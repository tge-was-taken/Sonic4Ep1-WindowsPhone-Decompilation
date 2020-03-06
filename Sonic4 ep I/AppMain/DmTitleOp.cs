using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200039D RID: 925
    public class DMS_TITLEOP_ROCK_SETTING
    {
        // Token: 0x060026EB RID: 9963 RVA: 0x00150D05 File Offset: 0x0014EF05
        public DMS_TITLEOP_ROCK_SETTING( uint x1, uint y1, uint z1, uint x2, uint y2, uint z2 )
        {
            this.pos = new AppMain.VecFx32( ( int )x1, ( int )y1, ( int )z1 );
            this.scale = new AppMain.VecFx32( ( int )x2, ( int )y2, ( int )z2 );
        }

        // Token: 0x04006137 RID: 24887
        public AppMain.VecFx32 pos = default(AppMain.VecFx32);

        // Token: 0x04006138 RID: 24888
        public AppMain.VecFx32 scale = default(AppMain.VecFx32);
    }

    // Token: 0x0200039E RID: 926
    public class DMS_TITLEOP_OBJ_3DNN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060026EC RID: 9964 RVA: 0x00150D44 File Offset: 0x0014EF44
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060026ED RID: 9965 RVA: 0x00150D4C File Offset: 0x0014EF4C
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.DMS_TITLEOP_OBJ_3DNN_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x060026EE RID: 9966 RVA: 0x00150D54 File Offset: 0x0014EF54
        public static explicit operator AppMain.DMS_TITLEOP_OBJ_3DNN_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_TITLEOP_OBJ_3DNN_WORK )work.holder;
        }

        // Token: 0x060026EF RID: 9967 RVA: 0x00150D61 File Offset: 0x0014EF61
        public DMS_TITLEOP_OBJ_3DNN_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04006139 RID: 24889
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x0400613A RID: 24890
        public AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x0400613B RID: 24891
        public AppMain.DMS_TITLEOP_ROCK_SETTING[] rock_setting;

        // Token: 0x0400613C RID: 24892
        public int rock_setting_num;

        // Token: 0x0400613D RID: 24893
        public float sky_rot;
    }

    // Token: 0x0200039F RID: 927
    public class DMS_TITLEOP_MGR_WORK
    {
        // Token: 0x060026F0 RID: 9968 RVA: 0x00150D80 File Offset: 0x0014EF80
        public void Clear()
        {
            this.frame = 0;
            this.flag = 0U;
            Array.Clear( this.obj_work, 0, this.obj_work.Length );
            Array.Clear( this.act, 0, this.act.Length );
            this.finger_frame = 0f;
        }

        // Token: 0x0400613E RID: 24894
        public int frame;

        // Token: 0x0400613F RID: 24895
        public uint flag;

        // Token: 0x04006140 RID: 24896
        public AppMain.OBS_OBJECT_WORK[] obj_work = new AppMain.OBS_OBJECT_WORK[5];

        // Token: 0x04006141 RID: 24897
        public AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[7];

        // Token: 0x04006142 RID: 24898
        public float finger_frame;
    }

    // Token: 0x060018B7 RID: 6327 RVA: 0x000E1A3E File Offset: 0x000DFC3E
    public AppMain.DMS_TITLEOP_OBJ_3DNN_WORK DMM_TITLEOP_CREATE_3D_OBJ( ushort prio, byte group, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return this.dmTitleOpCreate3DObj( prio, group, work_size );
    }

    // Token: 0x060018B8 RID: 6328 RVA: 0x000E1A49 File Offset: 0x000DFC49
    private void DmTitleOpLoad()
    {
        this.DmLogoComLoadFileCreate( AppMain.dm_titleop_load_tcb );
        this.DmLogoComLoadFileReg( AppMain.dm_titleop_load_tcb, this.dm_titleop_com_fileinfo_list, 2 );
        this.DmLogoComLoadFileStart( AppMain.dm_titleop_load_tcb );
    }

    // Token: 0x060018B9 RID: 6329 RVA: 0x000E1A74 File Offset: 0x000DFC74
    private bool DmTitleOpLoadCheck()
    {
        return AppMain.dm_titleop_load_tcb.Target == null && AppMain.dm_titleop_data[0] != null;
    }

    // Token: 0x060018BA RID: 6330 RVA: 0x000E1A90 File Offset: 0x000DFC90
    private void DmTitleOpBuild()
    {
        AppMain.AMS_AMB_HEADER[] array = new AppMain.AMS_AMB_HEADER[1];
        AppMain.dm_titleop_build_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpDataBuildMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpDataBuildDest ), 0U, ushort.MaxValue, 4096U, 0, null, "DM_TOP_BUILD" );
        AppMain.dm_titleop_aos_tex = AppMain.New<AppMain.AOS_TEXTURE>( 1 );
        string dir = null;
        array[0] = AppMain.readAMBFile( AppMain.amBindGet( AppMain.dm_titleop_data[1], 1, out dir ) );
        array[0].dir = dir;
        AppMain.AOS_TEXTURE[] array2 = AppMain.dm_titleop_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.AoTexBuild( array2[i], array[i] );
            AppMain.AoTexLoad( array2[i] );
        }
        AppMain.ObjInit( 4, 61435, 0, AppMain.GMD_OBJ_LCD_X, AppMain.GMD_OBJ_LCD_Y, ( float )AppMain.GSD_DISP_WIDTH, ( float )AppMain.GSD_DISP_HEIGHT );
        AppMain.ObjDataAlloc( 10 );
        AppMain.ObjDrawSetNNCommandStateTbl( 0U, 0U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 1U, 1U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 2U, 2U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 3U, 3U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 4U, 4U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 5U, 5U, true );
        AppMain.AoActSysClearPeak();
        AppMain.GmGameDBuildModelBuildInit();
        this.dm_titleop_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[0], ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[1], 0U );
        this.dm_titleop_water_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[3], ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[1], 0U );
    }

    // Token: 0x060018BB RID: 6331 RVA: 0x000E1BD5 File Offset: 0x000DFDD5
    private bool DmTitleOpBuildCheck()
    {
        return AppMain.dm_titleop_build_state;
    }

    // Token: 0x060018BC RID: 6332 RVA: 0x000E1BE4 File Offset: 0x000DFDE4
    private void DmTitleOpFlush()
    {
        AppMain.dm_titleop_flush_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpDataFlushMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpDataFlushDest ), 0U, ushort.MaxValue, 4096U, 0, null, "DM_TOP_FLUSH" );
        AppMain.AOS_TEXTURE[] array = AppMain.dm_titleop_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.AoTexRelease( array[i] );
        }
        AppMain.GmGameDBuildModelFlushInit();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.dm_titleop_mapfar_data[0];
        AppMain.GmGameDBuildRegFlushModel( this.dm_titleop_obj_3d_list, ams_AMB_HEADER.file_num );
        ams_AMB_HEADER = ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[3];
        AppMain.GmGameDBuildRegFlushModel( this.dm_titleop_water_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060018BD RID: 6333 RVA: 0x000E1C80 File Offset: 0x000DFE80
    private bool DmTitleOpFlushCheck()
    {
        return !AppMain.dm_titleop_build_state;
    }

    // Token: 0x060018BE RID: 6334 RVA: 0x000E1C8C File Offset: 0x000DFE8C
    private void DmTitleOpRelease()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.dm_titleop_data[i] = null;
        }
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.dm_titleop_mapfar_data[i] = null;
        }
    }

    // Token: 0x060018BF RID: 6335 RVA: 0x000E1CC1 File Offset: 0x000DFEC1
    private bool DmTitleOpReleaseCheck()
    {
        return AppMain.dm_titleop_load_tcb.Target == null && AppMain.dm_titleop_data[0] == null;
    }

    // Token: 0x060018C0 RID: 6336 RVA: 0x000E1CDC File Offset: 0x000DFEDC
    private void DmTitleOpInit()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.Clear();
        AppMain.NNS_VECTOR pos = new AppMain.NNS_VECTOR(0f, 0f, 50f);
        AppMain.g_obj.flag = 4259848U;
        AppMain.g_obj.ppPre = null;
        AppMain.g_obj.ppPost = null;
        AppMain.g_obj.ppCollision = null;
        AppMain.g_obj.ppObjPre = null;
        AppMain.g_obj.ppObjPost = null;
        AppMain.g_obj.ppRegRecAuto = null;
        AppMain.g_obj.draw_scale.x = ( AppMain.g_obj.draw_scale.y = ( AppMain.g_obj.draw_scale.z = 13107 ) );
        AppMain.g_obj.inv_draw_scale.x = ( AppMain.g_obj.inv_draw_scale.y = ( AppMain.g_obj.inv_draw_scale.z = AppMain.FX_Div( 4096, AppMain.g_obj.draw_scale.x ) ) );
        AppMain.g_obj.depth = 128;
        AppMain.g_obj.ambient_color.r = 0.8f;
        AppMain.g_obj.ambient_color.g = 0.8f;
        AppMain.g_obj.ambient_color.b = 0.8f;
        nns_VECTOR.x = -1f;
        nns_VECTOR.y = -1f;
        nns_VECTOR.z = -1f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_0, ref nns_RGBA, 1f, nns_VECTOR );
        AppMain.ObjCameraInit( 0, pos, 0, 0, 12288 );
        AppMain.ObjCamera3dInit( 0 );
        AppMain.g_obj.glb_camera_id = 0;
        AppMain.g_obj.glb_camera_type = 0;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.user_func = new AppMain.OBJF_CAMERA_USER_FUNC( this.dmTitleOpCamera );
        obs_CAMERA.command_state = 0U;
        obs_CAMERA.fovy = AppMain.NNM_DEGtoA32( 40f );
        obs_CAMERA.znear = 0.1f;
        obs_CAMERA.zfar = 32768f;
        this.dmTitleOpMgrInit();
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x060018C1 RID: 6337 RVA: 0x000E1F0C File Offset: 0x000E010C
    private void DmTitleOpExit()
    {
        if ( AppMain.dm_titleop_mgr_tcb != null )
        {
            AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)AppMain.dm_titleop_mgr_tcb.work;
            dms_TITLEOP_MGR_WORK.flag |= 536870912U;
        }
    }

    // Token: 0x060018C2 RID: 6338 RVA: 0x000E1F42 File Offset: 0x000E0142
    private bool DmTitleOpExitEndCheck()
    {
        return AppMain.dm_titleop_mgr_tcb == null;
    }

    // Token: 0x060018C3 RID: 6339 RVA: 0x000E1F50 File Offset: 0x000E0150
    private void DmTitleOpDraw2D()
    {
        if ( AppMain.dm_titleop_mgr_tcb == null )
        {
            return;
        }
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)AppMain.dm_titleop_mgr_tcb.work;
        if ( ( dms_TITLEOP_MGR_WORK.flag & 2147483648U ) == 0U )
        {
            return;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_titleop_aos_tex[0] ) );
        int num = 5;
        for ( int i = 0; i < num; i++ )
        {
            if ( ( dms_TITLEOP_MGR_WORK.flag & 1U << i ) != 0U && ( dms_TITLEOP_MGR_WORK.flag & 256U << i ) == 0U )
            {
                AppMain.AoActAcmPush();
                AppMain.AoActAcmInit();
                if ( i == 1 )
                {
                    AppMain.AoActSetFrame( dms_TITLEOP_MGR_WORK.act[i], dms_TITLEOP_MGR_WORK.finger_frame );
                    AppMain.AoActAcmApplyTrans( -10f, -15f, 0f );
                    AppMain.AoActAcmApplyScale( 0.9f, 0.9f );
                    AppMain.AoActUpdate( dms_TITLEOP_MGR_WORK.act[i], 0f );
                    dms_TITLEOP_MGR_WORK.finger_frame += 1f;
                    if ( dms_TITLEOP_MGR_WORK.finger_frame > 84f )
                    {
                        dms_TITLEOP_MGR_WORK.finger_frame = 60f;
                    }
                }
                else
                {
                    if ( i == 0 )
                    {
                        AppMain.AoActAcmApplyTrans( 0f, -25f, 0f );
                    }
                    else if ( i == 3 )
                    {
                        AppMain.AoActAcmApplyTrans( 0f, -10f, 0f );
                    }
                    AppMain.AoActAcmApplyScale( 0.9f, 0.9f );
                    AppMain.AoActUpdate( dms_TITLEOP_MGR_WORK.act[i] );
                }
                AppMain.AoActSortRegAction( dms_TITLEOP_MGR_WORK.act[i] );
                AppMain.AoActAcmPop( 1U );
            }
        }
    }

    // Token: 0x060018C4 RID: 6340 RVA: 0x000E20B4 File Offset: 0x000E02B4
    private bool DmTitleOpIsLogoActFinish()
    {
        if ( AppMain.dm_titleop_mgr_tcb == null )
        {
            return false;
        }
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)AppMain.dm_titleop_mgr_tcb.work;
        return ( dms_TITLEOP_MGR_WORK.flag & 1073741824U ) != 0U;
    }

    // Token: 0x060018C5 RID: 6341 RVA: 0x000E20EC File Offset: 0x000E02EC
    private void DmTitleOpDispRightEnable( bool disp )
    {
        if ( AppMain.dm_titleop_mgr_tcb == null )
        {
            return;
        }
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)AppMain.dm_titleop_mgr_tcb.work;
        if ( disp )
        {
            dms_TITLEOP_MGR_WORK.flag &= 4294963199U;
            return;
        }
        dms_TITLEOP_MGR_WORK.flag |= 4096U;
    }

    // Token: 0x060018C6 RID: 6342 RVA: 0x000E213C File Offset: 0x000E033C
    private void DmTitleOpSetRetOptionState()
    {
        if ( AppMain.dm_titleop_mgr_tcb == null )
        {
            return;
        }
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)AppMain.dm_titleop_mgr_tcb.work;
        dms_TITLEOP_MGR_WORK.flag |= 1073741951U;
        dms_TITLEOP_MGR_WORK.frame = 105;
        dms_TITLEOP_MGR_WORK.finger_frame = 75f;
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_titleop_aos_tex[0] ) );
        int num = 5;
        for ( int i = 0; i < num; i++ )
        {
            AppMain.AoActAcmPush();
            AppMain.AoActAcmInit();
            AppMain.AoActSetFrame( dms_TITLEOP_MGR_WORK.act[i], 75f );
            AppMain.AoActUpdate( dms_TITLEOP_MGR_WORK.act[i], 0f );
            AppMain.AoActAcmPop( 1U );
        }
    }

    // Token: 0x060018C7 RID: 6343 RVA: 0x000E21DC File Offset: 0x000E03DC
    private static void dmTitleOpLoadPostFuncMapFar( AppMain.DMS_LOGO_COM_LOAD_CONTEXT context )
    {
        AppMain.dm_titleop_data[context.no] = context.fs_req;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.dm_titleop_data[context.no]);
        for ( int i = 0; i < ams_AMB_HEADER.file_num; i++ )
        {
            string dir;
            AppMain.AmbChunk buf = AppMain.amBindGet(ams_AMB_HEADER, i, out dir);
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER2 = AppMain.readAMBFile(buf);
            ams_AMB_HEADER2.dir = dir;
            AppMain.dm_titleop_mapfar_data[i] = ams_AMB_HEADER2;
        }
    }

    // Token: 0x060018C8 RID: 6344 RVA: 0x000E2241 File Offset: 0x000E0441
    private static void dmTitleOpLoadPostFuncTitleLogo( AppMain.DMS_LOGO_COM_LOAD_CONTEXT context )
    {
        AppMain.dm_titleop_data[context.no] = context.fs_req;
        context.fs_req = null;
    }

    // Token: 0x060018C9 RID: 6345 RVA: 0x000E225C File Offset: 0x000E045C
    private void dmTitleOpDataBuildMain( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        AppMain.AOS_TEXTURE[] array = AppMain.dm_titleop_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( array[i] ) )
            {
                flag = false;
            }
        }
        if ( !AppMain.GmGameDBuildCheckBuildModel() )
        {
            flag = false;
        }
        if ( !flag )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
        AppMain.dm_titleop_build_state = true;
    }

    // Token: 0x060018CA RID: 6346 RVA: 0x000E22A2 File Offset: 0x000E04A2
    private void dmTitleOpDataBuildDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_titleop_build_tcb = null;
    }

    // Token: 0x060018CB RID: 6347 RVA: 0x000E22AC File Offset: 0x000E04AC
    private void dmTitleOpDataFlushMain( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        AppMain.AOS_TEXTURE[] array = AppMain.dm_titleop_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            if ( !AppMain.AoTexIsReleased( array[i] ) )
            {
                flag = false;
            }
        }
        if ( !AppMain.GmGameDBuildCheckFlushModel() )
        {
            flag = false;
        }
        if ( !flag )
        {
            return;
        }
        for ( int j = 0; j < AppMain.dm_titleop_aos_tex.Length; j++ )
        {
            AppMain.dm_titleop_aos_tex[j] = null;
        }
        AppMain.dm_titleop_aos_tex = null;
        this.dm_titleop_obj_3d_list = null;
        this.dm_titleop_water_obj_3d_list = null;
        AppMain.mtTaskClearTcb( tcb );
        AppMain.dm_titleop_build_state = false;
    }

    // Token: 0x060018CC RID: 6348 RVA: 0x000E2320 File Offset: 0x000E0520
    private void dmTitleOpDataFlushDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_titleop_flush_tcb = null;
    }

    // Token: 0x060018CD RID: 6349 RVA: 0x000E2330 File Offset: 0x000E0530
    private void dmTitleOpMgrInit()
    {
        AppMain.dm_titleop_mgr_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpMgrMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpMgrDest ), 0U, ushort.MaxValue, 12288U, 0, () => new AppMain.DMS_TITLEOP_MGR_WORK(), "DM_TOP_MGR" );
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)AppMain.dm_titleop_mgr_tcb.work;
        dms_TITLEOP_MGR_WORK.Clear();
        this.dmTitleOpCreateObjFarSky();
        this.dmTitleOpCreateObjFarRock( 0U );
        this.dmTitleOpCreateObjFarRock( 1U );
        this.dmTitleOpCreateObjFarRock( 2U );
        this.dmTitleOpCreateObjFarSea();
        this.dmTitleOpCreateAction( dms_TITLEOP_MGR_WORK );
        dms_TITLEOP_MGR_WORK.flag |= 268435456U;
        AppMain.dm_titleop_scrl_x_ofst = 0;
    }

    // Token: 0x060018CE RID: 6350 RVA: 0x000E23E3 File Offset: 0x000E05E3
    private void dmTitleOpMgrDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_titleop_mgr_tcb = null;
    }

    // Token: 0x060018CF RID: 6351 RVA: 0x000E23EC File Offset: 0x000E05EC
    private void dmTitleOpMgrMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)tcb.work;
        if ( ( dms_TITLEOP_MGR_WORK.flag & 536870912U ) != 0U )
        {
            this.dmTitleOpEndStart( tcb );
            return;
        }
        dms_TITLEOP_MGR_WORK.frame++;
        if ( dms_TITLEOP_MGR_WORK.frame == 30 )
        {
            dms_TITLEOP_MGR_WORK.flag |= 111U;
        }
        if ( dms_TITLEOP_MGR_WORK.frame == 75 )
        {
            dms_TITLEOP_MGR_WORK.flag |= 16U;
        }
        else if ( dms_TITLEOP_MGR_WORK.frame >= 105 )
        {
            dms_TITLEOP_MGR_WORK.flag |= 1073741824U;
        }
        if ( ( dms_TITLEOP_MGR_WORK.flag & 268435456U ) != 0U )
        {
            AppMain.dm_titleop_scrl_x_ofst += -128;
            int num = AppMain.dm_titleop_scrl_x_ofst / 3145728;
            AppMain.dm_titleop_scrl_x_ofst -= num * 3145728;
        }
        AppMain.ObjDraw3DNNUserFunc( AppMain._dmTitleOpPreDrawDT, null, 0, 0U );
        AppMain.ObjDraw3DNNUserFunc( AppMain._dmTitleOpFallShaderPreRenderUserFunc, null, 0, 2U );
        AppMain.amDrawSetFog( 0U, 1 );
        AppMain.amDrawSetFogColor( 0U, 0.7f, 0.95f, 1f );
        AppMain.amDrawSetFogRange( 0U, 1f, 500f );
        AppMain.amDrawSetFog( 4U, 0 );
    }

    // Token: 0x060018D0 RID: 6352 RVA: 0x000E2510 File Offset: 0x000E0710
    private void dmTitleOpCreateObjFarSky()
    {
        AppMain.DMS_TITLEOP_OBJ_3DNN_WORK dms_TITLEOP_OBJ_3DNN_WORK = this.DMM_TITLEOP_CREATE_3D_OBJ(24576, 0, () => new AppMain.DMS_TITLEOP_OBJ_3DNN_WORK(), "DM_TOP_SKYT");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)dms_TITLEOP_OBJ_3DNN_WORK;
        obs_OBJECT_WORK.obj_type = 1;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, this.dm_titleop_obj_3d_list[0], dms_TITLEOP_OBJ_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.obj_3d.command_state = 3U;
        AppMain.ObjAction3dNNMaterialMotionLoad( dms_TITLEOP_OBJ_3DNN_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[2] );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.disp_flag |= 13697028U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmTitleOpFarSkyFunc );
        dms_TITLEOP_OBJ_3DNN_WORK = this.DMM_TITLEOP_CREATE_3D_OBJ( 16384, 0, () => new AppMain.DMS_TITLEOP_OBJ_3DNN_WORK(), "DM_TOP_SKYB" );
        obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )dms_TITLEOP_OBJ_3DNN_WORK;
        obs_OBJECT_WORK.obj_type = 1;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, this.dm_titleop_obj_3d_list[0], dms_TITLEOP_OBJ_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.obj_3d.command_state = 1U;
        AppMain.ObjAction3dNNMaterialMotionLoad( dms_TITLEOP_OBJ_3DNN_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[2] );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.disp_flag |= 13697028U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmTitleOpFarSkyFunc );
    }

    // Token: 0x060018D1 RID: 6353 RVA: 0x000E2664 File Offset: 0x000E0864
    private void dmTitleOpFarSkyFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_TITLEOP_OBJ_3DNN_WORK dms_TITLEOP_OBJ_3DNN_WORK = (AppMain.DMS_TITLEOP_OBJ_3DNN_WORK)obj_work;
        dms_TITLEOP_OBJ_3DNN_WORK.sky_rot += 0.01f;
        if ( dms_TITLEOP_OBJ_3DNN_WORK.sky_rot > 360f )
        {
            dms_TITLEOP_OBJ_3DNN_WORK.sky_rot -= 360f;
        }
        AppMain.nnMakeUnitMatrix( obj_work.obj_3d.user_obj_mtx );
        AppMain.nnRotateYMatrix( obj_work.obj_3d.user_obj_mtx, obj_work.obj_3d.user_obj_mtx, ( int )( ( ushort )AppMain.NNM_DEGtoA16( dms_TITLEOP_OBJ_3DNN_WORK.sky_rot ) ) );
    }

    // Token: 0x060018D2 RID: 6354 RVA: 0x000E26E8 File Offset: 0x000E08E8
    private void dmTitleOpCreateObjFarRock( uint type )
    {
        AppMain.DMS_TITLEOP_OBJ_3DNN_WORK dms_TITLEOP_OBJ_3DNN_WORK = this.DMM_TITLEOP_CREATE_3D_OBJ(24832, 0, () => new AppMain.DMS_TITLEOP_OBJ_3DNN_WORK(), "DM_TOP_ROCKT");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)dms_TITLEOP_OBJ_3DNN_WORK;
        obs_OBJECT_WORK.obj_type = 1;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, this.dm_titleop_obj_3d_list[( int )( ( UIntPtr )( 1U + type ) )], dms_TITLEOP_OBJ_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.obj_3d.command_state = 3U;
        obs_OBJECT_WORK.disp_flag |= 5242880U;
        obs_OBJECT_WORK.disp_flag |= 268435456U;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmTitleOpObjRockDraw );
        dms_TITLEOP_OBJ_3DNN_WORK.rock_setting = AppMain.dm_titleop_rock_setting[( int )( ( UIntPtr )type )];
        dms_TITLEOP_OBJ_3DNN_WORK.rock_setting_num = AppMain.dm_titleop_rock_setting_num[( int )( ( UIntPtr )type )];
    }

    // Token: 0x060018D3 RID: 6355 RVA: 0x000E27B0 File Offset: 0x000E09B0
    private void dmTitleOpCreateObjFarSea()
    {
        AppMain.DMS_TITLEOP_OBJ_3DNN_WORK dms_TITLEOP_OBJ_3DNN_WORK = this.DMM_TITLEOP_CREATE_3D_OBJ(20480, 0, () => new AppMain.DMS_TITLEOP_OBJ_3DNN_WORK(), "DM_TOP_SEA");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)dms_TITLEOP_OBJ_3DNN_WORK;
        obs_OBJECT_WORK.obj_type = 1;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, this.dm_titleop_water_obj_3d_list[0], dms_TITLEOP_OBJ_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.obj_3d.command_state = 2U;
        AppMain.ObjAction3dNNMaterialMotionLoad( dms_TITLEOP_OBJ_3DNN_WORK.obj_3d, 0, null, null, 1, ( AppMain.AMS_AMB_HEADER )AppMain.dm_titleop_mapfar_data[2] );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.obj_3d.mat_speed = 0.2f;
        obs_OBJECT_WORK.dir.y = 49152;
        obs_OBJECT_WORK.disp_flag |= 5308420U;
    }

    // Token: 0x060018D4 RID: 6356 RVA: 0x000E2870 File Offset: 0x000E0A70
    private AppMain.DMS_TITLEOP_OBJ_3DNN_WORK dmTitleOpCreate3DObj( ushort prio, byte group, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(prio, group, 0, 0, work_size, null);
        AppMain.DMS_TITLEOP_OBJ_3DNN_WORK result = (AppMain.DMS_TITLEOP_OBJ_3DNN_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmTitleOpObjDraw );
        obs_OBJECT_WORK.ppOutSub = null;
        obs_OBJECT_WORK.ppIn = null;
        obs_OBJECT_WORK.ppMove = null;
        obs_OBJECT_WORK.ppActCall = null;
        obs_OBJECT_WORK.ppRec = null;
        obs_OBJECT_WORK.ppLast = null;
        obs_OBJECT_WORK.ppFunc = null;
        return result;
    }

    // Token: 0x060018D5 RID: 6357 RVA: 0x000E28D8 File Offset: 0x000E0AD8
    private void dmTitleOpCreateAction( AppMain.DMS_TITLEOP_MGR_WORK top_mgr_work )
    {
        string text = null;
        AppMain.A2S_AMA_HEADER ama = AppMain.readAMAFile(AppMain.amBindGet(AppMain.dm_titleop_data[1], 0, out text));
        for ( uint num = 0U; num < 7U; num += 1U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_titleop_aos_tex[0] ) );
            top_mgr_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, num );
        }
        top_mgr_work.flag |= 2147483648U;
    }

    // Token: 0x060018D6 RID: 6358 RVA: 0x000E293C File Offset: 0x000E0B3C
    private void dmTitleOpDeleteAction( ref AppMain.DMS_TITLEOP_MGR_WORK top_mgr_work )
    {
        for ( int i = 0; i < 7; i++ )
        {
            AppMain.AoActDelete( top_mgr_work.act[i] );
        }
    }

    // Token: 0x060018D7 RID: 6359 RVA: 0x000E2964 File Offset: 0x000E0B64
    private void dmTitleOpEndStart( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)tcb.work;
        this.dmTitleOpPreEnd( ref dms_TITLEOP_MGR_WORK );
        dms_TITLEOP_MGR_WORK.frame = 0;
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpPreEndWait ) );
    }

    // Token: 0x060018D8 RID: 6360 RVA: 0x000E29A0 File Offset: 0x000E0BA0
    private void dmTitleOpPreEnd( ref AppMain.DMS_TITLEOP_MGR_WORK top_mgr_work )
    {
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, ushort.MaxValue ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ushort.MaxValue ) )
        {
            obs_OBJECT_WORK.ppOut = null;
        }
    }

    // Token: 0x060018D9 RID: 6361 RVA: 0x000E29D4 File Offset: 0x000E0BD4
    private void dmTitleOpPreEndWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_TITLEOP_MGR_WORK dms_TITLEOP_MGR_WORK = (AppMain.DMS_TITLEOP_MGR_WORK)tcb.work;
        dms_TITLEOP_MGR_WORK.frame++;
        if ( dms_TITLEOP_MGR_WORK.frame > 2 )
        {
            this.dmTitleOpEnd( ref dms_TITLEOP_MGR_WORK );
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmTitleOpEndWait ) );
        }
    }

    // Token: 0x060018DA RID: 6362 RVA: 0x000E2A1E File Offset: 0x000E0C1E
    private void dmTitleOpEnd( ref AppMain.DMS_TITLEOP_MGR_WORK top_mgr_work )
    {
        this.dmTitleOpDeleteAction( ref top_mgr_work );
        AppMain.g_obj.ppPre = null;
        AppMain.ObjObjectClearAllObject();
        AppMain.ObjPreExit();
        AppMain.ObjExit();
    }

    // Token: 0x060018DB RID: 6363 RVA: 0x000E2A41 File Offset: 0x000E0C41
    private void dmTitleOpEndWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.ObjObjectCheckClearAllObject() )
        {
            return;
        }
        if ( AppMain.ObjIsExitWait() )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
    }

    // Token: 0x060018DC RID: 6364 RVA: 0x000E2A59 File Offset: 0x000E0C59
    private static void dmTitleOpPreDrawDT( object data )
    {
        AppMain.amDrawSetBGColor( AppMain.dm_titleop_clear_color );
    }

    // Token: 0x060018DD RID: 6365 RVA: 0x000E2A65 File Offset: 0x000E0C65
    private void dmTitleOpObjDraw( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x060018DE RID: 6366 RVA: 0x000E2A70 File Offset: 0x000E0C70
    private void dmTitleOpObjRockDraw( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_TITLEOP_OBJ_3DNN_WORK dms_TITLEOP_OBJ_3DNN_WORK = (AppMain.DMS_TITLEOP_OBJ_3DNN_WORK)obj_work;
        for ( int i = 0; i < dms_TITLEOP_OBJ_3DNN_WORK.rock_setting_num; i++ )
        {
            obj_work.pos.Assign( dms_TITLEOP_OBJ_3DNN_WORK.rock_setting[i].pos );
            obj_work.pos.x = obj_work.pos.x + AppMain.dm_titleop_scrl_x_ofst;
            if ( obj_work.pos.x < -1966080 )
            {
                obj_work.pos.x = obj_work.pos.x + 3145728;
            }
            else if ( obj_work.pos.x > 1966080 )
            {
                obj_work.pos.x = obj_work.pos.x - 3145728;
            }
            if ( obj_work.pos.x >= -1179648 && obj_work.pos.x <= 1179648 )
            {
                obj_work.scale.Assign( dms_TITLEOP_OBJ_3DNN_WORK.rock_setting[i].scale );
                AppMain.ObjDrawActionSummary( obj_work );
            }
        }
    }

    // Token: 0x060018DF RID: 6367 RVA: 0x000E2B60 File Offset: 0x000E0D60
    private static void dmTitleOpFallShaderPreRenderUserFunc( object data )
    {
        AppMain.NNS_RGBA_U8 color = new AppMain.NNS_RGBA_U8(0, 0, 0, byte.MaxValue);
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain._am_render_manager.targetp;
        if ( ams_RENDER_TARGET == AppMain._gm_mapFar_render_work )
        {
            ams_RENDER_TARGET = AppMain._am_draw_target;
        }
        else
        {
            ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
        }
        if ( ams_RENDER_TARGET.width == 0 )
        {
            return;
        }
        AppMain.amRenderCopyTarget( ams_RENDER_TARGET, color );
    }

    // Token: 0x060018E0 RID: 6368 RVA: 0x000E2BAC File Offset: 0x000E0DAC
    private void dmTitleOpDrawFallShaderPreSettingUserFunc( ref object data )
    {
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain._am_render_manager.targetp;
        if ( ams_RENDER_TARGET == AppMain._gm_mapFar_render_work )
        {
            ams_RENDER_TARGET = AppMain._am_draw_target;
        }
        else
        {
            ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
        }
        if ( ams_RENDER_TARGET.width == 0 )
        {
            return;
        }
        AppMain.amDrawGetProjectionMatrix();
    }

    // Token: 0x060018E1 RID: 6369 RVA: 0x000E2BEC File Offset: 0x000E0DEC
    private void dmTitleOpCamera( AppMain.OBS_CAMERA camera )
    {
        camera.disp_pos.x = 0f;
        camera.disp_pos.y = 5f;
        camera.disp_pos.z = 160f;
        camera.target_pos.x = 0f;
        camera.target_pos.y = 0f;
        camera.target_pos.z = 10f;
    }
}
