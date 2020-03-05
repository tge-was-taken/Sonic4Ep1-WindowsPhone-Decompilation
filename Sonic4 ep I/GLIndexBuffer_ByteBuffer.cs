using System;
using mpp;

// Token: 0x020003F2 RID: 1010
public struct GLIndexBuffer_ByteBuffer : OpenGL.GLIndexBuffer
{
	// Token: 0x060028CD RID: 10445 RVA: 0x00154C05 File Offset: 0x00152E05
	public GLIndexBuffer_ByteBuffer(ByteBuffer data, int dataSize)
	{
		this.data_ = data;
		this.dataSize_ = dataSize;
	}

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x060028CE RID: 10446 RVA: 0x00154C15 File Offset: 0x00152E15
	public int Size
	{
		get
		{
			return this.dataSize_ / 2;
		}
	}

	// Token: 0x060028CF RID: 10447 RVA: 0x00154C20 File Offset: 0x00152E20
	public void ExtractTo(ushort[] dst)
	{
		int num = 0;
		for (int i = 0; i < this.dataSize_; i += 2)
		{
			dst[num] = this.data_.GetUShort(i);
			num++;
		}
	}

	// Token: 0x040062F0 RID: 25328
	private ByteBuffer data_;

	// Token: 0x040062F1 RID: 25329
	private int dataSize_;
}
