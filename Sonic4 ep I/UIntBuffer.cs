using System;

// Token: 0x02000418 RID: 1048
public class UIntBuffer : ByteBuffer
{
	// Token: 0x06002A5B RID: 10843 RVA: 0x0015A2C0 File Offset: 0x001584C0
	public UIntBuffer(ByteBuffer buffer) : base(buffer.data, buffer.offset)
	{
	}

	// Token: 0x170001BF RID: 447
	public new uint this[int index]
	{
		get
		{
			return base.GetUInt(index * 4);
		}
		set
		{
			base.PutUInt(value, index * 4);
		}
	}
}
