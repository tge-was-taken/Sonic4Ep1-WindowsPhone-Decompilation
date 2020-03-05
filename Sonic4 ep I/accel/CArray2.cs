using System;

namespace accel
{
	// Token: 0x02000405 RID: 1029
	public struct CArray2<T> where T : struct
	{
		// Token: 0x1700016B RID: 363
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
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06002971 RID: 10609 RVA: 0x0015841C File Offset: 0x0015661C
		// (set) Token: 0x06002972 RID: 10610 RVA: 0x00158424 File Offset: 0x00156624
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

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06002973 RID: 10611 RVA: 0x0015842D File Offset: 0x0015662D
		// (set) Token: 0x06002974 RID: 10612 RVA: 0x00158435 File Offset: 0x00156635
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

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06002975 RID: 10613 RVA: 0x0015843E File Offset: 0x0015663E
		// (set) Token: 0x06002976 RID: 10614 RVA: 0x00158446 File Offset: 0x00156646
		public T u
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

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06002977 RID: 10615 RVA: 0x0015844F File Offset: 0x0015664F
		// (set) Token: 0x06002978 RID: 10616 RVA: 0x00158457 File Offset: 0x00156657
		public T v
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

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06002979 RID: 10617 RVA: 0x00158460 File Offset: 0x00156660
		// (set) Token: 0x0600297A RID: 10618 RVA: 0x00158468 File Offset: 0x00156668
		public T s
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

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600297B RID: 10619 RVA: 0x00158471 File Offset: 0x00156671
		// (set) Token: 0x0600297C RID: 10620 RVA: 0x00158479 File Offset: 0x00156679
		public T t
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

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600297D RID: 10621 RVA: 0x00158482 File Offset: 0x00156682
		// (set) Token: 0x0600297E RID: 10622 RVA: 0x0015848A File Offset: 0x0015668A
		public T width
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

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600297F RID: 10623 RVA: 0x00158493 File Offset: 0x00156693
		// (set) Token: 0x06002980 RID: 10624 RVA: 0x0015849B File Offset: 0x0015669B
		public T height
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

		// Token: 0x06002981 RID: 10625 RVA: 0x001584A4 File Offset: 0x001566A4
		public int size()
		{
			return 2;
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x001584A8 File Offset: 0x001566A8
		public static CArray2<T> initializer()
		{
			return CArray2<T>.initializer(default(T));
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x001584C4 File Offset: 0x001566C4
		public static CArray2<T> initializer(T value)
		{
			CArray2<T> result;
			result.v0 = value;
			result.v1 = value;
			return result;
		}

		// Token: 0x06002984 RID: 10628 RVA: 0x001584E4 File Offset: 0x001566E4
		public static CArray2<T> initializer(T v0, T v1)
		{
			CArray2<T> result;
			result.v0 = v0;
			result.v1 = v1;
			return result;
		}

		// Token: 0x06002985 RID: 10629 RVA: 0x00158502 File Offset: 0x00156702
		public bool equals(CArray2<T> a2)
		{
			return this.v0.Equals(a2.v0) && this.v1.Equals(a2.v1);
		}

		// Token: 0x040063CD RID: 25549
		private T v0;

		// Token: 0x040063CE RID: 25550
		private T v1;
	}
}
