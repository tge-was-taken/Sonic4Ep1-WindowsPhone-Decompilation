using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0600000A RID: 10 RVA: 0x000020B4 File Offset: 0x000002B4
    private static void GsRebootInit()
    {
        AppMain.amSystemLog( "gsReboot Initializing...\n" );
        AppMain.amSystemLog( "gsReboot Initialized.\n" );
    }

    // Token: 0x0600000B RID: 11 RVA: 0x000020CA File Offset: 0x000002CA
    private static void GsRebootExit()
    {
    }

    // Token: 0x0600000C RID: 12 RVA: 0x000020CC File Offset: 0x000002CC
    private static bool GsRebootIsReboot()
    {
        return false;
    }

    // Token: 0x0600000D RID: 13 RVA: 0x000020CF File Offset: 0x000002CF
    private static bool GsRebootIsTitleReboot()
    {
        return false;
    }

    // Token: 0x0600000E RID: 14 RVA: 0x000020D2 File Offset: 0x000002D2
    private static void GsRebootSetTitle()
    {
    }

    // Token: 0x0600000F RID: 15 RVA: 0x000020D4 File Offset: 0x000002D4
    private static bool GsRebootIsTitle()
    {
        return false;
    }
}