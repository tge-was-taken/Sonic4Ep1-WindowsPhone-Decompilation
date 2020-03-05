using System;
using Microsoft.Xna.Framework;
using mpp;

// Token: 0x020003F1 RID: 1009
public class GLBlendWeightData : OpenGL.GLVertexData
{
	// Token: 0x060028C8 RID: 10440 RVA: 0x00154AF4 File Offset: 0x00152CF4
	public GLBlendWeightData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
	{
		stride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
		this.data_ = new Vector4[elCount];
		int num = 0;
		for (int i = 0; i < elCount; i++)
		{
			float @float = buffer.GetFloat(num);
			float y = (size > 1) ? buffer.GetFloat(num + 4) : 0f;
			float z = (size > 2) ? buffer.GetFloat(num + 8) : 0f;
			float w = (size > 3) ? buffer.GetFloat(num + 12) : 0f;
			this.data_[i] = new Vector4(@float, y, z, w);
			num += stride;
		}
	}

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x060028C9 RID: 10441 RVA: 0x00154BB5 File Offset: 0x00152DB5
	public OpenGL.GLVertexElementType[] DataComponents
	{
		get
		{
			return this.compType_;
		}
	}

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x060028CA RID: 10442 RVA: 0x00154BBD File Offset: 0x00152DBD
	public int VertexCount
	{
		get
		{
			return this.data_.Length;
		}
	}

	// Token: 0x060028CB RID: 10443 RVA: 0x00154BC8 File Offset: 0x00152DC8
	public void ExtractTo(OpenGL.Vertex[] dst, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i].BlendWeight = this.data_[i];
		}
	}

	// Token: 0x060028CC RID: 10444 RVA: 0x00154BFE File Offset: 0x00152DFE
	public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
	{
		throw new InvalidOperationException();
	}

	// Token: 0x040062EE RID: 25326
	protected readonly Vector4[] data_;

	// Token: 0x040062EF RID: 25327
	protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[]
	{
		OpenGL.GLVertexElementType.BlendWeight
	};
}
