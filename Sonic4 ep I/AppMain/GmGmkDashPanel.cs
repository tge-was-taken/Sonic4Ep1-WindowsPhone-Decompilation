using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060005A9 RID: 1449 RVA: 0x00032C60 File Offset: 0x00030E60
    private static AppMain.OBS_OBJECT_WORK GmGmkDashPanelInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_DASH_PANEL");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_dash_panel_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 827 ), null, 0, null );
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 828 ).pData );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppHit = null;
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkDashPanelDefFunc );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 && ( eve_rec.id == 109 || eve_rec.id == 110 ) )
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -8, 16, 8 );
        }
        else
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -8, -8, 8, 8 );
        }
        obs_RECT_WORK.flag |= 1024U;
        if ( eve_rec.id == 108 )
        {
            obs_OBJECT_WORK.dir.y = 32768;
        }
        else if ( eve_rec.id == 109 )
        {
            obs_OBJECT_WORK.dir.z = 49152;
        }
        else if ( eve_rec.id == 110 )
        {
            obs_OBJECT_WORK.dir.z = 16384;
            obs_OBJECT_WORK.dir.y = 32768;
        }
        else
        {
            obs_OBJECT_WORK.dir.z = 0;
            obs_OBJECT_WORK.dir.y = 0;
        }
        obs_OBJECT_WORK.ppFunc = null;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060005AA RID: 1450 RVA: 0x00032E6E File Offset: 0x0003106E
    public static void GmGmkDashPanelBuild()
    {
        AppMain.gm_gmk_dash_panel_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 825 ), AppMain.GmGameDatGetGimmickData( 826 ), 0U );
    }

    // Token: 0x060005AB RID: 1451 RVA: 0x00032E90 File Offset: 0x00031090
    public static void GmGmkDashPanelFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(825));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_dash_panel_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060005AC RID: 1452 RVA: 0x00032EC0 File Offset: 0x000310C0
    private static void gmGmkDashPanelDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
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
        ushort id = gms_ENEMY_COM_WORK.eve_rec.id;
        if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) == 0U )
        {
            gms_ENEMY_COM_WORK.rect_work[2].flag &= 4294573823U;
            return;
        }
        AppMain.GmPlySeqInitDashPanel( gms_PLAYER_WORK, ( uint )( gms_ENEMY_COM_WORK.eve_rec.id - 107 ) );
        AppMain.GmSoundPlaySE( "DashPanel" );
    }
}