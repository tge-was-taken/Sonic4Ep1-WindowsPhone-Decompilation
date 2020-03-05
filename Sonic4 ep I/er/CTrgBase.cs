using System;

namespace er
{
	// Token: 0x02000408 RID: 1032
	public class CTrgBase<T> where T : CTrgState, new()
	{
		// Token: 0x060029D7 RID: 10711 RVA: 0x00158CAC File Offset: 0x00156EAC
		public virtual void Update()
		{
			if (this.IsValid() && !this.m_flag[0])
			{
				for (int i = 0; i < AppMain._am_tp_touch.Length; i++)
				{
					bool is_on = false;
					AppMain.AMS_TP_TOUCH_STATUS ams_TP_TOUCH_STATUS = AppMain._am_tp_touch[i];
					bool flag;
					IntPair move;
					if (AppMain.amTpIsTouchOn(i))
					{
						flag = AppMain.amTpIsTouchPush(i);
						if (flag)
						{
							this.m_pos[i] = new IntPair((int)ams_TP_TOUCH_STATUS.push[0], (int)ams_TP_TOUCH_STATUS.push[1]);
						}
						IntPair intPair = new IntPair((int)ams_TP_TOUCH_STATUS.on[0], (int)ams_TP_TOUCH_STATUS.on[1]);
						if (!this.m_flag[1])
						{
							is_on = this.hitTest(intPair, (uint)i);
						}
						move = intPair - this.m_pos[i];
						this.m_pos[i] = intPair;
					}
					else
					{
						flag = AppMain.amTpIsTouchPull(i);
						move = new IntPair((int)ams_TP_TOUCH_STATUS.pull[0], (int)ams_TP_TOUCH_STATUS.pull[1]) - this.m_pos[i];
						if (flag)
						{
							this.m_pos[i] = default(IntPair);
						}
					}
					T t = this.m_state[i];
					t.Push(is_on, flag, move);
				}
			}
		}

		// Token: 0x060029D8 RID: 10712 RVA: 0x00158DF4 File Offset: 0x00156FF4
		public virtual bool IsValid()
		{
			return false;
		}

