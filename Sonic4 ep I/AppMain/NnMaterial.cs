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
using System.Runtime.InteropServices;

public partial class AppMain
{
    // Token: 0x020000A4 RID: 164
    public class NNS_MATERIAL_COLOR
    {
        // Token: 0x06001EAB RID: 7851 RVA: 0x0013B3F6 File Offset: 0x001395F6
        public NNS_MATERIAL_COLOR()
        {
        }

        // Token: 0x06001EAC RID: 7852 RVA: 0x0013B400 File Offset: 0x00139600
        public NNS_MATERIAL_COLOR( AppMain.NNS_MATERIAL_COLOR matColor )
        {
            this.fFlag = matColor.fFlag;
            this.Ambient = matColor.Ambient;
            this.Diffuse = matColor.Diffuse;
            this.Specular = matColor.Specular;
            this.Emission = matColor.Emission;
            this.Shininess = matColor.Shininess;
            this.VtxColMaterial = matColor.VtxColMaterial;
        }

        // Token: 0x06001EAD RID: 7853 RVA: 0x0013B468 File Offset: 0x00139668
        public AppMain.NNS_MATERIAL_COLOR Assign( AppMain.NNS_MATERIAL_COLOR matColor )
        {
            this.fFlag = matColor.fFlag;
            this.Ambient = matColor.Ambient;
            this.Diffuse = matColor.Diffuse;
            this.Specular = matColor.Specular;
            this.Emission = matColor.Emission;
            this.Shininess = matColor.Shininess;
            this.VtxColMaterial = matColor.VtxColMaterial;
            return this;
        }

        // Token: 0x06001EAE RID: 7854 RVA: 0x0013B4CC File Offset: 0x001396CC
        public static explicit operator AppMain.NNS_MATERIAL_STDSHADER_COLOR( AppMain.NNS_MATERIAL_COLOR color )
        {
            return new AppMain.NNS_MATERIAL_STDSHADER_COLOR
            {
                Ambient = color.Ambient,
                Diffuse = color.Diffuse,
                Emission = color.Emission,
                fFlag = color.fFlag,
                Shininess = color.Shininess,
                Specular = color.Specular,
                SpecularIntensity = MppBitConverter.UInt32ToSingle( color.VtxColMaterial )
            };
        }

        // Token: 0x04004A9E RID: 19102
        public uint fFlag;

        // Token: 0x04004A9F RID: 19103
        public AppMain.NNS_RGBA Ambient;

        // Token: 0x04004AA0 RID: 19104
        public AppMain.NNS_RGBA Diffuse;

        // Token: 0x04004AA1 RID: 19105
        public AppMain.NNS_RGBA Specular;

        // Token: 0x04004AA2 RID: 19106
        public AppMain.NNS_RGBA Emission;

        // Token: 0x04004AA3 RID: 19107
        public float Shininess;

        // Token: 0x04004AA4 RID: 19108
        public uint VtxColMaterial;
    }

    // Token: 0x020000A5 RID: 165
    public class NNS_MATERIAL_LOGIC
    {
        // Token: 0x06001EAF RID: 7855 RVA: 0x0013B53C File Offset: 0x0013973C
        public AppMain.NNS_MATERIAL_LOGIC Assign( AppMain.NNS_MATERIAL_LOGIC matLogic )
        {
            this.fFlag = matLogic.fFlag;
            this.SrcFactorRGB = matLogic.SrcFactorRGB;
            this.DstFactorRGB = matLogic.DstFactorRGB;
            this.SrcFactorA = matLogic.SrcFactorA;
            this.DstFactorA = matLogic.DstFactorA;
            this.BlendColor = matLogic.BlendColor;
            this.BlendOp = matLogic.BlendOp;
            this.LogicOp = matLogic.LogicOp;
            this.AlphaFunc = matLogic.AlphaFunc;
            this.DepthFunc = matLogic.DepthFunc;
            this.AlphaRef = matLogic.AlphaRef;
            return this;
        }

        // Token: 0x04004AA5 RID: 19109
        public uint fFlag;

        // Token: 0x04004AA6 RID: 19110
        public ushort SrcFactorRGB;

        // Token: 0x04004AA7 RID: 19111
        public ushort DstFactorRGB;

        // Token: 0x04004AA8 RID: 19112
        public ushort SrcFactorA;

        // Token: 0x04004AA9 RID: 19113
        public ushort DstFactorA;

        // Token: 0x04004AAA RID: 19114
        public AppMain.NNS_RGBA BlendColor;

