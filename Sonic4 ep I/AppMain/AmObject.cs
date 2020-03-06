using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public partial class AppMain
{

    // Token: 0x06001145 RID: 4421 RVA: 0x000972F4 File Offset: 0x000954F4
    public static void amObjectSetup( out AppMain.NNS_OBJECT _object, out AppMain.NNS_TEXFILELIST texfilelist, object _buf )
    {
        _object = null;
        texfilelist = null;
        AppMain.AmbChunk ambChunk = (AppMain.AmbChunk)_buf;
        using ( MemoryStream memoryStream = new MemoryStream( ambChunk.array, ambChunk.offset, ambChunk.array.Length - ambChunk.offset ) )
        {
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            AppMain.NNS_BINCNK_FILEHEADER nns_BINCNK_FILEHEADER = AppMain.NNS_BINCNK_FILEHEADER.Read(binaryReader);
            long num;
            binaryReader.BaseStream.Seek( num = ( long )nns_BINCNK_FILEHEADER.OfsData, 0 );
            AppMain.NNS_BINCNK_DATAHEADER nns_BINCNK_DATAHEADER = AppMain.NNS_BINCNK_DATAHEADER.Read(binaryReader);
            long num2 = num;
            binaryReader.BaseStream.Seek( ( long )nns_BINCNK_FILEHEADER.OfsNOF0, 0 );
            AppMain.NNS_BINCNK_NOF0HEADER.Read( binaryReader );
            int i = nns_BINCNK_FILEHEADER.nChunk;
            while ( i > 0 )
            {
                uint id = nns_BINCNK_DATAHEADER.Id;
                if ( id != 1112492366U )
                {
                    if ( id == 1145980238U )
                    {
                        break;
                    }
                    if ( id == 1280592206U )
                    {
                        binaryReader.BaseStream.Seek( num2 + ( long )nns_BINCNK_DATAHEADER.OfsMainData, 0 );
                        texfilelist = AppMain.NNS_TEXFILELIST.Read( binaryReader, num2 );
                    }
                }
                else
                {
                    binaryReader.BaseStream.Seek( num2 + ( long )nns_BINCNK_DATAHEADER.OfsMainData, 0 );
                    _object = AppMain.NNS_OBJECT.Read( binaryReader, num2 );
                }
                i--;
                binaryReader.BaseStream.Seek( num += ( long )( 8 + nns_BINCNK_DATAHEADER.OfsNextId ), 0 );
                nns_BINCNK_DATAHEADER = AppMain.NNS_BINCNK_DATAHEADER.Read( binaryReader );
            }
        }
    }

    // Token: 0x06001146 RID: 4422 RVA: 0x00097444 File Offset: 0x00095644
    public static int amObjectLoad( out AppMain.NNS_OBJECT _object, AppMain.NNS_OBJECT obj_file, uint drawflag )
    {
        AppMain.AMS_PARAM_VERTEX_BUFFER_OBJECT ams_PARAM_VERTEX_BUFFER_OBJECT = new AppMain.AMS_PARAM_VERTEX_BUFFER_OBJECT();
        _object = new AppMain.NNS_OBJECT();
        ams_PARAM_VERTEX_BUFFER_OBJECT.obj = _object;
        ams_PARAM_VERTEX_BUFFER_OBJECT.srcobj = obj_file;
        ams_PARAM_VERTEX_BUFFER_OBJECT.bindflag = 0U;
        ams_PARAM_VERTEX_BUFFER_OBJECT.drawflag = drawflag;
        return AppMain.amDrawRegistCommand( 3, ams_PARAM_VERTEX_BUFFER_OBJECT );
    }

    // Token: 0x06001147 RID: 4423 RVA: 0x00097484 File Offset: 0x00095684
    public static int amObjectLoad( out AppMain.NNS_OBJECT _object, out AppMain.NNS_TEXLIST texlist, out object texlistbuf, object buf, uint drawflag, string filepath, AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.NNS_OBJECT obj_file;
        AppMain.NNS_TEXFILELIST nns_TEXFILELIST;
        AppMain.amObjectSetup( out obj_file, out nns_TEXFILELIST, buf );
        int nTex = nns_TEXFILELIST.nTex;
        texlistbuf = null;
        AppMain.nnSetUpTexlist( out texlist, nTex, ref texlistbuf );
        int result = AppMain.amObjectLoad(out _object, obj_file, drawflag);
        if ( filepath != null || amb != null )
        {
            result = AppMain.amTextureLoad( texlist, nns_TEXFILELIST, filepath, amb );
        }
        return result;
    }

    // Token: 0x06001148 RID: 4424 RVA: 0x000974D0 File Offset: 0x000956D0
    private static int amObjectLoad( out AppMain.NNS_OBJECT _object, AppMain.NNS_TEXFILELIST txbfilelist, out AppMain.NNS_TEXLIST texlist, out object texlistbuf, object buf, uint drawflag, string filepath, AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.NNS_OBJECT obj_file;
        AppMain.NNS_TEXFILELIST nns_TEXFILELIST;
        AppMain.amObjectSetup( out obj_file, out nns_TEXFILELIST, buf );
        int nTex = txbfilelist.nTex;
        texlistbuf = null;
        AppMain.nnSetUpTexlist( out texlist, nTex, ref texlistbuf );
        int result = AppMain.amObjectLoad(out _object, obj_file, drawflag);
        if ( filepath != null || amb != null )
        {
            result = AppMain.amTextureLoad( texlist, txbfilelist, filepath, amb );
        }
        return result;
    }

    // Token: 0x06001149 RID: 4425 RVA: 0x0009751A File Offset: 0x0009571A
    private int amObjectLoadShader( ref AppMain.NNS_OBJECT _object, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x0600114A RID: 4426 RVA: 0x00097522 File Offset: 0x00095722
    private int amObjectLoadShader( ref AppMain.NNS_OBJECT _object, int num, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x0600114B RID: 4427 RVA: 0x0009752C File Offset: 0x0009572C
    public static int amObjectRelease( AppMain.NNS_OBJECT _object )
    {
        return AppMain.amDrawRegistCommand( 4, new AppMain.AMS_PARAM_DELETE_VERTEX_OBJECT
        {
            obj = _object
        } );
    }

    // Token: 0x0600114C RID: 4428 RVA: 0x0009754D File Offset: 0x0009574D
    private static int amObjectRelease( AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist )
    {
        AppMain.amObjectRelease( _object );
        return AppMain.amTextureRelease( texlist );
    }
}
