using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000199 RID: 409
    public class GMS_PLY_SEQ_STATE_DATA
    {
        // Token: 0x060021E6 RID: 8678 RVA: 0x00141ED4 File Offset: 0x001400D4
        public GMS_PLY_SEQ_STATE_DATA( uint check_attr, uint accept_attr )
        {
            this.check_attr = check_attr;
            this.accept_attr = accept_attr;
        }

        // Token: 0x04004F21 RID: 20257
        public uint check_attr;

        // Token: 0x04004F22 RID: 20258
        public uint accept_attr;
    }

    // Token: 0x06001716 RID: 5910 RVA: 0x000C94DE File Offset: 0x000C76DE
    private static void GmPlySeqSetSeqState( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.seq_init_tbl = AppMain.g_gm_ply_seq_init_tbl_list[( int )ply_work.char_id];
        ply_work.seq_state_data_tbl = AppMain.g_gm_ply_seq_state_data_tbl[( int )ply_work.char_id];
    }

    // Token: 0x06001717 RID: 5911 RVA: 0x000C9504 File Offset: 0x000C7704
    private static void GmPlySeqMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.GMS_PLY_SEQ_STATE_DATA[] seq_state_data_tbl = ply_work.seq_state_data_tbl;
        if ( ply_work.no_spddown_timer != 0 )
        {
            ply_work.no_spddown_timer = AppMain.ObjTimeCountDown( ply_work.no_spddown_timer );
        }
        if ( ply_work.maxdash_timer != 0 )
        {
            ply_work.maxdash_timer = AppMain.ObjTimeCountDown( ply_work.maxdash_timer );
        }
        if ( ( ply_work.player_flag & 1048576U ) != 0U )
        {
            AppMain.gmPlySeqActGoal( ply_work );
        }
        if ( ( ply_work.player_flag & 2097152U ) != 0U )
        {
            AppMain.gmPlySeqBossGoalPre( ply_work );
        }
        if ( ( ply_work.player_flag & 1073741824U ) != 0U )
        {
            AppMain.gmPlySeqBoss5DemoPre( ply_work );
        }
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            AppMain.gmPlySeqSplStgRollCtrl( ply_work );
        }
        AppMain.gmPlySeqCheckChangeSequence( ply_work );
        if ( ply_work.seq_func != null )
        {
            ply_work.seq_func( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 8388608U ) != 0U )
        {
            AppMain.GmPlayerAnimeSpeedSetWalk( ply_work, ply_work.obj_work.spd_m );
        }
        else if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 4194304U ) == 0U )
        {
            ply_work.obj_work.obj_3d.speed[0] = 1f;
            ply_work.obj_work.obj_3d.speed[1] = 1f;
        }
        if ( ( ply_work.player_flag & 16U ) != 0U )
        {
            int num = (int)ply_work.pgm_turn_dir;
            if ( ply_work.pgm_turn_dir_tbl != null )
            {
                num = ( int )ply_work.pgm_turn_dir_tbl[ply_work.pgm_turn_tbl_cnt];
                ply_work.pgm_turn_tbl_cnt++;
                if ( ply_work.pgm_turn_tbl_cnt >= ply_work.pgm_turn_tbl_num )
                {
                    ply_work.pgm_turn_tbl_cnt = ply_work.pgm_turn_tbl_num - 1;
                    ply_work.player_flag &= 4294967279U;
                    if ( ( ply_work.player_flag & 256U ) == 0U )
                    {
                        num = 0;
                    }
                }
            }
            else if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
            {
                num -= ( int )ply_work.pgm_turn_spd;
                if ( num <= 0 )
                {
                    num = 0;
                    ply_work.player_flag &= 4294967279U;
                }
            }
            else
            {
                num += ( int )ply_work.pgm_turn_spd;
                if ( num >= 65536 )
                {
                    num = 0;
                    ply_work.player_flag &= 4294967279U;
                }
            }
            ply_work.pgm_turn_dir = ( ushort )num;
            if ( ( ply_work.player_flag & 2147483648U ) != 0U && ( ply_work.player_flag & 16U ) == 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, ply_work.fall_act_state );
                ply_work.obj_work.disp_flag |= 4U;
                ply_work.player_flag &= 2147483647U;
            }
        }
    }

    // Token: 0x06001718 RID: 5912 RVA: 0x000C973B File Offset: 0x000C793B
    private static bool GmPlySeqChangeSequence( AppMain.GMS_PLAYER_WORK ply_work, int seq_state )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, seq_state );
        if ( ply_work.seq_init_tbl[seq_state] != null )
        {
            ply_work.seq_init_tbl[seq_state]( ply_work );
            return true;
        }
        return false;
    }

    // Token: 0x06001719 RID: 5913 RVA: 0x000C9760 File Offset: 0x000C7960
    private static void GmPlySeqChangeSequenceState( AppMain.GMS_PLAYER_WORK ply_work, int seq_state )
    {
        if ( ply_work.gmk_obj != null )
        {
            AppMain.GmPlayerStateGimmickInit( ply_work );
        }
        ply_work.prev_seq_state = ply_work.seq_state;
        ply_work.seq_state = seq_state;
        ply_work.rect_work[1].flag &= 4294967291U;
        if ( ( ply_work.player_flag & 256U ) != 0U )
        {
            AppMain.GmPlayerSetReverseOnlyState( ply_work );
        }
        if ( ( ply_work.player_flag & 2147483648U ) != 0U )
        {
            ply_work.player_flag &= 2147483375U;
            ply_work.pgm_turn_dir_tbl = null;
            ply_work.pgm_turn_dir = 0;
            ply_work.pgm_turn_spd = 0;
        }
    }

    // Token: 0x0600171A RID: 5914 RVA: 0x000C97F0 File Offset: 0x000C79F0
    private static void GmPlySeqSetProgramTurn( AppMain.GMS_PLAYER_WORK ply_work, ushort turn_spd )
    {
        if ( ( ply_work.player_flag & 16U ) == 0U )
        {
            ply_work.pgm_turn_dir = 0;
        }
        AppMain.GmPlayerSetReverse( ply_work );
        ply_work.player_flag |= 16U;
        ply_work.pgm_turn_spd = turn_spd;
        ply_work.pgm_turn_dir += 32768;
        ply_work.pgm_turn_dir_tbl = null;
    }

    // Token: 0x0600171B RID: 5915 RVA: 0x000C9848 File Offset: 0x000C7A48
    private static void GmPlySeqSetProgramTurnTbl( AppMain.GMS_PLAYER_WORK ply_work, ushort[] turn_tbl, int tbl_num, bool rev_depend_mtn )
    {
        if ( ( ply_work.player_flag & 16U ) == 0U )
        {
            ply_work.pgm_turn_dir = 0;
        }
        if ( !rev_depend_mtn )
        {
            AppMain.GmPlayerSetReverse( ply_work );
        }
        else
        {
            ply_work.player_flag |= 256U;
        }
        ply_work.player_flag |= 16U;
        ply_work.pgm_turn_dir_tbl = turn_tbl;
        ply_work.pgm_turn_tbl_num = tbl_num;
        ply_work.pgm_turn_tbl_cnt = 0;
    }

    // Token: 0x0600171C RID: 5916 RVA: 0x000C98A8 File Offset: 0x000C7AA8
    private static void GmPlySeqSetProgramTurnFwTurn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqSetProgramTurnTbl( ply_work, AppMain.gm_ply_seq_turn_l_dir_tbl, 10, true );
            return;
        }
        AppMain.GmPlySeqSetProgramTurnTbl( ply_work, AppMain.gm_ply_seq_turn_dir_tbl, 10, true );
    }

    // Token: 0x0600171D RID: 5917 RVA: 0x000C98D8 File Offset: 0x000C7AD8
    private static void GmPlySeqSetFallTurn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = 0;
        if ( ( ply_work.player_flag & 2147483648U ) != 0U )
        {
            num = ply_work.pgm_turn_tbl_cnt;
        }
        else
        {
            ply_work.fall_act_state = ply_work.act_state;
        }
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqSetProgramTurnTbl( ply_work, AppMain.gm_ply_seq_fall_turn_l_dir_tbl, 10, false );
        }
        else
        {
            AppMain.GmPlySeqSetProgramTurnTbl( ply_work, AppMain.gm_ply_seq_fall_turn_dir_tbl, 10, false );
        }
        ply_work.player_flag |= 2147483648U;
        if ( ply_work.act_state == 42 || ply_work.act_state == 43 )
        {
            AppMain.GmPlayerActionChange( ply_work, 43 );
        }
        else
        {
            AppMain.GmPlayerActionChange( ply_work, 41 );
        }
        if ( num != 0 )
        {
            ply_work.pgm_turn_tbl_cnt = 10 - num;
            ply_work.obj_work.obj_3d.frame[0] = ( float )ply_work.pgm_turn_tbl_cnt;
        }
    }

    // Token: 0x0600171E RID: 5918 RVA: 0x000C9995 File Offset: 0x000C7B95
    private static void GmPlySeqChangeFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 0 );
    }

    // Token: 0x0600171F RID: 5919 RVA: 0x000C99A0 File Offset: 0x000C7BA0
    private static void GmPlySeqInitFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            if ( ply_work.obj_work.spd_m != 0 )
            {
                if ( ply_work.prev_seq_state == 2 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 0 );
                }
                AppMain.GmPlySeqChangeSequence( ply_work, 1 );
                return;
            }
            if ( ( ply_work.player_flag & 131072U ) == 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 0 );
            }
            else
            {
                AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
            }
        }
        else
        {
            AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
        }
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqFwMain );
    }

    // Token: 0x06001720 RID: 5920 RVA: 0x000C9A54 File Offset: 0x000C7C54
    private static void gmPlySeqFwMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state == 0 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                int user_work = (int)(ply_work.obj_work.user_work + 1U);
                ply_work.obj_work.user_work = ( uint )user_work;
                if ( ply_work.obj_work.user_work >= 8U )
                {
                    if ( ( ply_work.player_flag & 16384U ) != 0U )
                    {
                        AppMain.GmPlayerActionChange( ply_work, 4 );
                    }
                    else
                    {
                        AppMain.GmPlayerActionChange( ply_work, 2 );
                    }
                    if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
                    {
                        AppMain.GmPlySeqSetProgramTurn( ply_work, 4096 );
                    }
                    ply_work.obj_work.user_work = 0U;
                    return;
                }
            }
        }
        else if ( ply_work.act_state == 2 || ply_work.act_state == 4 || ply_work.act_state == 6 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, ply_work.act_state + 1 );
                ply_work.obj_work.disp_flag |= 4U;
                ply_work.obj_work.user_work = 0U;
                return;
            }
        }
        else if ( ply_work.act_state == 3 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                int user_work2 = (int)(ply_work.obj_work.user_work + 1U);
                ply_work.obj_work.user_work = ( uint )user_work2;
                if ( ply_work.obj_work.user_work >= 10U )
                {
                    AppMain.GmPlayerActionChange( ply_work, 4 );
                    ply_work.obj_work.user_work = 0U;
                    return;
                }
            }
        }
        else if ( ply_work.act_state == 5 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            int user_work3 = (int)(ply_work.obj_work.user_work + 1U);
            ply_work.obj_work.user_work = ( uint )user_work3;
            if ( ply_work.obj_work.user_work >= 3U && ( ply_work.player_flag & 16384U ) == 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 6 );
                ply_work.obj_work.user_work = 0U;
            }
        }
    }

    // Token: 0x06001721 RID: 5921 RVA: 0x000C9C04 File Offset: 0x000C7E04
    private static void GmPlySeqInitWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) == 0U )
        {
            AppMain.GmPlayerWalkActionSet( ply_work );
        }
        else
        {
            AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqWalkMain );
        ply_work.obj_work.user_timer = 0;
    }

    // Token: 0x06001722 RID: 5922 RVA: 0x000C9C60 File Offset: 0x000C7E60
    private static void gmPlySeqWalkMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.spd_m > 0 && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) != 0U ) || ( ply_work.obj_work.spd_m < 0 && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) == 0U ) )
        {
            AppMain.GmPlySeqSetProgramTurn( ply_work, 4096 );
        }
        AppMain.GmPlayerWalkActionCheck( ply_work );
        if ( ( ply_work.obj_work.user_timer & 63 ) == 1 && ply_work.obj_work.ride_obj == null )
        {
            AppMain.GmPlyEfctCreateFootSmoke( ply_work );
        }
        ply_work.obj_work.user_timer++;
    }

    // Token: 0x06001723 RID: 5923 RVA: 0x000C9D00 File Offset: 0x000C7F00
    private static void GmPlySeqInitTurn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.prev_seq_state == 2 )
        {
            ply_work.player_flag &= 2147483375U;
            AppMain.GmPlayerSetReverse( ply_work );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( 23 <= ply_work.act_state && ply_work.act_state <= 25 )
        {
            AppMain.GmPlayerActionChange( ply_work, 10 );
        }
        else if ( 20 <= ply_work.act_state && ply_work.act_state <= 22 )
        {
            AppMain.GmPlayerActionChange( ply_work, 9 );
        }
        else
        {
            AppMain.GmPlayerActionChange( ply_work, 8 );
            AppMain.GmPlySeqSetProgramTurnFwTurn( ply_work );
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTurnMain );
    }

    // Token: 0x06001724 RID: 5924 RVA: 0x000C9DA6 File Offset: 0x000C7FA6
    private static void gmPlySeqTurnMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlayerSetReverseOnlyState( ply_work );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06001725 RID: 5925 RVA: 0x000C9DC5 File Offset: 0x000C7FC5
    private static void GmPlySeqInitLookupStart( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 11 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqLookupMain );
    }

    // Token: 0x06001726 RID: 5926 RVA: 0x000C9DF8 File Offset: 0x000C7FF8
    private static void GmPlySeqInitLookupMiddle( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 12 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqLookupMain );
    }

    // Token: 0x06001727 RID: 5927 RVA: 0x000C9E46 File Offset: 0x000C8046
    private static void GmPlySeqInitLookupEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 13 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqLookupEndMain );
    }

    // Token: 0x06001728 RID: 5928 RVA: 0x000C9E78 File Offset: 0x000C8078
    private static void gmPlySeqLookupMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m != 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 1 );
            return;
        }
        int act_state = ply_work.act_state;
        if ( act_state != 11 )
        {
            return;
        }
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 4 );
        }
    }

    // Token: 0x06001729 RID: 5929 RVA: 0x000C9EBF File Offset: 0x000C80BF
    private static void gmPlySeqLookupEndMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x0600172A RID: 5930 RVA: 0x000C9ED8 File Offset: 0x000C80D8
    private static void GmPlySeqInitSquatStart( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 14 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSquatMain );
    }

    // Token: 0x0600172B RID: 5931 RVA: 0x000C9F08 File Offset: 0x000C8108
    private static void GmPlySeqInitSquatMiddle( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 15 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 4096 )
        {
            ply_work.obj_work.spd_m = 0;
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSquatMain );
    }

    // Token: 0x0600172C RID: 5932 RVA: 0x000C9F79 File Offset: 0x000C8179
    private static void GmPlySeqInitSquatEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 16 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSquatEndMain );
    }

    // Token: 0x0600172D RID: 5933 RVA: 0x000C9FAC File Offset: 0x000C81AC
    private static void gmPlySeqSquatMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int act_state = ply_work.act_state;
        if ( act_state == 14 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 7 );
        }
        if ( ply_work.seq_state == 7 && ply_work.obj_work.spd_m != 0 )
        {
            ply_work.obj_work.move_flag |= 16384U;
            AppMain.GmPlySeqChangeSequence( ply_work, 10 );
        }
    }

    // Token: 0x0600172E RID: 5934 RVA: 0x000CA012 File Offset: 0x000C8212
    private static void gmPlySeqSquatEndMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x0600172F RID: 5935 RVA: 0x000CA02C File Offset: 0x000C822C
    private static void GmPlySeqInitBrake( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 23 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqBrakeMain );
        AppMain.GmSoundPlaySE( "Brake" );
        AppMain.GmPlyEfctCreateBrakeImpact( ply_work );
        AppMain.GmPlyEfctCreateBrakeDust( ply_work );
    }

    // Token: 0x06001730 RID: 5936 RVA: 0x000CA080 File Offset: 0x000C8280
    private static void gmPlySeqBrakeMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state != 25 && ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && !AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && !AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) ) )
        {
            AppMain.GmPlayerActionChange( ply_work, 25 );
        }
        switch ( ply_work.act_state )
        {
            case 23:
                if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
                {
                    AppMain.GmPlayerActionChange( ply_work, 24 );
                    ply_work.obj_work.disp_flag |= 4U;
                    return;
                }
                break;
            case 24:
                if ( ( ply_work.obj_work.spd_m <= 0 || !AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) && ( ply_work.obj_work.spd_m >= 0 || !AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
                {
                    AppMain.GmPlySeqChangeSequence( ply_work, 2 );
                    return;
                }
                break;
            case 25:
                if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
                {
                    if ( ply_work.obj_work.spd_m != 0 )
                    {
                        AppMain.GmPlySeqChangeSequence( ply_work, 1 );
                        return;
                    }
                    AppMain.GmPlySeqChangeSequence( ply_work, 0 );
                }
                break;
            default:
                return;
        }
    }

    // Token: 0x06001731 RID: 5937 RVA: 0x000CA178 File Offset: 0x000C8378
    private static void GmPlySeqInitSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 27 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSpinMain );
        AppMain.GmPlayerSetAtk( ply_work );
        if ( ply_work.prev_seq_state != 37 && ( ply_work.player_flag & 131072U ) == 0U )
        {
            AppMain.GmSoundPlaySE( "Spin" );
        }
        AppMain.GmPlyEfctCreateSpinDashDust( ply_work );
        AppMain.GmPlyEfctCreateSuperAuraSpin( ply_work );
        AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 1U );
        AppMain.GmPlyEfctCreateSpinDashCircleBlur( ply_work );
        AppMain.GmPlyEfctCreateTrail( ply_work, 1 );
    }

    // Token: 0x06001732 RID: 5938 RVA: 0x000CA210 File Offset: 0x000C8410
    private static void gmPlySeqSpinMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001733 RID: 5939 RVA: 0x000CA214 File Offset: 0x000C8414
    private static void GmPlySeqInitSpinDashAcc( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state != 29 && ply_work.act_state != 30 && ply_work.act_state != 28 )
        {
            AppMain.GmPlyEfctCreateSpinStartBlur( ply_work );
        }
        if ( ply_work.efct_spin_start_blur != null )
        {
            AppMain.GmPlayerActionChange( ply_work, 28 );
        }
        else
        {
            AppMain.GmPlayerActionChange( ply_work, 29 );
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        if ( ply_work.dash_power != 0 )
        {
            ply_work.dash_power = AppMain.ObjSpdUpSet( ply_work.dash_power, ply_work.spd_add_spin, ply_work.spd_max_spin );
        }
        else
        {
            ply_work.dash_power = ply_work.spd_spin;
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSpinDashMain );
        AppMain.GmPlayerSetAtk( ply_work );
        if ( ply_work.spin_se_timer <= 0 )
        {
            AppMain.GmSoundPlaySE( "Dash1" );
            ply_work.spin_se_timer = 25;
        }
        if ( ply_work.spin_back_se_timer <= 0 )
        {
            AppMain.GmSoundPlaySE( "Dash2" );
            ply_work.spin_se_timer = 50;
        }
        if ( ply_work.prev_seq_state != 11 )
        {
            AppMain.GmPlyEfctCreateSpinAddDust( ply_work );
        }
    }

    // Token: 0x06001734 RID: 5940 RVA: 0x000CA308 File Offset: 0x000C8508
    private static void GmPlySeqInitSpinDash( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state != 29 && ply_work.act_state != 30 && ply_work.act_state != 28 )
        {
            AppMain.GmPlyEfctCreateSpinStartBlur( ply_work );
        }
        AppMain.GmPlayerActionChange( ply_work, 30 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSpinDashMain );
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmPlyEfctCreateSpinDust( ply_work );
    }

    // Token: 0x06001735 RID: 5941 RVA: 0x000CA388 File Offset: 0x000C8588
    private static void gmPlySeqSpinDashMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state == 28 && ply_work.efct_spin_start_blur == null )
        {
            if ( ply_work.seq_state == 11 )
            {
                AppMain.GmPlySeqChangeSequence( ply_work, 12 );
                return;
            }
            AppMain.GmPlayerActionChange( ply_work, 30 );
        }
        if ( ply_work.act_state == 29 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 12 );
            return;
        }
        if ( ( ply_work.key_on & 2 ) == 0 || ply_work.obj_work.spd_m != 0 )
        {
            ply_work.no_spddown_timer = 72;
            ply_work.camera_stop_timer = 32768;
            int num = 48128 + AppMain.FX_Mul(ply_work.dash_power, 512);
            if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
            {
                num = -num;
            }
            if ( AppMain.MTM_MATH_ABS( num ) > AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) )
            {
                ply_work.obj_work.spd_m = num;
            }
            ply_work.dash_power = 0;
            ply_work.obj_work.move_flag |= 16384U;
            AppMain.GmPlySeqChangeSequence( ply_work, 10 );
            AppMain.GmPlyEfctCreateSpinDashImpact( ply_work );
            AppMain.GMM_PAD_VIB_SMALL();
            return;
        }
        if ( ( ply_work.key_on & 1 ) != 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06001736 RID: 5942 RVA: 0x000CA4A8 File Offset: 0x000C86A8
    private static void GmPlySeqInitStaggerFront( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 33 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqStaggerMain );
        AppMain.GmPlyEfctCreateSweat( ply_work );
    }

    // Token: 0x06001737 RID: 5943 RVA: 0x000CA4FC File Offset: 0x000C86FC
    private static void GmPlySeqInitStaggerBack( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 34 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqStaggerMain );
        AppMain.GmPlyEfctCreateSweat( ply_work );
    }

    // Token: 0x06001738 RID: 5944 RVA: 0x000CA550 File Offset: 0x000C8750
    private static void GmPlySeqInitStaggerDanger( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 35 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqStaggerMain );
        AppMain.GmPlyEfctCreateSweat( ply_work );
    }

    // Token: 0x06001739 RID: 5945 RVA: 0x000CA5A4 File Offset: 0x000C87A4
    private static void gmPlySeqStaggerMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x0600173A RID: 5946 RVA: 0x000CA5A8 File Offset: 0x000C87A8
    private static void GmPlySeqInitFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() && ( ( ply_work.player_flag & 16384U ) == 0U || ( ply_work.act_state != 21 && ply_work.act_state != 22 ) ) && ( ply_work.player_flag & 131072U ) == 0U && ply_work.prev_seq_state != 40 )
        {
            if ( ply_work.obj_work.dir.z - 8192 <= 49152 )
            {
                AppMain.GmPlayerActionChange( ply_work, 42 );
            }
            else
            {
                AppMain.GmPlayerActionChange( ply_work, 40 );
            }
        }
        AppMain.GmPlySeqInitFallState( ply_work );
    }

    // Token: 0x0600173B RID: 5947 RVA: 0x000CA62C File Offset: 0x000C882C
    private static void GmPlySeqInitFallState( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 32912U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqJumpMain );
        ply_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )( ply_work.obj_work.dir.z - ( AppMain.g_gm_main_system.pseudofall_dir - ply_work.prev_dir_fall2 ) ) ) );
        ply_work.obj_work.spd.y = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathSin( ( int )( ply_work.obj_work.dir.z - ( AppMain.g_gm_main_system.pseudofall_dir - ply_work.prev_dir_fall2 ) ) ) );
        ply_work.obj_work.spd_m = 0;
        ply_work.player_flag &= 4294967280U;
        ply_work.player_flag |= 1U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.timer = 0;
    }

    // Token: 0x0600173C RID: 5948 RVA: 0x000CA760 File Offset: 0x000C8960
    private static void GmPlySeqInitJump( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) == 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 39 );
        }
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4290772990U;
        ushort num = ply_work.obj_work.dir.z;
        if ( ( num + 256 & 8192 ) != 0 && ( num + 256 & 4095 ) <= 1024 )
        {
            if ( ply_work.obj_work.spd_m > 0 && num < 32768 )
            {
                num -= 1152;
            }
            else if ( ply_work.obj_work.spd_m < 0 && num > 32768 )
            {
                num += 1152;
            }
        }
        ply_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )num ) );
        ply_work.obj_work.spd.y = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathSin( ( int )num ) );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.spd.x = obj_work.spd.x + AppMain.FX_Mul( ply_work.spd_jump, AppMain.mtMathSin( ( int )ply_work.obj_work.dir.z ) );
        AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
        obj_work2.spd.y = obj_work2.spd.y + AppMain.FX_Mul( -ply_work.spd_jump, AppMain.mtMathCos( ( int )ply_work.obj_work.dir.z ) );
        if ( ( ply_work.gmk_flag & 4096U ) != 0U )
        {
            ply_work.obj_work.spd.z = ply_work.obj_work.spd.y;
            ply_work.obj_work.spd.y = 0;
            if ( ply_work.obj_work.pos.z < 0 )
            {
                ply_work.obj_work.spd.z = -ply_work.obj_work.spd.z;
            }
        }
        ply_work.player_flag &= 4294967280U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.timer = 0;
        AppMain.GmPlySeqSetJumpState( ply_work, 0, 0U );
        if ( ply_work.prev_seq_state == 10 && ply_work.no_spddown_timer >= 20 )
        {
            ply_work.no_spddown_timer = 20;
        }
        AppMain.GmPlayerSetAtk( ply_work );
        if ( AppMain.gm_ply_seq_jump_call_se_jump )
        {
            AppMain.GmSoundPlaySE( "Jump" );
        }
        AppMain.GmPlyEfctCreateJumpDust( ply_work );
        AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
    }

    // Token: 0x0600173D RID: 5949 RVA: 0x000CA9DC File Offset: 0x000C8BDC
    private static void GmPlySeqSetJumpState( AppMain.GMS_PLAYER_WORK ply_work, int nofall_timer, uint flag )
    {
        ply_work.obj_work.user_timer = nofall_timer;
        if ( ply_work.no_jump_move_timer == 0 )
        {
            ply_work.player_flag &= 4294967263U;
        }
        ply_work.player_flag &= 4294967152U;
        if ( ( flag & 1U ) != 0U )
        {
            ply_work.player_flag |= 1U;
        }
        if ( ( flag & 2U ) != 0U )
        {
            ply_work.player_flag |= 2U;
        }
        if ( ( flag & 4U ) != 0U )
        {
            ply_work.player_flag |= 128U;
        }
        if ( ( flag & 8U ) != 0U )
        {
            ply_work.player_flag |= 32U;
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckJumpMain );
            return;
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqJumpMain );
    }

    // Token: 0x0600173E RID: 5950 RVA: 0x000CAAA4 File Offset: 0x000C8CA4
    private static void GmPlySeqInitJumpEX( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqInitJump( ply_work );
        ply_work.obj_work.spd.x = spd_x;
        ply_work.obj_work.spd.y = spd_y;
        ply_work.obj_work.spd_m = 0;
        if ( ply_work.obj_work.spd.x < 0 )
        {
            if ( ply_work.obj_work.spd_m > 0 )
            {
                ply_work.obj_work.spd_m = 0;
            }
            if ( ( ply_work.obj_work.disp_flag & 1U ) == 0U )
            {
                AppMain.GmPlayerSetReverse( ply_work );
                return;
            }
        }
        else
        {
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = 0;
            }
            if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
            {
                AppMain.GmPlayerSetReverse( ply_work );
            }
        }
    }

    // Token: 0x0600173F RID: 5951 RVA: 0x000CAB58 File Offset: 0x000C8D58
    private static void GmPlySeqAtkReactionInit( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.seq_state == 19 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 20 );
            return;
        }
        if ( ( ply_work.obj_work.move_flag & 16U ) != 0U )
        {
            int x = ply_work.obj_work.spd.x;
            int spd_m = ply_work.obj_work.spd_m;
            AppMain.GmPlayerStateInit( ply_work );
            AppMain.gm_ply_seq_jump_call_se_jump = false;
            AppMain.GmPlySeqChangeSequence( ply_work, 17 );
            AppMain.gm_ply_seq_jump_call_se_jump = true;
            AppMain.GmPlySeqSetJumpState( ply_work, 0, 1U );
            ply_work.obj_work.spd.y = -16384;
            ply_work.obj_work.spd.x = x;
            ply_work.obj_work.spd_m = spd_m;
        }
    }

    // Token: 0x06001740 RID: 5952 RVA: 0x000CABFB File Offset: 0x000C8DFB
    private static void GmPlySeqAtkReactionSpdInit( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int no_spddown_timer )
    {
        ply_work.obj_work.spd.x = spd_x;
        ply_work.no_spddown_timer = no_spddown_timer;
        AppMain.GmPlySeqAtkReactionInit( ply_work );
    }

    // Token: 0x06001741 RID: 5953 RVA: 0x000CAC1C File Offset: 0x000C8E1C
    private static void gmPlySeqJumpMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.obj_work.spd.y;
        if ( ( ply_work.gmk_flag & 4096U ) != 0U )
        {
            num = ply_work.obj_work.spd.z;
            if ( ply_work.obj_work.dir.x > 32768 )
            {
                num = -num;
            }
        }
        if ( ply_work.obj_work.user_timer != 0 )
        {
            ply_work.obj_work.user_timer--;
            if ( ply_work.obj_work.user_timer == 0 )
            {
                ply_work.obj_work.move_flag |= 128U;
            }
        }
        if ( ( ply_work.player_flag & 5U ) == 0U && !AppMain.GmPlayerKeyCheckJumpKeyOn( ply_work ) && num < -16384 )
        {
            ply_work.player_flag |= 4U;
        }
        if ( ( ply_work.player_flag & 4U ) != 0U && ply_work.obj_work.spd.y < 0 )
        {
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.spd.y = obj_work.spd.y + ply_work.obj_work.spd_fall;
        }
        int act_state = ply_work.act_state;
        if ( act_state != 39 )
        {
            switch ( act_state )
            {
                case 44:
                    if ( num > 1024 )
                    {
                        AppMain.GmPlayerActionChange( ply_work, 45 );
                    }
                    break;
                case 45:
                    if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
                    {
                        AppMain.GmPlayerActionChange( ply_work, 46 );
                        ply_work.obj_work.disp_flag |= 4U;
                    }
                    break;
                case 47:
                    if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
                    {
                        ply_work.obj_work.disp_flag |= 1024U;
                        AppMain.GmPlayerActionChange( ply_work, 48 );
                        ply_work.obj_work.disp_flag |= 4U;
                    }
                    break;
            }
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06001742 RID: 5954 RVA: 0x000CADE5 File Offset: 0x000C8FE5
    private static void GmPlySeqInitWallPush( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 17 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqWallPushMain );
    }

    // Token: 0x06001743 RID: 5955 RVA: 0x000CAE15 File Offset: 0x000C9015
    private static void gmPlySeqWallPushMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state == 17 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 18 );
            ply_work.obj_work.disp_flag |= 4U;
        }
    }

    // Token: 0x06001744 RID: 5956 RVA: 0x000CAE4C File Offset: 0x000C904C
    private static void GmPlySeqInitHoming( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.enemy_obj == null )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 21 );
            return;
        }
        if ( ( ply_work.player_flag & 131072U ) == 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 31 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4294967166U;
        ply_work.player_flag |= 128U;
        ply_work.obj_work.dir.z = 0;
        ply_work.gmk_flag &= 4261410812U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqHomingMain );
        ply_work.obj_work.user_timer = 131072;
        ply_work.homing_timer = 98304;
        ply_work.homing_boost_timer = 262144;
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmPlyEfctCreateHomingImpact( ply_work );
        AppMain.GmSoundPlaySE( "Homing" );
    }

    // Token: 0x06001745 RID: 5957 RVA: 0x000CAF45 File Offset: 0x000C9145
    private static void GmPlySeqSetNoJumpMoveTime( AppMain.GMS_PLAYER_WORK ply_work, int time )
    {
        ply_work.no_jump_move_timer = time;
        ply_work.player_flag |= 32U;
    }

    // Token: 0x06001746 RID: 5958 RVA: 0x000CAF60 File Offset: 0x000C9160
    private static void gmPlySeqHomingMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.user_timer == 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            return;
        }
        ply_work.obj_work.user_timer = AppMain.ObjTimeCountDown( ply_work.obj_work.user_timer );
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( ply_work.enemy_obj != null )
        {
            AppMain.OBS_RECT_WORK obs_RECT_WORK = ((AppMain.GMS_ENEMY_COM_WORK)ply_work.enemy_obj).rect_work[2];
            int x = ply_work.enemy_obj.pos.x;
            int num;
            if ( ( ply_work.enemy_obj.disp_flag & 2U ) != 0U )
            {
                num = ply_work.enemy_obj.pos.y - ( ( int )( obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom ) << 11 );
            }
            else
            {
                num = ply_work.enemy_obj.pos.y + ( ( int )( obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom ) << 11 );
            }
            float num2 = AppMain.FXM_FX32_TO_FLOAT(x - ply_work.obj_work.pos.x);
            float num3 = AppMain.FXM_FX32_TO_FLOAT(num - ply_work.obj_work.pos.y);
            int num4 = AppMain.nnArcTan2((double)num3, (double)num2);
            num4 += ( int )ply_work.obj_work.dir_fall;
            ply_work.obj_work.spd.x = ( int )( AppMain.nnCos( num4 ) * 61440f );
            ply_work.obj_work.spd.y = ( int )( AppMain.nnSin( num4 ) * 61440f );
            if ( ply_work.obj_work.spd.x < 0 )
            {
                ply_work.obj_work.disp_flag |= 1U;
            }
            else if ( ply_work.obj_work.spd.x > 0 )
            {
                ply_work.obj_work.disp_flag &= 4294967294U;
            }
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) > 256 && ( ply_work.obj_work.move_flag & 4U ) != 0U )
            {
                AppMain.GmPlySeqLandingSet( ply_work, 0 );
                AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            }
        }
    }

    // Token: 0x06001747 RID: 5959 RVA: 0x000CB16C File Offset: 0x000C936C
    private static void GmPlySeqInitHomingRef( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) == 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 32 );
        }
        ply_work.player_flag &= 4294967167U;
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 32912U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqHomingRefMain );
        ply_work.obj_work.spd.x = 0;
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            ply_work.obj_work.spd.y = AppMain.GMD_PLAYER_WATERJUMP_GET( -20480 );
        }
        else
        {
            ply_work.obj_work.spd.y = -20480;
        }
        ply_work.obj_work.spd_add.x = ( ply_work.obj_work.spd_add.y = 0 );
        ply_work.obj_work.spd_m = 0;
        ply_work.player_flag &= 4294967280U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.timer = 0;
        AppMain.GmPlyEfctCreateJumpDust( ply_work );
    }

    // Token: 0x06001748 RID: 5960 RVA: 0x000CB2A5 File Offset: 0x000C94A5
    private static void gmPlySeqHomingRefMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd.y >= 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            return;
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06001749 RID: 5961 RVA: 0x000CB2E4 File Offset: 0x000C94E4
    private static void GmPlySeqInitJumpDash( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) == 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 39 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.player_flag |= 160U;
        ply_work.obj_work.dir.z = 0;
        ply_work.gmk_flag &= 4261410812U;
        int ang;
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            ang = -30720;
        }
        else
        {
            ang = 63488;
        }
        if ( ( ply_work.player_flag & 32768U ) != 0U )
        {
            ply_work.obj_work.spd.y = 0;
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.spd.x = obj_work.spd.x + ( int )( 4096f * AppMain.nnCos( ang ) );
            AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
            obj_work2.spd.y = obj_work2.spd.y + -( int )( 4096f * AppMain.nnSin( ang ) );
            ply_work.no_spddown_timer = 8;
            ply_work.obj_work.user_timer = 20;
        }
        else
        {
            ply_work.obj_work.spd.y = 0;
            AppMain.OBS_OBJECT_WORK obj_work3 = ply_work.obj_work;
            obj_work3.spd.x = obj_work3.spd.x + ( int )( 16384f * AppMain.nnCos( ang ) );
            AppMain.OBS_OBJECT_WORK obj_work4 = ply_work.obj_work;
            obj_work4.spd.y = obj_work4.spd.y + -( int )( 16384f * AppMain.nnSin( ang ) );
            ply_work.no_spddown_timer = 8;
            ply_work.obj_work.user_timer = 20;
        }
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmPlyEfctCreateJumpDash( ply_work );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqJumpDashMain );
    }

    // Token: 0x0600174A RID: 5962 RVA: 0x000CB4A4 File Offset: 0x000C96A4
    private static void gmPlySeqJumpDashMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            ply_work.player_flag &= 4294967263U;
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( ply_work.obj_work.user_timer == 0 )
        {
            int x = ply_work.obj_work.spd.x;
            int y = ply_work.obj_work.spd.y;
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            ply_work.obj_work.spd.x = x;
            ply_work.obj_work.spd.y = y;
            ply_work.player_flag &= 4294967263U;
            return;
        }
        ply_work.obj_work.user_timer--;
    }

    // Token: 0x0600174B RID: 5963 RVA: 0x000CB55C File Offset: 0x000C975C
    private static void GmPlySeqChangeDamage( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 22 );
    }

    // Token: 0x0600174C RID: 5964 RVA: 0x000CB568 File Offset: 0x000C9768
    private static void GmPlySeqChangeDamageSetSpd( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 22 );
        ply_work.obj_work.spd.x = spd_x;
        ply_work.obj_work.spd.y = spd_y;
        if ( spd_x < 0 )
        {
            ply_work.obj_work.disp_flag &= 4294967294U;
            return;
        }
        ply_work.obj_work.disp_flag |= 1U;
    }

    // Token: 0x0600174D RID: 5965 RVA: 0x000CB5CC File Offset: 0x000C97CC
    private static void GmPlySeqInitDamage( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerStateInit( ply_work );
        if ( ( ply_work.player_flag & 32768U ) != 0U )
        {
            ply_work.obj_work.spd.x = 24576;
            ply_work.obj_work.spd.y = -12288;
            ply_work.obj_work.spd_m = 0;
            ply_work.obj_work.disp_flag &= 4294967294U;
        }
        else
        {
            ply_work.obj_work.spd.x = -6144;
            ply_work.obj_work.spd.y = -12288;
            ply_work.obj_work.spd_m = 0;
            if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
            {
                ply_work.obj_work.spd.x = -ply_work.obj_work.spd.x;
            }
        }
        AppMain.GmPlayerActionChange( ply_work, 36 );
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.invincible_timer = ply_work.time_damage;
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqDamageMain );
        ply_work.obj_work.disp_flag |= 4U;
        AppMain.GMM_PAD_VIB_LARGE_TIME( 60f );
    }

    // Token: 0x0600174E RID: 5966 RVA: 0x000CB713 File Offset: 0x000C9913
    private static void gmPlySeqDamageMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            ply_work.rect_work[0].flag &= 4294967039U;
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x0600174F RID: 5967 RVA: 0x000CB74C File Offset: 0x000C994C
    private static void GmPlySeqChangeDeath( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 23 );
    }

    // Token: 0x06001750 RID: 5968 RVA: 0x000CB758 File Offset: 0x000C9958
    private static void GmPlySeqInitDeath( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        if ( ( ply_work.player_flag & 16777216U ) != 0U )
        {
            return;
        }
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            AppMain.GmPlayerSetEndSuperSonic( ply_work );
        }
        AppMain.GmPlayerStateInit( ply_work );
        ply_work.obj_work.disp_flag &= 4294967294U;
        ply_work.obj_work.move_flag |= 768U;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.y = -ply_work.spd_jump;
        ply_work.obj_work.spd_add.x = ( ply_work.obj_work.spd_add.y = 0 );
        ply_work.obj_work.dir.z = 0;
        ply_work.obj_work.pos.z = 983040;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.jump_pseudofall_dir = AppMain.g_gm_main_system.pseudofall_dir;
            ply_work.gmk_flag |= 16777216U;
            ply_work.obj_work.dir.x = ( ply_work.obj_work.dir.y = 0 );
            ply_work.obj_work.dir.z = 0;
            ply_work.obj_work.move_flag &= 4294967231U;
        }
        ply_work.player_flag &= 3489660927U;
        ply_work.player_flag |= 1024U;
        ply_work.obj_work.flag |= 2U;
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GmSoundPlaySE( "Damage3" );
        }
        else
        {
            AppMain.GmSoundPlaySE( "Damage1" );
        }
        AppMain.GmPlayerActionChange( ply_work, 37 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqDeathMain );
        ply_work.obj_work.user_timer = 0;
        ply_work.water_timer = 0;
        AppMain.GMM_PAD_VIB_LARGE_TIME( 90f );
    }

    // Token: 0x06001751 RID: 5969 RVA: 0x000CB968 File Offset: 0x000C9B68
    private static void gmPlySeqDeathMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state == 37 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 38 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.dir.z = ( ushort )( obj_work.dir.z + 1024 );
        }
    }

    // Token: 0x06001752 RID: 5970 RVA: 0x000CB9D4 File Offset: 0x000C9BD4
    private static void GmPlySeqChangeTransformSuper( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 24 );
    }

    // Token: 0x06001753 RID: 5971 RVA: 0x000CB9E0 File Offset: 0x000C9BE0
    private static void GmPlySeqInitTransformSuper( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = 0;
        int num2 = 0;
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        if ( ( ply_work.player_flag & 16777216U ) != 0U )
        {
            return;
        }
        ushort z = ply_work.obj_work.dir.z;
        if ( ( ply_work.obj_work.move_flag & 16U ) == 0U )
        {
            num = AppMain.FXM_FLOAT_TO_FX32( AppMain.nnCos( 81920 - ( int )ply_work.obj_work.dir.z ) * 3f );
            num2 = -AppMain.FXM_FLOAT_TO_FX32( AppMain.nnSin( 81920 - ( int )ply_work.obj_work.dir.z ) * 3f );
        }
        AppMain.GmPlayerStateInit( ply_work );
        ply_work.obj_work.move_flag &= 4294967167U;
        ply_work.obj_work.flag |= 2U;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.move_flag |= 8448U;
        }
        if ( ( ply_work.obj_work.move_flag & 16U ) == 0U )
        {
            ply_work.obj_work.move_flag |= 16U;
            ply_work.obj_work.move_flag &= 4294967280U;
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.pos.x = obj_work.pos.x + num;
            AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
            obj_work2.pos.y = obj_work2.pos.y + num2;
        }
        ply_work.obj_work.spd.x = ( ply_work.obj_work.spd.y = 0 );
        ply_work.obj_work.spd_add.x = ( ply_work.obj_work.spd_add.y = 0 );
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.dir.z = 0;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.dir.z = z;
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.pos.z = -32768;
            ply_work.gmk_flag |= 536870912U;
        }
        AppMain.GmPlayerActionChange( ply_work, 50 );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTransformSuperMain );
        ply_work.obj_work.user_timer = 593920;
        ply_work.obj_work.user_work = 0U;
        AppMain.GmPlyEfctCreateSuperStart( ply_work );
    }

    // Token: 0x06001754 RID: 5972 RVA: 0x000CBC34 File Offset: 0x000C9E34
    public static void gmPlySeqTransformSuperMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.user_timer = AppMain.ObjTimeCountDown( ply_work.obj_work.user_timer );
        if ( ply_work.act_state == 50 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 51 );
                ply_work.obj_work.disp_flag |= 4U;
            }
        }
        else if ( ply_work.act_state != 52 && ( ( long )ply_work.obj_work.user_timer & -4096 ) == 286720L )
        {
            AppMain.GmPlayerActionChange( ply_work, 52 );
        }
        if ( ( ( long )ply_work.obj_work.user_timer & -4096 ) == 245760L && ( ply_work.player_flag & 16384U ) == 0U )
        {
            AppMain.GMS_PLAYER_RESET_ACT_WORK reset_act_work = new AppMain.GMS_PLAYER_RESET_ACT_WORK();
            ushort z = ply_work.obj_work.dir.z;
            AppMain.GmPlayerActionChange( ply_work, 53 );
            ply_work.obj_work.disp_flag |= 4U;
            AppMain.GmPlayerSaveResetAction( ply_work, reset_act_work );
            AppMain.GmPlayerSetSuperSonic( ply_work );
            AppMain.GmPlayerResetAction( ply_work, reset_act_work );
            ply_work.obj_work.move_flag &= 4294967167U;
            ply_work.obj_work.flag |= 2U;
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                ply_work.obj_work.move_flag |= 8448U;
            }
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                ply_work.obj_work.dir.z = z;
            }
        }
        if ( ply_work.obj_work.user_timer == 0 )
        {
            ply_work.obj_work.move_flag |= 128U;
            ply_work.obj_work.flag &= 4294967293U;
            ply_work.obj_work.move_flag &= 4294958847U;
            ply_work.super_sonic_ring_timer = 245760;
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                ply_work.obj_work.pos.z = 0;
                ply_work.gmk_flag &= 3758096383U;
            }
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06001755 RID: 5973 RVA: 0x000CBE38 File Offset: 0x000CA038
    private static void GmPlySeqChangeActGoal( AppMain.GMS_PLAYER_WORK ply_work )
    {
        SaveState.deleteSave();
        if ( ( ply_work.player_flag & 1024U ) != 0U || ( AppMain.g_gm_main_system.game_flag & 16384U ) != 0U )
        {
            return;
        }
        uint move_flag = ply_work.obj_work.move_flag;
        AppMain.GmPlayerStateInit( ply_work );
        if ( ply_work.seq_state == 11 || ply_work.seq_state == 12 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
        ply_work.obj_work.move_flag |= ( move_flag & 1U );
        ply_work.obj_work.move_flag &= 4294441983U;
        ply_work.player_flag |= 22020096U;
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.invincible_timer = 0;
    }

    // Token: 0x06001756 RID: 5974 RVA: 0x000CBEE4 File Offset: 0x000CA0E4
    private static void gmPlySeqActGoal( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( AppMain.g_gm_main_system.game_flag & 16384U ) != 0U )
        {
            return;
        }
        ply_work.player_flag |= 4194304U;
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.invincible_timer = 0;
        ply_work.water_timer = 0;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        if ( AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.disp_pos.x ) + ( AppMain.OBD_LCD_X >> 1 ) + 128 > ply_work.obj_work.pos.x >> 12 )
        {
            ply_work.key_on |= 8;
            ply_work.key_walk_rot_z = 32767;
        }
    }

    // Token: 0x06001757 RID: 5975 RVA: 0x000CBF88 File Offset: 0x000CA188
    private static void GmPlySeqChangeBossGoal( AppMain.GMS_PLAYER_WORK ply_work, int capsule_pos_x, int capsule_pos_y )
    {
        SaveState.deleteSave();
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        AppMain.GmPlayerStateInit( ply_work );
        ply_work.player_flag |= 23068672U;
        ply_work.rect_work[0].def_power = 3;
        ply_work.gmk_work0 = capsule_pos_x;
        ply_work.gmk_work1 = capsule_pos_y;
        if ( ply_work.obj_work.pos.x >= capsule_pos_x )
        {
            ply_work.gmk_work2 = 0;
        }
        else
        {
            ply_work.gmk_work2 = 1;
        }
        AppMain.GmPlySeqChangeSequence( ply_work, 0 );
    }

    // Token: 0x06001758 RID: 5976 RVA: 0x000CC008 File Offset: 0x000CA208
    private static void gmPlySeqBossGoalPre( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.player_flag |= 4194304U;
        ply_work.rect_work[0].def_power = 3;
        ply_work.water_timer = 0;
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U || ( ( ply_work.obj_work.move_flag & 1U ) != 0U && ply_work.obj_work.pos.y < ply_work.gmk_work1 - 98304 ) )
        {
            if ( ( ply_work.obj_work.move_flag & 1U ) != 0U || AppMain.MTM_MATH_ABS( ply_work.obj_work.pos.x - ply_work.gmk_work0 ) <= 262144 )
            {
                if ( ply_work.gmk_work2 != 0 )
                {
                    ply_work.key_on |= 4;
                    ply_work.key_walk_rot_z = -32767;
                    return;
                }
                ply_work.key_on |= 8;
                ply_work.key_walk_rot_z = 32767;
                return;
            }
        }
        else
        {
            ply_work.player_flag &= 4292870143U;
            AppMain.GmPlySeqChangeSequence( ply_work, 25 );
        }
    }

    // Token: 0x06001759 RID: 5977 RVA: 0x000CC108 File Offset: 0x000CA308
    private static void GmPlySeqInitBossGaol( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        AppMain.GmPlayerStateInit( ply_work );
        ply_work.player_flag |= 4194304U;
        ply_work.rect_work[0].def_power = 3;
        ply_work.water_timer = 0;
        AppMain.GmPlayerActionChange( ply_work, 0 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.user_timer = 245760;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqBossGoalMain );
    }

    // Token: 0x0600175A RID: 5978 RVA: 0x000CC190 File Offset: 0x000CA390
    private static void gmPlySeqBossGoalMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state == 0 )
        {
            ply_work.obj_work.user_timer = AppMain.ObjTimeCountDown( ply_work.obj_work.user_timer );
            if ( ply_work.obj_work.user_timer == 0 )
            {
                if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
                {
                    AppMain.GmPlySeqSetProgramTurn( ply_work, 4096 );
                }
                AppMain.GmPlayerActionChange( ply_work, 54 );
                return;
            }
        }
        else if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U && ply_work.act_state == 54 )
        {
            AppMain.GmPlayerActionChange( ply_work, 55 );
            ply_work.obj_work.disp_flag |= 4U;
        }
    }

    // Token: 0x0600175B RID: 5979 RVA: 0x000CC224 File Offset: 0x000CA424
    private static void GmPlySeqChangeBoss5Demo( AppMain.GMS_PLAYER_WORK ply_work, int dest_pos_x, bool is_goal )
    {
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        ply_work.player_flag |= 1077936128U;
        if ( is_goal )
        {
            SaveState.deleteSave();
            ply_work.player_flag |= 16777216U;
            ply_work.rect_work[0].def_power = 3;
        }
        ply_work.gmk_work0 = dest_pos_x;
        AppMain.GmPlySeqChangeSequence( ply_work, 0 );
    }

    // Token: 0x0600175C RID: 5980 RVA: 0x000CC2B0 File Offset: 0x000CA4B0
    private static void gmPlySeqBoss5DemoPre( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.pos.x >= ply_work.gmk_work0 )
        {
            if ( ply_work.obj_work.spd.x == 0 )
            {
                ply_work.player_flag &= 3221225471U;
                AppMain.GmPlySeqChangeSequence( ply_work, 26 );
                return;
            }
        }
        else
        {
            ply_work.key_on |= 8;
            ply_work.key_walk_rot_z = 32767;
        }
    }

    // Token: 0x0600175D RID: 5981 RVA: 0x000CC320 File Offset: 0x000CA520
    private static void GmPlySeqInitBoss5Demo( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        AppMain.GmPlayerStateInit( ply_work );
        ply_work.player_flag |= 4194304U;
        if ( ply_work.act_state != 0 )
        {
            AppMain.GmPlayerActionChange( ply_work, 0 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqBoss5DemoMain );
    }

    // Token: 0x0600175E RID: 5982 RVA: 0x000CC388 File Offset: 0x000CA588
    private static void gmPlySeqBoss5DemoMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x0600175F RID: 5983 RVA: 0x000CC38A File Offset: 0x000CA58A
    private static void GmPlySeqChangeBoss5DemoEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        ply_work.player_flag &= 3217031167U;
        AppMain.GmPlySeqChangeSequence( ply_work, 0 );
    }

    // Token: 0x06001760 RID: 5984 RVA: 0x000CC3B5 File Offset: 0x000CA5B5
    private static void GmPlySeqChangeTRetryFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 27 );
    }

    // Token: 0x06001761 RID: 5985 RVA: 0x000CC3C0 File Offset: 0x000CA5C0
    private static void GmPlySeqInitTRetryFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) != 0U )
        {
            AppMain.GmPlayerSetEndPinballSonic( ply_work );
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            AppMain.GmPlayerSetEndTruckRide( ply_work );
        }
        AppMain.GmPlayerSpdParameterSet( ply_work );
        ply_work.obj_work.dir.x = 0;
        ply_work.obj_work.dir.y = 0;
        ply_work.obj_work.dir.z = 0;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd.z = 0;
        ply_work.obj_work.disp_flag &= 4294967292U;
        AppMain.GmPlayerActionChange( ply_work, 4 );
        ply_work.player_flag &= 4293918719U;
        ply_work.obj_work.spd_m = 0;
        ply_work.water_timer = 0;
        ply_work.rect_work[0].def_power = 3;
        ply_work.invincible_timer = 0;
        ply_work.obj_work.move_flag = 16192U;
        ply_work.obj_work.move_flag &= 4294967167U;
        ply_work.obj_work.flag |= 2U;
        ply_work.obj_work.dir_fall = 0;
        ply_work.ply_pseudofall_dir = 0;
        ply_work.jump_pseudofall_dir = 0;
        AppMain.g_gm_main_system.pseudofall_dir = 0;
        ply_work.player_flag |= 4194304U;
        ply_work.player_flag &= 3220176895U;
        ply_work.obj_work.dir_slope = 192;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTRetryFw );
    }

    // Token: 0x06001762 RID: 5986 RVA: 0x000CC567 File Offset: 0x000CA767
    private static void gmPlySeqTRetryFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 5 );
        }
        ply_work.water_timer = 0;
        ply_work.rect_work[0].def_power = 3;
    }

    // Token: 0x06001763 RID: 5987 RVA: 0x000CC594 File Offset: 0x000CA794
    private static void GmPlySeqChangeTRetryAcc( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 28 );
    }

    // Token: 0x06001764 RID: 5988 RVA: 0x000CC59F File Offset: 0x000CA79F
    private static void GmPlySeqInitTRetryAcc( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.player_flag |= 512U;
        AppMain.GmPlySeqMoveWalk( ply_work );
        AppMain.GmPlayerWalkActionSet( ply_work );
        ply_work.obj_work.user_timer = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTRetryAcc );
    }

    // Token: 0x06001765 RID: 5989 RVA: 0x000CC5E0 File Offset: 0x000CA7E0
    private static void gmPlySeqTRetryAcc( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.user_timer++;
        ply_work.obj_work.spd_m += 512;
        if ( ply_work.obj_work.user_timer > 100 )
        {
            ply_work.seq_func = null;
            ply_work.obj_work.user_timer = 0;
            ply_work.obj_work.move_flag &= 4294959103U;
            ply_work.obj_work.move_flag &= 4294966271U;
            ply_work.obj_work.flag |= 16U;
        }
        if ( ply_work.obj_work.spd_m > ply_work.spd4 - 512 && ( ply_work.player_flag & 1048576U ) == 0U )
        {
            ply_work.obj_work.dir.z = 4097;
            AppMain.GmPlayerWalkActionSet( ply_work );
            AppMain.GmPlayerWalkActionCheck( ply_work );
            ply_work.obj_work.dir.z = 0;
            AppMain.GmPlySeqChangeTRetryRun( ply_work );
        }
        ply_work.water_timer = 0;
        ply_work.rect_work[0].def_power = 3;
    }

    // Token: 0x06001766 RID: 5990 RVA: 0x000CC6EF File Offset: 0x000CA8EF
    private static void GmPlySeqChangeTRetryRun( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.player_flag |= 1048576U;
    }

    // Token: 0x06001767 RID: 5991 RVA: 0x000CC704 File Offset: 0x000CA904
    private static void GmPlySeqInitTruckFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m != 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 1 );
            return;
        }
        if ( ( ply_work.obj_work.move_flag & 4194304U ) == 0U )
        {
            ply_work.gmk_flag &= 4293918719U;
            AppMain.GmPlayerActionChange( ply_work, 73 );
        }
        else if ( ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][0]].act_id[0] != ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][0] && ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][73]].act_id[0] != ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][73] )
        {
            if ( ( ply_work.gmk_flag & 1048576U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 70 );
            }
            else
            {
                AppMain.GmPlayerActionChange( ply_work, 69 );
            }
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckFwMain );
    }

    // Token: 0x06001768 RID: 5992 RVA: 0x000CC824 File Offset: 0x000CAA24
    private static void gmPlySeqTruckFwMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][73]].act_id[0] == ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][73] && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            if ( ( ply_work.gmk_flag & 1048576U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 70 );
            }
            else
            {
                AppMain.GmPlayerActionChange( ply_work, 69 );
            }
            ply_work.obj_work.disp_flag |= 4U;
        }
        if ( ply_work.act_state == 69 || ply_work.act_state == 70 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                uint user_work = ply_work.obj_work.user_work;
                ply_work.obj_work.user_work = ply_work.obj_work.user_work + 1U;
                if ( ply_work.obj_work.user_work >= 8U )
                {
                    AppMain.GmPlayerActionChange( ply_work, 2 );
                    ply_work.obj_work.user_work = 0U;
                    return;
                }
            }
        }
        else if ( ply_work.act_state == 2 || ply_work.act_state == 4 || ply_work.act_state == 6 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, ply_work.act_state + 1 );
                ply_work.obj_work.disp_flag |= 4U;
                ply_work.obj_work.user_work = 0U;
                return;
            }
        }
        else if ( ply_work.act_state == 3 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            int user_work2 = (int)(ply_work.obj_work.user_work + 1U);
            ply_work.obj_work.user_work = ( uint )user_work2;
            if ( ply_work.obj_work.user_work >= 10U )
            {
                AppMain.GmPlayerActionChange( ply_work, 4 );
                ply_work.obj_work.user_work = 0U;
            }
        }
    }

    // Token: 0x06001769 RID: 5993 RVA: 0x000CC9C0 File Offset: 0x000CABC0
    private static void GmPlySeqInitTruckWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 4194304U ) == 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 73 );
        }
        else if ( ply_work.act_state != 71 && ply_work.act_state != 72 )
        {
            if ( ( ply_work.gmk_flag & 1048576U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 72 );
            }
            else
            {
                AppMain.GmPlayerActionChange( ply_work, 71 );
            }
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckWalkMain );
        ply_work.obj_work.user_timer = 0;
        ply_work.truck_left_flip_timer = 245760;
    }

    // Token: 0x0600176A RID: 5994 RVA: 0x000CCA70 File Offset: 0x000CAC70
    private static void gmPlySeqTruckWalkMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        bool flag = false;
        if ( ply_work.obj_work.spd_m < 0 && ply_work.act_state == 71 )
        {
            ply_work.truck_left_flip_timer = AppMain.ObjTimeCountDown( ply_work.truck_left_flip_timer );
            if ( ply_work.truck_left_flip_timer == 0 )
            {
                ply_work.gmk_flag |= 1048576U;
                flag = true;
            }
        }
        else
        {
            ply_work.truck_left_flip_timer = 245760;
            if ( ply_work.obj_work.spd_m >= 0 && ply_work.act_state == 72 )
            {
                ply_work.gmk_flag &= 4293918719U;
                flag = true;
            }
        }
        if ( flag )
        {
            float num = ply_work.obj_work.obj_3d.frame[0];
            if ( ( ply_work.gmk_flag & 1048576U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 72 );
            }
            else
            {
                AppMain.GmPlayerActionChange( ply_work, 71 );
            }
            ply_work.obj_work.disp_flag |= 4U;
            ply_work.obj_work.obj_3d.frame[0] = ( ply_work.obj_work.obj_3d.frame[1] = num );
        }
        if ( ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][73]].act_id[0] == ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][73] && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            if ( ply_work.obj_work.spd_m >= 0 )
            {
                ply_work.gmk_flag &= 4293918719U;
                AppMain.GmPlayerActionChange( ply_work, 71 );
            }
            else if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.gmk_flag |= 1048576U;
                AppMain.GmPlayerActionChange( ply_work, 72 );
            }
            ply_work.obj_work.disp_flag |= 4U;
        }
    }

    // Token: 0x0600176B RID: 5995 RVA: 0x000CCC10 File Offset: 0x000CAE10
    private static void GmPlySeqInitTruckFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][40]].act_id[0] != ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][40] )
        {
            AppMain.GmPlayerActionChange( ply_work, 40 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 49296U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.gmk_flag &= 1073479679U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckJumpMain );
        ushort angle = (ushort)(ply_work.obj_work.dir.z + ply_work.obj_work.dir_fall - ply_work.jump_pseudofall_dir);
        ply_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )angle ) );
        ply_work.obj_work.spd.y = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathSin( ( int )angle ) );
        ply_work.player_flag &= 4294967280U;
        ply_work.player_flag |= 1U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.timer = 0;
    }

    // Token: 0x0600176C RID: 5996 RVA: 0x000CCD78 File Offset: 0x000CAF78
    private static void GmPlySeqInitTruckJump( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][40]].act_id[0] != ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][40] )
        {
            AppMain.GmPlayerActionChange( ply_work, 40 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag |= 49168U;
        ply_work.obj_work.move_flag &= 4290772990U;
        ushort num = ply_work.obj_work.dir.z;
        if ( ( num + 256 & 8192 ) != 0 && ( num + 256 & 4095 ) <= 1024 )
        {
            if ( ply_work.obj_work.spd_m > 0 && num < 32768 )
            {
                num -= 1152;
            }
            else if ( ply_work.obj_work.spd_m < 0 && num > 32768 )
            {
                num += 1152;
            }
        }
        num = ( ushort )( num + ply_work.obj_work.dir_fall - ply_work.jump_pseudofall_dir );
        ply_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )num ) );
        ply_work.obj_work.spd.y = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathSin( ( int )num ) );
        num = ( ushort )( ply_work.obj_work.dir.z + ply_work.obj_work.dir_fall - ply_work.jump_pseudofall_dir );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.spd.x = obj_work.spd.x + AppMain.FX_Mul( ply_work.spd_jump, AppMain.mtMathSin( ( int )num ) );
        AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
        obj_work2.spd.y = obj_work2.spd.y + AppMain.FX_Mul( -ply_work.spd_jump, AppMain.mtMathCos( ( int )num ) );
        ply_work.player_flag &= 4294967280U;
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.timer = 0;
        AppMain.GmPlySeqSetJumpState( ply_work, 0, 0U );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckJumpMain );
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmSoundPlaySE( "Lorry3" );
    }

    // Token: 0x0600176D RID: 5997 RVA: 0x000CCFA0 File Offset: 0x000CB1A0
    private static void gmPlySeqTruckJumpMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int y = ply_work.obj_work.spd.y;
        if ( ply_work.obj_work.user_timer != 0 )
        {
            ply_work.obj_work.user_timer--;
            if ( ply_work.obj_work.user_timer == 0 )
            {
                ply_work.obj_work.move_flag |= 128U;
            }
        }
        if ( ( ply_work.player_flag & 5U ) == 0U && !AppMain.GmPlayerKeyCheckJumpKeyOn( ply_work ) && y < -16384 )
        {
            ply_work.player_flag |= 4U;
        }
        if ( ( ply_work.player_flag & 4U ) != 0U && ply_work.obj_work.spd.y < 0 )
        {
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.spd.y = obj_work.spd.y + ply_work.obj_work.spd_fall;
        }
        if ( ( ply_work.obj_work.move_flag & 6U ) == 0U )
        {
            bool flag = false;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < 4096 )
            {
                flag = true;
            }
            if ( flag )
            {
                ushort angle = (ushort)(ply_work.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir);
                AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
                obj_work2.spd.x = obj_work2.spd.x + AppMain.mtMathSin( ( int )angle );
            }
        }
        if ( ( ply_work.obj_work.move_flag & 2U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obj_work3 = ply_work.obj_work;
            obj_work3.spd.y = obj_work3.spd.y + ply_work.obj_work.spd_fall * 5;
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmSoundPlaySE( "Lorry4" );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            AppMain.GMM_PAD_VIB_MID();
        }
    }

    // Token: 0x0600176E RID: 5998 RVA: 0x000CD130 File Offset: 0x000CB330
    private static void GmPlySeqInitTruckSquatStart( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 14 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckSquatMain );
    }

    // Token: 0x0600176F RID: 5999 RVA: 0x000CD160 File Offset: 0x000CB360
    private static void GmPlySeqInitTruckSquatMiddle( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 15 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 4096 )
        {
            ply_work.obj_work.spd_m = 0;
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckSquatMain );
    }

    // Token: 0x06001770 RID: 6000 RVA: 0x000CD1D1 File Offset: 0x000CB3D1
    private static void GmPlySeqInitTruckSquatEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 16 );
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqSquatEndMain );
    }

    // Token: 0x06001771 RID: 6001 RVA: 0x000CD204 File Offset: 0x000CB404
    private static void gmPlySeqTruckSquatMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m != 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 1 );
            return;
        }
        int act_state = ply_work.act_state;
        if ( act_state != 14 )
        {
            return;
        }
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 7 );
        }
    }

    // Token: 0x06001772 RID: 6002 RVA: 0x000CD24C File Offset: 0x000CB44C
    private static void GmPlySeqInitTruckStaggerFront( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 33 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckStaggerMain );
        ply_work.obj_work.user_timer = 0;
        AppMain.GmPlyEfctCreateSweat( ply_work );
    }

    // Token: 0x06001773 RID: 6003 RVA: 0x000CD2AC File Offset: 0x000CB4AC
    private static void GmPlySeqInitTruckStaggerBack( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerActionChange( ply_work, 34 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqTruckStaggerMain );
        ply_work.obj_work.user_timer = 0;
        AppMain.GmPlyEfctCreateSweat( ply_work );
    }

    // Token: 0x06001774 RID: 6004 RVA: 0x000CD30C File Offset: 0x000CB50C
    private static void gmPlySeqTruckStaggerMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.gmk_flag & 262144U ) == 0U )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( ply_work.seq_state == 13 )
        {
            ply_work.obj_work.user_timer += 1024;
            if ( ply_work.obj_work.user_timer > 8192 )
            {
                ply_work.obj_work.user_timer = 8192;
                return;
            }
        }
        else
        {
            ply_work.obj_work.user_timer -= 1024;
            if ( ply_work.obj_work.user_timer < -8192 )
            {
                ply_work.obj_work.user_timer = -8192;
            }
        }
    }

    // Token: 0x06001775 RID: 6005 RVA: 0x000CD3B0 File Offset: 0x000CB5B0
    private static void GmPlySeqLandingSet( AppMain.GMS_PLAYER_WORK ply_work, ushort dir_z )
    {
        AppMain.GmPlayerSpdParameterSet( ply_work );
        ply_work.obj_work.move_flag &= 4294934511U;
        ply_work.obj_work.move_flag |= 128U;
        ply_work.obj_work.disp_flag &= 4294967263U;
        ply_work.gmk_flag &= 4278190079U;
        ply_work.gmk_flag2 &= 4294967007U;
        ply_work.gmk_flag2 &= 4294966783U;
        ply_work.player_flag &= 4294967135U;
        ply_work.no_jump_move_timer = 0;
        ply_work.score_combo_cnt = 0U;
        if ( ( ply_work.gmk_flag & 1U ) == 0U && ( ply_work.obj_work.col_flag & 1U ) != 0U )
        {
            ply_work.obj_work.dir.z = 0;
        }
        if ( dir_z > 0 )
        {
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                if ( ( ply_work.gmk_flag2 & 1U ) != 0U )
                {
                    ply_work.obj_work.spd_m += AppMain.FX_Mul( AppMain.FX_Mul( ply_work.obj_work.move.x, 2048 ), AppMain.mtMathCos( ( int )( dir_z - AppMain.g_gm_main_system.pseudofall_dir ) ) );
                    ply_work.obj_work.spd_m += AppMain.FX_Mul( AppMain.FX_Mul( ply_work.obj_work.move.y, 2048 ), AppMain.mtMathSin( ( int )( dir_z - AppMain.g_gm_main_system.pseudofall_dir ) ) );
                }
                else
                {
                    ply_work.obj_work.spd_m += AppMain.FX_Mul( ply_work.obj_work.move.x, AppMain.mtMathCos( ( int )( dir_z - AppMain.g_gm_main_system.pseudofall_dir ) ) );
                    ply_work.obj_work.spd_m += AppMain.FX_Mul( ply_work.obj_work.move.y, AppMain.mtMathSin( ( int )( dir_z - AppMain.g_gm_main_system.pseudofall_dir ) ) );
                }
            }
            else
            {
                ply_work.obj_work.spd_m += AppMain.FX_Mul( ply_work.obj_work.move.x, AppMain.mtMathCos( ( int )dir_z ) );
                ply_work.obj_work.spd_m += AppMain.FX_Mul( ply_work.obj_work.move.y, AppMain.mtMathSin( ( int )dir_z ) );
                if ( AppMain.ObjObjectDirFallReverseCheck( ply_work.obj_work.dir_fall ) != 0U )
                {
                    ply_work.obj_work.spd_m = -ply_work.obj_work.spd_m;
                }
            }
        }
        else if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) )
            {
                ply_work.obj_work.spd_m = ply_work.obj_work.spd.x;
            }
            ply_work.obj_work.spd_m += AppMain.FX_Mul( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ), AppMain.mtMathSin( ( int )( ply_work.obj_work.dir.z + ( ply_work.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir ) ) ) );
        }
        else
        {
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) )
            {
                ply_work.obj_work.spd_m = ply_work.obj_work.spd.x;
            }
            ply_work.obj_work.spd_m += AppMain.FX_Mul( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ), AppMain.mtMathSin( ( int )ply_work.obj_work.dir.z ) );
        }
        ply_work.gmk_flag2 &= 4294967294U;
        ply_work.spd_work_max = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
        if ( ply_work.spd_work_max > ply_work.obj_work.spd_slope_max )
        {
            ply_work.spd_work_max = ply_work.obj_work.spd_slope_max;
        }
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        if ( dir_z != 0 )
        {
            ply_work.obj_work.dir.z = dir_z;
        }
        if ( ( ply_work.gmk_flag & 4096U ) == 0U )
        {
            ply_work.obj_work.dir.x = 0;
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.move_flag &= 4294950911U;
        }
    }

    // Token: 0x06001776 RID: 6006 RVA: 0x000CD830 File Offset: 0x000CBA30
    private static void GmPlySeqMoveFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        AppMain.GMS_PLY_SEQ_STATE_DATA[] seq_state_data_tbl = gms_PLAYER_WORK.seq_state_data_tbl;
        if ( ( seq_state_data_tbl[gms_PLAYER_WORK.seq_state].check_attr & 2147483648U ) != 0U )
        {
            if ( ( gms_PLAYER_WORK.player_flag & 32768U ) != 0U )
            {
                AppMain.GmPlySeqMoveWalkAutoRun( gms_PLAYER_WORK );
            }
            else if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
            {
                AppMain.GmPlySeqMoveWalkTruck( gms_PLAYER_WORK );
            }
            else
            {
                AppMain.GmPlySeqMoveWalk( gms_PLAYER_WORK );
            }
        }
        if ( ( seq_state_data_tbl[gms_PLAYER_WORK.seq_state].check_attr & 1073741824U ) != 0U && ( gms_PLAYER_WORK.player_flag & 32U ) == 0U )
        {
            if ( ( gms_PLAYER_WORK.player_flag & 32768U ) != 0U )
            {
                AppMain.GmPlySeqMoveJumpAutoRun( gms_PLAYER_WORK );
            }
            else if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
            {
                AppMain.GmPlySeqMoveJumpTruck( gms_PLAYER_WORK );
            }
            else
            {
                AppMain.GmPlySeqMoveJump( gms_PLAYER_WORK );
            }
        }
        if ( gms_PLAYER_WORK.no_jump_move_timer != 0 )
        {
            gms_PLAYER_WORK.no_jump_move_timer = AppMain.ObjTimeCountDown( gms_PLAYER_WORK.no_jump_move_timer );
            if ( gms_PLAYER_WORK.no_jump_move_timer == 0 )
            {
                gms_PLAYER_WORK.player_flag &= 4294967263U;
            }
        }
        if ( ( seq_state_data_tbl[gms_PLAYER_WORK.seq_state].check_attr & 536870912U ) != 0U )
        {
            AppMain.GmPlySeqMoveSpin( gms_PLAYER_WORK );
        }
        if ( ( seq_state_data_tbl[gms_PLAYER_WORK.seq_state].check_attr & 134217728U ) != 0U )
        {
            AppMain.GmPlySeqMoveSpinNoDec( gms_PLAYER_WORK );
        }
        if ( ( seq_state_data_tbl[gms_PLAYER_WORK.seq_state].check_attr & 67108864U ) != 0U )
        {
            AppMain.GmPlySeqMoveSpinPinball( gms_PLAYER_WORK );
        }
        if ( ( seq_state_data_tbl[gms_PLAYER_WORK.seq_state].check_attr & 268435456U ) != 0U )
        {
            if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
            {
                AppMain.GmPlySeqTruckJumpDirec( gms_PLAYER_WORK );
            }
            else if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
            {
                AppMain.gmPlySeqSplJumpDirec( gms_PLAYER_WORK );
            }
            else
            {
                AppMain.GmPlySeqJumpDirec( gms_PLAYER_WORK );
            }
        }
        if ( ( gms_PLAYER_WORK.player_flag & 32768U ) != 0U && ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U && obj_work.pos.x <= AppMain.g_obj.camera[0][0] + 65536 && obj_work.pos.x > AppMain.g_obj.camera[0][0] + 65536 - 4194304 )
        {
            if ( ( obj_work.move_flag & 16U ) != 0U )
            {
                if ( obj_work.spd.x < gms_PLAYER_WORK.scroll_spd_x )
                {
                    obj_work.spd.x = gms_PLAYER_WORK.scroll_spd_x;
                    if ( ( obj_work.disp_flag & 1U ) != 0U )
                    {
                        AppMain.GmPlySeqSetProgramTurn( gms_PLAYER_WORK, 4096 );
                    }
                }
            }
            else if ( obj_work.spd_m < gms_PLAYER_WORK.scroll_spd_x )
            {
                obj_work.spd_m = gms_PLAYER_WORK.scroll_spd_x;
                if ( 3 <= gms_PLAYER_WORK.seq_state && gms_PLAYER_WORK.seq_state <= 5 )
                {
                    AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 0 );
                }
                if ( ( obj_work.disp_flag & 1U ) != 0U )
                {
                    if ( gms_PLAYER_WORK.seq_state == 10 )
                    {
                        AppMain.GmPlayerSetReverse( gms_PLAYER_WORK );
                        AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 0 );
                    }
                    else if ( 6 <= gms_PLAYER_WORK.seq_state && gms_PLAYER_WORK.seq_state <= 8 )
                    {
                        AppMain.GmPlySeqSetProgramTurn( gms_PLAYER_WORK, 4096 );
                    }
                    else
                    {
                        AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 2 );
                    }
                }
            }
        }
        if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
        {
            if ( ( obj_work.move_flag & 1U ) == 0U || ( gms_PLAYER_WORK.gmk_flag & 262144U ) == 0U )
            {
                AppMain.gmPlySeqTruckMove( obj_work );
                return;
            }
        }
        else
        {
            if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
            {
                AppMain.gmPlySeqSplMove( obj_work );
                return;
            }
            AppMain.ObjObjectMove( obj_work );
        }
    }

    // Token: 0x06001777 RID: 6007 RVA: 0x000CDB24 File Offset: 0x000CBD24
    private static void GmPlySeqMoveWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.spd_add;
        int num2 = ply_work.spd_dec;
        int num3 = ply_work.spd_max;
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) || AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) )
        {
            int num4 = AppMain.MTM_MATH_ABS(ply_work.key_walk_rot_z);
            if ( num4 > 24576 )
            {
                num4 = 24576;
            }
            num3 = num3 * num4 / 24576;
        }
        if ( num3 < ply_work.prev_walk_roll_spd_max )
        {
            num3 = ply_work.prev_walk_roll_spd_max - num2;
            if ( num3 < 0 )
            {
                num3 = 0;
            }
        }
        ply_work.prev_walk_roll_spd_max = num3;
        if ( ply_work.obj_work.dir.z > 0 )
        {
            int num5 = AppMain.FX_Mul(ply_work.spd_max_add_slope, AppMain.mtMathSin((int)ply_work.obj_work.dir.z));
            if ( num5 > 0 )
            {
                num3 += num5;
            }
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num2 = 0;
        }
        else
        {
            int num6 = 0;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) > ply_work.spd3 )
            {
                if ( num3 - ply_work.spd3 != 0 )
                {
                    num6 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) - ply_work.spd3, num3 - ply_work.spd3 );
                    if ( num6 > 4096 )
                    {
                        num6 = 4096;
                    }
                }
                else
                {
                    num6 = 4096;
                }
                num6 = num6 * 3968 >> 12;
            }
            num -= AppMain.FX_Mul( num, num6 );
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATER_SET( ref num );
            AppMain.GMD_PLAYER_WATER_SET( ref num2 );
        }
        if ( ply_work.spd_work_max >= num3 && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= num3 )
        {
            if ( ply_work.spd_work_max > ply_work.obj_work.spd_m )
            {
                ply_work.spd_work_max = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
            }
            num3 = ply_work.spd_work_max;
        }
        if ( ( ply_work.player_flag & 32768U ) != 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && num3 > ply_work.scroll_spd_x + 8192 )
        {
            num3 = ply_work.scroll_spd_x + 8192;
        }
        if ( !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            ply_work.spd_pool = 0;
            ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -num3, num3 );
            ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -num3, num3 );
            if ( ( ply_work.obj_work.dir.z + 8192 & 65280 ) <= 16384 )
            {
                if ( ( ply_work.player_flag & 134217728U ) != 0U )
                {
                    ply_work.player_flag &= 4160749567U;
                    return;
                }
                if ( ( ply_work.player_flag & 32768U ) != 0U )
                {
                    if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U || ply_work.seq_state != 1 )
                    {
                        ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                        return;
                    }
                    int num7 = ply_work.scroll_spd_x + -4096;
                    if ( num7 < 0 )
                    {
                        num7 = 0;
                    }
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                    if ( ply_work.obj_work.spd_m < num7 )
                    {
                        ply_work.obj_work.spd_m = num7;
                        return;
                    }
                }
                else
                {
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                }
            }
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
            }
            ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, num, num3 );
            return;
        }
        if ( ply_work.obj_work.spd_m > 0 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, -num, num3 );
    }

    // Token: 0x06001778 RID: 6008 RVA: 0x000CDEEC File Offset: 0x000CC0EC
    private static void GmPlySeqMoveWalkTruck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.gmk_flag & 262144U ) != 0U )
        {
            return;
        }
        int num = ply_work.spd_add;
        int sSpd = ply_work.spd_dec;
        int num2 = ply_work.spd_max;
        ushort num3 = (ushort)(ply_work.obj_work.dir.z + (ply_work.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir));
        if ( num3 != 0 )
        {
            int num4 = AppMain.FX_Mul(ply_work.spd_max_add_slope, AppMain.mtMathSin((int)num3));
            if ( num4 > 0 )
            {
                num2 += num4;
            }
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            sSpd = 0;
        }
        else
        {
            int num5 = 0;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) > ply_work.spd3 )
            {
                if ( num2 - ply_work.spd3 != 0 )
                {
                    num5 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) - ply_work.spd3, num2 - ply_work.spd3 );
                    if ( num5 > 4096 )
                    {
                        num5 = 4096;
                    }
                }
                else
                {
                    num5 = 4096;
                }
                num5 = num5 * 3968 >> 12;
            }
            num -= AppMain.FX_Mul( num, num5 );
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATER_SET( ref num );
            AppMain.GMD_PLAYER_WATER_SET( ref sSpd );
        }
        if ( ply_work.spd_work_max >= num2 && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= num2 )
        {
            if ( ply_work.spd_work_max > ply_work.obj_work.spd_m )
            {
                ply_work.spd_work_max = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
            }
            num2 = ply_work.spd_work_max;
        }
        if ( ( ( AppMain.g_gm_main_system.game_flag & 1048576U ) == 0U && ( ply_work.player_flag & 16777216U ) == 0U ) || !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            if ( ( int )( num3 + ply_work.obj_work.dir_slope & 65535 ) < ( int )ply_work.obj_work.dir_slope << 1 )
            {
                ply_work.spd_pool = 0;
                ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -num2, num2 );
                ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -num2, num2 );
                if ( ( num3 + 2048 & 65280 ) <= 4096 )
                {
                    if ( ( ply_work.player_flag & 134217728U ) != 0U )
                    {
                        ply_work.player_flag &= 4160749567U;
                        return;
                    }
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, sSpd );
                }
            }
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, sSpd );
            }
            ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, num, num2 );
            return;
        }
        if ( ply_work.obj_work.spd_m > 0 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, sSpd );
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, -num, num2 );
    }

    // Token: 0x06001779 RID: 6009 RVA: 0x000CE1E8 File Offset: 0x000CC3E8
    private static void GmPlySeqMoveWalkAutoRun( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.spd_add;
        int num2 = ply_work.spd_dec;
        int num3 = ply_work.spd_max;
        num3 = AppMain.FX_F32_TO_FX32( 9.5f );
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd_m <= ply_work.spd3 )
            {
                num >>= 2;
            }
            if ( ply_work.obj_work.spd_m < ply_work.scroll_spd_x + AppMain.FX_F32_TO_FX32( 0.25f ) )
            {
                ply_work.obj_work.spd_m = ply_work.scroll_spd_x + AppMain.FX_F32_TO_FX32( 0.25f );
            }
            if ( ply_work.obj_work.spd_m < AppMain.FX_F32_TO_FX32( 8.4f ) )
            {
                ply_work.obj_work.spd_m = AppMain.FX_F32_TO_FX32( 8.4f );
            }
            if ( ply_work.obj_work.spd_m > AppMain.FX_F32_TO_FX32( 8.7f ) )
            {
                ply_work.obj_work.spd_m = AppMain.FX_F32_TO_FX32( 8.7f );
            }
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) || AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) )
        {
            int num4 = AppMain.MTM_MATH_ABS(ply_work.key_walk_rot_z);
            if ( num4 > 24576 )
            {
                num4 = 24576;
            }
            num3 = num3 * num4 / 24576;
        }
        if ( num3 < ply_work.prev_walk_roll_spd_max )
        {
            num3 = ply_work.prev_walk_roll_spd_max - num2;
            if ( num3 < 0 )
            {
                num3 = 0;
            }
        }
        ply_work.prev_walk_roll_spd_max = num3;
        if ( ply_work.obj_work.dir.z != 0 )
        {
            int num5 = AppMain.FX_Mul(ply_work.spd_max_add_slope, AppMain.mtMathSin((int)ply_work.obj_work.dir.z));
            if ( num5 > 0 )
            {
                num3 += num5;
            }
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num2 = 0;
        }
        else
        {
            int num6 = 0;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) > ply_work.spd3 )
            {
                if ( num3 - ply_work.spd3 != 0 )
                {
                    num6 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) - ply_work.spd3, num3 - ply_work.spd3 );
                    if ( num6 > 4096 )
                    {
                        num6 = 4096;
                    }
                }
                else
                {
                    num6 = 4096;
                }
                num6 = num6 * 3968 >> 12;
            }
            num -= AppMain.FX_Mul( num, num6 );
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATER_SET( ref num );
            AppMain.GMD_PLAYER_WATER_SET( ref num2 );
        }
        if ( ply_work.spd_work_max >= num3 && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= num3 )
        {
            if ( ply_work.spd_work_max > ply_work.obj_work.spd_m )
            {
                ply_work.spd_work_max = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
            }
            num3 = ply_work.spd_work_max;
        }
        if ( ( ply_work.player_flag & 32768U ) != 0U )
        {
            ply_work.spd_work_max += 8192;
            num3 = ply_work.spd_work_max + 8192;
        }
        if ( !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            ply_work.spd_pool = 0;
            ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -num3, num3 );
            ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -num3, num3 );
            if ( ( ply_work.obj_work.dir.z + 8192 & 65280 ) <= 16384 )
            {
                if ( ( ply_work.player_flag & 134217728U ) != 0U )
                {
                    ply_work.player_flag &= 4160749567U;
                    return;
                }
                if ( ( ply_work.player_flag & 32768U ) != 0U )
                {
                    if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U || ply_work.seq_state != 1 )
                    {
                        ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                        return;
                    }
                    int num7 = ply_work.scroll_spd_x + -4096;
                    if ( num7 < 0 )
                    {
                        num7 = 0;
                    }
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                    if ( ply_work.obj_work.spd_m < num7 )
                    {
                        ply_work.obj_work.spd_m = num7;
                        return;
                    }
                }
                else
                {
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                }
            }
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
            }
            ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, num, num3 );
            return;
        }
        if ( ply_work.obj_work.spd_m > 0 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, -num, num3 );
    }

    // Token: 0x0600177A RID: 6010 RVA: 0x000CE668 File Offset: 0x000CC868
    private static void GmPlySeqMoveJump( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.spd_jump_add;
        int num2 = ply_work.spd_jump_dec;
        int spd_jump_dec = ply_work.spd_jump_dec;
        int spd_jump_max = ply_work.spd_jump_max;
        ply_work.spd_work_max = 0;
        if ( ( ply_work.obj_work.dir.z + 8192 & 49152 ) != 0 || ply_work.obj_work.dir.z == 57344 )
        {
            num2 >>= 2;
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num2 = 0;
            num >>= 2;
        }
        else
        {
            int num3 = 0;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) > ply_work.spd2 )
            {
                if ( spd_jump_max - ply_work.spd2 != 0 )
                {
                    num3 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) - ply_work.spd2, spd_jump_max - ply_work.spd2 );
                    if ( num3 > 4096 )
                    {
                        num3 = 4096;
                    }
                }
                else
                {
                    num3 = 4096;
                }
                num3 = num3 * 3968 >> 12;
            }
            num -= AppMain.FX_Mul( num, num3 );
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATER_SET( ref num );
            AppMain.GMD_PLAYER_WATER_SET( ref num2 );
        }
        int sSpd = AppMain.FX_Mul(num2, 4096);
        AppMain.FX_Mul( spd_jump_dec, 4096 );
        if ( !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -spd_jump_max, spd_jump_max );
            ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -spd_jump_max, spd_jump_max );
            ply_work.spd_pool = 0;
            ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, num2 );
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd.x < 0 )
            {
                ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, sSpd );
            }
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
            ply_work.obj_work.spd.x = AppMain.ObjSpdUpSet( ply_work.obj_work.spd.x, num, spd_jump_max );
            return;
        }
        if ( ply_work.obj_work.spd.x > 0 )
        {
            ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, sSpd );
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
        ply_work.obj_work.spd.x = AppMain.ObjSpdUpSet( ply_work.obj_work.spd.x, -num, spd_jump_max );
    }

    // Token: 0x0600177B RID: 6011 RVA: 0x000CE948 File Offset: 0x000CCB48
    private static void GmPlySeqMoveJumpTruck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.spd_jump_add;
        int num2 = ply_work.spd_jump_dec;
        int spd_jump_dec = ply_work.spd_jump_dec;
        int spd_jump_max = ply_work.spd_jump_max;
        ply_work.spd_work_max = 0;
        if ( ( ply_work.obj_work.dir.z + 8192 & 49152 ) != 0 || ply_work.obj_work.dir.z == 57344 )
        {
            num2 >>= 2;
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num2 = 0;
            num >>= 2;
        }
        else
        {
            int num3 = 0;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) > ply_work.spd2 )
            {
                if ( spd_jump_max - ply_work.spd2 != 0 )
                {
                    num3 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) - ply_work.spd2, spd_jump_max - ply_work.spd2 );
                    if ( num3 > 4096 )
                    {
                        num3 = 4096;
                    }
                }
                else
                {
                    num3 = 4096;
                }
                num3 = num3 * 3968 >> 12;
            }
            num -= AppMain.FX_Mul( num, num3 );
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATER_SET( ref num );
            AppMain.GMD_PLAYER_WATER_SET( ref num2 );
        }
        int num4 = AppMain.FX_Mul(num2, 4096);
        int num5 = AppMain.FX_Mul(spd_jump_dec, 4096);
        int num6 = 12288;
        if ( ( ply_work.gmk_flag2 & 512U ) != 0U )
        {
            ushort angle = (ushort)(ply_work.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir);
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.spd.x = obj_work.spd.x + AppMain.mtMathSin( ( int )angle ) / 3;
            if ( ply_work.obj_work.spd.x > num6 )
            {
                ply_work.obj_work.spd.x = num6;
                return;
            }
            if ( ply_work.obj_work.spd.x < -num6 )
            {
                ply_work.obj_work.spd.x = -num6;
                return;
            }
        }
        else
        {
            if ( ( ply_work.gmk_flag2 & 1U ) != 0U )
            {
                num4 = AppMain.FX_Mul( num4, 3072 );
                num5 = AppMain.FX_Mul( num5, 3072 );
                ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -spd_jump_max, spd_jump_max );
                ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -spd_jump_max, spd_jump_max );
                ply_work.spd_pool = 0;
                ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, num4 );
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num5 );
                return;
            }
            if ( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
            {
                if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
                {
                    if ( ply_work.obj_work.spd.x < 0 )
                    {
                        ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, num4 );
                    }
                    if ( ply_work.obj_work.spd_m < 0 )
                    {
                        ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
                    }
                    ply_work.obj_work.spd.x = AppMain.ObjSpdUpSet( ply_work.obj_work.spd.x, num, spd_jump_max );
                    return;
                }
                if ( ply_work.obj_work.spd.x > 0 )
                {
                    ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, num4 );
                }
                if ( ply_work.obj_work.spd_m > 0 )
                {
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
                }
                ply_work.obj_work.spd.x = AppMain.ObjSpdUpSet( ply_work.obj_work.spd.x, -num, spd_jump_max );
                return;
            }
            else
            {
                ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -spd_jump_max, spd_jump_max );
                ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -spd_jump_max, spd_jump_max );
                ply_work.spd_pool = 0;
                ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, num2 );
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
            }
        }
    }

    // Token: 0x0600177C RID: 6012 RVA: 0x000CEDAC File Offset: 0x000CCFAC
    private static void GmPlySeqMoveJumpAutoRun( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.spd_jump_add;
        int num2 = ply_work.spd_jump_dec;
        int spd_jump_dec = ply_work.spd_jump_dec;
        int spd_jump_max = ply_work.spd_jump_max;
        ply_work.spd_work_max = 0;
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            num = 0;
        }
        if ( ( ply_work.obj_work.dir.z + 8192 & 49152 ) != 0 || ply_work.obj_work.dir.z == 57344 )
        {
            num2 >>= 2;
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num2 = 0;
            num >>= 2;
        }
        else
        {
            int num3 = 0;
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) > ply_work.spd2 )
            {
                if ( spd_jump_max - ply_work.spd2 != 0 )
                {
                    num3 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) - ply_work.spd2, spd_jump_max - ply_work.spd2 );
                    if ( num3 > 4096 )
                    {
                        num3 = 4096;
                    }
                }
                else
                {
                    num3 = 4096;
                }
                num3 = num3 * 3968 >> 12;
            }
            num -= AppMain.FX_Mul( num, num3 );
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATER_SET( ref num );
            AppMain.GMD_PLAYER_WATER_SET( ref num2 );
        }
        int sSpd = AppMain.FX_Mul(num2, 4096);
        AppMain.FX_Mul( spd_jump_dec, 4096 );
        if ( !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -spd_jump_max, spd_jump_max );
            ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -spd_jump_max, spd_jump_max );
            ply_work.spd_pool = 0;
            ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, num2 );
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd.x < 0 )
            {
                ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, sSpd );
            }
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
            }
            ply_work.obj_work.spd.x = AppMain.ObjSpdUpSet( ply_work.obj_work.spd.x, num, spd_jump_max );
            return;
        }
        if ( ply_work.obj_work.spd.x > 0 )
        {
            ply_work.obj_work.spd.x = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.x, sSpd );
        }
        if ( ply_work.obj_work.spd_m > 0 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, spd_jump_dec );
        }
        ply_work.obj_work.spd.x = AppMain.ObjSpdUpSet( ply_work.obj_work.spd.x, -num, spd_jump_max );
    }

    // Token: 0x0600177D RID: 6013 RVA: 0x000CF0B4 File Offset: 0x000CD2B4
    private static void GmPlySeqMoveSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = ply_work.spd_dec_spin;
        if ( ply_work.no_spddown_timer != 0 )
        {
            ply_work.obj_work.spd_slope = 0;
            num = 0;
        }
        else
        {
            if ( ply_work.seq_state != 37 )
            {
                ply_work.obj_work.spd_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope_spin;
            }
            else
            {
                ply_work.obj_work.spd_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope_spin_spipe;
            }
            ply_work.obj_work.dir_slope = 640;
        }
        if ( ( ply_work.obj_work.spd_m > 0 && ( ply_work.key_on & 8 ) != 0 ) || ( ply_work.obj_work.spd_m < 0 && ( ply_work.key_on & 4 ) != 0 ) )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num >> 1 );
            return;
        }
        if ( ( ply_work.obj_work.spd_m <= 0 || ( ply_work.key_on & 8 ) == 0 ) && ( ply_work.obj_work.spd_m >= 0 || ( ply_work.key_on & 4 ) == 0 ) )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num << 1 );
            return;
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num );
    }

    // Token: 0x0600177E RID: 6014 RVA: 0x000CF1F8 File Offset: 0x000CD3F8
    private static void GmPlySeqMoveSpinNoDec( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int spd_dec_spin = ply_work.spd_dec_spin;
        if ( ply_work.no_spddown_timer != 0 )
        {
            ply_work.obj_work.spd_slope = 0;
            return;
        }
        if ( ply_work.seq_state != 37 )
        {
            ply_work.obj_work.spd_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope_spin;
        }
        else
        {
            ply_work.obj_work.spd_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope_spin_spipe;
        }
        ply_work.obj_work.dir_slope = 640;
    }

    // Token: 0x0600177F RID: 6015 RVA: 0x000CF280 File Offset: 0x000CD480
    private static void GmPlySeqMoveSpinPinball( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.spd_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope_spin_pinball;
        ply_work.obj_work.dir_slope = 256;
        int spd_add_spin_pinball = ply_work.spd_add_spin_pinball;
        int num = ply_work.spd_dec_spin_pinball;
        int num2 = ply_work.spd_max_spin_pinball;
        int num3 = AppMain.MTM_MATH_ABS(ply_work.key_walk_rot_z);
        if ( num3 > 24576 )
        {
            num3 = 24576;
        }
        num2 = num2 * num3 / 24576;
        if ( num2 < ply_work.prev_walk_roll_spd_max )
        {
            num2 = ply_work.prev_walk_roll_spd_max - num;
            if ( num2 < 0 )
            {
                num2 = 0;
            }
        }
        ply_work.prev_walk_roll_spd_max = num2;
        if ( ply_work.obj_work.dir.z != 0 )
        {
            int num4 = AppMain.FX_Mul(ply_work.spd_max_add_slope_spin_pinball, AppMain.mtMathSin((int)ply_work.obj_work.dir.z));
            if ( num4 > 0 )
            {
                num2 += num4;
            }
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num = 0;
        }
        if ( ply_work.spd_work_max >= num2 && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= num2 )
        {
            if ( ply_work.spd_work_max > ply_work.obj_work.spd_m )
            {
                ply_work.spd_work_max = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
            }
            num2 = ply_work.spd_work_max;
        }
        if ( !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            ply_work.spd_pool = 0;
            ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -num2, num2 );
            ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -num2, num2 );
            if ( ( ply_work.obj_work.dir.z + 8192 & 65280 ) <= 16384 )
            {
                if ( ( ply_work.player_flag & 134217728U ) != 0U )
                {
                    ply_work.player_flag &= 4160749567U;
                    return;
                }
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num );
            }
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num );
            }
            ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, spd_add_spin_pinball, num2 );
            return;
        }
        if ( ply_work.obj_work.spd_m > 0 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num );
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, -spd_add_spin_pinball, num2 );
    }

    // Token: 0x06001780 RID: 6016 RVA: 0x000CF504 File Offset: 0x000CD704
    private static void gmPlySeqTruckMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        ushort num4 = (ushort)(obj_work.dir.z + (obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir));
        obj_work.prev_pos.x = obj_work.pos.x;
        obj_work.prev_pos.y = obj_work.pos.y;
        obj_work.prev_pos.z = obj_work.pos.z;
        if ( ( obj_work.move_flag & 134217728U ) != 0U )
        {
            obj_work.flow.x = 0;
            obj_work.flow.y = 0;
            obj_work.flow.z = 0;
        }
        int x = obj_work.flow.x;
        int y = obj_work.flow.y;
        if ( ( x != 0 || y != 0 ) && obj_work.dir_fall != 0 )
        {
            AppMain.ObjObjectSpdDirFall( ref x, ref y, obj_work.dir_fall );
        }
        if ( obj_work.hitstop_timer != 0 )
        {
            obj_work.move.x = AppMain.FX_Mul( x, AppMain.g_obj.speed );
            obj_work.move.y = AppMain.FX_Mul( y, AppMain.g_obj.speed );
            obj_work.move.z = AppMain.FX_Mul( obj_work.flow.z, AppMain.g_obj.speed );
        }
        else
        {
            if ( ( obj_work.move_flag & 1U ) == 0U )
            {
                if ( ( obj_work.move_flag & 128U ) != 0U && ( obj_work.move_flag & 1U ) == 0U )
                {
                    obj_work.spd.y = obj_work.spd.y + AppMain.FX_Mul( obj_work.spd_fall, AppMain.g_obj.speed );
                }
                if ( ( obj_work.move_flag & 128U ) != 0U && obj_work.spd.y > obj_work.spd_fall_max )
                {
                    obj_work.spd.y = obj_work.spd_fall_max;
                }
            }
            if ( ( obj_work.move_flag & 64U ) != 0U )
            {
                if ( ( obj_work.move_flag & 131072U ) != 0U && ( obj_work.spd_m != 0 || ( obj_work.move_flag & 262144U ) == 0U ) && ( int )( num4 + obj_work.dir_slope & 65535 ) >= ( int )obj_work.dir_slope << 1 )
                {
                    int num5;
                    if ( AppMain.MTM_MATH_ABS( obj_work.spd_m ) < 16384 )
                    {
                        num5 = obj_work.spd_slope;
                    }
                    else
                    {
                        num5 = obj_work.spd_slope << 1;
                    }
                    if ( ( obj_work.spd_m > 0 && num4 > 32768 ) || ( obj_work.spd_m < 0 && num4 < 32768 ) )
                    {
                        num5 <<= 1;
                    }
                    int num6 = AppMain.FX_Mul(num5, AppMain.mtMathSin((int)num4));
                    if ( num6 > 0 || num4 < 32768 )
                    {
                        if ( num6 < 256 )
                        {
                            num6 = 256;
                        }
                    }
                    else if ( num6 > -256 )
                    {
                        num6 = -256;
                    }
                    obj_work.spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, num6, obj_work.spd_slope_max );
                }
                if ( ( obj_work.move_flag & 32768U ) == 0U )
                {
                    num = AppMain.FX_Mul( obj_work.spd_m, AppMain.mtMathCos( ( int )obj_work.dir.z ) );
                    num2 = AppMain.FX_Mul( obj_work.spd_m, AppMain.mtMathSin( ( int )obj_work.dir.z ) );
                }
            }
            if ( ( obj_work.move_flag & 67108864U ) != 0U )
            {
                obj_work.move.x = AppMain.FX_Mul( obj_work.spd.x + num + x, AppMain.g_obj.speed );
                obj_work.move.y = AppMain.FX_Mul( obj_work.spd.y + num2 + y, AppMain.g_obj.speed );
            }
            else
            {
                obj_work.move.x = AppMain.FX_Mul( obj_work.spd.x + num + x + AppMain.g_obj.scroll[0], AppMain.g_obj.speed );
                obj_work.move.y = AppMain.FX_Mul( obj_work.spd.y + num2 + y + AppMain.g_obj.scroll[1], AppMain.g_obj.speed );
            }
            obj_work.move.z = AppMain.FX_Mul( obj_work.spd.z + num3 + obj_work.flow.z, AppMain.g_obj.speed );
            if ( ( obj_work.move_flag & 1U ) != 0U )
            {
                AppMain.ObjObjectSpdDirFall( ref obj_work.move.x, ref obj_work.move.y, obj_work.dir_fall );
            }
            else
            {
                AppMain.ObjObjectSpdDirFall( ref obj_work.move.x, ref obj_work.move.y, gms_PLAYER_WORK.jump_pseudofall_dir );
            }
        }
        obj_work.pos.x = obj_work.pos.x + obj_work.move.x;
        obj_work.pos.y = obj_work.pos.y + obj_work.move.y;
        obj_work.pos.z = obj_work.pos.z + obj_work.move.z;
        obj_work.spd.x = obj_work.spd.x + obj_work.spd_add.x;
        obj_work.spd.y = obj_work.spd.y + obj_work.spd_add.y;
        obj_work.spd.z = obj_work.spd.z + obj_work.spd_add.z;
        obj_work.flow.x = 0;
        obj_work.flow.y = 0;
        obj_work.flow.z = 0;
    }

    // Token: 0x06001781 RID: 6017 RVA: 0x000CFA3C File Offset: 0x000CDC3C
    private static void gmPlySeqSplMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        ushort num4 = (ushort)(obj_work.dir.z + (obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir));
        obj_work.prev_pos.x = obj_work.pos.x;
        obj_work.prev_pos.y = obj_work.pos.y;
        obj_work.prev_pos.z = obj_work.pos.z;
        if ( ( obj_work.move_flag & 134217728U ) != 0U )
        {
            obj_work.flow.x = 0;
            obj_work.flow.y = 0;
            obj_work.flow.z = 0;
        }
        int x = obj_work.flow.x;
        int y = obj_work.flow.y;
        if ( ( x != 0 || y != 0 ) && obj_work.dir_fall != 0 )
        {
            AppMain.ObjObjectSpdDirFall( ref x, ref y, obj_work.dir_fall );
        }
        if ( obj_work.hitstop_timer != 0 )
        {
            obj_work.move.x = AppMain.FX_Mul( x, AppMain.g_obj.speed );
            obj_work.move.y = AppMain.FX_Mul( y, AppMain.g_obj.speed );
            obj_work.move.z = AppMain.FX_Mul( obj_work.flow.z, AppMain.g_obj.speed );
        }
        else
        {
            if ( ( obj_work.move_flag & 1U ) == 0U )
            {
                if ( ( obj_work.move_flag & 128U ) != 0U && ( obj_work.move_flag & 1U ) == 0U )
                {
                    obj_work.spd.y = obj_work.spd.y + AppMain.FX_Mul( obj_work.spd_fall, AppMain.g_obj.speed );
                }
                if ( ( obj_work.move_flag & 128U ) != 0U && obj_work.spd.y > obj_work.spd_fall_max )
                {
                    obj_work.spd.y = obj_work.spd_fall_max;
                }
            }
            if ( ( obj_work.move_flag & 64U ) != 0U )
            {
                if ( ( obj_work.move_flag & 131072U ) != 0U && ( obj_work.spd_m != 0 || ( obj_work.move_flag & 262144U ) == 0U ) )
                {
                    if ( ( int )( num4 + obj_work.dir_slope & 65535 ) >= ( int )obj_work.dir_slope << 1 && ( obj_work.move_flag & 1U ) != 0U )
                    {
                        if ( AppMain.MTM_MATH_ABS( obj_work.spd_m ) < 8192 )
                        {
                            obj_work.spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, AppMain.FX_Mul( obj_work.spd_slope >> 1, AppMain.mtMathSin( ( int )num4 ) ), obj_work.spd_slope_max );
                        }
                        else if ( AppMain.MTM_MATH_ABS( obj_work.spd_m ) < 16384 )
                        {
                            obj_work.spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, AppMain.FX_Mul( obj_work.spd_slope, AppMain.mtMathSin( ( int )num4 ) ), obj_work.spd_slope_max );
                        }
                        else
                        {
                            obj_work.spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, AppMain.FX_Mul( obj_work.spd_slope << 1, AppMain.mtMathSin( ( int )num4 ) ), obj_work.spd_slope_max );
                        }
                    }
                    else
                    {
                        obj_work.spd_m = 0;
                    }
                }
                if ( ( obj_work.move_flag & 32768U ) == 0U )
                {
                    num = AppMain.FX_Mul( obj_work.spd_m, AppMain.mtMathCos( ( int )obj_work.dir.z ) );
                    num2 = AppMain.FX_Mul( obj_work.spd_m, AppMain.mtMathSin( ( int )obj_work.dir.z ) );
                }
            }
            if ( ( obj_work.move_flag & 67108864U ) != 0U )
            {
                obj_work.move.x = AppMain.FX_Mul( obj_work.spd.x + num + x, AppMain.g_obj.speed );
                obj_work.move.y = AppMain.FX_Mul( obj_work.spd.y + num2 + y, AppMain.g_obj.speed );
            }
            else
            {
                obj_work.move.x = AppMain.FX_Mul( obj_work.spd.x + num + x + AppMain.g_obj.scroll[0], AppMain.g_obj.speed );
                obj_work.move.y = AppMain.FX_Mul( obj_work.spd.y + num2 + y + AppMain.g_obj.scroll[1], AppMain.g_obj.speed );
            }
            obj_work.move.z = AppMain.FX_Mul( obj_work.spd.z + num3 + obj_work.flow.z, AppMain.g_obj.speed );
            if ( ( obj_work.move_flag & 1U ) != 0U )
            {
                AppMain.ObjObjectSpdDirFall( ref obj_work.move.x, ref obj_work.move.y, obj_work.dir_fall );
            }
            else
            {
                AppMain.ObjObjectSpdDirFall( ref obj_work.move.x, ref obj_work.move.y, gms_PLAYER_WORK.jump_pseudofall_dir );
            }
        }
        obj_work.pos.x = obj_work.pos.x + obj_work.move.x;
        obj_work.pos.y = obj_work.pos.y + obj_work.move.y;
        obj_work.pos.z = obj_work.pos.z + obj_work.move.z;
        obj_work.spd.x = obj_work.spd.x + obj_work.spd_add.x;
        obj_work.spd.y = obj_work.spd.y + obj_work.spd_add.y;
        obj_work.spd.z = obj_work.spd.z + obj_work.spd_add.z;
        obj_work.flow.x = 0;
        obj_work.flow.y = 0;
        obj_work.flow.z = 0;
    }

    // Token: 0x06001782 RID: 6018 RVA: 0x000CFF84 File Offset: 0x000CE184
    private static void gmPlySeqSplJumpDirec( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.dir.z = AppMain.ObjRoopMove16( ply_work.obj_work.dir.z, ( ushort )( ply_work.jump_pseudofall_dir - ply_work.obj_work.dir_fall ), 512 );
        if ( ( ply_work.gmk_flag & 536875264U ) == 0U )
        {
            ply_work.obj_work.pos.z = ( int )( ( long )AppMain.ObjSpdDownSet( ply_work.obj_work.pos.z, 16384 ) & -4096 );
            ply_work.obj_work.spd.z = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.z, 512 );
            ply_work.obj_work.dir.x = AppMain.ObjRoopMove16( ply_work.obj_work.dir.x, 0, 1024 );
        }
    }

    // Token: 0x06001783 RID: 6019 RVA: 0x000D0068 File Offset: 0x000CE268
    private static void GmPlySeqJumpDirec( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.dir.z = AppMain.ObjRoopMove16( ply_work.obj_work.dir.z, 0, 512 );
        if ( ( ply_work.gmk_flag & 536875264U ) == 0U )
        {
            ply_work.obj_work.pos.z = ( int )( ( long )AppMain.ObjSpdDownSet( ply_work.obj_work.pos.z, 16384 ) & -4096 );
            ply_work.obj_work.spd.z = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.z, 512 );
            ply_work.obj_work.dir.x = AppMain.ObjRoopMove16( ply_work.obj_work.dir.x, 0, 1024 );
        }
    }

    // Token: 0x06001784 RID: 6020 RVA: 0x000D013C File Offset: 0x000CE33C
    private static void GmPlySeqTruckJumpDirec( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.dir.z = AppMain.ObjRoopMove16( ply_work.obj_work.dir.z, ( ushort )( ply_work.jump_pseudofall_dir - ply_work.obj_work.dir_fall ), 512 );
        if ( ( ply_work.gmk_flag & 536875264U ) == 0U )
        {
            ply_work.obj_work.pos.z = ( int )( ( long )AppMain.ObjSpdDownSet( ply_work.obj_work.pos.z, 16384 ) & -4096 );
            ply_work.obj_work.spd.z = AppMain.ObjSpdDownSet( ply_work.obj_work.spd.z, 512 );
            ply_work.obj_work.dir.x = AppMain.ObjRoopMove16( ply_work.obj_work.dir.x, 0, 1024 );
        }
    }

    // Token: 0x06001785 RID: 6021 RVA: 0x000D021F File Offset: 0x000CE41F
    private static bool GmPlySeqCheckAcceptHoming( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.seq_state_data_tbl[ply_work.seq_state].accept_attr & 16U ) != 0U && ( ply_work.player_flag & 128U ) == 0U;
    }

    // Token: 0x06001786 RID: 6022 RVA: 0x000D0249 File Offset: 0x000CE449
    private static void gmPlySeqCheckChangeSequence( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        if ( AppMain.GmPlayerIsTransformSuperSonic( ply_work ) && AppMain.GmPlayerKeyCheckTransformKeyPush( ply_work ) && 0 <= ply_work.seq_state && ply_work.seq_state <= 21 )
        {
            AppMain.GmPlySeqChangeTransformSuper( ply_work );
        }
        AppMain.gmPlySeqCheckChangeSequenceUserInput( ply_work );
    }

    // Token: 0x06001787 RID: 6023 RVA: 0x000D0284 File Offset: 0x000CE484
    private static bool gmPlySeqCheckChangeSequenceUserInput( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.GMS_PLY_SEQ_STATE_DATA[] seq_state_data_tbl = ply_work.seq_state_data_tbl;
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 4U ) != 0U )
        {
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                AppMain.gmPlySeqCheckEndTruckWalk( ply_work );
            }
            else
            {
                AppMain.gmPlySeqCheckEndWalk( ply_work );
            }
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 1U ) != 0U )
        {
            AppMain.gmPlySeqCheckTurn( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 2U ) != 0U )
        {
            AppMain.gmPlySeqCheckDirectTurn( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 8U ) != 0U )
        {
            AppMain.gmPlySeqCheckFall( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 32768U ) != 0U )
        {
            AppMain.gmPlySeqCheckStagger( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 16U ) != 0U )
        {
            AppMain.gmPlySeqCheckEndLookup( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 32U ) != 0U )
        {
            AppMain.gmPlySeqCheckEndSquat( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 128U ) != 0U )
        {
            AppMain.gmPlySeqCheckEndSpin( ply_work );
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].check_attr & 1024U ) != 0U )
        {
            AppMain.gmPlySeqCheckEndWallPush( ply_work );
        }
        if ( AppMain.GmPlySeqCheckAcceptHoming( ply_work ) )
        {
            if ( ply_work.cursol_enemy_obj == null )
            {
                AppMain.GmPlyEfctCreateHomingCursol( ply_work );
                ply_work.cursol_enemy_obj = ply_work.enemy_obj;
            }
            if ( AppMain.gmPlySeqCheckHoming( ply_work ) )
            {
                return true;
            }
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 4096U ) != 0U && AppMain.gmPlySeqCheckSquatSpin( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 256U ) != 0U && AppMain.gmPlySeqCheckSpin( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 512U ) != 0U && AppMain.gmPlySeqCheckSpinDashAcc( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 2048U ) != 0U && AppMain.gmPlySeqCheckPinballSpinDashAcc( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 8U ) != 0U && AppMain.gmPlySeqCheckJump( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 4U ) != 0U && AppMain.gmPlySeqCheckBrake( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 1024U ) != 0U && AppMain.gmPlySeqCheckWallPush( ply_work ) )
        {
            return true;
        }
        if ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 2U ) != 0U )
        {
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                if ( AppMain.gmPlySeqCheckTruckWalk( ply_work ) )
                {
                    return true;
                }
            }
            else if ( AppMain.gmPlySeqCheckWalk( ply_work ) )
            {
                return true;
            }
        }
        return ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 64U ) != 0U && AppMain.gmPlySeqCheckLookup( ply_work ) ) || ( ( seq_state_data_tbl[ply_work.seq_state].accept_attr & 128U ) != 0U && AppMain.gmPlySeqCheckSquat( ply_work ) );
    }

    // Token: 0x06001788 RID: 6024 RVA: 0x000D0508 File Offset: 0x000CE708
    private static bool gmPlySeqCheckEndWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m == 0 && ply_work.obj_work.spd.z == 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return true;
        }
        return false;
    }

    // Token: 0x06001789 RID: 6025 RVA: 0x000D0534 File Offset: 0x000CE734
    private static bool gmPlySeqCheckTurn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.seq_state == 2 )
        {
            if ( ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) || ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) )
            {
                return AppMain.GmPlySeqChangeSequence( ply_work, 2 );
            }
        }
        else if ( ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) ) && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 16384 )
        {
            return AppMain.GmPlySeqChangeSequence( ply_work, 2 );
        }
        return false;
    }

    // Token: 0x0600178A RID: 6026 RVA: 0x000D05D0 File Offset: 0x000CE7D0
    private static bool gmPlySeqCheckDirectTurn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) ) && ( ( ply_work.obj_work.move_flag & 16U ) != 0U || ( ( ply_work.obj_work.move_flag & 16U ) == 0U && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 16384 ) ) )
        {
            if ( ply_work.act_state == 40 || ply_work.act_state == 48 || ply_work.act_state == 41 || ply_work.act_state == 42 || ply_work.act_state == 43 )
            {
                AppMain.GmPlySeqSetFallTurn( ply_work );
            }
            else
            {
                AppMain.GmPlySeqSetProgramTurn( ply_work, 4096 );
            }
            return true;
        }
        return false;
    }

    // Token: 0x0600178B RID: 6027 RVA: 0x000D0690 File Offset: 0x000CE890
    private static bool gmPlySeqCheckFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            return AppMain.GmPlySeqChangeSequence( ply_work, 16 );
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            if ( ( ply_work.gmk_flag & 262144U ) != 0U )
            {
                if ( ( ply_work.gmk_flag & 1073741824U ) != 0U )
                {
                    if ( ply_work.fall_timer != 0 )
                    {
                        ply_work.fall_timer = AppMain.ObjTimeCountDown( ply_work.fall_timer );
                        return false;
                    }
                    ply_work.gmk_flag &= 3220963327U;
                    AppMain.GmPlayerSpdParameterSet( ply_work );
                    ply_work.jump_pseudofall_dir = AppMain.g_gm_main_system.pseudofall_dir;
                    ply_work.obj_work.pos.x = AppMain.FXM_FLOAT_TO_FX32( ply_work.truck_mtx_ply_mtn_pos.M03 );
                    ply_work.obj_work.pos.y = AppMain.FXM_FLOAT_TO_FX32( -ply_work.truck_mtx_ply_mtn_pos.M13 );
                    ply_work.obj_work.pos.z = AppMain.FXM_FLOAT_TO_FX32( ply_work.truck_mtx_ply_mtn_pos.M23 );
                    AppMain.GmPlySeqChangeDeath( ply_work );
                    ply_work.gmk_flag2 |= 64U;
                    return true;
                }
            }
            else
            {
                ushort num = (ushort)(ply_work.obj_work.dir.z + (ply_work.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir));
                if ( ( ( num + 16384 & 32768 ) != 0 || num == 49152 ) && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 8192 )
                {
                    if ( ply_work.fall_timer != 0 )
                    {
                        ply_work.fall_timer = AppMain.ObjTimeCountDown( ply_work.fall_timer );
                        return false;
                    }
                    AppMain.GmPlayerSpdParameterSet( ply_work );
                    return AppMain.GmPlySeqChangeSequence( ply_work, 16 );
                }
                else
                {
                    AppMain.GmPlayerSpdParameterSet( ply_work );
                }
            }
        }
        else if ( ply_work.fall_timer != 0 )
        {
            ply_work.fall_timer = AppMain.ObjTimeCountDown( ply_work.fall_timer );
        }
        else if ( ( ( ply_work.obj_work.dir.z + 16384 & 32768 ) != 0 || ply_work.obj_work.dir.z == 49152 ) && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 8192 )
        {
            AppMain.GmPlayerSpdParameterSet( ply_work );
            return AppMain.GmPlySeqChangeSequence( ply_work, 16 );
        }
        return false;
    }

    // Token: 0x0600178C RID: 6028 RVA: 0x000D08A4 File Offset: 0x000CEAA4
    private static bool gmPlySeqCheckStagger( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.dir.z & 32767 ) != 0 || ply_work.obj_work.ride_obj != null )
        {
            return false;
        }
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.pos_x = ply_work.obj_work.pos.x >> 12;
        obs_COL_CHK_DATA.pos_y = ( ply_work.obj_work.pos.y >> 12 ) + ( int )ply_work.obj_work.field_rect[3];
        obs_COL_CHK_DATA.flag = ( ushort )( ply_work.obj_work.flag & 1U );
        obs_COL_CHK_DATA.vec = 2;
        obs_COL_CHK_DATA.dir = null;
        obs_COL_CHK_DATA.attr = null;
        int num = AppMain.ObjDiffCollision(obs_COL_CHK_DATA);
        if ( num > 0 )
        {
            obs_COL_CHK_DATA.pos_x = ( ply_work.obj_work.pos.x >> 12 ) + ( int )ply_work.obj_work.field_rect[0] - 2;
            int num2 = AppMain.ObjDiffCollision(obs_COL_CHK_DATA);
            obs_COL_CHK_DATA.pos_x = ( ply_work.obj_work.pos.x >> 12 ) + ( int )ply_work.obj_work.field_rect[2] + 2;
            int num3 = AppMain.ObjDiffCollision(obs_COL_CHK_DATA);
            if ( num2 <= 0 && num3 >= 16 )
            {
                obs_COL_CHK_DATA.pos_x = ( ply_work.obj_work.pos.x >> 12 ) + ( int )ply_work.obj_work.field_rect[0] - -4;
                num2 = AppMain.ObjDiffCollision( obs_COL_CHK_DATA );
                if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
                {
                    AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
                    return AppMain.GmPlySeqChangeSequence( ply_work, 14 );
                }
                AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
                if ( num2 > 0 )
                {
                    return AppMain.GmPlySeqChangeSequence( ply_work, 15 );
                }
                return AppMain.GmPlySeqChangeSequence( ply_work, 13 );
            }
            else if ( num2 >= 16 && num3 <= 0 )
            {
                obs_COL_CHK_DATA.pos_x = ( ply_work.obj_work.pos.x >> 12 ) + ( int )ply_work.obj_work.field_rect[2] + -4;
                num3 = AppMain.ObjDiffCollision( obs_COL_CHK_DATA );
                if ( ( ply_work.obj_work.disp_flag & 1U ) == 0U )
                {
                    AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
                    return AppMain.GmPlySeqChangeSequence( ply_work, 14 );
                }
                AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
                if ( num3 > 0 )
                {
                    return AppMain.GmPlySeqChangeSequence( ply_work, 15 );
                }
                return AppMain.GmPlySeqChangeSequence( ply_work, 13 );
            }
        }
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return false;
    }

    // Token: 0x0600178D RID: 6029 RVA: 0x000D0AA4 File Offset: 0x000CECA4
    private static bool gmPlySeqCheckEndLookup( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            return AppMain.GmPlySeqChangeSequence( ply_work, 16 );
        }
        return ( ply_work.key_on & 1 ) == 0 && AppMain.GmPlySeqChangeSequence( ply_work, 5 );
    }

    // Token: 0x0600178E RID: 6030 RVA: 0x000D0AD1 File Offset: 0x000CECD1
    private static bool gmPlySeqCheckEndSquat( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            return AppMain.GmPlySeqChangeSequence( ply_work, 16 );
        }
        return ( ply_work.key_on & 2 ) == 0 && AppMain.GmPlySeqChangeSequence( ply_work, 8 );
    }

    // Token: 0x0600178F RID: 6031 RVA: 0x000D0B00 File Offset: 0x000CED00
    private static bool gmPlySeqCheckEndSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m < 2048 && ply_work.obj_work.spd_m > -2048 )
        {
            ply_work.obj_work.spd_m = 0;
            AppMain.GmPlayerSpdParameterSet( ply_work );
            if ( ( ply_work.player_flag & 131072U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 39 );
                ply_work.obj_work.disp_flag |= 4U;
            }
            return AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
        return false;
    }

    // Token: 0x06001790 RID: 6032 RVA: 0x000D0B78 File Offset: 0x000CED78
    private static bool gmPlySeqCheckEndWallPush( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ( ply_work.obj_work.move_flag & 4U ) == 0U || ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && !AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && !AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) ) && AppMain.GmPlySeqChangeSequence( ply_work, 0 );
    }

    // Token: 0x06001791 RID: 6033 RVA: 0x000D0BCC File Offset: 0x000CEDCC
    private static bool gmPlySeqCheckHoming( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( !AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) || ply_work.homing_timer != 0 || ( ply_work.player_flag & 128U ) != 0U || AppMain.GMM_MAIN_STAGE_IS_ENDING() )
        {
            return false;
        }
        if ( ply_work.enemy_obj != null )
        {
            return AppMain.GmPlySeqChangeSequence( ply_work, 19 );
        }
        return AppMain.GmPlySeqChangeSequence( ply_work, 21 );
    }

    // Token: 0x06001792 RID: 6034 RVA: 0x000D0C19 File Offset: 0x000CEE19
    private static bool gmPlySeqCheckSquatSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.key_on & 2 ) != 0 && ( ply_work.obj_work.spd_m > 2048 || ply_work.obj_work.spd_m < -2048 ) && AppMain.GmPlySeqChangeSequence( ply_work, 10 );
    }

    // Token: 0x06001793 RID: 6035 RVA: 0x000D0C53 File Offset: 0x000CEE53
    private static bool gmPlySeqCheckSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.obj_work.spd_m > 2048 || ply_work.obj_work.spd_m < -2048 ) && AppMain.GmPlySeqChangeSequence( ply_work, 10 );
    }

    // Token: 0x06001794 RID: 6036 RVA: 0x000D0C83 File Offset: 0x000CEE83
    private static bool gmPlySeqCheckSpinDashAcc( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) && AppMain.GmPlySeqChangeSequence( ply_work, 11 );
    }

    // Token: 0x06001795 RID: 6037 RVA: 0x000D0C97 File Offset: 0x000CEE97
    private static bool gmPlySeqCheckPinballSpinDashAcc( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.key_on & 2 ) != 0 && AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) && AppMain.GmPlySeqChangeSequence( ply_work, 11 );
    }

    // Token: 0x06001796 RID: 6038 RVA: 0x000D0CB5 File Offset: 0x000CEEB5
    private static bool gmPlySeqCheckJump( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) && ( ( ply_work.obj_work.move_flag & 1U ) != 0U || ( ply_work.gmk_obj != null && ( ply_work.gmk_flag & 16384U ) != 0U ) ) && AppMain.GmPlySeqChangeSequence( ply_work, 17 );
    }

    // Token: 0x06001797 RID: 6039 RVA: 0x000D0CF0 File Offset: 0x000CEEF0
    private static bool gmPlySeqCheckBrake( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ply_work.seq_state != 9 && ( ( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) && ply_work.obj_work.spd_m >= 16384 ) || ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && ply_work.obj_work.spd_m <= -16384 ) ) && AppMain.GmPlySeqChangeSequence( ply_work, 9 );
    }

    // Token: 0x06001798 RID: 6040 RVA: 0x000D0D48 File Offset: 0x000CEF48
    private static bool gmPlySeqCheckWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( !AppMain.GmObjCheckMapLeftLimit( ply_work.obj_work, 14 ) || !AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) && ( !AppMain.GmObjCheckMapRightLimit( ply_work.obj_work, 14 ) || !AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) && ( 13 > ply_work.seq_state || ply_work.seq_state > 15 || ( ply_work.obj_work.move_flag & 4U ) == 0U || ( ( ( ply_work.obj_work.disp_flag & 1U ) == 0U || !AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) && ( ( ply_work.obj_work.disp_flag & 1U ) != 0U || !AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) ) ) && ( ply_work.obj_work.spd_m != 0 || AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) || AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) && AppMain.GmPlySeqChangeSequence( ply_work, 1 );
    }

    // Token: 0x06001799 RID: 6041 RVA: 0x000D0DFE File Offset: 0x000CEFFE
    private static bool gmPlySeqCheckLookup( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ply_work.obj_work.spd_m == 0 && ( ply_work.obj_work.move_flag & 1U ) != 0U && ( ply_work.key_on & 1 ) != 0 && AppMain.GmPlySeqChangeSequence( ply_work, 3 );
    }

    // Token: 0x0600179A RID: 6042 RVA: 0x000D0E31 File Offset: 0x000CF031
    private static bool gmPlySeqCheckSquat( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.key_on & 2 ) != 0 && AppMain.GmPlySeqChangeSequence( ply_work, 7 );
    }

    // Token: 0x0600179B RID: 6043 RVA: 0x000D0E48 File Offset: 0x000CF048
    private static bool gmPlySeqCheckWallPush( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.obj_work.move_flag & 4U ) != 0U && ( ply_work.player_flag & 32768U ) == 0U && ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) ) && ply_work.obj_work.pos.x >> 12 > AppMain.g_gm_main_system.map_fcol.left + 14 && ply_work.obj_work.pos.x >> 12 < AppMain.g_gm_main_system.map_fcol.right - 14 && AppMain.GmPlySeqChangeSequence( ply_work, 18 );
    }

    // Token: 0x0600179C RID: 6044 RVA: 0x000D0F00 File Offset: 0x000CF100
    private static bool gmPlySeqCheckTruckWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( AppMain.GmObjCheckMapLeftLimit( ply_work.obj_work, 14 ) && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) || ( AppMain.GmObjCheckMapRightLimit( ply_work.obj_work, 14 ) && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            return false;
        }
        if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= 64 || AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) || AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            return AppMain.GmPlySeqChangeSequence( ply_work, 1 );
        }
        ply_work.obj_work.spd_m = 0;
        return false;
    }

    // Token: 0x0600179D RID: 6045 RVA: 0x000D0F76 File Offset: 0x000CF176
    private static bool gmPlySeqCheckEndTruckWalk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 64 && ply_work.obj_work.spd.z == 0 )
        {
            ply_work.obj_work.spd_m = 0;
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return true;
        }
        return false;
    }

    // Token: 0x0600179E RID: 6046 RVA: 0x000D0FB8 File Offset: 0x000CF1B8
    private static void gmPlySeqSplStgRollCtrl( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        if ( ( AppMain.g_gm_main_system.game_flag & 17240600U ) != 0U )
        {
            return;
        }
        int num = ply_work.key_rot_z;
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 512U ) != 0U )
        {
            num = num * 26 / 10;
            obs_CAMERA.roll += num;
        }
        else
        {
            int num2 = 66;
            ply_work.accel_counter--;
            if ( ply_work.accel_counter <= 0 )
            {
                ply_work.accel_counter = 0;
                int num3 = num - ply_work.prev_key_rot_z;
                num3 = num3 * 3 / 4;
                if ( AppMain.MTM_MATH_ABS( num3 ) >= 16384 )
                {
                    if ( ( num3 >= 0 || num <= 0 ) && ( num3 <= 0 || num >= 0 ) )
                    {
                        num3 /= 64;
                        ply_work.dir_vec_add = num3;
                        ply_work.accel_counter = 8;
                    }
                }
            }
            num /= num2;
            num += ply_work.dir_vec_add * ply_work.accel_counter;
            obs_CAMERA.roll += num;
        }
        if ( ply_work.nudge_di_timer != 0 )
        {
            ply_work.nudge_di_timer -= 1;
            return;
        }
        bool flag = false;
        if ( ( ply_work.key_push & 160 ) != 0 )
        {
            flag = true;
        }
        if ( flag )
        {
            AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = AppMain.GmSplStageGetWork();
            ply_work.nudge_di_timer = 30;
            ply_work.nudge_timer = 30;
            gms_SPL_STG_WORK.flag &= 4294967293U;
        }
    }

    // Token: 0x06000851 RID: 2129 RVA: 0x00048CEC File Offset: 0x00046EEC
    private static void GmPlySeqInitSpringJump( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, bool spd_clear, int no_jump_move_time, int fall_dir, bool t_cam_slow )
    {
        bool set_act = true;
        AppMain.GmPlySeqChangeSequenceState( ply_work, 29 );
        if ( spd_clear )
        {
            ply_work.obj_work.spd.x = ( ply_work.obj_work.spd.y = 0 );
            ply_work.obj_work.spd_add.x = ( ply_work.obj_work.spd_add.y = 0 );
            ply_work.obj_work.spd_m = 0;
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            if ( fall_dir != -1 )
            {
                ply_work.jump_pseudofall_dir = ( ushort )fall_dir;
                int num = fall_dir - ply_work.ply_pseudofall_dir;
                if ( ( ushort )AppMain.MTM_MATH_ABS( num ) > 32768 )
                {
                    if ( num < 0 )
                    {
                        ply_work.ply_pseudofall_dir += 65536 + num;
                    }
                    else
                    {
                        ply_work.ply_pseudofall_dir += num - 65536;
                    }
                }
                else
                {
                    ply_work.ply_pseudofall_dir = fall_dir;
                }
                AppMain.g_gm_main_system.pseudofall_dir = ( ushort )ply_work.ply_pseudofall_dir;
            }
            AppMain.GmPlayerSetAtk( ply_work );
            set_act = false;
            AppMain.GmPlayerActionChange( ply_work, 40 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spd_x, spd_y, set_act );
        if ( ( ply_work.player_flag & 262144U ) != 0U && fall_dir != -1 )
        {
            ply_work.gmk_flag2 |= 256U;
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.disp_flag &= 4294967294U;
            if ( t_cam_slow )
            {
                ply_work.gmk_flag2 |= 32U;
            }
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U && fall_dir != -1 )
        {
            ply_work.gmk_flag |= 16777216U;
        }
        if ( no_jump_move_time > 0 )
        {
            AppMain.GmPlySeqSetNoJumpMoveTime( ply_work, no_jump_move_time );
        }
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            AppMain.GmSoundPlaySE( "Lorry5" );
        }
        else
        {
            AppMain.GmSoundPlaySE( "Spring" );
        }
        AppMain.GMM_PAD_VIB_SMALL();
    }

    // Token: 0x06000852 RID: 2130 RVA: 0x00048EBC File Offset: 0x000470BC
    private static void GmPlySeqInitRockRideStart( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK com_work )
    {
        if ( ply_work.gmk_obj == ( AppMain.OBS_OBJECT_WORK )com_work )
        {
            return;
        }
        AppMain.GmPlySeqChangeSequenceState( ply_work, 30 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.gmk_obj = com_work.obj_work;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRidePush );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.OBS_OBJECT_WORK gmk_obj = ply_work.gmk_obj;
        AppMain.GmPlayerActionChange( ply_work, 17 );
        obj_work.spd_m = 0;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        obj_work.spd.z = 0;
        obj_work.spd_add.x = 0;
        obj_work.spd_add.y = 0;
        obj_work.spd_add.z = 0;
        if ( obj_work.pos.x < gmk_obj.pos.x )
        {
            obj_work.disp_flag &= 4294967294U;
            return;
        }
        obj_work.disp_flag |= 1U;
    }

    // Token: 0x06000853 RID: 2131 RVA: 0x00048FA0 File Offset: 0x000471A0
    private static void GmPlySeqInitRockRide( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK com_work )
    {
        AppMain.OBS_OBJECT_WORK gmk_obj = ply_work.gmk_obj;
        if ( gmk_obj == ( AppMain.OBS_OBJECT_WORK )com_work )
        {
            return;
        }
        AppMain.GmPlySeqChangeSequenceState( ply_work, 31 );
        AppMain.GmPlySeqGmkInitGimmickDependInit( ply_work, com_work.obj_work, 0, 0, 0 );
        ply_work.gmk_obj = com_work.obj_work;
        com_work.target_dp_dist = 229376;
        ply_work.player_flag |= 12U;
        ply_work.obj_work.move_flag |= 256U;
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        gmk_obj = ply_work.gmk_obj;
        if ( obj_work.pos.y > gmk_obj.pos.y )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRideStop );
        }
        else
        {
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRide );
            AppMain.GmPlayerCameraOffsetSet( ply_work, 0, -48 );
            AppMain.GmCameraAllowSet( 10f, 30f, 0f );
        }
        AppMain.GmPlayerActionChange( ply_work, 60 );
        obj_work.disp_flag |= 4U;
        ply_work.gmk_flag |= 16384U;
        int v = AppMain.FX_Div(gmk_obj.pos.x - obj_work.pos.x, 229376);
        obj_work.spd_m = AppMain.FX_Mul( v, 15360 ) + gmk_obj.spd_m;
        if ( gmk_obj.spd_m > 0 )
        {
            obj_work.disp_flag &= 4294967294U;
            return;
        }
        obj_work.disp_flag |= 1U;
    }

    // Token: 0x06000854 RID: 2132 RVA: 0x00049110 File Offset: 0x00047310
    private static void GmPlySeqInitPulley( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK com_work )
    {
        if ( ply_work.gmk_obj == ( AppMain.OBS_OBJECT_WORK )com_work )
        {
            return;
        }
        AppMain.GmPlySeqChangeSequenceState( ply_work, 32 );
        com_work.obj_work.spd.x = ply_work.obj_work.spd.x;
        if ( ( ply_work.obj_work.move_flag & 16U ) == 0U )
        {
            com_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )ply_work.obj_work.dir.z ) );
        }
        com_work.obj_work.move_flag &= 4294967231U;
        AppMain.GmPlySeqGmkInitGimmickDependInit( ply_work, com_work.obj_work, 0, 163840, 0 );
        com_work.target_dp_pos.x = 0;
        com_work.target_dp_pos.y = 163840;
        com_work.target_dp_pos.z = 0;
        ply_work.player_flag |= 12U;
        com_work.target_dp_dist = -163840;
        ply_work.obj_work.move_flag |= 256U;
        ply_work.obj_work.move_flag &= 4294967278U;
        ply_work.gmk_flag |= 16384U;
        AppMain.GmPlayerActionChange( ply_work, 66 );
        ply_work.obj_work.pos.Assign( com_work.obj_work.pos );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.pos.y = obj_work.pos.y + 163840;
    }

    // Token: 0x06000855 RID: 2133 RVA: 0x00049280 File Offset: 0x00047480
    private static void GmPlySeqInitBreathing( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 33 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickBreathing );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.spd_m = 0;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        obj_work.spd_add.x = 0;
        obj_work.spd_add.y = 0;
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 62 );
        }
        else
        {
            AppMain.GmPlayerActionChange( ply_work, 68 );
        }
        AppMain.GmSoundPlaySE( "Breathe" );
    }

    // Token: 0x06000856 RID: 2134 RVA: 0x00049314 File Offset: 0x00047514
    private static void GmPlySeqInitDashPanel( AppMain.GMS_PLAYER_WORK ply_work, uint type )
    {
        int[][] array = new int[4][];
        int[][] array2 = array;
        int num = 0;
        int[] array3 = new int[2];
        array3[0] = 55296;
        array2[num] = array3;
        int[][] array4 = array;
        int num2 = 1;
        int[] array5 = new int[2];
        array5[0] = -55296;
        array4[num2] = array5;
        array[2] = new int[]
        {
            default(int),
            -55296
        };
        array[3] = new int[]
        {
            default(int),
            -55296
        };
        int[][] array6 = array;
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 34 );
        if ( ( ply_work.player_flag & 262144U ) == 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 27 );
        }
        else if ( type == 1U || type == 3U )
        {
            ply_work.gmk_flag |= 1048576U;
            AppMain.GmPlayerActionChange( ply_work, 72 );
        }
        else
        {
            ply_work.gmk_flag &= 1048576U;
            AppMain.GmPlayerActionChange( ply_work, 71 );
        }
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.obj_work.user_timer = 60;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainDashPanel );
        if ( ( ply_work.player_flag & 262144U ) == 0U )
        {
            AppMain.GmPlySeqGmkSpdSet( ply_work, array6[( int )( ( UIntPtr )type )][0], array6[( int )( ( UIntPtr )type )][1] );
        }
        else
        {
            AppMain.GmPlySeqGmkTruckSpdSet( ply_work, array6[( int )( ( UIntPtr )type )][0], array6[( int )( ( UIntPtr )type )][1] );
        }
        ply_work.no_spddown_timer = 49152;
        ply_work.spd_work_max = ply_work.obj_work.spd_m;
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmSoundPlaySE( "Spin" );
        if ( ( ply_work.player_flag & 262144U ) == 0U )
        {
            AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 1U );
            AppMain.GmPlyEfctCreateSpinDashCircleBlur( ply_work );
            AppMain.GmPlyEfctCreateTrail( ply_work, 1 );
        }
        AppMain.GMM_PAD_VIB_SMALL();
    }

    // Token: 0x06000857 RID: 2135 RVA: 0x000494B0 File Offset: 0x000476B0
    private static void GmPlySeqInitTarzanRope( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK com_work )
    {
        if ( ply_work.gmk_obj == ( AppMain.OBS_OBJECT_WORK )com_work )
        {
            return;
        }
        AppMain.GmPlySeqChangeSequenceState( ply_work, 35 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.gmk_obj = com_work.obj_work;
        ply_work.seq_func = null;
        ply_work.obj_work.move_flag &= 4294967102U;
        AppMain.GmPlayerActionChange( ply_work, 63 );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.disp_flag |= 4U;
        ply_work.gmk_flag |= 16384U;
    }

    // Token: 0x06000858 RID: 2136 RVA: 0x00049534 File Offset: 0x00047734
    private static void GmPlySeqInitWaterSlider( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK com_work )
    {
        if ( ply_work.gmk_obj == ( AppMain.OBS_OBJECT_WORK )com_work )
        {
            return;
        }
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 36 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.gmk_obj = com_work.obj_work;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainWaterSlider );
        ply_work.obj_work.move_flag &= 4294967279U;
        AppMain.GmPlayerActionChange( ply_work, 65 );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.disp_flag |= 4U;
        AppMain.GmGmkWaterSliderCreateEffect();
    }

    // Token: 0x06000859 RID: 2137 RVA: 0x000495BC File Offset: 0x000477BC
    private static void GmPlySeqInitSpipe( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 37 );
        if ( ply_work.act_state != 26 && ply_work.act_state != 27 )
        {
            AppMain.GmSoundPlaySE( "Spin" );
        }
        if ( ply_work.act_state != 27 )
        {
            AppMain.GmPlayerActionChange( ply_work, 27 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainSpipe );
        AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 1U );
        AppMain.GmPlyEfctCreateSpinDashCircleBlur( ply_work );
    }

    // Token: 0x0600085A RID: 2138 RVA: 0x00049649 File Offset: 0x00047849
    private static ushort GmPlySeqScrewCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.seq_func == new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkScrewMain ) )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x0600085B RID: 2139 RVA: 0x00049668 File Offset: 0x00047868
    private static void GmPlySeqInitScrew( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK gmk_work, int pos_x, int pos_y, ushort flag )
    {
        if ( AppMain.GmPlySeqScrewCheck( ply_work ) != 0 )
        {
            return;
        }
        AppMain.GmPlySeqChangeSequenceState( ply_work, 38 );
        AppMain.GmPlayerWalkActionSet( ply_work );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 8208U;
        ply_work.gmk_flag |= 147456U;
        ply_work.gmk_obj = gmk_work.obj_work;
        ply_work.gmk_work0 = pos_x;
        ply_work.gmk_work1 = pos_y;
        ply_work.obj_work.user_work = ( uint )flag;
        ply_work.obj_work.user_timer = 0;
        if ( ( ply_work.obj_work.user_work & ( uint )AppMain.GMD_GMK_SCREW_EVE_FLAG_LEFT ) != 0U )
        {
            if ( ply_work.gmk_work0 > ply_work.obj_work.pos.x )
            {
                ply_work.obj_work.user_timer = ply_work.gmk_work0 - ply_work.obj_work.pos.x;
            }
        }
        else if ( ply_work.gmk_work0 < ply_work.obj_work.pos.x )
        {
            ply_work.obj_work.user_timer = ply_work.obj_work.pos.x - ply_work.gmk_work0;
        }
        ply_work.gmk_work1 -= ( int )ply_work.obj_work.field_rect[3] << 12;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkScrewMain );
        ply_work.timer = 16;
    }

    // Token: 0x0600085C RID: 2140 RVA: 0x000497BC File Offset: 0x000479BC
    private static void GmPlySeqInitDemoFw( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 39 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.seq_func = null;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 69 );
            ply_work.obj_work.disp_flag |= 4U;
            return;
        }
        AppMain.GmPlayerActionChange( ply_work, 0 );
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.disp_flag |= 4U;
    }

    // Token: 0x0600085D RID: 2141 RVA: 0x00049824 File Offset: 0x00047A24
    private static void GmPlySeqInitCannon( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK gmk_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 41 );
        AppMain.GmPlayerActionChange( ply_work, 26 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.obj_work.move_flag |= 512U;
        ply_work.obj_work.pos.x = gmk_work.obj_work.pos.x;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.x = 0;
        if ( ply_work.obj_work.spd_add.y <= 0 )
        {
            ply_work.obj_work.spd_add.y = 672;
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkCannonWait );
        ply_work.gmk_obj = gmk_work.obj_work;
        ply_work.gmk_flag2 |= 134U;
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.invincible_timer = 0;
    }

    // Token: 0x0600085E RID: 2142 RVA: 0x00049932 File Offset: 0x00047B32
    private static void GmPlySeqInitCannonShoot( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 42 );
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spd_x, spd_y );
        AppMain.GmPlayerActionChange( ply_work, 67 );
        ply_work.obj_work.disp_flag |= 4U;
        AppMain.GmPlayerSetDefNormal( ply_work );
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
    }

    // Token: 0x0600085F RID: 2143 RVA: 0x00049974 File Offset: 0x00047B74
    private static void GmPlySeqInitStopper( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK gmk_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 40 );
        if ( ply_work.act_state != 26 )
        {
            AppMain.GmPlayerActionChange( ply_work, 26 );
        }
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 16U;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.move_flag &= 4294967167U;
        ply_work.obj_work.flag |= 2U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkStopperMove );
        ply_work.gmk_obj = gmk_work.obj_work;
    }

    // Token: 0x06000860 RID: 2144 RVA: 0x00049A38 File Offset: 0x00047C38
    private static void GmPlySeqInitStopperEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.move_flag |= 144U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkStopperEnd );
    }

    // Token: 0x06000861 RID: 2145 RVA: 0x00049A63 File Offset: 0x00047C63
    private static void GmPlySeqGmkInitUpBumper( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 43 );
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spd_x, spd_y );
        AppMain.GmSoundPlaySE( "Spring" );
    }

    // Token: 0x06000862 RID: 2146 RVA: 0x00049A80 File Offset: 0x00047C80
    private static void GmPlySeqGmkInitSeesaw( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK gmk_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 44 );
        if ( ply_work.act_state != 27 )
        {
            AppMain.GmPlayerActionChange( ply_work, 27 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.obj_work.move_flag &= 4294967167U;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.dir.z = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkSeesaw );
        ply_work.gmk_obj = gmk_work.obj_work;
        AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 1U );
        AppMain.GmPlyEfctCreateSpinDashCircleBlur( ply_work );
    }

    // Token: 0x06000863 RID: 2147 RVA: 0x00049B54 File Offset: 0x00047D54
    private static void GmPlySeqGmkInitSeesawEnd( AppMain.GMS_PLAYER_WORK ply_work, int spdx, int spdy )
    {
        AppMain.GmPlySeqChangeSequence( ply_work, 16 );
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spdx, spdy, false );
        ply_work.no_spddown_timer = 0;
        ply_work.gmk_obj = null;
        AppMain.GmPlayerActionChange( ply_work, 26 );
        ply_work.obj_work.disp_flag |= 4U;
        AppMain.GmPlayerSetAtk( ply_work );
    }

    // Token: 0x06000864 RID: 2148 RVA: 0x00049BA4 File Offset: 0x00047DA4
    private static void GmPlySeqGmkInitSpinFall( AppMain.GMS_PLAYER_WORK ply_work, int spdx, int spdy )
    {
        ply_work.gmk_obj = null;
        AppMain.GmPlySeqChangeSequenceState( ply_work, 66 );
        AppMain.GmPlySeqInitFallState( ply_work );
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spdx, spdy, false );
        ply_work.no_spddown_timer = 0;
        if ( ply_work.act_state != 26 )
        {
            AppMain.GmPlayerActionChange( ply_work, 26 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
    }

    // Token: 0x06000865 RID: 2149 RVA: 0x00049C08 File Offset: 0x00047E08
    private static void GmPlySeqInitPinball( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, int no_spddown_timer )
    {
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 45 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        if ( ply_work.act_state != 39 )
        {
            AppMain.GmPlayerActionChange( ply_work, 39 );
            ply_work.obj_work.disp_flag |= 4U;
            AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        AppMain.GmPlySeqGmkSpdSet( ply_work, spd_x, spd_y );
        ply_work.obj_work.spd_add.x = 0;
        ply_work.obj_work.spd_add.y = 0;
        ply_work.obj_work.spd_add.z = 0;
        ply_work.obj_work.user_timer = 60;
        ply_work.no_spddown_timer = no_spddown_timer * 4096;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainPinball );
        AppMain.GmPlayerSetAtk( ply_work );
        AppMain.GmSoundPlaySE( "Spin" );
    }

    // Token: 0x06000866 RID: 2150 RVA: 0x00049CE1 File Offset: 0x00047EE1
    private static void GmPlySeqInitPinballAir( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqInitPinballAir( ply_work, spd_x, spd_y, 5, false, 0 );
    }

    // Token: 0x06000867 RID: 2151 RVA: 0x00049CEE File Offset: 0x00047EEE
    private static void GmPlySeqInitPinballAir( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, int no_move_time )
    {
        AppMain.GmPlySeqInitPinballAir( ply_work, spd_x, spd_y, no_move_time, false, 0 );
    }

    // Token: 0x06000868 RID: 2152 RVA: 0x00049CFB File Offset: 0x00047EFB
    private static void GmPlySeqInitPinballAir( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, int no_move_time, bool flag_no_recover_homing )
    {
        AppMain.GmPlySeqInitPinballAir( ply_work, spd_x, spd_y, no_move_time, flag_no_recover_homing ? 1 : 0, 0 );
    }

    // Token: 0x06000869 RID: 2153 RVA: 0x00049D0F File Offset: 0x00047F0F
    private static void GmPlySeqInitPinballAir( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, int no_move_time, bool flag_no_recover_homing, int no_spddown_timer )
    {
        AppMain.GmPlySeqInitPinballAir( ply_work, spd_x, spd_y, no_move_time, flag_no_recover_homing ? 1 : 0, no_spddown_timer );
    }

    // Token: 0x0600086A RID: 2154 RVA: 0x00049D24 File Offset: 0x00047F24
    private static void GmPlySeqInitPinballAir( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, int no_move_time, int flag_no_recover_homing, int no_spddown_timer )
    {
        uint num = 0U;
        if ( ( ply_work.rect_work[1].flag & 4U ) != 0U )
        {
            num = 1U;
        }
        uint num2 = 0U;
        if ( ( ply_work.player_flag & 128U ) != 0U )
        {
            num2 = 1U;
        }
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 46 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        if ( ( ( long )flag_no_recover_homing & ( long )( ( ulong )num2 ) ) != 0L )
        {
            ply_work.player_flag |= 128U;
        }
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.obj_work.move_flag |= 128U;
        ply_work.obj_work.flag &= 4294967293U;
        ply_work.player_flag |= 32U;
        ply_work.obj_work.spd_fall = AppMain.FX_Mul( ply_work.obj_work.spd_fall, AppMain.FX_F32_TO_FX32( 1.1f ) );
        ply_work.obj_work.dir.y = 0;
        AppMain.GmPlySeqGmkSpdSet( ply_work, spd_x, spd_y );
        ply_work.obj_work.spd_add.x = 0;
        ply_work.obj_work.spd_add.y = 0;
        ply_work.obj_work.spd_add.z = 0;
        ply_work.obj_work.spd_m = 0;
        bool flag = false;
        if ( ( ply_work.obj_work.disp_flag & 4U ) != 0U )
        {
            flag = true;
        }
        int num3 = ply_work.act_state;
        int num4 = num3;
        switch ( num4 )
        {
            case 0:
            case 1:
                break;
            default:
                switch ( num4 )
                {
                    case 8:
                    case 9:
                    case 10:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                        goto IL_1E2;
                    default:
                        switch ( num4 )
                        {
                            case 41:
                                num3 = 40;
                                flag = true;
                                goto IL_1E2;
                            case 42:
                                goto IL_1E2;
                            case 43:
                                num3 = 42;
                                flag = true;
                                goto IL_1E2;
                            default:
                                goto IL_1E2;
                        }
                        break;
                }
                break;
        }
        num3 = 40;
        flag = true;
        IL_1E2:
        AppMain.GmPlayerActionChange( ply_work, num3 );
        if ( flag )
        {
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.no_spddown_timer = no_spddown_timer * 4096;
        ply_work.obj_work.user_timer = no_move_time;
        ply_work.obj_work.user_flag = 1U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainPinballAir );
        if ( num != 0U )
        {
            AppMain.GmPlayerSetAtk( ply_work );
        }
        if ( ( ply_work.gmk_flag & 4096U ) != 0U )
        {
            ply_work.obj_work.spd.z = ply_work.obj_work.spd.y;
            ply_work.obj_work.spd.y = 0;
            if ( ply_work.obj_work.pos.z < 0 )
            {
                ply_work.obj_work.spd.z = -ply_work.obj_work.spd.z;
            }
        }
    }

    // Token: 0x0600086B RID: 2155 RVA: 0x00049FE4 File Offset: 0x000481E4
    private static void GmPlySeqInitFlipper( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, AppMain.GMS_ENEMY_COM_WORK com_work )
    {
        if ( ply_work.gmk_obj == ( AppMain.OBS_OBJECT_WORK )com_work )
        {
            return;
        }
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 47 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.gmk_obj = com_work.obj_work;
        if ( ply_work.act_state != 39 )
        {
            AppMain.GmPlayerActionChange( ply_work, 39 );
            ply_work.obj_work.disp_flag |= 4U;
            AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
        }
        ply_work.obj_work.spd.x = spd_x;
        ply_work.obj_work.spd.y = spd_y;
        ply_work.obj_work.spd.z = 0;
        ply_work.obj_work.spd_add.x = 0;
        ply_work.obj_work.spd_add.y = 0;
        ply_work.obj_work.spd_add.z = 0;
        ply_work.obj_work.move_flag &= 4294967166U;
        ply_work.obj_work.move_flag |= 33040U;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.dir.z = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainFlipper );
        AppMain.GmSoundPlaySE( "Spin" );
        if ( ply_work.obj_work.spd.x > 0 )
        {
            ply_work.obj_work.disp_flag &= 4294967294U;
            return;
        }
        if ( ply_work.obj_work.spd.x < 0 )
        {
            ply_work.obj_work.disp_flag |= 1U;
        }
    }

    // Token: 0x0600086C RID: 2156 RVA: 0x0004A168 File Offset: 0x00048368
    private static void GmPlySeqGmkInitForceSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 51 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        if ( ply_work.act_state != 26 && ply_work.act_state != 27 )
        {
            AppMain.GmSoundPlaySE( "Spin" );
        }
        if ( ply_work.act_state != 26 )
        {
            AppMain.GmPlayerActionChange( ply_work, 26 );
            ply_work.obj_work.disp_flag |= 4U;
            AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 0U );
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainForceSpin );
        ply_work.obj_work.user_timer = ply_work.obj_work.spd_m;
        ply_work.obj_work.user_flag = 0U;
        AppMain.GmPlayerSetAtk( ply_work );
        ply_work.obj_work.move_flag |= 193U;
        ply_work.gmk_obj = null;
    }

    // Token: 0x0600086D RID: 2157 RVA: 0x0004A230 File Offset: 0x00048430
    private static void GmPlySeqGmkInitForceSpinDec( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 52 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        if ( ply_work.act_state != 26 && ply_work.act_state != 27 )
        {
            AppMain.GmSoundPlaySE( "Spin" );
        }
        if ( ply_work.act_state != 26 )
        {
            AppMain.GmPlayerActionChange( ply_work, 26 );
            ply_work.obj_work.disp_flag |= 4U;
            AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 0U );
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainForceSpinDec );
        ply_work.obj_work.user_timer = ply_work.obj_work.spd_m;
        ply_work.obj_work.user_flag = 1U;
        AppMain.GmPlayerSetAtk( ply_work );
        ply_work.obj_work.move_flag |= 193U;
        ply_work.gmk_obj = null;
    }

    // Token: 0x0600086E RID: 2158 RVA: 0x0004A2F8 File Offset: 0x000484F8
    private static void GmPlySeqGmkInitForceSpinFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 53 );
        ply_work.obj_work.move_flag |= 32912U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainForceSpinFall );
        ply_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )ply_work.obj_work.dir.z ) );
        ply_work.obj_work.spd.y = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathSin( ( int )ply_work.obj_work.dir.z ) );
        if ( ( ply_work.obj_work.user_flag & 1U ) != 0U && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) > AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) )
        {
            ply_work.obj_work.spd.y = ply_work.obj_work.spd.x >> 1;
            if ( ply_work.obj_work.spd.y < 0 )
            {
                ply_work.obj_work.spd.y = -ply_work.obj_work.spd.y;
            }
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.spd.x = obj_work.spd.x >> 1;
        }
    }

    // Token: 0x0600086F RID: 2159 RVA: 0x0004A460 File Offset: 0x00048660
    private static void GmPlySeqInitPinballCtpltHold( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_ENEMY_COM_WORK gmk_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 48 );
        if ( ply_work.prev_seq_state != 51 && ply_work.prev_seq_state != 52 )
        {
            AppMain.GmPlayerActionChange( ply_work, 26 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag &= 4294967279U;
        ply_work.obj_work.move_flag &= 4294967167U;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.dir.z = 0;
        AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 0U );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainPinballCtpltHold );
        ply_work.gmk_obj = gmk_work.obj_work;
    }

    // Token: 0x06000870 RID: 2160 RVA: 0x0004A534 File Offset: 0x00048734
    private static void GmPlySeqInitPinballCtplt( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, ( spd_x == 0 ) ? 49 : 50 );
        AppMain.GmPlayerActionChange( ply_work, 26 );
        ply_work.obj_work.disp_flag |= 4U;
        if ( spd_x != 0 )
        {
            ply_work.obj_work.move_flag &= 4294967279U;
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainPinballCtplt );
            if ( spd_x > 0 )
            {
                ply_work.obj_work.disp_flag &= 4294967294U;
            }
            else
            {
                ply_work.obj_work.disp_flag |= 1U;
            }
        }
        else
        {
            ply_work.obj_work.move_flag |= 144U;
            AppMain.GmPlySeqGmkSpdSet( ply_work, spd_x, spd_y );
            ply_work.obj_work.spd_m = 0;
            ply_work.obj_work.dir.z = 0;
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainPinballAir );
        }
        ply_work.obj_work.flag &= 4294967293U;
        AppMain.GmPlayerSetAtk( ply_work );
        ply_work.no_spddown_timer = 2457600;
        AppMain.GmSoundPlaySE( "Catapult" );
        AppMain.GmPlyEfctCreateSpinJumpBlur( ply_work );
    }

    // Token: 0x06000871 RID: 2161 RVA: 0x0004A650 File Offset: 0x00048850
    private static void GmPlySeqInitMoveGear( AppMain.GMS_PLAYER_WORK ply_work, AppMain.OBS_OBJECT_WORK gmk_obj, bool cam_adjust )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 54 );
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        ply_work.obj_work.dir.z = 0;
        AppMain.GmPlySeqGmkInitGimmickDependInit( ply_work, gmk_obj, 0, 0, 0 );
        ply_work.player_flag |= 514U;
        ply_work.obj_work.user_flag = 1U;
        ply_work.obj_work.move_flag |= 257U;
        if ( ply_work.obj_work.spd_m != 0 )
        {
            AppMain.GmPlayerWalkActionSet( ply_work );
        }
        else if ( ply_work.act_state != 0 )
        {
            AppMain.GmPlayerActionChange( ply_work, 0 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        if ( cam_adjust )
        {
            AppMain.GmPlayerCameraOffsetSet( ply_work, 0, -48 );
            AppMain.GmCameraAllowSet( 0f, 0f, 0f );
        }
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainMoveGear );
    }

    // Token: 0x06000872 RID: 2162 RVA: 0x0004A728 File Offset: 0x00048928
    private static void GmPlySeqInitSteamPipeIn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 57 );
        AppMain.GmPlayerActionChange( ply_work, 26 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 256U;
        ply_work.obj_work.move_flag &= 4294967167U;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd_m = 0;
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.invincible_timer = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainSteamPipe );
        ply_work.gmk_obj = null;
        ply_work.obj_work.user_timer = 0;
        AppMain.GmPlyEfctCreateSteamPipe( ply_work );
        AppMain.GmPlyEfctCreateSpinDashBlur( ply_work, 0U );
    }

    // Token: 0x06000873 RID: 2163 RVA: 0x0004A7FC File Offset: 0x000489FC
    private static void GmPlySeqInitSteamPipeOut( AppMain.GMS_PLAYER_WORK ply_work, int spd_x )
    {
        ply_work.obj_work.move_flag &= 4294967039U;
        ply_work.obj_work.move_flag |= 128U;
        AppMain.GmPlayerSetDefNormal( ply_work );
        ply_work.obj_work.user_timer = 60;
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spd_x, 0 );
        AppMain.GmPlayerActionChange( ply_work, 26 );
        AppMain.GmPlayerSetAtk( ply_work );
    }

    // Token: 0x06000874 RID: 2164 RVA: 0x0004A860 File Offset: 0x00048A60
    private static void GmPlySeqGmkInitPopSteamJump( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, int no_jump_move_time )
    {
        if ( ply_work.seq_state != 58 )
        {
            AppMain.GmPlySeqChangeSequenceState( ply_work, 58 );
        }
        ply_work.obj_work.spd.x = ( ply_work.obj_work.spd.y = 0 );
        ply_work.obj_work.spd_add.x = ( ply_work.obj_work.spd_add.y = 0 );
        ply_work.obj_work.spd_m = 0;
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spd_x, spd_y );
        if ( no_jump_move_time > 0 )
        {
            AppMain.GmPlySeqSetNoJumpMoveTime( ply_work, no_jump_move_time );
        }
    }

    // Token: 0x06000875 RID: 2165 RVA: 0x0004A8E8 File Offset: 0x00048AE8
    private static void GmPlySeqInitDrainTank( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 55 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        AppMain.GmPlayerActionChange( ply_work, 26 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4294967166U;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd.z = 0;
        ply_work.obj_work.spd_add.x = 0;
        ply_work.obj_work.spd_add.y = 0;
        ply_work.obj_work.spd_add.z = 0;
        ply_work.seq_func = null;
    }

    // Token: 0x06000876 RID: 2166 RVA: 0x0004A9BC File Offset: 0x00048BBC
    private static void GmPlySeqInitDrainTankFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 56 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        AppMain.GmPlayerActionChange( ply_work, 26 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.obj_work.move_flag |= 32912U;
        ply_work.obj_work.move_flag &= 4294967294U;
        ply_work.obj_work.spd_add.x = 0;
        ply_work.obj_work.spd_add.y = 0;
        ply_work.obj_work.spd_add.z = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainDrainTank );
    }

    // Token: 0x06000877 RID: 2167 RVA: 0x0004AA64 File Offset: 0x00048C64
    private static void GmPlySeqInitSplIn( AppMain.GMS_PLAYER_WORK ply_work, AppMain.VecFx32 pos )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 59 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        if ( ply_work.act_state != 26 )
        {
            AppMain.GmPlayerActionChange( ply_work, 39 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag |= 41232U;
        ply_work.obj_work.move_flag &= 4294967166U;
        ply_work.obj_work.pos.x = pos.x;
        ply_work.obj_work.pos.y = pos.y;
        ply_work.seq_func = null;
        AppMain.g_gm_main_system.game_flag |= 16384U;
    }

    // Token: 0x06000878 RID: 2168 RVA: 0x0004AB20 File Offset: 0x00048D20
    private static void GmPlySeqGmkInitBoss2Catch( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 60 );
        if ( ply_work.act_state != 39 )
        {
            AppMain.GmPlayerActionChange( ply_work, 39 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.move_flag |= 41232U;
        ply_work.obj_work.move_flag &= 4294967166U;
        ply_work.seq_func = null;
    }

    // Token: 0x06000879 RID: 2169 RVA: 0x0004AB90 File Offset: 0x00048D90
    private static void GmPlySeqGmkInitBoss5Quake( AppMain.GMS_PLAYER_WORK ply_work, int no_move_time )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 61 );
        if ( ply_work.act_state != 34 )
        {
            AppMain.GmPlayerActionChange( ply_work, 34 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        ply_work.obj_work.spd.x = ( ply_work.obj_work.spd.y = 0 );
        ply_work.obj_work.spd_add.x = ( ply_work.obj_work.spd_add.y = 0 );
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.move_flag |= 40960U;
        ply_work.obj_work.user_timer = no_move_time;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainBoss5Quake );
    }

    // Token: 0x0600087A RID: 2170 RVA: 0x0004AC54 File Offset: 0x00048E54
    private static void GmPlySeqGmkInitEndingDemo1( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 62 );
        AppMain.GmPlayerActionChange( ply_work, 77 );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainEndingFrontSide );
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd_add.x = 0;
        ply_work.obj_work.spd_add.y = 0;
    }

    // Token: 0x0600087B RID: 2171 RVA: 0x0004ACD4 File Offset: 0x00048ED4
    private static void GmPlySeqGmkInitEndingDemo2( AppMain.GMS_PLAYER_WORK ply_work, bool type2 )
    {
        AppMain.GmPlySeqChangeSequenceState( ply_work, 63 );
        AppMain.GmPlayerActionChange( ply_work, 39 );
        ply_work.obj_work.disp_flag |= 4U;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainEndingFinish );
        ply_work.obj_work.spd.y = -10240;
        ply_work.obj_work.spd_add.y = 168;
        ply_work.obj_work.dir.y = 16384;
        ply_work.obj_work.user_work = 0U;
        ply_work.obj_work.user_flag = 0U;
        if ( type2 )
        {
            ply_work.obj_work.user_flag = 1U;
        }
        ply_work.obj_work.move_flag |= 33040U;
    }

    // Token: 0x0600087C RID: 2172 RVA: 0x0004AD94 File Offset: 0x00048F94
    private static void GmPlySeqGmkInitTruckDanger( AppMain.GMS_PLAYER_WORK ply_work, AppMain.OBS_OBJECT_WORK gmk_obj )
    {
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        AppMain.GmPlySeqChangeSequenceState( ply_work, 64 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.gmk_obj = gmk_obj;
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.invincible_timer = 0;
        ply_work.player_flag &= 4294967280U;
        ply_work.gmk_flag &= 4293918719U;
        ply_work.gmk_flag |= 32768U;
        AppMain.nnMakeUnitMatrix( ply_work.ex_obj_mtx_r );
        int num = (int)(32768 - ply_work.obj_work.dir.z + (ushort)((short)(AppMain.g_gm_main_system.pseudofall_dir - ply_work.obj_work.dir_fall)));
        ply_work.gmk_work1 = 0;
        ply_work.gmk_work2 = 69632;
        ply_work.gmk_work3 = 0;
        ply_work.obj_work.user_work = 0U;
        uint num2 = AppMain.gmPlayerCheckTruckAirFoot(ply_work);
        if ( ply_work.obj_work.dir.z <= 32768 )
        {
            if ( ( num2 & 1U ) != 0U )
            {
                num -= 6144;
                ply_work.obj_work.user_timer = 1024;
            }
            else
            {
                ply_work.player_flag |= 2U;
                AppMain.GmPlayerActionChange( ply_work, 74 );
            }
        }
        else if ( ( num2 & 2U ) != 0U )
        {
            num += 6144;
            ply_work.player_flag |= 4U;
            ply_work.obj_work.user_timer = -1024;
        }
        else
        {
            ply_work.player_flag |= 2U;
            AppMain.GmPlayerActionChange( ply_work, 74 );
        }
        ply_work.gmk_work0 = ( int )( ( ushort )( num / 17 ) );
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainTruckDanger );
        AppMain.GmSoundPlaySE( "Lorry2" );
    }

    // Token: 0x0600087D RID: 2173 RVA: 0x0004AF1C File Offset: 0x0004911C
    private static void GmPlySeqGmkInitTruckDangerRet( AppMain.GMS_PLAYER_WORK ply_work, AppMain.OBS_OBJECT_WORK gmk_obj )
    {
        int gmk_work = ply_work.gmk_work3;
        uint num = ply_work.player_flag & 13U;
        AppMain.GmPlySeqChangeSequenceState( ply_work, 64 );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.player_flag |= num;
        ply_work.gmk_obj = gmk_obj;
        AppMain.GmPlayerActionChange( ply_work, 76 );
        ply_work.gmk_flag |= 32768U;
        int num2 = (int)(32768 - ply_work.obj_work.dir.z) - gmk_work + (int)((short)(AppMain.g_gm_main_system.pseudofall_dir - ply_work.obj_work.dir_fall));
        if ( num2 > 0 )
        {
            num2 = ( int )( ( ushort )num2 );
        }
        ply_work.gmk_work0 = -num2 / 14;
        ply_work.gmk_work1 = num2;
        ply_work.gmk_work2 = 0;
        ply_work.gmk_work3 = gmk_work;
        ply_work.obj_work.vib_timer = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainTruckDangerRet );
    }

    // Token: 0x0600087E RID: 2174 RVA: 0x0004AFED File Offset: 0x000491ED
    private static void GmPlySeqGmkInitGmkJump( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, spd_x, spd_y, true );
    }

    // Token: 0x0600087F RID: 2175 RVA: 0x0004AFF8 File Offset: 0x000491F8
    private static void GmPlySeqGmkInitGmkJump( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y, bool set_act )
    {
        if ( ( ply_work.player_flag & 1024U ) != 0U )
        {
            return;
        }
        AppMain.GmPlayerStateGimmickInit( ply_work );
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            ply_work.obj_work.spd.x = ply_work.obj_work.spd_m;
        }
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            AppMain.ObjObjectSpdDirFall( ref spd_x, ref spd_y, ( ushort )-ply_work.jump_pseudofall_dir );
        }
        else
        {
            AppMain.ObjObjectSpdDirFall( ref spd_x, ref spd_y, ply_work.obj_work.dir_fall );
        }
        if ( ( ply_work.obj_work.move_flag & 16U ) == 0U )
        {
            ply_work.camera_jump_pos_y = ply_work.obj_work.pos.y;
        }
        ply_work.obj_work.move_flag |= 32784U;
        ply_work.obj_work.move_flag &= 4294967294U;
        if ( spd_x != 0 )
        {
            if ( set_act )
            {
                AppMain.GmPlayerActionChange( ply_work, 47 );
            }
            ply_work.obj_work.spd.x = spd_x;
            if ( ply_work.obj_work.spd.x < 0 )
            {
                if ( ply_work.obj_work.spd_m > 0 )
                {
                    ply_work.obj_work.spd_m = 0;
                }
                ply_work.obj_work.disp_flag |= 1U;
            }
            else
            {
                if ( ply_work.obj_work.spd_m < 0 )
                {
                    ply_work.obj_work.spd_m = 0;
                }
                ply_work.obj_work.disp_flag &= 4294967294U;
            }
            ply_work.no_spddown_timer = 262144;
        }
        else
        {
            if ( set_act )
            {
                AppMain.GmPlayerActionChange( ply_work, 44 );
                ply_work.obj_work.disp_flag |= 4U;
            }
            ply_work.obj_work.spd.x = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathCos( ( int )ply_work.obj_work.dir.z ) );
        }
        if ( spd_y != 0 )
        {
            ply_work.obj_work.spd.y = spd_y;
        }
        else
        {
            ply_work.obj_work.spd.y = AppMain.FX_Mul( ply_work.obj_work.spd_m, AppMain.mtMathSin( ( int )ply_work.obj_work.dir.z ) );
        }
        ply_work.obj_work.user_timer = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.timer = 0;
        AppMain.GmPlySeqSetJumpState( ply_work, 0, 3U );
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATERJUMP_SET( ref ply_work.obj_work.spd.x );
            AppMain.GMD_PLAYER_WATERJUMP_SET( ref ply_work.obj_work.spd.y );
        }
    }

    // Token: 0x06000880 RID: 2176 RVA: 0x0004B270 File Offset: 0x00049470
    private static void GmPlySeqGmkInitGimmickDependInit( AppMain.GMS_PLAYER_WORK ply_work, AppMain.OBS_OBJECT_WORK gmk_obj, int ofst_x, int ofst_y, int ofst_z )
    {
        if ( ply_work.gmk_obj == gmk_obj )
        {
            return;
        }
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.GmPlayerStateGimmickInit( ply_work );
        ply_work.gmk_obj = gmk_obj;
        ply_work.obj_work.move_flag |= 40976U;
        ply_work.obj_work.move_flag &= 4294967103U;
        ply_work.obj_work.user_flag = 0U;
        ply_work.player_flag &= 4294967280U;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.user_work = 0U;
        ply_work.obj_work.user_timer = 0;
        ply_work.gmk_work0 = ofst_x;
        ply_work.gmk_work1 = ofst_y;
        ply_work.gmk_work2 = ofst_z;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.GmPlySeqGmkMainGimmickDepend );
    }

    // Token: 0x06000881 RID: 2177 RVA: 0x0004B354 File Offset: 0x00049554
    private static void GmPlySeqGmkMainGimmickDepend( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ply_work;
        AppMain.OBS_OBJECT_WORK gmk_obj = ply_work.gmk_obj;
        if ( gmk_obj != null )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)ply_work.gmk_obj;
            if ( ( gms_ENEMY_COM_WORK.enemy_flag & 15U ) != 0U )
            {
                ply_work.gmk_obj = null;
                if ( ( gms_ENEMY_COM_WORK.enemy_flag & 2U ) != 0U )
                {
                    obs_OBJECT_WORK.spd.x = gmk_obj.spd.x;
                    obs_OBJECT_WORK.spd.y = gmk_obj.spd.y;
                }
                else if ( ( gms_ENEMY_COM_WORK.enemy_flag & 4U ) != 0U )
                {
                    obs_OBJECT_WORK.spd.x = gmk_obj.spd_m;
                }
                else if ( ( gms_ENEMY_COM_WORK.enemy_flag & 8U ) != 0U )
                {
                    obs_OBJECT_WORK.spd.x = obs_OBJECT_WORK.move.x;
                    obs_OBJECT_WORK.spd.y = obs_OBJECT_WORK.move.y;
                }
            }
            else
            {
                obs_OBJECT_WORK.prev_pos.x = obs_OBJECT_WORK.pos.x;
                obs_OBJECT_WORK.prev_pos.y = obs_OBJECT_WORK.pos.y;
                obs_OBJECT_WORK.prev_pos.z = obs_OBJECT_WORK.pos.z;
                if ( ( ply_work.player_flag & 1U ) != 0U )
                {
                    obs_OBJECT_WORK.pos.Assign( gmk_obj.pos );
                }
                else if ( ( ply_work.player_flag & 2U ) != 0U )
                {
                    obs_OBJECT_WORK.pos.x = gmk_obj.pos.x + gms_ENEMY_COM_WORK.target_dp_pos.x;
                    obs_OBJECT_WORK.pos.y = gmk_obj.pos.y + gms_ENEMY_COM_WORK.target_dp_pos.y;
                    obs_OBJECT_WORK.pos.z = gmk_obj.pos.z + gms_ENEMY_COM_WORK.target_dp_pos.z;
                }
                else if ( ( ply_work.player_flag & 4U ) != 0U )
                {
                    AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
                    AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(0f, -1f, 0f);
                    AppMain.nnMakeUnitMatrix( nns_MATRIX );
                    AppMain.nnRotateXYZMatrix( nns_MATRIX, nns_MATRIX, ( int )( -( int )gms_ENEMY_COM_WORK.target_dp_dir.x ), ( int )gms_ENEMY_COM_WORK.target_dp_dir.y, ( int )gms_ENEMY_COM_WORK.target_dp_dir.z );
                    AppMain.nnTransformVector( nns_VECTOR, nns_MATRIX, nns_VECTOR );
                    AppMain.nnScaleVector( nns_VECTOR, nns_VECTOR, AppMain.FXM_FX32_TO_FLOAT( gms_ENEMY_COM_WORK.target_dp_dist ) );
                    obs_OBJECT_WORK.pos.x = gmk_obj.pos.x + AppMain.FXM_FLOAT_TO_FX32( nns_VECTOR.x );
                    obs_OBJECT_WORK.pos.y = gmk_obj.pos.y + AppMain.FXM_FLOAT_TO_FX32( nns_VECTOR.y );
                    obs_OBJECT_WORK.pos.z = gmk_obj.pos.z + AppMain.FXM_FLOAT_TO_FX32( nns_VECTOR.z );
                    AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
                }
                if ( ( ply_work.player_flag & 8U ) != 0U )
                {
                    obs_OBJECT_WORK.dir.Assign( gms_ENEMY_COM_WORK.target_dp_dir );
                }
                obs_OBJECT_WORK.move.x = obs_OBJECT_WORK.pos.x - obs_OBJECT_WORK.prev_pos.x;
                obs_OBJECT_WORK.move.y = obs_OBJECT_WORK.pos.y - obs_OBJECT_WORK.prev_pos.y;
                obs_OBJECT_WORK.move.z = obs_OBJECT_WORK.pos.z - obs_OBJECT_WORK.prev_pos.z;
                if ( ( obs_OBJECT_WORK.user_flag & 1U ) != 0U && gmk_obj.vib_timer != 0 )
                {
                    obs_OBJECT_WORK.vib_timer = gmk_obj.vib_timer + 4096;
                }
                if ( ( obs_OBJECT_WORK.move_flag & 8192U ) != 0U )
                {
                    obs_OBJECT_WORK.flow.x = ( obs_OBJECT_WORK.flow.y = ( obs_OBJECT_WORK.flow.z = 0 ) );
                }
            }
        }
        if ( ply_work.gmk_obj == null )
        {
            AppMain.GmPlayerStateGimmickInit( ply_work );
        }
    }

    // Token: 0x06000882 RID: 2178 RVA: 0x0004B6D8 File Offset: 0x000498D8
    private static void GmPlySeqGmkSpdSet( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        if ( spd_x < 0 )
        {
            ply_work.obj_work.disp_flag |= 1U;
        }
        else if ( spd_x > 0 )
        {
            ply_work.obj_work.disp_flag &= 4294967294U;
        }
        if ( ( ply_work.obj_work.move_flag & 16U ) != 0U )
        {
            if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd.x > spd_x ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd.x < spd_x ) )
            {
                ply_work.obj_work.spd.x = spd_x;
            }
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) < AppMain.MTM_MATH_ABS( spd_y ) )
            {
                ply_work.obj_work.spd.y = spd_y;
                return;
            }
        }
        else
        {
            switch ( ( ply_work.obj_work.dir.z + 8192 & 49152 ) >> 14 )
            {
                case 0:
                case 2:
                    if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd_m > spd_x ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd_m < spd_x ) )
                    {
                        ply_work.obj_work.spd_m = spd_x;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) < AppMain.MTM_MATH_ABS( spd_y ) )
                    {
                        ply_work.obj_work.spd.y = spd_y;
                        if ( ply_work.obj_work.spd.y < 0 )
                        {
                            ply_work.obj_work.move_flag |= 16U;
                            return;
                        }
                    }
                    break;
                case 1:
                    if ( ( spd_y > 0 && ply_work.obj_work.spd_m < spd_y ) || ( spd_y < 0 && ply_work.obj_work.spd_m > spd_y ) )
                    {
                        ply_work.obj_work.spd_m = spd_y;
                    }
                    if ( ply_work.obj_work.spd_m > 0 )
                    {
                        ply_work.obj_work.disp_flag &= 4294967294U;
                    }
                    else
                    {
                        ply_work.obj_work.disp_flag |= 1U;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < AppMain.MTM_MATH_ABS( spd_x ) )
                    {
                        ply_work.obj_work.spd.x = spd_x;
                        return;
                    }
                    break;
                case 3:
                    if ( ( spd_y > 0 && ply_work.obj_work.spd_m > -spd_y ) || ( spd_y < 0 && ply_work.obj_work.spd_m < -spd_y ) )
                    {
                        ply_work.obj_work.spd_m = -spd_y;
                    }
                    if ( ply_work.obj_work.spd_m > 0 )
                    {
                        ply_work.obj_work.disp_flag &= 4294967294U;
                    }
                    else
                    {
                        ply_work.obj_work.disp_flag |= 1U;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < AppMain.MTM_MATH_ABS( spd_x ) )
                    {
                        ply_work.obj_work.spd.x = spd_x;
                    }
                    break;
                default:
                    return;
            }
        }
    }

    // Token: 0x06000883 RID: 2179 RVA: 0x0004B9BC File Offset: 0x00049BBC
    private static void GmPlySeqGmkTruckSpdSet( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        if ( spd_x < 0 )
        {
            ply_work.gmk_flag |= 1048576U;
        }
        else if ( spd_x > 0 )
        {
            ply_work.gmk_flag &= 4293918719U;
        }
        if ( ( ply_work.obj_work.move_flag & 16U ) != 0U )
        {
            if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd.x > spd_x ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd.x < spd_x ) )
            {
                ply_work.obj_work.spd.x = spd_x;
            }
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) < AppMain.MTM_MATH_ABS( spd_y ) )
            {
                ply_work.obj_work.spd.y = spd_y;
                return;
            }
        }
        else
        {
            ushort num = (ushort)(ply_work.obj_work.dir.z + ply_work.obj_work.dir_fall);
            switch ( ( num + 8192 & 49152 ) >> 14 )
            {
                case 0:
                case 2:
                    if ( ( ( ply_work.gmk_flag & 1048576U ) != 0U && ply_work.obj_work.spd_m > spd_x ) || ( ( ply_work.gmk_flag & 1048576U ) == 0U && ply_work.obj_work.spd_m < spd_x ) )
                    {
                        ply_work.obj_work.spd_m = spd_x;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) < AppMain.MTM_MATH_ABS( spd_y ) )
                    {
                        ply_work.obj_work.spd.y = spd_y;
                        if ( ply_work.obj_work.spd.y < 0 )
                        {
                            ply_work.obj_work.move_flag |= 16U;
                            return;
                        }
                    }
                    break;
                case 1:
                    if ( ( spd_y > 0 && ply_work.obj_work.spd_m < spd_y ) || ( spd_y < 0 && ply_work.obj_work.spd_m > spd_y ) )
                    {
                        ply_work.obj_work.spd_m = spd_y;
                    }
                    if ( ply_work.obj_work.spd_m > 0 )
                    {
                        ply_work.gmk_flag &= 4293918719U;
                    }
                    else
                    {
                        ply_work.gmk_flag |= 1048576U;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < AppMain.MTM_MATH_ABS( spd_x ) )
                    {
                        ply_work.obj_work.spd.x = spd_x;
                        return;
                    }
                    break;
                case 3:
                    if ( ( spd_y > 0 && ply_work.obj_work.spd_m > -spd_y ) || ( spd_y < 0 && ply_work.obj_work.spd_m < -spd_y ) )
                    {
                        ply_work.obj_work.spd_m = -spd_y;
                    }
                    if ( ply_work.obj_work.spd_m > 0 )
                    {
                        ply_work.gmk_flag &= 4293918719U;
                    }
                    else
                    {
                        ply_work.gmk_flag |= 1048576U;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < AppMain.MTM_MATH_ABS( spd_x ) )
                    {
                        ply_work.obj_work.spd.x = spd_x;
                    }
                    break;
                default:
                    return;
            }
        }
    }

    // Token: 0x06000884 RID: 2180 RVA: 0x0004BCA4 File Offset: 0x00049EA4
    private static void gmPlySeqGmkMainGimmickRockRidePush( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.obj_3d.speed[0] -= 0.02f;
        if ( obj_work.obj_3d.speed[0] <= 0.5f )
        {
            obj_work.obj_3d.speed[0] = 0.5f;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.user_timer = 5;
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRideStartWait );
            obj_work.obj_3d.speed[0] = 1f;
        }
    }

    // Token: 0x06000885 RID: 2181 RVA: 0x0004BD38 File Offset: 0x00049F38
    private static void gmPlySeqGmkMainGimmickRockRideStartWait( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.user_timer--;
        if ( obj_work.user_timer > 0 )
        {
            return;
        }
        obj_work.user_timer = 0;
        ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRideStartJump );
    }

    // Token: 0x06000886 RID: 2182 RVA: 0x0004BD80 File Offset: 0x00049F80
    private static void gmPlySeqGmkMainGimmickRockRideStartJump( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK gmk_obj = ply_work.gmk_obj;
            int num = 13824;
            if ( gmk_obj.pos.x < obj_work.pos.x )
            {
                num = -num;
            }
            AppMain.GmPlySeqGmkInitGmkJump( ply_work, num, -24576 );
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRideStartFall );
        }
    }

    // Token: 0x06000887 RID: 2183 RVA: 0x0004BDE4 File Offset: 0x00049FE4
    private static void gmPlySeqGmkMainGimmickRockRideStartFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06000888 RID: 2184 RVA: 0x0004BE04 File Offset: 0x0004A004
    private static void gmPlySeqGmkMainGimmickRockRide( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.OBS_OBJECT_WORK gmk_obj = ply_work.gmk_obj;
        if ( gmk_obj.spd_m == 0 )
        {
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkMainGimmickRockRideStop );
            AppMain.GmPlayerCameraOffsetSet( ply_work, 0, 0 );
            AppMain.GmCameraAllowReset();
            return;
        }
        int num = AppMain.GmPlayerKeyGetGimmickRotZ(ply_work);
        int num2 = -num;
        float x = (float)num2 / AppMain.GMD_GMK_ROCK_RIDE_KEY_ANGLE_LIMIT;
        int num3 = AppMain.FX_Mul(61440, AppMain.FX_F32_TO_FX32(x));
        if ( gmk_obj.spd_m > 0 )
        {
            num3 += -32768;
        }
        else
        {
            num3 -= -32768;
        }
        int num4 = num3 - obj_work.spd_m;
        if ( num4 > 0 )
        {
            obj_work.spd_m += 384;
        }
        else if ( num4 < 0 )
        {
            obj_work.spd_m -= 384;
        }
        int num5 = gmk_obj.spd_m - obj_work.spd_m;
        int num6 = AppMain.MTM_MATH_ABS(num5);
        if ( num6 >= 15360 )
        {
            int num7 = 16384;
            if ( num5 < 0 )
            {
                num7 = -num7;
            }
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            AppMain.GmPlySeqGmkInitGmkJump( ply_work, num7, 12288 );
            AppMain.GmPlayerCameraOffsetSet( ply_work, 0, 0 );
            AppMain.GmCameraAllowReset();
            return;
        }
        if ( num6 >= 2816 )
        {
            if ( ply_work.act_state != 61 )
            {
                AppMain.GmPlayerActionChange( ply_work, 61 );
                obj_work.disp_flag |= 4U;
            }
        }
        else if ( ply_work.act_state != 60 )
        {
            AppMain.GmPlayerActionChange( ply_work, 60 );
            obj_work.disp_flag |= 4U;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)gmk_obj;
        gms_ENEMY_COM_WORK.target_dp_dir.z = ( ushort )( num5 * 4 / 5 );
        AppMain.GmPlySeqGmkMainGimmickDepend( ply_work );
    }

    // Token: 0x06000889 RID: 2185 RVA: 0x0004BF8C File Offset: 0x0004A18C
    private static void gmPlySeqGmkMainGimmickRockRideStop( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.GmPlySeqGmkInitGmkJump( ply_work, obj_work.spd.x, obj_work.spd.y );
    }

    // Token: 0x0600088A RID: 2186 RVA: 0x0004BFBC File Offset: 0x0004A1BC
    private static void gmPlySeqGmkMainGimmickBreathing( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( ( obj_work.move_flag & 1U ) != 0U )
            {
                AppMain.GmPlySeqChangeSequence( ply_work, 0 );
                return;
            }
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
        }
    }

    // Token: 0x0600088B RID: 2187 RVA: 0x0004BFFD File Offset: 0x0004A1FD
    private static void gmPlySeqGmkMainDashPanel( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.user_timer--;
        if ( ply_work.obj_work.user_timer <= 0 || ply_work.obj_work.spd_m == 0 )
        {
            AppMain.GmPlayerSpdParameterSet( ply_work );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x0600088C RID: 2188 RVA: 0x0004C03C File Offset: 0x0004A23C
    private static void gmPlySeqGmkMainWaterSlider( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        if ( ( obj_work.move_flag & 1U ) == 0U )
        {
            AppMain.nnMakeUnitMatrix( ply_work.ex_obj_mtx_r );
            ply_work.gmk_flag &= 4294934527U;
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) )
        {
            AppMain.nnMakeUnitMatrix( ply_work.ex_obj_mtx_r );
            ply_work.gmk_flag &= 4294934527U;
            obj_work.spd_m /= 2;
            AppMain.GmPlySeqChangeSequence( ply_work, 17 );
        }
    }

    // Token: 0x0600088D RID: 2189 RVA: 0x0004C0BC File Offset: 0x0004A2BC
    private static void gmPlySeqGmkMainSpipe( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.gmk_flag & 65536U ) != 0U )
        {
            if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
            {
                int num = AppMain.FX_Mul(40960, AppMain.mtMathCos((int)(ply_work.obj_work.dir.z - 16384)));
                AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
                obj_work.pos.x = obj_work.pos.x - num;
                num = AppMain.FX_Mul( 40960, AppMain.mtMathSin( ( int )( ply_work.obj_work.dir.z - 16384 ) ) );
                AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
                obj_work2.pos.y = obj_work2.pos.y - num;
                ply_work.obj_work.spd.x = 0;
                ply_work.obj_work.spd.y = 0;
            }
            ply_work.obj_work.move_flag &= 4294934511U;
            if ( ply_work.obj_work.spd_m == 0 )
            {
                ply_work.obj_work.spd_m = 8192;
                AppMain.GmSoundPlaySE( "Spin" );
            }
        }
        else
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 10 );
        }
        ply_work.gmk_flag &= 4294901759U;
    }

    // Token: 0x0600088E RID: 2190 RVA: 0x0004C1E8 File Offset: 0x0004A3E8
    private static void gmPlySeqGmkScrewMain( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerWalkActionCheck( ply_work );
        AppMain.GMS_PLY_SEQ_STATE_DATA[] seq_state_data_tbl = ply_work.seq_state_data_tbl;
        if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < ply_work.spd2 && ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            ply_work.obj_work.dir.x = ( ply_work.obj_work.dir.y = ( ply_work.obj_work.dir.z = 0 ) );
            ply_work.obj_work.move_flag &= 4294959103U;
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            return;
        }
        if ( ply_work.timer != 0 )
        {
            ply_work.timer--;
        }
        else if ( ( ply_work.obj_work.move_flag & 13U ) != 0U )
        {
            ply_work.obj_work.dir.x = ( ply_work.obj_work.dir.y = ( ply_work.obj_work.dir.z = 0 ) );
            ply_work.obj_work.move_flag &= 4294959103U;
            ply_work.obj_work.spd.x = ply_work.obj_work.spd_m;
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        AppMain.GmPlySeqMoveWalk( ply_work );
        AppMain.gmPlySeqGmkMoveScrew( ply_work, 1530320, 288, 38 );
    }

    // Token: 0x0600088F RID: 2191 RVA: 0x0004C340 File Offset: 0x0004A540
    private static void gmPlySeqGmkMoveScrew( AppMain.GMS_PLAYER_WORK ply_work, int screw_length, short screw_width, short screw_height )
    {
        ply_work.obj_work.user_timer += AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
        int num = ply_work.obj_work.user_timer;
        sbyte b = (sbyte)(num / screw_length);
        num -= screw_length * ( int )b;
        int num2 = (num << 8) / screw_length << 4;
        ushort num3 = (ushort)(num2 << 4 & 65535);
        ply_work.obj_work.dir.x = num3;
        if ( ( ply_work.obj_work.user_work & ( uint )AppMain.GMD_GMK_SCREW_EVE_FLAG_LEFT ) != 0U )
        {
            ply_work.obj_work.dir.x = ( ushort )-ply_work.obj_work.dir.x;
        }
        if ( ply_work.obj_work.dir.x < 16384 )
        {
            ply_work.obj_work.dir.z = ply_work.obj_work.dir.x;
        }
        else if ( ply_work.obj_work.dir.x < 32768 )
        {
            ply_work.obj_work.dir.z = ( ushort )( 16384 - ( ply_work.obj_work.dir.x - 16384 ) );
        }
        else if ( ply_work.obj_work.dir.x < 49152 )
        {
            ply_work.obj_work.dir.z = ( ushort )( ply_work.obj_work.dir.x - 32768 );
        }
        else
        {
            ply_work.obj_work.dir.z = ( ushort )( 65536 - ( int )ply_work.obj_work.dir.x );
        }
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        obj_work.dir.z = ( ushort )( obj_work.dir.z >> 1 );
        if ( ply_work.obj_work.dir.x < 32768 )
        {
            ply_work.obj_work.dir.z = ( ushort )-ply_work.obj_work.dir.z;
        }
        ply_work.obj_work.dir.x = ( ushort )-ply_work.obj_work.dir.x;
        int num4 = AppMain.mtMathCos((int)num3);
        screw_height -= ply_work.obj_work.field_rect[3];
        screw_height = ( short )-screw_height;
        ply_work.obj_work.prev_pos.x = ply_work.obj_work.pos.x;
        ply_work.obj_work.prev_pos.y = ply_work.obj_work.pos.y;
        if ( ( ply_work.obj_work.user_work & ( uint )AppMain.GMD_GMK_SCREW_EVE_FLAG_LEFT ) != 0U )
        {
            ply_work.obj_work.pos.x = ply_work.gmk_work0 - ( ( int )( ( short )b * screw_width ) << 12 ) - ( int )screw_width * num2;
        }
        else
        {
            ply_work.obj_work.pos.x = ply_work.gmk_work0 + ( ( int )( ( short )b * screw_width ) << 12 ) + ( int )screw_width * num2;
        }
        ply_work.obj_work.pos.y = ply_work.gmk_work1 + ( ( int )screw_height << 12 ) - num4 * ( int )screw_height;
        ply_work.obj_work.move.x = ply_work.obj_work.pos.x - ply_work.obj_work.prev_pos.x;
        ply_work.obj_work.move.y = ply_work.obj_work.pos.y - ply_work.obj_work.prev_pos.y;
    }

    // Token: 0x06000890 RID: 2192 RVA: 0x0004C678 File Offset: 0x0004A878
    private static void gmPlySeqGmkCannonWait( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.pos.y >= ply_work.gmk_obj.pos.y )
        {
            ply_work.obj_work.pos.y = ply_work.gmk_obj.pos.y;
            ply_work.obj_work.spd.y = 0;
            ply_work.obj_work.spd_add.y = 0;
            ply_work.obj_work.spd_add.y = 0;
            ply_work.obj_work.spd_fall = 0;
            ply_work.seq_func = null;
            ply_work.obj_work.move_flag &= 4294967167U;
        }
    }

    // Token: 0x06000891 RID: 2193 RVA: 0x0004C724 File Offset: 0x0004A924
    private static void gmPlySeqGmkStopperMove( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.pos.x = ( ply_work.obj_work.pos.x + ply_work.gmk_obj.pos.x ) / 2;
        int num = AppMain.MTM_MATH_ABS(ply_work.obj_work.pos.x - ply_work.gmk_obj.pos.x);
        if ( num < 1024 )
        {
            ply_work.obj_work.pos.x = ply_work.gmk_obj.pos.x;
        }
        if ( ply_work.obj_work.pos.y > ply_work.gmk_obj.pos.y )
        {
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.pos.y = obj_work.pos.y - 32768;
            if ( ply_work.obj_work.pos.y < ply_work.gmk_obj.pos.y )
            {
                ply_work.obj_work.pos.y = ply_work.gmk_obj.pos.y;
            }
        }
        else
        {
            AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
            obj_work2.pos.y = obj_work2.pos.y + 32768;
            if ( ply_work.obj_work.pos.y > ply_work.gmk_obj.pos.y )
            {
                ply_work.obj_work.pos.y = ply_work.gmk_obj.pos.y;
            }
        }
        if ( ply_work.obj_work.pos.x == ply_work.gmk_obj.pos.x && ply_work.obj_work.pos.y == ply_work.gmk_obj.pos.y )
        {
            ply_work.seq_func = new AppMain.seq_func_delegate( AppMain.gmPlySeqGmkStopperWait );
        }
    }

    // Token: 0x06000892 RID: 2194 RVA: 0x0004C8EC File Offset: 0x0004AAEC
    private static void gmPlySeqGmkStopperWait( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06000893 RID: 2195 RVA: 0x0004C8F0 File Offset: 0x0004AAF0
    private static void gmPlySeqGmkStopperEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        bool flag = false;
        if ( ply_work.gmk_obj == null )
        {
            flag = true;
        }
        else if ( ply_work.gmk_obj.user_timer < ply_work.obj_work.pos.y >> 12 )
        {
            flag = true;
        }
        if ( flag )
        {
            int y = ply_work.obj_work.spd.y;
            AppMain.GmPlySeqChangeSequence( ply_work, 16 );
            AppMain.GmPlySeqGmkInitGmkJump( ply_work, 0, y, false );
            ply_work.gmk_obj = null;
            if ( ply_work.act_state != 26 )
            {
                AppMain.GmPlayerActionChange( ply_work, 26 );
                ply_work.obj_work.disp_flag |= 4U;
            }
            ply_work.obj_work.flag &= 4294967293U;
        }
    }

    // Token: 0x06000894 RID: 2196 RVA: 0x0004C993 File Offset: 0x0004AB93
    private static void gmPlySeqGmkSeesaw( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06000895 RID: 2197 RVA: 0x0004C998 File Offset: 0x0004AB98
    private static void gmPlySeqGmkMainPinball( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.user_timer--;
        if ( ply_work.obj_work.user_timer <= 0 || ply_work.obj_work.spd_m == 0 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            int spd_x = AppMain.FX_Mul(ply_work.obj_work.spd_m, AppMain.mtMathCos((int)ply_work.obj_work.dir.z));
            int spd_y = AppMain.FX_Mul(ply_work.obj_work.spd_m, AppMain.mtMathSin((int)ply_work.obj_work.dir.z));
            AppMain.GmPlySeqInitPinballAir( ply_work, spd_x, spd_y );
        }
    }

    // Token: 0x06000896 RID: 2198 RVA: 0x0004CA40 File Offset: 0x0004AC40
    private static void gmPlySeqGmkMainPinballAir( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.user_timer > 0 )
        {
            ply_work.obj_work.user_timer--;
        }
        if ( ply_work.obj_work.user_timer <= 0 && ply_work.obj_work.user_flag != 0U )
        {
            ply_work.player_flag &= 4294967263U;
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            ply_work.no_spddown_timer = 0;
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
        }
    }

    // Token: 0x06000897 RID: 2199 RVA: 0x0004CABD File Offset: 0x0004ACBD
    private static void gmPlySeqGmkMainPinballCtpltHold( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06000898 RID: 2200 RVA: 0x0004CAC0 File Offset: 0x0004ACC0
    private static void gmPlySeqGmkMainPinballCtplt( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            int spd_x = AppMain.FX_Mul(ply_work.obj_work.spd_m, AppMain.mtMathCos((int)ply_work.obj_work.dir.z));
            int spd_y = AppMain.FX_Mul(ply_work.obj_work.spd_m, AppMain.mtMathSin((int)ply_work.obj_work.dir.z));
            AppMain.GmPlySeqInitPinballAir( ply_work, spd_x, spd_y );
        }
    }

    // Token: 0x06000899 RID: 2201 RVA: 0x0004CB30 File Offset: 0x0004AD30
    private static void gmPlySeqGmkMainFlipper( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( AppMain.MTM_MATH_ABS( ply_work.gmk_obj.pos.x - ply_work.obj_work.pos.x ) > 221184 || AppMain.MTM_MATH_ABS( ply_work.gmk_obj.pos.y - ply_work.obj_work.pos.y ) > 131072 )
        {
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            ply_work.obj_work.move_flag |= 128U;
            ply_work.obj_work.move_flag &= 4294934271U;
        }
    }

    // Token: 0x0600089A RID: 2202 RVA: 0x0004CBD0 File Offset: 0x0004ADD0
    private static void gmPlySeqGmkMainForceSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m == 0 )
        {
            if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
            {
                ply_work.obj_work.spd_m = -8192;
            }
            else
            {
                ply_work.obj_work.spd_m = 8192;
            }
            AppMain.GmSoundPlaySE( "Spin" );
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            AppMain.GmPlySeqGmkInitForceSpinFall( ply_work );
        }
    }

    // Token: 0x0600089B RID: 2203 RVA: 0x0004CC3C File Offset: 0x0004AE3C
    private static void gmPlySeqGmkMainForceSpinDec( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.spd_m == 0 )
        {
            if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
            {
                ply_work.obj_work.spd_m = -8192;
            }
            else
            {
                ply_work.obj_work.spd_m = 8192;
            }
            AppMain.GmSoundPlaySE( "Spin" );
        }
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            if ( ply_work.obj_work.spd_m < -8192 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, -2048 );
            }
        }
        else if ( ply_work.obj_work.spd_m > 8192 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, 2048 );
        }
        if ( ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            AppMain.GmPlySeqGmkInitForceSpinFall( ply_work );
            ply_work.obj_work.spd_m = 0;
        }
    }

    // Token: 0x0600089C RID: 2204 RVA: 0x0004CD27 File Offset: 0x0004AF27
    private static void gmPlySeqGmkMainForceSpinFall( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            if ( ( ply_work.obj_work.user_flag & 1U ) != 0U )
            {
                AppMain.GmPlySeqGmkInitForceSpinDec( ply_work );
                return;
            }
            AppMain.GmPlySeqGmkInitForceSpin( ply_work );
        }
    }

    // Token: 0x0600089D RID: 2205 RVA: 0x0004CD54 File Offset: 0x0004AF54
    private static void gmPlySeqGmkMainMoveGear( AppMain.GMS_PLAYER_WORK ply_work )
    {
        bool flag = true;
        AppMain.OBS_OBJECT_WORK gmk_obj = ply_work.gmk_obj;
        if ( gmk_obj == null )
        {
            AppMain.GmPlySeqChangeFw( ply_work );
            return;
        }
        if ( ( gmk_obj.user_flag & 1U ) == 0U && AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) )
        {
            ply_work.obj_work.spd_m = 0;
            ply_work.obj_work.spd.x = ( ply_work.obj_work.spd.y = 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 17 );
            return;
        }
        ply_work.obj_work.move_flag |= 1U;
        if ( ( gmk_obj.user_flag & 2U ) != 0U )
        {
            ply_work.obj_work.spd_m = 0;
            ply_work.obj_work.spd.x = ( ply_work.obj_work.spd.y = 0 );
        }
        if ( ply_work.act_state != 8 && ( ( ( gmk_obj.user_flag & 2U ) == 0U && ( ( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd_m <= 0 ) || ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd_m >= 0 ) ) ) || ( ( gmk_obj.user_flag & 1U ) != 0U && ( ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd_m <= 0 ) || ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd_m >= 0 ) ) ) || ( ( gmk_obj.user_flag & 2U ) != 0U && gmk_obj.user_work == 7U && ( ( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) == 0U && gmk_obj.user_timer <= 0 ) || ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) != 0U && gmk_obj.user_timer >= 0 ) ) ) ) )
        {
            AppMain.GmPlayerActionChange( ply_work, 8 );
            AppMain.GmPlySeqSetProgramTurnFwTurn( ply_work );
        }
        else if ( ply_work.act_state == 8 )
        {
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                AppMain.GmPlayerSetReverseOnlyState( ply_work );
                AppMain.GmPlayerActionChange( ply_work, 0 );
                ply_work.obj_work.disp_flag |= 4U;
            }
        }
        else if ( ( ( gmk_obj.user_flag & 2U ) != 0U && ( ( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) != 0U ) || ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && ( ply_work.obj_work.disp_flag & 1U ) == 0U ) ) ) || gmk_obj.user_timer != 0 )
        {
            if ( ply_work.ring_num == 0 && ( gmk_obj.user_work == 0U || gmk_obj.user_work == 4U ) )
            {
                if ( ply_work.act_state != 33 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 33 );
                    ply_work.obj_work.obj_3d.blend_spd = 0.0625f;
                    ply_work.obj_work.disp_flag |= 4U;
                }
                ply_work.obj_work.obj_3d.speed[0] = 0.5f;
                ply_work.obj_work.obj_3d.speed[1] = 0.5f;
                flag = false;
            }
            else
            {
                if ( ( ( ( gmk_obj.user_flag & 8U ) == 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) || ( ( gmk_obj.user_flag & 8U ) != 0U && AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) ) ) && gmk_obj.user_work == 7U && gmk_obj.user_timer == 0 )
                {
                    AppMain.GmPlySeqChangeFw( ply_work );
                    return;
                }
                if ( gmk_obj.user_work == 1U || gmk_obj.user_work == 2U )
                {
                    if ( ply_work.act_state != 60 )
                    {
                        AppMain.GmPlayerActionChange( ply_work, 60 );
                        ply_work.obj_work.obj_3d.blend_spd = 0.0625f;
                        ply_work.obj_work.disp_flag |= 4U;
                    }
                }
                else if ( ply_work.act_state != 20 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 20 );
                    ply_work.obj_work.disp_flag |= 4U;
                }
            }
            if ( ply_work.act_state != 33 )
            {
                flag = false;
                int num = gmk_obj.user_timer * 3;
                int num2 = AppMain.MTM_MATH_ABS((num >> 3) + (num >> 2));
                if ( num2 <= 1024 )
                {
                    num2 = 1024;
                }
                if ( num2 >= 32768 )
                {
                    num2 = 32768;
                }
                ply_work.obj_work.obj_3d.speed[0] = AppMain.FXM_FX32_TO_FLOAT( num2 );
                ply_work.obj_work.obj_3d.speed[1] = AppMain.FXM_FX32_TO_FLOAT( num2 );
            }
        }
        else if ( ply_work.obj_work.spd_m != 0 )
        {
            AppMain.GmPlayerWalkActionCheck( ply_work );
        }
        else if ( ply_work.act_state != 0 )
        {
            AppMain.GmPlayerActionChange( ply_work, 0 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        if ( ( gmk_obj.user_flag & 3U ) == 0U )
        {
            if ( ( gmk_obj.user_flag & 4U ) != 0U )
            {
                AppMain.gmPlySeqGmkMoveGearMove( ply_work, true );
            }
            else
            {
                AppMain.gmPlySeqGmkMoveGearMove( ply_work, false );
            }
        }
        if ( flag )
        {
            AppMain.gmPlySeqGmkMoveGearAnimeSpeedSetWalk( ply_work, ply_work.obj_work.spd_m );
        }
        AppMain.GmPlySeqGmkMainGimmickDepend( ply_work );
    }

    // Token: 0x0600089E RID: 2206 RVA: 0x0004D1C8 File Offset: 0x0004B3C8
    private static void gmPlySeqGmkMoveGearMove( AppMain.GMS_PLAYER_WORK ply_work, bool spd_up_type )
    {
        int num;
        int num2;
        if ( !spd_up_type )
        {
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 1024 )
            {
                num = ply_work.spd_add >> 3;
                num2 = ply_work.spd_dec;
            }
            else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 2048 )
            {
                num = ply_work.spd_add >> 2;
                num2 = ( ply_work.spd_dec >> 1 ) + ( ply_work.spd_dec >> 2 );
            }
            else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 3072 )
            {
                num = ply_work.spd_add >> 1;
                num2 = ply_work.spd_dec >> 1;
            }
            else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 4096 )
            {
                num = ( ply_work.spd_add >> 1 ) + ( ply_work.spd_add >> 2 );
                num2 = ply_work.spd_dec >> 2;
            }
            else
            {
                num = ply_work.spd_add;
                num2 = ply_work.spd_dec >> 3;
            }
        }
        else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 3072 )
        {
            num = ply_work.spd_add >> 1;
            num2 = ply_work.spd_dec;
        }
        else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 4096 )
        {
            num = ( ply_work.spd_add >> 1 ) + ( ply_work.spd_add >> 2 );
            num2 = ( ply_work.spd_dec >> 1 ) + ( ply_work.spd_dec >> 2 );
        }
        else
        {
            num = ply_work.spd_add;
            num2 = ply_work.spd_dec >> 1;
        }
        int num3 = (ply_work.spd_max >> 1) + (ply_work.spd_max >> 2);
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) || AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) )
        {
            int num4 = AppMain.MTM_MATH_ABS(ply_work.key_walk_rot_z);
            if ( num4 > 24576 )
            {
                num4 = 24576;
            }
            num3 = num3 * num4 / 24576;
        }
        if ( num3 < ply_work.prev_walk_roll_spd_max )
        {
            num3 = ply_work.prev_walk_roll_spd_max - num2;
            if ( num3 < 0 )
            {
                num3 = 0;
            }
        }
        ply_work.prev_walk_roll_spd_max = num3;
        if ( ply_work.obj_work.dir.z != 0 )
        {
            int num5 = AppMain.FX_Mul(ply_work.spd_max_add_slope, AppMain.mtMathSin((int)ply_work.obj_work.dir.z));
            if ( num5 > 0 )
            {
                num3 += num5;
            }
        }
        if ( ply_work.no_spddown_timer != 0 )
        {
            num2 = 0;
        }
        else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) <= ply_work.spd1 )
        {
            num = num * 5 / 8;
        }
        else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) <= ply_work.spd2 )
        {
            num >>= 1;
        }
        else if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) > ply_work.spd3 )
        {
            int num6;
            if ( num3 - ply_work.spd3 != 0 )
            {
                num6 = AppMain.FX_Div( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) - ply_work.spd3, num3 - ply_work.spd3 );
                if ( num6 > 4096 )
                {
                    num6 = 4096;
                }
            }
            else
            {
                num6 = 4096;
            }
            num6 = num6 * 3968 >> 12;
            num -= AppMain.FX_Mul( num, num6 );
        }
        if ( ply_work.spd_work_max >= num3 && AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= num3 )
        {
            if ( ply_work.spd_work_max > ply_work.obj_work.spd_m )
            {
                ply_work.spd_work_max = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
            }
            num3 = ply_work.spd_work_max;
        }
        if ( ( ply_work.player_flag & 32768U ) != 0U && AppMain.GmPlayerKeyCheckWalkRight( ply_work ) && num3 > ply_work.scroll_spd_x + 8192 )
        {
            num3 = ply_work.scroll_spd_x + 8192;
        }
        if ( !( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) | AppMain.GmPlayerKeyCheckWalkRight( ply_work ) ) )
        {
            ply_work.spd_pool = 0;
            ply_work.obj_work.spd.x = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd.x, -num3, num3 );
            ply_work.obj_work.spd_m = AppMain.MTM_MATH_CLIP( ply_work.obj_work.spd_m, -num3, num3 );
            if ( ( ply_work.obj_work.dir.z + 8192 & 65280 ) <= 16384 )
            {
                if ( ( ply_work.player_flag & 134217728U ) != 0U )
                {
                    ply_work.player_flag &= 4160749567U;
                    return;
                }
                if ( ( ply_work.player_flag & 32768U ) != 0U )
                {
                    if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U || ply_work.seq_state != 1 )
                    {
                        ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                        return;
                    }
                    int num7 = ply_work.scroll_spd_x + -4096;
                    if ( num7 < 0 )
                    {
                        num7 = 0;
                    }
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                    if ( ply_work.obj_work.spd_m < num7 )
                    {
                        ply_work.obj_work.spd_m = num7;
                        return;
                    }
                }
                else
                {
                    ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
                }
            }
            return;
        }
        if ( AppMain.GmPlayerKeyCheckWalkRight( ply_work ) )
        {
            if ( ply_work.obj_work.spd_m < 0 )
            {
                ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
            }
            ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, num, num3 );
            return;
        }
        if ( ply_work.obj_work.spd_m > 0 )
        {
            ply_work.obj_work.spd_m = AppMain.ObjSpdDownSet( ply_work.obj_work.spd_m, num2 );
        }
        ply_work.obj_work.spd_m = AppMain.ObjSpdUpSet( ply_work.obj_work.spd_m, -num, num3 );
    }

    // Token: 0x0600089F RID: 2207 RVA: 0x0004D708 File Offset: 0x0004B908
    private static void gmPlySeqGmkMoveGearAnimeSpeedSetWalk( AppMain.GMS_PLAYER_WORK ply_work, int spd_set )
    {
        int num;
        if ( 19 <= ply_work.act_state && ply_work.act_state <= 21 )
        {
            num = AppMain.MTM_MATH_ABS( ( spd_set >> 3 ) + ( spd_set >> 2 ) );
            if ( num <= 2048 )
            {
                num = 2048;
            }
            if ( num >= 32768 )
            {
                num = 32768;
            }
        }
        else
        {
            num = 4096;
        }
        if ( ply_work.obj_work.obj_3d != null )
        {
            ply_work.obj_work.obj_3d.speed[0] = AppMain.FXM_FX32_TO_FLOAT( num );
            ply_work.obj_work.obj_3d.speed[1] = AppMain.FXM_FX32_TO_FLOAT( num );
        }
    }

    // Token: 0x060008A0 RID: 2208 RVA: 0x0004D798 File Offset: 0x0004B998
    private static void gmPlySeqGmkMainSteamPipe( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.user_timer < 245760 )
        {
            ply_work.obj_work.user_timer = AppMain.ObjTimeCountUp( ply_work.obj_work.user_timer );
            float num = AppMain.FXM_FX32_TO_FLOAT(ply_work.obj_work.user_timer) / 60f * 2f;
            ply_work.obj_work.obj_3d.speed[0] = 1f + num;
            ply_work.obj_work.obj_3d.speed[1] = 1f + num;
        }
    }

    // Token: 0x060008A1 RID: 2209 RVA: 0x0004D824 File Offset: 0x0004BA24
    private static void gmPlySeqGmkMainDrainTank( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqLandingSet( ply_work, 0 );
            AppMain.GmPlySeqChangeSequence( ply_work, 0 );
            return;
        }
        if ( ply_work.obj_work.spd_add.x > 0 )
        {
            if ( ply_work.obj_work.spd.x >= 0 )
            {
                ply_work.obj_work.spd_add.x = 0;
                ply_work.obj_work.spd.x = 0;
                return;
            }
        }
        else if ( ply_work.obj_work.spd_add.x < 0 && ply_work.obj_work.spd.x <= 0 )
        {
            ply_work.obj_work.spd_add.x = 0;
            ply_work.obj_work.spd.x = 0;
        }
    }

    // Token: 0x060008A2 RID: 2210 RVA: 0x0004D8E4 File Offset: 0x0004BAE4
    private static void gmPlySeqGmkMainBoss5Quake( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.obj_work.user_timer > 0 )
        {
            ply_work.obj_work.user_timer--;
            return;
        }
        AppMain.GmPlySeqLandingSet( ply_work, 0 );
        ply_work.obj_work.move_flag &= 4294959103U;
        AppMain.GmPlySeqChangeSequence( ply_work, 0 );
    }

    // Token: 0x060008A3 RID: 2211 RVA: 0x0004D939 File Offset: 0x0004BB39
    private static void gmPlySeqGmkMainEndingFrontSide( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state == 77 && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 78 );
            ply_work.obj_work.disp_flag |= 4U;
        }
    }

    // Token: 0x060008A4 RID: 2212 RVA: 0x0004D970 File Offset: 0x0004BB70
    private static void gmPlySeqGmkMainEndingFinish( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.act_state != 80 && ply_work.act_state != 82 && ply_work.act_state != 84 )
        {
            int user_work = (int)(ply_work.obj_work.user_work + 4U);
            ply_work.obj_work.user_work = ( uint )user_work;
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.scale.x = obj_work.scale.x + ( int )ply_work.obj_work.user_work;
            AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
            obj_work2.scale.y = obj_work2.scale.y + ( int )ply_work.obj_work.user_work;
            AppMain.OBS_OBJECT_WORK obj_work3 = ply_work.obj_work;
            obj_work3.scale.z = obj_work3.scale.z + ( int )ply_work.obj_work.user_work;
            AppMain.OBS_OBJECT_WORK obj_work4 = ply_work.obj_work;
            obj_work4.pos.z = obj_work4.pos.z + 1024;
        }
        if ( ply_work.act_state != 39 || ply_work.obj_work.spd.y <= -4096 )
        {
            if ( ( ply_work.act_state == 79 || ply_work.act_state == 81 || ply_work.act_state == 83 ) && ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                if ( ( ply_work.player_flag & 16384U ) != 0U )
                {
                    AppMain.GmPlayerActionChange( ply_work, 84 );
                }
                else if ( ply_work.obj_work.user_flag != 0U )
                {
                    AppMain.GmPlayerActionChange( ply_work, 82 );
                }
                else
                {
                    AppMain.GmPlayerActionChange( ply_work, 80 );
                }
                ply_work.obj_work.move_flag |= 8192U;
                ply_work.obj_work.disp_flag |= 32U;
                AppMain.GmEndingTrophySet();
            }
            return;
        }
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 83 );
            return;
        }
        if ( ply_work.obj_work.user_flag != 0U )
        {
            AppMain.GmPlayerActionChange( ply_work, 81 );
            return;
        }
        AppMain.GmPlayerActionChange( ply_work, 79 );
    }

    // Token: 0x060008A5 RID: 2213 RVA: 0x0004DB2C File Offset: 0x0004BD2C
    private static uint gmPlayerCheckTruckAirFoot( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        uint num = 0U;
        int num2 = 0;
        int num3 = 0;
        if ( ply_work.obj_work.ride_obj != null )
        {
            return num;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ply_work;
        ushort num4 = ( ushort ) ( obs_OBJECT_WORK.dir.z + obs_OBJECT_WORK.dir_fall );
        obs_COL_CHK_DATA.flag = ( ushort )( obs_OBJECT_WORK.flag & 1U );
        obs_COL_CHK_DATA.vec = 2;
        obs_COL_CHK_DATA.dir = null;
        obs_COL_CHK_DATA.attr = null;
        ushort num5 = (ushort)((obs_OBJECT_WORK.dir.z + 8192 & 49152) >> 14);
        num5 += ( ushort )( ( obs_OBJECT_WORK.dir_fall + 8192 & 49152 ) >> 14 );
        switch ( num5 & 3 )
        {
            case 0:
                obs_COL_CHK_DATA.vec = 2;
                break;
            case 1:
                obs_COL_CHK_DATA.vec = 1;
                break;
            case 2:
                obs_COL_CHK_DATA.vec = 3;
                break;
            case 3:
                obs_COL_CHK_DATA.vec = 0;
                break;
        }
        if ( ( num4 & 16383 ) != 0 )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.NNS_VECTOR nns_VECTOR4 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.NNS_VECTOR nns_VECTOR5 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.NNS_VECTOR nns_VECTOR6 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            switch ( ( num4 & 49152 ) >> 14 )
            {
                case 0:
                    num2 = ( int )( obs_OBJECT_WORK.field_rect[0] - 2 );
                    num3 = ( int )( obs_OBJECT_WORK.field_rect[3] + 2 );
                    break;
                case 1:
                    num2 = ( int )( obs_OBJECT_WORK.field_rect[0] - 2 );
                    num3 = ( int )( obs_OBJECT_WORK.field_rect[1] - 2 );
                    break;
                case 2:
                    num2 = ( int )( obs_OBJECT_WORK.field_rect[2] + 2 );
                    num3 = ( int )( obs_OBJECT_WORK.field_rect[1] - 2 );
                    break;
                case 3:
                    num2 = ( int )( obs_OBJECT_WORK.field_rect[2] + 2 );
                    num3 = ( int )( obs_OBJECT_WORK.field_rect[3] + 2 );
                    break;
            }
            nns_VECTOR.x = ( float )num2;
            nns_VECTOR.y = ( float )( -( float )num3 );
            nns_VECTOR.z = 0f;
            nns_VECTOR2.x = ( float )num2 + 10f * AppMain.nnCos( ( int )( -( int )num4 ) );
            nns_VECTOR2.y = ( float )( -( float )num3 ) + 10f * AppMain.nnSin( ( int )( -( int )num4 ) );
            nns_VECTOR2.z = 0f;
            nns_VECTOR3.x = ( nns_VECTOR3.y = ( nns_VECTOR3.z = 0f ) );
            nns_VECTOR5.x = nns_VECTOR2.x - nns_VECTOR.x;
            nns_VECTOR5.y = nns_VECTOR2.y - nns_VECTOR.y;
            nns_VECTOR5.z = nns_VECTOR2.z - nns_VECTOR.z;
            nns_VECTOR6.x = nns_VECTOR3.x - nns_VECTOR.x;
            nns_VECTOR6.y = nns_VECTOR3.y - nns_VECTOR.y;
            nns_VECTOR6.z = nns_VECTOR3.z - nns_VECTOR.z;
            float num6 = AppMain.nnDotProductVector(nns_VECTOR5, nns_VECTOR6) / AppMain.nnDotProductVector(nns_VECTOR5, nns_VECTOR5);
            nns_VECTOR4.x = nns_VECTOR.x + nns_VECTOR5.x * num6;
            nns_VECTOR4.y = nns_VECTOR.y + nns_VECTOR5.y * num6;
            nns_VECTOR4.z = nns_VECTOR.z + nns_VECTOR5.z * num6;
            num2 = AppMain.FXM_FLOAT_TO_FX32( nns_VECTOR4.x );
            num3 = AppMain.FXM_FLOAT_TO_FX32( -nns_VECTOR4.y );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR4 );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR5 );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR6 );
        }
        else
        {
            switch ( ( num4 & 49152 ) >> 14 )
            {
                case 0:
                    num2 = 0;
                    num3 = ( int )obs_OBJECT_WORK.field_rect[3] << 12;
                    break;
                case 1:
                    num2 = ( int )( -( int )obs_OBJECT_WORK.field_rect[3] ) << 12;
                    num3 = 0;
                    break;
                case 2:
                    num2 = 0;
                    num3 = ( int )( -( int )obs_OBJECT_WORK.field_rect[3] ) << 12;
                    break;
                case 3:
                    num2 = ( int )obs_OBJECT_WORK.field_rect[3] << 12;
                    num3 = 0;
                    break;
            }
        }
        int num7 = AppMain.FXM_FLOAT_TO_FX32((float)obs_OBJECT_WORK.field_rect[2] * AppMain.nnCos((int)num4));
        int num8 = AppMain.FXM_FLOAT_TO_FX32((float)obs_OBJECT_WORK.field_rect[2] * AppMain.nnSin((int)num4));
        obs_COL_CHK_DATA.pos_x = num2 + num7 + obs_OBJECT_WORK.pos.x >> 12;
        obs_COL_CHK_DATA.pos_y = num3 + num8 + obs_OBJECT_WORK.pos.y >> 12;
        int num9 = AppMain.ObjDiffCollision(obs_COL_CHK_DATA);
        if ( num9 <= 2 )
        {
            num |= 1U;
        }
        num7 = AppMain.FXM_FLOAT_TO_FX32( ( float )obs_OBJECT_WORK.field_rect[0] * AppMain.nnCos( ( int )num4 ) );
        num8 = AppMain.FXM_FLOAT_TO_FX32( ( float )obs_OBJECT_WORK.field_rect[0] * AppMain.nnSin( ( int )num4 ) );
        obs_COL_CHK_DATA.pos_x = num2 + num7 + obs_OBJECT_WORK.pos.x >> 12;
        obs_COL_CHK_DATA.pos_y = num3 + num8 + obs_OBJECT_WORK.pos.y >> 12;
        int num10 = AppMain.ObjDiffCollision(obs_COL_CHK_DATA);
        if ( num10 <= 2 )
        {
            num |= 2U;
        }
        return num;
    }

    // Token: 0x060008A6 RID: 2214 RVA: 0x0004DFE8 File Offset: 0x0004C1E8
    private static void gmPlySeqGmkMainTruckDanger( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        if ( ( ply_work.player_flag & 2U ) == 0U )
        {
            if ( AppMain.MTM_MATH_ABS( ply_work.gmk_work3 ) < 6144 )
            {
                ply_work.gmk_work3 += ply_work.obj_work.user_timer;
                if ( ( ply_work.player_flag & 4U ) == 0U )
                {
                    if ( ply_work.gmk_work3 > 6144 )
                    {
                        ply_work.gmk_work3 = 6144;
                    }
                    ply_work.obj_work.user_timer = AppMain.ObjSpdUpSet( ply_work.obj_work.user_timer, 32, 1024 );
                }
                else
                {
                    if ( ply_work.gmk_work3 < -6144 )
                    {
                        ply_work.gmk_work3 = -6144;
                    }
                    ply_work.obj_work.user_timer = AppMain.ObjSpdUpSet( ply_work.obj_work.user_timer, -32, 1024 );
                }
            }
            else
            {
                if ( ply_work.act_state != 74 && ply_work.act_state != 75 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 74 );
                }
                if ( ply_work.obj_work.user_work < 3U )
                {
                    int user_work = (int)(ply_work.obj_work.user_work + 1U);
                    ply_work.obj_work.user_work = ( uint )user_work;
                    ply_work.obj_work.user_timer = -ply_work.obj_work.user_timer >> 1;
                    if ( ply_work.gmk_work3 < 0 )
                    {
                        ply_work.gmk_work3++;
                    }
                    else
                    {
                        ply_work.gmk_work3--;
                    }
                }
                else
                {
                    ply_work.player_flag |= 2U;
                }
            }
        }
        if ( ply_work.act_state == 74 )
        {
            ply_work.gmk_work2 = AppMain.ObjTimeCountDown( ply_work.gmk_work2 );
            if ( ply_work.gmk_work2 != 0 )
            {
                ply_work.gmk_work1 = ( int )( ( ushort )( ply_work.gmk_work1 + ply_work.gmk_work0 ) );
            }
            if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
            {
                AppMain.GmPlayerActionChange( ply_work, 75 );
                ply_work.obj_work.disp_flag |= 4U;
                ply_work.gmk_flag |= 1073741824U;
                ply_work.obj_work.vib_timer = ply_work.fall_timer;
            }
        }
        else if ( ( ply_work.gmk_flag & 1073741824U ) != 0U )
        {
            ply_work.gmk_work1 = ( int )( ( ushort )( ( int )( 32768 - ply_work.obj_work.dir.z ) - ply_work.gmk_work3 + ( int )( ( short )( AppMain.g_gm_main_system.pseudofall_dir - ply_work.obj_work.dir_fall ) ) ) );
            if ( ( ply_work.player_flag & 1U ) != 0U )
            {
                AppMain.GmPlySeqGmkInitTruckDangerRet( ply_work, ply_work.truck_obj );
            }
        }
        if ( ( ply_work.gmk_flag & 1073741824U ) == 0U && ply_work.act_state == 75 && ( ply_work.player_flag & 2U ) != 0U )
        {
            ply_work.gmk_flag |= 1073741824U;
        }
        AppMain.nnMakeUnitMatrix( ply_work.ex_obj_mtx_r );
        AppMain.nnTranslateMatrix( ply_work.ex_obj_mtx_r, ply_work.ex_obj_mtx_r, 0f, 5f, 9f );
        AppMain.nnRotateXMatrix( ply_work.ex_obj_mtx_r, ply_work.ex_obj_mtx_r, ply_work.gmk_work1 );
        AppMain.nnTranslateMatrix( ply_work.ex_obj_mtx_r, ply_work.ex_obj_mtx_r, -1f, -5f, -9f );
        float num;
        float num2;
        float num3;
        if ( ( ply_work.player_flag & 4U ) == 0U )
        {
            num = 0f;
            num2 = 8f;
            num3 = -5f;
        }
        else
        {
            num = 0f;
            num2 = 8f;
            num3 = 5f;
        }
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, -num, -num2, -num3 );
        AppMain.nnRotateXMatrix( nns_MATRIX, nns_MATRIX, ply_work.gmk_work3 );
        AppMain.nnRotateYMatrix( nns_MATRIX, nns_MATRIX, AppMain.MTM_MATH_ABS( ply_work.gmk_work3 ) >> 2 );
        AppMain.nnRotateZMatrix( nns_MATRIX, nns_MATRIX, AppMain.MTM_MATH_ABS( ply_work.gmk_work3 ) >> 2 );
        AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, num, num2, num3 );
        AppMain.nnMultiplyMatrix( ply_work.ex_obj_mtx_r, nns_MATRIX, ply_work.ex_obj_mtx_r );
    }

    // Token: 0x060008A7 RID: 2215 RVA: 0x0004E368 File Offset: 0x0004C568
    private static void gmPlySeqGmkMainTruckDangerRet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        ply_work.gmk_work2 = AppMain.ObjTimeCountUp( ply_work.gmk_work2 );
        if ( 73728 <= ply_work.gmk_work2 && ply_work.gmk_work2 <= 131072 )
        {
            ply_work.gmk_work1 += ply_work.gmk_work0;
            if ( ply_work.gmk_work0 < 0 )
            {
                if ( ply_work.gmk_work1 < 0 )
                {
                    ply_work.gmk_work1 = 0;
                }
            }
            else if ( ply_work.gmk_work1 > 0 )
            {
                ply_work.gmk_work1 = 0;
            }
        }
        if ( ( ply_work.player_flag & 2U ) != 0U )
        {
            ply_work.gmk_work3 = AppMain.ObjSpdDownSet( ply_work.gmk_work3, 1024 );
            if ( AppMain.MTM_MATH_ABS( ply_work.gmk_work3 ) == 0 )
            {
                ply_work.gmk_work3 = 0;
                ply_work.gmk_flag |= 2147483648U;
                AppMain.GmPlySeqChangeFw( ply_work );
                return;
            }
        }
        else if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            ply_work.gmk_work1 = 0;
            if ( ply_work.gmk_work3 == 0 )
            {
                ply_work.gmk_flag |= 2147483648U;
                AppMain.GmPlySeqChangeFw( ply_work );
                return;
            }
            ply_work.player_flag |= 2U;
            ply_work.gmk_flag &= 4293918719U;
            AppMain.GmPlayerActionChange( ply_work, 69 );
            ply_work.obj_work.disp_flag |= 4U;
        }
        AppMain.nnMakeUnitMatrix( ply_work.ex_obj_mtx_r );
        AppMain.nnTranslateMatrix( ply_work.ex_obj_mtx_r, ply_work.ex_obj_mtx_r, 0f, 5f, 9f );
        AppMain.nnRotateXMatrix( ply_work.ex_obj_mtx_r, ply_work.ex_obj_mtx_r, ( int )( ( ushort )ply_work.gmk_work1 ) );
        AppMain.nnTranslateMatrix( ply_work.ex_obj_mtx_r, ply_work.ex_obj_mtx_r, -1f, -5f, -9f );
        float num;
        float num2;
        float num3;
        if ( ( ply_work.player_flag & 4U ) == 0U )
        {
            num = 0f;
            num2 = 8f;
            num3 = -5f;
        }
        else
        {
            num = 0f;
            num2 = 8f;
            num3 = 5f;
        }
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, -num, -num2, -num3 );
        AppMain.nnRotateXMatrix( nns_MATRIX, nns_MATRIX, ply_work.gmk_work3 );
        AppMain.nnRotateZMatrix( nns_MATRIX, nns_MATRIX, AppMain.MTM_MATH_ABS( ply_work.gmk_work3 ) >> 2 );
        AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, num, num2, num3 );
        AppMain.nnMultiplyMatrix( ply_work.ex_obj_mtx_r, nns_MATRIX, ply_work.ex_obj_mtx_r );
    }
}
