using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000EFD RID: 3837 RVA: 0x000842C9 File Offset: 0x000824C9
    private static void GsFontInit()
    {
    }

    // Token: 0x06000EFE RID: 3838 RVA: 0x000842CB File Offset: 0x000824CB
    private static void GsFontExit()
    {
    }

    // Token: 0x06000EFF RID: 3839 RVA: 0x000842CD File Offset: 0x000824CD
    private static void GsFontBuild()
    {
        AppMain.GsFontBuild( true );
    }

    // Token: 0x06000F00 RID: 3840 RVA: 0x000842D5 File Offset: 0x000824D5
    private static void GsFontBuild( bool use_mem2 )
    {
        AppMain.g_gs_font_builded = true;
    }

    // Token: 0x06000F01 RID: 3841 RVA: 0x000842DD File Offset: 0x000824DD
    private static bool GsFontIsBuilding()
    {
        return false;
    }

    // Token: 0x06000F02 RID: 3842 RVA: 0x000842E0 File Offset: 0x000824E0
    private static bool GsFontIsBuilded()
    {
        return AppMain.g_gs_font_builded;
    }

    // Token: 0x06000F03 RID: 3843 RVA: 0x000842E7 File Offset: 0x000824E7
    private static void GsFontRelease()
    {
        AppMain.g_gs_font_builded = false;
    }
}
