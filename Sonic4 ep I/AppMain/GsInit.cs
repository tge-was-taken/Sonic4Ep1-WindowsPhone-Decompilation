using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001CD RID: 461
    // (Invoke) Token: 0x06002245 RID: 8773
    public delegate void GSF_INIT_FUNC();

    // Token: 0x020001CE RID: 462
    public class GSS_INIT_WORK
    {
        // Token: 0x0400504A RID: 20554
        public int count;

        // Token: 0x0400504B RID: 20555
        public AppMain.AMS_FS fs;

        // Token: 0x0400504C RID: 20556
        public AppMain.GSS_INIT_WORK.ProcDelegate proc;

        // Token: 0x020001CF RID: 463
        // (Invoke) Token: 0x0600224A RID: 8778
        public delegate void ProcDelegate( AppMain.GSS_INIT_WORK work );
    }

    // Token: 0x060009E9 RID: 2537 RVA: 0x000599AC File Offset: 0x00057BAC
    private static void GsInitOtherStart()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        gss_MAIN_SYS_INFO.is_save_run = 0U;
        AppMain.g_gs_init_tcb = AppMain.amTaskMake( new AppMain.TaskProc( AppMain.gsInitTaskProcedure ), new AppMain.TaskProc( AppMain.gsInitTaskDestructor ), 0U, 0U, 0U, "gsInit" );
        AppMain.g_gs_init_tcb.work = new AppMain.GSS_INIT_WORK();
        AppMain.GSS_INIT_WORK gss_INIT_WORK = (AppMain.GSS_INIT_WORK)AppMain.amTaskGetWork(AppMain.g_gs_init_tcb);
        gss_INIT_WORK.count = 0;
        gss_INIT_WORK.fs = null;
        gss_INIT_WORK.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcSysFirst );
        AppMain.amTaskStart( AppMain.g_gs_init_tcb );
    }

    // Token: 0x060009EA RID: 2538 RVA: 0x00059A3A File Offset: 0x00057C3A
    private static bool GsInitOtherIsInitialized()
    {
        return AppMain.g_gs_init_tcb == null;
    }

    // Token: 0x060009EB RID: 2539 RVA: 0x00059A46 File Offset: 0x00057C46
    private static void GsOtherExit()
    {
    }

    // Token: 0x060009EC RID: 2540 RVA: 0x00059A48 File Offset: 0x00057C48
    private static void gsInitTaskProcedure( AppMain.AMS_TCB tcb )
    {
        AppMain.GSS_INIT_WORK gss_INIT_WORK = (AppMain.GSS_INIT_WORK)AppMain.amTaskGetWork(tcb);
        if ( gss_INIT_WORK.proc == null )
        {
            AppMain.amTaskDelete( tcb );
            return;
        }
        Delegate proc = gss_INIT_WORK.proc;
        gss_INIT_WORK.proc( gss_INIT_WORK );
        if ( gss_INIT_WORK.proc != proc )
        {
            gss_INIT_WORK.count = 0;
            return;
        }
        if ( gss_INIT_WORK.count < -1 )
        {
            gss_INIT_WORK.count++;
        }
    }

    // Token: 0x060009ED RID: 2541 RVA: 0x00059AAB File Offset: 0x00057CAB
    private static void gsInitTaskDestructor( AppMain.AMS_TCB tcb )
    {
        AppMain.g_gs_init_tcb = null;
    }

    // Token: 0x060009EE RID: 2542 RVA: 0x00059AB4 File Offset: 0x00057CB4
    private static void gsInitProcSysFirst( AppMain.GSS_INIT_WORK work )
    {
        AppMain.GsEnvInit();
        AppMain.GsFontInit();
        AppMain.AoSysInit();
        AppMain.AoActSysInit( 256U, 256U, 256U, 32U );
        AppMain.GsSystemBgmInit();
        AppMain.GsSystemBgmSetEnable( true );
        AppMain.GsRebootInit();
        bool flag = true;
        AppMain.GsRebootIsTitleReboot();
        if ( flag )
        {
            AppMain.IzFadeInitEasyTask( 0U, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, 1f );
        }
        else
        {
            AppMain.IzFadeInitEasyTask( 0U, 0, 0, 0, byte.MaxValue, 0, 0, 0, byte.MaxValue, 1f );
        }
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcStrapLoad );
    }

    // Token: 0x060009EF RID: 2543 RVA: 0x00059B63 File Offset: 0x00057D63
    private static void gsInitProcStrapLoad( AppMain.GSS_INIT_WORK work )
    {
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcLoadLoadingFile );
    }

    // Token: 0x060009F0 RID: 2544 RVA: 0x00059B78 File Offset: 0x00057D78
    private static void gsInitProcLoadLoadingFile( AppMain.GSS_INIT_WORK work )
    {
        if ( work.fs == null )
        {
            work.fs = AppMain.amFsReadBackground( "DEMO/LOADING/D_LOADING.AMB" );
        }
        if ( AppMain.amFsIsComplete( work.fs ) )
        {
            AppMain.DmLoadingBuild( work.fs );
            AppMain.amFsClearRequest( work.fs );
            work.fs = null;
            work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcBuildLoadingFile );
        }
    }

    // Token: 0x060009F1 RID: 2545 RVA: 0x00059BD9 File Offset: 0x00057DD9
    private static void gsInitProcBuildLoadingFile( AppMain.GSS_INIT_WORK work )
    {
        if ( AppMain.DmLoadingBuildCheck() )
        {
            work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcLoadSysMsgFile );
        }
    }

    // Token: 0x060009F2 RID: 2546 RVA: 0x00059BF4 File Offset: 0x00057DF4
    private static void gsInitProcLoadSysMsgFile( AppMain.GSS_INIT_WORK work )
    {
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcLoadSaveMsgFile );
    }

    // Token: 0x060009F3 RID: 2547 RVA: 0x00059C08 File Offset: 0x00057E08
    private static void gsInitProcLoadSaveMsgFile( AppMain.GSS_INIT_WORK work )
    {
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcSysLast );
    }

    // Token: 0x060009F4 RID: 2548 RVA: 0x00059C1C File Offset: 0x00057E1C
    private static void gsInitProcSysLast( AppMain.GSS_INIT_WORK work )
    {
        AppMain.AoAccountInit();
        AppMain.AoStorageInit();
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcCheckTrial );
    }

    // Token: 0x060009F5 RID: 2549 RVA: 0x00059C3C File Offset: 0x00057E3C
    private static void gsInitProcCheckTrial( AppMain.GSS_INIT_WORK work )
    {
        if ( work.count == 0 )
        {
            AppMain.GsTrialInitStart();
        }
        if ( AppMain.GsTrialInitIsFinished() )
        {
            AppMain.amSystemLog( "\n================================================\n" );
            if ( AppMain.GsTrialIsTrial() )
            {
                AppMain.amSystemLog( "gsInit - product mode : Trial\n" );
            }
            else
            {
                AppMain.amSystemLog( "gsInit - product mode : Full\n" );
            }
            AppMain.amSystemLog( "================================================\n\n" );
            work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcInitTorphy );
        }
    }

    // Token: 0x060009F6 RID: 2550 RVA: 0x00059CA0 File Offset: 0x00057EA0
    private static void gsInitProcInitTorphy( AppMain.GSS_INIT_WORK work )
    {
        AppMain.GsTrophyInit();
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcInstallTorphy );
    }

    // Token: 0x060009F7 RID: 2551 RVA: 0x00059CB9 File Offset: 0x00057EB9
    private static void gsInitProcInstallTorphy( AppMain.GSS_INIT_WORK work )
    {
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcPresence );
    }

    // Token: 0x060009F8 RID: 2552 RVA: 0x00059CCD File Offset: 0x00057ECD
    private static void gsInitProcPresence( AppMain.GSS_INIT_WORK work )
    {
        if ( work.count == 0 )
        {
            AppMain.AoPresenceInit();
        }
        if ( AppMain.AoPresenceInitialized() )
        {
            work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcWaitPadEnable );
        }
    }

    // Token: 0x060009F9 RID: 2553 RVA: 0x00059CF5 File Offset: 0x00057EF5
    private static void gsInitProcWaitPadEnable( AppMain.GSS_INIT_WORK work )
    {
        work.proc = new AppMain.GSS_INIT_WORK.ProcDelegate( AppMain.gsInitProcEnd );
    }

    // Token: 0x060009FA RID: 2554 RVA: 0x00059D09 File Offset: 0x00057F09
    private static void gsInitProcEnd( AppMain.GSS_INIT_WORK work )
    {
        work.proc = null;
    }
}