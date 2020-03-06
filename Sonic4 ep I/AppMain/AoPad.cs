using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060018EC RID: 6380 RVA: 0x000E3C82 File Offset: 0x000E1E82
    private static ushort AoPadDirect()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_DIRECT( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018ED RID: 6381 RVA: 0x000E3C98 File Offset: 0x000E1E98
    private static ushort AoPadStand()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_STAND( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018EE RID: 6382 RVA: 0x000E3CAE File Offset: 0x000E1EAE
    private static ushort AoPadRepeat()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_REPEAT( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018EF RID: 6383 RVA: 0x000E3CC4 File Offset: 0x000E1EC4
    private static ushort AoPadRelease()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_RELEASE( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F0 RID: 6384 RVA: 0x000E3CDA File Offset: 0x000E1EDA
    private static ushort AoPadADirect()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_ADIRECT( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F1 RID: 6385 RVA: 0x000E3CF0 File Offset: 0x000E1EF0
    private static ushort AoPadAStand()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_ASTAND( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F2 RID: 6386 RVA: 0x000E3D06 File Offset: 0x000E1F06
    private static ushort AoPadARepeat()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_AREPEAT( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F3 RID: 6387 RVA: 0x000E3D1C File Offset: 0x000E1F1C
    private static ushort AoPadARelease()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_ARELEASE( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F4 RID: 6388 RVA: 0x000E3D32 File Offset: 0x000E1F32
    private static ushort AoPadMDirect()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return ( ushort )AppMain.PAD_MDIRECT( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F5 RID: 6389 RVA: 0x000E3D49 File Offset: 0x000E1F49
    private static ushort AoPadMStand()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return ( ushort )AppMain.PAD_MSTAND( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F6 RID: 6390 RVA: 0x000E3D60 File Offset: 0x000E1F60
    private static ushort AoPadMRepeat()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return ( ushort )AppMain.PAD_MREPEAT( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F7 RID: 6391 RVA: 0x000E3D77 File Offset: 0x000E1F77
    private static ushort AoPadMRelease()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return ( ushort )AppMain.PAD_MRELEASE( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F8 RID: 6392 RVA: 0x000E3D8E File Offset: 0x000E1F8E
    private static short AoPadAnalogLX()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_A_LX( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018F9 RID: 6393 RVA: 0x000E3DA4 File Offset: 0x000E1FA4
    private static short AoPadAnalogLY()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_A_LY( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018FA RID: 6394 RVA: 0x000E3DBA File Offset: 0x000E1FBA
    private static short AoPadAnalogRX()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_A_RX( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018FB RID: 6395 RVA: 0x000E3DD0 File Offset: 0x000E1FD0
    private static short AoPadAnalogRY()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_A_RY( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018FC RID: 6396 RVA: 0x000E3DE6 File Offset: 0x000E1FE6
    private static short AoPadTriggerL()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_A_L2( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018FD RID: 6397 RVA: 0x000E3DFC File Offset: 0x000E1FFC
    private static short AoPadTriggerR()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_A_R2( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018FE RID: 6398 RVA: 0x000E3E12 File Offset: 0x000E2012
    private static short AoPadAxisX()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_AXIS_X( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x060018FF RID: 6399 RVA: 0x000E3E28 File Offset: 0x000E2028
    private static short AoPadAxisY()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_AXIS_Y( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001900 RID: 6400 RVA: 0x000E3E3E File Offset: 0x000E203E
    private static short AoPadAxisZ()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_AXIS_Z( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001901 RID: 6401 RVA: 0x000E3E54 File Offset: 0x000E2054
    private static short AoPadAxisG()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_AXIS_G( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001902 RID: 6402 RVA: 0x000E3E6A File Offset: 0x000E206A
    private static int AoPadRotX()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_ROT_X( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001903 RID: 6403 RVA: 0x000E3E80 File Offset: 0x000E2080
    private static int AoPadRotY()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_ROT_Y( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001904 RID: 6404 RVA: 0x000E3E96 File Offset: 0x000E2096
    private static int AoPadRotZ()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_ROT_Z( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001905 RID: 6405 RVA: 0x000E3EAC File Offset: 0x000E20AC
    private static bool AoPadPointEnable()
    {
        return AppMain.AoAccountGetCurrentId() < 4 && AppMain.PAD_POS_ENABLE( AppMain.AoAccountGetCurrentId() ) != 0;
    }

    // Token: 0x06001906 RID: 6406 RVA: 0x000E3EC8 File Offset: 0x000E20C8
    private static short AoPadPointX()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_POS_X( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001907 RID: 6407 RVA: 0x000E3EDE File Offset: 0x000E20DE
    private static short AoPadPointY()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_POS_Y( AppMain.AoAccountGetCurrentId() );
        }
        return 0;
    }

    // Token: 0x06001908 RID: 6408 RVA: 0x000E3EF4 File Offset: 0x000E20F4
    private static float AoPadPointZ()
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            return AppMain.PAD_POS_Z( AppMain.AoAccountGetCurrentId() );
        }
        return 0f;
    }

    // Token: 0x06001909 RID: 6409 RVA: 0x000E3F10 File Offset: 0x000E2110
    private static int AoPadSomeoneDirect( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_DIRECT( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x0600190A RID: 6410 RVA: 0x000E3F38 File Offset: 0x000E2138
    private static int AoPadSomeoneStand( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_STAND( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x0600190B RID: 6411 RVA: 0x000E3F60 File Offset: 0x000E2160
    private static int AoPadSomeoneRepeat( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_REPEAT( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x0600190C RID: 6412 RVA: 0x000E3F88 File Offset: 0x000E2188
    private static int AoPadSomeoneRelease( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_RELEASE( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x0600190D RID: 6413 RVA: 0x000E3FB0 File Offset: 0x000E21B0
    private static int AoPadSomeoneADirect( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_ADIRECT( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x0600190E RID: 6414 RVA: 0x000E3FD8 File Offset: 0x000E21D8
    private static int AoPadSomeoneAStand( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_ASTAND( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x0600190F RID: 6415 RVA: 0x000E4000 File Offset: 0x000E2200
    private static int AoPadSomeoneARepeat( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_AREPEAT( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x06001910 RID: 6416 RVA: 0x000E4028 File Offset: 0x000E2228
    private static int AoPadSomeoneARelease( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_ARELEASE( i ) & key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x06001911 RID: 6417 RVA: 0x000E4050 File Offset: 0x000E2250
    private static int AoPadSomeoneMDirect( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_MDIRECT( i ) & ( int )key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x06001912 RID: 6418 RVA: 0x000E4078 File Offset: 0x000E2278
    private static int AoPadSomeoneMStand( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_MSTAND( i ) & ( int )key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x06001913 RID: 6419 RVA: 0x000E40A0 File Offset: 0x000E22A0
    private static int AoPadSomeoneMRepeat( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_MREPEAT( i ) & ( int )key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x06001914 RID: 6420 RVA: 0x000E40C8 File Offset: 0x000E22C8
    private static int AoPadSomeoneMRelease( ushort key )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( AppMain.PAD_MRELEASE( i ) & ( int )key ) != 0 )
            {
                return i;
            }
        }
        return -1;
    }

    // Token: 0x06001915 RID: 6421 RVA: 0x000E40EE File Offset: 0x000E22EE
    private static ushort AoPadPortDirect( uint port )
    {
        return AppMain.PAD_DIRECT( ( int )port );
    }

    // Token: 0x06001916 RID: 6422 RVA: 0x000E40F6 File Offset: 0x000E22F6
    private static ushort AoPadPortStand( uint port )
    {
        return AppMain.PAD_STAND( ( int )port );
    }

    // Token: 0x06001917 RID: 6423 RVA: 0x000E40FE File Offset: 0x000E22FE
    private static ushort AoPadPortRepeat( uint port )
    {
        return AppMain.PAD_REPEAT( ( int )port );
    }

    // Token: 0x06001918 RID: 6424 RVA: 0x000E4106 File Offset: 0x000E2306
    private ushort AoPadPortRelease( uint port )
    {
        return AppMain.PAD_RELEASE( ( int )port );
    }

    // Token: 0x06001919 RID: 6425 RVA: 0x000E410E File Offset: 0x000E230E
    private static ushort AoPadPortADirect( uint port )
    {
        return AppMain.PAD_ADIRECT( ( int )port );
    }

    // Token: 0x0600191A RID: 6426 RVA: 0x000E4116 File Offset: 0x000E2316
    private static ushort AoPadPortAStand( uint port )
    {
        return AppMain.PAD_ASTAND( ( int )port );
    }

    // Token: 0x0600191B RID: 6427 RVA: 0x000E411E File Offset: 0x000E231E
    private static ushort AoPadPortARepeat( uint port )
    {
        return AppMain.PAD_AREPEAT( ( int )port );
    }

    // Token: 0x0600191C RID: 6428 RVA: 0x000E4126 File Offset: 0x000E2326
    private static ushort AoPadPortARelease( uint port )
    {
        return AppMain.PAD_ARELEASE( ( int )port );
    }

    // Token: 0x0600191D RID: 6429 RVA: 0x000E412E File Offset: 0x000E232E
    private static ushort AoPadPortMDirect( uint port )
    {
        return ( ushort )AppMain.PAD_MDIRECT( ( int )port );
    }

    // Token: 0x0600191E RID: 6430 RVA: 0x000E4137 File Offset: 0x000E2337
    private static ushort AoPadPortMStand( uint port )
    {
        return ( ushort )AppMain.PAD_MSTAND( ( int )port );
    }

    // Token: 0x0600191F RID: 6431 RVA: 0x000E4140 File Offset: 0x000E2340
    private static ushort AoPadPortMRepeat( uint port )
    {
        return ( ushort )AppMain.PAD_MREPEAT( ( int )port );
    }

    // Token: 0x06001920 RID: 6432 RVA: 0x000E4149 File Offset: 0x000E2349
    private static ushort AoPadPortMRelease( uint port )
    {
        return ( ushort )AppMain.PAD_MRELEASE( ( int )port );
    }

    // Token: 0x06001921 RID: 6433 RVA: 0x000E4152 File Offset: 0x000E2352
    private static short AoPadPortAnalogLX( uint port )
    {
        return AppMain.PAD_A_LX( ( int )port );
    }

    // Token: 0x06001922 RID: 6434 RVA: 0x000E415A File Offset: 0x000E235A
    private static short AoPadPortAnalogLY( uint port )
    {
        return AppMain.PAD_A_LY( ( int )port );
    }

    // Token: 0x06001923 RID: 6435 RVA: 0x000E4162 File Offset: 0x000E2362
    private static short AoPadPortAnalogRX( uint port )
    {
        return AppMain.PAD_A_RX( ( int )port );
    }

    // Token: 0x06001924 RID: 6436 RVA: 0x000E416A File Offset: 0x000E236A
    private static short AoPadPortAnalogRY( uint port )
    {
        return AppMain.PAD_A_RY( ( int )port );
    }

    // Token: 0x06001925 RID: 6437 RVA: 0x000E4172 File Offset: 0x000E2372
    private static short AoPadPortTriggerL( uint port )
    {
        return AppMain.PAD_A_L2( ( int )port );
    }

    // Token: 0x06001926 RID: 6438 RVA: 0x000E417A File Offset: 0x000E237A
    private static short AoPadPortTriggerR( uint port )
    {
        return AppMain.PAD_A_R2( ( int )port );
    }

    // Token: 0x06001927 RID: 6439 RVA: 0x000E4182 File Offset: 0x000E2382
    private static short AoPadPortAxisX( uint port )
    {
        return AppMain.PAD_AXIS_X( ( int )port );
    }

    // Token: 0x06001928 RID: 6440 RVA: 0x000E418A File Offset: 0x000E238A
    private static short AoPadPortAxisY( uint port )
    {
        return AppMain.PAD_AXIS_Y( ( int )port );
    }

    // Token: 0x06001929 RID: 6441 RVA: 0x000E4192 File Offset: 0x000E2392
    private static short AoPadPortAxisZ( uint port )
    {
        return AppMain.PAD_AXIS_Z( ( int )port );
    }

    // Token: 0x0600192A RID: 6442 RVA: 0x000E419A File Offset: 0x000E239A
    private static short AoPadPortAxisG( uint port )
    {
        return AppMain.PAD_AXIS_G( ( int )port );
    }

    // Token: 0x0600192B RID: 6443 RVA: 0x000E41A2 File Offset: 0x000E23A2
    private static int AoPadPortRotX( uint port )
    {
        return AppMain.PAD_ROT_X( ( int )port );
    }

    // Token: 0x0600192C RID: 6444 RVA: 0x000E41AA File Offset: 0x000E23AA
    private static int AoPadPortRotY( uint port )
    {
        return AppMain.PAD_ROT_Y( ( int )port );
    }

    // Token: 0x0600192D RID: 6445 RVA: 0x000E41B2 File Offset: 0x000E23B2
    private static int AoPadPortRotZ( uint port )
    {
        return AppMain.PAD_ROT_Z( ( int )port );
    }

    // Token: 0x0600192E RID: 6446 RVA: 0x000E41BA File Offset: 0x000E23BA
    private static bool AoPadPortPointEnable( uint port )
    {
        return AppMain.PAD_POS_ENABLE( ( int )port ) != 0;
    }

    // Token: 0x0600192F RID: 6447 RVA: 0x000E41C8 File Offset: 0x000E23C8
    private static short AoPadPortPointX( uint port )
    {
        return AppMain.PAD_POS_X( ( int )port );
    }

    // Token: 0x06001930 RID: 6448 RVA: 0x000E41D0 File Offset: 0x000E23D0
    private static short AoPadPortPointY( uint port )
    {
        return AppMain.PAD_POS_Y( ( int )port );
    }

    // Token: 0x06001931 RID: 6449 RVA: 0x000E41D8 File Offset: 0x000E23D8
    private static float AoPadPortPointZ( uint port )
    {
        return AppMain.PAD_POS_Z( ( int )port );
    }

    // Token: 0x06001932 RID: 6450 RVA: 0x000E41E0 File Offset: 0x000E23E0
    private static bool AoPadIsConnected( uint port )
    {
        return AppMain.PAD_CONNECT( ( int )port ) != 0;
    }

    // Token: 0x06001933 RID: 6451 RVA: 0x000E41F0 File Offset: 0x000E23F0
    private static bool AoPadIsConnected()
    {
        int num = AppMain.AoAccountGetCurrentId();
        return num >= 0 && AppMain.AoPadIsConnected( ( uint )num );
    }

    // Token: 0x06001934 RID: 6452 RVA: 0x000E420F File Offset: 0x000E240F
    private static void AoPadEnableVibration( bool flag )
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            AppMain.amPadEnableVibration( AppMain.AoAccountGetCurrentId(), flag ? 1 : 0 );
        }
    }

    // Token: 0x06001935 RID: 6453 RVA: 0x000E422A File Offset: 0x000E242A
    private static void AoPadSetVibration( ushort left, ushort right )
    {
        if ( AppMain.AoAccountGetCurrentId() < 4 )
        {
            AppMain.amPadSetVibration( AppMain.AoAccountGetCurrentId(), left, right );
        }
    }
}
