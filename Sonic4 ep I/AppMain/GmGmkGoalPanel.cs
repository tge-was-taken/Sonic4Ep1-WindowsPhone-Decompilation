using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060008D2 RID: 2258 RVA: 0x0005018C File Offset: 0x0004E38C
    private static AppMain.OBS_OBJECT_WORK GmGmkGoalPanelInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_GOAL_PANEL");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 65536U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_goal_panel_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.dir.y = 32768;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGoalPanelMain );
        AppMain.GmGmkSplRingMake( pos_x + 393216, pos_y - 393216 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060008D3 RID: 2259 RVA: 0x00050290 File Offset: 0x0004E490
    public static void GmGmkGoalPanelBuild()
    {
        AppMain.gm_gmk_goal_panel_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 836 ), AppMain.GmGameDatGetGimmickData( 837 ), 0U );
    }

    // Token: 0x060008D4 RID: 2260 RVA: 0x000502B4 File Offset: 0x0004E4B4
    public static void GmGmkGoalPanelFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(836));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_goal_panel_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060008D5 RID: 2261 RVA: 0x000502E4 File Offset: 0x0004E4E4
    private static void gmGmkGoalPanelMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( obj_work.pos.x < gms_PLAYER_WORK.obj_work.pos.x )
        {
            SaveState.deleteSave();
            if ( ( gms_PLAYER_WORK.player_flag & 16384U ) != 0U )
            {
                AppMain.g_gm_main_system.game_flag |= 33554432U;
            }
            else
            {
                AppMain.g_gm_main_system.game_flag &= 4261412863U;
            }
            AppMain.HgTrophyTryAcquisition( 1 );
            AppMain.GmPlayerSetGoalState( gms_PLAYER_WORK );
            AppMain.g_gm_main_system.game_flag &= 4294966271U;
            AppMain.g_gm_main_system.game_flag |= 1048576U;
            obj_work.user_work = 4096U;
            obj_work.user_timer = 120;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGoalPanelPass );
            AppMain.GmGmkCamScrLimitSet( new AppMain.GMS_EVE_RECORD_EVENT
            {
                flag = 5,
                left = -96,
                top = -104,
                width = 192,
                height = 112
            }, obj_work.pos.x, obj_work.pos.y );
            AppMain.gm_gmk_goal_panel_effct = AppMain.GmEfctCmnEsCreate( obj_work, 32 );
            AppMain.GmEffect3DESSetDispOffset( AppMain.gm_gmk_goal_panel_effct, 0f, 30f, 15f );
            AppMain.GmEffect3DESSetDispRotation( AppMain.gm_gmk_goal_panel_effct, 0, 0, 0 );
            AppMain.GMM_PAD_VIB_SMALL();
            AppMain.GmSoundPlaySE( "GoalPanel" );
        }
    }

    // Token: 0x060008D6 RID: 2262 RVA: 0x0005044C File Offset: 0x0004E64C
    private static AppMain.OBS_OBJECT_WORK GmGmkCamScrLimitSet( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y )
    {
        return AppMain.GmEventMgrLocalEventBirth( 302, pos_x, pos_y, eve_rec.flag, eve_rec.left, eve_rec.top, eve_rec.width, eve_rec.height, 0 );
    }

    // Token: 0x060008D7 RID: 2263 RVA: 0x00050488 File Offset: 0x0004E688
    private static void gmGmkGoalPanelPass( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer--;
        if ( obj_work.user_timer <= 0 )
        {
            obj_work.user_timer = 0;
            obj_work.user_work = 0U;
            obj_work.dir.y = 0;
            obj_work.user_timer = 120;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGoalPanelWait );
            AppMain.gmGmkGoalPanelEfctKill();
            AppMain.GmPlySeqChangeActGoal( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
        }
        obj_work.dir.y = ( ushort )( obj_work.dir.y + ( ushort )obj_work.user_work );
    }

    // Token: 0x060008D8 RID: 2264 RVA: 0x00050514 File Offset: 0x0004E714
    private static void gmGmkGoalPanelWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( --obj_work.user_timer <= 0 )
        {
            AppMain.g_gm_main_system.game_flag |= 4U;
            obj_work.ppFunc = null;
            AppMain.gmGmkGoalPanelEfctKill();
        }
    }

    // Token: 0x060008D9 RID: 2265 RVA: 0x00050553 File Offset: 0x0004E753
    private static void gmGmkGoalPanelEfctKill()
    {
        if ( AppMain.gm_gmk_goal_panel_effct != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )AppMain.gm_gmk_goal_panel_effct );
            AppMain.gm_gmk_goal_panel_effct = null;
        }
    }
}