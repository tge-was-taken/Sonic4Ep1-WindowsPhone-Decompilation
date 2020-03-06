using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

public partial class AppMain
{

    // Token: 0x02000338 RID: 824
    // (Invoke) Token: 0x060025B5 RID: 9653
    public delegate void GSF_TASK_PROCEDURE( AppMain.MTS_TASK_TCB task );

    // Token: 0x02000339 RID: 825
    private struct GSS_TASK_SYS
    {
        // Token: 0x04005E6B RID: 24171
        public int pause_level;

        // Token: 0x04005E6C RID: 24172
        public int pause_level_set;
    }

    // Token: 0x0200033A RID: 826
    // (Invoke) Token: 0x060025B9 RID: 9657
    public delegate object TaskWorkFactoryDelegate();

    // Token: 0x0200033B RID: 827
    public struct SCallSlot
    {
        // Token: 0x060025BC RID: 9660 RVA: 0x0014E296 File Offset: 0x0014C496
        public SCallSlot( MethodInfo info, bool bNoCast )
        {
            this.m_info = info;
            this.m_bNoCast = bNoCast;
        }

        // Token: 0x04005E6D RID: 24173
        public MethodInfo m_info;

        // Token: 0x04005E6E RID: 24174
        public bool m_bNoCast;
    }
}
