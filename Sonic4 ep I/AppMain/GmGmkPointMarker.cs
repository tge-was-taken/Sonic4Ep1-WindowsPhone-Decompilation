using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000202 RID: 514
    public class GMS_GMK_PMARKER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002344 RID: 9028 RVA: 0x00148780 File Offset: 0x00146980
        public GMS_GMK_PMARKER_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002345 RID: 9029 RVA: 0x00148794 File Offset: 0x00146994
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x170000AA RID: 170
        // (get) Token: 0x06002346 RID: 9030 RVA: 0x001487A6 File Offset: 0x001469A6
        public AppMain.OBS_ACTION3D_NN_WORK OBJ_3D
        {
            get
            {
                return this.gmk_work.obj_3d;
            }
        }

        // Token: 0x170000AB RID: 171
        // (get) Token: 0x06002347 RID: 9031 RVA: 0x001487B3 File Offset: 0x001469B3
        public AppMain.GMS_ENEMY_COM_WORK COMWORK
        {
            get
            {
                return this.gmk_work.ene_com;
            }
        }

        // Token: 0x170000AC RID: 172
        // (get) Token: 0x06002348 RID: 9032 RVA: 0x001487C0 File Offset: 0x001469C0
        public AppMain.OBS_OBJECT_WORK OBJWORK
        {
            get
            {
                return this.COMWORK.obj_work;
            }
        }

        // Token: 0x040055E3 RID: 21987
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x040055E4 RID: 21988
        public int markerdist;

        // Token: 0x040055E5 RID: 21989
        public int markerdistlast;

        // Token: 0x040055E6 RID: 21990
        public int hitcounter;

        // Token: 0x040055E7 RID: 21991
        public ushort marker_prty;
    }

    // Token: 0x06000B2C RID: 2860 RVA: 0x00064D60 File Offset: 0x00062F60
    private static AppMain.OBS_OBJECT_WORK GmGmkPointMarkerInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        if ( AppMain.g_gs_main_sys_info.game_mode == 1 )
        {
            eve_rec.pos_x = byte.MaxValue;
            return null;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_PMARKER_WORK(), "GMK_POINT_MARKER");
        AppMain.GMS_GMK_PMARKER_WORK gms_GMK_PMARKER_WORK = (AppMain.GMS_GMK_PMARKER_WORK)obs_OBJECT_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + 4096;
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            obs_OBJECT_WORK.pos.z = -131072;
        }
        else
        {
            obs_OBJECT_WORK.pos.z = -65536;
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_PMARKER_WORK.marker_prty = ( ushort )eve_rec.left;
        AppMain.gmGmkPointMarkerStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B2D RID: 2861 RVA: 0x00064E38 File Offset: 0x00063038
    public static void GmGmkPointMarkerBuild()
    {
        AppMain.gm_gmk_pmarker_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 838 ), AppMain.GmGameDatGetGimmickData( 839 ), 0U );
    }

    // Token: 0x06000B2E RID: 2862 RVA: 0x00064E5C File Offset: 0x0006305C
    public static void GmGmkPointMarkerFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(838));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_pmarker_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000B2F RID: 2863 RVA: 0x00064E8C File Offset: 0x0006308C
    private static void gmGmkPointMarkerHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_GMK_PMARKER_WORK gms_GMK_PMARKER_WORK = (AppMain.GMS_GMK_PMARKER_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        gms_GMK_PMARKER_WORK.markerdist = gms_GMK_PMARKER_WORK.OBJWORK.pos.x - gms_PLAYER_WORK.obj_work.pos.x;
        if ( ( gms_GMK_PMARKER_WORK.markerdist <= 16384 && gms_GMK_PMARKER_WORK.markerdist >= -16384 ) || ( gms_GMK_PMARKER_WORK.markerdist < 16384 && gms_GMK_PMARKER_WORK.markerdistlast >= 16384 ) || ( gms_GMK_PMARKER_WORK.markerdist > -16384 && gms_GMK_PMARKER_WORK.markerdistlast <= -16384 ) )
        {
            if ( AppMain.g_gm_main_system.marker_pri < ( uint )gms_GMK_PMARKER_WORK.marker_prty )
            {
                AppMain.GmPlayerSetMarkerPoint( gms_PLAYER_WORK, gms_GMK_PMARKER_WORK.OBJWORK.pos.x, gms_GMK_PMARKER_WORK.OBJWORK.pos.y );
                AppMain.g_gm_main_system.marker_pri = ( uint )gms_GMK_PMARKER_WORK.marker_prty;
                gms_GMK_PMARKER_WORK.marker_prty = 0;
                gms_GMK_PMARKER_WORK.hitcounter = 2;
                SaveState.saveCurrentState( 1 );
            }
            gms_GMK_PMARKER_WORK.OBJWORK.flag |= 2U;
            return;
        }
        mine_rect.flag &= 4294573823U;
    }

    // Token: 0x06000B30 RID: 2864 RVA: 0x00064FA8 File Offset: 0x000631A8
    private static void gmGmkPointMarkerStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PMARKER_WORK gms_GMK_PMARKER_WORK = (AppMain.GMS_GMK_PMARKER_WORK)obj_work;
        AppMain.ObjDrawObjectActionSet( obj_work, 0 );
        gms_GMK_PMARKER_WORK.markerdist = 0;
        gms_GMK_PMARKER_WORK.hitcounter = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPointMarkerStay_100 );
    }

    // Token: 0x06000B31 RID: 2865 RVA: 0x00064FE4 File Offset: 0x000631E4
    private static void gmGmkPointMarkerStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PMARKER_WORK gms_GMK_PMARKER_WORK = (AppMain.GMS_GMK_PMARKER_WORK)obj_work;
        gms_GMK_PMARKER_WORK.markerdistlast = gms_GMK_PMARKER_WORK.markerdist;
        gms_GMK_PMARKER_WORK.markerdist = 0;
        if ( gms_GMK_PMARKER_WORK.hitcounter > 0 )
        {
            AppMain.GmSoundPlaySE( "Marker" );
            AppMain.gmGmkPointMarkerStay_200( obj_work );
            return;
        }
        if ( AppMain.g_gm_main_system.marker_pri >= ( uint )gms_GMK_PMARKER_WORK.marker_prty )
        {
            gms_GMK_PMARKER_WORK.marker_prty = 0;
            AppMain.gmGmkPointMarkerStay_400( obj_work );
        }
    }

    // Token: 0x06000B32 RID: 2866 RVA: 0x00065044 File Offset: 0x00063244
    private static void gmGmkPointMarkerStay_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet( obj_work, 1 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPointMarkerStay_210 );
    }

    // Token: 0x06000B33 RID: 2867 RVA: 0x00065060 File Offset: 0x00063260
    private static void gmGmkPointMarkerStay_210( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PMARKER_WORK gms_GMK_PMARKER_WORK = (AppMain.GMS_GMK_PMARKER_WORK)obj_work;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            gms_GMK_PMARKER_WORK.hitcounter--;
            if ( gms_GMK_PMARKER_WORK.hitcounter == 0 )
            {
                AppMain.ObjDrawObjectActionSet( obj_work, 0 );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPointMarkerStay_300 );
                return;
            }
            AppMain.gmGmkPointMarkerStay_200( obj_work );
        }
    }

    // Token: 0x06000B34 RID: 2868 RVA: 0x000650B4 File Offset: 0x000632B4
    private static void gmGmkPointMarkerStay_300( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.gmGmkPointMarkerStay_400( obj_work );
        }
    }

    // Token: 0x06000B35 RID: 2869 RVA: 0x000650C8 File Offset: 0x000632C8
    private static void gmGmkPointMarkerStay_400( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(obj_work, 49);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 34f, 0f );
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = obj_work.pos.z + 40960;
        }
        else
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = obj_work.pos.z + 65536;
        }
        AppMain.ObjAction3dNNMaterialMotionLoad( obj_work.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 841 ).pData );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        obj_work.obj_3d.mat_speed = 1f;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = null;
    }

    // Token: 0x06000B36 RID: 2870 RVA: 0x000651A0 File Offset: 0x000633A0
    private static void gmGmkPointMarkerStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PMARKER_WORK gms_GMK_PMARKER_WORK = (AppMain.GMS_GMK_PMARKER_WORK)obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_pmarker_obj_3d_list[0], gms_GMK_PMARKER_WORK.OBJ_3D );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, AppMain.ObjDataGet( 840 ), null, 0, null );
        AppMain.ObjDrawObjectActionSet( obj_work, 0 );
        if ( AppMain.g_gm_main_system.marker_pri < ( uint )gms_GMK_PMARKER_WORK.marker_prty )
        {
            gms_GMK_PMARKER_WORK.COMWORK.rect_work[0].flag &= 4294967291U;
            gms_GMK_PMARKER_WORK.COMWORK.rect_work[1].flag &= 4294967291U;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_PMARKER_WORK.COMWORK.rect_work[2];
            obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkPointMarkerHit );
            obs_RECT_WORK.ppHit = null;
            AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
            AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -64, 16, 0 );
        }
        else
        {
            gms_GMK_PMARKER_WORK.marker_prty = 0;
        }
        AppMain.gmGmkPointMarkerStay( obj_work );
    }
}