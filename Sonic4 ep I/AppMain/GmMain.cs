using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using dbg;

public partial class AppMain
{

    // Token: 0x1700000F RID: 15
    // (get) Token: 0x06000380 RID: 896 RVA: 0x0001C24C File Offset: 0x0001A44C
    private static byte[][] g_gm_player_motion_right_tbl
    {
        get
        {
            if ( AppMain._g_gm_player_motion_right_tbl == null )
            {
                AppMain._g_gm_player_motion_right_tbl = new byte[][]
                {
                    AppMain.gm_player_motion_list_son_right,
                    AppMain.gm_player_motion_list_sson_right,
                    AppMain.gm_player_motion_list_son_right,
                    AppMain.gm_player_motion_list_pn_son_right,
                    AppMain.gm_player_motion_list_pn_sson_right,
                    AppMain.gm_player_motion_list_tr_son_right,
                    AppMain.gm_player_motion_list_tr_son_right
                };
            }
            return AppMain._g_gm_player_motion_right_tbl;
        }
    }

    // Token: 0x17000010 RID: 16
    // (get) Token: 0x06000381 RID: 897 RVA: 0x0001C2AC File Offset: 0x0001A4AC
    private static byte[][] g_gm_player_motion_left_tbl
    {
        get
        {
            if ( AppMain._g_gm_player_motion_left_tbl == null )
            {
                AppMain._g_gm_player_motion_left_tbl = new byte[][]
                {
                    AppMain.gm_player_motion_list_son_left,
                    AppMain.gm_player_motion_list_sson_left,
                    AppMain.gm_player_motion_list_son_left,
                    AppMain.gm_player_motion_list_pn_son_left,
                    AppMain.gm_player_motion_list_pn_sson_left,
                    AppMain.gm_player_motion_list_tr_son_left,
                    AppMain.gm_player_motion_list_tr_son_left
                };
            }
            return AppMain._g_gm_player_motion_left_tbl;
        }
    }

    // Token: 0x17000011 RID: 17
    // (get) Token: 0x06000382 RID: 898 RVA: 0x0001C30C File Offset: 0x0001A50C
    private static byte[][] g_gm_player_model_tbl
    {
        get
        {
            if ( AppMain._g_gm_player_model_tbl == null )
            {
                AppMain._g_gm_player_model_tbl = new byte[][]
                {
                    AppMain.gm_player_model_list_son,
                    AppMain.gm_player_model_list_son,
                    AppMain.gm_player_model_list_son,
                    AppMain.gm_player_model_list_pn_son,
                    AppMain.gm_player_model_list_pn_son,
                    AppMain.gm_player_model_list_tr_son,
                    AppMain.gm_player_model_list_tr_son
                };
            }
            return AppMain._g_gm_player_model_tbl;
        }
    }

    // Token: 0x17000012 RID: 18
    // (get) Token: 0x06000383 RID: 899 RVA: 0x0001C36C File Offset: 0x0001A56C
    private static byte[][] g_gm_player_mtn_blend_setting_tbl
    {
        get
        {
            if ( AppMain._g_gm_player_mtn_blend_setting_tbl == null )
            {
                AppMain._g_gm_player_mtn_blend_setting_tbl = new byte[][]
                {
                    AppMain.gm_player_mtn_blend_setting_son,
                    AppMain.gm_player_mtn_blend_setting_son,
                    AppMain.gm_player_mtn_blend_setting_son,
                    AppMain.gm_player_mtn_blend_setting_pn_son,
                    AppMain.gm_player_mtn_blend_setting_pn_son,
                    AppMain.gm_player_mtn_blend_setting_tr_son,
                    AppMain.gm_player_mtn_blend_setting_tr_son
                };
            }
            return AppMain._g_gm_player_mtn_blend_setting_tbl;
        }
    }

    // Token: 0x17000013 RID: 19
    // (get) Token: 0x06000384 RID: 900 RVA: 0x0001C3CA File Offset: 0x0001A5CA
    public static short GMD_OBJ_LCD_X
    {
        get
        {
            return ( short )( 0.67438334f * ( float )AppMain.GSD_DISP_WIDTH );
        }
    }

    // Token: 0x17000014 RID: 20
    // (get) Token: 0x06000385 RID: 901 RVA: 0x0001C3D9 File Offset: 0x0001A5D9
    public static short GMD_OBJ_LCD_Y
    {
        get
        {
            return ( short )( 0.67438334f * ( float )AppMain.GSD_DISP_HEIGHT );
        }
    }

    // Token: 0x06000386 RID: 902 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
    public static bool GMM_MAIN_STAGE_IS_BOSS()
    {
        return ( int )AppMain.g_gs_main_sys_info.stage_id < AppMain.g_gm_gamedat_stage_type_tbl.Length && AppMain.g_gm_gamedat_stage_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == AppMain.GSE_MAIN_STAGE_TYPE.GSD_MAIN_STAGE_TYPE_BOSS;
    }

    // Token: 0x06000387 RID: 903 RVA: 0x0001C415 File Offset: 0x0001A615
    public static bool GMM_MAIN_STAGE_IS_SS()
    {
        return ( int )AppMain.g_gs_main_sys_info.stage_id < AppMain.g_gm_gamedat_stage_type_tbl.Length && AppMain.g_gm_gamedat_stage_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == AppMain.GSE_MAIN_STAGE_TYPE.GSD_MAIN_STAGE_TYPE_SS;
    }

    // Token: 0x06000388 RID: 904 RVA: 0x0001C442 File Offset: 0x0001A642
    public static bool GMM_MAIN_STAGE_IS_ENDING()
    {
        return AppMain.g_gs_main_sys_info.game_mode == 2;
    }

