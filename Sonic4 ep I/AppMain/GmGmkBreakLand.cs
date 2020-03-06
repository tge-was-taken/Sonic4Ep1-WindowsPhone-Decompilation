using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200039B RID: 923
    public class GMS_GMK_BLAND_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060026E6 RID: 9958 RVA: 0x00150CA8 File Offset: 0x0014EEA8
        public GMS_GMK_BLAND_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060026E7 RID: 9959 RVA: 0x00150CBC File Offset: 0x0014EEBC
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_BLAND_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x060026E8 RID: 9960 RVA: 0x00150CC4 File Offset: 0x0014EEC4
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060026E9 RID: 9961 RVA: 0x00150CD6 File Offset: 0x0014EED6
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BLAND_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0400612E RID: 24878
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x0400612F RID: 24879
        public int broken_timer;

        // Token: 0x04006130 RID: 24880
        public int quake_timer;

        // Token: 0x04006131 RID: 24881
        public ushort vect;

        // Token: 0x04006132 RID: 24882
        public int colrect_left;

        // Token: 0x04006133 RID: 24883
        public int colrect_right;
    }

    // Token: 0x060018A6 RID: 6310 RVA: 0x000E0C74 File Offset: 0x000DEE74
    private static void gmGmkBreakLandStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BLAND_WORK gms_GMK_BLAND_WORK = (AppMain.GMS_GMK_BLAND_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obj_work2 = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].obj_work;
        if ( obj_work2.ride_obj == obj_work )
        {
            int num = obj_work.pos.x + gms_GMK_BLAND_WORK.colrect_left;
            int num2 = obj_work.pos.x + gms_GMK_BLAND_WORK.colrect_right;
            num -= ( int )obj_work2.field_rect[0] << 12;
            num2 -= ( int )obj_work2.field_rect[2] << 12;
            if ( num <= obj_work2.pos.x && obj_work2.pos.x <= num2 )
            {
                int num3 = obj_work2.pos.x - obj_work.pos.x;
                if ( num3 <= ( int )( gms_GMK_BLAND_WORK.gmk_work.ene_com.col_work.obj_col.width * 4096 / 2 ) )
                {
                    ushort num4 = (ushort)-(gms_GMK_BLAND_WORK.gmk_work.ene_com.col_work.obj_col.width * 4096 / 2);
                }
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctZoneEsCreate(null, 0, 0);
                obs_OBJECT_WORK.pos.x = obj_work.pos.x;
                obs_OBJECT_WORK.pos.y = obj_work.pos.y;
                obs_OBJECT_WORK.pos.z = obj_work.pos.z + 131072;
                if ( gms_GMK_BLAND_WORK.vect == 0 )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + 262144;
                }
                else
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x - 262144;
                }
                gms_GMK_BLAND_WORK.broken_timer = 45;
                gms_GMK_BLAND_WORK.quake_timer = 0;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakLandStay_100 );
            }
        }
    }

    // Token: 0x060018A7 RID: 6311 RVA: 0x000E0E28 File Offset: 0x000DF028
    private static void gmGmkBreakLandStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BLAND_WORK gms_GMK_BLAND_WORK = (AppMain.GMS_GMK_BLAND_WORK)obj_work;
        gms_GMK_BLAND_WORK.broken_timer--;
        if ( gms_GMK_BLAND_WORK.broken_timer <= 0 )
        {
            AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
            AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_breakland_obj_3d_list[( gms_GMK_BLAND_WORK.vect == 0 ) ? 2 : 3], gms_GMK_BLAND_WORK.gmk_work.obj_3d );
            AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, AppMain.ObjDataGet( 796 ), null, 0, null );
            if ( gms_GMK_BLAND_WORK.vect == 32768 )
            {
                AppMain.ObjDrawObjectActionSet( obj_work, 0 );
                obj_work.obj_3d.use_light_flag &= 4294967294U;
                obj_work.obj_3d.use_light_flag |= 4U;
                obj_work.obj_3d.use_light_flag |= 65536U;
            }
            else
            {
                AppMain.ObjDrawObjectActionSet( obj_work, 1 );
                obj_work.obj_3d.use_light_flag &= 4294967294U;
                obj_work.obj_3d.use_light_flag |= 2U;
                obj_work.obj_3d.use_light_flag |= 65536U;
            }
            obj_work.disp_flag &= 4294967279U;
            obj_work.disp_flag &= 4294967291U;
            gms_GMK_BLAND_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
            AppMain.GmSoundPlaySE( "BreakGround" );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakLandBroken );
            return;
        }
        gms_GMK_BLAND_WORK.quake_timer &= 3;
        obj_work.pos.y = obj_work.pos.y + ( int )AppMain.tbl_breaklandquake[gms_GMK_BLAND_WORK.quake_timer] * 4096;
        gms_GMK_BLAND_WORK.quake_timer++;
    }

    // Token: 0x060018A8 RID: 6312 RVA: 0x000E0FC3 File Offset: 0x000DF1C3
    private static void gmGmkBreakLandBroken( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 8U;
        }
    }

    // Token: 0x060018A9 RID: 6313 RVA: 0x000E0FE4 File Offset: 0x000DF1E4
    private static AppMain.OBS_OBJECT_WORK gmGmkBreakLandInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, ushort vect )
    {
        AppMain.GMS_GMK_BLAND_WORK gms_GMK_BLAND_WORK = (AppMain.GMS_GMK_BLAND_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BLAND_WORK(), "GMK_BREAK_LAND_MAIN");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BLAND_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_BLAND_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_breakland_obj_3d_list[( vect == 0 ) ? 0 : 1], gms_ENEMY_3D_WORK.obj_3d );
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 32U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 65536U;
        }
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.diff_data = AppMain.g_gm_breakland_col;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = ( ushort )AppMain.gm_gmk_breakland_col_rect_tbl[0];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = ( ushort )AppMain.gm_gmk_breakland_col_rect_tbl[1];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = AppMain.gm_gmk_breakland_col_rect_tbl[2];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = AppMain.gm_gmk_breakland_col_rect_tbl[3];
        gms_GMK_BLAND_WORK.colrect_left = 278528;
        gms_GMK_BLAND_WORK.colrect_right = 524288;
        if ( vect == 32768 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x - ( short )gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width );
            gms_GMK_BLAND_WORK.colrect_right = -278528;
            gms_GMK_BLAND_WORK.colrect_left = -524288;
        }
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 268435456U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.dir = 0;
        if ( ( eve_rec.flag & 128 ) == 0 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.attr = 1;
        }
        obs_OBJECT_WORK.pos.z = -4096;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 272629760U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakLandStay );
        gms_GMK_BLAND_WORK.vect = vect;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060018AA RID: 6314 RVA: 0x000E1294 File Offset: 0x000DF494
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakLandRInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        return AppMain.gmGmkBreakLandInit( eve_rec, pos_x, pos_y, type, 0 );
    }

    // Token: 0x060018AB RID: 6315 RVA: 0x000E12A0 File Offset: 0x000DF4A0
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakLandLInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        return AppMain.gmGmkBreakLandInit( eve_rec, pos_x, pos_y, type, 32768 );
    }

    // Token: 0x060018AC RID: 6316 RVA: 0x000E12B0 File Offset: 0x000DF4B0
    private static void GmGmkBreakLandBuild()
    {
        AppMain.gm_gmk_breakland_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 794 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 795 ) ), 0U );
    }

    // Token: 0x060018AD RID: 6317 RVA: 0x000E12DC File Offset: 0x000DF4DC
    private static void GmGmkBreakLandFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(794));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_breakland_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060018AE RID: 6318 RVA: 0x000E130C File Offset: 0x000DF50C
    private static void GmGmkBreakLandSetLight()
    {
        AppMain.NNS_RGBA nns_RGBA = default(AppMain.NNS_RGBA);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = -0.5f;
        nns_VECTOR.y = -0.05f;
        nns_VECTOR.z = -1f;
        nns_RGBA.r = 0.65f;
        nns_RGBA.g = 0.65f;
        nns_RGBA.b = 0.65f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_1, ref nns_RGBA, 1f, nns_VECTOR );
        nns_VECTOR.x = 0.4f;
        nns_VECTOR.y = -0.05f;
        nns_VECTOR.z = -1f;
        nns_RGBA.r = 0.65f;
        nns_RGBA.g = 0.65f;
        nns_RGBA.b = 0.65f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_2, ref nns_RGBA, 1f, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }
}
