using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

public partial class AppMain
{
    // Token: 0x0600185F RID: 6239 RVA: 0x000DB697 File Offset: 0x000D9897
    public static int amTextureLoad( AppMain.NNS_TEXLIST texlist, AppMain.NNS_TEXFILELIST texfilelist, string filepath )
    {
        AppMain.mppAssertNotImpl();
        return AppMain.amTextureLoad( texlist, texfilelist, filepath, null );
    }

    // Token: 0x06001860 RID: 6240 RVA: 0x000DB6A8 File Offset: 0x000D98A8
    public static int amTextureLoad( AppMain.NNS_TEXLIST texlist, AppMain.NNS_TEXFILELIST texfilelist, string filepath, AppMain.AMS_AMB_HEADER amb )
    {
        int result = 0;
        AppMain.ArrayPointer<AppMain.NNS_TEXINFO> pointer = new AppMain.ArrayPointer<AppMain.NNS_TEXINFO>(texlist.pTexInfoList);
        AppMain.ArrayPointer<AppMain.NNS_TEXFILE> pointer2 = new AppMain.ArrayPointer<AppMain.NNS_TEXFILE>(texfilelist.pTexFileList);
        int i = texfilelist.nTex;
        while ( i > 0 )
        {
            if ( amb == null )
            {
                result = AppMain.amTextureLoad( pointer, pointer2, filepath, null, 0 );
            }
            else
            {
                string text = (~pointer2).Filename;
                int num = text.LastIndexOf(".pvr", StringComparison.OrdinalIgnoreCase);
                if ( num > 0 )
                {
                    text = text.Remove( num );
                    text += ".PNG";
                }
                num = Array.IndexOf<string>( amb.files, text );
                Texture2D texture2D;
                if ( amb.buf[num] != null )
                {
                    texture2D = ( Texture2D )amb.buf[num];
                }
                else
                {
                    using ( MemoryStream memoryStream = new MemoryStream( amb.data, amb.offsets[num], amb.data.Length - amb.offsets[num] ) )
                    {
                        texture2D = Texture2D.FromStream( AppMain.m_game.GraphicsDevice, memoryStream );
                        amb.buf[num] = texture2D;
                    }
                }
                result = AppMain.amTextureLoad( pointer, pointer2, filepath, texture2D, 0 );
            }
            i--;
            pointer = ++pointer;
            pointer2 = ++pointer2;
        }
        return result;
    }

    // Token: 0x06001861 RID: 6241 RVA: 0x000DB7F4 File Offset: 0x000D99F4
    public static int amTextureLoad( AppMain.NNS_TEXINFO texinfo, AppMain.NNS_TEXFILE texfile, string filepath, Texture2D texbuf, int size )
    {
        AppMain.AMS_PARAM_LOAD_TEXTURE ams_PARAM_LOAD_TEXTURE = new AppMain.AMS_PARAM_LOAD_TEXTURE();
        ams_PARAM_LOAD_TEXTURE.pTexInfo = texinfo;
        ams_PARAM_LOAD_TEXTURE.tex = texbuf;
        ams_PARAM_LOAD_TEXTURE.size = ( uint )size;
        AppMain._amTextureSetupLoadParam( ref ams_PARAM_LOAD_TEXTURE, ref texfile, texbuf );
        return AppMain.amDrawRegistCommand( 1, ams_PARAM_LOAD_TEXTURE );
    }

    // Token: 0x06001862 RID: 6242 RVA: 0x000DB830 File Offset: 0x000D9A30
    public static int amTextureLoad( Texture2D texture, byte[] image, int size, int minfilter, int magfilter, int u_wrap, int v_wrap, byte[] gvrobj )
    {
        AppMain.mppAssertNotImpl();
        return AppMain.amDrawRegistCommand( 11, new AppMain.AMS_PARAM_LOAD_TEXTURE_IMAGE
        {
            texture = texture,
            size = size,
            minfilter = ( short )minfilter,
            magfilter = ( short )magfilter,
            u_wrap = ( short )u_wrap,
            v_wrap = ( short )v_wrap
        } );
    }

    // Token: 0x06001863 RID: 6243 RVA: 0x000DB890 File Offset: 0x000D9A90
    public static int amTextureRelease( AppMain.NNS_TEXLIST texlist )
    {
        return AppMain.amDrawRegistCommand( 2, new AppMain.AMS_PARAM_RELEASE_TEXTURE
        {
            texlist = texlist
        } );
    }

    // Token: 0x06001864 RID: 6244 RVA: 0x000DB8B1 File Offset: 0x000D9AB1
    public static int amTextureRelease( byte[] texture )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06001865 RID: 6245 RVA: 0x000DB8B9 File Offset: 0x000D9AB9
    public static byte[] _amTextureConvertHeader( ref AppMain.NNS_TEXINFO texinfo, ref byte[] texbuf )
    {
        AppMain.mppAssertNotImpl();
        return texbuf;
    }

    // Token: 0x06001866 RID: 6246 RVA: 0x000DB8C4 File Offset: 0x000D9AC4
    public static void _amTextureSetupLoadParam( ref AppMain.AMS_PARAM_LOAD_TEXTURE param, ref AppMain.NNS_TEXFILE texfile, Texture2D texload )
    {
        if ( ( texfile.fType & 512U ) != 0U )
        {
            param.minfilter = 0;
            param.magfilter = 0;
        }
        else
        {
            param.minfilter = texfile.MinFilter;
            param.magfilter = texfile.MagFilter;
        }
        if ( ( texfile.fType & 1024U ) != 0U )
        {
            param.globalIndex = texfile.GlobalIndex;
        }
        else
        {
            param.globalIndex = 0U;
        }
        if ( ( texfile.fType & 2048U ) != 0U )
        {
            param.bank = texfile.Bank;
            return;
        }
        param.bank = 0U;
    }
}
