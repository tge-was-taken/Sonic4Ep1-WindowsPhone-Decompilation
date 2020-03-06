using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000046 RID: 70
    public enum OBE_CAMERA_TYPE
    {
        // Token: 0x0400487E RID: 18558
        OBE_CAMERA_TYPE_TARGET_ROLL,
        // Token: 0x0400487F RID: 18559
        OBE_CAMERA_TYPE_TARGET_UP_TARGET,
        // Token: 0x04004880 RID: 18560
        OBE_CAMERA_TYPE_TARGET_UP_VEC,
        // Token: 0x04004881 RID: 18561
        OBE_CAMERA_TYPE_MAX
    }

    // Token: 0x02000048 RID: 72
    public class OBS_CAMERA : AppMain.IClearable
    {
        // Token: 0x06001DB8 RID: 7608 RVA: 0x00138770 File Offset: 0x00136970
        public void Clear()
        {
            this.camera_id = 0;
            this.target_obj = ( this.camup_obj = null );
            this.disp_pos.Clear();
            this.prev_disp_pos.Clear();
            this.pos.Clear();
            this.prev_pos.Clear();
            this.ofst.Clear();
            this.disp_ofst.Clear();
            this.target_ofst.Clear();
            this.play_ofst_max.Clear();
            this.allow.Clear();
            this.allow_limit.Clear();
            this.target_pos.Clear();
            this.camup_pos.Clear();
            this.spd.Clear();
            this.spd_add.Clear();
            this.spd_max.Clear();
            this.roll = 0;
            Array.Clear( this.roll_hist, 0, this.roll_hist.Length );
            this.roll_ptr = 0;
        }

        // Token: 0x04004882 RID: 18562
        public int camera_id;

        // Token: 0x04004883 RID: 18563
        public readonly AppMain.NNS_VECTOR disp_pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004884 RID: 18564
        public readonly AppMain.NNS_VECTOR prev_disp_pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004885 RID: 18565
        public readonly AppMain.NNS_VECTOR pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004886 RID: 18566
        public readonly AppMain.NNS_VECTOR prev_pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004887 RID: 18567
        public readonly AppMain.NNS_VECTOR ofst = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004888 RID: 18568
        public readonly AppMain.NNS_VECTOR disp_ofst = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004889 RID: 18569
        public readonly AppMain.NNS_VECTOR target_ofst = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400488A RID: 18570
        public readonly AppMain.NNS_VECTOR play_ofst_max = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400488B RID: 18571
        public readonly AppMain.NNS_VECTOR allow = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400488C RID: 18572
        public readonly AppMain.NNS_VECTOR allow_limit = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400488D RID: 18573
        public AppMain.OBS_OBJECT_WORK target_obj;

        // Token: 0x0400488E RID: 18574
        public readonly AppMain.NNS_VECTOR target_pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400488F RID: 18575
        public AppMain.OBS_OBJECT_WORK camup_obj;

        // Token: 0x04004890 RID: 18576
        public readonly AppMain.NNS_VECTOR camup_pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004891 RID: 18577
        public readonly AppMain.NNS_VECTOR spd = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004892 RID: 18578
        public readonly AppMain.NNS_VECTOR spd_add = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004893 RID: 18579
        public readonly AppMain.NNS_VECTOR spd_max = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004894 RID: 18580
        public int roll;

        // Token: 0x04004895 RID: 18581
        public readonly int[] roll_hist = new int[16];

        // Token: 0x04004896 RID: 18582
        public ushort roll_ptr;

        // Token: 0x04004897 RID: 18583
        public ushort shift;

        // Token: 0x04004898 RID: 18584
        public ushort index;

        // Token: 0x04004899 RID: 18585
        public readonly AppMain.NNS_VECTOR work = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400489A RID: 18586
        public uint command_state;

        // Token: 0x0400489B RID: 18587
        public AppMain.OBJF_CAMERA_USER_FUNC user_func;

        // Token: 0x0400489C RID: 18588
        public object user_work;

        // Token: 0x0400489D RID: 18589
        public readonly int[] limit = new int[6];

        // Token: 0x0400489E RID: 18590
        public uint flag;

        // Token: 0x0400489F RID: 18591
        public AppMain.OBE_CAMERA_TYPE camera_type;

        // Token: 0x040048A0 RID: 18592
        public readonly AppMain.NNS_MATRIX prj_pers_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x040048A1 RID: 18593
        public readonly AppMain.NNS_MATRIX prj_ortho_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x040048A2 RID: 18594
        public readonly AppMain.NNS_MATRIX view_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x040048A3 RID: 18595
        public int fovy;

        // Token: 0x040048A4 RID: 18596
        public readonly AppMain.NNS_VECTOR up_vec = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040048A5 RID: 18597
        public float scale;

        // Token: 0x040048A6 RID: 18598
        public float left;

        // Token: 0x040048A7 RID: 18599
        public float right;

        // Token: 0x040048A8 RID: 18600
        public float bottom;

        // Token: 0x040048A9 RID: 18601
        public float top;

        // Token: 0x040048AA RID: 18602
        public float znear;

        // Token: 0x040048AB RID: 18603
        public float zfar;

        // Token: 0x040048AC RID: 18604
        public float aspect;
    }

    // Token: 0x02000049 RID: 73
    public class OBS_CAMERA_SYS
    {
        // Token: 0x06001DBA RID: 7610 RVA: 0x00138964 File Offset: 0x00136B64
        public void Clear()
        {
            Array.Clear( this.obj_camera, 0, this.obj_camera.Length );
            this.camera_num = 0;
        }

        // Token: 0x040048AD RID: 18605
        public readonly AppMain.OBS_CAMERA[] obj_camera = new AppMain.OBS_CAMERA[8];

        // Token: 0x040048AE RID: 18606
        public int camera_num;
    }

    // Token: 0x0200004A RID: 74
    // (Invoke) Token: 0x06001DBD RID: 7613
    public delegate void OBJF_CAMERA_USER_FUNC( AppMain.OBS_CAMERA camera );

    // Token: 0x06000126 RID: 294 RVA: 0x0000CF64 File Offset: 0x0000B164
    private static int ObjCameraInit( int cam_id, AppMain.NNS_VECTOR pos, int group, ushort pause_level, int prio )
    {
        AppMain.OBS_CAMERA_SYS obs_CAMERA_SYS = new AppMain.OBS_CAMERA_SYS();
        if ( AppMain.obj_camera_tcb == null )
        {
            AppMain.obj_camera_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.objCameraMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.objCameraDest ), 0U, pause_level, ( uint )prio, group, () => new AppMain.OBS_CAMERA_SYS(), "objCamera" );
            obs_CAMERA_SYS = ( AppMain.OBS_CAMERA_SYS )AppMain.obj_camera_tcb.work;
            obs_CAMERA_SYS.Clear();
            AppMain.obj_camera_sys = obs_CAMERA_SYS;
        }
        else
        {
            obs_CAMERA_SYS = AppMain.obj_camera_sys;
        }
        if ( obs_CAMERA_SYS.camera_num >= 8 )
        {
            return -1;
        }
        int i;
        if ( cam_id < 0 )
        {
            for ( i = 0; i < 8; i++ )
            {
                if ( obs_CAMERA_SYS.obj_camera[i] == null )
                {
                    break;
                }
            }
        }
        else
        {
            if ( obs_CAMERA_SYS.obj_camera[cam_id] != null )
            {
                return -1;
            }
            i = cam_id;
        }
        if ( i >= 8 )
        {
            return -1;
        }
        if ( obs_CAMERA_SYS.obj_camera[i] != null )
        {
            return -1;
        }
        obs_CAMERA_SYS.obj_camera[i] = new AppMain.OBS_CAMERA();
        obs_CAMERA_SYS.camera_num++;
        AppMain.OBS_CAMERA obs_CAMERA = obs_CAMERA_SYS.obj_camera[i];
        obs_CAMERA.camera_id = i;
        obs_CAMERA.command_state = 0U;
        obs_CAMERA.spd_max.x = 16f;
        obs_CAMERA.spd_max.y = 16f;
        obs_CAMERA.spd_max.z = 4f;
        obs_CAMERA.spd_add.x = 3f;
        obs_CAMERA.spd_add.y = 3f;
        obs_CAMERA.spd_add.z = 0.5f;
        obs_CAMERA.shift = 1;
        obs_CAMERA.limit[0] = 8;
        obs_CAMERA.limit[1] = 8;
        obs_CAMERA.limit[2] = obs_CAMERA.limit[0] + ( int )AppMain.OBD_LCD_X;
        obs_CAMERA.limit[3] = obs_CAMERA.limit[1] + ( int )AppMain.OBD_LCD_Y;
        obs_CAMERA.limit[4] = -4096;
        obs_CAMERA.limit[5] = 4096;
        obs_CAMERA.pos.Assign( pos );
        obs_CAMERA.prev_pos.Assign( pos );
        obs_CAMERA.disp_pos.Assign( pos );
        obs_CAMERA.prev_disp_pos.Assign( pos );
        return i;
    }

    // Token: 0x06000127 RID: 295 RVA: 0x0000D158 File Offset: 0x0000B358
    private static void ObjCamera3dInit( int cam_id )
    {
        if ( AppMain.obj_camera_sys == null )
        {
            return;
        }
        if ( AppMain.obj_camera_sys.obj_camera[cam_id] == null )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            int num = AppMain.ObjCameraInit(cam_id, nns_VECTOR, 0, 0, 61438);
            if ( num == -1 )
            {
                return;
            }
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.obj_camera_sys.obj_camera[cam_id];
        obs_CAMERA.flag |= 16U;
        obs_CAMERA.znear = 1f;
        obs_CAMERA.zfar = 60000f;
        obs_CAMERA.aspect = AppMain.AMD_SCREEN_ASPECT;
        obs_CAMERA.fovy = AppMain.NNM_DEGtoA32( 45f );
        AppMain.nnMakePerspectiveMatrix( obs_CAMERA.prj_pers_mtx, obs_CAMERA.fovy, obs_CAMERA.aspect, obs_CAMERA.znear, obs_CAMERA.zfar );
        obs_CAMERA.scale = 0.078125f;
        float num2 = AppMain.g_obj.disp_height * obs_CAMERA.scale * 0.5f * 1f;
        float num3 = num2 * obs_CAMERA.aspect;
        obs_CAMERA.left = -num3;
        obs_CAMERA.right = num3;
        obs_CAMERA.bottom = -num2;
        obs_CAMERA.top = num2;
        AppMain.nnMakeOrthoMatrix( obs_CAMERA.prj_ortho_mtx, obs_CAMERA.left, obs_CAMERA.right, obs_CAMERA.bottom, obs_CAMERA.top, obs_CAMERA.znear, obs_CAMERA.zfar );
        switch ( obs_CAMERA.camera_type )
        {
            case AppMain.OBE_CAMERA_TYPE.OBE_CAMERA_TYPE_TARGET_ROLL:
                {
                    AppMain.NNS_CAMERA_TARGET_ROLL nns_CAMERA_TARGET_ROLL = new AppMain.NNS_CAMERA_TARGET_ROLL();
                    AppMain.ObjCameraGetTargetRollCamera( obs_CAMERA, nns_CAMERA_TARGET_ROLL );
                    AppMain.nnMakeTargetRollCameraViewMatrix( obs_CAMERA.view_mtx, nns_CAMERA_TARGET_ROLL );
                    return;
                }
            case AppMain.OBE_CAMERA_TYPE.OBE_CAMERA_TYPE_TARGET_UP_TARGET:
                {
                    AppMain.NNS_CAMERA_TARGET_UPTARGET nns_CAMERA_TARGET_UPTARGET = new AppMain.NNS_CAMERA_TARGET_UPTARGET();
                    AppMain.ObjCameraGetTargetUpTargetCamera( obs_CAMERA, nns_CAMERA_TARGET_UPTARGET );
                    AppMain.nnMakeTargetUpTargetCameraViewMatrix( obs_CAMERA.view_mtx, nns_CAMERA_TARGET_UPTARGET );
                    return;
                }
            case AppMain.OBE_CAMERA_TYPE.OBE_CAMERA_TYPE_TARGET_UP_VEC:
                {
                    AppMain.NNS_CAMERA_TARGET_UPVECTOR nns_CAMERA_TARGET_UPVECTOR = new AppMain.NNS_CAMERA_TARGET_UPVECTOR();
                    AppMain.ObjCameraGetTargetUpVecCamera( obs_CAMERA, nns_CAMERA_TARGET_UPVECTOR );
                    AppMain.nnMakeTargetUpVectorCameraViewMatrix( obs_CAMERA.view_mtx, nns_CAMERA_TARGET_UPVECTOR );
                    return;
                }
            default:
                return;
        }
    }

    // Token: 0x06000128 RID: 296 RVA: 0x0000D300 File Offset: 0x0000B500
    private static void ObjCameraExit()
    {
        if ( AppMain.obj_camera_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.obj_camera_tcb );
        }
    }

    // Token: 0x06000129 RID: 297 RVA: 0x0000D314 File Offset: 0x0000B514
    private static void ObjCameraGetTargetRollCamera( AppMain.OBS_CAMERA obj_camera, AppMain.NNS_CAMERA_TARGET_ROLL troll_camera )
    {
        troll_camera.User = 0U;
        troll_camera.Fovy = obj_camera.fovy;
        troll_camera.Aspect = obj_camera.aspect;
        troll_camera.ZNear = obj_camera.znear;
        troll_camera.ZFar = obj_camera.zfar;
        troll_camera.Position.x = obj_camera.disp_pos.x;
        troll_camera.Position.y = obj_camera.disp_pos.y;
        troll_camera.Position.z = obj_camera.disp_pos.z;
        if ( obj_camera.target_obj != null )
        {
            troll_camera.Target.x = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.x );
            troll_camera.Target.y = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.y );
            troll_camera.Target.z = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.z );
        }
        else
        {
            troll_camera.Target.x = obj_camera.target_pos.x;
            troll_camera.Target.y = obj_camera.target_pos.y;
            troll_camera.Target.z = obj_camera.target_pos.z;
        }
        troll_camera.Roll = obj_camera.roll + 16384;
    }

    // Token: 0x0600012A RID: 298 RVA: 0x0000D458 File Offset: 0x0000B658
    private static void ObjCameraGetTargetUpTargetCamera( AppMain.OBS_CAMERA obj_camera, AppMain.NNS_CAMERA_TARGET_UPTARGET tupt_camera )
    {
        tupt_camera.User = 0U;
        tupt_camera.Fovy = obj_camera.fovy;
        tupt_camera.Aspect = obj_camera.aspect;
        tupt_camera.ZNear = obj_camera.znear;
        tupt_camera.ZFar = obj_camera.zfar;
        tupt_camera.Position.x = obj_camera.disp_pos.x;
        tupt_camera.Position.y = obj_camera.disp_pos.y;
        tupt_camera.Position.z = obj_camera.disp_pos.z;
        if ( obj_camera.camup_obj != null )
        {
            tupt_camera.Target.x = AppMain.FXM_FX32_TO_FLOAT( obj_camera.camup_obj.pos.x );
            tupt_camera.Target.y = AppMain.FXM_FX32_TO_FLOAT( obj_camera.camup_obj.pos.y );
            tupt_camera.Target.z = AppMain.FXM_FX32_TO_FLOAT( obj_camera.camup_obj.pos.z );
            return;
        }
        tupt_camera.Target.x = obj_camera.camup_pos.x;
        tupt_camera.Target.y = obj_camera.camup_pos.y;
        tupt_camera.Target.z = obj_camera.camup_pos.z;
    }

    // Token: 0x0600012B RID: 299 RVA: 0x0000D58C File Offset: 0x0000B78C
    private static void ObjCameraGetTargetUpVecCamera( AppMain.OBS_CAMERA obj_camera, AppMain.NNS_CAMERA_TARGET_UPVECTOR tupvec_camera )
    {
        tupvec_camera.User = 0U;
        tupvec_camera.Fovy = obj_camera.fovy;
        tupvec_camera.Aspect = obj_camera.aspect;
        tupvec_camera.ZNear = obj_camera.znear;
        tupvec_camera.ZFar = obj_camera.zfar;
        tupvec_camera.Position.x = obj_camera.disp_pos.x;
        tupvec_camera.Position.y = obj_camera.disp_pos.y;
        tupvec_camera.Position.z = obj_camera.disp_pos.z;
        if ( obj_camera.target_obj != null )
        {
            tupvec_camera.Target.x = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.x );
            tupvec_camera.Target.y = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.y );
            tupvec_camera.Target.z = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.z );
        }
        else
        {
            tupvec_camera.Target.x = obj_camera.target_pos.x;
            tupvec_camera.Target.y = obj_camera.target_pos.y;
            tupvec_camera.Target.z = obj_camera.target_pos.z;
        }
        tupvec_camera.UpVector.Assign( obj_camera.up_vec );
    }

    // Token: 0x0600012C RID: 300 RVA: 0x0000D6D0 File Offset: 0x0000B8D0
    private static void ObjCameraPlaySet( int cam_id, AppMain.NNS_VECTOR ofst )
    {
        AppMain.obj_camera_sys.obj_camera[cam_id].play_ofst_max.Assign( ofst );
    }

    // Token: 0x0600012D RID: 301 RVA: 0x0000D6EC File Offset: 0x0000B8EC
    private static void ObjCameraAllowSet( int cam_id, AppMain.NNS_VECTOR allow )
    {
        AppMain.obj_camera_sys.obj_camera[cam_id].allow.x = 0f;
        AppMain.obj_camera_sys.obj_camera[cam_id].allow.y = 0f;
        AppMain.obj_camera_sys.obj_camera[cam_id].allow.z = 0f;
        AppMain.obj_camera_sys.obj_camera[cam_id].allow_limit.Assign( allow );
    }

    // Token: 0x0600012E RID: 302 RVA: 0x0000D762 File Offset: 0x0000B962
    public static void ObjCameraDispPosGet( int cam_id, out AppMain.SNNS_VECTOR disp_pos )
    {
        disp_pos = new AppMain.SNNS_VECTOR( AppMain.obj_camera_sys.obj_camera[cam_id].disp_pos );
    }

    // Token: 0x0600012F RID: 303 RVA: 0x0000D780 File Offset: 0x0000B980
    private static float ObjCameraDispScaleGet( int cam_id )
    {
        AppMain.mppAssertNotImpl();
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.obj_camera_sys.obj_camera[cam_id];
        if ( obs_CAMERA.disp_pos.z >= 0f )
        {
            return 1f - obs_CAMERA.disp_pos.z / 2f;
        }
        return 1f - obs_CAMERA.disp_pos.z;
    }

    // Token: 0x06000130 RID: 304 RVA: 0x0000D7DA File Offset: 0x0000B9DA
    public static AppMain.OBS_CAMERA ObjCameraGet( int cam_id )
    {
        if ( AppMain.obj_camera_sys != null )
        {
            return AppMain.obj_camera_sys.obj_camera[cam_id];
        }
        return null;
    }

    // Token: 0x06000131 RID: 305 RVA: 0x0000D7F1 File Offset: 0x0000B9F1
    public static void ObjCameraSetUserFunc( int cam_id, AppMain.OBJF_CAMERA_USER_FUNC user_func )
    {
        if ( AppMain.obj_camera_sys != null && AppMain.obj_camera_sys.obj_camera[cam_id] != null )
        {
            AppMain.obj_camera_sys.obj_camera[cam_id].user_func = user_func;
        }
    }

    // Token: 0x06000132 RID: 306 RVA: 0x0000D81C File Offset: 0x0000BA1C
    private static void objCameraDest( AppMain.MTS_TASK_TCB pTcb )
    {
        AppMain.obj_camera_tcb = null;
        AppMain.obj_camera_sys = null;
        AppMain.OBS_CAMERA_SYS obs_CAMERA_SYS = (AppMain.OBS_CAMERA_SYS)pTcb.work;
        for ( int i = 0; i < 8; i++ )
        {
            if ( obs_CAMERA_SYS.obj_camera[i] != null )
            {
                object user_work = obs_CAMERA_SYS.obj_camera[i].user_work;
            }
        }
    }

    // Token: 0x06000133 RID: 307 RVA: 0x0000D868 File Offset: 0x0000BA68
    private static void objCameraMain( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            return;
        }
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.OBS_CAMERA obs_CAMERA = AppMain.obj_camera_sys.obj_camera[i];
            if ( obs_CAMERA != null )
            {
                obs_CAMERA.prev_disp_pos.x = obs_CAMERA.disp_pos.x;
                obs_CAMERA.prev_disp_pos.y = obs_CAMERA.disp_pos.y;
                obs_CAMERA.prev_disp_pos.z = obs_CAMERA.disp_pos.z;
                if ( obs_CAMERA.user_func != null )
                {
                    obs_CAMERA.user_func( obs_CAMERA );
                }
                else
                {
                    if ( ( obs_CAMERA.flag & 4U ) != 0U )
                    {
                        AppMain.objCameraMove( obs_CAMERA );
                    }
                    nns_VECTOR.x = obs_CAMERA.pos.x;
                    nns_VECTOR.y = obs_CAMERA.pos.y;
                    nns_VECTOR.z = obs_CAMERA.pos.z;
                    if ( ( obs_CAMERA.flag & 8U ) != 0U )
                    {
                        nns_VECTOR.x -= ( nns_VECTOR.x - obs_CAMERA.work.x ) * 2f;
                        nns_VECTOR.y -= ( nns_VECTOR.y - obs_CAMERA.work.y ) * 2f;
                        nns_VECTOR.z -= ( nns_VECTOR.z - obs_CAMERA.work.z ) * 2f;
                    }
                    obs_CAMERA.disp_pos.x = nns_VECTOR.x + obs_CAMERA.ofst.x;
                    obs_CAMERA.disp_pos.y = nns_VECTOR.y + obs_CAMERA.ofst.y;
                    obs_CAMERA.disp_pos.z = nns_VECTOR.z + obs_CAMERA.ofst.z;
                }
                if ( ( obs_CAMERA.flag & 32U ) != 0U )
                {
                    AppMain.objCameraLimitCheck( obs_CAMERA );
                }
                obs_CAMERA.disp_pos.x += obs_CAMERA.disp_ofst.x;
                obs_CAMERA.disp_pos.y += obs_CAMERA.disp_ofst.y;
                obs_CAMERA.disp_pos.z += obs_CAMERA.disp_ofst.z;
                obs_CAMERA.disp_ofst.x = 0f;
                obs_CAMERA.disp_ofst.y = 0f;
                obs_CAMERA.disp_ofst.z = 0f;
                if ( ( obs_CAMERA.flag & 16U ) != 0U )
                {
                    AppMain.nnMakePerspectiveMatrix( obs_CAMERA.prj_pers_mtx, obs_CAMERA.fovy, obs_CAMERA.aspect, obs_CAMERA.znear, obs_CAMERA.zfar );
                    float num = AppMain.AMD_SCREEN_2D_WIDTH * obs_CAMERA.scale * 0.5f * 1f;
                    float num2 = num * obs_CAMERA.aspect;
                    obs_CAMERA.left = -num2;
                    obs_CAMERA.right = num2;
                    obs_CAMERA.bottom = -num;
                    obs_CAMERA.top = num;
                    AppMain.nnMakeOrthoMatrix( obs_CAMERA.prj_ortho_mtx, obs_CAMERA.left, obs_CAMERA.right, obs_CAMERA.bottom, obs_CAMERA.top, obs_CAMERA.znear, obs_CAMERA.zfar );
                    switch ( obs_CAMERA.camera_type )
                    {
                        case AppMain.OBE_CAMERA_TYPE.OBE_CAMERA_TYPE_TARGET_ROLL:
                            {
                                AppMain.NNS_CAMERA_TARGET_ROLL nns_CAMERA_TARGET_ROLL = AppMain.GlobalPool<AppMain.NNS_CAMERA_TARGET_ROLL>.Alloc();
                                int roll = obs_CAMERA.roll;
                                if ( ( obs_CAMERA.flag & 1073741824U ) != 0U )
                                {
                                    obs_CAMERA.roll = 0;
                                }
                                AppMain.ObjCameraGetTargetRollCamera( obs_CAMERA, nns_CAMERA_TARGET_ROLL );
                                AppMain.nnMakeTargetRollCameraViewMatrix( obs_CAMERA.view_mtx, nns_CAMERA_TARGET_ROLL );
                                obs_CAMERA.roll = roll;
                                AppMain.GlobalPool<AppMain.NNS_CAMERA_TARGET_ROLL>.Release( nns_CAMERA_TARGET_ROLL );
                                break;
                            }
                        case AppMain.OBE_CAMERA_TYPE.OBE_CAMERA_TYPE_TARGET_UP_TARGET:
                            {
                                AppMain.NNS_CAMERA_TARGET_UPTARGET nns_CAMERA_TARGET_UPTARGET = new AppMain.NNS_CAMERA_TARGET_UPTARGET();
                                AppMain.ObjCameraGetTargetUpTargetCamera( obs_CAMERA, nns_CAMERA_TARGET_UPTARGET );
                                AppMain.nnMakeTargetUpTargetCameraViewMatrix( obs_CAMERA.view_mtx, nns_CAMERA_TARGET_UPTARGET );
                                break;
                            }
                        case AppMain.OBE_CAMERA_TYPE.OBE_CAMERA_TYPE_TARGET_UP_VEC:
                            {
                                AppMain.NNS_CAMERA_TARGET_UPVECTOR nns_CAMERA_TARGET_UPVECTOR = new AppMain.NNS_CAMERA_TARGET_UPVECTOR();
                                AppMain.ObjCameraGetTargetUpVecCamera( obs_CAMERA, nns_CAMERA_TARGET_UPVECTOR );
                                AppMain.nnMakeTargetUpVectorCameraViewMatrix( obs_CAMERA.view_mtx, nns_CAMERA_TARGET_UPVECTOR );
                                break;
                            }
                    }
                }
            }
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000134 RID: 308 RVA: 0x0000DC00 File Offset: 0x0000BE00
    private static void objCameraMove( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        if ( obj_camera.target_obj != null )
        {
            nns_VECTOR.x = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.x ) + obj_camera.target_ofst.x;
            nns_VECTOR.y = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.y - ( ( ( int )AppMain.OBD_LCD_Y << 1 ) + 200 << 12 ) ) + obj_camera.target_ofst.y;
            nns_VECTOR.z = AppMain.FXM_FX32_TO_FLOAT( obj_camera.target_obj.pos.z ) + obj_camera.target_ofst.z;
        }
        else
        {
            nns_VECTOR.x = obj_camera.target_pos.x - AppMain.FXM_FX32_TO_FLOAT( AppMain.OBD_LCD_X >> 1 << 12 ) + obj_camera.target_ofst.x;
            nns_VECTOR.y = obj_camera.target_pos.y - AppMain.FXM_FX32_TO_FLOAT( AppMain.OBD_LCD_Y >> 1 << 12 ) + obj_camera.target_ofst.y;
            nns_VECTOR.z = obj_camera.target_pos.z + obj_camera.target_ofst.z;
        }
        obj_camera.work.x = nns_VECTOR.x;
        obj_camera.work.y = nns_VECTOR.y;
        obj_camera.work.z = nns_VECTOR.z;
        obj_camera.prev_pos.x = obj_camera.pos.x;
        obj_camera.prev_pos.y = obj_camera.pos.y;
        obj_camera.prev_pos.z = obj_camera.pos.z;
        if ( ( obj_camera.flag & 1U ) != 0U )
        {
            if ( obj_camera.target_obj != null )
            {
                obj_camera.pos.x = nns_VECTOR.x;
                obj_camera.pos.y = nns_VECTOR.y;
                obj_camera.pos.z = nns_VECTOR.z;
            }
            return;
        }
        if ( ( obj_camera.flag & 2U ) != 0U )
        {
            obj_camera.pos.x = AppMain.ObjShiftSetF( obj_camera.pos.x, nns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.x, obj_camera.spd_add.x );
            obj_camera.pos.y = AppMain.ObjShiftSetF( obj_camera.pos.y, nns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.y, obj_camera.spd_add.y );
            obj_camera.pos.z = AppMain.ObjShiftSetF( obj_camera.pos.z, nns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.z, obj_camera.spd_add.z );
        }
        else
        {
            if ( nns_VECTOR.x != obj_camera.pos.x )
            {
                obj_camera.spd.x = AppMain.ObjSpdUpSetF( obj_camera.spd.x, obj_camera.spd_add.x, obj_camera.spd_max.x );
            }
            else
            {
                obj_camera.spd.x = AppMain.ObjSpdDownSetF( obj_camera.spd.x, obj_camera.spd_add.x );
            }
            if ( nns_VECTOR.y != obj_camera.pos.y )
            {
                obj_camera.spd.y = AppMain.ObjSpdUpSetF( obj_camera.spd.y, obj_camera.spd_add.y, obj_camera.spd_max.y );
            }
            else
            {
                obj_camera.spd.y = AppMain.ObjSpdDownSetF( obj_camera.spd.y, obj_camera.spd_add.y );
            }
            if ( nns_VECTOR.z != obj_camera.pos.z )
            {
                obj_camera.spd.z = AppMain.ObjSpdUpSetF( obj_camera.spd.z, obj_camera.spd_add.z, obj_camera.spd_max.z );
            }
            else
            {
                obj_camera.spd.z = AppMain.ObjSpdDownSetF( obj_camera.spd.z, obj_camera.spd_add.z );
            }
            if ( nns_VECTOR.x > obj_camera.pos.x )
            {
                obj_camera.pos.x += obj_camera.spd.x;
                if ( obj_camera.pos.x > nns_VECTOR.x )
                {
                    obj_camera.pos.x = nns_VECTOR.x;
                }
            }
            else
            {
                obj_camera.pos.x -= obj_camera.spd.x;
                if ( obj_camera.pos.x < nns_VECTOR.x )
                {
                    obj_camera.pos.x = nns_VECTOR.x;
                }
            }
            if ( nns_VECTOR.y > obj_camera.pos.y )
            {
                obj_camera.pos.y += obj_camera.spd.y;
                if ( obj_camera.pos.y > nns_VECTOR.y )
                {
                    obj_camera.pos.y = nns_VECTOR.y;
                }
            }
            else
            {
                obj_camera.pos.y -= obj_camera.spd.y;
                if ( obj_camera.pos.y < nns_VECTOR.y )
                {
                    obj_camera.pos.y = nns_VECTOR.y;
                }
            }
            if ( nns_VECTOR.z > obj_camera.pos.z )
            {
                obj_camera.pos.z += obj_camera.spd.z;
                if ( obj_camera.pos.z > nns_VECTOR.z )
                {
                    obj_camera.pos.z = nns_VECTOR.z;
                }
            }
            else
            {
                obj_camera.pos.z -= obj_camera.spd.z;
                if ( obj_camera.pos.z < nns_VECTOR.z )
                {
                    obj_camera.pos.z = nns_VECTOR.z;
                }
            }
        }
        if ( Math.Abs( nns_VECTOR.x - obj_camera.pos.x ) > obj_camera.play_ofst_max.x )
        {
            if ( nns_VECTOR.x > obj_camera.pos.x )
            {
                obj_camera.pos.x = nns_VECTOR.x - obj_camera.play_ofst_max.x;
            }
            else
            {
                obj_camera.pos.x = nns_VECTOR.x + obj_camera.play_ofst_max.x;
            }
        }
        if ( Math.Abs( nns_VECTOR.y - obj_camera.pos.y ) > obj_camera.play_ofst_max.y )
        {
            if ( nns_VECTOR.y > obj_camera.pos.y )
            {
                obj_camera.pos.y = nns_VECTOR.y - obj_camera.play_ofst_max.y;
            }
            else
            {
                obj_camera.pos.y = nns_VECTOR.y + obj_camera.play_ofst_max.y;
            }
        }
        if ( Math.Abs( nns_VECTOR.z - obj_camera.pos.z ) > obj_camera.play_ofst_max.z )
        {
            if ( nns_VECTOR.z > obj_camera.pos.z )
            {
                obj_camera.pos.z = nns_VECTOR.z - obj_camera.play_ofst_max.z;
            }
            else
            {
                obj_camera.pos.z = nns_VECTOR.z + obj_camera.play_ofst_max.z;
            }
        }
        obj_camera.pos.z += obj_camera.ofst.z;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000135 RID: 309 RVA: 0x0000E326 File Offset: 0x0000C526
    private static void objCameraLimitCheck( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.objCameraPosLimitCheck( obj_camera, obj_camera.disp_pos );
    }

    // Token: 0x06000136 RID: 310 RVA: 0x0000E334 File Offset: 0x0000C534
    private static void objCameraPosLimitCheck( AppMain.OBS_CAMERA obj_camera, AppMain.NNS_VECTOR pPos )
    {
        int num = 0;
        if ( pPos.z != 0f )
        {
            if ( ( float )obj_camera.limit[4] > pPos.z )
            {
                pPos.z = ( float )obj_camera.limit[4];
            }
            if ( ( float )obj_camera.limit[5] < pPos.z )
            {
                pPos.z = ( float )obj_camera.limit[5];
            }
            if ( 1f / AppMain.ObjCameraDispScaleGet( ( int )obj_camera.index ) * ( float )AppMain.OBD_LCD_X > ( float )( obj_camera.limit[2] - obj_camera.limit[0] ) )
            {
                float num2 = (float)(obj_camera.limit[2] - obj_camera.limit[0]) / (float)AppMain.OBD_LCD_X;
                num2 = 1f / num2;
                if ( pPos.z >= 0f )
                {
                    pPos.z = ( num2 - 1f ) * -2f;
                }
                else
                {
                    pPos.z = ( num2 - 1f ) * -1f;
                }
            }
            if ( 1f / AppMain.ObjCameraDispScaleGet( ( int )obj_camera.index ) * ( float )AppMain.OBD_LCD_Y > ( float )( obj_camera.limit[3] - obj_camera.limit[1] ) )
            {
                float num2 = (float)(obj_camera.limit[3] - obj_camera.limit[1]) / (float)AppMain.OBD_LCD_X;
                num2 = 1f / num2;
                if ( pPos.z >= 0f )
                {
                    pPos.z = ( num2 - 1f ) * -2f;
                }
                else
                {
                    pPos.z = ( num2 - 1f ) * -1f;
                }
            }
        }
        if ( pPos.z > 0f )
        {
            num = AppMain.FXM_FLOAT_TO_FX32( 1f / AppMain.ObjCameraDispScaleGet( ( int )obj_camera.index ) * ( float )AppMain.OBD_LCD_X );
            num -= ( int )AppMain.OBD_LCD_X << 12;
            num >>= 13;
        }
        if ( ( float )( obj_camera.limit[0] + num ) > pPos.x )
        {
            pPos.x = ( float )( obj_camera.limit[0] + num );
        }
        if ( ( float )( obj_camera.limit[2] - ( int )AppMain.OBD_LCD_X - num ) < pPos.x )
        {
            pPos.x = ( float )( obj_camera.limit[2] - ( int )AppMain.OBD_LCD_X - num );
        }
        if ( pPos.z > 0f )
        {
            num = AppMain.FXM_FLOAT_TO_FX32( 1f / AppMain.ObjCameraDispScaleGet( ( int )obj_camera.index ) * ( float )AppMain.OBD_LCD_Y );
            num -= ( int )AppMain.OBD_LCD_Y << 12;
            num >>= 13;
        }
        if ( ( float )( obj_camera.limit[1] + num ) > pPos.y )
        {
            pPos.y = ( float )( obj_camera.limit[1] + num );
        }
        if ( ( float )( obj_camera.limit[3] - ( int )AppMain.OBD_LCD_Y - num ) < pPos.y )
        {
            pPos.y = ( float )( obj_camera.limit[3] - ( int )AppMain.OBD_LCD_Y - num );
        }
    }
}
