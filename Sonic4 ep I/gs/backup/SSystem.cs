using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x0200040C RID: 1036
	public class SSystem
	{
		// Token: 0x060029FB RID: 10747 RVA: 0x0015939B File Offset: 0x0015759B
		public uint GetPlayerStock()
		{
			return this.m_player_stock;
		}

		// Token: 0x060029FC RID: 10748 RVA: 0x001593A3 File Offset: 0x001575A3
		public uint GetKilled()
		{
			return this.m_killed;
		}

		// Token: 0x060029FD RID: 10749 RVA: 0x001593AB File Offset: 0x001575AB
		public uint GetClearCount()
		{
			return this.m_clear_count;
		}

		// Token: 0x060029FE RID: 10750 RVA: 0x001593B4 File Offset: 0x001575B4
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.m_player_stock);
					binaryWriter.Write(this.m_killed);
					binaryWriter.Write(this.m_clear_count);
					binaryWriter.Write(this.m_announce_open_zone_select);
					binaryWriter.Write(this.m_announce_open_zone1_boss);
					binaryWriter.Write(this.m_announce_open_zone2_boss);
					binaryWriter.Write(this.m_announce_open_zone3_boss);
					binaryWriter.Write(this.m_announce_open_zone4_boss);
					binaryWriter.Write(this.m_announce_open_final_zone);
					binaryWriter.Write(this.m_announce_open_supersonic);
					binaryWriter.Write(this.m_announce_open_specialstage);
					binaryWriter.Write(this.m_reserve1);
					binaryWriter.Write(this.m_announcetruck_tilt);
					binaryWriter.Write(this.m_announcetruck_flick);
					binaryWriter.Write(this.m_announcespecial_stage_tilt);
					binaryWriter.Write(this.m_announcespecial_stage_flick);
					binaryWriter.Write(this.m_reserve2);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060029FF RID: 10751 RVA: 0x001594D8 File Offset: 0x001576D8
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					this.m_player_stock = binaryReader.ReadUInt32();
					this.m_killed = binaryReader.ReadUInt32();
					this.m_clear_count = binaryReader.ReadUInt32();
					this.m_announce_open_zone_select = binaryReader.ReadUInt32();
					this.m_announce_open_zone1_boss = binaryReader.ReadUInt32();
					this.m_announce_open_zone2_boss = binaryReader.ReadUInt32();
					this.m_announce_open_zone3_boss = binaryReader.ReadUInt32();
					this.m_announce_open_zone4_boss = binaryReader.ReadUInt32();
					this.m_announce_open_final_zone = binaryReader.ReadUInt32();
					this.m_announce_open_supersonic = binaryReader.ReadUInt32();
					this.m_announce_open_specialstage = binaryReader.ReadUInt32();
					this.m_reserve1 = binaryReader.ReadUInt32();
					this.m_announcetruck_tilt = binaryReader.ReadUInt32();
					this.m_announcetruck_flick = binaryReader.ReadUInt32();
					this.m_announcespecial_stage_tilt = binaryReader.ReadUInt32();
					this.m_announcespecial_stage_flick = binaryReader.ReadUInt32();
					this.m_reserve2 = binaryReader.ReadUInt32();
				}
			}
		}

		// Token: 0x06002A00 RID: 10752 RVA: 0x001595F4 File Offset: 0x001577F4
		public static SSystem CreateInstance(uint save_index)
		{
			return SBackup.CreateInstance().GetSystem(save_index);
		}

		// Token: 0x06002A01 RID: 10753 RVA: 0x00159601 File Offset: 0x00157801
		public static SSystem CreateInstance()
		{
			return SBackup.CreateInstance().GetSystem();
		}

		// Token: 0x06002A02 RID: 10754 RVA: 0x00159610 File Offset: 0x00157810
		public void Init()
		{
			this.m_player_stock = 3U;
			this.m_killed = 0U;
			this.m_clear_count = 0U;
			this.m_announce_open_zone_select = 0U;
			this.m_announce_open_zone1_boss = 0U;
			this.m_announce_open_zone2_boss = 0U;
			this.m_announce_open_zone3_boss = 0U;
			this.m_announce_open_zone4_boss = 0U;
			this.m_announce_open_final_zone = 0U;
			this.m_announce_open_supersonic = 0U;
			this.m_announce_open_specialstage = 0U;
			this.m_announcetruck_tilt = 0U;
			this.m_announcetruck_flick = 0U;
			this.m_announcespecial_stage_tilt = 0U;
			this.m_announcespecial_stage_flick = 0U;
		}

		// Token: 0x06002A03 RID: 10755 RVA: 0x00159688 File Offset: 0x00157888
		public bool IsAnnounce(SSystem.EAnnounce index)
		{
			uint result;
			switch (index)
			{
			case SSystem.EAnnounce.OpenZoneSelect:
				result = this.m_announce_open_zone_select;
				break;
			case SSystem.EAnnounce.OpenZone1Boss:
				result = this.m_announce_open_zone1_boss;
				break;
			case SSystem.EAnnounce.OpenZone2Boss:
				result = this.m_announce_open_zone2_boss;
				break;
			case SSystem.EAnnounce.OpenZone3Boss:
				result = this.m_announce_open_zone3_boss;
				break;
			case SSystem.EAnnounce.OpenZone4Boss:
				result = this.m_announce_open_zone4_boss;
				break;
			case SSystem.EAnnounce.OpenFinalZone:
				result = this.m_announce_open_final_zone;
				break;
			case SSystem.EAnnounce.OpenSuperSonic:
				result = this.m_announce_open_supersonic;
				break;
			case SSystem.EAnnounce.OpenSpecialStage:
				result = this.m_announce_open_specialstage;
				break;
			case SSystem.EAnnounce.TruckTilt:
				result = this.m_announcetruck_tilt;
				break;
			case SSystem.EAnnounce.TruckFlick:
				result = this.m_announcetruck_flick;
				break;
			case SSystem.EAnnounce.SpecialStageTilt:
				result = this.m_announcespecial_stage_tilt;
				break;
			case SSystem.EAnnounce.SpecialStageFlick:
				result = this.m_announcespecial_stage_flick;
				break;
			default:
				result = 0U;
				break;
			}
			return result != 0U;
		}

		// Token: 0x06002A04 RID: 10756 RVA: 0x00159743 File Offset: 0x00157943
		public void SetPlayerStock(uint player_stock)
		{
			player_stock = Math.Min(player_stock, 1000U);
			this.m_player_stock = player_stock;
		}

		// Token: 0x06002A05 RID: 10757 RVA: 0x00159759 File Offset: 0x00157959
		public void SetKilled(uint killed)
		{
			killed = Math.Min(killed, 1000U);
			this.m_killed = killed;
		}

		// Token: 0x06002A06 RID: 10758 RVA: 0x0015976F File Offset: 0x0015796F
		public void SetClearCount(uint count)
		{
			count = Math.Min(count, 2U);
			this.m_clear_count = count;
		}

		// Token: 0x06002A07 RID: 10759 RVA: 0x00159784 File Offset: 0x00157984
		public void SetAnnounce(SSystem.EAnnounce index, bool is_announce)
		{
			uint num = is_announce ? 1U : 0U;
			switch (index)
			{
			case SSystem.EAnnounce.OpenZoneSelect:
				this.m_announce_open_zone_select = num;
				return;
			case SSystem.EAnnounce.OpenZone1Boss:
				this.m_announce_open_zone1_boss = num;
				return;
			case SSystem.EAnnounce.OpenZone2Boss:
				this.m_announce_open_zone2_boss = num;
				return;
			case SSystem.EAnnounce.OpenZone3Boss:
				this.m_announce_open_zone3_boss = num;
				return;
			case SSystem.EAnnounce.OpenZone4Boss:
				this.m_announce_open_zone4_boss = num;
				return;
			case SSystem.EAnnounce.OpenFinalZone:
				this.m_announce_open_final_zone = num;
				return;
			case SSystem.EAnnounce.OpenSuperSonic:
				this.m_announce_open_supersonic = num;
				return;
			case SSystem.EAnnounce.OpenSpecialStage:
				this.m_announce_open_specialstage = num;
				return;
			case SSystem.EAnnounce.TruckTilt:
				this.m_announcetruck_tilt = num;
				return;
			case SSystem.EAnnounce.TruckFlick:
				this.m_announcetruck_flick = num;
				return;
			case SSystem.EAnnounce.SpecialStageTilt:
				this.m_announcespecial_stage_tilt = num;
				return;
			case SSystem.EAnnounce.SpecialStageFlick:
				this.m_announcespecial_stage_flick = num;
				return;
			default:
				return;
			}
		}

		// Token: 0x040063E3 RID: 25571
		public const uint c_false = 0U;

		// Token: 0x040063E4 RID: 25572
		public const uint c_true = 1U;

		// Token: 0x040063E5 RID: 25573
		public const uint c_player_stock_limit = 1000U;

		// Token: 0x040063E6 RID: 25574
		public const uint c_killed_limit = 1000U;

		// Token: 0x040063E7 RID: 25575
		public const uint c_clear_count_limit = 2U;

		// Token: 0x040063E8 RID: 25576
		private uint m_player_stock = 10U;

		// Token: 0x040063E9 RID: 25577
		private uint m_killed = 10U;

		// Token: 0x040063EA RID: 25578
		private uint m_clear_count = 2U;

		// Token: 0x040063EB RID: 25579
		private uint m_announce_open_zone_select = 1U;

		// Token: 0x040063EC RID: 25580
		private uint m_announce_open_zone1_boss = 1U;

		// Token: 0x040063ED RID: 25581
		private uint m_announce_open_zone2_boss = 1U;

		// Token: 0x040063EE RID: 25582
		private uint m_announce_open_zone3_boss = 1U;

		// Token: 0x040063EF RID: 25583
		private uint m_announce_open_zone4_boss = 1U;

		// Token: 0x040063F0 RID: 25584
		private uint m_announce_open_final_zone = 1U;

		// Token: 0x040063F1 RID: 25585
		private uint m_announce_open_supersonic = 1U;

		// Token: 0x040063F2 RID: 25586
		private uint m_announce_open_specialstage = 1U;

		// Token: 0x040063F3 RID: 25587
		private uint m_reserve1 = 2U;

		// Token: 0x040063F4 RID: 25588
		private uint m_announcetruck_tilt = 1U;

		// Token: 0x040063F5 RID: 25589
		private uint m_announcetruck_flick = 1U;

		// Token: 0x040063F6 RID: 25590
		private uint m_announcespecial_stage_tilt = 1U;

		// Token: 0x040063F7 RID: 25591
		private uint m_announcespecial_stage_flick = 1U;

		// Token: 0x040063F8 RID: 25592
		private uint m_reserve2 = 28U;

		// Token: 0x0200040D RID: 1037
		public enum EAnnounce
		{
			// Token: 0x040063FA RID: 25594
			OpenZoneSelect,
			// Token: 0x040063FB RID: 25595
			OpenZone1Boss,
			// Token: 0x040063FC RID: 25596
			OpenZone2Boss,
			// Token: 0x040063FD RID: 25597
			OpenZone3Boss,
			// Token: 0x040063FE RID: 25598
			OpenZone4Boss,
			// Token: 0x040063FF RID: 25599
			OpenFinalZone,
			// Token: 0x04006400 RID: 25600
			OpenSuperSonic,
			// Token: 0x04006401 RID: 25601
			OpenSpecialStage,
			// Token: 0x04006402 RID: 25602
			TruckTilt,
			// Token: 0x04006403 RID: 25603
			TruckFlick,
			// Token: 0x04006404 RID: 25604
			SpecialStageTilt,
			// Token: 0x04006405 RID: 25605
			SpecialStageFlick,
			// Token: 0x04006406 RID: 25606
			Max,
			// Token: 0x04006407 RID: 25607
			None
		}
	}
}
