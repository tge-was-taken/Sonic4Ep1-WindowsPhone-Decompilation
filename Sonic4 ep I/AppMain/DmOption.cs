using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using er;
using gs.backup;

public partial class AppMain
{
    // Token: 0x0200022B RID: 555
    public class DMS_OPT_MAIN_WORK
    {
        // Token: 0x0600237F RID: 9087 RVA: 0x00148F40 File Offset: 0x00147140
        public DMS_OPT_MAIN_WORK()
        {
            this.cmn_tex = AppMain.New<AppMain.AOS_TEXTURE>( 5 );
            this.tex = AppMain.New<AppMain.AOS_TEXTURE>( 2 );
            this.trg_slct = AppMain.New<CTrgAoAction>( 4 );
            this.trg_bgm_btn = AppMain.New<CTrgAoAction>( 2 );
            this.trg_se_btn = AppMain.New<CTrgAoAction>( 2 );
            this.trg_ctrl_btn = AppMain.New<CTrgAoAction>( 2 );
            this.ctrl_win_trg_btn = AppMain.New<CTrgAoAction>( 2 );
            this.trg_bgm_slider = new CTrgRect();
            this.trg_se_slider = new CTrgRect();
            this.trg_return = new CTrgAoAction();
        }

        // Token: 0x0400572B RID: 22315
        public AppMain.AMS_FS[] arc_cmn_amb_fs = new AppMain.AMS_FS[5];

        // Token: 0x0400572C RID: 22316
        public AppMain.AMS_AMB_HEADER[] arc_cmn_amb = new AppMain.AMS_AMB_HEADER[5];

        // Token: 0x0400572D RID: 22317
        public AppMain.A2S_AMA_HEADER[] cmn_ama = new AppMain.A2S_AMA_HEADER[5];

        // Token: 0x0400572E RID: 22318
        public AppMain.AMS_AMB_HEADER[] cmn_amb = new AppMain.AMS_AMB_HEADER[5];

        // Token: 0x0400572F RID: 22319
        public AppMain.AOS_TEXTURE[] cmn_tex;

        // Token: 0x04005730 RID: 22320
        public AppMain.AMS_FS[] arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x04005731 RID: 22321
        public AppMain.AMS_FS[] user_arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x04005732 RID: 22322
        public AppMain.AMS_FS[] manual_arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x04005733 RID: 22323
        public AppMain.AMS_AMB_HEADER[] arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005734 RID: 22324
        public AppMain.AMS_AMB_HEADER[] user_arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005735 RID: 22325
        public AppMain.AMS_AMB_HEADER[] manual_arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005736 RID: 22326
        public AppMain.AMS_FS[] win_amb_fs;

        // Token: 0x04005737 RID: 22327
        public AppMain.A2S_AMA_HEADER[] ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x04005738 RID: 22328
        public AppMain.AMS_AMB_HEADER[] amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005739 RID: 22329
        public AppMain.AMS_AMB_HEADER[] win_amb;

        // Token: 0x0400573A RID: 22330
        public AppMain.AOS_TEXTURE[] tex;

        // Token: 0x0400573B RID: 22331
        public AppMain.AOS_TEXTURE win_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x0400573C RID: 22332
        public AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[102];

        // Token: 0x0400573D RID: 22333
        public AppMain.AOS_ACTION bg_icon_node;

        // Token: 0x0400573E RID: 22334
        public AppMain.DMS_OPT_MAIN_WORK._proc_input_ proc_input;

        // Token: 0x0400573F RID: 22335
        public AppMain.DMS_OPT_MAIN_WORK._proc_update_ proc_update;

        // Token: 0x04005740 RID: 22336
        public AppMain.DMS_OPT_MAIN_WORK._proc_draw_ proc_draw;

        // Token: 0x04005741 RID: 22337
        public AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_ proc_menu_draw;

        // Token: 0x04005742 RID: 22338
        public float frm_update_time;

        // Token: 0x04005743 RID: 22339
        public float timer;

        // Token: 0x04005744 RID: 22340
        public float efct_timer;

        // Token: 0x04005745 RID: 22341
        public float win_timer;

        // Token: 0x04005746 RID: 22342
        public float[] push_efct_timer = new float[4];

        // Token: 0x04005747 RID: 22343
        public float vib_timer;

        // Token: 0x04005748 RID: 22344
        public uint flag;

        // Token: 0x04005749 RID: 22345
        public int state;

        // Token: 0x0400574A RID: 22346
        public uint disp_flag;

        // Token: 0x0400574B RID: 22347
        public int next_evt;

        // Token: 0x0400574C RID: 22348
        public int prev_evt;

        // Token: 0x0400574D RID: 22349
        public CTrgAoAction[] trg_slct;

        // Token: 0x0400574E RID: 22350
        public CTrgAoAction trg_return;

        // Token: 0x0400574F RID: 22351
        public int ctrl_mode;

        // Token: 0x04005750 RID: 22352
        public int prev_ctrl_mode;

        // Token: 0x04005751 RID: 22353
        public int[] volume_data = new int[2];

        // Token: 0x04005752 RID: 22354
        public int set_vbrt;

        // Token: 0x04005753 RID: 22355
        public CTrgAoAction[] trg_bgm_btn;

        // Token: 0x04005754 RID: 22356
        public CTrgRect trg_bgm_slider;

        // Token: 0x04005755 RID: 22357
        public CTrgAoAction[] trg_se_btn = new CTrgAoAction[2];

        // Token: 0x04005756 RID: 22358
        public CTrgRect trg_se_slider;

        // Token: 0x04005757 RID: 22359
        public CTrgAoAction[] trg_ctrl_btn = new CTrgAoAction[2];

        // Token: 0x04005758 RID: 22360
        public CTrgAoAction[] ctrl_win_trg_btn = new CTrgAoAction[2];

        // Token: 0x04005759 RID: 22361
        public float ctrl_win_window_prgrs;

        // Token: 0x0400575A RID: 22362
        public int cur_slct_top;

        // Token: 0x0400575B RID: 22363
        public int cur_slct_set;

        // Token: 0x0400575C RID: 22364
        public float top_crsr_pos_y;

        // Token: 0x0400575D RID: 22365
        public float src_crsr_pos_y;

        // Token: 0x0400575E RID: 22366
        public float dst_crsr_pos_y;

        // Token: 0x0400575F RID: 22367
        public float[] ctrl_tab_pos_x = new float[2];

        // Token: 0x04005760 RID: 22368
        public float[] ctrl_tab_pos_y = new float[2];

        // Token: 0x04005761 RID: 22369
        public float[][] ctrl_move_src = AppMain.New<float>(2, 2);

        // Token: 0x04005762 RID: 22370
        public float[][] ctrl_move_dest = AppMain.New<float>(2, 2);

        // Token: 0x04005763 RID: 22371
        public float obi_pos_y;

        // Token: 0x04005764 RID: 22372
        public float[] obi_tex_pos = new float[2];

        // Token: 0x04005765 RID: 22373
        public float set_icon_dir;

        // Token: 0x04005766 RID: 22374
        public float set_icon_shdw_dir;

        // Token: 0x04005767 RID: 22375
        public float[] win_size_rate = new float[2];

        // Token: 0x04005768 RID: 22376
        public uint draw_state;

        // Token: 0x04005769 RID: 22377
        public AppMain.AOS_ACT_COL decide_menu_col = default(AppMain.AOS_ACT_COL);

        // Token: 0x0400576A RID: 22378
        public AppMain.AOS_ACT_COL vol_icon_col = default(AppMain.AOS_ACT_COL);

        // Token: 0x0400576B RID: 22379
        public AppMain.AOS_ACT_COL win_col = default(AppMain.AOS_ACT_COL);

        // Token: 0x0400576C RID: 22380
        public int nrml_disp_type;

        // Token: 0x0400576D RID: 22381
        public int prev_nrml_disp_type;

        // Token: 0x0400576E RID: 22382
        public bool is_jp_region;

        // Token: 0x0400576F RID: 22383
        public AppMain.GSS_SND_SCB bgm_scb;

        // Token: 0x04005770 RID: 22384
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x0200022C RID: 556
        // (Invoke) Token: 0x06002381 RID: 9089
        public delegate void _proc_input_( AppMain.DMS_OPT_MAIN_WORK work );

        // Token: 0x0200022D RID: 557
        // (Invoke) Token: 0x06002385 RID: 9093
        public delegate void _proc_update_( AppMain.DMS_OPT_MAIN_WORK work );

        // Token: 0x0200022E RID: 558
        // (Invoke) Token: 0x06002389 RID: 9097
        public delegate void _proc_draw_( AppMain.DMS_OPT_MAIN_WORK work );

        // Token: 0x0200022F RID: 559
        // (Invoke) Token: 0x0600238D RID: 9101
        public delegate void _proc_menu_draw_( AppMain.DMS_OPT_MAIN_WORK work );
    }

    // Token: 0x02000230 RID: 560
    public class DMS_OPT_MGR
    {
        // Token: 0x06002390 RID: 9104 RVA: 0x0014911A File Offset: 0x0014731A
        public void Clear()
        {
            this.tcb = null;
        }

        // Token: 0x04005771 RID: 22385
        public AppMain.MTS_TASK_TCB tcb;
    }

    // Token: 0x02000231 RID: 561
    private struct SResetLocalTable
    {
        // Token: 0x06002392 RID: 9106 RVA: 0x0014912B File Offset: 0x0014732B
        public SResetLocalTable( int a, int b, int c )
        {
            this.act_idx = a;
            this.act_id = b;
            this.ama_idx = c;
        }

        // Token: 0x04005772 RID: 22386
        public int act_idx;

        // Token: 0x04005773 RID: 22387
        public int act_id;

        // Token: 0x04005774 RID: 22388
        public int ama_idx;
    }

