using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020000C0 RID: 192
    public class GMS_DECO_SUBMODEL_WORK : AppMain.IClearable, AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001EED RID: 7917 RVA: 0x0013CB30 File Offset: 0x0013AD30
        public void Clear()
        {
            this.deco_work.Clear();
            this.obj_3d_sub.Clear();
            this.sub_model_index = 0;
        }

        // Token: 0x06001EEE RID: 7918 RVA: 0x0013CB4F File Offset: 0x0013AD4F
        public static explicit operator AppMain.GMS_DECO_WORK( AppMain.GMS_DECO_SUBMODEL_WORK work )
        {
            return work.deco_work;
        }

        // Token: 0x06001EEF RID: 7919 RVA: 0x0013CB57 File Offset: 0x0013AD57
        public GMS_DECO_SUBMODEL_WORK()
        {
            this.deco_work = new AppMain.GMS_DECO_WORK( this );
        }

        // Token: 0x06001EF0 RID: 7920 RVA: 0x0013CB76 File Offset: 0x0013AD76
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.deco_work.obj_work;
        }

        // Token: 0x04004B87 RID: 19335
        public readonly AppMain.GMS_DECO_WORK deco_work;

        // Token: 0x04004B88 RID: 19336
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_sub = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004B89 RID: 19337
        public int sub_model_index;
    }

    // Token: 0x020000C1 RID: 193
    public class GMS_DECO_FALL_REGISTER : AppMain.IClearable
    {
        // Token: 0x06001EF1 RID: 7921 RVA: 0x0013CB83 File Offset: 0x0013AD83
        public void Clear()
        {
            this.num = 0U;
            this.vec.Clear();
        }

        // Token: 0x04004B8A RID: 19338
        public uint num;

        // Token: 0x04004B8B RID: 19339
        public AppMain.VecFx32 vec = default(AppMain.VecFx32);
    }

    // Token: 0x020000C2 RID: 194
    public class GMS_DECO_FALL_MANAGER : AppMain.IClearable
    {
        // Token: 0x06001EF3 RID: 7923 RVA: 0x0013CBAC File Offset: 0x0013ADAC
        public void Clear()
        {
            this.dec_id = 0U;
            this.texlist = null;
            this.all_num = ( this.reg_num = 0 );
            this.frame = 0f;
            AppMain.ClearArray<AppMain.GMS_DECO_FALL_REGISTER>( this.reg );
        }

        // Token: 0x04004B8C RID: 19340
        public uint dec_id;

        // Token: 0x04004B8D RID: 19341
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04004B8E RID: 19342
        public ushort all_num;

        // Token: 0x04004B8F RID: 19343
        public ushort reg_num;

        // Token: 0x04004B90 RID: 19344
        public float frame;

        // Token: 0x04004B91 RID: 19345
        public AppMain.GMS_DECO_FALL_REGISTER[] reg = AppMain.New<AppMain.GMS_DECO_FALL_REGISTER>(8);
    }

    // Token: 0x020000C3 RID: 195
    public class GMS_DECO_PRIM_DRAW_STACK
    {
        // Token: 0x04004B92 RID: 19346
        public AppMain.AOS_TVX_VERTEX[] vtx;

        // Token: 0x04004B93 RID: 19347
        public AppMain.VecFx32 pos;

        // Token: 0x04004B94 RID: 19348
        public float off_y;

        // Token: 0x04004B95 RID: 19349
        public uint disp_flag;

        // Token: 0x04004B96 RID: 19350
        public uint vtx_num;
    }

    // Token: 0x020000C4 RID: 196
    public class GMS_DECO_PRIM_DRAW_WORK
    {
        // Token: 0x04004B97 RID: 19351
        public AppMain.AOS_TEXTURE tex;

        // Token: 0x04004B98 RID: 19352
        public int tex_id;

        // Token: 0x04004B99 RID: 19353
        public uint command;

        // Token: 0x04004B9A RID: 19354
        public ushort all_vtx_num;

        // Token: 0x04004B9B RID: 19355
        public ushort stack_num;

        // Token: 0x04004B9C RID: 19356
        public readonly AppMain.GMS_DECO_PRIM_DRAW_STACK[] stack = AppMain.New<AppMain.GMS_DECO_PRIM_DRAW_STACK>(128);
    }

    // Token: 0x020000C5 RID: 197
    public class GMS_DECO_MGR : AppMain.IClearable
    {
        // Token: 0x06001EF7 RID: 7927 RVA: 0x0013CC24 File Offset: 0x0013AE24
        public void Clear()
        {
            this.tcb_post = null;
            this.flag_render_front = ( this.flag_render_back = false );
            this.render_target_front = ( this.render_target_back = null );
            this.state_loop = 0;
            this.se_handle = null;
            for ( int i = 0; i < this.motion_frame_loop.Length; i++ )
            {
                this.motion_frame_loop[i] = 0;
            }
        }

        // Token: 0x04004B9D RID: 19357
        public AppMain.MTS_TASK_TCB tcb_post;

        // Token: 0x04004B9E RID: 19358
        public int[] common_frame_motion = new int[3];

        // Token: 0x04004B9F RID: 19359
        public bool flag_render_front;

        // Token: 0x04004BA0 RID: 19360
        public bool flag_render_back;

        // Token: 0x04004BA1 RID: 19361
        public AppMain.AMS_RENDER_TARGET render_target_front;

        // Token: 0x04004BA2 RID: 19362
        public AppMain.AMS_RENDER_TARGET render_target_back;

        // Token: 0x04004BA3 RID: 19363
        public int[] motion_frame_loop = new int[12];

        // Token: 0x04004BA4 RID: 19364
        public int state_loop;

        // Token: 0x04004BA5 RID: 19365
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x020000C6 RID: 198
    public class GMS_DECO_DATA
    {
        // Token: 0x06001EF9 RID: 7929 RVA: 0x0013CCA3 File Offset: 0x0013AEA3
        public void Clear()
        {
            this.tvx_tex.Clear();
            this.amb_header = null;
            this.obj_3d_list = null;
            this.obj_3d_list_fall = null;
            this.tvx_model = null;
        }

        // Token: 0x04004BA6 RID: 19366
        public AppMain.AMS_AMB_HEADER amb_header;

        // Token: 0x04004BA7 RID: 19367
        public AppMain.OBS_ACTION3D_NN_WORK obj_3d_list;

        // Token: 0x04004BA8 RID: 19368
        public AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_list_fall;

        // Token: 0x04004BA9 RID: 19369
        public AppMain.AMS_AMB_HEADER tvx_model;

        // Token: 0x04004BAA RID: 19370
        public AppMain.TVX_FILE[] tvx_model_data;

        // Token: 0x04004BAB RID: 19371
        public readonly AppMain.AOS_TEXTURE tvx_tex = new AppMain.AOS_TEXTURE();
    }

    // Token: 0x020000C7 RID: 199
    public class GMS_DECO_WORK : AppMain.IClearable, AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001EFB RID: 7931 RVA: 0x0013CCDF File Offset: 0x0013AEDF
        public static explicit operator AppMain.GMS_DECO_SUBMODEL_WORK( AppMain.GMS_DECO_WORK p )
        {
            return ( AppMain.GMS_DECO_SUBMODEL_WORK )p.holder;
        }

        // Token: 0x06001EFC RID: 7932 RVA: 0x0013CCEC File Offset: 0x0013AEEC
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x06001EFD RID: 7933 RVA: 0x0013CCF4 File Offset: 0x0013AEF4
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_DECO_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x06001EFE RID: 7934 RVA: 0x0013CCFC File Offset: 0x0013AEFC
        public void Clear()
        {
            this.obj_work.Clear();
            this.obj_3d.Clear();
            AppMain.ClearArray<AppMain.OBS_RECT_WORK>( this.rect_work );
            this.event_record = null;
            this.event_x = 0;
            this.model_tex = null;
            this.model_index = 0;
        }

        // Token: 0x06001EFF RID: 7935 RVA: 0x0013CD3B File Offset: 0x0013AF3B
        public GMS_DECO_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x06001F00 RID: 7936 RVA: 0x0013CD66 File Offset: 0x0013AF66
        public GMS_DECO_WORK( object _holder )
        {
            this.holder = _holder;
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04004BAC RID: 19372
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004BAD RID: 19373
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004BAE RID: 19374
        public readonly AppMain.OBS_RECT_WORK[] rect_work = AppMain.New<AppMain.OBS_RECT_WORK>(1);

        // Token: 0x04004BAF RID: 19375
        public AppMain.GMS_EVE_RECORD_DECORATE event_record;

        // Token: 0x04004BB0 RID: 19376
        public byte event_x;

        // Token: 0x04004BB1 RID: 19377
        public AppMain.AOS_TEXTURE model_tex;

        // Token: 0x04004BB2 RID: 19378
        public int model_index;

        // Token: 0x04004BB3 RID: 19379
        public readonly object holder;
    }

    // Token: 0x020000C8 RID: 200
    // (Invoke) Token: 0x06001F02 RID: 7938
    public delegate void GMF_DECO_RECT_FUNC( AppMain.OBS_RECT_WORK _obs_rect_work1, AppMain.OBS_RECT_WORK _obs_rect_work2 );

    // Token: 0x020000C9 RID: 201
    private class _gmDecoExecuteDrawPrimitive
    {
        // Token: 0x04004BB4 RID: 19380
        public static AppMain.NNS_PRIM3D_PCT_ARRAY[] v_tbl_array = AppMain.New<AppMain.NNS_PRIM3D_PCT_ARRAY>(16);

        // Token: 0x04004BB5 RID: 19381
        public static AppMain.NNS_PRIM3D_PCT[][] v_tbl = new AppMain.NNS_PRIM3D_PCT[16][];
    }

    // Token: 0x060003FC RID: 1020 RVA: 0x000207E9 File Offset: 0x0001E9E9
    private static void GmDecoInit()
    {
        AppMain.gmDecoInitMgr();
        AppMain.ClearArray<AppMain.GMS_DECO_FALL_MANAGER>( AppMain.g_deco_fall_manager, 0, 16 );
    }

    // Token: 0x060003FD RID: 1021 RVA: 0x000207FD File Offset: 0x0001E9FD
    public static void GmDecoExit()
    {
        AppMain.gmDecoExitMgr();
        AppMain.gmDeco_motionHeader = null;
        AppMain.gmDeco_matMotionHeader = null;
    }

    // Token: 0x060003FE RID: 1022 RVA: 0x00020810 File Offset: 0x0001EA10
    public static void gmDecoDrawServerMain( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        uint command = 0U;
        float dividend = AppMain.gmDecoGameSystemGetSyncTime();
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER = AppMain.g_deco_fall_manager[i];
            if ( gms_DECO_FALL_MANAGER.dec_id != 0U )
            {
                uint dec_id = gms_DECO_FALL_MANAGER.dec_id;
                if ( dec_id == 20U )
                {
                    goto IL_76;
                }
                if ( dec_id != 27U )
                {
                    switch ( dec_id )
                    {
                        case 40U:
                        case 41U:
                        case 42U:
                            goto IL_76;
                        case 43U:
                        case 44U:
                        case 45U:
                        case 46U:
                            goto IL_87;
                        case 47U:
                        case 48U:
                        case 49U:
                            break;
                        default:
                            goto IL_87;
                    }
                }
                command = 12U;
                AppMain.ObjDraw3DNNSetCameraEx( 0, 1, 12U );
                IL_87:
                AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
                vecFx.Assign( gms_DECO_FALL_MANAGER.reg[0].vec );
                AppMain.NNS_TEXLIST texlist = gms_DECO_FALL_MANAGER.texlist;
                AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
                AppMain.nnMakeUnitMatrix( nns_MATRIX );
                AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, AppMain.FX_FX32_TO_F32( vecFx.x ), AppMain.FX_FX32_TO_F32( vecFx.y ), AppMain.FX_FX32_TO_F32( vecFx.z ) );
                AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
                ams_PARAM_DRAW_PRIMITIVE.type = 0;
                ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * gms_DECO_FALL_MANAGER.reg_num );
                ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
                ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
                ams_PARAM_DRAW_PRIMITIVE.bldDst = 771;
                ams_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
                ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
                ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
                ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
                ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
                ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
                ams_PARAM_DRAW_PRIMITIVE.vwrap = 0;
                ams_PARAM_DRAW_PRIMITIVE.texlist = texlist;
                ams_PARAM_DRAW_PRIMITIVE.texId = texlist.nTex - 1;
                ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( ams_PARAM_DRAW_PRIMITIVE.count );
                AppMain.NNS_PRIM3D_PCT[] buffer = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
                int offset = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
                ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
                uint num = 0U;
                float num2 = AppMain.fmod(dividend, gms_DECO_FALL_MANAGER.frame) / gms_DECO_FALL_MANAGER.frame * 5.027991f;
                AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
                AppMain.VecFx32 vecFx2 = default(AppMain.VecFx32);
                for ( uint num3 = 0U; num3 < 8U; num3 += 1U )
                {
                    vecFx2.Assign( gms_DECO_FALL_MANAGER.reg[( int )( ( UIntPtr )num3 )].vec );
                    if ( vecFx2.x != 0 )
                    {
                        int num4 = offset + (int)(6U * num);
                        buffer[num4].Tex.u = ( buffer[num4 + 1].Tex.u = 1f );
                        buffer[num4 + 2].Tex.u = ( buffer[num4 + 3].Tex.u = 0f );
                        buffer[num4].Tex.v = ( buffer[num4 + 2].Tex.v = -1f * gms_DECO_FALL_MANAGER.reg[( int )( ( UIntPtr )num3 )].num - num2 );
                        buffer[num4 + 1].Tex.v = ( buffer[num4 + 3].Tex.v = 0f - num2 );
                        buffer[num4].Col = uint.MaxValue;
                        buffer[num4 + 1].Col = ( buffer[num4 + 2].Col = ( buffer[num4 + 3].Col = buffer[num4].Col ) );
                        nns_VECTOR.x = AppMain.FX_FX32_TO_F32( vecFx2.x - vecFx.x );
                        nns_VECTOR.y = AppMain.FX_FX32_TO_F32( vecFx2.y - vecFx.y );
                        nns_VECTOR.z = AppMain.FX_FX32_TO_F32( vecFx2.z - vecFx.z );
                        buffer[num4].Pos.x = ( buffer[num4 + 1].Pos.x = 32f + nns_VECTOR.x );
                        buffer[num4 + 2].Pos.x = ( buffer[num4 + 3].Pos.x = -32f + nns_VECTOR.x );
                        buffer[num4].Pos.y = ( buffer[num4 + 2].Pos.y = 32f + nns_VECTOR.y );
                        buffer[num4 + 1].Pos.y = ( buffer[num4 + 3].Pos.y = -32f + nns_VECTOR.y + -64f * ( gms_DECO_FALL_MANAGER.reg[( int )( ( UIntPtr )num3 )].num - 1U ) );
                        buffer[num4].Pos.z = ( buffer[num4 + 1].Pos.z = ( buffer[num4 + 2].Pos.z = ( buffer[num4 + 3].Pos.z = 1f + nns_VECTOR.z ) ) );
                        buffer[num4 + 4] = buffer[num4 + 2];
                        buffer[num4 + 5] = buffer[num4 + 3];
                        buffer[num4 + 3] = buffer[num4 + 1];
                        gms_DECO_FALL_MANAGER.reg[( int )( ( UIntPtr )num3 )].vec.y = 0;
                        num += 1U;
                    }
                }
                AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
                AppMain.amMatrixPush( nns_MATRIX );
                AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
                AppMain.ObjDraw3DNNDrawPrimitive( ams_PARAM_DRAW_PRIMITIVE, command, 0, 0 );
                AppMain.amMatrixPop();
                AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
                goto IL_5C4;
                IL_76:
                command = 9U;
                goto IL_87;
            }
            IL_5C4:;
        }
        AppMain.gmDecoExecuteDrawPrimitive();
        AppMain.gmDecoInitDrawPrimitive();
    }

    // Token: 0x060003FF RID: 1023 RVA: 0x00020DF7 File Offset: 0x0001EFF7
    private static uint gmDecoGameSystemGetSyncTime()
    {
        return AppMain.g_gm_main_system.sync_time;
    }

    // Token: 0x06000400 RID: 1024 RVA: 0x00020E04 File Offset: 0x0001F004
    private static void gmDecoExecuteDrawPrimitive()
    {
        AppMain.GMS_DECO_PRIM_DRAW_WORK[] array = AppMain.g_deco_tvx_work;
        if ( array[0].tex == null )
        {
            return;
        }
        AppMain.SNNS_MATRIX snns_MATRIX = default(AppMain.SNNS_MATRIX);
        AppMain.SNNS_MATRIX snns_MATRIX2 = default(AppMain.SNNS_MATRIX);
        AppMain.SNNS_MATRIX snns_MATRIX3 = default(AppMain.SNNS_MATRIX);
        AppMain.nnMakeUnitMatrix( ref snns_MATRIX3 );
        AppMain.nnMakeScaleMatrix( out snns_MATRIX, -1f, 1f, 1f );
        AppMain.nnMakeScaleMatrix( out snns_MATRIX2, 1f, -1f, 1f );
        uint num = AppMain.GmMainGetLightColor();
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.ablend = 0;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldDst = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.aTest = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.zMask = 0;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.zTest = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.noSort = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.uwrap = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.vwrap = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.format3D = 4;
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        for ( uint num2 = 0U; num2 < 16U; num2 += 1U )
        {
            if ( array[( int )( ( UIntPtr )num2 )].tex_id == -1 )
            {
                return;
            }
            if ( array[( int )( ( UIntPtr )num2 )].tex_id != 0 )
            {
                AppMain._AMS_PARAM_DRAW_PRIMITIVE.ablend = 1;
                AppMain._AMS_PARAM_DRAW_PRIMITIVE.aTest = 0;
            }
            else
            {
                AppMain._AMS_PARAM_DRAW_PRIMITIVE.ablend = 0;
                AppMain._AMS_PARAM_DRAW_PRIMITIVE.aTest = 1;
            }
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.texlist = array[( int )( ( UIntPtr )num2 )].tex.texlist;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.type = 1;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.count = ( int )( array[( int )( ( UIntPtr )num2 )].all_vtx_num + array[( int )( ( UIntPtr )num2 )].stack_num * 2 - 2 );
            if ( AppMain._gmDecoExecuteDrawPrimitive.v_tbl[( int )( ( UIntPtr )num2 )] == null || AppMain._gmDecoExecuteDrawPrimitive.v_tbl[( int )( ( UIntPtr )num2 )].Length < AppMain._AMS_PARAM_DRAW_PRIMITIVE.count )
            {
                AppMain._gmDecoExecuteDrawPrimitive.v_tbl[( int )( ( UIntPtr )num2 )] = new AppMain.NNS_PRIM3D_PCT[AppMain._AMS_PARAM_DRAW_PRIMITIVE.count];
            }
            AppMain._gmDecoExecuteDrawPrimitive.v_tbl_array[( int )( ( UIntPtr )num2 )].buffer = AppMain._gmDecoExecuteDrawPrimitive.v_tbl[( int )( ( UIntPtr )num2 )];
            AppMain.NNS_PRIM3D_PCT[] buffer = AppMain._gmDecoExecuteDrawPrimitive.v_tbl_array[(int)((UIntPtr)num2)].buffer;
            int num3 = 0;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain._gmDecoExecuteDrawPrimitive.v_tbl_array[( int )( ( UIntPtr )num2 )];
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.texId = array[( int )( ( UIntPtr )num2 )].tex_id;
            for ( uint num4 = 0U; num4 < ( uint )array[( int )( ( UIntPtr )num2 )].stack_num; num4 += 1U )
            {
                AppMain.GMS_DECO_PRIM_DRAW_STACK gms_DECO_PRIM_DRAW_STACK = array[(int)((UIntPtr)num2)].stack[(int)((UIntPtr)num4)];
                uint num5 = gms_DECO_PRIM_DRAW_STACK.vtx_num / 3U;
                float num6 = AppMain.FXM_FX32_TO_FLOAT(gms_DECO_PRIM_DRAW_STACK.pos.x);
                float num7 = -AppMain.FXM_FX32_TO_FLOAT(gms_DECO_PRIM_DRAW_STACK.pos.y) + gms_DECO_PRIM_DRAW_STACK.off_y;
                float num8 = AppMain.FXM_FX32_TO_FLOAT(gms_DECO_PRIM_DRAW_STACK.pos.z);
                int num9 = num3;
                AppMain.AOS_TVX_VERTEX[] vtx = gms_DECO_PRIM_DRAW_STACK.vtx;
                int num10 = 0;
                while ( ( long )num10 < ( long )( ( ulong )gms_DECO_PRIM_DRAW_STACK.vtx_num ) )
                {
                    snns_VECTOR.x = vtx[num10].x;
                    snns_VECTOR.y = vtx[num10].y;
                    snns_VECTOR.z = vtx[num10].z;
                    int num11 = num9 + num10;
                    if ( ( gms_DECO_PRIM_DRAW_STACK.disp_flag & 1U ) != 0U )
                    {
                        AppMain.nnTransformVector( ref buffer[num11].Pos, ref snns_MATRIX, ref snns_VECTOR );
                    }
                    else if ( ( gms_DECO_PRIM_DRAW_STACK.disp_flag & 2U ) != 0U )
                    {
                        AppMain.nnTransformVector( ref buffer[num11].Pos, ref snns_MATRIX2, ref snns_VECTOR );
                    }
                    else
                    {
                        buffer[num11].Pos.Assign( snns_VECTOR.x, snns_VECTOR.y, snns_VECTOR.z );
                    }
                    AppMain.NNS_PRIM3D_PCT[] array2 = buffer;
                    int num12 = num11;
                    array2[num12].Pos.x = array2[num12].Pos.x + num6;
                    AppMain.NNS_PRIM3D_PCT[] array3 = buffer;
                    int num13 = num11;
                    array3[num13].Pos.y = array3[num13].Pos.y + num7;
                    AppMain.NNS_PRIM3D_PCT[] array4 = buffer;
                    int num14 = num11;
                    array4[num14].Pos.z = array4[num14].Pos.z + num8;
                    buffer[num11].Tex.u = vtx[num10].u;
                    buffer[num11].Tex.v = vtx[num10].v;
                    buffer[num11].Col = ( vtx[num10].c & num );
                    num10++;
                }
                num3 = num3 + ( int )gms_DECO_PRIM_DRAW_STACK.vtx_num + 2;
                if ( num4 != 0U )
                {
                    int num15 = num9 - 1;
                    buffer[num15] = buffer[num15 + 1];
                }
                if ( ( ulong )num4 != ( ulong )( ( long )( array[( int )( ( UIntPtr )num2 )].stack_num - 1 ) ) )
                {
                    int num15 = num9 + (int)gms_DECO_PRIM_DRAW_STACK.vtx_num - 1;
                    buffer[num15 + 1] = buffer[num15];
                }
            }
            AppMain.ObjDraw3DNNSetCameraEx( 0, 1, array[( int )( ( UIntPtr )num2 )].command );
            AppMain.amMatrixPush( ref snns_MATRIX3 );
            AppMain.ObjDraw3DNNDrawPrimitive( AppMain._AMS_PARAM_DRAW_PRIMITIVE, array[( int )( ( UIntPtr )num2 )].command, 0, 0 );
            AppMain.amMatrixPop();
        }
    }

    // Token: 0x06000401 RID: 1025 RVA: 0x000212DC File Offset: 0x0001F4DC
    private static void gmDecoInitDrawPrimitive()
    {
        AppMain.GMS_DECO_PRIM_DRAW_WORK[] array = AppMain.g_deco_tvx_work;
        for ( int i = 0; i < 16; i++ )
        {
            array[i].tex = null;
            array[i].tex_id = -1;
            array[i].command = uint.MaxValue;
            array[i].all_vtx_num = 0;
            array[i].stack_num = 0;
        }
    }

    // Token: 0x06000402 RID: 1026 RVA: 0x0002132C File Offset: 0x0001F52C
    private static void gmDecoExitMgr()
    {
        if ( AppMain.g_deco_mgr != null )
        {
            if ( AppMain.g_deco_mgr.se_handle != null )
            {
                AppMain.GmSoundStopSE( AppMain.g_deco_mgr.se_handle );
                AppMain.GsSoundFreeSeHandle( AppMain.g_deco_mgr.se_handle );
                AppMain.g_deco_mgr.se_handle = null;
            }
            AppMain.gmDecoDeleteTcbPost();
            AppMain.g_deco_mgr = null;
        }
    }

    // Token: 0x06000403 RID: 1027 RVA: 0x00021380 File Offset: 0x0001F580
    private static void GmDecoSetLightFinalZone()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = 0f;
        nns_VECTOR.y = -0.3f;
        nns_VECTOR.z = -0.4f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_2, ref nns_RGBA, 0.8f, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000404 RID: 1028 RVA: 0x000213F4 File Offset: 0x0001F5F4
    private static void gmDecoDeleteTcbPost()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR.tcb_post != null )
        {
            AppMain.mtTaskClearTcb( gms_DECO_MGR.tcb_post );
            gms_DECO_MGR.tcb_post = null;
        }
    }

    // Token: 0x06000405 RID: 1029 RVA: 0x00021421 File Offset: 0x0001F621
    private static AppMain.GMS_DECO_MGR gmDecoGetMgr()
    {
        return AppMain.g_deco_mgr;
    }

    // Token: 0x06000406 RID: 1030 RVA: 0x00021428 File Offset: 0x0001F628
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModel( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK != null )
        {
            return gms_DECO_WORK.obj_work;
        }
        return null;
    }

    // Token: 0x06000407 RID: 1031 RVA: 0x0002144C File Offset: 0x0001F64C
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelMaterial( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelMaterial(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x06000408 RID: 1032 RVA: 0x0002146C File Offset: 0x0001F66C
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelMotionMaterial( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelMotioinMaterial(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x06000409 RID: 1033 RVA: 0x00021489 File Offset: 0x0001F689
    private static AppMain.OBS_OBJECT_WORK GmDecoInitPrimitive3D( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        return null;
    }

    // Token: 0x0600040A RID: 1034 RVA: 0x0002148C File Offset: 0x0001F68C
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelMotionTouch( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK != null )
        {
            return gms_DECO_WORK.obj_work;
        }
        return null;
    }

    // Token: 0x0600040B RID: 1035 RVA: 0x000214B0 File Offset: 0x0001F6B0
    private static AppMain.OBS_OBJECT_WORK GmDecoInitFall( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitFall(dec_rec, x, y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_DECO_WORK.obj_work;
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = gms_DECO_WORK.obj_3d;
        float frame = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id) - AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
        AppMain.gmDecoAddFallEvent( dec_rec, obj_work.pos.x + obj_work.ofst.x, obj_3d.texlist, frame );
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x0600040C RID: 1036 RVA: 0x00021524 File Offset: 0x0001F724
    private static AppMain.OBS_OBJECT_WORK GmDecoInitEffect( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitEffect(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x0600040D RID: 1037 RVA: 0x00021544 File Offset: 0x0001F744
    private static AppMain.OBS_OBJECT_WORK GmDecoInitEffectBlockAndNext( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitEffectBlockAndNext(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x0600040E RID: 1038 RVA: 0x00021564 File Offset: 0x0001F764
    private static AppMain.OBS_OBJECT_WORK GmDecoInitEffectBlock( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitEffectBlock(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x0600040F RID: 1039 RVA: 0x00021584 File Offset: 0x0001F784
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelEffect( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelEffect(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x06000410 RID: 1040 RVA: 0x000215A4 File Offset: 0x0001F7A4
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelMotionMaterialTouch( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelMotioinMaterial(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_DECO_WORK;
        obs_OBJECT_WORK.flag &= 4294967293U;
        int id = (int)dec_rec.id;
        short num = AppMain.g_gm_deco_rect_size[id][0];
        short num2 = AppMain.g_gm_deco_rect_size[id][1];
        short left = (short)(-num / 2);
        short top = (short)(-num2 / 2);
        short right = (short)(num / 2);
        short bottom = (short)(num2 / 2);
        AppMain.gmDecoSetRect( gms_DECO_WORK, left, top, -500, right, bottom, 500, AppMain.g_gm_deco_func_rect[id] );
        return ( AppMain.OBS_OBJECT_WORK )gms_DECO_WORK;
    }

    // Token: 0x06000411 RID: 1041 RVA: 0x00021634 File Offset: 0x0001F834
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelLoop( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelLoop(dec_rec, x, y, type);
        return gms_DECO_WORK.obj_work;
    }

    // Token: 0x06000412 RID: 1042 RVA: 0x00021651 File Offset: 0x0001F851
    private static void GmDecoInitData( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.gmDecoDataInit();
        AppMain.gmDecoDataSetAmbHeader( amb );
        AppMain.gmDecoInitDrawPrimitive();
    }

    // Token: 0x06000413 RID: 1043 RVA: 0x00021664 File Offset: 0x0001F864
    private static void GmDecoBuildData()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        AppMain.AMS_AMB_HEADER header = null;
        if ( gms_DECO_DATA != null )
        {
            header = AppMain.gmDecoDataGetAmbHeader();
        }
        if ( AppMain.gmDecoIsUseModel( 0 ) )
        {
            string dir;
            gms_DECO_DATA.tvx_model = AppMain.readAMBFile( AppMain.amBindGet( header, 0, out dir ) );
            gms_DECO_DATA.tvx_model_data = new AppMain.TVX_FILE[gms_DECO_DATA.tvx_model.file_num];
            gms_DECO_DATA.tvx_model.dir = dir;
            AppMain.AoTexBuild( gms_DECO_DATA.tvx_tex, AppMain.readAMBFile( AppMain.amBindGet( header, 1 ) ) );
            AppMain.AoTexLoad( gms_DECO_DATA.tvx_tex );
        }
        if ( AppMain.gmDecoIsUseModel( 1 ) )
        {
            string dir;
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 4, out dir));
            ams_AMB_HEADER.dir = dir;
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER2 = AppMain.readAMBFile(AppMain.amBindGet(header, 5, out dir));
            ams_AMB_HEADER2.dir = dir;
            uint draw_flag = 0U;
            gms_DECO_DATA.obj_3d_list_fall = AppMain.GmGameDBuildRegBuildModel( ams_AMB_HEADER, ams_AMB_HEADER2, draw_flag );
        }
    }

    // Token: 0x06000414 RID: 1044 RVA: 0x0002173C File Offset: 0x0001F93C
    private static bool GmDecoCheckLoading()
    {
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        if ( AppMain.gmDecoIsUseModel( 0 ) && !AppMain.AoTexIsLoaded( gms_DECO_DATA.tvx_tex ) )
        {
            return false;
        }
        AppMain.gmDecoIsUseModel( 1 );
        return true;
    }

    // Token: 0x06000415 RID: 1045 RVA: 0x0002176E File Offset: 0x0001F96E
    private static void GmDecoRelease()
    {
        AppMain.GmDecoGlareDataRelease();
        AppMain.gmDecoDataRelease();
        AppMain.gmDecoReleaseMgr();
    }

    // Token: 0x06000416 RID: 1046 RVA: 0x00021780 File Offset: 0x0001F980
    private static void GmDecoFlushData()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        AppMain.AMS_AMB_HEADER header = null;
        if ( gms_DECO_DATA != null )
        {
            header = AppMain.gmDecoDataGetAmbHeader();
        }
        if ( AppMain.gmDecoIsUseModel( 0 ) )
        {
            AppMain.AoTexRelease( gms_DECO_DATA.tvx_tex );
        }
        if ( AppMain.gmDecoIsUseModel( 1 ) )
        {
            string dir;
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.amBindGet(header, 4, out dir));
            ams_AMB_HEADER.dir = dir;
            AppMain.GmGameDBuildRegFlushModel( gms_DECO_DATA.obj_3d_list_fall, ams_AMB_HEADER.file_num );
            gms_DECO_DATA.obj_3d_list_fall = null;
        }
    }

    // Token: 0x06000417 RID: 1047 RVA: 0x000217F8 File Offset: 0x0001F9F8
    private static bool GmDecoCheckFlushing()
    {
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        return !AppMain.gmDecoIsUseModel( 0 ) || AppMain.AoTexIsReleased( gms_DECO_DATA.tvx_tex );
    }

    // Token: 0x06000418 RID: 1048 RVA: 0x00021823 File Offset: 0x0001FA23
    private static AppMain.OBS_OBJECT_WORK GmDecoInitModelMotion( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        return null;
    }

    // Token: 0x06000419 RID: 1049 RVA: 0x00021828 File Offset: 0x0001FA28
    private static void GmDecoSetFrameMotion( int frame, int index )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null )
        {
            gms_DECO_MGR.common_frame_motion[index] = frame;
        }
    }

    // Token: 0x0600041A RID: 1050 RVA: 0x00021847 File Offset: 0x0001FA47
    private static void GmDecoStartEffectFinalBossLight()
    {
        AppMain.GmDecoSetFrameMotion( 1, 2 );
    }

    // Token: 0x0600041B RID: 1051 RVA: 0x00021850 File Offset: 0x0001FA50
    private static AppMain.AMS_RENDER_TARGET GmDecoGetFallRenderTarget()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return null;
        }
        AppMain.AMS_RENDER_TARGET result;
        if ( gms_DECO_MGR.flag_render_front )
        {
            result = gms_DECO_MGR.render_target_front;
        }
        else if ( gms_DECO_MGR.render_target_back != null )
        {
            result = gms_DECO_MGR.render_target_back;
        }
        else
        {
            result = AppMain.gmDecoDrawFallCopyRenderFront();
        }
        return result;
    }

    // Token: 0x0600041C RID: 1052 RVA: 0x00021894 File Offset: 0x0001FA94
    private static void GmDecoSetLoopState()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        int num = 0;
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 4 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 4 ) )
        {
            if ( obs_OBJECT_WORK.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmDecoMainFuncLoop ) )
            {
                if ( num < 2 )
                {
                    gms_DECO_MGR.motion_frame_loop[num] = 1;
                    num++;
                    continue;
                }
                if ( num < 12 )
                {
                    gms_DECO_MGR.motion_frame_loop[num] = obs_OBJECT_WORK.user_timer;
                    num++;
                }
                obs_OBJECT_WORK.flag |= 8U;
                obs_OBJECT_WORK.disp_flag |= 32U;
                AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)obs_OBJECT_WORK;
                AppMain.GMS_EVE_RECORD_DECORATE event_record = gms_DECO_WORK.event_record;
                if ( event_record != null )
                {
                    if ( event_record.pos_x == 255 )
                    {
                        event_record.pos_x = gms_DECO_WORK.event_x;
                        gms_DECO_WORK.event_x = 0;
                    }
                    gms_DECO_WORK.event_record = null;
                }
            }
        }
    }

    // Token: 0x0600041D RID: 1053 RVA: 0x00021968 File Offset: 0x0001FB68
    private static void GmDecoClearLoopState()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        for ( int i = 0; i < gms_DECO_MGR.motion_frame_loop.Length; i++ )
        {
            gms_DECO_MGR.motion_frame_loop[i] = 0;
        }
    }

    // Token: 0x0600041E RID: 1054 RVA: 0x0002199C File Offset: 0x0001FB9C
    private static void GmDecoStartLoop()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        gms_DECO_MGR.state_loop = 1;
    }

    // Token: 0x0600041F RID: 1055 RVA: 0x000219BC File Offset: 0x0001FBBC
    private static void GmDecoEndLoop()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        gms_DECO_MGR.state_loop = 2;
    }

    // Token: 0x06000420 RID: 1056 RVA: 0x000219DA File Offset: 0x0001FBDA
    private static void gmDecoDataInit()
    {
        AppMain.g_deco_data_real.Clear();
        AppMain.g_deco_data = AppMain.g_deco_data_real;
    }

    // Token: 0x06000421 RID: 1057 RVA: 0x000219F0 File Offset: 0x0001FBF0
    private static void gmDecoDataRelease()
    {
        if ( AppMain.g_deco_data != null )
        {
            AppMain.gmDecoDataReleaseAmbHeader();
            AppMain.g_deco_data = null;
        }
    }

    // Token: 0x06000422 RID: 1058 RVA: 0x00021A04 File Offset: 0x0001FC04
    private static AppMain.GMS_DECO_DATA gmDecoDataGetInfo()
    {
        return AppMain.g_deco_data;
    }

    // Token: 0x06000423 RID: 1059 RVA: 0x00021A0C File Offset: 0x0001FC0C
    private static void gmDecoDataSetAmbHeader( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        gms_DECO_DATA.amb_header = amb;
    }

    // Token: 0x06000424 RID: 1060 RVA: 0x00021A28 File Offset: 0x0001FC28
    private static AppMain.AMS_AMB_HEADER gmDecoDataGetAmbHeader()
    {
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        return gms_DECO_DATA.amb_header;
    }

    // Token: 0x06000425 RID: 1061 RVA: 0x00021A44 File Offset: 0x0001FC44
    private static void gmDecoDataReleaseAmbHeader()
    {
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        if ( gms_DECO_DATA.amb_header != null )
        {
            gms_DECO_DATA.amb_header = null;
        }
    }

    // Token: 0x06000426 RID: 1062 RVA: 0x00021A68 File Offset: 0x0001FC68
    private static AppMain.OBS_ACTION3D_NN_WORK[] gmDecoDataGetObj3DList( int id )
    {
        AppMain.GMS_DECO_DATA gms_DECO_DATA = AppMain.gmDecoDataGetInfo();
        AppMain.OBS_ACTION3D_NN_WORK[] result = null;
        switch ( id )
        {
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                result = AppMain.GmGmkWaterSliderGetObj3DList();
                break;
            case 20:
            case 27:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 70:
            case 71:
            case 72:
            case 73:
                result = gms_DECO_DATA.obj_3d_list_fall;
                break;
        }
        return result;
    }

    // Token: 0x06000427 RID: 1063 RVA: 0x00021D78 File Offset: 0x0001FF78
    private static AppMain.AMS_AMB_HEADER gmDecoDataGetMotionHeader( int id )
    {
        AppMain.AMS_AMB_HEADER result = null;
        switch ( id )
        {
            case 7:
            case 8:
            case 9:
            case 11:
            case 12:
            case 13:
                result = ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 834 ).pData;
                break;
            case 17:
            case 26:
            case 111:
            case 114:
            case 170:
            case 171:
            case 172:
            case 174:
            case 175:
            case 176:
            case 178:
            case 179:
            case 183:
                {
                    AppMain.AMS_AMB_HEADER header = AppMain.gmDecoDataGetAmbHeader();
                    if ( AppMain.gmDeco_matMotionHeader == null )
                    {
                        string dir;
                        AppMain.gmDeco_matMotionHeader = AppMain.readAMBFile( AppMain.amBindGet( header, 2, out dir ) );
                        AppMain.gmDeco_matMotionHeader.dir = dir;
                    }
                    result = AppMain.gmDeco_matMotionHeader;
                    break;
                }
        }
        return result;
    }

    // Token: 0x06000428 RID: 1064 RVA: 0x000220BC File Offset: 0x000202BC
    private static AppMain.AMS_AMB_HEADER gmDecoDataGetMatMotionHeader( int id )
    {
        AppMain.AMS_AMB_HEADER result = null;
        switch ( id )
        {
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                result = ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 835 ).pData;
                break;
            case 20:
            case 27:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 70:
            case 71:
            case 72:
            case 73:
            case 170:
            case 171:
            case 172:
            case 174:
            case 175:
            case 176:
            case 178:
            case 179:
            case 183:
                {
                    AppMain.AMS_AMB_HEADER header = AppMain.gmDecoDataGetAmbHeader();
                    if ( AppMain.gmDeco_motionHeader == null )
                    {
                        string dir;
                        AppMain.gmDeco_motionHeader = AppMain.readAMBFile( AppMain.amBindGet( header, 3, out dir ) );
                        AppMain.gmDeco_motionHeader.dir = dir;
                    }
                    result = AppMain.gmDeco_motionHeader;
                    break;
                }
        }
        return result;
    }

    // Token: 0x06000429 RID: 1065 RVA: 0x00022400 File Offset: 0x00020600
    private static void gmDecoCopySetRenderTargetForFront( AppMain.AMS_RENDER_TARGET target )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null )
        {
            gms_DECO_MGR.flag_render_front = true;
            gms_DECO_MGR.render_target_front = target;
        }
    }

    // Token: 0x0600042A RID: 1066 RVA: 0x00022424 File Offset: 0x00020624
    private static void gmDecoCopySetRenderTargetForBack( AppMain.AMS_RENDER_TARGET target )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null )
        {
            gms_DECO_MGR.flag_render_back = true;
            gms_DECO_MGR.render_target_back = target;
        }
    }

    // Token: 0x0600042B RID: 1067 RVA: 0x00022448 File Offset: 0x00020648
    private static AppMain.AMS_RENDER_TARGET gmDecoGetRenderWorkFront()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return null;
        }
        if ( gms_DECO_MGR.render_target_front == null )
        {
            return null;
        }
        return gms_DECO_MGR.render_target_front;
    }

    // Token: 0x0600042C RID: 1068 RVA: 0x00022470 File Offset: 0x00020670
    private static AppMain.AMS_RENDER_TARGET gmDecoGetRenderWorkBack()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return null;
        }
        if ( gms_DECO_MGR.render_target_back == null )
        {
            return null;
        }
        return gms_DECO_MGR.render_target_back;
    }

    // Token: 0x0600042D RID: 1069 RVA: 0x00022498 File Offset: 0x00020698
    private static void gmDecoInitMgr()
    {
        AppMain.g_deco_mgr_real.Clear();
        AppMain.g_deco_mgr = AppMain.g_deco_mgr_real;
        AppMain.gmDecoCreateTcbPost();
    }

    // Token: 0x0600042E RID: 1070 RVA: 0x000224B4 File Offset: 0x000206B4
    private static void gmDecoReleaseMgr()
    {
    }

    // Token: 0x0600042F RID: 1071 RVA: 0x000224B8 File Offset: 0x000206B8
    private static AppMain.MTS_TASK_TCB gmDecoCreateTcbPost()
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        gms_DECO_MGR.tcb_post = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmDecoTcbProcPost ), null, 0U, 0, 5376U, 5, null, "GM DECO POST" );
        return gms_DECO_MGR.tcb_post;
    }

    // Token: 0x06000430 RID: 1072 RVA: 0x000224F7 File Offset: 0x000206F7
    private static void gmDecoTcbProcPost( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmDecoTcbProcPostDT, null, 0, 8U );
    }

    // Token: 0x06000431 RID: 1073 RVA: 0x00022508 File Offset: 0x00020708
    private static void gmDecoTcbProcPostDT( object data )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null )
        {
            gms_DECO_MGR.flag_render_front = false;
            gms_DECO_MGR.flag_render_back = false;
            gms_DECO_MGR.render_target_front = null;
            gms_DECO_MGR.render_target_back = null;
        }
    }

    // Token: 0x06000432 RID: 1074 RVA: 0x0002253C File Offset: 0x0002073C
    private static void gmDecoDraw( AppMain.OBS_OBJECT_WORK obj_work )
    {
        uint num = obj_work.disp_flag;
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)obj_work;
        if ( gms_DECO_WORK.model_tex != null )
        {
            if ( !AppMain.GmMainIsDrawEnable() )
            {
                return;
            }
            if ( ( num & 32U ) != 0U )
            {
                return;
            }
            if ( ( obj_work.user_flag & 2U ) == 0U )
            {
                AppMain.gmDecoSetDrawPrimitive( gms_DECO_WORK.model_index, gms_DECO_WORK.model_tex, obj_work.pos, 0f, gms_DECO_WORK.obj_3d.command_state, num );
            }
            if ( ( obj_work.user_flag & 4U ) != 0U )
            {
                AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)gms_DECO_WORK;
                AppMain.gmDecoSetDrawPrimitive( gms_DECO_SUBMODEL_WORK.sub_model_index, gms_DECO_WORK.model_tex, obj_work.pos, 0f, gms_DECO_WORK.obj_3d.command_state, num );
                return;
            }
        }
        else
        {
            if ( ( obj_work.user_flag & 2U ) == 0U )
            {
                AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
                if ( obj_3d != null )
                {
                    if ( ( obj_work.user_flag & 8U ) != 0U && obj_3d != null && obj_3d.motion != null && obj_3d.motion.mmobject != null )
                    {
                        float num2 = AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
                        float num3 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id);
                        float divisor = num3 - num2;
                        float dividend = AppMain.gmDecoGameSystemGetSyncTime();
                        obj_3d.mat_frame = AppMain.fmod( dividend, divisor );
                        obj_work.disp_flag |= 16U;
                    }
                    if ( obj_3d.command_state != 0U )
                    {
                        AppMain.ObjDraw3DNNSetCameraEx( 0, 1, obj_work.obj_3d.command_state );
                    }
                    AppMain.ObjDrawActionSummary( obj_work );
                    obj_work.disp_flag = num;
                }
            }
            if ( ( obj_work.user_flag & 4U ) != 0U )
            {
                if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
                {
                    num |= 4096U;
                }
                AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK2 = (AppMain.GMS_DECO_SUBMODEL_WORK)obj_work;
                gms_DECO_SUBMODEL_WORK2.obj_3d_sub.command_state = 17U;
                if ( gms_DECO_SUBMODEL_WORK2.obj_3d_sub.command_state != 17U )
                {
                    AppMain.ObjDraw3DNNSetCameraEx( 0, 1, gms_DECO_SUBMODEL_WORK2.obj_3d_sub.command_state );
                }
                AppMain.ObjDrawAction3DNN( gms_DECO_SUBMODEL_WORK2.obj_3d_sub, new AppMain.VecFx32?( obj_work.pos ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref num );
            }
        }
    }

    // Token: 0x06000433 RID: 1075 RVA: 0x00022711 File Offset: 0x00020911
    private static float fmod( float dividend, float divisor )
    {
        return ( Math.Abs( dividend ) - Math.Abs( divisor ) * ( float )Math.Floor( ( double )( Math.Abs( dividend ) / Math.Abs( divisor ) ) ) ) * ( float )Math.Sign( dividend );
    }

    // Token: 0x06000434 RID: 1076 RVA: 0x00022740 File Offset: 0x00020940
    private static void gmDecoDrawFinalShutter3Line( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.user_flag & 2U ) == 0U )
        {
            AppMain.ObjDrawActionSummary( obj_work );
        }
        if ( ( obj_work.user_flag & 4U ) != 0U )
        {
            uint num = obj_work.disp_flag;
            if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
            {
                num |= 4096U;
            }
            AppMain.VecFx32 vecFx = new AppMain.VecFx32(obj_work.pos);
            vecFx.z = -1703936;
            AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)obj_work;
            if ( gms_DECO_SUBMODEL_WORK.obj_3d_sub.command_state != 15U )
            {
                AppMain.ObjDraw3DNNSetCameraEx( 0, 1, gms_DECO_SUBMODEL_WORK.obj_3d_sub.command_state );
            }
            AppMain.ObjDrawAction3DNN( gms_DECO_SUBMODEL_WORK.obj_3d_sub, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref num );
        }
    }

    // Token: 0x06000435 RID: 1077 RVA: 0x000227E4 File Offset: 0x000209E4
    private static void gmDecoDrawFinalShutter5Line( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)obj_work;
        uint num = obj_work.disp_flag;
        num |= 4096U;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( num & 32U ) != 0U )
        {
            return;
        }
        if ( ( obj_work.user_flag & 2U ) == 0U )
        {
            AppMain.gmDecoSetDrawPrimitive( gms_DECO_WORK.model_index, gms_DECO_WORK.model_tex, obj_work.pos, ( float )obj_work.user_timer, gms_DECO_WORK.obj_3d.command_state, num );
        }
        if ( ( obj_work.user_flag & 4U ) != 0U )
        {
            AppMain.VecFx32 pos = new AppMain.VecFx32(obj_work.pos);
            pos.x = obj_work.pos.x;
            pos.y = obj_work.pos.y;
            pos.z = -2228224;
            AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)gms_DECO_WORK;
            AppMain.gmDecoSetDrawPrimitive( gms_DECO_SUBMODEL_WORK.sub_model_index, gms_DECO_WORK.model_tex, pos, ( float )( -( float )obj_work.user_timer / 2 ), gms_DECO_WORK.obj_3d.command_state, num );
        }
    }

    // Token: 0x06000436 RID: 1078 RVA: 0x000228C0 File Offset: 0x00020AC0
    private static AppMain.AMS_RENDER_TARGET gmDecoDrawFallCopyRenderFront()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET;
        if ( num == 0 )
        {
            ams_RENDER_TARGET = AppMain.gmDecoGetRenderWorkFront();
            if ( ams_RENDER_TARGET == null )
            {
                ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
                if ( ams_RENDER_TARGET.width == 0 )
                {
                    return null;
                }
            }
        }
        else
        {
            if ( num != 2 )
            {
                return null;
            }
            ams_RENDER_TARGET = AppMain.GmWaterSurfaceGetRenderTarget();
            if ( ams_RENDER_TARGET != null )
            {
                AppMain.gmDecoCopySetRenderTargetForFront( ams_RENDER_TARGET );
                return ams_RENDER_TARGET;
            }
            ams_RENDER_TARGET = AppMain._am_render_manager.targetp;
            if ( ams_RENDER_TARGET == AppMain._gm_mapFar_render_work )
            {
                ams_RENDER_TARGET = AppMain._am_draw_target;
            }
            else
            {
                ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
            }
        }
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null && !gms_DECO_MGR.flag_render_front )
        {
            AppMain.NNS_RGBA_U8 color = AppMain.g_deco_rendaer_target_color;
            AppMain.amRenderCopyTarget( ams_RENDER_TARGET, color );
            AppMain.gmDecoCopySetRenderTargetForFront( ams_RENDER_TARGET );
        }
        return ams_RENDER_TARGET;
    }

    // Token: 0x06000437 RID: 1079 RVA: 0x0002295C File Offset: 0x00020B5C
    private static AppMain.AMS_RENDER_TARGET gmDecoDrawFallCopyRenderBack()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain.gmDecoGetRenderWorkBack();
        if ( num == 0 )
        {
            if ( ams_RENDER_TARGET == null )
            {
                ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
                if ( ams_RENDER_TARGET.width == 0 )
                {
                    return null;
                }
            }
        }
        else
        {
            if ( num != 2 )
            {
                return null;
            }
            ams_RENDER_TARGET = AppMain._am_render_manager.targetp;
            if ( ams_RENDER_TARGET == AppMain._gm_mapFar_render_work )
            {
                ams_RENDER_TARGET = AppMain._am_draw_target;
            }
            else
            {
                ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
            }
        }
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null && !gms_DECO_MGR.flag_render_back )
        {
            AppMain.NNS_RGBA_U8 color = AppMain.g_deco_rendaer_target_color;
            AppMain.amRenderCopyTarget( ams_RENDER_TARGET, color );
            AppMain.gmDecoCopySetRenderTargetForBack( ams_RENDER_TARGET );
        }
        return ams_RENDER_TARGET;
    }

    // Token: 0x06000438 RID: 1080 RVA: 0x000229E4 File Offset: 0x00020BE4
    private static void gmDecoDrawFallRender( AppMain.AMS_RENDER_TARGET render_target, AppMain.NNS_MATRIX proj_mtx )
    {
    }

    // Token: 0x06000439 RID: 1081 RVA: 0x000229E6 File Offset: 0x00020BE6
    private static void gmDecoDrawFallFrontUserFunc( object data )
    {
        AppMain.amDrawGetProjectionMatrix();
    }

    // Token: 0x0600043A RID: 1082 RVA: 0x000229F0 File Offset: 0x00020BF0
    private static void gmDecoDrawFallBackUserFunc( object data )
    {
        AppMain.NNS_MATRIX proj_mtx = AppMain.amDrawGetProjectionMatrix();
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain.gmDecoDrawFallCopyRenderBack();
        if ( ams_RENDER_TARGET != null )
        {
            AppMain.gmDecoDrawFallRender( ams_RENDER_TARGET, proj_mtx );
        }
    }

    // Token: 0x0600043B RID: 1083 RVA: 0x00022A13 File Offset: 0x00020C13
    private static void gmDecoDrawFallFront( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, obj_work.obj_3d.command_state );
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmDecoDrawFallFrontUserFunc, null, 0, obj_work.obj_3d.command_state );
        AppMain.gmDecoDraw( obj_work );
    }

    // Token: 0x0600043C RID: 1084 RVA: 0x00022A4D File Offset: 0x00020C4D
    public static void gmDecoDrawFallBack( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, obj_work.obj_3d.command_state );
        AppMain.ObjDraw3DNNUserFunc( AppMain._gmDecoDrawFallBackUserFunc, null, 0, obj_work.obj_3d.command_state );
        AppMain.gmDecoDraw( obj_work );
    }

    // Token: 0x0600043D RID: 1085 RVA: 0x00022A88 File Offset: 0x00020C88
    private static AppMain.GMS_DECO_WORK gmDecoLoadObj( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, AppMain.TaskWorkFactoryDelegate work_size, int pos_x, int pos_y, AppMain.MPP_VOID_OBS_OBJECT_WORK main_func, AppMain.MPP_VOID_OBS_OBJECT_WORK move_func, AppMain.MPP_VOID_OBS_OBJECT_WORK out_func, AppMain.GSF_TASK_PROCEDURE dest_func )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)AppMain.OBM_OBJECT_TASK_DETAIL_INIT(5376, 5, 0, 0, work_size, "DECO OBJ");
        AppMain.OBS_OBJECT_WORK obj_work = gms_DECO_WORK.obj_work;
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, dest_func );
        obj_work.obj_type = 4;
        obj_work.pos.x = pos_x + AppMain.g_gm_deco_pos[( int )dec_rec.id][0];
        obj_work.pos.y = pos_y + AppMain.g_gm_deco_pos[( int )dec_rec.id][1];
        obj_work.pos.z = AppMain.g_gm_deco_pos[( int )dec_rec.id][2];
        obj_work.dir.z = AppMain.g_gm_deco_rot_z[( int )dec_rec.id];
        obj_work.move_flag |= 8448U;
        obj_work.ppFunc = main_func;
        obj_work.ppMove = move_func;
        obj_work.ppOut = out_func;
        obj_work.view_out_ofst = ( short )( AppMain.g_gm_decorate_size_tbl[( int )dec_rec.id] + 16 + 32 + 16 );
        obj_work.ppViewCheck = new AppMain.OBS_OBJECT_WORK_Delegate3( AppMain.ObjObjectViewOutCheck );
        gms_DECO_WORK.event_record = dec_rec;
        gms_DECO_WORK.event_x = dec_rec.pos_x;
        dec_rec.pos_x = byte.MaxValue;
        return gms_DECO_WORK;
    }

    // Token: 0x0600043E RID: 1086 RVA: 0x00022BA8 File Offset: 0x00020DA8
    private static AppMain.GMS_DECO_WORK gmDecoLoadModel( AppMain.GMS_DECO_WORK deco_work, AppMain.OBS_ACTION3D_NN_WORK obj_3d_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = deco_work.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, obj_3d_work, deco_work.obj_3d );
        deco_work.obj_3d.drawflag |= 32U;
        return deco_work;
    }

    // Token: 0x0600043F RID: 1087 RVA: 0x00022BE0 File Offset: 0x00020DE0
    private static void gmDecoLoadMotion( AppMain.GMS_DECO_WORK deco_work, int motion_index, AppMain.AMS_AMB_HEADER motion_amb )
    {
        AppMain.OBS_OBJECT_WORK obj_work = deco_work.obj_work;
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, null, null, motion_index, motion_amb );
    }

    // Token: 0x06000440 RID: 1088 RVA: 0x00022C00 File Offset: 0x00020E00
    private static void gmDecoLoadMatMotion( AppMain.GMS_DECO_WORK deco_work, int motion_index, AppMain.AMS_AMB_HEADER motion_amb )
    {
        AppMain.OBS_OBJECT_WORK obj_work = deco_work.obj_work;
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, 0, null, null, motion_index, motion_amb );
    }

    // Token: 0x06000441 RID: 1089 RVA: 0x00022C20 File Offset: 0x00020E20
    private static void gmDecoSetRect( AppMain.GMS_DECO_WORK deco_work, short left, short top, short back, short right, short bottom, short front, AppMain.OBS_RECT_WORK_Delegate1 func )
    {
        AppMain.OBS_OBJECT_WORK obj_work = deco_work.obj_work;
        AppMain.ArrayPointer<AppMain.OBS_RECT_WORK> arrayPointer = new AppMain.ArrayPointer<AppMain.OBS_RECT_WORK>(deco_work.rect_work, 0);
        AppMain.ObjObjectGetRectBuf( obj_work, arrayPointer, 1 );
        AppMain.ObjRectGroupSet( arrayPointer, 1, 1 );
        AppMain.ObjRectAtkSet( arrayPointer, 0, 0 );
        AppMain.ObjRectDefSet( arrayPointer, 65534, 0 );
        ( ~arrayPointer ).parent_obj = obj_work;
        ( ~arrayPointer ).ppDef = func;
        ( ~arrayPointer ).ppHit = null;
        ( ~arrayPointer ).flag |= 1152U;
        AppMain.ObjRectWorkZSet( arrayPointer, left, top, back, right, bottom, front );
    }

    // Token: 0x06000442 RID: 1090 RVA: 0x00022CC8 File Offset: 0x00020EC8
    private static void gmDecoMainFuncMotionCount( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer--;
        if ( 0 < obj_work.user_timer )
        {
            return;
        }
        obj_work.obj_3d.frame[0] = 0f;
        obj_work.user_timer = 0;
        obj_work.disp_flag |= 16U;
        obj_work.ppFunc = null;
    }

    // Token: 0x06000443 RID: 1091 RVA: 0x00022D1C File Offset: 0x00020F1C
    private static void gmDecoMainFuncDecreaseMotionSpeed( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer--;
        if ( obj_work.user_timer <= 0 )
        {
            obj_work.user_timer = 0;
            obj_work.obj_3d.speed[0] = 0f;
            obj_work.ppFunc = null;
            return;
        }
        float num = (float)obj_work.user_timer;
        float num2 = obj_work.obj_3d.speed[0] / num;
        obj_work.obj_3d.speed[0] -= num2;
        obj_work.obj_3d.frame[0] += obj_work.obj_3d.speed[0];
        float num3 = AppMain.amMotionGetStartFrame(obj_work.obj_3d.motion, obj_work.obj_3d.act_id[0]);
        float num4 = AppMain.amMotionGetEndFrame(obj_work.obj_3d.motion, obj_work.obj_3d.act_id[0]);
        if ( obj_work.obj_3d.frame[0] < num3 )
        {
            obj_work.obj_3d.frame[0] = num4;
            return;
        }
        if ( obj_work.obj_3d.frame[0] > num4 )
        {
            obj_work.obj_3d.frame[0] = num3;
        }
    }

    // Token: 0x06000444 RID: 1092 RVA: 0x00022E40 File Offset: 0x00021040
    private static void gmDecoMainFuncMotionApplyCommonFrame( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        AppMain.OBS_ACTION3D_NN_WORK[] array = new AppMain.OBS_ACTION3D_NN_WORK[2];
        AppMain.OBS_ACTION3D_NN_WORK[] array2 = array;
        array2[0] = obj_work.obj_3d;
        if ( ( obj_work.user_flag & 4U ) != 0U )
        {
            AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)obj_work;
            array2[1] = gms_DECO_SUBMODEL_WORK.obj_3d_sub;
        }
        int num = Convert.ToInt32(obj_work.user_work);
        int num2 = 0;
        if ( ( obj_work.user_flag & 32U ) != 0U )
        {
            num2 = 1;
        }
        int num3 = 0;
        while ( 2 > num3 )
        {
            AppMain.OBS_ACTION3D_NN_WORK obs_ACTION3D_NN_WORK = array2[num3];
            if ( obs_ACTION3D_NN_WORK != null && obs_ACTION3D_NN_WORK.motion != null )
            {
                if ( obs_ACTION3D_NN_WORK.motion.mtnbuf[0] != null )
                {
                    obs_ACTION3D_NN_WORK.frame[0] = ( float )( gms_DECO_MGR.common_frame_motion[num2] + num );
                    float num4 = AppMain.amMotionGetStartFrame(obs_ACTION3D_NN_WORK.motion, obs_ACTION3D_NN_WORK.act_id[0]);
                    float num5 = AppMain.amMotionGetEndFrame(obs_ACTION3D_NN_WORK.motion, obs_ACTION3D_NN_WORK.act_id[0]);
                    if ( obs_ACTION3D_NN_WORK.frame[0] < num4 )
                    {
                        obs_ACTION3D_NN_WORK.frame[0] = num4;
                    }
                    else if ( obs_ACTION3D_NN_WORK.frame[0] >= num5 )
                    {
                        obs_ACTION3D_NN_WORK.frame[0] = num5 - 1f;
                    }
                }
                if ( obs_ACTION3D_NN_WORK.motion.mmobject != null )
                {
                    obs_ACTION3D_NN_WORK.mat_frame = ( float )( gms_DECO_MGR.common_frame_motion[num2] + num );
                    float num6 = AppMain.amMotionMaterialGetStartFrame(obs_ACTION3D_NN_WORK.motion, obs_ACTION3D_NN_WORK.mat_act_id);
                    float num7 = AppMain.amMotionMaterialGetEndFrame(obs_ACTION3D_NN_WORK.motion, obs_ACTION3D_NN_WORK.mat_act_id);
                    if ( obs_ACTION3D_NN_WORK.mat_frame < num6 )
                    {
                        obs_ACTION3D_NN_WORK.mat_frame = num6;
                    }
                    else if ( obs_ACTION3D_NN_WORK.mat_frame >= num7 )
                    {
                        obs_ACTION3D_NN_WORK.mat_frame = num7 - 1f;
                    }
                }
            }
            num3++;
        }
    }

    // Token: 0x06000445 RID: 1093 RVA: 0x00022FD8 File Offset: 0x000211D8
    private static void gmDecoMainFuncMotionCheckCommonFrame( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( AppMain.g_gm_main_system.game_flag & 4096U ) != 0U )
        {
            return;
        }
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        if ( obj_work.user_timer < 254 )
        {
            obj_work.user_timer++;
            obj_work.disp_flag &= 4294967279U;
        }
        int num = 0;
        if ( ( obj_work.user_flag & 32U ) != 0U )
        {
            num = 1;
        }
        if ( gms_DECO_MGR.common_frame_motion[num] == 0 )
        {
            obj_work.flag &= 4294967279U;
            obj_work.user_timer = 0;
            return;
        }
        obj_work.flag |= 16U;
    }

    // Token: 0x06000446 RID: 1094 RVA: 0x0002306C File Offset: 0x0002126C
    private static void gmDecoMainFuncLoop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        int num = 0;
        if ( ( obj_work.user_flag & 32U ) != 0U )
        {
            num = 1;
        }
        if ( gms_DECO_MGR.state_loop == 0 )
        {
            obj_work.flag |= 16U;
        }
        else if ( gms_DECO_MGR.state_loop == 1 )
        {
            AppMain.gmDecoMainFuncMotionCheckCommonFrame( obj_work );
            obj_work.flag &= 4294967279U;
        }
        else
        {
            AppMain.gmDecoMainFuncMotionCheckCommonFrame( obj_work );
        }
        if ( obj_work.user_timer != 0 && gms_DECO_MGR.common_frame_motion[num] != 0 && gms_DECO_MGR.common_frame_motion[num] + 1 >= obj_work.user_timer )
        {
            gms_DECO_MGR.common_frame_motion[num] = obj_work.user_timer;
        }
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)obj_work;
        int id = (int)gms_DECO_WORK.event_record.id;
        if ( gms_DECO_MGR.se_handle != null )
        {
            if ( gms_DECO_MGR.common_frame_motion[num] > Convert.ToInt32( obj_work.user_work ) )
            {
                AppMain.GmSoundStopSE( gms_DECO_MGR.se_handle );
                AppMain.GsSoundFreeSeHandle( gms_DECO_MGR.se_handle );
                gms_DECO_MGR.se_handle = null;
            }
        }
        else if ( gms_DECO_MGR.state_loop == 1 && gms_DECO_MGR.common_frame_motion[num] < Convert.ToInt32( obj_work.user_work ) && id != 0 )
        {
            gms_DECO_MGR.se_handle = AppMain.GsSoundAllocSeHandle();
            int num2 = id;
            if ( num2 == 183 )
            {
                AppMain.GmSoundPlaySE( "Shutter1", gms_DECO_MGR.se_handle );
            }
        }
        if ( obj_work.user_timer == Convert.ToInt32( obj_work.user_work ) && id != 0 )
        {
            int num3 = id;
            if ( num3 != 183 )
            {
                return;
            }
            AppMain.GmSoundPlaySE( "Shutter2" );
        }
    }

    // Token: 0x06000447 RID: 1095 RVA: 0x000231C8 File Offset: 0x000213C8
    private static void gmDecoMainFuncEffectCheckCommonFrame( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR == null )
        {
            return;
        }
        int num = 0;
        if ( ( obj_work.user_flag & 32U ) != 0U )
        {
            num = 1;
        }
        else if ( ( obj_work.user_flag & 64U ) != 0U )
        {
            num = 2;
        }
        if ( gms_DECO_MGR.common_frame_motion[num] == 0 )
        {
            obj_work.disp_flag |= 4128U;
            return;
        }
        obj_work.disp_flag &= 4294963167U;
    }

    // Token: 0x06000448 RID: 1096 RVA: 0x0002322C File Offset: 0x0002142C
    private static void gmDecoTcbDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.gmDecoDelFallEvent( gms_DECO_WORK.event_record, gms_DECO_WORK.obj_work.pos.x + gms_DECO_WORK.obj_work.ofst.x );
        if ( ( gms_DECO_WORK.obj_work.user_flag & 4U ) != 0U && gms_DECO_WORK.model_tex == null )
        {
            AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)gms_DECO_WORK;
            AppMain.ObjAction3dNNMotionRelease( gms_DECO_SUBMODEL_WORK.obj_3d_sub );
        }
        AppMain.GMS_EVE_RECORD_DECORATE event_record = gms_DECO_WORK.event_record;
        if ( event_record != null )
        {
            if ( event_record.pos_x == 255 )
            {
                event_record.pos_x = gms_DECO_WORK.event_x;
                gms_DECO_WORK.event_x = 0;
            }
            gms_DECO_WORK.event_record = null;
        }
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06000449 RID: 1097 RVA: 0x000232D4 File Offset: 0x000214D4
    private static void gmDecoRectFuncChangeMotionCount( AppMain.OBS_RECT_WORK own_rect_work, AppMain.OBS_RECT_WORK target_rect_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect_work.parent_obj;
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)parent_obj;
        uint id = (uint)gms_DECO_WORK.event_record.id;
        parent_obj.user_timer = AppMain.g_gm_deco_user_timer[( int )( ( UIntPtr )id )];
        float num = AppMain.amMotionGetStartFrame(parent_obj.obj_3d.motion, parent_obj.obj_3d.act_id[0]);
        float num2 = AppMain.amMotionGetEndFrame(parent_obj.obj_3d.motion, parent_obj.obj_3d.act_id[0]);
        float num3 = (num2 - num) * (float)Convert.ToInt32(parent_obj.user_work);
        parent_obj.obj_3d.speed[0] = num3 / ( float )parent_obj.user_timer;
        parent_obj.disp_flag &= 4294967279U;
        parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmDecoMainFuncMotionCount );
    }

    // Token: 0x0600044A RID: 1098 RVA: 0x00023394 File Offset: 0x00021594
    private static void gmDecoRectFuncChangeDecreaseMotionSpeed( AppMain.OBS_RECT_WORK own_rect_work, AppMain.OBS_RECT_WORK target_rect_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect_work.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect_work.parent_obj;
        float num;
        if ( ( parent_obj2.move_flag & 32768U ) != 0U )
        {
            num = AppMain.FX_FX32_TO_F32( parent_obj2.spd.x );
        }
        else
        {
            num = AppMain.FX_FX32_TO_F32( parent_obj2.spd_m );
        }
        num = num * ( float )Convert.ToInt32( parent_obj.user_work ) / 10f;
        parent_obj.obj_3d.speed[0] = num;
        if ( ( parent_obj.user_flag & 16U ) == 0U )
        {
            parent_obj.obj_3d.speed[0] = AppMain.MTM_MATH_ABS( parent_obj.obj_3d.speed[0] );
        }
        parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmDecoMainFuncDecreaseMotionSpeed );
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)parent_obj;
        uint id = (uint)gms_DECO_WORK.event_record.id;
        parent_obj.user_timer = AppMain.g_gm_deco_user_timer[( int )( ( UIntPtr )id )];
    }

    // Token: 0x0600044B RID: 1099 RVA: 0x00023468 File Offset: 0x00021668
    private static void gmDecoRectFuncChangeMotionCommonFrame( AppMain.OBS_RECT_WORK own_rect_work, AppMain.OBS_RECT_WORK target_rect_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect_work.parent_obj;
        parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmDecoMainFuncMotionCheckCommonFrame );
        parent_obj.flag |= 2U;
    }

    // Token: 0x0600044C RID: 1100 RVA: 0x0002349C File Offset: 0x0002169C
    private static void gmDecoSetLightSpecial( AppMain.OBS_OBJECT_WORK obj_work, int id )
    {
    }

    // Token: 0x0600044D RID: 1101 RVA: 0x000234A0 File Offset: 0x000216A0
    private static void gmDecoAdjustIPhone( AppMain.OBS_OBJECT_WORK obj_work, int id )
    {
        if ( obj_work == null )
        {
            return;
        }
        if ( id != 71 )
        {
            return;
        }
        ushort stage_id = AppMain.g_gs_main_sys_info.stage_id;
        if ( stage_id != 8 )
        {
            return;
        }
        float num;
        float num2;
        if ( obj_work.pos.x > AppMain.FX_F32_TO_FX32( 1024f ) && obj_work.pos.x < AppMain.FX_F32_TO_FX32( 1280f ) )
        {
            num = 576f;
            num2 = 54.4f;
        }
        else if ( obj_work.pos.x > AppMain.FX_F32_TO_FX32( 3008f ) && obj_work.pos.x < AppMain.FX_F32_TO_FX32( 3072f ) )
        {
            num = 768f;
            num2 = 40f;
        }
        else
        {
            if ( obj_work.pos.x <= AppMain.FX_F32_TO_FX32( 6848f ) || obj_work.pos.x >= AppMain.FX_F32_TO_FX32( 6976f ) || obj_work.pos.y <= AppMain.FX_F32_TO_FX32( 1213f ) )
            {
                return;
            }
            num = 1213f;
            num2 = 61f;
        }
        obj_work.scale.y = AppMain.FX_F32_TO_FX32( num2 / 64f );
        float num3 = AppMain.FX_FX32_TO_F32(obj_work.pos.y) - num;
        num3 /= 64f;
        obj_work.pos.y = AppMain.FX_F32_TO_FX32( num + num3 * num2 );
    }

    // Token: 0x0600044E RID: 1102 RVA: 0x000235F0 File Offset: 0x000217F0
    private static AppMain.GMS_DECO_WORK gmDecoInitNomodel( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type, AppMain.TaskWorkFactoryDelegate work_size )
    {
        int id = (int)dec_rec.id;
        if ( ( AppMain.g_gm_deco_user_flag[id] & 1U ) != 0U && ( AppMain.g_gs_main_sys_info.game_flag & 32U ) == 0U )
        {
            dec_rec.pos_x = byte.MaxValue;
            return null;
        }
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoLoadObj(dec_rec, work_size, x, y, AppMain.g_gm_deco_func_main[id], AppMain.g_gm_deco_func_move[id], AppMain.g_gm_deco_func_out[id], AppMain.g_gm_deco_func_dest[id]);
        gms_DECO_WORK.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        gms_DECO_WORK.obj_work.user_work = AppMain.g_gm_deco_user_work[id];
        gms_DECO_WORK.obj_work.user_timer = AppMain.g_gm_deco_user_timer[id];
        gms_DECO_WORK.obj_work.user_flag = AppMain.g_gm_deco_user_flag[id];
        gms_DECO_WORK.obj_work.flag |= 2U;
        if ( ( gms_DECO_WORK.obj_work.disp_flag & 1U ) != 0U )
        {
            gms_DECO_WORK.obj_work.scale.x = -4096;
            gms_DECO_WORK.obj_work.disp_flag &= 4294967294U;
        }
        if ( ( gms_DECO_WORK.obj_work.disp_flag & 2U ) != 0U )
        {
            gms_DECO_WORK.obj_work.scale.y = -4096;
            gms_DECO_WORK.obj_work.disp_flag &= 4294967293U;
        }
        if ( ( gms_DECO_WORK.obj_work.user_flag & 512U ) != 0U )
        {
            gms_DECO_WORK.obj_work.flag |= 16U;
        }
        return gms_DECO_WORK;
    }

    // Token: 0x0600044F RID: 1103 RVA: 0x0002375C File Offset: 0x0002195C
    private static AppMain.GMS_DECO_WORK gmDecoInitModel( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        int id = (int)dec_rec.id;
        int num = -1;
        AppMain.TaskWorkFactoryDelegate work_size;
        if ( ( AppMain.g_gm_deco_user_flag[id] & 4U ) != 0U )
        {
            work_size = ( () => new AppMain.GMS_DECO_SUBMODEL_WORK() );
            num = AppMain.g_gm_deco_model_index[id][1];
        }
        else
        {
            work_size = ( () => new AppMain.GMS_DECO_WORK() );
        }
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitNomodel(dec_rec, x, y, type, work_size);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.OBS_ACTION3D_NN_WORK[] array = AppMain.gmDecoDataGetObj3DList(id);
        if ( array == null )
        {
            gms_DECO_WORK.model_tex = AppMain.gmDecoDataGetInfo().tvx_tex;
            int model_index = AppMain.g_gm_deco_model_index[id][0];
            gms_DECO_WORK.obj_3d.command_state = AppMain.g_gm_deco_command_state[id];
            gms_DECO_WORK.model_index = model_index;
            if ( num != -1 )
            {
                AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)gms_DECO_WORK;
                gms_DECO_SUBMODEL_WORK.obj_3d_sub.command_state = AppMain.g_gm_deco_command_state[id];
                gms_DECO_SUBMODEL_WORK.sub_model_index = num;
            }
            gms_DECO_WORK.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        }
        else
        {
            int num2 = AppMain.g_gm_deco_model_index[id][0];
            if ( num2 != -1 )
            {
                AppMain.gmDecoLoadModel( gms_DECO_WORK, array[num2] );
                gms_DECO_WORK.obj_3d.command_state = AppMain.g_gm_deco_command_state[id];
            }
            if ( num != -1 )
            {
                AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK2 = (AppMain.GMS_DECO_SUBMODEL_WORK)gms_DECO_WORK;
                AppMain.ObjCopyAction3dNNModel( array[num], gms_DECO_SUBMODEL_WORK2.obj_3d_sub );
                gms_DECO_SUBMODEL_WORK2.obj_3d_sub.drawflag |= 32U;
                if ( ( AppMain.g_gm_deco_user_flag[id] & 128U ) != 0U )
                {
                    gms_DECO_SUBMODEL_WORK2.obj_3d_sub.use_light_flag &= 4294967294U;
                    gms_DECO_SUBMODEL_WORK2.obj_3d_sub.use_light_flag |= 4U;
                }
                gms_DECO_SUBMODEL_WORK2.obj_3d_sub.command_state = AppMain.g_gm_deco_command_state[id];
            }
            gms_DECO_WORK.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
            if ( ( gms_DECO_WORK.obj_work.disp_flag & 1U ) != 0U )
            {
                gms_DECO_WORK.obj_work.scale.x = -4096;
                gms_DECO_WORK.obj_work.disp_flag &= 4294967294U;
            }
            if ( ( gms_DECO_WORK.obj_work.disp_flag & 2U ) != 0U )
            {
                gms_DECO_WORK.obj_work.scale.y = -4096;
                gms_DECO_WORK.obj_work.disp_flag &= 4294967293U;
            }
        }
        AppMain.gmDecoSetLightSpecial( gms_DECO_WORK.obj_work, id );
        return gms_DECO_WORK;
    }

    // Token: 0x06000450 RID: 1104 RVA: 0x000239A0 File Offset: 0x00021BA0
    private static void gmDecoInitMotion( AppMain.GMS_DECO_WORK deco_work )
    {
        int id = (int)deco_work.event_record.id;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.gmDecoDataGetMotionHeader(id);
        int num = AppMain.g_gm_deco_node_motion_index[id][0];
        if ( num != -1 )
        {
            AppMain.gmDecoLoadMotion( deco_work, num, ams_AMB_HEADER );
            AppMain.OBS_OBJECT_WORK obj_work = deco_work.obj_work;
            uint disp_flag = obj_work.disp_flag;
            AppMain.ObjDrawObjectActionSet( obj_work, 0 );
            obj_work.disp_flag = disp_flag;
        }
        if ( ( AppMain.g_gm_deco_user_flag[id] & 4U ) != 0U )
        {
            int num2 = AppMain.g_gm_deco_node_motion_index[id][1];
            if ( num2 != -1 )
            {
                AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)deco_work;
                AppMain.ObjAction3dNNMotionLoad( gms_DECO_SUBMODEL_WORK.obj_3d_sub, 0, false, null, null, num2, ams_AMB_HEADER );
            }
        }
    }

    // Token: 0x06000451 RID: 1105 RVA: 0x00023A2C File Offset: 0x00021C2C
    private static AppMain.GMS_DECO_WORK gmDecoInitModelMotion( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.gmDecoInitMotion( gms_DECO_WORK );
        return gms_DECO_WORK;
    }

    // Token: 0x06000452 RID: 1106 RVA: 0x00023A50 File Offset: 0x00021C50
    private static AppMain.GMS_DECO_WORK gmDecoInitModelMotionTouch( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelMotion(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_DECO_WORK;
        obs_OBJECT_WORK.flag &= 4294967293U;
        int id = (int)dec_rec.id;
        short num = AppMain.g_gm_deco_rect_size[id][0];
        short num2 = AppMain.g_gm_deco_rect_size[id][1];
        short left = (short)(-num / 2);
        short top = (short)(-num2 / 2);
        short right = (short)(num / 2);
        short bottom = (short)(num2 / 2);
        AppMain.gmDecoSetRect( gms_DECO_WORK, left, top, -500, right, bottom, 500, AppMain.g_gm_deco_func_rect[id] );
        return gms_DECO_WORK;
    }

    // Token: 0x06000453 RID: 1107 RVA: 0x00023ADC File Offset: 0x00021CDC
    private static void gmDecoInitMaterial( AppMain.GMS_DECO_WORK deco_work )
    {
        int id = (int)deco_work.event_record.id;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.gmDecoDataGetMatMotionHeader(id);
        int num = AppMain.g_gm_deco_mat_motion_index[id][0];
        if ( num != -1 )
        {
            AppMain.gmDecoLoadMatMotion( deco_work, num, ams_AMB_HEADER );
            AppMain.OBS_OBJECT_WORK obj_work = deco_work.obj_work;
            uint disp_flag = obj_work.disp_flag;
            AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
            obj_work.disp_flag = disp_flag;
        }
        if ( ( AppMain.g_gm_deco_user_flag[id] & 4U ) != 0U )
        {
            int num2 = AppMain.g_gm_deco_mat_motion_index[id][1];
            if ( num2 != -1 )
            {
                AppMain.GMS_DECO_SUBMODEL_WORK gms_DECO_SUBMODEL_WORK = (AppMain.GMS_DECO_SUBMODEL_WORK)deco_work;
                AppMain.ObjAction3dNNMaterialMotionLoad( gms_DECO_SUBMODEL_WORK.obj_3d_sub, 0, null, null, num2, ams_AMB_HEADER );
            }
        }
    }

    // Token: 0x06000454 RID: 1108 RVA: 0x00023B68 File Offset: 0x00021D68
    private static AppMain.GMS_DECO_WORK gmDecoInitModelMaterial( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.gmDecoInitMaterial( gms_DECO_WORK );
        return gms_DECO_WORK;
    }

    // Token: 0x06000455 RID: 1109 RVA: 0x00023B8C File Offset: 0x00021D8C
    private static AppMain.GMS_DECO_WORK gmDecoInitModelMotioinMaterial( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.gmDecoInitMotion( gms_DECO_WORK );
        AppMain.gmDecoInitMaterial( gms_DECO_WORK );
        return gms_DECO_WORK;
    }

    // Token: 0x06000456 RID: 1110 RVA: 0x00023BB8 File Offset: 0x00021DB8
    private static AppMain.GMS_DECO_WORK gmDecoInitModelMotionMaterialTouch( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelMotioinMaterial(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_DECO_WORK;
        obs_OBJECT_WORK.flag &= 4294967293U;
        int id = (int)dec_rec.id;
        short num = AppMain.g_gm_deco_rect_size[id][0];
        short num2 = AppMain.g_gm_deco_rect_size[id][1];
        short left = (short)(-num / 2);
        short top = (short)(-num2 / 2);
        short right = (short)(num / 2);
        short bottom = (short)(num2 / 2);
        AppMain.gmDecoSetRect( gms_DECO_WORK, left, top, -500, right, bottom, 500, AppMain.g_gm_deco_func_rect[id] );
        return gms_DECO_WORK;
    }

    // Token: 0x06000457 RID: 1111 RVA: 0x00023C44 File Offset: 0x00021E44
    private static AppMain.GMS_DECO_WORK gmDecoInitModelLoop( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        AppMain.GMS_DECO_MGR gms_DECO_MGR = AppMain.gmDecoGetMgr();
        if ( gms_DECO_MGR != null )
        {
            if ( gms_DECO_MGR.state_loop == 0 )
            {
                AppMain.gmDecoMainFuncLoop( gms_DECO_WORK.obj_work );
            }
            else if ( gms_DECO_MGR.state_loop == 1 )
            {
                int num = 0;
                while ( 12 > num )
                {
                    if ( gms_DECO_MGR.motion_frame_loop[num] != 0 )
                    {
                        gms_DECO_WORK.obj_work.user_timer = gms_DECO_MGR.motion_frame_loop[num];
                        gms_DECO_MGR.motion_frame_loop[num] = 0;
                        AppMain.gmDecoMainFuncLoop( gms_DECO_WORK.obj_work );
                        break;
                    }
                    num++;
                }
            }
            else
            {
                AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
                if ( gms_DECO_WORK.obj_work.pos.x < gms_PLAYER_WORK.obj_work.pos.x )
                {
                    gms_DECO_WORK.obj_work.user_timer = 254;
                }
                else
                {
                    int num2 = 0;
                    if ( ( gms_DECO_WORK.obj_work.user_flag & 32U ) != 0U )
                    {
                        num2 = 1;
                    }
                    if ( 16 < gms_DECO_MGR.common_frame_motion[num2] )
                    {
                        gms_DECO_WORK.obj_work.user_timer = gms_DECO_MGR.common_frame_motion[num2] - 16;
                    }
                }
                AppMain.gmDecoMainFuncLoop( gms_DECO_WORK.obj_work );
            }
        }
        return gms_DECO_WORK;
    }

    // Token: 0x06000458 RID: 1112 RVA: 0x00023D60 File Offset: 0x00021F60
    private static AppMain.GMS_DECO_WORK gmDecoInitModelEffect( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModel(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        int id = (int)dec_rec.id;
        int efct_zone_idx = AppMain.g_gm_deco_model_index[id][1];
        int zone_no = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(gms_DECO_WORK.obj_work, zone_no, efct_zone_idx);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = AppMain.g_gm_deco_rot_z[( int )dec_rec.id];
        int num = (int)AppMain.g_gm_deco_user_work[id];
        num <<= 16;
        num >>= 16;
        int num2 = (int)AppMain.g_gm_deco_user_work[id];
        num2 >>= 16;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = gms_DECO_WORK.obj_work.pos.x + num * 4096;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = gms_DECO_WORK.obj_work.pos.y + num2 * 4096;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = gms_DECO_WORK.obj_work.pos.z + 131072;
        if ( gms_DECO_WORK.obj_3d.command_state == 17U )
        {
            gms_EFFECT_3DES_WORK.obj_3des.command_state = 17U;
        }
        return gms_DECO_WORK;
    }

    // Token: 0x06000459 RID: 1113 RVA: 0x00023EA8 File Offset: 0x000220A8
    private static AppMain.GMS_DECO_WORK gmDecoInitPrimitive3D( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        int id = (int)dec_rec.id;
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitNomodel(dec_rec, x, y, type, () => new AppMain.GMS_DECO_WORK());
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        gms_DECO_WORK.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        return gms_DECO_WORK;
    }

    // Token: 0x0600045A RID: 1114 RVA: 0x00023F04 File Offset: 0x00022104
    private static AppMain.GMS_DECO_WORK gmDecoInitFall( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitModelMaterial(dec_rec, x, y, type);
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        int id = (int)gms_DECO_WORK.event_record.id;
        AppMain.gmDecoAdjustIPhone( ( AppMain.OBS_OBJECT_WORK )gms_DECO_WORK, id );
        return gms_DECO_WORK;
    }

    // Token: 0x0600045B RID: 1115 RVA: 0x00023F40 File Offset: 0x00022140
    private static AppMain.GMS_DECO_WORK gmDecoInitEffect( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        int id = (int)dec_rec.id;
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitNomodel(dec_rec, x, y, type, () => new AppMain.GMS_DECO_WORK());
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        int efct_zone_idx = AppMain.g_gm_deco_model_index[id][0];
        int zone_no = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(gms_DECO_WORK.obj_work, zone_no, efct_zone_idx);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = AppMain.g_gm_deco_rot_z[( int )dec_rec.id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        int num = (int)gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag;
        num |= ( int )AppMain.g_gm_deco_user_flag[id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag = ( uint )num;
        num = ( int )gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work;
        num |= ( int )AppMain.g_gm_deco_user_work[id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = ( uint )num;
        gms_EFFECT_3DES_WORK.obj_3des.command_state = AppMain.g_gm_deco_command_state[id];
        if ( gms_DECO_WORK.obj_work.ppFunc != null )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = gms_DECO_WORK.obj_work.ppFunc;
            gms_DECO_WORK.obj_work.ppFunc = null;
        }
        return gms_DECO_WORK;
    }

    // Token: 0x0600045C RID: 1116 RVA: 0x000240A0 File Offset: 0x000222A0
    private static AppMain.GMS_DECO_WORK gmDecoInitEffectBlock( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        int id = (int)dec_rec.id;
        int num = x >> 18;
        num <<= 18;
        int num2 = y >> 18;
        num2 <<= 18;
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitNomodel(dec_rec, num, num2, type, () => new AppMain.GMS_DECO_WORK());
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        int efct_zone_idx = AppMain.g_gm_deco_model_index[id][0];
        int zone_no = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(gms_DECO_WORK.obj_work, zone_no, efct_zone_idx);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = AppMain.g_gm_deco_rot_z[( int )dec_rec.id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag = ( gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag | AppMain.g_gm_deco_user_flag[id] );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = ( gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work | AppMain.g_gm_deco_user_work[id] );
        gms_EFFECT_3DES_WORK.obj_3des.command_state = AppMain.g_gm_deco_command_state[id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag = ( gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag | gms_DECO_WORK.obj_work.user_flag );
        if ( gms_DECO_WORK.obj_work.ppFunc != null )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = gms_DECO_WORK.obj_work.ppFunc;
            gms_DECO_WORK.obj_work.ppFunc = null;
        }
        if ( ( AppMain.g_gm_deco_user_flag[id] & 256U ) != 0U )
        {
            int num3 = (int)AppMain.g_gm_deco_user_work[id];
            num3 <<= 16;
            num3 >>= 16;
            int num4 = (int)AppMain.g_gm_deco_user_work[id];
            num4 >>= 16;
            AppMain.GmEffect3DESSetDuplicateDraw( gms_EFFECT_3DES_WORK, ( float )num3, ( float )num4, 0f );
        }
        return gms_DECO_WORK;
    }

    // Token: 0x0600045D RID: 1117 RVA: 0x00024280 File Offset: 0x00022480
    private static AppMain.GMS_DECO_WORK gmDecoInitEffectBlockAndNext( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, int y, byte type )
    {
        int id = (int)dec_rec.id;
        int num = x >> 18;
        num <<= 18;
        int num2 = y >> 18;
        num2 <<= 18;
        AppMain.GMS_DECO_WORK gms_DECO_WORK = AppMain.gmDecoInitNomodel(dec_rec, num, num2, type, () => new AppMain.GMS_DECO_WORK());
        if ( gms_DECO_WORK == null )
        {
            return null;
        }
        int num3 = AppMain.g_gm_deco_model_index[id][0];
        int zone_no = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(gms_DECO_WORK.obj_work, zone_no, num3);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = AppMain.g_gm_deco_rot_z[( int )dec_rec.id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag = ( gms_EFFECT_3DES_WORK.efct_com.obj_work.user_flag | AppMain.g_gm_deco_user_flag[id] );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work = ( gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work | AppMain.g_gm_deco_user_work[id] );
        gms_EFFECT_3DES_WORK.obj_3des.command_state = AppMain.g_gm_deco_command_state[id];
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK2 = AppMain.GmEfctZoneEsCreate(gms_DECO_WORK.obj_work, zone_no, num3 + 1);
        gms_EFFECT_3DES_WORK2.efct_com.obj_work.dir.z = AppMain.g_gm_deco_rot_z[( int )dec_rec.id];
        gms_EFFECT_3DES_WORK2.efct_com.obj_work.disp_flag |= AppMain.g_gm_deco_disp_flag[id];
        gms_EFFECT_3DES_WORK2.efct_com.obj_work.user_flag = ( gms_EFFECT_3DES_WORK2.efct_com.obj_work.user_flag | AppMain.g_gm_deco_user_flag[id] );
        gms_EFFECT_3DES_WORK2.efct_com.obj_work.user_work = ( gms_EFFECT_3DES_WORK2.efct_com.obj_work.user_work | AppMain.g_gm_deco_user_work[id] );
        gms_EFFECT_3DES_WORK2.obj_3des.command_state = AppMain.g_gm_deco_command_state[id];
        if ( gms_DECO_WORK.obj_work.ppFunc != null )
        {
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = gms_DECO_WORK.obj_work.ppFunc;
            gms_EFFECT_3DES_WORK2.efct_com.obj_work.ppFunc = gms_DECO_WORK.obj_work.ppFunc;
            gms_DECO_WORK.obj_work.ppFunc = null;
        }
        return gms_DECO_WORK;
    }

    // Token: 0x0600045E RID: 1118 RVA: 0x000244B8 File Offset: 0x000226B8
    private static void gmDecoAddFallEvent( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x, AppMain.NNS_TEXLIST texlist, float frame )
    {
        if ( dec_rec == null )
        {
            return;
        }
        ushort id = dec_rec.id;
        AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER = null;
        AppMain.GMS_DECO_FALL_REGISTER gms_DECO_FALL_REGISTER = null;
        ushort num = id;
        if ( num != 20 && num != 27 )
        {
            switch ( num )
            {
                case 40:
                case 41:
                case 42:
                case 47:
                case 48:
                case 49:
                    break;
                case 43:
                case 44:
                case 45:
                case 46:
                    return;
                default:
                    return;
            }
        }
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER2 = AppMain.g_deco_fall_manager[i];
            if ( gms_DECO_FALL_MANAGER2.dec_id == 0U )
            {
                if ( gms_DECO_FALL_MANAGER == null )
                {
                    gms_DECO_FALL_MANAGER = gms_DECO_FALL_MANAGER2;
                }
            }
            else if ( gms_DECO_FALL_MANAGER2.dec_id == ( uint )id )
            {
                gms_DECO_FALL_MANAGER = gms_DECO_FALL_MANAGER2;
                break;
            }
        }
        gms_DECO_FALL_MANAGER.dec_id = ( uint )id;
        gms_DECO_FALL_MANAGER.texlist = texlist;
        gms_DECO_FALL_MANAGER.frame = frame;
        AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER3 = gms_DECO_FALL_MANAGER;
        gms_DECO_FALL_MANAGER3.all_num += 1;
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.GMS_DECO_FALL_REGISTER gms_DECO_FALL_REGISTER2 = gms_DECO_FALL_MANAGER.reg[i];
            if ( gms_DECO_FALL_REGISTER2.num == 0U )
            {
                if ( gms_DECO_FALL_REGISTER == null )
                {
                    gms_DECO_FALL_REGISTER = gms_DECO_FALL_REGISTER2;
                }
            }
            else if ( gms_DECO_FALL_REGISTER2.vec.x == x )
            {
                gms_DECO_FALL_REGISTER = gms_DECO_FALL_REGISTER2;
                break;
            }
        }
        if ( gms_DECO_FALL_REGISTER.num == 0U )
        {
            AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER4 = gms_DECO_FALL_MANAGER;
            gms_DECO_FALL_MANAGER4.reg_num += 1;
        }
        gms_DECO_FALL_REGISTER.num += 1U;
        gms_DECO_FALL_REGISTER.vec.x = x;
    }

    // Token: 0x0600045F RID: 1119 RVA: 0x000245DC File Offset: 0x000227DC
    private static void gmDecoDelFallEvent( AppMain.GMS_EVE_RECORD_DECORATE dec_rec, int x )
    {
        if ( dec_rec == null )
        {
            return;
        }
        ushort id = dec_rec.id;
        ushort num = id;
        if ( num != 20 && num != 27 )
        {
            switch ( num )
            {
                case 40:
                case 41:
                case 42:
                case 47:
                case 48:
                case 49:
                    break;
                case 43:
                case 44:
                case 45:
                case 46:
                    return;
                default:
                    return;
            }
        }
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER = AppMain.g_deco_fall_manager[i];
            if ( gms_DECO_FALL_MANAGER.dec_id == ( uint )id )
            {
                AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER2 = gms_DECO_FALL_MANAGER;
                gms_DECO_FALL_MANAGER2.all_num -= 1;
                if ( gms_DECO_FALL_MANAGER.all_num == 0 )
                {
                    gms_DECO_FALL_MANAGER.dec_id = 0U;
                    gms_DECO_FALL_MANAGER.texlist = null;
                }
                int j = 0;
                while ( j < 8 )
                {
                    AppMain.GMS_DECO_FALL_REGISTER gms_DECO_FALL_REGISTER = gms_DECO_FALL_MANAGER.reg[j];
                    if ( gms_DECO_FALL_REGISTER.vec.x == x )
                    {
                        gms_DECO_FALL_REGISTER.num -= 1U;
                        if ( gms_DECO_FALL_REGISTER.num == 0U )
                        {
                            gms_DECO_FALL_REGISTER.vec.x = 0;
                            AppMain.GMS_DECO_FALL_MANAGER gms_DECO_FALL_MANAGER3 = gms_DECO_FALL_MANAGER;
                            gms_DECO_FALL_MANAGER3.reg_num -= 1;
                            return;
                        }
                        return;
                    }
                    else
                    {
                        j++;
                    }
                }
                return;
            }
        }
    }

    // Token: 0x06000460 RID: 1120 RVA: 0x000246E0 File Offset: 0x000228E0
    private static void gmDecoSetDrawFall( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.GMS_DECO_WORK gms_DECO_WORK = (AppMain.GMS_DECO_WORK)obj_work;
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = obj_work.pos.x + obj_work.ofst.x;
        vecFx.y = -( obj_work.pos.y + obj_work.ofst.y );
        vecFx.z = obj_work.pos.z + obj_work.ofst.z;
        AppMain.GMS_EVE_RECORD_DECORATE event_record = gms_DECO_WORK.event_record;
        AppMain.GMS_DECO_FALL_REGISTER gms_DECO_FALL_REGISTER = null;
        for ( int i = 0; i < 16; i++ )
        {
            if ( AppMain.g_deco_fall_manager[i].dec_id == ( uint )event_record.id )
            {
                for ( int j = 0; j < 8; j++ )
                {
                    if ( AppMain.g_deco_fall_manager[i].reg[j].vec.x == vecFx.x )
                    {
                        gms_DECO_FALL_REGISTER = AppMain.g_deco_fall_manager[i].reg[j];
                        break;
                    }
                }
            }
        }
        if ( gms_DECO_FALL_REGISTER != null )
        {
            gms_DECO_FALL_REGISTER.vec.z = vecFx.z;
            if ( gms_DECO_FALL_REGISTER.vec.y == 0 || gms_DECO_FALL_REGISTER.vec.y < vecFx.y )
            {
                gms_DECO_FALL_REGISTER.vec.y = vecFx.y;
            }
        }
    }

    // Token: 0x06000461 RID: 1121 RVA: 0x0002481C File Offset: 0x00022A1C
    private static void gmDecoSetDrawPrimitive( int model_index, AppMain.AOS_TEXTURE model_tex, AppMain.VecFx32 pos, float off_y, uint command, uint disp_flag )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( AppMain.gmDecoDataGetInfo().tvx_model_data[model_index] == null )
        {
            AppMain.AmbChunk data = (AppMain.AmbChunk)AppMain.amBindGet(AppMain.gmDecoDataGetInfo().tvx_model, model_index);
            AppMain.gmDecoDataGetInfo().tvx_model_data[model_index] = new AppMain.TVX_FILE( data );
        }
        AppMain.TVX_FILE file = AppMain.gmDecoDataGetInfo().tvx_model_data[model_index];
        uint num = AppMain.AoTvxGetTextureNum(file);
        AppMain.GMS_DECO_PRIM_DRAW_WORK[] array = AppMain.g_deco_tvx_work;
        for ( uint num2 = 0U; num2 < num; num2 += 1U )
        {
            uint num3 = AppMain.AoTvxGetVertexNum(file, num2);
            int num4 = AppMain.AoTvxGetTextureId(file, num2);
            for ( int i = 0; i < 16; i++ )
            {
                if ( ( array[i].tex == null && array[i].tex_id == -1 && array[i].command == 4294967295U ) || ( array[i].tex == model_tex && array[i].tex_id == num4 && array[i].command == command ) )
                {
                    array[i].tex = model_tex;
                    array[i].tex_id = num4;
                    array[i].command = command;
                    AppMain.GMS_DECO_PRIM_DRAW_WORK gms_DECO_PRIM_DRAW_WORK = array[i];
                    gms_DECO_PRIM_DRAW_WORK.all_vtx_num += ( ushort )num3;
                    AppMain.GMS_DECO_PRIM_DRAW_STACK gms_DECO_PRIM_DRAW_STACK = array[i].stack[(int)array[i].stack_num];
                    gms_DECO_PRIM_DRAW_STACK.vtx = AppMain.AoTvxGetVertex( file, num2 );
                    gms_DECO_PRIM_DRAW_STACK.vtx_num = num3;
                    gms_DECO_PRIM_DRAW_STACK.pos.Assign( pos );
                    gms_DECO_PRIM_DRAW_STACK.off_y = off_y;
                    gms_DECO_PRIM_DRAW_STACK.disp_flag = disp_flag;
                    AppMain.GMS_DECO_PRIM_DRAW_WORK gms_DECO_PRIM_DRAW_WORK2 = array[i];
                    gms_DECO_PRIM_DRAW_WORK2.stack_num += 1;
                    break;
                }
            }
        }
    }

    // Token: 0x06000462 RID: 1122 RVA: 0x000249AC File Offset: 0x00022BAC
    private static bool gmDecoIsUseModel( int type )
    {
        bool result = false;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( type == 0 && 5 != num )
        {
            result = true;
        }
        if ( 1 == type && ( num == 0 || 2 == num ) )
        {
            result = true;
        }
        return result;
    }
}