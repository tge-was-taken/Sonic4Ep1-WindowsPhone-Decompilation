using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
    private static void GsTrophyInit()
    {
    }

    // Token: 0x06000002 RID: 2 RVA: 0x00002052 File Offset: 0x00000252
    private static void GsTrophyExit()
    {
    }

    // Token: 0x06000003 RID: 3 RVA: 0x00002054 File Offset: 0x00000254
    private static void GsTrophyResetForAccount()
    {
        AppMain.gsTrophyResetAcquisitionTable();
    }

    // Token: 0x06000004 RID: 4 RVA: 0x0000205B File Offset: 0x0000025B
    private static void GsTrophyUpdateAcquisition( uint trophy_id )
    {
        if ( AppMain.gs_trophy_acquisition_tbl[( int )( ( UIntPtr )trophy_id )] != 0 )
        {
            return;
        }
        AppMain.gs_trophy_acquisition_tbl[( int )( ( UIntPtr )trophy_id )] = 1;
        AppMain.gsTrophyTriggerAquisition( trophy_id );
    }

    // Token: 0x06000005 RID: 5 RVA: 0x00002077 File Offset: 0x00000277
    private static bool GsTrophyIsAcquired( uint trophy_id )
    {
        return AppMain.gs_trophy_acquisition_tbl[( int )( ( UIntPtr )trophy_id )] != 0;
    }

    // Token: 0x06000006 RID: 6 RVA: 0x00002086 File Offset: 0x00000286
    private static void GsTrophyAvatarUpdateAcquisition( uint avaw_id )
    {
    }

    // Token: 0x06000007 RID: 7 RVA: 0x00002088 File Offset: 0x00000288
    private static bool GsTrophyAvatarIsAcquired( uint avaw_id )
    {
        return true;
    }

    // Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000028B
    private static void gsTrophyResetAcquisitionTable()
    {
        Array.Clear( AppMain.gs_trophy_acquisition_tbl, 0, 16 );
    }

    // Token: 0x06000009 RID: 9 RVA: 0x0000209A File Offset: 0x0000029A
    private static void gsTrophyTriggerAquisition( uint trophy_no )
    {
        LiveFeature.getInstance().GotAchievment( AppMain.achievements[( int )( ( UIntPtr )trophy_no )].id );
    }
}
