using System;

namespace er
{
	// Token: 0x0200041C RID: 1052
	public struct IntPair
	{
		// Token: 0x06002A67 RID: 10855 RVA: 0x0015A36C File Offset: 0x0015856C
		public IntPair(int _first, int _second)
		{
			this.first = _first;
			this.second = _second;
		}

		// Token: 0x06002A68 RID: 10856 RVA: 0x0015A37C File Offset: 0x0015857C
		public static IntPair operator -(IntPair lhs, IntPair rhs)
		{
			return new IntPair(lhs.first - rhs.first, lhs.second - rhs.second);
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0015A3A1 File Offset: 0x001585A1
		public static IntPair operator +(IntPair lhs, IntPair rhs)
		{
			return new IntPair(lhs.first + rhs.first, lhs.second + rhs.second);
		}

		// Token: 0x0400643A RID: 25658
		public int first;

		// Token: 0x0400643B RID: 25659
		public int second;
	}
}
