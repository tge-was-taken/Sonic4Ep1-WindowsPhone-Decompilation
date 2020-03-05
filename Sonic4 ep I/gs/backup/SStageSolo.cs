using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x0200042E RID: 1070
	public class SStageSolo
	{
		// Token: 0x06002AC2 RID: 10946 RVA: 0x0015B3AB File Offset: 0x001595AB
		public bool IsNew()
		{
			return this.m_is_new != 0U;
		}

		// Token: 0x06002AC3 RID: 10947 RVA: 0x0015B3B8 File Offset: 0x001595B8
		public bool IsHighScoreUseSuperSonic()
		{
			return this.m_is_high_score_use_supersonic != 0U;
		}

		// Token: 0x06002AC4 RID: 10948 RVA: 0x0015B3C5 File Offset: 0x001595C5
		public bool IsFastTimeUseSuperSonic()
		{
			return this.m_is_fast_time_use_supersonic != 0U;
		}

		// Token: 0x06002AC5 RID: 10949 RVA: 0x0015B3D2 File Offset: 0x001595D2
		public bool IsScoreUploadedOnce()
		{
			return this.m_is_score_uploaded_once != 0U;
		}

		// Token: 0x06002AC6 RID: 10950 RVA: 0x0015B3DF File Offset: 0x001595DF
		public bool IsTimeUploadedOnce()
		{
			return this.m_is_time_uploaded_once != 0U;
		}

		// Token: 0x06002AC7 RID: 10951 RVA: 0x0015B3EC File Offset: 0x001595EC
		public bool IsUseSuperSonicOnce()
		{
			return this.m_is_use_supersonic_once != 0U;
		}

		// Token: 0x06002AC8 RID: 10952 RVA: 0x0015B3FC File Offset: 0x001595FC
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					for (int i = 0; i < this.m_record.Length; i++)
					{
						binaryWriter.Write(this.m_record[i].getData());
					}
					binaryWriter.Write(this.m_is_new);
					binaryWriter.Write(this.m_is_high_score_use_supersonic);
					binaryWriter.Write(this.m_is_fast_time_use_supersonic);
					binaryWriter.Write(this.m_is_score_uploaded_once);
					binaryWriter.Write(this.m_is_time_uploaded_once);
					binaryWriter.Write(this.m_is_use_supersonic_once);
					binaryWriter.Write(this.m_reserve1);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06002AC9 RID: 10953 RVA: 0x0015B4D0 File Offset: 0x001596D0
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					for (int i = 0; i < this.m_record.Length; i++)
					{
						this.m_record[i].setData(binaryReader.ReadBytes(28));
					}
					this.m_is_new = binaryReader.ReadUInt32();
					this.m_is_high_score_use_supersonic = binaryReader.ReadUInt32();
					this.m_is_fast_time_use_supersonic = binaryReader.ReadUInt32();
					this.m_is_score_uploaded_once = binaryReader.ReadUInt32();
					this.m_is_time_uploaded_once = binaryReader.ReadUInt32();
					this.m_is_use_supersonic_once = binaryReader.ReadUInt32();
					this.m_reserve1 = binaryReader.ReadUInt32();
				}
			}
		}

		// Token: 0x06002ACA RID: 10954 RVA: 0x0015B59C File Offset: 0x0015979C
		public void Init()
		{
			int num = this.m_record.Length;
			for (int i = 0; i < num; i++)
			{
				this.m_record[i] = new SStageSolo.SRecord();
				this.m_record[i].high_score = 100000000U;
				this.m_record[i].fast_time = 36000U;
				this.m_record[i].is_high_score_enable = 0U;
				this.m_record[i].is_fast_time_enable = 0U;
				this.m_record[i].is_high_score_uploaded = 0U;
				this.m_record[i].is_fast_time_uploaded = 0U;
			}
			this.m_is_new = 1U;
			this.m_is_high_score_use_supersonic = 0U;
			this.m_is_fast_time_use_supersonic = 0U;
			this.m_is_score_uploaded_once = 0U;
			this.m_is_time_uploaded_once = 0U;
			this.m_is_use_supersonic_once = 0U;
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x0015B651 File Offset: 0x00159851
		private SStageSolo.SRecord getRecord(SStageSolo.ERecordKind.Type record_kind)
		{
			return this.m_record[(int)((UIntPtr)record_kind)];
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x0015B65C File Offset: 0x0015985C
		private SStageSolo.SRecord getRecord(bool is_supersonic)
		{
			return this.getRecord(is_supersonic ? SStageSolo.ERecordKind.Type.SuperSonic : SStageSolo.ERecordKind.Type.Sonic);
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x0015B66B File Offset: 0x0015986B
		public bool IsHighScoreEnable(bool is_supersonic)
		{
			return this.getRecord(is_supersonic).is_high_score_enable != 0U;
		}

		// Token: 0x06002ACE RID: 10958 RVA: 0x0015B67E File Offset: 0x0015987E
		public bool IsFastTimeEnable(bool is_supersonic)
		{
			return this.getRecord(is_supersonic).is_fast_time_enable != 0U;
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x0015B691 File Offset: 0x00159891
		public uint GetHighScore(bool is_supersonic)
		{
			return this.getRecord(is_supersonic).high_score * 10U;
		}

		// Token: 0x06002AD0 RID: 10960 RVA: 0x0015B6A2 File Offset: 0x001598A2
		public uint GetFastTime(bool is_supersonic)
		{
			return this.getRecord(is_supersonic).fast_time;
		}

		// Token: 0x06002AD1 RID: 10961 RVA: 0x0015B6B0 File Offset: 0x001598B0
		public bool IsHighScoreUploaded(bool is_supersonic)
		{
			return this.getRecord(is_supersonic).is_high_score_uploaded != 0U;
		}

		// Token: 0x06002AD2 RID: 10962 RVA: 0x0015B6C3 File Offset: 0x001598C3
		public bool IsFastTimeUploaded(bool is_supersonic)
		{
			return this.getRecord(is_supersonic).is_fast_time_uploaded != 0U;
		}

		// Token: 0x06002AD3 RID: 10963 RVA: 0x0015B6D6 File Offset: 0x001598D6
		public void SetNew(bool is_new)
		{
			this.m_is_new = (is_new ? 1U : 0U);
		}

		// Token: 0x06002AD4 RID: 10964 RVA: 0x0015B6E8 File Offset: 0x001598E8
		public void SetHighScore(uint high_score, bool is_use_supersonic)
		{
			SStageSolo.SRecord record = this.getRecord(is_use_supersonic);
			high_score = Math.Min(high_score, 1000000000U);
			record.high_score = high_score / 10U;
			record.is_high_score_enable = 1U;
			if (this.getRecord(!is_use_supersonic).high_score < record.high_score)
			{
				this.m_is_high_score_use_supersonic = (is_use_supersonic ? 1U : 0U);
			}
			if (is_use_supersonic)
			{
				this.m_is_use_supersonic_once = 1U;
			}
		}

		// Token: 0x06002AD5 RID: 10965 RVA: 0x0015B74C File Offset: 0x0015994C
		public void SetFastTime(uint fast_time, bool is_use_supersonic)
		{
			SStageSolo.SRecord record = this.getRecord(is_use_supersonic);
			fast_time = Math.Min(fast_time, 36000U);
			record.fast_time = fast_time;
			record.is_fast_time_enable = 1U;
			if (record.fast_time < this.getRecord(!is_use_supersonic).fast_time)
			{
				this.m_is_fast_time_use_supersonic = (is_use_supersonic ? 1U : 0U);
			}
			if (is_use_supersonic)
			{
				this.m_is_use_supersonic_once = 1U;
			}
		}

		// Token: 0x06002AD6 RID: 10966 RVA: 0x0015B7AC File Offset: 0x001599AC
		public void SetHighScoreUploaded(bool is_supersonic, bool is_uploaded)
		{
			SStageSolo.SRecord record = this.getRecord(is_supersonic);
			record.is_high_score_uploaded = (is_uploaded ? 1U : 0U);
		}

		// Token: 0x06002AD7 RID: 10967 RVA: 0x0015B7D0 File Offset: 0x001599D0
		public void SetFastTimeUploaded(bool is_supersonic, bool is_uploaded)
		{
			SStageSolo.SRecord record = this.getRecord(is_supersonic);
			record.is_fast_time_uploaded = (is_uploaded ? 1U : 0U);
		}

		// Token: 0x06002AD8 RID: 10968 RVA: 0x0015B7F2 File Offset: 0x001599F2
		public void SetScoreUploadedOnce(bool is_uploaded_once)
		{
			this.m_is_score_uploaded_once = (is_uploaded_once ? 1U : 0U);
		}

		// Token: 0x06002AD9 RID: 10969 RVA: 0x0015B801 File Offset: 0x00159A01
		public void SetTimeUploadedOnce(bool is_uploaded_once)
		{
			this.m_is_time_uploaded_once = (is_uploaded_once ? 1U : 0U);
		}

		// Token: 0x06002ADA RID: 10970 RVA: 0x0015B810 File Offset: 0x00159A10
		public void SetUseSuperSonicOnce(bool is_use_supersonic_once)
		{
			this.m_is_use_supersonic_once = (is_use_supersonic_once ? 1U : 0U);
		}

		// Token: 0x0400647F RID: 25727
		public const uint c_false = 0U;

		// Token: 0x04006480 RID: 25728
		public const uint c_true = 1U;

		// Token: 0x04006481 RID: 25729
		public const uint c_high_score_max_limit = 1000000000U;

		// Token: 0x04006482 RID: 25730
		public const uint c_high_score_unit = 10U;

		// Token: 0x04006483 RID: 25731
		public const uint c_fast_time_max_limit = 36000U;

		// Token: 0x04006484 RID: 25732
		private SStageSolo.SRecord[] m_record = AppMain.New<SStageSolo.SRecord>(2U);

		// Token: 0x04006485 RID: 25733
		private uint m_is_new = 1U;

		// Token: 0x04006486 RID: 25734
		private uint m_is_high_score_use_supersonic = 1U;

		// Token: 0x04006487 RID: 25735
		private uint m_is_fast_time_use_supersonic = 1U;

		// Token: 0x04006488 RID: 25736
		private uint m_is_score_uploaded_once = 1U;

		// Token: 0x04006489 RID: 25737
		private uint m_is_time_uploaded_once = 1U;

		// Token: 0x0400648A RID: 25738
		private uint m_is_use_supersonic_once = 1U;

		// Token: 0x0400648B RID: 25739
		private uint m_reserve1 = 26U;

		// Token: 0x0200042F RID: 1071
		public struct ERecordKind
		{
			// Token: 0x02000430 RID: 1072
			public enum Type
			{
				// Token: 0x0400648D RID: 25741
				Sonic,
				// Token: 0x0400648E RID: 25742
				SuperSonic,
				// Token: 0x0400648F RID: 25743
				Max,
				// Token: 0x04006490 RID: 25744
				None
			}
		}

		// Token: 0x02000431 RID: 1073
		public class SRecord
		{
			// Token: 0x06002ADC RID: 10972 RVA: 0x0015B874 File Offset: 0x00159A74
			public byte[] getData()
			{
				byte[] result = null;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						binaryWriter.Write(this.high_score);
						binaryWriter.Write(this.fast_time);
						binaryWriter.Write(this.is_high_score_enable);
						binaryWriter.Write(this.is_fast_time_enable);
						binaryWriter.Write(this.is_high_score_uploaded);
						binaryWriter.Write(this.is_fast_time_uploaded);
						binaryWriter.Write(this.reserve1);
					}
					result = memoryStream.ToArray();
				}
				return result;
			}

			// Token: 0x06002ADD RID: 10973 RVA: 0x0015B920 File Offset: 0x00159B20
			public void setData(byte[] data)
			{
				using (MemoryStream memoryStream = new MemoryStream(data))
				{
					using (BinaryReader binaryReader = new BinaryReader(memoryStream))
					{
						this.high_score = binaryReader.ReadUInt32();
						this.fast_time = binaryReader.ReadUInt32();
						this.is_high_score_enable = binaryReader.ReadUInt32();
						this.is_fast_time_enable = binaryReader.ReadUInt32();
						this.is_high_score_uploaded = binaryReader.ReadUInt32();
						this.is_fast_time_uploaded = binaryReader.ReadUInt32();
						this.reserve1 = binaryReader.ReadUInt32();
					}
				}
			}

			// Token: 0x04006491 RID: 25745
			public uint high_score = 32U;

			// Token: 0x04006492 RID: 25746
			public uint fast_time = 16U;

			// Token: 0x04006493 RID: 25747
			public uint is_high_score_enable = 1U;

			// Token: 0x04006494 RID: 25748
			public uint is_fast_time_enable = 1U;

			// Token: 0x04006495 RID: 25749
			public uint is_high_score_uploaded = 1U;

			// Token: 0x04006496 RID: 25750
			public uint is_fast_time_uploaded = 1U;

			// Token: 0x04006497 RID: 25751
			public uint reserve1 = 12U;
		}
	}
}
