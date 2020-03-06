using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain 
{

    // Token: 0x06001395 RID: 5013 RVA: 0x000AE7A4 File Offset: 0x000AC9A4
    public static double floorf( double f )
    {
        return Math.Floor( f );
    }

    // Token: 0x06001396 RID: 5014 RVA: 0x000AE7AC File Offset: 0x000AC9AC
    public static float floorf( float f )
    {
        return ( float )Math.Floor( ( double )f );
    }

    // Token: 0x06001397 RID: 5015 RVA: 0x000AE7B6 File Offset: 0x000AC9B6
    public static float nnRandom()
    {
        return ( float )AppMain.random.Next( 0, 32768 ) * 3.0517578E-05f;
    }

    // Token: 0x06001398 RID: 5016 RVA: 0x000AE7CF File Offset: 0x000AC9CF
    public static void nnRandomSeed( int n )
    {
        AppMain.random = new Random( n );
    }

    // Token: 0x06001399 RID: 5017 RVA: 0x000AE7DC File Offset: 0x000AC9DC
    public static float nnAbs( double n )
    {
        return ( float )Math.Abs( n );
    }

    // Token: 0x0600139A RID: 5018 RVA: 0x000AE7E6 File Offset: 0x000AC9E6
    public static int nnArcCos( double n )
    {
        return AppMain.NNM_RADtoA32( ( float )Math.Acos( n ) );
    }

    // Token: 0x0600139B RID: 5019 RVA: 0x000AE7F5 File Offset: 0x000AC9F5
    public static int nnArcSin( double n )
    {
        return AppMain.NNM_RADtoA32( ( float )Math.Asin( n ) );
    }

    // Token: 0x0600139C RID: 5020 RVA: 0x000AE804 File Offset: 0x000ACA04
    public static int nnArcTan( double n )
    {
        return AppMain.NNM_RADtoA32( ( float )Math.Atan( n ) );
    }

    // Token: 0x0600139D RID: 5021 RVA: 0x000AE813 File Offset: 0x000ACA13
    public static int nnArcTan2( double y, double x )
    {
        return AppMain.NNM_RADtoA32( ( float )Math.Atan2( y, x ) );
    }

    // Token: 0x0600139E RID: 5022 RVA: 0x000AE824 File Offset: 0x000ACA24
    public static float nnExp( double x )
    {
        return ( float )Math.Exp( x );
    }

    // Token: 0x0600139F RID: 5023 RVA: 0x000AE82D File Offset: 0x000ACA2D
    public static float nnFloor( double n )
    {
        return ( float )Math.Floor( n );
    }

    // Token: 0x060013A0 RID: 5024 RVA: 0x000AE837 File Offset: 0x000ACA37
    public static float nnFraction( double n )
    {
        AppMain.mppAssertNotImpl();
        if ( n > 0.0 )
        {
            return ( float )( n - Math.Floor( n ) );
        }
        return ( float )( n - Math.Ceiling( n ) );
    }

    // Token: 0x060013A1 RID: 5025 RVA: 0x000AE85D File Offset: 0x000ACA5D
    public static float nnHypot( double x, double y )
    {
        return ( float )Math.Sqrt( x * x + y * y );
    }

    // Token: 0x060013A2 RID: 5026 RVA: 0x000AE86D File Offset: 0x000ACA6D
    public static float nnInvertSqrt( float n )
    {
        return ( float )( 1.0 / Math.Sqrt( ( double )n ) );
    }

    // Token: 0x060013A3 RID: 5027 RVA: 0x000AE881 File Offset: 0x000ACA81
    public static float nnLog( double n )
    {
        return ( float )Math.Log( n );
    }

    // Token: 0x060013A4 RID: 5028 RVA: 0x000AE88B File Offset: 0x000ACA8B
    public static float nnLog10( double n )
    {
        return ( float )Math.Log10( n );
    }

    // Token: 0x060013A5 RID: 5029 RVA: 0x000AE895 File Offset: 0x000ACA95
    public static float nnPow( double n1, double n2 )
    {
        return ( float )Math.Pow( n1, n2 );
    }

    // Token: 0x060013A6 RID: 5030 RVA: 0x000AE8A1 File Offset: 0x000ACAA1
    public static float nnSqrt( float n )
    {
        return ( float )Math.Sqrt( ( double )n );
    }

    // Token: 0x060013A7 RID: 5031 RVA: 0x000AE8AB File Offset: 0x000ACAAB
    public static float nnTan( int ang )
    {
        return ( float )Math.Tan( ( double )AppMain.NNM_A32toRAD( ang ) );
    }

    // Token: 0x060013A8 RID: 5032 RVA: 0x000AE8BC File Offset: 0x000ACABC
    private static float nnRoundOff( float n )
    {
        float result;
        if ( n < 0f )
        {
            result = -AppMain.nnFloor( ( double )AppMain.nnAbs( ( double )n ) );
        }
        else
        {
            result = AppMain.nnFloor( ( double )AppMain.nnAbs( ( double )n ) );
        }
        return result;
    }
}