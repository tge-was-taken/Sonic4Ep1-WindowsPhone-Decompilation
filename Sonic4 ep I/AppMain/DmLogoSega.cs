using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0200019F RID: 415
    public class DMS_LOGO_SEGA_OBJ_3DNN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021F4 RID: 8692 RVA: 0x0014201D File Offset: 0x0014021D
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060021F5 RID: 8693 RVA: 0x00142025 File Offset: 0x00140225
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.DMS_LOGO_SEGA_OBJ_3DNN_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x060021F6 RID: 8694 RVA: 0x0014202D File Offset: 0x0014022D
        public static explicit operator AppMain.DMS_LOGO_SEGA_OBJ_3DNN_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_LOGO_SEGA_OBJ_3DNN_WORK )work.holder;
        }

        // Token: 0x060021F7 RID: 8695 RVA: 0x0014203A File Offset: 0x0014023A
        public DMS_LOGO_SEGA_OBJ_3DNN_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04004F42 RID: 20290
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004F43 RID: 20291
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004F44 RID: 20292
        public readonly AppMain.OBS_DATA_WORK data_work = new AppMain.OBS_DATA_WORK();
    }

    // Token: 0x020001A0 RID: 416
    public class DMS_LOGO_SEGA_OBJ_ES_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021F8 RID: 8696 RVA: 0x00142064 File Offset: 0x00140264
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060021F9 RID: 8697 RVA: 0x0014206C File Offset: 0x0014026C
        public static explicit operator AppMain.DMS_LOGO_SEGA_OBJ_ES_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_LOGO_SEGA_OBJ_ES_WORK )work.holder;
        }

        // Token: 0x060021FA RID: 8698 RVA: 0x00142079 File Offset: 0x00140279
        public DMS_LOGO_SEGA_OBJ_ES_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04004F45 RID: 20293
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004F46 RID: 20294
        public readonly AppMain.OBS_ACTION3D_ES_WORK obj_3des = new AppMain.OBS_ACTION3D_ES_WORK();

        // Token: 0x04004F47 RID: 20295
        public readonly AppMain.OBS_DATA_WORK data_work_texamb = new AppMain.OBS_DATA_WORK();

        // Token: 0x04004F48 RID: 20296
        public readonly AppMain.OBS_DATA_WORK data_work_texlist = new AppMain.OBS_DATA_WORK();

        // Token: 0x04004F49 RID: 20297
        public readonly AppMain.OBS_DATA_WORK data_work_model = new AppMain.OBS_DATA_WORK();
    }

    // Token: 0x020001A1 RID: 417
    // (Invoke) Token: 0x060021FC RID: 8700
    public delegate void DMS_LOGO_SEGA_WORK_Delegate( AppMain.DMS_LOGO_SEGA_WORK work );

    // Token: 0x020001A2 RID: 418
    public class DMS_LOGO_SEGA_WORK
    {
        // Token: 0x04004F4A RID: 20298
        public uint flag;

        // Token: 0x04004F4B RID: 20299
        public int timer;

        // Token: 0x04004F4C RID: 20300
        public AppMain.DMS_LOGO_SEGA_WORK_Delegate func;

        // Token: 0x04004F4D RID: 20301
        public AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[8];

        // Token: 0x04004F4E RID: 20302
        public AppMain.OBS_OBJECT_WORK ply_obj;

        // Token: 0x04004F4F RID: 20303
        public AppMain.OBS_OBJECT_WORK efct_obj;

        // Token: 0x04004F50 RID: 20304
        public AppMain.GSS_SND_SE_HANDLE h_se;
    }

    // Token: 0x1700001C RID: 28
    // (get) Token: 0x0600079F RID: 1951 RVA: 0x00043820 File Offset: 0x00041A20
    public static int dm_logo_sega_com_file_num
    {
        get
        {
            return AppMain.dm_logo_sega_com_fileinfo_list.Length;
        }
    }

    // Token: 0x1700001D RID: 29
    // (get) Token: 0x060007A0 RID: 1952 RVA: 0x00043829 File Offset: 0x00041A29
    private static int dm_logo_sega_localize_file_num
    {
        get
        {
            return AppMain.dm_logo_sega_localize_fileinfo_list_region_jp.Length;
        }
    }

    // Token: 0x060007A1 RID: 1953 RVA: 0x00043834 File Offset: 0x00041A34
    private void DmLogoSegaInit( object arg )
    {
        AppMain.AoAccountClearCurrentId();
        if ( this.DmLogoSegaBuildCheck() )
        {
            this.dmLogoSegaStart();
            return;
        }
        AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSegaLoadWait ), null, 0U, ushort.MaxValue, 4096U, 0, null, "DM_LSEGA_LW" );
        this.DmLogoSegaLoad();
    }

    // Token: 0x060007A2 RID: 1954 RVA: 0x00043880 File Offset: 0x00041A80
    private void DmLogoSegaLoad()
    {
        AppMain.GSE_REGION gse_REGION = AppMain.GsEnvGetRegion();
        this.DmLogoComLoadFileCreate( AppMain.dm_logo_sega_load_tcb );
        this.DmLogoComLoadFileReg( AppMain.dm_logo_sega_load_tcb, AppMain.dm_logo_sega_com_fileinfo_list, AppMain.dm_logo_sega_com_file_num );
        this.DmLogoComLoadFileReg( AppMain.dm_logo_sega_load_tcb, AppMain.dm_logo_sega_localize_fileinfo_list_tbl[( int )gse_REGION], AppMain.dm_logo_sega_localize_file_num );
        this.DmLogoComLoadFileStart( AppMain.dm_logo_sega_load_tcb );
    }

    // Token: 0x060007A3 RID: 1955 RVA: 0x000438D6 File Offset: 0x00041AD6
    private bool DmLogoSegaLoadCheck()
    {
        return AppMain.dm_logo_sega_load_tcb.Target == null && AppMain.dm_logo_sega_data[0] != null;
    }

    // Token: 0x060007A4 RID: 1956 RVA: 0x000438F0 File Offset: 0x00041AF0
    private void DmLogoSegaBuild()
    {
        AppMain.AMS_AMB_HEADER[] array = new AppMain.AMS_AMB_HEADER[2];
        AppMain.dm_logo_sega_build_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSegaDataBuildMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSegaDataBuildDest ), 0U, ushort.MaxValue, 4096U, 0, null, "DM_LSEGA_BUILD" );
        AppMain.g_obj.def_user_light_flag = 1U;
        AppMain.GmGameDBuildModelBuildInit();
        this.dm_logo_sega_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.dm_logo_sega_data[0], AppMain.dm_logo_sega_data[1], 0U );
        AppMain.dm_logo_sega_aos_tex = AppMain.New<AppMain.AOS_TEXTURE>( 2 );
        string dir;
        array[0] = AppMain.readAMBFile( AppMain.amBindGet( AppMain.dm_logo_sega_data[4], 1, out dir ) );
        array[0].dir = dir;
        array[1] = AppMain.readAMBFile( AppMain.amBindGet( AppMain.dm_logo_sega_data[3], 105, out dir ) );
        array[1].dir = dir;
        AppMain.AOS_TEXTURE[] array2 = AppMain.dm_logo_sega_aos_tex;
        for ( int i = 0; i < 2; i++ )
        {
            if ( array[i] != null )
            {
                AppMain.AoTexBuild( array2[i], array[i] );
                AppMain.AoTexLoad( array2[i] );
            }
        }
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.dm_logo_sega_efct_mdl_state[i] = AppMain.ObjAction3dESModelLoadToDwork( AppMain.dm_logo_sega_efct_mdl_data_work[i], ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.dm_logo_sega_data[3], AppMain.dm_logo_sega_efct_mdl_id_tbl[i] ), 0U );
        }
    }

    // Token: 0x060007A5 RID: 1957 RVA: 0x00043A10 File Offset: 0x00041C10
    private bool DmLogoSegaBuildCheck()
    {
        return AppMain.dm_logo_sega_build_state;
    }

    // Token: 0x060007A6 RID: 1958 RVA: 0x00043A1C File Offset: 0x00041C1C
    private void DmLogoSegaFlush()
    {
        AppMain.dm_logo_sega_flush_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSegaDataFlushMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSegaDataFlushDest ), 0U, ushort.MaxValue, 4096U, 0, null, "DM_TOP_FLUSH" );
        AppMain.GmGameDBuildModelFlushInit();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.dm_logo_sega_data[0];
        AppMain.GmGameDBuildRegFlushModel( this.dm_logo_sega_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.ArrayPointer<AppMain.AOS_TEXTURE> pointer = AppMain.dm_logo_sega_aos_tex;
        int i = 0;
        while ( i < 2 )
        {
            AppMain.AoTexRelease( pointer );
            i++;
            pointer = ++pointer;
        }
        for ( i = 0; i < 2; i++ )
        {
            AppMain.dm_logo_sega_efct_mdl_state[i] = AppMain.ObjAction3dESModelReleaseDwork( AppMain.dm_logo_sega_efct_mdl_data_work[i] );
        }
    }

    // Token: 0x060007A7 RID: 1959 RVA: 0x00043AC3 File Offset: 0x00041CC3
    private bool DmLogoSegaFlushCheck()
    {
        return !AppMain.dm_logo_sega_build_state;
    }

    // Token: 0x060007A8 RID: 1960 RVA: 0x00043AD0 File Offset: 0x00041CD0
    private void DmLogoSegaRelease()
    {
        for ( int i = 0; i < 5; i++ )
        {
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.dm_logo_sega_data[i];
            AppMain.dm_logo_sega_data[i] = null;
        }
    }

    // Token: 0x060007A9 RID: 1961 RVA: 0x00043AF9 File Offset: 0x00041CF9
    private bool DmLogoSegaReleaseCheck()
    {
        return AppMain.dm_logo_sega_load_tcb.Target == null && AppMain.dm_logo_sega_data[0] == null;
    }

    // Token: 0x060007AA RID: 1962 RVA: 0x00043B1C File Offset: 0x00041D1C
    private void dmLogoSegaStart()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_RGB nns_RGB = new AppMain.NNS_RGB(1f, 1f, 1f);
        this.dmLogoSegaObjSysytemInit();
        AppMain.GsSoundReset();
        AppMain.GsSoundBegin( 3, 32767U, 0 );
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(this.dmLogoSegaMainFunc), null, 0U, 0, 4096U, 0, () => new AppMain.DMS_LOGO_SEGA_WORK(), "DM_LSEGA_MAIN");
        AppMain.DMS_LOGO_SEGA_WORK dms_LOGO_SEGA_WORK = (AppMain.DMS_LOGO_SEGA_WORK)mts_TASK_TCB.work;
        AppMain.nnSetPrimitive3DMaterial( ref nns_RGBA, ref nns_RGB, 1f );
        AppMain.AoActSysSetDrawStateEnable( false );
        this.dmLogoSegaActionCreate( dms_LOGO_SEGA_WORK );
        dms_LOGO_SEGA_WORK.ply_obj = this.dmLogoSegaCreatePlayer();
        dms_LOGO_SEGA_WORK.timer = 0;
        dms_LOGO_SEGA_WORK.func = new AppMain.DMS_LOGO_SEGA_WORK_Delegate( this.dmLogoSegaStartWaitFunc );
        dms_LOGO_SEGA_WORK.h_se = AppMain.GsSoundAllocSeHandle();
    }

    // Token: 0x060007AB RID: 1963 RVA: 0x00043C0C File Offset: 0x00041E0C
    private void dmLogoSegaObjSysytemInit()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR pos = new AppMain.NNS_VECTOR(0f, 0f, 50f);
        AppMain.ObjInit( 4, 61435, 0, AppMain.GMD_OBJ_LCD_X, AppMain.GMD_OBJ_LCD_Y, ( float )AppMain.GSD_DISP_WIDTH, ( float )AppMain.GSD_DISP_HEIGHT );
        AppMain.ObjDataAlloc( 10 );
        AppMain.ObjDrawESEffectSystemInit( 0, 20480U, 0U );
        AppMain.ObjDrawSetNNCommandStateTbl( 0U, 0U, true );
        AppMain.AoActSysClearPeak();
        AppMain.g_obj.flag = 4259848U;
        AppMain.g_obj.ppPre = null;
        AppMain.g_obj.ppPost = null;
        AppMain.g_obj.ppCollision = null;
        AppMain.g_obj.ppObjPre = null;
        AppMain.g_obj.ppObjPost = null;
        AppMain.g_obj.ppRegRecAuto = null;
        AppMain.g_obj.draw_scale.x = ( AppMain.g_obj.draw_scale.y = ( AppMain.g_obj.draw_scale.z = 29127 ) );
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
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.ObjCameraInit( 0, pos, 0, 0, 6144 );
        AppMain.ObjCamera3dInit( 0 );
        AppMain.g_obj.glb_camera_id = 0;
        AppMain.g_obj.glb_camera_type = 1;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.user_func = new AppMain.OBJF_CAMERA_USER_FUNC( this.dmLogoSegaCamera );
        obs_CAMERA.command_state = 0U;
        obs_CAMERA.scale = 0.9f;
        obs_CAMERA.ofst.z = 1000f;
        this.amTrailEFInitialize();
    }

    // Token: 0x060007AC RID: 1964 RVA: 0x00043E6C File Offset: 0x0004206C
    private void dmLogoSegaPreEnd( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        AppMain.amTrailEFDeleteGroup( 1 );
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, ushort.MaxValue ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ushort.MaxValue ) )
        {
            obs_OBJECT_WORK.ppOut = null;
        }
    }

    // Token: 0x060007AD RID: 1965 RVA: 0x00043EA4 File Offset: 0x000420A4
    private void dmLogoSegaEnd( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        this.dmLogoSegaActionDelete( logo_work );
        AppMain.g_obj.ppPre = null;
        AppMain.ObjObjectClearAllObject();
        AppMain.ObjPreExit();
        AppMain.ObjDrawESEffectSystemExit();
        AppMain.ObjExit();
        AppMain.GsSoundStopSeHandle( logo_work.h_se );
        AppMain.GsSoundFreeSeHandle( logo_work.h_se );
        AppMain.GsSoundHalt();
        AppMain.GsSoundEnd();
        AppMain.GsSoundReset();
    }

    // Token: 0x060007AE RID: 1966 RVA: 0x00043EFC File Offset: 0x000420FC
    private void dmLogoSegaMainFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOGO_SEGA_WORK dms_LOGO_SEGA_WORK = (AppMain.DMS_LOGO_SEGA_WORK)tcb.work;
        if ( AppMain.GsSystemBgmIsPlay() )
        {
            dms_LOGO_SEGA_WORK.h_se.snd_ctrl_param.volume = 0f;
        }
        else
        {
            dms_LOGO_SEGA_WORK.h_se.snd_ctrl_param.volume = 1f;
        }
        if ( AppMain.AoSysIsShowPlatformUI() )
        {
            if ( AppMain.IzFadeIsExe() )
            {
                AppMain.IzFadeSetStopUpdate1Frame( null );
            }
        }
        else
        {
            if ( dms_LOGO_SEGA_WORK.func != null )
            {
                dms_LOGO_SEGA_WORK.func( dms_LOGO_SEGA_WORK );
            }
            if ( ( dms_LOGO_SEGA_WORK.flag & 1U ) != 0U )
            {
                this.dmLogoSegaPreEnd( dms_LOGO_SEGA_WORK );
                AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.gmLogoSegaPreEndWaitFunc ) );
                dms_LOGO_SEGA_WORK.timer = 0;
                return;
            }
        }
        float frame = 0f;
        if ( !AppMain.AoSysIsShowPlatformUI() && ( dms_LOGO_SEGA_WORK.flag & 2U ) != 0U )
        {
            frame = 1f;
        }
        AppMain.AoActSysSetDrawTaskPrio();
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_logo_sega_aos_tex[( int )AppMain.dm_logo_sega_tex_id_tbl[i]] ) );
            AppMain.AoActUpdate( dms_LOGO_SEGA_WORK.act[i], frame );
            AppMain.AoActDraw( dms_LOGO_SEGA_WORK.act[i] );
        }
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_RGB nns_RGB = new AppMain.NNS_RGB(1f, 1f, 1f);
        if ( !AppMain.AoSysIsShowPlatformUI() )
        {
            AppMain.amTrailEFUpdate( 1 );
        }
        if ( AppMain.g_obj.glb_camera_id != -1 )
        {
            AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
            AppMain.SNNS_VECTOR snns_VECTOR2 = default(AppMain.SNNS_VECTOR);
            AppMain.SNNS_MATRIX snns_MATRIX = default(AppMain.SNNS_MATRIX);
            AppMain.nnMakeUnitMatrix( ref snns_MATRIX );
            AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type, 0U );
            AppMain.ObjCameraDispPosGet( AppMain.g_obj.glb_camera_id, out snns_VECTOR );
            AppMain.amVectorSet( ref snns_VECTOR2, -snns_MATRIX.M03, -snns_MATRIX.M13, -snns_MATRIX.M23 );
            AppMain.nnAddVector( ref snns_VECTOR, ref snns_VECTOR2, ref snns_VECTOR );
            AppMain.amEffectSetCameraPos( ref snns_VECTOR );
        }
        AppMain.nnSetPrimitive3DMaterial( ref nns_RGBA, ref nns_RGB, 1f );
        AppMain.NNS_TEXLIST texlist = AppMain.dm_logo_sega_aos_tex[0].texlist;
        AppMain.amTrailEFDraw( 1, texlist, 0U );
    }

    // Token: 0x060007AF RID: 1967 RVA: 0x000440F0 File Offset: 0x000422F0
    private void gmLogoSegaPreEndWaitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOGO_SEGA_WORK dms_LOGO_SEGA_WORK = (AppMain.DMS_LOGO_SEGA_WORK)tcb.work;
        dms_LOGO_SEGA_WORK.timer++;
        if ( dms_LOGO_SEGA_WORK.timer > 2 )
        {
            this.dmLogoSegaEnd( dms_LOGO_SEGA_WORK );
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.gmLogoSegaEndWaitFunc ) );
        }
    }

    // Token: 0x060007B0 RID: 1968 RVA: 0x00044139 File Offset: 0x00042339
    private void gmLogoSegaEndWaitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.ObjObjectCheckClearAllObject() )
        {
            return;
        }
        if ( AppMain.ObjIsExitWait() )
        {
            return;
        }
        this.DmLogoSegaFlush();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.gmLogoSegaFlushWaitFunc ) );
    }

    // Token: 0x060007B1 RID: 1969 RVA: 0x00044163 File Offset: 0x00042363
    private void gmLogoSegaFlushWaitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !this.DmLogoSegaFlushCheck() )
        {
            return;
        }
        this.DmLogoSegaRelease();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.gmLogoSegaRelesehWaitFunc ) );
    }

    // Token: 0x060007B2 RID: 1970 RVA: 0x00044186 File Offset: 0x00042386
    private void gmLogoSegaRelesehWaitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !this.DmLogoSegaReleaseCheck() )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x060007B3 RID: 1971 RVA: 0x0004419C File Offset: 0x0004239C
    public static bool mppSountInitializationDelayExpired()
    {
        return true;
    }

    // Token: 0x060007B4 RID: 1972 RVA: 0x000441A0 File Offset: 0x000423A0
    private void dmLogoSegaStartWaitFunc( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        bool flag = true;
        logo_work.timer++;
        if ( !AppMain.mppSountInitializationDelayExpired() )
        {
            flag = false;
        }
        if ( logo_work.timer >= 0 && flag )
        {
            AppMain.IzFadeExit();
            logo_work.timer = 4;
            logo_work.func = new AppMain.DMS_LOGO_SEGA_WORK_Delegate( this.dmLogoSegaRunLeftFunc );
            this.dmLogoSegaPlayerInitSeqRunLeft( logo_work.ply_obj );
            logo_work.flag |= 2U;
            logo_work.efct_obj = this.dmLogoSegaCreateDashEffect( logo_work.ply_obj, 0 );
        }
    }

    // Token: 0x060007B5 RID: 1973 RVA: 0x00044220 File Offset: 0x00042420
    private void dmLogoSegaRunLeftFunc( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        logo_work.timer++;
        if ( logo_work.timer > 10 )
        {
            logo_work.timer = 0;
            logo_work.func = new AppMain.DMS_LOGO_SEGA_WORK_Delegate( this.dmLogoSegaRunRightWaitFunc );
            logo_work.efct_obj.flag |= 8U;
            logo_work.efct_obj = null;
        }
    }

    // Token: 0x060007B6 RID: 1974 RVA: 0x00044278 File Offset: 0x00042478
    private void dmLogoSegaRunRightWaitFunc( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        logo_work.timer++;
        if ( logo_work.timer > 25 )
        {
            logo_work.timer = 0;
            logo_work.func = new AppMain.DMS_LOGO_SEGA_WORK_Delegate( this.dmLogoSegaRunRightFunc );
            this.dmLogoSegaPlayerInitSeqRunRight( logo_work.ply_obj );
            logo_work.efct_obj = this.dmLogoSegaCreateDashEffect( logo_work.ply_obj, 1 );
        }
    }

    // Token: 0x060007B7 RID: 1975 RVA: 0x000442D8 File Offset: 0x000424D8
    private void dmLogoSegaRunRightFunc( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        logo_work.timer++;
        if ( logo_work.timer > 10 )
        {
            logo_work.timer = 0;
            logo_work.func = new AppMain.DMS_LOGO_SEGA_WORK_Delegate( this.dmLogoSegaDispWaitFunc );
            AppMain.GsSoundPlaySe( "Sega_Logo", logo_work.h_se );
            if ( AppMain.GsSystemBgmIsPlay() )
            {
                logo_work.h_se.snd_ctrl_param.volume = 0f;
            }
        }
    }

    // Token: 0x060007B8 RID: 1976 RVA: 0x00044342 File Offset: 0x00042542
    private void dmLogoSegaDispWaitFunc( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        logo_work.timer++;
        if ( logo_work.timer >= 180 )
        {
            logo_work.func = new AppMain.DMS_LOGO_SEGA_WORK_Delegate( this.dmLogoSegaFadeOutWaitFunc );
            AppMain.IzFadeInitEasy( 0U, 3U, 60f, true );
        }
    }

    // Token: 0x060007B9 RID: 1977 RVA: 0x0004437E File Offset: 0x0004257E
    private void dmLogoSegaFadeOutWaitFunc( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            logo_work.flag |= 1U;
        }
    }

    // Token: 0x060007BA RID: 1978 RVA: 0x0004439C File Offset: 0x0004259C
    private AppMain.OBS_OBJECT_WORK dmLogoSegaCreatePlayer()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(8192, 0, 0, 0, () => new AppMain.DMS_LOGO_SEGA_OBJ_3DNN_WORK(), "DM_LSEGA_PLY");
        AppMain.DMS_LOGO_SEGA_OBJ_3DNN_WORK dms_LOGO_SEGA_OBJ_3DNN_WORK = (AppMain.DMS_LOGO_SEGA_OBJ_3DNN_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.obj_type = 1;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
        obs_OBJECT_WORK.ppOutSub = null;
        obs_OBJECT_WORK.ppIn = null;
        obs_OBJECT_WORK.ppMove = null;
        obs_OBJECT_WORK.ppActCall = null;
        obs_OBJECT_WORK.ppRec = null;
        obs_OBJECT_WORK.ppLast = null;
        obs_OBJECT_WORK.ppFunc = null;
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = dms_LOGO_SEGA_OBJ_3DNN_WORK.obj_3d;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, this.dm_logo_sega_obj_3d_list[0], obj_3d );
        AppMain.ObjDrawSetToon( obj_3d );
        obj_3d.command_state = 0U;
        AppMain.ObjDataSet( dms_LOGO_SEGA_OBJ_3DNN_WORK.data_work, AppMain.dm_logo_sega_data[2] );
        AppMain.OBS_DATA_WORK data_work = dms_LOGO_SEGA_OBJ_3DNN_WORK.data_work;
        data_work.num |= 32768;
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, dms_LOGO_SEGA_OBJ_3DNN_WORK.data_work, null, 0, null, 136, 16 );
        obs_OBJECT_WORK.disp_flag |= 16777728U;
        obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = ( obs_OBJECT_WORK.scale.z = 8192 ) );
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx_r );
        AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx_r, obj_3d.user_obj_mtx_r, 0f, -36f / AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.draw_scale.y ), 0f );
        obs_OBJECT_WORK.pos.x = 2490368;
        obs_OBJECT_WORK.pos.y = 0;
        obs_OBJECT_WORK.pos.z = 0;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060007BB RID: 1979 RVA: 0x0004453C File Offset: 0x0004273C
    private void dmLogoSegaPlayerInitSeqRunLeft( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = 2490368;
        AppMain.ObjDrawObjectActionSet( obj_work, 77 );
        obj_work.disp_flag |= 5U;
        this.dmLogoSegaCreateTrail( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmLogoSegaPlayerSeqRunLeft );
    }

    // Token: 0x060007BC RID: 1980 RVA: 0x00044588 File Offset: 0x00042788
    private void dmLogoSegaPlayerSeqRunLeft( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.AoSysIsShowPlatformUI() )
        {
            obj_work.disp_flag |= 4096U;
            return;
        }
        obj_work.disp_flag &= 4294963199U;
        obj_work.pos.x = obj_work.pos.x + -495616;
    }

    // Token: 0x060007BD RID: 1981 RVA: 0x000445D8 File Offset: 0x000427D8
    private void dmLogoSegaPlayerInitSeqRunRight( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = -2490368;
        AppMain.ObjDrawObjectActionSet( obj_work, 9 );
        obj_work.disp_flag &= 4294967294U;
        obj_work.disp_flag |= 4U;
        this.dmLogoSegaCreateTrail( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmLogoSegaPlayerSeqRunRight );
    }

    // Token: 0x060007BE RID: 1982 RVA: 0x00044634 File Offset: 0x00042834
    private void dmLogoSegaPlayerSeqRunRight( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.AoSysIsShowPlatformUI() )
        {
            obj_work.disp_flag |= 4096U;
            return;
        }
        obj_work.disp_flag &= 4294963199U;
        obj_work.pos.x = obj_work.pos.x + 495616;
    }

    // Token: 0x060007BF RID: 1983 RVA: 0x0004468C File Offset: 0x0004288C
    private AppMain.OBS_OBJECT_WORK dmLogoSegaCreateDashEffect( AppMain.OBS_OBJECT_WORK parent_obj, int type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(12288, 0, 0, 0, () => new AppMain.DMS_LOGO_SEGA_OBJ_ES_WORK(), "DM_LSEGA_EFCT");
        AppMain.DMS_LOGO_SEGA_OBJ_ES_WORK dms_LOGO_SEGA_OBJ_ES_WORK = (AppMain.DMS_LOGO_SEGA_OBJ_ES_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.obj_type = 2;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
        obs_OBJECT_WORK.ppOutSub = null;
        obs_OBJECT_WORK.ppIn = null;
        obs_OBJECT_WORK.ppMove = null;
        obs_OBJECT_WORK.ppActCall = null;
        obs_OBJECT_WORK.ppRec = null;
        obs_OBJECT_WORK.ppLast = null;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( this.dmLogoSegaEffectMain );
        obs_OBJECT_WORK.parent_obj = parent_obj;
        obs_OBJECT_WORK.pos.Assign( parent_obj.pos );
        int index;
        if ( type == 1 )
        {
            index = 53;
        }
        else
        {
            index = 52;
        }
        AppMain.ObjObjectAction3dESEffectLoad( obs_OBJECT_WORK, dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des, null, null, index, AppMain.dm_logo_sega_data[3], 0, 0 );
        dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des.command_state = 0U;
        AppMain.ObjDataSet( dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texamb, AppMain.amBindGet( AppMain.dm_logo_sega_data[3], 97 ) );
        AppMain.OBS_DATA_WORK data_work_texamb = dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texamb;
        data_work_texamb.num |= 32768;
        AppMain.ObjDataSet( dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texlist, AppMain.dm_logo_sega_aos_tex[1].texlist );
        AppMain.OBS_DATA_WORK data_work_texlist = dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texlist;
        data_work_texlist.num |= 32768;
        AppMain.ObjObjectAction3dESTextureLoad( obs_OBJECT_WORK, dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des, dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texamb, null, 0, null, false );
        AppMain.ObjObjectAction3dESTextureSetByDwork( obs_OBJECT_WORK, dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texlist );
        AppMain.ObjDataSet( dms_LOGO_SEGA_OBJ_ES_WORK.data_work_model, AppMain.amBindGet( AppMain.dm_logo_sega_data[3], AppMain.dm_logo_sega_efct_mdl_id_tbl[type] ) );
        AppMain.OBS_DATA_WORK data_work_texlist2 = dms_LOGO_SEGA_OBJ_ES_WORK.data_work_texlist;
        data_work_texlist2.num |= 32768;
        AppMain.ObjObjectAction3dESModelLoad( obs_OBJECT_WORK, dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des, dms_LOGO_SEGA_OBJ_ES_WORK.data_work_model, null, 0, null, 0U, false );
        AppMain.ObjObjectAction3dESModelSetByDwork( obs_OBJECT_WORK, AppMain.dm_logo_sega_efct_mdl_data_work[type] );
        dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des.disp_rot.x = 0;
        dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des.disp_rot.y = 0;
        dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des.disp_rot.z = 0;
        obs_OBJECT_WORK.scale.x = AppMain.FX_Mul( parent_obj.scale.x, AppMain.g_obj.draw_scale.x );
        obs_OBJECT_WORK.scale.y = AppMain.FX_Mul( parent_obj.scale.y, AppMain.g_obj.draw_scale.y );
        obs_OBJECT_WORK.scale.z = AppMain.FX_Mul( parent_obj.scale.z, AppMain.g_obj.draw_scale.z );
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        dms_LOGO_SEGA_OBJ_ES_WORK.obj_3des.flag |= 8U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060007C0 RID: 1984 RVA: 0x00044924 File Offset: 0x00042B24
    private void dmLogoSegaEffectMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        if ( AppMain.AoSysIsShowPlatformUI() )
        {
            obj_work.disp_flag |= 4096U;
            return;
        }
        obj_work.disp_flag &= 4294963199U;
        obj_work.pos.Assign( parent_obj.pos );
        if ( ( obj_work.parent_obj.disp_flag & 1U ) != 0U )
        {
            obj_work.pos.x = obj_work.pos.x - -81920;
        }
        else
        {
            obj_work.pos.x = obj_work.pos.x + -81920;
        }
        obj_work.pos.y = obj_work.pos.y + 409600;
        obj_work.pos.z = obj_work.pos.z + 409600;
        obj_work.disp_flag &= 4294967294U;
        obj_work.disp_flag |= ( parent_obj.disp_flag & 1U );
    }

    // Token: 0x060007C1 RID: 1985 RVA: 0x00044A08 File Offset: 0x00042C08
    private void dmLogoSegaCreateTrail( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.NNS_TEXLIST texlist = AppMain.dm_logo_sega_aos_tex[0].texlist;
        AppMain.AMS_TRAIL_PARAM ams_TRAIL_PARAM = new AppMain.AMS_TRAIL_PARAM();
        ams_TRAIL_PARAM.startColor.r = 0f;
        ams_TRAIL_PARAM.startColor.g = 0f;
        ams_TRAIL_PARAM.startColor.b = 1f;
        ams_TRAIL_PARAM.startColor.a = 1f;
        ams_TRAIL_PARAM.endColor.r = 0f;
        ams_TRAIL_PARAM.endColor.g = 0f;
        ams_TRAIL_PARAM.endColor.b = 1f;
        ams_TRAIL_PARAM.endColor.a = 0f;
        ams_TRAIL_PARAM.startSize = 88f;
        ams_TRAIL_PARAM.endSize = 88f;
        ams_TRAIL_PARAM.life = 35f;
        ams_TRAIL_PARAM.vanish_time = 10f;
        ams_TRAIL_PARAM.trail_obj_work = obj_work;
        ams_TRAIL_PARAM.partsNum = 63;
        ams_TRAIL_PARAM.zBias = -65536f;
        ams_TRAIL_PARAM.texId = texlist.nTex - 1;
        ams_TRAIL_PARAM.blendType = 0;
        ams_TRAIL_PARAM.zTest = 1;
        AppMain.amTrailMakeEffect( ams_TRAIL_PARAM, 1, 1 );
    }

    // Token: 0x060007C2 RID: 1986 RVA: 0x00044B14 File Offset: 0x00042D14
    private void dmLogoSegaCamera( AppMain.OBS_CAMERA camera )
    {
        camera.disp_pos.x = 0f;
        camera.disp_pos.y = 0f;
        camera.disp_pos.z = 200f;
        camera.target_pos.x = 0f;
        camera.target_pos.y = 0f;
        camera.target_pos.z = 0f;
    }

    // Token: 0x060007C3 RID: 1987 RVA: 0x00044B81 File Offset: 0x00042D81
    private static void dmLogoSegaLoadPostFunc( AppMain.DMS_LOGO_COM_LOAD_CONTEXT context )
    {
        AppMain.dm_logo_sega_data[context.no] = AppMain.readAMBFile( context.fs_req );
    }

    // Token: 0x060007C4 RID: 1988 RVA: 0x00044B9C File Offset: 0x00042D9C
    private void dmLogoSegaDataBuildMain( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        if ( !AppMain.GmGameDBuildCheckBuildModel() )
        {
            flag = false;
        }
        AppMain.ArrayPointer<AppMain.AOS_TEXTURE> pointer = AppMain.dm_logo_sega_aos_tex;
        int i = 0;
        while ( i < 2 )
        {
            if ( !AppMain.AoTexIsLoaded( pointer ) )
            {
                flag = false;
            }
            i++;
            pointer = ++pointer;
        }
        for ( i = 0; i < 2; i++ )
        {
            if ( AppMain.dm_logo_sega_efct_mdl_state[i] != -1 && !AppMain.amDrawIsRegistComplete( AppMain.dm_logo_sega_efct_mdl_state[i] ) )
            {
                flag = false;
                AppMain.dm_logo_sega_efct_mdl_state[i] = -1;
            }
        }
        if ( !flag )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
        AppMain.dm_logo_sega_build_state = true;
    }

    // Token: 0x060007C5 RID: 1989 RVA: 0x00044C1F File Offset: 0x00042E1F
    private void dmLogoSegaDataBuildDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_logo_sega_build_tcb = null;
    }

    // Token: 0x060007C6 RID: 1990 RVA: 0x00044C28 File Offset: 0x00042E28
    private void dmLogoSegaDataFlushMain( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        if ( !AppMain.GmGameDBuildCheckFlushModel() )
        {
            flag = false;
        }
        AppMain.ArrayPointer<AppMain.AOS_TEXTURE> pointer = AppMain.dm_logo_sega_aos_tex;
        int i = 0;
        while ( i < 2 )
        {
            if ( !AppMain.AoTexIsReleased( pointer ) )
            {
                flag = false;
            }
            i++;
            pointer = ++pointer;
        }
        for ( i = 0; i < 2; i++ )
        {
            if ( AppMain.dm_logo_sega_efct_mdl_state[i] != -1 )
            {
                if ( AppMain.ObjAction3dESModelReleaseDworkCheck( AppMain.dm_logo_sega_efct_mdl_data_work[i], AppMain.dm_logo_sega_efct_mdl_state[i] ) )
                {
                    AppMain.dm_logo_sega_efct_mdl_state[i] = -1;
                }
                else
                {
                    flag = false;
                }
            }
        }
        if ( !flag )
        {
            return;
        }
        AppMain.dm_logo_sega_aos_tex = null;
        this.dm_logo_sega_obj_3d_list = null;
        AppMain.mtTaskClearTcb( tcb );
        AppMain.dm_logo_sega_build_state = false;
    }

    // Token: 0x060007C7 RID: 1991 RVA: 0x00044CC1 File Offset: 0x00042EC1
    private void dmLogoSegaDataFlushDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_logo_sega_flush_tcb = null;
    }

    // Token: 0x060007C8 RID: 1992 RVA: 0x00044CC9 File Offset: 0x00042EC9
    private void dmLogoSegaLoadWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( this.DmLogoSegaLoadCheck() )
        {
            this.DmLogoSegaBuild();
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSegaBuildWait ) );
        }
    }

    // Token: 0x060007C9 RID: 1993 RVA: 0x00044CEB File Offset: 0x00042EEB
    private void dmLogoSegaBuildWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( this.DmLogoSegaBuildCheck() )
        {
            AppMain.mtTaskClearTcb( tcb );
            this.dmLogoSegaStart();
        }
    }

    // Token: 0x060007CA RID: 1994 RVA: 0x00044D04 File Offset: 0x00042F04
    private void dmLogoSegaActionCreate( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        AppMain.A2S_AMA_HEADER ama = AppMain.readAMAFile(AppMain.amBindGet(AppMain.dm_logo_sega_data[4], 0));
        for ( uint num = 0U; num < 8U; num += 1U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_logo_sega_aos_tex[( int )AppMain.dm_logo_sega_tex_id_tbl[( int )( ( UIntPtr )num )]] ) );
            logo_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, num );
        }
    }

    // Token: 0x060007CB RID: 1995 RVA: 0x00044D58 File Offset: 0x00042F58
    private void dmLogoSegaActionDelete( AppMain.DMS_LOGO_SEGA_WORK logo_work )
    {
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.AoActDelete( logo_work.act[i] );
        }
    }
}
