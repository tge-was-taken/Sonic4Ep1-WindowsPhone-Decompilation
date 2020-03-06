using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;

public partial class AppMain
{
    // Token: 0x02000101 RID: 257
    public class NNS_TEXFILE
    {
        // Token: 0x06001FB5 RID: 8117 RVA: 0x0013D040 File Offset: 0x0013B240
        public static AppMain.NNS_TEXFILE Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_TEXFILE nns_TEXFILE = new AppMain.NNS_TEXFILE();
            nns_TEXFILE.fType = reader.ReadUInt32();
            uint num = reader.ReadUInt32();
            nns_TEXFILE.MinFilter = reader.ReadUInt16();
            nns_TEXFILE.MagFilter = reader.ReadUInt16();
            nns_TEXFILE.GlobalIndex = reader.ReadUInt32();
            nns_TEXFILE.Bank = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                StringBuilder stringBuilder = new StringBuilder();
                byte b;
                while ( ( b = reader.ReadByte() ) != 0 )
                {
                    stringBuilder.Append( ( char )b );
                }
                nns_TEXFILE.Filename = stringBuilder.ToString().ToUpper();
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_TEXFILE;
        }

        // Token: 0x04004C13 RID: 19475
        public uint fType;

        // Token: 0x04004C14 RID: 19476
        public string Filename;

        // Token: 0x04004C15 RID: 19477
        public ushort MinFilter;

        // Token: 0x04004C16 RID: 19478
        public ushort MagFilter;

        // Token: 0x04004C17 RID: 19479
        public uint GlobalIndex;

        // Token: 0x04004C18 RID: 19480
        public uint Bank;
    }

    // Token: 0x02000102 RID: 258
    public class NNS_TEXFILELIST
    {
        // Token: 0x06001FB7 RID: 8119 RVA: 0x0013D0FC File Offset: 0x0013B2FC
        public static AppMain.NNS_TEXFILELIST Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_TEXFILELIST nns_TEXFILELIST = new AppMain.NNS_TEXFILELIST();
            nns_TEXFILELIST.nTex = reader.ReadInt32();
            nns_TEXFILELIST.pTexFileList = new AppMain.NNS_TEXFILE[nns_TEXFILELIST.nTex];
            uint num = reader.ReadUInt32();
            reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
            for ( int i = 0; i < nns_TEXFILELIST.nTex; i++ )
            {
                nns_TEXFILELIST.pTexFileList[i] = AppMain.NNS_TEXFILE.Read( reader, data0Pos );
            }
            return nns_TEXFILELIST;
        }

        // Token: 0x04004C19 RID: 19481
        public int nTex;

        // Token: 0x04004C1A RID: 19482
        public AppMain.NNS_TEXFILE[] pTexFileList;
    }

    // Token: 0x0200013D RID: 317
    public class NNS_TEXINFO
    {
        // Token: 0x06002083 RID: 8323 RVA: 0x0013EB22 File Offset: 0x0013CD22
        public NNS_TEXINFO()
        {
        }

        // Token: 0x06002084 RID: 8324 RVA: 0x0013EB2A File Offset: 0x0013CD2A
        public NNS_TEXINFO( AppMain.NNS_TEXINFO pFrom )
        {
            this.TexName = pFrom.TexName;
            this.GlobalIndex = pFrom.GlobalIndex;
            this.Bank = pFrom.Bank;
            this.Flag = pFrom.Flag;
        }

        // Token: 0x06002085 RID: 8325 RVA: 0x0013EB64 File Offset: 0x0013CD64
        public static AppMain.NNS_TEXINFO Read( BinaryReader reader )
        {
            return new AppMain.NNS_TEXINFO
            {
                TexName = reader.ReadUInt32(),
                GlobalIndex = reader.ReadUInt32(),
                Bank = reader.ReadUInt32(),
                Flag = reader.ReadUInt32()
            };
        }

        // Token: 0x04004D12 RID: 19730
        public uint TexName;

        // Token: 0x04004D13 RID: 19731
        public uint GlobalIndex;

        // Token: 0x04004D14 RID: 19732
        public uint Bank;

        // Token: 0x04004D15 RID: 19733
        public uint Flag;
    }

    // Token: 0x0200013E RID: 318
    public class NNS_TEXLIST
    {
        // Token: 0x06002086 RID: 8326 RVA: 0x0013EBA8 File Offset: 0x0013CDA8
        public NNS_TEXLIST()
        {
        }

        // Token: 0x06002087 RID: 8327 RVA: 0x0013EBB0 File Offset: 0x0013CDB0
        public NNS_TEXLIST( AppMain.NNS_TEXLIST pFrom )
        {
            this.nTex = pFrom.nTex;
            this.pTexInfoList = new AppMain.NNS_TEXINFO[this.nTex];
            for ( int i = 0; i < this.nTex; i++ )
            {
                this.pTexInfoList[i] = new AppMain.NNS_TEXINFO( pFrom.pTexInfoList[i] );
            }
        }

        // Token: 0x06002088 RID: 8328 RVA: 0x0013EC06 File Offset: 0x0013CE06
        public void Clear()
        {
            this.nTex = 0;
            this.pTexInfoList = null;
        }

        // Token: 0x04004D16 RID: 19734
        public int nTex;

        // Token: 0x04004D17 RID: 19735
        public AppMain.NNS_TEXINFO[] pTexInfoList;
    }
}