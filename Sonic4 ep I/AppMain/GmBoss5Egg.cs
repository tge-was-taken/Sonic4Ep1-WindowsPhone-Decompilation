using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001BF RID: 447
    public class GMS_BOSS5_EGG_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002228 RID: 8744 RVA: 0x00142487 File Offset: 0x00140687
        public GMS_BOSS5_EGG_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002229 RID: 8745 RVA: 0x0014249B File Offset: 0x0014069B
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005001 RID: 20481
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005002 RID: 20482
        public AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK proc_update;

        // Token: 0x04005003 RID: 20483
        public uint flag;

        // Token: 0x04005004 RID: 20484
        public uint wait_timer;

        // Token: 0x04005005 RID: 20485
        public int jump_dest_pos_x;
    }

    // Token: 0x0600096F RID: 2415 RVA: 0x000551D8 File Offset: 0x000533D8
    public static AppMain.OBS_OBJECT_WORK GmBoss5EggInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_EGG_WORK(), "BOSS5_EGG");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS5_EGG_WORK gms_BOSS5_EGG_WORK = (AppMain.GMS_BOSS5_EGG_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.pos.z = AppMain.GMD_BOSS5_BG_FARSIDE_POS_Z;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -16, -16, 16, 0 );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss5GetObject3dList()[2], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 746 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = AppMain.GMD_BOSS5_DEFAULT_BLEND_SPD;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag &= 4290772991U;
        obs_OBJECT_WORK.disp_flag &= 4294967294U;
        obs_OBJECT_WORK.move_flag |= 1152U;
        obs_OBJECT_WORK.move_flag &= 4294967039U;
        gms_BOSS5_EGG_WORK.ene_3d.ene_com.enemy_flag |= 32768U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5EggMain );
        AppMain.gmBoss5EggProcInit( gms_BOSS5_EGG_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000970 RID: 2416 RVA: 0x0005532C File Offset: 0x0005352C
    public static AppMain.GMS_BOSS5_EGG_WORK GmBoss5EggCreate( AppMain.GMS_BOSS5_BODY_WORK body_work, int pos_x, int pos_y )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(334, pos_x, pos_y, 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK.parent_obj = AppMain.GMM_BS_OBJ( body_work );
        return ( AppMain.GMS_BOSS5_EGG_WORK )obs_OBJECT_WORK;
    }

    // Token: 0x06000971 RID: 2417 RVA: 0x00055360 File Offset: 0x00053560
    public static void gmBoss5EggInitEscapeRun( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.x = AppMain.GmBsCmnGetPlayerObj().pos.x + ( ( int )AppMain.OBD_OBJ_CLIP_LCD_X << 12 );
    }

    // Token: 0x06000972 RID: 2418 RVA: 0x000553A0 File Offset: 0x000535A0
    public static void gmBoss5EggUpdateEscapeRun( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.ObjViewOutCheck( obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, AppMain.GMD_BOSS5_EGG_ESCAPE_RUN_VIEWOUT_OFST_LEFT, 0, AppMain.GMD_BOSS5_EGG_ESCAPE_RUN_VIEWOUT_OFST_RIGHT, 0 ) == 0 )
        {
            int num = obs_OBJECT_WORK.pos.x - AppMain.GmBsCmnGetPlayerObj().pos.x;
            int num2 = AppMain.FX_Div(AppMain.GMD_BOSS5_EGG_ESCAPE_RUN_DISTANCE_SLOWEST - num, AppMain.GMD_BOSS5_EGG_ESCAPE_RUN_DISTANCE_SLOWEST - AppMain.GMD_BOSS5_EGG_ESCAPE_RUN_DISTANCE_FASTEST);
            num2 = AppMain.MTM_MATH_CLIP( num2, 0, 4096 );
            obs_OBJECT_WORK.spd.x = AppMain.FX_Mul( num2, AppMain.GmBsCmnGetPlayerObj().spd_m ) + AppMain.FX_Mul( 4096 - num2, AppMain.GMD_BOSS5_EGG_ESCAPE_RUN_SLOWEST_SPD );
        }
    }

    // Token: 0x06000973 RID: 2419 RVA: 0x00055450 File Offset: 0x00053650
    public static void gmBoss5EggInitJump( AppMain.GMS_BOSS5_EGG_WORK egg_work, int dest_pos_x )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.VEC_Set( ref obs_OBJECT_WORK.spd_add, 0, 0, 0 );
        obs_OBJECT_WORK.spd.x = AppMain.GMD_BOSS5_EGG_JUMP_INIT_SPD_X;
        obs_OBJECT_WORK.spd.y = AppMain.GMD_BOSS5_EGG_JUMP_INIT_SPD_Y;
        obs_OBJECT_WORK.spd_add.y = -2 * AppMain.FX_Mul( AppMain.FX_Div( obs_OBJECT_WORK.spd.x, dest_pos_x - obs_OBJECT_WORK.pos.x ), obs_OBJECT_WORK.spd.y );
        egg_work.jump_dest_pos_x = dest_pos_x;
        obs_OBJECT_WORK.move_flag |= 272U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
    }

    // Token: 0x06000974 RID: 2420 RVA: 0x000554F8 File Offset: 0x000536F8
    public static int gmBoss5EggUpdateJump( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( obs_OBJECT_WORK.pos.x >= egg_work.jump_dest_pos_x )
        {
            obs_OBJECT_WORK.spd.x = 0;
        }
        if ( obs_OBJECT_WORK.pos.y > gms_BOSS5_BODY_WORK.ground_v_pos + AppMain.GMD_BOSS5_EGG_HIDE_HIGHT )
        {
            AppMain.GmBsCmnSetObjSpdZero( obs_OBJECT_WORK );
            return 1;
        }
        return 0;
    }

    // Token: 0x06000975 RID: 2421 RVA: 0x0005555C File Offset: 0x0005375C
    public static void gmBoss5EggGetBodyNodePos( AppMain.GMS_BOSS5_EGG_WORK egg_work, out AppMain.VecFx32 pos_out )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.body_snm_reg_id);
        pos_out = new AppMain.VecFx32( AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 ), -AppMain.FX_F32_TO_FX32( nns_MATRIX.M13 ), AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 ) );
    }

    // Token: 0x06000976 RID: 2422 RVA: 0x000555BC File Offset: 0x000537BC
    public static void gmBoss5EggMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_EGG_WORK gms_BOSS5_EGG_WORK = (AppMain.GMS_BOSS5_EGG_WORK)obj_work;
        if ( gms_BOSS5_EGG_WORK.proc_update != null )
        {
            gms_BOSS5_EGG_WORK.proc_update( gms_BOSS5_EGG_WORK );
        }
    }

    // Token: 0x06000977 RID: 2423 RVA: 0x000555E4 File Offset: 0x000537E4
    public static void gmBoss5EggProcInit( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GmBsCmnSetAction( obj_work, 0, 1, 0 );
        AppMain.GmBoss5EfctStartEggSweat( egg_work );
        egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.gmBoss5EggProcUpdateStandby );
    }

    // Token: 0x06000978 RID: 2424 RVA: 0x0005561C File Offset: 0x0005381C
    public static void gmBoss5EggProcUpdateStandby( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = ((AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj).mgr_work;
        if ( ( mgr_work.flag & 4194304U ) != 0U )
        {
            AppMain.gmBoss5EggInitEscapeRun( egg_work );
            egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.gmBoss5EggProcUpdateRun );
        }
    }

    // Token: 0x06000979 RID: 2425 RVA: 0x00055668 File Offset: 0x00053868
    public static void gmBoss5EggProcUpdateRun( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.VecFx32 vecFx;
        AppMain.gmBoss5EggGetBodyNodePos( egg_work, out vecFx );
        AppMain.gmBoss5EggUpdateEscapeRun( egg_work );
        if ( obs_OBJECT_WORK.pos.x >= vecFx.x + AppMain.GMD_BOSS5_EGG_JUMP_START_OFST_POS_X )
        {
            obs_OBJECT_WORK.spd.x = AppMain.GMD_BOSS5_EGG_JUMP_RUNUP_SPD_X;
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, 1, 0, 1 );
            egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.gmBoss5EggProcUpdateStartJump );
        }
    }

    // Token: 0x0600097A RID: 2426 RVA: 0x000556D0 File Offset: 0x000538D0
    public static void gmBoss5EggProcUpdateStartJump( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            AppMain.GMS_BOSS5_MGR_WORK mgr_work = ((AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj).mgr_work;
            mgr_work.flag |= 524288U;
            AppMain.GmBoss5EfctEndEggSweat( egg_work );
            AppMain.VecFx32 vecFx;
            AppMain.gmBoss5EggGetBodyNodePos( egg_work, out vecFx );
            AppMain.gmBoss5EggInitJump( egg_work, vecFx.x );
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, 2, 0, 0 );
            egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.gmBoss5EggProcUpdateJump );
        }
    }

    // Token: 0x0600097B RID: 2427 RVA: 0x00055748 File Offset: 0x00053948
    public static void gmBoss5EggProcUpdateJump( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.gmBoss5EggUpdateJump( egg_work );
        if ( obs_OBJECT_WORK.spd.y > 0 )
        {
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, 3, 0, 0 );
            egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.gmBoss5EggProcUpdateFall );
        }
    }

    // Token: 0x0600097C RID: 2428 RVA: 0x0005578C File Offset: 0x0005398C
    public static void gmBoss5EggProcUpdateFall( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        if ( AppMain.gmBoss5EggUpdateJump( egg_work ) != 0 )
        {
            AppMain.VecFx32 vecFx;
            AppMain.gmBoss5EggGetBodyNodePos( egg_work, out vecFx );
            obs_OBJECT_WORK.pos.Assign( vecFx );
            AppMain.GmBsCmnSetAction( obs_OBJECT_WORK, 4, 0, 0 );
            obs_OBJECT_WORK.disp_flag |= 1U;
            egg_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.gmBoss5EggProcUpdateAnger );
        }
    }

    // Token: 0x0600097D RID: 2429 RVA: 0x000557E8 File Offset: 0x000539E8
    public static void gmBoss5EggProcUpdateAnger( AppMain.GMS_BOSS5_EGG_WORK egg_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(egg_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        if ( AppMain.GmBsCmnIsActionEnd( obs_OBJECT_WORK ) != 0 )
        {
            gms_BOSS5_BODY_WORK.flag |= 16777216U;
            obs_OBJECT_WORK.flag |= 4U;
        }
    }
}
