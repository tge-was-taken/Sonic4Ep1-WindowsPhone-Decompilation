using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x06001554 RID: 5460 RVA: 0x000B9490 File Offset: 0x000B7690
    private static AppMain.OBS_OBJECT_WORK GmGmkSsGoalInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_GOAL");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_goal_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsGoalMain );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsGoalDrawFunc );
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        col_work.obj_col.width = 24;
        col_work.obj_col.height = 24;
        col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
        col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
        col_work.obj_col.attr = 2;
        col_work.obj_col.flag |= 134217760U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001555 RID: 5461 RVA: 0x000B961C File Offset: 0x000B781C
    public static void GmGmkSsGoalBuild()
    {
        AppMain.gm_gmk_ss_goal_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 907 ), AppMain.GmGameDatGetGimmickData( 908 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(909);
        AppMain.gm_gmk_ss_goal_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06001556 RID: 5462 RVA: 0x000B965C File Offset: 0x000B785C
    public static void GmGmkSsGoalFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(907);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_goal_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_ss_goal_obj_tvx_list = null;
    }

    // Token: 0x06001557 RID: 5463 RVA: 0x000B968C File Offset: 0x000B788C
    private static void gmGmkSsGoalMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_COLLISION_OBJ obj_col = obj_work.col_work.obj_col;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        obj_work.dir.z = AppMain.GmMainGetObjectRotation();
        if ( obj_col.toucher_obj == gms_PLAYER_WORK.obj_work && obj_col.toucher_obj.touch_obj == obj_work && ( AppMain.g_gm_main_system.game_flag & 131072U ) == 0U )
        {
            AppMain.g_gm_main_system.game_flag |= 131072U;
            AppMain.GmSoundPlaySE( "Special4" );
        }
    }

    // Token: 0x06001558 RID: 5464 RVA: 0x000B9730 File Offset: 0x000B7930
    private static void gmGmkSsGoalDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
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
        if ( AppMain.gm_gmk_ss_goal_obj_tvx_list.buf[0] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_ss_goal_obj_tvx_list, 0 ) );
            AppMain.gm_gmk_ss_goal_obj_tvx_list.buf[0] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.gm_gmk_ss_goal_obj_tvx_list.buf[0];
        }
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        AppMain.GmTvxSetModel( tvx_FILE, texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_LIGHT_DISABLE | AppMain.GMD_TVX_DISP_ROTATE, ( short )( -( short )obj_work.dir.z ) );
    }
}