using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000292 RID: 658
    public class GMS_WATER_SURFACE_DATA
    {
        // Token: 0x06002439 RID: 9273 RVA: 0x0014A6B2 File Offset: 0x001488B2
        internal void Clear()
        {
            this.amb_header = null;
            this.flag_load_object = false;
        }

        // Token: 0x04005A64 RID: 23140
        public AppMain.AMS_AMB_HEADER amb_header;

        // Token: 0x04005A65 RID: 23141
        public bool flag_load_object;
    }

    // Token: 0x02000293 RID: 659
    public class GMS_WATER_SURFACE_INFO
    {
        // Token: 0x04005A66 RID: 23142
        public float now_water_level;

        // Token: 0x04005A67 RID: 23143
        public float next_water_level;

        // Token: 0x04005A68 RID: 23144
        public ushort water_time;

        // Token: 0x04005A69 RID: 23145
        public ushort water_counter;

        // Token: 0x04005A6A RID: 23146
        public bool flag_draw;

        // Token: 0x04005A6B RID: 23147
        public bool flag_enable_ref;
    }

    // Token: 0x02000294 RID: 660
    public class GMS_WATER_SURFACE_MGR
    {
        // Token: 0x0600243C RID: 9276 RVA: 0x0014A6D2 File Offset: 0x001488D2
        internal void Clear()
        {
            this.tcb_water = null;
            this.render_target = null;
        }

        // Token: 0x04005A6C RID: 23148
        public AppMain.MTS_TASK_TCB tcb_water;

        // Token: 0x04005A6D RID: 23149
        public AppMain.AMS_RENDER_TARGET render_target;
    }

    // Token: 0x06001168 RID: 4456 RVA: 0x00098DC9 File Offset: 0x00096FC9
    private static void GmWaterSurfaceInitData( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.gmWaterSurfaceDataInit();
        AppMain.gmWaterSurfaceDataSetAmbHeader( amb );
    }

    // Token: 0x06001169 RID: 4457 RVA: 0x00098DD8 File Offset: 0x00096FD8
    private static void GmWaterSurfaceBuildData()
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.dwaterInit();
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.gmWaterSurfaceDataGetAmbHeader();
            AppMain.AoTexBuild( AppMain._dmap_water.tex_color, AppMain.readAMBFile( AppMain.amBindGet( ams_AMB_HEADER, ams_AMB_HEADER.file_num - 1 ) ) );
            AppMain.AoTexLoad( AppMain._dmap_water.tex_color );
            AppMain.dwaterSetObjectAMB( ams_AMB_HEADER, ams_AMB_HEADER );
            uint objflag = 0U;
            AppMain.dwaterLoadObject( objflag );
        }
    }

    // Token: 0x0600116A RID: 4458 RVA: 0x00098E44 File Offset: 0x00097044
    private static bool GmWaterSurfaceCheckLoading()
    {
        bool result = true;
        if ( AppMain.GsMainSysGetDisplayListRegistNum() >= 192 )
        {
            return false;
        }
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.GMS_WATER_SURFACE_DATA gms_WATER_SURFACE_DATA = AppMain.gmWaterSurfaceDataGetInfo();
            if ( !AppMain.AoTexIsLoaded( AppMain._dmap_water.tex_color ) )
            {
                result = false;
            }
            else if ( !gms_WATER_SURFACE_DATA.flag_load_object )
            {
                uint objflag = 0U;
                if ( AppMain.dwaterLoadObject( objflag ) == 0 )
                {
                    result = false;
                    gms_WATER_SURFACE_DATA.flag_load_object = false;
                }
                else
                {
                    gms_WATER_SURFACE_DATA.flag_load_object = true;
                }
            }
        }
        return result;
    }

    // Token: 0x0600116B RID: 4459 RVA: 0x00098EB8 File Offset: 0x000970B8
    private static void GmWaterSurfaceInit()
    {
        AppMain.gmWaterSurfaceGameSystemSetWaterLevel( ushort.MaxValue );
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.gmWaterSurfaceInitMgr();
            AppMain.gmWaterSurfaceCreateTcb();
        }
    }

    // Token: 0x0600116C RID: 4460 RVA: 0x00098EEB File Offset: 0x000970EB
    private static void GmWaterSurfaceExit()
    {
        AppMain.gmWaterSurfaceExitMgr();
    }

    // Token: 0x0600116D RID: 4461 RVA: 0x00098EF4 File Offset: 0x000970F4
    private static void GmWaterSurfaceFlushData()
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.AoTexRelease( AppMain._dmap_water.tex_color );
        }
    }

    // Token: 0x0600116E RID: 4462 RVA: 0x00098F24 File Offset: 0x00097124
    private static void GmWaterSurfaceRelease()
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.gmWaterSurfaceDataRelease();
        }
    }

    // Token: 0x0600116F RID: 4463 RVA: 0x00098F48 File Offset: 0x00097148
    private static bool GmWaterSurfaceCheckFlush()
    {
        if ( AppMain.GsMainSysGetDisplayListRegistNum() >= 192 )
        {
            return false;
        }
        bool result = true;
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 && AppMain._dmap_water != null )
        {
            if ( !AppMain.AoTexIsReleased( AppMain._dmap_water.tex_color ) )
            {
                result = false;
            }
            else if ( AppMain._dmap_water.regist_index == -1 )
            {
                AppMain._dmap_water.regist_index = AppMain.dwaterRelease();
                result = false;
            }
            else if ( !AppMain.amDrawIsRegistComplete( AppMain._dmap_water.regist_index ) )
            {
                result = false;
            }
            else
            {
                AppMain.dwaterExit();
            }
        }
        return result;
    }

    // Token: 0x06001170 RID: 4464 RVA: 0x00098FD4 File Offset: 0x000971D4
    private static void GmWaterSurfaceRequestChangeWaterLevel( ushort water_level, ushort time, bool flag_add_time )
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
            if ( gms_WATER_SURFACE_MGR == null )
            {
                return;
            }
            AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO = (AppMain.GMS_WATER_SURFACE_INFO)gms_WATER_SURFACE_MGR.tcb_water.work;
            if ( flag_add_time )
            {
                AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO2 = gms_WATER_SURFACE_INFO;
                gms_WATER_SURFACE_INFO2.water_time += time;
            }
            else
            {
                gms_WATER_SURFACE_INFO.water_time = time;
                gms_WATER_SURFACE_INFO.water_counter = 0;
            }
            gms_WATER_SURFACE_INFO.next_water_level = ( float )water_level;
            gms_WATER_SURFACE_INFO.now_water_level = ( float )AppMain.gmWaterSurfaceGameSystemGetWaterLevel();
        }
    }

    // Token: 0x06001171 RID: 4465 RVA: 0x00099044 File Offset: 0x00097244
    private static void GmWaterSurfaceRequestAddWatarLevel( float water_level, ushort time, bool flag_add_time )
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
            if ( gms_WATER_SURFACE_MGR == null )
            {
                return;
            }
            AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO = (AppMain.GMS_WATER_SURFACE_INFO)gms_WATER_SURFACE_MGR.tcb_water.work;
            if ( flag_add_time )
            {
                AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO2 = gms_WATER_SURFACE_INFO;
                gms_WATER_SURFACE_INFO2.water_time += time;
            }
            else
            {
                gms_WATER_SURFACE_INFO.water_time = time;
                gms_WATER_SURFACE_INFO.water_counter = 0;
            }
            gms_WATER_SURFACE_INFO.next_water_level += water_level;
            gms_WATER_SURFACE_INFO.now_water_level = ( float )AppMain.gmWaterSurfaceGameSystemGetWaterLevel();
        }
    }

    // Token: 0x06001172 RID: 4466 RVA: 0x000990BC File Offset: 0x000972BC
    private static void GmWaterSurfaceSetFlagDraw( bool flag_draw )
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
            if ( gms_WATER_SURFACE_MGR == null )
            {
                return;
            }
            AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO = (AppMain.GMS_WATER_SURFACE_INFO)gms_WATER_SURFACE_MGR.tcb_water.work;
            gms_WATER_SURFACE_INFO.flag_draw = flag_draw;
        }
    }

    // Token: 0x06001173 RID: 4467 RVA: 0x000990FC File Offset: 0x000972FC
    private static void GmWaterSurfaceSetFlagEnableRef( bool flag_enable_ref )
    {
        int stage_id = AppMain.gmWaterSurfaceGameSystemGetStageId();
        int num = AppMain.gmWaterSurfaceGameSystemGetZoneType(stage_id);
        if ( num == 2 )
        {
            AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
            if ( gms_WATER_SURFACE_MGR == null )
            {
                return;
            }
            AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO = (AppMain.GMS_WATER_SURFACE_INFO)gms_WATER_SURFACE_MGR.tcb_water.work;
            gms_WATER_SURFACE_INFO.flag_enable_ref = flag_enable_ref;
        }
    }

    // Token: 0x06001174 RID: 4468 RVA: 0x0009913C File Offset: 0x0009733C
    private static AppMain.AMS_RENDER_TARGET GmWaterSurfaceGetRenderTarget()
    {
        AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
        if ( gms_WATER_SURFACE_MGR == null )
        {
            return null;
        }
        return gms_WATER_SURFACE_MGR.render_target;
    }

    // Token: 0x06001175 RID: 4469 RVA: 0x0009915C File Offset: 0x0009735C
    private static void GmWaterSurfaceDrawNoWaterField( float left, float top, float right, float bottom )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
        ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
        AppMain.NNS_PRIM3D_PC[] array = AppMain.amDrawAlloc_NNS_PRIM3D_PC(6);
        float z = AppMain.FX_FX32_TO_F32(1310720);
        array[0].Pos.Assign( left, top, z );
        array[1].Pos.Assign( right, top, z );
        array[2].Pos.Assign( left, bottom, z );
        array[5].Pos.Assign( right, bottom, z );
        uint col = AppMain.AMD_RGBA8888(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
        array[0].Col = col;
        array[1].Col = col;
        array[2].Col = col;
        array[5].Col = col;
        array[3] = array[1];
        array[4] = array[2];
        ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
        ams_PARAM_DRAW_PRIMITIVE.type = 0;
        ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = array;
        ams_PARAM_DRAW_PRIMITIVE.texlist = null;
        ams_PARAM_DRAW_PRIMITIVE.texId = 0;
        ams_PARAM_DRAW_PRIMITIVE.count = 6;
        ams_PARAM_DRAW_PRIMITIVE.sortZ = -1f;
        AppMain.gmWaterSurfaceMatrixPush( 9U );
        AppMain.amDrawPrimitive3D( 9U, ams_PARAM_DRAW_PRIMITIVE );
        AppMain.gmWaterSurfaceMatrixPop( 9U );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x06001176 RID: 4470 RVA: 0x000992BF File Offset: 0x000974BF
    private static int gmWaterSurfaceGameSystemGetStageId()
    {
        return ( int )AppMain.g_gs_main_sys_info.stage_id;
    }

    // Token: 0x06001177 RID: 4471 RVA: 0x000992CB File Offset: 0x000974CB
    private static int gmWaterSurfaceGameSystemGetZoneType( int stage_id )
    {
        return AppMain.g_gm_gamedat_zone_type_tbl[stage_id];
    }

    // Token: 0x06001178 RID: 4472 RVA: 0x000992D4 File Offset: 0x000974D4
    private static ushort gmWaterSurfaceGameSystemGetWaterLevel()
    {
        return AppMain.g_gm_main_system.water_level;
    }

    // Token: 0x06001179 RID: 4473 RVA: 0x000992E0 File Offset: 0x000974E0
    private static void gmWaterSurfaceGameSystemSetWaterLevel( ushort water_level )
    {
        AppMain.g_gm_main_system.water_level = water_level;
    }

    // Token: 0x0600117A RID: 4474 RVA: 0x000992ED File Offset: 0x000974ED
    private static void gmWaterSurfaceDataInit()
    {
        AppMain.g_water_surface_data_real.Clear();
        AppMain.g_water_surface_data = AppMain.g_water_surface_data_real;
    }

    // Token: 0x0600117B RID: 4475 RVA: 0x00099303 File Offset: 0x00097503
    private static void gmWaterSurfaceDataRelease()
    {
        if ( AppMain.g_water_surface_data != null )
        {
            AppMain.gmWaterSurfaceDataReleaseAmbHeader();
            AppMain.g_water_surface_data = null;
        }
    }

    // Token: 0x0600117C RID: 4476 RVA: 0x00099317 File Offset: 0x00097517
    private static AppMain.GMS_WATER_SURFACE_DATA gmWaterSurfaceDataGetInfo()
    {
        return AppMain.g_water_surface_data;
    }

    // Token: 0x0600117D RID: 4477 RVA: 0x00099320 File Offset: 0x00097520
    private static void gmWaterSurfaceDataSetAmbHeader( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.GMS_WATER_SURFACE_DATA gms_WATER_SURFACE_DATA = AppMain.gmWaterSurfaceDataGetInfo();
        gms_WATER_SURFACE_DATA.amb_header = amb;
    }

    // Token: 0x0600117E RID: 4478 RVA: 0x0009933C File Offset: 0x0009753C
    private static AppMain.AMS_AMB_HEADER gmWaterSurfaceDataGetAmbHeader()
    {
        AppMain.GMS_WATER_SURFACE_DATA gms_WATER_SURFACE_DATA = AppMain.gmWaterSurfaceDataGetInfo();
        return gms_WATER_SURFACE_DATA.amb_header;
    }

    // Token: 0x0600117F RID: 4479 RVA: 0x00099358 File Offset: 0x00097558
    private static void gmWaterSurfaceDataReleaseAmbHeader()
    {
        AppMain.GMS_WATER_SURFACE_DATA gms_WATER_SURFACE_DATA = AppMain.gmWaterSurfaceDataGetInfo();
        if ( gms_WATER_SURFACE_DATA.amb_header != null )
        {
            gms_WATER_SURFACE_DATA.amb_header = null;
        }
    }

    // Token: 0x06001180 RID: 4480 RVA: 0x0009937A File Offset: 0x0009757A
    private static AppMain.GMS_WATER_SURFACE_MGR gmWaterSurfaceGetMgr()
    {
        return AppMain.g_water_surface_mgr;
    }

    // Token: 0x06001181 RID: 4481 RVA: 0x00099381 File Offset: 0x00097581
    private static void gmWaterSurfaceInitMgr()
    {
        AppMain.g_water_surface_mgr_real.Clear();
        AppMain.g_water_surface_mgr = AppMain.g_water_surface_mgr_real;
    }

    // Token: 0x06001182 RID: 4482 RVA: 0x00099397 File Offset: 0x00097597
    private static void gmWaterSurfaceExitMgr()
    {
        if ( AppMain.g_water_surface_mgr != null )
        {
            AppMain.gmWaterSurfaceDeleteTcb();
            AppMain.g_water_surface_mgr = null;
        }
    }

    // Token: 0x06001183 RID: 4483 RVA: 0x000993B4 File Offset: 0x000975B4
    private static AppMain.MTS_TASK_TCB gmWaterSurfaceCreateTcb()
    {
        AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
        gms_WATER_SURFACE_MGR.tcb_water = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmWaterSurfaceProc ), null, 0U, 0, 8202U, 5, () => new AppMain.GMS_WATER_SURFACE_INFO(), "GM WATER SURFACE" );
        AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO = (AppMain.GMS_WATER_SURFACE_INFO)gms_WATER_SURFACE_MGR.tcb_water.work;
        gms_WATER_SURFACE_INFO.now_water_level = ( float )AppMain.gmWaterSurfaceGameSystemGetWaterLevel();
        gms_WATER_SURFACE_INFO.next_water_level = 65535f;
        gms_WATER_SURFACE_INFO.water_time = 0;
        gms_WATER_SURFACE_INFO.water_counter = 0;
        gms_WATER_SURFACE_INFO.flag_draw = true;
        gms_WATER_SURFACE_INFO.flag_enable_ref = true;
        return gms_WATER_SURFACE_MGR.tcb_water;
    }

    // Token: 0x06001184 RID: 4484 RVA: 0x00099454 File Offset: 0x00097654
    private static void gmWaterSurfaceDeleteTcb()
    {
        AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
        if ( gms_WATER_SURFACE_MGR.tcb_water != null )
        {
            AppMain.mtTaskClearTcb( gms_WATER_SURFACE_MGR.tcb_water );
            gms_WATER_SURFACE_MGR.tcb_water = null;
        }
    }

    // Token: 0x06001185 RID: 4485 RVA: 0x00099484 File Offset: 0x00097684
    private static void gmWaterSurfaceTcbProcPreDrawDT( object data )
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
        AppMain.amDrawEndScene();
        AppMain.NNS_RGBA_U8 color = new AppMain.NNS_RGBA_U8(0, 0, 0, byte.MaxValue);
        AppMain.amRenderCopyTarget( ams_RENDER_TARGET, color );
        AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
        if ( gms_WATER_SURFACE_MGR != null )
        {
            gms_WATER_SURFACE_MGR.render_target = ams_RENDER_TARGET;
        }
    }

    // Token: 0x06001186 RID: 4486 RVA: 0x000994E8 File Offset: 0x000976E8
    private static void gmWaterSurfaceTcbProcDrawDT( object data )
    {
        AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
        if ( gms_WATER_SURFACE_MGR == null || gms_WATER_SURFACE_MGR.render_target == null || gms_WATER_SURFACE_MGR.render_target.width == 0 )
        {
            return;
        }
        AppMain.dwaterDrawWater( gms_WATER_SURFACE_MGR.render_target );
    }

    // Token: 0x06001187 RID: 4487 RVA: 0x0009951F File Offset: 0x0009771F
    private static void gmWaterSurfaceTcbProcPostDrawDT( object data )
    {
    }

    // Token: 0x06001188 RID: 4488 RVA: 0x00099524 File Offset: 0x00097724
    private static void gmWaterSurfaceProc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO = (AppMain.GMS_WATER_SURFACE_INFO)tcb.work;
        float speed = 0f;
        if ( AppMain.ObjObjectPauseCheck( 0U ) == 0U )
        {
            float num = (float)(gms_WATER_SURFACE_INFO.water_time - gms_WATER_SURFACE_INFO.water_counter);
            if ( num != 0f )
            {
                float num2 = (gms_WATER_SURFACE_INFO.next_water_level - gms_WATER_SURFACE_INFO.now_water_level) / num;
                gms_WATER_SURFACE_INFO.now_water_level += num2;
                if ( 1 > ( ushort )AppMain.MTM_MATH_ABS( gms_WATER_SURFACE_INFO.now_water_level - gms_WATER_SURFACE_INFO.next_water_level ) )
                {
                    gms_WATER_SURFACE_INFO.water_time = 0;
                    gms_WATER_SURFACE_INFO.water_counter = 0;
                }
                else
                {
                    AppMain.GMS_WATER_SURFACE_INFO gms_WATER_SURFACE_INFO2 = gms_WATER_SURFACE_INFO;
                    gms_WATER_SURFACE_INFO2.water_counter += 1;
                }
            }
            else
            {
                gms_WATER_SURFACE_INFO.now_water_level = gms_WATER_SURFACE_INFO.next_water_level;
            }
            if ( !gms_WATER_SURFACE_INFO.flag_draw )
            {
                AppMain.gmWaterSurfaceGameSystemSetWaterLevel( ushort.MaxValue );
                return;
            }
            AppMain.gmWaterSurfaceGameSystemSetWaterLevel( ( ushort )gms_WATER_SURFACE_INFO.now_water_level );
            speed = AppMain.amSystemGetFrameRateMain();
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(6);
        float x = obs_CAMERA.disp_pos.x;
        float num3 = obs_CAMERA.disp_pos.y;
        float num4 = -gms_WATER_SURFACE_INFO.now_water_level - num3;
        if ( num4 < ( float )( -( float )( AppMain.OBD_LCD_Y / 2 + 32 ) ) )
        {
            AppMain.GMS_WATER_SURFACE_MGR gms_WATER_SURFACE_MGR = AppMain.gmWaterSurfaceGetMgr();
            if ( gms_WATER_SURFACE_MGR != null )
            {
                gms_WATER_SURFACE_MGR.render_target = null;
            }
            return;
        }
        bool flag = false;
        if ( num4 > ( float )AppMain.OBD_LCD_Y * 0.8f )
        {
            num3 = obs_CAMERA.disp_pos.y;
            num4 = ( float )AppMain.OBD_LCD_Y * 0.8f;
            flag = true;
        }
        int roll = obs_CAMERA.roll;
        float scale = 1f / obs_CAMERA.scale;
        AppMain.dwaterUpdate( speed, x, num3, num4, roll, scale );
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.dwaterSetParam();
        uint drawflag = 0U;
        AppMain.ObjDraw3DNNSetCameraEx( 6, 1, 9U );
        if ( gms_WATER_SURFACE_INFO.flag_enable_ref && !flag )
        {
            AppMain.dwaterDrawReflection( 9U, drawflag );
        }
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmWaterSurfaceTcbProcPreDrawDT, null, 0, 9U );
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, 9U );
        AppMain.ObjDraw3DNNSetCameraEx( 6, 1, 4U );
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
        ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
        ams_PARAM_DRAW_PRIMITIVE.bldDst = 1;
        ams_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(18);
        AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
        int offset = nns_PRIM3D_PCT_ARRAY.offset;
        AppMain.OBS_CAMERA obs_CAMERA2 = AppMain.ObjCameraGet(0);
        x = obs_CAMERA2.disp_pos.x;
        num3 = -gms_WATER_SURFACE_INFO.now_water_level;
        float num5 = AppMain.FX_FX32_TO_F32(1310720);
        float num6 = obs_CAMERA2.znear + 1f;
        float num7 = 300f;
        num4 = num3 - ( obs_CAMERA2.disp_pos.y - 300f );
        uint col = AppMain.AMD_RGBA8888(byte.MaxValue, byte.MaxValue, byte.MaxValue, 96);
        for ( int i = 0; i < 3; i++ )
        {
            float num8 = num6 * (float)(i + 1);
            int num9 = offset + i * 6;
            buffer[num9].Pos.Assign( x - num7, num3, num5 - num8 );
            buffer[1 + num9].Pos.Assign( x + num7, num3, num5 - num8 );
            buffer[2 + num9].Pos.Assign( x - num7, num3 - num4, num5 - num8 );
            buffer[5 + num9].Pos.Assign( x + num7, num3 - num4, num5 - num8 );
            buffer[num9].Col = col;
            buffer[1 + num9].Col = col;
            buffer[2 + num9].Col = col;
            buffer[5 + num9].Col = col;
            float num10;
            float num11;
            AppMain.nnSinCos( AppMain.NNM_DEGtoA32( AppMain._dmap_water.speed_surface * 360f ), out num10, out num11 );
            float num12 = num7 * 2f / 128f * 0.5f;
            float num13;
            float num14;
            float num15;
            float v;
            if ( i == 0 )
            {
                num13 = x / 270f;
                num13 -= ( float )( ( int )num13 ) - AppMain._dmap_water.speed_surface;
                num14 = num13 + num12;
                num15 = 0.3f;
                v = num15 + num4 / 128f * 0.5f + num11 / 5f;
            }
            else if ( i == 1 )
            {
                num14 = x / 270f;
                num14 -= ( float )( ( int )num14 ) + AppMain._dmap_water.speed_surface * 2f;
                num13 = num14 - num12 * 0.75f;
                num15 = 1f;
                v = num15 - num4 * 0.75f / 128f * 0.5f + num10 / 5f;
            }
            else
            {
                num13 = 0.171875f;
                num14 = num13 + 0.0078125f;
                num15 = 0.5f;
                v = num15 + 0.0078125f;
                buffer[num9].Col = AppMain.AMD_RGBA8888( 32, 176, 64, 112 );
                buffer[1 + num9].Col = buffer[num9].Col;
                buffer[2 + num9].Col = buffer[num9].Col;
                buffer[5 + num9].Col = buffer[num9].Col;
            }
            buffer[num9].Tex.u = num13;
            buffer[num9].Tex.v = num15;
            buffer[1 + num9].Tex.u = num14;
            buffer[1 + num9].Tex.v = num15;
            buffer[2 + num9].Tex.u = num13;
            buffer[2 + num9].Tex.v = v;
            buffer[5 + num9].Tex.u = num14;
            buffer[5 + num9].Tex.v = v;
            buffer[3 + num9] = buffer[1 + num9];
            buffer[4 + num9] = buffer[2 + num9];
        }
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        ams_PARAM_DRAW_PRIMITIVE.type = 0;
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
        ams_PARAM_DRAW_PRIMITIVE.count = 18;
        ams_PARAM_DRAW_PRIMITIVE.sortZ = -num6;
        ams_PARAM_DRAW_PRIMITIVE.texId = 0;
        ams_PARAM_DRAW_PRIMITIVE.texlist = AppMain._dmap_water.tex_color.texlist;
        ams_PARAM_DRAW_PRIMITIVE.uwrap = 0;
        ams_PARAM_DRAW_PRIMITIVE.vwrap = 0;
        AppMain.gmWaterSurfaceMatrixPush( 4U );
        AppMain.ObjDraw3DNNDrawPrimitive( ams_PARAM_DRAW_PRIMITIVE, 4U );
        AppMain.gmWaterSurfaceMatrixPop( 4U );
        if ( !flag )
        {
            AppMain.dwaterDrawSurface( 4U, drawflag );
        }
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, 4U );
        AppMain.ObjDraw3DNNUserFunc( new AppMain.OBF_DRAW_USER_DT_FUNC( AppMain.gmWaterSurfaceTcbProcPostDrawDT ), null, 0, 8U );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x06001189 RID: 4489 RVA: 0x00099BF3 File Offset: 0x00097DF3
    private static void gmWaterSurfaceMatrixPush( uint command_state )
    {
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmWaterSurfaceUserFuncMatrixPush, null, 0, command_state );
    }

    // Token: 0x0600118A RID: 4490 RVA: 0x00099C02 File Offset: 0x00097E02
    private static void gmWaterSurfaceMatrixPop( uint command_state )
    {
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmWaterSurfaceUserFuncPop, null, 0, command_state );
    }

    // Token: 0x0600118B RID: 4491 RVA: 0x00099C14 File Offset: 0x00097E14
    private static void gmWaterSurfaceUserFuncMatrixPush( object param )
    {
        AppMain.amMatrixPush();
        AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain.amDrawGetWorldViewMatrix(), mtx );
        AppMain.nnSetPrimitive3DMatrix( nns_MATRIX );
    }

    // Token: 0x0600118C RID: 4492 RVA: 0x00099C44 File Offset: 0x00097E44
    private static void gmWaterSurfaceUserFuncPop( object param )
    {
        AppMain.amMatrixPop();
    }
}
