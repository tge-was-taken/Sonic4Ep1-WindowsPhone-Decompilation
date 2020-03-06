using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600080E RID: 2062 RVA: 0x00047816 File Offset: 0x00045A16
    private static uint _amConvertEndian32( uint data )
    {
        return ( data & 4278190080U ) >> 24 | ( data & 16711680U ) >> 8 | ( data & 65280U ) << 8 | ( data & 255U ) << 24;
    }

    // Token: 0x0600080F RID: 2063 RVA: 0x00047841 File Offset: 0x00045A41
    private static ushort _amConvertEndian16( ushort data )
    {
        return ( ushort )( ( data >> 8 & 255 ) | ( int )data << 8 );
    }

    // Token: 0x06000810 RID: 2064 RVA: 0x00047854 File Offset: 0x00045A54
    private static ulong _amConvertEndian64( ulong data )
    {
        return ( data >> 56 & 255UL ) | ( data >> 48 & 255UL ) << 8 | ( data >> 40 & 255UL ) << 16 | ( data >> 32 & 255UL ) << 24 | ( data >> 24 & 255UL ) << 32 | ( data >> 16 & 255UL ) << 40 | ( data >> 8 & 255UL ) << 48 | ( data & 255UL ) << 56;
    }

    // Token: 0x06000811 RID: 2065 RVA: 0x000478D0 File Offset: 0x00045AD0
    private static uint _amConvertEndian( uint data )
    {
        return AppMain._amConvertEndian32( data );
    }

    // Token: 0x06000812 RID: 2066 RVA: 0x000478D8 File Offset: 0x00045AD8
    private static int _amConvertEndian( int data )
    {
        return ( int )AppMain._amConvertEndian32( ( uint )data );
    }

    // Token: 0x06000813 RID: 2067 RVA: 0x000478E0 File Offset: 0x00045AE0
    private static ushort _amConvertEndian( ushort data )
    {
        return AppMain._amConvertEndian16( data );
    }

    // Token: 0x06000814 RID: 2068 RVA: 0x000478E8 File Offset: 0x00045AE8
    private static short _amConvertEndian( short data )
    {
        AppMain.mppAssertNotImpl();
        return ( short )AppMain._amConvertEndian16( ( ushort )data );
    }

    // Token: 0x06000815 RID: 2069 RVA: 0x000478F7 File Offset: 0x00045AF7
    private static ulong _amConvertEndian( ulong data )
    {
        return AppMain._amConvertEndian64( data );
    }

    // Token: 0x06000816 RID: 2070 RVA: 0x000478FF File Offset: 0x00045AFF
    private static long _amConvertEndian( long data )
    {
        return ( long )AppMain._amConvertEndian64( ( ulong )data );
    }

    // Token: 0x06000817 RID: 2071 RVA: 0x00047907 File Offset: 0x00045B07
    private static void _amConvertEndian( ref uint data )
    {
        data = AppMain._amConvertEndian32( data );
    }

    // Token: 0x06000818 RID: 2072 RVA: 0x00047912 File Offset: 0x00045B12
    private static void _amConvertEndian( ref int data )
    {
        data = ( int )AppMain._amConvertEndian32( ( uint )data );
    }

    // Token: 0x06000819 RID: 2073 RVA: 0x0004791D File Offset: 0x00045B1D
    private static void _amConvertEndian( ref ushort data )
    {
        data = AppMain._amConvertEndian16( data );
    }

    // Token: 0x0600081A RID: 2074 RVA: 0x00047928 File Offset: 0x00045B28
    private static void _amConvertEndian( ref short data )
    {
        data = ( short )AppMain._amConvertEndian16( ( ushort )data );
    }

    // Token: 0x0600081B RID: 2075 RVA: 0x00047935 File Offset: 0x00045B35
    private static void _amConvertEndian( ref ulong data )
    {
        data = AppMain._amConvertEndian64( data );
    }

    // Token: 0x0600081C RID: 2076 RVA: 0x00047940 File Offset: 0x00045B40
    private static void _amConvertEndian( ref long data )
    {
        data = ( long )AppMain._amConvertEndian64( ( ulong )data );
    }
}