using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000229 RID: 553
    public class DMS_SND_BGM_PLAYER_MAIN_WORK
    {
        // Token: 0x04005728 RID: 22312
        public AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_ proc_update;

        // Token: 0x04005729 RID: 22313
        public uint flag;

        // Token: 0x0400572A RID: 22314
        public int end_timer;

        // Token: 0x0200022A RID: 554
        // (Invoke) Token: 0x0600237C RID: 9084
        public delegate void _proc_( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK work );
    }

    // Token: 0x06000CA2 RID: 3234 RVA: 0x00070050 File Offset: 0x0006E250
    public static void DmSndBgmPlayerInit()
    {
        AppMain.dmSndBgmPlayerInit();
    }

    // Token: 0x06000CA3 RID: 3235 RVA: 0x00070057 File Offset: 0x0006E257
    public static void DmSndBgmPlayerExit()
    {
        AppMain.dm_snd_bgm_player_flag |= 4U;
    }

    // Token: 0x06000CA4 RID: 3236 RVA: 0x00070065 File Offset: 0x0006E265
    public static void DmSndBgmPlayerBgmStop()
    {
        AppMain.dm_snd_bgm_player_flag |= 8U;
    }

    // Token: 0x06000CA5 RID: 3237 RVA: 0x00070073 File Offset: 0x0006E273
    private static bool DmSndBgmPlayerIsTaskExit()
    {
        return AppMain.dm_snd_bgm_player_tcb == null;
    }

    // Token: 0x06000CA6 RID: 3238 RVA: 0x0007007F File Offset: 0x0006E27F
    private static bool DmSndBgmPlayerIsSndSysBuild()
    {
        return AppMain.DmSoundBuildCheck();
    }

    // Token: 0x06000CA7 RID: 3239 RVA: 0x0007008C File Offset: 0x0006E28C
    public static void DmSndBgmPlayerPlayBgm( int idx )
    {
        if ( AppMain.dm_snd_bgm_player_tcb == null )
        {
            AppMain.dmSndBgmPlayerInit();
        }
        if ( idx == 0 )
        {
            if ( ( AppMain.dm_snd_bgm_player_flag & 16U ) != 0U )
            {
                AppMain.dm_snd_bgm_player_flag |= 128U;
                return;
            }
            if ( ( AppMain.dm_snd_bgm_player_flag & 32U ) == 0U )
            {
                AppMain.dm_snd_bgm_player_flag |= 32U;
                return;
            }
        }
        else if ( idx == 1 )
        {
            if ( ( AppMain.dm_snd_bgm_player_flag & 32U ) != 0U )
            {
                AppMain.dm_snd_bgm_player_flag |= 64U;
                return;
            }
            if ( ( AppMain.dm_snd_bgm_player_flag & 16U ) == 0U )
            {
                AppMain.dm_snd_bgm_player_flag |= 16U;
            }
        }
    }

    // Token: 0x06000CA8 RID: 3240 RVA: 0x00070118 File Offset: 0x0006E318
    private static void dmSndBgmPlayerInit()
    {
        if ( AppMain.dm_snd_bgm_player_tcb != null )
        {
            return;
        }
        AppMain.dm_snd_bgm_player_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.dmSndBgmPlayerProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.dmSndBgmPlayerDest ), 0U, 0, 4096U, 0, () => new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK(), "DM_SND_BGM_PLAYER_MAIN" );
        AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK dms_SND_BGM_PLAYER_MAIN_WORK = (AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK)AppMain.dm_snd_bgm_player_tcb.work;
        AppMain.dm_snd_bgm_player_flag = 0U;
        dms_SND_BGM_PLAYER_MAIN_WORK.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcInit );
    }

    // Token: 0x06000CA9 RID: 3241 RVA: 0x000701A4 File Offset: 0x0006E3A4
    private static void dmSndBgmPlayerProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK dms_SND_BGM_PLAYER_MAIN_WORK = (AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK)tcb.work;
        if ( ( AppMain.dm_snd_bgm_player_flag & 1U ) != 0U )
        {
            AppMain.mtTaskClearTcb( tcb );
            AppMain.dm_snd_bgm_player_flag = 0U;
            AppMain.dm_snd_bgm_player_tcb = null;
        }
        if ( dms_SND_BGM_PLAYER_MAIN_WORK.proc_update != null )
        {
            dms_SND_BGM_PLAYER_MAIN_WORK.proc_update( dms_SND_BGM_PLAYER_MAIN_WORK );
        }
    }

    // Token: 0x06000CAA RID: 3242 RVA: 0x000701EC File Offset: 0x0006E3EC
    private static void dmSndBgmPlayerDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06000CAB RID: 3243 RVA: 0x000701EE File Offset: 0x0006E3EE
    private static void dmSndBgmPlayerProcInit( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        AppMain.DmSoundBuild();
        main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcBuildIdle );
    }

    // Token: 0x06000CAC RID: 3244 RVA: 0x00070207 File Offset: 0x0006E407
    private static void dmSndBgmPlayerProcBuildIdle( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        if ( AppMain.DmSoundBuildCheck() )
        {
            AppMain.DmSoundInit();
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcWaitSetBgm );
            main_work.end_timer = 0;
        }
    }

    // Token: 0x06000CAD RID: 3245 RVA: 0x00070230 File Offset: 0x0006E430
    private static void dmSndBgmPlayerProcWaitSetBgm( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        AppMain.GsGetMainSysInfo();
        if ( ( AppMain.dm_snd_bgm_player_flag & 8U ) != 0U || ( AppMain.dm_snd_bgm_player_flag & 4U ) != 0U )
        {
            AppMain.DmSoundStopJingle( 24 );
            AppMain.DmSoundStopBGM( 24 );
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcStopIdle );
            return;
        }
        if ( ( AppMain.dm_snd_bgm_player_flag & 16U ) != 0U || ( AppMain.dm_snd_bgm_player_flag & 32U ) != 0U )
        {
            if ( ( AppMain.dm_snd_bgm_player_flag & 16U ) != 0U )
            {
                AppMain.DmSoundPlayJingle( 0, 0 );
                AppMain.dm_snd_bgm_player_flag &= 4294967263U;
            }
            else
            {
                AppMain.DmSoundPlayMenuBGM( 0, 32 );
                AppMain.dm_snd_bgm_player_flag &= 4294967279U;
            }
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcPlayIdle );
            main_work.end_timer = 0;
            return;
        }
        if ( ( AppMain.dm_snd_bgm_player_flag & 64U ) != 0U )
        {
            AppMain.DmSoundStopBGM( 0 );
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcStopIdle );
            return;
        }
        if ( ( AppMain.dm_snd_bgm_player_flag & 128U ) != 0U )
        {
            AppMain.DmSoundStopJingle( 24 );
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcStopIdle );
        }
    }

    // Token: 0x06000CAE RID: 3246 RVA: 0x00070324 File Offset: 0x0006E524
    private static void dmSndBgmPlayerProcPlayIdle( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        if ( ( AppMain.dm_snd_bgm_player_flag & 8U ) != 0U || ( AppMain.dm_snd_bgm_player_flag & 4U ) != 0U )
        {
            AppMain.DmSoundStopJingle( 24 );
            AppMain.DmSoundStopBGM( 24 );
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcStopIdle );
            return;
        }
        if ( ( AppMain.dm_snd_bgm_player_flag & 64U ) != 0U )
        {
            AppMain.DmSoundStopBGM( 0 );
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcStopIdle );
            return;
        }
        if ( ( AppMain.dm_snd_bgm_player_flag & 128U ) != 0U )
        {
            AppMain.DmSoundStopJingle( 24 );
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcStopIdle );
        }
    }

    // Token: 0x06000CAF RID: 3247 RVA: 0x000703B0 File Offset: 0x0006E5B0
    private static void dmSndBgmPlayerProcStopIdle( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        if ( AppMain.DmSoundIsStopStageBGM() && AppMain.DmSoundIsStopJingle() )
        {
            if ( ( AppMain.dm_snd_bgm_player_flag & 4U ) != 0U )
            {
                AppMain.dm_snd_bgm_player_flag &= 4294967291U;
                main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcSndRelease );
                return;
            }
            if ( ( AppMain.dm_snd_bgm_player_flag & 64U ) != 0U )
            {
                AppMain.dm_snd_bgm_player_flag |= 16U;
                AppMain.dm_snd_bgm_player_flag &= 4294967231U;
            }
            else if ( ( AppMain.dm_snd_bgm_player_flag & 64U ) == 0U && ( AppMain.dm_snd_bgm_player_flag & 128U ) == 0U && ( AppMain.dm_snd_bgm_player_flag & 8U ) == 0U )
            {
                AppMain.dm_snd_bgm_player_flag |= 16U;
            }
            else if ( ( AppMain.dm_snd_bgm_player_flag & 8U ) != 0U )
            {
                AppMain.dm_snd_bgm_player_flag &= 4294967279U;
                AppMain.dm_snd_bgm_player_flag &= 4294967263U;
                AppMain.dm_snd_bgm_player_flag &= 4294967287U;
            }
            else
            {
                AppMain.dm_snd_bgm_player_flag |= 32U;
                AppMain.dm_snd_bgm_player_flag &= 4294967167U;
            }
            main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcWaitSetBgm );
        }
    }

    // Token: 0x06000CB0 RID: 3248 RVA: 0x000704B0 File Offset: 0x0006E6B0
    private static void dmSndBgmPlayerProcSndRelease( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        AppMain.DmSoundExit();
        AppMain.DmSoundFlush();
        main_work.proc_update = new AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK._proc_( AppMain.dmSndBgmPlayerProcSndFinish );
    }

    // Token: 0x06000CB1 RID: 3249 RVA: 0x000704CE File Offset: 0x0006E6CE
    private static void dmSndBgmPlayerProcSndFinish( AppMain.DMS_SND_BGM_PLAYER_MAIN_WORK main_work )
    {
        main_work.proc_update = null;
        AppMain.dm_snd_bgm_player_flag |= 1U;
    }
}