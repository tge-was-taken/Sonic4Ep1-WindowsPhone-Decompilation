using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001AAE RID: 6830 RVA: 0x000F312F File Offset: 0x000F132F
    private static void GmPlyEfctTrailSysInit()
    {
        if ( AppMain.gm_ply_efct_trail_sys_tcb == null )
        {
            AppMain.gm_ply_efct_trail_sys_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmPlyEfctTrailSysMain ), null, 0U, 0, 8448U, 3, null, "GM_PLY_EF_TRAIL" );
        }
    }

    // Token: 0x06001AAF RID: 6831 RVA: 0x000F315D File Offset: 0x000F135D
    private static void GmPlyEfctTrailSysExit()
    {
        if ( AppMain.gm_ply_efct_trail_sys_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_ply_efct_trail_sys_tcb );
            AppMain.gm_ply_efct_trail_sys_tcb = null;
        }
    }

    // Token: 0x06001AB0 RID: 6832 RVA: 0x000F3176 File Offset: 0x000F1376
    private static void GmPlyEfctCreateTrail( AppMain.GMS_PLAYER_WORK ply_work, int efct_type )
    {
    }

    // Token: 0x06001AB1 RID: 6833 RVA: 0x000F3178 File Offset: 0x000F1378
    private static void GmPlyEfctCreateBarrier( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 4);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctBarrierMain );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = 4U;
        AppMain.GmComEfctAddDispOffset( gms_EFFECT_3DES_WORK, 0, 0, 61440 );
        gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 5 );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctBarrierMain );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = 5U;
        AppMain.GmComEfctAddDispOffset( gms_EFFECT_3DES_WORK, 0, 0, 61440 );
        if ( ( ply_work.gmk_flag2 & 2U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.disp_flag |= 32U;
        }
    }

    // Token: 0x06001AB2 RID: 6834 RVA: 0x000F3240 File Offset: 0x000F1440
    private static void GmPlyEfctCreateInvincible( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.gmPlyEfctCreateInvincibleCircle( ply_work );
        AppMain.gmPlyEfctCreateInvincibleTail( ply_work );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_COM_WORK(), ply_work.obj_work, 0, "GM_PLY_INV_MGR");
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctInvincibleMgrMain );
    }

    // Token: 0x06001AB3 RID: 6835 RVA: 0x000F329C File Offset: 0x000F149C
    private static void GmPlyEfctCreateRollDash( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 147456U ) != 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 52 );
            AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, 1.5f, 5f, 16f );
            gms_EFFECT_3DES_WORK.obj_3des.ecb.drawObjState = 0U;
        }
        else
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 53 );
            AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, -1.5f, 5f, 16f );
            gms_EFFECT_3DES_WORK.obj_3des.ecb.drawObjState = 0U;
        }
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctRollDashMain );
    }

    // Token: 0x06001AB4 RID: 6836 RVA: 0x000F3350 File Offset: 0x000F1550
    private static void GmPlyEfctCreateSweat( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 93);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSweatMain );
        AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, -5f, -10f, 16f );
    }

    // Token: 0x06001AB5 RID: 6837 RVA: 0x000F339C File Offset: 0x000F159C
    private static void GmPlyEfctCreateRunDust( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AB6 RID: 6838 RVA: 0x000F339E File Offset: 0x000F159E
    private static void GmPlyEfctCreateDash1Dust( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AB7 RID: 6839 RVA: 0x000F33A0 File Offset: 0x000F15A0
    private static void GmPlyEfctCreateDash2Dust( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AB8 RID: 6840 RVA: 0x000F33A4 File Offset: 0x000F15A4
    private static void GmPlyEfctCreateDash2Impact( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 147456U ) != 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 51);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctDash2ImpactMain );
        AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, -8f, 16f, 0f );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.z = AppMain.FXM_FLOAT_TO_FX32( 16f );
    }

    // Token: 0x06001AB9 RID: 6841 RVA: 0x000F3420 File Offset: 0x000F1620
    private static void GmPlyEfctCreateSpinDust( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 2 && ( ply_work.player_flag & 67108864U ) != 0U && ( ply_work.obj_work.pos.y >> 12 ) - 4 >= ( int )AppMain.g_gm_main_system.water_level )
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( ply_work.obj_work, 2, 28 );
        }
        else
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 71 );
        }
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSpinDustMain );
        AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, -8f, 16f, 0f );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.z = AppMain.FXM_FLOAT_TO_FX32( 16f );
    }

    // Token: 0x06001ABA RID: 6842 RVA: 0x000F34D3 File Offset: 0x000F16D3
    private static void GmPlyEfctCreateSpinAddDust( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001ABB RID: 6843 RVA: 0x000F34D5 File Offset: 0x000F16D5
    private static void GmPlyEfctCreateSpinDashImpact( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001ABC RID: 6844 RVA: 0x000F34D7 File Offset: 0x000F16D7
    private static void GmPlyEfctCreateSpinDashDust( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001ABD RID: 6845 RVA: 0x000F34DC File Offset: 0x000F16DC
    private static object GmPlyEfctCreateSpinDashCircleBlur( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.efct_spin_dash_cir_blur != null && ( ply_work.efct_spin_dash_cir_blur.flag & 12U ) == 0U )
        {
            return null;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 82 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer = 82;
        }
        else
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 73 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer = 73;
        }
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSpinDashCircleBlurMain );
        if ( ( ply_work.player_flag & 131072U ) != 0U || AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, 0, 0, 0 );
        }
        else
        {
            AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, 0, 0, 0 );
        }
        gms_EFFECT_3DES_WORK.efct_com.obj_work.obj_3des.speed = ply_work.obj_work.obj_3d.speed[0];
        AppMain.mtTaskChangeTcbDestructor( gms_EFFECT_3DES_WORK.efct_com.obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmPlyEfctSpinDashBlurDest ) );
        ply_work.efct_spin_dash_cir_blur = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        return gms_EFFECT_3DES_WORK;
    }

    // Token: 0x06001ABE RID: 6846 RVA: 0x000F35F2 File Offset: 0x000F17F2
    private static object GmPlyEfctCreateSpinDashBlur( AppMain.GMS_PLAYER_WORK ply_work, uint type )
    {
        return null;
    }

    // Token: 0x06001ABF RID: 6847 RVA: 0x000F35F5 File Offset: 0x000F17F5
    private static void GmPlyEfctCreateBrakeImpact( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AC0 RID: 6848 RVA: 0x000F35F7 File Offset: 0x000F17F7
    private static void GmPlyEfctCreateBrakeDust( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AC1 RID: 6849 RVA: 0x000F35FC File Offset: 0x000F17FC
    private static void GmPlyEfctCreateJumpDust( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            return;
        }
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 41);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctJumpDustMain );
        AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, 0f, 16f, 16f );
    }

    // Token: 0x06001AC2 RID: 6850 RVA: 0x000F365F File Offset: 0x000F185F
    private static void GmPlyEfctCreateFootSmoke( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AC3 RID: 6851 RVA: 0x000F3664 File Offset: 0x000F1864
    private static void GmPlyEfctCreateSpray( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 76);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = ( int )AppMain.g_gm_main_system.water_level << 12;
    }

    // Token: 0x06001AC4 RID: 6852 RVA: 0x000F36A1 File Offset: 0x000F18A1
    private static void GmPlyEfctCreateBubble( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AC5 RID: 6853 RVA: 0x000F36A4 File Offset: 0x000F18A4
    private static void GmPlyEfctWaterCount( AppMain.GMS_PLAYER_WORK ply_work, uint no )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, (int)(24U + no));
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctWaterCountMain );
        gms_EFFECT_3DES_WORK.obj_3des.command_state = 10U;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer = 487424;
        AppMain.GmComEfctAddDispOffset( gms_EFFECT_3DES_WORK, 0, -65536, 1179648 );
    }

    // Token: 0x06001AC6 RID: 6854 RVA: 0x000F3710 File Offset: 0x000F1910
    private static void GmPlyEfctWaterDeath( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmEfctCmnEsCreate( ply_work.obj_work, 31 );
    }

    // Token: 0x06001AC7 RID: 6855 RVA: 0x000F3720 File Offset: 0x000F1920
    private static void GmPlyEfctCreateRunSpray( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.efct_run_spray != null || AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) < 4096 || ( ply_work.obj_work.move_flag & 1U ) == 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m ) >= 16384 )
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( ply_work.obj_work, 2, 30 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = 1U;
        }
        else
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( ply_work.obj_work, 2, 31 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = 0U;
        }
        gms_EFFECT_3DES_WORK.efct_com.obj_work.flag &= 4294966271U;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = ( int )AppMain.g_gm_main_system.water_level << 12;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctRunSprayMain );
        ply_work.efct_run_spray = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        AppMain.mtTaskChangeTcbDestructor( gms_EFFECT_3DES_WORK.efct_com.obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmPlyEfctRunSprayDest ) );
    }

    // Token: 0x06001AC8 RID: 6856 RVA: 0x000F3841 File Offset: 0x000F1A41
    private static void GmPlyEfctCreateHomingImpact( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06001AC9 RID: 6857 RVA: 0x000F3844 File Offset: 0x000F1A44
    private static void GmPlyEfctCreateHomingCursol( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.enemy_obj == null )
        {
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)ply_work.enemy_obj;
        if ( gms_ENEMY_COM_WORK.obj_work.obj_type != 2 && gms_ENEMY_COM_WORK.obj_work.obj_type != 3 )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(gms_ENEMY_COM_WORK.obj_work, 95);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctHomingCursolMain );
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer = obs_RECT_WORK.rect.left + obs_RECT_WORK.rect.right >> 1 << 12;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = ( uint )( ( uint )( obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1 ) << 12 );
        if ( ( gms_ENEMY_COM_WORK.obj_work.disp_flag & 1U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer = -gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer;
        }
        if ( ( gms_ENEMY_COM_WORK.obj_work.disp_flag & 2U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = ( uint )-gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work;
        }
        AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer, ( int )gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work, 524288 );
    }

    // Token: 0x06001ACA RID: 6858 RVA: 0x000F399C File Offset: 0x000F1B9C
    private static void GmPlyEfctCreateJumpDash( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = AppMain.nnArcTan2((double)(-(double)ply_work.obj_work.spd.y), (double)ply_work.obj_work.spd.x);
        AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 36);
        AppMain.GmComEfctAddDispRotation( efct_work, 0, 0, ( ushort )num );
    }

    // Token: 0x06001ACB RID: 6859 RVA: 0x000F39EA File Offset: 0x000F1BEA
    private static object GmPlyEfctCreateSpinStartBlur( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return null;
    }

    // Token: 0x06001ACC RID: 6860 RVA: 0x000F39ED File Offset: 0x000F1BED
    private static object GmPlyEfctCreateSpinJumpBlur( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return null;
    }

    // Token: 0x06001ACD RID: 6861 RVA: 0x000F39F0 File Offset: 0x000F1BF0
    private static void GmPlyEfctCreateSuperStart( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 85);
        AppMain.GmComEfctSetDispOffset( efct_work, 0, -12288, 0 );
    }

    // Token: 0x06001ACE RID: 6862 RVA: 0x000F3A18 File Offset: 0x000F1C18
    private static void GmPlyEfctCreateSuperEnd( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 80);
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag &= 4294966271U;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = AppMain.FXM_FLOAT_TO_FX32( ply_work.truck_mtx_ply_mtn_pos.M03 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = AppMain.FXM_FLOAT_TO_FX32( -ply_work.truck_mtx_ply_mtn_pos.M13 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = AppMain.FXM_FLOAT_TO_FX32( ply_work.truck_mtx_ply_mtn_pos.M23 );
        }
    }

    // Token: 0x06001ACF RID: 6863 RVA: 0x000F3AD0 File Offset: 0x000F1CD0
    private static void GmPlyEfctCreateSuperAuraDeco( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) == 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 0);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSuperAuraMain );
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag &= 4294966271U;
        }
    }

    // Token: 0x06001AD0 RID: 6864 RVA: 0x000F3B40 File Offset: 0x000F1D40
    private static void GmPlyEfctCreateSuperAuraBase( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) == 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 1);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSuperAuraMain );
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag &= 4294966271U;
        }
    }

    // Token: 0x06001AD1 RID: 6865 RVA: 0x000F3BB0 File Offset: 0x000F1DB0
    private static void GmPlyEfctCreateSuperAuraSpin( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) == 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 2);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSuperAuraSpinMain );
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag &= 4294966271U;
        }
    }

    // Token: 0x06001AD2 RID: 6866 RVA: 0x000F3C20 File Offset: 0x000F1E20
    private static void GmPlyEfctCreateSuperAuraDash( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) == 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 3);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSuperAuraDashMain );
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag &= 4294966271U;
        }
    }

    // Token: 0x06001AD3 RID: 6867 RVA: 0x000F3C90 File Offset: 0x000F1E90
    private static void GmPlyEfctCreateSteamPipe( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int efct_cmn_idx = 90;
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            efct_cmn_idx = 91;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, efct_cmn_idx);
        AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, 0, 0, 40960 );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctSteamPipeMain );
    }

    // Token: 0x06001AD4 RID: 6868 RVA: 0x000F3CE8 File Offset: 0x000F1EE8
    private static void gmPlyEfctTrailSysMain( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.ObjObjectPauseCheck( 0U ) == 0U )
        {
            AppMain.amTrailEFUpdate( 1 );
        }
        if ( AppMain.g_obj.glb_camera_id != -1 && AppMain.ObjCameraGet( AppMain.g_obj.glb_camera_id ) != null )
        {
            AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
            AppMain.SNNS_VECTOR snns_VECTOR2 = default(AppMain.SNNS_VECTOR);
            AppMain.SNNS_MATRIX snns_MATRIX = default(AppMain.SNNS_MATRIX);
            AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
            AppMain.SNNS_RGB snns_RGB = new AppMain.SNNS_RGB(1f, 1f, 1f);
            AppMain.nnMakeUnitMatrix( ref snns_MATRIX );
            AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type, 0U );
            AppMain.ObjCameraDispPosGet( AppMain.g_obj.glb_camera_id, out snns_VECTOR );
            AppMain.amVectorSet( ref snns_VECTOR2, -snns_MATRIX.M03, -snns_MATRIX.M13, -snns_MATRIX.M23 );
            AppMain.nnAddVector( ref snns_VECTOR, ref snns_VECTOR2, ref snns_VECTOR );
            AppMain.amEffectSetCameraPos( ref snns_VECTOR );
            AppMain.nnSetPrimitive3DMaterial( ref nns_RGBA, ref snns_RGB, 1f );
            AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(18);
            AppMain.NNS_TEXLIST texlist = (AppMain.NNS_TEXLIST)obs_DATA_WORK.pData;
            AppMain.amTrailEFDraw( 1, texlist, 0U );
        }
    }

    // Token: 0x06001AD5 RID: 6869 RVA: 0x000F3E08 File Offset: 0x000F2008
    private static void gmPlyEfctBarrierMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( ( gms_PLAYER_WORK.player_flag & 268435456U ) == 0U )
        {
            obj_work.flag |= 8U;
            if ( obj_work.user_work == 4U )
            {
                AppMain.gmPlyEfctCreateBarrierLost( gms_PLAYER_WORK );
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        }
        if ( ( gms_PLAYER_WORK.gmk_flag2 & 2U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
            return;
        }
        obj_work.disp_flag &= 4294967263U;
    }

    // Token: 0x06001AD6 RID: 6870 RVA: 0x000F3E88 File Offset: 0x000F2088
    private static void gmPlyEfctCreateBarrierLost( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.gmk_flag2 & 2U ) != 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 6);
        AppMain.GmComEfctAddDispOffset( efct_work, 0, 0, 61440 );
    }

    // Token: 0x06001AD7 RID: 6871 RVA: 0x000F3EBC File Offset: 0x000F20BC
    private static void gmPlyEfctInvincibleMgrMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.genocide_timer == 0 )
        {
            obj_work.flag |= 4U;
            return;
        }
        obj_work.user_timer++;
        if ( obj_work.user_timer >= 15 )
        {
            obj_work.user_timer = 0;
            AppMain.gmPlyEfctCreateInvincibleTail( ( AppMain.GMS_PLAYER_WORK )obj_work.parent_obj );
        }
        int user_work = (int)(obj_work.user_work + 1U);
        obj_work.user_work = ( uint )user_work;
        if ( obj_work.user_work >= 70U )
        {
            obj_work.user_work = 0U;
            AppMain.gmPlyEfctCreateInvincibleCircle( ( AppMain.GMS_PLAYER_WORK )obj_work.parent_obj );
        }
    }

    // Token: 0x06001AD8 RID: 6872 RVA: 0x000F3F4C File Offset: 0x000F214C
    private static void gmPlyEfctCreateInvincibleCircle( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 42);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctInvincibleCircleMain );
        AppMain.GmComEfctAddDispOffsetF( gms_EFFECT_3DES_WORK, 0f, 0f, 16f );
        if ( ply_work != null && ( ply_work.gmk_flag2 & 4U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.disp_flag |= 32U;
        }
    }

    // Token: 0x06001AD9 RID: 6873 RVA: 0x000F3FBE File Offset: 0x000F21BE
    private static void gmPlyEfctInvincibleCircleMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEfctCmnUpdateInvincibleMainPart( ( AppMain.GMS_EFFECT_3DES_WORK )obj_work );
        AppMain.gmPlyEfctInvincibleMain( obj_work );
    }

    // Token: 0x06001ADA RID: 6874 RVA: 0x000F3FD4 File Offset: 0x000F21D4
    private static void gmPlyEfctCreateInvincibleTail( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(ply_work.obj_work, 43);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlyEfctInvincibleTailMain );
        AppMain.GmComEfctAddDispOffsetF( gms_EFFECT_3DES_WORK, 0f, 0f, 16f );
        if ( ply_work != null && ( ply_work.gmk_flag2 & 4U ) != 0U )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.disp_flag |= 32U;
        }
    }

    // Token: 0x06001ADB RID: 6875 RVA: 0x000F4046 File Offset: 0x000F2246
    private static void gmPlyEfctInvincibleTailMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEfctCmnUpdateInvincibleSubPart( ( AppMain.GMS_EFFECT_3DES_WORK )obj_work, obj_work.parent_obj );
        AppMain.gmPlyEfctInvincibleMain( obj_work );
    }

    // Token: 0x06001ADC RID: 6876 RVA: 0x000F4060 File Offset: 0x000F2260
    private static void gmPlyEfctInvincibleMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.genocide_timer == 0 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        if ( ( gms_PLAYER_WORK.gmk_flag2 & 4U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
        }
        else
        {
            obj_work.disp_flag &= 4294967263U;
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06001ADD RID: 6877 RVA: 0x000F40CC File Offset: 0x000F22CC
    private static void gmPlyEfctRollDashMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.act_state != 22 )
        {
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
            return;
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001ADE RID: 6878 RVA: 0x000F4118 File Offset: 0x000F2318
    private static void gmPlyEfctSweatMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( 13 > gms_PLAYER_WORK.seq_state || gms_PLAYER_WORK.seq_state > 15 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06001ADF RID: 6879 RVA: 0x000F4164 File Offset: 0x000F2364
    private static void gmPlyEfctRunDustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.act_state != 20 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE0 RID: 6880 RVA: 0x000F41A8 File Offset: 0x000F23A8
    private static void gmPlyEfctDash1DustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.act_state != 21 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE1 RID: 6881 RVA: 0x000F41EC File Offset: 0x000F23EC
    private static void gmPlyEfctDash2DustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.act_state != 22 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE2 RID: 6882 RVA: 0x000F4230 File Offset: 0x000F2430
    private static void gmPlyEfctDash2ImpactMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.act_state != 22 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE3 RID: 6883 RVA: 0x000F4274 File Offset: 0x000F2474
    private static void gmPlyEfctSpinDustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.seq_state != 12 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE4 RID: 6884 RVA: 0x000F42B8 File Offset: 0x000F24B8
    private static void gmPlyEfctSpinAddDustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.seq_state != 11 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE5 RID: 6885 RVA: 0x000F42FC File Offset: 0x000F24FC
    private static void gmPlyEfctSpinDashImpactMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer == 0 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        else if ( gms_PLAYER_WORK.seq_state != 10 )
        {
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE6 RID: 6886 RVA: 0x000F4378 File Offset: 0x000F2578
    private static void gmPlyEfctSpinDashDustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.seq_state != 10 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AE7 RID: 6887 RVA: 0x000F43BC File Offset: 0x000F25BC
    private static void gmPlyEfctSpinDashCircleBlurMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.ofst.Assign( gms_PLAYER_WORK.obj_work.ofst );
        }
        obj_work.obj_3des.speed = gms_PLAYER_WORK.obj_work.obj_3d.speed[0];
        obj_work.disp_flag &= 4294967263U;
        obj_work.disp_flag |= ( gms_PLAYER_WORK.obj_work.disp_flag & 32U );
        if ( gms_PLAYER_WORK.seq_state != 10 && gms_PLAYER_WORK.seq_state != 34 && gms_PLAYER_WORK.seq_state != 44 && gms_PLAYER_WORK.seq_state != 37 && !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        if ( ( obj_work.flag & 12U ) == 0U && gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer == 82 && ( gms_PLAYER_WORK.player_flag & 16384U ) == 0U )
        {
            obj_work.flag |= 8U;
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK2 = (AppMain.GMS_EFFECT_3DES_WORK)AppMain.GmPlyEfctCreateSpinDashCircleBlur(gms_PLAYER_WORK);
            if ( gms_EFFECT_3DES_WORK2 != null )
            {
                float speed = AppMain.amEffectGetUnitFrame();
                AppMain.amEffectSetUnitTime( gms_PLAYER_WORK.obj_work.obj_3d.frame[0], 60 );
                AppMain.amEffectUpdate( gms_EFFECT_3DES_WORK2.obj_3des.ecb );
                AppMain.amEffectSetUnitTime( speed, 60 );
                gms_EFFECT_3DES_WORK2.obj_3des.speed = gms_PLAYER_WORK.obj_work.obj_3d.speed[0];
            }
        }
    }

    // Token: 0x06001AE8 RID: 6888 RVA: 0x000F4538 File Offset: 0x000F2738
    private static void gmPlyEfctSpinDashBlurMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.ofst.Assign( gms_PLAYER_WORK.obj_work.ofst );
        }
        obj_work.obj_3des.speed = gms_PLAYER_WORK.obj_work.obj_3d.speed[0];
        if ( gms_PLAYER_WORK.seq_state != 10 && gms_PLAYER_WORK.seq_state != 34 && gms_PLAYER_WORK.seq_state != 37 && gms_PLAYER_WORK.seq_state != 44 && gms_PLAYER_WORK.seq_state != 51 && gms_PLAYER_WORK.seq_state != 52 && gms_PLAYER_WORK.seq_state != 53 && gms_PLAYER_WORK.seq_state != 48 && gms_PLAYER_WORK.seq_state != 57 && !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        if ( ( obj_work.flag & 12U ) == 0U && ( gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer == 83 || gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer == 81 ) && ( gms_PLAYER_WORK.player_flag & 16384U ) == 0U )
        {
            obj_work.flag |= 8U;
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK2 = (AppMain.GMS_EFFECT_3DES_WORK)AppMain.GmPlyEfctCreateSpinDashBlur(gms_PLAYER_WORK, (gms_EFFECT_3DES_WORK.efct_com.obj_work.user_timer == 81) ? 0U : 1U);
            if ( gms_EFFECT_3DES_WORK2 != null )
            {
                float speed = AppMain.amEffectGetUnitFrame();
                AppMain.amEffectSetUnitTime( gms_PLAYER_WORK.obj_work.obj_3d.frame[0], 60 );
                AppMain.amEffectUpdate( gms_EFFECT_3DES_WORK2.obj_3des.ecb );
                AppMain.amEffectSetUnitTime( speed, 60 );
                gms_EFFECT_3DES_WORK2.obj_3des.speed = gms_PLAYER_WORK.obj_work.obj_3d.speed[0];
            }
        }
    }

    // Token: 0x06001AE9 RID: 6889 RVA: 0x000F46EC File Offset: 0x000F28EC
    private static void gmPlyEfctSpinDashBlurDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK;
        if ( obs_OBJECT_WORK.parent_obj != null && obs_OBJECT_WORK.parent_obj.obj_type == 1 )
        {
            gms_PLAYER_WORK = ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK.parent_obj;
        }
        else
        {
            gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )];
        }
        if ( gms_PLAYER_WORK.efct_spin_dash_blur == obs_OBJECT_WORK )
        {
            gms_PLAYER_WORK.efct_spin_dash_blur = null;
        }
        if ( gms_PLAYER_WORK.efct_spin_dash_cir_blur == obs_OBJECT_WORK )
        {
            gms_PLAYER_WORK.efct_spin_dash_cir_blur = null;
        }
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06001AEA RID: 6890 RVA: 0x000F4758 File Offset: 0x000F2958
    private static void gmPlyEfctBrakeDustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.seq_state != 9 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AEB RID: 6891 RVA: 0x000F479C File Offset: 0x000F299C
    private static void gmPlyEfctJumpDustMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.seq_state != 17 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
    }

    // Token: 0x06001AEC RID: 6892 RVA: 0x000F47E0 File Offset: 0x000F29E0
    private static void gmPlyEfctBubbleMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        bool flag = true;
        if ( AppMain.GmMainIsWaterLevel() && obj_work.pos.y >> 12 > ( int )( AppMain.g_gm_main_system.water_level + 8 ) )
        {
            flag = false;
            obj_work.spd.y = obj_work.spd.y + -64;
            if ( obj_work.spd.y < -65536 )
            {
                obj_work.spd.y = -65536;
            }
            if ( obj_work.pos.y + obj_work.spd.y < ( ( int )AppMain.g_gm_main_system.water_level << 12 ) + 32768 )
            {
                obj_work.spd.y = ( ( int )AppMain.g_gm_main_system.water_level << 12 ) + 32768 - obj_work.pos.y;
            }
            obj_work.user_timer = AppMain.ObjTimeCountUp( obj_work.user_timer );
            if ( ( obj_work.user_timer >> 12 & 3 ) != 0 )
            {
                obj_work.spd.x = ( int )( ( AppMain.mtMathRand() & 4095 ) - 2048 );
            }
        }
        if ( flag )
        {
            obj_work.flag |= 4U;
            return;
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06001AED RID: 6893 RVA: 0x000F48F8 File Offset: 0x000F2AF8
    private static void gmPlyEfctWaterCountMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( obj_work.user_timer == 0 || ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || ( AppMain.GmMainIsWaterLevel() && gms_PLAYER_WORK.obj_work.pos.y >> 12 <= ( int )AppMain.g_gm_main_system.water_level ) || !AppMain.GmMainIsWaterLevel() || gms_PLAYER_WORK.time_air - gms_PLAYER_WORK.water_timer > 2703360 )
        {
            obj_work.flag |= 4U;
            return;
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06001AEE RID: 6894 RVA: 0x000F4990 File Offset: 0x000F2B90
    private static void gmPlyEfctRunSprayMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        if ( parent_obj != null )
        {
            bool flag = false;
            bool flag2 = false;
            if ( obj_work.user_work == 0U )
            {
                if ( AppMain.MTM_MATH_ABS( parent_obj.spd_m ) < 4096 )
                {
                    flag = true;
                }
                else if ( AppMain.MTM_MATH_ABS( parent_obj.spd_m ) >= 16384 )
                {
                    flag = true;
                }
            }
            else if ( AppMain.MTM_MATH_ABS( parent_obj.spd_m ) < 16384 )
            {
                flag = true;
            }
            if ( ( parent_obj.move_flag & 1U ) == 0U || ( parent_obj.pos.y >> 12 ) - 4 >= ( int )AppMain.g_gm_main_system.water_level )
            {
                flag2 = true;
            }
            if ( flag || flag2 )
            {
                AppMain.ObjDrawKillAction3DES( obj_work );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
                if ( !flag2 && AppMain.MTM_MATH_ABS( parent_obj.spd_m ) >= 4096 )
                {
                    ( ( AppMain.GMS_PLAYER_WORK )parent_obj ).efct_run_spray = null;
                    AppMain.GmPlyEfctCreateRunSpray( ( AppMain.GMS_PLAYER_WORK )parent_obj );
                }
            }
            obj_work.pos.x = parent_obj.pos.x;
            obj_work.pos.y = ( int )AppMain.g_gm_main_system.water_level << 12;
            obj_work.disp_flag &= 4294967292U;
            obj_work.disp_flag |= ( parent_obj.disp_flag & 3U );
        }
    }

    // Token: 0x06001AEF RID: 6895 RVA: 0x000F4ABC File Offset: 0x000F2CBC
    private static void gmPlyEfctRunSprayDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK;
        if ( obs_OBJECT_WORK.parent_obj != null && obs_OBJECT_WORK.parent_obj.obj_type == 1 )
        {
            gms_PLAYER_WORK = ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK.parent_obj;
        }
        else
        {
            gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )];
        }
        if ( gms_PLAYER_WORK.efct_run_spray == obs_OBJECT_WORK )
        {
            gms_PLAYER_WORK.efct_run_spray = null;
        }
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06001AF0 RID: 6896 RVA: 0x000F4B18 File Offset: 0x000F2D18
    private static void gmPlyEfctHomingImpact01Main( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.seq_state != 19 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06001AF1 RID: 6897 RVA: 0x000F4B5C File Offset: 0x000F2D5C
    private static void gmPlyEfctHomingCursolMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.enemy_obj != obj_work.parent_obj || !AppMain.GmPlySeqCheckAcceptHoming( gms_PLAYER_WORK ) )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(obj_work.parent_obj, 94);
            if ( ( obj_work.parent_obj.flag & 12U ) != 0U )
            {
                gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_obj = null;
            }
            AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, obj_work.user_timer, ( int )Convert.ToUInt32( obj_work.user_work ), 131072 );
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06001AF2 RID: 6898 RVA: 0x000F4C00 File Offset: 0x000F2E00
    private static void gmPlyEfctSpinStartBlurMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        gms_EFFECT_3DES_WORK.obj_3des.speed += 0.05f;
        if ( gms_EFFECT_3DES_WORK.obj_3des.ecb != null )
        {
            gms_EFFECT_3DES_WORK.obj_3des.ecb.transparency = AppMain.FX_Div( obj_work.user_timer, 61440 ) * 256 >> 12;
            if ( gms_EFFECT_3DES_WORK.obj_3des.ecb.transparency > 256 )
            {
                gms_EFFECT_3DES_WORK.obj_3des.ecb.transparency = 256;
            }
        }
        if ( obj_work.user_timer == 0 || gms_PLAYER_WORK.act_state != 28 )
        {
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
        }
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.ofst.Assign( gms_PLAYER_WORK.obj_work.ofst );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        if ( ( obj_work.flag & 12U ) == 0U && gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work == 84U && ( gms_PLAYER_WORK.player_flag & 16384U ) == 0U )
        {
            obj_work.flag |= 8U;
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK2 = (AppMain.GMS_EFFECT_3DES_WORK)AppMain.GmPlyEfctCreateSpinStartBlur(gms_PLAYER_WORK);
            if ( gms_EFFECT_3DES_WORK2 != null )
            {
                float speed = AppMain.amEffectGetUnitFrame();
                AppMain.amEffectSetUnitTime( gms_PLAYER_WORK.obj_work.obj_3d.frame[0], 60 );
                AppMain.amEffectUpdate( gms_EFFECT_3DES_WORK2.obj_3des.ecb );
                AppMain.amEffectSetUnitTime( speed, 60 );
                gms_EFFECT_3DES_WORK2.obj_3des.speed = gms_EFFECT_3DES_WORK.obj_3des.speed;
                gms_EFFECT_3DES_WORK2.efct_com.obj_work.user_timer = obj_work.user_timer;
            }
        }
    }

    // Token: 0x06001AF3 RID: 6899 RVA: 0x000F4DB8 File Offset: 0x000F2FB8
    private static void gmPlyEfctSpinStartBlurDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK;
        if ( obs_OBJECT_WORK.parent_obj != null && obs_OBJECT_WORK.parent_obj.obj_type == 1 )
        {
            gms_PLAYER_WORK = ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK.parent_obj;
        }
        else
        {
            gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )];
        }
        if ( gms_PLAYER_WORK.efct_spin_start_blur == obs_OBJECT_WORK )
        {
            gms_PLAYER_WORK.efct_spin_start_blur = null;
        }
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06001AF4 RID: 6900 RVA: 0x000F4E14 File Offset: 0x000F3014
    private static void gmPlyEfctSpinJumpBlurMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.ofst.Assign( gms_PLAYER_WORK.obj_work.ofst );
        }
        if ( ( ( gms_PLAYER_WORK.player_flag & 131072U ) != 0U && gms_PLAYER_WORK.seq_state != 0 && gms_PLAYER_WORK.seq_state != 1 && gms_PLAYER_WORK.seq_state != 17 && gms_PLAYER_WORK.seq_state != 16 && gms_PLAYER_WORK.seq_state != 21 && gms_PLAYER_WORK.seq_state != 19 && gms_PLAYER_WORK.seq_state != 66 && gms_PLAYER_WORK.seq_state != 45 && gms_PLAYER_WORK.seq_state != 46 && gms_PLAYER_WORK.seq_state != 49 && gms_PLAYER_WORK.seq_state != 50 && gms_PLAYER_WORK.seq_state != 47 ) || ( ( gms_PLAYER_WORK.player_flag & 131072U ) == 0U && ( ( gms_PLAYER_WORK.seq_state != 17 && gms_PLAYER_WORK.seq_state != 66 && gms_PLAYER_WORK.seq_state != 45 && gms_PLAYER_WORK.seq_state != 46 && gms_PLAYER_WORK.seq_state != 49 && gms_PLAYER_WORK.seq_state != 50 && gms_PLAYER_WORK.seq_state != 42 && gms_PLAYER_WORK.seq_state != 47 ) || ( gms_PLAYER_WORK.act_state != 39 && gms_PLAYER_WORK.act_state != 26 && gms_PLAYER_WORK.act_state != 67 && gms_PLAYER_WORK.act_state != 27 ) ) && !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() ) )
        {
            obj_work.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
            AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
            return;
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            obj_work.dir.z = ( ushort )( obj_work.dir.z + gms_PLAYER_WORK.obj_work.dir_fall );
        }
        if ( ( obj_work.flag & 12U ) == 0U && gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work == 81U && ( gms_PLAYER_WORK.player_flag & 16384U ) == 0U )
        {
            obj_work.flag |= 8U;
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK2 = (AppMain.GMS_EFFECT_3DES_WORK)AppMain.GmPlyEfctCreateSpinJumpBlur(gms_PLAYER_WORK);
            if ( gms_EFFECT_3DES_WORK2 != null )
            {
                float speed = AppMain.amEffectGetUnitFrame();
                AppMain.amEffectSetUnitTime( gms_PLAYER_WORK.obj_work.obj_3d.frame[0], 60 );
                AppMain.amEffectUpdate( gms_EFFECT_3DES_WORK2.obj_3des.ecb );
                AppMain.amEffectSetUnitTime( speed, 60 );
                gms_EFFECT_3DES_WORK2.obj_3des.speed = gms_PLAYER_WORK.obj_work.obj_3d.speed[0];
            }
        }
        else
        {
            int num = AppMain.FXM_FLOAT_TO_FX32(gms_PLAYER_WORK.obj_work.obj_3d.frame[0]);
            if ( ( ( long )obj_work.user_timer & -4096 ) != ( ( long )num & -4096 ) )
            {
                int num2 = (int)((((long)num & -4096)) - ((long)obj_work.user_timer & -4096));
                num2 %= 81920;
                if ( num2 < 0 )
                {
                    num2 += 81920;
                    num2 %= 81920;
                }
                float speed2 = AppMain.amEffectGetUnitFrame();
                AppMain.amEffectSetUnitTime( AppMain.FXM_FX32_TO_FLOAT( num2 ), 60 );
                AppMain.amEffectUpdate( gms_EFFECT_3DES_WORK.obj_3des.ecb );
                AppMain.amEffectSetUnitTime( speed2, 60 );
                obj_work.user_timer = num;
            }
        }
        obj_work.user_timer = AppMain.ObjTimeCountUp( obj_work.user_timer );
        if ( obj_work.user_timer >= 81920 )
        {
            obj_work.user_timer -= 81920;
        }
    }

    // Token: 0x06001AF5 RID: 6901 RVA: 0x000F5144 File Offset: 0x000F3344
    private static void gmPlyEfctSpinJumpBlurPosAdj( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK efct_work = (AppMain.GMS_EFFECT_3DES_WORK)ply_work.efct_spin_jump_blur;
        if ( ( ply_work.player_flag & 131072U ) != 0U || ply_work.act_state == 26 || AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.GmComEfctSetDispOffset( efct_work, 0, 4096, 0 );
            return;
        }
        AppMain.GmComEfctSetDispOffset( efct_work, 0, -20480, 0 );
    }

    // Token: 0x06001AF6 RID: 6902 RVA: 0x000F5198 File Offset: 0x000F3398
    private static void gmPlyEfctSpinJumpBlurDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK;
        if ( obs_OBJECT_WORK.parent_obj != null && obs_OBJECT_WORK.parent_obj.obj_type == 1 )
        {
            gms_PLAYER_WORK = ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK.parent_obj;
        }
        else
        {
            gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )];
        }
        if ( gms_PLAYER_WORK.efct_spin_jump_blur == obs_OBJECT_WORK )
        {
            gms_PLAYER_WORK.efct_spin_jump_blur = null;
        }
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06001AF7 RID: 6903 RVA: 0x000F51F4 File Offset: 0x000F33F4
    private static void gmPlyEfctSuperAuraMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK == null || ( gms_PLAYER_WORK.player_flag & 16384U ) == 0U || ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || gms_PLAYER_WORK.act_state == 84 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
            AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
            return;
        }
        if ( ( gms_PLAYER_WORK.gmk_flag2 & 128U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
        }
        else
        {
            obj_work.disp_flag &= 4294967263U;
        }
        if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
        {
            obj_work.pos.x = AppMain.FXM_FLOAT_TO_FX32( gms_PLAYER_WORK.truck_mtx_ply_mtn_pos.M03 );
            obj_work.pos.y = AppMain.FXM_FLOAT_TO_FX32( -gms_PLAYER_WORK.truck_mtx_ply_mtn_pos.M13 );
            obj_work.pos.z = AppMain.FXM_FLOAT_TO_FX32( gms_PLAYER_WORK.truck_mtx_ply_mtn_pos.M23 );
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        if ( AppMain.GMM_MAIN_STAGE_IS_ENDING() )
        {
            obj_work.scale.Assign( gms_PLAYER_WORK.obj_work.scale );
        }
    }

    // Token: 0x06001AF8 RID: 6904 RVA: 0x000F5308 File Offset: 0x000F3508
    private static void gmPlyEfctSuperAuraSpinMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK == null || ( ( ( ( gms_PLAYER_WORK.player_flag & 131072U ) != 0U && gms_PLAYER_WORK.seq_state != 0 && gms_PLAYER_WORK.seq_state != 1 && gms_PLAYER_WORK.seq_state != 17 && gms_PLAYER_WORK.seq_state != 16 && gms_PLAYER_WORK.seq_state != 21 && gms_PLAYER_WORK.seq_state != 19 && gms_PLAYER_WORK.seq_state != 45 && gms_PLAYER_WORK.seq_state != 46 && gms_PLAYER_WORK.seq_state != 47 ) || ( ( gms_PLAYER_WORK.player_flag & 131072U ) == 0U && ( ( gms_PLAYER_WORK.seq_state != 17 && gms_PLAYER_WORK.seq_state != 45 && gms_PLAYER_WORK.seq_state != 46 && gms_PLAYER_WORK.seq_state != 47 ) || ( gms_PLAYER_WORK.act_state != 39 && gms_PLAYER_WORK.act_state != 26 && gms_PLAYER_WORK.act_state != 27 ) ) ) ) && !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() ) )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
            AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
            return;
        }
        if ( ( gms_PLAYER_WORK.gmk_flag2 & 128U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
        }
        else
        {
            obj_work.disp_flag &= 4294967263U;
        }
        AppMain.gmPlyEfctSuperAuraMain( obj_work );
    }

    // Token: 0x06001AF9 RID: 6905 RVA: 0x000F543C File Offset: 0x000F363C
    private static void gmPlyEfctSuperAuraDashMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.act_state != 22 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ );
            AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
            return;
        }
        if ( ( gms_PLAYER_WORK.gmk_flag2 & 128U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
        }
        else
        {
            obj_work.disp_flag &= 4294967263U;
        }
        AppMain.gmPlyEfctSuperAuraMain( obj_work );
    }

    // Token: 0x06001AFA RID: 6906 RVA: 0x000F54B8 File Offset: 0x000F36B8
    private static void gmPlyEfctSteamPipeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.parent_obj;
        if ( gms_PLAYER_WORK.obj_work.spd.x != 0 )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        }
    }
}