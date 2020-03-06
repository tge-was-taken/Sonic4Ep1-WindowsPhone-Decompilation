using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.backup;

public partial class AppMain
{
    // Token: 0x0200023D RID: 573
    public class GMS_START_DEMO_DATA : AppMain.IClearable
    {
        // Token: 0x0600239A RID: 9114 RVA: 0x00149273 File Offset: 0x00147473
        public void Clear()
        {
            Array.Clear( this.demo_amb, 0, this.demo_amb.Length );
            AppMain.ClearArray<AppMain.AOS_TEXTURE>( this.aos_texture );
            this.flag_regist = false;
        }

        // Token: 0x040057EC RID: 22508
        public readonly AppMain.AOS_TEXTURE[] aos_texture = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x040057ED RID: 22509
        public readonly object[] demo_amb = new object[2];

        // Token: 0x040057EE RID: 22510
        public bool flag_regist;
    }

    // Token: 0x0200023E RID: 574
    public class GMS_START_DEMO_WORK
    {
        // Token: 0x040057EF RID: 22511
        public uint counter;

        // Token: 0x040057F0 RID: 22512
        public uint flag;

        // Token: 0x040057F1 RID: 22513
        public AppMain.GMS_COCKPIT_2D_WORK[] action_obj_work_cmn = new AppMain.GMS_COCKPIT_2D_WORK[4];

        // Token: 0x040057F2 RID: 22514
        public AppMain.GMS_COCKPIT_2D_WORK[] action_obj_work_zone = new AppMain.GMS_COCKPIT_2D_WORK[1];

        // Token: 0x040057F3 RID: 22515
        public AppMain.GMS_COCKPIT_2D_WORK[] action_obj_work_act = new AppMain.GMS_COCKPIT_2D_WORK[2];

        // Token: 0x040057F4 RID: 22516
        public AppMain.GMS_COCKPIT_2D_WORK action_obj_work_message;

        // Token: 0x040057F5 RID: 22517
        public AppMain.GMS_START_DEMO_WORK._update_ update;

        // Token: 0x0200023F RID: 575
        // (Invoke) Token: 0x0600239E RID: 9118
        public delegate void _update_( AppMain.GMS_START_DEMO_WORK cont );
    }

    // Token: 0x02000240 RID: 576
    public class GMS_START_DEMO_MGR : AppMain.IClearable
    {
        // Token: 0x060023A1 RID: 9121 RVA: 0x001492E7 File Offset: 0x001474E7
        public void Clear()
        {
            this.main_tcb = null;
        }

        // Token: 0x040057F6 RID: 22518
        public AppMain.MTS_TASK_TCB main_tcb;
    }

    // Token: 0x06000D61 RID: 3425 RVA: 0x000754F0 File Offset: 0x000736F0
    private static void GmStartDemoBuild()
    {
        AppMain.gmStartDemoDataInit();
        AppMain.GMS_START_DEMO_DATA gms_START_DEMO_DATA = AppMain.gmStartDemoDataGetInfo();
        int num = 0;
        while ( 2 > num )
        {
            int num2 = AppMain.GsEnvGetLanguage();
            gms_START_DEMO_DATA.demo_amb[num] = AppMain.ObjDataLoadAmbIndex( null, AppMain.g_gm_start_demo_data_amb_id[num2][num], AppMain.GmGameDatGetCockpitData() );
            num++;
        }
        gms_START_DEMO_DATA.flag_regist = false;
    }

    // Token: 0x06000D62 RID: 3426 RVA: 0x00075540 File Offset: 0x00073740
    private static bool GmStartDemoBuildCheck()
    {
        AppMain.GMS_START_DEMO_DATA gms_START_DEMO_DATA = AppMain.gmStartDemoDataGetInfo();
        if ( !gms_START_DEMO_DATA.flag_regist )
        {
            if ( AppMain.GsMainSysGetDisplayListRegistNum() >= 192 )
            {
                return false;
            }
            int num = 0;
            while ( 2 > num )
            {
                AppMain.AoTexBuild( gms_START_DEMO_DATA.aos_texture[num], ( AppMain.AMS_AMB_HEADER )gms_START_DEMO_DATA.demo_amb[num] );
                AppMain.AoTexLoad( gms_START_DEMO_DATA.aos_texture[num] );
                num++;
            }
            gms_START_DEMO_DATA.flag_regist = true;
        }
        return AppMain.gmStartDemoDataCheckLoading();
    }

