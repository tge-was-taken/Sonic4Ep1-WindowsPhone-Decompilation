using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000236 RID: 566
    private enum NNE_FOG_MODEL
    {
        // Token: 0x040057A8 RID: 22440
        NNE_FOG_NONE,
        // Token: 0x040057A9 RID: 22441
        NNE_FOG_LINEAR,
        // Token: 0x040057AA RID: 22442
        NNE_FOG_EXP,
        // Token: 0x040057AB RID: 22443
        NNE_FOG_EXP2
    }

    // Token: 0x02000237 RID: 567
    private enum NNE_ATTEN_FUNC
    {
        // Token: 0x040057AD RID: 22445
        NNE_ATTEN_CONSTANT,
        // Token: 0x040057AE RID: 22446
        NNE_ATTEN_INVLINEAR,
        // Token: 0x040057AF RID: 22447
        NNE_ATTEN_INVQUADRATIC
    }

    // Token: 0x02000238 RID: 568
    public struct NNS_SHADER_CONFIG
    {
        // Token: 0x040057B0 RID: 22448
        private int bNormalizeVertexNormal;

        // Token: 0x040057B1 RID: 22449
        private int bRescaleVertexNormal;

        // Token: 0x040057B2 RID: 22450
        private int nMaxParallelLight;

        // Token: 0x040057B3 RID: 22451
        private int nMaxPointLight;

        // Token: 0x040057B4 RID: 22452
        private int nMaxSpotLight;

        // Token: 0x040057B5 RID: 22453
        private int bLightAmbient;

        // Token: 0x040057B6 RID: 22454
        private AppMain.NNE_ATTEN_FUNC PointLightDistAtten;

        // Token: 0x040057B7 RID: 22455
        private AppMain.NNE_ATTEN_FUNC SpotLightDistAtten;

        // Token: 0x040057B8 RID: 22456
        private AppMain.NNE_FOG_MODEL FogModel;

        // Token: 0x040057B9 RID: 22457
        private int bDistanceFog;

        // Token: 0x040057BA RID: 22458
        private int bFragmentFog;

        // Token: 0x040057BB RID: 22459
        private uint nUserUniform;

        // Token: 0x040057BC RID: 22460
        private int bHalfFloat;

        // Token: 0x040057BD RID: 22461
        private int bNoScaleEnvelope;

        // Token: 0x040057BE RID: 22462
        private int bVertexSpecular;

        // Token: 0x040057BF RID: 22463
        private int bCalcBinormal;
    }

    // Token: 0x02000239 RID: 569
    public class NNS_SHADER_PROFILE
    {
        // Token: 0x040057C0 RID: 22464
        private int bLighting;

        // Token: 0x040057C1 RID: 22465
        private int bSpecular;

        // Token: 0x040057C2 RID: 22466
        private int bTwoSidedLighting;

        // Token: 0x040057C3 RID: 22467
        private int nFragParallelLight;

        // Token: 0x040057C4 RID: 22468
        private int nFragPointLight;

        // Token: 0x040057C5 RID: 22469
        private int NormalMapType;

        // Token: 0x040057C6 RID: 22470
        private int bBaseMap;

        // Token: 0x040057C7 RID: 22471
        private int nDecalMap;

        // Token: 0x040057C8 RID: 22472
        private int bSpecularMap;

        // Token: 0x040057C9 RID: 22473
        private int bShininessMap;

        // Token: 0x040057CA RID: 22474
        private int bDualParaboloidMap;

        // Token: 0x040057CB RID: 22475
        private int bEnvMaskMap;

        // Token: 0x040057CC RID: 22476
        private int bModulateMap;

        // Token: 0x040057CD RID: 22477
        private int bAddMap;

        // Token: 0x040057CE RID: 22478
        private int bOpacityMap;

        // Token: 0x040057CF RID: 22479
        private int bUser1Map;

        // Token: 0x040057D0 RID: 22480
        private int bUser2Map;

        // Token: 0x040057D1 RID: 22481
        private int bUser3Map;

        // Token: 0x040057D2 RID: 22482
        private int bUser4Map;

        // Token: 0x040057D3 RID: 22483
        private int bUser5Map;

        // Token: 0x040057D4 RID: 22484
        private int bUser6Map;

        // Token: 0x040057D5 RID: 22485
        private int bUser7Map;

        // Token: 0x040057D6 RID: 22486
        private int bUser8Map;

        // Token: 0x040057D7 RID: 22487
        private int nShadowMap;

        // Token: 0x040057D8 RID: 22488
        private int bUserSampler2D1;

        // Token: 0x040057D9 RID: 22489
        private int bUserSampler2D2;

        // Token: 0x040057DA RID: 22490
        private int bUserSampler3D1;

        // Token: 0x040057DB RID: 22491
        private int bUserSampler3D2;

        // Token: 0x040057DC RID: 22492
        private int bUserSamplerCube1;

        // Token: 0x040057DD RID: 22493
        private int bUserSamplerCube2;

        // Token: 0x040057DE RID: 22494
        private int[] TexCoord = AppMain.New<int>(8);

        // Token: 0x040057DF RID: 22495
        private uint UserProfile;

        // Token: 0x040057E0 RID: 22496
        private uint UserProfileDrawobj;

        // Token: 0x040057E1 RID: 22497
        private int nVertexMatrixIndex;
    }

    // Token: 0x0200023A RID: 570
    private class NNS_SHADER_NAME
    {
        // Token: 0x040057E2 RID: 22498
        private ulong low;

        // Token: 0x040057E3 RID: 22499
        private ulong high;
    }

    // Token: 0x0200023B RID: 571
    private enum NNE_SHADERTYPE
    {
        // Token: 0x040057E5 RID: 22501
        NNE_SHADERTYPE_NONE,
        // Token: 0x040057E6 RID: 22502
        NNE_SHADERTYPE_GLSL,
        // Token: 0x040057E7 RID: 22503
        NNE_SHADERTYPE_VP_FP
    }

    // Token: 0x0200023C RID: 572
    private class NNS_COMPILED_SHADER_PROFILE
    {
        // Token: 0x040057E8 RID: 22504
        private AppMain.NNE_SHADERTYPE ShaderType;

        // Token: 0x040057E9 RID: 22505
        private uint ProgramObject;

        // Token: 0x040057EA RID: 22506
        private uint VertexProgram;

        // Token: 0x040057EB RID: 22507
        private uint FragmentProgram;
    }
}