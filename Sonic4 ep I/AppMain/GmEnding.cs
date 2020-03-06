using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002A4 RID: 676
    public class GMS_ENDING_WORK
    {
        // Token: 0x04005AD7 RID: 23255
        public int step;

        // Token: 0x04005AD8 RID: 23256
        public int type;

        // Token: 0x04005AD9 RID: 23257
        public uint flag;

        // Token: 0x04005ADA RID: 23258
        public uint get_ring;

        // Token: 0x04005ADB RID: 23259
        public uint timer;
    }


    // Token: 0x06001256 RID: 4694 RVA: 0x000A0678 File Offset: 0x0009E878
    private static void GmEndingTrophySet()
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = AppMain.gmEndingGetWork();
        if ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] != null )
        {
            AppMain.GsGetMainSysInfo().clear_ring = gms_ENDING_WORK.get_ring;
            return;
        }
        AppMain.GsGetMainSysInfo().clear_ring = 0U;
    }

    // Token: 0x06001257 RID: 4695 RVA: 0x000A06B6 File Offset: 0x0009E8B6
    public static void GmEndingExit()
    {
        if ( AppMain.gm_ending_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_ending_tcb );
            AppMain.g_gm_main_system.game_flag &= 4286578687U;
            AppMain.gm_ending_tcb = null;
        }
    }

    // Token: 0x06001258 RID: 4696 RVA: 0x000A06EC File Offset: 0x0009E8EC
    public static void GmEndingStart()
    {
        AppMain.g_gm_main_system.game_flag |= 8388608U;
        AppMain.GmFixSetDispEx( false, false, false, true, false );
        AppMain.gm_ending_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEndingCtrl ), null, 0U, 0, 18448U, 5, () => new AppMain.GMS_ENDING_WORK(), "ENDING_CTRL" );
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = (AppMain.GMS_ENDING_WORK)AppMain.gm_ending_tcb.work;
        gms_ENDING_WORK.step = 0;
        gms_ENDING_WORK.flag = 1U;
        gms_ENDING_WORK.timer = 16U;
        AppMain.GmCameraAllowSet( 0f, 50f, 0f );
        AppMain.g_gm_main_system.map_fcol.bottom = AppMain.g_gm_main_system.map_fcol.bottom - 32;
    }

    // Token: 0x06001259 RID: 4697 RVA: 0x000A07B5 File Offset: 0x0009E9B5
    public static void GmEndingBuild()
    {
        AppMain.gm_ending_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 949 ), AppMain.GmGameDatGetGimmickData( 950 ), 0U );
    }

    // Token: 0x0600125A RID: 4698 RVA: 0x000A07D8 File Offset: 0x0009E9D8
    public static void GmEndingFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(949);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ending_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600125B RID: 4699 RVA: 0x000A0800 File Offset: 0x0009EA00
    public static AppMain.GMS_ENDING_WORK gmEndingGetWork()
    {
        return ( AppMain.GMS_ENDING_WORK )AppMain.gm_ending_tcb.work;
    }

    // Token: 0x0600125C RID: 4700 RVA: 0x000A0820 File Offset: 0x0009EA20
    public static bool GmEndingAnimalForwardChk()
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = AppMain.gmEndingGetWork();
        return gms_ENDING_WORK.type != 0 && gms_ENDING_WORK.step >= 7;
    }

    // Token: 0x0600125D RID: 4701 RVA: 0x000A0848 File Offset: 0x0009EA48
    public static void GmEndingPlyKeyCustom( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = AppMain.gmEndingGetWork();
        if ( ( gms_ENDING_WORK.flag & 1U ) != 0U )
        {
            ply_work.key_on = 0;
            ply_work.key_push = 0;
            ply_work.key_release = 0;
        }
        else
        {
            ply_work.key_on &= 160;
            ply_work.key_push &= 160;
            ply_work.key_release &= 160;
        }
        ply_work.key_rot_z = ( ply_work.key_walk_rot_z = 0 );
        if ( ( gms_ENDING_WORK.flag & 2U ) != 0U )
        {
            ply_work.key_on |= 4;
            ply_work.key_rot_z = ( ply_work.key_walk_rot_z = -32767 );
            return;
        }
        if ( ( gms_ENDING_WORK.flag & 4U ) != 0U )
        {
            ply_work.key_on |= 8;
            ply_work.key_rot_z = ( ply_work.key_walk_rot_z = 32767 );
        }
    }

    // Token: 0x0600125E RID: 4702 RVA: 0x000A0920 File Offset: 0x0009EB20
    private static void GmEndingPlyNopSet()
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = AppMain.gmEndingGetWork();
        if ( gms_ENDING_WORK.step == 1 )
        {
            gms_ENDING_WORK.step = 2;
            AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work.spd_m = -36864;
        }
    }

    // Token: 0x0600125F RID: 4703 RVA: 0x000A0960 File Offset: 0x0009EB60
    private static void GmEndingPlyBrakeSet()
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = AppMain.gmEndingGetWork();
        if ( gms_ENDING_WORK.step == 2 )
        {
            gms_ENDING_WORK.step = 3;
            AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work.pos.x = 2080768;
            AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work.spd_m = -36864;
        }
    }

    // Token: 0x06001260 RID: 4704 RVA: 0x000A09C0 File Offset: 0x0009EBC0
    private static void gmEndingLastPic( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        obj_work.disp_flag |= 32U;
        if ( gms_PLAYER_WORK.act_state == 80 || gms_PLAYER_WORK.act_state == 82 || gms_PLAYER_WORK.act_state == 84 )
        {
            obj_work.disp_flag &= 4294967263U;
            gms_PLAYER_WORK.obj_work.disp_flag |= 32U;
        }
    }

    // Token: 0x06001261 RID: 4705 RVA: 0x000A0A34 File Offset: 0x0009EC34
    private static void gmEndingLastPicInit()
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = AppMain.gmEndingGetWork();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), gms_PLAYER_WORK.obj_work, 0, "END_PIC");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEndingLastPic );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ending_obj_3d_list[gms_ENDING_WORK.type], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.move_flag |= 16128U;
        obs_OBJECT_WORK.disp_flag |= 4194336U;
        obs_OBJECT_WORK.flag |= 1026U;
        obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = ( obs_OBJECT_WORK.scale.z = 5120 ) );
        obs_OBJECT_WORK.parent_ofst.y = AppMain.gm_ending_obj_offset[gms_ENDING_WORK.type];
    }

    // Token: 0x06001262 RID: 4706 RVA: 0x000A0B34 File Offset: 0x0009ED34
    private static void gmEndingCtrl( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_ENDING_WORK gms_ENDING_WORK = (AppMain.GMS_ENDING_WORK)tcb.work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        switch ( gms_ENDING_WORK.step )
        {
            case 0:
                if ( gms_ENDING_WORK.timer != 0U )
                {
                    gms_ENDING_WORK.timer -= 1U;
                    return;
                }
                AppMain.g_gm_main_system.game_flag |= 1024U;
                AppMain.IzFadeInitEasy( 1U, 2U, 60f );
                gms_ENDING_WORK.step = 1;
                gms_ENDING_WORK.flag = 2U;
                AppMain.GmSoundPlayStageBGM( 0 );
                return;
            case 1:
                break;
            case 2:
                gms_ENDING_WORK.flag |= 1U;
                gms_PLAYER_WORK.spd_jump_add = gms_PLAYER_WORK.spd_add;
                return;
            case 3:
                gms_PLAYER_WORK.obj_work.disp_flag |= 1U;
                if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U && gms_PLAYER_WORK.obj_work.spd_m > -4096 )
                {
                    if ( AppMain.amTpIsTouchOn( 0 ) )
                    {
                        gms_PLAYER_WORK.ring_num = ( short )AppMain.GmEventMgrGetRingNum();
                        if ( AppMain.amTpIsTouchOn( 1 ) )
                        {
                            AppMain.g_gs_main_sys_info.game_flag |= 32U;
                        }
                        else
                        {
                            AppMain.g_gs_main_sys_info.game_flag &= 4294967263U;
                        }
                    }
                    gms_ENDING_WORK.get_ring = ( uint )gms_PLAYER_WORK.ring_num;
                    if ( gms_ENDING_WORK.get_ring < AppMain.GmEventMgrGetRingNum() )
                    {
                        gms_ENDING_WORK.step = 4;
                        gms_ENDING_WORK.type = 0;
                    }
                    else if ( ( AppMain.g_gs_main_sys_info.game_flag & 32U ) != 0U )
                    {
                        gms_ENDING_WORK.step = 5;
                        gms_ENDING_WORK.type = 2;
                    }
                    else
                    {
                        gms_ENDING_WORK.step = 4;
                        gms_ENDING_WORK.type = 1;
                    }
                    gms_ENDING_WORK.flag &= 4294967291U;
                    AppMain.gmEndingLastPicInit();
                    return;
                }
                gms_ENDING_WORK.flag &= 4294967293U;
                gms_ENDING_WORK.flag |= 4U;
                return;
            case 4:
                if ( AppMain.g_gm_main_system.game_time > 720U && gms_PLAYER_WORK.seq_state != 62 )
                {
                    AppMain.GmPlySeqGmkInitEndingDemo1( gms_PLAYER_WORK );
                    gms_ENDING_WORK.step = 6;
                    return;
                }
                break;
            case 5:
                if ( AppMain.g_gm_main_system.game_time > 720U && gms_PLAYER_WORK.seq_state != 24 )
                {
                    AppMain.GmPlySeqChangeTransformSuper( gms_PLAYER_WORK );
                    gms_ENDING_WORK.step = 6;
                    return;
                }
                break;
            case 6:
                if ( AppMain.g_gm_main_system.game_time > 900U && gms_PLAYER_WORK.seq_state != 63 )
                {
                    bool type = false;
                    if ( gms_ENDING_WORK.type == 1 )
                    {
                        type = true;
                    }
                    AppMain.GmPlySeqGmkInitEndingDemo2( gms_PLAYER_WORK, type );
                    gms_ENDING_WORK.step = 7;
                    return;
                }
                break;
            case 7:
                if ( AppMain.g_gm_main_system.game_time > 1140U )
                {
                    AppMain.IzFadeInitEasy( 0U, 1U, 32f );
                    gms_ENDING_WORK.step = 8;
                    return;
                }
                break;
            case 8:
                if ( AppMain.IzFadeIsEnd() )
                {
                    AppMain.GmMainEnd();
                    AppMain.SyDecideEvtCase( 0 );
                    AppMain.SyChangeNextEvt();
                }
                break;
            default:
                return;
        }
    }
}