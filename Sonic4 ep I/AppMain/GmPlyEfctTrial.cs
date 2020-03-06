using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x020003C7 RID: 967
    public class GMS_PLY_EFCT_TRAIL_COLOR
    {
        // Token: 0x06002835 RID: 10293 RVA: 0x00152975 File Offset: 0x00150B75
        public GMS_PLY_EFCT_TRAIL_COLOR( AppMain.NNS_RGBA s_col, AppMain.NNS_RGBA e_col )
        {
            this.start_col = s_col;
            this.end_col = e_col;
        }

        // Token: 0x06002836 RID: 10294 RVA: 0x0015298B File Offset: 0x00150B8B
        public GMS_PLY_EFCT_TRAIL_COLOR()
        {
            this.start_col = default( AppMain.NNS_RGBA );
            this.end_col = default( AppMain.NNS_RGBA );
        }

        // Token: 0x040061FD RID: 25085
        public readonly AppMain.NNS_RGBA start_col;

        // Token: 0x040061FE RID: 25086
        public readonly AppMain.NNS_RGBA end_col;
    }

    // Token: 0x020003C8 RID: 968
    public class GMS_PLY_EFCT_TRAIL_SETTING
    {
        // Token: 0x06002837 RID: 10295 RVA: 0x001529AB File Offset: 0x00150BAB
        public GMS_PLY_EFCT_TRAIL_SETTING( float start_size, float end_size, float life, float vanish_time )
        {
            this.start_size = start_size;
            this.end_size = end_size;
            this.life = life;
            this.vanish_time = vanish_time;
        }

        // Token: 0x040061FF RID: 25087
        public float start_size;

        // Token: 0x04006200 RID: 25088
        public float end_size;

        // Token: 0x04006201 RID: 25089
        public float life;

        // Token: 0x04006202 RID: 25090
        public float vanish_time;
    }
}