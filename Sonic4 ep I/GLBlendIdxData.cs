using System;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using mpp;

// Token: 0x020003F0 RID: 1008
public class GLBlendIdxData : OpenGL.GLVertexData
{
	// Token: 0x060028C3 RID: 10435 RVA: 0x001549E4 File Offset: 0x00152BE4
	public GLBlendIdxData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
	{
		stride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
		this.data_ = new Byte4[elCount];
		int num = 0;
		for (int i = 0; i < elCount; i++)
		{
			byte b = buffer[num];
			byte b2 = (byte)((size > 1) ? buffer[num + 1] : 0);
			byte b3 = (byte)((size > 2) ? buffer[num + 2] : 0);
			byte b4 = (byte)((size > 3) ? buffer[num + 3] : 0);
			this.data_[i] = new Byte4((float)b, (float)b2, (float)b3, (float)b4);
			num += stride;
		}
	}

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x060028C4 RID: 10436 RVA: 0x00154A9F File Offset: 0x00152C9F
	public OpenGL.GLVertexElementType[] DataComponents
	{
		get
		{
			return this.compType_;
		}
	}

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x060028C5 RID: 10437 RVA: 0x00154AA7 File Offset: 0x00152CA7
	public int VertexCount
	{
		get
		{
			return this.data_.Length;
		}
	}

	// Token: 0x060028C6 RID: 10438 RVA: 0x00154AB4 File Offset: 0x00152CB4
	public void ExtractTo(OpenGL.Vertex[] dst, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i].BlendIndices = this.data_[i];
		}
	}

	// Token: 0x060028C7 RID: 10439 RVA: 0x00154AEA File Offset: 0x00152CEA
	public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
	{
		throw new InvalidOperationException();
	}

	// Token: 0x040062EC RID: 25324
	protected readonly Byte4[] data_;

	// Token: 0x040062ED RID: 25325
	protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[]
	{
		OpenGL.GLVertexElementType.BlendIndex
	};
}
