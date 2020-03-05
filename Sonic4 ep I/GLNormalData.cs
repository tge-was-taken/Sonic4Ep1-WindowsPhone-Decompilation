using System;
using mpp;

// Token: 0x020003EF RID: 1007
public class GLNormalData : GLVector3Data, OpenGL.GLVertexData
{
	// Token: 0x060028BF RID: 10431 RVA: 0x00154970 File Offset: 0x00152B70
	public GLNormalData(ByteBuffer buffer, int size, uint type, int stride, int elCount) : base(buffer, size, type, stride, elCount)
	{
	}

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x060028C0 RID: 10432 RVA: 0x0015499C File Offset: 0x00152B9C
	public OpenGL.GLVertexElementType[] DataComponents
	{
		get
		{
			return this.compType_;
		}
	}

	// Token: 0x060028C1 RID: 10433 RVA: 0x001549A4 File Offset: 0x00152BA4
	public virtual void ExtractTo(OpenGL.Vertex[] dst, int count)
	{
		for (int i = 0; i < count; i++)
		{
			dst[i].Normal = this.data_[i];
		}
	}

	// Token: 0x060028C2 RID: 10434 RVA: 0x001549DA File Offset: 0x00152BDA
	public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
	{
		throw new InvalidOperationException();
	}

	// Token: 0x040062EB RID: 25323
	protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[]
	{
		OpenGL.GLVertexElementType.Normal
	};
}
