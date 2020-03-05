using System;

// Token: 0x0200041A RID: 1050
public class UShortBuffer : ByteBuffer
{
	// Token: 0x06002A61 RID: 10849 RVA: 0x0015A316 File Offset: 0x00158516
	public UShortBuffer(ByteBuffer buffer) : base(buffer.data, buffer.offset)
	{
	}

	// Token: 0x170001C1 RID: 449
	public new ushort this[int index]
	{
		get
		{
			return base.GetUShort(index * 2);
		}
		set
		{
			base.PutUShort(value, index * 2);
		}
	}
}
