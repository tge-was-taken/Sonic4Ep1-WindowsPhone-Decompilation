using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000073 RID: 115
    public class GMS_GMK_BOSS5_TRIGGER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E25 RID: 7717 RVA: 0x00139662 File Offset: 0x00137862
        public GMS_GMK_BOSS5_TRIGGER_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001E26 RID: 7718 RVA: 0x00139676 File Offset: 0x00137876
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0400497F RID: 18815
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;
    }
}