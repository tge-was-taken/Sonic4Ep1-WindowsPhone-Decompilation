using System;
using mpp;

// Token: 0x02000416 RID: 1046
public class ByteBuffer
{
	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06002A3B RID: 10811 RVA: 0x0015A040 File Offset: 0x00158240
	public byte[] Data
	{
		get
		{
			return this.data;
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06002A3C RID: 10812 RVA: 0x0015A048 File Offset: 0x00158248
	// (set) Token: 0x06002A3D RID: 10813 RVA: 0x0015A050 File Offset: 0x00158250
	public int Offset
	{
		get
		{
			return this.offset;
		}
		set
		{
			this.offset = value;
			this.data = null;
		}
	}

	// Token: 0x06002A3E RID: 10814 RVA: 0x0015A060 File Offset: 0x00158260
	public void SetOffset(int iOffset)
	{
		this.offset = iOffset;
	}

	// Token: 0x06002A3F RID: 10815 RVA: 0x0015A069 File Offset: 0x00158269
	public static ByteBuffer Wrap(byte[] data)
	{
		return new ByteBuffer(data, 0);
	}

	// Token: 0x06002A40 RID: 10816 RVA: 0x0015A072 File Offset: 0x00158272
	protected ByteBuffer(byte[] _data, int _offset)
	{
		this.data = _data;
		this.offset = _offset;
	}

	// Token: 0x06002A41 RID: 10817 RVA: 0x0015A088 File Offset: 0x00158288
	public static ByteBuffer operator +(ByteBuffer buffer, int i)
	{
		return new ByteBuffer(buffer.data, buffer.offset + i);
	}

	// Token: 0x06002A42 RID: 10818 RVA: 0x0015A09D File Offset: 0x0015829D
	public static ByteBuffer operator -(ByteBuffer buffer, int i)
	{
		return new ByteBuffer(buffer.data, buffer.offset - i);
	}

	// Token: 0x06002A43 RID: 10819 RVA: 0x0015A0B2 File Offset: 0x001582B2
	public static bool operator <(ByteBuffer buffer1, ByteBuffer buffer2)
	{
		if (buffer1.data != buffer2.data)
		{
			throw new InvalidOperationException();
		}
		return buffer1.offset < buffer2.offset;
	}

	// Token: 0x06002A44 RID: 10820 RVA: 0x0015A0D6 File Offset: 0x001582D6
	public static int operator -(ByteBuffer buffer1, ByteBuffer buffer2)
	{
		if (buffer1.data != buffer2.data)
		{
			throw new InvalidOperationException();
		}
		return buffer1.offset - buffer2.offset;
	}

	// Token: 0x06002A45 RID: 10821 RVA: 0x0015A0F9 File Offset: 0x001582F9
	public static bool operator >(ByteBuffer buffer1, ByteBuffer buffer2)
	{
		if (buffer1.data != buffer2.data)
		{
			throw new InvalidOperationException();
		}
		return buffer1.offset > buffer2.offset;
	}

	// Token: 0x170001BD RID: 445
	public byte this[int i]
	{
		get
		{
			return this.data[this.offset + i];
		}
		set
		{
			this.data[this.offset + i] = value;
		}
	}

	// Token: 0x06002A48 RID: 10824 RVA: 0x0015A140 File Offset: 0x00158340
	public int GetInt(int getOffset)
	{
		return BitConverter.ToInt32(this.data, this.offset + getOffset);
	}

	// Token: 0x06002A49 RID: 10825 RVA: 0x0015A155 File Offset: 0x00158355
	public void PutInt(int n, int putOffset)
	{
		MppBitConverter.GetBytes(n, this.data, this.offset + putOffset);
	}

	// Token: 0x06002A4A RID: 10826 RVA: 0x0015A16B File Offset: 0x0015836B
	public IntBuffer AsIntBuffer()
	{
		return new IntBuffer(this);
	}

	// Token: 0x06002A4B RID: 10827 RVA: 0x0015A173 File Offset: 0x00158373
	public uint GetUInt(int getOffset)
	{
		return BitConverter.ToUInt32(this.data, this.offset + getOffset);
	}

	// Token: 0x06002A4C RID: 10828 RVA: 0x0015A188 File Offset: 0x00158388
	public void PutUInt(uint n, int putOffset)
	{
		Array.Copy(BitConverter.GetBytes(n), 0, this.data, this.offset + putOffset, 4);
	}

	// Token: 0x06002A4D RID: 10829 RVA: 0x0015A1A5 File Offset: 0x001583A5
	public UIntBuffer AsUIntBuffer()
	{
		return new UIntBuffer(this);
	}

	// Token: 0x06002A4E RID: 10830 RVA: 0x0015A1AD File Offset: 0x001583AD
	public short GetShort(int getOffset)
	{
		return BitConverter.ToInt16(this.data, this.offset + getOffset);
	}

	// Token: 0x06002A4F RID: 10831 RVA: 0x0015A1C2 File Offset: 0x001583C2
	public void PutShort(short n, int putOffset)
	{
		Array.Copy(BitConverter.GetBytes(n), 0, this.data, this.offset + putOffset, 2);
	}

	// Token: 0x06002A50 RID: 10832 RVA: 0x0015A1DF File Offset: 0x001583DF
	public ShortBuffer AsShortBuffer()
	{
		return new ShortBuffer(this);
	}

	// Token: 0x06002A51 RID: 10833 RVA: 0x0015A1E7 File Offset: 0x001583E7
	public ushort GetUShort(int getOffset)
	{
		return BitConverter.ToUInt16(this.data, this.offset + getOffset);
	}

	// Token: 0x06002A52 RID: 10834 RVA: 0x0015A1FC File Offset: 0x001583FC
	public void PutUShort(ushort n, int putOffset)
	{
		Array.Copy(BitConverter.GetBytes(n), 0, this.data, this.offset + putOffset, 2);
	}

	// Token: 0x06002A53 RID: 10835 RVA: 0x0015A219 File Offset: 0x00158419
	public UShortBuffer AsUShortBuffer()
	{
		return new UShortBuffer(this);
	}

	// Token: 0x06002A54 RID: 10836 RVA: 0x0015A221 File Offset: 0x00158421
	public float GetFloat(int getOffset)
	{
		return BitConverter.ToSingle(this.data, this.offset + getOffset);
	}

	// Token: 0x06002A55 RID: 10837 RVA: 0x0015A236 File Offset: 0x00158436
	public void PutFloat(float n, int putOffset)
	{
		MppBitConverter.GetBytes(n, this.data, this.offset + putOffset);
	}

	// Token: 0x06002A56 RID: 10838 RVA: 0x0015A24C File Offset: 0x0015844C
	public FloatBuffer AsFloatBuffer()
	{
		return new FloatBuffer(this);
	}

	// Token: 0x06002A57 RID: 10839 RVA: 0x0015A254 File Offset: 0x00158454
	public byte[] GetBytesCopy(int size)
	{
		if (this.offset + size > this.data.Length)
		{
			throw new ArgumentException();
		}
		byte[] array = new byte[size];
		Array.Copy(this.data, this.offset, array, 0, size);
		return array;
	}

	// Token: 0x04006438 RID: 25656
	internal byte[] data;

	// Token: 0x04006439 RID: 25657
	internal int offset;
}
