using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200011A RID: 282
    public class CProcCount : AppMain.CProc
    {
        // Token: 0x06002001 RID: 8193 RVA: 0x0013D862 File Offset: 0x0013BA62
        public new void operator_brackets()
        {
            this.m_counter += 1U;
            base.operator_brackets();
        }

        // Token: 0x06002002 RID: 8194 RVA: 0x0013D878 File Offset: 0x0013BA78
        public uint GetCount()
        {
            return this.m_counter;
        }

        // Token: 0x06002003 RID: 8195 RVA: 0x0013D880 File Offset: 0x0013BA80
        public new void SetProc( AppMain.ITaskAsv.FProc proc )
        {
            this.ResetCounter();
            base.SetProc( proc );
        }

        // Token: 0x06002004 RID: 8196 RVA: 0x0013D88F File Offset: 0x0013BA8F
        public new void SetProc()
        {
            this.ResetCounter();
            base.SetProc();
        }

        // Token: 0x06002005 RID: 8197 RVA: 0x0013D89D File Offset: 0x0013BA9D
        public CProcCount()
        {
            this.ResetCounter();
        }

        // Token: 0x06002006 RID: 8198 RVA: 0x0013D8AB File Offset: 0x0013BAAB
        public CProcCount( object it ) : base( it )
        {
            this.ResetCounter();
        }

        // Token: 0x06002007 RID: 8199 RVA: 0x0013D8BA File Offset: 0x0013BABA
        protected void ResetCounter()
        {
            this.m_counter = uint.MaxValue;
        }

        // Token: 0x04004C98 RID: 19608
        private uint m_counter;
    }

    // Token: 0x02000123 RID: 291
    public class CProcCount<TCrtpType> : AppMain.CProc<TCrtpType> where TCrtpType : class, AppMain.IFunctor
    {
        // Token: 0x06002038 RID: 8248 RVA: 0x0013DC1C File Offset: 0x0013BE1C
        public override void operator_brackets()
        {
            this.m_counter += 1UL;
            base.operator_brackets();
        }

        // Token: 0x06002039 RID: 8249 RVA: 0x0013DC33 File Offset: 0x0013BE33
        public ulong GetCount()
        {
            return this.m_counter;
        }

        // Token: 0x0600203A RID: 8250 RVA: 0x0013DC3B File Offset: 0x0013BE3B
        public new void SetProc( AppMain.CProc<TCrtpType>.FProc proc )
        {
            this.ResetCounter();
            base.SetProc( proc );
        }

        // Token: 0x0600203B RID: 8251 RVA: 0x0013DC4A File Offset: 0x0013BE4A
        public new void SetProc()
        {
            this.ResetCounter();
            base.SetProc();
        }

        // Token: 0x0600203C RID: 8252 RVA: 0x0013DC58 File Offset: 0x0013BE58
        public CProcCount()
        {
        }

        // Token: 0x0600203D RID: 8253 RVA: 0x0013DC60 File Offset: 0x0013BE60
        public CProcCount( TCrtpType it ) : base( it )
        {
        }

        // Token: 0x0600203E RID: 8254 RVA: 0x0013DC6C File Offset: 0x0013BE6C
        ~CProcCount()
        {
        }

        // Token: 0x0600203F RID: 8255 RVA: 0x0013DC94 File Offset: 0x0013BE94
        protected void ResetCounter()
        {
            this.m_counter = ulong.MaxValue;
        }

        // Token: 0x04004CA9 RID: 19625
        private ulong m_counter;
    }
}
