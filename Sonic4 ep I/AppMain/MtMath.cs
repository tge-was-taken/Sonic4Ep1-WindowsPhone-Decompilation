using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001524 RID: 5412 RVA: 0x000B89D0 File Offset: 0x000B6BD0
    public static void MTM_MATH_SWAP<T>( ref T a, ref T b )
    {
        T t = a;
        a = b;
        b = t;
    }

    // Token: 0x06001525 RID: 5413 RVA: 0x000B89F7 File Offset: 0x000B6BF7
    public static uint MTM_MATH_MAX( uint a, uint b )
    {
        return Math.Max( a, b );
    }

    // Token: 0x06001526 RID: 5414 RVA: 0x000B8A00 File Offset: 0x000B6C00
    public static int MTM_MATH_MAX( int a, int b )
    {
        return Math.Max( a, b );
    }

    // Token: 0x06001527 RID: 5415 RVA: 0x000B8A09 File Offset: 0x000B6C09
    public static float MTM_MATH_CLIP( float a, float low, float high )
    {
        if ( a < low )
        {
            return low;
        }
        if ( a <= high )
        {
            return a;
        }
        return high;
    }

    // Token: 0x06001528 RID: 5416 RVA: 0x000B8A18 File Offset: 0x000B6C18
    public static int MTM_MATH_CLIP( int a, int low, int high )
    {
        if ( a < low )
        {
            return low;
        }
        if ( a <= high )
        {
            return a;
        }
        return high;
    }

    // Token: 0x06001529 RID: 5417 RVA: 0x000B8A27 File Offset: 0x000B6C27
    public static uint MTM_MATH_CLIP( uint a, uint low, uint high )
    {
        if ( a < low )
        {
            return low;
        }
        if ( a <= high )
        {
            return a;
        }
        return high;
    }

    // Token: 0x0600152A RID: 5418 RVA: 0x000B8A36 File Offset: 0x000B6C36
    public static int MTM_MATH_ABS( int a )
    {
        if ( a >= 0 )
        {
            return a;
        }
        return -a;
    }

    // Token: 0x0600152B RID: 5419 RVA: 0x000B8A40 File Offset: 0x000B6C40
    public static float MTM_MATH_ABS( float a )
    {
        return ( a < 0f ) ? ( -a ) : a;
    }

    // Token: 0x0600152C RID: 5420 RVA: 0x000B8A50 File Offset: 0x000B6C50
    public static int mtMathSin( int angle )
    {
        return AppMain.FX_Sin( angle );
    }

    // Token: 0x0600152D RID: 5421 RVA: 0x000B8A58 File Offset: 0x000B6C58
    public static int mtMathCos( int angle )
    {
        return AppMain.FX_Cos( angle );
    }

    // Token: 0x0600152E RID: 5422 RVA: 0x000B8A60 File Offset: 0x000B6C60
    public static void mtMathSRand( uint seed )
    {
        AppMain._mt_math_rand = seed;
    }

    // Token: 0x0600152F RID: 5423 RVA: 0x000B8A68 File Offset: 0x000B6C68
    public static ushort mtMathRand()
    {
        AppMain._mt_math_rand = 1663525U * AppMain._mt_math_rand + 1013904223U;
        return ( ushort )( AppMain._mt_math_rand >> 16 );
    }

    // Token: 0x0600033F RID: 831 RVA: 0x0001A13F File Offset: 0x0001833F
    public static void MTM_ASSERT( int _e )
    {
    }

    // Token: 0x06000340 RID: 832 RVA: 0x0001A141 File Offset: 0x00018341
    public static void MTM_ASSERT( bool _e )
    {
    }

    // Token: 0x06000341 RID: 833 RVA: 0x0001A143 File Offset: 0x00018343
    public static void MTM_ASSERT( object _e )
    {
    }

    // Token: 0x06000342 RID: 834 RVA: 0x0001A145 File Offset: 0x00018345
    public static void MTM_ASSERT( uint _e )
    {
    }
}
