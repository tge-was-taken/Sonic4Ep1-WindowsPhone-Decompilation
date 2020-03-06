using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200034C RID: 844
    private enum GSE_REGION
    {
        // Token: 0x04005ED2 RID: 24274
        GSD_REGION_JP,
        // Token: 0x04005ED3 RID: 24275
        GSD_REGION_US,
        // Token: 0x04005ED4 RID: 24276
        GSD_REGION_EU,
        // Token: 0x04005ED5 RID: 24277
        GSD_REGION_NUM,
        // Token: 0x04005ED6 RID: 24278
        GSD_REGION_DEF = 1
    }

    // Token: 0x0200034D RID: 845
    private enum GSE_DECIDE_KEY
    {
        // Token: 0x04005ED8 RID: 24280
        GSD_DECIDE_KEY_O,
        // Token: 0x04005ED9 RID: 24281
        GSD_DECIDE_KEY_X,
        // Token: 0x04005EDA RID: 24282
        GSD_DECIDE_KEY_NUM,
        // Token: 0x04005EDB RID: 24283
        GSD_DECIDE_KEY_DEF = 1
    }


    // Token: 0x0200034E RID: 846
    private struct CRegionTable
    {
        // Token: 0x060025D7 RID: 9687 RVA: 0x0014E3D2 File Offset: 0x0014C5D2
        public CRegionTable( string country, AppMain.GSE_REGION region )
        {
            this.country = country;
            this.region = region;
        }

        // Token: 0x04005EDC RID: 24284
        public string country;

        // Token: 0x04005EDD RID: 24285
        public AppMain.GSE_REGION region;
    }

    // Token: 0x0200034F RID: 847
    private struct CLanguageTable
    {
        // Token: 0x060025D8 RID: 9688 RVA: 0x0014E3E2 File Offset: 0x0014C5E2
        public CLanguageTable( string lang, int code )
        {
            this.lang = lang;
            this.code = code;
        }

        // Token: 0x04005EDE RID: 24286
        public string lang;

        // Token: 0x04005EDF RID: 24287
        public int code;
    }
}