    // Token: 0x06000D63 RID: 3427 RVA: 0x000755A8 File Offset: 0x000737A8
    private static void GmStartDemoFlush()
    {
        AppMain.GMS_START_DEMO_DATA gms_START_DEMO_DATA = AppMain.gmStartDemoDataGetInfo();
        int num = 0;
        while ( 2 > num )
        {
            AppMain.AoTexRelease( gms_START_DEMO_DATA.aos_texture[num] );
            num++;
        }
    }

    // Token: 0x06000D64 RID: 3428 RVA: 0x000755D4 File Offset: 0x000737D4
    private static bool GmStartDemoFlushCheck()
    {
        if ( !AppMain.gmStartDemoDataCheckRelease() )
        {
            return false;
        }
        AppMain.gmStartDemoDataFlush();
        return true;
    }

    // Token: 0x06000D65 RID: 3429 RVA: 0x000755E5 File Offset: 0x000737E5
    private static void GmStartDemoStart()
    {
        AppMain.gmStartDemoInit();
        AppMain.gmStartDemoSetGameFlag( 4096U );
    }

    // Token: 0x06000D66 RID: 3430 RVA: 0x000755F6 File Offset: 0x000737F6
    private static void GmStartDemoExit()
    {
        AppMain.gmStartDemoExit();
    }

    // Token: 0x06000D67 RID: 3431 RVA: 0x000755FD File Offset: 0x000737FD
    private static void gmStartDemoDataInit()
    {
        AppMain.g_start_demo_data_real.Clear();
        AppMain.g_start_demo_data = AppMain.g_start_demo_data_real;
    }

    // Token: 0x06000D68 RID: 3432 RVA: 0x00075613 File Offset: 0x00073813
    private static void gmStartDemoDataFlush()
    {
        if ( AppMain.g_start_demo_data != null )
        {
            AppMain.g_start_demo_data = null;
        }
    }

    // Token: 0x06000D69 RID: 3433 RVA: 0x00075622 File Offset: 0x00073822
    private static AppMain.GMS_START_DEMO_DATA gmStartDemoDataGetInfo()
    {
        return AppMain.g_start_demo_data;
    }

    // Token: 0x06000D6A RID: 3434 RVA: 0x0007562C File Offset: 0x0007382C
    private static bool gmStartDemoDataCheckLoading()
    {
        int num = 0;
        AppMain.GMS_START_DEMO_DATA gms_START_DEMO_DATA = AppMain.gmStartDemoDataGetInfo();
        int num2 = 0;
        while ( 2 > num2 )
        {
            if ( AppMain.AoTexIsLoaded( gms_START_DEMO_DATA.aos_texture[num2] ) )
            {
                num |= 1 << num2;
            }
            num2++;
        }
        return 3 == num;
    }

    // Token: 0x06000D6B RID: 3435 RVA: 0x0007566C File Offset: 0x0007386C
    private static bool gmStartDemoDataCheckRelease()
    {
        int num = 0;
        AppMain.GMS_START_DEMO_DATA gms_START_DEMO_DATA = AppMain.gmStartDemoDataGetInfo();
        if ( gms_START_DEMO_DATA == null )
        {
            return true;
        }
        int num2 = 0;
        while ( 2 > num2 )
        {
            if ( AppMain.AoTexIsReleased( gms_START_DEMO_DATA.aos_texture[num2] ) )
            {
                num |= 1 << num2;
            }
            num2++;
        }
        return 3 == num;
    }

    // Token: 0x06000D6C RID: 3436 RVA: 0x000756B1 File Offset: 0x000738B1
    private static AppMain.GMS_START_DEMO_MGR gmStartDemoMgrGetInfo()
    {
        return AppMain.g_start_demo_mgr;
    }

