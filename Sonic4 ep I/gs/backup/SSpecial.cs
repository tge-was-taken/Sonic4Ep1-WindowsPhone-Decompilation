using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x02000413 RID: 1043
	public class SSpecial
	{
		// Token: 0x06002A20 RID: 10784 RVA: 0x00159C10 File Offset: 0x00157E10
		private SSpecialSolo getSpecialSolo(uint index)
		{
			return this.m_stage[(int)((UIntPtr)index)];
		}

		// Token: 0x06002A21 RID: 10785 RVA: 0x00159C1B File Offset: 0x00157E1B
		private SSpecialSolo getSpecialSolo(SStage.EStage.Type index)
		{
			return this.getSpecialSolo(index);
		}

		// Token: 0x170001BA RID: 442
		public SSpecialSolo this[int index]
		{
			get
			{
				return this.m_stage[index];
			}
			set
			{
				this.m_stage[index] = value;
			}
		}

		// Token: 0x06002A24 RID: 10788 RVA: 0x00159C39 File Offset: 0x00157E39
		public static uint GetSize()
		{
			return 7U;
		}

		// Token: 0x06002A25 RID: 10789 RVA: 0x00159C3C File Offset: 0x00157E3C
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					for (int i = 0; i < this.m_stage.Length; i++)
					{
						binaryWriter.Write(this.m_stage[i].getData());
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06002A26 RID: 10790 RVA: 0x00159CBC File Offset: 0x00157EBC
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					for (int i = 0; i < this.m_stage.Length; i++)
					{
						this.m_stage[i].setData(binaryReader.ReadBytes(40));
					}
				}
			}
		}

		// Token: 0x06002A27 RID: 10791 RVA: 0x00159D34 File Offset: 0x00157F34
		public static SSpecial CreateInstance(uint save_index)
		{
			return SBackup.CreateInstance().GetSpecial(save_index);
		}

		// Token: 0x06002A28 RID: 10792 RVA: 0x00159D41 File Offset: 0x00157F41
		public static SSpecial CreateInstance()
		{
			return SBackup.CreateInstance().GetSpecial();
		}

		// Token: 0x06002A29 RID: 10793 RVA: 0x00159D50 File Offset: 0x00157F50
		public void Init()
		{
			int num = 0;
			while ((long)num < 7L)
			{
				this.m_stage[num] = new SSpecialSolo();
				this.m_stage[num].Init();
				num++;
			}
		}

		// Token: 0x04006431 RID: 25649
		private const uint c_size = 7U;

		// Token: 0x04006432 RID: 25650
		private SSpecialSolo[] m_stage = AppMain.New<SSpecialSolo>(7U);
	}
}
