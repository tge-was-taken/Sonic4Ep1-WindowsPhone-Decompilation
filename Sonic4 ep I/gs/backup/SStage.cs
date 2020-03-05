using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x02000432 RID: 1074
	public class SStage
	{
		// Token: 0x06002ADF RID: 10975 RVA: 0x0015BA00 File Offset: 0x00159C00
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					int num = 0;
					while ((long)num < 17L)
					{
						binaryWriter.Write(this.m_stage[num].getData());
						num++;
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06002AE0 RID: 10976 RVA: 0x0015BA7C File Offset: 0x00159C7C
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					int num = 0;
					while ((long)num < 17L)
					{
						this.m_stage[num].setData(binaryReader.ReadBytes(84));
						num++;
					}
				}
			}
		}

		// Token: 0x06002AE1 RID: 10977 RVA: 0x0015BAF0 File Offset: 0x00159CF0
		public SStageSolo getStageSolo(uint index)
		{
			return this.m_stage[(int)((UIntPtr)index)];
		}

		// Token: 0x06002AE2 RID: 10978 RVA: 0x0015BAFB File Offset: 0x00159CFB
		public SStageSolo getStageSolo(SStage.EStage.Type index)
		{
			return this.getStageSolo((uint)index);
		}

		// Token: 0x170001C6 RID: 454
		public SStageSolo this[int index]
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

		// Token: 0x06002AE5 RID: 10981 RVA: 0x0015BB19 File Offset: 0x00159D19
		public static uint GetSize()
		{
			return 17U;
		}

		// Token: 0x06002AE6 RID: 10982 RVA: 0x0015BB1D File Offset: 0x00159D1D
		public static SStage CreateInstance(uint save_index)
		{
			return SBackup.CreateInstance().GetStage(save_index);
		}

		// Token: 0x06002AE7 RID: 10983 RVA: 0x0015BB2A File Offset: 0x00159D2A
		public static SStage CreateInstance()
		{
			return SBackup.CreateInstance().GetStage();
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x0015BB38 File Offset: 0x00159D38
		public void Init()
		{
			for (int i = 0; i < this.m_stage.Length; i++)
			{
				this.m_stage[i] = new SStageSolo();
				this.m_stage[i].Init();
			}
		}

		// Token: 0x04006498 RID: 25752
		private const uint c_size = 17U;

		// Token: 0x04006499 RID: 25753
		private SStageSolo[] m_stage = AppMain.New<SStageSolo>(17U);

		// Token: 0x02000433 RID: 1075
		public struct EStage
		{
			// Token: 0x02000434 RID: 1076
			public enum Type
			{
				// Token: 0x0400649B RID: 25755
				Zone1Act1,
				// Token: 0x0400649C RID: 25756
				Zone1Act2,
				// Token: 0x0400649D RID: 25757
				Zone1Act3,
				// Token: 0x0400649E RID: 25758
				Zone1Boss,
				// Token: 0x0400649F RID: 25759
				Zone2Act1,
				// Token: 0x040064A0 RID: 25760
				Zone2Act2,
				// Token: 0x040064A1 RID: 25761
				Zone2Act3,
				// Token: 0x040064A2 RID: 25762
				Zone2Boss,
				// Token: 0x040064A3 RID: 25763
				Zone3Act1,
				// Token: 0x040064A4 RID: 25764
				Zone3Act2,
				// Token: 0x040064A5 RID: 25765
				Zone3Act3,
				// Token: 0x040064A6 RID: 25766
				Zone3Boss,
				// Token: 0x040064A7 RID: 25767
				Zone4Act1,
				// Token: 0x040064A8 RID: 25768
				Zone4Act2,
				// Token: 0x040064A9 RID: 25769
				Zone4Act3,
				// Token: 0x040064AA RID: 25770
				Zone4Boss,
				// Token: 0x040064AB RID: 25771
				Final,
				// Token: 0x040064AC RID: 25772
				Max,
				// Token: 0x040064AD RID: 25773
				None
			}
		}
	}
}
