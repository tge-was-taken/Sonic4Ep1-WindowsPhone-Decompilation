using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200026C RID: 620
    public class GMS_BOSS5_ROCKET_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023FF RID: 9215 RVA: 0x00149FBC File Offset: 0x001481BC
        public GMS_BOSS5_ROCKET_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002400 RID: 9216 RVA: 0x0014A05D File Offset: 0x0014825D
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_BOSS5_ROCKET_WORK p )
        {
            return p.ene_3d.ene_com;
        }

        // Token: 0x06002401 RID: 9217 RVA: 0x0014A06A File Offset: 0x0014826A
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0400593C RID: 22844
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x0400593D RID: 22845
        public uint flag;

        // Token: 0x0400593E RID: 22846
        public int rkt_type;

        // Token: 0x0400593F RID: 22847
        public uint wait_timer;

        // Token: 0x04005940 RID: 22848
        public uint hit_count;

        // Token: 0x04005941 RID: 22849
        public uint no_hit_timer;

        // Token: 0x04005942 RID: 22850
        public uint wfall_atk_toggle_timer;

        // Token: 0x04005943 RID: 22851
        public AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK proc_update;

        // Token: 0x04005944 RID: 22852
        public int move_dir;

        // Token: 0x04005945 RID: 22853
        public int acc;

        // Token: 0x04005946 RID: 22854
        public int max_spd;

        // Token: 0x04005947 RID: 22855
        public AppMain.VecFx32 launch_pos = default(AppMain.VecFx32);

        // Token: 0x04005948 RID: 22856
        public AppMain.VecFx32 dest_pos = default(AppMain.VecFx32);

        // Token: 0x04005949 RID: 22857
        public AppMain.VecFx32 rvs_acc = default(AppMain.VecFx32);

        // Token: 0x0400594A RID: 22858
        public int rot_spd;

        // Token: 0x0400594B RID: 22859
        public int stuck_dir;

        // Token: 0x0400594C RID: 22860
        public float stuck_lean_ratio;

        // Token: 0x0400594D RID: 22861
        public float hit_vib_amp_deg;

        // Token: 0x0400594E RID: 22862
        public int hit_vib_sin_angle;

        // Token: 0x0400594F RID: 22863
        public int pivot_fall_angle;

        // Token: 0x04005950 RID: 22864
        public int wobble_sin_param_angle;

        // Token: 0x04005951 RID: 22865
        public AppMain.NNS_QUATERNION sct_cur_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04005952 RID: 22866
        public AppMain.NNS_QUATERNION sct_spin_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04005953 RID: 22867
        public int arm_snm_id;

        // Token: 0x04005954 RID: 22868
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04005955 RID: 22869
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04005956 RID: 22870
        public int drill_snm_reg_id;

        // Token: 0x04005957 RID: 22871
        public AppMain.VecFx32 pivot_prev_pos = default(AppMain.VecFx32);

        // Token: 0x04005958 RID: 22872
        public AppMain.NNS_QUATERNION stuck_lerp_src_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04005959 RID: 22873
        public float stuck_lerp_ratio;

        // Token: 0x0400595A RID: 22874
        public float stuck_lerp_ratio_spd;

        // Token: 0x0400595B RID: 22875
        public readonly AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK dsearch_work = new AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK();

        // Token: 0x0400595C RID: 22876
        public AppMain.VecFx32[] search_hist_buf = AppMain.New<AppMain.VecFx32>(21U);

        // Token: 0x0400595D RID: 22877
        public int ply_search_delay;
    }

    // Token: 0x0200026D RID: 621
    private class GMS_BOSS5_RKT_SEQ_WAITFALL_INFO
    {
        // Token: 0x06002402 RID: 9218 RVA: 0x0014A07C File Offset: 0x0014827C
        public GMS_BOSS5_RKT_SEQ_WAITFALL_INFO( int life, int[] prob, uint[] fr )
        {
            this.life_threshold = life;
            this.probability = prob;
            this.frame = fr;
        }

        // Token: 0x0400595E RID: 22878
        public int life_threshold;

        // Token: 0x0400595F RID: 22879
        public readonly int[] probability = new int[3];

        // Token: 0x04005960 RID: 22880
        public readonly uint[] frame = new uint[3];
    }

    // Token: 0x06001054 RID: 4180 RVA: 0x0008FC48 File Offset: 0x0008DE48
    public static AppMain.OBS_OBJECT_WORK GmBoss5RocketInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_ROCKET_WORK(), "BOSS5_RKT");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS5_ROCKET_WORK rkt_work = (AppMain.GMS_BOSS5_ROCKET_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -16, -16, 16, 16 );
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294443007U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss5GetObject3dList()[3], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 747 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = AppMain.GMD_BOSS5_DEFAULT_BLEND_SPD;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 16U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss5RocketAtkPlyHitFunc );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss5RocketDamageDefFunc );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag |= 2048U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag |= 2048U;
        AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, 0, 1, 0 );
        AppMain.gmBoss5RocketInitCallbacks( rkt_work );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5RocketMain );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5RocketOutFunc );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss5RocketExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001055 RID: 4181 RVA: 0x0008FE38 File Offset: 0x0008E038
    public static AppMain.GMS_BOSS5_ROCKET_WORK GmBoss5RocketLaunchNormal( AppMain.GMS_BOSS5_BODY_WORK body_work, int rkt_type )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = AppMain.gmBoss5RocketCreate(body_work, rkt_type);
        AppMain.gmBoss5RocketNmlProcInit( gms_BOSS5_ROCKET_WORK );
        return gms_BOSS5_ROCKET_WORK;
    }

    // Token: 0x06001056 RID: 4182 RVA: 0x0008FE54 File Offset: 0x0008E054
    public static AppMain.GMS_BOSS5_ROCKET_WORK GmBoss5RocketLaunchStrong( AppMain.GMS_BOSS5_BODY_WORK body_work, int rkt_type )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = AppMain.gmBoss5RocketCreate(body_work, rkt_type);
        AppMain.gmBoss5RocketStrProcInit( gms_BOSS5_ROCKET_WORK );
        return gms_BOSS5_ROCKET_WORK;
    }

    // Token: 0x06001057 RID: 4183 RVA: 0x0008FE70 File Offset: 0x0008E070
    public static AppMain.GMS_BOSS5_ROCKET_WORK GmBoss5RocketSpawnConnected( AppMain.GMS_BOSS5_BODY_WORK body_work, int rkt_type )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = AppMain.gmBoss5RocketCreate(body_work, rkt_type);
        AppMain.gmBoss5RocketCnctProcInit( gms_BOSS5_ROCKET_WORK );
        return gms_BOSS5_ROCKET_WORK;
    }

    // Token: 0x06001058 RID: 4184 RVA: 0x0008FE8C File Offset: 0x0008E08C
    public static void gmBoss5RocketExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK rkt_work = (AppMain.GMS_BOSS5_ROCKET_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss5RocketReleaseCallbacks( rkt_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06001059 RID: 4185 RVA: 0x0008FEB4 File Offset: 0x0008E0B4
    public static AppMain.GMS_BOSS5_ROCKET_WORK gmBoss5RocketCreate( AppMain.GMS_BOSS5_BODY_WORK body_work, int rkt_type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(332, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0);
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)obs_OBJECT_WORK2;
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        gms_BOSS5_ROCKET_WORK.rkt_type = rkt_type;
        if ( 1 == rkt_type )
        {
            gms_BOSS5_ROCKET_WORK.arm_snm_id = body_work.armpt_snm_reg_ids[1][2];
        }
        else
        {
            gms_BOSS5_ROCKET_WORK.arm_snm_id = body_work.armpt_snm_reg_ids[0][2];
        }
        obs_OBJECT_WORK2.disp_flag |= 16777216U;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.nnMakeRotateXMatrix( obs_OBJECT_WORK2.obj_3d.user_obj_mtx_r, AppMain.AKM_DEGtoA32( 180 ) );
            obs_OBJECT_WORK2.disp_flag |= 1U;
        }
        else
        {
            AppMain.nnMakeRotateXMatrix( obs_OBJECT_WORK2.obj_3d.user_obj_mtx_r, AppMain.AKM_DEGtoA32( 0 ) );
            obs_OBJECT_WORK2.disp_flag &= 4294967294U;
        }
        return ( AppMain.GMS_BOSS5_ROCKET_WORK )obs_OBJECT_WORK2;
    }

    // Token: 0x0600105A RID: 4186 RVA: 0x0008FF9C File Offset: 0x0008E19C
    public static void gmBoss5RocketSetAtkBodyRect( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)rkt_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[1];
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 0, 2 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 2, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, ushort.MaxValue, 0 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss5RocketAtkBossHitFunc );
        obs_RECT_WORK.ppDef = null;
    }

    // Token: 0x0600105B RID: 4187 RVA: 0x0008FFFC File Offset: 0x0008E1FC
    public static void gmBoss5RocketSetNoHitTime( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)rkt_work;
        rkt_work.no_hit_timer = 10U;
        gms_ENEMY_COM_WORK.rect_work[0].flag |= 2048U;
        gms_ENEMY_COM_WORK.rect_work[1].flag |= 2048U;
    }

    // Token: 0x0600105C RID: 4188 RVA: 0x0009004C File Offset: 0x0008E24C
    public static void gmBoss5RocketUpdateNoHitTime( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( rkt_work.no_hit_timer != 0U )
        {
            rkt_work.no_hit_timer -= 1U;
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)rkt_work;
        gms_ENEMY_COM_WORK.rect_work[0].flag &= 4294965247U;
        gms_ENEMY_COM_WORK.rect_work[1].flag &= 4294965247U;
    }

    // Token: 0x0600105D RID: 4189 RVA: 0x000900AC File Offset: 0x0008E2AC
    public static void gmBoss5RocketUpdateMainRectPosition( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(rkt_work.snm_work, rkt_work.drill_snm_reg_id);
        int x = AppMain.FX_F32_TO_FX32(nns_MATRIX.M03) - rkt_work.pivot_prev_pos.x;
        int y = -AppMain.FX_F32_TO_FX32(nns_MATRIX.M13) - rkt_work.pivot_prev_pos.y;
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.VEC_Set( ref rkt_work.ene_3d.ene_com.rect_work[i].rect.pos, x, y, 0 );
        }
    }

    // Token: 0x0600105E RID: 4190 RVA: 0x0009012C File Offset: 0x0008E32C
    public static void gmBoss5RocketSetAtkEnable( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int enable )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)rkt_work;
        if ( enable != 0 )
        {
            gms_ENEMY_COM_WORK.rect_work[1].flag &= 4294965247U;
            return;
        }
        gms_ENEMY_COM_WORK.rect_work[1].flag |= 2048U;
    }

    // Token: 0x0600105F RID: 4191 RVA: 0x00090178 File Offset: 0x0008E378
    public static void gmBoss5RocketSetDmgEnable( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int enable )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)rkt_work;
        if ( enable != 0 )
        {
            gms_ENEMY_COM_WORK.rect_work[0].flag &= 4294965247U;
            return;
        }
        gms_ENEMY_COM_WORK.rect_work[0].flag |= 2048U;
    }

    // Token: 0x06001060 RID: 4192 RVA: 0x000901C4 File Offset: 0x0008E3C4
    public static void gmBoss5RocketSetRectSize( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int sides_type )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)rkt_work;
        switch ( sides_type )
        {
            default:
                AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[0], -20, -20, 20, 20 );
                AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[1], -10, -10, 10, 10 );
                return;
            case 1:
                AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[1], -20, -20, 20, 20 );
                AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[0], -10, -10, 10, 10 );
                return;
        }
    }

    // Token: 0x06001061 RID: 4193 RVA: 0x00090241 File Offset: 0x0008E441
    public static void gmBoss5RocketInitPlySearch( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int delay )
    {
        rkt_work.ply_search_delay = delay;
        AppMain.GmBsCmnInitDelaySearch( rkt_work.dsearch_work, AppMain.GmBsCmnGetPlayerObj(), rkt_work.search_hist_buf, 21 );
    }

    // Token: 0x06001062 RID: 4194 RVA: 0x00090262 File Offset: 0x0008E462
    public static void gmBoss5RocketUpdatePlySearch( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.GmBsCmnUpdateDelaySearch( rkt_work.dsearch_work );
    }

    // Token: 0x06001063 RID: 4195 RVA: 0x0009026F File Offset: 0x0008E46F
    public static void gmBoss5RocketGetPlySearchPos( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, out AppMain.VecFx32 pos )
    {
        AppMain.GmBsCmnGetDelaySearchPos( rkt_work.dsearch_work, rkt_work.ply_search_delay, out pos );
    }

    // Token: 0x06001064 RID: 4196 RVA: 0x00090284 File Offset: 0x0008E484
    public static int gmBoss5RocketSetPlyRebound( AppMain.OBS_RECT_WORK rkt_rect, AppMain.OBS_RECT_WORK ply_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = ply_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = rkt_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj3 = parent_obj2.parent_obj;
        AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
        if ( gms_PLAYER_WORK.seq_state == 20 )
        {
            AppMain.GmPlySeqSetJumpState( gms_PLAYER_WORK, 0, 5U );
            uint num = AppMain.GmBsCmnCheckRectHitSideVFirst(rkt_rect, ply_rect);
            gms_PLAYER_WORK.obj_work.spd_m = 0;
            if ( ( num & AppMain.GMD_BS_CMN_RECT_HIT_SIDE_H_MASK ) != 0U )
            {
                if ( ( num & AppMain.GMD_BS_CMN_RECT_HIT_SIDE_LEFT ) != 0U )
                {
                    gms_PLAYER_WORK.obj_work.spd.x = -16384;
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.x = 16384;
                }
            }
            else if ( gms_PLAYER_WORK.obj_work.move.x > 0 )
            {
                gms_PLAYER_WORK.obj_work.spd.x = -16384;
            }
            else if ( gms_PLAYER_WORK.obj_work.move.x < 0 )
            {
                gms_PLAYER_WORK.obj_work.spd.x = 16384;
            }
            else if ( gms_PLAYER_WORK.obj_work.pos.x < parent_obj3.pos.x )
            {
                gms_PLAYER_WORK.obj_work.spd.x = 16384;
            }
            else if ( parent_obj3.pos.x < gms_PLAYER_WORK.obj_work.pos.x )
            {
                gms_PLAYER_WORK.obj_work.spd.x = -16384;
            }
            else if ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) != 0U )
            {
                gms_PLAYER_WORK.obj_work.spd.x = 16384;
            }
            else
            {
                gms_PLAYER_WORK.obj_work.spd.x = -16384;
            }
            gms_PLAYER_WORK.obj_work.spd.y = -16384;
            AppMain.GmPlySeqSetNoJumpMoveTime( gms_PLAYER_WORK, 49152 );
        }
        else
        {
            uint num2 = AppMain.GmBsCmnCheckRectHitSideVFirst(rkt_rect, ply_rect);
            gms_PLAYER_WORK.obj_work.spd_m = 0;
            if ( ( num2 & AppMain.GMD_BS_CMN_RECT_HIT_SIDE_H_MASK ) != 0U )
            {
                if ( ( num2 & AppMain.GMD_BS_CMN_RECT_HIT_SIDE_LEFT ) != 0U )
                {
                    gms_PLAYER_WORK.obj_work.spd.x = -12288;
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.x = 12288;
                }
            }
            else if ( gms_PLAYER_WORK.obj_work.move.x > 0 )
            {
                gms_PLAYER_WORK.obj_work.spd.x = -12288;
            }
            else if ( gms_PLAYER_WORK.obj_work.move.x < 0 )
            {
                gms_PLAYER_WORK.obj_work.spd.x = 12288;
            }
            else if ( gms_PLAYER_WORK.obj_work.pos.x < parent_obj3.pos.x )
            {
                gms_PLAYER_WORK.obj_work.spd.x = 12288;
            }
            else if ( parent_obj3.pos.x < gms_PLAYER_WORK.obj_work.pos.x )
            {
                gms_PLAYER_WORK.obj_work.spd.x = -12288;
            }
            else if ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) != 0U )
            {
                gms_PLAYER_WORK.obj_work.spd.x = 12288;
            }
            else
            {
                gms_PLAYER_WORK.obj_work.spd.x = -12288;
            }
            gms_PLAYER_WORK.obj_work.spd.y = -16384;
            AppMain.GmPlySeqSetNoJumpMoveTime( gms_PLAYER_WORK, 32768 );
            gms_PLAYER_WORK.homing_timer = 40960;
        }
        return 1;
    }

    // Token: 0x06001065 RID: 4197 RVA: 0x000905D0 File Offset: 0x0008E7D0
    public static void gmBoss5RocketUpdateRocketStuckWithArm( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int b_rotation )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.NNS_MATRIX ofst_mtx;
        if ( ( gms_BOSS5_BODY_WORK.flag & 16U ) != 0U )
        {
            int num;
            if ( rkt_work.rkt_type == 1 )
            {
                num = 1;
            }
            else
            {
                num = 0;
            }
            ofst_mtx = gms_BOSS5_BODY_WORK.rkt_ofst_mtx[num];
        }
        else
        {
            ofst_mtx = null;
        }
        if ( gms_BOSS5_BODY_WORK.adj_hgap_is_active != 0 )
        {
            AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obs_OBJECT_WORK, gms_BOSS5_BODY_WORK.snm_work, rkt_work.arm_snm_id, b_rotation, ofst_mtx );
        }
        else
        {
            AppMain.GmBsCmnUpdateObject3DNNStuckWithNodeRelative( obs_OBJECT_WORK, gms_BOSS5_BODY_WORK.snm_work, rkt_work.arm_snm_id, b_rotation, obs_OBJECT_WORK.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos, ofst_mtx );
        }
        if ( b_rotation != 0 && rkt_work.rkt_type == 1 )
        {
            obs_OBJECT_WORK.disp_flag |= 16777216U;
            AppMain.nnRotateYMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, AppMain.AKM_DEGtoA32( 180 ) );
        }
    }

    // Token: 0x06001066 RID: 4198 RVA: 0x000906A0 File Offset: 0x0008E8A0
    public static void gmBoss5RocketInitRocketStuckWithArmLerpRot( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, float ratio_spd )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX src_mtx = AppMain.GmBsCmnGetSNMMtx(rkt_work.snm_work, rkt_work.drill_snm_reg_id);
        AppMain.AkMathNormalizeMtx( nns_MATRIX, src_mtx );
        AppMain.nnMakeRotateMatrixQuaternion( out rkt_work.stuck_lerp_src_quat, nns_MATRIX );
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 0 );
        obs_OBJECT_WORK.dir.x = ( obs_OBJECT_WORK.dir.y = ( obs_OBJECT_WORK.dir.z = 0 ) );
        rkt_work.stuck_lerp_ratio = 0f;
        rkt_work.stuck_lerp_ratio_spd = ratio_spd;
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06001067 RID: 4199 RVA: 0x00090728 File Offset: 0x0008E928
    public static int gmBoss5RocketUpdateRocketStuckWithArmLerpRot( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num = 0;
        rkt_work.stuck_lerp_ratio += rkt_work.stuck_lerp_ratio_spd;
        if ( rkt_work.stuck_lerp_ratio >= 1f )
        {
            rkt_work.stuck_lerp_ratio = 1f;
            num = 1;
        }
        AppMain.NNS_MATRIX src_mtx = AppMain.GmBsCmnGetSNMMtx(gms_BOSS5_BODY_WORK.snm_work, rkt_work.arm_snm_id);
        AppMain.AkMathNormalizeMtx( nns_MATRIX, src_mtx );
        AppMain.NNS_QUATERNION nns_QUATERNION;
        AppMain.nnMakeRotateMatrixQuaternion( out nns_QUATERNION, nns_MATRIX );
        if ( rkt_work.rkt_type == 1 )
        {
            AppMain.NNS_QUATERNION nns_QUATERNION2;
            AppMain.nnMakeRotateXYZQuaternion( out nns_QUATERNION2, 0, AppMain.AKM_DEGtoA32( 180 ), 0 );
            AppMain.nnMultiplyQuaternion( ref nns_QUATERNION, ref nns_QUATERNION, ref nns_QUATERNION2 );
        }
        AppMain.NNS_QUATERNION nns_QUATERNION3;
        AppMain.nnSlerpQuaternion( out nns_QUATERNION3, ref rkt_work.stuck_lerp_src_quat, ref nns_QUATERNION, rkt_work.stuck_lerp_ratio );
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 0 );
        obs_OBJECT_WORK.disp_flag |= 16777216U;
        AppMain.nnQuaternionMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, ref nns_QUATERNION3 );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        if ( num != 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001068 RID: 4200 RVA: 0x00090820 File Offset: 0x0008EA20
    public static void gmBoss5RocketGetArmNodePosFx( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, out AppMain.VecFx32 pos_out )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(gms_BOSS5_BODY_WORK.snm_work, rkt_work.arm_snm_id);
        pos_out.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        pos_out.y = -AppMain.FX_F32_TO_FX32( nns_MATRIX.M13 );
        pos_out.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
    }

    // Token: 0x06001069 RID: 4201 RVA: 0x00090888 File Offset: 0x0008EA88
    public static void gmBoss5RocketSetDispOfst( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, float disp_ofst, int b_pos_slide )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        obs_OBJECT_WORK.disp_flag |= 16777216U;
        AppMain.nnTranslateMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, disp_ofst, 0f, 0f );
        if ( b_pos_slide != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x - AppMain.FX_Mul( AppMain.FX_F32_TO_FX32( AppMain.nnCos( ( int )obs_OBJECT_WORK.dir.z ) * disp_ofst ), AppMain.g_obj.draw_scale.x );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y - AppMain.FX_Mul( AppMain.FX_F32_TO_FX32( AppMain.nnSin( ( int )obs_OBJECT_WORK.dir.z ) * disp_ofst ), AppMain.g_obj.draw_scale.y );
        }
    }

    // Token: 0x0600106A RID: 4202 RVA: 0x00090954 File Offset: 0x0008EB54
    public static void gmBoss5RocketGetDispOfst( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, ref AppMain.VecFx32 ofst_pos_out )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, 0f, 0f, 0f );
        AppMain.nnMakeRotateXYZMatrix( nns_MATRIX, ( int )( 65535L & ( long )( -( long )obs_OBJECT_WORK.dir.x ) ), ( int )( ushort.MaxValue & obs_OBJECT_WORK.dir.y ), ( int )( 65535L & ( long )( -( long )obs_OBJECT_WORK.dir.z ) ) );
        AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, AppMain.FX_FX32_TO_F32( AppMain.g_obj.draw_scale.x ), AppMain.FX_FX32_TO_F32( AppMain.g_obj.draw_scale.y ), AppMain.FX_FX32_TO_F32( AppMain.g_obj.draw_scale.z ) );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, obs_OBJECT_WORK.obj_3d.user_obj_mtx_r );
        AppMain.nnTransformVector( nns_VECTOR, nns_MATRIX, nns_VECTOR );
        AppMain.VEC_Set( ref ofst_pos_out, AppMain.FX_F32_TO_FX32( nns_VECTOR.x ), AppMain.FX_F32_TO_FX32( -nns_VECTOR.y ), AppMain.FX_F32_TO_FX32( nns_VECTOR.z ) );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x0600106B RID: 4203 RVA: 0x00090A5C File Offset: 0x0008EC5C
    public static int gmBoss5RocketInitFlyDestPos( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int init_acc, int init_spd, int max_spd, AppMain.VecFx32 launch_pos, ref AppMain.VecFx32 dest_pos )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        rkt_work.acc = init_acc;
        rkt_work.max_spd = max_spd;
        int num = AppMain.nnArcTan2((double)AppMain.FX_FX32_TO_F32(dest_pos.y - launch_pos.y), (double)AppMain.FX_FX32_TO_F32(dest_pos.x - launch_pos.x));
        rkt_work.move_dir = num;
        int v = AppMain.FX_F32_TO_FX32(AppMain.nnCos(rkt_work.move_dir));
        int v2 = AppMain.FX_F32_TO_FX32(AppMain.nnSin(rkt_work.move_dir));
        obs_OBJECT_WORK.spd_add.x = AppMain.FX_Mul( rkt_work.acc, v );
        obs_OBJECT_WORK.spd_add.y = AppMain.FX_Mul( rkt_work.acc, v2 );
        obs_OBJECT_WORK.spd_add.z = 0;
        obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( init_spd, v );
        obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( init_spd, v2 );
        rkt_work.launch_pos = launch_pos;
        rkt_work.dest_pos = dest_pos;
        return num;
    }

    // Token: 0x0600106C RID: 4204 RVA: 0x00090B4C File Offset: 0x0008ED4C
    public static void gmBoss5RocketInitFlyDestDistance( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int init_acc, int init_spd, int max_spd, ref AppMain.VecFx32 launch_pos, int angle, int distance )
    {
        AppMain.VecFx32 vecFx;
        vecFx.x = launch_pos.x + AppMain.FX_Mul( distance, AppMain.FX_F32_TO_FX32( AppMain.nnCos( angle ) ) );
        vecFx.y = launch_pos.y + AppMain.FX_Mul( distance, AppMain.FX_F32_TO_FX32( AppMain.nnSin( angle ) ) );
        vecFx.z = 0;
        AppMain.gmBoss5RocketInitFlyDestPos( rkt_work, init_acc, init_spd, max_spd, launch_pos, ref vecFx );
    }

    // Token: 0x0600106D RID: 4205 RVA: 0x00090BB8 File Offset: 0x0008EDB8
    public static void gmBoss5RocketRedirectFlyDestPos( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int init_acc, ref AppMain.VecFx32 dest_pos )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.VecFx32 spd = obs_OBJECT_WORK.spd;
        AppMain.gmBoss5RocketInitFlyDestPos( rkt_work, init_acc, 4096, rkt_work.max_spd, obs_OBJECT_WORK.pos, ref dest_pos );
        obs_OBJECT_WORK.spd.Assign( spd );
    }

    // Token: 0x0600106E RID: 4206 RVA: 0x00090BF9 File Offset: 0x0008EDF9
    public static int gmBoss5RocketUpdateFlyDest( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        return AppMain.gmBoss5RocketUpdateFlyDest( rkt_work, 0 );
    }

    // Token: 0x0600106F RID: 4207 RVA: 0x00090C04 File Offset: 0x0008EE04
    public static int gmBoss5RocketUpdateFlyDest( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int b_mdl_center )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        int num = AppMain.FX_Sqrt(AppMain.FX_Mul(obs_OBJECT_WORK.spd.x, obs_OBJECT_WORK.spd.x) + AppMain.FX_Mul(obs_OBJECT_WORK.spd.y, obs_OBJECT_WORK.spd.y));
        if ( num >= rkt_work.max_spd )
        {
            obs_OBJECT_WORK.spd_add.x = ( obs_OBJECT_WORK.spd_add.y = ( obs_OBJECT_WORK.spd_add.z = 0 ) );
        }
        AppMain.amVectorSet( nns_VECTOR, AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.x ), AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.y ), 0f );
        if ( b_mdl_center != 0 )
        {
            AppMain.gmBoss5RocketGetDispOfst( rkt_work, ref vecFx );
        }
        AppMain.amVectorSet( nns_VECTOR2, AppMain.FX_FX32_TO_F32( rkt_work.dest_pos.x - ( obs_OBJECT_WORK.pos.x + vecFx.x ) ), AppMain.FX_FX32_TO_F32( rkt_work.dest_pos.y - ( obs_OBJECT_WORK.pos.y + vecFx.y ) ), 0f );
        int result = (AppMain.nnDotProductVector(nns_VECTOR, nns_VECTOR2) <= 0f) ? 1 : 0;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        return result;
    }

    // Token: 0x06001070 RID: 4208 RVA: 0x00090D49 File Offset: 0x0008EF49
    public static void gmBoss5RocketInitFlyReverse( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int acc_scalar )
    {
        AppMain.gmBoss5RocketInitFlyReverse( rkt_work, acc_scalar, 0 );
    }

    // Token: 0x06001071 RID: 4209 RVA: 0x00090D54 File Offset: 0x0008EF54
    public static void gmBoss5RocketInitFlyReverse( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int acc_scalar, int is_add )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, -AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.x ), -AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.y ), 0f );
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(AppMain.FX_Mul(AppMain.FX_F32_TO_FX32(nns_VECTOR.x), acc_scalar), AppMain.FX_Mul(AppMain.FX_F32_TO_FX32(nns_VECTOR.y), acc_scalar), 0);
        AppMain.gmBoss5RocketInitFlyReverseVec( rkt_work, ref vecFx, is_add );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06001072 RID: 4210 RVA: 0x00090DE1 File Offset: 0x0008EFE1
    public static void gmBoss5RocketInitFlyReverseVec( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, ref AppMain.VecFx32 acc_vec )
    {
        AppMain.gmBoss5RocketInitFlyReverseVec( rkt_work, ref acc_vec, 0 );
    }

    // Token: 0x06001073 RID: 4211 RVA: 0x00090DEC File Offset: 0x0008EFEC
    public static void gmBoss5RocketInitFlyReverseVec( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, ref AppMain.VecFx32 acc_vec, int is_add )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        rkt_work.rvs_acc.x = acc_vec.x;
        rkt_work.rvs_acc.y = acc_vec.y;
        rkt_work.rvs_acc.z = 0;
        if ( is_add != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.spd_add.x = obs_OBJECT_WORK2.spd_add.x + rkt_work.rvs_acc.x;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.spd_add.y = obs_OBJECT_WORK3.spd_add.y + rkt_work.rvs_acc.y;
            obs_OBJECT_WORK.spd_add.z = 0;
            return;
        }
        obs_OBJECT_WORK.spd_add.Assign( rkt_work.rvs_acc );
    }

    // Token: 0x06001074 RID: 4212 RVA: 0x00090E8C File Offset: 0x0008F08C
    public static int gmBoss5RocketUpdateFlyReverse( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, AppMain.FX_FX32_TO_F32( rkt_work.rvs_acc.x ), AppMain.FX_FX32_TO_F32( rkt_work.rvs_acc.y ), 0f );
        AppMain.amVectorSet( nns_VECTOR2, AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.x ), AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.y ), 0f );
        int result = (AppMain.nnDotProductVector(nns_VECTOR, nns_VECTOR2) >= 0f) ? 1 : 0;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        return result;
    }

    // Token: 0x06001075 RID: 4213 RVA: 0x00090F24 File Offset: 0x0008F124
    public static void gmBoss5RocketSetInitialDir( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.OBS_OBJECT_WORK parent_obj = obs_OBJECT_WORK.parent_obj;
        if ( ( parent_obj.disp_flag & 1U ) != 0U )
        {
            obs_OBJECT_WORK.dir.z = ( ushort )AppMain.GMD_BOSS5_RKT_SEARCH_INITIAL_DIR_Z_L;
        }
        else
        {
            obs_OBJECT_WORK.dir.z = ( ushort )AppMain.GMD_BOSS5_RKT_SEARCH_INITIAL_DIR_Z_R;
        }
        if ( rkt_work.rkt_type == 1 )
        {
            obs_OBJECT_WORK.dir.x = ( ushort )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.x + AppMain.GMD_BOSS5_RKT_SEARCH_INITIAL_ADJ_DIR_X_RA ) );
            return;
        }
        obs_OBJECT_WORK.dir.x = ( ushort )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.x + AppMain.GMD_BOSS5_RKT_SEARCH_INITIAL_ADJ_DIR_X_LA ) );
    }

    // Token: 0x06001076 RID: 4214 RVA: 0x00090FC1 File Offset: 0x0008F1C1
    public static void gmBoss5RocketUpdateDirFollowingPos( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, ref AppMain.VecFx32 targ_pos, float deg, int is_reverse )
    {
        AppMain.gmBoss5RocketUpdateDirFollowingPos( rkt_work, targ_pos, deg, is_reverse, 0 );
    }

    // Token: 0x06001077 RID: 4215 RVA: 0x00090FD4 File Offset: 0x0008F1D4
    public static void gmBoss5RocketUpdateDirFollowingPos( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, AppMain.VecFx32 targ_pos, float deg, int is_reverse, int force_rot_spd )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( is_reverse != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.dir.z = ( ushort )( obs_OBJECT_WORK2.dir.z - ( ushort )AppMain.AKM_DEGtoA32( 180 ) );
        }
        int num = (int)(65535L & (long)AppMain.nnArcTan2((double)AppMain.FX_FX32_TO_F32(targ_pos.y - obs_OBJECT_WORK.pos.y), (double)AppMain.FX_FX32_TO_F32(targ_pos.x - obs_OBJECT_WORK.pos.x)));
        int num2 = (int)(65535L & (long)(num - (int)obs_OBJECT_WORK.dir.z));
        int num3;
        if ( num2 >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            num2 = -( AppMain.AKM_DEGtoA32( 360 ) - num2 );
            num3 = AppMain.AKM_DEGtoA32( -deg );
        }
        else
        {
            num3 = AppMain.AKM_DEGtoA32( deg );
        }
        if ( AppMain.MTM_MATH_ABS( num2 ) <= AppMain.MTM_MATH_ABS( num3 ) )
        {
            num3 = num2;
        }
        if ( is_reverse != 0 )
        {
            num3 += AppMain.AKM_DEGtoA32( 180 );
        }
        if ( force_rot_spd != 0 )
        {
            num3 = force_rot_spd;
        }
        obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.z + num3 ) ) );
    }

    // Token: 0x06001078 RID: 4216 RVA: 0x000910D8 File Offset: 0x0008F2D8
    public static void gmBoss5RocketUpdateDirPlyLockOn( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, ref AppMain.VecFx32 lock_pos )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.OBS_OBJECT_WORK parent_obj = obs_OBJECT_WORK.parent_obj;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        if ( ( parent_obj.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK2.pos.x >= obs_OBJECT_WORK.pos.x )
            {
                AppMain.gmBoss5RocketUpdateDirFollowingPos( rkt_work, lock_pos, 1f, 0, AppMain.AKM_DEGtoA32( 1f ) );
            }
            else
            {
                AppMain.gmBoss5RocketUpdateDirFollowingPos( rkt_work, ref lock_pos, 1f, 0 );
            }
            AppMain.gmBoss5RocketLimitDir( rkt_work, AppMain.GMD_BOSS5_RKT_LOCKON_DIR_LIMIT_L_START, AppMain.GMD_BOSS5_RKT_LOCKON_DIR_LIMIT_L_END );
            return;
        }
        if ( obs_OBJECT_WORK2.pos.x <= obs_OBJECT_WORK.pos.x )
        {
            AppMain.gmBoss5RocketUpdateDirFollowingPos( rkt_work, lock_pos, 1f, 0, AppMain.AKM_DEGtoA32( -1f ) );
        }
        else
        {
            AppMain.gmBoss5RocketUpdateDirFollowingPos( rkt_work, ref lock_pos, 1f, 0 );
        }
        AppMain.gmBoss5RocketLimitDir( rkt_work, AppMain.GMD_BOSS5_RKT_LOCKON_DIR_LIMIT_R_START, AppMain.GMD_BOSS5_RKT_LOCKON_DIR_LIMIT_R_END );
    }

    // Token: 0x06001079 RID: 4217 RVA: 0x000911AC File Offset: 0x0008F3AC
    public static void gmBoss5RocketUpdateDirFollowingAccSpd( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, float deg, int is_reverse )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( is_reverse != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.dir.z = ( ushort )( obs_OBJECT_WORK2.dir.z - ( ushort )AppMain.AKM_DEGtoA32( 180 ) );
        }
        int num = AppMain.nnArcTan2((double)AppMain.FX_FX32_TO_F32(obs_OBJECT_WORK.spd.y), (double)AppMain.FX_FX32_TO_F32(obs_OBJECT_WORK.spd.x));
        int num2 = (int)(65535L & (long)(num - (int)obs_OBJECT_WORK.dir.z));
        if ( num2 >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            num2 = -( AppMain.AKM_DEGtoA32( 360 ) - num2 );
        }
        int num4;
        if ( obs_OBJECT_WORK.spd_add.x != 0 || obs_OBJECT_WORK.spd_add.y != 0 )
        {
            int num3 = AppMain.nnArcTan2((double)AppMain.FX_FX32_TO_F32(obs_OBJECT_WORK.spd_add.y), (double)AppMain.FX_FX32_TO_F32(obs_OBJECT_WORK.spd_add.x));
            num4 = ( int )( 65535L & ( long )( num3 - ( int )obs_OBJECT_WORK.dir.z ) );
            if ( num4 >= AppMain.AKM_DEGtoA32( 180 ) )
            {
                num4 = -( AppMain.AKM_DEGtoA32( 360 ) - num4 );
            }
        }
        else
        {
            num4 = num2;
        }
        int num5 = (int)(65535L & (long)((num4 + num2) / 2));
        int num6;
        if ( num5 >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            num5 = -( AppMain.AKM_DEGtoA32( 360 ) - num5 );
            num6 = AppMain.AKM_DEGtoA32( -deg );
        }
        else
        {
            num6 = AppMain.AKM_DEGtoA32( deg );
        }
        if ( AppMain.MTM_MATH_ABS( num5 ) < AppMain.MTM_MATH_ABS( num6 ) )
        {
            num6 = num5;
        }
        if ( is_reverse != 0 )
        {
            num6 += AppMain.AKM_DEGtoA32( 180 );
        }
        obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.z + num6 ) ) );
    }

    // Token: 0x0600107A RID: 4218 RVA: 0x0009133C File Offset: 0x0008F53C
    public static void gmBoss5RocketLimitDir( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work, int start_angle, int end_angle )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        int num = (int)(65535L & (long)obs_OBJECT_WORK.dir.z);
        int num2 = (int)(65535L & (long)(num - start_angle));
        int num3 = (int)(65535L & (long)(end_angle - start_angle));
        if ( num2 > num3 )
        {
            int num4 = num3 / 2 + AppMain.AKM_DEGtoA32(180);
            if ( num2 >= num4 )
            {
                obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )start_angle ) );
                return;
            }
            obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )end_angle ) );
        }
    }

    // Token: 0x0600107B RID: 4219 RVA: 0x000913C8 File Offset: 0x0008F5C8
    public static void gmBoss5RocketInitDirFalling( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        rkt_work.pivot_fall_angle = AppMain.AKM_DEGtoA32( 90 );
        rkt_work.wobble_sin_param_angle = AppMain.AKM_DEGtoA32( 0 );
        obs_OBJECT_WORK.dir.z = ( ushort )( 65535L & ( long )rkt_work.pivot_fall_angle );
    }

    // Token: 0x0600107C RID: 4220 RVA: 0x00091410 File Offset: 0x0008F610
    public static void gmBoss5RocketUpdateDirFalling( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        obs_OBJECT_WORK.dir.x = ( ushort )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.x + AppMain.GMD_BOSS5_RKT_FALL_SPIN_ANGLE_SPD ) );
        rkt_work.wobble_sin_param_angle += AppMain.GMD_BOSS5_RKT_FALL_WOBBLE_SIN_PARAM_DEG_SPD;
        rkt_work.wobble_sin_param_angle = ( int )( 65535L & ( long )rkt_work.wobble_sin_param_angle );
        obs_OBJECT_WORK.dir.z = ( ushort )( 65535L & ( long )( rkt_work.pivot_fall_angle + AppMain.AKM_DEGtoA32( 15f * AppMain.nnSin( rkt_work.wobble_sin_param_angle ) ) ) );
    }

    // Token: 0x0600107D RID: 4221 RVA: 0x000914A4 File Offset: 0x0008F6A4
    public static void gmBoss5RocketEndDirFalling( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        rkt_work.pivot_fall_angle = 0;
        rkt_work.wobble_sin_param_angle = 0;
        obs_OBJECT_WORK.dir.z = ( ushort )AppMain.AKM_DEGtoA32( 90 );
    }

    // Token: 0x0600107E RID: 4222 RVA: 0x000914D9 File Offset: 0x0008F6D9
    public static void gmBoss5RocketInitLeakageFlicker( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.wfall_atk_toggle_timer = 0U;
        rkt_work.flag &= 4294967287U;
    }

    // Token: 0x0600107F RID: 4223 RVA: 0x000914F4 File Offset: 0x0008F6F4
    public static int gmBoss5RocketUpdateLeakageFlicker( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( rkt_work.wfall_atk_toggle_timer != 0U )
        {
            rkt_work.wfall_atk_toggle_timer -= 1U;
        }
        else
        {
            rkt_work.wfall_atk_toggle_timer = 39U;
        }
        if ( rkt_work.wfall_atk_toggle_timer < 20U )
        {
            rkt_work.flag &= 4294967287U;
            return 0;
        }
        rkt_work.flag |= 8U;
        return 1;
    }

    // Token: 0x06001080 RID: 4224 RVA: 0x0009154B File Offset: 0x0008F74B
    public static void gmBoss5RocketClearLeakageFlicker( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.wfall_atk_toggle_timer = 0U;
        rkt_work.flag &= 4294967287U;
    }

    // Token: 0x06001081 RID: 4225 RVA: 0x00091564 File Offset: 0x0008F764
    public static void gmBoss5RocketInitFlyBlow( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        obs_OBJECT_WORK.move_flag |= 16U;
        obs_OBJECT_WORK.move_flag &= 4294967166U;
        rkt_work.launch_pos.Assign( obs_OBJECT_WORK.pos );
        rkt_work.dest_pos.Assign( gms_BOSS5_BODY_WORK.part_obj_core.pos );
        int ang = AppMain.nnArcTan2((double)AppMain.FX_FX32_TO_F32(rkt_work.dest_pos.y - obs_OBJECT_WORK.pos.y), (double)AppMain.FX_FX32_TO_F32(rkt_work.dest_pos.x - obs_OBJECT_WORK.pos.x));
        int v = AppMain.FX_F32_TO_FX32(AppMain.nnCos(ang));
        int v2 = AppMain.FX_F32_TO_FX32(AppMain.nnSin(ang));
        obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( 49152, v );
        obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( 49152, v2 );
        obs_OBJECT_WORK.spd.z = 0;
        if ( obs_OBJECT_WORK.spd.x < 0 )
        {
            rkt_work.rot_spd = -AppMain.GMD_BOSS5_RKT_BLOW_FLY_ROT_SPD;
            return;
        }
        rkt_work.rot_spd = AppMain.GMD_BOSS5_RKT_BLOW_FLY_ROT_SPD;
    }

    // Token: 0x06001082 RID: 4226 RVA: 0x00091684 File Offset: 0x0008F884
    public static int gmBoss5RocketUpdateFlyBlow( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.z + rkt_work.rot_spd ) ) );
        AppMain.amVectorSet( nns_VECTOR, AppMain.FX_FX32_TO_F32( rkt_work.dest_pos.x - rkt_work.launch_pos.x ), AppMain.FX_FX32_TO_F32( rkt_work.dest_pos.y - rkt_work.launch_pos.y ), 0f );
        AppMain.amVectorSet( nns_VECTOR2, AppMain.FX_FX32_TO_F32( rkt_work.dest_pos.x - obs_OBJECT_WORK.pos.x ), AppMain.FX_FX32_TO_F32( rkt_work.dest_pos.y - obs_OBJECT_WORK.pos.y ), 0f );
        int result = (AppMain.nnDotProductVector(nns_VECTOR, nns_VECTOR2) <= 0f) ? 1 : 0;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        return result;
    }

    // Token: 0x06001083 RID: 4227 RVA: 0x00091774 File Offset: 0x0008F974
    public static void gmBoss5RocketInitFlyBounce( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        obs_OBJECT_WORK.move_flag |= 16U;
        obs_OBJECT_WORK.move_flag &= 4294967166U;
        int v = AppMain.FX_F32_TO_FX32(AppMain.nnCos(AppMain.GMD_BOSS5_RKT_BOUNCE_DIR_ANGLE));
        int v2 = AppMain.FX_F32_TO_FX32(AppMain.nnSin(AppMain.GMD_BOSS5_RKT_BOUNCE_DIR_ANGLE));
        int num = 0;
        if ( obs_OBJECT_WORK.spd.x < 0 )
        {
            num = 1;
        }
        obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( 16384, v );
        obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( 16384, v2 );
        obs_OBJECT_WORK.spd.z = 0;
        if ( num != 0 )
        {
            obs_OBJECT_WORK.spd.x = -obs_OBJECT_WORK.spd.x;
        }
        if ( obs_OBJECT_WORK.spd.x < 0 )
        {
            rkt_work.rot_spd = -AppMain.GMD_BOSS5_RKT_BOUNCE_FLY_ROT_SPD;
            return;
        }
        rkt_work.rot_spd = AppMain.GMD_BOSS5_RKT_BOUNCE_FLY_ROT_SPD;
    }

    // Token: 0x06001084 RID: 4228 RVA: 0x00091854 File Offset: 0x0008FA54
    public static int gmBoss5RocketUpdateFlyBounce( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )( ( int )obs_OBJECT_WORK.dir.z + rkt_work.rot_spd ) ) );
        if ( obs_OBJECT_WORK.pos.y <= AppMain.GMM_BOSS5_AREA_TOP() - 196608 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001085 RID: 4229 RVA: 0x000918AC File Offset: 0x0008FAAC
    public static void gmBoss5RocketInitStuckLean( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        rkt_work.stuck_dir = ( int )obs_OBJECT_WORK.dir.z;
        rkt_work.stuck_lean_ratio = 0f;
    }

    // Token: 0x06001086 RID: 4230 RVA: 0x000918DC File Offset: 0x0008FADC
    public static int gmBoss5RocketUpdateStuckLean( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.OBS_OBJECT_WORK parent_obj = obs_OBJECT_WORK.parent_obj;
        int result = 1;
        int num = 0;
        rkt_work.hit_vib_amp_deg -= 0.5f;
        if ( rkt_work.hit_vib_amp_deg <= 0f )
        {
            rkt_work.hit_vib_amp_deg = 0f;
        }
        rkt_work.hit_vib_sin_angle = ( int )( 65535L & ( long )( rkt_work.hit_vib_sin_angle + AppMain.GMD_BOSS5_RKT_GRD_STUCK_LEAN_HIT_VIB_SIN_ANGLE_ADD ) );
        float num2 = AppMain.nnSin(rkt_work.hit_vib_sin_angle) * rkt_work.hit_vib_amp_deg;
        float num3;
        if ( ( rkt_work.flag & 128U ) != 0U )
        {
            float stuck_lean_ratio = rkt_work.stuck_lean_ratio;
            if ( rkt_work.stuck_lean_ratio < 1f )
            {
                rkt_work.stuck_lean_ratio += 0.075f;
                result = 0;
            }
            rkt_work.stuck_lean_ratio = AppMain.MTM_MATH_CLIP( rkt_work.stuck_lean_ratio, 0f, 1f );
            num3 = 180f * rkt_work.stuck_lean_ratio - num2;
            num = ( int )( 131072f * ( rkt_work.stuck_lean_ratio - stuck_lean_ratio ) );
            AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -16, -16, 16, ( short )( 16 + ( short )( rkt_work.stuck_lean_ratio * 8f ) ) );
        }
        else
        {
            num3 = ( float )rkt_work.hit_count * -10f + num2;
        }
        if ( obs_OBJECT_WORK.pos.x < parent_obj.pos.x )
        {
            num3 = -num3;
            num = -num;
        }
        obs_OBJECT_WORK.dir.z = ( ushort )( 65535L & ( long )( rkt_work.stuck_dir + AppMain.AKM_DEGtoA32( num3 ) ) );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + num;
        return result;
    }

    // Token: 0x06001087 RID: 4231 RVA: 0x00091A58 File Offset: 0x0008FC58
    public static void gmBoss5RocketSetStuckLeanHitVib( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        rkt_work.hit_vib_amp_deg = 10f;
        rkt_work.hit_vib_sin_angle = AppMain.AKM_DEGtoA32( 0 );
    }

    // Token: 0x06001088 RID: 4232 RVA: 0x00091A74 File Offset: 0x0008FC74
    public static void gmBoss5RocketInitScatter( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GmBoss5ScatterSetFlyParam( obs_OBJECT_WORK );
        AppMain.AkMathNormalizeMtx( nns_MATRIX, obs_OBJECT_WORK.obj_3d.user_obj_mtx_r );
        AppMain.nnMakeRotateMatrixQuaternion( out rkt_work.sct_cur_quat, nns_MATRIX );
        AppMain.nnMakeUnitQuaternion( ref rkt_work.sct_spin_quat );
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            float num = AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()) * 2f - 1f;
            num = AppMain.MTM_MATH_CLIP( num, -1f, 1f );
            short rand_angle = AppMain.AKM_DEGtoA16(360f * AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()));
            AppMain.AkMathGetRandomUnitVector( nns_VECTOR, num, rand_angle );
            AppMain.NNS_QUATERNION nns_QUATERNION;
            AppMain.nnMakeRotateAxisQuaternion( out nns_QUATERNION, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z, AppMain.GMD_BOSS5_SCT_SPIN_SPD_ANGLE );
            AppMain.nnMultiplyQuaternion( ref rkt_work.sct_spin_quat, ref nns_QUATERNION, ref rkt_work.sct_spin_quat );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06001089 RID: 4233 RVA: 0x00091B60 File Offset: 0x0008FD60
    public static void gmBoss5RocketUpdateScatter( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.nnMultiplyQuaternion( ref rkt_work.sct_cur_quat, ref rkt_work.sct_spin_quat, ref rkt_work.sct_cur_quat );
        AppMain.nnMakeQuaternionMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, ref rkt_work.sct_cur_quat );
        obs_OBJECT_WORK.disp_flag |= 16777216U;
    }

    // Token: 0x0600108A RID: 4234 RVA: 0x00091BB4 File Offset: 0x0008FDB4
    public static int gmBoss5RocketReceiveSignalLaunch( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( rkt_work.rkt_type == 0 && ( gms_BOSS5_BODY_WORK.flag & 268435456U ) != 0U )
        {
            gms_BOSS5_BODY_WORK.flag &= 4026531839U;
            return 1;
        }
        if ( rkt_work.rkt_type == 1 && ( gms_BOSS5_BODY_WORK.flag & 134217728U ) != 0U )
        {
            gms_BOSS5_BODY_WORK.flag &= 4160749567U;
            return 1;
        }
        return 0;
    }

    // Token: 0x0600108B RID: 4235 RVA: 0x00091C2C File Offset: 0x0008FE2C
    public static int gmBoss5RocketReceiveSignalReturn( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( rkt_work.rkt_type == 0 && ( gms_BOSS5_BODY_WORK.flag & 1073741824U ) != 0U )
        {
            gms_BOSS5_BODY_WORK.flag &= 3221225471U;
            return 1;
        }
        if ( rkt_work.rkt_type == 1 && ( gms_BOSS5_BODY_WORK.flag & 536870912U ) != 0U )
        {
            gms_BOSS5_BODY_WORK.flag &= 3758096383U;
            return 1;
        }
        return 0;
    }

    // Token: 0x0600108C RID: 4236 RVA: 0x00091CA4 File Offset: 0x0008FEA4
    public static void gmBoss5RocketDispatchSignalReturned( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( rkt_work.rkt_type == 0 )
        {
            gms_BOSS5_BODY_WORK.flag |= 67108864U;
            return;
        }
        if ( rkt_work.rkt_type == 1 )
        {
            gms_BOSS5_BODY_WORK.flag |= 33554432U;
        }
    }

    // Token: 0x0600108D RID: 4237 RVA: 0x00091CFC File Offset: 0x0008FEFC
    public static void gmBoss5RocketInitCallbacks( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GmBsCmnInitBossMotionCBSystem( obs_OBJECT_WORK, rkt_work.bmcb_mgr );
        AppMain.GmBsCmnCreateSNMWork( rkt_work.snm_work, obs_OBJECT_WORK.obj_3d._object, 1 );
        AppMain.GmBsCmnAppendBossMotionCallback( rkt_work.bmcb_mgr, rkt_work.snm_work.bmcb_link );
        rkt_work.drill_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( rkt_work.snm_work, 3 );
    }

    // Token: 0x0600108E RID: 4238 RVA: 0x00091D5C File Offset: 0x0008FF5C
    public static void gmBoss5RocketReleaseCallbacks( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GmBsCmnClearBossMotionCBSystem( obj_work );
        AppMain.GmBsCmnDeleteSNMWork( rkt_work.snm_work );
    }

    // Token: 0x0600108F RID: 4239 RVA: 0x00091D84 File Offset: 0x0008FF84
    public static void gmBoss5RocketAtkPlyHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)my_rect.parent_obj;
        gms_BOSS5_ROCKET_WORK.flag |= 1U;
        AppMain.GmEnemyDefaultAtkFunc( my_rect, your_rect );
    }

    // Token: 0x06001090 RID: 4240 RVA: 0x00091DB4 File Offset: 0x0008FFB4
    public static void gmBoss5RocketAtkBossHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        AppMain.GMS_BOSS5_ROCKET_WORK rkt_work = (AppMain.GMS_BOSS5_ROCKET_WORK)parent_obj;
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)parent_obj2;
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 330 )
        {
            parent_obj.flag |= 2U;
            AppMain.gmBoss5RocketBounceProcInit( rkt_work );
            return;
        }
        AppMain.ObjRectFuncNoHit( my_rect, your_rect );
    }

    // Token: 0x06001091 RID: 4241 RVA: 0x00091E0C File Offset: 0x0009000C
    public static void gmBoss5RocketDamageDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj = your_rect.parent_obj;
        if ( parent_obj != null && 1 == parent_obj.obj_type )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj;
            if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
            {
                return;
            }
            int num = AppMain.gmBoss5RocketSetPlyRebound(my_rect, your_rect);
            if ( ( gms_BOSS5_ROCKET_WORK.flag & 2U ) != 0U )
            {
                if ( num != 0 )
                {
                    gms_BOSS5_ROCKET_WORK.hit_count += 1U;
                    if ( gms_BOSS5_ROCKET_WORK.hit_count >= 3U )
                    {
                        AppMain.gmBoss5RocketClearLeakageFlicker( gms_BOSS5_ROCKET_WORK );
                        AppMain.gmBoss5RocketBlowProcInit( gms_BOSS5_ROCKET_WORK );
                    }
                    else
                    {
                        AppMain.gmBoss5RocketSetNoHitTime( gms_BOSS5_ROCKET_WORK );
                        AppMain.gmBoss5RocketSetStuckLeanHitVib( gms_BOSS5_ROCKET_WORK );
                    }
                }
                else
                {
                    AppMain.gmBoss5RocketSetDmgEnable( gms_BOSS5_ROCKET_WORK, 0 );
                    AppMain.GmBoss5EfctCreateRocketRollSpark( gms_BOSS5_ROCKET_WORK );
                    gms_BOSS5_ROCKET_WORK.flag |= 128U;
                }
            }
            else
            {
                AppMain.gmBoss5RocketClearLeakageFlicker( gms_BOSS5_ROCKET_WORK );
                AppMain.gmBoss5RocketBlowProcInit( gms_BOSS5_ROCKET_WORK );
            }
            AppMain.GmSoundPlaySE( "Boss0_01" );
        }
    }

    // Token: 0x06001092 RID: 4242 RVA: 0x00091ED4 File Offset: 0x000900D4
    public static void gmBoss5RocketOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)obj_work;
        AppMain.ObjDrawActionSummary( obj_work );
        gms_BOSS5_ROCKET_WORK.pivot_prev_pos.Assign( obj_work.pos );
    }

    // Token: 0x06001093 RID: 4243 RVA: 0x00091F00 File Offset: 0x00090100
    public static void gmBoss5RocketMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_ROCKET_WORK gms_BOSS5_ROCKET_WORK = (AppMain.GMS_BOSS5_ROCKET_WORK)obj_work;
        if ( ( gms_BOSS5_ROCKET_WORK.flag & 2U ) != 0U && ( gms_BOSS5_ROCKET_WORK.flag & 128U ) == 0U )
        {
            AppMain.gmBoss5RocketUpdateNoHitTime( gms_BOSS5_ROCKET_WORK );
        }
        if ( gms_BOSS5_ROCKET_WORK.proc_update != null )
        {
            gms_BOSS5_ROCKET_WORK.proc_update( gms_BOSS5_ROCKET_WORK );
        }
        if ( ( gms_BOSS5_ROCKET_WORK.flag & 8U ) != 0U )
        {
            AppMain.GmBoss5EfctTryStartRocketLeakage( gms_BOSS5_ROCKET_WORK );
        }
        else
        {
            AppMain.GmBoss5EfctEndRocketLeakage( gms_BOSS5_ROCKET_WORK );
        }
        AppMain.gmBoss5RocketUpdateMainRectPosition( gms_BOSS5_ROCKET_WORK );
    }

    // Token: 0x06001094 RID: 4244 RVA: 0x00091F64 File Offset: 0x00090164
    public static void gmBoss5RocketNmlProcInit( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.gmBoss5RocketSetInitialDir( rkt_work );
        AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketInitPlySearch( rkt_work, 20 );
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketNmlProcUpdateFace );
    }

    // Token: 0x06001095 RID: 4245 RVA: 0x00091F9C File Offset: 0x0009019C
    public static void gmBoss5RocketNmlProcUpdateFace( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 0 );
        AppMain.gmBoss5RocketUpdatePlySearch( rkt_work );
        AppMain.VecFx32 vecFx;
        AppMain.gmBoss5RocketGetPlySearchPos( rkt_work, out vecFx );
        AppMain.gmBoss5RocketUpdateDirPlyLockOn( rkt_work, ref vecFx );
        if ( AppMain.gmBoss5RocketReceiveSignalLaunch( rkt_work ) != 0 )
        {
            AppMain.gmBoss5RocketInitFlyDestDistance( rkt_work, 4096, 40960, 49152, ref obs_OBJECT_WORK.pos, ( int )obs_OBJECT_WORK.dir.z, 786432 );
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
            AppMain.GmBoss5EfctCreateRocketLaunch( rkt_work );
            AppMain.GmSoundPlaySE( "FinalBoss07" );
            AppMain.GmBoss5EfctStartRocketJet( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketNmlProcUpdateFly );
        }
    }

    // Token: 0x06001096 RID: 4246 RVA: 0x0009202F File Offset: 0x0009022F
    public static void gmBoss5RocketNmlProcUpdateFly( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( AppMain.gmBoss5RocketUpdateFlyDest( rkt_work ) != 0 )
        {
            AppMain.gmBoss5RocketInitFlyReverse( rkt_work, 4096, 0 );
            AppMain.GmBoss5EfctEndRocketJet( rkt_work );
            AppMain.GmBoss5EfctStartRocketJetReverse( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketNmlProcUpdateWaitDecel );
        }
    }

    // Token: 0x06001097 RID: 4247 RVA: 0x00092064 File Offset: 0x00090264
    public static void gmBoss5RocketNmlProcUpdateWaitDecel( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( AppMain.gmBoss5RocketUpdateFlyReverse( rkt_work ) != 0 )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            AppMain.VecFx32 vecFx;
            AppMain.gmBoss5RocketGetArmNodePosFx( rkt_work, out vecFx );
            int num = AppMain.gmBoss5RocketInitFlyDestPos(rkt_work, 2048, 0, 40960, obs_OBJECT_WORK.pos, ref vecFx);
            obs_OBJECT_WORK.dir.z = ( ushort )( ( short )( 65535L & ( long )( num + AppMain.AKM_DEGtoA32( 180 ) ) ) );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketNmlProcUpdateWaitReturn );
        }
    }

    // Token: 0x06001098 RID: 4248 RVA: 0x000920DC File Offset: 0x000902DC
    public static void gmBoss5RocketNmlProcUpdateWaitReturn( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( AppMain.gmBoss5RocketUpdateFlyDest( rkt_work, 1 ) != 0 )
        {
            AppMain.gmBoss5RocketDispatchSignalReturned( rkt_work );
            AppMain.GmBoss5EfctEndRocketJet( rkt_work );
            AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
            AppMain.GmBoss5EfctCreateRocketDock( body_work, rkt_work.rkt_type );
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketNmlProcUpdateFinalize );
        }
    }

    // Token: 0x06001099 RID: 4249 RVA: 0x00092138 File Offset: 0x00090338
    public static void gmBoss5RocketNmlProcUpdateFinalize( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.flag |= 4U;
    }

    // Token: 0x0600109A RID: 4250 RVA: 0x00092160 File Offset: 0x00090360
    public static void gmBoss5RocketStrProcInit( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.gmBoss5RocketSetInitialDir( rkt_work );
        AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketInitPlySearch( rkt_work, 20 );
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateFace );
    }

    // Token: 0x0600109B RID: 4251 RVA: 0x00092198 File Offset: 0x00090398
    public static void gmBoss5RocketStrProcUpdateFace( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 0 );
        AppMain.gmBoss5RocketUpdatePlySearch( rkt_work );
        AppMain.VecFx32 vecFx;
        AppMain.gmBoss5RocketGetPlySearchPos( rkt_work, out vecFx );
        AppMain.gmBoss5RocketUpdateDirPlyLockOn( rkt_work, ref vecFx );
        if ( AppMain.gmBoss5RocketReceiveSignalReturn( rkt_work ) != 0 )
        {
            AppMain.gmBoss5RocketInitRocketStuckWithArmLerpRot( rkt_work, 0.1f );
            AppMain.gmBoss5RocketUpdateRocketStuckWithArmLerpRot( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateRecover );
            return;
        }
        if ( AppMain.gmBoss5RocketReceiveSignalLaunch( rkt_work ) != 0 )
        {
            AppMain.gmBoss5RocketSetDispOfst( rkt_work, -10f, 1 );
            AppMain.gmBoss5RocketInitFlyDestDistance( rkt_work, 6144, 40960, 61440, ref obs_OBJECT_WORK.pos, ( int )obs_OBJECT_WORK.dir.z, 786432 );
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
            AppMain.GmBoss5EfctCreateRocketLaunch( rkt_work );
            AppMain.GmSoundPlaySE( "FinalBoss07" );
            AppMain.GmBoss5EfctStartRocketJet( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateFlyTarget );
        }
    }

    // Token: 0x0600109C RID: 4252 RVA: 0x00092264 File Offset: 0x00090464
    public static void gmBoss5RocketStrProcUpdateFlyTarget( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( AppMain.gmBoss5RocketUpdateFlyDest( rkt_work ) != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
            AppMain.VecFx32 vecFx = new AppMain.VecFx32(obs_OBJECT_WORK.pos.x, AppMain.GMM_BOSS5_AREA_TOP() - 196608, 0);
            AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(-2048, 0, 0);
            AppMain.gmBoss5RocketRedirectFlyDestPos( rkt_work, 2048, ref vecFx );
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                vecFx2.x = -vecFx2.x;
            }
            AppMain.gmBoss5RocketInitFlyReverseVec( rkt_work, ref vecFx2, 1 );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateFlyDecel );
        }
    }

    // Token: 0x0600109D RID: 4253 RVA: 0x000922F8 File Offset: 0x000904F8
    public static void gmBoss5RocketStrProcUpdateFlyDecel( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.gmBoss5RocketUpdateDirFollowingAccSpd( rkt_work, 5f, 0 );
        if ( AppMain.gmBoss5RocketUpdateFlyReverse( rkt_work ) != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
            AppMain.VecFx32 vecFx = new AppMain.VecFx32(obs_OBJECT_WORK.pos.x, AppMain.GMM_BOSS5_AREA_TOP() - 196608, 0);
            AppMain.gmBoss5RocketInitFlyDestPos( rkt_work, 2048, AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.y ), 61440, obs_OBJECT_WORK.pos, ref vecFx );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateFlyAbove );
        }
    }

    // Token: 0x0600109E RID: 4254 RVA: 0x00092380 File Offset: 0x00090580
    public static void gmBoss5RocketStrProcUpdateFlyAbove( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateDirFollowingAccSpd( rkt_work, 1f, 0 );
        if ( AppMain.gmBoss5RocketUpdateFlyDest( rkt_work ) != 0 )
        {
            AppMain.GmBsCmnSetObjSpdZero( obj_work );
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
            rkt_work.wait_timer = AppMain.gmBoss5RocketSeqGetWaitFallTime( rkt_work );
            AppMain.GmBoss5EfctEndRocketJet( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateWaitFall );
        }
    }

    // Token: 0x0600109F RID: 4255 RVA: 0x000923DC File Offset: 0x000905DC
    public static void gmBoss5RocketStrProcUpdateWaitFall( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( rkt_work.wait_timer >= 10U )
        {
            obs_OBJECT_WORK.pos.x = AppMain.GmBsCmnGetPlayerObj().pos.x;
        }
        if ( rkt_work.wait_timer != 0U )
        {
            rkt_work.wait_timer -= 1U;
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.spd.y = 8192;
        AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
        AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 1 );
        AppMain.gmBoss5RocketInitLeakageFlicker( rkt_work );
        AppMain.GmBoss5EfctStartRocketSmoke( rkt_work );
        AppMain.gmBoss5RocketInitDirFalling( rkt_work );
        gms_ENEMY_COM_WORK.enemy_flag &= 4294934527U;
        rkt_work.flag &= 4294967294U;
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateFall );
    }

    // Token: 0x060010A0 RID: 4256 RVA: 0x0009249C File Offset: 0x0009069C
    public static void gmBoss5RocketStrProcUpdateFall( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateDirFalling( rkt_work );
        if ( AppMain.gmBoss5RocketUpdateLeakageFlicker( rkt_work ) != 0 )
        {
            AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        }
        else
        {
            AppMain.gmBoss5RocketSetRectSize( rkt_work, 0 );
        }
        if ( obs_OBJECT_WORK.pos.y >= AppMain.GMM_BOSS5_AREA_TOP() )
        {
            obs_OBJECT_WORK.move_flag &= 4294967039U;
        }
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            rkt_work.flag |= 2U;
            AppMain.gmBoss5RocketSetRectSize( rkt_work, 0 );
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
            AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 1 );
            if ( ( rkt_work.flag & 1U ) != 0U )
            {
                rkt_work.wait_timer = 30U;
            }
            else
            {
                rkt_work.wait_timer = 300U;
            }
            AppMain.gmBoss5RocketClearLeakageFlicker( rkt_work );
            AppMain.GmBoss5EfctCreateRocketLandingShockwave( rkt_work );
            AppMain.GmSoundPlaySE( "FinalBoss13" );
            AppMain.gmBoss5RocketEndDirFalling( rkt_work );
            AppMain.gmBoss5RocketInitStuckLean( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateStuck );
        }
    }

    // Token: 0x060010A1 RID: 4257 RVA: 0x00092578 File Offset: 0x00090778
    public static void gmBoss5RocketStrProcUpdateStuck( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        int num = AppMain.gmBoss5RocketUpdateStuckLean(rkt_work);
        if ( num != 0 && ( rkt_work.flag & 128U ) != 0U && ( rkt_work.flag & 256U ) == 0U )
        {
            AppMain.gmBoss5RocketSetStuckLeanHitVib( rkt_work );
            rkt_work.flag |= 256U;
        }
        if ( ( rkt_work.flag & 128U ) != 0U )
        {
            rkt_work.flag |= 8U;
        }
        else
        {
            rkt_work.flag &= 4294967287U;
        }
        if ( rkt_work.wait_timer != 0U )
        {
            rkt_work.wait_timer -= 1U;
            return;
        }
        if ( num != 0 )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
            rkt_work.flag &= 4294967287U;
            AppMain.GmBoss5EfctEndRocketSmoke( rkt_work );
            AppMain.VecFx32 vecFx;
            AppMain.gmBoss5RocketGetArmNodePosFx( rkt_work, out vecFx );
            AppMain.gmBoss5RocketInitFlyDestPos( rkt_work, 1228, 0, 61440, obs_OBJECT_WORK.pos, ref vecFx );
            rkt_work.flag &= 4294967293U;
            AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
            AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 0 );
            gms_ENEMY_COM_WORK.enemy_flag |= 32768U;
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateReturn );
        }
    }

    // Token: 0x060010A2 RID: 4258 RVA: 0x0009269C File Offset: 0x0009089C
    public static void gmBoss5RocketStrProcUpdateReturn( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( ( rkt_work.flag & 128U ) != 0U )
        {
            AppMain.gmBoss5RocketUpdateDirFollowingAccSpd( rkt_work, 5f, 1 );
        }
        else
        {
            AppMain.gmBoss5RocketUpdateDirFollowingAccSpd( rkt_work, 2f, 1 );
        }
        if ( AppMain.gmBoss5RocketUpdateFlyDest( rkt_work, 1 ) != 0 )
        {
            AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
            AppMain.GmBoss5EfctCreateRocketDock( body_work, rkt_work.rkt_type );
            AppMain.gmBoss5RocketDispatchSignalReturned( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketStrProcUpdateFinalize );
        }
    }

    // Token: 0x060010A3 RID: 4259 RVA: 0x00092714 File Offset: 0x00090914
    public static void gmBoss5RocketStrProcUpdateFinalize( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.flag |= 4U;
    }

    // Token: 0x060010A4 RID: 4260 RVA: 0x0009273C File Offset: 0x0009093C
    public static void gmBoss5RocketStrProcUpdateRecover( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.gmBoss5RocketUpdateRocketStuckWithArmLerpRot( rkt_work );
        if ( ( rkt_work.rkt_type == 0 && ( gms_BOSS5_BODY_WORK.flag & 4U ) == 0U ) || ( rkt_work.rkt_type == 1 && ( gms_BOSS5_BODY_WORK.flag & 4U ) == 0U ) )
        {
            obs_OBJECT_WORK.flag |= 4U;
        }
    }

    // Token: 0x060010A5 RID: 4261 RVA: 0x00092798 File Offset: 0x00090998
    public static void gmBoss5RocketBlowProcInit( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        AppMain.GmPlayerAddScore( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 100, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y );
        AppMain.GmBoss5EfctEndRocketSmoke( rkt_work );
        rkt_work.flag &= 4294967293U;
        obs_OBJECT_WORK.move_flag |= 16U;
        obs_OBJECT_WORK.move_flag &= 4294967294U;
        gms_ENEMY_COM_WORK.enemy_flag |= 32768U;
        AppMain.gmBoss5RocketSetAtkBodyRect( rkt_work );
        AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
        AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketInitFlyBlow( rkt_work );
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketBlowProcUpdateFly );
    }

    // Token: 0x060010A6 RID: 4262 RVA: 0x00092852 File Offset: 0x00090A52
    public static void gmBoss5RocketBlowProcUpdateFly( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        if ( AppMain.gmBoss5RocketUpdateFlyBlow( rkt_work ) != 0 )
        {
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketBlowProcUpdateWaitHit );
        }
    }

    // Token: 0x060010A7 RID: 4263 RVA: 0x00092870 File Offset: 0x00090A70
    public static void gmBoss5RocketBlowProcUpdateWaitHit( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateFlyBlow( rkt_work );
        obs_OBJECT_WORK.pos.x = rkt_work.dest_pos.x;
        obs_OBJECT_WORK.pos.y = rkt_work.dest_pos.y;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
    }

    // Token: 0x060010A8 RID: 4264 RVA: 0x000928C0 File Offset: 0x00090AC0
    public static void gmBoss5RocketBounceProcInit( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 16U;
        obs_OBJECT_WORK.move_flag &= 4294967294U;
        gms_ENEMY_COM_WORK.enemy_flag |= 32768U;
        AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketInitFlyBounce( rkt_work );
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketBounceProcUpdateFlyUp );
    }

    // Token: 0x060010A9 RID: 4265 RVA: 0x00092934 File Offset: 0x00090B34
    public static void gmBoss5RocketBounceProcUpdateFlyUp( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(rkt_work);
        if ( AppMain.gmBoss5RocketUpdateFlyBounce( rkt_work ) != 0 )
        {
            AppMain.GmBsCmnSetObjSpdZero( obj_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketBounceProcUpdateWait );
        }
    }

    // Token: 0x060010AA RID: 4266 RVA: 0x00092968 File Offset: 0x00090B68
    public static void gmBoss5RocketBounceProcUpdateWait( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        if ( AppMain.gmBoss5RocketReceiveSignalReturn( rkt_work ) != 0 )
        {
            AppMain.VecFx32 vecFx;
            AppMain.gmBoss5RocketGetArmNodePosFx( rkt_work, out vecFx );
            AppMain.gmBoss5RocketInitFlyDestPos( rkt_work, 1228, 0, 61440, obs_OBJECT_WORK.pos, ref vecFx );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketBounceProcUpdateReturn );
        }
    }

    // Token: 0x060010AB RID: 4267 RVA: 0x000929B8 File Offset: 0x00090BB8
    public static void gmBoss5RocketBounceProcUpdateReturn( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateDirFollowingAccSpd( rkt_work, 5f, 1 );
        if ( AppMain.gmBoss5RocketUpdateFlyDest( rkt_work, 1 ) != 0 )
        {
            AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
            AppMain.GmBoss5EfctCreateRocketDock( body_work, rkt_work.rkt_type );
            AppMain.gmBoss5RocketDispatchSignalReturned( rkt_work );
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketBounceProcUpdateFinalize );
        }
    }

    // Token: 0x060010AC RID: 4268 RVA: 0x00092A14 File Offset: 0x00090C14
    public static void gmBoss5RocketBounceProcUpdateFinalize( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.flag |= 4U;
    }

    // Token: 0x060010AD RID: 4269 RVA: 0x00092A3C File Offset: 0x00090C3C
    public static void gmBoss5RocketCnctProcInit( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 1 );
        AppMain.gmBoss5RocketSetRectSize( rkt_work, 1 );
        AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
        AppMain.gmBoss5RocketSetDmgEnable( rkt_work, 0 );
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketCnctProcUpdateIdle );
    }

    // Token: 0x060010AE RID: 4270 RVA: 0x00092A6C File Offset: 0x00090C6C
    public static void gmBoss5RocketCnctProcUpdateIdle( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 1 );
        if ( ( rkt_work.rkt_type == 0 && ( gms_BOSS5_BODY_WORK.flag & 4U ) != 0U ) || ( rkt_work.rkt_type == 1 && ( gms_BOSS5_BODY_WORK.flag & 8U ) != 0U ) )
        {
            obs_OBJECT_WORK.disp_flag |= 32U;
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
            return;
        }
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        if ( ( gms_BOSS5_BODY_WORK.flag & 256U ) != 0U )
        {
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 1 );
        }
        else
        {
            AppMain.gmBoss5RocketSetAtkEnable( rkt_work, 0 );
        }
        if ( ( gms_BOSS5_BODY_WORK.flag & 262144U ) != 0U )
        {
            if ( rkt_work.rkt_type == 0 )
            {
                rkt_work.wait_timer = 10U;
            }
            else
            {
                rkt_work.wait_timer = 30U;
            }
            rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketCnctProcUpdateWaitScatterStart );
        }
    }

    // Token: 0x060010AF RID: 4271 RVA: 0x00092B38 File Offset: 0x00090D38
    public static void gmBoss5RocketCnctProcUpdateWaitScatterStart( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.gmBoss5RocketUpdateRocketStuckWithArm( rkt_work, 1 );
        if ( rkt_work.wait_timer != 0U )
        {
            rkt_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5RocketInitScatter( rkt_work );
        rkt_work.wait_timer = 180U;
        rkt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.gmBoss5RocketCnctProcUpdateScatter );
    }

    // Token: 0x060010B0 RID: 4272 RVA: 0x00092B88 File Offset: 0x00090D88
    public static void gmBoss5RocketCnctProcUpdateScatter( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(rkt_work);
        AppMain.gmBoss5RocketUpdateScatter( rkt_work );
        if ( rkt_work.wait_timer != 0U )
        {
            rkt_work.wait_timer -= 1U;
            return;
        }
        obs_OBJECT_WORK.flag |= 4U;
    }

    // Token: 0x060010B1 RID: 4273 RVA: 0x00092BC8 File Offset: 0x00090DC8
    public static uint gmBoss5RocketSeqGetWaitFallTime( AppMain.GMS_BOSS5_ROCKET_WORK rkt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(rkt_work).parent_obj;
        int life = gms_BOSS5_BODY_WORK.mgr_work.life;
        AppMain.GMS_BOSS5_RKT_SEQ_WAITFALL_INFO gms_BOSS5_RKT_SEQ_WAITFALL_INFO = null;
        int num = 0;
        int num2 = 0;
        for ( int i = 0; i < 3; i++ )
        {
            if ( life <= AppMain.gm_boss5_rkt_seq_wait_fall_time_tbl[i].life_threshold )
            {
                gms_BOSS5_RKT_SEQ_WAITFALL_INFO = AppMain.gm_boss5_rkt_seq_wait_fall_time_tbl[i];
                break;
            }
        }
        if ( gms_BOSS5_RKT_SEQ_WAITFALL_INFO == null )
        {
            return 0U;
        }
        int num3 = AppMain.AkMathRandFx();
        for ( int j = 0; j < 3; j++ )
        {
            int num4 = gms_BOSS5_RKT_SEQ_WAITFALL_INFO.probability[j];
            if ( num4 > 0 )
            {
                num = j;
                num2 += num4;
                if ( num3 <= num2 )
                {
                    return gms_BOSS5_RKT_SEQ_WAITFALL_INFO.frame[j];
                }
            }
        }
        return gms_BOSS5_RKT_SEQ_WAITFALL_INFO.frame[num];
    }
}
