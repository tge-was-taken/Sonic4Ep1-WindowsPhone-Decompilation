using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001BBF RID: 7103 RVA: 0x000FEDE7 File Offset: 0x000FCFE7
    private static void AoSysMsgSetBaseMsgFile( object file )
    {
    }

    // Token: 0x06001BC0 RID: 7104 RVA: 0x000FEDE9 File Offset: 0x000FCFE9
    private static object AoSysMsgGetBaseMsgFile()
    {
        return null;
    }

    // Token: 0x06001BC1 RID: 7105 RVA: 0x000FEDEC File Offset: 0x000FCFEC
    private static void AoSysMsgStart( int id, int select )
    {
    }

    // Token: 0x06001BC2 RID: 7106 RVA: 0x000FEDEE File Offset: 0x000FCFEE
    private static void AoSysMsgStart( object file, uint id, int select )
    {
    }

    // Token: 0x06001BC3 RID: 7107 RVA: 0x000FEDF0 File Offset: 0x000FCFF0
    private static void AoSysMsgCancel()
    {
    }

    // Token: 0x06001BC4 RID: 7108 RVA: 0x000FEDF2 File Offset: 0x000FCFF2
    private static bool AoSysMsgIsFinished()
    {
        return true;
    }

    // Token: 0x06001BC5 RID: 7109 RVA: 0x000FEDF5 File Offset: 0x000FCFF5
    private static int AoSysMsgGetResult()
    {
        return 6;
    }

    // Token: 0x06001BC6 RID: 7110 RVA: 0x000FEDF8 File Offset: 0x000FCFF8
    private static bool AoSysMsgIsShow()
    {
        return AppMain.AoSysMsgIsShowReal();
    }

    // Token: 0x06001BC7 RID: 7111 RVA: 0x000FEDFF File Offset: 0x000FCFFF
    private static bool AoSysMsgIsShowReal()
    {
        return false;
    }
}