        // Token: 0x04004AAB RID: 19115
        public ushort BlendOp;

        // Token: 0x04004AAC RID: 19116
        public ushort LogicOp;

        // Token: 0x04004AAD RID: 19117
        public ushort AlphaFunc;

        // Token: 0x04004AAE RID: 19118
        public ushort DepthFunc;

        // Token: 0x04004AAF RID: 19119
        public float AlphaRef;
    }

    // Token: 0x020000A6 RID: 166
    public class NNS_TEXTURE_COMBINE
    {
        // Token: 0x06001EB1 RID: 7857 RVA: 0x0013B5D8 File Offset: 0x001397D8
        public AppMain.NNS_TEXTURE_COMBINE Assign( AppMain.NNS_TEXTURE_COMBINE combine )
        {
            this.CombineRGB = combine.CombineRGB;
            this.Source0RGB = combine.Source0RGB;
            this.Operand0RGB = combine.Operand0RGB;
            this.Source1RGB = combine.Source1RGB;
            this.Operand1RGB = combine.Operand1RGB;
            this.Source2RGB = combine.Source2RGB;
            this.Operand2RGB = combine.Operand2RGB;
            this.CombineAlpha = combine.CombineAlpha;
            this.Source0Alpha = combine.Source0Alpha;
            this.Operand0Alpha = combine.Operand0Alpha;
            this.Source1Alpha = combine.Source1Alpha;
            this.Operand1Alpha = combine.Operand1Alpha;
            this.Source2Alpha = combine.Source2Alpha;
            this.Operand2Alpha = combine.Operand2Alpha;
            return this;
        }

        // Token: 0x04004AB0 RID: 19120
        public ushort CombineRGB;

        // Token: 0x04004AB1 RID: 19121
        public ushort Source0RGB;

        // Token: 0x04004AB2 RID: 19122
        public ushort Operand0RGB;

        // Token: 0x04004AB3 RID: 19123
        public ushort Source1RGB;

        // Token: 0x04004AB4 RID: 19124
        public ushort Operand1RGB;

        // Token: 0x04004AB5 RID: 19125
        public ushort Source2RGB;

        // Token: 0x04004AB6 RID: 19126
        public ushort Operand2RGB;

        // Token: 0x04004AB7 RID: 19127
        public ushort CombineAlpha;

        // Token: 0x04004AB8 RID: 19128
        public ushort Source0Alpha;

        // Token: 0x04004AB9 RID: 19129
        public ushort Operand0Alpha;

        // Token: 0x04004ABA RID: 19130
        public ushort Source1Alpha;

        // Token: 0x04004ABB RID: 19131
        public ushort Operand1Alpha;

        // Token: 0x04004ABC RID: 19132
        public ushort Source2Alpha;

        // Token: 0x04004ABD RID: 19133
        public ushort Operand2Alpha;
    }

    // Token: 0x020000A7 RID: 167
    public class NNS_TEXTURE_FILTERMODE
    {
        // Token: 0x06001EB3 RID: 7859 RVA: 0x0013B698 File Offset: 0x00139898
        public static AppMain.NNS_TEXTURE_FILTERMODE Read( BinaryReader reader )
        {
            return new AppMain.NNS_TEXTURE_FILTERMODE
            {
                MagFilter = reader.ReadUInt16(),
                MinFilter = reader.ReadUInt16(),
                Anisotropy = reader.ReadSingle()
            };
        }

        // Token: 0x06001EB4 RID: 7860 RVA: 0x0013B6D0 File Offset: 0x001398D0
        public AppMain.NNS_TEXTURE_FILTERMODE Assign( AppMain.NNS_TEXTURE_FILTERMODE filterMode )
        {
            this.MagFilter = filterMode.MagFilter;
            this.MinFilter = filterMode.MinFilter;
            this.Anisotropy = filterMode.Anisotropy;
            return this;
        }

        // Token: 0x04004ABE RID: 19134
        public ushort MagFilter;

        // Token: 0x04004ABF RID: 19135
        public ushort MinFilter;

        // Token: 0x04004AC0 RID: 19136
        public float Anisotropy;
    }

    // Token: 0x020000A8 RID: 168
    public class NNS_TEXTURE_LOD_PARAM
    {
        // Token: 0x06001EB6 RID: 7862 RVA: 0x0013B6FF File Offset: 0x001398FF
        public AppMain.NNS_TEXTURE_LOD_PARAM Assign( AppMain.NNS_TEXTURE_LOD_PARAM lodParam )
        {
            this.BaseLevel = lodParam.BaseLevel;
            this.MaxLevel = lodParam.MaxLevel;
            this.MinLOD = lodParam.MinLOD;
            this.MaxLOD = lodParam.MaxLOD;
            this.LODBias = lodParam.LODBias;
            return this;
        }

