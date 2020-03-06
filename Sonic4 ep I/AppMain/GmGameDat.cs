using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200014B RID: 331
    public enum GME_GAMEDAT_LOAD_PROGRESS
    {
        // Token: 0x04004D84 RID: 19844
        GMD_GAMEDAT_LOAD_PROGRESS_NOLOAD,
        // Token: 0x04004D85 RID: 19845
        GMD_GAMEDAT_LOAD_PROGRESS_LOADING,
        // Token: 0x04004D86 RID: 19846
        GMD_GAMEDAT_LOAD_PROGRESS_LOADFINISH,
        // Token: 0x04004D87 RID: 19847
        GMD_GAMEDAT_LOAD_PROGRESS_COMPLETE,
        // Token: 0x04004D88 RID: 19848
        GMD_GAMEDAT_LOAD_PROGRESS_MAX
    }

    // Token: 0x0200014C RID: 332
    public enum GME_GAMEDAT_ATTRSET
    {
        // Token: 0x04004D8A RID: 19850
        GMD_GAMEDAT_ATTRSET_AT,
        // Token: 0x04004D8B RID: 19851
        GMD_GAMEDAT_ATTRSET_DF,
        // Token: 0x04004D8C RID: 19852
        GMD_GAMEDAT_ATTRSET_DI,
        // Token: 0x04004D8D RID: 19853
        GMD_GAMEDAT_ATTRSET_MAX
    }

    // Token: 0x0200014D RID: 333
    public class GMS_GAMEDAT_LOAD_DATA
    {
        // Token: 0x060020BA RID: 8378 RVA: 0x0013F9EF File Offset: 0x0013DBEF
        public GMS_GAMEDAT_LOAD_DATA( string _path, AppMain.GMS_GAMEDAT_LOAD_DATA._alloc_ _alloc, AppMain.GMS_GAMEDAT_LOAD_DATA._proc_pre_ _proc_pre, AppMain.GMS_GAMEDAT_LOAD_DATA._proc_post_ _proc_post, int udata )
        {
            this.path = _path;
            this.alloc = _alloc;
            this.proc_pre = _proc_pre;
            this.proc_post = _proc_post;
            this.user_data = udata;
        }

        // Token: 0x04004D8E RID: 19854
        public string path;

        // Token: 0x04004D8F RID: 19855
        public AppMain.GMS_GAMEDAT_LOAD_DATA._alloc_ alloc;

        // Token: 0x04004D90 RID: 19856
        public AppMain.GMS_GAMEDAT_LOAD_DATA._proc_pre_ proc_pre;

        // Token: 0x04004D91 RID: 19857
        public AppMain.GMS_GAMEDAT_LOAD_DATA._proc_post_ proc_post;

        // Token: 0x04004D92 RID: 19858
        public int user_data;

        // Token: 0x0200014E RID: 334
        // (Invoke) Token: 0x060020BC RID: 8380
        public delegate object _alloc_( string s );

        // Token: 0x0200014F RID: 335
        // (Invoke) Token: 0x060020C0 RID: 8384
        public delegate void _proc_pre_( AppMain.GMS_GAMEDAT_LOAD_CONTEXT contex );

        // Token: 0x02000150 RID: 336
        // (Invoke) Token: 0x060020C4 RID: 8388
        public delegate void _proc_post_( AppMain.GMS_GAMEDAT_LOAD_CONTEXT contex );
    }

    // Token: 0x02000151 RID: 337
    public class GMS_GAMEDAT_LOAD_INFO
    {
        // Token: 0x060020C7 RID: 8391 RVA: 0x0013FA1C File Offset: 0x0013DC1C
        public GMS_GAMEDAT_LOAD_INFO( AppMain.GMS_GAMEDAT_LOAD_DATA[] _tbl, int _num )
        {
            this.data_tbl = _tbl;
            this.num = _num;
        }

        // Token: 0x04004D93 RID: 19859
        public AppMain.GMS_GAMEDAT_LOAD_DATA[] data_tbl;

        // Token: 0x04004D94 RID: 19860
        public int num;
    }

    // Token: 0x02000152 RID: 338
    public enum GME_GAMEDAT_LOAD_STATE
    {
        // Token: 0x04004D96 RID: 19862
        GMD_GAMEDAT_LOAD_STATE_LOADING,
        // Token: 0x04004D97 RID: 19863
        GMD_GAMEDAT_LOAD_STATE_LOADFINISH,
        // Token: 0x04004D98 RID: 19864
        GMD_GAMEDAT_LOAD_STATE_COMPLETE,
        // Token: 0x04004D99 RID: 19865
        GMD_GAMEDAT_LOAD_STATE_ERROR,
        // Token: 0x04004D9A RID: 19866
        GMD_GAMEDAT_LOAD_STATE_MAX
    }

    // Token: 0x02000153 RID: 339
    public class GMS_GAMEDAT_LOAD_CONTEXT
    {
        // Token: 0x060020C8 RID: 8392 RVA: 0x0013FA34 File Offset: 0x0013DC34
        internal void Clear()
        {
            this.state = AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_LOADING;
            this.file_path = "";
            this.bb_no = 0;
            this.fs_req = null;
            this.load_data = null;
            this.char_id = 0;
            this.ply_no = 0;
            this.stage_id = 0;
            this.data_no = 0;
        }

        // Token: 0x04004D9B RID: 19867
        public AppMain.GME_GAMEDAT_LOAD_STATE state;

        // Token: 0x04004D9C RID: 19868
        public string file_path;

        // Token: 0x04004D9D RID: 19869
        public int bb_no;

        // Token: 0x04004D9E RID: 19870
        public AppMain.AMS_FS fs_req;

        // Token: 0x04004D9F RID: 19871
        public AppMain.GMS_GAMEDAT_LOAD_DATA load_data;

        // Token: 0x04004DA0 RID: 19872
        public ushort char_id;

        // Token: 0x04004DA1 RID: 19873
        public ushort ply_no;

        // Token: 0x04004DA2 RID: 19874
        public ushort stage_id;

        // Token: 0x04004DA3 RID: 19875
        public ushort data_no;
    }

    // Token: 0x02000154 RID: 340
    public class GMS_GAMEDAT_LOAD_WORK
    {
        // Token: 0x060020CA RID: 8394 RVA: 0x0013FA8C File Offset: 0x0013DC8C
        internal void Clear()
        {
            for ( int i = 0; i < this.context.Length; i++ )
            {
                this.context[i].Clear();
            }
            this.proc_type = 0;
            this.load_finish = false;
            this.post_finish = false;
            this.stage_id = 0;
            for ( int j = 0; j < this.char_id.Length; j++ )
            {
                this.char_id[j] = 0;
            }
        }

        // Token: 0x04004DA4 RID: 19876
        public AppMain.GMS_GAMEDAT_LOAD_CONTEXT[] context = AppMain.New<AppMain.GMS_GAMEDAT_LOAD_CONTEXT>(AppMain.GMD_GAMEDAT_LOAD_CONTEXT_MAX);

        // Token: 0x04004DA5 RID: 19877
        public int context_num;

        // Token: 0x04004DA6 RID: 19878
        public int proc_type;

        // Token: 0x04004DA7 RID: 19879
        public bool load_finish;

        // Token: 0x04004DA8 RID: 19880
        public bool post_finish;

        // Token: 0x04004DA9 RID: 19881
        public ushort stage_id;

        // Token: 0x04004DAA RID: 19882
        public ushort[] char_id = new ushort[1];
    }


    // Token: 0x020001B7 RID: 439
    public enum GME_GAME_DBUILD_MDL_STATE
    {
        // Token: 0x04004FD8 RID: 20440
        GME_GAME_DBUILD_MDL_STATE_REG_WAIT,
        // Token: 0x04004FD9 RID: 20441
        GME_GAME_DBUILD_MDL_STATE_BUILD_WAIT,
        // Token: 0x04004FDA RID: 20442
        GME_GAME_DBUILD_MDL_STATE_REG_FLUSH_WAIT,
        // Token: 0x04004FDB RID: 20443
        GME_GAME_DBUILD_MDL_STATE_FLUSH_WAIT,
        // Token: 0x04004FDC RID: 20444
        GME_GAME_DBUILD_MDL_STATE_MAX
    }

    // Token: 0x020001B8 RID: 440
    public class GMS_GDBUILD_BUILD_MDL_WORK : AppMain.IClearable
    {
        // Token: 0x06002219 RID: 8729 RVA: 0x0014237C File Offset: 0x0014057C
        public void Clear()
        {
            this.build_state = AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_REG_WAIT;
            this.obj_3d_list = null;
            this.num = ( this.reg_num = 0 );
            this.mdl_amb = ( this.tex_amb = null );
            this.draw_flag = 0U;
            this.txb = null;
        }

        // Token: 0x04004FDD RID: 20445
        public AppMain.GME_GAME_DBUILD_MDL_STATE build_state;

        // Token: 0x04004FDE RID: 20446
        public AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_list;

        // Token: 0x04004FDF RID: 20447
        public int num;

        // Token: 0x04004FE0 RID: 20448
        public int reg_num;

        // Token: 0x04004FE1 RID: 20449
        public AppMain.AMS_AMB_HEADER mdl_amb;

        // Token: 0x04004FE2 RID: 20450
        public AppMain.AMS_AMB_HEADER tex_amb;

        // Token: 0x04004FE3 RID: 20451
        public uint draw_flag;

        // Token: 0x04004FE4 RID: 20452
        public AppMain.TXB_HEADER txb;
    }

    // Token: 0x020001B9 RID: 441
    // (Invoke) Token: 0x0600221C RID: 8732
    public delegate void gamedat_build_area_func();

    // Token: 0x060005AD RID: 1453 RVA: 0x00032F4E File Offset: 0x0003114E
    public static AppMain.AMS_AMB_HEADER GmGameDatGetCockpitData()
    {
        return AppMain.g_gm_gamedat_cockpit_main_arc;
    }

    // Token: 0x060005AE RID: 1454 RVA: 0x00032F5C File Offset: 0x0003115C
    public static void GmGameDatLoadInit( int proc_type, ushort stage_id, short[] char_id_list )
    {
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(AppMain.gmDataLoadMain), new AppMain.GSF_TASK_PROCEDURE(AppMain.gmDataLoadDest), 0U, ushort.MaxValue, 2048U, 5, () => new AppMain.GMS_GAMEDAT_LOAD_WORK(), "GM_LOAD");
        AppMain.gm_gamedat_load_tcb = mts_TASK_TCB;
        AppMain.GMS_GAMEDAT_LOAD_WORK gms_GAMEDAT_LOAD_WORK = (AppMain.GMS_GAMEDAT_LOAD_WORK)mts_TASK_TCB.work;
        AppMain.gm_gamedat_load_work = gms_GAMEDAT_LOAD_WORK;
        gms_GAMEDAT_LOAD_WORK.Clear();
        AppMain.gm_gamedat_load_work.stage_id = stage_id;
        int i = 0;
        while ( ( long )i < 1L )
        {
            gms_GAMEDAT_LOAD_WORK.char_id[i] = ( ushort )char_id_list[i];
            i++;
        }
        gms_GAMEDAT_LOAD_WORK.proc_type = proc_type;
        AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_CONTEXT> pointer = new AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_CONTEXT>(gms_GAMEDAT_LOAD_WORK.context);
        AppMain.GMS_GAMEDAT_LOAD_INFO gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_common_info_tbl[0];
        i = 0;
        while ( i < gms_GAMEDAT_LOAD_INFO.num )
        {
            ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
            ( ~pointer ).data_no = ( ushort )i;
            AppMain.gmGameDatLoad( pointer );
            i++;
            pointer = ++pointer;
            gms_GAMEDAT_LOAD_WORK.context_num++;
        }
        int num = 0;
        while ( ( long )num < 1L )
        {
            if ( gms_GAMEDAT_LOAD_WORK.char_id[num] != 32767 )
            {
                gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_player_info_tbl[( int )gms_GAMEDAT_LOAD_WORK.char_id[num]];
                i = 0;
                while ( i < gms_GAMEDAT_LOAD_INFO.num )
                {
                    ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
                    ( ~pointer ).char_id = gms_GAMEDAT_LOAD_WORK.char_id[num];
                    ( ~pointer ).ply_no = ( ushort )num;
                    ( ~pointer ).data_no = ( ushort )i;
                    AppMain.gmGameDatLoad( pointer );
                    i++;
                    pointer = ++pointer;
                    gms_GAMEDAT_LOAD_WORK.context_num++;
                }
            }
            num++;
        }
        gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_map_info_tbl[( int )stage_id];
        i = 0;
        while ( i < gms_GAMEDAT_LOAD_INFO.num )
        {
            ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
            ( ~pointer ).stage_id = stage_id;
            ( ~pointer ).data_no = ( ushort )i;
            AppMain.gmGameDatLoad( pointer );
            i++;
            pointer = ++pointer;
            gms_GAMEDAT_LOAD_WORK.context_num++;
        }
        gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_effect_info_tbl[( int )stage_id];
        i = 0;
        while ( i < gms_GAMEDAT_LOAD_INFO.num )
        {
            ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
            ( ~pointer ).stage_id = stage_id;
            AppMain.gmGameDatLoad( pointer );
            i++;
            pointer = ++pointer;
            gms_GAMEDAT_LOAD_WORK.context_num++;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 )
        {
            gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_enemy_info_tbl[( int )stage_id];
            i = 0;
            while ( i < gms_GAMEDAT_LOAD_INFO.num )
            {
                ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
                ( ~pointer ).stage_id = stage_id;
                AppMain.gmGameDatLoad( pointer );
                i++;
                pointer = ++pointer;
                gms_GAMEDAT_LOAD_WORK.context_num++;
            }
        }
        gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_gimmick_common_info_tbl[0];
        i = 0;
        while ( i < gms_GAMEDAT_LOAD_INFO.num )
        {
            ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
            ( ~pointer ).stage_id = stage_id;
            AppMain.gmGameDatLoad( pointer );
            i++;
            pointer = ++pointer;
            gms_GAMEDAT_LOAD_WORK.context_num++;
        }
        gms_GAMEDAT_LOAD_INFO = AppMain.gm_gamedat_tbl_gimmick_info_tbl[( int )stage_id];
        i = 0;
        while ( i < gms_GAMEDAT_LOAD_INFO.num )
        {
            ( ~pointer ).load_data = gms_GAMEDAT_LOAD_INFO.data_tbl[i];
            ( ~pointer ).stage_id = stage_id;
            AppMain.gmGameDatLoad( pointer );
            i++;
            pointer = ++pointer;
            gms_GAMEDAT_LOAD_WORK.context_num++;
        }
    }

    // Token: 0x060005AF RID: 1455 RVA: 0x00033320 File Offset: 0x00031520
    public static void GmGameDatLoadPost()
    {
        AppMain.GMS_GAMEDAT_LOAD_WORK gms_GAMEDAT_LOAD_WORK = AppMain.gm_gamedat_load_work;
        if ( gms_GAMEDAT_LOAD_WORK == null )
        {
            return;
        }
        gms_GAMEDAT_LOAD_WORK.proc_type = 0;
    }

    // Token: 0x060005B0 RID: 1456 RVA: 0x0003333E File Offset: 0x0003153E
    public static AppMain.GME_GAMEDAT_LOAD_PROGRESS GmGameDatLoadCheck()
    {
        if ( AppMain.gm_gamedat_load_work == null )
        {
            return AppMain.GME_GAMEDAT_LOAD_PROGRESS.GMD_GAMEDAT_LOAD_PROGRESS_NOLOAD;
        }
        if ( AppMain.gm_gamedat_load_work.post_finish )
        {
            return AppMain.GME_GAMEDAT_LOAD_PROGRESS.GMD_GAMEDAT_LOAD_PROGRESS_COMPLETE;
        }
        if ( AppMain.gm_gamedat_load_work.load_finish )
        {
            return AppMain.GME_GAMEDAT_LOAD_PROGRESS.GMD_GAMEDAT_LOAD_PROGRESS_LOADFINISH;
        }
        return AppMain.GME_GAMEDAT_LOAD_PROGRESS.GMD_GAMEDAT_LOAD_PROGRESS_LOADING;
    }

    // Token: 0x060005B1 RID: 1457 RVA: 0x00033366 File Offset: 0x00031566
    public static void GmGameDatLoadExit()
    {
        if ( AppMain.gm_gamedat_load_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_gamedat_load_tcb );
        }
    }

    // Token: 0x060005B2 RID: 1458 RVA: 0x00033379 File Offset: 0x00031579
    public static void GmGameDatRelease()
    {
        AppMain.GmGameDatReleaseStandard();
        AppMain.GmGameDatReleaseArea();
    }

    // Token: 0x060005B3 RID: 1459 RVA: 0x00033388 File Offset: 0x00031588
    public static void GmGameDatReleaseStandard()
    {
        AppMain.GmPlayerRelease();
        if ( AppMain.g_gm_gamedat_cockpit_main_arc != null )
        {
            AppMain.g_gm_gamedat_cockpit_main_arc = null;
        }
        for ( int i = 0; i < 3; i++ )
        {
            if ( AppMain.g_gm_gamedat_ring[i] != null )
            {
                AppMain.g_gm_gamedat_ring[i] = null;
            }
        }
    }

    // Token: 0x060005B4 RID: 1460 RVA: 0x000333C4 File Offset: 0x000315C4
    public static void GmGameDatReleaseArea()
    {
        AppMain.GmMapRelease();
        AppMain.GmMapFarRelease();
        AppMain.GmDecoRelease();
        AppMain.GmWaterSurfaceRelease();
        for ( int i = 0; i < 11; i++ )
        {
            if ( AppMain.g_gm_gamedat_effect[i] != null )
            {
                AppMain.g_gm_gamedat_effect[i] = null;
            }
        }
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 )
        {
            for ( int i = 0; i < 44; i++ )
            {
                if ( AppMain.g_gm_gamedat_enemy[i] != null )
                {
                    AppMain.g_gm_gamedat_enemy[i] = null;
                }
            }
        }
        if ( AppMain.g_gm_gamedat_enemy_arc != null )
        {
            AppMain.g_gm_gamedat_enemy_arc = null;
        }
        for ( int i = 0; i < 204; i++ )
        {
            if ( AppMain.g_gm_gamedat_gimmick[i] != null )
            {
                AppMain.g_gm_gamedat_gimmick[i] = null;
            }
        }
    }

    // Token: 0x060005B5 RID: 1461 RVA: 0x0003345D File Offset: 0x0003165D
    public static bool GmGameDatReleaseCheck()
    {
        return true;
    }

    // Token: 0x060005B6 RID: 1462 RVA: 0x00033460 File Offset: 0x00031660
    public static object GmGameDatGetEnemyData( int data_no )
    {
        return AppMain.g_gm_gamedat_enemy[data_no - 658];
    }

    // Token: 0x060005B7 RID: 1463 RVA: 0x0003346F File Offset: 0x0003166F
    public static AppMain.AMS_AMB_HEADER GmGameDatGetGimmickData( int data_no )
    {
        return AppMain.g_gm_gamedat_gimmick[data_no - 789];
    }

    // Token: 0x060005B8 RID: 1464 RVA: 0x00033488 File Offset: 0x00031688
    private static void GmGameDatLoadBoosBattleInit( int boss_type )
    {
        ushort num = (ushort)AppMain.g_gm_gamedat_bossbattle_stage_id_tbl[boss_type];
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(AppMain.gmDataLoadMain), new AppMain.GSF_TASK_PROCEDURE(AppMain.gmDataLoadDest), 0U, ushort.MaxValue, 2048U, 5, () => new AppMain.GMS_GAMEDAT_LOAD_WORK(), "GM_LOAD_BB");
        AppMain.gm_gamedat_load_tcb = mts_TASK_TCB;
        AppMain.GMS_GAMEDAT_LOAD_WORK gms_GAMEDAT_LOAD_WORK = (AppMain.GMS_GAMEDAT_LOAD_WORK)mts_TASK_TCB.work;
        AppMain.gm_gamedat_load_work = gms_GAMEDAT_LOAD_WORK;
        gms_GAMEDAT_LOAD_WORK.Clear();
        AppMain.gm_gamedat_load_work.stage_id = num;
        gms_GAMEDAT_LOAD_WORK.proc_type = 0;
        AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_CONTEXT> pointer = new AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_CONTEXT>(gms_GAMEDAT_LOAD_WORK.context);
        AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_INFO> pointer2 = new AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_INFO>(AppMain.gm_gamedat_tbl_enemy_final_info_tbl, (int)num);
        int i = 0;
        AppMain.ArrayPointer<AppMain.GMS_GAMEDAT_LOAD_DATA> pointer3 = (~pointer2).data_tbl;
        while ( i < ( ~pointer2 ).num )
        {
            ( ~pointer ).load_data = pointer3;
            ( ~pointer ).stage_id = num;
            AppMain.gmGameDatLoad( pointer );
            i++;
            pointer = ++pointer;
            pointer3 = ++pointer3;
            gms_GAMEDAT_LOAD_WORK.context_num++;
        }
    }

    // Token: 0x060005B9 RID: 1465 RVA: 0x000335AC File Offset: 0x000317AC
    public static void GmGameDatBoosBattleRelease( int boss_type )
    {
        int num = AppMain.g_gm_gamedat_bossbattle_stage_id_tbl[boss_type];
        for ( int i = 0; i < 44; i++ )
        {
            if ( AppMain.g_gm_gamedat_enemy[i] != null )
            {
                AppMain.g_gm_gamedat_enemy[i] = null;
            }
        }
        if ( AppMain.g_gm_gamedat_enemy_arc != null )
        {
            AppMain.g_gm_gamedat_enemy_arc = null;
        }
    }

    // Token: 0x060005BA RID: 1466 RVA: 0x000335EC File Offset: 0x000317EC
    public static void gmDataLoadMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GAMEDAT_LOAD_WORK gms_GAMEDAT_LOAD_WORK = (AppMain.GMS_GAMEDAT_LOAD_WORK)tcb.work;
        AppMain.GME_GAMEDAT_LOAD_STATE gme_GAMEDAT_LOAD_STATE;
        if ( gms_GAMEDAT_LOAD_WORK.proc_type == 1 )
        {
            gme_GAMEDAT_LOAD_STATE = AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_LOADFINISH;
        }
        else
        {
            gme_GAMEDAT_LOAD_STATE = AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_COMPLETE;
        }
        for ( int i = 0; i < gms_GAMEDAT_LOAD_WORK.context_num; i++ )
        {
            AppMain.GME_GAMEDAT_LOAD_STATE gme_GAMEDAT_LOAD_STATE2 = AppMain.gmGameDatLoad(gms_GAMEDAT_LOAD_WORK.context[i]);
            if ( gme_GAMEDAT_LOAD_STATE2 < gme_GAMEDAT_LOAD_STATE )
            {
                return;
            }
        }
        gms_GAMEDAT_LOAD_WORK.load_finish = true;
        if ( gms_GAMEDAT_LOAD_WORK.proc_type == 1 )
        {
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmDataLoadMainPostWait ) );
            return;
        }
        gms_GAMEDAT_LOAD_WORK.post_finish = true;
        AppMain.mtTaskChangeTcbProcedure( tcb, null );
    }

    // Token: 0x060005BB RID: 1467 RVA: 0x0003366C File Offset: 0x0003186C
    public static void gmDataLoadMainPostWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GAMEDAT_LOAD_WORK gms_GAMEDAT_LOAD_WORK = (AppMain.GMS_GAMEDAT_LOAD_WORK)tcb.work;
        if ( gms_GAMEDAT_LOAD_WORK.proc_type == 0 )
        {
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmDataLoadMain ) );
            AppMain.gmDataLoadMain( tcb );
        }
    }

    // Token: 0x060005BC RID: 1468 RVA: 0x000336A5 File Offset: 0x000318A5
    public static void gmDataLoadDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_gamedat_load_tcb = null;
        AppMain.gm_gamedat_load_work = null;
    }

    // Token: 0x060005BD RID: 1469 RVA: 0x000336B3 File Offset: 0x000318B3
    public static object gmGameDatLoadAllocHead( string path )
    {
        return null;
    }

    // Token: 0x060005BE RID: 1470 RVA: 0x000336B6 File Offset: 0x000318B6
    public static object gmGameDatLoadAllocHeadSub( string path )
    {
        return null;
    }

    // Token: 0x060005BF RID: 1471 RVA: 0x000336B9 File Offset: 0x000318B9
    public static AppMain.GME_GAMEDAT_LOAD_STATE gmGameDatLoad( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        return AppMain.gmGameDatLoadFileReq( context );
    }

    // Token: 0x060005C0 RID: 1472 RVA: 0x000336C4 File Offset: 0x000318C4
    public static AppMain.GME_GAMEDAT_LOAD_STATE gmGameDatLoadFileReq( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        if ( context.state == AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_COMPLETE || context.state == AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_ERROR )
        {
            return context.state;
        }
        AppMain.GMS_GAMEDAT_LOAD_DATA load_data = context.load_data;
        if ( context.fs_req == null )
        {
            context.file_path = load_data.path;
            if ( load_data.proc_pre != null )
            {
                load_data.proc_pre( context );
            }
            int stage_id = (int)context.stage_id;
            if ( ( 7 == stage_id && "G_ZONE2/BOSS/BOSS02.AMB" == context.file_path ) || ( 11 == stage_id && "G_ZONE3/BOSS/BOSS03.AMB" == context.file_path ) || ( 15 == stage_id && "G_ZONEF/BOSS/BOSS04.AMB" == context.file_path ) || ( 16 == stage_id && "G_ZONEF/BOSS/BOSS05.AMB" == context.file_path ) )
            {
                context.fs_req = AppMain.amFsReadBackground( context.file_path, 8192 );
            }
            else
            {
                context.fs_req = AppMain.amFsReadBackground( context.file_path, 65536 );
            }
            context.state = AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_LOADING;
        }
        else if ( AppMain.amFsIsComplete( context.fs_req ) )
        {
            context.state = AppMain.GME_GAMEDAT_LOAD_STATE.GMD_GAMEDAT_LOAD_STATE_COMPLETE;
            if ( AppMain.gm_gamedat_load_work.proc_type != 1 && context.fs_req != null )
            {
                if ( load_data.proc_post != null )
                {
                    load_data.proc_post( context );
                }
                AppMain.amFsClearRequest( context.fs_req );
                context.fs_req = null;
            }
        }
        return context.state;
    }

    // Token: 0x060005C1 RID: 1473 RVA: 0x0003380A File Offset: 0x00031A0A
    public static void gmGameDatLoadProcPostRing( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_ring[context.load_data.user_data - 2] = context.fs_req;
        context.fs_req = null;
    }

    // Token: 0x060005C2 RID: 1474 RVA: 0x0003382C File Offset: 0x00031A2C
    public static void gmGameDatLoadProcPostPlayer( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.ObjDataSet( AppMain.g_gm_player_data_work[( int )context.ply_no][( int )context.data_no], context.fs_req );
        context.fs_req = null;
    }

    // Token: 0x060005C3 RID: 1475 RVA: 0x00033854 File Offset: 0x00031A54
    public static void gmGameDatLoadProcPostCockpit( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_cockpit_main_arc = AppMain.readAMBFile( context.fs_req );
        context.fs_req = null;
    }

    // Token: 0x060005C4 RID: 1476 RVA: 0x00033870 File Offset: 0x00031A70
    public static void gmGameDatLoadProcPostMap( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_map[( int )context.data_no] = AppMain.readAMBFile( context.fs_req );
        switch ( context.data_no )
        {
            case 0:
                {
                    AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(context.fs_req);
                    int i = 0;
                    while ( i < 9 && i < ams_AMB_HEADER.file_num )
                    {
                        switch ( i )
                        {
                            case 0:
                            case 1:
                            case 4:
                            case 5:
                                AppMain.g_gm_gamedat_map_set[i] = AppMain.readMPFile( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER, i ) );
                                break;
                            case 2:
                            case 3:
                                AppMain.g_gm_gamedat_map_set[i] = AppMain.readMDFile( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER, i ) );
                                break;
                            default:
                                AppMain.g_gm_gamedat_map_set[i] = AppMain.amBindGet( ams_AMB_HEADER, i );
                                break;
                        }
                        i++;
                    }
                    for ( i = 0; i < 10; i += 2 )
                    {
                        if ( ams_AMB_HEADER.file_num >= 11 + i )
                        {
                            AppMain.g_gm_gamedat_map_set_add[i] = AppMain.readMPFile( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER, 9 + i ) );
                            AppMain.g_gm_gamedat_map_set_add[i + 1] = AppMain.readMDFile( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER, 9 + i + 1 ) );
                        }
                        else
                        {
                            AppMain.g_gm_gamedat_map_set_add[i] = null;
                            AppMain.g_gm_gamedat_map_set_add[i + 1] = null;
                        }
                    }
                    break;
                }
            case 1:
                {
                    AppMain.AMS_AMB_HEADER ams_AMB_HEADER2 = (AppMain.AMS_AMB_HEADER)AppMain.g_gm_gamedat_map[(int)context.data_no];
                    AppMain.TVX_FILE[] array = new AppMain.TVX_FILE[ams_AMB_HEADER2.file_num];
                    for ( int j = 0; j < ams_AMB_HEADER2.file_num; j++ )
                    {
                        array[j] = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER2, j ) );
                    }
                    if ( AppMain.g_gs_main_sys_info.stage_id >= 0 && AppMain.g_gs_main_sys_info.stage_id <= 3 )
                    {
                        for ( int k = 0; k < ams_AMB_HEADER2.file_num; k++ )
                        {
                            float num = array[k].vertexes[0][0].x;
                            float num2 = array[k].vertexes[0][0].x;
                            float num3 = array[k].vertexes[0][0].y;
                            float num4 = array[k].vertexes[0][0].y;
                            for ( int l = 1; l < array[k].vertexes[0].Length; l++ )
                            {
                                num = Math.Min( num, array[k].vertexes[0][l].x );
                                num2 = Math.Max( num2, array[k].vertexes[0][l].x );
                                num3 = Math.Min( num3, array[k].vertexes[0][l].y );
                                num4 = Math.Max( num4, array[k].vertexes[0][l].y );
                            }
                            for ( int m = 0; m < array[k].vertexes[0].Length; m++ )
                            {
                                if ( array[k].vertexes[0][m].x == num )
                                {
                                    AppMain.AOS_TVX_VERTEX[] array2 = array[k].vertexes[0];
                                    int num5 = m;
                                    array2[num5].x = array2[num5].x - 0.5f;
                                }
                                else if ( array[k].vertexes[0][m].x == num2 )
                                {
                                    AppMain.AOS_TVX_VERTEX[] array3 = array[k].vertexes[0];
                                    int num6 = m;
                                    array3[num6].x = array3[num6].x + 0.5f;
                                }
                                if ( array[k].vertexes[0][m].y == num3 )
                                {
                                    AppMain.AOS_TVX_VERTEX[] array4 = array[k].vertexes[0];
                                    int num7 = m;
                                    array4[num7].y = array4[num7].y - 0.5f;
                                }
                                else if ( array[k].vertexes[0][m].y == num4 )
                                {
                                    AppMain.AOS_TVX_VERTEX[] array5 = array[k].vertexes[0];
                                    int num8 = m;
                                    array5[num8].y = array5[num8].y + 0.5f;
                                }
                            }
                        }
                        if ( AppMain.g_gs_main_sys_info.stage_id == 2 )
                        {
                            array[103].vertexes[0][1].x = 63.5f;
                            array[103].vertexes[0][3].x = 63.5f;
                        }
                    }
                    if ( AppMain.g_gs_main_sys_info.stage_id >= 4 && AppMain.g_gs_main_sys_info.stage_id <= 7 )
                    {
                        array[201].vertexes[1][1].x = 64f;
                        array[201].vertexes[1][3].x = 64f;
                    }
                    if ( AppMain.g_gs_main_sys_info.stage_id >= 8 && AppMain.g_gs_main_sys_info.stage_id <= 11 )
                    {
                        for ( int n = 59; n <= 62; n++ )
                        {
                            array[n].vertexes[0][0].x = 64.5f;
                            array[n].vertexes[0][2].x = 64.5f;
                            array[n].vertexes[0][0].y = 64.5f;
                            array[n].vertexes[0][1].y = 64.5f;
                            array[n].vertexes[0][1].x = -0.5f;
                            array[n].vertexes[0][3].x = -0.5f;
                            array[n].vertexes[0][2].y = -0.5f;
                            array[n].vertexes[0][3].y = -0.5f;
                        }
                    }
                    AppMain.g_gm_gamedat_map[( int )context.data_no] = array;
                    break;
                }
            case 2:
                break;
            case 3:
                {
                    AppMain.AMS_AMB_HEADER ams_AMB_HEADER3 = AppMain.readAMBFile(context.fs_req);
                    int num9 = 0;
                    while ( num9 < 3 && num9 < ams_AMB_HEADER3.file_num )
                    {
                        AppMain.g_gm_gamedat_map_attr_set[num9] = AppMain.amBindGet( ams_AMB_HEADER3, num9 );
                        num9++;
                    }
                    break;
                }
            default:
                return;
        }
        context.fs_req = null;
    }

    // Token: 0x060005C5 RID: 1477 RVA: 0x00033E45 File Offset: 0x00032045
    public static void gmGameDatLoadProcPostMapFar( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.GmMapFarInitData( AppMain.readAMBFile( context.fs_req ) );
        context.fs_req = null;
    }

    // Token: 0x060005C6 RID: 1478 RVA: 0x00033E5E File Offset: 0x0003205E
    public static void gmGameDatLoadProcPostEffect( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_effect[context.load_data.user_data - 5] = AppMain.readAMBFile( context.fs_req );
        context.fs_req = null;
    }

    // Token: 0x060005C7 RID: 1479 RVA: 0x00033E85 File Offset: 0x00032085
    public static void gmGameDatLoadProcPostEnemy( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_enemy[context.load_data.user_data - 658] = context.fs_req;
        context.fs_req = null;
    }

    // Token: 0x060005C8 RID: 1480 RVA: 0x00033EAB File Offset: 0x000320AB
    public static void gmGameDatLoadProcPostBoss( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_enemy_arc = AppMain.readAMBFile( context.fs_req );
        context.fs_req = null;
    }

    // Token: 0x060005C9 RID: 1481 RVA: 0x00033EC4 File Offset: 0x000320C4
    public static void gmGameDatLoadProcPostGimmick( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.g_gm_gamedat_gimmick[context.load_data.user_data - 789] = AppMain.readAMBFile( context.fs_req );
        context.fs_req = null;
    }

    // Token: 0x060005CA RID: 1482 RVA: 0x00033EEF File Offset: 0x000320EF
    public static void gmGameDatLoadProcPostDeco( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.GmDecoInitData( AppMain.readAMBFile( context.fs_req ) );
        context.fs_req = null;
    }

    // Token: 0x060005CB RID: 1483 RVA: 0x00033F08 File Offset: 0x00032108
    public static void gmGameDatLoadProcPostWaterSurface( AppMain.GMS_GAMEDAT_LOAD_CONTEXT context )
    {
        AppMain.GmWaterSurfaceInitData( AppMain.readAMBFile( context.fs_req ) );
        context.fs_req = null;
    }


    // Token: 0x060008E8 RID: 2280 RVA: 0x0005196C File Offset: 0x0004FB6C
    private static void GmGameDatBuildInit()
    {
        AppMain.ObjLoadSetInitDrawFlag( true );
        AppMain.GmGameDBuildModelBuildInit();
        for ( int i = 0; i < 44; i++ )
        {
            if ( AppMain.g_gm_gamedat_enemy[i] != null )
            {
                AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(658 + i);
                AppMain.ObjDataSet( obs_DATA_WORK, AppMain.g_gm_gamedat_enemy[i] );
                AppMain.OBS_DATA_WORK obs_DATA_WORK2 = obs_DATA_WORK;
                obs_DATA_WORK2.num |= 32768;
            }
        }
        for ( int i = 0; i < 204; i++ )
        {
            if ( AppMain.g_gm_gamedat_gimmick[i] != null )
            {
                AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(789 + i);
                AppMain.ObjDataSet( obs_DATA_WORK, AppMain.g_gm_gamedat_gimmick[i] );
                AppMain.OBS_DATA_WORK obs_DATA_WORK3 = obs_DATA_WORK;
                obs_DATA_WORK3.num |= 32768;
            }
        }
        for ( int i = 0; i < 3; i++ )
        {
            if ( AppMain.g_gm_gamedat_ring[i] != null )
            {
                AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(2 + i);
                AppMain.ObjDataSet( obs_DATA_WORK, AppMain.g_gm_gamedat_ring[i] );
                AppMain.OBS_DATA_WORK obs_DATA_WORK4 = obs_DATA_WORK;
                obs_DATA_WORK4.num |= 32768;
            }
        }
        for ( int i = 0; i < 11; i++ )
        {
            if ( AppMain.g_gm_gamedat_effect[i] != null )
            {
                AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(5 + i);
                AppMain.ObjDataSet( obs_DATA_WORK, AppMain.g_gm_gamedat_effect[i] );
                AppMain.OBS_DATA_WORK obs_DATA_WORK5 = obs_DATA_WORK;
                obs_DATA_WORK5.num |= 32768;
            }
        }
    }

    // Token: 0x060008E9 RID: 2281 RVA: 0x00051A8E File Offset: 0x0004FC8E
    private static void GmGameDatBuildStandard()
    {
        AppMain.GmPlayerBuild();
        AppMain.GmSoundBuild();
        AppMain.GmFixBuildDataInit();
        AppMain.GmClearDemoBuild();
        AppMain.GmStartDemoBuild();
        AppMain.GmOverBuildDataInit();
        AppMain.GmPauseMenuBuildStart();
        AppMain.GmEfctCmnBuildDataInit();
        AppMain.GmRingBuild();
    }

    // Token: 0x060008EA RID: 2282 RVA: 0x00051AC0 File Offset: 0x0004FCC0
    private static void GmGameDatBuildArea()
    {
        AppMain.GmTvxBuild();
        AppMain.GmMapBuildDataInit();
        AppMain.GmMapBuildColData();
        AppMain.GmMapFarBuildData();
        AppMain.GmDecoBuildData();
        AppMain.GmWaterSurfaceBuildData();
        AppMain.GmEventDataBuild();
        AppMain.GmGmkSpringBuild();
        AppMain.GmGmkDashPanelBuild();
        AppMain.GmGmkGoalPanelBuild();
        AppMain.GmGmkItemBuild();
        AppMain.GmGmkNeedleBuild();
        AppMain.GmGmkPointMarkerBuild();
        AppMain.GmGmkAnimalBuild();
        AppMain.GmGmkSplRingBuild();
        if ( AppMain.g_gs_main_sys_info.stage_id == 11 || ( !AppMain.GMM_MAIN_STAGE_IS_BOSS() && !AppMain.GMM_MAIN_STAGE_IS_SS() && !AppMain.GMM_MAIN_STAGE_IS_ENDING() ) )
        {
            AppMain.GmEneHariSenboBuild();
        }
        AppMain.GmEfctBossBuildSingleDataInit();
        if ( AppMain.gm_gamedat_build_area_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] != null )
        {
            AppMain.gm_gamedat_build_area_tbl[( int )AppMain.g_gs_main_sys_info.stage_id]();
        }
    }

    // Token: 0x060008EB RID: 2283 RVA: 0x00051B6C File Offset: 0x0004FD6C
    private static bool GmGameDatBuildStandardCheck()
    {
        return AppMain.GmPlayerBuildCheck() && AppMain.GmSoundBuildCheck() && AppMain.GmRingBuildCheck() != 0 && AppMain.GmFixBuildDataLoop() && AppMain.GmClearDemoBuildCheck() && AppMain.GmStartDemoBuildCheck() && AppMain.GmOverBuildDataLoop() && AppMain.GmPauseMenuBuildIsFinished() && AppMain.GmEfctCmnBuildDataLoop();
    }

    // Token: 0x060008EC RID: 2284 RVA: 0x00051BCC File Offset: 0x0004FDCC
    private static bool GmGameDatBuildAreaCheck()
    {
        bool result = true;
        if ( !AppMain.GmMapBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmMapFarCheckLoading() )
        {
            result = false;
        }
        if ( !AppMain.GmDecoCheckLoading() )
        {
            result = false;
        }
        if ( !AppMain.GmWaterSurfaceCheckLoading() )
        {
            result = false;
        }
        if ( !AppMain.GmGameDBuildCheckBuildModel() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctZoneBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctEneBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossCmnBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossBuildSingleDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmStartMsgBuildCheck() )
        {
            result = false;
        }
        return result;
    }

    // Token: 0x060008ED RID: 2285 RVA: 0x00051C36 File Offset: 0x0004FE36
    private static void GmGameDatFlushInit()
    {
        AppMain.ObjLoadSetInitDrawFlag( false );
        AppMain.GmGameDBuildModelFlushInit();
    }

    // Token: 0x060008EE RID: 2286 RVA: 0x00051C43 File Offset: 0x0004FE43
    private static void GmGameDatFlushStandard()
    {
        AppMain.GmRingFlush();
        AppMain.GmEfctCmnFlushDataInit();
        AppMain.GmPauseMenuFlushStart();
        AppMain.GmOverFlushDataInit();
        AppMain.GmStartDemoFlush();
        AppMain.GmClearDemoFlush();
        AppMain.GmFixFlushDataInit();
        AppMain.GmSoundFlush();
        AppMain.GmPlayerFlush();
    }

    // Token: 0x060008EF RID: 2287 RVA: 0x00051C74 File Offset: 0x0004FE74
    private static void GmGameDatFlushArea()
    {
        if ( AppMain.gm_gamedat_flush_area_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] != null )
        {
            AppMain.gm_gamedat_flush_area_tbl[( int )AppMain.g_gs_main_sys_info.stage_id]();
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 11 || ( !AppMain.GMM_MAIN_STAGE_IS_BOSS() && !AppMain.GMM_MAIN_STAGE_IS_SS() && !AppMain.GMM_MAIN_STAGE_IS_ENDING() ) )
        {
            AppMain.GmEneHariSenboFlush();
        }
        AppMain.GmGmkSplRingFlush();
        AppMain.GmGmkAnimalFlush();
        AppMain.GmGmkPointMarkerFlush();
        AppMain.GmGmkNeedleFlush();
        AppMain.GmGmkItemFlush();
        AppMain.GmGmkGoalPanelFlush();
        AppMain.GmGmkDashPanelFlush();
        AppMain.GmGmkSpringFlush();
        AppMain.GmEventDataFlush();
        AppMain.GmWaterSurfaceFlushData();
        AppMain.GmDecoFlushData();
        AppMain.GmMapFarFlushData();
        AppMain.GmMapFlushColData();
        AppMain.GmMapFlushData();
        AppMain.GmTvxFlush();
    }

    // Token: 0x060008F0 RID: 2288 RVA: 0x00051D1C File Offset: 0x0004FF1C
    private static bool GmGameDatFlushStandardCheck()
    {
        return AppMain.GmRingFlushCheck() != 0 && AppMain.GmEfctCmnFlushDataLoop() && AppMain.GmFixFlushDataLoop() && AppMain.GmStartDemoFlushCheck() && AppMain.GmClearDemoFlushCheck() && AppMain.GmOverFlushDataLoop() && AppMain.GmPauseMenuFlushIsFinished() && AppMain.GmGameDBuildCheckFlushModel() && AppMain.GmWaterSurfaceCheckFlush() && AppMain.GmPlayerFlushCheck();
    }

    // Token: 0x060008F1 RID: 2289 RVA: 0x00051D84 File Offset: 0x0004FF84
    private static bool GmGameDatFlushAreaCheck()
    {
        bool result = true;
        if ( !AppMain.GmStartMsgFlushCheck() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctZoneFlushDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctEneFlushDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossCmnFlushDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossFlushSingleDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmMapFlushDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmDecoCheckFlushing() )
        {
            result = false;
        }
        return result;
    }

    // Token: 0x060008F2 RID: 2290 RVA: 0x00051DD4 File Offset: 0x0004FFD4
    private static void GmGameDatBuildBossBattleInit()
    {
        AppMain.GmGameDBuildModelBuildInit();
        for ( int i = 0; i < 44; i++ )
        {
            if ( AppMain.g_gm_gamedat_enemy[i] != null )
            {
                AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(658 + i);
                AppMain.ObjDataSet( obs_DATA_WORK, AppMain.g_gm_gamedat_enemy[i] );
                AppMain.OBS_DATA_WORK obs_DATA_WORK2 = obs_DATA_WORK;
                obs_DATA_WORK2.num |= 32768;
            }
        }
    }

    // Token: 0x060008F3 RID: 2291 RVA: 0x00051E2A File Offset: 0x0005002A
    private static void GmGameDatBuildBossBattle( int boss_type )
    {
        int num = AppMain.g_gm_gamedat_bossbattle_stage_id_tbl[boss_type];
        AppMain.GmEfctBossBuildSingleDataInit();
        if ( AppMain.gm_gamedat_build_boss_buttle_tbl[boss_type] != null )
        {
            AppMain.gm_gamedat_build_boss_buttle_tbl[boss_type]();
        }
    }

    // Token: 0x060008F4 RID: 2292 RVA: 0x00051E50 File Offset: 0x00050050
    private static bool GmGameDatBuildBossBattleCheck()
    {
        bool result = true;
        if ( !AppMain.GmGameDBuildCheckBuildModel() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctZoneBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctEneBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossCmnBuildDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossBuildSingleDataLoop() )
        {
            result = false;
        }
        return result;
    }

    // Token: 0x060008F5 RID: 2293 RVA: 0x00051E8D File Offset: 0x0005008D
    private static void GmGameDatFlushBossBattleInit()
    {
        AppMain.GmGameDBuildModelFlushInit();
    }

    // Token: 0x060008F6 RID: 2294 RVA: 0x00051E94 File Offset: 0x00050094
    private static void GmGameDatFlushBossBattle( int boss_type )
    {
        int num = AppMain.g_gm_gamedat_bossbattle_stage_id_tbl[boss_type];
        if ( AppMain.gm_gamedat_flush_boss_buttle_tbl[boss_type] != null )
        {
            AppMain.gm_gamedat_flush_boss_buttle_tbl[boss_type]();
        }
    }

    // Token: 0x060008F7 RID: 2295 RVA: 0x00051EB4 File Offset: 0x000500B4
    private static bool GmGameDatFlushBossBattleCheck()
    {
        bool result = true;
        if ( !AppMain.GmGameDBuildCheckFlushModel() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctZoneFlushDataLoop() )
        {
            result = false;
        }
        if ( !AppMain.GmEfctBossFlushSingleDataLoop() )
        {
            result = false;
        }
        return result;
    }

    // Token: 0x060008F8 RID: 2296 RVA: 0x00051EE0 File Offset: 0x000500E0
    private static void GmGameDBuildModelBuildInit()
    {
        for ( int i = 0; i < AppMain.gm_obj_build_model_work_buf.Length; i++ )
        {
            AppMain.gm_obj_build_model_work_buf[i].Clear();
        }
        AppMain.gm_obj_build_model_work_reg_num = 0;
    }

    // Token: 0x060008F9 RID: 2297 RVA: 0x00051F11 File Offset: 0x00050111
    private static AppMain.OBS_ACTION3D_NN_WORK[] GmGameDBuildRegBuildModel( AppMain.AMS_AMB_HEADER mdl_amb, AppMain.AMS_AMB_HEADER tex_amb, uint draw_flag )
    {
        return AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, draw_flag, null );
    }

    // Token: 0x060008FA RID: 2298 RVA: 0x00051F1C File Offset: 0x0005011C
    private static AppMain.OBS_ACTION3D_NN_WORK[] GmGameDBuildRegBuildModel( AppMain.AMS_AMB_HEADER mdl_amb, AppMain.AMS_AMB_HEADER tex_amb, uint draw_flag, AppMain.TXB_HEADER txb )
    {
        AppMain.GMS_GDBUILD_BUILD_MDL_WORK gms_GDBUILD_BUILD_MDL_WORK = AppMain.gm_obj_build_model_work_buf[AppMain.gm_obj_build_model_work_reg_num];
        AppMain.gm_obj_build_model_work_reg_num++;
        gms_GDBUILD_BUILD_MDL_WORK.num = mdl_amb.file_num;
        gms_GDBUILD_BUILD_MDL_WORK.obj_3d_list = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>( gms_GDBUILD_BUILD_MDL_WORK.num );
        gms_GDBUILD_BUILD_MDL_WORK.mdl_amb = mdl_amb;
        gms_GDBUILD_BUILD_MDL_WORK.tex_amb = tex_amb;
        gms_GDBUILD_BUILD_MDL_WORK.draw_flag = draw_flag;
        gms_GDBUILD_BUILD_MDL_WORK.txb = txb;
        gms_GDBUILD_BUILD_MDL_WORK.build_state = AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_REG_WAIT;
        return gms_GDBUILD_BUILD_MDL_WORK.obj_3d_list;
    }

    // Token: 0x060008FB RID: 2299 RVA: 0x00051F88 File Offset: 0x00050188
    private static bool GmGameDBuildCheckBuildModel()
    {
        AppMain.ArrayPointer<AppMain.GMS_GDBUILD_BUILD_MDL_WORK> pointer = null;
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer2 = null;
        bool result = true;
        if ( AppMain.gm_obj_build_model_work_reg_num != 0 )
        {
            int i = AppMain.gm_obj_build_model_work_reg_num - 1;
            pointer = new AppMain.ArrayPointer<AppMain.GMS_GDBUILD_BUILD_MDL_WORK>( AppMain.gm_obj_build_model_work_buf, i );
            while ( i >= 0 )
            {
                if ( ( ~pointer ).build_state == ( AppMain.GME_GAME_DBUILD_MDL_STATE )AppMain.GME_GAME_DBUILD_MDL_STATE_REG_WAIT )
                {
                    int j = (~pointer).reg_num;
                    pointer2 = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>( ( ~pointer ).obj_3d_list, j );
                    if ( ( ~pointer ).txb == null )
                    {
                        while ( AppMain.GsMainSysGetDisplayListRegistNum() <= 188 && j < ( ~pointer ).num )
                        {
                            AppMain.ObjAction3dNNModelLoad( ~pointer2, null, null, j, ( ~pointer ).mdl_amb, null, ( ~pointer ).tex_amb, ( ~pointer ).draw_flag );
                            j++;
                            pointer2 = ++pointer2;
                        }
                        if ( j == ( ~pointer ).reg_num )
                        {
                            return false;
                        }
                        ( ~pointer ).reg_num = j;
                        if ( ( ~pointer ).reg_num == ( ~pointer ).num )
                        {
                            ( ~pointer ).build_state = AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_BUILD_WAIT;
                        }
                    }
                    else
                    {
                        while ( AppMain.GsMainSysGetDisplayListRegistNum() <= 188 && j < ( ~pointer ).num )
                        {
                            AppMain.ObjAction3dNNModelLoadTxb( pointer2, null, null, j, ( ~pointer ).mdl_amb, null, ( ~pointer ).tex_amb, ( ~pointer ).draw_flag, ( ~pointer ).txb );
                            j++;
                            pointer2 = ++pointer2;
                        }
                        if ( j == ( ~pointer ).reg_num )
                        {
                            return false;
                        }
                        ( ~pointer ).reg_num = j;
                        if ( ( ~pointer ).reg_num == ( ~pointer ).num )
                        {
                            ( ~pointer ).build_state = AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_BUILD_WAIT;
                        }
                    }
                    result = false;
                }
                else if ( ( ~pointer ).build_state == ( AppMain.GME_GAME_DBUILD_MDL_STATE )AppMain.GME_GAME_DBUILD_MDL_STATE_BUILD_WAIT )
                {
                    pointer2 = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>( ( ~pointer ).obj_3d_list );
                    int j = 0;
                    while ( j < ( ~pointer ).num )
                    {
                        if ( !AppMain.ObjAction3dNNModelLoadCheck( ~pointer2 ) )
                        {
                            result = false;
                            break;
                        }
                        j++;
                        pointer2 = ++pointer2;
                    }
                    if ( j >= ( ~pointer ).num && i == AppMain.gm_obj_build_model_work_reg_num - 1 )
                    {
                        AppMain.gm_obj_build_model_work_reg_num--;
                    }
                }
                i--;
                pointer = --pointer;
            }
        }
        return result;
    }

    // Token: 0x060008FC RID: 2300 RVA: 0x000521DD File Offset: 0x000503DD
    private static void GmGameDBuildModelFlushInit()
    {
        AppMain.ClearArray<AppMain.GMS_GDBUILD_BUILD_MDL_WORK>( AppMain.gm_obj_build_model_work_buf );
        AppMain.gm_obj_build_model_work_reg_num = 0;
    }

    // Token: 0x060008FD RID: 2301 RVA: 0x000521F0 File Offset: 0x000503F0
    private static void GmGameDBuildRegFlushModel( AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_list, int num )
    {
        AppMain.GMS_GDBUILD_BUILD_MDL_WORK gms_GDBUILD_BUILD_MDL_WORK = AppMain.gm_obj_build_model_work_buf[AppMain.gm_obj_build_model_work_reg_num];
        AppMain.gm_obj_build_model_work_reg_num++;
        gms_GDBUILD_BUILD_MDL_WORK.num = num;
        gms_GDBUILD_BUILD_MDL_WORK.obj_3d_list = obj_3d_list;
        gms_GDBUILD_BUILD_MDL_WORK.build_state = AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_REG_FLUSH_WAIT;
    }

    // Token: 0x060008FE RID: 2302 RVA: 0x0005222C File Offset: 0x0005042C
    private static bool GmGameDBuildCheckFlushModel()
    {
        bool result = true;
        if ( AppMain.gm_obj_build_model_work_reg_num != 0 )
        {
            int i = AppMain.gm_obj_build_model_work_reg_num - 1;
            AppMain.ArrayPointer<AppMain.GMS_GDBUILD_BUILD_MDL_WORK> pointer = new AppMain.ArrayPointer<AppMain.GMS_GDBUILD_BUILD_MDL_WORK>(AppMain.gm_obj_build_model_work_buf, i);
            while ( i >= 0 )
            {
                if ( ( ~pointer ).build_state == AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_REG_FLUSH_WAIT )
                {
                    int j = (~pointer).reg_num;
                    AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer2 = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>((~pointer).obj_3d_list, j);
                    while ( AppMain.GsMainSysGetDisplayListRegistNum() <= 188 && j < ( ~pointer ).num )
                    {
                        AppMain.ObjAction3dNNModelRelease( pointer2 );
                        j++;
                        pointer2 = ++pointer2;
                    }
                    if ( j == ( ~pointer ).reg_num )
                    {
                        return false;
                    }
                    ( ~pointer ).reg_num = j;
                    if ( ( ~pointer ).reg_num == ( ~pointer ).num )
                    {
                        ( ~pointer ).build_state = AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_FLUSH_WAIT;
                    }
                    result = false;
                }
                else if ( ( ~pointer ).build_state == AppMain.GME_GAME_DBUILD_MDL_STATE.GME_GAME_DBUILD_MDL_STATE_FLUSH_WAIT )
                {
                    int j = 0;
                    AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer2 = (~pointer).obj_3d_list;
                    while ( j < ( ~pointer ).num )
                    {
                        if ( !AppMain.ObjAction3dNNModelReleaseCheck( pointer2 ) )
                        {
                            result = false;
                            break;
                        }
                        j++;
                        pointer2 = ++pointer2;
                    }
                    if ( j >= ( ~pointer ).num && i == AppMain.gm_obj_build_model_work_reg_num - 1 )
                    {
                        AppMain.gm_obj_build_model_work_reg_num--;
                    }
                }
                i--;
                pointer = --pointer;
            }
        }
        return result;
    }

    // Token: 0x060008FF RID: 2303 RVA: 0x0005238D File Offset: 0x0005058D
    private static void GmGameDatFlashRestart()
    {
        AppMain.GmEventDataFlush();
    }

    // Token: 0x06000900 RID: 2304 RVA: 0x00052394 File Offset: 0x00050594
    private static void GmGameDatReBuildRestart()
    {
        AppMain.GmEventDataBuild();
        AppMain.GmMapBuildColData();
        AppMain.GmGmkSwitchReBuild();
        AppMain.GmGmkPressPillarClear();
    }

    // Token: 0x06000901 RID: 2305 RVA: 0x000523AA File Offset: 0x000505AA
    private static bool GmGameDatReBuildRestartCheck()
    {
        return true;
    }

    // Token: 0x06000902 RID: 2306 RVA: 0x000523AD File Offset: 0x000505AD
    private static void gmGameDatBuildStage11()
    {
        AppMain.GmEneMotoraBuild();
        AppMain.GmEneGabuBuild();
        AppMain.GmEneStingBuild();
        AppMain.GmEneMereonBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkBridgeBuild();
        AppMain.GmGmkBreakLandBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmEfctEneBuildDataInit( 0 );
        AppMain.GmEfctZoneBuildDataInit( 0 );
    }

    // Token: 0x06000903 RID: 2307 RVA: 0x000523E8 File Offset: 0x000505E8
    private static void gmGameDatBuildStage12()
    {
        AppMain.GmEneMotoraBuild();
        AppMain.GmEneGabuBuild();
        AppMain.GmEneStingBuild();
        AppMain.GmEneMereonBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkTarzanRopeBuild();
        AppMain.GmGmkBridgeBuild();
        AppMain.GmGmkBreakLandBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmEfctEneBuildDataInit( 0 );
        AppMain.GmEfctZoneBuildDataInit( 0 );
    }

    // Token: 0x06000904 RID: 2308 RVA: 0x00052428 File Offset: 0x00050628
    private static void gmGameDatBuildStage13()
    {
        AppMain.GmEneMotoraBuild();
        AppMain.GmEneGabuBuild();
        AppMain.GmEneStingBuild();
        AppMain.GmEneMereonBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkPulleyBuild();
        AppMain.GmGmkBridgeBuild();
        AppMain.GmGmkBreakLandBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmEfctEneBuildDataInit( 0 );
        AppMain.GmEfctZoneBuildDataInit( 0 );
    }

    // Token: 0x06000905 RID: 2309 RVA: 0x00052468 File Offset: 0x00050668
    private static void gmGameDatBuildStage1Boss()
    {
        AppMain.GmBoss1Build();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkCapsuleBuild();
        AppMain.GmEfctZoneBuildDataInit( 0 );
        AppMain.GmEfctBossCmnBuildDataInit();
    }

    // Token: 0x06000906 RID: 2310 RVA: 0x00052484 File Offset: 0x00050684
    private static void gmGameDatBuildStage21()
    {
        AppMain.GmEneGardonBuild();
        AppMain.GmEneHaroBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkEnBmprBuild();
        AppMain.GmGmkBobbinBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkStopperBuild();
        AppMain.GmGmkSlotBuild();
        AppMain.GmGmkSpCtpltBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmEfctEneBuildDataInit( 1 );
        AppMain.GmEfctZoneBuildDataInit( 1 );
    }

    // Token: 0x06000907 RID: 2311 RVA: 0x000524D9 File Offset: 0x000506D9
    private static void gmGameDatBuildStage22()
    {
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkEnBmprBuild();
        AppMain.GmGmkBobbinBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkStopperBuild();
        AppMain.GmGmkSlotBuild();
        AppMain.GmGmkSpCtpltBuild();
        AppMain.GmGmkSsArrowBuild();
        AppMain.GmEfctEneBuildDataInit( 1 );
        AppMain.GmEfctZoneBuildDataInit( 1 );
        AppMain.GmStartMsgBuild();
    }

    // Token: 0x06000908 RID: 2312 RVA: 0x00052514 File Offset: 0x00050714
    private static void gmGameDatBuildStage23()
    {
        AppMain.GmEneGardonBuild();
        AppMain.GmEneHaroBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkEnBmprBuild();
        AppMain.GmGmkBobbinBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkCannonBuild();
        AppMain.GmGmkSpCtpltBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmGmkSsArrowBuild();
        AppMain.GmEfctEneBuildDataInit( 1 );
        AppMain.GmEfctZoneBuildDataInit( 1 );
    }

    // Token: 0x06000909 RID: 2313 RVA: 0x00052569 File Offset: 0x00050769
    private static void gmGameDatBuildStage2Boss()
    {
        AppMain.GmBoss2Build();
        AppMain.GmGmkCapsuleBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkEnBmprBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkShutterBuild();
        AppMain.GmGmkNeedleNeonBuild();
        AppMain.GmEfctBossCmnBuildDataInit();
        AppMain.GmEfctZoneBuildDataInit( 1 );
    }

    // Token: 0x0600090A RID: 2314 RVA: 0x0005259C File Offset: 0x0005079C
    private static void gmGameDatBuildStage31()
    {
        AppMain.GmEneMoguBuild();
        AppMain.GmEneUnidesBuild();
        AppMain.GmEneUniuniBuild();
        AppMain.GmEneBukuBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkRockBuild();
        AppMain.GmGmkSpearBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmGmkRockRideBuild();
        AppMain.GmGmkSwitchBuildTypeZone3();
        AppMain.GmGmkSwWallBuild();
        AppMain.GmEfctEneBuildDataInit( 2 );
        AppMain.GmEfctZoneBuildDataInit( 2 );
    }

    // Token: 0x0600090B RID: 2315 RVA: 0x000525F1 File Offset: 0x000507F1
    private static void gmGameDatBuildStage32()
    {
        AppMain.GmEneMoguBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkSpearBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmGmkTruckBuild();
        AppMain.GmGmkSwitchBuildTypeZone3();
        AppMain.GmGmkSwWallBuild();
        AppMain.GmGmkDSignBuild();
        AppMain.GmEfctEneBuildDataInit( 2 );
        AppMain.GmEfctZoneBuildDataInit( 2 );
        AppMain.GmStartMsgBuild();
    }

    // Token: 0x0600090C RID: 2316 RVA: 0x00052634 File Offset: 0x00050834
    private static void gmGameDatBuildStage33()
    {
        AppMain.GmEneMoguBuild();
        AppMain.GmEneUnidesBuild();
        AppMain.GmEneUniuniBuild();
        AppMain.GmEneBukuBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkWaterSliderBuild();
        AppMain.GmGmkSpearBuild();
        AppMain.GmGmkPressWallBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkBreakObjBuild();
        AppMain.GmGmkDrainTankBuild();
        AppMain.GmGmkSwitchBuildTypeZone3();
        AppMain.GmGmkSwWallBuild();
        AppMain.GmEfctEneBuildDataInit( 2 );
        AppMain.GmEfctZoneBuildDataInit( 2 );
    }

    // Token: 0x0600090D RID: 2317 RVA: 0x0005268E File Offset: 0x0005088E
    private static void gmGameDatBuildStage3Boss()
    {
        AppMain.GmBoss3Build();
        AppMain.GmEneMoguBuild();
        AppMain.GmEneUnidesBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkCapsuleBuild();
        AppMain.GmGmkSpearBuild();
        AppMain.GmGmkBoss3PillarBuild();
        AppMain.GmEfctEneBuildDataInit( 2 );
        AppMain.GmEfctZoneBuildDataInit( 2 );
        AppMain.GmEfctBossCmnBuildDataInit();
    }

    // Token: 0x0600090E RID: 2318 RVA: 0x000526C4 File Offset: 0x000508C4
    private static void gmGameDatBuildStage41()
    {
        AppMain.GmEneTStarBuild();
        AppMain.GmEneKaniBuild();
        AppMain.GmEneKamaBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkPistonBuild();
        AppMain.GmGmkBeltConveyorBuild();
        AppMain.GmGmkUpBumperBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkPopSteamBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkSwitchBuildTypeZone4();
        AppMain.GmGmkSwWallBuild();
        AppMain.GmEfctEneBuildDataInit( 3 );
        AppMain.GmEfctZoneBuildDataInit( 3 );
    }

    // Token: 0x0600090F RID: 2319 RVA: 0x0005271C File Offset: 0x0005091C
    private static void gmGameDatBuildStage42()
    {
        AppMain.GmEneTStarBuild();
        AppMain.GmEneKaniBuild();
        AppMain.GmEneKamaBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkPistonBuild();
        AppMain.GmGmkBeltConveyorBuild();
        AppMain.GmGmkUpBumperBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkPopSteamBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkGearBuild();
        AppMain.GmGmkSwitchBuildTypeZone4();
        AppMain.GmGmkSwWallBuild();
        AppMain.GmEfctEneBuildDataInit( 3 );
        AppMain.GmEfctZoneBuildDataInit( 3 );
    }

    // Token: 0x06000910 RID: 2320 RVA: 0x00052778 File Offset: 0x00050978
    private static void gmGameDatBuildStage43()
    {
        AppMain.GmEneTStarBuild();
        AppMain.GmEneKaniBuild();
        AppMain.GmEneKamaBuild();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkPistonBuild();
        AppMain.GmGmkBeltConveyorBuild();
        AppMain.GmGmkUpBumperBuild();
        AppMain.GmGmkSeesawBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkPopSteamBuild();
        AppMain.GmGmkPressWallBuild();
        AppMain.GmGmkPressPillarBuild();
        AppMain.GmGmkBreakWallBuild();
        AppMain.GmGmkGearBuild();
        AppMain.GmGmkSwitchBuildTypeZone4();
        AppMain.GmGmkSwWallBuild();
        AppMain.GmEfctEneBuildDataInit( 3 );
        AppMain.GmEfctZoneBuildDataInit( 3 );
    }

    // Token: 0x06000911 RID: 2321 RVA: 0x000527E1 File Offset: 0x000509E1
    private static void gmGameDatBuildStage4Boss()
    {
        AppMain.GmBoss4Build();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkCapsuleBuild();
        AppMain.GmEfctBossCmnBuildDataInit();
    }

    // Token: 0x06000912 RID: 2322 RVA: 0x000527F7 File Offset: 0x000509F7
    private static void gmGameDatBuildStageFinalBoss01()
    {
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkShutterBuild();
        AppMain.GmGmkBoss3PillarBuild();
        AppMain.GmGmkNeedleNeonBuild();
        AppMain.GmEfctBossCmnBuildDataInit();
        AppMain.GmEfctZoneBuildDataInit( 4 );
    }

    // Token: 0x06000913 RID: 2323 RVA: 0x00052827 File Offset: 0x00050A27
    private static void gmGameDatBuildStageFinalBoss02()
    {
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkShutterBuild();
        AppMain.GmGmkBoss3PillarBuild();
        AppMain.GmGmkNeedleNeonBuild();
        AppMain.GmEfctBossCmnBuildDataInit();
        AppMain.GmEfctZoneBuildDataInit( 4 );
    }

    // Token: 0x06000914 RID: 2324 RVA: 0x00052857 File Offset: 0x00050A57
    private static void gmGameDatBuildStageFinalBoss03()
    {
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkShutterBuild();
        AppMain.GmGmkBoss3PillarBuild();
        AppMain.GmGmkNeedleNeonBuild();
        AppMain.GmEfctBossCmnBuildDataInit();
        AppMain.GmEfctZoneBuildDataInit( 4 );
    }

    // Token: 0x06000915 RID: 2325 RVA: 0x00052887 File Offset: 0x00050A87
    private static void gmGameDatBuildStageFinalBoss04()
    {
        AppMain.GmGmkLandBuild();
        AppMain.GmEfctZoneBuildDataInit( 4 );
    }

    // Token: 0x06000916 RID: 2326 RVA: 0x00052894 File Offset: 0x00050A94
    private static void gmGameDatBuildStageFinalBoss05()
    {
        AppMain.GmBoss5Build();
        AppMain.GmGmkLandBuild();
        AppMain.GmGmkSteamPipeBuild();
        AppMain.GmGmkBumperBuild();
        AppMain.GmGmkFlipperBuild();
        AppMain.GmGmkShutterBuild();
        AppMain.GmGmkBoss3PillarBuild();
        AppMain.GmGmkNeedleNeonBuild();
        AppMain.GmEfctBossCmnBuildDataInit();
        AppMain.GmEfctZoneBuildDataInit( 4 );
    }

    // Token: 0x06000917 RID: 2327 RVA: 0x000528C9 File Offset: 0x00050AC9
    private static void gmGameDatBuildSS01()
    {
        AppMain.GmGmkSsSquareBuild();
        AppMain.GmGmkSsCircleBuild();
        AppMain.GmGmkSsEnduranceBuild();
        AppMain.GmGmkSsGoalBuild();
        AppMain.GmGmkSsEmeraldBuild();
        AppMain.GmGmkSsTimeBuild();
        AppMain.GmGmkSsRingGateBuild();
        AppMain.GmGmkSsArrowBuild();
        AppMain.GmGmkSsOblongBuild();
        AppMain.GmGmkBobbinBuild();
        AppMain.GmEfctZoneBuildDataInit( 5 );
        AppMain.GmStartMsgBuild();
    }

    // Token: 0x06000918 RID: 2328 RVA: 0x00052908 File Offset: 0x00050B08
    private static void gmGameDatBuildEnding()
    {
        AppMain.GmGmkLandBuild();
        AppMain.GmEfctZoneBuildDataInit( 0 );
        AppMain.GmEndingBuild();
        AppMain.DmStfrlMdlCtrlRingBuild();
        AppMain.DmStfrlMdlCtrlBoss1Build();
        AppMain.DmStfrlMdlCtrlSonicBuild();
    }

    // Token: 0x06000919 RID: 2329 RVA: 0x00052929 File Offset: 0x00050B29
    private static void gmGameDatFlushStage11()
    {
        AppMain.GmEneMotoraFlush();
        AppMain.GmEneGabuFlush();
        AppMain.GmEneStingFlush();
        AppMain.GmEneMereonFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkBridgeFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkBreakLandFlush();
        AppMain.GmEfctEneFlushDataInit( 0 );
        AppMain.GmEfctZoneFlushDataInit( 0 );
    }

    // Token: 0x0600091A RID: 2330 RVA: 0x00052964 File Offset: 0x00050B64
    private static void gmGameDatFlushStage12()
    {
        AppMain.GmEneMotoraFlush();
        AppMain.GmEneGabuFlush();
        AppMain.GmEneStingFlush();
        AppMain.GmEneMereonFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkTarzanRopeFlush();
        AppMain.GmGmkBridgeFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkBreakLandFlush();
        AppMain.GmEfctEneFlushDataInit( 0 );
        AppMain.GmEfctZoneFlushDataInit( 0 );
    }

    // Token: 0x0600091B RID: 2331 RVA: 0x000529A4 File Offset: 0x00050BA4
    private static void gmGameDatFlushStage13()
    {
        AppMain.GmEneMotoraFlush();
        AppMain.GmEneGabuFlush();
        AppMain.GmEneStingFlush();
        AppMain.GmEneMereonFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkPulleyFlush();
        AppMain.GmGmkBridgeFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkBreakLandFlush();
        AppMain.GmEfctEneFlushDataInit( 0 );
        AppMain.GmEfctZoneFlushDataInit( 0 );
    }

    // Token: 0x0600091C RID: 2332 RVA: 0x000529E4 File Offset: 0x00050BE4
    private static void gmGameDatFlushStage1Boss()
    {
        AppMain.GmBoss1Flush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkCapsuleFlush();
        AppMain.GmEfctZoneFlushDataInit( 0 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x0600091D RID: 2333 RVA: 0x00052A00 File Offset: 0x00050C00
    private static void gmGameDatFlushStage21()
    {
        AppMain.GmEneGardonFlush();
        AppMain.GmEneHaroFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkEnBmprFlush();
        AppMain.GmGmkBobbinFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkStopperFlush();
        AppMain.GmGmkSlotFlush();
        AppMain.GmGmkSpCtpltFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmEfctEneFlushDataInit( 1 );
        AppMain.GmEfctZoneFlushDataInit( 1 );
    }

    // Token: 0x0600091E RID: 2334 RVA: 0x00052A55 File Offset: 0x00050C55
    private static void gmGameDatFlushStage22()
    {
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkEnBmprFlush();
        AppMain.GmGmkBobbinFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkStopperFlush();
        AppMain.GmGmkSlotFlush();
        AppMain.GmGmkSpCtpltFlush();
        AppMain.GmGmkSsArrowFlush();
        AppMain.GmEfctEneFlushDataInit( 1 );
        AppMain.GmEfctZoneFlushDataInit( 1 );
        AppMain.GmStartMsgFlush();
    }

    // Token: 0x0600091F RID: 2335 RVA: 0x00052A90 File Offset: 0x00050C90
    private static void gmGameDatFlushStage23()
    {
        AppMain.GmEneGardonFlush();
        AppMain.GmEneHaroFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkEnBmprFlush();
        AppMain.GmGmkBobbinFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkCannonFlush();
        AppMain.GmGmkSpCtpltFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkSsArrowFlush();
        AppMain.GmEfctEneFlushDataInit( 1 );
        AppMain.GmEfctZoneFlushDataInit( 1 );
    }

    // Token: 0x06000920 RID: 2336 RVA: 0x00052AE5 File Offset: 0x00050CE5
    private static void gmGameDatFlushStage2Boss()
    {
        AppMain.GmBoss2Flush();
        AppMain.GmGmkCapsuleFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkEnBmprFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkShutterFlush();
        AppMain.GmGmkNeedleNeonFlush();
        AppMain.GmEfctZoneFlushDataInit( 1 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x06000921 RID: 2337 RVA: 0x00052B18 File Offset: 0x00050D18
    private static void gmGameDatFlushStage31()
    {
        AppMain.GmEneMoguFlush();
        AppMain.GmEneUnidesFlush();
        AppMain.GmEneUniuniFlush();
        AppMain.GmEneBukuFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkRockFlush();
        AppMain.GmGmkSpearFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkRockRideFlush();
        AppMain.GmGmkSwitchFlush();
        AppMain.GmGmkSwWallFlush();
        AppMain.GmEfctEneFlushDataInit( 2 );
        AppMain.GmEfctZoneFlushDataInit( 2 );
    }

    // Token: 0x06000922 RID: 2338 RVA: 0x00052B6D File Offset: 0x00050D6D
    private static void gmGameDatFlushStage32()
    {
        AppMain.GmEneMoguFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkSpearFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkTruckFlush();
        AppMain.GmGmkSwitchFlush();
        AppMain.GmGmkSwWallFlush();
        AppMain.GmGmkDSignFlush();
        AppMain.GmEfctEneFlushDataInit( 2 );
        AppMain.GmEfctZoneFlushDataInit( 2 );
        AppMain.GmStartMsgFlush();
    }

    // Token: 0x06000923 RID: 2339 RVA: 0x00052BB0 File Offset: 0x00050DB0
    private static void gmGameDatFlushStage33()
    {
        AppMain.GmEneMoguFlush();
        AppMain.GmEneUnidesFlush();
        AppMain.GmEneUniuniFlush();
        AppMain.GmEneBukuFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkWaterSliderFlush();
        AppMain.GmGmkSpearFlush();
        AppMain.GmGmkPressWallFlush();
        AppMain.GmGmkBreakObjFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkDrainTankFlush();
        AppMain.GmGmkSwitchFlush();
        AppMain.GmGmkSwWallFlush();
        AppMain.GmEfctEneFlushDataInit( 2 );
        AppMain.GmEfctZoneFlushDataInit( 2 );
    }

    // Token: 0x06000924 RID: 2340 RVA: 0x00052C0A File Offset: 0x00050E0A
    private static void gmGameDatFlushStage3Boss()
    {
        AppMain.GmBoss3Flush();
        AppMain.GmEneMoguFlush();
        AppMain.GmEneUnidesFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkCapsuleFlush();
        AppMain.GmGmkSpearFlush();
        AppMain.GmGmkBoss3PillarFlush();
        AppMain.GmEfctEneFlushDataInit( 2 );
        AppMain.GmEfctZoneFlushDataInit( 2 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x06000925 RID: 2341 RVA: 0x00052C40 File Offset: 0x00050E40
    private static void gmGameDatFlushStage41()
    {
        AppMain.GmEneTStarFlush();
        AppMain.GmEneKaniFlush();
        AppMain.GmEneKamaFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkPistonFlush();
        AppMain.GmGmkBeltConveyorFlush();
        AppMain.GmGmkUpBumperFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkPopSteamFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkSwitchFlush();
        AppMain.GmGmkSwWallFlush();
        AppMain.GmEfctEneFlushDataInit( 3 );
        AppMain.GmEfctZoneFlushDataInit( 3 );
    }

    // Token: 0x06000926 RID: 2342 RVA: 0x00052C98 File Offset: 0x00050E98
    private static void gmGameDatFlushStage42()
    {
        AppMain.GmEneTStarFlush();
        AppMain.GmEneKaniFlush();
        AppMain.GmEneKamaFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkPistonFlush();
        AppMain.GmGmkBeltConveyorFlush();
        AppMain.GmGmkUpBumperFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkPopSteamFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkGearFlush();
        AppMain.GmGmkSwitchFlush();
        AppMain.GmGmkSwWallFlush();
        AppMain.GmEfctEneFlushDataInit( 3 );
        AppMain.GmEfctZoneFlushDataInit( 3 );
    }

    // Token: 0x06000927 RID: 2343 RVA: 0x00052CF4 File Offset: 0x00050EF4
    private static void gmGameDatFlushStage43()
    {
        AppMain.GmEneTStarFlush();
        AppMain.GmEneKaniFlush();
        AppMain.GmEneKamaFlush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkPistonFlush();
        AppMain.GmGmkBeltConveyorFlush();
        AppMain.GmGmkUpBumperFlush();
        AppMain.GmGmkSeesawFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkPopSteamFlush();
        AppMain.GmGmkPressWallFlush();
        AppMain.GmGmkPressPillarFlush();
        AppMain.GmGmkBreakWallFlush();
        AppMain.GmGmkGearFlush();
        AppMain.GmGmkSwitchFlush();
        AppMain.GmGmkSwWallFlush();
        AppMain.GmEfctEneFlushDataInit( 3 );
        AppMain.GmEfctZoneFlushDataInit( 3 );
    }

    // Token: 0x06000928 RID: 2344 RVA: 0x00052D5D File Offset: 0x00050F5D
    private static void gmGameDatFlushStage4Boss()
    {
        AppMain.GmBoss4Flush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkCapsuleFlush();
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x06000929 RID: 2345 RVA: 0x00052D73 File Offset: 0x00050F73
    private static void gmGameDatFlushStageFinalBoss01()
    {
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkShutterFlush();
        AppMain.GmGmkBoss3PillarFlush();
        AppMain.GmGmkNeedleNeonFlush();
        AppMain.GmEfctZoneFlushDataInit( 4 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x0600092A RID: 2346 RVA: 0x00052DA3 File Offset: 0x00050FA3
    private static void gmGameDatFlushStageFinalBoss02()
    {
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkShutterFlush();
        AppMain.GmGmkBoss3PillarFlush();
        AppMain.GmGmkNeedleNeonFlush();
        AppMain.GmEfctZoneFlushDataInit( 4 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x0600092B RID: 2347 RVA: 0x00052DD3 File Offset: 0x00050FD3
    private static void gmGameDatFlushStageFinalBoss03()
    {
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkShutterFlush();
        AppMain.GmGmkBoss3PillarFlush();
        AppMain.GmGmkNeedleNeonFlush();
        AppMain.GmEfctZoneFlushDataInit( 4 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x0600092C RID: 2348 RVA: 0x00052E03 File Offset: 0x00051003
    private static void gmGameDatFlushStageFinalBoss04()
    {
        AppMain.GmGmkLandFlush();
        AppMain.GmEfctZoneFlushDataInit( 4 );
    }

    // Token: 0x0600092D RID: 2349 RVA: 0x00052E10 File Offset: 0x00051010
    private static void gmGameDatFlushStageFinalBoss05()
    {
        AppMain.GmBoss5Flush();
        AppMain.GmGmkLandFlush();
        AppMain.GmGmkSteamPipeFlush();
        AppMain.GmGmkBumperFlush();
        AppMain.GmGmkFlipperFlush();
        AppMain.GmGmkShutterFlush();
        AppMain.GmGmkBoss3PillarFlush();
        AppMain.GmGmkNeedleNeonFlush();
        AppMain.GmEfctZoneFlushDataInit( 4 );
        AppMain.GmEfctBossCmnFlushDataInit();
    }

    // Token: 0x0600092E RID: 2350 RVA: 0x00052E45 File Offset: 0x00051045
    private static void gmGameDatFlushSS01()
    {
        AppMain.GmGmkSsSquareFlush();
        AppMain.GmGmkSsCircleFlush();
        AppMain.GmGmkSsEnduranceFlush();
        AppMain.GmGmkSsGoalFlush();
        AppMain.GmGmkSsEmeraldFlush();
        AppMain.GmGmkSsTimeFlush();
        AppMain.GmGmkSsRingGateFlush();
        AppMain.GmGmkSsArrowFlush();
        AppMain.GmGmkSsOblongFlush();
        AppMain.GmGmkBobbinFlush();
        AppMain.GmEfctZoneFlushDataInit( 5 );
        AppMain.GmStartMsgFlush();
    }

    // Token: 0x0600092F RID: 2351 RVA: 0x00052E84 File Offset: 0x00051084
    private static void gmGameDatFlushEnding()
    {
        AppMain.GmGmkLandFlush();
        AppMain.GmEfctZoneFlushDataInit( 0 );
        AppMain.GmEndingFlush();
        AppMain.DmStfrlMdlCtrlSonicFlush();
        AppMain.DmStfrlMdlCtrlRingFlush();
        AppMain.DmStfrlMdlCtrlBoss1Flush();
    }

    // Token: 0x06000930 RID: 2352 RVA: 0x00052EA5 File Offset: 0x000510A5
    private static void gmGameDatBuildStageF_BB1()
    {
        AppMain.GmBoss1Build();
    }

    // Token: 0x06000931 RID: 2353 RVA: 0x00052EAC File Offset: 0x000510AC
    private static void gmGameDatBuildStageF_BB2()
    {
        AppMain.GmBoss2Build();
    }

    // Token: 0x06000932 RID: 2354 RVA: 0x00052EB3 File Offset: 0x000510B3
    private static void gmGameDatBuildStageF_BB3()
    {
        AppMain.GmBoss3Build();
    }

    // Token: 0x06000933 RID: 2355 RVA: 0x00052EBA File Offset: 0x000510BA
    private static void gmGameDatBuildStageF_BB4()
    {
        AppMain.GmBoss4Build();
    }

    // Token: 0x06000934 RID: 2356 RVA: 0x00052EC1 File Offset: 0x000510C1
    private static void gmGameDatBuildStageF_BBF()
    {
        AppMain.GmBoss5Build();
    }

    // Token: 0x06000935 RID: 2357 RVA: 0x00052EC8 File Offset: 0x000510C8
    private static void gmGameDatFlushStageF_BB1()
    {
        AppMain.GmBoss1Flush();
    }

    // Token: 0x06000936 RID: 2358 RVA: 0x00052ECF File Offset: 0x000510CF
    private static void gmGameDatFlushStageF_BB2()
    {
        AppMain.GmBoss2Flush();
    }

    // Token: 0x06000937 RID: 2359 RVA: 0x00052ED6 File Offset: 0x000510D6
    private static void gmGameDatFlushStageF_BB3()
    {
        AppMain.GmBoss3Flush();
    }

    // Token: 0x06000938 RID: 2360 RVA: 0x00052EDD File Offset: 0x000510DD
    private static void gmGameDatFlushStageF_BB4()
    {
        AppMain.GmBoss4Flush();
    }

    // Token: 0x06000939 RID: 2361 RVA: 0x00052EE4 File Offset: 0x000510E4
    private static void gmGameDatFlushStageF_BBF()
    {
        AppMain.GmBoss5Flush();
    }
}
