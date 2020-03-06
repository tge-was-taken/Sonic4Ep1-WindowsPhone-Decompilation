using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000044 RID: 68
    public class GMS_BOSS5_EFCT_GENERAL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001DB2 RID: 7602 RVA: 0x001386BC File Offset: 0x001368BC
        public GMS_BOSS5_EFCT_GENERAL_WORK()
        {
            this.efct_3des = new AppMain.GMS_EFFECT_3DES_WORK( this );
        }

        // Token: 0x06001DB3 RID: 7603 RVA: 0x001386E6 File Offset: 0x001368E6
        public static explicit operator AppMain.GMS_EFFECT_COM_WORK( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK p )
        {
            return p.efct_3des.efct_com;
        }

        // Token: 0x06001DB4 RID: 7604 RVA: 0x001386F3 File Offset: 0x001368F3
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_3des.efct_com.obj_work;
        }

        // Token: 0x06001DB5 RID: 7605 RVA: 0x00138705 File Offset: 0x00136905
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK work )
        {
            return work.efct_3des.efct_com.obj_work;
        }

        // Token: 0x04004869 RID: 18537
        public readonly AppMain.GMS_EFFECT_3DES_WORK efct_3des;

        // Token: 0x0400486A RID: 18538
        public readonly AppMain.NNS_MATRIX ofst_mtx = new AppMain.NNS_MATRIX();

        // Token: 0x0400486B RID: 18539
        public uint flag;

        // Token: 0x0400486C RID: 18540
        public uint user_flag;

        // Token: 0x0400486D RID: 18541
        public uint user_work;

        // Token: 0x0400486E RID: 18542
        public int ref_node_snm_id;

        // Token: 0x0400486F RID: 18543
        public uint timer;

        // Token: 0x04004870 RID: 18544
        public float ratio_timer;

        // Token: 0x04004871 RID: 18545
        public readonly AppMain.GMS_BOSS5_1SHOT_TIMER se_timer = new AppMain.GMS_BOSS5_1SHOT_TIMER();

        // Token: 0x04004872 RID: 18546
        public uint se_cnt;

        // Token: 0x04004873 RID: 18547
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x02000045 RID: 69
    public class GMS_BOSS5_EFCT_DATA_INFO
    {
        // Token: 0x06001DB6 RID: 7606 RVA: 0x00138718 File Offset: 0x00136918
        public GMS_BOSS5_EFCT_DATA_INFO( int z, int a, int b, int c, int d, int e, int f, int g, int h )
        {
            this.use_model = z;
            this.ame_arc_idx = a;
            this.ame_dwork_no = b;
            this.tex_amb_arc_idx = c;
            this.tex_amb_dwork_no = d;
            this.tex_list_dwork_no = e;
            this.model_arc_idx = f;
            this.model_dwork_no = g;
            this.object_dwork_no = h;
        }

        // Token: 0x04004874 RID: 18548
        public int use_model;

        // Token: 0x04004875 RID: 18549
        public int ame_arc_idx;

        // Token: 0x04004876 RID: 18550
        public int ame_dwork_no;

        // Token: 0x04004877 RID: 18551
        public int tex_amb_arc_idx;

        // Token: 0x04004878 RID: 18552
        public int tex_amb_dwork_no;

        // Token: 0x04004879 RID: 18553
        public int tex_list_dwork_no;

        // Token: 0x0400487A RID: 18554
        public int model_arc_idx;

        // Token: 0x0400487B RID: 18555
        public int model_dwork_no;

        // Token: 0x0400487C RID: 18556
        public int object_dwork_no;
    }

    // Token: 0x060000B0 RID: 176 RVA: 0x00008FE8 File Offset: 0x000071E8
    public static void GmBoss5EfctBuild()
    {
        for ( int i = 0; i < 27; i++ )
        {
            AppMain.GMS_BOSS5_EFCT_DATA_INFO gms_BOSS5_EFCT_DATA_INFO = AppMain.gm_boss5_efct_data_info_tbl[i];
            AppMain.OBS_DATA_WORK model_dwork = null;
            AppMain.OBS_DATA_WORK object_dwork = null;
            if ( gms_BOSS5_EFCT_DATA_INFO.use_model != 0 )
            {
                model_dwork = AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.model_dwork_no );
                object_dwork = AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.object_dwork_no );
            }
            AppMain.GmEfctBossBuildSingleDataReg( gms_BOSS5_EFCT_DATA_INFO.tex_amb_arc_idx, AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.tex_amb_dwork_no ), AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.tex_list_dwork_no ), gms_BOSS5_EFCT_DATA_INFO.model_arc_idx, model_dwork, object_dwork, AppMain.g_gm_gamedat_enemy_arc );
        }
    }

    // Token: 0x060000B1 RID: 177 RVA: 0x0000905C File Offset: 0x0000725C
    public static void GmBoss5EfctFlush()
    {
        AppMain.GmEfctBossFlushSingleDataInit();
    }

    // Token: 0x060000B2 RID: 178 RVA: 0x00009063 File Offset: 0x00007263
    public static void GmBoss5EfctTryStartLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 2048U ) == 0U )
        {
            AppMain.GmSoundPlaySE( "FinalBoss11", body_work.se_hnd_leakage );
            AppMain.gmBoss5EfctCreateLeakage( body_work );
            body_work.flag |= 2048U;
        }
    }

    // Token: 0x060000B3 RID: 179 RVA: 0x0000909B File Offset: 0x0000729B
    public static void GmBoss5EfctEndLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GmBoss5EfctEndLeakage( body_work, 0 );
    }

    // Token: 0x060000B4 RID: 180 RVA: 0x000090A4 File Offset: 0x000072A4
    public static void GmBoss5EfctEndLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work, int no_vanish )
    {
        if ( ( body_work.flag & 2048U ) != 0U )
        {
            AppMain.GsSoundStopSeHandle( body_work.se_hnd_leakage, 30 );
        }
        body_work.flag &= 4294965247U;
    }

    // Token: 0x060000B5 RID: 181 RVA: 0x000090D3 File Offset: 0x000072D3
    public static void GmBoss5EfctStartPrelimLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag |= 1048576U;
        AppMain.gmBoss5EfctCreatePrelimLeakage( body_work );
    }

    // Token: 0x060000B6 RID: 182 RVA: 0x000090ED File Offset: 0x000072ED
    public static void GmBoss5EfctEndPrelimLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4293918719U;
    }

    // Token: 0x060000B7 RID: 183 RVA: 0x00009101 File Offset: 0x00007301
    public static void GmBoss5EfctCreateWalkStepSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work, int leg_type )
    {
    }

    // Token: 0x060000B8 RID: 184 RVA: 0x00009103 File Offset: 0x00007303
    public static void GmBoss5EfctCreateRunStepSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work, int leg_type )
    {
    }

    // Token: 0x060000B9 RID: 185 RVA: 0x0000910C File Offset: 0x0000730C
    public static void GmBoss5EfctCreateBerserkStampSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work, int leg_type, uint spawn_delay )
    {
        AppMain.GMS_EFFECT_COM_WORK work = (AppMain.GMS_EFFECT_COM_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 9, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id = body_work.leg_snm_reg_ids[leg_type];
        obs_OBJECT_WORK.disp_flag |= 4128U;
        gms_BOSS5_EFCT_GENERAL_WORK.timer = spawn_delay;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctBerserkStampSmokeProcWaitStart );
    }

    // Token: 0x060000BA RID: 186 RVA: 0x00009198 File Offset: 0x00007398
    public static void GmBoss5EfctCreateCrashLandingSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 10, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS5_EFCT_GENERAL_WORK);
        obs_OBJECT_WORK.pos.x = AppMain.GMM_BS_OBJ( body_work ).pos.x;
        obs_OBJECT_WORK.pos.y = body_work.ground_v_pos;
        obs_OBJECT_WORK.pos.z = AppMain.GMM_BS_OBJ( body_work ).pos.z + 262144;
    }

    // Token: 0x060000BB RID: 187 RVA: 0x00009238 File Offset: 0x00007438
    public static void GmBoss5EfctCreateBreakingGlass( AppMain.OBS_OBJECT_WORK parent_obj )
    {
        int num = AppMain.ObjViewOutCheck(parent_obj.pos.x, parent_obj.pos.y, 0, 0, (short)-(AppMain.OBD_OBJ_CLIP_LCD_Y / 2), 0, (short)(AppMain.OBD_OBJ_CLIP_LCD_Y / 2));
        if ( num != 0 )
        {
            return;
        }
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(parent_obj, 11, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS5_EFCT_GENERAL_WORK);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + -131072;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
        obs_OBJECT_WORK3.pos.z = obs_OBJECT_WORK3.pos.z + 262144;
    }

    // Token: 0x060000BC RID: 188 RVA: 0x000092E0 File Offset: 0x000074E0
    public static void GmBoss5EfctStartJet( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag |= 16384U;
        AppMain.gmBoss5EfctCreateJet( body_work );
    }

    // Token: 0x060000BD RID: 189 RVA: 0x000092FA File Offset: 0x000074FA
    public static void GmBoss5EfctEndJet( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4294950911U;
    }

    // Token: 0x060000BE RID: 190 RVA: 0x0000930E File Offset: 0x0000750E
    public static void GmBoss5EfctStartJetSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag |= 32768U;
        AppMain.gmBoss5EfctCreateJetSmoke( body_work );
    }

    // Token: 0x060000BF RID: 191 RVA: 0x00009328 File Offset: 0x00007528
    public static void GmBoss5EfctEndJetSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4294934527U;
    }

    // Token: 0x060000C0 RID: 192 RVA: 0x0000933C File Offset: 0x0000753C
    public static void GmBoss5EfctTryStartRocketLeakage( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( ( rkt_work.flag & 4U ) == 0U )
        {
            AppMain.gmBoss5EfctCreateRocketLeakage( rkt_work );
            rkt_work.flag |= 4U;
        }
    }

    // Token: 0x060000C1 RID: 193 RVA: 0x0000935C File Offset: 0x0000755C
    public static void GmBoss5EfctEndRocketLeakage( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.flag &= 4294967291U;
    }

    // Token: 0x060000C2 RID: 194 RVA: 0x0000936D File Offset: 0x0000756D
    public static void GmBoss5EfctCreateRocketLaunch( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
    }

    // Token: 0x060000C3 RID: 195 RVA: 0x00009378 File Offset: 0x00007578
    public static void GmBoss5EfctCreateRocketDock( AppMain.GMS_BOSS5_BODY_WORK body_work, int rkt_type )
    {
        AppMain.GMS_EFFECT_COM_WORK work = (AppMain.GMS_EFFECT_COM_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 15, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        float x;
        if ( rkt_type == 0 )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id = body_work.armpt_snm_reg_ids[0][2];
            x = 2f;
        }
        else
        {
            gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id = body_work.armpt_snm_reg_ids[1][2];
            x = -2f;
        }
        AppMain.nnMakeTranslateMatrix( gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx, x, 0f, 0f );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctRocketDockProcMain );
    }

    // Token: 0x060000C4 RID: 196 RVA: 0x0000941C File Offset: 0x0000761C
    public static void GmBoss5EfctStartRocketJet( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( ( rkt_work.flag & 16U ) == 0U )
        {
            AppMain.gmBoss5EfctCreateRocketJet( rkt_work, 0 );
            rkt_work.flag |= 16U;
        }
    }

    // Token: 0x060000C5 RID: 197 RVA: 0x0000943F File Offset: 0x0000763F
    public static void GmBoss5EfctEndRocketJet( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.flag &= 4294967279U;
    }

    // Token: 0x060000C6 RID: 198 RVA: 0x00009450 File Offset: 0x00007650
    public static void GmBoss5EfctStartRocketJetReverse( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( ( rkt_work.flag & 32U ) == 0U )
        {
            AppMain.gmBoss5EfctCreateRocketJet( rkt_work, 1 );
            rkt_work.flag |= 32U;
        }
    }

    // Token: 0x060000C7 RID: 199 RVA: 0x00009473 File Offset: 0x00007673
    public static void GmBoss5EfctEndRocketJetReverse( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.flag &= 4294967263U;
    }

    // Token: 0x060000C8 RID: 200 RVA: 0x00009484 File Offset: 0x00007684
    public static void GmBoss5EfctCreateRocketLandingShockwave( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
    }

    // Token: 0x060000C9 RID: 201 RVA: 0x00009490 File Offset: 0x00007690
    public static void GmBoss5EfctCreateLandingShockwave( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 19, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 262144;
        AppMain.GmBsCmnSetEfctAtkVsPly( ( AppMain.GMS_EFFECT_COM_WORK )obs_OBJECT_WORK, 128 );
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.ObjRectWorkSet( gms_EFFECT_COM_WORK.rect_work[1], -88, -32, 88, 32 );
        gms_EFFECT_COM_WORK.rect_work[1].flag &= 4294965247U;
        gms_BOSS5_EFCT_GENERAL_WORK.timer = 8U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctLandingShockwaveProcMain );
    }

    // Token: 0x060000CA RID: 202 RVA: 0x00009560 File Offset: 0x00007760
    public static void GmBoss5EfctCreateStrikeShockwave( AppMain.GMS_BOSS5_BODY_WORK body_work, uint spawn_delay )
    {
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 20, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        AppMain.GmBsCmnSetEfctAtkVsPly( ( AppMain.GMS_EFFECT_COM_WORK )obs_OBJECT_WORK, 64 );
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.ObjRectWorkSet( gms_EFFECT_COM_WORK.rect_work[1], -64, -64, 64, 32 );
        gms_EFFECT_COM_WORK.rect_work[1].flag &= 4294965247U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.disp_flag |= 4128U;
        gms_BOSS5_EFCT_GENERAL_WORK.timer = spawn_delay;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctStrikeShockwaveProcWaitStart );
    }

    // Token: 0x060000CB RID: 203 RVA: 0x0000962F File Offset: 0x0000782F
    public static void GmBoss5EfctTargetCursorInit( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5EfctCreateTargetCursorStart( body_work );
    }

    // Token: 0x060000CC RID: 204 RVA: 0x00009637 File Offset: 0x00007837
    public static void GmBoss5EfctCrashCursorInit( AppMain.GMS_BOSS5_BODY_WORK body_work, int pos_x, uint duration_time )
    {
        AppMain.gmBoss5EfctCreateCrashCursorStart( body_work, pos_x, duration_time );
    }

    // Token: 0x060000CD RID: 205 RVA: 0x00009644 File Offset: 0x00007844
    public static void GmBoss5EfctCreateVulcanFire( AppMain.GMS_BOSS5_TURRET_WORK trt_work, AppMain.VecFx32 pos, int angle )
    {
        AppMain.UNREFERENCED_PARAMETER( trt_work );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(trt_work), 14);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
        obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )angle ) );
        AppMain.GmEffect3DESAddDispRotation( gms_EFFECT_3DES_WORK, ( short )AppMain.AKM_DEGtoA32( 90 ), 0, 0 );
        obs_OBJECT_WORK.pos.Assign( pos );
        AppMain.GmSoundPlaySE( "FinalBoss14" );
    }

    // Token: 0x060000CE RID: 206 RVA: 0x000096A8 File Offset: 0x000078A8
    public static void GmBoss5EfctCreateVulcanBullet( AppMain.GMS_BOSS5_TURRET_WORK trt_work, AppMain.VecFx32 pos, int angle, int spd )
    {
        AppMain.UNREFERENCED_PARAMETER( trt_work );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(trt_work), 15);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
        AppMain.GmBsCmnSetEfctAtkVsPly( gms_EFFECT_3DES_WORK.efct_com, 16 );
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_EFFECT_3DES_WORK.efct_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -8, -8, 8, 8 );
        obs_RECT_WORK.flag |= 4U;
        obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )angle ) );
        AppMain.GmEffect3DESAddDispRotation( gms_EFFECT_3DES_WORK, ( short )AppMain.AKM_DEGtoA32( -90 ), 0, 0 );
        obs_OBJECT_WORK.pos.Assign( pos );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 262144;
        obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( spd, AppMain.FX_F32_TO_FX32( AppMain.nnCos( angle ) ) );
        obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( spd, AppMain.FX_F32_TO_FX32( AppMain.nnSin( angle ) ) );
        obs_OBJECT_WORK.spd.z = 0;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctVulcanBulletProcMain );
    }

    // Token: 0x060000CF RID: 207 RVA: 0x000097B4 File Offset: 0x000079B4
    public static void GmBoss5EfctCreateSmallExplosion( int pos_x, int pos_y, int pos_z )
    {
        AppMain.GMS_EFFECT_3DES_WORK work = AppMain.GmEfctCmnEsCreate(null, 7);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = pos_y;
        obs_OBJECT_WORK.pos.z = pos_z;
    }

    // Token: 0x060000D0 RID: 208 RVA: 0x000097F4 File Offset: 0x000079F4
    public static void GmBoss5EfctCreateBigExplosion( int pos_x, int pos_y, int pos_z )
    {
        AppMain.GMS_EFFECT_3DES_WORK work = AppMain.GmEfctCmnEsCreate(null, 8);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = pos_y;
        obs_OBJECT_WORK.pos.z = pos_z;
    }

    // Token: 0x060000D1 RID: 209 RVA: 0x00009834 File Offset: 0x00007A34
    public static void GmBoss5EfctCreateFragments( int pos_x, int pos_y, int pos_z )
    {
        AppMain.GMS_EFFECT_3DES_WORK work = AppMain.GmEfctBossCmnEsCreate(null, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = pos_y;
        obs_OBJECT_WORK.pos.z = pos_z;
    }

    // Token: 0x060000D2 RID: 210 RVA: 0x00009874 File Offset: 0x00007A74
    public static void GmBoss5EfctCreateDamage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK work = AppMain.GmEfctBossCmnEsCreate(null, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK.pos.x = body_work.part_obj_core.pos.x;
        obs_OBJECT_WORK.pos.y = body_work.part_obj_core.pos.y;
        obs_OBJECT_WORK.pos.z = body_work.part_obj_core.pos.z + 262144;
    }

    // Token: 0x060000D3 RID: 211 RVA: 0x000098E7 File Offset: 0x00007AE7
    public static void GmBoss5EfctStartRocketSmoke( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.flag |= 64U;
        AppMain.gmBoss5EfctCreateRocketSmoke( rkt_work );
    }

    // Token: 0x060000D4 RID: 212 RVA: 0x000098FE File Offset: 0x00007AFE
    public static void GmBoss5EfctEndRocketSmoke( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.flag &= 4294967231U;
    }

    // Token: 0x060000D5 RID: 213 RVA: 0x00009910 File Offset: 0x00007B10
    public static void GmBoss5EfctBreakdownSmokesInit( AppMain.GMS_BOSS5_BODY_WORK body_work, uint duration_time )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(AppMain.GMM_BS_OBJ(body_work), 3U);
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
            AppMain.GmEffect3DESChangeBase( gms_EFFECT_3DES_WORK, 1U, ( uint )( ( ulong )gms_EFFECT_3DES_WORK.saved_init_flag & 18446744073709551613UL ) );
            AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, AppMain.gm_boss5_efct_breakdown_smoke_disp_ofst_tbl[( int )( ( UIntPtr )num )][0], AppMain.gm_boss5_efct_breakdown_smoke_disp_ofst_tbl[( int )( ( UIntPtr )num )][1], AppMain.gm_boss5_efct_breakdown_smoke_disp_ofst_tbl[( int )( ( UIntPtr )num )][2] );
            AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, AppMain.gm_boss5_efct_breakdown_smoke_disp_rot_tbl[( int )( ( UIntPtr )num )][0], AppMain.gm_boss5_efct_breakdown_smoke_disp_rot_tbl[( int )( ( UIntPtr )num )][1], AppMain.gm_boss5_efct_breakdown_smoke_disp_rot_tbl[( int )( ( UIntPtr )num )][2] );
            obs_OBJECT_WORK.user_timer = ( int )duration_time;
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctBreakdownSmokeProcLoop );
        }
    }

    // Token: 0x060000D6 RID: 214 RVA: 0x000099B8 File Offset: 0x00007BB8
    public static void GmBoss5EfctBodySmallSmokesInit( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        for ( uint num = 0U; num < 3U; num += 1U )
        {
            AppMain.gmBoss5EfctCreateBodySmallSmoke( body_work, num );
        }
    }

    // Token: 0x060000D7 RID: 215 RVA: 0x000099D8 File Offset: 0x00007BD8
    public static void GmBoss5EfctBerserkSteamInit( AppMain.GMS_BOSS5_BODY_WORK body_work, uint count )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            AppMain.gmBoss5EfctCreateBerserkSteam( body_work, count, num );
        }
    }

    // Token: 0x060000D8 RID: 216 RVA: 0x000099F9 File Offset: 0x00007BF9
    public static void GmBoss5EfctStartEggSweat( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        egg_work.flag |= AppMain.GMD_BOSS5_EGG_FLAG_SWEAT_ACTIVE;
        AppMain.gmBoss5EfctCreateEggSweat( egg_work );
    }

    // Token: 0x060000D9 RID: 217 RVA: 0x00009A13 File Offset: 0x00007C13
    public static void GmBoss5EfctEndEggSweat( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        egg_work.flag &= ~AppMain.GMD_BOSS5_EGG_FLAG_SWEAT_ACTIVE;
    }

    // Token: 0x060000DA RID: 218 RVA: 0x00009A28 File Offset: 0x00007C28
    public static void GmBoss5EfctCreateRocketRollSpark( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(rkt_work), 48);
        obs_OBJECT_WORK.pos.y = ( ( AppMain.GMS_BOSS5_BODY_WORK )AppMain.GMM_BS_OBJ( rkt_work ).parent_obj ).ground_v_pos;
        obs_OBJECT_WORK.dir.z = AppMain.GMD_BOSS5_EFCT_ROCKET_ROLLING_SPARK_DIR_Z;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
    }

    // Token: 0x060000DB RID: 219 RVA: 0x00009A96 File Offset: 0x00007C96
    public static AppMain.GMS_EFFECT_3DES_WORK gmBoss5EfctEsCreate( AppMain.OBS_OBJECT_WORK parent_obj, int efct_idx )
    {
        return AppMain.gmBoss5EfctEsCreate( parent_obj, efct_idx, () => new AppMain.GMS_EFFECT_3DES_WORK() );
    }

    // Token: 0x060000DC RID: 220 RVA: 0x00009ABC File Offset: 0x00007CBC
    public static AppMain.GMS_EFFECT_3DES_WORK gmBoss5EfctEsCreate( AppMain.OBS_OBJECT_WORK parent_obj, int efct_idx, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.GMS_EFFECT_CREATE_PARAM gms_EFFECT_CREATE_PARAM = AppMain.gm_boss5_efct_create_param_tbl[efct_idx];
        AppMain.GMS_BOSS5_EFCT_DATA_INFO gms_BOSS5_EFCT_DATA_INFO = AppMain.gm_boss5_efct_data_info_tbl[efct_idx];
        AppMain.OBS_DATA_WORK model_dwork;
        AppMain.OBS_DATA_WORK object_dwork;
        if ( gms_EFFECT_CREATE_PARAM.model_idx != -1 )
        {
            model_dwork = AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.model_dwork_no );
            object_dwork = AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.object_dwork_no );
        }
        else
        {
            model_dwork = null;
            object_dwork = null;
        }
        return AppMain.GmEffect3dESCreateByParam( gms_EFFECT_CREATE_PARAM, parent_obj, AppMain.g_gm_gamedat_enemy_arc, AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.ame_dwork_no ), AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.tex_amb_dwork_no ), AppMain.ObjDataGet( gms_BOSS5_EFCT_DATA_INFO.tex_list_dwork_no ), model_dwork, object_dwork, work_size );
    }

    // Token: 0x060000DD RID: 221 RVA: 0x00009B3C File Offset: 0x00007D3C
    public static void gmBoss5EfctCreateLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK obj = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 7, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMM_BS_OBJ( obj ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctLeakagePartProcMain );
    }

    // Token: 0x060000DE RID: 222 RVA: 0x00009B90 File Offset: 0x00007D90
    public static void gmBoss5EfctLeakagePartProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        obj_work.pos.z = obj_work.pos.z + 327680;
        if ( ( gms_BOSS5_BODY_WORK.flag & 2048U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctLeakageProcFade );
        }
    }

    // Token: 0x060000DF RID: 223 RVA: 0x00009C0A File Offset: 0x00007E0A
    public static void gmBoss5EfctLeakageProcFade( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000E0 RID: 224 RVA: 0x00009C2C File Offset: 0x00007E2C
    public static void gmBoss5EfctCreatePrelimLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK obj = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 7, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMM_BS_OBJ( obj ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctPrelimLeakageProcLoop );
    }

    // Token: 0x060000E1 RID: 225 RVA: 0x00009C80 File Offset: 0x00007E80
    public static void gmBoss5EfctPrelimLeakageProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        obj_work.pos.z = obj_work.pos.z + 327680;
        if ( ( gms_BOSS5_BODY_WORK.flag & 1048576U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctPrelimLeakageProcFade );
        }
    }

    // Token: 0x060000E2 RID: 226 RVA: 0x00009CFA File Offset: 0x00007EFA
    public static void gmBoss5EfctPrelimLeakageProcFade( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000E3 RID: 227 RVA: 0x00009D14 File Offset: 0x00007F14
    public static void gmBoss5EfctBerserkStampSmokeProcWaitStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
            return;
        }
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id);
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obj_work.pos.y = gms_BOSS5_BODY_WORK.ground_v_pos;
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
        obj_work.pos.z = 65536;
        obj_work.disp_flag &= 4294963167U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
    }

    // Token: 0x060000E4 RID: 228 RVA: 0x00009DD8 File Offset: 0x00007FD8
    public static void gmBoss5EfctCreateJet( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int ref_node_snm_id;
        if ( ( AppMain.GMM_BS_OBJ( body_work ).disp_flag & 1U ) != 0U )
        {
            ref_node_snm_id = body_work.nozzle_snm_reg_ids[0];
        }
        else
        {
            ref_node_snm_id = body_work.nozzle_snm_reg_ids[1];
        }
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 12, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)gms_BOSS5_EFCT_GENERAL_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS5_EFCT_GENERAL_WORK);
        obs_OBJECT_WORK.obj_3des.ecb.drawObjState = 0U;
        gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id = ref_node_snm_id;
        AppMain.GmBsCmnSetEfctAtkVsPly( ( AppMain.GMS_EFFECT_COM_WORK )obs_OBJECT_WORK, 16 );
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.ObjRectWorkSet( gms_EFFECT_COM_WORK.rect_work[1], -8, 0, 8, 88 );
        gms_EFFECT_COM_WORK.rect_work[1].flag |= 2048U;
        gms_BOSS5_EFCT_GENERAL_WORK.timer = 65U;
        AppMain.GmBoss5Init1ShotTimer( gms_BOSS5_EFCT_GENERAL_WORK.se_timer, 50U );
        AppMain.GMM_BS_OBJ( gms_BOSS5_EFCT_GENERAL_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctJetProcMain );
    }

    // Token: 0x060000E5 RID: 229 RVA: 0x00009ED4 File Offset: 0x000080D4
    public static void gmBoss5EfctJetProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        if ( AppMain.GmBoss5Update1ShotTimer( gms_BOSS5_EFCT_GENERAL_WORK.se_timer ) != 0 )
        {
            AppMain.GmSoundPlaySE( "FinalBoss04" );
        }
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
        }
        else
        {
            AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)obj_work;
            gms_EFFECT_COM_WORK.rect_work[1].flag &= 4294965247U;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        if ( ( gms_BOSS5_BODY_WORK.flag & 16384U ) == 0U && ( gms_BOSS5_EFCT_GENERAL_WORK.flag & 1U ) == 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.flag |= 1U;
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000E6 RID: 230 RVA: 0x00009FB4 File Offset: 0x000081B4
    public static void gmBoss5EfctCreateJetSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 13, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS5_EFCT_GENERAL_WORK);
        int snm_reg_id;
        if ( ( AppMain.GMM_BS_OBJ( body_work ).disp_flag & 1U ) != 0U )
        {
            snm_reg_id = body_work.nozzle_snm_reg_ids[0];
        }
        else
        {
            snm_reg_id = body_work.nozzle_snm_reg_ids[1];
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, snm_reg_id);
        obs_OBJECT_WORK.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obs_OBJECT_WORK.pos.y = body_work.ground_v_pos;
        obs_OBJECT_WORK.pos.z = AppMain.GMM_BS_OBJ( body_work ).pos.z;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctJetSmokeProcMain );
    }

    // Token: 0x060000E7 RID: 231 RVA: 0x0000A084 File Offset: 0x00008284
    public static void gmBoss5EfctJetSmokeProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        if ( ( gms_BOSS5_BODY_WORK.flag & 32768U ) == 0U && ( gms_BOSS5_EFCT_GENERAL_WORK.flag & 1U ) == 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.flag |= 1U;
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000E8 RID: 232 RVA: 0x0000A0F0 File Offset: 0x000082F0
    public static void gmBoss5EfctCreateRocketLeakage( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(rkt_work), 14, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.nnMakeTranslateMatrix( gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx, -7f, 0f, 0f );
        gms_BOSS5_EFCT_GENERAL_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        AppMain.mtTaskChangeTcbDestructor( ( ( AppMain.OBS_OBJECT_WORK )gms_BOSS5_EFCT_GENERAL_WORK ).tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss5EfctRocketLeakageExit ) );
        AppMain.GmSoundPlaySE( "FinalBoss11", gms_BOSS5_EFCT_GENERAL_WORK.se_handle );
        AppMain.GMM_BS_OBJ( gms_BOSS5_EFCT_GENERAL_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctRocketLeakageProcMain );
    }

    // Token: 0x060000E9 RID: 233 RVA: 0x0000A198 File Offset: 0x00008398
    public static void gmBoss5EfctRocketLeakageExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GsSoundFreeSeHandle( gms_BOSS5_EFCT_GENERAL_WORK.se_handle );
        AppMain.GmEffectDefaultExit( tcb );
    }

    // Token: 0x060000EA RID: 234 RVA: 0x0000A1C4 File Offset: 0x000083C4
    public static void gmBoss5EfctRocketLeakageProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_ROCKET_WORK.snm_work, gms_BOSS5_ROCKET_WORK.drill_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_ROCKET_WORK.pivot_prev_pos, gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx );
        obj_work.pos.z = obj_work.pos.z + 262144;
        if ( ( gms_BOSS5_ROCKET_WORK.flag & 4U ) == 0U && ( gms_BOSS5_EFCT_GENERAL_WORK.flag & 1U ) == 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.flag |= 1U;
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GsSoundStopSeHandle( gms_BOSS5_EFCT_GENERAL_WORK.se_handle );
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000EB RID: 235 RVA: 0x0000A270 File Offset: 0x00008470
    public static void gmBoss5EfctRocketDockProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_EFCT_GENERAL_WORK.ref_node_snm_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos, gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx );
        obj_work.pos.z = obj_work.pos.z + 65536;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000EC RID: 236 RVA: 0x0000A2F0 File Offset: 0x000084F0
    public static void gmBoss5EfctCreateRocketJet( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int is_rev_jet )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(rkt_work), 16, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        if ( is_rev_jet != 0 )
        {
            AppMain.nnMakeTranslateMatrix( gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx, 4f, 0f, 0f );
            AppMain.nnRotateYMatrix( gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx, gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx, AppMain.AKM_DEGtoA32( 180 ) );
            gms_BOSS5_EFCT_GENERAL_WORK.user_flag |= 1U;
        }
        else
        {
            AppMain.nnMakeTranslateMatrix( gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx, -6f, 0f, 0f );
        }
        AppMain.GMM_BS_OBJ( gms_BOSS5_EFCT_GENERAL_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctRocketJetProcMain );
    }

    // Token: 0x060000ED RID: 237 RVA: 0x0000A3A8 File Offset: 0x000085A8
    public static void gmBoss5EfctRocketJetProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        int num = 0;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_ROCKET_WORK.snm_work, gms_BOSS5_ROCKET_WORK.drill_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_ROCKET_WORK.pivot_prev_pos, gms_BOSS5_EFCT_GENERAL_WORK.ofst_mtx );
        obj_work.pos.z = obj_work.pos.z + 32768;
        if ( ( gms_BOSS5_EFCT_GENERAL_WORK.user_flag & 1U ) != 0U )
        {
            if ( ( gms_BOSS5_ROCKET_WORK.flag & 32U ) == 0U )
            {
                num = 1;
            }
        }
        else if ( ( gms_BOSS5_ROCKET_WORK.flag & 16U ) == 0U )
        {
            num = 1;
        }
        if ( num != 0 && ( gms_BOSS5_EFCT_GENERAL_WORK.flag & 1U ) == 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.flag |= 1U;
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000EE RID: 238 RVA: 0x0000A46C File Offset: 0x0000866C
    public static void gmBoss5EfctLandingShockwaveProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
        }
        else
        {
            AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)obj_work;
            gms_EFFECT_COM_WORK.rect_work[1].flag |= 2048U;
            gms_EFFECT_COM_WORK.rect_work[1].flag &= 4294967291U;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000EF RID: 239 RVA: 0x0000A4E8 File Offset: 0x000086E8
    public static void gmBoss5EfctStrikeShockwaveProcWaitStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
            return;
        }
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.armpt_snm_reg_ids[1][2]);
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obj_work.pos.y = gms_BOSS5_BODY_WORK.ground_v_pos;
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
        obj_work.pos.z = obj_work.pos.z + 262144;
        obj_work.flag &= 4294967293U;
        obj_work.disp_flag &= 4294963167U;
        gms_BOSS5_EFCT_GENERAL_WORK.timer = 15U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctStrikeShockwaveProcLoop );
    }

    // Token: 0x060000F0 RID: 240 RVA: 0x0000A5C4 File Offset: 0x000087C4
    public static void gmBoss5EfctStrikeShockwaveProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
        }
        else
        {
            AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)obj_work;
            gms_EFFECT_COM_WORK.rect_work[1].flag |= 2048U;
            gms_EFFECT_COM_WORK.rect_work[1].flag &= 4294967291U;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000F1 RID: 241 RVA: 0x0000A648 File Offset: 0x00008848
    public static void gmBoss5EfctCreateTargetCursorStart( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 23, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)gms_EFFECT_3DES_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        obs_OBJECT_WORK.pos.Assign( AppMain.GmBsCmnGetPlayerObj().pos );
        gms_BOSS5_EFCT_GENERAL_WORK.timer = 120U;
        obs_OBJECT_WORK.obj_3des.speed = 0.5f;
        AppMain.gmBoss5EfctTargetCursorInitFlickerNoDisp( gms_BOSS5_EFCT_GENERAL_WORK );
        AppMain.gmBoss5EfctCreateTargetCursorFlash( gms_EFFECT_COM_WORK, 26 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctTargetCursorStartProcMain );
    }

    // Token: 0x060000F2 RID: 242 RVA: 0x0000A6F8 File Offset: 0x000088F8
    public static void gmBoss5EfctTargetCursorStartProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        AppMain.GmBoss5BodyGetPlySearchPos( body_work, out obj_work.pos );
        float num = 1f - gms_BOSS5_EFCT_GENERAL_WORK.timer / 120f;
        num = AppMain.MTM_MATH_CLIP( num, 0f, 1f );
        obj_work.obj_3des.speed = 0.5f + num * 0.5f;
        float nodisp_time = 10f / obj_work.obj_3des.speed;
        float cycle_time = 20f / obj_work.obj_3des.speed;
        AppMain.gmBoss5EfctTargetCursorUpdateFlickerNoDisp( gms_BOSS5_EFCT_GENERAL_WORK, nodisp_time, cycle_time );
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
            return;
        }
        AppMain.gmBoss5EfctCreateTargetCursorLoop( body_work, gms_BOSS5_EFCT_GENERAL_WORK.efct_3des.efct_com );
        obj_work.flag |= 4U;
    }

    // Token: 0x060000F3 RID: 243 RVA: 0x0000A7D0 File Offset: 0x000089D0
    public static void gmBoss5EfctCreateTargetCursorLoop( AppMain.GMS_BOSS5_BODY_WORK body_work, AppMain.GMS_EFFECT_COM_WORK former_efct )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 21, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)gms_EFFECT_3DES_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        obs_OBJECT_WORK.pos.Assign( ( ( AppMain.OBS_OBJECT_WORK )former_efct ).pos );
        obs_OBJECT_WORK.obj_3des.speed = 0.8f;
        AppMain.gmBoss5EfctCreateTargetCursorFlash( gms_EFFECT_COM_WORK, 24 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctTargetCursorLoopProcMain );
    }

    // Token: 0x060000F4 RID: 244 RVA: 0x0000A874 File Offset: 0x00008A74
    public static void gmBoss5EfctTargetCursorLoopProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK targ_cursor = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        AppMain.GmBoss5BodyGetPlySearchPos( gms_BOSS5_BODY_WORK, out obj_work.pos );
        obj_work.obj_3des.speed += 0.005f;
        obj_work.obj_3des.speed = AppMain.MTM_MATH_CLIP( obj_work.obj_3des.speed, 0f, 1.5f );
        float nodisp_time = 10f / obj_work.obj_3des.speed;
        float cycle_time = 20f / obj_work.obj_3des.speed;
        AppMain.gmBoss5EfctTargetCursorUpdateFlickerNoDisp( targ_cursor, nodisp_time, cycle_time );
        if ( ( gms_BOSS5_BODY_WORK.flag & 2U ) == 0U )
        {
            AppMain.gmBoss5EfctCreateTargetCursorEnd( gms_BOSS5_BODY_WORK, ( AppMain.GMS_EFFECT_COM_WORK )obj_work );
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000F5 RID: 245 RVA: 0x0000A934 File Offset: 0x00008B34
    public static void gmBoss5EfctCreateTargetCursorEnd( AppMain.GMS_BOSS5_BODY_WORK body_work, AppMain.GMS_EFFECT_COM_WORK former_efct )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 22, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)gms_EFFECT_3DES_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        obs_OBJECT_WORK.pos.Assign( ( ( AppMain.OBS_OBJECT_WORK )former_efct ).pos );
        AppMain.gmBoss5EfctCreateTargetCursorFlash( gms_EFFECT_COM_WORK, 25 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctTargetCursorEndProcMain );
    }

    // Token: 0x060000F6 RID: 246 RVA: 0x0000A9C6 File Offset: 0x00008BC6
    public static void gmBoss5EfctTargetCursorEndProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060000F7 RID: 247 RVA: 0x0000A9E0 File Offset: 0x00008BE0
    public static void gmBoss5EfctCreateTargetCursorFlash( AppMain.GMS_EFFECT_COM_WORK parent_efct, int efct_idx )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate((AppMain.OBS_OBJECT_WORK)parent_efct, efct_idx);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
        obs_OBJECT_WORK.disp_flag |= 32U;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        obs_OBJECT_WORK.obj_3des.speed = ( ( AppMain.OBS_OBJECT_WORK )parent_efct ).obj_3des.speed;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctTargetCursorFlashProcMain );
    }

    // Token: 0x060000F8 RID: 248 RVA: 0x0000AA54 File Offset: 0x00008C54
    public static void gmBoss5EfctTargetCursorFlashProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3des.speed = obj_work.parent_obj.obj_3des.speed;
        if ( ( obj_work.parent_obj.disp_flag & 32U ) != 0U )
        {
            obj_work.disp_flag &= 4294967263U;
            return;
        }
        obj_work.disp_flag |= 32U;
    }

    // Token: 0x060000F9 RID: 249 RVA: 0x0000AAAB File Offset: 0x00008CAB
    public static void gmBoss5EfctTargetCursorInitFlickerNoDisp( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK targ_cursor )
    {
        targ_cursor.ratio_timer = 0f;
    }

    // Token: 0x060000FA RID: 250 RVA: 0x0000AAB8 File Offset: 0x00008CB8
    public static void gmBoss5EfctTargetCursorUpdateFlickerNoDisp( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK targ_cursor, float nodisp_time, float cycle_time )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)targ_cursor;
        targ_cursor.ratio_timer += 1f;
        if ( targ_cursor.ratio_timer >= cycle_time )
        {
            targ_cursor.ratio_timer = 0f;
        }
        if ( targ_cursor.ratio_timer >= nodisp_time )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967263U;
            return;
        }
        obs_OBJECT_WORK.disp_flag |= 32U;
    }

    // Token: 0x060000FB RID: 251 RVA: 0x0000AB24 File Offset: 0x00008D24
    public static void gmBoss5EfctCreateCrashCursorStart( AppMain.GMS_BOSS5_BODY_WORK body_work, int pos_x, uint duration_time )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 23, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)gms_EFFECT_3DES_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        gms_BOSS5_EFCT_GENERAL_WORK.user_work = ( uint )pos_x;
        gms_BOSS5_EFCT_GENERAL_WORK.timer = duration_time;
        obs_OBJECT_WORK.user_work = duration_time;
        if ( ( AppMain.mtMathRand() & 1 ) != 0 )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.user_flag = 1U;
        }
        else
        {
            gms_BOSS5_EFCT_GENERAL_WORK.user_flag = 0U;
        }
        AppMain.gmBoss5EfctCrashCursorStartSetCurPos( gms_BOSS5_EFCT_GENERAL_WORK, 0f, ( int )gms_BOSS5_EFCT_GENERAL_WORK.user_flag );
        obs_OBJECT_WORK.pos.y = body_work.ground_v_pos + -131072;
        obs_OBJECT_WORK.pos.z = AppMain.GmBsCmnGetPlayerObj().pos.z;
        AppMain.gmBoss5EfctTargetCursorInitFlickerNoDisp( gms_BOSS5_EFCT_GENERAL_WORK );
        AppMain.gmBoss5EfctCreateTargetCursorFlash( gms_EFFECT_COM_WORK, 26 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctCrashCursorStartProcMain );
    }

    // Token: 0x060000FC RID: 252 RVA: 0x0000AC18 File Offset: 0x00008E18
    public static void gmBoss5EfctCrashCursorStartProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK gms_BOSS5_EFCT_GENERAL_WORK = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        AppMain.gmBoss5EfctTargetCursorUpdateFlickerNoDisp( gms_BOSS5_EFCT_GENERAL_WORK, 10f, 20f );
        if ( gms_BOSS5_EFCT_GENERAL_WORK.timer != 0U )
        {
            gms_BOSS5_EFCT_GENERAL_WORK.timer -= 1U;
            float num = 1f - gms_BOSS5_EFCT_GENERAL_WORK.timer / obj_work.user_work;
            num = ( 1f - AppMain.nnSin( AppMain.nnArcCos( ( double )( num * 0.9f ) ) ) ) / ( 1f - AppMain.nnSin( AppMain.nnArcCos( 0.8999999761581421 ) ) );
            num = AppMain.MTM_MATH_CLIP( num, 0f, 1f );
            AppMain.gmBoss5EfctCrashCursorStartSetCurPos( gms_BOSS5_EFCT_GENERAL_WORK, num, ( int )gms_BOSS5_EFCT_GENERAL_WORK.user_flag );
            return;
        }
        AppMain.gmBoss5EfctCrashCursorStartSetCurPos( gms_BOSS5_EFCT_GENERAL_WORK, 1f, ( int )gms_BOSS5_EFCT_GENERAL_WORK.user_flag );
        AppMain.gmBoss5EfctCreateCrashCursorLoop( body_work, obj_work.pos.x );
        obj_work.flag |= 4U;
    }

    // Token: 0x060000FD RID: 253 RVA: 0x0000ACF8 File Offset: 0x00008EF8
    public static void gmBoss5EfctCrashCursorStartSetCurPos( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK ctarg_start, float ratio, int app_dir_left )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ctarg_start;
        int num = AppMain.GMM_BOSS5_AREA_CENTER_X() + -1048576;
        int num2 = AppMain.GMM_BOSS5_AREA_CENTER_X() + 1048576;
        int num3 = 2097152 - (int)(4096f * AppMain.fmod(AppMain.FX_FX32_TO_F32(13631488), AppMain.FX_FX32_TO_F32(2097152)));
        int num4 = (int)ctarg_start.user_work;
        num4 = AppMain.MTM_MATH_CLIP( num4, num, num2 );
        if ( app_dir_left != 0 )
        {
            num3 += num2 - num4;
        }
        else
        {
            num3 += 2097152;
            num3 += num4 - num;
        }
        int num5 = (int)(13631488f * ratio) + num3;
        int num6 = (int)(4096f * AppMain.fmod(AppMain.FX_FX32_TO_F32(num5), AppMain.FX_FX32_TO_F32(2097152)));
        if ( ( AppMain.FX_Div( num5, 2097152 ) >> 12 & 1 ) != 0 )
        {
            obs_OBJECT_WORK.pos.x = num2 - num6;
            return;
        }
        obs_OBJECT_WORK.pos.x = num + num6;
    }

    // Token: 0x060000FE RID: 254 RVA: 0x0000ADE0 File Offset: 0x00008FE0
    public static void gmBoss5EfctCreateCrashCursorLoop( AppMain.GMS_BOSS5_BODY_WORK body_work, int pos_x )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 21, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)gms_EFFECT_3DES_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_COM_WORK;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK targ_cursor = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obs_OBJECT_WORK;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = body_work.ground_v_pos + -131072;
        obs_OBJECT_WORK.pos.z = AppMain.GmBsCmnGetPlayerObj().pos.z;
        AppMain.gmBoss5EfctTargetCursorInitFlickerNoDisp( targ_cursor );
        AppMain.gmBoss5EfctCreateTargetCursorFlash( gms_EFFECT_COM_WORK, 24 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctCrashCursorLoopProcMain );
    }

    // Token: 0x060000FF RID: 255 RVA: 0x0000AEA0 File Offset: 0x000090A0
    public static void gmBoss5EfctCrashCursorLoopProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_EFCT_GENERAL_WORK targ_cursor = (AppMain.GMS_BOSS5_EFCT_GENERAL_WORK)obj_work;
        AppMain.gmBoss5EfctTargetCursorUpdateFlickerNoDisp( targ_cursor, 10f, 20f );
        if ( ( gms_BOSS5_BODY_WORK.flag & 2U ) == 0U )
        {
            AppMain.gmBoss5EfctCreateCrashCursorEnd( gms_BOSS5_BODY_WORK, ( AppMain.GMS_EFFECT_COM_WORK )obj_work );
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000100 RID: 256 RVA: 0x0000AEFC File Offset: 0x000090FC
    public static void gmBoss5EfctCreateCrashCursorEnd( AppMain.GMS_BOSS5_BODY_WORK body_work, AppMain.GMS_EFFECT_COM_WORK former_efct )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.gmBoss5EfctEsCreate(AppMain.GMM_BS_OBJ(body_work), 22, () => new AppMain.GMS_BOSS5_EFCT_GENERAL_WORK());
        AppMain.GMS_EFFECT_COM_WORK work = (AppMain.GMS_EFFECT_COM_WORK)gms_EFFECT_3DES_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)work;
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 32f );
        obs_OBJECT_WORK.pos.Assign( ( ( AppMain.OBS_OBJECT_WORK )former_efct ).pos );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctCrashCursorEndProcMain );
    }

    // Token: 0x06000101 RID: 257 RVA: 0x0000AF86 File Offset: 0x00009186
    public static void gmBoss5EfctCrashCursorEndProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000102 RID: 258 RVA: 0x0000AFA0 File Offset: 0x000091A0
    public static void gmBoss5EfctVulcanBulletProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.pos.x <= AppMain.GMM_BOSS5_AREA_LEFT() || obj_work.pos.y <= AppMain.GMM_BOSS5_AREA_TOP() || obj_work.pos.x >= AppMain.GMM_BOSS5_AREA_RIGHT() || obj_work.pos.y >= AppMain.GMM_BOSS5_AREA_BOTTOM() )
        {
            obj_work.flag &= 4294967279U;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000103 RID: 259 RVA: 0x0000B01C File Offset: 0x0000921C
    public static void gmBoss5EfctCreateRocketSmoke( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(AppMain.GMM_BS_OBJ(rkt_work), 3U);
        AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 0f );
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, ( short )AppMain.AKM_DEGtoA32( 0 ), 0, 0 );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctRocketSmokeProcLoop );
    }

    // Token: 0x06000104 RID: 260 RVA: 0x0000B074 File Offset: 0x00009274
    public static void gmBoss5EfctRocketSmokeProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)obj_work.parent_obj;
        if ( ( gms_BOSS5_ROCKET_WORK.flag & 64U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctRocketSmokeProcFade );
        }
    }

    // Token: 0x06000105 RID: 261 RVA: 0x0000B0B0 File Offset: 0x000092B0
    public static void gmBoss5EfctRocketSmokeProcFade( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000106 RID: 262 RVA: 0x0000B0CC File Offset: 0x000092CC
    public static void gmBoss5EfctBreakdownSmokeProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.ObjDrawKillAction3DES( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctBreakdownSmokeProcFade );
    }

    // Token: 0x06000107 RID: 263 RVA: 0x0000B138 File Offset: 0x00009338
    public static void gmBoss5EfctBreakdownSmokeProcFade( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000108 RID: 264 RVA: 0x0000B152 File Offset: 0x00009352
    public static void gmBoss5EfctCreateBodySmallSmoke( AppMain.GMS_BOSS5_BODY_WORK body_work, uint part_idx )
    {
    }

    // Token: 0x06000109 RID: 265 RVA: 0x0000B154 File Offset: 0x00009354
    public static void gmBoss5EfctBodySmallSmokeProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.ObjDrawKillAction3DES( obj_work );
        obj_work.user_timer = AppMain.AkMathRandFx() * 60 + 60 >> 12;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctBodySmallSmokeProcFade );
    }

    // Token: 0x0600010A RID: 266 RVA: 0x0000B1D4 File Offset: 0x000093D4
    public static void gmBoss5EfctBodySmallSmokeProcFade( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( obj_work.user_timer != 0 )
            {
                obj_work.user_timer--;
                return;
            }
            AppMain.gmBoss5EfctCreateBodySmallSmoke( body_work, obj_work.user_work );
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x0600010B RID: 267 RVA: 0x0000B228 File Offset: 0x00009428
    public static void gmBoss5EfctCreateBerserkSteam( AppMain.GMS_BOSS5_BODY_WORK body_work, uint count, uint part_idx )
    {
        if ( count == 0U )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(body_work), 89);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_EFFECT_3DES_WORK;
        obs_OBJECT_WORK.user_flag = part_idx;
        obs_OBJECT_WORK.user_work = count - 1U;
        AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, AppMain.gm_boss5_efct_berserk_steam_disp_ofst_tbl[( int )( ( UIntPtr )part_idx )][0], AppMain.gm_boss5_efct_berserk_steam_disp_ofst_tbl[( int )( ( UIntPtr )part_idx )][1], AppMain.gm_boss5_efct_berserk_steam_disp_ofst_tbl[( int )( ( UIntPtr )part_idx )][2] );
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, AppMain.gm_boss5_efct_berserk_steam_disp_rot_tbl[( int )( ( UIntPtr )part_idx )][0], AppMain.gm_boss5_efct_berserk_steam_disp_rot_tbl[( int )( ( UIntPtr )part_idx )][1], AppMain.gm_boss5_efct_berserk_steam_disp_rot_tbl[( int )( ( UIntPtr )part_idx )][2] );
        obs_OBJECT_WORK.user_timer = 6;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctBerserkSteamProcLoop );
    }

    // Token: 0x0600010C RID: 268 RVA: 0x0000B2C0 File Offset: 0x000094C0
    public static void gmBoss5EfctBerserkSteamProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.ObjDrawKillAction3DES( obj_work );
        obj_work.user_timer = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctBerserkSteamProcFade );
    }

    // Token: 0x0600010D RID: 269 RVA: 0x0000B334 File Offset: 0x00009534
    public static void gmBoss5EfctBerserkSteamProcFade( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, 1, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( obj_work.user_timer != 0 )
            {
                obj_work.user_timer--;
                return;
            }
            if ( obj_work.user_work != 0U )
            {
                AppMain.gmBoss5EfctCreateBerserkSteam( gms_BOSS5_BODY_WORK, obj_work.user_work, obj_work.user_flag );
            }
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x0600010E RID: 270 RVA: 0x0000B3BC File Offset: 0x000095BC
    public static void gmBoss5EfctCreateEggSweat( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(egg_work), 93);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 56f, -8f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EfctEggSweatProcLoop );
    }

    // Token: 0x0600010F RID: 271 RVA: 0x0000B404 File Offset: 0x00009604
    public static void gmBoss5EfctEggSweatProcLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_EGG_WORK gms_BOSS5_EGG_WORK = (AppMain.GMS_BOSS5_EGG_WORK)obj_work.parent_obj;
        if ( ( gms_BOSS5_EGG_WORK.flag & AppMain.GMD_BOSS5_EGG_FLAG_SWEAT_ACTIVE ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        }
    }
}