        // Token: 0x04004AC1 RID: 19137
        public int BaseLevel;

        // Token: 0x04004AC2 RID: 19138
        public int MaxLevel;

        // Token: 0x04004AC3 RID: 19139
        public float MinLOD;

        // Token: 0x04004AC4 RID: 19140
        public float MaxLOD;

        // Token: 0x04004AC5 RID: 19141
        public float LODBias;
    }

    // Token: 0x020000A9 RID: 169
    public class NNS_MATERIAL_TEXMAP_DESC
    {
        // Token: 0x06001EB8 RID: 7864 RVA: 0x0013B746 File Offset: 0x00139946
        public void Assign( AppMain.NNS_MATERIAL_TEXMAP_DESC pPtr )
        {
            AppMain.mppAssertNotImpl();
        }

        // Token: 0x06001EB9 RID: 7865 RVA: 0x0013B74D File Offset: 0x0013994D
        public NNS_MATERIAL_TEXMAP_DESC()
        {
        }

        // Token: 0x06001EBA RID: 7866 RVA: 0x0013B764 File Offset: 0x00139964
        public NNS_MATERIAL_TEXMAP_DESC( AppMain.NNS_MATERIAL_TEXMAP_DESC desc )
        {
            this.fType = desc.fType;
            this.iTexIdx = desc.iTexIdx;
            this.EnvMode = desc.EnvMode;
            this.pCombine = desc.pCombine;
            this.EnvColor = desc.EnvColor;
            this.Offset = desc.Offset;
            this.Scale = desc.Scale;
            this.WrapS = desc.WrapS;
            this.WrapT = desc.WrapT;
            this.pBorderColor = desc.pBorderColor;
            this.pFilterMode = desc.pFilterMode;
            this.pLODParam = desc.pLODParam;
            this.pTexInfo = desc.pTexInfo;
            this.Reserved1 = desc.Reserved1;
            this.Reserved0 = desc.Reserved0;
        }

        // Token: 0x04004AC6 RID: 19142
        public uint fType;

        // Token: 0x04004AC7 RID: 19143
        public int iTexIdx;

        // Token: 0x04004AC8 RID: 19144
        public int EnvMode;

        // Token: 0x04004AC9 RID: 19145
        public AppMain.NNS_TEXTURE_COMBINE pCombine;

        // Token: 0x04004ACA RID: 19146
        public AppMain.NNS_RGBA EnvColor;

        // Token: 0x04004ACB RID: 19147
        public AppMain.NNS_TEXCOORD Offset;

        // Token: 0x04004ACC RID: 19148
        public AppMain.NNS_TEXCOORD Scale;

        // Token: 0x04004ACD RID: 19149
        public int WrapS;

        // Token: 0x04004ACE RID: 19150
        public int WrapT;

        // Token: 0x04004ACF RID: 19151
        public AppMain.NNS_RGBA? pBorderColor = default(AppMain.NNS_RGBA?);

        // Token: 0x04004AD0 RID: 19152
        public AppMain.NNS_TEXTURE_FILTERMODE pFilterMode;

        // Token: 0x04004AD1 RID: 19153
        public AppMain.NNS_TEXTURE_LOD_PARAM pLODParam;

        // Token: 0x04004AD2 RID: 19154
        public object pTexInfo;

        // Token: 0x04004AD3 RID: 19155
        public uint Reserved1;

        // Token: 0x04004AD4 RID: 19156
        public uint Reserved0;
    }

    // Token: 0x020000AA RID: 170
    public class NNS_MATERIAL_DESC
    {
        // Token: 0x06001EBB RID: 7867 RVA: 0x0013B837 File Offset: 0x00139A37
        public NNS_MATERIAL_DESC()
        {
        }

        // Token: 0x06001EBC RID: 7868 RVA: 0x0013B840 File Offset: 0x00139A40
        public NNS_MATERIAL_DESC( AppMain.NNS_MATERIAL_DESC desc )
        {
            this.fFlag = desc.fFlag;
            this.User = desc.User;
            this.pColor = desc.pColor;
            this.pBackColor = desc.pBackColor;
            this.pLogic = desc.pLogic;
            this.nTex = desc.nTex;
            this.pTexDesc = desc.pTexDesc;
        }

