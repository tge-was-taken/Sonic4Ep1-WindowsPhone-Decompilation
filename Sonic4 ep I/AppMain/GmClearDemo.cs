using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using er;
using gs.backup;

public partial class AppMain
{
    // Token: 0x06000E14 RID: 3604 RVA: 0x0007C054 File Offset: 0x0007A254
    private static void GmClearDemoBuild()
    {
        int num = AppMain.GsEnvGetLanguage();
        if ( num >= 1 )
        {
            num = 2 * num;
        }
        AppMain.gm_clrdm_mgr.Clear();
        AppMain.gm_clrdm_mgr_p = AppMain.gm_clrdm_mgr;
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.gm_clrdm_tex[i].Clear();
        }
        AppMain.gm_clrdm_amb[0] = AppMain.readAMBFile( AppMain.ObjDataLoadAmbIndex( null, 31, AppMain.g_gm_gamedat_cockpit_main_arc ) );
        AppMain.gm_clrdm_amb[1] = AppMain.readAMBFile( AppMain.ObjDataLoadAmbIndex( null, AppMain.g_gm_clear_demo_data_amb_id[AppMain.GsEnvGetLanguage()], AppMain.g_gm_gamedat_cockpit_main_arc ) );
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexBuild( AppMain.gm_clrdm_tex[i], AppMain.gm_clrdm_amb[i] );
            AppMain.AoTexLoad( AppMain.gm_clrdm_tex[i] );
        }
    }

    // Token: 0x06000E15 RID: 3605 RVA: 0x0007C107 File Offset: 0x0007A307
    private static bool GmClearDemoBuildCheck()
    {
        return AppMain.gmClearDemoIsTexLoad();
    }

    // Token: 0x06000E16 RID: 3606 RVA: 0x0007C114 File Offset: 0x0007A314
    private static void GmClearDemoFlush()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexRelease( AppMain.gm_clrdm_tex[i] );
        }
    }

    // Token: 0x06000E17 RID: 3607 RVA: 0x0007C139 File Offset: 0x0007A339
    private static bool GmClearDemoFlushCheck()
    {
        return AppMain.gmClearDemoIsTexRelease();
    }

    // Token: 0x06000E18 RID: 3608 RVA: 0x0007C145 File Offset: 0x0007A345
    private static void GmClearDemoStart()
    {
        AppMain.gmClearDemoInit();
    }

    // Token: 0x06000E19 RID: 3609 RVA: 0x0007C14C File Offset: 0x0007A34C
    private static void GmClearDemoExit()
    {
        if ( AppMain.gm_clrdm_mgr_p.tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_clrdm_mgr_p.tcb );
            AppMain.gm_clrdm_mgr_p.tcb = null;
        }
    }

    // Token: 0x06000E1A RID: 3610 RVA: 0x0007C174 File Offset: 0x0007A374
    private static bool GmClearDemoIsExit()
    {
        return AppMain.gm_clrdm_mgr_p.tcb == null;
    }

    // Token: 0x06000E1B RID: 3611 RVA: 0x0007C185 File Offset: 0x0007A385
    private static void GmClearDemoRetryStart()
    {
        AppMain.gmClearDemoRetryInit();
    }

    // Token: 0x06000E1C RID: 3612 RVA: 0x0007C194 File Offset: 0x0007A394
    private static void gmClearDemoInit()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(AppMain.gmClearDemoProcMain), new AppMain.GSF_TASK_PROCEDURE(AppMain.gmClearDemoDest), 0U, 0, 18448U, 5, () => new AppMain.GMS_CLRDM_MAIN_WORK(), "CLRDM_MAIN");
        AppMain.gm_clrdm_mgr_p.tcb = mts_TASK_TCB;
        AppMain.GMS_CLRDM_MAIN_WORK gms_CLRDM_MAIN_WORK = (AppMain.GMS_CLRDM_MAIN_WORK)mts_TASK_TCB.work;
        for ( int i = 0; i < 2; i++ )
        {
            gms_CLRDM_MAIN_WORK.tex[i] = AppMain.gm_clrdm_tex[i];
        }
        gms_CLRDM_MAIN_WORK.trg_retry.Constructor();
        gms_CLRDM_MAIN_WORK.trg_back.Constructor();
        gms_CLRDM_MAIN_WORK.count = 1;
        gms_CLRDM_MAIN_WORK.stage_id = gss_MAIN_SYS_INFO.stage_id;
        gms_CLRDM_MAIN_WORK.game_mode = gss_MAIN_SYS_INFO.game_mode;
        if ( gms_CLRDM_MAIN_WORK.stage_id <= 20 )
        {
            gms_CLRDM_MAIN_WORK.is_clear_spe_stg = false;
            AppMain.gmClearDemoSetPlayGameScore( gms_CLRDM_MAIN_WORK );
        }
        else
        {
            gms_CLRDM_MAIN_WORK.is_clear_spe_stg = true;
            AppMain.gmClearDemoSetSpecialStageScore( gms_CLRDM_MAIN_WORK );
            AppMain.gmClearDemoSetSpecialStageClearInfo( gms_CLRDM_MAIN_WORK );
        }
        AppMain.gmClearDemoSetSaveScoreData( gms_CLRDM_MAIN_WORK );
        if ( gms_CLRDM_MAIN_WORK.stage_id >= 21 && gms_CLRDM_MAIN_WORK.stage_id < 29 )
        {
            if ( gms_CLRDM_MAIN_WORK.game_mode == 0 )
            {
                AppMain.gmClearDemoCreateObjSpeScore( gms_CLRDM_MAIN_WORK );
                AppMain.gmClearDemoCreateObjSpecialScoreAtk( gms_CLRDM_MAIN_WORK );
                AppMain.gmClearDemoSetInitDispAct( gms_CLRDM_MAIN_WORK );
            }
            else
            {
                AppMain.gmClearDemoCreateObjSpeTime( gms_CLRDM_MAIN_WORK );
                AppMain.gmClearDemoCreateObjSpecialTimeAtk( gms_CLRDM_MAIN_WORK );
            }
        }
        else if ( gms_CLRDM_MAIN_WORK.game_mode == 0 )
        {
            AppMain.gmClearDemoCreateObjActScore( gms_CLRDM_MAIN_WORK );
            AppMain.gmClearDemoCreateObjAct( gms_CLRDM_MAIN_WORK );
            AppMain.gmClearDemoSetInitDispAct( gms_CLRDM_MAIN_WORK );
        }
        else
        {
            AppMain.gmClearDemoCreateObjActTime( gms_CLRDM_MAIN_WORK );
            AppMain.gmClearDemoCreateObjNormalTimeAtk( gms_CLRDM_MAIN_WORK );
        }
        if ( gss_MAIN_SYS_INFO.stage_id >= 16 && gss_MAIN_SYS_INFO.stage_id <= 20 )
        {
            AppMain.GmSoundPlayClearFinal();
        }
        else
        {
            AppMain.GmSoundPlayClear();
        }
        AppMain.gmClearDemoSetMainUpdateProc( gms_CLRDM_MAIN_WORK );
    }

    // Token: 0x06000E1D RID: 3613 RVA: 0x0007C31C File Offset: 0x0007A51C
    private static void gmClearDemoRetryInit()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(AppMain.gmClearDemoProcMain), new AppMain.GSF_TASK_PROCEDURE(AppMain.gmClearDemoDest), 0U, 0, 18448U, 5, () => new AppMain.GMS_CLRDM_MAIN_WORK(), "CLRDM_MAIN");
        AppMain.gm_clrdm_mgr_p.tcb = mts_TASK_TCB;
        AppMain.GMS_CLRDM_MAIN_WORK gms_CLRDM_MAIN_WORK = (AppMain.GMS_CLRDM_MAIN_WORK)mts_TASK_TCB.work;
        for ( int i = 0; i < 2; i++ )
        {
            gms_CLRDM_MAIN_WORK.tex[i] = AppMain.gm_clrdm_tex[i];
        }
        gms_CLRDM_MAIN_WORK.trg_retry.Constructor();
        gms_CLRDM_MAIN_WORK.trg_back.Constructor();
        gms_CLRDM_MAIN_WORK.count = 1;
        gms_CLRDM_MAIN_WORK.stage_id = gss_MAIN_SYS_INFO.stage_id;
        if ( gms_CLRDM_MAIN_WORK.stage_id >= 21 )
        {
            gms_CLRDM_MAIN_WORK.is_clear_spe_stg = true;
        }
        else
        {
            gms_CLRDM_MAIN_WORK.is_clear_spe_stg = false;
        }
        gms_CLRDM_MAIN_WORK.game_mode = gss_MAIN_SYS_INFO.game_mode;
        AppMain.gmClearDemoCreateObjActTime( gms_CLRDM_MAIN_WORK );
        AppMain.gmClearDemoCreateObjNormalTimeAtk( gms_CLRDM_MAIN_WORK );
        AppMain.gmClearDemoSetRetryInitAct( gms_CLRDM_MAIN_WORK );
        gms_CLRDM_MAIN_WORK.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcRetryStart );
    }

    // Token: 0x06000E1E RID: 3614 RVA: 0x0007C41C File Offset: 0x0007A61C
    private static void gmClearDemoSetMainUpdateProc( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.stage_id >= 21 )
        {
            if ( main_work.game_mode == 0 )
            {
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScoreMoveEfct );
                return;
            }
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeMoveEfct );
            AppMain.gmClearDemoSetClearTimeRecord( main_work );
            AppMain.gmClearDemoSetSortBufTimeAct( main_work );
            main_work.tex_new_record_act.obj_2d.speed = 0f;
            return;
        }
        else
        {
            if ( main_work.game_mode == 0 )
            {
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcMoveEfct );
                return;
            }
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcTimeMoveEfct );
            AppMain.gmClearDemoSetClearTimeRecord( main_work );
            AppMain.gmClearDemoSetSortBufTimeAct( main_work );
            main_work.tex_new_record_act.obj_2d.speed = 0f;
            return;
        }
    }

    // Token: 0x06000E1F RID: 3615 RVA: 0x0007C4D0 File Offset: 0x0007A6D0
    private static void gmClearDemoSetPlayGameScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        gss_MAIN_SYS_INFO.clear_score = AppMain.gmClearDemoGetScore();
        gss_MAIN_SYS_INFO.clear_time = ( int )AppMain.gmClearDemoGetGameTime();
        gss_MAIN_SYS_INFO.clear_ring = ( uint )AppMain.gmClearDemoGetRingNum();
        main_work.time_score[0] = 0U;
        main_work.time_score[1] = AppMain.gmClearDemoGetTimeScore( gss_MAIN_SYS_INFO.clear_time );
        main_work.ring_score[0] = 0U;
        main_work.ring_score[1] = gss_MAIN_SYS_INFO.clear_ring * 100U;
        if ( main_work.ring_score[1] > 99900U )
        {
            main_work.ring_score[1] = 99900U;
        }
        main_work.total_score[1] = gss_MAIN_SYS_INFO.clear_score;
        main_work.total_score[0] = main_work.total_score[1] + main_work.ring_score[1] + main_work.time_score[1];
        if ( main_work.total_score[0] > 999999990U )
        {
            main_work.total_score[0] = 999999990U;
        }
    }

    // Token: 0x06000E20 RID: 3616 RVA: 0x0007C5A4 File Offset: 0x0007A7A4
    private static void gmClearDemoSetSaveScoreData( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        SSystem ssystem = SSystem.CreateInstance();
        if ( main_work.stage_id >= 21 )
        {
            SSpecial sspecial = SSpecial.CreateInstance();
            uint num = (uint)(main_work.stage_id - 21);
            AppMain.GMM_MAIN_GOAL_AS_SUPER_SONIC();
            if ( gss_MAIN_SYS_INFO.game_mode == 0 )
            {
                uint num2;
                if ( main_work.total_score[0] >= 10U )
                {
                    num2 = main_work.total_score[0];
                }
                else
                {
                    num2 = 0U;
                }
                if ( ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U && !main_work.is_first_spe_clear )
                {
                    AppMain.GmPlayerStockGet( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )], 1 );
                }
                int index = (int)(main_work.stage_id - 4);
                bool flag = LiveFeature.getInstance().saveLeaderBoardScore(index, (int)num2);
                sspecial[( int )num].SetHighScoreUploaded( flag );
                if ( flag && !sspecial[( int )num].IsScoreUploadedOnce() )
                {
                    sspecial[( int )num].SetScoreUploadedOnce( true );
                }
                if ( ( sspecial[( int )num].GetHighScore() < num2 || sspecial[( int )num].GetHighScore() == 1000000000U ) && ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U )
                {
                    sspecial[( int )num].SetHighScore( num2 );
                    main_work.flag |= 32768U;
                }
            }
            else if ( gss_MAIN_SYS_INFO.game_mode == 1 )
            {
                if ( ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U && !main_work.is_first_spe_clear )
                {
                    AppMain.GmPlayerStockGet( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )], 1 );
                }
                bool flag2 = false;
                if ( ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U )
                {
                    int index2 = (int)(main_work.stage_id - 4 + 24);
                    flag2 = LiveFeature.getInstance().saveLeaderBoardScore( index2, gss_MAIN_SYS_INFO.clear_time );
                    sspecial[( int )num].SetFastTimeUploaded( flag2 );
                }
                if ( flag2 && !sspecial[( int )num].IsTimeUploadedOnce() )
                {
                    sspecial[( int )num].SetTimeUploadedOnce( true );
                }
                if ( ( sspecial[( int )num].GetFastTime() < ( uint )gss_MAIN_SYS_INFO.clear_time || sspecial[( int )num].GetFastTime() == 36000U ) && ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U )
                {
                    sspecial[( int )num].SetFastTime( ( uint )gss_MAIN_SYS_INFO.clear_time );
                    main_work.flag |= 4096U;
                }
            }
        }
        else
        {
            SStage sstage = SStage.CreateInstance();
            uint num = (uint)main_work.stage_id;
            if ( num > 16U && num <= 20U )
            {
                num = 16U;
            }
            bool flag3 = AppMain.GMM_MAIN_USE_SUPER_SONIC();
            if ( AppMain.GMM_MAIN_GOAL_AS_SUPER_SONIC() )
            {
                sstage[( int )num].SetUseSuperSonicOnce( true );
            }
            if ( gss_MAIN_SYS_INFO.game_mode == 0 )
            {
                uint num2;
                if ( main_work.total_score[0] >= 10U )
                {
                    num2 = main_work.total_score[0];
                }
                else
                {
                    num2 = 0U;
                }
                if ( sstage[( int )num].GetHighScore( false ) == 1000000000U )
                {
                    AppMain.g_gs_main_sys_info.is_first_play = true;
                }
                else
                {
                    AppMain.g_gs_main_sys_info.is_first_play = false;
                }
                if ( sstage[( int )num].GetHighScore( flag3 ) < num2 || sstage[( int )num].GetHighScore( flag3 ) == 1000000000U )
                {
                    sstage[( int )num].SetHighScore( num2, flag3 );
                }
                int index3 = (int)num;
                bool flag4 = LiveFeature.getInstance().saveLeaderBoardScore(index3, (int)num2);
                sstage[( int )num].SetHighScoreUploaded( flag3, flag4 );
                if ( flag4 && !sstage[( int )num].IsScoreUploadedOnce() )
                {
                    sstage[( int )num].SetScoreUploadedOnce( true );
                }
                if ( ( AppMain.g_gm_main_system.game_flag & 16384U ) != 0U )
                {
                    AppMain.g_gs_main_sys_info.prev_stage_id = AppMain.g_gs_main_sys_info.stage_id;
                }
                else
                {
                    AppMain.g_gs_main_sys_info.prev_stage_id = ushort.MaxValue;
                }
            }
            else if ( gss_MAIN_SYS_INFO.game_mode == 1 && ( sstage[( int )num].GetFastTime( flag3 ) > ( uint )gss_MAIN_SYS_INFO.clear_time || sstage[( int )num].GetFastTime( flag3 ) == 36000U ) )
            {
                if ( flag3 )
                {
                    if ( sstage[( int )num].GetFastTime( false ) > ( uint )gss_MAIN_SYS_INFO.clear_time || sstage[( int )num].GetFastTime( false ) == 36000U )
                    {
                        main_work.flag |= 4096U;
                    }
                }
                else if ( sstage[( int )num].GetFastTime( true ) > ( uint )gss_MAIN_SYS_INFO.clear_time || sstage[( int )num].GetFastTime( true ) == 36000U )
                {
                    main_work.flag |= 4096U;
                }
                sstage[( int )num].SetFastTime( ( uint )gss_MAIN_SYS_INFO.clear_time, flag3 );
                int index4 = (int)(num + 24U);
                bool flag5 = LiveFeature.getInstance().saveLeaderBoardScore(index4, gss_MAIN_SYS_INFO.clear_time);
                sstage[( int )num].SetFastTimeUploaded( flag3, flag5 );
                if ( flag5 && !sstage[( int )num].IsTimeUploadedOnce() )
                {
                    sstage[( int )num].SetTimeUploadedOnce( true );
                }
            }
        }
        ssystem.SetKilled( gss_MAIN_SYS_INFO.ene_kill_count );
        ssystem.SetPlayerStock( gss_MAIN_SYS_INFO.rest_player_num );
        if ( gss_MAIN_SYS_INFO.stage_id >= 16 && gss_MAIN_SYS_INFO.stage_id <= 20 )
        {
            AppMain.HgTrophyIncFinalClearCount();
            ssystem.SetClearCount( gss_MAIN_SYS_INFO.final_clear_count );
        }
        AppMain.HgTrophyTryAcquisition( 4 );
    }

    // Token: 0x06000E21 RID: 3617 RVA: 0x0007CA90 File Offset: 0x0007AC90
    private static void gmClearDemoSetClearTimeRecord( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        main_work.clear_time = ( uint )gss_MAIN_SYS_INFO.clear_time;
        AppMain.AkUtilFrame60ToTime( main_work.clear_time, ref main_work.time_min, ref main_work.time_sec, ref main_work.time_msec );
        main_work.record_time_num_act[0].obj_2d.speed = 0f;
        main_work.record_time_num_act[2].obj_2d.speed = 0f;
        main_work.record_time_num_act[3].obj_2d.speed = 0f;
        main_work.record_time_num_act[5].obj_2d.speed = 0f;
        main_work.record_time_num_act[6].obj_2d.speed = 0f;
        main_work.record_time_num_act[1].obj_2d.speed = 0f;
        main_work.record_time_num_act[4].obj_2d.speed = 0f;
        for ( int i = 0; i < 7; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.record_time_num_act[i];
            obs_OBJECT_WORK.disp_flag &= 4294967263U;
        }
    }

    // Token: 0x06000E22 RID: 3618 RVA: 0x0007CB98 File Offset: 0x0007AD98
    private static void gmClearDemoSetSpecialStageScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        gss_MAIN_SYS_INFO.clear_score = AppMain.gmClearDemoGetScore();
        gss_MAIN_SYS_INFO.clear_time = ( int )AppMain.gmClearDemoGetGameTime();
        gss_MAIN_SYS_INFO.clear_ring = ( uint )AppMain.gmClearDemoGetRingNum();
        main_work.time_score[0] = 0U;
        main_work.time_score[1] = AppMain.gmClearDemoGetTimeSpeScore( gss_MAIN_SYS_INFO.clear_time );
        main_work.ring_score[0] = 0U;
        main_work.ring_score[1] = gss_MAIN_SYS_INFO.clear_ring * 100U;
        if ( main_work.ring_score[1] > 99900U )
        {
            main_work.ring_score[1] = 99900U;
        }
        main_work.total_score[1] = gss_MAIN_SYS_INFO.clear_score;
        main_work.total_score[0] = main_work.total_score[1] + main_work.ring_score[1] + main_work.time_score[1];
        if ( main_work.total_score[0] > 999999990U )
        {
            main_work.total_score[0] = 999999990U;
        }
    }

    // Token: 0x06000E23 RID: 3619 RVA: 0x0007CC6C File Offset: 0x0007AE6C
    private static void gmClearDemoSetSpecialStageClearInfo( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        ushort num;
        if ( AppMain.g_gs_main_sys_info.prev_stage_id != 65535 )
        {
            num = AppMain.g_gs_main_sys_info.prev_stage_id;
        }
        else
        {
            num = ushort.MaxValue;
        }
        SSpecial sspecial = SSpecial.CreateInstance();
        uint num2 = (uint)(main_work.stage_id - 21);
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 32U ) != 0U )
        {
            main_work.is_full_eme = true;
        }
        if ( ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U )
        {
            main_work.is_get_eme = true;
            if ( !sspecial[( int )num2].IsGetEmerald() && num != 65535 )
            {
                sspecial[( int )num2].SetEmeraldStage( ( EEmeraldStage.Type )AppMain.dm_clrdm_spe_stg_get_act_no[( int )num] );
                main_work.is_first_spe_clear = true;
            }
            main_work.get_eme_no = ( int )num2;
            if ( AppMain.g_gs_main_sys_info.stage_id == 27 )
            {
                AppMain.g_gs_main_sys_info.game_flag |= 32U;
            }
            main_work.has_eme_num = ( int )( num2 + 1U );
            for ( int i = 7; i > 0; i-- )
            {
                if ( sspecial[i - 1].IsGetEmerald() )
                {
                    main_work.has_eme_num = i;
                    return;
                }
            }
            return;
        }
        main_work.is_get_eme = false;
        main_work.get_eme_no = -1;
        for ( int j = 7; j > 0; j-- )
        {
            if ( sspecial[j - 1].IsGetEmerald() )
            {
                main_work.has_eme_num = j;
                return;
            }
        }
    }

    // Token: 0x06000E24 RID: 3620 RVA: 0x0007CDA4 File Offset: 0x0007AFA4
    private static uint gmClearDemoGetTimeScore( int clear_time )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        uint result = 0U;
        ushort num = 0;
        ushort num2 = 0;
        ushort num3 = 0;
        AppMain.AkUtilFrame60ToTime( ( uint )clear_time, ref num, ref num2, ref num3 );
        int num4 = (int)(num * 60 + num2);
        for ( int i = 0; i < 9; i++ )
        {
            if ( num4 < AppMain.dm_clrdm_clear_time_sec_tbl[( int )gss_MAIN_SYS_INFO.stage_id][i] )
            {
                result = AppMain.dm_clrdm_clear_time_score_tbl[i];
                break;
            }
        }
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 8U ) != 0U )
        {
            result = 0U;
        }
        return result;
    }

    // Token: 0x06000E25 RID: 3621 RVA: 0x0007CE1C File Offset: 0x0007B01C
    private static uint gmClearDemoGetTimeSpeScore( int clear_time )
    {
        ushort num = 0;
        ushort num2 = 0;
        ushort num3 = 0;
        AppMain.AkUtilFrame60ToTime( ( uint )clear_time, ref num, ref num2, ref num3 );
        int num4 = (int)(num * 60 + num2);
        uint result = (uint)(num4 * 100);
        if ( ( AppMain.g_gm_main_system.game_flag & 131072U ) != 0U )
        {
            result = 0U;
        }
        if ( ( AppMain.g_gm_main_system.game_flag & 262144U ) != 0U )
        {
            result = 0U;
        }
        return result;
    }

    // Token: 0x06000E26 RID: 3622 RVA: 0x0007CE78 File Offset: 0x0007B078
    private static void gmClearDemoSetInitDispAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        for ( int i = 0; i < 5; i++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i];
            obs_OBJECT_WORK.disp_flag |= 32U;
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        for ( int i = 0; i < 9; i++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        for ( int i = 0; i < 3; i++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act2;
        obs_OBJECT_WORK.disp_flag |= 32U;
    }

    // Token: 0x06000E27 RID: 3623 RVA: 0x0007CF58 File Offset: 0x0007B158
    private static void gmClearDemoProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_CLRDM_MAIN_WORK gms_CLRDM_MAIN_WORK = (AppMain.GMS_CLRDM_MAIN_WORK)tcb.work;
        if ( ( gms_CLRDM_MAIN_WORK.flag & 1U ) != 0U )
        {
            if ( AppMain.gm_clrdm_mgr_p.tcb != null )
            {
                AppMain.mtTaskClearTcb( AppMain.gm_clrdm_mgr_p.tcb );
                AppMain.gm_clrdm_mgr_p.tcb = null;
            }
            if ( gms_CLRDM_MAIN_WORK.stage_id < 21 )
            {
                if ( ( AppMain.g_gm_main_system.game_flag & 16384U ) != 0U )
                {
                    AppMain.g_gs_main_sys_info.prev_stage_id = AppMain.g_gs_main_sys_info.stage_id;
                    AppMain.DmCmnBackupSave( false, false, false );
                }
                else
                {
                    AppMain.g_gs_main_sys_info.prev_stage_id = ushort.MaxValue;
                }
            }
            if ( ( gms_CLRDM_MAIN_WORK.flag & 16384U ) != 0U )
            {
                gms_CLRDM_MAIN_WORK.flag &= 4294950911U;
            }
            AppMain.g_gm_main_system.game_flag |= 16U;
            if ( ( gms_CLRDM_MAIN_WORK.flag & 8192U ) != 0U )
            {
                AppMain.g_gm_main_system.game_flag |= 2U;
                gms_CLRDM_MAIN_WORK.flag &= 4294959103U;
            }
            return;
        }
        if ( gms_CLRDM_MAIN_WORK.proc_update != null )
        {
            gms_CLRDM_MAIN_WORK.proc_update( gms_CLRDM_MAIN_WORK );
        }
    }

    // Token: 0x06000E28 RID: 3624 RVA: 0x0007D067 File Offset: 0x0007B267
    private static void gmClearDemoDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06000E29 RID: 3625 RVA: 0x0007D06C File Offset: 0x0007B26C
    private static void gmClearDemoProcMoveEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.AoActIsEndTrs( main_work.tex_total_act.obj_2d.act ) )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcPrevCalcScore );
            AppMain.amFlagOn( ref main_work.flag, 32U );
            AppMain.amFlagOn( ref main_work.flag, 512U );
        }
        if ( AppMain.AoActIsEndTrs( main_work.tex_time_act.obj_2d.act ) )
        {
            AppMain.amFlagOn( ref main_work.flag, 128U );
        }
        if ( AppMain.AoActIsEndTrs( main_work.tex_ring_act.obj_2d.act ) )
        {
            AppMain.amFlagOn( ref main_work.flag, 256U );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E2A RID: 3626 RVA: 0x0007D120 File Offset: 0x0007B320
    private static void gmClearDemoProcPrevCalcScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.timer += ( float )main_work.count;
        if ( main_work.timer > 150f )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcCalcScore );
            main_work.proc_calc_score = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoSetCalcScore );
            main_work.timer = 0f;
        }
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            AppMain.amFlagOn( ref main_work.flag, 4U );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E2B RID: 3627 RVA: 0x0007D1B0 File Offset: 0x0007B3B0
    private static void gmClearDemoProcCalcScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.timer += ( float )main_work.count;
        if ( ( main_work.flag & 4U ) != 0U || ( main_work.flag & 8U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcWaitDispSonic );
            main_work.time_score[1] = main_work.time_score[0];
            main_work.ring_score[1] = main_work.ring_score[0];
            main_work.total_score[1] = main_work.total_score[0];
            main_work.proc_calc_score = null;
            AppMain.amFlagOff( ref main_work.flag, 4U );
            AppMain.amFlagOff( ref main_work.flag, 8U );
            if ( main_work.total_score[1] >= 10000U )
            {
                AppMain.amFlagOn( ref main_work.flag, 16U );
                main_work.idle_time = 270;
            }
            else
            {
                main_work.idle_time = 120;
            }
            AppMain.HgTrophyTryAcquisition( 0 );
            main_work.timer = 0f;
        }
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            AppMain.amFlagOn( ref main_work.flag, 4U );
        }
        if ( main_work.proc_calc_score != null && main_work.timer > 1f )
        {
            main_work.proc_calc_score( main_work );
            main_work.timer = 0f;
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        if ( main_work.proc_calc_score == null )
        {
            AppMain.GmSoundPlaySE( "Result2" );
            return;
        }
        if ( 0f == main_work.timer )
        {
            AppMain.GmSoundPlaySE( "Result1" );
        }
    }

    // Token: 0x06000E2C RID: 3628 RVA: 0x0007D314 File Offset: 0x0007B514
    private static void gmClearDemoProcWaitDispSonic( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.timer >= 60f )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcDispIdle );
            main_work.timer = 0f;
            if ( ( main_work.flag & 16U ) != 0U )
            {
                AppMain.GmSoundPlayJingle( 0U );
                AppMain.GmPlayerStockGet( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )], 1 );
            }
            return;
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E2D RID: 3629 RVA: 0x0007D398 File Offset: 0x0007B598
    private static void gmClearDemoProcDispIdle( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.timer >= ( float )main_work.idle_time )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcFadeOut );
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
        }
        if ( ( main_work.flag & 16U ) != 0U )
        {
            AppMain.gmClearDemoSetFlashSonic( main_work );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E2E RID: 3630 RVA: 0x0007D40C File Offset: 0x0007B60C
    private static void gmClearDemoProcFadeOut( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcFinish );
            main_work.timer = 0f;
            return;
        }
        if ( ( main_work.flag & 16U ) != 0U )
        {
            AppMain.gmClearDemoSetFlashSonic( main_work );
        }
        if ( main_work.game_mode == 0 )
        {
            AppMain.gmClearDemoSetSortBufAct( main_work );
            AppMain.gmClearDemoSetScoreData( main_work );
            AppMain.gmClearDemoUpdateAct( main_work );
        }
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E2F RID: 3631 RVA: 0x0007D480 File Offset: 0x0007B680
    private static void gmClearDemoProcFinish( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.proc_update = null;
        main_work.trg_retry.Release();
        main_work.trg_retry.Destructor();
        main_work.trg_back.Release();
        main_work.trg_back.Destructor();
        AppMain.amFlagOn( ref main_work.flag, 1U );
    }

    // Token: 0x06000E30 RID: 3632 RVA: 0x0007D4CC File Offset: 0x0007B6CC
    private static void gmClearDemoProcTimeMoveEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.AoActIsEndTrs( main_work.tex_big_time_act.obj_2d.act ) )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcTimeWaitTimeEfct );
            for ( int i = 0; i < 7; i++ )
            {
                AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i], main_work.record_time_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 49 + i ), 0 );
                ( ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i] ).scale.x = 4096;
                ( ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i] ).scale.y = 4096;
            }
            AppMain.gmClearDemoSetClearTimeRecord( main_work );
            AppMain.gmClearDemoSetSortBufTimeAct( main_work );
            AppMain.amFlagOn( ref main_work.flag, 1024U );
            AppMain.amFlagOn( ref main_work.flag, 2048U );
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E31 RID: 3633 RVA: 0x0007D5BC File Offset: 0x0007B7BC
    private static void gmClearDemoProcTimeWaitTimeEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.timer > 60f )
        {
            if ( ( main_work.flag & 4096U ) != 0U )
            {
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcTimeMoveNewRecord );
                main_work.tex_new_record_act.obj_2d.speed = 1f;
                main_work.idle_time = 180;
            }
            else
            {
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcTimeDispEffect );
                main_work.idle_time = 120;
            }
            AppMain.HgTrophyTryAcquisition( 0 );
            main_work.timer = 0f;
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        if ( main_work.timer > 120f )
        {
            return;
        }
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E32 RID: 3634 RVA: 0x0007D671 File Offset: 0x0007B871
    private static void gmClearDemoProcTimeMoveNewRecord( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.AoActIsEndTrs( main_work.tex_new_record_act.obj_2d.act ) )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcTimeDispEffect );
            AppMain.GmSoundPlayJingle( 5U );
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E33 RID: 3635 RVA: 0x0007D6B0 File Offset: 0x0007B8B0
    private static void gmClearDemoProcTimeDispEffect( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.timer += ( float )main_work.count;
        if ( AppMain.amTpIsTouchPush( 0 ) )
        {
            main_work.flag |= 4U;
        }
        if ( main_work.timer > ( float )main_work.idle_time || ( main_work.flag & 4U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcChangeRetryOut );
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            main_work.timer = 0f;
            main_work.flag &= 4294967291U;
        }
        AppMain.gmClearDemoTimeFlushEffect( main_work );
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
    }

    // Token: 0x06000E34 RID: 3636 RVA: 0x0007D744 File Offset: 0x0007B944
    private static void gmClearDemoProcRetryStart( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcChangeRetryOut );
        AppMain.IzFadeInitEasy( 0U, 1U, 32f );
        main_work.timer = 0f;
    }

    // Token: 0x06000E35 RID: 3637 RVA: 0x0007D770 File Offset: 0x0007B970
    private static void gmClearDemoProcChangeRetryOut( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            if ( main_work.nodisp_check )
            {
                AppMain.IzFadeInitEasy( 0U, 0U, 32f );
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcChangeRetryIn );
                main_work.nodisp_check = false;
                return;
            }
            AppMain.gmClearDemoSetRetryDispInfo( main_work );
            AppMain.gmClearDemoSetRetrySortBufAct( main_work );
            main_work.nodisp_check = true;
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
    }

    // Token: 0x06000E36 RID: 3638 RVA: 0x0007D7CB File Offset: 0x0007B9CB
    private static void gmClearDemoProcChangeRetryIn( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcWaitSelectRetry );
        }
    }

    // Token: 0x06000E37 RID: 3639 RVA: 0x0007D7E8 File Offset: 0x0007B9E8
    private static void gmClearDemoProcWaitSelectRetry( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.gmClearDemoSetBgColorBlack();
        AppMain.gmClearDemoSetRetryInput( main_work );
        if ( ( main_work.flag & 4U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcWaitRetrySonicRunEfct );
            AppMain.GmPlySeqChangeTRetryAcc( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
            return;
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcFadeOut );
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
        }
    }

    // Token: 0x06000E38 RID: 3640 RVA: 0x0007D858 File Offset: 0x0007BA58
    private static void gmClearDemoProcWaitRetrySonicRunEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.gmClearDemoSetBgColorBlack();
        if ( AppMain.ObjObjectViewOutCheck( AppMain.g_gm_main_system.ply_work[0].obj_work ) != 0 )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcFadeOut );
            main_work.flag |= 8192U;
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
        }
    }

    // Token: 0x06000E39 RID: 3641 RVA: 0x0007D8B4 File Offset: 0x0007BAB4
    private static void gmClearDemoSetRetryInput( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.isBackKeyPressed() )
        {
            main_work.flag |= 2U;
            AppMain.setBackKeyRequest( false );
            AppMain.GmSoundPlaySE( "Ok" );
            return;
        }
        CTrgAoAction trg_retry = main_work.trg_retry;
        trg_retry.Update();
        if ( trg_retry.GetState( 0U )[10] && trg_retry.GetState( 0U )[1] )
        {
            main_work.flag |= 4U;
            int i = 0;
            int num = AppMain.arrayof(main_work.btn_retry);
            while ( i < num )
            {
                main_work.btn_retry[i].obj_2d.frame = 2f;
                main_work.btn_retry[i].obj_2d.speed = 1f;
                i++;
            }
            AppMain.GmSoundPlaySE( "Ok" );
        }
        else if ( trg_retry.GetState( 0U )[0] )
        {
            int j = 0;
            int num2 = AppMain.arrayof(main_work.btn_retry);
            while ( j < num2 )
            {
                main_work.btn_retry[j].obj_2d.frame = 1f;
                j++;
            }
        }
        else if ( trg_retry.GetState( 0U )[13] )
        {
            int k = 0;
            int num3 = AppMain.arrayof(main_work.btn_retry);
            while ( k < num3 )
            {
                main_work.btn_retry[k].obj_2d.frame = 0f;
                k++;
            }
        }
        CTrgAoAction trg_back = main_work.trg_back;
        trg_back.Update();
        if ( trg_back.GetState( 0U )[10] && trg_back.GetState( 0U )[1] )
        {
            main_work.flag |= 2U;
            int l = 0;
            int num4 = AppMain.arrayof(main_work.btn_back);
            while ( l < num4 )
            {
                main_work.btn_back[l].obj_2d.frame = 2f;
                main_work.btn_back[l].obj_2d.speed = 1f;
                l++;
            }
            AppMain.GmSoundPlaySE( "Ok" );
            return;
        }
        if ( trg_back.GetState( 0U )[2] )
        {
            int m = 0;
            int num5 = AppMain.arrayof(main_work.btn_back);
            while ( m < num5 )
            {
                main_work.btn_back[m].obj_2d.frame = 1f;
                m++;
            }
            return;
        }
        if ( trg_back.GetState( 0U )[13] )
        {
            int n = 0;
            int num6 = AppMain.arrayof(main_work.btn_back);
            while ( n < num6 )
            {
                main_work.btn_back[n].obj_2d.frame = 0f;
                n++;
            }
        }
    }

    // Token: 0x06000E3A RID: 3642 RVA: 0x0007DB24 File Offset: 0x0007BD24
    private static void gmClearDemoSetRetryDispInfo( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag |= 65536U;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GmSoundStopStageBGM( 64 );
        AppMain.GmSoundStopJingle( 64 );
        AppMain.GmSoundStopBGMJingle( 64 );
        AppMain.GsSoundStopSe();
        AppMain.GmMapSetDisp( false );
        AppMain.GmFixSetDisp( false );
        AppMain.GmObjSetAllObjectNoDisp();
        AppMain.GmRingGetWork().flag |= 1U;
        AppMain.g_gm_main_system.game_flag |= 8192U;
        AppMain.g_gm_main_system.water_level = ushort.MaxValue;
        AppMain.g_gm_main_system.game_flag &= 4294964223U;
        gms_PLAYER_WORK.obj_work.flag &= 4294967167U;
        gms_PLAYER_WORK.obj_work.disp_flag &= 4294967263U;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        AppMain.ObjCameraSetUserFunc( 0, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.GmCameraFunc ) );
        AppMain.GmCameraScaleSet( 1f, 1f );
        obs_CAMERA.roll = 0;
        gms_PLAYER_WORK.gmk_flag &= 4294934527U;
        gms_PLAYER_WORK.obj_work.pos.x = AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.x );
        gms_PLAYER_WORK.obj_work.pos.y = AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.y * -1f );
        AppMain.GmCamScrLimitSetDirect( new AppMain.GMS_EVE_RECORD_EVENT
        {
            flag = 15,
            left = -96,
            top = -85,
            width = 192,
            height = 112
        }, AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.x ), AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.y * -1f ) );
        AppMain.GmPlySeqChangeTRetryFw( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
        AppMain.GmObjSetObjectNoFunc( 4U );
        AppMain.GmObjSetObjectNoFunc( 8U );
        AppMain.GmObjSetObjectNoFunc( 16U );
        AppMain.GmObjSetObjectNoFunc( 32U );
        AppMain.GmObjSetObjectNoFunc( 64U );
        AppMain.GmObjSetObjectNoFunc( 128U );
        AppMain.GmObjSetObjectNoFunc( 256U );
        AppMain.GMM_PAD_VIB_STOP();
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.tex_retry_act;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_back_slct_act;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.bg_retry;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        AppMain.amFlagOff( ref main_work.flag, 1024U );
        main_work.flag &= 4294966271U;
        for ( int i = 0; i < AppMain.arrayof( main_work.record_time_num_act ); i++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        int j = 0;
        int num = AppMain.arrayof(main_work.btn_retry);
        while ( j < num )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.btn_retry[j];
            obs_OBJECT_WORK.disp_flag &= 4294967263U;
            j++;
        }
        int k = 0;
        int num2 = AppMain.arrayof(main_work.btn_back);
        while ( k < num2 )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.btn_back[k];
            obs_OBJECT_WORK.disp_flag &= 4294967263U;
            k++;
        }
        AppMain.ObjDrawClearNNCommandStateTbl();
        AppMain.ObjDrawSetNNCommandStateTbl( 0U, 1U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 1U, 2U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 2U, 3U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 3U, 5U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 4U, 11U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 5U, 12U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 6U, 9U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 7U, 4U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 8U, 8U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 9U, 7U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 10U, 10U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 11U, 6U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 12U, 0U, true );
    }

    // Token: 0x06000E3B RID: 3643 RVA: 0x0007DED8 File Offset: 0x0007C0D8
    private static void gmClearDemoProcSpeScoreMoveEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.AoActIsEndTrs( main_work.tex_total_act.obj_2d.act ) )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScorePrevCalcScore );
            AppMain.amFlagOn( ref main_work.flag, 32U );
            AppMain.amFlagOn( ref main_work.flag, 512U );
        }
        if ( AppMain.AoActIsEndTrs( main_work.tex_time_act.obj_2d.act ) )
        {
            AppMain.amFlagOn( ref main_work.flag, 128U );
        }
        if ( AppMain.AoActIsEndTrs( main_work.tex_ring_act.obj_2d.act ) )
        {
            AppMain.amFlagOn( ref main_work.flag, 256U );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E3C RID: 3644 RVA: 0x0007DF8C File Offset: 0x0007C18C
    private static void gmClearDemoProcSpeScorePrevCalcScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.timer += ( float )main_work.count;
        if ( main_work.timer > 150f )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScoreCalcScore );
            main_work.proc_calc_score = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoSetCalcScore );
            main_work.timer = 0f;
        }
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            AppMain.amFlagOn( ref main_work.flag, 4U );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E3D RID: 3645 RVA: 0x0007E01C File Offset: 0x0007C21C
    private static void gmClearDemoProcSpeScoreCalcScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.timer += ( float )main_work.count;
        if ( ( main_work.flag & 4U ) != 0U || ( main_work.flag & 8U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScoreWaitDispSonic );
            main_work.time_score[1] = main_work.time_score[0];
            main_work.ring_score[1] = main_work.ring_score[0];
            main_work.total_score[1] = main_work.total_score[0];
            main_work.proc_calc_score = null;
            AppMain.amFlagOff( ref main_work.flag, 4U );
            AppMain.amFlagOff( ref main_work.flag, 8U );
            if ( main_work.total_score[1] >= 10000U )
            {
                AppMain.amFlagOn( ref main_work.flag, 16U );
                main_work.idle_time = 270;
            }
            else
            {
                main_work.idle_time = 120;
            }
            AppMain.HgTrophyTryAcquisition( 0 );
            main_work.timer = 0f;
        }
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            AppMain.amFlagOn( ref main_work.flag, 4U );
        }
        if ( main_work.proc_calc_score != null && main_work.timer > 1f )
        {
            main_work.proc_calc_score( main_work );
            main_work.timer = 0f;
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        if ( main_work.proc_calc_score == null )
        {
            AppMain.GmSoundPlaySE( "Result2" );
            return;
        }
        if ( 0f == main_work.timer )
        {
            AppMain.GmSoundPlaySE( "Result1" );
        }
    }

    // Token: 0x06000E3E RID: 3646 RVA: 0x0007E180 File Offset: 0x0007C380
    private static void gmClearDemoProcSpeScoreWaitDispSonic( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.timer >= 60f )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScoreDispIdle );
            main_work.timer = 0f;
            if ( ( main_work.flag & 16U ) != 0U )
            {
                AppMain.GmSoundPlayJingle( 0U );
                AppMain.GmPlayerStockGet( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )], 1 );
            }
            return;
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E3F RID: 3647 RVA: 0x0007E204 File Offset: 0x0007C404
    private static void gmClearDemoProcSpeScoreDispIdle( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.timer >= ( float )main_work.idle_time )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScoreFadeOut );
            AppMain.IzFadeInitEasy( 0U, 3U, 32f );
        }
        if ( ( main_work.flag & 16U ) != 0U )
        {
            AppMain.gmClearDemoSetFlashSonic( main_work );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E40 RID: 3648 RVA: 0x0007E278 File Offset: 0x0007C478
    private static void gmClearDemoProcSpeScoreFadeOut( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeScoreFinish );
            main_work.timer = 0f;
            return;
        }
        if ( ( main_work.flag & 16U ) != 0U )
        {
            AppMain.gmClearDemoSetFlashSonic( main_work );
        }
        AppMain.gmClearDemoSetSortBufAct( main_work );
        AppMain.gmClearDemoSetScoreData( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E41 RID: 3649 RVA: 0x0007E2E1 File Offset: 0x0007C4E1
    private static void gmClearDemoProcSpeScoreFinish( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.proc_update = null;
        AppMain.amFlagOn( ref main_work.flag, 1U );
    }

    // Token: 0x06000E42 RID: 3650 RVA: 0x0007E2F8 File Offset: 0x0007C4F8
    private static void gmClearDemoProcSpeTimeMoveEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.AoActIsEndTrs( main_work.tex_big_time_act.obj_2d.act ) )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeWaitTimeEfct );
            for ( int i = 0; i < 7; i++ )
            {
                AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i], main_work.record_time_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 49 + i ), 0 );
                ( ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i] ).scale.x = 4096;
                ( ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[i] ).scale.y = 4096;
            }
            AppMain.gmClearDemoSetClearTimeRecord( main_work );
            AppMain.gmClearDemoSetSortBufTimeAct( main_work );
            AppMain.amFlagOn( ref main_work.flag, 1024U );
            AppMain.amFlagOn( ref main_work.flag, 2048U );
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E43 RID: 3651 RVA: 0x0007E3E8 File Offset: 0x0007C5E8
    private static void gmClearDemoProcSpeTimeWaitTimeEfct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.timer > 60f )
        {
            if ( ( main_work.flag & 4096U ) != 0U )
            {
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeTimeMoveNewRecord );
                main_work.tex_new_record_act.obj_2d.speed = 1f;
                main_work.idle_time = 180;
            }
            else
            {
                main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeDispEffect );
                main_work.idle_time = 120;
            }
            AppMain.HgTrophyTryAcquisition( 0 );
            main_work.timer = 0f;
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
        if ( main_work.timer > 120f )
        {
            return;
        }
        main_work.timer += ( float )main_work.count;
    }

    // Token: 0x06000E44 RID: 3652 RVA: 0x0007E49D File Offset: 0x0007C69D
    private static void gmClearDemoProcSpeTimeTimeMoveNewRecord( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.AoActIsEndTrs( main_work.tex_new_record_act.obj_2d.act ) )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeDispEffect );
            AppMain.GmSoundPlayJingle( 5U );
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
        AppMain.gmClearDemoUpdateAct( main_work );
    }

    // Token: 0x06000E45 RID: 3653 RVA: 0x0007E4DC File Offset: 0x0007C6DC
    private static void gmClearDemoProcSpeTimeDispEffect( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        main_work.timer += ( float )main_work.count;
        if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_DECIDE ) != 0 )
        {
            main_work.flag |= 4U;
        }
        if ( main_work.timer > ( float )main_work.idle_time || ( main_work.flag & 4U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeChangeRetryOut );
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            main_work.timer = 0f;
            main_work.flag &= 4294967291U;
        }
        AppMain.gmClearDemoTimeFlushEffect( main_work );
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
    }

    // Token: 0x06000E46 RID: 3654 RVA: 0x0007E578 File Offset: 0x0007C778
    private static void gmClearDemoProcSpeTimeChangeRetryOut( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeChangeRetryIn );
            AppMain.IzFadeInitEasy( 0U, 0U, 32f );
            AppMain.gmClearDemoSetRetryDispInfo( main_work );
            AppMain.gmClearDemoSetRetrySortBufAct( main_work );
            main_work.timer = 0f;
            return;
        }
        AppMain.gmClearDemoSetTimeAtkSortBufAct( main_work );
    }

    // Token: 0x06000E47 RID: 3655 RVA: 0x0007E5C8 File Offset: 0x0007C7C8
    private static void gmClearDemoProcSpeTimeChangeRetryIn( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcSpeTimeWaitSelectRetry );
        }
    }

    // Token: 0x06000E48 RID: 3656 RVA: 0x0007E5E4 File Offset: 0x0007C7E4
    private static void gmClearDemoProcSpeTimeWaitSelectRetry( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.gmClearDemoSetBgColorBlack();
        AppMain.gmClearDemoSetRetryInput( main_work );
        if ( ( main_work.flag & 4U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcWaitRetrySonicRunEfct );
            AppMain.GmPlySeqChangeTRetryAcc( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
            return;
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_update = new AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate( AppMain.gmClearDemoProcFadeOut );
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
        }
    }

    // Token: 0x06000E49 RID: 3657 RVA: 0x0007E65C File Offset: 0x0007C85C
    private static void gmClearDemoCreateObjActScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.TaskWorkFactoryDelegate work_size = () => new AppMain.GMS_COCKPIT_2D_WORK();
        AppMain.OBS_OBJECT_WORK work;
        for ( int i = 0; i < 5; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_UPTEXT" );
            main_work.tex_up_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMENUM" );
            main_work.time_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RINGNUM" );
            main_work.ring_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        for ( int i = 0; i < 9; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TOTALNUM" );
            main_work.total_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        for ( int i = 0; i < 3; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_LINE" );
            main_work.line_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMETEXT" );
        main_work.tex_time_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RINGTEXT" );
        main_work.tex_ring_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TOTALTEXT" );
        main_work.tex_total_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_SONICICON" );
        main_work.sonic_icon_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_SONICICON2" );
        main_work.sonic_icon_act2 = ( AppMain.GMS_COCKPIT_2D_WORK )work;
    }

    // Token: 0x06000E4A RID: 3658 RVA: 0x0007E7D8 File Offset: 0x0007C9D8
    private static void gmClearDemoCreateObjActTime( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.TaskWorkFactoryDelegate work_size = () => new AppMain.GMS_COCKPIT_2D_WORK();
        AppMain.OBS_OBJECT_WORK work;
        for ( int i = 0; i < 5; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_UPTEXT" );
            main_work.tex_up_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMEATK_TEXT" );
        main_work.tex_big_time_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        for ( int j = 0; j < 7; j++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIME_DIGIT_NUM" );
            main_work.record_time_num_act[j] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMEATK_SONIC" );
        main_work.time_sonic_icon_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_NEWRECORD_TEXT" );
        main_work.tex_new_record_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_BG_RETRY" );
        main_work.bg_retry = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RETRY_TEXT" );
        main_work.tex_retry_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_ACT_BACK_TEXT" );
        main_work.tex_back_slct_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        int k = 0;
        int num = AppMain.arrayof(main_work.btn_retry);
        while ( k < num )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RETRY_BTN" );
            main_work.btn_retry[k] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            k++;
        }
        int l = 0;
        int num2 = AppMain.arrayof(main_work.btn_back);
        while ( l < num2 )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_ACT_BACK_BTN" );
            main_work.btn_back[l] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            l++;
        }
    }

    // Token: 0x06000E4B RID: 3659 RVA: 0x0007E980 File Offset: 0x0007CB80
    private static void gmClearDemoCreateObjSpeScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.TaskWorkFactoryDelegate work_size = () => new AppMain.GMS_COCKPIT_2D_WORK();
        AppMain.OBS_OBJECT_WORK work;
        for ( int i = 0; i < 3; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_UP_SPST_TEXT" );
            main_work.tex_spst_up_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        for ( int i = 0; i < 7; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_SPE_STAGE_NO" );
            main_work.spst_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_EMER_UP_ICON" );
            main_work.icon_emer_up_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_EMER_DOWN_ICON" );
            main_work.icon_emer_down_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_LIGHT_EMER" );
        main_work.icon_emer_light_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_EXTEND_TEXT" );
        main_work.tex_extend_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        for ( int i = 0; i < 5; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMENUM" );
            main_work.time_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RINGNUM" );
            main_work.ring_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        for ( int i = 0; i < 9; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TOTALNUM" );
            main_work.total_num_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        for ( int i = 0; i < 3; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_LINE" );
            main_work.line_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMETEXT" );
        main_work.tex_time_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RINGTEXT" );
        main_work.tex_ring_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TOTALTEXT" );
        main_work.tex_total_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_SONICICON" );
        main_work.sonic_icon_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_SONICICON2" );
        main_work.sonic_icon_act2 = ( AppMain.GMS_COCKPIT_2D_WORK )work;
    }

    // Token: 0x06000E4C RID: 3660 RVA: 0x0007EBA8 File Offset: 0x0007CDA8
    private static void gmClearDemoCreateObjSpeTime( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.TaskWorkFactoryDelegate work_size = () => new AppMain.GMS_COCKPIT_2D_WORK();
        AppMain.OBS_OBJECT_WORK work;
        for ( int i = 0; i < 3; i++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_UP_SPST_TEXT" );
            main_work.tex_spst_up_act[i] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        for ( int j = 0; j < 7; j++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_SPE_STAGE_NO" );
            main_work.spst_num_act[j] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_EMER_UP_ICON" );
            main_work.icon_emer_up_act[j] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_EMER_DOWN_ICON" );
            main_work.icon_emer_down_act[j] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_LIGHT_EMER" );
        main_work.icon_emer_light_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMEATK_TEXT" );
        main_work.tex_big_time_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        for ( int k = 0; k < 7; k++ )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIME_DIGIT_NUM" );
            main_work.record_time_num_act[k] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        }
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_TIMEATK_SONIC" );
        main_work.time_sonic_icon_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_NEWRECORD_TEXT" );
        main_work.tex_new_record_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_BG_RETRY" );
        main_work.bg_retry = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RETRY_TEXT" );
        main_work.tex_retry_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_ACT_BACK_TEXT" );
        main_work.tex_back_slct_act = ( AppMain.GMS_COCKPIT_2D_WORK )work;
        int l = 0;
        int num = AppMain.arrayof(main_work.btn_retry);
        while ( l < num )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_RETRY_BTN" );
            main_work.btn_retry[l] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            l++;
        }
        int m = 0;
        int num2 = AppMain.arrayof(main_work.btn_back);
        while ( m < num2 )
        {
            work = AppMain.GMM_COCKPIT_CREATE_WORK( work_size, null, 0, "CLRDM_ACT_BACK_BTN" );
            main_work.btn_back[m] = ( AppMain.GMS_COCKPIT_2D_WORK )work;
            m++;
        }
    }

    // Token: 0x06000E4D RID: 3661 RVA: 0x0007EDD0 File Offset: 0x0007CFD0
    private static void gmClearDemoCreateObjAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.gmClearDemoCreateObjActForStage( main_work );
        for ( int i = 0; i < 5; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i], main_work.time_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 4 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i] ).scale.y = 4096;
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i], main_work.ring_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 9 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i] ).scale.y = 4096;
        }
        for ( int i = 0; i < 9; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i], main_work.total_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 18 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i] ).scale.y = 4096;
        }
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i], main_work.line_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 14 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i] ).scale.y = 4096;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_time_act, main_work.tex_time_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 7U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_time_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_time_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_ring_act, main_work.tex_ring_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 8U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_ring_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_ring_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_total_act, main_work.tex_total_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 9U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_total_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_total_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act, main_work.sonic_icon_act.obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), 17U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act ).scale.y = 4096;
    }

    // Token: 0x06000E4E RID: 3662 RVA: 0x0007F190 File Offset: 0x0007D390
    private static void gmClearDemoCreateObjNormalTimeAtk( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.gmClearDemoCreateObjActForStage( main_work );
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act, main_work.tex_big_time_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 15U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act, main_work.time_sonic_icon_act.obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), 56U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act ).scale.y = 4096;
        main_work.time_sonic_icon_act.obj_2d.frame = ( AppMain.GMM_MAIN_USE_SUPER_SONIC() ? 1f : 0f );
        main_work.time_sonic_icon_act.obj_2d.speed = 0f;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act, main_work.tex_new_record_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 14U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act ).scale.y = 4096;
    }

    // Token: 0x06000E4F RID: 3663 RVA: 0x0007F328 File Offset: 0x0007D528
    private static void gmClearDemoCreateObjSpecialScoreAtk( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[0], main_work.tex_spst_up_act[0].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 11U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[0] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[0] ).scale.y = 4096;
        if ( main_work.is_get_eme && main_work.is_first_spe_clear )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[1], main_work.tex_spst_up_act[1].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 12U, 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[1] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[1] ).scale.y = 4096;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[2], main_work.tex_spst_up_act[2].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 13U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[2] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[2] ).scale.y = 4096;
        AppMain.gmClearDemoCreateObjSpeActForStage( main_work );
        for ( int i = 0; i < main_work.has_eme_num; i++ )
        {
            if ( main_work.is_get_eme && main_work.is_first_spe_clear )
            {
                AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_down_act[i], main_work.icon_emer_down_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 34 + i ), 0 );
                ( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_down_act[i] ).scale.x = 4096;
                ( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_down_act[i] ).scale.y = 4096;
            }
            else
            {
                AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_up_act[i], main_work.icon_emer_up_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 42 + i ), 0 );
                ( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_up_act[i] ).scale.x = 4096;
                ( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_up_act[i] ).scale.y = 4096;
            }
        }
        for ( int i = 0; i < 5; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i], main_work.time_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 57 + i ), 0 );
            main_work.time_num_act[i].obj_2d.ama.act_tbl[( int )( ( UIntPtr )main_work.time_num_act[i].obj_2d.act_id )].mtn.trs_tbl[0].trs_y -= 15f;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.time_num_act[i] ).scale.y = 4096;
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i], main_work.ring_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 62 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.ring_num_act[i] ).scale.y = 4096;
        }
        for ( int i = 0; i < 9; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i], main_work.total_num_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 72 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.total_num_act[i] ).scale.y = 4096;
        }
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i], main_work.line_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 67 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.line_act[i] ).scale.y = 4096;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_time_act, main_work.tex_time_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 18U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_time_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_time_act ).scale.y = 4096;
        main_work.tex_time_act.obj_2d.ama.act_tbl[( int )( ( UIntPtr )main_work.tex_time_act.obj_2d.act_id )].mtn.trs_tbl[0].trs_y -= 15f;
        main_work.tex_time_act.obj_2d.ama.act_tbl[( int )( ( UIntPtr )main_work.tex_time_act.obj_2d.act_id )].mtn.trs_tbl[1].trs_y -= 15f;
        main_work.tex_time_act.obj_2d.ama.act_tbl[( int )( ( UIntPtr )main_work.tex_time_act.obj_2d.act_id )].mtn.trs_tbl[2].trs_y -= 15f;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_ring_act, main_work.tex_ring_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 19U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_ring_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_ring_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_total_act, main_work.tex_total_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 20U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_total_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_total_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act, main_work.sonic_icon_act.obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), 70U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act2, main_work.sonic_icon_act2.obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), 71U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act2 ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.sonic_icon_act2 ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_extend_act, main_work.tex_extend_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 10U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_extend_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_extend_act ).scale.y = 4096;
    }

    // Token: 0x06000E50 RID: 3664 RVA: 0x0007FB64 File Offset: 0x0007DD64
    private static void gmClearDemoCreateObjSpecialTimeAtk( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[0], main_work.tex_spst_up_act[0].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 11U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[0] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[0] ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[2], main_work.tex_spst_up_act[2].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 13U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[2] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[2] ).scale.y = 4096;
        AppMain.gmClearDemoCreateObjSpeActForStage( main_work );
        for ( int i = 0; i < main_work.has_eme_num; i++ )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_up_act[i], main_work.icon_emer_up_act[i].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 42 + i ), 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_up_act[i] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.icon_emer_up_act[i] ).scale.y = 4096;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act, main_work.tex_big_time_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 15U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act ).scale.y = 4096;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act, main_work.time_sonic_icon_act.obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), 56U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act ).scale.y = 4096;
        main_work.time_sonic_icon_act.obj_2d.frame = ( AppMain.GMM_MAIN_USE_SUPER_SONIC() ? 1f : 0f );
        main_work.time_sonic_icon_act.obj_2d.speed = 0f;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act, main_work.tex_new_record_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 14U, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act ).scale.y = 4096;
    }

    // Token: 0x06000E51 RID: 3665 RVA: 0x0007FE70 File Offset: 0x0007E070
    private static void gmClearDemoCreateObjActForStage( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        int num = AppMain.GsEnvGetLanguage();
        ushort num2;
        if ( num == 3 )
        {
            num2 = 84;
        }
        else if ( num == 5 )
        {
            num2 = 85;
        }
        else
        {
            num2 = 0;
        }
        if ( num != 4 )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[0], main_work.tex_up_act[0].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )num2, 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[0] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[0] ).scale.y = 4096;
        }
        ushort id;
        if ( num != 4 )
        {
            id = AppMain.dm_clrdm_stage_tex_act_id[( int )main_work.stage_id];
        }
        else
        {
            id = AppMain.dm_clrdm_stage_ge_tex_act_id[( int )main_work.stage_id];
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[1], main_work.tex_up_act[1].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), ( uint )id, 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[1] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[1] ).scale.y = 4096;
        ushort num3;
        int index;
        if ( AppMain.dm_clrdm_stage_text_amb_id[( int )main_work.stage_id] == 0 )
        {
            num3 = 0;
            index = 30;
        }
        else
        {
            num3 = 1;
            index = AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()];
        }
        if ( num3 == 0 && ( num == 0 || num == 1 ) )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[2], main_work.tex_up_act[2].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 3U, 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[2] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[2] ).scale.y = 4096;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[3], main_work.tex_up_act[3].obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), ( uint )AppMain.dm_clrdm_stage_text_act_id[( int )main_work.stage_id], 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[3] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[3] ).scale.y = 4096;
        if ( num == 4 )
        {
            num2 = AppMain.dm_clrdm_stage_ge_num_act_id[( int )main_work.stage_id];
        }
        else if ( num == 2 )
        {
            num2 = AppMain.dm_clrdm_stage_fr_num_act_id[( int )main_work.stage_id];
        }
        else if ( num == 5 )
        {
            num2 = AppMain.dm_clrdm_stage_sp_num_act_id[( int )main_work.stage_id];
        }
        else if ( num == 3 )
        {
            num2 = AppMain.dm_clrdm_stage_sp_num_act_id[( int )main_work.stage_id];
        }
        else
        {
            num2 = AppMain.dm_clrdm_stage_num_act_id[( int )main_work.stage_id];
        }
        if ( num2 != 65535 )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[4], main_work.tex_up_act[4].obj_2d, null, null, index, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[( int )num3] ), ( uint )num2, 0 );
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[4] ).scale.x = 4096;
            ( ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[4] ).scale.y = 4096;
        }
    }

    // Token: 0x06000E52 RID: 3666 RVA: 0x000801B0 File Offset: 0x0007E3B0
    private static void gmClearDemoCreateObjSpeActForStage( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        int num = AppMain.GsEnvGetLanguage();
        int num2 = (int)(main_work.stage_id - 21);
        int num3;
        if ( num != 3 )
        {
            num3 = 27;
        }
        else
        {
            num3 = 86;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.spst_num_act[num2], main_work.spst_num_act[num2].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( num3 + num2 ), 0 );
        ( ( AppMain.OBS_OBJECT_WORK )main_work.spst_num_act[num2] ).scale.x = 4096;
        ( ( AppMain.OBS_OBJECT_WORK )main_work.spst_num_act[num2] ).scale.y = 4096;
    }

    // Token: 0x06000E53 RID: 3667 RVA: 0x00080250 File Offset: 0x0007E450
    private static void gmClearDemoSetSortBufAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 32U ) == 0U )
        {
            for ( int i = 0; i < 3; i++ )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.line_act[i];
                obs_OBJECT_WORK.disp_flag |= 32U;
            }
        }
        else
        {
            for ( int i = 0; i < 3; i++ )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.line_act[i];
                obs_OBJECT_WORK.disp_flag &= 4294967263U;
            }
        }
        if ( ( main_work.flag & 64U ) == 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.sonic_icon_act;
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        else
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.sonic_icon_act;
            obs_OBJECT_WORK.disp_flag &= 4294967263U;
        }
        AppMain.gmClearDemoSetSortBufScore( main_work );
    }

    // Token: 0x06000E54 RID: 3668 RVA: 0x00080308 File Offset: 0x0007E508
    private static void gmClearDemoSetTimeAtkSortBufAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 1024U ) != 0U )
        {
            for ( int i = 0; i < 7; i++ )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.record_time_num_act[i];
                obs_OBJECT_WORK.disp_flag &= 4294967263U;
            }
        }
        AppMain.gmClearDemoSetSortBufScore( main_work );
    }

    // Token: 0x06000E55 RID: 3669 RVA: 0x00080354 File Offset: 0x0007E554
    private static void gmClearDemoSetRetryInitAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        for ( int i = 0; i < 5; i++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[i];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        for ( int j = 0; j < 7; j++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[j];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        main_work.tex_retry_act.obj_2d.frame = 0f;
        main_work.tex_retry_act.obj_2d.speed = 0f;
        main_work.tex_back_slct_act.obj_2d.frame = 0f;
        main_work.tex_back_slct_act.obj_2d.speed = 0f;
        int k = 0;
        int num = AppMain.arrayof(main_work.btn_retry);
        while ( k < num )
        {
            main_work.btn_retry[k].obj_2d.frame = 0f;
            main_work.btn_retry[k].obj_2d.speed = 0f;
            k++;
        }
        int l = 0;
        int num2 = AppMain.arrayof(main_work.btn_back);
        while ( l < num2 )
        {
            main_work.btn_back[l].obj_2d.frame = 0f;
            main_work.btn_back[l].obj_2d.speed = 0f;
            l++;
        }
    }

    // Token: 0x06000E56 RID: 3670 RVA: 0x000804F0 File Offset: 0x0007E6F0
    private static void gmClearDemoSetRetrySortBufAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        if ( main_work.is_clear_spe_stg )
        {
            for ( int i = 0; i < 3; i++ )
            {
                obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_spst_up_act[i];
                obs_OBJECT_WORK.disp_flag |= 32U;
            }
        }
        else
        {
            for ( int j = 0; j < 5; j++ )
            {
                obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_up_act[j];
                obs_OBJECT_WORK.disp_flag |= 32U;
            }
        }
        for ( int k = 0; k < 7; k++ )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.record_time_num_act[k];
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_big_time_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.time_sonic_icon_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )main_work.tex_new_record_act;
        obs_OBJECT_WORK.disp_flag |= 32U;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.bg_retry, main_work.bg_retry.obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), 99U, 0 );
        int l = 0;
        int num = AppMain.arrayof(main_work.btn_retry);
        while ( l < num )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.btn_retry[l], main_work.btn_retry[l].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 100 + l ), 0 );
            l++;
        }
        int m = 0;
        int num2 = AppMain.arrayof(main_work.btn_back);
        while ( m < num2 )
        {
            AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.btn_back[m], main_work.btn_back[m].obj_2d, null, null, 30, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[0] ), ( uint )( 103 + m ), 0 );
            m++;
        }
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_retry_act, main_work.tex_retry_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 16U, 0 );
        AppMain.ObjObjectAction2dAMALoadSetTexlist( ( AppMain.OBS_OBJECT_WORK )main_work.tex_back_slct_act, main_work.tex_back_slct_act.obj_2d, null, null, AppMain.g_gm_clear_demo_data_ama_id[AppMain.GsEnvGetLanguage()], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( main_work.tex[1] ), 17U, 0 );
        main_work.tex_retry_act.obj_2d.frame = 0f;
        main_work.tex_retry_act.obj_2d.speed = 0f;
        main_work.tex_back_slct_act.obj_2d.frame = 0f;
        main_work.tex_back_slct_act.obj_2d.speed = 0f;
        int n = 0;
        int num3 = AppMain.arrayof(main_work.btn_retry);
        while ( n < num3 )
        {
            main_work.btn_retry[n].obj_2d.frame = 0f;
            main_work.btn_retry[n].obj_2d.speed = 0f;
            n++;
        }
        int num4 = 0;
        int num5 = AppMain.arrayof(main_work.btn_back);
        while ( num4 < num5 )
        {
            main_work.btn_back[num4].obj_2d.frame = 0f;
            main_work.btn_back[num4].obj_2d.speed = 0f;
            num4++;
        }
        CTrgAoAction trg_retry = main_work.trg_retry;
        AppMain.AOS_ACTION act = main_work.btn_retry[1].obj_2d.act;
        trg_retry.Create( act );
        CTrgAoAction trg_back = main_work.trg_back;
        AppMain.AOS_ACTION act2 = main_work.btn_back[1].obj_2d.act;
        trg_back.Create( act2 );
    }

    // Token: 0x06000E57 RID: 3671 RVA: 0x00080874 File Offset: 0x0007EA74
    private static void gmClearDemoSetSortBufScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 128U ) != 0U )
        {
            AppMain.gmClearDemoSetSortBufScoreAct( main_work.time_num_act, main_work.time_score[1], 5U );
        }
        if ( ( main_work.flag & 256U ) != 0U )
        {
            AppMain.gmClearDemoSetSortBufScoreAct( main_work.ring_num_act, main_work.ring_score[1], 5U );
        }
        if ( ( main_work.flag & 512U ) != 0U )
        {
            AppMain.gmClearDemoSetSortBufScoreAct( main_work.total_num_act, main_work.total_score[1], 9U );
        }
    }

    // Token: 0x06000E58 RID: 3672 RVA: 0x000808E8 File Offset: 0x0007EAE8
    private static void gmClearDemoSetSortBufScoreAct( AppMain.GMS_COCKPIT_2D_WORK[] score_act, uint score, uint digits )
    {
        int num = 1;
        if ( score < 10U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
            for ( int i = 0; i < ( int )( digits - 1U ); i++ )
            {
                obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )score_act[i];
                obs_OBJECT_WORK.disp_flag |= 32U;
            }
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )score_act[( int )( ( UIntPtr )( digits - 1U ) )];
            obs_OBJECT_WORK.disp_flag &= 4294967263U;
            return;
        }
        if ( score >= 10U )
        {
            for ( int i = 0; i < ( int )digits; i++ )
            {
                for ( int j = 0; j < ( int )( ( ulong )digits - ( ulong )( ( long )i ) - 1UL ); j++ )
                {
                    num *= 10;
                }
                if ( score < ( uint )num )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)score_act[i];
                    obs_OBJECT_WORK.disp_flag |= 32U;
                }
                else
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)score_act[i];
                    obs_OBJECT_WORK.disp_flag &= 4294967263U;
                }
                num = 1;
            }
        }
    }

    // Token: 0x06000E59 RID: 3673 RVA: 0x000809A4 File Offset: 0x0007EBA4
    private static void gmClearDemoSetSortBufTimeAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        int num;
        if ( main_work.time_sec >= 10 )
        {
            num = ( int )( main_work.time_sec / 10 );
        }
        else
        {
            num = 0;
        }
        int num2;
        if ( main_work.time_msec >= 10 )
        {
            num2 = ( int )( main_work.time_msec / 10 );
        }
        else
        {
            num2 = 0;
        }
        int num3 = (int)(main_work.time_sec % 10);
        int num4 = (int)(main_work.time_msec % 10);
        main_work.record_time_num_act[0].obj_2d.frame = ( float )main_work.time_min;
        main_work.record_time_num_act[2].obj_2d.frame = ( float )num;
        main_work.record_time_num_act[3].obj_2d.frame = ( float )num3;
        main_work.record_time_num_act[5].obj_2d.frame = ( float )num2;
        main_work.record_time_num_act[6].obj_2d.frame = ( float )num4;
        main_work.record_time_num_act[1].obj_2d.frame = 0f;
        main_work.record_time_num_act[4].obj_2d.frame = 0f;
    }

    // Token: 0x06000E5A RID: 3674 RVA: 0x00080A94 File Offset: 0x0007EC94
    private static void gmClearDemoUpdateAct( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
    }

    // Token: 0x06000E5B RID: 3675 RVA: 0x00080A96 File Offset: 0x0007EC96
    private static void gmClearDemoTimeFlushEffect( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
    }

    // Token: 0x06000E5C RID: 3676 RVA: 0x00080A98 File Offset: 0x0007EC98
    private static void gmClearDemoSetCalcScore( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( main_work.ring_score[1] <= 0U && main_work.time_score[1] <= 0U )
        {
            main_work.proc_calc_score = null;
            AppMain.amFlagOn( ref main_work.flag, 8U );
            return;
        }
        if ( main_work.time_score[1] > 0U )
        {
            main_work.time_score[1] -= 100U;
            main_work.total_score[1] += 100U;
        }
        if ( main_work.ring_score[1] > 0U )
        {
            main_work.ring_score[1] -= 100U;
            main_work.total_score[1] += 100U;
        }
    }

    // Token: 0x06000E5D RID: 3677 RVA: 0x00080B4D File Offset: 0x0007ED4D
    private static void gmClearDemoSetScoreData( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        AppMain.gmClearDemoSetDispScore( main_work.time_num_act, main_work.time_score[1], 5U );
        AppMain.gmClearDemoSetDispScore( main_work.ring_num_act, main_work.ring_score[1], 5U );
        AppMain.gmClearDemoSetDispScore( main_work.total_num_act, main_work.total_score[1], 9U );
    }

    // Token: 0x06000E5E RID: 3678 RVA: 0x00080B8C File Offset: 0x0007ED8C
    private static void gmClearDemoSetDispScore( AppMain.GMS_COCKPIT_2D_WORK[] score_act, uint score, uint digits )
    {
        int num = 1;
        for ( int i = 0; i < 1; i++ )
        {
            checked
            {
                score_act[( int )( ( IntPtr )( unchecked(( ulong )( digits - 1U ) - ( ulong )( ( long )i )) ) )].obj_2d.frame = 0f;
                score_act[( int )( ( IntPtr )( unchecked(( ulong )( digits - 1U ) - ( ulong )( ( long )i )) ) )].obj_2d.speed = 0f;
            }
        }
        for ( int i = 1; i < ( int )digits; i++ )
        {
            for ( int j = 0; j < i; j++ )
            {
                num *= 10;
            }
            checked
            {
                if ( score >= ( uint )num )
                {
                    float num2;
                    unchecked
                    {
                        num2 = ( float )( ( ulong )score / ( ulong )( ( long )num ) );
                        num2 = ( float )( ( int )num2 % 10 );
                    }
                    score_act[( int )( ( IntPtr )( unchecked(( ulong )( digits - 1U ) - ( ulong )( ( long )i )) ) )].obj_2d.frame = num2;
                    score_act[( int )( ( IntPtr )( unchecked(( ulong )( digits - 1U ) - ( ulong )( ( long )i )) ) )].obj_2d.speed = 0f;
                }
                else
                {
                    score_act[( int )( ( IntPtr )( unchecked(( ulong )( digits - 1U ) - ( ulong )( ( long )i )) ) )].obj_2d.frame = 0f;
                    score_act[( int )( ( IntPtr )( unchecked(( ulong )( digits - 1U ) - ( ulong )( ( long )i )) ) )].obj_2d.speed = 0f;
                }
                num = 1;
            }
        }
    }

    // Token: 0x06000E5F RID: 3679 RVA: 0x00080C7C File Offset: 0x0007EE7C
    private static void gmClearDemoSetFlashSonic( AppMain.GMS_CLRDM_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 64U ) != 0U )
        {
            if ( main_work.flash_timer >= 30f )
            {
                AppMain.amFlagOff( ref main_work.flag, 64U );
                main_work.flash_timer = 0f;
            }
        }
        else if ( main_work.flash_timer >= 10f )
        {
            AppMain.amFlagOn( ref main_work.flag, 64U );
            main_work.flash_timer = 0f;
        }
        main_work.flash_timer += ( float )main_work.count;
    }

    // Token: 0x06000E60 RID: 3680 RVA: 0x00080CF4 File Offset: 0x0007EEF4
    private static bool gmClearDemoIsTexLoad()
    {
        int num = 0;
        for ( int i = 0; i < 2; i++ )
        {
            if ( AppMain.AoTexIsLoaded( AppMain.gm_clrdm_tex[i] ) )
            {
                num |= 1 << i;
            }
        }
        return num == 3;
    }

    // Token: 0x06000E61 RID: 3681 RVA: 0x00080D30 File Offset: 0x0007EF30
    private static bool gmClearDemoIsTexRelease()
    {
        int num = 0;
        for ( int i = 0; i < 2; i++ )
        {
            if ( AppMain.AoTexIsReleased( AppMain.gm_clrdm_tex[i] ) )
            {
                num |= 1 << i;
            }
        }
        return num == 3;
    }

    // Token: 0x06000E62 RID: 3682 RVA: 0x00080D69 File Offset: 0x0007EF69
    private static short gmClearDemoGetRingNum()
    {
        if ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] != null )
        {
            return AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].ring_num;
        }
        return 0;
    }

    // Token: 0x06000E63 RID: 3683 RVA: 0x00080D8E File Offset: 0x0007EF8E
    private static uint gmClearDemoGetScore()
    {
        if ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] != null )
        {
            return AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].score;
        }
        return 0U;
    }

    // Token: 0x06000E64 RID: 3684 RVA: 0x00080DB4 File Offset: 0x0007EFB4
    private static uint gmClearDemoGetGameTime()
    {
        if ( AppMain.g_gs_main_sys_info.stage_id >= 21 && ( AppMain.g_gm_main_system.game_flag & 65536U ) == 0U )
        {
            return 0U;
        }
        if ( AppMain.g_gm_main_system.game_time >= 35999U )
        {
            return 35999U;
        }
        return AppMain.g_gm_main_system.game_time;
    }

    // Token: 0x06000E65 RID: 3685 RVA: 0x00080E04 File Offset: 0x0007F004
    private static uint gmClearDemoGetChallengeNum()
    {
        return AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )];
    }

    // Token: 0x06000E66 RID: 3686 RVA: 0x00080E13 File Offset: 0x0007F013
    private static void gmClearDemoSetBgColorBlack()
    {
        AppMain.gmClearDemoSetBgColorBlack( null );
    }

    // Token: 0x06000E67 RID: 3687 RVA: 0x00080E1C File Offset: 0x0007F01C
    private static void gmClearDemoSetBgColorBlack( AppMain.AMS_TCB tcb )
    {
        if ( tcb != null )
        {
            AppMain.NNS_RGBA_U8 bgColor = new AppMain.NNS_RGBA_U8(0, 0, 0, byte.MaxValue);
            AppMain.amDrawSetBGColor( bgColor );
            return;
        }
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.gmClearDemoSetBgColorBlack ), 65280 );
    }
}
