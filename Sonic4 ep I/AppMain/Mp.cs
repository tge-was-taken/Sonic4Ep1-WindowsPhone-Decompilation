using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002C5 RID: 709
    public class MP_HEADER
    {
        // Token: 0x04005C16 RID: 23574
        public ushort map_w;

        // Token: 0x04005C17 RID: 23575
        public ushort map_h;

        // Token: 0x04005C18 RID: 23576
        public AppMain.MP_BLOCK[] blocks;
    }

    // Token: 0x020002C6 RID: 710
    public struct MP_BLOCK
    {
        // Token: 0x060024AE RID: 9390 RVA: 0x0014B00D File Offset: 0x0014920D
        public MP_BLOCK( ushort bitFieldValue )
        {
            this.id = ( ushort )( bitFieldValue & 4095 );
            this.rot = ( ushort )( bitFieldValue >> 12 & 3 );
            this.flip_h = ( ushort )( bitFieldValue >> 14 & 1 );
            this.flip_v = ( ushort )( bitFieldValue >> 15 & 1 );
        }

        // Token: 0x04005C19 RID: 23577
        public ushort id;

        // Token: 0x04005C1A RID: 23578
        public ushort rot;

        // Token: 0x04005C1B RID: 23579
        public ushort flip_h;

        // Token: 0x04005C1C RID: 23580
        public ushort flip_v;
    }
}