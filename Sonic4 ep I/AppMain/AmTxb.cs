using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;

public partial class AppMain
{
    // Token: 0x0200033E RID: 830
    private enum TXB_MAG_FILTER
    {
        // Token: 0x04005E82 RID: 24194
        TXB_MAGF_N,
        // Token: 0x04005E83 RID: 24195
        TXB_MAGF_L,
        // Token: 0x04005E84 RID: 24196
        TXB_MAGF_A,
        // Token: 0x04005E85 RID: 24197
        TXB_MAGF_NUM
    }

    // Token: 0x0200033F RID: 831
    private enum TXB_MIN_FILTER
    {
        // Token: 0x04005E87 RID: 24199
        TXB_MINF_N,
        // Token: 0x04005E88 RID: 24200
        TXB_MINF_L,
        // Token: 0x04005E89 RID: 24201
        TXB_MINF_N_M_N,
        // Token: 0x04005E8A RID: 24202
        TXB_MINF_N_M_L,
        // Token: 0x04005E8B RID: 24203
        TXB_MINF_L_M_N,
        // Token: 0x04005E8C RID: 24204
        TXB_MINF_L_M_L,
        // Token: 0x04005E8D RID: 24205
        TXB_MINF_A2,
        // Token: 0x04005E8E RID: 24206
        TXB_MINF_A2_M_N,
        // Token: 0x04005E8F RID: 24207
        TXB_MINF_A2_M_L,
        // Token: 0x04005E90 RID: 24208
        TXB_MINF_A4,
        // Token: 0x04005E91 RID: 24209
        TXB_MINF_A4_M_N,
        // Token: 0x04005E92 RID: 24210
        TXB_MINF_A4_M_L,
        // Token: 0x04005E93 RID: 24211
        TXB_MINF_A8,
        // Token: 0x04005E94 RID: 24212
        TXB_MINF_A8_M_N,
        // Token: 0x04005E95 RID: 24213
        TXB_MINF_A8_M_L,
        // Token: 0x04005E96 RID: 24214
        TXB_MINF_NUM
    }

    // Token: 0x02000340 RID: 832
    public class TXB_TEXFILE : AppMain.NNS_TEXFILE
    {
        // Token: 0x04005E97 RID: 24215
        public int name_offset;
    }

    // Token: 0x02000341 RID: 833
    public class TXB_TEXFILELIST : AppMain.NNS_TEXFILELIST
    {
        // Token: 0x04005E98 RID: 24216
        public int tex_list_offset;
    }

    // Token: 0x02000342 RID: 834
    public class TXB_HEADER
    {
        // Token: 0x04005E99 RID: 24217
        public byte[] file_id = new byte[4];

        // Token: 0x04005E9A RID: 24218
        public int texfilelist_offset;

        // Token: 0x04005E9B RID: 24219
        public AppMain.TXB_TEXFILELIST texfilelist = new AppMain.TXB_TEXFILELIST();

        // Token: 0x04005E9C RID: 24220
        public byte[] pad = new byte[8];
    }

    // Token: 0x0600170A RID: 5898 RVA: 0x000C9174 File Offset: 0x000C7374
    public static AppMain.TXB_HEADER readTXBfile( object data )
    {
        AppMain.AmbChunk ambChunk = (AppMain.AmbChunk)data;
        return AppMain.readTXBfile( ambChunk.array, ambChunk.offset );
    }

    // Token: 0x0600170B RID: 5899 RVA: 0x000C9199 File Offset: 0x000C7399
    public static AppMain.TXB_HEADER readTXBfile( byte[] data, int offset )
    {
        return AppMain.readTXBfile( data, offset, null );
    }

