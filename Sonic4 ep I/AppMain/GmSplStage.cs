using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000241 RID: 577
    public class GMS_SPL_STG_WORK
    {
        // Token: 0x040057F7 RID: 22519
        public uint counter;

        // Token: 0x040057F8 RID: 22520
        public uint flag;

        // Token: 0x040057F9 RID: 22521
        public int roll;

        // Token: 0x040057FA RID: 22522
        public int roll_spd;

        // Token: 0x040057FB RID: 22523
        public readonly AppMain.NNS_VECTOR light_vec = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040057FC RID: 22524
        public ushort get_ring;
    }

    // Token: 0x06000D7B RID: 3451 RVA: 0x00076010 File Offset: 0x00074210
    private static void GmSplStageStart()
    {
        ushort num = (ushort)(g_gs_main_sys_info.stage_id - 21);
        AppMain.gm_spl_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSplStageFadeInWait ), null, 0U, 0, 4176U, 5, () => new AppMain.GMS_SPL_STG_WORK(), "SPL_STG_CTRL" );
        AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = (AppMain.GMS_SPL_STG_WORK)AppMain.gm_spl_tcb.work;
        gms_SPL_STG_WORK.counter = 0U;
        gms_SPL_STG_WORK.light_vec.x = -1f;
        gms_SPL_STG_WORK.light_vec.y = -1f;
        gms_SPL_STG_WORK.light_vec.z = -1f;
        gms_SPL_STG_WORK.get_ring = 0;
        AppMain.g_gm_main_system.game_flag &= 4294508543U;
        AppMain.IzFadeInitEasy( 1U, 3U, 8f );
        AppMain.g_gm_main_system.game_time = AppMain.gm_spl_stage_init_time[( int )num];
        AppMain.g_gm_main_system.game_flag |= 4096U;
        Array.Clear( AppMain.gm_gmk_ss_switch, 0, AppMain.gm_gmk_ss_switch.Length );
    }

    // Token: 0x06000D7C RID: 3452 RVA: 0x00076116 File Offset: 0x00074316
    private static void GmSplStageExit()
    {
        if ( AppMain.gm_spl_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_spl_tcb );
            AppMain.gm_spl_tcb = null;
            AppMain.g_gm_main_system.game_flag &= 4294508543U;
        }
    }

    // Token: 0x06000D7D RID: 3453 RVA: 0x00076148 File Offset: 0x00074348
    private static void GmSplStageSetLight()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = -0.4f;
        nns_VECTOR.y = -0.4f;
        nns_VECTOR.z = -1f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_1, ref nns_RGBA, 1f, nns_VECTOR );
    }

    // Token: 0x06000D7E RID: 3454 RVA: 0x000761B8 File Offset: 0x000743B8
    private static AppMain.GMS_SPL_STG_WORK GmSplStageGetWork()
    {
        return ( AppMain.GMS_SPL_STG_WORK )AppMain.gm_spl_tcb.work;
    }

    // Token: 0x06000D7F RID: 3455 RVA: 0x000761D6 File Offset: 0x000743D6
    private static void GmSplStageSwSet( uint sw_no )
    {
        sw_no &= 15U;
        AppMain.gm_gmk_ss_switch[( int )( ( UIntPtr )sw_no )] = 1;
    }

    // Token: 0x06000D80 RID: 3456 RVA: 0x000761E7 File Offset: 0x000743E7
    private static bool GmSplStageSwCheck( uint sw_no )
    {
        sw_no &= 15U;
        return AppMain.gm_gmk_ss_switch[( int )( ( UIntPtr )sw_no )] != 0;
    }

    // Token: 0x06000D81 RID: 3457 RVA: 0x000761FC File Offset: 0x000743FC
    private static ushort GmSplStageRingGateNumGet( ushort gate_id )
    {
        ushort num = (ushort)(AppMain.g_gs_main_sys_info.stage_id - 21);
        return AppMain.gm_spl_stage_ringgate_num[( int )num][( int )gate_id];
    }

    // Token: 0x06000D82 RID: 3458 RVA: 0x00076224 File Offset: 0x00074424
    private static void gmSplStageFadeInWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = (AppMain.GMS_SPL_STG_WORK)tcb.work;
        gms_SPL_STG_WORK.counter += 1U;
        if ( gms_SPL_STG_WORK.counter > 30U )
        {
            gms_SPL_STG_WORK.counter = 0U;
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSplStageFadeInWait2 ) );
            AppMain.IzFadeInitEasy( 0U, 2U, 30f );
        }
    }

    // Token: 0x06000D83 RID: 3459 RVA: 0x0007627C File Offset: 0x0007447C
    private static void gmSplStageFadeInWait2( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            return;
        }
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
            gms_PLAYER_WORK.obj_work.move_flag &= 4294958847U;
            gms_PLAYER_WORK.nudge_di_timer = 0;
            gms_PLAYER_WORK.nudge_timer = 0;
            gms_PLAYER_WORK.nudge_ofst_x = 0;
            AppMain.g_gm_main_system.game_flag |= 1024U;
            AppMain.g_gm_main_system.game_flag &= 4294963199U;
            if ( AppMain.GmStartMsgIsExe() )
            {
                AppMain.GmStartMsgInit();
            }
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSplStagePlayEndChk ) );
        }
    }

    // Token: 0x06000D84 RID: 3460 RVA: 0x00076328 File Offset: 0x00074528
    private static void gmSplStagePlayEndChk( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = (AppMain.GMS_SPL_STG_WORK)tcb.work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            return;
        }
        AppMain.gmSplStageLightCtrl( gms_SPL_STG_WORK );
        gms_SPL_STG_WORK.flag &= 4294967294U;
        AppMain.gmSplStageNudgeCtrl();
        AppMain.gmSplStageRingGateChk( gms_SPL_STG_WORK );
        if ( ( AppMain.g_gm_main_system.game_flag & 458752U ) != 0U )
        {
            AppMain.g_gm_main_system.game_flag &= 4294966271U;
            gms_PLAYER_WORK.obj_work.flag |= 130U;
            gms_PLAYER_WORK.obj_work.move_flag |= 8448U;
            gms_PLAYER_WORK.obj_work.disp_flag &= 4294967294U;
            gms_PLAYER_WORK.player_flag |= 4194304U;
            if ( ( AppMain.g_gm_main_system.game_flag & 393216U ) != 0U )
            {
                AppMain.GMM_PAD_VIB_MID_TIME( 90f );
            }
            gms_SPL_STG_WORK.roll = obs_CAMERA.roll;
            gms_SPL_STG_WORK.roll_spd = 256;
            gms_SPL_STG_WORK.counter = 0U;
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSplStageRolling ) );
        }
    }

    // Token: 0x06000D85 RID: 3461 RVA: 0x0007644C File Offset: 0x0007464C
    private static void gmSplStageRolling( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = (AppMain.GMS_SPL_STG_WORK)tcb.work;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            return;
        }
        if ( obs_CAMERA == null )
        {
            return;
        }
        gms_SPL_STG_WORK.roll_spd += 56;
        gms_SPL_STG_WORK.roll += gms_SPL_STG_WORK.roll_spd;
        obs_CAMERA.roll = gms_SPL_STG_WORK.roll;
        gms_SPL_STG_WORK.counter += 1U;
        if ( gms_SPL_STG_WORK.counter == 90U )
        {
            AppMain.IzFadeInitEasy( 0U, 3U, 30f );
        }
        if ( gms_SPL_STG_WORK.counter > 90U && AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            AppMain.IzFadeRestoreDrawSetting();
            AppMain.GmObjSetAllObjectNoDisp();
            AppMain.GmRingGetWork().flag |= 1U;
            AppMain.GmFixSetDisp( false );
            gms_SPL_STG_WORK.flag |= 4U;
            gms_SPL_STG_WORK.counter = 1U;
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSplStageGotoEnd ) );
            obs_CAMERA.roll = 0;
            AppMain.g_gm_main_system.pseudofall_dir = 0;
        }
    }

    // Token: 0x06000D86 RID: 3462 RVA: 0x0007653C File Offset: 0x0007473C
    private static void gmSplStageGotoEnd( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = (AppMain.GMS_SPL_STG_WORK)tcb.work;
        if ( gms_SPL_STG_WORK.counter != 0U )
        {
            gms_SPL_STG_WORK.counter -= 1U;
            return;
        }
        AppMain.g_gm_main_system.game_flag |= 4U;
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSplStageEnd ) );
    }

    // Token: 0x06000D87 RID: 3463 RVA: 0x00076590 File Offset: 0x00074790
    private static void gmSplStageEnd( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
    }

    // Token: 0x06000D88 RID: 3464 RVA: 0x00076598 File Offset: 0x00074798
    private static void gmSplStageLightCtrl( AppMain.GMS_SPL_STG_WORK tcb_work )
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.UNREFERENCED_PARAMETER( tcb_work );
        nns_VECTOR = AppMain.gmSplStageLightRot( -1f, -1f, -1f );
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_0, ref nns_RGBA, 1f, nns_VECTOR );
        nns_VECTOR = AppMain.gmSplStageLightRot( -0.4f, -0.4f, -1f );
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_1, ref nns_RGBA, 1f, nns_VECTOR );
    }

    // Token: 0x06000D89 RID: 3465 RVA: 0x00076630 File Offset: 0x00074830
    private static AppMain.NNS_VECTOR gmSplStageLightRot( float pos_x, float pos_y, float pos_z )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        float num = pos_x * AppMain.nnSin((int)(-(int)AppMain.g_gm_main_system.pseudofall_dir));
        float num2 = pos_x * AppMain.nnCos((int)(-(int)AppMain.g_gm_main_system.pseudofall_dir));
        float num3 = pos_y * AppMain.nnSin((int)(-(int)AppMain.g_gm_main_system.pseudofall_dir));
        float num4 = pos_y * AppMain.nnCos((int)(-(int)AppMain.g_gm_main_system.pseudofall_dir));
        nns_VECTOR.x = num2 - num3;
        nns_VECTOR.y = num + num4;
        nns_VECTOR.z = pos_z;
        return nns_VECTOR;
    }

    // Token: 0x06000D8A RID: 3466 RVA: 0x000766AC File Offset: 0x000748AC
    private static void gmSplStageNudgeCtrl()
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        if ( gms_PLAYER_WORK.nudge_timer != 0 )
        {
            int num = ((int)(gms_PLAYER_WORK.nudge_timer * 8) << 12) / 30;
            if ( ( gms_PLAYER_WORK.nudge_timer & 2 ) != 0 )
            {
                num = -num;
            }
            int num2 = 0;
            AppMain.GmObjGetRotPosXY( num, num2, ref gms_PLAYER_WORK.obj_work.ofst.x, ref gms_PLAYER_WORK.obj_work.ofst.y, AppMain.g_gm_main_system.pseudofall_dir );
            AppMain.GmObjGetRotPosXY( num, num2, ref num, ref num2, ( ushort )-AppMain.g_gm_main_system.pseudofall_dir );
            obs_CAMERA.ofst.x = AppMain.FXM_FX32_TO_FLOAT( num );
            obs_CAMERA.ofst.y = AppMain.FXM_FX32_TO_FLOAT( num2 );
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK2 = gms_PLAYER_WORK;
            gms_PLAYER_WORK2.nudge_timer -= 1;
            return;
        }
        obs_CAMERA.ofst.x = 0f;
        obs_CAMERA.ofst.y = 0f;
        gms_PLAYER_WORK.obj_work.ofst.x = 0;
        gms_PLAYER_WORK.obj_work.ofst.y = 0;
        gms_PLAYER_WORK.nudge_ofst_x = 0;
    }

    // Token: 0x06000D8B RID: 3467 RVA: 0x000767BC File Offset: 0x000749BC
    private static void gmSplStageRingGateChk( AppMain.GMS_SPL_STG_WORK tcb_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        ushort get_ring = tcb_work.get_ring;
        for ( ushort num = 0; num < 9; num += 1 )
        {
            if ( ( ( int )tcb_work.get_ring & 1 << ( int )num ) == 0 )
            {
                ushort num2 = AppMain.GmSplStageRingGateNumGet(num);
                if ( num2 == 255 )
                {
                    break;
                }
                if ( num2 <= ( ushort )gms_PLAYER_WORK.ring_num )
                {
                    tcb_work.get_ring |= ( ushort )( 1 << ( int )num );
                }
            }
        }
        if ( get_ring != tcb_work.get_ring )
        {
            AppMain.GmSoundPlaySE( "Special7" );
        }
    }


    // Token: 0x06001548 RID: 5448 RVA: 0x000B923C File Offset: 0x000B743C
    public static void GmSpStageBranchInit( object arg )
    {
        AppMain.UNREFERENCED_PARAMETER( arg );
        AppMain.SYS_EVT_INFO sys_EVT_INFO = AppMain.SyGetEvtInfo();
        if ( sys_EVT_INFO.old_evt_id == 5 )
        {
            if ( AppMain.g_gs_main_sys_info.stage_id < 21 || AppMain.g_gs_main_sys_info.stage_id > 27 )
            {
                AppMain.g_gs_main_sys_info.stage_id = 21;
            }
        }
        else if ( !AppMain.GsMainSysIsStageClear( 21 ) )
        {
            AppMain.g_gs_main_sys_info.stage_id = 21;
        }
        else if ( !AppMain.GsMainSysIsStageClear( 22 ) )
        {
            AppMain.g_gs_main_sys_info.stage_id = 22;
        }
        else if ( !AppMain.GsMainSysIsStageClear( 23 ) )
        {
            AppMain.g_gs_main_sys_info.stage_id = 23;
        }
        else if ( !AppMain.GsMainSysIsStageClear( 24 ) )
        {
            AppMain.g_gs_main_sys_info.stage_id = 24;
        }
        else if ( !AppMain.GsMainSysIsStageClear( 25 ) )
        {
            AppMain.g_gs_main_sys_info.stage_id = 25;
        }
        else if ( !AppMain.GsMainSysIsStageClear( 26 ) )
        {
            AppMain.g_gs_main_sys_info.stage_id = 26;
        }
        else
        {
            AppMain.g_gs_main_sys_info.stage_id = 27;
        }
        AppMain.g_gs_main_sys_info.char_id[0] = 2;
        AppMain.g_gs_main_sys_info.game_flag |= 128U;
        AppMain.GmMainGSInit();
        AppMain.SyChangeNextEvt();
    }
}