    // Token: 0x06000389 RID: 905 RVA: 0x0001C454 File Offset: 0x0001A654
    private static int GMM_MAIN_GET_ZONE_TYPE()
    {
        return AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id];
    }

    // Token: 0x0600038A RID: 906 RVA: 0x0001C466 File Offset: 0x0001A666
    public static bool GMM_MAIN_USE_SUPER_SONIC()
    {
        return ( AppMain.g_gm_main_system.game_flag & 524288U ) != 0U;
    }

    // Token: 0x0600038B RID: 907 RVA: 0x0001C47D File Offset: 0x0001A67D
    public static bool GMM_MAIN_GOAL_AS_SUPER_SONIC()
    {
        return ( AppMain.g_gm_main_system.game_flag & 33554432U ) != 0U;
    }

    // Token: 0x0600038C RID: 908 RVA: 0x0001C494 File Offset: 0x0001A694
    private static bool GmMainIsWaterLevel()
    {
        return AppMain.g_gm_main_system.water_level != ushort.MaxValue;
    }

    // Token: 0x0600038D RID: 909 RVA: 0x0001C4AA File Offset: 0x0001A6AA
    public static void GmMainClearSuspendedPause()
    {
        AppMain.g_gs_main_sys_info.game_flag &= 3758096383U;
    }

    // Token: 0x0600038E RID: 910 RVA: 0x0001C4C2 File Offset: 0x0001A6C2
    private static void GmMainGSInit()
    {
        AppMain.g_gs_main_sys_info.game_flag &= 4294967009U;
        AppMain.g_gs_main_sys_info.clear_ring = 0U;
        AppMain.g_gs_main_sys_info.clear_score = 0U;
        AppMain.g_gs_main_sys_info.clear_time = 0;
    }

    // Token: 0x0600038F RID: 911 RVA: 0x0001C4FC File Offset: 0x0001A6FC
    private static void GmMainGSRetryInit()
    {
        AppMain._bossFinishThread = true;
        AppMain.g_gs_main_sys_info.rest_player_num = AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )];
        AppMain.g_gs_main_sys_info.game_flag &= 4294967025U;
        AppMain.g_gs_main_sys_info.clear_ring = 0U;
        AppMain.g_gs_main_sys_info.clear_score = 0U;
        AppMain.g_gs_main_sys_info.clear_time = 0;
    }

    // Token: 0x06000390 RID: 912 RVA: 0x0001C560 File Offset: 0x0001A760
    private void GmMainInit( object arg )
    {
        AppMain.GsFontRelease();
        CPadEmu cpadEmu = CPadEmu.CreateInstance();
        cpadEmu.Create( CPadEmu.EMode.Game );
        if ( AppMain.GsTrialIsTrial() )
        {
            AppMain.g_gs_main_sys_info.stage_id = ( ushort )AppMain.nextDemoLevel;
        }
        if ( SaveState.shouldResume() )
        {
            SaveState.resumeStageState();
        }
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 4U ) == 0U )
        {
            AppMain.gmMainSysInit();
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            AppMain.ObjInit( 4, 61435, 0, ( short )( ( double )AppMain.GMD_OBJ_LCD_X * 1.42 ), ( short )( ( double )AppMain.GMD_OBJ_LCD_X * 1.42 ), ( float )AppMain.GSD_DISP_WIDTH, ( float )AppMain.GSD_DISP_HEIGHT );
        }
        else
        {
            AppMain.ObjInit( 4, 61435, 0, AppMain.GMD_OBJ_LCD_X, AppMain.GMD_OBJ_LCD_Y, ( float )AppMain.GSD_DISP_WIDTH, ( float )AppMain.GSD_DISP_HEIGHT );
        }
        AppMain.ObjDataAlloc( 994 );
        AppMain.ObjDrawESEffectSystemInit( 0, 20480U, 5U );
        this.amTrailEFInitialize();
        AppMain.ObjDrawSetNNCommandStateTbl( 0U, 1U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 1U, 2U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 2U, 3U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 3U, 5U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 4U, 11U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 5U, 12U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 6U, 15U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 7U, 0U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 8U, 16U, true );
        if ( AppMain.g_gs_main_sys_info.stage_id == 10 || AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            AppMain.ObjDrawSetNNCommandStateTbl( 9U, 17U, true );
        }
        else
        {
            AppMain.ObjDrawSetNNCommandStateTbl( 9U, uint.MaxValue, false );
        }
        AppMain.ObjDrawSetNNCommandStateTbl( 10U, 9U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 11U, 4U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 12U, 8U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 13U, 7U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 14U, 10U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 15U, 6U, true );
        AppMain.AoActSysClearPeak();
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 16U ) == 0U )
        {
            AppMain.gmMainLoad( 0 );
            return;
        }
        AppMain.gmMainRebuild();
    }

    // Token: 0x06000391 RID: 913 RVA: 0x0001C714 File Offset: 0x0001A914
    private static void GmMainEnd()
    {
        AppMain.GmPadVibExit();
        if ( AppMain.g_gm_main_system.pre_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.g_gm_main_system.pre_tcb );
            AppMain.g_gm_main_system.pre_tcb = null;
        }
        if ( AppMain.g_gm_main_system.post_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.g_gm_main_system.post_tcb );
            AppMain.g_gm_main_system.post_tcb = null;
        }
        AppMain.amTrailEFDeleteGroup( 1 );
        AppMain.GmPlyEfctTrailSysExit();
        AppMain.g_obj.ppPre = null;
        AppMain.ObjObjectClearAllObject();
        AppMain.ObjPreExit();
        AppMain.GmMapExit();
        AppMain.GmFixExit();
        AppMain.GmPauseExit();
        AppMain.GmRingExit();
        AppMain.GmCameraExit();
        AppMain.GmSoundExit();
        AppMain.GmMapFarExit();
        AppMain.GmDecoExit();
        AppMain.GmWaterSurfaceExit();
        AppMain.GmEventMgrExit();
        AppMain.ObjDrawESEffectSystemExit();
        AppMain.GmClearDemoExit();
        AppMain.GmOverExit();
        AppMain.GmSplStageExit();
        AppMain.GmEndingExit();
        AppMain.GmStartDemoExit();
        AppMain.GmStartMsgExit();
        AppMain.CPadVirtualPad cpadVirtualPad = AppMain.CPadVirtualPad.CreateInstance();
        cpadVirtualPad.Release();
        AppMain.CPadPolarHandle cpadPolarHandle = AppMain.CPadPolarHandle.CreateInstance();
        cpadPolarHandle.Release();
        AppMain.GsMainSysSetSleepFlag( true );
        AppMain.GsMainSysSetAccelFlag( false );
    }

    // Token: 0x06000392 RID: 914 RVA: 0x0001C80B File Offset: 0x0001AA0B
    private static void GmMainExit()
    {
        AppMain.GmMainEnd();
        AppMain.gmMainDataRelease();
    }

    // Token: 0x06000393 RID: 915 RVA: 0x0001C817 File Offset: 0x0001AA17
    private static void GmMainRestartExit()
    {
        AppMain.GmMainEnd();
        if ( AppMain.g_gs_main_sys_info.stage_id == 16 )
        {
            AppMain.gmMainObjectRelease();
            return;
        }
        AppMain.g_obj.flag |= 1073741824U;
        AppMain.ObjExit();
        AppMain.gmMainObjectRelease();
    }

    // Token: 0x06000394 RID: 916 RVA: 0x0001C852 File Offset: 0x0001AA52
    private static void GmMainExitForStaffroll()
    {
        AppMain.gmMainDataRelease();
    }

    // Token: 0x06000395 RID: 917 RVA: 0x0001C859 File Offset: 0x0001AA59
    private static bool GmMainCheckExeTimerCount()
    {
        return ( AppMain.g_gm_main_system.game_flag & 1024U ) != 0U;
    }

    // Token: 0x06000396 RID: 918 RVA: 0x0001C870 File Offset: 0x0001AA70
    public static bool GmMainIsDrawEnable()
    {
        return AppMain._am_sample_draw_enable;
    }

    // Token: 0x06000397 RID: 919 RVA: 0x0001C884 File Offset: 0x0001AA84
    public static float GmMainGetDrawMotionSpeed()
    {
        return ( float )AppMain._am_sample_count;
    }

    // Token: 0x06000398 RID: 920 RVA: 0x0001C88C File Offset: 0x0001AA8C
    private static ushort GmMainGetObjectRotation()
    {
        ushort result = 0;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        if ( obs_CAMERA != null )
        {
            result = ( ushort )( -( ushort )obs_CAMERA.roll );
        }
        return result;
    }

    // Token: 0x06000399 RID: 921 RVA: 0x0001C8B8 File Offset: 0x0001AAB8
    private static uint GmMainGetLightColor()
    {
        uint result = 3772834047U;
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            result = 3767175935U;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            result = 2593823487U;
        }
        return result;
    }

    // Token: 0x0600039A RID: 922 RVA: 0x0001C904 File Offset: 0x0001AB04
    private static uint GmMainGetLightColorABGR()
    {
        uint result = 4292927712U;
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            result = 4287269600U;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            result = 4288322202U;
        }
        return result;
    }

    // Token: 0x0600039B RID: 923 RVA: 0x0001C950 File Offset: 0x0001AB50
    private static OpenGL.glArray4f GmMainGetLightColorArray4f()
    {
        ushort stage_id = AppMain.g_gs_main_sys_info.stage_id;
        switch ( stage_id )
        {
            case 2:
            case 3:
                return AppMain.LightColor[1];
            default:
                if ( stage_id != 14 )
                {
                    return AppMain.LightColor[0];
                }
                return AppMain.LightColor[2];
        }
    }

    // Token: 0x0600039C RID: 924 RVA: 0x0001C9B8 File Offset: 0x0001ABB8
    public static void GmMainDatLoadBossBattleStart( int boss_type )
    {
        if ( AppMain.g_gm_main_system.boss_load_no == boss_type )
        {
            return;
        }
        if ( AppMain.GmMainDatReleaseBossBattleReleaseCheck() )
        {
            AppMain.GmGameDatReleaseBossBattleExit();
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 16 && boss_type > 0 && boss_type < 4 )
        {
            if ( AppMain._bossThread != null && AppMain._bossThread.IsAlive )
            {
                AppMain._bossThread.Join();
            }
            AppMain._bossThread = null;
            AppMain._bossThread = new Thread( new ParameterizedThreadStart( AppMain._GmMainDatLoadBossBattleStart ) );
            AppMain._bossFinishThread = false;
            AppMain._bossThread.Start( boss_type );
            return;
        }
        AppMain._bossFinishThread = true;
        AppMain.GmGameDatLoadBoosBattleInit( boss_type );
        AppMain.gm_main_load_bossbattle_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataLoadBoosBattleMgr_LoadWait ), null, 0U, ushort.MaxValue, 2048U, 5, () => new AppMain.GMS_MAIN_LOAD_BB_MGR_WORK(), "GM_LOAD_BBM" );
        AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)AppMain.gm_main_load_bossbattle_tcb.work;
        gms_MAIN_LOAD_BB_MGR_WORK.boss_type = boss_type;
        gms_MAIN_LOAD_BB_MGR_WORK.b_end = false;
        AppMain.g_gm_main_system.game_flag |= 2097152U;
    }

    // Token: 0x0600039D RID: 925 RVA: 0x0001CAD4 File Offset: 0x0001ACD4
    public static void _GmMainDatLoadBossBattleStart( object o )
    {
        int boss_type = (int)o;
        bool flag = false;
        for (; ; )
        {
            int x = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].obj_work.pos.x;
            switch ( boss_type )
            {
                case 0:
                    flag = true;
                    break;
                case 1:
                    if ( x >= 10424705 )
                    {
                        flag = true;
                    }
                    break;
                case 2:
                    if ( x >= 23266972 )
                    {
                        flag = true;
                    }
                    break;
                case 3:
                    if ( x >= 37948249 )
                    {
                        flag = true;
                    }
                    break;
                case 4:
                    if ( x >= 52666673 )
                    {
                        flag = true;
                    }
                    break;
            }
            if ( AppMain._bossFinishThread )
            {
                break;
            }
            if ( !flag )
            {
                Thread.Sleep( 30 );
            }
            if ( flag )
            {
                goto Block_8;
            }
        }
        return;
        Block_8:
        AppMain.GmGameDatLoadBoosBattleInit( boss_type );
        AppMain.gm_main_load_bossbattle_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataLoadBoosBattleMgr_LoadWait ), null, 0U, ushort.MaxValue, 2048U, 5, () => new AppMain.GMS_MAIN_LOAD_BB_MGR_WORK(), "GM_LOAD_BBM" );
        AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)AppMain.gm_main_load_bossbattle_tcb.work;
        gms_MAIN_LOAD_BB_MGR_WORK.boss_type = boss_type;
        gms_MAIN_LOAD_BB_MGR_WORK.b_end = false;
        AppMain.g_gm_main_system.game_flag |= 2097152U;
        AppMain._bossFinishThread = true;
    }

    // Token: 0x0600039E RID: 926 RVA: 0x0001CBF6 File Offset: 0x0001ADF6
    private static bool GmMainDatLoadBossBattleLoadCheck()
    {
        return AppMain.GmMainDatLoadBossBattleLoadCheck( 0 );
    }

    // Token: 0x0600039F RID: 927 RVA: 0x0001CBFE File Offset: 0x0001ADFE
    private static bool GmMainDatLoadBossBattleLoadCheck( int boss_type )
    {
        return AppMain.g_gm_main_system.boss_load_no != -1 && ( AppMain.g_gm_main_system.game_flag & 4194304U ) == 0U && ( boss_type == -1 || boss_type == AppMain.g_gm_main_system.boss_load_no );
    }

    // Token: 0x060003A0 RID: 928 RVA: 0x0001CC33 File Offset: 0x0001AE33
    private static bool GmMainDatLoadBossBattleLoadNowCheck()
    {
        return ( AppMain.g_gm_main_system.game_flag & 2097152U ) != 0U;
    }

    // Token: 0x060003A1 RID: 929 RVA: 0x0001CC4A File Offset: 0x0001AE4A
    private static void GmGameDatLoadBossBattleExit()
    {
        if ( AppMain.gm_main_load_bossbattle_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_main_load_bossbattle_tcb );
            AppMain.gm_main_load_bossbattle_tcb = null;
        }
    }

    // Token: 0x060003A2 RID: 930 RVA: 0x0001CC6C File Offset: 0x0001AE6C
    private static void GmGameDatReleaseBossBattleStart( int boss_type )
    {
        AppMain.GmGameDatFlushBossBattleInit();
        AppMain.GmGameDatFlushBossBattle( boss_type );
        AppMain.gm_main_release_bossbattle_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataReleaseBoosBattleMgr_FlushWait ), null, 0U, ushort.MaxValue, 2048U, 5, () => new AppMain.GMS_MAIN_LOAD_BB_MGR_WORK(), "GM_RELEASEBBM" );
        AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)AppMain.gm_main_release_bossbattle_tcb.work;
        gms_MAIN_LOAD_BB_MGR_WORK.boss_type = boss_type;
        gms_MAIN_LOAD_BB_MGR_WORK.b_end = false;
        AppMain.g_gm_main_system.game_flag |= 4194304U;
    }

    // Token: 0x060003A3 RID: 931 RVA: 0x0001CCFD File Offset: 0x0001AEFD
    private static bool GmMainDatReleaseBossBattleReleaseCheck()
    {
        return AppMain.g_gm_main_system.boss_load_no == -1 && ( AppMain.g_gm_main_system.game_flag & 2097152U ) == 0U;
    }

    // Token: 0x060003A4 RID: 932 RVA: 0x0001CD21 File Offset: 0x0001AF21
    private static bool GmMainDatReleaseBossBattleReleaseNowCheck()
    {
        return ( AppMain.g_gm_main_system.game_flag & 4194304U ) != 0U;
    }

    // Token: 0x060003A5 RID: 933 RVA: 0x0001CD38 File Offset: 0x0001AF38
    private static void GmGameDatReleaseBossBattleExit()
    {
        if ( AppMain.gm_main_release_bossbattle_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_main_release_bossbattle_tcb );
            AppMain.gm_main_release_bossbattle_tcb = null;
        }
    }

    // Token: 0x060003A6 RID: 934 RVA: 0x0001CD54 File Offset: 0x0001AF54
    private static int GmMainKeyCheckPauseKeyOn()
    {
        int result = -1;
        uint num = 215U;
        uint num2 = 0U;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            num = 390U;
            num2 = 0U;
        }
        else if ( AppMain.GsGetMainSysInfo().game_mode == 1 )
        {
            num = 275U;
            num2 = 0U;
        }
        for ( int i = 0; i < 4; i++ )
        {
            if ( AppMain.amTpIsTouchOn( i ) )
            {
                ushort num3 = AppMain._am_tp_touch[i].on[0];
                ushort num4 = AppMain._am_tp_touch[i].on[1];
                if ( ( uint )num3 >= num && ( uint )num3 <= num + 115U && ( uint )num4 >= num2 && ( uint )num4 <= num2 + 60U )
                {
                    num3 = AppMain._am_tp_touch[i].push[0];
                    num4 = AppMain._am_tp_touch[i].push[1];
                    if ( ( uint )num3 >= num && ( uint )num3 <= num + 115U && ( uint )num4 >= num2 && ( uint )num4 <= num2 + 60U )
                    {
                        result = i;
                        break;
                    }
                }
            }
        }
        return result;
    }

    // Token: 0x060003A7 RID: 935 RVA: 0x0001CE24 File Offset: 0x0001B024
    private static int GmMainKeyCheckPauseKeyPush()
    {
        int result = -1;
        uint num = 215U;
        uint num2 = 0U;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            num = 390U;
            num2 = 0U;
        }
        else if ( AppMain.GsGetMainSysInfo().game_mode == 1 )
        {
            num = 275U;
            num2 = 0U;
        }
        for ( int i = 0; i < 4; i++ )
        {
            if ( AppMain.amTpIsTouchPush( i ) )
            {
                ushort num3 = AppMain._am_tp_touch[i].push[0];
                ushort num4 = AppMain._am_tp_touch[i].push[1];
                if ( ( uint )num3 >= num && ( uint )num3 <= num + 115U && ( uint )num4 >= num2 && ( uint )num4 <= num2 + 60U )
                {
                    result = i;
                    break;
                }
            }
        }
        if ( AppMain.g_pause_flag )
        {
            AppMain.g_pause_flag = false;
            return 1;
        }
        return result;
    }

    // Token: 0x060003A8 RID: 936 RVA: 0x0001CEC4 File Offset: 0x0001B0C4
    private static void gmMainSysInit()
    {
        AppMain.g_gm_main_system.Clear();
        AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] = AppMain.g_gs_main_sys_info.rest_player_num;
        if ( AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] <= 0U )
        {
            AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] = 1U;
        }
        AppMain.mtMathSRand( ( uint )( AppMain.nnRandom() * 32767f ) );
    }

    // Token: 0x060003A9 RID: 937 RVA: 0x0001CF24 File Offset: 0x0001B124
    private static void gmMainLoad( int load_proc )
    {
        short[] array = new short[1];
        AppMain.GmMainClearSuspendedPause();
        AppMain.DmLoadingStart();
        AppMain.GmPauseMenuLoadStart();
        int num = 0;
        while ( ( long )num < 1L )
        {
            array[num] = ( short )AppMain.g_gs_main_sys_info.char_id[num];
            num++;
        }
        AppMain.GmGameDatLoadInit( load_proc, AppMain.g_gs_main_sys_info.stage_id, array );
        AppMain.gm_main_load_wait_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataLoadWait ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataLoadDest ), 0U, ushort.MaxValue, 4096U, 0, null, "GM_LOAD_WAIT" );
    }

    // Token: 0x060003AA RID: 938 RVA: 0x0001CFAC File Offset: 0x0001B1AC
    private static void gmMainDataLoadWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gmMainUpdateSuspendedPause();
        if ( !AppMain.GmPauseMenuLoadIsFinished() )
        {
            return;
        }
        if ( AppMain.GmGameDatLoadCheck() == AppMain.GME_GAMEDAT_LOAD_PROGRESS.GMD_GAMEDAT_LOAD_PROGRESS_COMPLETE )
        {
            if ( !SaveState.shouldResume() )
            {
                SaveState.deleteSave();
            }
            AppMain.GmGameDatBuildInit();
            AppMain.GmGameDatBuildStandard();
            AppMain.GmGameDatBuildArea();
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataBuildWait ) );
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    // Token: 0x060003AB RID: 939 RVA: 0x0001D00C File Offset: 0x0001B20C
    private static void gmMainDataBuildWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gmMainUpdateSuspendedPause();
        if ( !AppMain.GmGameDatBuildStandardCheck() )
        {
            return;
        }
        if ( !AppMain.GmGameDatBuildAreaCheck() )
        {
            return;
        }
        if ( !AppMain.SoundPartialCache( 5 ) )
        {
            return;
        }
        if ( !AppMain.PrepareBGMForLevel( ( int )AppMain.g_gs_main_sys_info.stage_id ) )
        {
            return;
        }
        AppMain.GmGameDatLoadExit();
        AppMain.g_gs_main_sys_info.game_flag |= 16U;
        AppMain.DmLoadingSetLoadComplete();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataLoadingEndWait ) );
    }

    // Token: 0x060003AC RID: 940 RVA: 0x0001D078 File Offset: 0x0001B278
    private static void gmMainDataLoadingEndWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gmMainUpdateSuspendedPause();
        if ( AppMain.DmLoadingIsExit() )
        {
            AppMain.gmMainGameStart();
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x060003AD RID: 941 RVA: 0x0001D091 File Offset: 0x0001B291
    private static void gmMainDataLoadDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_main_load_wait_tcb = null;
    }

    // Token: 0x060003AE RID: 942 RVA: 0x0001D099 File Offset: 0x0001B299
    private static void gmMainRebuild()
    {
        AppMain.gm_main_load_wait_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainRebuildWait ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainRebuildDest ), 0U, ushort.MaxValue, 4096U, 0, null, "GM_REBUILD_WAIT" );
        AppMain.GmGameDatReBuildRestart();
    }

    // Token: 0x060003AF RID: 943 RVA: 0x0001D0D4 File Offset: 0x0001B2D4
    private static void gmMainRebuildWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.GmGameDatReBuildRestartCheck() )
        {
            return;
        }
        AppMain.gmMainGameStart();
        AppMain.mtTaskClearTcb( tcb );
    }

    // Token: 0x060003B0 RID: 944 RVA: 0x0001D0E9 File Offset: 0x0001B2E9
    private static void gmMainRebuildDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_main_load_wait_tcb = null;
    }

    // Token: 0x060003B1 RID: 945 RVA: 0x0001D0F4 File Offset: 0x0001B2F4
    private static void gmMainDataRelease()
    {
        AppMain.GSF_TASK_PROCEDURE proc;
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitWait );
        }
        else
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitFinalClearObjWait );
        }
        AppMain.gm_main_release_wait_tcb = AppMain.MTM_TASK_MAKE_TCB( proc, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataReleaseDest ), 0U, ushort.MaxValue, 4096U, 0, null, "GM_UNLOAD_WAIT" );
    }

    // Token: 0x060003B2 RID: 946 RVA: 0x0001D154 File Offset: 0x0001B354
    private static void gmMainDataFlushExitFinalClearObjWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain._bossFinishThread = true;
        if ( !AppMain.ObjObjectCheckClearAllObject() )
        {
            return;
        }
        AppMain.GsSoundReset();
        AppMain.GSF_TASK_PROCEDURE proc;
        if ( AppMain.GmMainDatLoadBossBattleLoadCheck() )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitFinalWait );
            AppMain.GmGameDatLoadBossBattleExit();
            AppMain.GmGameDatReleaseBossBattleStart( AppMain.g_gm_main_system.boss_load_no );
        }
        else if ( AppMain.GmMainDatLoadBossBattleLoadNowCheck() )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitFinalLoadWait );
        }
        else if ( AppMain.GmMainDatReleaseBossBattleReleaseNowCheck() )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitFinalWait );
            AppMain.GmGameDatLoadBossBattleExit();
        }
        else
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitWait );
            AppMain.GmGameDatReleaseBossBattleExit();
        }
        AppMain.mtTaskChangeTcbProcedure( tcb, proc );
    }

    // Token: 0x060003B3 RID: 947 RVA: 0x0001D1E8 File Offset: 0x0001B3E8
    private static void gmMainDataFlushExitFinalLoadWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmMainDatLoadBossBattleLoadCheck() )
        {
            AppMain.GmGameDatLoadBossBattleExit();
            AppMain.GmGameDatReleaseBossBattleStart( AppMain.g_gm_main_system.boss_load_no );
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitFinalWait ) );
        }
    }

    // Token: 0x060003B4 RID: 948 RVA: 0x0001D217 File Offset: 0x0001B417
    private static void gmMainDataFlushExitFinalWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmMainDatReleaseBossBattleReleaseCheck() )
        {
            AppMain.GmGameDatReleaseBossBattleExit();
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushExitWait ) );
        }
    }

    // Token: 0x060003B5 RID: 949 RVA: 0x0001D237 File Offset: 0x0001B437
    private static void gmMainDataFlushExitWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.ObjObjectCheckClearAllObject() )
        {
            return;
        }
        AppMain.GsSoundReset();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataFlushWait ) );
        AppMain.GmGameDatFlushInit();
        AppMain.GmGameDatFlushArea();
        AppMain.GmGameDatFlushStandard();
    }

    // Token: 0x060003B6 RID: 950 RVA: 0x0001D268 File Offset: 0x0001B468
    private static void gmMainDataFlushWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.GmGameDatFlushStandardCheck() )
        {
            return;
        }
        if ( !AppMain.GmGameDatFlushAreaCheck() )
        {
            return;
        }
        AppMain.OBS_DATA_WORK[] pData = AppMain.g_obj.pData;
        for ( int i = 0; i < AppMain.g_obj.data_max; i++ )
        {
            if ( pData[i].pData != null && ( pData[i].num & 32768 ) == 0 )
            {
                pData[i].pData = null;
            }
        }
        AppMain.ObjExit();
        AppMain.GmGameDatReleaseStandard();
        AppMain.GmGameDatReleaseArea();
        AppMain.GmPauseMenuRelease();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataReleaseWait ) );
    }

    // Token: 0x060003B7 RID: 951 RVA: 0x0001D2F0 File Offset: 0x0001B4F0
    private static void gmMainDataReleaseWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmGameDatReleaseCheck() && !AppMain.ObjIsExitWait() )
        {
            AppMain.g_gs_main_sys_info.game_flag &= 4294967279U;
            AppMain.mtTaskClearTcb( tcb );
            AppMain.g_gs_main_sys_info.rest_player_num = AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )];
            if ( AppMain.g_gs_main_sys_info.rest_player_num <= 0U )
            {
                AppMain.g_gs_main_sys_info.rest_player_num = 3U;
            }
            if ( AppMain.g_gs_main_sys_info.game_mode == 0 && ( AppMain.g_gs_main_sys_info.game_flag & 2U ) != 0U && AppMain.g_gs_main_sys_info.stage_id == 16 )
            {
                AppMain.g_gs_main_sys_info.stage_id = 28;
                AppMain.g_gs_main_sys_info.char_id[0] = 0;
                AppMain.g_gs_main_sys_info.game_mode = 2;
                AppMain.GmMainGSInit();
            }
            AppMain.SyChangeNextEvt();
        }
    }

    // Token: 0x060003B8 RID: 952 RVA: 0x0001D3AF File Offset: 0x0001B5AF
    private static void gmMainDataReleaseDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_main_release_wait_tcb = null;
    }

    // Token: 0x060003B9 RID: 953 RVA: 0x0001D3B8 File Offset: 0x0001B5B8
    private static void gmMainObjectRelease()
    {
        AppMain.GSF_TASK_PROCEDURE proc;
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseWait );
        }
        else
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseFinalClearObjWait );
        }
        AppMain.gm_main_release_wait_tcb = AppMain.MTM_TASK_MAKE_TCB( proc, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseDest ), 0U, ushort.MaxValue, 4096U, 0, null, "GM_UNLOAD_OBJ_WAIT" );
    }

    // Token: 0x060003BA RID: 954 RVA: 0x0001D418 File Offset: 0x0001B618
    private static void gmMainObjectReleaseFinalClearObjWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.ObjObjectCheckClearAllObject() )
        {
            return;
        }
        AppMain.GSF_TASK_PROCEDURE proc;
        if ( AppMain.GmMainDatLoadBossBattleLoadCheck() )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseFinalWait );
            AppMain.GmGameDatLoadBossBattleExit();
            AppMain.GmGameDatReleaseBossBattleStart( AppMain.g_gm_main_system.boss_load_no );
        }
        else if ( AppMain.GmMainDatLoadBossBattleLoadNowCheck() )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseFinalLoadWait );
        }
        else if ( AppMain.GmMainDatReleaseBossBattleReleaseNowCheck() )
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseFinalWait );
            AppMain.GmGameDatLoadBossBattleExit();
        }
        else
        {
            proc = new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseWait );
            AppMain.GmGameDatReleaseBossBattleExit();
            AppMain.g_obj.flag |= 1073741824U;
            AppMain.ObjExit();
        }
        AppMain.mtTaskChangeTcbProcedure( tcb, proc );
    }

    // Token: 0x060003BB RID: 955 RVA: 0x0001D4BC File Offset: 0x0001B6BC
    private static void gmMainObjectReleaseFinalLoadWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmMainDatLoadBossBattleLoadCheck() )
        {
            AppMain.GmGameDatLoadBossBattleExit();
            AppMain.GmGameDatReleaseBossBattleStart( AppMain.g_gm_main_system.boss_load_no );
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseFinalWait ) );
        }
    }

    // Token: 0x060003BC RID: 956 RVA: 0x0001D4EB File Offset: 0x0001B6EB
    private static void gmMainObjectReleaseFinalWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmMainDatReleaseBossBattleReleaseCheck() )
        {
            AppMain.GmGameDatReleaseBossBattleExit();
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainObjectReleaseWait ) );
            AppMain.g_obj.flag |= 1073741824U;
            AppMain.ObjExit();
        }
    }

    // Token: 0x060003BD RID: 957 RVA: 0x0001D526 File Offset: 0x0001B726
    private static void gmMainObjectReleaseWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.ObjObjectCheckClearAllObject() )
        {
            return;
        }
        if ( AppMain.ObjIsExitWait() )
        {
            return;
        }
        AppMain.GmGameDatFlashRestart();
        AppMain.mtTaskClearTcb( tcb );
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x060003BE RID: 958 RVA: 0x0001D548 File Offset: 0x0001B748
    private static void gmMainObjectReleaseDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_main_release_wait_tcb = null;
    }

    // Token: 0x060003BF RID: 959 RVA: 0x0001D560 File Offset: 0x0001B760
    private static void gmMainGameStart()
    {
        bool flag = false;
        if ( SaveState.shouldResume() )
        {
            SaveState.resumePlayerState();
            SaveState.resumeMapData();
        }
        AppMain.amIPhoneTouchCanceled();
        AppMain.CPadVirtualPad cpadVirtualPad = AppMain.CPadVirtualPad.CreateInstance();
        float[] area = new float[]
        {
            -120f,
            166f,
            232f,
            318f
        };
        cpadVirtualPad.Create( area );
        AppMain.CPadPolarHandle cpadPolarHandle = AppMain.CPadPolarHandle.CreateInstance();
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            cpadPolarHandle.Create( 0f, 0f, AppMain.AMD_SCREEN_2D_WIDTH * 4f / 5f, AppMain.AMD_SCREEN_2D_HEIGHT );
        }
        else
        {
            cpadPolarHandle.Create();
        }
        cpadPolarHandle.SetValue( 0f );
        AppMain.g_gm_main_system.polar_now = 0;
        AppMain.g_gm_main_system.polar_diff = 0;
        if ( ( AppMain.GsGetMainSysInfo().game_flag & 1U ) == 0U )
        {
            AppMain.GsMainSysSetSleepFlag( false );
            AppMain.GsMainSysSetAccelFlag( true );
        }
        else if ( ( AppMain.GsGetMainSysInfo().game_flag & 512U ) == 0U && ( AppMain.GsGetMainSysInfo().stage_id == 9 || AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() ) )
        {
            AppMain.GsMainSysSetSleepFlag( false );
            AppMain.GsMainSysSetAccelFlag( true );
        }
        else
        {
            AppMain.GsMainSysSetSleepFlag( true );
            AppMain.GsMainSysSetAccelFlag( false );
        }
        AppMain.GmPadVibInit();
        if ( ( AppMain.g_gm_main_system.game_flag & 512U ) != 0U )
        {
            AppMain.g_gm_main_system.game_time = 0U;
            flag = true;
        }
        AppMain.g_gm_main_system.game_flag &= 4187479041U;
        AppMain.g_gm_main_system.die_event_wait_time = 0;
        AppMain.g_gm_main_system.pseudofall_dir = 0;
        AppMain.g_gm_main_system.boss_load_no = -1;
        AppMain.g_gm_main_system.pre_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainPre ), null, 0U, 0, 4096U, 5, null, "GM_MAIN_PRE" );
        AppMain.g_gm_main_system.post_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainPost ), null, 0U, 0, 32768U, 5, null, "GM_MAIN_POST" );
        AppMain.g_obj.flag = 4194408U;
        AppMain.g_obj.ppPre = new AppMain.OBJECT_Delegate( AppMain.GmObjPreFunc );
        AppMain.g_obj.ppPost = null;
        AppMain.g_obj.ppCollision = new AppMain.OBJECT_WORK_Delegate( AppMain.GmObjCollision );
        AppMain.g_obj.ppObjPre = new AppMain.OBJECT_WORK_Delegate( AppMain.GmObjObjPreFunc );
        AppMain.g_obj.ppObjPost = new AppMain.OBJECT_WORK_Delegate( AppMain.GmObjObjPostFunc );
        AppMain.g_obj.ppRegRecAuto = new AppMain.OBJECT_WORK_Delegate( AppMain.GmObjRegistRectAuto );
        AppMain.g_obj.draw_scale.x = ( AppMain.g_obj.draw_scale.y = ( AppMain.g_obj.draw_scale.z = 13107 ) );
        AppMain.g_obj.inv_draw_scale.x = ( AppMain.g_obj.inv_draw_scale.y = ( AppMain.g_obj.inv_draw_scale.z = AppMain.FX_Div( 4096, AppMain.g_obj.draw_scale.x ) ) );
        AppMain.g_obj.depth = 128;
        AppMain.ObjDebugRectActionInit();
        AppMain.gmMainInitLight();
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 4U ) != 0U )
        {
            AppMain.g_gm_main_system.game_time = AppMain.g_gm_main_system.time_save;
            if ( AppMain.g_gm_main_system.marker_pri == 0U )
            {
                AppMain.g_gm_main_system.ply_dmg_count = 0U;
                AppMain.g_gm_main_system.game_flag &= 4227858431U;
            }
            else
            {
                AppMain.g_gm_main_system.game_flag |= 67108864U;
                if ( flag )
                {
                    AppMain.g_gs_main_sys_info.game_flag |= 256U;
                }
            }
        }
        AppMain.GmMapInit();
        AppMain.GmTvxInit();
        AppMain.GmMapFarInit();
        AppMain.GmDecoInit();
        AppMain.GmWaterSurfaceInit();
        AppMain.GmPlyEfctTrailSysInit();
        AppMain.GmFixInit();
        AppMain.GmCameraInit();
        AppMain.GmSoundInit();
        AppMain.GmRingInit();
        AppMain.GmEventMgrInit();
        AppMain.GmEventMgrStart();
        int num = 0;
        while ( ( long )num < 1L )
        {
            if ( AppMain.g_gs_main_sys_info.char_id[num] != 32767 )
            {
                AppMain.g_gm_main_system.ply_work[num] = AppMain.GmPlayerInit( AppMain.g_gs_main_sys_info.char_id[num], 0, ( ushort )num, 0 );
            }
            num++;
        }
        AppMain.GmEveMgrCreateStateEvent();
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 4U ) != 0U && AppMain.g_gm_main_system.marker_pri > 0U )
        {
            SaveState.saveCurrentState( 0 );
        }
        if ( AppMain.g_gs_main_sys_info.stage_id != 28 )
        {
            AppMain.g_gm_main_system.game_flag |= 268435456U;
            AppMain.g_gm_main_system.game_flag &= 4160749567U;
        }
        AppMain.g_gm_main_system.game_flag &= 4294964223U;
        AppMain.g_gm_main_system.game_flag |= 2048U;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.GmSplStageStart();
            return;
        }
        if ( AppMain.g_gs_main_sys_info.game_mode == 2 )
        {
            AppMain.GmEndingStart();
            return;
        }
        AppMain.GmStartDemoStart();
    }

    // Token: 0x060003C0 RID: 960 RVA: 0x0001D9F8 File Offset: 0x0001BBF8
    private static void gmMainInitLight()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            AppMain.g_obj.ambient_color.r = 1f;
            AppMain.g_obj.ambient_color.g = 0f;
            AppMain.g_obj.ambient_color.b = 0f;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            AppMain.g_obj.ambient_color.r = 0.1f;
            AppMain.g_obj.ambient_color.g = 0.1f;
            AppMain.g_obj.ambient_color.b = 0.1f;
        }
        else
        {
            AppMain.g_obj.ambient_color.r = 0.8f;
            AppMain.g_obj.ambient_color.g = 0.8f;
            AppMain.g_obj.ambient_color.b = 0.8f;
        }
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 3 )
        {
            nns_VECTOR.x = -0.95f;
            nns_VECTOR.y = 0.25f;
            nns_VECTOR.z = -1f;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 16 )
        {
            nns_VECTOR.x = -1f;
            nns_VECTOR.y = -1f;
            nns_VECTOR.z = -1f;
        }
        else
        {
            nns_VECTOR.x = 0f;
            nns_VECTOR.y = 0f;
            nns_VECTOR.z = -1f;
        }
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        float intensity;
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            intensity = 0.8f;
        }
        else
        {
            intensity = 1f;
        }
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_0, ref nns_RGBA, intensity, nns_VECTOR );
        AppMain.g_gm_main_system.def_light_vec.Assign( nns_VECTOR );
        AppMain.g_gm_main_system.def_light_col = nns_RGBA;
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            intensity = 1f;
        }
        else
        {
            intensity = 1.5f;
        }
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 3 )
        {
            nns_VECTOR.x = 0.05f;
            nns_VECTOR.y = 0.15f;
            nns_VECTOR.z = -0.05f;
        }
        else
        {
            nns_VECTOR.x = -0.5f;
            nns_VECTOR.y = -0.4f;
            nns_VECTOR.z = -0.25f;
        }
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_6, ref nns_RGBA, intensity, nns_VECTOR );
        AppMain.g_gm_main_system.ply_light_vec.Assign( nns_VECTOR );
        AppMain.g_gm_main_system.ply_light_col = nns_RGBA;
        AppMain.GmMapSetLight();
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 0 )
        {
            AppMain.GmGmkBreakLandSetLight();
        }
        else if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 3 )
        {
            AppMain.GmGmkGearSetLight();
            AppMain.GmGmkNeedleSetLight();
        }
        else if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.GmSplStageSetLight();
        }
        else if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            AppMain.GmBoss5LandSetLight();
            AppMain.GmDecoSetLightFinalZone();
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x060003C1 RID: 961 RVA: 0x0001DCC0 File Offset: 0x0001BEC0
    private static void gmMainPre( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gmMainUpdateSuspendedPause();
        AppMain.GMS_MAIN_SYSTEM gms_MAIN_SYSTEM = AppMain.g_gm_main_system;
        if ( ( gms_MAIN_SYSTEM.game_flag & 134217728U ) != 0U )
        {
            AppMain.g_gm_main_system.game_flag &= 4160749567U;
            if ( AppMain.g_gs_main_sys_info.stage_id != 28 && ( AppMain.g_gm_main_system.game_flag & 524288U ) == 0U )
            {
                AppMain.GmSoundPlayStageBGM( 0 );
            }
        }
        AppMain.CPadVirtualPad cpadVirtualPad = AppMain.CPadVirtualPad.CreateInstance();
        cpadVirtualPad.Update();
        AppMain.CPadPolarHandle cpadPolarHandle = AppMain.CPadPolarHandle.CreateInstance();
        cpadPolarHandle.Update();
        int polar_now = gms_MAIN_SYSTEM.polar_now;
        gms_MAIN_SYSTEM.polar_now = cpadPolarHandle.GetAngle32Value();
        gms_MAIN_SYSTEM.polar_diff = gms_MAIN_SYSTEM.polar_now - polar_now;
        if ( AppMain.gmMainIsUseWaitUpCamera() )
        {
            if ( AppMain.GmPlayerIsStateWait( gms_MAIN_SYSTEM.ply_work[( int )( ( UIntPtr )0 )] ) )
            {
                if ( gms_MAIN_SYSTEM.camscale_state == AppMain.GME_MAIN_CAMSCALE_STATE.GMD_MAIN_CAMSCALE_STATE_NON )
                {
                    gms_MAIN_SYSTEM.camscale_state = AppMain.GME_MAIN_CAMSCALE_STATE.GMD_MAIN_CAMSCALE_STATE_ZOOM;
                }
            }
            else
            {
                gms_MAIN_SYSTEM.camscale_state = AppMain.GME_MAIN_CAMSCALE_STATE.GMD_MAIN_CAMSCALE_STATE_NON;
                gms_MAIN_SYSTEM.camera_scale = 0.67438334f;
            }
            if ( gms_MAIN_SYSTEM.camscale_state == AppMain.GME_MAIN_CAMSCALE_STATE.GMD_MAIN_CAMSCALE_STATE_ZOOM )
            {
                gms_MAIN_SYSTEM.camera_scale -= 0.01f;
                if ( gms_MAIN_SYSTEM.camera_scale < 0.33719167f )
                {
                    gms_MAIN_SYSTEM.camera_scale = 0.33719167f;
                    gms_MAIN_SYSTEM.camscale_state = AppMain.GME_MAIN_CAMSCALE_STATE.GMD_MAIN_CAMSCALE_STATE_UP;
                }
            }
            for ( int i = 0; i < 7; i++ )
            {
                AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(i);
                if ( obs_CAMERA != null )
                {
                    obs_CAMERA.scale = gms_MAIN_SYSTEM.camera_scale;
                }
            }
        }
    }

    // Token: 0x060003C2 RID: 962 RVA: 0x0001DDFC File Offset: 0x0001BFFC
    private static void gmMainPost( AppMain.MTS_TASK_TCB tcb )
    {
        CPadEmu.CreateInstance();
        if ( ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 1024U ) != 0U && AppMain.g_gm_main_system.die_event_wait_time < 491520 && ( AppMain.g_gm_main_system.game_flag & 64U ) == 0U )
        {
            AppMain.g_gm_main_system.die_event_wait_time = AppMain.ObjTimeCountUp( AppMain.g_gm_main_system.die_event_wait_time );
            if ( AppMain.g_gm_main_system.die_event_wait_time >= 491520 )
            {
                if ( AppMain.g_gs_main_sys_info.game_mode == 1 )
                {
                    AppMain.GmClearDemoRetryStart();
                }
                else
                {
                    AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] -= 1U;
                    if ( AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] < 0U )
                    {
                        AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] = 0U;
                    }
                    if ( AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] == 0U )
                    {
                        AppMain.g_gm_main_system.game_flag |= 32U;
                        AppMain.GmOverStart( 0 );
                        AppMain.GmSoundPlayGameOver();
                    }
                    else
                    {
                        AppMain.g_gm_main_system.game_flag |= 2U;
                        AppMain.g_gs_main_sys_info.game_flag |= 4U;
                        if ( ( AppMain.g_gm_main_system.game_flag & 512U ) != 0U )
                        {
                            AppMain.g_gm_main_system.game_flag |= 32U;
                            AppMain.GmOverStart( 1 );
                        }
                        else
                        {
                            AppMain.IzFadeInitEasy( 0U, 1U, 15f );
                        }
                    }
                }
            }
        }
        if ( ( AppMain.g_gs_main_sys_info.game_mode == 1 && ( AppMain.g_gm_main_system.game_flag & 16U ) != 0U ) || ( AppMain.g_gs_main_sys_info.game_mode != 1 && ( ( AppMain.g_gm_main_system.game_flag & 256U ) != 0U || ( ( AppMain.g_gm_main_system.game_flag & 768U ) == 0U && ( AppMain.g_gm_main_system.game_flag & 2U ) != 0U && AppMain.IzFadeIsEnd() ) || ( AppMain.g_gm_main_system.game_flag & 20U ) == 20U ) ) )
        {
            AppMain.gmMainDecideNextEvt();
            if ( ( AppMain.g_gm_main_system.game_flag & 2U ) != 0U )
            {
                AppMain.GmMainRestartExit();
                if ( AppMain.g_gs_main_sys_info.game_mode == 1 )
                {
                    AppMain.GmMainGSRetryInit();
                    return;
                }
            }
            else
            {
                AppMain.GmMainExit();
            }
            return;
        }
        if ( !AppMain.AoAccountIsCurrentEnable() )
        {
            AppMain.SyDecideEvtCase( 5 );
            AppMain.IzFadeInitEasy( 0U, 3U, 1f );
            AppMain.GmMainExit();
            return;
        }
        if ( ( AppMain.g_gm_main_system.game_flag & 4U ) != 0U && ( AppMain.g_gm_main_system.game_flag & 8U ) == 0U )
        {
            AppMain.g_gs_main_sys_info.game_flag |= 2U;
            AppMain.GmClearDemoStart();
            AppMain.g_gm_main_system.game_flag |= 8U;
        }
        if ( AppMain.GmMainCheckExeTimerCount() )
        {
            if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
            {
                AppMain.g_gm_main_system.game_time += 1U;
            }
            else if ( AppMain.g_gm_main_system.game_time != 0U )
            {
                AppMain.g_gm_main_system.game_time -= 1U;
            }
        }
        if ( AppMain.gmMainCheckExeSyncTimerCount() )
        {
            AppMain.g_gm_main_system.sync_time += 1U;
        }
        if ( ( AppMain.GmMainKeyCheckPauseKeyPush() != -1 || AppMain.gmMainIsSuspendedPause() || AppMain.isBackKeyPressed() || !AppMain.isForeground || AppMain.g_ao_sys_global.is_show_ui ) && AppMain.GmPauseCheckExecutable() )
        {
            AppMain.setBackKeyRequest( false );
            AppMain.GmMainClearSuspendedPause();
            AppMain.GmPauseInit();
            return;
        }
        if ( ( AppMain.g_gm_main_system.game_flag & 128U ) != 0U )
        {
            AppMain.gmMainDecideNextEvt();
            AppMain.g_gm_main_system.game_flag &= 4294967167U;
            if ( AppMain.GmPauseMenuGetResult() == 0 )
            {
                AppMain.GmMainRestartExit();
                AppMain.GmMainGSRetryInit();
                return;
            }
            AppMain.GmMainExit();
        }
    }

    // Token: 0x060003C3 RID: 963 RVA: 0x0001E144 File Offset: 0x0001C344
    private static void gmMainDecideNextEvt()
    {
        short evt_case;
        if ( ( AppMain.g_gm_main_system.game_flag & 128U ) != 0U )
        {
            switch ( AppMain.GmPauseMenuGetResult() )
            {
                case 0:
                    evt_case = 1;
                    goto IL_114;
                case 2:
                    evt_case = 0;
                    goto IL_114;
                case 3:
                    evt_case = 4;
                    goto IL_114;
            }
            evt_case = 1;
        }
        else if ( ( AppMain.g_gm_main_system.game_flag & 2U ) == 0U && AppMain.GsTrialIsTrial() )
        {
            AppMain.g_gs_main_sys_info.game_flag &= 4294967009U;
            AppMain.nextDemoLevel = 0;
            evt_case = 6;
        }
        else if ( AppMain.g_gs_main_sys_info.game_mode == 1 )
        {
            AppMain.GmMainClearSuspendedPause();
            if ( ( AppMain.g_gm_main_system.game_flag & 2U ) != 0U )
            {
                evt_case = 1;
            }
            else if ( AppMain.GsMainSysIsStageClear( 0 ) )
            {
                evt_case = 0;
            }
            else
            {
                evt_case = 4;
            }
        }
        else if ( ( AppMain.g_gm_main_system.game_flag & 4U ) != 0U )
        {
            if ( ( AppMain.g_gm_main_system.game_flag & 16384U ) != 0U )
            {
                evt_case = 3;
            }
            else if ( AppMain.g_gs_main_sys_info.stage_id == 16 )
            {
                evt_case = 2;
            }
            else
            {
                evt_case = 0;
            }
        }
        else if ( ( AppMain.g_gm_main_system.game_flag & 2U ) != 0U )
        {
            evt_case = 1;
        }
        else if ( AppMain.GsMainSysIsStageClear( 0 ) )
        {
            evt_case = 0;
        }
        else
        {
            evt_case = 4;
        }
        IL_114:
        AppMain.SyDecideEvtCase( evt_case );
    }

    // Token: 0x060003C4 RID: 964 RVA: 0x0001E26B File Offset: 0x0001C46B
    private static bool gmMainCheckExeSyncTimerCount()
    {
        return ( AppMain.g_gm_main_system.game_flag & 2048U ) != 0U;
    }

    // Token: 0x060003C5 RID: 965 RVA: 0x0001E284 File Offset: 0x0001C484
    private static void gmMainDataLoadBoosBattleMgr_LoadWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmGameDatLoadCheck() == AppMain.GME_GAMEDAT_LOAD_PROGRESS.GMD_GAMEDAT_LOAD_PROGRESS_COMPLETE )
        {
            AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)tcb.work;
            AppMain.GmGameDatLoadExit();
            AppMain.GmGameDatBuildBossBattleInit();
            AppMain.GmGameDatBuildBossBattle( gms_MAIN_LOAD_BB_MGR_WORK.boss_type );
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataLoadBoosBattleMgr_BuildWait ) );
        }
    }

    // Token: 0x060003C6 RID: 966 RVA: 0x0001E2CC File Offset: 0x0001C4CC
    private static void gmMainDataLoadBoosBattleMgr_BuildWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmGameDatBuildBossBattleCheck() )
        {
            AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)tcb.work;
            gms_MAIN_LOAD_BB_MGR_WORK.b_end = true;
            AppMain.g_gm_main_system.boss_load_no = gms_MAIN_LOAD_BB_MGR_WORK.boss_type;
            AppMain.g_gm_main_system.game_flag &= 4292870143U;
            AppMain.mtTaskClearTcb( tcb );
            AppMain.gm_main_load_bossbattle_tcb = null;
        }
    }

    // Token: 0x060003C7 RID: 967 RVA: 0x0001E328 File Offset: 0x0001C528
    private static void gmMainDataReleaseBoosBattleMgr_FlushWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmGameDatFlushBossBattleCheck() )
        {
            AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)tcb.work;
            AppMain.GmGameDatBoosBattleRelease( gms_MAIN_LOAD_BB_MGR_WORK.boss_type );
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataReleaseBoosBattleMgr_ReleaseWait ) );
        }
    }

    // Token: 0x060003C8 RID: 968 RVA: 0x0001E368 File Offset: 0x0001C568
    private static void gmMainDataReleaseBoosBattleMgr_ReleaseWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.GmGameDatReleaseCheck() )
        {
            AppMain.GMS_MAIN_LOAD_BB_MGR_WORK gms_MAIN_LOAD_BB_MGR_WORK = (AppMain.GMS_MAIN_LOAD_BB_MGR_WORK)tcb.work;
            gms_MAIN_LOAD_BB_MGR_WORK.b_end = true;
            AppMain.g_gm_main_system.boss_load_no = -1;
            AppMain.g_gm_main_system.game_flag &= 4290772991U;
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMainDataReleaseBoosBattleMgr_EndWait ) );
        }
    }

    // Token: 0x060003C9 RID: 969 RVA: 0x0001E3C2 File Offset: 0x0001C5C2
    private static void gmMainDataReleaseBoosBattleMgr_EndWait( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060003CA RID: 970 RVA: 0x0001E3C4 File Offset: 0x0001C5C4
    private static bool gmMainIsUseWaitUpCamera()
    {
        bool result = true;
        switch ( AppMain.g_gs_main_sys_info.stage_id )
        {
            case 3:
            case 7:
            case 11:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
                return false;
        }
        if ( ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 65536U ) != 0U )
        {
            result = false;
        }
        return result;
    }

    // Token: 0x060003CB RID: 971 RVA: 0x0001E46D File Offset: 0x0001C66D
    public static bool gmMainIsSuspendedPause()
    {
        return ( AppMain.g_gs_main_sys_info.game_flag & 536870912U ) != 0U;
    }

    // Token: 0x060003CC RID: 972 RVA: 0x0001E484 File Offset: 0x0001C684
    private static void gmMainUpdateSuspendedPause()
    {
        uint num = 4104U;
        if ( AppMain.GsMainSysGetSuspendedFlag() && ( AppMain.g_gm_main_system.game_flag & 32968936U & ~( num != 0U ? 1 : 0 ) ) == 0U )
        {
            AppMain.g_gs_main_sys_info.game_flag |= 536870912U;
        }
    }
}