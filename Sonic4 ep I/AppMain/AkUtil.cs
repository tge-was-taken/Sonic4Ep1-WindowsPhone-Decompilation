using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001936 RID: 6454 RVA: 0x000E4240 File Offset: 0x000E2440
    public static void AkUtilFrame60ToTime( uint frame )
    {
        ushort? num = default(ushort?);
        AppMain.AkUtilFrame60ToTime( frame, ref num, ref num, ref num );
    }

    // Token: 0x06001937 RID: 6455 RVA: 0x000E4264 File Offset: 0x000E2464
    public static void AkUtilFrame60ToTime( uint frame, ref ushort min )
    {
        ushort? num = default(ushort?);
        ushort? num2 = new ushort?(min);
        AppMain.AkUtilFrame60ToTime( frame, ref num2, ref num, ref num );
        min = num2.Value;
    }

    // Token: 0x06001938 RID: 6456 RVA: 0x000E429C File Offset: 0x000E249C
    public static void AkUtilFrame60ToTime( uint frame, ref ushort min, ref ushort sec )
    {
        ushort? num = default(ushort?);
        ushort? num2 = new ushort?(min);
        ushort? num3 = new ushort?(sec);
        AppMain.AkUtilFrame60ToTime( frame, ref num2, ref num3, ref num );
        min = num2.Value;
        sec = num3.Value;
    }

    // Token: 0x06001939 RID: 6457 RVA: 0x000E42EC File Offset: 0x000E24EC
    public static void AkUtilFrame60ToTime( uint frame, ref ushort min, ref ushort sec, ref ushort msec )
    {
        ushort? num = new ushort?(min);
        ushort? num2 = new ushort?(sec);
        ushort? num3 = new ushort?(msec);
        AppMain.AkUtilFrame60ToTime( frame, ref num, ref num2, ref num3 );
        min = num.Value;
        sec = num2.Value;
        msec = num3.Value;
    }

    // Token: 0x0600193A RID: 6458 RVA: 0x000E434C File Offset: 0x000E254C
    public static void AkUtilFrame60ToTime( uint frame, ushort? min, ref ushort sec, ushort? msec )
    {
        ushort? num = new ushort?(sec);
        ushort? num2 = default(ushort?);
        AppMain.AkUtilFrame60ToTime( frame, ref num2, ref num, ref num2 );
        sec = num.Value;
    }

    // Token: 0x0600193B RID: 6459 RVA: 0x000E4384 File Offset: 0x000E2584
    public static void AkUtilFrame60ToTime( uint frame, ref ushort? min )
    {
        ushort? num = default(ushort?);
        AppMain.AkUtilFrame60ToTime( frame, ref min, ref num, ref num );
    }

    // Token: 0x0600193C RID: 6460 RVA: 0x000E43A4 File Offset: 0x000E25A4
    public static void AkUtilFrame60ToTime( uint frame, ref ushort? min, ref ushort? sec )
    {
        ushort? num = default(ushort?);
        AppMain.AkUtilFrame60ToTime( frame, ref min, ref sec, ref num );
    }

    // Token: 0x0600193D RID: 6461 RVA: 0x000E43C4 File Offset: 0x000E25C4
    public static void AkUtilFrame60ToTime( uint frame, ref ushort? min, ref ushort? sec, ref ushort? msec )
    {
        if ( ( ulong )frame > ( ulong )( ( long )AppMain.AKD_UTIL_FRAME60_TO_TIME_MAX_FRAME ) )
        {
            frame = ( uint )AppMain.AKD_UTIL_FRAME60_TO_TIME_MAX_FRAME;
        }
        ushort num = (ushort)(frame / 3600U);
        frame -= ( uint )( num * 60 * 60 );
        ushort num2 = (ushort)(frame / 60U);
        frame -= ( uint )( num2 * 60 );
        ushort num3 = (ushort)(frame * 433U >> 8);
        if ( num3 >= 100 )
        {
            num3 = 99;
        }
        ushort? num4 = min;
        int? num5 = (num4 != null) ? new int?((int)num4.GetValueOrDefault()) : default(int?);
        if ( num5 != null )
        {
            min = new ushort?( num );
        }
        ushort? num6 = sec;
        int? num7 = (num6 != null) ? new int?((int)num6.GetValueOrDefault()) : default(int?);
        if ( num7 != null )
        {
            sec = new ushort?( num2 );
        }
        ushort? num8 = msec;
        int? num9 = (num8 != null) ? new int?((int)num8.GetValueOrDefault()) : default(int?);
        if ( num9 != null )
        {
            msec = new ushort?( num3 );
        }
    }

    // Token: 0x0600193E RID: 6462 RVA: 0x000E44D6 File Offset: 0x000E26D6
    public static int AkUtilNumValueToDigits( int val, int[] digit_list, int digit_num )
    {
        return AppMain.AkUtilNumValueToDigits( val, digit_list, digit_num, 10 );
    }

    // Token: 0x0600193F RID: 6463 RVA: 0x000E44E4 File Offset: 0x000E26E4
    public static int AkUtilNumValueToDigits( int val, int[] digit_list, int digit_num, int radix )
    {
        int num = val;
        int num2 = 1;
        for ( int i = 0; i < digit_num; i++ )
        {
            int num3 = num % (num2 * radix);
            digit_list[i] = num3 / num2;
            num -= num3;
            num2 *= radix;
        }
        return num;
    }

    // Token: 0x06001940 RID: 6464 RVA: 0x000E4516 File Offset: 0x000E2716
    public static int AkUtilNumValueToDigits( int val, AppMain.ArrayPointer<int> digit_list, int digit_num )
    {
        return AppMain.AkUtilNumValueToDigits( val, digit_list, digit_num, 10 );
    }

    // Token: 0x06001941 RID: 6465 RVA: 0x000E4524 File Offset: 0x000E2724
    public static int AkUtilNumValueToDigits( int val, AppMain.ArrayPointer<int> digit_list, int digit_num, int radix )
    {
        int num = val;
        int num2 = 1;
        for ( int i = 0; i < digit_num; i++ )
        {
            int num3 = num % (num2 * radix);
            digit_list.SetPrimitive( i, num3 / num2 );
            num -= num3;
            num2 *= radix;
        }
        return num;
    }
}