    // Token: 0x06000CB2 RID: 3250 RVA: 0x000704E4 File Offset: 0x0006E6E4
    private static void DmOptionStart( object arg )
    {
        AppMain.dm_opt_mgr.Clear();
        AppMain.dm_opt_mgr_p = AppMain.dm_opt_mgr;
        AppMain.dm_opt_win_tex.Clear();
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 6 || cur_evt_id == 11 )
        {
            AppMain.dm_opt_is_pause_maingame = true;
            AppMain.mtTaskStartPause( 2 );
        }
        else
        {
            AppMain.dm_opt_is_pause_maingame = false;
        }
        AppMain.dm_xbox_show_progress = 0;
        AppMain.dmOptInit();
    }

    // Token: 0x06000CB3 RID: 3251 RVA: 0x00070544 File Offset: 0x0006E744
    private static bool DmOptionIsExit()
    {
        return AppMain.dm_opt_mgr_p == null || AppMain.dm_opt_mgr_p.tcb == null;
    }

    // Token: 0x06000CB4 RID: 3252 RVA: 0x00070568 File Offset: 0x0006E768
    private static void dmOptInit()
    {
        AppMain.dm_opt_mgr_p.tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.dmOptProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.dmOptDest ), 0U, 32767, 8192U, 10, () => new AppMain.DMS_OPT_MAIN_WORK(), "OPT_MAIN" );
        AppMain.DMS_OPT_MAIN_WORK dms_OPT_MAIN_WORK = (AppMain.DMS_OPT_MAIN_WORK)AppMain.dm_opt_mgr_p.tcb.work;
        if ( AppMain.dm_opt_is_pause_maingame )
        {
            dms_OPT_MAIN_WORK.draw_state = ( AppMain.AoActSysGetDrawStateEnable() ? 1U : 0U );
            if ( dms_OPT_MAIN_WORK.draw_state > 0U )
            {
                AppMain.dm_opt_draw_state = AppMain.AoActSysGetDrawState();
            }
        }
        else
        {
            dms_OPT_MAIN_WORK.draw_state = 1U;
            AppMain.dm_opt_draw_state = 0U;
        }
        AppMain.AoActSysSetDrawStateEnable( dms_OPT_MAIN_WORK.draw_state > 0U );
        if ( dms_OPT_MAIN_WORK.draw_state > 0U )
        {
            AppMain.dm_opt_draw_state = AppMain.AoActSysGetDrawState();
        }
        AppMain.dmOptSetInitDispOptionData( dms_OPT_MAIN_WORK );
        dms_OPT_MAIN_WORK.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptLoadFontData );
    }

    // Token: 0x06000CB5 RID: 3253 RVA: 0x00070654 File Offset: 0x0006E854
    private static void dmOptSetSaveOptionData( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        SOption soption = SOption.CreateInstance();
        int volumeBgm = (int)soption.GetVolumeBgm();
        int volumeSe = (int)soption.GetVolumeSe();
        if ( volumeBgm != 0 )
        {
            main_work.volume_data[0] = volumeBgm / 10;
        }
        else
        {
            main_work.volume_data[0] = 0;
        }
        if ( volumeSe != 0 )
        {
            main_work.volume_data[1] = volumeSe / 10;
        }
        else
        {
            main_work.volume_data[1] = 0;
        }
        soption.SetVolumeBgm( ( uint )( main_work.volume_data[0] * 10 ) );
        soption.SetVolumeSe( ( uint )( main_work.volume_data[1] * 10 ) );
    }

    // Token: 0x06000CB6 RID: 3254 RVA: 0x000706D0 File Offset: 0x0006E8D0
    private static void dmOptSetInitDispOptionData( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.GeEnvGetDecideKey() == AppMain.GSE_DECIDE_KEY.GSD_DECIDE_KEY_O )
        {
            main_work.is_jp_region = true;
        }
        else
        {
            main_work.is_jp_region = false;
        }
        main_work.vol_icon_col.r = byte.MaxValue;
        main_work.vol_icon_col.g = byte.MaxValue;
        main_work.vol_icon_col.b = 0;
        main_work.vol_icon_col.a = byte.MaxValue;
        main_work.win_col.r = 0;
        main_work.win_col.g = 0;
        main_work.win_col.b = 0;
        main_work.win_col.a = byte.MaxValue;
        main_work.win_size_rate[0] = 0f;
        main_work.win_size_rate[1] = 0f;
        main_work.ctrl_tab_pos_x[0] = AppMain.dm_opt_ctrl_nrml_disp_pos_tbl[main_work.ctrl_mode][0];
        main_work.ctrl_tab_pos_y[0] = AppMain.dm_opt_ctrl_nrml_disp_pos_tbl[main_work.ctrl_mode][1];
        main_work.ctrl_tab_pos_x[1] = AppMain.dm_opt_ctrl_clsc_disp_pos_tbl[main_work.ctrl_mode][0];
        main_work.ctrl_tab_pos_y[1] = AppMain.dm_opt_ctrl_clsc_disp_pos_tbl[main_work.ctrl_mode][1];
        main_work.decide_menu_col.r = byte.MaxValue;
        main_work.decide_menu_col.g = byte.MaxValue;
        main_work.decide_menu_col.b = byte.MaxValue;
        main_work.decide_menu_col.a = 0;
        main_work.prev_nrml_disp_type = 2;
        main_work.top_crsr_pos_y = 250f;
        main_work.frm_update_time = 1f;
        main_work.obi_tex_pos[0] = 0f;
        main_work.obi_tex_pos[1] = 1120f;
    }

    // Token: 0x06000CB7 RID: 3255 RVA: 0x0007084C File Offset: 0x0006EA4C
    private static void dmOptProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_OPT_MAIN_WORK dms_OPT_MAIN_WORK = (AppMain.DMS_OPT_MAIN_WORK)tcb.work;
        if ( ( dms_OPT_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.mtTaskClearTcb( tcb );
            AppMain.dm_opt_mgr_p = null;
            if ( AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.mtTaskEndPause();
            }
            AppMain.dmOptSetNextEvt( dms_OPT_MAIN_WORK );
        }
        if ( ( dms_OPT_MAIN_WORK.flag & 2147483648U ) > 0U && !AppMain.AoAccountIsCurrentEnable() )
        {
            dms_OPT_MAIN_WORK.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcFadeOut );
            dms_OPT_MAIN_WORK.flag &= 2147483647U;
            dms_OPT_MAIN_WORK.next_evt = 1;
            if ( AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 1U, 1U, 32f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 1U, 1U, 32f );
            }
            AppMain.DmSndBgmPlayerExit();
            dms_OPT_MAIN_WORK.flag |= 1048576U;
            dms_OPT_MAIN_WORK.flag &= 4294967291U;
            dms_OPT_MAIN_WORK.flag &= 4294967293U;
            dms_OPT_MAIN_WORK.proc_input = null;
            dms_OPT_MAIN_WORK.win_timer = 0f;
        }
        if ( dms_OPT_MAIN_WORK.proc_update != null )
        {
            dms_OPT_MAIN_WORK.proc_update( dms_OPT_MAIN_WORK );
        }
        if ( dms_OPT_MAIN_WORK.proc_draw != null )
        {
            dms_OPT_MAIN_WORK.proc_draw( dms_OPT_MAIN_WORK );
        }
    }

    // Token: 0x06000CB8 RID: 3256 RVA: 0x00070972 File Offset: 0x0006EB72
    private static void dmOptDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06000CB9 RID: 3257 RVA: 0x00070974 File Offset: 0x0006EB74
    private static void dmOptSetNextEvt( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        short num;
        if ( ( main_work.flag & 524288U ) != 0U )
        {
            num = 10;
            AppMain.dm_opt_prev_evt = AppMain.SyGetEvtInfo().old_evt_id;
            main_work.flag &= 4294443007U;
        }
        else
        {
            num = AppMain.SyGetEvtInfo().old_evt_id;
            if ( num == 10 )
            {
                num = AppMain.dm_opt_prev_evt;
            }
        }
        if ( num == 3 )
        {
            num = 4;
        }
        if ( main_work.next_evt == 1 )
        {
            num = 3;
        }
        if ( !AppMain.dm_opt_is_pause_maingame )
        {
            AppMain.SyDecideEvt( num );
            AppMain.SyChangeNextEvt();
        }
    }

    // Token: 0x06000CBA RID: 3258 RVA: 0x000709F0 File Offset: 0x0006EBF0
    private static void dmOptLoadFontData( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.GsFontBuild();
        main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptIsLoadFontData );
    }

    // Token: 0x06000CBB RID: 3259 RVA: 0x00070A09 File Offset: 0x0006EC09
    private static void dmOptIsLoadFontData( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.GsFontIsBuilded() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptLoadRequest );
        }
    }

    // Token: 0x06000CBC RID: 3260 RVA: 0x00070A24 File Offset: 0x0006EC24
    private static void dmOptLoadRequest( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        main_work.arc_amb_fs[0] = AppMain.amFsReadBackground( "DEMO/OPTION/D_OPTION.AMB" );
        main_work.arc_amb_fs[1] = AppMain.amFsReadBackground( AppMain.dm_opt_main_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        for ( int i = 0; i < 4; i++ )
        {
            main_work.arc_cmn_amb_fs[i] = AppMain.amFsReadBackground( AppMain.dm_opt_menu_cmn_amb_name_tbl[i] );
        }
        main_work.arc_cmn_amb_fs[4] = AppMain.amFsReadBackground( AppMain.dm_opt_menu_cmn_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        main_work.manual_arc_amb_fs[0] = AppMain.amFsReadBackground( "DEMO/MANUAL/D_MANUAL.AMB" );
        main_work.manual_arc_amb_fs[1] = AppMain.amFsReadBackground( AppMain.dm_opt_manual_file_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcLoadWait );
    }

    // Token: 0x06000CBD RID: 3261 RVA: 0x00070AD0 File Offset: 0x0006ECD0
    private static void dmOptProcLoadWait( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.dmOptIsDataLoad( main_work ) > 0 )
        {
            for ( int i = 0; i < 2; i++ )
            {
                main_work.arc_amb[i] = AppMain.readAMBFile( main_work.arc_amb_fs[i] );
                main_work.ama[i] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_amb[i], 0 ) );
                string dir;
                main_work.amb[i] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_amb[i], 1, out dir ) );
                main_work.amb[i].dir = dir;
                AppMain.amFsClearRequest( main_work.arc_amb_fs[i] );
                main_work.arc_amb_fs[i] = null;
                AppMain.AoTexBuild( main_work.tex[i], main_work.amb[i] );
                AppMain.AoTexLoad( main_work.tex[i] );
            }
            for ( int j = 0; j < 5; j++ )
            {
                main_work.arc_cmn_amb[j] = AppMain.readAMBFile( main_work.arc_cmn_amb_fs[j] );
                main_work.cmn_ama[j] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_cmn_amb[j], 0 ) );
                string dir2;
                main_work.cmn_amb[j] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_cmn_amb[j], 1, out dir2 ) );
                main_work.cmn_amb[j].dir = dir2;
                AppMain.amFsClearRequest( main_work.arc_cmn_amb_fs[j] );
                main_work.arc_cmn_amb_fs[j] = null;
                AppMain.AoTexBuild( main_work.cmn_tex[j], main_work.cmn_amb[j] );
                AppMain.AoTexLoad( main_work.cmn_tex[j] );
            }
            if ( !AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.GsFontBuild();
                AppMain.DmSndBgmPlayerInit();
            }
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcLoadWait2 );
        }
    }

    // Token: 0x06000CBE RID: 3262 RVA: 0x00070C58 File Offset: 0x0006EE58
    private static void dmOptProcLoadWait2( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.dmOptIsTexLoad( main_work ) == 1 )
        {
            for ( int i = 0; i < 2; i++ )
            {
                main_work.manual_arc_amb[i] = AppMain.readAMBFile( main_work.manual_arc_amb_fs[i] );
                AppMain.amFsClearRequest( main_work.manual_arc_amb_fs[i] );
                main_work.manual_arc_amb_fs[i] = null;
            }
            AppMain.DmManualBuild( main_work.manual_arc_amb );
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTexBuildWait );
        }
    }

    // Token: 0x06000CBF RID: 3263 RVA: 0x00070CC4 File Offset: 0x0006EEC4
    private static void dmOptProcTexBuildWait( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.dmOptIsTexLoad2( main_work ) == 1 )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcCheckLoadingEnd );
            if ( !AppMain.dm_opt_is_pause_maingame )
            {
                return;
            }
            main_work.bgm_scb = AppMain.GsSoundAssignScb( 0 );
            main_work.bgm_scb.flag |= 2147483648U;
            main_work.se_handle = AppMain.GsSoundAllocSeHandle();
        }
    }

    // Token: 0x06000CC0 RID: 3264 RVA: 0x00070D24 File Offset: 0x0006EF24
    private static void dmOptProcCheckLoadingEnd( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcCreateAct );
        if ( AppMain.dm_opt_is_pause_maingame )
        {
            AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 0U, 32f, true );
            return;
        }
        AppMain.IzFadeInitEasy( 0U, 0U, 32f );
    }

    // Token: 0x06000CC1 RID: 3265 RVA: 0x00070D74 File Offset: 0x0006EF74
    private static void dmOptProcCreateAct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.A2S_AMA_HEADER ama;
        AppMain.AOS_TEXTURE tex;
        for ( uint num = 0U; num < 102U; num += 1U )
        {
            if ( num >= 101U )
            {
                ama = main_work.cmn_ama[4];
                tex = main_work.cmn_tex[4];
            }
            else if ( num >= 100U )
            {
                ama = main_work.cmn_ama[1];
                tex = main_work.cmn_tex[1];
            }
            else if ( num >= 97U )
            {
                ama = main_work.cmn_ama[0];
                tex = main_work.cmn_tex[0];
            }
            else if ( 1U <= num && num <= 2U )
            {
                ama = main_work.cmn_ama[3];
                tex = main_work.cmn_tex[3];
            }
            else if ( num >= 69U )
            {
                ama = main_work.ama[1];
                tex = main_work.tex[1];
            }
            else
            {
                ama = main_work.ama[0];
                tex = main_work.tex[0];
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_opt[( int )( ( UIntPtr )num )] );
        }
        for ( int i = 0; i < main_work.trg_slct.Length; i++ )
        {
            CTrgAoAction ctrgAoAction = main_work.trg_slct[i];
            ctrgAoAction.Create( main_work.act[3] );
        }
        int j = 0;
        int num2 = main_work.trg_bgm_btn.Length;
        while ( j < num2 )
        {
            int[] array = new int[]
            {
                11,
                10
            };
            CTrgAoAction ctrgAoAction2 = main_work.trg_bgm_btn[j];
            ctrgAoAction2.Create( main_work.act[array[j]] );
            CTrgAoAction ctrgAoAction3 = main_work.trg_se_btn[j];
            ctrgAoAction3.Create( main_work.act[array[j]] );
            j++;
        }
        CTrgRect trg_bgm_slider = main_work.trg_bgm_slider;
        trg_bgm_slider.Create( 42, 70, 426, 124 );
        trg_bgm_slider.SetMoveThreshold( 30 );
        CTrgRect trg_se_slider = main_work.trg_se_slider;
        trg_se_slider.Create( 42, 136, 436, 180 );
        trg_se_slider.SetMoveThreshold( 30 );
        CTrgAoAction trg_return = main_work.trg_return;
        trg_return.Create( main_work.act[2] );
        int k = 0;
        int num3 = main_work.trg_ctrl_btn.Length;
        while ( k < num3 )
        {
            int[] array2 = new int[]
            {
                23,
                26
            };
            CTrgAoAction ctrgAoAction4 = main_work.trg_ctrl_btn[k];
            ctrgAoAction4.Create( main_work.act[array2[k]] );
            k++;
        }
        int l = 0;
        int num4 = main_work.ctrl_win_trg_btn.Length;
        while ( l < num4 )
        {
            int[] array3 = new int[]
            {
                37,
                40
            };
            CTrgAoAction ctrgAoAction5 = main_work.ctrl_win_trg_btn[l];
            ctrgAoAction5.Create( main_work.act[array3[l]] );
            l++;
        }
        ama = main_work.ama[0];
        tex = main_work.tex[0];
        main_work.obi_pos_y = 192f;
        main_work.proc_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_draw_( AppMain.dmOptProcActDraw );
        main_work.proc_menu_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_( AppMain.dmOptTopMenuDraw );
        main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcFadeIn );
        main_work.flag |= 2147483648U;
        if ( !AppMain.dm_opt_is_pause_maingame )
        {
            AppMain.DmSndBgmPlayerPlayBgm( 0 );
            return;
        }
        AppMain.GsSoundPlayBgm( main_work.bgm_scb, "snd_sng_menu", 32 );
    }

    // Token: 0x06000CC2 RID: 3266 RVA: 0x00071075 File Offset: 0x0006F275
    private static void dmOptProcFadeIn( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcTopMenu );
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTopMenuIdle );
        }
    }

    // Token: 0x06000CC3 RID: 3267 RVA: 0x000710A8 File Offset: 0x0006F2A8
    private static void dmOptProcTopMenuIdle( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        CTrgAoAction trg_return = main_work.trg_return;
        float frame = main_work.act[1].frame;
        if ( trg_return.GetState( 0U )[10] && trg_return.GetState( 0U )[1] )
        {
            frame = 2f;
        }
        else if ( trg_return.GetState( 0U )[0] )
        {
            frame = 1f;
        }
        else if ( 2f > main_work.act[1].frame )
        {
            frame = 0f;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int i = 1; i <= 2; i++ )
        {
            AppMain.AoActSetFrame( main_work.act[i], frame );
            AppMain.AoActUpdate( main_work.act[i], 0f );
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcFadeOut );
            if ( AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 32f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            }
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
            if ( !AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.DmSoundPlaySE( "Cancel" );
                return;
            }
            AppMain.GsSoundPlaySe( "Cancel", main_work.se_handle );
            AppMain.GsSoundStopBgm( main_work.bgm_scb, 32 );
            return;
        }
        else
        {
            if ( ( main_work.flag & 4U ) != 0U )
            {
                main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTopMenuDecideEfct );
                AppMain.dmOptSetTopMenuDecideEfctData( main_work );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Ok" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Ok", main_work.se_handle );
                }
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
                return;
            }
            if ( ( main_work.flag & 64U ) != 0U )
            {
                main_work.cur_slct_top = AppMain.dmOptGetRevisedTopMenuNo( main_work.cur_slct_top, -1 );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
                main_work.flag |= 262144U;
                AppMain.dmOptSetChngFocusCrsrData( main_work );
                main_work.flag &= 4294967231U;
                main_work.flag &= 4294967167U;
            }
            if ( ( main_work.flag & 128U ) != 0U )
            {
                main_work.cur_slct_top = AppMain.dmOptGetRevisedTopMenuNo( main_work.cur_slct_top, 1 );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
                main_work.flag |= 262144U;
                AppMain.dmOptSetChngFocusCrsrData( main_work );
                main_work.flag &= 4294967231U;
                main_work.flag &= 4294967167U;
            }
            if ( ( main_work.flag & 262144U ) != 0U )
            {
                AppMain.dmOptSetCtrlFocusChangeEfct( main_work );
                if ( AppMain.dmOptIsCtrlFocusChangeEfctEnd( main_work ) )
                {
                    main_work.flag &= 4294705151U;
                }
            }
            return;
        }
    }

    // Token: 0x06000CC4 RID: 3268 RVA: 0x00071398 File Offset: 0x0006F598
    private static void dmOptProcTopMenuDecideEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.dmOptIsTopMenuTabDecideEfctEnd( main_work ) )
        {
            AppMain.dmOptSetNextProcFunc( main_work );
            main_work.timer = 0f;
            return;
        }
        if ( ( main_work.flag & 262144U ) > 0U )
        {
            AppMain.dmOptSetCtrlFocusChangeEfct( main_work );
            if ( AppMain.dmOptIsCtrlFocusChangeEfctEnd( main_work ) )
            {
                main_work.flag &= 4294705151U;
            }
        }
        main_work.timer += 1f;
    }

    // Token: 0x06000CC5 RID: 3269 RVA: 0x00071400 File Offset: 0x0006F600
    private static void dmOptProcManualStartFadeOut( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcManualIdle );
            main_work.flag &= 2147483647U;
            AppMain.DmManualStart();
            main_work.proc_menu_draw = null;
        }
    }

    // Token: 0x06000CC6 RID: 3270 RVA: 0x0007143C File Offset: 0x0006F63C
    private static void dmOptProcManualIdle( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.DmManualIsExit() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcManualEndFadeIn );
            main_work.proc_menu_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_( AppMain.dmOptTopMenuDraw );
            main_work.flag |= 2147483648U;
            if ( AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 0U, 32f, true );
                return;
            }
            AppMain.IzFadeInitEasy( 0U, 0U, 32f );
        }
    }

    // Token: 0x06000CC7 RID: 3271 RVA: 0x000714B4 File Offset: 0x0006F6B4
    private static void dmOptProcManualEndFadeIn( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTopMenuIdle );
            main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcTopMenu );
        }
    }

    // Token: 0x06000CC8 RID: 3272 RVA: 0x000714E4 File Offset: 0x0006F6E4
    private static void dmOptProcSetMenuInEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 2048U ) > 0U )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcSetMenuIdle );
            main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcSettingMenu );
            main_work.disp_flag |= 1U;
            main_work.flag &= 4294965247U;
            return;
        }
        AppMain.dmOptSetWinOpenEfct( main_work );
    }

    // Token: 0x06000CC9 RID: 3273 RVA: 0x0007154C File Offset: 0x0006F74C
    private static void dmOptProcSetMenuIdle( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        CTrgAoAction trg_return = main_work.trg_return;
        float frame = main_work.act[1].frame;
        if ( trg_return.GetState( 0U )[10] && trg_return.GetState( 0U )[1] )
        {
            frame = 2f;
        }
        else if ( trg_return.GetState( 0U )[0] )
        {
            frame = 1f;
        }
        else if ( 2f > main_work.act[1].frame )
        {
            frame = 0f;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int i = 1; i <= 2; i++ )
        {
            AppMain.AoActSetFrame( main_work.act[i], frame );
            AppMain.AoActUpdate( main_work.act[i], 0f );
        }
        if ( ( main_work.flag & 2U ) > 0U && ( 16777216U & main_work.flag ) > 0U )
        {
            main_work.flag &= 4278190077U;
            if ( !AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.DmSoundPlaySE( "Cancel" );
                return;
            }
            AppMain.GsSoundPlaySe( "Cancel", main_work.se_handle );
            return;
        }
        else
        {
            if ( ( main_work.flag & 2U ) != 0U )
            {
                SOption soption = SOption.CreateInstance();
                soption.SetVolumeBgm( ( uint )( main_work.volume_data[0] * 10 ) );
                soption.SetVolumeSe( ( uint )( main_work.volume_data[1] * 10 ) );
                AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
                switch ( soption.GetControl() )
                {
                    case SOption.EControl.Type.VirtualPadDown:
                        gss_MAIN_SYS_INFO.game_flag &= 4294966783U;
                        gss_MAIN_SYS_INFO.game_flag |= 1U;
                        goto IL_1D2;
                    case SOption.EControl.Type.VirtualPadUp:
                        gss_MAIN_SYS_INFO.game_flag |= 512U;
                        gss_MAIN_SYS_INFO.game_flag |= 1U;
                        goto IL_1D2;
                }
                gss_MAIN_SYS_INFO.game_flag &= 4294966783U;
                gss_MAIN_SYS_INFO.game_flag &= 4294967294U;
                IL_1D2:
                main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcSetMenuOutEfct );
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cancel" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cancel", main_work.se_handle );
                }
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
                return;
            }
            if ( ( main_work.flag & 4U ) != 0U )
            {
                if ( main_work.cur_slct_set == 2 )
                {
                    AppMain.dmOptSetDefaultDataSetMenu( main_work );
                }
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Ok" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Ok", main_work.se_handle );
                }
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
                return;
            }
            if ( ( main_work.flag & 64U ) > 0U )
            {
                main_work.cur_slct_set = AppMain.dmOptGetRevisedSettingMenuNo( main_work.cur_slct_set, -1 );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
                main_work.flag &= 4294967231U;
                main_work.flag &= 4294967167U;
                return;
            }
            if ( ( main_work.flag & 128U ) > 0U )
            {
                main_work.cur_slct_set = AppMain.dmOptGetRevisedSettingMenuNo( main_work.cur_slct_set, 1 );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
                main_work.flag &= 4294967231U;
                main_work.flag &= 4294967167U;
                return;
            }
            AppMain.dmOptSetVolPushEfct( main_work );
            if ( ( main_work.flag & 1024U ) > 0U )
            {
                AppMain.dmOptSetDfltPushEfct( main_work );
            }
            if ( ( 16777216U & main_work.flag ) > 0U )
            {
                if ( main_work.ctrl_win_window_prgrs < 1f )
                {
                    main_work.ctrl_win_window_prgrs += 0.125f;
                    if ( 1.0 < ( double )main_work.ctrl_win_window_prgrs )
                    {
                        main_work.ctrl_win_window_prgrs = 1f;
                        return;
                    }
                }
            }
            else if ( 0f < main_work.ctrl_win_window_prgrs )
            {
                main_work.ctrl_win_window_prgrs -= 0.125f;
                if ( main_work.ctrl_win_window_prgrs < 0f )
                {
                    main_work.ctrl_win_window_prgrs = 0f;
                }
            }
            return;
        }
    }

    // Token: 0x06000CCA RID: 3274 RVA: 0x0007195C File Offset: 0x0006FB5C
    private static void dmOptProcSetMenuOutEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 2048U ) > 0U )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTopMenuIdle );
            main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcTopMenu );
            main_work.proc_menu_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_( AppMain.dmOptTopMenuDraw );
            main_work.state = 0;
            main_work.flag &= 4294965247U;
            return;
        }
        AppMain.dmOptSetWinCloseEfct( main_work );
    }

    // Token: 0x06000CCB RID: 3275 RVA: 0x000719D0 File Offset: 0x0006FBD0
    private static void dmOptProcCtrlMenuIdle( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        CTrgAoAction trg_return = main_work.trg_return;
        float frame = main_work.act[1].frame;
        if ( trg_return.GetState( 0U )[10] && trg_return.GetState( 0U )[1] )
        {
            frame = 2f;
        }
        else if ( trg_return.GetState( 0U )[0] )
        {
            frame = 1f;
        }
        else if ( 2f > main_work.act[1].frame )
        {
            frame = 0f;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int i = 1; i <= 2; i++ )
        {
            AppMain.AoActSetFrame( main_work.act[i], frame );
            AppMain.AoActUpdate( main_work.act[i], 0f );
        }
        if ( ( main_work.flag & 2U ) > 0U )
        {
            main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcTopMenu );
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTopMenuIdle );
            main_work.proc_menu_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_( AppMain.dmOptTopMenuDraw );
            main_work.state = 0;
            main_work.top_crsr_pos_y = 250f + ( float )main_work.cur_slct_top * 220f;
            if ( !AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.DmSoundPlaySE( "Cancel" );
            }
            else
            {
                AppMain.GsSoundPlaySe( "Cancel", main_work.se_handle );
            }
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
        }
    }

    // Token: 0x06000CCC RID: 3276 RVA: 0x00071B41 File Offset: 0x0006FD41
    private static void dmOptProcStfrlStartFadeOut( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcStfrlIdle );
            main_work.proc_draw = null;
            main_work.flag &= 2147483647U;
            AppMain.DmStaffRollStart( null );
        }
    }

    // Token: 0x06000CCD RID: 3277 RVA: 0x00071B7C File Offset: 0x0006FD7C
    private static void dmOptProcStfrlIdle( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.DmStaffRollIsExit() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcStfrlEndFadeIn );
            main_work.proc_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_draw_( AppMain.dmOptProcActDraw );
            AppMain.AoActSysSetDrawStateEnable( true );
            AppMain.AoActSysSetDrawState( AppMain.dm_opt_draw_state );
            main_work.flag |= 2147483648U;
            if ( AppMain.dm_opt_is_pause_maingame )
            {
                AppMain.GsSoundPlayBgm( main_work.bgm_scb, "snd_sng_menu", 32 );
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 0U, 32f, true );
                return;
            }
            AppMain.DmSndBgmPlayerPlayBgm( 0 );
            AppMain.IzFadeInitEasy( 0U, 0U, 32f );
        }
    }

    // Token: 0x06000CCE RID: 3278 RVA: 0x00071C20 File Offset: 0x0006FE20
    private static void dmOptProcStfrlEndFadeIn( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.flag |= 2147483648U;
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcTopMenuIdle );
            main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcTopMenu );
        }
    }

    // Token: 0x06000CCF RID: 3279 RVA: 0x00071C70 File Offset: 0x0006FE70
    private static void dmOptProcFadeOut( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.dm_opt_show_xboxlive && AppMain.dm_xbox_show_progress > 0 )
        {
            AppMain.dm_xbox_show_progress -= 20;
        }
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcStopDraw );
            main_work.proc_draw = null;
            main_work.timer = 0f;
            if ( !AppMain.dm_opt_is_pause_maingame )
            {
                return;
            }
            AppMain.GsSoundStopBgm( main_work.bgm_scb, 0 );
            AppMain.GsSoundResignScb( main_work.bgm_scb );
            main_work.bgm_scb = null;
            AppMain.GsSoundFreeSeHandle( main_work.se_handle );
            main_work.se_handle = null;
        }
    }

    // Token: 0x06000CD0 RID: 3280 RVA: 0x00071CFC File Offset: 0x0006FEFC
    private static void dmOptProcStopDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcDataRelease );
    }

    // Token: 0x06000CD1 RID: 3281 RVA: 0x00071D10 File Offset: 0x0006FF10
    private static void dmOptProcDataRelease( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexRelease( main_work.tex[i] );
        }
        for ( int j = 0; j < 5; j++ )
        {
            AppMain.AoTexRelease( main_work.cmn_tex[j] );
        }
        AppMain.DmManualFlush();
        bool flag = AppMain.dm_opt_is_pause_maingame;
        main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcFinish );
    }

    // Token: 0x06000CD2 RID: 3282 RVA: 0x00071D6C File Offset: 0x0006FF6C
    private static void dmOptProcFinish( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.dmOptIsTexRelease( main_work ) == 1 )
        {
            if ( AppMain.dm_opt_show_xboxlive )
            {
                LiveFeature.endInterrupt();
                AppMain.dm_opt_show_xboxlive = false;
            }
            for ( int i = 0; i < main_work.trg_slct.Length; i++ )
            {
                CTrgAoAction ctrgAoAction = main_work.trg_slct[i];
                ctrgAoAction.Release();
            }
            for ( int j = 0; j < main_work.trg_bgm_btn.Length; j++ )
            {
                CTrgAoAction ctrgAoAction2 = main_work.trg_bgm_btn[j];
                ctrgAoAction2.Release();
            }
            for ( int k = 0; k < main_work.trg_se_btn.Length; k++ )
            {
                CTrgAoAction ctrgAoAction3 = main_work.trg_se_btn[k];
                ctrgAoAction3.Release();
            }
            CTrgRect trg_bgm_slider = main_work.trg_bgm_slider;
            trg_bgm_slider.Release();
            CTrgRect trg_se_slider = main_work.trg_se_slider;
            trg_se_slider.Release();
            CTrgAoAction trg_return = main_work.trg_return;
            trg_return.Release();
            for ( int l = 0; l < main_work.trg_ctrl_btn.Length; l++ )
            {
                CTrgAoAction ctrgAoAction4 = main_work.trg_ctrl_btn[l];
                ctrgAoAction4.Release();
            }
            for ( int m = 0; m < main_work.ctrl_win_trg_btn.Length; m++ )
            {
                CTrgAoAction ctrgAoAction5 = main_work.ctrl_win_trg_btn[m];
                ctrgAoAction5.Release();
            }
            for ( int n = 0; n < 102; n++ )
            {
                if ( main_work.act[n] != null )
                {
                    AppMain.AoActDelete( main_work.act[n] );
                    main_work.act[n] = null;
                }
            }
            for ( int num = 0; num < 2; num++ )
            {
                if ( main_work.arc_amb[num] != null )
                {
                    main_work.arc_amb[num] = null;
                }
            }
            for ( int num2 = 0; num2 < 5; num2++ )
            {
                if ( main_work.arc_cmn_amb[num2] != null )
                {
                    main_work.arc_cmn_amb[num2] = null;
                }
            }
            for ( int num3 = 0; num3 < 2; num3++ )
            {
                if ( main_work.manual_arc_amb[num3] != null )
                {
                    main_work.manual_arc_amb[num3] = null;
                }
            }
            AppMain.DmSaveMenuStart( true, false );
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcFinishWaitSave );
        }
    }

    // Token: 0x06000CD3 RID: 3283 RVA: 0x00071F3F File Offset: 0x0007013F
    private static void dmOptProcFinishWaitSave( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcWaitFinished );
        }
    }

    // Token: 0x06000CD4 RID: 3284 RVA: 0x00071F5C File Offset: 0x0007015C
    private static void dmOptProcWaitFinished( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 1048576U ) != 0U )
        {
            if ( AppMain.DmSndBgmPlayerIsTaskExit() )
            {
                main_work.flag |= 1U;
                main_work.proc_update = null;
                main_work.flag &= 4293918719U;
                return;
            }
        }
        else
        {
            main_work.flag |= 1U;
            main_work.proc_update = null;
        }
    }

    // Token: 0x06000CD5 RID: 3285 RVA: 0x00071FBC File Offset: 0x000701BC
    private static void dmOptInputProcTopMenu( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( ( main_work.trg_return.GetState( 0U )[10] && main_work.trg_return.GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            main_work.flag |= 2U;
            return;
        }
        int i = 0;
        int num = main_work.trg_slct.Length;
        while ( i < num )
        {
            CTrgAoAction ctrgAoAction = main_work.trg_slct[i];
            if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
            {
                main_work.cur_slct_top = i;
                main_work.flag |= 4U;
                return;
            }
            i++;
        }
    }

    // Token: 0x06000CD6 RID: 3286 RVA: 0x00072064 File Offset: 0x00070264
    private static void dmOptInputProcSettingMenu( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( ( main_work.trg_return.GetState( 0U )[10] && main_work.trg_return.GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            main_work.flag |= 2U;
            return;
        }
        if ( ( 16777216U & main_work.flag ) == 0U )
        {
            CTrgAoAction ctrgAoAction = main_work.trg_ctrl_btn[0];
            if ( ctrgAoAction.GetState( 0U )[2] )
            {
                SOption soption = SOption.CreateInstance();
                soption.SetControl( SOption.EControl.Type.Tilt );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
            }
            CTrgAoAction ctrgAoAction2 = main_work.trg_ctrl_btn[1];
            if ( ctrgAoAction2.GetState( 0U )[2] )
            {
                SOption soption2 = SOption.CreateInstance();
                if ( soption2.GetControl() == SOption.EControl.Type.Tilt )
                {
                    soption2.SetControl( SOption.EControl.Type.VirtualPadDown );
                }
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
            }
            else if ( ctrgAoAction2.GetState( 0U )[10] && ctrgAoAction2.GetState( 0U )[1] )
            {
                main_work.flag |= 16777216U;
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Window" );
                    return;
                }
                AppMain.GsSoundPlaySe( "Window", main_work.se_handle );
                return;
            }
        }
        if ( 0f < main_work.ctrl_win_window_prgrs )
        {
            if ( 1f == main_work.ctrl_win_window_prgrs )
            {
                SOption soption3 = SOption.CreateInstance();
                bool flag = true;
                if ( main_work.ctrl_win_trg_btn[0].GetState( 0U )[2] )
                {
                    soption3.SetControl( SOption.EControl.Type.VirtualPadDown );
                }
                else if ( main_work.ctrl_win_trg_btn[1].GetState( 0U )[2] )
                {
                    soption3.SetControl( SOption.EControl.Type.VirtualPadUp );
                }
                else
                {
                    flag = false;
                }
                if ( flag )
                {
                    if ( !AppMain.dm_opt_is_pause_maingame )
                    {
                        AppMain.DmSoundPlaySE( "Cursol" );
                        return;
                    }
                    AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                }
            }
            return;
        }
        bool flag2 = false;
        bool[] array = new bool[main_work.trg_bgm_btn.Length];
        int i = 0;
        int num = main_work.trg_bgm_btn.Length;
        while ( i < num )
        {
            for ( int j = 0; j < 2; j++ )
            {
                CTrgAoAction[] array2 = (j == 0) ? main_work.trg_bgm_btn : main_work.trg_se_btn;
                if ( array2[i].GetState( 0U )[14] )
                {
                    if ( array2[i].GetState( 0U )[7] )
                    {
                        main_work.cur_slct_set = ( ( j == 0 ) ? 0 : 1 );
                        array[i] = true;
                        break;
                    }
                }
                else if ( array2[i].GetState( 0U )[13] )
                {
                    array2[i].DelLock();
                }
            }
            for ( int k = 0; k < 2; k++ )
            {
                CTrgRect ctrgRect = (k == 0) ? main_work.trg_bgm_slider : main_work.trg_se_slider;
                CTrgState state = ctrgRect.GetState(0U);
                if ( state[9] )
                {
                    IntPair lastMove = state.GetLastMove();
                    int moveThreshold = state.GetMoveThreshold();
                    if ( lastMove.first < -moveThreshold || moveThreshold < lastMove.first )
                    {
                        main_work.cur_slct_set = ( ( k == 0 ) ? 0 : 1 );
                        array[( lastMove.first < 0 ) ? 0 : 1] = true;
                        break;
                    }
                    if ( lastMove.second < -moveThreshold || moveThreshold < lastMove.second )
                    {
                        ctrgRect.DelLock();
                    }
                }
            }
            i++;
        }
        if ( flag2 )
        {
            if ( main_work.cur_slct_set == 2 )
            {
                main_work.flag |= 1024U;
                main_work.efct_timer = 0f;
            }
            main_work.flag |= 4U;
            return;
        }
        if ( !array[0] )
        {
            if ( array[1] )
            {
                switch ( main_work.cur_slct_set )
                {
                    case 0:
                        main_work.volume_data[0] = AppMain.dmOptGetRevisedVolume( main_work.volume_data[0], 1 );
                        main_work.push_efct_timer[0] = 12f;
                        AppMain.DmSoundSetVolumeBGM( ( float )main_work.volume_data[0] );
                        return;
                    case 1:
                        main_work.volume_data[1] = AppMain.dmOptGetRevisedVolume( main_work.volume_data[1], 1 );
                        main_work.push_efct_timer[2] = 12f;
                        AppMain.DmSoundSetVolumeSE( ( float )main_work.volume_data[1] );
                        if ( !AppMain.dm_opt_is_pause_maingame )
                        {
                            AppMain.DmSoundPlaySE( "Cursol" );
                            return;
                        }
                        AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                        break;
                    default:
                        return;
                }
            }
            return;
        }
        switch ( main_work.cur_slct_set )
        {
            case 0:
                main_work.volume_data[0] = AppMain.dmOptGetRevisedVolume( main_work.volume_data[0], -1 );
                main_work.push_efct_timer[1] = 12f;
                AppMain.DmSoundSetVolumeBGM( ( float )main_work.volume_data[0] );
                return;
            case 1:
                main_work.volume_data[1] = AppMain.dmOptGetRevisedVolume( main_work.volume_data[1], -1 );
                main_work.push_efct_timer[3] = 12f;
                AppMain.DmSoundSetVolumeSE( ( float )main_work.volume_data[1] );
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Cursol" );
                    return;
                }
                AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
                return;
            default:
                return;
        }
    }

    // Token: 0x06000CD7 RID: 3287 RVA: 0x00072528 File Offset: 0x00070728
    private static void dmOptInputProcControlMenu( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( ( main_work.trg_return.GetState( 0U )[10] && main_work.trg_return.GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            main_work.flag |= 2U;
            return;
        }
        if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_DECIDE ) > 0 )
        {
            main_work.flag |= 4U;
        }
    }

    // Token: 0x06000CD8 RID: 3288 RVA: 0x00072598 File Offset: 0x00070798
    private static void dmOptProcActDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.dmOptSetObiEfctPos( main_work );
        AppMain.dmOptCommonDraw( main_work );
        AppMain.dmOptCommonFixDraw( main_work );
        if ( main_work.proc_menu_draw != null )
        {
            if ( !AppMain.dm_opt_show_xboxlive )
            {
                main_work.proc_menu_draw( main_work );
            }
            else if ( AppMain.dm_xbox_show_progress < 100 && main_work.proc_update != new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcFadeOut ) )
            {
                AppMain.dm_xbox_show_progress += 5;
            }
        }
        if ( AppMain.dm_opt_is_pause_maingame )
        {
            if ( main_work.draw_state != 0U )
            {
                AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmOptTaskDraw ), 32768, 0U );
                return;
            }
        }
        else
        {
            AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmOptTaskDraw ), 32768, 0U );
        }
    }

    // Token: 0x06000CD9 RID: 3289 RVA: 0x00072640 File Offset: 0x00070840
    private static void dmOptTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( AppMain.dm_opt_draw_state );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06000CDA RID: 3290 RVA: 0x00072658 File Offset: 0x00070858
    private static void dmOptCommonDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 4096U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[0] ) );
        AppMain.AoActSortRegAction( main_work.act[97] );
        if ( !AppMain.dm_opt_show_xboxlive || LiveFeature.interruptMainLoop == 1 )
        {
            AppMain.AoActSortRegAction( main_work.act[99] );
        }
        AppMain.AoActSortRegAction( main_work.act[98] );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[0] ) );
        AppMain.AoActUpdate( main_work.act[97], 1f );
        if ( !AppMain.dm_opt_show_xboxlive || LiveFeature.interruptMainLoop == 1 )
        {
            AppMain.AoActUpdate( main_work.act[99], 0f );
        }
        AppMain.AoActUpdate( main_work.act[98], 0f );
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06000CDB RID: 3291 RVA: 0x00072724 File Offset: 0x00070924
    private static void dmOptCommonFixDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 12288U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        if ( !AppMain.dm_opt_show_xboxlive || LiveFeature.interruptMainLoop == 1 )
        {
            for ( int i = 0; i <= 0; i++ )
            {
                AppMain.AoActSortRegAction( main_work.act[i] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        if ( !AppMain.dm_opt_show_xboxlive )
        {
            for ( int j = 69; j <= 69; j++ )
            {
                AppMain.AoActSortRegAction( main_work.act[j] );
            }
        }
        for ( int k = 1; k <= 2; k++ )
        {
            AppMain.AoActSortRegAction( main_work.act[k] );
        }
        AppMain.AoActSortRegAction( main_work.act[101] );
        AppMain.AoActSetFrame( main_work.act[69], ( float )main_work.state );
        if ( main_work.is_jp_region )
        {
            AppMain.AoActSetFrame( main_work.act[100], 0f );
        }
        else
        {
            AppMain.AoActSetFrame( main_work.act[100], 1f );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        for ( int l = 0; l <= 0; l++ )
        {
            AppMain.AoActUpdate( main_work.act[l], 0f );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActUpdate( main_work.act[69], 0f );
        main_work.act[69].sprite.center_y += 10f;
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[4] ) );
        AppMain.AoActUpdate( main_work.act[101], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int m = 1; m <= 2; m++ )
        {
            float frame = (2f <= main_work.act[m].frame) ? 1f : 0f;
            AppMain.AoActUpdate( main_work.act[m], frame );
        }
        CTrgAoAction trg_return = main_work.trg_return;
        trg_return.Update();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06000CDC RID: 3292 RVA: 0x00072934 File Offset: 0x00070B34
    private static void dmOptTopMenuDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            AppMain.AoActSortRegAction( main_work.act[3] );
            AppMain.AoActSortRegAction( main_work.act[4] );
            AppMain.AoActSortRegAction( main_work.act[5] );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActSortRegAction( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]] );
            if ( ( 16U & main_work.flag ) > 0U )
            {
                if ( i == main_work.cur_slct_top )
                {
                    float frame = 2f + main_work.timer;
                    AppMain.AoActSetFrame( main_work.act[3], frame );
                    AppMain.AoActSetFrame( main_work.act[4], frame );
                    AppMain.AoActSetFrame( main_work.act[5], frame );
                    AppMain.AoActSetFrame( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]], 1f );
                }
                else
                {
                    AppMain.AoActSetFrame( main_work.act[3], 0f );
                    AppMain.AoActSetFrame( main_work.act[4], 0f );
                    AppMain.AoActSetFrame( main_work.act[5], 0f );
                    AppMain.AoActSetFrame( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]], 0f );
                }
            }
            else if ( AppMain.IzFadeIsExe() && !AppMain.IzFadeIsEnd() )
            {
                AppMain.AoActSetFrame( main_work.act[3], 0f );
                AppMain.AoActSetFrame( main_work.act[4], 0f );
                AppMain.AoActSetFrame( main_work.act[5], 0f );
                AppMain.AoActSetFrame( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]], 0f );
            }
            else if ( main_work.trg_slct[i].GetState( 0U )[0] )
            {
                AppMain.AoActSetFrame( main_work.act[3], 1f );
                AppMain.AoActSetFrame( main_work.act[4], 1f );
                AppMain.AoActSetFrame( main_work.act[5], 1f );
                AppMain.AoActSetFrame( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]], 1f );
            }
            else
            {
                AppMain.AoActSetFrame( main_work.act[3], 0f );
                AppMain.AoActSetFrame( main_work.act[4], 0f );
                AppMain.AoActSetFrame( main_work.act[5], 0f );
                AppMain.AoActSetFrame( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]], 0f );
            }
            AppMain.AoActAcmPush();
            AppMain.AoActAcmInit();
            AppMain.AoActAcmApplyTrans( 240f + ( float )( i % 2 ) * 480f, 250f + ( float )( i / 2 ) * 220f, 0f );
            if ( main_work.cur_slct_top == i && ( main_work.flag & 16U ) > 0U )
            {
                AppMain.AoActAcmApplyFade( main_work.decide_menu_col );
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            AppMain.AoActUpdate( main_work.act[3], 0f );
            AppMain.AoActUpdate( main_work.act[4], 0f );
            AppMain.AoActUpdate( main_work.act[5], 0f );
            CTrgAoAction ctrgAoAction = main_work.trg_slct[i];
            ctrgAoAction.Update();
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActUpdate( main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]], 0f );
            main_work.act[AppMain.dm_opt_top_menu_tex_tbl[i]].sprite.center_y += 7f;
            AppMain.AoActAcmPop();
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
            AppMain.AoActSortUnregAll();
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06000CDD RID: 3293 RVA: 0x00072CAC File Offset: 0x00070EAC
    private static void dmOptSettingMenuDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.AOS_ACT_COL aos_ACT_COL = default(AppMain.AOS_ACT_COL);
        float num = 0f;
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( main_work.tex[0] ), 3U, 480f, 356f, 840f * main_work.win_size_rate[0], 400f * main_work.win_size_rate[1] * 0.9f, AppMain.dm_opt_draw_state );
        if ( ( main_work.disp_flag & 1U ) != 0U )
        {
            for ( int i = 0; i < 2; i++ )
            {
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                if ( i < 2 )
                {
                    for ( uint num2 = 10U; num2 <= 21U; num2 += 1U )
                    {
                        AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )num2 )] );
                    }
                    if ( main_work.volume_data[i] == 10 )
                    {
                        AppMain.AoActSortRegAction( main_work.act[6] );
                    }
                    if ( main_work.volume_data[i] > 0 )
                    {
                        AppMain.AoActSortRegAction( main_work.act[7] );
                    }
                    AppMain.AoActSortRegAction( main_work.act[8] );
                    AppMain.AoActSortRegAction( main_work.act[9] );
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                AppMain.AoActSortRegAction( main_work.act[AppMain.dm_opt_set_menu_tex_tbl[i]] );
                if ( i > 1 )
                {
                    AppMain.AoActSortRegAction( main_work.act[78] );
                    AppMain.AoActSortRegAction( main_work.act[79] );
                }
                if ( main_work.cur_slct_set == i )
                {
                    AppMain.AoActSetFrame( main_work.act[AppMain.dm_opt_set_menu_tex_tbl[i]], 0f );
                    aos_ACT_COL.r = ( aos_ACT_COL.g = ( aos_ACT_COL.b = ( aos_ACT_COL.a = byte.MaxValue ) ) );
                }
                else
                {
                    aos_ACT_COL.r = ( aos_ACT_COL.g = ( aos_ACT_COL.b = byte.MaxValue ) );
                    aos_ACT_COL.a = 60;
                }
                AppMain.AoActSetFrame( main_work.act[6], 1f );
                AppMain.AoActSetFrame( main_work.act[7], ( float )( main_work.volume_data[i] % 10 ) );
                AppMain.AoActSetFrame( main_work.act[8], 0f );
                if ( i <= 1 )
                {
                    for ( int j = 0; j < 10; j++ )
                    {
                        if ( j < main_work.volume_data[i] )
                        {
                            AppMain.AoActSetFrame( main_work.act[12 + j], 0f );
                        }
                        else
                        {
                            AppMain.AoActSetFrame( main_work.act[12 + j], 1f );
                        }
                    }
                }
                if ( main_work.set_vbrt == 0 )
                {
                    AppMain.AoActSetFrame( main_work.act[78], 0f );
                    AppMain.AoActSetFrame( main_work.act[79], 1f );
                }
                else
                {
                    AppMain.AoActSetFrame( main_work.act[78], 1f );
                    AppMain.AoActSetFrame( main_work.act[79], 0f );
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                for ( int k = 6; k <= 21; k++ )
                {
                    AppMain.AoActAcmPush();
                    AppMain.AoActAcmInit();
                    AppMain.AoActAcmApplyTrans( 480f + num, AppMain.dm_opt_set_tab_pos_y_tbl[i], 0f );
                    if ( main_work.push_efct_timer[2 * i] > 0f && k == 10 )
                    {
                        AppMain.AoActAcmApplyColor( main_work.vol_icon_col );
                    }
                    if ( main_work.push_efct_timer[1 + 2 * i] > 0f && k == 11 )
                    {
                        AppMain.AoActAcmApplyColor( main_work.vol_icon_col );
                    }
                    AppMain.AoActUpdate( main_work.act[k], 0f );
                    int num3;
                    switch ( k )
                    {
                        case 10:
                            num3 = 1;
                            break;
                        case 11:
                            num3 = 0;
                            break;
                        default:
                            num3 = -1;
                            break;
                    }
                    if ( 0 <= num3 )
                    {
                        CTrgAoAction[] array;
                        switch ( i )
                        {
                            case 0:
                                array = main_work.trg_bgm_btn;
                                break;
                            case 1:
                                array = main_work.trg_se_btn;
                                break;
                            default:
                                array = null;
                                break;
                        }
                        if ( array != null )
                        {
                            array[num3].Update();
                        }
                    }
                    AppMain.AoActAcmPop();
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                for ( uint num4 = 74U; num4 <= 79U; num4 += 1U )
                {
                    AppMain.AoActAcmPush();
                    AppMain.AoActAcmInit();
                    AppMain.AoActAcmApplyTrans( 480f, AppMain.dm_opt_set_tab_pos_y_tbl[i], 0f );
                    AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )num4 )], 0f );
                    AppMain.AoActAcmPop();
                }
                AppMain.AoActSortExecute();
                AppMain.AoActSortDraw();
                AppMain.AoActSortUnregAll();
            }
            CTrgRect trg_bgm_slider = main_work.trg_bgm_slider;
            trg_bgm_slider.Update();
            CTrgRect trg_se_slider = main_work.trg_se_slider;
            trg_se_slider.Update();
            float frame;
            float frame2;
            if ( SOption.CreateInstance().GetControl() == SOption.EControl.Type.Tilt )
            {
                frame = 1f;
                frame2 = 0f;
            }
            else
            {
                frame = 0f;
                frame2 = 1f;
            }
            for ( int l = 22; l < 25; l++ )
            {
                AppMain.AoActSetFrame( main_work.act[l], frame );
            }
            for ( int m = 80; m < 81; m++ )
            {
                AppMain.AoActSetFrame( main_work.act[m], frame );
            }
            for ( int n = 25; n < 28; n++ )
            {
                AppMain.AoActSetFrame( main_work.act[n], frame2 );
            }
            for ( int num5 = 81; num5 < 82; num5++ )
            {
                AppMain.AoActSetFrame( main_work.act[num5], frame2 );
            }
            AppMain.AoActAcmPush();
            AppMain.AoActAcmInit();
            AppMain.AoActAcmApplyTrans( 480f + num, AppMain.dm_opt_set_tab_pos_y_tbl[2], 0f );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            for ( int num6 = 22; num6 < 28; num6++ )
            {
                AppMain.AoActUpdate( main_work.act[num6], 0f );
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActUpdate( main_work.act[76], 0f );
            for ( int num7 = 80; num7 < 82; num7++ )
            {
                AppMain.AoActUpdate( main_work.act[num7], 0f );
            }
            for ( int num8 = 0; num8 < main_work.trg_ctrl_btn.Length; num8++ )
            {
                main_work.trg_ctrl_btn[num8].Update();
            }
            AppMain.AoActAcmPop();
            AppMain.AoActSortRegAction( main_work.act[76] );
            for ( int num9 = 22; num9 < 28; num9++ )
            {
                AppMain.AoActSortRegAction( main_work.act[num9] );
            }
            for ( int num10 = 80; num10 < 82; num10++ )
            {
                AppMain.AoActSortRegAction( main_work.act[num10] );
            }
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
            AppMain.AoActSortUnregAll();
            if ( 0f < main_work.ctrl_win_window_prgrs )
            {
                AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( main_work.cmn_tex[3] ), 0U, 480f, 356f, 1280f * main_work.ctrl_win_window_prgrs, 720f * main_work.ctrl_win_window_prgrs * 0.9f, AppMain.dm_opt_draw_state );
                if ( 1f == main_work.ctrl_win_window_prgrs )
                {
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                    for ( int num11 = 28; num11 < 42; num11++ )
                    {
                        AppMain.AoActUpdate( main_work.act[num11] );
                    }
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    for ( int num12 = 82; num12 < 88; num12++ )
                    {
                        AppMain.AoActUpdate( main_work.act[num12] );
                    }
                    for ( int num13 = 0; num13 < main_work.ctrl_win_trg_btn.Length; num13++ )
                    {
                        main_work.ctrl_win_trg_btn[num13].Update();
                    }
                    SOption.EControl.Type control = SOption.CreateInstance().GetControl();
                    if ( SOption.EControl.Type.VirtualPadUp == control )
                    {
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                        for ( int num14 = 36; num14 < 39; num14++ )
                        {
                            AppMain.AOS_ACTION act = main_work.act[num14];
                            AppMain.AoActSetFrame( act, 1f );
                            AppMain.AoActUpdate( act, 0f );
                        }
                        for ( int num15 = 39; num15 < 42; num15++ )
                        {
                            AppMain.AOS_ACTION act2 = main_work.act[num15];
                            AppMain.AoActSetFrame( act2, 0f );
                            AppMain.AoActUpdate( act2, 0f );
                        }
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                        AppMain.AoActSetFrame( main_work.act[84], 1f );
                        AppMain.AoActSetFrame( main_work.act[85], 0f );
                        for ( int num16 = 84; num16 < 86; num16++ )
                        {
                            AppMain.AoActUpdate( main_work.act[num16], 0f );
                        }
                    }
                    else
                    {
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                        for ( int num17 = 36; num17 < 39; num17++ )
                        {
                            AppMain.AOS_ACTION act3 = main_work.act[num17];
                            AppMain.AoActSetFrame( act3, 0f );
                            AppMain.AoActUpdate( act3, 0f );
                        }
                        for ( int num18 = 39; num18 < 42; num18++ )
                        {
                            AppMain.AOS_ACTION act4 = main_work.act[num18];
                            AppMain.AoActSetFrame( act4, 1f );
                            AppMain.AoActUpdate( act4, 0f );
                        }
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                        AppMain.AoActSetFrame( main_work.act[84], 0f );
                        AppMain.AoActSetFrame( main_work.act[85], 1f );
                        for ( int num19 = 84; num19 < 86; num19++ )
                        {
                            AppMain.AoActUpdate( main_work.act[num19], 0f );
                        }
                    }
                    for ( int num20 = 28; num20 < 29; num20++ )
                    {
                        AppMain.AOS_ACTION aos_ACTION = main_work.act[num20];
                        AppMain.AoActSortRegAction( main_work.act[num20] );
                    }
                    for ( int num21 = 36; num21 < 42; num21++ )
                    {
                        AppMain.AOS_ACTION aos_ACTION2 = main_work.act[num21];
                        AppMain.AoActSortRegAction( main_work.act[num21] );
                    }
                    for ( int num22 = 82; num22 < 86; num22++ )
                    {
                        AppMain.AOS_ACTION aos_ACTION3 = main_work.act[num22];
                        AppMain.AoActSortRegAction( main_work.act[num22] );
                    }
                    if ( SOption.EControl.Type.VirtualPadUp == control )
                    {
                        AppMain.AoActSortRegAction( main_work.act[31] );
                        for ( int num23 = 32; num23 < 36; num23++ )
                        {
                            AppMain.AOS_ACTION aos_ACTION4 = main_work.act[num23];
                            AppMain.AoActSortRegAction( main_work.act[num23] );
                        }
                        AppMain.AoActSortRegAction( main_work.act[87] );
                    }
                    else
                    {
                        for ( int num24 = 29; num24 < 31; num24++ )
                        {
                            AppMain.AOS_ACTION aos_ACTION5 = main_work.act[num24];
                            AppMain.AoActSortRegAction( main_work.act[num24] );
                        }
                        AppMain.AoActSortRegAction( main_work.act[86] );
                    }
                }
                AppMain.AoActSortRegAction( main_work.act[101] );
                for ( int num25 = 1; num25 < 3; num25++ )
                {
                    AppMain.AoActSortRegAction( main_work.act[num25] );
                }
                AppMain.AoActSortExecute();
                AppMain.AoActSortDraw();
                AppMain.AoActSortUnregAll();
            }
        }
    }

    // Token: 0x06000CDE RID: 3294 RVA: 0x000736C0 File Offset: 0x000718C0
    private static void dmOptControlMenuDraw( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        for ( int i = 42; i <= 68; i++ )
        {
            if ( i >= 52 && i <= 56 )
            {
                if ( ( AppMain.g_gs_main_sys_info.game_flag & 32U ) > 0U && main_work.act[i] != null )
                {
                    AppMain.AoActSortRegAction( main_work.act[i] );
                }
            }
            else if ( i != 51 && main_work.act[i] != null )
            {
                AppMain.AoActSortRegAction( main_work.act[i] );
            }
        }
        if ( SOption.CreateInstance().GetControl() != SOption.EControl.Type.Tilt )
        {
            if ( main_work.act[50] != null )
            {
                AppMain.AoActSetFrame( main_work.act[50], 0f );
            }
            if ( main_work.act[55] != null )
            {
                AppMain.AoActSetFrame( main_work.act[55], 0f );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        for ( int j = 88; j <= 96; j++ )
        {
            if ( j == 92 )
            {
                if ( ( AppMain.g_gs_main_sys_info.game_flag & 32U ) > 0U && main_work.act[j] != null )
                {
                    AppMain.AoActSortRegAction( main_work.act[j] );
                }
            }
            else if ( main_work.act[j] != null )
            {
                AppMain.AoActSortRegAction( main_work.act[j] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        for ( int k = 42; k <= 68; k++ )
        {
            if ( main_work.act[k] != null )
            {
                AppMain.AoActUpdate( main_work.act[k] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        for ( int l = 88; l <= 96; l++ )
        {
            if ( main_work.act[l] != null )
            {
                AppMain.AoActUpdate( main_work.act[l] );
            }
        }
        AppMain.AoActSortExecuteFix();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06000CDF RID: 3295 RVA: 0x00073870 File Offset: 0x00071A70
    private static void dmOptSetObiEfctPos( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( main_work.obi_tex_pos[( int )( ( UIntPtr )num )] < -1120f )
            {
                main_work.obi_tex_pos[( int )( ( UIntPtr )num )] = 1120f;
            }
            main_work.obi_tex_pos[( int )( ( UIntPtr )num )] += -3f;
        }
    }

    // Token: 0x06000CE0 RID: 3296 RVA: 0x000738C8 File Offset: 0x00071AC8
    private static void dmOptSetNextProcFunc( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        switch ( main_work.cur_slct_top )
        {
            case 0:
                main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcManualStartFadeOut );
                main_work.proc_input = null;
                main_work.state = 0;
                if ( AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 32f, true );
                    return;
                }
                AppMain.IzFadeInitEasy( 0U, 1U, 32f );
                return;
            case 1:
                main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcCtrlMenuIdle );
                main_work.proc_input = new AppMain.DMS_OPT_MAIN_WORK._proc_input_( AppMain.dmOptInputProcControlMenu );
                main_work.proc_menu_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_( AppMain.dmOptControlMenuDraw );
                AppMain.dmOptControlResetAct( main_work );
                main_work.state = 1;
                return;
            case 2:
                main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcSetMenuInEfct );
                main_work.proc_input = null;
                main_work.proc_menu_draw = new AppMain.DMS_OPT_MAIN_WORK._proc_menu_draw_( AppMain.dmOptSettingMenuDraw );
                main_work.state = 2;
                main_work.cur_slct_set = 0;
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSoundPlaySE( "Window" );
                }
                else
                {
                    AppMain.GsSoundPlaySe( "Window", main_work.se_handle, 0 );
                }
                AppMain.dmOptSetSaveOptionData( main_work );
                return;
            case 3:
                main_work.proc_update = new AppMain.DMS_OPT_MAIN_WORK._proc_update_( AppMain.dmOptProcStfrlStartFadeOut );
                main_work.proc_input = null;
                main_work.state = 0;
                if ( AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 32f, true );
                }
                else
                {
                    AppMain.IzFadeInitEasy( 0U, 1U, 32f );
                }
                if ( !AppMain.dm_opt_is_pause_maingame )
                {
                    AppMain.DmSndBgmPlayerBgmStop();
                    return;
                }
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 32 );
                return;
            default:
                return;
        }
    }

    // Token: 0x06000CE1 RID: 3297 RVA: 0x00073A54 File Offset: 0x00071C54
    private static void dmOptSetDefaultDataSetMenu( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            main_work.volume_data[( int )( ( UIntPtr )num )] = 10;
        }
        AppMain.DmSoundSetVolumeBGM( ( float )main_work.volume_data[0] );
        AppMain.DmSoundSetVolumeSE( ( float )main_work.volume_data[1] );
        main_work.set_vbrt = 0;
    }

    // Token: 0x06000CE2 RID: 3298 RVA: 0x00073A9B File Offset: 0x00071C9B
    private static void dmOptSetTopMenuDecideEfctData( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        main_work.flag |= 16U;
    }

    // Token: 0x06000CE3 RID: 3299 RVA: 0x00073AAC File Offset: 0x00071CAC
    private static void dmOptSetTopMenuTabDecideEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        float num = (float)main_work.decide_menu_col.a;
        if ( main_work.timer <= 8f )
        {
            float num2 = 31.875f;
            num += num2;
            if ( num >= 255f )
            {
                num = 255f;
            }
        }
        else if ( main_work.timer <= 16f )
        {
            float num2 = 31.875f;
            num -= num2;
            if ( num < 0f )
            {
                num = 0f;
            }
        }
        main_work.decide_menu_col.a = ( byte )num;
    }

    // Token: 0x06000CE4 RID: 3300 RVA: 0x00073B2B File Offset: 0x00071D2B
    private static bool dmOptIsTopMenuTabDecideEfctEnd( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( main_work.timer > 28f )
        {
            main_work.flag &= 4294967279U;
            main_work.decide_menu_col.a = 0;
            main_work.timer = 0f;
            return true;
        }
        return false;
    }

    // Token: 0x06000CE5 RID: 3301 RVA: 0x00073B64 File Offset: 0x00071D64
    private static void dmOptSetCtrlFocusChangeEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        float num = main_work.dst_crsr_pos_y - main_work.src_crsr_pos_y;
        float num2 = num / 8f;
        main_work.top_crsr_pos_y += num2;
    }

    // Token: 0x06000CE6 RID: 3302 RVA: 0x00073BA4 File Offset: 0x00071DA4
    private static bool dmOptIsCtrlFocusChangeEfctEnd( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        float num = main_work.dst_crsr_pos_y - main_work.src_crsr_pos_y;
        if ( main_work.top_crsr_pos_y >= main_work.dst_crsr_pos_y && num >= 0f )
        {
            main_work.top_crsr_pos_y = main_work.dst_crsr_pos_y;
            return true;
        }
        if ( main_work.top_crsr_pos_y <= main_work.dst_crsr_pos_y && num <= 0f )
        {
            main_work.top_crsr_pos_y = main_work.dst_crsr_pos_y;
            return true;
        }
        return false;
    }

    // Token: 0x06000CE7 RID: 3303 RVA: 0x00073C10 File Offset: 0x00071E10
    private static void dmOptSetVolPushEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( main_work.push_efct_timer[i] > 0f )
            {
                main_work.push_efct_timer[i] -= 1f;
            }
            else
            {
                main_work.push_efct_timer[i] = 0f;
            }
        }
    }

    // Token: 0x06000CE8 RID: 3304 RVA: 0x00073C64 File Offset: 0x00071E64
    private static void dmOptSetDfltPushEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( main_work.efct_timer > 10f )
        {
            main_work.flag &= 4294966271U;
            main_work.efct_timer = 0f;
        }
        main_work.efct_timer += 1f;
    }

    // Token: 0x06000CE9 RID: 3305 RVA: 0x00073CA4 File Offset: 0x00071EA4
    private static void dmOptSetWinOpenEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( main_work.win_timer > 8f )
        {
            main_work.flag |= 2048U;
            main_work.win_timer = 0f;
            for ( uint num = 0U; num < 2U; num += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 1f;
            }
        }
        else
        {
            main_work.win_timer += 1f;
        }
        for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
        {
            if ( main_work.win_timer != 0f )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = main_work.win_timer / 8f;
            }
            else
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
            if ( main_work.win_size_rate[( int )( ( UIntPtr )num2 )] > 1f )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
        }
    }

    // Token: 0x06000CEA RID: 3306 RVA: 0x00073D68 File Offset: 0x00071F68
    private static void dmOptSetWinCloseEfct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( main_work.win_timer > 0f )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = main_work.win_timer / 8f;
            }
            else
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 0f;
            }
            if ( main_work.win_size_rate[( int )( ( UIntPtr )num )] < 0f )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 0f;
            }
        }
        if ( main_work.win_timer < 0f )
        {
            main_work.flag |= 2048U;
            main_work.win_timer = 0f;
            for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 0f;
            }
            return;
        }
        main_work.win_timer -= 1f;
    }

    // Token: 0x06000CEB RID: 3307 RVA: 0x00073E28 File Offset: 0x00072028
    private static void dmOptSetChngFocusCrsrData( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        main_work.src_crsr_pos_y = main_work.top_crsr_pos_y;
        main_work.dst_crsr_pos_y = 250f + ( float )main_work.cur_slct_top * 220f;
        main_work.flag |= 262144U;
    }

    // Token: 0x06000CEC RID: 3308 RVA: 0x00073E64 File Offset: 0x00072064
    private static int dmOptIsDataLoad( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_amb_fs[i] ) )
            {
                return 0;
            }
        }
        for ( int j = 0; j < 5; j++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_cmn_amb_fs[j] ) )
            {
                return 0;
            }
        }
        for ( int k = 0; k < 2; k++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.manual_arc_amb_fs[k] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x06000CED RID: 3309 RVA: 0x00073ECC File Offset: 0x000720CC
    private static int dmOptIsTexLoad( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.tex[i] ) )
            {
                return 0;
            }
        }
        for ( int j = 0; j < 5; j++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.cmn_tex[j] ) )
            {
                return 0;
            }
        }
        if ( !AppMain.GsFontIsBuilded() )
        {
            return 0;
        }
        if ( !AppMain.dm_opt_is_pause_maingame && !AppMain.DmSndBgmPlayerIsSndSysBuild() )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000CEE RID: 3310 RVA: 0x00073F2D File Offset: 0x0007212D
    private static int dmOptIsTexLoad2( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        if ( !AppMain.DmManualBuildCheck() )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000CEF RID: 3311 RVA: 0x00073F3C File Offset: 0x0007213C
    private static int dmOptIsTexRelease( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.tex[i] ) )
            {
                return 0;
            }
        }
        for ( int j = 0; j < 5; j++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.cmn_tex[j] ) )
            {
                return 0;
            }
        }
        if ( !AppMain.DmManualFlushCheck() )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000CF0 RID: 3312 RVA: 0x00073F90 File Offset: 0x00072190
    private static int dmOptGetRevisedTopMenuNo( int idx, int diff )
    {
        int num = idx + diff;
        if ( num < 0 )
        {
            num = 3;
        }
        if ( num >= 4 )
        {
            num = 0;
        }
        return num;
    }

    // Token: 0x06000CF1 RID: 3313 RVA: 0x00073FB0 File Offset: 0x000721B0
    private static int dmOptGetRevisedSettingMenuNo( int idx, int diff )
    {
        int num = idx + diff;
        if ( num < 0 )
        {
            num = 2;
        }
        if ( num >= 3 )
        {
            num = 0;
        }
        return num;
    }

    // Token: 0x06000CF2 RID: 3314 RVA: 0x00073FD0 File Offset: 0x000721D0
    private static int dmOptGetRevisedVolume( int idx, int diff )
    {
        int num = idx + diff;
        if ( num < 0 )
        {
            num = 0;
        }
        if ( num > 10 )
        {
            num = 10;
        }
        return num;
    }

    // Token: 0x06000CF3 RID: 3315 RVA: 0x00073FF0 File Offset: 0x000721F0
    private static void dmOptControlResetAct( AppMain.DMS_OPT_MAIN_WORK main_work )
    {
        AppMain.SResetLocalTable[][] array = new AppMain.SResetLocalTable[][]
        {
            new AppMain.SResetLocalTable[]
            {
                new AppMain.SResetLocalTable(51, 32, 0),
                new AppMain.SResetLocalTable(52, 33, 0),
                new AppMain.SResetLocalTable(53, 34, 0),
                new AppMain.SResetLocalTable(54, 35, 0),
                new AppMain.SResetLocalTable(55, 45, 0),
                new AppMain.SResetLocalTable(56, 44, 0),
                new AppMain.SResetLocalTable(57, 36, 0),
                new AppMain.SResetLocalTable(58, 37, 0),
                new AppMain.SResetLocalTable(59, 38, 0),
                new AppMain.SResetLocalTable(60, 41, 0),
                new AppMain.SResetLocalTable(61, 42, 0),
                new AppMain.SResetLocalTable(62, 43, 0),
                new AppMain.SResetLocalTable(63, 39, 0),
                new AppMain.SResetLocalTable(64, 40, 0),
                new AppMain.SResetLocalTable(65, -1, -1),
                new AppMain.SResetLocalTable(66, 46, 0),
                new AppMain.SResetLocalTable(88, 11, 1),
                new AppMain.SResetLocalTable(89, 12, 1),
                new AppMain.SResetLocalTable(92, 15, 1),
                new AppMain.SResetLocalTable(93, 19, 1),
                new AppMain.SResetLocalTable(94, 18, 1),
                new AppMain.SResetLocalTable(95, 16, 1),
                new AppMain.SResetLocalTable(96, 17, 1)
            },
            new AppMain.SResetLocalTable[]
            {
                new AppMain.SResetLocalTable(51, 56, 0),
                new AppMain.SResetLocalTable(52, 57, 0),
                new AppMain.SResetLocalTable(53, 58, 0),
                new AppMain.SResetLocalTable(54, 59, 0),
                new AppMain.SResetLocalTable(55, 69, 0),
                new AppMain.SResetLocalTable(56, -1, -1),
                new AppMain.SResetLocalTable(57, 60, 0),
                new AppMain.SResetLocalTable(58, 61, 0),
                new AppMain.SResetLocalTable(59, 62, 0),
                new AppMain.SResetLocalTable(60, 66, 0),
                new AppMain.SResetLocalTable(61, 67, 0),
                new AppMain.SResetLocalTable(62, 68, 0),
                new AppMain.SResetLocalTable(63, 63, 0),
                new AppMain.SResetLocalTable(64, 64, 0),
                new AppMain.SResetLocalTable(65, 65, 0),
                new AppMain.SResetLocalTable(66, -1, -1),
                new AppMain.SResetLocalTable(88, 32, 1),
                new AppMain.SResetLocalTable(89, 33, 1),
                new AppMain.SResetLocalTable(92, 28, 1),
                new AppMain.SResetLocalTable(93, -1, -1),
                new AppMain.SResetLocalTable(94, 29, 1),
                new AppMain.SResetLocalTable(95, 31, 1),
                new AppMain.SResetLocalTable(96, 30, 1)
            },
            new AppMain.SResetLocalTable[]
            {
                new AppMain.SResetLocalTable(51, 56, 0),
                new AppMain.SResetLocalTable(52, 57, 0),
                new AppMain.SResetLocalTable(53, 58, 0),
                new AppMain.SResetLocalTable(54, 59, 0),
                new AppMain.SResetLocalTable(55, 69, 0),
                new AppMain.SResetLocalTable(56, -1, -1),
                new AppMain.SResetLocalTable(57, 60, 0),
                new AppMain.SResetLocalTable(58, 61, 0),
                new AppMain.SResetLocalTable(59, 62, 0),
                new AppMain.SResetLocalTable(60, 66, 0),
                new AppMain.SResetLocalTable(61, 67, 0),
                new AppMain.SResetLocalTable(62, 68, 0),
                new AppMain.SResetLocalTable(63, 63, 0),
                new AppMain.SResetLocalTable(64, 64, 0),
                new AppMain.SResetLocalTable(65, 65, 0),
                new AppMain.SResetLocalTable(66, -1, -1),
                new AppMain.SResetLocalTable(88, 32, 1),
                new AppMain.SResetLocalTable(89, 33, 1),
                new AppMain.SResetLocalTable(92, 28, 1),
                new AppMain.SResetLocalTable(93, -1, -1),
                new AppMain.SResetLocalTable(94, 29, 1),
                new AppMain.SResetLocalTable(95, 31, 1),
                new AppMain.SResetLocalTable(96, 30, 1)
            }
        };
        for ( int i = 0; i < array[0].Length; i++ )
        {
            if ( main_work.act[array[0][i].act_idx] != null )
            {
                AppMain.AoActDelete( main_work.act[array[0][i].act_idx] );
                main_work.act[array[0][i].act_idx] = null;
            }
        }
        SOption.EControl.Type control = SOption.CreateInstance().GetControl();
        for ( int j = 0; j < array[( int )control].Length; j++ )
        {
            if ( 0 <= array[( int )control][j].act_id )
            {
                main_work.act[array[( int )control][j].act_idx] = AppMain.AoActCreate( main_work.ama[array[( int )control][j].ama_idx], ( uint )array[( int )control][j].act_id );
            }
        }
        if ( control == SOption.EControl.Type.Tilt )
        {
            for ( int num = 42; num != 69; num++ )
            {
                if ( main_work.act[num] != null )
                {
                    AppMain.AoActSetFrame( main_work.act[num], 0f );
                }
            }
            for ( int num2 = 88; num2 != 97; num2++ )
            {
                if ( main_work.act[num2] != null )
                {
                    AppMain.AoActSetFrame( main_work.act[num2], 0f );
                }
            }
        }
    }
}
