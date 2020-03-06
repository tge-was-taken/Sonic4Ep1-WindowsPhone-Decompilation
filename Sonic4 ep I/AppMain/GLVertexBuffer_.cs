using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Runtime.InteropServices;

public partial class AppMain
{
    // Token: 0x020001E1 RID: 481
    public class GLVertexBuffer_ : OpenGL.GLVertexData
    {
        // Token: 0x060022EC RID: 8940 RVA: 0x00147414 File Offset: 0x00145614
        public GLVertexBuffer_( AppMain.NNS_VTXLIST_GL_DESC pVtxDesc )
        {
            this.pVtxDesc_ = pVtxDesc;
            this.elementTypes_ = new OpenGL.GLVertexElementType[this.pVtxDesc_.nArray];
            for ( int i = 0; i < this.pVtxDesc_.nArray; i++ )
            {
                uint type = this.pVtxDesc_.pArray[i].Type;
                if ( type <= 8U )
                {
                    switch ( type )
                    {
                        case 1U:
                            this.posArray_ = this.pVtxDesc_.pArray[i];
                            this.elementTypes_[i] = OpenGL.GLVertexElementType.Position;
                            break;
                        case 2U:
                            this.blWeightArray_ = this.pVtxDesc_.pArray[i];
                            this.elementTypes_[i] = OpenGL.GLVertexElementType.BlendWeight;
                            break;
                        case 3U:
                            break;
                        case 4U:
                            this.blIndexArray_ = this.pVtxDesc_.pArray[i];
                            this.elementTypes_[i] = OpenGL.GLVertexElementType.BlendIndex;
                            break;
                        default:
                            if ( type == 8U )
                            {
                                this.normArray_ = this.pVtxDesc_.pArray[i];
                                this.elementTypes_[i] = OpenGL.GLVertexElementType.Normal;
                            }
                            break;
                    }
                }
                else if ( type != 16U )
                {
                    if ( type != 256U )
                    {
                        if ( type == 512U )
                        {
                            this.texCoord1Array_ = this.pVtxDesc_.pArray[i];
                            this.elementTypes_[i] = OpenGL.GLVertexElementType.TextureCoordinate1;
                        }
                    }
                    else
                    {
                        this.texCoord0Array_ = this.pVtxDesc_.pArray[i];
                        this.elementTypes_[i] = OpenGL.GLVertexElementType.TextureCoordinate0;
                    }
                }
                else
                {
                    this.colArray_ = this.pVtxDesc_.pArray[i];
                    this.elementTypes_[i] = OpenGL.GLVertexElementType.Color;
                }
            }
        }

        // Token: 0x170000A8 RID: 168
        // (get) Token: 0x060022ED RID: 8941 RVA: 0x0014758B File Offset: 0x0014578B
        public OpenGL.GLVertexElementType[] DataComponents
        {
            get
            {
                return this.elementTypes_;
            }
        }

        // Token: 0x170000A9 RID: 169
        // (get) Token: 0x060022EE RID: 8942 RVA: 0x00147593 File Offset: 0x00145793
        public int VertexCount
        {
            get
            {
                return this.pVtxDesc_.nVertex;
            }
        }