    // Token: 0x0600170C RID: 5900 RVA: 0x000C91A4 File Offset: 0x000C73A4
    public static AppMain.TXB_HEADER readTXBfile( byte[] data, int offset, string sPath )
    {
        AppMain.TXB_HEADER result = null;
        if ( data != null )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data, offset, data.Length - offset ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    result = AppMain.readTXBfile( binaryReader, sPath );
                }
            }
        }
        return result;
    }

    // Token: 0x0600170D RID: 5901 RVA: 0x000C9208 File Offset: 0x000C7408
    public static AppMain.TXB_HEADER readTXBfile( BinaryReader br )
    {
        return AppMain.readTXBfile( br, null );
    }

    // Token: 0x0600170E RID: 5902 RVA: 0x000C9214 File Offset: 0x000C7414
    public static AppMain.TXB_HEADER readTXBfile( BinaryReader br, string sPath )
    {
        AppMain.TXB_HEADER txb_HEADER = new AppMain.TXB_HEADER();
        txb_HEADER.file_id = br.ReadBytes( 4 );
        txb_HEADER.texfilelist_offset = AppMain._amConvertEndian( br.ReadInt32() );
        txb_HEADER.pad = br.ReadBytes( 8 );
        br.BaseStream.Position = ( long )txb_HEADER.texfilelist_offset;
        txb_HEADER.texfilelist.nTex = AppMain._amConvertEndian( br.ReadInt32() );
        txb_HEADER.texfilelist.tex_list_offset = AppMain._amConvertEndian( br.ReadInt32() );
        if ( txb_HEADER.texfilelist.tex_list_offset != 0 )
        {
            br.BaseStream.Position = ( long )txb_HEADER.texfilelist.tex_list_offset;
            txb_HEADER.texfilelist.pTexFileList = new AppMain.TXB_TEXFILE[txb_HEADER.texfilelist.nTex];
            for ( int i = 0; i < txb_HEADER.texfilelist.nTex; i++ )
            {
                txb_HEADER.texfilelist.pTexFileList[i] = new AppMain.TXB_TEXFILE();
                txb_HEADER.texfilelist.pTexFileList[i].fType = AppMain._amConvertEndian( br.ReadUInt32() );
                ( ( AppMain.TXB_TEXFILE )txb_HEADER.texfilelist.pTexFileList[i] ).name_offset = AppMain._amConvertEndian( br.ReadInt32() );
                txb_HEADER.texfilelist.pTexFileList[i].MinFilter = AppMain._amConvertEndian( br.ReadUInt16() );
                txb_HEADER.texfilelist.pTexFileList[i].MagFilter = AppMain._amConvertEndian( br.ReadUInt16() );
                txb_HEADER.texfilelist.pTexFileList[i].GlobalIndex = AppMain._amConvertEndian( br.ReadUInt32() );
                txb_HEADER.texfilelist.pTexFileList[i].Bank = AppMain._amConvertEndian( br.ReadUInt32() );
            }
            for ( int j = 0; j < txb_HEADER.texfilelist.nTex; j++ )
            {
                br.BaseStream.Position = ( long )( ( AppMain.TXB_TEXFILE )txb_HEADER.texfilelist.pTexFileList[j] ).name_offset;
                txb_HEADER.texfilelist.pTexFileList[j].Filename = AppMain.readChars( br );
                string filename = txb_HEADER.texfilelist.pTexFileList[j].Filename.Replace(".PVR", ".PNG");
                txb_HEADER.texfilelist.pTexFileList[j].Filename = filename;
            }
        }
        return txb_HEADER;
    }

    // Token: 0x0600170F RID: 5903 RVA: 0x000C943D File Offset: 0x000C763D
    private static AppMain.NNS_TEXFILELIST amTxbGetTexFileList( AppMain.TXB_HEADER txb )
    {
        return txb.texfilelist;
    }

    // Token: 0x06001710 RID: 5904 RVA: 0x000C9445 File Offset: 0x000C7645
    private static uint amTxbGetCount( AppMain.TXB_HEADER txb )
    {
        if ( txb == null )
        {
            return 0U;
        }
        return ( uint )txb.texfilelist.nTex;
    }

    // Token: 0x06001711 RID: 5905 RVA: 0x000C9457 File Offset: 0x000C7657
    private ushort amTxbGetMagFilter( AppMain.TXB_HEADER txb, uint tex_no )
    {
        AppMain.mppAssertNotImpl();
        if ( tex_no >= AppMain.amTxbGetCount( txb ) )
        {
            return AppMain.g_txb_mag_filter[0];
        }
        return txb.texfilelist.pTexFileList[( int )( ( UIntPtr )tex_no )].MagFilter;
    }

    // Token: 0x06001712 RID: 5906 RVA: 0x000C9482 File Offset: 0x000C7682
    private ushort amTxbGetMinFilter( AppMain.TXB_HEADER txb, uint tex_no )
    {
        AppMain.mppAssertNotImpl();
        if ( tex_no >= AppMain.amTxbGetCount( txb ) )
        {
            return AppMain.g_txb_min_filter[0];
        }
        return txb.texfilelist.pTexFileList[( int )( ( UIntPtr )tex_no )].MinFilter;
    }

    // Token: 0x06001713 RID: 5907 RVA: 0x000C94AD File Offset: 0x000C76AD
    private string amTxbGetName( AppMain.TXB_HEADER txb, uint tex_no )
    {
        AppMain.mppAssertNotImpl();
        if ( tex_no >= AppMain.amTxbGetCount( txb ) )
        {
            tex_no = 0U;
        }
        return txb.texfilelist.pTexFileList[( int )( ( UIntPtr )tex_no )].Filename;
    }

    // Token: 0x06001714 RID: 5908 RVA: 0x000C94D3 File Offset: 0x000C76D3
    private static int amTxbConv( AppMain.TXB_HEADER header )
    {
        return 0;
    }

    // Token: 0x06001715 RID: 5909 RVA: 0x000C94D6 File Offset: 0x000C76D6
    private static int amTxbConv( byte[] stream )
    {
        AppMain.mppAssertNotImpl();
        return 1;
    }
}
