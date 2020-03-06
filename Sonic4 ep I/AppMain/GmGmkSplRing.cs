using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000B24 RID: 2852 RVA: 0x000648F4 File Offset: 0x00062AF4
    private static AppMain.OBS_OBJECT_WORK GmGmkSplRingInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SPL_RING");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 65536U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_splring_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 882 ).pData );
        AppMain.ObjDrawAction3dActionSet3DNNMaterial( gms_ENEMY_3D_WORK.obj_3d, 0 );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194336U;
        obs_OBJECT_WORK.flag |= 18U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSplRingDefFunc );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -4, -4, 4, 4 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSplRingWait );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B25 RID: 2853 RVA: 0x00064A30 File Offset: 0x00062C30
    public static void GmGmkSplRingBuild()
    {
        AppMain.gm_gmk_splring_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 880 ), AppMain.GmGameDatGetGimmickData( 881 ), 0U );
    }

    // Token: 0x06000B26 RID: 2854 RVA: 0x00064A54 File Offset: 0x00062C54
    public static void GmGmkSplRingFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(880));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_splring_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000B27 RID: 2855 RVA: 0x00064A84 File Offset: 0x00062C84
    private static AppMain.OBS_OBJECT_WORK GmGmkSplRingMake( int pos_x, int pos_y )
    {
        return AppMain.GmEventMgrLocalEventBirth( 304, pos_x, pos_y, 0, 0, 0, 0, 0, 0 );
    }

    // Token: 0x06000B28 RID: 2856 RVA: 0x00064AA8 File Offset: 0x00062CA8
    private static void gmGmkSplRingWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK == null )
        {
            return;
        }
        if ( AppMain.g_gs_main_sys_info.game_mode != 0 )
        {
            return;
        }
        if ( AppMain.GsTrialIsTrial() )
        {
            return;
        }
        if ( gms_PLAYER_WORK.obj_work.pos.x < obj_work.pos.x - AppMain.FXM_FLOAT_TO_FX32( AppMain.AMD_SCREEN_2D_WIDTH ) )
        {
            return;
        }
        if ( AppMain.GsMainSysIsSpecialStageClearedAct( ( int )AppMain.g_gs_main_sys_info.stage_id ) )
        {
            return;
        }
        if ( AppMain.GsMainSysIsStageClear( 27 ) )
        {
            return;
        }
        if ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].ring_num < 50 )
        {
            obj_work.disp_flag |= 32U;
            obj_work.flag |= 2U;
        }
        else
        {
            obj_work.disp_flag &= 4294967263U;
            obj_work.flag &= 4294967293U;
        }
        uint num = 4U;
        AppMain.ObjDrawAction3DNNMaterialUpdate( obj_work.obj_3d, ref num );
    }

    // Token: 0x06000B29 RID: 2857 RVA: 0x00064B84 File Offset: 0x00062D84
    private static void gmGmkSplRingVanishReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d.mat_frame = 1f;
        uint num = 16U;
        AppMain.ObjDrawAction3DNNMaterialUpdate( obj_work.obj_3d, ref num );
        if ( ( obj_work.dir.y & 32767 ) == 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSplRingVanish );
            AppMain.GMS_EFFECT_3DES_WORK efct_3des = AppMain.GmEfctCmnEsCreate(obj_work, 78);
            AppMain.GmEffect3DESSetDispOffset( efct_3des, 0f, 0f, 50f );
            AppMain.GmEfctCmnEsCreate( obj_work, 79 );
        }
    }

    // Token: 0x06000B2A RID: 2858 RVA: 0x00064C00 File Offset: 0x00062E00
    private static void gmGmkSplRingVanish( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        obj_work.dir.y = ( ushort )( obj_work.dir.y - 4096 );
        if ( ( obj_work.dir.y & 32767 ) == 0 )
        {
            obj_work.ppFunc = null;
            obj_work.disp_flag |= 32U;
            gms_PLAYER_WORK.obj_work.disp_flag |= 32U;
            gms_PLAYER_WORK.obj_work.move_flag |= 8192U;
        }
    }

    // Token: 0x06000B2B RID: 2859 RVA: 0x00064C88 File Offset: 0x00062E88
    private static void gmGmkSplRingDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
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
        if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
        {
            AppMain.GmPlayerSetEndTruckRide( gms_PLAYER_WORK );
        }
        AppMain.GmPlySeqInitSplIn( gms_PLAYER_WORK, gms_ENEMY_COM_WORK.obj_work.pos );
        gms_PLAYER_WORK.gmk_flag2 |= 6U;
        ( ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_COM_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSplRingVanishReady );
        gms_ENEMY_COM_WORK.obj_work.dir.y = ( ushort )( ( gms_ENEMY_COM_WORK.obj_work.dir.y & 57344 ) );
        gms_ENEMY_COM_WORK.obj_work.flag |= 2U;
        AppMain.GMM_PAD_VIB_SMALL();
        AppMain.GmSoundPlaySE( "Special1" );
    }
}