using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.backup;

public partial class AppMain
{
    // Token: 0x020000BA RID: 186
    public enum GME_MAIN_CAMSCALE_STATE
    {
        // Token: 0x04004B58 RID: 19288
        GMD_MAIN_CAMSCALE_STATE_NON,
        // Token: 0x04004B59 RID: 19289
        GMD_MAIN_CAMSCALE_STATE_ZOOM,
        // Token: 0x04004B5A RID: 19290
        GMD_MAIN_CAMSCALE_STATE_UP,
        // Token: 0x04004B5B RID: 19291
        GMD_MAIN_CAMSCALE_STATE_MAX
    }

    // Token: 0x020000BB RID: 187
    public class GMS_MAIN_SYSTEM
    {
        // Token: 0x06001EE4 RID: 7908 RVA: 0x0013C938 File Offset: 0x0013AB38
        public void Clear()
        {
            this.game_flag = 0U;
            this.pre_tcb = null;
            this.post_tcb = null;
            this.game_time = 0U;
            this.sync_time = 0U;
            for ( int i = 0; i < this.ply_work.Length; i++ )
            {
                this.ply_work[i] = null;
            }
            this.marker_pri = 0U;
            this.time_save = 0U;
            this.resume_pos_x = 0;
            this.resume_pos_y = 0;
            int num = 0;
            while ( ( long )num < 1L )
            {
                this.player_rest_num[num] = 0U;
                num++;
            }
            this.map_fcol.Clear();
            for ( int j = 0; j < 2; j++ )
            {
                this.map_size[j] = 0;
            }
            this.water_level = 0;
            this.pseudofall_dir = 0;
            this.die_event_wait_time = 0;
            this.def_light_vec.Clear();
            this.def_light_col.Clear();
            this.ply_light_vec.Clear();
            this.ply_light_col.Clear();
            this.ply_dmg_count = 0U;
            this.boss_load_no = 0;
            this.polar_diff = 0;
            this.polar_now = 0;
            this.camscale_state = AppMain.GME_MAIN_CAMSCALE_STATE.GMD_MAIN_CAMSCALE_STATE_NON;
            this.camera_scale = 0f;
        }

        // Token: 0x04004B5C RID: 19292
        public uint game_flag;

        // Token: 0x04004B5D RID: 19293
        public AppMain.MTS_TASK_TCB pre_tcb;

        // Token: 0x04004B5E RID: 19294
        public AppMain.MTS_TASK_TCB post_tcb;

        // Token: 0x04004B5F RID: 19295
        public uint game_time;

        // Token: 0x04004B60 RID: 19296
        public uint sync_time;

        // Token: 0x04004B61 RID: 19297
        public AppMain.GMS_PLAYER_WORK[] ply_work = new AppMain.GMS_PLAYER_WORK[1];

        // Token: 0x04004B62 RID: 19298
        public uint marker_pri;

        // Token: 0x04004B63 RID: 19299
        public uint time_save;

        // Token: 0x04004B64 RID: 19300
        public int resume_pos_x;

        // Token: 0x04004B65 RID: 19301
        public int resume_pos_y;

        // Token: 0x04004B66 RID: 19302
        public uint[] player_rest_num = new uint[1];

        // Token: 0x04004B67 RID: 19303
        public readonly AppMain.OBS_DIFF_COLLISION map_fcol = new AppMain.OBS_DIFF_COLLISION();

        // Token: 0x04004B68 RID: 19304
        public int[] map_size = new int[2];

        // Token: 0x04004B69 RID: 19305
        public ushort water_level;

        // Token: 0x04004B6A RID: 19306
        public ushort pseudofall_dir;

        // Token: 0x04004B6B RID: 19307
        public int die_event_wait_time;

        // Token: 0x04004B6C RID: 19308
        public readonly AppMain.NNS_VECTOR def_light_vec = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004B6D RID: 19309
        public AppMain.NNS_RGBA def_light_col;

        // Token: 0x04004B6E RID: 19310
        public readonly AppMain.NNS_VECTOR ply_light_vec = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004B6F RID: 19311
        public AppMain.NNS_RGBA ply_light_col;

        // Token: 0x04004B70 RID: 19312
        public uint ply_dmg_count;

        // Token: 0x04004B71 RID: 19313
        public int boss_load_no;

        // Token: 0x04004B72 RID: 19314
        public int polar_diff;

        // Token: 0x04004B73 RID: 19315
        public int polar_now;

        // Token: 0x04004B74 RID: 19316
        public AppMain.GME_MAIN_CAMSCALE_STATE camscale_state;

