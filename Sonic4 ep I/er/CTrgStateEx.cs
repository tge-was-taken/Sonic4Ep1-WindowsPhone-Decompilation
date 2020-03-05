using System;
using accel;

namespace er
{
	// Token: 0x02000423 RID: 1059
	public class CTrgStateEx : CTrgState
	{
		// Token: 0x06002A93 RID: 10899 RVA: 0x0015AB92 File Offset: 0x00158D92
		public override void Push(bool is_on, bool is_edge, IntPair move)
		{
			base.Push(is_on, is_edge, move);
			if (is_on || is_edge)
			{
				this.m_pos_history.push_front(move);
				return;
			}
			this.m_pos_history.push_front(new IntPair(0, 0));
		}

		// Token: 0x06002A94 RID: 10900 RVA: 0x0015ABC2 File Offset: 0x00158DC2
		public override void ResetState()
		{
			base.ResetState();
			this.m_pos_history.clear();
		}

		// Token: 0x06002A95 RID: 10901 RVA: 0x0015ABD8 File Offset: 0x00158DD8
		public CArray2<float> GetDragSpeed()
		{
			IntPair intPair = new IntPair(0, 0);
			for (int i = 0; i < this.m_pos_history.size(); i++)
			{
				IntPair at = this.m_pos_history.getAt(i);
				intPair.first += at.first;
				intPair.second += at.second;
			}
			float num = 1f / (float)this.m_pos_history.max_size();
			return new CArray2<float>
			{
				x = (float)intPair.first * num,
				y = (float)intPair.second * num
			};
		}

		// Token: 0x04006466 RID: 25702
		public const int c_pos_history = 6;

		// Token: 0x04006467 RID: 25703
		public readonly CCircularBuffer<IntPair> m_pos_history = new CCircularBuffer<IntPair>(6);
	}
}
