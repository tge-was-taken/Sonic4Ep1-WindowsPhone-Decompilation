using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002C7 RID: 711
    public class MD_HEADER
    {
        // Token: 0x04005C1D RID: 23581
        public ushort map_w;

        // Token: 0x04005C1E RID: 23582
        public ushort map_h;

        // Token: 0x04005C1F RID: 23583
        public AppMain.MD_BLOCK[] blocks;
    }

    // Token: 0x020002C8 RID: 712
    public struct MD_BLOCK
    {
        // Token: 0x060024B0 RID: 9392 RVA: 0x0014B04C File Offset: 0x0014924C
        public MD_BLOCK( sbyte bitFieldValue )
        {
            int num = (int)(bitFieldValue & 15);
            this.ofst_x = ( ( num >= 8 ) ? ( ( sbyte )( num - 16 ) ) : ( ( sbyte )num ) );
            this.ofst_y = ( sbyte )( bitFieldValue >> 4 );
        }

        // Token: 0x04005C20 RID: 23584
        public sbyte ofst_x;

        // Token: 0x04005C21 RID: 23585
        public sbyte ofst_y;
    }
}