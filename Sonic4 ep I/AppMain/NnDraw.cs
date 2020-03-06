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
    // Token: 0x020000B3 RID: 179
    private static class nndrawprim2d
    {
        // Token: 0x04004B21 RID: 19233
        public static int nnsFormat;

        // Token: 0x04004B22 RID: 19234
        public static uint nnsAlphaFunc = 516U;

        // Token: 0x04004B23 RID: 19235
        public static float nnsAlphaFuncRef = 0f;

        // Token: 0x04004B24 RID: 19236
        public static uint nnsDepthFunc = 515U;

        // Token: 0x04004B25 RID: 19237
        public static bool nnsDepthMask = true;
    }

    // Token: 0x020000B4 RID: 180
    private class _nnDrawPrimitive2DCore
    {
        // Token: 0x04004B26 RID: 19238
        public static Vector3[] vbuf = new Vector3[6];

        // Token: 0x04004B27 RID: 19239
        public static AppMain.RGBA_U8[] cbuf = new AppMain.RGBA_U8[6];
    }

    // Token: 0x020000FA RID: 250
    public class NNS_DRAWCALLBACK_VAL
    {
        // Token: 0x04004BFA RID: 19450
        public int iMaterial;

        // Token: 0x04004BFB RID: 19451
        public int iPrevMaterial;

        // Token: 0x04004BFC RID: 19452
        public int iVtxList;

        // Token: 0x04004BFD RID: 19453
        public int iPrevVtxList;

        // Token: 0x04004BFE RID: 19454
        public int iNode;

        // Token: 0x04004BFF RID: 19455
        public int iMeshset;

        // Token: 0x04004C00 RID: 19456
        public int iSubobject;

        // Token: 0x04004C01 RID: 19457
        public AppMain.NNS_MATERIALPTR pMaterial;

        // Token: 0x04004C02 RID: 19458
        public AppMain.NNS_VTXLISTPTR pVtxListPtr;

        // Token: 0x04004C03 RID: 19459
        public AppMain.NNS_OBJECT pObject;

        // Token: 0x04004C04 RID: 19460
        public AppMain.NNS_MATRIX[] pMatrixPalette;

        // Token: 0x04004C05 RID: 19461
        public uint[] pNodeStatusList;

        // Token: 0x04004C06 RID: 19462
        public uint DrawSubobjType;

        // Token: 0x04004C07 RID: 19463
        public uint DrawFlag;

        // Token: 0x04004C08 RID: 19464
        public int bModified;

        // Token: 0x04004C09 RID: 19465
        public int bReDraw;
    }

    // Token: 0x02000108 RID: 264
    private static class nndrawprim3d
    {
        // Token: 0x04004C3D RID: 19517
        public static int nnsFormat;

        // Token: 0x04004C3E RID: 19518
        public static readonly float[] nnsDiffuse = new float[]
        {
            0.8f,
            0.8f,
            0.8f,
            1f
        };

        // Token: 0x04004C3F RID: 19519
        public static readonly float[] nnsAmbient = new float[]
        {
            0.2f,
            0.2f,
            0.2f,
            1f
        };

        // Token: 0x04004C40 RID: 19520
        public static readonly float[] nnsSpecular = new float[]
        {
            default(float),
            default(float),
            default(float),
            1f
        };

        // Token: 0x04004C41 RID: 19521
        public static float nnsShininess = 16f;

        // Token: 0x04004C42 RID: 19522
        public static readonly float[] nnsEmission = new float[]
        {
            default(float),
            default(float),
            default(float),
            1f
        };

        // Token: 0x04004C43 RID: 19523
        public static readonly AppMain.NNS_MATRIX nnsPrim3DMatrix = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04004C44 RID: 19524
        public static uint nnsAlphaFunc = 516U;

        // Token: 0x04004C45 RID: 19525
        public static float nnsAlphaFuncRef = 0f;

        // Token: 0x04004C46 RID: 19526
        public static uint nnsDepthFunc = 515U;

        // Token: 0x04004C47 RID: 19527
        public static bool nnsDepthMask = true;
    }

    // Token: 0x02000109 RID: 265
    private class _nnDrawPrimitive3DCore
    {
        // Token: 0x04004C48 RID: 19528
        public static AppMain.RGBA_U8[] cbuf = new AppMain.RGBA_U8[6];

        // Token: 0x04004C49 RID: 19529
        public static AppMain.NNS_PRIM3D_PCT[] prim_d = AppMain.New<AppMain.NNS_PRIM3D_PCT>(2048);

        // Token: 0x04004C4A RID: 19530
        public static AppMain.RGBA_U8[] prim_c = AppMain.New<AppMain.RGBA_U8>(2048);

        // Token: 0x04004C4B RID: 19531
        public static AppMain.NNS_PRIM3D_PCT_VertexData vertexData = new AppMain.NNS_PRIM3D_PCT_VertexData();

        // Token: 0x04004C4C RID: 19532
        public static AppMain.NNS_PRIM3D_PC_VertexData vertexDataPC = new AppMain.NNS_PRIM3D_PC_VertexData();

        // Token: 0x04004C4D RID: 19533
        public static AppMain.NNS_PRIM3D_PCT_TexCoordData texCoordData = new AppMain.NNS_PRIM3D_PCT_TexCoordData();

        // Token: 0x04004C4E RID: 19534
        public static AppMain.RGBA_U8_ColorData colorData = new AppMain.RGBA_U8_ColorData();
    }

    // Token: 0x0200010A RID: 266
    private class _nnMakeRotateMatrixQuaternion
    {
        // Token: 0x04004C4F RID: 19535
        public static int[] nxt = new int[3];

        // Token: 0x04004C50 RID: 19536
        public static float[] q = new float[3];
    }

    // Token: 0x020001A4 RID: 420
    private static class nndrawcircumsphere
    {
        // Token: 0x04004F5C RID: 20316
        public static int nnsSubMotIdx;

        // Token: 0x04004F5D RID: 20317
        public static readonly AppMain.NNS_RGBA[] nnsMsstCircumCol = new AppMain.NNS_RGBA[]
        {
            new AppMain.NNS_RGBA(0f, 1f, 0f, 0.3f),
            new AppMain.NNS_RGBA(1f, 0f, 1f, 0.3f),
            new AppMain.NNS_RGBA(1f, 1f, 0f, 0.3f),
            new AppMain.NNS_RGBA(1f, 1f, 1f, 0.3f),
            new AppMain.NNS_RGBA(0f, 1f, 1f, 0.3f),
            new AppMain.NNS_RGBA(1f, 0f, 0f, 0.3f),
            new AppMain.NNS_RGBA(0f, 0f, 0f, 0.3f),
            default(AppMain.NNS_RGBA)
        };

        // Token: 0x04004F5E RID: 20318
        public static AppMain.NNS_MATRIX nnsBaseMtx;

        // Token: 0x04004F5F RID: 20319
        public static AppMain.NNS_OBJECT nnsObj;

        // Token: 0x04004F60 RID: 20320
        public static AppMain.NNS_NODE nnsNodeList;

        // Token: 0x04004F61 RID: 20321
        public static AppMain.NNS_MATRIXSTACK nnsMstk;

        // Token: 0x04004F62 RID: 20322
        public static AppMain.NNS_MOTION nnsMot;

        // Token: 0x04004F63 RID: 20323
        public static AppMain.NNS_TRS nnsTrsList;

        // Token: 0x04004F64 RID: 20324
        public static float nnsFrame;

        // Token: 0x04004F65 RID: 20325
        public static uint nnsDrawCsFlag;
    }

}