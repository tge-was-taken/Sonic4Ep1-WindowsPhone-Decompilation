using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.backup;

public partial class AppMain
{
    // Token: 0x020001C0 RID: 448
    private enum DME_SAVE_ACT
    {
        // Token: 0x04005007 RID: 20487
        ACT_WIN_LINE,
        // Token: 0x04005008 RID: 20488
        ACT_TEX_WINTITLE,
        // Token: 0x04005009 RID: 20489
        ACT_TEX_MSG1,
        // Token: 0x0400500A RID: 20490
        ACT_TEX_MSG2,
        // Token: 0x0400500B RID: 20491
        ACT_TEX_MSG3,
        // Token: 0x0400500C RID: 20492
        ACT_TEX_OK,
        // Token: 0x0400500D RID: 20493
        ACT_NUM,
        // Token: 0x0400500E RID: 20494
        ACT_NONE
    }

    // Token: 0x020001C1 RID: 449
    // (Invoke) Token: 0x0600222B RID: 8747
    public delegate void _saveproc_input_update( AppMain.DMS_SAVE_MAIN_WORK work );

    // Token: 0x020001C2 RID: 450
    // (Invoke) Token: 0x0600222F RID: 8751
    public delegate void _saveproc_draw();

    // Token: 0x020001C3 RID: 451
    public class DMS_SAVE_MAIN_WORK
    {
        // Token: 0x0400500F RID: 20495
        public readonly AppMain.AMS_FS[] arc_cmn_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x04005010 RID: 20496
        public readonly AppMain.AMS_AMB_HEADER[] arc_cmn_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005011 RID: 20497
        public readonly AppMain.A2S_AMA_HEADER[] cmn_ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x04005012 RID: 20498
        public readonly AppMain.AMS_AMB_HEADER[] cmn_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005013 RID: 20499
        public readonly AppMain.AOS_TEXTURE[] cmn_tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x04005014 RID: 20500
        public readonly AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[6];

        // Token: 0x04005015 RID: 20501
        public AppMain._saveproc_input_update proc_input;

        // Token: 0x04005016 RID: 20502
        public AppMain._saveproc_input_update proc_menu_update;

        // Token: 0x04005017 RID: 20503
        public AppMain._saveproc_draw proc_draw;

        // Token: 0x04005018 RID: 20504
        public uint flag;

        // Token: 0x04005019 RID: 20505
        public uint announce_flag;

        // Token: 0x0400501A RID: 20506
        public uint disp_flag;

        // Token: 0x0400501B RID: 20507
        public int state;

        // Token: 0x0400501C RID: 20508
        public int timer;

        // Token: 0x0400501D RID: 20509
        public int win_timer;

        // Token: 0x0400501E RID: 20510
        public readonly float[][] win_act_pos = AppMain.New<float>(5, 2);

        // Token: 0x0400501F RID: 20511
        public readonly float[] win_size_rate = new float[2];

        // Token: 0x04005020 RID: 20512
        public int win_mode;

        // Token: 0x04005021 RID: 20513
        public int win_cur_slct;

        // Token: 0x04005022 RID: 20514
        public uint draw_state;

        // Token: 0x04005023 RID: 20515
        public AppMain.GSS_SND_SCB bgm_scb;
    }

    // Token: 0x020001C4 RID: 452
    public class DMS_SAVE_MGR
    {
        // Token: 0x06002233 RID: 8755 RVA: 0x00142524 File Offset: 0x00140724
        internal void Clear()
        {
            this.tcb = null;
        }

        // Token: 0x04005024 RID: 20516
        public AppMain.MTS_TASK_TCB tcb;
    }

