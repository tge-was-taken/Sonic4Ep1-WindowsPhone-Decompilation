using System;
using mpp;

// Token: 0x020003EC RID: 1004
public class GLPositionData : GLVector3Data, OpenGL.GLVertexData
{
	// Token: 0x060028AC RID: 10412 RVA: 0x001544CC File Offset: 0x001526CC
	public GLPositionData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
		: base( buffer, size, type, stride, elCount )
	{
		OpenGL.GLVertexElementType[] array = new OpenGL.GLVertexElementType[1];
		this.compType_ = array;
	}

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x060028AD RID: 10413 RVA: 0x001544F4 File Offset: 0x001526F4
	public OpenGL.GLVertexElementType[] DataComponents
	{
		get
		{
			return this.compType_;
		}
	}

	// Token: 0x060028AE RID: 10414 RVA: 0x001544FC File Offset: 0x001526FC
	public virtual void ExtractTo(OpenGL.Vertex[] dst, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i].Position = this.data_[i];
		}
	}

	// Token: 0x060028AF RID: 10415 RVA: 0x00154534 File Offset: 0x00152734
	public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i + dstOffset].Position = this.data_[i];
		}
	}

	// Token: 0x040062E6 RID: 25318
	protected OpenGL.GLVertexElementType[] compType_;
}
