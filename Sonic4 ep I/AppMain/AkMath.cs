using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060013AA RID: 5034 RVA: 0x000AE8F8 File Offset: 0x000ACAF8
    public static short AKM_DEGtoA16( float n )
    {
        return ( short )( 65535L & ( long )( ( int )( n * 182.04443f ) ) );
    }

    // Token: 0x060013AB RID: 5035 RVA: 0x000AE90B File Offset: 0x000ACB0B
    public static int AKM_DEGtoA32( float n )
    {
        return AppMain.NNM_DEGtoA32( n );
    }

    // Token: 0x060013AC RID: 5036 RVA: 0x000AE913 File Offset: 0x000ACB13
    public static short AKM_DEGtoA16( int n )
    {
        return ( short )( 65535L & ( long )( ( int )( ( float )n * 182.04443f ) ) );
    }

    // Token: 0x060013AD RID: 5037 RVA: 0x000AE927 File Offset: 0x000ACB27
    public static int AKM_DEGtoA32( int n )
    {
        return AppMain.NNM_DEGtoA32( n );
    }

    // Token: 0x060013AE RID: 5038 RVA: 0x000AE92F File Offset: 0x000ACB2F
    public static int AkMathRandFx()
    {
        return AppMain.mtMathRand() >> 4;
    }

    // Token: 0x060013AF RID: 5039 RVA: 0x000AE938 File Offset: 0x000ACB38
    public static void AkMathGetRandomUnitVector( AppMain.NNS_VECTOR dst_vec, float rand_z, short rand_angle )
    {
        dst_vec.x = AppMain.nnSqrt( 1f - rand_z * rand_z ) * AppMain.nnCos( ( int )rand_angle );
        dst_vec.y = AppMain.nnSqrt( 1f - rand_z * rand_z ) * AppMain.nnSin( ( int )rand_angle );
        dst_vec.z = rand_z;
    }

    // Token: 0x060013B0 RID: 5040 RVA: 0x000AE978 File Offset: 0x000ACB78
    public static void AkMathNormalizeMtx( AppMain.NNS_MATRIX dst_mtx, AppMain.NNS_MATRIX src_mtx )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, src_mtx.M00, src_mtx.M01, src_mtx.M02 );
        AppMain.amVectorSet( nns_VECTOR2, src_mtx.M10, src_mtx.M11, src_mtx.M12 );
        AppMain.amVectorSet( nns_VECTOR3, src_mtx.M20, src_mtx.M21, src_mtx.M22 );
        AppMain.nnMakeUnitMatrix( dst_mtx );
        float num = 1f / AppMain.nnLengthVector(nns_VECTOR);
        dst_mtx.M00 = nns_VECTOR.x * num;
        dst_mtx.M01 = nns_VECTOR.y * num;
        dst_mtx.M02 = nns_VECTOR.z * num;
        num = 1f / AppMain.nnLengthVector( nns_VECTOR2 );
        dst_mtx.M10 = nns_VECTOR2.x * num;
        dst_mtx.M11 = nns_VECTOR2.y * num;
        dst_mtx.M12 = nns_VECTOR2.z * num;
        num = 1f / AppMain.nnLengthVector( nns_VECTOR3 );
        dst_mtx.M20 = nns_VECTOR3.x * num;
        dst_mtx.M21 = nns_VECTOR3.y * num;
        dst_mtx.M22 = nns_VECTOR3.z * num;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
    }

    // Token: 0x060013B1 RID: 5041 RVA: 0x000AEA9C File Offset: 0x000ACC9C
    private static void AkMathExtractScaleMtx( AppMain.NNS_MATRIX dst_mtx, AppMain.NNS_MATRIX src_mtx )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.amAssert( true );
        AppMain.amVectorSet( nns_VECTOR, src_mtx.M( 0, 0 ), src_mtx.M( 0, 1 ), src_mtx.M( 0, 2 ) );
        float x = AppMain.nnLengthVector(nns_VECTOR);
        AppMain.amVectorSet( nns_VECTOR, src_mtx.M( 1, 0 ), src_mtx.M( 1, 1 ), src_mtx.M( 1, 2 ) );
        float y = AppMain.nnLengthVector(nns_VECTOR);
        AppMain.amVectorSet( nns_VECTOR, src_mtx.M( 2, 0 ), src_mtx.M( 2, 1 ), src_mtx.M( 2, 2 ) );
        float z = AppMain.nnLengthVector(nns_VECTOR);
        AppMain.nnMakeScaleMatrix( dst_mtx, x, y, z );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x060013B2 RID: 5042 RVA: 0x000AEB33 File Offset: 0x000ACD33
    public static void AkMathInvertYZQuaternion( out AppMain.NNS_QUATERNION dst_quat, ref AppMain.NNS_QUATERNION src_quat )
    {
        dst_quat = src_quat;
        dst_quat.y = -dst_quat.y;
        dst_quat.z = -dst_quat.z;
    }

    // Token: 0x060013B3 RID: 5043 RVA: 0x000AEB5B File Offset: 0x000ACD5B
    public static void AkMathInvertXZQuaternion( out AppMain.NNS_QUATERNION dst_quat, ref AppMain.NNS_QUATERNION src_quat )
    {
        dst_quat = src_quat;
        dst_quat.x = -dst_quat.x;
        dst_quat.z = -dst_quat.z;
    }

    // Token: 0x060013B4 RID: 5044 RVA: 0x000AEB83 File Offset: 0x000ACD83
    public static void AkMathInvertXYQuaternion( out AppMain.NNS_QUATERNION dst_quat, ref AppMain.NNS_QUATERNION src_quat )
    {
        dst_quat = src_quat;
        dst_quat.x = -dst_quat.x;
        dst_quat.y = -dst_quat.y;
    }

    // Token: 0x060013B5 RID: 5045 RVA: 0x000AEBAC File Offset: 0x000ACDAC
    private static byte AkMathCountBitPopulation( uint bits )
    {
        bits -= ( bits >> 1 & 1431655765U );
        bits = ( bits & 858993459U ) + ( bits >> 2 & 858993459U );
        bits = ( bits + ( bits >> 4 ) & 252645135U );
        bits += bits >> 8;
        bits += bits >> 16;
        return ( byte )( bits & 63U );
    }
}