    // Token: 0x06000D6D RID: 3437 RVA: 0x000756C0 File Offset: 0x000738C0
    private static void gmStartDemoInit()
    {
        AppMain.g_start_demo_mgr_real.Clear();
        AppMain.g_start_demo_mgr = AppMain.g_start_demo_mgr_real;
        AppMain.g_start_demo_mgr.main_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmStartDemoProcMain ), null, 0U, 0, 18448U, 5, () => new AppMain.GMS_START_DEMO_WORK(), "START_DEMO_MAIN" );
        AppMain.GMS_START_DEMO_WORK gms_START_DEMO_WORK = (AppMain.GMS_START_DEMO_WORK)AppMain.g_start_demo_mgr.main_tcb.work;
        gms_START_DEMO_WORK.counter = 0U;
        gms_START_DEMO_WORK.update = new AppMain.GMS_START_DEMO_WORK._update_( AppMain.gmStartDemoProcFade );
        AppMain.gmStartDemo2DActionCreate( gms_START_DEMO_WORK );
        AppMain.GMS_PLAYER_WORK ply_work = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GmPlySeqInitDemoFw( ply_work );
        AppMain.IzFadeInitEasy( 1U, 2U, 30f );
    }

    // Token: 0x06000D6E RID: 3438 RVA: 0x0007577C File Offset: 0x0007397C
    private static void gmStartDemoRequestExit()
    {
        AppMain.GMS_START_DEMO_MGR gms_START_DEMO_MGR = AppMain.gmStartDemoMgrGetInfo();
        if ( gms_START_DEMO_MGR != null )
        {
            if ( gms_START_DEMO_MGR.main_tcb != null )
            {
                AppMain.mtTaskClearTcb( gms_START_DEMO_MGR.main_tcb );
                gms_START_DEMO_MGR.main_tcb = null;
            }
            AppMain.gmStartDemoClearGameFlag( 4096U );
        }
    }

    // Token: 0x06000D6F RID: 3439 RVA: 0x000757B6 File Offset: 0x000739B6
    private static void gmStartDemoExit()
    {
        if ( AppMain.g_start_demo_mgr != null )
        {
            AppMain.gmStartDemoRequestExit();
            AppMain.g_start_demo_mgr = null;
        }
    }

    // Token: 0x06000D70 RID: 3440 RVA: 0x000757CC File Offset: 0x000739CC
    private static void gmStartDemoProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_START_DEMO_WORK gms_START_DEMO_WORK = (AppMain.GMS_START_DEMO_WORK)tcb.work;
        if ( ( gms_START_DEMO_WORK.flag & 1U ) != 0U )
        {
            AppMain.gmStartDemoRequestExit();
            return;
        }
        if ( gms_START_DEMO_WORK.update != null )
        {
            gms_START_DEMO_WORK.update( gms_START_DEMO_WORK );
        }
        gms_START_DEMO_WORK.counter += 1U;
    }

    // Token: 0x06000D71 RID: 3441 RVA: 0x00075817 File Offset: 0x00073A17
    private static void gmStartDemoSetGameFlag( uint flag )
    {
        AppMain.g_gm_main_system.game_flag |= flag;
    }

    // Token: 0x06000D72 RID: 3442 RVA: 0x0007582B File Offset: 0x00073A2B
    private static void gmStartDemoClearGameFlag( uint flag )
    {
        AppMain.g_gm_main_system.game_flag &= ~flag;
    }

    // Token: 0x06000D73 RID: 3443 RVA: 0x00075840 File Offset: 0x00073A40
    private static void gmStartDemo2DActionCreate( AppMain.GMS_START_DEMO_WORK work )
    {
        AppMain.GMS_START_DEMO_DATA gms_START_DEMO_DATA = AppMain.gmStartDemoDataGetInfo();
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        int num = AppMain.GsEnvGetLanguage();
        int num2 = 0;
        while ( 4 > num2 )
        {
            int num3 = AppMain.g_gm_start_demo_data_type_cmn[num2];
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = AppMain.gmStartDemo2DActionCreate(AppMain.g_gm_start_demo_action_name_cmn[num2], gms_START_DEMO_DATA.aos_texture[num3], AppMain.g_gm_start_demo_data_ama_id[num][num3], AppMain.g_gm_start_demo_action_id_cmn[num2], AppMain.g_gm_start_demo_action_node_flag_cmn[num2]);
            if ( gms_COCKPIT_2D_WORK != null )
            {
                gms_COCKPIT_2D_WORK.obj_2d.speed = 0f;
            }
            work.action_obj_work_cmn[num2] = gms_COCKPIT_2D_WORK;
            num2++;
        }
        int num4 = AppMain.g_gm_gamedat_zone_type_tbl[(int)gss_MAIN_SYS_INFO.stage_id];
        int num5 = 0;
        while ( 1 > num5 )
        {
            int num6 = AppMain.g_gm_start_demo_data_type_zone[num5];
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK2 = AppMain.gmStartDemo2DActionCreate(AppMain.g_gm_start_demo_action_name_zone[num5], gms_START_DEMO_DATA.aos_texture[num6], AppMain.g_gm_start_demo_data_ama_id[num][num6], AppMain.g_gm_start_demo_action_id_zone[num4][num5].Value, AppMain.g_gm_start_demo_action_node_flag_zone[num5]);
            if ( gms_COCKPIT_2D_WORK2 != null )
            {
                gms_COCKPIT_2D_WORK2.obj_2d.speed = 0f;
            }
            work.action_obj_work_zone[num5] = gms_COCKPIT_2D_WORK2;
            num5++;
        }
        int num7 = AppMain.g_gm_start_demo_act_no[(int)gss_MAIN_SYS_INFO.stage_id];
        if ( num4 != 4 )
        {
            int num8 = 0;
            while ( 2 > num8 )
            {
                int num9 = AppMain.g_gm_start_demo_data_type_act[num8];
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK3 = AppMain.gmStartDemo2DActionCreate(AppMain.g_gm_start_demo_action_name_act[num8], gms_START_DEMO_DATA.aos_texture[num9], AppMain.g_gm_start_demo_data_ama_id[num][num9], AppMain.g_gm_start_demo_action_id_act[num7][num8], AppMain.g_gm_start_demo_action_node_flag_act[num8]);
                if ( gms_COCKPIT_2D_WORK3 != null )
                {
                    gms_COCKPIT_2D_WORK3.obj_2d.speed = 0f;
                }
                work.action_obj_work_act[num8] = gms_COCKPIT_2D_WORK3;
                num8++;
            }
        }
        int num10 = 1;
        AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK4 = AppMain.gmStartDemo2DActionCreate(AppMain.g_gm_start_demo_action_name_message, gms_START_DEMO_DATA.aos_texture[num10], AppMain.g_gm_start_demo_data_ama_id[num][num10], AppMain.g_gm_start_demo_action_id_message[num4][num7], 1);
        if ( gms_COCKPIT_2D_WORK4 != null )
        {
            gms_COCKPIT_2D_WORK4.obj_2d.speed = 0f;
        }
        work.action_obj_work_message = gms_COCKPIT_2D_WORK4;
    }

    // Token: 0x06000D74 RID: 3444 RVA: 0x00075A1C File Offset: 0x00073C1C
    private static AppMain.GMS_COCKPIT_2D_WORK gmStartDemo2DActionCreate( string tcb_name, AppMain.AOS_TEXTURE aos_texture, int ama_id, int action_id, int node_flag )
    {
        if ( action_id == -1 )
        {
            return null;
        }
        AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, tcb_name);
        gms_COCKPIT_2D_WORK.cpit_com.obj_work.disp_flag |= ( uint )node_flag;
        AppMain.ObjObjectAction2dAMALoadSetTexlist( gms_COCKPIT_2D_WORK.cpit_com.obj_work, gms_COCKPIT_2D_WORK.obj_2d, null, null, ama_id, AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( aos_texture ), ( uint )action_id, node_flag );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_COCKPIT_2D_WORK;
        obs_OBJECT_WORK.pos.z = obs_OBJECT_WORK.pos.z - AppMain.FX_F32_TO_FX32( 10f );
        return gms_COCKPIT_2D_WORK;
    }

    // Token: 0x06000D75 RID: 3445 RVA: 0x00075ABC File Offset: 0x00073CBC
    private static void gmStartDemoProcFade( AppMain.GMS_START_DEMO_WORK work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            work.update = new AppMain.GMS_START_DEMO_WORK._update_( AppMain.gmStartDemoProcIn );
            work.counter = 0U;
            int num = 0;
            while ( 4 > num )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = work.action_obj_work_cmn[num];
                if ( gms_COCKPIT_2D_WORK != null )
                {
                    gms_COCKPIT_2D_WORK.obj_2d.speed = 1f;
                    gms_COCKPIT_2D_WORK.obj_2d.frame = 0f;
                }
                num++;
            }
            int num2 = 0;
            while ( 1 > num2 )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK2 = work.action_obj_work_zone[num2];
                if ( gms_COCKPIT_2D_WORK2 != null )
                {
                    gms_COCKPIT_2D_WORK2.obj_2d.speed = 1f;
                    gms_COCKPIT_2D_WORK2.obj_2d.frame = 0f;
                }
                num2++;
            }
            int num3 = 0;
            while ( 2 > num3 )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK3 = work.action_obj_work_act[num3];
                if ( gms_COCKPIT_2D_WORK3 != null )
                {
                    gms_COCKPIT_2D_WORK3.obj_2d.speed = 1f;
                    gms_COCKPIT_2D_WORK3.obj_2d.frame = 0f;
                }
                num3++;
            }
            AppMain.GMS_COCKPIT_2D_WORK action_obj_work_message = work.action_obj_work_message;
            if ( action_obj_work_message != null )
            {
                action_obj_work_message.obj_2d.speed = 1f;
                action_obj_work_message.obj_2d.frame = 0f;
            }
        }
    }

    // Token: 0x06000D76 RID: 3446 RVA: 0x00075BD0 File Offset: 0x00073DD0
    private static void gmStartDemoProcIn( AppMain.GMS_START_DEMO_WORK work )
    {
        if ( work.counter >= 39U )
        {
            work.update = new AppMain.GMS_START_DEMO_WORK._update_( AppMain.gmStartDemoProcWait );
            int num = 0;
            while ( 4 > num )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = work.action_obj_work_cmn[num];
                if ( gms_COCKPIT_2D_WORK != null )
                {
                    gms_COCKPIT_2D_WORK.obj_2d.speed = 0f;
                    gms_COCKPIT_2D_WORK.obj_2d.frame = 40f;
                }
                num++;
            }
            int num2 = 0;
            while ( 1 > num2 )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK2 = work.action_obj_work_zone[num2];
                if ( gms_COCKPIT_2D_WORK2 != null )
                {
                    gms_COCKPIT_2D_WORK2.obj_2d.speed = 0f;
                    gms_COCKPIT_2D_WORK2.obj_2d.frame = 40f;
                }
                num2++;
            }
            int num3 = 0;
            while ( 2 > num3 )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK3 = work.action_obj_work_act[num3];
                if ( gms_COCKPIT_2D_WORK3 != null )
                {
                    gms_COCKPIT_2D_WORK3.obj_2d.speed = 0f;
                    gms_COCKPIT_2D_WORK3.obj_2d.frame = 40f;
                }
                num3++;
            }
            AppMain.GMS_COCKPIT_2D_WORK action_obj_work_message = work.action_obj_work_message;
            if ( action_obj_work_message != null )
            {
                action_obj_work_message.obj_2d.speed = 0f;
                action_obj_work_message.obj_2d.frame = 40f;
            }
        }
    }

    // Token: 0x06000D77 RID: 3447 RVA: 0x00075CDC File Offset: 0x00073EDC
    public static bool GmStartMsgIsExe()
    {
        bool flag = false;
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 4U ) == 0U )
        {
            SSystem ssystem = SSystem.CreateInstance();
            ushort stage_id = gss_MAIN_SYS_INFO.stage_id;
            if ( stage_id != 5 )
            {
                if ( stage_id != 9 )
                {
                    switch ( stage_id )
                    {
                        case 21:
                            if ( !AppMain.GsMainSysIsStageClear( 21 ) )
                            {
                                flag = true;
                            }
                            break;
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                            break;
                        default:
                            goto IL_11D;
                    }
                    if ( !flag )
                    {
                        if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
                        {
                            if ( !ssystem.IsAnnounce( SSystem.EAnnounce.SpecialStageFlick ) )
                            {
                                flag = true;
                            }
                        }
                        else if ( !ssystem.IsAnnounce( SSystem.EAnnounce.SpecialStageTilt ) )
                        {
                            flag = true;
                        }
                    }
                    if ( flag )
                    {
                        if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
                        {
                            ssystem.SetAnnounce( SSystem.EAnnounce.SpecialStageFlick, true );
                        }
                        else
                        {
                            ssystem.SetAnnounce( SSystem.EAnnounce.SpecialStageTilt, true );
                        }
                    }
                }
                else
                {
                    if ( !AppMain.GsMainSysIsStageClear( 9 ) )
                    {
                        flag = true;
                    }
                    else if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
                    {
                        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.TruckFlick ) )
                        {
                            flag = true;
                        }
                    }
                    else if ( !ssystem.IsAnnounce( SSystem.EAnnounce.TruckTilt ) )
                    {
                        flag = true;
                    }
                    if ( flag )
                    {
                        if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
                        {
                            ssystem.SetAnnounce( SSystem.EAnnounce.TruckFlick, true );
                        }
                        else
                        {
                            ssystem.SetAnnounce( SSystem.EAnnounce.TruckTilt, true );
                        }
                    }
                }
            }
            else
            {
                flag = !AppMain.GsMainSysIsStageClear( 5 );
            }
        }
        IL_11D:
        if ( flag )
        {
            AppMain.GmMainClearSuspendedPause();
        }
        return flag;
    }

    // Token: 0x06000D78 RID: 3448 RVA: 0x00075E10 File Offset: 0x00074010
    private static void gmStartDemoProcWait( AppMain.GMS_START_DEMO_WORK work )
    {
        if ( work.counter >= 160U )
        {
            work.update = new AppMain.GMS_START_DEMO_WORK._update_( AppMain.gmStartDemoProcOut );
            if ( AppMain.GmStartMsgIsExe() )
            {
                AppMain.GmStartMsgInit();
            }
            else
            {
                AppMain.GMS_PLAYER_WORK ply_work = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
                AppMain.GmPlySeqChangeSequence( ply_work, 0 );
                AppMain.gmStartDemoSetGameFlag( 1024U );
            }
            int num = 0;
            while ( 4 > num )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = work.action_obj_work_cmn[num];
                if ( gms_COCKPIT_2D_WORK != null )
                {
                    gms_COCKPIT_2D_WORK.obj_2d.speed = 1f;
                }
                num++;
            }
            int num2 = 0;
            while ( 1 > num2 )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK2 = work.action_obj_work_zone[num2];
                if ( gms_COCKPIT_2D_WORK2 != null )
                {
                    gms_COCKPIT_2D_WORK2.obj_2d.speed = 1f;
                }
                num2++;
            }
            int num3 = 0;
            while ( 2 > num3 )
            {
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK3 = work.action_obj_work_act[num3];
                if ( gms_COCKPIT_2D_WORK3 != null )
                {
                    gms_COCKPIT_2D_WORK3.obj_2d.speed = 1f;
                }
                num3++;
            }
            AppMain.GMS_COCKPIT_2D_WORK action_obj_work_message = work.action_obj_work_message;
            if ( action_obj_work_message != null )
            {
                action_obj_work_message.obj_2d.speed = 1f;
            }
        }
    }

    // Token: 0x06000D79 RID: 3449 RVA: 0x00075F0D File Offset: 0x0007410D
    private static void gmStartDemoProcOut( AppMain.GMS_START_DEMO_WORK work )
    {
        if ( work.counter > 230U )
        {
            work.update = new AppMain.GMS_START_DEMO_WORK._update_( AppMain.gmStartDemoProcEnd );
        }
    }

    // Token: 0x06000D7A RID: 3450 RVA: 0x00075F30 File Offset: 0x00074130
    private static void gmStartDemoProcEnd( AppMain.GMS_START_DEMO_WORK work )
    {
        work.update = null;
        AppMain.gmStartDemoRequestExit();
        int num = 0;
        while ( 4 > num )
        {
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = work.action_obj_work_cmn[num];
            if ( gms_COCKPIT_2D_WORK != null )
            {
                gms_COCKPIT_2D_WORK.cpit_com.obj_work.flag |= 8U;
            }
            num++;
        }
        int num2 = 0;
        while ( 1 > num2 )
        {
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK2 = work.action_obj_work_zone[num2];
            if ( gms_COCKPIT_2D_WORK2 != null )
            {
                gms_COCKPIT_2D_WORK2.cpit_com.obj_work.flag |= 8U;
            }
            num2++;
        }
        int num3 = 0;
        while ( 2 > num3 )
        {
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK3 = work.action_obj_work_act[num3];
            if ( gms_COCKPIT_2D_WORK3 != null )
            {
                gms_COCKPIT_2D_WORK3.cpit_com.obj_work.flag |= 8U;
            }
            num3++;
        }
        AppMain.GMS_COCKPIT_2D_WORK action_obj_work_message = work.action_obj_work_message;
        if ( action_obj_work_message != null )
        {
            action_obj_work_message.cpit_com.obj_work.flag |= 8U;
        }
    }
}
