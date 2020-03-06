using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001B0 RID: 432
    public class GMS_SCORE_DISP_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600220B RID: 8715 RVA: 0x00142285 File Offset: 0x00140485
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_SCORE_DISP_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x0600220C RID: 8716 RVA: 0x0014228D File Offset: 0x0014048D
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x0600220D RID: 8717 RVA: 0x00142295 File Offset: 0x00140495
        public GMS_SCORE_DISP_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04004FAB RID: 20395
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004FAC RID: 20396
        public readonly AppMain.GMS_EFFECT_3DES_WORK[] efct_work = new AppMain.GMS_EFFECT_3DES_WORK[5];

        // Token: 0x04004FAD RID: 20397
        public int vib_level;

        // Token: 0x04004FAE RID: 20398
        public int scale;

        // Token: 0x04004FAF RID: 20399
        public AppMain.VecFx32 base_pos;

        // Token: 0x04004FB0 RID: 20400
        public int rise_dist;

        // Token: 0x04004FB1 RID: 20401
        public int rise_spd;

        // Token: 0x04004FB2 RID: 20402
        public int rise_dec;

        // Token: 0x04004FB3 RID: 20403
        public int vib_timer;

        // Token: 0x04004FB4 RID: 20404
        public int timer;
    }
}