using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000260 RID: 608
    public class AMS_PAD_DATA : AppMain.IClearable
    {
        // Token: 0x060023E5 RID: 9189 RVA: 0x00149C7C File Offset: 0x00147E7C
        public void Clear()
        {
            this.state = 0U;
            this.direct = ( this.stand = ( this.release = ( this.repeat = 0 ) ) );
            this.timer_lv = ( this.timer_btn = 0 );
            this.alx = ( this.aly = ( this.arx = ( this.ary = ( this.al2 = ( this.ar2 = 0 ) ) ) ) );
            this.adirect = ( this.astand = ( this.arelease = ( this.arepeat = 0 ) ) );
            this.sensor_x = ( this.sensor_y = ( this.sensor_z = ( this.sensor_g = ( this.point_flag = ( this.point_x = ( this.point_y = 0 ) ) ) ) ) );
            this.rot_x = ( this.rot_y = ( this.rot_z = ( this.vib_flag = 0 ) ) );
            this.point_z = 0f;
            Array.Clear( this.keep_time, 0, this.keep_time.Length );
            Array.Clear( this.last_time, 0, this.last_time.Length );
            Array.Clear( this.keep_atime, 0, this.keep_atime.Length );
            Array.Clear( this.last_atime, 0, this.last_atime.Length );
        }

        // Token: 0x040058E0 RID: 22752
        public uint state;

        // Token: 0x040058E1 RID: 22753
        public ushort direct;

        // Token: 0x040058E2 RID: 22754
        public ushort stand;

        // Token: 0x040058E3 RID: 22755
        public ushort release;

        // Token: 0x040058E4 RID: 22756
        public ushort repeat;

        // Token: 0x040058E5 RID: 22757
        public short timer_lv;

        // Token: 0x040058E6 RID: 22758
        public short timer_btn;

        // Token: 0x040058E7 RID: 22759
        public readonly int[] keep_time = new int[0];

        // Token: 0x040058E8 RID: 22760
        public readonly int[] last_time = new int[0];

        // Token: 0x040058E9 RID: 22761
        public short alx;

        // Token: 0x040058EA RID: 22762
        public short aly;

        // Token: 0x040058EB RID: 22763
        public short arx;

        // Token: 0x040058EC RID: 22764
        public short ary;

        // Token: 0x040058ED RID: 22765
        public short al2;

        // Token: 0x040058EE RID: 22766
        public short ar2;

        // Token: 0x040058EF RID: 22767
        public ushort adirect;

        // Token: 0x040058F0 RID: 22768
        public ushort astand;

        // Token: 0x040058F1 RID: 22769
        public ushort arelease;

        // Token: 0x040058F2 RID: 22770
        public ushort arepeat;

        // Token: 0x040058F3 RID: 22771
        public readonly int[] keep_atime = new int[0];

        // Token: 0x040058F4 RID: 22772
        public readonly int[] last_atime = new int[0];

        // Token: 0x040058F5 RID: 22773
        public short sensor_x;

        // Token: 0x040058F6 RID: 22774
        public short sensor_y;

        // Token: 0x040058F7 RID: 22775
        public short sensor_z;

        // Token: 0x040058F8 RID: 22776
        public short sensor_g;

        // Token: 0x040058F9 RID: 22777
        public int rot_x;

        // Token: 0x040058FA RID: 22778
        public int rot_y;

        // Token: 0x040058FB RID: 22779
        public int rot_z;

        // Token: 0x040058FC RID: 22780
        public short point_flag;

        // Token: 0x040058FD RID: 22781
        public short point_x;

        // Token: 0x040058FE RID: 22782
        public short point_y;

        // Token: 0x040058FF RID: 22783
        public float point_z;

        // Token: 0x04005900 RID: 22784
        public int vib_flag;
    }

    // Token: 0x06000F77 RID: 3959 RVA: 0x000885AC File Offset: 0x000867AC
    public static int PAD_CONNECT( int _port )
    {
        return ( int )( AppMain._am_pad[_port].state & 1U );
    }

    // Token: 0x06000F78 RID: 3960 RVA: 0x000885BC File Offset: 0x000867BC
    public static ushort PAD_DIRECT( int _port )
    {
        return AppMain._am_pad[_port].direct;
    }

    // Token: 0x06000F79 RID: 3961 RVA: 0x000885CA File Offset: 0x000867CA
    public static ushort PAD_STAND( int _port )
    {
        return AppMain._am_pad[_port].stand;
    }

    // Token: 0x06000F7A RID: 3962 RVA: 0x000885D8 File Offset: 0x000867D8
    public static ushort PAD_REPEAT( int _port )
    {
        return AppMain._am_pad[_port].repeat;
    }

    // Token: 0x06000F7B RID: 3963 RVA: 0x000885E6 File Offset: 0x000867E6
    public static ushort PAD_RELEASE( int _port )
    {
        return AppMain._am_pad[_port].release;
    }

    // Token: 0x06000F7C RID: 3964 RVA: 0x000885F4 File Offset: 0x000867F4
    public static ushort PAD_ADIRECT( int _port )
    {
        return AppMain._am_pad[_port].adirect;
    }

    // Token: 0x06000F7D RID: 3965 RVA: 0x00088602 File Offset: 0x00086802
    public static ushort PAD_ASTAND( int _port )
    {
        return AppMain._am_pad[_port].astand;
    }

    // Token: 0x06000F7E RID: 3966 RVA: 0x00088610 File Offset: 0x00086810
    public static ushort PAD_AREPEAT( int _port )
    {
        return AppMain._am_pad[_port].arepeat;
    }

    // Token: 0x06000F7F RID: 3967 RVA: 0x0008861E File Offset: 0x0008681E
    public static ushort PAD_ARELEASE( int _port )
    {
        return AppMain._am_pad[_port].arelease;
    }

    // Token: 0x06000F80 RID: 3968 RVA: 0x0008862C File Offset: 0x0008682C
    public static int PAD_MDIRECT( int _port )
    {
        return ( int )( AppMain._am_pad[_port].direct | AppMain._am_pad[_port].adirect );
    }

    // Token: 0x06000F81 RID: 3969 RVA: 0x00088647 File Offset: 0x00086847
    public static int PAD_MSTAND( int _port )
    {
        return ( int )( AppMain._am_pad[_port].stand | AppMain._am_pad[_port].astand );
    }

    // Token: 0x06000F82 RID: 3970 RVA: 0x00088662 File Offset: 0x00086862
    public static int PAD_MREPEAT( int _port )
    {
        return ( int )( AppMain._am_pad[_port].repeat | AppMain._am_pad[_port].arepeat );
    }

    // Token: 0x06000F83 RID: 3971 RVA: 0x0008867D File Offset: 0x0008687D
    public static int PAD_MRELEASE( int _port )
    {
        return ( int )( AppMain._am_pad[_port].release | AppMain._am_pad[_port].arelease );
    }

    // Token: 0x06000F84 RID: 3972 RVA: 0x00088698 File Offset: 0x00086898
    public static short PAD_A_LX( int _port )
    {
        return AppMain._am_pad[_port].alx;
    }

    // Token: 0x06000F85 RID: 3973 RVA: 0x000886A6 File Offset: 0x000868A6
    public static short PAD_A_LY( int _port )
    {
        return AppMain._am_pad[_port].aly;
    }

    // Token: 0x06000F86 RID: 3974 RVA: 0x000886B4 File Offset: 0x000868B4
    public static short PAD_A_RX( int _port )
    {
        return AppMain._am_pad[_port].arx;
    }

    // Token: 0x06000F87 RID: 3975 RVA: 0x000886C2 File Offset: 0x000868C2
    public static short PAD_A_RY( int _port )
    {
        return AppMain._am_pad[_port].ary;
    }

    // Token: 0x06000F88 RID: 3976 RVA: 0x000886D0 File Offset: 0x000868D0
    public static short PAD_A_L2( int _port )
    {
        return AppMain._am_pad[_port].al2;
    }

    // Token: 0x06000F89 RID: 3977 RVA: 0x000886DE File Offset: 0x000868DE
    public static short PAD_A_R2( int _port )
    {
        return AppMain._am_pad[_port].ar2;
    }

    // Token: 0x06000F8A RID: 3978 RVA: 0x000886EC File Offset: 0x000868EC
    public static short PAD_AXIS_X( int _port )
    {
        return AppMain._am_pad[_port].sensor_x;
    }

    // Token: 0x06000F8B RID: 3979 RVA: 0x000886FA File Offset: 0x000868FA
    public static short PAD_AXIS_Y( int _port )
    {
        return AppMain._am_pad[_port].sensor_y;
    }

    // Token: 0x06000F8C RID: 3980 RVA: 0x00088708 File Offset: 0x00086908
    public static short PAD_AXIS_Z( int _port )
    {
        return AppMain._am_pad[_port].sensor_z;
    }

    // Token: 0x06000F8D RID: 3981 RVA: 0x00088716 File Offset: 0x00086916
    public static short PAD_AXIS_G( int _port )
    {
        return AppMain._am_pad[_port].sensor_g;
    }

    // Token: 0x06000F8E RID: 3982 RVA: 0x00088724 File Offset: 0x00086924
    public static int PAD_ROT_X( int _port )
    {
        return AppMain._am_pad[_port].rot_x;
    }

    // Token: 0x06000F8F RID: 3983 RVA: 0x00088732 File Offset: 0x00086932
    public static int PAD_ROT_Y( int _port )
    {
        return AppMain._am_pad[_port].rot_y;
    }

    // Token: 0x06000F90 RID: 3984 RVA: 0x00088740 File Offset: 0x00086940
    public static int PAD_ROT_Z( int _port )
    {
        return AppMain._am_pad[_port].rot_z;
    }

    // Token: 0x06000F91 RID: 3985 RVA: 0x0008874E File Offset: 0x0008694E
    public static short PAD_POS_ENABLE( int _port )
    {
        return AppMain._am_pad[_port].point_flag;
    }

    // Token: 0x06000F92 RID: 3986 RVA: 0x0008875C File Offset: 0x0008695C
    public static short PAD_POS_X( int _port )
    {
        return AppMain._am_pad[_port].point_x;
    }

    // Token: 0x06000F93 RID: 3987 RVA: 0x0008876A File Offset: 0x0008696A
    public static short PAD_POS_Y( int _port )
    {
        return AppMain._am_pad[_port].point_y;
    }

    // Token: 0x06000F94 RID: 3988 RVA: 0x00088778 File Offset: 0x00086978
    public static float PAD_POS_Z( int _port )
    {
        return AppMain._am_pad[_port].point_z;
    }

    // Token: 0x06000F95 RID: 3989 RVA: 0x00088786 File Offset: 0x00086986
    public static int PAD_KEEP_TIME( int _port, int _key_id )
    {
        return AppMain._am_pad[_port].keep_time[_key_id];
    }

    // Token: 0x06000F96 RID: 3990 RVA: 0x00088796 File Offset: 0x00086996
    public static int PAD_LAST_TIME( int _port, int _key_id )
    {
        return AppMain._am_pad[_port].last_time[_key_id];
    }

    // Token: 0x06000F97 RID: 3991 RVA: 0x000887A6 File Offset: 0x000869A6
    public static int PAD_KEEP_ATIME( int _port, int _key_id )
    {
        return AppMain._am_pad[_port].keep_atime[_key_id];
    }

    // Token: 0x06000F98 RID: 3992 RVA: 0x000887B6 File Offset: 0x000869B6
    public static int PAD_LAST_ATIME( int _port, int _key_id )
    {
        return AppMain._am_pad[_port].last_atime[_key_id];
    }

    // Token: 0x06000F99 RID: 3993 RVA: 0x000887C6 File Offset: 0x000869C6
    private static void amPadInit()
    {
        AppMain.amPadInit( 0, 0U );
    }

    // Token: 0x06000F9A RID: 3994 RVA: 0x000887CF File Offset: 0x000869CF
    private static void amPadInit( int pad_num )
    {
        AppMain.amPadInit( pad_num, 0U );
    }

    // Token: 0x06000F9B RID: 3995 RVA: 0x000887D8 File Offset: 0x000869D8
    private static void amPadInit( int pad_num, uint format )
    {
        for ( int i = 0; i < 4; i++ )
        {
            AppMain._am_pad[i].Clear();
            AppMain._am_pad[i].vib_flag = 1;
        }
    }

    // Token: 0x06000F9C RID: 3996 RVA: 0x0008880A File Offset: 0x00086A0A
    private static void amPadExit()
    {
    }

    // Token: 0x06000F9D RID: 3997 RVA: 0x0008880C File Offset: 0x00086A0C
    private static void amPadSetDeviceFormat( int port, uint format )
    {
    }

    // Token: 0x06000F9E RID: 3998 RVA: 0x0008880E File Offset: 0x00086A0E
    private static void amPadSetMapping( int port, ushort mapping )
    {
    }

    // Token: 0x06000F9F RID: 3999 RVA: 0x00088810 File Offset: 0x00086A10
    private static void amPadSetMappingGC( int port, ushort mapping )
    {
    }

    // Token: 0x06000FA0 RID: 4000 RVA: 0x00088814 File Offset: 0x00086A14
    private static void amPadEnableInput( int port, int flag )
    {
        if ( port != -1 )
        {
            if ( flag != 0 )
            {
                AppMain._am_pad[port].state &= 4294967293U;
                return;
            }
            AppMain._am_pad[port].state |= 2U;
            return;
        }
        else
        {
            if ( flag != 0 )
            {
                for ( port = 0; port < 4; port++ )
                {
                    AppMain._am_pad[port].state &= 4294967293U;
                }
                return;
            }
            for ( port = 0; port < 4; port++ )
            {
                AppMain._am_pad[port].state |= 2U;
            }
            return;
        }
    }

    // Token: 0x06000FA1 RID: 4001 RVA: 0x0008889C File Offset: 0x00086A9C
    private static void amPadGetData()
    {
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.AMS_PAD_DATA ams_PAD_DATA = AppMain._am_pad[i];
            ushort num = 0;
            ushort num2 = (ushort)(ams_PAD_DATA.direct ^ num);
            ams_PAD_DATA.stand = ( ushort )( num2 & num );
            ams_PAD_DATA.release = ( ushort )( num2 & ~num );
            ams_PAD_DATA.direct = num;
            ushort num3 = 0;
            if ( ams_PAD_DATA.alx < -16384 )
            {
                num3 |= 4;
            }
            else if ( ams_PAD_DATA.alx > 16384 )
            {
                num3 |= 8;
            }
            if ( ams_PAD_DATA.aly < -16384 )
            {
                num3 |= 2;
            }
            else if ( ams_PAD_DATA.aly > 16384 )
            {
                num3 |= 1;
            }
            if ( ams_PAD_DATA.arx < -16384 )
            {
                num3 |= 64;
            }
            else if ( ams_PAD_DATA.arx > 16384 )
            {
                num3 |= 128;
            }
            if ( ams_PAD_DATA.ary < -16384 )
            {
                num3 |= 32;
            }
            else if ( ams_PAD_DATA.ary > 16384 )
            {
                num3 |= 16;
            }
            ushort num4 = (ushort)(ams_PAD_DATA.adirect ^ num3);
            ams_PAD_DATA.astand = ( ushort )( num4 & num3 );
            ams_PAD_DATA.arelease = ( ushort )( num4 & ~num3 );
            ams_PAD_DATA.adirect = num3;
            ams_PAD_DATA.repeat = 0;
            ams_PAD_DATA.arepeat = 0;
            if ( ( ( ams_PAD_DATA.stand | ams_PAD_DATA.astand ) & 15 ) != 0 )
            {
                ams_PAD_DATA.repeat = ( ushort )( num & 15 );
                ams_PAD_DATA.arepeat = ( ushort )( num3 & 15 );
                ams_PAD_DATA.timer_lv = 30;
            }
            else
            {
                AppMain.AMS_PAD_DATA ams_PAD_DATA2 = ams_PAD_DATA;
                if ( ( ams_PAD_DATA2.timer_lv -= 1 ) == 0 )
                {
                    ams_PAD_DATA.repeat = ( ushort )( num & 15 );
                    ams_PAD_DATA.arepeat = ( ushort )( num3 & 15 );
                    ams_PAD_DATA.timer_lv = 5;
                }
            }
            if ( ( ( ams_PAD_DATA.stand | ams_PAD_DATA.astand ) & 65520 ) != 0 )
            {
                AppMain.AMS_PAD_DATA ams_PAD_DATA3 = ams_PAD_DATA;
                ams_PAD_DATA3.repeat |= ( ushort )( num & 65520 );
                AppMain.AMS_PAD_DATA ams_PAD_DATA4 = ams_PAD_DATA;
                ams_PAD_DATA4.arepeat |= ( ushort )( num3 & 65520 );
                ams_PAD_DATA.timer_btn = 30;
            }
            else
            {
                AppMain.AMS_PAD_DATA ams_PAD_DATA5 = ams_PAD_DATA;
                if ( ( ams_PAD_DATA5.timer_btn -= 1 ) == 0 )
                {
                    AppMain.AMS_PAD_DATA ams_PAD_DATA6 = ams_PAD_DATA;
                    ams_PAD_DATA6.repeat |= ( ushort )( num & 65520 );
                    AppMain.AMS_PAD_DATA ams_PAD_DATA7 = ams_PAD_DATA;
                    ams_PAD_DATA7.arepeat |= ( ushort )( num3 & 65520 );
                    ams_PAD_DATA.timer_btn = 5;
                }
            }
            int[] keep_time = ams_PAD_DATA.keep_time;
            int[] keep_atime = ams_PAD_DATA.keep_atime;
            int j = 0;
            while ( j < 0 )
            {
                if ( ( num2 & 1 ) != 0 )
                {
                    ams_PAD_DATA.last_time[j] = keep_time[j];
                    keep_time[j] = 1;
                }
                else
                {
                    keep_time[j]++;
                }
                if ( ( num4 & 1 ) != 0 )
                {
                    ams_PAD_DATA.last_atime[j] = keep_atime[j];
                    keep_atime[j] = 1;
                }
                else
                {
                    keep_atime[j]++;
                }
                j++;
                num2 = ( ushort )( num2 >> 1 );
                num4 = ( ushort )( num4 >> 1 );
            }
        }
    }

    // Token: 0x06000FA2 RID: 4002 RVA: 0x00088B6E File Offset: 0x00086D6E
    private static void amPadEnableVibration( int port, int flag )
    {
        if ( flag != 0 )
        {
            AppMain.amPadSetVibration( port, 0, 0 );
        }
        if ( port == -1 )
        {
            for ( port = 0; port < 4; port++ )
            {
                AppMain._am_pad[port].vib_flag = flag;
            }
            return;
        }
        AppMain._am_pad[port].vib_flag = flag;
    }

    // Token: 0x06000FA3 RID: 4003 RVA: 0x00088BA8 File Offset: 0x00086DA8
    private static void amPadSetVibration( int port, ushort left, ushort right )
    {
    }
}
