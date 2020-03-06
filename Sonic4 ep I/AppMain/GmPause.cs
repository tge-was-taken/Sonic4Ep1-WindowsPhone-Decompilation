using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200002D RID: 45
    public class GMS_PAUSE_WORK
    {
        // Token: 0x06001D32 RID: 7474 RVA: 0x00137216 File Offset: 0x00135416
        internal void Clear()
        {
            this.flag = 0U;
            this.proc_update = null;
            this.time_count_flag_save = 0U;
        }

        // Token: 0x04004802 RID: 18434
        public uint flag;

        // Token: 0x04004803 RID: 18435
        public AppMain.GMS_PAUSE_WORK._proc_update_ proc_update;

        // Token: 0x04004804 RID: 18436
        public uint time_count_flag_save;

        // Token: 0x0200002E RID: 46
        // (Invoke) Token: 0x06001D35 RID: 7477
        public delegate void _proc_update_( AppMain.GMS_PAUSE_WORK work );
    }

    // Token: 0x0600003F RID: 63 RVA: 0x000044FC File Offset: 0x000026FC
    public static void GmPauseInit()
    {
        AppMain.ObjObjectPause( 2 );
        AppMain.g_gm_main_system.game_flag |= 64U;
        AppMain.g_gm_main_system.game_flag &= 4294967167U;
        uint time_count_flag_save = AppMain.g_gm_main_system.game_flag & 3072U;
        AppMain.g_gm_main_system.game_flag &= 4294964223U;
        AppMain.gm_pause_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmPauseMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmPauseDest ), 0U, 3, 28928U, 6, () => new AppMain.GMS_PAUSE_WORK(), "GM_PAUSE" );
        AppMain.GMS_PAUSE_WORK gms_PAUSE_WORK = (AppMain.GMS_PAUSE_WORK)AppMain.gm_pause_tcb.work;
        gms_PAUSE_WORK.Clear();
        gms_PAUSE_WORK.time_count_flag_save = time_count_flag_save;
        AppMain.gmPauseProcUpdateInit( gms_PAUSE_WORK );
    }

    // Token: 0x06000040 RID: 64 RVA: 0x000045D0 File Offset: 0x000027D0
    private static void GmPauseExit()
    {
        if ( !AppMain.GmPauseMenuIsFinished() )
        {
            AppMain.GmPauseMenuCancel();
        }
        if ( AppMain.gm_pause_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_pause_tcb );
            AppMain.gm_pause_tcb = null;
        }
    }

    // Token: 0x06000041 RID: 65 RVA: 0x000045F8 File Offset: 0x000027F8
    public static bool GmPauseCheckExecutable()
    {
        return AppMain.gm_pause_tcb == null && ( AppMain.g_gm_main_system.game_flag & 32968936U ) == 0U && AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] != null && ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 1024U ) == 0U;
    }

    // Token: 0x06000042 RID: 66 RVA: 0x0000464C File Offset: 0x0000284C
    private static void gmPauseDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_PAUSE_WORK gms_PAUSE_WORK = (AppMain.GMS_PAUSE_WORK)tcb.work;
        AppMain.g_gm_main_system.game_flag |= ( gms_PAUSE_WORK.time_count_flag_save & 3072U );
        AppMain.g_gm_main_system.game_flag &= 4294967231U;
        AppMain.gm_pause_tcb = null;
    }

    // Token: 0x06000043 RID: 67 RVA: 0x0000469C File Offset: 0x0000289C
    private static void gmPauseMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_PAUSE_WORK gms_PAUSE_WORK = (AppMain.GMS_PAUSE_WORK)tcb.work;
        if ( gms_PAUSE_WORK.proc_update != null )
        {
            gms_PAUSE_WORK.proc_update( gms_PAUSE_WORK );
        }
        if ( ( gms_PAUSE_WORK.flag & 1U ) != 0U )
        {
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x06000044 RID: 68 RVA: 0x000046D9 File Offset: 0x000028D9
    private static void gmPauseExecRecoverRoutine( AppMain.GMS_PAUSE_WORK pause_work, bool b_rec_snd )
    {
        AppMain.ObjObjectPauseOut();
        pause_work.flag |= 1U;
        if ( b_rec_snd )
        {
            AppMain.GmSoundAllResume();
        }
    }

    // Token: 0x06000045 RID: 69 RVA: 0x000046F6 File Offset: 0x000028F6
    private static void gmPauseProcUpdateInit( AppMain.GMS_PAUSE_WORK pause_work )
    {
        pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdatePauseMenuStart );
    }

    // Token: 0x06000046 RID: 70 RVA: 0x0000470A File Offset: 0x0000290A
    private static void gmPauseProcUpdateReinit( AppMain.GMS_PAUSE_WORK pause_work )
    {
        AppMain.GmPauseMenuStart( 28928U );
        pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdateWaitDecision );
    }

    // Token: 0x06000047 RID: 71 RVA: 0x00004728 File Offset: 0x00002928
    private static void gmPauseProcUpdatePauseMenuStart( AppMain.GMS_PAUSE_WORK pause_work )
    {
        AppMain.GmSoundAllPause();
        AppMain.GmPauseMenuStart( 28928U );
        pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdateWaitDecision );
    }

    // Token: 0x06000048 RID: 72 RVA: 0x0000474C File Offset: 0x0000294C
    private static void gmPauseProcUpdateWaitDecision( AppMain.GMS_PAUSE_WORK pause_work )
    {
        if ( AppMain.GmPauseMenuIsFinished() )
        {
            int num = AppMain.GmPauseMenuGetResult();
            bool flag = false;
            switch ( num )
            {
                case 0:
                case 2:
                case 3:
                    SaveState.deleteSave();
                    flag = true;
                    pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdateFadeOutToExitGame );
                    goto IL_77;
                case 1:
                    flag = true;
                    pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdateFadeOutToOption );
                    goto IL_77;
            }
            AppMain.gmPauseExecRecoverRoutine( pause_work, true );
            pause_work.proc_update = null;
            IL_77:
            if ( flag )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 20f, true );
            }
        }
    }

    // Token: 0x06000049 RID: 73 RVA: 0x000047ED File Offset: 0x000029ED
    private static void gmPauseProcUpdateFadeOutToOption( AppMain.GMS_PAUSE_WORK pause_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.DmOptionStart( null );
            pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdateWaitRecover );
        }
    }

    // Token: 0x0600004A RID: 74 RVA: 0x00004810 File Offset: 0x00002A10
    private static void gmPauseProcUpdateWaitRecover( AppMain.GMS_PAUSE_WORK pause_work )
    {
        bool flag = true;
        if ( !AppMain.DmOptionIsExit() )
        {
            flag = false;
        }
        if ( flag )
        {
            AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 1U, 0U, 20f, true );
            pause_work.proc_update = new AppMain.GMS_PAUSE_WORK._proc_update_( AppMain.gmPauseProcUpdateFadeInFromDemo );
        }
    }

    // Token: 0x0600004B RID: 75 RVA: 0x00004857 File Offset: 0x00002A57
    private static void gmPauseProcUpdateFadeInFromDemo( AppMain.GMS_PAUSE_WORK pause_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            AppMain.gmPauseProcUpdateReinit( pause_work );
        }
    }

    // Token: 0x0600004C RID: 76 RVA: 0x0000486B File Offset: 0x00002A6B
    private static void gmPauseProcUpdateFadeOutToExitGame( AppMain.GMS_PAUSE_WORK pause_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.g_gm_main_system.game_flag |= 128U;
            AppMain.gmPauseExecRecoverRoutine( pause_work, false );
        }
    }

    // Token: 0x06001549 RID: 5449 RVA: 0x000B9354 File Offset: 0x000B7554
    public static void GmPauseMenuLoadStart()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        cmain_PauseMenu.Create();
        cmain_PauseMenu.LoadFile();
    }

    // Token: 0x0600154A RID: 5450 RVA: 0x000B9374 File Offset: 0x000B7574
    public static bool GmPauseMenuLoadIsFinished()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        return cmain_PauseMenu.IsLoadFile();
    }

    // Token: 0x0600154B RID: 5451 RVA: 0x000B9390 File Offset: 0x000B7590
    public static void GmPauseMenuBuildStart()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        cmain_PauseMenu.CreateTexture();
    }

    // Token: 0x0600154C RID: 5452 RVA: 0x000B93AC File Offset: 0x000B75AC
    public static bool GmPauseMenuBuildIsFinished()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        return cmain_PauseMenu.IsCreatedTexture();
    }

    // Token: 0x0600154D RID: 5453 RVA: 0x000B93C8 File Offset: 0x000B75C8
    public static void GmPauseMenuFlushStart()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        cmain_PauseMenu.ReleaseTexture();
    }

    // Token: 0x0600154E RID: 5454 RVA: 0x000B93E4 File Offset: 0x000B75E4
    public static bool GmPauseMenuFlushIsFinished()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        return cmain_PauseMenu.IsReleasedTexture();
    }

    // Token: 0x0600154F RID: 5455 RVA: 0x000B9400 File Offset: 0x000B7600
    public static void GmPauseMenuRelease()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        cmain_PauseMenu.Release();
    }

    // Token: 0x06001550 RID: 5456 RVA: 0x000B941C File Offset: 0x000B761C
    public static void GmPauseMenuStart( uint prio )
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        cmain_PauseMenu.Start( prio );
    }

    // Token: 0x06001551 RID: 5457 RVA: 0x000B9438 File Offset: 0x000B7638
    public static void GmPauseMenuCancel()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        cmain_PauseMenu.Cancel();
    }

    // Token: 0x06001552 RID: 5458 RVA: 0x000B9454 File Offset: 0x000B7654
    public static bool GmPauseMenuIsFinished()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        return cmain_PauseMenu.IsPlay();
    }

    // Token: 0x06001553 RID: 5459 RVA: 0x000B9470 File Offset: 0x000B7670
    public static int GmPauseMenuGetResult()
    {
        AppMain.CMain_PauseMenu cmain_PauseMenu = AppMain.CMain_PauseMenu.CreateInstance();
        return cmain_PauseMenu.GetResult();
    }
}