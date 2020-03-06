using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200010C RID: 268
    public class GmkUpBumperData
    {
        // Token: 0x06001FC5 RID: 8133 RVA: 0x0013D3A4 File Offset: 0x0013B5A4
        // Note: this type is marked as 'beforefieldinit'.
        static GmkUpBumperData()
        {
            short[][] array = new short[2][];
            short[][] array2 = array;
            int num = 0;
            short[] array3 = new short[4];
            array3[1] = -8;
            array3[2] = 8;
            array2[num] = array3;
            short[][] array4 = array;
            int num2 = 1;
            short[] array5 = new short[4];
            array5[0] = -8;
            array5[1] = -8;
            array4[num2] = array5;
            AppMain.GmkUpBumperData.tbl_gm_gmk_upbumper_rect = array;
        }

        // Token: 0x04004C59 RID: 19545
        public const int GME_GMK_TYPE_UPBUMPER_L = 0;

        // Token: 0x04004C5A RID: 19546
        public const int GME_GMK_TYPE_UPBUMPER_R = 1;

        // Token: 0x04004C5B RID: 19547
        public const int GME_GMK_TYPE_MAX = 2;

        // Token: 0x04004C5C RID: 19548
        public const int GME_GMK_RECT_DATA_COL_WIDTH = 0;

        // Token: 0x04004C5D RID: 19549
        public const int GME_GMK_RECT_DATA_COL_HEIGHT = 1;

        // Token: 0x04004C5E RID: 19550
        public const int GME_GMK_RECT_DATA_COL_OFST_X = 2;

        // Token: 0x04004C5F RID: 19551
        public const int GME_GMK_RECT_DATA_COL_OFST_Y = 3;

        // Token: 0x04004C60 RID: 19552
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 0;

        // Token: 0x04004C61 RID: 19553
        public const int GME_GMK_RECT_DATA_DEF_TOP = 1;

        // Token: 0x04004C62 RID: 19554
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 2;

        // Token: 0x04004C63 RID: 19555
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 3;

        // Token: 0x04004C64 RID: 19556
        public const int GME_GMK_RECT_DATA_MAX = 4;

        // Token: 0x04004C65 RID: 19557
        public static readonly short[][] tbl_gm_gmk_upbumper_rect;
    }

    // Token: 0x0200010D RID: 269
    public class GMS_GMK_UPBUMPER_REBOUND_DATA
    {
        // Token: 0x06001FC6 RID: 8134 RVA: 0x0013D3EF File Offset: 0x0013B5EF
        public GMS_GMK_UPBUMPER_REBOUND_DATA( int act_state, int spd_x, int spd_y )
        {
            this.act_state = act_state;
            this.spd_x = spd_x;
            this.spd_y = spd_y;
        }

        // Token: 0x04004C66 RID: 19558
        public int act_state;

        // Token: 0x04004C67 RID: 19559
        public int spd_x;

        // Token: 0x04004C68 RID: 19560
        public int spd_y;
    }

    // Token: 0x0200010E RID: 270
    public class GMS_GMK_UPBUMPER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001FC7 RID: 8135 RVA: 0x0013D40C File Offset: 0x0013B60C
        public GMS_GMK_UPBUMPER_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001FC8 RID: 8136 RVA: 0x0013D42B File Offset: 0x0013B62B
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_UPBUMPER_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x06001FC9 RID: 8137 RVA: 0x0013D433 File Offset: 0x0013B633
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001FCA RID: 8138 RVA: 0x0013D445 File Offset: 0x0013B645
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_UPBUMPER_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004C69 RID: 19561
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work = new AppMain.GMS_ENEMY_3D_WORK();

        // Token: 0x04004C6A RID: 19562
        public int obj_type;

        // Token: 0x04004C6B RID: 19563
        public short player_spd_keep_timer_mine;
    }

    // Token: 0x060004E7 RID: 1255 RVA: 0x00029FC0 File Offset: 0x000281C0
    public static AppMain.OBS_OBJECT_WORK GmGmkUpBumperLInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_UPBUMPER_WORK gms_GMK_UPBUMPER_WORK = (AppMain.GMS_GMK_UPBUMPER_WORK)AppMain.gmGmkUpBumperInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_UPBUMPER_WORK.obj_type = 0;
        AppMain.gmGmkUpBumperStart( gms_GMK_UPBUMPER_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_UPBUMPER_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x060004E8 RID: 1256 RVA: 0x0002A008 File Offset: 0x00028208
    public static AppMain.OBS_OBJECT_WORK GmGmkUpBumperRInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkUpBumperInit(eve_rec, pos_x, pos_y, type);
        AppMain.GMS_GMK_UPBUMPER_WORK gms_GMK_UPBUMPER_WORK = (AppMain.GMS_GMK_UPBUMPER_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.disp_flag &= 4290772991U;
        obs_OBJECT_WORK.obj_3d.drawflag |= 32U;
        obs_OBJECT_WORK.dir.y = 16384;
        gms_GMK_UPBUMPER_WORK.obj_type = 1;
        AppMain.gmGmkUpBumperStart( gms_GMK_UPBUMPER_WORK.gmk_work.ene_com.obj_work );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060004E9 RID: 1257 RVA: 0x0002A079 File Offset: 0x00028279
    public static void GmGmkUpBumperBuild()
    {
        AppMain.gm_gmk_upbumper_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 850 ), AppMain.GmGameDatGetGimmickData( 851 ), 0U );
    }

    // Token: 0x060004EA RID: 1258 RVA: 0x0002A09C File Offset: 0x0002829C
    public static void GmGmkUpBumperFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(850);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_upbumper_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060004EB RID: 1259 RVA: 0x0002A0C4 File Offset: 0x000282C4
    private static void gmGmkUpBumperStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_UPBUMPER_WORK gms_GMK_UPBUMPER_WORK = (AppMain.GMS_GMK_UPBUMPER_WORK)obj_work;
        gms_GMK_UPBUMPER_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
        gms_GMK_UPBUMPER_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_UPBUMPER_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkUpBumperHit );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.GmkUpBumperData.tbl_gm_gmk_upbumper_rect[gms_GMK_UPBUMPER_WORK.obj_type][0], AppMain.GmkUpBumperData.tbl_gm_gmk_upbumper_rect[gms_GMK_UPBUMPER_WORK.obj_type][1], AppMain.GmkUpBumperData.tbl_gm_gmk_upbumper_rect[gms_GMK_UPBUMPER_WORK.obj_type][2], AppMain.GmkUpBumperData.tbl_gm_gmk_upbumper_rect[gms_GMK_UPBUMPER_WORK.obj_type][3] );
        obj_work.flag &= 4294967293U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkUpBumperStay );
    }

    // Token: 0x060004EC RID: 1260 RVA: 0x0002A1B8 File Offset: 0x000283B8
    private static void gmGmkUpBumperStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_UPBUMPER_WORK gms_GMK_UPBUMPER_WORK = (AppMain.GMS_GMK_UPBUMPER_WORK)obj_work;
        if ( gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine > 0 )
        {
            if ( gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine > AppMain.player_spd_keep_timer )
            {
                gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine = AppMain.player_spd_keep_timer;
                AppMain.player_spd_keep_timer -= 1;
                if ( AppMain.player_spd_keep_timer <= 0 )
                {
                    gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine = 0;
                    AppMain.player_spd_keep_timer = 0;
                    AppMain.player_spd_x = ( AppMain.player_spd_y = 0 );
                    return;
                }
            }
            else
            {
                gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine = 0;
            }
        }
    }

    // Token: 0x060004ED RID: 1261 RVA: 0x0002A224 File Offset: 0x00028424
    private static void gmGmkUpBumperHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_GMK_UPBUMPER_WORK gms_GMK_UPBUMPER_WORK = (AppMain.GMS_GMK_UPBUMPER_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] )
        {
            int spd_y = 0;
            int num;
            if ( AppMain.player_spd_keep_timer <= 0 )
            {
                num = 0;
                uint num2 = 0U;
                while ( ( ulong )num2 < ( ulong )( ( long )AppMain.GMD_GMK_UPBUMPER_REBOUND_DATA_NUM ) )
                {
                    if ( gms_PLAYER_WORK.act_state == AppMain.tbl_upbmper_rebound_data[( int )( ( UIntPtr )num2 )].act_state )
                    {
                        num = AppMain.tbl_upbmper_rebound_data[( int )( ( UIntPtr )num2 )].spd_x;
                        spd_y = AppMain.tbl_upbmper_rebound_data[( int )( ( UIntPtr )num2 )].spd_y;
                        AppMain.player_spd_x = num;
                        AppMain.player_spd_y = spd_y;
                        AppMain.player_spd_keep_timer = 60;
                        gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine = ( short )( AppMain.player_spd_keep_timer + 1 );
                        break;
                    }
                    num2 += 1U;
                }
                if ( num == 0 )
                {
                    num = AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd.x );
                    num += num >> 3;
                    if ( num > 32768 )
                    {
                        num = 32768;
                    }
                    if ( num < 16384 )
                    {
                        num = 16384;
                    }
                    spd_y = -16384;
                }
            }
            else
            {
                num = AppMain.player_spd_x;
                spd_y = AppMain.player_spd_y;
                AppMain.player_spd_keep_timer = 60;
                gms_GMK_UPBUMPER_WORK.player_spd_keep_timer_mine = ( short )( AppMain.player_spd_keep_timer + 1 );
            }
            if ( gms_GMK_UPBUMPER_WORK.obj_type == 1 )
            {
                num = -num;
            }
            AppMain.GmPlySeqGmkInitUpBumper( gms_PLAYER_WORK, num, spd_y );
            AppMain.GMM_PAD_VIB_SMALL();
        }
        mine_rect.flag &= 4294573823U;
    }

    // Token: 0x060004EE RID: 1262 RVA: 0x0002A370 File Offset: 0x00028570
    private static AppMain.OBS_OBJECT_WORK gmGmkUpBumperInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_UPBUMPER_WORK gms_GMK_UPBUMPER_WORK = (AppMain.GMS_GMK_UPBUMPER_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_UPBUMPER_WORK(), "Gmk_UpBumper");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_UPBUMPER_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_UPBUMPER_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_upbumper_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -4096;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        return obs_OBJECT_WORK;
    }
}
