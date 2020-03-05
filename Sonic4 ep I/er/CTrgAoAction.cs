using System;

namespace er
{
	// Token: 0x02000429 RID: 1065
	public class CTrgAoAction : CTrgBase<CTrgState>
	{
		// Token: 0x06002AB0 RID: 10928 RVA: 0x0015B091 File Offset: 0x00159291
		public CTrgAoAction()
		{
			this.Constructor();
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x0015B0AC File Offset: 0x001592AC
		~CTrgAoAction()
		{
			this.Destructor();
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x0015B0D8 File Offset: 0x001592D8
		public void Constructor()
		{
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x0015B0DA File Offset: 0x001592DA
		public void Destructor()
		{
		}

		// Token: 0x06002AB4 RID: 10932 RVA: 0x0015B0DC File Offset: 0x001592DC
		public bool Create(AppMain.AOS_ACTION act)
		{
			this.Release();
			this.m_act = act;
			return this.create();
		}

		// Token: 0x06002AB5 RID: 10933 RVA: 0x0015B0F1 File Offset: 0x001592F1
		public virtual void Release()
		{
			if (this.m_flag[0])
			{
				this.m_flag[0] = false;
			}
		}

		// Token: 0x06002AB6 RID: 10934 RVA: 0x0015B106 File Offset: 0x00159306
		public override bool IsValid()
		{
			return this.m_flag[0];
		}

		// Token: 0x06002AB7 RID: 10935 RVA: 0x0015B110 File Offset: 0x00159310
		protected bool create()
		{
			bool result;
			if (this.m_act == null)
			{
				result = false;
			}
			else
			{
				result = true;
				base.ResetState();
				base.SetRepeatInterval();
				base.SetDoubleClickTime();
				base.SetMoveThreshold();
				this.m_flag[0] = true;
			}
			return result;
		}

		// Token: 0x06002AB8 RID: 10936 RVA: 0x0015B150 File Offset: 0x00159350
		protected override bool hitTest(IntPair pos, uint index)
		{
			bool result = false;
			if (this.m_flag[0])
			{
				uint num = AppMain.AoActGetHitNum(this.m_act);
				AppMain.AOS_ACT_HIT[] array = AppMain.New<AppMain.AOS_ACT_HIT>((int)num);
				AppMain.AoActGetHitTbl(array, num, this.m_act);
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					if (AppMain.AoActHitTestCorReverse(array[num2], (float)pos.first, (float)pos.second))
					{
						result = true;
						break;
					}
					num2++;
				}
			}
			return result;
		}

		// Token: 0x04006473 RID: 25715
		private bool[] m_flag = new bool[1];

		// Token: 0x04006474 RID: 25716
		private AppMain.AOS_ACTION m_act;

		// Token: 0x0200042A RID: 1066
		private struct BFlag
		{
			// Token: 0x04006475 RID: 25717
			public const int Setup = 0;

			// Token: 0x04006476 RID: 25718
			public const int Max = 1;

			// Token: 0x04006477 RID: 25719
			public const int None = 2;
		}
	}
}
