using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000526 RID: 1318 RVA: 0x0002B6CB File Offset: 0x000298CB
    private static void GmTvxBuild()
    {
        AppMain.gm_tvx_draw_work = AppMain.New<AppMain.GMS_TVX_DRAW_WORK>( AppMain.GMD_TVX_DRAW_WORK_NUM );
        AppMain.GmTvxInit();
    }

    // Token: 0x06000527 RID: 1319 RVA: 0x0002B6E4 File Offset: 0x000298E4
    private static void GmTvxInit()
    {
        AppMain.GMS_TVX_DRAW_WORK[] array = AppMain.gm_tvx_draw_work;
        for ( int i = 0; i < AppMain.GMD_TVX_DRAW_WORK_NUM; i++ )
        {
            array[i].Clear();
            array[i].tex_id = -1;
        }
    }

    // Token: 0x06000528 RID: 1320 RVA: 0x0002B718 File Offset: 0x00029918
    private static void GmTvxExit()
    {
        AppMain.GmTvxInit();
    }

    // Token: 0x06000529 RID: 1321 RVA: 0x0002B71F File Offset: 0x0002991F
    private static void GmTvxFlush()
    {
        AppMain.GMS_TVX_DRAW_WORK[] array = AppMain.gm_tvx_draw_work;
        AppMain.gm_tvx_draw_work = null;
    }

    // Token: 0x0600052A RID: 1322 RVA: 0x0002B730 File Offset: 0x00029930
    private static void GmTvxSetModel( AppMain.TVX_FILE model_tvx, AppMain.NNS_TEXLIST model_tex, ref AppMain.VecFx32 pos, ref AppMain.VecFx32 scale, uint flag, short rotate_z )
    {
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = 0f;
        gms_TVX_EX_WORK.coord.v = 0f;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        AppMain.GmTvxSetModelEx( model_tvx, model_tex, ref pos, ref scale, flag, rotate_z, ref gms_TVX_EX_WORK );
    }

    // Token: 0x0600052B RID: 1323 RVA: 0x0002B790 File Offset: 0x00029990
    private static void GmTvxSetModelEx( AppMain.TVX_FILE model_tvx, AppMain.NNS_TEXLIST model_tex, ref AppMain.VecFx32 pos, ref AppMain.VecFx32 scale, uint flag, short rotate_z, ref AppMain.GMS_TVX_EX_WORK ex_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.GMS_TVX_DRAW_WORK[] array = AppMain.gm_tvx_draw_work;
        uint num = AppMain.AoTvxGetTextureNum(model_tvx);
        for ( uint num2 = 0U; num2 < num; num2 += 1U )
        {
            uint num3 = AppMain.AoTvxGetVertexNum(model_tvx, num2);
            int num4 = AppMain.AoTvxGetTextureId(model_tvx, num2);
            int i = 0;
            while ( i < AppMain.GMD_TVX_DRAW_WORK_NUM )
            {
                if ( ( array[i].tex == null && array[i].tex_id == -1 ) || ( array[i].tex == model_tex && array[i].tex_id == num4 && array[i].u_wrap == ex_work.u_wrap && array[i].v_wrap == ex_work.v_wrap ) )
                {
                    if ( ( ulong )array[i].stack_num >= ( ulong )( ( long )AppMain.GMD_TVX_DRAW_STACK_NUM ) )
                    {
                        return;
                    }
                    array[i].tex = model_tex;
                    array[i].tex_id = num4;
                    array[i].u_wrap = ex_work.u_wrap;
                    array[i].v_wrap = ex_work.v_wrap;
                    array[i].all_vtx_num += num3;
                    AppMain.GMS_TVX_DRAW_STACK gms_TVX_DRAW_STACK = array[i].stack[(int)((UIntPtr)array[i].stack_num)];
                    gms_TVX_DRAW_STACK.vtx = AppMain.AoTvxGetVertex( model_tvx, num2 );
                    gms_TVX_DRAW_STACK.vtx_num = num3;
                    gms_TVX_DRAW_STACK.pos = pos;
                    gms_TVX_DRAW_STACK.scale = scale;
                    gms_TVX_DRAW_STACK.disp_flag = flag;
                    gms_TVX_DRAW_STACK.rotate_z = ( int )rotate_z;
                    gms_TVX_DRAW_STACK.coord = ex_work.coord;
                    gms_TVX_DRAW_STACK.color = ex_work.color;
                    array[i].stack_num += 1U;
                    break;
                }
                else
                {
                    i++;
                }
            }
        }
    }

    // Token: 0x0600052C RID: 1324 RVA: 0x0002B92C File Offset: 0x00029B2C
    private static void GmTvxExecuteDraw()
    {
        AppMain.GMS_TVX_DRAW_WORK[] array = AppMain.gm_tvx_draw_work;
        if ( array == null )
        {
            return;
        }
        if ( array[0].tex == null )
        {
            return;
        }
        uint num = AppMain.GmMainGetLightColor();
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldDst = 771;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.aTest = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.zMask = 0;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.zTest = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.noSort = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.format3D = 4;
        uint num2 = 0U;
        while ( ( ulong )num2 < ( ulong )( ( long )AppMain.GMD_TVX_DRAW_WORK_NUM ) )
        {
            if ( array[( int )( ( UIntPtr )num2 )].tex_id == -1 )
            {
                return;
            }
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.ablend = 0;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.texlist = array[( int )( ( UIntPtr )num2 )].tex;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.uwrap = array[( int )( ( UIntPtr )num2 )].u_wrap;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.vwrap = array[( int )( ( UIntPtr )num2 )].v_wrap;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.type = 1;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.count = ( int )( array[( int )( ( UIntPtr )num2 )].all_vtx_num + array[( int )( ( UIntPtr )num2 )].stack_num * 2U - 2U );
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(AppMain._AMS_PARAM_DRAW_PRIMITIVE.count);
            AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
            int offset = nns_PRIM3D_PCT_ARRAY.offset;
            int num3 = 0;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
            AppMain._AMS_PARAM_DRAW_PRIMITIVE.texId = array[( int )( ( UIntPtr )num2 )].tex_id;
            AppMain.SNNS_MATRIX snns_MATRIX = default(AppMain.SNNS_MATRIX);
            AppMain.SNNS_MATRIX snns_MATRIX2 = default(AppMain.SNNS_MATRIX);
            AppMain.nnMakeUnitMatrix( ref snns_MATRIX2 );
            for ( uint num4 = 0U; num4 < array[( int )( ( UIntPtr )num2 )].stack_num; num4 += 1U )
            {
                AppMain.GMS_TVX_DRAW_STACK gms_TVX_DRAW_STACK = array[(int)((UIntPtr)num2)].stack[(int)((UIntPtr)num4)];
                if ( ( gms_TVX_DRAW_STACK.disp_flag & AppMain.GMD_TVX_DISP_BLEND ) != 0U )
                {
                    AppMain._AMS_PARAM_DRAW_PRIMITIVE.ablend = 1;
                }
                float num5 = AppMain.FXM_FX32_TO_FLOAT(gms_TVX_DRAW_STACK.pos.x);
                float num6 = -AppMain.FXM_FX32_TO_FLOAT(gms_TVX_DRAW_STACK.pos.y);
                float num7 = AppMain.FXM_FX32_TO_FLOAT(gms_TVX_DRAW_STACK.pos.z);
                AppMain.nnMakeUnitMatrix( ref snns_MATRIX );
                if ( ( gms_TVX_DRAW_STACK.disp_flag & AppMain.GMD_TVX_DISP_ROTATE ) != 0U )
                {
                    AppMain.nnRotateZMatrix( ref snns_MATRIX, ref snns_MATRIX, ( int )( ( ushort )gms_TVX_DRAW_STACK.rotate_z ) );
                }
                if ( ( gms_TVX_DRAW_STACK.disp_flag & AppMain.GMD_TVX_DISP_SCALE ) != 0U )
                {
                    AppMain.nnScaleMatrix( ref snns_MATRIX, ref snns_MATRIX, AppMain.FXM_FX32_TO_FLOAT( gms_TVX_DRAW_STACK.scale.x ), AppMain.FXM_FX32_TO_FLOAT( gms_TVX_DRAW_STACK.scale.y ), AppMain.FXM_FX32_TO_FLOAT( gms_TVX_DRAW_STACK.scale.z ) );
                }
                uint num8 = num;
                if ( ( gms_TVX_DRAW_STACK.disp_flag & AppMain.GMD_TVX_DISP_LIGHT_DISABLE ) != 0U )
                {
                    num8 = gms_TVX_DRAW_STACK.color;
                }
                AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
                int num9 = num3 + offset;
                AppMain.AOS_TVX_VERTEX[] vtx = gms_TVX_DRAW_STACK.vtx;
                int num10 = 0;
                while ( ( long )num10 < ( long )( ( ulong )gms_TVX_DRAW_STACK.vtx_num ) )
                {
                    snns_VECTOR.x = vtx[num10].x;
                    snns_VECTOR.y = vtx[num10].y;
                    snns_VECTOR.z = vtx[num10].z;
                    int num11 = num9 + num10;
                    if ( gms_TVX_DRAW_STACK.disp_flag != 0U )
                    {
                        AppMain.nnTransformVector( ref buffer[num11].Pos, ref snns_MATRIX, ref snns_VECTOR );
                    }
                    else
                    {
                        buffer[num11].Pos.Assign( snns_VECTOR.x, snns_VECTOR.y, snns_VECTOR.z );
                    }
                    AppMain.NNS_PRIM3D_PCT[] array2 = buffer;
                    int num12 = num11;
                    array2[num12].Pos.x = array2[num12].Pos.x + num5;
                    AppMain.NNS_PRIM3D_PCT[] array3 = buffer;
                    int num13 = num11;
                    array3[num13].Pos.y = array3[num13].Pos.y + num6;
                    AppMain.NNS_PRIM3D_PCT[] array4 = buffer;
                    int num14 = num11;
                    array4[num14].Pos.z = array4[num14].Pos.z + num7;
                    buffer[num11].Tex.u = vtx[num10].u + gms_TVX_DRAW_STACK.coord.u;
                    buffer[num11].Tex.v = vtx[num10].v + gms_TVX_DRAW_STACK.coord.v;
                    buffer[num11].Col = ( vtx[num10].c & num8 );
                    num10++;
                }
                num3 += ( int )( gms_TVX_DRAW_STACK.vtx_num + 2U );
                if ( num4 != 0U )
                {
                    int num15 = num9 - 1;
                    buffer[num15] = buffer[num15 + 1];
                }
                if ( num4 != array[( int )( ( UIntPtr )num2 )].stack_num - 1U )
                {
                    int num15 = num9 + (int)(gms_TVX_DRAW_STACK.vtx_num - 1U);
                    buffer[num15 + 1] = buffer[num15];
                }
            }
            AppMain.amMatrixPush( ref snns_MATRIX2 );
            AppMain.ObjDraw3DNNDrawPrimitive( AppMain._AMS_PARAM_DRAW_PRIMITIVE );
            AppMain.amMatrixPop();
            array[( int )( ( UIntPtr )num2 )].tex = null;
            array[( int )( ( UIntPtr )num2 )].tex_id = -1;
            array[( int )( ( UIntPtr )num2 )].stack_num = 0U;
            array[( int )( ( UIntPtr )num2 )].all_vtx_num = 0U;
            num2 += 1U;
        }
    }

    // Token: 0x17000015 RID: 21
    // (get) Token: 0x0600052D RID: 1325 RVA: 0x0002BDE9 File Offset: 0x00029FE9
    public static int gm_map_prim_draw_tvx_mgr_index_tbl_z2_num
    {
        get
        {
            return ( ( uint[] )AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z2 ).Length;
        }
    }

    // Token: 0x17000016 RID: 22
    // (get) Token: 0x0600052E RID: 1326 RVA: 0x0002BDF7 File Offset: 0x00029FF7
    public static int gm_map_prim_draw_tvx_mgr_index_tbl_z3_num
    {
        get
        {
            return ( ( uint[] )AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z3 ).Length;
        }
    }

    // Token: 0x17000017 RID: 23
    // (get) Token: 0x0600052F RID: 1327 RVA: 0x0002BE05 File Offset: 0x0002A005
    public static int gm_map_prim_draw_tvx_mgr_index_tbl_z4_num
    {
        get
        {
            return ( ( uint[] )AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z4 ).Length;
        }
    }

    // Token: 0x17000018 RID: 24
    // (get) Token: 0x06000530 RID: 1328 RVA: 0x0002BE13 File Offset: 0x0002A013
    public static int gm_map_prim_draw_tvx_mgr_index_tbl_zf_num
    {
        get
        {
            return ( ( uint[] )AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_zf ).Length;
        }
    }
}