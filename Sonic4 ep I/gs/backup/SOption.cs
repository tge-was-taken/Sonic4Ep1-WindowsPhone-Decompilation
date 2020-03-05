using System;
using System.IO;

namespace gs.backup
{
	// Token: 0x02000400 RID: 1024
	public class SOption
	{
		// Token: 0x0600292D RID: 10541 RVA: 0x00157CF8 File Offset: 0x00155EF8
		public bool IsVibration()
		{
			return this.m_is_vibration != 0U;
		}

		// Token: 0x0600292E RID: 10542 RVA: 0x00157D05 File Offset: 0x00155F05
		public uint GetVolumeBgm()
		{
			return this.m_volume_bgm * 10U;
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x00157D10 File Offset: 0x00155F10
		public uint GetVolumeSe()
		{
			return this.m_volume_se * 10U;
		}

		// Token: 0x06002930 RID: 10544 RVA: 0x00157D1B File Offset: 0x00155F1B
		public SOption.EControl.Type GetControl()
		{
			return (SOption.EControl.Type)this.m_control;
		}

		// Token: 0x06002931 RID: 10545 RVA: 0x00157D24 File Offset: 0x00155F24
		public byte[] getData()
		{
			byte[] result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.m_is_vibration);
					binaryWriter.Write(this.m_volume_bgm);
					binaryWriter.Write(this.m_volume_se);
					binaryWriter.Write(this.m_control);
					binaryWriter.Write(this.m_reserve1);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06002932 RID: 10546 RVA: 0x00157DB8 File Offset: 0x00155FB8
		public void setData(byte[] data)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					this.m_is_vibration = binaryReader.ReadUInt32();
					this.m_volume_bgm = binaryReader.ReadUInt32();
					this.m_volume_se = binaryReader.ReadUInt32();
					this.m_control = binaryReader.ReadUInt32();
					this.m_reserve1 = binaryReader.ReadUInt32();
				}
			}
		}

		// Token: 0x06002933 RID: 10547 RVA: 0x00157E44 File Offset: 0x00156044
		public static SOption CreateInstance(uint save_index)
		{
			return SBackup.CreateInstance().GetOption(save_index);
		}

		// Token: 0x06002934 RID: 10548 RVA: 0x00157E51 File Offset: 0x00156051
		public static SOption CreateInstance()
		{
			return SBackup.CreateInstance().GetOption();
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x00157E5D File Offset: 0x0015605D
		public void Init()
		{
			this.m_is_vibration = 1U;
			this.m_volume_bgm = 10U;
			this.m_volume_se = 10U;
			this.m_control = 1U;
		}

		// Token: 0x06002936 RID: 10550 RVA: 0x00157E7D File Offset: 0x0015607D
		private void SetVibration(bool is_vibration)
		{
			this.m_is_vibration = (is_vibration ? 1U : 0U);
		}

		// Token: 0x06002937 RID: 10551 RVA: 0x00157E8C File Offset: 0x0015608C
		public void SetVolumeBgm(uint volume_bgm)
		{
			volume_bgm = Math.Min(volume_bgm, 100U);
			this.m_volume_bgm = volume_bgm / 10U;
		}

		// Token: 0x06002938 RID: 10552 RVA: 0x00157EA2 File Offset: 0x001560A2
		public void SetVolumeSe(uint volume_se)
		{
			volume_se = Math.Min(volume_se, 100U);
			this.m_volume_se = volume_se / 10U;
		}

		// Token: 0x06002939 RID: 10553 RVA: 0x00157EB8 File Offset: 0x001560B8
		public void SetControl(SOption.EControl.Type control)
		{
			control = (SOption.EControl.Type)Math.Min((uint)control, 3U);
			this.m_control = (uint)control;
		}

		// Token: 0x040063B2 RID: 25522
		public const uint c_false = 0U;

		// Token: 0x040063B3 RID: 25523
		public const uint c_true = 1U;

		// Token: 0x040063B4 RID: 25524
		public const uint c_volume_bgm_max_limit = 100U;

		// Token: 0x040063B5 RID: 25525
		public const uint c_volume_bgm_unit = 10U;

		// Token: 0x040063B6 RID: 25526
		public const uint c_volume_se_max_limit = 100U;

		// Token: 0x040063B7 RID: 25527
		public const uint c_volume_se_unit = 10U;

		// Token: 0x040063B8 RID: 25528
		public const uint c_name_length_limit = 10U;

		// Token: 0x040063B9 RID: 25529
		public const uint c_name_length_limit_pad = 16U;

		// Token: 0x040063BA RID: 25530
		private uint m_is_vibration = 1U;

		// Token: 0x040063BB RID: 25531
		private uint m_volume_bgm = 4U;

		// Token: 0x040063BC RID: 25532
		private uint m_volume_se = 4U;

		// Token: 0x040063BD RID: 25533
		private uint m_control = 2U;

		// Token: 0x040063BE RID: 25534
		private uint m_reserve1 = 21U;

		// Token: 0x02000401 RID: 1025
		public struct EControl
		{
			// Token: 0x02000402 RID: 1026
			public enum Type
			{
				// Token: 0x040063C0 RID: 25536
				Tilt,
				// Token: 0x040063C1 RID: 25537
				VirtualPadDown,
				// Token: 0x040063C2 RID: 25538
				VirtualPadUp,
				// Token: 0x040063C3 RID: 25539
				Max,
				// Token: 0x040063C4 RID: 25540
				None
			}
		}
	}
}
