using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x060013CB RID: 5067 RVA: 0x000AF7F0 File Offset: 0x000AD9F0
    private static AppMain.OBS_OBJECT_WORK GmGmkBoss3PillarInitManager( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)AppMain.gmGmkBoss3PillarLoadObjNoModel(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BOSS3_PILLAR_MANAGER_WORK;
        AppMain.gmGmkBoss3PillarManagerInit( obs_OBJECT_WORK );
        int num = 0;
        while ( 2 > num )
        {
            int num2 = 0;
            int num3 = 0;
            int num4 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
            if ( num4 == 2 )
            {
                num2 = AppMain.g_gm_gmk_boss3_pillar_wall_default_pos[num][0];
                num3 = AppMain.g_gm_gmk_boss3_pillar_wall_default_pos[num][1];
            }
            else if ( num4 == 4 )
            {
                num2 = AppMain.g_gm_gmk_boss3_pillar_f_wall_default_pos[num][0];
                num3 = AppMain.g_gm_gmk_boss3_pillar_f_wall_default_pos[num][1];
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(343, obs_OBJECT_WORK.pos.x + num2 * 4096, obs_OBJECT_WORK.pos.y + num3 * 4096, eve_rec.flag, eve_rec.left, eve_rec.top, eve_rec.width, eve_rec.height, (byte)num);
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_wall[num] = obs_OBJECT_WORK2;
            if ( ( gms_GMK_BOSS3_PILLAR_MANAGER_WORK.gimmick_work.ene_com.eve_rec.byte_param[1] & 1 ) != 0 && num == 0 )
            {
                int num5 = 917504;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK2;
                obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y - num5;
            }
            num++;
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x060013CC RID: 5068 RVA: 0x000AF93C File Offset: 0x000ADB3C
    private static AppMain.OBS_OBJECT_WORK GmGmkBoss3PillarInitParts( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        uint num = AppMain.gmGmkBoss3PillarCalcPillarType((int)eve_rec.id);
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        int i;
        int[] array;
        if ( num2 == 2 )
        {
            i = AppMain.g_gm_gmk_boss3_pillar_parts_num[( int )( ( UIntPtr )num )];
            array = AppMain.g_gm_boss3_pillar_model_id[( int )( ( UIntPtr )num )];
        }
        else
        {
            if ( num2 != 4 )
            {
                return null;
            }
            i = AppMain.g_gm_gmk_boss3_pillar_f_parts_num[( int )( ( UIntPtr )num )];
            array = AppMain.g_gm_boss3_pillar_f_model_id[( int )( ( UIntPtr )num )];
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBoss3PillarLoadObj(eve_rec, pos_x, pos_y, AppMain.g_gm_gmk_boss3_pillar_obj_3d_list, (uint)array[0], () => new AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_ENEMY_3D_WORK;
        AppMain.gmGmkBoss3PillarPartsInitMain( obs_OBJECT_WORK, num );
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)gms_ENEMY_3D_WORK;
        int num3 = 1;
        while ( i > num3 )
        {
            int num4 = array[num3];
            AppMain.ObjCopyAction3dNNModel( AppMain.g_gm_gmk_boss3_pillar_obj_3d_list[num4], gms_GMK_BOSS3_PILLAR_MAIN_WORK.obj_3d_parts[num3 - 1] );
            gms_GMK_BOSS3_PILLAR_MAIN_WORK.obj_3d_parts[num3 - 1].drawflag |= 32U;
            num3++;
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x060013CD RID: 5069 RVA: 0x000AFA44 File Offset: 0x000ADC44
    private static AppMain.OBS_OBJECT_WORK GmGmkBoss3PillarInitWall( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_ENEMY_3D_WORK work = AppMain.gmGmkBoss3PillarLoadObj(eve_rec, pos_x, pos_y, AppMain.g_gm_gmk_boss3_wall_obj_3d_list, 0U, () => new AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obs_OBJECT_WORK;
        int num = (AppMain.g_gm_gmk_boss3_wall_obj_3d_list.Length > 1) ? 1 : 0;
        AppMain.ObjCopyAction3dNNModel( AppMain.g_gm_gmk_boss3_wall_obj_3d_list[num], gms_GMK_BOSS3_PILLAR_WALL_WORK.obj_3d_parts[0] );
        AppMain.gmGmkBoss3PillarWallInit( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060013CE RID: 5070 RVA: 0x000AFAC0 File Offset: 0x000ADCC0
    public static void GmGmkBoss3PillarBuild()
    {
        AppMain.g_gm_gmk_boss3_pillar_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 941 ), AppMain.GmGameDatGetGimmickData( 942 ), 0U );
        AppMain.g_gm_gmk_boss3_wall_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 945 ), AppMain.GmGameDatGetGimmickData( 946 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(944);
        AppMain.g_gm_gmk_boss3_pillar_obj_tvx_list = ams_AMB_HEADER;
        ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData( 948 );
        AppMain.g_gm_gmk_boss3_wall_obj_tvx_list = ams_AMB_HEADER;
        AppMain.gm_gmk_boss3_pillar_se_use_count = 0;
        AppMain.gm_gmk_boss3_pillar_global_flag = 0;
    }

    // Token: 0x060013CF RID: 5071 RVA: 0x000AFB3C File Offset: 0x000ADD3C
    public static void GmGmkBoss3PillarFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(941);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_boss3_pillar_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_boss3_pillar_obj_3d_list = null;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER2 = AppMain.GmGameDatGetGimmickData(945);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_boss3_wall_obj_3d_list, ams_AMB_HEADER2.file_num );
        AppMain.g_gm_gmk_boss3_wall_obj_3d_list = null;
        AppMain.g_gm_gmk_boss3_pillar_obj_tvx_list = null;
        AppMain.g_gm_gmk_boss3_wall_obj_tvx_list = null;
        AppMain.gm_gmk_boss3_pillar_se_use_count = 0;
        AppMain.gm_gmk_boss3_pillar_global_flag = 0;
    }

    // Token: 0x060013D0 RID: 5072 RVA: 0x000AFBA4 File Offset: 0x000ADDA4
    private static void GmGmkBoss3PillarChangeModeActive( AppMain.OBS_OBJECT_WORK obj_work, int pattern_no )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        float num = 80f;
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num2 == 4 )
        {
            num /= 1.5f;
        }
        int num3 = 0;
        while ( 26 > num3 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num3];
            int num4 = AppMain.g_gm_gmk_boss3_pillar_move_distance[pattern_no][num3] * 40;
            if ( num4 == 0 )
            {
                if ( obs_OBJECT_WORK != null )
                {
                    obs_OBJECT_WORK.flag |= 8U;
                    AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obs_OBJECT_WORK;
                    if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work != null )
                    {
                        AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work );
                        gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work = null;
                    }
                    gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num3] = null;
                }
            }
            else
            {
                if ( obs_OBJECT_WORK == null )
                {
                    ushort id = (ushort)AppMain.g_gm_gmk_boss3_pillar_event_id[num3];
                    obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth( id, obj_work.pos.x + AppMain.g_gm_gmk_boss3_pillar_default_pos[num3][0] * 40 * 4096, obj_work.pos.y + AppMain.g_gm_gmk_boss3_pillar_default_pos[num3][1] * 40 * 4096, gms_ENEMY_3D_WORK.ene_com.eve_rec.flag, gms_ENEMY_3D_WORK.ene_com.eve_rec.left, gms_ENEMY_3D_WORK.ene_com.eve_rec.top, gms_ENEMY_3D_WORK.ene_com.eve_rec.width, gms_ENEMY_3D_WORK.ene_com.eve_rec.height, 0 );
                    obs_OBJECT_WORK.parent_obj = obj_work;
                    gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num3] = obs_OBJECT_WORK;
                }
                else
                {
                    AppMain.gmGmkBoss3PillarPartsChangeModeWait( obs_OBJECT_WORK );
                }
                if ( AppMain.g_gm_gmk_boss3_pillar_flag_hit_effect[pattern_no][num3] != 0 )
                {
                    obs_OBJECT_WORK.user_flag |= 9U;
                    AppMain.gm_gmk_boss3_pillar_global_flag |= 8;
                }
                int wait_time = AppMain.g_gm_gmk_boss3_pillar_wait_frame[pattern_no][num3] * (int)num;
                AppMain.gmGmkBoss3PillarPartsChangeModeNormal( obs_OBJECT_WORK, ( num4 + 16 ) * 4096, wait_time );
            }
            num3++;
        }
        gms_GMK_BOSS3_PILLAR_MANAGER_WORK.pattern_no = pattern_no;
        obj_work.user_timer = ( int )( ( float )AppMain.g_gm_gmk_boss3_pillar_frame_change_hurry[gms_GMK_BOSS3_PILLAR_MANAGER_WORK.pattern_no] * num );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncWaitHurry );
    }

    // Token: 0x060013D1 RID: 5073 RVA: 0x000AFDA8 File Offset: 0x000ADFA8
    private static void GmGmkBoss3PillarChangeModeHurry( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        int num = 0;
        while ( 26 > num )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num];
            if ( obs_OBJECT_WORK != null )
            {
                AppMain.gmGmkBoss3PillarPartsChangeModeHurry( obs_OBJECT_WORK, 50 );
            }
            num++;
        }
    }

    // Token: 0x060013D2 RID: 5074 RVA: 0x000AFDE0 File Offset: 0x000ADFE0
    private static void GmGmkBoss3PillarChangeModeReturn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        int num = 0;
        while ( 26 > num )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num];
            if ( obs_OBJECT_WORK != null )
            {
                AppMain.gmGmkBoss3PillarPartsChangeModeReturn( obs_OBJECT_WORK, 0, 30 );
            }
            num++;
        }
        obj_work.user_timer = 30;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncWaitReturn );
    }

    // Token: 0x060013D3 RID: 5075 RVA: 0x000AFE30 File Offset: 0x000AE030
    private static void GmGmkBoss3PillarChangeModeDelete( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        int num = 0;
        while ( 26 > num )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num];
            if ( obs_OBJECT_WORK != null )
            {
                obs_OBJECT_WORK.flag |= 8U;
                gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_pillar[num] = null;
            }
            num++;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncFw );
    }

    // Token: 0x060013D4 RID: 5076 RVA: 0x000AFE88 File Offset: 0x000AE088
    private static int GmGmkBoss3PillarGetActiveTime( int pattern_no )
    {
        float num = 80f;
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num2 == 4 )
        {
            num /= 1.5f;
        }
        return ( int )( ( float )AppMain.g_gm_gmk_boss3_pillar_frame_change_hurry[pattern_no] * num + 50f );
    }

    // Token: 0x060013D5 RID: 5077 RVA: 0x000AFECC File Offset: 0x000AE0CC
    private static void GmGmkBoss3PillarWallChangeModeActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        int num = 0;
        while ( 2 > num )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_wall[num];
            obs_OBJECT_WORK.user_flag |= 1U;
            obs_OBJECT_WORK.user_flag |= 4U;
            AppMain.gmGmkBoss3PillarWallChangeModeActive( obs_OBJECT_WORK );
            num++;
        }
        gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_wall[0].user_flag |= 10U;
        AppMain.gm_gmk_boss3_pillar_global_flag |= 12;
    }

    // Token: 0x060013D6 RID: 5078 RVA: 0x000AFF3C File Offset: 0x000AE13C
    private static void GmGmkBoss3PillarWallChangeModeReturn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        byte[] byte_param = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.gimmick_work.ene_com.eve_rec.byte_param;
        int num = 1;
        byte_param[num] |= 1;
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_wall[1];
        AppMain.gmGmkBoss3PillarWallChangeModeReturn( obj_work2 );
    }

    // Token: 0x060013D7 RID: 5079 RVA: 0x000AFF88 File Offset: 0x000AE188
    private static void GmGmkBoss3PillarWallClearFlagNoPressDie( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK gms_GMK_BOSS3_PILLAR_MANAGER_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK)obj_work;
        int num = 0;
        while ( 2 > num )
        {
            AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)gms_GMK_BOSS3_PILLAR_MANAGER_WORK.obj_work_wall[num];
            gms_GMK_BOSS3_PILLAR_WALL_WORK.gimmick_work.ene_com.enemy_flag &= 4294950911U;
            num++;
        }
    }

    // Token: 0x060013D8 RID: 5080 RVA: 0x000AFFD4 File Offset: 0x000AE1D4
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBoss3PillarLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, work_size, "GMK_BOSS3_PILLAR");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x060013D9 RID: 5081 RVA: 0x000B002C File Offset: 0x000AE22C
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBoss3PillarLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.OBS_ACTION3D_NN_WORK[] data_work_list, uint model_id, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBoss3PillarLoadObjNoModel(eve_rec, pos_x, pos_y, work_size);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, data_work_list[( int )( ( UIntPtr )model_id )], gms_ENEMY_3D_WORK.obj_3d );
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x060013DA RID: 5082 RVA: 0x000B0062 File Offset: 0x000AE262
    private static void gmGmkBoss3PillarManagerInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 256U;
        obj_work.ppMove = null;
        obj_work.ppOut = null;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncFw );
    }

    // Token: 0x060013DB RID: 5083 RVA: 0x000B0096 File Offset: 0x000AE296
    private static void gmGmkBoss3PillarManagerMainFuncWaitHurry( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gm_gmk_boss3_pillar_global_flag = -1;
        if ( obj_work.user_timer > 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.GmGmkBoss3PillarChangeModeHurry( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncWaitHurryEnd );
        obj_work.user_timer = 50;
    }

    // Token: 0x060013DC RID: 5084 RVA: 0x000B00D6 File Offset: 0x000AE2D6
    private static void gmGmkBoss3PillarManagerMainFuncWaitHurryEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gm_gmk_boss3_pillar_global_flag = -1;
        if ( obj_work.user_timer > 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.GmCameraVibrationSet( 0, 12288, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncFw );
    }

    // Token: 0x060013DD RID: 5085 RVA: 0x000B0114 File Offset: 0x000AE314
    private static void gmGmkBoss3PillarManagerMainFuncWaitReturn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gm_gmk_boss3_pillar_global_flag = -1;
        if ( obj_work.user_timer > 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.GmGmkBoss3PillarChangeModeDelete( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarManagerMainFuncFw );
    }

    // Token: 0x060013DE RID: 5086 RVA: 0x000B014C File Offset: 0x000AE34C
    private static void gmGmkBoss3PillarManagerMainFuncFw( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gm_gmk_boss3_pillar_global_flag = -1;
    }

    // Token: 0x060013DF RID: 5087 RVA: 0x000B0154 File Offset: 0x000AE354
    private static uint gmGmkBoss3PillarCalcPillarType( int event_id )
    {
        return ( uint )( event_id - 339 );
    }

    // Token: 0x060013E0 RID: 5088 RVA: 0x000B016C File Offset: 0x000AE36C
    private static void gmGmkBoss3PillarSetFieldRect( AppMain.OBS_COLLISION_OBJ field_obj, uint pillar_type )
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 2 )
        {
            field_obj.width = ( ushort )AppMain.g_gm_boss3_pillar_field_rect_wh[( int )( ( UIntPtr )pillar_type )][0];
            field_obj.height = ( ushort )AppMain.g_gm_boss3_pillar_field_rect_wh[( int )( ( UIntPtr )pillar_type )][1];
            field_obj.ofst_x = ( short )AppMain.g_gm_boss3_pillar_field_rect_offset[( int )( ( UIntPtr )pillar_type )][0];
            field_obj.ofst_y = ( short )AppMain.g_gm_boss3_pillar_field_rect_offset[( int )( ( UIntPtr )pillar_type )][1];
            return;
        }
        if ( num == 4 )
        {
            field_obj.width = ( ushort )AppMain.g_gm_boss3_pillar_f_field_rect_wh[( int )( ( UIntPtr )pillar_type )][0];
            field_obj.height = ( ushort )AppMain.g_gm_boss3_pillar_f_field_rect_wh[( int )( ( UIntPtr )pillar_type )][1];
            field_obj.ofst_x = ( short )AppMain.g_gm_boss3_pillar_f_field_rect_offset[( int )( ( UIntPtr )pillar_type )][0];
            field_obj.ofst_y = ( short )AppMain.g_gm_boss3_pillar_f_field_rect_offset[( int )( ( UIntPtr )pillar_type )][1];
        }
    }

    // Token: 0x060013E1 RID: 5089 RVA: 0x000B021C File Offset: 0x000AE41C
    private static void gmGmkBoss3PillarSetMoveSpeed( AppMain.OBS_OBJECT_WORK obj_work, uint pillar_type, int speed )
    {
        int x = AppMain.FX_Mul(speed, AppMain.g_gm_boss3_pillar_adjust_dir[(int)((UIntPtr)pillar_type)][0] * 4096);
        int y = AppMain.FX_Mul(speed, AppMain.g_gm_boss3_pillar_adjust_dir[(int)((UIntPtr)pillar_type)][1] * 4096);
        obj_work.spd.x = x;
        obj_work.spd.y = y;
    }

    // Token: 0x060013E2 RID: 5090 RVA: 0x000B0270 File Offset: 0x000AE470
    private static void gmGmkBoss3PillarSetMoveTarget( AppMain.OBS_OBJECT_WORK obj_work, uint pillar_type, int distance )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        int num = AppMain.FX_Mul(distance, AppMain.g_gm_boss3_pillar_adjust_dir[(int)((UIntPtr)pillar_type)][0] * 4096);
        int num2 = AppMain.FX_Mul(distance, AppMain.g_gm_boss3_pillar_adjust_dir[(int)((UIntPtr)pillar_type)][1] * 4096);
        gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.x = gms_GMK_BOSS3_PILLAR_MAIN_WORK.default_pos.x + num;
        gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.y = gms_GMK_BOSS3_PILLAR_MAIN_WORK.default_pos.y + num2;
    }

    // Token: 0x060013E3 RID: 5091 RVA: 0x000B02E4 File Offset: 0x000AE4E4
    private static void gmGmkBoss3PillarSetMoveHurry( AppMain.OBS_OBJECT_WORK obj_work, int frame )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        if ( frame <= 0 )
        {
            obj_work.pos.Assign( gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos );
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            return;
        }
        int numer = gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.x - obj_work.pos.x;
        int numer2 = gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.y - obj_work.pos.y;
        int x = AppMain.FX_Div(numer, frame * 4096);
        int y = AppMain.FX_Div(numer2, frame * 4096);
        obj_work.spd.x = x;
        obj_work.spd.y = y;
    }

    // Token: 0x060013E4 RID: 5092 RVA: 0x000B038C File Offset: 0x000AE58C
    private static bool gmGmkBoss3PillarCheckMoveEnd( AppMain.OBS_OBJECT_WORK obj_work, uint pillar_type )
    {
        AppMain.UNREFERENCED_PARAMETER( pillar_type );
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        bool result = false;
        int x = obj_work.spd.x;
        int y = obj_work.spd.y;
        if ( x == 0 && y == 0 )
        {
            result = true;
        }
        else
        {
            int num = gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.x - obj_work.pos.x;
            int num2 = gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.y - obj_work.pos.y;
            if ( ( x < 0 && num >= 0 ) || ( x > 0 && num <= 0 ) || ( y < 0 && num2 >= 0 ) || ( y > 0 && num2 <= 0 ) )
            {
                result = true;
            }
        }
        return result;
    }

    // Token: 0x060013E5 RID: 5093 RVA: 0x000B0428 File Offset: 0x000AE628
    private static void gmBoss3PillarDestFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work );
            gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work = null;
        }
        if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle );
        }
        AppMain.GMM_PAD_VIB_STOP();
        if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle );
            gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060013E6 RID: 5094 RVA: 0x000B04A4 File Offset: 0x000AE6A4
    private static void gmBoss3PillarOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        uint num = AppMain.gmGmkBoss3PillarCalcPillarType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        int i = 0;
        int[] array = null;
        int[] array2 = null;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.g_gm_gmk_boss3_pillar_obj_tvx_list;
        if ( num2 == 2 )
        {
            i = AppMain.g_gm_gmk_boss3_pillar_parts_num[( int )( ( UIntPtr )num )];
            array = AppMain.g_gm_boss3_pillar_parts_offset[( int )( ( UIntPtr )num )];
            array2 = AppMain.g_gm_boss3_pillar_model_id[( int )( ( UIntPtr )num )];
        }
        else if ( num2 == 4 )
        {
            i = AppMain.g_gm_gmk_boss3_pillar_f_parts_num[( int )( ( UIntPtr )num )];
            array = AppMain.g_gm_boss3_pillar_f_parts_offset[( int )( ( UIntPtr )num )];
            array2 = AppMain.g_gm_boss3_pillar_f_model_id[( int )( ( UIntPtr )num )];
            int num3 = AppMain.g_gm_boss3_pillar_f_sub_model_id[(int)((UIntPtr)num)];
        }
        uint gmd_TVX_DISP_SCALE = AppMain.GMD_TVX_DISP_SCALE;
        AppMain.VecFx32 vecFx;
        vecFx.x = AppMain.FX_F32_TO_FX32( 1.25f );
        vecFx.y = AppMain.FX_F32_TO_FX32( 1.25f );
        vecFx.z = obj_work.scale.z;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            vecFx.x *= -1;
        }
        else if ( ( obj_work.disp_flag & 2U ) != 0U )
        {
            vecFx.y *= -1;
        }
        AppMain.TVX_FILE tvx_FILE;
        if ( ams_AMB_HEADER.buf[array2[0]] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER, array2[0] ) );
            ams_AMB_HEADER.buf[array2[0]] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )ams_AMB_HEADER.buf[array2[0]];
        }
        AppMain.GmTvxSetModel( tvx_FILE, obj_work.obj_3d.texlist, ref obj_work.pos, ref vecFx, gmd_TVX_DISP_SCALE, 0 );
        int num4 = 1;
        while ( i > num4 )
        {
            int num5 = -array[num4];
            int num6 = -array[num4];
            num5 *= AppMain.g_gm_boss3_pillar_adjust_dir[( int )( ( UIntPtr )num )][0] * 40;
            num6 *= AppMain.g_gm_boss3_pillar_adjust_dir[( int )( ( UIntPtr )num )][1] * 40;
            AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(obj_work.pos);
            vecFx2.x += num5 * 4096;
            vecFx2.y += num6 * 4096;
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( ams_AMB_HEADER, array2[num4] ) );
            AppMain.GmTvxSetModel( tvx_FILE, obj_work.obj_3d.texlist, ref vecFx2, ref vecFx, gmd_TVX_DISP_SCALE, 0 );
            num4++;
        }
    }

    // Token: 0x060013E7 RID: 5095 RVA: 0x000B06E4 File Offset: 0x000AE8E4
    private static void gmGmkBoss3PillarPartsInitMain( AppMain.OBS_OBJECT_WORK obj_work, uint pillar_type )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkBoss3PillarSetFieldRect( gms_ENEMY_3D_WORK.ene_com.col_work.obj_col, pillar_type );
        obj_work.disp_flag |= 67108864U;
        obj_work.flag |= 16U;
        obj_work.move_flag |= 4112U;
        obj_work.move_flag &= 4294967167U;
        obj_work.move_flag |= 256U;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 2 )
        {
            if ( pillar_type == 0U )
            {
                obj_work.disp_flag |= 1U;
            }
            else if ( pillar_type == 2U )
            {
                obj_work.disp_flag |= 2U;
            }
            gms_ENEMY_3D_WORK.obj_3d.drawflag |= 32U;
            obj_work.pos.x = obj_work.pos.x + AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_boss3_pillar_adjust_default_pos[( int )( ( UIntPtr )pillar_type )][0] );
            obj_work.pos.y = obj_work.pos.y + AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_boss3_pillar_adjust_default_pos[( int )( ( UIntPtr )pillar_type )][1] );
        }
        else if ( num == 4 )
        {
            obj_work.pos.x = obj_work.pos.x + AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_boss3_pillar_f_adjust_default_pos[( int )( ( UIntPtr )pillar_type )][0] );
            obj_work.pos.y = obj_work.pos.y + AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_boss3_pillar_f_adjust_default_pos[( int )( ( UIntPtr )pillar_type )][1] );
        }
        obj_work.pos.z = -655360;
        gms_GMK_BOSS3_PILLAR_MAIN_WORK.default_pos.Assign( obj_work.pos );
        gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.Assign( gms_GMK_BOSS3_PILLAR_MAIN_WORK.default_pos );
        gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        AppMain.gmGmkBoss3PillarPartsChangeModeWait( obj_work );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3PillarOutFunc );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss3PillarDestFunc ) );
    }

    // Token: 0x060013E8 RID: 5096 RVA: 0x000B08D0 File Offset: 0x000AEAD0
    private static void gmGmkBoss3PillarPartsChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        obj_work.pos.Assign( gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos );
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarPartsMainWait );
        if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work );
            gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work = null;
        }
    }

    // Token: 0x060013E9 RID: 5097 RVA: 0x000B0940 File Offset: 0x000AEB40
    private static void gmGmkBoss3PillarPartsChangeModeNormal( AppMain.OBS_OBJECT_WORK obj_work, int distance, int wait_time )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        uint pillar_type = AppMain.gmGmkBoss3PillarCalcPillarType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        AppMain.gmGmkBoss3PillarSetMoveTarget( obj_work, pillar_type, distance );
        float num = 0.5f;
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num2 == 4 )
        {
            num *= 1.5f;
        }
        AppMain.gmGmkBoss3PillarSetMoveSpeed( obj_work, pillar_type, AppMain.FX_F32_TO_FX32( num ) );
        obj_work.user_flag |= 4U;
        AppMain.gm_gmk_boss3_pillar_global_flag |= 4;
        obj_work.user_timer = wait_time;
        obj_work.move_flag |= 8192U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarPartsMainReady );
    }

    // Token: 0x060013EA RID: 5098 RVA: 0x000B09E7 File Offset: 0x000AEBE7
    private static void gmGmkBoss3PillarPartsChangeModeHurry( AppMain.OBS_OBJECT_WORK obj_work, int move_frame )
    {
        AppMain.gmGmkBoss3PillarSetMoveHurry( obj_work, move_frame );
        obj_work.user_timer = 0;
        obj_work.move_flag &= 4294959103U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarPartsMainActive );
    }

    // Token: 0x060013EB RID: 5099 RVA: 0x000B0A1C File Offset: 0x000AEC1C
    private static void gmGmkBoss3PillarPartsChangeModeReturn( AppMain.OBS_OBJECT_WORK obj_work, int wait_time, int move_frame )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        uint pillar_type = AppMain.gmGmkBoss3PillarCalcPillarType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        AppMain.gmGmkBoss3PillarSetMoveTarget( obj_work, pillar_type, 0 );
        AppMain.gmGmkBoss3PillarSetMoveHurry( obj_work, move_frame );
        obj_work.user_flag &= 4294967294U;
        obj_work.user_flag |= 4U;
        obj_work.user_flag &= 4294967287U;
        AppMain.gm_gmk_boss3_pillar_global_flag |= 4;
        AppMain.gm_gmk_boss3_pillar_global_flag = ( int )( ( long )AppMain.gm_gmk_boss3_pillar_global_flag & -9 );
        obj_work.user_timer = wait_time;
        obj_work.move_flag |= 8192U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarPartsMainReady );
    }

    // Token: 0x060013EC RID: 5100 RVA: 0x000B0AC8 File Offset: 0x000AECC8
    private static void gmGmkBoss3PillarPartsMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060013ED RID: 5101 RVA: 0x000B0ACC File Offset: 0x000AECCC
    private static void gmGmkBoss3PillarPartsMainReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer > 0 )
        {
            obj_work.user_timer--;
            return;
        }
        obj_work.move_flag &= 4294959103U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarPartsMainActive );
        AppMain.gmGmkBoss3PillarEffectCreatePillarAppear( obj_work );
        obj_work.user_timer = 45;
        if ( ( ( ulong )obj_work.user_flag & ( ulong )( ( long )AppMain.gm_gmk_boss3_pillar_global_flag ) & 4UL ) != 0UL )
        {
            AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
            if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle != null )
            {
                AppMain.GmSoundPlaySE( "Boss3_01", gms_GMK_BOSS3_PILLAR_MAIN_WORK.se_handle );
            }
            obj_work.user_flag &= 4294967291U;
            AppMain.gm_gmk_boss3_pillar_global_flag = ( int )( ( long )AppMain.gm_gmk_boss3_pillar_global_flag & -5 );
            AppMain.GMM_PAD_VIB_SMALL_NOEND();
        }
    }

    // Token: 0x060013EE RID: 5102 RVA: 0x000B0B7C File Offset: 0x000AED7C
    private static void gmGmkBoss3PillarPartsMainActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        uint pillar_type = AppMain.gmGmkBoss3PillarCalcPillarType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        if ( --obj_work.user_timer == 0 )
        {
            AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
            if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work != null )
            {
                AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work );
                gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work = null;
            }
        }
        if ( !AppMain.gmGmkBoss3PillarCheckMoveEnd( obj_work, pillar_type ) )
        {
            return;
        }
        if ( ( obj_work.user_flag & 1U ) != 0U )
        {
            AppMain.gmGmkBoss3PillarEffectCreatePillarHit( obj_work );
            obj_work.user_flag &= 4294967294U;
            AppMain.GMM_PAD_VIB_STOP();
        }
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK2 = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK2.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_BOSS3_PILLAR_MAIN_WORK2.se_handle );
            if ( ( ( ulong )obj_work.user_flag & ( ulong )( ( long )AppMain.gm_gmk_boss3_pillar_global_flag ) & 8UL ) != 0UL )
            {
                AppMain.GmSoundPlaySE( "Boss3_02", gms_GMK_BOSS3_PILLAR_MAIN_WORK2.se_handle );
                obj_work.user_flag &= 4294967287U;
                AppMain.gm_gmk_boss3_pillar_global_flag = ( int )( ( long )AppMain.gm_gmk_boss3_pillar_global_flag & -9 );
            }
        }
        AppMain.gmGmkBoss3PillarPartsChangeModeWait( obj_work );
    }

    // Token: 0x060013EF RID: 5103 RVA: 0x000B0C74 File Offset: 0x000AEE74
    private static AppMain.GSS_SND_SE_HANDLE gmGmkBoss3PillarGetSeHandle()
    {
        AppMain.GSS_SND_SE_HANDLE result = null;
        if ( AppMain.gm_gmk_boss3_pillar_se_use_count <= 0 )
        {
            result = AppMain.GsSoundAllocSeHandle();
            AppMain.gm_gmk_boss3_pillar_se_use_count++;
        }
        return result;
    }

    // Token: 0x060013F0 RID: 5104 RVA: 0x000B0C9E File Offset: 0x000AEE9E
    private static void gmGmkBoss3PillarFreeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        if ( se_handle != null )
        {
            AppMain.GmSoundStopSE( se_handle );
            AppMain.GsSoundFreeSeHandle( se_handle );
            AppMain.gm_gmk_boss3_pillar_se_use_count--;
        }
    }

    // Token: 0x060013F1 RID: 5105 RVA: 0x000B0CBC File Offset: 0x000AEEBC
    private static void gmGmkBoss3PillarWallInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 2 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 32;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 192;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = -16;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -16;
        }
        else if ( num == 4 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 32;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 192;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = -16;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = 0;
        }
        obj_work.disp_flag |= 67108864U;
        obj_work.flag |= 16U;
        obj_work.move_flag |= 272U;
        obj_work.move_flag &= 4294967167U;
        gms_GMK_BOSS3_PILLAR_WALL_WORK.gimmick_work.ene_com.enemy_flag |= 16384U;
        obj_work.pos.z = -393216;
        gms_GMK_BOSS3_PILLAR_WALL_WORK.default_pos.Assign( obj_work.pos );
        gms_GMK_BOSS3_PILLAR_WALL_WORK.target_pos.Assign( gms_GMK_BOSS3_PILLAR_WALL_WORK.default_pos );
        gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        obj_work.user_flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarWallMainWait );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss3PillarWallDestFunc ) );
        if ( num == 2 )
        {
            obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3PillarWallOutFunc );
            return;
        }
        if ( num == 4 )
        {
            obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3PillarWallOutFuncForFinalZone );
        }
    }

    // Token: 0x060013F2 RID: 5106 RVA: 0x000B0EF8 File Offset: 0x000AF0F8
    private static void gmBoss3PillarWallDestFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work );
            gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work = null;
        }
        AppMain.GMM_PAD_VIB_STOP();
        if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle );
            gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060013F3 RID: 5107 RVA: 0x000B0F60 File Offset: 0x000AF160
    private static void gmBoss3PillarWallOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int i = 6;
        int num = 32;
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.TVX_FILE model_tvx = new AppMain.TVX_FILE((AppMain.AmbChunk)AppMain.amBindGet(AppMain.g_gm_gmk_boss3_wall_obj_tvx_list, 0));
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(4096, 4096, 4096);
        int num2 = 0;
        while ( i > num2 )
        {
            AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(obj_work.pos);
            vecFx2.y += num * num2 * 4096;
            AppMain.GmTvxSetModel( model_tvx, obj_work.obj_3d.texlist, ref vecFx2, ref vecFx, 0U, 0 );
            num2++;
        }
    }

    // Token: 0x060013F4 RID: 5108 RVA: 0x000B1000 File Offset: 0x000AF200
    private static void gmBoss3PillarWallOutFuncForFinalZone( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int i = 3;
        int num = 64;
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        uint num2 = obj_work.disp_flag | 4U;
        num2 |= 4096U;
        obj_work.ofst.y = num * 4096;
        AppMain.ObjDrawActionSummary( obj_work );
        int num3 = 1;
        while ( i > num3 )
        {
            AppMain.VecFx32 vecFx = new AppMain.VecFx32(obj_work.pos);
            vecFx.y += obj_work.ofst.y + num * ( num3 - 1 ) * 4096;
            AppMain.ObjDrawAction3DNN( gms_GMK_BOSS3_PILLAR_WALL_WORK.obj_3d_parts[0], new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref obj_work.disp_flag );
            num3++;
        }
    }

    // Token: 0x060013F5 RID: 5109 RVA: 0x000B10B0 File Offset: 0x000AF2B0
    private static void gmGmkBoss3PillarWallChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        obj_work.spd.y = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarWallMainWait );
        if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work );
            gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work = null;
        }
    }

    // Token: 0x060013F6 RID: 5110 RVA: 0x000B1104 File Offset: 0x000AF304
    private static void gmGmkBoss3PillarWallChangeModeActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        int num = 917504;
        gms_GMK_BOSS3_PILLAR_WALL_WORK.target_pos.y = gms_GMK_BOSS3_PILLAR_WALL_WORK.default_pos.y - num;
        obj_work.spd.y = -12288;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarWallMainActive );
        AppMain.gmGmkBoss3PillarEffectCreateWallAppear( obj_work );
        if ( ( obj_work.user_flag & 4U ) != 0U )
        {
            if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle != null )
            {
                AppMain.GmSoundPlaySE( "Boss3_01", gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle );
            }
            obj_work.user_flag &= 4294967291U;
            AppMain.GMM_PAD_VIB_SMALL_NOEND();
        }
        short ofst_x = -16;
        int num2 = AppMain.g_gm_main_system.map_fcol.left + (AppMain.g_gm_main_system.map_fcol.right - AppMain.g_gm_main_system.map_fcol.left) / 2;
        if ( num2 * 4096 > obj_work.pos.x )
        {
            ofst_x = -32;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ofst_x;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 48;
    }

    // Token: 0x060013F7 RID: 5111 RVA: 0x000B1218 File Offset: 0x000AF418
    private static void gmGmkBoss3PillarWallChangeModeReturn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        gms_GMK_BOSS3_PILLAR_WALL_WORK.target_pos.Assign( gms_GMK_BOSS3_PILLAR_WALL_WORK.default_pos );
        obj_work.spd.y = 12288;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3PillarWallMainActive );
        obj_work.user_flag &= 4294967279U;
        AppMain.gmGmkBoss3PillarEffectCreateWallAppear( obj_work );
        if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle != null )
        {
            AppMain.GmSoundPlaySE( "Boss3_01", gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle );
        }
        AppMain.GMM_PAD_VIB_SMALL_NOEND();
    }

    // Token: 0x060013F8 RID: 5112 RVA: 0x000B1294 File Offset: 0x000AF494
    private static int gmGmkBoss3PillarWallCheckMoveEnd( AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK wall_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)wall_work;
        if ( wall_work.target_pos.y == obs_OBJECT_WORK.pos.y || obs_OBJECT_WORK.spd.y == 0 )
        {
            return 0;
        }
        int num = wall_work.target_pos.y - obs_OBJECT_WORK.pos.y;
        if ( obs_OBJECT_WORK.spd.y < 0 )
        {
            if ( num >= 0 )
            {
                obs_OBJECT_WORK.pos.y = wall_work.target_pos.y;
                return 0;
            }
        }
        else if ( obs_OBJECT_WORK.spd.y > 0 && num <= 0 )
        {
            obs_OBJECT_WORK.pos.y = wall_work.target_pos.y;
            return 0;
        }
        return num;
    }

    // Token: 0x060013F9 RID: 5113 RVA: 0x000B133C File Offset: 0x000AF53C
    private static void gmGmkBoss3PillarWallMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060013FA RID: 5114 RVA: 0x000B1340 File Offset: 0x000AF540
    private static void gmGmkBoss3PillarWallMainActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        int num = AppMain.gmGmkBoss3PillarWallCheckMoveEnd(gms_GMK_BOSS3_PILLAR_WALL_WORK);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( obj_work.spd.y < 0 && AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.pos.x - obj_work.pos.x ) < 65536 && obs_OBJECT_WORK.pos.y <= obj_work.pos.y && AppMain.MTM_MATH_ABS( num ) < 262144 )
        {
            int num2 = AppMain.g_gm_main_system.map_fcol.left + (AppMain.g_gm_main_system.map_fcol.right - AppMain.g_gm_main_system.map_fcol.left) / 2;
            if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
            {
                int num3 = 16384;
                if ( num2 * 4096 < obs_OBJECT_WORK.pos.x )
                {
                    num3 *= -1;
                }
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.flow.x = obs_OBJECT_WORK2.flow.x + num3;
            }
            else
            {
                int num4 = 4096;
                if ( num2 * 4096 < obs_OBJECT_WORK.pos.x )
                {
                    num4 *= -1;
                }
                AppMain.GmPlySeqGmkInitGmkJump( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, num4, 0 );
                AppMain.GmPlySeqChangeSequenceState( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, 17 );
            }
        }
        if ( num != 0 )
        {
            return;
        }
        obj_work.pos.Assign( gms_GMK_BOSS3_PILLAR_WALL_WORK.target_pos );
        AppMain.gmGmkBoss3PillarWallChangeModeWait( obj_work );
        if ( ( obj_work.user_flag & 1U ) != 0U )
        {
            AppMain.gmGmkBoss3PillarEffectCreateWallHit( obj_work );
            obj_work.user_flag &= 4294967294U;
        }
        AppMain.GMM_PAD_VIB_STOP();
        if ( ( obj_work.user_flag & 2U ) != 0U )
        {
            AppMain.GmCameraVibrationSet( 0, 12288, 0 );
            obj_work.user_flag &= 4294967293U;
        }
        if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle );
            if ( ( obj_work.user_flag & 8U ) != 0U )
            {
                AppMain.GmSoundPlaySE( "Boss3_02", gms_GMK_BOSS3_PILLAR_WALL_WORK.se_handle );
                obj_work.user_flag &= 4294967287U;
            }
        }
    }

    // Token: 0x060013FB RID: 5115 RVA: 0x000B1520 File Offset: 0x000AF720
    private static void gmGmkBoss3PillarWallDrawBack( float left, float top, float right, float bottom, float z )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 0;
        ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
        AppMain.NNS_PRIM3D_PC[] array = AppMain.amDrawAlloc_NNS_PRIM3D_PC(6);
        AppMain.amVectorSet( array[0], left, top, z );
        AppMain.amVectorSet( array[1], right, top, z );
        AppMain.amVectorSet( array[2], left, bottom, z );
        AppMain.amVectorSet( array[5], right, bottom, z );
        uint col = AppMain.AMD_RGBA8888(0, 0, 0, byte.MaxValue);
        array[0].Col = col;
        array[1].Col = col;
        array[2].Col = col;
        array[5].Col = col;
        array[3] = array[1];
        array[4] = array[2];
        ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
        ams_PARAM_DRAW_PRIMITIVE.type = 0;
        ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = array;
        ams_PARAM_DRAW_PRIMITIVE.texlist = null;
        ams_PARAM_DRAW_PRIMITIVE.texId = 0;
        ams_PARAM_DRAW_PRIMITIVE.count = 6;
        ams_PARAM_DRAW_PRIMITIVE.sortZ = -1f;
        AppMain.gmGmkBoss3PillarWallMatrixPush( 0U );
        AppMain.amDrawPrimitive3D( 0U, ams_PARAM_DRAW_PRIMITIVE );
        AppMain.gmGmkBoss3PillarWallMatrixPop( 0U );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x060013FC RID: 5116 RVA: 0x000B1671 File Offset: 0x000AF871
    private static void gmGmkBoss3PillarWallMatrixPush( uint command_state )
    {
        AppMain.ObjDraw3DNNUserFunc( new AppMain.OBF_DRAW_USER_DT_FUNC( AppMain.gmGmkBoss3PillarWallUserFuncMatrixPush ), null, 0, command_state );
    }

    // Token: 0x060013FD RID: 5117 RVA: 0x000B1687 File Offset: 0x000AF887
    private static void gmGmkBoss3PillarWallMatrixPop( uint command_state )
    {
        AppMain.ObjDraw3DNNUserFunc( new AppMain.OBF_DRAW_USER_DT_FUNC( AppMain.gmGmkBoss3PillarWallUserFuncPop ), null, 0, command_state );
    }

    // Token: 0x060013FE RID: 5118 RVA: 0x000B16A0 File Offset: 0x000AF8A0
    private static void gmGmkBoss3PillarWallUserFuncMatrixPush( object param )
    {
        AppMain.UNREFERENCED_PARAMETER( param );
        AppMain.amMatrixPush();
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain.amDrawGetWorldViewMatrix(), mtx );
        AppMain.nnSetPrimitive3DMatrix( nns_MATRIX );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x060013FF RID: 5119 RVA: 0x000B16DC File Offset: 0x000AF8DC
    private static void gmGmkBoss3PillarWallUserFuncPop( object param )
    {
        AppMain.amMatrixPop();
    }

    // Token: 0x06001400 RID: 5120 RVA: 0x000B16E4 File Offset: 0x000AF8E4
    private static void gmGmkBoss3PillarEffectCreatePillarAppear( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        if ( gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work != null )
        {
            return;
        }
        int num = gms_GMK_BOSS3_PILLAR_MAIN_WORK.default_pos.x;
        int num2 = gms_GMK_BOSS3_PILLAR_MAIN_WORK.default_pos.y;
        int num3 = 0;
        uint num4 = 0U;
        uint num5 = AppMain.gmGmkBoss3PillarCalcPillarType((int)gms_GMK_BOSS3_PILLAR_MAIN_WORK.gimmick_work.ene_com.eve_rec.id);
        int num6 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( num6 == 2 )
        {
            switch ( num5 )
            {
                case 0U:
                    num += 188416;
                    num3 = 14;
                    num4 = 1U;
                    break;
                case 1U:
                    num -= 188416;
                    num3 = 14;
                    break;
                case 2U:
                    num2 += 188416;
                    num3 = 15;
                    break;
                case 3U:
                    num2 -= 188416;
                    num3 = 13;
                    break;
            }
            gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( null, num6, num3 );
        }
        else
        {
            switch ( num5 )
            {
                case 0U:
                    num += 229376;
                    num3 = 45;
                    num4 = 1U;
                    break;
                case 1U:
                    num -= 229376;
                    num3 = 45;
                    break;
                case 2U:
                    num2 += 229376;
                    num3 = 46;
                    break;
                case 3U:
                    num2 -= 229376;
                    num3 = 44;
                    break;
            }
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( null, num3 );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
        obs_OBJECT_WORK.pos.x = num;
        obs_OBJECT_WORK.pos.y = num2;
        obs_OBJECT_WORK.pos.z = -524288;
        obs_OBJECT_WORK.disp_flag |= num4;
        gms_GMK_BOSS3_PILLAR_MAIN_WORK.effect_work = gms_EFFECT_3DES_WORK;
    }

    // Token: 0x06001401 RID: 5121 RVA: 0x000B185C File Offset: 0x000AFA5C
    private static void gmGmkBoss3PillarEffectCreatePillarHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK gms_GMK_BOSS3_PILLAR_MAIN_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK)obj_work;
        int num = gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.x;
        int num2 = gms_GMK_BOSS3_PILLAR_MAIN_WORK.target_pos.y;
        ushort z = 0;
        uint num3 = AppMain.gmGmkBoss3PillarCalcPillarType((int)gms_GMK_BOSS3_PILLAR_MAIN_WORK.gimmick_work.ene_com.eve_rec.id);
        int num4 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK work;
        if ( num4 == 2 )
        {
            int num5 = 16;
            switch ( num3 )
            {
                case 0U:
                    num += 122880;
                    z = ( ushort )AppMain.NNM_DEGtoA16( -90f );
                    break;
                case 1U:
                    num -= 122880;
                    z = ( ushort )AppMain.NNM_DEGtoA16( 90f );
                    break;
                case 2U:
                    num2 += 122880;
                    break;
                case 3U:
                    num2 -= 122880;
                    z = ( ushort )AppMain.NNM_DEGtoA16( 180f );
                    break;
            }
            work = AppMain.GmEfctZoneEsCreate( null, num4, num5 );
        }
        else
        {
            int num5 = 47;
            switch ( num3 )
            {
                case 0U:
                    num += 163840;
                    z = ( ushort )AppMain.NNM_DEGtoA16( -90f );
                    break;
                case 1U:
                    num -= 163840;
                    z = ( ushort )AppMain.NNM_DEGtoA16( 90f );
                    break;
                case 2U:
                    num2 += 163840;
                    break;
                case 3U:
                    num2 -= 163840;
                    z = ( ushort )AppMain.NNM_DEGtoA16( 180f );
                    break;
            }
            work = AppMain.GmEfctCmnEsCreate( null, num5 );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK.pos.x = num;
        obs_OBJECT_WORK.pos.y = num2;
        obs_OBJECT_WORK.pos.z = 655360;
        obs_OBJECT_WORK.dir.z = z;
    }

    // Token: 0x06001402 RID: 5122 RVA: 0x000B19F8 File Offset: 0x000AFBF8
    private static void gmGmkBoss3PillarEffectCreateWallAppear( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        if ( gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work != null )
        {
            return;
        }
        int x = gms_GMK_BOSS3_PILLAR_WALL_WORK.default_pos.x;
        int num = gms_GMK_BOSS3_PILLAR_WALL_WORK.default_pos.y;
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( num2 == 2 )
        {
            num -= 196608;
            gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( null, num2, 13 );
        }
        else
        {
            num -= 131072;
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( null, 44 );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
        obs_OBJECT_WORK.pos.x = x;
        obs_OBJECT_WORK.pos.y = num;
        obs_OBJECT_WORK.pos.z = 393216;
        gms_GMK_BOSS3_PILLAR_WALL_WORK.effect_work = gms_EFFECT_3DES_WORK;
    }

    // Token: 0x06001403 RID: 5123 RVA: 0x000B1AA8 File Offset: 0x000AFCA8
    private static void gmGmkBoss3PillarEffectCreateWallHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK gms_GMK_BOSS3_PILLAR_WALL_WORK = (AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK)obj_work;
        int x = gms_GMK_BOSS3_PILLAR_WALL_WORK.target_pos.x;
        int num = gms_GMK_BOSS3_PILLAR_WALL_WORK.target_pos.y;
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK work;
        if ( num2 == 2 )
        {
            num -= 65536;
            work = AppMain.GmEfctZoneEsCreate( null, num2, 16 );
        }
        else
        {
            num = num;
            work = AppMain.GmEfctCmnEsCreate( null, 47 );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK.pos.x = x;
        obs_OBJECT_WORK.pos.y = num;
        obs_OBJECT_WORK.pos.z = 655360;
        obs_OBJECT_WORK.dir.z = ( ushort )AppMain.NNM_DEGtoA16( 180f );
    }
}