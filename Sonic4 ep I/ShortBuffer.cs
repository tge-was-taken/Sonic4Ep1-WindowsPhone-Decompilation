using System;

// Token: 0x02000419 RID: 1049
public class ShortBuffer : ByteBuffer
{
	// Token: 0x06002A5E RID: 10846 RVA: 0x0015A2EB File Offset: 0x001584EB
	public ShortBuffer(ByteBuffer buffer) : base(buffer.data, buffer.offset)
	{
	}

	// Token: 0x170001C0 RID: 448
	public new short this[int index]
	{
		get
		{
			return base.GetShort(index * 2);
		}
		set
		{
			base.PutShort(value, index * 2);
		}
	}
}
