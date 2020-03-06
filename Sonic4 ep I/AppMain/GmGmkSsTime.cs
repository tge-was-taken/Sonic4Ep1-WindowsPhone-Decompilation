using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0600179F RID: 6047 RVA: 0x000D10FC File Offset: 0x000CF2FC
    private static AppMain.OBS_OBJECT_WORK GmGmkSsTimeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_TIME");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        uint num = (uint)(eve_rec.flag & 3);
        num = AppMain.MTM_MATH_CLIP( num, 0U, 2U );
        obs_OBJECT_WORK.user_work = num;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_time_obj_3d_list[( int )( ( UIntPtr )num )], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = ( obs_OBJECT_WORK.scale.z = 6144 ) );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsTimeMain );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSsTimeDefFunc );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -6, -6, 6, 6 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060017A0 RID: 6048 RVA: 0x000D128E File Offset: 0x000CF48E
    public static void GmGmkSsTimeBuild()
    {
        AppMain.gm_gmk_ss_time_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 915 ), AppMain.GmGameDatGetGimmickData( 916 ), 0U );
    }

    // Token: 0x060017A1 RID: 6049 RVA: 0x000D12B0 File Offset: 0x000CF4B0
    public static void GmGmkSsTimeFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(915);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_time_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060017A2 RID: 6050 RVA: 0x000D12D8 File Offset: 0x000CF4D8
    private static void gmGmkSsTimeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        obj_work.dir.z = AppMain.GmMainGetObjectRotation();
    }

    // Token: 0x060017A3 RID: 6051 RVA: 0x000D1308 File Offset: 0x000CF508
    private static void gmGmkSsTimeDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.gmk_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_COM_WORK )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(gms_ENEMY_COM_WORK.obj_work, 5, 17);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 512U;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsTimeEfctMain );
        gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( gms_ENEMY_COM_WORK.obj_work, 5, AppMain.gm_gmk_ss_time_add_msg[AppMain.GsEnvGetLanguage()] );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 512U;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsTimeEfctMain );
        gms_EFFECT_3DES_WORK.obj_3des.command_state = 10U;
        gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
        AppMain.GmSoundPlaySE( "Special6" );
        AppMain.GmFixRequestTimerFlash();
        AppMain.g_gm_main_system.game_time += AppMain.gm_gmk_ss_time_add_subtract[( int )( ( UIntPtr )gms_ENEMY_COM_WORK.obj_work.user_work )];
        gms_ENEMY_COM_WORK.obj_work.flag |= 4U;
    }

    // Token: 0x060017A4 RID: 6052 RVA: 0x000D1450 File Offset: 0x000CF650
    private static void gmGmkSsTimeEfctMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        if ( obs_CAMERA != null )
        {
            obj_work.dir.z = ( ushort )( -( ushort )obs_CAMERA.roll );
        }
    }
}