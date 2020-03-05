using System;

// Token: 0x02000417 RID: 1047
public class IntBuffer : ByteBuffer
{
	// Token: 0x06002A58 RID: 10840 RVA: 0x0015A295 File Offset: 0x00158495
	public IntBuffer(ByteBuffer buffer) : base(buffer.data, buffer.offset)
	{
	}

	// Token: 0x170001BE RID: 446
	public new int this[int index]
	{
		get
		{
			return base.GetInt(index * 4);
		}
		set
		{
			base.PutInt(value, index * 4);
		}
	}
}
