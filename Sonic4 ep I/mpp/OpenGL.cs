using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace mpp
{
	// Token: 0x020001D0 RID: 464
	public sealed class OpenGL
	{
		// Token: 0x0600224D RID: 8781 RVA: 0x00142570 File Offset: 0x00140770
		public static void glActiveTexture(uint texture)
		{
			switch (texture)
			{
			case 33984U:
			case 33985U:
				OpenGL.m_activeTextureUnit = texture - 33984U;
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x001425A8 File Offset: 0x001407A8
		public static void glAlphaFunc(uint func, float _ref)
		{
			switch (func)
			{
			case 512U:
				OpenGL.m_alphaFunction = CompareFunction.Never;
				break;
			case 513U:
				OpenGL.m_alphaFunction = CompareFunction.Less;
				break;
			case 514U:
				OpenGL.m_alphaFunction = CompareFunction.Equal;
				break;
			case 515U:
				OpenGL.m_alphaFunction = CompareFunction.LessEqual;
				break;
			case 516U:
				OpenGL.m_alphaFunction = CompareFunction.Greater;
				break;
			case 517U:
				OpenGL.m_alphaFunction = CompareFunction.NotEqual;
				break;
			case 518U:
				OpenGL.m_alphaFunction = CompareFunction.GreaterEqual;
				break;
			case 519U:
				OpenGL.m_alphaFunction = CompareFunction.Always;
				break;
			default:
				throw new ArgumentException();
			}
			_ref = OpenGL.Clamp(_ref, 0f, 1f);
			OpenGL.m_alphaRef = (int)(255f * _ref);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x0014264A File Offset: 0x0014084A
		public static void glArrayElement(int i)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x00142651 File Offset: 0x00140851
		public static void glBegin(uint mode)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x00142658 File Offset: 0x00140858
		public static void glBindBuffer(uint target, uint buffer)
		{
			switch (target)
			{
			case 34962U:
				OpenGL.m_boundArrayBuffer = buffer;
				return;
			case 34963U:
				OpenGL.m_boundElementArrayBuffer = buffer;
				return;
			default:
				throw new ArgumentException();
			}
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x00142690 File Offset: 0x00140890
		public static void glBindTexture(uint target, uint texture)
		{
			OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].BoundTexture = texture;
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001426A4 File Offset: 0x001408A4
		public static void glBlendEquation(uint mode)
		{
			BlendFunction blendFunction;
			BlendFunction blendFunction2;
			if (mode != 32774U)
			{
				if (mode != 32779U)
				{
					throw new NotImplementedException();
				}
				blendFunction = BlendFunction.ReverseSubtract;
				blendFunction2 = BlendFunction.ReverseSubtract;
			}
			else
			{
				blendFunction = BlendFunction.Add;
				blendFunction2 = BlendFunction.Add;
			}
			long num = OpenGL.CalcBlendStateId(OpenGL.m_blendState.ColorSourceBlend, OpenGL.m_blendState.AlphaSourceBlend, OpenGL.m_blendState.ColorDestinationBlend, OpenGL.m_blendState.AlphaDestinationBlend, OpenGL.m_blendState.ColorWriteChannels, blendFunction, blendFunction2);
			BlendState blendState;
			if (!OpenGL.m_blendStates.TryGetValue(num, out blendState ))
			{
				blendState = OpenGL.m_blendState.clone();
				blendState.ColorBlendFunction = blendFunction;
				blendState.AlphaBlendFunction = blendFunction2;
				OpenGL.m_blendStates[num] = blendState;
			}
			OpenGL.m_blendState = blendState;
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x00142750 File Offset: 0x00140950
		public static void glBlendFunc(uint sfactor, uint dfactor)
		{
			Blend blend;
			Blend blend2;
			if (sfactor != 1U)
			{
				if (sfactor != 770U)
				{
					throw new NotImplementedException();
				}
				blend = Blend.SourceAlpha;
				blend2 = Blend.SourceAlpha;
			}
			else
			{
				blend = Blend.One;
				blend2 = Blend.One;
			}
			Blend blend3;
			Blend blend4;
			if (dfactor != 1U)
			{
				if (dfactor != 771U)
				{
					throw new NotImplementedException();
				}
				blend3 = Blend.InverseSourceAlpha;
				blend4 = Blend.InverseSourceAlpha;
			}
			else
			{
				blend3 = Blend.One;
				blend4 = Blend.One;
			}
			long num = OpenGL.CalcBlendStateId(blend, blend2, blend3, blend4, OpenGL.m_blendState.ColorWriteChannels, OpenGL.m_blendState.ColorBlendFunction, OpenGL.m_blendState.AlphaBlendFunction);
			BlendState blendState;
			if (!OpenGL.m_blendStates.TryGetValue(num, out blendState ))
			{
				blendState = OpenGL.m_blendState.clone();
				blendState.ColorSourceBlend = blend;
				blendState.AlphaSourceBlend = blend2;
				blendState.ColorDestinationBlend = blend3;
				blendState.AlphaDestinationBlend = blend4;
				OpenGL.m_blendStates[num] = blendState;
			}
			OpenGL.m_blendState = blendState;
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x00142820 File Offset: 0x00140A20
		public static void glBufferVertexData(OpenGL.GLVertexData data)
		{
			OpenGL.VertexBufferDesc vertexBufferDesc = new OpenGL.VertexBufferDesc();
			vertexBufferDesc.Components = (OpenGL.GLVertexElementType[])data.DataComponents.Clone();
			OpenGL.Vertex[] array = new OpenGL.Vertex[data.VertexCount];
			for (int i = 0; i < data.VertexCount; i++)
			{
				array[i].Color = Color.White;
				array[i].Normal = Vector3.Backward;
			}
			data.ExtractTo(array, data.VertexCount);
			VertexBuffer vertexBuffer = new VertexBuffer(OpenGL.m_graphicsDevice, OpenGL.Vertex.VertexDeclaration, array.Length, BufferUsage.WriteOnly);
			vertexBuffer.SetData<OpenGL.Vertex>(array);
			OpenGL.VertexBufferDesc vertexBufferDesc2 = (OpenGL.VertexBufferDesc)OpenGL.m_buffers[OpenGL.m_boundArrayBuffer].buffer;
			if (vertexBufferDesc2 != null)
			{
				vertexBufferDesc2.Buffer.Dispose();
			}
			vertexBufferDesc.Buffer = vertexBuffer;
			OpenGL.m_buffers[OpenGL.m_boundArrayBuffer].buffer = vertexBufferDesc;
			OpenGL.m_buffers[OpenGL.m_boundArrayBuffer].rawData = array;
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x0014290C File Offset: 0x00140B0C
		public static void glBufferIndexData(OpenGL.GLIndexBuffer data)
		{
			ushort[] array = new ushort[data.Size];
			data.ExtractTo(array);
			IndexBuffer indexBuffer = new IndexBuffer(OpenGL.m_graphicsDevice, IndexElementSize.SixteenBits, data.Size, BufferUsage.None);
			indexBuffer.SetData<ushort>(array);
			IndexBuffer indexBuffer2 = (IndexBuffer)OpenGL.m_buffers[OpenGL.m_boundElementArrayBuffer].buffer;
			if (indexBuffer2 != null)
			{
				indexBuffer2.Dispose();
			}
			short[] array2 = new short[data.Size];
			Buffer.BlockCopy(array, 0, array2, 0, data.Size * 2);
			OpenGL.m_buffers[OpenGL.m_boundElementArrayBuffer].buffer = indexBuffer;
			OpenGL.m_buffers[OpenGL.m_boundElementArrayBuffer].rawData = array2;
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001429B0 File Offset: 0x00140BB0
		public static void glBufferData(uint target, int size, ByteBuffer data, uint usage)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001429B8 File Offset: 0x00140BB8
		public static void glClear(uint mask)
		{
			OpenGL.flushDrawArrays();
			ClearOptions clearOptions = (ClearOptions)0;
			if ((mask & 16384U) != 0U)
			{
				clearOptions |= ClearOptions.Target;
			}
			if ((mask & 256U) != 0U)
			{
				clearOptions |= ClearOptions.DepthBuffer;
			}
			if (clearOptions == (ClearOptions)0)
			{
				throw new ArgumentException();
			}
			OpenGL.m_graphicsDevice.Clear(clearOptions, OpenGL.m_clearColor, OpenGL.m_clearDepth, 0);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x00142A08 File Offset: 0x00140C08
		public static void glClearColor(float red, float green, float blue, float alpha)
		{
			OpenGL.m_clearColor.R = (byte)(255f * OpenGL.Clamp(red, 0f, 1f));
			OpenGL.m_clearColor.G = (byte)(255f * OpenGL.Clamp(green, 0f, 1f));
			OpenGL.m_clearColor.B = (byte)(255f * OpenGL.Clamp(blue, 0f, 1f));
			OpenGL.m_clearColor.A = (byte)(255f * OpenGL.Clamp(alpha, 0f, 1f));
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x00142A99 File Offset: 0x00140C99
		public static void glClearDepth(double depth)
		{
			OpenGL.m_clearDepth = (float)depth;
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x00142AA2 File Offset: 0x00140CA2
		public static void glClearDepthf(float depth)
		{
			OpenGL.m_clearDepth = OpenGL.Clamp(depth, 0f, 1f);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x00142ABC File Offset: 0x00140CBC
		public static void glClientActiveTexture(uint texture)
		{
			switch (texture)
			{
			case 33984U:
			case 33985U:
				OpenGL.m_clientActiveTextureUnit = texture - 33984U;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x00142AEC File Offset: 0x00140CEC
		public static void glColor3f(float red, float green, float blue)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x00142AF3 File Offset: 0x00140CF3
		public static void glColor3fv(float[] v)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x00142AFC File Offset: 0x00140CFC
		public static void glColor4f(float red, float green, float blue, float alpha)
		{
			OpenGL.m_color.R = (byte)(red * 255f);
			OpenGL.m_color.G = (byte)(green * 255f);
			OpenGL.m_color.B = (byte)(blue * 255f);
			OpenGL.m_color.A = (byte)(alpha * 255f);
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x00142B54 File Offset: 0x00140D54
		public static void glColor4fv(OpenGL.glArray4f v)
		{
			OpenGL.m_color.R = (byte)(255f * v.f0);
			OpenGL.m_color.G = (byte)(255f * v.f1);
			OpenGL.m_color.B = (byte)(255f * v.f2);
			OpenGL.m_color.A = (byte)(255f * v.f3);
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x00142BC4 File Offset: 0x00140DC4
		public static void glColor4fv(float[] v)
		{
			OpenGL.m_color.R = (byte)(255f * v[0]);
			OpenGL.m_color.G = (byte)(255f * v[1]);
			OpenGL.m_color.B = (byte)(255f * v[2]);
			OpenGL.m_color.A = (byte)(255f * v[3]);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x00142C24 File Offset: 0x00140E24
		public static void glColorMask(byte red, byte green, byte blue, byte alpha)
		{
			ColorWriteChannels colorWriteChannels = ColorWriteChannels.None;
			if (red != 0)
			{
				colorWriteChannels |= ColorWriteChannels.Red;
			}
			if (green != 0)
			{
				colorWriteChannels |= ColorWriteChannels.Green;
			}
			if (blue != 0)
			{
				colorWriteChannels |= ColorWriteChannels.Blue;
			}
			if (alpha != 0)
			{
				colorWriteChannels |= ColorWriteChannels.Alpha;
			}
			long num = OpenGL.CalcBlendStateId(OpenGL.m_blendState.ColorSourceBlend, OpenGL.m_blendState.AlphaSourceBlend, OpenGL.m_blendState.ColorDestinationBlend, OpenGL.m_blendState.AlphaDestinationBlend, colorWriteChannels, OpenGL.m_blendState.ColorBlendFunction, OpenGL.m_blendState.AlphaBlendFunction);
			BlendState blendState;
			if (!OpenGL.m_blendStates.TryGetValue(num, out blendState ))
			{
				blendState = OpenGL.m_blendState.clone();
				blendState.ColorWriteChannels = colorWriteChannels;
				OpenGL.m_blendStates[num] = blendState;
			}
			OpenGL.m_blendState = blendState;
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x00142CC5 File Offset: 0x00140EC5
		public static void glColorPointer(int size, uint type, int stride, OpenGL.GLVertexData pointer)
		{
			OpenGL.m_colorArraySize = size;
			OpenGL.m_colorArrayDataType = type;
			OpenGL.m_colorArrayStride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
			OpenGL.m_colorArray = pointer;
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x00142CEC File Offset: 0x00140EEC
		public static void glCullFace(uint mode)
		{
			switch (mode)
			{
			case 1028U:
				OpenGL.m_rasterizerState = ((2305U == OpenGL.m_frontFace) ? OpenGL.m_rasterizerStateCCW : OpenGL.m_rasterizerStateCW);
				break;
			case 1029U:
				OpenGL.m_rasterizerState = ((2305U == OpenGL.m_frontFace) ? OpenGL.m_rasterizerStateCW : OpenGL.m_rasterizerStateCCW);
				break;
			default:
				throw new NotImplementedException();
			}
			OpenGL.m_cullFace = mode;
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x00142D5B File Offset: 0x00140F5B
		public static void glCurrentPaletteMatrixOES(uint matrixpaletteindex)
		{
			if (matrixpaletteindex >= 32U)
			{
				throw new ArgumentException();
			}
			OpenGL.m_currentPaletteMatrixOES = matrixpaletteindex;
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x00142D70 File Offset: 0x00140F70
		public static void glDeleteBuffers(int n, uint[] buffers)
		{
			for (int i = 0; i < n; i++)
			{
				uint num = buffers[i];
				OpenGL.BufferItem bufferItem;
				if (!OpenGL.m_buffers.TryGetValue(num, out bufferItem ))
				{
					throw new ArgumentException();
				}
				if (bufferItem.buffer != null)
				{
					if (bufferItem.buffer is OpenGL.VertexBufferDesc)
					{
						OpenGL.VertexBufferDesc vertexBufferDesc = (OpenGL.VertexBufferDesc)bufferItem.buffer;
						vertexBufferDesc.Buffer.Dispose();
					}
					else
					{
						((IndexBuffer)bufferItem.buffer).Dispose();
					}
				}
				OpenGL.m_buffers.Remove(num);
				num -= 1U;
				uint num2 = num / 32U;
				uint num3 = num & 31U;
				uint num4 = 1U << (int)num3;
				OpenGL.m_usedBufferIDs[(int)((UIntPtr)num2)] &= ~num4;
			}
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x00142E2C File Offset: 0x0014102C
		public static void glDeleteTextures(int n, uint[] textures)
		{
			for (int i = 0; i < n; i++)
			{
				uint num = textures[i];
				Texture2D texture2D;
				if (!OpenGL.m_textures.TryGetValue(num, out texture2D ))
				{
					throw new ArgumentException();
				}
				if (texture2D != null)
				{
					texture2D.Dispose();
				}
				OpenGL.m_textures.Remove(num);
				num -= 1U;
				uint num2 = num / 32U;
				uint num3 = num & 31U;
				uint num4 = 1U << (int)num3;
				OpenGL.m_usedTexIDs[(int)((UIntPtr)num2)] &= ~num4;
			}
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x00142EA8 File Offset: 0x001410A8
		public static void glDepthFunc(uint func)
		{
			CompareFunction depthBufferFunction;
			switch (func)
			{
			case 512U:
				depthBufferFunction = CompareFunction.Never;
				break;
			case 513U:
				depthBufferFunction = CompareFunction.Less;
				break;
			case 514U:
				depthBufferFunction = CompareFunction.Equal;
				break;
			case 515U:
				depthBufferFunction = CompareFunction.LessEqual;
				break;
			case 516U:
				depthBufferFunction = CompareFunction.Greater;
				break;
			case 517U:
				depthBufferFunction = CompareFunction.NotEqual;
				break;
			case 518U:
				depthBufferFunction = CompareFunction.GreaterEqual;
				break;
			case 519U:
				depthBufferFunction = CompareFunction.Always;
				break;
			default:
				throw new ArgumentException();
			}
			int num = OpenGL.CalcDepthStencilStateId(depthBufferFunction, OpenGL.m_depthStencilState.DepthBufferWriteEnable);
			DepthStencilState depthStencilState;
			if (!OpenGL.m_depthStencils.TryGetValue(num, out depthStencilState ))
			{
				depthStencilState = OpenGL.m_depthStencilState.clone();
				depthStencilState.DepthBufferFunction = depthBufferFunction;
				OpenGL.m_depthStencils[num] = depthStencilState;
			}
			OpenGL.m_depthStencilState = depthStencilState;
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x00142F4F File Offset: 0x0014114F
		public static void glDepthMask(byte flag)
		{
			OpenGL.glDepthMask(0 != flag);
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x00142F60 File Offset: 0x00141160
		public static void glDepthMask(bool flag)
		{
			if (OpenGL.m_depthStencilState.DepthBufferWriteEnable == flag)
			{
				return;
			}
			int num = OpenGL.CalcDepthStencilStateId(OpenGL.m_depthStencilState.DepthBufferFunction, flag);
			DepthStencilState depthStencilState;
			if (!OpenGL.m_depthStencils.TryGetValue(num, out depthStencilState))
			{
				depthStencilState = OpenGL.m_depthStencilState.clone();
				depthStencilState.DepthBufferWriteEnable = flag;
				OpenGL.m_depthStencils[num] = depthStencilState;
			}
			OpenGL.m_depthStencilState = depthStencilState;
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x00142FC0 File Offset: 0x001411C0
		public static void glDisable(uint cap)
		{
			if (cap <= 2929U)
			{
				if (cap <= 2896U)
				{
					if (cap == 2884U)
					{
						OpenGL.m_cullFaceEnabled = false;
						return;
					}
					if (cap == 2896U)
					{
						OpenGL.m_lightingEnabled = false;
						return;
					}
				}
				else
				{
					if (cap == 2903U)
					{
						OpenGL.m_colorMaterialEnabled = false;
						return;
					}
					if (cap == 2912U)
					{
						OpenGL.m_fogEnabled = false;
						return;
					}
					if (cap == 2929U)
					{
						OpenGL.m_depthTestEnabled = false;
						return;
					}
				}
			}
			else if (cap <= 3058U)
			{
				if (cap == 3008U)
				{
					OpenGL.m_alphaTestEnabled = false;
					return;
				}
				if (cap == 3042U)
				{
					OpenGL.m_blendEnabled = false;
					return;
				}
				if (cap == 3058U)
				{
					OpenGL.m_colorLogicEnabled = false;
					return;
				}
			}
			else
			{
				if (cap == 3553U)
				{
					OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].Enabled = false;
					return;
				}
				switch (cap)
				{
				case 16384U:
					OpenGL.m_lightUnit[0].Enabled = false;
					return;
				case 16385U:
					OpenGL.m_lightUnit[1].Enabled = false;
					return;
				case 16386U:
					OpenGL.m_lightUnit[2].Enabled = false;
					return;
				case 16387U:
				case 16388U:
				case 16389U:
				case 16390U:
				case 16391U:
					return;
				default:
					if (cap == 34880U)
					{
						OpenGL.m_matrixPalleteOESEnabled = false;
						OpenGL.m_matrixPaletteOESActive = false;
						return;
					}
					break;
				}
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x00143114 File Offset: 0x00141314
		public static void glEnable(uint cap)
		{
			if (cap <= 2929U)
			{
				if (cap <= 2896U)
				{
					if (cap == 2884U)
					{
						OpenGL.m_cullFaceEnabled = true;
						return;
					}
					if (cap == 2896U)
					{
						OpenGL.m_lightingEnabled = true;
						return;
					}
				}
				else
				{
					if (cap == 2903U)
					{
						OpenGL.m_colorMaterialEnabled = true;
						return;
					}
					if (cap == 2912U)
					{
						OpenGL.m_fogEnabled = true;
						return;
					}
					if (cap == 2929U)
					{
						OpenGL.m_depthTestEnabled = true;
						return;
					}
				}
			}
			else if (cap <= 3058U)
			{
				if (cap == 3008U)
				{
					OpenGL.m_alphaTestEnabled = true;
					return;
				}
				if (cap == 3042U)
				{
					OpenGL.m_blendEnabled = true;
					return;
				}
				if (cap == 3058U)
				{
					OpenGL.m_colorLogicEnabled = true;
					return;
				}
			}
			else
			{
				if (cap == 3553U)
				{
					OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].Enabled = true;
					return;
				}
				switch (cap)
				{
				case 16384U:
					OpenGL.m_lightUnit[0].Enabled = true;
					return;
				case 16385U:
					OpenGL.m_lightUnit[1].Enabled = true;
					return;
				case 16386U:
					OpenGL.m_lightUnit[2].Enabled = true;
					return;
				case 16387U:
				case 16388U:
				case 16389U:
				case 16390U:
				case 16391U:
					return;
				default:
					if (cap == 34880U)
					{
						OpenGL.m_matrixPalleteOESEnabled = true;
						return;
					}
					break;
				}
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x0014325C File Offset: 0x0014145C
		public static void glDisableClientState(uint cap)
		{
			if (cap <= 33886U)
			{
				switch (cap)
				{
				case 32884U:
					OpenGL.m_vertexArrayEnabled = false;
					return;
				case 32885U:
					OpenGL.m_normalArrayEnabled = false;
					return;
				case 32886U:
					OpenGL.m_colorArrayEnabled = false;
					return;
				case 32887U:
					break;
				case 32888U:
					OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_clientActiveTextureUnit)].TexCoordArrayEnabled = false;
					return;
				default:
					if (cap == 33886U)
					{
						OpenGL.m_secondaryColorArrayEnabled = false;
						return;
					}
					break;
				}
			}
			else
			{
				if (cap == 34477U)
				{
					OpenGL.m_weightArrayEnabled = false;
					return;
				}
				if (cap == 34884U)
				{
					OpenGL.m_matrixIndexArrayEnabled = false;
					return;
				}
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001432F4 File Offset: 0x001414F4
		public static void glEnableClientState(uint cap)
		{
			if (cap <= 33886U)
			{
				switch (cap)
				{
				case 32884U:
					OpenGL.m_vertexArrayEnabled = true;
					return;
				case 32885U:
					OpenGL.m_normalArrayEnabled = true;
					return;
				case 32886U:
					OpenGL.m_colorArrayEnabled = true;
					return;
				case 32887U:
					break;
				case 32888U:
					OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_clientActiveTextureUnit)].TexCoordArrayEnabled = true;
					return;
				default:
					if (cap == 33886U)
					{
						OpenGL.m_secondaryColorArrayEnabled = true;
						return;
					}
					break;
				}
			}
			else
			{
				if (cap == 34477U)
				{
					OpenGL.m_weightArrayEnabled = true;
					return;
				}
				if (cap == 34884U)
				{
					OpenGL.m_matrixIndexArrayEnabled = true;
					return;
				}
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x0014338C File Offset: 0x0014158C
		private static void storeDrawArraysContext()
		{
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].isPending = true;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].view = Matrix.Identity;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].projection = OpenGL.m_projectionMatrixStack.Peek() * OpenGL.PROJECTION_CORRECTION;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].alphaTestEnabled = OpenGL.m_alphaTestEnabled;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].normalArrayEnabled = OpenGL.m_normalArrayEnabled;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].vertexColorEnabled = OpenGL.m_vertexColorEnabled;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].referenceAlpha = OpenGL.m_alphaRef;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].alphaFunction = OpenGL.m_alphaFunction;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].blendState = (OpenGL.m_blendEnabled ? OpenGL.m_blendState : BlendState.Opaque);
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].depthStencilState = (OpenGL.m_depthTestEnabled ? OpenGL.m_depthStencilState : DepthStencilState.None);
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].rasterizerState = (OpenGL.m_cullFaceEnabled ? OpenGL.m_rasterizerState : OpenGL.m_rasterizerStateCN);
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].samplerState = OpenGL.m_textureUnits[0].SamplerState;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].ambientColor = OpenGL.m_ambientColor;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].diffuseColor = OpenGL.m_diffuseColor;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].diffuseColorAlpha = OpenGL.m_diffuseColorAlpha;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].emissiveColor = OpenGL.m_emissiveColor;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].specularColor = OpenGL.m_specularColor;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].specularPower = OpenGL.m_specularPower;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].fogEnabled = OpenGL.m_fogEnabled;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].fogStart = OpenGL.m_fogStart;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].fogEnd = OpenGL.m_fogEnd;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].fogColor = OpenGL.m_fogColor;
			bool flag = OpenGL.m_textureUnits[0].TexCoordArrayEnabled && OpenGL.m_textureUnits[0].Enabled;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].textureEnabled = flag;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].texture = (flag ? OpenGL.m_textures[OpenGL.m_textureUnits[0].BoundTexture] : null);
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight0Enabled = OpenGL.m_lightUnit[0].Enabled;
			if (OpenGL.m_lightUnit[0].Enabled)
			{
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight0DiffuseColor = OpenGL.m_lightUnit[0].DiffuseColor;
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight0SpecularColor = OpenGL.m_lightUnit[0].SpecularColor;
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight0Direction = OpenGL.m_lightUnit[0].Direction;
			}
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight1Enabled = OpenGL.m_lightUnit[1].Enabled;
			if (OpenGL.m_lightUnit[1].Enabled)
			{
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight1DiffuseColor = OpenGL.m_lightUnit[1].DiffuseColor;
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight1SpecularColor = OpenGL.m_lightUnit[1].SpecularColor;
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight1Direction = OpenGL.m_lightUnit[1].Direction;
			}
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight2Enabled = OpenGL.m_lightUnit[2].Enabled;
			if (OpenGL.m_lightUnit[2].Enabled)
			{
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight2DiffuseColor = OpenGL.m_lightUnit[2].DiffuseColor;
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight2SpecularColor = OpenGL.m_lightUnit[2].SpecularColor;
				OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount].DirLight2Direction = OpenGL.m_lightUnit[2].Direction;
			}
			OpenGL.drawArraysCallsCount++;
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x00143814 File Offset: 0x00141A14
		private static void flushDrawArrays()
		{
			int i = 0;
			int num = OpenGL.drawArraysCallsCount;
			while (OpenGL.drawArraysCallsCount > 0)
			{
				int num2 = 0;
				OpenGL.drawArraysCallsCount--;
				OpenGL.drawArraysCalls[i].isPending = false;
				Array.Copy(OpenGL.pendingVertices, OpenGL.drawArraysCalls[i].vertexArrayOffset, OpenGL.drawArraysVertices, num2, OpenGL.drawArraysCalls[i].vertexCount);
				num2 += OpenGL.drawArraysCalls[i].vertexCount;
				for (int j = i + 1; j < num; j++)
				{
					if (OpenGL.drawArraysCalls[j].isPending)
					{
						if (OpenGL.drawArraysCalls[i].isEqualTo(ref OpenGL.drawArraysCalls[j]))
						{
							OpenGL.drawArraysCallsCount--;
							OpenGL.drawArraysCalls[j].isPending = false;
							Array.Copy(OpenGL.pendingVertices, OpenGL.drawArraysCalls[j].vertexArrayOffset, OpenGL.drawArraysVertices, num2, OpenGL.drawArraysCalls[j].vertexCount);
							num2 += OpenGL.drawArraysCalls[j].vertexCount;
						}
						else if (OpenGL.drawArraysCalls[i].blendState != OpenGL.drawArraysCalls[j].blendState || OpenGL.drawArraysCalls[i].depthStencilState != OpenGL.drawArraysCalls[j].depthStencilState || OpenGL.drawArraysCalls[j].blendState == BlendState.Opaque)
						{
							break;
						}
					}
				}
				OpenGL.drawPrimitives(OpenGL.drawArraysVertices, PrimitiveType.TriangleList, num2 / 3, ref OpenGL.drawArraysCalls[i]);
				while (i < num)
				{
					if (OpenGL.drawArraysCalls[i].isPending)
					{
						break;
					}
					OpenGL.drawArraysCalls[i].texture = null;
					i++;
				}
				while (num > i && !OpenGL.drawArraysCalls[num - 1].isPending)
				{
					OpenGL.drawArraysCalls[num - 1].texture = null;
					num--;
				}
			}
			OpenGL.pendingVerticesCount = 0;
			OpenGL.drawArraysCallsCount = 0;
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x00143A24 File Offset: 0x00141C24
		public static void glDrawArrays(uint mode, int first, int count)
		{
			if (!OpenGL.m_vertexArrayEnabled)
			{
				return;
			}
			int num = count;
			PrimitiveType primitiveType;
			int primitiveCount;
			switch (mode)
			{
			case 4U:
				primitiveType = PrimitiveType.TriangleList;
				primitiveCount = count / 3;
				break;
			case 5U:
				primitiveType = PrimitiveType.TriangleStrip;
				primitiveCount = count - 2;
				num = (count - 2) * 3;
				break;
			default:
				throw new NotImplementedException();
			}
			if (primitiveType == PrimitiveType.TriangleStrip || count > 64)
			{
				OpenGL.flushDrawArrays();
				bool twoPasses;
				OpenGL.initVertices(count, out twoPasses);
				OpenGL.verticesToDraw_ = count;
				OpenGL.drawPrimitives(primitiveType, primitiveCount, false, twoPasses);
				return;
			}
			OpenGL.prevPrimType = primitiveType;
			if (OpenGL.drawArraysCallsCount >= OpenGL.drawArraysCalls.Length)
			{
				OpenGL.flushDrawArrays();
			}
			if (OpenGL.pendingVertices.Length < OpenGL.pendingVerticesCount + num)
			{
				OpenGL.pendingVertices = new OpenGL.VertexPosTexColNorm[OpenGL.pendingVertices.Length * 2];
			}
			OpenGL._glDrawArrays_PrepareVertices(primitiveType, OpenGL.pendingVertices, OpenGL.pendingVerticesCount, count);
			OpenGL.storeDrawArraysContext();
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount - 1].vertexArrayOffset = OpenGL.pendingVerticesCount;
			OpenGL.drawArraysCalls[OpenGL.drawArraysCallsCount - 1].vertexCount = num;
			OpenGL.pendingVerticesCount += num;
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x00143B24 File Offset: 0x00141D24
		public static void glDrawElements(uint mode, int count, uint type, ushort[] indices)
		{
			if (!OpenGL.m_vertexArrayEnabled)
			{
				return;
			}
			if (5123U != type)
			{
				throw new ArgumentException();
			}
			PrimitiveType primitiveType;
			int primitiveCount;
			switch (mode)
			{
			case 4U:
				primitiveType = PrimitiveType.TriangleList;
				primitiveCount = count / 3;
				break;
			case 5U:
				primitiveType = PrimitiveType.TriangleStrip;
				primitiveCount = count - 2;
				break;
			default:
				throw new NotImplementedException();
			}
			OpenGL.BufferItem bufferItem = OpenGL.m_buffers[OpenGL.m_boundArrayBuffer];
			OpenGL.VertexBufferDesc vertexBufferDesc = (OpenGL.VertexBufferDesc)bufferItem.buffer;
			if (Array.IndexOf<OpenGL.GLVertexElementType>(vertexBufferDesc.Components, OpenGL.GLVertexElementType.Normal) < 0)
			{
				OpenGL.m_ambientColor = new Vector3(1f, 1f, 1f);
			}
			VertexBuffer buffer = vertexBufferDesc.Buffer;
			OpenGL.BufferItem ibi = OpenGL.m_buffers[OpenGL.m_boundElementArrayBuffer];
			bool flag = true;
			if ((OpenGL.m_textureUnits[0].TexCoordArrayEnabled && OpenGL.m_textureUnits[0].Enabled) || vertexBufferDesc.vertices == null)
			{
				Matrix matrix = OpenGL.m_textureUnits[0].MatrixStack.Peek();
				Matrix matrix2 = OpenGL.m_textureUnits[1].MatrixStack.Peek();
				bool flag2 = !vertexBufferDesc.TextureMatrix.Equals(matrix);
				if (!vertexBufferDesc.Texture2Matrix.Equals(matrix2))
				{
					bool enabled = OpenGL.m_textureUnits[1].Enabled;
				}
				if (flag2 || vertexBufferDesc.vertices == null)
				{
					flag = (OpenGL.m_matrixPalleteOESEnabled || count > 32);
					if (vertexBufferDesc.vertices == null)
					{
						vertexBufferDesc.vertices = new OpenGL.Vertex[buffer.VertexCount];
						flag = true;
					}
					OpenGL.Vertex[] array = (OpenGL.Vertex[])bufferItem.rawData;
					Array.Copy(array, vertexBufferDesc.vertices, buffer.VertexCount);
					for (int i = 0; i < vertexBufferDesc.vertices.Length; i++)
					{
						if (flag2)
						{
							Vector2.Transform(ref vertexBufferDesc.vertices[i].TextureCoordinate, ref matrix, out vertexBufferDesc.vertices[i].TextureCoordinate);
						}
					}
					if (flag)
					{
						buffer.SetData<OpenGL.Vertex>(vertexBufferDesc.vertices);
					}
					else
					{
						vertexBufferDesc.needSetBufferData = true;
					}
					vertexBufferDesc.TextureMatrix = matrix;
					vertexBufferDesc.Texture2Matrix = matrix2;
				}
			}
			OpenGL.flushDrawArrays();
			if (!flag)
			{
				int j = 0;
				int num = OpenGL.pendingVerticesCount;
				ushort[] array2 = (ushort[])OpenGL.m_buffers[OpenGL.m_boundElementArrayBuffer].rawData;
				while (j < count)
				{
					OpenGL.m_vertices[0][j].Position = vertexBufferDesc.vertices[(int)array2[j]].Position;
					OpenGL.m_vertices[0][j].Color = vertexBufferDesc.vertices[(int)array2[j]].Color;
					OpenGL.m_vertices[0][j].Normal = vertexBufferDesc.vertices[(int)array2[j]].Normal;
					OpenGL.m_vertices[0][j].TextureCoordinate = vertexBufferDesc.vertices[(int)array2[j]].TextureCoordinate;
					j++;
				}
				OpenGL.verticesToDraw_ = count;
				OpenGL.drawPrimitives(primitiveType, primitiveCount, false, false);
				return;
			}
			if (OpenGL.m_matrixPalleteOESEnabled && OpenGL.m_alphaTestEnabled && count <= 32)
			{
				flag = false;
			}
			if (flag && vertexBufferDesc.needSetBufferData)
			{
				buffer.SetData<OpenGL.Vertex>(vertexBufferDesc.vertices);
				vertexBufferDesc.needSetBufferData = false;
			}
			OpenGL.drawVertexBuffer(primitiveType, primitiveCount, bufferItem, ibi, flag);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x00143E54 File Offset: 0x00142054
		private static void setupEffect(SkinnedEffect effect)
		{
			effect.DiffuseColor = OpenGL.m_diffuseColor;
			effect.Alpha = OpenGL.m_diffuseColorAlpha;
			effect.EmissiveColor = OpenGL.m_emissiveColor;
			effect.SpecularColor = OpenGL.m_specularColor;
			effect.SpecularPower = OpenGL.m_specularPower;
			OpenGL.setupEffect<SkinnedEffect>(effect);
			effect.PreferPerPixelLighting = false;
			effect.Texture = (OpenGL.m_textureUnits[0].Enabled ? OpenGL.m_textures[OpenGL.m_textureUnits[0].BoundTexture] : OpenGL.m_fakeTexture);
			effect.SetBoneTransforms(OpenGL.m_matrixPalleteOES);
			if (OpenGL.m_normalArrayEnabled)
			{
				return;
			}
			OpenGL.m_skinnedEffect.DirectionalLight0.Enabled = false;
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x00143EFC File Offset: 0x001420FC
		private static void setupEffect(BasicEffect effect)
		{
			effect.VertexColorEnabled = (OpenGL.m_vertexColorEnabled || OpenGL.m_colorArrayEnabled);
			effect.DiffuseColor = OpenGL.m_diffuseColor;
			effect.Alpha = OpenGL.m_diffuseColorAlpha;
			effect.EmissiveColor = OpenGL.m_emissiveColor;
			effect.SpecularColor = OpenGL.m_specularColor;
			effect.SpecularPower = OpenGL.m_specularPower;
			effect.PreferPerPixelLighting = false;
			effect.TextureEnabled = (OpenGL.m_textureUnits[0].TexCoordArrayEnabled && OpenGL.m_textureUnits[0].Enabled);
			effect.Texture = (effect.TextureEnabled ? OpenGL.m_textures[OpenGL.m_textureUnits[0].BoundTexture] : OpenGL.m_fakeTexture);
			if (!OpenGL.m_normalArrayEnabled)
			{
				effect.LightingEnabled = false;
			}
			OpenGL.setupEffect<BasicEffect>(effect);
		}

		// Token: 0x06002275 RID: 8821 RVA: 0x00143FC0 File Offset: 0x001421C0
		private static void setupEffect(AlphaTestEffect effect)
		{
			effect.VertexColorEnabled = (OpenGL.m_vertexColorEnabled || OpenGL.m_colorArrayEnabled);
			effect.DiffuseColor = OpenGL.m_diffuseColor;
			effect.Alpha = OpenGL.m_diffuseColorAlpha;
			effect.Texture = ((OpenGL.m_textureUnits[0].TexCoordArrayEnabled && OpenGL.m_textureUnits[0].Enabled) ? OpenGL.m_textures[OpenGL.m_textureUnits[0].BoundTexture] : OpenGL.m_fakeTexture);
			effect.AlphaFunction = OpenGL.m_alphaFunction;
			effect.ReferenceAlpha = OpenGL.m_alphaRef;
			effect.View = OpenGL.m_modelViewMatrixStack.Peek();
			effect.Projection = OpenGL.m_projectionMatrixStack.Peek() * OpenGL.PROJECTION_CORRECTION;
			effect.FogEnabled = (OpenGL.m_fogEnabled && 9729 == OpenGL.m_fogMode);
			effect.FogColor = OpenGL.m_fogColor;
			effect.FogStart = OpenGL.m_fogStart;
			effect.FogEnd = OpenGL.m_fogEnd;
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x001440BC File Offset: 0x001422BC
		private static void setupEffect(BasicEffect effect, ref OpenGL.DrawArraysCallContext callContext)
		{
			effect.VertexColorEnabled = callContext.vertexColorEnabled;
			effect.DiffuseColor = callContext.diffuseColor;
			effect.Alpha = callContext.diffuseColorAlpha;
			effect.EmissiveColor = callContext.emissiveColor;
			effect.SpecularColor = callContext.specularColor;
			effect.SpecularPower = callContext.specularPower;
			effect.PreferPerPixelLighting = false;
			effect.TextureEnabled = (callContext.texture != null);
			effect.Texture = callContext.texture;
			if (!callContext.normalArrayEnabled)
			{
				effect.LightingEnabled = false;
			}
			OpenGL.setupEffect<BasicEffect>(effect, ref callContext);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x0014414C File Offset: 0x0014234C
		private static void setupEffect(AlphaTestEffect effect, ref OpenGL.DrawArraysCallContext callContext)
		{
			effect.VertexColorEnabled = callContext.vertexColorEnabled;
			effect.DiffuseColor = callContext.diffuseColor;
			effect.Alpha = callContext.diffuseColorAlpha;
			effect.Texture = (callContext.textureEnabled ? callContext.texture : OpenGL.m_fakeTexture);
			effect.AlphaFunction = callContext.alphaFunction;
			effect.ReferenceAlpha = callContext.referenceAlpha;
			effect.View = callContext.view;
			effect.Projection = callContext.projection;
			effect.FogEnabled = callContext.fogEnabled;
			effect.FogColor = callContext.fogColor;
			effect.FogStart = callContext.fogStart;
			effect.FogEnd = callContext.fogEnd;
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x001441F8 File Offset: 0x001423F8
		private static void setupEffect<TEffect>(TEffect effect) where TEffect : Effect, IEffectMatrices, IEffectLights, IEffectFog
		{
			effect.View = OpenGL.m_modelViewMatrixStack.Peek();
			effect.Projection = OpenGL.m_projectionMatrixStack.Peek() * OpenGL.PROJECTION_CORRECTION;
			effect.FogEnabled = (OpenGL.m_fogEnabled && 9729 == OpenGL.m_fogMode);
			effect.FogColor = OpenGL.m_fogColor;
			effect.FogStart = OpenGL.m_fogStart;
			effect.FogEnd = OpenGL.m_fogEnd;
			effect.AmbientLightColor = OpenGL.m_ambientColor;
			effect.LightingEnabled |= OpenGL.m_lightingEnabled;
			effect.DirectionalLight0.Enabled = OpenGL.m_lightUnit[0].Enabled;
			effect.DirectionalLight0.DiffuseColor = OpenGL.m_lightUnit[0].DiffuseColor;
			effect.DirectionalLight0.SpecularColor = OpenGL.m_lightUnit[0].SpecularColor;
			effect.DirectionalLight0.Direction = OpenGL.m_lightUnit[0].Direction;
			effect.DirectionalLight1.Enabled = OpenGL.m_lightUnit[1].Enabled;
			effect.DirectionalLight1.DiffuseColor = OpenGL.m_lightUnit[1].DiffuseColor;
			effect.DirectionalLight1.SpecularColor = OpenGL.m_lightUnit[1].SpecularColor;
			effect.DirectionalLight1.Direction = OpenGL.m_lightUnit[1].Direction;
			effect.DirectionalLight2.Enabled = OpenGL.m_lightUnit[2].Enabled;
			effect.DirectionalLight2.DiffuseColor = OpenGL.m_lightUnit[2].DiffuseColor;
			effect.DirectionalLight2.SpecularColor = OpenGL.m_lightUnit[2].SpecularColor;
			effect.DirectionalLight2.Direction = OpenGL.m_lightUnit[2].Direction;
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x00144430 File Offset: 0x00142630
		private static void setupEffect<TEffect>(TEffect effect, ref OpenGL.DrawArraysCallContext callContext) where TEffect : Effect, IEffectMatrices, IEffectLights, IEffectFog
		{
			effect.Projection = callContext.projection;
			effect.View = callContext.view;
			effect.FogEnabled = callContext.fogEnabled;
			effect.FogColor = callContext.fogColor;
			effect.FogStart = callContext.fogStart;
			effect.FogEnd = callContext.fogEnd;
			effect.AmbientLightColor = callContext.ambientColor;
			effect.DirectionalLight0.Enabled = callContext.DirLight0Enabled;
			if (effect.DirectionalLight0.Enabled)
			{
				effect.DirectionalLight0.DiffuseColor = callContext.DirLight0DiffuseColor;
				effect.DirectionalLight0.SpecularColor = callContext.DirLight0SpecularColor;
				effect.DirectionalLight0.Direction = callContext.DirLight0Direction;
			}
			effect.DirectionalLight1.Enabled = callContext.DirLight1Enabled;
			if (effect.DirectionalLight1.Enabled)
			{
				effect.DirectionalLight1.DiffuseColor = callContext.DirLight1DiffuseColor;
				effect.DirectionalLight1.SpecularColor = callContext.DirLight1SpecularColor;
				effect.DirectionalLight1.Direction = callContext.DirLight1Direction;
			}
			effect.DirectionalLight2.Enabled = callContext.DirLight2Enabled;
			if (effect.DirectionalLight2.Enabled)
			{
				effect.DirectionalLight2.DiffuseColor = callContext.DirLight2DiffuseColor;
				effect.DirectionalLight2.SpecularColor = callContext.DirLight2SpecularColor;
				effect.DirectionalLight2.Direction = callContext.DirLight2Direction;
			}
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x00144620 File Offset: 0x00142820
		private static void skinVertex(Matrix[] bones, ref Vector3 position, ref Vector3 normal, ref Vector4 blendIndices, ref Vector4 blendWeights, out Vector3 outPosition, out Vector3 outNormal)
		{
			int num = (int)blendIndices.X;
			int num2 = (int)blendIndices.Y;
			int num3 = (int)blendIndices.Z;
			int num4 = (int)blendIndices.W;
			Matrix matrix;
			OpenGL.blend4x3Matrix(ref bones[num], ref bones[num2], ref bones[num3], ref bones[num4], ref blendWeights, out matrix);
			Vector3.Transform(ref position, ref matrix, out outPosition);
			Vector3.TransformNormal(ref normal, ref matrix, out outNormal);
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x00144688 File Offset: 0x00142888
		private static void blend4x3Matrix(ref Matrix m1, ref Matrix m2, ref Matrix m3, ref Matrix m4, ref Vector4 weights, out Matrix blended)
		{
			float x = weights.X;
			float y = weights.Y;
			float z = weights.Z;
			float w = weights.W;
			float m5 = m1.M11 * x + m2.M11 * y + m3.M11 * z + m4.M11 * w;
			float m6 = m1.M12 * x + m2.M12 * y + m3.M12 * z + m4.M12 * w;
			float m7 = m1.M13 * x + m2.M13 * y + m3.M13 * z + m4.M13 * w;
			float m8 = m1.M21 * x + m2.M21 * y + m3.M21 * z + m4.M21 * w;
			float m9 = m1.M22 * x + m2.M22 * y + m3.M22 * z + m4.M22 * w;
			float m10 = m1.M23 * x + m2.M23 * y + m3.M23 * z + m4.M23 * w;
			float m11 = m1.M31 * x + m2.M31 * y + m3.M31 * z + m4.M31 * w;
			float m12 = m1.M32 * x + m2.M32 * y + m3.M32 * z + m4.M32 * w;
			float m13 = m1.M33 * x + m2.M33 * y + m3.M33 * z + m4.M33 * w;
			float m14 = m1.M41 * x + m2.M41 * y + m3.M41 * z + m4.M41 * w;
			float m15 = m1.M42 * x + m2.M42 * y + m3.M42 * z + m4.M42 * w;
			float m16 = m1.M43 * x + m2.M43 * y + m3.M43 * z + m4.M43 * w;
			blended = default(Matrix);
			blended.M11 = m5;
			blended.M12 = m6;
			blended.M13 = m7;
			blended.M14 = 0f;
			blended.M21 = m8;
			blended.M22 = m9;
			blended.M23 = m10;
			blended.M24 = 0f;
			blended.M31 = m11;
			blended.M32 = m12;
			blended.M33 = m13;
			blended.M34 = 0f;
			blended.M41 = m14;
			blended.M42 = m15;
			blended.M43 = m16;
			blended.M44 = 1f;
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x00144918 File Offset: 0x00142B18
		private static void drawVertexBuffer(PrimitiveType primitiveType, int primitiveCount, OpenGL.BufferItem vbi, OpenGL.BufferItem ibi, bool useVB)
		{
			OpenGL.VertexBufferDesc vertexBufferDesc = (OpenGL.VertexBufferDesc)vbi.buffer;
			if (OpenGL.m_colorLogicEnabled)
			{
				throw new NotImplementedException();
			}
			if (OpenGL.m_colorMaterialEnabled)
			{
				throw new NotImplementedException();
			}
			BlendState blendState = OpenGL.m_blendEnabled ? OpenGL.m_blendState : BlendState.Opaque;
			if (OpenGL.m_graphicsDevice.BlendState != blendState)
			{
				OpenGL.m_graphicsDevice.BlendState = blendState;
			}
			DepthStencilState depthStencilState = OpenGL.m_depthTestEnabled ? OpenGL.m_depthStencilState : DepthStencilState.None;
			if (OpenGL.m_graphicsDevice.DepthStencilState != depthStencilState)
			{
				OpenGL.m_graphicsDevice.DepthStencilState = depthStencilState;
			}
			RasterizerState rasterizerState = OpenGL.m_cullFaceEnabled ? OpenGL.m_rasterizerState : OpenGL.m_rasterizerStateCN;
			if (OpenGL.m_graphicsDevice.RasterizerState != rasterizerState)
			{
				OpenGL.m_graphicsDevice.RasterizerState = rasterizerState;
			}
			if (OpenGL.m_graphicsDevice.SamplerStates[0] != OpenGL.m_textureUnits[0].SamplerState)
			{
				OpenGL.m_graphicsDevice.SamplerStates[0] = OpenGL.m_textureUnits[0].SamplerState;
			}
			if (!OpenGL.m_viewportSet)
			{
				OpenGL.m_graphicsDevice.Viewport = OpenGL.m_viewport;
				OpenGL.m_viewportSet = true;
			}
			Effect effect = OpenGL.m_basicEffect;
			if (OpenGL.m_matrixPalleteOESEnabled)
			{
				if (useVB)
				{
					OpenGL.setupEffect(OpenGL.m_skinnedEffect);
					OpenGL.m_skinnedEffect.SpecularPower = OpenGL.m_specularPower / 128f;
					OpenGL.m_skinnedEffect.PreferPerPixelLighting = false;
					effect = OpenGL.m_skinnedEffect;
				}
				else
				{
					OpenGL.Vertex[] array = (OpenGL.Vertex[])vbi.rawData;
					if (vertexBufferDesc.vertices == null)
					{
						vertexBufferDesc.vertices = new OpenGL.Vertex[array.Length];
					}
					for (int i = 0; i < array.Length; i++)
					{
						Vector4 vector = array[i].BlendIndices.ToVector4();
						OpenGL.skinVertex(OpenGL.m_matrixPalleteOES, ref array[i].Position, ref array[i].Normal, ref vector, ref array[i].BlendWeight, out vertexBufferDesc.vertices[i].Position, out vertexBufferDesc.vertices[i].Normal);
						vertexBufferDesc.vertices[i].Color = array[i].Color;
					}
				}
			}
			if (!useVB || (useVB && !OpenGL.m_matrixPalleteOESEnabled))
			{
				if (OpenGL.m_alphaTestEnabled)
				{
					OpenGL.setupEffect(OpenGL.m_alphaTestEffect);
					effect = OpenGL.m_alphaTestEffect;
				}
				else
				{
					OpenGL.setupEffect(OpenGL.m_basicEffect);
				}
			}
			if (useVB)
			{
				VertexBuffer buffer = vertexBufferDesc.Buffer;
				effect.GraphicsDevice.SetVertexBuffer(buffer);
				if (ibi != null)
				{
					IndexBuffer indices = (IndexBuffer)ibi.buffer;
					effect.GraphicsDevice.Indices = indices;
				}
				foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
				{
					effectPass.Apply();
					if (ibi != null)
					{
						OpenGL.m_graphicsDevice.DrawIndexedPrimitives(primitiveType, 0, 0, buffer.VertexCount, 0, primitiveCount);
						OpenGL.m_graphicsDevice.Indices = null;
					}
					else
					{
						OpenGL.m_graphicsDevice.DrawPrimitives(primitiveType, 0, primitiveCount);
					}
				}
				OpenGL.m_graphicsDevice.SetVertexBuffer(null);
				return;
			}
			OpenGL.Vertex[] vertices = vertexBufferDesc.vertices;
			foreach (EffectPass effectPass2 in effect.CurrentTechnique.Passes)
			{
				effectPass2.Apply();
				if (ibi != null)
				{
					short[] indexData = (short[])ibi.rawData;
					OpenGL.m_graphicsDevice.DrawUserIndexedPrimitives<OpenGL.Vertex>(primitiveType, vertices, 0, vertices.Length, indexData, 0, primitiveCount);
				}
				else
				{
					OpenGL.m_graphicsDevice.DrawUserPrimitives<OpenGL.Vertex>(primitiveType, vertices, 0, primitiveCount);
				}
			}
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x00144CC4 File Offset: 0x00142EC4
		private static void _glDrawArrays_PrepareVertices(PrimitiveType primitiveType, OpenGL.VertexPosTexColNorm[] dstArray, int dstOffset, int count)
		{
			Matrix matrix = OpenGL.m_textureUnits[0].MatrixStack.Peek();
			OpenGL.m_textureUnits[1].MatrixStack.Peek();
			bool flag = matrix.Equals(Matrix.Identity);
			Matrix matrix2 = OpenGL.m_invScreen * Matrix.Invert(OpenGL.m_projectionMatrixStack.Peek());
			OpenGL.GLVertexData vertexArray = OpenGL.m_vertexArray;
			OpenGL.GLVertexData colorArray = OpenGL.m_colorArray;
			OpenGL.GLVertexData normalArray = OpenGL.m_normalArray;
			OpenGL.texCoordData[0] = OpenGL.m_textureUnits[0].TexCoordArray;
			OpenGL.texCoordData[1] = OpenGL.m_textureUnits[1].TexCoordArray;
			Vector4 vector = Vector4.Transform(OpenGL.posShift, matrix2 * Matrix.Invert(OpenGL.m_modelViewMatrixStack.Peek()));
			OpenGL.VertexPosTexColNorm[] array;
			int num;
			if (primitiveType == PrimitiveType.TriangleStrip)
			{
				array = OpenGL.vtxBuffer;
				num = 0;
			}
			else
			{
				array = dstArray;
				num = dstOffset;
			}
			vertexArray.ExtractTo(array, num, count);
			if (OpenGL.m_normalArrayEnabled)
			{
				normalArray.ExtractTo(array, num, count);
			}
			if (OpenGL.m_colorArrayEnabled)
			{
				colorArray.ExtractTo(array, num, count);
			}
			if (OpenGL.m_textureUnits[0].Enabled && OpenGL.m_textureUnits[0].TexCoordArrayEnabled)
			{
				OpenGL.m_textureUnits[0].TexCoordArray.ExtractTo(array, num, count);
			}
			if (OpenGL.m_textureUnits[1].Enabled && OpenGL.m_textureUnits[1].TexCoordArrayEnabled)
			{
				OpenGL.m_textureUnits[1].TexCoordArray.ExtractTo(array, num, count);
			}
			Matrix matrix3 = OpenGL.m_modelViewMatrixStack.Peek();
			for (int i = 0; i < count; i++)
			{
				int num2 = num + i;
				OpenGL.VertexPosTexColNorm[] array2 = array;
				int num3 = num2;
				array2[num3].Position.X = array2[num3].Position.X + vector.X;
				Vector3.Transform(ref array[num2].Position, ref matrix3, out array[num2].Position);
				Vector3.TransformNormal(ref array[num2].Normal, ref matrix3, out array[num2].Normal);
				Vector2 zero = Vector2.Zero;
				if (OpenGL.m_textureUnits[0].Enabled && OpenGL.m_textureUnits[0].TexCoordArrayEnabled && !flag)
				{
					Vector2.Transform(ref array[num2].TextureCoordinate, ref matrix, out zero);
				}
				array[num2].TextureCoordinate = zero;
			}
			if (primitiveType == PrimitiveType.TriangleStrip)
			{
				dstArray[dstOffset] = array[0];
				dstArray[dstOffset + 1] = array[1];
				dstArray[dstOffset + 2] = array[2];
				int j = 3;
				int num4 = dstOffset + 3;
				bool flag2 = false;
				while (j < count)
				{
					int num5 = j - 1;
					int num6 = j - 2;
					if (flag2)
					{
						int num7 = num5;
						num5 = num6;
						num6 = num7;
					}
					dstArray[num4] = array[num5];
					num4++;
					dstArray[num4] = array[num6];
					num4++;
					dstArray[num4] = array[j];
					num4++;
					j++;
				}
			}
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x00144FF4 File Offset: 0x001431F4
		private static void initVertices(int count, out bool twoPasses)
		{
			twoPasses = false;
			int num = 0;
			num |= (OpenGL.m_textureUnits[0].Enabled ? 1 : 0);
			switch (num | (OpenGL.m_textureUnits[1].Enabled ? 2 : 0))
			{
			case 0:
				twoPasses = false;
				break;
			case 1:
				twoPasses = false;
				break;
			case 2:
				throw new InvalidOperationException();
			case 3:
				twoPasses = true;
				break;
			}
			Matrix matrix = OpenGL.m_textureUnits[0].MatrixStack.Peek();
			OpenGL.m_textureUnits[0].MatrixStack.Peek();
			bool flag = matrix.Equals(Matrix.Identity);
			Matrix matrix2 = OpenGL.m_invScreen * Matrix.Invert(OpenGL.m_projectionMatrixStack.Peek());
			OpenGL.GLVertexData vertexArray = OpenGL.m_vertexArray;
			OpenGL.GLVertexData colorArray = OpenGL.m_colorArray;
			OpenGL.GLVertexData normalArray = OpenGL.m_normalArray;
			OpenGL.texCoordData[0] = OpenGL.m_textureUnits[0].TexCoordArray;
			OpenGL.texCoordData[1] = OpenGL.m_textureUnits[1].TexCoordArray;
			if (OpenGL.m_vertices[0] == null || count > OpenGL.m_vertices[0].Length)
			{
				OpenGL.m_vertices[0] = new OpenGL.VertexPosTexColNorm[count * 2];
			}
			Vector4 vector = Vector4.Transform(OpenGL.posShift, matrix2 * Matrix.Invert(OpenGL.m_modelViewMatrixStack.Peek()));
			vertexArray.ExtractTo(OpenGL.m_vertices[0], 0, count);
			if (OpenGL.m_normalArrayEnabled)
			{
				normalArray.ExtractTo(OpenGL.m_vertices[0], 0, count);
			}
			if (OpenGL.m_colorArrayEnabled)
			{
				colorArray.ExtractTo(OpenGL.m_vertices[0], 0, count);
			}
			if (OpenGL.m_textureUnits[0].Enabled && OpenGL.m_textureUnits[0].TexCoordArrayEnabled)
			{
				OpenGL.texCoordData[0].ExtractTo(OpenGL.m_vertices[0], 0, count);
			}
			for (int i = 0; i < count; i++)
			{
				OpenGL.VertexPosTexColNorm[] array = OpenGL.m_vertices[0];
				int num2 = i;
				array[num2].Position.X = array[num2].Position.X + vector.X;
				Vector2 zero = Vector2.Zero;
				if (OpenGL.m_textureUnits[0].Enabled && OpenGL.m_textureUnits[0].TexCoordArrayEnabled && !flag)
				{
					Vector2.Transform(ref OpenGL.m_vertices[0][i].TextureCoordinate, ref matrix, out zero);
				}
				OpenGL.m_vertices[0][i].TextureCoordinate = zero;
			}
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x0014522C File Offset: 0x0014342C
		private static void drawPrimitives(PrimitiveType primitiveType, int primitiveCount, bool useIndices, bool twoPasses)
		{
			if (OpenGL.m_colorLogicEnabled)
			{
				throw new NotImplementedException();
			}
			if (OpenGL.m_colorMaterialEnabled)
			{
				throw new NotImplementedException();
			}
			BlendState blendState = OpenGL.m_blendEnabled ? OpenGL.m_blendState : BlendState.Opaque;
			if (OpenGL.m_graphicsDevice.BlendState != blendState)
			{
				OpenGL.m_graphicsDevice.BlendState = blendState;
			}
			DepthStencilState depthStencilState = OpenGL.m_depthTestEnabled ? OpenGL.m_depthStencilState : DepthStencilState.None;
			if (OpenGL.m_graphicsDevice.DepthStencilState != depthStencilState)
			{
				OpenGL.m_graphicsDevice.DepthStencilState = depthStencilState;
			}
			RasterizerState rasterizerState = OpenGL.m_cullFaceEnabled ? OpenGL.m_rasterizerState : OpenGL.m_rasterizerStateCN;
			if (OpenGL.m_graphicsDevice.RasterizerState != rasterizerState)
			{
				OpenGL.m_graphicsDevice.RasterizerState = rasterizerState;
			}
			if (OpenGL.m_graphicsDevice.SamplerStates[0] != OpenGL.m_textureUnits[0].SamplerState)
			{
				OpenGL.m_graphicsDevice.SamplerStates[0] = OpenGL.m_textureUnits[0].SamplerState;
			}
			if (!OpenGL.m_viewportSet)
			{
				OpenGL.m_graphicsDevice.Viewport = OpenGL.m_viewport;
				OpenGL.m_viewportSet = true;
			}
			Effect effect = OpenGL.m_basicEffect;
			if (OpenGL.m_alphaTestEnabled)
			{
				OpenGL.setupEffect(OpenGL.m_alphaTestEffect);
				effect = OpenGL.m_alphaTestEffect;
			}
			else
			{
				OpenGL.setupEffect(OpenGL.m_basicEffect);
			}
			foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
			{
				effectPass.Apply();
				if (useIndices)
				{
					OpenGL.m_graphicsDevice.DrawUserIndexedPrimitives<OpenGL.VertexPosTexColNorm>(primitiveType, OpenGL.m_vertices[0], 0, OpenGL.verticesToDraw_, OpenGL.m_indices, 0, primitiveCount);
				}
				else
				{
					OpenGL.m_graphicsDevice.DrawUserPrimitives<OpenGL.VertexPosTexColNorm>(primitiveType, OpenGL.m_vertices[0], 0, primitiveCount);
				}
			}
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x001453DC File Offset: 0x001435DC
		private static void drawPrimitives(OpenGL.VertexPosTexColNorm[] vertices, PrimitiveType primitiveType, int primitiveCount, ref OpenGL.DrawArraysCallContext callContext)
		{
			OpenGL.drawPrimitives_Count++;
			if (callContext.blendState != OpenGL.m_graphicsDevice.BlendState)
			{
				OpenGL.m_graphicsDevice.BlendState = callContext.blendState;
			}
			if (callContext.depthStencilState != OpenGL.m_graphicsDevice.DepthStencilState)
			{
				OpenGL.m_graphicsDevice.DepthStencilState = callContext.depthStencilState;
			}
			if (callContext.rasterizerState != OpenGL.m_graphicsDevice.RasterizerState)
			{
				OpenGL.m_graphicsDevice.RasterizerState = callContext.rasterizerState;
			}
			if (callContext.samplerState != OpenGL.m_graphicsDevice.SamplerStates[0])
			{
				OpenGL.m_graphicsDevice.SamplerStates[0] = callContext.samplerState;
			}
			if (!OpenGL.m_viewportSet)
			{
				OpenGL.m_graphicsDevice.Viewport = OpenGL.m_viewport;
				OpenGL.m_viewportSet = true;
			}
			Effect effect = OpenGL.m_basicEffect;
			if (callContext.alphaTestEnabled)
			{
				OpenGL.setupEffect(OpenGL.m_alphaTestEffect, ref callContext);
				effect = OpenGL.m_alphaTestEffect;
			}
			else
			{
				OpenGL.setupEffect(OpenGL.m_basicEffect, ref callContext);
			}
			foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
			{
				effectPass.Apply();
				OpenGL.m_graphicsDevice.DrawUserPrimitives<OpenGL.VertexPosTexColNorm>(primitiveType, vertices, 0, primitiveCount);
			}
		}

		// Token: 0x06002281 RID: 8833 RVA: 0x0014552C File Offset: 0x0014372C
		public static void glEnd()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x00145533 File Offset: 0x00143733
		public static void glFlush()
		{
			OpenGL.flushDrawArrays();
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x0014553C File Offset: 0x0014373C
		public static void glFogf(uint pname, float param)
		{
			switch (pname)
			{
			case 2914U:
				return;
			case 2915U:
				OpenGL.m_fogStart = param;
				return;
			case 2916U:
				OpenGL.m_fogEnd = param;
				return;
			case 2917U:
				OpenGL.m_fogMode = (ushort)param;
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x00145588 File Offset: 0x00143788
		public static void glFogfv(uint pname, float[] param)
		{
			if (pname == 2918U)
			{
				OpenGL.m_fogColor.X = param[0];
				OpenGL.m_fogColor.Y = param[1];
				OpenGL.m_fogColor.Z = param[2];
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x001455CC File Offset: 0x001437CC
		public static void glFrontFace(uint mode)
		{
			switch (mode)
			{
			case 2304U:
				OpenGL.m_rasterizerState = ((1029U == OpenGL.m_cullFace) ? OpenGL.m_rasterizerStateCCW : OpenGL.m_rasterizerStateCW);
				break;
			case 2305U:
				OpenGL.m_rasterizerState = ((1029U == OpenGL.m_cullFace) ? OpenGL.m_rasterizerStateCW : OpenGL.m_rasterizerStateCCW);
				break;
			default:
				throw new ArgumentException();
			}
			OpenGL.m_frontFace = mode;
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x0014563C File Offset: 0x0014383C
		public static void glGenBuffer(out uint buffer)
		{
			uint num = 0U;
			uint num2 = 0U;
			while (4294967295U == OpenGL.m_usedBufferIDs[(int)((UIntPtr)num2)])
			{
				num2 += 1U;
				if ((ulong)num2 == (ulong)((long)OpenGL.m_usedBufferIDs.Length))
				{
					Array.Resize<uint>(ref OpenGL.m_usedBufferIDs, (int)(num2 + 8U));
				}
			}
			uint num3 = 1U;
			uint num4 = 0U;
			while (num3 != 0U)
			{
				if ((OpenGL.m_usedBufferIDs[(int)((UIntPtr)num2)] & num3) == 0U)
				{
					OpenGL.m_usedBufferIDs[(int)((UIntPtr)num2)] |= num3;
					uint num5 = num2 * 32U + num4 + 1U;
					num = num5;
					OpenGL.m_buffers.Add(num5, new OpenGL.BufferItem());
					break;
				}
				num3 <<= 1;
				num4 += 1U;
			}
			buffer = num;
		}

		// Token: 0x06002287 RID: 8839 RVA: 0x001456D0 File Offset: 0x001438D0
		public static void glGenBuffers(int n, uint[] buffers)
		{
			for (int i = 0; i < n; i++)
			{
				OpenGL.glGenBuffer(out buffers[i]);
			}
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x001456F8 File Offset: 0x001438F8
		public static void glGenTexture(out uint texture)
		{
			uint num = 0U;
			uint num2 = 0U;
			while (4294967295U == OpenGL.m_usedTexIDs[(int)((UIntPtr)num2)])
			{
				num2 += 1U;
				if ((ulong)num2 == (ulong)((long)OpenGL.m_usedTexIDs.Length))
				{
					Array.Resize<uint>(ref OpenGL.m_usedTexIDs, (int)(num2 + 8U));
				}
			}
			uint num3 = 1U;
			uint num4 = 0U;
			while (num3 != 0U)
			{
				if ((OpenGL.m_usedTexIDs[(int)((UIntPtr)num2)] & num3) == 0U)
				{
					OpenGL.m_usedTexIDs[(int)((UIntPtr)num2)] |= num3;
					uint num5 = num2 * 32U + num4 + 1U;
					num = num5;
					OpenGL.m_textures.Add(num5, null);
					break;
				}
				num3 <<= 1;
				num4 += 1U;
			}
			texture = num;
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x00145788 File Offset: 0x00143988
		public static void glGenTextures(int n, uint[] textures)
		{
			for (int i = 0; i < n; i++)
			{
				OpenGL.glGenTexture(out textures[i]);
			}
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001457AD File Offset: 0x001439AD
		public static void glGetFloatv(uint pname, byte[] param)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001457B4 File Offset: 0x001439B4
		public static void glGetInteger(uint pname, out int param)
		{
			if (pname == 34882U)
			{
				param = 32;
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001457D8 File Offset: 0x001439D8
		public static void glGetRenderbufferParameteriOES(uint target, uint pname, out int param)
		{
			if (target != 36161U)
			{
				throw new NotImplementedException();
			}
			switch (pname)
			{
			case 36162U:
				param = OpenGL.m_graphicsDevice.PresentationParameters.BackBufferWidth;
				return;
			case 36163U:
				param = OpenGL.m_graphicsDevice.PresentationParameters.BackBufferHeight;
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x00145836 File Offset: 0x00143A36
		public static string glGetString(uint name)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x0014583D File Offset: 0x00143A3D
		public static void glLightf(uint light, uint pname, float param)
		{
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x00145840 File Offset: 0x00143A40
		public static void glLightfv(uint light, uint pname, ref OpenGL.glArray4f param)
		{
			light -= 16384U;
			switch (pname)
			{
			case 4608U:
			case 4611U:
				return;
			case 4609U:
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].DiffuseColor.X = param.f0;
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].DiffuseColor.Y = param.f1;
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].DiffuseColor.Z = param.f2;
				return;
			case 4610U:
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].SpecularColor.X = param.f0;
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].SpecularColor.Y = param.f1;
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].SpecularColor.Z = param.f2;
				return;
			case 4612U:
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].Direction.X = param.f0;
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].Direction.Y = param.f1;
				OpenGL.m_lightUnit[(int)((UIntPtr)light)].Direction.Z = param.f2;
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x00145960 File Offset: 0x00143B60
		public static void glLightModelf(uint pname, float param)
		{
			if (pname != 2898U)
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x00145980 File Offset: 0x00143B80
		public static void glLightModelfv(uint pname, OpenGL.glArray4f param)
		{
			if (pname == 2899U)
			{
				OpenGL.m_ambientColor.X = param.f0;
				OpenGL.m_ambientColor.Y = param.f0;
				OpenGL.m_ambientColor.Z = param.f0;
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001459D0 File Offset: 0x00143BD0
		public static void glLoadIdentity()
		{
			if (OpenGL.m_matrixPaletteOESActive)
			{
				OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)] = Matrix.Identity;
				return;
			}
			OpenGL.m_activeMatrixStack.Pop();
			OpenGL.m_activeMatrixStack.Push(Matrix.Identity);
		}

		// Token: 0x06002293 RID: 8851 RVA: 0x00145A0E File Offset: 0x00143C0E
		public static void glLoadMatrixf(ref Matrix matrix)
		{
			if (OpenGL.m_matrixPaletteOESActive)
			{
				OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)] = matrix;
				return;
			}
			OpenGL.m_activeMatrixStack.Pop();
			OpenGL.m_activeMatrixStack.Push(matrix);
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x00145A4E File Offset: 0x00143C4E
		public static void glLoadPaletteFromModelViewMatrixOES()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x00145A55 File Offset: 0x00143C55
		public static void glLogicOp(uint opcode)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x00145A5C File Offset: 0x00143C5C
		public static object glMapBuffer(uint target, uint access)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002297 RID: 8855 RVA: 0x00145A63 File Offset: 0x00143C63
		public static void glMaterialf(uint face, uint pname, float param)
		{
			if (1032U != face)
			{
				throw new NotImplementedException();
			}
			if (5633U != pname)
			{
				throw new ArgumentException();
			}
			OpenGL.m_specularPower = param;
		}

		// Token: 0x06002298 RID: 8856 RVA: 0x00145A87 File Offset: 0x00143C87
		public static void glMaterialfv(uint face, uint pname, float[] param)
		{
			OpenGL.glMaterialfv(face, pname, new OpenGL.glArray4f(param[0], param[1], param[2], param[3]));
		}

		// Token: 0x06002299 RID: 8857 RVA: 0x00145AA4 File Offset: 0x00143CA4
		public static void glMaterialfv(uint face, uint pname, OpenGL.glArray4f param)
		{
			if (1032U != face)
			{
				throw new NotImplementedException();
			}
			switch (pname)
			{
			case 4608U:
				OpenGL.m_ambientColor.X = param.f0;
				OpenGL.m_ambientColor.Y = param.f1;
				OpenGL.m_ambientColor.Z = param.f2;
				return;
			case 4609U:
				OpenGL.m_diffuseColor.X = param.f0;
				OpenGL.m_diffuseColor.Y = param.f1;
				OpenGL.m_diffuseColor.Z = param.f2;
				OpenGL.m_diffuseColorAlpha = param.f3;
				return;
			case 4610U:
				OpenGL.m_specularColor.X = param.f0;
				OpenGL.m_specularColor.Y = param.f1;
				OpenGL.m_specularColor.Z = param.f2;
				return;
			default:
				if (pname != 5632U)
				{
					throw new NotImplementedException();
				}
				OpenGL.m_emissiveColor.X = param.f0;
				OpenGL.m_emissiveColor.Y = param.f1;
				OpenGL.m_emissiveColor.Z = param.f2;
				return;
			}
		}

		// Token: 0x0600229A RID: 8858 RVA: 0x00145BCA File Offset: 0x00143DCA
		public static void glMatrixIndexPointerOES(int size, uint type, int stride, OpenGL.GLVertexData data)
		{
			OpenGL.m_matrixIndexArraySize = size;
			OpenGL.m_matrixIndexArrayDataType = type;
			OpenGL.m_matrixIndexArrayStride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
			OpenGL.m_matrixIndexArray = data;
		}

		// Token: 0x0600229B RID: 8859 RVA: 0x00145BF4 File Offset: 0x00143DF4
		public static void glMatrixMode(uint mode)
		{
			OpenGL.m_matrixPaletteOESActive = false;
			switch (mode)
			{
			case 5888U:
				OpenGL.m_activeMatrixStack = OpenGL.m_modelViewMatrixStack;
				return;
			case 5889U:
				OpenGL.m_activeMatrixStack = OpenGL.m_projectionMatrixStack;
				return;
			case 5890U:
				OpenGL.m_activeMatrixStack = OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].MatrixStack;
				return;
			default:
				if (mode == 6144U)
				{
					throw new NotImplementedException();
				}
				if (mode != 34880U)
				{
					throw new ArgumentException();
				}
				OpenGL.m_matrixPaletteOESActive = OpenGL.m_matrixPalleteOESEnabled;
				return;
			}
		}

		// Token: 0x0600229C RID: 8860 RVA: 0x00145C76 File Offset: 0x00143E76
		public static void glMultiTexCoord2fv(uint target, float[] v)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x00145C7D File Offset: 0x00143E7D
		public static void glNormal3fv(float[] v)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600229E RID: 8862 RVA: 0x00145C84 File Offset: 0x00143E84
		public static void glNormalPointer(uint type, int stride, OpenGL.GLVertexData pointer)
		{
			OpenGL.m_normalArrayDataType = type;
			OpenGL.m_normalArrayStride = ((stride == 0) ? (OpenGL.SizeOf(type) * 3) : stride);
			OpenGL.m_normalArray = pointer;
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x00145CA8 File Offset: 0x00143EA8
		public static void glOrtho(float left, float right, float bottom, float top, float nearVal, float farVal)
		{
			Matrix matrix = Matrix.CreateOrthographicOffCenter(left, right, bottom, top, nearVal, farVal);
			if (OpenGL.m_matrixPaletteOESActive)
			{
				OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)] = matrix * OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)];
				return;
			}
			OpenGL.m_activeMatrixStack.Push(matrix * OpenGL.m_activeMatrixStack.Pop());
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x00145D15 File Offset: 0x00143F15
		public static void glPixelStorei(uint pname, int param)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x00145D1C File Offset: 0x00143F1C
		public static void glPolygonMode(uint face, uint mode)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x00145D23 File Offset: 0x00143F23
		public static void glPopMatrix()
		{
			if (OpenGL.m_matrixPaletteOESActive)
			{
				throw new ArgumentException();
			}
			if (1 == OpenGL.m_activeMatrixStack.Count)
			{
				throw new InvalidOperationException();
			}
			OpenGL.m_activeMatrixStack.Pop();
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x00145D50 File Offset: 0x00143F50
		public static void glPushMatrix()
		{
			if (OpenGL.m_matrixPaletteOESActive)
			{
				throw new ArgumentException();
			}
			OpenGL.m_activeMatrixStack.Push(OpenGL.m_activeMatrixStack.Peek());
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x00145D74 File Offset: 0x00143F74
		public static void glScalef(float x, float y, float z)
		{
			Matrix matrix = Matrix.CreateScale(x, y, z);
			if (OpenGL.m_matrixPaletteOESActive)
			{
				OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)] = matrix * OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)];
				return;
			}
			OpenGL.m_activeMatrixStack.Push(matrix * OpenGL.m_activeMatrixStack.Pop());
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x00145DDC File Offset: 0x00143FDC
		public static void glShadeModel(uint mode)
		{
			switch (mode)
			{
			case 7424U:
				OpenGL.m_perPixelLighting = false;
				return;
			case 7425U:
				OpenGL.m_perPixelLighting = true;
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x00145E14 File Offset: 0x00144014
		public static void glTexCoordPointer(int size, uint type, int stride, OpenGL.GLVertexData pointer)
		{
			OpenGL.TextureUnit textureUnit = OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_clientActiveTextureUnit)];
			textureUnit.TexCoordArraySize = size;
			textureUnit.TexCoordArrayDataType = type;
			textureUnit.TexCoordArrayStride = stride;
			textureUnit.TexCoordArray = pointer;
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x00145E4A File Offset: 0x0014404A
		public static void glTexEnvf(uint target, uint pname, float param)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x00145E54 File Offset: 0x00144054
		public static void glTexEnvfv(uint target, uint pname, OpenGL.glArray4f v)
		{
			if (target != 8960U)
			{
				throw new NotImplementedException();
			}
			if (pname != 8705U)
			{
				throw new NotImplementedException();
			}
			OpenGL.m_color.R = (byte)(255f * v.f0);
			OpenGL.m_color.G = (byte)(255f * v.f1);
			OpenGL.m_color.B = (byte)(255f * v.f2);
			OpenGL.m_color.A = (byte)(255f * v.f3);
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x00145EE4 File Offset: 0x001440E4
		public static void glTexEnvi(uint target, uint pname, int param)
		{
			if (target != 8960U)
			{
				throw new NotImplementedException();
			}
			if (pname != 8704U)
			{
				throw new NotImplementedException();
			}
			if (param == 7681)
			{
				OpenGL.m_vertexColorEnabled = false;
				return;
			}
			switch (param)
			{
			case 8448:
				OpenGL.m_vertexColorEnabled = true;
				return;
			case 8449:
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x00145F48 File Offset: 0x00144148
		public static void mppglTexImage2D(Texture2D texture)
		{
			OpenGL.m_textures[OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].BoundTexture] = texture;
			OpenGL.m_textures[OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].BoundTexture].Tag = true;
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x00145F98 File Offset: 0x00144198
		public static void mppglTexImage2D(string textureName)
		{
			using (Stream stream = TitleContainer.OpenStream(Path.Combine("Content", textureName + ".png")))
			{
				OpenGL.m_textures[OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].BoundTexture] = Texture2D.FromStream(OpenGL.m_graphicsDevice, stream);
				OpenGL.m_textures[OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].BoundTexture].Tag = true;
			}
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x00146028 File Offset: 0x00144228
		public static void glTexParameteri(uint target, uint pname, int param)
		{
			if (target != 3553U)
			{
				throw new NotImplementedException();
			}
			TextureAddressMode textureAddressMode = OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].SamplerState.AddressU;
			TextureAddressMode textureAddressMode2 = OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].SamplerState.AddressV;
			switch (pname)
			{
			case 10242U:
				switch (param)
				{
				case 10496:
					break;
				case 10497:
					textureAddressMode = TextureAddressMode.Wrap;
					goto IL_D5;
				default:
					if (param != 33071)
					{
						if (param != 33648)
						{
							throw new NotImplementedException();
						}
						textureAddressMode = TextureAddressMode.Mirror;
						goto IL_D5;
					}
					break;
				}
				textureAddressMode = TextureAddressMode.Clamp;
				break;
			case 10243U:
				switch (param)
				{
				case 10496:
					break;
				case 10497:
					textureAddressMode2 = TextureAddressMode.Wrap;
					goto IL_D5;
				default:
					if (param != 33071)
					{
						if (param != 33648)
						{
							throw new NotImplementedException();
						}
						textureAddressMode2 = TextureAddressMode.Mirror;
						goto IL_D5;
					}
					break;
				}
				textureAddressMode2 = TextureAddressMode.Clamp;
				break;
			default:
				return;
			}
			IL_D5:
			int num = OpenGL.CalcSamplerStateId(textureAddressMode, textureAddressMode2);
			SamplerState samplerState;
			if (!OpenGL.m_samplerStates.TryGetValue(num, out samplerState))
			{
				samplerState = OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].SamplerState.clone();
				samplerState.AddressU = textureAddressMode;
				samplerState.AddressV = textureAddressMode2;
				OpenGL.m_samplerStates[num] = samplerState;
			}
			OpenGL.m_textureUnits[(int)((UIntPtr)OpenGL.m_activeTextureUnit)].SamplerState = samplerState;
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x00146164 File Offset: 0x00144364
		public static void glTranslatef(float x, float y, float z)
		{
			Matrix matrix = Matrix.CreateTranslation(x, y, z);
			if (OpenGL.m_matrixPaletteOESActive)
			{
				OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)] = matrix * OpenGL.m_matrixPalleteOES[(int)((UIntPtr)OpenGL.m_currentPaletteMatrixOES)];
				return;
			}
			OpenGL.m_activeMatrixStack.Push(matrix * OpenGL.m_activeMatrixStack.Pop());
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x001461CC File Offset: 0x001443CC
		public static byte glUnmapBuffer(uint target)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x001461D3 File Offset: 0x001443D3
		public static void glVertex3f(float x, float y, float z)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001461DA File Offset: 0x001443DA
		public static void glVertex3fv(float[] v)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001461E1 File Offset: 0x001443E1
		public static void glVertexAttrib3fvARB(uint index, float[] v)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001461E8 File Offset: 0x001443E8
		public static void glVertexPointer(int size, uint type, int stride, OpenGL.GLVertexData pointer)
		{
			OpenGL.m_vertexArraySize = size;
			OpenGL.m_vertexArrayDataType = type;
			OpenGL.m_vertexArrayStride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
			OpenGL.m_vertexArray = pointer;
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x0014620F File Offset: 0x0014440F
		public static void glViewport(int x, int y, int width, int height)
		{
			OpenGL.m_viewport = new Viewport(x, y, width, height);
			OpenGL.calculateInvScreenMatrix();
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x00146224 File Offset: 0x00144424
		public static void glWeightPointerOES(int size, uint type, int stride, OpenGL.GLVertexData pointer)
		{
			OpenGL.m_weightArraySize = size;
			OpenGL.m_weightArrayDataType = type;
			OpenGL.m_weightArrayStride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
			OpenGL.m_weightArray = pointer;
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x0014624C File Offset: 0x0014444C
		static OpenGL()
		{
			OpenGL.m_modelViewMatrixStack = new Stack<Matrix>();
			OpenGL.m_modelViewMatrixStack.Push(Matrix.Identity);
			OpenGL.m_projectionMatrixStack = new Stack<Matrix>();
			OpenGL.m_projectionMatrixStack.Push(Matrix.Identity);
			OpenGL.m_matrixPalleteOES = new Matrix[32];
			for (int i = 0; i < 32; i++)
			{
				OpenGL.m_matrixPalleteOES[i] = Matrix.Identity;
			}
			OpenGL.m_activeMatrixStack = OpenGL.m_modelViewMatrixStack;
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x00146744 File Offset: 0x00144944
		public static void init(Game game, GraphicsDevice graphicsDevice)
		{
			OpenGL.m_graphicsDevice = graphicsDevice;
			OpenGL.m_basicEffect = new BasicEffect(OpenGL.m_graphicsDevice);
			OpenGL.m_alphaTestEffect = new AlphaTestEffect(OpenGL.m_graphicsDevice);
			OpenGL.m_skinnedEffect = new SkinnedEffect(OpenGL.m_graphicsDevice);
			OpenGL.m_dualTextureEffect = new DualTextureEffect(OpenGL.m_graphicsDevice);
			OpenGL.m_fakeTexture = new Texture2D(OpenGL.m_graphicsDevice, 1, 1);
			OpenGL.m_fakeTexture.SetData<Color>(new Color[]
			{
				new Color(1f, 1f, 1f, 1f)
			});
			OpenGL.calculateInvScreenMatrix();
			int num = OpenGL.CalcDepthStencilStateId(OpenGL.m_depthStencilState.DepthBufferFunction, OpenGL.m_depthStencilState.DepthBufferWriteEnable);
			OpenGL.m_depthStencils[num] = OpenGL.m_depthStencilState;
			int num2 = OpenGL.CalcSamplerStateId(OpenGL.m_textureUnits[0].SamplerState.AddressU, OpenGL.m_textureUnits[0].SamplerState.AddressV);
			OpenGL.m_samplerStates[num2] = OpenGL.m_textureUnits[0].SamplerState;
			long num3 = OpenGL.CalcBlendStateId(OpenGL.m_blendState.ColorSourceBlend, OpenGL.m_blendState.AlphaSourceBlend, OpenGL.m_blendState.ColorDestinationBlend, OpenGL.m_blendState.AlphaDestinationBlend, OpenGL.m_blendState.ColorWriteChannels, OpenGL.m_blendState.ColorBlendFunction, OpenGL.m_blendState.AlphaBlendFunction);
			OpenGL.m_blendStates[num3] = OpenGL.m_blendState;
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x001468A5 File Offset: 0x00144AA5
		private static int CalcDepthStencilStateId(CompareFunction depthBufferFunction, bool depthBufferWriteEnable)
		{
			return (int)(((int)depthBufferFunction + 1) * 10 + (depthBufferWriteEnable ? 1 : 0));
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x001468B5 File Offset: 0x00144AB5
		private static int CalcSamplerStateId(TextureAddressMode AddrU, TextureAddressMode AddrV)
		{
			return (int)(((int)AddrU + 1) * 10 + (int)AddrV);
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001468C0 File Offset: 0x00144AC0
		private static long CalcBlendStateId(Blend colorSrcBlend, Blend alphaSrcBlend, Blend colorDstBlend, Blend alphaDstBlend, ColorWriteChannels channels, BlendFunction ColorFunc, BlendFunction AlphaFunc)
		{
			return (long)(((int)colorSrcBlend + 1) * 32 * 32 * 32 * 32 * 32 + (int)(((int)alphaSrcBlend + 1) * 32 * 32 * 32 * 32) + (int)(((int)colorDstBlend + 1) * 32 * 32 * 32) + (int)(((int)alphaDstBlend + 1) * 32 * 32) + (int)(((int)channels + 1) * 32) + (int)(((int)ColorFunc + 1) * 5) + (int)AlphaFunc);
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x0014691C File Offset: 0x00144B1C
		private static void calculateInvScreenMatrix()
		{
			OpenGL.m_invScreen = Matrix.Identity;
			int num = OpenGL.m_viewport.Width >> 1;
			int num2 = OpenGL.m_viewport.Height >> 1;
			OpenGL.m_invScreen.M11 = (float)num;
			OpenGL.m_invScreen.M22 = (float)(-(float)num2);
			OpenGL.m_invScreen.M41 = (float)(OpenGL.m_viewport.X + num);
			OpenGL.m_invScreen.M42 = (float)(OpenGL.m_viewport.Y + num2);
			OpenGL.m_invScreen = Matrix.Invert(OpenGL.m_invScreen);
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001469A4 File Offset: 0x00144BA4
		public static int SizeOf(uint type)
		{
			switch (type)
			{
			case 5120U:
			case 5121U:
				return 1;
			case 5122U:
			case 5123U:
				return 2;
			case 5124U:
			case 5125U:
			case 5126U:
				return 4;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x001469E8 File Offset: 0x00144BE8
		private static float Clamp(float value, float lowerBound, float upperBound)
		{
			if (value < lowerBound)
			{
				return lowerBound;
			}
			if (value > upperBound)
			{
				return upperBound;
			}
			return value;
		}

		// Token: 0x0400504D RID: 20557
		private const int MinBufferSize = 32;

		// Token: 0x0400504E RID: 20558
		private const int MAX_PALETTE_MATRICES_OES = 32;

		// Token: 0x0400504F RID: 20559
		private const int TEXTURES_NAME_CAPACITY = 8;

		// Token: 0x04005050 RID: 20560
		private const int TEXTURES_NAME_CAPACITY_INCREMENT = 8;

		// Token: 0x04005051 RID: 20561
		private const int BUFFERS_NAME_CAPACITY = 8;

		// Token: 0x04005052 RID: 20562
		private const int BUFFERS_NAME_CAPACITY_INCREMENT = 8;

		// Token: 0x04005053 RID: 20563
		public const ushort GL_BLEND_EQUATION_RGB_OES = 32777;

		// Token: 0x04005054 RID: 20564
		public const ushort GL_BLEND_EQUATION_ALPHA_OES = 34877;

		// Token: 0x04005055 RID: 20565
		public const ushort GL_BLEND_DST_RGB_OES = 32968;

		// Token: 0x04005056 RID: 20566
		public const ushort GL_BLEND_SRC_RGB_OES = 32969;

		// Token: 0x04005057 RID: 20567
		public const ushort GL_BLEND_DST_ALPHA_OES = 32970;

		// Token: 0x04005058 RID: 20568
		public const ushort GL_BLEND_SRC_ALPHA_OES = 32971;

		// Token: 0x04005059 RID: 20569
		public const ushort GL_BLEND_EQUATION_OES = 32777;

		// Token: 0x0400505A RID: 20570
		public const ushort GL_FUNC_ADD_OES = 32774;

		// Token: 0x0400505B RID: 20571
		public const ushort GL_FUNC_SUBTRACT_OES = 32778;

		// Token: 0x0400505C RID: 20572
		public const ushort GL_FUNC_REVERSE_SUBTRACT_OES = 32779;

		// Token: 0x0400505D RID: 20573
		public const ushort GL_ETC1_RGB8_OES = 36196;

		// Token: 0x0400505E RID: 20574
		public const ushort GL_TEXTURE_CROP_RECT_OES = 35741;

		// Token: 0x0400505F RID: 20575
		public const ushort GL_FIXED_OES = 5132;

		// Token: 0x04005060 RID: 20576
		public const ushort GL_NONE_OES = 0;

		// Token: 0x04005061 RID: 20577
		public const ushort GL_FRAMEBUFFER_OES = 36160;

		// Token: 0x04005062 RID: 20578
		public const ushort GL_RENDERBUFFER_OES = 36161;

		// Token: 0x04005063 RID: 20579
		public const ushort GL_RGBA4_OES = 32854;

		// Token: 0x04005064 RID: 20580
		public const ushort GL_RGB5_A1_OES = 32855;

		// Token: 0x04005065 RID: 20581
		public const ushort GL_RGB565_OES = 36194;

		// Token: 0x04005066 RID: 20582
		public const ushort GL_DEPTH_COMPONENT16_OES = 33189;

		// Token: 0x04005067 RID: 20583
		public const ushort GL_RENDERBUFFER_WIDTH_OES = 36162;

		// Token: 0x04005068 RID: 20584
		public const ushort GL_RENDERBUFFER_HEIGHT_OES = 36163;

		// Token: 0x04005069 RID: 20585
		public const ushort GL_RENDERBUFFER_INTERNAL_FORMAT_OES = 36164;

		// Token: 0x0400506A RID: 20586
		public const ushort GL_RENDERBUFFER_RED_SIZE_OES = 36176;

		// Token: 0x0400506B RID: 20587
		public const ushort GL_RENDERBUFFER_GREEN_SIZE_OES = 36177;

		// Token: 0x0400506C RID: 20588
		public const ushort GL_RENDERBUFFER_BLUE_SIZE_OES = 36178;

		// Token: 0x0400506D RID: 20589
		public const ushort GL_RENDERBUFFER_ALPHA_SIZE_OES = 36179;

		// Token: 0x0400506E RID: 20590
		public const ushort GL_RENDERBUFFER_DEPTH_SIZE_OES = 36180;

		// Token: 0x0400506F RID: 20591
		public const ushort GL_RENDERBUFFER_STENCIL_SIZE_OES = 36181;

		// Token: 0x04005070 RID: 20592
		public const ushort GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_OES = 36048;

		// Token: 0x04005071 RID: 20593
		public const ushort GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_OES = 36049;

		// Token: 0x04005072 RID: 20594
		public const ushort GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_OES = 36050;

		// Token: 0x04005073 RID: 20595
		public const ushort GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_OES = 36051;

		// Token: 0x04005074 RID: 20596
		public const ushort GL_COLOR_ATTACHMENT0_OES = 36064;

		// Token: 0x04005075 RID: 20597
		public const ushort GL_DEPTH_ATTACHMENT_OES = 36096;

		// Token: 0x04005076 RID: 20598
		public const ushort GL_STENCIL_ATTACHMENT_OES = 36128;

		// Token: 0x04005077 RID: 20599
		public const ushort GL_FRAMEBUFFER_COMPLETE_OES = 36053;

		// Token: 0x04005078 RID: 20600
		public const ushort GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT_OES = 36054;

		// Token: 0x04005079 RID: 20601
		public const ushort GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_OES = 36055;

		// Token: 0x0400507A RID: 20602
		public const ushort GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS_OES = 36057;

		// Token: 0x0400507B RID: 20603
		public const ushort GL_FRAMEBUFFER_INCOMPLETE_FORMATS_OES = 36058;

		// Token: 0x0400507C RID: 20604
		public const ushort GL_FRAMEBUFFER_UNSUPPORTED_OES = 36061;

		// Token: 0x0400507D RID: 20605
		public const ushort GL_FRAMEBUFFER_BINDING_OES = 36006;

		// Token: 0x0400507E RID: 20606
		public const ushort GL_RENDERBUFFER_BINDING_OES = 36007;

		// Token: 0x0400507F RID: 20607
		public const ushort GL_MAX_RENDERBUFFER_SIZE_OES = 34024;

		// Token: 0x04005080 RID: 20608
		public const ushort GL_INVALID_FRAMEBUFFER_OPERATION_OES = 1286;

		// Token: 0x04005081 RID: 20609
		public const ushort GL_MODELVIEW_MATRIX_FLOAT_AS_INT_BITS_OES = 35213;

		// Token: 0x04005082 RID: 20610
		public const ushort GL_PROJECTION_MATRIX_FLOAT_AS_INT_BITS_OES = 35214;

		// Token: 0x04005083 RID: 20611
		public const ushort GL_TEXTURE_MATRIX_FLOAT_AS_INT_BITS_OES = 35215;

		// Token: 0x04005084 RID: 20612
		public const ushort GL_MAX_VERTEX_UNITS_OES = 34468;

		// Token: 0x04005085 RID: 20613
		public const ushort GL_MAX_PALETTE_MATRICES_OES = 34882;

		// Token: 0x04005086 RID: 20614
		public const ushort GL_MATRIX_PALETTE_OES = 34880;

		// Token: 0x04005087 RID: 20615
		public const ushort GL_MATRIX_INDEX_ARRAY_OES = 34884;

		// Token: 0x04005088 RID: 20616
		public const ushort GL_WEIGHT_ARRAY_OES = 34477;

		// Token: 0x04005089 RID: 20617
		public const ushort GL_CURRENT_PALETTE_MATRIX_OES = 34883;

		// Token: 0x0400508A RID: 20618
		public const ushort GL_MATRIX_INDEX_ARRAY_SIZE_OES = 34886;

		// Token: 0x0400508B RID: 20619
		public const ushort GL_MATRIX_INDEX_ARRAY_TYPE_OES = 34887;

		// Token: 0x0400508C RID: 20620
		public const ushort GL_MATRIX_INDEX_ARRAY_STRIDE_OES = 34888;

		// Token: 0x0400508D RID: 20621
		public const ushort GL_MATRIX_INDEX_ARRAY_POINTER_OES = 34889;

		// Token: 0x0400508E RID: 20622
		public const ushort GL_MATRIX_INDEX_ARRAY_BUFFER_BINDING_OES = 35742;

		// Token: 0x0400508F RID: 20623
		public const ushort GL_WEIGHT_ARRAY_SIZE_OES = 34475;

		// Token: 0x04005090 RID: 20624
		public const ushort GL_WEIGHT_ARRAY_TYPE_OES = 34473;

		// Token: 0x04005091 RID: 20625
		public const ushort GL_WEIGHT_ARRAY_STRIDE_OES = 34474;

		// Token: 0x04005092 RID: 20626
		public const ushort GL_WEIGHT_ARRAY_POINTER_OES = 34476;

		// Token: 0x04005093 RID: 20627
		public const ushort GL_WEIGHT_ARRAY_BUFFER_BINDING_OES = 34974;

		// Token: 0x04005094 RID: 20628
		public const ushort GL_INCR_WRAP_OES = 34055;

		// Token: 0x04005095 RID: 20629
		public const ushort GL_DECR_WRAP_OES = 34056;

		// Token: 0x04005096 RID: 20630
		public const ushort GL_NORMAL_MAP_OES = 34065;

		// Token: 0x04005097 RID: 20631
		public const ushort GL_REFLECTION_MAP_OES = 34066;

		// Token: 0x04005098 RID: 20632
		public const ushort GL_TEXTURE_CUBE_MAP_OES = 34067;

		// Token: 0x04005099 RID: 20633
		public const ushort GL_TEXTURE_BINDING_CUBE_MAP_OES = 34068;

		// Token: 0x0400509A RID: 20634
		public const ushort GL_TEXTURE_CUBE_MAP_POSITIVE_X_OES = 34069;

		// Token: 0x0400509B RID: 20635
		public const ushort GL_TEXTURE_CUBE_MAP_NEGATIVE_X_OES = 34070;

		// Token: 0x0400509C RID: 20636
		public const ushort GL_TEXTURE_CUBE_MAP_POSITIVE_Y_OES = 34071;

		// Token: 0x0400509D RID: 20637
		public const ushort GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_OES = 34072;

		// Token: 0x0400509E RID: 20638
		public const ushort GL_TEXTURE_CUBE_MAP_POSITIVE_Z_OES = 34073;

		// Token: 0x0400509F RID: 20639
		public const ushort GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_OES = 34074;

		// Token: 0x040050A0 RID: 20640
		public const ushort GL_MAX_CUBE_MAP_TEXTURE_SIZE_OES = 34076;

		// Token: 0x040050A1 RID: 20641
		public const ushort GL_TEXTURE_GEN_MODE_OES = 9472;

		// Token: 0x040050A2 RID: 20642
		public const ushort GL_TEXTURE_GEN_STR_OES = 36192;

		// Token: 0x040050A3 RID: 20643
		public const ushort GL_MIRRORED_REPEAT_OES = 33648;

		// Token: 0x040050A4 RID: 20644
		public const ushort GL_DEPTH_COMPONENT24_OES = 33190;

		// Token: 0x040050A5 RID: 20645
		public const ushort GL_DEPTH_COMPONENT32_OES = 33191;

		// Token: 0x040050A6 RID: 20646
		public const ushort GL_WRITE_ONLY_OES = 35001;

		// Token: 0x040050A7 RID: 20647
		public const ushort GL_BUFFER_ACCESS_OES = 35003;

		// Token: 0x040050A8 RID: 20648
		public const ushort GL_BUFFER_MAPPED_OES = 35004;

		// Token: 0x040050A9 RID: 20649
		public const ushort GL_BUFFER_MAP_POINTER_OES = 35005;

		// Token: 0x040050AA RID: 20650
		public const ushort GL_RGB8_OES = 32849;

		// Token: 0x040050AB RID: 20651
		public const ushort GL_RGBA8_OES = 32856;

		// Token: 0x040050AC RID: 20652
		public const ushort GL_STENCIL_INDEX1_OES = 36166;

		// Token: 0x040050AD RID: 20653
		public const ushort GL_STENCIL_INDEX4_OES = 36167;

		// Token: 0x040050AE RID: 20654
		public const ushort GL_STENCIL_INDEX8_OES = 36168;

		// Token: 0x040050AF RID: 20655
		public const ushort GL_3DC_X_AMD = 34809;

		// Token: 0x040050B0 RID: 20656
		public const ushort GL_3DC_XY_AMD = 34810;

		// Token: 0x040050B1 RID: 20657
		public const ushort GL_ATC_RGB_AMD = 35986;

		// Token: 0x040050B2 RID: 20658
		public const ushort GL_ATC_RGBA_EXPLICIT_ALPHA_AMD = 35987;

		// Token: 0x040050B3 RID: 20659
		public const ushort GL_ATC_RGBA_INTERPOLATED_ALPHA_AMD = 34798;

		// Token: 0x040050B4 RID: 20660
		public const ushort GL_TEXTURE_MAX_ANISOTROPY_EXT = 34046;

		// Token: 0x040050B5 RID: 20661
		public const ushort GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 34047;

		// Token: 0x040050B6 RID: 20662
		public const ushort GL_POINT_SIZE_MIN = 33062;

		// Token: 0x040050B7 RID: 20663
		public const ushort GL_POINT_SIZE_MAX = 33063;

		// Token: 0x040050B8 RID: 20664
		public const ushort GL_POINT_FADE_THRESHOLD_SIZE = 33064;

		// Token: 0x040050B9 RID: 20665
		public const ushort GL_POINT_DISTANCE_ATTENUATION = 33065;

		// Token: 0x040050BA RID: 20666
		public const ushort GL_GENERATE_MIPMAP_HINT = 33170;

		// Token: 0x040050BB RID: 20667
		public const ushort GL_FIXED = 5132;

		// Token: 0x040050BC RID: 20668
		public const ushort GL_GENERATE_MIPMAP = 33169;

		// Token: 0x040050BD RID: 20669
		public const ushort GL_ARRAY_BUFFER = 34962;

		// Token: 0x040050BE RID: 20670
		public const ushort GL_ELEMENT_ARRAY_BUFFER = 34963;

		// Token: 0x040050BF RID: 20671
		public const ushort GL_ARRAY_BUFFER_BINDING = 34964;

		// Token: 0x040050C0 RID: 20672
		public const ushort GL_ELEMENT_ARRAY_BUFFER_BINDING = 34965;

		// Token: 0x040050C1 RID: 20673
		public const ushort GL_VERTEX_ARRAY_BUFFER_BINDING = 34966;

		// Token: 0x040050C2 RID: 20674
		public const ushort GL_NORMAL_ARRAY_BUFFER_BINDING = 34967;

		// Token: 0x040050C3 RID: 20675
		public const ushort GL_COLOR_ARRAY_BUFFER_BINDING = 34968;

		// Token: 0x040050C4 RID: 20676
		public const ushort GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING = 34970;

		// Token: 0x040050C5 RID: 20677
		public const ushort GL_STATIC_DRAW = 35044;

		// Token: 0x040050C6 RID: 20678
		public const ushort GL_DYNAMIC_DRAW = 35048;

		// Token: 0x040050C7 RID: 20679
		public const ushort GL_BUFFER_SIZE = 34660;

		// Token: 0x040050C8 RID: 20680
		public const ushort GL_BUFFER_USAGE = 34661;

		// Token: 0x040050C9 RID: 20681
		public const ushort GL_SRC0_RGB = 34176;

		// Token: 0x040050CA RID: 20682
		public const ushort GL_SRC1_RGB = 34177;

		// Token: 0x040050CB RID: 20683
		public const ushort GL_SRC2_RGB = 34178;

		// Token: 0x040050CC RID: 20684
		public const ushort GL_SRC0_ALPHA = 34184;

		// Token: 0x040050CD RID: 20685
		public const ushort GL_SRC1_ALPHA = 34185;

		// Token: 0x040050CE RID: 20686
		public const ushort GL_SRC2_ALPHA = 34186;

		// Token: 0x040050CF RID: 20687
		public const ushort GL_MIRRORED_REPEAT = 33648;

		// Token: 0x040050D0 RID: 20688
		public const ushort GL_SECONDARY_COLOR_ARRAY = 33886;

		// Token: 0x040050D1 RID: 20689
		public const byte GL_FALSE = 0;

		// Token: 0x040050D2 RID: 20690
		public const byte GL_TRUE = 1;

		// Token: 0x040050D3 RID: 20691
		public const ushort GL_BYTE = 5120;

		// Token: 0x040050D4 RID: 20692
		public const ushort GL_UNSIGNED_BYTE = 5121;

		// Token: 0x040050D5 RID: 20693
		public const ushort GL_SHORT = 5122;

		// Token: 0x040050D6 RID: 20694
		public const ushort GL_UNSIGNED_SHORT = 5123;

		// Token: 0x040050D7 RID: 20695
		public const ushort GL_INT = 5124;

		// Token: 0x040050D8 RID: 20696
		public const ushort GL_UNSIGNED_INT = 5125;

		// Token: 0x040050D9 RID: 20697
		public const ushort GL_FLOAT = 5126;

		// Token: 0x040050DA RID: 20698
		public const ushort GL_2_BYTES = 5127;

		// Token: 0x040050DB RID: 20699
		public const ushort GL_3_BYTES = 5128;

		// Token: 0x040050DC RID: 20700
		public const ushort GL_4_BYTES = 5129;

		// Token: 0x040050DD RID: 20701
		public const ushort GL_DOUBLE = 5130;

		// Token: 0x040050DE RID: 20702
		public const ushort GL_POINTS = 0;

		// Token: 0x040050DF RID: 20703
		public const ushort GL_LINES = 1;

		// Token: 0x040050E0 RID: 20704
		public const ushort GL_LINE_LOOP = 2;

		// Token: 0x040050E1 RID: 20705
		public const ushort GL_LINE_STRIP = 3;

		// Token: 0x040050E2 RID: 20706
		public const ushort GL_TRIANGLES = 4;

		// Token: 0x040050E3 RID: 20707
		public const ushort GL_TRIANGLE_STRIP = 5;

		// Token: 0x040050E4 RID: 20708
		public const ushort GL_TRIANGLE_FAN = 6;

		// Token: 0x040050E5 RID: 20709
		public const ushort GL_QUADS = 7;

		// Token: 0x040050E6 RID: 20710
		public const ushort GL_QUAD_STRIP = 8;

		// Token: 0x040050E7 RID: 20711
		public const ushort GL_POLYGON = 9;

		// Token: 0x040050E8 RID: 20712
		public const ushort GL_VERTEX_ARRAY = 32884;

		// Token: 0x040050E9 RID: 20713
		public const ushort GL_NORMAL_ARRAY = 32885;

		// Token: 0x040050EA RID: 20714
		public const ushort GL_COLOR_ARRAY = 32886;

		// Token: 0x040050EB RID: 20715
		public const ushort GL_INDEX_ARRAY = 32887;

		// Token: 0x040050EC RID: 20716
		public const ushort GL_TEXTURE_COORD_ARRAY = 32888;

		// Token: 0x040050ED RID: 20717
		public const ushort GL_EDGE_FLAG_ARRAY = 32889;

		// Token: 0x040050EE RID: 20718
		public const ushort GL_VERTEX_ARRAY_SIZE = 32890;

		// Token: 0x040050EF RID: 20719
		public const ushort GL_VERTEX_ARRAY_TYPE = 32891;

		// Token: 0x040050F0 RID: 20720
		public const ushort GL_VERTEX_ARRAY_STRIDE = 32892;

		// Token: 0x040050F1 RID: 20721
		public const ushort GL_NORMAL_ARRAY_TYPE = 32894;

		// Token: 0x040050F2 RID: 20722
		public const ushort GL_NORMAL_ARRAY_STRIDE = 32895;

		// Token: 0x040050F3 RID: 20723
		public const ushort GL_COLOR_ARRAY_SIZE = 32897;

		// Token: 0x040050F4 RID: 20724
		public const ushort GL_COLOR_ARRAY_TYPE = 32898;

		// Token: 0x040050F5 RID: 20725
		public const ushort GL_COLOR_ARRAY_STRIDE = 32899;

		// Token: 0x040050F6 RID: 20726
		public const ushort GL_INDEX_ARRAY_TYPE = 32901;

		// Token: 0x040050F7 RID: 20727
		public const ushort GL_INDEX_ARRAY_STRIDE = 32902;

		// Token: 0x040050F8 RID: 20728
		public const ushort GL_TEXTURE_COORD_ARRAY_SIZE = 32904;

		// Token: 0x040050F9 RID: 20729
		public const ushort GL_TEXTURE_COORD_ARRAY_TYPE = 32905;

		// Token: 0x040050FA RID: 20730
		public const ushort GL_TEXTURE_COORD_ARRAY_STRIDE = 32906;

		// Token: 0x040050FB RID: 20731
		public const ushort GL_EDGE_FLAG_ARRAY_STRIDE = 32908;

		// Token: 0x040050FC RID: 20732
		public const ushort GL_VERTEX_ARRAY_POINTER = 32910;

		// Token: 0x040050FD RID: 20733
		public const ushort GL_NORMAL_ARRAY_POINTER = 32911;

		// Token: 0x040050FE RID: 20734
		public const ushort GL_COLOR_ARRAY_POINTER = 32912;

		// Token: 0x040050FF RID: 20735
		public const ushort GL_INDEX_ARRAY_POINTER = 32913;

		// Token: 0x04005100 RID: 20736
		public const ushort GL_TEXTURE_COORD_ARRAY_POINTER = 32914;

		// Token: 0x04005101 RID: 20737
		public const ushort GL_EDGE_FLAG_ARRAY_POINTER = 32915;

		// Token: 0x04005102 RID: 20738
		public const ushort GL_V2F = 10784;

		// Token: 0x04005103 RID: 20739
		public const ushort GL_V3F = 10785;

		// Token: 0x04005104 RID: 20740
		public const ushort GL_C4UB_V2F = 10786;

		// Token: 0x04005105 RID: 20741
		public const ushort GL_C4UB_V3F = 10787;

		// Token: 0x04005106 RID: 20742
		public const ushort GL_C3F_V3F = 10788;

		// Token: 0x04005107 RID: 20743
		public const ushort GL_N3F_V3F = 10789;

		// Token: 0x04005108 RID: 20744
		public const ushort GL_C4F_N3F_V3F = 10790;

		// Token: 0x04005109 RID: 20745
		public const ushort GL_T2F_V3F = 10791;

		// Token: 0x0400510A RID: 20746
		public const ushort GL_T4F_V4F = 10792;

		// Token: 0x0400510B RID: 20747
		public const ushort GL_T2F_C4UB_V3F = 10793;

		// Token: 0x0400510C RID: 20748
		public const ushort GL_T2F_C3F_V3F = 10794;

		// Token: 0x0400510D RID: 20749
		public const ushort GL_T2F_N3F_V3F = 10795;

		// Token: 0x0400510E RID: 20750
		public const ushort GL_T2F_C4F_N3F_V3F = 10796;

		// Token: 0x0400510F RID: 20751
		public const ushort GL_T4F_C4F_N3F_V4F = 10797;

		// Token: 0x04005110 RID: 20752
		public const ushort GL_MATRIX_MODE = 2976;

		// Token: 0x04005111 RID: 20753
		public const ushort GL_MODELVIEW = 5888;

		// Token: 0x04005112 RID: 20754
		public const ushort GL_PROJECTION = 5889;

		// Token: 0x04005113 RID: 20755
		public const ushort GL_TEXTURE = 5890;

		// Token: 0x04005114 RID: 20756
		public const ushort GL_POINT_SMOOTH = 2832;

		// Token: 0x04005115 RID: 20757
		public const ushort GL_POINT_SIZE = 2833;

		// Token: 0x04005116 RID: 20758
		public const ushort GL_POINT_SIZE_GRANULARITY = 2835;

		// Token: 0x04005117 RID: 20759
		public const ushort GL_POINT_SIZE_RANGE = 2834;

		// Token: 0x04005118 RID: 20760
		public const ushort GL_LINE_SMOOTH = 2848;

		// Token: 0x04005119 RID: 20761
		public const ushort GL_LINE_STIPPLE = 2852;

		// Token: 0x0400511A RID: 20762
		public const ushort GL_LINE_STIPPLE_PATTERN = 2853;

		// Token: 0x0400511B RID: 20763
		public const ushort GL_LINE_STIPPLE_REPEAT = 2854;

		// Token: 0x0400511C RID: 20764
		public const ushort GL_LINE_WIDTH = 2849;

		// Token: 0x0400511D RID: 20765
		public const ushort GL_LINE_WIDTH_GRANULARITY = 2851;

		// Token: 0x0400511E RID: 20766
		public const ushort GL_LINE_WIDTH_RANGE = 2850;

		// Token: 0x0400511F RID: 20767
		public const ushort GL_POINT = 6912;

		// Token: 0x04005120 RID: 20768
		public const ushort GL_LINE = 6913;

		// Token: 0x04005121 RID: 20769
		public const ushort GL_FILL = 6914;

		// Token: 0x04005122 RID: 20770
		public const ushort GL_CW = 2304;

		// Token: 0x04005123 RID: 20771
		public const ushort GL_CCW = 2305;

		// Token: 0x04005124 RID: 20772
		public const ushort GL_FRONT = 1028;

		// Token: 0x04005125 RID: 20773
		public const ushort GL_BACK = 1029;

		// Token: 0x04005126 RID: 20774
		public const ushort GL_POLYGON_MODE = 2880;

		// Token: 0x04005127 RID: 20775
		public const ushort GL_POLYGON_SMOOTH = 2881;

		// Token: 0x04005128 RID: 20776
		public const ushort GL_POLYGON_STIPPLE = 2882;

		// Token: 0x04005129 RID: 20777
		public const ushort GL_EDGE_FLAG = 2883;

		// Token: 0x0400512A RID: 20778
		public const ushort GL_CULL_FACE = 2884;

		// Token: 0x0400512B RID: 20779
		public const ushort GL_CULL_FACE_MODE = 2885;

		// Token: 0x0400512C RID: 20780
		public const ushort GL_FRONT_FACE = 2886;

		// Token: 0x0400512D RID: 20781
		public const ushort GL_POLYGON_OFFSET_FACTOR = 32824;

		// Token: 0x0400512E RID: 20782
		public const ushort GL_POLYGON_OFFSET_UNITS = 10752;

		// Token: 0x0400512F RID: 20783
		public const ushort GL_POLYGON_OFFSET_POINT = 10753;

		// Token: 0x04005130 RID: 20784
		public const ushort GL_POLYGON_OFFSET_LINE = 10754;

		// Token: 0x04005131 RID: 20785
		public const ushort GL_POLYGON_OFFSET_FILL = 32823;

		// Token: 0x04005132 RID: 20786
		public const ushort GL_COMPILE = 4864;

		// Token: 0x04005133 RID: 20787
		public const ushort GL_COMPILE_AND_EXECUTE = 4865;

		// Token: 0x04005134 RID: 20788
		public const ushort GL_LIST_BASE = 2866;

		// Token: 0x04005135 RID: 20789
		public const ushort GL_LIST_INDEX = 2867;

		// Token: 0x04005136 RID: 20790
		public const ushort GL_LIST_MODE = 2864;

		// Token: 0x04005137 RID: 20791
		public const ushort GL_NEVER = 512;

		// Token: 0x04005138 RID: 20792
		public const ushort GL_LESS = 513;

		// Token: 0x04005139 RID: 20793
		public const ushort GL_EQUAL = 514;

		// Token: 0x0400513A RID: 20794
		public const ushort GL_LEQUAL = 515;

		// Token: 0x0400513B RID: 20795
		public const ushort GL_GREATER = 516;

		// Token: 0x0400513C RID: 20796
		public const ushort GL_NOTEQUAL = 517;

		// Token: 0x0400513D RID: 20797
		public const ushort GL_GEQUAL = 518;

		// Token: 0x0400513E RID: 20798
		public const ushort GL_ALWAYS = 519;

		// Token: 0x0400513F RID: 20799
		public const ushort GL_DEPTH_TEST = 2929;

		// Token: 0x04005140 RID: 20800
		public const ushort GL_DEPTH_BITS = 3414;

		// Token: 0x04005141 RID: 20801
		public const ushort GL_DEPTH_CLEAR_VALUE = 2931;

		// Token: 0x04005142 RID: 20802
		public const ushort GL_DEPTH_FUNC = 2932;

		// Token: 0x04005143 RID: 20803
		public const ushort GL_DEPTH_RANGE = 2928;

		// Token: 0x04005144 RID: 20804
		public const ushort GL_DEPTH_WRITEMASK = 2930;

		// Token: 0x04005145 RID: 20805
		public const ushort GL_DEPTH_COMPONENT = 6402;

		// Token: 0x04005146 RID: 20806
		public const ushort GL_LIGHTING = 2896;

		// Token: 0x04005147 RID: 20807
		public const ushort GL_LIGHT0 = 16384;

		// Token: 0x04005148 RID: 20808
		public const ushort GL_LIGHT1 = 16385;

		// Token: 0x04005149 RID: 20809
		public const ushort GL_LIGHT2 = 16386;

		// Token: 0x0400514A RID: 20810
		public const ushort GL_LIGHT3 = 16387;

		// Token: 0x0400514B RID: 20811
		public const ushort GL_LIGHT4 = 16388;

		// Token: 0x0400514C RID: 20812
		public const ushort GL_LIGHT5 = 16389;

		// Token: 0x0400514D RID: 20813
		public const ushort GL_LIGHT6 = 16390;

		// Token: 0x0400514E RID: 20814
		public const ushort GL_LIGHT7 = 16391;

		// Token: 0x0400514F RID: 20815
		public const ushort GL_SPOT_EXPONENT = 4613;

		// Token: 0x04005150 RID: 20816
		public const ushort GL_SPOT_CUTOFF = 4614;

		// Token: 0x04005151 RID: 20817
		public const ushort GL_CONSTANT_ATTENUATION = 4615;

		// Token: 0x04005152 RID: 20818
		public const ushort GL_LINEAR_ATTENUATION = 4616;

		// Token: 0x04005153 RID: 20819
		public const ushort GL_QUADRATIC_ATTENUATION = 4617;

		// Token: 0x04005154 RID: 20820
		public const ushort GL_AMBIENT = 4608;

		// Token: 0x04005155 RID: 20821
		public const ushort GL_DIFFUSE = 4609;

		// Token: 0x04005156 RID: 20822
		public const ushort GL_SPECULAR = 4610;

		// Token: 0x04005157 RID: 20823
		public const ushort GL_SHININESS = 5633;

		// Token: 0x04005158 RID: 20824
		public const ushort GL_EMISSION = 5632;

		// Token: 0x04005159 RID: 20825
		public const ushort GL_POSITION = 4611;

		// Token: 0x0400515A RID: 20826
		public const ushort GL_SPOT_DIRECTION = 4612;

		// Token: 0x0400515B RID: 20827
		public const ushort GL_AMBIENT_AND_DIFFUSE = 5634;

		// Token: 0x0400515C RID: 20828
		public const ushort GL_COLOR_INDEXES = 5635;

		// Token: 0x0400515D RID: 20829
		public const ushort GL_LIGHT_MODEL_TWO_SIDE = 2898;

		// Token: 0x0400515E RID: 20830
		public const ushort GL_LIGHT_MODEL_LOCAL_VIEWER = 2897;

		// Token: 0x0400515F RID: 20831
		public const ushort GL_LIGHT_MODEL_AMBIENT = 2899;

		// Token: 0x04005160 RID: 20832
		public const ushort GL_FRONT_AND_BACK = 1032;

		// Token: 0x04005161 RID: 20833
		public const ushort GL_SHADE_MODEL = 2900;

		// Token: 0x04005162 RID: 20834
		public const ushort GL_FLAT = 7424;

		// Token: 0x04005163 RID: 20835
		public const ushort GL_SMOOTH = 7425;

		// Token: 0x04005164 RID: 20836
		public const ushort GL_COLOR_MATERIAL = 2903;

		// Token: 0x04005165 RID: 20837
		public const ushort GL_COLOR_MATERIAL_FACE = 2901;

		// Token: 0x04005166 RID: 20838
		public const ushort GL_COLOR_MATERIAL_PARAMETER = 2902;

		// Token: 0x04005167 RID: 20839
		public const ushort GL_NORMALIZE = 2977;

		// Token: 0x04005168 RID: 20840
		public const ushort GL_CLIP_PLANE0 = 12288;

		// Token: 0x04005169 RID: 20841
		public const ushort GL_CLIP_PLANE1 = 12289;

		// Token: 0x0400516A RID: 20842
		public const ushort GL_CLIP_PLANE2 = 12290;

		// Token: 0x0400516B RID: 20843
		public const ushort GL_CLIP_PLANE3 = 12291;

		// Token: 0x0400516C RID: 20844
		public const ushort GL_CLIP_PLANE4 = 12292;

		// Token: 0x0400516D RID: 20845
		public const ushort GL_CLIP_PLANE5 = 12293;

		// Token: 0x0400516E RID: 20846
		public const ushort GL_ACCUM_RED_BITS = 3416;

		// Token: 0x0400516F RID: 20847
		public const ushort GL_ACCUM_GREEN_BITS = 3417;

		// Token: 0x04005170 RID: 20848
		public const ushort GL_ACCUM_BLUE_BITS = 3418;

		// Token: 0x04005171 RID: 20849
		public const ushort GL_ACCUM_ALPHA_BITS = 3419;

		// Token: 0x04005172 RID: 20850
		public const ushort GL_ACCUM_CLEAR_VALUE = 2944;

		// Token: 0x04005173 RID: 20851
		public const ushort GL_ACCUM = 256;

		// Token: 0x04005174 RID: 20852
		public const ushort GL_ADD = 260;

		// Token: 0x04005175 RID: 20853
		public const ushort GL_LOAD = 257;

		// Token: 0x04005176 RID: 20854
		public const ushort GL_MULT = 259;

		// Token: 0x04005177 RID: 20855
		public const ushort GL_RETURN = 258;

		// Token: 0x04005178 RID: 20856
		public const ushort GL_ALPHA_TEST = 3008;

		// Token: 0x04005179 RID: 20857
		public const ushort GL_ALPHA_TEST_REF = 3010;

		// Token: 0x0400517A RID: 20858
		public const ushort GL_ALPHA_TEST_FUNC = 3009;

		// Token: 0x0400517B RID: 20859
		public const ushort GL_BLEND = 3042;

		// Token: 0x0400517C RID: 20860
		public const ushort GL_BLEND_SRC = 3041;

		// Token: 0x0400517D RID: 20861
		public const ushort GL_BLEND_DST = 3040;

		// Token: 0x0400517E RID: 20862
		public const ushort GL_ZERO = 0;

		// Token: 0x0400517F RID: 20863
		public const ushort GL_ONE = 1;

		// Token: 0x04005180 RID: 20864
		public const ushort GL_SRC_COLOR = 768;

		// Token: 0x04005181 RID: 20865
		public const ushort GL_ONE_MINUS_SRC_COLOR = 769;

		// Token: 0x04005182 RID: 20866
		public const ushort GL_SRC_ALPHA = 770;

		// Token: 0x04005183 RID: 20867
		public const ushort GL_ONE_MINUS_SRC_ALPHA = 771;

		// Token: 0x04005184 RID: 20868
		public const ushort GL_DST_ALPHA = 772;

		// Token: 0x04005185 RID: 20869
		public const ushort GL_ONE_MINUS_DST_ALPHA = 773;

		// Token: 0x04005186 RID: 20870
		public const ushort GL_DST_COLOR = 774;

		// Token: 0x04005187 RID: 20871
		public const ushort GL_ONE_MINUS_DST_COLOR = 775;

		// Token: 0x04005188 RID: 20872
		public const ushort GL_SRC_ALPHA_SATURATE = 776;

		// Token: 0x04005189 RID: 20873
		public const ushort GL_FEEDBACK = 7169;

		// Token: 0x0400518A RID: 20874
		public const ushort GL_RENDER = 7168;

		// Token: 0x0400518B RID: 20875
		public const ushort GL_SELECT = 7170;

		// Token: 0x0400518C RID: 20876
		public const ushort GL_2D = 1536;

		// Token: 0x0400518D RID: 20877
		public const ushort GL_3D = 1537;

		// Token: 0x0400518E RID: 20878
		public const ushort GL_3D_COLOR = 1538;

		// Token: 0x0400518F RID: 20879
		public const ushort GL_3D_COLOR_TEXTURE = 1539;

		// Token: 0x04005190 RID: 20880
		public const ushort GL_4D_COLOR_TEXTURE = 1540;

		// Token: 0x04005191 RID: 20881
		public const ushort GL_POINT_TOKEN = 1793;

		// Token: 0x04005192 RID: 20882
		public const ushort GL_LINE_TOKEN = 1794;

		// Token: 0x04005193 RID: 20883
		public const ushort GL_LINE_RESET_TOKEN = 1799;

		// Token: 0x04005194 RID: 20884
		public const ushort GL_POLYGON_TOKEN = 1795;

		// Token: 0x04005195 RID: 20885
		public const ushort GL_BITMAP_TOKEN = 1796;

		// Token: 0x04005196 RID: 20886
		public const ushort GL_DRAW_PIXEL_TOKEN = 1797;

		// Token: 0x04005197 RID: 20887
		public const ushort GL_COPY_PIXEL_TOKEN = 1798;

		// Token: 0x04005198 RID: 20888
		public const ushort GL_PASS_THROUGH_TOKEN = 1792;

		// Token: 0x04005199 RID: 20889
		public const ushort GL_FEEDBACK_BUFFER_POINTER = 3568;

		// Token: 0x0400519A RID: 20890
		public const ushort GL_FEEDBACK_BUFFER_SIZE = 3569;

		// Token: 0x0400519B RID: 20891
		public const ushort GL_FEEDBACK_BUFFER_TYPE = 3570;

		// Token: 0x0400519C RID: 20892
		public const ushort GL_SELECTION_BUFFER_POINTER = 3571;

		// Token: 0x0400519D RID: 20893
		public const ushort GL_SELECTION_BUFFER_SIZE = 3572;

		// Token: 0x0400519E RID: 20894
		public const ushort GL_FOG = 2912;

		// Token: 0x0400519F RID: 20895
		public const ushort GL_FOG_MODE = 2917;

		// Token: 0x040051A0 RID: 20896
		public const ushort GL_FOG_DENSITY = 2914;

		// Token: 0x040051A1 RID: 20897
		public const ushort GL_FOG_COLOR = 2918;

		// Token: 0x040051A2 RID: 20898
		public const ushort GL_FOG_INDEX = 2913;

		// Token: 0x040051A3 RID: 20899
		public const ushort GL_FOG_START = 2915;

		// Token: 0x040051A4 RID: 20900
		public const ushort GL_FOG_END = 2916;

		// Token: 0x040051A5 RID: 20901
		public const ushort GL_LINEAR = 9729;

		// Token: 0x040051A6 RID: 20902
		public const ushort GL_EXP = 2048;

		// Token: 0x040051A7 RID: 20903
		public const ushort GL_EXP2 = 2049;

		// Token: 0x040051A8 RID: 20904
		public const ushort GL_LOGIC_OP = 3057;

		// Token: 0x040051A9 RID: 20905
		public const ushort GL_INDEX_LOGIC_OP = 3057;

		// Token: 0x040051AA RID: 20906
		public const ushort GL_COLOR_LOGIC_OP = 3058;

		// Token: 0x040051AB RID: 20907
		public const ushort GL_LOGIC_OP_MODE = 3056;

		// Token: 0x040051AC RID: 20908
		public const ushort GL_CLEAR = 5376;

		// Token: 0x040051AD RID: 20909
		public const ushort GL_SET = 5391;

		// Token: 0x040051AE RID: 20910
		public const ushort GL_COPY = 5379;

		// Token: 0x040051AF RID: 20911
		public const ushort GL_COPY_INVERTED = 5388;

		// Token: 0x040051B0 RID: 20912
		public const ushort GL_NOOP = 5381;

		// Token: 0x040051B1 RID: 20913
		public const ushort GL_INVERT = 5386;

		// Token: 0x040051B2 RID: 20914
		public const ushort GL_AND = 5377;

		// Token: 0x040051B3 RID: 20915
		public const ushort GL_NAND = 5390;

		// Token: 0x040051B4 RID: 20916
		public const ushort GL_OR = 5383;

		// Token: 0x040051B5 RID: 20917
		public const ushort GL_NOR = 5384;

		// Token: 0x040051B6 RID: 20918
		public const ushort GL_XOR = 5382;

		// Token: 0x040051B7 RID: 20919
		public const ushort GL_EQUIV = 5385;

		// Token: 0x040051B8 RID: 20920
		public const ushort GL_AND_REVERSE = 5378;

		// Token: 0x040051B9 RID: 20921
		public const ushort GL_AND_INVERTED = 5380;

		// Token: 0x040051BA RID: 20922
		public const ushort GL_OR_REVERSE = 5387;

		// Token: 0x040051BB RID: 20923
		public const ushort GL_OR_INVERTED = 5389;

		// Token: 0x040051BC RID: 20924
		public const ushort GL_STENCIL_BITS = 3415;

		// Token: 0x040051BD RID: 20925
		public const ushort GL_STENCIL_TEST = 2960;

		// Token: 0x040051BE RID: 20926
		public const ushort GL_STENCIL_CLEAR_VALUE = 2961;

		// Token: 0x040051BF RID: 20927
		public const ushort GL_STENCIL_FUNC = 2962;

		// Token: 0x040051C0 RID: 20928
		public const ushort GL_STENCIL_VALUE_MASK = 2963;

		// Token: 0x040051C1 RID: 20929
		public const ushort GL_STENCIL_FAIL = 2964;

		// Token: 0x040051C2 RID: 20930
		public const ushort GL_STENCIL_PASS_DEPTH_FAIL = 2965;

		// Token: 0x040051C3 RID: 20931
		public const ushort GL_STENCIL_PASS_DEPTH_PASS = 2966;

		// Token: 0x040051C4 RID: 20932
		public const ushort GL_STENCIL_REF = 2967;

		// Token: 0x040051C5 RID: 20933
		public const ushort GL_STENCIL_WRITEMASK = 2968;

		// Token: 0x040051C6 RID: 20934
		public const ushort GL_STENCIL_INDEX = 6401;

		// Token: 0x040051C7 RID: 20935
		public const ushort GL_KEEP = 7680;

		// Token: 0x040051C8 RID: 20936
		public const ushort GL_REPLACE = 7681;

		// Token: 0x040051C9 RID: 20937
		public const ushort GL_INCR = 7682;

		// Token: 0x040051CA RID: 20938
		public const ushort GL_DECR = 7683;

		// Token: 0x040051CB RID: 20939
		public const ushort GL_NONE = 0;

		// Token: 0x040051CC RID: 20940
		public const ushort GL_LEFT = 1030;

		// Token: 0x040051CD RID: 20941
		public const ushort GL_RIGHT = 1031;

		// Token: 0x040051CE RID: 20942
		public const ushort GL_FRONT_LEFT = 1024;

		// Token: 0x040051CF RID: 20943
		public const ushort GL_FRONT_RIGHT = 1025;

		// Token: 0x040051D0 RID: 20944
		public const ushort GL_BACK_LEFT = 1026;

		// Token: 0x040051D1 RID: 20945
		public const ushort GL_BACK_RIGHT = 1027;

		// Token: 0x040051D2 RID: 20946
		public const ushort GL_AUX0 = 1033;

		// Token: 0x040051D3 RID: 20947
		public const ushort GL_AUX1 = 1034;

		// Token: 0x040051D4 RID: 20948
		public const ushort GL_AUX2 = 1035;

		// Token: 0x040051D5 RID: 20949
		public const ushort GL_AUX3 = 1036;

		// Token: 0x040051D6 RID: 20950
		public const ushort GL_COLOR_INDEX = 6400;

		// Token: 0x040051D7 RID: 20951
		public const ushort GL_RED = 6403;

		// Token: 0x040051D8 RID: 20952
		public const ushort GL_GREEN = 6404;

		// Token: 0x040051D9 RID: 20953
		public const ushort GL_BLUE = 6405;

		// Token: 0x040051DA RID: 20954
		public const ushort GL_ALPHA = 6406;

		// Token: 0x040051DB RID: 20955
		public const ushort GL_LUMINANCE = 6409;

		// Token: 0x040051DC RID: 20956
		public const ushort GL_LUMINANCE_ALPHA = 6410;

		// Token: 0x040051DD RID: 20957
		public const ushort GL_ALPHA_BITS = 3413;

		// Token: 0x040051DE RID: 20958
		public const ushort GL_RED_BITS = 3410;

		// Token: 0x040051DF RID: 20959
		public const ushort GL_GREEN_BITS = 3411;

		// Token: 0x040051E0 RID: 20960
		public const ushort GL_BLUE_BITS = 3412;

		// Token: 0x040051E1 RID: 20961
		public const ushort GL_INDEX_BITS = 3409;

		// Token: 0x040051E2 RID: 20962
		public const ushort GL_SUBPIXEL_BITS = 3408;

		// Token: 0x040051E3 RID: 20963
		public const ushort GL_AUX_BUFFERS = 3072;

		// Token: 0x040051E4 RID: 20964
		public const ushort GL_READ_BUFFER = 3074;

		// Token: 0x040051E5 RID: 20965
		public const ushort GL_DRAW_BUFFER = 3073;

		// Token: 0x040051E6 RID: 20966
		public const ushort GL_DOUBLEBUFFER = 3122;

		// Token: 0x040051E7 RID: 20967
		public const ushort GL_STEREO = 3123;

		// Token: 0x040051E8 RID: 20968
		public const ushort GL_BITMAP = 6656;

		// Token: 0x040051E9 RID: 20969
		public const ushort GL_COLOR = 6144;

		// Token: 0x040051EA RID: 20970
		public const ushort GL_DEPTH = 6145;

		// Token: 0x040051EB RID: 20971
		public const ushort GL_STENCIL = 6146;

		// Token: 0x040051EC RID: 20972
		public const ushort GL_DITHER = 3024;

		// Token: 0x040051ED RID: 20973
		public const ushort GL_RGB = 6407;

		// Token: 0x040051EE RID: 20974
		public const ushort GL_RGBA = 6408;

		// Token: 0x040051EF RID: 20975
		public const ushort GL_MAX_LIST_NESTING = 2865;

		// Token: 0x040051F0 RID: 20976
		public const ushort GL_MAX_EVAL_ORDER = 3376;

		// Token: 0x040051F1 RID: 20977
		public const ushort GL_MAX_LIGHTS = 3377;

		// Token: 0x040051F2 RID: 20978
		public const ushort GL_MAX_CLIP_PLANES = 3378;

		// Token: 0x040051F3 RID: 20979
		public const ushort GL_MAX_TEXTURE_SIZE = 3379;

		// Token: 0x040051F4 RID: 20980
		public const ushort GL_MAX_PIXEL_MAP_TABLE = 3380;

		// Token: 0x040051F5 RID: 20981
		public const ushort GL_MAX_ATTRIB_STACK_DEPTH = 3381;

		// Token: 0x040051F6 RID: 20982
		public const ushort GL_MAX_MODELVIEW_STACK_DEPTH = 3382;

		// Token: 0x040051F7 RID: 20983
		public const ushort GL_MAX_NAME_STACK_DEPTH = 3383;

		// Token: 0x040051F8 RID: 20984
		public const ushort GL_MAX_PROJECTION_STACK_DEPTH = 3384;

		// Token: 0x040051F9 RID: 20985
		public const ushort GL_MAX_TEXTURE_STACK_DEPTH = 3385;

		// Token: 0x040051FA RID: 20986
		public const ushort GL_MAX_VIEWPORT_DIMS = 3386;

		// Token: 0x040051FB RID: 20987
		public const ushort GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 3387;

		// Token: 0x040051FC RID: 20988
		public const ushort GL_ATTRIB_STACK_DEPTH = 2992;

		// Token: 0x040051FD RID: 20989
		public const ushort GL_CLIENT_ATTRIB_STACK_DEPTH = 2993;

		// Token: 0x040051FE RID: 20990
		public const ushort GL_COLOR_CLEAR_VALUE = 3106;

		// Token: 0x040051FF RID: 20991
		public const ushort GL_COLOR_WRITEMASK = 3107;

		// Token: 0x04005200 RID: 20992
		public const ushort GL_CURRENT_INDEX = 2817;

		// Token: 0x04005201 RID: 20993
		public const ushort GL_CURRENT_COLOR = 2816;

		// Token: 0x04005202 RID: 20994
		public const ushort GL_CURRENT_NORMAL = 2818;

		// Token: 0x04005203 RID: 20995
		public const ushort GL_CURRENT_RASTER_COLOR = 2820;

		// Token: 0x04005204 RID: 20996
		public const ushort GL_CURRENT_RASTER_DISTANCE = 2825;

		// Token: 0x04005205 RID: 20997
		public const ushort GL_CURRENT_RASTER_INDEX = 2821;

		// Token: 0x04005206 RID: 20998
		public const ushort GL_CURRENT_RASTER_POSITION = 2823;

		// Token: 0x04005207 RID: 20999
		public const ushort GL_CURRENT_RASTER_TEXTURE_COORDS = 2822;

		// Token: 0x04005208 RID: 21000
		public const ushort GL_CURRENT_RASTER_POSITION_VALID = 2824;

		// Token: 0x04005209 RID: 21001
		public const ushort GL_CURRENT_TEXTURE_COORDS = 2819;

		// Token: 0x0400520A RID: 21002
		public const ushort GL_INDEX_CLEAR_VALUE = 3104;

		// Token: 0x0400520B RID: 21003
		public const ushort GL_INDEX_MODE = 3120;

		// Token: 0x0400520C RID: 21004
		public const ushort GL_INDEX_WRITEMASK = 3105;

		// Token: 0x0400520D RID: 21005
		public const ushort GL_MODELVIEW_MATRIX = 2982;

		// Token: 0x0400520E RID: 21006
		public const ushort GL_MODELVIEW_STACK_DEPTH = 2979;

		// Token: 0x0400520F RID: 21007
		public const ushort GL_NAME_STACK_DEPTH = 3440;

		// Token: 0x04005210 RID: 21008
		public const ushort GL_PROJECTION_MATRIX = 2983;

		// Token: 0x04005211 RID: 21009
		public const ushort GL_PROJECTION_STACK_DEPTH = 2980;

		// Token: 0x04005212 RID: 21010
		public const ushort GL_RENDER_MODE = 3136;

		// Token: 0x04005213 RID: 21011
		public const ushort GL_RGBA_MODE = 3121;

		// Token: 0x04005214 RID: 21012
		public const ushort GL_TEXTURE_MATRIX = 2984;

		// Token: 0x04005215 RID: 21013
		public const ushort GL_TEXTURE_STACK_DEPTH = 2981;

		// Token: 0x04005216 RID: 21014
		public const ushort GL_VIEWPORT = 2978;

		// Token: 0x04005217 RID: 21015
		public const ushort GL_AUTO_NORMAL = 3456;

		// Token: 0x04005218 RID: 21016
		public const ushort GL_MAP1_COLOR_4 = 3472;

		// Token: 0x04005219 RID: 21017
		public const ushort GL_MAP1_INDEX = 3473;

		// Token: 0x0400521A RID: 21018
		public const ushort GL_MAP1_NORMAL = 3474;

		// Token: 0x0400521B RID: 21019
		public const ushort GL_MAP1_TEXTURE_COORD_1 = 3475;

		// Token: 0x0400521C RID: 21020
		public const ushort GL_MAP1_TEXTURE_COORD_2 = 3476;

		// Token: 0x0400521D RID: 21021
		public const ushort GL_MAP1_TEXTURE_COORD_3 = 3477;

		// Token: 0x0400521E RID: 21022
		public const ushort GL_MAP1_TEXTURE_COORD_4 = 3478;

		// Token: 0x0400521F RID: 21023
		public const ushort GL_MAP1_VERTEX_3 = 3479;

		// Token: 0x04005220 RID: 21024
		public const ushort GL_MAP1_VERTEX_4 = 3480;

		// Token: 0x04005221 RID: 21025
		public const ushort GL_MAP2_COLOR_4 = 3504;

		// Token: 0x04005222 RID: 21026
		public const ushort GL_MAP2_INDEX = 3505;

		// Token: 0x04005223 RID: 21027
		public const ushort GL_MAP2_NORMAL = 3506;

		// Token: 0x04005224 RID: 21028
		public const ushort GL_MAP2_TEXTURE_COORD_1 = 3507;

		// Token: 0x04005225 RID: 21029
		public const ushort GL_MAP2_TEXTURE_COORD_2 = 3508;

		// Token: 0x04005226 RID: 21030
		public const ushort GL_MAP2_TEXTURE_COORD_3 = 3509;

		// Token: 0x04005227 RID: 21031
		public const ushort GL_MAP2_TEXTURE_COORD_4 = 3510;

		// Token: 0x04005228 RID: 21032
		public const ushort GL_MAP2_VERTEX_3 = 3511;

		// Token: 0x04005229 RID: 21033
		public const ushort GL_MAP2_VERTEX_4 = 3512;

		// Token: 0x0400522A RID: 21034
		public const ushort GL_MAP1_GRID_DOMAIN = 3536;

		// Token: 0x0400522B RID: 21035
		public const ushort GL_MAP1_GRID_SEGMENTS = 3537;

		// Token: 0x0400522C RID: 21036
		public const ushort GL_MAP2_GRID_DOMAIN = 3538;

		// Token: 0x0400522D RID: 21037
		public const ushort GL_MAP2_GRID_SEGMENTS = 3539;

		// Token: 0x0400522E RID: 21038
		public const ushort GL_COEFF = 2560;

		// Token: 0x0400522F RID: 21039
		public const ushort GL_ORDER = 2561;

		// Token: 0x04005230 RID: 21040
		public const ushort GL_DOMAIN = 2562;

		// Token: 0x04005231 RID: 21041
		public const ushort GL_PERSPECTIVE_CORRECTION_HINT = 3152;

		// Token: 0x04005232 RID: 21042
		public const ushort GL_POINT_SMOOTH_HINT = 3153;

		// Token: 0x04005233 RID: 21043
		public const ushort GL_LINE_SMOOTH_HINT = 3154;

		// Token: 0x04005234 RID: 21044
		public const ushort GL_POLYGON_SMOOTH_HINT = 3155;

		// Token: 0x04005235 RID: 21045
		public const ushort GL_FOG_HINT = 3156;

		// Token: 0x04005236 RID: 21046
		public const ushort GL_DONT_CARE = 4352;

		// Token: 0x04005237 RID: 21047
		public const ushort GL_FASTEST = 4353;

		// Token: 0x04005238 RID: 21048
		public const ushort GL_NICEST = 4354;

		// Token: 0x04005239 RID: 21049
		public const ushort GL_SCISSOR_BOX = 3088;

		// Token: 0x0400523A RID: 21050
		public const ushort GL_SCISSOR_TEST = 3089;

		// Token: 0x0400523B RID: 21051
		public const ushort GL_MAP_COLOR = 3344;

		// Token: 0x0400523C RID: 21052
		public const ushort GL_MAP_STENCIL = 3345;

		// Token: 0x0400523D RID: 21053
		public const ushort GL_INDEX_SHIFT = 3346;

		// Token: 0x0400523E RID: 21054
		public const ushort GL_INDEX_OFFSET = 3347;

		// Token: 0x0400523F RID: 21055
		public const ushort GL_RED_SCALE = 3348;

		// Token: 0x04005240 RID: 21056
		public const ushort GL_RED_BIAS = 3349;

		// Token: 0x04005241 RID: 21057
		public const ushort GL_GREEN_SCALE = 3352;

		// Token: 0x04005242 RID: 21058
		public const ushort GL_GREEN_BIAS = 3353;

		// Token: 0x04005243 RID: 21059
		public const ushort GL_BLUE_SCALE = 3354;

		// Token: 0x04005244 RID: 21060
		public const ushort GL_BLUE_BIAS = 3355;

		// Token: 0x04005245 RID: 21061
		public const ushort GL_ALPHA_SCALE = 3356;

		// Token: 0x04005246 RID: 21062
		public const ushort GL_ALPHA_BIAS = 3357;

		// Token: 0x04005247 RID: 21063
		public const ushort GL_DEPTH_SCALE = 3358;

		// Token: 0x04005248 RID: 21064
		public const ushort GL_DEPTH_BIAS = 3359;

		// Token: 0x04005249 RID: 21065
		public const ushort GL_PIXEL_MAP_S_TO_S_SIZE = 3249;

		// Token: 0x0400524A RID: 21066
		public const ushort GL_PIXEL_MAP_I_TO_I_SIZE = 3248;

		// Token: 0x0400524B RID: 21067
		public const ushort GL_PIXEL_MAP_I_TO_R_SIZE = 3250;

		// Token: 0x0400524C RID: 21068
		public const ushort GL_PIXEL_MAP_I_TO_G_SIZE = 3251;

		// Token: 0x0400524D RID: 21069
		public const ushort GL_PIXEL_MAP_I_TO_B_SIZE = 3252;

		// Token: 0x0400524E RID: 21070
		public const ushort GL_PIXEL_MAP_I_TO_A_SIZE = 3253;

		// Token: 0x0400524F RID: 21071
		public const ushort GL_PIXEL_MAP_R_TO_R_SIZE = 3254;

		// Token: 0x04005250 RID: 21072
		public const ushort GL_PIXEL_MAP_G_TO_G_SIZE = 3255;

		// Token: 0x04005251 RID: 21073
		public const ushort GL_PIXEL_MAP_B_TO_B_SIZE = 3256;

		// Token: 0x04005252 RID: 21074
		public const ushort GL_PIXEL_MAP_A_TO_A_SIZE = 3257;

		// Token: 0x04005253 RID: 21075
		public const ushort GL_PIXEL_MAP_S_TO_S = 3185;

		// Token: 0x04005254 RID: 21076
		public const ushort GL_PIXEL_MAP_I_TO_I = 3184;

		// Token: 0x04005255 RID: 21077
		public const ushort GL_PIXEL_MAP_I_TO_R = 3186;

		// Token: 0x04005256 RID: 21078
		public const ushort GL_PIXEL_MAP_I_TO_G = 3187;

		// Token: 0x04005257 RID: 21079
		public const ushort GL_PIXEL_MAP_I_TO_B = 3188;

		// Token: 0x04005258 RID: 21080
		public const ushort GL_PIXEL_MAP_I_TO_A = 3189;

		// Token: 0x04005259 RID: 21081
		public const ushort GL_PIXEL_MAP_R_TO_R = 3190;

		// Token: 0x0400525A RID: 21082
		public const ushort GL_PIXEL_MAP_G_TO_G = 3191;

		// Token: 0x0400525B RID: 21083
		public const ushort GL_PIXEL_MAP_B_TO_B = 3192;

		// Token: 0x0400525C RID: 21084
		public const ushort GL_PIXEL_MAP_A_TO_A = 3193;

		// Token: 0x0400525D RID: 21085
		public const ushort GL_PACK_ALIGNMENT = 3333;

		// Token: 0x0400525E RID: 21086
		public const ushort GL_PACK_LSB_FIRST = 3329;

		// Token: 0x0400525F RID: 21087
		public const ushort GL_PACK_ROW_LENGTH = 3330;

		// Token: 0x04005260 RID: 21088
		public const ushort GL_PACK_SKIP_PIXELS = 3332;

		// Token: 0x04005261 RID: 21089
		public const ushort GL_PACK_SKIP_ROWS = 3331;

		// Token: 0x04005262 RID: 21090
		public const ushort GL_PACK_SWAP_BYTES = 3328;

		// Token: 0x04005263 RID: 21091
		public const ushort GL_UNPACK_ALIGNMENT = 3317;

		// Token: 0x04005264 RID: 21092
		public const ushort GL_UNPACK_LSB_FIRST = 3313;

		// Token: 0x04005265 RID: 21093
		public const ushort GL_UNPACK_ROW_LENGTH = 3314;

		// Token: 0x04005266 RID: 21094
		public const ushort GL_UNPACK_SKIP_PIXELS = 3316;

		// Token: 0x04005267 RID: 21095
		public const ushort GL_UNPACK_SKIP_ROWS = 3315;

		// Token: 0x04005268 RID: 21096
		public const ushort GL_UNPACK_SWAP_BYTES = 3312;

		// Token: 0x04005269 RID: 21097
		public const ushort GL_ZOOM_X = 3350;

		// Token: 0x0400526A RID: 21098
		public const ushort GL_ZOOM_Y = 3351;

		// Token: 0x0400526B RID: 21099
		public const ushort GL_TEXTURE_ENV = 8960;

		// Token: 0x0400526C RID: 21100
		public const ushort GL_TEXTURE_ENV_MODE = 8704;

		// Token: 0x0400526D RID: 21101
		public const ushort GL_TEXTURE_1D = 3552;

		// Token: 0x0400526E RID: 21102
		public const ushort GL_TEXTURE_2D = 3553;

		// Token: 0x0400526F RID: 21103
		public const ushort GL_TEXTURE_WRAP_S = 10242;

		// Token: 0x04005270 RID: 21104
		public const ushort GL_TEXTURE_WRAP_T = 10243;

		// Token: 0x04005271 RID: 21105
		public const ushort GL_TEXTURE_MAG_FILTER = 10240;

		// Token: 0x04005272 RID: 21106
		public const ushort GL_TEXTURE_MIN_FILTER = 10241;

		// Token: 0x04005273 RID: 21107
		public const ushort GL_TEXTURE_ENV_COLOR = 8705;

		// Token: 0x04005274 RID: 21108
		public const ushort GL_TEXTURE_GEN_S = 3168;

		// Token: 0x04005275 RID: 21109
		public const ushort GL_TEXTURE_GEN_T = 3169;

		// Token: 0x04005276 RID: 21110
		public const ushort GL_TEXTURE_GEN_MODE = 9472;

		// Token: 0x04005277 RID: 21111
		public const ushort GL_TEXTURE_BORDER_COLOR = 4100;

		// Token: 0x04005278 RID: 21112
		public const ushort GL_TEXTURE_WIDTH = 4096;

		// Token: 0x04005279 RID: 21113
		public const ushort GL_TEXTURE_HEIGHT = 4097;

		// Token: 0x0400527A RID: 21114
		public const ushort GL_TEXTURE_BORDER = 4101;

		// Token: 0x0400527B RID: 21115
		public const ushort GL_TEXTURE_COMPONENTS = 4099;

		// Token: 0x0400527C RID: 21116
		public const ushort GL_TEXTURE_RED_SIZE = 32860;

		// Token: 0x0400527D RID: 21117
		public const ushort GL_TEXTURE_GREEN_SIZE = 32861;

		// Token: 0x0400527E RID: 21118
		public const ushort GL_TEXTURE_BLUE_SIZE = 32862;

		// Token: 0x0400527F RID: 21119
		public const ushort GL_TEXTURE_ALPHA_SIZE = 32863;

		// Token: 0x04005280 RID: 21120
		public const ushort GL_TEXTURE_LUMINANCE_SIZE = 32864;

		// Token: 0x04005281 RID: 21121
		public const ushort GL_TEXTURE_INTENSITY_SIZE = 32865;

		// Token: 0x04005282 RID: 21122
		public const ushort GL_NEAREST_MIPMAP_NEAREST = 9984;

		// Token: 0x04005283 RID: 21123
		public const ushort GL_NEAREST_MIPMAP_LINEAR = 9986;

		// Token: 0x04005284 RID: 21124
		public const ushort GL_LINEAR_MIPMAP_NEAREST = 9985;

		// Token: 0x04005285 RID: 21125
		public const ushort GL_LINEAR_MIPMAP_LINEAR = 9987;

		// Token: 0x04005286 RID: 21126
		public const ushort GL_OBJECT_LINEAR = 9217;

		// Token: 0x04005287 RID: 21127
		public const ushort GL_OBJECT_PLANE = 9473;

		// Token: 0x04005288 RID: 21128
		public const ushort GL_EYE_LINEAR = 9216;

		// Token: 0x04005289 RID: 21129
		public const ushort GL_EYE_PLANE = 9474;

		// Token: 0x0400528A RID: 21130
		public const ushort GL_SPHERE_MAP = 9218;

		// Token: 0x0400528B RID: 21131
		public const ushort GL_DECAL = 8449;

		// Token: 0x0400528C RID: 21132
		public const ushort GL_MODULATE = 8448;

		// Token: 0x0400528D RID: 21133
		public const ushort GL_NEAREST = 9728;

		// Token: 0x0400528E RID: 21134
		public const ushort GL_REPEAT = 10497;

		// Token: 0x0400528F RID: 21135
		public const ushort GL_CLAMP = 10496;

		// Token: 0x04005290 RID: 21136
		public const ushort GL_S = 8192;

		// Token: 0x04005291 RID: 21137
		public const ushort GL_T = 8193;

		// Token: 0x04005292 RID: 21138
		public const ushort GL_R = 8194;

		// Token: 0x04005293 RID: 21139
		public const ushort GL_Q = 8195;

		// Token: 0x04005294 RID: 21140
		public const ushort GL_TEXTURE_GEN_R = 3170;

		// Token: 0x04005295 RID: 21141
		public const ushort GL_TEXTURE_GEN_Q = 3171;

		// Token: 0x04005296 RID: 21142
		public const ushort GL_VENDOR = 7936;

		// Token: 0x04005297 RID: 21143
		public const ushort GL_RENDERER = 7937;

		// Token: 0x04005298 RID: 21144
		public const ushort GL_VERSION = 7938;

		// Token: 0x04005299 RID: 21145
		public const ushort GL_EXTENSIONS = 7939;

		// Token: 0x0400529A RID: 21146
		public const ushort GL_NO_ERROR = 0;

		// Token: 0x0400529B RID: 21147
		public const ushort GL_INVALID_ENUM = 1280;

		// Token: 0x0400529C RID: 21148
		public const ushort GL_INVALID_VALUE = 1281;

		// Token: 0x0400529D RID: 21149
		public const ushort GL_INVALID_OPERATION = 1282;

		// Token: 0x0400529E RID: 21150
		public const ushort GL_STACK_OVERFLOW = 1283;

		// Token: 0x0400529F RID: 21151
		public const ushort GL_STACK_UNDERFLOW = 1284;

		// Token: 0x040052A0 RID: 21152
		public const ushort GL_OUT_OF_MEMORY = 1285;

		// Token: 0x040052A1 RID: 21153
		public const int GL_CURRENT_BIT = 1;

		// Token: 0x040052A2 RID: 21154
		public const int GL_POINT_BIT = 2;

		// Token: 0x040052A3 RID: 21155
		public const int GL_LINE_BIT = 4;

		// Token: 0x040052A4 RID: 21156
		public const int GL_POLYGON_BIT = 8;

		// Token: 0x040052A5 RID: 21157
		public const int GL_POLYGON_STIPPLE_BIT = 16;

		// Token: 0x040052A6 RID: 21158
		public const int GL_PIXEL_MODE_BIT = 32;

		// Token: 0x040052A7 RID: 21159
		public const int GL_LIGHTING_BIT = 64;

		// Token: 0x040052A8 RID: 21160
		public const int GL_FOG_BIT = 128;

		// Token: 0x040052A9 RID: 21161
		public const int GL_DEPTH_BUFFER_BIT = 256;

		// Token: 0x040052AA RID: 21162
		public const int GL_ACCUM_BUFFER_BIT = 512;

		// Token: 0x040052AB RID: 21163
		public const int GL_STENCIL_BUFFER_BIT = 1024;

		// Token: 0x040052AC RID: 21164
		public const int GL_VIEWPORT_BIT = 2048;

		// Token: 0x040052AD RID: 21165
		public const int GL_TRANSFORM_BIT = 4096;

		// Token: 0x040052AE RID: 21166
		public const int GL_ENABLE_BIT = 8192;

		// Token: 0x040052AF RID: 21167
		public const int GL_COLOR_BUFFER_BIT = 16384;

		// Token: 0x040052B0 RID: 21168
		public const int GL_HINT_BIT = 32768;

		// Token: 0x040052B1 RID: 21169
		public const int GL_EVAL_BIT = 65536;

		// Token: 0x040052B2 RID: 21170
		public const int GL_LIST_BIT = 131072;

		// Token: 0x040052B3 RID: 21171
		public const int GL_TEXTURE_BIT = 262144;

		// Token: 0x040052B4 RID: 21172
		public const int GL_SCISSOR_BIT = 524288;

		// Token: 0x040052B5 RID: 21173
		public const int GL_ALL_ATTRIB_BITS = 1048575;

		// Token: 0x040052B6 RID: 21174
		public const ushort GL_PROXY_TEXTURE_1D = 32867;

		// Token: 0x040052B7 RID: 21175
		public const ushort GL_PROXY_TEXTURE_2D = 32868;

		// Token: 0x040052B8 RID: 21176
		public const ushort GL_TEXTURE_PRIORITY = 32870;

		// Token: 0x040052B9 RID: 21177
		public const ushort GL_TEXTURE_RESIDENT = 32871;

		// Token: 0x040052BA RID: 21178
		public const ushort GL_TEXTURE_BINDING_1D = 32872;

		// Token: 0x040052BB RID: 21179
		public const ushort GL_TEXTURE_BINDING_2D = 32873;

		// Token: 0x040052BC RID: 21180
		public const ushort GL_TEXTURE_INTERNAL_FORMAT = 4099;

		// Token: 0x040052BD RID: 21181
		public const ushort GL_ALPHA4 = 32827;

		// Token: 0x040052BE RID: 21182
		public const ushort GL_ALPHA8 = 32828;

		// Token: 0x040052BF RID: 21183
		public const ushort GL_ALPHA12 = 32829;

		// Token: 0x040052C0 RID: 21184
		public const ushort GL_ALPHA16 = 32830;

		// Token: 0x040052C1 RID: 21185
		public const ushort GL_LUMINANCE4 = 32831;

		// Token: 0x040052C2 RID: 21186
		public const ushort GL_LUMINANCE8 = 32832;

		// Token: 0x040052C3 RID: 21187
		public const ushort GL_LUMINANCE12 = 32833;

		// Token: 0x040052C4 RID: 21188
		public const ushort GL_LUMINANCE16 = 32834;

		// Token: 0x040052C5 RID: 21189
		public const ushort GL_LUMINANCE4_ALPHA4 = 32835;

		// Token: 0x040052C6 RID: 21190
		public const ushort GL_LUMINANCE6_ALPHA2 = 32836;

		// Token: 0x040052C7 RID: 21191
		public const ushort GL_LUMINANCE8_ALPHA8 = 32837;

		// Token: 0x040052C8 RID: 21192
		public const ushort GL_LUMINANCE12_ALPHA4 = 32838;

		// Token: 0x040052C9 RID: 21193
		public const ushort GL_LUMINANCE12_ALPHA12 = 32839;

		// Token: 0x040052CA RID: 21194
		public const ushort GL_LUMINANCE16_ALPHA16 = 32840;

		// Token: 0x040052CB RID: 21195
		public const ushort GL_INTENSITY = 32841;

		// Token: 0x040052CC RID: 21196
		public const ushort GL_INTENSITY4 = 32842;

		// Token: 0x040052CD RID: 21197
		public const ushort GL_INTENSITY8 = 32843;

		// Token: 0x040052CE RID: 21198
		public const ushort GL_INTENSITY12 = 32844;

		// Token: 0x040052CF RID: 21199
		public const ushort GL_INTENSITY16 = 32845;

		// Token: 0x040052D0 RID: 21200
		public const ushort GL_R3_G3_B2 = 10768;

		// Token: 0x040052D1 RID: 21201
		public const ushort GL_RGB4 = 32847;

		// Token: 0x040052D2 RID: 21202
		public const ushort GL_RGB5 = 32848;

		// Token: 0x040052D3 RID: 21203
		public const ushort GL_RGB8 = 32849;

		// Token: 0x040052D4 RID: 21204
		public const ushort GL_RGB10 = 32850;

		// Token: 0x040052D5 RID: 21205
		public const ushort GL_RGB12 = 32851;

		// Token: 0x040052D6 RID: 21206
		public const ushort GL_RGB16 = 32852;

		// Token: 0x040052D7 RID: 21207
		public const ushort GL_RGBA2 = 32853;

		// Token: 0x040052D8 RID: 21208
		public const ushort GL_RGBA4 = 32854;

		// Token: 0x040052D9 RID: 21209
		public const ushort GL_RGB5_A1 = 32855;

		// Token: 0x040052DA RID: 21210
		public const ushort GL_RGBA8 = 32856;

		// Token: 0x040052DB RID: 21211
		public const ushort GL_RGB10_A2 = 32857;

		// Token: 0x040052DC RID: 21212
		public const ushort GL_RGBA12 = 32858;

		// Token: 0x040052DD RID: 21213
		public const ushort GL_RGBA16 = 32859;

		// Token: 0x040052DE RID: 21214
		public const uint GL_CLIENT_PIXEL_STORE_BIT = 1U;

		// Token: 0x040052DF RID: 21215
		public const uint GL_CLIENT_VERTEX_ARRAY_BIT = 2U;

		// Token: 0x040052E0 RID: 21216
		public const uint GL_ALL_CLIENT_ATTRIB_BITS = 4294967295U;

		// Token: 0x040052E1 RID: 21217
		public const uint GL_CLIENT_ALL_ATTRIB_BITS = 4294967295U;

		// Token: 0x040052E2 RID: 21218
		public const ushort GL_RESCALE_NORMAL = 32826;

		// Token: 0x040052E3 RID: 21219
		public const ushort GL_CLAMP_TO_EDGE = 33071;

		// Token: 0x040052E4 RID: 21220
		public const ushort GL_MAX_ELEMENTS_VERTICES = 33000;

		// Token: 0x040052E5 RID: 21221
		public const ushort GL_MAX_ELEMENTS_INDICES = 33001;

		// Token: 0x040052E6 RID: 21222
		public const ushort GL_BGR = 32992;

		// Token: 0x040052E7 RID: 21223
		public const ushort GL_BGRA = 32993;

		// Token: 0x040052E8 RID: 21224
		public const ushort GL_UNSIGNED_BYTE_3_3_2 = 32818;

		// Token: 0x040052E9 RID: 21225
		public const ushort GL_UNSIGNED_BYTE_2_3_3_REV = 33634;

		// Token: 0x040052EA RID: 21226
		public const ushort GL_UNSIGNED_SHORT_5_6_5 = 33635;

		// Token: 0x040052EB RID: 21227
		public const ushort GL_UNSIGNED_SHORT_5_6_5_REV = 33636;

		// Token: 0x040052EC RID: 21228
		public const ushort GL_UNSIGNED_SHORT_4_4_4_4 = 32819;

		// Token: 0x040052ED RID: 21229
		public const ushort GL_UNSIGNED_SHORT_4_4_4_4_REV = 33637;

		// Token: 0x040052EE RID: 21230
		public const ushort GL_UNSIGNED_SHORT_5_5_5_1 = 32820;

		// Token: 0x040052EF RID: 21231
		public const ushort GL_UNSIGNED_SHORT_1_5_5_5_REV = 33638;

		// Token: 0x040052F0 RID: 21232
		public const ushort GL_UNSIGNED_INT_8_8_8_8 = 32821;

		// Token: 0x040052F1 RID: 21233
		public const ushort GL_UNSIGNED_INT_8_8_8_8_REV = 33639;

		// Token: 0x040052F2 RID: 21234
		public const ushort GL_UNSIGNED_INT_10_10_10_2 = 32822;

		// Token: 0x040052F3 RID: 21235
		public const ushort GL_UNSIGNED_INT_2_10_10_10_REV = 33640;

		// Token: 0x040052F4 RID: 21236
		public const ushort GL_LIGHT_MODEL_COLOR_CONTROL = 33272;

		// Token: 0x040052F5 RID: 21237
		public const ushort GL_SINGLE_COLOR = 33273;

		// Token: 0x040052F6 RID: 21238
		public const ushort GL_SEPARATE_SPECULAR_COLOR = 33274;

		// Token: 0x040052F7 RID: 21239
		public const ushort GL_TEXTURE_MIN_LOD = 33082;

		// Token: 0x040052F8 RID: 21240
		public const ushort GL_TEXTURE_MAX_LOD = 33083;

		// Token: 0x040052F9 RID: 21241
		public const ushort GL_TEXTURE_BASE_LEVEL = 33084;

		// Token: 0x040052FA RID: 21242
		public const ushort GL_TEXTURE_MAX_LEVEL = 33085;

		// Token: 0x040052FB RID: 21243
		public const ushort GL_SMOOTH_POINT_SIZE_RANGE = 2834;

		// Token: 0x040052FC RID: 21244
		public const ushort GL_SMOOTH_POINT_SIZE_GRANULARITY = 2835;

		// Token: 0x040052FD RID: 21245
		public const ushort GL_SMOOTH_LINE_WIDTH_RANGE = 2850;

		// Token: 0x040052FE RID: 21246
		public const ushort GL_SMOOTH_LINE_WIDTH_GRANULARITY = 2851;

		// Token: 0x040052FF RID: 21247
		public const ushort GL_ALIASED_POINT_SIZE_RANGE = 33901;

		// Token: 0x04005300 RID: 21248
		public const ushort GL_ALIASED_LINE_WIDTH_RANGE = 33902;

		// Token: 0x04005301 RID: 21249
		public const ushort GL_PACK_SKIP_IMAGES = 32875;

		// Token: 0x04005302 RID: 21250
		public const ushort GL_PACK_IMAGE_HEIGHT = 32876;

		// Token: 0x04005303 RID: 21251
		public const ushort GL_UNPACK_SKIP_IMAGES = 32877;

		// Token: 0x04005304 RID: 21252
		public const ushort GL_UNPACK_IMAGE_HEIGHT = 32878;

		// Token: 0x04005305 RID: 21253
		public const ushort GL_TEXTURE_3D = 32879;

		// Token: 0x04005306 RID: 21254
		public const ushort GL_PROXY_TEXTURE_3D = 32880;

		// Token: 0x04005307 RID: 21255
		public const ushort GL_TEXTURE_DEPTH = 32881;

		// Token: 0x04005308 RID: 21256
		public const ushort GL_TEXTURE_WRAP_R = 32882;

		// Token: 0x04005309 RID: 21257
		public const ushort GL_MAX_3D_TEXTURE_SIZE = 32883;

		// Token: 0x0400530A RID: 21258
		public const ushort GL_TEXTURE_BINDING_3D = 32874;

		// Token: 0x0400530B RID: 21259
		public const ushort GL_CONSTANT_COLOR = 32769;

		// Token: 0x0400530C RID: 21260
		public const ushort GL_ONE_MINUS_CONSTANT_COLOR = 32770;

		// Token: 0x0400530D RID: 21261
		public const ushort GL_CONSTANT_ALPHA = 32771;

		// Token: 0x0400530E RID: 21262
		public const ushort GL_ONE_MINUS_CONSTANT_ALPHA = 32772;

		// Token: 0x0400530F RID: 21263
		public const ushort GL_COLOR_TABLE = 32976;

		// Token: 0x04005310 RID: 21264
		public const ushort GL_POST_CONVOLUTION_COLOR_TABLE = 32977;

		// Token: 0x04005311 RID: 21265
		public const ushort GL_POST_COLOR_MATRIX_COLOR_TABLE = 32978;

		// Token: 0x04005312 RID: 21266
		public const ushort GL_PROXY_COLOR_TABLE = 32979;

		// Token: 0x04005313 RID: 21267
		public const ushort GL_PROXY_POST_CONVOLUTION_COLOR_TABLE = 32980;

		// Token: 0x04005314 RID: 21268
		public const ushort GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE = 32981;

		// Token: 0x04005315 RID: 21269
		public const ushort GL_COLOR_TABLE_SCALE = 32982;

		// Token: 0x04005316 RID: 21270
		public const ushort GL_COLOR_TABLE_BIAS = 32983;

		// Token: 0x04005317 RID: 21271
		public const ushort GL_COLOR_TABLE_FORMAT = 32984;

		// Token: 0x04005318 RID: 21272
		public const ushort GL_COLOR_TABLE_WIDTH = 32985;

		// Token: 0x04005319 RID: 21273
		public const ushort GL_COLOR_TABLE_RED_SIZE = 32986;

		// Token: 0x0400531A RID: 21274
		public const ushort GL_COLOR_TABLE_GREEN_SIZE = 32987;

		// Token: 0x0400531B RID: 21275
		public const ushort GL_COLOR_TABLE_BLUE_SIZE = 32988;

		// Token: 0x0400531C RID: 21276
		public const ushort GL_COLOR_TABLE_ALPHA_SIZE = 32989;

		// Token: 0x0400531D RID: 21277
		public const ushort GL_COLOR_TABLE_LUMINANCE_SIZE = 32990;

		// Token: 0x0400531E RID: 21278
		public const ushort GL_COLOR_TABLE_INTENSITY_SIZE = 32991;

		// Token: 0x0400531F RID: 21279
		public const ushort GL_CONVOLUTION_1D = 32784;

		// Token: 0x04005320 RID: 21280
		public const ushort GL_CONVOLUTION_2D = 32785;

		// Token: 0x04005321 RID: 21281
		public const ushort GL_SEPARABLE_2D = 32786;

		// Token: 0x04005322 RID: 21282
		public const ushort GL_CONVOLUTION_BORDER_MODE = 32787;

		// Token: 0x04005323 RID: 21283
		public const ushort GL_CONVOLUTION_FILTER_SCALE = 32788;

		// Token: 0x04005324 RID: 21284
		public const ushort GL_CONVOLUTION_FILTER_BIAS = 32789;

		// Token: 0x04005325 RID: 21285
		public const ushort GL_REDUCE = 32790;

		// Token: 0x04005326 RID: 21286
		public const ushort GL_CONVOLUTION_FORMAT = 32791;

		// Token: 0x04005327 RID: 21287
		public const ushort GL_CONVOLUTION_WIDTH = 32792;

		// Token: 0x04005328 RID: 21288
		public const ushort GL_CONVOLUTION_HEIGHT = 32793;

		// Token: 0x04005329 RID: 21289
		public const ushort GL_MAX_CONVOLUTION_WIDTH = 32794;

		// Token: 0x0400532A RID: 21290
		public const ushort GL_MAX_CONVOLUTION_HEIGHT = 32795;

		// Token: 0x0400532B RID: 21291
		public const ushort GL_POST_CONVOLUTION_RED_SCALE = 32796;

		// Token: 0x0400532C RID: 21292
		public const ushort GL_POST_CONVOLUTION_GREEN_SCALE = 32797;

		// Token: 0x0400532D RID: 21293
		public const ushort GL_POST_CONVOLUTION_BLUE_SCALE = 32798;

		// Token: 0x0400532E RID: 21294
		public const ushort GL_POST_CONVOLUTION_ALPHA_SCALE = 32799;

		// Token: 0x0400532F RID: 21295
		public const ushort GL_POST_CONVOLUTION_RED_BIAS = 32800;

		// Token: 0x04005330 RID: 21296
		public const ushort GL_POST_CONVOLUTION_GREEN_BIAS = 32801;

		// Token: 0x04005331 RID: 21297
		public const ushort GL_POST_CONVOLUTION_BLUE_BIAS = 32802;

		// Token: 0x04005332 RID: 21298
		public const ushort GL_POST_CONVOLUTION_ALPHA_BIAS = 32803;

		// Token: 0x04005333 RID: 21299
		public const ushort GL_CONSTANT_BORDER = 33105;

		// Token: 0x04005334 RID: 21300
		public const ushort GL_REPLICATE_BORDER = 33107;

		// Token: 0x04005335 RID: 21301
		public const ushort GL_CONVOLUTION_BORDER_COLOR = 33108;

		// Token: 0x04005336 RID: 21302
		public const ushort GL_COLOR_MATRIX = 32945;

		// Token: 0x04005337 RID: 21303
		public const ushort GL_COLOR_MATRIX_STACK_DEPTH = 32946;

		// Token: 0x04005338 RID: 21304
		public const ushort GL_MAX_COLOR_MATRIX_STACK_DEPTH = 32947;

		// Token: 0x04005339 RID: 21305
		public const ushort GL_POST_COLOR_MATRIX_RED_SCALE = 32948;

		// Token: 0x0400533A RID: 21306
		public const ushort GL_POST_COLOR_MATRIX_GREEN_SCALE = 32949;

		// Token: 0x0400533B RID: 21307
		public const ushort GL_POST_COLOR_MATRIX_BLUE_SCALE = 32950;

		// Token: 0x0400533C RID: 21308
		public const ushort GL_POST_COLOR_MATRIX_ALPHA_SCALE = 32951;

		// Token: 0x0400533D RID: 21309
		public const ushort GL_POST_COLOR_MATRIX_RED_BIAS = 32952;

		// Token: 0x0400533E RID: 21310
		public const ushort GL_POST_COLOR_MATRIX_GREEN_BIAS = 32953;

		// Token: 0x0400533F RID: 21311
		public const ushort GL_POST_COLOR_MATRIX_BLUE_BIAS = 32954;

		// Token: 0x04005340 RID: 21312
		public const ushort GL_POST_COLOR_MATRIX_ALPHA_BIAS = 32955;

		// Token: 0x04005341 RID: 21313
		public const ushort GL_HISTOGRAM = 32804;

		// Token: 0x04005342 RID: 21314
		public const ushort GL_PROXY_HISTOGRAM = 32805;

		// Token: 0x04005343 RID: 21315
		public const ushort GL_HISTOGRAM_WIDTH = 32806;

		// Token: 0x04005344 RID: 21316
		public const ushort GL_HISTOGRAM_FORMAT = 32807;

		// Token: 0x04005345 RID: 21317
		public const ushort GL_HISTOGRAM_RED_SIZE = 32808;

		// Token: 0x04005346 RID: 21318
		public const ushort GL_HISTOGRAM_GREEN_SIZE = 32809;

		// Token: 0x04005347 RID: 21319
		public const ushort GL_HISTOGRAM_BLUE_SIZE = 32810;

		// Token: 0x04005348 RID: 21320
		public const ushort GL_HISTOGRAM_ALPHA_SIZE = 32811;

		// Token: 0x04005349 RID: 21321
		public const ushort GL_HISTOGRAM_LUMINANCE_SIZE = 32812;

		// Token: 0x0400534A RID: 21322
		public const ushort GL_HISTOGRAM_SINK = 32813;

		// Token: 0x0400534B RID: 21323
		public const ushort GL_MINMAX = 32814;

		// Token: 0x0400534C RID: 21324
		public const ushort GL_MINMAX_FORMAT = 32815;

		// Token: 0x0400534D RID: 21325
		public const ushort GL_MINMAX_SINK = 32816;

		// Token: 0x0400534E RID: 21326
		public const ushort GL_TABLE_TOO_LARGE = 32817;

		// Token: 0x0400534F RID: 21327
		public const ushort GL_BLEND_EQUATION = 32777;

		// Token: 0x04005350 RID: 21328
		public const ushort GL_MIN = 32775;

		// Token: 0x04005351 RID: 21329
		public const ushort GL_MAX = 32776;

		// Token: 0x04005352 RID: 21330
		public const ushort GL_FUNC_ADD = 32774;

		// Token: 0x04005353 RID: 21331
		public const ushort GL_FUNC_SUBTRACT = 32778;

		// Token: 0x04005354 RID: 21332
		public const ushort GL_FUNC_REVERSE_SUBTRACT = 32779;

		// Token: 0x04005355 RID: 21333
		public const ushort GL_BLEND_COLOR = 32773;

		// Token: 0x04005356 RID: 21334
		public const ushort GL_TEXTURE0 = 33984;

		// Token: 0x04005357 RID: 21335
		public const ushort GL_TEXTURE1 = 33985;

		// Token: 0x04005358 RID: 21336
		public const ushort GL_TEXTURE2 = 33986;

		// Token: 0x04005359 RID: 21337
		public const ushort GL_TEXTURE3 = 33987;

		// Token: 0x0400535A RID: 21338
		public const ushort GL_TEXTURE4 = 33988;

		// Token: 0x0400535B RID: 21339
		public const ushort GL_TEXTURE5 = 33989;

		// Token: 0x0400535C RID: 21340
		public const ushort GL_TEXTURE6 = 33990;

		// Token: 0x0400535D RID: 21341
		public const ushort GL_TEXTURE7 = 33991;

		// Token: 0x0400535E RID: 21342
		public const ushort GL_TEXTURE8 = 33992;

		// Token: 0x0400535F RID: 21343
		public const ushort GL_TEXTURE9 = 33993;

		// Token: 0x04005360 RID: 21344
		public const ushort GL_TEXTURE10 = 33994;

		// Token: 0x04005361 RID: 21345
		public const ushort GL_TEXTURE11 = 33995;

		// Token: 0x04005362 RID: 21346
		public const ushort GL_TEXTURE12 = 33996;

		// Token: 0x04005363 RID: 21347
		public const ushort GL_TEXTURE13 = 33997;

		// Token: 0x04005364 RID: 21348
		public const ushort GL_TEXTURE14 = 33998;

		// Token: 0x04005365 RID: 21349
		public const ushort GL_TEXTURE15 = 33999;

		// Token: 0x04005366 RID: 21350
		public const ushort GL_TEXTURE16 = 34000;

		// Token: 0x04005367 RID: 21351
		public const ushort GL_TEXTURE17 = 34001;

		// Token: 0x04005368 RID: 21352
		public const ushort GL_TEXTURE18 = 34002;

		// Token: 0x04005369 RID: 21353
		public const ushort GL_TEXTURE19 = 34003;

		// Token: 0x0400536A RID: 21354
		public const ushort GL_TEXTURE20 = 34004;

		// Token: 0x0400536B RID: 21355
		public const ushort GL_TEXTURE21 = 34005;

		// Token: 0x0400536C RID: 21356
		public const ushort GL_TEXTURE22 = 34006;

		// Token: 0x0400536D RID: 21357
		public const ushort GL_TEXTURE23 = 34007;

		// Token: 0x0400536E RID: 21358
		public const ushort GL_TEXTURE24 = 34008;

		// Token: 0x0400536F RID: 21359
		public const ushort GL_TEXTURE25 = 34009;

		// Token: 0x04005370 RID: 21360
		public const ushort GL_TEXTURE26 = 34010;

		// Token: 0x04005371 RID: 21361
		public const ushort GL_TEXTURE27 = 34011;

		// Token: 0x04005372 RID: 21362
		public const ushort GL_TEXTURE28 = 34012;

		// Token: 0x04005373 RID: 21363
		public const ushort GL_TEXTURE29 = 34013;

		// Token: 0x04005374 RID: 21364
		public const ushort GL_TEXTURE30 = 34014;

		// Token: 0x04005375 RID: 21365
		public const ushort GL_TEXTURE31 = 34015;

		// Token: 0x04005376 RID: 21366
		public const ushort GL_ACTIVE_TEXTURE = 34016;

		// Token: 0x04005377 RID: 21367
		public const ushort GL_CLIENT_ACTIVE_TEXTURE = 34017;

		// Token: 0x04005378 RID: 21368
		public const ushort GL_MAX_TEXTURE_UNITS = 34018;

		// Token: 0x04005379 RID: 21369
		public const ushort GL_NORMAL_MAP = 34065;

		// Token: 0x0400537A RID: 21370
		public const ushort GL_REFLECTION_MAP = 34066;

		// Token: 0x0400537B RID: 21371
		public const ushort GL_TEXTURE_CUBE_MAP = 34067;

		// Token: 0x0400537C RID: 21372
		public const ushort GL_TEXTURE_BINDING_CUBE_MAP = 34068;

		// Token: 0x0400537D RID: 21373
		public const ushort GL_TEXTURE_CUBE_MAP_POSITIVE_X = 34069;

		// Token: 0x0400537E RID: 21374
		public const ushort GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 34070;

		// Token: 0x0400537F RID: 21375
		public const ushort GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 34071;

		// Token: 0x04005380 RID: 21376
		public const ushort GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 34072;

		// Token: 0x04005381 RID: 21377
		public const ushort GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 34073;

		// Token: 0x04005382 RID: 21378
		public const ushort GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 34074;

		// Token: 0x04005383 RID: 21379
		public const ushort GL_PROXY_TEXTURE_CUBE_MAP = 34075;

		// Token: 0x04005384 RID: 21380
		public const ushort GL_MAX_CUBE_MAP_TEXTURE_SIZE = 34076;

		// Token: 0x04005385 RID: 21381
		public const ushort GL_COMPRESSED_ALPHA = 34025;

		// Token: 0x04005386 RID: 21382
		public const ushort GL_COMPRESSED_LUMINANCE = 34026;

		// Token: 0x04005387 RID: 21383
		public const ushort GL_COMPRESSED_LUMINANCE_ALPHA = 34027;

		// Token: 0x04005388 RID: 21384
		public const ushort GL_COMPRESSED_INTENSITY = 34028;

		// Token: 0x04005389 RID: 21385
		public const ushort GL_COMPRESSED_RGB = 34029;

		// Token: 0x0400538A RID: 21386
		public const ushort GL_COMPRESSED_RGBA = 34030;

		// Token: 0x0400538B RID: 21387
		public const ushort GL_TEXTURE_COMPRESSION_HINT = 34031;

		// Token: 0x0400538C RID: 21388
		public const ushort GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 34464;

		// Token: 0x0400538D RID: 21389
		public const ushort GL_TEXTURE_COMPRESSED = 34465;

		// Token: 0x0400538E RID: 21390
		public const ushort GL_NUM_COMPRESSED_TEXTURE_FORMATS = 34466;

		// Token: 0x0400538F RID: 21391
		public const ushort GL_COMPRESSED_TEXTURE_FORMATS = 34467;

		// Token: 0x04005390 RID: 21392
		public const ushort GL_MULTISAMPLE = 32925;

		// Token: 0x04005391 RID: 21393
		public const ushort GL_SAMPLE_ALPHA_TO_COVERAGE = 32926;

		// Token: 0x04005392 RID: 21394
		public const ushort GL_SAMPLE_ALPHA_TO_ONE = 32927;

		// Token: 0x04005393 RID: 21395
		public const ushort GL_SAMPLE_COVERAGE = 32928;

		// Token: 0x04005394 RID: 21396
		public const ushort GL_SAMPLE_BUFFERS = 32936;

		// Token: 0x04005395 RID: 21397
		public const ushort GL_SAMPLES = 32937;

		// Token: 0x04005396 RID: 21398
		public const ushort GL_SAMPLE_COVERAGE_VALUE = 32938;

		// Token: 0x04005397 RID: 21399
		public const ushort GL_SAMPLE_COVERAGE_INVERT = 32939;

		// Token: 0x04005398 RID: 21400
		public const uint GL_MULTISAMPLE_BIT = 536870912U;

		// Token: 0x04005399 RID: 21401
		public const ushort GL_TRANSPOSE_MODELVIEW_MATRIX = 34019;

		// Token: 0x0400539A RID: 21402
		public const ushort GL_TRANSPOSE_PROJECTION_MATRIX = 34020;

		// Token: 0x0400539B RID: 21403
		public const ushort GL_TRANSPOSE_TEXTURE_MATRIX = 34021;

		// Token: 0x0400539C RID: 21404
		public const ushort GL_TRANSPOSE_COLOR_MATRIX = 34022;

		// Token: 0x0400539D RID: 21405
		public const ushort GL_COMBINE = 34160;

		// Token: 0x0400539E RID: 21406
		public const ushort GL_COMBINE_RGB = 34161;

		// Token: 0x0400539F RID: 21407
		public const ushort GL_COMBINE_ALPHA = 34162;

		// Token: 0x040053A0 RID: 21408
		public const ushort GL_SOURCE0_RGB = 34176;

		// Token: 0x040053A1 RID: 21409
		public const ushort GL_SOURCE1_RGB = 34177;

		// Token: 0x040053A2 RID: 21410
		public const ushort GL_SOURCE2_RGB = 34178;

		// Token: 0x040053A3 RID: 21411
		public const ushort GL_SOURCE0_ALPHA = 34184;

		// Token: 0x040053A4 RID: 21412
		public const ushort GL_SOURCE1_ALPHA = 34185;

		// Token: 0x040053A5 RID: 21413
		public const ushort GL_SOURCE2_ALPHA = 34186;

		// Token: 0x040053A6 RID: 21414
		public const ushort GL_OPERAND0_RGB = 34192;

		// Token: 0x040053A7 RID: 21415
		public const ushort GL_OPERAND1_RGB = 34193;

		// Token: 0x040053A8 RID: 21416
		public const ushort GL_OPERAND2_RGB = 34194;

		// Token: 0x040053A9 RID: 21417
		public const ushort GL_OPERAND0_ALPHA = 34200;

		// Token: 0x040053AA RID: 21418
		public const ushort GL_OPERAND1_ALPHA = 34201;

		// Token: 0x040053AB RID: 21419
		public const ushort GL_OPERAND2_ALPHA = 34202;

		// Token: 0x040053AC RID: 21420
		public const ushort GL_RGB_SCALE = 34163;

		// Token: 0x040053AD RID: 21421
		public const ushort GL_ADD_SIGNED = 34164;

		// Token: 0x040053AE RID: 21422
		public const ushort GL_INTERPOLATE = 34165;

		// Token: 0x040053AF RID: 21423
		public const ushort GL_SUBTRACT = 34023;

		// Token: 0x040053B0 RID: 21424
		public const ushort GL_CONSTANT = 34166;

		// Token: 0x040053B1 RID: 21425
		public const ushort GL_PRIMARY_COLOR = 34167;

		// Token: 0x040053B2 RID: 21426
		public const ushort GL_PREVIOUS = 34168;

		// Token: 0x040053B3 RID: 21427
		public const ushort GL_DOT3_RGB = 34478;

		// Token: 0x040053B4 RID: 21428
		public const ushort GL_DOT3_RGBA = 34479;

		// Token: 0x040053B5 RID: 21429
		public const ushort GL_CLAMP_TO_BORDER = 33069;

		// Token: 0x040053B6 RID: 21430
		public const ushort GL_TEXTURE0_ARB = 33984;

		// Token: 0x040053B7 RID: 21431
		public const ushort GL_TEXTURE1_ARB = 33985;

		// Token: 0x040053B8 RID: 21432
		public const ushort GL_TEXTURE2_ARB = 33986;

		// Token: 0x040053B9 RID: 21433
		public const ushort GL_TEXTURE3_ARB = 33987;

		// Token: 0x040053BA RID: 21434
		public const ushort GL_TEXTURE4_ARB = 33988;

		// Token: 0x040053BB RID: 21435
		public const ushort GL_TEXTURE5_ARB = 33989;

		// Token: 0x040053BC RID: 21436
		public const ushort GL_TEXTURE6_ARB = 33990;

		// Token: 0x040053BD RID: 21437
		public const ushort GL_TEXTURE7_ARB = 33991;

		// Token: 0x040053BE RID: 21438
		public const ushort GL_TEXTURE8_ARB = 33992;

		// Token: 0x040053BF RID: 21439
		public const ushort GL_TEXTURE9_ARB = 33993;

		// Token: 0x040053C0 RID: 21440
		public const ushort GL_TEXTURE10_ARB = 33994;

		// Token: 0x040053C1 RID: 21441
		public const ushort GL_TEXTURE11_ARB = 33995;

		// Token: 0x040053C2 RID: 21442
		public const ushort GL_TEXTURE12_ARB = 33996;

		// Token: 0x040053C3 RID: 21443
		public const ushort GL_TEXTURE13_ARB = 33997;

		// Token: 0x040053C4 RID: 21444
		public const ushort GL_TEXTURE14_ARB = 33998;

		// Token: 0x040053C5 RID: 21445
		public const ushort GL_TEXTURE15_ARB = 33999;

		// Token: 0x040053C6 RID: 21446
		public const ushort GL_TEXTURE16_ARB = 34000;

		// Token: 0x040053C7 RID: 21447
		public const ushort GL_TEXTURE17_ARB = 34001;

		// Token: 0x040053C8 RID: 21448
		public const ushort GL_TEXTURE18_ARB = 34002;

		// Token: 0x040053C9 RID: 21449
		public const ushort GL_TEXTURE19_ARB = 34003;

		// Token: 0x040053CA RID: 21450
		public const ushort GL_TEXTURE20_ARB = 34004;

		// Token: 0x040053CB RID: 21451
		public const ushort GL_TEXTURE21_ARB = 34005;

		// Token: 0x040053CC RID: 21452
		public const ushort GL_TEXTURE22_ARB = 34006;

		// Token: 0x040053CD RID: 21453
		public const ushort GL_TEXTURE23_ARB = 34007;

		// Token: 0x040053CE RID: 21454
		public const ushort GL_TEXTURE24_ARB = 34008;

		// Token: 0x040053CF RID: 21455
		public const ushort GL_TEXTURE25_ARB = 34009;

		// Token: 0x040053D0 RID: 21456
		public const ushort GL_TEXTURE26_ARB = 34010;

		// Token: 0x040053D1 RID: 21457
		public const ushort GL_TEXTURE27_ARB = 34011;

		// Token: 0x040053D2 RID: 21458
		public const ushort GL_TEXTURE28_ARB = 34012;

		// Token: 0x040053D3 RID: 21459
		public const ushort GL_TEXTURE29_ARB = 34013;

		// Token: 0x040053D4 RID: 21460
		public const ushort GL_TEXTURE30_ARB = 34014;

		// Token: 0x040053D5 RID: 21461
		public const ushort GL_TEXTURE31_ARB = 34015;

		// Token: 0x040053D6 RID: 21462
		public const ushort GL_ACTIVE_TEXTURE_ARB = 34016;

		// Token: 0x040053D7 RID: 21463
		public const ushort GL_CLIENT_ACTIVE_TEXTURE_ARB = 34017;

		// Token: 0x040053D8 RID: 21464
		public const ushort GL_MAX_TEXTURE_UNITS_ARB = 34018;

		// Token: 0x040053D9 RID: 21465
		private static int drawArraysCallsCount = 0;

		// Token: 0x040053DA RID: 21466
		private static OpenGL.DrawArraysCallContext[] drawArraysCalls = new OpenGL.DrawArraysCallContext[256];

		// Token: 0x040053DB RID: 21467
		private static OpenGL.VertexPosTexColNorm[] pendingVertices = new OpenGL.VertexPosTexColNorm[4096];

		// Token: 0x040053DC RID: 21468
		private static int pendingVerticesCount = 0;

		// Token: 0x040053DD RID: 21469
		private static OpenGL.VertexPosTexColNorm[] drawArraysVertices = new OpenGL.VertexPosTexColNorm[16324];

		// Token: 0x040053DE RID: 21470
		private static int verticesToDraw_ = 0;

		// Token: 0x040053DF RID: 21471
		private static PrimitiveType prevPrimType = PrimitiveType.TriangleList;

		// Token: 0x040053E0 RID: 21472
		public static int drawVertexBuffer_Count = 0;

		// Token: 0x040053E1 RID: 21473
		private static OpenGL.VertexPosTexColNorm[] vtxBuffer = new OpenGL.VertexPosTexColNorm[4096];

		// Token: 0x040053E2 RID: 21474
		private static Vector4 posShift = new Vector4(-0.5f, -0.5f, 0f, 0f);

		// Token: 0x040053E3 RID: 21475
		private static OpenGL.GLVertexData[] texCoordData = new OpenGL.GLVertexData[2];

		// Token: 0x040053E4 RID: 21476
		public static int drawPrimitives_Count = 0;

		// Token: 0x040053E5 RID: 21477
		private static GraphicsDevice m_graphicsDevice;

		// Token: 0x040053E6 RID: 21478
		private static BasicEffect m_basicEffect;

		// Token: 0x040053E7 RID: 21479
		private static AlphaTestEffect m_alphaTestEffect;

		// Token: 0x040053E8 RID: 21480
		private static SkinnedEffect m_skinnedEffect;

		// Token: 0x040053E9 RID: 21481
		private static DualTextureEffect m_dualTextureEffect;

		// Token: 0x040053EA RID: 21482
		private static bool m_viewportSet = false;

		// Token: 0x040053EB RID: 21483
		private static Viewport m_viewport;

		// Token: 0x040053EC RID: 21484
		private static Matrix m_invScreen;

		// Token: 0x040053ED RID: 21485
		private static Texture2D m_fakeTexture;

		// Token: 0x040053EE RID: 21486
		private static Stack<Matrix> m_modelViewMatrixStack;

		// Token: 0x040053EF RID: 21487
		private static Stack<Matrix> m_projectionMatrixStack;

		// Token: 0x040053F0 RID: 21488
		private static Stack<Matrix> m_activeMatrixStack;

		// Token: 0x040053F1 RID: 21489
		private static bool m_matrixPaletteOESActive = false;

		// Token: 0x040053F2 RID: 21490
		private static Matrix[] m_matrixPalleteOES;

		// Token: 0x040053F3 RID: 21491
		private static uint m_currentPaletteMatrixOES = 0U;

		// Token: 0x040053F4 RID: 21492
		private static Color m_color = new Color(1f, 1f, 1f, 0f);

		// Token: 0x040053F5 RID: 21493
		private static Color m_clearColor = default(Color);

		// Token: 0x040053F6 RID: 21494
		private static float m_clearDepth = 1f;

		// Token: 0x040053F7 RID: 21495
		private static bool m_perPixelLighting = true;

		// Token: 0x040053F8 RID: 21496
		private static bool m_alphaTestEnabled = false;

		// Token: 0x040053F9 RID: 21497
		private static CompareFunction m_alphaFunction = CompareFunction.Always;

		// Token: 0x040053FA RID: 21498
		private static int m_alphaRef = 0;

		// Token: 0x040053FB RID: 21499
		private static bool m_blendEnabled = false;

		// Token: 0x040053FC RID: 21500
		private static Dictionary<long, BlendState> m_blendStates = new Dictionary<long, BlendState>();

		// Token: 0x040053FD RID: 21501
		private static BlendState m_blendState = new BlendState
		{
			ColorBlendFunction = BlendFunction.Add,
			AlphaBlendFunction = BlendFunction.Add,
			ColorSourceBlend = Blend.One,
			AlphaSourceBlend = Blend.One,
			ColorDestinationBlend = Blend.Zero,
			AlphaDestinationBlend = Blend.Zero,
			ColorWriteChannels = ColorWriteChannels.All
		};

		// Token: 0x040053FE RID: 21502
		private static bool m_vertexColorEnabled = false;

		// Token: 0x040053FF RID: 21503
		private static bool m_colorLogicEnabled = false;

		// Token: 0x04005400 RID: 21504
		private static bool m_colorMaterialEnabled = false;

		// Token: 0x04005401 RID: 21505
		private static bool m_cullFaceEnabled = false;

		// Token: 0x04005402 RID: 21506
		private static uint m_frontFace = 2305U;

		// Token: 0x04005403 RID: 21507
		private static uint m_cullFace = 1029U;

		// Token: 0x04005404 RID: 21508
		private static RasterizerState m_rasterizerState = new RasterizerState
		{
			CullMode = CullMode.None,
			ScissorTestEnable = true,
			MultiSampleAntiAlias = false
		};

		// Token: 0x04005405 RID: 21509
		private static RasterizerState m_rasterizerStateCW = new RasterizerState
		{
			CullMode = CullMode.CullClockwiseFace,
			ScissorTestEnable = true,
			MultiSampleAntiAlias = false
		};

		// Token: 0x04005406 RID: 21510
		private static RasterizerState m_rasterizerStateCCW = new RasterizerState
		{
			CullMode = CullMode.CullClockwiseFace,
			ScissorTestEnable = true,
			MultiSampleAntiAlias = false
		};

		// Token: 0x04005407 RID: 21511
		private static RasterizerState m_rasterizerStateCN = new RasterizerState
		{
			CullMode = CullMode.None,
			ScissorTestEnable = true,
			MultiSampleAntiAlias = false
		};

		// Token: 0x04005408 RID: 21512
		private static bool m_depthTestEnabled = false;

		// Token: 0x04005409 RID: 21513
		private static Dictionary<int, DepthStencilState> m_depthStencils = new Dictionary<int, DepthStencilState>();

		// Token: 0x0400540A RID: 21514
		private static DepthStencilState m_depthStencilState = new DepthStencilState
		{
			DepthBufferFunction = CompareFunction.Less,
			DepthBufferWriteEnable = true
		};

		// Token: 0x0400540B RID: 21515
		private static bool m_fogEnabled = false;

		// Token: 0x0400540C RID: 21516
		private static Vector3 m_fogColor = new Vector3(0f, 0f, 0f);

		// Token: 0x0400540D RID: 21517
		private static ushort m_fogMode = 2048;

		// Token: 0x0400540E RID: 21518
		private static float m_fogStart = 0.5f;

		// Token: 0x0400540F RID: 21519
		private static float m_fogEnd = 1f;

		// Token: 0x04005410 RID: 21520
		private static bool m_lightingEnabled = false;

		// Token: 0x04005411 RID: 21521
		private static OpenGL.LightUnit[] m_lightUnit = new OpenGL.LightUnit[]
		{
			new OpenGL.LightUnit(),
			new OpenGL.LightUnit(),
			new OpenGL.LightUnit()
		};

		// Token: 0x04005412 RID: 21522
		private static Vector3 m_ambientColor = new Vector3(0.2f, 0.2f, 0.2f);

		// Token: 0x04005413 RID: 21523
		private static Vector3 m_diffuseColor = new Vector3(0.8f, 0.8f, 0.8f);

		// Token: 0x04005414 RID: 21524
		private static float m_diffuseColorAlpha = 1f;

		// Token: 0x04005415 RID: 21525
		private static Vector3 m_emissiveColor = new Vector3(0f, 0f, 0f);

		// Token: 0x04005416 RID: 21526
		private static Vector3 m_specularColor = new Vector3(0f, 0f, 0f);

		// Token: 0x04005417 RID: 21527
		private static float m_specularPower = 0f;

		// Token: 0x04005418 RID: 21528
		private static bool m_matrixPalleteOESEnabled = false;

		// Token: 0x04005419 RID: 21529
		private static uint m_activeTextureUnit = 0U;

		// Token: 0x0400541A RID: 21530
		private static uint m_clientActiveTextureUnit = 0U;

		// Token: 0x0400541B RID: 21531
		private static Dictionary<int, SamplerState> m_samplerStates = new Dictionary<int, SamplerState>();

		// Token: 0x0400541C RID: 21532
		private static OpenGL.TextureUnit[] m_textureUnits = new OpenGL.TextureUnit[]
		{
			new OpenGL.TextureUnit(),
			new OpenGL.TextureUnit()
		};

		// Token: 0x0400541D RID: 21533
		private static uint[] m_usedTexIDs = new uint[8];

		// Token: 0x0400541E RID: 21534
		private static Dictionary<uint, Texture2D> m_textures = new Dictionary<uint, Texture2D>(8);

		// Token: 0x0400541F RID: 21535
		private static Texture2D m_curTexture = null;

		// Token: 0x04005420 RID: 21536
		private static uint[] m_usedBufferIDs = new uint[8];

		// Token: 0x04005421 RID: 21537
		public static Dictionary<uint, OpenGL.BufferItem> m_buffers = new Dictionary<uint, OpenGL.BufferItem>(8);

		// Token: 0x04005422 RID: 21538
		public static uint m_boundArrayBuffer = 0U;

		// Token: 0x04005423 RID: 21539
		private static uint m_boundElementArrayBuffer = 0U;

		// Token: 0x04005424 RID: 21540
		private static bool m_normalArrayEnabled = false;

		// Token: 0x04005425 RID: 21541
		private static uint m_normalArrayDataType = 0U;

		// Token: 0x04005426 RID: 21542
		private static int m_normalArrayStride = 0;

		// Token: 0x04005427 RID: 21543
		private static OpenGL.GLVertexData m_normalArray = null;

		// Token: 0x04005428 RID: 21544
		private static bool m_colorArrayEnabled = false;

		// Token: 0x04005429 RID: 21545
		private static int m_colorArraySize = 0;

		// Token: 0x0400542A RID: 21546
		private static uint m_colorArrayDataType = 0U;

		// Token: 0x0400542B RID: 21547
		private static int m_colorArrayStride = 0;

		// Token: 0x0400542C RID: 21548
		private static OpenGL.GLVertexData m_colorArray = null;

		// Token: 0x0400542D RID: 21549
		private static bool m_vertexArrayEnabled = false;

		// Token: 0x0400542E RID: 21550
		private static int m_vertexArraySize = 0;

		// Token: 0x0400542F RID: 21551
		private static uint m_vertexArrayDataType = 0U;

		// Token: 0x04005430 RID: 21552
		private static int m_vertexArrayStride = 0;

		// Token: 0x04005431 RID: 21553
		private static OpenGL.GLVertexData m_vertexArray = null;

		// Token: 0x04005432 RID: 21554
		private static bool m_weightArrayEnabled;

		// Token: 0x04005433 RID: 21555
		private static int m_weightArraySize = 0;

		// Token: 0x04005434 RID: 21556
		private static uint m_weightArrayDataType = 0U;

		// Token: 0x04005435 RID: 21557
		private static int m_weightArrayStride = 0;

		// Token: 0x04005436 RID: 21558
		private static OpenGL.GLVertexData m_weightArray = null;

		// Token: 0x04005437 RID: 21559
		private static bool m_matrixIndexArrayEnabled = false;

		// Token: 0x04005438 RID: 21560
		private static int m_matrixIndexArraySize = 0;

		// Token: 0x04005439 RID: 21561
		private static uint m_matrixIndexArrayDataType = 0U;

		// Token: 0x0400543A RID: 21562
		private static int m_matrixIndexArrayStride = 0;

		// Token: 0x0400543B RID: 21563
		private static OpenGL.GLVertexData m_matrixIndexArray = null;

		// Token: 0x0400543C RID: 21564
		private static bool m_secondaryColorArrayEnabled = false;

		// Token: 0x0400543D RID: 21565
		private static readonly Matrix PROJECTION_CORRECTION = Matrix.CreateRotationZ(1.5707964f) * Matrix.CreateScale(1f, 1.12f, 0.5f) * Matrix.CreateTranslation(0f, 0f, 0.5f);

		// Token: 0x0400543E RID: 21566
		private static OpenGL.VertexPosTexColNorm[][] m_vertices = new OpenGL.VertexPosTexColNorm[][]
		{
			new OpenGL.VertexPosTexColNorm[32768],
			new OpenGL.VertexPosTexColNorm[2048]
		};

		// Token: 0x0400543F RID: 21567
		private static short[] m_indices = null;

		// Token: 0x020001D1 RID: 465
		public struct glArray4f
		{
			// Token: 0x060022BE RID: 8894 RVA: 0x001469FF File Offset: 0x00144BFF
			public glArray4f(float F0, float F1, float F2, float F3)
			{
				this.f0 = F0;
				this.f1 = F1;
				this.f2 = F2;
				this.f3 = F3;
			}

			// Token: 0x04005440 RID: 21568
			public float f0;

			// Token: 0x04005441 RID: 21569
			public float f1;

			// Token: 0x04005442 RID: 21570
			public float f2;

			// Token: 0x04005443 RID: 21571
			public float f3;
		}

		// Token: 0x020001D2 RID: 466
		public struct Vertex : IVertexType
		{
			// Token: 0x1700009B RID: 155
			// (get) Token: 0x060022BF RID: 8895 RVA: 0x00146A1E File Offset: 0x00144C1E
			VertexDeclaration IVertexType.VertexDeclaration
			{
				get
				{
					return OpenGL.Vertex.VertexDeclaration;
				}
			}

			// Token: 0x04005444 RID: 21572
			public Vector3 Position;

			// Token: 0x04005445 RID: 21573
			public Vector2 TextureCoordinate;

			// Token: 0x04005446 RID: 21574
			public Color Color;

			// Token: 0x04005447 RID: 21575
			public Vector3 Normal;

			// Token: 0x04005448 RID: 21576
			public Vector4 BlendWeight;

			// Token: 0x04005449 RID: 21577
			public Byte4 BlendIndices;

			// Token: 0x0400544A RID: 21578
			public Vector2 TextureCoordinate2;

			// Token: 0x0400544B RID: 21579
			public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[]
			{
				new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
				new VertexElement(12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
				new VertexElement(20, VertexElementFormat.Color, VertexElementUsage.Color, 0),
				new VertexElement(24, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
				new VertexElement(36, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
				new VertexElement(52, VertexElementFormat.Byte4, VertexElementUsage.BlendIndices, 0),
				new VertexElement(56, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 1)
			});
		}

		// Token: 0x020001D3 RID: 467
		public struct VertexPosTexColNorm : IVertexType
		{
			// Token: 0x1700009C RID: 156
			// (get) Token: 0x060022C1 RID: 8897 RVA: 0x00146AE0 File Offset: 0x00144CE0
			VertexDeclaration IVertexType.VertexDeclaration
			{
				get
				{
					return OpenGL.VertexPosTexColNorm.VertexDeclaration;
				}
			}

			// Token: 0x0400544C RID: 21580
			public Vector3 Position;

			// Token: 0x0400544D RID: 21581
			public Vector2 TextureCoordinate;

			// Token: 0x0400544E RID: 21582
			public Color Color;

			// Token: 0x0400544F RID: 21583
			public Vector3 Normal;

			// Token: 0x04005450 RID: 21584
			public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[]
			{
				new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
				new VertexElement(12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
				new VertexElement(20, VertexElementFormat.Color, VertexElementUsage.Color, 0),
				new VertexElement(24, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
			});
		}

		// Token: 0x020001D4 RID: 468
		public enum GLVertexElementType
		{
			// Token: 0x04005452 RID: 21586
			Position,
			// Token: 0x04005453 RID: 21587
			Normal,
			// Token: 0x04005454 RID: 21588
			Color,
			// Token: 0x04005455 RID: 21589
			TextureCoordinate0,
			// Token: 0x04005456 RID: 21590
			TextureCoordinate1,
			// Token: 0x04005457 RID: 21591
			BlendWeight,
			// Token: 0x04005458 RID: 21592
			BlendIndex
		}

		// Token: 0x020001D5 RID: 469
		public interface GLVertexData
		{
			// Token: 0x1700009D RID: 157
			// (get) Token: 0x060022C3 RID: 8899
			OpenGL.GLVertexElementType[] DataComponents { get; }

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x060022C4 RID: 8900
			int VertexCount { get; }

			// Token: 0x060022C5 RID: 8901
			void ExtractTo(OpenGL.Vertex[] dst, int count);

			// Token: 0x060022C6 RID: 8902
			void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count);
		}

		// Token: 0x020001D6 RID: 470
		public interface GLIndexBuffer
		{
			// Token: 0x1700009F RID: 159
			// (get) Token: 0x060022C7 RID: 8903
			int Size { get; }

			// Token: 0x060022C8 RID: 8904
			void ExtractTo(ushort[] dst);
		}

		// Token: 0x020001D7 RID: 471
		private struct DrawArraysCallContext
		{
			// Token: 0x060022C9 RID: 8905 RVA: 0x00146B60 File Offset: 0x00144D60
			public bool isEqualTo(ref OpenGL.DrawArraysCallContext other)
			{
				if (this.alphaTestEnabled != other.alphaTestEnabled || this.blendState != other.blendState || this.depthStencilState != other.depthStencilState || this.rasterizerState != other.rasterizerState || this.samplerState != other.samplerState || this.vertexColorEnabled != other.vertexColorEnabled || this.fogEnabled != other.fogEnabled || this.texture != other.texture || this.projection != other.projection)
				{
					return false;
				}
				if (this.fogEnabled && (this.fogColor != other.fogColor || this.fogStart != other.fogStart || this.fogEnd != other.fogEnd))
				{
					return false;
				}
				if (this.alphaTestEnabled)
				{
					if (!this.normalArrayEnabled && (this.diffuseColor != other.diffuseColor || this.diffuseColorAlpha != other.diffuseColorAlpha))
					{
						return false;
					}
					if (this.alphaFunction != other.alphaFunction || this.referenceAlpha != other.referenceAlpha)
					{
						return false;
					}
					if (this.referenceAlpha != other.referenceAlpha)
					{
						return false;
					}
				}
				else if (!this.normalArrayEnabled)
				{
					if (this.diffuseColor != other.diffuseColor || this.diffuseColorAlpha != other.diffuseColorAlpha || this.ambientColor != other.ambientColor || this.specularColor != other.specularColor || this.emissiveColor != other.emissiveColor)
					{
						return false;
					}
					if (this.DirLight0Enabled != other.DirLight0Enabled || this.DirLight1Enabled != other.DirLight1Enabled || this.DirLight2Enabled != other.DirLight2Enabled)
					{
						return false;
					}
					if (this.DirLight0Enabled && (this.DirLight0DiffuseColor != other.DirLight0DiffuseColor || this.DirLight0Direction != other.DirLight0Direction || this.DirLight0SpecularColor != other.DirLight0SpecularColor))
					{
						return false;
					}
					if (this.DirLight1Enabled && (this.DirLight1DiffuseColor != other.DirLight1DiffuseColor || this.DirLight1Direction != other.DirLight1Direction || this.DirLight1SpecularColor != other.DirLight1SpecularColor))
					{
						return false;
					}
					if (this.DirLight2Enabled && (this.DirLight2DiffuseColor != other.DirLight2DiffuseColor || this.DirLight2Direction != other.DirLight2Direction || this.DirLight2SpecularColor != other.DirLight2SpecularColor))
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x04005459 RID: 21593
			public bool isPending;

			// Token: 0x0400545A RID: 21594
			public int vertexArrayOffset;

			// Token: 0x0400545B RID: 21595
			public int vertexCount;

			// Token: 0x0400545C RID: 21596
			public Texture2D texture;

			// Token: 0x0400545D RID: 21597
			public BlendState blendState;

			// Token: 0x0400545E RID: 21598
			public DepthStencilState depthStencilState;

			// Token: 0x0400545F RID: 21599
			public RasterizerState rasterizerState;

			// Token: 0x04005460 RID: 21600
			public SamplerState samplerState;

			// Token: 0x04005461 RID: 21601
			public Vector3 ambientColor;

			// Token: 0x04005462 RID: 21602
			public Vector3 diffuseColor;

			// Token: 0x04005463 RID: 21603
			public float diffuseColorAlpha;

			// Token: 0x04005464 RID: 21604
			public Vector3 emissiveColor;

			// Token: 0x04005465 RID: 21605
			public Vector3 specularColor;

			// Token: 0x04005466 RID: 21606
			public float specularPower;

			// Token: 0x04005467 RID: 21607
			public bool textureEnabled;

			// Token: 0x04005468 RID: 21608
			public bool normalArrayEnabled;

			// Token: 0x04005469 RID: 21609
			public bool vertexColorEnabled;

			// Token: 0x0400546A RID: 21610
			public bool alphaTestEnabled;

			// Token: 0x0400546B RID: 21611
			public CompareFunction alphaFunction;

			// Token: 0x0400546C RID: 21612
			public int referenceAlpha;

			// Token: 0x0400546D RID: 21613
			public Matrix view;

			// Token: 0x0400546E RID: 21614
			public Matrix projection;

			// Token: 0x0400546F RID: 21615
			public bool fogEnabled;

			// Token: 0x04005470 RID: 21616
			public Vector3 fogColor;

			// Token: 0x04005471 RID: 21617
			public float fogStart;

			// Token: 0x04005472 RID: 21618
			public float fogEnd;

			// Token: 0x04005473 RID: 21619
			public bool DirLight0Enabled;

			// Token: 0x04005474 RID: 21620
			public Vector3 DirLight0DiffuseColor;

			// Token: 0x04005475 RID: 21621
			public Vector3 DirLight0Direction;

			// Token: 0x04005476 RID: 21622
			public Vector3 DirLight0SpecularColor;

			// Token: 0x04005477 RID: 21623
			public bool DirLight1Enabled;

			// Token: 0x04005478 RID: 21624
			public Vector3 DirLight1DiffuseColor;

			// Token: 0x04005479 RID: 21625
			public Vector3 DirLight1Direction;

			// Token: 0x0400547A RID: 21626
			public Vector3 DirLight1SpecularColor;

			// Token: 0x0400547B RID: 21627
			public bool DirLight2Enabled;

			// Token: 0x0400547C RID: 21628
			public Vector3 DirLight2DiffuseColor;

			// Token: 0x0400547D RID: 21629
			public Vector3 DirLight2Direction;

			// Token: 0x0400547E RID: 21630
			public Vector3 DirLight2SpecularColor;
		}

		// Token: 0x020001D8 RID: 472
		private class TextureUnit
		{
			// Token: 0x060022CA RID: 8906 RVA: 0x00146DEC File Offset: 0x00144FEC
			public TextureUnit()
			{
				this.SamplerState = new SamplerState
				{
					AddressU = TextureAddressMode.Wrap,
					AddressV = TextureAddressMode.Wrap,
					AddressW = TextureAddressMode.Wrap,
					Filter = TextureFilter.Linear
				};
				this.MatrixStack = new Stack<Matrix>();
				this.MatrixStack.Push(Matrix.Identity);
			}

			// Token: 0x0400547F RID: 21631
			public bool Enabled;

			// Token: 0x04005480 RID: 21632
			public uint BoundTexture;

			// Token: 0x04005481 RID: 21633
			public bool TexCoordArrayEnabled;

			// Token: 0x04005482 RID: 21634
			public int TexCoordArraySize;

			// Token: 0x04005483 RID: 21635
			public uint TexCoordArrayDataType;

			// Token: 0x04005484 RID: 21636
			public int TexCoordArrayStride;

			// Token: 0x04005485 RID: 21637
			public OpenGL.GLVertexData TexCoordArray;

			// Token: 0x04005486 RID: 21638
			public SamplerState SamplerState;

			// Token: 0x04005487 RID: 21639
			public Stack<Matrix> MatrixStack;
		}

		// Token: 0x020001D9 RID: 473
		private class LightUnit
		{
			// Token: 0x04005488 RID: 21640
			public bool Enabled;

			// Token: 0x04005489 RID: 21641
			public Vector3 DiffuseColor;

			// Token: 0x0400548A RID: 21642
			public Vector3 Direction;

			// Token: 0x0400548B RID: 21643
			public Vector3 SpecularColor;
		}

		// Token: 0x020001DA RID: 474
		public class VertexBufferDesc
		{
			// Token: 0x0400548C RID: 21644
			public OpenGL.GLVertexElementType[] Components;

			// Token: 0x0400548D RID: 21645
			public VertexBuffer Buffer;

			// Token: 0x0400548E RID: 21646
			public OpenGL.Vertex[] vertices;

			// Token: 0x0400548F RID: 21647
			public Matrix TextureMatrix = Matrix.Identity;

			// Token: 0x04005490 RID: 21648
			public Matrix Texture2Matrix = Matrix.Identity;

			// Token: 0x04005491 RID: 21649
			public bool needSetBufferData;

			// Token: 0x04005492 RID: 21650
			public uint VertexColor;
		}

		// Token: 0x020001DB RID: 475
		public class BufferItem
		{
			// Token: 0x04005493 RID: 21651
			public object rawData;

			// Token: 0x04005494 RID: 21652
			public object buffer;

			// Token: 0x04005495 RID: 21653
			public int rawDataSize;
		}
	}
}
