using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000111 RID: 273 RVA: 0x0000B44B File Offset: 0x0000964B
    public static void GsTrialInitStart()
    {
    }

    // Token: 0x06000112 RID: 274 RVA: 0x0000B44D File Offset: 0x0000964D
    public static bool GsTrialInitIsFinished()
    {
        return true;
    }

    // Token: 0x06000113 RID: 275 RVA: 0x0000B450 File Offset: 0x00009650
    public static void GsTrialExit()
    {
    }

    // Token: 0x06000114 RID: 276 RVA: 0x0000B452 File Offset: 0x00009652
    public static bool GsTrialIsTrial()
    {
        return XBOXLive.isTrial();
    }

    // Token: 0x06000115 RID: 277 RVA: 0x0000B459 File Offset: 0x00009659
    public static void GsTrialCheckStart()
    {
    }

    // Token: 0x06000116 RID: 278 RVA: 0x0000B45B File Offset: 0x0000965B
    public static bool GsTrialCheckIsFinished()
    {
        return true;
    }

    // Token: 0x06000117 RID: 279 RVA: 0x0000B45E File Offset: 0x0000965E
    public static void GsTrialStoreStart()
    {
    }

    // Token: 0x06000118 RID: 280 RVA: 0x0000B460 File Offset: 0x00009660
    public static bool GsTrialStoreIsFinished()
    {
        return true;
    }

    // Token: 0x06000119 RID: 281 RVA: 0x0000B463 File Offset: 0x00009663
    public static void GsTrialDebugSetTrial( bool is_trial )
    {
    }
}
