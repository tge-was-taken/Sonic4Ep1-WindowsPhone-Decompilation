using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000030 RID: 48
    public class GMS_GMK_SLOT_REEL_STATUS_WORK
    {
        // Token: 0x04004810 RID: 18448
        public short reel;

        // Token: 0x04004811 RID: 18449
        public int reel_spd;

        // Token: 0x04004812 RID: 18450
        public int reel_acc;

        // Token: 0x04004813 RID: 18451
        public int reel_time;

        // Token: 0x04004814 RID: 18452
        public int reel_target_pos;

        // Token: 0x04004815 RID: 18453
        public int reel_target_mark;

        // Token: 0x04004816 RID: 18454
        public int reel_extime;

        // Token: 0x04004817 RID: 18455
        public int reel_se;
    }

    // Token: 0x02000032 RID: 50
    public class GMS_GMK_SLOT_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001D3A RID: 7482 RVA: 0x0013723D File Offset: 0x0013543D
        public GMS_GMK_SLOT_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001D3B RID: 7483 RVA: 0x00137269 File Offset: 0x00135469
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SLOT_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001D3C RID: 7484 RVA: 0x0013727B File Offset: 0x0013547B
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001D3D RID: 7485 RVA: 0x0013728D File Offset: 0x0013548D
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_SLOT_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x04004818 RID: 18456
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004819 RID: 18457
        public readonly AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK[] reel_status = AppMain.New<AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK>(3);

        // Token: 0x0400481A RID: 18458
        public int current_reel;

        // Token: 0x0400481B RID: 18459
        public int slot_id;

        // Token: 0x0400481C RID: 18460
        public int timer;

        // Token: 0x0400481D RID: 18461
        public int timer_next;

        // Token: 0x0400481E RID: 18462
        public int timer_meoshi_wait;

        // Token: 0x0400481F RID: 18463
        public int slot_step;

        // Token: 0x04004820 RID: 18464
        public int slot_se;

        // Token: 0x04004821 RID: 18465
        public int slot_se_timer;

        // Token: 0x04004822 RID: 18466
        public int suberi_cnt;

        // Token: 0x04004823 RID: 18467
        public int suberi_input;

        // Token: 0x04004824 RID: 18468
        public readonly short[] prob = new short[5];

        // Token: 0x04004825 RID: 18469
        public short lotresult;

        // Token: 0x04004826 RID: 18470
        public int freestop;

        // Token: 0x04004827 RID: 18471
        public int ppos_x;

        // Token: 0x04004828 RID: 18472
        public int ppos_y;
    }

    // Token: 0x02000033 RID: 51
    public class GMS_GMK_SLOTPARTS_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001D3E RID: 7486 RVA: 0x00137295 File Offset: 0x00135495
        public GMS_GMK_SLOTPARTS_WORK()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x06001D3F RID: 7487 RVA: 0x001372A9 File Offset: 0x001354A9
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SLOTPARTS_WORK work )
        {
            return work.eff_work.efct_com.obj_work;
        }

        // Token: 0x06001D40 RID: 7488 RVA: 0x001372BB File Offset: 0x001354BB
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x04004829 RID: 18473
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x0400482A RID: 18474
        public AppMain.GMS_GMK_SLOT_WORK slot_work;

        // Token: 0x0400482B RID: 18475
        public int reel_id;

        // Token: 0x0400482C RID: 18476
        public float tex_v;
    }

    // Token: 0x0600005D RID: 93 RVA: 0x00004C34 File Offset: 0x00002E34
    private static void gmGmkSlot_ReelControl( AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK preel )
    {
        if ( preel.reel_time > 0 )
        {
            preel.reel_time--;
        }
        if ( preel.reel_time <= 0 && preel.reel_acc != 0 )
        {
            preel.reel_spd += preel.reel_acc;
            if ( preel.reel_spd > ( int )AppMain.GMD_GMK_SLOT_REEL_MAX_SPEED )
            {
                preel.reel_spd = ( int )AppMain.GMD_GMK_SLOT_REEL_MAX_SPEED;
                preel.reel_acc = 0;
            }
            else if ( preel.reel_spd < 0 )
            {
                preel.reel_spd = 0;
                preel.reel_acc = 0;
            }
        }
        preel.reel += ( short )preel.reel_spd;
    }

    // Token: 0x0600005E RID: 94 RVA: 0x00004CCC File Offset: 0x00002ECC
    private static void gmGmkSlotStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        gms_GMK_SLOT_WORK.reel_status[0].reel = ( short )( AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT * 15 );
        AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK gms_GMK_SLOT_REEL_STATUS_WORK = gms_GMK_SLOT_WORK.reel_status[1];
        short gmd_GMK_SLOT_REEL1KOMA_HEIGHT = AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT;
        gms_GMK_SLOT_REEL_STATUS_WORK.reel = ( short )0;
        gms_GMK_SLOT_WORK.reel_status[2].reel = AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT;
        gms_GMK_SLOT_WORK.reel_status[0].reel_spd = 0;
        gms_GMK_SLOT_WORK.reel_status[1].reel_spd = 0;
        gms_GMK_SLOT_WORK.reel_status[2].reel_spd = 0;
        gms_GMK_SLOT_WORK.reel_status[0].reel_acc = 0;
        gms_GMK_SLOT_WORK.reel_status[1].reel_acc = 0;
        gms_GMK_SLOT_WORK.reel_status[2].reel_acc = 0;
        gms_GMK_SLOT_WORK.reel_status[0].reel_time = 0;
        gms_GMK_SLOT_WORK.reel_status[1].reel_time = 0;
        gms_GMK_SLOT_WORK.reel_status[2].reel_time = 0;
        gms_GMK_SLOT_WORK.prob[0] = AppMain.GMD_GMK_SLOT_PROB_JJJ;
        gms_GMK_SLOT_WORK.prob[1] = AppMain.GMD_GMK_SLOT_PROB_EEE;
        gms_GMK_SLOT_WORK.prob[2] = AppMain.GMD_GMK_SLOT_PROB_SSS;
        gms_GMK_SLOT_WORK.prob[4] = AppMain.GMD_GMK_SLOT_PROB_BBB;
        gms_GMK_SLOT_WORK.prob[3] = AppMain.GMD_GMK_SLOT_PROB_RRR;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotStay );
    }

    // Token: 0x0600005F RID: 95 RVA: 0x00004DF0 File Offset: 0x00002FF0
    private static void gmGmkSlotStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        AppMain.rand_result <<= 16;
        AppMain.rand_result += ( uint )AppMain.mtMathRand();
        if ( AppMain.slot_start_call == gms_GMK_SLOT_WORK.slot_id )
        {
            AppMain.gmGmkSlotGameStart( obj_work );
        }
    }

    // Token: 0x06000060 RID: 96 RVA: 0x00004E34 File Offset: 0x00003034
    private static uint getRand()
    {
        AppMain.rand_result = AppMain.rand_result % 13U * 330382099U + AppMain.rand_result / 13U;
        return AppMain.rand_result;
    }

    // Token: 0x06000061 RID: 97 RVA: 0x00004E58 File Offset: 0x00003058
    private static void gmGmkSlotGameStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        gms_GMK_SLOT_WORK.slot_step = 0;
        gms_GMK_SLOT_WORK.current_reel = 0;
        gms_GMK_SLOT_WORK.slot_se_timer = 0;
        int num = (int)(AppMain.rand_result % 100U);
        num -= ( int )AppMain.GMD_GMK_SLOT_1ST_LOT;
        if ( num >= 0 )
        {
            num = num * 100 / ( int )( 100 - AppMain.GMD_GMK_SLOT_1ST_LOT );
            int i;
            for ( i = 0; i < 5; i++ )
            {
                num -= ( int )gms_GMK_SLOT_WORK.prob[i];
                if ( num <= 0 )
                {
                    gms_GMK_SLOT_WORK.prob[i] = AppMain.tbl_gmk_slot_prob[i];
                    break;
                }
                if ( gms_GMK_SLOT_WORK.prob[i] < AppMain.tbl_gmk_slot_prob_max[i] )
                {
                    short[] prob = gms_GMK_SLOT_WORK.prob;
                    int num2 = i;
                    prob[num2] += AppMain.tbl_gmk_slot_prob[i];
                    if ( gms_GMK_SLOT_WORK.prob[i] > AppMain.tbl_gmk_slot_prob_max[i] )
                    {
                        gms_GMK_SLOT_WORK.prob[i] = AppMain.tbl_gmk_slot_prob_max[i];
                    }
                }
            }
            gms_GMK_SLOT_WORK.lotresult = ( short )i;
            if ( i != 5 )
            {
                gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark = ( gms_GMK_SLOT_WORK.reel_status[1].reel_target_mark = ( gms_GMK_SLOT_WORK.reel_status[2].reel_target_mark = i ) );
            }
            else
            {
                int num3 = 0;
                for ( i = 0; i < 3; i++ )
                {
                    gms_GMK_SLOT_WORK.reel_status[i].reel_target_mark = ( int )( AppMain.getRand() % 5U );
                    if ( gms_GMK_SLOT_WORK.reel_status[i].reel_target_mark == 4 )
                    {
                        num3++;
                    }
                }
                int num4 = (int)(AppMain.getRand() % 3U);
                if ( num3 <= 1 )
                {
                    gms_GMK_SLOT_WORK.lotresult = 5;
                    if ( num3 == 0 )
                    {
                        gms_GMK_SLOT_WORK.reel_status[num4].reel_target_mark = 4;
                    }
                }
                else if ( num3 >= 2 )
                {
                    gms_GMK_SLOT_WORK.lotresult = 6;
                    if ( num3 == 3 )
                    {
                        gms_GMK_SLOT_WORK.reel_status[num4].reel_target_mark = ( int )( AppMain.getRand() % 4U );
                    }
                }
            }
        }
        else if ( num < ( int )( -( int )AppMain.GMD_GMK_SLOT_EGG_LOT ) )
        {
            gms_GMK_SLOT_WORK.lotresult = -1;
            for ( int j = 0; j < 3; j++ )
            {
                gms_GMK_SLOT_WORK.reel_status[j].reel_target_mark = ( int )( AppMain.getRand() % 4U );
            }
            if ( gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == gms_GMK_SLOT_WORK.reel_status[1].reel_target_mark && gms_GMK_SLOT_WORK.reel_status[1].reel_target_mark == gms_GMK_SLOT_WORK.reel_status[2].reel_target_mark )
            {
                if ( gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == 1 )
                {
                    gms_GMK_SLOT_WORK.lotresult = 8;
                }
                else
                {
                    int num5;
                    do
                    {
                        num5 = ( int )( AppMain.getRand() % 4U );
                    }
                    while ( gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == num5 );
                    gms_GMK_SLOT_WORK.reel_status[2].reel_target_mark = num5;
                }
            }
        }
        else
        {
            gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark = ( gms_GMK_SLOT_WORK.reel_status[1].reel_target_mark = ( gms_GMK_SLOT_WORK.reel_status[2].reel_target_mark = 1 ) );
            gms_GMK_SLOT_WORK.lotresult = 8;
        }
        for ( int k = 0; k < 3; k++ )
        {
            ushort num6 = (ushort)AppMain.getRand();
            do
            {
                num6 = ( ushort )( ( num6 + 1 ) % ( ushort )AppMain.GMD_GMK_SLOT_REEL_ALLMARK );
                gms_GMK_SLOT_WORK.reel_status[k].reel_target_pos = ( int )num6;
            }
            while ( ( int )AppMain.tbl_gmk_reel_mark[k][( int )( AppMain.GMD_GMK_SLOT_REEL_ALLMARK - ( short )num6 & 15 )] != gms_GMK_SLOT_WORK.reel_status[k].reel_target_mark );
        }
        gms_GMK_SLOT_WORK.freestop = 0;
        AppMain.gmGmkSlotGameStart_100( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameStart_100 );
    }

    // Token: 0x06000062 RID: 98 RVA: 0x00005164 File Offset: 0x00003364
    private static void gmGmkSlotGameStart_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        if ( gms_GMK_SLOT_WORK.timer <= 0 )
        {
            AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK gms_GMK_SLOT_REEL_STATUS_WORK = gms_GMK_SLOT_WORK.reel_status[gms_GMK_SLOT_WORK.current_reel];
            int slot_step = gms_GMK_SLOT_WORK.slot_step;
            if ( slot_step <= 30 )
            {
                if ( slot_step <= 10 )
                {
                    if ( slot_step != 0 )
                    {
                        if ( slot_step == 10 )
                        {
                            gms_GMK_SLOT_WORK.current_reel = 0;
                            gms_GMK_SLOT_WORK.slot_step = 40;
                            gms_GMK_SLOT_WORK.timer_next = 0;
                            gms_GMK_SLOT_WORK.freestop = 1;
                            gms_GMK_SLOT_WORK.timer = 0;
                        }
                    }
                    else
                    {
                        gms_GMK_SLOT_WORK.reel_status[0].reel_time = 0;
                        gms_GMK_SLOT_WORK.reel_status[1].reel_time = 15;
                        gms_GMK_SLOT_WORK.reel_status[2].reel_time = 30;
                        gms_GMK_SLOT_WORK.reel_status[0].reel_acc = ( int )AppMain.GMD_GMK_SLOT_REEL_ACC;
                        gms_GMK_SLOT_WORK.reel_status[1].reel_acc = ( int )AppMain.GMD_GMK_SLOT_REEL_ACC;
                        gms_GMK_SLOT_WORK.reel_status[2].reel_acc = ( int )AppMain.GMD_GMK_SLOT_REEL_ACC;
                        gms_GMK_SLOT_WORK.timer = 10;
                        gms_GMK_SLOT_WORK.timer += ( int )( AppMain.mtMathRand() % 1 );
                        gms_GMK_SLOT_WORK.slot_step = 10;
                    }
                }
                else if ( slot_step != 20 )
                {
                    if ( slot_step == 30 )
                    {
                        gms_GMK_SLOT_WORK.current_reel = 2;
                        if ( gms_GMK_SLOT_WORK.timer < 0 )
                        {
                            gms_GMK_SLOT_WORK.slot_step = 80;
                        }
                        else if ( gms_GMK_SLOT_WORK.freestop != 0 )
                        {
                            if ( gms_GMK_SLOT_WORK.lotresult < 0 || gms_GMK_SLOT_WORK.lotresult == 5 || gms_GMK_SLOT_WORK.lotresult == 6 )
                            {
                                gms_GMK_SLOT_WORK.timer = 0;
                                gms_GMK_SLOT_WORK.slot_step = 40;
                            }
                            else
                            {
                                gms_GMK_SLOT_WORK.timer = 60;
                                if ( gms_GMK_SLOT_WORK.lotresult != 8 )
                                {
                                    gms_GMK_SLOT_WORK.slot_step = 50;
                                }
                                else
                                {
                                    gms_GMK_SLOT_WORK.slot_step = 60;
                                }
                            }
                        }
                        else
                        {
                            gms_GMK_SLOT_WORK.timer = 0;
                            gms_GMK_SLOT_WORK.slot_step = 40;
                        }
                    }
                }
                else
                {
                    gms_GMK_SLOT_WORK.current_reel = 1;
                    gms_GMK_SLOT_WORK.slot_step = 40;
                    gms_GMK_SLOT_WORK.timer_next = 0;
                    gms_GMK_SLOT_WORK.freestop = 1;
                    gms_GMK_SLOT_WORK.timer = 0;
                }
            }
            else if ( slot_step <= 51 )
            {
                switch ( slot_step )
                {
                    case 40:
                        if ( gms_GMK_SLOT_WORK.freestop == 0 )
                        {
                            gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = ( int )AppMain.GMD_GMK_SLOT_REEL_MIN_SPEED;
                            gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = 0;
                            gms_GMK_SLOT_WORK.timer = 0;
                            gms_GMK_SLOT_WORK.slot_step = 71;
                            goto IL_825;
                        }
                        gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = ( int )( -( int )AppMain.GMD_GMK_SLOT_REEL_BRAKE );
                        gms_GMK_SLOT_WORK.slot_step++;
                        break;
                    case 41:
                        break;
                    default:
                        switch ( slot_step )
                        {
                            case 50:
                                gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = ( int )( -AppMain.GMD_GMK_SLOT_REEL_BRAKE / 2 );
                                gms_GMK_SLOT_WORK.slot_step++;
                                break;
                            case 51:
                                break;
                            default:
                                goto IL_825;
                        }
                        if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd <= ( int )AppMain.GMD_GMK_SLOT_REEL_MIN_SPEED + gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc )
                        {
                            gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = ( int )AppMain.GMD_GMK_SLOT_REEL_MIN_SPEED;
                            gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = 0;
                            gms_GMK_SLOT_WORK.timer = 30;
                            gms_GMK_SLOT_WORK.slot_step = 70;
                            goto IL_825;
                        }
                        goto IL_825;
                }
                if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd <= ( int )AppMain.GMD_GMK_SLOT_REEL_MIN_SPEED + gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc )
                {
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = ( int )AppMain.GMD_GMK_SLOT_REEL_MIN_SPEED;
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = 0;
                    gms_GMK_SLOT_WORK.timer = 0;
                    gms_GMK_SLOT_WORK.slot_step = 70;
                }
            }
            else
            {
                int num;
                switch ( slot_step )
                {
                    case 60:
                        gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = ( int )( -AppMain.GMD_GMK_SLOT_REEL_BRAKE / 2 );
                        gms_GMK_SLOT_WORK.slot_step++;
                        break;
                    case 61:
                        break;
                    case 62:
                        num = ( int )( ( ushort )gms_GMK_SLOT_REEL_STATUS_WORK.reel / ( ushort )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT % ( ushort )AppMain.GMD_GMK_SLOT_REEL_ALLMARK );
                        if ( num == gms_GMK_SLOT_REEL_STATUS_WORK.reel_target_pos )
                        {
                            gms_GMK_SLOT_WORK.slot_step = 69;
                            gms_GMK_SLOT_REEL_STATUS_WORK.reel = ( short )( ( int )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT * num );
                            gms_GMK_SLOT_WORK.lotresult = 1;
                            goto IL_825;
                        }
                        goto IL_825;
                    case 63:
                    case 64:
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                        goto IL_825;
                    case 69:
                        goto IL_431;
                    case 70:
                        if ( ( ushort )gms_GMK_SLOT_REEL_STATUS_WORK.reel / ( ushort )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT != ( ushort )( ( int )gms_GMK_SLOT_REEL_STATUS_WORK.reel - gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd ) / ( ushort )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT )
                        {
                            goto IL_403;
                        }
                        goto IL_825;
                    case 71:
                        goto IL_403;
                    case 72:
                        goto IL_44A;
                    default:
                        switch ( slot_step )
                        {
                            case 80:
                                {
                                    if ( ( ushort )gms_GMK_SLOT_REEL_STATUS_WORK.reel / ( ushort )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT == ( ushort )( ( int )gms_GMK_SLOT_REEL_STATUS_WORK.reel - gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd ) / ( ushort )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT )
                                    {
                                        goto IL_825;
                                    }
                                    AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK gms_GMK_SLOT_REEL_STATUS_WORK2 = gms_GMK_SLOT_REEL_STATUS_WORK;
                                    gms_GMK_SLOT_REEL_STATUS_WORK2.reel &= -4096;
                                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_target_pos = ( int )gms_GMK_SLOT_REEL_STATUS_WORK.reel;
                                    int num2 = (int)(16 - (ushort)gms_GMK_SLOT_REEL_STATUS_WORK.reel / (ushort)AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT & 15);
                                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_target_mark = ( int )AppMain.tbl_gmk_reel_mark[gms_GMK_SLOT_WORK.current_reel][num2];
                                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime = 8;
                                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = ( int )AppMain.GMD_GMK_SLOT_REEL_MIN_SPEED;
                                    AppMain.GmSoundPlaySE( "Casino5" );
                                    gms_GMK_SLOT_WORK.slot_step = 81;
                                    break;
                                }
                            case 81:
                                break;
                            default:
                                goto IL_825;
                        }
                        if ( ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime & 1 ) == 0 )
                        {
                            if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime == 4 )
                            {
                                gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd /= 2;
                            }
                            gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = -gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd;
                        }
                        gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime--;
                        if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime != 0 )
                        {
                            goto IL_825;
                        }
                        gms_GMK_SLOT_REEL_STATUS_WORK.reel = ( short )gms_GMK_SLOT_REEL_STATUS_WORK.reel_target_pos;
                        gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = 0;
                        if ( gms_GMK_SLOT_WORK.current_reel == 0 )
                        {
                            gms_GMK_SLOT_WORK.timer = gms_GMK_SLOT_WORK.timer_next;
                            gms_GMK_SLOT_WORK.timer += ( int )( AppMain.mtMathRand() % 1 );
                            gms_GMK_SLOT_WORK.slot_step = 20;
                            goto IL_825;
                        }
                        if ( gms_GMK_SLOT_WORK.current_reel == 1 )
                        {
                            gms_GMK_SLOT_WORK.timer = gms_GMK_SLOT_WORK.timer_next;
                            gms_GMK_SLOT_WORK.timer += ( int )( AppMain.mtMathRand() % 1 );
                            gms_GMK_SLOT_WORK.slot_step = 30;
                            goto IL_825;
                        }
                        if ( gms_GMK_SLOT_WORK.current_reel != 2 )
                        {
                            goto IL_825;
                        }
                        if ( gms_GMK_SLOT_WORK.lotresult == 9 )
                        {
                            if ( gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == gms_GMK_SLOT_WORK.reel_status[1].reel_target_mark && gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == gms_GMK_SLOT_WORK.reel_status[2].reel_target_mark )
                            {
                                gms_GMK_SLOT_WORK.lotresult = ( short )gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark;
                            }
                            else
                            {
                                int num3 = 5;
                                for ( int i = 0; i < 3; i++ )
                                {
                                    if ( gms_GMK_SLOT_WORK.reel_status[i].reel_target_mark == 4 )
                                    {
                                        gms_GMK_SLOT_WORK.lotresult = ( short )num3;
                                        num3++;
                                    }
                                }
                            }
                        }
                        if ( gms_GMK_SLOT_WORK.lotresult < 0 || gms_GMK_SLOT_WORK.lotresult == 9 )
                        {
                            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameLose );
                            goto IL_825;
                        }
                        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameHit );
                        goto IL_825;
                }
                if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd <= ( int )AppMain.GMD_GMK_SLOT_REEL_EGG_SPEED + gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc )
                {
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = ( int )AppMain.GMD_GMK_SLOT_REEL_EGG_SPEED;
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_acc = 0;
                    gms_GMK_SLOT_WORK.slot_step++;
                    gms_GMK_SLOT_WORK.suberi_cnt = 0;
                    gms_GMK_SLOT_WORK.suberi_input = 0;
                    goto IL_825;
                }
                goto IL_825;
                IL_403:
                num = ( int )( ( ushort )gms_GMK_SLOT_REEL_STATUS_WORK.reel / ( ushort )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT % ( ushort )AppMain.GMD_GMK_SLOT_REEL_ALLMARK );
                if ( num != gms_GMK_SLOT_REEL_STATUS_WORK.reel_target_pos )
                {
                    goto IL_825;
                }
                gms_GMK_SLOT_REEL_STATUS_WORK.reel = ( short )( ( int )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT * num );
                IL_431:
                gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime = 8;
                AppMain.GmSoundPlaySE( "Casino5" );
                gms_GMK_SLOT_WORK.slot_step = 72;
                IL_44A:
                if ( ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime & 1 ) == 0 )
                {
                    if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime == 4 )
                    {
                        gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd /= 2;
                    }
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = -gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd;
                }
                gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime--;
                if ( gms_GMK_SLOT_REEL_STATUS_WORK.reel_extime == 0 )
                {
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel = ( short )( ( int )AppMain.GMD_GMK_SLOT_REEL1KOMA_HEIGHT * gms_GMK_SLOT_REEL_STATUS_WORK.reel_target_pos );
                    gms_GMK_SLOT_REEL_STATUS_WORK.reel_spd = 0;
                    if ( gms_GMK_SLOT_WORK.current_reel == 0 )
                    {
                        gms_GMK_SLOT_WORK.timer = gms_GMK_SLOT_WORK.timer_next;
                        gms_GMK_SLOT_WORK.timer += ( int )( AppMain.mtMathRand() % 1 );
                        gms_GMK_SLOT_WORK.slot_step = 20;
                    }
                    else if ( gms_GMK_SLOT_WORK.current_reel == 1 )
                    {
                        gms_GMK_SLOT_WORK.timer = gms_GMK_SLOT_WORK.timer_next;
                        gms_GMK_SLOT_WORK.timer += ( int )( AppMain.mtMathRand() % 1 );
                        gms_GMK_SLOT_WORK.slot_step = 30;
                    }
                    else if ( gms_GMK_SLOT_WORK.current_reel == 2 )
                    {
                        if ( gms_GMK_SLOT_WORK.lotresult == 9 )
                        {
                            if ( gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == gms_GMK_SLOT_WORK.reel_status[1].reel_target_mark && gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark == gms_GMK_SLOT_WORK.reel_status[2].reel_target_mark )
                            {
                                gms_GMK_SLOT_WORK.lotresult = ( short )gms_GMK_SLOT_WORK.reel_status[0].reel_target_mark;
                            }
                            else
                            {
                                int num4 = 5;
                                for ( int j = 0; j < 3; j++ )
                                {
                                    if ( gms_GMK_SLOT_WORK.reel_status[j].reel_target_mark == 4 )
                                    {
                                        gms_GMK_SLOT_WORK.lotresult = ( short )num4;
                                        num4++;
                                    }
                                }
                            }
                        }
                        if ( gms_GMK_SLOT_WORK.lotresult < 0 || gms_GMK_SLOT_WORK.lotresult == 9 )
                        {
                            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameLose );
                        }
                        else
                        {
                            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameHit );
                        }
                    }
                }
            }
        }
        else
        {
            gms_GMK_SLOT_WORK.timer--;
        }
        IL_825:
        if ( gms_GMK_SLOT_WORK.slot_se_timer > 0 )
        {
            gms_GMK_SLOT_WORK.slot_se_timer--;
        }
        for ( int k = 0; k < 3; k++ )
        {
            AppMain.GMS_GMK_SLOT_REEL_STATUS_WORK gms_GMK_SLOT_REEL_STATUS_WORK3 = gms_GMK_SLOT_WORK.reel_status[k];
            if ( gms_GMK_SLOT_REEL_STATUS_WORK3.reel_spd != 0 )
            {
                short num5 = (short)((int)gms_GMK_SLOT_REEL_STATUS_WORK3.reel + gms_GMK_SLOT_REEL_STATUS_WORK3.reel_spd);
                if ( num5 / 4096 != gms_GMK_SLOT_REEL_STATUS_WORK3.reel / 4096 && ( int )( num5 & -4096 ) != gms_GMK_SLOT_REEL_STATUS_WORK3.reel_se && gms_GMK_SLOT_WORK.slot_se_timer <= 0 )
                {
                    AppMain.GmSoundPlaySE( "Casino4" );
                    gms_GMK_SLOT_WORK.slot_se_timer = 3;
                }
                gms_GMK_SLOT_REEL_STATUS_WORK3.reel_se = ( int )( num5 & -4096 );
            }
        }
        AppMain.gmGmkSlot_ReelControl( gms_GMK_SLOT_WORK.reel_status[0] );
        AppMain.gmGmkSlot_ReelControl( gms_GMK_SLOT_WORK.reel_status[1] );
        AppMain.gmGmkSlot_ReelControl( gms_GMK_SLOT_WORK.reel_status[2] );
    }

    // Token: 0x06000063 RID: 99 RVA: 0x00005A60 File Offset: 0x00003C60
    private static void gmGmkSlotGameHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        if ( gms_GMK_SLOT_WORK.lotresult != 1 )
        {
            AppMain.GmRingSlotSetNum( AppMain.slot_start_player, AppMain.tbl_slot_bonus_ring[( int )gms_GMK_SLOT_WORK.lotresult] );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameHit_100 );
            return;
        }
        AppMain.GmEfctCmnEsCreate( AppMain.slot_start_player.obj_work, 96 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameHit_200 );
        gms_GMK_SLOT_WORK.timer = 30;
    }

    // Token: 0x06000064 RID: 100 RVA: 0x00005AD4 File Offset: 0x00003CD4
    private static void gmGmkSlotGameHit_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.GmRingCheckRestSlotRing() != 0 )
        {
            return;
        }
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        AppMain.GmPlayerAddScore( AppMain.slot_start_player, AppMain.tbl_slot_bonus_score[( int )gms_GMK_SLOT_WORK.lotresult], AppMain.slot_start_player.obj_work.pos.x, AppMain.slot_start_player.obj_work.pos.y );
        AppMain.slot_start_call = -1;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotStay );
    }

    // Token: 0x06000065 RID: 101 RVA: 0x00005B48 File Offset: 0x00003D48
    private static void gmGmkSlotGameHit_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        gms_GMK_SLOT_WORK.timer--;
        if ( gms_GMK_SLOT_WORK.timer <= 0 )
        {
            gms_GMK_SLOT_WORK.ppos_x = AppMain.slot_start_player.obj_work.pos.x;
            gms_GMK_SLOT_WORK.ppos_y = AppMain.slot_start_player.obj_work.pos.y;
            gms_GMK_SLOT_WORK.timer = 100;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotGameHit_210 );
        }
    }

    // Token: 0x06000066 RID: 102 RVA: 0x00005BC4 File Offset: 0x00003DC4
    private static void gmGmkSlotGameHit_210( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)obj_work;
        AppMain.slot_start_player.obj_work.pos.x = gms_GMK_SLOT_WORK.ppos_x + ( ( int )AppMain.tbl_dam_ofst_xy[gms_GMK_SLOT_WORK.timer % 8][0] << 12 );
        AppMain.slot_start_player.obj_work.pos.y = gms_GMK_SLOT_WORK.ppos_y + ( ( int )AppMain.tbl_dam_ofst_xy[gms_GMK_SLOT_WORK.timer % 8][1] << 12 );
        AppMain.GmPlayerRingDec( AppMain.slot_start_player, 1 );
        if ( gms_GMK_SLOT_WORK.timer % 12 == 0 )
        {
            AppMain.GmSoundPlaySE( "Damage2" );
        }
        gms_GMK_SLOT_WORK.timer--;
        if ( gms_GMK_SLOT_WORK.timer <= 0 )
        {
            AppMain.slot_start_player.obj_work.pos.x = gms_GMK_SLOT_WORK.ppos_x;
            AppMain.slot_start_player.obj_work.pos.y = gms_GMK_SLOT_WORK.ppos_y;
            AppMain.slot_start_call = -1;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotStay );
        }
    }

    // Token: 0x06000067 RID: 103 RVA: 0x00005CB7 File Offset: 0x00003EB7
    private static void gmGmkSlotGameLose( AppMain.OBS_OBJECT_WORK obj_work )
    {
        //(AppMain.GMS_GMK_SLOT_WORK)obj_work;
        AppMain.slot_start_call = -1;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotStay );
    }

    // Token: 0x06000068 RID: 104 RVA: 0x00005CE0 File Offset: 0x00003EE0
    private static void gmGmkSlot_CreateReel( AppMain.GMS_GMK_SLOT_WORK pwork )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)pwork;
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_SLOTPARTS_WORK(), null, 0, "Gmk_SlotReel");
            AppMain.GMS_GMK_SLOTPARTS_WORK gms_GMK_SLOTPARTS_WORK = (AppMain.GMS_GMK_SLOTPARTS_WORK)obs_OBJECT_WORK2;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_slot_obj_3d_list[( int )AppMain.tbl_gmk_slot_reelmodel_id[i]], gms_GMK_SLOTPARTS_WORK.eff_work.obj_3d );
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK.pos.x + ( 48 * i - 48 ) * 4096;
            obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK.pos.y;
            obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK.pos.z;
            obs_OBJECT_WORK2.obj_3d.drawflag |= 268435456U;
            obs_OBJECT_WORK2.flag &= 4294966271U;
            obs_OBJECT_WORK2.flag |= 2U;
            obs_OBJECT_WORK2.move_flag |= 256U;
            obs_OBJECT_WORK2.disp_flag &= 4294967039U;
            obs_OBJECT_WORK2.disp_flag |= 138412032U;
            obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSlotReel );
            gms_GMK_SLOTPARTS_WORK.reel_id = i;
            gms_GMK_SLOTPARTS_WORK.slot_work = pwork;
        }
    }

    // Token: 0x06000069 RID: 105 RVA: 0x00005E3C File Offset: 0x0000403C
    private static void gmGmkSlotReel( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SLOTPARTS_WORK gms_GMK_SLOTPARTS_WORK = (AppMain.GMS_GMK_SLOTPARTS_WORK)obj_work;
        ushort num = (ushort)((ushort)gms_GMK_SLOTPARTS_WORK.slot_work.reel_status[gms_GMK_SLOTPARTS_WORK.reel_id].reel >> 12);
        int num2 = (int)AppMain.tbl_reel_tex_u[(int)(num / 5)];
        int num3 = (int)AppMain.tbl_reel_tex_v[num2][(int)(num % 5)] << 12;
        num3 += ( int )( gms_GMK_SLOTPARTS_WORK.slot_work.reel_status[gms_GMK_SLOTPARTS_WORK.reel_id].reel & 4095 );
        float num4 = (float)num3 / 32768f;
        float u = (float)num2 / 8f;
        gms_GMK_SLOTPARTS_WORK.eff_work.obj_3d.draw_state.texoffset[0].v = -num4;
        gms_GMK_SLOTPARTS_WORK.eff_work.obj_3d.draw_state.texoffset[0].u = u;
    }

    // Token: 0x0600006A RID: 106 RVA: 0x00005EF7 File Offset: 0x000040F7
    private static int GmGmkSlotStartRequest( int slot_id, AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( AppMain.slot_start_call != -1 )
        {
            return 0;
        }
        AppMain.slot_start_call = slot_id;
        AppMain.slot_start_player = ply_work;
        return 1;
    }

    // Token: 0x0600006B RID: 107 RVA: 0x00005F10 File Offset: 0x00004110
    private static int GmGmkSlotIsStatus( int slot_id )
    {
        if ( AppMain.slot_start_call == -1 )
        {
            return 1;
        }
        AppMain.UNREFERENCED_PARAMETER( slot_id );
        return 0;
    }

    // Token: 0x0600006C RID: 108 RVA: 0x00005F30 File Offset: 0x00004130
    private static AppMain.OBS_OBJECT_WORK GmGmkSlotInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_SLOT_WORK gms_GMK_SLOT_WORK = (AppMain.GMS_GMK_SLOT_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SLOT_WORK(), "Gmk_Slot");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_SLOT_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_SLOT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_slot_obj_3d_list[3], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 875 ).pData, 1, 1 );
        AppMain.ObjDrawAction3dActionSet3DNNMaterial( gms_ENEMY_3D_WORK.obj_3d, 0 );
        obs_OBJECT_WORK.pos.z = -135168;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194308U;
        gms_GMK_SLOT_WORK.slot_id = ( int )eve_rec.left;
        if ( AppMain.slot_start_call == 0 )
        {
            AppMain.slot_start_call = -1;
        }
        AppMain.gmGmkSlot_CreateReel( gms_GMK_SLOT_WORK );
        AppMain.gmGmkSlotStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600006D RID: 109 RVA: 0x00006019 File Offset: 0x00004219
    private static void GmGmkSlotBuild()
    {
        AppMain.gm_gmk_slot_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 873 ), AppMain.GmGameDatGetGimmickData( 874 ), 0U );
        AppMain.slot_start_call = 0;
    }

    // Token: 0x0600006E RID: 110 RVA: 0x00006040 File Offset: 0x00004240
    private static void GmGmkSlotFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(873);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_slot_obj_3d_list, ams_AMB_HEADER.file_num );
    }

}