using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200031B RID: 795
    public static class gmGmkBreakWallConstants
    {
        // Token: 0x04005DAF RID: 23983
        public const int GME_GMK_RECT_DATA_COL_WIDTH = 0;

        // Token: 0x04005DB0 RID: 23984
        public const int GME_GMK_RECT_DATA_COL_HEIGHT = 1;

        // Token: 0x04005DB1 RID: 23985
        public const int GME_GMK_RECT_DATA_COL_OFST_X = 2;

        // Token: 0x04005DB2 RID: 23986
        public const int GME_GMK_RECT_DATA_COL_OFST_Y = 3;

        // Token: 0x04005DB3 RID: 23987
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 4;

        // Token: 0x04005DB4 RID: 23988
        public const int GME_GMK_RECT_DATA_DEF_TOP = 5;

        // Token: 0x04005DB5 RID: 23989
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 6;

        // Token: 0x04005DB6 RID: 23990
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 7;

        // Token: 0x04005DB7 RID: 23991
        public const int GME_GMK_RECT_DATA_MAX = 8;
    }

    // Token: 0x0200031C RID: 796
    public class GMS_GMK_BWALL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002579 RID: 9593 RVA: 0x0014D849 File Offset: 0x0014BA49
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_BWALL_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x0600257A RID: 9594 RVA: 0x0014D851 File Offset: 0x0014BA51
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0600257B RID: 9595 RVA: 0x0014D863 File Offset: 0x0014BA63
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BWALL_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0600257C RID: 9596 RVA: 0x0014D875 File Offset: 0x0014BA75
        public GMS_GMK_BWALL_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x04005DB8 RID: 23992
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04005DB9 RID: 23993
        public int obj_type;

        // Token: 0x04005DBA RID: 23994
        public int wall_type;

        // Token: 0x04005DBB RID: 23995
        public int hitpass;

        // Token: 0x04005DBC RID: 23996
        public short hitcheck;

        // Token: 0x04005DBD RID: 23997
        public ushort broketype;

        // Token: 0x04005DBE RID: 23998
        public ushort vect;
    }

    // Token: 0x0200031D RID: 797
    public class GMS_GMK_BWALL_PARTS : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600257D RID: 9597 RVA: 0x0014D889 File Offset: 0x0014BA89
        public GMS_GMK_BWALL_PARTS()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x0600257E RID: 9598 RVA: 0x0014D89D File Offset: 0x0014BA9D
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x0600257F RID: 9599 RVA: 0x0014D8AF File Offset: 0x0014BAAF
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BWALL_PARTS work )
        {
            return work.eff_work.efct_com.obj_work;
        }

        // Token: 0x04005DBF RID: 23999
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x04005DC0 RID: 24000
        public short falltimer;

        // Token: 0x04005DC1 RID: 24001
        public ushort vect;
    }

    // Token: 0x0200031E RID: 798
    private class GMS_GMK_BWALL_PARTS_PARAM_TABLE
    {
        // Token: 0x06002580 RID: 9600 RVA: 0x0014D8C1 File Offset: 0x0014BAC1
        public GMS_GMK_BWALL_PARTS_PARAM_TABLE( ushort[][] prm, ushort n )
        {
            this._params = prm;
            this.num = n;
        }

        // Token: 0x06002581 RID: 9601 RVA: 0x0014D8D7 File Offset: 0x0014BAD7
        public GMS_GMK_BWALL_PARTS_PARAM_TABLE( ushort[][] prm, int n )
        {
            this._params = prm;
            this.num = ( ushort )n;
        }

        // Token: 0x04005DC2 RID: 24002
        public ushort[][] _params;

        // Token: 0x04005DC3 RID: 24003
        public ushort num;
    }

    // Token: 0x0600158C RID: 5516 RVA: 0x000BB1C4 File Offset: 0x000B93C4
    private static void gmGmkBreakWallStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)obj_work;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.width = ( ushort )AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][0];
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.height = ( ushort )AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][1];
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][2];
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][3];
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_BWALL_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkBreakWallHit );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][4], AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][5], AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][6], AppMain.tbl_gm_gmk_bwall_col_rect[gms_GMK_BWALL_WORK.obj_type][7] );
        gms_GMK_BWALL_WORK.hitpass = 0;
        gms_GMK_BWALL_WORK.hitcheck = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakWallStay );
    }

    // Token: 0x0600158D RID: 5517 RVA: 0x000BB390 File Offset: 0x000B9590
    private static void gmGmkBreakWallStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)obj_work;
        if ( gms_GMK_BWALL_WORK.hitcheck < 0 )
        {
            ushort num = ( ushort )(((gms_GMK_BWALL_WORK.hitcheck & 1) != 0) ? 0 : 32768);
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = null;
            obj_work.flag |= 10U;
            AppMain.GmSoundPlaySE( "BreakWall" );
            AppMain.GMM_PAD_VIB_SMALL();
            AppMain.gmGmkBreakWall_CreateParts( obj_work, gms_GMK_BWALL_WORK.wall_type, gms_GMK_BWALL_WORK.obj_type, num );
            if ( AppMain.gmk_bwall_effect_y > 196608 )
            {
                while ( AppMain.gmk_bwall_effect_y > 65536 )
                {
                    AppMain.gmk_bwall_effect_y -= 53248;
                }
            }
            int z = obj_work.pos.z;
            switch ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] )
            {
                case 0:
                    obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )AppMain.GmEfctZoneEsCreate( null, 0, 8 );
                    break;
                case 1:
                    obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )AppMain.GmEfctZoneEsCreate( null, 1, 1 );
                    break;
                case 2:
                    obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )AppMain.GmEfctZoneEsCreate( null, 2, 33 );
                    if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
                    {
                        z = 655360;
                        obs_OBJECT_WORK.obj_3des.command_state = 15U;
                    }
                    break;
                case 3:
                    obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )AppMain.GmEfctZoneEsCreate( null, 3, 3 );
                    break;
            }
            if ( obs_OBJECT_WORK != null )
            {
                obs_OBJECT_WORK.pos.x = obj_work.pos.x;
                obs_OBJECT_WORK.pos.y = obj_work.pos.y - AppMain.gmk_bwall_effect_y;
                obs_OBJECT_WORK.pos.z = z;
                AppMain.gmk_bwall_effect_y += 126976;
                obs_OBJECT_WORK.dir.z = num;
                obs_OBJECT_WORK.disp_flag &= 4294967039U;
            }
            return;
        }
        if ( gms_GMK_BWALL_WORK.hitpass == 0 && gms_GMK_BWALL_WORK.hitcheck != 0 )
        {
            AppMain.gmGmkBreakWallStart( obj_work );
        }
        gms_GMK_BWALL_WORK.hitpass = 0;
    }

    // Token: 0x0600158E RID: 5518 RVA: 0x000BB54C File Offset: 0x000B974C
    private static void gmGmkBreakWallHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] )
        {
            AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)parent_obj;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_BWALL_WORK.gmk_work.ene_com.rect_work[2];
            switch ( AppMain.GMM_GMK_TYPE_CHECK( gms_GMK_BWALL_WORK.obj_type ) )
            {
                case 0:
                    if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
                    {
                        if ( AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd_m ) < gms_PLAYER_WORK.spd3 && AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd.x ) < gms_PLAYER_WORK.spd3 )
                        {
                            return;
                        }
                    }
                    else if ( gms_PLAYER_WORK.act_state == 30 || gms_PLAYER_WORK.act_state == 29 || gms_PLAYER_WORK.act_state == 26 || gms_PLAYER_WORK.act_state == 27 )
                    {
                        if ( ( ( uint )gms_GMK_BWALL_WORK.broketype & AppMain.GMD_GMK_BWALL_HARD_SPIN_D ) != 0U )
                        {
                            return;
                        }
                        if ( gms_PLAYER_WORK.act_state != 26 && gms_PLAYER_WORK.act_state != 27 )
                        {
                            gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
                            gms_GMK_BWALL_WORK.hitcheck = 1;
                            gms_GMK_BWALL_WORK.hitpass = 1;
                        }
                        else if ( AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd_m ) < AppMain.g_gm_player_parameter[( int )( ( UIntPtr )0 )].spd_max_spin / 4 )
                        {
                            return;
                        }
                    }
                    else if ( gms_PLAYER_WORK.act_state == 39 )
                    {
                        if ( ( ( uint )gms_GMK_BWALL_WORK.broketype & AppMain.GMD_GMK_BWALL_HARD_SPIN_J ) != 0U )
                        {
                            return;
                        }
                    }
                    else
                    {
                        if ( gms_PLAYER_WORK.act_state != 22 && gms_PLAYER_WORK.act_state != 22 && gms_PLAYER_WORK.act_state != 21 )
                        {
                            break;
                        }
                        if ( ( ( uint )gms_GMK_BWALL_WORK.broketype & AppMain.GMD_GMK_BWALL_HARD_DASH ) != 0U )
                        {
                            return;
                        }
                    }
                    if ( AppMain.GMM_GMK_TYPE_IS_VECT( gms_GMK_BWALL_WORK.obj_type ) != 0 )
                    {
                        if ( parent_obj.pos.x >= gms_PLAYER_WORK.obj_work.pos.x )
                        {
                            short num = (short)((parent_obj.pos.x >> 12) + (int)obs_RECT_WORK.rect.left - (int)match_rect.rect.right);
                            num = ( short )( ( gms_PLAYER_WORK.obj_work.pos.x >> 12 ) - ( int )num );
                            AppMain.OBS_RECT rect = obs_RECT_WORK.rect;
                            rect.left += num;
                            gms_GMK_BWALL_WORK.hitcheck = AppMain.GMD_GMK_BWALL_HIT_LEFT;
                        }
                        else
                        {
                            short num2 = (short)((parent_obj.pos.x >> 12) + (int)obs_RECT_WORK.rect.right - (int)match_rect.rect.left - (gms_PLAYER_WORK.obj_work.pos.x >> 12));
                            AppMain.OBS_RECT rect2 = obs_RECT_WORK.rect;
                            rect2.right -= num2;
                            gms_GMK_BWALL_WORK.hitcheck = AppMain.GMD_GMK_BWALL_HIT_RIGHT;
                        }
                        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
                        gms_GMK_BWALL_WORK.hitpass = 1;
                        if ( obs_RECT_WORK.rect.left >= -16 || obs_RECT_WORK.rect.right <= 16 )
                        {
                            gms_GMK_BWALL_WORK.hitcheck = ( short )-gms_GMK_BWALL_WORK.hitcheck;
                            return;
                        }
                    }
                    else
                    {
                        if ( parent_obj.pos.y >= gms_PLAYER_WORK.obj_work.pos.y )
                        {
                            short num3 = (short)((parent_obj.pos.y >> 12) + (int)obs_RECT_WORK.rect.top - (int)match_rect.rect.bottom);
                            num3 = ( short )( ( gms_PLAYER_WORK.obj_work.pos.y >> 12 ) - ( int )num3 );
                            AppMain.OBS_RECT rect3 = obs_RECT_WORK.rect;
                            rect3.top += num3;
                            gms_GMK_BWALL_WORK.hitcheck = AppMain.GMD_GMK_BFLOOR_HIT_TOP;
                        }
                        else
                        {
                            short num4 = (short)((parent_obj.pos.y >> 12) + (int)obs_RECT_WORK.rect.bottom - (int)match_rect.rect.top);
                            num4 -= ( short )( gms_PLAYER_WORK.obj_work.pos.y >> 12 );
                            AppMain.OBS_RECT rect4 = obs_RECT_WORK.rect;
                            rect4.bottom -= num4;
                            gms_GMK_BWALL_WORK.hitcheck = AppMain.GMD_GMK_BFLOOR_HIT_BOTTOM;
                        }
                        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
                        gms_GMK_BWALL_WORK.hitpass = 1;
                        if ( obs_RECT_WORK.rect.top >= -16 || obs_RECT_WORK.rect.bottom <= 16 )
                        {
                            gms_GMK_BWALL_WORK.hitcheck = ( short )-gms_GMK_BWALL_WORK.hitcheck;
                            return;
                        }
                    }
                    break;
                case 1:
                    if ( ( ( uint )gms_GMK_BWALL_WORK.broketype & AppMain.GMD_GMK_BFLOOR_HARD_CANNON ) == 0U || gms_PLAYER_WORK.act_state == 67 )
                    {
                        if ( ( ( uint )gms_GMK_BWALL_WORK.broketype & AppMain.GMD_GMK_BFLOOR_HARD_CANNON ) != 0U && gms_PLAYER_WORK.act_state == 67 && gms_PLAYER_WORK.obj_work.spd.y > 0 )
                        {
                            return;
                        }
                        if ( ( gms_PLAYER_WORK.act_state == 39 || ( ( uint )gms_GMK_BWALL_WORK.broketype & AppMain.GMD_GMK_BFLOOR_HARD_CANNON ) != 0U ) && ( gms_PLAYER_WORK.obj_work.pos.y > parent_obj.pos.y || gms_PLAYER_WORK.obj_work.spd.y > 0 ) )
                        {
                            if ( gms_PLAYER_WORK.obj_work.pos.y >= parent_obj.pos.y && gms_PLAYER_WORK.obj_work.spd.y >= 0 )
                            {
                                return;
                            }
                            if ( parent_obj.pos.y >= gms_PLAYER_WORK.obj_work.pos.y )
                            {
                                short num5 = (short)((parent_obj.pos.y >> 12) + (int)obs_RECT_WORK.rect.top - (int)match_rect.rect.bottom);
                                num5 = ( short )( ( gms_PLAYER_WORK.obj_work.pos.y >> 12 ) - ( int )num5 );
                                AppMain.OBS_RECT rect5 = obs_RECT_WORK.rect;
                                rect5.top += num5;
                                gms_GMK_BWALL_WORK.hitcheck = AppMain.GMD_GMK_BFLOOR_HIT_TOP;
                            }
                            else
                            {
                                short num6 = (short)((parent_obj.pos.y >> 12) + (int)obs_RECT_WORK.rect.bottom - (int)match_rect.rect.top);
                                num6 -= ( short )( gms_PLAYER_WORK.obj_work.pos.y >> 12 );
                                AppMain.OBS_RECT rect6 = obs_RECT_WORK.rect;
                                rect6.bottom -= num6;
                                gms_GMK_BWALL_WORK.hitcheck = AppMain.GMD_GMK_BFLOOR_HIT_BOTTOM;
                            }
                            gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
                            gms_GMK_BWALL_WORK.hitpass = 1;
                            if ( obs_RECT_WORK.rect.top >= -16 || obs_RECT_WORK.rect.bottom <= 16 )
                            {
                                gms_GMK_BWALL_WORK.hitcheck = ( short )-gms_GMK_BWALL_WORK.hitcheck;
                            }
                        }
                    }
                    break;
                default:
                    return;
            }
        }
    }

    // Token: 0x0600158F RID: 5519 RVA: 0x000BBB54 File Offset: 0x000B9D54
    private static void gmGmkBreakLandParts_Main( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BWALL_PARTS gms_GMK_BWALL_PARTS = (AppMain.GMS_GMK_BWALL_PARTS)obj_work;
        if ( gms_GMK_BWALL_PARTS.vect > 32768 )
        {
            obj_work.dir.x = ( ushort )( obj_work.dir.x + 1024 );
            obj_work.dir.y = ( ushort )( obj_work.dir.y + 768 );
        }
        else
        {
            obj_work.dir.x = ( ushort )( obj_work.dir.x - 1024 );
            obj_work.dir.y = ( ushort )( obj_work.dir.y - 768 );
        }
        AppMain.GMS_GMK_BWALL_PARTS gms_GMK_BWALL_PARTS2 = gms_GMK_BWALL_PARTS;
        gms_GMK_BWALL_PARTS2.falltimer -= 1;
        if ( gms_GMK_BWALL_PARTS.falltimer <= 0 )
        {
            obj_work.flag |= 8U;
        }
    }

    // Token: 0x06001590 RID: 5520 RVA: 0x000BBC04 File Offset: 0x000B9E04
    private static void gmGmkBreakWall_CreateParts( AppMain.OBS_OBJECT_WORK parent_obj, int type, int obj_type, ushort vect )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        ushort num = (ushort)AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        ushort num2 = ( ushort )(AppMain.mtMathRand() % 8192);
        for ( int i = 0; i < ( int )AppMain.tbl_gmk_bwall_parts[( int )num][type].num; i++ )
        {
            ushort[] array = AppMain.tbl_gmk_bwall_parts[(int)num][type]._params[i];
            AppMain.GMS_GMK_BWALL_PARTS gms_GMK_BWALL_PARTS = (AppMain.GMS_GMK_BWALL_PARTS)AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_BWALL_PARTS(), null, 0, "BreakWall_Parts");
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BWALL_PARTS;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_breakwall_obj_3d_list[( int )array[0]], gms_GMK_BWALL_PARTS.eff_work.obj_3d );
            ushort num3 = array[5];
            ushort num4 = array[3];
            ushort angle = ( ushort )(array[4] + num2 / 2);
            if ( AppMain.GMM_GMK_TYPE_IS_VECT( obj_type ) != 0 )
            {
                if ( num4 >= 32768 )
                {
                    num4 += num2;
                }
                else
                {
                    num4 -= num2;
                }
                if ( vect == 0 )
                {
                    obs_OBJECT_WORK.pos.x = parent_obj.pos.x + ( int )( ( short )array[1] * 4096 );
                    obs_OBJECT_WORK.dir.z = 0;
                }
                else
                {
                    obs_OBJECT_WORK.pos.x = parent_obj.pos.x - ( int )( ( short )array[1] * 4096 );
                    obs_OBJECT_WORK.dir.z = 32768;
                    num4 = ( ushort )( 32768 - num4 );
                }
                gms_GMK_BWALL_PARTS.vect = num4;
                obs_OBJECT_WORK.pos.y = parent_obj.pos.y + ( int )( ( short )array[2] * 4096 );
                ushort angle2 = ( ushort )(array[4] + num2 / 2);
                int num5 = AppMain.mtMathCos((int)num4) * (int)num3;
                obs_OBJECT_WORK.spd.y = AppMain.mtMathSin( ( int )num4 ) * ( int )num3;
                obs_OBJECT_WORK.spd.x = AppMain.mtMathCos( ( int )angle2 ) * num5 >> 12;
                obs_OBJECT_WORK.spd.z = -( AppMain.mtMathSin( ( int )angle2 ) * AppMain.MTM_MATH_ABS( num5 ) >> 12 );
                obs_OBJECT_WORK.pos.z = parent_obj.pos.z + AppMain.mtMathSin( ( int )angle2 ) * 8;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.spd.x = obs_OBJECT_WORK2.spd.x + ( gms_PLAYER_WORK.obj_work.move.x >> 1 );
            }
            else
            {
                if ( num4 >= 49152 )
                {
                    num4 += num2;
                }
                else
                {
                    num4 -= num2;
                }
                obs_OBJECT_WORK.pos.x = parent_obj.pos.x + ( int )( ( short )array[1] * 4096 );
                if ( vect == 0 )
                {
                    obs_OBJECT_WORK.pos.y = parent_obj.pos.y + ( int )( ( short )array[2] * 4096 );
                    obs_OBJECT_WORK.dir.z = 0;
                }
                else
                {
                    obs_OBJECT_WORK.pos.y = parent_obj.pos.y - ( int )( ( short )array[2] * 4096 );
                    obs_OBJECT_WORK.dir.z = 32768;
                    num4 = ( ushort )( 65536 - ( int )num4 );
                }
                gms_GMK_BWALL_PARTS.vect = num4;
                int num6 = AppMain.mtMathCos((int)num4) * (int)num3;
                obs_OBJECT_WORK.spd.y = AppMain.mtMathSin( ( int )num4 ) * ( int )num3;
                obs_OBJECT_WORK.spd.x = AppMain.mtMathCos( ( int )angle ) * num6 >> 12;
                obs_OBJECT_WORK.spd.z = -( AppMain.mtMathSin( ( int )angle ) * AppMain.MTM_MATH_ABS( num6 ) >> 12 );
                obs_OBJECT_WORK.pos.z = parent_obj.pos.z + AppMain.mtMathSin( ( int )angle ) * 8;
            }
            obs_OBJECT_WORK.spd_add.y = 384;
            obs_OBJECT_WORK.dir.x = 0;
            obs_OBJECT_WORK.dir.z = 0;
            obs_OBJECT_WORK.move_flag |= 256U;
            obs_OBJECT_WORK.disp_flag |= 4194304U;
            obs_OBJECT_WORK.disp_flag &= 4294967039U;
            obs_OBJECT_WORK.flag |= 2U;
            if ( obs_OBJECT_WORK.spd.y < 0 )
            {
                gms_GMK_BWALL_PARTS.falltimer = 90;
            }
            else
            {
                gms_GMK_BWALL_PARTS.falltimer = 120;
            }
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBreakLandParts_Main );
            obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 65536U;
        }
    }

    // Token: 0x06001591 RID: 5521 RVA: 0x000BC070 File Offset: 0x000BA270
    private static AppMain.OBS_OBJECT_WORK gmGmkBreakWallInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, int wall )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BWALL_WORK(), "GMK_BREAK_LAND_MAIN");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BWALL_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_BWALL_WORK;
        ushort num = AppMain.tbl_breakwall_mdl[AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id]][wall];
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_breakwall_obj_3d_list[( int )num], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        gms_GMK_BWALL_WORK.broketype = ( ushort )( eve_rec.flag & 7 );
        if ( eve_rec.id == 272 )
        {
            gms_GMK_BWALL_WORK.obj_type = 1;
        }
        else
        {
            gms_GMK_BWALL_WORK.obj_type = 0;
        }
        gms_GMK_BWALL_WORK.wall_type = wall;
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag &= 4294967294U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 2U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 98304U;
        }
        else
        {
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag &= 4294967294U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 2U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 65536U;
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001592 RID: 5522 RVA: 0x000BC200 File Offset: 0x000BA400
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_L1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK work = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 0);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )work );
        return ( AppMain.OBS_OBJECT_WORK )work;
    }

    // Token: 0x06001593 RID: 5523 RVA: 0x000BC230 File Offset: 0x000BA430
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_L2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK work = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 1);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )work );
        return ( AppMain.OBS_OBJECT_WORK )work;
    }

    // Token: 0x06001594 RID: 5524 RVA: 0x000BC260 File Offset: 0x000BA460
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_R1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK work = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 2);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )work );
        return ( AppMain.OBS_OBJECT_WORK )work;
    }

    // Token: 0x06001595 RID: 5525 RVA: 0x000BC290 File Offset: 0x000BA490
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_R2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK work = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 3);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )work );
        return ( AppMain.OBS_OBJECT_WORK )work;
    }

    // Token: 0x06001596 RID: 5526 RVA: 0x000BC2C0 File Offset: 0x000BA4C0
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_C1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 4);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BWALL_WORK );
        gms_GMK_BWALL_WORK.gmk_work.ene_com.obj_work.disp_flag |= 4194304U;
        return ( AppMain.OBS_OBJECT_WORK )gms_GMK_BWALL_WORK;
    }

    // Token: 0x06001597 RID: 5527 RVA: 0x000BC310 File Offset: 0x000BA510
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_C2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 5);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BWALL_WORK );
        gms_GMK_BWALL_WORK.gmk_work.ene_com.obj_work.disp_flag |= 4194304U;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.obj_work.obj_3d.drawflag |= 32U;
        return ( AppMain.OBS_OBJECT_WORK )gms_GMK_BWALL_WORK;
    }

    // Token: 0x06001598 RID: 5528 RVA: 0x000BC384 File Offset: 0x000BA584
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakWall_C1_H_Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)AppMain.gmGmkBreakWallInit(eve_rec, pos_x, pos_y, type, 7);
        AppMain.gmGmkBreakWallStart( ( AppMain.OBS_OBJECT_WORK )gms_GMK_BWALL_WORK );
        gms_GMK_BWALL_WORK.gmk_work.ene_com.obj_work.disp_flag |= 4194304U;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.obj_work.disp_flag &= 4294967039U;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.obj_work.dir.z = 49152;
        gms_GMK_BWALL_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 32U;
        return ( AppMain.OBS_OBJECT_WORK )gms_GMK_BWALL_WORK;
    }

    // Token: 0x06001599 RID: 5529 RVA: 0x000BC440 File Offset: 0x000BA640
    private static AppMain.OBS_OBJECT_WORK GmGmkBreakFloorInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BWALL_WORK gms_GMK_BWALL_WORK = (AppMain.GMS_GMK_BWALL_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BWALL_WORK(), "GMK_BREAK_LAND_MAIN");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BWALL_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_BWALL_WORK;
        ushort num = AppMain.tbl_breakwall_mdl[AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id]][6];
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_breakwall_obj_3d_list[( int )num], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        if ( ( eve_rec.flag & 2 ) != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z - 4096;
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_BWALL_WORK.broketype = ( ushort )( eve_rec.flag & 1 );
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag &= 4294967294U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 2U;
        }
        gms_GMK_BWALL_WORK.obj_type = 2;
        gms_GMK_BWALL_WORK.wall_type = 6;
        AppMain.gmGmkBreakWallStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600159A RID: 5530 RVA: 0x000BC571 File Offset: 0x000BA771
    private static void GmGmkBreakWallBuild()
    {
        AppMain.gm_gmk_breakwall_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 797 ), AppMain.GmGameDatGetGimmickData( 798 ), 0U );
    }

    // Token: 0x0600159B RID: 5531 RVA: 0x000BC594 File Offset: 0x000BA794
    private static void GmGmkBreakWallFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(797));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_breakwall_obj_3d_list, ams_AMB_HEADER.file_num );
    }
}