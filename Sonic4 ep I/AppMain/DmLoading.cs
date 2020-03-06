using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001C7 RID: 455
    private enum DME_LOADING_DATA_TYPE
    {
        // Token: 0x0400502A RID: 20522
        DME_LOADING_DATA_TYPE_CMN_DATA,
        // Token: 0x0400502B RID: 20523
        DME_LOADING_DATA_TYPE_MAX,
        // Token: 0x0400502C RID: 20524
        DME_LOADING_DATA_TYPE_NONE
    }

    // Token: 0x020001C8 RID: 456
    private enum DME_LOADING_ACT
    {
        // Token: 0x0400502E RID: 20526
        ACT_BG_WHITE,
        // Token: 0x0400502F RID: 20527
        ACT_BG_BOTTOM,
        // Token: 0x04005030 RID: 20528
        ACT_OBI,
        // Token: 0x04005031 RID: 20529
        ACT_RUN,
        // Token: 0x04005032 RID: 20530
        ACT_PERIOD1,
        // Token: 0x04005033 RID: 20531
        ACT_PERIOD2,
        // Token: 0x04005034 RID: 20532
        ACT_PERIOD3,
        // Token: 0x04005035 RID: 20533
        ACT_TEXT_LOAD,
        // Token: 0x04005036 RID: 20534
        ACT_NUM,
        // Token: 0x04005037 RID: 20535
        ACT_NONE
    }

    // Token: 0x020001C9 RID: 457
    public class DMS_LOADING_MAIN_WORK
    {
        // Token: 0x04005038 RID: 20536
        public AppMain.AMS_FS arc_amb;

        // Token: 0x04005039 RID: 20537
        public byte[] ama;

        // Token: 0x0400503A RID: 20538
        public byte[] amb;

        // Token: 0x0400503B RID: 20539
        public AppMain.AOS_TEXTURE tex;

        // Token: 0x0400503C RID: 20540
        public AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[8];

        // Token: 0x0400503D RID: 20541
        public AppMain.DMS_LOADING_MAIN_WORK._proc_update_ proc_update;

        // Token: 0x0400503E RID: 20542
        public AppMain.DMS_LOADING_MAIN_WORK._proc_draw_ proc_draw;

        // Token: 0x0400503F RID: 20543
        public float timer;

        // Token: 0x04005040 RID: 20544
        public uint flag;

        // Token: 0x04005041 RID: 20545
        public float efct_timer;

        // Token: 0x04005042 RID: 20546
        public float sonic_set_frame;

        // Token: 0x04005043 RID: 20547
        public float sonic_pos_x;

        // Token: 0x04005044 RID: 20548
        public float sonic_move_spd;

        // Token: 0x04005045 RID: 20549
        public bool is_maingame_load;

        // Token: 0x04005046 RID: 20550
        public bool is_play_maingame;

        // Token: 0x04005047 RID: 20551
        public uint draw_state;

        // Token: 0x04005048 RID: 20552
        public int lang_id;

        // Token: 0x020001CA RID: 458
        // (Invoke) Token: 0x0600223C RID: 8764
        public delegate void _proc_update_( AppMain.DMS_LOADING_MAIN_WORK work );

        // Token: 0x020001CB RID: 459
        // (Invoke) Token: 0x06002240 RID: 8768
        public delegate void _proc_draw_( AppMain.DMS_LOADING_MAIN_WORK work );
    }

    // Token: 0x020001CC RID: 460
    public class DMS_LOADING_MGR
    {
        // Token: 0x04005049 RID: 20553
        public AppMain.MTS_TASK_TCB tcb;
    }

    // Token: 0x060009BB RID: 2491 RVA: 0x00057148 File Offset: 0x00055348
    private static void DmLoadingBuild( AppMain.AMS_FS arc_amb )
    {
        AppMain.dm_loading_mgr_p = new AppMain.DMS_LOADING_MGR();
        AppMain.dm_loading_tex = new AppMain.AOS_TEXTURE[1];
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.dm_loading_tex[i] = new AppMain.AOS_TEXTURE();
        }
        for ( int i = 0; i < 1; i++ )
        {
            string dir = null;
            AppMain.dm_loading_ama[i] = AppMain.readAMAFile( AppMain.amBindGet( arc_amb, 0, out dir ) );
            dir = null;
            AppMain.dm_loading_amb[i] = AppMain.readAMBFile( AppMain.amBindGet( arc_amb, 1, out dir ) );
            AppMain.dm_loading_amb[i].dir = dir;
        }
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.AoTexBuild( AppMain.dm_loading_tex[i], AppMain.dm_loading_amb[i] );
            AppMain.AoTexLoad( AppMain.dm_loading_tex[i] );
        }
    }

    // Token: 0x060009BC RID: 2492 RVA: 0x000571F6 File Offset: 0x000553F6
    private static bool DmLoadingBuildCheck()
    {
        return AppMain.dmLoadingIsTexLoad() != 0;
    }

    // Token: 0x060009BD RID: 2493 RVA: 0x00057204 File Offset: 0x00055404
    private static void DmLoadingFlush()
    {
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.AoTexRelease( AppMain.dm_loading_tex[i] );
        }
    }

    // Token: 0x060009BE RID: 2494 RVA: 0x00057229 File Offset: 0x00055429
    private static bool DmLoadingFlushCheck()
    {
        if ( AppMain.dmLoadingIsTexRelease() != 0 )
        {
            if ( AppMain.dm_loading_mgr_p != null )
            {
                AppMain.dm_loading_mgr_p = null;
            }
            return true;
        }
        return false;
    }

    // Token: 0x060009BF RID: 2495 RVA: 0x00057242 File Offset: 0x00055442
    private static void DmLoadingStart()
    {
        AppMain.dmLoadingInit();
    }

    // Token: 0x060009C0 RID: 2496 RVA: 0x00057249 File Offset: 0x00055449
    private static bool DmLoadingIsExit()
    {
        return AppMain.dm_loading_mgr_p == null || AppMain.dm_loading_mgr_p.tcb == null;
    }

    // Token: 0x060009C1 RID: 2497 RVA: 0x00057263 File Offset: 0x00055463
    private static void DmLoadingExit()
    {
        if ( AppMain.dm_loading_mgr_p.tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.dm_loading_mgr_p.tcb );
            AppMain.dm_loading_mgr_p.tcb = null;
        }
    }

    // Token: 0x060009C2 RID: 2498 RVA: 0x0005728B File Offset: 0x0005548B
    private static void DmLoadingSetLoadComplete()
    {
        AppMain.dm_loading_check_load_comp = true;
    }

    // Token: 0x060009C3 RID: 2499 RVA: 0x0005729C File Offset: 0x0005549C
    private static void dmLoadingInit()
    {
        AppMain.dm_loading_mgr_p.tcb = AppMain.mtTaskMake( new AppMain.GSF_TASK_PROCEDURE( AppMain.dmLoadingProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.dmLoadingDest ), 0U, 32767, 8192U, 10, () => new AppMain.DMS_LOADING_MAIN_WORK(), "LOADING_MAIN" );
        AppMain.DMS_LOADING_MAIN_WORK dms_LOADING_MAIN_WORK = (AppMain.DMS_LOADING_MAIN_WORK)AppMain.dm_loading_mgr_p.tcb.work;
        dms_LOADING_MAIN_WORK.draw_state = ( AppMain.AoActSysGetDrawStateEnable() ? 1U : 0U );
        AppMain.AoActSysSetDrawStateEnable( dms_LOADING_MAIN_WORK.draw_state == 1U );
        if ( dms_LOADING_MAIN_WORK.draw_state != 0U )
        {
            AppMain.dm_loading_draw_state = AppMain.AoActSysGetDrawState();
        }
        AppMain.dmLoadingSetInitData( dms_LOADING_MAIN_WORK );
        dms_LOADING_MAIN_WORK.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcInit );
    }

    // Token: 0x060009C4 RID: 2500 RVA: 0x00057364 File Offset: 0x00055564
    private static void dmLoadingSetInitData( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        AppMain.dm_loading_check_load_comp = false;
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 6 || cur_evt_id == 9 || cur_evt_id == 11 )
        {
            main_work.is_maingame_load = true;
            main_work.sonic_pos_x = 0f;
        }
        else
        {
            main_work.is_maingame_load = false;
            main_work.sonic_pos_x = 0f;
        }
        main_work.lang_id = AppMain.GsEnvGetLanguage();
    }

    // Token: 0x060009C5 RID: 2501 RVA: 0x000573C4 File Offset: 0x000555C4
    private static void dmLoadingProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOADING_MAIN_WORK dms_LOADING_MAIN_WORK = (AppMain.DMS_LOADING_MAIN_WORK)tcb.work;
        if ( ( dms_LOADING_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.DmLoadingExit();
        }
        if ( dms_LOADING_MAIN_WORK.proc_update != null )
        {
            dms_LOADING_MAIN_WORK.proc_update( dms_LOADING_MAIN_WORK );
        }
        if ( dms_LOADING_MAIN_WORK.proc_draw != null )
        {
            dms_LOADING_MAIN_WORK.proc_draw( dms_LOADING_MAIN_WORK );
        }
    }

    // Token: 0x060009C6 RID: 2502 RVA: 0x00057414 File Offset: 0x00055614
    private static void dmLoadingDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060009C7 RID: 2503 RVA: 0x00057416 File Offset: 0x00055616
    private static void dmLoadingProcInit( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        main_work.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcCreateAct );
    }

    // Token: 0x060009C8 RID: 2504 RVA: 0x0005742C File Offset: 0x0005562C
    private static void dmLoadingProcCreateAct( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 8U; num += 1U )
        {
            AppMain.A2S_AMA_HEADER ama = AppMain.dm_loading_ama[0];
            AppMain.AOS_TEXTURE tex = AppMain.dm_loading_tex[0];
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_loading[( int )( ( UIntPtr )num )] );
        }
        main_work.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcFadeIn );
        main_work.proc_draw = new AppMain.DMS_LOADING_MAIN_WORK._proc_draw_( AppMain.dmLoadingProcActDraw );
        if ( main_work.is_maingame_load )
        {
            AppMain.IzFadeInitEasy( 0U, 0U, 32f );
            return;
        }
        AppMain.IzFadeInitEasy( 0U, 0U, 32f );
    }

    // Token: 0x060009C9 RID: 2505 RVA: 0x000574BC File Offset: 0x000556BC
    private static void dmLoadingProcFadeIn( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcNowLoading );
        }
    }

    // Token: 0x060009CA RID: 2506 RVA: 0x000574DC File Offset: 0x000556DC
    private static void dmLoadingProcNowLoading( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        if ( AppMain.dm_loading_check_load_comp && main_work.timer > 60f )
        {
            main_work.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcAlreadyLoaded );
            main_work.timer = 0f;
            if ( main_work.is_maingame_load )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 3U, 32f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 3U, 32f );
            }
        }
        if ( main_work.sonic_set_frame >= 12f )
        {
            main_work.sonic_set_frame = 0f;
        }
        main_work.sonic_set_frame += 1f;
        main_work.timer += 1f;
    }

    // Token: 0x060009CB RID: 2507 RVA: 0x00057588 File Offset: 0x00055788
    private static void dmLoadingProcAlreadyLoaded( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        if ( main_work.timer > 32f )
        {
            main_work.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcFadeOut );
            main_work.timer = 0f;
        }
        if ( main_work.sonic_set_frame >= 12f )
        {
            main_work.sonic_set_frame = 0f;
        }
        main_work.sonic_pos_x += 50f;
        main_work.sonic_set_frame += 1f;
        main_work.timer += 1f;
    }

    // Token: 0x060009CC RID: 2508 RVA: 0x0005760D File Offset: 0x0005580D
    private static void dmLoadingProcFadeOut( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_LOADING_MAIN_WORK._proc_update_( AppMain.dmLoadingProcStopDraw );
            main_work.proc_draw = null;
        }
    }

    // Token: 0x060009CD RID: 2509 RVA: 0x00057630 File Offset: 0x00055830
    private static void dmLoadingProcStopDraw( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 8; i++ )
        {
            if ( main_work.act[i] != null )
            {
                AppMain.AoActDelete( main_work.act[i] );
                main_work.act[i] = null;
            }
        }
        main_work.proc_update = null;
        main_work.flag |= 1U;
    }

    // Token: 0x060009CE RID: 2510 RVA: 0x0005767E File Offset: 0x0005587E
    private static void dmLoadingProcActDraw( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        AppMain.dmLoadingCommonDraw( main_work );
        if ( main_work.draw_state != 0U )
        {
            AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmLoadingTaskDraw ), 32768, null );
        }
    }

    // Token: 0x060009CF RID: 2511 RVA: 0x000576A5 File Offset: 0x000558A5
    private static void dmLoadingTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( AppMain.dm_loading_draw_state );
        AppMain.amDrawEndScene();
    }

    // Token: 0x060009D0 RID: 2512 RVA: 0x000576BC File Offset: 0x000558BC
    private static void dmLoadingCommonDraw( AppMain.DMS_LOADING_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_loading_tex[0] ) );
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.AoActSortRegAction( main_work.act[i] );
        }
        AppMain.AoActSetFrame( main_work.act[3], main_work.sonic_set_frame );
        AppMain.AoActSetFrame( main_work.act[7], ( float )main_work.lang_id );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_loading_tex[0] ) );
        for ( int j = 0; j <= 2; j++ )
        {
            AppMain.AoActUpdate( main_work.act[j], 0f );
        }
        AppMain.AoActAcmPush();
        AppMain.AoActAcmInit();
        AppMain.AoActAcmApplyTrans( main_work.sonic_pos_x, -10f, 0f );
        AppMain.AoActUpdate( main_work.act[3], 0f );
        AppMain.AoActAcmPop();
        for ( int k = 4; k <= 6; k++ )
        {
            AppMain.AoActUpdate( main_work.act[k], 1f );
        }
        AppMain.AoActUpdate( main_work.act[7], 0f );
        if ( main_work.lang_id >= 6 )
        {
            main_work.act[7].sprite.tex_id = 9 + main_work.lang_id - 6;
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x060009D1 RID: 2513 RVA: 0x000577F0 File Offset: 0x000559F0
    private static short dmLoadingIsTexLoad()
    {
        for ( int i = 0; i < 1; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( AppMain.dm_loading_tex[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x060009D2 RID: 2514 RVA: 0x0005781C File Offset: 0x00055A1C
    private static short dmLoadingIsTexRelease()
    {
        for ( int i = 0; i < 1; i++ )
        {
            if ( !AppMain.AoTexIsReleased( AppMain.dm_loading_tex[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }
}
