using System;
using Microsoft.Xna.Framework;

namespace er
{
	// Token: 0x0200042B RID: 1067
	public class CTrgRect : CTrgBase<CTrgState>
	{
		// Token: 0x06002AB9 RID: 10937 RVA: 0x0015B1BC File Offset: 0x001593BC
		public bool Create(Rectangle rect)
		{
			this.Release();
			this.m_rect = rect;
			return this.create();
		}

		// Token: 0x06002ABA RID: 10938 RVA: 0x0015B1D4 File Offset: 0x001593D4
		public bool Create(IntPair xy1, IntPair xy2)
		{
			this.Release();
			this.m_rect.X = xy1.first;
			this.m_rect.Y = xy1.second;
			this.m_rect.Width = xy2.first - xy1.first + 1;
			this.m_rect.Height = xy2.second - xy1.second + 1;
			return this.create();
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x0015B24C File Offset: 0x0015944C
		public bool Create(int x1, int y1, int x2, int y2)
		{
			this.Release();
			this.m_rect.X = x1;
			this.m_rect.Y = y1;
			this.m_rect.Width = x2 - x1 + 1;
			this.m_rect.Height = y2 - y1 + 1;
			return this.create();
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x0015B29E File Offset: 0x0015949E
		public void Release()
		{
			if (this.m_flag[0])
			{
				this.m_flag[0] = false;
			}
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x0015B2B3 File Offset: 0x001594B3
		public override bool IsValid()
		{
			return this.m_flag[0];
		}

		// Token: 0x06002ABE RID: 10942 RVA: 0x0015B2BD File Offset: 0x001594BD
		public bool create()
		{
			this.m_pos = default(IntPair);
			base.ResetState();
			base.SetRepeatInterval();
			base.SetDoubleClickTime();
			base.SetMoveThreshold();
			this.m_flag[0] = true;
			return true;
		}

		// Token: 0x06002ABF RID: 10943 RVA: 0x0015B2F0 File Offset: 0x001594F0
		protected override bool hitTest(IntPair pos, uint index)
		{
			bool result = false;
			if (this.m_flag[0] && pos.first >= this.m_pos.first + this.m_rect.Left && this.m_pos.first + this.m_rect.Right >= pos.first && pos.second >= this.m_pos.second + this.m_rect.Top && this.m_pos.second + this.m_rect.Bottom >= pos.second)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x04006478 RID: 25720
		private bool[] m_flag = new bool[1];

		// Token: 0x04006479 RID: 25721
		private IntPair m_pos;

		// Token: 0x0400647A RID: 25722
		private Rectangle m_rect;

		// Token: 0x0200042C RID: 1068
		private struct BFlag
		{
			// Token: 0x0400647B RID: 25723
			public const int Setup = 0;

			// Token: 0x0400647C RID: 25724
			public const int Max = 1;

			// Token: 0x0400647D RID: 25725
			public const int None = 2;
		}
	}
}