        // Token: 0x06001EBD RID: 7869 RVA: 0x0013B8A8 File Offset: 0x00139AA8
        public AppMain.NNS_MATERIAL_DESC Assign( AppMain.NNS_MATERIAL_DESC desc )
        {
            this.fFlag = desc.fFlag;
            this.User = desc.User;
            this.pColor = desc.pColor;
            this.pBackColor = desc.pBackColor;
            this.pLogic = desc.pLogic;
            this.nTex = desc.nTex;
            this.pTexDesc = desc.pTexDesc;
            return this;
        }

        // Token: 0x04004AD5 RID: 19157
        public uint fFlag;

        // Token: 0x04004AD6 RID: 19158
        public uint User;

        // Token: 0x04004AD7 RID: 19159
        public AppMain.NNS_MATERIAL_COLOR pColor;

        // Token: 0x04004AD8 RID: 19160
        public AppMain.NNS_MATERIAL_COLOR pBackColor;

        // Token: 0x04004AD9 RID: 19161
        public AppMain.NNS_MATERIAL_LOGIC pLogic;

        // Token: 0x04004ADA RID: 19162
        public int nTex;

        // Token: 0x04004ADB RID: 19163
        public AppMain.NNS_MATERIAL_TEXMAP_DESC[] pTexDesc;
    }

    // Token: 0x020000AB RID: 171
    public class NNS_MATERIAL_STDSHADER_COLOR
    {
        // Token: 0x06001EBE RID: 7870 RVA: 0x0013B90C File Offset: 0x00139B0C
        public static AppMain.NNS_MATERIAL_STDSHADER_COLOR Read( BinaryReader reader )
        {
            AppMain.NNS_MATERIAL_STDSHADER_COLOR nns_MATERIAL_STDSHADER_COLOR = new AppMain.NNS_MATERIAL_STDSHADER_COLOR();
            nns_MATERIAL_STDSHADER_COLOR.fFlag = reader.ReadUInt32();
            nns_MATERIAL_STDSHADER_COLOR.Ambient.r = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Ambient.g = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Ambient.b = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Ambient.a = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Diffuse.r = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Diffuse.g = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Diffuse.b = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Diffuse.a = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Specular.r = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Specular.g = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Specular.b = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Specular.a = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Emission.r = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Emission.g = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Emission.b = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Emission.a = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.Shininess = reader.ReadSingle();
            nns_MATERIAL_STDSHADER_COLOR.SpecularIntensity = reader.ReadSingle();
            return nns_MATERIAL_STDSHADER_COLOR;
        }

        // Token: 0x06001EBF RID: 7871 RVA: 0x0013BA54 File Offset: 0x00139C54
        public NNS_MATERIAL_STDSHADER_COLOR()
        {
        }

        // Token: 0x06001EC0 RID: 7872 RVA: 0x0013BA5C File Offset: 0x00139C5C
        public NNS_MATERIAL_STDSHADER_COLOR( AppMain.NNS_MATERIAL_STDSHADER_COLOR matColor )
        {
            this.fFlag = matColor.fFlag;
            this.Ambient.r = matColor.Ambient.r;
            this.Ambient.g = matColor.Ambient.g;
            this.Ambient.b = matColor.Ambient.b;
            this.Ambient.a = matColor.Ambient.a;
            this.Diffuse.r = matColor.Diffuse.r;
            this.Diffuse.g = matColor.Diffuse.g;
            this.Diffuse.b = matColor.Diffuse.b;
            this.Diffuse.a = matColor.Diffuse.a;
            this.Specular.r = matColor.Specular.r;
            this.Specular.g = matColor.Specular.g;
            this.Specular.b = matColor.Specular.b;
            this.Specular.a = matColor.Specular.a;
            this.Emission.r = matColor.Emission.r;
            this.Emission.g = matColor.Emission.g;
            this.Emission.b = matColor.Emission.b;
            this.Emission.a = matColor.Emission.a;
            this.Shininess = matColor.Shininess;
            this.SpecularIntensity = matColor.SpecularIntensity;
        }

