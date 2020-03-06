using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200026E RID: 622
    public class GMS_BOSS3_PART_ACT_INFO
    {
        // Token: 0x06002403 RID: 9219 RVA: 0x0014A0B1 File Offset: 0x001482B1
        public GMS_BOSS3_PART_ACT_INFO( ushort id, byte mntain, byte isrep, float spd, int blnd, float bspd, int mergeman )
        {
            this.mtn_id = id;
            this.is_maintain = mntain;
            this.is_repeat = isrep;
            this.mtn_spd = spd;
            this.is_blend = blnd;
            this.blend_spd = bspd;
            this.is_merge_manual = mergeman;
        }

        // Token: 0x04005961 RID: 22881
        public ushort mtn_id;

        // Token: 0x04005962 RID: 22882
        public byte is_maintain;

        // Token: 0x04005963 RID: 22883
        public byte is_repeat;

        // Token: 0x04005964 RID: 22884
        public float mtn_spd;

        // Token: 0x04005965 RID: 22885
        public int is_blend;

        // Token: 0x04005966 RID: 22886
        public float blend_spd;

        // Token: 0x04005967 RID: 22887
        public int is_merge_manual;
    }

    // Token: 0x0200026F RID: 623
    // (Invoke) Token: 0x06002405 RID: 9221
    public delegate void GMF_BOSS3_BODY_STATE_FUNC( AppMain.GMS_BOSS3_BODY_WORK body_work );

    // Token: 0x02000270 RID: 624
    // (Invoke) Token: 0x06002409 RID: 9225
    public delegate void GMF_BOSS3_EGG_STATE_FUNC( AppMain.GMS_BOSS3_EGG_WORK egg_work );

    // Token: 0x02000271 RID: 625
    public class GMS_BOSS3_EFF_BOMB_WORK
    {
        // Token: 0x04005968 RID: 22888
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x04005969 RID: 22889
        public uint interval_timer;

        // Token: 0x0400596A RID: 22890
        public uint interval_min;

        // Token: 0x0400596B RID: 22891
        public uint interval_max;

        // Token: 0x0400596C RID: 22892
        public int[] pos = new int[2];

        // Token: 0x0400596D RID: 22893
        public int[] area = new int[2];
    }

    // Token: 0x02000272 RID: 626
    public class GMS_BOSS3_MGR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600240D RID: 9229 RVA: 0x0014A10E File Offset: 0x0014830E
        public GMS_BOSS3_MGR_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600240E RID: 9230 RVA: 0x0014A122 File Offset: 0x00148322
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS3_MGR_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0600240F RID: 9231 RVA: 0x0014A134 File Offset: 0x00148334
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0400596E RID: 22894
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x0400596F RID: 22895
        public int life;

        // Token: 0x04005970 RID: 22896
        public uint flag;

        // Token: 0x04005971 RID: 22897
        public AppMain.GMS_BOSS3_BODY_WORK body_work;

        // Token: 0x04005972 RID: 22898
        public int obj_create_count;
    }

    // Token: 0x02000273 RID: 627
    public class GMS_BOSS3_BODY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002410 RID: 9232 RVA: 0x0014A148 File Offset: 0x00148348
        public GMS_BOSS3_BODY_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002411 RID: 9233 RVA: 0x0014A1CE File Offset: 0x001483CE
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS3_BODY_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002412 RID: 9234 RVA: 0x0014A1E0 File Offset: 0x001483E0
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005973 RID: 22899
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005974 RID: 22900
        public AppMain.OBS_OBJECT_WORK[] parts_objs = new AppMain.OBS_OBJECT_WORK[2];

        // Token: 0x04005975 RID: 22901
        public int state;

        // Token: 0x04005976 RID: 22902
        public int prev_state;

        // Token: 0x04005977 RID: 22903
        public AppMain.GMF_BOSS3_BODY_STATE_FUNC proc_update;

        // Token: 0x04005978 RID: 22904
        public uint flag;

        // Token: 0x04005979 RID: 22905
        public int action_id;

        // Token: 0x0400597A RID: 22906
        public int pattern_no;

        // Token: 0x0400597B RID: 22907
        public short angle_current;

        // Token: 0x0400597C RID: 22908
        public AppMain.VecFx32 start_pos = default(AppMain.VecFx32);

        // Token: 0x0400597D RID: 22909
        public AppMain.VecFx32 end_pos = default(AppMain.VecFx32);

        // Token: 0x0400597E RID: 22910
        public float move_counter;

        // Token: 0x0400597F RID: 22911
        public float move_frame;

        // Token: 0x04005980 RID: 22912
        public short turn_start;

        // Token: 0x04005981 RID: 22913
        public int turn_amount;

        // Token: 0x04005982 RID: 22914
        public float turn_counter;

        // Token: 0x04005983 RID: 22915
        public float turn_frame;

        // Token: 0x04005984 RID: 22916
        public int is_move;

        // Token: 0x04005985 RID: 22917
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04005986 RID: 22918
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04005987 RID: 22919
        public int[] snm_reg_id = new int[1];

        // Token: 0x04005988 RID: 22920
        public readonly AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work = new AppMain.GMS_BS_CMN_DMG_FLICKER_WORK();

        // Token: 0x04005989 RID: 22921
        public uint counter_no_hit;

        // Token: 0x0400598A RID: 22922
        public uint counter_invincible;

        // Token: 0x0400598B RID: 22923
        public readonly AppMain.GMS_CMN_FLASH_SCR_WORK flash_work = new AppMain.GMS_CMN_FLASH_SCR_WORK();

        // Token: 0x0400598C RID: 22924
        public readonly AppMain.GMS_BOSS3_EFF_BOMB_WORK bomb_work = new AppMain.GMS_BOSS3_EFF_BOMB_WORK();
    }

    // Token: 0x02000274 RID: 628
    public class GMS_BOSS3_EGG_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002413 RID: 9235 RVA: 0x0014A1F2 File Offset: 0x001483F2
        public GMS_BOSS3_EGG_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002414 RID: 9236 RVA: 0x0014A206 File Offset: 0x00148406
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS3_EGG_WORK p )
        {
            return p.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06002415 RID: 9237 RVA: 0x0014A218 File Offset: 0x00148418
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0400598D RID: 22925
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x0400598E RID: 22926
        public int egg_action_id;

        // Token: 0x0400598F RID: 22927
        public uint flag;

        // Token: 0x04005990 RID: 22928
        public AppMain.GMF_BOSS3_EGG_STATE_FUNC proc_update;
    }

    // Token: 0x060010B2 RID: 4274 RVA: 0x00092C74 File Offset: 0x00090E74
    private static void GmBoss3Build()
    {
        AppMain.AMS_AMB_HEADER amb = AppMain.GmBoss3GetGameDatEnemyArc();
        AppMain.AMS_AMB_HEADER mdl_amb = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, amb);
        AppMain.AMS_AMB_HEADER tex_amb = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 1, amb);
        AppMain.gm_boss3_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 728 ), 2, amb );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 729 ), 3, amb );
    }

    // Token: 0x060010B3 RID: 4275 RVA: 0x00092CD4 File Offset: 0x00090ED4
    private static void GmBoss3Flush()
    {
        AppMain.GmEfctBossFlushSingleDataInit();
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 729 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 728 ) );
        AppMain.AMS_AMB_HEADER amb = AppMain.GmBoss3GetGameDatEnemyArc();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, amb);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_boss3_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_boss3_obj_3d_list = null;
    }

    // Token: 0x060010B4 RID: 4276 RVA: 0x00092D2E File Offset: 0x00090F2E
    private static AppMain.AMS_AMB_HEADER GmBoss3GetGameDatEnemyArc()
    {
        return AppMain.g_gm_gamedat_enemy_arc;
    }

    // Token: 0x060010B5 RID: 4277 RVA: 0x00092D3C File Offset: 0x00090F3C
    private static AppMain.OBS_OBJECT_WORK GmBoss3Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = (AppMain.GMS_BOSS3_MGR_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS3_MGR_WORK(), "BOSS3_MGR");
        AppMain.OBS_OBJECT_WORK obj_work = gms_BOSS3_MGR_WORK.ene_3d.ene_com.obj_work;
        obj_work.flag |= 16U;
        obj_work.disp_flag |= 32U;
        obj_work.move_flag |= 8448U;
        gms_BOSS3_MGR_WORK.ene_3d.ene_com.enemy_flag |= 32768U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3MgrMainFuncWaitLoad );
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            gms_BOSS3_MGR_WORK.life = 4;
        }
        else
        {
            gms_BOSS3_MGR_WORK.life = 8;
        }
        return obj_work;
    }

    // Token: 0x060010B6 RID: 4278 RVA: 0x00092E08 File Offset: 0x00091008
    private static AppMain.OBS_OBJECT_WORK GmBoss3BodyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS3_BODY_WORK(), "BOSS3_BODY");
        AppMain.GMS_ENEMY_3D_WORK ene_3d = gms_BOSS3_BODY_WORK.ene_3d;
        AppMain.OBS_OBJECT_WORK obj_work = ene_3d.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_boss3_obj_3d_list[0], ene_3d.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, true, AppMain.ObjDataGet( 728 ), null, 0, null );
        ene_3d.ene_com.vit = 1;
        AppMain.ObjRectWorkSet( ene_3d.ene_com.rect_work[2], -24, -24, 24, 24 );
        AppMain.ObjRectGroupSet( ene_3d.ene_com.rect_work[2], 1, 3 );
        ene_3d.ene_com.rect_work[2].flag &= 4294967291U;
        ene_3d.ene_com.rect_work[2].flag |= 1024U;
        gms_BOSS3_BODY_WORK.ene_3d.ene_com.rect_work[1].flag |= 1024U;
        AppMain.ObjRectWorkSet( ene_3d.ene_com.rect_work[0], -28, -28, 28, 24 );
        ene_3d.ene_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss3BodyDefFunc );
        ene_3d.ene_com.rect_work[0].flag |= 1024U;
        AppMain.gmBoss3BodySetRectNormal( gms_BOSS3_BODY_WORK );
        obj_work.pos.z = 655360;
        obj_work.flag |= 16U;
        obj_work.disp_flag |= 4194309U;
        obj_work.move_flag &= 4294967167U;
        obj_work.move_flag |= 53776U;
        gms_BOSS3_BODY_WORK.is_move = 0;
        obj_work.obj_3d.blend_spd = 0.125f;
        AppMain.ObjDrawObjectSetToon( obj_work );
        obj_work.disp_flag |= 134217728U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3BodyMainFuncWaitSetup );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3BodyOutFunc );
        obj_work.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3BodyChaseMoveFunc );
        AppMain.gmBoss3BodyChangeState( gms_BOSS3_BODY_WORK, 0 );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return obj_work;
    }

    // Token: 0x060010B7 RID: 4279 RVA: 0x00093068 File Offset: 0x00091268
    private static AppMain.OBS_OBJECT_WORK GmBoss3EggInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS3_EGG_WORK gms_BOSS3_EGG_WORK = (AppMain.GMS_BOSS3_EGG_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS3_EGG_WORK(), "BOSS3_EGG");
        AppMain.GMS_ENEMY_3D_WORK ene_3d = gms_BOSS3_EGG_WORK.ene_3d;
        AppMain.OBS_OBJECT_WORK obj_work = ene_3d.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_boss3_obj_3d_list[1], ene_3d.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, true, AppMain.ObjDataGet( 729 ), null, 0, null );
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
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3EggmanMainFuncWaitSetup );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return obj_work;
    }

    // Token: 0x060010B8 RID: 4280 RVA: 0x000931FC File Offset: 0x000913FC
    private static void gmBoss3ChangeTextureBurnt( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d.drawflag |= 268435456U;
        obj_work.obj_3d.draw_state.texoffset[0].mode = 2;
        obj_work.obj_3d.draw_state.texoffset[0].u = 0.5f;
    }

    // Token: 0x060010B9 RID: 4281 RVA: 0x00093254 File Offset: 0x00091454
    private static void gmBoss3ExitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmBoss3MgrDeleteObject( obj_work_parts );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060010BA RID: 4282 RVA: 0x00093274 File Offset: 0x00091474
    private static int gmBoss3MgrCheckSetupComplete( AppMain.GMS_BOSS3_MGR_WORK mgr_work )
    {
        if ( ( mgr_work.flag & 1U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x060010BB RID: 4283 RVA: 0x00093283 File Offset: 0x00091483
    private static AppMain.GMS_BOSS3_MGR_WORK gmBoss3MgrGetMgrWork( AppMain.OBS_OBJECT_WORK obj_work_parts )
    {
        return ( AppMain.GMS_BOSS3_MGR_WORK )obj_work_parts.user_work_OBJECT;
    }

    // Token: 0x060010BC RID: 4284 RVA: 0x00093290 File Offset: 0x00091490
    private static void gmBoss3MgrAddObject( AppMain.GMS_BOSS3_MGR_WORK mgr_work, AppMain.OBS_OBJECT_WORK obj_work_parts )
    {
        mgr_work.obj_create_count++;
        obj_work_parts.user_work_OBJECT = mgr_work;
    }

    // Token: 0x060010BD RID: 4285 RVA: 0x000932A8 File Offset: 0x000914A8
    private static void gmBoss3MgrDeleteObject( AppMain.OBS_OBJECT_WORK obj_work_parts )
    {
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = AppMain.gmBoss3MgrGetMgrWork(obj_work_parts);
        gms_BOSS3_MGR_WORK.obj_create_count--;
        obj_work_parts.user_work = 0U;
    }

    // Token: 0x060010BE RID: 4286 RVA: 0x000932D4 File Offset: 0x000914D4
    private static void gmBoss3MgrMainFuncWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 && !AppMain.GmMainDatLoadBossBattleLoadCheck( 2 ) )
        {
            return;
        }
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = (AppMain.GMS_BOSS3_MGR_WORK)obj_work;
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)AppMain.GmEventMgrLocalEventBirth(319, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_BOSS3_BODY_WORK.ene_3d.ene_com.obj_work;
        obj_work2.parent_obj = obj_work;
        gms_BOSS3_BODY_WORK.parts_objs[0] = obj_work2;
        gms_BOSS3_MGR_WORK.body_work = gms_BOSS3_BODY_WORK;
        AppMain.gmBoss3MgrAddObject( gms_BOSS3_MGR_WORK, obj_work2 );
        AppMain.mtTaskChangeTcbDestructor( obj_work2.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss3BodyExit ) );
        AppMain.GMS_BOSS3_EGG_WORK gms_BOSS3_EGG_WORK = (AppMain.GMS_BOSS3_EGG_WORK)AppMain.GmEventMgrLocalEventBirth(320, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
        AppMain.OBS_OBJECT_WORK obj_work3 = gms_BOSS3_EGG_WORK.ene_3d.ene_com.obj_work;
        obj_work3.parent_obj = obj_work2;
        AppMain.gmBoss3MgrAddObject( gms_BOSS3_MGR_WORK, obj_work3 );
        AppMain.mtTaskChangeTcbDestructor( obj_work3.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss3ExitFunc ) );
        gms_BOSS3_BODY_WORK.parts_objs[1] = obj_work3;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3MgrMainFuncWaitSetup );
    }

    // Token: 0x060010BF RID: 4287 RVA: 0x000933F0 File Offset: 0x000915F0
    private static void gmBoss3MgrMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = (AppMain.GMS_BOSS3_MGR_WORK)obj_work;
        AppMain.GMS_BOSS3_BODY_WORK body_work = gms_BOSS3_MGR_WORK.body_work;
        int num = 0;
        while ( 2 > num )
        {
            if ( body_work.parts_objs[num] == null )
            {
                return;
            }
            num++;
        }
        gms_BOSS3_MGR_WORK.flag |= 1U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3MgrMainFunc );
    }

    // Token: 0x060010C0 RID: 4288 RVA: 0x00093444 File Offset: 0x00091644
    private static void gmBoss3MgrMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = (AppMain.GMS_BOSS3_MGR_WORK)obj_work;
        if ( ( gms_BOSS3_MGR_WORK.flag & 2U ) != 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS3_MGR_WORK.body_work);
            obs_OBJECT_WORK.flag |= 8U;
            gms_BOSS3_MGR_WORK.body_work = null;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3MgrMainFuncWaitRelease );
        }
    }

    // Token: 0x060010C1 RID: 4289 RVA: 0x00093498 File Offset: 0x00091698
    private static void gmBoss3MgrMainFuncWaitRelease( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = (AppMain.GMS_BOSS3_MGR_WORK)obj_work;
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            if ( gms_BOSS3_MGR_WORK.obj_create_count > 0 )
            {
                return;
            }
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
            obj_work.flag |= 4U;
            AppMain.GmGameDatReleaseBossBattleStart( 2 );
            AppMain.GmGmkCamScrLimitRelease( 14 );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss3BodyBattleSearchPillar();
            if ( obs_OBJECT_WORK != null )
            {
                AppMain.GmGmkBoss3PillarWallChangeModeReturn( obs_OBJECT_WORK );
            }
        }
        obj_work.ppFunc = null;
    }

    // Token: 0x060010C2 RID: 4290 RVA: 0x0009350C File Offset: 0x0009170C
    private static void gmBoss3BodyExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.OBS_OBJECT_WORK obj_work = gms_BOSS3_BODY_WORK.ene_3d.ene_com.obj_work;
        AppMain.GmBsCmnClearBossMotionCBSystem( obj_work );
        AppMain.GmBsCmnDeleteSNMWork( gms_BOSS3_BODY_WORK.snm_work );
        AppMain.GmBsCmnClearCNMCb( obj_work );
        AppMain.gmBoss3ExitFunc( tcb );
    }

    // Token: 0x060010C3 RID: 4291 RVA: 0x00093554 File Offset: 0x00091754
    private static void gmBoss3BodyReactionPlayer( AppMain.OBS_OBJECT_WORK obj_work_player, AppMain.OBS_OBJECT_WORK obj_work_body )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work_player;
        AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
        AppMain.GmPlySeqSetJumpState( gms_PLAYER_WORK, 0, 5U );
        int num = 2048;
        int num2 = 1228;
        if ( gms_PLAYER_WORK.seq_state == 20 )
        {
            num = 12288;
            num2 = 12288;
        }
        obj_work_player.spd_m = 0;
        if ( obj_work_player.move.x >= 0 )
        {
            obj_work_player.spd.x = -num;
        }
        else
        {
            obj_work_player.spd.x = num;
        }
        if ( obj_work_player.pos.y <= obj_work_body.pos.y )
        {
            obj_work_player.spd.y = -num2;
        }
        else
        {
            obj_work_player.spd.y = num2;
        }
        AppMain.GmPlySeqSetNoJumpMoveTime( gms_PLAYER_WORK, 102400 );
    }

    // Token: 0x060010C4 RID: 4292 RVA: 0x00093606 File Offset: 0x00091806
    private static void gmBoss3BodySetRectNormal( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.ObjRectWorkSet( body_work.ene_3d.ene_com.rect_work[1], -8, -8, 8, 8 );
        body_work.ene_3d.ene_com.rect_work[0].flag |= 4U;
    }

    // Token: 0x060010C5 RID: 4293 RVA: 0x00093645 File Offset: 0x00091845
    private static void gmBoss3BodySetActionAllParts( AppMain.GMS_BOSS3_BODY_WORK body_work, int action_id )
    {
        AppMain.gmBoss3BodySetActionAllParts( body_work, action_id, 0 );
    }

    // Token: 0x060010C6 RID: 4294 RVA: 0x00093650 File Offset: 0x00091850
    private static void gmBoss3BodySetActionAllParts( AppMain.GMS_BOSS3_BODY_WORK body_work, int action_id, int force_change )
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
                AppMain.GMS_BOSS3_PART_ACT_INFO gms_BOSS3_PART_ACT_INFO = AppMain.gm_boss3_act_info_tbl[action_id][num];
                if ( num == 1 )
                {
                    AppMain.GMS_BOSS3_EGG_WORK gms_BOSS3_EGG_WORK = (AppMain.GMS_BOSS3_EGG_WORK)obs_OBJECT_WORK;
                    if ( ( gms_BOSS3_EGG_WORK.flag & 1U ) != 0U )
                    {
                        goto IL_A2;
                    }
                }
                if ( gms_BOSS3_PART_ACT_INFO.is_maintain != 0 )
                {
                    if ( gms_BOSS3_PART_ACT_INFO.is_repeat != 0 )
                    {
                        obs_OBJECT_WORK.disp_flag |= 4U;
                    }
                }
                else
                {
                    AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS3_PART_ACT_INFO.mtn_id, ( int )gms_BOSS3_PART_ACT_INFO.is_repeat, gms_BOSS3_PART_ACT_INFO.is_blend );
                }
                obs_OBJECT_WORK.obj_3d.speed[0] = gms_BOSS3_PART_ACT_INFO.mtn_spd;
                obs_OBJECT_WORK.obj_3d.blend_spd = gms_BOSS3_PART_ACT_INFO.blend_spd;
            }
            IL_A2:
            num++;
        }
    }

    // Token: 0x060010C7 RID: 4295 RVA: 0x0009370A File Offset: 0x0009190A
    private static void gmBoss3BodyOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x060010C8 RID: 4296 RVA: 0x00093714 File Offset: 0x00091914
    private static void gmBoss3BodyChaseMoveFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int x = obj_work.spd.x;
        int y = obj_work.spd.y;
        AppMain.GMS_BOSS3_BODY_WORK body_work = (AppMain.GMS_BOSS3_BODY_WORK)obj_work;
        AppMain.gmBoss3BodyChaseAdjustMoveSpeed( body_work );
        AppMain.ObjObjectMove( obj_work );
        obj_work.spd.x = x;
        obj_work.spd.y = y;
    }

    // Token: 0x060010C9 RID: 4297 RVA: 0x00093764 File Offset: 0x00091964
    private static void gmBoss3BodyDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = target_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = own_rect.parent_obj;
        AppMain.GMS_BOSS3_BODY_WORK body_work = (AppMain.GMS_BOSS3_BODY_WORK)parent_obj2;
        if ( parent_obj == null || 1 != parent_obj.obj_type )
        {
            return;
        }
        AppMain.gmBoss3BodyReactionPlayer( parent_obj, parent_obj2 );
        AppMain.gmBoss3BodySetNoHitTime( body_work, 10U );
        AppMain.gmBoss3BodyDamage( body_work );
    }

    // Token: 0x060010CA RID: 4298 RVA: 0x000937A8 File Offset: 0x000919A8
    private static void gmBoss3BodySetNoHitTime( AppMain.GMS_BOSS3_BODY_WORK body_work, uint time )
    {
        AppMain.GMS_ENEMY_COM_WORK ene_com = body_work.ene_3d.ene_com;
        body_work.counter_no_hit = time;
        ene_com.rect_work[0].flag |= 2048U;
    }

    // Token: 0x060010CB RID: 4299 RVA: 0x000937E4 File Offset: 0x000919E4
    private static void gmBoss3BodyUpdateNoHitTime( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        if ( body_work.counter_no_hit > 0U )
        {
            body_work.counter_no_hit -= 1U;
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK ene_com = body_work.ene_3d.ene_com;
        ene_com.rect_work[0].flag &= 4294965247U;
    }

    // Token: 0x060010CC RID: 4300 RVA: 0x0009382E File Offset: 0x00091A2E
    private static void gmBoss3BodySetInvincibleTime( AppMain.GMS_BOSS3_BODY_WORK body_work, uint time )
    {
        body_work.counter_invincible = time;
        body_work.flag |= 1U;
    }

    // Token: 0x060010CD RID: 4301 RVA: 0x00093845 File Offset: 0x00091A45
    private static void gmBoss3BodyUpdateInvincibleTime( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        if ( body_work.counter_invincible > 0U )
        {
            body_work.counter_invincible -= 1U;
            return;
        }
        body_work.flag &= 4294967294U;
    }

    // Token: 0x060010CE RID: 4302 RVA: 0x0009386E File Offset: 0x00091A6E
    private static void gmBoss3BodySetDirection( AppMain.GMS_BOSS3_BODY_WORK body_work, short deg )
    {
        body_work.angle_current = deg;
    }

    // Token: 0x060010CF RID: 4303 RVA: 0x00093878 File Offset: 0x00091A78
    private static void gmBoss3BodySetDirectionNormal( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss3BodySetDirection( body_work, AppMain.GMD_BOSS3_ANGLE_LEFT );
            return;
        }
        AppMain.gmBoss3BodySetDirection( body_work, AppMain.GMD_BOSS3_ANGLE_RIGHT );
    }

    // Token: 0x060010D0 RID: 4304 RVA: 0x000938B0 File Offset: 0x00091AB0
    private static void gmBoss3BodyUpdateDirection( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.dir.y = ( ushort )body_work.angle_current;
    }

    // Token: 0x060010D1 RID: 4305 RVA: 0x000938D8 File Offset: 0x00091AD8
    private static float gmBoss3BodyCalcMoveXNormalFrame( AppMain.GMS_BOSS3_BODY_WORK body_work, int x, int speed )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        int num = AppMain.MTM_MATH_ABS(x - obs_OBJECT_WORK.pos.x);
        return ( float )num / ( float )speed;
    }

    // Token: 0x060010D2 RID: 4306 RVA: 0x00093908 File Offset: 0x00091B08
    private static void gmBoss3BodyInitMoveNormal( AppMain.GMS_BOSS3_BODY_WORK body_work, AppMain.VecFx32 dest_pos, float frame )
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

    // Token: 0x060010D3 RID: 4307 RVA: 0x000939C0 File Offset: 0x00091BC0
    private static float gmBoss3BodyUpdateMoveNormal( AppMain.GMS_BOSS3_BODY_WORK body_work )
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

    // Token: 0x060010D4 RID: 4308 RVA: 0x00093B68 File Offset: 0x00091D68
    private static void gmBoss3BodyInitTurn( AppMain.GMS_BOSS3_BODY_WORK body_work, short dest_angle, float frame, int flag_positive )
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

    // Token: 0x060010D5 RID: 4309 RVA: 0x00093BCC File Offset: 0x00091DCC
    private static float gmBoss3BodyUpdateTurn( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        if ( body_work.turn_frame < 1f )
        {
            return 0f;
        }
        body_work.turn_counter += 1f;
        short deg;
        if ( body_work.turn_counter >= body_work.turn_frame )
        {
            deg = ( short )( ( int )body_work.turn_start + body_work.turn_amount );
        }
        else
        {
            float num = body_work.turn_counter / body_work.turn_frame;
            int ang = AppMain.AKM_DEGtoA32(180f * num);
            float num2 = (float)body_work.turn_amount * 0.5f * (1f - AppMain.nnCos(ang));
            deg = ( short )( ( float )body_work.turn_start + num2 );
        }
        AppMain.gmBoss3BodySetDirection( body_work, deg );
        return body_work.turn_frame - body_work.turn_counter;
    }

    // Token: 0x060010D6 RID: 4310 RVA: 0x00093C74 File Offset: 0x00091E74
    private static int gmBoss3BodyChaseCheckTurn( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.spd.x < 0 )
            {
                return 0;
            }
        }
        else if ( obs_OBJECT_WORK.spd.x > 0 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060010D7 RID: 4311 RVA: 0x00093CB4 File Offset: 0x00091EB4
    private static void gmBoss3BodyChaseAdjustMoveSpeed( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = AppMain.gmBoss3MgrGetMgrWork(obs_OBJECT_WORK);
        int num = AppMain.FX_F32_TO_FX32(1f + (float)(8 - gms_BOSS3_MGR_WORK.life) * 0.2f);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.obj_work.pos.y < obs_OBJECT_WORK.pos.y )
        {
            if ( obs_OBJECT_WORK.spd.x > 0 && obs_OBJECT_WORK.pos.x < gms_PLAYER_WORK.obj_work.pos.x )
            {
                num = AppMain.FX_Mul( num, 8192 );
            }
            if ( obs_OBJECT_WORK.spd.x < 0 && gms_PLAYER_WORK.obj_work.pos.x < obs_OBJECT_WORK.pos.x )
            {
                num = AppMain.FX_Mul( num, 8192 );
            }
        }
        obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( obs_OBJECT_WORK.spd.x, num );
        obs_OBJECT_WORK.spd.y = AppMain.FX_Mul( obs_OBJECT_WORK.spd.y, num );
        if ( body_work.is_move == 0 )
        {
            obs_OBJECT_WORK.spd.x = 0;
            obs_OBJECT_WORK.spd.y = 0;
        }
    }

    // Token: 0x060010D8 RID: 4312 RVA: 0x00093DDC File Offset: 0x00091FDC
    private static int gmBoss3BodyBattleCalcPattern( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = AppMain.gmBoss3MgrGetMgrWork(obj_work_parts);
        int num = (int)(AppMain.mtMathRand() % 100);
        int num2 = 0;
        int num3 = 0;
        while ( 7 > num3 )
        {
            num2 += AppMain.g_gm_boss3_battle_pattern_per[gms_BOSS3_MGR_WORK.life - 1][num3];
            if ( num < num2 )
            {
                return num3;
            }
            num3++;
        }
        return 0;
    }

    // Token: 0x060010D9 RID: 4313 RVA: 0x00093E30 File Offset: 0x00092030
    private static int gmBoss3BodyBattleInitMovePattern( AppMain.GMS_BOSS3_BODY_WORK body_work, int pattern_no, int pos_index, int move_speed )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.g_gm_boss3_battle_move_x[pattern_no][pos_index] == 0 )
        {
            return 0;
        }
        AppMain.VecFx32 dest_pos = new AppMain.VecFx32(obs_OBJECT_WORK.pos.x + AppMain.g_gm_boss3_battle_move_x[pattern_no][pos_index] * 4096, obs_OBJECT_WORK.pos.y, obs_OBJECT_WORK.pos.z);
        float frame = AppMain.gmBoss3BodyCalcMoveXNormalFrame(body_work, dest_pos.x, move_speed);
        AppMain.gmBoss3BodyInitMoveNormal( body_work, dest_pos, frame );
        return 1;
    }

    // Token: 0x060010DA RID: 4314 RVA: 0x00093EA4 File Offset: 0x000920A4
    private static int gmBoss3BodyBattleCheckTurn( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( body_work.end_pos.x <= body_work.start_pos.x )
            {
                return 0;
            }
        }
        else if ( body_work.start_pos.x <= body_work.end_pos.x )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060010DB RID: 4315 RVA: 0x00093EF8 File Offset: 0x000920F8
    private static AppMain.OBS_OBJECT_WORK gmBoss3BodyBattleSearchPillar()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        for ( obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id == 279 )
            {
                break;
            }
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x060010DC RID: 4316 RVA: 0x00093F3C File Offset: 0x0009213C
    private static void gmBoss3BodyDamage( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(body_work);
        if ( ( body_work.flag & 1U ) != 0U )
        {
            return;
        }
        AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = AppMain.gmBoss3MgrGetMgrWork(obj_work_parts);
        gms_BOSS3_MGR_WORK.life--;
        if ( gms_BOSS3_MGR_WORK.life > 0 )
        {
            body_work.flag |= 1073741824U;
        }
        else
        {
            body_work.flag |= 2147483648U;
        }
        AppMain.GmSoundPlaySE( "Boss0_01" );
        AppMain.gmBoss3EffDamageInit( body_work );
        AppMain.GmPadVibSet( 1, 30f, 8192, 8192, 0f, 0f, 0f, 8191U );
        AppMain.gmBoss3BodySetInvincibleTime( body_work, 120U );
    }

    // Token: 0x060010DD RID: 4317 RVA: 0x00093FE0 File Offset: 0x000921E0
    private static int gmBoss3BodyEscapeCheckScreenOut( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.pos.x >= ( AppMain.g_gm_main_system.map_fcol.right + 64 ) * 4096 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x060010DE RID: 4318 RVA: 0x0009401C File Offset: 0x0009221C
    private static void gmBoss3BodyEscapeAddjustSpeed( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd.x ) > -1228 )
        {
            obs_OBJECT_WORK.spd.x = 6144;
            obs_OBJECT_WORK.spd.y = -1228;
            obs_OBJECT_WORK.spd_add.x = 0;
            obs_OBJECT_WORK.spd_add.y = 0;
        }
    }

    // Token: 0x060010DF RID: 4319 RVA: 0x00094080 File Offset: 0x00092280
    private static void gmBoss3BodyChangeState( AppMain.GMS_BOSS3_BODY_WORK body_work, int state )
    {
        AppMain.GMF_BOSS3_BODY_STATE_FUNC gmf_BOSS3_BODY_STATE_FUNC = AppMain.gm_boss3_body_state_func_tbl_leave[body_work.state];
        if ( gmf_BOSS3_BODY_STATE_FUNC != null )
        {
            gmf_BOSS3_BODY_STATE_FUNC( body_work );
        }
        body_work.prev_state = body_work.state;
        body_work.state = state;
        AppMain.GMF_BOSS3_BODY_STATE_FUNC gmf_BOSS3_BODY_STATE_FUNC2 = AppMain.gm_boss3_body_state_func_tbl_enter[body_work.state];
        if ( gmf_BOSS3_BODY_STATE_FUNC2 != null )
        {
            gmf_BOSS3_BODY_STATE_FUNC2( body_work );
        }
    }

    // Token: 0x060010E0 RID: 4320 RVA: 0x000940D0 File Offset: 0x000922D0
    private static void gmBoss3BodyStateStartEnter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        AppMain.gmBoss3BodySetActionAllParts( body_work, 0, 1 );
        AppMain.gmBoss3BodySetDirectionNormal( body_work );
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateStartUpdateWait );
        }
        else
        {
            body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateStartUpdateWaitScrLimit );
        }
        obs_OBJECT_WORK.user_timer = 180;
        body_work.ene_3d.ene_com.enemy_flag |= 32768U;
    }

    // Token: 0x060010E1 RID: 4321 RVA: 0x00094158 File Offset: 0x00092358
    private static void gmBoss3BodyStateStartLeave( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag &= 4294967293U;
        body_work.flag &= 4294967279U;
        body_work.ene_3d.ene_com.enemy_flag &= 4294934527U;
    }

    // Token: 0x060010E2 RID: 4322 RVA: 0x000941A6 File Offset: 0x000923A6
    private static void gmBoss3BodyStateStartUpdateWaitScrLimit( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        if ( ( AppMain.g_gm_main_system.game_flag & 32768U ) == 0U )
        {
            return;
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateStartUpdateWait );
    }

    // Token: 0x060010E3 RID: 4323 RVA: 0x000941D0 File Offset: 0x000923D0
    private static void gmBoss3BodyStateStartUpdateWait( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss3BodySetDirectionNormal( body_work );
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
        body_work.is_move = 1;
        AppMain.gmBoss3EffAfterburnerRequestCreate( body_work );
        obs_OBJECT_WORK.disp_flag &= 4294967294U;
        AppMain.gmBoss3BodyInitTurn( body_work, AppMain.GMD_BOSS3_ANGLE_RIGHT, 60f, 1 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateStartUpdateEnd );
    }

    // Token: 0x060010E4 RID: 4324 RVA: 0x00094248 File Offset: 0x00092448
    private static void gmBoss3BodyStateStartUpdateEnd( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss3BodyUpdateTurn( body_work );
        if ( AppMain.ObjViewOutCheck( obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 64, 0, 0, 0, 0 ) == 0 )
        {
            return;
        }
        AppMain.GmGmkCamScrLimitRelease( 4 );
        AppMain.gmBoss3BodyChangeState( body_work, 2 );
    }

    // Token: 0x060010E5 RID: 4325 RVA: 0x00094295 File Offset: 0x00092495
    private static void gmBoss3BodyStateChaseMoveEnter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateChaseMoveUpdate );
        AppMain.gmBoss3EffAfterburnerRequestCreate( body_work );
    }

    // Token: 0x060010E6 RID: 4326 RVA: 0x000942B6 File Offset: 0x000924B6
    private static void gmBoss3BodyStateChaseMoveLeave( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010E7 RID: 4327 RVA: 0x000942C0 File Offset: 0x000924C0
    private static void gmBoss3BodyStateChaseMoveUpdate( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.gmBoss3BodyChaseCheckTurn( body_work ) != 0 )
        {
            short dest_angle;
            int flag_positive;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                dest_angle = AppMain.GMD_BOSS3_ANGLE_RIGHT;
                flag_positive = 1;
            }
            else
            {
                obs_OBJECT_WORK.disp_flag |= 1U;
                dest_angle = AppMain.GMD_BOSS3_ANGLE_LEFT;
                flag_positive = 0;
            }
            AppMain.gmBoss3BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
        }
        AppMain.gmBoss3BodyUpdateTurn( body_work );
        if ( obs_OBJECT_WORK.user_flag != 0U )
        {
            AppMain.gmBoss3BodyChangeState( body_work, 3 );
        }
    }

    // Token: 0x060010E8 RID: 4328 RVA: 0x00094338 File Offset: 0x00092538
    private static void gmBoss3BodyStatePreBattleEnter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStatePreBattleUpdateStart );
        obs_OBJECT_WORK.user_timer = 120;
        obs_OBJECT_WORK.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjObjectMove );
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010E9 RID: 4329 RVA: 0x00094385 File Offset: 0x00092585
    private static void gmBoss3BodyStatePreBattleLeave( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010EA RID: 4330 RVA: 0x00094390 File Offset: 0x00092590
    private static void gmBoss3BodyStatePreBattleUpdateStart( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.ObjViewOutCheck( obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0 ) != 0 )
        {
            return;
        }
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        if ( AppMain._am_draw_video.wide_screen )
        {
            AppMain.GmCameraScaleSet( 0.85f, 0.0024999997f );
            AppMain.GmMapSetDrawMarginMag();
        }
        obs_OBJECT_WORK.disp_flag |= 1U;
        AppMain.gmBoss3BodyInitTurn( body_work, AppMain.GMD_BOSS3_ANGLE_LEFT, 60f, 0 );
        AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStatePreBattleUpdateTurn );
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) == 0 )
        {
            AppMain.GmSoundChangeAngryBossBGM();
        }
    }

    // Token: 0x060010EB RID: 4331 RVA: 0x00094444 File Offset: 0x00092644
    private static void gmBoss3BodyStatePreBattleUpdateTurn( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        float num = AppMain.gmBoss3BodyUpdateTurn(body_work);
        if ( num > 0f )
        {
            return;
        }
        AppMain.gmBoss3BodySetActionAllParts( body_work, 2 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStatePreBattleUpdateLaugh );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK != null )
        {
            AppMain.GmGmkBoss3PillarWallChangeModeActive( obs_OBJECT_WORK );
        }
        AppMain.GmMapSetMapDrawSize( 5 );
        AppMain.GmWaterSurfaceSetFlagDraw( false );
    }

    // Token: 0x060010EC RID: 4332 RVA: 0x00094498 File Offset: 0x00092698
    private static void gmBoss3BodyStatePreBattleUpdateLaugh( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK != null )
        {
            AppMain.GmGmkBoss3PillarWallClearFlagNoPressDie( obs_OBJECT_WORK );
        }
        AppMain.gmBoss3BodyChangeState( body_work, 4 );
        AppMain.GmCameraScaleSet( 1f, 0.0024999997f );
        AppMain.GmMapSetDrawMarginNormal();
    }

    // Token: 0x060010ED RID: 4333 RVA: 0x000944E0 File Offset: 0x000926E0
    private static void gmBoss3BodyStateBattleEnter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
        int num = AppMain.g_gm_main_system.map_fcol.right - AppMain.g_gm_main_system.map_fcol.left;
        int x = (AppMain.g_gm_main_system.map_fcol.left + num / 2) * 4096;
        AppMain.VecFx32 dest_pos = new AppMain.VecFx32(x, obs_OBJECT_WORK.pos.y, obs_OBJECT_WORK.pos.z);
        float frame = AppMain.gmBoss3BodyCalcMoveXNormalFrame(body_work, dest_pos.x, 4096);
        AppMain.gmBoss3BodyInitMoveNormal( body_work, dest_pos, frame );
        if ( AppMain.gmBoss3BodyBattleCheckTurn( body_work ) != 0 )
        {
            short dest_angle;
            int flag_positive;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                dest_angle = AppMain.GMD_BOSS3_ANGLE_RIGHT;
                flag_positive = 1;
            }
            else
            {
                obs_OBJECT_WORK.disp_flag |= 1U;
                dest_angle = AppMain.GMD_BOSS3_ANGLE_LEFT;
                flag_positive = 0;
            }
            AppMain.gmBoss3BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateMoveCenter );
        AppMain.gmBoss3EffAfterburnerRequestCreate( body_work );
    }

    // Token: 0x060010EE RID: 4334 RVA: 0x000945DC File Offset: 0x000927DC
    private static void gmBoss3BodyStateBattleLeave( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010EF RID: 4335 RVA: 0x000945E4 File Offset: 0x000927E4
    private static void gmBoss3BodyStateBattleUpdateMoveCenter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num = AppMain.gmBoss3BodyUpdateTurn(body_work);
        float num2 = AppMain.gmBoss3BodyUpdateMoveNormal(body_work);
        if ( num > 0f || num2 > 0f )
        {
            return;
        }
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss3BodySetActionAllParts( body_work, 3 );
        }
        else
        {
            AppMain.gmBoss3BodySetActionAllParts( body_work, 4 );
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateSearch );
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010F0 RID: 4336 RVA: 0x0009464C File Offset: 0x0009284C
    private static void gmBoss3BodyStateBattleUpdateSearch( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) == 0 )
        {
            return;
        }
        body_work.pattern_no = AppMain.gmBoss3BodyBattleCalcPattern( body_work );
        if ( AppMain.gmBoss3BodyBattleInitMovePattern( body_work, body_work.pattern_no, 0, 4096 ) != 0 )
        {
            if ( AppMain.gmBoss3BodyBattleCheckTurn( body_work ) != 0 )
            {
                short dest_angle;
                int flag_positive;
                if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
                {
                    obs_OBJECT_WORK.disp_flag &= 4294967294U;
                    dest_angle = AppMain.GMD_BOSS3_ANGLE_RIGHT;
                    flag_positive = 1;
                }
                else
                {
                    obs_OBJECT_WORK.disp_flag |= 1U;
                    dest_angle = AppMain.GMD_BOSS3_ANGLE_LEFT;
                    flag_positive = 0;
                }
                AppMain.gmBoss3BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
            }
            body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateMoveFirst );
            AppMain.gmBoss3EffAfterburnerRequestCreate( body_work );
            AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
            return;
        }
        AppMain.gmBoss3BodySetActionAllParts( body_work, 5 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateSign );
    }

    // Token: 0x060010F1 RID: 4337 RVA: 0x00094710 File Offset: 0x00092910
    private static void gmBoss3BodyStateBattleUpdateMoveFirst( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        float num = AppMain.gmBoss3BodyUpdateTurn(body_work);
        float num2 = AppMain.gmBoss3BodyUpdateMoveNormal(body_work);
        if ( num > 0f || num2 > 0f )
        {
            return;
        }
        AppMain.gmBoss3BodySetActionAllParts( body_work, 5 );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateSign );
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010F2 RID: 4338 RVA: 0x0009475C File Offset: 0x0009295C
    private static void gmBoss3BodyStateBattleUpdateSign( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) == 0 )
        {
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK2 != null )
        {
            AppMain.GmGmkBoss3PillarChangeModeActive( obs_OBJECT_WORK2, body_work.pattern_no );
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateWaitPillar );
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            obs_OBJECT_WORK.user_timer = 150;
        }
        else
        {
            obs_OBJECT_WORK.user_timer = 240;
        }
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss3BodySetActionAllParts( body_work, 6 );
            return;
        }
        AppMain.gmBoss3BodySetActionAllParts( body_work, 7 );
    }

    // Token: 0x060010F3 RID: 4339 RVA: 0x000947DC File Offset: 0x000929DC
    private static void gmBoss3BodyStateBattleUpdateWaitPillar( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        int move_speed = 4096;
        AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK );
        if ( AppMain.gmBoss3BodyBattleInitMovePattern( body_work, body_work.pattern_no, 1, move_speed ) != 0 )
        {
            if ( AppMain.gmBoss3BodyBattleCheckTurn( body_work ) != 0 )
            {
                short dest_angle;
                int flag_positive;
                if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
                {
                    obs_OBJECT_WORK.disp_flag &= 4294967294U;
                    dest_angle = AppMain.GMD_BOSS3_ANGLE_RIGHT;
                    flag_positive = 1;
                }
                else
                {
                    obs_OBJECT_WORK.disp_flag |= 1U;
                    dest_angle = AppMain.GMD_BOSS3_ANGLE_LEFT;
                    flag_positive = 0;
                }
                AppMain.gmBoss3BodyInitTurn( body_work, dest_angle, 60f, flag_positive );
            }
            AppMain.gmBoss3EffAfterburnerRequestCreate( body_work );
            body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateMoveSecond );
            AppMain.gmBoss3BodySetActionAllParts( body_work, 1 );
            return;
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateWaitActive );
        obs_OBJECT_WORK.user_timer = AppMain.GmGmkBoss3PillarGetActiveTime( body_work.pattern_no ) - 240 + 120;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss3BodySetActionAllParts( body_work, 6 );
            return;
        }
        AppMain.gmBoss3BodySetActionAllParts( body_work, 7 );
    }

    // Token: 0x060010F4 RID: 4340 RVA: 0x000948D8 File Offset: 0x00092AD8
    private static void gmBoss3BodyStateBattleUpdateMoveSecond( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        float num = AppMain.gmBoss3BodyUpdateTurn(body_work);
        float num2 = AppMain.gmBoss3BodyUpdateMoveNormal(body_work);
        if ( num > 0f || num2 > 0f )
        {
            return;
        }
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss3BodySetActionAllParts( body_work, 6 );
        }
        else
        {
            AppMain.gmBoss3BodySetActionAllParts( body_work, 7 );
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateWaitActive );
        int num3 = 240;
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            num3 = 150;
        }
        obs_OBJECT_WORK.user_timer = AppMain.GmGmkBoss3PillarGetActiveTime( body_work.pattern_no ) - num3 - ( int )body_work.move_frame + 120;
        AppMain.gmBoss3EffAfterburnerRequestDelete( body_work );
    }

    // Token: 0x060010F5 RID: 4341 RVA: 0x00094970 File Offset: 0x00092B70
    private static void gmBoss3BodyStateBattleUpdateWaitActive( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateBattleUpdateWaitReturn );
        obs_OBJECT_WORK.user_timer = 30;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK2 != null )
        {
            AppMain.GmGmkBoss3PillarChangeModeReturn( obs_OBJECT_WORK2 );
        }
    }

    // Token: 0x060010F6 RID: 4342 RVA: 0x000949C8 File Offset: 0x00092BC8
    private static void gmBoss3BodyStateBattleUpdateWaitReturn( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        AppMain.gmBoss3BodyChangeState( body_work, 4 );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK2 != null )
        {
            AppMain.GmGmkBoss3PillarChangeModeDelete( obs_OBJECT_WORK2 );
        }
    }

    // Token: 0x060010F7 RID: 4343 RVA: 0x00094A0C File Offset: 0x00092C0C
    private static void gmBoss3BodyStateDefeatEnter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.disp_flag |= 16U;
        body_work.ene_3d.ene_com.enemy_flag |= 32768U;
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateDefeatUpdateStart );
        obs_OBJECT_WORK.user_timer = 40;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK2 != null )
        {
            AppMain.GmGmkBoss3PillarChangeModeReturn( obs_OBJECT_WORK2 );
        }
        AppMain.GmSoundChangeWinBossBGM();
    }

    // Token: 0x060010F8 RID: 4344 RVA: 0x00094A90 File Offset: 0x00092C90
    private static void gmBoss3BodyStateDefeatLeave( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.disp_flag &= 4294967279U;
        obs_OBJECT_WORK.flag &= 4294967293U;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK2 != null )
        {
            AppMain.GmGmkBoss3PillarChangeModeDelete( obs_OBJECT_WORK2 );
        }
    }

    // Token: 0x060010F9 RID: 4345 RVA: 0x00094AD4 File Offset: 0x00092CD4
    private static void gmBoss3BodyStateDefeatUpdateStart( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(body_work);
        AppMain.gmBoss3EffBombsInit( body_work.bomb_work, obs_OBJECT_WORK2, obs_OBJECT_WORK2.pos.x, obs_OBJECT_WORK2.pos.y, 327680, 327680, 10U, 30U );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateDefeatUpdateFall );
        obs_OBJECT_WORK.user_timer = 120;
    }

    // Token: 0x060010FA RID: 4346 RVA: 0x00094B54 File Offset: 0x00092D54
    private static void gmBoss3BodyStateDefeatUpdateFall( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            AppMain.gmBoss3EffBombsUpdate( body_work.bomb_work );
            return;
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateDefeatUpdateExplode );
    }

    // Token: 0x060010FB RID: 4347 RVA: 0x00094BA0 File Offset: 0x00092DA0
    private static void gmBoss3BodyStateDefeatUpdateExplode( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        body_work.flag |= 134217728U;
        AppMain.GmSoundPlaySE( "Boss0_03" );
        AppMain.GMM_PAD_VIB_MID_TIME( 120f );
        AppMain.GmBsCmnInitFlashScreen( body_work.flash_work, 4f, 5f, 30f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(obs_OBJECT_WORK2, 8);
        obs_OBJECT_WORK3.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateDefeatUpdateScatter );
        AppMain.GmPlayerAddScoreNoDisp( ( AppMain.GMS_PLAYER_WORK )AppMain.GmBsCmnGetPlayerObj(), 1000 );
        obs_OBJECT_WORK.user_timer = 40;
    }

    // Token: 0x060010FC RID: 4348 RVA: 0x00094C54 File Offset: 0x00092E54
    private static void gmBoss3BodyStateDefeatUpdateScatter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GmBsCmnUpdateFlashScreen( body_work.flash_work );
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        AppMain.gmBoss3ChangeTextureBurnt( obs_OBJECT_WORK );
        body_work.flag |= 16777216U;
        AppMain.gmBoss3EffAfterburnerSmokeInit( body_work );
        AppMain.gmBoss3EffBodySmokeInit( body_work );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateDefeatUpdateEnd );
        obs_OBJECT_WORK.user_timer = 120;
    }

    // Token: 0x060010FD RID: 4349 RVA: 0x00094CCC File Offset: 0x00092ECC
    private static void gmBoss3BodyStateDefeatUpdateEnd( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        if ( obs_OBJECT_WORK.user_timer > 0 )
        {
            obs_OBJECT_WORK.user_timer--;
            return;
        }
        AppMain.gmBoss3BodyChangeState( body_work, 6 );
    }

    // Token: 0x060010FE RID: 4350 RVA: 0x00094D00 File Offset: 0x00092F00
    private static void gmBoss3BodyStateEscapeEnter( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.spd.x = 0;
        obs_OBJECT_WORK.spd.y = 0;
        obs_OBJECT_WORK.spd_add.x = 327;
        obs_OBJECT_WORK.spd_add.y = 40;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967294U;
            AppMain.gmBoss3BodyInitTurn( body_work, AppMain.GMD_BOSS3_ANGLE_RIGHT, 60f, 1 );
        }
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.move_flag |= 4352U;
        AppMain.gmBoss3BodySetDirectionNormal( body_work );
        AppMain.gmBoss3BodySetActionAllParts( body_work, 8, 1 );
        body_work.flag |= 8388608U;
        AppMain.GmMapSetMapDrawSize( 1 );
        if ( AppMain.GmBsCmnIsFinalZoneType( obs_OBJECT_WORK ) != 0 )
        {
            body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateEscapeUpdateFinalZone );
            return;
        }
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateEscapeUpdateScrollLock );
    }

    // Token: 0x060010FF RID: 4351 RVA: 0x00094DE8 File Offset: 0x00092FE8
    private static void gmBoss3BodyStateEscapeLeave( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        obs_OBJECT_WORK.flag &= 4294967293U;
    }

    // Token: 0x06001100 RID: 4352 RVA: 0x00094E0C File Offset: 0x0009300C
    private static void gmBoss3BodyStateEscapeUpdateScrollLock( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3BodyEscapeAddjustSpeed( body_work );
        float num = AppMain.gmBoss3BodyUpdateTurn(body_work);
        if ( num > 0f )
        {
            return;
        }
        AppMain.GmGmkCamScrLimitRelease( 4 );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmBoss3BodyBattleSearchPillar();
        if ( obs_OBJECT_WORK != null )
        {
            AppMain.GmGmkBoss3PillarWallChangeModeReturn( obs_OBJECT_WORK );
        }
        AppMain.GmEfctBossCmnEsCreate( AppMain.GMM_BS_OBJ( body_work ), 1U );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateEscapeUpdateWaitScreenOut );
    }

    // Token: 0x06001101 RID: 4353 RVA: 0x00094E64 File Offset: 0x00093064
    private static void gmBoss3BodyStateEscapeUpdateWaitScreenOut( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3BodyEscapeAddjustSpeed( body_work );
        if ( AppMain.gmBoss3BodyEscapeCheckScreenOut( body_work ) != 0 )
        {
            AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(body_work);
            AppMain.GMS_BOSS3_MGR_WORK gms_BOSS3_MGR_WORK = AppMain.gmBoss3MgrGetMgrWork(obj_work_parts);
            gms_BOSS3_MGR_WORK.flag |= 2U;
            body_work.proc_update = null;
        }
    }

    // Token: 0x06001102 RID: 4354 RVA: 0x00094EA4 File Offset: 0x000930A4
    private static void gmBoss3BodyStateEscapeUpdateFinalZone( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.gmBoss3BodyEscapeAddjustSpeed( body_work );
        float num = AppMain.gmBoss3BodyUpdateTurn(body_work);
        if ( num > 0f )
        {
            return;
        }
        AppMain.GmEfctBossCmnEsCreate( AppMain.GMM_BS_OBJ( body_work ), 1U );
        body_work.proc_update = new AppMain.GMF_BOSS3_BODY_STATE_FUNC( AppMain.gmBoss3BodyStateEscapeUpdateWaitScreenOut );
    }

    // Token: 0x06001103 RID: 4355 RVA: 0x00094EE8 File Offset: 0x000930E8
    private static void gmBoss3BodyMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obj_work;
        AppMain.GMS_BOSS3_MGR_WORK mgr_work = AppMain.gmBoss3MgrGetMgrWork(obj_work);
        if ( AppMain.gmBoss3MgrCheckSetupComplete( mgr_work ) == 0 )
        {
            return;
        }
        AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, gms_BOSS3_BODY_WORK.bmcb_mgr );
        AppMain.GmBsCmnCreateSNMWork( gms_BOSS3_BODY_WORK.snm_work, obj_work.obj_3d._object, 1 );
        AppMain.GmBsCmnAppendBossMotionCallback( gms_BOSS3_BODY_WORK.bmcb_mgr, gms_BOSS3_BODY_WORK.snm_work.bmcb_link );
        int num = 0;
        while ( 1 > num )
        {
            gms_BOSS3_BODY_WORK.snm_reg_id[num] = AppMain.GmBsCmnRegisterSNMNode( gms_BOSS3_BODY_WORK.snm_work, AppMain.g_boss3_node_index_list[num] );
            num++;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3BodyMainFunc );
        AppMain.gmBoss3BodyChangeState( gms_BOSS3_BODY_WORK, 1 );
    }

    // Token: 0x06001104 RID: 4356 RVA: 0x00094F84 File Offset: 0x00093184
    private static void gmBoss3BodyMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obj_work;
        AppMain.gmBoss3BodyUpdateNoHitTime( gms_BOSS3_BODY_WORK );
        AppMain.gmBoss3BodyUpdateInvincibleTime( gms_BOSS3_BODY_WORK );
        if ( gms_BOSS3_BODY_WORK.proc_update != null )
        {
            gms_BOSS3_BODY_WORK.proc_update( gms_BOSS3_BODY_WORK );
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 33554432U ) != 0U )
        {
            AppMain.gmBoss3EffAfterburnerInit( gms_BOSS3_BODY_WORK );
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 2147483648U ) != 0U )
        {
            gms_BOSS3_BODY_WORK.flag &= 1073741823U;
            AppMain.gmBoss3BodyChangeState( gms_BOSS3_BODY_WORK, 5 );
            return;
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 1073741824U ) != 0U )
        {
            gms_BOSS3_BODY_WORK.flag &= 3221225471U;
            gms_BOSS3_BODY_WORK.flag |= 536870912U;
            AppMain.GmBsCmnInitObject3DNNDamageFlicker( obj_work, gms_BOSS3_BODY_WORK.flk_work, 32f );
        }
        AppMain.GmBsCmnUpdateObject3DNNDamageFlicker( obj_work, gms_BOSS3_BODY_WORK.flk_work );
        AppMain.gmBoss3BodyUpdateDirection( gms_BOSS3_BODY_WORK );
    }

    // Token: 0x06001105 RID: 4357 RVA: 0x0009504A File Offset: 0x0009324A
    private static void gmBoss3EggChangeAction( AppMain.GMS_BOSS3_EGG_WORK egg_work, int action_id )
    {
        AppMain.gmBoss3EggChangeAction( egg_work, action_id, 0 );
    }

    // Token: 0x06001106 RID: 4358 RVA: 0x00095054 File Offset: 0x00093254
    private static void gmBoss3EggChangeAction( AppMain.GMS_BOSS3_EGG_WORK egg_work, int action_id, int force_change )
    {
        AppMain.GMS_BOSS3_PART_ACT_INFO gms_BOSS3_PART_ACT_INFO = AppMain.gm_boss3_egg_act_info_tbl[action_id];
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        if ( force_change == 0 && egg_work.egg_action_id == action_id && ( egg_work.flag & 1U ) != 0U )
        {
            return;
        }
        egg_work.egg_action_id = action_id;
        egg_work.flag |= 1U;
        if ( gms_BOSS3_PART_ACT_INFO.is_maintain != 0 )
        {
            if ( gms_BOSS3_PART_ACT_INFO.is_repeat != 0 )
            {
                obs_OBJECT_WORK.disp_flag |= 4U;
            }
        }
        else
        {
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS3_PART_ACT_INFO.mtn_id, ( int )gms_BOSS3_PART_ACT_INFO.is_repeat, gms_BOSS3_PART_ACT_INFO.is_blend );
        }
        obs_OBJECT_WORK.obj_3d.speed[0] = gms_BOSS3_PART_ACT_INFO.mtn_spd;
        obs_OBJECT_WORK.obj_3d.blend_spd = gms_BOSS3_PART_ACT_INFO.blend_spd;
    }

    // Token: 0x06001107 RID: 4359 RVA: 0x000950F8 File Offset: 0x000932F8
    private static void gmBoss3EggRevertAction( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_BS_OBJ(gms_BOSS3_BODY_WORK);
        egg_work.flag &= 4294967294U;
        AppMain.GMS_BOSS3_PART_ACT_INFO gms_BOSS3_PART_ACT_INFO = AppMain.gm_boss3_act_info_tbl[gms_BOSS3_BODY_WORK.action_id][1];
        AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS3_PART_ACT_INFO.mtn_id, ( int )gms_BOSS3_PART_ACT_INFO.is_repeat, 1 );
        obs_OBJECT_WORK.obj_3d.frame[0] = obs_OBJECT_WORK2.obj_3d.frame[0];
    }

    // Token: 0x06001108 RID: 4360 RVA: 0x0009516A File Offset: 0x0009336A
    private static void gmBoss3EggStateIdleInit( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        egg_work.proc_update = new AppMain.GMF_BOSS3_EGG_STATE_FUNC( AppMain.gmBoss3EggStateIdleUpdate );
    }

    // Token: 0x06001109 RID: 4361 RVA: 0x00095180 File Offset: 0x00093380
    private static void gmBoss3EggStateIdleUpdate( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS3_BODY_WORK.flag & 268435456U ) != 0U )
        {
            gms_BOSS3_BODY_WORK.flag &= 4026531839U;
            AppMain.gmBoss3EggStateLaughInit( egg_work );
        }
    }

    // Token: 0x0600110A RID: 4362 RVA: 0x000951C8 File Offset: 0x000933C8
    private static void gmBoss3EggStateLaughInit( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.OBS_OBJECT_WORK parent_obj = obs_OBJECT_WORK.parent_obj;
        if ( ( parent_obj.disp_flag & 1U ) != 0U )
        {
            AppMain.gmBoss3EggChangeAction( egg_work, 0 );
        }
        else
        {
            AppMain.gmBoss3EggChangeAction( egg_work, 1 );
        }
        egg_work.proc_update = new AppMain.GMF_BOSS3_EGG_STATE_FUNC( AppMain.gmBoss3EggStateLaughUpdate );
    }

    // Token: 0x0600110B RID: 4363 RVA: 0x00095210 File Offset: 0x00093410
    private static void gmBoss3EggStateLaughUpdate( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        AppMain.gmBoss3EggRevertAction( egg_work );
        AppMain.gmBoss3EggStateIdleInit( egg_work );
    }

    // Token: 0x0600110C RID: 4364 RVA: 0x00095239 File Offset: 0x00093439
    private static void gmBoss3EggStateDamageInit( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.gmBoss3EggChangeAction( egg_work, 2 );
        AppMain.gmBoss3EffSweatInit( egg_work );
        egg_work.proc_update = new AppMain.GMF_BOSS3_EGG_STATE_FUNC( AppMain.gmBoss3EggStateDamageUpdate );
    }

    // Token: 0x0600110D RID: 4365 RVA: 0x0009525C File Offset: 0x0009345C
    private static void gmBoss3EggStateDamageUpdate( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) == 0 )
        {
            return;
        }
        egg_work.flag &= 4294967293U;
        AppMain.gmBoss3EggRevertAction( egg_work );
        AppMain.gmBoss3EggStateIdleInit( egg_work );
    }

    // Token: 0x0600110E RID: 4366 RVA: 0x00095294 File Offset: 0x00093494
    private static void gmBoss3EggStateEscapeInit( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        if ( ( egg_work.flag & 2U ) == 0U )
        {
            AppMain.gmBoss3EffSweatInit( egg_work );
        }
        egg_work.proc_update = new AppMain.GMF_BOSS3_EGG_STATE_FUNC( AppMain.gmBoss3EggStateEscapeUpdate );
    }

    // Token: 0x0600110F RID: 4367 RVA: 0x000952B8 File Offset: 0x000934B8
    private static void gmBoss3EggStateEscapeUpdate( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.UNREFERENCED_PARAMETER( egg_work );
    }

    // Token: 0x06001110 RID: 4368 RVA: 0x000952C0 File Offset: 0x000934C0
    private static void gmBoss3EggmanMainFuncWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK obj = (AppMain.GMS_BOSS3_BODY_WORK)obj_work.parent_obj;
        AppMain.OBS_OBJECT_WORK obj_work_parts = AppMain.GMM_BS_OBJ(obj);
        AppMain.GMS_BOSS3_MGR_WORK mgr_work = AppMain.gmBoss3MgrGetMgrWork(obj_work_parts);
        if ( AppMain.gmBoss3MgrCheckSetupComplete( mgr_work ) == 0 )
        {
            return;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3EggmanMainFunc );
        AppMain.GMS_BOSS3_EGG_WORK egg_work = (AppMain.GMS_BOSS3_EGG_WORK)obj_work;
        AppMain.gmBoss3EggStateIdleInit( egg_work );
    }

    // Token: 0x06001111 RID: 4369 RVA: 0x00095310 File Offset: 0x00093510
    private static void gmBoss3EggmanMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS3_EGG_WORK gms_BOSS3_EGG_WORK = (AppMain.GMS_BOSS3_EGG_WORK)obj_work;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, gms_BOSS3_BODY_WORK.snm_work, gms_BOSS3_BODY_WORK.snm_reg_id[0], 1 );
        if ( gms_BOSS3_EGG_WORK.proc_update != null )
        {
            gms_BOSS3_EGG_WORK.proc_update( gms_BOSS3_EGG_WORK );
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 8388608U ) != 0U )
        {
            gms_BOSS3_BODY_WORK.flag &= 4286578687U;
            AppMain.gmBoss3EggStateEscapeInit( gms_BOSS3_EGG_WORK );
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 536870912U ) != 0U )
        {
            gms_BOSS3_BODY_WORK.flag &= 3758096383U;
            AppMain.gmBoss3EggStateDamageInit( gms_BOSS3_EGG_WORK );
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 16777216U ) != 0U )
        {
            gms_BOSS3_BODY_WORK.flag &= 4278190079U;
            AppMain.gmBoss3ChangeTextureBurnt( obj_work );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_BOSS3_BODY_WORK);
        if ( ( obs_OBJECT_WORK.disp_flag & 16U ) != 0U )
        {
            obj_work.disp_flag |= 16U;
            return;
        }
        obj_work.disp_flag &= 4294967279U;
    }

    // Token: 0x06001112 RID: 4370 RVA: 0x000953FC File Offset: 0x000935FC
    private static void gmBoss3EffDamageInit( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK obj = AppMain.GmEfctBossCmnEsCreate(parent_obj, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(obj);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
    }

    // Token: 0x06001113 RID: 4371 RVA: 0x00095438 File Offset: 0x00093638
    private static void gmBoss3EffBombsInit( AppMain.GMS_BOSS3_EFF_BOMB_WORK bomb_work, AppMain.OBS_OBJECT_WORK parent_obj, int pos_x, int pos_y, int width, int height, uint interval_min, uint interval_max )
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

    // Token: 0x06001114 RID: 4372 RVA: 0x0009548C File Offset: 0x0009368C
    private static void gmBoss3EffBombsUpdate( AppMain.GMS_BOSS3_EFF_BOMB_WORK bomb_work )
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

    // Token: 0x06001115 RID: 4373 RVA: 0x00095584 File Offset: 0x00093784
    private static void gmBoss3EffAfterburnerRequestCreate( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        body_work.flag |= 33554432U;
    }

    // Token: 0x06001116 RID: 4374 RVA: 0x00095598 File Offset: 0x00093798
    private static void gmBoss3EffAfterburnerRequestDelete( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        body_work.flag &= 4294967293U;
        body_work.flag &= 4261412863U;
    }

    // Token: 0x06001117 RID: 4375 RVA: 0x000955BC File Offset: 0x000937BC
    private static void gmBoss3EffAfterburnerInit( AppMain.GMS_BOSS3_BODY_WORK body_work )
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
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3EffAfterburnerMainFunc );
    }

    // Token: 0x06001118 RID: 4376 RVA: 0x00095634 File Offset: 0x00093834
    private static void gmBoss3EffAfterburnerMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obj_work.parent_obj;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( gms_BOSS3_BODY_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS3_BODY_WORK.snm_work, gms_BOSS3_BODY_WORK.snm_reg_id[0], 1 );
    }

    // Token: 0x06001119 RID: 4377 RVA: 0x0009568C File Offset: 0x0009388C
    private static void gmBoss3EffAfterburnerSmokeInit( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 5U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3EffAfterburnerSmokeMainFunc );
    }

    // Token: 0x0600111A RID: 4378 RVA: 0x000956D8 File Offset: 0x000938D8
    private static void gmBoss3EffAfterburnerSmokeMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS3_BODY_WORK.snm_work, gms_BOSS3_BODY_WORK.snm_reg_id[0], 1 );
    }

    // Token: 0x0600111B RID: 4379 RVA: 0x00095708 File Offset: 0x00093908
    private static void gmBoss3EffBodySmokeInit( AppMain.GMS_BOSS3_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctBossCmnEsCreate(parent_obj, 3U);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, -32f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3EffBodySmokeMainFunc );
    }

    // Token: 0x0600111C RID: 4380 RVA: 0x00095754 File Offset: 0x00093954
    private static void gmBoss3EffBodySmokeMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_BODY_WORK gms_BOSS3_BODY_WORK = (AppMain.GMS_BOSS3_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS3_BODY_WORK.snm_work, gms_BOSS3_BODY_WORK.snm_reg_id[0], 1 );
    }

    // Token: 0x0600111D RID: 4381 RVA: 0x00095784 File Offset: 0x00093984
    private static void gmBoss3EffSweatInit( AppMain.GMS_BOSS3_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(parent_obj, 93);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 32f, 0f );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss3EffSweatMainFunc );
        egg_work.flag |= 2U;
    }

    // Token: 0x0600111E RID: 4382 RVA: 0x000957E0 File Offset: 0x000939E0
    private static void gmBoss3EffSweatMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS3_EGG_WORK gms_BOSS3_EGG_WORK = (AppMain.GMS_BOSS3_EGG_WORK)obj_work.parent_obj;
        if ( ( gms_BOSS3_EGG_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }
}
