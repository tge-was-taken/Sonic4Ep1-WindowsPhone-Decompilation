using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001B1 RID: 433
    public class GMS_GMK_ROCK_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600220E RID: 8718 RVA: 0x001422B5 File Offset: 0x001404B5
        public GMS_GMK_ROCK_WORK()
        {
            this.enemy_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600220F RID: 8719 RVA: 0x001422C9 File Offset: 0x001404C9
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.enemy_work.ene_com.obj_work;
        }

        // Token: 0x04004FB5 RID: 20405
        public readonly AppMain.GMS_ENEMY_3D_WORK enemy_work;

        // Token: 0x04004FB6 RID: 20406
        public AppMain.GMS_EFFECT_3DES_WORK effect_work;

        // Token: 0x04004FB7 RID: 20407
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x04004FB8 RID: 20408
        public int vib_timer;
    }

    // Token: 0x02000265 RID: 613
    public class GMS_GMK_ROCK_CHASE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023F2 RID: 9202 RVA: 0x00149EB2 File Offset: 0x001480B2
        public GMS_GMK_ROCK_CHASE_WORK()
        {
            this.enemy_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023F3 RID: 9203 RVA: 0x00149EC6 File Offset: 0x001480C6
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.enemy_work.ene_com.obj_work;
        }

        // Token: 0x04005909 RID: 22793
        public readonly AppMain.GMS_ENEMY_3D_WORK enemy_work;

        // Token: 0x0400590A RID: 22794
        public AppMain.GMS_EFFECT_3DES_WORK effect_work;

        // Token: 0x0400590B RID: 22795
        public int target_bound;

        // Token: 0x0400590C RID: 22796
        public int current_bound;

        // Token: 0x0400590D RID: 22797
        public int length;

        // Token: 0x0400590E RID: 22798
        public int speed;

        // Token: 0x0400590F RID: 22799
        public ushort angle_z;

        // Token: 0x04005910 RID: 22800
        public ushort reserve;

        // Token: 0x04005911 RID: 22801
        public uint dir_type;

        // Token: 0x04005912 RID: 22802
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x04005913 RID: 22803
        public bool flag_vib;

        // Token: 0x04005914 RID: 22804
        public AppMain.GMS_ENEMY_3D_WORK hook_work;
    }

    // Token: 0x02000266 RID: 614
    public class GMS_GMK_ROCK_FALL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023F4 RID: 9204 RVA: 0x00149ED8 File Offset: 0x001480D8
        public GMS_GMK_ROCK_FALL_WORK()
        {
            this.enemy_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023F5 RID: 9205 RVA: 0x00149EEC File Offset: 0x001480EC
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.enemy_work.ene_com.obj_work;
        }

        // Token: 0x04005915 RID: 22805
        public readonly AppMain.GMS_ENEMY_3D_WORK enemy_work;

        // Token: 0x04005916 RID: 22806
        public AppMain.GMS_EFFECT_3DES_WORK effect_work;

        // Token: 0x04005917 RID: 22807
        public int wait_time;

        // Token: 0x04005918 RID: 22808
        public ushort roll;

        // Token: 0x04005919 RID: 22809
        public ushort roll_d;

        // Token: 0x0400591A RID: 22810
        public AppMain.GMS_ENEMY_3D_WORK hook_work;
    }

    // Token: 0x02000267 RID: 615
    public class GMS_GMK_ROCK_FALL_MGR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023F6 RID: 9206 RVA: 0x00149EFE File Offset: 0x001480FE
        public GMS_GMK_ROCK_FALL_MGR_WORK()
        {
            this.enemy_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023F7 RID: 9207 RVA: 0x00149F12 File Offset: 0x00148112
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.enemy_work.ene_com.obj_work;
        }

        // Token: 0x0400591B RID: 22811
        public readonly AppMain.GMS_ENEMY_3D_WORK enemy_work;

        // Token: 0x0400591C RID: 22812
        public int interval;

        // Token: 0x0400591D RID: 22813
        public AppMain.GMS_ENEMY_3D_WORK hook_work;
    }

    // Token: 0x06000FD9 RID: 4057 RVA: 0x0008A5AC File Offset: 0x000887AC
    private static AppMain.OBS_OBJECT_WORK GmGmkRockChaseManagerInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmGmkRockHookInit(eve_rec, pos_x, pos_y, type);
        AppMain.GMS_ENEMY_3D_WORK hook_work = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.OBS_OBJECT_WORK work = AppMain.GmEventMgrLocalEventBirth(307, pos_x, pos_y, eve_rec.flag, eve_rec.left, eve_rec.top, eve_rec.width, eve_rec.height, 0);
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)work;
        gms_GMK_ROCK_CHASE_WORK.hook_work = hook_work;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000FDA RID: 4058 RVA: 0x0008A60C File Offset: 0x0008880C
    private static AppMain.OBS_OBJECT_WORK GmGmkRockFallManagerInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_ROCK_FALL_MGR_WORK gms_GMK_ROCK_FALL_MGR_WORK = (AppMain.GMS_GMK_ROCK_FALL_MGR_WORK)AppMain.gmGmkRockLoadObjNoModel(eve_rec, pos_x, pos_y, type, () => new AppMain.GMS_GMK_ROCK_FALL_MGR_WORK());
        AppMain.OBS_OBJECT_WORK obj_work = gms_GMK_ROCK_FALL_MGR_WORK.enemy_work.ene_com.obj_work;
        AppMain.gmGmkRockManagerInit( obj_work );
        AppMain.gmGmkRockFallMgrSetInterval( gms_GMK_ROCK_FALL_MGR_WORK, ( int )( eve_rec.left * 60 ) );
        AppMain.gmGmkRockFallMgrSetUserTimer( obj_work, ( int )( eve_rec.left * 60 ) );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(306, obj_work.pos.x, obj_work.pos.y - (int)(eve_rec.top * 2) * 4096 + 262144, eve_rec.flag, eve_rec.left, eve_rec.top, eve_rec.width, eve_rec.height, 0);
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.parent_obj = obj_work;
        gms_GMK_ROCK_FALL_MGR_WORK.hook_work = ( AppMain.GMS_ENEMY_3D_WORK )obs_OBJECT_WORK;
        return obj_work;
    }

    // Token: 0x06000FDB RID: 4059 RVA: 0x0008A6FC File Offset: 0x000888FC
    private static AppMain.OBS_OBJECT_WORK GmGmkRockFallInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)AppMain.gmGmkRockLoadObj(eve_rec, pos_x, pos_y, type, () => new AppMain.GMS_GMK_ROCK_FALL_WORK());
        AppMain.OBS_OBJECT_WORK obj_work = gms_GMK_ROCK_FALL_WORK.enemy_work.ene_com.obj_work;
        AppMain.gmGmkRockFallInit( obj_work );
        if ( type != 0 )
        {
            gms_GMK_ROCK_FALL_WORK.wait_time = 30;
        }
        else
        {
            gms_GMK_ROCK_FALL_WORK.wait_time = 0;
        }
        return obj_work;
    }

    // Token: 0x06000FDC RID: 4060 RVA: 0x0008A764 File Offset: 0x00088964
    private static AppMain.OBS_OBJECT_WORK GmGmkRockHookInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkRockLoadObjHook(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkRockHookInit( obj_work );
        return obj_work;
    }

    // Token: 0x06000FDD RID: 4061 RVA: 0x0008A798 File Offset: 0x00088998
    private static AppMain.OBS_OBJECT_WORK GmGmkRockChaseInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)AppMain.gmGmkRockLoadObj(eve_rec, pos_x, pos_y, type, () => new AppMain.GMS_GMK_ROCK_CHASE_WORK());
        AppMain.OBS_OBJECT_WORK obj_work = gms_GMK_ROCK_CHASE_WORK.enemy_work.ene_com.obj_work;
        AppMain.gmGmkRockChaseInit( obj_work );
        AppMain.gmGmkRockChaseSetLength( gms_GMK_ROCK_CHASE_WORK, ( int )( eve_rec.left * 2 ) * 4096 );
        AppMain.gmGmkRockChaseSetSpeed( gms_GMK_ROCK_CHASE_WORK, ( int )( eve_rec.top * 2 ) * 4096 );
        return obj_work;
    }

    // Token: 0x06000FDE RID: 4062 RVA: 0x0008A811 File Offset: 0x00088A11
    public static void GmGmkRockBuild()
    {
        AppMain.g_gm_gmk_rock_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 816 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 817 ) ), 0U );
    }

    // Token: 0x06000FDF RID: 4063 RVA: 0x0008A83C File Offset: 0x00088A3C
    public static void GmGmkRockFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(816));
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_rock_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000FE0 RID: 4064 RVA: 0x0008A86C File Offset: 0x00088A6C
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkRockLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, work_size, "GMK_ROCK");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000FE1 RID: 4065 RVA: 0x0008A8C8 File Offset: 0x00088AC8
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkRockLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkRockLoadObjNoModel(eve_rec, pos_x, pos_y, type, work_size);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_rock_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000FE2 RID: 4066 RVA: 0x0008A930 File Offset: 0x00088B30
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkRockLoadObjHook( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int num = pos_y >> 17;
        int pos_y2 = num << 17;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkRockLoadObjNoModel(eve_rec, pos_x, pos_y2, type, () => new AppMain.GMS_ENEMY_3D_WORK());
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_rock_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, AppMain.ObjDataGet( 818 ), null, 0, null );
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000FE3 RID: 4067 RVA: 0x0008A9A3 File Offset: 0x00088BA3
    private static void gmGmkRockMoveFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjObjectMove( obj_work );
    }

    // Token: 0x06000FE4 RID: 4068 RVA: 0x0008A9AC File Offset: 0x00088BAC
    private static void gmGmkRockFallDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.VecU16 vecU = new AppMain.VecU16(obj_work.dir);
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obj_work;
        ushort roll = gms_GMK_ROCK_FALL_WORK.roll;
        obj_work.dir.y = roll;
        ushort z = (ushort)obj_work.user_work;
        obj_work.dir.z = z;
        obj_work.dir.z = ( ushort )( obj_work.dir.z + roll );
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.ObjDrawActionSummary( obj_work );
        obj_work.dir.Assign( vecU );
    }

    // Token: 0x06000FE5 RID: 4069 RVA: 0x0008AA20 File Offset: 0x00088C20
    private static void gmGmkRockChaseDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)obj_work;
        AppMain.VecU16 vecU = new AppMain.VecU16(obj_work.dir);
        ushort z = AppMain.gmGmkRockChaseGetAngleZ(gms_GMK_ROCK_CHASE_WORK);
        if ( obj_work.spd_m < 0 )
        {
            obj_work.dir.z = z;
        }
        else
        {
            obj_work.dir.z = z;
        }
        ushort x = (ushort)obj_work.user_work;
        obj_work.dir.x = x;
        obj_work.pos.y = obj_work.pos.y + gms_GMK_ROCK_CHASE_WORK.current_bound;
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.ObjDrawActionSummary( obj_work );
        obj_work.dir.Assign( vecU );
        obj_work.pos.y = obj_work.pos.y - gms_GMK_ROCK_CHASE_WORK.current_bound;
    }

    // Token: 0x06000FE6 RID: 4070 RVA: 0x0008AAC8 File Offset: 0x00088CC8
    private static void gmGmkRockChaseTcbDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_GMK_ROCK_CHASE_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_ROCK_CHASE_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_ROCK_CHASE_WORK.se_handle );
            gms_GMK_ROCK_CHASE_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000FE7 RID: 4071 RVA: 0x0008AB0C File Offset: 0x00088D0C
    private static void gmGmkRockWaitDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK obj_work = (AppMain.OBS_OBJECT_WORK)gms_GMK_ROCK_CHASE_WORK.hook_work;
        AppMain.gmGmkRockHookkChangeModeActive( obj_work );
        gms_GMK_ROCK_CHASE_WORK.hook_work = null;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(parent_obj, 2, 32);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = null;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.y = 204800;
        AppMain.gmGmkRockChaseChangeModeFall( parent_obj );
    }

    // Token: 0x06000FE8 RID: 4072 RVA: 0x0008AB98 File Offset: 0x00088D98
    private static void gmGmkRockSetRectActive( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, -40, -40, -500, 40, 40, 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 2, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 0, 0 );
        obs_RECT_WORK.ppDef = null;
    }

    // Token: 0x06000FE9 RID: 4073 RVA: 0x0008ABF8 File Offset: 0x00088DF8
    private static void gmGmkRockSetRectWait( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, -40, -40, -500, 40, 500, 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkRockWaitDefFunc );
    }

    // Token: 0x06000FEA RID: 4074 RVA: 0x0008AC68 File Offset: 0x00088E68
    private static void gmGmkRockChaseInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockSetRectWait( gms_ENEMY_3D_WORK );
        AppMain.ObjObjectFieldRectSet( obj_work, -28, -28, 28, 42 );
        obj_work.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.target_obj = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work;
        obj_work.pos.z = -131072;
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)obj_work;
        ushort angle_z = AppMain.mtMathRand();
        AppMain.gmGmkRockChaseSetAngleZ( gms_GMK_ROCK_CHASE_WORK, angle_z );
        obj_work.user_work = ( uint )AppMain.mtMathRand();
        gms_GMK_ROCK_CHASE_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        obj_work.ppFunc = null;
        obj_work.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockMoveFunc );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockChaseDrawFunc );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkRockChaseTcbDest ) );
    }

    // Token: 0x06000FEB RID: 4075 RVA: 0x0008AD3C File Offset: 0x00088F3C
    private static void gmGmkRockChaseChangeModeFall( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)obj_work;
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockSetRectActive( gimmick_work );
        obj_work.spd_m = 0;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        obj_work.dir.z = 0;
        obj_work.flag |= 16U;
        obj_work.move_flag |= 192U;
        obj_work.move_flag &= 4294443007U;
        if ( gms_GMK_ROCK_CHASE_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_ROCK_CHASE_WORK.se_handle );
        }
        if ( gms_GMK_ROCK_CHASE_WORK.flag_vib )
        {
            AppMain.GMM_PAD_VIB_STOP();
            gms_GMK_ROCK_CHASE_WORK.flag_vib = false;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockChaseMainFall );
    }

    // Token: 0x06000FEC RID: 4076 RVA: 0x0008ADF4 File Offset: 0x00088FF4
    private static void gmGmkRockChaseChangeModeChase( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)obj_work;
        obj_work.spd_m = 0;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        AppMain.gmGmkRockChaseSetDirType( gms_GMK_ROCK_CHASE_WORK, 0U );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockChaseMainChase );
        if ( gms_GMK_ROCK_CHASE_WORK.effect_work == null )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 2, 24);
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = null;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.y = 204800;
            gms_GMK_ROCK_CHASE_WORK.effect_work = gms_EFFECT_3DES_WORK;
        }
        AppMain.GmSoundPlaySE( "BigRock2", gms_GMK_ROCK_CHASE_WORK.se_handle );
    }

    // Token: 0x06000FED RID: 4077 RVA: 0x0008AEB0 File Offset: 0x000890B0
    private static void gmGmkRockChaseChangeModeEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)obj_work;
        if ( gms_GMK_ROCK_CHASE_WORK.flag_vib )
        {
            AppMain.GMM_PAD_VIB_STOP();
            gms_GMK_ROCK_CHASE_WORK.flag_vib = false;
        }
        obj_work.flag &= 4294967279U;
        obj_work.move_flag |= 256U;
        obj_work.ppFunc = null;
    }

    // Token: 0x06000FEE RID: 4078 RVA: 0x0008AF00 File Offset: 0x00089100
    private static void gmGmkRockChaseMainFall( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmSoundPlaySE( "BigRock1" );
            AppMain.GmCameraVibrationSet( 0, 12288, 0 );
            AppMain.gmGmkRockChaseChangeModeChase( obj_work );
            return;
        }
        AppMain.OBS_OBJECT_WORK obj_work2 = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].obj_work;
        if ( obj_work2.pos.y < obj_work.pos.y - 2097152 )
        {
            AppMain.gmGmkRockChaseChangeModeEnd( obj_work );
        }
    }

    // Token: 0x06000FEF RID: 4079 RVA: 0x0008AF6C File Offset: 0x0008916C
    private static void gmGmkRockChaseMainChase( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_CHASE_WORK gms_GMK_ROCK_CHASE_WORK = (AppMain.GMS_GMK_ROCK_CHASE_WORK)obj_work;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        int num = target_obj.pos.x - obj_work.pos.x;
        uint num2 = AppMain.gmGmkRockChaseGetDirType(gms_GMK_ROCK_CHASE_WORK);
        if ( num2 == 0U )
        {
            if ( ( int )obj_work.dir.z <= AppMain.NNM_DEGtoA16( 180f ) )
            {
                num2 = 1U;
            }
            else
            {
                num2 = 2U;
            }
            AppMain.gmGmkRockChaseSetDirType( gms_GMK_ROCK_CHASE_WORK, num2 );
        }
        int num3;
        int num4;
        if ( ( num2 == 1U && num < 0 ) || ( num2 == 2U && num >= 0 ) )
        {
            num3 = 768;
            num4 = 32768;
            if ( gms_GMK_ROCK_CHASE_WORK.flag_vib )
            {
                AppMain.GMM_PAD_VIB_STOP();
                gms_GMK_ROCK_CHASE_WORK.flag_vib = false;
            }
        }
        else
        {
            int num5 = AppMain.MTM_MATH_ABS(target_obj.spd_m);
            if ( num5 < AppMain.gmGmkRockChaseGetSpeed( gms_GMK_ROCK_CHASE_WORK ) )
            {
                num3 = 512;
                num4 = 65536;
            }
            else
            {
                int num6 = AppMain.MTM_MATH_ABS(num);
                int num7 = AppMain.gmGmkRockChaseGetLength(gms_GMK_ROCK_CHASE_WORK);
                int num8 = AppMain.FX_Mul(num7, 8192);
                if ( num8 < 1228800 )
                {
                    num8 = 1228800;
                }
                if ( num6 > num8 )
                {
                    num3 = 3840;
                    num4 = ( int )( ( long )num5 + 32768L );
                    if ( gms_GMK_ROCK_CHASE_WORK.flag_vib )
                    {
                        AppMain.GMM_PAD_VIB_STOP();
                        gms_GMK_ROCK_CHASE_WORK.flag_vib = false;
                    }
                }
                else if ( num6 > num7 )
                {
                    num3 = 768;
                    num4 = ( int )( ( long )num5 + 10240L );
                    if ( !gms_GMK_ROCK_CHASE_WORK.flag_vib )
                    {
                        AppMain.GMM_PAD_VIB_MID_NOEND();
                        gms_GMK_ROCK_CHASE_WORK.flag_vib = true;
                    }
                }
                else
                {
                    num3 = -768;
                    num4 = ( int )( ( long )num5 + -6144L );
                    if ( !gms_GMK_ROCK_CHASE_WORK.flag_vib )
                    {
                        AppMain.GMM_PAD_VIB_MID_NOEND();
                        gms_GMK_ROCK_CHASE_WORK.flag_vib = true;
                    }
                }
            }
        }
        if ( num2 == 1U )
        {
            obj_work.spd_m += num3;
            AppMain.gmGmkRockChaseAddAngleZ( gms_GMK_ROCK_CHASE_WORK, 1000 );
            if ( obj_work.spd_m > num4 )
            {
                obj_work.spd_m = num4;
            }
        }
        else
        {
            num3 = -num3;
            num4 = -num4;
            obj_work.spd_m += num3;
            AppMain.gmGmkRockChaseAddAngleZ( gms_GMK_ROCK_CHASE_WORK, -1000 );
            if ( obj_work.spd_m < num4 )
            {
                obj_work.spd_m = num4;
            }
        }
        if ( ( obj_work.move_flag & 1U ) == 0U )
        {
            AppMain.gmGmkRockChaseChangeModeFall( obj_work );
            return;
        }
        if ( gms_GMK_ROCK_CHASE_WORK.current_bound >= 0 )
        {
            gms_GMK_ROCK_CHASE_WORK.current_bound = 0;
            if ( AppMain.mtMathRand() % 10 == 0 )
            {
                int num9 = (int)(32 + AppMain.mtMathRand() % 16);
                gms_GMK_ROCK_CHASE_WORK.target_bound = -num9 * 4096;
                gms_GMK_ROCK_CHASE_WORK.current_bound -= 8192;
                if ( gms_GMK_ROCK_CHASE_WORK.se_handle != null )
                {
                    AppMain.GmSoundStopSE( gms_GMK_ROCK_CHASE_WORK.se_handle );
                    return;
                }
            }
        }
        else if ( gms_GMK_ROCK_CHASE_WORK.target_bound > gms_GMK_ROCK_CHASE_WORK.current_bound )
        {
            gms_GMK_ROCK_CHASE_WORK.target_bound = 0;
            gms_GMK_ROCK_CHASE_WORK.current_bound += 8192;
            if ( gms_GMK_ROCK_CHASE_WORK.current_bound >= 0 )
            {
                AppMain.GmSoundPlaySE( "BigRock1" );
                AppMain.GmSoundPlaySE( "BigRock2", gms_GMK_ROCK_CHASE_WORK.se_handle );
                AppMain.GmCameraVibrationSet( 0, 12288, 0 );
                return;
            }
        }
        else
        {
            gms_GMK_ROCK_CHASE_WORK.current_bound -= 8192;
        }
    }

    // Token: 0x06000FF0 RID: 4080 RVA: 0x0008B23A File Offset: 0x0008943A
    private static void gmGmkRockManagerInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 8448U;
        AppMain.gmGmkRockFallMgrSetUserTimer( obj_work, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockManagerMain );
    }

    // Token: 0x06000FF1 RID: 4081 RVA: 0x0008B268 File Offset: 0x00089468
    private static void gmGmkRockManagerMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_FALL_MGR_WORK gms_GMK_ROCK_FALL_MGR_WORK = (AppMain.GMS_GMK_ROCK_FALL_MGR_WORK)obj_work;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkRockFallMgrGetInterval(gms_GMK_ROCK_FALL_MGR_WORK);
        int num2 = AppMain.gmGmkRockFallMgrGetUserTimer(obj_work);
        if ( num2 >= num )
        {
            AppMain.gmGmkRockFallMgrSetUserTimer( obj_work, 0 );
            byte type = 0;
            if ( num >= 120 )
            {
                type = 1;
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(300, obj_work.pos.x, obj_work.pos.y - (int)(gms_ENEMY_3D_WORK.ene_com.eve_rec.top * 2) * 4096, gms_ENEMY_3D_WORK.ene_com.eve_rec.flag, gms_ENEMY_3D_WORK.ene_com.eve_rec.left, gms_ENEMY_3D_WORK.ene_com.eve_rec.top, gms_ENEMY_3D_WORK.ene_com.eve_rec.width, gms_ENEMY_3D_WORK.ene_com.eve_rec.height, type);
            obs_OBJECT_WORK.spd_fall = 336;
            obs_OBJECT_WORK.spd_fall_max = 32768;
            AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obs_OBJECT_WORK;
            gms_GMK_ROCK_FALL_WORK.hook_work = gms_GMK_ROCK_FALL_MGR_WORK.hook_work;
        }
        AppMain.gmGmkRockFallMgrAddUserTimer( obj_work, 1 );
    }

    // Token: 0x06000FF2 RID: 4082 RVA: 0x0008B36C File Offset: 0x0008956C
    private static void gmGmkRockFallInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockSetRectActive( gimmick_work );
        obj_work.move_flag |= 384U;
        obj_work.disp_flag |= 4194304U;
        obj_work.pos.z = -131072;
        obj_work.user_work = ( uint )AppMain.mtMathRand();
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obj_work;
        gms_GMK_ROCK_FALL_WORK.roll = AppMain.mtMathRand();
        gms_GMK_ROCK_FALL_WORK.roll_d = 128;
        if ( gms_GMK_ROCK_FALL_WORK.roll % 2 != 0 )
        {
            gms_GMK_ROCK_FALL_WORK.roll_d = ( ushort )-gms_GMK_ROCK_FALL_WORK.roll_d;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockFallMainStart );
        obj_work.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockMoveFunc );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockFallDrawFunc );
    }

    // Token: 0x06000FF3 RID: 4083 RVA: 0x0008B430 File Offset: 0x00089630
    private static void gmGmkRockFallMainStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_ROCK_FALL_WORK.hook_work;
        if ( obs_OBJECT_WORK.pos.y + 98304 > obj_work.pos.y )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 2, 17);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
        AppMain.GmSoundPlaySE( "BigRock4" );
        obj_work.pos.y = obs_OBJECT_WORK.pos.y + 98304;
        AppMain.GmCameraVibrationSet( 0, 4096, 0 );
        obj_work.move_flag &= 4294967167U;
        obj_work.spd.y = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockFallMainWait );
    }

    // Token: 0x06000FF4 RID: 4084 RVA: 0x0008B4F8 File Offset: 0x000896F8
    private static void gmGmkRockFallMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obj_work2 = (AppMain.OBS_OBJECT_WORK)gms_GMK_ROCK_FALL_WORK.hook_work;
        obj_work.user_timer++;
        if ( obj_work.user_timer < gms_GMK_ROCK_FALL_WORK.wait_time )
        {
            return;
        }
        obj_work.user_timer = 0;
        obj_work.move_flag |= 128U;
        AppMain.gmGmkRockHookkChangeModeActive( obj_work2 );
        gms_GMK_ROCK_FALL_WORK.hook_work = null;
        AppMain.GmSoundPlaySE( "BigRock5" );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockFallMainFallWaitEffect );
    }

    // Token: 0x06000FF5 RID: 4085 RVA: 0x0008B578 File Offset: 0x00089778
    private static void gmGmkRockFallMainFallWaitEffect( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obj_work;
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK2 = gms_GMK_ROCK_FALL_WORK;
        gms_GMK_ROCK_FALL_WORK2.roll += gms_GMK_ROCK_FALL_WORK.roll_d;
        obj_work.user_timer++;
        if ( obj_work.user_timer < 30 )
        {
            return;
        }
        obj_work.user_timer = 0;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 2, 32);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = null;
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        obj_work2.pos.y = obj_work2.pos.y - 262144;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.y = 204800;
        gms_GMK_ROCK_FALL_WORK.effect_work = gms_EFFECT_3DES_WORK;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockFallMainFall );
    }

    // Token: 0x06000FF6 RID: 4086 RVA: 0x0008B64C File Offset: 0x0008984C
    private static void gmGmkRockFallMainFall( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 128U;
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK = (AppMain.GMS_GMK_ROCK_FALL_WORK)obj_work;
        AppMain.GMS_GMK_ROCK_FALL_WORK gms_GMK_ROCK_FALL_WORK2 = gms_GMK_ROCK_FALL_WORK;
        gms_GMK_ROCK_FALL_WORK2.roll += gms_GMK_ROCK_FALL_WORK.roll_d;
    }

    // Token: 0x06000FF7 RID: 4087 RVA: 0x0008B686 File Offset: 0x00089886
    private static void gmGmkRockHookInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 256U;
        obj_work.disp_flag |= 4194304U;
        obj_work.pos.z = 0;
        AppMain.gmGmkRockHookChangeModeWait( obj_work );
    }

    // Token: 0x06000FF8 RID: 4088 RVA: 0x0008B6BE File Offset: 0x000898BE
    private static void gmGmkRockHookChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 0, 0 );
        obj_work.ppFunc = null;
    }

    // Token: 0x06000FF9 RID: 4089 RVA: 0x0008B6CF File Offset: 0x000898CF
    private static void gmGmkRockHookkChangeModeActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 1, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockHookMainActive );
    }

    // Token: 0x06000FFA RID: 4090 RVA: 0x0008B6EB File Offset: 0x000898EB
    private static void gmGmkRockHookMainActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.gmGmkRockHookChangeModeWait( obj_work );
        }
    }

    // Token: 0x06000FFB RID: 4091 RVA: 0x0008B6FD File Offset: 0x000898FD
    private static void gmGmkRockChaseSetLength( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work, int length )
    {
        rock_work.length = length;
    }

    // Token: 0x06000FFC RID: 4092 RVA: 0x0008B706 File Offset: 0x00089906
    private static int gmGmkRockChaseGetLength( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work )
    {
        return rock_work.length;
    }

    // Token: 0x06000FFD RID: 4093 RVA: 0x0008B70E File Offset: 0x0008990E
    private static void gmGmkRockChaseSetSpeed( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work, int speed )
    {
        rock_work.speed = speed;
    }

    // Token: 0x06000FFE RID: 4094 RVA: 0x0008B717 File Offset: 0x00089917
    private static int gmGmkRockChaseGetSpeed( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work )
    {
        return rock_work.speed;
    }

    // Token: 0x06000FFF RID: 4095 RVA: 0x0008B71F File Offset: 0x0008991F
    private static void gmGmkRockChaseSetAngleZ( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work, ushort angle_z )
    {
        rock_work.angle_z = angle_z;
    }

    // Token: 0x06001000 RID: 4096 RVA: 0x0008B728 File Offset: 0x00089928
    private static void gmGmkRockChaseAddAngleZ( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work, short angle_z )
    {
        rock_work.angle_z += ( ushort )angle_z;
    }

    // Token: 0x06001001 RID: 4097 RVA: 0x0008B739 File Offset: 0x00089939
    private static ushort gmGmkRockChaseGetAngleZ( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work )
    {
        return rock_work.angle_z;
    }

    // Token: 0x06001002 RID: 4098 RVA: 0x0008B741 File Offset: 0x00089941
    private static void gmGmkRockChaseSetDirType( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work, uint type )
    {
        rock_work.dir_type = type;
    }

    // Token: 0x06001003 RID: 4099 RVA: 0x0008B74A File Offset: 0x0008994A
    private static uint gmGmkRockChaseGetDirType( AppMain.GMS_GMK_ROCK_CHASE_WORK rock_work )
    {
        return rock_work.dir_type;
    }

    // Token: 0x06001004 RID: 4100 RVA: 0x0008B752 File Offset: 0x00089952
    private static void gmGmkRockFallMgrSetInterval( AppMain.GMS_GMK_ROCK_FALL_MGR_WORK mgr_work, int interval )
    {
        mgr_work.interval = interval;
    }

    // Token: 0x06001005 RID: 4101 RVA: 0x0008B75B File Offset: 0x0008995B
    private static int gmGmkRockFallMgrGetInterval( AppMain.GMS_GMK_ROCK_FALL_MGR_WORK mgr_work )
    {
        return mgr_work.interval;
    }

    // Token: 0x06001006 RID: 4102 RVA: 0x0008B763 File Offset: 0x00089963
    private static void gmGmkRockFallMgrSetUserTimer( AppMain.OBS_OBJECT_WORK obj_work, int count )
    {
        obj_work.user_timer = count;
    }

    // Token: 0x06001007 RID: 4103 RVA: 0x0008B76C File Offset: 0x0008996C
    private static void gmGmkRockFallMgrAddUserTimer( AppMain.OBS_OBJECT_WORK obj_work, int count )
    {
        obj_work.user_timer += count;
    }

    // Token: 0x06001008 RID: 4104 RVA: 0x0008B77C File Offset: 0x0008997C
    private static int gmGmkRockFallMgrGetUserTimer( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.user_timer;
    }
}