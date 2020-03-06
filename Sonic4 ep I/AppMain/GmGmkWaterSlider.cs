using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200017E RID: 382
    public class GMS_GMK_WATER_SLIDER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002191 RID: 8593 RVA: 0x0014153F File Offset: 0x0013F73F
        public GMS_GMK_WATER_SLIDER_WORK()
        {
            this.gimmick_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002192 RID: 8594 RVA: 0x0014155E File Offset: 0x0013F75E
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x04004EA9 RID: 20137
        public readonly AppMain.GMS_ENEMY_3D_WORK gimmick_work;

        // Token: 0x04004EAA RID: 20138
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_parts = new AppMain.OBS_ACTION3D_NN_WORK();
    }

    // Token: 0x06000653 RID: 1619 RVA: 0x000382F8 File Offset: 0x000364F8
    private static void gmGmkWaterSliderEffectDestFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.g_gm_gmk_water_slider_se_handle != null )
        {
            AppMain.GmSoundStopSE( AppMain.g_gm_gmk_water_slider_se_handle );
            AppMain.GsSoundFreeSeHandle( AppMain.g_gm_gmk_water_slider_se_handle );
            AppMain.g_gm_gmk_water_slider_se_handle = null;
        }
        AppMain.GMM_PAD_VIB_STOP();
        AppMain.GmEffectDefaultExit( tcb );
        AppMain.g_gm_gmk_water_slider_effct_player = null;
    }

    // Token: 0x06000654 RID: 1620 RVA: 0x0003832C File Offset: 0x0003652C
    private static AppMain.OBS_OBJECT_WORK GmGmkWaterSliderCreateEffect()
    {
        if ( AppMain.g_gm_gmk_water_slider_effct_player == null )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
            AppMain.OBS_OBJECT_WORK obj_work = gms_PLAYER_WORK.obj_work;
            AppMain.g_gm_gmk_water_slider_effct_player = AppMain.GmEfctZoneEsCreate( obj_work, 2, 23 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_gmk_water_slider_effct_player;
            obs_OBJECT_WORK.parent_ofst.z = 131072;
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkWaterSliderEffectMainFunc );
            AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkWaterSliderEffectDestFunc ) );
        }
        if ( AppMain.g_gm_gmk_water_slider_se_handle == null )
        {
            AppMain.g_gm_gmk_water_slider_se_handle = AppMain.GsSoundAllocSeHandle();
            AppMain.GmSoundPlaySE( "WaterSlider", AppMain.g_gm_gmk_water_slider_se_handle );
        }
        AppMain.GMM_PAD_VIB_SMALL_TIME( 30f );
        return ( AppMain.OBS_OBJECT_WORK )AppMain.g_gm_gmk_water_slider_effct_player;
    }

    // Token: 0x06000655 RID: 1621 RVA: 0x000383DC File Offset: 0x000365DC
    private static void gmGmkWaterSliderEffectMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.seq_state != 36 )
        {
            AppMain.GmGmkWaterSliderDeleteEffect();
            return;
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06000656 RID: 1622 RVA: 0x0003840D File Offset: 0x0003660D
    private static void GmGmkWaterSliderDeleteEffect()
    {
        if ( AppMain.g_gm_gmk_water_slider_effct_player != null )
        {
            AppMain.g_gm_gmk_water_slider_effct_player.efct_com.obj_work.flag |= 8U;
            AppMain.g_gm_gmk_water_slider_effct_player = null;
        }
    }

    // Token: 0x06000657 RID: 1623 RVA: 0x00038438 File Offset: 0x00036638
    private static AppMain.OBS_OBJECT_WORK GmGmkWaterSliderInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        uint num;
        switch ( eve_rec.id )
        {
            case 116:
                num = 1U;
                goto IL_57;
            case 117:
                num = 2U;
                goto IL_57;
            case 118:
                num = 3U;
                goto IL_57;
            case 120:
                num = 5U;
                goto IL_57;
            case 121:
                num = 6U;
                goto IL_57;
            case 122:
                num = 7U;
                goto IL_57;
        }
        return null;
        IL_57:
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkWaterSliderLoadObj(eve_rec, pos_x, pos_y, num);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkWaterSliderInit( obj_work, num );
        return obj_work;
    }

    // Token: 0x06000658 RID: 1624 RVA: 0x000384BA File Offset: 0x000366BA
    public static void GmGmkWaterSliderBuild()
    {
        AppMain.g_gm_gmk_water_slider_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 832 ), AppMain.GmGameDatGetGimmickData( 833 ), 0U );
    }

    // Token: 0x06000659 RID: 1625 RVA: 0x000384DC File Offset: 0x000366DC
    public static void GmGmkWaterSliderFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(832);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_water_slider_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_water_slider_obj_3d_list = null;
    }

    // Token: 0x0600065A RID: 1626 RVA: 0x0003850A File Offset: 0x0003670A
    public static AppMain.OBS_ACTION3D_NN_WORK[] GmGmkWaterSliderGetObj3DList()
    {
        return AppMain.g_gm_gmk_water_slider_obj_3d_list;
    }

    // Token: 0x0600065B RID: 1627 RVA: 0x00038511 File Offset: 0x00036711
    private static uint gmGmkWaterSlidereGameSystemGetSyncTime()
    {
        return AppMain.g_gm_main_system.sync_time;
    }

    // Token: 0x0600065C RID: 1628 RVA: 0x00038524 File Offset: 0x00036724
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkWaterSliderLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, uint type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_WATER_SLIDER_WORK(), "GMK_WATER_SLIDER");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x0600065D RID: 1629 RVA: 0x00038598 File Offset: 0x00036798
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkWaterSliderLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, uint type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkWaterSliderLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        int num = AppMain.g_gm_gmk_water_slider_model_id_main[(int)((UIntPtr)type)];
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_water_slider_obj_3d_list[num], gms_ENEMY_3D_WORK.obj_3d );
        int index = AppMain.g_gm_gmk_water_slider_material_id_main[(int)((UIntPtr)type)];
        object pData = AppMain.ObjDataGet(835).pData;
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, index, ( AppMain.AMS_AMB_HEADER )pData );
        AppMain.GMS_GMK_WATER_SLIDER_WORK gms_GMK_WATER_SLIDER_WORK = (AppMain.GMS_GMK_WATER_SLIDER_WORK)obj_work;
        int num2 = AppMain.g_gm_gmk_water_slider_model_id_sub[(int)((UIntPtr)type)];
        if ( num2 != -1 )
        {
            AppMain.ObjCopyAction3dNNModel( AppMain.g_gm_gmk_water_slider_obj_3d_list[num2], gms_GMK_WATER_SLIDER_WORK.obj_3d_parts );
        }
        gms_GMK_WATER_SLIDER_WORK.obj_3d_parts.drawflag |= 32U;
        int num3 = AppMain.g_gm_gmk_water_slider_motion_id_sub[(int)((UIntPtr)type)];
        if ( num3 != -1 )
        {
            object pData2 = AppMain.ObjDataGet(834).pData;
            AppMain.ObjAction3dNNMotionLoad( gms_GMK_WATER_SLIDER_WORK.obj_3d_parts, 0, false, null, null, num3, ( AppMain.AMS_AMB_HEADER )pData2 );
        }
        int num4 = AppMain.g_gm_gmk_water_slider_material_id_sub[(int)((UIntPtr)type)];
        if ( num4 != -1 )
        {
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_GMK_WATER_SLIDER_WORK.obj_3d_parts, 0, null, null, num4, ( AppMain.AMS_AMB_HEADER )pData );
        }
        obj_work.disp_flag |= 268435456U;
        gms_GMK_WATER_SLIDER_WORK.obj_3d_parts.command_state = 17U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x0600065E RID: 1630 RVA: 0x000386C8 File Offset: 0x000368C8
    private static bool gmGmkWaterSliderCheckHFlip( uint type )
    {
        switch ( type )
        {
            case 0U:
            case 1U:
            case 2U:
            case 3U:
                return false;
            case 4U:
            case 5U:
            case 6U:
            case 7U:
                return true;
            default:
                return false;
        }
    }

    // Token: 0x0600065F RID: 1631 RVA: 0x00038704 File Offset: 0x00036904
    private static void gmGmkWaterSliderInit( AppMain.OBS_OBJECT_WORK obj_work, uint slider_type )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkWaterSliderSetRect( gimmick_work, slider_type );
        AppMain.gmGmkWaterSliderSetUserWorkSlideType( obj_work, slider_type );
        obj_work.move_flag = 8448U;
        int num = -61440;
        obj_work.dir.y = 49152;
        if ( AppMain.gmGmkWaterSliderCheckHFlip( slider_type ) )
        {
            obj_work.disp_flag |= 1U;
            num = -num;
        }
        AppMain.gmGmkWaterSliderSetUserTimerSlideSpeed( obj_work, num );
        obj_work.obj_3d.drawflag |= 32U;
        obj_work.pos.z = 131072;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        obj_work.disp_flag |= 20U;
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkWaterSliderDrawFunc );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkWaterSliderDestFunc ) );
    }

    // Token: 0x06000660 RID: 1632 RVA: 0x000387D8 File Offset: 0x000369D8
    private static void gmGmkWaterSliderSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work, uint slider_type )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        short num = 0;
        short num2 = 0;
        short num3 = 0;
        switch ( slider_type )
        {
            case 1U:
            case 5U:
                num = -64;
                num3 = 32;
                break;
            case 2U:
            case 6U:
                num = -64;
                num3 = 64;
                break;
            case 3U:
            case 7U:
                num = -64;
                num3 = 128;
                break;
        }
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, ( short )( num - 8 ), -8, -500, ( short )( num2 + 8 ), ( short )( num3 + 8 ), 500 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkWaterSliderDefFunc );
    }

    // Token: 0x06000661 RID: 1633 RVA: 0x0003887C File Offset: 0x00036A7C
    private static void gmGmkWaterSliderDestFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_WATER_SLIDER_WORK gms_GMK_WATER_SLIDER_WORK = (AppMain.GMS_GMK_WATER_SLIDER_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.ObjAction3dNNMotionRelease( gms_GMK_WATER_SLIDER_WORK.obj_3d_parts );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000662 RID: 1634 RVA: 0x000388A8 File Offset: 0x00036AA8
    private static void gmGmkWaterSliderDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( obj_3d.motion != null )
        {
            float num = AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num2 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num3 = num2 - num;
            float num4 = AppMain.gmGmkWaterSlidereGameSystemGetSyncTime();
            obj_3d.mat_frame = num4 % num3;
        }
        AppMain.ObjDrawActionSummary( obj_work );
        uint num5 = obj_work.disp_flag;
        num5 |= 4U;
        num5 &= 4294967279U;
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            num5 |= 4096U;
        }
        AppMain.GMS_GMK_WATER_SLIDER_WORK gms_GMK_WATER_SLIDER_WORK = (AppMain.GMS_GMK_WATER_SLIDER_WORK)obj_work;
        AppMain.VecFx32 pos = obj_work.pos;
        pos.z += 131072;
        AppMain.ObjDrawAction3DNN( gms_GMK_WATER_SLIDER_WORK.obj_3d_parts, new AppMain.VecFx32?( pos ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref num5 );
    }

    // Token: 0x06000663 RID: 1635 RVA: 0x00038978 File Offset: 0x00036B78
    private static void gmGmkWaterSliderDefFunc( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK player_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = player_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        if ( gms_PLAYER_WORK.seq_state == 36 )
        {
            gms_PLAYER_WORK.gmk_obj = parent_obj;
            return;
        }
        if ( ( parent_obj2.move_flag & 1U ) != 0U )
        {
            uint type = AppMain.gmGmkWaterSliderGetUserWorkSlideType(parent_obj);
            if ( AppMain.gmGmkWaterSliderCheckHFlip( type ) )
            {
                parent_obj2.disp_flag &= 4294967294U;
            }
            else
            {
                parent_obj2.disp_flag |= 1U;
            }
            parent_obj2.spd_m = AppMain.gmGmkWaterSliderGetUserTimerSlideSpeed( parent_obj );
            parent_obj2.spd.x = 0;
            parent_obj2.spd.y = 0;
            parent_obj2.spd_add.x = 0;
            parent_obj2.spd_add.y = 0;
            AppMain.GmPlySeqInitWaterSlider( gms_PLAYER_WORK, gms_ENEMY_3D_WORK.ene_com );
            gms_ENEMY_3D_WORK.ene_com.target_obj = parent_obj2;
            gimmick_rect.flag |= 1024U;
            parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkWaterSliderMainActive );
            AppMain.GmGmkWaterSliderCreateEffect();
            AppMain.nnMakeUnitMatrix( gms_PLAYER_WORK.ex_obj_mtx_r );
            int num = -6144;
            if ( ( parent_obj2.disp_flag & 1U ) != 0U )
            {
                num = -num;
            }
            AppMain.nnRotateYMatrix( gms_PLAYER_WORK.ex_obj_mtx_r, gms_PLAYER_WORK.ex_obj_mtx_r, num );
            gms_PLAYER_WORK.ex_obj_mtx_r.M13 = -2f;
            gms_PLAYER_WORK.gmk_flag |= 32768U;
        }
    }

    // Token: 0x06000664 RID: 1636 RVA: 0x00038AD0 File Offset: 0x00036CD0
    private static void gmGmkWaterSliderMainActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)target_obj;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        if ( gms_PLAYER_WORK.seq_state != 36 )
        {
            gms_ENEMY_3D_WORK.ene_com.target_obj = null;
            obs_RECT_WORK.flag &= 4294966271U;
            obj_work.ppFunc = null;
        }
    }

    // Token: 0x06000665 RID: 1637 RVA: 0x00038B34 File Offset: 0x00036D34
    private static void gmGmkWaterSliderSetUserWorkSlideType( AppMain.OBS_OBJECT_WORK obj_work, uint type )
    {
        obj_work.user_work = type;
    }

    // Token: 0x06000666 RID: 1638 RVA: 0x00038B3D File Offset: 0x00036D3D
    private static uint gmGmkWaterSliderGetUserWorkSlideType( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.user_work;
    }

    // Token: 0x06000667 RID: 1639 RVA: 0x00038B45 File Offset: 0x00036D45
    private static void gmGmkWaterSliderSetUserTimerSlideSpeed( AppMain.OBS_OBJECT_WORK obj_work, int speed )
    {
        obj_work.user_timer = speed;
    }

    // Token: 0x06000668 RID: 1640 RVA: 0x00038B4E File Offset: 0x00036D4E
    private static int gmGmkWaterSliderGetUserTimerSlideSpeed( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.user_timer;
    }
}
