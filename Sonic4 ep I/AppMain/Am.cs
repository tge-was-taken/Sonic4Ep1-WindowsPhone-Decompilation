using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

public partial class AppMain
{
    // Token: 0x0200030C RID: 780
    public class AMS_VECTOR3I
    {
        // Token: 0x06002538 RID: 9528 RVA: 0x0014C241 File Offset: 0x0014A441
        public void Assign( AppMain.AMS_VECTOR3I other )
        {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        // Token: 0x06002539 RID: 9529 RVA: 0x0014C267 File Offset: 0x0014A467
        public void Assign( AppMain.VecFx32 v )
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        // Token: 0x04005D40 RID: 23872
        public int x;

        // Token: 0x04005D41 RID: 23873
        public int y;

        // Token: 0x04005D42 RID: 23874
        public int z;
    }

    // Token: 0x0200030D RID: 781
    public struct AMS_VECTOR4I
    {
        // Token: 0x04005D43 RID: 23875
        public int x;

        // Token: 0x04005D44 RID: 23876
        public int y;

        // Token: 0x04005D45 RID: 23877
        public int z;

        // Token: 0x04005D46 RID: 23878
        public int w;
    }

    // Token: 0x0200030E RID: 782
    [StructLayout( LayoutKind.Explicit )]
    public struct AMS_RGBA8888
    {
        // Token: 0x04005D47 RID: 23879
        [FieldOffset(0)]
        public byte r;

        // Token: 0x04005D48 RID: 23880
        [FieldOffset(1)]
        public byte g;

        // Token: 0x04005D49 RID: 23881
        [FieldOffset(2)]
        public byte b;

        // Token: 0x04005D4A RID: 23882
        [FieldOffset(3)]
        public byte a;

        // Token: 0x04005D4B RID: 23883
        [FieldOffset(0)]
        public uint color;
    }
}