        // Token: 0x06001EC1 RID: 7873 RVA: 0x0013BBF4 File Offset: 0x00139DF4
        public AppMain.NNS_MATERIAL_STDSHADER_COLOR Assign( AppMain.NNS_MATERIAL_STDSHADER_COLOR matColor )
        {
            this.fFlag = matColor.fFlag;
            this.Ambient.r = matColor.Ambient.r;
            this.Ambient.g = matColor.Ambient.g;
            this.Ambient.b = matColor.Ambient.b;
            this.Ambient.a = matColor.Ambient.a;
            this.Diffuse.r = matColor.Diffuse.r;
            this.Diffuse.g = matColor.Diffuse.g;
            this.Diffuse.b = matColor.Diffuse.b;
            this.Diffuse.a = matColor.Diffuse.a;
            this.Specular.r = matColor.Specular.r;
            this.Specular.g = matColor.Specular.g;
            this.Specular.b = matColor.Specular.b;
            this.Specular.a = matColor.Specular.a;
            this.Emission.r = matColor.Emission.r;
            this.Emission.g = matColor.Emission.g;
            this.Emission.b = matColor.Emission.b;
            this.Emission.a = matColor.Emission.a;
            this.Shininess = matColor.Shininess;
            this.SpecularIntensity = matColor.SpecularIntensity;
            return this;
        }

        // Token: 0x04004ADC RID: 19164
        public uint fFlag;

        // Token: 0x04004ADD RID: 19165
        public AppMain.NNS_RGBA Ambient;

        // Token: 0x04004ADE RID: 19166
        public AppMain.NNS_RGBA Diffuse;

        // Token: 0x04004ADF RID: 19167
        public AppMain.NNS_RGBA Specular;

        // Token: 0x04004AE0 RID: 19168
        public AppMain.NNS_RGBA Emission;

        // Token: 0x04004AE1 RID: 19169
        public float Shininess;

        // Token: 0x04004AE2 RID: 19170
        public float SpecularIntensity;
    }

    // Token: 0x020000AC RID: 172
    public class NNS_MATERIAL_STDSHADER_TEXMAP_DESC
    {
        // Token: 0x06001EC2 RID: 7874 RVA: 0x0013BD86 File Offset: 0x00139F86
        public void Assign( AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC pPtr )
        {
            AppMain.mppAssertNotImpl();
        }

        // Token: 0x06001EC3 RID: 7875 RVA: 0x0013BD8D File Offset: 0x00139F8D
        public NNS_MATERIAL_STDSHADER_TEXMAP_DESC()
        {
        }

        // Token: 0x06001EC4 RID: 7876 RVA: 0x0013BDA4 File Offset: 0x00139FA4
        public NNS_MATERIAL_STDSHADER_TEXMAP_DESC( AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC desc )
        {
            this.fType = desc.fType;
            this.iTexIdx = desc.iTexIdx;
            this.TexCoord = desc.TexCoord;
            this.Blend = desc.Blend;
            this.Offset = desc.Offset;
            this.Scale = desc.Scale;
            this.WrapS = desc.WrapS;
            this.WrapT = desc.WrapT;
            this.pBorderColor = desc.pBorderColor;
            this.pFilterMode = desc.pFilterMode;
            this.pLODParam = desc.pLODParam;
            this.pTexInfo = desc.pTexInfo;
            this.Reserved1 = desc.Reserved1;
            this.Reserved0 = desc.Reserved0;
        }

        // Token: 0x04004AE3 RID: 19171
        public uint fType;

        // Token: 0x04004AE4 RID: 19172
        public int iTexIdx;

        // Token: 0x04004AE5 RID: 19173
        public int TexCoord;

        // Token: 0x04004AE6 RID: 19174
        public float Blend;

        // Token: 0x04004AE7 RID: 19175
        public AppMain.NNS_TEXCOORD Offset;

        // Token: 0x04004AE8 RID: 19176
        public AppMain.NNS_TEXCOORD Scale;

        // Token: 0x04004AE9 RID: 19177
        public int WrapS;

        // Token: 0x04004AEA RID: 19178
        public int WrapT;

        // Token: 0x04004AEB RID: 19179
        public AppMain.NNS_RGBA? pBorderColor = default(AppMain.NNS_RGBA?);

        // Token: 0x04004AEC RID: 19180
        public AppMain.NNS_TEXTURE_FILTERMODE pFilterMode;

        // Token: 0x04004AED RID: 19181
        public AppMain.NNS_TEXTURE_LOD_PARAM pLODParam;

        // Token: 0x04004AEE RID: 19182
        public object pTexInfo;

        // Token: 0x04004AEF RID: 19183
        public uint Reserved1;

        // Token: 0x04004AF0 RID: 19184
        public uint Reserved0;
    }

