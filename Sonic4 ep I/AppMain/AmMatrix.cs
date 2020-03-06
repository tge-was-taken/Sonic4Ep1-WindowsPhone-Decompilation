using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000A69 RID: 2665 RVA: 0x0005C7FC File Offset: 0x0005A9FC
    public static void amMatrixPush( ref AppMain.SNNS_MATRIX mtx )
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        AppMain.nnPushMatrix( mstk, ref mtx );
    }

    // Token: 0x06000A6A RID: 2666 RVA: 0x0005C818 File Offset: 0x0005AA18
    public static void amMatrixPush( AppMain.NNS_MATRIX mtx )
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        AppMain.nnPushMatrix( mstk, mtx );
    }

    // Token: 0x06000A6B RID: 2667 RVA: 0x0005C834 File Offset: 0x0005AA34
    public static void amMatrixPush()
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        AppMain.nnPushMatrix( mstk );
    }

    // Token: 0x06000A6C RID: 2668 RVA: 0x0005C850 File Offset: 0x0005AA50
    public static void amMatrixPop()
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        AppMain.nnPopMatrix( mstk );
    }

    // Token: 0x06000A6D RID: 2669 RVA: 0x0005C86C File Offset: 0x0005AA6C
    public static AppMain.NNS_MATRIX amMatrixGetCurrent()
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        return AppMain.nnGetCurrentMatrix( mstk );
    }

    // Token: 0x06000A6E RID: 2670 RVA: 0x0005C888 File Offset: 0x0005AA88
    public static void amMatrixSetCurrent( AppMain.NNS_MATRIX m )
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        AppMain.nnSetCurrentMatrix( mstk, m );
    }

    // Token: 0x06000A6F RID: 2671 RVA: 0x0005C8A4 File Offset: 0x0005AAA4
    public static void amMatrixClearStack()
    {
        AppMain.NNS_MATRIXSTACK mstk = AppMain._amMatrixGetCurrentStack();
        AppMain.nnClearMatrixStack( mstk );
    }

    // Token: 0x06000A70 RID: 2672 RVA: 0x0005C8C0 File Offset: 0x0005AAC0
    public static void amMatrixCalcPoint( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformVector( ref pDst, mtx, ref pSrc );
        pDst.w = pSrc.w;
    }

    // Token: 0x06000A71 RID: 2673 RVA: 0x0005C8E8 File Offset: 0x0005AAE8
    public static void amMatrixCalcPoint( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformVector( pDst, mtx, pSrc );
        pDst.w = pSrc.w;
    }

    // Token: 0x06000A72 RID: 2674 RVA: 0x0005C910 File Offset: 0x0005AB10
    public static void amMatrixCalcPoint( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformVector( pDst, mtx, pSrc );
    }

    // Token: 0x06000A73 RID: 2675 RVA: 0x0005C92C File Offset: 0x0005AB2C
    public static void amMatrixCalcVector( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformNormalVector( pDst, mtx, pSrc );
    }

    // Token: 0x06000A74 RID: 2676 RVA: 0x0005C948 File Offset: 0x0005AB48
    public static void amMatrixCalcVector( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformNormalVector( pDst, mtx, pSrc );
    }

    // Token: 0x06000A75 RID: 2677 RVA: 0x0005C964 File Offset: 0x0005AB64
    public static void amMatrixCalcVector( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformNormalVector( ref pDst, mtx, ref pSrc );
    }

    // Token: 0x06000A76 RID: 2678 RVA: 0x0005C980 File Offset: 0x0005AB80
    public static void amMatrixCalcVector( ref AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.nnTransformNormalVector( ref pDst, mtx, pSrc );
    }

    // Token: 0x06000A77 RID: 2679 RVA: 0x0005C99B File Offset: 0x0005AB9B
    public static AppMain.NNS_MATRIXSTACK _amMatrixGetCurrentStack()
    {
        return AppMain._am_default_stack;
    }
}