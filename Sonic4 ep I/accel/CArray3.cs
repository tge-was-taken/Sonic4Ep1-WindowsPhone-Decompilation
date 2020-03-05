using System;

namespace accel
{
	// Token: 0x02000406 RID: 1030
	public struct CArray3<T> where T : struct
	{
		// Token: 0x17000174 RID: 372
		public T this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.v0;
				case 1:
					return this.v1;
				case 2:
					return this.v2;
				default:
					throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.v0 = value;
					return;
				case 1:
					this.v1 = value;
					return;
				case 2:
					this.v2 = value;
					return;
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06002988 RID: 10632 RVA: 0x001585C4 File Offset: 0x001567C4
		// (set) Token: 0x06002989 RID: 10633 RVA: 0x001585CC File Offset: 0x001567CC
		public T x
		{
			get
			{
				return this.v0;
			}
			set
			{
				this.v0 = value;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600298A RID: 10634 RVA: 0x001585D5 File Offset: 0x001567D5
		// (set) Token: 0x0600298B RID: 10635 RVA: 0x001585DD File Offset: 0x001567DD
		public T y
		{
			get
			{
				return this.v1;
			}
			set
			{
				this.v1 = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600298C RID: 10636 RVA: 0x001585E6 File Offset: 0x001567E6
		// (set) Token: 0x0600298D RID: 10637 RVA: 0x001585EE File Offset: 0x001567EE
		public T z
		{
			get
			{
				return this.v2;
			}
			set
			{
				this.v2 = value;
			}
		}

		// Token: 0x0600298E RID: 10638 RVA: 0x001585F7 File Offset: 0x001567F7
		public int size()
		{
			return 3;
		}

		// Token: 0x0600298F RID: 10639 RVA: 0x001585FC File Offset: 0x001567FC
		public static CArray3<T> initializer()
		{
			return CArray3<T>.initializer(default(T));
		}

		// Token: 0x06002990 RID: 10640 RVA: 0x00158618 File Offset: 0x00156818
		public static CArray3<T> initializer(T value)
		{
			CArray3<T> result;
			result.v0 = value;
			result.v1 = value;
			result.v2 = value;
			return result;
		}

		// Token: 0x06002991 RID: 10641 RVA: 0x00158640 File Offset: 0x00156840
		public static CArray3<T> initializer(T v0, T v1, T v2)
		{
			CArray3<T> result;
			result.v0 = v0;
			result.v1 = v1;
			result.v2 = v2;
			return result;
		}

		// Token: 0x06002992 RID: 10642 RVA: 0x00158668 File Offset: 0x00156868
		internal bool equals(CArray3<T> a2)
		{
			return this.v0.Equals(a2.v0) && this.v1.Equals(a2.v1) && this.v2.Equals(a2.v2);
		}

		// Token: 0x040063CF RID: 25551
		private T v0;

		// Token: 0x040063D0 RID: 25552
		private T v1;

		// Token: 0x040063D1 RID: 25553
		private T v2;
	}
}
