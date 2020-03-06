using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200031A RID: 794
    private class GMS_GMK_FLIPPER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002577 RID: 9591 RVA: 0x0014D80D File Offset: 0x0014BA0D
        public GMS_GMK_FLIPPER_WORK()
        {
            this.gimmick_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002578 RID: 9592 RVA: 0x0014D837 File Offset: 0x0014BA37
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x04005DAD RID: 23981
        public readonly AppMain.GMS_ENEMY_3D_WORK gimmick_work = new AppMain.GMS_ENEMY_3D_WORK();

        // Token: 0x04005DAE RID: 23982
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_parts = new AppMain.OBS_ACTION3D_NN_WORK();
    }


    // Token: 0x06001569 RID: 5481 RVA: 0x000B9F9F File Offset: 0x000B819F
    private static void GmGmkFlipperBuild()
    {
        AppMain.g_gm_gmk_flipper_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 867 ), AppMain.GmGameDatGetGimmickData( 868 ), 0U );
    }

    // Token: 0x0600156A RID: 5482 RVA: 0x000B9FC0 File Offset: 0x000B81C0
    private static void GmGmkFlipperFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(867);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_flipper_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_flipper_obj_3d_list = null;
    }

    // Token: 0x0600156B RID: 5483 RVA: 0x000B9FF0 File Offset: 0x000B81F0
    private static AppMain.OBS_OBJECT_WORK GmGmkFlipperInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int num = AppMain.gmGmkFlipperCalcType((int)eve_rec.id);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkFlipperLoadObj(eve_rec, pos_x, pos_y, num);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkFlipperInit( obj_work, num );
        return obj_work;
    }

    // Token: 0x0600156C RID: 5484 RVA: 0x000BA027 File Offset: 0x000B8227
    private static uint gmGmkFlipperGameSystemGetSyncTime()
    {
        return AppMain.g_gm_main_system.sync_time;
    }

    // Token: 0x0600156D RID: 5485 RVA: 0x000BA044 File Offset: 0x000B8244
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkFlipperLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK;
        if ( type == 2 )
        {
            gms_ENEMY_3D_WORK = ( AppMain.GMS_ENEMY_3D_WORK )AppMain.GMM_ENEMY_CREATE_RIDE_WORK( eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_FLIPPER_WORK(), "GMK_FLIPPER_LR" );
        }
        else
        {
            gms_ENEMY_3D_WORK = ( AppMain.GMS_ENEMY_3D_WORK )AppMain.GMM_ENEMY_CREATE_WORK( eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_FLIPPER_WORK(), "GMK_FLIPPER_U" );
        }
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x0600156E RID: 5486 RVA: 0x000BA0F0 File Offset: 0x000B82F0
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkFlipperLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkFlipperLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        int num = AppMain.g_gm_gmk_flipper_model_id[type];
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_flipper_obj_3d_list[num], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.OBS_DATA_WORK data_work = AppMain.ObjDataGet(869);
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, 0, data_work, null, 0, null );
        if ( type == 2 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 16;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 8;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -7;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 32U;
        }
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x0600156F RID: 5487 RVA: 0x000BA1FC File Offset: 0x000B83FC
    private static void gmGmkFlipperInit( AppMain.OBS_OBJECT_WORK obj_work, int flipper_type )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkFlipperSetRect( gimmick_work, flipper_type );
        obj_work.move_flag = 8448U;
        obj_work.dir.z = AppMain.g_gm_gmk_flipper_angle_z[flipper_type];
        if ( flipper_type == 0 )
        {
            obj_work.user_flag = 1U;
        }
        obj_work.disp_flag |= 4194304U;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, AppMain.g_gm_gmk_flipper_mat_motion_id[flipper_type] );
        obj_work.disp_flag |= 4194308U;
        obj_work.pos.z = -122880;
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkFlipperDrawFunc );
        AppMain.gmGmkFlipperChangeModeWait( obj_work );
    }

    // Token: 0x06001570 RID: 5488 RVA: 0x000BA2A8 File Offset: 0x000B84A8
    private static void gmGmkFlipperSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work, int flipper_type )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        switch ( flipper_type )
        {
            case 0:
                obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkFlipperDefFuncU );
                break;
            case 1:
                obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkFlipperDefFuncU );
                break;
            case 2:
                obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkFlipperDefFuncLR );
                break;
        }
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, AppMain.g_gmk_flipper_rect[flipper_type][0], AppMain.g_gmk_flipper_rect[flipper_type][1], -500, AppMain.g_gmk_flipper_rect[flipper_type][2], AppMain.g_gmk_flipper_rect[flipper_type][3], 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
    }

    // Token: 0x06001571 RID: 5489 RVA: 0x000BA368 File Offset: 0x000B8568
    private static void gmGmkFlipperDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( obj_3d.motion != null )
        {
            float num = AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num2 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num3 = num2 - num;
            float num4 = AppMain.gmGmkFlipperGameSystemGetSyncTime();
            obj_3d.mat_frame = num4 % num3;
        }
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06001572 RID: 5490 RVA: 0x000BA3C8 File Offset: 0x000B85C8
    private static int gmGmkFlipperCalcType( int id )
    {
        return id - 169;
    }

    // Token: 0x06001573 RID: 5491 RVA: 0x000BA3E0 File Offset: 0x000B85E0
    private static void gmGmkFlipperDefPlayer( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        if ( gms_PLAYER_WORK.seq_state >= 60 )
        {
            return;
        }
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        gms_ENEMY_3D_WORK.ene_com.target_obj = parent_obj2;
        int num2 = AppMain.gmGmkFlipperCalcRideOffsetY(parent_obj2.pos.x, parent_obj, num);
        if ( parent_obj.pos.y + num2 < parent_obj2.pos.y )
        {
            int num3 = parent_obj2.pos.x - parent_obj.pos.x;
            if ( num == 1 )
            {
                num3 = -num3;
            }
            if ( num3 < 0 )
            {
                parent_obj2.spd.x = 0;
            }
            bool flag_no_recover_homing = false;
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                flag_no_recover_homing = true;
            }
            AppMain.GmPlySeqInitPinballAir( gms_PLAYER_WORK, parent_obj2.spd.x, 8192, 5, flag_no_recover_homing );
            return;
        }
        if ( AppMain.gmGmkFlipperCheckRect( parent_obj.pos, parent_obj2.pos, num ) == 0 )
        {
            gimmick_rect.flag &= 4294966271U;
            return;
        }
        AppMain.gmGmkFlipperChangeModeReady( parent_obj );
        gimmick_rect.flag |= 1024U;
        AppMain.gmGmkFlipperSetRideSpeed( parent_obj2, parent_obj, num );
        AppMain.GmPlySeqInitFlipper( ( AppMain.GMS_PLAYER_WORK )parent_obj2, parent_obj2.spd.x, parent_obj2.spd.y, gms_ENEMY_3D_WORK.ene_com );
        int num4 = num2;
        if ( ( gms_PLAYER_WORK.player_flag & 131072U ) != 0U )
        {
            num4 += -61440;
        }
        else
        {
            num4 += -36864;
        }
        parent_obj2.pos.y = parent_obj.pos.y + num4;
    }

    // Token: 0x06001574 RID: 5492 RVA: 0x000BA580 File Offset: 0x000B8780
    private static void gmGmkFlipperDefEnemy( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj2;
        if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id != 316 )
        {
            return;
        }
        if ( parent_obj.pos.y < parent_obj2.pos.y )
        {
            return;
        }
        parent_obj2.spd.y = -parent_obj2.spd.y;
        if ( ( long )AppMain.MTM_MATH_ABS( parent_obj2.spd.x ) < 256L )
        {
            parent_obj2.spd.x = 256;
        }
    }

    // Token: 0x06001575 RID: 5493 RVA: 0x000BA614 File Offset: 0x000B8814
    private static void gmGmkFlipperDefFuncU( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = target_rect.parent_obj;
        if ( parent_obj.obj_type == 1 )
        {
            AppMain.gmGmkFlipperDefPlayer( gimmick_rect, target_rect );
            return;
        }
        if ( parent_obj.obj_type == 2 )
        {
            AppMain.gmGmkFlipperDefEnemy( gimmick_rect, target_rect );
        }
    }

    // Token: 0x06001576 RID: 5494 RVA: 0x000BA64C File Offset: 0x000B884C
    private static void gmGmkFlipperDefFuncLR( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        gms_ENEMY_3D_WORK.ene_com.target_obj = parent_obj2;
        int num = 86016;
        int num2 = 0;
        if ( ( int )gms_ENEMY_3D_WORK.ene_com.eve_rec.width * 1000 == 0 )
        {
            if ( parent_obj2.pos.x < parent_obj.pos.x )
            {
                parent_obj.user_flag = 0U;
                num *= -1;
            }
            else
            {
                parent_obj.user_flag = 1U;
            }
        }
        else
        {
            parent_obj.user_flag = 0U;
            num *= -1;
        }
        int num3 = AppMain.FX_F32_TO_FX32((100f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.left) * 0.01f);
        if ( num3 < 0 )
        {
            num3 = 0;
        }
        int num4 = AppMain.FX_F32_TO_FX32((100f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.top) * 0.01f);
        if ( num4 < 0 )
        {
            num4 = 0;
        }
        num = AppMain.FX_Mul( num, num3 );
        num2 = AppMain.FX_Mul( num2, num4 );
        AppMain.gmGmkFlipperChangeModeHit( parent_obj );
        int no_spddown_timer = 12;
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            no_spddown_timer = 180;
        }
        AppMain.GmPlySeqInitPinball( ( AppMain.GMS_PLAYER_WORK )parent_obj2, num, num2, no_spddown_timer );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(parent_obj, 16);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj2.pos.x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj2.pos.y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = ( ushort )( AppMain.nnArcTan2( ( double )AppMain.FX_FX32_TO_F32( num2 ), ( double )AppMain.FX_FX32_TO_F32( num ) ) - 16384 );
    }

    // Token: 0x06001577 RID: 5495 RVA: 0x000BA81C File Offset: 0x000B8A1C
    private static void gmGmkFlipperChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        obj_work.user_work = ( uint )AppMain.g_gm_gmk_flipper_angle_z[num];
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkFlipperMainWait );
    }

    // Token: 0x06001578 RID: 5496 RVA: 0x000BA868 File Offset: 0x000B8A68
    private static void gmGmkFlipperChangeModeReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        obj_work.user_work = ( uint )AppMain.g_gm_gmk_flipper_angle_z[num];
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkFlipperMainReady );
    }

    // Token: 0x06001579 RID: 5497 RVA: 0x000BA8B4 File Offset: 0x000B8AB4
    private static void gmGmkFlipperChangeModeHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        ushort num2 = AppMain.g_gm_gmk_flipper_angle_z[num];
        if ( obj_work.user_flag != 0U )
        {
            num2 += ( ushort )AppMain.NNM_DEGtoA16( -70f );
        }
        else
        {
            num2 += ( ushort )AppMain.NNM_DEGtoA16( 70f );
        }
        obj_work.user_work = ( uint )num2;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkFlipperMainHit );
        AppMain.GmSoundPlaySE( "Casino2" );
    }

    // Token: 0x0600157A RID: 5498 RVA: 0x000BA934 File Offset: 0x000B8B34
    private static void gmGmkFlipperChangeModeHook( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        ushort num2 = AppMain.g_gm_gmk_flipper_angle_z[num];
        if ( obj_work.user_flag != 0U )
        {
            num2 += ( ushort )AppMain.NNM_DEGtoA16( -70f );
        }
        else
        {
            num2 += ( ushort )AppMain.NNM_DEGtoA16( 70f );
        }
        obj_work.user_work = ( uint )num2;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkFlipperMainHook );
    }

    // Token: 0x0600157B RID: 5499 RVA: 0x000BA9A8 File Offset: 0x000B8BA8
    private static void gmGmkFlipperChangeModeOpen( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        obj_work.user_work = ( uint )AppMain.g_gm_gmk_flipper_angle_z[num];
        obj_work.ppFunc = null;
        obj_work.dir.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = null;
    }

    // Token: 0x0600157C RID: 5500 RVA: 0x000BAA08 File Offset: 0x000B8C08
    private static void gmGmkFlipperMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkFlipperUpdateAngle( obj_work );
        int num = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        if ( num == 2 && AppMain.gmGmkFlipperCheckScore( obj_work ) != 0 )
        {
            AppMain.gmGmkFlipperChangeModeOpen( obj_work );
        }
    }

    // Token: 0x0600157D RID: 5501 RVA: 0x000BAA4C File Offset: 0x000B8C4C
    private static void gmGmkFlipperMainReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.gmGmkFlipperUpdateAngle( obj_work );
        int num = 1;
        if ( num != 0 )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
            if ( AppMain.gmGmkFlipperCheckControlPlayer() == 0 )
            {
                AppMain.gmGmkFlipperChangeModeWait( obj_work );
                return;
            }
            if ( AppMain.gmGmkFlipperCheckKeyHit( obj_work, gms_PLAYER_WORK ) == 0 )
            {
                return;
            }
            if ( AppMain.gmGmkFlipperCheckHook( obj_work ) != 0 )
            {
                target_obj.spd.x = 0;
                target_obj.spd.y = 0;
                AppMain.gmGmkFlipperChangeModeHook( obj_work );
                return;
            }
            int num2 = 12288;
            int num3 = -53248;
            int num4 = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
            if ( num4 == 1 )
            {
                num2 = -num2;
            }
            num2 += target_obj.pos.x - obj_work.pos.x >> 2;
            int num5 = (102400 - AppMain.MTM_MATH_ABS(target_obj.pos.x - obj_work.pos.x)) / 10;
            if ( num5 > 0 )
            {
                num3 += num5;
            }
            int num6 = AppMain.FX_F32_TO_FX32((100f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.left) * 0.01f);
            if ( num6 < 0 )
            {
                num6 = 0;
            }
            int num7 = AppMain.FX_F32_TO_FX32((100f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.top) * 0.01f);
            if ( num7 < 0 )
            {
                num7 = 0;
            }
            num2 = AppMain.FX_Mul( num2, num6 );
            num3 = AppMain.FX_Mul( num3, num7 );
            int flag_no_recover_homing = 0;
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                flag_no_recover_homing = 1;
            }
            int no_spddown_timer = 0;
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 2 ) != 0 )
            {
                no_spddown_timer = 30;
            }
            AppMain.GmPlayerSetAtk( gms_PLAYER_WORK );
            AppMain.GmPlySeqInitPinballAir( gms_PLAYER_WORK, num2, num3, 5, flag_no_recover_homing, no_spddown_timer );
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(obj_work, 16);
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = target_obj.pos.x;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = target_obj.pos.y;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = ( ushort )( AppMain.nnArcTan2( ( double )AppMain.FX_FX32_TO_F32( num3 ), ( double )AppMain.FX_FX32_TO_F32( num2 ) ) - 16384 );
        }
        AppMain.gmGmkFlipperChangeModeHit( obj_work );
    }

    // Token: 0x0600157E RID: 5502 RVA: 0x000BAC9F File Offset: 0x000B8E9F
    private static void gmGmkFlipperMainHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.gmGmkFlipperUpdateAngle( obj_work ) != 0 )
        {
            AppMain.gmGmkFlipperChangeModeWait( obj_work );
        }
    }

    // Token: 0x0600157F RID: 5503 RVA: 0x000BACB0 File Offset: 0x000B8EB0
    private static void gmGmkFlipperMainHook( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.gmGmkFlipperUpdateAngle( obj_work );
        int num = 1;
        if ( num != 0 )
        {
            if ( AppMain.gmGmkFlipperCheckControlPlayer() == 0 )
            {
                AppMain.gmGmkFlipperChangeModeWait( obj_work );
                return;
            }
            int num2 = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
            AppMain.gmGmkFlipperSetRideSpeed( target_obj, obj_work, num2 );
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
            if ( ( gms_PLAYER_WORK.key_on & 160 ) == 0 )
            {
                AppMain.gmGmkFlipperChangeModeReady( obj_work );
                return;
            }
            int num3 = target_obj.pos.x - obj_work.pos.x;
            if ( num2 == 1 )
            {
                num3 = -num3;
            }
            if ( num3 > 0 )
            {
                target_obj.spd.x = 0;
                target_obj.spd.y = 0;
            }
        }
    }

    // Token: 0x06001580 RID: 5504 RVA: 0x000BAD6F File Offset: 0x000B8F6F
    private static int gmGmkFlipperCheckKeyHit( AppMain.OBS_OBJECT_WORK gimmick_obj_work, AppMain.GMS_PLAYER_WORK player_work )
    {
        if ( AppMain.GmPlayerKeyCheckJumpKeyPush( player_work ) )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001581 RID: 5505 RVA: 0x000BAD7C File Offset: 0x000B8F7C
    private static int gmGmkFlipperCheckControlPlayer()
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.seq_state != 47 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001582 RID: 5506 RVA: 0x000BADA4 File Offset: 0x000B8FA4
    private static int gmGmkFlipperCheckScore( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        uint num = (uint)gms_ENEMY_3D_WORK.ene_com.eve_rec.width * 1000U;
        if ( num == 0U )
        {
            return 0;
        }
        uint score = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].score;
        if ( num > score )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001583 RID: 5507 RVA: 0x000BADF0 File Offset: 0x000B8FF0
    private static int gmGmkFlipperCheckLeft( AppMain.VecFx32 line_start, AppMain.VecFx32 line_end, AppMain.VecFx32 point )
    {
        int v = line_end.x - line_start.x;
        int v2 = line_end.y - line_start.y;
        int v3 = point.x - line_start.x;
        int v4 = point.y - line_start.y;
        int num = AppMain.FX_Mul(v, v4) - AppMain.FX_Mul(v2, v3);
        if ( num <= 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001584 RID: 5508 RVA: 0x000BAE58 File Offset: 0x000B9058
    private static int gmGmkFlipperCheckRect( AppMain.VecFx32 gimmick_pos, AppMain.VecFx32 target_pos, int type )
    {
        switch ( type )
        {
            case 0:
                {
                    AppMain.VecFx32 line_start = new AppMain.VecFx32(gimmick_pos);
                    line_start.y += AppMain.FX_F32_TO_FX32( ( float )( AppMain.g_gmk_flipper_rect[type][1] - 12 ) );
                    AppMain.VecFx32 line_end = new AppMain.VecFx32(gimmick_pos);
                    line_end.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_flipper_rect[type][2] );
                    line_end.y += AppMain.FX_F32_TO_FX32( ( float )( AppMain.g_gmk_flipper_rect[type][3] - 12 ) );
                    if ( AppMain.gmGmkFlipperCheckLeft( line_start, line_end, target_pos ) != 0 )
                    {
                        return 0;
                    }
                    break;
                }
            case 1:
                {
                    AppMain.VecFx32 line_end2 = new AppMain.VecFx32(gimmick_pos);
                    line_end2.y += AppMain.FX_F32_TO_FX32( ( float )( AppMain.g_gmk_flipper_rect[type][1] - 12 ) );
                    AppMain.VecFx32 line_start2 = new AppMain.VecFx32(gimmick_pos);
                    line_start2.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_flipper_rect[type][0] );
                    line_start2.y += AppMain.FX_F32_TO_FX32( ( float )( AppMain.g_gmk_flipper_rect[type][3] - 12 ) );
                    if ( AppMain.gmGmkFlipperCheckLeft( line_start2, line_end2, target_pos ) != 0 )
                    {
                        return 0;
                    }
                    break;
                }
        }
        return 1;
    }

    // Token: 0x06001585 RID: 5509 RVA: 0x000BAF70 File Offset: 0x000B9170
    private static int gmGmkFlipperCheckHook( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        int num = target_obj.pos.x - obj_work.pos.x;
        int num2 = 16384;
        int num3 = AppMain.gmGmkFlipperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        if ( num3 == 1 )
        {
            num = -num;
            num2 = -num2;
        }
        if ( num > 16384 )
        {
            return 0;
        }
        if ( num > 0 )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)target_obj;
            target_obj.pos.x = obj_work.pos.x;
            int num4 = AppMain.gmGmkFlipperCalcRideOffsetY(obj_work.pos.x + num2, obj_work, num3);
            if ( ( gms_PLAYER_WORK.player_flag & 131072U ) != 0U )
            {
                num4 += -61440;
            }
            else
            {
                num4 += -36864;
            }
            target_obj.pos.y = obj_work.pos.y + num4;
        }
        return 1;
    }

    // Token: 0x06001586 RID: 5510 RVA: 0x000BB054 File Offset: 0x000B9254
    private static void gmGmkFlipperSetRideSpeed( AppMain.OBS_OBJECT_WORK target_obj_work, AppMain.OBS_OBJECT_WORK gimmick_obj_work, int flipper_type )
    {
        AppMain.UNREFERENCED_PARAMETER( gimmick_obj_work );
        int num = AppMain.FX_F32_TO_FX32(0.6857143f);
        int y = AppMain.FX_F32_TO_FX32(0.37142858f);
        if ( flipper_type == 1 )
        {
            num = -num;
        }
        target_obj_work.spd.x = num;
        target_obj_work.spd.y = y;
        target_obj_work.spd.x = AppMain.FX_Div( target_obj_work.spd.x, 12288 );
        target_obj_work.spd.y = AppMain.FX_Div( target_obj_work.spd.y, 12288 );
    }

    // Token: 0x06001587 RID: 5511 RVA: 0x000BB0DC File Offset: 0x000B92DC
    private static int gmGmkFlipperCalcRideOffsetY( int x, AppMain.OBS_OBJECT_WORK gimmick_obj_work, int flipper_type )
    {
        float num = (float)(AppMain.g_gmk_flipper_rect[flipper_type][2] - AppMain.g_gmk_flipper_rect[flipper_type][0]);
        if ( flipper_type == 1 )
        {
            num = -num;
        }
        float num2 = (float)(AppMain.g_gmk_flipper_rect[flipper_type][3] - AppMain.g_gmk_flipper_rect[flipper_type][1]) + -2f;
        return AppMain.FX_Mul( ( int )( num2 / num * 4096f ), x - gimmick_obj_work.pos.x );
    }

    // Token: 0x06001588 RID: 5512 RVA: 0x000BB140 File Offset: 0x000B9340
    private static int gmGmkFlipperUpdateAngle( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer++;
        ushort num = (ushort)obj_work.user_work;
        ushort num2 = ( ushort )((num - obj_work.dir.z) / 6);
        obj_work.dir.z = ( ushort )( obj_work.dir.z + num2 );
        if ( obj_work.user_timer < 6 )
        {
            return 0;
        }
        obj_work.dir.z = num;
        obj_work.user_timer = 0;
        return 1;
    }
}