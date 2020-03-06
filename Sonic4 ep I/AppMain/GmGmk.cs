using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001589 RID: 5513 RVA: 0x000BB1A7 File Offset: 0x000B93A7
    private static int GMM_GMK_TYPE_CHECK( int gmk )
    {
        if ( gmk >= 2 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x0600158A RID: 5514 RVA: 0x000BB1B0 File Offset: 0x000B93B0
    private static bool GMM_GMK_TYPE_IS_WALL( int gmk )
    {
        return AppMain.GMM_GMK_TYPE_CHECK( gmk ) == 0;
    }

    // Token: 0x0600158B RID: 5515 RVA: 0x000BB1BB File Offset: 0x000B93BB
    private static int GMM_GMK_TYPE_IS_VECT( int gmk )
    {
        if ( gmk != 0 )
        {
            return 0;
        }
        return 1;
    }
}
