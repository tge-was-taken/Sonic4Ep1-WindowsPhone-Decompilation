using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000126 RID: 294
    public class DMS_BUY_SCR_WORK
    {
        // Token: 0x06002044 RID: 8260 RVA: 0x0013DD00 File Offset: 0x0013BF00
        internal void Clear()
        {
            this.instance = null;
            this.result[0] = 0;
        }

        // Token: 0x04004CAB RID: 19627
        public object instance;

        // Token: 0x04004CAC RID: 19628
        public int[] result = new int[1];
    }

    // Token: 0x0600050D RID: 1293 RVA: 0x0002B4EC File Offset: 0x000296EC
    public static int DmBuyScreenGetResult( AppMain.DMS_BUY_SCR_WORK work )
    {
        return work.result[0];
    }
}