    // Token: 0x020000AD RID: 173
    public class NNS_MATERIAL_STDSHADER_DESC
    {
        // Token: 0x06001EC5 RID: 7877 RVA: 0x0013BE6B File Offset: 0x0013A06B
        public NNS_MATERIAL_STDSHADER_DESC()
        {
        }

        // Token: 0x06001EC6 RID: 7878 RVA: 0x0013BE74 File Offset: 0x0013A074
        public NNS_MATERIAL_STDSHADER_DESC( AppMain.NNS_MATERIAL_STDSHADER_DESC desc )
        {
            this.fFlag = desc.fFlag;
            this.User = desc.User;
            this.pColor = desc.pColor;
            this.pLogic = desc.pLogic;
            this.fTexType = desc.fTexType;
            this.nTex = desc.nTex;
            this.pTexDesc = desc.pTexDesc;
        }

        // Token: 0x06001EC7 RID: 7879 RVA: 0x0013BEDC File Offset: 0x0013A0DC
        public AppMain.NNS_MATERIAL_STDSHADER_DESC Assign( AppMain.NNS_MATERIAL_STDSHADER_DESC desc )
        {
            this.fFlag = desc.fFlag;
            this.User = desc.User;
            this.pColor = desc.pColor;
            this.pLogic = desc.pLogic;
            this.fTexType = desc.fTexType;
            this.nTex = desc.nTex;
            this.pTexDesc = desc.pTexDesc;
            return this;
        }

        // Token: 0x04004AF1 RID: 19185
        public uint fFlag;

        // Token: 0x04004AF2 RID: 19186
        public uint User;

        // Token: 0x04004AF3 RID: 19187
        public AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor;

        // Token: 0x04004AF4 RID: 19188
        public AppMain.NNS_MATERIAL_LOGIC pLogic;

        // Token: 0x04004AF5 RID: 19189
        public uint fTexType;

        // Token: 0x04004AF6 RID: 19190
        public int nTex;

        // Token: 0x04004AF7 RID: 19191
        public AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[] pTexDesc;
    }

    // Token: 0x020000AE RID: 174
    public class NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE : AppMain.NNS_MATERIAL_STDSHADER_DESC
    {
        // Token: 0x06001EC8 RID: 7880 RVA: 0x0013BF3E File Offset: 0x0013A13E
        public NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE()
        {
        }

        // Token: 0x06001EC9 RID: 7881 RVA: 0x0013BF46 File Offset: 0x0013A146
        public NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE desc ) : base( desc )
        {
            this.UserProfile = desc.UserProfile;
        }

        // Token: 0x06001ECA RID: 7882 RVA: 0x0013BF5B File Offset: 0x0013A15B
        public AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE Assign( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE desc )
        {
            base.Assign( desc );
            this.UserProfile = desc.UserProfile;
            return this;
        }

