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
    // Token: 0x020000AF RID: 175
    public class NNS_MATERIAL_GLES11_LOGIC
    {
        // Token: 0x06001ECB RID: 7883 RVA: 0x0013BF74 File Offset: 0x0013A174
        public static AppMain.NNS_MATERIAL_GLES11_LOGIC Read( BinaryReader reader )
        {
            return new AppMain.NNS_MATERIAL_GLES11_LOGIC
            {
                fFlag = reader.ReadUInt32(),
                SrcFactor = reader.ReadUInt16(),
                DstFactor = reader.ReadUInt16(),
                BlendOp = reader.ReadUInt16(),
                LogicOp = reader.ReadUInt16(),
                AlphaFunc = reader.ReadUInt16(),
                DepthFunc = reader.ReadUInt16(),
                AlphaRef = reader.ReadSingle()
            };
        }

        // Token: 0x06001ECC RID: 7884 RVA: 0x0013BFE8 File Offset: 0x0013A1E8
        public AppMain.NNS_MATERIAL_GLES11_LOGIC Assign( AppMain.NNS_MATERIAL_GLES11_LOGIC logic )
        {
            this.fFlag = logic.fFlag;
            this.SrcFactor = logic.SrcFactor;
            this.DstFactor = logic.DstFactor;
            this.BlendOp = logic.BlendOp;
            this.LogicOp = logic.LogicOp;
            this.AlphaFunc = logic.AlphaFunc;
            this.DepthFunc = logic.DepthFunc;
            this.AlphaRef = logic.AlphaRef;
            return this;
        }

        // Token: 0x04004AF9 RID: 19193
        public uint fFlag;

        // Token: 0x04004AFA RID: 19194
        public ushort SrcFactor;

        // Token: 0x04004AFB RID: 19195
        public ushort DstFactor;

        // Token: 0x04004AFC RID: 19196
        public ushort BlendOp;

        // Token: 0x04004AFD RID: 19197
        public ushort LogicOp;

        // Token: 0x04004AFE RID: 19198
        public ushort AlphaFunc;

        // Token: 0x04004AFF RID: 19199
        public ushort DepthFunc;

        // Token: 0x04004B00 RID: 19200
        public float AlphaRef;
    }

    // Token: 0x020000B0 RID: 176
    public class NNS_TEXTURE_GLES11_COMBINE
    {
        // Token: 0x06001ECE RID: 7886 RVA: 0x0013C060 File Offset: 0x0013A260
        public static AppMain.NNS_TEXTURE_GLES11_COMBINE Read( BinaryReader reader )
        {
            AppMain.NNS_TEXTURE_GLES11_COMBINE nns_TEXTURE_GLES11_COMBINE = new AppMain.NNS_TEXTURE_GLES11_COMBINE();
            nns_TEXTURE_GLES11_COMBINE.CombineRGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Source0RGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Operand0RGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Source1RGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Operand1RGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Source2RGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Operand2RGB = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.CombineAlpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Source0Alpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Operand0Alpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Source1Alpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Operand1Alpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Source2Alpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.Operand2Alpha = reader.ReadUInt16();
            nns_TEXTURE_GLES11_COMBINE.EnvColor.r = reader.ReadSingle();
            nns_TEXTURE_GLES11_COMBINE.EnvColor.g = reader.ReadSingle();
            nns_TEXTURE_GLES11_COMBINE.EnvColor.b = reader.ReadSingle();
            nns_TEXTURE_GLES11_COMBINE.EnvColor.a = reader.ReadSingle();
            return nns_TEXTURE_GLES11_COMBINE;
        }

        // Token: 0x06001ECF RID: 7887 RVA: 0x0013C160 File Offset: 0x0013A360
        public AppMain.NNS_TEXTURE_GLES11_COMBINE Assign( AppMain.NNS_TEXTURE_GLES11_COMBINE combine )
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
            this.EnvColor = combine.EnvColor;
            return this;
        }

        // Token: 0x04004B01 RID: 19201
        public ushort CombineRGB;

        // Token: 0x04004B02 RID: 19202
        public ushort Source0RGB;

        // Token: 0x04004B03 RID: 19203
        public ushort Operand0RGB;

        // Token: 0x04004B04 RID: 19204
        public ushort Source1RGB;

        // Token: 0x04004B05 RID: 19205
        public ushort Operand1RGB;

        // Token: 0x04004B06 RID: 19206
        public ushort Source2RGB;

        // Token: 0x04004B07 RID: 19207
        public ushort Operand2RGB;

        // Token: 0x04004B08 RID: 19208
        public ushort CombineAlpha;

        // Token: 0x04004B09 RID: 19209
        public ushort Source0Alpha;

        // Token: 0x04004B0A RID: 19210
        public ushort Operand0Alpha;

        // Token: 0x04004B0B RID: 19211
        public ushort Source1Alpha;

        // Token: 0x04004B0C RID: 19212
        public ushort Operand1Alpha;

        // Token: 0x04004B0D RID: 19213
        public ushort Source2Alpha;

        // Token: 0x04004B0E RID: 19214
        public ushort Operand2Alpha;

        // Token: 0x04004B0F RID: 19215
        public AppMain.NNS_RGBA EnvColor;
    }

    // Token: 0x020000B1 RID: 177
    public struct NNS_MATERIAL_GLES11_TEXMAP_DESC
    {
        // Token: 0x06001ED1 RID: 7889 RVA: 0x0013C22C File Offset: 0x0013A42C
        public void Assign( ref AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC pPtr )
        {
            this.fType = pPtr.fType;
            this.iTexIdx = pPtr.iTexIdx;
            this.EnvMode = pPtr.EnvMode;
            this.pCombine = pPtr.pCombine;
            this.Offset = pPtr.Offset;
            this.Scale = pPtr.Scale;
            this.WrapS = pPtr.WrapS;
            this.WrapT = pPtr.WrapT;
            this.pFilterMode = pPtr.pFilterMode;
            this.LODBias = pPtr.LODBias;
            this.pTexInfo = pPtr.pTexInfo;
        }

        // Token: 0x06001ED2 RID: 7890 RVA: 0x0013C2C0 File Offset: 0x0013A4C0
        public NNS_MATERIAL_GLES11_TEXMAP_DESC( ref AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC desc )
        {
            this.fType = desc.fType;
            this.iTexIdx = desc.iTexIdx;
            this.EnvMode = desc.EnvMode;
            this.pCombine = desc.pCombine;
            this.Offset = desc.Offset;
            this.Scale = desc.Scale;
            this.WrapS = desc.WrapS;
            this.WrapT = desc.WrapT;
            this.pFilterMode = desc.pFilterMode;
            this.LODBias = desc.LODBias;
            this.pTexInfo = desc.pTexInfo;
        }

        // Token: 0x06001ED3 RID: 7891 RVA: 0x0013C354 File Offset: 0x0013A554
        public static AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC result = default(AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC);
            result.fType = reader.ReadUInt32();
            result.iTexIdx = reader.ReadInt32();
            result.EnvMode = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                result.pCombine = AppMain.NNS_TEXTURE_GLES11_COMBINE.Read( reader );
                reader.BaseStream.Seek( position, 0 );
            }
            result.Offset.u = reader.ReadSingle();
            result.Offset.v = reader.ReadSingle();
            result.Scale.u = reader.ReadSingle();
            result.Scale.v = reader.ReadSingle();
            result.WrapS = reader.ReadInt32();
            result.WrapT = reader.ReadInt32();
            uint num2 = reader.ReadUInt32();
            if ( num2 != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num2 ), 0 );
                result.pFilterMode = AppMain.NNS_TEXTURE_FILTERMODE.Read( reader );
                reader.BaseStream.Seek( position, 0 );
            }
            result.LODBias = reader.ReadSingle();
            uint num3 = reader.ReadUInt32();
            if ( num3 != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num3 ), 0 );
                result.pTexInfo = AppMain.NNS_TEXINFO.Read( reader );
                reader.BaseStream.Seek( position, 0 );
            }
            return result;
        }

        // Token: 0x04004B10 RID: 19216
        public uint fType;

        // Token: 0x04004B11 RID: 19217
        public int iTexIdx;

        // Token: 0x04004B12 RID: 19218
        public int EnvMode;

        // Token: 0x04004B13 RID: 19219
        public AppMain.NNS_TEXTURE_GLES11_COMBINE pCombine;

        // Token: 0x04004B14 RID: 19220
        public AppMain.NNS_TEXCOORD Offset;

        // Token: 0x04004B15 RID: 19221
        public AppMain.NNS_TEXCOORD Scale;

        // Token: 0x04004B16 RID: 19222
        public int WrapS;

        // Token: 0x04004B17 RID: 19223
        public int WrapT;

        // Token: 0x04004B18 RID: 19224
        public AppMain.NNS_TEXTURE_FILTERMODE pFilterMode;

        // Token: 0x04004B19 RID: 19225
        public float LODBias;

        // Token: 0x04004B1A RID: 19226
        public object pTexInfo;
    }

    // Token: 0x020000B2 RID: 178
    public class NNS_MATERIAL_GLES11_DESC
    {
        // Token: 0x06001ED4 RID: 7892 RVA: 0x0013C4CC File Offset: 0x0013A6CC
        public static AppMain.NNS_MATERIAL_GLES11_DESC Read( BinaryReader reader, long data0Pos, out bool transparentMaterial )
        {
            transparentMaterial = false;
            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = new AppMain.NNS_MATERIAL_GLES11_DESC();
            nns_MATERIAL_GLES11_DESC.fFlag = reader.ReadUInt32();
            nns_MATERIAL_GLES11_DESC.User = reader.ReadUInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                nns_MATERIAL_GLES11_DESC.pColor = AppMain.NNS_MATERIAL_STDSHADER_COLOR.Read( reader );
                reader.BaseStream.Seek( position, 0 );
                transparentMaterial = ( 1f != nns_MATERIAL_GLES11_DESC.pColor.Diffuse.a );
            }
            uint num2 = reader.ReadUInt32();
            if ( num2 != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num2 ), 0 );
                nns_MATERIAL_GLES11_DESC.pLogic = AppMain.NNS_MATERIAL_GLES11_LOGIC.Read( reader );
                reader.BaseStream.Seek( position, 0 );
            }
            nns_MATERIAL_GLES11_DESC.nTex = reader.ReadInt32();
            uint num3 = reader.ReadUInt32();
            if ( num3 != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num3 ), 0 );
                nns_MATERIAL_GLES11_DESC.pTexDesc = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[nns_MATERIAL_GLES11_DESC.nTex];
                for ( int i = 0; i < nns_MATERIAL_GLES11_DESC.nTex; i++ )
                {
                    nns_MATERIAL_GLES11_DESC.pTexDesc[i] = AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC.Read( reader, data0Pos );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_MATERIAL_GLES11_DESC;
        }

        // Token: 0x06001ED5 RID: 7893 RVA: 0x0013C61C File Offset: 0x0013A81C
        public NNS_MATERIAL_GLES11_DESC()
        {
        }

        // Token: 0x06001ED6 RID: 7894 RVA: 0x0013C624 File Offset: 0x0013A824
        public NNS_MATERIAL_GLES11_DESC( AppMain.NNS_MATERIAL_GLES11_DESC desc )
        {
            this.fFlag = desc.fFlag;
            this.User = desc.User;
            this.pColor = desc.pColor;
            this.pLogic = desc.pLogic;
            this.nTex = desc.nTex;
            this.pTexDesc = desc.pTexDesc;
        }

        // Token: 0x06001ED7 RID: 7895 RVA: 0x0013C680 File Offset: 0x0013A880
        public AppMain.NNS_MATERIAL_GLES11_DESC Assign( AppMain.NNS_MATERIAL_GLES11_DESC desc )
        {
            this.fFlag = desc.fFlag;
            this.User = desc.User;
            this.pColor = desc.pColor;
            this.pLogic = desc.pLogic;
            this.nTex = desc.nTex;
            this.pTexDesc = desc.pTexDesc;
            return this;
        }

        // Token: 0x04004B1B RID: 19227
        public uint fFlag;

        // Token: 0x04004B1C RID: 19228
        public uint User;

        // Token: 0x04004B1D RID: 19229
        public AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor;

        // Token: 0x04004B1E RID: 19230
        public AppMain.NNS_MATERIAL_GLES11_LOGIC pLogic;

        // Token: 0x04004B1F RID: 19231
        public int nTex;

        // Token: 0x04004B20 RID: 19232
        public AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] pTexDesc;
    }
}
