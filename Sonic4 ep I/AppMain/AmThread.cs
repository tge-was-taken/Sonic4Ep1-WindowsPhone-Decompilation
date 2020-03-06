using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public partial class AppMain
{

    // Token: 0x020003AA RID: 938
    private enum AMD_CORE
    {
        // Token: 0x0400616D RID: 24941
        AMD_CORE_1A,
        // Token: 0x0400616E RID: 24942
        AMD_CORE_1B,
        // Token: 0x0400616F RID: 24943
        AMD_CORE_2A,
        // Token: 0x04006170 RID: 24944
        AMD_CORE_2B,
        // Token: 0x04006171 RID: 24945
        AMD_CORE_3A,
        // Token: 0x04006172 RID: 24946
        AMD_CORE_3B
    }

    // Token: 0x020003AB RID: 939
    public class AMS_THREAD
    {
        // Token: 0x04006173 RID: 24947
        public Thread thread_id;

        // Token: 0x04006174 RID: 24948
        public int handle;

        // Token: 0x04006175 RID: 24949
        public AppMain.AMS_ALARM alarm_exit = new AppMain.AMS_ALARM();

        // Token: 0x04006176 RID: 24950
        public object mutex = new object();
    }

    // Token: 0x020003AC RID: 940
    // (Invoke) Token: 0x060026FF RID: 9983
    public delegate void AMF_THREAD_PROC();


    // Token: 0x06001A0C RID: 6668 RVA: 0x000EA228 File Offset: 0x000E8428
    private Thread amThreadGetCurrentID()
    {
        return Thread.CurrentThread;
    }

    // Token: 0x06001A0D RID: 6669 RVA: 0x000EA230 File Offset: 0x000E8430
    private static Thread amThreadCreate( ref AppMain.AMS_THREAD thread, ParameterizedThreadStart proc, object arg, AppMain.AMD_CORE core, int prio, uint stack_size, string name )
    {
        AppMain.mppAssertNotImpl();
        AppMain.amAssert( thread );
        AppMain.amAssert( proc );
        thread.thread_id = new Thread( new ParameterizedThreadStart( proc.Invoke ) );
        if ( thread.thread_id != null )
        {
            AppMain.amAlarmCreate( thread.alarm_exit );
            AppMain.amMutexCreate( thread.mutex );
            thread.thread_id.Start( arg );
        }
        return thread.thread_id;
    }

    // Token: 0x06001A0E RID: 6670 RVA: 0x000EA29D File Offset: 0x000E849D
    private static void amThreadCheckSafe( int i, string s )
    {
    }

    // Token: 0x06001A0F RID: 6671 RVA: 0x000EA29F File Offset: 0x000E849F
    private static void amThreadOpen( AppMain.AMS_THREAD thread )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001A10 RID: 6672 RVA: 0x000EA2A6 File Offset: 0x000E84A6
    private static int amThreadExit( AppMain.AMS_THREAD thread )
    {
        AppMain.amAssert( thread );
        AppMain.amAlarmSet( thread.alarm_exit );
        return 1;
    }

    // Token: 0x06001A11 RID: 6673 RVA: 0x000EA2BA File Offset: 0x000E84BA
    private static int amThreadCheckExit( AppMain.AMS_THREAD thread )
    {
        AppMain.amAssert( thread );
        return AppMain.amAlarmCheck( thread.alarm_exit );
    }

    // Token: 0x06001A12 RID: 6674 RVA: 0x000EA2CD File Offset: 0x000E84CD
    private static void amThreadQuit( AppMain.AMS_THREAD thread )
    {
        AppMain.amAssert( thread );
        thread.thread_id.Abort();
        thread.thread_id = null;
    }

    // Token: 0x06001A13 RID: 6675 RVA: 0x000EA2E7 File Offset: 0x000E84E7
    private static int amThreadCheckQuit( AppMain.AMS_THREAD thread )
    {
        AppMain.amAssert( thread );
        if ( !Monitor.Wait( thread.thread_id, 0 ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001A14 RID: 6676 RVA: 0x000EA300 File Offset: 0x000E8500
    private static void amThreadWaitQuit( AppMain.AMS_THREAD thread )
    {
        AppMain.amAssert( thread );
        Monitor.Wait( thread.thread_id );
    }

    // Token: 0x06001A15 RID: 6677 RVA: 0x000EA314 File Offset: 0x000E8514
    private static void amThreadDelete( AppMain.AMS_THREAD thread )
    {
        AppMain.amAssert( thread );
        AppMain.amMutexDelete( thread.mutex );
        AppMain.amAlarmDelete( thread.alarm_exit );
    }

    // Token: 0x06001A16 RID: 6678 RVA: 0x000EA333 File Offset: 0x000E8533
    public static bool amThreadCheckDraw()
    {
        return AppMain.amThreadCheckDraw( false );
    }

    // Token: 0x06001A17 RID: 6679 RVA: 0x000EA33B File Offset: 0x000E853B
    public static bool amThreadCheckDraw( bool default_thread )
    {
        return true;
    }

    // Token: 0x06001A18 RID: 6680 RVA: 0x000EA33E File Offset: 0x000E853E
    private static void amThreadSleep( int msec )
    {
        Thread.Sleep( msec );
    }

    // Token: 0x06001A19 RID: 6681 RVA: 0x000EA346 File Offset: 0x000E8546
    private static void amMutexCreate( object mutex )
    {
    }

    // Token: 0x06001A1A RID: 6682 RVA: 0x000EA348 File Offset: 0x000E8548
    private static int amMutexDelete( object mutex )
    {
        return 1;
    }

    // Token: 0x06001A1B RID: 6683 RVA: 0x000EA34B File Offset: 0x000E854B
    private static void amMutexLock( object mutex )
    {
        AppMain.amAssert( mutex );
        Monitor.Enter( mutex );
    }

    // Token: 0x06001A1C RID: 6684 RVA: 0x000EA359 File Offset: 0x000E8559
    private int amMutexTrylock( object mutex )
    {
        AppMain.amAssert( mutex );
        if ( !Monitor.TryEnter( mutex ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001A1D RID: 6685 RVA: 0x000EA36C File Offset: 0x000E856C
    private static void amMutexUnlock( object mutex )
    {
        AppMain.amAssert( mutex );
        Monitor.Exit( mutex );
    }
}
