using System;
using accel;

namespace er
{
	// Token: 0x0200040A RID: 1034
	public class CTrgFlick : CTrgBase<CTrgStateEx>
	{
		// Token: 0x060029F3 RID: 10739 RVA: 0x001591ED File Offset: 0x001573ED
		public bool Create(CArray4<int> rect)
		{
			this.Release();
			this.m_rect = rect;
			return this.create();
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x00159204 File Offset: 0x00157404
		public bool Create(CArray2<int> xy1, CArray2<int> xy2)
		{
			this.Release();
			this.m_rect.left = xy1.x;
			this.m_rect.top = xy1.y;
			this.m_rect.right = xy2.x;
			this.m_rect.bottom = xy2.y;
			return this.create();
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x00159265 File Offset: 0x00157465
		public bool Create(int x1, int y1, int x2, int y2)
		{
			this.Release();
			this.m_rect.left = x1;
			this.m_rect.top = y1;
			this.m_rect.right = x2;
			this.m_rect.bottom = y2;
			return this.create();
		}

		// Token: 0x060029F6 RID: 10742 RVA: 0x001592A4 File Offset: 0x001574A4
		public void Release()
		{
			if (this.m_flag[0])
			{
				this.m_flag[0] = false;
			}
		}

		// Token: 0x060029F7 RID: 10743 RVA: 0x001592B9 File Offset: 0x001574B9
		public override bool IsValid()
		{
			return this.m_flag[0];
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x001592C3 File Offset: 0x001574C3
		public bool create()
		{
			base.ResetState();
			base.SetRepeatInterval();
			base.SetDoubleClickTime();
			base.SetMoveThreshold();
			this.m_flag[0] = true;
			return true;
		}

		// Token: 0x060029F9 RID: 10745 RVA: 0x001592E8 File Offset: 0x001574E8
		protected override bool hitTest(IntPair pos, uint index)
		{
			bool result = false;
			if (this.m_flag[0] && pos.first >= this.m_pos.x + this.m_rect.left && this.m_pos.x + this.m_rect.right >= pos.first && pos.second >= this.m_pos.y + this.m_rect.top && this.m_pos.y + this.m_rect.bottom >= pos.second)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x040063DC RID: 25564
		private bool[] m_flag = new bool[1];

		// Token: 0x040063DD RID: 25565
		private CArray2<int> m_pos;

		// Token: 0x040063DE RID: 25566
		private CArray4<int> m_rect;

		// Token: 0x0200040B RID: 1035
		public enum BFlag
		{
			// Token: 0x040063E0 RID: 25568
			Setup,
			// Token: 0x040063E1 RID: 25569
			Max,
			// Token: 0x040063E2 RID: 25570
			None
		}
	}
}
