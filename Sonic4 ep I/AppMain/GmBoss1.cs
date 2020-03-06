using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x020002EA RID: 746
    public class GMS_BOSS1_1SHOT_TIMER
    {
        // Token: 0x04005CA4 RID: 23716
        public uint timer;

        // Token: 0x04005CA5 RID: 23717
        public bool is_active;
    }

    // Token: 0x020002EB RID: 747
    public class GMS_BOSS1_MTN_SUSPEND_WORK
    {
        // Token: 0x04005CA6 RID: 23718
        public bool is_suspended;

        // Token: 0x04005CA7 RID: 23719
        public uint suspend_timer;
    }

    // Token: 0x020002EC RID: 748
    public class GMS_BOSS1_EFF_BOMB_WORK
    {
        // Token: 0x04005CA8 RID: 23720
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x04005CA9 RID: 23721
        public int bomb_type;

        // Token: 0x04005CAA RID: 23722
        public uint interval_timer;

        // Token: 0x04005CAB RID: 23723
        public uint interval_min;

        // Token: 0x04005CAC RID: 23724
        public uint interval_max;

        // Token: 0x04005CAD RID: 23725
        public readonly int[] pos = new int[2];

        // Token: 0x04005CAE RID: 23726
        public readonly int[] area = new int[2];

        // Token: 0x04005CAF RID: 23727
        public int interval_timer_sound;
    }

    // Token: 0x020002ED RID: 749
    public class GMS_BOSS1_MGR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002501 RID: 9473 RVA: 0x0014B842 File Offset: 0x00149A42
        public GMS_BOSS1_MGR_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002502 RID: 9474 RVA: 0x0014B856 File Offset: 0x00149A56
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005CB0 RID: 23728
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005CB1 RID: 23729
        public int life;

        // Token: 0x04005CB2 RID: 23730
        public uint flag;

        // Token: 0x04005CB3 RID: 23731
        public int obj_create_cnt;

        // Token: 0x04005CB4 RID: 23732
        public AppMain.GMS_BOSS1_BODY_WORK body_work;
    }

    // Token: 0x020002EE RID: 750
    public class GMS_BOSS1_BODY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002503 RID: 9475 RVA: 0x0014B868 File Offset: 0x00149A68
        public GMS_BOSS1_BODY_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002504 RID: 9476 RVA: 0x0014B8ED File Offset: 0x00149AED
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002505 RID: 9477 RVA: 0x0014B8FF File Offset: 0x00149AFF
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_BOSS1_BODY_WORK p )
        {
            return p.ene_3d.ene_com;
        }

        // Token: 0x04005CB5 RID: 23733
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005CB6 RID: 23734
        public int state;

        // Token: 0x04005CB7 RID: 23735
        public int prev_state;

        // Token: 0x04005CB8 RID: 23736
        public AppMain.GMS_BOSS1_MGR_WORK mgr_work;

        // Token: 0x04005CB9 RID: 23737
        public AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK proc_update;

        // Token: 0x04005CBA RID: 23738
        public uint flag;

        // Token: 0x04005CBB RID: 23739
        public int whole_act_id;

        // Token: 0x04005CBC RID: 23740
        public ushort egg_revert_mtn_id;

        // Token: 0x04005CBD RID: 23741
        public readonly ushort[] reserved = new ushort[1];

        // Token: 0x04005CBE RID: 23742
        public uint wait_timer;

        // Token: 0x04005CBF RID: 23743
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04005CC0 RID: 23744
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04005CC1 RID: 23745
        public int chain_snm_reg_id;

        // Token: 0x04005CC2 RID: 23746
        public int egg_snm_reg_id;

        // Token: 0x04005CC3 RID: 23747
        public int body_snm_reg_id;

        // Token: 0x04005CC4 RID: 23748
        public int chaintop_snm_reg_id;

        // Token: 0x04005CC5 RID: 23749
        public readonly AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work = new AppMain.GMS_BS_CMN_CNM_MGR_WORK();

        // Token: 0x04005CC6 RID: 23750
        public int chaintop_cnm_reg_id;

        // Token: 0x04005CC7 RID: 23751
        public readonly AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work = new AppMain.GMS_BS_CMN_DMG_FLICKER_WORK();

        // Token: 0x04005CC8 RID: 23752
        public readonly AppMain.GMS_BOSS1_1SHOT_TIMER se_timer = new AppMain.GMS_BOSS1_1SHOT_TIMER();

        // Token: 0x04005CC9 RID: 23753
        public uint se_cnt;

        // Token: 0x04005CCA RID: 23754
        public uint no_hit_timer;

        // Token: 0x04005CCB RID: 23755
        public int move_time;

        // Token: 0x04005CCC RID: 23756
        public int move_cnt;

        // Token: 0x04005CCD RID: 23757
        public short cur_angle;

        // Token: 0x04005CCE RID: 23758
        public short orig_angle;

        // Token: 0x04005CCF RID: 23759
        public int turn_angle;

        // Token: 0x04005CD0 RID: 23760
        public int turn_amount;

        // Token: 0x04005CD1 RID: 23761
        public int turn_spd;

        // Token: 0x04005CD2 RID: 23762
        public int turn_gen_var;

        // Token: 0x04005CD3 RID: 23763
        public int turn_gen_factor;

        // Token: 0x04005CD4 RID: 23764
        public int drift_pivot_x;

        // Token: 0x04005CD5 RID: 23765
        public int drift_angle;

        // Token: 0x04005CD6 RID: 23766
        public int drift_ang_spd;

        // Token: 0x04005CD7 RID: 23767
        public int drift_timer;

        // Token: 0x04005CD8 RID: 23768
        public int atk_nml_alt;

        // Token: 0x04005CD9 RID: 23769
        public AppMain.VecFx32 bash_targ_pos;

        // Token: 0x04005CDA RID: 23770
        public AppMain.VecFx32 bash_ret_pos;

        // Token: 0x04005CDB RID: 23771
        public AppMain.VecFx32 bash_orig_pos;

        // Token: 0x04005CDC RID: 23772
        public int bash_homing_deg;

        // Token: 0x04005CDD RID: 23773
        public readonly AppMain.GMS_BOSS1_EFF_BOMB_WORK bomb_work = new AppMain.GMS_BOSS1_EFF_BOMB_WORK();

        // Token: 0x04005CDE RID: 23774
        public readonly AppMain.OBS_OBJECT_WORK[] parts_objs = new AppMain.OBS_OBJECT_WORK[3];

        // Token: 0x04005CDF RID: 23775
        public readonly AppMain.GMS_BOSS1_MTN_SUSPEND_WORK[] mtn_suspend = AppMain.New<AppMain.GMS_BOSS1_MTN_SUSPEND_WORK>(3);
    }

    // Token: 0x020002EF RID: 751
    public class GMS_BOSS1_CHAIN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002506 RID: 9478 RVA: 0x0014B90C File Offset: 0x00149B0C
        public GMS_BOSS1_CHAIN_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002507 RID: 9479 RVA: 0x0014B966 File Offset: 0x00149B66
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005CE0 RID: 23776
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005CE1 RID: 23777
        public AppMain.GMS_BOSS1_MGR_WORK mgr_work;

        // Token: 0x04005CE2 RID: 23778
        public uint flag;

        // Token: 0x04005CE3 RID: 23779
        public AppMain.MPP_VOID_GMS_BOSS1_CHAIN_WORK proc_update;

        // Token: 0x04005CE4 RID: 23780
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04005CE5 RID: 23781
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04005CE6 RID: 23782
        public int ball_snm_reg_id;

        // Token: 0x04005CE7 RID: 23783
        public readonly int[] sct_snm_reg_ids = new int[9];

        // Token: 0x04005CE8 RID: 23784
        public readonly AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work = new AppMain.GMS_BS_CMN_CNM_MGR_WORK();

        // Token: 0x04005CE9 RID: 23785
        public readonly int[] sct_cnm_reg_ids = new int[9];
    }

    // Token: 0x020002F0 RID: 752
    public class GMS_BOSS1_EGG_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002508 RID: 9480 RVA: 0x0014B978 File Offset: 0x00149B78
        public GMS_BOSS1_EGG_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002509 RID: 9481 RVA: 0x0014B98C File Offset: 0x00149B8C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005CEA RID: 23786
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005CEB RID: 23787
        public AppMain.GMS_BOSS1_MGR_WORK mgr_work;

        // Token: 0x04005CEC RID: 23788
        public uint flag;

        // Token: 0x04005CED RID: 23789
        public int egg_act_id;

        // Token: 0x04005CEE RID: 23790
        public AppMain.MPP_VOID_GMS_BOSS1_EGG_WORK proc_update;
    }

    // Token: 0x020002F1 RID: 753
    public class GMS_BOSS1_PART_ACT_INFO
    {
        // Token: 0x0600250A RID: 9482 RVA: 0x0014B9A0 File Offset: 0x00149BA0
        public GMS_BOSS1_PART_ACT_INFO( ushort _act_id, bool _is_maintain, bool _is_repeat, float _mtn_spd, bool _is_blend, float _blend_spd, bool _is_merge_manual )
        {
            this.act_id = _act_id;
            this.is_maintain = ( byte )( _is_maintain ? 1 : 0 );
            this.is_repeat = ( byte )( _is_repeat ? 1 : 0 );
            this.mtn_spd = _mtn_spd;
            this.is_blend = _is_blend;
            this.blend_spd = _blend_spd;
            this.is_merge_manual = _is_merge_manual;
        }

        // Token: 0x04005CEF RID: 23791
        public ushort act_id;

        // Token: 0x04005CF0 RID: 23792
        public byte is_maintain;

        // Token: 0x04005CF1 RID: 23793
        public byte is_repeat;

        // Token: 0x04005CF2 RID: 23794
        public float mtn_spd;

        // Token: 0x04005CF3 RID: 23795
        public bool is_blend;

        // Token: 0x04005CF4 RID: 23796
        public float blend_spd;

        // Token: 0x04005CF5 RID: 23797
        public bool is_merge_manual;
    }

    // Token: 0x020002F2 RID: 754
    public class GMS_BOSS1_EFF_SHOCKWAVE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600250B RID: 9483 RVA: 0x0014B9F4 File Offset: 0x00149BF4
        public GMS_BOSS1_EFF_SHOCKWAVE_WORK()
        {
            this.eff_3des = new AppMain.GMS_EFFECT_3DES_WORK( this );
        }

        // Token: 0x0600250C RID: 9484 RVA: 0x0014BA08 File Offset: 0x00149C08
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_3des.efct_com.obj_work;
        }

        // Token: 0x04005CF6 RID: 23798
        public readonly AppMain.GMS_EFFECT_3DES_WORK eff_3des;

        // Token: 0x04005CF7 RID: 23799
        public AppMain.GMS_BOSS1_MGR_WORK mgr_work;

        // Token: 0x04005CF8 RID: 23800
        public uint atk_rect_timer;
    }

    // Token: 0x020002F3 RID: 755
    public class GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600250D RID: 9485 RVA: 0x0014BA1A File Offset: 0x00149C1A
        public GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK()
        {
            this.eff_3des = new AppMain.GMS_EFFECT_3DES_WORK( this );
        }

        // Token: 0x0600250E RID: 9486 RVA: 0x0014BA2E File Offset: 0x00149C2E
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_3des.efct_com.obj_work;
        }

        // Token: 0x04005CF9 RID: 23801
        public readonly AppMain.GMS_EFFECT_3DES_WORK eff_3des;

        // Token: 0x04005CFA RID: 23802
        public AppMain.GMS_BOSS1_MGR_WORK mgr_work;
    }

    // Token: 0x020002F4 RID: 756
    public class GMS_BOSS1_EFF_SCT_PART_NDC_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600250F RID: 9487 RVA: 0x0014BA40 File Offset: 0x00149C40
        public GMS_BOSS1_EFF_SCT_PART_NDC_WORK()
        {
            this.ncd_obj = new AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( this );
        }

        // Token: 0x06002510 RID: 9488 RVA: 0x0014BA5F File Offset: 0x00149C5F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ncd_obj.efct_com.obj_work;
        }

        // Token: 0x06002511 RID: 9489 RVA: 0x0014BA71 File Offset: 0x00149C71
        public static explicit operator AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK work )
        {
            return work.ncd_obj;
        }

        // Token: 0x04005CFB RID: 23803
        public readonly AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT ncd_obj = new AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT();

        // Token: 0x04005CFC RID: 23804
        public AppMain.NNS_QUATERNION spin_quat;

        // Token: 0x04005CFD RID: 23805
        public bool is_ironball;
    }

    // Token: 0x020002F5 RID: 757
    public class GMS_BOSS1_FLASH_SCREEN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002512 RID: 9490 RVA: 0x0014BA79 File Offset: 0x00149C79
        public GMS_BOSS1_FLASH_SCREEN_WORK()
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
        }

        // Token: 0x06002513 RID: 9491 RVA: 0x0014BAA3 File Offset: 0x00149CA3
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_com.obj_work;
        }

        // Token: 0x04005CFE RID: 23806
        public readonly AppMain.GMS_EFFECT_COM_WORK efct_com = new AppMain.GMS_EFFECT_COM_WORK();

        // Token: 0x04005CFF RID: 23807
        public readonly AppMain.GMS_CMN_FLASH_SCR_WORK flash_work = new AppMain.GMS_CMN_FLASH_SCR_WORK();
    }

    // Token: 0x020002F6 RID: 758
    // (Invoke) Token: 0x06002515 RID: 9493
    public delegate void GMF_BOSS1_BODY_STATE_ENTER_FUNC( AppMain.GMS_BOSS1_BODY_WORK work );

    // Token: 0x020002F7 RID: 759
    // (Invoke) Token: 0x06002519 RID: 9497
    public delegate void GMF_BOSS1_BODY_STATE_LEAVE_FUNC( AppMain.GMS_BOSS1_BODY_WORK work );

    // Token: 0x020002F8 RID: 760
    public class GMS_BOSS1_BODY_STATE_ENTER_INFO
    {
        // Token: 0x0600251C RID: 9500 RVA: 0x0014BAB0 File Offset: 0x00149CB0
        public GMS_BOSS1_BODY_STATE_ENTER_INFO( AppMain.GMF_BOSS1_BODY_STATE_ENTER_FUNC _enter_func, bool _is_wrapped )
        {
            this.enter_func = _enter_func;
            this.is_wrapped = _is_wrapped;
        }

        // Token: 0x04005D00 RID: 23808
        public AppMain.GMF_BOSS1_BODY_STATE_ENTER_FUNC enter_func;

        // Token: 0x04005D01 RID: 23809
        public bool is_wrapped;
    }

    // Token: 0x17000045 RID: 69
    // (get) Token: 0x06001476 RID: 5238 RVA: 0x000B4669 File Offset: 0x000B2869
    public static AppMain.AMS_AMB_HEADER GMD_BOSS1_ARC
    {
        get
        {
            return AppMain.g_gm_gamedat_enemy_arc;
        }
    }

    // Token: 0x06001477 RID: 5239 RVA: 0x000B4670 File Offset: 0x000B2870
    public static int GMM_BOSS1_STAGE_MAP_POS_OFST_Y()
    {
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() != 4 )
        {
            return 0;
        }
        return 14155776;
    }

    // Token: 0x17000046 RID: 70
    // (get) Token: 0x06001478 RID: 5240 RVA: 0x000B4681 File Offset: 0x000B2881
    public static int GMD_BOSS1_GROUND_POS_Y
    {
        get
        {
            return 1286144 + AppMain.GMM_BOSS1_STAGE_MAP_POS_OFST_Y();
        }
    }

    // Token: 0x17000047 RID: 71
    // (get) Token: 0x06001479 RID: 5241 RVA: 0x000B468E File Offset: 0x000B288E
    public static int GMD_BOSS1_BODY_DEFAULT_ALTITUDE
    {
        get
        {
            return 712704 + AppMain.GMM_BOSS1_STAGE_MAP_POS_OFST_Y();
        }
    }

    // Token: 0x17000048 RID: 72
    // (get) Token: 0x0600147A RID: 5242 RVA: 0x000B469B File Offset: 0x000B289B
    public static int GMD_BOSS1_BODY_START_POS_Y
    {
        get
        {
            return -245760 + AppMain.GMM_BOSS1_STAGE_MAP_POS_OFST_Y();
        }
    }

    // Token: 0x17000049 RID: 73
    // (get) Token: 0x0600147B RID: 5243 RVA: 0x000B46A8 File Offset: 0x000B28A8
    public static int GMD_BOSS1_BODY_ATKBASH_TARG_Y
    {
        get
        {
            return AppMain.GMD_BOSS1_GROUND_POS_Y - 360448;
        }
    }

    // Token: 0x0600147C RID: 5244 RVA: 0x000B46B5 File Offset: 0x000B28B5
    public static AppMain.GMS_BOSS1_MGR_WORK GMM_BOSS1_MGR( AppMain.GMS_BOSS1_BODY_WORK work )
    {
        return work.mgr_work;
    }

    // Token: 0x0600147D RID: 5245 RVA: 0x000B46BD File Offset: 0x000B28BD
    public static int GMM_BOSS1_AREA_LEFT()
    {
        return AppMain.g_gm_main_system.map_fcol.left << 12;
    }

    // Token: 0x0600147E RID: 5246 RVA: 0x000B46D1 File Offset: 0x000B28D1
    public static int GMM_BOSS1_AREA_TOP()
    {
        return AppMain.g_gm_main_system.map_fcol.top << 12;
    }

    // Token: 0x0600147F RID: 5247 RVA: 0x000B46E5 File Offset: 0x000B28E5
    public static int GMM_BOSS1_AREA_RIGHT()
    {
        return AppMain.g_gm_main_system.map_fcol.right << 12;
    }

    // Token: 0x06001480 RID: 5248 RVA: 0x000B46F9 File Offset: 0x000B28F9
    public static int GMM_BOSS1_AREA_BOTTOM()
    {
        return AppMain.g_gm_main_system.map_fcol.bottom << 12;
    }

    // Token: 0x06001481 RID: 5249 RVA: 0x000B470D File Offset: 0x000B290D
    public static int GMM_BOSS1_AREA_CENTER_X()
    {
        return AppMain.GMM_BOSS1_AREA_LEFT() + ( AppMain.GMM_BOSS1_AREA_RIGHT() - AppMain.GMM_BOSS1_AREA_LEFT() ) / 2;
    }

    // Token: 0x06001482 RID: 5250 RVA: 0x000B4722 File Offset: 0x000B2922
    public static int GMM_BOSS1_AREA_CENTER_Y()
    {
        return AppMain.GMM_BOSS1_AREA_TOP() + ( AppMain.GMM_BOSS1_AREA_BOTTOM() - AppMain.GMM_BOSS1_AREA_TOP() ) / 2;
    }

    // Token: 0x06001483 RID: 5251 RVA: 0x000B4737 File Offset: 0x000B2937
    public static AppMain.OBS_OBJECT_WORK GMM_BS_OBJ( object obj )
    {
        if ( obj is AppMain.IOBS_OBJECT_WORK )
        {
            return ( ( AppMain.IOBS_OBJECT_WORK )obj ).Cast();
        }
        return ( AppMain.OBS_OBJECT_WORK )obj;
    }

    // Token: 0x06001484 RID: 5252 RVA: 0x000B4754 File Offset: 0x000B2954
    private static void GmBoss1Build()
    {
        object obj = AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.GMD_BOSS1_ARC);
        object obj2 = AppMain.ObjDataLoadAmbIndex(null, 1, AppMain.GMD_BOSS1_ARC);
        AppMain.gm_boss1_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( ( AppMain.AMS_AMB_HEADER )obj, ( AppMain.AMS_AMB_HEADER )obj2, 0U );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 703 ), 2, AppMain.GMD_BOSS1_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 704 ), 3, AppMain.GMD_BOSS1_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 705 ), 4, AppMain.GMD_BOSS1_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 706 ), 5, AppMain.GMD_BOSS1_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 707 ), 6, AppMain.GMD_BOSS1_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 708 ), 7, AppMain.GMD_BOSS1_ARC );
        AppMain.GmEfctBossBuildSingleDataReg( 8, AppMain.ObjDataGet( 709 ), AppMain.ObjDataGet( 710 ), 0, null, null, AppMain.GMD_BOSS1_ARC );
        AppMain.GmEfctBossBuildSingleDataReg( 8, AppMain.ObjDataGet( 709 ), AppMain.ObjDataGet( 710 ), 0, null, null, AppMain.GMD_BOSS1_ARC );
        AppMain.GmEfctBossBuildSingleDataReg( 8, AppMain.ObjDataGet( 709 ), AppMain.ObjDataGet( 710 ), 0, null, null, AppMain.GMD_BOSS1_ARC );
    }

    // Token: 0x06001485 RID: 5253 RVA: 0x000B487C File Offset: 0x000B2A7C
    private static void GmBoss1Flush()
    {
        AppMain.GmEfctBossFlushSingleDataInit();
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 708 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 707 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 706 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 705 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 704 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 703 ) );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.GMD_BOSS1_ARC);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_boss1_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_boss1_obj_3d_list = null;
    }

    // Token: 0x06001486 RID: 5254 RVA: 0x000B4918 File Offset: 0x000B2B18
    private static AppMain.OBS_OBJECT_WORK GmBoss1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS1_MGR_WORK(), "BOSS1_MGR");
        AppMain.GMS_BOSS1_MGR_WORK gms_BOSS1_MGR_WORK = (AppMain.GMS_BOSS1_MGR_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            gms_BOSS1_MGR_WORK.life = 4;
        }
        else
        {
            gms_BOSS1_MGR_WORK.life = 8;
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1MgrWaitLoad );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001487 RID: 5255 RVA: 0x000B49C4 File Offset: 0x000B2BC4
    private static AppMain.OBS_OBJECT_WORK GmBoss1BodyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS1_BODY_WORK(), "BOSS1_BODY");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.pos.y = AppMain.GMD_BOSS1_BODY_START_POS_Y;
        obs_OBJECT_WORK.pos.z = 0;
        gms_BOSS1_BODY_WORK.atk_nml_alt = AppMain.GMD_BOSS1_BODY_DEFAULT_ALTITUDE;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194309U;
        obs_OBJECT_WORK.move_flag |= 4096U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        gms_ENEMY_3D_WORK.ene_com.vit = 1;
        AppMain.gmBoss1BodySetDmgRectSizeToDefault( gms_BOSS1_BODY_WORK );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss1BodyDamageDefFunc );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag |= 2048U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_boss1_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 703 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.125f;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1BodyWaitSetup );
        AppMain.gmBoss1BodyChangeState( gms_BOSS1_BODY_WORK, 0 );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1BodyOutFunc );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss1BodyExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001488 RID: 5256 RVA: 0x000B4BA8 File Offset: 0x000B2DA8
    private static AppMain.OBS_OBJECT_WORK GmBoss1ChainInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS1_CHAIN_WORK(), "BOSS1_CHAIN");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 256U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_boss1_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 704 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.125f;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1ChainWaitSetup );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[1], -16, -16, 16, 16 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss1ChainAtkHitFunc );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag |= 2048U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag |= 2048U;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1ChainOutFunc );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss1ChainExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001489 RID: 5257 RVA: 0x000B4D60 File Offset: 0x000B2F60
    private static AppMain.OBS_OBJECT_WORK GmBoss1EggInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS1_EGG_WORK(), "BOSS1_EGG");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 256U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_boss1_obj_3d_list[2], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 705 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.125f;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EggWaitSetup );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss1EggExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600148A RID: 5258 RVA: 0x000B4EAC File Offset: 0x000B30AC
    private static void gmBoss1SetPartTextureBurnt( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3d );
        AppMain.MTM_ASSERT( obj_work.disp_flag & 134217728U );
        obj_work.obj_3d.drawflag |= 268435456U;
        obj_work.obj_3d.draw_state.texoffset[0].mode = 2;
        obj_work.obj_3d.draw_state.texoffset[0].u = 0.5f;
    }

    // Token: 0x0600148B RID: 5259 RVA: 0x000B4F26 File Offset: 0x000B3126
    private static bool gmBoss1IsScrollLockBusy()
    {
        return ( AppMain.g_gm_main_system.game_flag & 32768U ) != 0U;
    }

    // Token: 0x0600148C RID: 5260 RVA: 0x000B4F3D File Offset: 0x000B313D
    private static void gmBoss1Init1ShotTimer( AppMain.GMS_BOSS1_1SHOT_TIMER one_shot_timer, uint frame )
    {
        AppMain.MTM_ASSERT( one_shot_timer );
        one_shot_timer.timer = frame;
        one_shot_timer.is_active = true;
    }

    // Token: 0x0600148D RID: 5261 RVA: 0x000B4F53 File Offset: 0x000B3153
    private static bool gmBoss1Update1ShotTimer( AppMain.GMS_BOSS1_1SHOT_TIMER one_shot_timer )
    {
        AppMain.MTM_ASSERT( one_shot_timer );
        if ( !one_shot_timer.is_active )
        {
            return false;
        }
        if ( one_shot_timer.timer != 0U )
        {
            one_shot_timer.timer -= 1U;
            return false;
        }
        one_shot_timer.is_active = false;
        return true;
    }

    // Token: 0x0600148E RID: 5262 RVA: 0x000B4F87 File Offset: 0x000B3187
    private static void gmBoss1MgrIncObjCreateCount( AppMain.GMS_BOSS1_MGR_WORK mgr_work )
    {
        AppMain.MTM_ASSERT( mgr_work.obj_create_cnt >= 0 );
        mgr_work.obj_create_cnt++;
    }

    // Token: 0x0600148F RID: 5263 RVA: 0x000B4FA8 File Offset: 0x000B31A8
    private static void gmBoss1MgrDecObjCreateCount( AppMain.GMS_BOSS1_MGR_WORK mgr_work )
    {
        AppMain.MTM_ASSERT( mgr_work.obj_create_cnt > 0 );
        mgr_work.obj_create_cnt--;
    }

    // Token: 0x06001490 RID: 5264 RVA: 0x000B4FC6 File Offset: 0x000B31C6
    private static bool gmBoss1MgrIsAllCreatedObjDeleted( AppMain.GMS_BOSS1_MGR_WORK mgr_work )
    {
        AppMain.MTM_ASSERT( mgr_work.obj_create_cnt >= 0 );
        return mgr_work.obj_create_cnt <= 0;
    }

    // Token: 0x06001491 RID: 5265 RVA: 0x000B4FE8 File Offset: 0x000B31E8
    private static void gmBoss1MgrWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        bool flag = false;
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            if ( AppMain.GmMainDatLoadBossBattleLoadCheck( 0 ) )
            {
                flag = true;
            }
        }
        else
        {
            flag = true;
        }
        if ( flag )
        {
            AppMain.GMS_BOSS1_MGR_WORK gms_BOSS1_MGR_WORK = (AppMain.GMS_BOSS1_MGR_WORK)obj_work;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(313, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            AppMain.gmBoss1MgrIncObjCreateCount( gms_BOSS1_MGR_WORK );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(314, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            AppMain.gmBoss1MgrIncObjCreateCount( gms_BOSS1_MGR_WORK );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = AppMain.GmEventMgrLocalEventBirth(315, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            AppMain.gmBoss1MgrIncObjCreateCount( gms_BOSS1_MGR_WORK );
            AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obs_OBJECT_WORK;
            AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)obs_OBJECT_WORK2;
            AppMain.GMS_BOSS1_EGG_WORK gms_BOSS1_EGG_WORK = (AppMain.GMS_BOSS1_EGG_WORK)obs_OBJECT_WORK3;
            gms_BOSS1_MGR_WORK.body_work = gms_BOSS1_BODY_WORK;
            gms_BOSS1_BODY_WORK.mgr_work = gms_BOSS1_MGR_WORK;
            gms_BOSS1_CHAIN_WORK.mgr_work = gms_BOSS1_MGR_WORK;
            gms_BOSS1_EGG_WORK.mgr_work = gms_BOSS1_MGR_WORK;
            obs_OBJECT_WORK.parent_obj = obj_work;
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.parent_obj = obs_OBJECT_WORK;
            gms_BOSS1_BODY_WORK.parts_objs[0] = obs_OBJECT_WORK;
            gms_BOSS1_BODY_WORK.parts_objs[1] = obs_OBJECT_WORK2;
            gms_BOSS1_BODY_WORK.parts_objs[2] = obs_OBJECT_WORK3;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1MgrWaitSetup );
        }
    }

    // Token: 0x06001492 RID: 5266 RVA: 0x000B5124 File Offset: 0x000B3324
    private static void gmBoss1MgrWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_MGR_WORK gms_BOSS1_MGR_WORK = (AppMain.GMS_BOSS1_MGR_WORK)obj_work;
        AppMain.GMS_BOSS1_BODY_WORK body_work = gms_BOSS1_MGR_WORK.body_work;
        bool flag = true;
        for ( int i = 0; i < 3; i++ )
        {
            if ( body_work.parts_objs[i] == null )
            {
                flag = false;
            }
        }
        if ( flag )
        {
            gms_BOSS1_MGR_WORK.flag |= 1U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1MgrMain );
        }
    }

    // Token: 0x06001493 RID: 5267 RVA: 0x000B517C File Offset: 0x000B337C
    private static void gmBoss1MgrMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_MGR_WORK gms_BOSS1_MGR_WORK = (AppMain.GMS_BOSS1_MGR_WORK)obj_work;
        if ( ( gms_BOSS1_MGR_WORK.flag & 2U ) != 0U )
        {
            if ( gms_BOSS1_MGR_WORK.body_work != null )
            {
                AppMain.GMM_BS_OBJ( gms_BOSS1_MGR_WORK.body_work ).flag |= 8U;
                gms_BOSS1_MGR_WORK.body_work = null;
            }
            if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1MgrWaitRelease );
            }
        }
    }

    // Token: 0x06001494 RID: 5268 RVA: 0x000B51DC File Offset: 0x000B33DC
    private static void gmBoss1MgrWaitRelease( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_MGR_WORK mgr_work = (AppMain.GMS_BOSS1_MGR_WORK)obj_work;
        if ( AppMain.gmBoss1MgrIsAllCreatedObjDeleted( mgr_work ) )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
            obj_work.flag |= 4U;
            AppMain.GmGameDatReleaseBossBattleStart( 0 );
            AppMain.GmGmkCamScrLimitRelease( 14 );
        }
    }

    // Token: 0x06001495 RID: 5269 RVA: 0x000B5230 File Offset: 0x000B3430
    private static void gmBoss1BodyExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obs_OBJECT_WORK;
        AppMain.gmBoss1MgrDecObjCreateCount( gms_BOSS1_BODY_WORK.mgr_work );
        AppMain.GmBsCmnClearBossMotionCBSystem( obs_OBJECT_WORK );
        AppMain.GmBsCmnDeleteSNMWork( gms_BOSS1_BODY_WORK.snm_work );
        AppMain.GmBsCmnClearCNMCb( obs_OBJECT_WORK );
        AppMain.GmBsCmnDeleteCNMMgrWork( gms_BOSS1_BODY_WORK.cnm_mgr_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06001496 RID: 5270 RVA: 0x000B527E File Offset: 0x000B347E
    private static void gmBoss1BodySetActionWhole( AppMain.GMS_BOSS1_BODY_WORK body_work, int act_id )
    {
        AppMain.gmBoss1BodySetActionWhole( body_work, act_id, false );
    }

    // Token: 0x06001497 RID: 5271 RVA: 0x000B5288 File Offset: 0x000B3488
    private static void gmBoss1BodySetActionWhole( AppMain.GMS_BOSS1_BODY_WORK body_work, int act_id, bool force_change )
    {
        AppMain.GMS_BOSS1_PART_ACT_INFO[] array = AppMain.gm_boss1_act_id_tbl[act_id];
        if ( !force_change && body_work.whole_act_id == act_id )
        {
            return;
        }
        body_work.whole_act_id = act_id;
        for ( int i = 0; i < 3; i++ )
        {
            if ( body_work.parts_objs[i] != null )
            {
                if ( i == 2 )
                {
                    AppMain.GMS_BOSS1_EGG_WORK gms_BOSS1_EGG_WORK = (AppMain.GMS_BOSS1_EGG_WORK)body_work.parts_objs[i];
                    body_work.egg_revert_mtn_id = array[i].act_id;
                    if ( ( gms_BOSS1_EGG_WORK.flag & 1U ) != 0U )
                    {
                        goto IL_136;
                    }
                }
                if ( array[i].is_maintain == 0 )
                {
                    AppMain.GmBsCmnSetAction( body_work.parts_objs[i], ( int )array[i].act_id, ( int )array[i].is_repeat, array[i].is_blend ? 1 : 0 );
                }
                else if ( array[i].is_repeat != 0 )
                {
                    AppMain.GMM_BS_OBJ( body_work ).disp_flag |= 4U;
                }
                if ( array[i].is_blend && array[i].is_merge_manual )
                {
                    if ( i == 1 )
                    {
                        AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)body_work.parts_objs[1];
                        gms_BOSS1_CHAIN_WORK.flag |= 1U;
                        AppMain.GMM_BS_OBJ( gms_BOSS1_CHAIN_WORK ).disp_flag |= 4U;
                    }
                    else
                    {
                        AppMain.MTM_ASSERT( false );
                    }
                }
                body_work.parts_objs[i].obj_3d.speed[0] = array[i].mtn_spd;
                body_work.parts_objs[i].obj_3d.blend_spd = array[i].blend_spd;
            }
            IL_136:;
        }
    }

    // Token: 0x06001498 RID: 5272 RVA: 0x000B53D8 File Offset: 0x000B35D8
    private static void gmBoss1BodySetSuspendAction( AppMain.GMS_BOSS1_BODY_WORK body_work, int part_idx, uint suspend_time )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = body_work.parts_objs[part_idx].obj_3d;
        AppMain.MTM_ASSERT( part_idx == 1 );
        obj_3d.speed[0] = 0f;
        body_work.mtn_suspend[part_idx].is_suspended = true;
        body_work.mtn_suspend[part_idx].suspend_timer = suspend_time;
    }

    // Token: 0x06001499 RID: 5273 RVA: 0x000B5428 File Offset: 0x000B3628
    private static void gmBoss1BodyUpdateSuspendAction( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.GMS_BOSS1_MTN_SUSPEND_WORK gms_BOSS1_MTN_SUSPEND_WORK = body_work.mtn_suspend[i];
            if ( gms_BOSS1_MTN_SUSPEND_WORK.is_suspended )
            {
                AppMain.MTM_ASSERT( i == 1 );
                if ( gms_BOSS1_MTN_SUSPEND_WORK.suspend_timer != 0U )
                {
                    gms_BOSS1_MTN_SUSPEND_WORK.suspend_timer -= 1U;
                }
                else
                {
                    body_work.parts_objs[i].obj_3d.speed[0] = AppMain.gm_boss1_act_id_tbl[body_work.whole_act_id][i].mtn_spd;
                    gms_BOSS1_MTN_SUSPEND_WORK.is_suspended = false;
                }
            }
        }
    }

    // Token: 0x0600149A RID: 5274 RVA: 0x000B54A4 File Offset: 0x000B36A4
    private static bool gmBoss1BodyCheckChainMotionMergeEnd( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)body_work.parts_objs[1];
        return ( gms_BOSS1_CHAIN_WORK.flag & 1U ) == 0U;
    }

    // Token: 0x0600149B RID: 5275 RVA: 0x000B54CC File Offset: 0x000B36CC
    private static void gmBoss1BodySetNoHitTime( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)body_work;
        body_work.no_hit_timer = 10U;
        gms_ENEMY_COM_WORK.rect_work[0].flag |= 2048U;
    }

    // Token: 0x0600149C RID: 5276 RVA: 0x000B5504 File Offset: 0x000B3704
    private static void gmBoss1BodyUpdateNoHitTime( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( body_work.no_hit_timer != 0U )
        {
            body_work.no_hit_timer -= 1U;
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)body_work;
        gms_ENEMY_COM_WORK.rect_work[0].flag &= 4294965247U;
    }

    // Token: 0x0600149D RID: 5277 RVA: 0x000B5548 File Offset: 0x000B3748
    private static void gmBoss1BodyExecDamageRoutine( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS1_MGR_WORK mgr_work = body_work.mgr_work;
        AppMain.MTM_ASSERT( mgr_work );
        if ( mgr_work.life != 0 )
        {
            mgr_work.life--;
        }
        if ( 0 < mgr_work.life )
        {
            body_work.flag |= 1073741824U;
            return;
        }
        body_work.flag |= 2147483648U;
        AppMain.GMM_BS_OBJ( body_work ).flag |= 2U;
    }

    // Token: 0x0600149E RID: 5278 RVA: 0x000B55BC File Offset: 0x000B37BC
    private static void gmBoss1BodySetDmgRectSizeForAtkNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)body_work;
        AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[0], -24, -24, 24, 16 );
    }

    // Token: 0x0600149F RID: 5279 RVA: 0x000B55E8 File Offset: 0x000B37E8
    private static void gmBoss1BodySetDmgRectSizeToDefault( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)body_work;
        AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[0], -24, -24, 24, 24 );
    }

    // Token: 0x060014A0 RID: 5280 RVA: 0x000B5614 File Offset: 0x000B3814
    private static void gmBoss1BodySetAtkRectToWeakAttacker( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)body_work;
        AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[1], -16, -16, 16, 16 );
        gms_ENEMY_COM_WORK.rect_work[1].flag &= 4294965247U;
    }

    // Token: 0x060014A1 RID: 5281 RVA: 0x000B5658 File Offset: 0x000B3858
    private static void gmBoss1BodySetAtkRectToNormal( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)body_work;
        AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[1], 0, 0, 0, 0 );
        gms_ENEMY_COM_WORK.rect_work[1].flag |= 2048U;
    }

    // Token: 0x060014A2 RID: 5282 RVA: 0x000B5697 File Offset: 0x000B3897
    private static bool gmBoss1BodyIsExtraAttack( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        return AppMain.GMM_BOSS1_MGR( body_work ).life <= 3;
    }

    // Token: 0x060014A3 RID: 5283 RVA: 0x000B56AA File Offset: 0x000B38AA
    private static bool gmBoss1BodyIsEscapeScrUnlock( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        return AppMain.GMM_BS_OBJ( body_work ).pos.x >= AppMain.GMM_BOSS1_AREA_RIGHT() + -131072;
    }

    // Token: 0x060014A4 RID: 5284 RVA: 0x000B56CC File Offset: 0x000B38CC
    private static bool gmBoss1BodyIsEscapeOutFinalZone( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        return AppMain.GMM_BS_OBJ( body_work ).pos.x >= AppMain.GMM_BOSS1_AREA_RIGHT() + 393216;
    }

    // Token: 0x060014A5 RID: 5285 RVA: 0x000B56F0 File Offset: 0x000B38F0
    private static bool gmBoss1BodyIsDirectionPositiveFromCurrent( AppMain.GMS_BOSS1_BODY_WORK body_work, short target_angle )
    {
        int num = (int)(65535L & (long)(body_work.cur_angle - target_angle));
        return num >= AppMain.AKM_DEGtoA32( 180 );
    }

    // Token: 0x060014A6 RID: 5286 RVA: 0x000B5720 File Offset: 0x000B3920
    private static void gmBoss1BodyUpdateDirection( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.dir.y = ( ushort )body_work.cur_angle;
    }

    // Token: 0x060014A7 RID: 5287 RVA: 0x000B5748 File Offset: 0x000B3948
    private static void gmBoss1BodySetDirectionNormal( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss1BodySetDirection( body_work, AppMain.GMD_BOSS1_LEFTWARD_ANGLE );
        }
        else
        {
            AppMain.gmBoss1BodySetDirection( body_work, AppMain.GMD_BOSS1_RIGHTWARD_ANGLE );
        }
        body_work.orig_angle = 0;
        body_work.turn_angle = 0;
    }

    // Token: 0x060014A8 RID: 5288 RVA: 0x000B578C File Offset: 0x000B398C
    private static void gmBoss1BodySetDirection( AppMain.GMS_BOSS1_BODY_WORK body_work, short deg )
    {
        body_work.cur_angle = deg;
    }

    // Token: 0x060014A9 RID: 5289 RVA: 0x000B5798 File Offset: 0x000B3998
    private static void gmBoss1BodyInitTurnGently( AppMain.GMS_BOSS1_BODY_WORK body_work, short dest_angle, int frame, bool is_positive )
    {
        AppMain.MTM_ASSERT( frame > 0 );
        body_work.orig_angle = body_work.cur_angle;
        body_work.turn_angle = 0;
        body_work.turn_spd = 0;
        if ( is_positive )
        {
            ushort num = (ushort)(dest_angle - body_work.cur_angle);
            body_work.turn_amount = ( int )num;
        }
        else
        {
            ushort num = (ushort)((int)dest_angle - AppMain.AKM_DEGtoA32(360) - ((int)body_work.cur_angle - AppMain.AKM_DEGtoA32(360)));
            body_work.turn_amount = ( int )num - AppMain.AKM_DEGtoA32( 360 );
        }
        body_work.turn_gen_var = 0;
        float num2 = 180f / (float)frame;
        AppMain.MTM_ASSERT( AppMain.MTM_MATH_ABS( num2 ) <= 2.1474836E+09f );
        body_work.turn_gen_factor = AppMain.AKM_DEGtoA32( num2 );
        AppMain.gmBoss1BodySetDirection( body_work, ( short )( ( int )body_work.orig_angle + body_work.turn_angle ) );
    }

    // Token: 0x060014AA RID: 5290 RVA: 0x000B5858 File Offset: 0x000B3A58
    private static bool gmBoss1BodyUpdateTurnGently( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        bool flag = false;
        AppMain.MTM_ASSERT( body_work.turn_gen_factor > 0 );
        body_work.turn_gen_var += body_work.turn_gen_factor;
        if ( body_work.turn_gen_var >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            body_work.turn_gen_var = AppMain.AKM_DEGtoA32( 180 );
            flag = true;
        }
        float num = (float)body_work.turn_amount * 0.5f * (1f - AppMain.nnCos(body_work.turn_gen_var));
        AppMain.MTM_ASSERT( AppMain.MTM_MATH_ABS( num ) <= 2.1474836E+09f );
        body_work.turn_angle = ( int )num;
        if ( flag )
        {
            body_work.turn_angle = body_work.turn_amount;
        }
        AppMain.gmBoss1BodySetDirection( body_work, ( short )( ( int )body_work.orig_angle + body_work.turn_angle ) );
        return flag;
    }

    // Token: 0x060014AB RID: 5291 RVA: 0x000B5910 File Offset: 0x000B3B10
    private static void gmBoss1BodyInitPreANChainMotion( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.MTM_ASSERT( body_work.parts_objs[1] );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = body_work.parts_objs[1];
        obs_OBJECT_WORK.obj_3d.frame[0] = 160f;
    }

    // Token: 0x060014AC RID: 5292 RVA: 0x000B5948 File Offset: 0x000B3B48
    private static void gmBoss1BodyInitPreANMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.spd.x = 0;
        obs_OBJECT_WORK.spd_add.x = -81;
    }

    // Token: 0x060014AD RID: 5293 RVA: 0x000B5978 File Offset: 0x000B3B78
    private static bool gmBoss1BodyUpdatePreANMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool flag = false;
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) >= 7372 )
        {
            obs_OBJECT_WORK.spd.x = -7372;
            obs_OBJECT_WORK.spd_add.x = 0;
        }
        if ( obs_OBJECT_WORK.pos.x <= AppMain.GMM_BOSS1_AREA_LEFT() + 589824 )
        {
            obs_OBJECT_WORK.pos.x = AppMain.GMM_BOSS1_AREA_LEFT() + 589824;
            flag = true;
        }
        if ( flag )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        }
        return flag;
    }

    // Token: 0x060014AE RID: 5294 RVA: 0x000B59FC File Offset: 0x000B3BFC
    private static void gmBoss1BodySetANChainInitialBlendSpd( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.MTM_ASSERT( body_work.parts_objs[1] );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = body_work.parts_objs[1];
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.01f;
    }

    // Token: 0x060014AF RID: 5295 RVA: 0x000B5A2F File Offset: 0x000B3C2F
    private static void gmBoss1BodyInitAtkNmlMove( AppMain.GMS_BOSS1_BODY_WORK body_work, int frame )
    {
        body_work.move_time = frame;
        body_work.move_cnt = 0;
        AppMain.gmBoss1BodyUpdateAtkNmlMove( body_work );
    }

    // Token: 0x060014B0 RID: 5296 RVA: 0x000B5A48 File Offset: 0x000B3C48
    private static bool gmBoss1BodyUpdateAtkNmlMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.GMM_BOSS1_AREA_LEFT() + 589824;
        int num2 = AppMain.GMM_BOSS1_AREA_LEFT() + 983040;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            int num3 = num;
            num = num2;
            num2 = num3;
        }
        bool result;
        if ( body_work.move_cnt < body_work.move_time )
        {
            int gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH = AppMain.GMD_BOSS1_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH;
            int gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_START_ANGLE = AppMain.GMD_BOSS1_BODY_ATKNML_MOVE_CURVE_START_ANGLE;
            body_work.move_cnt++;
            int num4 = (int)((float)gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH / (float)body_work.move_time);
            float num5 = AppMain.nnCos(gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_START_ANGLE) - AppMain.nnCos(gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_START_ANGLE + gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH);
            float num6 = (AppMain.nnCos(gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_START_ANGLE) - AppMain.nnCos(gmd_BOSS1_BODY_ATKNML_MOVE_CURVE_START_ANGLE + num4 * body_work.move_cnt)) / num5;
            obs_OBJECT_WORK.pos.x = num + ( int )( ( float )( num2 - num ) * num6 );
            result = false;
        }
        else
        {
            obs_OBJECT_WORK.pos.x = num2;
            result = true;
        }
        return result;
    }

    // Token: 0x060014B1 RID: 5297 RVA: 0x000B5B18 File Offset: 0x000B3D18
    private static void gmBoss1BodySetFlipForAtkNmlMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.GMM_BOSS1_AREA_CENTER_X();
        if ( obs_OBJECT_WORK.pos.x < num )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967294U;
            return;
        }
        obs_OBJECT_WORK.disp_flag |= 1U;
    }

    // Token: 0x060014B2 RID: 5298 RVA: 0x000B5B60 File Offset: 0x000B3D60
    private static void gmBoss1BodyInitAtkNmlFlipAndTurn( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = 40;
        AppMain.MTM_ASSERT( num < 72 );
        AppMain.gmBoss1BodySetFlipForAtkNmlMove( body_work );
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.GMD_BOSS1_LEFTWARD_ANGLE, num, true );
            return;
        }
        AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.GMD_BOSS1_RIGHTWARD_ANGLE, num, false );
    }

    // Token: 0x060014B3 RID: 5299 RVA: 0x000B5BAC File Offset: 0x000B3DAC
    private static bool gmBoss1BodyUpdateAtkNmlFlipAndTurn( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        return AppMain.gmBoss1BodyUpdateTurnGently( body_work );
    }

    // Token: 0x060014B4 RID: 5300 RVA: 0x000B5BB4 File Offset: 0x000B3DB4
    private static void gmBoss1BodyInitAtkNmlDrift( AppMain.GMS_BOSS1_BODY_WORK body_work, int frame )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.MTM_ASSERT( frame > 0 );
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.drift_angle = 0;
        body_work.drift_ang_spd = ( int )AppMain.nnRoundOff( ( float )AppMain.AKM_DEGtoA32( 180f ) / ( float )frame + 0.5f );
        body_work.drift_timer = frame;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            body_work.drift_pivot_x = AppMain.GMM_BOSS1_AREA_LEFT() + 983040;
        }
        else
        {
            body_work.drift_pivot_x = AppMain.GMM_BOSS1_AREA_LEFT() + 589824;
        }
        AppMain.gmBoss1BodyUpdateAtkNmlDrift( body_work );
    }

    // Token: 0x060014B5 RID: 5301 RVA: 0x000B5C3C File Offset: 0x000B3E3C
    private static bool gmBoss1BodyUpdateAtkNmlDrift( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num;
        bool result;
        if ( body_work.drift_timer != 0 )
        {
            body_work.drift_timer--;
            body_work.drift_angle = ( int )( 65535L & ( long )( body_work.drift_angle + body_work.drift_ang_spd ) );
            num = AppMain.FX_Mul( AppMain.FX_Sin( body_work.drift_angle ), 131072 );
            result = false;
        }
        else
        {
            num = 0;
            result = true;
        }
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) == 0U )
        {
            num = -num;
        }
        obs_OBJECT_WORK.pos.x = body_work.drift_pivot_x + num;
        return result;
    }

    // Token: 0x060014B6 RID: 5302 RVA: 0x000B5CC4 File Offset: 0x000B3EC4
    private static void gmBoss1BodyInitRush( AppMain.GMS_BOSS1_BODY_WORK body_work, bool is_left )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( is_left )
        {
            body_work.bash_targ_pos.x = AppMain.GMM_BOSS1_AREA_LEFT() + 720896;
            body_work.bash_targ_pos.y = AppMain.GMD_BOSS1_BODY_ATKBASH_TARG_Y;
            body_work.bash_targ_pos.z = 0;
        }
        else
        {
            body_work.bash_targ_pos.x = AppMain.GMM_BOSS1_AREA_LEFT() + 851968;
            body_work.bash_targ_pos.y = AppMain.GMD_BOSS1_BODY_ATKBASH_TARG_Y;
            body_work.bash_targ_pos.z = 0;
        }
        int num = (body_work.bash_targ_pos.x - obs_OBJECT_WORK.pos.x) / 39;
        int num2 = (body_work.bash_targ_pos.y - obs_OBJECT_WORK.pos.y) / 39;
        obs_OBJECT_WORK.spd_add.x = ( int )( ( float )num * 0.03125f );
        obs_OBJECT_WORK.spd_add.y = ( int )( ( float )num2 * 0.03125f );
        obs_OBJECT_WORK.spd.x = 0;
        obs_OBJECT_WORK.spd.y = 0;
    }

    // Token: 0x060014B7 RID: 5303 RVA: 0x000B5DB8 File Offset: 0x000B3FB8
    private static bool gmBoss1BodyUpdateRush( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, AppMain.FX_FX32_TO_F32( body_work.bash_targ_pos.x ) - AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.pos.x ), AppMain.FX_FX32_TO_F32( body_work.bash_targ_pos.y ) - AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.pos.y ), 0f );
        AppMain.amVectorSet( nns_VECTOR2, AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.x ), AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.spd.y ), 0f );
        if ( 0f >= AppMain.nnDotProductVector( nns_VECTOR2, nns_VECTOR ) )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            AppMain.VEC_Set( ref obs_OBJECT_WORK.pos, body_work.bash_targ_pos.x, body_work.bash_targ_pos.y, body_work.bash_targ_pos.z );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
            return true;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        return false;
    }

    // Token: 0x060014B8 RID: 5304 RVA: 0x000B5EAC File Offset: 0x000B40AC
    private static void gmBoss1BodyInitBashReturn( AppMain.GMS_BOSS1_BODY_WORK body_work, bool is_left )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( is_left )
        {
            body_work.bash_ret_pos.x = AppMain.GMM_BOSS1_AREA_LEFT() + 524288;
            body_work.bash_ret_pos.y = body_work.atk_nml_alt;
            body_work.bash_ret_pos.z = 0;
        }
        else
        {
            body_work.bash_ret_pos.x = AppMain.GMM_BOSS1_AREA_LEFT() + 1048576;
            body_work.bash_ret_pos.y = body_work.atk_nml_alt;
            body_work.bash_ret_pos.z = 0;
        }
        AppMain.VEC_Set( ref body_work.bash_orig_pos, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, obs_OBJECT_WORK.pos.z );
        body_work.bash_homing_deg = 0;
    }

    // Token: 0x060014B9 RID: 5305 RVA: 0x000B5F60 File Offset: 0x000B4160
    private static bool gmBoss1BodyUpdateBashReturn( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        body_work.bash_homing_deg += AppMain.AKM_DEGtoA32( 3 );
        if ( body_work.bash_homing_deg >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            body_work.bash_homing_deg = AppMain.AKM_DEGtoA32( 180 );
            obs_OBJECT_WORK.pos.x = body_work.bash_ret_pos.x;
            obs_OBJECT_WORK.pos.y = body_work.bash_ret_pos.y;
            return true;
        }
        obs_OBJECT_WORK.pos.x = body_work.bash_orig_pos.x + AppMain.FX_Mul( body_work.bash_ret_pos.x - body_work.bash_orig_pos.x, 4096 - AppMain.mtMathCos( body_work.bash_homing_deg ) >> 1 );
        obs_OBJECT_WORK.pos.y = body_work.bash_orig_pos.y + AppMain.FX_Mul( body_work.bash_ret_pos.y - body_work.bash_orig_pos.y, 4096 - AppMain.mtMathCos( body_work.bash_homing_deg ) >> 1 );
        return false;
    }

    // Token: 0x060014BA RID: 5306 RVA: 0x000B6064 File Offset: 0x000B4264
    private static void gmBoss1BodyInitEscapeMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            obs_OBJECT_WORK.spd_add.x = -409;
        }
        else
        {
            obs_OBJECT_WORK.spd_add.x = 409;
        }
        obs_OBJECT_WORK.spd_add.y = -256;
    }

    // Token: 0x060014BB RID: 5307 RVA: 0x000B60BC File Offset: 0x000B42BC
    private static bool gmBoss1BodyUpdateEscapeMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool flag = false;
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) >= 4915 )
        {
            obs_OBJECT_WORK.spd.x = 4915;
            obs_OBJECT_WORK.spd.y = -3072;
            obs_OBJECT_WORK.spd_add.x = 0;
            obs_OBJECT_WORK.spd_add.y = 0;
        }
        if ( obs_OBJECT_WORK.pos.y < 0 )
        {
            flag = true;
        }
        else if ( obs_OBJECT_WORK.pos.x >= ( AppMain.g_gm_main_system.map_size[0] << 12 ) + 262144 )
        {
            flag = true;
        }
        if ( flag )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        }
        return flag;
    }

    // Token: 0x060014BC RID: 5308 RVA: 0x000B6164 File Offset: 0x000B4364
    private static void gmBoss1BodyInitDefeatState( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        bool flag = false;
        if ( ( body_work.flag & 1U ) != 0U )
        {
            flag = true;
        }
        AppMain.gmBoss1BodyChangeState( body_work, 7, true );
        if ( flag )
        {
            body_work.flag |= 1U;
            return;
        }
        body_work.flag &= 4294967294U;
    }

    // Token: 0x060014BD RID: 5309 RVA: 0x000B61A8 File Offset: 0x000B43A8
    private static void gmBoss1BodyUpdateChainTopDirection( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        if ( ( body_work.flag & 1U ) == 0U )
        {
            AppMain.NNS_MATRIX src = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, body_work.chaintop_snm_reg_id);
            AppMain.nnRotateYMatrix( nns_MATRIX, src, ( int )( -AppMain.GMM_BS_OBJ( body_work ).dir.y + ( ushort )AppMain.AKM_DEGtoA16( 90 ) ) );
            AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX, body_work.chaintop_cnm_reg_id );
            AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, body_work.chaintop_cnm_reg_id, 1 );
        }
        else
        {
            AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, body_work.chaintop_cnm_reg_id, 0 );
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x060014BE RID: 5310 RVA: 0x000B6238 File Offset: 0x000B4438
    private static void gmBoss1BodyDamageDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)parent_obj;
        if ( parent_obj2 != null && 1 == parent_obj2.obj_type )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
            AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
            AppMain.GmPlySeqSetJumpState( gms_PLAYER_WORK, 0, 5U );
            if ( gms_PLAYER_WORK.seq_state == 20 )
            {
                gms_PLAYER_WORK.obj_work.spd_m = 0;
                if ( gms_PLAYER_WORK.obj_work.move.x >= 0 )
                {
                    gms_PLAYER_WORK.obj_work.spd.x = -20480;
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.x = 20480;
                }
                if ( parent_obj2.pos.y <= parent_obj.pos.y )
                {
                    gms_PLAYER_WORK.obj_work.spd.y = -16384;
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.y = 16384;
                }
                AppMain.GmPlySeqSetNoJumpMoveTime( gms_PLAYER_WORK, 102400 );
            }
            else
            {
                gms_PLAYER_WORK.obj_work.spd_m = 0;
                if ( gms_PLAYER_WORK.obj_work.move.x >= 0 )
                {
                    gms_PLAYER_WORK.obj_work.spd.x = -16384;
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.x = 16384;
                }
                if ( parent_obj2.pos.y <= parent_obj.pos.y )
                {
                    gms_PLAYER_WORK.obj_work.spd.y = -12288;
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.y = 12288;
                }
                AppMain.GmPlySeqSetNoJumpMoveTime( gms_PLAYER_WORK, 102400 );
            }
            AppMain.gmBoss1BodySetNoHitTime( gms_BOSS1_BODY_WORK );
            AppMain.GmSoundPlaySE( "Boss0_01" );
            AppMain.GMM_PAD_VIB_SMALL_TIME( 30f );
            AppMain.gmBoss1EffDamageInit( gms_BOSS1_BODY_WORK );
            if ( ( gms_BOSS1_BODY_WORK.flag & 4U ) == 0U )
            {
                AppMain.gmBoss1BodyExecDamageRoutine( gms_BOSS1_BODY_WORK );
            }
        }
    }

    // Token: 0x060014BF RID: 5311 RVA: 0x000B63F8 File Offset: 0x000B45F8
    private static void gmBoss1BodyOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work;
        AppMain.GmBsCmnUpdateCNMParam( obj_work, gms_BOSS1_BODY_WORK.cnm_mgr_work );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x060014C0 RID: 5312 RVA: 0x000B641E File Offset: 0x000B461E
    private static void gmBoss1BodyChangeState( AppMain.GMS_BOSS1_BODY_WORK body_work, int state )
    {
        AppMain.gmBoss1BodyChangeState( body_work, state, false );
    }

    // Token: 0x060014C1 RID: 5313 RVA: 0x000B6428 File Offset: 0x000B4628
    private static void gmBoss1BodyChangeState( AppMain.GMS_BOSS1_BODY_WORK body_work, int state, bool is_wrapped )
    {
        AppMain.UNREFERENCED_PARAMETER( is_wrapped );
        AppMain.GMF_BOSS1_BODY_STATE_LEAVE_FUNC gmf_BOSS1_BODY_STATE_LEAVE_FUNC = AppMain.gm_boss1_body_state_leave_func_tbl[body_work.state];
        if ( gmf_BOSS1_BODY_STATE_LEAVE_FUNC != null )
        {
            gmf_BOSS1_BODY_STATE_LEAVE_FUNC( body_work );
        }
        body_work.prev_state = body_work.state;
        body_work.state = state;
        AppMain.GMS_BOSS1_BODY_STATE_ENTER_INFO gms_BOSS1_BODY_STATE_ENTER_INFO = AppMain.gm_boss1_body_state_enter_info_tbl[body_work.state];
        if ( gms_BOSS1_BODY_STATE_ENTER_INFO.enter_func != null )
        {
            gms_BOSS1_BODY_STATE_ENTER_INFO.enter_func( body_work );
        }
    }

    // Token: 0x060014C2 RID: 5314 RVA: 0x000B648C File Offset: 0x000B468C
    private static void gmBoss1BodyWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work;
        if ( ( gms_BOSS1_BODY_WORK.mgr_work.flag & 1U ) != 0U )
        {
            AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, gms_BOSS1_BODY_WORK.bmcb_mgr );
            AppMain.GmBsCmnCreateSNMWork( gms_BOSS1_BODY_WORK.snm_work, obj_work.obj_3d._object, 4 );
            AppMain.GmBsCmnAppendBossMotionCallback( gms_BOSS1_BODY_WORK.bmcb_mgr, gms_BOSS1_BODY_WORK.snm_work.bmcb_link );
            gms_BOSS1_BODY_WORK.chain_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS1_BODY_WORK.snm_work, 13 );
            gms_BOSS1_BODY_WORK.egg_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS1_BODY_WORK.snm_work, 11 );
            gms_BOSS1_BODY_WORK.body_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS1_BODY_WORK.snm_work, 2 );
            gms_BOSS1_BODY_WORK.chaintop_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS1_BODY_WORK.snm_work, 9 );
            AppMain.GmBsCmnCreateCNMMgrWork( gms_BOSS1_BODY_WORK.cnm_mgr_work, obj_work.obj_3d._object, 1 );
            AppMain.GmBsCmnInitCNMCb( obj_work, gms_BOSS1_BODY_WORK.cnm_mgr_work );
            gms_BOSS1_BODY_WORK.chaintop_cnm_reg_id = AppMain.GmBsCmnRegisterCNMNode( gms_BOSS1_BODY_WORK.cnm_mgr_work, 9 );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1BodyMain );
            AppMain.gmBoss1BodyChangeState( gms_BOSS1_BODY_WORK, 1 );
        }
    }

    // Token: 0x060014C3 RID: 5315 RVA: 0x000B6588 File Offset: 0x000B4788
    private static void gmBoss1BodyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work;
        AppMain.gmBoss1BodyUpdateNoHitTime( gms_BOSS1_BODY_WORK );
        if ( ( gms_BOSS1_BODY_WORK.flag & 2147483648U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 1073741823U;
            AppMain.gmBoss1BodyInitDefeatState( gms_BOSS1_BODY_WORK );
        }
        else if ( gms_BOSS1_BODY_WORK.proc_update != null )
        {
            gms_BOSS1_BODY_WORK.proc_update( gms_BOSS1_BODY_WORK );
        }
        AppMain.gmBoss1BodyUpdateSuspendAction( gms_BOSS1_BODY_WORK );
        AppMain.gmBoss1EffAfterburnerUpdateCreate( gms_BOSS1_BODY_WORK );
        if ( ( gms_BOSS1_BODY_WORK.flag & 1073741824U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 3221225471U;
            gms_BOSS1_BODY_WORK.flag |= 536870912U;
            AppMain.GmBsCmnInitObject3DNNDamageFlicker( obj_work, gms_BOSS1_BODY_WORK.flk_work, 32f );
        }
        AppMain.GmBsCmnUpdateObject3DNNDamageFlicker( obj_work, gms_BOSS1_BODY_WORK.flk_work );
        AppMain.gmBoss1BodyUpdateDirection( gms_BOSS1_BODY_WORK );
        AppMain.gmBoss1BodyUpdateChainTopDirection( gms_BOSS1_BODY_WORK );
    }

    // Token: 0x060014C4 RID: 5316 RVA: 0x000B6648 File Offset: 0x000B4848
    private static void gmBoss1BodyStateEnterStart( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag |= 2U;
        body_work.flag |= 64U;
        AppMain.gmBoss1BodySetActionWhole( body_work, 0, true );
        body_work.flag |= 32U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        AppMain.gmBoss1BodySetDirectionNormal( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateStartWithWaitLockBegin );
    }

    // Token: 0x060014C5 RID: 5317 RVA: 0x000B66CC File Offset: 0x000B48CC
    private static void gmBoss1BodyStateLeaveStart( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.gmBoss1EffAfterburnerSetEnable( body_work, false );
        gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294934527U;
        body_work.flag &= 4294967231U;
        obs_OBJECT_WORK.flag &= 4294967293U;
        body_work.flag &= 4294967263U;
    }

    // Token: 0x060014C6 RID: 5318 RVA: 0x000B6732 File Offset: 0x000B4932
    private static void gmBoss1BodyStateUpdateStartWithWaitLockBegin( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss1IsScrollLockBusy() )
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateStartWithWaitLockComplete );
        }
    }

    // Token: 0x060014C7 RID: 5319 RVA: 0x000B6750 File Offset: 0x000B4950
    private static void gmBoss1BodyStateUpdateStartWithWaitLockComplete( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( !AppMain.gmBoss1IsScrollLockBusy() )
        {
            AppMain.GmMapSetMapDrawSize( 3 );
            AppMain.GmBsCmnSetObjSpd( obj_work, 0, 4096, 0 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateStartWithFall );
        }
    }

    // Token: 0x060014C8 RID: 5320 RVA: 0x000B6790 File Offset: 0x000B4990
    private static void gmBoss1BodyStateUpdateStartWithFall( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y >= body_work.atk_nml_alt )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.pos.y = body_work.atk_nml_alt;
            AppMain.GmBsCmnSetObjSpd( obs_OBJECT_WORK, -4096, 0, 0 );
            AppMain.gmBoss1EffAfterburnerSetEnable( body_work, true );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateStartWithMove );
        }
    }

    // Token: 0x060014C9 RID: 5321 RVA: 0x000B67F4 File Offset: 0x000B49F4
    private static void gmBoss1BodyStateUpdateStartWithMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.GMM_BOSS1_AREA_LEFT() + 786432;
        if ( obs_OBJECT_WORK.pos.x <= num )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.pos.x = num;
            body_work.wait_timer = 10U;
            AppMain.gmBoss1EffAfterburnerSetEnable( body_work, false );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateStartWithWaitEnd );
        }
    }

    // Token: 0x060014CA RID: 5322 RVA: 0x000B6855 File Offset: 0x000B4A55
    private static void gmBoss1BodyStateUpdateStartWithWaitEnd( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss1BodyChangeState( body_work, 2 );
    }

    // Token: 0x060014CB RID: 5323 RVA: 0x000B6878 File Offset: 0x000B4A78
    private static void gmBoss1BodyStateEnterPrep( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag |= 2U;
        body_work.flag |= 64U;
        AppMain.gmBoss1BodySetActionWhole( body_work, 2 );
        body_work.flag &= 4294967263U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.wait_timer = 95U;
        AppMain.GmSoundPlaySE( "Boss1_01" );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdatePrepWithWait );
    }

    // Token: 0x060014CC RID: 5324 RVA: 0x000B6908 File Offset: 0x000B4B08
    private static void gmBoss1BodyStateLeavePrep( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294934527U;
        body_work.flag &= 4294967231U;
        obs_OBJECT_WORK.flag &= 4294967293U;
    }

    // Token: 0x060014CD RID: 5325 RVA: 0x000B6958 File Offset: 0x000B4B58
    private static void gmBoss1BodyStateUpdatePrepWithWait( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
        }
        else
        {
            body_work.flag &= 4294967231U;
        }
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss1BodyChangeState( body_work, 3 );
        }
    }

    // Token: 0x060014CE RID: 5326 RVA: 0x000B69A4 File Offset: 0x000B4BA4
    private static void gmBoss1BodyStateEnterPreAtkNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss1BodySetDmgRectSizeForAtkNml( body_work );
        obs_OBJECT_WORK.flag &= 4294967293U;
        AppMain.gmBoss1BodySetActionWhole( body_work, 3 );
        AppMain.gmBoss1BodyInitPreANChainMotion( body_work );
        AppMain.gmBoss1BodySetFlipForAtkNmlMove( body_work );
        AppMain.gmBoss1BodyInitPreANMove( body_work );
        AppMain.gmBoss1EffAfterburnerSetEnable( body_work, true );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdatePreAtkNmlWithMove );
    }

    // Token: 0x060014CF RID: 5327 RVA: 0x000B69FF File Offset: 0x000B4BFF
    private static void gmBoss1BodyStateLeavePreAtkNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.gmBoss1EffAfterburnerSetEnable( body_work, false );
        AppMain.gmBoss1BodySetDmgRectSizeToDefault( body_work );
    }

    // Token: 0x060014D0 RID: 5328 RVA: 0x000B6A0E File Offset: 0x000B4C0E
    private static void gmBoss1BodyStateUpdatePreAtkNmlWithMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.gmBoss1BodySetDirectionNormal( body_work );
        if ( AppMain.gmBoss1BodyUpdatePreANMove( body_work ) )
        {
            AppMain.gmBoss1BodyChangeState( body_work, 4 );
            AppMain.gmBoss1BodySetANChainInitialBlendSpd( body_work );
        }
    }

    // Token: 0x060014D1 RID: 5329 RVA: 0x000B6A2C File Offset: 0x000B4C2C
    private static void gmBoss1BodyStateEnterAtkNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool force_change = false;
        AppMain.gmBoss1BodySetDmgRectSizeForAtkNml( body_work );
        obs_OBJECT_WORK.flag &= 4294967293U;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            force_change = true;
        }
        AppMain.gmBoss1BodySetActionWhole( body_work, 4, force_change );
        AppMain.gmBoss1BodyInitAtkNmlFlipAndTurn( body_work );
        AppMain.gmBoss1BodyInitAtkNmlDrift( body_work, 72 );
        AppMain.gmBoss1EffAfterburnerSetEnable( body_work, false );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkNmlWithTurn );
    }

    // Token: 0x060014D2 RID: 5330 RVA: 0x000B6A92 File Offset: 0x000B4C92
    private static void gmBoss1BodyStateLeaveAtkNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.gmBoss1EffAfterburnerSetEnable( body_work, false );
        AppMain.gmBoss1BodySetDmgRectSizeToDefault( body_work );
    }

    // Token: 0x060014D3 RID: 5331 RVA: 0x000B6AA4 File Offset: 0x000B4CA4
    private static void gmBoss1BodyStateUpdateAtkNmlWithTurn( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        bool flag = AppMain.gmBoss1BodyUpdateAtkNmlDrift(body_work);
        if ( AppMain.gmBoss1BodyUpdateAtkNmlFlipAndTurn( body_work ) && flag )
        {
            AppMain.gmBoss1BodySetFlipForAtkNmlMove( body_work );
            AppMain.gmBoss1BodyInitAtkNmlMove( body_work, 56 );
            AppMain.gmBoss1EffAfterburnerSetEnable( body_work, true );
            AppMain.GmSoundPlaySE( "Boss1_02" );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkNmlWithMove );
        }
    }

    // Token: 0x060014D4 RID: 5332 RVA: 0x000B6AF4 File Offset: 0x000B4CF4
    private static void gmBoss1BodyStateUpdateAtkNmlWithMove( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.gmBoss1BodySetDirectionNormal( body_work );
        if ( AppMain.gmBoss1BodyIsExtraAttack( body_work ) )
        {
            if ( AppMain.GmBsCmnIsFinalZoneType( AppMain.GMM_BS_OBJ( body_work ) ) == 0 )
            {
                AppMain.GmSoundChangeAngryBossBGM();
            }
            AppMain.gmBoss1BodyChangeState( body_work, 5 );
            return;
        }
        if ( AppMain.gmBoss1BodyUpdateAtkNmlMove( body_work ) )
        {
            AppMain.gmBoss1BodyChangeState( body_work, 4 );
        }
    }

    // Token: 0x060014D5 RID: 5333 RVA: 0x000B6B30 File Offset: 0x000B4D30
    private static void gmBoss1BodyStateEnterAtkBash( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss1BodySetActionWhole( body_work, 5 );
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        AppMain.gmBoss1BodySetDirectionNormal( body_work );
        AppMain.gmBoss1BodySetDmgRectSizeForAtkNml( body_work );
        if ( AppMain.GmBsCmnGetPlayerObj().pos.x < obs_OBJECT_WORK.pos.x )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
            AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.AKM_DEGtoA16( 270f ), 30, false );
        }
        else
        {
            obs_OBJECT_WORK.disp_flag &= 4294967294U;
            AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.AKM_DEGtoA16( 90f ), 30, true );
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkBashWithLock );
    }

    // Token: 0x060014D6 RID: 5334 RVA: 0x000B6BD0 File Offset: 0x000B4DD0
    private static void gmBoss1BodyStateLeaveAtkBash( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        body_work.flag &= 4294967294U;
        body_work.flag &= 4294967291U;
        AppMain.gmBoss1BodySetAtkRectToNormal( body_work );
        AppMain.gmBoss1BodySetDmgRectSizeToDefault( body_work );
    }

    // Token: 0x060014D7 RID: 5335 RVA: 0x000B6BFC File Offset: 0x000B4DFC
    private static void gmBoss1BodyStateUpdateAtkBashWithLock( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss1BodyUpdateTurnGently( body_work ) )
        {
            AppMain.gmBoss1BodySetActionWhole( body_work, 6 );
            AppMain.gmBoss1Init1ShotTimer( body_work.se_timer, 110U );
            body_work.se_cnt = 3U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkBashWithPrep );
        }
    }

    // Token: 0x060014D8 RID: 5336 RVA: 0x000B6C34 File Offset: 0x000B4E34
    private static void gmBoss1BodyStateUpdateAtkBashWithPrep( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.gmBoss1Update1ShotTimer( body_work.se_timer ) && body_work.se_cnt != 0U )
        {
            body_work.se_cnt -= 1U;
            AppMain.GmSoundPlaySE( "Boss1_03" );
            AppMain.gmBoss1Init1ShotTimer( body_work.se_timer, 15U );
        }
        if ( AppMain.gmBoss1BodyCheckChainMotionMergeEnd( body_work ) )
        {
            body_work.flag |= 1U;
        }
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.gmBoss1BodySetDmgRectSizeToDefault( body_work );
            AppMain.gmBoss1BodySetAtkRectToWeakAttacker( body_work );
            body_work.flag |= 4U;
            body_work.flag |= 1U;
            AppMain.gmBoss1BodySetActionWhole( body_work, 7 );
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                AppMain.gmBoss1BodyInitRush( body_work, true );
            }
            else
            {
                AppMain.gmBoss1BodyInitRush( body_work, false );
            }
            AppMain.GmSoundPlaySE( "Boss1_04" );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkBashWithSwing );
        }
    }

    // Token: 0x060014D9 RID: 5337 RVA: 0x000B6D08 File Offset: 0x000B4F08
    private static void gmBoss1BodyStateUpdateAtkBashWithSwing( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.gmBoss1BodyUpdateRush( body_work ) && AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss1BodySetDmgRectSizeToDefault( body_work );
            AppMain.gmBoss1BodySetAtkRectToWeakAttacker( body_work );
            body_work.flag &= 4294967291U;
            body_work.flag |= 134217728U;
            AppMain.GmCameraVibrationSet( 0, 65536, 0 );
            AppMain.GmSoundPlaySE( "Boss1_05" );
            AppMain.GMM_PAD_VIB_MID_TIME( 30f );
            AppMain.gmBoss1BodySetActionWhole( body_work, 8 );
            AppMain.gmBoss1BodySetSuspendAction( body_work, 1, 1U );
            AppMain.gmBoss1Init1ShotTimer( body_work.se_timer, 70U );
            body_work.se_cnt = 2U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkBashWithFinish );
        }
    }

    // Token: 0x060014DA RID: 5338 RVA: 0x000B6DB4 File Offset: 0x000B4FB4
    private static void gmBoss1BodyStateUpdateAtkBashWithFinish( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.gmBoss1Update1ShotTimer( body_work.se_timer ) && body_work.se_cnt != 0U )
        {
            body_work.se_cnt -= 1U;
            AppMain.GmSoundPlaySE( "Boss1_03" );
            AppMain.gmBoss1Init1ShotTimer( body_work.se_timer, 15U );
        }
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.gmBoss1BodySetAtkRectToNormal( body_work );
            AppMain.gmBoss1BodySetActionWhole( body_work, 9 );
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                AppMain.gmBoss1BodyInitBashReturn( body_work, true );
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.AKM_DEGtoA16( 90 ), 90, false );
            }
            else
            {
                AppMain.gmBoss1BodyInitBashReturn( body_work, false );
                obs_OBJECT_WORK.disp_flag |= 1U;
                AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.AKM_DEGtoA16( 270 ), 90, true );
            }
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkBashWithHoming );
        }
    }

    // Token: 0x060014DB RID: 5339 RVA: 0x000B6E84 File Offset: 0x000B5084
    private static void gmBoss1BodyStateUpdateAtkBashWithHoming( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool flag = true;
        if ( !AppMain.gmBoss1BodyUpdateTurnGently( body_work ) )
        {
            flag = false;
        }
        if ( !AppMain.gmBoss1BodyUpdateBashReturn( body_work ) )
        {
            flag = false;
        }
        if ( flag )
        {
            AppMain.gmBoss1BodySetDmgRectSizeToDefault( body_work );
            AppMain.gmBoss1BodySetAtkRectToWeakAttacker( body_work );
            body_work.flag |= 4U;
            body_work.flag |= 1U;
            AppMain.gmBoss1BodySetActionWhole( body_work, 7 );
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                AppMain.gmBoss1BodyInitRush( body_work, true );
            }
            else
            {
                AppMain.gmBoss1BodyInitRush( body_work, false );
            }
            AppMain.GmSoundPlaySE( "Boss1_04" );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateAtkBashWithSwing );
        }
    }

    // Token: 0x060014DC RID: 5340 RVA: 0x000B6F16 File Offset: 0x000B5116
    private static void gmBoss1BodyStateEnterDmgNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x060014DD RID: 5341 RVA: 0x000B6F1E File Offset: 0x000B511E
    private static void gmBoss1BodyStateLeaveDmgNml( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x060014DE RID: 5342 RVA: 0x000B6F28 File Offset: 0x000B5128
    private static void gmBoss1BodyStateEnterDefeat( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.disp_flag |= 16U;
        body_work.flag |= 8U;
        body_work.ene_3d.ene_com.enemy_flag |= 32768U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.wait_timer = 40U;
        AppMain.GmSoundChangeWinBossBGM();
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateDefeatWithWaitStart );
    }

    // Token: 0x060014DF RID: 5343 RVA: 0x000B6FA8 File Offset: 0x000B51A8
    private static void gmBoss1BodyStateLeaveDefeat( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x060014E0 RID: 5344 RVA: 0x000B6FB0 File Offset: 0x000B51B0
    private static void gmBoss1BodyStateUpdateDefeatWithWaitStart( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss1EffBombInitCreate( body_work.bomb_work, 0, AppMain.GMM_BS_OBJ( body_work ), AppMain.GMM_BS_OBJ( body_work ).pos.x, AppMain.GMM_BS_OBJ( body_work ).pos.y, 327680, 327680, 10U, 10U );
        body_work.wait_timer = 120U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateDefeatWithExplode );
    }

    // Token: 0x060014E1 RID: 5345 RVA: 0x000B7030 File Offset: 0x000B5230
    private static void gmBoss1BodyStateUpdateDefeatWithExplode( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            AppMain.gmBoss1EffBombUpdateCreate( body_work.bomb_work );
            return;
        }
        body_work.flag |= 67108864U;
        AppMain.GmSoundPlaySE( "Boss0_03" );
        AppMain.gmBoss1InitFlashScreen();
        AppMain.GMM_PAD_VIB_MID_TIME( 120f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(body_work), 8);
        obs_OBJECT_WORK.pos.z = obs_OBJECT_WORK.parent_obj.pos.z + 131072;
        body_work.wait_timer = 40U;
        AppMain.GmPlayerAddScoreNoDisp( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 1000 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateDefeatWithScatter );
    }

    // Token: 0x060014E2 RID: 5346 RVA: 0x000B70EC File Offset: 0x000B52EC
    private static void gmBoss1BodyStateUpdateDefeatWithScatter( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss1SetPartTextureBurnt( AppMain.GMM_BS_OBJ( body_work ) );
        body_work.flag |= 16777216U;
        AppMain.gmBoss1EffABSmokeInit( body_work );
        AppMain.gmBoss1EffBodySmokeInit( body_work );
        AppMain.gmBoss1EffBodySmallSmokeInit( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateDefeatWithWaitEnd );
    }

    // Token: 0x060014E3 RID: 5347 RVA: 0x000B7151 File Offset: 0x000B5351
    private static void gmBoss1BodyStateUpdateDefeatWithWaitEnd( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss1BodyChangeState( body_work, 8 );
    }

    // Token: 0x060014E4 RID: 5348 RVA: 0x000B7174 File Offset: 0x000B5374
    private static void gmBoss1BodyStateEnterEscape( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.disp_flag &= 4294967279U;
        AppMain.gmBoss1BodySetActionWhole( body_work, 12 );
        body_work.flag |= 8388608U;
        bool is_positive = AppMain.gmBoss1BodyIsDirectionPositiveFromCurrent(body_work, AppMain.GMD_BOSS1_RIGHTWARD_ANGLE);
        AppMain.gmBoss1BodyInitTurnGently( body_work, AppMain.GMD_BOSS1_RIGHTWARD_ANGLE, 90, is_positive );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateEscapeWithTurn );
    }

    // Token: 0x060014E5 RID: 5349 RVA: 0x000B71F2 File Offset: 0x000B53F2
    private static void gmBoss1BodyStateLeaveEscape( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x060014E6 RID: 5350 RVA: 0x000B71FC File Offset: 0x000B53FC
    private static void gmBoss1BodyStateUpdateEscapeWithTurn( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss1BodyUpdateTurnGently( body_work ) )
        {
            AppMain.gmBoss1BodyInitEscapeMove( body_work );
            if ( AppMain.GmBsCmnIsFinalZoneType( AppMain.GMM_BS_OBJ( AppMain.GMM_BOSS1_MGR( body_work ) ) ) != 0 )
            {
                body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateEscapeWithMoveMoveFinalZone );
                return;
            }
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateEscapeWithMoveLocked );
        }
    }

    // Token: 0x060014E7 RID: 5351 RVA: 0x000B7250 File Offset: 0x000B5450
    private static void gmBoss1BodyStateUpdateEscapeWithMoveLocked( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.gmBoss1BodyUpdateEscapeMove( body_work );
        if ( AppMain.gmBoss1BodyIsEscapeScrUnlock( body_work ) )
        {
            AppMain.GmMapSetMapDrawSize( 1 );
            AppMain.gmBoss1EffBodyDebrisInit( body_work );
            body_work.flag |= 256U;
            AppMain.GmGmkCamScrLimitRelease( 4 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.gmBoss1BodyStateUpdateEscapeWithMoveUnlocked );
        }
    }

    // Token: 0x060014E8 RID: 5352 RVA: 0x000B72A3 File Offset: 0x000B54A3
    private static void gmBoss1BodyStateUpdateEscapeWithMoveUnlocked( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss1BodyUpdateEscapeMove( body_work ) )
        {
            AppMain.GMM_BOSS1_MGR( body_work ).flag |= 2U;
            body_work.proc_update = null;
        }
    }

    // Token: 0x060014E9 RID: 5353 RVA: 0x000B72C8 File Offset: 0x000B54C8
    private static void gmBoss1BodyStateUpdateEscapeWithMoveMoveFinalZone( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 256U ) == 0U && AppMain.gmBoss1BodyIsEscapeScrUnlock( body_work ) )
        {
            AppMain.gmBoss1EffBodyDebrisInit( body_work );
            body_work.flag |= 256U;
        }
        if ( AppMain.gmBoss1BodyUpdateEscapeMove( body_work ) || AppMain.gmBoss1BodyIsEscapeOutFinalZone( body_work ) )
        {
            AppMain.GMM_BOSS1_MGR( body_work ).flag |= 2U;
            body_work.proc_update = null;
        }
    }

    // Token: 0x060014EA RID: 5354 RVA: 0x000B7330 File Offset: 0x000B5530
    private static void gmBoss1ChainExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)obs_OBJECT_WORK;
        AppMain.gmBoss1MgrDecObjCreateCount( gms_BOSS1_CHAIN_WORK.mgr_work );
        AppMain.GmBsCmnClearBossMotionCBSystem( obs_OBJECT_WORK );
        AppMain.GmBsCmnDeleteSNMWork( gms_BOSS1_CHAIN_WORK.snm_work );
        AppMain.GmBsCmnClearCNMCb( obs_OBJECT_WORK );
        AppMain.GmBsCmnDeleteCNMMgrWork( gms_BOSS1_CHAIN_WORK.cnm_mgr_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060014EB RID: 5355 RVA: 0x000B7380 File Offset: 0x000B5580
    private static void gmBoss1ChainUpdateAtkRectPosition( AppMain.GMS_BOSS1_CHAIN_WORK chain_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(chain_work);
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(chain_work.snm_work, chain_work.ball_snm_reg_id);
        AppMain.VEC_Set( ref chain_work.ene_3d.ene_com.rect_work[1].rect.pos, AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 ) - obs_OBJECT_WORK.pos.x, AppMain.FX_F32_TO_FX32( -nns_MATRIX.M13 ) - obs_OBJECT_WORK.pos.y, 0 );
    }

    // Token: 0x060014EC RID: 5356 RVA: 0x000B73F8 File Offset: 0x000B55F8
    private static void gmBoss1ChainAtkHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)my_rect.parent_obj.parent_obj;
        gms_BOSS1_BODY_WORK.flag |= 268435456U;
        AppMain.GmEnemyDefaultAtkFunc( my_rect, your_rect );
    }

    // Token: 0x060014ED RID: 5357 RVA: 0x000B7430 File Offset: 0x000B5630
    private static void gmBoss1ChainOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)obj_work;
        AppMain.GmBsCmnUpdateCNMParam( obj_work, gms_BOSS1_CHAIN_WORK.cnm_mgr_work );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x060014EE RID: 5358 RVA: 0x000B7458 File Offset: 0x000B5658
    private static void gmBoss1ChainWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)obj_work;
        AppMain.GMS_BOSS1_BODY_WORK work = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        if ( ( AppMain.GMM_BOSS1_MGR( work ).flag & 1U ) != 0U )
        {
            AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, gms_BOSS1_CHAIN_WORK.bmcb_mgr );
            AppMain.GmBsCmnCreateSNMWork( gms_BOSS1_CHAIN_WORK.snm_work, obj_work.obj_3d._object, 10 );
            AppMain.GmBsCmnAppendBossMotionCallback( gms_BOSS1_CHAIN_WORK.bmcb_mgr, gms_BOSS1_CHAIN_WORK.snm_work.bmcb_link );
            gms_BOSS1_CHAIN_WORK.ball_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS1_CHAIN_WORK.snm_work, 11 );
            for ( int i = 0; i < 9; i++ )
            {
                gms_BOSS1_CHAIN_WORK.sct_snm_reg_ids[i] = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS1_CHAIN_WORK.snm_work, 2 + i );
            }
            AppMain.GmBsCmnCreateCNMMgrWork( gms_BOSS1_CHAIN_WORK.cnm_mgr_work, obj_work.obj_3d._object, 9 );
            AppMain.GmBsCmnInitCNMCb( obj_work, gms_BOSS1_CHAIN_WORK.cnm_mgr_work );
            for ( int j = 0; j < 9; j++ )
            {
                gms_BOSS1_CHAIN_WORK.sct_cnm_reg_ids[j] = AppMain.GmBsCmnRegisterCNMNode( gms_BOSS1_CHAIN_WORK.cnm_mgr_work, 2 + j );
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1ChainMain );
        }
    }

    // Token: 0x060014EF RID: 5359 RVA: 0x000B7554 File Offset: 0x000B5754
    private static void gmBoss1ChainMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_CHAIN_WORK gms_BOSS1_CHAIN_WORK = (AppMain.GMS_BOSS1_CHAIN_WORK)obj_work;
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        bool flag;
        if ( ( gms_BOSS1_BODY_WORK.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4194304U;
            flag = true;
        }
        else
        {
            obj_work.disp_flag &= 4290772991U;
            flag = false;
        }
        if ( ( gms_BOSS1_CHAIN_WORK.flag & 1U ) != 0U )
        {
            obj_work.obj_3d.flag &= 4294967294U;
            if ( obj_work.obj_3d.marge > 0f )
            {
                obj_work.obj_3d.marge -= obj_work.obj_3d.blend_spd;
            }
            else
            {
                gms_BOSS1_CHAIN_WORK.flag &= 4294967294U;
                if ( AppMain.gm_boss1_act_id_tbl[gms_BOSS1_BODY_WORK.whole_act_id][1].is_repeat != 0 )
                {
                    obj_work.disp_flag |= 4U;
                }
                else
                {
                    obj_work.disp_flag &= 4294967291U;
                }
                obj_work.obj_3d.marge = 0f;
            }
        }
        if ( ( AppMain.GMM_BS_OBJ( gms_BOSS1_BODY_WORK ).disp_flag & 16U ) != 0U )
        {
            obj_work.disp_flag |= 16U;
        }
        else if ( ( gms_BOSS1_BODY_WORK.flag & 128U ) == 0U )
        {
            obj_work.disp_flag &= 4294967279U;
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 32U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
        }
        else
        {
            obj_work.disp_flag &= 4294967263U;
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 64U ) != 0U )
        {
            obj_work.flag |= 2U;
        }
        else
        {
            obj_work.flag &= 4294967293U;
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 8U ) != 0U )
        {
            obj_work.disp_flag |= 16U;
            obj_work.flag |= 2U;
        }
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, gms_BOSS1_BODY_WORK.snm_work, gms_BOSS1_BODY_WORK.chain_snm_reg_id, flag ? 1 : 0 );
        if ( ( gms_BOSS1_BODY_WORK.flag & 134217728U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 4160749567U;
            AppMain.gmBoss1EffShockwaveInit( gms_BOSS1_CHAIN_WORK );
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 67108864U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 4227858431U;
            AppMain.gmBoss1EffScatterInit( gms_BOSS1_CHAIN_WORK );
        }
        AppMain.gmBoss1ChainUpdateAtkRectPosition( gms_BOSS1_CHAIN_WORK );
    }

    // Token: 0x060014F0 RID: 5360 RVA: 0x000B7778 File Offset: 0x000B5978
    private static void gmBoss1EggExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_BOSS1_EGG_WORK gms_BOSS1_EGG_WORK = (AppMain.GMS_BOSS1_EGG_WORK)p;
        AppMain.gmBoss1MgrDecObjCreateCount( gms_BOSS1_EGG_WORK.mgr_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060014F1 RID: 5361 RVA: 0x000B77A4 File Offset: 0x000B59A4
    private static void gmBoss1EggSetActionIndependent( AppMain.GMS_BOSS1_EGG_WORK egg_work, int act_id )
    {
        AppMain.gmBoss1EggSetActionIndependent( egg_work, act_id, false );
    }

    // Token: 0x060014F2 RID: 5362 RVA: 0x000B77B0 File Offset: 0x000B59B0
    private static void gmBoss1EggSetActionIndependent( AppMain.GMS_BOSS1_EGG_WORK egg_work, int act_id, bool force_change )
    {
        AppMain.GMS_BOSS1_PART_ACT_INFO gms_BOSS1_PART_ACT_INFO = AppMain.gm_boss1_egg_act_id_tbl[act_id];
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS1_BODY_WORK.flag & 2U ) != 0U )
        {
            return;
        }
        if ( !force_change && ( egg_work.flag & 1U ) != 0U && egg_work.egg_act_id == act_id )
        {
            return;
        }
        egg_work.egg_act_id = act_id;
        egg_work.flag |= 1U;
        if ( gms_BOSS1_PART_ACT_INFO.is_maintain == 0 )
        {
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS1_PART_ACT_INFO.act_id, ( int )gms_BOSS1_PART_ACT_INFO.is_repeat, gms_BOSS1_PART_ACT_INFO.is_blend ? 1 : 0 );
        }
        else if ( gms_BOSS1_PART_ACT_INFO.is_repeat != 0 )
        {
            AppMain.GMM_BS_OBJ( egg_work ).disp_flag |= 4U;
        }
        obs_OBJECT_WORK.obj_3d.speed[0] = gms_BOSS1_PART_ACT_INFO.mtn_spd;
        obs_OBJECT_WORK.obj_3d.blend_spd = gms_BOSS1_PART_ACT_INFO.blend_spd;
    }

    // Token: 0x060014F3 RID: 5363 RVA: 0x000B7878 File Offset: 0x000B5A78
    private static void gmBoss1EggRevertActionIndependent( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.MTM_ASSERT( egg_work.flag & 1U );
        egg_work.flag &= 4294967294U;
        AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS1_BODY_WORK.egg_revert_mtn_id, ( int )AppMain.gm_boss1_act_id_tbl[gms_BOSS1_BODY_WORK.whole_act_id][2].is_repeat, 1 );
        obs_OBJECT_WORK.obj_3d.frame[0] = AppMain.GMM_BS_OBJ( gms_BOSS1_BODY_WORK ).obj_3d.frame[0];
    }

    // Token: 0x060014F4 RID: 5364 RVA: 0x000B78F4 File Offset: 0x000B5AF4
    private static void gmBoss1EggWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK work = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS1_EGG_WORK egg_work = (AppMain.GMS_BOSS1_EGG_WORK)obj_work;
        if ( ( AppMain.GMM_BOSS1_MGR( work ).flag & 1U ) != 0U )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EggMain );
            AppMain.gmBoss1EggProcIdleInit( egg_work );
        }
    }

    // Token: 0x060014F5 RID: 5365 RVA: 0x000B793C File Offset: 0x000B5B3C
    private static void gmBoss1EggMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS1_EGG_WORK gms_BOSS1_EGG_WORK = (AppMain.GMS_BOSS1_EGG_WORK)obj_work;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, gms_BOSS1_BODY_WORK.snm_work, gms_BOSS1_BODY_WORK.egg_snm_reg_id, 1 );
        if ( gms_BOSS1_EGG_WORK.proc_update != null )
        {
            gms_BOSS1_EGG_WORK.proc_update( gms_BOSS1_EGG_WORK );
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 8388608U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 4286578687U;
            AppMain.gmBoss1EggProcEscapeInit( gms_BOSS1_EGG_WORK );
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 536870912U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 3758096383U;
            AppMain.gmBoss1EggProcDamageInit( gms_BOSS1_EGG_WORK );
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 16777216U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 4278190079U;
            AppMain.gmBoss1SetPartTextureBurnt( obj_work );
        }
        if ( ( AppMain.GMM_BS_OBJ( gms_BOSS1_BODY_WORK ).disp_flag & 16U ) != 0U )
        {
            obj_work.disp_flag |= 16U;
            return;
        }
        obj_work.disp_flag &= 4294967279U;
    }

    // Token: 0x060014F6 RID: 5366 RVA: 0x000B7A24 File Offset: 0x000B5C24
    private static void gmBoss1EggProcIdleInit( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_EGG_WORK( AppMain.gmBoss1EggProcIdleUpdateLoop );
    }

    // Token: 0x060014F7 RID: 5367 RVA: 0x000B7A38 File Offset: 0x000B5C38
    private static void gmBoss1EggProcIdleUpdateLoop( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS1_BODY_WORK.flag & 268435456U ) != 0U )
        {
            gms_BOSS1_BODY_WORK.flag &= 4026531839U;
            AppMain.gmBoss1EggProcLaughInit( egg_work );
        }
    }

    // Token: 0x060014F8 RID: 5368 RVA: 0x000B7A7E File Offset: 0x000B5C7E
    private static void gmBoss1EggProcLaughInit( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.gmBoss1EggSetActionIndependent( egg_work, 0 );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_EGG_WORK( AppMain.gmBoss1EggProcLaughUpdateLoop );
    }

    // Token: 0x060014F9 RID: 5369 RVA: 0x000B7A9C File Offset: 0x000B5C9C
    private static void gmBoss1EggProcLaughUpdateLoop( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss1EggRevertActionIndependent( egg_work );
            AppMain.gmBoss1EggProcIdleInit( egg_work );
        }
    }

    // Token: 0x060014FA RID: 5370 RVA: 0x000B7AC4 File Offset: 0x000B5CC4
    private static void gmBoss1EggProcDamageInit( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.gmBoss1EggSetActionIndependent( egg_work, 1 );
        AppMain.gmBoss1EffSweatInit( egg_work );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_EGG_WORK( AppMain.gmBoss1EggProcDamageUpdateLoop );
    }

    // Token: 0x060014FB RID: 5371 RVA: 0x000B7AE8 File Offset: 0x000B5CE8
    private static void gmBoss1EggProcDamageUpdateLoop( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            egg_work.flag &= 4294967293U;
            AppMain.gmBoss1EggRevertActionIndependent( egg_work );
            AppMain.gmBoss1EggProcIdleInit( egg_work );
        }
    }

    // Token: 0x060014FC RID: 5372 RVA: 0x000B7B1F File Offset: 0x000B5D1F
    private static void gmBoss1EggProcEscapeInit( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        if ( ( egg_work.flag & 2U ) == 0U )
        {
            AppMain.gmBoss1EffSweatInit( egg_work );
        }
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS1_EGG_WORK( AppMain.gmBoss1EggProcEscapeUpdateLoop );
    }

    // Token: 0x060014FD RID: 5373 RVA: 0x000B7B43 File Offset: 0x000B5D43
    private static void gmBoss1EggProcEscapeUpdateLoop( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.UNREFERENCED_PARAMETER( egg_work );
    }

    // Token: 0x060014FE RID: 5374 RVA: 0x000B7B54 File Offset: 0x000B5D54
    private static AppMain.GMS_EFFECT_3DES_WORK gmBoss1EffShockwaveInit( AppMain.GMS_BOSS1_CHAIN_WORK chain_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK(), AppMain.GMM_BS_OBJ(chain_work), 0, "B01_ShockWave");
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK gms_BOSS1_EFF_SHOCKWAVE_WORK = (AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK)gms_EFFECT_3DES_WORK;
        gms_BOSS1_EFF_SHOCKWAVE_WORK.mgr_work = chain_work.mgr_work;
        AppMain.gmBoss1MgrIncObjCreateCount( gms_BOSS1_EFF_SHOCKWAVE_WORK.mgr_work );
        int index;
        if ( AppMain.GmBsCmnIsFinalZoneType( AppMain.GMM_BS_OBJ( chain_work.mgr_work ) ) != 0 )
        {
            index = 708;
        }
        else
        {
            index = 706;
        }
        AppMain.ObjObjectAction3dESEffectLoad( AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ), gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( index ), null, 0, null );
        AppMain.ObjObjectAction3dESTextureLoad( AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ), gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( 709 ), null, 0, null, false );
        AppMain.ObjObjectAction3dESTextureSetByDwork( obs_OBJECT_WORK, AppMain.ObjDataGet( 710 ) );
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, 1U, 1U );
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(chain_work.snm_work, chain_work.ball_snm_reg_id);
        AppMain.VEC_Set( ref obs_OBJECT_WORK.pos, AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 ), AppMain.GMD_BOSS1_GROUND_POS_Y, 0 );
        obs_OBJECT_WORK.flag &= 4294967293U;
        AppMain.GmEffectRectInit( gms_EFFECT_3DES_WORK.efct_com, AppMain.gm_boss1_eff_sw_atk_flag_tbl, AppMain.gm_boss1_eff_sw_def_flag_tbl, 1, 1 );
        AppMain.ObjRectWorkSet( gms_EFFECT_3DES_WORK.efct_com.rect_work[1], -64, -32, 64, 32 );
        gms_BOSS1_EFF_SHOCKWAVE_WORK.atk_rect_timer = 10U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffShockwaveProcMain );
        AppMain.gmBoss1EffShockwaveSubpartInit( gms_BOSS1_EFF_SHOCKWAVE_WORK, 163840, true );
        AppMain.gmBoss1EffShockwaveSubpartInit( gms_BOSS1_EFF_SHOCKWAVE_WORK, 163840, false );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss1EffShockwaveExit ) );
        return gms_EFFECT_3DES_WORK;
    }

    // Token: 0x060014FF RID: 5375 RVA: 0x000B7CE4 File Offset: 0x000B5EE4
    private static void gmBoss1EffShockwaveExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK gms_BOSS1_EFF_SHOCKWAVE_WORK = (AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss1MgrDecObjCreateCount( gms_BOSS1_EFF_SHOCKWAVE_WORK.mgr_work );
        AppMain.GmEffectDefaultExit( tcb );
    }

    // Token: 0x06001500 RID: 5376 RVA: 0x000B7D10 File Offset: 0x000B5F10
    private static void gmBoss1EffShockwaveProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK gms_BOSS1_EFF_SHOCKWAVE_WORK = (AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK)obj_work;
        if ( gms_BOSS1_EFF_SHOCKWAVE_WORK.atk_rect_timer != 0U )
        {
            gms_BOSS1_EFF_SHOCKWAVE_WORK.atk_rect_timer -= 1U;
        }
        else
        {
            obj_work.flag |= 2U;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06001501 RID: 5377 RVA: 0x000B7D6C File Offset: 0x000B5F6C
    private static AppMain.GMS_EFFECT_3DES_WORK gmBoss1EffShockwaveSubpartInit( AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK sw_work, int ofst_h, bool is_left )
    {
        AppMain.MTM_ASSERT( ofst_h >= 0 );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK(), AppMain.GMM_BS_OBJ(sw_work).parent_obj, 0, "B01_SW_Subpart");
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK gms_BOSS1_EFF_SHOCKWAVE_SUB_WORK = (AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK)gms_EFFECT_3DES_WORK;
        gms_BOSS1_EFF_SHOCKWAVE_SUB_WORK.mgr_work = sw_work.mgr_work;
        AppMain.gmBoss1MgrIncObjCreateCount( gms_BOSS1_EFF_SHOCKWAVE_SUB_WORK.mgr_work );
        AppMain.ObjObjectAction3dESEffectLoad( AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ), gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( 707 ), null, 0, null );
        AppMain.ObjObjectAction3dESTextureLoad( AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ), gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( 709 ), null, 0, null, false );
        AppMain.ObjObjectAction3dESTextureSetByDwork( obs_OBJECT_WORK, AppMain.ObjDataGet( 710 ) );
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, 1U, 0U );
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, ( short )AppMain.GMD_BOSS1_EFF_SHOCKWAVE_SUB_ROT_X, 0, 0 );
        AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, 0f, -AppMain.FX_FX32_TO_F32( -16384 ), AppMain.FX_FX32_TO_F32( -ofst_h ) );
        obs_OBJECT_WORK.pos.x = AppMain.GMM_BS_OBJ( sw_work ).pos.x;
        obs_OBJECT_WORK.pos.y = AppMain.GMM_BS_OBJ( sw_work ).pos.y;
        obs_OBJECT_WORK.pos.z = AppMain.GMM_BS_OBJ( sw_work ).pos.z;
        if ( is_left )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967294U;
        }
        else
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss1EffShockwaveSubExit ) );
        return gms_EFFECT_3DES_WORK;
    }

    // Token: 0x06001502 RID: 5378 RVA: 0x000B7EEC File Offset: 0x000B60EC
    private static void gmBoss1EffShockwaveSubExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK gms_BOSS1_EFF_SHOCKWAVE_SUB_WORK = (AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss1MgrDecObjCreateCount( gms_BOSS1_EFF_SHOCKWAVE_SUB_WORK.mgr_work );
        AppMain.GmEffectDefaultExit( tcb );
    }

    // Token: 0x06001503 RID: 5379 RVA: 0x000B7F20 File Offset: 0x000B6120
    private static void gmBoss1EffScatterInit( AppMain.GMS_BOSS1_CHAIN_WORK chain_work )
    {
        for ( int i = 0; i < 9; i++ )
        {
            AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = AppMain.GmBsCmnCreateNodeControlObjectBySize(AppMain.GMM_BS_OBJ(chain_work), chain_work.cnm_mgr_work, chain_work.sct_cnm_reg_ids[i], chain_work.snm_work, chain_work.sct_snm_reg_ids[i], () => new AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK());
            AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK sct_part_ndc = (AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK)gms_BS_CMN_NODE_CTRL_OBJECT;
            gms_BS_CMN_NODE_CTRL_OBJECT.user_timer = ( uint )( AppMain.mtMathRand() % 20 );
            gms_BS_CMN_NODE_CTRL_OBJECT.is_enable = 0;
            AppMain.gmBoss1EffScatterSetPartParam( sct_part_ndc, i == 8 );
            AppMain.GMM_BS_OBJ( gms_BS_CMN_NODE_CTRL_OBJECT ).move_flag |= 4608U;
            AppMain.nnMakeUnitQuaternion( ref gms_BS_CMN_NODE_CTRL_OBJECT.user_quat );
            gms_BS_CMN_NODE_CTRL_OBJECT.proc_update = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffScatterProcWait );
        }
    }

    // Token: 0x06001504 RID: 5380 RVA: 0x000B7FE4 File Offset: 0x000B61E4
    private static void gmBoss1EffScatterSetPartParam( AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK sct_part_ndc, bool is_ironball )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)sct_part_ndc;
        int ang;
        if ( is_ironball )
        {
            sct_part_ndc.is_ironball = true;
            gms_BS_CMN_NODE_CTRL_OBJECT.user_ofst.y = 32f;
            ang = AppMain.GMD_BOSS1_EFF_SCT_PART_IBALL_SPIN_SPD_DEG;
        }
        else
        {
            sct_part_ndc.is_ironball = false;
            gms_BS_CMN_NODE_CTRL_OBJECT.user_ofst.y = 8f;
            ang = AppMain.GMD_BOSS1_EFF_SCT_PART_RING_SPIN_SPD_DEG;
        }
        AppMain.nnMakeUnitQuaternion( ref sct_part_ndc.spin_quat );
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
            float num = AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()) * 2f - 1f;
            num = AppMain.MTM_MATH_CLIP( num, -1f, 1f );
            short rand_angle = AppMain.AKM_DEGtoA16(360f * AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()));
            AppMain.AkMathGetRandomUnitVector( nns_VECTOR, num, rand_angle );
            AppMain.nnMakeRotateAxisQuaternion( out nns_QUATERNION, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z, ang );
            AppMain.nnMultiplyQuaternion( ref sct_part_ndc.spin_quat, ref nns_QUATERNION, ref sct_part_ndc.spin_quat );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        }
        if ( is_ironball )
        {
            AppMain.ObjObjectFieldRectSet( AppMain.GMM_BS_OBJ( gms_BS_CMN_NODE_CTRL_OBJECT ), -24, -24, 24, 24 );
            return;
        }
        AppMain.ObjObjectFieldRectSet( AppMain.GMM_BS_OBJ( gms_BS_CMN_NODE_CTRL_OBJECT ), -8, -8, 8, 8 );
    }

    // Token: 0x06001505 RID: 5381 RVA: 0x000B810C File Offset: 0x000B630C
    private static void gmBoss1EffScatterSetFlyParam( AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK sct_part_ndc )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(sct_part_ndc);
        int num = (int)(AppMain.mtMathRand() % 180);
        int ang = AppMain.AKM_DEGtoA32(num + ((num > 90) ? 45 : -45));
        float num2;
        if ( sct_part_ndc.is_ironball )
        {
            num2 = 3f;
        }
        else
        {
            num2 = 5f;
        }
        obs_OBJECT_WORK.spd.y = ( int )( 4096f * num2 * AppMain.nnSin( ang ) );
        obs_OBJECT_WORK.spd.x = ( int )( 4096f * num2 * AppMain.nnCos( ang ) );
        obs_OBJECT_WORK.move_flag |= 128U;
    }

    // Token: 0x06001506 RID: 5382 RVA: 0x000B819C File Offset: 0x000B639C
    private static void gmBoss1EffScatterProcWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obj_work;
        AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK sct_part_ndc = (AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK)gms_BS_CMN_NODE_CTRL_OBJECT;
        if ( gms_BS_CMN_NODE_CTRL_OBJECT.user_timer != 0U )
        {
            gms_BS_CMN_NODE_CTRL_OBJECT.user_timer -= 1U;
            return;
        }
        AppMain.GmBsCmnAttachNCObjectToSNMNode( gms_BS_CMN_NODE_CTRL_OBJECT );
        AppMain.gmBoss1EffScatterSetFlyParam( sct_part_ndc );
        gms_BS_CMN_NODE_CTRL_OBJECT.is_enable = 1;
        gms_BS_CMN_NODE_CTRL_OBJECT.user_timer = 180U;
        gms_BS_CMN_NODE_CTRL_OBJECT.proc_update = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffScatterProcFly );
    }

    // Token: 0x06001507 RID: 5383 RVA: 0x000B8200 File Offset: 0x000B6400
    private static void gmBoss1EffScatterProcFly( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obj_work;
        AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK gms_BOSS1_EFF_SCT_PART_NDC_WORK = (AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK)gms_BS_CMN_NODE_CTRL_OBJECT;
        AppMain.nnMultiplyQuaternion( ref gms_BS_CMN_NODE_CTRL_OBJECT.user_quat, ref gms_BOSS1_EFF_SCT_PART_NDC_WORK.spin_quat, ref gms_BS_CMN_NODE_CTRL_OBJECT.user_quat );
        AppMain.GmBsCmnSetWorldMtxFromNCObjectPosture( gms_BS_CMN_NODE_CTRL_OBJECT );
        if ( gms_BS_CMN_NODE_CTRL_OBJECT.user_timer != 0U )
        {
            gms_BS_CMN_NODE_CTRL_OBJECT.user_timer -= 1U;
            return;
        }
        obj_work.flag |= 4U;
    }

    // Token: 0x06001508 RID: 5384 RVA: 0x000B8260 File Offset: 0x000B6460
    private static void gmBoss1EffBombInitCreate( AppMain.GMS_BOSS1_EFF_BOMB_WORK bomb_work, int bomb_type, AppMain.OBS_OBJECT_WORK parent_obj, int pos_x, int pos_y, int width, int height, uint interval_min, uint interval_max )
    {
        AppMain.MTM_ASSERT( bomb_work );
        AppMain.MTM_ASSERT( parent_obj );
        bomb_work.parent_obj = parent_obj;
        bomb_work.bomb_type = bomb_type;
        bomb_work.interval_timer = 0U;
        bomb_work.interval_min = interval_min;
        bomb_work.interval_max = interval_max;
        bomb_work.pos[0] = pos_x;
        bomb_work.pos[1] = pos_y;
        bomb_work.area[0] = width;
        bomb_work.area[1] = height;
        bomb_work.interval_timer_sound = 0;
    }

    // Token: 0x06001509 RID: 5385 RVA: 0x000B82CC File Offset: 0x000B64CC
    private static void gmBoss1EffBombUpdateCreate( AppMain.GMS_BOSS1_EFF_BOMB_WORK bomb_work )
    {
        AppMain.MTM_ASSERT( bomb_work.parent_obj );
        if ( bomb_work.interval_timer != 0U )
        {
            bomb_work.interval_timer -= 1U;
            return;
        }
        int num = bomb_work.area[0];
        int num2 = bomb_work.area[1];
        int num3 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num);
        int num4 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num2);
        int bomb_type = bomb_work.bomb_type;
        if ( bomb_type == 0 )
        {
            AppMain.GMS_EFFECT_3DES_WORK obj = AppMain.GmEfctCmnEsCreate(null, 7);
            if ( --bomb_work.interval_timer_sound <= 0 )
            {
                bomb_work.interval_timer_sound = 3;
                AppMain.GmSoundPlaySE( "Boss0_02" );
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(obj);
            AppMain.MTM_ASSERT( obs_OBJECT_WORK );
            obs_OBJECT_WORK.pos.x = bomb_work.pos[0] - ( num >> 1 ) + num3;
            obs_OBJECT_WORK.pos.y = bomb_work.pos[1] - ( num2 >> 1 ) + num4;
            obs_OBJECT_WORK.pos.z = AppMain.GMM_BS_OBJ( bomb_work.parent_obj ).pos.z + 131072;
            uint num5 = (uint)((long)AppMain.AkMathRandFx() * (long)((ulong)(bomb_work.interval_max - bomb_work.interval_min)) >> 12);
            bomb_work.interval_timer = bomb_work.interval_min + num5;
            return;
        }
        AppMain.MTM_ASSERT( false );
    }

    // Token: 0x0600150A RID: 5386 RVA: 0x000B8400 File Offset: 0x000B6600
    private static void gmBoss1EffDamageInit( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK obj = AppMain.GmEfctBossCmnEsCreate(parent_obj, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(obj);
        obs_OBJECT_WORK.pos.z = obs_OBJECT_WORK.pos.z + 131072;
    }

    // Token: 0x0600150B RID: 5387 RVA: 0x000B8438 File Offset: 0x000B6638
    private static void gmBoss1EffAfterburnerSetEnable( AppMain.GMS_BOSS1_BODY_WORK body_work, bool is_enable )
    {
        if ( is_enable )
        {
            AppMain.MTM_ASSERT( 0U == ( body_work.flag & 16U ) );
            AppMain.MTM_ASSERT( 0U == ( body_work.flag & 33554432U ) );
            body_work.flag |= 33554432U;
            return;
        }
        body_work.flag &= 4294967279U;
        body_work.flag &= 4261412863U;
    }

    // Token: 0x0600150C RID: 5388 RVA: 0x000B84A1 File Offset: 0x000B66A1
    private static void gmBoss1EffAfterburnerUpdateCreate( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 33554432U ) != 0U )
        {
            body_work.flag &= 4261412863U;
            body_work.flag |= 16U;
            AppMain.gmBoss1EffAfterburnerInit( body_work );
        }
    }

    // Token: 0x0600150D RID: 5389 RVA: 0x000B84D8 File Offset: 0x000B66D8
    private static void gmBoss1EffAfterburnerInit( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 4U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -30f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffAfterburnerProcMain );
    }

    // Token: 0x0600150E RID: 5390 RVA: 0x000B8520 File Offset: 0x000B6720
    private static void gmBoss1EffAfterburnerProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS1_BODY_WORK.snm_work.reg_node_max );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS1_BODY_WORK.flag & 16U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS1_BODY_WORK.snm_work, gms_BOSS1_BODY_WORK.body_snm_reg_id, 1 );
    }

    // Token: 0x0600150F RID: 5391 RVA: 0x000B8588 File Offset: 0x000B6788
    private static void gmBoss1EffABSmokeInit( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 5U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffABSmokeProcMain );
    }

    // Token: 0x06001510 RID: 5392 RVA: 0x000B85D0 File Offset: 0x000B67D0
    private static void gmBoss1EffABSmokeProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS1_BODY_WORK.snm_work.reg_node_max );
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS1_BODY_WORK.snm_work, gms_BOSS1_BODY_WORK.body_snm_reg_id, 1 );
    }

    // Token: 0x06001511 RID: 5393 RVA: 0x000B860C File Offset: 0x000B680C
    private static void gmBoss1EffBodySmokeInit( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 3U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffBodySmokeProcMain );
    }

    // Token: 0x06001512 RID: 5394 RVA: 0x000B8654 File Offset: 0x000B6854
    private static void gmBoss1EffBodySmokeProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS1_BODY_WORK.snm_work.reg_node_max );
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS1_BODY_WORK.snm_work, gms_BOSS1_BODY_WORK.body_snm_reg_id, 1 );
    }

    // Token: 0x06001513 RID: 5395 RVA: 0x000B8690 File Offset: 0x000B6890
    private static void gmBoss1EffBodySmallSmokeInit( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 2U);
            AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, AppMain.gm_boss1_eff_small_smoke_disp_ofst_tbl[i][0], AppMain.gm_boss1_eff_small_smoke_disp_ofst_tbl[i][1], AppMain.gm_boss1_eff_small_smoke_disp_ofst_tbl[i][2] );
            AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffBodySmallSmokeProcMain );
        }
    }

    // Token: 0x06001514 RID: 5396 RVA: 0x000B86F0 File Offset: 0x000B68F0
    private static void gmBoss1EffBodySmallSmokeProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_BODY_WORK gms_BOSS1_BODY_WORK = (AppMain.GMS_BOSS1_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS1_BODY_WORK.snm_work.reg_node_max );
        obj_work.flag &= 4294966271U;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS1_BODY_WORK.snm_work, gms_BOSS1_BODY_WORK.body_snm_reg_id, 1 );
    }

    // Token: 0x06001515 RID: 5397 RVA: 0x000B8740 File Offset: 0x000B6940
    private static void gmBoss1EffBodyDebrisInit( AppMain.GMS_BOSS1_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctBossCmnEsCreate(AppMain.GMM_BS_OBJ(body_work), 1U);
        obs_OBJECT_WORK.parent_ofst.x = -65536;
    }

    // Token: 0x06001516 RID: 5398 RVA: 0x000B8770 File Offset: 0x000B6970
    private static void gmBoss1EffSweatInit( AppMain.GMS_BOSS1_EGG_WORK egg_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(egg_work), 93);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 32f, 0f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1EffSweatProcMain );
        egg_work.flag |= 2U;
    }

    // Token: 0x06001517 RID: 5399 RVA: 0x000B87C8 File Offset: 0x000B69C8
    private static void gmBoss1EffSweatProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_EGG_WORK gms_BOSS1_EGG_WORK = (AppMain.GMS_BOSS1_EGG_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( gms_BOSS1_EGG_WORK );
        if ( ( gms_BOSS1_EGG_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06001518 RID: 5400 RVA: 0x000B8818 File Offset: 0x000B6A18
    private static void gmBoss1InitFlashScreen()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_BOSS1_FLASH_SCREEN_WORK(), null, 0, "boss1_flash_scr");
        AppMain.GMS_BOSS1_FLASH_SCREEN_WORK gms_BOSS1_FLASH_SCREEN_WORK = (AppMain.GMS_BOSS1_FLASH_SCREEN_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.disp_flag |= 4128U;
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.GmBsCmnInitFlashScreen( gms_BOSS1_FLASH_SCREEN_WORK.flash_work, 4f, 5f, 30f );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss1FlashScreenMain );
    }

    // Token: 0x06001519 RID: 5401 RVA: 0x000B88A4 File Offset: 0x000B6AA4
    private static void gmBoss1FlashScreenMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS1_FLASH_SCREEN_WORK gms_BOSS1_FLASH_SCREEN_WORK = (AppMain.GMS_BOSS1_FLASH_SCREEN_WORK)obj_work;
        if ( AppMain.GmBsCmnUpdateFlashScreen( gms_BOSS1_FLASH_SCREEN_WORK.flash_work ) != 0 )
        {
            AppMain.GmBsCmnClearFlashScreen( gms_BOSS1_FLASH_SCREEN_WORK.flash_work );
            obj_work.flag |= 4U;
        }
    }
}