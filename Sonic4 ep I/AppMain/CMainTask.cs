using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000125 RID: 293
    public class CMainTask<TCrtpType> : AppMain.CProcCount<AppMain.CMain>, AppMain.IFunctor
    {
        // Token: 0x06002041 RID: 8257 RVA: 0x0013DCA0 File Offset: 0x0013BEA0
        public CMainTask()
        {
            base.SetTarget( this as AppMain.CMain );
            this.m_pTaskLink = new AppMain.ITaskLink( this );
        }

        // Token: 0x06002042 RID: 8258 RVA: 0x0013DCD0 File Offset: 0x0013BED0
        ~CMainTask()
        {
        }

        // Token: 0x06002043 RID: 8259 RVA: 0x0013DCF8 File Offset: 0x0013BEF8
        public override void operator_brackets()
        {
            base.operator_brackets();
        }

        // Token: 0x04004CAA RID: 19626
        public AppMain.ITaskLink m_pTaskLink;
    }
}