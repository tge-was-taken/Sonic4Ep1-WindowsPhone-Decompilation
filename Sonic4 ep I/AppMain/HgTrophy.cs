using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000261 RID: 609
    // (Invoke) Token: 0x060023E8 RID: 9192
    public delegate bool HGF_TROPHY_ACQUIRE_CHECK_FUNC();

    // Token: 0x02000262 RID: 610
    public class HGS_TROPHY_CHECK_INFO
    {
        // Token: 0x060023EB RID: 9195 RVA: 0x00149E2C File Offset: 0x0014802C
        public HGS_TROPHY_CHECK_INFO( int trophy, uint trophy_id, AppMain.HGF_TROPHY_ACQUIRE_CHECK_FUNC acquire_check_func )
        {
            this.trophy_type = trophy;
            this.trophy_id = trophy_id;
            this.acquire_check_func = acquire_check_func;
        }

        // Token: 0x060023EC RID: 9196 RVA: 0x00149E49 File Offset: 0x00148049
        public HGS_TROPHY_CHECK_INFO()
        {
        }

        // Token: 0x04005901 RID: 22785
        public int trophy_type;

        // Token: 0x04005902 RID: 22786
        public uint trophy_id;

        // Token: 0x04005903 RID: 22787
        public AppMain.HGF_TROPHY_ACQUIRE_CHECK_FUNC acquire_check_func;
    }

    // Token: 0x02000263 RID: 611
    public class HGS_TROPHY_CHECK_TIMING_INFO
    {
        // Token: 0x060023ED RID: 9197 RVA: 0x00149E51 File Offset: 0x00148051
        public HGS_TROPHY_CHECK_TIMING_INFO( AppMain.HGS_TROPHY_CHECK_INFO[] tbl, int num )
        {
            this.check_info_tbl = tbl;
            this.num = num;
        }

        // Token: 0x060023EE RID: 9198 RVA: 0x00149E67 File Offset: 0x00148067
        public HGS_TROPHY_CHECK_TIMING_INFO()
        {
        }

        // Token: 0x04005904 RID: 22788
        public AppMain.HGS_TROPHY_CHECK_INFO[] check_info_tbl;

        // Token: 0x04005905 RID: 22789
        public int num;
    }

    // Token: 0x06000FA4 RID: 4004 RVA: 0x00088BAC File Offset: 0x00086DAC
    private static void HgTrophyTryAcquisition( int timing )
    {
        AppMain.HGS_TROPHY_CHECK_TIMING_INFO hgs_TROPHY_CHECK_TIMING_INFO = AppMain.hg_trophy_check_timing_info_tbl[timing];
        if ( AppMain.GsTrialIsTrial() )
        {
            return;
        }
        if ( AppMain.hgTrophyIsPlayDemo() )
        {
            return;
        }
        for ( int i = 0; i < hgs_TROPHY_CHECK_TIMING_INFO.num; i++ )
        {
            AppMain.HGS_TROPHY_CHECK_INFO hgs_TROPHY_CHECK_INFO = hgs_TROPHY_CHECK_TIMING_INFO.check_info_tbl[i];
            int trophy_type = hgs_TROPHY_CHECK_INFO.trophy_type;
            if ( trophy_type == 0 )
            {
                AppMain.hgTrophyTryAcquisitionNormal( hgs_TROPHY_CHECK_INFO );
            }
            else
            {
                AppMain.MTM_ASSERT( false );
            }
        }
    }

    // Token: 0x06000FA5 RID: 4005 RVA: 0x00088C04 File Offset: 0x00086E04
    private static void HgTrophyIncEnemyKillCount( AppMain.OBS_OBJECT_WORK ene_obj )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( AppMain.hgTrophyIsPlayDemo() )
        {
            return;
        }
        if ( ene_obj.obj_type != 2 )
        {
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)ene_obj;
        if ( gms_ENEMY_COM_WORK.eve_rec == null )
        {
            return;
        }
        if ( ( gms_ENEMY_COM_WORK.eve_rec.id != 0 && gms_ENEMY_COM_WORK.eve_rec.id <= 0 ) || gms_ENEMY_COM_WORK.eve_rec.id >= 39 )
        {
            return;
        }
        if ( gss_MAIN_SYS_INFO.ene_kill_count < 1000U )
        {
            gss_MAIN_SYS_INFO.ene_kill_count += 1U;
        }
        else
        {
            gss_MAIN_SYS_INFO.ene_kill_count = 1000U;
        }
        AppMain.HgTrophyTryAcquisition( 2 );
    }

    // Token: 0x06000FA6 RID: 4006 RVA: 0x00088C94 File Offset: 0x00086E94
    private static void HgTrophyIncPlayerDamageCount( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( AppMain.hgTrophyIsPlayDemo() )
        {
            return;
        }
        if ( AppMain.g_gm_main_system.ply_dmg_count < 1U )
        {
            AppMain.g_gm_main_system.ply_dmg_count += 1U;
            return;
        }
        AppMain.g_gm_main_system.ply_dmg_count = 1U;
    }

    // Token: 0x06000FA7 RID: 4007 RVA: 0x00088CCC File Offset: 0x00086ECC
    private static void HgTrophyIncFinalClearCount()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( gss_MAIN_SYS_INFO.final_clear_count < 2U )
        {
            gss_MAIN_SYS_INFO.final_clear_count += 1U;
            return;
        }
        gss_MAIN_SYS_INFO.final_clear_count = 2U;
    }

    // Token: 0x06000FA8 RID: 4008 RVA: 0x00088CFE File Offset: 0x00086EFE
    private static bool hgTrophyIsPlayDemo()
    {
        return AppMain.GsTrialIsTrial();
    }

    // Token: 0x06000FA9 RID: 4009 RVA: 0x00088D05 File Offset: 0x00086F05
    private static uint hgTrophyGetClearTime()
    {
        if ( AppMain.GsGetMainSysInfo().clear_time >= 35999 )
        {
            return 35999U;
        }
        return ( uint )AppMain.GsGetMainSysInfo().clear_time;
    }

    // Token: 0x06000FAA RID: 4010 RVA: 0x00088D28 File Offset: 0x00086F28
    private static void hgTrophyTryAcquisitionNormal( AppMain.HGS_TROPHY_CHECK_INFO check_info )
    {
        if ( AppMain.GsTrophyIsAcquired( check_info.trophy_id ) )
        {
            return;
        }
        if ( check_info.acquire_check_func() )
        {
            AppMain.GsTrophyUpdateAcquisition( check_info.trophy_id );
        }
    }

    // Token: 0x06000FAB RID: 4011 RVA: 0x00088D50 File Offset: 0x00086F50
    private static void hgTrophyTryAcquisitionAvatar( AppMain.HGS_TROPHY_CHECK_INFO check_info )
    {
        if ( AppMain.GsTrophyAvatarIsAcquired( check_info.trophy_id ) )
        {
            return;
        }
        if ( check_info.acquire_check_func() )
        {
            AppMain.GsTrophyAvatarUpdateAcquisition( check_info.trophy_id );
        }
    }

    // Token: 0x06000FAC RID: 4012 RVA: 0x00088D78 File Offset: 0x00086F78
    private static bool hgTrophyCheckAcquireStage11Clear()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return AppMain.GsGetMainSysInfo().stage_id == 0;
    }

    // Token: 0x06000FAD RID: 4013 RVA: 0x00088D9B File Offset: 0x00086F9B
    private static bool hgTrophyCheckAcquireDefeatBoss1()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( AppMain.GMM_MAIN_STAGE_IS_BOSS() )
        {
            return AppMain.g_gs_main_sys_info.stage_id == 3;
        }
        AppMain.MTM_ASSERT( "hgTrophy.cpp::hgTrophyCheckAcquireDefeatBoss() Error! Not supposed to be called in this stage\n" );
        return false;
    }

    // Token: 0x06000FAE RID: 4014 RVA: 0x00088DD2 File Offset: 0x00086FD2
    private static bool hgTrophyCheckAcquireDefeatBoss2()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( AppMain.GMM_MAIN_STAGE_IS_BOSS() )
        {
            return AppMain.g_gs_main_sys_info.stage_id == 7;
        }
        AppMain.MTM_ASSERT( "hgTrophy.cpp::hgTrophyCheckAcquireDefeatBoss() Error! Not supposed to be called in this stage\n" );
        return false;
    }

    // Token: 0x06000FAF RID: 4015 RVA: 0x00088E09 File Offset: 0x00087009
    private static bool hgTrophyCheckAcquireDefeatBoss3()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( AppMain.GMM_MAIN_STAGE_IS_BOSS() )
        {
            return AppMain.g_gs_main_sys_info.stage_id == 11;
        }
        AppMain.MTM_ASSERT( "hgTrophy.cpp::hgTrophyCheckAcquireDefeatBoss() Error! Not supposed to be called in this stage\n" );
        return false;
    }

    // Token: 0x06000FB0 RID: 4016 RVA: 0x00088E41 File Offset: 0x00087041
    private static bool hgTrophyCheckAcquireDefeatBoss4()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( AppMain.GMM_MAIN_STAGE_IS_BOSS() )
        {
            return AppMain.g_gs_main_sys_info.stage_id == 15;
        }
        AppMain.MTM_ASSERT( "hgTrophy.cpp::hgTrophyCheckAcquireDefeatBoss() Error! Not supposed to be called in this stage\n" );
        return false;
    }

    // Token: 0x06000FB1 RID: 4017 RVA: 0x00088E79 File Offset: 0x00087079
    private static bool hgTrophyCheckAcquireFirstChaosEmerald()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U;
    }

    // Token: 0x06000FB2 RID: 4018 RVA: 0x00088EA2 File Offset: 0x000870A2
    private static bool hgTrophyCheckAcquire1000EnemyKill()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return AppMain.GsGetMainSysInfo().ene_kill_count >= 1000U;
    }

    // Token: 0x06000FB3 RID: 4019 RVA: 0x00088ECC File Offset: 0x000870CC
    private static bool hgTrophyCheckAcquireSsonicInAllAct()
    {
        bool result = true;
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( AppMain.g_gm_gamedat_stage_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] != AppMain.GSE_MAIN_STAGE_TYPE.GSD_MAIN_STAGE_TYPE_ACT || AppMain.g_gs_main_sys_info.stage_id == 28 || !AppMain.GMM_MAIN_GOAL_AS_SUPER_SONIC() )
        {
            return false;
        }
        for ( uint num = 0U; num < 29U; num += 1U )
        {
            if ( num != 28U && AppMain.g_gm_gamedat_stage_type_tbl[( int )( ( UIntPtr )num )] == AppMain.GSE_MAIN_STAGE_TYPE.GSD_MAIN_STAGE_TYPE_ACT )
            {
                AppMain.MTM_ASSERT( num < 16U );
                if ( num == ( uint )AppMain.g_gs_main_sys_info.stage_id )
                {
                    if ( !AppMain.GMM_MAIN_GOAL_AS_SUPER_SONIC() )
                    {
                        result = false;
                    }
                }
                else if ( !AppMain.GsMainSysIsStageGoalAsSuperSonic( ( int )num ) )
                {
                    result = false;
                }
            }
        }
        return result;
    }

    // Token: 0x06000FB4 RID: 4020 RVA: 0x00088F5F File Offset: 0x0008715F
    private static bool hgTrophyCheckAcquireReachEnd()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 10 );
        return true;
    }

    // Token: 0x06000FB5 RID: 4021 RVA: 0x00088F78 File Offset: 0x00087178
    private static bool hgTrophyCheckAcquireUploadAllRecords()
    {
        bool result = true;
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 7 || AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        for ( uint num = 0U; num < 29U; num += 1U )
        {
            if ( num != 28U && !AppMain.GsMainSysIsStageTimeUploadOnce( ( int )num ) )
            {
                result = false;
                break;
            }
        }
        return result;
    }

    // Token: 0x06000FB6 RID: 4022 RVA: 0x00088FC8 File Offset: 0x000871C8
    private static bool hgTrophyCheckAcquireStageS1AllRings()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( AppMain.GsGetMainSysInfo().stage_id == 21 && ( AppMain.g_gm_main_system.game_flag & 196608U ) != 0U && AppMain.GsGetMainSysInfo().clear_ring >= AppMain.GmEventMgrGetRingNum() )
        {
            AppMain.MTM_ASSERT( AppMain.GsGetMainSysInfo().clear_ring == AppMain.GmEventMgrGetRingNum() );
            return true;
        }
        return false;
    }

    // Token: 0x06000FB7 RID: 4023 RVA: 0x00089031 File Offset: 0x00087231
    private static bool hgTrophyCheckAcquireStage100Rings()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return AppMain.GsGetMainSysInfo().clear_ring >= 120U && AppMain.GsGetMainSysInfo().stage_id == 12;
    }

    // Token: 0x06000FB8 RID: 4024 RVA: 0x00089064 File Offset: 0x00087264
    private static bool hgTrophyCheckAcquire99Challenge()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] >= 100U;
    }

    // Token: 0x06000FB9 RID: 4025 RVA: 0x0008908C File Offset: 0x0008728C
    private static bool hgTrophyCheckAcquireAllChaosEmeralds()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return ( AppMain.g_gm_main_system.game_flag & 65536U ) != 0U && ( AppMain.GsGetMainSysInfo().game_flag & 32U ) != 0U;
    }

    // Token: 0x06000FBA RID: 4026 RVA: 0x000890C4 File Offset: 0x000872C4
    private static bool hgTrophyCheckAcquireStage11ClearIn1Min()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        if ( gss_MAIN_SYS_INFO.stage_id == 0 )
        {
            if ( gss_MAIN_SYS_INFO.game_mode != 1 && ( gss_MAIN_SYS_INFO.game_flag & 256U ) != 0U )
            {
                return false;
            }
            ushort num = 0;
            ushort num2 = 0;
            ushort num3 = 0;
            AppMain.AkUtilFrame60ToTime( AppMain.hgTrophyGetClearTime(), ref num, ref num2, ref num3 );
            if ( num == 0 || ( num == 1 && num2 == 0 && num3 == 0 ) )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000FBB RID: 4027 RVA: 0x00089130 File Offset: 0x00087330
    private static bool hgTrophyCheckAcquireStageFClearNoDamage()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        return AppMain.GsGetMainSysInfo().stage_id == 16 && AppMain.g_gm_main_system.ply_dmg_count == 0U && ( AppMain.g_gm_main_system.game_flag & 67108864U ) == 0U;
    }

    // Token: 0x06000FBC RID: 4028 RVA: 0x00089180 File Offset: 0x00087380
    private static bool hgTrophyCheckAcquireStageEndingAllRings()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 9 );
        if ( AppMain.GsGetMainSysInfo().stage_id == 28 && AppMain.GsGetMainSysInfo().clear_ring >= AppMain.GmEventMgrGetRingNum() )
        {
            AppMain.MTM_ASSERT( AppMain.GsGetMainSysInfo().clear_ring == AppMain.GmEventMgrGetRingNum() );
            return true;
        }
        return false;
    }

    // Token: 0x06000FBD RID: 4029 RVA: 0x000891D8 File Offset: 0x000873D8
    private static bool hgTrophyCheckAcquireStageFClearAllEmeralds()
    {
        AppMain.MTM_ASSERT( AppMain.SyGetEvtInfo().cur_evt_id == 6 );
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        return gss_MAIN_SYS_INFO.stage_id == 16 && ( AppMain.GsGetMainSysInfo().game_flag & 32U ) != 0U && gss_MAIN_SYS_INFO.final_clear_count >= 2U;
    }
}