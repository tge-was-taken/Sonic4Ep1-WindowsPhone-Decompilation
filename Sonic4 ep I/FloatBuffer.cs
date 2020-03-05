using System;

// Token: 0x0200041B RID: 1051
public class FloatBuffer : ByteBuffer
{
	// Token: 0x06002A64 RID: 10852 RVA: 0x0015A341 File Offset: 0x00158541
	public FloatBuffer(ByteBuffer buffer) : base(buffer.data, buffer.offset)
	{
	}

	// Token: 0x170001C2 RID: 450
	public new float this[int index]
	{
		get
		{
			return base.GetFloat(index * 4);
		}
		set
		{
			base.PutFloat(value, index * 4);
		}
	}
}
