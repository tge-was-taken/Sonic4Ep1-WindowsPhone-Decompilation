using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Runtime.InteropServices;

public partial class AppMain
{
    // Token: 0x020000CA RID: 202
    public enum OBD_DRAW_USER_COMMAND_3DNN
    {
        // Token: 0x04004BB7 RID: 19383
        OBD_DRAW_USER_COMMAND_3DNN_MODEL,
        // Token: 0x04004BB8 RID: 19384
        OBD_DRAW_USER_COMMAND_3DNN_MODEL_MATMTN,
        // Token: 0x04004BB9 RID: 19385
        OBD_DRAW_USER_COMMAND_3DNN_MOTION,
        // Token: 0x04004BBA RID: 19386
        OBD_DRAW_USER_COMMAND_3DNN_MOTION_MATMTN,
        // Token: 0x04004BBB RID: 19387
        OBD_DRAW_USER_COMMAND_3DNN_SET_CAMERA,
        // Token: 0x04004BBC RID: 19388
        OBD_DRAW_USER_COMMAND_3DNN_USER_FUNC,
        // Token: 0x04004BBD RID: 19389
        OBD_DRAW_USER_COMMAND_3DNN_DRAW_MOTION,
        // Token: 0x04004BBE RID: 19390
        OBD_DRAW_USER_COMMAND_3DNN_DRAW_MOTION_MATMTN,
        // Token: 0x04004BBF RID: 19391
        OBD_DRAW_USER_COMMAND_3DNN_MAX
    }

    // Token: 0x020000CB RID: 203
    public enum OBD_DRAW_USER_COMMAND_SORT_3DNN
    {
        // Token: 0x04004BC1 RID: 19393
        OBD_DRAW_USER_COMMAND_SORT_3DNN_MODEL,
        // Token: 0x04004BC2 RID: 19394
        OBD_DRAW_USER_COMMAND_SORT_3DNN_MATMTN,
        // Token: 0x04004BC3 RID: 19395
        OBD_DRAW_USER_COMMAND_SORT_3DNN_MAX
    }

    // Token: 0x020000CC RID: 204
    // (Invoke) Token: 0x06001F08 RID: 7944
    public delegate void OBF_DRAW_USER_DT_FUNC( object o );

    // Token: 0x020000CD RID: 205
    public class OBS_DRAW_PARAM_3DNN_USER_FUNC
    {
        // Token: 0x04004BC4 RID: 19396
        public AppMain.OBF_DRAW_USER_DT_FUNC func;

        // Token: 0x04004BC5 RID: 19397
        public object param;
    }

    // Token: 0x020000CE RID: 206
    // (Invoke) Token: 0x06001F0D RID: 7949
    public delegate void OBF_DRAW_USER_FUNC( object o );

    // Token: 0x020000CF RID: 207
    // (Invoke) Token: 0x06001F11 RID: 7953
    public delegate void OBF_DRAW_3DNN_MPLT_CB_FUNC( ref Matrix mtx_plt, AppMain.NNS_OBJECT _object, object mplt_cb_param );

    // Token: 0x020000D0 RID: 208
    // (Invoke) Token: 0x06001F15 RID: 7957
    public delegate void OBF_DRAW_3DNN_MOTION_CB_FUNC( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object mtn_cb_param );

    // Token: 0x020000D1 RID: 209
    private class OBS_DRAW_PARAM_3DNN_MODEL
    {
        // Token: 0x06001F18 RID: 7960 RVA: 0x0013CDC2 File Offset: 0x0013AFC2
        public OBS_DRAW_PARAM_3DNN_MODEL()
        {
            this.param = new AppMain.AMS_PARAM_DRAW_OBJECT( this );
        }

        // Token: 0x04004BC6 RID: 19398
        public readonly AppMain.AMS_PARAM_DRAW_OBJECT param;

        // Token: 0x04004BC7 RID: 19399
        public readonly AppMain.NNS_MATRIX mtx = new AppMain.NNS_MATRIX();

        // Token: 0x04004BC8 RID: 19400
        public readonly AppMain.AMS_DRAWSTATE draw_state = new AppMain.AMS_DRAWSTATE();

        // Token: 0x04004BC9 RID: 19401
        public AppMain.AMS_DRAWSTATE state;

        // Token: 0x04004BCA RID: 19402
        public AppMain.MPP_VOID_OBJECT_DELEGATE user_func;

        // Token: 0x04004BCB RID: 19403
        public object user_param;

        // Token: 0x04004BCC RID: 19404
        public AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func;

        // Token: 0x04004BCD RID: 19405
        public object material_cb_param;

        // Token: 0x04004BCE RID: 19406
        public uint use_light_flag;
    }

    // Token: 0x020000D2 RID: 210
    private class OBS_DRAW_PARAM_3DNN_MOTION : AppMain.IClearable
    {
        // Token: 0x06001F19 RID: 7961 RVA: 0x0013CDEC File Offset: 0x0013AFEC
        public OBS_DRAW_PARAM_3DNN_MOTION()
        {
            this.param = new AppMain.AMS_PARAM_DRAW_MOTION_TRS( this );
        }

        // Token: 0x06001F1A RID: 7962 RVA: 0x0013CE16 File Offset: 0x0013B016
        public void Clear()
        {
            AppMain.mppAssertNotImpl();
        }

        // Token: 0x04004BCF RID: 19407
        public readonly AppMain.AMS_PARAM_DRAW_MOTION_TRS param;

        // Token: 0x04004BD0 RID: 19408
        public readonly AppMain.NNS_MATRIX mtx = new AppMain.NNS_MATRIX();

        // Token: 0x04004BD1 RID: 19409
        public readonly AppMain.AMS_DRAWSTATE draw_state = new AppMain.AMS_DRAWSTATE();

        // Token: 0x04004BD2 RID: 19410
        public AppMain.AMS_DRAWSTATE state;

        // Token: 0x04004BD3 RID: 19411
        public AppMain.MPP_VOID_OBJECT_DELEGATE user_func;

        // Token: 0x04004BD4 RID: 19412
        public object user_param;

        // Token: 0x04004BD5 RID: 19413
        public AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func;

        // Token: 0x04004BD6 RID: 19414
        public object mplt_cb_param;

        // Token: 0x04004BD7 RID: 19415
        public AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func;

        // Token: 0x04004BD8 RID: 19416
        public object material_cb_param;

        // Token: 0x04004BD9 RID: 19417
        public uint use_light_flag;
    }

    // Token: 0x020000D3 RID: 211
    // (Invoke) Token: 0x06001F1C RID: 7964
    public delegate void OBS_DRAW_PARAM_3DNN_DRAW_MOTION_FUNC( object pObj );

    // Token: 0x020000D4 RID: 212
    private class OBS_DRAW_PARAM_3DNN_DRAW_MOTION
    {
        // Token: 0x06001F1F RID: 7967 RVA: 0x0013CE1D File Offset: 0x0013B01D
        public OBS_DRAW_PARAM_3DNN_DRAW_MOTION()
        {
            this.param = new AppMain.AMS_PARAM_DRAW_MOTION( this );
        }

        // Token: 0x04004BDA RID: 19418
        public readonly AppMain.AMS_PARAM_DRAW_MOTION param;

        // Token: 0x04004BDB RID: 19419
        public readonly AppMain.NNS_MATRIX mtx = new AppMain.NNS_MATRIX();

        // Token: 0x04004BDC RID: 19420
        public readonly AppMain.AMS_DRAWSTATE draw_state = new AppMain.AMS_DRAWSTATE();

        // Token: 0x04004BDD RID: 19421
        public AppMain.AMS_DRAWSTATE state;

        // Token: 0x04004BDE RID: 19422
        public AppMain.MPP_VOID_OBJECT_DELEGATE user_func;

        // Token: 0x04004BDF RID: 19423
        public object user_param;

        // Token: 0x04004BE0 RID: 19424
        public AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func;

        // Token: 0x04004BE1 RID: 19425
        public object mplt_cb_param;

        // Token: 0x04004BE2 RID: 19426
        public AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func;

        // Token: 0x04004BE3 RID: 19427
        public object material_cb_param;

        // Token: 0x04004BE4 RID: 19428
        public uint use_light_flag;
    }

    // Token: 0x020000D5 RID: 213
    private class OBS_DRAW_PARAM_3DNN_SORT_MODEL
    {
        // Token: 0x04004BE5 RID: 19429
        public readonly AppMain.AMS_COMMAND_HEADER cmd_header = new AppMain.AMS_COMMAND_HEADER();

        // Token: 0x04004BE6 RID: 19430
        public readonly AppMain.AMS_PARAM_SORT_DRAW_OBJECT param = new AppMain.AMS_PARAM_SORT_DRAW_OBJECT();

        // Token: 0x04004BE7 RID: 19431
        public readonly AppMain.AMS_DRAWSTATE state = new AppMain.AMS_DRAWSTATE();

        // Token: 0x04004BE8 RID: 19432
        public AppMain.OBF_DRAW_USER_FUNC user_func;

        // Token: 0x04004BE9 RID: 19433
        public object user_param;

        // Token: 0x04004BEA RID: 19434
        public AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func;

        // Token: 0x04004BEB RID: 19435
        public object material_cb_param;

        // Token: 0x04004BEC RID: 19436
        public uint use_light_flag;
    }

    // Token: 0x020000D6 RID: 214
    public class OBS_DRAW_PARAM_3DNN_SET_CAMERA
    {
        // Token: 0x04004BED RID: 19437
        public int proj_type;

        // Token: 0x04004BEE RID: 19438
        public readonly AppMain.NNS_MATRIX prj_mtx = new AppMain.NNS_MATRIX();

        // Token: 0x04004BEF RID: 19439
        public readonly AppMain.NNS_MATRIX view_mtx = new AppMain.NNS_MATRIX();
    }

    // Token: 0x020000D7 RID: 215
    private class OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE
    {
        // Token: 0x06001F22 RID: 7970 RVA: 0x0013CE8E File Offset: 0x0013B08E
        public OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE()
        {
        }

        // Token: 0x06001F23 RID: 7971 RVA: 0x0013CEAC File Offset: 0x0013B0AC
        public OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE( AppMain.OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE param )
        {
            this.dat.Assign( param.dat );
            this.mtx.Assign( param.mtx );
            this.light = param.light;
            this.cull = param.cull;
        }

        // Token: 0x04004BF0 RID: 19440
        public readonly AppMain.AMS_PARAM_DRAW_PRIMITIVE dat = new AppMain.AMS_PARAM_DRAW_PRIMITIVE();

        // Token: 0x04004BF1 RID: 19441
        public readonly AppMain.NNS_MATRIX mtx = new AppMain.NNS_MATRIX();

        // Token: 0x04004BF2 RID: 19442
        public int light;

        // Token: 0x04004BF3 RID: 19443
        public int cull;
    }

    // Token: 0x020000D8 RID: 216
    // (Invoke) Token: 0x06001F25 RID: 7973
    public delegate void MPP_VOID_AMSCOMMANDHEADER_NNFDRAWOBJ( AppMain.AMS_COMMAND_HEADER h, uint o );

    // Token: 0x020000D9 RID: 217
    private class _objDraw3DNNModel_DT
    {
        // Token: 0x04004BF4 RID: 19444
        public static AppMain.NNS_MATRIX[] plt_mtx;

        // Token: 0x04004BF5 RID: 19445
        public static uint[] nstat;
    }

    // Token: 0x020000DA RID: 218
    private class _objDraw3DNNMotion_DT
    {
        // Token: 0x04004BF6 RID: 19446
        public static AppMain.NNS_MATRIX[] plt_mtx;

        // Token: 0x04004BF7 RID: 19447
        public static uint[] nstat;
    }

    // Token: 0x020000DB RID: 219
    private class _objDraw3DNNDrawMotion_DT
    {
        // Token: 0x04004BF8 RID: 19448
        public static AppMain.NNS_MATRIX[] plt_mtx;

        // Token: 0x04004BF9 RID: 19449
        public static uint[] nstat;
    }

    // Token: 0x06000463 RID: 1123 RVA: 0x000249E3 File Offset: 0x00022BE3
    public static void ObjDrawObjectSetToon( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawSetToon( obj_work.obj_3d );
    }

    // Token: 0x06000464 RID: 1124 RVA: 0x000249F0 File Offset: 0x00022BF0
    public static void objDraw3DNNModelCommandFunc( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.obj_draw_user_command_func_tbl[command.command_id]( command, drawflag );
    }

    // Token: 0x06000465 RID: 1125 RVA: 0x00024A05 File Offset: 0x00022C05
    public static void objDrawResetCache()
    {
        AppMain._objDraw3DNNSetCamera_Pool.ReleaseUsedObjects();
        AppMain._ObjDraw3DNNModel_Pool.ReleaseUsedObjects();
        AppMain.OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE_Pool.ReleaseUsedObjects();
        AppMain.OBS_DRAW_PARAM_3DNN_SORT_MODEL_Pool.ReleaseUsedObjects();
    }

