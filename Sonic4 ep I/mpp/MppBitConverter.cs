using System;

namespace mpp
{
	// Token: 0x020003E0 RID: 992
	internal class MppBitConverter
	{
		// Token: 0x0600286D RID: 10349 RVA: 0x00152D34 File Offset: 0x00150F34
		public static void GetBytes(float value, byte[] dst, int offset)
		{
			MppBitConverter.float_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.float_buf, 0, dst, offset, 4);
		}

		// Token: 0x0600286E RID: 10350 RVA: 0x00152D4C File Offset: 0x00150F4C
		public static void GetBytes(uint value, byte[] dst, int offset)
		{
			MppBitConverter.UInt32_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.UInt32_buf, 0, dst, offset, 4);
		}

		// Token: 0x0600286F RID: 10351 RVA: 0x00152D64 File Offset: 0x00150F64
		public static void GetBytes(int value, byte[] dst, int offset)
		{
			MppBitConverter.Int32_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.Int32_buf, 0, dst, offset, 4);
		}

		// Token: 0x06002870 RID: 10352 RVA: 0x00152D7C File Offset: 0x00150F7C
		public static float Int32ToSingle(int value)
		{
			MppBitConverter.Int32_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.Int32_buf, 0, MppBitConverter.float_buf, 0, 4);
			return MppBitConverter.float_buf[0];
		}

		// Token: 0x06002871 RID: 10353 RVA: 0x00152D9F File Offset: 0x00150F9F
		public static int SingleToInt32(float value)
		{
			MppBitConverter.float_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.float_buf, 0, MppBitConverter.Int32_buf, 0, 4);
			return MppBitConverter.Int32_buf[0];
		}

		// Token: 0x06002872 RID: 10354 RVA: 0x00152DC2 File Offset: 0x00150FC2
		public static float UInt32ToSingle(uint value)
		{
			MppBitConverter.UInt32_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.UInt32_buf, 0, MppBitConverter.float_buf, 0, 4);
			return MppBitConverter.float_buf[0];
		}

		// Token: 0x06002873 RID: 10355 RVA: 0x00152DE5 File Offset: 0x00150FE5
		public static uint SingleToUInt32(float value)
		{
			MppBitConverter.float_buf[0] = value;
			Buffer.BlockCopy(MppBitConverter.float_buf, 0, MppBitConverter.UInt32_buf, 0, 4);
			return MppBitConverter.UInt32_buf[0];
		}

		// Token: 0x06002874 RID: 10356 RVA: 0x00152E08 File Offset: 0x00151008
		public static uint ToUInt32(byte[] src, int offset)
		{
			Buffer.BlockCopy(src, offset, MppBitConverter.UInt32_buf, 0, 4);
			return MppBitConverter.UInt32_buf[0];
		}

		// Token: 0x06002875 RID: 10357 RVA: 0x00152E1F File Offset: 0x0015101F
		public static int ToInt32(byte[] src, int offset)
		{
			Buffer.BlockCopy(src, offset, MppBitConverter.Int32_buf, 0, 4);
			return MppBitConverter.Int32_buf[0];
		}

		// Token: 0x06002876 RID: 10358 RVA: 0x00152E36 File Offset: 0x00151036
		public static float ToSingle(byte[] src, int offset)
		{
			Buffer.BlockCopy(src, offset, MppBitConverter.float_buf, 0, 4);
			return MppBitConverter.float_buf[0];
		}

		// Token: 0x040062A6 RID: 25254
		private static readonly int[] Int32_buf = new int[1];

		// Token: 0x040062A7 RID: 25255
		private static readonly uint[] UInt32_buf = new uint[1];

		// Token: 0x040062A8 RID: 25256
		private static readonly float[] float_buf = new float[1];
	}
}
