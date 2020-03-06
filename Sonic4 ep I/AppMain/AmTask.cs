using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public partial class AppMain
{
    // Token: 0x020001E9 RID: 489
    // (Invoke) Token: 0x06002303 RID: 8963
    public delegate void TaskProc( AppMain.AMS_TCB tcb );

    // Token: 0x020001EA RID: 490
    public class AMS_TCB : AppMain.IClearable
    {
        // Token: 0x06002306 RID: 8966 RVA: 0x00147CA0 File Offset: 0x00145EA0
        public void Clear()
        {
            this.name = string.Empty;
            this.user_id = 0U;
            this.attribute = 0U;
            this.priority = 0U;
            this.procedure = null;
            this.proc_addr = 0;
            this.destructor = null;
            this.prev = null;
            this.next = null;
            this.taskp = null;
            this.footer.wkend = 0;
        }

        // Token: 0x040054DB RID: 21723
        public string name;

        // Token: 0x040054DC RID: 21724
        public uint user_id;

        // Token: 0x040054DD RID: 21725
        public uint attribute;

        // Token: 0x040054DE RID: 21726
        public uint priority;

        // Token: 0x040054DF RID: 21727
        public AppMain.TaskProc procedure;

        // Token: 0x040054E0 RID: 21728
        public int proc_addr;

        // Token: 0x040054E1 RID: 21729
        public AppMain.TaskProc destructor;

        // Token: 0x040054E2 RID: 21730
        public AppMain.AMS_TCB prev;

        // Token: 0x040054E3 RID: 21731
        public AppMain.AMS_TCB next;

        // Token: 0x040054E4 RID: 21732
        public AppMain.AMS_TASK taskp;

        // Token: 0x040054E5 RID: 21733
        public readonly AppMain.AMS_TCB_FOOTER footer = new AppMain.AMS_TCB_FOOTER();

        // Token: 0x040054E6 RID: 21734
        public int wkbegin;

        // Token: 0x040054E7 RID: 21735
        public object work;
    }

    // Token: 0x020001EB RID: 491
    public class AMS_TCB_FOOTER
    {
        // Token: 0x040054E8 RID: 21736
        public int wkend;

        // Token: 0x040054E9 RID: 21737
        public uint cpu_cnt;

        // Token: 0x040054EA RID: 21738
        public uint cpu_cnt_max;
    }

    // Token: 0x020001EC RID: 492
    public class AMS_TASKLIST_OWNER
    {
        // Token: 0x040054EB RID: 21739
        public uint uflag;

        // Token: 0x040054EC RID: 21740
        public string name;
    }

    // Token: 0x020001ED RID: 493
    public class AMS_TCB_REPORT
    {
        // Token: 0x040054ED RID: 21741
        public string name;

        // Token: 0x040054EE RID: 21742
        public float frame_start;

        // Token: 0x040054EF RID: 21743
        public float frame_end;

        // Token: 0x040054F0 RID: 21744
        public AppMain.AMS_TCB_REPORT next;

        // Token: 0x040054F1 RID: 21745
        public int reserved;
    }

    // Token: 0x020001EE RID: 494
    public class AMS_TCB_THREAD
    {
        // Token: 0x040054F2 RID: 21746
        public int id;

        // Token: 0x040054F3 RID: 21747
        public AppMain.AMS_TASK taskp;

        // Token: 0x040054F4 RID: 21748
        public AppMain.AMS_TCB tcbp;

        // Token: 0x040054F5 RID: 21749
        public readonly AppMain.AMS_THREAD thread = new AppMain.AMS_THREAD();

        // Token: 0x040054F6 RID: 21750
        public Thread thread_id;

        // Token: 0x040054F7 RID: 21751
        public readonly AppMain.AMS_ALARM alarm_wakeup = new AppMain.AMS_ALARM();

        // Token: 0x040054F8 RID: 21752
        public AppMain.NNS_MATRIXSTACK matrix_stack;

        // Token: 0x040054F9 RID: 21753
        public byte[] matrix_stack_buf;
    }

    // Token: 0x020001EF RID: 495
    public class AMS_TASK
    {
        // Token: 0x040054FA RID: 21754
        public int tcb_max;

        // Token: 0x040054FB RID: 21755
        public readonly AppMain.AMS_TCB tcb_head = new AppMain.AMS_TCB();

        // Token: 0x040054FC RID: 21756
        public readonly AppMain.AMS_TCB tcb_tail = new AppMain.AMS_TCB();

        // Token: 0x040054FD RID: 21757
        public int tcb_work_size;
    }

    // Token: 0x020001F0 RID: 496
    private struct AMS_TASK_THREAD_MAP_HEADER
    {
        // Token: 0x040054FE RID: 21758
        private int thread_num;

        // Token: 0x040054FF RID: 21759
        private float x0;

        // Token: 0x04005500 RID: 21760
        private float x1;

        // Token: 0x04005501 RID: 21761
        private float y0;

        // Token: 0x04005502 RID: 21762
        private float dy;

        // Token: 0x04005503 RID: 21763
        private float ny;
    }

    // Token: 0x020001F1 RID: 497
    private struct AMS_TASK_THREAD_MAP_THREAD
    {
        // Token: 0x04005504 RID: 21764
        private int thread_tcb_num;
    }

    // Token: 0x020001F2 RID: 498
    private struct AMS_TASK_THREAD_MAP_TCB
    {
        // Token: 0x04005505 RID: 21765
        private float frame_start;

        // Token: 0x04005506 RID: 21766
        private float frame_end;
    }

    // Token: 0x06000A35 RID: 2613 RVA: 0x0005BF68 File Offset: 0x0005A168
    public static AppMain.AMS_TCB amTaskMake( AppMain.TaskProc proc, AppMain.TaskProc dest, uint prio, uint user, uint attr, string name )
    {
        return AppMain.amTaskMake( AppMain._am_default_taskp, proc, dest, prio, user, attr, name, 1U, 0, uint.MaxValue );
    }

    // Token: 0x06000A36 RID: 2614 RVA: 0x0005BF8C File Offset: 0x0005A18C
    public static AppMain.AMS_TCB amTaskMake( AppMain.AMS_TASK taskp, AppMain.TaskProc proc, AppMain.TaskProc dest, uint prio, uint user, uint attr, string name )
    {
        return AppMain.amTaskMake( taskp, proc, dest, prio, user, attr, name, 1U, 0, uint.MaxValue );
    }

    // Token: 0x06000A37 RID: 2615 RVA: 0x0005BFAC File Offset: 0x0005A1AC
    public static AppMain.AMS_TCB amTaskMake( AppMain.TaskProc proc, AppMain.TaskProc dest, uint prio, uint user, uint attr, string name, uint stall, int group, uint run )
    {
        return AppMain.amTaskMake( AppMain._am_default_taskp, proc, dest, prio, user, attr, name, stall, group, run );
    }

    // Token: 0x06000A38 RID: 2616 RVA: 0x0005BFD1 File Offset: 0x0005A1D1
    private static void amTaskSetProcedure( AppMain.AMS_TCB tcb, AppMain.TaskProc proc )
    {
        tcb.procedure = proc;
        tcb.proc_addr = int.MaxValue;
    }

    // Token: 0x06000A39 RID: 2617 RVA: 0x0005BFE5 File Offset: 0x0005A1E5
    private static void amTaskSetDestructor( AppMain.AMS_TCB tcb, AppMain.TaskProc dest )
    {
        tcb.destructor = dest;
    }

    // Token: 0x06000A3A RID: 2618 RVA: 0x0005BFEE File Offset: 0x0005A1EE
    public static void amTaskDeleteGroup( uint user, uint attr, uint flag )
    {
        AppMain.amTaskDeleteGroup( AppMain._am_default_taskp, user, attr, flag );
    }

    // Token: 0x06000A3B RID: 2619 RVA: 0x0005BFFD File Offset: 0x0005A1FD
    public static void amTaskDeletePriority( uint prio_begin, uint prio_end, uint user )
    {
        AppMain.amTaskDeletePriority( AppMain._am_default_taskp, prio_begin, prio_end, user );
    }

    // Token: 0x06000A3C RID: 2620 RVA: 0x0005C00C File Offset: 0x0005A20C
    public static void amTaskSleepGroup( uint user, uint attr, uint flag )
    {
        AppMain.amTaskSleepGroup( AppMain._am_default_taskp, user, attr, flag );
    }

    // Token: 0x06000A3D RID: 2621 RVA: 0x0005C01B File Offset: 0x0005A21B
    public static void amTaskSleepPriority( uint prio_begin, uint prio_end, uint user )
    {
        AppMain.amTaskSleepPriority( AppMain._am_default_taskp, prio_begin, prio_end, user );
    }

    // Token: 0x06000A3E RID: 2622 RVA: 0x0005C02A File Offset: 0x0005A22A
    public static void amTaskWakeupGroup( uint user, uint attr, uint flag )
    {
        AppMain.amTaskWakeupGroup( AppMain._am_default_taskp, user, attr, flag );
    }

    // Token: 0x06000A3F RID: 2623 RVA: 0x0005C039 File Offset: 0x0005A239
    public static void amTaskWakeupPriority( uint prio_begin, uint prio_end, uint user )
    {
        AppMain.amTaskWakeupPriority( AppMain._am_default_taskp, prio_begin, prio_end, user );
    }

    // Token: 0x06000A40 RID: 2624 RVA: 0x0005C048 File Offset: 0x0005A248
    public static object amTaskGetWork( AppMain.AMS_TCB tcb )
    {
        return tcb.work;
    }

    // Token: 0x06000A41 RID: 2625 RVA: 0x0005C050 File Offset: 0x0005A250
    private static AppMain.AMS_TCB amTaskNextTcb( AppMain.AMS_TCB tcbp )
    {
        return tcbp.next = AppMain.GlobalPool<AppMain.AMS_TCB>.Alloc();
    }

    // Token: 0x06000A42 RID: 2626 RVA: 0x0005C06C File Offset: 0x0005A26C
    private static AppMain.AMS_TCB amPrevNextTcb( AppMain.AMS_TCB tcbp )
    {
        return tcbp.prev = AppMain.GlobalPool<AppMain.AMS_TCB>.Alloc();
    }

    // Token: 0x06000A43 RID: 2627 RVA: 0x0005C087 File Offset: 0x0005A287
    private static AppMain.AMS_TCB_FOOTER amTaskGetTcbFooter( AppMain.AMS_TCB tcbp )
    {
        return tcbp.footer;
    }

    // Token: 0x06000A44 RID: 2628 RVA: 0x0005C08F File Offset: 0x0005A28F
    private static AppMain.AMS_TASK amTaskInitSystem()
    {
        return AppMain.amTaskInitSystem( 256, 64, 1 );
    }

    // Token: 0x06000A45 RID: 2629 RVA: 0x0005C0A0 File Offset: 0x0005A2A0
    private static AppMain.AMS_TASK amTaskInitSystem( int max_tcb, int work_size, int thread_num )
    {
        AppMain.AMS_TASK ams_TASK = new AppMain.AMS_TASK();
        if ( AppMain._am_default_taskp == null )
        {
            AppMain._am_default_taskp = ams_TASK;
        }
        ams_TASK.tcb_max = max_tcb;
        ams_TASK.tcb_work_size = ( work_size + 63 & -64 );
        ams_TASK.tcb_head.name = "TCB Head";
        ams_TASK.tcb_head.priority = 0U;
        ams_TASK.tcb_head.prev = null;
        ams_TASK.tcb_head.next = ams_TASK.tcb_tail;
        ams_TASK.tcb_head.user_id = 0U;
        ams_TASK.tcb_head.attribute = 1U;
        ams_TASK.tcb_head.wkbegin = 218237452;
        AppMain.amTaskSetProcedure( ams_TASK.tcb_head, null );
        AppMain.amTaskSetDestructor( ams_TASK.tcb_head, null );
        ams_TASK.tcb_tail.name = "TCB Tail";
        ams_TASK.tcb_tail.priority = uint.MaxValue;
        ams_TASK.tcb_tail.prev = ams_TASK.tcb_head;
        ams_TASK.tcb_tail.next = null;
        ams_TASK.tcb_tail.user_id = 0U;
        ams_TASK.tcb_tail.attribute = 1U;
        ams_TASK.tcb_tail.wkbegin = 218237452;
        AppMain.amTaskSetProcedure( ams_TASK.tcb_tail, null );
        AppMain.amTaskSetDestructor( ams_TASK.tcb_tail, null );
        return ams_TASK;
    }

    // Token: 0x06000A46 RID: 2630 RVA: 0x0005C1C7 File Offset: 0x0005A3C7
    private static void amTaskExitSystem()
    {
        AppMain.amTaskExitSystem( AppMain._am_default_taskp );
    }

    // Token: 0x06000A47 RID: 2631 RVA: 0x0005C1D3 File Offset: 0x0005A3D3
    private static void amTaskExitSystem( AppMain.AMS_TASK taskp )
    {
        AppMain.amMemFreeSystem( taskp );
    }

    // Token: 0x06000A48 RID: 2632 RVA: 0x0005C1DB File Offset: 0x0005A3DB
    private static void amTaskReset( AppMain.AMS_TASK taskp )
    {
        taskp.tcb_head.next = taskp.tcb_tail;
        taskp.tcb_tail.prev = taskp.tcb_head;
    }

    // Token: 0x06000A49 RID: 2633 RVA: 0x0005C1FF File Offset: 0x0005A3FF
    private static void amTaskExecute()
    {
        AppMain.amTaskExecute( AppMain._am_default_taskp );
    }

    // Token: 0x06000A4A RID: 2634 RVA: 0x0005C20B File Offset: 0x0005A40B
    private static void amTaskExecute( AppMain.AMS_TASK taskp )
    {
        AppMain._amTaskExecuteInOrder( taskp );
    }

    // Token: 0x06000A4B RID: 2635 RVA: 0x0005C214 File Offset: 0x0005A414
    private static AppMain.AMS_TCB amTaskMake( AppMain.AMS_TASK taskp, AppMain.TaskProc proc, AppMain.TaskProc dest, uint prio, uint user, uint attr, string name, uint stall, int group, uint run )
    {
        AppMain.AMS_TCB ams_TCB = AppMain.GlobalPool<AppMain.AMS_TCB>.Alloc();
        ams_TCB.name = name;
        AppMain.AMS_TCB_FOOTER ams_TCB_FOOTER = AppMain.amTaskGetTcbFooter(ams_TCB);
        ams_TCB_FOOTER.cpu_cnt = 0U;
        ams_TCB_FOOTER.cpu_cnt_max = 0U;
        ams_TCB.priority = prio;
        ams_TCB.priority = prio;
        ams_TCB.user_id = user;
        ams_TCB.attribute = attr;
        AppMain.amTaskSetProcedure( ams_TCB, proc );
        AppMain.amTaskSetDestructor( ams_TCB, dest );
        AppMain.AMS_TCB next = taskp.tcb_head.next;
        while ( next != taskp.tcb_tail && next.priority <= prio )
        {
            next = next.next;
        }
        next.prev.next = ams_TCB;
        ams_TCB.prev = next.prev;
        next.prev = ams_TCB;
        ams_TCB.next = next;
        return ams_TCB;
    }

    // Token: 0x06000A4C RID: 2636 RVA: 0x0005C2BE File Offset: 0x0005A4BE
    private int amTaskPending( AppMain.AMS_TCB tcbp )
    {
        return 0;
    }

    // Token: 0x06000A4D RID: 2637 RVA: 0x0005C2C1 File Offset: 0x0005A4C1
    public static int amTaskStart( AppMain.AMS_TCB tcbp )
    {
        return 0;
    }

    // Token: 0x06000A4E RID: 2638 RVA: 0x0005C2C4 File Offset: 0x0005A4C4
    public static void amTaskDelete( AppMain.AMS_TCB tcb )
    {
        if ( tcb.proc_addr == -1 )
        {
            return;
        }
        if ( tcb.destructor != null )
        {
            tcb.destructor( tcb );
        }
        tcb.proc_addr = -1;
    }

    // Token: 0x06000A4F RID: 2639 RVA: 0x0005C2EC File Offset: 0x0005A4EC
    public static void amTaskDeleteGroup( AppMain.AMS_TASK taskp, uint user, uint attr, uint flag )
    {
        if ( user == 0U )
        {
            user = uint.MaxValue;
        }
        AppMain.AMS_TCB next = taskp.tcb_head.next;
        switch ( flag )
        {
            case 0U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) != 0U )
                    {
                        AppMain.amTaskDelete( next );
                    }
                    next = next.next;
                }
                return;
            case 1U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) == attr )
                    {
                        AppMain.amTaskDelete( next );
                    }
                    next = next.next;
                }
                return;
            case 2U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) == 0U )
                    {
                        AppMain.amTaskDelete( next );
                    }
                    next = next.next;
                }
                return;
            case 3U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) != attr )
                    {
                        AppMain.amTaskDelete( next );
                    }
                    next = next.next;
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06000A50 RID: 2640 RVA: 0x0005C3D4 File Offset: 0x0005A5D4
    public static void amTaskDeletePriority( AppMain.AMS_TASK taskp, uint prio_begin, uint prio_end, uint user )
    {
        AppMain.AMS_TCB next;
        for ( next = taskp.tcb_head.next; next != taskp.tcb_tail; next = next.next )
        {
            if ( next.priority >= prio_begin )
            {
                break;
            }
        }
        while ( next != taskp.tcb_tail && next.priority <= prio_end )
        {
            if ( user == 0U || ( next.user_id & user ) != 0U )
            {
                AppMain.amTaskDelete( next );
            }
            next = next.next;
        }
    }

    // Token: 0x06000A51 RID: 2641 RVA: 0x0005C436 File Offset: 0x0005A636
    public static void amTaskSleep( AppMain.AMS_TCB tcb )
    {
        tcb.proc_addr |= 1;
    }

    // Token: 0x06000A52 RID: 2642 RVA: 0x0005C448 File Offset: 0x0005A648
    public static void amTaskSleepGroup( AppMain.AMS_TASK taskp, uint user, uint attr, uint flag )
    {
        AppMain.mppAssertNotImpl();
        if ( user == 0U )
        {
            user = uint.MaxValue;
        }
        AppMain.AMS_TCB next = taskp.tcb_head.next;
        switch ( flag )
        {
            case 0U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) != 0U )
                    {
                        AppMain.amTaskSleep( next );
                    }
                    next = next.next;
                }
                return;
            case 1U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) == attr )
                    {
                        AppMain.amTaskSleep( next );
                    }
                    next = next.next;
                }
                return;
            case 2U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) == 0U )
                    {
                        AppMain.amTaskSleep( next );
                    }
                    next = next.next;
                }
                return;
            case 3U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) != attr )
                    {
                        AppMain.amTaskSleep( next );
                    }
                    next = next.next;
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06000A53 RID: 2643 RVA: 0x0005C534 File Offset: 0x0005A734
    public static void amTaskSleepPriority( AppMain.AMS_TASK taskp, uint prio_begin, uint prio_end, uint user )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_TCB next;
        for ( next = taskp.tcb_head.next; next != taskp.tcb_tail; next = next.next )
        {
            if ( next.priority >= prio_begin )
            {
                break;
            }
        }
        while ( next != taskp.tcb_tail && next.priority <= prio_end )
        {
            if ( user == 0U || ( next.user_id & user ) != 0U )
            {
                AppMain.amTaskSleep( next );
            }
            next = next.next;
        }
    }

    // Token: 0x06000A54 RID: 2644 RVA: 0x0005C59B File Offset: 0x0005A79B
    public static void amTaskWakeup( AppMain.AMS_TCB tcb )
    {
        AppMain.mppAssertNotImpl();
        tcb.proc_addr &= -2;
    }

    // Token: 0x06000A55 RID: 2645 RVA: 0x0005C5B4 File Offset: 0x0005A7B4
    public static void amTaskWakeupGroup( AppMain.AMS_TASK taskp, uint user, uint attr, uint flag )
    {
        AppMain.mppAssertNotImpl();
        if ( user == 0U )
        {
            user = uint.MaxValue;
        }
        AppMain.AMS_TCB next = taskp.tcb_head.next;
        switch ( flag )
        {
            case 0U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) != 0U )
                    {
                        AppMain.amTaskWakeup( next );
                    }
                    next = next.next;
                }
                return;
            case 1U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) == attr )
                    {
                        AppMain.amTaskWakeup( next );
                    }
                    next = next.next;
                }
                return;
            case 2U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) == 0U )
                    {
                        AppMain.amTaskWakeup( next );
                    }
                    next = next.next;
                }
                return;
            case 3U:
                while ( next != taskp.tcb_tail )
                {
                    if ( ( next.user_id & user ) != 0U && ( next.attribute & attr ) != attr )
                    {
                        AppMain.amTaskWakeup( next );
                    }
                    next = next.next;
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06000A56 RID: 2646 RVA: 0x0005C6A0 File Offset: 0x0005A8A0
    public static void amTaskWakeupPriority( AppMain.AMS_TASK taskp, uint prio_begin, uint prio_end, uint user )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_TCB next;
        for ( next = taskp.tcb_head.next; next != taskp.tcb_tail; next = next.next )
        {
            if ( next.priority >= prio_begin )
            {
                break;
            }
        }
        while ( next != taskp.tcb_tail && next.priority <= prio_end )
        {
            if ( user == 0U || ( next.user_id & user ) != 0U )
            {
                AppMain.amTaskWakeup( next );
            }
            next = next.next;
        }
    }

    // Token: 0x06000A57 RID: 2647 RVA: 0x0005C707 File Offset: 0x0005A907
    private static void amTaskSetOwnerName( AppMain.AMS_TASKLIST_OWNER[] pList, uint listSize )
    {
        AppMain.mppAssertNotImpl();
        AppMain._am_owner_list = pList;
        AppMain._am_szOwnerList = ( int )( ( AppMain._am_owner_list != null ) ? listSize : 0U );
    }

    // Token: 0x06000A58 RID: 2648 RVA: 0x0005C724 File Offset: 0x0005A924
    private static void amTaskDisplayList( AppMain.AMS_TASK taskp, int locx, int locy )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A59 RID: 2649 RVA: 0x0005C72B File Offset: 0x0005A92B
    private static void amTaskDisplayThread( AppMain.AMS_TASK taskp )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A5A RID: 2650 RVA: 0x0005C734 File Offset: 0x0005A934
    private static void _amTaskExecuteInOrder( AppMain.AMS_TASK taskp )
    {
        for ( AppMain.AMS_TCB next = taskp.tcb_head.next; next != taskp.tcb_tail; next = next.next )
        {
            if ( next.procedure != null && next.proc_addr > 0 )
            {
                next.procedure( next );
            }
        }
        for ( AppMain.AMS_TCB next = taskp.tcb_head.next; next != taskp.tcb_tail; next = next.next )
        {
            if ( next.proc_addr == -1 )
            {
                AppMain._amTaskDeleteReal( next );
            }
        }
    }

    // Token: 0x06000A5B RID: 2651 RVA: 0x0005C7A9 File Offset: 0x0005A9A9
    private static void _amTaskDeleteReal( AppMain.AMS_TCB tcb )
    {
        AppMain.AMS_TASK taskp = tcb.taskp;
        tcb.prev.next = tcb.next;
        tcb.next.prev = tcb.prev;
        AppMain.GlobalPool<AppMain.AMS_TCB>.Release( tcb );
    }

    // Token: 0x06000A5C RID: 2652 RVA: 0x0005C7DA File Offset: 0x0005A9DA
    private static void _amTaskCheckWork( AppMain.AMS_TASK taskp )
    {
        AppMain.mppAssertNotImpl();
    }
}
