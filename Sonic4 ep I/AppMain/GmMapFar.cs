using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000298 RID: 664
    private enum GMD_MAP_FAR_OBJ_INDEX
    {
        // Token: 0x04005A95 RID: 23189
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_SEA,
        // Token: 0x04005A96 RID: 23190
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_SKY,
        // Token: 0x04005A97 RID: 23191
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_ROCKA,
        // Token: 0x04005A98 RID: 23192
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_ROCKB,
        // Token: 0x04005A99 RID: 23193
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_ROCKC,
        // Token: 0x04005A9A RID: 23194
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_2DBG,
        // Token: 0x04005A9B RID: 23195
        GMD_MAP_FAR_OBJ_INDEX_ZONE_1_MAX,
        // Token: 0x04005A9C RID: 23196
        GMD_MAP_FAR_OBJ_INDEX_ZONE_2DBG = 0,
        // Token: 0x04005A9D RID: 23197
        GMD_MAP_FAR_OBJ_INDEX_ZONE_2_WHEEL,
        // Token: 0x04005A9E RID: 23198
        GMD_MAP_FAR_OBJ_INDEX_ZONE_2_SLIGHT,
        // Token: 0x04005A9F RID: 23199
        GMD_MAP_FAR_OBJ_INDEX_ZONE_2_MAX,
        // Token: 0x04005AA0 RID: 23200
        GMD_MAP_FAR_OBJ_INDEX_ZONE_3_ISEKI = 0,
        // Token: 0x04005AA1 RID: 23201
        GMD_MAP_FAR_OBJ_INDEX_ZONE_3_MAX,
        // Token: 0x04005AA2 RID: 23202
        GMD_MAP_FAR_OBJ_INDEX_ZONE_4_DUMMY = 0,
        // Token: 0x04005AA3 RID: 23203
        GMD_MAP_FAR_OBJ_INDEX_ZONE_4_MAX,
        // Token: 0x04005AA4 RID: 23204
        GMD_MAP_FAR_OBJ_INDEX_ZONE_FINAL_SPACE = 0,
        // Token: 0x04005AA5 RID: 23205
        GMD_MAP_FAR_OBJ_INDEX_ZONE_FINAL_MAX,
        // Token: 0x04005AA6 RID: 23206
        GMD_MAP_FAR_OBJ_INDEX_ZONE_SS_KALEIDO = 0,
        // Token: 0x04005AA7 RID: 23207
        GMD_MAP_FAR_OBJ_INDEX_ZONE_SS_MAX
    }

    // Token: 0x02000299 RID: 665
    public class GMS_MAP_FAR_OBJ_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002441 RID: 9281 RVA: 0x0014A725 File Offset: 0x00148925
        public static explicit operator AppMain.GMS_MAP_FAR_OBJ_WORK( AppMain.OBS_OBJECT_WORK ob )
        {
            return ( AppMain.GMS_MAP_FAR_OBJ_WORK )ob.holder;
        }

        // Token: 0x06002442 RID: 9282 RVA: 0x0014A732 File Offset: 0x00148932
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_MAP_FAR_OBJ_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x06002443 RID: 9283 RVA: 0x0014A73A File Offset: 0x0014893A
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x06002444 RID: 9284 RVA: 0x0014A742 File Offset: 0x00148942
        public GMS_MAP_FAR_OBJ_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04005AA8 RID: 23208
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04005AA9 RID: 23209
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04005AAA RID: 23210
        public readonly object holder;
    }

    // Token: 0x0200029A RID: 666
    public class GMS_MAP_FAR_SCROLL
    {
        // Token: 0x06002445 RID: 9285 RVA: 0x0014A761 File Offset: 0x00148961
        public GMS_MAP_FAR_SCROLL( int _pos, int _width, int _loop_num )
        {
            this.pos = _pos;
            this.width = _width;
            this.loop_num = _loop_num;
        }

        // Token: 0x04005AAB RID: 23211
        public int pos;

        // Token: 0x04005AAC RID: 23212
        public int width;

        // Token: 0x04005AAD RID: 23213
        public int loop_num;
    }

    // Token: 0x0200029B RID: 667
    public class GMS_MAP_FAR_CAMERA
    {
        // Token: 0x06002446 RID: 9286 RVA: 0x0014A77E File Offset: 0x0014897E
        internal void Clear()
        {
            this.camera_id = 0;
            this.camera_type = 0;
            this.camera_speed_x = 0f;
            this.camera_speed_y = 0f;
        }

        // Token: 0x04005AAE RID: 23214
        public int camera_id;

        // Token: 0x04005AAF RID: 23215
        public int camera_type;

        // Token: 0x04005AB0 RID: 23216
        public float camera_speed_x;

        // Token: 0x04005AB1 RID: 23217
        public float camera_speed_y;
    }

    // Token: 0x0200029C RID: 668
    public class GMS_MAP_FAR_DATA
    {
        // Token: 0x06002448 RID: 9288 RVA: 0x0014A7AC File Offset: 0x001489AC
        internal void Clear()
        {
            this.amb_header = null;
            this.obj_3d_list = null;
            this.obj_3d_list_render = null;
            Array.Clear( this.obj_work, 0, 16 );
            this.nn_work = null;
            this.nn_work_num = 0;
            this.nn_regist_num = 0;
            this.pos.Clear();
            this.mp_header = null;
            this.md_header = null;
            this.degSky = 0f;
            this.degSky2 = 0f;
        }

        // Token: 0x04005AB2 RID: 23218
        public AppMain.AMS_AMB_HEADER amb_header;

        // Token: 0x04005AB3 RID: 23219
        public AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_list;

        // Token: 0x04005AB4 RID: 23220
        public AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_list_render;

        // Token: 0x04005AB5 RID: 23221
        public readonly AppMain.OBS_OBJECT_WORK[] obj_work = new AppMain.OBS_OBJECT_WORK[16];

        // Token: 0x04005AB6 RID: 23222
        public AppMain.OBS_ACTION3D_NN_WORK nn_work;

        // Token: 0x04005AB7 RID: 23223
        public int nn_work_num;

        // Token: 0x04005AB8 RID: 23224
        public int nn_regist_num;

        // Token: 0x04005AB9 RID: 23225
        public readonly AppMain.NNS_VECTOR pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04005ABA RID: 23226
        public AppMain.MP_HEADER mp_header;

        // Token: 0x04005ABB RID: 23227
        public AppMain.MD_HEADER md_header;

        // Token: 0x04005ABC RID: 23228
        public float degSky;

        // Token: 0x04005ABD RID: 23229
        public float degSky2;
    }

    // Token: 0x0200029D RID: 669
    public class GMS_MAP_FAR_MGR
    {
        // Token: 0x0600244A RID: 9290 RVA: 0x0014A840 File Offset: 0x00148A40
        internal void Clear()
        {
            this.tcb_pre_draw = null;
            this.tcb_draw = null;
            this.tcb_post_draw = null;
            this.camera.Clear();
        }

        // Token: 0x04005ABE RID: 23230
        public readonly AppMain.GMS_MAP_FAR_CAMERA camera = new AppMain.GMS_MAP_FAR_CAMERA();

        // Token: 0x04005ABF RID: 23231
        public AppMain.MTS_TASK_TCB tcb_pre_draw;

        // Token: 0x04005AC0 RID: 23232
        public AppMain.MTS_TASK_TCB tcb_draw;

        // Token: 0x04005AC1 RID: 23233
        public AppMain.MTS_TASK_TCB tcb_post_draw;
    }


    // Token: 0x0600119B RID: 4507 RVA: 0x0009A53C File Offset: 0x0009873C
    public static void GmMapFarInitData( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.gmMapFarDataInit();
        AppMain.gmMapFarDataSetAmbHeader( amb );
    }

    // Token: 0x0600119C RID: 4508 RVA: 0x0009A54C File Offset: 0x0009874C
    private static void GmMapFarBuildData()
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        switch ( AppMain.gmMapFarGetZoneType( stage_id ) )
        {
            case 0:
                AppMain.gmMapFarZone1Build();
                return;
            case 1:
                AppMain.gmMapFarZone2Build();
                return;
            case 2:
                AppMain.gmMapFarZone3Build();
                return;
            case 3:
                AppMain.gmMapFarZone4Build();
                return;
            case 4:
                AppMain.gmMapFarZoneFinalBuild();
                return;
            case 5:
                AppMain.gmMapFarZoneSSBuild();
                return;
            default:
                return;
        }
    }

    // Token: 0x0600119D RID: 4509 RVA: 0x0009A5AC File Offset: 0x000987AC
    private static bool GmMapFarCheckLoading()
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        switch ( AppMain.gmMapFarGetZoneType( stage_id ) )
        {
            case 0:
                return AppMain.gmMapFarZone1CheckLoading();
            case 1:
                return AppMain.gmMapFarZone2CheckLoading();
            case 2:
                return AppMain.gmMapFarZone3CheckLoading();
            case 3:
                return AppMain.gmMapFarZone4CheckLoading();
            case 4:
                return AppMain.gmMapFarZoneFinalCheckLoading();
            case 5:
                return AppMain.gmMapFarZoneSSCheckLoading();
            default:
                return true;
        }
    }

    // Token: 0x0600119E RID: 4510 RVA: 0x0009A610 File Offset: 0x00098810
    private static void GmMapFarInit()
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        int num = AppMain.gmMapFarGetZoneType(stage_id);
        AppMain.gmMapFarInitMgr();
        AppMain.gmMapFarCreateTcbPreDraw();
        AppMain.gmMapFarCreateTcbDraw();
        AppMain.gmMapFarCreateTcbPostDraw();
        switch ( num )
        {
            case 0:
                AppMain.gmMapFarZone1Init();
                return;
            case 1:
                AppMain.gmMapFarZone2Init();
                return;
            case 2:
                AppMain.gmMapFarZone3Init();
                return;
            case 3:
                AppMain.gmMapFarZone4Init();
                return;
            case 4:
                AppMain.gmMapFarZoneFinalInit();
                return;
            case 5:
                AppMain.gmMapFarZoneSSInit();
                return;
            default:
                return;
        }
    }

    // Token: 0x0600119F RID: 4511 RVA: 0x0009A685 File Offset: 0x00098885
    private static void GmMapFarExit()
    {
        AppMain.gmMapFarDataClearObjWork();
        AppMain.gmMapFarExitMgr();
    }

    // Token: 0x060011A0 RID: 4512 RVA: 0x0009A694 File Offset: 0x00098894
    private static void GmMapFarFlushData()
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        switch ( AppMain.gmMapFarGetZoneType( stage_id ) )
        {
            case 0:
                AppMain.gmMapFarZone1Flush();
                return;
            case 1:
                AppMain.gmMapFarZone2Flush();
                return;
            case 2:
                AppMain.gmMapFarZone3Flush();
                return;
            case 3:
                AppMain.gmMapFarZone4Flush();
                return;
            case 4:
                AppMain.gmMapFarZoneFinalFlush();
                return;
            case 5:
                AppMain.gmMapFarZoneSSFlush();
                return;
            default:
                return;
        }
    }

    // Token: 0x060011A1 RID: 4513 RVA: 0x0009A6F4 File Offset: 0x000988F4
    public static void GmMapFarRelease()
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        switch ( AppMain.gmMapFarGetZoneType( stage_id ) )
        {
            case 0:
                AppMain.gmMapFarZone1Release();
                break;
            case 1:
                AppMain.gmMapFarZone2Release();
                break;
            case 2:
                AppMain.gmMapFarZone3Release();
                break;
            case 3:
                AppMain.gmMapFarZone4Release();
                break;
            case 4:
                AppMain.gmMapFarZoneFinalRelease();
                break;
            case 5:
                AppMain.gmMapFarZoneSSRelease();
                break;
        }
        AppMain.gmMapFarDataRelease();
        AppMain.gmMapFarReleaseMgr();
    }

    // Token: 0x060011A2 RID: 4514 RVA: 0x0009A764 File Offset: 0x00098964
    private static AppMain.NNS_VECTOR GmMapFarGetCameraPos( AppMain.NNS_VECTOR player_camera_pos )
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        switch ( AppMain.gmMapFarGetZoneType( stage_id ) )
        {
            case 0:
                return AppMain.gmMapFarZone1GetCameraPos( player_camera_pos );
            case 1:
                return AppMain.gmMapFarZone2GetCameraPos( player_camera_pos );
            case 2:
                return AppMain.gmMapFarZone3GetCameraPos( player_camera_pos );
            case 3:
                return player_camera_pos;
            case 4:
                return AppMain.gmMapFarZoneFinalGetCameraPos( player_camera_pos );
            case 5:
                return AppMain.gmMapFarZoneSSGetCameraPos( player_camera_pos );
            default:
                return player_camera_pos;
        }
    }

    // Token: 0x060011A3 RID: 4515 RVA: 0x0009A7C8 File Offset: 0x000989C8
    private static AppMain.NNS_VECTOR GmMapFarGetCameraTarget( AppMain.NNS_VECTOR camera_pos )
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        int num = AppMain.gmMapFarGetZoneType(stage_id);
        AppMain.NNS_VECTOR gmMapFarGetCameraTarget_result = AppMain.GmMapFarGetCameraTarget_result;
        AppMain.nnAddVector( gmMapFarGetCameraTarget_result, camera_pos, AppMain.g_gm_map_far_camera_target_offset[num] );
        return gmMapFarGetCameraTarget_result;
    }

    // Token: 0x060011A4 RID: 4516 RVA: 0x0009A7F7 File Offset: 0x000989F7
    private static int gmMapFarGetStageId()
    {
        return ( int )AppMain.g_gs_main_sys_info.stage_id;
    }

    // Token: 0x060011A5 RID: 4517 RVA: 0x0009A803 File Offset: 0x00098A03
    private static int gmMapFarGetZoneType( int stage_id )
    {
        return AppMain.g_gm_gamedat_zone_type_tbl[stage_id];
    }

    // Token: 0x060011A6 RID: 4518 RVA: 0x0009A80C File Offset: 0x00098A0C
    private static AppMain.MP_HEADER gmMapFarGetMapsetMpA()
    {
        return ( AppMain.MP_HEADER )AppMain.g_gm_gamedat_map_set[0];
    }

    // Token: 0x060011A7 RID: 4519 RVA: 0x0009A81A File Offset: 0x00098A1A
    private static AppMain.OBS_OBJECT gmMapFarGetObject()
    {
        return AppMain.g_obj;
    }

    // Token: 0x060011A8 RID: 4520 RVA: 0x0009A824 File Offset: 0x00098A24
    private static void gmMapFarClearColor()
    {
        int stage_id = AppMain.gmMapFarGetStageId();
        int num = AppMain.gmMapFarGetZoneType(stage_id);
        AppMain.amDrawSetBGColor( AppMain.g_gm_map_far_clear_color[num] );
    }

    // Token: 0x060011A9 RID: 4521 RVA: 0x0009A84C File Offset: 0x00098A4C
    public static void gmMapFarDataInit()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.g_map_far_data_real.Clear();
        AppMain.g_map_far_data = AppMain.g_map_far_data_real;
        if ( num == 0 )
        {
            AppMain.g_map_far_data.degSky = AppMain.nnRandom() * 340f;
            AppMain.g_map_far_data.degSky2 = AppMain.nnRandom() * 340f;
            return;
        }
        if ( 4 == num )
        {
            float num2 = AppMain.nnRandom();
            if ( num2 < 0.25f )
            {
                AppMain.g_map_far_data.degSky = 260f + AppMain.nnRandom() * 50f;
            }
            else if ( num2 < 0.5f )
            {
                AppMain.g_map_far_data.degSky = 130f + AppMain.nnRandom() * 50f;
            }
            else if ( num2 < 0.75f )
            {
                AppMain.g_map_far_data.degSky = 20f + AppMain.nnRandom() * 50f;
            }
            else
            {
                AppMain.g_map_far_data.degSky = AppMain.nnRandom() * 355f;
            }
            AppMain.g_map_far_data.degSky2 = AppMain.nnRandom() * 355f;
            return;
        }
        AppMain.g_map_far_data.degSky = 90f;
        AppMain.g_map_far_data.degSky2 = 90f;
    }

    // Token: 0x060011AA RID: 4522 RVA: 0x0009A971 File Offset: 0x00098B71
    private static void gmMapFarDataRelease()
    {
        if ( AppMain.g_map_far_data != null )
        {
            AppMain.gmMapFarDataFreeNNModelWork();
            AppMain.gmMapFarDataReleaseAmbHeader();
            AppMain.g_map_far_data = null;
        }
    }

    // Token: 0x060011AB RID: 4523 RVA: 0x0009A98A File Offset: 0x00098B8A
    private static AppMain.GMS_MAP_FAR_DATA gmMapFarDataGetInfo()
    {
        return AppMain.g_map_far_data;
    }

    // Token: 0x060011AC RID: 4524 RVA: 0x0009A994 File Offset: 0x00098B94
    public static void gmMapFarDataSetAmbHeader( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        gms_MAP_FAR_DATA.amb_header = amb;
    }

    // Token: 0x060011AD RID: 4525 RVA: 0x0009A9B0 File Offset: 0x00098BB0
    private static AppMain.AMS_AMB_HEADER gmMapFarDataGetAmbHeader()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        return gms_MAP_FAR_DATA.amb_header;
    }

    // Token: 0x060011AE RID: 4526 RVA: 0x0009A9CC File Offset: 0x00098BCC
    private static void gmMapFarDataReleaseAmbHeader()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        if ( gms_MAP_FAR_DATA.amb_header != null )
        {
            gms_MAP_FAR_DATA.amb_header = null;
        }
    }

    // Token: 0x060011AF RID: 4527 RVA: 0x0009A9F8 File Offset: 0x00098BF8
    private static AppMain.GMS_MAP_FAR_OBJ_WORK gmMapFarDataLoadObj( AppMain.GMD_MAP_FAR_OBJ_INDEX obj_index, AppMain.OBS_ACTION3D_NN_WORK obj_3d_work, AppMain.MPP_VOID_OBS_OBJECT_WORK main_func, AppMain.MPP_VOID_OBS_OBJECT_WORK out_func )
    {
        AppMain.GMS_MAP_FAR_OBJ_WORK gms_MAP_FAR_OBJ_WORK = (AppMain.GMS_MAP_FAR_OBJ_WORK)AppMain.OBM_OBJECT_TASK_DETAIL_INIT(12544, 5, 0, 0, () => new AppMain.GMS_MAP_FAR_OBJ_WORK(), "MAP FAR OBJ");
        AppMain.OBS_OBJECT_WORK obj_work = gms_MAP_FAR_OBJ_WORK.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, obj_3d_work, gms_MAP_FAR_OBJ_WORK.obj_3d );
        obj_work.obj_type = 8;
        obj_work.flag |= 18U;
        obj_work.move_flag |= 768U;
        obj_work.user_flag = ( uint )obj_index;
        obj_work.ppFunc = main_func;
        obj_work.ppOut = out_func;
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.ObjObjectExit ) );
        AppMain.gmMapFarDataSetObjWork( obj_work, obj_index );
        return gms_MAP_FAR_OBJ_WORK;
    }

    // Token: 0x060011B0 RID: 4528 RVA: 0x0009AAAC File Offset: 0x00098CAC
    private static void gmMapFarDataClearObjWork()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        for ( int i = 0; i < 16; i++ )
        {
            gms_MAP_FAR_DATA.obj_work[i] = null;
        }
    }

    // Token: 0x060011B1 RID: 4529 RVA: 0x0009AAD8 File Offset: 0x00098CD8
    private static void gmMapFarDataSetObjWork( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMD_MAP_FAR_OBJ_INDEX obj_index )
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        gms_MAP_FAR_DATA.obj_work[( int )obj_index] = obj_work;
    }

    // Token: 0x060011B2 RID: 4530 RVA: 0x0009AAF4 File Offset: 0x00098CF4
    private static AppMain.OBS_OBJECT_WORK gmMapFarDataGetObjWork( AppMain.GMD_MAP_FAR_OBJ_INDEX obj_index )
    {
        if ( ( AppMain.GMD_MAP_FAR_OBJ_INDEX )16 <= obj_index )
        {
            return null;
        }
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        return gms_MAP_FAR_DATA.obj_work[( int )obj_index];
    }

    // Token: 0x060011B3 RID: 4531 RVA: 0x0009AB18 File Offset: 0x00098D18
    private static void gmMapFarDataFreeNNModelWork()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        if ( gms_MAP_FAR_DATA.nn_work != null )
        {
            gms_MAP_FAR_DATA.nn_work = null;
        }
        gms_MAP_FAR_DATA.nn_work_num = 0;
        gms_MAP_FAR_DATA.nn_regist_num = 0;
        gms_MAP_FAR_DATA.mp_header = null;
        gms_MAP_FAR_DATA.md_header = null;
    }

    // Token: 0x060011B4 RID: 4532 RVA: 0x0009AB56 File Offset: 0x00098D56
    private static AppMain.GMS_MAP_FAR_MGR gmMapFarGetMgr()
    {
        return AppMain.g_map_far_mgr;
    }

    // Token: 0x060011B5 RID: 4533 RVA: 0x0009AB5D File Offset: 0x00098D5D
    private static void gmMapFarInitMgr()
    {
        AppMain.g_map_far_mgr_real.Clear();
        AppMain.g_map_far_mgr = AppMain.g_map_far_mgr_real;
    }

    // Token: 0x060011B6 RID: 4534 RVA: 0x0009AB73 File Offset: 0x00098D73
    private static void gmMapFarExitMgr()
    {
        if ( AppMain.g_map_far_mgr != null )
        {
            AppMain.gmMapFarDeleteTcbPreDraw();
            AppMain.gmMapFarDeleteTcbDraw();
            AppMain.gmMapFarDeleteTcbPostDraw();
            AppMain.g_map_far_mgr = null;
        }
    }

    // Token: 0x060011B7 RID: 4535 RVA: 0x0009AB91 File Offset: 0x00098D91
    private static void gmMapFarReleaseMgr()
    {
    }

    // Token: 0x060011B8 RID: 4536 RVA: 0x0009AB94 File Offset: 0x00098D94
    private static AppMain.MTS_TASK_TCB gmMapFarCreateTcbPreDraw()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        gms_MAP_FAR_MGR.tcb_pre_draw = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMapFarTcbProcPreDraw ), null, 0U, 0, 12544U, 5, null, "GM MAP FAR PRE DRAW" );
        return gms_MAP_FAR_MGR.tcb_pre_draw;
    }

    // Token: 0x060011B9 RID: 4537 RVA: 0x0009ABD4 File Offset: 0x00098DD4
    private static void gmMapFarDeleteTcbPreDraw()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        if ( gms_MAP_FAR_MGR.tcb_pre_draw != null )
        {
            AppMain.mtTaskClearTcb( gms_MAP_FAR_MGR.tcb_pre_draw );
            gms_MAP_FAR_MGR.tcb_pre_draw = null;
        }
    }

    // Token: 0x060011BA RID: 4538 RVA: 0x0009AC04 File Offset: 0x00098E04
    private static void gmMapFarTcbProcPreDraw( AppMain.MTS_TASK_TCB tcb )
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmMapFarTcbProcPreDrawDT, null, 0, 1U );
        AppMain.gmMapFarCameraApply();
        if ( num == 0 )
        {
            AppMain.amDrawSetFog( 1U, 1 );
            if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
            {
                AppMain.amDrawSetFogColor( 1U, 0.85f, 0.5f, 0.25f );
                if ( AppMain.g_gs_main_sys_info.stage_id == 3 )
                {
                    AppMain.amDrawSetFog( 1U, 0 );
                }
            }
            else
            {
                AppMain.amDrawSetFogColor( 1U, 0.7f, 0.95f, 1f );
            }
            AppMain.amDrawSetFogRange( 1U, 100f, 500f );
        }
        else if ( 1 == num )
        {
            AppMain.amDrawSetFog( 1U, 0 );
            AppMain.amDrawSetFogColor( 1U, 0f, 0f, 0.3f );
            AppMain.amDrawSetFogRange( 1U, 450f, 650f );
        }
        else if ( 2 == num )
        {
            AppMain.amDrawSetFog( 1U, 0 );
            AppMain.amDrawSetFogColor( 1U, 0.33333334f, 0.4627451f, 0.42745098f );
            AppMain.amDrawSetFogRange( 1U, 300f, 1300f );
        }
        else if ( 4 == num )
        {
            AppMain.amDrawSetFog( 1U, 0 );
            AppMain.amDrawSetFogColor( 1U, 0.1f, 0.08f, 0.22f );
            AppMain.amDrawSetFogRange( 1U, 160f, 1100f );
        }
        else if ( 5 == num )
        {
            AppMain.amDrawSetFog( 1U, 1 );
            AppMain.amDrawSetFogColor( 1U, 0f, 0f, 0f );
            AppMain.amDrawSetFogRange( 1U, 100f, 1000f );
        }
        AppMain.amDrawSetFog( 0U, 0 );
        AppMain.amDrawSetFog( 3U, 0 );
    }

    // Token: 0x060011BB RID: 4539 RVA: 0x0009AD84 File Offset: 0x00098F84
    private static AppMain.MTS_TASK_TCB gmMapFarCreateTcbDraw()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        gms_MAP_FAR_MGR.tcb_draw = AppMain.MTM_TASK_MAKE_TCB( null, null, 0U, 0, 12544U, 5, null, "GM_MAP_FAR_DRAW" );
        return gms_MAP_FAR_MGR.tcb_draw;
    }

    // Token: 0x060011BC RID: 4540 RVA: 0x0009ADB8 File Offset: 0x00098FB8
    private static void gmMapFarDeleteTcbDraw()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        if ( gms_MAP_FAR_MGR.tcb_draw != null )
        {
            AppMain.mtTaskClearTcb( gms_MAP_FAR_MGR.tcb_draw );
            gms_MAP_FAR_MGR.tcb_draw = null;
        }
    }

    // Token: 0x060011BD RID: 4541 RVA: 0x0009ADE8 File Offset: 0x00098FE8
    private static void gmMapFarChangeTcbProcDraw( AppMain.GSF_TASK_PROCEDURE proc )
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        AppMain.mtTaskChangeTcbProcedure( gms_MAP_FAR_MGR.tcb_draw, proc );
    }

    // Token: 0x060011BE RID: 4542 RVA: 0x0009AE07 File Offset: 0x00099007
    private static void gmMapFarTcbProcPreDrawDT( object data )
    {
        AppMain.gmMapFarClearColor();
    }

    // Token: 0x060011BF RID: 4543 RVA: 0x0009AE10 File Offset: 0x00099010
    private static AppMain.MTS_TASK_TCB gmMapFarCreateTcbPostDraw()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        gms_MAP_FAR_MGR.tcb_post_draw = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMapFarTcbProcPostDraw ), null, 0U, 0, 12544U, 5, null, "GM MAP FAR POST DRAW" );
        return gms_MAP_FAR_MGR.tcb_post_draw;
    }

    // Token: 0x060011C0 RID: 4544 RVA: 0x0009AE50 File Offset: 0x00099050
    private static void gmMapFarDeleteTcbPostDraw()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        if ( gms_MAP_FAR_MGR.tcb_post_draw != null )
        {
            AppMain.mtTaskClearTcb( gms_MAP_FAR_MGR.tcb_post_draw );
            gms_MAP_FAR_MGR.tcb_post_draw = null;
        }
    }

    // Token: 0x060011C1 RID: 4545 RVA: 0x0009AE80 File Offset: 0x00099080
    private static void gmMapFarTcbProcPostDraw( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmMapFarTcbProcPostDrawDT, null, 0, 3U );
        AppMain.OBS_OBJECT obs_OBJECT = AppMain.gmMapFarGetObject();
        AppMain.ObjDraw3DNNSetCamera( obs_OBJECT.glb_camera_id, obs_OBJECT.glb_camera_type );
    }

    // Token: 0x060011C2 RID: 4546 RVA: 0x0009AEB1 File Offset: 0x000990B1
    private static void gmMapFarTcbProcPostDrawDT( object data )
    {
    }

    // Token: 0x060011C3 RID: 4547 RVA: 0x0009AEB4 File Offset: 0x000990B4
    private static AppMain.GMS_MAP_FAR_CAMERA gmMapFarCameraGetInfo()
    {
        AppMain.GMS_MAP_FAR_MGR gms_MAP_FAR_MGR = AppMain.gmMapFarGetMgr();
        return gms_MAP_FAR_MGR.camera;
    }

    // Token: 0x060011C4 RID: 4548 RVA: 0x0009AED0 File Offset: 0x000990D0
    private static void gmMapFarCameraSetInfo( int camear_id, int camera_type )
    {
        AppMain.GMS_MAP_FAR_CAMERA gms_MAP_FAR_CAMERA = AppMain.gmMapFarCameraGetInfo();
        gms_MAP_FAR_CAMERA.camera_id = camear_id;
        gms_MAP_FAR_CAMERA.camera_type = camera_type;
    }

    // Token: 0x060011C5 RID: 4549 RVA: 0x0009AEF4 File Offset: 0x000990F4
    private static void gmMapFarCameraApply()
    {
        AppMain.GMS_MAP_FAR_CAMERA gms_MAP_FAR_CAMERA = AppMain.gmMapFarCameraGetInfo();
        AppMain.ObjDraw3DNNSetCamera( gms_MAP_FAR_CAMERA.camera_id, gms_MAP_FAR_CAMERA.camera_type );
    }

    // Token: 0x060011C6 RID: 4550 RVA: 0x0009AF18 File Offset: 0x00099118
    private static void gmMapFarCameraSetSpeed( float speed_x, float speed_y )
    {
        AppMain.GMS_MAP_FAR_CAMERA gms_MAP_FAR_CAMERA = AppMain.gmMapFarCameraGetInfo();
        gms_MAP_FAR_CAMERA.camera_speed_x = speed_x;
        gms_MAP_FAR_CAMERA.camera_speed_y = speed_y;
    }

    // Token: 0x060011C7 RID: 4551 RVA: 0x0009AF3C File Offset: 0x0009913C
    private static float gmMapFarCameraGetSpeedX()
    {
        AppMain.GMS_MAP_FAR_CAMERA gms_MAP_FAR_CAMERA = AppMain.gmMapFarCameraGetInfo();
        return gms_MAP_FAR_CAMERA.camera_speed_x;
    }

    // Token: 0x060011C8 RID: 4552 RVA: 0x0009AF58 File Offset: 0x00099158
    private static float gmMapFarCameraGetSpeedY()
    {
        AppMain.GMS_MAP_FAR_CAMERA gms_MAP_FAR_CAMERA = AppMain.gmMapFarCameraGetInfo();
        return gms_MAP_FAR_CAMERA.camera_speed_y;
    }

    // Token: 0x060011C9 RID: 4553 RVA: 0x0009AF74 File Offset: 0x00099174
    private static int gmMapFarCameraGetScrollDistance( AppMain.GMS_MAP_FAR_SCROLL[] scroll_list, uint scroll_info_num )
    {
        if ( scroll_list == null )
        {
            return 0;
        }
        int num = 0;
        uint num2 = 0U;
        while ( scroll_info_num > num2 )
        {
            AppMain.GMS_MAP_FAR_SCROLL gms_MAP_FAR_SCROLL = scroll_list[(int)((UIntPtr)num2)];
            num += gms_MAP_FAR_SCROLL.width * gms_MAP_FAR_SCROLL.loop_num;
            num2 += 1U;
        }
        return num;
    }

    // Token: 0x060011CA RID: 4554 RVA: 0x0009AFAC File Offset: 0x000991AC
    private static float gmMapFarCameraGetPos( float player_camera_pos, AppMain.GMS_MAP_FAR_SCROLL[] scroll_list, uint scroll_info_num, float scroll_speed )
    {
        float num = scroll_speed * player_camera_pos;
        float result = num;
        if ( scroll_list == null )
        {
            return num;
        }
        uint num2 = 0U;
        while ( scroll_info_num > num2 )
        {
            AppMain.GMS_MAP_FAR_SCROLL gms_MAP_FAR_SCROLL = scroll_list[(int)((UIntPtr)num2)];
            if ( gms_MAP_FAR_SCROLL.loop_num != 0 )
            {
                int num3 = gms_MAP_FAR_SCROLL.width * gms_MAP_FAR_SCROLL.loop_num;
                if ( ( float )num3 > num )
                {
                    int num4 = (int)num / gms_MAP_FAR_SCROLL.width;
                    num -= ( float )( num4 * gms_MAP_FAR_SCROLL.width );
                    result = ( float )gms_MAP_FAR_SCROLL.pos + num;
                    break;
                }
                num -= ( float )num3;
                result = ( float )( gms_MAP_FAR_SCROLL.pos + gms_MAP_FAR_SCROLL.width );
            }
            num2 += 1U;
        }
        return result;
    }

    // Token: 0x060011CB RID: 4555 RVA: 0x0009B030 File Offset: 0x00099230
    private static AppMain.NNS_VECTOR gmMapFarCameraGetPos( AppMain.NNS_VECTOR player_camera_pos, AppMain.GMS_MAP_FAR_SCROLL[] scroll_list_x, uint scroll_info_num_x, AppMain.GMS_MAP_FAR_SCROLL[] scroll_list_y, uint scroll_info_num_y )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.gmMapFarCameraGetPos_result;
        float x = player_camera_pos.x;
        nns_VECTOR.x = AppMain.gmMapFarCameraGetPos( x, scroll_list_x, scroll_info_num_x, AppMain.gmMapFarCameraGetSpeedX() );
        float y = player_camera_pos.y;
        nns_VECTOR.y = AppMain.gmMapFarCameraGetPos( y, scroll_list_y, scroll_info_num_y, AppMain.gmMapFarCameraGetSpeedY() );
        nns_VECTOR.z = 160f;
        return nns_VECTOR;
    }

    // Token: 0x060011CC RID: 4556 RVA: 0x0009B084 File Offset: 0x00099284
    private static void gmMapFarSceneLoadObj( AppMain.GMD_MAP_FAR_OBJ_INDEX obj_index, AppMain.OBS_ACTION3D_NN_WORK obj_3d_work, uint mat_motion_index, AppMain.AMS_AMB_HEADER mat_amb_header, uint motion_index, AppMain.AMS_AMB_HEADER mtn_amb_header, AppMain.MPP_VOID_OBS_OBJECT_WORK main_func, AppMain.MPP_VOID_OBS_OBJECT_WORK out_func, uint command_state )
    {
        AppMain.GMS_MAP_FAR_OBJ_WORK gms_MAP_FAR_OBJ_WORK = AppMain.gmMapFarDataLoadObj(obj_index, obj_3d_work, main_func, out_func);
        gms_MAP_FAR_OBJ_WORK.obj_3d.command_state = command_state;
        if ( mat_amb_header != null )
        {
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_MAP_FAR_OBJ_WORK.obj_3d, 0, null, null, ( int )mat_motion_index, mat_amb_header );
            if ( AppMain.gmMapFarGetZoneType( AppMain.gmMapFarGetStageId() ) == 5 )
            {
                AppMain.AMS_MOTION motion = gms_MAP_FAR_OBJ_WORK.obj_3d.motion;
                motion.mmtn[motion.mmotion_id].StartFrame = 2400f;
            }
        }
        if ( mtn_amb_header != null )
        {
            AppMain.ObjAction3dNNMotionLoad( gms_MAP_FAR_OBJ_WORK.obj_3d, 0, false, null, null, ( int )motion_index, mtn_amb_header, 8, 8 );
        }
    }

    // Token: 0x060011CD RID: 4557 RVA: 0x0009B108 File Offset: 0x00099308
    private static void gmMapFarSceneObjFuncDraw2DBG( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        int num = AppMain.gmMapFarGetStageId();
        if ( num <= 2 )
        {
            return;
        }
        if ( num >= 4 && num <= 7 )
        {
            if ( AppMain.gmMapFarDrawCheckYakei() == 0 )
            {
                return;
            }
        }
        else if ( num == 8 )
        {
            if ( AppMain.g_map_far_data.pos.z >= -33.33f && AppMain.g_map_far_data.pos.z <= -26.37f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -97.64f && AppMain.g_map_far_data.pos.z <= -88.98f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -283.79f && AppMain.g_map_far_data.pos.z <= -243.6f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -376.93f && AppMain.g_map_far_data.pos.z <= -352.83f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -467.01f && AppMain.g_map_far_data.pos.z <= -454.16f )
            {
                return;
            }
        }
        else if ( num == 10 )
        {
            if ( AppMain.g_map_far_data.pos.z >= -117.26f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -183.14f && AppMain.g_map_far_data.pos.z <= -117.26f && AppMain.g_map_far_data.pos.y <= 26.73f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -444f && AppMain.g_map_far_data.pos.z <= -200f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -636.4f && AppMain.g_map_far_data.pos.z <= -486.14f )
            {
                return;
            }
        }
        else if ( num == 11 )
        {
            if ( ( AppMain.g_map_far_data.pos.z < -115f || AppMain.g_map_far_data.pos.y >= 15f ) && AppMain.g_map_far_data.pos.z > -245f && ( AppMain.g_map_far_data.pos.z > -105f || AppMain.g_map_far_data.pos.z < -220f || AppMain.g_map_far_data.pos.y < 40f ) )
            {
                return;
            }
        }
        else if ( num == 16 )
        {
            if ( AppMain.g_map_far_data.pos.z >= -5.6f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -13.3f && AppMain.g_map_far_data.pos.z <= -7.15f )
            {
                return;
            }
            if ( AppMain.g_map_far_data.pos.z >= -21.3f && AppMain.g_map_far_data.pos.z <= -15.65f )
            {
                return;
            }
        }
        pWork.disp_flag |= 9502720U;
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        if ( num == 3 )
        {
            pWork.disp_flag |= 4U;
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 250f, -97f, -20f );
        }
        else if ( num >= 4 && num <= 7 )
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 250f, -70f, -50f );
        }
        else if ( num >= 8 && num <= 11 )
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 10f, -30f, -50f );
        }
        else if ( num >= 16 && num <= 20 )
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 250f, -70f, -50f );
        }
        AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
    }

    // Token: 0x060011CE RID: 4558 RVA: 0x0009B4F0 File Offset: 0x000996F0
    private static void gmMapFarSceneObjFuncDrawRockA( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        float y = -10f;
        float num = -100f;
        int num2 = AppMain.gmMapFarGetStageId();
        pWork.disp_flag |= 9502720U;
        if ( AppMain.gmMapFarDrawCheckRock() == 0 )
        {
            return;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 )
        {
            if ( AppMain.g_map_far_data.pos.z <= -18f && AppMain.g_map_far_data.pos.z >= -295f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num - 40f, y, -90f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -112f && AppMain.g_map_far_data.pos.z >= -366f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 100f, y, -240f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -238f && AppMain.g_map_far_data.pos.z >= -559f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 30f, y, -400f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
        }
        else
        {
            if ( num2 == 3 )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num - 30f, y, -100f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 3f, 3f, 3f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
            if ( AppMain.g_map_far_data.pos.z <= -10f && AppMain.g_map_far_data.pos.z >= -260f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 100f, y, -135f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -84f && AppMain.g_map_far_data.pos.z >= -500f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num - 40f, y, -290f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -182f && AppMain.g_map_far_data.pos.z >= -475f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 80f, y, -330f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
        }
    }

    // Token: 0x060011CF RID: 4559 RVA: 0x0009B938 File Offset: 0x00099B38
    private static void gmMapFarSceneObjFuncDrawRockB( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        float y = -10f;
        float num = -100f;
        int num2 = AppMain.gmMapFarGetStageId();
        pWork.disp_flag |= 9502720U;
        if ( AppMain.gmMapFarDrawCheckRock() == 0 )
        {
            return;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 )
        {
            if ( AppMain.g_map_far_data.pos.z <= -18f && AppMain.g_map_far_data.pos.z >= -256f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 60f, y, -100f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2.5f, 2.5f, 2.5f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -112f && AppMain.g_map_far_data.pos.z >= -406f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 20f, y, -280f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -275f && AppMain.g_map_far_data.pos.z >= -526f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 100f, y, -400f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
        }
        else
        {
            if ( num2 == 3 )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num, y, 75f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 5f, 5f, 5f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num - 130f, y, -180f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 3f, 3f, 3f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
            if ( AppMain.g_map_far_data.pos.z <= -6f && AppMain.g_map_far_data.pos.z >= -317f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 40f, y, -160f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -100f && AppMain.g_map_far_data.pos.z >= -397f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 70f, y, -250f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -314f && AppMain.g_map_far_data.pos.z >= -574f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 100f, y, -440f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2.5f, 2.5f, 2.5f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
        }
    }

    // Token: 0x060011D0 RID: 4560 RVA: 0x0009BE14 File Offset: 0x0009A014
    private static void gmMapFarSceneObjFuncDrawRockC( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        float y = -10f;
        float num = -100f;
        int num2 = AppMain.gmMapFarGetStageId();
        pWork.disp_flag |= 9502720U;
        if ( AppMain.gmMapFarDrawCheckRock() == 0 )
        {
            return;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 )
        {
            if ( AppMain.g_map_far_data.pos.z <= -18f && AppMain.g_map_far_data.pos.z >= -387f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 20f, y, -180f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -167f && AppMain.g_map_far_data.pos.z >= -582f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 80f, y, -360f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 4f, 4f, 4f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
        }
        else
        {
            if ( num2 == 3 )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 160f, y, 10f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
            if ( AppMain.g_map_far_data.pos.z <= -6f && AppMain.g_map_far_data.pos.z >= -526f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 30f, y, -250f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 5f, 5f, 5f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            if ( AppMain.g_map_far_data.pos.z <= -202f && AppMain.g_map_far_data.pos.z >= -577f )
            {
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, num + 40f, y, -380f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 2f, 2f, 2f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
        }
    }

    // Token: 0x060011D1 RID: 4561 RVA: 0x0009C178 File Offset: 0x0009A378
    private static int gmMapFarDrawCheckRock()
    {
        int num = AppMain.gmMapFarGetStageId();
        if ( num != 2 )
        {
            if ( num == 3 )
            {
                return 0;
            }
            if ( num == 0 )
            {
                if ( AppMain.g_map_far_data.pos.y <= 5.2f && AppMain.g_map_far_data.pos.z >= -436f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 4.14f && AppMain.g_map_far_data.pos.z < -436f && AppMain.g_map_far_data.pos.z >= -471.4f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 10f && AppMain.g_map_far_data.pos.z < -182f && AppMain.g_map_far_data.pos.z >= -192f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 5.4f && AppMain.g_map_far_data.pos.z <= -62f && AppMain.g_map_far_data.pos.z >= -110f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 8.85f && AppMain.g_map_far_data.pos.z <= -267f && AppMain.g_map_far_data.pos.z >= -308f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 9.97f && AppMain.g_map_far_data.pos.z <= -337f && AppMain.g_map_far_data.pos.z >= -358f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y >= 7f && AppMain.g_map_far_data.pos.z <= -347f && AppMain.g_map_far_data.pos.z >= -359f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.z <= -495f && AppMain.g_map_far_data.pos.z >= -503f )
                {
                    return 0;
                }
            }
            else if ( num == 1 )
            {
                if ( AppMain.g_map_far_data.pos.y <= 2.95f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 6.47f && AppMain.g_map_far_data.pos.z <= -135.4f && AppMain.g_map_far_data.pos.z >= -156f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.y <= 4.5f && AppMain.g_map_far_data.pos.z <= -135.4f && AppMain.g_map_far_data.pos.z >= -170f )
                {
                    return 0;
                }
                if ( AppMain.g_map_far_data.pos.z <= -419f )
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    // Token: 0x060011D2 RID: 4562 RVA: 0x0009C458 File Offset: 0x0009A658
    private static int gmMapFarDrawCheckYakei()
    {
        int num = AppMain.gmMapFarGetStageId();
        if ( num == 4 )
        {
            if ( AppMain.g_map_far_data.pos.y >= 26.5f && AppMain.g_map_far_data.pos.z <= -36.7f && AppMain.g_map_far_data.pos.z >= -41.9f )
            {
                return 0;
            }
            if ( AppMain.g_map_far_data.pos.y <= 25.46f && AppMain.g_map_far_data.pos.z <= -50.88f && AppMain.g_map_far_data.pos.z >= -58.56f )
            {
                return 0;
            }
            if ( AppMain.g_map_far_data.pos.y >= 7.06f && AppMain.g_map_far_data.pos.y <= 31.67f && AppMain.g_map_far_data.pos.z <= -62.56f && AppMain.g_map_far_data.pos.z >= -64.97f )
            {
                return 0;
            }
        }
        else if ( num == 6 )
        {
            if ( AppMain.g_map_far_data.pos.y <= 9.55f )
            {
                return 0;
            }
            if ( AppMain.g_map_far_data.pos.y <= 15.31f && AppMain.g_map_far_data.pos.y >= 13f && AppMain.g_map_far_data.pos.z <= -56.48f )
            {
                return 0;
            }
            if ( AppMain.g_map_far_data.pos.y <= 19.39f && AppMain.g_map_far_data.pos.y >= 16.63f && AppMain.g_map_far_data.pos.z <= -58.88f )
            {
                return 0;
            }
            if ( AppMain.g_map_far_data.pos.y <= 19.39f && AppMain.g_map_far_data.pos.y >= 16.42f && AppMain.g_map_far_data.pos.z >= -37f )
            {
                return 0;
            }
            if ( AppMain.g_map_far_data.pos.y <= 32.49f && AppMain.g_map_far_data.pos.y >= 29.01f && AppMain.g_map_far_data.pos.z >= -29.98f )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x060011D3 RID: 4563 RVA: 0x0009C690 File Offset: 0x0009A890
    private static void gmMapFarSceneObjFuncDrawBg( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        float num = -30f;
        float x = 50f;
        int num2 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        int num3 = AppMain.gmMapFarGetStageId();
        pWork.disp_flag |= 9502720U;
        if ( AppMain.ObjObjectPauseCheck( obj_3d.flag ) > 0U )
        {
            pWork.disp_flag |= 4096U;
        }
        else
        {
            pWork.disp_flag &= 4294963199U;
        }
        if ( 1 == num2 )
        {
            if ( AppMain.gmMapFarDrawCheckYakei() == 0 )
            {
                return;
            }
            pWork.disp_flag |= 4U;
            AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
            if ( num3 == 7 )
            {
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num + 10f, 0f );
            }
            else
            {
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num, -135f );
            }
            AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 1f, 1f, 1f );
            AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            return;
        }
        else
        {
            if ( 2 == num2 )
            {
                if ( num3 == 8 )
                {
                    if ( AppMain.g_map_far_data.pos.z <= -312.5f && AppMain.g_map_far_data.pos.z >= -333f )
                    {
                        return;
                    }
                }
                else if ( num3 == 10 )
                {
                    if ( AppMain.g_map_far_data.pos.z >= -102f )
                    {
                        return;
                    }
                    if ( AppMain.g_map_far_data.pos.z <= -102f && AppMain.g_map_far_data.pos.z >= -160f && AppMain.g_map_far_data.pos.y <= 54f )
                    {
                        return;
                    }
                    if ( AppMain.g_map_far_data.pos.z <= -177.56f && AppMain.g_map_far_data.pos.z >= -392f )
                    {
                        return;
                    }
                    if ( AppMain.g_map_far_data.pos.z <= -410f && AppMain.g_map_far_data.pos.z >= -431f && AppMain.g_map_far_data.pos.y <= 64f )
                    {
                        return;
                    }
                    if ( AppMain.g_map_far_data.pos.z <= -431f && AppMain.g_map_far_data.pos.z >= -550f )
                    {
                        return;
                    }
                    if ( AppMain.g_map_far_data.pos.z >= -550f && AppMain.g_map_far_data.pos.y < 50f )
                    {
                        return;
                    }
                }
                else if ( num3 == 11 && ( AppMain.g_map_far_data.pos.z < -103f || AppMain.g_map_far_data.pos.y >= 24f ) && AppMain.g_map_far_data.pos.z > -216f && ( AppMain.g_map_far_data.pos.z > -95f || AppMain.g_map_far_data.pos.z < -190f || AppMain.g_map_far_data.pos.y < 84f ) )
                {
                    return;
                }
                pWork.disp_flag |= 4U;
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num, -160f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 1f, 1f, 1f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
            if ( 4 == num2 )
            {
                pWork.disp_flag |= 13705472U;
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, AppMain.g_map_far_data.pos.x, -10f, AppMain.g_map_far_data.pos.z );
                AppMain.nnRotateYMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, ( int )( ( ushort )AppMain.NNM_DEGtoA16( 90f ) ) );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
                return;
            }
            if ( 5 == num2 )
            {
                if ( ( AppMain.g_gm_main_system.game_flag & 4U ) != 0U )
                {
                    return;
                }
                x = ( float )AppMain.OBD_LCD_X;
                num = ( float )AppMain.OBD_LCD_Y;
                pWork.dir.y = 49152;
                pWork.disp_flag |= 4U;
                AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
                AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num, -160f );
                AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 3f, 3f, 3f );
                AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
            }
            return;
        }
    }

    // Token: 0x060011D4 RID: 4564 RVA: 0x0009CB94 File Offset: 0x0009AD94
    private static void gmMapFarSceneObjFuncDrawRotate( AppMain.OBS_OBJECT_WORK pWork )
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        int num2 = AppMain.gmMapFarGetStageId();
        if ( AppMain.ObjObjectPauseCheck( obj_3d.flag ) == 0U )
        {
            if ( num == 0 )
            {
                AppMain.g_map_far_data.degSky += AppMain.amSystemGetFrameRateMain() * 0.005f;
                AppMain.g_map_far_data.degSky2 += AppMain.amSystemGetFrameRateMain() * 0.01f;
            }
            else if ( 4 == num )
            {
                AppMain.g_map_far_data.degSky += AppMain.amSystemGetFrameRateMain() * 0.01f;
                AppMain.g_map_far_data.degSky2 += AppMain.amSystemGetFrameRateMain() * 0.02f;
            }
        }
        else
        {
            pWork.disp_flag |= 4096U;
        }
        if ( AppMain.g_map_far_data.degSky > 360f )
        {
            AppMain.g_map_far_data.degSky = 0f;
        }
        if ( AppMain.g_map_far_data.degSky2 > 360f )
        {
            AppMain.g_map_far_data.degSky2 = 0f;
        }
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        if ( 1 == num )
        {
            pWork.disp_flag |= 13705472U;
            if ( AppMain.gmMapFarDrawCheckYakei() == 0 )
            {
                return;
            }
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, AppMain.g_map_far_data.pos.x, -30f, AppMain.g_map_far_data.pos.z );
            AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 1.4f, 1.4f, 1.4f );
        }
        else if ( num == 0 )
        {
            pWork.disp_flag |= 4U;
            pWork.disp_flag |= 13705472U;
            if ( num2 == 3 )
            {
                return;
            }
            if ( num2 == 0 )
            {
                if ( AppMain.g_map_far_data.pos.y <= 10f && AppMain.g_map_far_data.pos.z <= -182f && AppMain.g_map_far_data.pos.z >= -191.8f )
                {
                    return;
                }
                if ( AppMain.g_map_far_data.pos.y <= 7.85f && AppMain.g_map_far_data.pos.z <= -269f && AppMain.g_map_far_data.pos.z >= -304f )
                {
                    return;
                }
                if ( AppMain.g_map_far_data.pos.y <= 9.97f && AppMain.g_map_far_data.pos.z <= -337f && AppMain.g_map_far_data.pos.z >= -358f )
                {
                    return;
                }
                if ( AppMain.g_map_far_data.pos.y >= 7f && AppMain.g_map_far_data.pos.z <= -347f && AppMain.g_map_far_data.pos.z >= -359f )
                {
                    return;
                }
                if ( AppMain.g_map_far_data.pos.z <= -495f && AppMain.g_map_far_data.pos.z >= -503f )
                {
                    return;
                }
            }
            else if ( num2 == 1 )
            {
                if ( AppMain.g_map_far_data.pos.y <= 6.47f && AppMain.g_map_far_data.pos.z <= -135.4f && AppMain.g_map_far_data.pos.z >= -156f )
                {
                    return;
                }
                if ( AppMain.g_map_far_data.pos.y <= 3.05f && AppMain.g_map_far_data.pos.z <= -130.4f && AppMain.g_map_far_data.pos.z >= -190f )
                {
                    return;
                }
                if ( AppMain.g_map_far_data.pos.z <= -419f )
                {
                    return;
                }
            }
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, AppMain.g_map_far_data.pos.x, -10f, AppMain.g_map_far_data.pos.z );
        }
        else if ( 4 == num )
        {
            pWork.disp_flag |= 13705472U;
        }
        AppMain.nnRotateYMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, ( int )( ( ushort )AppMain.NNM_DEGtoA16( AppMain.g_map_far_data.degSky ) ) );
        AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
    }

    // Token: 0x060011D5 RID: 4565 RVA: 0x0009CFCC File Offset: 0x0009B1CC
    private static void gmMapFarSceneObjFuncDrawWheel( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        float num = -30f;
        float x = 50f;
        int num2 = AppMain.gmMapFarGetStageId();
        if ( 7 == num2 )
        {
            return;
        }
        pWork.disp_flag |= 4U;
        pWork.disp_flag |= 9502720U;
        if ( num2 == 4 )
        {
            if ( AppMain.g_map_far_data.pos.z >= -119.4f )
            {
                return;
            }
            if ( AppMain.gmMapFarDrawCheckYakei() == 0 )
            {
                return;
            }
        }
        else
        {
            if ( num2 == 5 )
            {
                return;
            }
            if ( num2 == 6 && AppMain.g_map_far_data.pos.z >= -119.4f )
            {
                return;
            }
        }
        if ( AppMain.ObjObjectPauseCheck( obj_3d.flag ) > 0U )
        {
            pWork.disp_flag |= 4096U;
        }
        else
        {
            pWork.disp_flag &= 4294963199U;
        }
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        if ( num2 == 7 )
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num + 10f, 0f );
        }
        else
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num, -135f );
        }
        AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 1f, 1f, 1f );
        AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
    }

    // Token: 0x060011D6 RID: 4566 RVA: 0x0009D124 File Offset: 0x0009B324
    private static void gmMapFarSceneObjFuncDrawSLight( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        float num = -30f;
        float x = 50f;
        int num2 = AppMain.gmMapFarGetStageId();
        if ( 7 == num2 )
        {
            return;
        }
        pWork.disp_flag |= 4U;
        pWork.disp_flag |= 9502720U;
        if ( AppMain.gmMapFarDrawCheckYakei() == 0 )
        {
            return;
        }
        if ( AppMain.ObjObjectPauseCheck( obj_3d.flag ) > 0U )
        {
            pWork.disp_flag |= 4096U;
        }
        else
        {
            pWork.disp_flag &= 4294963199U;
        }
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        if ( num2 == 7 )
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num + 10f, 0f );
        }
        else
        {
            AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, num, -135f );
        }
        AppMain.nnScaleMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, 1f, 1f, 1f );
        AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
    }

    // Token: 0x060011D7 RID: 4567 RVA: 0x0009D240 File Offset: 0x0009B440
    private static void gmMapFarSceneObjFuncDrawSea( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = pWork.obj_3d;
        int num = AppMain.gmMapFarGetStageId();
        pWork.disp_flag |= 4U;
        pWork.disp_flag |= 13705472U;
        if ( num != 0 && num != 1 && num != 2 && num == 3 )
        {
            return;
        }
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        float x = 40f;
        AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx, obj_3d.user_obj_mtx, x, -10f, AppMain.g_map_far_data.pos.z );
        AppMain.ObjDrawAction3DNN( pWork.obj_3d, new AppMain.VecFx32?( pWork.pos ), new AppMain.VecU16?( pWork.dir ), pWork.scale, ref pWork.disp_flag );
    }

    // Token: 0x060011D8 RID: 4568 RVA: 0x0009D2F0 File Offset: 0x0009B4F0
    private static void gmMapFarDrawSeaUserFunc( object data )
    {
        AppMain.NNS_RGBA_U8 color = new AppMain.NNS_RGBA_U8(0, 0, 0, byte.MaxValue);
        AppMain.amDrawGetProjectionMatrix();
        AppMain.amDrawEndScene();
        AppMain.amRenderSetTarget( AppMain._am_draw_target, AppMain.AMD_RENDER_CLEAR_COLOR | AppMain.AMD_RENDER_CLEAR_DEPTH, color );
    }

    // Token: 0x060011D9 RID: 4569 RVA: 0x0009D330 File Offset: 0x0009B530
    private static void gmMapFarZone1Build()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        string dir;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 0, out dir));
        ams_AMB_HEADER.dir = dir;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER2 = AppMain.readAMBFile(AppMain.amBindGet(header, 1, out dir));
        ams_AMB_HEADER2.dir = dir;
        gms_MAP_FAR_DATA.obj_3d_list = AppMain.GmGameDBuildRegBuildModel( ams_AMB_HEADER, ams_AMB_HEADER2, 0U );
        uint draw_flag = 0U;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER3 = AppMain.readAMBFile(AppMain.amBindGet(header, 3, out dir));
        ams_AMB_HEADER3.dir = dir;
        gms_MAP_FAR_DATA.obj_3d_list_render = AppMain.GmGameDBuildRegBuildModel( ams_AMB_HEADER3, ams_AMB_HEADER2, draw_flag );
    }

    // Token: 0x060011DA RID: 4570 RVA: 0x0009D3B4 File Offset: 0x0009B5B4
    private static bool gmMapFarZone1CheckLoading()
    {
        return true;
    }

    // Token: 0x060011DB RID: 4571 RVA: 0x0009D3C4 File Offset: 0x0009B5C4
    private static void gmMapFarZone1Flush()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        string dir;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 0, out dir));
        ams_AMB_HEADER.dir = dir;
        AppMain.GmGameDBuildRegFlushModel( gms_MAP_FAR_DATA.obj_3d_list, ams_AMB_HEADER.file_num );
        gms_MAP_FAR_DATA.obj_3d_list = null;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER2 = AppMain.readAMBFile(AppMain.amBindGet(header, 3, out dir));
        ams_AMB_HEADER2.dir = dir;
        AppMain.GmGameDBuildRegFlushModel( gms_MAP_FAR_DATA.obj_3d_list_render, ams_AMB_HEADER2.file_num );
        gms_MAP_FAR_DATA.obj_3d_list_render = null;
    }

    // Token: 0x060011DC RID: 4572 RVA: 0x0009D43C File Offset: 0x0009B63C
    private static void gmMapFarZone1Init()
    {
        int num = AppMain.gmMapFarGetStageId();
        AppMain.gmMapFarChangeTcbProcDraw( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMpaFarZone1TcbProcDraw ) );
        AppMain.gmMapFarCameraSetInfo( 1, 0 );
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list;
        int scroll_info_num;
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list2;
        int scroll_info_num2;
        if ( num == 3 )
        {
            scroll_list = AppMain.g_map_far_zone_1_boss_scroll_x;
            scroll_info_num = AppMain.g_map_far_zone_1_boss_scroll_x.Length;
            scroll_list2 = AppMain.g_map_far_zone_1_boss_scroll_y;
            scroll_info_num2 = AppMain.g_map_far_zone_1_boss_scroll_y.Length;
        }
        else
        {
            scroll_list = AppMain.g_map_far_zone_1_scroll_x;
            scroll_info_num = AppMain.g_map_far_zone_1_scroll_num_x;
            scroll_list2 = AppMain.g_map_far_zone_1_scroll_y;
            scroll_info_num2 = AppMain.g_map_far_zone_1_scroll_num_y;
        }
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        int num2 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list, (uint)scroll_info_num);
        int num3 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list2, (uint)scroll_info_num2);
        float speed_x = (float)num2 / (float)(mp_HEADER.map_w * 64);
        float speed_y = (float)num3 / (float)(mp_HEADER.map_h * 64);
        AppMain.gmMapFarCameraSetSpeed( speed_x, speed_y );
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        int num4 = 0;
        while ( 6 > num4 )
        {
            uint num5 = AppMain.g_map_far_zone_1_scene_obj_data[num4];
            AppMain.OBS_ACTION3D_NN_WORK obj_3d_work;
            if ( num4 == 0 )
            {
                obj_3d_work = gms_MAP_FAR_DATA.obj_3d_list_render[( int )( ( UIntPtr )num5 )];
            }
            else
            {
                obj_3d_work = gms_MAP_FAR_DATA.obj_3d_list[( int )( ( UIntPtr )num5 )];
            }
            uint command_state;
            if ( num4 >= 0 )
            {
                command_state = 2U;
            }
            else
            {
                command_state = 1U;
            }
            uint num6 = AppMain.g_map_far_zone_1_scene_obj_data_mat_motion[num4];
            AppMain.AMS_AMB_HEADER mat_amb_header = null;
            if ( 4294967295U != num6 )
            {
                AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
                mat_amb_header = AppMain.readAMBFile( AppMain.amBindGet( header, 2 ) );
            }
            AppMain.gmMapFarSceneLoadObj( ( AppMain.GMD_MAP_FAR_OBJ_INDEX )num4, obj_3d_work, num6, mat_amb_header, 0U, null, AppMain.g_map_far_zone_1_scene_obj_func_main[num4], AppMain.g_map_far_zone_1_scene_obj_func_out[num4], command_state );
            num4++;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmMapFarDataGetObjWork(AppMain.GMD_MAP_FAR_OBJ_INDEX.GMD_MAP_FAR_OBJ_INDEX_ZONE_1_SKY);
        obs_OBJECT_WORK.scale.y = 8192;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.gmMapFarDataGetObjWork(AppMain.GMD_MAP_FAR_OBJ_INDEX.GMD_MAP_FAR_OBJ_INDEX_ZONE_1_SEA);
        obs_OBJECT_WORK2.disp_flag |= 4U;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK2, 0 );
        obs_OBJECT_WORK2.obj_3d.mat_speed = 0.2f;
        int num7 = 0;
        while ( 6 > num7 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = AppMain.gmMapFarDataGetObjWork((AppMain.GMD_MAP_FAR_OBJ_INDEX)num7);
            obs_OBJECT_WORK3.user_work = ( uint )num7;
            num7++;
        }
    }

    // Token: 0x060011DD RID: 4573 RVA: 0x0009D5FC File Offset: 0x0009B7FC
    private static void gmMapFarZone1Release()
    {
    }

    // Token: 0x060011DE RID: 4574 RVA: 0x0009D5FE File Offset: 0x0009B7FE
    private static void gmMpaFarZone1TcbProcDraw( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060011DF RID: 4575 RVA: 0x0009D600 File Offset: 0x0009B800
    private static AppMain.NNS_VECTOR gmMapFarZone1GetCameraPos( AppMain.NNS_VECTOR player_camera_pos )
    {
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.gmMapFarZone1GetCameraPos_result;
        nns_VECTOR.Assign( player_camera_pos );
        nns_VECTOR.y += ( float )( mp_HEADER.map_h * 64 );
        nns_VECTOR = AppMain.gmMapFarCameraGetPos( nns_VECTOR, AppMain.g_map_far_zone_1_scroll_x, ( uint )AppMain.g_map_far_zone_1_scroll_num_x, AppMain.g_map_far_zone_1_scroll_y, ( uint )AppMain.g_map_far_zone_1_scroll_num_y );
        float z = nns_VECTOR.z;
        nns_VECTOR.z = -nns_VECTOR.x;
        nns_VECTOR.y = nns_VECTOR.y;
        nns_VECTOR.x = z;
        AppMain.g_map_far_data.pos.Assign( nns_VECTOR );
        return nns_VECTOR;
    }

    // Token: 0x060011E0 RID: 4576 RVA: 0x0009D68C File Offset: 0x0009B88C
    private static void gmMapFarZone2Build()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER mdl_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.AMS_AMB_HEADER tex_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 3));
        gms_MAP_FAR_DATA.obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
    }

    // Token: 0x060011E1 RID: 4577 RVA: 0x0009D6D0 File Offset: 0x0009B8D0
    private static bool gmMapFarZone2CheckLoading()
    {
        return true;
    }

    // Token: 0x060011E2 RID: 4578 RVA: 0x0009D6E0 File Offset: 0x0009B8E0
    private static void gmMapFarZone2Flush()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.GmGameDBuildRegFlushModel( gms_MAP_FAR_DATA.obj_3d_list, ams_AMB_HEADER.file_num );
        gms_MAP_FAR_DATA.obj_3d_list = null;
    }

    // Token: 0x060011E3 RID: 4579 RVA: 0x0009D720 File Offset: 0x0009B920
    private static void gmMapFarZone2Init()
    {
        int num = AppMain.gmMapFarGetStageId();
        AppMain.gmMapFarChangeTcbProcDraw( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMpaFarZone2TcbProcDraw ) );
        AppMain.gmMapFarCameraSetInfo( 1, 0 );
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list;
        int scroll_info_num;
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list2;
        int scroll_info_num2;
        if ( num == 7 )
        {
            scroll_list = AppMain.g_map_far_zone_2_boss_scroll_x;
            scroll_info_num = AppMain.g_map_far_zone_2_boss_scroll_x.Length;
            scroll_list2 = AppMain.g_map_far_zone_2_boss_scroll_y;
            scroll_info_num2 = AppMain.g_map_far_zone_2_boss_scroll_y.Length;
        }
        else
        {
            scroll_list = AppMain.g_map_far_zone_2_scroll_x;
            scroll_info_num = AppMain.g_map_far_zone_2_scroll_num_x;
            scroll_list2 = AppMain.g_map_far_zone_2_scroll_y;
            scroll_info_num2 = AppMain.g_map_far_zone_2_scroll_num_y;
        }
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        int num2 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list, (uint)scroll_info_num);
        int num3 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list2, (uint)scroll_info_num2);
        float speed_x = (float)num2 / (float)(mp_HEADER.map_w * 64);
        float speed_y = (float)num3 / (float)(mp_HEADER.map_h * 64);
        AppMain.gmMapFarCameraSetSpeed( speed_x, speed_y );
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        int num4 = 0;
        while ( 3 > num4 )
        {
            uint num5 = AppMain.g_map_far_zone_2_scene_obj_data[num4];
            AppMain.OBS_ACTION3D_NN_WORK obj_3d_work = gms_MAP_FAR_DATA.obj_3d_list[(int)((UIntPtr)num5)];
            uint command_state = 1U;
            uint num6 = AppMain.g_map_far_zone_2_scene_obj_data_motion[num4];
            AppMain.AMS_AMB_HEADER mtn_amb_header = null;
            if ( 4294967295U != num6 )
            {
                AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
                mtn_amb_header = AppMain.readAMBFile( AppMain.amBindGet( header, 1 ) );
            }
            uint num7 = AppMain.g_map_far_zone_2_scene_obj_data_mat_motion[num4];
            AppMain.AMS_AMB_HEADER mat_amb_header = null;
            if ( 4294967295U != num7 )
            {
                AppMain.AMS_AMB_HEADER header2 = AppMain.gmMapFarDataGetAmbHeader();
                mat_amb_header = AppMain.readAMBFile( AppMain.amBindGet( header2, 2 ) );
            }
            AppMain.gmMapFarSceneLoadObj( ( AppMain.GMD_MAP_FAR_OBJ_INDEX )num4, obj_3d_work, num7, mat_amb_header, num6, mtn_amb_header, AppMain.g_map_far_zone_2_scene_obj_func_main[num4], AppMain.g_map_far_zone_2_scene_obj_func_out[num4], command_state );
            num4++;
        }
        int num8 = 0;
        while ( 3 > num8 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmMapFarDataGetObjWork((AppMain.GMD_MAP_FAR_OBJ_INDEX)num8);
            obs_OBJECT_WORK.user_work = ( uint )num8;
            num8++;
        }
    }

    // Token: 0x060011E4 RID: 4580 RVA: 0x0009D8A4 File Offset: 0x0009BAA4
    private static void gmMapFarZone2Release()
    {
    }

    // Token: 0x060011E5 RID: 4581 RVA: 0x0009D8A6 File Offset: 0x0009BAA6
    private static void gmMpaFarZone2TcbProcDraw( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060011E6 RID: 4582 RVA: 0x0009D8A8 File Offset: 0x0009BAA8
    private static AppMain.NNS_VECTOR gmMapFarZone2GetCameraPos( AppMain.NNS_VECTOR player_camera_pos )
    {
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.gmMapFarZone2GetCameraPos_result;
        nns_VECTOR.Assign( player_camera_pos );
        nns_VECTOR.y += ( float )( mp_HEADER.map_h * 64 );
        nns_VECTOR = AppMain.gmMapFarCameraGetPos( nns_VECTOR, AppMain.g_map_far_zone_2_scroll_x, ( uint )AppMain.g_map_far_zone_2_scroll_num_x, AppMain.g_map_far_zone_2_scroll_y, ( uint )AppMain.g_map_far_zone_2_scroll_num_y );
        float z = nns_VECTOR.z;
        nns_VECTOR.z = -nns_VECTOR.x;
        nns_VECTOR.y = nns_VECTOR.y;
        nns_VECTOR.x = z;
        AppMain.g_map_far_data.pos.Assign( nns_VECTOR );
        return nns_VECTOR;
    }

    // Token: 0x060011E7 RID: 4583 RVA: 0x0009D934 File Offset: 0x0009BB34
    private static void gmMapFarZone3Build()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER mdl_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.AMS_AMB_HEADER tex_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 1));
        gms_MAP_FAR_DATA.obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
    }

    // Token: 0x060011E8 RID: 4584 RVA: 0x0009D978 File Offset: 0x0009BB78
    private static bool gmMapFarZone3CheckLoading()
    {
        return true;
    }

    // Token: 0x060011E9 RID: 4585 RVA: 0x0009D988 File Offset: 0x0009BB88
    private static void gmMapFarZone3Flush()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.GmGameDBuildRegFlushModel( gms_MAP_FAR_DATA.obj_3d_list, ams_AMB_HEADER.file_num );
        gms_MAP_FAR_DATA.obj_3d_list = null;
    }

    // Token: 0x060011EA RID: 4586 RVA: 0x0009D9C8 File Offset: 0x0009BBC8
    private static void gmMapFarZone3Init()
    {
        AppMain.gmMapFarChangeTcbProcDraw( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMpaFarZone3TcbProcDraw ) );
        AppMain.gmMapFarCameraSetInfo( 1, 0 );
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list = AppMain.g_map_far_zone_3_scroll_x;
        int scroll_info_num = AppMain.g_map_far_zone_3_scroll_num_x;
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list2 = AppMain.g_map_far_zone_3_scroll_y;
        int scroll_info_num2 = AppMain.g_map_far_zone_3_scroll_num_y;
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        int num = AppMain.gmMapFarCameraGetScrollDistance(scroll_list, (uint)scroll_info_num);
        int num2 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list2, (uint)scroll_info_num2);
        float speed_x = (float)num / (float)(mp_HEADER.map_w * 64);
        float speed_y = (float)num2 / (float)(mp_HEADER.map_h * 64);
        AppMain.gmMapFarCameraSetSpeed( speed_x, speed_y );
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        int num3 = 0;
        while ( 1 > num3 )
        {
            uint num4 = AppMain.g_map_far_zone_3_scene_obj_data[num3];
            AppMain.OBS_ACTION3D_NN_WORK obj_3d_work = gms_MAP_FAR_DATA.obj_3d_list[(int)((UIntPtr)num4)];
            uint command_state = 2U;
            uint num5 = AppMain.g_map_far_zone_3_scene_obj_data_mat_motion[num3];
            AppMain.AMS_AMB_HEADER mat_amb_header = null;
            if ( 4294967295U != num5 )
            {
                AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
                mat_amb_header = AppMain.readAMBFile( AppMain.amBindGet( header, 2 ) );
            }
            AppMain.gmMapFarSceneLoadObj( ( AppMain.GMD_MAP_FAR_OBJ_INDEX )num3, obj_3d_work, num5, mat_amb_header, 0U, null, AppMain.g_map_far_zone_3_scene_obj_func_main[num3], AppMain.g_map_far_zone_3_scene_obj_func_out[num3], command_state );
            num3++;
        }
        int num6 = 0;
        while ( 1 > num6 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmMapFarDataGetObjWork((AppMain.GMD_MAP_FAR_OBJ_INDEX)num6);
            obs_OBJECT_WORK.user_work = ( uint )num6;
            num6++;
        }
    }

    // Token: 0x060011EB RID: 4587 RVA: 0x0009DAED File Offset: 0x0009BCED
    private static void gmMapFarZone3Release()
    {
    }

    // Token: 0x060011EC RID: 4588 RVA: 0x0009DAEF File Offset: 0x0009BCEF
    private static void gmMpaFarZone3TcbProcDraw( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060011ED RID: 4589 RVA: 0x0009DAF4 File Offset: 0x0009BCF4
    private static AppMain.NNS_VECTOR gmMapFarZone3GetCameraPos( AppMain.NNS_VECTOR player_camera_pos )
    {
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.gmMapFarZone3GetCameraPos_result;
        nns_VECTOR.Assign( player_camera_pos );
        nns_VECTOR.y += ( float )( mp_HEADER.map_h * 64 );
        nns_VECTOR = AppMain.gmMapFarCameraGetPos( nns_VECTOR, AppMain.g_map_far_zone_3_scroll_x, ( uint )AppMain.g_map_far_zone_3_scroll_num_x, AppMain.g_map_far_zone_3_scroll_y, ( uint )AppMain.g_map_far_zone_3_scroll_num_y );
        float z = nns_VECTOR.z;
        nns_VECTOR.z = -nns_VECTOR.x;
        nns_VECTOR.y = nns_VECTOR.y;
        nns_VECTOR.x = z;
        AppMain.g_map_far_data.pos.Assign( nns_VECTOR );
        return nns_VECTOR;
    }

    // Token: 0x060011EE RID: 4590 RVA: 0x0009DB80 File Offset: 0x0009BD80
    private static void gmMapFarZone4Build()
    {
    }

    // Token: 0x060011EF RID: 4591 RVA: 0x0009DB82 File Offset: 0x0009BD82
    private static bool gmMapFarZone4CheckLoading()
    {
        return true;
    }

    // Token: 0x060011F0 RID: 4592 RVA: 0x0009DB85 File Offset: 0x0009BD85
    private static void gmMapFarZone4Flush()
    {
    }

    // Token: 0x060011F1 RID: 4593 RVA: 0x0009DB87 File Offset: 0x0009BD87
    private static void gmMapFarZone4Init()
    {
        AppMain.gmMapFarChangeTcbProcDraw( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMpaFarZone4TcbProcDraw ) );
    }

    // Token: 0x060011F2 RID: 4594 RVA: 0x0009DB9A File Offset: 0x0009BD9A
    private static void gmMapFarZone4Release()
    {
    }

    // Token: 0x060011F3 RID: 4595 RVA: 0x0009DB9C File Offset: 0x0009BD9C
    private static void gmMpaFarZone4TcbProcDraw( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060011F4 RID: 4596 RVA: 0x0009DBA0 File Offset: 0x0009BDA0
    private static void gmMapFarZoneFinalBuild()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER mdl_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.AMS_AMB_HEADER tex_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 1));
        gms_MAP_FAR_DATA.obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
    }

    // Token: 0x060011F5 RID: 4597 RVA: 0x0009DBE1 File Offset: 0x0009BDE1
    private static bool gmMapFarZoneFinalCheckLoading()
    {
        return true;
    }

    // Token: 0x060011F6 RID: 4598 RVA: 0x0009DBE4 File Offset: 0x0009BDE4
    private static void gmMapFarZoneFinalFlush()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.GmGameDBuildRegFlushModel( gms_MAP_FAR_DATA.obj_3d_list, ams_AMB_HEADER.file_num );
        gms_MAP_FAR_DATA.obj_3d_list = null;
    }

    // Token: 0x060011F7 RID: 4599 RVA: 0x0009DC24 File Offset: 0x0009BE24
    private static void gmMapFarZoneFinalInit()
    {
        AppMain.gmMapFarChangeTcbProcDraw( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMpaFarZoneFinalTcbProcDraw ) );
        AppMain.gmMapFarCameraSetInfo( 1, 0 );
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list = AppMain.g_map_far_zone_final_scroll_x;
        int scroll_info_num = AppMain.g_map_far_zone_final_scroll_num_x;
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list2 = AppMain.g_map_far_zone_final_scroll_y;
        int scroll_info_num2 = AppMain.g_map_far_zone_final_scroll_num_y;
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        int num = AppMain.gmMapFarCameraGetScrollDistance(scroll_list, (uint)scroll_info_num);
        int num2 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list2, (uint)scroll_info_num2);
        float speed_x = (float)num / (float)(mp_HEADER.map_w * 64);
        float speed_y = (float)num2 / (float)(mp_HEADER.map_h * 64);
        AppMain.gmMapFarCameraSetSpeed( speed_x, speed_y );
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        int num3 = 0;
        while ( 1 > num3 )
        {
            uint num4 = AppMain.g_map_far_zone_final_scene_obj_data[num3];
            AppMain.OBS_ACTION3D_NN_WORK obj_3d_work = gms_MAP_FAR_DATA.obj_3d_list[(int)((UIntPtr)num4)];
            AppMain.gmMapFarSceneLoadObj( ( AppMain.GMD_MAP_FAR_OBJ_INDEX )num3, obj_3d_work, uint.MaxValue, null, 0U, null, AppMain.g_map_far_zone_final_scene_obj_func_main[num3], AppMain.g_map_far_zone_final_scene_obj_func_out[num3], 2U );
            num3++;
        }
        int num5 = 0;
        while ( 1 > num5 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmMapFarDataGetObjWork((AppMain.GMD_MAP_FAR_OBJ_INDEX)num5);
            obs_OBJECT_WORK.user_work = ( uint )num5;
            num5++;
        }
    }

    // Token: 0x060011F8 RID: 4600 RVA: 0x0009DD1B File Offset: 0x0009BF1B
    private static void gmMapFarZoneFinalRelease()
    {
    }

    // Token: 0x060011F9 RID: 4601 RVA: 0x0009DD1D File Offset: 0x0009BF1D
    private static void gmMpaFarZoneFinalTcbProcDraw( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060011FA RID: 4602 RVA: 0x0009DD20 File Offset: 0x0009BF20
    private static AppMain.NNS_VECTOR gmMapFarZoneFinalGetCameraPos( AppMain.NNS_VECTOR player_camera_pos )
    {
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.gmMapFarZoneFinalGetCameraPos_result;
        nns_VECTOR.Assign( player_camera_pos );
        nns_VECTOR.y += ( float )( mp_HEADER.map_h * 64 );
        nns_VECTOR = AppMain.gmMapFarCameraGetPos( nns_VECTOR, AppMain.g_map_far_zone_final_scroll_x, ( uint )AppMain.g_map_far_zone_final_scroll_num_x, AppMain.g_map_far_zone_final_scroll_y, ( uint )AppMain.g_map_far_zone_final_scroll_num_y );
        float z = nns_VECTOR.z;
        nns_VECTOR.z = -nns_VECTOR.x;
        nns_VECTOR.y = nns_VECTOR.y;
        nns_VECTOR.x = z;
        AppMain.g_map_far_data.pos.Assign( nns_VECTOR );
        return nns_VECTOR;
    }

    // Token: 0x060011FB RID: 4603 RVA: 0x0009DDAC File Offset: 0x0009BFAC
    private static void gmMapFarZoneSSBuild()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER mdl_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.AMS_AMB_HEADER tex_amb = AppMain.readAMBFile(AppMain.amBindGet(header, 1));
        gms_MAP_FAR_DATA.obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
    }

    // Token: 0x060011FC RID: 4604 RVA: 0x0009DDF0 File Offset: 0x0009BFF0
    private static bool gmMapFarZoneSSCheckLoading()
    {
        return true;
    }

    // Token: 0x060011FD RID: 4605 RVA: 0x0009DE00 File Offset: 0x0009C000
    private static void gmMapFarZoneSSFlush()
    {
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 0));
        AppMain.GmGameDBuildRegFlushModel( gms_MAP_FAR_DATA.obj_3d_list, ams_AMB_HEADER.file_num );
        gms_MAP_FAR_DATA.obj_3d_list = null;
    }

    // Token: 0x060011FE RID: 4606 RVA: 0x0009DE40 File Offset: 0x0009C040
    private static void gmMapFarZoneSSInit()
    {
        AppMain.gmMapFarChangeTcbProcDraw( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMpaFarZoneSSTcbProcDraw ) );
        AppMain.gmMapFarCameraSetInfo( 1, 0 );
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list = AppMain.g_map_far_zone_ss_scroll_x;
        int scroll_info_num = AppMain.g_map_far_zone_ss_scroll_num_x;
        AppMain.GMS_MAP_FAR_SCROLL[] scroll_list2 = AppMain.g_map_far_zone_ss_scroll_y;
        int scroll_info_num2 = AppMain.g_map_far_zone_ss_scroll_num_y;
        AppMain.MP_HEADER mp_HEADER = AppMain.gmMapFarGetMapsetMpA();
        int num = AppMain.gmMapFarCameraGetScrollDistance(scroll_list, (uint)scroll_info_num);
        int num2 = AppMain.gmMapFarCameraGetScrollDistance(scroll_list2, (uint)scroll_info_num2);
        float speed_x = (float)num / (float)(mp_HEADER.map_w * 64);
        float speed_y = (float)num2 / (float)(mp_HEADER.map_h * 64);
        AppMain.gmMapFarCameraSetSpeed( speed_x, speed_y );
        AppMain.GMS_MAP_FAR_DATA gms_MAP_FAR_DATA = AppMain.gmMapFarDataGetInfo();
        int num3 = 0;
        while ( 1 > num3 )
        {
            uint num4 = AppMain.g_map_far_zone_ss_scene_obj_data[num3];
            AppMain.OBS_ACTION3D_NN_WORK obj_3d_work = gms_MAP_FAR_DATA.obj_3d_list[(int)((UIntPtr)num4)];
            uint num5 = AppMain.g_map_far_zone_ss_scene_obj_data_mat_motion[num3];
            AppMain.AMS_AMB_HEADER mat_amb_header = null;
            if ( 4294967295U != num5 )
            {
                AppMain.AMS_AMB_HEADER header = AppMain.gmMapFarDataGetAmbHeader();
                mat_amb_header = AppMain.readAMBFile( AppMain.amBindGet( header, 2 ) );
            }
            AppMain.gmMapFarSceneLoadObj( ( AppMain.GMD_MAP_FAR_OBJ_INDEX )num3, obj_3d_work, num5, mat_amb_header, 0U, null, AppMain.g_map_far_zone_ss_scene_obj_func_main[num3], AppMain.g_map_far_zone_ss_scene_obj_func_out[num3], 1U );
            num3++;
        }
    }

    // Token: 0x060011FF RID: 4607 RVA: 0x0009DF42 File Offset: 0x0009C142
    private static void gmMapFarZoneSSRelease()
    {
    }

    // Token: 0x06001200 RID: 4608 RVA: 0x0009DF44 File Offset: 0x0009C144
    private static void gmMpaFarZoneSSTcbProcDraw( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06001201 RID: 4609 RVA: 0x0009DF48 File Offset: 0x0009C148
    private static AppMain.NNS_VECTOR gmMapFarZoneSSGetCameraPos( AppMain.NNS_VECTOR player_camera_pos )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.gmMapFarZoneSSGetCameraPos_result;
        nns_VECTOR.Assign( player_camera_pos );
        nns_VECTOR.x = ( float )AppMain.OBD_LCD_X;
        nns_VECTOR.y = ( float )AppMain.OBD_LCD_Y;
        nns_VECTOR.z = 50f;
        return nns_VECTOR;
    }
}