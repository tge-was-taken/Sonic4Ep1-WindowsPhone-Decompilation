using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200017C RID: 380
    public class AMS_TIMER
    {
        // Token: 0x04004E9C RID: 20124
        public ulong count_start;

        // Token: 0x04004E9D RID: 20125
        public ulong count_end;

        // Token: 0x04004E9E RID: 20126
        public int delete_flag;

        // Token: 0x04004E9F RID: 20127
        public float count_freq;

        // Token: 0x04004EA0 RID: 20128
        public float frame;

        // Token: 0x04004EA1 RID: 20129
        public float msec;

        // Token: 0x04004EA2 RID: 20130
        public float usec;
    }

    // Token: 0x0600063D RID: 1597 RVA: 0x000381C2 File Offset: 0x000363C2
    private float amTimerGetFrame( ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
        return timer.frame;
    }

    // Token: 0x0600063E RID: 1598 RVA: 0x000381D0 File Offset: 0x000363D0
    private float amTimerGetMSec( ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
        return timer.msec;
    }

    // Token: 0x0600063F RID: 1599 RVA: 0x000381DE File Offset: 0x000363DE
    private float amTimerGetuSec( ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
        return timer.usec;
    }

    // Token: 0x06000640 RID: 1600 RVA: 0x000381EC File Offset: 0x000363EC
    private AppMain.AMS_TIMER amTimerCreate( ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
        if ( timer == null )
        {
            timer = new AppMain.AMS_TIMER();
            timer.delete_flag = 1;
        }
        else
        {
            timer = null;
        }
        timer.count_freq = 1000000f;
        return timer;
    }

    // Token: 0x06000641 RID: 1601 RVA: 0x00038219 File Offset: 0x00036419
    private void amTimerDelete( ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
        if ( timer.delete_flag == 1 )
        {
            timer = null;
            return;
        }
        timer = null;
    }

    // Token: 0x06000642 RID: 1602 RVA: 0x00038231 File Offset: 0x00036431
    private void amTimerStart( ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000643 RID: 1603 RVA: 0x00038238 File Offset: 0x00036438
    private void amTimerEnd( ref AppMain.AMS_TIMER timer, int reset )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000644 RID: 1604 RVA: 0x0003823F File Offset: 0x0003643F
    private float amTimerCalcFrame( ulong count_start, ulong count_end, ref AppMain.AMS_TIMER timer )
    {
        AppMain.mppAssertNotImpl();
        return ( count_end - count_start ) * 60f / timer.count_freq;
    }
}