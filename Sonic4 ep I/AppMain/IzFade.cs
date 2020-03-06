using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200028F RID: 655
    public class IZS_FADE_WORK
    {
        // Token: 0x06002436 RID: 9270 RVA: 0x0014A5C8 File Offset: 0x001487C8
        public void Clear()
        {
            this.time = ( this.count = ( this.speed = 0f ) );
            this.flag = ( this.draw_state = 0U );
            this.draw_state = ( uint )( this.dt_prio = ( this.vtx_no = 0 ) );
            this.start_col.Clear();
            this.end_col.Clear();
            this.now_col.Clear();
            this.mtx.Clear();
            this.prim_param.Clear();
            for ( int i = 0; i < 2; i++ )
            {
                for ( int j = 0; j < 4; j++ )
                {
                    this.vtx[i][j].Clear();
                }
            }
        }

        // Token: 0x04005A51 RID: 23121
        public readonly AppMain.AMS_PARAM_DRAW_PRIMITIVE prim_param = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();

        // Token: 0x04005A52 RID: 23122
        public readonly AppMain.NNS_PRIM2D_PC[][] vtx = AppMain.New<AppMain.NNS_PRIM2D_PC>(2, 4);

        // Token: 0x04005A53 RID: 23123
        public readonly AppMain.NNS_MATRIX mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005A54 RID: 23124
        public AppMain.NNS_RGBA start_col;

        // Token: 0x04005A55 RID: 23125
        public AppMain.NNS_RGBA end_col;

        // Token: 0x04005A56 RID: 23126
        public AppMain.NNS_RGBA now_col;

        // Token: 0x04005A57 RID: 23127
        public float time;

        // Token: 0x04005A58 RID: 23128
        public float count;

        // Token: 0x04005A59 RID: 23129
        public float speed;

        // Token: 0x04005A5A RID: 23130
        public uint flag;

        // Token: 0x04005A5B RID: 23131
        public uint draw_state;

        // Token: 0x04005A5C RID: 23132
        public ushort dt_prio;

        // Token: 0x04005A5D RID: 23133
        public ushort vtx_no;
    }

    // Token: 0x02000290 RID: 656
    public class IZS_FADE_DT_WORK
    {
        // Token: 0x04005A5E RID: 23134
        public uint draw_state;

        // Token: 0x04005A5F RID: 23135
        public uint drawflag;
    }

    // Token: 0x02000291 RID: 657
    private enum tag_IZE_FADE_SET_TYPE
    {
        // Token: 0x04005A61 RID: 23137
        IZE_FADE_SET_TYPE_NORMAL,
        // Token: 0x04005A62 RID: 23138
        IZE_FADE_SET_TYPE_TAKEOEVER,
        // Token: 0x04005A63 RID: 23139
        IZE_FADE_SET_TYPE_MAX
    }

    // Token: 0x06001155 RID: 4437 RVA: 0x00098554 File Offset: 0x00096754
    public static uint IZM_FADE_COL_PAC( uint r, uint g, uint b, uint a )
    {
        return ( r & 255U ) << 24 | ( g & 255U ) << 16 | ( b & 255U ) << 8 | ( a & 255U );
    }

    // Token: 0x06001156 RID: 4438 RVA: 0x0009858A File Offset: 0x0009678A
    private static void IzFadeInitEasy( uint fade_set_type, uint fade_type, float time )
    {
        AppMain.IzFadeInitEasy( fade_set_type, fade_type, time, true );
    }

    // Token: 0x06001157 RID: 4439 RVA: 0x00098598 File Offset: 0x00096798
    private static void IzFadeInitEasy( uint fade_set_type, uint fade_type, float time, bool draw_start )
    {
        int num = (int)fade_type >> 1;
        int num2 = (int)(fade_type & 1U);
        AppMain.IzFadeInit( 0, 0, 61439, 18U, fade_set_type, AppMain.iz_fade_color[num][0], AppMain.iz_fade_color[num][1], AppMain.iz_fade_color[num][2], AppMain.iz_fade_alpha[num2], AppMain.iz_fade_color[num][0], AppMain.iz_fade_color[num][1], AppMain.iz_fade_color[num][2], AppMain.iz_fade_alpha[num2 ^ 1], time, draw_start );
    }

    // Token: 0x06001158 RID: 4440 RVA: 0x00098604 File Offset: 0x00096804
    private static void IzFadeInitEasyTask( uint fade_set_type, byte start_col_r, byte start_col_g, byte start_col_b, byte start_col_a, byte end_col_r, byte end_col_g, byte end_col_b, byte end_col_a, float time )
    {
        AppMain.IzFadeInitEasyTask( fade_set_type, start_col_r, start_col_g, start_col_b, start_col_a, end_col_r, end_col_g, end_col_b, end_col_a, time, true );
    }

    // Token: 0x06001159 RID: 4441 RVA: 0x00098628 File Offset: 0x00096828
    private static void IzFadeInitEasyTask( uint fade_set_type, byte start_col_r, byte start_col_g, byte start_col_b, byte start_col_a, byte end_col_r, byte end_col_g, byte end_col_b, byte end_col_a, float time, bool draw_start )
    {
        AppMain.IzFadeInit( 0, 0, 61439, 18U, fade_set_type, start_col_r, start_col_g, start_col_b, start_col_a, end_col_r, end_col_g, end_col_b, end_col_a, time, draw_start );
    }

    // Token: 0x0600115A RID: 4442 RVA: 0x00098658 File Offset: 0x00096858
    private static void IzFadeInitEasyColor( int group, ushort pause_level, ushort dt_prio, uint draw_state, uint fade_set_type, uint fade_type, float time, bool draw_start )
    {
        int num = (int)fade_type >> 1;
        int num2 = (int)(fade_type & 1U);
        AppMain.IzFadeInit( group, pause_level, dt_prio, draw_state, fade_set_type, AppMain.iz_fade_color[num][0], AppMain.iz_fade_color[num][1], AppMain.iz_fade_color[num][2], AppMain.iz_fade_alpha[num2], AppMain.iz_fade_color[num][0], AppMain.iz_fade_color[num][1], AppMain.iz_fade_color[num][2], AppMain.iz_fade_alpha[num2 ^ 1], time, draw_start );
    }

    // Token: 0x0600115B RID: 4443 RVA: 0x000986CC File Offset: 0x000968CC
    private static void IzFadeInit( int group, ushort pause_level, ushort dt_prio, uint draw_state, uint fade_set_type, byte start_col_r, byte start_col_g, byte start_col_b, byte start_col_a, byte end_col_r, byte end_col_g, byte end_col_b, byte end_col_a, float time, bool draw_start )
    {
        bool conti_state = false;
        AppMain.IZS_FADE_WORK fade_work;
        if ( AppMain.iz_fade_tcb == null )
        {
            AppMain.iz_fade_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.izFadeMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.izFadeDest ), 2U, pause_level, 4096U, group, () => new AppMain.IZS_FADE_WORK(), "IZ_FADE_SYS" );
            fade_work = ( AppMain.IZS_FADE_WORK )AppMain.iz_fade_tcb.work;
        }
        else
        {
            fade_work = ( AppMain.IZS_FADE_WORK )AppMain.iz_fade_tcb.work;
            conti_state = true;
        }
        AppMain.IzFadeSetWork( fade_work, dt_prio, draw_state, fade_set_type, start_col_r, start_col_g, start_col_b, start_col_a, end_col_r, end_col_g, end_col_b, end_col_a, time, draw_start, conti_state );
    }

    // Token: 0x0600115C RID: 4444 RVA: 0x00098774 File Offset: 0x00096974
    private static void IzFadeExit()
    {
        if ( AppMain.iz_fade_tcb != null )
        {
            AppMain.IZS_FADE_WORK izs_FADE_WORK = (AppMain.IZS_FADE_WORK)AppMain.iz_fade_tcb.work;
            AppMain.mtTaskChangeTcbProcedure( AppMain.iz_fade_tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.izFadeEndWaitMain ) );
            izs_FADE_WORK.count = 0f;
            AppMain.iz_fade_tcb = null;
        }
    }

    // Token: 0x0600115D RID: 4445 RVA: 0x000987BF File Offset: 0x000969BF
    private static bool IzFadeIsExe()
    {
        return AppMain.iz_fade_tcb != null;
    }

    // Token: 0x0600115E RID: 4446 RVA: 0x000987CC File Offset: 0x000969CC
    private static bool IzFadeIsEnd()
    {
        if ( AppMain.iz_fade_tcb != null )
        {
            AppMain.IZS_FADE_WORK izs_FADE_WORK = (AppMain.IZS_FADE_WORK)AppMain.iz_fade_tcb.work;
            return izs_FADE_WORK.count >= izs_FADE_WORK.time;
        }
        return true;
    }

    // Token: 0x0600115F RID: 4447 RVA: 0x00098803 File Offset: 0x00096A03
    private static void IzFadeRestoreDrawSetting()
    {
        AppMain.nnSetPrimitive2DAlphaFuncGL( 519U, 16f );
        AppMain.nnSetPrimitive2DDepthMaskGL( true );
        AppMain.nnSetPrimitive3DDepthFuncGL( 515U );
        AppMain.nnSetPrimitiveBlend( 0 );
    }

    // Token: 0x06001160 RID: 4448 RVA: 0x0009882A File Offset: 0x00096A2A
    private static void IzFadeSetStopUpdate1Frame( AppMain.IZS_FADE_WORK fade_work )
    {
        if ( fade_work == null && AppMain.iz_fade_tcb != null )
        {
            fade_work = ( AppMain.IZS_FADE_WORK )AppMain.iz_fade_tcb.work;
        }
        if ( fade_work != null )
        {
            fade_work.flag |= 2U;
        }
    }

    // Token: 0x06001161 RID: 4449 RVA: 0x00098858 File Offset: 0x00096A58
    private static void IzFadeSetWork( AppMain.IZS_FADE_WORK fade_work, ushort dt_prio, uint draw_state, uint fade_set_type, byte start_col_r, byte start_col_g, byte start_col_b, byte start_col_a, byte end_col_r, byte end_col_g, byte end_col_b, byte end_col_a, float time, bool draw_start, bool conti_state )
    {
        AppMain.NNS_RGBA start_col = default(AppMain.NNS_RGBA);
        ushort vtx_no = 1;
        if ( !conti_state )
        {
            fade_work.Clear();
            start_col.r = ( float )start_col_r;
            start_col.g = ( float )start_col_g;
            start_col.b = ( float )start_col_b;
            start_col.a = ( float )start_col_a;
        }
        else if ( fade_set_type == 1U )
        {
            start_col = fade_work.now_col;
            vtx_no = fade_work.vtx_no;
        }
        else
        {
            start_col.r = ( float )start_col_r;
            start_col.g = ( float )start_col_g;
            start_col.b = ( float )start_col_b;
            start_col.a = ( float )start_col_a;
        }
        fade_work.count = 0f;
        fade_work.start_col = start_col;
        fade_work.end_col.r = ( float )end_col_r;
        fade_work.end_col.g = ( float )end_col_g;
        fade_work.end_col.b = ( float )end_col_b;
        fade_work.end_col.a = ( float )end_col_a;
        fade_work.now_col = fade_work.start_col;
        fade_work.time = time;
        fade_work.speed = 1f;
        fade_work.dt_prio = dt_prio;
        fade_work.draw_state = draw_state;
        fade_work.vtx_no = vtx_no;
        AppMain.nnMakeUnitMatrix( fade_work.mtx );
        fade_work.flag &= 4294967294U;
        if ( draw_start )
        {
            fade_work.flag |= 1U;
        }
        AppMain.AMS_PARAM_DRAW_PRIMITIVE prim_param = fade_work.prim_param;
        prim_param.vtxPC2D = fade_work.vtx[( int )fade_work.vtx_no];
        prim_param.mtx = fade_work.mtx;
        prim_param.format2D = 1;
        prim_param.type = 1;
        prim_param.count = 4;
        prim_param.texlist = null;
        prim_param.texId = -1;
        prim_param.ablend = 1;
        prim_param.zOffset = -1f;
        AppMain.amDrawGetPrimBlendParam( 0, prim_param );
        prim_param.aTest = 0;
        prim_param.zMask = 1;
        prim_param.zTest = 0;
        for ( int i = 0; i < 2; i++ )
        {
            fade_work.vtx[i][0].Pos.x = 0f;
            fade_work.vtx[i][0].Pos.y = 0f;
            fade_work.vtx[i][1].Pos.x = 0f;
            fade_work.vtx[i][1].Pos.y = AppMain.AMD_SCREEN_HEIGHT;
            fade_work.vtx[i][2].Pos.x = AppMain.AMD_SCREEN_WIDTH;
            fade_work.vtx[i][2].Pos.y = 0f;
            fade_work.vtx[i][3].Pos.x = AppMain.AMD_SCREEN_WIDTH;
            fade_work.vtx[i][3].Pos.y = AppMain.AMD_SCREEN_HEIGHT;
        }
    }

    // Token: 0x06001162 RID: 4450 RVA: 0x00098ADC File Offset: 0x00096CDC
    private static void IzFadeUpdate( AppMain.IZS_FADE_WORK fade_work )
    {
        if ( ( fade_work.flag & 2U ) != 0U )
        {
            fade_work.flag &= 4294967293U;
        }
        else
        {
            fade_work.count += fade_work.speed;
            if ( fade_work.count > fade_work.time )
            {
                fade_work.count = fade_work.time;
            }
        }
        float num = fade_work.count / fade_work.time;
        fade_work.now_col.a = fade_work.start_col.a * ( 1f - num ) + fade_work.end_col.a * num;
        fade_work.now_col.r = fade_work.start_col.r * ( 1f - num ) + fade_work.end_col.r * num;
        fade_work.now_col.g = fade_work.start_col.g * ( 1f - num ) + fade_work.end_col.g * num;
        fade_work.now_col.b = fade_work.start_col.b * ( 1f - num ) + fade_work.end_col.b * num;
        byte r = (byte)AppMain.nnRoundOff(fade_work.now_col.r + 0.5f);
        byte g = (byte)AppMain.nnRoundOff(fade_work.now_col.g + 0.5f);
        byte b = (byte)AppMain.nnRoundOff(fade_work.now_col.b + 0.5f);
        byte a = (byte)AppMain.nnRoundOff(fade_work.now_col.a + 0.5f);
        fade_work.vtx_no += 1;
        if ( fade_work.vtx_no >= 2 )
        {
            fade_work.vtx_no = 0;
        }
        AppMain.ArrayPointer<AppMain.NNS_PRIM2D_PC> pointer = new AppMain.ArrayPointer<AppMain.NNS_PRIM2D_PC>(fade_work.vtx[(int)fade_work.vtx_no], 0);
        int i = 0;
        while ( i < 4 )
        {
            ( ~pointer ).Col = AppMain.IZM_FADE_COL_PAC( ( uint )r, ( uint )g, ( uint )b, ( uint )a );
            i++;
            pointer = ++pointer;
        }
    }

    // Token: 0x06001163 RID: 4451 RVA: 0x00098CB4 File Offset: 0x00096EB4
    private static void IzFadeDraw( AppMain.IZS_FADE_WORK fade_work )
    {
        fade_work.prim_param.vtxPC2D = fade_work.vtx[( int )fade_work.vtx_no];
        AppMain.amDrawPrim2D( fade_work.draw_state, fade_work.prim_param );
        if ( ( fade_work.flag & 1U ) != 0U )
        {
            AppMain.IZS_FADE_DT_WORK izs_FADE_DT_WORK = new AppMain.IZS_FADE_DT_WORK();
            izs_FADE_DT_WORK.draw_state = fade_work.draw_state;
            izs_FADE_DT_WORK.drawflag = 0U;
            AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.izFadeDrawStart_DT ), fade_work.dt_prio, izs_FADE_DT_WORK );
        }
    }

    // Token: 0x06001164 RID: 4452 RVA: 0x00098D25 File Offset: 0x00096F25
    private static void izFadeDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06001165 RID: 4453 RVA: 0x00098D28 File Offset: 0x00096F28
    private static void izFadeMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.IZS_FADE_WORK fade_work = (AppMain.IZS_FADE_WORK)tcb.work;
        AppMain.IzFadeUpdate( fade_work );
        AppMain.IzFadeDraw( fade_work );
    }

    // Token: 0x06001166 RID: 4454 RVA: 0x00098D50 File Offset: 0x00096F50
    private static void izFadeEndWaitMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.IZS_FADE_WORK izs_FADE_WORK = (AppMain.IZS_FADE_WORK)tcb.work;
        izs_FADE_WORK.count += 1f;
        if ( izs_FADE_WORK.count > 1f )
        {
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x06001167 RID: 4455 RVA: 0x00098D90 File Offset: 0x00096F90
    private static void izFadeDrawStart_DT( AppMain.AMS_TCB am_tcb )
    {
        AppMain.IZS_FADE_DT_WORK izs_FADE_DT_WORK = (AppMain.IZS_FADE_DT_WORK)AppMain.amTaskGetWork(am_tcb);
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( izs_FADE_DT_WORK.draw_state, izs_FADE_DT_WORK.drawflag );
        AppMain.amDrawEndScene();
        AppMain.IzFadeRestoreDrawSetting();
    }
}