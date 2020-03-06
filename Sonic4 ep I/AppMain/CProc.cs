using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000119 RID: 281
    public class CProc
    {
        // Token: 0x06001FF6 RID: 8182 RVA: 0x0013D7C0 File Offset: 0x0013B9C0
        public void operator_brackets()
        {
            if ( this.m_it != null && !this.IsNoneProc() )
            {
                this.m_proc();
            }
        }

        // Token: 0x06001FF7 RID: 8183 RVA: 0x0013D7DD File Offset: 0x0013B9DD
        public bool IsNoneProc()
        {
            return this.m_proc == null;
        }

        // Token: 0x06001FF8 RID: 8184 RVA: 0x0013D7E8 File Offset: 0x0013B9E8
        public bool IsProc( AppMain.ITaskAsv.FProc proc )
        {
            return this.m_proc == proc;
        }

        // Token: 0x06001FF9 RID: 8185 RVA: 0x0013D7F6 File Offset: 0x0013B9F6
        public bool IsProc()
        {
            return this.IsNoneProc();
        }

        // Token: 0x06001FFA RID: 8186 RVA: 0x0013D7FE File Offset: 0x0013B9FE
        public AppMain.ITaskAsv.FProc GetProc()
        {
            return this.m_proc;
        }

        // Token: 0x06001FFB RID: 8187 RVA: 0x0013D806 File Offset: 0x0013BA06
        public void SetTarget( object it )
        {
            this.m_it = it;
            this.SetProc();
        }

        // Token: 0x06001FFC RID: 8188 RVA: 0x0013D815 File Offset: 0x0013BA15
        public void SetTarget()
        {
            this.m_it = null;
            this.SetProc();
        }

        // Token: 0x06001FFD RID: 8189 RVA: 0x0013D824 File Offset: 0x0013BA24
        public void SetProc( AppMain.ITaskAsv.FProc proc )
        {
            this.m_proc = proc;
        }

        // Token: 0x06001FFE RID: 8190 RVA: 0x0013D82D File Offset: 0x0013BA2D
        public void SetProc()
        {
            this.m_proc = null;
        }

        // Token: 0x06001FFF RID: 8191 RVA: 0x0013D836 File Offset: 0x0013BA36
        public CProc()
        {
            this.m_it = null;
            this.m_proc = null;
        }

        // Token: 0x06002000 RID: 8192 RVA: 0x0013D84C File Offset: 0x0013BA4C
        public CProc( object it )
        {
            this.m_it = it;
            this.m_proc = null;
        }

        // Token: 0x04004C96 RID: 19606
        private AppMain.ITaskAsv.FProc m_proc;

        // Token: 0x04004C97 RID: 19607
        private object m_it;
    }

    // Token: 0x02000121 RID: 289
    public class CProc<TCrtpType> where TCrtpType : class, AppMain.IFunctor
    {
        // Token: 0x06002028 RID: 8232 RVA: 0x0013DB39 File Offset: 0x0013BD39
        public virtual void operator_brackets()
        {
            if ( this.m_it != null && !this.IsNoneProc() )
            {
                this.m_proc();
            }
        }

        // Token: 0x06002029 RID: 8233 RVA: 0x0013DB5B File Offset: 0x0013BD5B
        public bool IsNoneProc()
        {
            return this.m_proc == null;
        }

        // Token: 0x0600202A RID: 8234 RVA: 0x0013DB68 File Offset: 0x0013BD68
        public bool IsProc( AppMain.CProc<TCrtpType>.FProc proc )
        {
            return this.m_proc == proc;
        }

        // Token: 0x0600202B RID: 8235 RVA: 0x0013DB7B File Offset: 0x0013BD7B
        public bool IsProc()
        {
            return this.IsNoneProc();
        }

        // Token: 0x0600202C RID: 8236 RVA: 0x0013DB83 File Offset: 0x0013BD83
        public AppMain.CProc<TCrtpType>.FProc GetProc()
        {
            return this.m_proc;
        }

        // Token: 0x0600202D RID: 8237 RVA: 0x0013DB8B File Offset: 0x0013BD8B
        public void SetTarget( TCrtpType it )
        {
            this.m_it = it;
            this.SetProc();
        }

        // Token: 0x0600202E RID: 8238 RVA: 0x0013DB9A File Offset: 0x0013BD9A
        public void SetTarget()
        {
            this.m_it = default( TCrtpType );
            this.SetProc();
        }

        // Token: 0x0600202F RID: 8239 RVA: 0x0013DBAE File Offset: 0x0013BDAE
        public void SetProc( AppMain.CProc<TCrtpType>.FProc proc )
        {
            this.m_proc = proc;
        }

        // Token: 0x06002030 RID: 8240 RVA: 0x0013DBB7 File Offset: 0x0013BDB7
        public void SetProc()
        {
            this.m_proc = null;
        }

        // Token: 0x06002031 RID: 8241 RVA: 0x0013DBC0 File Offset: 0x0013BDC0
        public CProc()
        {
            this.m_it = default( TCrtpType );
            this.m_proc = null;
        }

        // Token: 0x06002032 RID: 8242 RVA: 0x0013DBDB File Offset: 0x0013BDDB
        public CProc( TCrtpType it )
        {
            this.m_it = it;
            this.m_proc = null;
        }

        // Token: 0x06002033 RID: 8243 RVA: 0x0013DBF4 File Offset: 0x0013BDF4
        ~CProc()
        {
        }

        // Token: 0x04004CA7 RID: 19623
        private AppMain.CProc<TCrtpType>.FProc m_proc;

        // Token: 0x04004CA8 RID: 19624
        private TCrtpType m_it;

        // Token: 0x02000122 RID: 290
        // (Invoke) Token: 0x06002035 RID: 8245
        public delegate void FProc();
    }

}
