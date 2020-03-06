using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020000BF RID: 191
    public class GMS_ENE_HARI_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001EEA RID: 7914 RVA: 0x0013CAE2 File Offset: 0x0013ACE2
        public GMS_ENE_HARI_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001EEB RID: 7915 RVA: 0x0013CB0C File Offset: 0x0013AD0C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x06001EEC RID: 7916 RVA: 0x0013CB1E File Offset: 0x0013AD1E
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_HARI_WORK work )
        {
            return work.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04004B84 RID: 19332
        public AppMain.GMS_ENEMY_3D_WORK ene_3d = new AppMain.GMS_ENEMY_3D_WORK();

        // Token: 0x04004B85 RID: 19333
        public AppMain.GMS_EFFECT_3DES_WORK efct_jet;

        // Token: 0x04004B86 RID: 19334
        public AppMain.NNS_MATRIX jet_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
    }
}
