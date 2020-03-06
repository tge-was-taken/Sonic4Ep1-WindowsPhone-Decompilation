using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000251 RID: 593
    public class GMS_BOSS4_CHIBI_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023C4 RID: 9156 RVA: 0x00149750 File Offset: 0x00147950
        public GMS_BOSS4_CHIBI_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023C5 RID: 9157 RVA: 0x001497A6 File Offset: 0x001479A6
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x060023C6 RID: 9158 RVA: 0x001497B8 File Offset: 0x001479B8
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BOSS4_CHIBI_WORK work )
        {
            return work.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005898 RID: 22680
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04005899 RID: 22681
        public int type;

        // Token: 0x0400589A RID: 22682
        public uint flag;

        // Token: 0x0400589B RID: 22683
        public readonly AppMain.GMS_BOSS4_1SHOT_TIMER timer = new AppMain.GMS_BOSS4_1SHOT_TIMER();

        // Token: 0x0400589C RID: 22684
        public int act_id;

        // Token: 0x0400589D RID: 22685
        public int cap_no;

        // Token: 0x0400589E RID: 22686
        public readonly AppMain.GMS_BOSS4_EFF_BOMB_WORK bomb = new AppMain.GMS_BOSS4_EFF_BOMB_WORK();

        // Token: 0x0400589F RID: 22687
        public int wait;

        // Token: 0x040058A0 RID: 22688
        public readonly AppMain.GMS_BOSS4_FLICKER_WORK flk_work = new AppMain.GMS_BOSS4_FLICKER_WORK();

        // Token: 0x040058A1 RID: 22689
        public int count;

        // Token: 0x040058A2 RID: 22690
        public readonly AppMain.GMS_BOSS4_DIRECTION dir = new AppMain.GMS_BOSS4_DIRECTION();

        // Token: 0x040058A3 RID: 22691
        public int bound;

        // Token: 0x040058A4 RID: 22692
        public int bnd_xspd;

        // Token: 0x040058A5 RID: 22693
        public AppMain.GMS_EFFECT_3DES_WORK boost;

        // Token: 0x040058A6 RID: 22694
        public readonly AppMain.GMS_BOSS4_NODE_MATRIX node_work = new AppMain.GMS_BOSS4_NODE_MATRIX();

        // Token: 0x040058A7 RID: 22695
        public AppMain.MPP_VOID_GMS_BOSS4_CHIBI_WORK proc_update;
    }

    // Token: 0x02000252 RID: 594
    private static class gmBoss4ChibiGetAttackTypeStatics
    {
        // Token: 0x040058A8 RID: 22696
        public static int _index = 0;

        // Token: 0x040058A9 RID: 22697
        public static readonly int[] life2_tbl = new int[]
        {
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            1,
            0,
            0
        };

        // Token: 0x040058AA RID: 22698
        public static readonly int[] life1_tbl = new int[]
        {
            0,
            1,
            0,
            1,
            0,
            2,
            1,
            2,
            1,
            2,
            0,
            1,
            2,
            1,
            0,
            2,
            1,
            0,
            1,
            2
        };

        // Token: 0x040058AB RID: 22699
        public static readonly int[] life3_tbl_f = new int[]
        {
            0,
            0,
            3,
            0,
            0,
            0,
            0,
            3,
            0,
            0,
            0,
            0,
            3,
            0,
            0,
            0,
            0,
            3,
            0,
            0
        };

        // Token: 0x040058AC RID: 22700
        public static readonly int[] life2_tbl_f = new int[]
        {
            0,
            0,
            3,
            0,
            1,
            0,
            0,
            3,
            0,
            1,
            0,
            0,
            3,
            0,
            1,
            0,
            1,
            3,
            0,
            0
        };

        // Token: 0x040058AD RID: 22701
        public static readonly int[] life1_tbl_f = new int[]
        {
            0,
            1,
            3,
            1,
            0,
            2,
            1,
            0,
            1,
            2,
            3,
            1,
            0,
            1,
            3,
            2,
            1,
            3,
            1,
            2
        };
    }

    // Token: 0x02000253 RID: 595
    private static class gmBoss4ChibiGetThrowTypeStatics
    {
        // Token: 0x040058AE RID: 22702
        public static int _index = 0;

        // Token: 0x040058AF RID: 22703
        public static readonly int[] _tbl = new int[]
        {
            0,
            0,
            1,
            0,
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            1,
            0,
            0,
            0,
            0,
            0,
            1,
            0,
            0
        };
    }

    // Token: 0x02000254 RID: 596
    public class GMS_BOSS4_PART_ACT_INFO
    {
        // Token: 0x060023C9 RID: 9161 RVA: 0x00149A57 File Offset: 0x00147C57
        public GMS_BOSS4_PART_ACT_INFO()
        {
        }

        // Token: 0x060023CA RID: 9162 RVA: 0x00149A60 File Offset: 0x00147C60
        public GMS_BOSS4_PART_ACT_INFO( int _act_id, bool _is_maintain, bool _is_repeat, float _mtn_spd, bool _is_blend, float _blend_spd, bool _is_merge_manual )
        {
            this.act_id = ( ushort )_act_id;
            this.is_maintain = ( byte )( _is_maintain ? 1 : 0 );
            this.is_repeat = ( byte )( _is_repeat ? 1 : 0 );
            this.mtn_spd = _mtn_spd;
            this.is_blend = ( _is_blend ? 1 : 0 );
            this.blend_spd = _blend_spd;
            this.is_merge_manual = _is_merge_manual;
        }

        // Token: 0x040058B0 RID: 22704
        public ushort act_id;

        // Token: 0x040058B1 RID: 22705
        public byte is_maintain;

        // Token: 0x040058B2 RID: 22706
        public byte is_repeat;

        // Token: 0x040058B3 RID: 22707
        public float mtn_spd;

        // Token: 0x040058B4 RID: 22708
        public int is_blend;

        // Token: 0x040058B5 RID: 22709
        public float blend_spd;

        // Token: 0x040058B6 RID: 22710
        public bool is_merge_manual;
    }

    // Token: 0x02000255 RID: 597
    public class GMS_BOSS4_MTN_SUSPEND_WORK
    {
        // Token: 0x040058B7 RID: 22711
        public bool is_suspended;

        // Token: 0x040058B8 RID: 22712
        public uint suspend_timer;
    }

    // Token: 0x02000256 RID: 598
    public class GMS_BOSS4_MGR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023CC RID: 9164 RVA: 0x00149AC3 File Offset: 0x00147CC3
        public GMS_BOSS4_MGR_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023CD RID: 9165 RVA: 0x00149AD7 File Offset: 0x00147CD7
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x040058B9 RID: 22713
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x040058BA RID: 22714
        public int life;

        // Token: 0x040058BB RID: 22715
        public uint flag;

        // Token: 0x040058BC RID: 22716
        public AppMain.GMS_BOSS4_BODY_WORK body_work;

        // Token: 0x040058BD RID: 22717
        public int obj_create_cnt;
    }

    // Token: 0x02000257 RID: 599
    private static class gmBoss4MgrMainStatics
    {
        // Token: 0x040058BE RID: 22718
        public static float xold;
    }

    // Token: 0x02000258 RID: 600
    private static class gmCameraForceScrollFuncStatics
    {
        // Token: 0x040058BF RID: 22719
        public static float ofst;

        // Token: 0x040058C0 RID: 22720
        public static int _damage_cnt;
    }
}