using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000147 RID: 327
    public class GmkSpearData
    {
        // Token: 0x04004D4F RID: 19791
        public const int GME_GMK_TYPE_SPEAR_U = 0;

        // Token: 0x04004D50 RID: 19792
        public const int GME_GMK_TYPE_SPEAR_D = 1;

        // Token: 0x04004D51 RID: 19793
        public const int GME_GMK_TYPE_SPEAR_L = 2;

        // Token: 0x04004D52 RID: 19794
        public const int GME_GMK_TYPE_SPEAR_R = 3;

        // Token: 0x04004D53 RID: 19795
        public const int GME_GMK_TYPE_MAX = 4;

        // Token: 0x04004D54 RID: 19796
        public const int GME_GMK_RECT_DATA_LEFT = 0;

        // Token: 0x04004D55 RID: 19797
        public const int GME_GMK_RECT_DATA_TOP = 1;

        // Token: 0x04004D56 RID: 19798
        public const int GME_GMK_RECT_DATA_RIGHT = 2;

        // Token: 0x04004D57 RID: 19799
        public const int GME_GMK_RECT_DATA_BOTTOM = 3;

        // Token: 0x04004D58 RID: 19800
        public const int GME_GMK_RECT_DATA_MAX = 4;
    }

    // Token: 0x02000148 RID: 328
    public class GMS_GMK_SPEAR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020B3 RID: 8371 RVA: 0x0013F955 File Offset: 0x0013DB55
        public GMS_GMK_SPEAR_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060020B4 RID: 8372 RVA: 0x0013F969 File Offset: 0x0013DB69
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004D59 RID: 19801
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004D5A RID: 19802
        public uint obj_type;

        // Token: 0x04004D5B RID: 19803
        public ushort vect;

        // Token: 0x04004D5C RID: 19804
        public int stroke_spd;

        // Token: 0x04004D5D RID: 19805
        public int timer_dec;

        // Token: 0x04004D5E RID: 19806
        public int timer_set_move;

        // Token: 0x04004D5F RID: 19807
        public short timer_set_wait_upper;

        // Token: 0x04004D60 RID: 19808
        public short timer_set_wait_lower;
    }

    // Token: 0x02000149 RID: 329
    public class GMS_GMK_SPEARPARTS_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020B5 RID: 8373 RVA: 0x0013F97B File Offset: 0x0013DB7B
        public GMS_GMK_SPEARPARTS_WORK()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x060020B6 RID: 8374 RVA: 0x0013F98F File Offset: 0x0013DB8F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x04004D61 RID: 19809
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x04004D62 RID: 19810
        public uint obj_type;

        // Token: 0x04004D63 RID: 19811
        public int fulcrum;

        // Token: 0x04004D64 RID: 19812
        public int connect;

        // Token: 0x04004D65 RID: 19813
        public AppMain.OBS_OBJECT_WORK parent_connect;

        // Token: 0x04004D66 RID: 19814
        public uint connect_type;
    }

    // Token: 0x06000554 RID: 1364 RVA: 0x0002CFAC File Offset: 0x0002B1AC
    private static AppMain.OBS_OBJECT_WORK GmGmkSpearUInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)AppMain.gmGmkSpearInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPEAR_WORK.obj_type = 0U;
        gms_GMK_SPEAR_WORK.vect = 49152;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.dir.z = 0;
        if ( eve_rec.left > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_upper = ( short )eve_rec.left;
        }
        if ( eve_rec.width > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_lower = ( short )eve_rec.width;
        }
        if ( eve_rec.top < 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_move = -( ( int )eve_rec.top << 12 );
        }
        AppMain.gmGmkSpear_CreateParts( gms_GMK_SPEAR_WORK );
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStart );
        return gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x06000555 RID: 1365 RVA: 0x0002D070 File Offset: 0x0002B270
    private static AppMain.OBS_OBJECT_WORK GmGmkSpearDInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)AppMain.gmGmkSpearInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPEAR_WORK.obj_type = 1U;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.dir.z = 32768;
        gms_GMK_SPEAR_WORK.vect = 16384;
        if ( eve_rec.left > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_upper = ( short )eve_rec.left;
        }
        if ( eve_rec.width > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_lower = ( short )eve_rec.width;
        }
        if ( eve_rec.top > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_move = ( int )eve_rec.top << 12;
        }
        AppMain.gmGmkSpear_CreateParts( gms_GMK_SPEAR_WORK );
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStart );
        return gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x06000556 RID: 1366 RVA: 0x0002D138 File Offset: 0x0002B338
    private static AppMain.OBS_OBJECT_WORK GmGmkSpearLInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)AppMain.gmGmkSpearInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPEAR_WORK.obj_type = 2U;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.dir.z = 49152;
        gms_GMK_SPEAR_WORK.vect = 32768;
        if ( eve_rec.top > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_upper = ( short )eve_rec.top;
        }
        if ( eve_rec.width > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_lower = ( short )eve_rec.width;
        }
        if ( eve_rec.left < 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_move = -( ( int )eve_rec.left << 12 );
        }
        AppMain.gmGmkSpear_CreateParts( gms_GMK_SPEAR_WORK );
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStart );
        return gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x06000557 RID: 1367 RVA: 0x0002D200 File Offset: 0x0002B400
    private static AppMain.OBS_OBJECT_WORK GmGmkSpearRInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)AppMain.gmGmkSpearInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SPEAR_WORK.obj_type = 3U;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.dir.z = 16384;
        gms_GMK_SPEAR_WORK.vect = 0;
        if ( eve_rec.top > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_upper = ( short )eve_rec.top;
        }
        if ( eve_rec.width > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_wait_lower = ( short )eve_rec.width;
        }
        if ( eve_rec.left > 0 )
        {
            gms_GMK_SPEAR_WORK.timer_set_move = ( int )eve_rec.left << 12;
        }
        AppMain.gmGmkSpear_CreateParts( gms_GMK_SPEAR_WORK );
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStart );
        return gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x06000558 RID: 1368 RVA: 0x0002D2C2 File Offset: 0x0002B4C2
    public static void GmGmkSpearBuild()
    {
        AppMain.gm_gmk_spear_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 856 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 857 ) ), 0U );
    }

    // Token: 0x06000559 RID: 1369 RVA: 0x0002D2F0 File Offset: 0x0002B4F0
    public static void GmGmkSpearFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(856));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_spear_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600055A RID: 1370 RVA: 0x0002D320 File Offset: 0x0002B520
    private static uint gmGmkSpearSyncTimeGet( AppMain.GMS_GMK_SPEAR_WORK pwork )
    {
        uint sync_time = AppMain.g_gm_main_system.sync_time;
        uint num = (uint)((pwork.timer_set_move + (pwork.stroke_spd - 1)) / pwork.stroke_spd);
        uint num2 = num * 2U;
        num2 += ( uint )pwork.timer_set_wait_upper;
        num2 += ( uint )pwork.timer_set_wait_lower;
        return sync_time % num2;
    }

    // Token: 0x0600055B RID: 1371 RVA: 0x0002D36C File Offset: 0x0002B56C
    private static void gmGmkSpearStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294967291U;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
        gms_GMK_SPEAR_WORK.gmk_work.ene_com.rect_work[1].flag |= 4U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_SPEAR_WORK.gmk_work.ene_com.rect_work[1];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_spear_rect[( int )( ( UIntPtr )gms_GMK_SPEAR_WORK.obj_type )][0], AppMain.tbl_gm_gmk_spear_rect[( int )( ( UIntPtr )gms_GMK_SPEAR_WORK.obj_type )][1], -500, AppMain.tbl_gm_gmk_spear_rect[( int )( ( UIntPtr )gms_GMK_SPEAR_WORK.obj_type )][2], AppMain.tbl_gm_gmk_spear_rect[( int )( ( UIntPtr )gms_GMK_SPEAR_WORK.obj_type )][3], 500 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK.flag |= 1024U;
        obj_work.flag &= 4294967293U;
        uint num = AppMain.g_gm_main_system.sync_time;
        uint num2 = (uint)((gms_GMK_SPEAR_WORK.timer_set_move + (gms_GMK_SPEAR_WORK.stroke_spd - 1)) / gms_GMK_SPEAR_WORK.stroke_spd);
        uint num3 = num2 * 2U;
        num3 += ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_upper;
        num3 += ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_lower;
        if ( num <= ( uint )gms_GMK_SPEAR_WORK.timer_dec )
        {
            gms_GMK_SPEAR_WORK.timer_dec -= ( int )( num - 1U );
            gms_GMK_SPEAR_WORK.timer_dec += ( int )gms_GMK_SPEAR_WORK.timer_set_wait_lower;
            AppMain.gmGmkSpearStay( obj_work );
            return;
        }
        num -= ( uint )gms_GMK_SPEAR_WORK.timer_dec;
        num %= num3;
        if ( num <= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_lower )
        {
            gms_GMK_SPEAR_WORK.timer_dec = ( int )( ( long )gms_GMK_SPEAR_WORK.timer_set_wait_lower - ( long )( ( ulong )( num - 1U ) ) );
            AppMain.gmGmkSpearStay( obj_work );
            return;
        }
        num -= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_lower;
        int num4 = AppMain.mtMathCos((int)gms_GMK_SPEAR_WORK.vect);
        int num5 = AppMain.mtMathSin((int)gms_GMK_SPEAR_WORK.vect);
        num4 = num4 * gms_GMK_SPEAR_WORK.stroke_spd >> 12;
        num5 = num5 * gms_GMK_SPEAR_WORK.stroke_spd >> 12;
        if ( num < num2 )
        {
            gms_GMK_SPEAR_WORK.timer_dec = gms_GMK_SPEAR_WORK.timer_set_move;
            while ( num > 1U )
            {
                gms_GMK_SPEAR_WORK.timer_dec -= gms_GMK_SPEAR_WORK.stroke_spd;
                obj_work.pos.x = obj_work.pos.x + num4;
                obj_work.pos.y = obj_work.pos.y + num5;
                num -= 1U;
            }
            obj_work.spd.x = num4;
            obj_work.spd.y = num5;
            AppMain.gmGmkSpearStroke( obj_work );
            return;
        }
        num -= num2;
        int num6 = AppMain.mtMathCos((int)gms_GMK_SPEAR_WORK.vect) * gms_GMK_SPEAR_WORK.timer_set_move >> 12;
        int num7 = AppMain.mtMathSin((int)gms_GMK_SPEAR_WORK.vect) * gms_GMK_SPEAR_WORK.timer_set_move >> 12;
        obj_work.pos.x = obj_work.pos.x + num6;
        obj_work.pos.y = obj_work.pos.y + num7;
        if ( num <= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_upper )
        {
            gms_GMK_SPEAR_WORK.timer_dec = ( int )( ( long )gms_GMK_SPEAR_WORK.timer_set_wait_upper - ( long )( ( ulong )( num - 1U ) ) );
            AppMain.gmGmkSpearWait( obj_work );
            return;
        }
        num -= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_upper;
        gms_GMK_SPEAR_WORK.timer_dec = gms_GMK_SPEAR_WORK.timer_set_move;
        while ( num > 1U )
        {
            gms_GMK_SPEAR_WORK.timer_dec -= gms_GMK_SPEAR_WORK.stroke_spd;
            obj_work.pos.x = obj_work.pos.x - num4;
            obj_work.pos.y = obj_work.pos.y - num5;
            num -= 1U;
        }
        obj_work.spd.x = -num4;
        obj_work.spd.y = -num5;
        AppMain.gmGmkSpearShrink( obj_work );
    }

    // Token: 0x0600055C RID: 1372 RVA: 0x0002D6BB File Offset: 0x0002B8BB
    private static void gmGmkSpearStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStay_100 );
        AppMain.gmGmkSpearStay_100( obj_work );
    }

    // Token: 0x0600055D RID: 1373 RVA: 0x0002D6D8 File Offset: 0x0002B8D8
    private static void gmGmkSpearStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        gms_GMK_SPEAR_WORK.timer_dec--;
        if ( gms_GMK_SPEAR_WORK.timer_dec <= 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStay_200 );
        }
    }

    // Token: 0x0600055E RID: 1374 RVA: 0x0002D718 File Offset: 0x0002B918
    private static void gmGmkSpearStay_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        obj_work.spd.x = AppMain.mtMathCos( ( int )gms_GMK_SPEAR_WORK.vect );
        obj_work.spd.y = AppMain.mtMathSin( ( int )gms_GMK_SPEAR_WORK.vect );
        obj_work.spd.x = obj_work.spd.x * gms_GMK_SPEAR_WORK.stroke_spd >> 12;
        obj_work.spd.y = obj_work.spd.y * gms_GMK_SPEAR_WORK.stroke_spd >> 12;
        gms_GMK_SPEAR_WORK.timer_dec = gms_GMK_SPEAR_WORK.timer_set_move;
        AppMain.GmSoundPlaySE( "Spear" );
        AppMain.gmGmkSpearStroke( obj_work );
    }

    // Token: 0x0600055F RID: 1375 RVA: 0x0002D7B4 File Offset: 0x0002B9B4
    private static void gmGmkSpearStroke( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = obj_work.pos.x + obj_work.spd.x;
        obj_work.pos.y = obj_work.pos.y + obj_work.spd.y;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStroke_100 );
        AppMain.gmGmkSpearStroke_100( obj_work );
    }

    // Token: 0x06000560 RID: 1376 RVA: 0x0002D814 File Offset: 0x0002BA14
    private static void gmGmkSpearStroke_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        gms_GMK_SPEAR_WORK.timer_dec -= gms_GMK_SPEAR_WORK.stroke_spd;
        if ( gms_GMK_SPEAR_WORK.timer_dec <= 0 )
        {
            if ( gms_GMK_SPEAR_WORK.timer_dec < 0 )
            {
                obj_work.spd.x = AppMain.mtMathCos( ( int )gms_GMK_SPEAR_WORK.vect );
                obj_work.spd.y = AppMain.mtMathSin( ( int )gms_GMK_SPEAR_WORK.vect );
                obj_work.spd.x = obj_work.spd.x * gms_GMK_SPEAR_WORK.timer_dec >> 12;
                obj_work.spd.y = obj_work.spd.y * gms_GMK_SPEAR_WORK.timer_dec >> 12;
            }
            else
            {
                obj_work.spd.x = 0;
                obj_work.spd.y = 0;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearStroke_200 );
        }
    }

    // Token: 0x06000561 RID: 1377 RVA: 0x0002D8E8 File Offset: 0x0002BAE8
    private static void gmGmkSpearStroke_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        uint num = (uint)((gms_GMK_SPEAR_WORK.timer_set_move + (gms_GMK_SPEAR_WORK.stroke_spd - 1)) / gms_GMK_SPEAR_WORK.stroke_spd);
        uint num2 = AppMain.gmGmkSpearSyncTimeGet(gms_GMK_SPEAR_WORK);
        num2 -= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_lower;
        num2 -= num;
        if ( num2 <= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_upper )
        {
            gms_GMK_SPEAR_WORK.timer_dec = ( int )( ( long )gms_GMK_SPEAR_WORK.timer_set_wait_upper - ( long )( ( ulong )( num2 - 1U ) ) );
        }
        else
        {
            gms_GMK_SPEAR_WORK.timer_dec = 0;
        }
        AppMain.gmGmkSpearWait( obj_work );
    }

    // Token: 0x06000562 RID: 1378 RVA: 0x0002D96A File Offset: 0x0002BB6A
    private static void gmGmkSpearWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearWait_100 );
        AppMain.gmGmkSpearWait_100( obj_work );
    }

    // Token: 0x06000563 RID: 1379 RVA: 0x0002D984 File Offset: 0x0002BB84
    private static void gmGmkSpearWait_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        gms_GMK_SPEAR_WORK.timer_dec--;
        if ( gms_GMK_SPEAR_WORK.timer_dec <= 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearWait_200 );
        }
    }

    // Token: 0x06000564 RID: 1380 RVA: 0x0002D9C4 File Offset: 0x0002BBC4
    private static void gmGmkSpearWait_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        obj_work.spd.x = -( AppMain.mtMathCos( ( int )gms_GMK_SPEAR_WORK.vect ) * gms_GMK_SPEAR_WORK.stroke_spd ) >> 12;
        obj_work.spd.y = -( AppMain.mtMathSin( ( int )gms_GMK_SPEAR_WORK.vect ) * gms_GMK_SPEAR_WORK.stroke_spd ) >> 12;
        gms_GMK_SPEAR_WORK.timer_dec = gms_GMK_SPEAR_WORK.timer_set_move;
        AppMain.gmGmkSpearShrink( obj_work );
    }

    // Token: 0x06000565 RID: 1381 RVA: 0x0002DA2C File Offset: 0x0002BC2C
    private static void gmGmkSpearShrink( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = obj_work.pos.x + obj_work.spd.x;
        obj_work.pos.y = obj_work.pos.y + obj_work.spd.y;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearShrink_100 );
        AppMain.gmGmkSpearShrink_100( obj_work );
    }

    // Token: 0x06000566 RID: 1382 RVA: 0x0002DA8C File Offset: 0x0002BC8C
    private static void gmGmkSpearShrink_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        gms_GMK_SPEAR_WORK.timer_dec -= gms_GMK_SPEAR_WORK.stroke_spd;
        if ( gms_GMK_SPEAR_WORK.timer_dec <= 0 )
        {
            if ( gms_GMK_SPEAR_WORK.timer_dec < 0 )
            {
                obj_work.spd.x = AppMain.mtMathCos( ( int )gms_GMK_SPEAR_WORK.vect );
                obj_work.spd.y = AppMain.mtMathSin( ( int )gms_GMK_SPEAR_WORK.vect );
                obj_work.spd.x = -( obj_work.spd.x * gms_GMK_SPEAR_WORK.timer_dec >> 12 );
                obj_work.spd.y = -( obj_work.spd.y * gms_GMK_SPEAR_WORK.timer_dec >> 12 );
            }
            else
            {
                obj_work.spd.x = 0;
                obj_work.spd.y = 0;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearShrink_200 );
        }
    }

    // Token: 0x06000567 RID: 1383 RVA: 0x0002DB64 File Offset: 0x0002BD64
    private static void gmGmkSpearShrink_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)obj_work;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        uint num = AppMain.gmGmkSpearSyncTimeGet(gms_GMK_SPEAR_WORK);
        if ( num <= ( uint )gms_GMK_SPEAR_WORK.timer_set_wait_lower )
        {
            gms_GMK_SPEAR_WORK.timer_dec = ( int )( ( long )gms_GMK_SPEAR_WORK.timer_set_wait_lower - ( long )( ( ulong )( num - 1U ) ) );
        }
        else
        {
            gms_GMK_SPEAR_WORK.timer_dec = 0;
        }
        AppMain.gmGmkSpearStay( obj_work );
    }

    // Token: 0x06000568 RID: 1384 RVA: 0x0002DBC4 File Offset: 0x0002BDC4
    private static void gmGmkSpearRod( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SPEARPARTS_WORK gms_GMK_SPEARPARTS_WORK = (AppMain.GMS_GMK_SPEARPARTS_WORK)obj_work;
        switch ( gms_GMK_SPEARPARTS_WORK.connect_type )
        {
            case 0U:
                gms_GMK_SPEARPARTS_WORK.connect = gms_GMK_SPEARPARTS_WORK.parent_connect.pos.y;
                break;
            case 1U:
                gms_GMK_SPEARPARTS_WORK.connect = gms_GMK_SPEARPARTS_WORK.parent_connect.pos.y;
                break;
            case 2U:
                gms_GMK_SPEARPARTS_WORK.connect = gms_GMK_SPEARPARTS_WORK.parent_connect.pos.x;
                break;
            case 3U:
                gms_GMK_SPEARPARTS_WORK.connect = gms_GMK_SPEARPARTS_WORK.parent_connect.pos.x;
                break;
        }
        int num = AppMain.MTM_MATH_ABS(gms_GMK_SPEARPARTS_WORK.connect - gms_GMK_SPEARPARTS_WORK.fulcrum);
        num /= 5;
        obj_work.scale.y = num;
    }

    // Token: 0x06000569 RID: 1385 RVA: 0x0002DC8C File Offset: 0x0002BE8C
    private static void gmGmkSpear_CreateParts( AppMain.GMS_GMK_SPEAR_WORK pwork )
    {
        AppMain.OBS_OBJECT_WORK obj_work = pwork.gmk_work.ene_com.obj_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_SPEARPARTS_WORK(), null, 0, "Gmk_SpearBase");
        AppMain.GMS_GMK_SPEARPARTS_WORK gms_GMK_SPEARPARTS_WORK = (AppMain.GMS_GMK_SPEARPARTS_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_spear_obj_3d_list[2], gms_GMK_SPEARPARTS_WORK.eff_work.obj_3d );
        obs_OBJECT_WORK.parent_obj = obj_work;
        obs_OBJECT_WORK.pos.x = obj_work.pos.x;
        obs_OBJECT_WORK.pos.y = obj_work.pos.y;
        obs_OBJECT_WORK.pos.z = obj_work.pos.z;
        switch ( pwork.obj_type )
        {
            case 0U:
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + 16384;
                    break;
                }
            case 1U:
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y - 16384;
                    break;
                }
            case 2U:
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK4.pos.x = obs_OBJECT_WORK4.pos.x + 16384;
                    break;
                }
            case 3U:
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK5 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK5.pos.x = obs_OBJECT_WORK5.pos.x - 16384;
                    break;
                }
        }
        obs_OBJECT_WORK.dir.z = obj_work.dir.z;
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag &= 4294967039U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.ppFunc = null;
        obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_GMK_SPEARPARTS_WORK(), null, 0, "Gmk_SpearRod" );
        gms_GMK_SPEARPARTS_WORK = ( AppMain.GMS_GMK_SPEARPARTS_WORK )obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_spear_obj_3d_list[1], gms_GMK_SPEARPARTS_WORK.eff_work.obj_3d );
        obs_OBJECT_WORK.parent_obj = obj_work;
        obs_OBJECT_WORK.parent_ofst.x = 0;
        obs_OBJECT_WORK.parent_ofst.y = 0;
        obs_OBJECT_WORK.parent_ofst.z = -1;
        obs_OBJECT_WORK.dir.z = obj_work.dir.z;
        obs_OBJECT_WORK.flag |= 1024U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag &= 4294967039U;
        obs_OBJECT_WORK.flag |= 2U;
        switch ( pwork.obj_type )
        {
            case 0U:
                gms_GMK_SPEARPARTS_WORK.connect = obj_work.pos.y;
                break;
            case 1U:
                gms_GMK_SPEARPARTS_WORK.connect = obj_work.pos.y;
                break;
            case 2U:
                gms_GMK_SPEARPARTS_WORK.connect = obj_work.pos.x;
                break;
            case 3U:
                gms_GMK_SPEARPARTS_WORK.connect = obj_work.pos.x;
                break;
        }
        gms_GMK_SPEARPARTS_WORK.connect_type = pwork.obj_type;
        gms_GMK_SPEARPARTS_WORK.parent_connect = obj_work;
        gms_GMK_SPEARPARTS_WORK.obj_type = pwork.obj_type;
        gms_GMK_SPEARPARTS_WORK.fulcrum = gms_GMK_SPEARPARTS_WORK.connect;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpearRod );
    }

    // Token: 0x0600056A RID: 1386 RVA: 0x0002DFA4 File Offset: 0x0002C1A4
    private static AppMain.OBS_OBJECT_WORK gmGmkSpearInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SPEAR_WORK gms_GMK_SPEAR_WORK = (AppMain.GMS_GMK_SPEAR_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SPEAR_WORK(), "Gmk_Spear");
        AppMain.OBS_OBJECT_WORK obj_work = gms_GMK_SPEAR_WORK.gmk_work.ene_com.obj_work;
        AppMain.GMS_ENEMY_3D_WORK gmk_work = gms_GMK_SPEAR_WORK.gmk_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_spear_obj_3d_list[0], gmk_work.obj_3d );
        obj_work.pos.z = 0;
        obj_work.move_flag |= 256U;
        gms_GMK_SPEAR_WORK.timer_set_move = 196608;
        gms_GMK_SPEAR_WORK.stroke_spd = 32768;
        gms_GMK_SPEAR_WORK.timer_set_wait_upper = 120;
        gms_GMK_SPEAR_WORK.timer_set_wait_lower = 120;
        gms_GMK_SPEAR_WORK.timer_dec = ( int )eve_rec.height;
        if ( ( eve_rec.flag & 31 ) != 0 )
        {
            int num;
            if ( ( eve_rec.flag & 16 ) == 0 )
            {
                num = ( int )( eve_rec.flag & 15 ) << 10;
            }
            else
            {
                num = ( int )( -( int )( eve_rec.flag & 15 ) ) << 10;
                if ( num == 0 )
                {
                    num = -16384;
                }
            }
            gms_GMK_SPEAR_WORK.stroke_spd += num;
        }
        return obj_work;
    }
}
