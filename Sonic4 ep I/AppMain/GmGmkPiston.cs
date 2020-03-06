using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002D5 RID: 725
    public class GmkPistonData
    {
        // Token: 0x04005C3C RID: 23612
        public const int GME_GMK_TYPE_PISTON_UP = 0;

        // Token: 0x04005C3D RID: 23613
        public const int GME_GMK_TYPE_PISTON_DOWN = 1;

        // Token: 0x04005C3E RID: 23614
        public const int GME_GMK_TYPE_MAX = 2;

        // Token: 0x04005C3F RID: 23615
        public const int GMD_GMK_BOBJ1_RECT_WIDTH = 56;

        // Token: 0x04005C40 RID: 23616
        public const int GMD_GMK_BOBJ1_RECT_HEIGHT = 32;

        // Token: 0x04005C41 RID: 23617
        public const int GMD_GMK_BOBJ1_RECT_MARGIN = 32;

        // Token: 0x04005C42 RID: 23618
        public static readonly short[][] tbl_gm_gmk_piston_col_rect = new short[][]
        {
            new short[]
            {
                56,
                32,
                -28,
                0,
                -28,
                32,
                28,
                0
            },
            new short[]
            {
                56,
                32,
                -28,
                -32,
                -28,
                0,
                28,
                32
            }
        };
    }

    // Token: 0x020002D6 RID: 726
    public class GMS_GMK_PISTON_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024B3 RID: 9395 RVA: 0x0014B0EA File Offset: 0x001492EA
        public GMS_GMK_PISTON_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060024B4 RID: 9396 RVA: 0x0014B0FE File Offset: 0x001492FE
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060024B5 RID: 9397 RVA: 0x0014B110 File Offset: 0x00149310
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_PISTON_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060024B6 RID: 9398 RVA: 0x0014B122 File Offset: 0x00149322
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_PISTON_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x04005C43 RID: 23619
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04005C44 RID: 23620
        public uint obj_type;

        // Token: 0x04005C45 RID: 23621
        public ushort piston_vect;

        // Token: 0x04005C46 RID: 23622
        public int stroke_spd;

        // Token: 0x04005C47 RID: 23623
        public int timer_dec;

        // Token: 0x04005C48 RID: 23624
        public int timer_set_move;

        // Token: 0x04005C49 RID: 23625
        public int timer_set_wait_upper;

        // Token: 0x04005C4A RID: 23626
        public int timer_set_wait_lower;

        // Token: 0x04005C4B RID: 23627
        public bool efct_di;
    }

    // Token: 0x020002D7 RID: 727
    public class GMS_GMK_PISTONROD_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024B7 RID: 9399 RVA: 0x0014B12A File Offset: 0x0014932A
        public GMS_GMK_PISTONROD_WORK()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x060024B8 RID: 9400 RVA: 0x0014B13E File Offset: 0x0014933E
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x060024B9 RID: 9401 RVA: 0x0014B150 File Offset: 0x00149350
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_PISTONROD_WORK work )
        {
            return work.eff_work.efct_com.obj_work;
        }

        // Token: 0x04005C4C RID: 23628
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x04005C4D RID: 23629
        public uint obj_type;

        // Token: 0x04005C4E RID: 23630
        public int fulcrum;
    }

    // Token: 0x060013B6 RID: 5046 RVA: 0x000AEBFC File Offset: 0x000ACDFC
    private static AppMain.OBS_OBJECT_WORK GmGmkPistonUpInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkPistonInit(eve_rec, pos_x, pos_y, type);
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obs_OBJECT_WORK;
        gms_GMK_PISTON_WORK.obj_type = 0U;
        gms_GMK_PISTON_WORK.piston_vect = 32768;
        obs_OBJECT_WORK.dir.z = 0;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 32U;
        if ( eve_rec.top < 0 )
        {
            gms_GMK_PISTON_WORK.timer_set_move = ( int )( -eve_rec.top * 2 ) << 12;
        }
        else if ( eve_rec.top > 0 )
        {
            gms_GMK_PISTON_WORK.timer_set_move = ( int )( eve_rec.top * 2 ) << 12;
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStart );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060013B7 RID: 5047 RVA: 0x000AECA8 File Offset: 0x000ACEA8
    private static AppMain.OBS_OBJECT_WORK GmGmkPistonDownInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkPistonInit(eve_rec, pos_x, pos_y, type);
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obs_OBJECT_WORK;
        gms_GMK_PISTON_WORK.obj_type = 1U;
        gms_GMK_PISTON_WORK.piston_vect = 0;
        obs_OBJECT_WORK.dir.z = 32768;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 32U;
        if ( eve_rec.top > 0 )
        {
            gms_GMK_PISTON_WORK.timer_set_move = ( int )( eve_rec.top * 2 ) << 12;
        }
        else if ( eve_rec.top < 0 )
        {
            gms_GMK_PISTON_WORK.timer_set_move = ( int )( -eve_rec.top * 2 ) << 12;
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStart );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060013B8 RID: 5048 RVA: 0x000AED51 File Offset: 0x000ACF51
    public static void GmGmkPistonBuild()
    {
        AppMain.gm_gmk_piston_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 842 ), AppMain.GmGameDatGetGimmickData( 843 ), 0U );
    }

    // Token: 0x060013B9 RID: 5049 RVA: 0x000AED74 File Offset: 0x000ACF74
    public static void GmGmkPistonFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(842);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_piston_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060013BA RID: 5050 RVA: 0x000AED9C File Offset: 0x000ACF9C
    private static uint gmGmkPistonSyncTimeGet( AppMain.GMS_GMK_PISTON_WORK pwork )
    {
        uint sync_time = AppMain.g_gm_main_system.sync_time;
        uint num = (uint)((pwork.timer_set_move + (pwork.stroke_spd - 1)) / pwork.stroke_spd);
        uint num2 = num * 2U;
        num2 += ( uint )pwork.timer_set_wait_upper;
        num2 += ( uint )pwork.timer_set_wait_lower;
        return sync_time % num2;
    }

    // Token: 0x060013BB RID: 5051 RVA: 0x000AEDE8 File Offset: 0x000ACFE8
    private static void gmGmkPistonStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.width = ( ushort )AppMain.GmkPistonData.tbl_gm_gmk_piston_col_rect[( int )( ( UIntPtr )gms_GMK_PISTON_WORK.obj_type )][0];
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.height = ( ushort )AppMain.GmkPistonData.tbl_gm_gmk_piston_col_rect[( int )( ( UIntPtr )gms_GMK_PISTON_WORK.obj_type )][1];
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = AppMain.GmkPistonData.tbl_gm_gmk_piston_col_rect[( int )( ( UIntPtr )gms_GMK_PISTON_WORK.obj_type )][2];
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = AppMain.GmkPistonData.tbl_gm_gmk_piston_col_rect[( int )( ( UIntPtr )gms_GMK_PISTON_WORK.obj_type )][3];
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 134217760U;
        gms_GMK_PISTON_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294967291U;
        AppMain.gmGmkPistonRod_Create( obj_work );
        uint num = (uint)((gms_GMK_PISTON_WORK.timer_set_move + (gms_GMK_PISTON_WORK.stroke_spd - 1)) / gms_GMK_PISTON_WORK.stroke_spd);
        uint num2 = AppMain.gmGmkPistonSyncTimeGet(gms_GMK_PISTON_WORK);
        if ( num2 <= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_lower )
        {
            gms_GMK_PISTON_WORK.timer_dec = ( int )( ( long )gms_GMK_PISTON_WORK.timer_set_wait_lower - ( long )( ( ulong )( num2 - 1U ) ) );
            AppMain.gmGmkPistonStay( obj_work );
            return;
        }
        num2 -= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_lower;
        int num3 = (gms_GMK_PISTON_WORK.piston_vect == 0) ? gms_GMK_PISTON_WORK.stroke_spd : (-gms_GMK_PISTON_WORK.stroke_spd);
        if ( num2 < num )
        {
            gms_GMK_PISTON_WORK.timer_dec = gms_GMK_PISTON_WORK.timer_set_move;
            while ( num2 > 1U )
            {
                gms_GMK_PISTON_WORK.timer_dec -= gms_GMK_PISTON_WORK.stroke_spd;
                obj_work.pos.y = obj_work.pos.y + num3;
                num2 -= 1U;
            }
            AppMain.gmGmkPistonStroke( obj_work );
            return;
        }
        num2 -= num;
        obj_work.pos.y = obj_work.pos.y + ( ( gms_GMK_PISTON_WORK.piston_vect == 0 ) ? gms_GMK_PISTON_WORK.timer_set_move : ( -gms_GMK_PISTON_WORK.timer_set_move ) );
        if ( num2 <= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_upper )
        {
            gms_GMK_PISTON_WORK.timer_dec = ( int )( ( long )gms_GMK_PISTON_WORK.timer_set_wait_upper - ( long )( ( ulong )( num2 - 1U ) ) );
            AppMain.gmGmkPistonTopDeadWait( obj_work );
            return;
        }
        num2 -= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_upper;
        gms_GMK_PISTON_WORK.timer_dec = gms_GMK_PISTON_WORK.timer_set_move;
        while ( num2 > 1U )
        {
            gms_GMK_PISTON_WORK.timer_dec -= gms_GMK_PISTON_WORK.stroke_spd;
            obj_work.pos.y = obj_work.pos.y - num3;
            num2 -= 1U;
        }
        AppMain.gmGmkPistonShrink( obj_work );
    }

    // Token: 0x060013BC RID: 5052 RVA: 0x000AF087 File Offset: 0x000AD287
    private static void gmGmkPistonStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.y = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStay_100 );
        AppMain.gmGmkPistonStay_100( obj_work );
    }

    // Token: 0x060013BD RID: 5053 RVA: 0x000AF0B0 File Offset: 0x000AD2B0
    private static void gmGmkPistonStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.timer_dec--;
        if ( gms_GMK_PISTON_WORK.timer_dec <= 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStay_200 );
        }
    }

    // Token: 0x060013BE RID: 5054 RVA: 0x000AF0F0 File Offset: 0x000AD2F0
    private static void gmGmkPistonStay_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.timer_dec = gms_GMK_PISTON_WORK.timer_set_move;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStroke );
        AppMain.gmGmkPistonStroke( obj_work );
    }

    // Token: 0x060013BF RID: 5055 RVA: 0x000AF128 File Offset: 0x000AD328
    private static void gmGmkPistonStroke( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        obj_work.spd.y = ( ( gms_GMK_PISTON_WORK.piston_vect == 0 ) ? gms_GMK_PISTON_WORK.stroke_spd : ( -gms_GMK_PISTON_WORK.stroke_spd ) );
        obj_work.pos.y = obj_work.pos.y + obj_work.spd.y;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStroke_100 );
        AppMain.gmGmkPistonStroke_100( obj_work );
        AppMain.GmSoundPlaySE( "Piston1" );
    }

    // Token: 0x060013C0 RID: 5056 RVA: 0x000AF1A0 File Offset: 0x000AD3A0
    private static void gmGmkPistonStroke_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.timer_dec -= gms_GMK_PISTON_WORK.stroke_spd;
        if ( gms_GMK_PISTON_WORK.timer_dec <= 0 )
        {
            obj_work.spd.y = 0;
            if ( gms_GMK_PISTON_WORK.timer_dec < 0 )
            {
                obj_work.spd.y = gms_GMK_PISTON_WORK.timer_dec;
                if ( gms_GMK_PISTON_WORK.piston_vect == 32768 )
                {
                    obj_work.spd.y = -obj_work.spd.y;
                }
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonStroke_200 );
        }
    }

    // Token: 0x060013C1 RID: 5057 RVA: 0x000AF22C File Offset: 0x000AD42C
    private static void gmGmkPistonStroke_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        uint num = (uint)((gms_GMK_PISTON_WORK.timer_set_move + (gms_GMK_PISTON_WORK.stroke_spd - 1)) / gms_GMK_PISTON_WORK.stroke_spd);
        uint num2 = AppMain.gmGmkPistonSyncTimeGet(gms_GMK_PISTON_WORK);
        num2 -= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_lower;
        num2 -= num;
        if ( num2 <= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_upper )
        {
            gms_GMK_PISTON_WORK.timer_dec = ( int )( ( long )gms_GMK_PISTON_WORK.timer_set_wait_upper - ( long )( ( ulong )( num2 - 1U ) ) );
        }
        else
        {
            gms_GMK_PISTON_WORK.timer_dec = 0;
        }
        AppMain.gmGmkPistonTopDeadWait( obj_work );
    }

    // Token: 0x060013C2 RID: 5058 RVA: 0x000AF298 File Offset: 0x000AD498
    private static void gmGmkPistonTopDeadWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        if ( !gms_GMK_PISTON_WORK.efct_di )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(null, 48);
            obs_OBJECT_WORK.pos.x = obj_work.pos.x;
            obs_OBJECT_WORK.pos.y = obj_work.pos.y;
            obs_OBJECT_WORK.pos.z = obj_work.pos.z + 65536;
            obs_OBJECT_WORK.dir.z = obj_work.dir.z;
            AppMain.GmSoundPlaySE( "Piston2" );
        }
        obj_work.spd.y = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonTopDeadWait_100 );
        AppMain.gmGmkPistonTopDeadWait_100( obj_work );
    }

    // Token: 0x060013C3 RID: 5059 RVA: 0x000AF350 File Offset: 0x000AD550
    private static void gmGmkPistonTopDeadWait_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.timer_dec--;
        if ( gms_GMK_PISTON_WORK.timer_dec <= 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonTopDeadWait_200 );
        }
    }

    // Token: 0x060013C4 RID: 5060 RVA: 0x000AF390 File Offset: 0x000AD590
    private static void gmGmkPistonTopDeadWait_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.timer_dec = gms_GMK_PISTON_WORK.timer_set_move;
        AppMain.gmGmkPistonShrink( obj_work );
    }

    // Token: 0x060013C5 RID: 5061 RVA: 0x000AF3B8 File Offset: 0x000AD5B8
    private static void gmGmkPistonShrink( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        obj_work.spd.y = ( ( gms_GMK_PISTON_WORK.piston_vect == 0 ) ? ( -gms_GMK_PISTON_WORK.stroke_spd ) : gms_GMK_PISTON_WORK.stroke_spd );
        obj_work.pos.y = obj_work.pos.y + obj_work.spd.y;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonShrink_100 );
        AppMain.gmGmkPistonShrink_100( obj_work );
        AppMain.GmSoundPlaySE( "Piston1" );
    }

    // Token: 0x060013C6 RID: 5062 RVA: 0x000AF430 File Offset: 0x000AD630
    private static void gmGmkPistonShrink_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        gms_GMK_PISTON_WORK.timer_dec -= gms_GMK_PISTON_WORK.stroke_spd;
        if ( gms_GMK_PISTON_WORK.timer_dec <= 0 )
        {
            obj_work.spd.y = 0;
            if ( gms_GMK_PISTON_WORK.timer_dec < 0 )
            {
                obj_work.spd.y = gms_GMK_PISTON_WORK.timer_dec;
                if ( gms_GMK_PISTON_WORK.piston_vect != 32768 )
                {
                    obj_work.spd.y = -obj_work.spd.y;
                }
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonShrink_200 );
        }
    }

    // Token: 0x060013C7 RID: 5063 RVA: 0x000AF4BC File Offset: 0x000AD6BC
    private static void gmGmkPistonShrink_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)obj_work;
        uint num = AppMain.gmGmkPistonSyncTimeGet(gms_GMK_PISTON_WORK);
        if ( num <= ( uint )gms_GMK_PISTON_WORK.timer_set_wait_lower )
        {
            gms_GMK_PISTON_WORK.timer_dec = ( int )( ( long )gms_GMK_PISTON_WORK.timer_set_wait_lower - ( long )( ( ulong )( num - 1U ) ) );
        }
        else
        {
            gms_GMK_PISTON_WORK.timer_dec = 0;
        }
        AppMain.gmGmkPistonStay( obj_work );
    }

    // Token: 0x060013C8 RID: 5064 RVA: 0x000AF504 File Offset: 0x000AD704
    private static void gmGmkPistonRodStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PISTONROD_WORK gms_GMK_PISTONROD_WORK = (AppMain.GMS_GMK_PISTONROD_WORK)obj_work;
        int num = AppMain.MTM_MATH_ABS(obj_work.parent_obj.pos.y - gms_GMK_PISTONROD_WORK.fulcrum);
        num /= 8;
        obj_work.scale.y = num;
    }

    // Token: 0x060013C9 RID: 5065 RVA: 0x000AF54C File Offset: 0x000AD74C
    private static void gmGmkPistonRod_Create( AppMain.OBS_OBJECT_WORK parent_obj )
    {
        AppMain.GMS_GMK_PISTONROD_WORK gms_GMK_PISTONROD_WORK = (AppMain.GMS_GMK_PISTONROD_WORK)AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_PISTONROD_WORK(), null, 0, "Gmk_PistonRod");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_PISTONROD_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_piston_obj_3d_list[1], gms_GMK_PISTONROD_WORK.eff_work.obj_3d );
        obs_OBJECT_WORK.parent_obj = parent_obj;
        obs_OBJECT_WORK.parent_ofst.x = 0;
        obs_OBJECT_WORK.parent_ofst.y = 65536;
        obs_OBJECT_WORK.parent_ofst.z = -524288;
        obs_OBJECT_WORK.dir.z = ( ushort )( parent_obj.dir.z ^ 32768 );
        if ( obs_OBJECT_WORK.dir.z == 0 )
        {
            obs_OBJECT_WORK.parent_ofst.y = -obs_OBJECT_WORK.parent_ofst.y;
        }
        obs_OBJECT_WORK.flag |= 1024U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.disp_flag &= 4294967039U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPistonRodStay );
        gms_GMK_PISTONROD_WORK.fulcrum = parent_obj.pos.y + obs_OBJECT_WORK.parent_ofst.y;
    }

    // Token: 0x060013CA RID: 5066 RVA: 0x000AF6A8 File Offset: 0x000AD8A8
    private static AppMain.OBS_OBJECT_WORK gmGmkPistonInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_PISTON_WORK gms_GMK_PISTON_WORK = (AppMain.GMS_GMK_PISTON_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_PISTON_WORK(), "Gmk_PistonRod");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_PISTON_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_PISTON_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_piston_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.disp_flag &= 4294967039U;
        obs_OBJECT_WORK.flag |= 2U;
        gms_GMK_PISTON_WORK.stroke_spd = 16384;
        gms_GMK_PISTON_WORK.timer_set_move = 524288;
        if ( ( eve_rec.flag & 31 ) != 0 )
        {
            int num;
            if ( ( eve_rec.flag & 31 ) <= 16 )
            {
                num = ( int )( eve_rec.flag & 31 ) << 10;
            }
            else
            {
                num = ( int )( -( int )( eve_rec.flag & 15 ) ) << 10;
            }
            gms_GMK_PISTON_WORK.stroke_spd += num;
        }
        gms_GMK_PISTON_WORK.efct_di = ( ( eve_rec.flag & 128 ) != 0 );
        gms_GMK_PISTON_WORK.timer_set_wait_upper = ( int )( eve_rec.left * 2 );
        gms_GMK_PISTON_WORK.timer_set_wait_lower = ( int )( eve_rec.height * 2 );
        return obs_OBJECT_WORK;
    }
}