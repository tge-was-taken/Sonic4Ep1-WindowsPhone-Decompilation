using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x02000414 RID: 1044
	public class SBackup
	{
		// Token: 0x06002A2B RID: 10795 RVA: 0x00159D99 File Offset: 0x00157F99
		public uint GetSaveIndex()
		{
			return 0U;
		}

		// Token: 0x06002A2C RID: 10796 RVA: 0x00159D9C File Offset: 0x00157F9C
		public SSystem GetSystem(uint save_index)
		{
			return this.m_system[(int)((UIntPtr)save_index)];
		}

		// Token: 0x06002A2D RID: 10797 RVA: 0x00159DA7 File Offset: 0x00157FA7
		public SSystem GetSystem()
		{
			return this.GetSystem(this.GetSaveIndex());
		}

		// Token: 0x06002A2E RID: 10798 RVA: 0x00159DB5 File Offset: 0x00157FB5
		public SOption GetOption(uint save_index)
		{
			return this.m_option[(int)((UIntPtr)save_index)];
		}

		// Token: 0x06002A2F RID: 10799 RVA: 0x00159DC0 File Offset: 0x00157FC0
		public SOption GetOption()
		{
			return this.GetOption(this.GetSaveIndex());
		}

		// Token: 0x06002A30 RID: 10800 RVA: 0x00159DCE File Offset: 0x00157FCE
		public SStage GetStage(uint save_index)
		{
			return this.m_stage[(int)((UIntPtr)save_index)];
		}

		// Token: 0x06002A31 RID: 10801 RVA: 0x00159DD9 File Offset: 0x00157FD9
		public SStage GetStage()
		{
			return this.GetStage(this.GetSaveIndex());
		}

		// Token: 0x06002A32 RID: 10802 RVA: 0x00159DE7 File Offset: 0x00157FE7
		public SSpecial GetSpecial(uint save_index)
		{
			return this.m_special[(int)((UIntPtr)save_index)];
		}

		// Token: 0x06002A33 RID: 10803 RVA: 0x00159DF2 File Offset: 0x00157FF2
		public SSpecial GetSpecial()
		{
			return this.GetSpecial(this.GetSaveIndex());
		}

		// Token: 0x06002A34 RID: 10804 RVA: 0x00159E00 File Offset: 0x00158000
		private void SetSaveIndex(uint save_index)
		{
		}

		// Token: 0x06002A35 RID: 10805 RVA: 0x00159E02 File Offset: 0x00158002
		public static SBackup CreateInstance()
		{
			return AppMain.GsGetMainSysInfo().backup;
		}

		// Token: 0x06002A36 RID: 10806 RVA: 0x00159E10 File Offset: 0x00158010
		public void Init()
		{
			int num = 0;
			while ((long)num < 1L)
			{
				this.m_system[num] = new SSystem();
				this.m_system[num].Init();
				this.m_option[num] = new SOption();
				this.m_option[num].Init();
				this.m_stage[num] = new SStage();
				this.m_stage[num].Init();
				this.m_special[num] = new SSpecial();
				this.m_special[num].Init();
				num++;
			}
		}

		// Token: 0x06002A37 RID: 10807 RVA: 0x00159E94 File Offset: 0x00158094
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					int num = 0;
					while ((long)num < 1L)
					{
						binaryWriter.Write(this.m_system[num].getData());
						binaryWriter.Write(this.m_option[num].getData());
						binaryWriter.Write(this.m_stage[num].getData());
						binaryWriter.Write(this.m_special[num].getData());
						num++;
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06002A38 RID: 10808 RVA: 0x00159F48 File Offset: 0x00158148
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					int num = 0;
					while ((long)num < 1L)
					{
						this.m_system[num].setData(binaryReader.ReadBytes(68));
						this.m_option[num].setData(binaryReader.ReadBytes(20));
						this.m_stage[num].setData(binaryReader.ReadBytes(1428));
						this.m_special[num].setData(binaryReader.ReadBytes(280));
						num++;
					}
				}
			}
		}

		// Token: 0x04006433 RID: 25651
		private const uint c_save_size = 1U;

		// Token: 0x04006434 RID: 25652
		private SSystem[] m_system = AppMain.New<SSystem>(1U);

		// Token: 0x04006435 RID: 25653
		private SOption[] m_option = AppMain.New<SOption>(1U);

		// Token: 0x04006436 RID: 25654
		private SStage[] m_stage = AppMain.New<SStage>(1U);

		// Token: 0x04006437 RID: 25655
		private SSpecial[] m_special = AppMain.New<SSpecial>(1U);
	}
}
