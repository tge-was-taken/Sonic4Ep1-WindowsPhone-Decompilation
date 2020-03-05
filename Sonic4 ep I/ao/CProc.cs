using System;

namespace ao
{
	// Token: 0x02000435 RID: 1077
	public class CProc<T>
	{
		// Token: 0x06002AEA RID: 10986 RVA: 0x0015BB87 File Offset: 0x00159D87
		public CProc()
		{
			this.SetOwnProcNone();
			this.m_counter = 0U;
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x0015BB9C File Offset: 0x00159D9C
		public void SetOwnProcNone()
		{
			this.SetOwnProc(null);
		}

		// Token: 0x06002AEC RID: 10988 RVA: 0x0015BBA5 File Offset: 0x00159DA5
		public void SetProcNone(uint no)
		{
			this.SetProc(no, null);
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x0015BBAF File Offset: 0x00159DAF
		public void SetOwnProc()
		{
			this.SetOwnProc(null);
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x0015BBB8 File Offset: 0x00159DB8
		public void SetProc(uint no)
		{
			this.SetProc(no, null);
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x0015BBC2 File Offset: 0x00159DC2
		public void SetOwnProc(CProc<T>.TypeProcedure proc)
		{
			this.m_proc = proc;
			this.m_counter_next = 0U;
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x0015BBD2 File Offset: 0x00159DD2
		public void SetProc(uint no, CProc<T>.TypeProcedure proc)
		{
			this.SetOwnProc(proc);
		}

		// Token: 0x06002AF1 RID: 10993 RVA: 0x0015BBDB File Offset: 0x00159DDB
		public CProc<T>.TypeProcedure GetOwnProc()
		{
			return this.m_proc;
		}

		// Token: 0x06002AF2 RID: 10994 RVA: 0x0015BBE3 File Offset: 0x00159DE3
		public CProc<T>.TypeProcedure GetProc(uint no)
		{
			return this.GetOwnProc();
		}

		// Token: 0x06002AF3 RID: 10995 RVA: 0x0015BBEB File Offset: 0x00159DEB
		public bool IsOwnProcNone()
		{
			return this.m_proc == null;
		}

		// Token: 0x06002AF4 RID: 10996 RVA: 0x0015BBF8 File Offset: 0x00159DF8
		public bool IsProcNone(uint no)
		{
			return this.IsOwnProcNone();
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x0015BC00 File Offset: 0x00159E00
		public bool IsOwnProc(CProc<T>.TypeProcedure proc)
		{
			return proc == this.m_proc;
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x0015BC13 File Offset: 0x00159E13
		public bool IsProc(uint no, CProc<T>.TypeProcedure proc)
		{
			return this.IsOwnProc(proc);
		}

		// Token: 0x06002AF7 RID: 10999 RVA: 0x0015BC1C File Offset: 0x00159E1C
		public uint GetCount()
		{
			return this.m_counter;
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x0015BC24 File Offset: 0x00159E24
		public void ResetCount()
		{
			this.m_counter_next = 0U;
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x0015BC2D File Offset: 0x00159E2D
		public void operator_brackets()
		{
			this.m_counter = this.m_counter_next;
			if (this.m_counter_next < 4294967295U)
			{
				this.m_counter_next += 1U;
			}
			if (this.m_proc != null)
			{
				this.m_proc();
			}
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x0015BC65 File Offset: 0x00159E65
		public void operator_brackets(uint no)
		{
			this.operator_brackets();
		}

		// Token: 0x06002AFB RID: 11003 RVA: 0x0015BC6D File Offset: 0x00159E6D
		public void Call()
		{
			this.operator_brackets();
		}

		// Token: 0x06002AFC RID: 11004 RVA: 0x0015BC75 File Offset: 0x00159E75
		public void Call(uint no)
		{
			this.operator_brackets(no);
		}

		// Token: 0x040064AE RID: 25774
		private CProc<T>.TypeProcedure m_proc;

		// Token: 0x040064AF RID: 25775
		private uint m_counter;

		// Token: 0x040064B0 RID: 25776
		private uint m_counter_next;

		// Token: 0x02000436 RID: 1078
		// (Invoke) Token: 0x06002AFE RID: 11006
		public delegate void TypeProcedure();
	}
}
