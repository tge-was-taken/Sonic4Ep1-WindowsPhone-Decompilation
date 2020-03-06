using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600198D RID: 6541 RVA: 0x000E7910 File Offset: 0x000E5B10
    private static uint nnCalcClipBoxNode( AppMain.NNS_NODE node, AppMain.NNS_MATRIX mtx )
    {
        float boundingBoxX = node.BoundingBoxX;
        float boundingBoxY = node.BoundingBoxY;
        float boundingBoxZ = node.BoundingBoxZ;
        return AppMain.nnCalcClipBox( node.Center, boundingBoxX, boundingBoxY, boundingBoxZ, mtx );
    }

    // Token: 0x0600198E RID: 6542 RVA: 0x000E7944 File Offset: 0x000E5B44
    private static uint nnCalcClipBox( AppMain.NNS_VECTOR center, float sx, float sy, float sz, AppMain.NNS_MATRIX mtx )
    {
        uint num = 0U;
        float n_clip = AppMain.nngClip3d.n_clip;
        float f_clip = AppMain.nngClip3d.f_clip;
        AppMain.NNS_VECTORFAST src;
        AppMain.nnmSetUpVectorFast( out src, center.x, center.y, center.z );
        AppMain.NNS_VECTORFAST nns_VECTORFAST;
        AppMain.nnTransformVectorFast( out nns_VECTORFAST, mtx, src );
        float num2 = sx * mtx.M20;
        float num3 = sy * mtx.M21;
        float num4 = sz * mtx.M22;
        float num5 = AppMain.nnAbs((double)num2) + AppMain.nnAbs((double)num3) + AppMain.nnAbs((double)num4);
        if ( nns_VECTORFAST.z > -n_clip + num5 || nns_VECTORFAST.z < -f_clip - num5 )
        {
            return 16U;
        }
        if ( nns_VECTORFAST.z > -n_clip - num5 )
        {
            num |= 260U;
        }
        if ( nns_VECTORFAST.z < -f_clip + num5 )
        {
            num |= 520U;
        }
        float num6 = sx * mtx.M00;
        float num7 = sy * mtx.M01;
        float num8 = sz * mtx.M02;
        if ( AppMain.nngProjectionType != 1 )
        {
            num5 = AppMain.nnAbs( ( double )( num6 * AppMain.nngClipPlane.Right.nx + num2 * AppMain.nngClipPlane.Right.nz ) ) + AppMain.nnAbs( ( double )( num7 * AppMain.nngClipPlane.Right.nx + num3 * AppMain.nngClipPlane.Right.nz ) ) + AppMain.nnAbs( ( double )( num8 * AppMain.nngClipPlane.Right.nx + num4 * AppMain.nngClipPlane.Right.nz ) );
            float num9 = nns_VECTORFAST.x * AppMain.nngClipPlane.Right.nx + nns_VECTORFAST.z * AppMain.nngClipPlane.Right.nz;
            if ( num9 > num5 )
            {
                return 16U;
            }
            if ( num9 > -num5 )
            {
                num |= 4096U;
            }
            num5 = AppMain.nnAbs( ( double )( num6 * AppMain.nngClipPlane.Left.nx + num2 * AppMain.nngClipPlane.Left.nz ) ) + AppMain.nnAbs( ( double )( num7 * AppMain.nngClipPlane.Left.nx + num3 * AppMain.nngClipPlane.Left.nz ) ) + AppMain.nnAbs( ( double )( num8 * AppMain.nngClipPlane.Left.nx + num4 * AppMain.nngClipPlane.Left.nz ) );
            num9 = nns_VECTORFAST.x * AppMain.nngClipPlane.Left.nx + nns_VECTORFAST.z * AppMain.nngClipPlane.Left.nz;
            if ( num9 > num5 )
            {
                return 16U;
            }
            if ( num9 > -num5 )
            {
                num |= 8192U;
            }
            float num10 = sx * mtx.M10;
            float num11 = sy * mtx.M11;
            float num12 = sz * mtx.M12;
            num5 = AppMain.nnAbs( ( double )( num10 * AppMain.nngClipPlane.Top.ny + num2 * AppMain.nngClipPlane.Top.nz ) ) + AppMain.nnAbs( ( double )( num11 * AppMain.nngClipPlane.Top.ny + num3 * AppMain.nngClipPlane.Top.nz ) ) + AppMain.nnAbs( ( double )( num12 * AppMain.nngClipPlane.Top.ny + num4 * AppMain.nngClipPlane.Top.nz ) );
            num9 = nns_VECTORFAST.y * AppMain.nngClipPlane.Top.ny + nns_VECTORFAST.z * AppMain.nngClipPlane.Top.nz;
            if ( num9 > num5 )
            {
                return 16U;
            }
            if ( num9 > -num5 )
            {
                num |= 16384U;
            }
            num5 = AppMain.nnAbs( ( double )( num10 * AppMain.nngClipPlane.Bottom.ny + num2 * AppMain.nngClipPlane.Bottom.nz ) ) + AppMain.nnAbs( ( double )( num11 * AppMain.nngClipPlane.Bottom.ny + num3 * AppMain.nngClipPlane.Bottom.nz ) ) + AppMain.nnAbs( ( double )( num12 * AppMain.nngClipPlane.Bottom.ny + num4 * AppMain.nngClipPlane.Bottom.nz ) );
            num9 = nns_VECTORFAST.y * AppMain.nngClipPlane.Bottom.ny + nns_VECTORFAST.z * AppMain.nngClipPlane.Bottom.nz;
            if ( num9 > num5 )
            {
                return 16U;
            }
            if ( num9 > -num5 )
            {
                num |= 32768U;
            }
            if ( num == 0U )
            {
                return 2U;
            }
        }
        else
        {
            num5 = AppMain.nnAbs( ( double )num6 ) + AppMain.nnAbs( ( double )num7 ) + AppMain.nnAbs( ( double )num8 );
            float num9 = nns_VECTORFAST.x - AppMain.nngClipPlane.Right.mul - AppMain.nngClipPlane.Right.ofs;
            if ( num9 > num5 )
            {
                return 16U;
            }
            if ( num9 > -num5 )
            {
                num |= 4096U;
            }
            num9 = nns_VECTORFAST.x - AppMain.nngClipPlane.Left.mul - AppMain.nngClipPlane.Left.ofs;
            if ( num9 < -num5 )
            {
                return 16U;
            }
            if ( num9 < num5 )
            {
                num |= 8192U;
            }
            float num10 = sx * mtx.M10;
            float num11 = sy * mtx.M11;
            float num12 = sz * mtx.M12;
            num5 = AppMain.nnAbs( ( double )num10 ) + AppMain.nnAbs( ( double )num11 ) + AppMain.nnAbs( ( double )num12 );
            num9 = nns_VECTORFAST.y - AppMain.nngClipPlane.Top.mul - AppMain.nngClipPlane.Top.ofs;
            if ( num9 > num5 )
            {
                return 16U;
            }
            if ( num9 > -num5 )
            {
                num |= 16384U;
            }
            num9 = nns_VECTORFAST.y - AppMain.nngClipPlane.Bottom.mul - AppMain.nngClipPlane.Bottom.ofs;
            if ( num9 < -num5 )
            {
                return 16U;
            }
            if ( num9 < num5 )
            {
                num |= 32768U;
            }
            if ( num == 0U )
            {
                return 2U;
            }
        }
        return num & 62U;
    }

    // Token: 0x0600198F RID: 6543 RVA: 0x000E7EF8 File Offset: 0x000E60F8
    private static uint nnCalcClipCore( AppMain.NNS_VECTOR center, float radius, AppMain.NNS_MATRIX mtx )
    {
        uint num = 0U;
        float n_clip = AppMain.nngClip3d.n_clip;
        float f_clip = AppMain.nngClip3d.f_clip;
        AppMain.NNS_VECTORFAST src;
        AppMain.nnmSetUpVectorFast( out src, center.x, center.y, center.z );
        AppMain.NNS_VECTORFAST nns_VECTORFAST;
        AppMain.nnTransformVectorFast( out nns_VECTORFAST, mtx, src );
        if ( nns_VECTORFAST.z > -n_clip + radius || nns_VECTORFAST.z < -f_clip - radius )
        {
            return 16U;
        }
        if ( nns_VECTORFAST.z > -n_clip - radius )
        {
            num |= 260U;
        }
        if ( nns_VECTORFAST.z < -f_clip + radius )
        {
            num |= 520U;
        }
        if ( AppMain.nngProjectionType != 1 )
        {
            float num2 = nns_VECTORFAST.x * AppMain.nngClipPlane.Right.nx + nns_VECTORFAST.z * AppMain.nngClipPlane.Right.nz;
            if ( num2 > radius )
            {
                return 16U;
            }
            if ( num2 > -radius )
            {
                num |= 4096U;
            }
            num2 = nns_VECTORFAST.x * AppMain.nngClipPlane.Left.nx + nns_VECTORFAST.z * AppMain.nngClipPlane.Left.nz;
            if ( num2 > radius )
            {
                return 16U;
            }
            if ( num2 > -radius )
            {
                num |= 8192U;
            }
            num2 = nns_VECTORFAST.y * AppMain.nngClipPlane.Top.ny + nns_VECTORFAST.z * AppMain.nngClipPlane.Top.nz;
            if ( num2 > radius )
            {
                return 16U;
            }
            if ( num2 > -radius )
            {
                num |= 16384U;
            }
            num2 = nns_VECTORFAST.y * AppMain.nngClipPlane.Bottom.ny + nns_VECTORFAST.z * AppMain.nngClipPlane.Bottom.nz;
            if ( num2 > radius )
            {
                return 16U;
            }
            if ( num2 > -radius )
            {
                num |= 32768U;
            }
            if ( num == 0U )
            {
                return 2U;
            }
        }
        else
        {
            float num2 = nns_VECTORFAST.y - AppMain.nngClipPlane.Top.mul - AppMain.nngClipPlane.Top.ofs;
            if ( num2 > radius )
            {
                return 16U;
            }
            if ( num2 > -radius )
            {
                num |= 16384U;
            }
            num2 = nns_VECTORFAST.y - AppMain.nngClipPlane.Bottom.mul - AppMain.nngClipPlane.Bottom.ofs;
            if ( num2 < -radius )
            {
                return 16U;
            }
            if ( num2 < radius )
            {
                num |= 32768U;
            }
            num2 = nns_VECTORFAST.x - AppMain.nngClipPlane.Right.mul - AppMain.nngClipPlane.Right.ofs;
            if ( num2 > radius )
            {
                return 16U;
            }
            if ( num2 > -radius )
            {
                num |= 4096U;
            }
            num2 = nns_VECTORFAST.x - AppMain.nngClipPlane.Left.mul - AppMain.nngClipPlane.Left.ofs;
            if ( num2 < -radius )
            {
                return 16U;
            }
            if ( num2 < radius )
            {
                num |= 8192U;
            }
            if ( num == 0U )
            {
                return 2U;
            }
        }
        return num & 62U;
    }

    // Token: 0x06001990 RID: 6544 RVA: 0x000E81A3 File Offset: 0x000E63A3
    private static uint nnCalcClip( AppMain.NNS_VECTOR center, float radius, AppMain.NNS_MATRIX mtx )
    {
        if ( radius == 0f )
        {
            return 0U;
        }
        radius *= AppMain.nnEstimateMatrixScaling( mtx );
        return AppMain.nnCalcClipCore( center, radius, mtx );
    }

    // Token: 0x06001991 RID: 6545 RVA: 0x000E81C1 File Offset: 0x000E63C1
    private static uint nnCalcClipUniformScale( AppMain.NNS_VECTOR center, float radius, AppMain.NNS_MATRIX mtx, float factor )
    {
        if ( radius == 0f )
        {
            return 0U;
        }
        radius *= factor;
        return AppMain.nnCalcClipCore( center, radius, mtx );
    }

    // Token: 0x06001992 RID: 6546 RVA: 0x000E81DC File Offset: 0x000E63DC
    private static void nnCalcClipSetNodeStatus( uint[] pNodeStatList, AppMain.NNS_NODE[] pNodeList, int nodeIdx, AppMain.NNS_MATRIX pNodeMtx, float rootscale, uint flag )
    {
        AppMain.nnclip.nnsNodeStatList = pNodeStatList;
        AppMain.nnclip.nnsNodeList = pNodeList;
        AppMain.NNS_NODE nns_NODE = pNodeList[nodeIdx];
        if ( ( pNodeStatList[nodeIdx] & 1025U ) != 0U )
        {
            return;
        }
        if ( ( nns_NODE.fType & 16U ) != 0U )
        {
            pNodeStatList[nodeIdx] |= 1U;
        }
        if ( ( nns_NODE.fType & 32U ) != 0U )
        {
            pNodeStatList[nodeIdx] |= 1U;
            if ( nns_NODE.iChild != -1 )
            {
                AppMain.nnSetUpNodeStatusListFlag( ( int )nns_NODE.iChild, 1U );
            }
            return;
        }
        if ( flag != 0U )
        {
            if ( nns_NODE.iMatrix == -1 && ( flag & 8U ) == 0U )
            {
                return;
            }
            if ( ( nns_NODE.fType & 2097152U ) != 0U && ( nns_NODE.fType & 4194304U ) == 0U && ( flag & 32U ) == 0U )
            {
                pNodeStatList[nodeIdx] |= AppMain.nnCalcClipBoxNode( nns_NODE, pNodeMtx );
            }
            else if ( ( flag & 16U ) != 0U )
            {
                pNodeStatList[nodeIdx] |= AppMain.nnCalcClip( nns_NODE.Center, nns_NODE.Radius, pNodeMtx );
            }
            else
            {
                pNodeStatList[nodeIdx] |= AppMain.nnCalcClipUniformScale( nns_NODE.Center, nns_NODE.Radius, pNodeMtx, rootscale );
            }
            if ( ( pNodeStatList[nodeIdx] & 16U ) != 0U )
            {
                if ( ( flag & 2U ) != 0U )
                {
                    pNodeStatList[nodeIdx] |= 1024U;
                }
                else
                {
                    pNodeStatList[nodeIdx] |= 1U;
                }
                if ( ( flag & 8U ) != 0U && nns_NODE.iChild != -1 )
                {
                    AppMain.nnSetUpNodeStatusListFlag( ( int )nns_NODE.iChild, pNodeStatList[nodeIdx] );
                }
            }
        }
    }

    // Token: 0x06001993 RID: 6547 RVA: 0x000E835D File Offset: 0x000E655D
    private static void nnSetUpNodeStatusListFlag( int nodeidx, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001994 RID: 6548 RVA: 0x000E8364 File Offset: 0x000E6564
    private uint nnCheckObjectClip( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06001995 RID: 6549 RVA: 0x000E836C File Offset: 0x000E656C
    private uint nnCheckObjectClipMotionCore( AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06001996 RID: 6550 RVA: 0x000E8374 File Offset: 0x000E6574
    private uint nnCheckObjectClipMotion( AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
        return uint.MaxValue;
    }

    // Token: 0x06001997 RID: 6551 RVA: 0x000E837C File Offset: 0x000E657C
    private static float nnEstimateMatrixScaling( AppMain.NNS_MATRIX mtx )
    {
        AppMain.NNS_VECTORFAST nns_VECTORFAST;
        AppMain.nnSetUpVectorFast( out nns_VECTORFAST, mtx.M00, mtx.M10, mtx.M20 );
        AppMain.NNS_VECTORFAST nns_VECTORFAST2;
        AppMain.nnSetUpVectorFast( out nns_VECTORFAST2, mtx.M01, mtx.M11, mtx.M21 );
        AppMain.NNS_VECTORFAST nns_VECTORFAST3;
        AppMain.nnSetUpVectorFast( out nns_VECTORFAST3, mtx.M02, mtx.M12, mtx.M22 );
        float num = AppMain.nnLengthSqVectorFast(ref nns_VECTORFAST);
        num = AppMain.NNM_MAX( num, AppMain.nnLengthSqVectorFast( ref nns_VECTORFAST2 ) );
        num = AppMain.NNM_MAX( num, AppMain.nnLengthSqVectorFast( ref nns_VECTORFAST3 ) );
        float num2 = AppMain.nnAbs((double)AppMain.nnDotProductVectorFast(ref nns_VECTORFAST, ref nns_VECTORFAST2));
        num2 = AppMain.NNM_MAX( num2, AppMain.nnAbs( ( double )AppMain.nnDotProductVectorFast( ref nns_VECTORFAST, ref nns_VECTORFAST3 ) ) );
        num2 = AppMain.NNM_MAX( num2, AppMain.nnAbs( ( double )AppMain.nnDotProductVectorFast( ref nns_VECTORFAST2, ref nns_VECTORFAST3 ) ) );
        return AppMain.nnSqrt( num + 2f * num2 );
    }

    // Token: 0x06001998 RID: 6552 RVA: 0x000E8448 File Offset: 0x000E6648
    public static uint NND_DRAWOBJ_SHADER_USER_PROFILE( byte _n )
    {
        return ( uint )( ( uint )( _n & byte.MaxValue ) << 2 );
    }

    // Token: 0x06001999 RID: 6553 RVA: 0x000E8453 File Offset: 0x000E6653
    private static void nnSetMaterialCallback( AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.nngMaterialCallbackFunc = func;
    }

    // Token: 0x0600199A RID: 6554 RVA: 0x000E845B File Offset: 0x000E665B
    private static AppMain.NNS_MATERIALCALLBACK_FUNC nnGetMaterialCallback()
    {
        return AppMain.nngMaterialCallbackFunc;
    }

    // Token: 0x0600199B RID: 6555 RVA: 0x000E8462 File Offset: 0x000E6662
    private static int nnPutMaterial( AppMain.NNS_DRAWCALLBACK_VAL val )
    {
        if ( AppMain.nngMaterialCallbackFunc != null )
        {
            return AppMain.nngMaterialCallbackFunc( val );
        }
        return AppMain.nnPutMaterialCore( val );
    }
}