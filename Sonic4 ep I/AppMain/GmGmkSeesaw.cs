using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000343 RID: 835
    public class GmkSeesawData
    {
        // Token: 0x04005E9D RID: 24221
        public const int GME_GMK_RECT_DATA_COL_WIDTH = 0;

        // Token: 0x04005E9E RID: 24222
        public const int GME_GMK_RECT_DATA_COL_HEIGHT = 1;

        // Token: 0x04005E9F RID: 24223
        public const int GME_GMK_RECT_DATA_COL_OFST_X = 2;

        // Token: 0x04005EA0 RID: 24224
        public const int GME_GMK_RECT_DATA_COL_OFST_Y = 3;

        // Token: 0x04005EA1 RID: 24225
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 0;

        // Token: 0x04005EA2 RID: 24226
        public const int GME_GMK_RECT_DATA_DEF_TOP = 1;

        // Token: 0x04005EA3 RID: 24227
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 2;

        // Token: 0x04005EA4 RID: 24228
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 3;

        // Token: 0x04005EA5 RID: 24229
        public const int GME_GMK_RECT_DATA_MAX = 4;

        // Token: 0x04005EA6 RID: 24230
        public const int GME_GMK_TYPE_SEESAW_0 = 0;

        // Token: 0x04005EA7 RID: 24231
        public const int GME_GMK_TYPE_SEESAW_30 = 1;

        // Token: 0x04005EA8 RID: 24232
        public const int GME_GMK_TYPE_SEESAW_330 = 2;

        // Token: 0x04005EA9 RID: 24233
        public const int GME_GMK_TYPE_MAX = 3;
    }

    // Token: 0x02000344 RID: 836
    public class GMS_GMK_SEESAW_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060025C1 RID: 9665 RVA: 0x0014E2E9 File Offset: 0x0014C4E9
        public GMS_GMK_SEESAW_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060025C2 RID: 9666 RVA: 0x0014E2FD File Offset: 0x0014C4FD
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060025C3 RID: 9667 RVA: 0x0014E30F File Offset: 0x0014C50F
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SEESAW_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060025C4 RID: 9668 RVA: 0x0014E321 File Offset: 0x0014C521
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_SEESAW_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x04005EAA RID: 24234
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04005EAB RID: 24235
        public ushort seesaw_id;

        // Token: 0x04005EAC RID: 24236
        public short initial_tilt;

        // Token: 0x04005EAD RID: 24237
        public short tilt;

        // Token: 0x04005EAE RID: 24238
        public short tilt_d;

        // Token: 0x04005EAF RID: 24239
        public short tilt_acc;

        // Token: 0x04005EB0 RID: 24240
        public short tilt_timer;

        // Token: 0x04005EB1 RID: 24241
        public short tilt_se_timer;

        // Token: 0x04005EB2 RID: 24242
        public int hold_x;

        // Token: 0x04005EB3 RID: 24243
        public int hold_y;

        // Token: 0x04005EB4 RID: 24244
        public long player_distance;

        // Token: 0x04005EB5 RID: 24245
        public int player_speed;

        // Token: 0x04005EB6 RID: 24246
        public AppMain.GMS_PLAYER_WORK ply_work;
    }

    // Token: 0x02000345 RID: 837
    public class GMS_GMK_SEESAWPARTS_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060025C5 RID: 9669 RVA: 0x0014E329 File Offset: 0x0014C529
        public GMS_GMK_SEESAWPARTS_WORK()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x060025C6 RID: 9670 RVA: 0x0014E33D File Offset: 0x0014C53D
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x060025C7 RID: 9671 RVA: 0x0014E34F File Offset: 0x0014C54F
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SEESAWPARTS_WORK work )
        {
            return work.eff_work.efct_com.obj_work;
        }

        // Token: 0x04005EB7 RID: 24247
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;
    }

    // Token: 0x060017A5 RID: 6053 RVA: 0x000D1484 File Offset: 0x000CF684
    private static AppMain.OBS_OBJECT_WORK GmGmkSeesaw0Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = AppMain.gmGmkSeesawInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SEESAW_WORK.tilt = 0;
        AppMain.gmGmkSeesawStart( gms_GMK_SEESAW_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_SEESAW_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x060017A6 RID: 6054 RVA: 0x000D14C8 File Offset: 0x000CF6C8
    private static AppMain.OBS_OBJECT_WORK GmGmkSeesaw30Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = AppMain.gmGmkSeesawInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SEESAW_WORK.tilt = 4608;
        AppMain.gmGmkSeesawStart( gms_GMK_SEESAW_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_SEESAW_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x060017A7 RID: 6055 RVA: 0x000D1510 File Offset: 0x000CF710
    private static AppMain.OBS_OBJECT_WORK GmGmkSeesaw330Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = AppMain.gmGmkSeesawInit(eve_rec, pos_x, pos_y, type);
        gms_GMK_SEESAW_WORK.tilt = -4608;
        AppMain.gmGmkSeesawStart( gms_GMK_SEESAW_WORK.gmk_work.ene_com.obj_work );
        return gms_GMK_SEESAW_WORK.gmk_work.ene_com.obj_work;
    }

    // Token: 0x060017A8 RID: 6056 RVA: 0x000D1558 File Offset: 0x000CF758
    public static void GmGmkSeesawBuild()
    {
        AppMain.gm_gmk_seesaw_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 876 ), AppMain.GmGameDatGetGimmickData( 877 ), 0U );
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.seesaw_alive[i] = 0;
        }
        AppMain.control_right = null;
    }

    // Token: 0x060017A9 RID: 6057 RVA: 0x000D15A0 File Offset: 0x000CF7A0
    public static void GmGmkSeesawFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(876);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_seesaw_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060017AA RID: 6058 RVA: 0x000D15C8 File Offset: 0x000CF7C8
    private static void gmGmkSeesawExitTCB( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = (AppMain.GMS_GMK_SEESAW_WORK)AppMain.mtTaskGetTcbWork(tcb);
        short[] array = AppMain.seesaw_alive;
        ushort seesaw_id = gms_GMK_SEESAW_WORK.seesaw_id;
        array[( int )seesaw_id] = ( short )( array[( int )seesaw_id] - 1 );
        if ( AppMain.control_right == gms_GMK_SEESAW_WORK )
        {
            AppMain.control_right = null;
            AppMain.lock_seesaw_id = 0;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060017AB RID: 6059 RVA: 0x000D161C File Offset: 0x000CF81C
    private static void gmGmkSeesawStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = (AppMain.GMS_GMK_SEESAW_WORK)obj_work;
        gms_GMK_SEESAW_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_SEESAW_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = null;
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -48, -24, 48, 0 );
        obs_RECT_WORK = gms_GMK_SEESAW_WORK.gmk_work.ene_com.rect_work[0];
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK.ppDef = null;
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -2, -2, 2, 2 );
        obj_work.flag &= 4294967293U;
        gms_GMK_SEESAW_WORK.initial_tilt = gms_GMK_SEESAW_WORK.tilt;
        gms_GMK_SEESAW_WORK.tilt_d = 0;
        gms_GMK_SEESAW_WORK.tilt_se_timer = 0;
        if ( AppMain.seesaw_alive[( int )gms_GMK_SEESAW_WORK.seesaw_id] == 0 )
        {
            AppMain.seesaw_tilt[( int )gms_GMK_SEESAW_WORK.seesaw_id] = gms_GMK_SEESAW_WORK.tilt;
        }
        else
        {
            gms_GMK_SEESAW_WORK.tilt = AppMain.seesaw_tilt[( int )gms_GMK_SEESAW_WORK.seesaw_id];
        }
        obj_work.dir.z = ( ushort )gms_GMK_SEESAW_WORK.tilt;
        short[] array = AppMain.seesaw_alive;
        ushort seesaw_id = gms_GMK_SEESAW_WORK.seesaw_id;
        array[( int )seesaw_id] = ( short )( array[( int )seesaw_id] + 1 );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkSeesawExitTCB ) );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSeesawStay );
    }

    // Token: 0x060017AC RID: 6060 RVA: 0x000D1788 File Offset: 0x000CF988
    private static void gmGmkSeesawStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = (AppMain.GMS_GMK_SEESAW_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( AppMain.lock_seesaw_id == gms_GMK_SEESAW_WORK.seesaw_id )
        {
            gms_GMK_SEESAW_WORK.tilt = AppMain.seesaw_tilt[( int )gms_GMK_SEESAW_WORK.seesaw_id];
            obj_work.dir.z = ( ushort )gms_GMK_SEESAW_WORK.tilt;
            gms_GMK_SEESAW_WORK.tilt_timer = 60;
        }
        else if ( gms_GMK_SEESAW_WORK.tilt != gms_GMK_SEESAW_WORK.initial_tilt )
        {
            if ( gms_GMK_SEESAW_WORK.tilt_timer <= 0 )
            {
                if ( gms_GMK_SEESAW_WORK.tilt > gms_GMK_SEESAW_WORK.initial_tilt )
                {
                    AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK2 = gms_GMK_SEESAW_WORK;
                    gms_GMK_SEESAW_WORK2.tilt -= 256;
                    if ( gms_GMK_SEESAW_WORK.tilt < gms_GMK_SEESAW_WORK.initial_tilt )
                    {
                        gms_GMK_SEESAW_WORK.tilt = gms_GMK_SEESAW_WORK.initial_tilt;
                    }
                }
                else if ( gms_GMK_SEESAW_WORK.tilt < gms_GMK_SEESAW_WORK.initial_tilt )
                {
                    AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK3 = gms_GMK_SEESAW_WORK;
                    gms_GMK_SEESAW_WORK3.tilt += 256;
                    if ( gms_GMK_SEESAW_WORK.tilt > gms_GMK_SEESAW_WORK.initial_tilt )
                    {
                        gms_GMK_SEESAW_WORK.tilt = gms_GMK_SEESAW_WORK.initial_tilt;
                    }
                }
            }
            else
            {
                AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK4 = gms_GMK_SEESAW_WORK;
                gms_GMK_SEESAW_WORK4.tilt_timer -= 1;
            }
        }
        obj_work.dir.z = ( ushort )gms_GMK_SEESAW_WORK.tilt;
        if ( gms_GMK_SEESAW_WORK.tilt == 0 )
        {
            gms_GMK_SEESAW_WORK.tilt = 0;
        }
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || ( gms_PLAYER_WORK.obj_work.flag & 2U ) != 0U || ( ( gms_PLAYER_WORK.obj_work.move_flag & 16U ) != 0U && gms_PLAYER_WORK.obj_work.spd.y < 0 ) )
        {
            return;
        }
        int num = AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 29;
        int num2 = AppMain.mtMathCos((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 29;
        int num3 = AppMain.mtMathCos((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 112 / 2;
        int num4 = AppMain.MTM_MATH_ABS(AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 112 / 2);
        int num5 = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
        if ( num5 >= -( num3 + 131072 - num ) && num5 <= num3 + 131072 + num )
        {
            int num6 = 0;
            int num7 = 0;
            long num8;
            long num9;
            if ( gms_PLAYER_WORK.obj_work.move.x == 0 )
            {
                if ( gms_PLAYER_WORK.obj_work.move.y == 0 )
                {
                    return;
                }
                num8 = ( long )gms_PLAYER_WORK.obj_work.pos.x;
                num9 = 0L;
            }
            else if ( gms_PLAYER_WORK.obj_work.move.y == 0 )
            {
                num8 = 0L;
                num9 = ( long )gms_PLAYER_WORK.obj_work.pos.y;
            }
            else
            {
                num8 = ( long )( ( long )gms_PLAYER_WORK.obj_work.move.y << 12 );
                num8 /= ( long )gms_PLAYER_WORK.obj_work.move.x;
                num9 = num8 * ( long )gms_PLAYER_WORK.obj_work.pos.x;
                num9 >>= 12;
                num9 = ( long )gms_PLAYER_WORK.obj_work.pos.y - num9;
            }
            long num10 = (long)AppMain.mtMathCos((int)((ushort)gms_GMK_SEESAW_WORK.tilt));
            long num11 = (long)AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt));
            num11 <<= 12;
            num10 = num11 / num10;
            num11 = num10 * ( long )( obj_work.pos.x + num );
            num11 >>= 12;
            num11 = ( long )( obj_work.pos.y - num2 ) - num11;
            if ( num8 != 0L && num8 == num10 )
            {
                num6 = gms_PLAYER_WORK.obj_work.pos.x;
                num7 = ( int )( ( num10 * ( long )num6 >> 12 ) + num11 );
            }
            else if ( num8 != 0L && num9 != 0L )
            {
                num6 = ( int )( ( num11 - num9 << 12 ) / ( num8 - num10 ) );
                num7 = ( int )( ( num10 * ( long )num6 >> 12 ) + num11 );
            }
            else if ( num8 == 0L )
            {
                num7 = ( int )num9;
                if ( num10 != 0L )
                {
                    num6 = ( int )( ( ( long )num7 - num11 << 12 ) / num10 );
                }
                else
                {
                    num6 = gms_PLAYER_WORK.obj_work.pos.x;
                }
            }
            else if ( num9 == 0L )
            {
                num6 = ( int )num8;
                num7 = ( int )( ( num10 * num8 >> 12 ) + num11 );
            }
            if ( obj_work.pos.x - ( num3 - num ) <= num6 && num6 <= obj_work.pos.x + ( num3 + num ) && obj_work.pos.y + ( num4 - num2 ) + 2 >= num7 && num7 >= obj_work.pos.y - ( num4 + num2 ) - 2 )
            {
                int num12 = gms_PLAYER_WORK.obj_work.pos.x - gms_PLAYER_WORK.obj_work.move.x;
                int num13 = gms_PLAYER_WORK.obj_work.pos.y - gms_PLAYER_WORK.obj_work.move.y;
                int x = gms_PLAYER_WORK.obj_work.pos.x;
                int num14 = gms_PLAYER_WORK.obj_work.pos.y;
                if ( num12 < x )
                {
                    AppMain.MTM_MATH_SWAP<int>( ref num12, ref x );
                }
                if ( num13 < num14 )
                {
                    AppMain.MTM_MATH_SWAP<int>( ref num13, ref num14 );
                }
                num13 += 1280;
                num14 -= 1280;
                if ( x <= num6 && num6 <= num12 && num13 >= num7 && num7 >= num14 )
                {
                    gms_GMK_SEESAW_WORK.ply_work = gms_PLAYER_WORK;
                    gms_GMK_SEESAW_WORK.hold_x = num6 - num;
                    gms_GMK_SEESAW_WORK.hold_y = num7;
                    if ( AppMain.control_right == null )
                    {
                        AppMain.gmGmkSeesaw_PlayerHold( obj_work );
                        return;
                    }
                    obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSeesaw_PlayerHold );
                }
            }
        }
    }

    // Token: 0x060017AD RID: 6061 RVA: 0x000D1C9C File Offset: 0x000CFE9C
    private static void gmGmkSeesaw_PlayerHold( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = (AppMain.GMS_GMK_SEESAW_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK ply_work = gms_GMK_SEESAW_WORK.ply_work;
        if ( AppMain.control_right != null )
        {
            if ( ( AppMain.control_right.gmk_work.ene_com.obj_work.pos.x >= obj_work.pos.x && ply_work.obj_work.spd.x >= 0 ) || ( AppMain.control_right.gmk_work.ene_com.obj_work.pos.x <= obj_work.pos.x && ply_work.obj_work.spd.x <= 0 ) )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSeesawStay );
                AppMain.gmGmkSeesawStay( obj_work );
                return;
            }
            gms_GMK_SEESAW_WORK.player_speed = AppMain.control_right.player_speed;
        }
        else
        {
            gms_GMK_SEESAW_WORK.player_speed = ply_work.obj_work.move.x / 2;
        }
        AppMain.GmPlySeqGmkInitSeesaw( ply_work, gms_GMK_SEESAW_WORK.gmk_work.ene_com );
        long num = (long)((long)(gms_GMK_SEESAW_WORK.hold_x - obj_work.pos.x) << 12);
        num /= ( long )AppMain.mtMathCos( ( int )gms_GMK_SEESAW_WORK.tilt );
        gms_GMK_SEESAW_WORK.player_distance = num;
        AppMain.control_right = gms_GMK_SEESAW_WORK;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSeesaw_PlayerHold_100 );
        AppMain.gmGmkSeesaw_PlayerHold_100( obj_work );
    }

    // Token: 0x060017AE RID: 6062 RVA: 0x000D1DDC File Offset: 0x000CFFDC
    private static void gmGmkSeesaw_PlayerHold_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = (AppMain.GMS_GMK_SEESAW_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK ply_work = gms_GMK_SEESAW_WORK.ply_work;
        AppMain.lock_seesaw_id = 0;
        if ( ply_work.seq_state != 44 || AppMain.control_right != gms_GMK_SEESAW_WORK || ( ply_work.obj_work.move_flag & 256U ) != 0U )
        {
            gms_GMK_SEESAW_WORK.tilt_d = 0;
            gms_GMK_SEESAW_WORK.tilt_se_timer = 0;
            if ( AppMain.control_right == gms_GMK_SEESAW_WORK )
            {
                AppMain.control_right = null;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSeesawStay );
            AppMain.gmGmkSeesawStay( obj_work );
            return;
        }
        AppMain.lock_seesaw_id = gms_GMK_SEESAW_WORK.seesaw_id;
        gms_GMK_SEESAW_WORK.tilt_timer = 60;
        AppMain.control_right = gms_GMK_SEESAW_WORK;
        int num = AppMain.GmPlayerKeyGetGimmickRotZ(gms_GMK_SEESAW_WORK.ply_work);
        if ( num > 256 )
        {
            num = 256;
        }
        if ( num < -256 )
        {
            num = -256;
        }
        gms_GMK_SEESAW_WORK.tilt_d = ( short )num;
        if ( gms_GMK_SEESAW_WORK.tilt_d != 0 )
        {
            AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK2 = gms_GMK_SEESAW_WORK;
            gms_GMK_SEESAW_WORK2.tilt += gms_GMK_SEESAW_WORK.tilt_d;
            if ( gms_GMK_SEESAW_WORK.tilt_se_timer == 0 )
            {
                AppMain.GmSoundPlaySE( "Seesaw" );
                gms_GMK_SEESAW_WORK.tilt_se_timer = 8;
            }
            AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK3 = gms_GMK_SEESAW_WORK;
            gms_GMK_SEESAW_WORK3.tilt_se_timer -= 1;
            if ( gms_GMK_SEESAW_WORK.tilt >= 4608 )
            {
                gms_GMK_SEESAW_WORK.tilt = 4608;
                gms_GMK_SEESAW_WORK.tilt_d = 0;
            }
            if ( gms_GMK_SEESAW_WORK.tilt <= -4608 )
            {
                gms_GMK_SEESAW_WORK.tilt = -4608;
                gms_GMK_SEESAW_WORK.tilt_d = 0;
            }
        }
        obj_work.dir.z = ( ushort )gms_GMK_SEESAW_WORK.tilt;
        AppMain.seesaw_tilt[( int )gms_GMK_SEESAW_WORK.seesaw_id] = ( short )obj_work.dir.z;
        if ( ( ply_work.obj_work.move_flag & 4U ) != 0U )
        {
            int num2 = AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 29;
            num2 = obj_work.pos.x + num2;
            num2 = ply_work.obj_work.pos.x - num2;
            long num3 = (long)((long)num2 << 12);
            num3 /= ( long )AppMain.mtMathCos( ( int )gms_GMK_SEESAW_WORK.tilt );
            gms_GMK_SEESAW_WORK.player_distance = num3;
            if ( ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && gms_GMK_SEESAW_WORK.player_speed > 0 ) || ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && gms_GMK_SEESAW_WORK.player_speed < 0 ) )
            {
                gms_GMK_SEESAW_WORK.player_speed = 0;
            }
        }
        long num4 = gms_GMK_SEESAW_WORK.player_distance;
        gms_GMK_SEESAW_WORK.player_distance += ( long )gms_GMK_SEESAW_WORK.player_speed;
        num4 = gms_GMK_SEESAW_WORK.player_distance - num4;
        gms_GMK_SEESAW_WORK.player_speed += 256 * AppMain.mtMathSin( ( int )( ( ushort )gms_GMK_SEESAW_WORK.tilt ) ) >> 12;
        int num5 = AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 29;
        num5 = obj_work.pos.x + num5;
        int num6 = AppMain.mtMathCos((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) * 29;
        num6 = obj_work.pos.y - num6;
        int num7 = (int)(gms_GMK_SEESAW_WORK.player_distance * (long)AppMain.mtMathCos((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) >> 12);
        num7 = num5 + num7;
        int num8 = (int)(gms_GMK_SEESAW_WORK.player_distance * (long)AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) >> 12);
        num8 = num6 + num8;
        if ( gms_GMK_SEESAW_WORK.player_speed < 0 && ( ply_work.obj_work.disp_flag & 1U ) == 0U )
        {
            ply_work.obj_work.disp_flag |= 1U;
        }
        else if ( gms_GMK_SEESAW_WORK.player_speed > 0 && ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            ply_work.obj_work.disp_flag &= 4294967294U;
        }
        if ( gms_GMK_SEESAW_WORK.player_distance <= 231424L && gms_GMK_SEESAW_WORK.player_distance >= -231424L )
        {
            ply_work.obj_work.spd.x = num7 - ply_work.obj_work.pos.x;
            ply_work.obj_work.spd.y = num8 - ply_work.obj_work.pos.y;
            return;
        }
        int num9 = (int)(num4 * (long)AppMain.mtMathCos((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) >> 12);
        int spdy = (int)(num4 * (long)AppMain.mtMathSin((int)((ushort)gms_GMK_SEESAW_WORK.tilt)) >> 12);
        if ( AppMain.MTM_MATH_ABS( num9 ) < 256 )
        {
            if ( num9 < 0 )
            {
                num9 = -1024;
            }
            else
            {
                num9 = 1024;
            }
        }
        AppMain.GmPlySeqGmkInitSeesawEnd( ply_work, num9, spdy );
        gms_GMK_SEESAW_WORK.tilt_d = 0;
        AppMain.control_right = null;
        AppMain.lock_seesaw_id = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSeesawStay );
    }

    // Token: 0x060017AF RID: 6063 RVA: 0x000D21F4 File Offset: 0x000D03F4
    private static void gmGmkSeesaw_CreateParts( AppMain.GMS_GMK_SEESAW_WORK pwork )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)pwork;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_SEESAWPARTS_WORK(), null, 0, "Gmk_SeesawParts");
        AppMain.GMS_GMK_SEESAWPARTS_WORK gms_GMK_SEESAWPARTS_WORK = (AppMain.GMS_GMK_SEESAWPARTS_WORK)obs_OBJECT_WORK2;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_seesaw_obj_3d_list[1], gms_GMK_SEESAWPARTS_WORK.eff_work.obj_3d );
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.flag &= 4294966271U;
        obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK.pos.x;
        obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK.pos.y;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK.pos.z + 4096;
        obs_OBJECT_WORK2.disp_flag |= 4194304U;
        obs_OBJECT_WORK2.disp_flag |= 256U;
        obs_OBJECT_WORK2.flag |= 2U;
        obs_OBJECT_WORK2.ppFunc = null;
    }

    // Token: 0x060017B0 RID: 6064 RVA: 0x000D22F4 File Offset: 0x000D04F4
    private static AppMain.GMS_GMK_SEESAW_WORK gmGmkSeesawInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_GMK_SEESAW_WORK gms_GMK_SEESAW_WORK = (AppMain.GMS_GMK_SEESAW_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SEESAW_WORK(), "Gmk_Seesaw");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_SEESAW_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_SEESAW_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_seesaw_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -4096;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_SEESAW_WORK.seesaw_id = ( ushort )eve_rec.left;
        AppMain.gmGmkSeesaw_CreateParts( gms_GMK_SEESAW_WORK );
        return gms_GMK_SEESAW_WORK;
    }
}
