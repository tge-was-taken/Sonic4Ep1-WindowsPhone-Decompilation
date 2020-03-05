using System;
using Microsoft.Xna.Framework;
using mpp;

// Token: 0x020003EB RID: 1003
public abstract class GLVector3Data
{
	// Token: 0x060028A4 RID: 10404 RVA: 0x001541C8 File Offset: 0x001523C8
	public GLVector3Data(ByteBuffer buffer, int size, uint type, int stride, int elCount)
	{
		stride = ((stride == 0) ? (OpenGL.SizeOf(type) * size) : stride);
		this.data_ = new Vector3[elCount];
		switch (type)
		{
		case 5121U:
			if (size > 2)
			{
				this.extract3ByteData(buffer, stride);
				return;
			}
			this.extract2ByteData(buffer, stride);
			break;
		case 5122U:
			break;
		case 5123U:
			if (size > 2)
			{
				this.extract3UShortData(buffer, stride);
				return;
			}
			this.extract2UShortData(buffer, stride);
			return;
		default:
			if (type != 5126U)
			{
				return;
			}
			if (size > 2)
			{
				this.extract3FloatData(buffer, stride);
				return;
			}
			this.extract2FloatData(buffer, stride);
			return;
		}
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x060028A5 RID: 10405 RVA: 0x00154264 File Offset: 0x00152464
	public int VertexCount
	{
		get
		{
			return this.data_.Length;
		}
	}

	// Token: 0x060028A6 RID: 10406 RVA: 0x00154270 File Offset: 0x00152470
	private void extract3FloatData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			float @float = buffer.GetFloat(num2);
			float float2 = buffer.GetFloat(num2 + 4);
			float float3 = buffer.GetFloat(num2 + 8);
			this.data_[i] = new Vector3(@float, float2, float3);
			num2 += stride;
		}
	}

	// Token: 0x060028A7 RID: 10407 RVA: 0x001542D8 File Offset: 0x001524D8
	private void extract2FloatData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			float @float = buffer.GetFloat(num2);
			float float2 = buffer.GetFloat(num2 + 4);
			this.data_[i] = new Vector3(@float, float2, 0f);
			num2 += stride;
		}
	}

	// Token: 0x060028A8 RID: 10408 RVA: 0x00154334 File Offset: 0x00152534
	private void extract3UShortData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ushort @ushort = buffer.GetUShort(num2);
			ushort ushort2 = buffer.GetUShort(num2 + 2);
			ushort ushort3 = buffer.GetUShort(num2 + 4);
			this.data_[i] = new Vector3((float)@ushort, (float)ushort2, (float)ushort3);
			num2 += stride;
		}
	}

	// Token: 0x060028A9 RID: 10409 RVA: 0x001543A0 File Offset: 0x001525A0
	private void extract2UShortData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ushort @ushort = buffer.GetUShort(num2);
			ushort ushort2 = buffer.GetUShort(num2 + 2);
			this.data_[i] = new Vector3((float)@ushort, (float)ushort2, 0f);
			num2 += stride;
		}
	}

	// Token: 0x060028AA RID: 10410 RVA: 0x00154400 File Offset: 0x00152600
	private void extract3ByteData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			byte b = buffer[num2];
			byte b2 = buffer[num2 + 1];
			byte b3 = buffer[num2 + 2];
			this.data_[i] = new Vector3((float)b, (float)b2, (float)b3);
			num2 += stride;
		}
	}

	// Token: 0x060028AB RID: 10411 RVA: 0x0015446C File Offset: 0x0015266C
	private void extract2ByteData(ByteBuffer buffer, int stride)
	{
		int num = this.data_.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			byte b = buffer[num2];
			byte b2 = buffer[num2 + 1];
			this.data_[i] = new Vector3((float)b, (float)b2, 0f);
			num2 += stride;
		}
	}

	// Token: 0x040062E5 RID: 25317
	protected readonly Vector3[] data_;
}