        // Token: 0x060022EF RID: 8943 RVA: 0x001475A0 File Offset: 0x001457A0
        public void ExtractTo( OpenGL.Vertex[] dst, int count )
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            for ( int i = 0; i < count; i++ )
            {
                float @float = this.posArray_.Pointer.GetFloat(num);
                float y = this.posArray_.Pointer.GetFloat(num + 4);
                float z = this.posArray_.Pointer.GetFloat(num + 8);
                dst[i].Position = new Vector3( @float, y, z );
                num += this.posArray_.Stride;
                if ( this.normArray_ != null )
                {
                    @float = this.normArray_.Pointer.GetFloat( num2 );
                    y = this.normArray_.Pointer.GetFloat( num2 + 4 );
                    z = this.normArray_.Pointer.GetFloat( num2 + 8 );
                    dst[i].Normal = new Vector3( @float, y, z );
                    num2 += this.normArray_.Stride;
                }
                if ( this.colArray_ != null )
                {
                    byte r = this.colArray_.Pointer[num3];
                    byte g = this.colArray_.Pointer[num3 + 1];
                    byte b = this.colArray_.Pointer[num3 + 2];
                    byte a = this.colArray_.Pointer[num3 + 3];
                    dst[i].Color = new Color( ( int )r, ( int )g, ( int )b, ( int )a );
                    num3 += this.colArray_.Stride;
                }
                else
                {
                    dst[i].Color = Color.White;
                }
                if ( this.texCoord0Array_ != null )
                {
                    @float = this.texCoord0Array_.Pointer.GetFloat( num4 );
                    y = this.texCoord0Array_.Pointer.GetFloat( num4 + 4 );
                    dst[i].TextureCoordinate = new Vector2( @float, y );
                    num4 += this.texCoord0Array_.Stride;
                }
                if ( this.texCoord1Array_ != null )
                {
                    @float = this.texCoord1Array_.Pointer.GetFloat( num5 );
                    y = this.texCoord1Array_.Pointer.GetFloat( num5 + 4 );
                    dst[i].TextureCoordinate2 = new Vector2( @float, y );
                    num5 += this.texCoord1Array_.Stride;
                }
                else
                {
                    dst[i].TextureCoordinate2 = Vector2.Zero;
                }
                if ( this.blWeightArray_ != null )
                {
                    @float = this.blWeightArray_.Pointer.GetFloat( num6 );
                    y = ( ( this.blWeightArray_.Size > 1 ) ? this.blWeightArray_.Pointer.GetFloat( num6 + 4 ) : 0f );
                    z = ( ( this.blWeightArray_.Size > 2 ) ? this.blWeightArray_.Pointer.GetFloat( num6 + 8 ) : 0f );
                    float w = (this.blWeightArray_.Size > 3) ? this.blWeightArray_.Pointer.GetFloat(num6 + 12) : 0f;
                    dst[i].BlendWeight = new Vector4( @float, y, z, w );
                    num6 += this.blWeightArray_.Stride;
                }
                else
                {
                    dst[i].BlendWeight = Vector4.UnitX;
                }
                if ( this.blIndexArray_ != null )
                {
                    byte b2 = this.blIndexArray_.Pointer[num7];
                    byte b3 = (byte)((this.blIndexArray_.Size > 1) ? this.blIndexArray_.Pointer[num7 + 1] : 0);
                    byte b4 = (byte)((this.blIndexArray_.Size > 2) ? this.blIndexArray_.Pointer[num7 + 2] : 0);
                    byte b5 = (byte)((this.blIndexArray_.Size > 3) ? this.blIndexArray_.Pointer[num7 + 3] : 0);
                    dst[i].BlendIndices = new Byte4( ( float )b2, ( float )b3, ( float )b4, ( float )b5 );
                    num7 += this.blIndexArray_.Stride;
                }
                else
                {
                    dst[i].BlendIndices = default( Byte4 );
                }
            }
        }

        // Token: 0x060022F0 RID: 8944 RVA: 0x001479B1 File Offset: 0x00145BB1
        public void ExtractTo( OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count )
        {
            throw new NotImplementedException();
        }

        // Token: 0x040054A3 RID: 21667
        private OpenGL.GLVertexElementType[] elementTypes_;

        // Token: 0x040054A4 RID: 21668
        private AppMain.NNS_VTXARRAY_GL posArray_;

        // Token: 0x040054A5 RID: 21669
        private AppMain.NNS_VTXARRAY_GL normArray_;

        // Token: 0x040054A6 RID: 21670
        private AppMain.NNS_VTXARRAY_GL colArray_;

        // Token: 0x040054A7 RID: 21671
        private AppMain.NNS_VTXARRAY_GL texCoord0Array_;

        // Token: 0x040054A8 RID: 21672
        private AppMain.NNS_VTXARRAY_GL texCoord1Array_;

        // Token: 0x040054A9 RID: 21673
        private AppMain.NNS_VTXARRAY_GL blWeightArray_;

        // Token: 0x040054AA RID: 21674
        private AppMain.NNS_VTXARRAY_GL blIndexArray_;

        // Token: 0x040054AB RID: 21675
        private AppMain.NNS_VTXLIST_GL_DESC pVtxDesc_;
    }
}