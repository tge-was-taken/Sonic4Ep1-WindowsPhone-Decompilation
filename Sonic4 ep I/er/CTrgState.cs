using System;
using System.Collections;
using accel;

namespace er
{
	// Token: 0x0200041D RID: 1053
	public class CTrgState
	{
		// Token: 0x06002A6A RID: 10858 RVA: 0x0015A3C8 File Offset: 0x001585C8
		public CTrgState()
		{
			this.m_state = new CCircularBuffer<CTrgState.CBitset>(2);
			this.m_counter = -1;
			this.m_repeat_interval = CTrgState.c_repeat_interval_default;
			this.m_wc_time = 6;
			this.m_move_threshold = 2;
			this.m_move_accumulate = default(IntPair);
			this.m_move_report = default(IntPair);
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x0015A420 File Offset: 0x00158620
		public virtual void Push(bool is_on, bool is_edge)
		{
			this.Push(is_on, is_edge, default(IntPair));
		}

		// Token: 0x06002A6C RID: 10860 RVA: 0x0015A43E File Offset: 0x0015863E
		public virtual void Push(bool is_on, bool is_edge, IntPair move)
		{
			this.updateTime();
			this.updateOnPrev(is_on);
			this.updateEdge(is_edge);
			this.updateRepeat();
			this.updateLock();
			this.updateMoveOver(move);
			this.updateClick();
		}

		// Token: 0x170001C3 RID: 451
		public bool this[int kind]
		{
			get
			{
				return this.m_state[0][kind];
			}
		}

		// Token: 0x06002A6E RID: 10862 RVA: 0x0015A481 File Offset: 0x00158681
		public void AddLock()
		{
			this.m_state[0].set(14, true);
		}

		// Token: 0x06002A6F RID: 10863 RVA: 0x0015A498 File Offset: 0x00158698
		public void DelLock()
		{
			this.m_state[0].set(14, false);
		}

		// Token: 0x06002A70 RID: 10864 RVA: 0x0015A4B0 File Offset: 0x001586B0
		public virtual void ResetState()
		{
			for (int i = 0; i < this.m_state.size(); i++)
			{
				this.m_state[i].reset();
			}
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0015A4E4 File Offset: 0x001586E4
		public IntPair GetRepeatInterval()
		{
			return this.m_repeat_interval;
		}

		// Token: 0x06002A72 RID: 10866 RVA: 0x0015A4EC File Offset: 0x001586EC
		public int GetDoubleClickTime()
		{
			return this.m_wc_time;
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x0015A4F4 File Offset: 0x001586F4
		public int GetMoveThreshold()
		{
			return this.m_move_threshold;
		}

		// Token: 0x06002A74 RID: 10868 RVA: 0x0015A4FC File Offset: 0x001586FC
		public IntPair GetMove()
		{
			if (this.m_state[0][9])
			{
				return this.GetLastMove();
			}
			return default(IntPair);
		}

		// Token: 0x06002A75 RID: 10869 RVA: 0x0015A52E File Offset: 0x0015872E
		public IntPair GetLastMove()
		{
			return this.m_move_report;
		}

		// Token: 0x06002A76 RID: 10870 RVA: 0x0015A538 File Offset: 0x00158738
		public IntPair GetOver()
		{
			if (this.m_state[0][12])
			{
				return this.GetLastOver();
			}
			return default(IntPair);
		}

		// Token: 0x06002A77 RID: 10871 RVA: 0x0015A56A File Offset: 0x0015876A
		public IntPair GetLastOver()
		{
			return this.m_move_report;
		}

		// Token: 0x06002A78 RID: 10872 RVA: 0x0015A572 File Offset: 0x00158772
		public void SetRepeatInterval(IntPair repeat_interval)
		{
			this.m_repeat_interval = repeat_interval;
		}

		// Token: 0x06002A79 RID: 10873 RVA: 0x0015A57B File Offset: 0x0015877B
		public void SetRepeatInterval(int first, int second)
		{
			this.m_repeat_interval.first = first;
			this.m_repeat_interval.second = second;
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x0015A595 File Offset: 0x00158795
		public void SetRepeatInterval()
		{
			this.SetRepeatInterval(CTrgState.c_repeat_interval_default);
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x0015A5A2 File Offset: 0x001587A2
		public void SetDoubleClickTime(int wc_time)
		{
			this.m_wc_time = wc_time;
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x0015A5AB File Offset: 0x001587AB
		public void SetDoubleClickTime()
		{
			this.SetDoubleClickTime(6);
		}

		// Token: 0x06002A7D RID: 10877 RVA: 0x0015A5B4 File Offset: 0x001587B4
		public void SetMoveThreshold(int move_threshold)
		{
			this.m_move_threshold = move_threshold;
		}

		// Token: 0x06002A7E RID: 10878 RVA: 0x0015A5BD File Offset: 0x001587BD
		public void SetMoveThreshold()
		{
			this.SetMoveThreshold(2);
		}

		// Token: 0x06002A7F RID: 10879 RVA: 0x0015A5C6 File Offset: 0x001587C6
		private void updateTime()
		{
			if (this.m_counter == 0)
			{
				this.m_counter = -1;
				return;
			}
			if (0 < this.m_counter)
			{
				this.m_counter--;
			}
		}

		// Token: 0x06002A80 RID: 10880 RVA: 0x0015A5F0 File Offset: 0x001587F0
		private void updateOnPrev(bool is_on)
		{
			if (this.m_state.size() == this.m_state.max_size())
			{
				CTrgState.CBitset back = this.m_state.back;
				back.reset();
				this.m_state.pop_back();
				this.m_state.push_front(back);
			}
			else
			{
				this.m_state.push_front();
			}
			CTrgState.CBitset at = this.m_state.getAt(0);
			CTrgState.CBitset at2 = this.m_state.getAt(1);
			if (is_on)
			{
				at.set(0, true);
			}
			if (at2.test(0))
			{
				at.set(1, true);
			}
			if (at2.test(10))
			{
				at.set(16, at2.test(16));
				return;
			}
			for (int i = 0; i < CTrgState.takeover.Length; i++)
			{
				at.set(CTrgState.takeover[i], at2.test(CTrgState.takeover[i]));
			}
		}

		// Token: 0x06002A81 RID: 10881 RVA: 0x0015A6CC File Offset: 0x001588CC
		private void updateEdge(bool is_edge)
		{
			CTrgState.CBitset at = this.m_state.getAt(0);
			if (at.test(0))
			{
				if (this.m_state[1].test(0))
				{
					return;
				}
				at.set(2, true);
				int pos = is_edge ? 8 : 11;
				at.set(pos, true);
				return;
			}
			else
			{
				if (this.m_state[1].test(0))
				{
					at.set(3, true);
					int pos2 = is_edge ? 10 : 13;
					at.set(pos2, true);
					return;
				}
				if (at.test(14) && is_edge)
				{
					at.set(10, true);
				}
				return;
			}
		}

		// Token: 0x06002A82 RID: 10882 RVA: 0x0015A768 File Offset: 0x00158968
		private void updateRepeat()
		{
			CTrgState.CBitset at = this.m_state.getAt(0);
			if (at.test(2))
			{
				at.set(7, true);
				this.m_counter = this.m_repeat_interval.first;
				return;
			}
			if (at.test(3))
			{
				this.m_counter = -1;
				return;
			}
			if (at.test(0) && this.m_counter == 0)
			{
				at.set(7, true);
				this.m_counter = this.m_repeat_interval.second;
			}
		}

		// Token: 0x06002A83 RID: 10883 RVA: 0x0015A7E4 File Offset: 0x001589E4
		private void updateLock()
		{
			CTrgState.CBitset at = this.m_state.getAt(0);
			if (at.test(8))
			{
				at.set(14, true);
			}
			if (this.m_state[1].test(10))
			{
				at.set(14, false);
			}
		}

		// Token: 0x06002A84 RID: 10884 RVA: 0x0015A830 File Offset: 0x00158A30
		private void updateMoveOver(IntPair move)
		{
			CTrgState.CBitset at = this.m_state.getAt(0);
			if (at.test(2))
			{
				at.set(12, true);
				if (at.test(14))
				{
					at.set(9, true);
				}
				if (!this.m_state[1].test(14))
				{
					this.resetMove();
				}
			}
			else if (at.test(0))
			{
				if (this.addMove(move))
				{
					at.set(12, true);
					if (at.test(14))
					{
						at.set(9, true);
						at.set(15, true);
					}
				}
			}
			else if (at.test(14) && this.addMove(move))
			{
				at.set(9, true);
				at.set(15, true);
			}
			if (this.m_state[1].test(10))
			{
				at.set(15, false);
			}
		}

		// Token: 0x06002A85 RID: 10885 RVA: 0x0015A910 File Offset: 0x00158B10
		private void updateClick()
		{
			CTrgState.CBitset at = this.m_state.getAt(0);
			if (at.test(8))
			{
				if (at.test(16))
				{
					at.set(6, true);
					at.set(17, true);
					at.set(16, false);
					this.m_counter = -1;
					return;
				}
			}
			else if (at.test(10))
			{
				if (at.test(14) && at.test(1) && !at.test(17))
				{
					if (0 < this.m_wc_time)
					{
						at.set(4, true);
						at.set(16, true);
						this.m_counter = this.m_wc_time;
						return;
					}
					at.set(4, true);
					at.set(5, true);
					return;
				}
			}
			else if (!at.test(0))
			{
				if (at.test(16) && this.m_counter == 0)
				{
					at.set(5, true);
					at.set(16, false);
				}
				if (this.m_state[1].test(10))
				{
					at.set(17, false);
				}
			}
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x0015AA1E File Offset: 0x00158C1E
		private void resetMove()
		{
			this.m_move_accumulate = default(IntPair);
			this.m_move_report = this.m_move_accumulate;
		}

		// Token: 0x06002A87 RID: 10887 RVA: 0x0015AA38 File Offset: 0x00158C38
		private bool addMove(IntPair move)
		{
			bool flag = false;
			this.m_move_accumulate.first = this.m_move_accumulate.first + move.first;
			this.m_move_accumulate.second = this.m_move_accumulate.second + move.second;
			if (this.m_move_threshold < Math.Abs(this.m_move_accumulate.first) || this.m_move_threshold < Math.Abs(this.m_move_accumulate.second))
			{
				flag = true;
			}
			if (flag)
			{
				this.m_move_report = this.m_move_accumulate;
				this.m_move_accumulate = default(IntPair);
			}
			return flag;
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x0015AAD8 File Offset: 0x00158CD8
		static CTrgState()
		{
			CTrgState.c_repeat_interval_default.first = 15;
			CTrgState.c_repeat_interval_default.second = 6;
		}

		// Token: 0x0400643C RID: 25660
		private const int c_counter_none = -1;

		// Token: 0x0400643D RID: 25661
		private const int c_wc_time_default = 6;

		// Token: 0x0400643E RID: 25662
		private const int c_move_threshold_default = 2;

		// Token: 0x0400643F RID: 25663
		private static int[] takeover = new int[]
		{
			14,
			15,
			16,
			17
		};

		// Token: 0x04006440 RID: 25664
		private static readonly IntPair c_repeat_interval_default;

		// Token: 0x04006441 RID: 25665
		private CCircularBuffer<CTrgState.CBitset> m_state;

		// Token: 0x04006442 RID: 25666
		private int m_counter;

		// Token: 0x04006443 RID: 25667
		private IntPair m_repeat_interval;

		// Token: 0x04006444 RID: 25668
		private int m_wc_time;

		// Token: 0x04006445 RID: 25669
		private int m_move_threshold;

		// Token: 0x04006446 RID: 25670
		private IntPair m_move_accumulate;

		// Token: 0x04006447 RID: 25671
		private IntPair m_move_report;

		// Token: 0x0200041E RID: 1054
		public class EState
		{
			// Token: 0x04006448 RID: 25672
			public const int On = 0;

			// Token: 0x04006449 RID: 25673
			public const int Prev = 1;

			// Token: 0x0400644A RID: 25674
			public const int Stand = 2;

			// Token: 0x0400644B RID: 25675
			public const int Release = 3;

			// Token: 0x0400644C RID: 25676
			public const int Click = 4;

			// Token: 0x0400644D RID: 25677
			public const int SingleClick = 5;

			// Token: 0x0400644E RID: 25678
			public const int DoubleClick = 6;

			// Token: 0x0400644F RID: 25679
			public const int Repeat = 7;

			// Token: 0x04006450 RID: 25680
			public const int Down = 8;

			// Token: 0x04006451 RID: 25681
			public const int Move = 9;

			// Token: 0x04006452 RID: 25682
			public const int Up = 10;

			// Token: 0x04006453 RID: 25683
			public const int In = 11;

			// Token: 0x04006454 RID: 25684
			public const int Over = 12;

			// Token: 0x04006455 RID: 25685
			public const int Out = 13;

			// Token: 0x04006456 RID: 25686
			public const int Lock = 14;

			// Token: 0x04006457 RID: 25687
			public const int DragAndDrop = 15;

			// Token: 0x04006458 RID: 25688
			public const int DoubleClickWait = 16;

			// Token: 0x04006459 RID: 25689
			public const int DoubleClickSecond = 17;

			// Token: 0x0400645A RID: 25690
			public const int Max = 18;

			// Token: 0x0400645B RID: 25691
			public const int None = 19;
		}

		// Token: 0x0200041F RID: 1055
		public class BState : CTrgState.EState
		{
		}

		// Token: 0x02000420 RID: 1056
		public enum ERepeatInterval
		{
			// Token: 0x0400645D RID: 25693
			First,
			// Token: 0x0400645E RID: 25694
			Second,
			// Token: 0x0400645F RID: 25695
			Max,
			// Token: 0x04006460 RID: 25696
			None
		}

		// Token: 0x02000421 RID: 1057
		private struct ETime
		{
			// Token: 0x04006461 RID: 25697
			public const int Direct = 0;

			// Token: 0x04006462 RID: 25698
			public const int Prev = 1;

			// Token: 0x04006463 RID: 25699
			public const int Max = 2;

			// Token: 0x04006464 RID: 25700
			public const int None = 3;
		}

		// Token: 0x02000422 RID: 1058
		public class CBitset
		{
			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x06002A8B RID: 10891 RVA: 0x0015AB17 File Offset: 0x00158D17
			public int Count
			{
				get
				{
					return this.imp.Count;
				}
			}

			// Token: 0x170001C5 RID: 453
			public bool this[int index]
			{
				get
				{
					return this.imp[index];
				}
				set
				{
					this.imp[index] = value;
				}
			}

			// Token: 0x06002A8E RID: 10894 RVA: 0x0015AB41 File Offset: 0x00158D41
			public CTrgState.CBitset set(int pos)
			{
				this.imp.Set(pos, true);
				return this;
			}

			// Token: 0x06002A8F RID: 10895 RVA: 0x0015AB51 File Offset: 0x00158D51
			public CTrgState.CBitset set(int pos, bool value)
			{
				this.imp.Set(pos, value);
				return this;
			}

			// Token: 0x06002A90 RID: 10896 RVA: 0x0015AB61 File Offset: 0x00158D61
			public bool test(int pos)
			{
				return this.imp.Get(pos);
			}

			// Token: 0x06002A91 RID: 10897 RVA: 0x0015AB6F File Offset: 0x00158D6F
			public void reset()
			{
				this.imp.SetAll(false);
			}

			// Token: 0x04006465 RID: 25701
			private BitArray imp = new BitArray(18);
		}
	}
}
