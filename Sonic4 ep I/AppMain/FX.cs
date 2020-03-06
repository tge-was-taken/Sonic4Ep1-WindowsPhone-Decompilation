using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000C3C RID: 3132 RVA: 0x0006BA19 File Offset: 0x00069C19
    public static int FX_MUL( int v1, int v2 )
    {
        return AppMain.FX32_CAST( ( long )v1 * ( long )v2 + 2048L >> 12 );
    }

    // Token: 0x06000C3D RID: 3133 RVA: 0x0006BA2F File Offset: 0x00069C2F
    public static int FX_MUL32x64C( int v1, long v2 )
    {
        return AppMain.FX32_CAST( v2 * ( long )v1 + ( long )int.MinValue >> 32 );
    }

    // Token: 0x06000C3E RID: 3134 RVA: 0x0006BA44 File Offset: 0x00069C44
    public static float FX_FX32_TO_F32( int x )
    {
        return ( float )x / 4096f;
    }

    // Token: 0x06000C3F RID: 3135 RVA: 0x0006BA4F File Offset: 0x00069C4F
    public static int FX_F32_TO_FX32( double x )
    {
        return ( int )( ( x > 0.0 ) ? ( x * 4096.0 + 0.5 ) : ( x * 4096.0 - 0.5 ) );
    }

    // Token: 0x06000C40 RID: 3136 RVA: 0x0006BA8A File Offset: 0x00069C8A
    public static int FX_F32_TO_FX32( float x )
    {
        return ( int )( ( x > 0f ) ? ( x * 4096f + 0.5f ) : ( x * 4096f - 0.5f ) );
    }

    // Token: 0x06000C41 RID: 3137 RVA: 0x0006BAB1 File Offset: 0x00069CB1
    public static int FX32_CONST( float x )
    {
        return AppMain.FX_F32_TO_FX32( x );
    }

    // Token: 0x06000C42 RID: 3138 RVA: 0x0006BAB9 File Offset: 0x00069CB9
    public static float FX_FX64_TO_F32( long x )
    {
        return ( float )x / 4096f;
    }

    // Token: 0x06000C43 RID: 3139 RVA: 0x0006BAC4 File Offset: 0x00069CC4
    public static long FX_F32_TO_FX64( float x )
    {
        return ( long )( ( x > 0f ) ? ( x * 4096f + 0.5f ) : ( x * 4096f - 0.5f ) );
    }

    // Token: 0x06000C44 RID: 3140 RVA: 0x0006BAEB File Offset: 0x00069CEB
    public static long FX64_CONST( float x )
    {
        return AppMain.FX_F32_TO_FX64( x );
    }

    // Token: 0x06000C45 RID: 3141 RVA: 0x0006BAF3 File Offset: 0x00069CF3
    public static float FX_FX64C_TO_F32( long x )
    {
        return ( float )x / 4.2949673E+09f;
    }

    // Token: 0x06000C46 RID: 3142 RVA: 0x0006BAFE File Offset: 0x00069CFE
    public static long FX_F32_TO_FX64C( float x )
    {
        return ( long )( ( x > 0f ) ? ( x * 4.2949673E+09f + 0.5f ) : ( x * 4.2949673E+09f - 0.5f ) );
    }

    // Token: 0x06000C47 RID: 3143 RVA: 0x0006BB25 File Offset: 0x00069D25
    public static long FX64C_CONST( float x )
    {
        return AppMain.FX_F32_TO_FX64C( x );
    }

    // Token: 0x06000C48 RID: 3144 RVA: 0x0006BB2D File Offset: 0x00069D2D
    public static float FX_FX16_TO_F32( short x )
    {
        return ( float )x / 4096f;
    }

    // Token: 0x06000C49 RID: 3145 RVA: 0x0006BB38 File Offset: 0x00069D38
    public static short FX_F32_TO_FX16( float x )
    {
        if ( x <= 0f )
        {
            return ( short )( x * 4096f - 0.5f );
        }
        return ( short )( x * 4096f + 0.5f );
    }

    // Token: 0x06000C4A RID: 3146 RVA: 0x0006BB5F File Offset: 0x00069D5F
    public static short FX16_CONST( float x )
    {
        return AppMain.FX_F32_TO_FX16( x );
    }

    // Token: 0x06000C4B RID: 3147 RVA: 0x0006BB67 File Offset: 0x00069D67
    public static float FXM_FX32_TO_FLOAT( int a )
    {
        return ( float )a / 4096f;
    }

    // Token: 0x06000C4C RID: 3148 RVA: 0x0006BB71 File Offset: 0x00069D71
    public static int FXM_FLOAT_TO_FX32( float a )
    {
        return ( int )( a * 4096f );
    }

    // Token: 0x06000C4D RID: 3149 RVA: 0x0006BB7B File Offset: 0x00069D7B
    public static void VEC_Set( ref AppMain.VecFx32 a, int x, int y, int z )
    {
        a.x = x;
        a.y = y;
        a.z = z;
    }

    // Token: 0x06000C4E RID: 3150 RVA: 0x0006BB92 File Offset: 0x00069D92
    public static int FX32_CAST( long res )
    {
        return ( int )res;
    }

    // Token: 0x06000C4F RID: 3151 RVA: 0x0006BB96 File Offset: 0x00069D96
    public static int FX_Mul( int v1, int v2 )
    {
        return AppMain.FX32_CAST( ( long )v1 * ( long )v2 + 2048L >> 12 );
    }

    // Token: 0x06000C50 RID: 3152 RVA: 0x0006BBAC File Offset: 0x00069DAC
    public static int FX_Mul32x64c( int v32, long v64c )
    {
        long num = v64c * (long)v32 + (long)int.MinValue;
        return AppMain.FX32_CAST( num >> 32 );
    }

    // Token: 0x06000C51 RID: 3153 RVA: 0x0006BBCE File Offset: 0x00069DCE
    public static int FX_Div( int numer, int denom )
    {
        return ( int )( ( ( long )numer << 32 ) / ( long )denom + 524288L >> 20 );
    }

    // Token: 0x06000C52 RID: 3154 RVA: 0x0006BBE3 File Offset: 0x00069DE3
    public static int FX_DivS32( int numer, int denom )
    {
        return numer / denom;
    }

    // Token: 0x06000C53 RID: 3155 RVA: 0x0006BBE8 File Offset: 0x00069DE8
    public static long FX_DivFx64c( int numer, int denom )
    {
        return ( long )( ( int )( ( ( long )numer << 32 ) / ( long )denom ) );
    }

    // Token: 0x06000C54 RID: 3156 RVA: 0x0006BBF4 File Offset: 0x00069DF4
    public static int FX_Mod( int numer, int denom )
    {
        return ( int )( ( ( long )numer << 32 ) % ( long )denom + 524288L ) >> 20;
    }

    // Token: 0x06000C55 RID: 3157 RVA: 0x0006BC09 File Offset: 0x00069E09
    public static int FX_ModS32( int numer, int denom )
    {
        return numer % denom;
    }

    // Token: 0x06000C56 RID: 3158 RVA: 0x0006BC0E File Offset: 0x00069E0E
    public static int FX_Inv( int denom )
    {
        return AppMain.FX_Div( 4096, denom );
    }

    // Token: 0x06000C57 RID: 3159 RVA: 0x0006BC1B File Offset: 0x00069E1B
    public static long FX_InvFx64c( int denom )
    {
        return AppMain.FX_DivFx64c( 4096, denom );
    }

    // Token: 0x06000C58 RID: 3160 RVA: 0x0006BC28 File Offset: 0x00069E28
    public static int FX_Sqrt( int x )
    {
        float a = AppMain.nnSqrt(AppMain.FXM_FX32_TO_FLOAT(x));
        return AppMain.FXM_FLOAT_TO_FX32( a );
    }

    // Token: 0x06000C59 RID: 3161 RVA: 0x0006BC48 File Offset: 0x00069E48
    public static int FX_Sin( int angle )
    {
        float a = AppMain.nnSin(angle);
        return AppMain.FXM_FLOAT_TO_FX32( a );
    }

    // Token: 0x06000C5A RID: 3162 RVA: 0x0006BC64 File Offset: 0x00069E64
    public static int FX_Cos( int angle )
    {
        float a = AppMain.nnCos(angle);
        return AppMain.FXM_FLOAT_TO_FX32( a );
    }
}