using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200006F RID: 111
    private static class gmGmkStopperConstants
    {
        // Token: 0x04004960 RID: 18784
        public const int GME_GMK_RECT_DATA_COL_WIDTH = 0;

        // Token: 0x04004961 RID: 18785
        public const int GME_GMK_RECT_DATA_COL_HEIGHT = 1;

        // Token: 0x04004962 RID: 18786
        public const int GME_GMK_RECT_DATA_COL_OFST_X = 2;

        // Token: 0x04004963 RID: 18787
        public const int GME_GMK_RECT_DATA_COL_OFST_Y = 3;

        // Token: 0x04004964 RID: 18788
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 4;

        // Token: 0x04004965 RID: 18789
        public const int GME_GMK_RECT_DATA_DEF_TOP = 5;

        // Token: 0x04004966 RID: 18790
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 6;

        // Token: 0x04004967 RID: 18791
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 7;

        // Token: 0x04004968 RID: 18792
        public const int GME_GMK_RECT_DATA_MAX = 8;
    }

    // Token: 0x02000070 RID: 112
    public class GMS_GMK_STOPPER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E1D RID: 7709 RVA: 0x001395E2 File Offset: 0x001377E2
        public GMS_GMK_STOPPER_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001E1E RID: 7710 RVA: 0x001395F6 File Offset: 0x001377F6
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_STOPPER_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001E1F RID: 7711 RVA: 0x00139608 File Offset: 0x00137808
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001E20 RID: 7712 RVA: 0x0013961A File Offset: 0x0013781A
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_STOPPER_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x04004969 RID: 18793
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x0400496A RID: 18794
        public readonly int obj_type;

        // Token: 0x0400496B RID: 18795
        public AppMain.GMS_PLAYER_WORK ply_work;

        // Token: 0x0400496C RID: 18796
        public short player_pass_timer;

        // Token: 0x0400496D RID: 18797
        public int call_slot_id;

        // Token: 0x0400496E RID: 18798
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x0600025F RID: 607 RVA: 0x000134EC File Offset: 0x000116EC
    private static void gmGmkStopperStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.width = ( ushort )AppMain.tbl_gm_gmk_piston_col_rect[0];
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.height = ( ushort )AppMain.tbl_gm_gmk_piston_col_rect[1];
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = AppMain.tbl_gm_gmk_piston_col_rect[2];
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = AppMain.tbl_gm_gmk_piston_col_rect[3];
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_STOPPER_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkStopperHit );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_piston_col_rect[4], AppMain.tbl_gm_gmk_piston_col_rect[5], AppMain.tbl_gm_gmk_piston_col_rect[6], AppMain.tbl_gm_gmk_piston_col_rect[7] );
        obj_work.flag &= 4294967293U;
        gms_GMK_STOPPER_WORK.se_handle = null;
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkStopperExit ) );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay );
    }

    // Token: 0x06000260 RID: 608 RVA: 0x000136A0 File Offset: 0x000118A0
    private static void gmGmkStopperStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        if ( gms_GMK_STOPPER_WORK.ply_work != null )
        {
            if ( gms_GMK_STOPPER_WORK.call_slot_id == -1 )
            {
                AppMain.gmGmkStopperStay_Norm( obj_work );
                return;
            }
            AppMain.gmGmkStopperStay_Slot( obj_work );
        }
    }

    // Token: 0x06000261 RID: 609 RVA: 0x000136D4 File Offset: 0x000118D4
    private static void gmGmkStopperStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        if ( obj_work.user_timer < gms_GMK_STOPPER_WORK.ply_work.obj_work.pos.y >> 12 )
        {
            AppMain.gmGmkStopperReset( obj_work );
        }
    }

    // Token: 0x06000262 RID: 610 RVA: 0x00013710 File Offset: 0x00011910
    private static void gmGmkStopperStay_Norm( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        obj_work.disp_flag &= 4294967279U;
        obj_work.disp_flag |= 4U;
        gms_GMK_STOPPER_WORK.player_pass_timer = 143;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_Norm_100 );
        AppMain.GmCameraAllowSet( 15f, 32f, 0f );
    }

    // Token: 0x06000263 RID: 611 RVA: 0x0001377C File Offset: 0x0001197C
    private static void gmGmkStopperStay_Norm_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        if ( gms_GMK_STOPPER_WORK.ply_work != AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] || gms_GMK_STOPPER_WORK.ply_work.gmk_obj != obj_work || gms_GMK_STOPPER_WORK.ply_work.seq_state != 40 )
        {
            AppMain.gmGmkStopperReset( obj_work );
            return;
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        AppMain.GmCameraPosSet( AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.x ), AppMain.FXM_FLOAT_TO_FX32( -obs_CAMERA.pos.y ) + 16384, AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.z ) );
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK2 = gms_GMK_STOPPER_WORK;
        gms_GMK_STOPPER_WORK2.player_pass_timer -= 1;
        if ( gms_GMK_STOPPER_WORK.player_pass_timer <= 0 )
        {
            obj_work.disp_flag &= 4294967291U;
            AppMain.gmGmkStopperStay_Norm_110( obj_work );
            return;
        }
        if ( gms_GMK_STOPPER_WORK.player_pass_timer % 16 == 0 )
        {
            AppMain.GmPlayerAddScore( gms_GMK_STOPPER_WORK.ply_work, 1000, gms_GMK_STOPPER_WORK.ply_work.obj_work.pos.x, gms_GMK_STOPPER_WORK.ply_work.obj_work.pos.y );
            AppMain.gsSoundStopSe( gms_GMK_STOPPER_WORK.se_handle );
            gms_GMK_STOPPER_WORK.se_handle.snd_ctrl_param.pitch = 0.8f - ( float )gms_GMK_STOPPER_WORK.player_pass_timer / 160f;
            AppMain.GmSoundPlaySE( "Casino3", gms_GMK_STOPPER_WORK.se_handle );
            if ( gms_GMK_STOPPER_WORK.player_pass_timer <= 16 )
            {
                AppMain.GmSoundPlaySE( "Casino3_1" );
            }
        }
    }

    // Token: 0x06000264 RID: 612 RVA: 0x000138D4 File Offset: 0x00011AD4
    private static void gmGmkStopperStay_Norm_110( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        gms_GMK_STOPPER_WORK.player_pass_timer = 0;
        gms_GMK_STOPPER_WORK.gmk_work.obj_3d.mat_frame = 0f;
        obj_work.disp_flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_100 );
        if ( gms_PLAYER_WORK.seq_state == 40 )
        {
            AppMain.GmPlySeqInitStopperEnd( gms_GMK_STOPPER_WORK.ply_work );
        }
    }

    // Token: 0x06000265 RID: 613 RVA: 0x00013948 File Offset: 0x00011B48
    private static void gmGmkStopperStay_Slot( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        obj_work.disp_flag &= 4294967279U;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_Slot_100 );
        AppMain.GmCameraAllowSet( 15f, 56f, 0f );
    }

    // Token: 0x06000266 RID: 614 RVA: 0x000139A0 File Offset: 0x00011BA0
    private static void gmGmkStopperStay_Slot_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        if ( gms_GMK_STOPPER_WORK.ply_work != AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] || gms_GMK_STOPPER_WORK.ply_work.gmk_obj != obj_work || gms_GMK_STOPPER_WORK.ply_work.seq_state != 40 )
        {
            AppMain.gmGmkStopperReset( obj_work );
            return;
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        AppMain.GmCameraPosSet( AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.x ), AppMain.FXM_FLOAT_TO_FX32( -obs_CAMERA.pos.y ) + 16384, AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.pos.z ) );
        if ( AppMain.GmGmkSlotIsStatus( gms_GMK_STOPPER_WORK.call_slot_id ) != 0 )
        {
            obj_work.disp_flag &= 4294967291U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_Slot_110 );
            AppMain.gmGmkStopperStay_Slot_110( obj_work );
        }
    }

    // Token: 0x06000267 RID: 615 RVA: 0x00013A64 File Offset: 0x00011C64
    private static void gmGmkStopperStay_Slot_110( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        gms_GMK_STOPPER_WORK.gmk_work.obj_3d.mat_frame = 0f;
        obj_work.disp_flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_100 );
        if ( gms_PLAYER_WORK.seq_state == 40 )
        {
            AppMain.GmPlySeqInitStopperEnd( gms_GMK_STOPPER_WORK.ply_work );
        }
    }

    // Token: 0x06000268 RID: 616 RVA: 0x00013AD4 File Offset: 0x00011CD4
    private static void gmGmkStopperReset( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
        obj_work.flag &= 4294967293U;
        gms_GMK_STOPPER_WORK.player_pass_timer = 0;
        gms_GMK_STOPPER_WORK.ply_work = null;
        gms_GMK_STOPPER_WORK.gmk_work.obj_3d.mat_frame = 0f;
        obj_work.disp_flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay );
        if ( gms_GMK_STOPPER_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_STOPPER_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_STOPPER_WORK.se_handle );
            gms_GMK_STOPPER_WORK.se_handle = null;
        }
    }

    // Token: 0x06000269 RID: 617 RVA: 0x00013B7C File Offset: 0x00011D7C
    private static void gmGmkStopperLockWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)obj_work;
        if ( gms_GMK_STOPPER_WORK.ply_work != AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] || gms_GMK_STOPPER_WORK.ply_work.gmk_obj != obj_work || gms_GMK_STOPPER_WORK.ply_work.seq_state != 40 )
        {
            AppMain.gmGmkStopperReset( obj_work );
            return;
        }
        AppMain.GMS_PLAYER_WORK ply_work = gms_GMK_STOPPER_WORK.ply_work;
        if ( obj_work.pos.x == ply_work.obj_work.pos.x && obj_work.pos.y == ply_work.obj_work.pos.y )
        {
            if ( gms_GMK_STOPPER_WORK.call_slot_id >= 0 )
            {
                AppMain.GmGmkSlotStartRequest( gms_GMK_STOPPER_WORK.call_slot_id, ply_work );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_Slot );
                AppMain.GmSoundPlaySE( "Casino3" );
                return;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperStay_Norm );
            if ( gms_GMK_STOPPER_WORK.se_handle != null )
            {
                AppMain.GmSoundStopSE( gms_GMK_STOPPER_WORK.se_handle );
                AppMain.GsSoundFreeSeHandle( gms_GMK_STOPPER_WORK.se_handle );
            }
            gms_GMK_STOPPER_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
            gms_GMK_STOPPER_WORK.se_handle.flag |= 2147483648U;
            AppMain.GmSoundPlaySE( "Casino3", gms_GMK_STOPPER_WORK.se_handle );
        }
    }

    // Token: 0x0600026A RID: 618 RVA: 0x00013CA8 File Offset: 0x00011EA8
    private static void gmGmkStopperHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)parent_obj;
        int num = 0;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] )
        {
            if ( parent_obj.pos.y > gms_PLAYER_WORK.obj_work.pos.y )
            {
                if ( gms_PLAYER_WORK.obj_work.spd.y >= 0 )
                {
                    num = 1;
                }
            }
            else if ( gms_PLAYER_WORK.obj_work.spd.y <= 0 )
            {
                num = 1;
            }
            if ( num != 0 )
            {
                AppMain.GmPlySeqInitStopper( gms_PLAYER_WORK, gms_GMK_STOPPER_WORK.gmk_work.ene_com );
                gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
                parent_obj.flag |= 2U;
                gms_GMK_STOPPER_WORK.ply_work = gms_PLAYER_WORK;
                parent_obj.user_timer = ( parent_obj.pos.y >> 12 ) + ( int )gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.height + ( int )gms_GMK_STOPPER_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y - ( int )gms_PLAYER_WORK.rect_work[0].rect.top;
                parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkStopperLockWait );
                return;
            }
            mine_rect.flag &= 4294573823U;
        }
    }

    // Token: 0x0600026B RID: 619 RVA: 0x00013DF8 File Offset: 0x00011FF8
    private static void gmGmkStopperExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)p;
        if ( gms_GMK_STOPPER_WORK.se_handle != null )
        {
            AppMain.GsSoundStopSeHandle( gms_GMK_STOPPER_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_STOPPER_WORK.se_handle );
            gms_GMK_STOPPER_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x0600026C RID: 620 RVA: 0x00013E48 File Offset: 0x00012048
    private static AppMain.OBS_OBJECT_WORK GmGmkStopperNormInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_STOPPER_WORK(), "Gmk_StopperRod");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_STOPPER_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_STOPPER_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_stopper_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = 393216;
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 849 ).pData );
        gms_ENEMY_3D_WORK.obj_3d.mat_speed = 1f;
        obs_OBJECT_WORK.disp_flag |= 20U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_STOPPER_WORK.call_slot_id = -1;
        AppMain.gmGmkStopperStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600026D RID: 621 RVA: 0x00013F3C File Offset: 0x0001213C
    private static AppMain.OBS_OBJECT_WORK GmGmkStopperSlotInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_STOPPER_WORK gms_GMK_STOPPER_WORK = (AppMain.GMS_GMK_STOPPER_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_STOPPER_WORK(), "Gmk_StopperRod");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_STOPPER_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_STOPPER_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_stopper_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = 393216;
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, 1, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 849 ).pData );
        gms_ENEMY_3D_WORK.obj_3d.mat_speed = 1f;
        obs_OBJECT_WORK.disp_flag |= 20U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_STOPPER_WORK.call_slot_id = ( int )eve_rec.left;
        AppMain.gmGmkStopperStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600026E RID: 622 RVA: 0x00014023 File Offset: 0x00012223
    private static void GmGmkStopperBuild()
    {
        AppMain.gm_gmk_stopper_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 847 ), AppMain.GmGameDatGetGimmickData( 848 ), 0U );
    }

    // Token: 0x0600026F RID: 623 RVA: 0x00014044 File Offset: 0x00012244
    private static void GmGmkStopperFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(847);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_stopper_obj_3d_list, ams_AMB_HEADER.file_num );
    }
}