    // Token: 0x0600097E RID: 2430 RVA: 0x00055830 File Offset: 0x00053A30
    public static void DmSaveStart( uint disp_flag, bool is_first_save, bool is_task_draw )
    {
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 6 || cur_evt_id == 11 || cur_evt_id == 9 )
        {
            return;
        }
        if ( ( disp_flag & 4U ) != 0U && AppMain.GsTrialIsTrial() )
        {
            return;
        }
        AppMain.dm_save_mgr.Clear();
        AppMain.dm_save_mgr_p = AppMain.dm_save_mgr;
        AppMain.dm_save_msg_flag = disp_flag;
        AppMain.dm_save_first_save = is_first_save;
        AppMain.dm_save_is_task_draw = is_task_draw;
        AppMain.dm_save_is_snd_build = false;
        AppMain.dmSaveInit();
    }

    // Token: 0x0600097F RID: 2431 RVA: 0x00055897 File Offset: 0x00053A97
    private static void DmSaveAttenMsgStart()
    {
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        AppMain.dm_save_mgr.Clear();
        AppMain.dm_save_mgr_p = AppMain.dm_save_mgr;
        AppMain.dm_save_msg_flag = 2U;
        AppMain.dm_save_first_save = false;
        AppMain.dm_save_is_task_draw = false;
        AppMain.dm_save_is_snd_build = true;
        AppMain.dmSaveInit();
    }

    // Token: 0x06000980 RID: 2432 RVA: 0x000558D8 File Offset: 0x00053AD8
    private static void DmSaveMenuStart( bool is_task_draw, bool is_snd_build )
    {
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 6 || cur_evt_id == 11 || cur_evt_id == 9 )
        {
            return;
        }
        if ( !AppMain.AoAccountIsCurrentEnable() )
        {
            return;
        }
        AppMain.dmSaveSetSysDataForBackup();
        if ( AppMain.GsTrialIsTrial() )
        {
            return;
        }
        if ( AppMain.dmSaveIsSaveNecessary() )
        {
            return;
        }
        AppMain.dm_save_mgr.Clear();
        AppMain.dm_save_mgr_p = AppMain.dm_save_mgr;
        AppMain.dm_save_msg_flag = 4U;
        AppMain.dm_save_first_save = false;
        AppMain.dm_save_is_task_draw = is_task_draw;
        AppMain.dm_save_is_snd_build = is_snd_build;
        AppMain.dmSaveInit();
    }

    // Token: 0x06000981 RID: 2433 RVA: 0x0005594F File Offset: 0x00053B4F
    public static bool DmSaveIsExit()
    {
        return AppMain.dm_save_mgr_p == null || AppMain.dm_save_mgr_p.tcb == null;
    }

    // Token: 0x06000982 RID: 2434 RVA: 0x00055969 File Offset: 0x00053B69
    private static bool DmSaveIsDraw()
    {
        return AppMain.dm_save_draw_reserve;
    }

    // Token: 0x06000983 RID: 2435 RVA: 0x00055978 File Offset: 0x00053B78
    private static void dmSaveInit()
    {
        AppMain.dm_save_mgr_p.tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.dmSaveProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.dmSaveDest ), 0U, 32767, 8192U, 0, () => new AppMain.DMS_SAVE_MAIN_WORK(), "SAVE_TASK" );
        AppMain.DMS_SAVE_MAIN_WORK dms_SAVE_MAIN_WORK = (AppMain.DMS_SAVE_MAIN_WORK)AppMain.dm_save_mgr_p.tcb.work;
        AppMain.dm_save_disp_flag = 0U;
        AppMain.dm_save_is_draw_state = 0U;
        AppMain.dm_save_win_mode = 0;
        AppMain.dm_save_draw_reserve = false;
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.dm_save_win_size_rate[i] = 0f;
            AppMain.dm_save_cmn_tex[i] = null;
        }
        for ( int j = 0; j < 6; j++ )
        {
            AppMain.dm_save_act[j] = null;
        }
        dms_SAVE_MAIN_WORK.announce_flag = AppMain.dm_save_msg_flag;
        dms_SAVE_MAIN_WORK.draw_state = ( AppMain.AoActSysGetDrawStateEnable() ? 1U : 0U );
        if ( dms_SAVE_MAIN_WORK.draw_state != 0U )
        {
            AppMain.dm_save_draw_state = AppMain.AoActSysGetDrawState();
        }
        else
        {
            AppMain.dm_save_draw_state = 0U;
        }
        for ( int k = 0; k < 2; k++ )
        {
            AppMain.dm_save_cmn_tex[k] = null;
        }
        AppMain.dm_save_is_draw_state = dms_SAVE_MAIN_WORK.draw_state;
        dms_SAVE_MAIN_WORK.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveLoadFontData );
    }

    // Token: 0x06000984 RID: 2436 RVA: 0x00055AA4 File Offset: 0x00053CA4
    private static void dmSaveSetSysDataForBackup()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        SSystem ssystem = SSystem.CreateInstance();
        ssystem.SetKilled( gss_MAIN_SYS_INFO.ene_kill_count );
        ssystem.SetPlayerStock( gss_MAIN_SYS_INFO.rest_player_num );
    }

    // Token: 0x06000985 RID: 2437 RVA: 0x00055AD8 File Offset: 0x00053CD8
    private static bool dmSaveIsSaveNecessary()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( gss_MAIN_SYS_INFO.is_save_run == 0U )
        {
            return true;
        }
        SSystem ssystem = SSystem.CreateInstance();
        SStage sstage = SStage.CreateInstance();
        SSpecial sspecial = SSpecial.CreateInstance();
        SOption soption = SOption.CreateInstance();
        SSystem system = gss_MAIN_SYS_INFO.cmp_backup.GetSystem();
        SStage sstage2 = gss_MAIN_SYS_INFO.cmp_backup.GetStage();
        SSpecial special = gss_MAIN_SYS_INFO.cmp_backup.GetSpecial();
        SOption option = gss_MAIN_SYS_INFO.cmp_backup.GetOption();
        if ( ssystem.GetPlayerStock() != system.GetPlayerStock() )
        {
            return false;
        }
        if ( ssystem.GetKilled() != system.GetKilled() )
        {
            return false;
        }
        if ( ssystem.GetClearCount() != system.GetClearCount() )
        {
            return false;
        }
        for ( int i = 0; i < 7; i++ )
        {
            SSystem.EAnnounce index = (SSystem.EAnnounce)i;
            if ( ssystem.IsAnnounce( index ) != system.IsAnnounce( index ) )
            {
                return false;
            }
        }
        return AppMain.memcmp( sstage2.getData(), sstage.getData() ) == 0 && AppMain.memcmp( special.getData(), sspecial.getData() ) == 0 && AppMain.memcmp( option.getData(), soption.getData() ) == 0;
    }

    // Token: 0x06000986 RID: 2438 RVA: 0x00055BE8 File Offset: 0x00053DE8
    private static void dmSaveProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_SAVE_MAIN_WORK dms_SAVE_MAIN_WORK = (AppMain.DMS_SAVE_MAIN_WORK)tcb.work;
        if ( ( dms_SAVE_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.mtTaskClearTcb( tcb );
            AppMain.dm_save_disp_flag = 0U;
            AppMain.dm_save_is_draw_state = 0U;
            AppMain.dm_save_win_mode = 0;
            AppMain.dm_save_is_task_draw = false;
            for ( int i = 0; i < 2; i++ )
            {
                AppMain.dm_save_win_size_rate[i] = 0f;
            }
            AppMain.dm_save_mgr_p = null;
        }
        if ( ( dms_SAVE_MAIN_WORK.flag & 2147483648U ) != 0U && !AppMain.AoAccountIsCurrentEnable() )
        {
            dms_SAVE_MAIN_WORK.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcStopDraw );
            dms_SAVE_MAIN_WORK.proc_input = null;
            dms_SAVE_MAIN_WORK.proc_draw = null;
            AppMain.dm_save_draw_reserve = false;
            dms_SAVE_MAIN_WORK.flag &= 2147483647U;
            return;
        }
        if ( dms_SAVE_MAIN_WORK.proc_menu_update != null )
        {
            dms_SAVE_MAIN_WORK.proc_menu_update( dms_SAVE_MAIN_WORK );
        }
        if ( dms_SAVE_MAIN_WORK.proc_draw != null && !AppMain.AoSysMsgIsShow() )
        {
            dms_SAVE_MAIN_WORK.proc_draw();
        }
    }

    // Token: 0x06000987 RID: 2439 RVA: 0x00055CC3 File Offset: 0x00053EC3
    private static void dmSaveDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06000988 RID: 2440 RVA: 0x00055CC8 File Offset: 0x00053EC8
    private static void dmSaveLoadFontData( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 10 )
        {
            AppMain.GsFontBuild( false );
        }
        else
        {
            AppMain.GsFontBuild();
        }
        main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveIsLoadFontData );
    }

    // Token: 0x06000989 RID: 2441 RVA: 0x00055D04 File Offset: 0x00053F04
    private static void dmSaveIsLoadFontData( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.GsFontIsBuilded() )
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveLoadRequest );
        }
    }

    // Token: 0x0600098A RID: 2442 RVA: 0x00055D1F File Offset: 0x00053F1F
    private static void dmSaveLoadRequest( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        main_work.arc_cmn_amb_fs[0] = AppMain.amFsReadBackground( "DEMO/CMN/D_CMN_WIN.AMB" );
        main_work.arc_cmn_amb_fs[1] = AppMain.amFsReadBackground( AppMain.dm_save_menu_cmn_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcLoadWait );
    }

    // Token: 0x0600098B RID: 2443 RVA: 0x00055D60 File Offset: 0x00053F60
    private static void dmSaveProcLoadWait( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.dmSaveIsDataLoad( main_work ) != 0 )
        {
            for ( int i = 0; i < 2; i++ )
            {
                main_work.arc_cmn_amb[i] = AppMain.readAMBFile( main_work.arc_cmn_amb_fs[i] );
                main_work.arc_cmn_amb_fs[i] = null;
                main_work.cmn_ama[i] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_cmn_amb[i], 0 ) );
                string dir;
                main_work.cmn_amb[i] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_cmn_amb[i], 1, out dir ) );
                main_work.cmn_amb[i].dir = dir;
                AppMain.amFsClearRequest( main_work.arc_cmn_amb_fs[i] );
                main_work.arc_cmn_amb_fs[i] = null;
                AppMain.AoTexBuild( main_work.cmn_tex[i], main_work.cmn_amb[i] );
                AppMain.AoTexLoad( main_work.cmn_tex[i] );
            }
            if ( AppMain.dm_save_is_snd_build )
            {
                AppMain.DmSoundBuild();
            }
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcTexBuildWait );
        }
    }

    // Token: 0x0600098C RID: 2444 RVA: 0x00055E44 File Offset: 0x00054044
    private static void dmSaveProcTexBuildWait( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.dmSaveIsTexLoad( main_work ) == 1 )
        {
            for ( int i = 0; i < 2; i++ )
            {
                AppMain.dm_save_cmn_tex[i] = main_work.cmn_tex[i];
            }
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcCreateAct );
        }
    }

    // Token: 0x0600098D RID: 2445 RVA: 0x00055E88 File Offset: 0x00054088
    private static void dmSaveProcCreateAct( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 6U; num += 1U )
        {
            AppMain.A2S_AMA_HEADER ama;
            AppMain.AOS_TEXTURE tex;
            if ( num >= 1U )
            {
                ama = main_work.cmn_ama[1];
                tex = main_work.cmn_tex[1];
            }
            else
            {
                ama = main_work.cmn_ama[0];
                tex = main_work.cmn_tex[0];
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl[( int )( ( UIntPtr )num )] );
            AppMain.dm_save_act[( int )( ( UIntPtr )num )] = main_work.act[( int )( ( UIntPtr )num )];
        }
        if ( ( AppMain.dm_save_msg_flag & 4U ) != 0U )
        {
            main_work.flag |= 2147483648U;
        }
        main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowNodispIdle );
    }

    // Token: 0x0600098E RID: 2446 RVA: 0x00055F2C File Offset: 0x0005412C
    private static void dmSaveProcWindowNodispIdle( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 8U ) != 0U || main_work.announce_flag != 0U )
        {
            main_work.win_timer = 0;
            for ( uint num = 0U; num < 4U; num += 1U )
            {
                if ( ( main_work.announce_flag & 1U << ( int )num ) != 0U )
                {
                    AppMain.dm_save_win_mode = ( main_work.win_mode = ( int )num );
                    break;
                }
            }
            if ( main_work.win_mode == 0 )
            {
                AppMain.DmCmnBackupLoad();
                main_work.proc_input = null;
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowOpenWaitLoadIdle );
            }
            else if ( main_work.win_mode == 1 )
            {
                main_work.proc_input = new AppMain._saveproc_input_update( AppMain.dmSaveInputProcWindow );
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowOpenEfct );
                main_work.proc_draw = new AppMain._saveproc_draw( AppMain.DmSaveWinSelectDraw );
                AppMain.dm_save_draw_reserve = true;
                AppMain.DmSoundPlaySE( "Window" );
            }
            else if ( main_work.win_mode == 2 )
            {
                AppMain.DmCmnBackupSave( AppMain.dm_save_first_save, false, false );
                main_work.proc_input = null;
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowOpenWaitIdle );
                main_work.proc_draw = null;
                AppMain.dm_save_draw_reserve = false;
            }
            else if ( main_work.win_mode == 3 )
            {
                AppMain.DmCmnBackupSave( AppMain.dm_save_first_save, true, false );
                main_work.proc_input = null;
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowOpenWaitIdle );
                main_work.proc_draw = null;
                AppMain.dm_save_draw_reserve = false;
            }
            main_work.flag &= 4294967287U;
            return;
        }
        main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcStopDraw );
        AppMain.dm_save_draw_reserve = false;
    }

    // Token: 0x0600098F RID: 2447 RVA: 0x0005609D File Offset: 0x0005429D
    private static void dmSaveProcWindowOpenWaitLoadIdle( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.AoStorageIsExecuteReal() )
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowOpenEfct );
            main_work.proc_draw = new AppMain._saveproc_draw( AppMain.DmSaveWinSelectDraw );
            AppMain.DmSoundPlaySE( "Window" );
            AppMain.dm_save_draw_reserve = true;
        }
    }

    // Token: 0x06000990 RID: 2448 RVA: 0x000560DA File Offset: 0x000542DA
    private static void dmSaveProcWindowOpenWaitIdle( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.AoStorageSaveFreeSpaceIsEnough() )
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowOpenEfct );
            main_work.proc_draw = new AppMain._saveproc_draw( AppMain.DmSaveWinSelectDraw );
            AppMain.DmSoundPlaySE( "Window" );
            AppMain.dm_save_draw_reserve = true;
        }
    }

    // Token: 0x06000991 RID: 2449 RVA: 0x00056118 File Offset: 0x00054318
    private static void dmSaveProcWindowOpenEfct( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 16U ) != 0U )
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowAnnounceIdle );
            main_work.disp_flag |= 1U;
            AppMain.dm_save_disp_flag = main_work.disp_flag;
            main_work.flag &= 4294967279U;
            return;
        }
        AppMain.dmSaveSetWinOpenEfct( main_work );
    }

    // Token: 0x06000992 RID: 2450 RVA: 0x00056174 File Offset: 0x00054374
    private static void dmSaveProcWindowAnnounceIdle( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( main_work.win_mode == 0 )
        {
            if ( AppMain.DmCmnBackupIsLoadFinished() )
            {
                main_work.win_timer = 8;
                if ( main_work.timer >= 60 )
                {
                    main_work.disp_flag &= 4294967294U;
                    AppMain.dm_save_disp_flag = main_work.disp_flag;
                    main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowCloseEfct );
                    main_work.timer = 0;
                }
            }
            else if ( AppMain.AoSysMsgIsShow() )
            {
                main_work.win_timer = 8;
                main_work.disp_flag &= 4294967294U;
                AppMain.dm_save_disp_flag = main_work.disp_flag;
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowCloseEfct );
                main_work.timer = 0;
            }
            else if ( !AppMain.AoStorageIsExecuteReal() )
            {
                main_work.timer = 0;
            }
        }
        else if ( main_work.win_mode == 1 )
        {
            if ( ( main_work.flag & 4U ) != 0U )
            {
                main_work.proc_input = null;
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowCloseEfct );
                main_work.win_timer = 8;
                main_work.disp_flag &= 4294967294U;
                AppMain.DmSoundPlaySE( "Ok" );
                main_work.flag &= 4294967291U;
                main_work.timer = 0;
            }
        }
        else if ( main_work.win_mode == 2 )
        {
            if ( AppMain.DmCmnBackupIsSaveFinished() )
            {
                main_work.win_timer = 8;
                if ( main_work.timer >= 60 )
                {
                    main_work.proc_input = null;
                    main_work.disp_flag &= 4294967294U;
                    main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowCloseEfct );
                    main_work.timer = 0;
                }
            }
            else if ( !AppMain.AoStorageIsExecuteReal() )
            {
                main_work.timer = 0;
            }
        }
        else if ( main_work.win_mode == 3 )
        {
            if ( AppMain.DmCmnBackupIsSaveFinished() )
            {
                main_work.win_timer = 8;
                if ( main_work.timer >= 60 )
                {
                    main_work.proc_input = null;
                    main_work.disp_flag &= 4294967294U;
                    main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowCloseEfct );
                    main_work.timer = 0;
                }
            }
            else if ( !AppMain.AoStorageIsExecuteReal() )
            {
                main_work.timer = 0;
            }
        }
        else
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowCloseEfct );
            main_work.disp_flag &= 4294967294U;
        }
        AppMain.dm_save_disp_flag = main_work.disp_flag;
        main_work.timer++;
    }

    // Token: 0x06000993 RID: 2451 RVA: 0x000563C4 File Offset: 0x000545C4
    private static void dmSaveProcWindowCloseEfct( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 16U ) != 0U )
        {
            if ( main_work.win_mode == 1 )
            {
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWaitSeStop );
            }
            else if ( main_work.win_mode == 0 )
            {
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWaitLoadEnd );
            }
            else
            {
                main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowNodispIdle );
            }
            main_work.announce_flag &= ~( 1U << main_work.win_mode );
            main_work.flag &= 4294967279U;
            main_work.proc_draw = null;
            AppMain.dm_save_draw_reserve = false;
        }
        AppMain.dmSaveSetWinCloseEfct( main_work );
    }

    // Token: 0x06000994 RID: 2452 RVA: 0x00056465 File Offset: 0x00054665
    private static void dmSaveProcWaitSeStop( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( main_work.timer > 60 )
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowNodispIdle );
            main_work.timer = 0;
            return;
        }
        main_work.timer++;
    }

    // Token: 0x06000995 RID: 2453 RVA: 0x00056499 File Offset: 0x00054699
    private static void dmSaveProcWaitLoadEnd( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.DmCmnBackupIsLoadFinished() )
        {
            main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcWindowNodispIdle );
            main_work.timer = 0;
        }
    }

    // Token: 0x06000996 RID: 2454 RVA: 0x000564BB File Offset: 0x000546BB
    private static void dmSaveProcStopDraw( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcDataRelease );
    }

    // Token: 0x06000997 RID: 2455 RVA: 0x000564D0 File Offset: 0x000546D0
    private static void dmSaveProcDataRelease( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexRelease( main_work.cmn_tex[i] );
        }
        if ( AppMain.dm_save_is_snd_build )
        {
            AppMain.DmSoundExit();
            AppMain.DmSoundFlush();
        }
        main_work.proc_menu_update = new AppMain._saveproc_input_update( AppMain.dmSaveProcFinish );
    }

    // Token: 0x06000998 RID: 2456 RVA: 0x0005651C File Offset: 0x0005471C
    private static void dmSaveProcFinish( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.dmSaveIsTexRelease( main_work ) == 1 )
        {
            for ( int i = 0; i < 2; i++ )
            {
                AppMain.dm_save_cmn_tex[i] = null;
            }
            for ( int j = 0; j < 6; j++ )
            {
                if ( main_work.act[j] != null )
                {
                    AppMain.AoActDelete( main_work.act[j] );
                    main_work.act[j] = null;
                }
                AppMain.dm_save_act[j] = null;
            }
            for ( int k = 0; k < 2; k++ )
            {
                if ( main_work.arc_cmn_amb[k] != null )
                {
                    main_work.arc_cmn_amb[k] = null;
                }
            }
            main_work.flag |= 1U;
            main_work.proc_menu_update = null;
        }
    }

    // Token: 0x06000999 RID: 2457 RVA: 0x000565B0 File Offset: 0x000547B0
    private static void dmSaveInputProcWindow( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( AppMain.AoAccountGetCurrentId() < 0 )
        {
            if ( AppMain.AoPadSomeoneStand( ( ushort )AppMain.GSD_KEY_DECIDE ) >= 0 )
            {
                main_work.flag |= 4U;
                return;
            }
        }
        else if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_DECIDE ) != 0 )
        {
            main_work.flag |= 4U;
        }
    }

    // Token: 0x0600099A RID: 2458 RVA: 0x00056600 File Offset: 0x00054800
    private static void DmSaveWinSelectDraw()
    {
        AppMain.AoActSysSetDrawTaskPrio( 61439U );
        int num;
        int num2;
        if ( ( AppMain.dm_save_msg_flag & 2U ) != 0U )
        {
            num = 749;
            num2 = ( int )( ( 180f + ( float )AppMain.dm_save_win_size_y_tbl[AppMain.GsEnvGetLanguage()] ) * 1.6875f );
        }
        else
        {
            if ( !AppMain.AoStorageIsExecuteReal() )
            {
                return;
            }
            if ( AppMain.GsEnvGetLanguage() == 4 )
            {
                num = 749;
                num2 = 303;
            }
            else
            {
                num = 641;
                num2 = 303;
            }
        }
        uint tex_id;
        if ( AppMain.dm_save_is_task_draw )
        {
            tex_id = 1U;
        }
        else if ( ( AppMain.dm_save_msg_flag & 2U ) != 0U )
        {
            tex_id = 1U;
        }
        else
        {
            tex_id = 0U;
        }
        if ( AppMain.dm_save_is_draw_state != 0U )
        {
            AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( AppMain.dm_save_cmn_tex[0] ), tex_id, 480f, 356f, ( float )num * AppMain.dm_save_win_size_rate[0], ( float )num2 * AppMain.dm_save_win_size_rate[1], AppMain.dm_save_draw_state );
        }
        else
        {
            AppMain.AoWinSysDrawTask( 0, AppMain.AoTexGetTexList( AppMain.dm_save_cmn_tex[0] ), tex_id, 480f, 356f, ( float )num * AppMain.dm_save_win_size_rate[0], ( float )num2 * AppMain.dm_save_win_size_rate[1] * 0.9f, 61439 );
        }
        if ( ( AppMain.dm_save_disp_flag & 1U ) != 0U )
        {
            switch ( AppMain.dm_save_win_mode )
            {
                case 0:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_save_cmn_tex[1] ) );
                    AppMain.AoActSortRegAction( AppMain.dm_save_act[2] );
                    break;
                case 1:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_save_cmn_tex[1] ) );
                    AppMain.AoActSortRegAction( AppMain.dm_save_act[3] );
                    AppMain.AoActSortRegAction( AppMain.dm_save_act[5] );
                    break;
                case 2:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_save_cmn_tex[1] ) );
                    AppMain.AoActSortRegAction( AppMain.dm_save_act[4] );
                    break;
                case 3:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_save_cmn_tex[1] ) );
                    AppMain.AoActSortRegAction( AppMain.dm_save_act[4] );
                    break;
            }
            AppMain.AoActAcmPush();
            int num3;
            if ( AppMain.GsEnvGetLanguage() != 0 )
            {
                num3 = AppMain.dm_save_win_size_y_tbl[AppMain.GsEnvGetLanguage()] / 2;
            }
            else
            {
                num3 = 0;
            }
            for ( int i = 0; i < 6; i++ )
            {
                AppMain.AOS_TEXTURE tex;
                if ( i >= 1 )
                {
                    tex = AppMain.dm_save_cmn_tex[1];
                }
                else
                {
                    tex = AppMain.dm_save_cmn_tex[0];
                }
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( AppMain.dm_save_win_act_pos_tbl[i][0], AppMain.dm_save_win_act_pos_tbl[i][1], 0f );
                if ( ( AppMain.dm_save_msg_flag & 2U ) != 0U )
                {
                    if ( i == 5 )
                    {
                        AppMain.AoActAcmApplyTrans( 0f, 16f + ( float )num3, 0f );
                    }
                    else if ( i == 0 || i == 1 )
                    {
                        AppMain.AoActAcmApplyTrans( -32f, ( float )( num3 * -1 ), 0f );
                    }
                }
                AppMain.AoActAcmApplyScale( 1.6875f, 1.6875f );
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
                AppMain.AoActUpdate( AppMain.dm_save_act[i], 0f );
            }
            AppMain.AoActAcmPop();
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
            AppMain.AoActSortUnregAll();
        }
        if ( AppMain.dm_save_is_draw_state != 0U && AppMain.dm_save_is_task_draw )
        {
            AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmSaveTaskDraw ), 61439, 0U );
        }
    }

    // Token: 0x0600099B RID: 2459 RVA: 0x000568D7 File Offset: 0x00054AD7
    private static void dmSaveTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( AppMain.dm_save_draw_state );
        AppMain.amDrawEndScene();
    }

    // Token: 0x0600099C RID: 2460 RVA: 0x000568F0 File Offset: 0x00054AF0
    private static int dmSaveIsDataLoad( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_cmn_amb_fs[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x0600099D RID: 2461 RVA: 0x0005691C File Offset: 0x00054B1C
    private static int dmSaveIsTexLoad( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.cmn_tex[i] ) )
            {
                return 0;
            }
        }
        if ( AppMain.dm_save_is_snd_build && !AppMain.DmSoundBuildCheck() )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x0600099E RID: 2462 RVA: 0x00056958 File Offset: 0x00054B58
    private static int dmSaveIsTexRelease( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.cmn_tex[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x0600099F RID: 2463 RVA: 0x00056984 File Offset: 0x00054B84
    private static void dmSaveSetWinOpenEfct( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        if ( main_work.win_timer > 8 )
        {
            main_work.flag |= 16U;
            main_work.win_timer = 0;
            for ( uint num = 0U; num < 2U; num += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 1f;
            }
        }
        else
        {
            main_work.win_timer++;
        }
        for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
        {
            if ( main_work.win_timer != 0 )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = ( float )main_work.win_timer / 8f;
            }
            else
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
            if ( main_work.win_size_rate[( int )( ( UIntPtr )num2 )] > 1f )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
            AppMain.dm_save_win_size_rate[( int )( ( UIntPtr )num2 )] = main_work.win_size_rate[( int )( ( UIntPtr )num2 )];
        }
    }

    // Token: 0x060009A0 RID: 2464 RVA: 0x00056A44 File Offset: 0x00054C44
    private static void dmSaveSetWinCloseEfct( AppMain.DMS_SAVE_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( main_work.win_timer != 0 )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = ( float )main_work.win_timer / 8f;
            }
            else
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 0f;
            }
            AppMain.dm_save_win_size_rate[( int )( ( UIntPtr )num )] = main_work.win_size_rate[( int )( ( UIntPtr )num )];
        }
        if ( main_work.win_timer < 0 )
        {
            main_work.flag |= 16U;
            main_work.win_timer = 0;
            for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 0f;
                AppMain.dm_save_win_size_rate[( int )( ( UIntPtr )num2 )] = main_work.win_size_rate[( int )( ( UIntPtr )num2 )];
            }
            return;
        }
        main_work.win_timer--;
    }
}
