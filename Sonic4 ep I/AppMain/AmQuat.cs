using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000F5B RID: 3931 RVA: 0x00087E30 File Offset: 0x00086030
    public void amQuatToEulerXYZ( out float rx, out float ry, out float rz, ref AppMain.NNS_QUATERNION pQuat )
    {
        rx = ( ry = ( rz = 0f ) );
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.amQuatUnit( ref nns_QUATERNION, ref pQuat );
        float num = nns_QUATERNION.x * nns_QUATERNION.x;
        float num2 = nns_QUATERNION.x * nns_QUATERNION.y;
        float num3 = nns_QUATERNION.x * nns_QUATERNION.z;
        float num4 = nns_QUATERNION.x * nns_QUATERNION.w;
        float num5 = nns_QUATERNION.y * nns_QUATERNION.y;
        float num6 = nns_QUATERNION.y * nns_QUATERNION.z;
        float num7 = nns_QUATERNION.y * nns_QUATERNION.w;
        float num8 = nns_QUATERNION.z * nns_QUATERNION.z;
        float num9 = nns_QUATERNION.z * nns_QUATERNION.w;
        float num10 = 1f - 2f * (num5 + num8);
        float num11 = 2f * (num2 + num9);
        float num12 = 2f * (num3 - num7);
        float num13 = 1f - AppMain.amPow2(num12);
        ry = ( float )Math.Atan2( ( double )( -( double )num12 ), ( num13 > 0f ) ? Math.Sqrt( ( double )num13 ) : 0.0 );
        num13 = ( float )Math.Sqrt( ( double )( AppMain.amPow2( num10 ) + AppMain.amPow2( num11 ) ) );
        float num14;
        float num15;
        if ( AppMain.amIsZerof( num13 ) )
        {
            num14 = 0f;
            num15 = 1f;
        }
        else
        {
            num14 = num11 / num13;
            num15 = num10 / num13;
        }
        float num16 = 2f * (num2 - num9);
        float num17 = 2f * (num3 + num7);
        float num18 = 1f - 2f * (num + num8);
        float num19 = 2f * (num6 - num4);
        float num20 = num17 * num14 - num19 * num15;
        float num21 = num18 * num15 - num16 * num14;
        rx = ( float )Math.Atan2( ( double )num20, ( double )num21 );
        rz = ( float )Math.Atan2( ( double )num14, ( double )num15 );
    }

    // Token: 0x06000F5C RID: 3932 RVA: 0x00088008 File Offset: 0x00086208
    public void amQuatToEulerXYZ( out int ax, out int ay, out int az, ref AppMain.NNS_QUATERNION pQuat )
    {
        float n;
        float n2;
        float n3;
        this.amQuatToEulerXYZ( out n, out n2, out n3, ref pQuat );
        ax = AppMain.NNM_RADtoA32( n );
        ay = AppMain.NNM_RADtoA32( n2 );
        az = AppMain.NNM_RADtoA32( n3 );
    }

    // Token: 0x06000F5D RID: 3933 RVA: 0x0008803C File Offset: 0x0008623C
    public void amQuatVectorToQuat( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR4 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.VEC3_COPY( nns_VECTOR, pV1 );
        AppMain.VEC3_COPY( nns_VECTOR2, pV2 );
        AppMain.nnAddVector( nns_VECTOR4, nns_VECTOR, nns_VECTOR2 );
        float num = AppMain.nnDotProductVector(nns_VECTOR4, nns_VECTOR4);
        num = ( float )( 1.0 / Math.Sqrt( ( double )num ) );
        AppMain.nnScaleVector( nns_VECTOR2, nns_VECTOR4, num );
        AppMain.nnCrossProductVector( nns_VECTOR3, nns_VECTOR, nns_VECTOR2 );
        AppMain.VEC3_COPY( pQuat, nns_VECTOR3 );
        pQuat.w = AppMain.nnDotProductVector( nns_VECTOR, nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR4 );
    }

    // Token: 0x06000F5E RID: 3934 RVA: 0x000880D8 File Offset: 0x000862D8
    public static void amQuatRotAxisToQuat( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec, float radian )
    {
        radian *= 0.5f;
        float num;
        float w;
        AppMain.amSinCos( radian, out num, out w );
        pQuat.x = pVec.x * num;
        pQuat.y = pVec.y * num;
        pQuat.z = pVec.z * num;
        pQuat.w = w;
    }

    // Token: 0x06000F5F RID: 3935 RVA: 0x0008812C File Offset: 0x0008632C
    public static void amQuatToMatrix( AppMain.NNS_MATRIX pMtx, ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec )
    {
        if ( pMtx == null )
        {
            AppMain.NNS_MATRIX dst = AppMain.amMatrixGetCurrent();
            AppMain.nnMakeQuaternionMatrix( out AppMain.tempSNNS_MATRIX0, ref pQuat );
            if ( pVec != null )
            {
                AppMain.nnCopyVectorMatrixTranslation( ref AppMain.tempSNNS_MATRIX0, pVec );
            }
            AppMain.nnCopyMatrix( dst, ref AppMain.tempSNNS_MATRIX0 );
            return;
        }
        AppMain.nnMakeQuaternionMatrix( pMtx, ref pQuat );
        if ( pVec != null )
        {
            AppMain.nnCopyVectorMatrixTranslation( ref AppMain.tempSNNS_MATRIX0, pVec );
        }
    }

    // Token: 0x06000F60 RID: 3936 RVA: 0x0008817C File Offset: 0x0008637C
    public static void amQuatMultiMatrix( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.nnMakeQuaternionMatrix( out AppMain.tempSNNS_MATRIX0, ref pQuat );
        if ( pVec != null )
        {
            AppMain.nnCopyVectorMatrixTranslation( ref AppMain.tempSNNS_MATRIX0, pVec );
        }
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref AppMain.tempSNNS_MATRIX0 );
    }

    // Token: 0x06000F61 RID: 3937 RVA: 0x000881B4 File Offset: 0x000863B4
    public static void amQuatMultiMatrix( ref AppMain.NNS_QUATERNION pQuat, ref AppMain.SNNS_VECTOR4D pVec )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.nnMakeQuaternionMatrix( out AppMain.tempSNNS_MATRIX0, ref pQuat );
        AppMain.nnCopyVectorMatrixTranslation( ref AppMain.tempSNNS_MATRIX0, ref pVec );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref AppMain.tempSNNS_MATRIX0 );
    }

    // Token: 0x06000F62 RID: 3938 RVA: 0x000881EC File Offset: 0x000863EC
    public static void amQuatMultiMatrix( ref AppMain.NNS_QUATERNION pQuat, ref AppMain.SNNS_VECTOR pVec )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.nnMakeQuaternionMatrix( out AppMain.tempSNNS_MATRIX0, ref pQuat );
        AppMain.nnCopyVectorMatrixTranslation( ref AppMain.tempSNNS_MATRIX0, ref pVec );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref AppMain.tempSNNS_MATRIX0 );
    }

    // Token: 0x06000F63 RID: 3939 RVA: 0x00088224 File Offset: 0x00086424
    public static void amQuatMultiMatrix( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR pVec )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.nnMakeQuaternionMatrix( out AppMain.tempSNNS_MATRIX0, ref pQuat );
        if ( pVec != null )
        {
            AppMain.nnCopyVectorMatrixTranslation( ref AppMain.tempSNNS_MATRIX0, pVec );
        }
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref AppMain.tempSNNS_MATRIX0 );
    }

    // Token: 0x06000F64 RID: 3940 RVA: 0x0008825C File Offset: 0x0008645C
    public static void amQuatMultiVector( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.VEC4_COPY( ref nns_QUATERNION4, pSrc );
        nns_QUATERNION2.x = -pQuat.x;
        nns_QUATERNION2.y = -pQuat.y;
        nns_QUATERNION2.z = -pQuat.z;
        nns_QUATERNION2.w = pQuat.w;
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION3, ref pQuat, ref nns_QUATERNION4 );
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION, ref nns_QUATERNION3, ref nns_QUATERNION2 );
        if ( pVec == null )
        {
            AppMain.VEC4_COPY( pDst, ref nns_QUATERNION );
            return;
        }
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.VEC4_COPY( nns_VECTOR4D, ref nns_QUATERNION );
        AppMain.VEC4_COPY( nns_VECTOR4D2, pVec );
        AppMain.amVectorAdd( pDst, nns_VECTOR4D, nns_VECTOR4D2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
    }

    // Token: 0x06000F65 RID: 3941 RVA: 0x00088320 File Offset: 0x00086520
    public static void amQuatMultiVector( ref AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.VEC4_COPY( ref nns_QUATERNION4, pSrc );
        nns_QUATERNION2.x = -pQuat.x;
        nns_QUATERNION2.y = -pQuat.y;
        nns_QUATERNION2.z = -pQuat.z;
        nns_QUATERNION2.w = pQuat.w;
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION3, ref pQuat, ref nns_QUATERNION4 );
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION, ref nns_QUATERNION3, ref nns_QUATERNION2 );
        if ( pVec == null )
        {
            AppMain.VEC4_COPY( ref pDst, ref nns_QUATERNION );
            return;
        }
        AppMain.SNNS_VECTOR4D snns_VECTOR4D = default(AppMain.SNNS_VECTOR4D);
        AppMain.SNNS_VECTOR4D snns_VECTOR4D2 = default(AppMain.SNNS_VECTOR4D);
        AppMain.VEC4_COPY( ref snns_VECTOR4D, ref nns_QUATERNION );
        AppMain.VEC4_COPY( ref snns_VECTOR4D2, pVec );
        AppMain.amVectorAdd( ref pDst, ref snns_VECTOR4D, ref snns_VECTOR4D2 );
    }

    // Token: 0x06000F66 RID: 3942 RVA: 0x000883D8 File Offset: 0x000865D8
    public static void amQuatMultiVector( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc, ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.VEC4_COPY( ref nns_QUATERNION4, ref pSrc );
        nns_QUATERNION2.x = -pQuat.x;
        nns_QUATERNION2.y = -pQuat.y;
        nns_QUATERNION2.z = -pQuat.z;
        nns_QUATERNION2.w = pQuat.w;
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION3, ref pQuat, ref nns_QUATERNION4 );
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION, ref nns_QUATERNION3, ref nns_QUATERNION2 );
        if ( pVec == null )
        {
            AppMain.VEC4_COPY( ref pDst, ref nns_QUATERNION );
            return;
        }
        AppMain.SNNS_VECTOR4D snns_VECTOR4D = default(AppMain.SNNS_VECTOR4D);
        AppMain.SNNS_VECTOR4D snns_VECTOR4D2 = default(AppMain.SNNS_VECTOR4D);
        AppMain.VEC4_COPY( ref snns_VECTOR4D, ref nns_QUATERNION );
        AppMain.VEC4_COPY( ref snns_VECTOR4D2, pVec );
        AppMain.amVectorAdd( ref pDst, ref snns_VECTOR4D, ref snns_VECTOR4D2 );
    }

    // Token: 0x06000F67 RID: 3943 RVA: 0x00088490 File Offset: 0x00086690
    public static void amQuatRotAxisToQuat( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pVec, int angle )
    {
        AppMain.amQuatRotAxisToQuat( ref pQuat, pVec, AppMain.NNM_A32toRAD( angle ) );
    }

    // Token: 0x06000F68 RID: 3944 RVA: 0x0008849F File Offset: 0x0008669F
    public static void amQuatSet( ref AppMain.NNS_QUATERNION pDst, float x, float y, float z, float w )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
        pDst.w = w;
    }

    // Token: 0x06000F69 RID: 3945 RVA: 0x000884BE File Offset: 0x000866BE
    public static void amQuatSquad( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pQ1, ref AppMain.NNS_QUATERNION pQ2, ref AppMain.NNS_QUATERNION pQ3, ref AppMain.NNS_QUATERNION pQ4, float t )
    {
        AppMain.nnSquadQuaternion( ref pDst, ref pQ1, ref pQ2, ref pQ3, ref pQ4, t );
    }

    // Token: 0x06000F6A RID: 3946 RVA: 0x000884CD File Offset: 0x000866CD
    public static void amQuatSlerp( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pQ1, ref AppMain.NNS_QUATERNION pQ2, float per )
    {
        AppMain.nnSlerpQuaternion( out pDst, ref pQ1, ref pQ2, per );
    }

    // Token: 0x06000F6B RID: 3947 RVA: 0x000884D8 File Offset: 0x000866D8
    public static void amQuatUnitLerp( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pQ1, ref AppMain.NNS_QUATERNION pQ2, float per )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.amQuatLerp( ref nns_QUATERNION, ref pQ1, ref pQ2, per );
        AppMain.nnNormalizeQuaternion( ref pDst, ref nns_QUATERNION );
    }

    // Token: 0x06000F6C RID: 3948 RVA: 0x00088500 File Offset: 0x00086700
    public static void amQuatLerp( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pQ1, ref AppMain.NNS_QUATERNION pQ2, float per )
    {
        AppMain.nnLerpQuaternion( ref pDst, ref pQ1, ref pQ2, per );
    }

    // Token: 0x06000F6D RID: 3949 RVA: 0x0008850B File Offset: 0x0008670B
    public static void amQuatMatrixToQuat( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_MATRIX pMtx )
    {
        AppMain.nnMakeRotateMatrixQuaternion( out pQuat, pMtx );
    }

    // Token: 0x06000F6E RID: 3950 RVA: 0x00088514 File Offset: 0x00086714
    public static void amQuatEulerToQuatXYZ( ref AppMain.NNS_QUATERNION pQuat, AppMain.NNS_VECTOR4D pRot )
    {
        AppMain.nnMakeRotateXYZQuaternion( out pQuat, AppMain.NNM_RADtoA32( pRot.x ), AppMain.NNM_RADtoA32( pRot.y ), AppMain.NNM_RADtoA32( pRot.z ) );
    }

    // Token: 0x06000F6F RID: 3951 RVA: 0x0008853D File Offset: 0x0008673D
    public static void amQuatEulerToQuatXYZ( ref AppMain.NNS_QUATERNION pQuat, float rx, float ry, float rz )
    {
        AppMain.nnMakeRotateXYZQuaternion( out pQuat, AppMain.NNM_RADtoA32( rx ), AppMain.NNM_RADtoA32( ry ), AppMain.NNM_RADtoA32( rz ) );
    }

    // Token: 0x06000F70 RID: 3952 RVA: 0x00088557 File Offset: 0x00086757
    public static void amQuatEulerToQuatXYZ( ref AppMain.NNS_QUATERNION pQuat, int ax, int ay, int az )
    {
        AppMain.nnMakeRotateXYZQuaternion( out pQuat, ax, ay, az );
    }

    // Token: 0x06000F71 RID: 3953 RVA: 0x00088562 File Offset: 0x00086762
    public static void amQuatMakeRotateAxis( ref AppMain.NNS_QUATERNION pDst, AppMain.NNS_VECTOR pV, int ang )
    {
        AppMain.nnMakeRotateAxisQuaternion( out pDst, pV.x, pV.y, pV.z, ang );
    }

    // Token: 0x06000F72 RID: 3954 RVA: 0x0008857D File Offset: 0x0008677D
    public static void amQuatMulti( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pQ1, ref AppMain.NNS_QUATERNION pQ2 )
    {
        AppMain.nnMultiplyQuaternion( ref pDst, ref pQ1, ref pQ2 );
    }

    // Token: 0x06000F73 RID: 3955 RVA: 0x00088587 File Offset: 0x00086787
    public static void amQuatUnit( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pSrc )
    {
        AppMain.nnNormalizeQuaternion( ref pDst, ref pSrc );
    }

    // Token: 0x06000F74 RID: 3956 RVA: 0x00088591 File Offset: 0x00086791
    public static void amQuatInverse( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pSrc )
    {
        AppMain.nnInvertQuaternion( ref pDst, ref pSrc );
    }

    // Token: 0x06000F75 RID: 3957 RVA: 0x0008859B File Offset: 0x0008679B
    public static void amQuatCopy( ref AppMain.NNS_QUATERNION pDst, ref AppMain.NNS_QUATERNION pSrc )
    {
        AppMain.nnCopyQuaternion( ref pDst, ref pSrc );
    }

    // Token: 0x06000F76 RID: 3958 RVA: 0x000885A4 File Offset: 0x000867A4
    public static void amQuatInit( ref AppMain.NNS_QUATERNION pQuat )
    {
        AppMain.nnMakeUnitQuaternion( ref pQuat );
    }
}
