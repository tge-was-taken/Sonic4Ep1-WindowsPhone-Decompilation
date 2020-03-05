using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x02000412 RID: 1042
	public class SSpecialSolo
	{
		// Token: 0x06002A09 RID: 10761 RVA: 0x001598C4 File Offset: 0x00157AC4
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.m_high_score);
					binaryWriter.Write(this.m_fast_time);
					binaryWriter.Write(this.m_is_high_score_enable);
					binaryWriter.Write(this.m_is_fast_time_enable);
					binaryWriter.Write(this.m_is_high_score_uploaded);
					binaryWriter.Write(this.m_is_fast_time_uploaded);
					binaryWriter.Write(this.m_emerald_stage);
					binaryWriter.Write(this.m_is_score_uploaded_once);
					binaryWriter.Write(this.m_is_time_uploaded_once);
					binaryWriter.Write(this.m_reserve1);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06002A0A RID: 10762 RVA: 0x00159994 File Offset: 0x00157B94
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					this.m_high_score = binaryReader.ReadUInt32();
					this.m_fast_time = binaryReader.ReadUInt32();
					this.m_is_high_score_enable = binaryReader.ReadUInt32();
					this.m_is_fast_time_enable = binaryReader.ReadUInt32();
					this.m_is_high_score_uploaded = binaryReader.ReadUInt32();
					this.m_is_fast_time_uploaded = binaryReader.ReadUInt32();
					this.m_emerald_stage = binaryReader.ReadUInt32();
					this.m_is_score_uploaded_once = binaryReader.ReadUInt32();
					this.m_is_time_uploaded_once = binaryReader.ReadUInt32();
					this.m_reserve1 = binaryReader.ReadUInt32();
				}
			}
		}

		// Token: 0x06002A0B RID: 10763 RVA: 0x00159A5C File Offset: 0x00157C5C
		public void Init()
		{
			this.m_high_score = 100000000U;
			this.m_fast_time = 36000U;
			this.m_is_high_score_enable = 0U;
			this.m_is_fast_time_enable = 0U;
			this.m_is_high_score_uploaded = 0U;
			this.m_is_fast_time_uploaded = 0U;
			this.m_emerald_stage = 0U;
			this.m_is_score_uploaded_once = 0U;
			this.m_is_time_uploaded_once = 0U;
		}

		// Token: 0x06002A0C RID: 10764 RVA: 0x00159AB0 File Offset: 0x00157CB0
		public bool IsNew()
		{
			return false;
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x00159AB3 File Offset: 0x00157CB3
		public bool IsHighScoreEnable()
		{
			return this.m_is_high_score_enable != 0U;
		}

		// Token: 0x06002A0E RID: 10766 RVA: 0x00159AC0 File Offset: 0x00157CC0
		public bool IsFastTimeEnable()
		{
			return this.m_is_fast_time_enable != 0U;
		}

		// Token: 0x06002A0F RID: 10767 RVA: 0x00159ACD File Offset: 0x00157CCD
		public uint GetHighScore()
		{
			return this.m_high_score * 10U;
		}

		// Token: 0x06002A10 RID: 10768 RVA: 0x00159AD8 File Offset: 0x00157CD8
		public uint GetFastTime()
		{
			return this.m_fast_time;
		}

		// Token: 0x06002A11 RID: 10769 RVA: 0x00159AE0 File Offset: 0x00157CE0
		public bool IsHighScoreUploaded()
		{
			return this.m_is_high_score_uploaded != 0U;
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x00159AED File Offset: 0x00157CED
		public bool IsFastTimeUploaded()
		{
			return this.m_is_fast_time_uploaded != 0U;
		}

		// Token: 0x06002A13 RID: 10771 RVA: 0x00159AFA File Offset: 0x00157CFA
		public bool IsGetEmerald()
		{
			return this.m_emerald_stage != 0U;
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x00159B07 File Offset: 0x00157D07
		public EEmeraldStage.Type GetEmeraldStage()
		{
			return (EEmeraldStage.Type)this.m_emerald_stage;
		}

		// Token: 0x06002A15 RID: 10773 RVA: 0x00159B0F File Offset: 0x00157D0F
		public bool IsScoreUploadedOnce()
		{
			return this.m_is_score_uploaded_once != 0U;
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x00159B1C File Offset: 0x00157D1C
		public bool IsTimeUploadedOnce()
		{
			return this.m_is_time_uploaded_once != 0U;
		}

		// Token: 0x06002A17 RID: 10775 RVA: 0x00159B29 File Offset: 0x00157D29
		public void SetNew(bool val)
		{
		}

		// Token: 0x06002A18 RID: 10776 RVA: 0x00159B2B File Offset: 0x00157D2B
		public void SetHighScore(uint high_score)
		{
			high_score = Math.Min(high_score, 1000000000U);
			this.m_high_score = high_score / 10U;
			this.m_is_high_score_enable = 1U;
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x00159B4B File Offset: 0x00157D4B
		public void SetFastTime(uint fast_time)
		{
			fast_time = Math.Min(fast_time, 36000U);
			this.m_fast_time = fast_time;
			this.m_is_fast_time_enable = 1U;
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x00159B68 File Offset: 0x00157D68
		public void SetHighScoreUploaded(bool is_uploaded)
		{
			this.m_is_high_score_uploaded = (is_uploaded ? 1U : 0U);
		}

		// Token: 0x06002A1B RID: 10779 RVA: 0x00159B77 File Offset: 0x00157D77
		public void SetFastTimeUploaded(bool is_uploaded)
		{
			this.m_is_fast_time_uploaded = (is_uploaded ? 1U : 0U);
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x00159B86 File Offset: 0x00157D86
		public void SetEmeraldStage(EEmeraldStage.Type emerald_stage)
		{
			this.m_emerald_stage = Math.Min((uint)emerald_stage, 13U);
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x00159B96 File Offset: 0x00157D96
		public void SetScoreUploadedOnce(bool is_uploaded_once)
		{
			this.m_is_score_uploaded_once = (is_uploaded_once ? 1U : 0U);
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x00159BA5 File Offset: 0x00157DA5
		public void SetTimeUploadedOnce(bool is_uploaded_once)
		{
			this.m_is_time_uploaded_once = (is_uploaded_once ? 1U : 0U);
		}

		// Token: 0x04006422 RID: 25634
		public const uint c_false = 0U;

		// Token: 0x04006423 RID: 25635
		public const uint c_true = 1U;

		// Token: 0x04006424 RID: 25636
		public const uint c_high_score_max_limit = 1000000000U;

		// Token: 0x04006425 RID: 25637
		public const uint c_high_score_unit = 10U;

		// Token: 0x04006426 RID: 25638
		public const uint c_fast_time_max_limit = 36000U;

		// Token: 0x04006427 RID: 25639
		public uint m_high_score = 32U;

		// Token: 0x04006428 RID: 25640
		public uint m_fast_time = 16U;

		// Token: 0x04006429 RID: 25641
		public uint m_is_high_score_enable = 1U;

		// Token: 0x0400642A RID: 25642
		public uint m_is_fast_time_enable = 1U;

		// Token: 0x0400642B RID: 25643
		public uint m_is_high_score_uploaded = 1U;

		// Token: 0x0400642C RID: 25644
		public uint m_is_fast_time_uploaded = 1U;

		// Token: 0x0400642D RID: 25645
		public uint m_emerald_stage = 4U;

		// Token: 0x0400642E RID: 25646
		public uint m_is_score_uploaded_once = 1U;

		// Token: 0x0400642F RID: 25647
		public uint m_is_time_uploaded_once = 1U;

		// Token: 0x04006430 RID: 25648
		public uint m_reserve1 = 24U;
	}
}
