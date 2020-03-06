using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200017D RID: 381
    public class AMS_ALARM
    {
        // Token: 0x04004EA3 RID: 20131
        public int delete_flag;

        // Token: 0x04004EA4 RID: 20132
        public uint alarm_id;

        // Token: 0x04004EA5 RID: 20133
        public uint timer_id;

        // Token: 0x04004EA6 RID: 20134
        public AppMain.AMS_TIMER timer;

        // Token: 0x04004EA7 RID: 20135
        public ulong count_end;

        // Token: 0x04004EA8 RID: 20136
        public ulong count_interval;
    }

    // Token: 0x06000645 RID: 1605 RVA: 0x00038259 File Offset: 0x00036459
    private AppMain.AMS_ALARM amAlarmCreateTimer( AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
        if ( alarm == null )
        {
            alarm = new AppMain.AMS_ALARM();
        }
        return alarm;
    }

    // Token: 0x06000646 RID: 1606 RVA: 0x0003826B File Offset: 0x0003646B
    private static AppMain.AMS_ALARM amAlarmCreate( AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
        return alarm;
    }

    // Token: 0x06000647 RID: 1607 RVA: 0x00038273 File Offset: 0x00036473
    private static void amAlarmDelete( AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
        if ( alarm.delete_flag == 1 )
        {
            alarm = null;
            return;
        }
        alarm = null;
    }

    // Token: 0x06000648 RID: 1608 RVA: 0x0003828A File Offset: 0x0003648A
    private void amAlarmSetTimerVSync( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000649 RID: 1609 RVA: 0x00038291 File Offset: 0x00036491
    private void amAlarmSetTimer( AppMain.AMS_ALARM alarm, uint interval )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600064A RID: 1610 RVA: 0x00038298 File Offset: 0x00036498
    private static void amAlarmSet( AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600064B RID: 1611 RVA: 0x0003829F File Offset: 0x0003649F
    private void amAlarmClear( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600064C RID: 1612 RVA: 0x000382A6 File Offset: 0x000364A6
    private void amAlarmWaitTimer( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600064D RID: 1613 RVA: 0x000382AD File Offset: 0x000364AD
    private void amAlarmWaitVSync( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600064E RID: 1614 RVA: 0x000382B4 File Offset: 0x000364B4
    private void amAlarmWait( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600064F RID: 1615 RVA: 0x000382BB File Offset: 0x000364BB
    private void amAlarmUpdateTimer( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000650 RID: 1616 RVA: 0x000382C4 File Offset: 0x000364C4
    private int amAlarmCheckTimer( ref AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000651 RID: 1617 RVA: 0x000382DC File Offset: 0x000364DC
    private static int amAlarmCheck( AppMain.AMS_ALARM alarm )
    {
        int result = 1;
        AppMain.mppAssertNotImpl();
        return result;
    }

    // Token: 0x06000652 RID: 1618 RVA: 0x000382F1 File Offset: 0x000364F1
    private void amAlarmHandler( int signal_id )
    {
        AppMain.mppAssertNotImpl();
    }
} 
