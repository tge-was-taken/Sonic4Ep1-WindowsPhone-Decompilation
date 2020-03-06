using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x06001404 RID: 5124 RVA: 0x000B1B58 File Offset: 0x000AFD58
    private static AppMain.OBS_OBJECT_WORK GmGmkBobbinInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBobbinLoadObj(eve_rec, pos_x, pos_y);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkBobbinInit( obj_work );
        return obj_work;
    }

    // Token: 0x06001405 RID: 5125 RVA: 0x000B1B81 File Offset: 0x000AFD81
    public static void GmGmkBobbinBuild()
    {
        AppMain.g_gm_gmk_bobbin_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 863 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 864 ) ), 0U );
    }

    // Token: 0x06001406 RID: 5126 RVA: 0x000B1BAC File Offset: 0x000AFDAC
    public static void GmGmkBobbinFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(863));
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_bobbin_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_bobbin_obj_3d_list = null;
    }

    // Token: 0x06001407 RID: 5127 RVA: 0x000B1BE8 File Offset: 0x000AFDE8
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBobbinLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_BOBBIN");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001408 RID: 5128 RVA: 0x000B1C5C File Offset: 0x000AFE5C
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBobbinLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBobbinLoadObjNoModel(eve_rec, pos_x, pos_y);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        int num = 0;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_bobbin_obj_3d_list[num], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.OBS_DATA_WORK data_work = AppMain.ObjDataGet(865);
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, data_work, null, 0, null );
        AppMain.OBS_DATA_WORK data_work2 = AppMain.ObjDataGet(866);
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, 0, data_work2, null, 0, null );
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001409 RID: 5129 RVA: 0x000B1CC4 File Offset: 0x000AFEC4
    private static void gmGmkBobbinInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkBobbinSetRect( gimmick_work );
        obj_work.move_flag = 8448U;
        obj_work.disp_flag |= 4194308U;
        obj_work.pos.z = -131072;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            obj_work.pos.z = -65536;
        }
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBobbinDrawFunc );
        AppMain.gmGmkBobbinChangeModeWait( obj_work );
    }

    // Token: 0x0600140A RID: 5130 RVA: 0x000B1D48 File Offset: 0x000AFF48
    private static void gmGmkBobbinSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gimmick_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        short cLeft = -24;
        short cRight = 24;
        short cTop = -24;
        short cBottom = 24;
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, cLeft, cTop, -500, cRight, cBottom, 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 1, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkBobbinDefFunc );
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.OBS_COLLISION_WORK col_work = ((AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK).ene_com.col_work;
            col_work.obj_col.obj = obs_OBJECT_WORK;
            col_work.obj_col.diff_data = AppMain.g_gm_default_col;
            col_work.obj_col.width = 16;
            col_work.obj_col.height = 16;
            col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
            col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
            col_work.obj_col.attr = 2;
            col_work.obj_col.flag |= 134217760U;
        }
    }

    // Token: 0x0600140B RID: 5131 RVA: 0x000B1E7A File Offset: 0x000B007A
    private static void gmGmkBobbinDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x0600140C RID: 5132 RVA: 0x000B1E84 File Offset: 0x000B0084
    private static AppMain.VecFx32 gmGmkBobbinNormalizeVectorXY( AppMain.VecFx32 vec )
    {
        AppMain.VecFx32 result = default(AppMain.VecFx32);
        int num = AppMain.FX_Mul(vec.x, vec.x) + AppMain.FX_Mul(vec.y, vec.y);
        if ( num == 0 )
        {
            result.x = 4096;
            result.y = 0;
        }
        else
        {
            num = AppMain.FX_Sqrt( num );
            int v = AppMain.FX_Div(4096, num);
            result.x = AppMain.FX_Mul( vec.x, v );
            result.y = AppMain.FX_Mul( vec.y, v );
        }
        result.z = 0;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            int x = 0;
            int y = 0;
            AppMain.ObjUtilGetRotPosXY( result.x, result.y, ref x, ref y, ( ushort )-AppMain.g_gm_main_system.pseudofall_dir );
            result.x = x;
            result.y = y;
        }
        return result;
    }

    // Token: 0x0600140D RID: 5133 RVA: 0x000B1F60 File Offset: 0x000B0160
    private static void gmGmkBobbinDefPlayer( AppMain.GMS_ENEMY_3D_WORK gimmick_work, AppMain.GMS_PLAYER_WORK player_work, int speed_x, int speed_y )
    {
        bool flag_no_recover_homing = false;
        if ( ( gimmick_work.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            flag_no_recover_homing = true;
        }
        AppMain.GmPlySeqInitPinballAir( player_work, speed_x, speed_y, 5, flag_no_recover_homing );
        if ( !AppMain.GMM_MAIN_STAGE_IS_SS() )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gimmick_work;
            AppMain.GmPlayerAddScore( player_work, 10, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y );
        }
    }

    // Token: 0x0600140E RID: 5134 RVA: 0x000B1FBC File Offset: 0x000B01BC
    private static void gmGmkBobbinDefEnemy( AppMain.OBS_OBJECT_WORK obj_work, int speed_x, int speed_y )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id != 316 )
        {
            return;
        }
        obj_work.spd.x = speed_x;
        obj_work.spd.y = speed_y;
        obj_work.spd_add.x = 0;
        obj_work.spd_add.y = 0;
        if ( ( long )AppMain.MTM_MATH_ABS( obj_work.spd.x ) < 256L )
        {
            obj_work.spd.x = 256;
            return;
        }
        if ( ( long )AppMain.MTM_MATH_ABS( obj_work.spd.y ) < 256L )
        {
            obj_work.spd.y = 256;
        }
    }

    // Token: 0x0600140F RID: 5135 RVA: 0x000B206C File Offset: 0x000B026C
    private static void gmGmkBobbinDefFunc( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK player_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = player_rect.parent_obj;
        AppMain.VecFx32 vec = default(AppMain.VecFx32);
        vec.x = parent_obj2.prev_pos.x - parent_obj.pos.x;
        vec.y = ( int )( ( long )parent_obj2.prev_pos.y + -12288L - ( long )parent_obj.pos.y );
        vec.z = 0;
        int num = AppMain.FX_Mul(vec.x, vec.x) + AppMain.FX_Mul(vec.y, vec.y);
        if ( AppMain.FX_Mul( 114688, 114688 ) < num )
        {
            gimmick_rect.flag &= 4294966271U;
            return;
        }
        gimmick_rect.flag |= 1024U;
        vec = AppMain.gmGmkBobbinNormalizeVectorXY( vec );
        parent_obj2.dir.z = 0;
        int num2 = AppMain.FX_Mul(vec.x, 24576);
        int num3 = AppMain.FX_Mul(vec.y, 24576);
        int num4 = AppMain.FX_F32_TO_FX32((100f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.left) * 0.01f);
        if ( num4 < 0 )
        {
            num4 = 0;
        }
        int num5 = AppMain.FX_F32_TO_FX32((100f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.top) * 0.01f);
        if ( num5 < 0 )
        {
            num5 = 0;
        }
        num2 = AppMain.FX_Mul( num2, num4 );
        num3 = AppMain.FX_Mul( num3, num5 );
        if ( parent_obj2.obj_type == 1 )
        {
            AppMain.gmGmkBobbinDefPlayer( gms_ENEMY_3D_WORK, ( AppMain.GMS_PLAYER_WORK )parent_obj2, num2, num3 );
        }
        else if ( parent_obj2.obj_type == 2 )
        {
            AppMain.gmGmkBobbinDefEnemy( parent_obj2, num2, num3 );
        }
        AppMain.gmGmkBobbinChangeModeHit( parent_obj );
        AppMain.GmSoundPlaySE( "Casino1" );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(parent_obj, 16);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj2.pos.x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj2.pos.y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = ( ushort )( AppMain.nnArcTan2( ( double )AppMain.FX_FX32_TO_F32( num3 ), ( double )AppMain.FX_FX32_TO_F32( num2 ) ) - 16384 );
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
            if ( obs_CAMERA != null )
            {
                AppMain.OBS_OBJECT_WORK obj_work = gms_EFFECT_3DES_WORK.efct_com.obj_work;
                obj_work.dir.z = ( ushort )( obj_work.dir.z - ( ushort )obs_CAMERA.roll );
            }
        }
        AppMain.GMM_PAD_VIB_SMALL();
    }

    // Token: 0x06001410 RID: 5136 RVA: 0x000B230A File Offset: 0x000B050A
    private static void gmGmkBobbinChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 0, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBobbinMainWait );
    }

    // Token: 0x06001411 RID: 5137 RVA: 0x000B2326 File Offset: 0x000B0526
    private static void gmGmkBobbinChangeModeHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 1, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBobbinMainHit );
    }

    // Token: 0x06001412 RID: 5138 RVA: 0x000B2349 File Offset: 0x000B0549
    private static void gmGmkBobbinMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x06001413 RID: 5139 RVA: 0x000B234B File Offset: 0x000B054B
    private static void gmGmkBobbinMainHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.gmGmkBobbinChangeModeWait( obj_work );
        }
    }
}