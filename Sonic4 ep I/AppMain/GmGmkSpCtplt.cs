using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000071 RID: 113
    private static class gmGmkSPCtpltConstants
    {
        // Token: 0x0400496F RID: 18799
        public const int GME_GMK_RECT_DATA_COL_WIDTH = 0;

        // Token: 0x04004970 RID: 18800
        public const int GME_GMK_RECT_DATA_COL_HEIGHT = 1;

        // Token: 0x04004971 RID: 18801
        public const int GME_GMK_RECT_DATA_COL_OFST_X = 2;

        // Token: 0x04004972 RID: 18802
        public const int GME_GMK_RECT_DATA_COL_OFST_Y = 3;

        // Token: 0x04004973 RID: 18803
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 0;

        // Token: 0x04004974 RID: 18804
        public const int GME_GMK_RECT_DATA_DEF_TOP = 1;

        // Token: 0x04004975 RID: 18805
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 2;

        // Token: 0x04004976 RID: 18806
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 3;

        // Token: 0x04004977 RID: 18807
        public const int GME_GMK_RECT_DATA_MAX = 4;
    }

    // Token: 0x02000072 RID: 114
    public class GMS_GMK_SPCTPLT_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E21 RID: 7713 RVA: 0x00139622 File Offset: 0x00137822
        public GMS_GMK_SPCTPLT_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001E22 RID: 7714 RVA: 0x00139636 File Offset: 0x00137836
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_SPCTPLT_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x06001E23 RID: 7715 RVA: 0x0013963E File Offset: 0x0013783E
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SPCTPLT_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001E24 RID: 7716 RVA: 0x00139650 File Offset: 0x00137850
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004978 RID: 18808
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004979 RID: 18809
        public ushort ctplt_id;

        // Token: 0x0400497A RID: 18810
        public ushort ctplt_tilt;

        // Token: 0x0400497B RID: 18811
        public int ctplt_return_timer;

        // Token: 0x0400497C RID: 18812
        public int ctplt_height;

        // Token: 0x0400497D RID: 18813
        public AppMain.GMS_PLAYER_WORK ply_work;

        // Token: 0x0400497E RID: 18814
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x06000270 RID: 624 RVA: 0x0001406C File Offset: 0x0001226C
    private static void gmGmkSpCtpltStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)obj_work;
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, AppMain.ObjDataGet( 885 ), null, 0, null );
        AppMain.ObjDrawObjectActionSet( obj_work, 0 );
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, 0, AppMain.ObjDataGet( 886 ), null, 0, null );
        obj_work.obj_3d.mat_speed = 1f;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 1 );
        obj_work.disp_flag &= 4294967291U;
        ( ( AppMain.NNS_MATERIAL_GLES11_DESC )obj_work.obj_3d._object.pMatPtrList[0].pMaterial ).fFlag |= 1U;
        ( ( AppMain.NNS_MATERIAL_GLES11_DESC )obj_work.obj_3d._object.pMatPtrList[1].pMaterial ).fFlag |= 1U;
        gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = null;
        obs_RECT_WORK.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSpCtplt_PlayerHit );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_spctplt_rect[( int )gms_GMK_SPCTPLT_WORK.ctplt_id][0], AppMain.tbl_gm_gmk_spctplt_rect[( int )gms_GMK_SPCTPLT_WORK.ctplt_id][1], AppMain.tbl_gm_gmk_spctplt_rect[( int )gms_GMK_SPCTPLT_WORK.ctplt_id][2], AppMain.tbl_gm_gmk_spctplt_rect[( int )gms_GMK_SPCTPLT_WORK.ctplt_id][3] );
        obj_work.flag &= 4294967293U;
        obj_work.dir.z = gms_GMK_SPCTPLT_WORK.ctplt_tilt;
        gms_GMK_SPCTPLT_WORK.ply_work = null;
        gms_GMK_SPCTPLT_WORK.ctplt_height = 319488;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpCtpltStay );
    }

    // Token: 0x06000271 RID: 625 RVA: 0x000141F8 File Offset: 0x000123F8
    private static void gmGmkSpCtpltStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_GMK_SPCTPLT_WORK.ply_work == gms_PLAYER_WORK )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpCtplt_PlayerHold );
            AppMain.gmGmkSpCtplt_PlayerHold( obj_work );
        }
    }

    // Token: 0x06000272 RID: 626 RVA: 0x0001423C File Offset: 0x0001243C
    private static void gmGmkSpCtplt_PlayerHold( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK ply_work = gms_GMK_SPCTPLT_WORK.ply_work;
        if ( ( ply_work.player_flag & 1024U ) != 0U || ( AppMain.g_gm_main_system.game_flag & 262656U ) != 0U )
        {
            return;
        }
        if ( ( AppMain.g_gm_main_system.game_flag & 16781312U ) == 0U )
        {
            if ( ( ply_work.key_release & 160 ) != 0 )
            {
                int num = 0;
                int num2 = (319488 - gms_GMK_SPCTPLT_WORK.ctplt_height) / 2;
                ply_work.obj_work.spd_m = num2;
                if ( gms_GMK_SPCTPLT_WORK.ctplt_tilt != 0 )
                {
                    num2 = ( num = ( int )( 2896.3093 * ( double )num2 / 4096.0 ) );
                    if ( gms_GMK_SPCTPLT_WORK.ctplt_tilt == 57344 )
                    {
                        num = -num;
                    }
                }
                else if ( num2 < 8192 )
                {
                    num2 = 8192;
                }
                else if ( num2 > 36864 )
                {
                    num2 = 36864 + 9 * num2 / 21;
                }
                AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 1 );
                obj_work.disp_flag &= 4294967291U;
                AppMain.ObjDrawObjectActionSet( obj_work, 2 );
                gms_GMK_SPCTPLT_WORK.ctplt_height = 319488;
                ply_work.obj_work.dir.z = ( ushort )( gms_GMK_SPCTPLT_WORK.ctplt_tilt + 49152 );
                AppMain.GmPlySeqInitPinballCtplt( ply_work, num, -num2 );
                AppMain.GMM_PAD_VIB_SMALL();
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpCtplt_PlayerHold_100 );
                gms_GMK_SPCTPLT_WORK.ctplt_return_timer = 4;
                gms_GMK_SPCTPLT_WORK.ply_work = null;
                AppMain.gmGmkSpCtpltSeStop( obj_work );
            }
            else if ( ( ply_work.key_on & 160 ) != 0 )
            {
                if ( gms_GMK_SPCTPLT_WORK.ctplt_height == 319488 )
                {
                    AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
                    obj_work.disp_flag &= 4294967291U;
                    AppMain.ObjDrawObjectActionSet( obj_work, 1 );
                    gms_GMK_SPCTPLT_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
                    AppMain.GmSoundPlaySE( "Catapult1", gms_GMK_SPCTPLT_WORK.se_handle );
                }
                if ( gms_GMK_SPCTPLT_WORK.ctplt_height > 147456 )
                {
                    gms_GMK_SPCTPLT_WORK.ctplt_height -= 3018;
                    if ( gms_GMK_SPCTPLT_WORK.ctplt_height < 147456 )
                    {
                        gms_GMK_SPCTPLT_WORK.ctplt_height = 147456;
                    }
                }
            }
        }
        int num3;
        int num4;
        if ( gms_GMK_SPCTPLT_WORK.ctplt_tilt == 0 )
        {
            num3 = 0;
            num4 = -gms_GMK_SPCTPLT_WORK.ctplt_height;
        }
        else
        {
            num4 = ( num3 = -( int )( 2896.3093 * ( double )gms_GMK_SPCTPLT_WORK.ctplt_height / 4096.0 ) );
            if ( gms_GMK_SPCTPLT_WORK.ctplt_tilt == 8192 )
            {
                num3 = -num3;
            }
        }
        ply_work.obj_work.pos.x = obj_work.pos.x + num3;
        ply_work.obj_work.pos.y = obj_work.pos.y + num4;
    }

    // Token: 0x06000273 RID: 627 RVA: 0x000144AC File Offset: 0x000126AC
    private static void gmGmkSpCtplt_PlayerHold_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)obj_work;
        gms_GMK_SPCTPLT_WORK.ctplt_return_timer--;
        if ( gms_GMK_SPCTPLT_WORK.ctplt_return_timer <= 0 )
        {
            obj_work.flag &= 4294967293U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpCtpltStay );
            AppMain.gmGmkSpCtpltStay( obj_work );
        }
    }

    // Token: 0x06000274 RID: 628 RVA: 0x00014500 File Offset: 0x00012700
    private static void gmGmkSpCtplt_PlayerHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || ( gms_PLAYER_WORK.obj_work.flag & 2U ) != 0U || ( AppMain.g_gm_main_system.game_flag & 262656U ) != 0U )
        {
            return;
        }
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] )
        {
            AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)parent_obj;
            AppMain.GmPlySeqInitPinballCtpltHold( gms_PLAYER_WORK, gms_GMK_SPCTPLT_WORK.gmk_work.ene_com );
            gms_PLAYER_WORK.obj_work.flag |= 2U;
            parent_obj.flag |= 2U;
            gms_GMK_SPCTPLT_WORK.ply_work = gms_PLAYER_WORK;
        }
    }

    // Token: 0x06000275 RID: 629 RVA: 0x000145A0 File Offset: 0x000127A0
    private static void gmGmkSpCtpltSeStop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)obj_work;
        if ( gms_GMK_SPCTPLT_WORK.se_handle != null )
        {
            AppMain.GsSoundStopSeHandle( gms_GMK_SPCTPLT_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_SPCTPLT_WORK.se_handle );
            gms_GMK_SPCTPLT_WORK.se_handle = null;
        }
    }

    // Token: 0x06000276 RID: 630 RVA: 0x000145DC File Offset: 0x000127DC
    private static void gmGmkSpCtpltExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmGmkSpCtpltSeStop( obj_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000277 RID: 631 RVA: 0x00014604 File Offset: 0x00012804
    private static AppMain.OBS_OBJECT_WORK gmGmkSpCtpltInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SPCTPLT_WORK(), "Gmk_Seesaw");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_SPCTPLT_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_SPCTPLT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_spctplt_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -4096;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkSpCtpltExit ) );
        gms_GMK_SPCTPLT_WORK.se_handle = null;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000278 RID: 632 RVA: 0x000146C0 File Offset: 0x000128C0
    private static AppMain.OBS_OBJECT_WORK GmGmkSpCtplt0Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)AppMain.gmGmkSpCtpltInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPCTPLT_WORK.ctplt_tilt = 0;
        gms_GMK_SPCTPLT_WORK.ctplt_id = 0;
        AppMain.gmGmkSpCtpltStart( gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x06000279 RID: 633 RVA: 0x00014710 File Offset: 0x00012910
    private static AppMain.OBS_OBJECT_WORK GmGmkSpCtplt45Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)AppMain.gmGmkSpCtpltInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPCTPLT_WORK.ctplt_tilt = 8192;
        gms_GMK_SPCTPLT_WORK.ctplt_id = 1;
        AppMain.gmGmkSpCtpltStart( gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x0600027A RID: 634 RVA: 0x00014764 File Offset: 0x00012964
    private static AppMain.OBS_OBJECT_WORK GmGmkSpCtplt315Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPCTPLT_WORK gms_GMK_SPCTPLT_WORK = (AppMain.GMS_GMK_SPCTPLT_WORK)AppMain.gmGmkSpCtpltInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPCTPLT_WORK.ctplt_tilt = 57344;
        gms_GMK_SPCTPLT_WORK.ctplt_id = 2;
        AppMain.gmGmkSpCtpltStart( gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_SPCTPLT_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x0600027B RID: 635 RVA: 0x000147B7 File Offset: 0x000129B7
    private static void GmGmkSpCtpltBuild()
    {
        AppMain.gm_gmk_spctplt_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 883 ), AppMain.GmGameDatGetGimmickData( 884 ), 0U );
    }

    // Token: 0x0600027C RID: 636 RVA: 0x000147D8 File Offset: 0x000129D8
    private static void GmGmkSpCtpltFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(883);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_spctplt_obj_3d_list, ams_AMB_HEADER.file_num );
    }

}