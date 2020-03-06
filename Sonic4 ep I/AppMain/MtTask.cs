using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000337 RID: 823
    public class MTS_TASK_TCB
    {
        // Token: 0x060025B2 RID: 9650 RVA: 0x0014E269 File Offset: 0x0014C469
        public void Clear()
        {
            this.am_tcb = null;
            this.proc = null;
            this.dest = null;
            this.pause_level = 0;
            this.work = null;
        }

        // Token: 0x04005E66 RID: 24166
        public AppMain.AMS_TCB am_tcb;

        // Token: 0x04005E67 RID: 24167
        public AppMain.GSF_TASK_PROCEDURE proc;

        // Token: 0x04005E68 RID: 24168
        public AppMain.GSF_TASK_PROCEDURE dest;

        // Token: 0x04005E69 RID: 24169
        public ushort pause_level;

        // Token: 0x04005E6A RID: 24170
        public object work;
    }

    // Token: 0x060016D4 RID: 5844 RVA: 0x000C738F File Offset: 0x000C558F
    public static AppMain.MTS_TASK_TCB MTM_TASK_MAKE_TCB( AppMain.GSF_TASK_PROCEDURE proc, AppMain.GSF_TASK_PROCEDURE dest, uint flag, ushort pause_level, uint prio, int group, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return AppMain.mtTaskMake( proc, dest, flag, pause_level, prio, group, work_size, name );
    }

    // Token: 0x060016D5 RID: 5845 RVA: 0x000C73A4 File Offset: 0x000C55A4
    private static void mtTaskInitSystem()
    {
        if ( AppMain.gs_task_mt_system_tcb != null )
        {
            return;
        }
        AppMain.gs_task_mt_system_tcb = AppMain.mtTaskMake( new AppMain.GSF_TASK_PROCEDURE( AppMain.mtTaskSystemMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.mtTaskSystemDest ), 2147483648U, ushort.MaxValue, 0U, 15, null, "GS_TASKMT_SYS" );
        AppMain.gs_task_mtsys = default( AppMain.GSS_TASK_SYS );
        AppMain.gs_task_mtsys.pause_level = -1;
        AppMain.gs_task_mtsys.pause_level_set = -1;
    }

    // Token: 0x060016D6 RID: 5846 RVA: 0x000C740F File Offset: 0x000C560F
    private static void mtTaskExitSystem()
    {
        AppMain.mtTaskClearTcb( AppMain.gs_task_mt_system_tcb );
    }

    // Token: 0x060016D7 RID: 5847 RVA: 0x000C741C File Offset: 0x000C561C
    public static AppMain.MTS_TASK_TCB mtTaskMake( AppMain.GSF_TASK_PROCEDURE proc, AppMain.GSF_TASK_PROCEDURE dest, uint flag, ushort pause_level, uint prio, int group, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        if ( ( flag & 2147483648U ) == 0U && group >= 15 )
        {
            group = 14;
        }
        AppMain.AMS_TCB ams_TCB = AppMain.amTaskMake(AppMain._mtTaskProcedure, AppMain._mtTaskDestructor, prio, 1U << group, 2U, name);
        ams_TCB.work = new AppMain.MTS_TASK_TCB();
        AppMain.MTS_TASK_TCB mts_TASK_TCB = (AppMain.MTS_TASK_TCB)AppMain.amTaskGetWork(ams_TCB);
        mts_TASK_TCB.am_tcb = ams_TCB;
        mts_TASK_TCB.proc = proc;
        mts_TASK_TCB.dest = dest;
        mts_TASK_TCB.pause_level = pause_level;
        if ( ( flag & 1U ) != 0U )
        {
            mts_TASK_TCB.pause_level = ushort.MaxValue;
        }
        mts_TASK_TCB.work = null;
        if ( work_size != null )
        {
            mts_TASK_TCB.work = work_size();
        }
        AppMain.amTaskStart( ams_TCB );
        return mts_TASK_TCB;
    }

    // Token: 0x060016D8 RID: 5848 RVA: 0x000C74BB File Offset: 0x000C56BB
    private static AppMain.AMS_TCB mtTaskGetAmTcb( AppMain.MTS_TASK_TCB tcb )
    {
        return tcb.am_tcb;
    }

    // Token: 0x060016D9 RID: 5849 RVA: 0x000C74C3 File Offset: 0x000C56C3
    private static AppMain.OBS_OBJECT_WORK mtTaskGetTcbWork( AppMain.MTS_TASK_TCB tcb )
    {
        if ( tcb.work is AppMain.IOBS_OBJECT_WORK )
        {
            return ( ( AppMain.IOBS_OBJECT_WORK )tcb.work ).Cast();
        }
        return ( AppMain.OBS_OBJECT_WORK )tcb.work;
    }

    // Token: 0x060016DA RID: 5850 RVA: 0x000C74EE File Offset: 0x000C56EE
    private static void mtTaskChangeTcbProcedure( AppMain.MTS_TASK_TCB tcb, AppMain.GSF_TASK_PROCEDURE proc )
    {
        tcb.proc = proc;
    }

    // Token: 0x060016DB RID: 5851 RVA: 0x000C74F7 File Offset: 0x000C56F7
    private static void mtTaskChangeTcbDestructor( AppMain.MTS_TASK_TCB tcb, AppMain.GSF_TASK_PROCEDURE dest )
    {
        tcb.dest = dest;
    }

    // Token: 0x060016DC RID: 5852 RVA: 0x000C7500 File Offset: 0x000C5700
    private static void mtTaskClearTcb( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.amTaskDelete( tcb.am_tcb );
    }

    // Token: 0x060016DD RID: 5853 RVA: 0x000C750D File Offset: 0x000C570D
    private static void mtTaskClearTcbAll()
    {
        AppMain.amTaskDeleteGroup( uint.MaxValue, 2U, 1U );
    }

    // Token: 0x060016DE RID: 5854 RVA: 0x000C7517 File Offset: 0x000C5717
    private static void mtTaskClearPriority( uint prio_begin, uint prio_end )
    {
        AppMain.amTaskDeletePriority( prio_begin, prio_end, uint.MaxValue );
    }

    // Token: 0x060016DF RID: 5855 RVA: 0x000C7521 File Offset: 0x000C5721
    private static void mtTaskClearGroup( int group )
    {
        AppMain.amTaskDeleteGroup( 1U << group, 2U, 1U );
    }

    // Token: 0x060016E0 RID: 5856 RVA: 0x000C7530 File Offset: 0x000C5730
    private static void mtTaskStartPause( ushort pause_level )
    {
        if ( pause_level >= 65535 )
        {
            pause_level = 65534;
        }
        AppMain.gs_task_mtsys.pause_level_set = ( int )pause_level;
    }

    // Token: 0x060016E1 RID: 5857 RVA: 0x000C754C File Offset: 0x000C574C
    private static void mtTaskEndPause()
    {
        AppMain.gs_task_mtsys.pause_level_set = -1;
    }

    // Token: 0x060016E2 RID: 5858 RVA: 0x000C7559 File Offset: 0x000C5759
    private static bool mtTaskIsPaused( ref ushort pause_level )
    {
        if ( pause_level != 0 )
        {
            if ( AppMain.gs_task_mtsys.pause_level_set >= 0 )
            {
                pause_level = ( ushort )AppMain.gs_task_mtsys.pause_level_set;
            }
            else
            {
                pause_level = 0;
            }
        }
        return AppMain.gs_task_mtsys.pause_level_set >= 0;
    }

    // Token: 0x060016E3 RID: 5859 RVA: 0x000C758E File Offset: 0x000C578E
    private static void mtTaskSystemMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gs_task_mtsys.pause_level = AppMain.gs_task_mtsys.pause_level_set;
    }

    // Token: 0x060016E4 RID: 5860 RVA: 0x000C75A4 File Offset: 0x000C57A4
    private static void mtTaskSystemDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gs_task_mt_system_tcb = null;
        AppMain.gs_task_mtsys = default( AppMain.GSS_TASK_SYS );
    }

    // Token: 0x060016E5 RID: 5861 RVA: 0x000C75B8 File Offset: 0x000C57B8
    public static void mtTaskProcedure( AppMain.AMS_TCB am_tcb )
    {
        AppMain.MTS_TASK_TCB mts_TASK_TCB = (AppMain.MTS_TASK_TCB)AppMain.amTaskGetWork(am_tcb);
        if ( ( int )mts_TASK_TCB.pause_level <= AppMain.gs_task_mtsys.pause_level )
        {
            return;
        }
        if ( mts_TASK_TCB.proc != null )
        {
            mts_TASK_TCB.proc( mts_TASK_TCB );
        }
    }

    // Token: 0x060016E6 RID: 5862 RVA: 0x000C75F8 File Offset: 0x000C57F8
    public static void mtTaskDestructor( AppMain.AMS_TCB am_tcb )
    {
        AppMain.MTS_TASK_TCB mts_TASK_TCB = (AppMain.MTS_TASK_TCB)AppMain.amTaskGetWork(am_tcb);
        if ( mts_TASK_TCB.dest != null )
        {
            mts_TASK_TCB.dest( mts_TASK_TCB );
        }
        if ( mts_TASK_TCB.work != null && mts_TASK_TCB.work is AppMain.GMS_EFFECT_3DES_WORK )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)mts_TASK_TCB.work;
            gms_EFFECT_3DES_WORK.Clear();
            AppMain.GMS_EFFECT_3DES_WORK_Pool.Release( gms_EFFECT_3DES_WORK );
        }
        mts_TASK_TCB.work = null;
    }
}