    // Token: 0x06000466 RID: 1126 RVA: 0x00024A30 File Offset: 0x00022C30
    public static void ObjDrawInit()
    {
        AppMain.amDrawSetDrawCommandFunc( new AppMain._am_draw_command_delegate( AppMain.objDraw3DNNModelCommandFunc ), new AppMain._am_draw_command_delegate( AppMain.objDraw3DNNModelCommandSortFunc ) );
        AppMain.ObjDrawClearNNCommandStateTbl();
        AppMain.g_obj_draw_3dnn_draw_state.drawflag = 0U;
        AppMain.g_obj_draw_3dnn_draw_state.diffuse.mode = 3;
        AppMain.g_obj_draw_3dnn_draw_state.diffuse.r = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.diffuse.g = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.diffuse.b = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.ambient.mode = 3;
        AppMain.g_obj_draw_3dnn_draw_state.ambient.r = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.ambient.g = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.ambient.b = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.alpha.mode = 3;
        AppMain.g_obj_draw_3dnn_draw_state.alpha.alpha = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.specular.mode = 3;
        AppMain.g_obj_draw_3dnn_draw_state.specular.r = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.specular.g = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.specular.b = 1f;
        AppMain.g_obj_draw_3dnn_draw_state.blend.mode = 0;
        AppMain.g_obj_draw_3dnn_draw_state.envmap.texsrc = 1;
        AppMain.g_obj_draw_3dnn_draw_state.zmode.compare = 1U;
        AppMain.g_obj_draw_3dnn_draw_state.zmode.func = 515;
        AppMain.g_obj_draw_3dnn_draw_state.zmode.update = 1U;
        AppMain.NNS_MATRIX texmtx = AppMain.g_obj_draw_3dnn_draw_state.envmap.texmtx;
        AppMain.nnMakeUnitMatrix( texmtx );
        AppMain.nnTranslateMatrix( texmtx, texmtx, 0.5f, 0.5f, 0f );
        AppMain.nnScaleMatrix( texmtx, texmtx, 0.5f, 0.5f, 0f );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.g_obj_draw_3dnn_draw_state.texoffset[i].mode = 2;
            AppMain.g_obj_draw_3dnn_draw_state.texoffset[i].u = 0f;
            AppMain.g_obj_draw_3dnn_draw_state.texoffset[i].v = 0f;
        }
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(-1f, -1f, -1f);
        AppMain.g_obj.def_user_light_flag = 1U;
        AppMain.g_obj.ambient_color.r = 0.8f;
        AppMain.g_obj.ambient_color.g = 0.8f;
        AppMain.g_obj.ambient_color.b = 0.8f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        int j = 0;
        AppMain.OBS_LIGHT obs_LIGHT = AppMain.g_obj.light[0];
        while ( j < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.ObjDrawSetParallelLight( j, ref nns_RGBA, 1f, nns_VECTOR );
            j++;
        }
        AppMain.AoActSysSetDrawStateEnable( true );
        AppMain.AoActSysSetDrawState( 6U );
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
    }

    // Token: 0x06000467 RID: 1127 RVA: 0x00024D1B File Offset: 0x00022F1B
    public static void ObjDrawESEffectSystemInit( ushort pause_level, uint task_prio, uint group )
    {
        AppMain.amEffectSystemInit();
        AppMain.obj_draw_effect_server_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.objDraw3DESEffectServerMain ), null, 0U, pause_level, task_prio, ( int )group, null, "ES_EFFECT_SERVER" );
    }

    // Token: 0x06000468 RID: 1128 RVA: 0x00024D43 File Offset: 0x00022F43
    public static bool ObjDrawESEffectSystemIsActive()
    {
        return AppMain.obj_draw_effect_server_tcb != null;
    }

    // Token: 0x06000469 RID: 1129 RVA: 0x00024D4F File Offset: 0x00022F4F
    public static void ObjDrawExit()
    {
        AppMain.nnSetMaterialCallback( null );
        AppMain.AoActSysSetDrawStateEnable( false );
    }

    // Token: 0x0600046A RID: 1130 RVA: 0x00024D5D File Offset: 0x00022F5D
    public static void ObjDrawESEffectSystemExit()
    {
        AppMain.mtTaskClearTcb( AppMain.obj_draw_effect_server_tcb );
        AppMain.obj_draw_effect_server_tcb = null;
    }

    // Token: 0x0600046B RID: 1131 RVA: 0x00024D6F File Offset: 0x00022F6F
    public static void ObjDrawPrioritySet( AppMain.OBS_OBJECT_WORK obj_work, uint prio )
    {
    }

    // Token: 0x0600046C RID: 1132 RVA: 0x00024D74 File Offset: 0x00022F74
    public static void ObjDrawObjectActionSet( AppMain.OBS_OBJECT_WORK obj_work, int id )
    {
        obj_work.disp_flag &= 4294967287U;
        obj_work.disp_flag &= 4294967291U;
        if ( obj_work.obj_3d != null && obj_work.obj_3d.motion != null )
        {
            obj_work.obj_3d.act_id[0] = id;
            AppMain.amMotionSet( obj_work.obj_3d.motion, 0, id );
            obj_work.obj_3d.frame[0] = 0f;
        }
    }

    // Token: 0x0600046D RID: 1133 RVA: 0x00024DE6 File Offset: 0x00022FE6
    public static void ObjDrawObjectActionSet3DNN( AppMain.OBS_OBJECT_WORK obj_work, int id, int mbuf_id )
    {
        obj_work.disp_flag &= 4294967287U;
        obj_work.disp_flag &= 4294967291U;
        AppMain.ObjDrawAction3dActionSet3DNN( obj_work.obj_3d, id, mbuf_id );
    }

    // Token: 0x0600046E RID: 1134 RVA: 0x00024E13 File Offset: 0x00023013
    public static void ObjDrawAction3dActionSet3DNN( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int id, int mbuf_id )
    {
        if ( mbuf_id >= 2 )
        {
            return;
        }
        obj_3d.act_id[mbuf_id] = id;
        AppMain.amMotionSet( obj_3d.motion, mbuf_id, id );
        obj_3d.frame[mbuf_id] = 0f;
    }

    // Token: 0x0600046F RID: 1135 RVA: 0x00024E3D File Offset: 0x0002303D
    public static void ObjDrawObjectActionSet3DNNBlend( AppMain.OBS_OBJECT_WORK obj_work, int id )
    {
        obj_work.disp_flag &= 4294967287U;
        obj_work.disp_flag &= 4294967291U;
        AppMain.ObjDrawAction3dActionSet3DNNBlend( obj_work.obj_3d, id );
    }

    // Token: 0x06000470 RID: 1136 RVA: 0x00024E6C File Offset: 0x0002306C
    public static void ObjDrawAction3dActionSet3DNNBlend( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int id )
    {
        AppMain.ObjDrawAction3dActionSet3DNN( obj_3d, obj_3d.act_id[0], 1 );
        obj_3d.frame[1] = obj_3d.frame[0];
        AppMain.ObjDrawAction3dActionSet3DNN( obj_3d, id, 0 );
        obj_3d.marge = 1f;
        obj_3d.flag |= 1U;
    }

    // Token: 0x06000471 RID: 1137 RVA: 0x00024EB9 File Offset: 0x000230B9
    public static void ObjDrawObjectActionSet3DNNMaterial( AppMain.OBS_OBJECT_WORK obj_work, int id )
    {
        obj_work.disp_flag &= 4294967287U;
        obj_work.disp_flag &= 4294967291U;
        AppMain.ObjDrawAction3dActionSet3DNNMaterial( obj_work.obj_3d, id );
    }

    // Token: 0x06000472 RID: 1138 RVA: 0x00024EE5 File Offset: 0x000230E5
    public static void ObjDrawAction3dActionSet3DNNMaterial( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int id )
    {
        obj_3d.mat_act_id = id;
        AppMain.amMotionMaterialSet( obj_3d.motion, id );
        obj_3d.mat_frame = 0f;
    }

    // Token: 0x06000473 RID: 1139 RVA: 0x00024F05 File Offset: 0x00023105
    public static int ObjDrawActionGet( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3d != null && obj_work.obj_3d.motion != null )
        {
            return obj_work.obj_3d.act_id[0];
        }
        if ( obj_work.obj_2d != null )
        {
            return ( int )obj_work.obj_2d.act_id;
        }
        return 0;
    }

    // Token: 0x06000474 RID: 1140 RVA: 0x00024F3F File Offset: 0x0002313F
    public static int ObjDrawActionGet3DNN( AppMain.OBS_OBJECT_WORK obj_work, int mbuf_id )
    {
        if ( mbuf_id >= 2 )
        {
            return 0;
        }
        if ( obj_work.obj_3d != null && obj_work.obj_3d.motion != null )
        {
            return obj_work.obj_3d.act_id[mbuf_id];
        }
        return 0;
    }

    // Token: 0x06000475 RID: 1141 RVA: 0x00024F6C File Offset: 0x0002316C
    public static void ObjDrawActionSummary( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3d != null && AppMain.ObjAction3dNNModelLoadCheck( obj_work.obj_3d ) )
        {
            AppMain.ObjDrawObjectAction3DNN( obj_work, obj_work.obj_3d );
        }
        if ( obj_work.obj_3des != null && AppMain.ObjAction3dESEffectLoadCheck( obj_work.obj_3des ) )
        {
            AppMain.ObjDrawObjectAction3DES( obj_work, obj_work.obj_3des );
        }
        if ( obj_work.obj_2d != null && AppMain.ObjAction2dAMALoadCheck( obj_work.obj_2d ) )
        {
            AppMain.ObjDrawObjectAction2DAMA( obj_work, obj_work.obj_2d );
        }
    }

    // Token: 0x06000476 RID: 1142 RVA: 0x00024FDC File Offset: 0x000231DC
    public static void ObjDrawClearNNCommandStateTbl()
    {
        int num = 0;
        while ( ( long )num < 18L )
        {
            AppMain.obj_draw_3dnn_command_state_tbl[num] = uint.MaxValue;
            AppMain.obj_draw_3dnn_command_state_exe_end_scene_tbl[num] = false;
            num++;
        }
        AppMain.obj_draw_3dnn_command_state_tbl[0] = 0U;
        AppMain.obj_draw_3dnn_command_state_exe_end_scene_tbl[0] = true;
    }

    // Token: 0x06000477 RID: 1143 RVA: 0x00025018 File Offset: 0x00023218
    public static void ObjDrawSetNNCommandStateTbl( uint tbl_no, uint command_state, bool end_scene )
    {
        AppMain.obj_draw_3dnn_command_state_tbl[( int )( ( UIntPtr )tbl_no )] = command_state;
        AppMain.obj_draw_3dnn_command_state_exe_end_scene_tbl[( int )( ( UIntPtr )tbl_no )] = end_scene;
    }

    // Token: 0x06000478 RID: 1144 RVA: 0x0002502C File Offset: 0x0002322C
    public static void ObjDrawNNStart()
    {
        AppMain.amDrawMakeTask( AppMain._objDrawStart_DT, 4096, null );
    }

    // Token: 0x06000479 RID: 1145 RVA: 0x00025040 File Offset: 0x00023240
    public static void ObjDraw3DNNSetCamera( int camera_id, int proj_type )
    {
        AppMain.OBS_CAMERA obs_CAMERA = null;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( camera_id >= 0 )
        {
            obs_CAMERA = AppMain.ObjCameraGet( camera_id );
        }
        AppMain.objDraw3DNNSetCamera( obs_CAMERA, proj_type, obs_CAMERA.command_state );
    }

    // Token: 0x0600047A RID: 1146 RVA: 0x00025070 File Offset: 0x00023270
    public static void ObjDraw3DNNSetCameraEx( int camera_id, int proj_type, uint command_state )
    {
        AppMain.OBS_CAMERA obj_camera = null;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( camera_id >= 0 )
        {
            obj_camera = AppMain.ObjCameraGet( camera_id );
        }
        AppMain.objDraw3DNNSetCamera( obj_camera, proj_type, command_state );
    }

    // Token: 0x0600047B RID: 1147 RVA: 0x0002509A File Offset: 0x0002329A
    public static void ObjDraw3DNNUserFunc( AppMain.OBF_DRAW_USER_DT_FUNC user_func, object param, int param_size, uint command_state )
    {
        AppMain._ObjDraw3DNNUserFunc( user_func, null, command_state );
    }

    // Token: 0x0600047C RID: 1148 RVA: 0x000250A4 File Offset: 0x000232A4
    public static void _ObjDraw3DNNUserFunc( AppMain.OBF_DRAW_USER_DT_FUNC user_func, object param, uint command_state )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_USER_FUNC obs_DRAW_PARAM_3DNN_USER_FUNC = AppMain.amDrawAlloc_OBS_DRAW_PARAM_3DNN_USER_FUNC();
        obs_DRAW_PARAM_3DNN_USER_FUNC.param = param;
        obs_DRAW_PARAM_3DNN_USER_FUNC.func = user_func;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_USER_FUNC, obs_DRAW_PARAM_3DNN_USER_FUNC );
    }

    // Token: 0x0600047D RID: 1149 RVA: 0x000250DC File Offset: 0x000232DC
    public static void ObjDrawObjectAction3DNN( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_NN_WORK obj_3d )
    {
        AppMain.VecFx32 pos = obj_work.pos;
        AppMain.VecU16 vecU = new AppMain.VecU16(obj_work.dir);
        pos.x += obj_work.ofst.x;
        pos.y += obj_work.ofst.y;
        pos.z += obj_work.ofst.z;
        if ( obj_work.dir_fall != 0 )
        {
            vecU.z += obj_work.dir_fall;
        }
        AppMain.ObjDrawAction3DNN( obj_3d, new AppMain.VecFx32?( pos ), new AppMain.VecU16?( vecU ), obj_work.scale, ref obj_work.disp_flag );
    }

    // Token: 0x0600047E RID: 1150 RVA: 0x00025184 File Offset: 0x00023384
    public static void ObjDrawAction3DNN( AppMain.OBS_ACTION3D_NN_WORK obj_3d, AppMain.VecFx32? pos, AppMain.VecU16? dir, AppMain.VecFx32 scale, ref uint p_disp_flag )
    {
        uint? num = new uint?(p_disp_flag);
        AppMain.ObjDrawAction3DNN( obj_3d, pos, dir, new AppMain.VecFx32?( scale ), ref num );
        p_disp_flag = num.Value;
    }

    // Token: 0x0600047F RID: 1151 RVA: 0x000251BC File Offset: 0x000233BC
    public static void ObjDrawAction3DNN( AppMain.OBS_ACTION3D_NN_WORK obj_3d, AppMain.VecFx32? pos, AppMain.VecU16? dir, AppMain.VecFx32? scale, ref uint? p_disp_flag )
    {
        uint num = 0U;
        if ( p_disp_flag != null )
        {
            if ( ( p_disp_flag & 16U ) == 0U )
            {
                p_disp_flag &= 4261412855U;
            }
            num = p_disp_flag.Value;
        }
        if ( obj_3d != null && obj_3d._object != null )
        {
            bool flag = false;
            num &= 3758096383U;
            if ( pos != null && ( num & 293609472U ) == 0U )
            {
                AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain._g_obj.glb_camera_id);
                float num2 = obs_CAMERA.disp_pos.x + obs_CAMERA.bottom;
                float num3 = obs_CAMERA.disp_pos.x + obs_CAMERA.top;
                float num4 = -(obs_CAMERA.disp_pos.y + obs_CAMERA.top);
                float num5 = -(obs_CAMERA.disp_pos.y + obs_CAMERA.bottom);
                float num6 = 1f;
                if ( ( num & 65536U ) == 0U )
                {
                    int num7 = scale.Value.x;
                    int num8 = scale.Value.y;
                    if ( num7 < num8 )
                    {
                        num7 = num8;
                    }
                    num8 = scale.Value.z;
                    if ( num7 < num8 )
                    {
                        num7 = num8;
                    }
                    num6 = AppMain.FX_FX32_TO_F32( num7 );
                }
                num6 *= 3.2f;
                float num9 = AppMain.FX_FX32_TO_F32(pos.Value.x) - obj_3d._object.Radius * 1.2f * num6;
                float num10 = AppMain.FX_FX32_TO_F32(pos.Value.x) + obj_3d._object.Radius * 1.2f * num6;
                float num11 = AppMain.FX_FX32_TO_F32(pos.Value.y) - obj_3d._object.Radius * 1.2f * num6;
                float num12 = AppMain.FX_FX32_TO_F32(pos.Value.y) + obj_3d._object.Radius * 1.2f * num6;
                if ( num2 > num10 )
                {
                    flag = true;
                }
                if ( num3 < num9 )
                {
                    flag = true;
                }
                if ( num4 > num12 )
                {
                    flag = true;
                }
                if ( num5 < num11 )
                {
                    flag = true;
                }
            }
            if ( flag )
            {
                num |= 536870944U;
            }
        }
        if ( ( num & 1073741824U ) != 0U )
        {
            if ( p_disp_flag != null )
            {
                p_disp_flag &= 3758096383U;
                p_disp_flag |= ( num & 570425352U );
            }
            return;
        }
        AppMain.NNS_MATRIX objDrawAction3DNN_obj_mtx = AppMain.ObjDrawAction3DNN_obj_mtx;
        AppMain.VecFx32 value = new AppMain.VecFx32(4096, 4096, 4096);
        AppMain.nnMakeUnitMatrix( objDrawAction3DNN_obj_mtx );
        if ( pos != null && ( num & 8192U ) == 0U )
        {
            AppMain.VecFx32 value2 = pos.Value;
            if ( ( num & 2097152U ) == 0U )
            {
                value2.y = -value2.y;
            }
            if ( ( num & 524288U ) == 0U )
            {
                if ( AppMain._g_obj.glb_scale.x != 4096 )
                {
                    value2.x = AppMain.FX_Mul( value2.x, AppMain._g_obj.glb_scale.x );
                }
                if ( AppMain._g_obj.glb_scale.y != 4096 )
                {
                    value2.y = AppMain.FX_Mul( value2.y, AppMain._g_obj.glb_scale.y );
                }
                if ( AppMain._g_obj.glb_scale.z != 4096 )
                {
                    value2.z = AppMain.FX_Mul( value2.z, AppMain._g_obj.glb_scale.z );
                }
            }
            AppMain.nnTranslateMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, AppMain.FX_FX32_TO_F32( value2.x ), AppMain.FX_FX32_TO_F32( value2.y ), AppMain.FX_FX32_TO_F32( value2.z ) );
        }
        if ( dir != null && ( num & 256U ) == 0U )
        {
            if ( ( num & 2097152U ) == 0U )
            {
                AppMain.nnRotateXYZMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, ( int )( -( int )dir.Value.x ), ( int )dir.Value.y, ( int )( -( int )dir.Value.z ) );
            }
            else
            {
                AppMain.nnRotateXYZMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, ( int )dir.Value.x, ( int )dir.Value.y, ( int )dir.Value.z );
            }
        }
        if ( ( num & 4194304U ) == 0U )
        {
            if ( ( num & 67108864U ) == 0U )
            {
                if ( ( num & 1U ) != 0U )
                {
                    AppMain.nnRotateYMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, 49152 );
                }
                else
                {
                    AppMain.nnRotateYMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, 16384 );
                }
            }
            else
            {
                if ( ( num & 2U ) != 0U )
                {
                    AppMain.nnRotateXMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, 32768 );
                }
                if ( ( num & 1U ) != 0U )
                {
                    AppMain.nnRotateYMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, 32768 );
                }
            }
        }
        if ( scale != null && ( num & 65536U ) == 0U )
        {
            value = scale.Value;
        }
        if ( ( num & 1048576U ) == 0U )
        {
            value.x = AppMain.FX_Mul( value.x, AppMain._g_obj.draw_scale.x );
            value.y = AppMain.FX_Mul( value.y, AppMain._g_obj.draw_scale.y );
            value.z = AppMain.FX_Mul( value.z, AppMain._g_obj.draw_scale.z );
        }
        if ( ( num & 524288U ) == 0U )
        {
            value.x = AppMain.FX_Mul( value.x, AppMain._g_obj.glb_scale.x );
            value.y = AppMain.FX_Mul( value.y, AppMain._g_obj.glb_scale.y );
            value.z = AppMain.FX_Mul( value.z, AppMain._g_obj.glb_scale.z );
        }
        AppMain.nnScaleMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, AppMain.FX_FX32_TO_F32( value.x ), AppMain.FX_FX32_TO_F32( value.y ), AppMain.FX_FX32_TO_F32( value.z ) );
        if ( ( num & 8388608U ) != 0U )
        {
            AppMain.nnMultiplyMatrix( objDrawAction3DNN_obj_mtx, obj_3d.user_obj_mtx, objDrawAction3DNN_obj_mtx );
        }
        if ( ( num & 16777216U ) != 0U )
        {
            AppMain.nnMultiplyMatrix( objDrawAction3DNN_obj_mtx, objDrawAction3DNN_obj_mtx, obj_3d.user_obj_mtx_r );
        }
        AppMain.amMatrixPush( objDrawAction3DNN_obj_mtx );
        if ( obj_3d.motion != null && obj_3d.motion.mmobject != null )
        {
            AppMain.ObjDrawAction3DNNMaterialUpdate( obj_3d, ref num );
        }
        if ( obj_3d.motion != null && obj_3d.motion.mtnbuf[0] != null )
        {
            AppMain.ObjDrawAction3DNNMotionUpdate( obj_3d, ref num );
            if ( obj_3d.mtn_cb_func != null )
            {
                obj_3d.mtn_cb_func( obj_3d.motion, obj_3d._object, obj_3d.mtn_cb_param );
            }
            if ( ( num & 32U ) == 0U )
            {
                AppMain.AMS_DRAWSTATE draw_state = null;
                if ( ( num & 134217728U ) != 0U )
                {
                    draw_state = obj_3d.draw_state;
                }
                if ( obj_3d.marge == 0f || obj_3d.marge == 1f )
                {
                    int num13;
                    float num14;
                    if ( obj_3d.marge == 0f )
                    {
                        num13 = obj_3d.act_id[0];
                        num14 = obj_3d.frame[0];
                    }
                    else
                    {
                        num13 = obj_3d.act_id[1];
                        num14 = obj_3d.frame[1];
                    }
                    AppMain.NNS_MOTION motion = obj_3d.motion.mtnbuf[num13 & 65535];
                    num14 += AppMain.amMotionGetStartFrame( obj_3d.motion, num13 );
                    if ( obj_3d.motion != null && obj_3d.motion.mmobject != null )
                    {
                        AppMain.ObjDraw3DNNMotionMaterialMotion( obj_3d.motion, obj_3d.texlist, obj_3d.drawflag, obj_3d.sub_obj_type, obj_3d.user_func, obj_3d.user_param, obj_3d.command_state, obj_3d.mplt_cb_func, obj_3d.mplt_cb_param, obj_3d.material_cb_func, obj_3d.material_cb_param, draw_state, obj_3d.use_light_flag );
                    }
                    else
                    {
                        AppMain.ObjDraw3DNNDrawMotion( motion, num14, obj_3d._object, obj_3d.texlist, obj_3d.drawflag, obj_3d.sub_obj_type, obj_3d.user_func, obj_3d.user_param, obj_3d.command_state, obj_3d.mplt_cb_func, obj_3d.mplt_cb_param, obj_3d.material_cb_func, obj_3d.material_cb_param, draw_state, obj_3d.use_light_flag );
                    }
                }
                else if ( obj_3d.motion != null && obj_3d.motion.mmobject != null )
                {
                    AppMain.ObjDraw3DNNMotionMaterialMotion( obj_3d.motion, obj_3d.texlist, obj_3d.drawflag, obj_3d.sub_obj_type, obj_3d.user_func, obj_3d.user_param, obj_3d.command_state, obj_3d.mplt_cb_func, obj_3d.mplt_cb_param, obj_3d.material_cb_func, obj_3d.material_cb_param, draw_state, obj_3d.use_light_flag );
                }
                else
                {
                    AppMain.ObjDraw3DNNMotion( obj_3d.motion, obj_3d.motion._object, obj_3d.texlist, obj_3d.drawflag, obj_3d.sub_obj_type, obj_3d.user_func, obj_3d.user_param, obj_3d.command_state, obj_3d.mplt_cb_func, obj_3d.mplt_cb_param, obj_3d.material_cb_func, obj_3d.material_cb_param, draw_state, obj_3d.use_light_flag );
                }
            }
            obj_3d.user_param = null;
            obj_3d.mplt_cb_param = null;
            obj_3d.material_cb_param = null;
        }
        else
        {
            if ( ( num & 32U ) == 0U )
            {
                AppMain.AMS_DRAWSTATE draw_state2 = null;
                if ( ( num & 134217728U ) != 0U )
                {
                    draw_state2 = obj_3d.draw_state;
                }
                if ( obj_3d.motion != null && obj_3d.motion.mmobject != null )
                {
                    AppMain.ObjDraw3DNNMotionMaterialMotion( obj_3d.motion, obj_3d.texlist, obj_3d.drawflag, obj_3d.sub_obj_type, obj_3d.user_func, obj_3d.user_param, obj_3d.command_state, null, null, obj_3d.material_cb_func, obj_3d.material_cb_param, draw_state2, obj_3d.use_light_flag );
                }
                else
                {
                    AppMain.ObjDraw3DNNModel( obj_3d._object, obj_3d.texlist, obj_3d.drawflag, obj_3d.sub_obj_type, obj_3d.user_func, obj_3d.user_param, obj_3d.command_state, obj_3d.material_cb_func, obj_3d.material_cb_param, draw_state2, obj_3d.use_light_flag );
                }
            }
            obj_3d.user_param = null;
            obj_3d.mplt_cb_param = null;
            obj_3d.material_cb_param = null;
        }
        AppMain.amMatrixPop();
        if ( p_disp_flag != null )
        {
            p_disp_flag &= 3758096383U;
            p_disp_flag |= ( num & 570425352U );
        }
    }

    // Token: 0x06000480 RID: 1152 RVA: 0x00025BFC File Offset: 0x00023DFC
    public static void ObjDrawAction3DNNMotionUpdate( AppMain.OBS_ACTION3D_NN_WORK obj_3d, ref uint p_disp_flag )
    {
        uint? num = new uint?(p_disp_flag);
        AppMain.ObjDrawAction3DNNMotionUpdate( obj_3d, ref num );
        p_disp_flag = num.Value;
    }

    // Token: 0x06000481 RID: 1153 RVA: 0x00025C28 File Offset: 0x00023E28
    public static void ObjDrawAction3DNNMotionUpdate( AppMain.OBS_ACTION3D_NN_WORK obj_3d, ref uint? p_disp_flag )
    {
        uint num = 0U;
        float num2 = 0f;
        float num3 = 0f;
        if ( p_disp_flag != null )
        {
            num = p_disp_flag.Value;
        }
        if ( ( num & 4096U ) == 0U )
        {
            if ( ( num & 16U ) == 0U )
            {
                if ( ( obj_3d.flag & 1U ) != 0U )
                {
                    obj_3d.marge -= obj_3d.blend_spd;
                    if ( obj_3d.marge <= 0f )
                    {
                        obj_3d.marge = 0f;
                        obj_3d.flag &= 4294967294U;
                    }
                }
                if ( ( num & 4112U ) == 0U )
                {
                    num2 = obj_3d.speed[0] * AppMain.FX_FX32_TO_F32( AppMain.g_obj.speed );
                    num3 = obj_3d.speed[1] * AppMain.FX_FX32_TO_F32( AppMain.g_obj.speed );
                }
                if ( obj_3d.marge < 1f || ( obj_3d.flag & 3U ) != 0U )
                {
                    obj_3d.frame[0] += num2;
                }
                if ( ( obj_3d.flag & 1U ) == 0U && ( obj_3d.marge > 0f || ( obj_3d.flag & 3U ) != 0U ) )
                {
                    obj_3d.frame[1] += num3;
                }
                if ( ( num & 4U ) != 0U )
                {
                    for ( int i = 0; i < 2; i++ )
                    {
                        float num4 = AppMain.amMotionGetEndFrame(obj_3d.motion, obj_3d.act_id[i]) - AppMain.amMotionGetStartFrame(obj_3d.motion, obj_3d.act_id[i]);
                        while ( obj_3d.frame[i] >= num4 )
                        {
                            obj_3d.frame[i] = obj_3d.frame[i] - num4;
                            if ( i == 0 )
                            {
                                num |= 8U;
                            }
                        }
                    }
                }
                else
                {
                    for ( int i = 0; i < 2; i++ )
                    {
                        float num5 = AppMain.amMotionGetEndFrame(obj_3d.motion, obj_3d.act_id[i]) - AppMain.amMotionGetStartFrame(obj_3d.motion, obj_3d.act_id[i]);
                        if ( obj_3d.frame[i] >= num5 - 1f )
                        {
                            obj_3d.frame[i] = num5 - 1f;
                            if ( i == 0 )
                            {
                                num |= 8U;
                            }
                        }
                    }
                }
            }
            if ( obj_3d.marge < 1f || ( obj_3d.flag & 3U ) != 0U )
            {
                AppMain.amMotionSetFrame( obj_3d.motion, 0, obj_3d.frame[0] + AppMain.amMotionGetStartFrame( obj_3d.motion, obj_3d.act_id[0] ) );
            }
            if ( obj_3d.marge > 0f || ( obj_3d.flag & 3U ) != 0U )
            {
                AppMain.amMotionSetFrame( obj_3d.motion, 1, obj_3d.frame[1] + AppMain.amMotionGetStartFrame( obj_3d.motion, obj_3d.act_id[1] ) );
            }
            AppMain.amMotionGet( obj_3d.motion, obj_3d.marge, obj_3d.per );
        }
        if ( p_disp_flag != null )
        {
            p_disp_flag |= ( num & 8U );
        }
    }

    // Token: 0x06000482 RID: 1154 RVA: 0x00025EE8 File Offset: 0x000240E8
    public static void ObjDrawAction3DNNMaterialUpdate( AppMain.OBS_ACTION3D_NN_WORK obj_3d, ref uint p_disp_flag )
    {
        uint? num = new uint?(p_disp_flag);
        AppMain.ObjDrawAction3DNNMaterialUpdate( obj_3d, ref num );
        p_disp_flag = num.Value;
    }

    // Token: 0x06000483 RID: 1155 RVA: 0x00025F14 File Offset: 0x00024114
    public static void ObjDrawAction3DNNMaterialUpdate( AppMain.OBS_ACTION3D_NN_WORK obj_3d, ref uint? p_disp_flag )
    {
        uint num = 0U;
        float num2 = 0f;
        if ( p_disp_flag != null )
        {
            num = p_disp_flag.Value;
        }
        if ( ( num & 4096U ) == 0U )
        {
            if ( ( num & 16U ) == 0U )
            {
                if ( ( num & 4112U ) == 0U )
                {
                    num2 = obj_3d.mat_speed * AppMain.FX_FX32_TO_F32( AppMain.g_obj.speed );
                }
                obj_3d.mat_frame += num2;
                if ( ( num & 4U ) != 0U )
                {
                    float num3 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id) - AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
                    while ( obj_3d.mat_frame >= num3 )
                    {
                        obj_3d.mat_frame -= num3;
                        num |= 33554432U;
                    }
                }
                else
                {
                    float num4 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id) - AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
                    if ( obj_3d.mat_frame >= num4 - 1f )
                    {
                        obj_3d.mat_frame = num4 - 1f;
                        num |= 33554432U;
                    }
                }
            }
            AppMain.amMotionMaterialSetFrame( obj_3d.motion, obj_3d.mat_frame + AppMain.amMotionMaterialGetStartFrame( obj_3d.motion, obj_3d.mat_act_id ) );
            AppMain.amMotionMaterialCalc( obj_3d.motion );
        }
        if ( p_disp_flag != null )
        {
            p_disp_flag |= ( num & 33554432U );
        }
    }

    // Token: 0x06000484 RID: 1156 RVA: 0x00026080 File Offset: 0x00024280
    public static void ObjDraw3DNNModel( AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, uint sub_obj_type, AppMain.MPP_VOID_OBJECT_DELEGATE user_func, object user_param, uint command_state, AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func, object material_cb_param, AppMain.AMS_DRAWSTATE draw_state, uint use_light_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_MODEL obs_DRAW_PARAM_3DNN_MODEL = AppMain._ObjDraw3DNNModel_Pool.Alloc();
        AppMain.NNS_MATRIX mtx = obs_DRAW_PARAM_3DNN_MODEL.mtx;
        AppMain.nnCopyMatrix( mtx, AppMain.amMatrixGetCurrent() );
        AppMain.AMS_PARAM_DRAW_OBJECT param = obs_DRAW_PARAM_3DNN_MODEL.param;
        param._object = _object;
        if ( AppMain.gmMapTransX != 0f )
        {
            AppMain.nnScaleMatrix( mtx, mtx, 1.005f, 1.005f, 1f );
        }
        param.mtx = mtx;
        param.sub_obj_type = sub_obj_type;
        param.flag = drawflag;
        param.texlist = texlist;
        param.material_func = null;
        param.scaleZ = 1f;
        obs_DRAW_PARAM_3DNN_MODEL.state = null;
        if ( draw_state != null )
        {
            obs_DRAW_PARAM_3DNN_MODEL.state = obs_DRAW_PARAM_3DNN_MODEL.draw_state;
            obs_DRAW_PARAM_3DNN_MODEL.draw_state.Assign( draw_state );
        }
        obs_DRAW_PARAM_3DNN_MODEL.use_light_flag = use_light_flag;
        obs_DRAW_PARAM_3DNN_MODEL.user_func = user_func;
        obs_DRAW_PARAM_3DNN_MODEL.user_param = user_param;
        obs_DRAW_PARAM_3DNN_MODEL.material_cb_func = material_cb_func;
        obs_DRAW_PARAM_3DNN_MODEL.material_cb_param = material_cb_param;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_MODEL, param );
    }

    // Token: 0x06000485 RID: 1157 RVA: 0x0002616C File Offset: 0x0002436C
    public static void ObjDraw3DNNModelMaterialMotion( AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, uint sub_obj_type, AppMain.MPP_VOID_OBJECT_DELEGATE user_func, object user_param, uint command_state, AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func, object material_cb_param, AppMain.AMS_DRAWSTATE draw_state, uint use_light_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_MODEL obs_DRAW_PARAM_3DNN_MODEL = new AppMain.OBS_DRAW_PARAM_3DNN_MODEL();
        AppMain.NNS_MATRIX mtx = obs_DRAW_PARAM_3DNN_MODEL.mtx;
        AppMain.nnCopyMatrix( mtx, AppMain.amMatrixGetCurrent() );
        AppMain.AMS_PARAM_DRAW_OBJECT param = obs_DRAW_PARAM_3DNN_MODEL.param;
        param._object = _object;
        param.mtx = mtx;
        param.sub_obj_type = sub_obj_type;
        param.flag = drawflag;
        param.texlist = texlist;
        param.material_func = null;
        param.scaleZ = 1f;
        obs_DRAW_PARAM_3DNN_MODEL.state = null;
        if ( draw_state != null )
        {
            obs_DRAW_PARAM_3DNN_MODEL.state = obs_DRAW_PARAM_3DNN_MODEL.draw_state;
            obs_DRAW_PARAM_3DNN_MODEL.draw_state.Assign( draw_state );
        }
        obs_DRAW_PARAM_3DNN_MODEL.use_light_flag = use_light_flag;
        obs_DRAW_PARAM_3DNN_MODEL.user_func = user_func;
        obs_DRAW_PARAM_3DNN_MODEL.user_param = user_param;
        obs_DRAW_PARAM_3DNN_MODEL.material_cb_func = material_cb_func;
        obs_DRAW_PARAM_3DNN_MODEL.material_cb_param = material_cb_param;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_MODEL_MATMTN, param );
    }

    // Token: 0x06000486 RID: 1158 RVA: 0x00026230 File Offset: 0x00024430
    public static void ObjDraw3DNNMotion( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, uint sub_obj_type, AppMain.MPP_VOID_OBJECT_DELEGATE user_func, object user_param, uint command_state, AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func, object mplt_cb_param, AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func, object material_cb_param, AppMain.AMS_DRAWSTATE draw_state, uint use_light_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        int node_num = motion.node_num;
        AppMain.OBS_DRAW_PARAM_3DNN_MOTION obs_DRAW_PARAM_3DNN_MOTION = AppMain.amDrawAlloc_OBS_DRAW_PARAM_3DNN_MOTION();
        AppMain.NNS_MATRIX mtx = obs_DRAW_PARAM_3DNN_MOTION.mtx;
        AppMain.nnCopyMatrix( mtx, AppMain.amMatrixGetCurrent() );
        AppMain.AMS_PARAM_DRAW_MOTION_TRS param = obs_DRAW_PARAM_3DNN_MOTION.param;
        param._object = _object;
        param.mtx = mtx;
        param.sub_obj_type = sub_obj_type;
        param.flag = drawflag;
        param.texlist = texlist;
        param.trslist = AppMain.amDrawAlloc_NNS_TRS( node_num );
        param.material_func = null;
        for ( int i = 0; i < node_num; i++ )
        {
            param.trslist[i] = motion.data[i];
        }
        int motion_id = motion.mbuf[0].motion_id;
        param.motion = motion.mtnfile[motion_id >> 16].motion[motion_id & 65535];
        param.frame = motion.mbuf[0].frame;
        obs_DRAW_PARAM_3DNN_MOTION.state = null;
        if ( draw_state != null )
        {
            obs_DRAW_PARAM_3DNN_MOTION.state = obs_DRAW_PARAM_3DNN_MOTION.draw_state;
            obs_DRAW_PARAM_3DNN_MOTION.draw_state.Assign( draw_state );
        }
        obs_DRAW_PARAM_3DNN_MOTION.use_light_flag = use_light_flag;
        obs_DRAW_PARAM_3DNN_MOTION.user_func = user_func;
        obs_DRAW_PARAM_3DNN_MOTION.user_param = user_param;
        obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_func = mplt_cb_func;
        obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_param = mplt_cb_param;
        obs_DRAW_PARAM_3DNN_MOTION.material_cb_func = material_cb_func;
        obs_DRAW_PARAM_3DNN_MOTION.material_cb_param = material_cb_param;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_MOTION, param );
    }

    // Token: 0x06000487 RID: 1159 RVA: 0x00026374 File Offset: 0x00024574
    public static void ObjDraw3DNNMotionMaterialMotion( AppMain.AMS_MOTION motion, AppMain.NNS_TEXLIST texlist, uint drawflag, uint sub_obj_type, AppMain.MPP_VOID_OBJECT_DELEGATE user_func, object user_param, uint command_state, AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func, object mplt_cb_param, AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func, object material_cb_param, AppMain.AMS_DRAWSTATE draw_state, uint use_light_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( motion.mmobject == null )
        {
            AppMain.ObjDraw3DNNMotion( motion, motion._object, texlist, drawflag, sub_obj_type, user_func, user_param, command_state, mplt_cb_func, mplt_cb_param, material_cb_func, material_cb_param, draw_state, use_light_flag );
            return;
        }
        int node_num = motion.node_num;
        AppMain.OBS_DRAW_PARAM_3DNN_MOTION obs_DRAW_PARAM_3DNN_MOTION = AppMain.amDrawAlloc_OBS_DRAW_PARAM_3DNN_MOTION();
        AppMain.NNS_MATRIX mtx = obs_DRAW_PARAM_3DNN_MOTION.mtx;
        mtx.Assign( AppMain.amMatrixGetCurrent() );
        AppMain.AMS_PARAM_DRAW_MOTION_TRS param = obs_DRAW_PARAM_3DNN_MOTION.param;
        param.mtx = mtx;
        param.sub_obj_type = sub_obj_type;
        param.flag = drawflag;
        param.texlist = texlist;
        param.trslist = AppMain.amDrawAlloc_NNS_TRS( node_num );
        param.material_func = null;
        for ( int i = 0; i < node_num; i++ )
        {
            param.trslist[i] = AppMain.amDraw_NNS_TRS_Pool.Alloc();
            param.trslist[i].Assign( motion.data[i] );
        }
        param._object = motion._object;
        param.mmotion = motion.mmtn[motion.mmotion_id];
        param.mframe = motion.mmotion_frame;
        int motion_id = motion.mbuf[0].motion_id;
        if ( motion.mtnfile[motion_id >> 16].file != null )
        {
            param.motion = motion.mtnfile[motion_id >> 16].motion[motion_id & 65535];
            param.frame = motion.mbuf[0].frame;
        }
        else
        {
            param.motion = null;
            param.frame = 0f;
        }
        obs_DRAW_PARAM_3DNN_MOTION.state = null;
        if ( draw_state != null )
        {
            obs_DRAW_PARAM_3DNN_MOTION.state = obs_DRAW_PARAM_3DNN_MOTION.draw_state;
            obs_DRAW_PARAM_3DNN_MOTION.draw_state.Assign( draw_state );
        }
        obs_DRAW_PARAM_3DNN_MOTION.use_light_flag = use_light_flag;
        obs_DRAW_PARAM_3DNN_MOTION.user_func = user_func;
        obs_DRAW_PARAM_3DNN_MOTION.user_param = user_param;
        obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_func = mplt_cb_func;
        obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_param = mplt_cb_param;
        obs_DRAW_PARAM_3DNN_MOTION.material_cb_func = material_cb_func;
        obs_DRAW_PARAM_3DNN_MOTION.material_cb_param = material_cb_param;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_MOTION_MATMTN, param );
    }

    // Token: 0x06000488 RID: 1160 RVA: 0x00026548 File Offset: 0x00024748
    public static void ObjDraw3DNNDrawMotion( AppMain.NNS_MOTION motion, float frame, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, uint sub_obj_type, AppMain.MPP_VOID_OBJECT_DELEGATE user_func, object user_param, uint command_state, AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func, object mplt_cb_param, AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func, object material_cb_param, AppMain.AMS_DRAWSTATE draw_state, uint use_light_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION obs_DRAW_PARAM_3DNN_DRAW_MOTION = AppMain.amDrawAlloc_OBS_DRAW_PARAM_3DNN_DRAW_MOTION();
        AppMain.NNS_MATRIX mtx = obs_DRAW_PARAM_3DNN_DRAW_MOTION.mtx;
        AppMain.nnCopyMatrix( mtx, AppMain.amMatrixGetCurrent() );
        AppMain.AMS_PARAM_DRAW_MOTION param = obs_DRAW_PARAM_3DNN_DRAW_MOTION.param;
        param._object = _object;
        param.mtx = mtx;
        param.sub_obj_type = sub_obj_type;
        param.flag = drawflag;
        param.texlist = texlist;
        param.motion = motion;
        param.frame = frame;
        param.material_func = null;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.state = null;
        if ( draw_state != null && draw_state != null )
        {
            obs_DRAW_PARAM_3DNN_DRAW_MOTION.state = obs_DRAW_PARAM_3DNN_DRAW_MOTION.draw_state;
            obs_DRAW_PARAM_3DNN_DRAW_MOTION.draw_state.Assign( draw_state );
        }
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.use_light_flag = use_light_flag;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_func = user_func;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_param = user_param;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_func = mplt_cb_func;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_param = mplt_cb_param;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_func = material_cb_func;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_param = material_cb_param;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_DRAW_MOTION, param );
    }

    // Token: 0x06000489 RID: 1161 RVA: 0x00026624 File Offset: 0x00024824
    public static void ObjDraw3DNNDrawMotionMaterialMotion( AppMain.NNS_MOTION motion, float frame, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, uint sub_obj_type, AppMain.MPP_VOID_OBJECT_DELEGATE user_func, object user_param, uint command_state, AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func, object mplt_cb_param, AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func, object material_cb_param, AppMain.AMS_DRAWSTATE draw_state, uint use_light_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION obs_DRAW_PARAM_3DNN_DRAW_MOTION = new AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION();
        AppMain.NNS_MATRIX mtx = obs_DRAW_PARAM_3DNN_DRAW_MOTION.mtx;
        AppMain.nnCopyMatrix( mtx, AppMain.amMatrixGetCurrent() );
        AppMain.AMS_PARAM_DRAW_MOTION param = obs_DRAW_PARAM_3DNN_DRAW_MOTION.param;
        param._object = _object;
        param.mtx = mtx;
        param.sub_obj_type = sub_obj_type;
        param.flag = drawflag;
        param.texlist = texlist;
        param.motion = motion;
        param.frame = frame;
        param.material_func = null;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.state = null;
        if ( draw_state != null )
        {
            obs_DRAW_PARAM_3DNN_DRAW_MOTION.state = obs_DRAW_PARAM_3DNN_DRAW_MOTION.draw_state;
            obs_DRAW_PARAM_3DNN_DRAW_MOTION.draw_state.Assign( draw_state );
        }
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.use_light_flag = use_light_flag;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_func = user_func;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_param = user_param;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_func = mplt_cb_func;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_param = mplt_cb_param;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_func = material_cb_func;
        obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_param = material_cb_param;
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_DRAW_MOTION_MATMTN, param );
    }

    // Token: 0x0600048A RID: 1162 RVA: 0x000266FC File Offset: 0x000248FC
    public static void ObjDraw3DNNDrawPrimitive( AppMain.AMS_PARAM_DRAW_PRIMITIVE prim )
    {
        AppMain.ObjDraw3DNNDrawPrimitive( prim, 0U, 0, 0 );
    }

    // Token: 0x0600048B RID: 1163 RVA: 0x00026707 File Offset: 0x00024907
    public static void ObjDraw3DNNDrawPrimitive( AppMain.AMS_PARAM_DRAW_PRIMITIVE prim, uint command )
    {
        AppMain.ObjDraw3DNNDrawPrimitive( prim, command, 0, 0 );
    }

    // Token: 0x0600048C RID: 1164 RVA: 0x00026714 File Offset: 0x00024914
    public static void ObjDraw3DNNDrawPrimitive( AppMain.AMS_PARAM_DRAW_PRIMITIVE prim, uint command, int light, int cull )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE = AppMain.OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE_Pool.Alloc();
        obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.dat.Assign( prim );
        AppMain.nnCopyMatrix( obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.mtx, AppMain.amMatrixGetCurrent() );
        obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.light = light;
        obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.cull = cull;
        AppMain._ObjDraw3DNNUserFunc( AppMain._objDraw3DNNDrawPrimitive_DT, obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE, command );
    }

    // Token: 0x0600048D RID: 1165 RVA: 0x0002676C File Offset: 0x0002496C
    public static uint ObjDraw3DNNGetMaterialUserData( AppMain.NNS_DRAWCALLBACK_VAL val )
    {
        uint result = 0U;
        uint fType = val.pMaterial.fType;
        switch ( fType )
        {
            case 1U:
                AppMain.mppAssertNotImpl();
                return result;
            case 2U:
                AppMain.mppAssertNotImpl();
                return result;
            case 3U:
                break;
            case 4U:
                AppMain.mppAssertNotImpl();
                return result;
            default:
                if ( fType == 8U )
                {
                    return ( ( AppMain.NNS_MATERIAL_GLES11_DESC )val.pMaterial.pMaterial ).User;
                }
                break;
        }
        result = 0U;
        return result;
    }

    // Token: 0x0600048E RID: 1166 RVA: 0x000267D3 File Offset: 0x000249D3
    public static void ObjDrawSetToon( AppMain.OBS_ACTION3D_NN_WORK obj_3d )
    {
    }

    // Token: 0x0600048F RID: 1167 RVA: 0x000267D5 File Offset: 0x000249D5
    public static int ObjDrawToonMaterialCallback( AppMain.NNS_DRAWCALLBACK_VAL val, object param )
    {
        return AppMain.nnPutMaterialCore( val );
    }

    // Token: 0x06000490 RID: 1168 RVA: 0x000267E0 File Offset: 0x000249E0
    public static void ObjDrawObjectAction3DES( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        AppMain.VecU16 vecU = default(AppMain.VecU16);
        vecFx.Assign( obj_work.pos );
        vecU.Assign( obj_work.dir );
        vecFx.x += obj_work.ofst.x;
        vecFx.y += obj_work.ofst.y;
        vecFx.z += obj_work.ofst.z;
        if ( obj_work.dir_fall != 0 )
        {
            vecU.z += obj_work.dir_fall;
        }
        AppMain.ObjDrawAction3DES( obj_3des, new AppMain.VecFx32?( vecFx ), ref vecU, new AppMain.VecFx32?( obj_work.scale ), ref obj_work.disp_flag );
    }

    // Token: 0x06000491 RID: 1169 RVA: 0x000268A0 File Offset: 0x00024AA0
    public static void ObjDrawAction3DES( AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.VecFx32? pos, ref AppMain.VecU16 dir, AppMain.VecFx32? scale, ref uint p_disp_flag )
    {
        uint? num = new uint?(p_disp_flag);
        AppMain.ObjDrawAction3DES( obj_3des, pos, new AppMain.VecU16?( dir ), scale, ref num );
        p_disp_flag = num.Value;
    }

    // Token: 0x06000492 RID: 1170 RVA: 0x000268DC File Offset: 0x00024ADC
    public static void ObjDrawAction3DES( AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.VecFx32? pos, AppMain.VecU16? dir, AppMain.VecFx32? scale, ref uint? p_disp_flag )
    {
        if ( obj_3des.ecb == null )
        {
            return;
        }
        uint num = 0U;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amDrawAlloc_NNS_MATRIX();
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.vec_posObjDrawAction3DES.w = 0f;
        AppMain.amQuatInit( ref nns_QUATERNION );
        AppMain.amVectorInit( ref AppMain.vecObjDrawAction3DES );
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        if ( p_disp_flag != null )
        {
            num = p_disp_flag.Value;
            if ( ( p_disp_flag.Value & 16U ) == 0U )
            {
                p_disp_flag &= 4294967287U;
            }
        }
        AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION2, ( int )obj_3des.disp_rot.x, ( int )obj_3des.disp_rot.y, ( int )obj_3des.disp_rot.z );
        if ( ( num & 4194304U ) == 0U )
        {
            if ( ( num & 1U ) != 0U )
            {
                if ( ( obj_3des.flag & 4U ) != 0U )
                {
                    AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION3, AppMain.NNM_DEGtoA32( 0f ), AppMain.NNM_DEGtoA32( 0f ), AppMain.NNM_DEGtoA32( 270f ) );
                }
                else
                {
                    AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION3, AppMain.NNM_DEGtoA32( 0f ), AppMain.NNM_DEGtoA32( 270f ), AppMain.NNM_DEGtoA32( 0f ) );
                }
            }
            else if ( ( obj_3des.flag & 4U ) != 0U )
            {
                AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION3, AppMain.NNM_DEGtoA32( 0f ), AppMain.NNM_DEGtoA32( 0f ), AppMain.NNM_DEGtoA32( 90f ) );
            }
            else
            {
                AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION3, AppMain.NNM_DEGtoA32( 0f ), AppMain.NNM_DEGtoA32( 90f ), AppMain.NNM_DEGtoA32( 0f ) );
            }
        }
        else
        {
            AppMain.amQuatInit( ref nns_QUATERNION3 );
        }
        if ( dir != null && ( num & 256U ) == 0U )
        {
            if ( ( num & 2097152U ) == 0U )
            {
                AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION4, ( int )( -( int )dir.Value.x ), ( int )dir.Value.y, ( int )( -( int )dir.Value.z ) );
            }
            else
            {
                AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION4, ( int )dir.Value.x, ( int )dir.Value.y, ( int )dir.Value.z );
            }
            if ( ( obj_3des.flag & 32U ) != 0U )
            {
                AppMain.nnMultiplyQuaternion( ref nns_QUATERNION4, ref nns_QUATERNION4, ref obj_3des.user_dir_quat );
            }
        }
        else
        {
            AppMain.amQuatInit( ref nns_QUATERNION4 );
        }
        AppMain.vec_dispObjDrawAction3DES.w = 0f;
        AppMain.amVectorSet( out AppMain.vec_dispObjDrawAction3DES, obj_3des.disp_ofst.x, obj_3des.disp_ofst.y, obj_3des.disp_ofst.z );
        if ( pos != null )
        {
            AppMain.VecFx32 value = pos.Value;
            if ( ( num & 2097152U ) == 0U )
            {
                value.y = -value.y;
            }
            AppMain.amVectorSet( out AppMain.vec_posObjDrawAction3DES, AppMain.FX_FX32_TO_F32( value.x ), AppMain.FX_FX32_TO_F32( value.y ), AppMain.FX_FX32_TO_F32( value.z ) );
        }
        else
        {
            AppMain.amVectorInit( ref AppMain.vec_posObjDrawAction3DES );
        }
        AppMain.amVectorOne( ref AppMain.vec_scaleObjDrawAction3DES );
        if ( scale != null && ( num & 65536U ) == 0U )
        {
            if ( ( obj_3des.flag & 8U ) != 0U )
            {
                AppMain.amVectorSet( out AppMain.vec_scaleObjDrawAction3DES, AppMain.FX_FX32_TO_F32( scale.Value.x ), AppMain.FX_FX32_TO_F32( scale.Value.y ), AppMain.FX_FX32_TO_F32( scale.Value.z ) );
                AppMain.amEffectSetSizeRate( obj_3des.ecb, 1f );
            }
            else
            {
                AppMain.amEffectSetSizeRate( obj_3des.ecb, AppMain.FX_FX32_TO_F32( scale.Value.x ) );
            }
        }
        if ( ( obj_3des.flag & 1U ) != 0U )
        {
            AppMain.amVectorAdd( ref AppMain.vecObjDrawAction3DES, ref AppMain.vec_dispObjDrawAction3DES, ref AppMain.vecObjDrawAction3DES );
            AppMain.amQuatMulti( ref nns_QUATERNION, ref nns_QUATERNION3, ref nns_QUATERNION );
            AppMain.amQuatMulti( ref nns_QUATERNION, ref nns_QUATERNION4, ref nns_QUATERNION );
            AppMain.SNNS_MATRIX snns_MATRIX;
            AppMain.nnMakeQuaternionMatrix( out snns_MATRIX, ref nns_QUATERNION );
            AppMain.SNNS_VECTOR snns_VECTOR;
            snns_VECTOR.x = AppMain.vecObjDrawAction3DES.x;
            snns_VECTOR.y = AppMain.vecObjDrawAction3DES.y;
            snns_VECTOR.z = AppMain.vecObjDrawAction3DES.z;
            AppMain.nnTransformVector( ref snns_VECTOR, ref snns_MATRIX, ref snns_VECTOR );
            AppMain.vecObjDrawAction3DES.x = snns_VECTOR.x;
            AppMain.vecObjDrawAction3DES.y = snns_VECTOR.y;
            AppMain.vecObjDrawAction3DES.z = snns_VECTOR.z;
            AppMain.amQuatMulti( ref nns_QUATERNION, ref nns_QUATERNION, ref nns_QUATERNION2 );
            if ( ( obj_3des.flag & 16U ) != 0U )
            {
                AppMain.amEffectSetRotate( obj_3des.ecb, ref nns_QUATERNION, 1 );
            }
            else
            {
                AppMain.amEffectSetRotate( obj_3des.ecb, ref nns_QUATERNION );
            }
            AppMain.SNNS_MATRIX snns_MATRIX2;
            AppMain.nnMakeScaleMatrix( out snns_MATRIX2, AppMain.vec_scaleObjDrawAction3DES.x, AppMain.vec_scaleObjDrawAction3DES.y, AppMain.vec_scaleObjDrawAction3DES.z );
            AppMain.nnMultiplyMatrix( nns_MATRIX, ref snns_MATRIX2, nns_MATRIX );
            if ( ( obj_3des.flag & 2U ) != 0U )
            {
                AppMain.SNNS_MATRIX snns_MATRIX3;
                AppMain.nnMakeTranslateMatrix( out snns_MATRIX3, AppMain.vec_posObjDrawAction3DES.x, AppMain.vec_posObjDrawAction3DES.y, AppMain.vec_posObjDrawAction3DES.z );
                AppMain.nnMultiplyMatrix( nns_MATRIX, ref snns_MATRIX3, nns_MATRIX );
            }
            else
            {
                AppMain.amVectorAdd( ref AppMain.vecObjDrawAction3DES, ref AppMain.vec_posObjDrawAction3DES, ref AppMain.vecObjDrawAction3DES );
            }
            AppMain.amEffectSetTranslate( obj_3des.ecb, ref AppMain.vecObjDrawAction3DES );
        }
        else
        {
            AppMain.amQuatMulti( ref nns_QUATERNION, ref nns_QUATERNION3, ref nns_QUATERNION );
            AppMain.amQuatMulti( ref nns_QUATERNION, ref nns_QUATERNION4, ref nns_QUATERNION );
            AppMain.nnMakeQuaternionMatrix( nns_MATRIX, ref nns_QUATERNION );
            AppMain.SNNS_VECTOR snns_VECTOR2;
            snns_VECTOR2.x = AppMain.vec_posObjDrawAction3DES.x;
            snns_VECTOR2.y = AppMain.vec_posObjDrawAction3DES.y;
            snns_VECTOR2.z = AppMain.vec_posObjDrawAction3DES.z;
            AppMain.nnCopyVectorMatrixTranslation( nns_MATRIX, ref snns_VECTOR2 );
            AppMain.SNNS_MATRIX snns_MATRIX4;
            AppMain.nnMakeScaleMatrix( out snns_MATRIX4, AppMain.vec_scaleObjDrawAction3DES.x, AppMain.vec_scaleObjDrawAction3DES.y, AppMain.vec_scaleObjDrawAction3DES.z );
            AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref snns_MATRIX4 );
            AppMain.SNNS_MATRIX snns_MATRIX5;
            AppMain.nnMakeTranslateMatrix( out snns_MATRIX5, AppMain.vec_dispObjDrawAction3DES.x, AppMain.vec_dispObjDrawAction3DES.y, AppMain.vec_dispObjDrawAction3DES.z );
            AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref snns_MATRIX5 );
            AppMain.SNNS_MATRIX snns_MATRIX6;
            AppMain.nnMakeQuaternionMatrix( out snns_MATRIX6, ref nns_QUATERNION2 );
            AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ref snns_MATRIX6 );
        }
        AppMain.ObjDraw3DESSetCamera( obj_3des, nns_MATRIX );
        AppMain.ObjDraw3DESMatrixPush( nns_MATRIX, obj_3des.command_state );
        float speed = AppMain.amEffectGetUnitFrame();
        if ( ( num & 4096U ) == 0U )
        {
            if ( ( num & 16U ) != 0U )
            {
                AppMain.amEffectSetUnitTime( 0f, 60 );
            }
            else
            {
                AppMain.amEffectSetUnitTime( obj_3des.speed * AppMain.FX_FX32_TO_F32( AppMain._g_obj.speed ), 60 );
            }
            AppMain.amEffectUpdate( obj_3des.ecb );
            if ( AppMain.amEffectIsDelete( obj_3des.ecb ) != 0 )
            {
                obj_3des.ecb = null;
                if ( p_disp_flag != null )
                {
                    p_disp_flag |= 8U;
                }
            }
        }
        AppMain.amEffectSetUnitTime( speed, 60 );
        if ( ( num & 32U ) == 0U && obj_3des.ecb != null )
        {
            AppMain.ObjDraw3DESEffect( obj_3des.ecb, obj_3des.texlist, obj_3des.command_state );
            if ( ( obj_3des.flag & 64U ) != 0U )
            {
                AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.amDrawAlloc_NNS_MATRIX();
                AppMain.nnMakeTranslateMatrix( nns_MATRIX2, obj_3des.dup_draw_ofst.x, obj_3des.dup_draw_ofst.y, obj_3des.dup_draw_ofst.z );
                AppMain.nnMultiplyMatrix( nns_MATRIX2, nns_MATRIX2, nns_MATRIX );
                AppMain.ObjDraw3DESMatrixPop( obj_3des.command_state );
                AppMain.ObjDraw3DESSetCamera( obj_3des, nns_MATRIX2 );
                AppMain.ObjDraw3DESMatrixPush( nns_MATRIX2, obj_3des.command_state );
                AppMain.ObjDraw3DESEffect( obj_3des.ecb, obj_3des.texlist, obj_3des.command_state );
            }
        }
        AppMain.ObjDraw3DESMatrixPop( obj_3des.command_state );
    }

    // Token: 0x06000493 RID: 1171 RVA: 0x00026FF2 File Offset: 0x000251F2
    public static void ObjDraw3DESEffect( AppMain.AMS_AME_ECB ecb, AppMain.NNS_TEXLIST texlist, uint command_state )
    {
        AppMain.amEffectDraw( ecb, texlist, command_state );
    }

    // Token: 0x06000494 RID: 1172 RVA: 0x00026FFC File Offset: 0x000251FC
    public static void ObjDraw3DESMatrixPush( AppMain.NNS_MATRIX mtx, uint command_state )
    {
        AppMain._ObjDraw3DNNUserFunc( AppMain._objDraw3DESMatrixPush_UserFunc, mtx, command_state );
    }

    // Token: 0x06000495 RID: 1173 RVA: 0x0002700A File Offset: 0x0002520A
    public static void ObjDraw3DESMatrixPop( uint command_state )
    {
        AppMain.ObjDraw3DNNUserFunc( AppMain._objDraw3DESMatrixPop_UserFunc, null, 0, command_state );
    }

    // Token: 0x06000496 RID: 1174 RVA: 0x00027019 File Offset: 0x00025219
    public static void ObjDrawKillAction3DES( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3des.ecb != null )
        {
            AppMain.amEffectKill( obj_work.obj_3des.ecb );
        }
    }

    // Token: 0x06000497 RID: 1175 RVA: 0x00027038 File Offset: 0x00025238
    public static void ObjDraw3DESSetCamera( AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.NNS_MATRIX obj_mtx )
    {
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR2 = default(AppMain.SNNS_VECTOR);
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type, obj_3des.command_state );
        AppMain.ObjCameraDispPosGet( AppMain.g_obj.glb_camera_id, out snns_VECTOR );
        AppMain.amVectorSet( ref snns_VECTOR2, -obj_mtx.M03, -obj_mtx.M13, -obj_mtx.M23 );
        AppMain.nnAddVector( ref snns_VECTOR, ref snns_VECTOR2, ref snns_VECTOR );
        AppMain.amEffectSetCameraPos( ref snns_VECTOR );
    }

    // Token: 0x06000498 RID: 1176 RVA: 0x000270B4 File Offset: 0x000252B4
    public static void ObjDrawObjectAction2DAMA( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION2D_AMA_WORK obj_2d )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(obj_work.pos);
        new AppMain.VecU16( obj_work.dir );
        vecFx.x += obj_work.ofst.x;
        vecFx.y += obj_work.ofst.y;
        vecFx.z += obj_work.ofst.z;
        AppMain.ObjDrawAction2DAMA( obj_2d, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), new AppMain.VecFx32?( obj_work.scale ), ref obj_work.disp_flag );
    }

    // Token: 0x06000499 RID: 1177 RVA: 0x00027158 File Offset: 0x00025358
    public static void ObjDrawAction2DAMA( AppMain.OBS_ACTION2D_AMA_WORK obj_2d, AppMain.VecFx32? pos, AppMain.VecU16? dir, AppMain.VecFx32? scale, ref uint p_disp_flag )
    {
        uint num = 0U;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( p_disp_flag != 0U )
        {
            if ( ( p_disp_flag & 16U ) == 0U )
            {
                p_disp_flag &= 4294967287U;
            }
            num = p_disp_flag;
        }
        AppMain.AoActSetTexture( obj_2d.texlist );
        AppMain.AOS_ACT_ACM objDrawAction2DAMA_acm = AppMain.ObjDrawAction2DAMA_acm;
        AppMain.AoActAcmInit( objDrawAction2DAMA_acm );
        if ( pos != null && ( num & 8192U ) == 0U )
        {
            objDrawAction2DAMA_acm.trans_x = AppMain.FXM_FX32_TO_FLOAT( pos.Value.x );
            objDrawAction2DAMA_acm.trans_y = AppMain.FXM_FX32_TO_FLOAT( pos.Value.y );
            objDrawAction2DAMA_acm.trans_z = AppMain.FXM_FX32_TO_FLOAT( pos.Value.z );
        }
        if ( dir != null && ( num & 256U ) == 0U )
        {
            objDrawAction2DAMA_acm.rotate = AppMain.NNM_A32toDEG( ( int )dir.Value.z );
        }
        if ( scale != null && ( num & 65536U ) == 0U )
        {
            objDrawAction2DAMA_acm.scale_x = AppMain.FXM_FX32_TO_FLOAT( scale.Value.x );
            objDrawAction2DAMA_acm.scale_y = AppMain.FXM_FX32_TO_FLOAT( scale.Value.y );
        }
        objDrawAction2DAMA_acm.color = obj_2d.color;
        objDrawAction2DAMA_acm.fade = obj_2d.fade;
        AppMain.AoActAcmPush( objDrawAction2DAMA_acm );
        if ( ( num & 4096U ) == 0U )
        {
            float frame = obj_2d.speed * AppMain.FX_FX32_TO_F32(AppMain.g_obj.speed) * AppMain.GmMainGetDrawMotionSpeed();
            if ( obj_2d.act.frame == obj_2d.frame )
            {
                AppMain.AoActUpdate( obj_2d.act, frame );
                obj_2d.frame = obj_2d.act.frame;
            }
            else
            {
                AppMain.AoActSetFrame( obj_2d.act, obj_2d.frame );
                AppMain.AoActUpdate( obj_2d.act, 0f );
            }
            if ( ( num & 4U ) != 0U )
            {
                if ( AppMain.AoActIsEnd( obj_2d.act ) )
                {
                    obj_2d.frame = 0f;
                    num |= 8U;
                }
            }
            else if ( AppMain.AoActIsEnd( obj_2d.act ) )
            {
                num |= 8U;
            }
        }
        if ( ( num & 32U ) == 0U )
        {
            AppMain.AoActSortRegAction( obj_2d.act );
        }
        AppMain.AoActAcmPop( 1U );
        p_disp_flag |= ( num & 8U );
    }

    // Token: 0x0600049A RID: 1178 RVA: 0x0002734D File Offset: 0x0002554D
    public static void ObjDrawAction2DAMADrawStart()
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.ObjDraw3DNNUserFunc( AppMain._objDraw2DAMAPre_DT, null, 0, 6U );
        AppMain.AoActSortExecuteFix();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x0600049B RID: 1179 RVA: 0x00027374 File Offset: 0x00025574
    public static void ObjDrawSetParallelLight( int light_no, ref AppMain.NNS_RGBA col, float intensity, AppMain.NNS_VECTOR vec )
    {
        AppMain.NNS_LIGHT_PARALLEL parallel = AppMain.g_obj.light[light_no].parallel;
        AppMain.nnSetUpParallelLight( parallel, ref col, intensity, vec );
        AppMain.g_obj.light[light_no].light_type = 1U;
    }

    // Token: 0x0600049C RID: 1180 RVA: 0x000273B0 File Offset: 0x000255B0
    private void ObjDrawSetPointLight( int light_no, ref AppMain.NNS_RGBA col, float intensity, AppMain.NNS_VECTOR pos, float falloffstart, float falloffend )
    {
        AppMain.mppAssertNotImpl();
        AppMain.NNS_LIGHT_POINT point = AppMain.g_obj.light[light_no].point;
        AppMain.nnSetUpPointLight( point, ref col, intensity, pos, falloffstart, falloffend );
        AppMain.g_obj.light[light_no].light_type = 2U;
    }

    // Token: 0x0600049D RID: 1181 RVA: 0x000273F4 File Offset: 0x000255F4
    private void ObjDrawSetTargetSpotLight( int light_no, ref AppMain.NNS_RGBA col, float intensity, AppMain.NNS_VECTOR pos, AppMain.NNS_VECTOR target, int innerangle, int outerangle, float falloffstart, float falloffend )
    {
        AppMain.mppAssertNotImpl();
        AppMain.NNS_LIGHT_TARGET_SPOT target_spot = AppMain.g_obj.light[light_no].target_spot;
        AppMain.nnSetUpTargetSpotLight( target_spot, ref col, intensity, pos, target, innerangle, outerangle, falloffstart, falloffend );
        AppMain.g_obj.light[light_no].light_type = 4U;
    }

    // Token: 0x0600049E RID: 1182 RVA: 0x00027440 File Offset: 0x00025640
    private void ObjDrawSetRotationSpotLight( int light_no, ref AppMain.NNS_RGBA col, float intensity, AppMain.NNS_VECTOR pos, int rottype, AppMain.NNS_ROTATE_A32 rotation, int innerangle, int outerangle, float falloffstart, float falloffend )
    {
        AppMain.mppAssertNotImpl();
        AppMain.NNS_LIGHT_ROTATION_SPOT rotation_spot = AppMain.g_obj.light[light_no].rotation_spot;
        AppMain.nnSetUpRotationSpotLight( rotation_spot, ref col, intensity, pos, rottype, rotation, innerangle, outerangle, falloffstart, falloffend );
        AppMain.g_obj.light[light_no].light_type = 8U;
    }

    // Token: 0x0600049F RID: 1183 RVA: 0x0002748C File Offset: 0x0002568C
    public static void objDrawStart_DT( AppMain.AMS_TCB tcb )
    {
        AppMain.nnSetAmbientColor( AppMain.g_obj.ambient_color.r, AppMain.g_obj.ambient_color.g, AppMain.g_obj.ambient_color.b );
        int i;
        for ( i = 0; i < AppMain.NNE_LIGHT_MAX; i++ )
        {
            if ( ( ( ulong )AppMain.g_obj.def_user_light_flag & ( ulong )( 1L << ( i & 31 ) ) ) != 0UL )
            {
                AppMain.nnSetLight( i, AppMain.g_obj.light[i].light_param, AppMain.g_obj.light[i].light_type );
                AppMain.nnSetLightSwitch( i, 1 );
            }
            else
            {
                AppMain.nnSetLightSwitch( i, 0 );
            }
        }
        AppMain.nnPutLightSettings();
        i = 0;
        while ( ( long )i < 18L )
        {
            if ( AppMain.obj_draw_3dnn_command_state_tbl[i] != 4294967295U )
            {
                AppMain.amDrawExecCommand( AppMain.obj_draw_3dnn_command_state_tbl[i], AppMain.g_obj.drawflag );
                if ( AppMain.obj_draw_3dnn_command_state_exe_end_scene_tbl[i] )
                {
                    AppMain.amDrawEndScene();
                }
            }
            i++;
        }
    }

    // Token: 0x060004A0 RID: 1184 RVA: 0x0002756C File Offset: 0x0002576C
    public static void objDraw3DNNSetCamera( AppMain.OBS_CAMERA obj_camera, int proj_type, uint command_state )
    {
        AppMain.OBS_DRAW_PARAM_3DNN_SET_CAMERA obs_DRAW_PARAM_3DNN_SET_CAMERA = AppMain._objDraw3DNNSetCamera_Pool.Alloc();
        obs_DRAW_PARAM_3DNN_SET_CAMERA.proj_type = proj_type;
        if ( obj_camera != null )
        {
            switch ( proj_type )
            {
                default:
                    obs_DRAW_PARAM_3DNN_SET_CAMERA.prj_mtx.Assign( obj_camera.prj_pers_mtx );
                    break;
                case 1:
                    obs_DRAW_PARAM_3DNN_SET_CAMERA.prj_mtx.Assign( obj_camera.prj_ortho_mtx );
                    break;
            }
            obs_DRAW_PARAM_3DNN_SET_CAMERA.view_mtx.Assign( obj_camera.view_mtx );
        }
        else
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.NNS_CAMERAPTR nns_CAMERAPTR = new AppMain.NNS_CAMERAPTR();
            AppMain.NNS_CAMERA_TARGET_ROLL nns_CAMERA_TARGET_ROLL = new AppMain.NNS_CAMERA_TARGET_ROLL();
            AppMain.NNS_VECTOR vec = new AppMain.NNS_VECTOR(0f, 0f, 0f);
            nns_CAMERAPTR.fType = 255U;
            nns_CAMERAPTR.pCamera = nns_CAMERA_TARGET_ROLL;
            nns_CAMERA_TARGET_ROLL.Target.Assign( vec );
            nns_CAMERA_TARGET_ROLL.Position.Assign( nns_CAMERA_TARGET_ROLL.Target );
            nns_CAMERA_TARGET_ROLL.Position.z += 50f;
            nns_CAMERA_TARGET_ROLL.Position.x += 0f;
            nns_CAMERA_TARGET_ROLL.Roll = AppMain.NNM_DEGtoA32( 0f );
            nns_CAMERA_TARGET_ROLL.Fovy = AppMain.NNM_DEGtoA32( 45f );
            nns_CAMERA_TARGET_ROLL.Aspect = AppMain.AMD_SCREEN_ASPECT;
            nns_CAMERA_TARGET_ROLL.ZNear = 1f;
            nns_CAMERA_TARGET_ROLL.ZFar = 60000f;
            switch ( proj_type )
            {
                default:
                    AppMain.nnMakePerspectiveMatrix( nns_MATRIX2, nns_CAMERA_TARGET_ROLL.Fovy, nns_CAMERA_TARGET_ROLL.Aspect, nns_CAMERA_TARGET_ROLL.ZNear, nns_CAMERA_TARGET_ROLL.ZFar );
                    obs_DRAW_PARAM_3DNN_SET_CAMERA.prj_mtx.Assign( nns_MATRIX2 );
                    break;
                case 1:
                    {
                        float num = 0.078125f;
                        float num2 = AppMain.g_obj.disp_height * num * 0.5f;
                        float num3 = num2 * nns_CAMERA_TARGET_ROLL.Aspect;
                        AppMain.nnMakeOrthoMatrix( nns_MATRIX2, -num3, num3, -num2, num2, nns_CAMERA_TARGET_ROLL.ZNear, nns_CAMERA_TARGET_ROLL.ZFar );
                        obs_DRAW_PARAM_3DNN_SET_CAMERA.prj_mtx.Assign( nns_MATRIX2 );
                        break;
                    }
            }
            AppMain.nnMakeTargetRollCameraViewMatrix( nns_MATRIX, nns_CAMERA_TARGET_ROLL );
            obs_DRAW_PARAM_3DNN_SET_CAMERA.view_mtx.Assign( nns_MATRIX );
        }
        AppMain.amEffectSetWorldViewMatrix( obs_DRAW_PARAM_3DNN_SET_CAMERA.view_mtx );
        AppMain.amDrawRegistCommand( command_state, AppMain.OBD_DRAW_USER_COMMAND_3DNN_SET_CAMERA, obs_DRAW_PARAM_3DNN_SET_CAMERA );
    }

    // Token: 0x060004A1 RID: 1185 RVA: 0x0002777C File Offset: 0x0002597C
    public static void objDraw3DNNModel_DT( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amDrawAlloc_NNS_MATRIX();
        AppMain.amMatrixPush();
        AppMain.OBS_DRAW_PARAM_3DNN_MODEL obs_DRAW_PARAM_3DNN_MODEL;
        if ( command.param is AppMain.AMS_PARAM_DRAW_OBJECT )
        {
            obs_DRAW_PARAM_3DNN_MODEL = ( AppMain.OBS_DRAW_PARAM_3DNN_MODEL )( ( AppMain.AMS_PARAM_DRAW_OBJECT )command.param );
        }
        else
        {
            obs_DRAW_PARAM_3DNN_MODEL = ( AppMain.OBS_DRAW_PARAM_3DNN_MODEL )command.param;
        }
        uint alternativeLighting = obs_DRAW_PARAM_3DNN_MODEL.use_light_flag & 98304U;
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_MODEL.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDrawLight( obs_DRAW_PARAM_3DNN_MODEL.use_light_flag );
        }
        if ( obs_DRAW_PARAM_3DNN_MODEL.user_func != null )
        {
            obs_DRAW_PARAM_3DNN_MODEL.user_func( obs_DRAW_PARAM_3DNN_MODEL.user_param );
        }
        AppMain.AMS_PARAM_DRAW_OBJECT param = obs_DRAW_PARAM_3DNN_MODEL.param;
        int nNode = param._object.nNode;
        AppMain.OBS_DRAW_PARAM_3DNN_SORT_MODEL_Pool.Alloc();
        if ( AppMain._objDraw3DNNModel_DT.plt_mtx == null || AppMain._objDraw3DNNModel_DT.plt_mtx.Length < nNode )
        {
            AppMain._objDraw3DNNModel_DT.plt_mtx = new AppMain.NNS_MATRIX[nNode];
            for ( int i = 0; i < nNode; i++ )
            {
                AppMain._objDraw3DNNModel_DT.plt_mtx[i] = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            }
        }
        AppMain.NNS_MATRIX[] plt_mtx = AppMain._objDraw3DNNModel_DT.plt_mtx;
        if ( AppMain._objDraw3DNNModel_DT.nstat == null || AppMain._objDraw3DNNModel_DT.nstat.Length < ( nNode + 3 & -4 ) )
        {
            AppMain._objDraw3DNNModel_DT.nstat = new uint[nNode + 3 & -4];
        }
        uint[] nstat = AppMain._objDraw3DNNModel_DT.nstat;
        if ( param.mtx != null )
        {
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain.amMatrixGetCurrent(), param.mtx );
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain._am_draw_world_view_matrix, nns_MATRIX );
        }
        else
        {
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain._am_draw_world_view_matrix, AppMain.amMatrixGetCurrent() );
        }
        AppMain.nnSetUpNodeStatusList( nstat, nNode, 0U );
        AppMain.nnCalcMatrixPalette( plt_mtx, nstat, param._object, nns_MATRIX, AppMain._am_default_stack, 1U );
        if ( param.texlist != null )
        {
            AppMain.nnSetTextureList( param.texlist );
        }
        if ( obs_DRAW_PARAM_3DNN_MODEL.state != null )
        {
            AppMain.amDrawPushState();
            AppMain.amDrawSetState( obs_DRAW_PARAM_3DNN_MODEL.state );
        }
        if ( obs_DRAW_PARAM_3DNN_MODEL.material_cb_func != null )
        {
            AppMain.objDraw3DNNSetMaterialCallback( obs_DRAW_PARAM_3DNN_MODEL.material_cb_func, obs_DRAW_PARAM_3DNN_MODEL.material_cb_param );
        }
        if ( command.command_id == AppMain.OBD_DRAW_USER_COMMAND_3DNN_MODEL )
        {
            AppMain.nnDrawObject( param._object, plt_mtx, nstat, param.sub_obj_type | 256U | 512U | 7U, param.flag | drawflag | AppMain.amDrawGetState().drawflag, alternativeLighting );
        }
        else
        {
            AppMain.nnDrawMaterialMotionObject( param._object, plt_mtx, nstat, param.sub_obj_type | 256U | 512U | 7U, param.flag | drawflag | AppMain.amDrawGetState().drawflag );
        }
        if ( obs_DRAW_PARAM_3DNN_MODEL.material_cb_func != null )
        {
            AppMain.objDraw3DNNSetMaterialCallback( null, null );
        }
        if ( obs_DRAW_PARAM_3DNN_MODEL.state != null )
        {
            AppMain.amDrawPopState();
        }
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_MODEL.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDefaultLight();
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x060004A2 RID: 1186 RVA: 0x000279E4 File Offset: 0x00025BE4
    private static void objDraw3DNNMotion_DT( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.SNNS_MATRIX snns_MATRIX = default(AppMain.SNNS_MATRIX);
        AppMain.amMatrixPush();
        AppMain.OBS_DRAW_PARAM_3DNN_MOTION obs_DRAW_PARAM_3DNN_MOTION;
        if ( command.param is AppMain.OBS_DRAW_PARAM_3DNN_MOTION )
        {
            obs_DRAW_PARAM_3DNN_MOTION = ( AppMain.OBS_DRAW_PARAM_3DNN_MOTION )command.param;
        }
        else
        {
            obs_DRAW_PARAM_3DNN_MOTION = ( AppMain.OBS_DRAW_PARAM_3DNN_MOTION )( ( AppMain.AMS_PARAM_DRAW_MOTION_TRS )command.param );
        }
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_MOTION.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDrawLight( obs_DRAW_PARAM_3DNN_MOTION.use_light_flag );
        }
        if ( obs_DRAW_PARAM_3DNN_MOTION.user_func != null )
        {
            obs_DRAW_PARAM_3DNN_MOTION.user_func( obs_DRAW_PARAM_3DNN_MOTION.user_param );
        }
        AppMain.AMS_PARAM_DRAW_MOTION_TRS param = obs_DRAW_PARAM_3DNN_MOTION.param;
        int nNode = param._object.nNode;
        int nMtxPal = param._object.nMtxPal;
        if ( command.command_id == AppMain.OBD_DRAW_USER_COMMAND_3DNN_MOTION_MATMTN && param.mmotion != null )
        {
            AppMain.NNS_OBJECT nns_OBJECT = AppMain.amDrawAlloc_NNS_OBJECT();
            AppMain.nnInitMaterialMotionObject_fast( nns_OBJECT, param._object, param.mmotion );
            AppMain.nnCalcMaterialMotion( nns_OBJECT, param._object, param.mmotion, param.mframe );
            param._object = nns_OBJECT;
        }
        AppMain.OBS_DRAW_PARAM_3DNN_SORT_MODEL_Pool.Alloc();
        if ( AppMain._objDraw3DNNMotion_DT.plt_mtx == null || AppMain._objDraw3DNNMotion_DT.plt_mtx.Length < nMtxPal )
        {
            AppMain._objDraw3DNNMotion_DT.plt_mtx = new AppMain.NNS_MATRIX[nMtxPal];
            for ( int i = 0; i < nMtxPal; i++ )
            {
                AppMain._objDraw3DNNMotion_DT.plt_mtx[i] = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            }
        }
        AppMain.NNS_MATRIX[] plt_mtx = AppMain._objDraw3DNNMotion_DT.plt_mtx;
        if ( AppMain._objDraw3DNNMotion_DT.nstat == null || AppMain._objDraw3DNNMotion_DT.nstat.Length < nNode )
        {
            AppMain._objDraw3DNNMotion_DT.nstat = new uint[nNode];
        }
        uint[] nstat = AppMain._objDraw3DNNMotion_DT.nstat;
        if ( param.mtx != null )
        {
            AppMain.nnMultiplyMatrix( ref snns_MATRIX, AppMain.amMatrixGetCurrent(), param.mtx );
            AppMain.nnMultiplyMatrix( ref snns_MATRIX, AppMain._am_draw_world_view_matrix, ref snns_MATRIX );
        }
        else
        {
            AppMain.nnMultiplyMatrix( ref snns_MATRIX, AppMain._am_draw_world_view_matrix, AppMain.amMatrixGetCurrent() );
        }
        AppMain.nnSetUpNodeStatusList( nstat, nNode, 0U );
        AppMain.nnCalcMatrixPaletteTRSList( plt_mtx, nstat, param._object, param.trslist, ref snns_MATRIX, AppMain._am_default_stack, 1U );
        if ( param.motion != null )
        {
            AppMain.nnCalcNodeHideMotion( nstat, param.motion, param.frame );
        }
        if ( obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_func != null )
        {
            obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_func( plt_mtx, param._object, obs_DRAW_PARAM_3DNN_MOTION.mplt_cb_param );
        }
        if ( param.texlist != null )
        {
            AppMain.nnSetTextureList( param.texlist );
        }
        if ( obs_DRAW_PARAM_3DNN_MOTION.state != null )
        {
            AppMain.amDrawPushState();
            AppMain.amDrawSetState( obs_DRAW_PARAM_3DNN_MOTION.state );
        }
        if ( obs_DRAW_PARAM_3DNN_MOTION.material_cb_func != null )
        {
            AppMain.objDraw3DNNSetMaterialCallback( obs_DRAW_PARAM_3DNN_MOTION.material_cb_func, obs_DRAW_PARAM_3DNN_MOTION.material_cb_param );
        }
        if ( command.command_id == AppMain.OBD_DRAW_USER_COMMAND_3DNN_MOTION )
        {
            AppMain.nnDrawObject( param._object, plt_mtx, nstat, param.sub_obj_type | 256U | 512U | 7U, param.flag | drawflag | AppMain.amDrawGetState().drawflag, 0U );
        }
        else
        {
            AppMain.nnDrawMaterialMotionObject( param._object, plt_mtx, nstat, param.sub_obj_type | 256U | 512U | 7U, param.flag | drawflag | AppMain.amDrawGetState().drawflag );
        }
        if ( obs_DRAW_PARAM_3DNN_MOTION.material_cb_func != null )
        {
            AppMain.objDraw3DNNSetMaterialCallback( null, null );
        }
        if ( obs_DRAW_PARAM_3DNN_MOTION.state != null )
        {
            AppMain.amDrawPopState();
        }
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_MOTION.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDefaultLight();
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x060004A3 RID: 1187 RVA: 0x00027CE0 File Offset: 0x00025EE0
    public static void objDraw3DNNDrawPrimitive_DT( object param )
    {
        AppMain.OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE = (AppMain.OBS_DRAW_PARAM_3DNN_DRAW_PRIMITIVE)param;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE dat = obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.dat;
        AppMain.amMatrixPush();
        AppMain.nnMultiplyMatrix( ref AppMain.tempSNNS_MATRIX0, AppMain.amMatrixGetCurrent(), obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.mtx );
        AppMain.nnMultiplyMatrix( ref AppMain.tempSNNS_MATRIX0, AppMain._am_draw_world_view_matrix, ref AppMain.tempSNNS_MATRIX0 );
        AppMain.nnSetPrimitive3DMatrix( ref AppMain.tempSNNS_MATRIX0 );
        AppMain.nnSetPrimitiveTexNum( dat.texlist, dat.texId );
        AppMain.nnSetPrimitiveTexState( 0, 0, dat.uwrap, dat.vwrap );
        if ( dat.aTest != 0 )
        {
            AppMain.nnSetPrimitive3DAlphaFuncGL( 516U, 0.5f );
        }
        else
        {
            AppMain.nnSetPrimitive3DAlphaFuncGL( 519U, 0.5f );
        }
        AppMain.nnSetPrimitive3DDepthMaskGL( dat.zMask == 0 );
        if ( dat.zTest != 0 )
        {
            AppMain.nnSetPrimitive3DDepthFuncGL( 515U );
        }
        else
        {
            AppMain.nnSetPrimitive3DDepthFuncGL( 519U );
        }
        if ( dat.ablend != 0 && dat.bldMode == 32774 )
        {
            int bldDst = dat.bldDst;
            if ( bldDst != 1 )
            {
                if ( bldDst != 771 )
                {
                    AppMain.nnSetPrimitiveBlend( 1 );
                }
                else
                {
                    AppMain.nnSetPrimitiveBlend( 1 );
                }
            }
            else
            {
                AppMain.nnSetPrimitiveBlend( 0 );
            }
        }
        AppMain.nnBeginDrawPrimitive3D( dat.format3D, dat.ablend, obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.light, obs_DRAW_PARAM_3DNN_DRAW_PRIMITIVE.cull );
        switch ( dat.format3D )
        {
            case 2:
                AppMain.nnDrawPrimitive3D( dat.type, dat.vtxPC3D, dat.count );
                break;
            case 4:
                AppMain.nnDrawPrimitive3D( dat.type, dat.vtxPCT3D, dat.count );
                break;
        }
        AppMain.nnEndDrawPrimitive3D();
        AppMain.amMatrixPop();
    }

    // Token: 0x060004A4 RID: 1188 RVA: 0x00027E60 File Offset: 0x00026060
    private static void objDraw3DNNSetCamera_DT( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.OBS_DRAW_PARAM_3DNN_SET_CAMERA obs_DRAW_PARAM_3DNN_SET_CAMERA = (AppMain.OBS_DRAW_PARAM_3DNN_SET_CAMERA)command.param;
        if ( obs_DRAW_PARAM_3DNN_SET_CAMERA.proj_type == 1 )
        {
            AppMain.amDrawSetProjection( obs_DRAW_PARAM_3DNN_SET_CAMERA.prj_mtx, 1 );
        }
        else
        {
            AppMain.amDrawSetProjection( obs_DRAW_PARAM_3DNN_SET_CAMERA.prj_mtx, 0 );
        }
        AppMain.amDrawSetWorldViewMatrix( obs_DRAW_PARAM_3DNN_SET_CAMERA.view_mtx );
        AppMain.nnSetLightMatrix( obs_DRAW_PARAM_3DNN_SET_CAMERA.view_mtx );
        AppMain.nnPutLightSettings();
    }

    // Token: 0x060004A5 RID: 1189 RVA: 0x00027EB8 File Offset: 0x000260B8
    public static void objDraw3DNNUserFunc_DT( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.OBS_DRAW_PARAM_3DNN_USER_FUNC obs_DRAW_PARAM_3DNN_USER_FUNC = (AppMain.OBS_DRAW_PARAM_3DNN_USER_FUNC)command.param;
        obs_DRAW_PARAM_3DNN_USER_FUNC.func( obs_DRAW_PARAM_3DNN_USER_FUNC.param );
    }

    // Token: 0x060004A6 RID: 1190 RVA: 0x00027EE4 File Offset: 0x000260E4
    public static void objDraw3DNNDrawMotion_DT( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amDrawAlloc_NNS_MATRIX();
        AppMain.amMatrixPush();
        AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION obs_DRAW_PARAM_3DNN_DRAW_MOTION;
        if ( command.param is AppMain.AMS_PARAM_DRAW_MOTION )
        {
            obs_DRAW_PARAM_3DNN_DRAW_MOTION = ( AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION )( ( AppMain.AMS_PARAM_DRAW_MOTION )command.param );
        }
        else
        {
            obs_DRAW_PARAM_3DNN_DRAW_MOTION = ( AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION )command.param;
        }
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_DRAW_MOTION.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDrawLight( obs_DRAW_PARAM_3DNN_DRAW_MOTION.use_light_flag );
        }
        if ( obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_func != null )
        {
            obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_func( obs_DRAW_PARAM_3DNN_DRAW_MOTION.user_param );
        }
        AppMain.AMS_PARAM_DRAW_MOTION param = obs_DRAW_PARAM_3DNN_DRAW_MOTION.param;
        int nNode = param._object.nNode;
        if ( AppMain._objDraw3DNNDrawMotion_DT.plt_mtx == null || AppMain._objDraw3DNNDrawMotion_DT.plt_mtx.Length < nNode )
        {
            AppMain._objDraw3DNNDrawMotion_DT.plt_mtx = new AppMain.NNS_MATRIX[nNode];
            AppMain._objDraw3DNNDrawMotion_DT.nstat = new uint[nNode];
            for ( int i = 0; i < nNode; i++ )
            {
                AppMain._objDraw3DNNDrawMotion_DT.plt_mtx[i] = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            }
        }
        AppMain.NNS_MATRIX[] plt_mtx = AppMain._objDraw3DNNDrawMotion_DT.plt_mtx;
        uint[] nstat = AppMain._objDraw3DNNDrawMotion_DT.nstat;
        if ( param.mtx != null )
        {
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain.amMatrixGetCurrent(), param.mtx );
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain._am_draw_world_view_matrix, nns_MATRIX );
        }
        else
        {
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain._am_draw_world_view_matrix, AppMain.amMatrixGetCurrent() );
        }
        AppMain.nnSetUpNodeStatusList( nstat, nNode, 0U );
        AppMain.nnCalcMatrixPaletteMotion( plt_mtx, nstat, param._object, param.motion, param.frame, nns_MATRIX, AppMain._am_default_stack, 1U );
        AppMain.nnCalcNodeHideMotion( nstat, param.motion, param.frame );
        if ( obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_func != null )
        {
            obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_func( plt_mtx, param._object, obs_DRAW_PARAM_3DNN_DRAW_MOTION.mplt_cb_param );
        }
        if ( param.texlist != null )
        {
            AppMain.nnSetTextureList( param.texlist );
        }
        if ( obs_DRAW_PARAM_3DNN_DRAW_MOTION.state != null )
        {
            AppMain.amDrawPushState();
            AppMain.amDrawSetState( obs_DRAW_PARAM_3DNN_DRAW_MOTION.state );
        }
        if ( obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_func != null )
        {
            AppMain.objDraw3DNNSetMaterialCallback( obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_func, obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_param );
        }
        uint alternativeLighting = obs_DRAW_PARAM_3DNN_DRAW_MOTION.use_light_flag & 98304U;
        if ( command.command_id == AppMain.OBD_DRAW_USER_COMMAND_3DNN_DRAW_MOTION )
        {
            AppMain.nnDrawObject( param._object, plt_mtx, nstat, param.sub_obj_type | 256U | 512U | 7U, param.flag | drawflag | AppMain.amDrawGetState().drawflag, alternativeLighting );
        }
        else
        {
            AppMain.nnDrawMaterialMotionObject( param._object, plt_mtx, nstat, param.sub_obj_type | 256U | 512U | 7U, param.flag | drawflag | AppMain.amDrawGetState().drawflag );
        }
        if ( obs_DRAW_PARAM_3DNN_DRAW_MOTION.material_cb_func != null )
        {
            AppMain.objDraw3DNNSetMaterialCallback( null, null );
        }
        if ( obs_DRAW_PARAM_3DNN_DRAW_MOTION.state != null )
        {
            AppMain.amDrawPopState();
        }
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_DRAW_MOTION.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDefaultLight();
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x060004A7 RID: 1191 RVA: 0x00028168 File Offset: 0x00026368
    private static void objDraw3DNNModelCommandSortFunc( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.obj_draw_user_command_sort_func_tbl[command.command_id]( command, drawflag );
    }

    // Token: 0x060004A8 RID: 1192 RVA: 0x00028180 File Offset: 0x00026380
    private static void objDraw3DNNSortModel_DT( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.amMatrixPush();
        AppMain.OBS_DRAW_PARAM_3DNN_SORT_MODEL obs_DRAW_PARAM_3DNN_SORT_MODEL = (AppMain.OBS_DRAW_PARAM_3DNN_SORT_MODEL)command.param;
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_SORT_MODEL.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDrawLight( obs_DRAW_PARAM_3DNN_SORT_MODEL.use_light_flag );
        }
        if ( obs_DRAW_PARAM_3DNN_SORT_MODEL.user_func != null )
        {
            obs_DRAW_PARAM_3DNN_SORT_MODEL.user_func( obs_DRAW_PARAM_3DNN_SORT_MODEL.user_param );
        }
        AppMain.AMS_PARAM_SORT_DRAW_OBJECT param = obs_DRAW_PARAM_3DNN_SORT_MODEL.param;
        AppMain.AMS_PARAM_DRAW_OBJECT draw_object = param.draw_object;
        if ( draw_object.texlist != null )
        {
            AppMain.nnSetTextureList( draw_object.texlist );
        }
        if ( param.draw_state != null )
        {
            AppMain.amDrawPushState();
            AppMain.amDrawSetState( param.draw_state );
        }
        AppMain.objDraw3DNNSetMaterialCallback( obs_DRAW_PARAM_3DNN_SORT_MODEL.material_cb_func, obs_DRAW_PARAM_3DNN_SORT_MODEL.material_cb_param );
        if ( command.command_id == AppMain.OBD_DRAW_USER_COMMAND_SORT_3DNN_MODEL )
        {
            AppMain.nnDrawObject( draw_object._object, param.mtx, param.nstat_list, draw_object.sub_obj_type | 256U | 512U | 2U, draw_object.flag | param.drawflag | AppMain.amDrawGetState().drawflag, 0U );
        }
        else
        {
            AppMain.nnDrawMaterialMotionObject( draw_object._object, param.mtx, param.nstat_list, draw_object.sub_obj_type | 256U | 512U | 2U, draw_object.flag | param.drawflag | AppMain.amDrawGetState().drawflag );
        }
        AppMain.objDraw3DNNSetMaterialCallback( null, null );
        if ( param.draw_state != null )
        {
            AppMain.amDrawPopState();
        }
        if ( ( AppMain.g_obj.def_user_light_flag ^ obs_DRAW_PARAM_3DNN_SORT_MODEL.use_light_flag ) != 0U )
        {
            AppMain.objDrawSetDefaultLight();
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x060004A9 RID: 1193 RVA: 0x000282E7 File Offset: 0x000264E7
    private static void objDraw3DNNSetMaterialCallback( AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE cb_func, object cb_param )
    {
        AppMain.obj_draw_material_cb_func = cb_func;
        AppMain.obj_draw_material_cb_param = cb_param;
        if ( cb_func != null )
        {
            AppMain.nnSetMaterialCallback( AppMain._objDraw3DNNMaterialCallback );
            return;
        }
        AppMain.nnSetMaterialCallback( null );
    }

    // Token: 0x060004AA RID: 1194 RVA: 0x00028309 File Offset: 0x00026509
    public static int objDraw3DNNMaterialCallback( AppMain.NNS_DRAWCALLBACK_VAL draw_cb_val )
    {
        if ( AppMain.obj_draw_material_cb_func == null )
        {
            return AppMain.nnPutMaterialCore( draw_cb_val );
        }
        if ( !AppMain.obj_draw_material_cb_func( draw_cb_val, AppMain.obj_draw_material_cb_param ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060004AB RID: 1195 RVA: 0x00028330 File Offset: 0x00026530
    public static void objDrawSetDrawLight( uint use_light_flag )
    {
        for ( int i = 0; i < AppMain.NNE_LIGHT_MAX; i++ )
        {
            if ( ( ( ulong )use_light_flag & ( ulong )( 1L << ( i & 31 ) ) ) != 0UL )
            {
                AppMain.nnSetLight( i, AppMain.g_obj.light[i].light_param, AppMain.g_obj.light[i].light_type );
                AppMain.nnSetLightSwitch( i, 1 );
            }
            else
            {
                AppMain.nnSetLightSwitch( i, 0 );
            }
        }
        AppMain.nnPutLightSettings();
    }

    // Token: 0x060004AC RID: 1196 RVA: 0x00028398 File Offset: 0x00026598
    public static void objDrawSetDefaultLight()
    {
        for ( int i = 0; i < AppMain.NNE_LIGHT_MAX; i++ )
        {
            if ( ( ( ulong )AppMain.g_obj.def_user_light_flag & ( ulong )( 1L << ( i & 31 ) ) ) != 0UL )
            {
                AppMain.nnSetLight( i, AppMain.g_obj.light[i].light_param, AppMain.g_obj.light[i].light_type );
                AppMain.nnSetLightSwitch( i, 1 );
            }
            else
            {
                AppMain.nnSetLightSwitch( i, 0 );
            }
        }
        AppMain.nnPutLightSettings();
    }

    // Token: 0x060004AD RID: 1197 RVA: 0x00028409 File Offset: 0x00026609
    public static void objDraw3DESEffectServerMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.amEffectExecute();
    }

    // Token: 0x060004AE RID: 1198 RVA: 0x00028410 File Offset: 0x00026610
    public static void objDraw3DESMatrixPush_UserFunc( object param )
    {
        AppMain.amMatrixPush();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, ( AppMain.NNS_MATRIX )param );
        AppMain.nnMultiplyMatrix( ref AppMain.tempSNNS_MATRIX0, AppMain.amDrawGetWorldViewMatrix(), nns_MATRIX );
        AppMain.nnSetPrimitive3DMatrix( ref AppMain.tempSNNS_MATRIX0 );
    }

    // Token: 0x060004AF RID: 1199 RVA: 0x0002844F File Offset: 0x0002664F
    public static void objDraw3DESMatrixPop_UserFunc( object param )
    {
        AppMain.amMatrixPop();
    }

    // Token: 0x060004B0 RID: 1200 RVA: 0x00028456 File Offset: 0x00026656
    public static void objDraw2DAMAPre_DT( object param )
    {
        AppMain.AoActDrawPre();
    }
}
