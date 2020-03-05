using System;

namespace accel
{
	// Token: 0x02000403 RID: 1027
	public class CCircularBuffer<T> where T : new()
	{
		// Token: 0x0600293B RID: 10555 RVA: 0x00157EF8 File Offset: 0x001560F8
		public CCircularBuffer(int size)
		{
			this.static_size = size;
			this.m_data = new T[size];
			if (!typeof(T).IsValueType)
			{
				for (int i = 0; i < size; i++)
				{
					this.m_data[i] = ((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
				}
			}
			this.m_begin = 0;
			this.m_size = 0;
		}

		// Token: 0x1700015B RID: 347
		public T this[int index]
		{
			get
			{
				return this.getAt(index);
			}
			set
			{
				this.setAt(index, value);
			}
		}

		// Token: 0x0600293E RID: 10558 RVA: 0x00157F88 File Offset: 0x00156188
		public T getAt(int index)
		{
			return this.m_data[this.indexAt(index)];
		}

		// Token: 0x0600293F RID: 10559 RVA: 0x00157F9C File Offset: 0x0015619C
		public void setAt(int index, T value)
		{
			this.m_data[this.indexAt(index)] = value;
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06002940 RID: 10560 RVA: 0x00157FB1 File Offset: 0x001561B1
		// (set) Token: 0x06002941 RID: 10561 RVA: 0x00157FBA File Offset: 0x001561BA
		public T front
		{
			get
			{
				return this.getAt(0);
			}
			set
			{
				this.setAt(0, value);
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06002942 RID: 10562 RVA: 0x00157FC4 File Offset: 0x001561C4
		// (set) Token: 0x06002943 RID: 10563 RVA: 0x00157FD4 File Offset: 0x001561D4
		public T back
		{
			get
			{
				return this.getAt(this.m_size - 1);
			}
			set
			{
				this.setAt(this.m_size - 1, value);
			}
		}

		// Token: 0x06002944 RID: 10564 RVA: 0x00157FE8 File Offset: 0x001561E8
		public void push_back(T value)
		{
			if (this.m_size < this.static_size)
			{
				this.m_size++;
			}
			else
			{
				this.m_begin++;
				if (this.static_size <= this.m_begin)
				{
					this.m_begin = 0;
				}
			}
			this.back = value;
		}

		// Token: 0x06002945 RID: 10565 RVA: 0x00158040 File Offset: 0x00156240
		public void push_front()
		{
			this.push_front((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
		}

		// Token: 0x06002946 RID: 10566 RVA: 0x00158074 File Offset: 0x00156274
		public void push_front(T value)
		{
			if (this.m_size < this.static_size)
			{
				this.m_size++;
			}
			if (0 < this.m_begin)
			{
				this.m_begin--;
			}
			else
			{
				this.m_begin = this.static_size - 1;
			}
			this.front = value;
		}

		// Token: 0x06002947 RID: 10567 RVA: 0x001580CB File Offset: 0x001562CB
		public void pop_back()
		{
			if (0 < this.m_size)
			{
				this.m_size--;
			}
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x001580E4 File Offset: 0x001562E4
		public void pop_front()
		{
			if (0 < this.m_size)
			{
				this.m_size--;
				this.m_begin++;
				if (this.static_size <= this.m_begin)
				{
					this.m_begin = 0;
				}
			}
		}

		// Token: 0x06002949 RID: 10569 RVA: 0x00158120 File Offset: 0x00156320
		public int size()
		{
			return this.m_size;
		}

		// Token: 0x0600294A RID: 10570 RVA: 0x00158128 File Offset: 0x00156328
		public int max_size()
		{
			return this.static_size;
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x00158130 File Offset: 0x00156330
		public void clear()
		{
			this.m_size = 0;
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x00158139 File Offset: 0x00156339
		public bool empty()
		{
			return this.m_size == 0;
		}

		// Token: 0x0600294D RID: 10573 RVA: 0x00158146 File Offset: 0x00156346
		public bool full()
		{
			return this.static_size == this.m_size;
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x00158159 File Offset: 0x00156359
		private int indexAt(int index)
		{
			if (this.static_size <= index)
			{
				index %= this.static_size;
			}
			index += this.m_begin;
			if (this.static_size <= index)
			{
				index -= this.static_size;
			}
			return index;
		}

		// Token: 0x040063C5 RID: 25541
		private readonly T[] m_data;

		// Token: 0x040063C6 RID: 25542
		private int m_begin;

		// Token: 0x040063C7 RID: 25543
		private int m_size;

		// Token: 0x040063C8 RID: 25544
		private int static_size;
	}
}