        // Token: 0x04004AF8 RID: 19192
        public uint UserProfile;
    }


    // Token: 0x020000B8 RID: 184
    private class nnmaterialcore
    {
        // Token: 0x04004B38 RID: 19256
        public static uint nngPreMatFlag = uint.MaxValue;

        // Token: 0x04004B39 RID: 19257
        public static object nngpPreMatColor = null;

        // Token: 0x04004B3A RID: 19258
        public static object nngpPreMatLogic = null;
    }

    // Token: 0x020000FB RID: 251
    public class NNS_MATCTRL_RGB
    {
        // Token: 0x06001FA7 RID: 8103 RVA: 0x0013CF36 File Offset: 0x0013B136
        public NNS_MATCTRL_RGB()
        {
        }

        // Token: 0x06001FA8 RID: 8104 RVA: 0x0013CF49 File Offset: 0x0013B149
        public NNS_MATCTRL_RGB( int _mode, float r, float g, float b )
        {
            _mode = this.mode;
            this.col.r = r;
            this.col.b = b;
            this.col.g = g;
        }

        // Token: 0x04004C0A RID: 19466
        public int mode;

        // Token: 0x04004C0B RID: 19467
        public readonly AppMain.NNS_RGB col = new AppMain.NNS_RGB();
    }

    // Token: 0x020000FC RID: 252
    public class NNS_MATCTRL_ALPHA
    {
        // Token: 0x06001FA9 RID: 8105 RVA: 0x0013CF89 File Offset: 0x0013B189
        public NNS_MATCTRL_ALPHA()
        {
        }

        // Token: 0x06001FAA RID: 8106 RVA: 0x0013CF91 File Offset: 0x0013B191
        public NNS_MATCTRL_ALPHA( int _mode, float _alpha )
        {
            this.mode = _mode;
            this.alpha = _alpha;
        }

        // Token: 0x04004C0C RID: 19468
        public int mode;

        // Token: 0x04004C0D RID: 19469
        public float alpha;
    }

    // Token: 0x020000FD RID: 253
    public class NNS_MATCTRL_TEXOFFSET
    {
        // Token: 0x06001FAB RID: 8107 RVA: 0x0013CFA7 File Offset: 0x0013B1A7
        public NNS_MATCTRL_TEXOFFSET()
        {
        }

        // Token: 0x06001FAC RID: 8108 RVA: 0x0013CFBB File Offset: 0x0013B1BB
        public NNS_MATCTRL_TEXOFFSET( int _mode, float _u, float _v )
        {
            this.mode = _mode;
            this.offset.u = _u;
            this.offset.v = _v;
        }

        // Token: 0x04004C0E RID: 19470
        public int mode;

        // Token: 0x04004C0F RID: 19471
        public AppMain.NNS_TEXCOORD offset = default(AppMain.NNS_TEXCOORD);
    }

    // Token: 0x020000FE RID: 254
    public class NNS_MATCTRL_ENVTEXMATRIX
    {
        // Token: 0x06001FAD RID: 8109 RVA: 0x0013CFEE File Offset: 0x0013B1EE
        public NNS_MATCTRL_ENVTEXMATRIX()
        {
        }

        // Token: 0x06001FAE RID: 8110 RVA: 0x0013D001 File Offset: 0x0013B201
        public NNS_MATCTRL_ENVTEXMATRIX( int _texcoordsrc, AppMain.NNS_MATRIX _texmtx )
        {
            this.texcoordsrc = _texcoordsrc;
            this.texmtx.Assign( _texmtx );
        }

        // Token: 0x04004C10 RID: 19472
        public int texcoordsrc;

        // Token: 0x04004C11 RID: 19473
        public readonly AppMain.NNS_MATRIX texmtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
    }

    // Token: 0x020000FF RID: 255
    public class NNS_MATCTRL_BLENDMODE
    {
        // Token: 0x06001FAF RID: 8111 RVA: 0x0013D028 File Offset: 0x0013B228
        public NNS_MATCTRL_BLENDMODE()
        {
        }

        // Token: 0x06001FB0 RID: 8112 RVA: 0x0013D030 File Offset: 0x0013B230
        public NNS_MATCTRL_BLENDMODE( int _blendmode )
        {
            this.blendmode = _blendmode;
        }

        // Token: 0x04004C12 RID: 19474
        public int blendmode;
    }

    // Token: 0x02000100 RID: 256
    // (Invoke) Token: 0x06001FB2 RID: 8114
    public delegate int NNS_MATERIALCALLBACK_FUNC( AppMain.NNS_DRAWCALLBACK_VAL val );

    // Token: 0x020001A6 RID: 422
    private enum NNE_TEXTURETYPE_GL
    {
        // Token: 0x04004F77 RID: 20343
        NNE_TEXTURETYPE_NORMAL,
        // Token: 0x04004F78 RID: 20344
        NNE_TEXTURETYPE_BASE,
        // Token: 0x04004F79 RID: 20345
        NNE_TEXTURETYPE_DECAL,
        // Token: 0x04004F7A RID: 20346
        NNE_TEXTURETYPE_DECAL2,
        // Token: 0x04004F7B RID: 20347
        NNE_TEXTURETYPE_DECAL3,
        // Token: 0x04004F7C RID: 20348
        NNE_TEXTURETYPE_SPECULAR,
        // Token: 0x04004F7D RID: 20349
        NNE_TEXTURETYPE_SHININESS,
        // Token: 0x04004F7E RID: 20350
        NNE_TEXTURETYPE_ENVMASK,
        // Token: 0x04004F7F RID: 20351
        NNE_TEXTURETYPE_MODULATE,
        // Token: 0x04004F80 RID: 20352
        NNE_TEXTURETYPE_ADD,
        // Token: 0x04004F81 RID: 20353
        NNE_TEXTURETYPE_OPACITY,
        // Token: 0x04004F82 RID: 20354
        NNE_TEXTURETYPE_USER1,
        // Token: 0x04004F83 RID: 20355
        NNE_TEXTURETYPE_USER2,
        // Token: 0x04004F84 RID: 20356
        NNE_TEXTURETYPE_USER3,
        // Token: 0x04004F85 RID: 20357
        NNE_TEXTURETYPE_USER4,
        // Token: 0x04004F86 RID: 20358
        NNE_TEXTURETYPE_USER5,
        // Token: 0x04004F87 RID: 20359
        NNE_TEXTURETYPE_USER6,
        // Token: 0x04004F88 RID: 20360
        NNE_TEXTURETYPE_USER7,
        // Token: 0x04004F89 RID: 20361
        NNE_TEXTURETYPE_USER8,
        // Token: 0x04004F8A RID: 20362
        NNE_TEXTURETYPE_DUALPARABOLOID,
        // Token: 0x04004F8B RID: 20363
        NNE_TEXTURETYPE_MAX
    }

    // Token: 0x020001A7 RID: 423
    private enum NNE_SHADOWMAP
    {
        // Token: 0x04004F8D RID: 20365
        NNE_SHADOWMAP_1,
        // Token: 0x04004F8E RID: 20366
        NNE_SHADOWMAP_2,
        // Token: 0x04004F8F RID: 20367
        NNE_SHADOWMAP_MAX
    }

    // Token: 0x020001A8 RID: 424
    private enum NNE_USER_SAMPLER
    {
        // Token: 0x04004F91 RID: 20369
        NNE_USER_SAMPLER_2D_1,
        // Token: 0x04004F92 RID: 20370
        NNE_USER_SAMPLER_2D_2,
        // Token: 0x04004F93 RID: 20371
        NNE_USER_SAMPLER_3D_1,
        // Token: 0x04004F94 RID: 20372
        NNE_USER_SAMPLER_3D_2,
        // Token: 0x04004F95 RID: 20373
        NNE_USER_SAMPLER_CUBE_1,
        // Token: 0x04004F96 RID: 20374
        NNE_USER_SAMPLER_CUBE_2,
        // Token: 0x04004F97 RID: 20375
        NNE_USER_SAMPLER_MAX
    }

    // Token: 0x020001A9 RID: 425
    private struct NNS_MATCTRL_TEXLODBIAS
    {
        // Token: 0x04004F98 RID: 20376
        private int mode;

        // Token: 0x04004F99 RID: 20377
        private float bias;
    }

    // Token: 0x020001AA RID: 426
    private class NNS_MATCTRL_SHADOWMAP
    {
        // Token: 0x04004F9A RID: 20378
        private uint texname;

        // Token: 0x04004F9B RID: 20379
        private AppMain.NNS_MATRIX mtx;

        // Token: 0x04004F9C RID: 20380
        private AppMain.NNS_RGB col;
    }

    // Token: 0x020001AB RID: 427
    private struct NNS_MATCTRL_USERSAMPLER
    {
        // Token: 0x04004F9D RID: 20381
        private uint texname;
    }

    // Token: 0x020001E0 RID: 480
    public class NNS_MATERIALPTR
    {
        // Token: 0x060022E8 RID: 8936 RVA: 0x00147368 File Offset: 0x00145568
        public NNS_MATERIALPTR()
        {
        }

        // Token: 0x060022E9 RID: 8937 RVA: 0x00147370 File Offset: 0x00145570
        public NNS_MATERIALPTR( AppMain.NNS_MATERIALPTR materialPtr )
        {
            this.fType = materialPtr.fType;
            this.pMaterial = materialPtr.pMaterial;
        }

        // Token: 0x060022EA RID: 8938 RVA: 0x00147390 File Offset: 0x00145590
        public AppMain.NNS_MATERIALPTR Assign( AppMain.NNS_MATERIALPTR materialPtr )
        {
            this.fType = materialPtr.fType;
            this.pMaterial = materialPtr.pMaterial;
            return this;
        }

        // Token: 0x060022EB RID: 8939 RVA: 0x001473AC File Offset: 0x001455AC
        public static AppMain.NNS_MATERIALPTR Read( BinaryReader reader, long data0Pos, out bool transparentMaterial )
        {
            transparentMaterial = false;
            AppMain.NNS_MATERIALPTR nns_MATERIALPTR = new AppMain.NNS_MATERIALPTR();
            nns_MATERIALPTR.fType = reader.ReadUInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                nns_MATERIALPTR.pMaterial = AppMain.NNS_MATERIAL_GLES11_DESC.Read( reader, data0Pos, out transparentMaterial );
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_MATERIALPTR;
        }

        // Token: 0x040054A1 RID: 21665
        public uint fType;

        // Token: 0x040054A2 RID: 21666
        public object pMaterial;
    }
}
