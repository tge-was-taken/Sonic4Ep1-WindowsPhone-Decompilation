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
    // Token: 0x0200008B RID: 139
    public struct SNNS_RGB
    {
        // Token: 0x06001E65 RID: 7781 RVA: 0x0013A56F File Offset: 0x0013876F
        public SNNS_RGB( float _r, float _g, float _b )
        {
            this.r = _r;
            this.g = _g;
            this.b = _b;
        }

        // Token: 0x06001E66 RID: 7782 RVA: 0x0013A586 File Offset: 0x00138786
        public void Assign( AppMain.NNS_RGB rgb )
        {
            this.r = rgb.r;
            this.g = rgb.g;
            this.b = rgb.b;
        }

        // Token: 0x06001E67 RID: 7783 RVA: 0x0013A5AC File Offset: 0x001387AC
        public void Clear()
        {
            this.r = ( this.g = ( this.b = 0f ) );
        }

        // Token: 0x04004A37 RID: 18999
        public float r;

        // Token: 0x04004A38 RID: 19000
        public float g;

        // Token: 0x04004A39 RID: 19001
        public float b;
    }

    // Token: 0x0200008C RID: 140
    public class NNS_RGB : AppMain.IClearable
    {
        // Token: 0x06001E68 RID: 7784 RVA: 0x0013A5D6 File Offset: 0x001387D6
        public NNS_RGB()
        {
        }

        // Token: 0x06001E69 RID: 7785 RVA: 0x0013A5DE File Offset: 0x001387DE
        public NNS_RGB( float _r, float _g, float _b )
        {
            this.r = _r;
            this.g = _g;
            this.b = _b;
        }

        // Token: 0x06001E6A RID: 7786 RVA: 0x0013A5FB File Offset: 0x001387FB
        public AppMain.NNS_RGB Assign( AppMain.NNS_RGB rgb )
        {
            this.r = rgb.r;
            this.g = rgb.g;
            this.b = rgb.b;
            return this;
        }

        // Token: 0x06001E6B RID: 7787 RVA: 0x0013A624 File Offset: 0x00138824
        public void Clear()
        {
            this.r = ( this.g = ( this.b = 0f ) );
        }

        // Token: 0x04004A3A RID: 19002
        public float r;

        // Token: 0x04004A3B RID: 19003
        public float g;

        // Token: 0x04004A3C RID: 19004
        public float b;
    }

    // Token: 0x0200008D RID: 141
    public struct NNS_RGBA
    {
        // Token: 0x06001E6C RID: 7788 RVA: 0x0013A650 File Offset: 0x00138850
        public void Clear()
        {
            this.r = ( this.g = ( this.b = ( this.a = 0f ) ) );
        }

        // Token: 0x06001E6D RID: 7789 RVA: 0x0013A683 File Offset: 0x00138883
        public NNS_RGBA( float _r, float _g, float _b, float _a )
        {
            this.r = _r;
            this.g = _g;
            this.b = _b;
            this.a = _a;
        }

        // Token: 0x06001E6E RID: 7790 RVA: 0x0013A6A2 File Offset: 0x001388A2
        public static explicit operator OpenGL.glArray4f( AppMain.NNS_RGBA c )
        {
            return new OpenGL.glArray4f( c.r, c.g, c.b, c.a );
        }

        // Token: 0x04004A3D RID: 19005
        public float r;

        // Token: 0x04004A3E RID: 19006
        public float g;

        // Token: 0x04004A3F RID: 19007
        public float b;

        // Token: 0x04004A40 RID: 19008
        public float a;
    }

    // Token: 0x0200008E RID: 142
    public class NNS_RGB_U8
    {
        // Token: 0x04004A41 RID: 19009
        public byte r;

        // Token: 0x04004A42 RID: 19010
        public byte g;

        // Token: 0x04004A43 RID: 19011
        public byte b;

        // Token: 0x04004A44 RID: 19012
        public byte a;
    }

    // Token: 0x02000090 RID: 144
    public class NNS_RGBA_U8
    {
        // Token: 0x06001E71 RID: 7793 RVA: 0x0013A6F0 File Offset: 0x001388F0
        public NNS_RGBA_U8( byte _r, byte _g, byte _b, byte _a )
        {
            this.r = _r;
            this.g = _g;
            this.b = _b;
            this.a = _a;
        }

        // Token: 0x06001E72 RID: 7794 RVA: 0x0013A715 File Offset: 0x00138915
        public NNS_RGBA_U8()
        {
        }

        // Token: 0x06001E73 RID: 7795 RVA: 0x0013A71D File Offset: 0x0013891D
        public static int SizeOf()
        {
            return 4;
        }

        // Token: 0x04004A49 RID: 19017
        public byte r;

        // Token: 0x04004A4A RID: 19018
        public byte g;

        // Token: 0x04004A4B RID: 19019
        public byte b;

        // Token: 0x04004A4C RID: 19020
        public byte a;
    }

    // Token: 0x02000091 RID: 145
    public class NNS_RGBA_U32
    {
        // Token: 0x04004A4D RID: 19021
        public byte r;

        // Token: 0x04004A4E RID: 19022
        public byte g;

        // Token: 0x04004A4F RID: 19023
        public byte b;

        // Token: 0x04004A50 RID: 19024
        public byte a;
    }

    // Token: 0x02000092 RID: 146
    public class NNS_ROTATE
    {
        // Token: 0x04004A51 RID: 19025
        public float x;

        // Token: 0x04004A52 RID: 19026
        public float y;

        // Token: 0x04004A53 RID: 19027
        public float z;
    }

    // Token: 0x02000093 RID: 147
    public struct NNS_ROTATE_A32
    {
        // Token: 0x06001E76 RID: 7798 RVA: 0x0013A730 File Offset: 0x00138930
        public NNS_ROTATE_A32( int x, int y, int z )
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Token: 0x06001E77 RID: 7799 RVA: 0x0013A748 File Offset: 0x00138948
        public static explicit operator int[]( AppMain.NNS_ROTATE_A32 rv )
        {
            return new int[]
            {
                rv.x,
                rv.y,
                rv.z
            };
        }

        // Token: 0x06001E78 RID: 7800 RVA: 0x0013A77C File Offset: 0x0013897C
        public static explicit operator AppMain.NNS_ROTATE_A32( int[] array )
        {
            return new AppMain.NNS_ROTATE_A32
            {
                x = array[0],
                y = array[1],
                z = array[2]
            };
        }

        // Token: 0x04004A54 RID: 19028
        public int x;

        // Token: 0x04004A55 RID: 19029
        public int y;

        // Token: 0x04004A56 RID: 19030
        public int z;
    }

    // Token: 0x02000094 RID: 148
    public struct NNS_ROTATE_A16
    {
        // Token: 0x06001E79 RID: 7801 RVA: 0x0013A7B0 File Offset: 0x001389B0
        public NNS_ROTATE_A16( short x, short y, short z )
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Token: 0x04004A57 RID: 19031
        public short x;

        // Token: 0x04004A58 RID: 19032
        public short y;

        // Token: 0x04004A59 RID: 19033
        public short z;
    }

    // Token: 0x02000095 RID: 149
    public struct NNS_TEXCOORD : AppMain.IClearable
    {
        // Token: 0x06001E7A RID: 7802 RVA: 0x0013A7C7 File Offset: 0x001389C7
        public NNS_TEXCOORD( float u, float v )
        {
            this.u = u;
            this.v = v;
        }

        // Token: 0x06001E7B RID: 7803 RVA: 0x0013A7D8 File Offset: 0x001389D8
        public void Clear()
        {
            this.u = ( this.v = 0f );
        }

        // Token: 0x04004A5A RID: 19034
        public float u;

        // Token: 0x04004A5B RID: 19035
        public float v;
    }

    // Token: 0x02000096 RID: 150
    public struct NNS_VECTORFAST
    {
        // Token: 0x06001E7C RID: 7804 RVA: 0x0013A7F9 File Offset: 0x001389F9
        public NNS_VECTORFAST( AppMain.NNS_VECTORFAST vector )
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
            this.w = vector.w;
        }

        // Token: 0x06001E7D RID: 7805 RVA: 0x0013A82F File Offset: 0x00138A2F
        public void Assign( AppMain.NNS_VECTORFAST vector )
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
            this.w = vector.w;
        }

        // Token: 0x04004A5C RID: 19036
        public float x;

        // Token: 0x04004A5D RID: 19037
        public float y;

        // Token: 0x04004A5E RID: 19038
        public float z;

        // Token: 0x04004A5F RID: 19039
        public float w;
    }

    // Token: 0x02000097 RID: 151
    public class NNS_VECTOR_S16
    {
        // Token: 0x04004A60 RID: 19040
        public short x;

        // Token: 0x04004A61 RID: 19041
        public short y;

        // Token: 0x04004A62 RID: 19042
        public short z;
    }

    // Token: 0x02000098 RID: 152
    public class NNS_VECTOR_S8
    {
        // Token: 0x04004A63 RID: 19043
        public sbyte x;

        // Token: 0x04004A64 RID: 19044
        public sbyte y;

        // Token: 0x04004A65 RID: 19045
        public sbyte z;
    }

    // Token: 0x02000099 RID: 153
    public class NNS_VECTOR2D
    {
        // Token: 0x06001E80 RID: 7808 RVA: 0x0013A875 File Offset: 0x00138A75
        public AppMain.NNS_VECTOR2D Assign( AppMain.NNS_VECTOR2D vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            return this;
        }

        // Token: 0x06001E81 RID: 7809 RVA: 0x0013A890 File Offset: 0x00138A90
        public void Clear()
        {
            this.x = ( this.y = 0f );
        }

        // Token: 0x06001E82 RID: 7810 RVA: 0x0013A8B4 File Offset: 0x00138AB4
        public static AppMain.NNS_VECTOR2D Read( BinaryReader reader )
        {
            return new AppMain.NNS_VECTOR2D
            {
                x = reader.ReadSingle(),
                y = reader.ReadSingle()
            };
        }

        // Token: 0x04004A66 RID: 19046
        public float x;

        // Token: 0x04004A67 RID: 19047
        public float y;
    }

    // Token: 0x0200009A RID: 154
    public class NNS_VECTOR : AppMain.IClearable
    {
        // Token: 0x06001E84 RID: 7812 RVA: 0x0013A8E8 File Offset: 0x00138AE8
        public NNS_VECTOR()
        {
        }

        // Token: 0x06001E85 RID: 7813 RVA: 0x0013A8F0 File Offset: 0x00138AF0
        public NNS_VECTOR( float _x, float _y, float _z )
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }

        // Token: 0x06001E86 RID: 7814 RVA: 0x0013A90D File Offset: 0x00138B0D
        public AppMain.NNS_VECTOR Assign( AppMain.NNS_VECTOR vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
            return this;
        }

        // Token: 0x06001E87 RID: 7815 RVA: 0x0013A934 File Offset: 0x00138B34
        public AppMain.NNS_VECTOR Assign( ref AppMain.SNNS_VECTOR vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
            return this;
        }

        // Token: 0x06001E88 RID: 7816 RVA: 0x0013A95B File Offset: 0x00138B5B
        public AppMain.NNS_VECTOR Assign( ref AppMain.SNNS_VECTOR4D vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
            return this;
        }

        // Token: 0x06001E89 RID: 7817 RVA: 0x0013A984 File Offset: 0x00138B84
        public void Clear()
        {
            this.x = ( this.y = ( this.z = 0f ) );
        }

        // Token: 0x06001E8A RID: 7818 RVA: 0x0013A9AE File Offset: 0x00138BAE
        public static explicit operator OpenGL.glArray4f( AppMain.NNS_VECTOR v )
        {
            return new OpenGL.glArray4f( v.x, v.y, v.z, 0f );
        }

        // Token: 0x06001E8B RID: 7819 RVA: 0x0013A9CC File Offset: 0x00138BCC
        public static explicit operator float[]( AppMain.NNS_VECTOR v )
        {
            return new float[]
            {
                v.x,
                v.y,
                v.z
            };
        }

        // Token: 0x06001E8C RID: 7820 RVA: 0x0013A9FC File Offset: 0x00138BFC
        internal AppMain.NNS_VECTOR Assign( AppMain.VecFx32 vec )
        {
            this.x = ( float )vec.x;
            this.y = ( float )vec.y;
            this.z = ( float )vec.z;
            return this;
        }

        // Token: 0x06001E8D RID: 7821 RVA: 0x0013AA2C File Offset: 0x00138C2C
        public static AppMain.NNS_VECTOR Read( BinaryReader reader )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            nns_VECTOR.x = reader.ReadSingle();
            nns_VECTOR.y = reader.ReadSingle();
            nns_VECTOR.z = reader.ReadSingle();
            return nns_VECTOR;
        }

        // Token: 0x04004A68 RID: 19048
        public float x;

        // Token: 0x04004A69 RID: 19049
        public float y;

        // Token: 0x04004A6A RID: 19050
        public float z;
    }

    // Token: 0x0200009B RID: 155
    public class NNS_VECTOR4D : AppMain.NNS_VECTOR
    {
        // Token: 0x06001E8E RID: 7822 RVA: 0x0013AA64 File Offset: 0x00138C64
        public new void Clear()
        {
            base.Clear();
            this.w = 0f;
        }

        // Token: 0x06001E8F RID: 7823 RVA: 0x0013AA77 File Offset: 0x00138C77
        public void Assign( AppMain.NNS_VECTOR4D v )
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        // Token: 0x06001E90 RID: 7824 RVA: 0x0013AAA9 File Offset: 0x00138CA9
        public static explicit operator OpenGL.glArray4f( AppMain.NNS_VECTOR4D v )
        {
            return new OpenGL.glArray4f( v.x, v.y, v.z, v.w );
        }

        // Token: 0x06001E91 RID: 7825 RVA: 0x0013AAC8 File Offset: 0x00138CC8
        public static explicit operator float[]( AppMain.NNS_VECTOR4D v )
        {
            return new float[]
            {
                v.x,
                v.y,
                v.z,
                v.w
            };
        }

        // Token: 0x04004A6B RID: 19051
        public float w;
    }

    // Token: 0x0200009C RID: 156
    public struct SNNS_VECTOR4D
    {
        // Token: 0x06001E93 RID: 7827 RVA: 0x0013AB09 File Offset: 0x00138D09
        public void Assign( ref AppMain.SNNS_VECTOR4D val )
        {
            this.x = val.x;
            this.y = val.y;
            this.z = val.z;
            this.w = val.w;
        }

        // Token: 0x06001E94 RID: 7828 RVA: 0x0013AB3C File Offset: 0x00138D3C
        public void Clear()
        {
            this.x = ( this.y = ( this.z = ( this.w = 0f ) ) );
        }

        // Token: 0x04004A6C RID: 19052
        public float x;

        // Token: 0x04004A6D RID: 19053
        public float y;

        // Token: 0x04004A6E RID: 19054
        public float z;

        // Token: 0x04004A6F RID: 19055
        public float w;
    }

    // Token: 0x0200009D RID: 157
    public struct SNNS_VECTOR
    {
        // Token: 0x06001E95 RID: 7829 RVA: 0x0013AB6F File Offset: 0x00138D6F
        public SNNS_VECTOR( AppMain.NNS_VECTOR vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }

        // Token: 0x06001E96 RID: 7830 RVA: 0x0013AB95 File Offset: 0x00138D95
        public void Assign( AppMain.NNS_VECTOR vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }

        // Token: 0x06001E97 RID: 7831 RVA: 0x0013ABBB File Offset: 0x00138DBB
        public void Assign( ref AppMain.SNNS_VECTOR vec )
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }

        // Token: 0x04004A70 RID: 19056
        public float x;

        // Token: 0x04004A71 RID: 19057
        public float y;

        // Token: 0x04004A72 RID: 19058
        public float z;
    }

    // Token: 0x0200009F RID: 159
    public class NNS_TEXCOORD_S16
    {
        // Token: 0x04004A76 RID: 19062
        public short u;

        // Token: 0x04004A77 RID: 19063
        public short v;
    }

    // Token: 0x020000A0 RID: 160
    public class NNS_TEXCOORD_U16
    {
        // Token: 0x04004A78 RID: 19064
        public ushort u;

        // Token: 0x04004A79 RID: 19065
        public ushort v;
    }

    // Token: 0x020000A1 RID: 161
    public struct NNS_QUATERNION
    {
        // Token: 0x06001E9D RID: 7837 RVA: 0x0013AC3B File Offset: 0x00138E3B
        public NNS_QUATERNION( float x, float y, float z, float w )
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        // Token: 0x06001E9E RID: 7838 RVA: 0x0013AC5A File Offset: 0x00138E5A
        public void Assign( AppMain.NNS_QUATERNION q )
        {
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }

        // Token: 0x06001E9F RID: 7839 RVA: 0x0013AC90 File Offset: 0x00138E90
        public void Clear()
        {
            this.x = 0f;
            this.y = 0f;
            this.z = 0f;
            this.w = 0f;
        }

        // Token: 0x04004A7A RID: 19066
        public float x;

        // Token: 0x04004A7B RID: 19067
        public float y;

        // Token: 0x04004A7C RID: 19068
        public float z;

        // Token: 0x04004A7D RID: 19069
        public float w;
    }

    // Token: 0x020000A2 RID: 162
    public struct SNNS_MATRIX
    {
        // Token: 0x06001EA0 RID: 7840 RVA: 0x0013ACC0 File Offset: 0x00138EC0
        public void Assign( AppMain.NNS_MATRIX matrix )
        {
            this.M00 = matrix.M00;
            this.M01 = matrix.M01;
            this.M02 = matrix.M02;
            this.M03 = matrix.M03;
            this.M10 = matrix.M10;
            this.M11 = matrix.M11;
            this.M12 = matrix.M12;
            this.M13 = matrix.M13;
            this.M20 = matrix.M20;
            this.M21 = matrix.M21;
            this.M22 = matrix.M22;
            this.M23 = matrix.M23;
            this.M30 = matrix.M30;
            this.M31 = matrix.M31;
            this.M32 = matrix.M32;
            this.M33 = matrix.M33;
        }

        // Token: 0x06001EA1 RID: 7841 RVA: 0x0013AD90 File Offset: 0x00138F90
        public void Assign( ref AppMain.SNNS_MATRIX matrix )
        {
            this.M00 = matrix.M00;
            this.M01 = matrix.M01;
            this.M02 = matrix.M02;
            this.M03 = matrix.M03;
            this.M10 = matrix.M10;
            this.M11 = matrix.M11;
            this.M12 = matrix.M12;
            this.M13 = matrix.M13;
            this.M20 = matrix.M20;
            this.M21 = matrix.M21;
            this.M22 = matrix.M22;
            this.M23 = matrix.M23;
            this.M30 = matrix.M30;
            this.M31 = matrix.M31;
            this.M32 = matrix.M32;
            this.M33 = matrix.M33;
        }

        // Token: 0x04004A7E RID: 19070
        public float M00;

        // Token: 0x04004A7F RID: 19071
        public float M01;

        // Token: 0x04004A80 RID: 19072
        public float M02;

        // Token: 0x04004A81 RID: 19073
        public float M03;

        // Token: 0x04004A82 RID: 19074
        public float M10;

        // Token: 0x04004A83 RID: 19075
        public float M11;

        // Token: 0x04004A84 RID: 19076
        public float M12;

        // Token: 0x04004A85 RID: 19077
        public float M13;

        // Token: 0x04004A86 RID: 19078
        public float M20;

        // Token: 0x04004A87 RID: 19079
        public float M21;

        // Token: 0x04004A88 RID: 19080
        public float M22;

        // Token: 0x04004A89 RID: 19081
        public float M23;

        // Token: 0x04004A8A RID: 19082
        public float M30;

        // Token: 0x04004A8B RID: 19083
        public float M31;

        // Token: 0x04004A8C RID: 19084
        public float M32;

        // Token: 0x04004A8D RID: 19085
        public float M33;
    }

    // Token: 0x020000A3 RID: 163
    public class NNS_MATRIX : AppMain.IClearable
    {
        // Token: 0x06001EA2 RID: 7842 RVA: 0x0013AE60 File Offset: 0x00139060
        public float M( int row, int col )
        {
            switch ( row )
            {
                case 0:
                    switch ( col )
                    {
                        case 0:
                            return this.M00;
                        case 1:
                            return this.M01;
                        case 2:
                            return this.M02;
                        default:
                            return this.M03;
                    }
                    break;
                case 1:
                    switch ( col )
                    {
                        case 0:
                            return this.M10;
                        case 1:
                            return this.M11;
                        case 2:
                            return this.M12;
                        default:
                            return this.M13;
                    }
                    break;
                case 2:
                    switch ( col )
                    {
                        case 0:
                            return this.M20;
                        case 1:
                            return this.M21;
                        case 2:
                            return this.M22;
                        default:
                            return this.M23;
                    }
                    break;
                default:
                    switch ( col )
                    {
                        case 0:
                            return this.M30;
                        case 1:
                            return this.M31;
                        case 2:
                            return this.M32;
                        default:
                            return this.M33;
                    }
                    break;
            }
        }

        // Token: 0x06001EA3 RID: 7843 RVA: 0x0013AF50 File Offset: 0x00139150
        public void SetM( int row, int col, float value )
        {
            switch ( row )
            {
                case 0:
                    switch ( col )
                    {
                        case 0:
                            this.M00 = value;
                            return;
                        case 1:
                            this.M01 = value;
                            return;
                        case 2:
                            this.M02 = value;
                            return;
                        default:
                            this.M03 = value;
                            return;
                    }
                    break;
                case 1:
                    switch ( col )
                    {
                        case 0:
                            this.M10 = value;
                            return;
                        case 1:
                            this.M11 = value;
                            return;
                        case 2:
                            this.M12 = value;
                            return;
                        default:
                            this.M13 = value;
                            return;
                    }
                    break;
                case 2:
                    switch ( col )
                    {
                        case 0:
                            this.M20 = value;
                            return;
                        case 1:
                            this.M21 = value;
                            return;
                        case 2:
                            this.M22 = value;
                            return;
                        default:
                            this.M23 = value;
                            return;
                    }
                    break;
                default:
                    switch ( col )
                    {
                        case 0:
                            this.M30 = value;
                            return;
                        case 1:
                            this.M31 = value;
                            return;
                        case 2:
                            this.M32 = value;
                            return;
                        default:
                            this.M33 = value;
                            return;
                    }
                    break;
            }
        }

        // Token: 0x06001EA4 RID: 7844 RVA: 0x0013B050 File Offset: 0x00139250
        public void Clear()
        {
            this.M00 = ( this.M01 = ( this.M02 = ( this.M03 = ( this.M10 = ( this.M11 = ( this.M12 = ( this.M13 = ( this.M20 = ( this.M21 = ( this.M22 = ( this.M23 = ( this.M30 = ( this.M31 = ( this.M32 = ( this.M33 = 0f ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
        }

        // Token: 0x06001EA5 RID: 7845 RVA: 0x0013B108 File Offset: 0x00139308
        public static AppMain.NNS_MATRIX CreateIdentity()
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            nns_MATRIX.M00 = 1f;
            nns_MATRIX.M01 = 0f;
            nns_MATRIX.M02 = 0f;
            nns_MATRIX.M03 = 0f;
            nns_MATRIX.M10 = 0f;
            nns_MATRIX.M11 = 1f;
            nns_MATRIX.M12 = 0f;
            nns_MATRIX.M13 = 0f;
            nns_MATRIX.M20 = 0f;
            nns_MATRIX.M21 = 0f;
            nns_MATRIX.M22 = 1f;
            nns_MATRIX.M23 = 0f;
            nns_MATRIX.M30 = 0f;
            nns_MATRIX.M31 = 0f;
            nns_MATRIX.M32 = 0f;
            nns_MATRIX.M33 = 1f;
            return nns_MATRIX;
        }

        // Token: 0x06001EA6 RID: 7846 RVA: 0x0013B1CC File Offset: 0x001393CC
        public NNS_MATRIX()
        {
        }

        // Token: 0x06001EA7 RID: 7847 RVA: 0x0013B1D4 File Offset: 0x001393D4
        public NNS_MATRIX( AppMain.NNS_MATRIX matrix )
        {
            this.Assign( matrix );
        }

        // Token: 0x06001EA8 RID: 7848 RVA: 0x0013B1E4 File Offset: 0x001393E4
        public AppMain.NNS_MATRIX Assign( ref AppMain.SNNS_MATRIX matrix )
        {
            this.M00 = matrix.M00;
            this.M01 = matrix.M01;
            this.M02 = matrix.M02;
            this.M03 = matrix.M03;
            this.M10 = matrix.M10;
            this.M11 = matrix.M11;
            this.M12 = matrix.M12;
            this.M13 = matrix.M13;
            this.M20 = matrix.M20;
            this.M21 = matrix.M21;
            this.M22 = matrix.M22;
            this.M23 = matrix.M23;
            this.M30 = matrix.M30;
            this.M31 = matrix.M31;
            this.M32 = matrix.M32;
            this.M33 = matrix.M33;
            return this;
        }

        // Token: 0x06001EA9 RID: 7849 RVA: 0x0013B2B4 File Offset: 0x001394B4
        public AppMain.NNS_MATRIX Assign( AppMain.NNS_MATRIX matrix )
        {
            this.M00 = matrix.M00;
            this.M01 = matrix.M01;
            this.M02 = matrix.M02;
            this.M03 = matrix.M03;
            this.M10 = matrix.M10;
            this.M11 = matrix.M11;
            this.M12 = matrix.M12;
            this.M13 = matrix.M13;
            this.M20 = matrix.M20;
            this.M21 = matrix.M21;
            this.M22 = matrix.M22;
            this.M23 = matrix.M23;
            this.M30 = matrix.M30;
            this.M31 = matrix.M31;
            this.M32 = matrix.M32;
            this.M33 = matrix.M33;
            return this;
        }

        // Token: 0x06001EAA RID: 7850 RVA: 0x0013B384 File Offset: 0x00139584
        public static explicit operator Matrix( AppMain.NNS_MATRIX m )
        {
            return new Matrix( m.M00, m.M10, m.M20, m.M30, m.M01, m.M11, m.M21, m.M31, m.M02, m.M12, m.M22, m.M32, m.M03, m.M13, m.M23, m.M33 );
        }

        // Token: 0x04004A8E RID: 19086
        public float M00;

        // Token: 0x04004A8F RID: 19087
        public float M01;

        // Token: 0x04004A90 RID: 19088
        public float M02;

        // Token: 0x04004A91 RID: 19089
        public float M03;

        // Token: 0x04004A92 RID: 19090
        public float M10;

        // Token: 0x04004A93 RID: 19091
        public float M11;

        // Token: 0x04004A94 RID: 19092
        public float M12;

        // Token: 0x04004A95 RID: 19093
        public float M13;

        // Token: 0x04004A96 RID: 19094
        public float M20;

        // Token: 0x04004A97 RID: 19095
        public float M21;

        // Token: 0x04004A98 RID: 19096
        public float M22;

        // Token: 0x04004A99 RID: 19097
        public float M23;

        // Token: 0x04004A9A RID: 19098
        public float M30;

        // Token: 0x04004A9B RID: 19099
        public float M31;

        // Token: 0x04004A9C RID: 19100
        public float M32;

        // Token: 0x04004A9D RID: 19101
        public float M33;
    }
}