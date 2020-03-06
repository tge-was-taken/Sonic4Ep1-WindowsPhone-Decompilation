using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x020002A8 RID: 680
    public class GMS_BOSS2_PART_ACT_INFO
    {
        // Token: 0x06002466 RID: 9318 RVA: 0x0014A9BB File Offset: 0x00148BBB
        public GMS_BOSS2_PART_ACT_INFO( ushort id, byte mnt, byte rpt, float spd, int blnd, float bspd, int mrg )
        {
            this.mtn_id = id;
            this.is_maintain = mnt;
            this.is_repeat = rpt;
            this.mtn_spd = spd;
            this.is_blend = blnd;
            this.blend_spd = bspd;
            this.is_merge_manual = mrg;
        }

        // Token: 0x04005AE2 RID: 23266
        public ushort mtn_id;

        // Token: 0x04005AE3 RID: 23267
        public byte is_maintain;

        // Token: 0x04005AE4 RID: 23268
        public byte is_repeat;

        // Token: 0x04005AE5 RID: 23269
        public float mtn_spd;

        // Token: 0x04005AE6 RID: 23270
        public int is_blend;

        // Token: 0x04005AE7 RID: 23271
        public float blend_spd;

        // Token: 0x04005AE8 RID: 23272
        public int is_merge_manual;
    }

    // Token: 0x020002A9 RID: 681
    public class GMS_BOSS2_EFF_BOMB_WORK
    {
        // Token: 0x04005AE9 RID: 23273
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x04005AEA RID: 23274
        public uint interval_timer;

        // Token: 0x04005AEB RID: 23275
        public uint interval_min;

        // Token: 0x04005AEC RID: 23276
        public uint interval_max;

        // Token: 0x04005AED RID: 23277
        public int[] pos = new int[2];

        // Token: 0x04005AEE RID: 23278
        public int[] area = new int[2];
    }

    // Token: 0x020002AA RID: 682
    public class GMS_BOSS2_MGR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002468 RID: 9320 RVA: 0x0014AA18 File Offset: 0x00148C18
        public GMS_BOSS2_MGR_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002469 RID: 9321 RVA: 0x0014AA2C File Offset: 0x00148C2C
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS2_MGR_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0600246A RID: 9322 RVA: 0x0014AA3E File Offset: 0x00148C3E
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005AEF RID: 23279
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005AF0 RID: 23280
        public int life;

        // Token: 0x04005AF1 RID: 23281
        public uint flag;

        // Token: 0x04005AF2 RID: 23282
        public AppMain.GMS_BOSS2_BODY_WORK body_work;

        // Token: 0x04005AF3 RID: 23283
        public int obj_create_count;
    }

    // Token: 0x020002AB RID: 683
    public class GMS_BOSS2_BODY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600246B RID: 9323 RVA: 0x0014AA50 File Offset: 0x00148C50
        public GMS_BOSS2_BODY_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600246C RID: 9324 RVA: 0x0014AAE2 File Offset: 0x00148CE2
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0600246D RID: 9325 RVA: 0x0014AAF4 File Offset: 0x00148CF4
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS2_BODY_WORK work )
        {
            return work.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005AF4 RID: 23284
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005AF5 RID: 23285
        public AppMain.OBS_OBJECT_WORK[] parts_objs = new AppMain.OBS_OBJECT_WORK[2];

        // Token: 0x04005AF6 RID: 23286
        public int state;

        // Token: 0x04005AF7 RID: 23287
        public int prev_state;

        // Token: 0x04005AF8 RID: 23288
        public AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK proc_update;

        // Token: 0x04005AF9 RID: 23289
        public uint flag;

        // Token: 0x04005AFA RID: 23290
        public int action_id;

        // Token: 0x04005AFB RID: 23291
        public float offset_arm;

        // Token: 0x04005AFC RID: 23292
        public readonly AppMain.OBS_RECT_WORK rect_work_arm = new AppMain.OBS_RECT_WORK();

        // Token: 0x04005AFD RID: 23293
        public int count_release_key;

        // Token: 0x04005AFE RID: 23294
        public int shake_pos;

        // Token: 0x04005AFF RID: 23295
        public int shake_speed;

        // Token: 0x04005B00 RID: 23296
        public uint shake_count;

        // Token: 0x04005B01 RID: 23297
        public uint counter_pinball;

        // Token: 0x04005B02 RID: 23298
        public short angle_current;

        // Token: 0x04005B03 RID: 23299
        public AppMain.VecFx32 start_pos;

        // Token: 0x04005B04 RID: 23300
        public AppMain.VecFx32 end_pos;

        // Token: 0x04005B05 RID: 23301
        public float move_counter;

        // Token: 0x04005B06 RID: 23302
        public float move_frame;

        // Token: 0x04005B07 RID: 23303
        public short turn_start;

        // Token: 0x04005B08 RID: 23304
        public int turn_amount;

        // Token: 0x04005B09 RID: 23305
        public float turn_counter;

        // Token: 0x04005B0A RID: 23306
        public float turn_frame;

        // Token: 0x04005B0B RID: 23307
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04005B0C RID: 23308
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04005B0D RID: 23309
        public int[] snm_reg_id = new int[15];

        // Token: 0x04005B0E RID: 23310
        public readonly AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work = new AppMain.GMS_BS_CMN_CNM_MGR_WORK();

        // Token: 0x04005B0F RID: 23311
        public int[] cnm_reg_id = new int[13];

        // Token: 0x04005B10 RID: 23312
        public readonly AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work = new AppMain.GMS_BS_CMN_DMG_FLICKER_WORK();

        // Token: 0x04005B11 RID: 23313
        public uint counter_no_hit;

        // Token: 0x04005B12 RID: 23314
        public uint counter_invincible;

        // Token: 0x04005B13 RID: 23315
        public readonly AppMain.GMS_CMN_FLASH_SCR_WORK flash_work = new AppMain.GMS_CMN_FLASH_SCR_WORK();

        // Token: 0x04005B14 RID: 23316
        public readonly AppMain.GMS_BOSS2_EFF_BOMB_WORK bomb_work = new AppMain.GMS_BOSS2_EFF_BOMB_WORK();

        // Token: 0x04005B15 RID: 23317
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x020002AC RID: 684
    public class GMS_BOSS2_EGG_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600246E RID: 9326 RVA: 0x0014AB06 File Offset: 0x00148D06
        public GMS_BOSS2_EGG_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600246F RID: 9327 RVA: 0x0014AB1A File Offset: 0x00148D1A
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS2_EGG_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002470 RID: 9328 RVA: 0x0014AB2C File Offset: 0x00148D2C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005B16 RID: 23318
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005B17 RID: 23319
        public int egg_action_id;

        // Token: 0x04005B18 RID: 23320
        public uint flag;

        // Token: 0x04005B19 RID: 23321
        public AppMain.MPP_VOID_GMS_BOSS2_EGG_WORK proc_update;
    }

    // Token: 0x020002AD RID: 685
    public class GMS_BOSS2_BALL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002471 RID: 9329 RVA: 0x0014AB3E File Offset: 0x00148D3E
        public GMS_BOSS2_BALL_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002472 RID: 9330 RVA: 0x0014AB5D File Offset: 0x00148D5D
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS2_BALL_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002473 RID: 9331 RVA: 0x0014AB6F File Offset: 0x00148D6F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005B1A RID: 23322
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005B1B RID: 23323
        public readonly AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work = new AppMain.GMS_BS_CMN_DMG_FLICKER_WORK();

        // Token: 0x04005B1C RID: 23324
        public AppMain.MPP_VOID_GMS_BOSS2_BALL_WORK proc_update;
    }

    // Token: 0x020002AE RID: 686
    public class GMS_BOSS2_EFFECT_SCATTER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002474 RID: 9332 RVA: 0x0014AB81 File Offset: 0x00148D81
        public GMS_BOSS2_EFFECT_SCATTER_WORK()
        {
            this.control_node_work = new AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( this );
        }

        // Token: 0x06002475 RID: 9333 RVA: 0x0014ABA1 File Offset: 0x00148DA1
        public static explicit operator AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK p )
        {
            return p.control_node_work;
        }

        // Token: 0x06002476 RID: 9334 RVA: 0x0014ABA9 File Offset: 0x00148DA9
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK p )
        {
            return p.control_node_work.efct_com.obj_work;
        }

        // Token: 0x06002477 RID: 9335 RVA: 0x0014ABBB File Offset: 0x00148DBB
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.control_node_work.efct_com.obj_work;
        }

        // Token: 0x04005B1D RID: 23325
        public readonly AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT control_node_work;

        // Token: 0x04005B1E RID: 23326
        public AppMain.NNS_QUATERNION spin_quat = default(AppMain.NNS_QUATERNION);
    }

    // Token: 0x06001265 RID: 4709 RVA: 0x000A0ED4 File Offset: 0x0009F0D4
    private static void GmBoss2Build()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmBoss2GetGameDatEnemyArc();
        AppMain.AMS_AMB_HEADER mdl_amb = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, ams_AMB_HEADER);
        AppMain.AMS_AMB_HEADER tex_amb = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 1, ams_AMB_HEADER);
        AppMain.gm_boss2_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 711 ), 2, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 713 ), 4, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 712 ), 3, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 714 ), 6, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 715 ), 7, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 716 ), 8, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 717 ), 9, ams_AMB_HEADER );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 718 ), 10, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 14, AppMain.ObjDataGet( 722 ), AppMain.ObjDataGet( 723 ), 0, null, null, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 14, AppMain.ObjDataGet( 722 ), AppMain.ObjDataGet( 723 ), 0, null, null, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 14, AppMain.ObjDataGet( 722 ), AppMain.ObjDataGet( 723 ), 0, null, null, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 14, AppMain.ObjDataGet( 722 ), AppMain.ObjDataGet( 723 ), 0, null, null, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 14, AppMain.ObjDataGet( 722 ), AppMain.ObjDataGet( 723 ), 0, null, null, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 15, AppMain.ObjDataGet( 726 ), AppMain.ObjDataGet( 727 ), 5, AppMain.ObjDataGet( 725 ), AppMain.ObjDataGet( 724 ), ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 14, AppMain.ObjDataGet( 722 ), AppMain.ObjDataGet( 723 ), 0, null, null, ams_AMB_HEADER );
        AppMain.GmEfctBossBuildSingleDataReg( 15, AppMain.ObjDataGet( 726 ), AppMain.ObjDataGet( 727 ), 5, AppMain.ObjDataGet( 725 ), AppMain.ObjDataGet( 724 ), ams_AMB_HEADER );
    }

    // Token: 0x06001266 RID: 4710 RVA: 0x000A10C0 File Offset: 0x0009F2C0
    private static void GmBoss2Flush()
    {
        AppMain.GmEfctBossFlushSingleDataInit();
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 718 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 717 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 716 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 715 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 714 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 713 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 711 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 712 ) );
        AppMain.AMS_AMB_HEADER amb = AppMain.GmBoss2GetGameDatEnemyArc();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, amb);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_boss2_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_boss2_obj_3d_list = null;
    }

    // Token: 0x06001267 RID: 4711 RVA: 0x000A1174 File Offset: 0x0009F374
    private static AppMain.AMS_AMB_HEADER GmBoss2GetGameDatEnemyArc()
    {
        return AppMain.g_gm_gamedat_enemy_arc;
    }

    // Token: 0x06001268 RID: 4712 RVA: 0x000A1184 File Offset: 0x0009F384
    private static AppMain.OBS_OBJECT_WORK GmBoss2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = (AppMain.GMS_BOSS2_MGR_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS2_MGR_WORK(), "BOSS2_MGR");
        AppMain.OBS_OBJECT_WORK obj_work = gms_BOSS2_MGR_WORK.ene_3d.ene_com.obj_work;
        obj_work.flag |= 16U;
        obj_work.disp_flag |= 32U;
        obj_work.move_flag |= 8448U;
        gms_BOSS2_MGR_WORK.ene_3d.ene_com.enemy_flag |= 32768U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2MgrMainFuncWaitLoad );
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            gms_BOSS2_MGR_WORK.life = 4;
        }
        else
        {
            gms_BOSS2_MGR_WORK.life = 8;
        }
        return obj_work;
    }

    // Token: 0x06001269 RID: 4713 RVA: 0x000A1250 File Offset: 0x0009F450
    private static AppMain.OBS_OBJECT_WORK GmBoss2BodyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS2_BODY_WORK(), "BOSS2_BODY");
        AppMain.GMS_ENEMY_3D_WORK ene_3d = gms_BOSS2_BODY_WORK.ene_3d;
        AppMain.OBS_OBJECT_WORK obj_work = ene_3d.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_boss2_obj_3d_list[1], ene_3d.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, true, AppMain.ObjDataGet( 711 ), null, 0, null );
        ene_3d.ene_com.vit = 1;
        AppMain.ObjRectWorkSet( ene_3d.ene_com.rect_work[2], -16, -16, 16, 16 );
        AppMain.ObjRectGroupSet( ene_3d.ene_com.rect_work[2], 1, 3 );
        ene_3d.ene_com.rect_work[2].flag &= 4294967291U;
        ene_3d.ene_com.rect_work[2].flag |= 1024U;
        gms_BOSS2_BODY_WORK.ene_3d.ene_com.rect_work[1].flag |= 1024U;
        AppMain.ObjRectWorkSet( ene_3d.ene_com.rect_work[0], -26, -26, 26, 26 );
        ene_3d.ene_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss2BodyDefFunc );
        ene_3d.ene_com.rect_work[0].flag |= 1024U;
        AppMain.gmBoss2BodySetRectArm( gms_BOSS2_BODY_WORK );
        AppMain.gmBoss2BodySetRectNormal( gms_BOSS2_BODY_WORK );
        AppMain.ObjObjectFieldRectSet( obj_work, -24, -24, 24, 24 );
        obj_work.pos.z = 131072;
        obj_work.flag |= 16U;
        obj_work.disp_flag |= 4194309U;
        obj_work.move_flag &= 4294967167U;
        obj_work.move_flag |= 49168U;
        obj_work.obj_3d.blend_spd = 0.125f;
        AppMain.ObjDrawObjectSetToon( obj_work );
        obj_work.disp_flag |= 134217728U;
        gms_BOSS2_BODY_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2BodyMainFuncWaitSetup );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2BodyOutFunc );
        AppMain.gmBoss2BodyChangeState( gms_BOSS2_BODY_WORK, 0 );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return obj_work;
    }

    // Token: 0x0600126A RID: 4714 RVA: 0x000A14B4 File Offset: 0x0009F6B4
    private static AppMain.OBS_OBJECT_WORK GmBoss2EggInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS2_EGG_WORK gms_BOSS2_EGG_WORK = (AppMain.GMS_BOSS2_EGG_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS2_EGG_WORK(), "BOSS2_EGG");
        AppMain.GMS_ENEMY_3D_WORK ene_3d = gms_BOSS2_EGG_WORK.ene_3d;
        AppMain.OBS_OBJECT_WORK obj_work = ene_3d.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_boss2_obj_3d_list[2], ene_3d.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, true, AppMain.ObjDataGet( 713 ), null, 0, null );
        ene_3d.ene_com.rect_work[1].flag |= 3072U;
        ene_3d.ene_com.rect_work[0].flag |= 3072U;
        ene_3d.ene_com.rect_work[2].flag |= 3072U;
        obj_work.flag |= 16U;
        obj_work.disp_flag |= 4194309U;
        obj_work.move_flag |= 4352U;
        obj_work.move_flag &= 4294967167U;
        obj_work.obj_3d.blend_spd = 0.125f;
        AppMain.ObjDrawObjectSetToon( obj_work );
        obj_work.disp_flag |= 134217728U;
        ene_3d.ene_com.enemy_flag |= 32768U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EggmanMainFuncWaitSetup );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return obj_work;
    }

    // Token: 0x0600126B RID: 4715 RVA: 0x000A164C File Offset: 0x0009F84C
    private static AppMain.OBS_OBJECT_WORK GmBoss2BallInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS2_BALL_WORK gms_BOSS2_BALL_WORK = (AppMain.GMS_BOSS2_BALL_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS2_BALL_WORK(), "BOSS2_BALL");
        AppMain.GMS_ENEMY_3D_WORK ene_3d = gms_BOSS2_BALL_WORK.ene_3d;
        AppMain.OBS_OBJECT_WORK obj_work = ene_3d.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_boss2_obj_3d_list[0], ene_3d.obj_3d );
        AppMain.ObjRectWorkSet( ene_3d.ene_com.rect_work[1], -8, -8, 8, 8 );
        ene_3d.ene_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss2BallHitFunc );
        ene_3d.ene_com.rect_work[1].flag |= 1024U;
        ene_3d.ene_com.rect_work[0].flag |= 2048U;
        ene_3d.ene_com.rect_work[2].flag |= 2048U;
        ene_3d.ene_com.enemy_flag |= 32768U;
        obj_work.disp_flag |= 4194304U;
        obj_work.obj_3d.blend_spd = 0.125f;
        AppMain.ObjDrawObjectSetToon( obj_work );
        obj_work.disp_flag |= 134217728U;
        AppMain.ObjObjectFieldRectSet( obj_work, -4, -8, 4, 6 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2BallMainFuncWaitSetup );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return obj_work;
    }

    // Token: 0x0600126C RID: 4716 RVA: 0x000A17D8 File Offset: 0x0009F9D8
    private static void gmBoss2ChangeTextureBurnt( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d.drawflag |= 268435456U;
        obj_work.obj_3d.draw_state.texoffset[0].mode = 2;
        obj_work.obj_3d.draw_state.texoffset[0].u = 0.5f;
    }

    // Token: 0x0600126D RID: 4717 RVA: 0x000A1830 File Offset: 0x0009FA30
    private static void gmBoss2ExitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss2MgrDeleteObject( obj_work_parts );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x0600126E RID: 4718 RVA: 0x000A1850 File Offset: 0x0009FA50
    private static void gmBoss2EffectExitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss2MgrDeleteObject( obj_work_parts );
        AppMain.GmEffectDefaultExit( tcb );
    }

    // Token: 0x0600126F RID: 4719 RVA: 0x000A1870 File Offset: 0x0009FA70
    private static int gmBoss2CheckScrollLocked()
    {
        if ( ( AppMain.g_gm_main_system.game_flag & 32768U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001270 RID: 4720 RVA: 0x000A1887 File Offset: 0x0009FA87
    private static int gmBoss2MgrCheckSetupComplete( AppMain.GMS_BOSS2_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 1U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001271 RID: 4721 RVA: 0x000A1896 File Offset: 0x0009FA96
    private static AppMain.GMS_BOSS2_MGR_WORK gmBoss2MgrGetMgrWork( AppMain.OBS_OBJECT_WORK obj_work_parts )
    {
        return ( AppMain.GMS_BOSS2_MGR_WORK )obj_work_parts.user_work_OBJECT;
    }

    // Token: 0x06001272 RID: 4722 RVA: 0x000A18A3 File Offset: 0x0009FAA3
    private static void gmBoss2MgrAddObject( AppMain.GMS_BOSS2_MGR_WORK mgr_work, AppMain.OBS_OBJECT_WORK obj_work_parts )
    {
        mgr_work.obj_create_count++;
        obj_work_parts.user_work_OBJECT = mgr_work;
    }

    // Token: 0x06001273 RID: 4723 RVA: 0x000A18BC File Offset: 0x0009FABC
    private static void gmBoss2MgrDeleteObject( AppMain.OBS_OBJECT_WORK obj_work_parts )
    {
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = AppMain.gmBoss2MgrGetMgrWork(obj_work_parts);
        gms_BOSS2_MGR_WORK.obj_create_count--;
        obj_work_parts.user_work = 0U;
    }

    // Token: 0x06001274 RID: 4724 RVA: 0x000A18E8 File Offset: 0x0009FAE8
    private static void gmBoss2MgrMainFuncWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 && !AppMain.GmMainDatLoadBossBattleLoadCheck( 1 ) )
        {
            return;
        }
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = (AppMain.GMS_BOSS2_MGR_WORK)obj_work;
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)AppMain.GmEventMgrLocalEventBirth(316, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_BOSS2_BODY_WORK.ene_3d.ene_com.obj_work;
        obj_work2.parent_obj = obj_work;
        gms_BOSS2_BODY_WORK.parts_objs[0] = obj_work2;
        gms_BOSS2_MGR_WORK.body_work = gms_BOSS2_BODY_WORK;
        AppMain.gmBoss2MgrAddObject( gms_BOSS2_MGR_WORK, obj_work2 );
        AppMain.mtTaskChangeTcbDestructor( obj_work2.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2BodyExit ) );
        AppMain.GMS_BOSS2_EGG_WORK gms_BOSS2_EGG_WORK = (AppMain.GMS_BOSS2_EGG_WORK)AppMain.GmEventMgrLocalEventBirth(317, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
        AppMain.OBS_OBJECT_WORK obj_work3 = gms_BOSS2_EGG_WORK.ene_3d.ene_com.obj_work;
        obj_work3.parent_obj = obj_work2;
        AppMain.gmBoss2MgrAddObject( gms_BOSS2_MGR_WORK, obj_work3 );
        AppMain.mtTaskChangeTcbDestructor( obj_work3.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2ExitFunc ) );
        gms_BOSS2_BODY_WORK.parts_objs[1] = obj_work3;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2MgrMainFuncWaitSetup );
    }

    // Token: 0x06001275 RID: 4725 RVA: 0x000A1A04 File Offset: 0x0009FC04
    private static void gmBoss2MgrMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = (AppMain.GMS_BOSS2_MGR_WORK)obj_work;
        AppMain.GMS_BOSS2_BODY_WORK body_work = gms_BOSS2_MGR_WORK.body_work;
        int num = 0;
        while ( 2 > num )
        {
            if ( body_work.parts_objs[num] == null )
            {
                return;
            }
            num++;
        }
        gms_BOSS2_MGR_WORK.flag |= 1U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2MgrMainFunc );
    }

    // Token: 0x06001276 RID: 4726 RVA: 0x000A1A58 File Offset: 0x0009FC58
    private static void gmBoss2MgrMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = (AppMain.GMS_BOSS2_MGR_WORK)obj_work;
        if ( ( gms_BOSS2_MGR_WORK.flag & 2U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS2_MGR_WORK.body_work);
            obs_OBJECT_WORK.flag |= 8U;
            gms_BOSS2_MGR_WORK.body_work = null;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2MgrMainFuncWaitRelease );
        }
    }

    // Token: 0x06001277 RID: 4727 RVA: 0x000A1AAC File Offset: 0x0009FCAC
    private static void gmBoss2MgrMainFuncWaitRelease( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = (AppMain.GMS_BOSS2_MGR_WORK)obj_work;
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            if ( gms_BOSS2_MGR_WORK.obj_create_count > 0 )
            {
                return;
            }
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
            obj_work.flag |= 4U;
            AppMain.GmGameDatReleaseBossBattleStart( 1 );
            AppMain.GmGmkCamScrLimitRelease( 14 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss2BodySearchShutterOut();
            if ( obs_OBJECT_WORK != null )
            {
                AppMain.GmGmkShutterOutChangeModeOpen( obs_OBJECT_WORK );
            }
        }
        obj_work.ppFunc = null;
    }

    // Token: 0x06001278 RID: 4728 RVA: 0x000A1B20 File Offset: 0x0009FD20
    private static void gmBoss2BodyExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.OBS_OBJECT_WORK obj_work = gms_BOSS2_BODY_WORK.ene_3d.ene_com.obj_work;
        AppMain.GmBsCmnClearBossMotionCBSystem( obj_work );
        AppMain.GmBsCmnDeleteSNMWork( gms_BOSS2_BODY_WORK.snm_work );
        AppMain.GmBsCmnClearCNMCb( obj_work );
        AppMain.GmBsCmnDeleteCNMMgrWork( gms_BOSS2_BODY_WORK.cnm_mgr_work );
        if ( gms_BOSS2_BODY_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_BOSS2_BODY_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_BOSS2_BODY_WORK.se_handle );
            gms_BOSS2_BODY_WORK.se_handle = null;
        }
        AppMain.gmBoss2ExitFunc( tcb );
    }

    // Token: 0x06001279 RID: 4729 RVA: 0x000A1B98 File Offset: 0x0009FD98
    private static void gmBoss2BodyReactionPlayer( AppMain.OBS_OBJECT_WORK obj_work_player, AppMain.OBS_OBJECT_WORK obj_work_body )
    {
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)obj_work_player;
        AppMain.GmPlySeqAtkReactionInit( ply_work );
        AppMain.GmPlySeqSetJumpState( ply_work, 0, 5U );
        obj_work_player.spd_m = 0;
        if ( obj_work_player.move.x >= 0 )
        {
            obj_work_player.spd.x = -20480;
        }
        else
        {
            obj_work_player.spd.x = 20480;
        }
        if ( obj_work_player.pos.y <= obj_work_body.pos.y )
        {
            obj_work_player.spd.y = -16384;
        }
        else
        {
            obj_work_player.spd.y = 16384;
        }
        AppMain.GmPlySeqSetNoJumpMoveTime( ply_work, 102400 );
    }

    // Token: 0x0600127A RID: 4730 RVA: 0x000A1C38 File Offset: 0x0009FE38
    private static void gmBoss2BodyRecFuncRegistArmRect( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work;
        AppMain.ObjObjectRectRegist( obj_work, gms_BOSS2_BODY_WORK.rect_work_arm );
    }

    // Token: 0x0600127B RID: 4731 RVA: 0x000A1C58 File Offset: 0x0009FE58
    private static void gmBoss2BodyCatchChangeArmRectNormal( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_RECT_WORK rect_work_arm = body_work.rect_work_arm;
        rect_work_arm.ppHit = null;
        rect_work_arm.ppDef = null;
        AppMain.ObjRectAtkSet( rect_work_arm, 0, 0 );
        AppMain.ObjRectDefSet( rect_work_arm, 0, 0 );
        rect_work_arm.flag &= 4294967291U;
    }

    // Token: 0x0600127C RID: 4732 RVA: 0x000A1C9C File Offset: 0x0009FE9C
    private static void gmBoss2BodyCatchChangeArmRectActive( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_RECT_WORK rect_work_arm = body_work.rect_work_arm;
        rect_work_arm.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss2BodyHitFunc );
        rect_work_arm.ppDef = null;
        AppMain.ObjRectAtkSet( rect_work_arm, 2, 1 );
        AppMain.ObjRectDefSet( rect_work_arm, ushort.MaxValue, 0 );
        rect_work_arm.flag |= 4U;
    }

    // Token: 0x0600127D RID: 4733 RVA: 0x000A1CEC File Offset: 0x0009FEEC
    private static void gmBoss2BodyCatchChangeArmRectCatch( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_RECT_WORK rect_work_arm = body_work.rect_work_arm;
        rect_work_arm.ppHit = null;
        rect_work_arm.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss2BodyCatchHitFuncArmCatch );
        AppMain.ObjRectAtkSet( rect_work_arm, 0, 0 );
        AppMain.ObjRectDefSet( rect_work_arm, 65534, 0 );
        rect_work_arm.flag |= 4U;
    }

    // Token: 0x0600127E RID: 4734 RVA: 0x000A1D3C File Offset: 0x0009FF3C
    private static void gmBoss2BodySetRectNormal( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], 0, 0, 0, 0 );
        body_work.ene_3d.ene_com.rect_work[0].flag |= 4U;
        AppMain.gmBoss2BodyCatchChangeArmRectNormal( body_work );
    }

    // Token: 0x0600127F RID: 4735 RVA: 0x000A1D8C File Offset: 0x0009FF8C
    private static void gmBoss2BodySetRectActive( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -8, -8, 8, 8 );
        body_work.ene_3d.ene_com.rect_work[0].flag |= 4U;
        AppMain.gmBoss2BodyCatchChangeArmRectActive( body_work );
    }

    // Token: 0x06001280 RID: 4736 RVA: 0x000A1DDC File Offset: 0x0009FFDC
    private static void gmBoss2BodySetRectRoll( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -36, -36, 36, 36 );
        body_work.ene_3d.ene_com.rect_work[0].flag &= 4294967291U;
        AppMain.gmBoss2BodyCatchChangeArmRectNormal( body_work );
    }

    // Token: 0x06001281 RID: 4737 RVA: 0x000A1E30 File Offset: 0x000A0030
    private static void gmBoss2BodySetRectArm( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)body_work;
        AppMain.OBS_RECT_WORK rect_work_arm = body_work.rect_work_arm;
        AppMain.ObjRectGroupSet( rect_work_arm, 1, 1 );
        AppMain.gmBoss2BodyRectApplyOffsetArm( body_work );
        rect_work_arm.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss2BodyHitFunc );
        rect_work_arm.parent_obj = obs_OBJECT_WORK;
        rect_work_arm.flag |= 1028U;
        obs_OBJECT_WORK.ppRec = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2BodyRecFuncRegistArmRect );
        AppMain.gmBoss2BodyCatchChangeArmRectNormal( body_work );
    }

    // Token: 0x06001282 RID: 4738 RVA: 0x000A1E9C File Offset: 0x000A009C
    private static void gmBoss2BodyRectApplyOffsetArm( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_RECT_WORK rect_work_arm = body_work.rect_work_arm;
        uint flag = rect_work_arm.flag;
        AppMain.ObjRectWorkSet( rect_work_arm, -40, ( short )( 24f - body_work.offset_arm ), 40, ( short )( 40f - body_work.offset_arm ) );
        rect_work_arm.flag = flag;
    }

    // Token: 0x06001283 RID: 4739 RVA: 0x000A1EE3 File Offset: 0x000A00E3
    private static void gmBoss2BodySetActionAllParts( AppMain.GMS_BOSS2_BODY_WORK body_work, int action_id )
    {
        AppMain.gmBoss2BodySetActionAllParts( body_work, action_id, 0 );
    }

    // Token: 0x06001284 RID: 4740 RVA: 0x000A1EF0 File Offset: 0x000A00F0
    private static void gmBoss2BodySetActionAllParts( AppMain.GMS_BOSS2_BODY_WORK body_work, int action_id, int force_change )
    {
        if ( force_change == 0 && body_work.action_id == action_id )
        {
            return;
        }
        body_work.action_id = action_id;
        int num = 0;
        while ( 2 > num )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = body_work.parts_objs[num];
            if ( obs_OBJECT_WORK != null )
            {
                AppMain.GMS_BOSS2_PART_ACT_INFO gms_BOSS2_PART_ACT_INFO = AppMain.gm_boss2_act_info_tbl[action_id][num];
                if ( num == 1 )
                {
                    AppMain.GMS_BOSS2_EGG_WORK gms_BOSS2_EGG_WORK = (AppMain.GMS_BOSS2_EGG_WORK)obs_OBJECT_WORK;
                    if ( ( gms_BOSS2_EGG_WORK.flag & 1U ) != 0U )
                    {
                        goto IL_A2;
                    }
                }
                if ( gms_BOSS2_PART_ACT_INFO.is_maintain != 0 )
                {
                    if ( gms_BOSS2_PART_ACT_INFO.is_repeat != 0 )
                    {
                        obs_OBJECT_WORK.disp_flag |= 4U;
                    }
                }
                else
                {
                    AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS2_PART_ACT_INFO.mtn_id, ( int )gms_BOSS2_PART_ACT_INFO.is_repeat, gms_BOSS2_PART_ACT_INFO.is_blend );
                }
                obs_OBJECT_WORK.obj_3d.speed[0] = gms_BOSS2_PART_ACT_INFO.mtn_spd;
                obs_OBJECT_WORK.obj_3d.blend_spd = gms_BOSS2_PART_ACT_INFO.blend_spd;
            }
            IL_A2:
            num++;
        }
    }

    // Token: 0x06001285 RID: 4741 RVA: 0x000A1FAC File Offset: 0x000A01AC
    private static void gmBoss2BodyOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work;
        AppMain.GmBsCmnUpdateCNMParam( obj_work, gms_BOSS2_BODY_WORK.cnm_mgr_work );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06001286 RID: 4742 RVA: 0x000A1FD4 File Offset: 0x000A01D4
    private static void gmBoss2BodyDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = target_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = own_rect.parent_obj;
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)parent_obj2;
        if ( parent_obj == null || 1 != parent_obj.obj_type )
        {
            return;
        }
        AppMain.gmBoss2BodyReactionPlayer( parent_obj, parent_obj2 );
        AppMain.gmBoss2BodySetNoHitTime( gms_BOSS2_BODY_WORK, 10U );
        AppMain.OBS_RECT_WORK rect_work_arm = gms_BOSS2_BODY_WORK.rect_work_arm;
        if ( ( rect_work_arm.flag & 4U ) != 0U && parent_obj2.pos.y < parent_obj.pos.y )
        {
            return;
        }
        AppMain.gmBoss2BodyDamage( gms_BOSS2_BODY_WORK );
    }

    // Token: 0x06001287 RID: 4743 RVA: 0x000A2044 File Offset: 0x000A0244
    private static void gmBoss2BodyHitFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.UNREFERENCED_PARAMETER( target_rect );
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)parent_obj;
        gms_BOSS2_BODY_WORK.flag |= 268435456U;
    }

    // Token: 0x06001288 RID: 4744 RVA: 0x000A2078 File Offset: 0x000A0278
    private static AppMain.OBS_OBJECT_WORK gmBoss2BodySearchShutterIn()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        for ( obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id == 261 )
            {
                break;
            }
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001289 RID: 4745 RVA: 0x000A20BC File Offset: 0x000A02BC
    private static AppMain.OBS_OBJECT_WORK gmBoss2BodySearchShutterOut()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        for ( obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_COM_WORK.eve_rec.id == 262 )
            {
                break;
            }
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600128A RID: 4746 RVA: 0x000A20F8 File Offset: 0x000A02F8
    private static void gmBoss2BodySetNoHitTime( AppMain.GMS_BOSS2_BODY_WORK body_work, uint time )
    {
        AppMain.GMS_ENEMY_COM_WORK ene_com = body_work.ene_3d.ene_com;
        body_work.counter_no_hit = time;
        ene_com.rect_work[0].flag |= 2048U;
    }

    // Token: 0x0600128B RID: 4747 RVA: 0x000A2134 File Offset: 0x000A0334
    private static void gmBoss2BodyUpdateNoHitTime( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        if ( body_work.counter_no_hit > 0U )
        {
            body_work.counter_no_hit -= 1U;
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK ene_com = body_work.ene_3d.ene_com;
        ene_com.rect_work[0].flag &= 4294965247U;
    }

    // Token: 0x0600128C RID: 4748 RVA: 0x000A217E File Offset: 0x000A037E
    private static void gmBoss2BodySetInvincibleTime( AppMain.GMS_BOSS2_BODY_WORK body_work, uint time )
    {
        body_work.counter_invincible = time;
        body_work.flag |= 1U;
    }

    // Token: 0x0600128D RID: 4749 RVA: 0x000A2195 File Offset: 0x000A0395
    private static void gmBoss2BodyUpdateInvincibleTime( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        if ( body_work.counter_invincible > 0U )
        {
            body_work.counter_invincible -= 1U;
            return;
        }
        body_work.flag &= 4294967294U;
    }

    // Token: 0x0600128E RID: 4750 RVA: 0x000A21BE File Offset: 0x000A03BE
    private static void gmBoss2BodySetDirection( AppMain.GMS_BOSS2_BODY_WORK body_work, short deg )
    {
        body_work.angle_current = deg;
    }

    // Token: 0x0600128F RID: 4751 RVA: 0x000A21C8 File Offset: 0x000A03C8
    private static void gmBoss2BodySetDirectionNormal( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss2BodySetDirection( body_work, AppMain.GMD_BOSS2_ANGLE_LEFT );
            return;
        }
        AppMain.gmBoss2BodySetDirection( body_work, AppMain.GMD_BOSS2_ANGLE_RIGHT );
    }

    // Token: 0x06001290 RID: 4752 RVA: 0x000A2200 File Offset: 0x000A0400
    private static void gmBoss2BodySetDirectionRoll( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss2BodySetDirection( body_work, AppMain.GMD_BOSS2_BODY_PINBALL_ANGLE_LEFT_ROLL );
            return;
        }
        AppMain.gmBoss2BodySetDirection( body_work, AppMain.GMD_BOSS2_BODY_PINBALL_ANGLE_RIGHT_ROLL );
    }

    // Token: 0x06001291 RID: 4753 RVA: 0x000A2238 File Offset: 0x000A0438
    private static void gmBoss2BodyUpdateDirection( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.dir.y = ( ushort )body_work.angle_current;
    }

    // Token: 0x06001292 RID: 4754 RVA: 0x000A2260 File Offset: 0x000A0460
    private static float gmBoss2BodyCalcMoveXNormalFrame( AppMain.GMS_BOSS2_BODY_WORK body_work, int x, int speed )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.MTM_MATH_ABS(x - obs_OBJECT_WORK.pos.x);
        return ( float )num / ( float )speed;
    }

    // Token: 0x06001293 RID: 4755 RVA: 0x000A2290 File Offset: 0x000A0490
    private static void gmBoss2BodyInitMoveNormal( AppMain.GMS_BOSS2_BODY_WORK body_work, AppMain.VecFx32 dest_pos, float frame )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        body_work.start_pos.x = obs_OBJECT_WORK.pos.x;
        body_work.start_pos.y = obs_OBJECT_WORK.pos.y;
        body_work.start_pos.z = obs_OBJECT_WORK.pos.z;
        body_work.end_pos.x = dest_pos.x;
        body_work.end_pos.y = dest_pos.y;
        body_work.end_pos.z = body_work.start_pos.z;
        body_work.move_counter = 0f;
        if ( frame > 0f )
        {
            body_work.move_frame = frame;
            return;
        }
        body_work.move_frame = 1f;
    }

    // Token: 0x06001294 RID: 4756 RVA: 0x000A2348 File Offset: 0x000A0548
    private static float gmBoss2BodyUpdateMoveNormal( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        body_work.move_counter += 1f;
        if ( body_work.move_counter >= body_work.move_frame )
        {
            vecFx.x = body_work.end_pos.x;
            vecFx.y = body_work.end_pos.y;
            vecFx.z = body_work.end_pos.z;
        }
        else
        {
            float num = body_work.move_counter / body_work.move_frame;
            int ang = AppMain.AKM_DEGtoA32(180f * num);
            float num2 = 0.5f * (1f - AppMain.nnCos(ang));
            AppMain.VecFx32 vecFx2 = default(AppMain.VecFx32);
            vecFx2.x = ( int )( ( float )( body_work.end_pos.x - body_work.start_pos.x ) * num2 );
            vecFx2.y = ( int )( ( float )( body_work.end_pos.y - body_work.start_pos.y ) * num2 );
            vecFx2.z = ( int )( ( float )( body_work.end_pos.z - body_work.start_pos.z ) * num2 );
            vecFx.x = body_work.start_pos.x + vecFx2.x;
            vecFx.y = body_work.start_pos.y + vecFx2.y;
            vecFx.z = body_work.start_pos.z + vecFx2.z;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.pos.x = vecFx.x;
        obs_OBJECT_WORK.pos.y = vecFx.y;
        obs_OBJECT_WORK.pos.z = vecFx.z;
        return body_work.move_frame - body_work.move_counter;
    }

    // Token: 0x06001295 RID: 4757 RVA: 0x000A24F0 File Offset: 0x000A06F0
    private static void gmBoss2BodyInitMovePinBall( AppMain.GMS_BOSS2_BODY_WORK body_work, AppMain.VecFx32 dir_pos, int speed )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = dir_pos.x - obs_OBJECT_WORK.pos.x;
        vecFx.y = dir_pos.y - obs_OBJECT_WORK.pos.y;
        vecFx.z = 0;
        if ( vecFx.x > 2048000 )
        {
            vecFx.x = 2048000;
        }
        else if ( vecFx.x < -2048000 )
        {
            vecFx.x = -2048000;
        }
        if ( vecFx.y > 2048000 )
        {
            vecFx.y = 2048000;
        }
        else if ( vecFx.y < -2048000 )
        {
            vecFx.y = -2048000;
        }
        int num = AppMain.FX_Sqrt(AppMain.FX_Mul(vecFx.x, vecFx.x) + AppMain.FX_Mul(vecFx.y, vecFx.y));
        if ( num != 0 )
        {
            obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( AppMain.FX_Div( vecFx.x, num ), speed );
            obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( AppMain.FX_Div( vecFx.y, num ), speed );
        }
    }

    // Token: 0x06001296 RID: 4758 RVA: 0x000A2620 File Offset: 0x000A0820
    private static int gmBoss2BodyPinBallCheckFieldUnder( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001297 RID: 4759 RVA: 0x000A262F File Offset: 0x000A082F
    private static int gmBoss2BodyPinBallCheckFieldOver( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 2U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001298 RID: 4760 RVA: 0x000A263E File Offset: 0x000A083E
    private static int gmBoss2BodyPinBallCheckFieldFront( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 4U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001299 RID: 4761 RVA: 0x000A264D File Offset: 0x000A084D
    private static int gmBoss2BodyPinBallCheckFieldBack( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 8U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x0600129A RID: 4762 RVA: 0x000A265C File Offset: 0x000A085C
    private static void gmBoss2BodyUpdateMovePinBall( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = 0;
        int num2 = AppMain.MTM_MATH_ABS(obs_OBJECT_WORK.spd.x);
        int num3 = AppMain.MTM_MATH_ABS(obs_OBJECT_WORK.spd.y);
        if ( AppMain.gmBoss2BodyPinBallCheckFieldUnder( obs_OBJECT_WORK ) != 0 )
        {
            obs_OBJECT_WORK.spd.y = -num3;
            if ( ( long )AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) < 256L )
            {
                obs_OBJECT_WORK.spd.x = 256;
            }
            obs_OBJECT_WORK.move_flag |= 32784U;
            num = 1;
        }
        else if ( AppMain.gmBoss2BodyPinBallCheckFieldOver( obs_OBJECT_WORK ) != 0 )
        {
            obs_OBJECT_WORK.spd.y = num3;
            if ( ( long )AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) < 256L )
            {
                obs_OBJECT_WORK.spd.x = 256;
            }
            obs_OBJECT_WORK.move_flag |= 32784U;
            num = 1;
        }
        if ( AppMain.gmBoss2BodyPinBallCheckFieldFront( obs_OBJECT_WORK ) != 0 || AppMain.gmBoss2BodyPinBallCheckFieldBack( obs_OBJECT_WORK ) != 0 )
        {
            if ( obs_OBJECT_WORK.spd.x < 0 )
            {
                obs_OBJECT_WORK.spd.x = num2;
            }
            else
            {
                obs_OBJECT_WORK.spd.x = -num2;
            }
            if ( ( long )AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.y ) < 256L )
            {
                obs_OBJECT_WORK.spd.y = 256;
            }
            obs_OBJECT_WORK.move_flag |= 32784U;
            num = 1;
        }
        if ( num != 0 )
        {
            if ( ( body_work.flag & 128U ) == 0U )
            {
                AppMain.GmSoundPlaySE( "Boss2_05" );
                body_work.flag |= 128U;
                return;
            }
        }
        else
        {
            body_work.flag &= 4294967167U;
        }
    }

    // Token: 0x0600129B RID: 4763 RVA: 0x000A27F0 File Offset: 0x000A09F0
    private static void gmBoss2BodyInitTurn( AppMain.GMS_BOSS2_BODY_WORK body_work, short dest_angle, float frame, int flag_positive )
    {
        body_work.turn_counter = 0f;
        body_work.turn_frame = frame;
        body_work.turn_start = body_work.angle_current;
        ushort turn_amount = (ushort)(dest_angle - body_work.angle_current);
        body_work.turn_amount = ( int )turn_amount;
        if ( flag_positive == 0 )
        {
            ushort num = (ushort)(body_work.turn_amount - AppMain.AKM_DEGtoA32(360));
            body_work.turn_amount = ( int )num - AppMain.AKM_DEGtoA32( 360 );
        }
    }

    // Token: 0x0600129C RID: 4764 RVA: 0x000A2854 File Offset: 0x000A0A54
    private static float gmBoss2BodyUpdateTurn( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        if ( body_work.turn_frame < 1f )
        {
            return 0f;
        }
        body_work.turn_counter += 1f;
        short deg;
        if ( body_work.turn_counter >= body_work.turn_frame )
        {
            deg = ( short )( body_work.turn_start + ( short )body_work.turn_amount );
        }
        else
        {
            float num = body_work.turn_counter / body_work.turn_frame;
            int ang = AppMain.AKM_DEGtoA32(180f * num);
            float num2 = (float)body_work.turn_amount * 0.5f * (1f - AppMain.nnCos(ang));
            deg = ( short )( body_work.turn_start + ( short )num2 );
        }
        AppMain.gmBoss2BodySetDirection( body_work, deg );
        return body_work.turn_frame - body_work.turn_counter;
    }

    // Token: 0x0600129D RID: 4765 RVA: 0x000A28FC File Offset: 0x000A0AFC
    private static int gmBoss2BodyCatchArmCheckTarget( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        if ( ( body_work.flag & 16U ) != 0U )
        {
            return 0;
        }
        if ( obs_OBJECT_WORK2.pos.y < obs_OBJECT_WORK.pos.y )
        {
            return 0;
        }
        int num = AppMain.MTM_MATH_ABS(obs_OBJECT_WORK2.pos.x - obs_OBJECT_WORK.pos.x);
        if ( num > 32768 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x0600129E RID: 4766 RVA: 0x000A2968 File Offset: 0x000A0B68
    private static int gmBoss2BodyCatchArmCountReleaseKey( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)p;
        int num = 0;
        int num2 = 0;
        while ( 16 > num2 )
        {
            if ( ( ( int )( 255 & gms_PLAYER_WORK.key_push ) & 1 << num2 ) != 0 )
            {
                body_work.count_release_key++;
                num = 1;
            }
            num2++;
        }
        if ( num != 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x0600129F RID: 4767 RVA: 0x000A29BC File Offset: 0x000A0BBC
    private static int gmBoss2BodyCatchArmCheckRelease( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        if ( body_work.count_release_key < 6 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060012A0 RID: 4768 RVA: 0x000A29CC File Offset: 0x000A0BCC
    private static void gmBoss2BodyCatchArmUpdateShakePlayer( AppMain.GMS_BOSS2_BODY_WORK body_work, uint shake_count )
    {
        body_work.shake_pos += body_work.shake_speed;
        int num = AppMain.MTM_MATH_ABS(body_work.shake_pos);
        int num2 = AppMain.MTM_MATH_ABS(body_work.shake_speed);
        if ( num > 5 )
        {
            body_work.shake_speed = -body_work.shake_speed;
        }
        else if ( num < num2 )
        {
            body_work.shake_count += 1U;
        }
        if ( body_work.shake_count >= shake_count * 2U )
        {
            body_work.shake_speed = 0;
            body_work.shake_pos = 0;
            body_work.shake_count = 0U;
        }
    }

    // Token: 0x060012A1 RID: 4769 RVA: 0x000A2A4C File Offset: 0x000A0C4C
    private static void gmBoss2BodyCatchSetArmLength( AppMain.GMS_BOSS2_BODY_WORK body_work, float length )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(body_work.snm_work, body_work.snm_reg_id[2]);
        AppMain.NNS_MATRIX dst_mtx = new AppMain.NNS_MATRIX();
        AppMain.AkMathExtractScaleMtx( dst_mtx, nns_MATRIX );
        AppMain.NNS_MATRIX nns_MATRIX2 = new AppMain.NNS_MATRIX();
        AppMain.nnMakeTranslateMatrix( nns_MATRIX2, 0f, length / nns_MATRIX.M11, 0f );
        int num = 0;
        while ( 13 > num )
        {
            int cnm_reg_id = body_work.cnm_reg_id[num];
            AppMain.GmBsCmnChangeCNMModeNode( body_work.cnm_mgr_work, cnm_reg_id, 1U );
            AppMain.GmBsCmnSetCNMMtx( body_work.cnm_mgr_work, nns_MATRIX2, cnm_reg_id );
            AppMain.GmBsCmnEnableCNMLocalCoordinate( body_work.cnm_mgr_work, cnm_reg_id, 1 );
            AppMain.GmBsCmnEnableCNMMtxNode( body_work.cnm_mgr_work, cnm_reg_id, 1 );
            AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
            num++;
        }
    }

    // Token: 0x060012A2 RID: 4770 RVA: 0x000A2AF0 File Offset: 0x000A0CF0
    private static void gmBoss2BodyCatchHitFuncArmCatch( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        own_rect.flag &= 4294967291U;
        AppMain.GmPlySeqGmkInitBoss2Catch( ply_work );
        gms_BOSS2_BODY_WORK.flag |= 8U;
        gms_BOSS2_BODY_WORK.flag |= 268435456U;
    }

    // Token: 0x060012A3 RID: 4771 RVA: 0x000A2B58 File Offset: 0x000A0D58
    private static void gmBoss2BodyCatchChangeNeedleModeActive()
    {
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_3D_WORK == null )
            {
                AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
                if ( gms_ENEMY_COM_WORK.eve_rec.id == 337 )
                {
                    AppMain.GmGmkNeedleNeonChangeModeActive( obs_OBJECT_WORK );
                }
            }
            else if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id == 337 )
            {
                AppMain.GmGmkNeedleNeonChangeModeActive( obs_OBJECT_WORK );
            }
        }
    }

    // Token: 0x060012A4 RID: 4772 RVA: 0x000A2BC4 File Offset: 0x000A0DC4
    private static void gmBoss2BodyCatchChangeNeedleModeWait()
    {
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_3D_WORK == null )
            {
                AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
                if ( gms_ENEMY_COM_WORK.eve_rec.id == 337 )
                {
                    AppMain.GmGmkNeedleNeonChangeModeWait( obs_OBJECT_WORK );
                }
            }
            else if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id == 337 )
            {
                AppMain.GmGmkNeedleNeonChangeModeWait( obs_OBJECT_WORK );
            }
        }
    }

    // Token: 0x060012A5 RID: 4773 RVA: 0x000A2C30 File Offset: 0x000A0E30
    private static int gmBoss2BodyBallShootCheckTarget( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        if ( ( body_work.flag & 16U ) != 0U )
        {
            return 0;
        }
        if ( obs_OBJECT_WORK2.pos.y < obs_OBJECT_WORK.pos.y )
        {
            return 0;
        }
        int num = AppMain.MTM_MATH_ABS(obs_OBJECT_WORK2.pos.x - obs_OBJECT_WORK.pos.x);
        if ( num > 32768 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060012A6 RID: 4774 RVA: 0x000A2C9C File Offset: 0x000A0E9C
    private static int gmBoss2BodyPinBallCheckTurn( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK2.pos.x < obs_OBJECT_WORK.pos.x )
            {
                return 0;
            }
        }
        else if ( obs_OBJECT_WORK.pos.x < obs_OBJECT_WORK2.pos.x )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060012A7 RID: 4775 RVA: 0x000A2CF8 File Offset: 0x000A0EF8
    private static void gmBoss2BodyPinBallAdjustMoveSpeed( AppMain.GMS_BOSS2_BODY_WORK body_work, int speed )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        int num = AppMain.FX_Mul(obs_OBJECT_WORK.spd.x, obs_OBJECT_WORK.spd.x) + AppMain.FX_Mul(obs_OBJECT_WORK.spd.y, obs_OBJECT_WORK.spd.y);
        num = AppMain.FX_Sqrt( num );
        if ( num == 0 )
        {
            vecFx.x = 4096;
            vecFx.y = 0;
        }
        else
        {
            vecFx.x = AppMain.FX_Div( obs_OBJECT_WORK.spd.x, num );
            vecFx.y = AppMain.FX_Div( obs_OBJECT_WORK.spd.y, num );
        }
        vecFx.z = 0;
        int num2 = (speed - num) / 10;
        obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( vecFx.x, num + num2 );
        obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( vecFx.y, num + num2 );
        obs_OBJECT_WORK.spd.z = 0;
    }

    // Token: 0x060012A8 RID: 4776 RVA: 0x000A2DEC File Offset: 0x000A0FEC
    private static int gmBoss2BodyPinBallCheckAreaStop( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.g_gm_main_system.map_fcol.left + (AppMain.g_gm_main_system.map_fcol.right - AppMain.g_gm_main_system.map_fcol.left) / 2;
        int num2 = AppMain.g_gm_main_system.map_fcol.top + (AppMain.g_gm_main_system.map_fcol.bottom - AppMain.g_gm_main_system.map_fcol.top) / 2;
        if ( ( num - 70 ) * 4096 < obs_OBJECT_WORK.pos.x && obs_OBJECT_WORK.pos.x < ( num + 70 ) * 4096 && ( num2 - 110 ) * 4096 < obs_OBJECT_WORK.pos.y && obs_OBJECT_WORK.pos.y < ( num2 + 110 ) * 4096 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060012A9 RID: 4777 RVA: 0x000A2EC4 File Offset: 0x000A10C4
    private static void gmBoss2BodyDamage( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(body_work);
        if ( ( body_work.flag & 1U ) != 0U )
        {
            return;
        }
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = AppMain.gmBoss2MgrGetMgrWork(obj_work_parts);
        gms_BOSS2_MGR_WORK.life--;
        if ( gms_BOSS2_MGR_WORK.life > 0 )
        {
            body_work.flag |= 1073741824U;
        }
        else
        {
            body_work.flag |= 2147483648U;
        }
        AppMain.GmSoundPlaySE( "Boss0_01" );
        AppMain.gmBoss2EffDamageInit( body_work );
        AppMain.GMM_PAD_VIB_SMALL();
        AppMain.gmBoss2BodySetInvincibleTime( body_work, 90U );
    }

    // Token: 0x060012AA RID: 4778 RVA: 0x000A2F44 File Offset: 0x000A1144
    private static int gmBoss2BodyEscapeCheckScrollUnlock( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.g_gm_main_system.map_fcol.top * 4096 + 131072;
        if ( obs_OBJECT_WORK.pos.y <= num )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x060012AB RID: 4779 RVA: 0x000A2F88 File Offset: 0x000A1188
    private static int gmBoss2BodyEscapeCheckScreenOut( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.y <= ( AppMain.g_gm_main_system.map_fcol.top - 64 ) * 4096 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x060012AC RID: 4780 RVA: 0x000A2FC4 File Offset: 0x000A11C4
    private static void gmBoss2BodyEscapeAddjustSpeed( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) > -3276 )
        {
            obs_OBJECT_WORK.spd.x = 0;
            obs_OBJECT_WORK.spd.y = -3276;
            obs_OBJECT_WORK.spd_add.x = 0;
            obs_OBJECT_WORK.spd_add.y = 0;
        }
    }

    // Token: 0x060012AD RID: 4781 RVA: 0x000A3024 File Offset: 0x000A1224
    private static void gmBoss2BodyChangeState( AppMain.GMS_BOSS2_BODY_WORK body_work, int state )
    {
        AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK mpp_VOID_GMS_BOSS2_BODY_WORK = AppMain.gm_boss2_body_state_func_tbl_leave[body_work.state];
        if ( mpp_VOID_GMS_BOSS2_BODY_WORK != null )
        {
            mpp_VOID_GMS_BOSS2_BODY_WORK( body_work );
        }
        body_work.prev_state = body_work.state;
        body_work.state = state;
        AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK mpp_VOID_GMS_BOSS2_BODY_WORK2 = AppMain.gm_boss2_body_state_func_tbl_enter[body_work.state];
        if ( mpp_VOID_GMS_BOSS2_BODY_WORK2 != null )
        {
            mpp_VOID_GMS_BOSS2_BODY_WORK2( body_work );
        }
    }

    // Token: 0x060012AE RID: 4782 RVA: 0x000A3074 File Offset: 0x000A1274
    private static void gmBoss2BodyStateStartEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = body_work.ene_3d.ene_com.obj_work;
        obj_work.flag |= 2U;
        AppMain.gmBoss2BodySetActionAllParts( body_work, 0, 1 );
        AppMain.GmBsCmnSetObjSpdZero( obj_work );
        AppMain.gmBoss2BodySetDirectionNormal( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateStartUpdateWait );
        body_work.ene_3d.ene_com.enemy_flag |= 32768U;
    }

    // Token: 0x060012AF RID: 4783 RVA: 0x000A30E4 File Offset: 0x000A12E4
    private static void gmBoss2BodyStateStartLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag &= 4294967293U;
        body_work.flag &= 4294967279U;
        body_work.ene_3d.ene_com.enemy_flag &= 4294934527U;
    }

    // Token: 0x060012B0 RID: 4784 RVA: 0x000A3132 File Offset: 0x000A1332
    private static void gmBoss2BodyStateStartUpdateWait( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        if ( AppMain.gmBoss2CheckScrollLocked() == 0 )
        {
            return;
        }
        AppMain.GmMapSetMapDrawSize( 4 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateStartUpdateEnd );
    }

    // Token: 0x060012B1 RID: 4785 RVA: 0x000A3154 File Offset: 0x000A1354
    private static void gmBoss2BodyStateStartUpdateEnd( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.ObjViewOutCheck( obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0 ) != 0 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 180 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss2BodySearchShutterIn();
        if ( obs_OBJECT_WORK2 != null )
        {
            AppMain.GmGmkShutterInChangeModeClose( obs_OBJECT_WORK2 );
        }
        AppMain.gmBoss2BodyChangeState( body_work, 2 );
    }

    // Token: 0x060012B2 RID: 4786 RVA: 0x000A31C4 File Offset: 0x000A13C4
    private static void gmBoss2BodyStateCatchMoveEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 1 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchMoveUpdateMove );
        AppMain.gmBoss2EffAfterburnerRequestCreate( body_work );
        int x;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            x = AppMain.g_gm_main_system.map_fcol.left * 4096 + 348160;
        }
        else
        {
            x = AppMain.g_gm_main_system.map_fcol.right * 4096 - 348160;
        }
        AppMain.VecFx32 dest_pos = new AppMain.VecFx32(x, obs_OBJECT_WORK.pos.y, obs_OBJECT_WORK.pos.z);
        int speed = 4915;
        float frame = AppMain.gmBoss2BodyCalcMoveXNormalFrame(body_work, dest_pos.x, speed);
        AppMain.gmBoss2BodyInitMoveNormal( body_work, dest_pos, frame );
    }

    // Token: 0x060012B3 RID: 4787 RVA: 0x000A3278 File Offset: 0x000A1478
    private static void gmBoss2BodyStateCatchMoveLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060012B4 RID: 4788 RVA: 0x000A3280 File Offset: 0x000A1480
    private static void gmBoss2BodyStateCatchMoveUpdateMove( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetDirectionNormal( body_work );
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = AppMain.gmBoss2MgrGetMgrWork(obs_OBJECT_WORK);
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            if ( gms_BOSS2_MGR_WORK.life <= 3 )
            {
                AppMain.gmBoss2BodyChangeState( body_work, 5 );
                return;
            }
        }
        else if ( 8 - gms_BOSS2_MGR_WORK.life >= 3 )
        {
            AppMain.gmBoss2BodyChangeState( body_work, 5 );
            return;
        }
        if ( AppMain.gmBoss2BodyCatchArmCheckTarget( body_work ) != 0 )
        {
            AppMain.gmBoss2BodyChangeState( body_work, 3 );
            return;
        }
        float num = AppMain.gmBoss2BodyUpdateMoveNormal(body_work);
        if ( num > 60f )
        {
            return;
        }
        short dest_angle;
        int flag_positive;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967294U;
            dest_angle = AppMain.GMD_BOSS2_ANGLE_RIGHT;
            flag_positive = 1;
        }
        else
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
            dest_angle = AppMain.GMD_BOSS2_ANGLE_LEFT;
            flag_positive = 0;
        }
        AppMain.gmBoss2BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
        body_work.flag &= 4294967279U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchMoveUpdateTurn );
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060012B5 RID: 4789 RVA: 0x000A3360 File Offset: 0x000A1560
    private static void gmBoss2BodyStateCatchMoveUpdateTurn( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2BodyUpdateMoveNormal( body_work );
        float num = AppMain.gmBoss2BodyUpdateTurn(body_work);
        if ( 0f < num )
        {
            return;
        }
        AppMain.gmBoss2BodyChangeState( body_work, 2 );
    }

    // Token: 0x060012B6 RID: 4790 RVA: 0x000A338C File Offset: 0x000A158C
    private static void gmBoss2BodyStateCatchArmEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 2 );
        AppMain.GmBsCmnSetObjSpdZero( obj_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchArmUpdateOpen );
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060012B7 RID: 4791 RVA: 0x000A33C5 File Offset: 0x000A15C5
    private static void gmBoss2BodyStateCatchArmLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        body_work.offset_arm = 0f;
        AppMain.gmBoss2BodyCatchSetArmLength( body_work, body_work.offset_arm );
        body_work.count_release_key = 0;
        body_work.flag |= 16U;
    }

    // Token: 0x060012B8 RID: 4792 RVA: 0x000A33F4 File Offset: 0x000A15F4
    private static void gmBoss2BodyStateCatchArmUpdateOpen( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchArmUpdateReady );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 3 );
    }

    // Token: 0x060012B9 RID: 4793 RVA: 0x000A342C File Offset: 0x000A162C
    private static void gmBoss2BodyStateCatchArmUpdateReady( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 5 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchArmUpdateDown );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 5 );
        AppMain.gmBoss2BodyCatchChangeArmRectCatch( body_work );
        AppMain.GmSoundPlaySE( "Boss2_01", body_work.se_handle );
    }

    // Token: 0x060012BA RID: 4794 RVA: 0x000A3490 File Offset: 0x000A1690
    private static void gmBoss2BodyStateCatchArmUpdateDown( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        body_work.offset_arm -= 6f;
        AppMain.gmBoss2BodyCatchSetArmLength( body_work, body_work.offset_arm );
        AppMain.gmBoss2BodyRectApplyOffsetArm( body_work );
        if ( ( body_work.flag & 8U ) == 0U && body_work.offset_arm > -60f )
        {
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchArmUpdateClose );
        AppMain.GmSoundStopSE( body_work.se_handle );
        AppMain.GmSoundPlaySE( "Boss2_02" );
    }

    // Token: 0x060012BB RID: 4795 RVA: 0x000A3500 File Offset: 0x000A1700
    private static void gmBoss2BodyStateCatchArmUpdateClose( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            body_work.flag &= 4294967287U;
        }
        if ( ( body_work.flag & 8U ) != 0U )
        {
            AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obs_OBJECT_WORK, body_work.snm_work, body_work.snm_reg_id[2], 1 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + ( -AppMain.FX_F32_TO_FX32( body_work.offset_arm ) + 163840 );
        }
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchArmUpdateUp );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 6 );
        if ( ( body_work.flag & 8U ) == 0U )
        {
            AppMain.gmBoss2BodyCatchChangeArmRectNormal( body_work );
        }
    }

    // Token: 0x060012BC RID: 4796 RVA: 0x000A35B4 File Offset: 0x000A17B4
    private static void gmBoss2BodyStateCatchArmUpdateUp( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK2;
        body_work.offset_arm += 1f;
        AppMain.gmBoss2BodyCatchSetArmLength( body_work, body_work.offset_arm );
        AppMain.gmBoss2BodyRectApplyOffsetArm( body_work );
        AppMain.gmBoss2BodyCatchArmUpdateShakePlayer( body_work, 1U );
        obs_OBJECT_WORK.dir.x = ( ushort )AppMain.AKM_DEGtoA16( body_work.shake_pos );
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            body_work.flag &= 4294967287U;
        }
        if ( ( body_work.flag & 8U ) != 0U )
        {
            if ( AppMain.gmBoss2BodyCatchArmCountReleaseKey( body_work ) != 0 && body_work.shake_speed == 0 )
            {
                body_work.shake_speed = 2;
            }
            AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obs_OBJECT_WORK2, body_work.snm_work, body_work.snm_reg_id[2], 1 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK2;
            obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + ( -AppMain.FX_F32_TO_FX32( body_work.offset_arm ) + 163840 );
            if ( AppMain.gmBoss2BodyCatchArmCheckRelease( body_work ) != 0 )
            {
                body_work.flag &= 4294967287U;
                AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 16 );
                gms_PLAYER_WORK.player_flag |= 160U;
                obs_OBJECT_WORK2.move_flag &= 4294958847U;
                obs_OBJECT_WORK2.spd.x = 0;
                obs_OBJECT_WORK2.spd.y = 0;
                obs_OBJECT_WORK2.spd_add.x = 0;
                obs_OBJECT_WORK2.spd_add.y = 0;
            }
        }
        if ( body_work.offset_arm < 0f || obs_OBJECT_WORK.dir.x != 0 )
        {
            return;
        }
        body_work.offset_arm = 0f;
        AppMain.gmBoss2BodyCatchSetArmLength( body_work, body_work.offset_arm );
        AppMain.gmBoss2BodyRectApplyOffsetArm( body_work );
        if ( ( body_work.flag & 8U ) != 0U )
        {
            AppMain.gmBoss2BodyChangeState( body_work, 4 );
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchArmUpdateEnd );
    }

    // Token: 0x060012BD RID: 4797 RVA: 0x000A3764 File Offset: 0x000A1964
    private static void gmBoss2BodyStateCatchArmUpdateEnd( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( ( float )obs_OBJECT_WORK.user_timer < 10f )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        AppMain.gmBoss2BodyChangeState( body_work, 2 );
        AppMain.gmBoss2BodyCatchChangeArmRectNormal( body_work );
    }

    // Token: 0x060012BE RID: 4798 RVA: 0x000A37AC File Offset: 0x000A19AC
    private static void gmBoss2BodyStateCatchCarryEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 7 );
        int num = AppMain.g_gm_main_system.map_fcol.right - AppMain.g_gm_main_system.map_fcol.left;
        int num2 = (AppMain.g_gm_main_system.map_fcol.left + num / 2) * 4096;
        AppMain.VecFx32 dest_pos = new AppMain.VecFx32(num2, obs_OBJECT_WORK.pos.y, obs_OBJECT_WORK.pos.z);
        int speed = 4915;
        float frame = AppMain.gmBoss2BodyCalcMoveXNormalFrame(body_work, dest_pos.x, speed);
        AppMain.gmBoss2BodyInitMoveNormal( body_work, dest_pos, frame );
        AppMain.gmBoss2BodySetDirectionNormal( body_work );
        short dest_angle = 0;
        int flag_positive = 0;
        int num3 = 0;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U && num2 - obs_OBJECT_WORK.pos.x >= 0 )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967294U;
            dest_angle = AppMain.GMD_BOSS2_ANGLE_RIGHT;
            flag_positive = 1;
            num3 = 1;
        }
        else if ( ( obs_OBJECT_WORK.disp_flag & 1U ) == 0U && num2 - obs_OBJECT_WORK.pos.x < 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
            dest_angle = AppMain.GMD_BOSS2_ANGLE_LEFT;
            flag_positive = 0;
            num3 = 1;
        }
        if ( num3 != 0 )
        {
            AppMain.gmBoss2BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchCarryUpdateMove );
        AppMain.gmBoss2EffAfterburnerRequestCreate( body_work );
        AppMain.gmBoss2BodyCatchChangeNeedleModeActive();
    }

    // Token: 0x060012BF RID: 4799 RVA: 0x000A38EC File Offset: 0x000A1AEC
    private static void gmBoss2BodyStateCatchCarryLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
        body_work.flag &= 4294967287U;
        AppMain.gmBoss2BodyCatchChangeArmRectNormal( body_work );
        AppMain.gmBoss2BodyCatchChangeNeedleModeWait();
    }

    // Token: 0x060012C0 RID: 4800 RVA: 0x000A3910 File Offset: 0x000A1B10
    private static void gmBoss2BodyStateCatchCarryUpdateMove( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            body_work.flag &= 4294967287U;
        }
        if ( ( body_work.flag & 8U ) != 0U )
        {
            AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obs_OBJECT_WORK, body_work.snm_work, body_work.snm_reg_id[2], 1 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + ( -AppMain.FX_F32_TO_FX32( body_work.offset_arm ) + 163840 );
        }
        float num = AppMain.gmBoss2BodyUpdateTurn(body_work);
        float num2 = AppMain.gmBoss2BodyUpdateMoveNormal(body_work);
        if ( 0f < num2 || 0f < num )
        {
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchCarryUpdateOpen );
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 8 );
    }

    // Token: 0x060012C1 RID: 4801 RVA: 0x000A39C8 File Offset: 0x000A1BC8
    private static void gmBoss2BodyStateCatchCarryUpdateOpen( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK2;
        obs_OBJECT_WORK.user_timer++;
        if ( ( float )obs_OBJECT_WORK.user_timer < 40f )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            body_work.flag &= 4294967287U;
        }
        if ( ( body_work.flag & 8U ) != 0U )
        {
            body_work.flag &= 4294967287U;
            AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 16 );
            gms_PLAYER_WORK.player_flag |= 160U;
            obs_OBJECT_WORK2.move_flag &= 4294958847U;
            obs_OBJECT_WORK2.spd.x = 0;
            obs_OBJECT_WORK2.spd.y = 0;
            obs_OBJECT_WORK2.spd_add.x = 0;
            obs_OBJECT_WORK2.spd_add.y = 0;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateCatchCarryUpdateEnd );
    }

    // Token: 0x060012C2 RID: 4802 RVA: 0x000A3AB4 File Offset: 0x000A1CB4
    private static void gmBoss2BodyStateCatchCarryUpdateEnd( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss2BodyChangeState( body_work, 2 );
    }

    // Token: 0x060012C3 RID: 4803 RVA: 0x000A3AD8 File Offset: 0x000A1CD8
    private static void gmBoss2BodyStatePreBallEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2BodySetActionAllParts( body_work, 17, 1 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePreBallUpdateAngry );
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060012C4 RID: 4804 RVA: 0x000A3AFB File Offset: 0x000A1CFB
    private static void gmBoss2BodyStatePreBallLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
        body_work.flag &= 4294967279U;
    }

    // Token: 0x060012C5 RID: 4805 RVA: 0x000A3B14 File Offset: 0x000A1D14
    private static void gmBoss2BodyStatePreBallUpdateAngry( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) == 0 )
        {
            return;
        }
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePreBallUpdateRise );
        AppMain.VecFx32 dest_pos = new AppMain.VecFx32(obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y - 409600, obs_OBJECT_WORK.pos.z);
        AppMain.gmBoss2BodyInitMoveNormal( body_work, dest_pos, 60f );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePreBallUpdateRise );
        AppMain.GmCameraScaleSet( 0.82f, 0.003f );
    }

    // Token: 0x060012C6 RID: 4806 RVA: 0x000A3BA0 File Offset: 0x000A1DA0
    private static void gmBoss2BodyStatePreBallUpdateRise( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        float num = AppMain.gmBoss2BodyUpdateMoveNormal(body_work);
        if ( 0f < num )
        {
            return;
        }
        AppMain.gmBoss2BodyChangeState( body_work, 6 );
    }

    // Token: 0x060012C7 RID: 4807 RVA: 0x000A3BC4 File Offset: 0x000A1DC4
    private static void gmBoss2BodyStateBallMoveEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 9 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateBallMoveUpdateMove );
        AppMain.gmBoss2EffAfterburnerRequestCreate( body_work );
        int x;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            x = AppMain.g_gm_main_system.map_fcol.left * 4096 + 348160;
        }
        else
        {
            x = AppMain.g_gm_main_system.map_fcol.right * 4096 - 348160;
        }
        AppMain.VecFx32 dest_pos = new AppMain.VecFx32(x, obs_OBJECT_WORK.pos.y, obs_OBJECT_WORK.pos.z);
        int speed = 4915;
        float frame = AppMain.gmBoss2BodyCalcMoveXNormalFrame(body_work, dest_pos.x, speed);
        AppMain.gmBoss2BodyInitMoveNormal( body_work, dest_pos, frame );
    }

    // Token: 0x060012C8 RID: 4808 RVA: 0x000A3C79 File Offset: 0x000A1E79
    private static void gmBoss2BodyStateBallMoveLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060012C9 RID: 4809 RVA: 0x000A3C84 File Offset: 0x000A1E84
    private static void gmBoss2BodyStateBallMoveUpdateMove( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetDirectionNormal( body_work );
        AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = AppMain.gmBoss2MgrGetMgrWork(obs_OBJECT_WORK);
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.gmBoss2BodyChangeState( body_work, 8 );
            return;
        }
        if ( 8 - gms_BOSS2_MGR_WORK.life >= 5 )
        {
            if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) == 0 )
            {
                return;
            }
            AppMain.gmBoss2BodyChangeState( body_work, 8 );
            return;
        }
        else
        {
            if ( AppMain.gmBoss2BodyBallShootCheckTarget( body_work ) != 0 )
            {
                AppMain.gmBoss2BodyChangeState( body_work, 7 );
                return;
            }
            float num = AppMain.gmBoss2BodyUpdateMoveNormal(body_work);
            if ( num > 60f )
            {
                return;
            }
            short dest_angle;
            int flag_positive;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                dest_angle = AppMain.GMD_BOSS2_ANGLE_RIGHT;
                flag_positive = 1;
            }
            else
            {
                obs_OBJECT_WORK.disp_flag |= 1U;
                dest_angle = AppMain.GMD_BOSS2_ANGLE_LEFT;
                flag_positive = 0;
            }
            AppMain.gmBoss2BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
            body_work.flag &= 4294967279U;
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateBallMoveUpdateTurn );
            AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
            return;
        }
    }

    // Token: 0x060012CA RID: 4810 RVA: 0x000A3D64 File Offset: 0x000A1F64
    private static void gmBoss2BodyStateBallMoveUpdateTurn( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2BodyUpdateMoveNormal( body_work );
        float num = AppMain.gmBoss2BodyUpdateTurn(body_work);
        if ( 0f < num )
        {
            return;
        }
        AppMain.gmBoss2BodyChangeState( body_work, 6 );
    }

    // Token: 0x060012CB RID: 4811 RVA: 0x000A3D90 File Offset: 0x000A1F90
    private static void gmBoss2BodyStateBallShootEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 10 );
        AppMain.GmBsCmnSetObjSpdZero( obj_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateBallShootUpdateWaitCreate );
        AppMain.gmBoss2EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060012CC RID: 4812 RVA: 0x000A3DCA File Offset: 0x000A1FCA
    private static void gmBoss2BodyStateBallShootLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        body_work.flag |= 16U;
    }

    // Token: 0x060012CD RID: 4813 RVA: 0x000A3DDC File Offset: 0x000A1FDC
    private static void gmBoss2BodyStateBallShootUpdateWaitCreate( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(318, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(obs_OBJECT_WORK);
        AppMain.gmBoss2MgrAddObject( mgr_work, obs_OBJECT_WORK2 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK2.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2ExitFunc ) );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateBallShootUpdateCatch );
    }

    // Token: 0x060012CE RID: 4814 RVA: 0x000A3E58 File Offset: 0x000A2058
    private static void gmBoss2BodyStateBallShootUpdateCatch( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        body_work.flag |= 4194304U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateBallShootUpdateShoot );
    }

    // Token: 0x060012CF RID: 4815 RVA: 0x000A3E9C File Offset: 0x000A209C
    private static void gmBoss2BodyStateBallShootUpdateShoot( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss2BodyChangeState( body_work, 6 );
    }

    // Token: 0x060012D0 RID: 4816 RVA: 0x000A3EC0 File Offset: 0x000A20C0
    private static void gmBoss2BodyStatePrePinBallEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 12, 1 );
        body_work.ene_3d.ene_com.rect_work[2].flag |= 4U;
        AppMain.GmBsCmnSetObjSpdZero( obj_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePrePinBallUpdateWaitEffect );
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) == 0 )
        {
            AppMain.GmSoundChangeAngryBossBGM();
        }
    }

    // Token: 0x060012D1 RID: 4817 RVA: 0x000A3F21 File Offset: 0x000A2121
    private static void gmBoss2BodyStatePrePinBallLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        body_work.flag &= 4294967279U;
    }

    // Token: 0x060012D2 RID: 4818 RVA: 0x000A3F34 File Offset: 0x000A2134
    private static void gmBoss2BodyStatePrePinBallUpdateWaitEffect( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( ( float )obs_OBJECT_WORK.user_timer < 119f )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        AppMain.gmBoss2EffBlitzInit( body_work );
        AppMain.GmSoundPlaySE( "FinalBoss11", body_work.se_handle );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePrePinBallUpdateWaitMotion );
    }

    // Token: 0x060012D3 RID: 4819 RVA: 0x000A3F94 File Offset: 0x000A2194
    private static void gmBoss2BodyStatePrePinBallUpdateWaitMotion( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss2BodyChangeState( body_work, 9 );
    }

    // Token: 0x060012D4 RID: 4820 RVA: 0x000A3FBC File Offset: 0x000A21BC
    private static void gmBoss2BodyStatePinBallMoveEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2BodySetActionAllParts( body_work, 15 );
        obs_OBJECT_WORK.move_flag &= 4294963199U;
        AppMain.gmBoss2BodySetRectActive( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePinBallMoveUpdateMove );
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.gmBoss2BodyCatchChangeNeedleModeActive();
        }
    }

    // Token: 0x060012D5 RID: 4821 RVA: 0x000A4010 File Offset: 0x000A2210
    private static void gmBoss2BodyStatePinBallMoveLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.move_flag |= 4096U;
    }

    // Token: 0x060012D6 RID: 4822 RVA: 0x000A4038 File Offset: 0x000A2238
    private static void gmBoss2BodyStatePinBallMoveUpdateMove( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        int num = 0;
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            num = AppMain.FX_Mul( num, 6144 );
        }
        AppMain.gmBoss2BodyPinBallAdjustMoveSpeed( body_work, num );
        AppMain.gmBoss2BodyUpdateMovePinBall( body_work );
        AppMain.gmBoss2BodySetDirectionNormal( body_work );
        body_work.counter_pinball += 1U;
        if ( body_work.counter_pinball == 90U && AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            AppMain.gmBoss2BodyCatchChangeNeedleModeWait();
        }
        if ( body_work.counter_pinball < 360U )
        {
            return;
        }
        body_work.counter_pinball = 0U;
        AppMain.gmBoss2BodyChangeState( body_work, 10 );
    }

    // Token: 0x060012D7 RID: 4823 RVA: 0x000A40B8 File Offset: 0x000A22B8
    private static void gmBoss2BodyStatePinBallRollEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.move_flag &= 4294963199U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 15 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePinBallRollUpdateSearch );
    }

    // Token: 0x060012D8 RID: 4824 RVA: 0x000A4100 File Offset: 0x000A2300
    private static void gmBoss2BodyStatePinBallRollLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.move_flag |= 4096U;
        body_work.flag &= 4294967231U;
    }

    // Token: 0x060012D9 RID: 4825 RVA: 0x000A4138 File Offset: 0x000A2338
    private static void gmBoss2BodyStatePinBallRollUpdateSearch( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss2BodySetActionAllParts( body_work, 16 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePinBallRollUpdateFind );
    }

    // Token: 0x060012DA RID: 4826 RVA: 0x000A4170 File Offset: 0x000A2370
    private static void gmBoss2BodyStatePinBallRollUpdateFind( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) == 0 )
        {
            return;
        }
        if ( AppMain.gmBoss2BodyPinBallCheckTurn( body_work ) != 0 )
        {
            short dest_angle;
            int flag_positive;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                dest_angle = AppMain.GMD_BOSS2_ANGLE_RIGHT;
                flag_positive = 1;
            }
            else
            {
                obs_OBJECT_WORK.disp_flag |= 1U;
                dest_angle = AppMain.GMD_BOSS2_ANGLE_LEFT;
                flag_positive = 0;
            }
            AppMain.gmBoss2BodyInitTurn( body_work, dest_angle, 20f, flag_positive );
        }
        AppMain.gmBoss2BodySetActionAllParts( body_work, 14 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePinBallRollReady );
    }

    // Token: 0x060012DB RID: 4827 RVA: 0x000A41F8 File Offset: 0x000A23F8
    private static void gmBoss2BodyStatePinBallRollReady( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num = AppMain.gmBoss2BodyUpdateTurn(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 10 )
        {
            return;
        }
        if ( 0f < num )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        int num2 = 20480;
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            num2 = AppMain.FX_Mul( num2, 6144 );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmBsCmnGetPlayerObj();
        AppMain.gmBoss2BodyInitMovePinBall( body_work, obs_OBJECT_WORK2.pos, num2 );
        AppMain.gmBoss2BodySetRectRoll( body_work );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 14 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePinBallRollUpdateMove );
        AppMain.gmBoss2EffCreateRollModel( body_work );
    }

    // Token: 0x060012DC RID: 4828 RVA: 0x000A4290 File Offset: 0x000A2490
    private static void gmBoss2BodyStatePinBallRollUpdateMove( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = 20480;
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            num = AppMain.FX_Mul( num, 6144 );
        }
        AppMain.gmBoss2BodyPinBallAdjustMoveSpeed( body_work, num );
        AppMain.gmBoss2BodyUpdateMovePinBall( body_work );
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.dir.z = ( ushort )( obs_OBJECT_WORK2.dir.z - ( ushort )AppMain.GMD_BOSS2_BODY_PINBALL_ROLL_ROT_Z );
        }
        else
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.dir.z = ( ushort )( obs_OBJECT_WORK3.dir.z + ( ushort )AppMain.GMD_BOSS2_BODY_PINBALL_ROLL_ROT_Z );
        }
        AppMain.gmBoss2BodySetDirectionRoll( body_work );
        body_work.flag |= 64U;
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 180 )
        {
            return;
        }
        if ( AppMain.gmBoss2BodyPinBallCheckAreaStop( body_work ) == 0 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStatePinBallRollUpdateStop );
        body_work.flag &= 4294967263U;
        AppMain.gmBoss2EffCreateRollModelLost( body_work );
    }

    // Token: 0x060012DD RID: 4829 RVA: 0x000A4374 File Offset: 0x000A2574
    private static void gmBoss2BodyStatePinBallRollUpdateStop( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = 20480;
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            num = AppMain.FX_Mul( num, 6144 );
        }
        AppMain.gmBoss2BodyPinBallAdjustMoveSpeed( body_work, num );
        AppMain.gmBoss2BodyUpdateMovePinBall( body_work );
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.dir.z = ( ushort )( obs_OBJECT_WORK2.dir.z - ( ushort )AppMain.GMD_BOSS2_BODY_PINBALL_ROLL_ROT_Z );
        }
        else
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.dir.z = ( ushort )( obs_OBJECT_WORK3.dir.z + ( ushort )AppMain.GMD_BOSS2_BODY_PINBALL_ROLL_ROT_Z );
        }
        AppMain.gmBoss2BodySetDirectionRoll( body_work );
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 10 )
        {
            return;
        }
        if ( AppMain.gmBoss2BodyPinBallCheckAreaStop( body_work ) == 0 )
        {
            return;
        }
        obs_OBJECT_WORK.dir.z = 0;
        obs_OBJECT_WORK.user_timer = 0;
        obs_OBJECT_WORK.dir.z = 0;
        AppMain.gmBoss2BodyChangeState( body_work, 9 );
    }

    // Token: 0x060012DE RID: 4830 RVA: 0x000A443C File Offset: 0x000A263C
    private static void gmBoss2BodyStateDefeatEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.disp_flag |= 16U;
        body_work.ene_3d.ene_com.enemy_flag |= 32768U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateDefeatUpdateStart );
        body_work.flag &= 4294967291U;
        AppMain.GmSoundStopSE( body_work.se_handle );
        body_work.flag &= 4294967263U;
        AppMain.gmBoss2BodyCatchChangeNeedleModeWait();
        AppMain.GmSoundChangeWinBossBGM();
    }

    // Token: 0x060012DF RID: 4831 RVA: 0x000A44D4 File Offset: 0x000A26D4
    private static void gmBoss2BodyStateDefeatLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.disp_flag &= 4294967279U;
        obs_OBJECT_WORK.flag &= 4294967293U;
    }

    // Token: 0x060012E0 RID: 4832 RVA: 0x000A4508 File Offset: 0x000A2708
    private static void gmBoss2BodyStateDefeatUpdateStart( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 40 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss2EffBombsInit( body_work.bomb_work, obs_OBJECT_WORK2, obs_OBJECT_WORK2.pos.x, obs_OBJECT_WORK2.pos.y, 327680, 327680, 10U, 30U );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateDefeatUpdateFall );
    }

    // Token: 0x060012E1 RID: 4833 RVA: 0x000A4588 File Offset: 0x000A2788
    private static void gmBoss2BodyStateDefeatUpdateFall( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 120 )
        {
            AppMain.gmBoss2EffBombsUpdate( body_work.bomb_work );
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        obs_OBJECT_WORK.move_flag |= 128U;
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateDefeatUpdateExplode );
    }

    // Token: 0x060012E2 RID: 4834 RVA: 0x000A45EC File Offset: 0x000A27EC
    private static void gmBoss2BodyStateDefeatUpdateExplode( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.g_gm_main_system.map_fcol.bottom * 4096 - 614400;
        if ( obs_OBJECT_WORK.pos.y < num )
        {
            return;
        }
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.flag |= 134217728U;
        AppMain.GmSoundPlaySE( "Boss0_03" );
        AppMain.GMM_PAD_VIB_MID_TIME( 120f );
        AppMain.GmBsCmnInitFlashScreen( body_work.flash_work, 4f, 5f, 30f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(obs_OBJECT_WORK2, 8);
        obs_OBJECT_WORK3.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
        AppMain.GmPlayerAddScoreNoDisp( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 1000 );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateDefeatUpdateScatter );
    }

    // Token: 0x060012E3 RID: 4835 RVA: 0x000A46DC File Offset: 0x000A28DC
    private static void gmBoss2BodyStateDefeatUpdateScatter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnUpdateFlashScreen( body_work.flash_work );
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 40 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        AppMain.gmBoss2ChangeTextureBurnt( obs_OBJECT_WORK );
        body_work.flag |= 16777216U;
        AppMain.gmBoss2EffAfterburnerSmokeInit( body_work );
        AppMain.gmBoss2EffBodySmokeInit( body_work );
        body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateDefeatUpdateEnd );
        AppMain.gmBoss2EffScatterInit( body_work );
        AppMain.GmCameraScaleSet( 1f, 0.0015f );
        AppMain.GmMapSetDrawMarginNormal();
    }

    // Token: 0x060012E4 RID: 4836 RVA: 0x000A476C File Offset: 0x000A296C
    private static void gmBoss2BodyStateDefeatUpdateEnd( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 120 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        AppMain.gmBoss2BodyChangeState( body_work, 12 );
    }

    // Token: 0x060012E5 RID: 4837 RVA: 0x000A47A8 File Offset: 0x000A29A8
    private static void gmBoss2BodyStateEscapeEnter( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.spd.x = 0;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            obs_OBJECT_WORK.spd_add.x = 0;
        }
        else
        {
            obs_OBJECT_WORK.spd_add.x = 0;
        }
        obs_OBJECT_WORK.spd_add.y = -655;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.move_flag |= 4352U;
        AppMain.gmBoss2BodySetDirectionNormal( body_work );
        AppMain.gmBoss2BodySetActionAllParts( body_work, 18, 1 );
        body_work.flag |= 8388608U;
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateEscapeUpdateFinalZone );
        }
        else
        {
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateEscapeUpdateScrollLock );
        }
        AppMain.GmMapSetMapDrawSize( 1 );
    }

    // Token: 0x060012E6 RID: 4838 RVA: 0x000A4874 File Offset: 0x000A2A74
    private static void gmBoss2BodyStateEscapeLeave( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag &= 4294967293U;
    }

    // Token: 0x060012E7 RID: 4839 RVA: 0x000A4898 File Offset: 0x000A2A98
    private static void gmBoss2BodyStateEscapeUpdateScrollLock( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2BodyEscapeAddjustSpeed( body_work );
        if ( AppMain.gmBoss2BodyEscapeCheckScrollUnlock( body_work ) != 0 )
        {
            AppMain.GmGmkCamScrLimitRelease( 4 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss2BodySearchShutterOut();
            if ( obs_OBJECT_WORK != null )
            {
                AppMain.GmGmkShutterOutChangeModeOpen( obs_OBJECT_WORK );
            }
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateEscapeUpdateWaitScreenOut );
            AppMain.GmEfctBossCmnEsCreate( AppMain.GMM_BS_OBJ( body_work ), 1U );
        }
    }

    // Token: 0x060012E8 RID: 4840 RVA: 0x000A48E8 File Offset: 0x000A2AE8
    private static void gmBoss2BodyStateEscapeUpdateWaitScreenOut( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2BodyEscapeAddjustSpeed( body_work );
        if ( AppMain.gmBoss2BodyEscapeCheckScreenOut( body_work ) != 0 )
        {
            AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(body_work);
            AppMain.GMS_BOSS2_MGR_WORK gms_BOSS2_MGR_WORK = AppMain.gmBoss2MgrGetMgrWork(obj_work_parts);
            gms_BOSS2_MGR_WORK.flag |= 2U;
            body_work.proc_update = null;
        }
    }

    // Token: 0x060012E9 RID: 4841 RVA: 0x000A4926 File Offset: 0x000A2B26
    private static void gmBoss2BodyStateEscapeUpdateFinalZone( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.gmBoss2BodyEscapeAddjustSpeed( body_work );
        if ( AppMain.gmBoss2BodyEscapeCheckScrollUnlock( body_work ) != 0 )
        {
            AppMain.GmEfctBossCmnEsCreate( AppMain.GMM_BS_OBJ( body_work ), 1U );
            body_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.gmBoss2BodyStateEscapeUpdateWaitScreenOut );
        }
    }

    // Token: 0x060012EA RID: 4842 RVA: 0x000A4958 File Offset: 0x000A2B58
    private static void gmBoss2BodyMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work;
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(obj_work);
        if ( AppMain.gmBoss2MgrCheckSetupComplete( mgr_work ) == 0 )
        {
            return;
        }
        AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, gms_BOSS2_BODY_WORK.bmcb_mgr );
        AppMain.GmBsCmnCreateSNMWork( gms_BOSS2_BODY_WORK.snm_work, obj_work.obj_3d._object, 15 );
        AppMain.GmBsCmnAppendBossMotionCallback( gms_BOSS2_BODY_WORK.bmcb_mgr, gms_BOSS2_BODY_WORK.snm_work.bmcb_link );
        int num = 0;
        while ( 15 > num )
        {
            gms_BOSS2_BODY_WORK.snm_reg_id[num] = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS2_BODY_WORK.snm_work, AppMain.g_boss2_node_index_list[num] );
            num++;
        }
        AppMain.GmBsCmnCreateCNMMgrWork( gms_BOSS2_BODY_WORK.cnm_mgr_work, obj_work.obj_3d._object, 13 );
        AppMain.GmBsCmnInitCNMCb( obj_work, gms_BOSS2_BODY_WORK.cnm_mgr_work );
        int num2 = 0;
        while ( 13 > num2 )
        {
            gms_BOSS2_BODY_WORK.cnm_reg_id[num2] = AppMain.GmBsCmnRegisterCNMNode( gms_BOSS2_BODY_WORK.cnm_mgr_work, AppMain.g_boss2_node_index_list[2 + num2] );
            num2++;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2BodyMainFunc );
        AppMain.gmBoss2BodyChangeState( gms_BOSS2_BODY_WORK, 1 );
    }

    // Token: 0x060012EB RID: 4843 RVA: 0x000A4A44 File Offset: 0x000A2C44
    private static void gmBoss2BodyMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work;
        AppMain.gmBoss2BodyUpdateNoHitTime( gms_BOSS2_BODY_WORK );
        AppMain.gmBoss2BodyUpdateInvincibleTime( gms_BOSS2_BODY_WORK );
        if ( gms_BOSS2_BODY_WORK.proc_update != null )
        {
            gms_BOSS2_BODY_WORK.proc_update( gms_BOSS2_BODY_WORK );
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 33554432U ) != 0U )
        {
            AppMain.gmBoss2EffAfterburnerInit( gms_BOSS2_BODY_WORK );
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 2147483648U ) != 0U )
        {
            gms_BOSS2_BODY_WORK.flag &= 1073741823U;
            AppMain.gmBoss2BodyChangeState( gms_BOSS2_BODY_WORK, 11 );
            return;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 1073741824U ) != 0U )
        {
            gms_BOSS2_BODY_WORK.flag &= 3221225471U;
            gms_BOSS2_BODY_WORK.flag |= 536870912U;
            AppMain.GmBsCmnInitObject3DNNDamageFlicker( obj_work, gms_BOSS2_BODY_WORK.flk_work, 32f );
        }
        AppMain.GmBsCmnUpdateObject3DNNDamageFlicker( obj_work, gms_BOSS2_BODY_WORK.flk_work );
        AppMain.gmBoss2BodyUpdateDirection( gms_BOSS2_BODY_WORK );
    }

    // Token: 0x060012EC RID: 4844 RVA: 0x000A4B0B File Offset: 0x000A2D0B
    private static void gmBoss2EggChangeAction( AppMain.GMS_BOSS2_EGG_WORK egg_work, int action_id )
    {
        AppMain.gmBoss2EggChangeAction( egg_work, action_id, 0 );
    }

    // Token: 0x060012ED RID: 4845 RVA: 0x000A4B18 File Offset: 0x000A2D18
    private static void gmBoss2EggChangeAction( AppMain.GMS_BOSS2_EGG_WORK egg_work, int action_id, int force_change )
    {
        AppMain.GMS_BOSS2_PART_ACT_INFO gms_BOSS2_PART_ACT_INFO = AppMain.gm_boss2_egg_act_info_tbl[action_id];
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        if ( force_change == 0 && egg_work.egg_action_id == action_id && ( egg_work.flag & 1U ) != 0U )
        {
            return;
        }
        egg_work.egg_action_id = action_id;
        egg_work.flag |= 1U;
        if ( gms_BOSS2_PART_ACT_INFO.is_maintain != 0 )
        {
            if ( gms_BOSS2_PART_ACT_INFO.is_repeat != 0 )
            {
                obs_OBJECT_WORK.disp_flag |= 4U;
            }
        }
        else
        {
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS2_PART_ACT_INFO.mtn_id, ( int )gms_BOSS2_PART_ACT_INFO.is_repeat, gms_BOSS2_PART_ACT_INFO.is_blend );
        }
        obs_OBJECT_WORK.obj_3d.speed[0] = gms_BOSS2_PART_ACT_INFO.mtn_spd;
        obs_OBJECT_WORK.obj_3d.blend_spd = gms_BOSS2_PART_ACT_INFO.blend_spd;
    }

    // Token: 0x060012EE RID: 4846 RVA: 0x000A4BBC File Offset: 0x000A2DBC
    private static void gmBoss2EggRevertAction( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(gms_BOSS2_BODY_WORK);
        egg_work.flag &= 4294967294U;
        AppMain.GMS_BOSS2_PART_ACT_INFO gms_BOSS2_PART_ACT_INFO = AppMain.gm_boss2_act_info_tbl[gms_BOSS2_BODY_WORK.action_id][1];
        AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS2_PART_ACT_INFO.mtn_id, ( int )gms_BOSS2_PART_ACT_INFO.is_repeat, 1 );
        obs_OBJECT_WORK.obj_3d.frame[0] = obs_OBJECT_WORK2.obj_3d.frame[0];
    }

    // Token: 0x060012EF RID: 4847 RVA: 0x000A4C2E File Offset: 0x000A2E2E
    private static void gmBoss2EggStateIdleInit( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_EGG_WORK( AppMain.gmBoss2EggStateIdleUpdate );
    }

    // Token: 0x060012F0 RID: 4848 RVA: 0x000A4C44 File Offset: 0x000A2E44
    private static void gmBoss2EggStateIdleUpdate( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS2_BODY_WORK.flag & 268435456U ) != 0U )
        {
            gms_BOSS2_BODY_WORK.flag &= 4026531839U;
            AppMain.gmBoss2EggStateLaughInit( egg_work );
        }
    }

    // Token: 0x060012F1 RID: 4849 RVA: 0x000A4C8C File Offset: 0x000A2E8C
    private static void gmBoss2EggStateLaughInit( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.OBS_OBJECT_WORK parent_obj = obs_OBJECT_WORK.parent_obj;
        if ( ( parent_obj.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss2EggChangeAction( egg_work, 0 );
        }
        else
        {
            AppMain.gmBoss2EggChangeAction( egg_work, 1 );
        }
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_EGG_WORK( AppMain.gmBoss2EggStateLaughUpdate );
    }

    // Token: 0x060012F2 RID: 4850 RVA: 0x000A4CD4 File Offset: 0x000A2ED4
    private static void gmBoss2EggStateLaughUpdate( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss2EggRevertAction( egg_work );
        AppMain.gmBoss2EggStateIdleInit( egg_work );
    }

    // Token: 0x060012F3 RID: 4851 RVA: 0x000A4CFD File Offset: 0x000A2EFD
    private static void gmBoss2EggStateDamageInit( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.gmBoss2EggChangeAction( egg_work, 2 );
        AppMain.gmBoss2EffSweatInit( egg_work );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_EGG_WORK( AppMain.gmBoss2EggStateDamageUpdate );
    }

    // Token: 0x060012F4 RID: 4852 RVA: 0x000A4D20 File Offset: 0x000A2F20
    private static void gmBoss2EggStateDamageUpdate( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        egg_work.flag &= 4294967293U;
        AppMain.gmBoss2EggRevertAction( egg_work );
        AppMain.gmBoss2EggStateIdleInit( egg_work );
    }

    // Token: 0x060012F5 RID: 4853 RVA: 0x000A4D58 File Offset: 0x000A2F58
    private static void gmBoss2EggStateEscapeInit( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        if ( ( egg_work.flag & 2U ) == 0U )
        {
            AppMain.gmBoss2EffSweatInit( egg_work );
        }
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_EGG_WORK( AppMain.gmBoss2EggStateEscapeUpdate );
    }

    // Token: 0x060012F6 RID: 4854 RVA: 0x000A4D7C File Offset: 0x000A2F7C
    private static void gmBoss2EggStateEscapeUpdate( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.UNREFERENCED_PARAMETER( egg_work );
    }

    // Token: 0x060012F7 RID: 4855 RVA: 0x000A4D84 File Offset: 0x000A2F84
    private static void gmBoss2EggmanMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_BOSS2_BODY_WORK.ene_3d.ene_com.obj_work;
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(obj_work2);
        if ( AppMain.gmBoss2MgrCheckSetupComplete( mgr_work ) == 0 )
        {
            return;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EggmanMainFunc );
        AppMain.GMS_BOSS2_EGG_WORK egg_work = (AppMain.GMS_BOSS2_EGG_WORK)obj_work;
        AppMain.gmBoss2EggStateIdleInit( egg_work );
    }

    // Token: 0x060012F8 RID: 4856 RVA: 0x000A4DE0 File Offset: 0x000A2FE0
    private static void gmBoss2EggmanMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS2_EGG_WORK gms_BOSS2_EGG_WORK = (AppMain.GMS_BOSS2_EGG_WORK)obj_work;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[0], 1 );
        if ( gms_BOSS2_EGG_WORK.proc_update != null )
        {
            gms_BOSS2_EGG_WORK.proc_update( gms_BOSS2_EGG_WORK );
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 8388608U ) != 0U )
        {
            gms_BOSS2_BODY_WORK.flag &= 4286578687U;
            AppMain.gmBoss2EggStateEscapeInit( gms_BOSS2_EGG_WORK );
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 536870912U ) != 0U )
        {
            gms_BOSS2_BODY_WORK.flag &= 3758096383U;
            AppMain.gmBoss2EggStateDamageInit( gms_BOSS2_EGG_WORK );
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 16777216U ) != 0U )
        {
            gms_BOSS2_BODY_WORK.flag &= 4278190079U;
            AppMain.gmBoss2ChangeTextureBurnt( obj_work );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS2_BODY_WORK);
        if ( ( obs_OBJECT_WORK.disp_flag & 16U ) != 0U )
        {
            obj_work.disp_flag |= 16U;
        }
        else
        {
            obj_work.disp_flag &= 4294967279U;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 64U ) != 0U )
        {
            obj_work.disp_flag |= 32U;
            return;
        }
        obj_work.disp_flag &= 4294967263U;
    }

    // Token: 0x060012F9 RID: 4857 RVA: 0x000A4EF8 File Offset: 0x000A30F8
    private static void gmBoss2BallHitFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = parent_obj.parent_obj;
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)parent_obj2;
        gms_BOSS2_BODY_WORK.flag |= 268435456U;
    }

    // Token: 0x060012FA RID: 4858 RVA: 0x000A4F2C File Offset: 0x000A312C
    private static void gmBoss2BallMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK obj = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(obj);
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(obj_work_parts);
        if ( AppMain.gmBoss2MgrCheckSetupComplete( mgr_work ) == 0 )
        {
            return;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2BallMainFunc );
        AppMain.GMS_BOSS2_BALL_WORK ball_work = (AppMain.GMS_BOSS2_BALL_WORK)obj_work;
        AppMain.gmBoss2BallInit( ball_work );
    }

    // Token: 0x060012FB RID: 4859 RVA: 0x000A4F7C File Offset: 0x000A317C
    private static void gmBoss2BallMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BALL_WORK gms_BOSS2_BALL_WORK = (AppMain.GMS_BOSS2_BALL_WORK)obj_work;
        if ( gms_BOSS2_BALL_WORK.proc_update != null )
        {
            gms_BOSS2_BALL_WORK.proc_update( gms_BOSS2_BALL_WORK );
        }
    }

    // Token: 0x060012FC RID: 4860 RVA: 0x000A4FA4 File Offset: 0x000A31A4
    private static void gmBoss2BallInit( AppMain.GMS_BOSS2_BALL_WORK ball_work )
    {
        ball_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BALL_WORK( AppMain.gmBoss2BallUpdateCatch );
    }

    // Token: 0x060012FD RID: 4861 RVA: 0x000A4FB8 File Offset: 0x000A31B8
    private static void gmBoss2BallUpdateCatch( AppMain.GMS_BOSS2_BALL_WORK ball_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ball_work);
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obs_OBJECT_WORK, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[1], 1 );
        ball_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BALL_WORK( AppMain.gmBoss2BallUpdateWaitShoot );
    }

    // Token: 0x060012FE RID: 4862 RVA: 0x000A5000 File Offset: 0x000A3200
    private static void gmBoss2BallUpdateWaitShoot( AppMain.GMS_BOSS2_BALL_WORK ball_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ball_work);
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obs_OBJECT_WORK, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[1], 1 );
        if ( ( gms_BOSS2_BODY_WORK.flag & 4194304U ) == 0U )
        {
            return;
        }
        gms_BOSS2_BODY_WORK.flag &= 4290772991U;
        ball_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BALL_WORK( AppMain.gmBoss2BallUpdateShoot );
        obs_OBJECT_WORK.move_flag |= 128U;
    }

    // Token: 0x060012FF RID: 4863 RVA: 0x000A507C File Offset: 0x000A327C
    private static void gmBoss2BallUpdateShoot( AppMain.GMS_BOSS2_BALL_WORK ball_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ball_work);
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) == 0U )
        {
            return;
        }
        ball_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BALL_WORK( AppMain.gmBoss2BallUpdateWaitBomb );
    }

    // Token: 0x06001300 RID: 4864 RVA: 0x000A50B0 File Offset: 0x000A32B0
    private static void gmBoss2BallUpdateWaitBomb( AppMain.GMS_BOSS2_BALL_WORK ball_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ball_work);
        obs_OBJECT_WORK.user_timer++;
        if ( obs_OBJECT_WORK.user_timer < 120 )
        {
            return;
        }
        obs_OBJECT_WORK.user_timer = 0;
        ball_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS2_BALL_WORK( AppMain.gmBoss2BallUpdateFlicker );
        AppMain.GmBsCmnInitObject3DNNDamageFlicker( obs_OBJECT_WORK, ball_work.flk_work, 16f );
        AppMain.gmBoss2EffBallBombInit( obs_OBJECT_WORK.pos, obs_OBJECT_WORK );
    }

    // Token: 0x06001301 RID: 4865 RVA: 0x000A5114 File Offset: 0x000A3314
    private static void gmBoss2BallUpdateFlicker( AppMain.GMS_BOSS2_BALL_WORK ball_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ball_work);
        AppMain.OBS_OBJECT_WORK parent_obj = obs_OBJECT_WORK.parent_obj;
        if ( AppMain.GmBsCmnUpdateObject3DNNDamageFlicker( obs_OBJECT_WORK, ball_work.flk_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss2EffBallBombPartInit( obs_OBJECT_WORK.pos, parent_obj, 4096 );
        AppMain.gmBoss2EffBallBombPartInit( obs_OBJECT_WORK.pos, parent_obj, -4096 );
        AppMain.GMS_EFFECT_3DES_WORK work = AppMain.GmEfctCmnEsCreate(null, 10);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = (AppMain.OBS_OBJECT_WORK)work;
        obs_OBJECT_WORK2.pos.Assign( obs_OBJECT_WORK.pos );
        obs_OBJECT_WORK.flag |= 4U;
        AppMain.GmSoundPlaySE( "Boss2_03" );
    }

    // Token: 0x06001302 RID: 4866 RVA: 0x000A51A0 File Offset: 0x000A33A0
    private static void gmBoss2EffDamageInit( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK obj = AppMain.GmEfctBossCmnEsCreate(parent_obj, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(obj);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
    }

    // Token: 0x06001303 RID: 4867 RVA: 0x000A51DC File Offset: 0x000A33DC
    private static void gmBoss2EffBombsInit( AppMain.GMS_BOSS2_EFF_BOMB_WORK bomb_work, AppMain.OBS_OBJECT_WORK parent_obj, int pos_x, int pos_y, int width, int height, uint interval_min, uint interval_max )
    {
        bomb_work.parent_obj = parent_obj;
        bomb_work.interval_timer = 0U;
        bomb_work.interval_min = interval_min;
        bomb_work.interval_max = interval_max;
        bomb_work.pos[0] = pos_x;
        bomb_work.pos[1] = pos_y;
        bomb_work.area[0] = width;
        bomb_work.area[1] = height;
    }

    // Token: 0x06001304 RID: 4868 RVA: 0x000A5230 File Offset: 0x000A3430
    private static void gmBoss2EffBombsUpdate( AppMain.GMS_BOSS2_EFF_BOMB_WORK bomb_work )
    {
        if ( bomb_work.interval_timer > 0U )
        {
            bomb_work.interval_timer -= 1U;
            return;
        }
        AppMain.GmSoundPlaySE( "Boss0_02" );
        AppMain.GMS_EFFECT_3DES_WORK obj = AppMain.GmEfctCmnEsCreate(null, 7);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(obj);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(bomb_work.parent_obj);
        int num = bomb_work.area[0];
        int num2 = bomb_work.area[1];
        int num3 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num);
        int num4 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num2);
        obs_OBJECT_WORK.pos.x = bomb_work.pos[0] - ( num >> 1 ) + num3;
        obs_OBJECT_WORK.pos.y = bomb_work.pos[1] - ( num2 >> 1 ) + num4;
        obs_OBJECT_WORK.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
        int num5 = (int)(bomb_work.interval_max - bomb_work.interval_min);
        int num6 = AppMain.AkMathRandFx();
        uint num7 = (uint)(num6 * num5 >> 12);
        bomb_work.interval_timer = bomb_work.interval_min + num7;
    }

    // Token: 0x06001305 RID: 4869 RVA: 0x000A5328 File Offset: 0x000A3528
    private static void gmBoss2EffAfterburnerRequestCreate( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        body_work.flag |= 33554432U;
    }

    // Token: 0x06001306 RID: 4870 RVA: 0x000A533C File Offset: 0x000A353C
    private static void gmBoss2EffAfterburnerRequestDelete( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        body_work.flag &= 4294967293U;
        body_work.flag &= 4261412863U;
    }

    // Token: 0x06001307 RID: 4871 RVA: 0x000A5360 File Offset: 0x000A3560
    private static void gmBoss2EffAfterburnerInit( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        if ( ( body_work.flag & 2U ) != 0U )
        {
            return;
        }
        body_work.flag &= 4261412863U;
        body_work.flag |= 2U;
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 4U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -30f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffAfterburnerMainFunc );
    }

    // Token: 0x06001308 RID: 4872 RVA: 0x000A53D8 File Offset: 0x000A35D8
    private static void gmBoss2EffAfterburnerMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[0], 1 );
    }

    // Token: 0x06001309 RID: 4873 RVA: 0x000A5430 File Offset: 0x000A3630
    private static void gmBoss2EffAfterburnerSmokeInit( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 5U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffAfterburnerSmokeMainFunc );
    }

    // Token: 0x0600130A RID: 4874 RVA: 0x000A547C File Offset: 0x000A367C
    private static void gmBoss2EffAfterburnerSmokeMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[0], 1 );
    }

    // Token: 0x0600130B RID: 4875 RVA: 0x000A54AC File Offset: 0x000A36AC
    private static void gmBoss2EffBodySmokeInit( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 3U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffBodySmokeMainFunc );
    }

    // Token: 0x0600130C RID: 4876 RVA: 0x000A54F8 File Offset: 0x000A36F8
    private static void gmBoss2EffBodySmokeMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[0], 1 );
    }

    // Token: 0x0600130D RID: 4877 RVA: 0x000A5528 File Offset: 0x000A3728
    private static void gmBoss2EffSweatInit( AppMain.GMS_BOSS2_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(parent_obj, 93);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 32f, 0f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffSweatMainFunc );
        egg_work.flag |= 2U;
    }

    // Token: 0x0600130E RID: 4878 RVA: 0x000A5584 File Offset: 0x000A3784
    private static void gmBoss2EffSweatMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_EGG_WORK gms_BOSS2_EGG_WORK = (AppMain.GMS_BOSS2_EGG_WORK)obj_work.parent_obj;
        if ( ( gms_BOSS2_EGG_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x0600130F RID: 4879 RVA: 0x000A55CC File Offset: 0x000A37CC
    private static AppMain.OBS_OBJECT_WORK gmBoss2EffInit( AppMain.OBS_DATA_WORK data_work, int effect_type, AppMain.OBS_OBJECT_WORK parent_obj_work, short rot_x, short rot_y, short rot_z, float offset_x, float offset_y, float offset_z, int flag_flip, int flag_data_rotate )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DES_WORK(), null, 0, "B02_effect");
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectAction3dESEffectLoad( obs_OBJECT_WORK, gms_EFFECT_3DES_WORK.obj_3des, data_work, null, 0, null );
        AppMain.ObjObjectAction3dESTextureLoad( obs_OBJECT_WORK, gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( 722 ), null, 0, null, false );
        AppMain.ObjObjectAction3dESTextureSetByDwork( obs_OBJECT_WORK, AppMain.ObjDataGet( 723 ) );
        uint num = 0U;
        if ( parent_obj_work != null )
        {
            obs_OBJECT_WORK.parent_obj = parent_obj_work;
            obs_OBJECT_WORK.pos.x = parent_obj_work.pos.x;
            obs_OBJECT_WORK.pos.y = parent_obj_work.pos.y;
            obs_OBJECT_WORK.pos.z = parent_obj_work.pos.z;
            num |= 18U;
        }
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, rot_x, rot_y, rot_z );
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, offset_x, offset_y, offset_z );
        if ( flag_flip == 0 )
        {
            num |= 1U;
        }
        if ( flag_data_rotate != 0 )
        {
            num |= 64U;
        }
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, ( uint )effect_type, num );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001310 RID: 4880 RVA: 0x000A56C8 File Offset: 0x000A38C8
    private static void gmBoss2EffBallBombInit( AppMain.VecFx32 create_pos, AppMain.OBS_OBJECT_WORK body_obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss2EffInit(AppMain.ObjDataGet(717), 1, null, 0, 0, 0, 0f, 0f, 0f, 0, 0);
        obs_OBJECT_WORK.pos.x = create_pos.x;
        obs_OBJECT_WORK.pos.y = create_pos.y;
        obs_OBJECT_WORK.pos.z = create_pos.z + 131072;
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(body_obj_work);
        AppMain.gmBoss2MgrAddObject( mgr_work, obs_OBJECT_WORK );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2EffectExitFunc ) );
    }

    // Token: 0x06001311 RID: 4881 RVA: 0x000A575C File Offset: 0x000A395C
    private static AppMain.OBS_OBJECT_WORK gmBoss2EffBallBombPartInit( AppMain.VecFx32 create_pos, AppMain.OBS_OBJECT_WORK body_obj_work, int spd_x )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)AppMain.gmBoss2EffInit(AppMain.ObjDataGet(718), 2, null, 0, 0, 0, 0f, 0f, 0f, 0, 0);
        AppMain.OBS_OBJECT_WORK obj_work = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        AppMain.OBS_RECT_WORK[] rect_work = gms_EFFECT_3DES_WORK.efct_com.rect_work;
        AppMain.GmBsCmnSetEfctAtkVsPly( gms_EFFECT_3DES_WORK.efct_com, 64 );
        AppMain.ObjRectWorkSet( rect_work[1], -8, -8, 8, 8 );
        rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss2BallHitFunc );
        rect_work[1].flag |= 1028U;
        rect_work[0].flag |= 3072U;
        obj_work.pos.x = create_pos.x;
        obj_work.pos.y = create_pos.y;
        obj_work.pos.z = create_pos.z;
        obj_work.spd.x = spd_x;
        obj_work.spd.y = -16384;
        obj_work.move_flag |= 32912U;
        obj_work.flag |= 16U;
        obj_work.parent_obj = body_obj_work;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffBallBombPartMainFunc );
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(body_obj_work);
        AppMain.gmBoss2MgrAddObject( mgr_work, obj_work );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2EffectExitFunc ) );
        return obj_work;
    }

    // Token: 0x06001312 RID: 4882 RVA: 0x000A58B8 File Offset: 0x000A3AB8
    private static void gmBoss2EffBallBombPartMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( AppMain.ObjViewOutCheck( obj_work.pos.x, obj_work.pos.y, 64, 0, 0, 0, 0 ) != 0 )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06001313 RID: 4883 RVA: 0x000A5910 File Offset: 0x000A3B10
    private static void gmBoss2EffBlitzInit( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss2EffInit(AppMain.ObjDataGet(714), 2, obs_OBJECT_WORK, 0, 0, 0, 24f, 0f, 0f, 0, 0);
        obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffBlitzMainFuncBlitzCoreL );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = AppMain.gmBoss2EffInit(AppMain.ObjDataGet(714), 2, obs_OBJECT_WORK, 0, 0, 0, -24f, 0f, 0f, 0, 0);
        obs_OBJECT_WORK3.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffBlitzMainFuncBlitzCoreR );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = AppMain.gmBoss2EffInit(AppMain.ObjDataGet(715), 2, obs_OBJECT_WORK, 0, 0, AppMain.GMD_BOSS2_EFFECT_BLITZ_LINE_DISP_ROT_Z, 0f, -30f, 0f, 0, 0);
        obs_OBJECT_WORK4.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffBlitzMainFuncBlitzLineCreate );
        body_work.flag |= 4U;
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(obs_OBJECT_WORK);
        AppMain.gmBoss2MgrAddObject( mgr_work, obs_OBJECT_WORK2 );
        AppMain.gmBoss2MgrAddObject( mgr_work, obs_OBJECT_WORK3 );
        AppMain.gmBoss2MgrAddObject( mgr_work, obs_OBJECT_WORK4 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK2.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2EffectExitFunc ) );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK3.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2EffectExitFunc ) );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK4.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2EffectExitFunc ) );
    }

    // Token: 0x06001314 RID: 4884 RVA: 0x000A5A44 File Offset: 0x000A3C44
    private static void gmBoss2EffBlitzMainFuncBlitzLineCreate( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 4U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[2], 1 );
        obj_work.user_timer++;
        if ( ( float )obj_work.user_timer < 64f )
        {
            return;
        }
        obj_work.user_timer = 0;
        AppMain.GMS_EFFECT_3DES_WORK efct_3des = (AppMain.GMS_EFFECT_3DES_WORK)obj_work;
        AppMain.GmEffect3DESAddDispOffset( efct_3des, 0f, -4f, 0f );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffBlitzMainFuncBlitzLineNormal );
    }

    // Token: 0x06001315 RID: 4885 RVA: 0x000A5B10 File Offset: 0x000A3D10
    private static void gmBoss2EffBlitzMainFuncBlitzLineNormal( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 4U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[2], 1 );
    }

    // Token: 0x06001316 RID: 4886 RVA: 0x000A5B8C File Offset: 0x000A3D8C
    private static void gmBoss2EffBlitzMainFuncBlitzCoreL( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 4U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[7], 1 );
    }

    // Token: 0x06001317 RID: 4887 RVA: 0x000A5C08 File Offset: 0x000A3E08
    private static void gmBoss2EffBlitzMainFuncBlitzCoreR( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( gms_BOSS2_BODY_WORK.flag & 4U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[10], 1 );
    }

    // Token: 0x06001318 RID: 4888 RVA: 0x000A5C6C File Offset: 0x000A3E6C
    private static void gmBoss2EffBlitzMainFuncBlitzL( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( gms_BOSS2_BODY_WORK.flag & 4U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[6], 1 );
    }

    // Token: 0x06001319 RID: 4889 RVA: 0x000A5CD0 File Offset: 0x000A3ED0
    private static void gmBoss2EffBlitzMainFuncBlitzR( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS2_BODY_WORK.flag & 4U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS2_BODY_WORK.snm_work, gms_BOSS2_BODY_WORK.snm_reg_id[9], 1 );
    }

    // Token: 0x0600131A RID: 4890 RVA: 0x000A5D54 File Offset: 0x000A3F54
    private static void gmBoss2EffScatterInit( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK gms_BOSS2_EFFECT_SCATTER_WORK = null;
        int num = 3;
        while ( 13 > num )
        {
            AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK gms_BOSS2_EFFECT_SCATTER_WORK2 = (AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK)AppMain.GmBsCmnCreateNodeControlObjectBySize(parent_obj, body_work.cnm_mgr_work, body_work.cnm_reg_id[num], body_work.snm_work, body_work.snm_reg_id[2 + num], () => new AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK());
            AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)gms_BOSS2_EFFECT_SCATTER_WORK2;
            AppMain.GmBsCmnChangeCNMModeNode( body_work.cnm_mgr_work, body_work.cnm_reg_id[num], 0U );
            AppMain.GmBsCmnEnableCNMLocalCoordinate( body_work.cnm_mgr_work, body_work.cnm_reg_id[num], 0 );
            AppMain.GmBsCmnAttachNCObjectToSNMNode( gms_BS_CMN_NODE_CTRL_OBJECT );
            gms_BS_CMN_NODE_CTRL_OBJECT.is_enable = 1;
            gms_BS_CMN_NODE_CTRL_OBJECT.proc_update = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffScatterMainFunc );
            AppMain.OBS_OBJECT_WORK obj_work = gms_BS_CMN_NODE_CTRL_OBJECT.efct_com.obj_work;
            obj_work.move_flag |= 128U;
            if ( num == 4 || num == 5 || num == 7 || num == 8 )
            {
                AppMain.OBS_OBJECT_WORK obj_work2 = gms_BOSS2_EFFECT_SCATTER_WORK.control_node_work.efct_com.obj_work;
                obj_work.spd.x = obj_work2.spd.x;
                obj_work.spd.y = obj_work2.spd.y;
            }
            else
            {
                int right_flag = 0;
                if ( num % 2 != 0 )
                {
                    right_flag = 1;
                }
                AppMain.gmBoss2EffScatterSetParamMove( obj_work, right_flag );
            }
            gms_BOSS2_EFFECT_SCATTER_WORK = gms_BOSS2_EFFECT_SCATTER_WORK2;
            num++;
        }
    }

    // Token: 0x0600131B RID: 4891 RVA: 0x000A5EA4 File Offset: 0x000A40A4
    private static void gmBoss2EffScatterMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT ndc_obj = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obj_work;
        AppMain.GmBsCmnSetWorldMtxFromNCObjectPosture( ndc_obj );
        obj_work.user_timer++;
        if ( obj_work.user_timer < 100 )
        {
            return;
        }
        obj_work.user_timer = 0;
        obj_work.flag |= 4U;
    }

    // Token: 0x0600131C RID: 4892 RVA: 0x000A5EEC File Offset: 0x000A40EC
    private static void gmBoss2EffScatterSetParamMove( AppMain.OBS_OBJECT_WORK obj_work, int right_flag )
    {
        int num = (int)(AppMain.mtMathRand() % 30 + 45);
        if ( right_flag != 0 )
        {
            num = -num;
        }
        int ang = AppMain.AKM_DEGtoA32(num + 90);
        obj_work.spd.y = -( int )( 4096f * AppMain.nnSin( ang ) );
        obj_work.spd.x = ( int )( 4096f * AppMain.nnCos( ang ) );
    }

    // Token: 0x0600131D RID: 4893 RVA: 0x000A5F50 File Offset: 0x000A4150
    private static void gmBoss2EffCreateRollModel( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( body_work.flag & 32U ) != 0U )
        {
            return;
        }
        body_work.flag |= 32U;
        short y;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            y = ( short )AppMain.AKM_DEGtoA32( -90f );
        }
        else
        {
            y = ( short )AppMain.AKM_DEGtoA32( 90f );
        }
        AppMain.GMS_EFFECT_CREATE_PARAM create_param = new AppMain.GMS_EFFECT_CREATE_PARAM(11, 0U, 19U, new AppMain.NNS_VECTOR(0f, 0f, 64f), new AppMain.NNS_ROTATE_A16(0, y, 0), 3.2f, new AppMain.MPP_VOID_OBS_OBJECT_WORK(AppMain.GmEffectDefaultMainFuncDeleteAtEnd), 5);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = (AppMain.OBS_OBJECT_WORK)AppMain.GmEffect3dESCreateByParam(create_param, obs_OBJECT_WORK, AppMain.GmBoss2GetGameDatEnemyArc(), AppMain.ObjDataGet(719), AppMain.ObjDataGet(726), AppMain.ObjDataGet(727), AppMain.ObjDataGet(725), AppMain.ObjDataGet(724), () => new AppMain.GMS_EFFECT_3DES_WORK());
        obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss2EffRollModelMainFunc );
        obs_OBJECT_WORK2.obj_3des.command_state = 16U;
        AppMain.GMS_BOSS2_MGR_WORK mgr_work = AppMain.gmBoss2MgrGetMgrWork(obs_OBJECT_WORK);
        AppMain.gmBoss2MgrAddObject( mgr_work, obs_OBJECT_WORK2 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK2.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss2EffectExitFunc ) );
    }

    // Token: 0x0600131E RID: 4894 RVA: 0x000A6088 File Offset: 0x000A4288
    private static void gmBoss2EffCreateRollModelLost( AppMain.GMS_BOSS2_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.AKM_DEGtoA32( -90f );
            return;
        }
        AppMain.AKM_DEGtoA32( 90f );
    }

    // Token: 0x0600131F RID: 4895 RVA: 0x000A60C0 File Offset: 0x000A42C0
    public static void gmBoss2EffRollModelMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        uint num = obj_work.disp_flag & 8U;
        if ( ( gms_BOSS2_BODY_WORK.flag & 32U ) == 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06001320 RID: 4896 RVA: 0x000A60FC File Offset: 0x000A42FC
    private static void gmBoss2EffRollMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS2_BODY_WORK gms_BOSS2_BODY_WORK = (AppMain.GMS_BOSS2_BODY_WORK)obj_work.parent_obj;
        uint num = obj_work.disp_flag & 8U;
        if ( ( gms_BOSS2_BODY_WORK.flag & 32U ) == 0U )
        {
            obj_work.flag |= 4U;
        }
    }
}
