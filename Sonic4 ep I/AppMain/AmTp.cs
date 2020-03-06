using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001E7 RID: 487
    public class AMS_TP_TOUCH_CORE
    {
        // Token: 0x040054D2 RID: 21714
        public ushort[] sampling_buf = new ushort[2];

        // Token: 0x040054D3 RID: 21715
        public byte sampling_num;

        // Token: 0x040054D4 RID: 21716
        public byte sampling_flag;
    }

    // Token: 0x020001E8 RID: 488
    public class AMS_TP_TOUCH_STATUS
    {
        // Token: 0x040054D5 RID: 21717
        public AppMain.AMS_TP_TOUCH_CORE core = new AppMain.AMS_TP_TOUCH_CORE();

        // Token: 0x040054D6 RID: 21718
        public ushort flag;

        // Token: 0x040054D7 RID: 21719
        public ushort[] on = new ushort[2];

        // Token: 0x040054D8 RID: 21720
        public ushort[] prev = new ushort[2];

        // Token: 0x040054D9 RID: 21721
        public ushort[] push = new ushort[2];

        // Token: 0x040054DA RID: 21722
        public ushort[] pull = new ushort[2];
    }

    // Token: 0x06000A2D RID: 2605 RVA: 0x0005BCBF File Offset: 0x00059EBF
    public static bool amTpIsTouchOn( int index )
    {
        return ( AppMain._am_tp_touch[index].flag & 1 ) != 0;
    }

    // Token: 0x06000A2E RID: 2606 RVA: 0x0005BCD5 File Offset: 0x00059ED5
    public static bool amTpIsTouchPush( int index )
    {
        return ( AppMain._am_tp_touch[index].flag & 4 ) != 0;
    }

    // Token: 0x06000A2F RID: 2607 RVA: 0x0005BCEB File Offset: 0x00059EEB
    public static bool amTpIsTouchPull( int index )
    {
        return ( AppMain._am_tp_touch[index].flag & 8 ) != 0;
    }

    // Token: 0x06000A30 RID: 2608 RVA: 0x0005BD04 File Offset: 0x00059F04
    public static void AMM_TP_BIT_SET16( ref ushort val, int shift, bool b )
    {
        byte b2 = (byte)(b ? 1 : 0);
        val = ( ushort )( ( ( int )val & ~( 1 << shift ) ) | ( int )b2 << shift );
    }

    // Token: 0x06000A31 RID: 2609 RVA: 0x0005BD30 File Offset: 0x00059F30
    private void amTpInit()
    {
        for ( int i = 0; i < 4; i++ )
        {
            AppMain._am_tp_touch[i] = new AppMain.AMS_TP_TOUCH_STATUS();
        }
    }

    // Token: 0x06000A32 RID: 2610 RVA: 0x0005BD58 File Offset: 0x00059F58
    private void amTpExecute()
    {
        this._amTpUpdateTouch_req();
        for ( int i = 0; i < 4; i++ )
        {
            this.amTpUpdateStatus( AppMain._am_tp_touch[i], AppMain._am_tp_touch[i].core );
        }
    }

    // Token: 0x06000A33 RID: 2611 RVA: 0x0005BD90 File Offset: 0x00059F90
    private void amTpUpdateStatus( AppMain.AMS_TP_TOUCH_STATUS status, AppMain.AMS_TP_TOUCH_CORE core )
    {
        bool flag = (core.sampling_flag & 1) != 0;
        bool flag2 = (status.flag & 1) != 0;
        bool flag3 = flag ^ flag2;
        AppMain.AMM_TP_BIT_SET16( ref status.flag, 7, ( core.sampling_flag & 128 ) != 0 );
        AppMain.AMM_TP_BIT_SET16( ref status.flag, 1, flag2 );
        AppMain.AMM_TP_BIT_SET16( ref status.flag, 0, flag );
        AppMain.AMM_TP_BIT_SET16( ref status.flag, 2, flag3 && flag );
        AppMain.AMM_TP_BIT_SET16( ref status.flag, 3, flag3 && flag2 );
        status.prev[0] = status.on[0];
        status.prev[1] = status.on[1];
        ushort[] sampling_buf = core.sampling_buf;
        status.on[0] = sampling_buf[0];
        status.on[1] = sampling_buf[1];
        if ( ( status.flag & 4 ) != 0 )
        {
            status.push[0] = status.on[0];
            status.push[1] = status.on[1];
        }
        else if ( ( status.flag & 8 ) != 0 )
        {
            status.pull[0] = status.prev[0];
            status.pull[1] = status.prev[1];
        }
        if ( status.core != core )
        {
            status.core = core;
        }
    }

    // Token: 0x06000A34 RID: 2612 RVA: 0x0005BEB8 File Offset: 0x0005A0B8
    private void _amTpUpdateTouch_req()
    {
        AppMain.AMS_IPHONE_TP_DATA amTpUpdateTouch_req_DispData = AppMain._amTpUpdateTouch_req_DispData;
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.AMS_TP_TOUCH_CORE core = AppMain._am_tp_touch[i].core;
            AppMain.amIPhoneRequestTouch( amTpUpdateTouch_req_DispData, i );
            if ( amTpUpdateTouch_req_DispData.touch == 1 )
            {
                if ( amTpUpdateTouch_req_DispData.validity == 1 )
                {
                    core.sampling_buf[0] = amTpUpdateTouch_req_DispData.x;
                    core.sampling_buf[1] = amTpUpdateTouch_req_DispData.y;
                    AppMain.AMS_TP_TOUCH_CORE ams_TP_TOUCH_CORE = core;
                    ams_TP_TOUCH_CORE.sampling_flag |= 1;
                    AppMain.AMS_TP_TOUCH_CORE ams_TP_TOUCH_CORE2 = core;
                    ams_TP_TOUCH_CORE2.sampling_flag &= 127;
                }
                else
                {
                    AppMain.AMS_TP_TOUCH_CORE ams_TP_TOUCH_CORE3 = core;
                    ams_TP_TOUCH_CORE3.sampling_flag |= 128;
                }
            }
            else
            {
                AppMain.AMS_TP_TOUCH_CORE ams_TP_TOUCH_CORE4 = core;
                ams_TP_TOUCH_CORE4.sampling_flag &= 126;
            }
        }
    }
}