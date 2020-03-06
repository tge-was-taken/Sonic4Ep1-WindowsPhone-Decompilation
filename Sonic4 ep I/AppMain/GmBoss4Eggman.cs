using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000155 RID: 341
    public class GMS_BOSS4_EGG_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020CC RID: 8396 RVA: 0x0013FB16 File Offset: 0x0013DD16
        public GMS_BOSS4_EGG_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060020CD RID: 8397 RVA: 0x0013FB40 File Offset: 0x0013DD40
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x060020CE RID: 8398 RVA: 0x0013FB52 File Offset: 0x0013DD52
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS4_EGG_WORK work )
        {
            return work.ene_3d.ene_com.obj_work;
        }

        // Token: 0x060020CF RID: 8399 RVA: 0x0013FB64 File Offset: 0x0013DD64
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_BOSS4_EGG_WORK work )
        {
            return work.ene_3d;
        }

        // Token: 0x04004DAB RID: 19883
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04004DAC RID: 19884
        public uint flag;

        // Token: 0x04004DAD RID: 19885
        public int egg_act_id;

        // Token: 0x04004DAE RID: 19886
        public readonly AppMain.GMS_BOSS4_DIRECTION dir_work = new AppMain.GMS_BOSS4_DIRECTION();

        // Token: 0x04004DAF RID: 19887
        public readonly AppMain.GMS_BOSS4_NODE_MATRIX node_work = new AppMain.GMS_BOSS4_NODE_MATRIX();

        // Token: 0x04004DB0 RID: 19888
        public AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK proc_update;
    }

    // Token: 0x060005DA RID: 1498 RVA: 0x0003427D File Offset: 0x0003247D
    private static AppMain.OBS_OBJECT_WORK GMM_BOSS4_EGG_CREATE_WORK( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return AppMain.GmEnemyCreateWork( eve_rec, pos_x, pos_y, work_size, 5386, name );
    }

    // Token: 0x060005DB RID: 1499 RVA: 0x0003428F File Offset: 0x0003248F
    private static void GmBoss4EggmanBuild()
    {
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 731 ), 3, AppMain.GMD_BOSS4_ARC );
    }

    // Token: 0x060005DC RID: 1500 RVA: 0x000342A7 File Offset: 0x000324A7
    private static void GmBoss4EggmanFlush()
    {
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 731 ) );
    }

    // Token: 0x060005DD RID: 1501 RVA: 0x000342C0 File Offset: 0x000324C0
    private static AppMain.OBS_OBJECT_WORK GmBoss4EggInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BOSS4_EGG_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS4_EGG_WORK(), "Boss4_EGG");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        obs_OBJECT_WORK.move_flag |= 256U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 1 ), gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 731 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.125f;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EggWaitLoad );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_BOSS4_EGG_WORK.dir_work.direction = 0;
        AppMain.GmBoss4UtilInitTurnGently( gms_BOSS4_EGG_WORK.dir_work, 0, 1, false );
        AppMain.GmBoss4UtilUpdateTurnGently( gms_BOSS4_EGG_WORK.dir_work );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss4EggExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060005DE RID: 1502 RVA: 0x00034428 File Offset: 0x00032628
    private static void gmBoss4EggExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)p;
        AppMain.GmBoss4DecObjCreateCount();
        AppMain.GmBoss4UtilExitNodeMatrix( gms_BOSS4_EGG_WORK.node_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060005DF RID: 1503 RVA: 0x00034459 File Offset: 0x00032659
    private static void gmBoss4EggSetActionIndependent( AppMain.GMS_BOSS4_EGG_WORK egg_work, int act_id )
    {
        AppMain.gmBoss4EggSetActionIndependent( egg_work, act_id, false );
    }

    // Token: 0x060005E0 RID: 1504 RVA: 0x00034464 File Offset: 0x00032664
    private static void gmBoss4EggSetActionIndependent( AppMain.GMS_BOSS4_EGG_WORK egg_work, int act_id, bool force_change )
    {
        AppMain.GMS_BOSS4_PART_ACT_INFO gms_BOSS4_PART_ACT_INFO = AppMain.gm_boss4_egg_act_id_tbl[act_id];
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 2U ) != 0U )
        {
            return;
        }
        if ( !force_change && ( egg_work.flag & 1U ) != 0U && egg_work.egg_act_id == act_id )
        {
            return;
        }
        egg_work.egg_act_id = act_id;
        egg_work.flag |= 1U;
        if ( gms_BOSS4_PART_ACT_INFO.is_maintain == 0 )
        {
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )gms_BOSS4_PART_ACT_INFO.act_id, ( int )gms_BOSS4_PART_ACT_INFO.is_repeat, gms_BOSS4_PART_ACT_INFO.is_blend );
        }
        else if ( gms_BOSS4_PART_ACT_INFO.is_repeat != 0 )
        {
            AppMain.GMM_BS_OBJ( egg_work ).disp_flag |= 4U;
        }
        obs_OBJECT_WORK.obj_3d.speed[0] = gms_BOSS4_PART_ACT_INFO.mtn_spd;
        obs_OBJECT_WORK.obj_3d.blend_spd = gms_BOSS4_PART_ACT_INFO.blend_spd;
    }

    // Token: 0x060005E1 RID: 1505 RVA: 0x00034528 File Offset: 0x00032728
    private static void gmBoss4EggRevertActionIndependent( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.MTM_ASSERT( egg_work.flag & 1U );
        egg_work.flag &= 4294967294U;
        AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, ( int )AppMain.GmBoss4GetActInfo( gms_BOSS4_BODY_WORK.egg_revert_mtn_id, 1 ).act_id, ( int )AppMain.GmBoss4GetActInfo( gms_BOSS4_BODY_WORK.egg_revert_mtn_id, 1 ).is_repeat, 1 );
        obs_OBJECT_WORK.obj_3d.frame[0] = AppMain.GMM_BS_OBJ( gms_BOSS4_BODY_WORK ).obj_3d.frame[0];
    }

    // Token: 0x060005E2 RID: 1506 RVA: 0x000345AC File Offset: 0x000327AC
    private static void gmBoss4EggWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK work = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)obj_work;
        if ( ( AppMain.GMM_BOSS4_MGR( work ).flag & 1U ) != 0U )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EggMain );
            AppMain.gmBoss4EggProcIdleInit( gms_BOSS4_EGG_WORK );
            AppMain.GmBoss4UtilInitNodeMatrix( gms_BOSS4_EGG_WORK.node_work, obj_work, 4 );
        }
    }

    // Token: 0x060005E3 RID: 1507 RVA: 0x00034600 File Offset: 0x00032800
    private static void gmBoss4EggMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_BOSS4_BODY_WORK;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_BODY_WORK.node_work, 2);
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GmBoss4UtilGetNodeMatrix(gms_BOSS4_BODY_WORK.node_work, 2);
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnCopyMatrix( nns_MATRIX3, nns_MATRIX );
        nns_MATRIX3.M03 = nns_MATRIX.M03 - nns_MATRIX2.M03 + ( float )obs_OBJECT_WORK.pos.x / 4096f;
        AppMain.GmBoss4UtilSetMatrixNN( obj_work, nns_MATRIX3 );
        AppMain.GmBoss4UtilUpdateTurnGently( gms_BOSS4_EGG_WORK.dir_work );
        AppMain.GmBoss4UtilUpdateDirection( gms_BOSS4_EGG_WORK.dir_work, obj_work );
        if ( gms_BOSS4_EGG_WORK.proc_update != null )
        {
            gms_BOSS4_EGG_WORK.proc_update( gms_BOSS4_EGG_WORK );
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 8388608U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 4286578687U;
            AppMain.gmBoss4EggProcEscapeInit( gms_BOSS4_EGG_WORK );
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 2097152U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 4292870143U;
            AppMain.gmBoss4EggProcThrowInit( gms_BOSS4_EGG_WORK );
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 4194304U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 4290772991U;
            AppMain.gmBoss4EggProcThrowLeftInit( gms_BOSS4_EGG_WORK );
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 536870912U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 3758096383U;
            AppMain.gmBoss4EggProcDamageInit( gms_BOSS4_EGG_WORK );
        }
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 16777216U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 4278190079U;
            AppMain.gmBoss4SetPartTextureBurnt( obj_work );
        }
        if ( ( AppMain.GMM_BS_OBJ( gms_BOSS4_BODY_WORK ).disp_flag & 16U ) != 0U )
        {
            obj_work.disp_flag |= 16U;
        }
        else
        {
            obj_work.disp_flag &= 4294967279U;
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
    }

    // Token: 0x060005E4 RID: 1508 RVA: 0x000347E3 File Offset: 0x000329E3
    private static void gmBoss4EggProcIdleInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.gmBoss4EggProcIdleUpdateLoop );
    }

    // Token: 0x060005E5 RID: 1509 RVA: 0x000347F8 File Offset: 0x000329F8
    private static void gmBoss4EggProcIdleUpdateLoop( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS4_BODY_WORK.flag[0] & 268435456U ) != 0U )
        {
            gms_BOSS4_BODY_WORK.flag[0] &= 4026531839U;
            AppMain.gmBoss4EggProcLaughInit( egg_work );
        }
    }

    // Token: 0x060005E6 RID: 1510 RVA: 0x0003484C File Offset: 0x00032A4C
    private static void gmBoss4EggProcLaughInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)((AppMain.OBS_OBJECT_WORK)egg_work).parent_obj;
        if ( gms_BOSS4_BODY_WORK.dir.direction == 0 )
        {
            AppMain.gmBoss4EggSetActionIndependent( egg_work, 1 );
        }
        else
        {
            AppMain.gmBoss4EggSetActionIndependent( egg_work, 0 );
        }
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.gmBoss4EggProcLaughUpdateLoop );
    }

    // Token: 0x060005E7 RID: 1511 RVA: 0x0003489C File Offset: 0x00032A9C
    private static void gmBoss4EggProcLaughUpdateLoop( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss4EggRevertActionIndependent( egg_work );
            AppMain.gmBoss4EggProcIdleInit( egg_work );
        }
    }

    // Token: 0x060005E8 RID: 1512 RVA: 0x000348C4 File Offset: 0x00032AC4
    private static void gmBoss4EggProcThrowInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.gmBoss4EggSetActionIndependent( egg_work, 3 );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.gmBoss4EggProcThrowUpdateLoop );
    }

    // Token: 0x060005E9 RID: 1513 RVA: 0x000348DF File Offset: 0x00032ADF
    private static void gmBoss4EggProcThrowLeftInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.gmBoss4EggSetActionIndependent( egg_work, 4 );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.gmBoss4EggProcThrowUpdateLoop );
    }

    // Token: 0x060005EA RID: 1514 RVA: 0x000348FC File Offset: 0x00032AFC
    private static void gmBoss4EggProcThrowUpdateLoop( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.gmBoss4EggRevertActionIndependent( egg_work );
            AppMain.gmBoss4EggProcIdleInit( egg_work );
        }
    }

    // Token: 0x060005EB RID: 1515 RVA: 0x00034924 File Offset: 0x00032B24
    private static void gmBoss4EggProcDamageInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.gmBoss4EggSetActionIndependent( egg_work, 2 );
        AppMain.gmBoss4EffSweatInit( egg_work );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.gmBoss4EggProcDamageUpdateLoop );
    }

    // Token: 0x060005EC RID: 1516 RVA: 0x00034948 File Offset: 0x00032B48
    private static void gmBoss4EggProcDamageUpdateLoop( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            egg_work.flag &= 4294967293U;
            AppMain.gmBoss4EggRevertActionIndependent( egg_work );
            AppMain.gmBoss4EggProcIdleInit( egg_work );
        }
    }

    // Token: 0x060005ED RID: 1517 RVA: 0x0003497F File Offset: 0x00032B7F
    private static void gmBoss4EggProcEscapeInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        if ( ( egg_work.flag & 2U ) == 0U )
        {
            AppMain.gmBoss4EffSweatInit( egg_work );
        }
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.gmBoss4EggProcEscapeUpdateLoop );
    }

    // Token: 0x060005EE RID: 1518 RVA: 0x000349A3 File Offset: 0x00032BA3
    private static void gmBoss4EggProcEscapeUpdateLoop( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
    }

    // Token: 0x060005EF RID: 1519 RVA: 0x000349A8 File Offset: 0x00032BA8
    private static void gmBoss4EffSweatInit( AppMain.GMS_BOSS4_EGG_WORK egg_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(AppMain.GMM_BS_OBJ(egg_work), 93);
        AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 32f, 0f );
        AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffSweatProcMain );
        egg_work.flag |= 2U;
    }

    // Token: 0x060005F0 RID: 1520 RVA: 0x00034A00 File Offset: 0x00032C00
    private static void gmBoss4EffSweatProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_EGG_WORK gms_BOSS4_EGG_WORK = (AppMain.GMS_BOSS4_EGG_WORK)obj_work.parent_obj;
        AppMain.MTM_ASSERT( gms_BOSS4_EGG_WORK );
        if ( ( gms_BOSS4_EGG_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }
}