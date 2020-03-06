using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000203 RID: 515
    public class GMS_BOSS5_1SHOT_TIMER
    {
        // Token: 0x040055E8 RID: 21992
        public uint timer;

        // Token: 0x040055E9 RID: 21993
        public int is_active;
    }

    // Token: 0x02000204 RID: 516
    public class GMS_BOSS5_GRD_MOVE_WORK
    {
        // Token: 0x040055EA RID: 21994
        public int cur_diff_x;

        // Token: 0x040055EB RID: 21995
        public int prev_diff_x;

        // Token: 0x040055EC RID: 21996
        public int ref_snm_reg_id;

        // Token: 0x040055ED RID: 21997
        public int is_first_updated;
    }

    // Token: 0x02000205 RID: 517
    public class GMS_BOSS5_ARM_ANIM_WORK
    {
        // Token: 0x040055EE RID: 21998
        public int is_anim;

        // Token: 0x040055EF RID: 21999
        public uint anim_wait_timer;

        // Token: 0x040055F0 RID: 22000
        public float cur_rate;

        // Token: 0x040055F1 RID: 22001
        public float rate_add;

        // Token: 0x040055F2 RID: 22002
        public AppMain.NNS_QUATERNION[] start_quat = AppMain.New<AppMain.NNS_QUATERNION>(3);

        // Token: 0x040055F3 RID: 22003
        public AppMain.NNS_QUATERNION[] end_quat = AppMain.New<AppMain.NNS_QUATERNION>(3);
    }

    // Token: 0x02000206 RID: 518
    public class GMS_BOSS5_EXPL_WORK
    {
        // Token: 0x040055F4 RID: 22004
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x040055F5 RID: 22005
        public int expl_type;

        // Token: 0x040055F6 RID: 22006
        public uint interval_timer;

        // Token: 0x040055F7 RID: 22007
        public uint interval_min;

        // Token: 0x040055F8 RID: 22008
        public uint interval_max;

        // Token: 0x040055F9 RID: 22009
        public float se_frequency;

        // Token: 0x040055FA RID: 22010
        public float se_freq_cnt;

        // Token: 0x040055FB RID: 22011
        public int[] ofst_pos = new int[2];

        // Token: 0x040055FC RID: 22012
        public int[] area = new int[2];
    }

    // Token: 0x02000207 RID: 519
    public class GMS_BOSS5_MGR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600234D RID: 9037 RVA: 0x0014881D File Offset: 0x00146A1D
        public GMS_BOSS5_MGR_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600234E RID: 9038 RVA: 0x00148853 File Offset: 0x00146A53
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS5_MGR_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0600234F RID: 9039 RVA: 0x00148865 File Offset: 0x00146A65
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x040055FD RID: 22013
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x040055FE RID: 22014
        public int life;

        // Token: 0x040055FF RID: 22015
        public AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK proc_update;

        // Token: 0x04005600 RID: 22016
        public uint flag;

        // Token: 0x04005601 RID: 22017
        public uint wait_timer;

        // Token: 0x04005602 RID: 22018
        public int ply_demo_run_dest_x;

        // Token: 0x04005603 RID: 22019
        public readonly short[] save_camera_offset = new short[2];

        // Token: 0x04005604 RID: 22020
        public int alarm_level;

        // Token: 0x04005605 RID: 22021
        public readonly AppMain.GMS_BOSS5_EXPL_WORK small_expl_work = new AppMain.GMS_BOSS5_EXPL_WORK();

        // Token: 0x04005606 RID: 22022
        public readonly AppMain.GMS_BOSS5_EXPL_WORK big_expl_work = new AppMain.GMS_BOSS5_EXPL_WORK();

        // Token: 0x04005607 RID: 22023
        public AppMain.GMS_BOSS5_BODY_WORK body_work;
    }

    // Token: 0x02000208 RID: 520
    public class GMS_BOSS5_BODY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002350 RID: 9040 RVA: 0x00148878 File Offset: 0x00146A78
        public GMS_BOSS5_BODY_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002351 RID: 9041 RVA: 0x001489D7 File Offset: 0x00146BD7
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_BOSS5_BODY_WORK p )
        {
            return p.ene_3d.ene_com;
        }

        // Token: 0x06002352 RID: 9042 RVA: 0x001489E4 File Offset: 0x00146BE4
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005608 RID: 22024
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005609 RID: 22025
        public int state;

        // Token: 0x0400560A RID: 22026
        public int prev_state;

        // Token: 0x0400560B RID: 22027
        public int sub_seq;

        // Token: 0x0400560C RID: 22028
        public int strat_state;

        // Token: 0x0400560D RID: 22029
        public AppMain.GMS_BOSS5_MGR_WORK mgr_work;

        // Token: 0x0400560E RID: 22030
        public AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK proc_update;

        // Token: 0x0400560F RID: 22031
        public uint flag;

        // Token: 0x04005610 RID: 22032
        public int whole_act_id;

        // Token: 0x04005611 RID: 22033
        public uint wait_timer;

        // Token: 0x04005612 RID: 22034
        public uint no_hit_timer;

        // Token: 0x04005613 RID: 22035
        public uint fast_move_timer;

        // Token: 0x04005614 RID: 22036
        public uint poke_trg_limit_timer;

        // Token: 0x04005615 RID: 22037
        public int ground_v_pos;

        // Token: 0x04005616 RID: 22038
        public int crash_pos_ofst_x;

        // Token: 0x04005617 RID: 22039
        public uint def_rect_req_flag;

        // Token: 0x04005618 RID: 22040
        public AppMain.OBS_RECT_WORK[][] sub_rect_work = AppMain.New<AppMain.OBS_RECT_WORK>(2, 3);

        // Token: 0x04005619 RID: 22041
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x0400561A RID: 22042
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x0400561B RID: 22043
        public int body_snm_reg_id;

        // Token: 0x0400561C RID: 22044
        public int lfoot_snm_reg_id;

        // Token: 0x0400561D RID: 22045
        public int rfoot_snm_reg_id;

        // Token: 0x0400561E RID: 22046
        public int[][] armpt_snm_reg_ids = AppMain.New<int>(2, 3);

        // Token: 0x0400561F RID: 22047
        public int[] leg_snm_reg_ids = AppMain.New<int>(2);

        // Token: 0x04005620 RID: 22048
        public int pole_snm_reg_id;

        // Token: 0x04005621 RID: 22049
        public int[] groin_snm_reg_ids = AppMain.New<int>(2);

        // Token: 0x04005622 RID: 22050
        public int[] nozzle_snm_reg_ids = AppMain.New<int>(2);

        // Token: 0x04005623 RID: 22051
        public AppMain.VecFx32 pivot_prev_pos = default(AppMain.VecFx32);

        // Token: 0x04005624 RID: 22052
        public readonly AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work = new AppMain.GMS_BS_CMN_CNM_MGR_WORK();

        // Token: 0x04005625 RID: 22053
        public int[][] arm_cnm_reg_id = AppMain.New<int>(2, 3);

        // Token: 0x04005626 RID: 22054
        public int pole_cnm_reg_id;

        // Token: 0x04005627 RID: 22055
        public int cover_cnm_reg_id;

        // Token: 0x04005628 RID: 22056
        public int neck_cnm_reg_id;

        // Token: 0x04005629 RID: 22057
        public int head_cnm_reg_id;

        // Token: 0x0400562A RID: 22058
        public int[] scatter_cnm_reg_ids = AppMain.New<int>(22);

        // Token: 0x0400562B RID: 22059
        public readonly AppMain.NNS_MATRIX[] rkt_ofst_mtx = AppMain.New<AppMain.NNS_MATRIX>(2);

        // Token: 0x0400562C RID: 22060
        public readonly AppMain.NNS_QUATERNION[][] arm_part_rot_quat = AppMain.New<AppMain.NNS_QUATERNION>(2, 3);

        // Token: 0x0400562D RID: 22061
        public readonly AppMain.GMS_BOSS5_ARM_ANIM_WORK arm_anim_work = new AppMain.GMS_BOSS5_ARM_ANIM_WORK();

        // Token: 0x0400562E RID: 22062
        public int arm_poke_anim_phase;

        // Token: 0x0400562F RID: 22063
        public AppMain.NNS_QUATERNION cnpy_close_init_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04005630 RID: 22064
        public AppMain.NNS_QUATERNION cnpy_close_dest_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04005631 RID: 22065
        public float cnpy_close_ratio;

        // Token: 0x04005632 RID: 22066
        public float cnpy_close_ratio_spd;

        // Token: 0x04005633 RID: 22067
        public readonly AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work = new AppMain.GMS_BS_CMN_DMG_FLICKER_WORK();

        // Token: 0x04005634 RID: 22068
        public int[] foot_ofst_record_src = new int[2];

        // Token: 0x04005635 RID: 22069
        public int[] foot_ofst_record_dest = new int[2];

        // Token: 0x04005636 RID: 22070
        public int adj_hgap_is_active;

        // Token: 0x04005637 RID: 22071
        public int adj_hgap_act_id;

        // Token: 0x04005638 RID: 22072
        public int adj_hgap_leg_type;

        // Token: 0x04005639 RID: 22073
        public AppMain.VecFx32 grdmv_pivot_pos = default(AppMain.VecFx32);

        // Token: 0x0400563A RID: 22074
        public readonly AppMain.GMS_BOSS5_GRD_MOVE_WORK grdmv_work = new AppMain.GMS_BOSS5_GRD_MOVE_WORK();

        // Token: 0x0400563B RID: 22075
        public int cur_move_phase_type;

        // Token: 0x0400563C RID: 22076
        public int is_move_reverse;

        // Token: 0x0400563D RID: 22077
        public int walk_end_monitor_phase_cnt;

        // Token: 0x0400563E RID: 22078
        public int is_player_behind;

        // Token: 0x0400563F RID: 22079
        public int cur_walk_grnd_phase_cnt;

        // Token: 0x04005640 RID: 22080
        public int run_grnd_runtype;

        // Token: 0x04005641 RID: 22081
        public uint run_grnd_delay_timer;

        // Token: 0x04005642 RID: 22082
        public uint run_grnd_spawn_remain;

        // Token: 0x04005643 RID: 22083
        public int cur_run_type;

        // Token: 0x04005644 RID: 22084
        public readonly AppMain.GMS_BOSS5_1SHOT_TIMER se_timer = new AppMain.GMS_BOSS5_1SHOT_TIMER();

        // Token: 0x04005645 RID: 22085
        public uint se_cnt;

        // Token: 0x04005646 RID: 22086
        public AppMain.GSS_SND_SE_HANDLE se_hnd_leakage;

        // Token: 0x04005647 RID: 22087
        public readonly AppMain.GMS_BOSS5_1SHOT_TIMER targ_se_timer = new AppMain.GMS_BOSS5_1SHOT_TIMER();

        // Token: 0x04005648 RID: 22088
        public float targ_se_cur_interval;

        // Token: 0x04005649 RID: 22089
        public readonly AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK dsearch_work = new AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK();

        // Token: 0x0400564A RID: 22090
        public AppMain.VecFx32[] search_hist_buf = AppMain.New<AppMain.VecFx32>(11);

        // Token: 0x0400564B RID: 22091
        public int ply_search_delay;

        // Token: 0x0400564C RID: 22092
        public int turn_src_dir;

        // Token: 0x0400564D RID: 22093
        public int turn_tgt_ofst_dir;

        // Token: 0x0400564E RID: 22094
        public float turn_ratio;

        // Token: 0x0400564F RID: 22095
        public float bsk_shake_acc_ratio;

        // Token: 0x04005650 RID: 22096
        public float bsk_shake_acc_ratio_spd;

        // Token: 0x04005651 RID: 22097
        public float bsk_shake_init_spd;

        // Token: 0x04005652 RID: 22098
        public uint crash_strike_vib_delay_timer;

        // Token: 0x04005653 RID: 22099
        public int crash_strike_vib_phase;

        // Token: 0x04005654 RID: 22100
        public float crash_strike_vib_ratio;

        // Token: 0x04005655 RID: 22101
        public uint start_rise_vib_int_timer;

        // Token: 0x04005656 RID: 22102
        public uint sct_land_vib_timer;

        // Token: 0x04005657 RID: 22103
        public readonly AppMain.GMS_BOSS5_EXPL_WORK expl_work = new AppMain.GMS_BOSS5_EXPL_WORK();

        // Token: 0x04005658 RID: 22104
        public AppMain.OBS_OBJECT_WORK[] parts_objs = new AppMain.OBS_OBJECT_WORK[1];

        // Token: 0x04005659 RID: 22105
        public AppMain.OBS_OBJECT_WORK part_obj_core;
    }

    // Token: 0x02000209 RID: 521
    public class GMS_BOSS5_CORE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002353 RID: 9043 RVA: 0x001489F6 File Offset: 0x00146BF6
        public GMS_BOSS5_CORE_WORK()
        {
            this.ene_com = new AppMain.GMS_ENEMY_COM_WORK( this );
        }

        // Token: 0x06002354 RID: 9044 RVA: 0x00148A0A File Offset: 0x00146C0A
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_com.obj_work;
        }

        // Token: 0x0400565A RID: 22106
        public readonly AppMain.GMS_ENEMY_COM_WORK ene_com;

        // Token: 0x0400565B RID: 22107
        public AppMain.MPP_VOID_GMS_BOSS5_CORE_WORK proc_update;
    }

    // Token: 0x0200020A RID: 522
    public class GMS_BOSS5_ALARM_FADE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002355 RID: 9045 RVA: 0x00148A17 File Offset: 0x00146C17
        public GMS_BOSS5_ALARM_FADE_WORK()
        {
            this.fade_obj = new AppMain.GMS_FADE_OBJ_WORK( this );
        }

        // Token: 0x06002356 RID: 9046 RVA: 0x00148A36 File Offset: 0x00146C36
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.fade_obj.obj_work;
        }

        // Token: 0x06002357 RID: 9047 RVA: 0x00148A43 File Offset: 0x00146C43
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS5_ALARM_FADE_WORK work )
        {
            return work.fade_obj.obj_work;
        }

        // Token: 0x0400565C RID: 22108
        public readonly AppMain.GMS_FADE_OBJ_WORK fade_obj;

        // Token: 0x0400565D RID: 22109
        public AppMain.GMS_BOSS5_MGR_WORK mgr_work;

        // Token: 0x0400565E RID: 22110
        public AppMain.MPP_VOID_GMS_BOSS5_ALARM_FADE_WORK proc_update;

        // Token: 0x0400565F RID: 22111
        public int cur_phase;

        // Token: 0x04005660 RID: 22112
        public int cur_level;

        // Token: 0x04005661 RID: 22113
        public uint wait_timer;

        // Token: 0x04005662 RID: 22114
        public readonly AppMain.GMS_BOSS5_1SHOT_TIMER alert_se_timer = new AppMain.GMS_BOSS5_1SHOT_TIMER();

        // Token: 0x04005663 RID: 22115
        public int alert_se_ref_level;
    }

    // Token: 0x0200020B RID: 523
    public class GMS_BOSS5_FLASH_SCREEN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002358 RID: 9048 RVA: 0x00148A50 File Offset: 0x00146C50
        public GMS_BOSS5_FLASH_SCREEN_WORK()
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
        }

        // Token: 0x06002359 RID: 9049 RVA: 0x00148A6F File Offset: 0x00146C6F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_com.Cast();
        }

        // Token: 0x04005664 RID: 22116
        public readonly AppMain.GMS_EFFECT_COM_WORK efct_com;

        // Token: 0x04005665 RID: 22117
        public readonly AppMain.GMS_CMN_FLASH_SCR_WORK flash_work = new AppMain.GMS_CMN_FLASH_SCR_WORK();
    }

    // Token: 0x0200020C RID: 524
    public class GMS_BOSS5_SCT_PART_NDC_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600235A RID: 9050 RVA: 0x00148A7C File Offset: 0x00146C7C
        public GMS_BOSS5_SCT_PART_NDC_WORK()
        {
            this.ndc_obj = new AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( this );
        }

        // Token: 0x0600235B RID: 9051 RVA: 0x00148A9C File Offset: 0x00146C9C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ndc_obj.Cast();
        }

        // Token: 0x04005666 RID: 22118
        public readonly AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT ndc_obj;

        // Token: 0x04005667 RID: 22119
        public AppMain.NNS_QUATERNION spin_quat = default(AppMain.NNS_QUATERNION);
    }

    // Token: 0x0200020D RID: 525
    public class GMS_BOSS5_ALARM_FADE_INFO
    {
        // Token: 0x0600235C RID: 9052 RVA: 0x00148AA9 File Offset: 0x00146CA9
        public GMS_BOSS5_ALARM_FADE_INFO( uint a, uint b, uint c, uint d )
        {
            this.fo_frame = a;
            this.on_frame = b;
            this.fi_frame = c;
            this.off_frame = d;
        }

        // Token: 0x04005668 RID: 22120
        public uint fo_frame;

        // Token: 0x04005669 RID: 22121
        public uint on_frame;

        // Token: 0x0400566A RID: 22122
        public uint fi_frame;

        // Token: 0x0400566B RID: 22123
        public uint off_frame;
    }

    // Token: 0x0200020E RID: 526
    public class GMS_BOSS5_SCT_PART_INFO
    {
        // Token: 0x0600235D RID: 9053 RVA: 0x00148ACE File Offset: 0x00146CCE
        public GMS_BOSS5_SCT_PART_INFO( int a, int b, int c )
        {
            this.cnm_mode = a;
            this.is_local_coord = b;
            this.is_inherit_scale = c;
        }

        // Token: 0x0400566C RID: 22124
        public int cnm_mode;

        // Token: 0x0400566D RID: 22125
        public int is_local_coord;

        // Token: 0x0400566E RID: 22126
        public int is_inherit_scale;
    }

    // Token: 0x0200020F RID: 527
    public class GMS_BOSS5_SCT_NDC_INFO
    {
        // Token: 0x0600235E RID: 9054 RVA: 0x00148AEB File Offset: 0x00146CEB
        public GMS_BOSS5_SCT_NDC_INFO( int a, uint b )
        {
            this.part_idx = a;
            this.delay_time = b;
        }

        // Token: 0x0400566F RID: 22127
        public int part_idx;

        // Token: 0x04005670 RID: 22128
        public uint delay_time;
    }

    // Token: 0x02000210 RID: 528
    public class GMS_BOSS5_PART_ACT_INFO
    {
        // Token: 0x0600235F RID: 9055 RVA: 0x00148B04 File Offset: 0x00146D04
        public GMS_BOSS5_PART_ACT_INFO()
        {
            this.act_id = 0;
            this.is_maintain = ( this.is_repeat = 0 );
            this.mtn_spd = ( this.blend_spd = 0f );
            this.is_blend = ( this.is_merge_manual = 0 );
        }

        // Token: 0x06002360 RID: 9056 RVA: 0x00148B52 File Offset: 0x00146D52
        public GMS_BOSS5_PART_ACT_INFO( ushort actId, byte isMantain, byte isRepeat, float mspd, int blend, float bspd, int merge )
        {
            this.act_id = actId;
            this.is_maintain = isMantain;
            this.is_repeat = isRepeat;
            this.mtn_spd = mspd;
            this.is_blend = blend;
            this.blend_spd = bspd;
            this.is_merge_manual = merge;
        }

        // Token: 0x04005671 RID: 22129
        public ushort act_id;

        // Token: 0x04005672 RID: 22130
        public byte is_maintain;

        // Token: 0x04005673 RID: 22131
        public byte is_repeat;

        // Token: 0x04005674 RID: 22132
        public float mtn_spd;

        // Token: 0x04005675 RID: 22133
        public int is_blend;

        // Token: 0x04005676 RID: 22134
        public float blend_spd;

        // Token: 0x04005677 RID: 22135
        public int is_merge_manual;
    }

    // Token: 0x02000211 RID: 529
    public class GMS_BOSS5_MOVE_INFO
    {
        // Token: 0x06002361 RID: 9057 RVA: 0x00148B8F File Offset: 0x00146D8F
        public GMS_BOSS5_MOVE_INFO( float a, int b )
        {
            this.switching_frame = a;
            this.move_phase_type = b;
        }

        // Token: 0x04005678 RID: 22136
        public float switching_frame;

        // Token: 0x04005679 RID: 22137
        public int move_phase_type;
    }

    // Token: 0x02000212 RID: 530
    public class GMD_BOSS5_WALK_GROUND_TIMING_INFO
    {
        // Token: 0x06002362 RID: 9058 RVA: 0x00148BA5 File Offset: 0x00146DA5
        public GMD_BOSS5_WALK_GROUND_TIMING_INFO( float a, int b )
        {
            this.grounding_frame = a;
            this.leg_type = b;
        }

        // Token: 0x0400567A RID: 22138
        public float grounding_frame;

        // Token: 0x0400567B RID: 22139
        public int leg_type;
    }

    // Token: 0x02000213 RID: 531
    public class GMS_BOSS5_ARM_PART_ANIM_INFO
    {
        // Token: 0x06002363 RID: 9059 RVA: 0x00148BBB File Offset: 0x00146DBB
        public GMS_BOSS5_ARM_PART_ANIM_INFO()
        {
        }

        // Token: 0x06002364 RID: 9060 RVA: 0x00148BDB File Offset: 0x00146DDB
        public GMS_BOSS5_ARM_PART_ANIM_INFO( int anim, AppMain.NNS_ROTATE_A32 rot, AppMain.NNS_ROTATE_A32 erot )
        {
            this.is_anim = anim;
            this.start_rot = rot;
            this.end_rot = erot;
        }

        // Token: 0x0400567C RID: 22140
        public int is_anim;

        // Token: 0x0400567D RID: 22141
        public readonly AppMain.NNS_ROTATE_A32 start_rot = default(AppMain.NNS_ROTATE_A32);

        // Token: 0x0400567E RID: 22142
        public readonly AppMain.NNS_ROTATE_A32 end_rot = default(AppMain.NNS_ROTATE_A32);
    }

    // Token: 0x02000214 RID: 532
    public class GMS_BOSS5_ARM_ANIM_INFO
    {
        // Token: 0x06002365 RID: 9061 RVA: 0x00148C10 File Offset: 0x00146E10
        public GMS_BOSS5_ARM_ANIM_INFO()
        {
        }

        // Token: 0x06002366 RID: 9062 RVA: 0x00148C24 File Offset: 0x00146E24
        public GMS_BOSS5_ARM_ANIM_INFO( uint wait, float sincrate, AppMain.GMS_BOSS5_ARM_PART_ANIM_INFO[] part )
        {
            this.wait_time = wait;
            this.slerp_inc_rate = sincrate;
            this.part_anim_info = part;
        }

        // Token: 0x0400567F RID: 22143
        public uint wait_time;

        // Token: 0x04005680 RID: 22144
        public float slerp_inc_rate;

        // Token: 0x04005681 RID: 22145
        public AppMain.GMS_BOSS5_ARM_PART_ANIM_INFO[] part_anim_info = AppMain.New<AppMain.GMS_BOSS5_ARM_PART_ANIM_INFO>(3);
    }

    // Token: 0x02000215 RID: 533
    public class GMS_BOSS5_RECTPOINT_SETTING_INFO
    {
        // Token: 0x06002367 RID: 9063 RVA: 0x00148C4D File Offset: 0x00146E4D
        public GMS_BOSS5_RECTPOINT_SETTING_INFO()
        {
        }

        // Token: 0x06002368 RID: 9064 RVA: 0x00148C62 File Offset: 0x00146E62
        public GMS_BOSS5_RECTPOINT_SETTING_INFO( uint bitFlag, short[][] rectsize )
        {
            this.enable_bit_flag = bitFlag;
            this.rect_size = rectsize;
        }

        // Token: 0x04005682 RID: 22146
        public uint enable_bit_flag;

        // Token: 0x04005683 RID: 22147
        public short[][] rect_size = AppMain.New<short>(3, 4);
    }

    // Token: 0x02000216 RID: 534
    public class GMS_BOSS5_BODY_RECT_SETTING_INFO
    {
        // Token: 0x06002369 RID: 9065 RVA: 0x00148C85 File Offset: 0x00146E85
        public GMS_BOSS5_BODY_RECT_SETTING_INFO( int invis, int leakage, AppMain.GMS_BOSS5_RECTPOINT_SETTING_INFO[] info )
        {
            this.is_invincible = invis;
            this.is_leakage = leakage;
            this.point_setting_info = info;
        }

        // Token: 0x04005684 RID: 22148
        public int is_invincible;

        // Token: 0x04005685 RID: 22149
        public int is_leakage;

        // Token: 0x04005686 RID: 22150
        public AppMain.GMS_BOSS5_RECTPOINT_SETTING_INFO[] point_setting_info = AppMain.New<AppMain.GMS_BOSS5_RECTPOINT_SETTING_INFO>(3);
    }

    // Token: 0x02000217 RID: 535
    public class GMS_BOSS5_BODY_STATE_ENTER_INFO
    {
        // Token: 0x0600236A RID: 9066 RVA: 0x00148CAE File Offset: 0x00146EAE
        public GMS_BOSS5_BODY_STATE_ENTER_INFO( AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK ef, int wrp )
        {
            this.enter_func = ef;
            this.is_wrapped = wrp;
        }

        // Token: 0x04005687 RID: 22151
        public AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK enter_func;

        // Token: 0x04005688 RID: 22152
        public int is_wrapped;
    }

    // Token: 0x02000218 RID: 536
    public class GMS_BOSS5_BODY_SUBSEQ_ENTER_INFO
    {
        // Token: 0x0600236B RID: 9067 RVA: 0x00148CC4 File Offset: 0x00146EC4
        public GMS_BOSS5_BODY_SUBSEQ_ENTER_INFO( AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK a, int b )
        {
            this.enter_func = a;
            this.super_state = b;
        }

        // Token: 0x04005689 RID: 22153
        public AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK enter_func;

        // Token: 0x0400568A RID: 22154
        public int super_state;
    }

    // Token: 0x02000219 RID: 537
    public class GMS_BOSS5_STRAT_PROB_INFO
    {
        // Token: 0x0600236C RID: 9068 RVA: 0x00148CDA File Offset: 0x00146EDA
        public GMS_BOSS5_STRAT_PROB_INFO( int a, int b, int c )
        {
            this.strat_state = a;
            this.probability = b;
            this.is_rkt = c;
        }

        // Token: 0x0400568B RID: 22155
        public int strat_state;

        // Token: 0x0400568C RID: 22156
        public int probability;

        // Token: 0x0400568D RID: 22157
        public int is_rkt;
    }

    // Token: 0x06000B37 RID: 2871 RVA: 0x00065286 File Offset: 0x00063486
    private static int GMM_BOSS5_AREA_LEFT()
    {
        return AppMain.g_gm_main_system.map_fcol.left << 12;
    }

    // Token: 0x06000B38 RID: 2872 RVA: 0x0006529A File Offset: 0x0006349A
    private static int GMM_BOSS5_AREA_TOP()
    {
        return AppMain.g_gm_main_system.map_fcol.top << 12;
    }

    // Token: 0x06000B39 RID: 2873 RVA: 0x000652AE File Offset: 0x000634AE
    private static int GMM_BOSS5_AREA_RIGHT()
    {
        return AppMain.g_gm_main_system.map_fcol.right << 12;
    }

    // Token: 0x06000B3A RID: 2874 RVA: 0x000652C2 File Offset: 0x000634C2
    private static int GMM_BOSS5_AREA_BOTTOM()
    {
        return AppMain.g_gm_main_system.map_fcol.bottom << 12;
    }

    // Token: 0x06000B3B RID: 2875 RVA: 0x000652D6 File Offset: 0x000634D6
    private static int GMM_BOSS5_AREA_CENTER_X()
    {
        return AppMain.GMM_BOSS5_AREA_LEFT() + ( AppMain.GMM_BOSS5_AREA_RIGHT() - AppMain.GMM_BOSS5_AREA_LEFT() ) / 2;
    }

    // Token: 0x06000B3C RID: 2876 RVA: 0x000652EB File Offset: 0x000634EB
    private static int GMM_BOSS5_AREA_CENTER_Y()
    {
        return AppMain.GMM_BOSS5_AREA_TOP() + ( AppMain.GMM_BOSS5_AREA_BOTTOM() - AppMain.GMM_BOSS5_AREA_TOP() ) / 2;
    }

    // Token: 0x06000B3D RID: 2877 RVA: 0x00065300 File Offset: 0x00063500
    private static void GmBoss5Build()
    {
        object obj = AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.g_gm_gamedat_enemy_arc);
        object obj2 = AppMain.ObjDataLoadAmbIndex(null, 1, AppMain.g_gm_gamedat_enemy_arc);
        AppMain.gm_boss5_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( ( AppMain.AMS_AMB_HEADER )obj, ( AppMain.AMS_AMB_HEADER )obj2, 0U );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 745 ), 2, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 746 ), 4, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 747 ), 8, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 748 ), 3, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 749 ), 5, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 750 ), 6, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 751 ), 7, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.GmBoss5EfctBuild();
    }

    // Token: 0x06000B3E RID: 2878 RVA: 0x000653E0 File Offset: 0x000635E0
    private static void GmBoss5Flush()
    {
        AppMain.GmBoss5EfctFlush();
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 751 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 750 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 749 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 748 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 747 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 746 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 745 ) );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.g_gm_gamedat_enemy_arc);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_boss5_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_boss5_obj_3d_list = null;
    }

    // Token: 0x06000B3F RID: 2879 RVA: 0x0006548C File Offset: 0x0006368C
    private static AppMain.OBS_OBJECT_WORK GmBoss5Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_MGR_WORK(), "BOSS5_MGR");
        AppMain.GMS_BOSS5_MGR_WORK gms_BOSS5_MGR_WORK = (AppMain.GMS_BOSS5_MGR_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        gms_BOSS5_MGR_WORK.ene_3d.ene_com.enemy_flag |= 32768U;
        gms_BOSS5_MGR_WORK.life = AppMain.GMD_BOSS5_LIFE;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5MgrWaitLoad );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B40 RID: 2880 RVA: 0x0006553C File Offset: 0x0006373C
    private static AppMain.OBS_OBJECT_WORK GmBoss5BodyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_BODY_WORK(), "BOSS5_BODY");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.pos.z = AppMain.GMD_BOSS5_DEFAULT_POS_Z;
        gms_BOSS5_BODY_WORK.ground_v_pos = pos_y;
        gms_ENEMY_3D_WORK.ene_com.vit = 1;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, AppMain.GMD_BOSS5_BODY_DEFAULT_FIELD_RECT_SIZE_LEFT, AppMain.GMD_BOSS5_BODY_DEFAULT_FIELD_RECT_SIZE_TOP, AppMain.GMD_BOSS5_BODY_DEFAULT_FIELD_RECT_SIZE_RIGHT, AppMain.GMD_BOSS5_BODY_DEFAULT_FIELD_RECT_SIZE_BOTTOM );
        AppMain.gmBoss5BodySetupRect( gms_BOSS5_BODY_WORK );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_boss5_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 745 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = AppMain.GMD_BOSS5_DEFAULT_BLEND_SPD;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194308U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag &= 4294443007U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag |= 1024U;
        gms_BOSS5_BODY_WORK.ene_3d.ene_com.enemy_flag |= 32768U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5BodyWaitSetup );
        AppMain.gmBoss5BodyChangeState( gms_BOSS5_BODY_WORK, 0, 0 );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5BodyOutFunc );
        obs_OBJECT_WORK.ppRec = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5BodyRecFunc );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss5BodyExit ) );
        AppMain.gmBoss5BodyAllocSeHandles( gms_BOSS5_BODY_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B41 RID: 2881 RVA: 0x00065728 File Offset: 0x00063928
    private static AppMain.OBS_OBJECT_WORK GmBoss5CoreInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_CORE_WORK(), "BOSS5_CORE");
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5CoreWaitSetup );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B42 RID: 2882 RVA: 0x000657B1 File Offset: 0x000639B1
    private static AppMain.OBS_ACTION3D_NN_WORK[] GmBoss5GetObject3dList()
    {
        return AppMain.gm_boss5_obj_3d_list;
    }

    // Token: 0x06000B43 RID: 2883 RVA: 0x000657B8 File Offset: 0x000639B8
    private static void GmBoss5BodyGetPlySearchPos( AppMain.GMS_BOSS5_BODY_WORK body_work, out AppMain.VecFx32 pos )
    {
        AppMain.GmBsCmnGetDelaySearchPos( body_work.dsearch_work, body_work.ply_search_delay, out pos );
    }

    // Token: 0x06000B44 RID: 2884 RVA: 0x000657CC File Offset: 0x000639CC
    private static void GmBoss5ScatterSetFlyParam( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = (int)(AppMain.mtMathRand() % 90);
        int ang;
        if ( obj_work.pos.x <= obj_work.parent_obj.pos.x )
        {
            ang = AppMain.AKM_DEGtoA32( num + 90 + 45 );
        }
        else
        {
            ang = AppMain.AKM_DEGtoA32( num - 45 );
        }
        float gmd_BOSS5_SCT_NDC_FLY_SPD_FLOAT = AppMain.GMD_BOSS5_SCT_NDC_FLY_SPD_FLOAT;
        obj_work.spd.y = ( int )( 4096f * gmd_BOSS5_SCT_NDC_FLY_SPD_FLOAT * AppMain.nnSin( ang ) );
        obj_work.spd.x = ( int )( 4096f * gmd_BOSS5_SCT_NDC_FLY_SPD_FLOAT * AppMain.nnCos( ang ) );
        obj_work.move_flag |= 128U;
    }

    // Token: 0x06000B45 RID: 2885 RVA: 0x00065864 File Offset: 0x00063A64
    private static void GmBoss5Init1ShotTimer( AppMain.GMS_BOSS5_1SHOT_TIMER one_shot_timer, uint frame )
    {
        one_shot_timer.timer = frame;
        one_shot_timer.is_active = 1;
    }

    // Token: 0x06000B46 RID: 2886 RVA: 0x00065874 File Offset: 0x00063A74
    private static int GmBoss5Update1ShotTimer( AppMain.GMS_BOSS5_1SHOT_TIMER one_shot_timer )
    {
        if ( one_shot_timer.is_active == 0 )
        {
            return 0;
        }
        if ( one_shot_timer.timer != 0U )
        {
            one_shot_timer.timer -= 1U;
            return 0;
        }
        one_shot_timer.is_active = 0;
        return 1;
    }

    // Token: 0x06000B47 RID: 2887 RVA: 0x000658A4 File Offset: 0x00063AA4
    private static int GmBoss5UpdateVib( int phase_cnt, int scale, ref int pos_x, ref int pos_y )
    {
        int num = phase_cnt;
        if ( num >= 40 )
        {
            num %= 40;
        }
        pos_x = AppMain.FX_Mul( scale, AppMain.gm_boss5_vib_tbl[phase_cnt][0] );
        pos_y = AppMain.FX_Mul( scale, AppMain.gm_boss5_vib_tbl[phase_cnt][1] );
        int num2 = num + 1;
        if ( num2 >= 40 )
        {
            num2 = 0;
        }
        return num2;
    }

    // Token: 0x06000B48 RID: 2888 RVA: 0x000658EC File Offset: 0x00063AEC
    private static void gmBoss5InitExplCreate( AppMain.GMS_BOSS5_EXPL_WORK expl_work, int expl_type, AppMain.OBS_OBJECT_WORK parent_obj, int ofst_pos_x, int ofst_pos_y, int width, int height, uint interval_min, uint interval_max, float se_freq )
    {
        expl_work.parent_obj = parent_obj;
        expl_work.expl_type = expl_type;
        expl_work.interval_timer = 0U;
        expl_work.interval_min = interval_min;
        expl_work.interval_max = interval_max;
        expl_work.se_frequency = se_freq;
        expl_work.se_freq_cnt = 0f;
        expl_work.ofst_pos[0] = ofst_pos_x;
        expl_work.ofst_pos[1] = ofst_pos_y;
        expl_work.area[0] = width;
        expl_work.area[1] = height;
    }

    // Token: 0x06000B49 RID: 2889 RVA: 0x00065958 File Offset: 0x00063B58
    public static void gmBoss5UpdateExplCreate( AppMain.GMS_BOSS5_EXPL_WORK expl_work )
    {
        if ( expl_work.interval_timer != 0U )
        {
            expl_work.interval_timer -= 1U;
            return;
        }
        int num = expl_work.area[0];
        int num2 = expl_work.area[1];
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(expl_work.parent_obj.pos);
        int num3 = 0;
        int num4 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num);
        int num5 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num2);
        if ( expl_work.se_freq_cnt < 1f )
        {
            expl_work.se_freq_cnt += expl_work.se_frequency;
        }
        if ( expl_work.se_freq_cnt >= 1f )
        {
            expl_work.se_freq_cnt -= 1f;
            num3 = 1;
        }
        switch ( expl_work.expl_type )
        {
            case 0:
                AppMain.GmBoss5EfctCreateSmallExplosion( vecFx.x + expl_work.ofst_pos[0] - ( num >> 1 ) + num4, vecFx.y + expl_work.ofst_pos[1] - ( num2 >> 1 ) + num5, vecFx.z + AppMain.GMD_BOSS5_EXPL_OFST_Z );
                if ( num3 != 0 )
                {
                    AppMain.GmSoundPlaySE( "Boss0_02" );
                }
                break;
            case 1:
                AppMain.GmBoss5EfctCreateSmallExplosion( vecFx.x + expl_work.ofst_pos[0] - ( num >> 1 ) + num4, vecFx.y + expl_work.ofst_pos[1] - ( num2 >> 1 ) + num5, vecFx.z + AppMain.GMD_BOSS5_EXPL_OFST_Z );
                AppMain.GmBoss5EfctCreateFragments( vecFx.x + expl_work.ofst_pos[0] - ( num >> 1 ) + num4, vecFx.y + expl_work.ofst_pos[1] - ( num2 >> 1 ) + num5, vecFx.z + AppMain.GMD_BOSS5_EXPL_OFST_Z );
                if ( num3 != 0 )
                {
                    AppMain.GmSoundPlaySE( "Boss0_02" );
                }
                break;
            case 2:
                AppMain.GmBoss5EfctCreateBigExplosion( vecFx.x + expl_work.ofst_pos[0] - ( num >> 1 ) + num4, vecFx.y + expl_work.ofst_pos[1] - ( num2 >> 1 ) + num5, vecFx.z + AppMain.GMD_BOSS5_EXPL_OFST_Z );
                if ( num3 != 0 )
                {
                    AppMain.GmSoundPlaySE( "Boss0_03" );
                }
                break;
            default:
                AppMain.mppAssertNotImpl();
                return;
        }
        uint num6 = (uint)((long)AppMain.AkMathRandFx() * (long)((ulong)(expl_work.interval_max - expl_work.interval_min)) >> 12);
        expl_work.interval_timer = expl_work.interval_min + num6;
    }

    // Token: 0x06000B4A RID: 2890 RVA: 0x00065B7C File Offset: 0x00063D7C
    private static void gmBoss5SetCameraLift( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
        if ( ( mgr_work.flag & 16U ) == 0U )
        {
            mgr_work.flag |= 16U;
            mgr_work.save_camera_offset[0] = gms_PLAYER_WORK.gmk_camera_center_ofst_x;
            mgr_work.save_camera_offset[1] = gms_PLAYER_WORK.gmk_camera_center_ofst_y;
        }
        AppMain.GmCameraScaleSet( 0.85f, 0.0024999997f );
        AppMain.GmPlayerCameraOffsetSet( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 0, AppMain.GMD_BOSS5_CAMERA_LIFT_OFFSET_POS_Y );
    }

    // Token: 0x06000B4B RID: 2891 RVA: 0x00065BF0 File Offset: 0x00063DF0
    private static void gmBoss5RestoreCameraLift( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 16U ) == 0U )
        {
            return;
        }
        AppMain.GmPlayerCameraOffsetSet( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), mgr_work.save_camera_offset[0], mgr_work.save_camera_offset[1] );
        AppMain.GmCameraScaleSet( 1f, 0.0024999997f );
        mgr_work.save_camera_offset[0] = ( mgr_work.save_camera_offset[1] = 0 );
        mgr_work.flag &= 4294967279U;
    }

    // Token: 0x06000B4C RID: 2892 RVA: 0x00065C5C File Offset: 0x00063E5C
    private static void gmBoss5SetCameraSlideForNarrowScreen( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
        if ( ( mgr_work.flag & 16U ) == 0U )
        {
            mgr_work.flag |= 16U;
            mgr_work.save_camera_offset[0] = gms_PLAYER_WORK.gmk_camera_center_ofst_x;
            mgr_work.save_camera_offset[1] = gms_PLAYER_WORK.gmk_camera_center_ofst_y;
        }
        AppMain.GmPlayerCameraOffsetSet( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), AppMain.GMD_BOSS5_CAMERA_SLIDE_FOR_NARROW_OFFSET_POS_X, 0 );
    }

    // Token: 0x06000B4D RID: 2893 RVA: 0x00065CC0 File Offset: 0x00063EC0
    private static void gmBoss5RestoreCameraSlideForNarrowScreen( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 16U ) == 0U )
        {
            return;
        }
        AppMain.GmPlayerCameraOffsetSet( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), mgr_work.save_camera_offset[0], mgr_work.save_camera_offset[1] );
        mgr_work.save_camera_offset[0] = ( mgr_work.save_camera_offset[1] = 0 );
        mgr_work.flag &= 4294967279U;
    }

    // Token: 0x06000B4E RID: 2894 RVA: 0x00065D24 File Offset: 0x00063F24
    private static void gmBoss5CamScrLimitReleaseGently()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_COM_WORK(), null, 0, "scr_lim_rel_gently");
        obs_OBJECT_WORK.disp_flag |= 4128U;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.user_timer = AppMain.GMD_BOSS5_CAM_SCR_LIMIT_RELEASE_GNTL_SPD_X_INIT;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5CamScrLimitReleaseGentlyProcMain );
    }

    // Token: 0x06000B4F RID: 2895 RVA: 0x00065D9C File Offset: 0x00063F9C
    private static void gmBoss5CamScrLimitReleaseGentlyProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = (int)(AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64) << 12;
        int num2 = AppMain.g_gm_main_system.map_fcol.right << 12;
        int num3 = 0;
        obj_work.user_timer += AppMain.GMD_BOSS5_CAM_SCR_LIMIT_RELEASE_GNTL_ACC_X;
        obj_work.user_timer = AppMain.MTM_MATH_CLIP( obj_work.user_timer, 0, int.MaxValue );
        int num4 = num2 + obj_work.user_timer;
        if ( num4 >= num )
        {
            num4 = num;
            num3 = 1;
        }
        AppMain.GmCamScrLimitSetDirect( new AppMain.GMS_EVE_RECORD_EVENT
        {
            flag = 4,
            left = 0,
            top = 0,
            width = 0,
            height = 0
        }, num4, 0 );
        if ( num3 != 0 )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000B50 RID: 2896 RVA: 0x00065E57 File Offset: 0x00064057
    private static void gmBoss5HideMapBSide()
    {
        AppMain.GmMapSetDispB( false );
    }

    // Token: 0x06000B51 RID: 2897 RVA: 0x00065E60 File Offset: 0x00064060
    private static void gmBoss5TransferPlayerToASide()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag &= 4294967294U;
        gms_PLAYER_WORK.graind_prev_ride = 0;
    }

    // Token: 0x06000B52 RID: 2898 RVA: 0x00065E90 File Offset: 0x00064090
    private static void gmBoss5Vibration( int vib_idx )
    {
        AppMain.GmCameraVibrationSet( AppMain.gm_boss5_vib_param_tbl[vib_idx][0], AppMain.gm_boss5_vib_param_tbl[vib_idx][1], AppMain.gm_boss5_vib_param_tbl[vib_idx][2] );
    }

    // Token: 0x06000B53 RID: 2899 RVA: 0x00065EBC File Offset: 0x000640BC
    private static void gmBoss5DelayedVibration( int vib_idx, uint delay )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_COM_WORK(), null, 0, "boss5_delay_vib");
        obs_OBJECT_WORK.disp_flag |= 4128U;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.user_work = ( uint )vib_idx;
        obs_OBJECT_WORK.user_timer = ( int )delay;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5DelayedVibrationProcMain );
    }

    // Token: 0x06000B54 RID: 2900 RVA: 0x00065F34 File Offset: 0x00064134
    private static void gmBoss5DelayedVibrationProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.gmBoss5Vibration( ( int )obj_work.user_work );
        obj_work.flag |= 4U;
    }

    // Token: 0x06000B55 RID: 2901 RVA: 0x00065F70 File Offset: 0x00064170
    private static void gmBoss5DelayedSePlayback( string cue_name, uint delay )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_COM_WORK(), null, 0, "boss5_delay_se");
        obs_OBJECT_WORK.disp_flag |= 4128U;
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.amCriAudioGetGlobal();
        obs_OBJECT_WORK.user_work = AppMain.CriAuPlayer.GetCueId( cue_name );
        if ( ( ulong )obs_OBJECT_WORK.user_work != 18446744073709551615UL )
        {
            obs_OBJECT_WORK.user_timer = ( int )delay;
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5DelayedSePlaybackProcMain );
        }
    }

    // Token: 0x06000B56 RID: 2902 RVA: 0x00065FFE File Offset: 0x000641FE
    private static void gmBoss5DelayedSePlaybackProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.GsSoundPlaySeById( obj_work.user_work );
        obj_work.flag |= 4U;
    }

    // Token: 0x06000B57 RID: 2903 RVA: 0x00066030 File Offset: 0x00064230
    private static void gmBoss5MgrSetAlarmLevel( AppMain.GMS_BOSS5_MGR_WORK mgr_work, int alarm_level )
    {
        mgr_work.alarm_level = alarm_level;
    }

    // Token: 0x06000B58 RID: 2904 RVA: 0x00066039 File Offset: 0x00064239
    private static void gmBoss5MgrSetDemoRunDestPos( AppMain.GMS_BOSS5_MGR_WORK mgr_work, int dest_pos_x )
    {
        mgr_work.ply_demo_run_dest_x = dest_pos_x;
    }

    // Token: 0x06000B59 RID: 2905 RVA: 0x00066044 File Offset: 0x00064244
    private static void gmBoss5InitChasingExpl( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.gmBoss5InitExplCreate( mgr_work.small_expl_work, 0, AppMain.GmBsCmnGetPlayerObj(), AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_OFST_X, AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_OFST_Y, AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_WIDTH, AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_HEIGHT, AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_INTERVAL_MIN, AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_INTERVAL_MAX, AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_SE_FREQUENCY );
        AppMain.gmBoss5InitExplCreate( mgr_work.big_expl_work, 2, AppMain.GmBsCmnGetPlayerObj(), AppMain.GMD_BOSS5_EXPL_CHASE_BIG_OFST_X + AppMain.GMD_BOSS5_EXPL_CHASE_BIG_DELAY_OFST_X, AppMain.GMD_BOSS5_EXPL_CHASE_BIG_OFST_Y, AppMain.GMD_BOSS5_EXPL_CHASE_BIG_WIDTH, AppMain.GMD_BOSS5_EXPL_CHASE_BIG_HEIGHT, AppMain.GMD_BOSS5_EXPL_CHASE_BIG_INTERVAL_MIN, AppMain.GMD_BOSS5_EXPL_CHASE_BIG_INTERVAL_MAX, AppMain.GMD_BOSS5_EXPL_CHASE_BIG_SE_FREQUENCY );
    }

    // Token: 0x06000B5A RID: 2906 RVA: 0x000660C0 File Offset: 0x000642C0
    private static void gmBoss5UpdateChasingExpl( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.GMS_BOSS5_EXPL_WORK small_expl_work = mgr_work.small_expl_work;
        AppMain.GMS_BOSS5_EXPL_WORK big_expl_work = mgr_work.big_expl_work;
        small_expl_work.ofst_pos[0] += AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_CHASE_SPD_X;
        if ( small_expl_work.ofst_pos[0] >= AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_CHASE_OFST_X_MAX )
        {
            small_expl_work.ofst_pos[0] = AppMain.GMD_BOSS5_EXPL_CHASE_SMALL_CHASE_OFST_X_MAX;
        }
        big_expl_work.ofst_pos[0] += AppMain.GMD_BOSS5_EXPL_CHASE_BIG_CHASE_SPD_X;
        if ( big_expl_work.ofst_pos[0] >= AppMain.GMD_BOSS5_EXPL_CHASE_BIG_CHASE_OFST_X_MAX + AppMain.GMD_BOSS5_EXPL_CHASE_BIG_DELAY_OFST_X )
        {
            big_expl_work.ofst_pos[0] = AppMain.GMD_BOSS5_EXPL_CHASE_BIG_CHASE_OFST_X_MAX + AppMain.GMD_BOSS5_EXPL_CHASE_BIG_DELAY_OFST_X;
        }
        AppMain.gmBoss5UpdateExplCreate( mgr_work.small_expl_work );
        AppMain.gmBoss5UpdateExplCreate( mgr_work.big_expl_work );
    }

    // Token: 0x06000B5B RID: 2907 RVA: 0x00066170 File Offset: 0x00064370
    private static void gmBoss5MgrWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = 0;
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 || AppMain.GmMainDatLoadBossBattleLoadCheck( 4 ) )
        {
            num = 1;
        }
        if ( num != 0 )
        {
            AppMain.GMS_BOSS5_MGR_WORK gms_BOSS5_MGR_WORK = (AppMain.GMS_BOSS5_MGR_WORK)obj_work;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(330, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(331, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK;
            gms_BOSS5_MGR_WORK.body_work = gms_BOSS5_BODY_WORK;
            gms_BOSS5_BODY_WORK.mgr_work = gms_BOSS5_MGR_WORK;
            obs_OBJECT_WORK.parent_obj = obj_work;
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            gms_BOSS5_BODY_WORK.parts_objs[0] = obs_OBJECT_WORK;
            gms_BOSS5_BODY_WORK.part_obj_core = obs_OBJECT_WORK2;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5MgrWaitSetup );
        }
    }

    // Token: 0x06000B5C RID: 2908 RVA: 0x0006623C File Offset: 0x0006443C
    private static void gmBoss5MgrWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_MGR_WORK gms_BOSS5_MGR_WORK = (AppMain.GMS_BOSS5_MGR_WORK)obj_work;
        AppMain.GMS_BOSS5_BODY_WORK body_work = gms_BOSS5_MGR_WORK.body_work;
        int num = 1;
        for ( int i = 0; i < 1; i++ )
        {
            if ( body_work.parts_objs[i] == null )
            {
                num = 0;
            }
        }
        if ( body_work.part_obj_core == null )
        {
            num = 0;
        }
        if ( num != 0 )
        {
            gms_BOSS5_MGR_WORK.flag |= 1U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5MgrMain );
            AppMain.gmBoss5MgrProcInit( gms_BOSS5_MGR_WORK );
        }
    }

    // Token: 0x06000B5D RID: 2909 RVA: 0x000662A4 File Offset: 0x000644A4
    private static void gmBoss5MgrMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_MGR_WORK gms_BOSS5_MGR_WORK = (AppMain.GMS_BOSS5_MGR_WORK)obj_work;
        if ( ( gms_BOSS5_MGR_WORK.flag & 2U ) != 0U && gms_BOSS5_MGR_WORK.body_work != null )
        {
            AppMain.GMM_BS_OBJ( gms_BOSS5_MGR_WORK.body_work ).flag |= 8U;
            gms_BOSS5_MGR_WORK.body_work = null;
        }
        if ( gms_BOSS5_MGR_WORK.proc_update != null )
        {
            gms_BOSS5_MGR_WORK.proc_update( gms_BOSS5_MGR_WORK );
        }
    }

    // Token: 0x06000B5E RID: 2910 RVA: 0x000662FD File Offset: 0x000644FD
    private static void gmBoss5MgrProcInit( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateWaitOpeningDemoBegin );
    }

    // Token: 0x06000B5F RID: 2911 RVA: 0x00066314 File Offset: 0x00064514
    private static void gmBoss5MgrProcUpdateWaitOpeningDemoBegin( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 2097152U ) != 0U && ( mgr_work.flag & 4194304U ) != 0U )
        {
            AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
            AppMain.g_gm_main_system.game_flag &= 4294966271U;
            AppMain.GmSoundChangeFinalBossBGM();
            AppMain.GmPlySeqChangeBoss5Demo( ply_work, mgr_work.ply_demo_run_dest_x, false );
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateOpeningDemo );
            AppMain.GmMapSetMapDrawSize( 8 );
        }
    }

    // Token: 0x06000B60 RID: 2912 RVA: 0x00066388 File Offset: 0x00064588
    private static void gmBoss5MgrProcUpdateOpeningDemo( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 33554432U ) != 0U )
        {
            AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
            AppMain.g_gm_main_system.game_flag |= 1024U;
            AppMain.GmPlySeqChangeBoss5DemoEnd( ply_work );
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateIdle );
        }
    }

    // Token: 0x06000B61 RID: 2913 RVA: 0x000663DC File Offset: 0x000645DC
    private static void gmBoss5MgrProcUpdateIdle( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 67108864U ) != 0U )
        {
            AppMain.GmBoss5LandCreate( mgr_work );
            AppMain.gmBoss5TransferPlayerToASide();
            AppMain.gmBoss5HideMapBSide();
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateWaitDefeat );
        }
    }

    // Token: 0x06000B62 RID: 2914 RVA: 0x00066410 File Offset: 0x00064610
    private static void gmBoss5MgrProcUpdateWaitDefeat( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 134217728U ) != 0U )
        {
            AppMain.g_gm_main_system.game_flag &= 4294966271U;
            AppMain.g_gm_main_system.game_flag |= 1048576U;
            mgr_work.wait_timer = AppMain.GMD_BOSS5_MGR_WAIT_EXPLODE_TIME;
            AppMain.GmPadVibSet( 1, -1f, 16384, 16384, -1f, 0f, 0f, 32768U );
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateWaitExplode );
        }
    }

    // Token: 0x06000B63 RID: 2915 RVA: 0x0006649D File Offset: 0x0006469D
    private static void gmBoss5MgrProcUpdateWaitExplode( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
            return;
        }
        mgr_work.wait_timer = AppMain.GMD_BOSS5_MGR_CLOSING_DEMO_WAIT_BEGIN_TIME_MAX;
        AppMain.gmBoss5CamScrLimitReleaseGently();
        mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateWaitClosingDemoBegin );
    }

    // Token: 0x06000B64 RID: 2916 RVA: 0x000664D8 File Offset: 0x000646D8
    private static void gmBoss5MgrProcUpdateWaitClosingDemoBegin( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
        }
        if ( ( AppMain.GmBsCmnGetPlayerObj().move_flag & 1U ) != 0U || mgr_work.wait_timer == 0U )
        {
            AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
            AppMain.GmPlySeqChangeBoss5Demo( ply_work, AppMain.g_gm_main_system.map_size[0] << 12, true );
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateClosingDemoLeaveBody );
        }
    }

    // Token: 0x06000B65 RID: 2917 RVA: 0x00066544 File Offset: 0x00064744
    private static void gmBoss5MgrProcUpdateClosingDemoLeaveBody( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 268435456U ) != 0U )
        {
            AppMain.gmBoss5InitChasingExpl( mgr_work );
            mgr_work.wait_timer = AppMain.GMD_BOSS5_MGR_CLOSING_DEMO_DURATION_TIME;
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateClosingDemoEscape );
        }
    }

    // Token: 0x06000B66 RID: 2918 RVA: 0x00066577 File Offset: 0x00064777
    private static void gmBoss5MgrProcUpdateClosingDemoEscape( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.gmBoss5UpdateChasingExpl( mgr_work );
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5InitLastFadeOut( mgr_work );
        mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateClosingDemoWaitFadeEnd );
    }

    // Token: 0x06000B67 RID: 2919 RVA: 0x000665AE File Offset: 0x000647AE
    private static void gmBoss5MgrProcUpdateClosingDemoWaitFadeEnd( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.gmBoss5UpdateChasingExpl( mgr_work );
        if ( ( mgr_work.flag & 2147483648U ) != 0U )
        {
            AppMain.GMM_PAD_VIB_STOP();
            mgr_work.wait_timer = AppMain.GMD_BOSS5_MGR_CLOSING_DEMO_WHITEOUT_TIME;
            mgr_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.gmBoss5MgrProcUpdateClosingDemoWaitFinish );
        }
    }

    // Token: 0x06000B68 RID: 2920 RVA: 0x000665E6 File Offset: 0x000647E6
    private static void gmBoss5MgrProcUpdateClosingDemoWaitFinish( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
            return;
        }
        AppMain.g_gm_main_system.game_flag |= 4U;
        mgr_work.proc_update = null;
    }

    // Token: 0x06000B69 RID: 2921 RVA: 0x00066618 File Offset: 0x00064818
    private static void gmBoss5BodyExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS5_BODY_WORK body_work = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss5BodyReleaseCallbacks( body_work );
        AppMain.gmBoss5BodyFreeSeHandles( body_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000B6A RID: 2922 RVA: 0x00066643 File Offset: 0x00064843
    private static void gmBoss5BodySetActionWhole( AppMain.GMS_BOSS5_BODY_WORK body_work, int act_id )
    {
        AppMain.gmBoss5BodySetActionWhole( body_work, act_id, 0 );
    }

    // Token: 0x06000B6B RID: 2923 RVA: 0x00066650 File Offset: 0x00064850
    private static void gmBoss5BodySetActionWhole( AppMain.GMS_BOSS5_BODY_WORK body_work, int act_id, int force_change )
    {
        AppMain.GMS_BOSS5_PART_ACT_INFO[] array = AppMain.gm_boss5_act_id_tbl[act_id];
        if ( force_change == 0 && body_work.whole_act_id == act_id )
        {
            return;
        }
        body_work.whole_act_id = act_id;
        for ( int i = 0; i < 1; i++ )
        {
            if ( body_work.parts_objs[i] != null )
            {
                if ( array[i].is_maintain == 0 )
                {
                    AppMain.GmBsCmnSetAction( body_work.parts_objs[i], ( int )array[i].act_id, ( int )array[i].is_repeat, array[i].is_blend );
                }
                else if ( array[i].is_repeat != 0 )
                {
                    AppMain.GMM_BS_OBJ( body_work ).disp_flag |= 4U;
                }
                body_work.parts_objs[i].obj_3d.speed[0] = array[i].mtn_spd;
                body_work.parts_objs[i].obj_3d.blend_spd = array[i].blend_spd;
            }
        }
    }

    // Token: 0x06000B6C RID: 2924 RVA: 0x0006671C File Offset: 0x0006491C
    private static void gmBoss5BodySetDirection( AppMain.GMS_BOSS5_BODY_WORK body_work, int dir_type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        switch ( dir_type )
        {
            case 0:
                obs_OBJECT_WORK.dir.y = ( ushort )AppMain.AKM_DEGtoA16( -90 );
                obs_OBJECT_WORK.disp_flag |= 1U;
                return;
            case 1:
                obs_OBJECT_WORK.dir.y = ( ushort )AppMain.AKM_DEGtoA16( 90 );
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                return;
            case 2:
                obs_OBJECT_WORK.dir.y = 0;
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                return;
            default:
                obs_OBJECT_WORK.dir.y = ( ushort )AppMain.AKM_DEGtoA16( -90 );
                obs_OBJECT_WORK.disp_flag |= 1U;
                return;
        }
    }

    // Token: 0x06000B6D RID: 2925 RVA: 0x000667C8 File Offset: 0x000649C8
    private static int gmBoss5BodyIsPlayerBehind( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK part_obj_core = body_work.part_obj_core;
        if ( ( obs_OBJECT_WORK2.disp_flag & 1U ) != 0U )
        {
            if ( part_obj_core.pos.x < obs_OBJECT_WORK.pos.x )
            {
                return 1;
            }
        }
        else if ( obs_OBJECT_WORK.pos.x < part_obj_core.pos.x )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000B6E RID: 2926 RVA: 0x00066828 File Offset: 0x00064A28
    private static void gmBoss5BodySetNoHitTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_RECT_WORK[][] array = new AppMain.OBS_RECT_WORK[][]
        {
            body_work.sub_rect_work[0],
            body_work.sub_rect_work[1],
            ((AppMain.GMS_ENEMY_COM_WORK)body_work).rect_work
        };
        body_work.no_hit_timer = ( uint )AppMain.GMD_BOSS5_BODY_DMG_NO_HIT_TIME;
        body_work.flag |= 32U;
        for ( int i = 0; i < 3; i++ )
        {
            array[i][0].flag |= 2048U;
            array[i][0].flag &= 4294967291U;
        }
    }

    // Token: 0x06000B6F RID: 2927 RVA: 0x000668B4 File Offset: 0x00064AB4
    private static void gmBoss5BodyUpdateNoHitTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.no_hit_timer != 0U )
        {
            body_work.no_hit_timer -= 1U;
            return;
        }
        AppMain.OBS_RECT_WORK[][] array = new AppMain.OBS_RECT_WORK[][]
        {
            body_work.sub_rect_work[0],
            body_work.sub_rect_work[1],
            ((AppMain.GMS_ENEMY_COM_WORK)body_work).rect_work
        };
        body_work.flag &= 4294967263U;
        for ( int i = 0; i < 3; i++ )
        {
            if ( ( ( ulong )body_work.def_rect_req_flag & ( ulong )( 1L << ( i & 31 ) ) ) != 0UL )
            {
                array[i][0].flag &= 4294965247U;
                array[i][0].flag |= 4U;
            }
            else
            {
                array[i][0].flag |= 2048U;
                array[i][0].flag &= 4294967291U;
            }
        }
    }

    // Token: 0x06000B70 RID: 2928 RVA: 0x00066986 File Offset: 0x00064B86
    private static void gmBoss5BodySetPokeTriggerLimitTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.poke_trg_limit_timer = 120U;
        body_work.flag |= 128U;
    }

    // Token: 0x06000B71 RID: 2929 RVA: 0x000669A2 File Offset: 0x00064BA2
    private static void gmBoss5BodyUpdatePokeTriggerLimitTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.poke_trg_limit_timer != 0U )
        {
            body_work.poke_trg_limit_timer -= 1U;
            return;
        }
        body_work.flag &= 4294967167U;
    }

    // Token: 0x06000B72 RID: 2930 RVA: 0x000669CD File Offset: 0x00064BCD
    private static int gmBoss5BodyIsWithinPokeTriggerLimitTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 128U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000B73 RID: 2931 RVA: 0x000669E0 File Offset: 0x00064BE0
    private static void gmBoss5BodyClearPokeTriggerLimitTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.poke_trg_limit_timer = 0U;
        body_work.flag &= 4294967167U;
    }

    // Token: 0x06000B74 RID: 2932 RVA: 0x000669FC File Offset: 0x00064BFC
    private static void gmBoss5BodyExecDamageRoutine( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = body_work.mgr_work;
        if ( mgr_work.life != 0 )
        {
            mgr_work.life--;
        }
        if ( 0 < mgr_work.life )
        {
            body_work.flag |= 2147483648U;
            if ( body_work.state == 2 )
            {
                if ( AppMain.gmBoss5BodyIsWithinPokeTriggerLimitTime( body_work ) != 0 )
                {
                    if ( AppMain.gmBoss5BodyIsPoking( body_work ) == 0 )
                    {
                        body_work.flag |= 8388608U;
                    }
                }
                else
                {
                    AppMain.gmBoss5BodySetPokeTriggerLimitTime( body_work );
                }
            }
            AppMain.gmBoss5BodyTryStartTurret( body_work );
        }
        else if ( ( body_work.flag & 65536U ) == 0U )
        {
            mgr_work.life = 1;
        }
        else
        {
            body_work.flag |= 4194304U;
            AppMain.GMM_BS_OBJ( body_work ).flag |= 2U;
            mgr_work.life = 0;
        }
        AppMain.gmBoss5BodySeqTryRequestEnableStr( body_work );
    }

    // Token: 0x06000B75 RID: 2933 RVA: 0x00066AC8 File Offset: 0x00064CC8
    private static void gmBoss5BodyUpdateMainRectPosition( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK part_obj_core = body_work.part_obj_core;
        int x = part_obj_core.pos.x - obs_OBJECT_WORK.pos.x;
        int y = part_obj_core.pos.y - obs_OBJECT_WORK.pos.y;
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.VEC_Set( ref body_work.ene_3d.ene_com.rect_work[i].rect.pos, x, y, 0 );
        }
    }

    // Token: 0x06000B76 RID: 2934 RVA: 0x00066B48 File Offset: 0x00064D48
    private static void gmBoss5BodyUpdateSubRectPosition( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.snm_reg_id_tbl[0] = body_work.leg_snm_reg_ids[0];
        AppMain.snm_reg_id_tbl[1] = body_work.leg_snm_reg_ids[1];
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, AppMain.snm_reg_id_tbl[i]);
            int x = AppMain.FX_F32_TO_FX32(nns_MATRIX.M03) - body_work.pivot_prev_pos.x;
            int y = -AppMain.FX_F32_TO_FX32(nns_MATRIX.M13) - body_work.pivot_prev_pos.y;
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.VEC_Set( ref body_work.sub_rect_work[i][j].rect.pos, x, y, 0 );
            }
        }
    }

    // Token: 0x06000B77 RID: 2935 RVA: 0x00066BF8 File Offset: 0x00064DF8
    private static void gmBoss5BodySetupRect( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_RECT_WORK[][] array = new AppMain.OBS_RECT_WORK[][]
        {
            body_work.sub_rect_work[0],
            body_work.sub_rect_work[1],
            ((AppMain.GMS_ENEMY_COM_WORK)body_work).rect_work
        };
        ushort[] array2 = new ushort[]
        {
            default(ushort),
            2,
            1
        };
        ushort[] array3 = new ushort[]
        {
            65533,
            ushort.MaxValue,
            65534
        };
        for ( int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.ObjRectGroupSet( body_work.sub_rect_work[i][j], 1, 1 );
                AppMain.ObjRectAtkSet( body_work.sub_rect_work[i][j], array2[j], 1 );
                AppMain.ObjRectDefSet( body_work.sub_rect_work[i][j], array3[j], 0 );
                body_work.sub_rect_work[i][j].parent_obj = parent_obj;
                body_work.sub_rect_work[i][j].flag &= 4294967291U;
            }
            body_work.sub_rect_work[i][0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.GmEnemyDefaultDefFunc );
            body_work.sub_rect_work[i][1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.GmEnemyDefaultAtkFunc );
            body_work.sub_rect_work[i][2].flag |= 1048800U;
        }
        for ( int k = 0; k < 3; k++ )
        {
            array[k][0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss5BodyDamageDefFunc );
        }
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 0 );
    }

    // Token: 0x06000B78 RID: 2936 RVA: 0x00066D78 File Offset: 0x00064F78
    private static void gmBoss5BodyChangeRectSetting( AppMain.GMS_BOSS5_BODY_WORK body_work, int rect_setting )
    {
        AppMain.OBS_RECT_WORK[][] array = new AppMain.OBS_RECT_WORK[][]
        {
            body_work.sub_rect_work[0],
            body_work.sub_rect_work[1],
            ((AppMain.GMS_ENEMY_COM_WORK)body_work).rect_work
        };
        AppMain.GMS_BOSS5_BODY_RECT_SETTING_INFO gms_BOSS5_BODY_RECT_SETTING_INFO = AppMain.gm_boss5_body_rect_setting_info_tbl[rect_setting];
        if ( gms_BOSS5_BODY_RECT_SETTING_INFO.is_invincible != 0 )
        {
            body_work.flag |= 1U;
        }
        else
        {
            body_work.flag &= 4294967294U;
        }
        if ( gms_BOSS5_BODY_RECT_SETTING_INFO.is_leakage != 0 )
        {
            body_work.flag |= 4096U;
        }
        else
        {
            body_work.flag &= 4294963199U;
        }
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.GMS_BOSS5_RECTPOINT_SETTING_INFO gms_BOSS5_RECTPOINT_SETTING_INFO = gms_BOSS5_BODY_RECT_SETTING_INFO.point_setting_info[i];
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.ObjRectWorkSet( array[i][j], gms_BOSS5_RECTPOINT_SETTING_INFO.rect_size[j][0], gms_BOSS5_RECTPOINT_SETTING_INFO.rect_size[j][1], gms_BOSS5_RECTPOINT_SETTING_INFO.rect_size[j][2], gms_BOSS5_RECTPOINT_SETTING_INFO.rect_size[j][3] );
                if ( ( 1L << ( j & 31 ) & ( long )( ( ulong )gms_BOSS5_RECTPOINT_SETTING_INFO.enable_bit_flag ) ) != 0L )
                {
                    if ( j == 0 )
                    {
                        body_work.def_rect_req_flag |= 1U << i;
                        if ( ( body_work.flag & 32U ) == 0U )
                        {
                            array[i][j].flag &= 4294965247U;
                            array[i][j].flag |= 4U;
                        }
                    }
                    else
                    {
                        array[i][j].flag &= 4294965247U;
                        array[i][j].flag |= 4U;
                    }
                }
                else
                {
                    array[i][j].flag |= 2048U;
                    array[i][j].flag &= 4294967291U;
                    if ( j == 0 )
                    {
                        body_work.def_rect_req_flag &= ~( 1U << i );
                    }
                }
            }
        }
    }

    // Token: 0x06000B79 RID: 2937 RVA: 0x00066F51 File Offset: 0x00065151
    private static void gmBoss5BodyChangeRectSettingDefault( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodySeqIsStr( body_work ) != 0 )
        {
            AppMain.gmBoss5BodyChangeRectSetting( body_work, 1 );
            return;
        }
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 0 );
    }

    // Token: 0x06000B7A RID: 2938 RVA: 0x00066F6C File Offset: 0x0006516C
    private static void gmBoss5BodySwitchEnableLegRectOneSide( AppMain.GMS_BOSS5_BODY_WORK body_work, int leg_type )
    {
        int num;
        int num2;
        if ( leg_type == 0 )
        {
            num = 0;
            num2 = 1;
        }
        else
        {
            num = 1;
            num2 = 0;
        }
        body_work.sub_rect_work[num][1].flag &= 4294965247U;
        body_work.sub_rect_work[num][1].flag |= 4U;
        body_work.sub_rect_work[num2][1].flag |= 2048U;
        body_work.sub_rect_work[num2][1].flag &= 4294967291U;
    }

    // Token: 0x06000B7B RID: 2939 RVA: 0x00066FEB File Offset: 0x000651EB
    private static void gmBoss5BodyTryImmobilizePlayer( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
        if ( ( AppMain.GmBsCmnGetPlayerObj().move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqGmkInitBoss5Quake( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), AppMain.GMD_BOSS5_BODY_CRASH_PLY_IMMOBILE_TIME );
        }
    }

    // Token: 0x06000B7C RID: 2940 RVA: 0x00067015 File Offset: 0x00065215
    private static void gmBoss5BodyAllocSeHandles( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.se_hnd_leakage = AppMain.GsSoundAllocSeHandle();
    }

    // Token: 0x06000B7D RID: 2941 RVA: 0x00067022 File Offset: 0x00065222
    private static void gmBoss5BodyFreeSeHandles( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.se_hnd_leakage != null )
        {
            AppMain.GsSoundFreeSeHandle( body_work.se_hnd_leakage );
            body_work.se_hnd_leakage = null;
        }
    }

    // Token: 0x06000B7E RID: 2942 RVA: 0x0006703E File Offset: 0x0006523E
    private static void gmBoss5BodyInitPlayTargetSe( AppMain.GMS_BOSS5_BODY_WORK body_work, float init_interval )
    {
        body_work.targ_se_cur_interval = init_interval;
        AppMain.GmBoss5Init1ShotTimer( body_work.targ_se_timer, ( uint )body_work.targ_se_cur_interval );
        AppMain.GmSoundPlaySE( "FinalBoss05" );
    }

    // Token: 0x06000B7F RID: 2943 RVA: 0x00067064 File Offset: 0x00065264
    private static void gmBoss5BodyUpdatePlayTargetSe( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.targ_se_cur_interval >= 0f )
        {
            body_work.targ_se_cur_interval -= AppMain.GMD_BOSS5_BODY_SE_TARGET_INTERVAL_DEC_SPD;
        }
        else
        {
            body_work.targ_se_cur_interval = 0f;
        }
        if ( AppMain.GmBoss5Update1ShotTimer( body_work.targ_se_timer ) != 0 )
        {
            uint num = (uint)body_work.targ_se_cur_interval;
            if ( ( ulong )num <= ( ulong )( ( long )AppMain.GMD_BOSS5_BODY_SE_TARGET_INTERVAL_MIN ) )
            {
                num = ( uint )AppMain.GMD_BOSS5_BODY_SE_TARGET_INTERVAL_MIN;
            }
            AppMain.GmSoundPlaySE( "FinalBoss05" );
            AppMain.GmBoss5Init1ShotTimer( body_work.targ_se_timer, num );
        }
    }

    // Token: 0x06000B80 RID: 2944 RVA: 0x000670D8 File Offset: 0x000652D8
    private static void gmBoss5BodyForceEndLeakage( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4294963199U;
        AppMain.GmBoss5EfctEndLeakage( body_work, 1 );
    }

    // Token: 0x06000B81 RID: 2945 RVA: 0x000670F3 File Offset: 0x000652F3
    private static void gmBoss5BodyInitPlySearch( AppMain.GMS_BOSS5_BODY_WORK body_work, int delay )
    {
        body_work.ply_search_delay = delay;
        AppMain.GmBsCmnInitDelaySearch( body_work.dsearch_work, AppMain.GmBsCmnGetPlayerObj(), body_work.search_hist_buf, 11 );
    }

    // Token: 0x06000B82 RID: 2946 RVA: 0x00067114 File Offset: 0x00065314
    private static void gmBoss5BodyUpdatePlySearch( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GmBsCmnUpdateDelaySearch( body_work.dsearch_work );
    }

    // Token: 0x06000B83 RID: 2947 RVA: 0x00067124 File Offset: 0x00065324
    private static void gmBoss5BodySetPlyRebound( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ply_work;
        AppMain.GmPlySeqAtkReactionInit( ply_work );
        if ( ply_work.seq_state == 20 )
        {
            AppMain.GmPlySeqSetJumpState( ply_work, 0, 5U );
            ply_work.obj_work.spd_m = 0;
            if ( ply_work.obj_work.move.x >= 0 )
            {
                ply_work.obj_work.spd.x = -AppMain.GMD_BOSS5_BODY_PLY_HOMING_REBOUND_X;
            }
            else
            {
                ply_work.obj_work.spd.x = AppMain.GMD_BOSS5_BODY_PLY_HOMING_REBOUND_X;
            }
            if ( obs_OBJECT_WORK.pos.y <= body_work.part_obj_core.pos.y )
            {
                ply_work.obj_work.spd.y = AppMain.GMD_BOSS5_BODY_PLY_HOMING_REBOUND_Y;
            }
            else
            {
                ply_work.obj_work.spd.y = -AppMain.GMD_BOSS5_BODY_PLY_HOMING_REBOUND_Y;
            }
            AppMain.GmPlySeqSetNoJumpMoveTime( ply_work, AppMain.GMD_BOSS5_BODY_PLY_HOMING_REBOUND_NOJUMPMOVE_TIME );
            return;
        }
        ply_work.obj_work.spd_m = 0;
        if ( ply_work.obj_work.move.x >= 0 )
        {
            ply_work.obj_work.spd.x = -AppMain.GMD_BOSS5_BODY_PLY_NML_REBOUND_X;
        }
        else
        {
            ply_work.obj_work.spd.x = AppMain.GMD_BOSS5_BODY_PLY_NML_REBOUND_X;
        }
        if ( obs_OBJECT_WORK.pos.y <= body_work.part_obj_core.pos.y )
        {
            ply_work.obj_work.spd.y = AppMain.GMD_BOSS5_BODY_PLY_NML_REBOUND_Y;
        }
        else
        {
            ply_work.obj_work.spd.y = -AppMain.GMD_BOSS5_BODY_PLY_NML_REBOUND_Y;
        }
        AppMain.GmPlySeqSetNoJumpMoveTime( ply_work, AppMain.GMD_BOSS5_BODY_PLY_NML_REBOUND_NOJUMPMOVE_TIME );
        ply_work.homing_timer = AppMain.GMD_BOSS5_BODY_DMG_NO_HIT_TIME * 4096;
    }

    // Token: 0x06000B84 RID: 2948 RVA: 0x000672A7 File Offset: 0x000654A7
    private static void gmBoss5BodySetMoveFastTime( AppMain.GMS_BOSS5_BODY_WORK body_work, uint fast_move_time )
    {
        body_work.fast_move_timer = fast_move_time;
    }

    // Token: 0x06000B85 RID: 2949 RVA: 0x000672B0 File Offset: 0x000654B0
    private static void gmBoss5BodyUpdateMoveFastTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.fast_move_timer != 0U )
        {
            body_work.fast_move_timer -= 1U;
        }
    }

    // Token: 0x06000B86 RID: 2950 RVA: 0x000672C8 File Offset: 0x000654C8
    private static int gmBoss5BodyIsMoveFastEnd( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.fast_move_timer != 0U )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000B87 RID: 2951 RVA: 0x000672D8 File Offset: 0x000654D8
    private static int gmBoss5BodyGetStompFallPosX( AppMain.GMS_BOSS5_BODY_WORK body_work, int search_pos_x )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
        int num = 0;
        int num2 = search_pos_x - AppMain.GMD_BOSS5_BODY_STOMP_FALL_POS_MARGIN;
        int num3 = search_pos_x + AppMain.GMD_BOSS5_BODY_STOMP_FALL_POS_MARGIN;
        if ( num2 <= AppMain.GMM_BOSS5_AREA_LEFT() )
        {
            num = AppMain.GMM_BOSS5_AREA_LEFT() - num2;
        }
        else if ( num3 >= AppMain.GMM_BOSS5_AREA_RIGHT() )
        {
            num = AppMain.GMM_BOSS5_AREA_RIGHT() - num3;
        }
        return search_pos_x + num;
    }

    // Token: 0x06000B88 RID: 2952 RVA: 0x00067324 File Offset: 0x00065524
    private static void gmBoss5BodyDecideCrashFallPosX( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        ushort num = 0;
        uint num2;
        if ( AppMain.g_gm_main_system.game_time >= 35999U )
        {
            num2 = 35999U;
        }
        else
        {
            num2 = AppMain.g_gm_main_system.game_time;
        }
        AppMain.AkUtilFrame60ToTime( num2, default( ushort? ), ref num, default( ushort? ) );
        num = ( ushort )( num2 % 10U );
        switch ( num )
        {
            case 3:
            case 5:
            case 7:
            case 9:
                body_work.crash_pos_ofst_x = 1048576;
                return;
            case 4:
            case 6:
            case 8:
                body_work.crash_pos_ofst_x = -1048576;
                return;
        }
        body_work.crash_pos_ofst_x = 0;
    }

    // Token: 0x06000B89 RID: 2953 RVA: 0x000673CA File Offset: 0x000655CA
    private static int gmBoss5BodyGetCrashFallPosX( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        return AppMain.GMM_BOSS5_AREA_CENTER_X() + body_work.crash_pos_ofst_x;
    }

    // Token: 0x06000B8A RID: 2954 RVA: 0x000673D8 File Offset: 0x000655D8
    private static int gmBoss5BodyCheckJetSmokeClearTiming( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y <= body_work.ground_v_pos - AppMain.GMD_BOSS5_BODY_JETSMOKE_CLEAR_HEIGHT )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000B8B RID: 2955 RVA: 0x00067408 File Offset: 0x00065608
    private static int gmBoss5BodyIsMoveFastDirFwd( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.state == 3 )
        {
            return 1;
        }
        if ( body_work.state == 4 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000B8C RID: 2956 RVA: 0x00067424 File Offset: 0x00065624
    private static int gmBoss5BodyIsBodyExplosionStopAllowed( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int num = AppMain.ObjViewOutCheck(body_work.part_obj_core.pos.x, body_work.ground_v_pos, 0, (short)(-(short)(AppMain.GMD_BOSS5_EXPL_BODY_OFST_X + AppMain.GMD_BOSS5_EXPL_BODY_WIDTH / 2 >> 12)), (short)(-(short)(AppMain.GMD_BOSS5_EXPL_BODY_OFST_Y + AppMain.GMD_BOSS5_EXPL_BODY_HEIGHT / 2 >> 12)), (short)(-(short)(AppMain.GMD_BOSS5_EXPL_BODY_OFST_X - AppMain.GMD_BOSS5_EXPL_BODY_WIDTH / 2 >> 12)), (short)(-(short)(AppMain.GMD_BOSS5_EXPL_BODY_OFST_Y - AppMain.GMD_BOSS5_EXPL_BODY_HEIGHT / 2 >> 12)));
        if ( AppMain.GmBsCmnGetPlayerObj().pos.x < body_work.part_obj_core.pos.x )
        {
            num = 0;
        }
        if ( num != 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000B8D RID: 2957 RVA: 0x000674C0 File Offset: 0x000656C0
    private static int gmBoss5BodyGetStompFallDirectionType( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.x <= AppMain.GMM_BOSS5_AREA_LEFT() + AppMain.GMD_BOSS5_BODY_STOMP_WALL_BEHIND_WALL_DISTANCE )
        {
            return 1;
        }
        if ( obs_OBJECT_WORK.pos.x >= AppMain.GMM_BOSS5_AREA_RIGHT() - AppMain.GMD_BOSS5_BODY_STOMP_WALL_BEHIND_WALL_DISTANCE )
        {
            return 0;
        }
        if ( obs_OBJECT_WORK.pos.x < AppMain.GmBsCmnGetPlayerObj().pos.x )
        {
            return 1;
        }
        if ( obs_OBJECT_WORK.pos.x > AppMain.GmBsCmnGetPlayerObj().pos.x )
        {
            return 0;
        }
        if ( ( AppMain.GmBsCmnGetPlayerObj().disp_flag & 1U ) != 0U )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000B8E RID: 2958 RVA: 0x00067555 File Offset: 0x00065755
    private static void gmBoss5BodyTryStartTurret( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.mgr_work.life <= AppMain.GMD_BOSS5_TURRET_START_LIFE_THRESHOLD && ( body_work.flag & 1024U ) == 0U )
        {
            body_work.flag |= 1024U;
            AppMain.GmBoss5TurretStartUp( body_work );
        }
    }

    // Token: 0x06000B8F RID: 2959 RVA: 0x00067590 File Offset: 0x00065790
    private static void gmBoss5BodyRecordGapAdjustmentDest( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int[] array = new int[]
        {
            body_work.lfoot_snm_reg_id,
            body_work.rfoot_snm_reg_id
        };
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, array[i]);
            int x = body_work.grdmv_pivot_pos.x;
            int num = AppMain.FX_F32_TO_FX32(nns_MATRIX.M03);
            body_work.foot_ofst_record_dest[i] = num - x;
            if ( ( AppMain.GMM_BS_OBJ( body_work ).disp_flag & 1U ) != 0U )
            {
                body_work.foot_ofst_record_dest[i] = -body_work.foot_ofst_record_dest[i];
            }
        }
    }

    // Token: 0x06000B90 RID: 2960 RVA: 0x00067624 File Offset: 0x00065824
    private static void gmBoss5BodyRecordGapAdjustmentSrc( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int[] array = new int[]
        {
            body_work.lfoot_snm_reg_id,
            body_work.rfoot_snm_reg_id
        };
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, array[i]);
            int x = body_work.grdmv_pivot_pos.x;
            int num = AppMain.FX_F32_TO_FX32(nns_MATRIX.M03);
            body_work.foot_ofst_record_src[i] = num - x;
            if ( ( AppMain.GMM_BS_OBJ( body_work ).disp_flag & 1U ) != 0U )
            {
                body_work.foot_ofst_record_src[i] = -body_work.foot_ofst_record_src[i];
            }
        }
    }

    // Token: 0x06000B91 RID: 2961 RVA: 0x000676B6 File Offset: 0x000658B6
    private static void gmBoss5BodyInitAdjustMtnBlendHGap( AppMain.GMS_BOSS5_BODY_WORK body_work, int dest_act_id, int leg_type )
    {
        body_work.adj_hgap_is_active = 1;
        body_work.adj_hgap_act_id = dest_act_id;
        body_work.adj_hgap_leg_type = leg_type;
    }

    // Token: 0x06000B92 RID: 2962 RVA: 0x000676D0 File Offset: 0x000658D0
    private static void gmBoss5BodyUpdateAdjustMtnBlendHGap( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( body_work.adj_hgap_is_active == 0 )
        {
            return;
        }
        int num = body_work.foot_ofst_record_dest[body_work.adj_hgap_leg_type] - body_work.foot_ofst_record_src[body_work.adj_hgap_leg_type];
        num = ( int )( ( float )num * AppMain.gm_boss5_act_id_tbl[body_work.adj_hgap_act_id][0].blend_spd );
        if ( ( AppMain.GMM_BS_OBJ( body_work ).disp_flag & 1U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + num;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
        obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x - num;
    }

    // Token: 0x06000B93 RID: 2963 RVA: 0x00067757 File Offset: 0x00065957
    private static void gmBoss5BodyClearAdjustMtnBlendHGap( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.adj_hgap_is_active = 0;
    }

    // Token: 0x06000B94 RID: 2964 RVA: 0x00067760 File Offset: 0x00065960
    private static void gmBoss5BodyInitGroundingMove( AppMain.GMS_BOSS5_BODY_WORK body_work, int ref_snm_reg_id )
    {
        AppMain.GMS_BOSS5_GRD_MOVE_WORK grdmv_work = body_work.grdmv_work;
        grdmv_work.cur_diff_x = 0;
        grdmv_work.prev_diff_x = 0;
        grdmv_work.ref_snm_reg_id = ref_snm_reg_id;
        grdmv_work.is_first_updated = 0;
    }

    // Token: 0x06000B95 RID: 2965 RVA: 0x00067790 File Offset: 0x00065990
    private static void gmBoss5BodyUpdateGroundingMove( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_GRD_MOVE_WORK grdmv_work = body_work.grdmv_work;
        if ( grdmv_work.ref_snm_reg_id == -1 )
        {
            return;
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, grdmv_work.ref_snm_reg_id);
        int x = body_work.grdmv_pivot_pos.x;
        int num = AppMain.FX_F32_TO_FX32(nns_MATRIX.M03);
        grdmv_work.prev_diff_x = grdmv_work.cur_diff_x;
        grdmv_work.cur_diff_x = num - x;
        if ( grdmv_work.is_first_updated == 0 )
        {
            grdmv_work.is_first_updated = 1;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.pos.x = obs_OBJECT_WORK.pos.x - ( grdmv_work.cur_diff_x - grdmv_work.prev_diff_x );
    }

    // Token: 0x06000B96 RID: 2966 RVA: 0x00067824 File Offset: 0x00065A24
    private static void gmBoss5BodyChangeMovePhase( AppMain.GMS_BOSS5_BODY_WORK body_work, int move_phase_type )
    {
        body_work.cur_move_phase_type = move_phase_type;
        int ref_snm_reg_id;
        if ( body_work.cur_move_phase_type == 1 )
        {
            ref_snm_reg_id = body_work.lfoot_snm_reg_id;
        }
        else if ( body_work.cur_move_phase_type == 2 )
        {
            ref_snm_reg_id = body_work.rfoot_snm_reg_id;
        }
        else
        {
            ref_snm_reg_id = -1;
        }
        AppMain.gmBoss5BodyInitGroundingMove( body_work, ref_snm_reg_id );
    }

    // Token: 0x06000B97 RID: 2967 RVA: 0x00067865 File Offset: 0x00065A65
    private static void gmBoss5BodyInitWalk( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyChangeMovePhase( body_work, AppMain.gm_boss5_body_walk_move_info_tbl[0].move_phase_type );
    }

    // Token: 0x06000B98 RID: 2968 RVA: 0x0006787C File Offset: 0x00065A7C
    private static int gmBoss5BodyUpdateWalk( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num = obs_OBJECT_WORK.obj_3d.frame[0];
        AppMain.gmBoss5BodyUpdateGroundingMove( body_work );
        int i = 3;
        while ( i >= 0 )
        {
            if ( AppMain.gm_boss5_body_walk_move_info_tbl[i].switching_frame <= num )
            {
                if ( AppMain.gm_boss5_body_walk_move_info_tbl[i].move_phase_type != body_work.cur_move_phase_type )
                {
                    AppMain.gmBoss5BodyChangeMovePhase( body_work, AppMain.gm_boss5_body_walk_move_info_tbl[i].move_phase_type );
                    break;
                }
                break;
            }
            else
            {
                i--;
            }
        }
        if ( i >= 3 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000B99 RID: 2969 RVA: 0x000678F0 File Offset: 0x00065AF0
    private static void gmBoss5BodyInitWalkAbortRecovery( AppMain.GMS_BOSS5_BODY_WORK body_work, int cur_move_phase_type )
    {
        int leg_type;
        if ( cur_move_phase_type == 1 )
        {
            leg_type = 0;
        }
        else
        {
            leg_type = 1;
        }
        AppMain.gmBoss5BodyInitWalkAbortRecoveryByLegType( body_work, leg_type );
    }

    // Token: 0x06000B9A RID: 2970 RVA: 0x0006790E File Offset: 0x00065B0E
    private static void gmBoss5BodyInitWalkAbortRecoveryByLegType( AppMain.GMS_BOSS5_BODY_WORK body_work, int leg_type )
    {
        AppMain.gmBoss5BodyRecordGapAdjustmentSrc( body_work );
        AppMain.gmBoss5BodyInitAdjustMtnBlendHGap( body_work, body_work.whole_act_id, leg_type );
        AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
    }

    // Token: 0x06000B9B RID: 2971 RVA: 0x0006792C File Offset: 0x00065B2C
    private static int gmBoss5BodyUpdateWalkAbortRecovery( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.obj_3d.flag & 1U ) != 0U )
        {
            AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
            return 0;
        }
        return 1;
    }

    // Token: 0x06000B9C RID: 2972 RVA: 0x00067958 File Offset: 0x00065B58
    private static void gmBoss5BodyInitMonitoringWalkEnd( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.walk_end_monitor_phase_cnt = 0;
        body_work.is_player_behind = 0;
    }

    // Token: 0x06000B9D RID: 2973 RVA: 0x00067968 File Offset: 0x00065B68
    private static int gmBoss5BodyUpdateMonitoringWalkEnd( AppMain.GMS_BOSS5_BODY_WORK body_work, int? leg_type )
    {
        int num = 0;
        return AppMain._gmBoss5BodyUpdateMonitoringWalkEnd( body_work, ref num, false );
    }

    // Token: 0x06000B9E RID: 2974 RVA: 0x00067980 File Offset: 0x00065B80
    private static int gmBoss5BodyUpdateMonitoringWalkEnd( AppMain.GMS_BOSS5_BODY_WORK body_work, ref int leg_type )
    {
        return AppMain._gmBoss5BodyUpdateMonitoringWalkEnd( body_work, ref leg_type, true );
    }

    // Token: 0x06000B9F RID: 2975 RVA: 0x0006798C File Offset: 0x00065B8C
    private static int _gmBoss5BodyUpdateMonitoringWalkEnd( AppMain.GMS_BOSS5_BODY_WORK body_work, ref int leg_type, bool ltAvailable )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num = obs_OBJECT_WORK.obj_3d.frame[0];
        int num2 = 0;
        if ( AppMain.gmBoss5BodyIsPlayerBehind( body_work ) != 0 )
        {
            body_work.is_player_behind = 1;
        }
        int i = 4;
        while ( i >= 0 )
        {
            if ( AppMain.gm_boss5_body_walk_ground_timing_info_tbl[i].grounding_frame <= num )
            {
                if ( i != body_work.walk_end_monitor_phase_cnt )
                {
                    num2 = 1;
                    body_work.walk_end_monitor_phase_cnt = i;
                    break;
                }
                break;
            }
            else
            {
                i--;
            }
        }
        if ( ltAvailable )
        {
            if ( i >= 0 )
            {
                leg_type = AppMain.gm_boss5_body_walk_ground_timing_info_tbl[i].leg_type;
            }
            else
            {
                leg_type = 0;
            }
        }
        if ( i >= 4 )
        {
            return 0;
        }
        if ( num2 != 0 )
        {
            if ( body_work.is_player_behind != 0 )
            {
                return 1;
            }
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                if ( obs_OBJECT_WORK.pos.x <= AppMain.GMM_BOSS5_AREA_LEFT() + AppMain.GMD_BOSS5_BODY_WALK_WALK_END_WALL_DISTANCE )
                {
                    return 1;
                }
            }
            else if ( obs_OBJECT_WORK.pos.x >= AppMain.GMM_BOSS5_AREA_RIGHT() - AppMain.GMD_BOSS5_BODY_WALK_WALK_END_WALL_DISTANCE )
            {
                return 1;
            }
        }
        return 0;
    }

    // Token: 0x06000BA0 RID: 2976 RVA: 0x00067A5A File Offset: 0x00065C5A
    private static void gmBoss5BodyInitWalkGroundingEffects( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.cur_walk_grnd_phase_cnt = 0;
    }

    // Token: 0x06000BA1 RID: 2977 RVA: 0x00067A64 File Offset: 0x00065C64
    private static int gmBoss5BodyUpdateWalkGroundingEffects( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num = obs_OBJECT_WORK.obj_3d.frame[0];
        int i = 4;
        while ( i >= 0 )
        {
            if ( AppMain.gm_boss5_body_walk_ground_timing_info_tbl[i].grounding_frame <= num )
            {
                if ( i != body_work.cur_walk_grnd_phase_cnt )
                {
                    AppMain.GmBoss5EfctCreateWalkStepSmoke( body_work, AppMain.gm_boss5_body_walk_ground_timing_info_tbl[i].leg_type );
                    AppMain.gmBoss5Vibration( 0 );
                    AppMain.GmSoundPlaySE( "FinalBoss03" );
                    body_work.cur_walk_grnd_phase_cnt = i;
                    break;
                }
                break;
            }
            else
            {
                i--;
            }
        }
        if ( i >= 4 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BA2 RID: 2978 RVA: 0x00067ADC File Offset: 0x00065CDC
    private static void gmBoss5BodyInitRunGroundingEffects( AppMain.GMS_BOSS5_BODY_WORK body_work, int run_type, uint delay )
    {
        body_work.run_grnd_runtype = run_type;
        body_work.run_grnd_delay_timer = delay;
        body_work.run_grnd_spawn_remain = 1U;
    }

    // Token: 0x06000BA3 RID: 2979 RVA: 0x00067AF4 File Offset: 0x00065CF4
    private static int gmBoss5BodyUpdateRunGroundingEffects( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.run_grnd_delay_timer != 0U )
        {
            body_work.run_grnd_delay_timer -= 1U;
            return 0;
        }
        if ( body_work.run_grnd_spawn_remain != 0U )
        {
            body_work.run_grnd_spawn_remain -= 1U;
            switch ( body_work.run_grnd_runtype )
            {
                case 0:
                    AppMain.GmBoss5EfctCreateRunStepSmoke( body_work, 0 );
                    break;
                case 1:
                    AppMain.GmBoss5EfctCreateRunStepSmoke( body_work, 1 );
                    break;
            }
            AppMain.gmBoss5Vibration( 1 );
            AppMain.GmSoundPlaySE( "FinalBoss03" );
            return 1;
        }
        return 1;
    }

    // Token: 0x06000BA4 RID: 2980 RVA: 0x00067B70 File Offset: 0x00065D70
    private static void gmBoss5BodyInitStompFlyUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.move_flag &= 4294967166U;
        obs_OBJECT_WORK.move_flag |= 272U;
        obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_BODY_SFLYUP_INIT_SPD;
        obs_OBJECT_WORK.spd_add.y = AppMain.GMD_BOSS5_BODY_SFLYUP_ACC;
    }

    // Token: 0x06000BA5 RID: 2981 RVA: 0x00067BD0 File Offset: 0x00065DD0
    private static int gmBoss5BodyUpdateStompFlyUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y <= AppMain.GMM_BOSS5_AREA_TOP() - AppMain.GMD_BOSS5_BODY_HIDE_RADIUS )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BA6 RID: 2982 RVA: 0x00067C08 File Offset: 0x00065E08
    private static void gmBoss5BodyInitStompFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_BODY_STOMP_FALL_INIT_SPD;
        obs_OBJECT_WORK.spd_add.y = AppMain.GMD_BOSS5_BODY_STOMP_FALL_ACC;
    }

    // Token: 0x06000BA7 RID: 2983 RVA: 0x00067C44 File Offset: 0x00065E44
    private static int gmBoss5BodyUpdateStompFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y >= AppMain.GMM_BOSS5_AREA_TOP() )
        {
            obs_OBJECT_WORK.move_flag &= 4294967039U;
        }
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.move_flag |= 128U;
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BA8 RID: 2984 RVA: 0x00067CA4 File Offset: 0x00065EA4
    private static void gmBoss5BodyInitCrashFlyUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.move_flag &= 4294967166U;
        obs_OBJECT_WORK.move_flag |= 272U;
        obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_BODY_CFLYUP_INIT_SPD;
        obs_OBJECT_WORK.spd_add.y = AppMain.GMD_BOSS5_BODY_CFLYUP_ACC;
    }

    // Token: 0x06000BA9 RID: 2985 RVA: 0x00067D04 File Offset: 0x00065F04
    private static int gmBoss5BodyUpdateCrashFlyUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y <= AppMain.GMM_BOSS5_AREA_TOP() - AppMain.GMD_BOSS5_BODY_HIDE_RADIUS )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BAA RID: 2986 RVA: 0x00067D3C File Offset: 0x00065F3C
    private static void gmBoss5BodyInitCrashFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_BODY_CRASH_FALL_INIT_SPD;
        obs_OBJECT_WORK.spd_add.y = AppMain.GMD_BOSS5_BODY_CRASH_FALL_ACC;
    }

    // Token: 0x06000BAB RID: 2987 RVA: 0x00067D78 File Offset: 0x00065F78
    private static int gmBoss5BodyUpdateCrashFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y >= AppMain.GMM_BOSS5_AREA_TOP() )
        {
            obs_OBJECT_WORK.move_flag &= 4294967039U;
        }
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.move_flag |= 128U;
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BAC RID: 2988 RVA: 0x00067DD8 File Offset: 0x00065FD8
    private static void gmBoss5BodyInitCrashSink( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.move_flag |= 384U;
        obs_OBJECT_WORK.move_flag &= 4294967294U;
    }

    // Token: 0x06000BAD RID: 2989 RVA: 0x00067E13 File Offset: 0x00066013
    private static int gmBoss5BodyUpdateCrashSink( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
        return 0;
    }

    // Token: 0x06000BAE RID: 2990 RVA: 0x00067E1C File Offset: 0x0006601C
    private static void gmBoss5BodyInitBerserkTurn( AppMain.GMS_BOSS5_BODY_WORK body_work, int turn_type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num;
        switch ( turn_type )
        {
            case 0:
                num = AppMain.GMD_BOSS5_BODY_BERSERK_TURN_FRONT_DEG_F;
                break;
            case 1:
                num = AppMain.GMD_BOSS5_BODY_BERSERK_TURN_RETURN_DEG_F;
                break;
            default:
                num = 0f;
                break;
        }
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            num = -num;
        }
        body_work.turn_src_dir = ( int )( 65535L & ( long )obs_OBJECT_WORK.dir.y );
        int num2 = (int)(65535L & (long)AppMain.AKM_DEGtoA32(num));
        body_work.turn_tgt_ofst_dir = ( int )( 65535L & ( long )( num2 - body_work.turn_src_dir ) );
        if ( body_work.turn_tgt_ofst_dir > AppMain.AKM_DEGtoA32( 180 ) )
        {
            body_work.turn_tgt_ofst_dir = ( int )( ( long )body_work.turn_tgt_ofst_dir - 65536L );
        }
        body_work.turn_ratio = 0f;
    }

    // Token: 0x06000BAF RID: 2991 RVA: 0x00067ED8 File Offset: 0x000660D8
    private static int gmBoss5BodyUpdateBerserkTurn( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int result = 0;
        body_work.turn_ratio += AppMain.GMD_BOSS5_BODY_BERSERK_TURN_RATIO_SPD;
        if ( body_work.turn_ratio >= 1f )
        {
            body_work.turn_ratio = 1f;
            result = 1;
        }
        int num = (int)((float)body_work.turn_tgt_ofst_dir * body_work.turn_ratio);
        obs_OBJECT_WORK.dir.y = ( ushort )( 65535L & ( long )( body_work.turn_src_dir + num ) );
        return result;
    }

    // Token: 0x06000BB0 RID: 2992 RVA: 0x00067F48 File Offset: 0x00066148
    private static void gmBoss5BodyClearBerserkTurn( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss5BodySetDirection( body_work, 0 );
        }
        else
        {
            AppMain.gmBoss5BodySetDirection( body_work, 1 );
        }
        body_work.turn_src_dir = 0;
        body_work.turn_tgt_ofst_dir = 0;
        body_work.turn_ratio = 0f;
    }

    // Token: 0x06000BB1 RID: 2993 RVA: 0x00067F90 File Offset: 0x00066190
    private static void gmBoss5BodyInitPoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyInitArmPose( body_work );
        body_work.arm_poke_anim_phase = 0;
        AppMain.gmBoss5BodyInitArmAnim( body_work, AppMain.gm_boss5_arm_anim_info_tbl[body_work.arm_poke_anim_phase] );
        body_work.flag |= 64U;
        body_work.flag |= 256U;
    }

    // Token: 0x06000BB2 RID: 2994 RVA: 0x00067FE0 File Offset: 0x000661E0
    private static int gmBoss5BodyUpdatePoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int result = 0;
        if ( AppMain.gmBoss5BodyUpdateArmAnim( body_work ) != 0 )
        {
            body_work.arm_poke_anim_phase++;
            if ( body_work.arm_poke_anim_phase >= 9 )
            {
                body_work.arm_poke_anim_phase = 8;
                result = 1;
            }
            else
            {
                AppMain.gmBoss5BodyInitArmAnim( body_work, AppMain.gm_boss5_arm_anim_info_tbl[body_work.arm_poke_anim_phase] );
            }
        }
        return result;
    }

    // Token: 0x06000BB3 RID: 2995 RVA: 0x0006802D File Offset: 0x0006622D
    private static void gmBoss5BodyEndPoke( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4294967039U;
        body_work.flag &= 4294967231U;
        AppMain.gmBoss5BodyEndArmPose( body_work );
        body_work.arm_poke_anim_phase = 0;
    }

    // Token: 0x06000BB4 RID: 2996 RVA: 0x0006805D File Offset: 0x0006625D
    private static int gmBoss5BodyIsPoking( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 64U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BB5 RID: 2997 RVA: 0x00068070 File Offset: 0x00066270
    private static void gmBoss5BodyInitArmAnim( AppMain.GMS_BOSS5_BODY_WORK body_work, AppMain.GMS_BOSS5_ARM_ANIM_INFO anim_info )
    {
        if ( anim_info.wait_time > 0U )
        {
            body_work.arm_anim_work.is_anim = 0;
            body_work.arm_anim_work.anim_wait_timer = anim_info.wait_time;
            body_work.arm_anim_work.cur_rate = 0f;
            body_work.arm_anim_work.rate_add = 0f;
            for ( int i = 0; i < 3; i++ )
            {
                AppMain.nnMakeRotateXYZQuaternion( out body_work.arm_anim_work.start_quat[i], anim_info.part_anim_info[i].start_rot.x, anim_info.part_anim_info[i].start_rot.y, anim_info.part_anim_info[i].start_rot.z );
                AppMain.nnMakeUnitQuaternion( ref body_work.arm_anim_work.end_quat[i] );
            }
        }
        else
        {
            body_work.arm_anim_work.is_anim = 1;
            body_work.arm_anim_work.anim_wait_timer = 0U;
            body_work.arm_anim_work.cur_rate = 0f;
            body_work.arm_anim_work.rate_add = anim_info.slerp_inc_rate;
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.nnMakeRotateXYZQuaternion( out body_work.arm_anim_work.start_quat[j], anim_info.part_anim_info[j].start_rot.x, anim_info.part_anim_info[j].start_rot.y, anim_info.part_anim_info[j].start_rot.z );
                AppMain.nnMakeRotateXYZQuaternion( out body_work.arm_anim_work.end_quat[j], anim_info.part_anim_info[j].end_rot.x, anim_info.part_anim_info[j].end_rot.y, anim_info.part_anim_info[j].end_rot.z );
            }
        }
        for ( int k = 0; k < 3; k++ )
        {
            AppMain.gmBoss5BodySetArmPoseParam( body_work, 0, k, ref body_work.arm_anim_work.start_quat[k] );
            AppMain.NNS_QUATERNION nns_QUATERNION;
            AppMain.AkMathInvertYZQuaternion( out nns_QUATERNION, ref body_work.arm_anim_work.start_quat[k] );
            AppMain.gmBoss5BodySetArmPoseParam( body_work, 1, k, ref nns_QUATERNION );
        }
        AppMain.gmBoss5BodyApplyArmPose( body_work );
    }

    // Token: 0x06000BB6 RID: 2998 RVA: 0x0006826C File Offset: 0x0006646C
    private static int gmBoss5BodyUpdateArmAnim( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int result = 0;
        if ( body_work.arm_anim_work.is_anim != 0 )
        {
            body_work.arm_anim_work.cur_rate += body_work.arm_anim_work.rate_add;
            if ( body_work.arm_anim_work.cur_rate >= 1f )
            {
                body_work.arm_anim_work.cur_rate = 1f;
                result = 1;
            }
            for ( int i = 0; i < 3; i++ )
            {
                AppMain.NNS_QUATERNION nns_QUATERNION;
                AppMain.nnSlerpQuaternion( out nns_QUATERNION, ref body_work.arm_anim_work.start_quat[i], ref body_work.arm_anim_work.end_quat[i], body_work.arm_anim_work.cur_rate );
                AppMain.gmBoss5BodySetArmPoseParam( body_work, 0, i, ref nns_QUATERNION );
                AppMain.NNS_QUATERNION nns_QUATERNION2;
                AppMain.AkMathInvertYZQuaternion( out nns_QUATERNION2, ref nns_QUATERNION );
                AppMain.gmBoss5BodySetArmPoseParam( body_work, 1, i, ref nns_QUATERNION2 );
            }
        }
        else if ( body_work.arm_anim_work.anim_wait_timer != 0U )
        {
            body_work.arm_anim_work.anim_wait_timer -= 1U;
        }
        else
        {
            result = 1;
        }
        AppMain.gmBoss5BodyApplyArmPose( body_work );
        return result;
    }

    // Token: 0x06000BB7 RID: 2999 RVA: 0x00068356 File Offset: 0x00066556
    private static void gmBoss5BodyInitCloseCanopy( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.nnMakeRotateXYZQuaternion( out body_work.cnpy_close_init_quat, AppMain.GMD_BOSS5_BODY_CANOPY_CLOSE_START_ANGLE_X, 0, 0 );
        AppMain.nnMakeRotateXYZQuaternion( out body_work.cnpy_close_dest_quat, 0, 0, 0 );
        body_work.cnpy_close_ratio = 0f;
        body_work.cnpy_close_ratio_spd = 0f;
    }

    // Token: 0x06000BB8 RID: 3000 RVA: 0x00068390 File Offset: 0x00066590
    private static int gmBoss5BodyUpdateCloseCanopy( AppMain.GMS_BOSS5_BODY_WORK body_work, int is_update )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        int result = 0;
        if ( is_update != 0 )
        {
            body_work.cnpy_close_ratio_spd += AppMain.GMD_BOSS5_BODY_CANOPY_CLOSE_RATIO_SPD_ACC;
        }
        if ( body_work.cnpy_close_ratio_spd >= AppMain.GMD_BOSS5_BODY_CANOPY_CLOSE_RATIO_SPD_MAX )
        {
            body_work.cnpy_close_ratio_spd = AppMain.GMD_BOSS5_BODY_CANOPY_CLOSE_RATIO_SPD_MAX;
        }
        if ( is_update != 0 )
        {
            body_work.cnpy_close_ratio += body_work.cnpy_close_ratio_spd;
        }
        if ( body_work.cnpy_close_ratio >= 1f )
        {
            body_work.cnpy_close_ratio = 1f;
            result = 1;
        }
        AppMain.nnSlerpQuaternion( out nns_QUATERNION, ref body_work.cnpy_close_init_quat, ref body_work.cnpy_close_dest_quat, body_work.cnpy_close_ratio );
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX, ref nns_QUATERNION );
        AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX, body_work.head_cnm_reg_id );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeScaleMatrix( nns_MATRIX2, 0f, 0f, 0f );
        AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX2, body_work.pole_cnm_reg_id );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
        return result;
    }

    // Token: 0x06000BB9 RID: 3001 RVA: 0x00068478 File Offset: 0x00066678
    private static void gmBoss5BodyInitScatterFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.move_flag |= 144U;
        obs_OBJECT_WORK.move_flag &= 4294967294U;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, AppMain.GMD_BOSS5_BODY_SCT_FIEELD_RECT_SIZE_LEFT, AppMain.GMD_BOSS5_BODY_SCT_FIEELD_RECT_SIZE_TOP, AppMain.GMD_BOSS5_BODY_SCT_FIEELD_RECT_SIZE_RIGHT, AppMain.GMD_BOSS5_BODY_SCT_FIEELD_RECT_SIZE_BOTTOM );
        body_work.sct_land_vib_timer = AppMain.GMD_BOSS5_BODY_DEFEAT_SCT_FALL_LAND_VIB_TIME;
    }

    // Token: 0x06000BBA RID: 3002 RVA: 0x000684D4 File Offset: 0x000666D4
    private static int gmBoss5BodyUpdateScatterFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( body_work.sct_land_vib_timer != 0U )
        {
            if ( ( obs_OBJECT_WORK.move_flag & 1U ) == 0U )
            {
                int num = (int)((float)AppMain.GMD_BOSS5_BODY_DEFEAT_SCT_FALL_LAND_VIB_AMP * (body_work.sct_land_vib_timer / AppMain.GMD_BOSS5_BODY_DEFEAT_SCT_FALL_LAND_VIB_TIME));
                obs_OBJECT_WORK.ofst.y = ( int )( ( float )num * AppMain.nnSin( ( int )( ( ulong )( AppMain.GMD_BOSS5_BODY_DEFEAT_SCT_FALL_LAND_VIB_TIME - body_work.sct_land_vib_timer ) * ( ulong )( ( long )AppMain.GMD_BOSS5_BODY_DEFEAT_SCT_FALL_LAND_VIB_DEG_SPD ) ) ) );
                body_work.sct_land_vib_timer -= 1U;
            }
            return 0;
        }
        return 1;
    }

    // Token: 0x06000BBB RID: 3003 RVA: 0x00068550 File Offset: 0x00066750
    private static void gmBoss5BodyInitShakeAccelerate( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        body_work.bsk_shake_acc_ratio = 0f;
        body_work.bsk_shake_acc_ratio_spd = 0f;
        body_work.bsk_shake_init_spd = obs_OBJECT_WORK.obj_3d.speed[0];
    }

    // Token: 0x06000BBC RID: 3004 RVA: 0x00068590 File Offset: 0x00066790
    private static int gmBoss5BodyUpdateShakeAccelerate( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int result = 0;
        body_work.bsk_shake_acc_ratio_spd += AppMain.GMD_BOSS5_BODY_BERSERK_SHAKE_MOTION_SPD_RATIO_ACC;
        body_work.bsk_shake_acc_ratio += body_work.bsk_shake_acc_ratio_spd;
        if ( body_work.bsk_shake_acc_ratio >= 1f )
        {
            body_work.bsk_shake_acc_ratio = 1f;
            body_work.bsk_shake_acc_ratio_spd = 0f;
            result = 1;
        }
        obs_OBJECT_WORK.obj_3d.speed[0] = body_work.bsk_shake_acc_ratio * AppMain.GMD_BOSS5_BODY_BERSERK_SHAKE_MOTION_SPD_DEST + ( 1f - body_work.bsk_shake_acc_ratio ) * body_work.bsk_shake_init_spd;
        return result;
    }

    // Token: 0x06000BBD RID: 3005 RVA: 0x0006861E File Offset: 0x0006681E
    private static void gmBoss5BodyInitCrashStrikeVib( AppMain.GMS_BOSS5_BODY_WORK body_work, uint delay )
    {
        body_work.crash_strike_vib_delay_timer = delay;
        body_work.crash_strike_vib_phase = 0;
        body_work.crash_strike_vib_ratio = 0f;
    }

    // Token: 0x06000BBE RID: 3006 RVA: 0x0006863C File Offset: 0x0006683C
    private static int gmBoss5BodyUpdateCrashStrikeVib( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int result = 0;
        if ( body_work.crash_strike_vib_delay_timer != 0U )
        {
            body_work.crash_strike_vib_delay_timer -= 1U;
            return 0;
        }
        body_work.crash_strike_vib_ratio += AppMain.GMD_BOSS5_BODY_CRASH_STRIKE_BODY_VIB_RATIO_ADD;
        if ( body_work.crash_strike_vib_ratio >= 1f )
        {
            body_work.crash_strike_vib_ratio = 1f;
            result = 1;
        }
        int scale = (int)((float)AppMain.GMD_BOSS5_BODY_CRASH_STRIKE_BODY_VIB_SCALE * (1f - body_work.crash_strike_vib_ratio));
        body_work.crash_strike_vib_phase = AppMain.GmBoss5UpdateVib( body_work.crash_strike_vib_phase, scale, ref obs_OBJECT_WORK.ofst.x, ref obs_OBJECT_WORK.ofst.y );
        return result;
    }

    // Token: 0x06000BBF RID: 3007 RVA: 0x000686D4 File Offset: 0x000668D4
    private static void gmBoss5BodyInitStartRiseVib( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.start_rise_vib_int_timer = 0U;
    }

    // Token: 0x06000BC0 RID: 3008 RVA: 0x000686E0 File Offset: 0x000668E0
    private static void gmBoss5BodyUpdateStartRiseVib( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.start_rise_vib_int_timer != 0U )
        {
            body_work.start_rise_vib_int_timer -= 1U;
            return;
        }
        float num = AppMain.FX_FX32_TO_F32(AppMain.FX_Div(AppMain.GMM_BS_OBJ(body_work).pos.y - body_work.ground_v_pos, AppMain.GMD_BOSS5_BODY_START_BURY_HEIGHT));
        AppMain.GmCameraVibrationSet( ( int )( ( float )AppMain.GMD_BOSS5_BODY_START_RISE_VIB_AMP_MAX * AppMain.nnSin( AppMain.AKM_DEGtoA32( 180f * num ) ) ), 0, 0 );
        body_work.start_rise_vib_int_timer = AppMain.GMD_BOSS5_BODY_START_RISE_VIB_INTERVAL;
    }

    // Token: 0x06000BC1 RID: 3009 RVA: 0x00068758 File Offset: 0x00066958
    private static void gmBoss5BodyInitArmPose( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        for ( int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.GmBsCmnChangeCNMModeNode( body_work.cnm_mgr_work, body_work.arm_cnm_reg_id[i][j], 1U );
                AppMain.GmBsCmnEnableCNMLocalCoordinate( body_work.cnm_mgr_work, body_work.arm_cnm_reg_id[i][j], 1 );
                AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, body_work.arm_cnm_reg_id[i][j], 1 );
                AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX, body_work.arm_cnm_reg_id[i][j] );
                AppMain.nnMakeUnitQuaternion( ref body_work.arm_part_rot_quat[i][j] );
            }
            AppMain.nnMakeUnitMatrix( body_work.rkt_ofst_mtx[i] );
        }
        body_work.flag |= 16U;
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000BC2 RID: 3010 RVA: 0x0006881C File Offset: 0x00066A1C
    private static void gmBoss5BodyEndArmPose( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4294967279U;
        for ( int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, body_work.arm_cnm_reg_id[i][j], 0 );
            }
        }
    }

    // Token: 0x06000BC3 RID: 3011 RVA: 0x00068866 File Offset: 0x00066A66
    private static void gmBoss5BodySetArmPoseParam( AppMain.GMS_BOSS5_BODY_WORK body_work, int arm_type, int arm_part_idx, ref AppMain.NNS_QUATERNION quat )
    {
        body_work.arm_part_rot_quat[arm_type][arm_part_idx] = quat;
    }

    // Token: 0x06000BC4 RID: 3012 RVA: 0x00068884 File Offset: 0x00066A84
    private static void gmBoss5BodyApplyArmPose( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.NNS_MATRIX[][] array = AppMain.New<AppMain.NNS_MATRIX>(2, 3);
        for ( int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.nnMakeQuaternionMatrix( array[i][j], ref body_work.arm_part_rot_quat[i][j] );
                AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, array[i][j], body_work.arm_cnm_reg_id[i][j] );
            }
        }
        for ( int k = 0; k < 2; k++ )
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.NNS_MATRIX nns_MATRIX4 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.NNS_MATRIX nns_MATRIX5 = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, body_work.armpt_snm_reg_ids[k][0]);
            AppMain.NNS_MATRIX nns_MATRIX6 = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, body_work.armpt_snm_reg_ids[k][1]);
            AppMain.NNS_MATRIX nns_MATRIX7 = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, body_work.armpt_snm_reg_ids[k][2]);
            AppMain.nnInvertMatrix( nns_MATRIX, nns_MATRIX5 );
            AppMain.nnInvertMatrix( nns_MATRIX2, nns_MATRIX6 );
            AppMain.nnInvertMatrix( nns_MATRIX3, nns_MATRIX7 );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX3, nns_MATRIX5 );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, array[k][0] );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, nns_MATRIX );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, nns_MATRIX6 );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, array[k][1] );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, nns_MATRIX2 );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, nns_MATRIX7 );
            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, array[k][2] );
            AppMain.nnCopyMatrix( body_work.rkt_ofst_mtx[k], nns_MATRIX4 );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX4 );
        }
    }

    // Token: 0x06000BC5 RID: 3013 RVA: 0x00068A00 File Offset: 0x00066C00
    private static void gmBoss5BodyInitCanopyPartsPose( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int[] array = new int[]
        {
            body_work.head_cnm_reg_id,
            body_work.neck_cnm_reg_id,
            body_work.cover_cnm_reg_id,
            body_work.pole_cnm_reg_id
        };
        int num = array.Length;
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        for ( int i = 0; i < num; i++ )
        {
            AppMain.GmBsCmnChangeCNMModeNode( body_work.cnm_mgr_work, array[i], 1U );
            AppMain.GmBsCmnEnableCNMLocalCoordinate( body_work.cnm_mgr_work, array[i], 1 );
            AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, array[i], 1 );
            AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX, array[i] );
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000BC6 RID: 3014 RVA: 0x00068AA0 File Offset: 0x00066CA0
    private static void gmBoss5BodyEndCanopyPartsPose( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int[] array = new int[]
        {
            body_work.head_cnm_reg_id,
            body_work.neck_cnm_reg_id,
            body_work.cover_cnm_reg_id,
            body_work.pole_cnm_reg_id
        };
        int num = array.Length;
        for ( int i = 0; i < num; i++ )
        {
            AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, array[i], 0 );
        }
    }

    // Token: 0x06000BC7 RID: 3015 RVA: 0x00068AFC File Offset: 0x00066CFC
    private static int gmBoss5BodyTryTransitCrashWall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( body_work.sub_seq == -1 )
        {
            if ( body_work.state == 3 )
            {
                if ( ( obs_OBJECT_WORK.move_flag & 4U ) != 0U )
                {
                    AppMain.gmBoss5BodyStartSubsequence( body_work, 0 );
                    return 1;
                }
            }
            else if ( body_work.state == 4 && ( obs_OBJECT_WORK.move_flag & 8U ) != 0U )
            {
                AppMain.gmBoss5BodyStartSubsequence( body_work, 1 );
                return 1;
            }
        }
        return 0;
    }

    // Token: 0x06000BC8 RID: 3016 RVA: 0x00068B52 File Offset: 0x00066D52
    private static void gmBoss5BodyResumeMoveFast( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.sub_seq == 0 )
        {
            AppMain.gmBoss5BodyChangeState( body_work, 4, body_work.strat_state, 1 );
            return;
        }
        AppMain.gmBoss5BodyChangeState( body_work, 3, body_work.strat_state, 1 );
    }

    // Token: 0x06000BC9 RID: 3017 RVA: 0x00068B7C File Offset: 0x00066D7C
    private static int gmBoss5BodyReceiveSignalRocketReturned( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 67108864U ) != 0U )
        {
            body_work.flag &= 4227858431U;
            return 1;
        }
        if ( ( body_work.flag & 33554432U ) != 0U )
        {
            body_work.flag &= 4261412863U;
            return 1;
        }
        return 0;
    }

    // Token: 0x06000BCA RID: 3018 RVA: 0x00068BD0 File Offset: 0x00066DD0
    private static void gmBoss5BodyInitCallbacks( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnInitBossMotionCBSystem( obs_OBJECT_WORK, body_work.bmcb_mgr );
        AppMain.GmBsCmnCreateSNMWork( body_work.snm_work, obs_OBJECT_WORK.obj_3d._object, ( ushort )AppMain.GMD_BOSS5_BODY_NODE_SNM_NUM );
        AppMain.GmBsCmnAppendBossMotionCallback( body_work.bmcb_mgr, body_work.snm_work.bmcb_link );
        body_work.body_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_BODY );
        body_work.lfoot_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_FOOT_L );
        body_work.rfoot_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_FOOT_R );
        body_work.leg_snm_reg_ids[0] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_LEG_L );
        body_work.leg_snm_reg_ids[1] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_LEG_R );
        body_work.pole_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_POLE );
        body_work.groin_snm_reg_ids[0] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_GROIN_L );
        body_work.groin_snm_reg_ids[1] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_GROIN_R );
        body_work.nozzle_snm_reg_ids[0] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_NOZZLE_L );
        body_work.nozzle_snm_reg_ids[1] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_NOZZLE_R );
        for ( int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                body_work.armpt_snm_reg_ids[i][j] = AppMain.GmBsCmnRegisterSNMNode( body_work.snm_work, AppMain.arm_part_node_ids[i][j] );
            }
        }
        AppMain.GmBsCmnCreateCNMMgrWork( body_work.cnm_mgr_work, obs_OBJECT_WORK.obj_3d._object, ( ushort )AppMain.GMD_BOSS5_BODY_NODE_CNM_NUM );
        AppMain.GmBsCmnInitCNMCb( obs_OBJECT_WORK, body_work.cnm_mgr_work );
        for ( int k = 0; k < 2; k++ )
        {
            for ( int l = 0; l < 3; l++ )
            {
                body_work.arm_cnm_reg_id[k][l] = AppMain.GmBsCmnRegisterCNMNode( body_work.cnm_mgr_work, AppMain.arm_part_node_ids[k][l] );
            }
        }
        body_work.head_cnm_reg_id = AppMain.GmBsCmnRegisterCNMNode( body_work.cnm_mgr_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_HEAD );
        body_work.neck_cnm_reg_id = AppMain.GmBsCmnRegisterCNMNode( body_work.cnm_mgr_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_NECK );
        body_work.cover_cnm_reg_id = AppMain.GmBsCmnRegisterCNMNode( body_work.cnm_mgr_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_COVER );
        body_work.pole_cnm_reg_id = AppMain.GmBsCmnRegisterCNMNode( body_work.cnm_mgr_work, AppMain.GMD_BOSS5_BODY_NODE_IDX_POLE );
    }

    // Token: 0x06000BCB RID: 3019 RVA: 0x00068DFC File Offset: 0x00066FFC
    private static void gmBoss5BodyReleaseCallbacks( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnClearBossMotionCBSystem( obj_work );
        AppMain.GmBsCmnDeleteSNMWork( body_work.snm_work );
        AppMain.GmBsCmnClearCNMCb( obj_work );
        AppMain.GmBsCmnDeleteCNMMgrWork( body_work.cnm_mgr_work );
    }

    // Token: 0x06000BCC RID: 3020 RVA: 0x00068E34 File Offset: 0x00067034
    private static void gmBoss5BodyRegisterScatterPartsCNM( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        for ( int i = 0; i < 22; i++ )
        {
            body_work.scatter_cnm_reg_ids[i] = AppMain.GmBsCmnRegisterCNMNode( body_work.cnm_mgr_work, AppMain.gm_boss5_body_scatter_parts_cnm_node_id_tbl[i] );
        }
    }

    // Token: 0x06000BCD RID: 3021 RVA: 0x00068E68 File Offset: 0x00067068
    private static void gmBoss5BodyDamageDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)parent_obj;
        int num = 0;
        int num2 = 0;
        if ( parent_obj2 != null )
        {
            if ( 1 == parent_obj2.obj_type )
            {
                num = 1;
            }
            else if ( 2 == parent_obj2.obj_type )
            {
                AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)parent_obj2;
                if ( gms_ENEMY_COM_WORK.eve_rec.id == 332 )
                {
                    num2 = 1;
                }
            }
        }
        if ( num != 0 || num2 != 0 )
        {
            if ( num != 0 )
            {
                AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)parent_obj2;
                AppMain.gmBoss5BodySetPlyRebound( ply_work, gms_BOSS5_BODY_WORK );
                AppMain.GMM_PAD_VIB_SMALL_TIME( 30f );
            }
            else
            {
                AppMain.gmBoss5BodyStartSubsequence( gms_BOSS5_BODY_WORK, 2 );
                AppMain.GMM_PAD_VIB_SMALL();
                AppMain.GmSoundPlaySE( "FinalBoss15" );
            }
            AppMain.gmBoss5BodySetNoHitTime( gms_BOSS5_BODY_WORK );
            AppMain.GmSoundPlaySE( "Boss0_01" );
            AppMain.GmBoss5EfctCreateDamage( gms_BOSS5_BODY_WORK );
            if ( ( gms_BOSS5_BODY_WORK.flag & 1U ) == 0U || num2 != 0 )
            {
                AppMain.gmBoss5BodyExecDamageRoutine( gms_BOSS5_BODY_WORK );
            }
        }
    }

    // Token: 0x06000BCE RID: 3022 RVA: 0x00068F2C File Offset: 0x0006712C
    private static void gmBoss5BodyOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work;
        AppMain.GmBsCmnUpdateCNMParam( obj_work, gms_BOSS5_BODY_WORK.cnm_mgr_work );
        AppMain.ObjDrawActionSummary( obj_work );
        gms_BOSS5_BODY_WORK.grdmv_pivot_pos.Assign( obj_work.pos );
        gms_BOSS5_BODY_WORK.pivot_prev_pos.Assign( obj_work.pos );
    }

    // Token: 0x06000BCF RID: 3023 RVA: 0x00068F74 File Offset: 0x00067174
    private static void gmBoss5BodyRecFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work;
        for ( int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.ObjObjectRectRegist( obj_work, gms_BOSS5_BODY_WORK.sub_rect_work[i][j] );
            }
        }
    }

    // Token: 0x06000BD0 RID: 3024 RVA: 0x00068FB0 File Offset: 0x000671B0
    private static void gmBoss5BodyChangeState( AppMain.GMS_BOSS5_BODY_WORK body_work, int state, int strat_state )
    {
        AppMain.gmBoss5BodyChangeState( body_work, state, strat_state, 0 );
    }

    // Token: 0x06000BD1 RID: 3025 RVA: 0x00068FBC File Offset: 0x000671BC
    private static void gmBoss5BodyChangeState( AppMain.GMS_BOSS5_BODY_WORK body_work, int state, int strat_state, int is_wrapped )
    {
        AppMain.UNREFERENCED_PARAMETER( is_wrapped );
        AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK mpp_VOID_GMS_BOSS5_BODY_WORK = AppMain.gm_boss5_body_state_leave_func_tbl[body_work.state];
        if ( mpp_VOID_GMS_BOSS5_BODY_WORK != null )
        {
            mpp_VOID_GMS_BOSS5_BODY_WORK( body_work );
        }
        body_work.prev_state = body_work.state;
        body_work.state = state;
        body_work.sub_seq = -1;
        body_work.strat_state = strat_state;
        AppMain.GMS_BOSS5_BODY_STATE_ENTER_INFO gms_BOSS5_BODY_STATE_ENTER_INFO = AppMain.gm_boss5_body_state_enter_info_tbl[body_work.state];
        if ( gms_BOSS5_BODY_STATE_ENTER_INFO.enter_func != null )
        {
            gms_BOSS5_BODY_STATE_ENTER_INFO.enter_func( body_work );
        }
    }

    // Token: 0x06000BD2 RID: 3026 RVA: 0x00069030 File Offset: 0x00067230
    private static void gmBoss5BodyStartSubsequence( AppMain.GMS_BOSS5_BODY_WORK body_work, int sub_seq )
    {
        AppMain.GMS_BOSS5_BODY_SUBSEQ_ENTER_INFO gms_BOSS5_BODY_SUBSEQ_ENTER_INFO = AppMain.gm_boss5_body_sub_seq_enter_func_tbl[sub_seq];
        body_work.sub_seq = sub_seq;
        if ( gms_BOSS5_BODY_SUBSEQ_ENTER_INFO.enter_func != null )
        {
            gms_BOSS5_BODY_SUBSEQ_ENTER_INFO.enter_func( body_work );
        }
    }

    // Token: 0x06000BD3 RID: 3027 RVA: 0x00069060 File Offset: 0x00067260
    private static void gmBoss5BodyWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work;
        if ( ( gms_BOSS5_BODY_WORK.mgr_work.flag & 1U ) != 0U )
        {
            AppMain.gmBoss5BodyInitCallbacks( gms_BOSS5_BODY_WORK );
            AppMain.GmBoss5RocketSpawnConnected( gms_BOSS5_BODY_WORK, 0 );
            AppMain.GmBoss5RocketSpawnConnected( gms_BOSS5_BODY_WORK, 1 );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5BodyMain );
            AppMain.gmBoss5BodyChangeState( gms_BOSS5_BODY_WORK, 1, 1 );
        }
    }

    // Token: 0x06000BD4 RID: 3028 RVA: 0x000690B4 File Offset: 0x000672B4
    private static void gmBoss5BodyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work;
        int num = 0;
        AppMain.gmBoss5BodyUpdatePokeTriggerLimitTime( gms_BOSS5_BODY_WORK );
        AppMain.gmBoss5BodyUpdateNoHitTime( gms_BOSS5_BODY_WORK );
        if ( gms_BOSS5_BODY_WORK.sub_seq != 0 && gms_BOSS5_BODY_WORK.sub_seq != 1 )
        {
            AppMain.gmBoss5BodyUpdateMoveFastTime( gms_BOSS5_BODY_WORK );
        }
        if ( ( gms_BOSS5_BODY_WORK.flag & 131072U ) == 0U )
        {
            if ( ( gms_BOSS5_BODY_WORK.flag & 4194304U ) != 0U )
            {
                gms_BOSS5_BODY_WORK.flag &= 2143289343U;
                AppMain.GmBsCmnInitObject3DNNDamageFlicker( obj_work, gms_BOSS5_BODY_WORK.flk_work, AppMain.GMD_BOSS5_BODY_DMG_FLICKER_RADIUS );
                AppMain.gmBoss5BodyProceedToDefeatState( gms_BOSS5_BODY_WORK );
                num = 1;
            }
            if ( num == 0 && AppMain.gmBoss5BodyTryTransitCrashWall( gms_BOSS5_BODY_WORK ) != 0 )
            {
                num = 1;
                AppMain.GmSoundPlaySE( "FinalBoss12" );
            }
        }
        if ( num == 0 && gms_BOSS5_BODY_WORK.proc_update != null )
        {
            gms_BOSS5_BODY_WORK.proc_update( gms_BOSS5_BODY_WORK );
        }
        if ( ( gms_BOSS5_BODY_WORK.flag & 2147483648U ) != 0U )
        {
            gms_BOSS5_BODY_WORK.flag &= 2147483647U;
            AppMain.GmBsCmnInitObject3DNNDamageFlicker( obj_work, gms_BOSS5_BODY_WORK.flk_work, AppMain.GMD_BOSS5_BODY_DMG_FLICKER_RADIUS );
        }
        AppMain.GmBsCmnUpdateObject3DNNDamageFlicker( obj_work, gms_BOSS5_BODY_WORK.flk_work );
        if ( ( gms_BOSS5_BODY_WORK.flag & 4096U ) != 0U )
        {
            AppMain.GmBoss5EfctTryStartLeakage( gms_BOSS5_BODY_WORK );
            return;
        }
        AppMain.GmBoss5EfctEndLeakage( gms_BOSS5_BODY_WORK );
    }

    // Token: 0x06000BD5 RID: 3029 RVA: 0x000691BC File Offset: 0x000673BC
    private static void gmBoss5BodyStateEnterStart( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodySetActionWhole( body_work, 0, 1 );
        AppMain.gmBoss5BodySetDirection( body_work, 0 );
        obs_OBJECT_WORK.move_flag &= 4294967039U;
        obs_OBJECT_WORK.move_flag |= 128U;
        body_work.flag |= 8192U;
        obs_OBJECT_WORK.spd.y = obs_OBJECT_WORK.spd_fall_max;
        obs_OBJECT_WORK.pos.z = AppMain.GMD_BOSS5_BG_FARSIDE_POS_Z;
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 2 );
        AppMain.GmBoss5EggCreate( body_work, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithPlacement );
    }

    // Token: 0x06000BD6 RID: 3030 RVA: 0x0006926C File Offset: 0x0006746C
    private static void gmBoss5BodyStateLeaveStart( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5RestoreCameraSlideForNarrowScreen( body_work.mgr_work );
        AppMain.gmBoss5BodyEndCanopyPartsPose( body_work );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
        body_work.flag &= 4294959103U;
        obs_OBJECT_WORK.move_flag &= 4294967039U;
        obs_OBJECT_WORK.move_flag |= 128U;
        obs_OBJECT_WORK.pos.z = AppMain.GMD_BOSS5_DEFAULT_POS_Z;
    }

    // Token: 0x06000BD7 RID: 3031 RVA: 0x000692E0 File Offset: 0x000674E0
    private static void gmBoss5BodyStateUpdateStartWithPlacement( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
        {
            body_work.ground_v_pos = obs_OBJECT_WORK.pos.y;
            obs_OBJECT_WORK.move_flag |= 256U;
            obs_OBJECT_WORK.move_flag &= 4294967167U;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + AppMain.GMD_BOSS5_BODY_START_BURY_HEIGHT;
            AppMain.GmBoss5CtpltCreate( body_work );
            body_work.mgr_work.flag |= 2097152U;
            AppMain.gmBoss5MgrSetDemoRunDestPos( body_work.mgr_work, obs_OBJECT_WORK.pos.x + AppMain.GMD_BOSS5_PLY_OP_DEMO_RUN_DEST_X_OFST_FROM_BODY );
            AppMain.gmBoss5BodyInitCanopyPartsPose( body_work );
            AppMain.gmBoss5BodyInitCloseCanopy( body_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithWaitEggRide );
        }
    }

    // Token: 0x06000BD8 RID: 3032 RVA: 0x000693A4 File Offset: 0x000675A4
    private static void gmBoss5BodyStateUpdateStartWithWaitEggRide( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.mgr_work.flag & 524288U ) != 0U && ( body_work.mgr_work.flag & 1048576U ) == 0U )
        {
            body_work.mgr_work.flag |= 1048576U;
            AppMain.gmBoss5SetCameraSlideForNarrowScreen( body_work.mgr_work );
        }
        AppMain.gmBoss5BodyUpdateCloseCanopy( body_work, 0 );
        if ( ( body_work.flag & 16777216U ) != 0U )
        {
            body_work.flag &= 4278190079U;
            AppMain.gmBoss5BodyRecordGapAdjustmentDest( body_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithCockpitClose );
        }
    }

    // Token: 0x06000BD9 RID: 3033 RVA: 0x0006943C File Offset: 0x0006763C
    private static void gmBoss5BodyStateUpdateStartWithCockpitClose( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyUpdateCloseCanopy( body_work, 1 ) != 0 )
        {
            AppMain.GmSoundPlaySE( "FinalBoss01" );
            body_work.mgr_work.flag |= 33554432U;
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_START_WAIT_RISE_TIME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithWaitRise );
        }
    }

    // Token: 0x06000BDA RID: 3034 RVA: 0x00069490 File Offset: 0x00067690
    private static void gmBoss5BodyStateUpdateStartWithWaitRise( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_BODY_START_RISE_SPD_Y;
        AppMain.gmBoss5BodyInitStartRiseVib( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithRise );
    }

    // Token: 0x06000BDB RID: 3035 RVA: 0x000694E4 File Offset: 0x000676E4
    private static void gmBoss5BodyStateUpdateStartWithRise( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = body_work.mgr_work;
        AppMain.gmBoss5BodyUpdateStartRiseVib( body_work );
        if ( obs_OBJECT_WORK.pos.y <= body_work.ground_v_pos )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.move_flag &= 4294967039U;
            obs_OBJECT_WORK.move_flag |= 128U;
            mgr_work.flag |= 8388608U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithWaitCtplt );
        }
    }

    // Token: 0x06000BDC RID: 3036 RVA: 0x00069568 File Offset: 0x00067768
    private static void gmBoss5BodyStateUpdateStartWithWaitCtplt( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = body_work.mgr_work;
        if ( ( mgr_work.flag & 16777216U ) != 0U )
        {
            AppMain.gmBoss5RestoreCameraSlideForNarrowScreen( body_work.mgr_work );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_START_WAIT_END_TIME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStartWithWaitEnd );
        }
    }

    // Token: 0x06000BDD RID: 3037 RVA: 0x000695B2 File Offset: 0x000677B2
    private static void gmBoss5BodyStateUpdateStartWithWaitEnd( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodyProceedToNextSeqNml( body_work );
    }

    // Token: 0x06000BDE RID: 3038 RVA: 0x000695D4 File Offset: 0x000677D4
    private static void gmBoss5BodyStateEnterMoveNml( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodySetActionWhole( body_work, 2, 1 );
        AppMain.gmBoss5BodyInitWalk( body_work );
        AppMain.gmBoss5BodyInitMonitoringWalkEnd( body_work );
        AppMain.gmBoss5BodyInitWalkGroundingEffects( body_work );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
        obs_OBJECT_WORK.move_flag &= 4294966271U;
        obs_OBJECT_WORK.move_flag |= 524288U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveNmlWithLoop );
        if ( AppMain.gmBoss5BodyIsPlayerBehind( body_work ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 3 );
            AppMain.gmBoss5BodyInitWalkAbortRecovery( body_work, body_work.cur_move_phase_type );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveNmlWithAbort );
        }
    }

    // Token: 0x06000BDF RID: 3039 RVA: 0x0006966C File Offset: 0x0006786C
    private static void gmBoss5BodyStateLeaveMoveNml( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodyClearAdjustMtnBlendHGap( body_work );
        body_work.flag &= 4286578687U;
        AppMain.gmBoss5BodyClearPokeTriggerLimitTime( body_work );
        AppMain.gmBoss5BodyEndPoke( body_work );
        obs_OBJECT_WORK.move_flag &= 4294443007U;
        obs_OBJECT_WORK.move_flag |= 1024U;
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
    }

    // Token: 0x06000BE0 RID: 3040 RVA: 0x000696D0 File Offset: 0x000678D0
    private static void gmBoss5BodyStateUpdateMoveNmlWithLoop( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyIsPoking( body_work ) != 0 && AppMain.gmBoss5BodyUpdatePoke( body_work ) != 0 )
        {
            AppMain.gmBoss5BodyEndPoke( body_work );
        }
        AppMain.gmBoss5BodyUpdateWalkGroundingEffects( body_work );
        if ( AppMain.gmBoss5BodyUpdateWalk( body_work ) != 0 && AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 && AppMain.gmBoss5BodyIsPoking( body_work ) == 0 )
        {
            AppMain.gmBoss5BodyProceedToNextSeqNml( body_work );
            return;
        }
        int leg_type = 0;
        if ( AppMain.gmBoss5BodyUpdateMonitoringWalkEnd( body_work, ref leg_type ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 3 );
            AppMain.gmBoss5BodyInitWalkAbortRecoveryByLegType( body_work, leg_type );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveNmlWithAbort );
            return;
        }
        if ( ( body_work.flag & 8388608U ) != 0U )
        {
            body_work.flag &= 4286578687U;
            AppMain.gmBoss5BodyInitPoke( body_work );
        }
    }

    // Token: 0x06000BE1 RID: 3041 RVA: 0x00069771 File Offset: 0x00067971
    private static void gmBoss5BodyStateUpdateMoveNmlWithAbort( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyIsPoking( body_work ) != 0 && AppMain.gmBoss5BodyUpdatePoke( body_work ) != 0 )
        {
            AppMain.gmBoss5BodyEndPoke( body_work );
        }
        if ( AppMain.gmBoss5BodyUpdateWalkAbortRecovery( body_work ) != 0 && AppMain.gmBoss5BodyIsPoking( body_work ) == 0 )
        {
            AppMain.gmBoss5BodyProceedToNextSeqNml( body_work );
        }
    }

    // Token: 0x06000BE2 RID: 3042 RVA: 0x000697A0 File Offset: 0x000679A0
    private static void gmBoss5BodyStateEnterMoveFast( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
        if ( AppMain.gmBoss5BodyIsMoveFastEnd( body_work ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 20 );
            AppMain.gmBoss5BodyRecordGapAdjustmentSrc( body_work );
            AppMain.gmBoss5BodyInitAdjustMtnBlendHGap( body_work, body_work.whole_act_id, 0 );
            AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_RUN_RECOVER_TIMEOUT_FRAME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithRecover );
            return;
        }
        if ( body_work.prev_state == 10 )
        {
            if ( body_work.whole_act_id != 45 )
            {
                AppMain.gmBoss5BodySetActionWhole( body_work, 45 );
            }
            AppMain.gmBoss5BodyClearAdjustMtnBlendHGap( body_work );
        }
        else
        {
            if ( AppMain.gmBoss5BodyIsMoveFastDirFwd( body_work ) != 0 )
            {
                AppMain.gmBoss5BodySetActionWhole( body_work, 4 );
            }
            else
            {
                AppMain.gmBoss5BodySetActionWhole( body_work, 11 );
            }
            AppMain.gmBoss5BodyRecordGapAdjustmentSrc( body_work );
            AppMain.gmBoss5BodyInitAdjustMtnBlendHGap( body_work, body_work.whole_act_id, 0 );
            AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
        }
        obs_OBJECT_WORK.move_flag &= 4294966271U;
        obs_OBJECT_WORK.move_flag |= 524288U;
        body_work.cur_run_type = 1;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithPrep );
    }

    // Token: 0x06000BE3 RID: 3043 RVA: 0x00069894 File Offset: 0x00067A94
    private static void gmBoss5BodyStateLeaveMoveFast( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.move_flag &= 4294967279U;
        obs_OBJECT_WORK.move_flag &= 4294443007U;
        obs_OBJECT_WORK.move_flag |= 1024U;
        AppMain.gmBoss5BodyClearAdjustMtnBlendHGap( body_work );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
    }

    // Token: 0x06000BE4 RID: 3044 RVA: 0x000698E8 File Offset: 0x00067AE8
    private static void gmBoss5BodyStateUpdateMoveFastWithPrep( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.obj_3d.flag & 1U ) != 0U )
        {
            AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
        }
        else
        {
            AppMain.gmBoss5BodyClearAdjustMtnBlendHGap( body_work );
        }
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.gmBoss5BodyClearAdjustMtnBlendHGap( body_work );
            obs_OBJECT_WORK.spd.x = AppMain.GMD_BOSS5_BODY_RUN_FWD_JUMP_INIT_SPD_X;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.spd.x = -obs_OBJECT_WORK.spd.x;
            }
            if ( AppMain.gmBoss5BodyIsMoveFastDirFwd( body_work ) != 0 )
            {
                AppMain.gmBoss5BodySetActionWhole( body_work, 5 );
            }
            else
            {
                obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( -obs_OBJECT_WORK.spd.x, AppMain.GMD_BOSS5_BODY_RUN_BWD_SPD_X_FACTOR );
                AppMain.gmBoss5BodySetActionWhole( body_work, 12 );
            }
            AppMain.gmBoss5BodySwitchEnableLegRectOneSide( body_work, 1 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithJump );
        }
    }

    // Token: 0x06000BE5 RID: 3045 RVA: 0x000699B0 File Offset: 0x00067BB0
    private static void gmBoss5BodyStateUpdateMoveFastWithJump( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEndFlexibly( obs_OBJECT_WORK, AppMain.GMD_BOSS5_BODY_RUN_ACT_FRAME_OVERRUN_ALLOW_RATIO ) != 0 )
        {
            int num = AppMain.gmBoss5BodyIsMoveFastDirFwd(body_work);
            if ( body_work.cur_run_type == 1 )
            {
                if ( num != 0 )
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 6 );
                }
                else
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 13 );
                }
            }
            else if ( num != 0 )
            {
                AppMain.gmBoss5BodySetActionWhole( body_work, 9 );
            }
            else
            {
                AppMain.gmBoss5BodySetActionWhole( body_work, 16 );
            }
            obs_OBJECT_WORK.spd.x = AppMain.GMD_BOSS5_BODY_RUN_FWD_FLY_INIT_SPD_X;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.spd.x = -obs_OBJECT_WORK.spd.x;
            }
            obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_BODY_RUN_FWD_FLY_INIT_SPD_Y;
            if ( num == 0 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( -obs_OBJECT_WORK.spd.x, AppMain.GMD_BOSS5_BODY_RUN_BWD_SPD_X_FACTOR );
            }
            obs_OBJECT_WORK.move_flag |= 144U;
            obs_OBJECT_WORK.move_flag &= 4294967294U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithAir );
        }
    }

    // Token: 0x06000BE6 RID: 3046 RVA: 0x00069AA8 File Offset: 0x00067CA8
    private static void gmBoss5BodyStateUpdateMoveFastWithAir( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
        {
            int num = AppMain.gmBoss5BodyIsMoveFastDirFwd(body_work);
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
            {
                AppMain.gmBoss5BodyInitRunGroundingEffects( body_work, body_work.cur_run_type, AppMain.GMD_BOSS5_BODY_RUN_GROUNDING_EFCT_DELAY );
                if ( body_work.cur_run_type == 1 )
                {
                    if ( num != 0 )
                    {
                        AppMain.gmBoss5BodySetActionWhole( body_work, 7 );
                    }
                    else
                    {
                        AppMain.gmBoss5BodySetActionWhole( body_work, 14 );
                    }
                }
                else if ( num != 0 )
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 10 );
                }
                else
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 17 );
                }
                if ( AppMain.gmBoss5BodyIsMoveFastEnd( body_work ) != 0 )
                {
                    body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithPreRecover );
                    body_work.wait_timer = AppMain.GMD_BOSS5_BODY_RUN_PRE_RECOVER_TIMEOUT_FRAME;
                    return;
                }
                body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithLand );
            }
        }
    }

    // Token: 0x06000BE7 RID: 3047 RVA: 0x00069B5C File Offset: 0x00067D5C
    private static void gmBoss5BodyStateUpdateMoveFastWithLand( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodyUpdateRunGroundingEffects( body_work );
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            int num = AppMain.gmBoss5BodyIsMoveFastDirFwd(body_work);
            if ( body_work.cur_run_type == 1 )
            {
                body_work.cur_run_type = 0;
                if ( num != 0 )
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 8 );
                }
                else
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 15 );
                }
                AppMain.gmBoss5BodySwitchEnableLegRectOneSide( body_work, 0 );
            }
            else
            {
                body_work.cur_run_type = 1;
                if ( num != 0 )
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 5 );
                }
                else
                {
                    AppMain.gmBoss5BodySetActionWhole( body_work, 12 );
                }
                AppMain.gmBoss5BodySwitchEnableLegRectOneSide( body_work, 1 );
            }
            obs_OBJECT_WORK.spd.x = AppMain.GMD_BOSS5_BODY_RUN_FWD_JUMP_INIT_SPD_X;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.spd.x = -obs_OBJECT_WORK.spd.x;
            }
            if ( num == 0 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( -obs_OBJECT_WORK.spd.x, AppMain.GMD_BOSS5_BODY_RUN_BWD_SPD_X_FACTOR );
            }
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithJump );
        }
    }

    // Token: 0x06000BE8 RID: 3048 RVA: 0x00069C40 File Offset: 0x00067E40
    private static void gmBoss5BodyStateUpdateMoveFastWithPreRecover( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = 0;
        AppMain.gmBoss5BodyUpdateRunGroundingEffects( body_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
        }
        else
        {
            num = 1;
        }
        if ( ( obs_OBJECT_WORK.obj_3d.flag & 1U ) == 0U || num != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 20 );
            AppMain.gmBoss5BodyRecordGapAdjustmentSrc( body_work );
            if ( body_work.cur_run_type == 1 )
            {
                AppMain.gmBoss5BodyInitAdjustMtnBlendHGap( body_work, body_work.whole_act_id, 1 );
            }
            else
            {
                AppMain.gmBoss5BodyInitAdjustMtnBlendHGap( body_work, body_work.whole_act_id, 0 );
            }
            AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_RUN_RECOVER_TIMEOUT_FRAME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateMoveFastWithRecover );
        }
    }

    // Token: 0x06000BE9 RID: 3049 RVA: 0x00069CE0 File Offset: 0x00067EE0
    private static void gmBoss5BodyStateUpdateMoveFastWithRecover( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = 0;
        AppMain.gmBoss5BodyUpdateRunGroundingEffects( body_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
        }
        else
        {
            num = 1;
        }
        if ( ( obs_OBJECT_WORK.obj_3d.flag & 1U ) == 0U || num != 0 )
        {
            AppMain.gmBoss5BodyProceedToNextSeqStr( body_work );
            return;
        }
        AppMain.gmBoss5BodyUpdateAdjustMtnBlendHGap( body_work );
    }

    // Token: 0x06000BEA RID: 3050 RVA: 0x00069D36 File Offset: 0x00067F36
    private static void gmBoss5BodyStateEnterStomp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodySetActionWhole( body_work, 21 );
        body_work.wait_timer = AppMain.GMD_BOSS5_BODY_STOMP_IGNITE_TIME;
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
        AppMain.GmBoss5EfctStartJet( body_work );
        AppMain.GmBoss5EfctStartJetSmoke( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStompWithPrep );
    }

    // Token: 0x06000BEB RID: 3051 RVA: 0x00069D70 File Offset: 0x00067F70
    private static void gmBoss5BodyStateLeaveStomp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.move_flag &= 4294967023U;
        obs_OBJECT_WORK.move_flag |= 128U;
        AppMain.GmBoss5EfctEndJetSmoke( body_work );
        AppMain.GmBoss5EfctEndJet( body_work );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
    }

    // Token: 0x06000BEC RID: 3052 RVA: 0x00069DBA File Offset: 0x00067FBA
    private static void gmBoss5BodyStateUpdateStompWithPrep( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodySetActionWhole( body_work, 22 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStompWithHover );
    }

    // Token: 0x06000BED RID: 3053 RVA: 0x00069DF0 File Offset: 0x00067FF0
    private static void gmBoss5BodyStateUpdateStompWithHover( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 23 );
            AppMain.gmBoss5BodyInitStompFlyUp( body_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStompWithFlyUp );
        }
    }

    // Token: 0x06000BEE RID: 3054 RVA: 0x00069E2C File Offset: 0x0006802C
    private static void gmBoss5BodyStateUpdateStompWithFlyUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyCheckJetSmokeClearTiming( body_work ) != 0 )
        {
            AppMain.GmBoss5EfctEndJetSmoke( body_work );
        }
        if ( AppMain.gmBoss5BodyUpdateStompFlyUp( body_work ) != 0 )
        {
            AppMain.GmBoss5EfctEndJetSmoke( body_work );
            AppMain.GmBoss5EfctEndJet( body_work );
            AppMain.GmBoss5EfctTargetCursorInit( body_work );
            body_work.flag |= 2U;
            AppMain.gmBoss5BodyInitPlySearch( body_work, ( int )AppMain.GMD_BOSS5_BODY_STOMP_SEARCH_DELAY );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_STOMP_WAIT_TIME;
            AppMain.gmBoss5BodyInitPlayTargetSe( body_work, ( float )AppMain.GMD_BOSS5_BODY_SE_TARGET_INIT_INTERVAL );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStompWithWait );
        }
    }

    // Token: 0x06000BEF RID: 3055 RVA: 0x00069EA4 File Offset: 0x000680A4
    private static void gmBoss5BodyStateUpdateStompWithWait( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer >= AppMain.GMD_BOSS5_BODY_STOMP_NO_SEARCH_TIME )
        {
            AppMain.gmBoss5BodyUpdatePlySearch( body_work );
        }
        AppMain.gmBoss5BodyUpdatePlayTargetSe( body_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        body_work.flag &= 4294967293U;
        AppMain.GmBoss5BodyGetPlySearchPos( body_work, out vecFx );
        obs_OBJECT_WORK.pos.x = AppMain.gmBoss5BodyGetStompFallPosX( body_work, vecFx.x );
        AppMain.gmBoss5BodySetActionWhole( body_work, 24 );
        AppMain.gmBoss5BodySetDirection( body_work, AppMain.gmBoss5BodyGetStompFallDirectionType( body_work ) );
        AppMain.gmBoss5BodyInitStompFall( body_work );
        if ( AppMain.gmBoss5BodySeqIsStr( body_work ) != 0 )
        {
            AppMain.gmBoss5BodyChangeRectSetting( body_work, 4 );
        }
        else
        {
            AppMain.gmBoss5BodyChangeRectSetting( body_work, 3 );
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStompWithFall );
    }

    // Token: 0x06000BF0 RID: 3056 RVA: 0x00069F64 File Offset: 0x00068164
    private static void gmBoss5BodyStateUpdateStompWithFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.gmBoss5BodyUpdateStompFall( body_work ) != 0 )
        {
            AppMain.GmSoundPlaySE( "FinalBoss06" );
            AppMain.GMM_PAD_VIB_MID_TIME( 30f );
            obs_OBJECT_WORK.move_flag &= 4294967279U;
            AppMain.gmBoss5BodySetActionWhole( body_work, 25 );
            AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
            AppMain.GmBoss5EfctCreateLandingShockwave( body_work );
            AppMain.gmBoss5Vibration( 3 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateStompWithLand );
        }
    }

    // Token: 0x06000BF1 RID: 3057 RVA: 0x00069FCF File Offset: 0x000681CF
    private static void gmBoss5BodyStateUpdateStompWithLand( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            if ( body_work.state == 6 )
            {
                AppMain.gmBoss5BodyProceedToNextSeqStr( body_work );
                return;
            }
            AppMain.gmBoss5BodyProceedToNextSeqNml( body_work );
        }
    }

    // Token: 0x06000BF2 RID: 3058 RVA: 0x00069FF4 File Offset: 0x000681F4
    private static void gmBoss5BodyStateEnterCrash( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5MgrSetAlarmLevel( body_work.mgr_work, 1 );
        body_work.flag |= 65536U;
        body_work.flag |= 512U;
        AppMain.gmBoss5BodySetActionWhole( body_work, 26 );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
        AppMain.GmBoss5EfctStartJet( body_work );
        AppMain.GmBoss5EfctStartJetSmoke( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithPrep );
    }

    // Token: 0x06000BF3 RID: 3059 RVA: 0x0006A060 File Offset: 0x00068260
    private static void gmBoss5BodyStateLeaveCrash( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        body_work.flag &= 4294959103U;
        AppMain.GMM_PAD_VIB_STOP();
        obs_OBJECT_WORK.move_flag &= 4294967023U;
        obs_OBJECT_WORK.move_flag |= 128U;
        body_work.flag &= 4294966783U;
        AppMain.GmBoss5EfctEndJetSmoke( body_work );
        AppMain.gmBoss5RestoreCameraLift( body_work.mgr_work );
        AppMain.GmBoss5EfctEndJet( body_work );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
    }

    // Token: 0x06000BF4 RID: 3060 RVA: 0x0006A0E0 File Offset: 0x000682E0
    private static void gmBoss5BodyStateUpdateCrashWithPrep( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss5BodyDecideCrashFallPosX( body_work );
            AppMain.gmBoss5BodySetActionWhole( body_work, 27 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithStartFly );
        }
    }

    // Token: 0x06000BF5 RID: 3061 RVA: 0x0006A11C File Offset: 0x0006831C
    private static void gmBoss5BodyStateUpdateCrashWithStartFly( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 28 );
            AppMain.gmBoss5BodyInitCrashFlyUp( body_work );
            AppMain.gmBoss5SetCameraLift( body_work.mgr_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithFlyUp );
        }
    }

    // Token: 0x06000BF6 RID: 3062 RVA: 0x0006A164 File Offset: 0x00068364
    private static void gmBoss5BodyStateUpdateCrashWithFlyUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyCheckJetSmokeClearTiming( body_work ) != 0 )
        {
            AppMain.GmBoss5EfctEndJetSmoke( body_work );
        }
        if ( AppMain.gmBoss5BodyUpdateCrashFlyUp( body_work ) != 0 )
        {
            body_work.mgr_work.flag |= 67108864U;
            AppMain.GmBoss5EfctEndJetSmoke( body_work );
            AppMain.GmBoss5EfctEndJet( body_work );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_CRASH_WAIT_TIME;
            AppMain.GmBoss5EfctCrashCursorInit( body_work, AppMain.gmBoss5BodyGetCrashFallPosX( body_work ), AppMain.GMD_BOSS5_BODY_CRASH_WAIT_TIME - AppMain.GMD_BOSS5_BODY_CRASH_CURSOR_SPAWN_TIME_TRHESHOLD );
            body_work.flag |= 2U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithWait );
        }
    }

    // Token: 0x06000BF7 RID: 3063 RVA: 0x0006A1EC File Offset: 0x000683EC
    private static void gmBoss5BodyStateUpdateCrashWithWait( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.pos.x = AppMain.gmBoss5BodyGetCrashFallPosX( body_work );
        AppMain.gmBoss5BodySetDirection( body_work, 0 );
        AppMain.gmBoss5BodySetActionWhole( body_work, 29 );
        AppMain.gmBoss5BodyInitCrashFall( body_work );
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 5 );
        AppMain.GmSoundPlaySE( "FinalBoss17" );
        AppMain.gmBoss5RestoreCameraLift( body_work.mgr_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithFall );
    }

    // Token: 0x06000BF8 RID: 3064 RVA: 0x0006A26C File Offset: 0x0006846C
    private static void gmBoss5BodyStateUpdateCrashWithFall( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.gmBoss5BodyUpdateCrashFall( body_work ) != 0 )
        {
            body_work.flag &= 4294967293U;
            obs_OBJECT_WORK.move_flag &= 4294967279U;
            AppMain.gmBoss5BodySetActionWhole( body_work, 30 );
            AppMain.GmBoss5EfctCreateStrikeShockwave( body_work, AppMain.GMD_BOSS5_BODY_CRASH_STRIKE_SW_CREATE_DELAY );
            AppMain.gmBoss5DelayedVibration( 5, AppMain.GMD_BOSS5_BODY_CRASH_STRIKE_VIB_START_DELAY );
            AppMain.gmBoss5BodyInitCrashStrikeVib( body_work, AppMain.GMD_BOSS5_BODY_CRASH_STRIKE_BODY_VIB_START_DELAY );
            AppMain.gmBoss5BodyChangeRectSetting( body_work, 6 );
            AppMain.gmBoss5BodyForceEndLeakage( body_work );
            AppMain.GmBoss5EfctCreateLandingShockwave( body_work );
            AppMain.GmBoss5EfctCreateCrashLandingSmoke( body_work );
            AppMain.gmBoss5BodyTryImmobilizePlayer( body_work );
            AppMain.gmBoss5Vibration( 4 );
            AppMain.GmPadVibSet( 1, -1f, 32768, 32768, -1f, 0f, 0f, 32768U );
            AppMain.gmBoss5DelayedSePlayback( "FinalBoss18", AppMain.GMD_BOSS5_BODY_CRASH_STRIKE_SE_START_DELAY );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithLand );
        }
    }

    // Token: 0x06000BF9 RID: 3065 RVA: 0x0006A344 File Offset: 0x00068544
    private static void gmBoss5BodyStateUpdateCrashWithLand( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyUpdateCrashStrikeVib( body_work );
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            body_work.mgr_work.flag |= 536870912U;
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_CRASH_LANDED_IDLE_TIME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithIdle );
        }
    }

    // Token: 0x06000BFA RID: 3066 RVA: 0x0006A39C File Offset: 0x0006859C
    private static void gmBoss5BodyStateUpdateCrashWithIdle( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodyUpdateCrashStrikeVib( body_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.GMM_PAD_VIB_STOP();
        AppMain.gmBoss5BodySetActionWhole( body_work, 31 );
        AppMain.gmBoss5BodyInitCrashSink( body_work );
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 7 );
        obs_OBJECT_WORK.flag |= 2U;
        body_work.flag |= 8192U;
        body_work.flag |= 131072U;
        body_work.mgr_work.flag |= 1073741824U;
        AppMain.GmGmkCamScrLimitRelease( 8 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateCrashWithSink );
    }

    // Token: 0x06000BFB RID: 3067 RVA: 0x0006A44A File Offset: 0x0006864A
    private static void gmBoss5BodyStateUpdateCrashWithSink( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyUpdateCrashSink( body_work );
    }

    // Token: 0x06000BFC RID: 3068 RVA: 0x0006A453 File Offset: 0x00068653
    private static void gmBoss5BodyStateEnterRpc( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodySetActionWhole( body_work, 32 );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithPrep );
    }

    // Token: 0x06000BFD RID: 3069 RVA: 0x0006A475 File Offset: 0x00068675
    private static void gmBoss5BodyStateLeaveRpc( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 2281701375U;
        body_work.flag &= 4294967283U;
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
    }

    // Token: 0x06000BFE RID: 3070 RVA: 0x0006A4A0 File Offset: 0x000686A0
    private static void gmBoss5BodyStateUpdateRpcWithPrep( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            body_work.flag |= 4U;
            if ( body_work.state == 9 )
            {
                AppMain.GmBoss5RocketLaunchStrong( body_work, 0 );
            }
            else
            {
                AppMain.GmBoss5RocketLaunchNormal( body_work, 0 );
            }
            if ( body_work.state == 9 )
            {
                body_work.wait_timer = AppMain.gmBoss5BodySeqGetRpcStrSearchTime( body_work );
            }
            else
            {
                body_work.wait_timer = AppMain.gmBoss5BodySeqGetRpcNmlSearchTime( body_work );
            }
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithSearch );
        }
    }

    // Token: 0x06000BFF RID: 3071 RVA: 0x0006A51A File Offset: 0x0006871A
    private static void gmBoss5BodyStateUpdateRpcWithSearch( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodySetActionWhole( body_work, 33 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithLaunchFirst );
    }

    // Token: 0x06000C00 RID: 3072 RVA: 0x0006A550 File Offset: 0x00068750
    private static void gmBoss5BodyStateUpdateRpcWithLaunchFirst( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.obj_3d.frame[0] >= AppMain.GMD_BOSS5_BODY_RPUNCH_LAUNCH_TIMING_DELAY )
        {
            body_work.flag |= 268435456U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithWaitReturnFirst );
        }
    }

    // Token: 0x06000C01 RID: 3073 RVA: 0x0006A59C File Offset: 0x0006879C
    private static void gmBoss5BodyStateUpdateRpcWithWaitReturnFirst( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int num = 0;
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            num = 1;
        }
        if ( ( body_work.flag & 67108864U ) != 0U )
        {
            body_work.flag &= 4227858431U;
            num = 1;
            body_work.flag &= 4294967291U;
            AppMain.gmBoss5BodySetActionWhole( body_work, 34 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithLaunchSecond );
        }
        if ( num != 0 && ( body_work.flag & 8U ) == 0U )
        {
            body_work.flag |= 8U;
            if ( body_work.state == 9 )
            {
                AppMain.GmBoss5RocketLaunchStrong( body_work, 1 );
                return;
            }
            AppMain.GmBoss5RocketLaunchNormal( body_work, 1 );
        }
    }

    // Token: 0x06000C02 RID: 3074 RVA: 0x0006A63C File Offset: 0x0006883C
    private static void gmBoss5BodyStateUpdateRpcWithLaunchSecond( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.obj_3d.frame[0] >= AppMain.GMD_BOSS5_BODY_RPUNCH_LAUNCH_TIMING_DELAY )
        {
            body_work.flag |= 134217728U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithWaitReturnSecond );
        }
    }

    // Token: 0x06000C03 RID: 3075 RVA: 0x0006A688 File Offset: 0x00068888
    private static void gmBoss5BodyStateUpdateRpcWithWaitReturnSecond( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 33554432U ) != 0U )
        {
            body_work.flag &= 4261412863U;
            body_work.flag &= 4294967287U;
            AppMain.gmBoss5BodySetActionWhole( body_work, 35 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateRpcWithRecover );
        }
    }

    // Token: 0x06000C04 RID: 3076 RVA: 0x0006A6DE File Offset: 0x000688DE
    private static void gmBoss5BodyStateUpdateRpcWithRecover( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            if ( body_work.state == 9 )
            {
                AppMain.gmBoss5BodyProceedToNextSeqStr( body_work );
                return;
            }
            AppMain.gmBoss5BodyProceedToNextSeqNml( body_work );
        }
    }

    // Token: 0x06000C05 RID: 3077 RVA: 0x0006A704 File Offset: 0x00068904
    private static void gmBoss5BodyStateEnterBerserk( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodySetActionWhole( body_work, 39 );
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 9 );
        AppMain.GmBoss5EfctBreakdownSmokesInit( body_work, AppMain.GMD_BOSS5_BODY_BERSERK_BREAKDOWN_TIME );
        AppMain.GmBoss5EfctBodySmallSmokesInit( body_work );
        body_work.wait_timer = AppMain.GMD_BOSS5_BODY_BERSERK_BREAKDOWN_TIME;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithBreakdown );
    }

    // Token: 0x06000C06 RID: 3078 RVA: 0x0006A744 File Offset: 0x00068944
    private static void gmBoss5BodyStateLeaveBerserk( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyClearBerserkTurn( body_work );
        AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
    }

    // Token: 0x06000C07 RID: 3079 RVA: 0x0006A754 File Offset: 0x00068954
    private static void gmBoss5BodyStateUpdateBerserkWithBreakdown( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodySetActionWhole( body_work, 40 );
        AppMain.gmBoss5BodyInitShakeAccelerate( body_work );
        AppMain.GmBoss5EfctStartPrelimLeakage( body_work );
        body_work.wait_timer = AppMain.GMD_BOSS5_BODY_BERSERK_SHAKE_STAY_TIME;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithShake );
    }

    // Token: 0x06000C08 RID: 3080 RVA: 0x0006A7AC File Offset: 0x000689AC
    private static void gmBoss5BodyStateUpdateBerserkWithShake( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyUpdateShakeAccelerate( body_work ) != 0 )
        {
            if ( body_work.wait_timer != 0U )
            {
                body_work.wait_timer -= 1U;
                return;
            }
            AppMain.gmBoss5InitAlarmFade( body_work.mgr_work );
            AppMain.gmBoss5MgrSetAlarmLevel( body_work.mgr_work, 0 );
            AppMain.GmDecoStartEffectFinalBossLight();
            AppMain.gmBoss5BodySetActionWhole( body_work, 41 );
            AppMain.GmSoundPlaySE( "FinalBoss08" );
            AppMain.gmBoss5BodyInitBerserkTurn( body_work, 0 );
            AppMain.GmBoss5EfctEndPrelimLeakage( body_work );
            AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithTurnFront );
        }
    }

    // Token: 0x06000C09 RID: 3081 RVA: 0x0006A82B File Offset: 0x00068A2B
    private static void gmBoss5BodyStateUpdateBerserkWithTurnFront( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyUpdateBerserkTurn( body_work ) != 0 )
        {
            AppMain.GmBoss5EfctBerserkSteamInit( body_work, 1U );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_BERSERK_ROAR_PREP_TIME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithRoarPrep );
        }
    }

    // Token: 0x06000C0A RID: 3082 RVA: 0x0006A859 File Offset: 0x00068A59
    private static void gmBoss5BodyStateUpdateBerserkWithRoarPrep( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodySetActionWhole( body_work, 42 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithRoarStart );
    }

    // Token: 0x06000C0B RID: 3083 RVA: 0x0006A88C File Offset: 0x00068A8C
    private static void gmBoss5BodyStateUpdateBerserkWithRoarStart( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            AppMain.GmBoss5EfctBerserkSteamInit( body_work, 1U );
            AppMain.gmBoss5BodySetActionWhole( body_work, 43 );
            body_work.wait_timer = AppMain.GMD_BOSS5_BODY_BERSERK_ROAR_LOOP_TIME;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithRoarLoop );
        }
    }

    // Token: 0x06000C0C RID: 3084 RVA: 0x0006A8C8 File Offset: 0x00068AC8
    private static void gmBoss5BodyStateUpdateBerserkWithRoarLoop( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodySetActionWhole( body_work, 44 );
        AppMain.GmBoss5EfctCreateBerserkStampSmoke( body_work, 0, AppMain.GMD_BOSS5_BODY_BERSERK_STAMP_SMOKE_CREATE_DELAY );
        AppMain.gmBoss5DelayedVibration( 2, AppMain.GMD_BOSS5_BODY_BERSERK_STAMP_VIB_START_DELAY );
        AppMain.gmBoss5DelayedSePlayback( "FinalBoss03", AppMain.GMD_BOSS5_BODY_BERSERK_STAMP_SE_START_DELAY );
        AppMain.gmBoss5BodyInitBerserkTurn( body_work, 1 );
        AppMain.gmBoss5BodyInitGroundingMove( body_work, body_work.rfoot_snm_reg_id );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithTurnSide );
    }

    // Token: 0x06000C0D RID: 3085 RVA: 0x0006A93F File Offset: 0x00068B3F
    private static void gmBoss5BodyStateUpdateBerserkWithTurnSide( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyUpdateGroundingMove( body_work );
        if ( AppMain.gmBoss5BodyUpdateBerserkTurn( body_work ) != 0 )
        {
            AppMain.gmBoss5BodyClearBerserkTurn( body_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithStamp );
        }
    }

    // Token: 0x06000C0E RID: 3086 RVA: 0x0006A968 File Offset: 0x00068B68
    private static void gmBoss5BodyStateUpdateBerserkWithStamp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodyUpdateGroundingMove( body_work );
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 45 );
            AppMain.gmBoss5BodyInitGroundingMove( body_work, body_work.lfoot_snm_reg_id );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateBerserkWithKickUp );
        }
    }

    // Token: 0x06000C0F RID: 3087 RVA: 0x0006A9B0 File Offset: 0x00068BB0
    private static void gmBoss5BodyStateUpdateBerserkWithKickUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss5BodyUpdateGroundingMove( body_work );
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss5BodyProceedToNextSeqStr( body_work );
        }
    }

    // Token: 0x06000C10 RID: 3088 RVA: 0x0006A9D8 File Offset: 0x00068BD8
    private static void gmBoss5BodyStateEnterDefeat( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.mgr_work.flag |= 134217728U;
        AppMain.GmPlayerAddScoreNoDisp( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 1000 );
        body_work.flag |= 512U;
        body_work.flag |= 8192U;
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 10 );
        AppMain.gmBoss5InitExplCreate( body_work.expl_work, 1, body_work.part_obj_core, AppMain.GMD_BOSS5_EXPL_BODY_OFST_X, AppMain.GMD_BOSS5_EXPL_BODY_OFST_Y, AppMain.GMD_BOSS5_EXPL_BODY_WIDTH, AppMain.GMD_BOSS5_EXPL_BODY_HEIGHT, AppMain.GMD_BOSS5_EXPL_BODY_INTERVAL_MIN, AppMain.GMD_BOSS5_EXPL_BODY_INTERVAL_MAX, AppMain.GMD_BOSS5_EXPL_BODY_SE_FREQUENCY );
        body_work.wait_timer = AppMain.GMD_BOSS5_BODY_DEFEAT_WAIT_START_TIME;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateDefeatWithWaitStart );
    }

    // Token: 0x06000C11 RID: 3089 RVA: 0x0006AA8E File Offset: 0x00068C8E
    private static void gmBoss5BodyStateLeaveDefeat( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        body_work.flag &= 4294959103U;
        body_work.flag &= 4294966783U;
    }

    // Token: 0x06000C12 RID: 3090 RVA: 0x0006AAB4 File Offset: 0x00068CB4
    private static void gmBoss5BodyStateUpdateDefeatWithWaitStart( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5UpdateExplCreate( body_work.expl_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5BodyRegisterScatterPartsCNM( body_work );
        AppMain.gmBoss5InitScatter( body_work );
        body_work.wait_timer = AppMain.MTM_MATH_MAX( 80U, 90U );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodyStateUpdateDefeatWithExplode );
    }

    // Token: 0x06000C13 RID: 3091 RVA: 0x0006AB10 File Offset: 0x00068D10
    private static void gmBoss5BodyStateUpdateDefeatWithExplode( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int num = 0;
        AppMain.gmBoss5UpdateExplCreate( body_work.expl_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
        }
        else if ( ( body_work.flag & 524288U ) == 0U )
        {
            AppMain.gmBoss5BodyInitScatterFall( body_work );
            body_work.flag |= 524288U;
        }
        else
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
            if ( AppMain.gmBoss5BodyUpdateScatterFall( body_work ) != 0 )
            {
                num = 1;
            }
            if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U && ( body_work.flag & 2097152U ) == 0U )
            {
                AppMain.GmBoss5EfctCreateBigExplosion( body_work.part_obj_core.pos.x, body_work.part_obj_core.pos.y, body_work.part_obj_core.pos.z + AppMain.GMD_BOSS5_EXPL_OFST_Z );
                body_work.flag |= 2097152U;
                AppMain.GmSoundPlaySE( "Boss0_03" );
                AppMain.gmBoss5InitFlashScreen();
                AppMain.GMM_PAD_VIB_MID_TIME( 120f );
            }
        }
        if ( AppMain.gmBoss5BodyIsBodyExplosionStopAllowed( body_work ) != 0 && num != 0 )
        {
            body_work.proc_update = null;
            body_work.mgr_work.flag |= 268435456U;
        }
    }

    // Token: 0x06000C14 RID: 3092 RVA: 0x0006AC28 File Offset: 0x00068E28
    private static void gmBoss5BodySubSeqEnterMoveFastCrash( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.sub_seq == 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 18 );
        }
        else
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 19 );
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodySubSeqUpdateMoveFastCrashWithStagger );
    }

    // Token: 0x06000C15 RID: 3093 RVA: 0x0006AC58 File Offset: 0x00068E58
    private static void gmBoss5BodySubSeqUpdateMoveFastCrashWithStagger( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U && AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.gmBoss5BodyResumeMoveFast( body_work );
        }
    }

    // Token: 0x06000C16 RID: 3094 RVA: 0x0006AC84 File Offset: 0x00068E84
    private static void gmBoss5BodySubSeqEnterRpcStrDmg( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodySetActionWhole( body_work, 36 );
        AppMain.gmBoss5BodyChangeRectSetting( body_work, 8 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodySubSeqUpdateRpcStrDmgWithBend );
    }

    // Token: 0x06000C17 RID: 3095 RVA: 0x0006ACA7 File Offset: 0x00068EA7
    private static void gmBoss5BodySubSeqUpdateRpcStrDmgWithBend( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            AppMain.gmBoss5BodySetActionWhole( body_work, 37 );
            body_work.wait_timer = 240U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodySubSeqUpdateRpcStrDmgWithSwing );
        }
    }

    // Token: 0x06000C18 RID: 3096 RVA: 0x0006ACDB File Offset: 0x00068EDB
    private static void gmBoss5BodySubSeqUpdateRpcStrDmgWithSwing( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        body_work.flag |= 1610612736U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodySubSeqUpdateRpcStrDmgWithWaitReturn );
    }

    // Token: 0x06000C19 RID: 3097 RVA: 0x0006AD18 File Offset: 0x00068F18
    private static void gmBoss5BodySubSeqUpdateRpcStrDmgWithWaitReturn( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss5BodyReceiveSignalRocketReturned( body_work ) != 0 )
        {
            body_work.flag &= 4294967283U;
            AppMain.gmBoss5BodySetActionWhole( body_work, 38 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.gmBoss5BodySubSeqUpdateRpcStrDmgWithRecover );
        }
    }

    // Token: 0x06000C1A RID: 3098 RVA: 0x0006AD4B File Offset: 0x00068F4B
    private static void gmBoss5BodySubSeqUpdateRpcStrDmgWithRecover( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( AppMain.GmBsCmnIsActionEnd( AppMain.GMM_BS_OBJ( body_work ) ) != 0 )
        {
            AppMain.gmBoss5BodyChangeRectSettingDefault( body_work );
            AppMain.gmBoss5BodyProceedToNextSeqStr( body_work );
        }
    }

    // Token: 0x06000C1B RID: 3099 RVA: 0x0006AD68 File Offset: 0x00068F68
    private static void gmBoss5CoreWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_CORE_WORK core_work = (AppMain.GMS_BOSS5_CORE_WORK)obj_work;
        if ( ( gms_BOSS5_BODY_WORK.mgr_work.flag & 1U ) != 0U )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5CoreMain );
            AppMain.gmBoss5CoreProcInit( core_work );
        }
    }

    // Token: 0x06000C1C RID: 3100 RVA: 0x0006ADB0 File Offset: 0x00068FB0
    private static void gmBoss5CoreMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_CORE_WORK gms_BOSS5_CORE_WORK = (AppMain.GMS_BOSS5_CORE_WORK)obj_work;
        if ( gms_BOSS5_CORE_WORK.proc_update != null )
        {
            gms_BOSS5_CORE_WORK.proc_update( gms_BOSS5_CORE_WORK );
        }
    }

    // Token: 0x06000C1D RID: 3101 RVA: 0x0006ADD8 File Offset: 0x00068FD8
    private static void gmBoss5CoreProcInit( AppMain.GMS_BOSS5_CORE_WORK core_work )
    {
        core_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_CORE_WORK( AppMain.gmBoss5CoreProcUpdateLoop );
    }

    // Token: 0x06000C1E RID: 3102 RVA: 0x0006ADEC File Offset: 0x00068FEC
    private static void gmBoss5CoreProcUpdateLoop( AppMain.GMS_BOSS5_CORE_WORK core_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(core_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.GmBsCmnUpdateObjectGeneralStuckWithNodeRelative( obs_OBJECT_WORK, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id, obs_OBJECT_WORK.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos );
        AppMain.gmBoss5BodyUpdateMainRectPosition( gms_BOSS5_BODY_WORK );
        AppMain.gmBoss5BodyUpdateSubRectPosition( gms_BOSS5_BODY_WORK );
        if ( ( gms_BOSS5_BODY_WORK.flag & 8192U ) != 0U )
        {
            ( ( AppMain.GMS_ENEMY_COM_WORK )obs_OBJECT_WORK ).enemy_flag |= 32768U;
            return;
        }
        ( ( AppMain.GMS_ENEMY_COM_WORK )obs_OBJECT_WORK ).enemy_flag &= 4294934527U;
    }

    // Token: 0x06000C1F RID: 3103 RVA: 0x0006AE80 File Offset: 0x00069080
    private static void gmBoss5InitAlarmFade( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 32U ) != 0U )
        {
            return;
        }
        mgr_work.flag |= 32U;
        AppMain.GMS_BOSS5_ALARM_FADE_WORK gms_BOSS5_ALARM_FADE_WORK = (AppMain.GMS_BOSS5_ALARM_FADE_WORK)AppMain.GmFadeCreateFadeObj(6656, 3, 0, () => new AppMain.GMS_BOSS5_ALARM_FADE_WORK(), 61439, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_BOSS5_ALARM_FADE_WORK;
        obs_OBJECT_WORK.parent_obj = AppMain.GMM_BS_OBJ( mgr_work );
        gms_BOSS5_ALARM_FADE_WORK.mgr_work = mgr_work;
        AppMain.GmFadeSetFade( gms_BOSS5_ALARM_FADE_WORK.fade_obj, 0U, 0, 0, 0, 0, 0, 0, 0, 0, 1f, 0, 0 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5AlarmFadeMain );
        AppMain.gmBoss5AlarmFadeProcInit( gms_BOSS5_ALARM_FADE_WORK );
    }

    // Token: 0x06000C20 RID: 3104 RVA: 0x0006AF2A File Offset: 0x0006912A
    private static void gmBoss5RequestClearAlarmFade( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        mgr_work.flag &= 4294967263U;
    }

    // Token: 0x06000C21 RID: 3105 RVA: 0x0006AF3B File Offset: 0x0006913B
    private static void gmBoss5AlarmFadeInitFade( AppMain.GMS_BOSS5_ALARM_FADE_WORK alarm_fade, int alarm_level )
    {
        alarm_fade.cur_phase = 0;
        alarm_fade.cur_level = alarm_level;
        alarm_fade.wait_timer = 0U;
        AppMain.gmBoss5AlarmFadeUpdateFade( alarm_fade );
    }

    // Token: 0x06000C22 RID: 3106 RVA: 0x0006AF5C File Offset: 0x0006915C
    private static int gmBoss5AlarmFadeUpdateFade( AppMain.GMS_BOSS5_ALARM_FADE_WORK alarm_fade )
    {
        if ( alarm_fade.wait_timer != 0U )
        {
            alarm_fade.wait_timer -= 1U;
        }
        else
        {
            if ( AppMain.GmFadeIsEnd( alarm_fade.fade_obj ) == 0 )
            {
                return 0;
            }
            AppMain.GMS_BOSS5_ALARM_FADE_INFO gms_BOSS5_ALARM_FADE_INFO = AppMain.gm_boss5_alarm_fade_info[alarm_fade.cur_level];
            switch ( alarm_fade.cur_phase )
            {
                case 0:
                    AppMain.GmFadeSetFade( alarm_fade.fade_obj, 0U, byte.MaxValue, 0, 0, 0, AppMain.GMD_BOSS5_ALARM_FADE_DEST_RED, AppMain.GMD_BOSS5_ALARM_FADE_DEST_GREEN, AppMain.GMD_BOSS5_ALARM_FADE_DEST_BLUE, AppMain.GMD_BOSS5_ALARM_FADE_DEST_ALPHA, gms_BOSS5_ALARM_FADE_INFO.fo_frame, 0, 0 );
                    alarm_fade.cur_phase = 1;
                    break;
                case 1:
                    alarm_fade.wait_timer = gms_BOSS5_ALARM_FADE_INFO.on_frame;
                    alarm_fade.cur_phase = 2;
                    break;
                case 2:
                    AppMain.GmFadeSetFade( alarm_fade.fade_obj, 0U, AppMain.GMD_BOSS5_ALARM_FADE_DEST_RED, AppMain.GMD_BOSS5_ALARM_FADE_DEST_GREEN, AppMain.GMD_BOSS5_ALARM_FADE_DEST_BLUE, AppMain.GMD_BOSS5_ALARM_FADE_DEST_ALPHA, byte.MaxValue, 0, 0, 0, gms_BOSS5_ALARM_FADE_INFO.fi_frame, 0, 1 );
                    alarm_fade.cur_phase = 3;
                    break;
                case 3:
                    alarm_fade.wait_timer = gms_BOSS5_ALARM_FADE_INFO.off_frame;
                    alarm_fade.cur_phase = 4;
                    break;
                case 4:
                    return 1;
                default:
                    alarm_fade.cur_phase = 0;
                    break;
            }
        }
        return 0;
    }

    // Token: 0x06000C23 RID: 3107 RVA: 0x0006B070 File Offset: 0x00069270
    private static void gmBoss5AlarmFadeInitAlertSe( AppMain.GMS_BOSS5_ALARM_FADE_WORK alarm_fade )
    {
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = alarm_fade.mgr_work;
        alarm_fade.alert_se_ref_level = mgr_work.alarm_level;
        AppMain.GmBoss5Init1ShotTimer( alarm_fade.alert_se_timer, AppMain.gm_boss5_alarm_se_interval_time_tbl[alarm_fade.alert_se_ref_level] );
        AppMain.GmSoundPlaySE( "FinalBoss10" );
    }

    // Token: 0x06000C24 RID: 3108 RVA: 0x0006B0B4 File Offset: 0x000692B4
    private static void gmBoss5AlarmFadeUpdateAlertSe( AppMain.GMS_BOSS5_ALARM_FADE_WORK alarm_fade )
    {
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = alarm_fade.mgr_work;
        if ( AppMain.GmBoss5Update1ShotTimer( alarm_fade.alert_se_timer ) != 0 || alarm_fade.alert_se_ref_level != mgr_work.alarm_level )
        {
            AppMain.GmSoundPlaySE( "FinalBoss10" );
            alarm_fade.alert_se_ref_level = mgr_work.alarm_level;
            AppMain.GmBoss5Init1ShotTimer( alarm_fade.alert_se_timer, AppMain.gm_boss5_alarm_se_interval_time_tbl[alarm_fade.alert_se_ref_level] );
        }
    }

    // Token: 0x06000C25 RID: 3109 RVA: 0x0006B110 File Offset: 0x00069310
    private static void gmBoss5AlarmFadeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_ALARM_FADE_WORK gms_BOSS5_ALARM_FADE_WORK = (AppMain.GMS_BOSS5_ALARM_FADE_WORK)obj_work;
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = gms_BOSS5_ALARM_FADE_WORK.mgr_work;
        if ( ( mgr_work.flag & 32U ) == 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        if ( gms_BOSS5_ALARM_FADE_WORK.proc_update != null )
        {
            gms_BOSS5_ALARM_FADE_WORK.proc_update( gms_BOSS5_ALARM_FADE_WORK );
        }
    }

    // Token: 0x06000C26 RID: 3110 RVA: 0x0006B15C File Offset: 0x0006935C
    private static void gmBoss5AlarmFadeProcInit( AppMain.GMS_BOSS5_ALARM_FADE_WORK alarm_fade )
    {
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = alarm_fade.mgr_work;
        AppMain.gmBoss5AlarmFadeInitFade( alarm_fade, mgr_work.alarm_level );
        AppMain.gmBoss5AlarmFadeInitAlertSe( alarm_fade );
        alarm_fade.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_ALARM_FADE_WORK( AppMain.gmBoss5AlarmFadeProcUpdateLoop );
    }

    // Token: 0x06000C27 RID: 3111 RVA: 0x0006B194 File Offset: 0x00069394
    private static void gmBoss5AlarmFadeProcUpdateLoop( AppMain.GMS_BOSS5_ALARM_FADE_WORK alarm_fade )
    {
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = alarm_fade.mgr_work;
        AppMain.gmBoss5AlarmFadeUpdateAlertSe( alarm_fade );
        if ( AppMain.gmBoss5AlarmFadeUpdateFade( alarm_fade ) != 0 )
        {
            AppMain.gmBoss5AlarmFadeInitFade( alarm_fade, mgr_work.alarm_level );
        }
    }

    // Token: 0x06000C28 RID: 3112 RVA: 0x0006B1CC File Offset: 0x000693CC
    private static void gmBoss5InitFlashScreen()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_BOSS5_FLASH_SCREEN_WORK(), null, 0, "boss5_flash_scr");
        AppMain.GMS_BOSS5_FLASH_SCREEN_WORK gms_BOSS5_FLASH_SCREEN_WORK = (AppMain.GMS_BOSS5_FLASH_SCREEN_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.disp_flag |= 4128U;
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.GmBsCmnInitFlashScreen( gms_BOSS5_FLASH_SCREEN_WORK.flash_work, ( float )AppMain.GMD_BOSS5_FLASH_SCREEN_FADEOUT_TIME, 5f, 30f );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5FlashScreenMain );
    }

    // Token: 0x06000C29 RID: 3113 RVA: 0x0006B258 File Offset: 0x00069458
    private static void gmBoss5FlashScreenMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_FLASH_SCREEN_WORK gms_BOSS5_FLASH_SCREEN_WORK = (AppMain.GMS_BOSS5_FLASH_SCREEN_WORK)obj_work;
        if ( AppMain.GmBsCmnUpdateFlashScreen( gms_BOSS5_FLASH_SCREEN_WORK.flash_work ) != 0 )
        {
            AppMain.GmBsCmnClearFlashScreen( gms_BOSS5_FLASH_SCREEN_WORK.flash_work );
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06000C2A RID: 3114 RVA: 0x0006B29C File Offset: 0x0006949C
    private static void gmBoss5InitLastFadeOut( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.GMS_FADE_OBJ_WORK gms_FADE_OBJ_WORK = AppMain.GmFadeCreateFadeObj(6656, 3, 0, () => new AppMain.GMS_FADE_OBJ_WORK(), 61439, 6U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_FADE_OBJ_WORK;
        obs_OBJECT_WORK.parent_obj = AppMain.GMM_BS_OBJ( mgr_work );
        AppMain.GmFadeSetFade( gms_FADE_OBJ_WORK, 0U, 0, 0, 0, 0, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, 300f, 0, 0 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5LastFadeOutMain );
    }

    // Token: 0x06000C2B RID: 3115 RVA: 0x0006B324 File Offset: 0x00069524
    private static void gmBoss5LastFadeOutMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_FADE_OBJ_WORK fade_obj = (AppMain.GMS_FADE_OBJ_WORK)obj_work;
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = (AppMain.GMS_BOSS5_MGR_WORK)obj_work.parent_obj;
        if ( AppMain.GmFadeIsEnd( fade_obj ) != 0 )
        {
            AppMain.gmBoss5RequestClearAlarmFade( mgr_work );
            AppMain.GmFixSetDisp( false );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5LastFadeOutEnd );
        }
    }

    // Token: 0x06000C2C RID: 3116 RVA: 0x0006B36C File Offset: 0x0006956C
    private static void gmBoss5LastFadeOutEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_FADE_OBJ_WORK gms_FADE_OBJ_WORK = (AppMain.GMS_FADE_OBJ_WORK)obj_work;
        AppMain.GMS_BOSS5_MGR_WORK gms_BOSS5_MGR_WORK = (AppMain.GMS_BOSS5_MGR_WORK)obj_work.parent_obj;
        gms_BOSS5_MGR_WORK.flag |= 2147483648U;
        gms_FADE_OBJ_WORK.fade_work.draw_state = 0U;
        obj_work.ppFunc = null;
    }

    // Token: 0x06000C2D RID: 3117 RVA: 0x0006B3B8 File Offset: 0x000695B8
    private static void gmBoss5InitScatter( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int[] array = new int[]
        {
            body_work.armpt_snm_reg_ids[0][2],
            body_work.armpt_snm_reg_ids[1][2],
            body_work.groin_snm_reg_ids[0],
            body_work.groin_snm_reg_ids[1],
            body_work.leg_snm_reg_ids[0],
            body_work.leg_snm_reg_ids[1]
        };
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        for ( int i = 0; i < 22; i++ )
        {
            AppMain.GMS_BOSS5_SCT_PART_INFO gms_BOSS5_SCT_PART_INFO = AppMain.gm_boss5_scatter_parts_info_tbl[i];
            AppMain.GmBsCmnChangeCNMModeNode( body_work.cnm_mgr_work, body_work.scatter_cnm_reg_ids[i], ( uint )gms_BOSS5_SCT_PART_INFO.cnm_mode );
            AppMain.GmBsCmnEnableCNMLocalCoordinate( body_work.cnm_mgr_work, body_work.scatter_cnm_reg_ids[i], gms_BOSS5_SCT_PART_INFO.is_local_coord );
            AppMain.GmBsCmnEnableCNMInheritNodeScale( body_work.cnm_mgr_work, body_work.scatter_cnm_reg_ids[i], gms_BOSS5_SCT_PART_INFO.is_inherit_scale );
            AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX, body_work.scatter_cnm_reg_ids[i], 1 );
        }
        for ( int j = 0; j < 6; j++ )
        {
            AppMain.GMS_BOSS5_SCT_NDC_INFO gms_BOSS5_SCT_NDC_INFO = AppMain.gm_boss5_scatter_ndc_info_tbl[j];
            int part_idx = gms_BOSS5_SCT_NDC_INFO.part_idx;
            AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, body_work.scatter_cnm_reg_ids[part_idx], 0 );
            AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = AppMain.GmBsCmnCreateNodeControlObjectBySize(AppMain.GMM_BS_OBJ(body_work), body_work.cnm_mgr_work, body_work.scatter_cnm_reg_ids[part_idx], body_work.snm_work, array[j], () => new AppMain.GMS_BOSS5_SCT_PART_NDC_WORK());
            AppMain.GMS_BOSS5_SCT_PART_NDC_WORK sct_part_ndc = (AppMain.GMS_BOSS5_SCT_PART_NDC_WORK)gms_BS_CMN_NODE_CTRL_OBJECT;
            gms_BS_CMN_NODE_CTRL_OBJECT.user_timer = gms_BOSS5_SCT_NDC_INFO.delay_time;
            gms_BS_CMN_NODE_CTRL_OBJECT.is_enable = 0;
            AppMain.gmBoss5ScatterSetPartParam( sct_part_ndc );
            AppMain.GMM_BS_OBJ( gms_BS_CMN_NODE_CTRL_OBJECT ).move_flag |= 4608U;
            AppMain.nnMakeUnitQuaternion( ref gms_BS_CMN_NODE_CTRL_OBJECT.user_quat );
            gms_BS_CMN_NODE_CTRL_OBJECT.proc_update = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5ScatterProcWait );
        }
        body_work.flag |= 262144U;
    }

    // Token: 0x06000C2E RID: 3118 RVA: 0x0006B58C File Offset: 0x0006978C
    private static void gmBoss5ScatterSetPartParam( AppMain.GMS_BOSS5_SCT_PART_NDC_WORK sct_part_ndc )
    {
        AppMain.nnMakeUnitQuaternion( ref sct_part_ndc.spin_quat );
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            float num = AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()) * 2f - 1f;
            num = AppMain.MTM_MATH_CLIP( num, -1f, 1f );
            short rand_angle = AppMain.AKM_DEGtoA16(360f * AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()));
            AppMain.AkMathGetRandomUnitVector( nns_VECTOR, num, rand_angle );
            AppMain.NNS_QUATERNION nns_QUATERNION;
            AppMain.nnMakeRotateAxisQuaternion( out nns_QUATERNION, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z, AppMain.GMD_BOSS5_SCT_SPIN_SPD_ANGLE );
            AppMain.nnMultiplyQuaternion( ref sct_part_ndc.spin_quat, ref nns_QUATERNION, ref sct_part_ndc.spin_quat );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        }
    }

    // Token: 0x06000C2F RID: 3119 RVA: 0x0006B63C File Offset: 0x0006983C
    private static void gmBoss5ScatterProcWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obj_work;
        if ( gms_BS_CMN_NODE_CTRL_OBJECT.user_timer != 0U )
        {
            gms_BS_CMN_NODE_CTRL_OBJECT.user_timer -= 1U;
            return;
        }
        AppMain.GmBsCmnAttachNCObjectToSNMNode( gms_BS_CMN_NODE_CTRL_OBJECT );
        AppMain.GmBoss5ScatterSetFlyParam( obj_work );
        gms_BS_CMN_NODE_CTRL_OBJECT.is_enable = 1;
        gms_BS_CMN_NODE_CTRL_OBJECT.user_timer = 180U;
        AppMain.GmBoss5EfctCreateSmallExplosion( obj_work.pos.x, obj_work.pos.y, obj_work.pos.z + AppMain.GMD_BOSS5_EXPL_OFST_Z );
        gms_BS_CMN_NODE_CTRL_OBJECT.proc_update = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5ScatterProcFly );
    }

    // Token: 0x06000C30 RID: 3120 RVA: 0x0006B6C4 File Offset: 0x000698C4
    private static void gmBoss5ScatterProcFly( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obj_work;
        AppMain.GMS_BOSS5_SCT_PART_NDC_WORK gms_BOSS5_SCT_PART_NDC_WORK = (AppMain.GMS_BOSS5_SCT_PART_NDC_WORK)gms_BS_CMN_NODE_CTRL_OBJECT;
        AppMain.nnMultiplyQuaternion( ref gms_BS_CMN_NODE_CTRL_OBJECT.user_quat, ref gms_BOSS5_SCT_PART_NDC_WORK.spin_quat, ref gms_BS_CMN_NODE_CTRL_OBJECT.user_quat );
        AppMain.GmBsCmnSetWorldMtxFromNCObjectPosture( gms_BS_CMN_NODE_CTRL_OBJECT );
        if ( gms_BS_CMN_NODE_CTRL_OBJECT.user_timer != 0U )
        {
            gms_BS_CMN_NODE_CTRL_OBJECT.user_timer -= 1U;
            return;
        }
        obj_work.flag |= 4U;
    }

    // Token: 0x06000C31 RID: 3121 RVA: 0x0006B721 File Offset: 0x00069921
    private static void gmBoss5BodySeqTryRequestEnableStr( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.mgr_work.life <= AppMain.GMD_BOSS5_STRONG_MODE_THRESHOLD_LIFE )
        {
            body_work.mgr_work.flag |= 4U;
        }
    }

    // Token: 0x06000C32 RID: 3122 RVA: 0x0006B748 File Offset: 0x00069948
    private static void gmBoss5BodySeqTryEnableStr( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.mgr_work.flag & 4U ) != 0U )
        {
            body_work.mgr_work.flag |= 8U;
        }
    }

    // Token: 0x06000C33 RID: 3123 RVA: 0x0006B76C File Offset: 0x0006996C
    private static int gmBoss5BodySeqIsStr( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( ( body_work.mgr_work.flag & 8U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000C34 RID: 3124 RVA: 0x0006B780 File Offset: 0x00069980
    private static int gmBoss5BodySeqIsNearDeath( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        if ( body_work.mgr_work.life <= 1 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000C35 RID: 3125 RVA: 0x0006B793 File Offset: 0x00069993
    private static int gmBoss5BodySeqLotStrat( int strat_branch )
    {
        return AppMain.gmBoss5BodySeqLotStrat( strat_branch, 0 );
    }

    // Token: 0x06000C36 RID: 3126 RVA: 0x0006B79C File Offset: 0x0006999C
    private static int gmBoss5BodySeqLotStrat( int strat_branch, int b_no_rkt )
    {
        AppMain.GMS_BOSS5_STRAT_PROB_INFO[] array = AppMain.gm_boss5_body_seq_strat_branch_prob_tbl[strat_branch];
        int num = 0;
        int num2 = 0;
        int num3 = AppMain.AkMathRandFx();
        if ( b_no_rkt != 0 )
        {
            int num4 = 4096;
            int num5 = 0;
            while ( ( long )num5 < 3L )
            {
                if ( array[num5].is_rkt != 0 )
                {
                    num4 -= array[num5].probability;
                    num4 = AppMain.MTM_MATH_CLIP( num4, 0, 4096 );
                }
                num5++;
            }
            num3 = AppMain.FX_Mul( num3, num4 );
            num3 = AppMain.MTM_MATH_CLIP( num3, 0, num4 );
        }
        int num6 = 0;
        while ( ( long )num6 < 3L )
        {
            int probability = array[num6].probability;
            if ( ( b_no_rkt == 0 || array[num6].is_rkt == 0 ) && probability > 0 )
            {
                num = num6;
                num2 += probability;
                if ( num3 <= num2 )
                {
                    return array[num6].strat_state;
                }
            }
            num6++;
        }
        return array[num].strat_state;
    }

    // Token: 0x06000C37 RID: 3127 RVA: 0x0006B85C File Offset: 0x00069A5C
    private static void gmBoss5BodyProceedToNextSeqNml( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int state = body_work.state;
        int num = 0;
        AppMain.gmBoss5BodySeqTryEnableStr( body_work );
        if ( AppMain.gmBoss5BodySeqIsStr( body_work ) != 0 )
        {
            num = 8;
        }
        else
        {
            int b_no_rkt = 0;
            if ( AppMain.gmBoss5BodyIsPlayerBehind( body_work ) != 0 )
            {
                b_no_rkt = 1;
            }
            switch ( body_work.strat_state )
            {
                case 1:
                    num = 2;
                    break;
                case 2:
                case 3:
                case 4:
                    num = 5;
                    break;
                case 5:
                    num = AppMain.gmBoss5BodySeqLotStrat( 0, b_no_rkt );
                    break;
                case 6:
                    num = 5;
                    break;
                case 7:
                    num = AppMain.gmBoss5BodySeqLotStrat( 1, b_no_rkt );
                    break;
            }
        }
        state = AppMain.gm_boss5_body_state_strat_tbl[num];
        AppMain.gmBoss5BodyChangeState( body_work, state, num, 1 );
    }

    // Token: 0x06000C38 RID: 3128 RVA: 0x0006B8F0 File Offset: 0x00069AF0
    private static void gmBoss5BodyProceedToNextSeqStr( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        int num = body_work.state;
        int num2 = 0;
        if ( AppMain.gmBoss5BodySeqIsNearDeath( body_work ) != 0 )
        {
            num2 = 16;
        }
        else
        {
            int num3 = 0;
            if ( AppMain.gmBoss5BodyIsPlayerBehind( body_work ) != 0 )
            {
                num3 = 1;
            }
            switch ( body_work.strat_state )
            {
                case 8:
                    num2 = 9;
                    break;
                case 9:
                    num2 = 12;
                    break;
                case 10:
                case 13:
                    if ( num3 != 0 )
                    {
                        num2 = 12;
                    }
                    else
                    {
                        num2 = 15;
                    }
                    break;
                case 11:
                    num2 = 12;
                    break;
                case 12:
                    num2 = AppMain.gmBoss5BodySeqLotStrat( 2, num3 );
                    break;
                case 14:
                    num2 = AppMain.gmBoss5BodySeqLotStrat( 3, num3 );
                    break;
                case 15:
                    num2 = 12;
                    break;
            }
        }
        num = AppMain.gm_boss5_body_state_strat_tbl[num2];
        if ( num == 3 )
        {
            AppMain.gmBoss5BodySetMoveFastTime( body_work, 360U );
        }
        else
        {
            AppMain.gmBoss5BodySetMoveFastTime( body_work, 0U );
        }
        AppMain.gmBoss5BodyChangeState( body_work, num, num2, 1 );
    }

    // Token: 0x06000C39 RID: 3129 RVA: 0x0006B9CD File Offset: 0x00069BCD
    private static void gmBoss5BodyProceedToDefeatState( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.gmBoss5BodyChangeState( body_work, 11, 0, 1 );
    }

    // Token: 0x06000C3A RID: 3130 RVA: 0x0006B9D9 File Offset: 0x00069BD9
    private static uint gmBoss5BodySeqGetRpcNmlSearchTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
        if ( AppMain.AkMathRandFx() < AppMain.GMD_BOSS5_BODY_SEQ_RPUNCH_NML_FASTSHOT_PROB )
        {
            return AppMain.GMD_BOSS5_BODY_SEQ_RPUNCH_NML_SEARCH_TIME_SHORT;
        }
        return AppMain.GMD_BOSS5_BODY_SEQ_RPUNCH_NML_SEARCH_TIME_NORMAL;
    }

    // Token: 0x06000C3B RID: 3131 RVA: 0x0006B9F8 File Offset: 0x00069BF8
    private static uint gmBoss5BodySeqGetRpcStrSearchTime( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
        if ( ( long )AppMain.AkMathRandFx() < ( long )( ( ulong )AppMain.GMD_BOSS5_BODY_SEQ_RPUNCH_STR_FASTSHOT_PROB ) )
        {
            return AppMain.GMD_BOSS5_BODY_SEQ_RPUNCH_STR_SEARCH_TIME_SHORT;
        }
        return AppMain.GMD_BOSS5_BODY_SEQ_RPUNCH_STR_SEARCH_TIME_NORMAL;
    }
}