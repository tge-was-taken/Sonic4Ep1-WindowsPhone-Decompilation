using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.backup;

public partial class AppMain
{
    // Token: 0x06001AFB RID: 6907 RVA: 0x000F5504 File Offset: 0x000F3704
    private static AppMain.OBS_OBJECT_WORK GmGmkSsEmeraldInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        bool flag = false;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_EMERALD");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        ushort num = (ushort)(AppMain.g_gs_main_sys_info.stage_id - 21);
        SSpecial sspecial = SSpecial.CreateInstance();
        if ( sspecial[( int )num].IsGetEmerald() )
        {
            flag = true;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_1up_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_emerald_obj_3d_list[( int )num], gms_ENEMY_3D_WORK.obj_3d );
            AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 912 ), null, 0, null );
            AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, ( int )num );
        }
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194308U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsEmeraldMain );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSsEmeraldDefFunc );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -4, -4, 4, 4 );
        int efct_zone_idx;
        if ( flag )
        {
            efct_zone_idx = 0;
        }
        else
        {
            efct_zone_idx = ( int )( 1 + num );
        }
        AppMain.gm_gmk_ss_emerald_effct = AppMain.GmEfctZoneEsCreate( obs_OBJECT_WORK, 5, efct_zone_idx );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001AFC RID: 6908 RVA: 0x000F56A4 File Offset: 0x000F38A4
    public static void GmGmkSsEmeraldBuild()
    {
        AppMain.gm_gmk_ss_emerald_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 910 ), AppMain.GmGameDatGetGimmickData( 911 ), 0U );
        AppMain.gm_gmk_ss_1up_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 913 ), AppMain.GmGameDatGetGimmickData( 914 ), 0U );
    }

    // Token: 0x06001AFD RID: 6909 RVA: 0x000F56E4 File Offset: 0x000F38E4
    public static void GmGmkSsEmeraldFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(910);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_emerald_obj_3d_list, ams_AMB_HEADER.file_num );
        ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData( 913 );
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_1up_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001AFE RID: 6910 RVA: 0x000F5727 File Offset: 0x000F3927
    private static void gmGmkSsEmeraldMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.dir.z = AppMain.GmMainGetObjectRotation();
    }

    // Token: 0x06001AFF RID: 6911 RVA: 0x000F573C File Offset: 0x000F393C
    private static void gmGmkSsEmeraldDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
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
        AppMain.GmSoundPlayJingle( 3U, 0 );
        AppMain.GmSoundPlaySE( "Special5" );
        AppMain.GmComEfctCreateRing( gms_ENEMY_COM_WORK.obj_work.pos.x, gms_ENEMY_COM_WORK.obj_work.pos.y );
        AppMain.gmGmkSsEmeraldEfctKill();
        gms_ENEMY_COM_WORK.obj_work.flag |= 4U;
        AppMain.g_gm_main_system.game_flag |= 65536U;
    }

    // Token: 0x06001B00 RID: 6912 RVA: 0x000F57EA File Offset: 0x000F39EA
    private static void gmGmkSsEmeraldEfctKill()
    {
        if ( AppMain.gm_gmk_ss_emerald_effct != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )AppMain.gm_gmk_ss_emerald_effct );
            AppMain.gm_gmk_ss_emerald_effct = null;
        }
    }
}