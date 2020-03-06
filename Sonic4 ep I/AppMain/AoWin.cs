using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020003A0 RID: 928
    public class AOS_WIN_DRAW_WORK
    {
        // Token: 0x04006143 RID: 24899
        public int type;

        // Token: 0x04006144 RID: 24900
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04006145 RID: 24901
        public uint tex_id;

        // Token: 0x04006146 RID: 24902
        public float x;

        // Token: 0x04006147 RID: 24903
        public float y;

        // Token: 0x04006148 RID: 24904
        public float w;

        // Token: 0x04006149 RID: 24905
        public float h;
    }

    // Token: 0x060018E2 RID: 6370 RVA: 0x000E2C59 File Offset: 0x000E0E59
    private void AoWinSysDraw( int type, AppMain.NNS_TEXLIST texlist, uint tex_id, float x, float y, float w, float h )
    {
        AppMain.AoActDrawPre();
        AppMain.aoWinSysDrawPrimitveA( texlist, tex_id, x, y, w, h );
    }

    // Token: 0x060018E3 RID: 6371 RVA: 0x000E2C70 File Offset: 0x000E0E70
    private static void AoWinSysDrawState( int type, AppMain.NNS_TEXLIST texlist, uint tex_id, float x, float y, float w, float h, uint state )
    {
        AppMain.AoWinSysDrawState( type, texlist, tex_id, x, y, w, h, state, 0f );
    }

    // Token: 0x060018E4 RID: 6372 RVA: 0x000E2C93 File Offset: 0x000E0E93
    private static void AoWinSysDrawState( int type, AppMain.NNS_TEXLIST texlist, uint tex_id, float x, float y, float w, float h, uint state, float z )
    {
        AppMain.aoWinSysMakeCommandA( state, texlist, tex_id, x, y, w, h, z );
    }

    // Token: 0x060018E5 RID: 6373 RVA: 0x000E2CA8 File Offset: 0x000E0EA8
    private static void AoWinSysDrawTask( int type, AppMain.NNS_TEXLIST texlist, uint tex_id, float x, float y, float w, float h, ushort prio )
    {
        AppMain.AOS_WIN_DRAW_WORK aos_WIN_DRAW_WORK = new AppMain.AOS_WIN_DRAW_WORK();
        aos_WIN_DRAW_WORK.type = type;
        aos_WIN_DRAW_WORK.texlist = texlist;
        aos_WIN_DRAW_WORK.tex_id = tex_id;
        aos_WIN_DRAW_WORK.x = x;
        aos_WIN_DRAW_WORK.y = y;
        aos_WIN_DRAW_WORK.w = w;
        aos_WIN_DRAW_WORK.h = h;
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.aoWinSysTaskDraw ), prio, aos_WIN_DRAW_WORK );
    }

    // Token: 0x060018E6 RID: 6374 RVA: 0x000E2D04 File Offset: 0x000E0F04
    private static void aoWinSysTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.AOS_WIN_DRAW_WORK aos_WIN_DRAW_WORK = (AppMain.AOS_WIN_DRAW_WORK)AppMain.amTaskGetWork(tcb);
        AppMain.AoActDrawPre();
        AppMain.aoWinSysDrawPrimitveA( aos_WIN_DRAW_WORK.texlist, aos_WIN_DRAW_WORK.tex_id, aos_WIN_DRAW_WORK.x, aos_WIN_DRAW_WORK.y, aos_WIN_DRAW_WORK.w, aos_WIN_DRAW_WORK.h );
    }

    // Token: 0x060018E7 RID: 6375 RVA: 0x000E2D4C File Offset: 0x000E0F4C
    private static void aoWinSysDrawPrimitveA( AppMain.NNS_TEXLIST texlist, uint tex_id, float x, float y, float w, float h )
    {
        AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(8);
        AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
        int offset = nns_PRIM3D_PCT_ARRAY.offset;
        AppMain.amDrawPushState();
        AppMain.amDrawInitState();
        AppMain.nnSetPrimitive3DAlphaFuncGL( 519U, 0.5f );
        AppMain.nnSetPrimitive3DDepthMaskGL( false );
        AppMain.nnSetPrimitive3DDepthFuncGL( 519U );
        AppMain.nnSetPrimitiveBlend( 1 );
        AppMain.amDrawSetFog( 0 );
        AppMain.nnSetPrimitiveTexNum( texlist, ( int )tex_id );
        AppMain.nnSetPrimitiveTexState( 0, 0, 1, 1 );
        AppMain.nnBeginDrawPrimitive3D( 4, 1, 0, 0 );
        AppMain.aoWinSysMakeVertex00A( nns_PRIM3D_PCT_ARRAY, x, y, w, h );
        AppMain.nnDrawPrimitive3D( 1, nns_PRIM3D_PCT_ARRAY, 8 );
        AppMain.aoWinSysMakeVertex01A( nns_PRIM3D_PCT_ARRAY, x, y, w, h );
        AppMain.nnDrawPrimitive3D( 1, nns_PRIM3D_PCT_ARRAY, 8 );
        AppMain.aoWinSysMakeVertex02A( nns_PRIM3D_PCT_ARRAY, x, y, w, h );
        AppMain.nnDrawPrimitive3D( 1, nns_PRIM3D_PCT_ARRAY, 8 );
        AppMain.nnEndDrawPrimitive3D();
        AppMain.amDrawPopState();
    }

    // Token: 0x060018E8 RID: 6376 RVA: 0x000E2E04 File Offset: 0x000E1004
    private static void aoWinSysMakeCommandA( uint state, AppMain.NNS_TEXLIST texlist, uint tex_id, float x, float y, float w, float h, float z )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.mtx = null;
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = null;
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        ams_PARAM_DRAW_PRIMITIVE.type = 1;
        ams_PARAM_DRAW_PRIMITIVE.count = 8;
        ams_PARAM_DRAW_PRIMITIVE.texlist = texlist;
        ams_PARAM_DRAW_PRIMITIVE.texId = ( int )tex_id;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
        ams_PARAM_DRAW_PRIMITIVE.sortZ = z;
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
        ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.vwrap = 1;
        AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(8);
        AppMain.aoWinSysMakeVertex00A( nns_PRIM3D_PCT_ARRAY, x, y, w, h );
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
        AppMain.amDrawPrimitive3D( state, ams_PARAM_DRAW_PRIMITIVE );
        nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( 8 );
        AppMain.aoWinSysMakeVertex01A( nns_PRIM3D_PCT_ARRAY, x, y, w, h );
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
        AppMain.amDrawPrimitive3D( state, ams_PARAM_DRAW_PRIMITIVE );
        nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( 8 );
        AppMain.aoWinSysMakeVertex02A( nns_PRIM3D_PCT_ARRAY, x, y, w, h );
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
        AppMain.amDrawPrimitive3D( state, ams_PARAM_DRAW_PRIMITIVE );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x060018E9 RID: 6377 RVA: 0x000E2EF0 File Offset: 0x000E10F0
    private static void aoWinSysMakeVertex00A( AppMain.NNS_PRIM3D_PCT_ARRAY array, float x, float y, float w, float h )
    {
        int offset = array.offset;
        AppMain.NNS_PRIM3D_PCT[] buffer = array.buffer;
        buffer[offset].Tex.u = ( buffer[offset + 1].Tex.u = ( buffer[offset + 6].Tex.u = ( buffer[offset + 7].Tex.u = 0f ) ) );
        buffer[offset + 2].Tex.u = ( buffer[offset + 3].Tex.u = ( buffer[offset + 4].Tex.u = ( buffer[offset + 5].Tex.u = 1f ) ) );
        buffer[offset].Tex.v = ( buffer[offset + 2].Tex.v = ( buffer[offset + 4].Tex.v = ( buffer[offset + 6].Tex.v = 0f ) ) );
        buffer[offset + 1].Tex.v = ( buffer[offset + 3].Tex.v = ( buffer[offset + 5].Tex.v = ( buffer[offset + 7].Tex.v = 1f ) ) );
        buffer[offset].Col = ( buffer[offset + 1].Col = ( buffer[offset + 2].Col = ( buffer[offset + 3].Col = ( buffer[offset + 4].Col = ( buffer[offset + 5].Col = ( buffer[offset + 6].Col = ( buffer[offset + 7].Col = uint.MaxValue ) ) ) ) ) ) );
        float num = x - w * 0.5f;
        float num2 = y - h * 0.5f;
        float num3 = num + w;
        buffer[offset].Pos.x = ( buffer[offset + 1].Pos.x = num - 32f );
        buffer[offset + 2].Pos.x = ( buffer[offset + 3].Pos.x = num );
        buffer[offset + 4].Pos.x = ( buffer[offset + 5].Pos.x = num3 );
        buffer[offset + 6].Pos.x = ( buffer[offset + 7].Pos.x = num3 + 32f );
        buffer[offset].Pos.y = ( buffer[offset + 2].Pos.y = ( buffer[offset + 4].Pos.y = ( buffer[offset + 6].Pos.y = num2 - 32f ) ) );
        buffer[offset + 1].Pos.y = ( buffer[offset + 3].Pos.y = ( buffer[offset + 5].Pos.y = ( buffer[offset + 7].Pos.y = num2 ) ) );
        buffer[offset].Pos.z = ( buffer[offset + 1].Pos.z = ( buffer[offset + 2].Pos.z = ( buffer[offset + 3].Pos.z = ( buffer[offset + 4].Pos.z = ( buffer[offset + 5].Pos.z = ( buffer[offset + 6].Pos.z = ( buffer[offset + 7].Pos.z = -2f ) ) ) ) ) ) );
        AppMain.AoActDrawCorWide( array, 0, 8U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
    }

    // Token: 0x060018EA RID: 6378 RVA: 0x000E3374 File Offset: 0x000E1574
    private static void aoWinSysMakeVertex01A( AppMain.NNS_PRIM3D_PCT_ARRAY array, float x, float y, float w, float h )
    {
        AppMain.NNS_PRIM3D_PCT[] buffer = array.buffer;
        int offset = array.offset;
        buffer[offset].Tex.u = ( buffer[offset + 1].Tex.u = ( buffer[offset + 6].Tex.u = ( buffer[offset + 7].Tex.u = 0f ) ) );
        buffer[offset + 2].Tex.u = ( buffer[offset + 3].Tex.u = ( buffer[offset + 4].Tex.u = ( buffer[offset + 5].Tex.u = 1f ) ) );
        buffer[offset].Tex.v = ( buffer[offset + 2].Tex.v = ( buffer[offset + 4].Tex.v = ( buffer[offset + 6].Tex.v = 1f ) ) );
        buffer[offset + 1].Tex.v = ( buffer[offset + 3].Tex.v = ( buffer[offset + 5].Tex.v = ( buffer[offset + 7].Tex.v = 1f ) ) );
        buffer[offset].Col = ( buffer[offset + 1].Col = ( buffer[offset + 2].Col = ( buffer[offset + 3].Col = ( buffer[offset + 4].Col = ( buffer[offset + 5].Col = ( buffer[offset + 6].Col = ( buffer[offset + 7].Col = uint.MaxValue ) ) ) ) ) ) );
        float num = x - w * 0.5f;
        float num2 = y - h * 0.5f;
        float num3 = num + w;
        float y2 = num2 + h;
        buffer[offset].Pos.x = ( buffer[offset + 1].Pos.x = num - 32f );
        buffer[offset + 2].Pos.x = ( buffer[offset + 3].Pos.x = num );
        buffer[offset + 4].Pos.x = ( buffer[offset + 5].Pos.x = num3 );
        buffer[offset + 6].Pos.x = ( buffer[offset + 7].Pos.x = num3 + 32f );
        buffer[offset].Pos.y = ( buffer[offset + 2].Pos.y = ( buffer[offset + 4].Pos.y = ( buffer[offset + 6].Pos.y = num2 ) ) );
        buffer[offset + 1].Pos.y = ( buffer[offset + 3].Pos.y = ( buffer[offset + 5].Pos.y = ( buffer[offset + 7].Pos.y = y2 ) ) );
        buffer[offset].Pos.z = ( buffer[offset + 1].Pos.z = ( buffer[offset + 2].Pos.z = ( buffer[offset + 3].Pos.z = ( buffer[offset + 4].Pos.z = ( buffer[offset + 5].Pos.z = ( buffer[offset + 6].Pos.z = ( buffer[offset + 7].Pos.z = -2f ) ) ) ) ) ) );
        AppMain.AoActDrawCorWide( array, 0, 8U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
    }

    // Token: 0x060018EB RID: 6379 RVA: 0x000E37F8 File Offset: 0x000E19F8
    private static void aoWinSysMakeVertex02A( AppMain.NNS_PRIM3D_PCT_ARRAY array, float x, float y, float w, float h )
    {
        AppMain.NNS_PRIM3D_PCT[] buffer = array.buffer;
        int offset = array.offset;
        buffer[offset].Tex.u = ( buffer[offset + 1].Tex.u = ( buffer[offset + 6].Tex.u = ( buffer[offset + 7].Tex.u = 0f ) ) );
        buffer[offset + 2].Tex.u = ( buffer[offset + 3].Tex.u = ( buffer[offset + 4].Tex.u = ( buffer[offset + 5].Tex.u = 1f ) ) );
        buffer[offset].Tex.v = ( buffer[offset + 2].Tex.v = ( buffer[offset + 4].Tex.v = ( buffer[offset + 6].Tex.v = 1f ) ) );
        buffer[offset + 1].Tex.v = ( buffer[offset + 3].Tex.v = ( buffer[offset + 5].Tex.v = ( buffer[offset + 7].Tex.v = 0f ) ) );
        buffer[offset].Col = ( buffer[offset + 1].Col = ( buffer[offset + 2].Col = ( buffer[offset + 3].Col = ( buffer[offset + 4].Col = ( buffer[offset + 5].Col = ( buffer[offset + 6].Col = ( buffer[offset + 7].Col = uint.MaxValue ) ) ) ) ) ) );
        float num = x - w * 0.5f;
        float num2 = y - h * 0.5f;
        float num3 = num + w;
        float num4 = num2 + h;
        buffer[offset].Pos.x = ( buffer[offset + 1].Pos.x = num - 32f );
        buffer[offset + 2].Pos.x = ( buffer[offset + 3].Pos.x = num );
        buffer[offset + 4].Pos.x = ( buffer[offset + 5].Pos.x = num3 );
        buffer[offset + 6].Pos.x = ( buffer[offset + 7].Pos.x = num3 + 32f );
        buffer[offset].Pos.y = ( buffer[offset + 2].Pos.y = ( buffer[offset + 4].Pos.y = ( buffer[offset + 6].Pos.y = num4 ) ) );
        buffer[offset + 1].Pos.y = ( buffer[offset + 3].Pos.y = ( buffer[offset + 5].Pos.y = ( buffer[offset + 7].Pos.y = num4 + 32f ) ) );
        buffer[offset].Pos.z = ( buffer[offset + 1].Pos.z = ( buffer[offset + 2].Pos.z = ( buffer[offset + 3].Pos.z = ( buffer[offset + 4].Pos.z = ( buffer[offset + 5].Pos.z = ( buffer[offset + 6].Pos.z = ( buffer[offset + 7].Pos.z = -2f ) ) ) ) ) ) );
        AppMain.AoActDrawCorWide( array, 0, 8U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
    }
}
