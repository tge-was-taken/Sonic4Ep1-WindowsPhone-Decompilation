using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000DD4 RID: 3540 RVA: 0x0007A1E4 File Offset: 0x000783E4
    private static AppMain.OBS_OBJECT_WORK GmGmkNeedleNeonInitStand( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkNeedleNeonLoadObj(eve_rec, pos_x, pos_y, type, 2U);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkNeedleNeonStandInit( obj_work );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(337, obj_work.pos.x, obj_work.pos.y, eve_rec.flag, eve_rec.left, eve_rec.top, eve_rec.width, eve_rec.height, type);
        obs_OBJECT_WORK.parent_obj = obj_work;
        obs_OBJECT_WORK.user_work = ( uint )( obj_work.pos.y + 131072 );
        return obj_work;
    }

    // Token: 0x06000DD5 RID: 3541 RVA: 0x0007A270 File Offset: 0x00078470
    private static AppMain.OBS_OBJECT_WORK GmGmkNeedleNeonInitNeedle( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkNeedleNeonLoadObj(eve_rec, pos_x, pos_y, type, 0U);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkNeedleNeonNeedleInit( obj_work );
        return obj_work;
    }

    // Token: 0x06000DD6 RID: 3542 RVA: 0x0007A29B File Offset: 0x0007849B
    private static AppMain.OBS_OBJECT_WORK GmGmkNeedleNeonInitGlaer( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( eve_rec );
        AppMain.UNREFERENCED_PARAMETER( pos_x );
        AppMain.UNREFERENCED_PARAMETER( pos_y );
        AppMain.UNREFERENCED_PARAMETER( type );
        return null;
    }

    // Token: 0x06000DD7 RID: 3543 RVA: 0x0007A2C8 File Offset: 0x000784C8
    public static void GmGmkNeedleNeonBuild()
    {
        AppMain.g_gm_gmk_needle_neon_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 822 ), AppMain.GmGameDatGetGimmickData( 823 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(824);
        AppMain.g_gm_gmk_needle_neon_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06000DD8 RID: 3544 RVA: 0x0007A308 File Offset: 0x00078508
    public static void GmGmkNeedleNeonFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(822);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_needle_neon_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_needle_neon_obj_3d_list = null;
        AppMain.g_gm_gmk_needle_neon_obj_tvx_list = null;
    }

    // Token: 0x06000DD9 RID: 3545 RVA: 0x0007A33C File Offset: 0x0007853C
    private static void GmGmkNeedleNeonChangeModeActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_flag &= 4294967294U;
        if ( obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainOn ) || obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainActive ) )
        {
            return;
        }
        AppMain.gmGmkNeedleNeonNeedleChangeModeOn( obj_work );
    }

    // Token: 0x06000DDA RID: 3546 RVA: 0x0007A394 File Offset: 0x00078594
    private static void GmGmkNeedleNeonChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_flag &= 4294967294U;
        if ( obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainWait ) || obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainOff ) )
        {
            return;
        }
        AppMain.gmGmkNeedleNeonNeedleChangeModeOff( obj_work );
    }

    // Token: 0x06000DDB RID: 3547 RVA: 0x0007A3E9 File Offset: 0x000785E9
    private static void GmGmkNeedleNeonChangeModeTimer( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_flag |= 1U;
    }

    // Token: 0x06000DDC RID: 3548 RVA: 0x0007A400 File Offset: 0x00078600
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkNeedleNeonLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_NEEDLE_NEON");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000DDD RID: 3549 RVA: 0x0007A480 File Offset: 0x00078680
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkNeedleNeonLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, uint model_index )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkNeedleNeonLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_needle_neon_obj_3d_list[( int )( ( UIntPtr )model_index )], gms_ENEMY_3D_WORK.obj_3d );
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000DDE RID: 3550 RVA: 0x0007A4BC File Offset: 0x000786BC
    private static void gmGmkNeedleNeonDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainWait ) )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.TVX_FILE tvx = new AppMain.TVX_FILE((AppMain.AmbChunk)AppMain.amBindGet(AppMain.g_gm_gmk_needle_neon_obj_tvx_list, 0));
        AppMain.gmGmkNeedleNeonTvxDrawFunc( tvx, obj_work.obj_3d.texlist, obj_work.pos );
    }

    // Token: 0x06000DDF RID: 3551 RVA: 0x0007A524 File Offset: 0x00078724
    private static void gmGmkNeedleNeonStandDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.TVX_FILE tvx_FILE;
        if ( AppMain.g_gm_gmk_needle_neon_obj_tvx_list.buf[1] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.g_gm_gmk_needle_neon_obj_tvx_list, 1 ) );
            AppMain.g_gm_gmk_needle_neon_obj_tvx_list.buf[1] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.g_gm_gmk_needle_neon_obj_tvx_list.buf[1];
        }
        AppMain.gmGmkNeedleNeonTvxDrawFunc( tvx_FILE, obj_work.obj_3d.texlist, obj_work.pos );
    }

    // Token: 0x06000DE0 RID: 3552 RVA: 0x0007A5A4 File Offset: 0x000787A4
    private static void gmGmkNeedleNeonTvxDrawFunc( AppMain.TVX_FILE tvx, AppMain.NNS_TEXLIST texlist, AppMain.VecFx32 base_pos )
    {
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(4096, 4096, 4096);
        int num = 0;
        while ( 5 > num )
        {
            AppMain.VecFx32 vecFx2;
            vecFx2.x = base_pos.x + AppMain.g_gm_gmk_disp_offset[num].x;
            vecFx2.y = base_pos.y + AppMain.g_gm_gmk_disp_offset[num].y;
            vecFx2.z = base_pos.z + AppMain.g_gm_gmk_disp_offset[num].z;
            AppMain.GmTvxSetModel( tvx, texlist, ref vecFx2, ref vecFx, 0U, 0 );
            num++;
        }
    }

    // Token: 0x06000DE1 RID: 3553 RVA: 0x0007A644 File Offset: 0x00078844
    private static void gmGmkNeedleNeonStandInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 8449U;
        obj_work.disp_flag |= 4194304U;
        obj_work.pos.z = -655360;
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonStandDrawFunc );
    }

    // Token: 0x06000DE2 RID: 3554 RVA: 0x0007A6A8 File Offset: 0x000788A8
    private static void gmGmkNeedleNeonNeedleInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 24;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 30;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = -12;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -32;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, -16, -33, -500, 16, -8, 500 );
        obs_RECT_WORK.flag |= 1024U;
        obj_work.flag |= 2U;
        obj_work.move_flag |= 8449U;
        obj_work.disp_flag |= 4194304U;
        obj_work.flag |= 16U;
        obj_work.pos.z = -655360;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonDrawFunc );
        AppMain.gmGmkNeedleNeonNeedleChangeModeWait( obj_work );
    }

    // Token: 0x06000DE3 RID: 3555 RVA: 0x0007A7E1 File Offset: 0x000789E1
    private static void gmGmkNeedleNeonNeedleChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainWait );
    }

    // Token: 0x06000DE4 RID: 3556 RVA: 0x0007A7F5 File Offset: 0x000789F5
    private static void gmGmkNeedleNeonNeedleChangeModeOn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainOn );
        AppMain.GmSoundPlaySE( "Boss2_06" );
    }

    // Token: 0x06000DE5 RID: 3557 RVA: 0x0007A813 File Offset: 0x00078A13
    private static void gmGmkNeedleNeonNeedleChangeModeActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainActive );
    }

    // Token: 0x06000DE6 RID: 3558 RVA: 0x0007A827 File Offset: 0x00078A27
    private static void gmGmkNeedleNeonNeedleChangeModeOff( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.flag |= 2U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleNeonNeedleMainOff );
    }

    // Token: 0x06000DE7 RID: 3559 RVA: 0x0007A84C File Offset: 0x00078A4C
    private static void gmGmkNeedleNeonNeedleMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int user_work = (int)obj_work.user_work;
        obj_work.pos.y = user_work;
        if ( ( obj_work.user_flag & 1U ) == 0U )
        {
            return;
        }
        obj_work.user_timer++;
        if ( obj_work.user_timer < 480 )
        {
            return;
        }
        obj_work.user_timer = 0;
        AppMain.gmGmkNeedleNeonNeedleChangeModeOn( obj_work );
    }

    // Token: 0x06000DE8 RID: 3560 RVA: 0x0007A8A0 File Offset: 0x00078AA0
    private static void gmGmkNeedleNeonNeedleMainOn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkNeedleNeonNeedleUpdateHitRect( obj_work );
        int user_work = (int)obj_work.user_work;
        int num = AppMain.FX_F32_TO_FX32((float)(32 * obj_work.user_timer / 10));
        obj_work.pos.y = user_work - num;
        obj_work.user_timer++;
        if ( obj_work.user_timer < 10 )
        {
            return;
        }
        obj_work.user_timer = 0;
        AppMain.gmGmkNeedleNeonNeedleChangeModeActive( obj_work );
    }

    // Token: 0x06000DE9 RID: 3561 RVA: 0x0007A904 File Offset: 0x00078B04
    private static void gmGmkNeedleNeonNeedleMainActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkNeedleNeonNeedleUpdateHitRect( obj_work );
        int user_work = (int)obj_work.user_work;
        obj_work.pos.y = user_work - 131072;
        if ( ( obj_work.user_flag & 1U ) == 0U )
        {
            return;
        }
        obj_work.user_timer++;
        if ( obj_work.user_timer < 180 )
        {
            return;
        }
        obj_work.user_timer = 0;
        AppMain.gmGmkNeedleNeonNeedleChangeModeOff( obj_work );
    }

    // Token: 0x06000DEA RID: 3562 RVA: 0x0007A964 File Offset: 0x00078B64
    private static void gmGmkNeedleNeonNeedleMainOff( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int user_work = (int)obj_work.user_work;
        int num = AppMain.FX_F32_TO_FX32((float)(32 - 32 * obj_work.user_timer / 10));
        obj_work.pos.y = user_work - num;
        obj_work.user_timer++;
        if ( obj_work.user_timer < 10 )
        {
            return;
        }
        obj_work.user_timer = 0;
        AppMain.gmGmkNeedleNeonNeedleChangeModeWait( obj_work );
    }

    // Token: 0x06000DEB RID: 3563 RVA: 0x0007A9C4 File Offset: 0x00078BC4
    private static void gmGmkNeedleNeonNeedleUpdateHitRect( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK rider_obj = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.rider_obj;
        if ( rider_obj != null )
        {
            obj_work.flag &= 4294967293U;
            return;
        }
        obj_work.flag |= 2U;
    }
}
