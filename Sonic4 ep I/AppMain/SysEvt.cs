using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002B7 RID: 695
    public class SYS_EVT_DATA
    {
        // Token: 0x06002493 RID: 9363 RVA: 0x0014AF20 File Offset: 0x00149120
        public SYS_EVT_DATA( AppMain.SYS_EVT_DATA._init_func_ f1, AppMain.SYS_EVT_DATA._exit_func_ f2, AppMain.SYS_EVT_DATA._reset_func_ f3, AppMain.SYS_EVT_DATA._init_sys_func_ f4, AppMain.SYS_EVT_DATA._exit_sys_func_ f5, short[] ar, uint at )
        {
            this.init_func = f1;
            this.exit_func = f2;
            this.reset_func = f3;
            this.init_sys_func = f4;
            this.exit_sys_func = f5;
            this.next_evt_id = ar;
            this.attr = at;
        }

        // Token: 0x06002494 RID: 9364 RVA: 0x0014AF5D File Offset: 0x0014915D
        public SYS_EVT_DATA()
        {
        }

        // Token: 0x04005BF9 RID: 23545
        public AppMain.SYS_EVT_DATA._init_func_ init_func;

        // Token: 0x04005BFA RID: 23546
        public AppMain.SYS_EVT_DATA._exit_func_ exit_func;

        // Token: 0x04005BFB RID: 23547
        public AppMain.SYS_EVT_DATA._reset_func_ reset_func;

        // Token: 0x04005BFC RID: 23548
        public AppMain.SYS_EVT_DATA._init_sys_func_ init_sys_func;

        // Token: 0x04005BFD RID: 23549
        public AppMain.SYS_EVT_DATA._exit_sys_func_ exit_sys_func;

        // Token: 0x04005BFE RID: 23550
        public short[] next_evt_id;

        // Token: 0x04005BFF RID: 23551
        public uint attr;

        // Token: 0x020002B8 RID: 696
        // (Invoke) Token: 0x06002496 RID: 9366
        public delegate void _init_func_( object obj );

        // Token: 0x020002B9 RID: 697
        // (Invoke) Token: 0x0600249A RID: 9370
        public delegate void _exit_func_();

        // Token: 0x020002BA RID: 698
        // (Invoke) Token: 0x0600249E RID: 9374
        public delegate void _reset_func_();

        // Token: 0x020002BB RID: 699
        // (Invoke) Token: 0x060024A2 RID: 9378
        public delegate void _init_sys_func_();

        // Token: 0x020002BC RID: 700
        // (Invoke) Token: 0x060024A6 RID: 9382
        public delegate void _exit_sys_func_();
    }

    // Token: 0x020002BD RID: 701
    private class SYS_EVT_INFO
    {
        // Token: 0x04005C00 RID: 23552
        public AppMain.SYS_EVT_DATA[] evt_data;

        // Token: 0x04005C01 RID: 23553
        public int evt_data_num;

        // Token: 0x04005C02 RID: 23554
        public AppMain.SYS_EVT_DATA cur_evt_data;

        // Token: 0x04005C03 RID: 23555
        public short cur_evt_id;

        // Token: 0x04005C04 RID: 23556
        public short old_evt_id;

        // Token: 0x04005C05 RID: 23557
        public AppMain.SYS_EVT_DATA next_evt_data;

        // Token: 0x04005C06 RID: 23558
        public short req_evt_id;

        // Token: 0x04005C07 RID: 23559
        public short req_evt_case;

        // Token: 0x04005C08 RID: 23560
        public uint flag;

        // Token: 0x04005C09 RID: 23561
        public uint arg_size;

        // Token: 0x04005C0A RID: 23562
        public sbyte[] arg = new sbyte[8];
    }

    // Token: 0x06001389 RID: 5001 RVA: 0x000AE3F4 File Offset: 0x000AC5F4
    private static void SyInitEvtSys( AppMain.SYS_EVT_DATA[] evt_data, int evt_data_num, short start_evt_id, bool tcb_use, ushort pri, byte group )
    {
        if ( tcb_use )
        {
            AppMain.sy_evt_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.syEvtSys ), null, 3U, 0, ( uint )pri, ( int )group, null, "SY_EVT_SYS" );
        }
        AppMain.sy_evt_info = new AppMain.SYS_EVT_INFO();
        AppMain.sy_evt_info.evt_data = evt_data;
        AppMain.sy_evt_info.evt_data_num = evt_data_num;
        AppMain.sy_evt_info.cur_evt_data = evt_data[0];
        AppMain.sy_evt_info.next_evt_data = null;
        AppMain.sy_evt_info.cur_evt_id = 0;
        AppMain.sy_evt_info.req_evt_id = 0;
        AppMain.sy_evt_info.flag = 0U;
        AppMain.SyDecideEvt( start_evt_id );
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x0600138A RID: 5002 RVA: 0x000AE48B File Offset: 0x000AC68B
    private static void SyExitEvtSys()
    {
        if ( AppMain.sy_evt_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.sy_evt_tcb );
            AppMain.sy_evt_tcb = null;
        }
    }

    // Token: 0x0600138B RID: 5003 RVA: 0x000AE4A4 File Offset: 0x000AC6A4
    private static AppMain.SYS_EVT_INFO SyGetEvtInfo()
    {
        return AppMain.sy_evt_info;
    }

    // Token: 0x0600138C RID: 5004 RVA: 0x000AE4AB File Offset: 0x000AC6AB
    public static void SyDecideEvtCase( short evt_case )
    {
        if ( AppMain.sy_evt_info.cur_evt_data.next_evt_id[( int )evt_case] == 0 )
        {
            evt_case = 0;
        }
        AppMain.sy_evt_info.req_evt_case = evt_case;
        AppMain.SyDecideEvt( AppMain.sy_evt_info.cur_evt_data.next_evt_id[( int )evt_case] );
    }

    // Token: 0x0600138D RID: 5005 RVA: 0x000AE4E4 File Offset: 0x000AC6E4
    private static void SyDecideEvtIdCase( short req_id )
    {
        int num = 0;
        while ( num < 8 && AppMain.sy_evt_info.cur_evt_data.next_evt_id[num] != 0 && AppMain.sy_evt_info.cur_evt_data.next_evt_id[num] != req_id )
        {
            num++;
        }
        if ( num >= 8 || AppMain.sy_evt_info.cur_evt_data.next_evt_id[num] == 0 )
        {
            req_id = AppMain.sy_evt_info.cur_evt_data.next_evt_id[0];
        }
        AppMain.SyDecideEvt( req_id );
    }

    // Token: 0x0600138E RID: 5006 RVA: 0x000AE554 File Offset: 0x000AC754
    private static void SyDecideEvt( short req_id )
    {
        if ( req_id <= 0 || AppMain.sy_evt_info.evt_data_num <= ( int )req_id )
        {
            return;
        }
        AppMain.sy_evt_info.req_evt_id = req_id;
        AppMain.syDecideNextEvt();
    }

    // Token: 0x0600138F RID: 5007 RVA: 0x000AE578 File Offset: 0x000AC778
    public static void SyChangeNextEvt()
    {
        AppMain.SYS_EVT_DATA cur_evt_data = AppMain.sy_evt_info.cur_evt_data;
        if ( AppMain.sy_evt_info.req_evt_id < 0 )
        {
            AppMain.sy_evt_info.req_evt_id = cur_evt_data.next_evt_id[0];
        }
        AppMain.sy_evt_info.flag = 1U;
        AppMain.sy_evt_info.arg_size = 0U;
        AppMain.sy_evt_info.arg = new sbyte[8];
    }

    // Token: 0x06001390 RID: 5008 RVA: 0x000AE5D5 File Offset: 0x000AC7D5
    private static void SyChangeNextEvtArg( uint arg_size, sbyte[] arg_buf )
    {
        AppMain.SyChangeNextEvt();
        if ( arg_size > 8U )
        {
            arg_size = 8U;
        }
        if ( arg_size != 0U )
        {
            Array.Copy( AppMain.sy_evt_info.arg, arg_buf, ( int )arg_size );
            arg_buf = new sbyte[arg_size];
            AppMain.sy_evt_info.arg_size = arg_size;
        }
    }

    // Token: 0x06001391 RID: 5009 RVA: 0x000AE60B File Offset: 0x000AC80B
    private static bool SYM_CHECK_EVT_DATA_BRUNCH( AppMain.SYS_EVT_DATA _sy_evt_data )
    {
        return 0 < _sy_evt_data.next_evt_id[1];
    }

    // Token: 0x06001392 RID: 5010 RVA: 0x000AE61C File Offset: 0x000AC81C
    private static void syEvtSys( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.sy_evt_info.flag == 1U )
        {
            AppMain.SYS_EVT_DATA cur_evt_data = AppMain.sy_evt_info.cur_evt_data;
            if ( cur_evt_data.exit_func != null )
            {
                cur_evt_data.exit_func();
            }
            if ( cur_evt_data.exit_sys_func != null )
            {
                cur_evt_data.exit_sys_func();
            }
            AppMain.sy_evt_info.old_evt_id = AppMain.sy_evt_info.cur_evt_id;
            AppMain.sy_evt_info.cur_evt_id = AppMain.sy_evt_info.req_evt_id;
            AppMain.sy_evt_info.cur_evt_data = AppMain.sy_evt_info.evt_data[( int )AppMain.sy_evt_info.cur_evt_id];
            cur_evt_data = AppMain.sy_evt_info.cur_evt_data;
            AppMain.sy_evt_info.req_evt_id = -1;
            if ( !AppMain.SYM_CHECK_EVT_DATA_BRUNCH( cur_evt_data ) )
            {
                AppMain.sy_evt_info.req_evt_id = cur_evt_data.next_evt_id[0];
                AppMain.syDecideNextEvt();
            }
            AppMain.syEvtSysOvlCallBack();
        }
    }

    // Token: 0x06001393 RID: 5011 RVA: 0x000AE6EC File Offset: 0x000AC8EC
    private static void syEvtSysOvlCallBack()
    {
        AppMain.SYS_EVT_DATA cur_evt_data = AppMain.sy_evt_info.cur_evt_data;
        AppMain.sy_evt_info.flag = 0U;
        if ( cur_evt_data.init_sys_func != null )
        {
            cur_evt_data.init_sys_func();
        }
        if ( cur_evt_data.init_func != null )
        {
            sbyte[] obj = null;
            if ( AppMain.sy_evt_info.arg_size != 0U )
            {
                obj = AppMain.sy_evt_info.arg;
            }
            cur_evt_data.init_func( obj );
        }
    }

    // Token: 0x06001394 RID: 5012 RVA: 0x000AE750 File Offset: 0x000AC950
    private static void syDecideNextEvt()
    {
        if ( AppMain.sy_evt_info.req_evt_id < 0 )
        {
            AppMain.sy_evt_info.req_evt_id = AppMain.sy_evt_info.cur_evt_data.next_evt_id[0];
        }
        AppMain.sy_evt_info.next_evt_data = AppMain.sy_evt_info.evt_data[( int )AppMain.sy_evt_info.req_evt_id];
    }
}