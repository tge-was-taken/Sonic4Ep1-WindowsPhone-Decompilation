using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x020001B3 RID: 435
    public static class gmGmkBreakObjConstants
    {
        // Token: 0x04004FC1 RID: 20417
        public const int GME_GMK_RECT_DATA_COL_WIDTH = 0;

        // Token: 0x04004FC2 RID: 20418
        public const int GME_GMK_RECT_DATA_COL_HEIGHT = 1;

        // Token: 0x04004FC3 RID: 20419
        public const int GME_GMK_RECT_DATA_COL_OFST_X = 2;

        // Token: 0x04004FC4 RID: 20420
        public const int GME_GMK_RECT_DATA_COL_OFST_Y = 3;

        // Token: 0x04004FC5 RID: 20421
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 4;

        // Token: 0x04004FC6 RID: 20422
        public const int GME_GMK_RECT_DATA_DEF_TOP = 5;

        // Token: 0x04004FC7 RID: 20423
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 6;

        // Token: 0x04004FC8 RID: 20424
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 7;

        // Token: 0x04004FC9 RID: 20425
        public const int GME_GMK_RECT_DATA_MAX = 8;
    }

    // Token: 0x020001B4 RID: 436
    public class GMS_GMK_BOBJ_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002212 RID: 8722 RVA: 0x00142301 File Offset: 0x00140501
        public GMS_GMK_BOBJ_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002213 RID: 8723 RVA: 0x00142315 File Offset: 0x00140515
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06002214 RID: 8724 RVA: 0x00142327 File Offset: 0x00140527
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BOBJ_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06002215 RID: 8725 RVA: 0x00142339 File Offset: 0x00140539
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_BOBJ_WORK work )
        {
            return work.gmk_work;
        }

        // Token: 0x04004FCA RID: 20426
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004FCB RID: 20427
        public int zone_type;

        // Token: 0x04004FCC RID: 20428
        public short breakrect_left;

        // Token: 0x04004FCD RID: 20429
        public short breakrect_right;

        // Token: 0x04004FCE RID: 20430
        public short breakrect_top;

        // Token: 0x04004FCF RID: 20431
        public bool hitpass;

        // Token: 0x04004FD0 RID: 20432
        public short hitcheck;

        // Token: 0x04004FD1 RID: 20433
        public ushort broketype;

        // Token: 0x04004FD2 RID: 20434
        public ushort vect;
    }

    // Token: 0x020001B5 RID: 437
    public class GMS_GMK_BOBJ_PARTS : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002216 RID: 8726 RVA: 0x00142341 File Offset: 0x00140541
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x06002217 RID: 8727 RVA: 0x00142353 File Offset: 0x00140553
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BOBJ_PARTS work )
        {
            return work.eff_work.efct_com.obj_work;
        }

        // Token: 0x06002218 RID: 8728 RVA: 0x00142365 File Offset: 0x00140565
        public GMS_GMK_BOBJ_PARTS()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x04004FD3 RID: 20435
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x04004FD4 RID: 20436
        public short falltimer;
    }

    // Token: 0x020001B6 RID: 438
    private struct tag_GMS_GMK_BOBJ_PARTS_PARAM_TABLE
    {
        // Token: 0x04004FD5 RID: 20437
        public ushort[][] Params;

        // Token: 0x04004FD6 RID: 20438
        public ushort num;
    }

    // Token: 0x060008E0 RID: 2272 RVA: 0x00050F40 File Offset: 0x0004F140
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakObjInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BOBJ_WORK gms_GMK_BOBJ_WORK = (AppMain.GMS_GMK_BOBJ_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BOBJ_WORK(), "GMK_BREAK_LAND_MAIN");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BOBJ_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_BOBJ_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_breakobj_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -4096;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_BOBJ_WORK.zone_type = AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id];
        AppMain.gmGmkBreakObjStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060008E1 RID: 2273 RVA: 0x00050FEF File Offset: 0x0004F1EF
    public static void GmGmkBreakObjBuild()
    {
        AppMain.gm_gmk_breakobj_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 799 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 800 ) ), 0U );
    }

    // Token: 0x060008E2 RID: 2274 RVA: 0x0005101C File Offset: 0x0004F21C
    public static void GmGmkBreakObjFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(799));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_breakobj_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060008E3 RID: 2275 RVA: 0x0005104C File Offset: 0x0004F24C
    public static void gmGmkBreakObjStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOBJ_WORK gms_GMK_BOBJ_WORK = (AppMain.GMS_GMK_BOBJ_WORK)obj_work;
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.width = ( ushort )AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][0];
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.height = ( ushort )AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][1];
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][2];
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][3];
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
        gms_GMK_BOBJ_WORK.breakrect_left = ( short )( gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x - 4 );
        gms_GMK_BOBJ_WORK.breakrect_right = ( short )( gms_GMK_BOBJ_WORK.breakrect_left + ( short )gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.width + 4 );
        gms_GMK_BOBJ_WORK.breakrect_top = ( short )( gms_GMK_BOBJ_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y - 4 );
        gms_GMK_BOBJ_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_BOBJ_WORK.gmk_work.ene_com.rect_work[0];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkBreakObjHit );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][4], AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][5], AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][6], AppMain.tbl_gm_gmk_bobj_col_rect[gms_GMK_BOBJ_WORK.zone_type][7] );
        obs_RECT_WORK = gms_GMK_BOBJ_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = null;
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, gms_GMK_BOBJ_WORK.breakrect_left, gms_GMK_BOBJ_WORK.breakrect_top, gms_GMK_BOBJ_WORK.breakrect_right, 0 );
        gms_GMK_BOBJ_WORK.hitpass = false;
        gms_GMK_BOBJ_WORK.hitcheck = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakObjStay );
    }

    // Token: 0x060008E4 RID: 2276 RVA: 0x000512B8 File Offset: 0x0004F4B8
    public static void gmGmkBreakObjStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOBJ_WORK gms_GMK_BOBJ_WORK = (AppMain.GMS_GMK_BOBJ_WORK)obj_work;
        if ( !gms_GMK_BOBJ_WORK.hitpass && gms_GMK_BOBJ_WORK.hitcheck != 0 )
        {
            AppMain.gmGmkBreakObjStart( obj_work );
        }
        gms_GMK_BOBJ_WORK.hitpass = false;
    }

    // Token: 0x060008E5 RID: 2277 RVA: 0x000512EC File Offset: 0x0004F4EC
    private static void gmGmkBreakObjHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] )
        {
            AppMain.GMS_GMK_BOBJ_WORK gms_GMK_BOBJ_WORK = (AppMain.GMS_GMK_BOBJ_WORK)parent_obj;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_BOBJ_WORK.gmk_work.ene_com.obj_work.rect_work[0];
            if ( gms_PLAYER_WORK.act_state == 39 || gms_PLAYER_WORK.act_state == 31 || ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
            {
                short num3;
                short num2;
                short num = num2 = (num3 = 0);
                ushort vect = 0;
                if ( parent_obj.pos.x >= gms_PLAYER_WORK.obj_work.pos.x )
                {
                    num2 = ( short )( ( parent_obj.pos.x >> 12 ) + ( int )obs_RECT_WORK.rect.left - ( int )match_rect.rect.right );
                    num2 = ( short )( ( gms_PLAYER_WORK.obj_work.pos.x >> 12 ) - ( int )num2 );
                    gms_GMK_BOBJ_WORK.hitcheck = 1;
                }
                else
                {
                    num = ( short )( ( parent_obj.pos.x >> 12 ) + ( int )obs_RECT_WORK.rect.right - ( int )match_rect.rect.left - ( gms_PLAYER_WORK.obj_work.pos.x >> 12 ) );
                    gms_GMK_BOBJ_WORK.hitcheck = 1;
                    vect = 32768;
                }
                if ( parent_obj.pos.y >= gms_PLAYER_WORK.obj_work.pos.y )
                {
                    num3 = ( short )( ( parent_obj.pos.y >> 12 ) + ( int )obs_RECT_WORK.rect.top - ( int )match_rect.rect.bottom );
                    num3 = ( short )( ( gms_PLAYER_WORK.obj_work.pos.y >> 12 ) - ( int )num3 );
                    gms_GMK_BOBJ_WORK.hitcheck = 1;
                }
                if ( obs_RECT_WORK.rect.right > gms_GMK_BOBJ_WORK.breakrect_right )
                {
                    AppMain.OBS_RECT rect = obs_RECT_WORK.rect;
                    rect.right -= num;
                    if ( obs_RECT_WORK.rect.right < gms_GMK_BOBJ_WORK.breakrect_right )
                    {
                        obs_RECT_WORK.rect.right = gms_GMK_BOBJ_WORK.breakrect_right;
                    }
                }
                if ( obs_RECT_WORK.rect.left < gms_GMK_BOBJ_WORK.breakrect_left )
                {
                    AppMain.OBS_RECT rect2 = obs_RECT_WORK.rect;
                    rect2.left += num2;
                    if ( obs_RECT_WORK.rect.left > gms_GMK_BOBJ_WORK.breakrect_left )
                    {
                        obs_RECT_WORK.rect.left = gms_GMK_BOBJ_WORK.breakrect_left;
                    }
                }
                if ( obs_RECT_WORK.rect.top < gms_GMK_BOBJ_WORK.breakrect_top )
                {
                    AppMain.OBS_RECT rect3 = obs_RECT_WORK.rect;
                    rect3.top += num3;
                    if ( obs_RECT_WORK.rect.top > gms_GMK_BOBJ_WORK.breakrect_top )
                    {
                        obs_RECT_WORK.rect.top = gms_GMK_BOBJ_WORK.breakrect_top;
                    }
                }
                gms_GMK_BOBJ_WORK.hitpass = true;
                short num4 = (short)(gms_PLAYER_WORK.obj_work.spd.x >> 12);
                short num5 = (short)(gms_PLAYER_WORK.obj_work.spd.y >> 12);
                if ( ( obs_RECT_WORK.rect.right + num4 <= gms_GMK_BOBJ_WORK.breakrect_right || obs_RECT_WORK.rect.left + num4 >= gms_GMK_BOBJ_WORK.breakrect_left ) && obs_RECT_WORK.rect.top + num5 >= gms_GMK_BOBJ_WORK.breakrect_top )
                {
                    ushort efct_zone_idx = AppMain.tbl_gmk_breakobj_effect[gms_GMK_BOBJ_WORK.zone_type];
                    switch ( gms_GMK_BOBJ_WORK.zone_type )
                    {
                        case 0:
                            if ( AppMain.g_gs_main_sys_info.stage_id == 2 )
                            {
                                efct_zone_idx = 3;
                            }
                            break;
                        case 2:
                            if ( AppMain.g_gm_main_system.water_level != 65535 && ( int )AppMain.g_gm_main_system.water_level < ( parent_obj.pos.y >> 12 ) + ( int )gms_GMK_BOBJ_WORK.breakrect_top )
                            {
                                efct_zone_idx = 11;
                            }
                            break;
                    }
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctZoneEsCreate(null, gms_GMK_BOBJ_WORK.zone_type, (int)efct_zone_idx);
                    obs_OBJECT_WORK.pos.x = parent_obj.pos.x;
                    obs_OBJECT_WORK.pos.y = parent_obj.pos.y;
                    obs_OBJECT_WORK.pos.z = parent_obj.pos.z;
                    AppMain.gmGmkBreakObj_CreateParts( parent_obj, gms_GMK_BOBJ_WORK.zone_type, vect );
                    gms_GMK_BOBJ_WORK.gmk_work.ene_com.obj_work.col_work.obj_col.obj = null;
                    AppMain.GmEnemyDefaultDefFunc( mine_rect, match_rect );
                    AppMain.GmSoundPlaySE( "BreakOBJ" );
                    AppMain.GmPlayerAddScore( gms_PLAYER_WORK, 100, parent_obj.pos.x, parent_obj.pos.y );
                }
            }
        }
    }

    // Token: 0x060008E6 RID: 2278 RVA: 0x00051728 File Offset: 0x0004F928
    public static void gmGmkBreakObj_CreateParts( AppMain.OBS_OBJECT_WORK parent_obj, int type, ushort vect )
    {
        int num = 0;
        for ( int i = 0; i < ( int )AppMain.GMS_GMK_BOBJ_PARTS_PARAM_TABLE[type].num; i++ )
        {
            ushort[] array = AppMain.GMS_GMK_BOBJ_PARTS_PARAM_TABLE[type].Params[num];
            AppMain.GMS_GMK_BOBJ_PARTS gms_GMK_BOBJ_PARTS = (AppMain.GMS_GMK_BOBJ_PARTS)AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_BOBJ_PARTS(), null, 0, "BreakObj_Parts");
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BOBJ_PARTS;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_breakobj_obj_3d_list[( int )array[0]], gms_GMK_BOBJ_PARTS.eff_work.obj_3d );
            ( ( AppMain.NNS_MATERIAL_GLES11_DESC )obs_OBJECT_WORK.obj_3d._object.pMatPtrList[0].pMaterial ).fFlag = 2U;
            obs_OBJECT_WORK.pos.x = parent_obj.pos.x + ( int )( ( short )array[1] * 4096 );
            obs_OBJECT_WORK.pos.y = parent_obj.pos.y - ( int )( ( short )array[2] * 4096 );
            obs_OBJECT_WORK.pos.z = parent_obj.pos.z + 1;
            vect = array[3];
            int num2 = (int)(-(int)array[4]);
            obs_OBJECT_WORK.spd.x = AppMain.mtMathCos( ( int )vect ) * num2 >> 12;
            obs_OBJECT_WORK.spd.y = -( AppMain.mtMathSin( ( int )vect ) * num2 >> 12 );
            obs_OBJECT_WORK.spd_add.y = 1024;
            obs_OBJECT_WORK.dir.x = 0;
            obs_OBJECT_WORK.dir.y = 0;
            obs_OBJECT_WORK.dir.z = vect;
            obs_OBJECT_WORK.move_flag |= 256U;
            obs_OBJECT_WORK.disp_flag |= 4194304U;
            obs_OBJECT_WORK.disp_flag &= 4294967039U;
            obs_OBJECT_WORK.flag |= 2U;
            gms_GMK_BOBJ_PARTS.falltimer = 60;
            num++;
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakObjParts_Main );
        }
    }

    // Token: 0x060008E7 RID: 2279 RVA: 0x00051918 File Offset: 0x0004FB18
    public static void gmGmkBreakObjParts_Main( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BOBJ_PARTS gms_GMK_BOBJ_PARTS = (AppMain.GMS_GMK_BOBJ_PARTS)obj_work;
        obj_work.dir.z = ( ushort )( obj_work.dir.z + 512 );
        AppMain.GMS_GMK_BOBJ_PARTS gms_GMK_BOBJ_PARTS2 = gms_GMK_BOBJ_PARTS;
        gms_GMK_BOBJ_PARTS2.falltimer -= 1;
        if ( gms_GMK_BOBJ_PARTS.falltimer <= 0 )
        {
            obj_work.flag |= 8U;
        }
    }
}