        // Token: 0x04004B75 RID: 19317
        public float camera_scale;
    }

    // Token: 0x020000BC RID: 188
    public enum GMD_MAIN_NEXT_EVT
    {
        // Token: 0x04004B77 RID: 19319
        GMD_MAIN_NEXT_EVT_WORLDMAP,
        // Token: 0x04004B78 RID: 19320
        GMD_MAIN_NEXT_EVT_MAINGAME,
        // Token: 0x04004B79 RID: 19321
        GMD_MAIN_NEXT_EVT_ENDING,
        // Token: 0x04004B7A RID: 19322
        GMD_MAIN_NEXT_EVT_SPSTAGE_BRA,
        // Token: 0x04004B7B RID: 19323
        GMD_MAIN_NEXT_EVT_MAINMENU,
        // Token: 0x04004B7C RID: 19324
        GMD_MAIN_NEXT_EVT_TITLE,
        // Token: 0x04004B7D RID: 19325
        GMD_MAIN_NEXT_EVT_BUYSCREEN,
        // Token: 0x04004B7E RID: 19326
        GMD_MAIN_NEXT_EVT_MAX
    }

    // Token: 0x020000BD RID: 189
    public class GMS_MAIN_LOAD_BB_MGR_WORK
    {
        // Token: 0x04004B7F RID: 19327
        public int boss_type;

        // Token: 0x04004B80 RID: 19328
        public bool b_end;
    }

    // Token: 0x02000233 RID: 563
    private enum GSE_EVT_ID
    {
        // Token: 0x0400577B RID: 22395
        GSD_EVT_ID_NOP,
        // Token: 0x0400577C RID: 22396
        GSD_EVT_ID_SYS_INIT,
        // Token: 0x0400577D RID: 22397
        GSD_EVT_ID_LOGO_SEGA,
        // Token: 0x0400577E RID: 22398
        GSD_EVT_ID_TITLE,
        // Token: 0x0400577F RID: 22399
        GSD_EVT_ID_MAINMENU,
        // Token: 0x04005780 RID: 22400
        GSD_EVT_ID_MAP,
        // Token: 0x04005781 RID: 22401
        GSD_EVT_ID_MAINGAME,
        // Token: 0x04005782 RID: 22402
        GSD_EVT_ID_RANKING,
        // Token: 0x04005783 RID: 22403
        GSD_EVT_ID_OPTION,
        // Token: 0x04005784 RID: 22404
        GSD_EVT_ID_ENDING,
        // Token: 0x04005785 RID: 22405
        GSD_EVT_ID_STAFFROLL,
        // Token: 0x04005786 RID: 22406
        GSD_EVT_ID_SPSTAGE_BRANCH,
        // Token: 0x04005787 RID: 22407
        GSD_EVT_ID_BUYSCREEN,
        // Token: 0x04005788 RID: 22408
        GSD_EVT_ID_LOGO_SONIC,
        // Token: 0x04005789 RID: 22409
        GSD_EVT_ID_MOVIE,
        // Token: 0x0400578A RID: 22410
        GSD_EVT_ID_NUM
    }

    // Token: 0x02000234 RID: 564
    public enum GSE_MAIN_STAGE_TYPE
    {
        // Token: 0x0400578C RID: 22412
        GSD_MAIN_STAGE_TYPE_ACT,
        // Token: 0x0400578D RID: 22413
        GSD_MAIN_STAGE_TYPE_BOSS,
        // Token: 0x0400578E RID: 22414
        GSD_MAIN_STAGE_TYPE_SS,
        // Token: 0x0400578F RID: 22415
        GSD_MAIN_STAGE_TYPE_MAX
    }

    // Token: 0x02000235 RID: 565
    public class GSS_MAIN_SYS_INFO
    {
        // Token: 0x06002396 RID: 9110 RVA: 0x0014919C File Offset: 0x0014739C
        public void Clear()
        {
            this.main_flag = 0U;
            this.game_flag = 0U;
            this.sys_flag = 0U;
            this.sys_disp_width = 0f;
            this.sys_disp_height = 0f;
            this.char_id[0] = 0;
            this.clear_ring = 0U;
            this.clear_score = 0U;
            this.clear_time = 0;
            this.rest_player_num = 0U;
            this.se_volume = 0f;
            this.bgm_volume = 0f;
            this.ene_kill_count = 0U;
            this.final_clear_count = 0U;
            this.is_save_run = 0U;
            this.backup.Init();
            this.cmp_backup.Init();
            this.prev_stage_id = 0;
            this.is_spe_clear = false;
            this.is_first_play = false;
        }

