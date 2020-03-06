using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000320 RID: 800
    public class GMS_BOSS4_BODY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002585 RID: 9605 RVA: 0x0014D954 File Offset: 0x0014BB54
        public GMS_BOSS4_BODY_WORK()
        {
            uint[] array = new uint[1];
            this.flag = array;
            this.reserved = new ushort[1];
            this.node_work = new AppMain.GMS_BOSS4_NODE_MATRIX();
            this.cnm_mgr_work = new AppMain.GMS_BS_CMN_CNM_MGR_WORK();
            this.flk_work = new AppMain.GMS_BS_CMN_DMG_FLICKER_WORK();
            this.se_timer = new AppMain.GMS_BOSS4_1SHOT_TIMER();
            this.move_work = new AppMain.GMS_BOSS4_MOVE();
            this.dir = new AppMain.GMS_BOSS4_DIRECTION();
            this.bomb_work = new AppMain.GMS_BOSS4_EFF_BOMB_WORK();
            this.bomb_work2 = new AppMain.GMS_BOSS4_EFF_BOMB_WORK();
            this.parts_objs = new AppMain.OBS_OBJECT_WORK[2];
            this.mtn_suspend = AppMain.New<AppMain.GMS_BOSS4_MTN_SUSPEND_WORK>( 2 );
            this.nohit_work = new AppMain.GMS_BOSS4_NOHIT_TIMER();
            this.flash_work = new AppMain.GMS_CMN_FLASH_SCR_WORK();
            //base..ctor();
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002586 RID: 9606 RVA: 0x0014DA13 File Offset: 0x0014BC13
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002587 RID: 9607 RVA: 0x0014DA25 File Offset: 0x0014BC25
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS4_BODY_WORK work )
        {
            if ( work == null )
            {
                return null;
            }
            return work.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002588 RID: 9608 RVA: 0x0014DA3C File Offset: 0x0014BC3C
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_BOSS4_BODY_WORK work )
        {
            return work.ene_3d.ene_com;
        }

        // Token: 0x06002589 RID: 9609 RVA: 0x0014DA49 File Offset: 0x0014BC49
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_BOSS4_BODY_WORK work )
        {
            return work.ene_3d;
        }

        // Token: 0x04005DD1 RID: 24017
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005DD2 RID: 24018
        public int state;

        // Token: 0x04005DD3 RID: 24019
        public int prev_state;

        // Token: 0x04005DD4 RID: 24020
        public AppMain.GMS_BOSS4_MGR_WORK mgr_work;

        // Token: 0x04005DD5 RID: 24021
        public AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK proc_update;

        // Token: 0x04005DD6 RID: 24022
        public readonly uint[] flag;

        // Token: 0x04005DD7 RID: 24023
        public int whole_act_id;

        // Token: 0x04005DD8 RID: 24024
        public int egg_revert_mtn_id;

        // Token: 0x04005DD9 RID: 24025
        public readonly ushort[] reserved;

        // Token: 0x04005DDA RID: 24026
        public uint wait_timer;

        // Token: 0x04005DDB RID: 24027
        public uint wait_timer2;

        // Token: 0x04005DDC RID: 24028
        public readonly AppMain.GMS_BOSS4_NODE_MATRIX node_work;

        // Token: 0x04005DDD RID: 24029
        public readonly AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work;

        // Token: 0x04005DDE RID: 24030
        public int chaintop_cnm_reg_id;

        // Token: 0x04005DDF RID: 24031
        public readonly AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work;

        // Token: 0x04005DE0 RID: 24032
        public readonly AppMain.GMS_BOSS4_1SHOT_TIMER se_timer;

        // Token: 0x04005DE1 RID: 24033
        public uint se_cnt;

        // Token: 0x04005DE2 RID: 24034
        public int move_time;

        // Token: 0x04005DE3 RID: 24035
        public int move_cnt;

        // Token: 0x04005DE4 RID: 24036
        public readonly AppMain.GMS_BOSS4_MOVE move_work;

        // Token: 0x04005DE5 RID: 24037
        public readonly AppMain.GMS_BOSS4_DIRECTION dir;

        // Token: 0x04005DE6 RID: 24038
        public int drift_pivot_x;

        // Token: 0x04005DE7 RID: 24039
        public int drift_angle;

        // Token: 0x04005DE8 RID: 24040
        public int drift_ang_spd;

        // Token: 0x04005DE9 RID: 24041
        public int drift_timer;

        // Token: 0x04005DEA RID: 24042
        public int atk_nml_alt;

        // Token: 0x04005DEB RID: 24043
        public AppMain.VecFx32 bash_targ_pos;

        // Token: 0x04005DEC RID: 24044
        public AppMain.VecFx32 bash_ret_pos;

        // Token: 0x04005DED RID: 24045
        public AppMain.VecFx32 bash_orig_pos;

        // Token: 0x04005DEE RID: 24046
        public int bash_homing_deg;

        // Token: 0x04005DEF RID: 24047
        public int damage_timer;

        // Token: 0x04005DF0 RID: 24048
        public readonly AppMain.GMS_BOSS4_EFF_BOMB_WORK bomb_work;

        // Token: 0x04005DF1 RID: 24049
        public readonly AppMain.GMS_BOSS4_EFF_BOMB_WORK bomb_work2;

        // Token: 0x04005DF2 RID: 24050
        public readonly AppMain.OBS_OBJECT_WORK[] parts_objs;

        // Token: 0x04005DF3 RID: 24051
        public readonly AppMain.GMS_BOSS4_MTN_SUSPEND_WORK[] mtn_suspend;

        // Token: 0x04005DF4 RID: 24052
        public readonly AppMain.GMS_BOSS4_NOHIT_TIMER nohit_work;

        // Token: 0x04005DF5 RID: 24053
        public readonly AppMain.GMS_CMN_FLASH_SCR_WORK flash_work;

        // Token: 0x04005DF6 RID: 24054
        public int avoid_timer;

        // Token: 0x04005DF7 RID: 24055
        public int avoid_yspd;
    }

    // Token: 0x02000321 RID: 801
    // (Invoke) Token: 0x0600258B RID: 9611
    public delegate void GMF_BOSS4_BODY_STATE_ENTER_FUNC( AppMain.GMS_BOSS4_BODY_WORK bodeWork );

    // Token: 0x02000322 RID: 802
    // (Invoke) Token: 0x0600258F RID: 9615
    public delegate void GMF_BOSS4_BODY_STATE_LEAVE_FUNC( AppMain.GMS_BOSS4_BODY_WORK bodyWork );

    // Token: 0x02000323 RID: 803
    public class GMS_BOSS4_BODY_STATE_ENTER_INFO
    {
        // Token: 0x06002592 RID: 9618 RVA: 0x0014DA51 File Offset: 0x0014BC51
        public GMS_BOSS4_BODY_STATE_ENTER_INFO( AppMain.GMF_BOSS4_BODY_STATE_ENTER_FUNC _enter_func, bool _is_wrapped )
        {
            this.enter_func = _enter_func;
            this.is_wrapped = _is_wrapped;
        }

        // Token: 0x04005DF8 RID: 24056
        public AppMain.GMF_BOSS4_BODY_STATE_ENTER_FUNC enter_func;

        // Token: 0x04005DF9 RID: 24057
        public bool is_wrapped;
    }

    // Token: 0x1700004A RID: 74
    // (get) Token: 0x060015B2 RID: 5554 RVA: 0x000BD5B0 File Offset: 0x000BB7B0
    public static float GMD_BOSS4_BODY_START_POS_Y
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<float>( -120f, 1480f );
        }
    }

    // Token: 0x1700004B RID: 75
    // (get) Token: 0x060015B3 RID: 5555 RVA: 0x000BD5C1 File Offset: 0x000BB7C1
    public static float GMD_BOSS4_BODY_END_POS_Y
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<float>( 280f, 1880f );
        }
    }

    // Token: 0x1700004C RID: 76
    // (get) Token: 0x060015B4 RID: 5556 RVA: 0x000BD5D2 File Offset: 0x000BB7D2
    public static int GMD_BOSS4_SPEED_TIMES_IN_DAMAGE
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 5f );
        }
    }

    // Token: 0x1700004D RID: 77
    // (get) Token: 0x060015B5 RID: 5557 RVA: 0x000BD5DE File Offset: 0x000BB7DE
    public static float GMD_BOSS4_BODY_PRE_ATKNML_SPD_ADD
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.02f );
        }
    }

    // Token: 0x1700004E RID: 78
    // (get) Token: 0x060015B6 RID: 5558 RVA: 0x000BD5EA File Offset: 0x000BB7EA
    public static int GMD_BOSS4_BODY_PRE_ATKNML_SPD_MAX_ABS
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 1f );
        }
    }

    // Token: 0x1700004F RID: 79
    // (get) Token: 0x060015B7 RID: 5559 RVA: 0x000BD5F6 File Offset: 0x000BB7F6
    public static int GMD_BOSS4_BODY_ATKNML_MOVE_FRAME
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 720f );
        }
    }

    // Token: 0x17000050 RID: 80
    // (get) Token: 0x060015B8 RID: 5560 RVA: 0x000BD602 File Offset: 0x000BB802
    public static int GMD_BOSS4_BODY_ATKNML_DRIFT_FRAME
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 30f );
        }
    }

    // Token: 0x17000051 RID: 81
    // (get) Token: 0x060015B9 RID: 5561 RVA: 0x000BD60E File Offset: 0x000BB80E
    public static int GMD_BOSS4_BODY_ATKNML_TURN_FRAME
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 28f );
        }
    }

    // Token: 0x17000052 RID: 82
    // (get) Token: 0x060015BA RID: 5562 RVA: 0x000BD61A File Offset: 0x000BB81A
    public static int GMD_BOSS4_BODY_2ND_POS_X
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 3500, 12100 );
        }
    }

    // Token: 0x17000053 RID: 83
    // (get) Token: 0x060015BB RID: 5563 RVA: 0x000BD62B File Offset: 0x000BB82B
    public static int GMD_BOSS4_BODY_2ND_POS_Y
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 250, 1850 );
        }
    }

    // Token: 0x17000054 RID: 84
    // (get) Token: 0x060015BC RID: 5564 RVA: 0x000BD63C File Offset: 0x000BB83C
    public static uint GMD_BOSS4_BODY_SONIC_CTRL_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 240f );
        }
    }

    // Token: 0x17000055 RID: 85
    // (get) Token: 0x060015BD RID: 5565 RVA: 0x000BD648 File Offset: 0x000BB848
    public static uint GMD_BOSS4_BODY_CREATE_CAP_FIRST_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 120f );
        }
    }

    // Token: 0x17000056 RID: 86
    // (get) Token: 0x060015BE RID: 5566 RVA: 0x000BD654 File Offset: 0x000BB854
    public static float GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_X_1
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -1f );
        }
    }

    // Token: 0x17000057 RID: 87
    // (get) Token: 0x060015BF RID: 5567 RVA: 0x000BD660 File Offset: 0x000BB860
    public static float GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_Y_1
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2f );
        }
    }

    // Token: 0x17000058 RID: 88
    // (get) Token: 0x060015C0 RID: 5568 RVA: 0x000BD66C File Offset: 0x000BB86C
    public static float GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_X_2
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2f );
        }
    }

    // Token: 0x17000059 RID: 89
    // (get) Token: 0x060015C1 RID: 5569 RVA: 0x000BD678 File Offset: 0x000BB878
    public static float GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_Y_2
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2f );
        }
    }

    // Token: 0x1700005A RID: 90
    // (get) Token: 0x060015C2 RID: 5570 RVA: 0x000BD684 File Offset: 0x000BB884
    public static uint GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_3
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 300f );
        }
    }

    // Token: 0x1700005B RID: 91
    // (get) Token: 0x060015C3 RID: 5571 RVA: 0x000BD690 File Offset: 0x000BB890
    public static uint GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_2
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 180f );
        }
    }

    // Token: 0x1700005C RID: 92
    // (get) Token: 0x060015C4 RID: 5572 RVA: 0x000BD69C File Offset: 0x000BB89C
    public static uint GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_1
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 120f );
        }
    }

    // Token: 0x1700005D RID: 93
    // (get) Token: 0x060015C5 RID: 5573 RVA: 0x000BD6A8 File Offset: 0x000BB8A8
    public static uint GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_2_2
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 90f );
        }
    }

    // Token: 0x1700005E RID: 94
    // (get) Token: 0x060015C6 RID: 5574 RVA: 0x000BD6B4 File Offset: 0x000BB8B4
    public static uint GMD_BOSS4_BODY_DEFEAT_BOMB_SMALL_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 120f );
        }
    }

    // Token: 0x1700005F RID: 95
    // (get) Token: 0x060015C7 RID: 5575 RVA: 0x000BD6C0 File Offset: 0x000BB8C0
    public static uint GMD_BOSS4_BODY_DEFEAT_BOMB_SMALL_INTERVAL_MIN_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 10f );
        }
    }

    // Token: 0x17000060 RID: 96
    // (get) Token: 0x060015C8 RID: 5576 RVA: 0x000BD6CC File Offset: 0x000BB8CC
    public static uint GMD_BOSS4_BODY_DEFEAT_BOMB_SMALL_INTERVAL_MAX_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 30f );
        }
    }

    // Token: 0x17000061 RID: 97
    // (get) Token: 0x060015C9 RID: 5577 RVA: 0x000BD6D8 File Offset: 0x000BB8D8
    public static uint GMD_BOSS4_BODY_DEFEAT_BOMB_PARTS_INTERVAL_MIN_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 10f );
        }
    }

    // Token: 0x17000062 RID: 98
    // (get) Token: 0x060015CA RID: 5578 RVA: 0x000BD6E4 File Offset: 0x000BB8E4
    public static uint GMD_BOSS4_BODY_DEFEAT_BOMB_PARTS_INTERVAL_MAX_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 30f );
        }
    }

    // Token: 0x060015CB RID: 5579 RVA: 0x000BD6F0 File Offset: 0x000BB8F0
    public static AppMain.GMS_BOSS4_MGR_WORK GMM_BOSS4_MGR( AppMain.GMS_BOSS4_BODY_WORK work )
    {
        return work.mgr_work;
    }

    // Token: 0x060015CC RID: 5580 RVA: 0x000BD6F8 File Offset: 0x000BB8F8
    private static void GmBoss4BodyBuild()
    {
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 730 ), 2, AppMain.GMD_BOSS4_ARC );
    }

    // Token: 0x060015CD RID: 5581 RVA: 0x000BD710 File Offset: 0x000BB910
    private static void GmBoss4BodyFlush()
    {
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 730 ) );
    }

    // Token: 0x060015CE RID: 5582 RVA: 0x000BD728 File Offset: 0x000BB928
    private static AppMain.OBS_OBJECT_WORK GmBoss4BodyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS4_BODY_WORK(), "BOSS4_BODY");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.pos.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_START_POS_Y );
        obs_OBJECT_WORK.pos.z = -131072;
        gms_BOSS4_BODY_WORK.atk_nml_alt = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_END_POS_Y );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194309U;
        obs_OBJECT_WORK.move_flag |= 4096U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        gms_ENEMY_3D_WORK.ene_com.vit = 1;
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[0], -40, -16, 40, 2 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4BodyDamageDefFunc );
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[1], -32, -8, 32, 40 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4BodyAtkHitFunc );
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[2], -30, -18, 30, 40 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4BodyDefHitFunc );
        AppMain.ObjRectGroupSet( gms_ENEMY_3D_WORK.ene_com.rect_work[2], 1, 1 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294965247U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag |= 4U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 0 ), gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 730 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4BodyWaitLoad );
        AppMain.gmBoss4BodyChangeState( gms_BOSS4_BODY_WORK, 0 );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4BodyOutFunc );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss4BodyExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060015CF RID: 5583 RVA: 0x000BD9A0 File Offset: 0x000BBBA0
    private static void gmBoss4BodyExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obs_OBJECT_WORK;
        AppMain.GmBoss4DecObjCreateCount();
        AppMain.GmBoss4UtilExitNodeMatrix( gms_BOSS4_BODY_WORK.node_work );
        AppMain.GmBsCmnClearCNMCb( obs_OBJECT_WORK );
        AppMain.GmBsCmnDeleteCNMMgrWork( gms_BOSS4_BODY_WORK.cnm_mgr_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060015D0 RID: 5584 RVA: 0x000BD9E2 File Offset: 0x000BBBE2
    private static void gmBoss4BodySetActionWhole( AppMain.GMS_BOSS4_BODY_WORK body_work, int act_id )
    {
        AppMain.gmBoss4BodySetActionWhole( body_work, act_id, false );
    }

    // Token: 0x060015D1 RID: 5585 RVA: 0x000BD9EC File Offset: 0x000BBBEC
    private static void gmBoss4BodySetActionWhole( AppMain.GMS_BOSS4_BODY_WORK body_work, int act_id, bool force_change )
    {
        AppMain.GMS_BOSS4_PART_ACT_INFO[] array = AppMain.gm_boss4_act_id_tbl[act_id];
        if ( !force_change && body_work.whole_act_id == act_id )
        {
            return;
        }
        body_work.whole_act_id = act_id;
        for ( int i = 0; i < 2; i++ )
        {
            if ( body_work.parts_objs[i] != null )
            {
                if ( i == 1 )
                {
                    AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)body_work.parts_objs[i];
                    body_work.egg_revert_mtn_id = act_id;
                    ushort act_id2 = AppMain.GmBoss4GetActInfo(body_work.egg_revert_mtn_id, 1).act_id;
                    if ( act_id2 == 4 )
                    {
                        if ( AppMain.GmBoss4Is2ndStage() )
                        {
                            body_work.egg_revert_mtn_id = 5;
                        }
                        else
                        {
                            body_work.egg_revert_mtn_id = 3;
                        }
                    }
                    if ( ( gms_BOSS4_EGG_WORK.flag & 1U ) != 0U )
                    {
                        goto IL_107;
                    }
                }
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
            IL_107:;
        }
    }

    // Token: 0x060015D2 RID: 5586 RVA: 0x000BDB0B File Offset: 0x000BBD0B
    private static void gmBoss4BodyUpdateSuspendAction( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
    }

    // Token: 0x060015D3 RID: 5587 RVA: 0x000BDB10 File Offset: 0x000BBD10
    private static void gmBoss4BodyExecDamageRoutine( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GMS_BOSS4_MGR_WORK mgr_work = body_work.mgr_work;
        AppMain.MTM_ASSERT( mgr_work );
        if ( body_work.damage_timer > 0 )
        {
            return;
        }
        if ( mgr_work.life != 0 )
        {
            mgr_work.life--;
        }
        if ( 0 < mgr_work.life )
        {
            body_work.flag[0] |= 1073741824U;
            if ( 1 >= mgr_work.life )
            {
                AppMain.GmDecoStartLoop();
            }
        }
        else
        {
            body_work.flag[0] |= 2147483648U;
        }
        body_work.damage_timer = 60;
        AppMain.GmBoss4CapsuleSetInvincible( 30 );
        AppMain.gmBoss4BodySetActionWhole( body_work, 6, true );
    }

    // Token: 0x060015D4 RID: 5588 RVA: 0x000BDBB4 File Offset: 0x000BBDB4
    private static bool gmBoss4BodyIsExtraAttack( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        return AppMain.GMM_BOSS4_MGR( body_work ).life <= AppMain.GMD_BOSS4_EXTRA_ATK_THRESHOLD_LIFE;
    }

    // Token: 0x060015D5 RID: 5589 RVA: 0x000BDBCB File Offset: 0x000BBDCB
    private static void gmBoss4BodyInitPreANChainMotion( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x060015D6 RID: 5590 RVA: 0x000BDBD4 File Offset: 0x000BBDD4
    private static void gmBoss4BodyInitPreANMove( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.spd.x = 0;
        obs_OBJECT_WORK.spd_add.x = -AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_PRE_ATKNML_SPD_ADD );
    }

    // Token: 0x060015D7 RID: 5591 RVA: 0x000BDC0C File Offset: 0x000BBE0C
    private static bool gmBoss4BodyUpdatePreANMoveLeft( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool flag = false;
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) >= AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_PRE_ATKNML_SPD_MAX_ABS ) )
        {
            obs_OBJECT_WORK.spd.x = -AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_PRE_ATKNML_SPD_MAX_ABS );
            obs_OBJECT_WORK.spd_add.x = 0;
        }
        if ( obs_OBJECT_WORK.pos.x <= AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32( 74f ) )
        {
            obs_OBJECT_WORK.pos.x = AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32( 74f );
            flag = true;
        }
        if ( flag )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        }
        return flag;
    }

    // Token: 0x060015D8 RID: 5592 RVA: 0x000BDCA8 File Offset: 0x000BBEA8
    private static bool gmBoss4BodyUpdatePreANMoveRight( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool flag = false;
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) >= AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_PRE_ATKNML_SPD_MAX_ABS ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_PRE_ATKNML_SPD_MAX_ABS );
            obs_OBJECT_WORK.spd_add.x = 0;
        }
        if ( obs_OBJECT_WORK.pos.x >= AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32( 310f ) )
        {
            obs_OBJECT_WORK.pos.x = AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32( 310f );
            flag = true;
        }
        if ( flag )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        }
        return flag;
    }

    // Token: 0x060015D9 RID: 5593 RVA: 0x000BDD41 File Offset: 0x000BBF41
    private static void gmBoss4BodySetANChainInitialBlendSpd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
    }

    // Token: 0x060015DA RID: 5594 RVA: 0x000BDD43 File Offset: 0x000BBF43
    private static void gmBoss4BodyInitAtkNmlMove( AppMain.GMS_BOSS4_BODY_WORK body_work, int frame )
    {
        body_work.move_time = frame;
        body_work.move_cnt = 0;
        AppMain.gmBoss4BodyUpdateAtkNmlMove( body_work );
    }

    // Token: 0x060015DB RID: 5595 RVA: 0x000BDD5C File Offset: 0x000BBF5C
    private static bool gmBoss4BodyUpdateAtkNmlMove( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32(74f);
        int num2 = AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32(310f);
        if ( body_work.dir.direction == 1 )
        {
            int num3 = num;
            num = num2;
            num2 = num3;
        }
        bool result;
        if ( body_work.move_cnt < body_work.move_time )
        {
            int gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH = AppMain.GMD_BOSS4_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH;
            int gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_START_ANGLE = AppMain.GMD_BOSS4_BODY_ATKNML_MOVE_CURVE_START_ANGLE;
            body_work.move_cnt++;
            int num4 = (int)((float)gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH / (float)body_work.move_time);
            float num5 = AppMain.nnCos(gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_START_ANGLE) - AppMain.nnCos(gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_START_ANGLE + gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_ANGLE_WIDTH);
            float num6 = (AppMain.nnCos(gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_START_ANGLE) - AppMain.nnCos(gmd_BOSS4_BODY_ATKNML_MOVE_CURVE_START_ANGLE + num4 * body_work.move_cnt)) / num5;
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

    // Token: 0x060015DC RID: 5596 RVA: 0x000BDE3C File Offset: 0x000BC03C
    private static void gmBoss4BodySetFlipForAtkNmlMove( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.GMM_BOSS4_AREA_CENTER_X();
        if ( obs_OBJECT_WORK.pos.x < num )
        {
            body_work.dir.direction = 0;
            return;
        }
        body_work.dir.direction = 1;
    }

    // Token: 0x060015DD RID: 5597 RVA: 0x000BDE80 File Offset: 0x000BC080
    private static void gmBoss4BodyInitAtkNmlFlipAndTurn( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        int gmd_BOSS4_BODY_ATKNML_TURN_FRAME = AppMain.GMD_BOSS4_BODY_ATKNML_TURN_FRAME;
        AppMain.MTM_ASSERT( gmd_BOSS4_BODY_ATKNML_TURN_FRAME < AppMain.GMD_BOSS4_BODY_ATKNML_DRIFT_FRAME );
        AppMain.gmBoss4BodySetFlipForAtkNmlMove( body_work );
        if ( body_work.dir.direction == 1 )
        {
            AppMain.GmBoss4UtilInitTurnGently( body_work.dir, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, gmd_BOSS4_BODY_ATKNML_TURN_FRAME, true );
            return;
        }
        AppMain.GmBoss4UtilInitTurnGently( body_work.dir, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE, gmd_BOSS4_BODY_ATKNML_TURN_FRAME, false );
    }

    // Token: 0x060015DE RID: 5598 RVA: 0x000BDED9 File Offset: 0x000BC0D9
    private static bool gmBoss4BodyUpdateAtkNmlFlipAndTurn( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        return AppMain.GmBoss4UtilUpdateTurnGently( body_work.dir );
    }

    // Token: 0x060015DF RID: 5599 RVA: 0x000BDEE8 File Offset: 0x000BC0E8
    private static void gmBoss4BodyInitAtkNmlDrift( AppMain.GMS_BOSS4_BODY_WORK body_work, int frame )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.MTM_ASSERT( frame > 0 );
        AppMain.GmBsCmnSetObjSpdZero( obj_work );
        body_work.drift_angle = 0;
        body_work.drift_ang_spd = ( int )AppMain.nnRoundOff( ( float )AppMain.AKM_DEGtoA32( 180f ) / ( float )frame + 0.5f );
        body_work.drift_timer = frame;
        if ( body_work.dir.direction == 1 )
        {
            body_work.drift_pivot_x = AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32( 310f );
        }
        else
        {
            body_work.drift_pivot_x = AppMain.GMM_BOSS4_AREA_LEFT() + AppMain.FX_F32_TO_FX32( 74f );
        }
        AppMain.gmBoss4BodyUpdateAtkNmlDrift( body_work );
    }

    // Token: 0x060015E0 RID: 5600 RVA: 0x000BDF7C File Offset: 0x000BC17C
    private static bool gmBoss4BodyUpdateAtkNmlDrift( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num;
        bool result;
        if ( body_work.drift_timer != 0 )
        {
            body_work.drift_timer--;
            body_work.drift_angle = ( int )( 65535L & ( long )( body_work.drift_angle + body_work.drift_ang_spd ) );
            num = AppMain.FX_Mul( AppMain.FX_Sin( body_work.drift_angle ), AppMain.FX_F32_TO_FX32( 16f ) );
            result = false;
        }
        else
        {
            num = 0;
            result = true;
        }
        if ( body_work.dir.direction == 0 )
        {
            num = -num;
        }
        obs_OBJECT_WORK.pos.x = body_work.drift_pivot_x + num;
        return result;
    }

    // Token: 0x060015E1 RID: 5601 RVA: 0x000BE00C File Offset: 0x000BC20C
    private static void gmBoss4BodyInitEscapeMove( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.spd.x = 0;
        if ( body_work.dir.direction == 1 )
        {
            obs_OBJECT_WORK.spd_add.x = -409;
        }
        else
        {
            obs_OBJECT_WORK.spd_add.x = 409;
        }
        obs_OBJECT_WORK.spd_add.y = 204;
    }

    // Token: 0x060015E2 RID: 5602 RVA: 0x000BE06C File Offset: 0x000BC26C
    private static bool gmBoss4BodyUpdateEscapeMove( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool flag = false;
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) >= 11264 )
        {
            obs_OBJECT_WORK.spd.x = 11264;
            obs_OBJECT_WORK.spd.y = -1536;
            obs_OBJECT_WORK.spd_add.x = 0;
            obs_OBJECT_WORK.spd_add.y = 0;
        }
        float num = (float)AppMain.g_gm_main_system.map_fcol.right;
        if ( obs_OBJECT_WORK.pos.x > AppMain.FX_F32_TO_FX32( num + 100f ) )
        {
            flag = true;
        }
        if ( flag )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        }
        return flag;
    }

    // Token: 0x060015E3 RID: 5603 RVA: 0x000BE108 File Offset: 0x000BC308
    private static void gmBoss4BodyInitDefeatState( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        bool flag = false;
        if ( ( body_work.flag[0] & 1U ) != 0U )
        {
            flag = true;
        }
        AppMain.gmBoss4BodyChangeState( body_work, 7, true );
        if ( flag )
        {
            body_work.flag[0] |= 1U;
        }
        else
        {
            body_work.flag[0] &= 4294967294U;
        }
        AppMain.GmSoundChangeWinBossBGM();
    }

    // Token: 0x060015E4 RID: 5604 RVA: 0x000BE16A File Offset: 0x000BC36A
    private static void gmBoss4BodyUpdateChainTopDirection( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
    }

    // Token: 0x060015E5 RID: 5605 RVA: 0x000BE16C File Offset: 0x000BC36C
    private static void gmBoss4BodyAtkHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)my_rect.parent_obj;
        gms_BOSS4_BODY_WORK.flag[0] |= 268435456U;
        AppMain.GmEnemyDefaultAtkFunc( my_rect, your_rect );
    }

    // Token: 0x060015E6 RID: 5606 RVA: 0x000BE1AC File Offset: 0x000BC3AC
    private static void gmBoss4BodyDamageDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)parent_obj;
        if ( parent_obj2 != null && 1 == parent_obj2.obj_type )
        {
            AppMain.GmBoss4UtilSetPlayerAttackReaction( parent_obj2, parent_obj );
            if ( gms_BOSS4_BODY_WORK.nohit_work.timer == 0U )
            {
                AppMain.GmSoundPlaySE( "Boss0_01" );
                AppMain.gmBoss4EffDamageInit( gms_BOSS4_BODY_WORK );
                AppMain.gmBoss4BodyExecDamageRoutine( gms_BOSS4_BODY_WORK );
                if ( AppMain.GmBoss4Is2ndStage() )
                {
                    AppMain.GmBoss4ChibiExplosion();
                    gms_BOSS4_BODY_WORK.wait_timer = 60U;
                    gms_BOSS4_BODY_WORK.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2nd );
                }
                AppMain.GMM_PAD_VIB_SMALL_TIME( 30f );
            }
            AppMain.GmBoss4UtilInitNoHitTimer( gms_BOSS4_BODY_WORK.nohit_work, ( AppMain.GMS_ENEMY_COM_WORK )parent_obj, 10 );
        }
    }

    // Token: 0x060015E7 RID: 5607 RVA: 0x000BE248 File Offset: 0x000BC448
    private static void gmBoss4BodyDefHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        parent_obj2.pos.x = parent_obj2.pos.x - parent_obj2.move.x;
        if ( parent_obj.pos.x > parent_obj2.pos.x )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = parent_obj2;
            obs_OBJECT_WORK.pos.x = obs_OBJECT_WORK.pos.x - AppMain.FX_F32_TO_FX32( 2f );
            parent_obj2.spd.x = -AppMain.MTM_MATH_ABS( parent_obj2.spd.x );
            parent_obj2.spd_m = -AppMain.MTM_MATH_ABS( parent_obj2.spd_m );
        }
        if ( parent_obj.pos.x < parent_obj2.pos.x )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = parent_obj2;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + AppMain.FX_F32_TO_FX32( 2f );
            parent_obj2.spd.x = AppMain.MTM_MATH_ABS( parent_obj2.spd.x );
            parent_obj2.spd_m = AppMain.MTM_MATH_ABS( parent_obj2.spd_m );
        }
    }

    // Token: 0x060015E8 RID: 5608 RVA: 0x000BE348 File Offset: 0x000BC548
    private static void gmBoss4BodyOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work;
        AppMain.GmBsCmnUpdateCNMParam( obj_work, gms_BOSS4_BODY_WORK.cnm_mgr_work );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x060015E9 RID: 5609 RVA: 0x000BE36E File Offset: 0x000BC56E
    private static void gmBoss4BodyChangeState( AppMain.GMS_BOSS4_BODY_WORK body_work, int state )
    {
        AppMain.gmBoss4BodyChangeState( body_work, state, false );
    }

    // Token: 0x060015EA RID: 5610 RVA: 0x000BE378 File Offset: 0x000BC578
    private static void gmBoss4BodyChangeState( AppMain.GMS_BOSS4_BODY_WORK body_work, int state, bool is_wrapped )
    {
        AppMain.GMF_BOSS4_BODY_STATE_LEAVE_FUNC gmf_BOSS4_BODY_STATE_LEAVE_FUNC = AppMain.gm_boss4_body_state_leave_func_tbl[body_work.state];
        if ( gmf_BOSS4_BODY_STATE_LEAVE_FUNC != null )
        {
            gmf_BOSS4_BODY_STATE_LEAVE_FUNC( body_work );
        }
        body_work.prev_state = body_work.state;
        body_work.state = state;
        AppMain.GMS_BOSS4_BODY_STATE_ENTER_INFO gms_BOSS4_BODY_STATE_ENTER_INFO = AppMain.gm_boss4_body_state_enter_info_tbl[body_work.state];
        if ( gms_BOSS4_BODY_STATE_ENTER_INFO.enter_func != null )
        {
            gms_BOSS4_BODY_STATE_ENTER_INFO.enter_func( body_work );
        }
    }

    // Token: 0x060015EB RID: 5611 RVA: 0x000BE3D0 File Offset: 0x000BC5D0
    private static void gmBoss4BodyWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work;
        if ( AppMain.GmBoss4IsBuilded() )
        {
            AppMain.GmBoss4UtilInitNodeMatrix( gms_BOSS4_BODY_WORK.node_work, obj_work, 6 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_BODY_WORK.node_work, 2 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_BODY_WORK.node_work, 2 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_BODY_WORK.node_work, 9 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_BODY_WORK.node_work, 10 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_BODY_WORK.node_work, 5 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_BODY_WORK.node_work, 8 );
            AppMain.GmBsCmnCreateCNMMgrWork( gms_BOSS4_BODY_WORK.cnm_mgr_work, obj_work.obj_3d._object, 1 );
            AppMain.GmBsCmnInitCNMCb( obj_work, gms_BOSS4_BODY_WORK.cnm_mgr_work );
            gms_BOSS4_BODY_WORK.chaintop_cnm_reg_id = AppMain.GmBsCmnRegisterCNMNode( gms_BOSS4_BODY_WORK.cnm_mgr_work, 0 );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4BodyMain );
            gms_BOSS4_BODY_WORK.damage_timer = 0;
            AppMain.GmBoss4UtilInitNoHitTimer( gms_BOSS4_BODY_WORK.nohit_work, ( AppMain.GMS_ENEMY_COM_WORK )gms_BOSS4_BODY_WORK, 0 );
            if ( AppMain.GmBoss4CheckBossRush() )
            {
                AppMain.gmBoss4BodyChangeState( gms_BOSS4_BODY_WORK, 5 );
                return;
            }
            AppMain.gmBoss4BodyChangeState( gms_BOSS4_BODY_WORK, 1 );
        }
    }

    // Token: 0x060015EC RID: 5612 RVA: 0x000BE4C4 File Offset: 0x000BC6C4
    private static void gmBoss4BodyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work;
        AppMain.GmBoss4UtilUpdateNoHitTimer( gms_BOSS4_BODY_WORK.nohit_work );
        if ( gms_BOSS4_BODY_WORK.proc_update != null )
        {
            gms_BOSS4_BODY_WORK.proc_update( gms_BOSS4_BODY_WORK );
        }
        AppMain.gmBoss4BodyUpdateSuspendAction( gms_BOSS4_BODY_WORK );
        AppMain.gmBoss4EffAfterburnerUpdateCreate( gms_BOSS4_BODY_WORK );
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 2147483648U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 1073741823U;
            AppMain.gmBoss4BodyInitDefeatState( gms_BOSS4_BODY_WORK );
            return;
        }
        if ( gms_BOSS4_BODY_WORK.damage_timer > 0 )
        {
            gms_BOSS4_BODY_WORK.damage_timer--;
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 1073741824U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 3221225471U;
            gms_BOSS4_BODY_WORK.flag[0] |= 536870912U;
            AppMain.GmBsCmnInitObject3DNNDamageFlicker( obj_work, gms_BOSS4_BODY_WORK.flk_work, 32f );
        }
        AppMain.GmBsCmnUpdateObject3DNNDamageFlicker( obj_work, gms_BOSS4_BODY_WORK.flk_work );
        AppMain.GmBoss4UtilUpdateDirection( gms_BOSS4_BODY_WORK.dir, obj_work );
        AppMain.gmBoss4BodyUpdateChainTopDirection( gms_BOSS4_BODY_WORK );
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
        if ( gms_PLAYER_WORK.seq_state == 17 || gms_PLAYER_WORK.seq_state == 19 )
        {
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
            return;
        }
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag |= 4U;
    }

    // Token: 0x060015ED RID: 5613 RVA: 0x000BE628 File Offset: 0x000BC828
    private static void gmBoss4BodyStateEnterStart( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        body_work.flag[0] |= 64U;
        AppMain.gmBoss4BodySetActionWhole( body_work, 0, true );
        body_work.flag[0] |= 32U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        AppMain.GmBoss4UtilSetDirectionNormal( body_work.dir );
        body_work.wait_timer = 120U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateStartWithWait );
        AppMain.gmBoss4EffBossLightSetEnable( body_work, true );
    }

    // Token: 0x060015EE RID: 5614 RVA: 0x000BE6B8 File Offset: 0x000BC8B8
    private static void gmBoss4BodyStateLeaveStart( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
        body_work.flag[0] &= 4294967231U;
        obs_OBJECT_WORK.flag &= 4294967293U;
        body_work.flag[0] &= 4294967263U;
    }

    // Token: 0x060015EF RID: 5615 RVA: 0x000BE716 File Offset: 0x000BC916
    private static void gmBoss4BodyStateUpdateStartWithWait( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss4IsScrollLockBusy() )
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateStartWithWaitEnd );
        }
    }

    // Token: 0x060015F0 RID: 5616 RVA: 0x000BE734 File Offset: 0x000BC934
    private static void gmBoss4BodyStateUpdateStartWithWaitEnd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( !AppMain.gmBoss4IsScrollLockBusy() )
        {
            AppMain.GmBsCmnSetObjSpd( obj_work, 0, 4096, 0 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateStartWithFall );
            AppMain.GmBoss4CapsuleSetInvincible( 600, false );
            AppMain.GmBoss4ChibiSetInvincible( false );
            body_work.wait_timer2 = 90U;
            body_work.flag[0] |= 268435456U;
            body_work.wait_timer = 120U;
            AppMain.GmBoss4UtilLookAtPlayer( body_work.dir, obj_work, 1 );
            AppMain.GmBoss4UtilLookAt( body_work.dir );
            AppMain.GmMapSetMapDrawSize( 6 );
        }
    }

    // Token: 0x060015F1 RID: 5617 RVA: 0x000BE7CC File Offset: 0x000BC9CC
    private static void gmBoss4BodyStateUpdateStartWithFall( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        if ( body_work.wait_timer2 > 0U )
        {
            body_work.wait_timer2 -= 1U;
            AppMain.GmBoss4UtilLookAtPlayer( body_work.dir, obs_OBJECT_WORK, 1 );
        }
        if ( ( body_work.wait_timer -= 1U ) <= 0U && obs_OBJECT_WORK.pos.y <= AppMain.FX_F32_TO_FX32( 235f ) )
        {
            body_work.flag[0] |= 268435456U;
            body_work.wait_timer = 120U;
        }
        if ( obs_OBJECT_WORK.pos.y >= body_work.atk_nml_alt )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.pos.y = body_work.atk_nml_alt;
            AppMain.GmBsCmnSetObjSpd( obs_OBJECT_WORK, 0, 0, 0 );
            body_work.wait_timer = 30U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateStartWithFallWait );
            AppMain.GmBoss4UtilLookAtPlayer( body_work.dir, obs_OBJECT_WORK, 28 );
        }
    }

    // Token: 0x060015F2 RID: 5618 RVA: 0x000BE8D0 File Offset: 0x000BCAD0
    private static void gmBoss4BodyStateUpdateStartWithFallWait( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBoss4UtilLookAt( body_work.dir );
        if ( ( body_work.wait_timer -= 1U ) == 0U )
        {
            AppMain.GmBoss4CapsuleSetInvincible( 0 );
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            obs_OBJECT_WORK.pos.y = body_work.atk_nml_alt;
            AppMain.GmBsCmnSetObjSpd( obs_OBJECT_WORK, -4096, 0, 0 );
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 1 );
            AppMain.gmBoss4BodyChangeState( body_work, 2 );
            AppMain.GMS_BOSS4_EGG_WORK work = (AppMain.GMS_BOSS4_EGG_WORK)body_work.parts_objs[1];
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)work;
            gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294934527U;
        }
    }

    // Token: 0x060015F3 RID: 5619 RVA: 0x000BE968 File Offset: 0x000BCB68
    private static void gmBoss4BodyStateEnterPreAtkNml( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag &= 4294967293U;
        AppMain.gmBoss4BodySetActionWhole( body_work, 2 );
        AppMain.gmBoss4BodyInitPreANChainMotion( body_work );
        AppMain.gmBoss4BodyInitPreANMove( body_work );
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 1 );
        if ( body_work.dir.direction == 0 )
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdatePreAtkNmlWithMoveRight );
            obs_OBJECT_WORK.spd_add.x = -obs_OBJECT_WORK.spd_add.x;
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdatePreAtkNmlWithMoveLeft );
    }

    // Token: 0x060015F4 RID: 5620 RVA: 0x000BE9EE File Offset: 0x000BCBEE
    private static void gmBoss4BodyStateLeavePreAtkNml( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
    }

    // Token: 0x060015F5 RID: 5621 RVA: 0x000BE9F8 File Offset: 0x000BCBF8
    private static void gmBoss4BodyStateUpdatePreAtkNmlWithMoveLeft( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(-30f), AppMain.FX_F32_TO_FX32(0f));
        AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(180f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
        if ( ( body_work.flag[0] & 2048U ) != 0U )
        {
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
            if ( ( body_work.flag[0] & 1024U ) == 0U )
            {
                AppMain.GmBoss4EffCommonInit( 742, new AppMain.VecFx32?( vecFx ), ( AppMain.OBS_OBJECT_WORK )body_work, 2U, 2U, body_work.node_work, 2, new AppMain.VecFx32?( vecFx2 ), body_work.flag, 1024U );
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
            obs_OBJECT_WORK.spd.x = 0;
            obs_OBJECT_WORK.spd_add.x = 0;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y > AppMain.FX_F32_TO_FX32( 240f ) )
            {
                body_work.avoid_yspd += AppMain.FX_F32_TO_FX32( 0.03f );
            }
            else
            {
                body_work.avoid_yspd -= AppMain.FX_F32_TO_FX32( 0.05f );
                if ( body_work.avoid_yspd < AppMain.FX_F32_TO_FX32( 1f ) )
                {
                    body_work.avoid_yspd = AppMain.FX_F32_TO_FX32( 1f );
                }
            }
            AppMain.OBS_OBJECT_WORK obj_work = body_work.ene_3d.ene_com.obj_work;
            obj_work.pos.y = obj_work.pos.y - body_work.avoid_yspd;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y < AppMain.FX_F32_TO_FX32( 190f ) )
            {
                body_work.ene_3d.ene_com.obj_work.pos.y = AppMain.FX_F32_TO_FX32( 190f );
                body_work.avoid_timer--;
            }
            if ( body_work.avoid_timer < 0 )
            {
                body_work.flag[0] &= 4294965247U;
                body_work.avoid_yspd = 0;
            }
            AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -8, 20, 8, 40 );
            return;
        }
        if ( body_work.atk_nml_alt > body_work.ene_3d.ene_com.obj_work.pos.y )
        {
            body_work.flag[0] |= 4096U;
            body_work.ene_3d.ene_com.rect_work[1].flag &= 4294967291U;
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
            body_work.flag[0] &= 4294966271U;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y > AppMain.FX_F32_TO_FX32( 240f ) )
            {
                body_work.avoid_yspd -= AppMain.FX_F32_TO_FX32( 0.05f );
                if ( body_work.avoid_yspd < AppMain.FX_F32_TO_FX32( 1f ) )
                {
                    body_work.avoid_yspd = AppMain.FX_F32_TO_FX32( 1f );
                }
            }
            else
            {
                body_work.avoid_yspd += AppMain.FX_F32_TO_FX32( 0.03f );
            }
            AppMain.OBS_OBJECT_WORK obj_work2 = body_work.ene_3d.ene_com.obj_work;
            obj_work2.pos.y = obj_work2.pos.y + body_work.avoid_yspd;
            if ( body_work.atk_nml_alt <= body_work.ene_3d.ene_com.obj_work.pos.y )
            {
                AppMain.gmBoss4BodyInitPreANMove( body_work );
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 1 );
                body_work.flag[0] &= 4294966271U;
                AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -32, -8, 32, 40 );
                body_work.ene_3d.ene_com.rect_work[1].flag |= 4U;
            }
            return;
        }
        body_work.ene_3d.ene_com.obj_work.pos.y = body_work.atk_nml_alt;
        body_work.flag[0] &= 4294963199U;
        AppMain.GmBoss4UtilSetDirectionNormal( body_work.dir );
        if ( AppMain.gmBoss4BodyUpdatePreANMoveLeft( body_work ) )
        {
            AppMain.gmBoss4BodyChangeState( body_work, 3 );
            AppMain.gmBoss4BodySetANChainInitialBlendSpd( body_work );
        }
        if ( body_work.damage_timer != 0 )
        {
            for ( int i = 1; i < AppMain.GMD_BOSS4_SPEED_TIMES_IN_DAMAGE; i++ )
            {
                if ( AppMain.gmBoss4BodyUpdatePreANMoveLeft( body_work ) )
                {
                    AppMain.gmBoss4BodyChangeState( body_work, 3 );
                    AppMain.gmBoss4BodySetANChainInitialBlendSpd( body_work );
                    return;
                }
            }
        }
    }

    // Token: 0x060015F6 RID: 5622 RVA: 0x000BEE50 File Offset: 0x000BD050
    private static void gmBoss4BodyStateUpdatePreAtkNmlWithMoveRight( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(-30f), AppMain.FX_F32_TO_FX32(0f));
        AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(180f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( body_work.flag[0] & 2048U ) != 0U )
        {
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
            if ( ( body_work.flag[0] & 1024U ) == 0U )
            {
                AppMain.GmBoss4EffCommonInit( 742, new AppMain.VecFx32?( vecFx ), ( AppMain.OBS_OBJECT_WORK )body_work, 2U, 2U, body_work.node_work, 2, new AppMain.VecFx32?( vecFx2 ), body_work.flag, 1024U );
            }
            obs_OBJECT_WORK.spd.x = 0;
            obs_OBJECT_WORK.spd_add.x = 0;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y > AppMain.FX_F32_TO_FX32( 240f ) )
            {
                body_work.avoid_yspd += AppMain.FX_F32_TO_FX32( 0.03f );
            }
            else
            {
                body_work.avoid_yspd -= AppMain.FX_F32_TO_FX32( 0.05f );
                if ( body_work.avoid_yspd < AppMain.FX_F32_TO_FX32( 1f ) )
                {
                    body_work.avoid_yspd = AppMain.FX_F32_TO_FX32( 1f );
                }
            }
            AppMain.OBS_OBJECT_WORK obj_work = body_work.ene_3d.ene_com.obj_work;
            obj_work.pos.y = obj_work.pos.y - body_work.avoid_yspd;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y < AppMain.FX_F32_TO_FX32( 190f ) )
            {
                body_work.ene_3d.ene_com.obj_work.pos.y = AppMain.FX_F32_TO_FX32( 190f );
                body_work.avoid_timer--;
            }
            if ( body_work.avoid_timer < 0 )
            {
                body_work.flag[0] &= 4294965247U;
                body_work.avoid_yspd = 0;
            }
            AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -8, 20, 8, 40 );
            return;
        }
        if ( body_work.atk_nml_alt > body_work.ene_3d.ene_com.obj_work.pos.y )
        {
            body_work.ene_3d.ene_com.rect_work[1].flag &= 4294967291U;
            body_work.flag[0] |= 4096U;
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
            body_work.flag[0] &= 4294966271U;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y > AppMain.FX_F32_TO_FX32( 240f ) )
            {
                body_work.avoid_yspd -= AppMain.FX_F32_TO_FX32( 0.05f );
                if ( body_work.avoid_yspd < AppMain.FX_F32_TO_FX32( 1f ) )
                {
                    body_work.avoid_yspd = AppMain.FX_F32_TO_FX32( 1f );
                }
            }
            else
            {
                body_work.avoid_yspd += AppMain.FX_F32_TO_FX32( 0.03f );
            }
            AppMain.OBS_OBJECT_WORK obj_work2 = body_work.ene_3d.ene_com.obj_work;
            obj_work2.pos.y = obj_work2.pos.y + body_work.avoid_yspd;
            if ( body_work.atk_nml_alt <= body_work.ene_3d.ene_com.obj_work.pos.y )
            {
                AppMain.gmBoss4BodyInitPreANMove( body_work );
                obs_OBJECT_WORK.spd_add.x = -obs_OBJECT_WORK.spd_add.x;
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 1 );
                body_work.flag[0] &= 4294966271U;
                AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -32, -8, 32, 40 );
                body_work.ene_3d.ene_com.rect_work[1].flag |= 4U;
            }
            return;
        }
        body_work.ene_3d.ene_com.obj_work.pos.y = body_work.atk_nml_alt;
        body_work.flag[0] &= 4294963199U;
        AppMain.GmBoss4UtilSetDirectionNormal( body_work.dir );
        if ( AppMain.gmBoss4BodyUpdatePreANMoveRight( body_work ) )
        {
            AppMain.gmBoss4BodyChangeState( body_work, 3 );
            AppMain.gmBoss4BodySetANChainInitialBlendSpd( body_work );
        }
        if ( body_work.damage_timer != 0 )
        {
            for ( int i = 1; i < AppMain.GMD_BOSS4_SPEED_TIMES_IN_DAMAGE; i++ )
            {
                if ( AppMain.gmBoss4BodyUpdatePreANMoveRight( body_work ) )
                {
                    AppMain.gmBoss4BodyChangeState( body_work, 3 );
                    AppMain.gmBoss4BodySetANChainInitialBlendSpd( body_work );
                    return;
                }
            }
        }
    }

    // Token: 0x060015F7 RID: 5623 RVA: 0x000BF2C4 File Offset: 0x000BD4C4
    private static void gmBoss4BodyStateEnterAtkNml( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        bool force_change = false;
        obs_OBJECT_WORK.flag &= 4294967293U;
        if ( body_work.dir.direction == 1 )
        {
            force_change = true;
        }
        AppMain.gmBoss4BodySetActionWhole( body_work, 3, force_change );
        AppMain.gmBoss4BodyInitAtkNmlFlipAndTurn( body_work );
        AppMain.gmBoss4BodyInitAtkNmlDrift( body_work, AppMain.GMD_BOSS4_BODY_ATKNML_DRIFT_FRAME );
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateAtkNmlWithTurn );
    }

    // Token: 0x060015F8 RID: 5624 RVA: 0x000BF32B File Offset: 0x000BD52B
    private static void gmBoss4BodyStateLeaveAtkNml( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
    }

    // Token: 0x060015F9 RID: 5625 RVA: 0x000BF334 File Offset: 0x000BD534
    private static void gmBoss4BodyStateUpdateAtkNmlWithTurn( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        bool flag = AppMain.gmBoss4BodyUpdateAtkNmlDrift(body_work);
        if ( AppMain.gmBoss4BodyUpdateAtkNmlFlipAndTurn( body_work ) && flag )
        {
            AppMain.gmBoss4BodySetFlipForAtkNmlMove( body_work );
            AppMain.gmBoss4BodyInitAtkNmlMove( body_work, AppMain.GMD_BOSS4_BODY_ATKNML_MOVE_FRAME );
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 1 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateAtkNmlWithMove );
        }
    }

    // Token: 0x060015FA RID: 5626 RVA: 0x000BF380 File Offset: 0x000BD580
    private static void gmBoss4BodyStateUpdateAtkNmlWithMove( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(-30f), AppMain.FX_F32_TO_FX32(0f));
        AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(180f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
        if ( ( body_work.flag[0] & 2048U ) != 0U )
        {
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
            if ( ( body_work.flag[0] & 1024U ) == 0U )
            {
                AppMain.GmBoss4EffCommonInit( 742, new AppMain.VecFx32?( vecFx ), ( AppMain.OBS_OBJECT_WORK )body_work, 2U, 2U, body_work.node_work, 2, new AppMain.VecFx32?( vecFx2 ), body_work.flag, 1024U );
            }
            if ( body_work.ene_3d.ene_com.obj_work.pos.y > AppMain.FX_F32_TO_FX32( 240f ) )
            {
                body_work.avoid_yspd += AppMain.FX_F32_TO_FX32( 0.03f );
            }
            else
            {
                body_work.avoid_yspd -= AppMain.FX_F32_TO_FX32( 0.05f );
                if ( body_work.avoid_yspd < AppMain.FX_F32_TO_FX32( 1f ) )
                {
                    body_work.avoid_yspd = AppMain.FX_F32_TO_FX32( 1f );
                }
            }
            AppMain.OBS_OBJECT_WORK obj_work = body_work.ene_3d.ene_com.obj_work;
            obj_work.pos.y = obj_work.pos.y - body_work.avoid_yspd;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y < AppMain.FX_F32_TO_FX32( 190f ) )
            {
                body_work.ene_3d.ene_com.obj_work.pos.y = AppMain.FX_F32_TO_FX32( 190f );
                body_work.avoid_timer--;
            }
            if ( body_work.avoid_timer < 0 )
            {
                body_work.flag[0] &= 4294965247U;
                body_work.avoid_yspd = 0;
            }
            AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -8, 20, 8, 40 );
            return;
        }
        if ( body_work.atk_nml_alt > body_work.ene_3d.ene_com.obj_work.pos.y )
        {
            body_work.ene_3d.ene_com.rect_work[1].flag &= 4294967291U;
            body_work.flag[0] |= 4096U;
            AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
            body_work.flag[0] &= 4294966271U;
            if ( body_work.ene_3d.ene_com.obj_work.pos.y > AppMain.FX_F32_TO_FX32( 240f ) )
            {
                body_work.avoid_yspd -= AppMain.FX_F32_TO_FX32( 0.05f );
                if ( body_work.avoid_yspd < AppMain.FX_F32_TO_FX32( 1f ) )
                {
                    body_work.avoid_yspd = AppMain.FX_F32_TO_FX32( 1f );
                }
            }
            else
            {
                body_work.avoid_yspd += AppMain.FX_F32_TO_FX32( 0.03f );
            }
            AppMain.OBS_OBJECT_WORK obj_work2 = body_work.ene_3d.ene_com.obj_work;
            obj_work2.pos.y = obj_work2.pos.y + body_work.avoid_yspd;
            if ( body_work.atk_nml_alt <= body_work.ene_3d.ene_com.obj_work.pos.y )
            {
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 1 );
                body_work.flag[0] &= 4294966271U;
                AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -32, -8, 32, 40 );
                body_work.ene_3d.ene_com.rect_work[1].flag |= 4U;
            }
            return;
        }
        body_work.ene_3d.ene_com.obj_work.pos.y = body_work.atk_nml_alt;
        body_work.flag[0] &= 4294963199U;
        AppMain.GmBoss4UtilSetDirectionNormal( body_work.dir );
        if ( AppMain.gmBoss4BodyIsExtraAttack( body_work ) )
        {
            AppMain.gmBoss4BodyChangeState( body_work, 4 );
            return;
        }
        if ( AppMain.gmBoss4BodyUpdateAtkNmlMove( body_work ) )
        {
            AppMain.gmBoss4BodyChangeState( body_work, 3 );
            return;
        }
        if ( body_work.damage_timer != 0 )
        {
            for ( int i = 1; i < AppMain.GMD_BOSS4_SPEED_TIMES_IN_DAMAGE; i++ )
            {
                if ( AppMain.gmBoss4BodyUpdateAtkNmlMove( body_work ) )
                {
                    AppMain.gmBoss4BodyChangeState( body_work, 3 );
                    return;
                }
            }
        }
    }

    // Token: 0x060015FB RID: 5627 RVA: 0x000BF7B8 File Offset: 0x000BD9B8
    private static void gmBoss4BodyStateEnter1stEnd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilInitNoHitTimer( body_work.nohit_work, ( AppMain.GMS_ENEMY_COM_WORK )body_work, 1200 );
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)body_work;
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag |= 2048U;
        AppMain.GmBoss4CapsuleSetInvincible( 600, false );
        AppMain.GmBoss4ChibiSetInvincible( true );
        AppMain.GmBoss4ChibiExplosion();
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.GmBoss4UtilTimerStop( true );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        AppMain.VecFx32 end = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(obs_CAMERA.target_pos.x), AppMain.FX_F32_TO_FX32(220f), 0);
        AppMain.GmBoss4UtilInitMove( body_work.move_work, obs_OBJECT_WORK.pos, end, 180, 1 );
        bool is_positive = AppMain.GmBoss4UtilIsDirectionPositiveFromCurrent(body_work.dir, AppMain.GMD_BOSS4_LEFTWARD_ANGLE);
        body_work.dir.direction = 1;
        AppMain.GmBoss4UtilInitTurnGently( body_work.dir, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, 40, is_positive );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate1stEnd );
    }

    // Token: 0x060015FC RID: 5628 RVA: 0x000BF8B0 File Offset: 0x000BDAB0
    private static void gmBoss4BodyStateUpdate1stEnd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.GmBoss4ChibiExplosion();
        AppMain.OBS_OBJECT_WORK obj_work = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.GmBoss4UtilUpdateTurnGently( body_work.dir );
        if ( body_work.move_work.now_count == 30 )
        {
            AppMain.VecFx32 vecFx = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(-30f), AppMain.FX_F32_TO_FX32(0f));
            AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(180f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
            AppMain.GmBoss4EffCommonInit( 742, new AppMain.VecFx32?( vecFx ), ( AppMain.OBS_OBJECT_WORK )body_work, 2U, 2U, body_work.node_work, 2, new AppMain.VecFx32?( vecFx2 ), body_work.flag, 1024U );
        }
        if ( AppMain.GmBoss4UtilUpdateMove( body_work.move_work ) )
        {
            if ( AppMain.GmBoss4CapsuleGetCount() > 0 )
            {
                body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit1stEndExplosion );
            }
            else
            {
                body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit1stEndAngry );
            }
        }
        AppMain.GmBoss4UtilUpdateMovePosition( body_work.move_work, obj_work );
    }

    // Token: 0x060015FD RID: 5629 RVA: 0x000BF9AC File Offset: 0x000BDBAC
    private static void gmBoss4BodyStateInit1stEndExplosion( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.GmBoss4CapsuleExplosion();
        body_work.wait_timer = 180U;
        body_work.flag[0] |= 16777216U;
        AppMain.VecFx32 end = new AppMain.VecFx32(obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y + AppMain.FX_F32_TO_FX32(20f), 0);
        AppMain.GmBoss4UtilInitMove( body_work.move_work, obs_OBJECT_WORK.pos, end, 60, 1 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate1stEndExplosion );
    }

    // Token: 0x060015FE RID: 5630 RVA: 0x000BFA44 File Offset: 0x000BDC44
    private static void gmBoss4BodyStateUpdate1stEndExplosion( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.OBS_OBJECT_WORK obj_work = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.GmBoss4UtilUpdateMove( body_work.move_work );
        AppMain.GmBoss4UtilUpdateMovePosition( body_work.move_work, obj_work );
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit1stEndAngry );
    }

    // Token: 0x060015FF RID: 5631 RVA: 0x000BFAA0 File Offset: 0x000BDCA0
    private static void gmBoss4BodyStateInit1stEndAngry( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.gmBoss4BodySetActionWhole( body_work, 8 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate1stEndAngry );
    }

    // Token: 0x06001600 RID: 5632 RVA: 0x000BFAC1 File Offset: 0x000BDCC1
    private static void gmBoss4BodyStateUpdate1stEndAngry( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        if ( AppMain.GmBsCmnIsActionEnd( ( AppMain.OBS_OBJECT_WORK )body_work ) != 0 )
        {
            AppMain.gmBoss4BodySetActionWhole( body_work, 9 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate1stEndAngryL2 );
        }
    }

    // Token: 0x06001601 RID: 5633 RVA: 0x000BFAF0 File Offset: 0x000BDCF0
    private static void gmBoss4BodyStateUpdate1stEndAngryL2( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        if ( AppMain.GmBsCmnIsActionEnd( ( AppMain.OBS_OBJECT_WORK )body_work ) != 0 )
        {
            AppMain.gmBoss4BodySetActionWhole( body_work, 10 );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit1stEndEscape );
        }
    }

    // Token: 0x06001602 RID: 5634 RVA: 0x000BFB20 File Offset: 0x000BDD20
    private static void gmBoss4BodyStateInit1stEndEscape( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 2 );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        AppMain.VecFx32 end = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(obs_CAMERA.target_pos.x + 200f) + (AppMain.GMM_BOSS4_AREA_RIGHT() - AppMain.GMM_BOSS4_AREA_LEFT()) / 2, obs_OBJECT_WORK.pos.y, 0);
        AppMain.GmBoss4UtilInitMove( body_work.move_work, obs_OBJECT_WORK.pos, end, 150, 1 );
        AppMain.GmMapSetMapDrawSize( 1 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate1stEndEscape );
    }

    // Token: 0x06001603 RID: 5635 RVA: 0x000BFBB0 File Offset: 0x000BDDB0
    private static void gmBoss4BodyStateUpdate1stEndEscape( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4UtilPlayerStop( true );
        AppMain.OBS_OBJECT_WORK obj_work = (AppMain.OBS_OBJECT_WORK)body_work;
        if ( AppMain.GmBoss4UtilUpdateMove( body_work.move_work ) )
        {
            AppMain.gmBoss4BodyChangeState( body_work, 5 );
            return;
        }
        AppMain.GmBoss4UtilUpdateMovePosition( body_work.move_work, obj_work );
    }

    // Token: 0x06001604 RID: 5636 RVA: 0x000BFBEC File Offset: 0x000BDDEC
    private static void gmBoss4BodyStateEnter2nd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.GmBoss4UtilInitNoHitTimer( body_work.nohit_work, ( AppMain.GMS_ENEMY_COM_WORK )body_work, 0 );
        AppMain.GmBoss4CapsuleSetInvincible( 0 );
        AppMain.GmBoss4ChibiSetInvincible( false );
        AppMain.GmBoss4UtilPlayerStop( false );
        AppMain.GmBoss4UtilTimerStop( false );
        if ( !AppMain.GmBoss4CheckBossRush() )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmGmkCamScrLimitRelease(4);
            obs_OBJECT_WORK2.user_work = 16U;
        }
        obs_OBJECT_WORK.pos.x = AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_2ND_POS_X );
        obs_OBJECT_WORK.pos.y = AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_2ND_POS_Y );
        obs_OBJECT_WORK.pos.z = -131072;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)body_work;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag |= 2048U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag |= 2048U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294965247U;
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[0], -38, -24, 38, 32 );
        AppMain.GMS_BOSS4_EGG_WORK work = (AppMain.GMS_BOSS4_EGG_WORK)body_work.parts_objs[1];
        AppMain.gmBoss4SetPartTextureBurnt( ( AppMain.OBS_OBJECT_WORK )work, false );
        AppMain.GmBoss4UtilInitTurnGently( body_work.dir, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, 1, false );
        AppMain.GmBoss4UtilUpdateTurnGently( body_work.dir );
        AppMain.gmBoss4BodySetActionWhole( body_work, 5 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit2nd );
        AppMain.GmBoss4CapsuleExplosion();
        bool is_positive = AppMain.GmBoss4UtilIsDirectionPositiveFromCurrent(body_work.dir, AppMain.GMD_BOSS4_LEFTWARD_ANGLE);
        body_work.dir.direction = 1;
        AppMain.GmBoss4UtilInitTurnGently( body_work.dir, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, 1, is_positive );
        AppMain.GmBoss4UtilUpdateTurnGently( body_work.dir );
        AppMain.gm_boss4_locking = 0;
    }

    // Token: 0x06001605 RID: 5637 RVA: 0x000BFDC8 File Offset: 0x000BDFC8
    private static void gmBoss4BodyStateInit2nd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        int num = AppMain.FX_F32_TO_FX32((float)AppMain.GMD_BOSS4_SCROLL_INIT_X);
        if ( obs_OBJECT_WORK2.pos.x >= num )
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2ndWaitBoss );
            AppMain.GmBoss4ScrollInit( null, 0, 0, 0 );
            body_work.wait_timer = AppMain.GMD_BOSS4_BODY_SONIC_CTRL_TIME;
            if ( AppMain.GmBoss4CheckBossRush() )
            {
                AppMain.gmBoss4BodySetActionWhole( body_work, 5 );
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
                AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 2 );
            }
            else
            {
                AppMain.GmSoundChangeAngryBossBGM();
            }
            AppMain.GmMapSetMapDrawSize( 7 );
        }
        obs_OBJECT_WORK.pos.y = AppMain.FX_F32_TO_FX32( ( float )AppMain.GMD_BOSS4_BODY_2ND_POS_Y );
    }

    // Token: 0x06001606 RID: 5638 RVA: 0x000BFE64 File Offset: 0x000BE064
    private static void gmBoss4BodyStateUpdate2ndWaitBoss( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
        if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmBoss4UtilPlayerStop( true );
        }
        float num = (float)AppMain.g_gm_main_system.map_fcol.right;
        if ( ( ( AppMain.OBS_OBJECT_WORK )body_work ).pos.x < AppMain.FX_F32_TO_FX32( num - 10f ) )
        {
            return;
        }
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2nd );
        AppMain.GmBoss4ScrollInit( null, 0, 0, 0 );
        body_work.wait_timer = AppMain.GMD_BOSS4_BODY_CREATE_CAP_FIRST_TIME;
        AppMain.GmBoss4UtilPlayerStop( false );
    }

    // Token: 0x06001607 RID: 5639 RVA: 0x000BFF08 File Offset: 0x000BE108
    private static void gmBoss4BodyStateUpdate2nd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit2ndAttack );
        body_work.wait_timer = 34U;
        body_work.flag[0] |= 2097152U;
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)body_work.parts_objs[1];
        AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_EGG_WORK.node_work, 9 );
        AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_EGG_WORK.node_work, 6 );
    }

    // Token: 0x06001608 RID: 5640 RVA: 0x000BFF90 File Offset: 0x000BE190
    private static void gmBoss4BodyStateInit2ndAttack( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)body_work.parts_objs[1];
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_EGG_WORK.node_work, 9);
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GmBoss4UtilGetNodeMatrix(body_work.node_work, 2);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = nns_MATRIX.M03 - nns_MATRIX2.M03 + ( float )obs_OBJECT_WORK.pos.x / 4096f;
        nns_VECTOR.y = nns_MATRIX.M13;
        nns_VECTOR.z = nns_MATRIX.M23;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(324, AppMain.FX_F32_TO_FX32(nns_VECTOR.x + 0f), -AppMain.FX_F32_TO_FX32(nns_VECTOR.y + -22f), 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        AppMain.GmBoss4IncObjCreateCount();
        if ( AppMain.gmBoss4ChibiGetThrowType() != 0 )
        {
            obs_OBJECT_WORK2.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_X_1 );
            obs_OBJECT_WORK2.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_Y_1 );
        }
        else
        {
            obs_OBJECT_WORK2.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_X_2 );
            obs_OBJECT_WORK2.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_Y_2 );
        }
        obs_OBJECT_WORK2.pos.z = 0;
        if ( AppMain.GmBoss4GetLife() < AppMain.GME_BOSS4_LIFE_H && AppMain.GmBoss4GetLife() > AppMain.GME_BOSS4_LIFE_L )
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2ndAttackWait );
            body_work.wait_timer = AppMain.GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_2_2;
        }
        else
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2ndAttack );
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06001609 RID: 5641 RVA: 0x000C012C File Offset: 0x000BE32C
    private static void gmBoss4BodyStateUpdate2ndAttackWait( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateInit2ndAttack2 );
        body_work.wait_timer = 34U;
        body_work.flag[0] |= 4194304U;
    }

    // Token: 0x0600160A RID: 5642 RVA: 0x000C0188 File Offset: 0x000BE388
    private static void gmBoss4BodyStateInit2ndAttack2( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)body_work.parts_objs[1];
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_EGG_WORK.node_work, 6);
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GmBoss4UtilGetNodeMatrix(body_work.node_work, 2);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = nns_MATRIX.M03 - nns_MATRIX2.M03 + ( float )obs_OBJECT_WORK.pos.x / 4096f;
        nns_VECTOR.y = nns_MATRIX.M13;
        nns_VECTOR.z = nns_MATRIX.M23;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(324, AppMain.FX_F32_TO_FX32(nns_VECTOR.x + 0f), -AppMain.FX_F32_TO_FX32(nns_VECTOR.y + -22f), 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        AppMain.GmBoss4IncObjCreateCount();
        if ( AppMain.gmBoss4ChibiGetThrowType() != 0 )
        {
            obs_OBJECT_WORK2.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_X_1 );
            obs_OBJECT_WORK2.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_Y_1 );
        }
        else
        {
            obs_OBJECT_WORK2.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_X_2 );
            obs_OBJECT_WORK2.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_BODY_CREATE_CAP_THROW_SPD_Y_2 );
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2ndAttack );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x0600160B RID: 5643 RVA: 0x000C02E0 File Offset: 0x000BE4E0
    private static void gmBoss4BodyStateUpdate2ndAttack( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        body_work.wait_timer = AppMain.GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_3;
        if ( AppMain.GmBoss4GetLife() == 1 )
        {
            body_work.wait_timer = AppMain.GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_1;
        }
        if ( AppMain.GmBoss4GetLife() == 2 )
        {
            body_work.wait_timer = AppMain.GMD_BOSS4_BODY_CREATE_CAP_TIMING_LIFE_2;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdate2nd );
    }

    // Token: 0x0600160C RID: 5644 RVA: 0x000C0330 File Offset: 0x000BE530
    private static void gmBoss4BodyStateLeave1stEnd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x0600160D RID: 5645 RVA: 0x000C0338 File Offset: 0x000BE538
    private static void gmBoss4BodyStateLeave2nd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x0600160E RID: 5646 RVA: 0x000C0340 File Offset: 0x000BE540
    private static void gmBoss4BodyStateEnterDmgNml( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x0600160F RID: 5647 RVA: 0x000C0348 File Offset: 0x000BE548
    private static void gmBoss4BodyStateLeaveDmgNml( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x06001610 RID: 5648 RVA: 0x000C0350 File Offset: 0x000BE550
    private static void gmBoss4BodyStateEnterDefeat( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        body_work.flag[0] |= 8U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.wait_timer = 40U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateDefeatWithWaitStart );
        AppMain.gmBoss4EffAfterburnerSetEnable( body_work, 0 );
        AppMain.GmBoss4ScrollNext();
        AppMain.GmBoss4UtilInitNoHitTimer( body_work.nohit_work, ( AppMain.GMS_ENEMY_COM_WORK )body_work, 1200 );
        AppMain.GmBoss4CapsuleSetInvincible( 600, false );
        AppMain.GmBoss4ChibiSetInvincible( true );
    }

    // Token: 0x06001611 RID: 5649 RVA: 0x000C03DE File Offset: 0x000BE5DE
    private static void gmBoss4BodyStateLeaveDefeat( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x06001612 RID: 5650 RVA: 0x000C03E8 File Offset: 0x000BE5E8
    private static void gmBoss4BodyStateUpdateDefeatWithWaitStart( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBoss4ChibiExplosion();
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.GmBoss4EffBombInitCreate( body_work.bomb_work, 0, AppMain.GMM_BS_OBJ( body_work ), AppMain.GMM_BS_OBJ( body_work ).pos.x, AppMain.GMM_BS_OBJ( body_work ).pos.y, AppMain.FX_F32_TO_FX32( 80f ), AppMain.FX_F32_TO_FX32( 80f ), AppMain.GMD_BOSS4_BODY_DEFEAT_BOMB_SMALL_INTERVAL_MIN_TIME, AppMain.GMD_BOSS4_BODY_DEFEAT_BOMB_SMALL_INTERVAL_MAX_TIME );
        AppMain.GmBoss4EffBombInitCreate( body_work.bomb_work2, 5, AppMain.GMM_BS_OBJ( body_work ), AppMain.GMM_BS_OBJ( body_work ).pos.x, AppMain.GMM_BS_OBJ( body_work ).pos.y, AppMain.FX_F32_TO_FX32( 80f ), AppMain.FX_F32_TO_FX32( 80f ), AppMain.GMD_BOSS4_BODY_DEFEAT_BOMB_PARTS_INTERVAL_MIN_TIME, AppMain.GMD_BOSS4_BODY_DEFEAT_BOMB_PARTS_INTERVAL_MAX_TIME );
        body_work.wait_timer = AppMain.GMD_BOSS4_BODY_DEFEAT_BOMB_SMALL_TIME;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateDefeatWithExplode );
    }

    // Token: 0x06001613 RID: 5651 RVA: 0x000C04D0 File Offset: 0x000BE6D0
    private static void gmBoss4BodyStateUpdateDefeatWithExplode( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            AppMain.GmBoss4EffBombUpdateCreate( body_work.bomb_work );
            AppMain.GmBoss4EffBombUpdateCreate( body_work.bomb_work2 );
            body_work.bomb_work.pos[0] -= AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_SCROLL_SPD_MAX - AppMain.GMD_BOSS4_SCROLL_SPD_BOSS_BROKEN );
            body_work.bomb_work2.pos[0] -= AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_SCROLL_SPD_MAX - AppMain.GMD_BOSS4_SCROLL_SPD_BOSS_BROKEN );
            return;
        }
        AppMain.GmSoundPlaySE( "Boss0_03" );
        AppMain.GMM_PAD_VIB_MID_TIME( 120f );
        AppMain.GmBsCmnInitFlashScreen( body_work.flash_work, 4f, 5f, 30f );
        AppMain.GmPlayerAddScoreNoDisp( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 1000 );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(body_work), 8);
        obs_OBJECT_WORK.pos.z = obs_OBJECT_WORK.parent_obj.pos.z + 131072;
        AppMain.GmBoss4EffChangeType( ( AppMain.GMS_EFFECT_3DES_WORK )obs_OBJECT_WORK, 2U, 1U );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.spd.x = obs_OBJECT_WORK2.spd.x - AppMain.FX_F32_TO_FX32( 1f );
        AppMain.gmBoss4BodySetActionWhole( body_work, 7 );
        AppMain.GmBoss4ScrollOut();
        body_work.wait_timer = 40U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateDefeatWithScatter );
    }

    // Token: 0x06001614 RID: 5652 RVA: 0x000C062C File Offset: 0x000BE82C
    private static void gmBoss4BodyStateUpdateDefeatWithScatter( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.GmBsCmnUpdateFlashScreen( body_work.flash_work );
        if ( body_work.wait_timer != 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss4SetPartTextureBurnt( AppMain.GMM_BS_OBJ( body_work ) );
        body_work.flag[0] |= 16777216U;
        AppMain.gmBoss4EffABSmokeInit( body_work );
        AppMain.gmBoss4EffBodySmokeInit( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateDefeatWithWaitEnd );
    }

    // Token: 0x06001615 RID: 5653 RVA: 0x000C06A2 File Offset: 0x000BE8A2
    private static void gmBoss4BodyStateUpdateDefeatWithWaitEnd( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( body_work.wait_timer > 0U )
        {
            body_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss4BodyChangeState( body_work, 8 );
    }

    // Token: 0x06001616 RID: 5654 RVA: 0x000C06C4 File Offset: 0x000BE8C4
    private static void gmBoss4BodyStateEnterEscape( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.disp_flag &= 4294967279U;
        AppMain.gmBoss4BodySetActionWhole( body_work, 7 );
        body_work.flag[0] |= 8388608U;
        bool is_positive = AppMain.GmBoss4UtilIsDirectionPositiveFromCurrent(body_work.dir, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE);
        AppMain.GmBoss4UtilInitTurnGently( body_work.dir, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE, 90, is_positive );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateEscapeWithTurn );
    }

    // Token: 0x06001617 RID: 5655 RVA: 0x000C0756 File Offset: 0x000BE956
    private static void gmBoss4BodyStateLeaveEscape( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.UNREFERENCED_PARAMETER( body_work );
    }

    // Token: 0x06001618 RID: 5656 RVA: 0x000C075E File Offset: 0x000BE95E
    private static void gmBoss4BodyStateUpdateEscapeWithTurn( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( AppMain.GmBoss4UtilUpdateTurnGently( body_work.dir ) )
        {
            AppMain.gmBoss4BodyInitEscapeMove( body_work );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateEscapeWithMoveLocked );
        }
    }

    // Token: 0x06001619 RID: 5657 RVA: 0x000C0785 File Offset: 0x000BE985
    private static void gmBoss4BodyStateUpdateEscapeWithMoveLocked( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.gmBoss4BodyUpdateEscapeMove( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateEscapeWithMoveUnlocked );
    }

    // Token: 0x0600161A RID: 5658 RVA: 0x000C07A0 File Offset: 0x000BE9A0
    private static void gmBoss4BodyStateUpdateEscapeWithMoveUnlocked( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        float num = (float)AppMain.g_gm_main_system.map_fcol.right;
        AppMain.gmBoss4BodyUpdateEscapeMove( body_work );
        if ( obs_OBJECT_WORK.pos.x > AppMain.FX_F32_TO_FX32( num - 100f ) )
        {
            AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctBossCmnEsCreate(obs_OBJECT_WORK, 4U);
            AppMain.GmBoss4EffChangeType( efct_work, 2U, 3U );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.gmBoss4BodyStateUpdateEscapeWithMoveFinish );
            AppMain.GmMapSetMapDrawSize( 1 );
        }
    }

    // Token: 0x0600161B RID: 5659 RVA: 0x000C080D File Offset: 0x000BEA0D
    private static void gmBoss4BodyStateUpdateEscapeWithMoveFinish( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss4BodyUpdateEscapeMove( body_work ) )
        {
            AppMain.GMM_BOSS4_MGR( body_work ).flag |= 2U;
            body_work.proc_update = null;
            AppMain.GmBoss4ScrollNext();
        }
    }

    // Token: 0x0600161C RID: 5660 RVA: 0x000C0838 File Offset: 0x000BEA38
    private static void gmBoss4EffAfterburnerSetEnable( AppMain.GMS_BOSS4_BODY_WORK body_work, int type )
    {
        switch ( type )
        {
            default:
                body_work.flag[0] &= 4294967279U;
                body_work.flag[0] &= 4261412863U;
                body_work.flag[0] &= 4294967039U;
                body_work.flag[0] &= 4293918719U;
                return;
            case 1:
                AppMain.MTM_ASSERT( 0U == ( body_work.flag[0] & 16U ) );
                AppMain.MTM_ASSERT( 0U == ( body_work.flag[0] & 33554432U ) );
                body_work.flag[0] &= 4294967039U;
                body_work.flag[0] &= 4293918719U;
                body_work.flag[0] |= 33554432U;
                return;
            case 2:
                AppMain.MTM_ASSERT( 0U == ( body_work.flag[0] & 256U ) );
                AppMain.MTM_ASSERT( 0U == ( body_work.flag[0] & 1048576U ) );
                body_work.flag[0] &= 4294967279U;
                body_work.flag[0] &= 4261412863U;
                body_work.flag[0] |= 1048576U;
                body_work.flag[0] &= 4294966271U;
                return;
        }
    }

    // Token: 0x0600161D RID: 5661 RVA: 0x000C09EC File Offset: 0x000BEBEC
    private static void gmBoss4EffAfterburnerUpdateCreate( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( ( body_work.flag[0] & 1048576U ) != 0U )
        {
            body_work.flag[0] &= 4261412863U;
            body_work.flag[0] &= 4293918719U;
            body_work.flag[0] |= 256U;
            AppMain.gmBoss4EffAfterburnerExInit( body_work );
        }
        if ( ( body_work.flag[0] & 33554432U ) != 0U )
        {
            body_work.flag[0] &= 4261412863U;
            body_work.flag[0] &= 4293918719U;
            body_work.flag[0] |= 16U;
            AppMain.gmBoss4EffAfterburnerInit( body_work );
        }
    }

    // Token: 0x0600161E RID: 5662 RVA: 0x000C0AD0 File Offset: 0x000BECD0
    private static void gmBoss4EffAfterburnerInit( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 4U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, -15f, -45f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffAfterburnerProcMain );
        gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate( parent_obj, 4U );
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 5f, -45f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffAfterburnerProcMain );
    }

    // Token: 0x0600161F RID: 5663 RVA: 0x000C0B4C File Offset: 0x000BED4C
    private static void gmBoss4EffAfterburnerProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS4_BODY_WORK.node_work.snm_work.reg_node_max );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 16U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS4_BODY_WORK.node_work.snm_work, gms_BOSS4_BODY_WORK.node_work.work[2], 1 );
    }

    // Token: 0x06001620 RID: 5664 RVA: 0x000C0BC4 File Offset: 0x000BEDC4
    private static void gmBoss4EffAfterburnerExInit( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmBoss4EffCommonInit(741, default(AppMain.VecFx32?), parent_obj);
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = null;
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, 2U, 2U );
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, ( short )AppMain.GMD_BOSS4_EFF_ABURNER3_DISP_ROT_X, 0, 0 );
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, -1f, -1f, 0f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffAfterburnerExProcMainL );
        gms_EFFECT_3DES_WORK = AppMain.GmBoss4EffCommonInit( 741, default( AppMain.VecFx32? ), parent_obj );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = null;
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, 2U, 2U );
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, ( short )AppMain.GMD_BOSS4_EFF_ABURNER3_DISP_ROT_X, 0, 0 );
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, -1f, 0f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffAfterburnerExProcMainR );
    }

    // Token: 0x06001621 RID: 5665 RVA: 0x000C0CA0 File Offset: 0x000BEEA0
    private static void gmBoss4EffAfterburnerExProcMainL( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS4_BODY_WORK.node_work.snm_work.reg_node_max );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 256U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_BODY_WORK.node_work, 5);
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_BODY_WORK.node_work, 2);
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnCopyMatrix( nns_MATRIX3, nns_MATRIX );
        nns_MATRIX3.M03 = nns_MATRIX.M03 - nns_MATRIX2.M03 + ( float )gms_BOSS4_BODY_WORK.ene_3d.ene_com.obj_work.pos.x / 4096f;
        AppMain.GmBoss4UtilSetMatrixES( obj_work, nns_MATRIX3 );
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
    }

    // Token: 0x06001622 RID: 5666 RVA: 0x000C0D98 File Offset: 0x000BEF98
    private static void gmBoss4EffAfterburnerExProcMainR( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS4_BODY_WORK.node_work.snm_work.reg_node_max );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 256U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_BODY_WORK.node_work, 8);
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_BODY_WORK.node_work, 2);
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnCopyMatrix( nns_MATRIX3, nns_MATRIX );
        nns_MATRIX3.M03 = nns_MATRIX.M03 - nns_MATRIX2.M03 + ( float )gms_BOSS4_BODY_WORK.ene_3d.ene_com.obj_work.pos.x / 4096f;
        AppMain.GmBoss4UtilSetMatrixES( obj_work, nns_MATRIX3 );
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
    }

    // Token: 0x06001623 RID: 5667 RVA: 0x000C0E90 File Offset: 0x000BF090
    private static void gmBoss4EffABSmokeInit( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 5U);
        AppMain.GmBoss4EffChangeType( gms_EFFECT_3DES_WORK, 2U, 19U );
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffABSmokeProcMain );
    }

    // Token: 0x06001624 RID: 5668 RVA: 0x000C0EE4 File Offset: 0x000BF0E4
    private static void gmBoss4EffABSmokeProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS4_BODY_WORK.node_work.snm_work.reg_node_max );
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
        }
        else
        {
            obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS4_BODY_WORK.node_work.snm_work, gms_BOSS4_BODY_WORK.node_work.work[2], 1 );
    }

    // Token: 0x06001625 RID: 5669 RVA: 0x000C0F8C File Offset: 0x000BF18C
    private static void gmBoss4EffBodySmokeInit( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 3U);
        AppMain.GmBoss4EffChangeType( gms_EFFECT_3DES_WORK, 2U, 19U );
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffBodySmokeProcMain );
        float[][] array = new float[4][];
        array[0] = new float[]
        {
            -36f,
            default(float),
            -6f
        };
        array[1] = new float[]
        {
            -20f,
            6f,
            16f
        };
        array[2] = new float[]
        {
            default(float),
            8f,
            -24f
        };
        float[][] array2 = array;
        int num = 3;
        float[] array3 = new float[3];
        array3[0] = 36f;
        array2[num] = array3;
        float[][] array4 = array;
        for ( int i = 0; i < 4; i++ )
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate( parent_obj, 2U );
            AppMain.GmBoss4EffChangeType( gms_EFFECT_3DES_WORK, 2U, 19U );
            AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, array4[i][0], array4[i][1], array4[i][2] );
            AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffBodySmokeProcMain );
        }
    }

    // Token: 0x06001626 RID: 5670 RVA: 0x000C10A0 File Offset: 0x000BF2A0
    private static void gmBoss4EffBodySmokeProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS4_BODY_WORK.node_work.snm_work.reg_node_max );
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
        }
        else
        {
            obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS4_BODY_WORK.node_work.snm_work, gms_BOSS4_BODY_WORK.node_work.work[2], 1 );
    }

    // Token: 0x06001627 RID: 5671 RVA: 0x000C1138 File Offset: 0x000BF338
    private static void gmBoss4EffBossLightUpdateCreate( AppMain.GMS_BOSS4_BODY_WORK body_work )
    {
        if ( ( body_work.flag[0] & 524288U ) != 0U )
        {
            body_work.flag[0] &= 4294443007U;
            AppMain.VecFx32 vecFx = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
            AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
            AppMain.GmBoss4EffCommonInit( 744, new AppMain.VecFx32?( vecFx ), ( AppMain.OBS_OBJECT_WORK )body_work, 2U, 2U, body_work.node_work, 9, new AppMain.VecFx32?( vecFx2 ), body_work.flag, 512U );
            AppMain.VecFx32 vecFx3 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
            AppMain.VecFx32 vecFx4 = new AppMain.VecFx32(AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f), AppMain.FX_F32_TO_FX32(0f));
            AppMain.GmBoss4EffCommonInit( 744, new AppMain.VecFx32?( vecFx3 ), ( AppMain.OBS_OBJECT_WORK )body_work, 2U, 2U, body_work.node_work, 10, new AppMain.VecFx32?( vecFx4 ), body_work.flag, 512U );
        }
    }

    // Token: 0x06001628 RID: 5672 RVA: 0x000C1270 File Offset: 0x000BF470
    private static void gmBoss4EffBossLightSetEnable( AppMain.GMS_BOSS4_BODY_WORK body_work, bool on )
    {
        if ( !on )
        {
            body_work.flag[0] &= 4294966783U;
            body_work.flag[0] &= 4294443007U;
            return;
        }
        if ( ( body_work.flag[0] & 512U ) != 0U )
        {
            return;
        }
        body_work.flag[0] |= 524288U;
    }
}