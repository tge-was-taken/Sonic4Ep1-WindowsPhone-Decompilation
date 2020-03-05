using System;
using Microsoft.Xna.Framework;
using mpp;

// Token: 0x020003EE RID: 1006
public class GLColorData : OpenGL.GLVertexData
{
	// Token: 0x060028B8 RID: 10424 RVA: 0x00154784 File Offset: 0x00152984
	public GLColorData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
	{
		stride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
		this.data_ = new Color[elCount];
		switch (type)
		{
		case 5121U:
			if (size > 3)
			{
				this.extract4ByteData(buffer, stride);
				return;
			}
			this.extract3ByteData(buffer, stride);
			break;
		case 5122U:
			break;
		case 5123U:
			throw new NotImplementedException();
		default:
			if (type != 5126U)
			{
				return;
			}
			throw new NotImplementedException();
		}
	}

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x060028B9 RID: 10425 RVA: 0x0015480E File Offset: 0x00152A0E
	public OpenGL.GLVertexElementType[] DataComponents
	{
		get
		{
			return this.compType_;
		}
	}

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x060028BA RID: 10426 RVA: 0x00154816 File Offset: 0x00152A16
	public int VertexCount
	{
		get
		{
			return this.data_.Length;
		}
	}

	// Token: 0x060028BB RID: 10427 RVA: 0x00154820 File Offset: 0x00152A20
	public void ExtractTo(OpenGL.Vertex[] dst, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i].Color = this.data_[i];
		}
	}

	// Token: 0x060028BC RID: 10428 RVA: 0x00154858 File Offset: 0x00152A58
	public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i + dstOffset].Color = this.data_[i];
		}
	}

	// Token: 0x060028BD RID: 10429 RVA: 0x00154890 File Offset: 0x00152A90
	private void extract4ByteData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			byte r = buffer[num2];
			byte g = buffer[num2 + 1];
			byte b = buffer[num2 + 2];
			byte a = buffer[num2 + 3];
			this.data_[i] = new Color((int)r, (int)g, (int)b, (int)a);
			num2 += stride;
		}
	}

	// Token: 0x060028BE RID: 10430 RVA: 0x00154908 File Offset: 0x00152B08
	private void extract3ByteData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			byte r = buffer[num2];
			byte g = buffer[num2 + 1];
			byte b = buffer[num2 + 2];
			this.data_[i] = new Color((int)r, (int)g, (int)b);
			num2 += stride;
		}
	}

	// Token: 0x040062E9 RID: 25321
	protected readonly Color[] data_;

	// Token: 0x040062EA RID: 25322
	protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[]
	{
		OpenGL.GLVertexElementType.Color
	};
}