        // Token: 0x04005790 RID: 22416
        public uint main_flag;

        // Token: 0x04005791 RID: 22417
        public uint game_flag;

        // Token: 0x04005792 RID: 22418
        public uint sys_flag;

        // Token: 0x04005793 RID: 22419
        public float sys_disp_width;

        // Token: 0x04005794 RID: 22420
        public float sys_disp_height;

        // Token: 0x04005795 RID: 22421
        public int level;

        // Token: 0x04005796 RID: 22422
        public int game_mode;

        // Token: 0x04005797 RID: 22423
        public ushort stage_id;

        // Token: 0x04005798 RID: 22424
        public readonly int[] char_id = new int[1];

        // Token: 0x04005799 RID: 22425
        public uint clear_ring;

        // Token: 0x0400579A RID: 22426
        public uint clear_score;

        // Token: 0x0400579B RID: 22427
        public int clear_time;

        // Token: 0x0400579C RID: 22428
        public uint rest_player_num;

        // Token: 0x0400579D RID: 22429
        public float se_volume;

        // Token: 0x0400579E RID: 22430
        public float bgm_volume;

        // Token: 0x0400579F RID: 22431
        public uint ene_kill_count;

        // Token: 0x040057A0 RID: 22432
        public uint final_clear_count;

        // Token: 0x040057A1 RID: 22433
        public uint is_save_run;

        // Token: 0x040057A2 RID: 22434
        public readonly GSS_BACKUP backup = new GSS_BACKUP();

        // Token: 0x040057A3 RID: 22435
        public readonly GSS_BACKUP cmp_backup = new GSS_BACKUP();

        // Token: 0x040057A4 RID: 22436
        public ushort prev_stage_id;

        // Token: 0x040057A5 RID: 22437
        public bool is_spe_clear;

        // Token: 0x040057A6 RID: 22438
        public bool is_first_play;
    }

    // Token: 0x1700001E RID: 30
    // (get) Token: 0x06000D07 RID: 3335 RVA: 0x000749BF File Offset: 0x00072BBF
    public static int GSD_DISP_WIDTH
    {
        get
        {
            return ( int )AppMain.g_gs_main_sys_info.sys_disp_width;
        }
    }

    // Token: 0x1700001F RID: 31
    // (get) Token: 0x06000D08 RID: 3336 RVA: 0x000749CC File Offset: 0x00072BCC
    public static int GSD_DISP_HEIGHT
    {
        get
        {
            return ( int )AppMain.g_gs_main_sys_info.sys_disp_height;
        }
    }

    // Token: 0x06000D09 RID: 3337 RVA: 0x000749D9 File Offset: 0x00072BD9
    public static bool GSM_MAIN_STAGE_IS_SPSTAGE()
    {
        return ( AppMain.g_gs_main_sys_info.game_flag & 128U ) != 0U;
    }

