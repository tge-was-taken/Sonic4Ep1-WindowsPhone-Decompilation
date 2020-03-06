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
    // Token: 0x020000B5 RID: 181
    public class NNS_BINCNK_FILEHEADER
    {
        // Token: 0x06001EDB RID: 7899 RVA: 0x0013C71C File Offset: 0x0013A91C
        public static AppMain.NNS_BINCNK_FILEHEADER Read( BinaryReader reader )
        {
            return new AppMain.NNS_BINCNK_FILEHEADER
            {
                Id = reader.ReadUInt32(),
                OfsNextId = reader.ReadInt32(),
                nChunk = reader.ReadInt32(),
                OfsData = reader.ReadInt32(),
                SizeData = reader.ReadInt32(),
                OfsNOF0 = reader.ReadInt32(),
                SizeNOF0 = reader.ReadInt32(),
                Version = reader.ReadInt32()
            };
        }

        // Token: 0x04004B28 RID: 19240
        public uint Id;

        // Token: 0x04004B29 RID: 19241
        public int OfsNextId;

        // Token: 0x04004B2A RID: 19242
        public int nChunk;

        // Token: 0x04004B2B RID: 19243
        public int OfsData;

        // Token: 0x04004B2C RID: 19244
        public int SizeData;

        // Token: 0x04004B2D RID: 19245
        public int OfsNOF0;

        // Token: 0x04004B2E RID: 19246
        public int SizeNOF0;

        // Token: 0x04004B2F RID: 19247
        public int Version;
    }

    // Token: 0x020000B6 RID: 182
    public class NNS_BINCNK_DATAHEADER
    {
        // Token: 0x06001EDD RID: 7901 RVA: 0x0013C798 File Offset: 0x0013A998
        public static AppMain.NNS_BINCNK_DATAHEADER Read( BinaryReader reader )
        {
            return new AppMain.NNS_BINCNK_DATAHEADER
            {
                Id = reader.ReadUInt32(),
                OfsNextId = reader.ReadInt32(),
                OfsMainData = reader.ReadInt32(),
                Version = reader.ReadInt32()
            };
        }

        // Token: 0x04004B30 RID: 19248
        public uint Id;

        // Token: 0x04004B31 RID: 19249
        public int OfsNextId;

        // Token: 0x04004B32 RID: 19250
        public int OfsMainData;

        // Token: 0x04004B33 RID: 19251
        public int Version;
    }

    // Token: 0x020000B7 RID: 183
    public class NNS_BINCNK_NOF0HEADER
    {
        // Token: 0x06001EDF RID: 7903 RVA: 0x0013C7E4 File Offset: 0x0013A9E4
        public static AppMain.NNS_BINCNK_NOF0HEADER Read( BinaryReader reader )
        {
            return new AppMain.NNS_BINCNK_NOF0HEADER
            {
                Id = reader.ReadUInt32(),
                OfsNextId = reader.ReadInt32(),
                nData = reader.ReadInt32(),
                Pad = reader.ReadInt32()
            };
        }

        // Token: 0x04004B34 RID: 19252
        public uint Id;

        // Token: 0x04004B35 RID: 19253
        public int OfsNextId;

        // Token: 0x04004B36 RID: 19254
        public int nData;

        // Token: 0x04004B37 RID: 19255
        public int Pad;
    }

}