using System;
using Microsoft.Xna.Framework;
using mpp;

// Token: 0x020003ED RID: 1005
public class GLTexCoordData : OpenGL.GLVertexData
{
	// Token: 0x060028B0 RID: 10416 RVA: 0x0015456C File Offset: 0x0015276C
	public GLTexCoordData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
	{
		stride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
		this.data_ = new Vector2[elCount];
		switch (type)
		{
		case 5121U:
			this.extractByteData(buffer, stride);
			break;
		case 5122U:
			break;
		case 5123U:
			this.extractUShortData(buffer, stride);
			return;
		default:
			if (type != 5126U)
			{
				return;
			}
			this.extractFloatData(buffer, stride);
			return;
		}
	}

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x060028B1 RID: 10417 RVA: 0x001545F0 File Offset: 0x001527F0
	public OpenGL.GLVertexElementType[] DataComponents
	{
		get
		{
			return this.compType_;
		}
	}

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x060028B2 RID: 10418 RVA: 0x001545F8 File Offset: 0x001527F8
	public int VertexCount
	{
		get
		{
			return this.data_.Length;
		}
	}

	// Token: 0x060028B3 RID: 10419 RVA: 0x00154604 File Offset: 0x00152804
	public void ExtractTo(OpenGL.Vertex[] dst, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i].TextureCoordinate = this.data_[i];
		}
	}

	// Token: 0x060028B4 RID: 10420 RVA: 0x0015463C File Offset: 0x0015283C
	public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i + dstOffset].TextureCoordinate = this.data_[i];
		}
	}

	// Token: 0x060028B5 RID: 10421 RVA: 0x00154674 File Offset: 0x00152874
	private void extractFloatData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			float @float = buffer.GetFloat(num2);
			float float2 = buffer.GetFloat(num2 + 4);
			this.data_[i] = new Vector2(@float, float2);
			num2 += stride;
		}
	}

	// Token: 0x060028B6 RID: 10422 RVA: 0x001546CC File Offset: 0x001528CC
	private void extractUShortData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ushort @ushort = buffer.GetUShort(num2);
			ushort ushort2 = buffer.GetUShort(num2 + 2);
			this.data_[i] = new Vector2((float)@ushort, (float)ushort2);
			num2 += stride;
		}
	}

	// Token: 0x060028B7 RID: 10423 RVA: 0x00154728 File Offset: 0x00152928
	private void extractByteData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			byte b = buffer[num2];
			byte b2 = buffer[num2 + 1];
			this.data_[i] = new Vector2((float)b, (float)b2);
			num2 += stride;
		}
	}

	// Token: 0x040062E7 RID: 25319
	protected readonly Vector2[] data_;

	// Token: 0x040062E8 RID: 25320
	protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[]
	{
		OpenGL.GLVertexElementType.TextureCoordinate0
	};
}
