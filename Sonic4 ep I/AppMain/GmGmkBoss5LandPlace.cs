using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000111 RID: 273
    public class GMS_BOSS5_LAND_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001FCE RID: 8142 RVA: 0x0013D4C6 File Offset: 0x0013B6C6
        public GMS_BOSS5_LAND_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001FCF RID: 8143 RVA: 0x0013D4DA File Offset: 0x0013B6DA
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_BOSS5_LAND_WORK p )
        {
            return p.ene_3d.ene_com;
        }

        // Token: 0x06001FD0 RID: 8144 RVA: 0x0013D4E7 File Offset: 0x0013B6E7
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_BOSS5_LAND_WORK p )
        {
            return p.ene_3d;
        }

        // Token: 0x06001FD1 RID: 8145 RVA: 0x0013D4EF File Offset: 0x0013B6EF
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04004C77 RID: 19575
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04004C78 RID: 19576
        public AppMain.MPP_VOID_GMS_BOSS5_LAND_WORK proc_update;

        // Token: 0x04004C79 RID: 19577
        public AppMain.GMS_BOSS5_MGR_WORK mgr_work;

        // Token: 0x04004C7A RID: 19578
        public uint flag;

        // Token: 0x04004C7B RID: 19579
        public uint wait_timer;
    }

    // Token: 0x02000112 RID: 274
    public class GMS_BOSS5_LDPART_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001FD2 RID: 8146 RVA: 0x0013D504 File Offset: 0x0013B704
        public GMS_BOSS5_LDPART_WORK()
        {
            this.efct_3d = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x06001FD3 RID: 8147 RVA: 0x0013D55E File Offset: 0x0013B75E
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_3d.efct_com.obj_work;
        }

        // Token: 0x04004C7C RID: 19580
        public readonly AppMain.GMS_EFFECT_3DNN_WORK efct_3d;

        // Token: 0x04004C7D RID: 19581
        public readonly AppMain.OBS_COLLISION_WORK col_work = new AppMain.OBS_COLLISION_WORK();

        // Token: 0x04004C7E RID: 19582
        public AppMain.MPP_VOID_GMS_BOSS5_LDPART_WORK proc_update;

        // Token: 0x04004C7F RID: 19583
        public int vib_cnt;

        // Token: 0x04004C80 RID: 19584
        public readonly int[] vib_ofst = new int[2];

        // Token: 0x04004C81 RID: 19585
        public readonly int[] pivot_parent_ofst = new int[2];

        // Token: 0x04004C82 RID: 19586
        public AppMain.NNS_QUATERNION rot_diff_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04004C83 RID: 19587
        public AppMain.NNS_QUATERNION cur_rot_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04004C84 RID: 19588
        public int part_index;

        // Token: 0x04004C85 RID: 19589
        public uint wait_timer;

        // Token: 0x04004C86 RID: 19590
        public uint brk_glass_cnt;
    }

    // Token: 0x02000113 RID: 275
    public class GMS_BOSS5_LAND_PLACEMENT_INFO
    {
        // Token: 0x04004C87 RID: 19591
        public int pos_x;

        // Token: 0x04004C88 RID: 19592
        public int pos_y;

        // Token: 0x04004C89 RID: 19593
        public int part_num;
    }

    // Token: 0x02000248 RID: 584
    public class GMS_GMK_BOSS5_LAND_PLACE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023B3 RID: 9139 RVA: 0x00149505 File Offset: 0x00147705
        public GMS_GMK_BOSS5_LAND_PLACE_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023B4 RID: 9140 RVA: 0x00149519 File Offset: 0x00147719
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x0400582C RID: 22572
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;
    }


    // Token: 0x06000DEC RID: 3564 RVA: 0x0007AA18 File Offset: 0x00078C18
    private static AppMain.OBS_OBJECT_WORK GmGmkBoss5LandPlaceInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BOSS5_LAND_PLACE_WORK(), "BOSS5_LAND_PLACE");
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        return obs_OBJECT_WORK;
    }
}