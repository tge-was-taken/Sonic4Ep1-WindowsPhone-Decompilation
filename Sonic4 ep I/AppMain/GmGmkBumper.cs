using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000034 RID: 52
    public class GMS_GMK_BUMPER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001D41 RID: 7489 RVA: 0x001372CD File Offset: 0x001354CD
        public GMS_GMK_BUMPER_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001D42 RID: 7490 RVA: 0x001372EC File Offset: 0x001354EC
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0400482D RID: 18477
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x0400482E RID: 18478
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_parts = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x0400482F RID: 18479
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x0600006F RID: 111 RVA: 0x00006068 File Offset: 0x00004268
    private static void GmGmkBumperBuild()
    {
        AppMain.g_gm_gmk_bumper_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 852 ), AppMain.GmGameDatGetGimmickData( 853 ), 0U );
    }

    // Token: 0x06000070 RID: 112 RVA: 0x0000608C File Offset: 0x0000428C
    private static void GmGmkBumperFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(852);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_bumper_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_bumper_obj_3d_list = null;
    }

    // Token: 0x06000071 RID: 113 RVA: 0x000060BC File Offset: 0x000042BC
    private static AppMain.OBS_OBJECT_WORK GmGmkBumperInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int num = (int)(eve_rec.id - 146);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBumperLoadObj(eve_rec, pos_x, pos_y, num);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkBumperInit( obj_work, num );
        return obj_work;
    }

    // Token: 0x06000072 RID: 114 RVA: 0x000060F4 File Offset: 0x000042F4
    private static uint gmGmkBumpereGameSystemGetSyncTime()
    {
        return AppMain.g_gm_main_system.sync_time;
    }

    // Token: 0x06000073 RID: 115 RVA: 0x00006108 File Offset: 0x00004308
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBumperLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BUMPER_WORK(), "GMK_BUMPER");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000074 RID: 116 RVA: 0x00006188 File Offset: 0x00004388
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBumperLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBumperLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        int num = AppMain.g_gm_gmk_bumper_model_id[type];
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_bumper_obj_3d_list[num], gms_ENEMY_3D_WORK.obj_3d );
        int index = AppMain.g_gm_gmk_bumper_motion_id[type];
        object pData = AppMain.ObjDataGet(855).pData;
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, 0, null, null, index, pData );
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000075 RID: 117 RVA: 0x000061EC File Offset: 0x000043EC
    private static void gmGmkBumperInit( AppMain.OBS_OBJECT_WORK obj_work, int bumper_type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkBumperSetRect( gms_ENEMY_3D_WORK, bumper_type );
        obj_work.move_flag = 8448U;
        obj_work.dir.z = AppMain.g_gm_gmk_bumper_angle_z[bumper_type];
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        obj_work.disp_flag |= 4194324U;
        obj_work.pos.z = -122880;
        AppMain.GMS_GMK_BUMPER_WORK gms_GMK_BUMPER_WORK = (AppMain.GMS_GMK_BUMPER_WORK)gms_ENEMY_3D_WORK;
        gms_GMK_BUMPER_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBumperDrawFunc );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkBumperDestFunc ) );
    }

    // Token: 0x06000076 RID: 118 RVA: 0x00006298 File Offset: 0x00004498
    private static void gmGmkBumperSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work, int bumper_type )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        short cLeft = AppMain.g_gmk_bumper_rect[bumper_type][0];
        short cRight = AppMain.g_gmk_bumper_rect[bumper_type][2];
        short cTop = AppMain.g_gmk_bumper_rect[bumper_type][1];
        short cBottom = AppMain.g_gmk_bumper_rect[bumper_type][3];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, cLeft, cTop, -500, cRight, cBottom, 500 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkBumperDefFunc );
    }

    // Token: 0x06000077 RID: 119 RVA: 0x00006310 File Offset: 0x00004510
    private static void gmGmkBumperDestFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_BUMPER_WORK gms_GMK_BUMPER_WORK = (tcb.work is AppMain.GMS_GMK_BUMPER_WORK) ? ((AppMain.GMS_GMK_BUMPER_WORK)tcb.work) : ((AppMain.GMS_GMK_BUMPER_WORK)AppMain.mtTaskGetTcbWork(tcb));
        if ( gms_GMK_BUMPER_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_BUMPER_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_BUMPER_WORK.se_handle );
            gms_GMK_BUMPER_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000078 RID: 120 RVA: 0x00006370 File Offset: 0x00004570
    private static void gmGmkBumperDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( obj_3d.motion != null )
        {
            float num = AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num2 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num3 = num2 - num;
            float num4 = AppMain.gmGmkBumpereGameSystemGetSyncTime();
            obj_3d.mat_frame = num4 % num3;
        }
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06000079 RID: 121 RVA: 0x000063D0 File Offset: 0x000045D0
    private static int gmGmkBumperCalcType( int id )
    {
        return id - 146;
    }

    // Token: 0x0600007A RID: 122 RVA: 0x000063E8 File Offset: 0x000045E8
    private static void gmGmkBumperDefFunc( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK player_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = player_rect.parent_obj;
        if ( parent_obj2.holder == null || !( parent_obj2.holder is AppMain.GMS_ENEMY_COM_WORK ) )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
            if ( gms_PLAYER_WORK.seq_state == 40 )
            {
                return;
            }
        }
        int num = 32768;
        int num2 = 32768;
        int num3 = -12288;
        int num4 = AppMain.gmGmkBumperCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        if ( parent_obj2.obj_type == 1 && !AppMain.gmGmkBumperCheckHit( parent_obj.pos, parent_obj2.pos, num4 ) )
        {
            return;
        }
        parent_obj2.dir.z = 0;
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.z = 0;
        vecFx.x = parent_obj2.spd.x;
        vecFx.y = parent_obj2.spd.y;
        int num5 = parent_obj2.pos.x - parent_obj.pos.x;
        int num6 = parent_obj2.pos.y + num3 - parent_obj.pos.y;
        int num7 = AppMain.MTM_MATH_ABS(vecFx.x);
        int num8 = AppMain.MTM_MATH_ABS(vecFx.y);
        int no_move_time = 0;
        switch ( num4 )
        {
            case 0:
                if ( num5 > ( int )( AppMain.g_gmk_bumper_rect[0][2] * 4096 ) + num )
                {
                    vecFx.x = 16384;
                    no_move_time = 15;
                }
                else if ( num5 < ( int )( AppMain.g_gmk_bumper_rect[0][0] * 4096 ) - num )
                {
                    vecFx.x = -16384;
                    no_move_time = 15;
                }
                else
                {
                    vecFx.y = 24576;
                    if ( num5 < -num )
                    {
                        vecFx.x -= 12288;
                    }
                    else if ( num5 > num )
                    {
                        vecFx.x += 12288;
                    }
                    no_move_time = 5;
                }
                break;
            case 1:
                if ( num5 > ( int )( AppMain.g_gmk_bumper_rect[1][2] * 4096 ) )
                {
                    vecFx.x = 16384;
                    no_move_time = 15;
                }
                else if ( num5 < ( int )( AppMain.g_gmk_bumper_rect[1][0] * 4096 ) )
                {
                    vecFx.x = -16384;
                    no_move_time = 15;
                }
                else
                {
                    vecFx.y = -24576;
                    if ( num5 < -num )
                    {
                        vecFx.x -= 12288;
                    }
                    else if ( num5 > num )
                    {
                        vecFx.x += 12288;
                    }
                    no_move_time = 5;
                }
                break;
            case 2:
                if ( num6 < ( int )( AppMain.g_gmk_bumper_rect[2][1] * 4096 ) )
                {
                    vecFx.y = -24576;
                    no_move_time = 5;
                }
                else if ( num6 > ( int )( AppMain.g_gmk_bumper_rect[2][3] * 4096 ) )
                {
                    vecFx.y = 24576;
                    no_move_time = 5;
                }
                else
                {
                    vecFx.x = 16384;
                    if ( num6 < -num2 )
                    {
                        vecFx.y -= 12288;
                    }
                    else if ( num6 > num2 )
                    {
                        vecFx.y += 12288;
                    }
                    no_move_time = 15;
                }
                break;
            case 3:
                if ( num6 < ( int )( AppMain.g_gmk_bumper_rect[3][1] * 4096 ) )
                {
                    vecFx.y = -24576;
                    no_move_time = 5;
                }
                else if ( num6 > ( int )( AppMain.g_gmk_bumper_rect[3][3] * 4096 ) )
                {
                    vecFx.y = 24576;
                    no_move_time = 5;
                }
                else
                {
                    vecFx.x = -16384;
                    if ( num6 < -num2 )
                    {
                        vecFx.y -= 12288;
                    }
                    else if ( num6 > num2 )
                    {
                        vecFx.y += 12288;
                    }
                    no_move_time = 15;
                }
                break;
            case 4:
                vecFx.x = num7;
                vecFx.y = num8;
                vecFx.x = 20480;
                vecFx.y = 20480;
                no_move_time = 5;
                break;
            case 5:
                vecFx.x = num7;
                vecFx.y = -num8;
                vecFx.x = 20480;
                vecFx.y = -20480;
                no_move_time = 5;
                break;
            case 6:
                vecFx.x = -num7;
                vecFx.y = num8;
                vecFx.x = -20480;
                vecFx.y = 20480;
                no_move_time = 5;
                break;
            case 7:
                vecFx.x = -num7;
                vecFx.y = -num8;
                vecFx.x = -20480;
                vecFx.y = -20480;
                no_move_time = 5;
                break;
            case 8:
                if ( num5 > ( int )( AppMain.g_gmk_bumper_rect[8][2] * 4096 ) )
                {
                    vecFx.x = 16384;
                    no_move_time = 15;
                }
                else if ( num5 < ( int )( AppMain.g_gmk_bumper_rect[8][0] * 4096 ) )
                {
                    vecFx.x = -16384;
                    no_move_time = 15;
                }
                else if ( num6 < -num2 )
                {
                    vecFx.y = -24576;
                    if ( num5 < -num )
                    {
                        vecFx.x -= 12288;
                    }
                    else if ( num5 > num )
                    {
                        vecFx.x += 12288;
                    }
                    no_move_time = 5;
                }
                else
                {
                    vecFx.y = 24576;
                    if ( num5 < -num )
                    {
                        vecFx.x -= 12288;
                    }
                    else if ( num5 > num )
                    {
                        vecFx.x += 12288;
                    }
                    no_move_time = 5;
                }
                break;
            case 9:
                if ( num6 < ( int )( AppMain.g_gmk_bumper_rect[9][1] * 4096 ) )
                {
                    vecFx.y = -24576;
                    no_move_time = 5;
                }
                else if ( num6 > ( int )( AppMain.g_gmk_bumper_rect[9][3] * 4096 ) )
                {
                    vecFx.y = 24576;
                    no_move_time = 5;
                }
                else if ( num5 < -num )
                {
                    vecFx.x = -16384;
                    if ( num6 < -num2 )
                    {
                        vecFx.y -= 12288;
                    }
                    else if ( num5 > num )
                    {
                        vecFx.y += 12288;
                    }
                    no_move_time = 15;
                }
                else
                {
                    vecFx.x = 16384;
                    if ( num6 < -num2 )
                    {
                        vecFx.y -= 12288;
                    }
                    else if ( num5 > num )
                    {
                        vecFx.y += 12288;
                    }
                    no_move_time = 15;
                }
                break;
        }
        vecFx.x = AppMain.MTM_MATH_CLIP( vecFx.x, -16384, 16384 );
        vecFx.y = AppMain.MTM_MATH_CLIP( vecFx.y, -24576, 24576 );
        if ( parent_obj2.obj_type == 1 )
        {
            bool flag_no_recover_homing = false;
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                flag_no_recover_homing = true;
            }
            AppMain.GmPlySeqInitPinballAir( ( AppMain.GMS_PLAYER_WORK )parent_obj2, vecFx.x, vecFx.y, no_move_time, flag_no_recover_homing );
        }
        else if ( parent_obj2.obj_type == 2 )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK2 = (AppMain.GMS_ENEMY_3D_WORK)parent_obj2;
            if ( gms_ENEMY_3D_WORK2.ene_com.eve_rec.id != 316 )
            {
                return;
            }
            parent_obj2.spd.x = vecFx.x;
            parent_obj2.spd.y = vecFx.y;
            parent_obj2.spd_add.x = 0;
            parent_obj2.spd_add.y = 0;
            if ( ( long )AppMain.MTM_MATH_ABS( parent_obj2.spd.x ) < 256L )
            {
                parent_obj2.spd.x = 256;
            }
            else if ( ( long )AppMain.MTM_MATH_ABS( parent_obj2.spd.y ) < 256L )
            {
                parent_obj2.spd.y = 256;
            }
        }
        AppMain.GMS_GMK_BUMPER_WORK gms_GMK_BUMPER_WORK = (AppMain.GMS_GMK_BUMPER_WORK)parent_obj;
        if ( AppMain.gmGmkBumperCheckHitEffect( gms_GMK_BUMPER_WORK ) )
        {
            if ( gms_GMK_BUMPER_WORK.se_handle != null )
            {
                AppMain.GmSoundPlaySE( "Casino6", gms_GMK_BUMPER_WORK.se_handle );
            }
            int num9 = AppMain.g_gmk_bumper_effect_id_flush[num4];
            if ( num9 != -1 )
            {
                AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(parent_obj, num9);
                int num10 = AppMain.g_gmk_bumper_effect_offset_flush[num4][0] * 4096;
                int num11 = AppMain.g_gmk_bumper_effect_offset_flush[num4][1] * 4096;
                gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj.pos.x + num10;
                gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj.pos.y + num11;
                gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 655360;
                gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = parent_obj.dir.z;
            }
            AppMain.GMM_PAD_VIB_SMALL();
        }
    }

    // Token: 0x0600007B RID: 123 RVA: 0x00006C80 File Offset: 0x00004E80
    private static bool gmGmkBumperCheckHit( AppMain.VecFx32 gimmick_pos, AppMain.VecFx32 target_pos, int type )
    {
        switch ( type )
        {
            case 0:
                {
                    AppMain.VecFx32 vecFx = new AppMain.VecFx32(gimmick_pos);
                    vecFx.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] );
                    AppMain.VecFx32 line_end = default(AppMain.VecFx32);
                    line_end.Assign( gimmick_pos );
                    line_end.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] );
                    line_end.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] * 0.5f );
                    AppMain.VecFx32 line_start = default(AppMain.VecFx32);
                    line_start.Assign( gimmick_pos );
                    line_start.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] );
                    line_start.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] * 0.5f );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start, vecFx, target_pos ) || AppMain.gmGmkBumperCheckLeft( vecFx, line_end, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 1:
                {
                    AppMain.VecFx32 vecFx2 = default(AppMain.VecFx32);
                    vecFx2.Assign( gimmick_pos );
                    vecFx2.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] );
                    AppMain.VecFx32 line_start2 = default(AppMain.VecFx32);
                    line_start2.Assign( gimmick_pos );
                    line_start2.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] );
                    line_start2.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] * 0.4f );
                    AppMain.VecFx32 line_end2 = default(AppMain.VecFx32);
                    line_end2.Assign( gimmick_pos );
                    line_end2.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] );
                    line_end2.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] * 0.4f );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start2, vecFx2, target_pos ) || AppMain.gmGmkBumperCheckLeft( vecFx2, line_end2, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 2:
                {
                    AppMain.VecFx32 vecFx3 = default(AppMain.VecFx32);
                    vecFx3.Assign( gimmick_pos );
                    vecFx3.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] );
                    AppMain.VecFx32 line_start3 = default(AppMain.VecFx32);
                    line_start3.Assign( gimmick_pos );
                    line_start3.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] * 0.4f );
                    line_start3.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] );
                    AppMain.VecFx32 line_end3 = default(AppMain.VecFx32);
                    line_end3.Assign( gimmick_pos );
                    line_end3.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] * 0.4f );
                    line_end3.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start3, vecFx3, target_pos ) || AppMain.gmGmkBumperCheckLeft( vecFx3, line_end3, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 3:
                {
                    AppMain.VecFx32 vecFx4 = default(AppMain.VecFx32);
                    vecFx4.Assign( gimmick_pos );
                    vecFx4.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] );
                    AppMain.VecFx32 line_end4 = default(AppMain.VecFx32);
                    line_end4.Assign( gimmick_pos );
                    line_end4.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] * 0.4f );
                    line_end4.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] );
                    AppMain.VecFx32 line_start4 = default(AppMain.VecFx32);
                    line_start4.Assign( gimmick_pos );
                    line_start4.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] * 0.4f );
                    line_start4.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start4, vecFx4, target_pos ) || AppMain.gmGmkBumperCheckLeft( vecFx4, line_end4, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 4:
                {
                    AppMain.VecFx32 line_start5 = new AppMain.VecFx32(gimmick_pos);
                    line_start5.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] );
                    line_start5.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] * 0.2f );
                    AppMain.VecFx32 line_end5 = new AppMain.VecFx32(gimmick_pos);
                    line_end5.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] * 0.2f );
                    line_end5.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start5, line_end5, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 5:
                {
                    AppMain.VecFx32 line_start6 = new AppMain.VecFx32(gimmick_pos);
                    line_start6.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] * 0.2f );
                    line_start6.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] );
                    AppMain.VecFx32 line_end6 = new AppMain.VecFx32(gimmick_pos);
                    line_end6.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] );
                    line_end6.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] * 0.2f );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start6, line_end6, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 6:
                {
                    AppMain.VecFx32 line_end7 = new AppMain.VecFx32(gimmick_pos);
                    line_end7.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] );
                    line_end7.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] * 0.2f );
                    AppMain.VecFx32 line_start7 = new AppMain.VecFx32(gimmick_pos);
                    line_start7.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] * 0.2f );
                    line_start7.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][3] );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start7, line_end7, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
            case 7:
                {
                    AppMain.VecFx32 line_end8 = new AppMain.VecFx32(gimmick_pos);
                    line_end8.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][2] * 0.2f );
                    line_end8.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] );
                    AppMain.VecFx32 line_start8 = new AppMain.VecFx32(gimmick_pos);
                    line_start8.x += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][0] );
                    line_start8.y += AppMain.FX_F32_TO_FX32( ( float )AppMain.g_gmk_bumper_rect[type][1] * 0.2f );
                    if ( AppMain.gmGmkBumperCheckLeft( line_start8, line_end8, target_pos ) )
                    {
                        return false;
                    }
                    break;
                }
        }
        return true;
    }

    // Token: 0x0600007C RID: 124 RVA: 0x000072E0 File Offset: 0x000054E0
    private static bool gmGmkBumperCheckLeft( AppMain.VecFx32 line_start, AppMain.VecFx32 line_end, AppMain.VecFx32 point )
    {
        int v = line_end.x - line_start.x;
        int v2 = line_end.y - line_start.y;
        int v3 = point.x - line_start.x;
        int v4 = point.y - line_start.y;
        int num = AppMain.FX_Mul(v, v4) - AppMain.FX_Mul(v2, v3);
        return num <= 0;
    }

    // Token: 0x0600007D RID: 125 RVA: 0x00007348 File Offset: 0x00005548
    private static bool gmGmkBumperCheckHitEffect( AppMain.GMS_GMK_BUMPER_WORK bumper_work )
    {
        return bumper_work.se_handle != null && bumper_work.se_handle.au_player != null && 2 != bumper_work.se_handle.au_player.GetStatus() && 1 != bumper_work.se_handle.au_player.GetStatus();
    }
}