using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000CFC RID: 3324 RVA: 0x00074950 File Offset: 0x00072B50
    private static void AoAccountInit()
    {
        AppMain.g_ao_account_current_id = -1;
    }

    // Token: 0x06000CFD RID: 3325 RVA: 0x00074958 File Offset: 0x00072B58
    private static void AoAccountDebugInit()
    {
    }

    // Token: 0x06000CFE RID: 3326 RVA: 0x0007495A File Offset: 0x00072B5A
    private static void AoAccountExit()
    {
    }

    // Token: 0x06000CFF RID: 3327 RVA: 0x0007495C File Offset: 0x00072B5C
    private static void AoAccountClearCurrentId()
    {
        AppMain.g_ao_account_current_id = -1;
    }

    // Token: 0x06000D00 RID: 3328 RVA: 0x00074964 File Offset: 0x00072B64
    private static void AoAccountSetCurrentIdStart( uint id )
    {
        AppMain.g_ao_account_current_id = ( int )id;
    }

    // Token: 0x06000D01 RID: 3329 RVA: 0x0007496C File Offset: 0x00072B6C
    private static bool AoAccountSetCurrentIdIsFinished()
    {
        return true;
    }

    // Token: 0x06000D02 RID: 3330 RVA: 0x0007496F File Offset: 0x00072B6F
    private static int AoAccountGetCurrentId()
    {
        return AppMain.g_ao_account_current_id;
    }

    // Token: 0x06000D03 RID: 3331 RVA: 0x00074976 File Offset: 0x00072B76
    private static bool AoAccountIsCurrentSignin()
    {
        return AppMain.AoAccountGetCurrentId() >= 0;
    }

    // Token: 0x06000D04 RID: 3332 RVA: 0x00074983 File Offset: 0x00072B83
    private static bool AoAccountIsCurrentOnline()
    {
        return XBOXLive.signinStatus == XBOXLive.SigninStatus.LIVE;
    }

    // Token: 0x06000D05 RID: 3333 RVA: 0x0007498D File Offset: 0x00072B8D
    private static bool AoAccountIsCurrentEnable()
    {
        return AppMain.g_ao_account_current_id < 4;
    }
}