		// Token: 0x060029D9 RID: 10713 RVA: 0x00158DF8 File Offset: 0x00156FF8
		public void ResetState()
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].ResetState();
			}
		}

		// Token: 0x060029DA RID: 10714 RVA: 0x00158E31 File Offset: 0x00157031
		public void ResetState(uint index)
		{
			this.m_state[(int)((UIntPtr)index)].ResetState();
		}

		// Token: 0x060029DB RID: 10715 RVA: 0x00158E50 File Offset: 0x00157050
		public void AddLock()
		{
			T state = this.getState();
			state.AddLock();
		}

		// Token: 0x060029DC RID: 10716 RVA: 0x00158E71 File Offset: 0x00157071
		public void AddLock(uint index)
		{
			this.m_state[(int)((UIntPtr)index)].ResetState();
		}

		// Token: 0x060029DD RID: 10717 RVA: 0x00158E90 File Offset: 0x00157090
		public void DelLock()
		{
			T state = this.getState();
			state.DelLock();
		}

		// Token: 0x060029DE RID: 10718 RVA: 0x00158EB4 File Offset: 0x001570B4
		public void DelLock(uint index)
		{
			T state = this.getState(index);
			state.DelLock();
		}

		// Token: 0x060029DF RID: 10719 RVA: 0x00158ED6 File Offset: 0x001570D6
		public bool IsFrieze()
		{
			return this.m_flag[0];
		}

		// Token: 0x060029E0 RID: 10720 RVA: 0x00158EE0 File Offset: 0x001570E0
		public bool IsNoHit()
		{
			return this.m_flag[1];
		}

		// Token: 0x060029E1 RID: 10721 RVA: 0x00158EEA File Offset: 0x001570EA
		public T GetState()
		{
			return this.getState();
		}

		// Token: 0x060029E2 RID: 10722 RVA: 0x00158EF2 File Offset: 0x001570F2
		public T GetState(uint index)
		{
			return this.getState(index);
		}

		// Token: 0x060029E3 RID: 10723 RVA: 0x00158EFC File Offset: 0x001570FC
		public IntPair GetRepeatInterval()
		{
			T state = this.GetState(0U);
			return state.GetRepeatInterval();
		}

		// Token: 0x060029E4 RID: 10724 RVA: 0x00158F20 File Offset: 0x00157120
		public int GetDoubleClickTime()
		{
			T state = this.GetState(0U);
			return state.GetDoubleClickTime();
		}

		// Token: 0x060029E5 RID: 10725 RVA: 0x00158F44 File Offset: 0x00157144
		public int GetMoveThreshold()
		{
			T state = this.GetState(0U);
			return state.GetMoveThreshold();
		}

		// Token: 0x060029E6 RID: 10726 RVA: 0x00158F66 File Offset: 0x00157166
		public void SetFrieze(bool frieze)
		{
			this.m_flag[0] = frieze;
		}

		// Token: 0x060029E7 RID: 10727 RVA: 0x00158F71 File Offset: 0x00157171
		public void SetNoHit(bool nohit)
		{
			this.m_flag[1] = nohit;
		}

		// Token: 0x060029E8 RID: 10728 RVA: 0x00158F7C File Offset: 0x0015717C
		public void SetRepeatInterval(IntPair repeat_interval)
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetRepeatInterval(repeat_interval);
			}
		}

		// Token: 0x060029E9 RID: 10729 RVA: 0x00158FB8 File Offset: 0x001571B8
		public void SetRepeatInterval(int first, int second)
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetRepeatInterval(first, second);
			}
		}

		// Token: 0x060029EA RID: 10730 RVA: 0x00158FF4 File Offset: 0x001571F4
		public void SetRepeatInterval()
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetRepeatInterval();
			}
		}

		// Token: 0x060029EB RID: 10731 RVA: 0x00159030 File Offset: 0x00157230
		public void SetDoubleClickTime(int wc_time)
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetDoubleClickTime(wc_time);
			}
		}

		// Token: 0x060029EC RID: 10732 RVA: 0x0015906C File Offset: 0x0015726C
		public void SetDoubleClickTime()
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetDoubleClickTime();
			}
		}

		// Token: 0x060029ED RID: 10733 RVA: 0x001590A8 File Offset: 0x001572A8
		public void SetMoveThreshold(int move_threshold)
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetMoveThreshold(move_threshold);
			}
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x001590E4 File Offset: 0x001572E4
		public void SetMoveThreshold()
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				this.m_state[i].SetMoveThreshold();
			}
		}

		// Token: 0x060029EF RID: 10735 RVA: 0x0015911D File Offset: 0x0015731D
		protected virtual bool hitTest(IntPair pos, uint index)
		{
			return false;
		}

		// Token: 0x060029F0 RID: 10736 RVA: 0x00159120 File Offset: 0x00157320
		private T getState()
		{
			for (int i = 0; i < this.m_state.Length; i++)
			{
				if (this.m_state[i][14])
				{
					return this.m_state[i];
				}
			}
			for (int j = 0; j < this.m_state.Length; j++)
			{
				if (this.m_state[j][0])
				{
					return this.m_state[j];
				}
			}
			return this.m_state[0];
		}

		// Token: 0x060029F1 RID: 10737 RVA: 0x001591B2 File Offset: 0x001573B2
		private T getState(uint index)
		{
			return this.m_state[(int)((UIntPtr)index)];
		}

		// Token: 0x040063D4 RID: 25556
		private const int c_touch_max = 4;

		// Token: 0x040063D5 RID: 25557
		private bool[] m_flag = new bool[2];

		// Token: 0x040063D6 RID: 25558
		private readonly T[] m_state = AppMain.New<T>(4);

		// Token: 0x040063D7 RID: 25559
		private IntPair[] m_pos = new IntPair[4];

		// Token: 0x02000409 RID: 1033
		private struct BFlag
		{
			// Token: 0x040063D8 RID: 25560
			public const int Frieze = 0;

			// Token: 0x040063D9 RID: 25561
			public const int NoHit = 1;

			// Token: 0x040063DA RID: 25562
			public const int Max = 2;

			// Token: 0x040063DB RID: 25563
			public const int None = 3;
		}
	}
}
