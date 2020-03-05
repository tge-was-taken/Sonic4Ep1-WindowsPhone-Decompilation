using System;

namespace dbg
{
	// Token: 0x02000437 RID: 1079
	internal class CPadEmu
	{
		// Token: 0x06002B01 RID: 11009 RVA: 0x0015BC7E File Offset: 0x00159E7E
		public static CPadEmu CreateInstance()
		{
			if (CPadEmu.instance == null)
			{
				CPadEmu.instance = new CPadEmu();
			}
			return CPadEmu.instance;
		}

		// Token: 0x06002B02 RID: 11010 RVA: 0x0015BC96 File Offset: 0x00159E96
		public void Create(CPadEmu.EMode mode)
		{
		}

		// Token: 0x040064B1 RID: 25777
		private static CPadEmu instance;

		// Token: 0x02000438 RID: 1080
		public enum EMode
		{
			// Token: 0x040064B3 RID: 25779
			Tap,
			// Token: 0x040064B4 RID: 25780
			Drag,
			// Token: 0x040064B5 RID: 25781
			Game,
			// Token: 0x040064B6 RID: 25782
			Dummy,
			// Token: 0x040064B7 RID: 25783
			Max,
			// Token: 0x040064B8 RID: 25784
			None
		}
	}
}