    // Token: 0x06000D0A RID: 3338 RVA: 0x000749F0 File Offset: 0x00072BF0
    public static bool GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY()
    {
        return ( AppMain.g_gs_main_sys_info.game_flag & 128U ) != 0U && ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 65536U ) == 0U;
    }

    // Token: 0x06000D0B RID: 3339 RVA: 0x00074A21 File Offset: 0x00072C21
    public static AppMain.GSS_MAIN_SYS_INFO GsGetMainSysInfo()
    {
        return AppMain.g_gs_main_sys_info;
    }

    // Token: 0x06000D0C RID: 3340 RVA: 0x00074A28 File Offset: 0x00072C28
    public static int GsMainSysGetDisplayListRegistNum()
    {
        return AppMain._am_displaylist_manager.regist_num + AppMain._am_displaylist_manager.reg_write_num;
    }

    // Token: 0x06000D0D RID: 3341 RVA: 0x00074A3F File Offset: 0x00072C3F
    public static int GsGetGameLevel()
    {
        return AppMain.g_gs_main_sys_info.level;
    }

    // Token: 0x06000D0E RID: 3342 RVA: 0x00074A4B File Offset: 0x00072C4B
    private static void GsSetGameLevel( int level )
    {
        AppMain.g_gs_main_sys_info.level = level;
    }

    // Token: 0x06000D0F RID: 3343 RVA: 0x00074A58 File Offset: 0x00072C58
    private static void GsReqExit()
    {
    }

    // Token: 0x06000D10 RID: 3344 RVA: 0x00074A5A File Offset: 0x00072C5A
    private static void GsInitUser()
    {
        AppMain.GsMainSysInfoInit( AppMain.GsGetMainSysInfo() );
        AppMain.mtTaskInitSystem();
        AppMain.SyInitEvtSys( AppMain._gs_evt_data, 15, 1, true, 256, 14 );
        AppMain.GsSoundInit();
    }

    // Token: 0x06000D11 RID: 3345 RVA: 0x00074A85 File Offset: 0x00072C85
    private static void GsExitUser()
    {
        AppMain.GsOtherExit();
        AppMain.GsSoundExit();
    }

    // Token: 0x06000D12 RID: 3346 RVA: 0x00074A91 File Offset: 0x00072C91
    private static void GsMainSysSystemInitEvent( object obj )
    {
        AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gsMainSysSystemInitMain ), null, 0U, ushort.MaxValue, 4096U, 0, null, "GS_SYS_INIT" );
    }

    // Token: 0x06000D13 RID: 3347 RVA: 0x00074AB8 File Offset: 0x00072CB8
    private static void gsMainSysSystemInitMain( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.GsMainSysCheckLoadShaderFinished() )
        {
            return;
        }
        AppMain.GsInitOtherStart();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gsMainSysSystemInitMain2 ) );
    }

    // Token: 0x06000D14 RID: 3348 RVA: 0x00074AD9 File Offset: 0x00072CD9
    private static void gsMainSysSystemInitMain2( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.GsInitOtherIsInitialized() )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
        if ( !AppMain.GsRebootIsTitleReboot() )
        {
            AppMain.SyDecideEvtCase( 0 );
        }
        else
        {
            AppMain.SyDecideEvtCase( 2 );
        }
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x06000D15 RID: 3349 RVA: 0x00074B03 File Offset: 0x00072D03
    private static void GsMainSysSetSleepFlag( bool flag )
    {
        AppMain._am_sample_is_sleep = flag;
    }

    // Token: 0x06000D16 RID: 3350 RVA: 0x00074B0B File Offset: 0x00072D0B
    private static bool GsMainSysIsSuspendedSystem()
    {
        return AppMain._am_sample_is_suspended;
    }

    // Token: 0x06000D17 RID: 3351 RVA: 0x00074B12 File Offset: 0x00072D12
    private static void GsMainSysSetSuspendedFlag( bool flag )
    {
        if ( flag )
        {
            AppMain.amFlagOn( ref AppMain.g_gs_main_sys_info.sys_flag, 1U );
            return;
        }
        AppMain.amFlagOff( ref AppMain.g_gs_main_sys_info.sys_flag, 1U );
    }

    // Token: 0x06000D18 RID: 3352 RVA: 0x00074B38 File Offset: 0x00072D38
    private static bool GsMainSysGetSuspendedFlag()
    {
        bool result = false;
        if ( ( AppMain.g_gs_main_sys_info.sys_flag & 1U ) != 0U )
        {
            result = true;
        }
        return result;
    }

    // Token: 0x06000D19 RID: 3353 RVA: 0x00074B58 File Offset: 0x00072D58
    private static void GsMainSysSetAccelFlag( bool flag )
    {
        AppMain._am_sample_is_accel = flag;
    }

    // Token: 0x06000D1A RID: 3354 RVA: 0x00074B60 File Offset: 0x00072D60
    public static void GsMainSysInfoInit( AppMain.GSS_MAIN_SYS_INFO gs_main )
    {
        gs_main.Clear();
        gs_main.sys_disp_width = 480f;
        gs_main.sys_disp_height = 320f;
        gs_main.level = 1;
        gs_main.backup.Init();
    }

    // Token: 0x06000D1B RID: 3355 RVA: 0x00074B90 File Offset: 0x00072D90
    private static bool GsMainSysIsStageClear( int stage_id )
    {
        if ( stage_id >= 21 )
        {
            uint index = (uint)(stage_id - 21);
            SSpecial sspecial = SSpecial.CreateInstance();
            if ( sspecial[( int )index].GetHighScore() != 1000000000U && sspecial[( int )index].IsGetEmerald() )
            {
                return true;
            }
            if ( sspecial[( int )index].GetFastTime() != 36000U )
            {
                return true;
            }
        }
        else
        {
            SStage sstage = SStage.CreateInstance();
            uint index;
            if ( stage_id >= 16 )
            {
                index = 16U;
            }
            else
            {
                index = ( uint )stage_id;
            }
            if ( sstage[( int )index].GetHighScore( false ) != 1000000000U )
            {
                return true;
            }
            if ( sstage[( int )index].GetHighScore( true ) != 1000000000U )
            {
                return true;
            }
            if ( sstage[( int )index].GetFastTime( false ) != 36000U )
            {
                return true;
            }
            if ( sstage[( int )index].GetFastTime( true ) != 36000U )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000D1C RID: 3356 RVA: 0x00074C54 File Offset: 0x00072E54
    private static bool GsMainSysIsStageSonicClear( int stage_id )
    {
        if ( stage_id >= 21 )
        {
            uint index = (uint)(stage_id - 21);
            SSpecial sspecial = SSpecial.CreateInstance();
            if ( sspecial[( int )index].GetHighScore() != 1000000000U && sspecial[( int )index].IsGetEmerald() )
            {
                return true;
            }
            if ( sspecial[( int )index].GetFastTime() != 36000U )
            {
                return true;
            }
        }
        else
        {
            SStage sstage = SStage.CreateInstance();
            uint index;
            if ( stage_id >= 16 )
            {
                index = 16U;
            }
            else
            {
                index = ( uint )stage_id;
            }
            if ( sstage[( int )index].GetHighScore( false ) != 1000000000U )
            {
                return true;
            }
            if ( sstage[( int )index].GetHighScore( true ) != 1000000000U )
            {
                return true;
            }
            if ( sstage[( int )index].GetFastTime( false ) != 36000U )
            {
                return true;
            }
            if ( sstage[( int )index].GetFastTime( true ) != 36000U )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000D1D RID: 3357 RVA: 0x00074D18 File Offset: 0x00072F18
    private static bool GsMainSysIsStageSuperSonicClear( int stage_id )
    {
        if ( stage_id > 20 )
        {
        }
        SStage sstage = SStage.CreateInstance();
        uint index;
        if ( stage_id >= 16 )
        {
            index = 16U;
        }
        else
        {
            index = ( uint )stage_id;
        }
        return sstage[( int )index].GetHighScore( true ) != 1000000000U || sstage[( int )index].GetFastTime( true ) != 36000U;
    }

    // Token: 0x06000D1E RID: 3358 RVA: 0x00074D70 File Offset: 0x00072F70
    private static bool GsMainSysIsStageGoalAsSuperSonic( int stage_id )
    {
        if ( stage_id > 20 )
        {
        }
        SStage sstage = SStage.CreateInstance();
        uint index;
        if ( stage_id >= 16 )
        {
            index = 16U;
        }
        else
        {
            index = ( uint )stage_id;
        }
        return sstage[( int )index].IsUseSuperSonicOnce();
    }

    // Token: 0x06000D1F RID: 3359 RVA: 0x00074DAC File Offset: 0x00072FAC
    private static bool GsMainSysIsStageScoreUploadOnce( int stage_id )
    {
        if ( stage_id >= 21 )
        {
            uint index = (uint)(stage_id - 21);
            SSpecial sspecial = SSpecial.CreateInstance();
            if ( sspecial[( int )index].IsScoreUploadedOnce() )
            {
                return true;
            }
        }
        else
        {
            SStage sstage = SStage.CreateInstance();
            uint index;
            if ( stage_id >= 16 )
            {
                index = 16U;
            }
            else
            {
                index = ( uint )stage_id;
            }
            if ( sstage[( int )index].IsScoreUploadedOnce() )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000D20 RID: 3360 RVA: 0x00074E00 File Offset: 0x00073000
    private static bool GsMainSysIsStageTimeUploadOnce( int stage_id )
    {
        if ( stage_id >= 21 )
        {
            uint index = (uint)(stage_id - 21);
            SSpecial sspecial = SSpecial.CreateInstance();
            if ( sspecial[( int )index].IsTimeUploadedOnce() )
            {
                return true;
            }
        }
        else
        {
            SStage sstage = SStage.CreateInstance();
            uint index;
            if ( stage_id >= 16 )
            {
                index = 16U;
            }
            else
            {
                index = ( uint )stage_id;
            }
            if ( sstage[( int )index].IsTimeUploadedOnce() )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000D21 RID: 3361 RVA: 0x00074E54 File Offset: 0x00073054
    private static bool GsMainSysIsSpecialStageClearedAct( int stage_id )
    {
        SSpecial sspecial = SSpecial.CreateInstance();
        for ( int i = 0; i < 7; i++ )
        {
            int num = (int)AppMain.gs_main_eme_get_act_no_tbl[(int)sspecial[i].GetEmeraldStage()];
            if ( stage_id == num )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000D22 RID: 3362 RVA: 0x00074E8F File Offset: 0x0007308F
    private static void GsMainSysLoadShader( string file_path )
    {
    }

    // Token: 0x06000D23 RID: 3363 RVA: 0x00074E91 File Offset: 0x00073091
    private static bool GsMainSysCheckLoadShaderFinished()
    {
        return true;
    }
}