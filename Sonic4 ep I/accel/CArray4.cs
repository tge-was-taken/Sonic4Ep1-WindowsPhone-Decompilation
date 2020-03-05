using System;

namespace accel
{
	// Token: 0x02000404 RID: 1028
	public struct CArray4<T> where T : struct
	{
		// Token: 0x1700015E RID: 350
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
				case 3:
					return this.v3;
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
				case 3:
					this.v3 = value;
					return;
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06002951 RID: 10577 RVA: 0x00158220 File Offset: 0x00156420
		// (set) Token: 0x06002952 RID: 10578 RVA: 0x00158228 File Offset: 0x00156428
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

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06002953 RID: 10579 RVA: 0x00158231 File Offset: 0x00156431
		// (set) Token: 0x06002954 RID: 10580 RVA: 0x00158239 File Offset: 0x00156439
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

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06002955 RID: 10581 RVA: 0x00158242 File Offset: 0x00156442
		// (set) Token: 0x06002956 RID: 10582 RVA: 0x0015824A File Offset: 0x0015644A
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

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06002957 RID: 10583 RVA: 0x00158253 File Offset: 0x00156453
		// (set) Token: 0x06002958 RID: 10584 RVA: 0x0015825B File Offset: 0x0015645B
		public T w
		{
			get
			{
				return this.v3;
			}
			set
			{
				this.v3 = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06002959 RID: 10585 RVA: 0x00158264 File Offset: 0x00156464
		// (set) Token: 0x0600295A RID: 10586 RVA: 0x0015826C File Offset: 0x0015646C
		public T r
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

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600295B RID: 10587 RVA: 0x00158275 File Offset: 0x00156475
		// (set) Token: 0x0600295C RID: 10588 RVA: 0x0015827D File Offset: 0x0015647D
		public T g
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

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600295D RID: 10589 RVA: 0x00158286 File Offset: 0x00156486
		// (set) Token: 0x0600295E RID: 10590 RVA: 0x0015828E File Offset: 0x0015648E
		public T b
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

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600295F RID: 10591 RVA: 0x00158297 File Offset: 0x00156497
		// (set) Token: 0x06002960 RID: 10592 RVA: 0x0015829F File Offset: 0x0015649F
		public T a
		{
			get
			{
				return this.v3;
			}
			set
			{
				this.v3 = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06002961 RID: 10593 RVA: 0x001582A8 File Offset: 0x001564A8
		// (set) Token: 0x06002962 RID: 10594 RVA: 0x001582B0 File Offset: 0x001564B0
		public T left
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

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06002963 RID: 10595 RVA: 0x001582B9 File Offset: 0x001564B9
		// (set) Token: 0x06002964 RID: 10596 RVA: 0x001582C1 File Offset: 0x001564C1
		public T top
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

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06002965 RID: 10597 RVA: 0x001582CA File Offset: 0x001564CA
		// (set) Token: 0x06002966 RID: 10598 RVA: 0x001582D2 File Offset: 0x001564D2
		public T right
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

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06002967 RID: 10599 RVA: 0x001582DB File Offset: 0x001564DB
		// (set) Token: 0x06002968 RID: 10600 RVA: 0x001582E3 File Offset: 0x001564E3
		public T bottom
		{
			get
			{
				return this.v3;
			}
			set
			{
				this.v3 = value;
			}
		}

		// Token: 0x06002969 RID: 10601 RVA: 0x001582EC File Offset: 0x001564EC
		public int size()
		{
			return 4;
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x001582F0 File Offset: 0x001564F0
		public static CArray4<T> initializer()
		{
			return CArray4<T>.initializer(default(T));
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x0015830C File Offset: 0x0015650C
		public static CArray4<T> initializer(T value)
		{
			CArray4<T> result;
			result.v0 = value;
			result.v1 = value;
			result.v2 = value;
			result.v3 = value;
			return result;
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x0015833C File Offset: 0x0015653C
		public static CArray4<T> initializer(T v0, T v1, T v2, T v3)
		{
			CArray4<T> result;
			result.v0 = v0;
			result.v1 = v1;
			result.v2 = v2;
			result.v3 = v3;
			return result;
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x0015836C File Offset: 0x0015656C
		public static CArray4<T> initializer(T v0, T v1, T v2)
		{
			return CArray4<T>.initializer(v0, v1, v2, default(T));
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x0015838C File Offset: 0x0015658C
		public static CArray4<T> initializer(T v0, T v1)
		{
			return CArray4<T>.initializer(v0, v1, default(T), default(T));
		}

		// Token: 0x040063C9 RID: 25545
		private T v0;

		// Token: 0x040063CA RID: 25546
		private T v1;

		// Token: 0x040063CB RID: 25547
		private T v2;

		// Token: 0x040063CC RID: 25548
		private T v3;
	}
}
