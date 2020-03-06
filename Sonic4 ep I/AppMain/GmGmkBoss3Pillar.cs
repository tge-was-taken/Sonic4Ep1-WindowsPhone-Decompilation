using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002D8 RID: 728
    public class GMS_GMK_BOSS3_PILLAR_MAIN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024BA RID: 9402 RVA: 0x0014B162 File Offset: 0x00149362
        public GMS_GMK_BOSS3_PILLAR_MAIN_WORK()
        {
            this.gimmick_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060024BB RID: 9403 RVA: 0x0014B19A File Offset: 0x0014939A
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK p )
        {
            return p.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x060024BC RID: 9404 RVA: 0x0014B1AC File Offset: 0x001493AC
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x04005C4F RID: 23631
        public readonly AppMain.GMS_ENEMY_3D_WORK gimmick_work;

        // Token: 0x04005C50 RID: 23632
        public readonly AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_parts = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>(8);

        // Token: 0x04005C51 RID: 23633
        public AppMain.GMS_EFFECT_3DES_WORK effect_work;

        // Token: 0x04005C52 RID: 23634
        public AppMain.VecFx32 target_pos = default(AppMain.VecFx32);

        // Token: 0x04005C53 RID: 23635
        public AppMain.VecFx32 default_pos = default(AppMain.VecFx32);

        // Token: 0x04005C54 RID: 23636
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x020002D9 RID: 729
    public class GMS_GMK_BOSS3_PILLAR_WALL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024BD RID: 9405 RVA: 0x0014B1BE File Offset: 0x001493BE
        public GMS_GMK_BOSS3_PILLAR_WALL_WORK()
        {
            this.gimmick_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060024BE RID: 9406 RVA: 0x0014B1DE File Offset: 0x001493DE
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x060024BF RID: 9407 RVA: 0x0014B1F0 File Offset: 0x001493F0
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK work )
        {
            return work.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x04005C55 RID: 23637
        public readonly AppMain.GMS_ENEMY_3D_WORK gimmick_work;

        // Token: 0x04005C56 RID: 23638
        public readonly AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_parts = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>(2);

        // Token: 0x04005C57 RID: 23639
        public AppMain.GMS_EFFECT_3DES_WORK effect_work;

        // Token: 0x04005C58 RID: 23640
        public AppMain.VecFx32 target_pos;

        // Token: 0x04005C59 RID: 23641
        public AppMain.VecFx32 default_pos;

        // Token: 0x04005C5A RID: 23642
        public AppMain.GSS_SND_SE_HANDLE se_handle;
    }

    // Token: 0x020002DA RID: 730
    public class GMS_GMK_BOSS3_PILLAR_MANAGER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024C0 RID: 9408 RVA: 0x0014B202 File Offset: 0x00149402
        public GMS_GMK_BOSS3_PILLAR_MANAGER_WORK()
        {
            this.gimmick_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060024C1 RID: 9409 RVA: 0x0014B22F File Offset: 0x0014942F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x060024C2 RID: 9410 RVA: 0x0014B241 File Offset: 0x00149441
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK work )
        {
            return work.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x04005C5B RID: 23643
        public readonly AppMain.GMS_ENEMY_3D_WORK gimmick_work;

        // Token: 0x04005C5C RID: 23644
        public readonly AppMain.OBS_OBJECT_WORK[] obj_work_pillar = new AppMain.OBS_OBJECT_WORK[26];

        // Token: 0x04005C5D RID: 23645
        public readonly AppMain.OBS_OBJECT_WORK[] obj_work_wall = new AppMain.OBS_OBJECT_WORK[2];

        // Token: 0x04005C5E RID: 23646
        public int pattern_no;
    }
}