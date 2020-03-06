using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using er;
using accel;

public partial class AppMain
{
    // Token: 0x0200024C RID: 588
    private class GMS_CLRDM_MAIN_WORK
    {
        // Token: 0x0400584A RID: 22602
        public readonly AppMain.AMS_FS[] ama_fs = new AppMain.AMS_FS[2];

        // Token: 0x0400584B RID: 22603
        public readonly AppMain.AMS_FS[] amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x0400584C RID: 22604
        public readonly AppMain.A2S_AMA_HEADER[] ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x0400584D RID: 22605
        public readonly AppMain.AMS_AMB_HEADER[] amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x0400584E RID: 22606
        public readonly AppMain.AOS_TEXTURE[] tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x0400584F RID: 22607
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] tex_up_act = new AppMain.GMS_COCKPIT_2D_WORK[5];

        // Token: 0x04005850 RID: 22608
        public AppMain.GMS_COCKPIT_2D_WORK tex_time_act;

        // Token: 0x04005851 RID: 22609
        public AppMain.GMS_COCKPIT_2D_WORK tex_ring_act;

        // Token: 0x04005852 RID: 22610
        public AppMain.GMS_COCKPIT_2D_WORK tex_total_act;

        // Token: 0x04005853 RID: 22611
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] time_num_act = new AppMain.GMS_COCKPIT_2D_WORK[5];

        // Token: 0x04005854 RID: 22612
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] ring_num_act = new AppMain.GMS_COCKPIT_2D_WORK[5];

        // Token: 0x04005855 RID: 22613
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] total_num_act = new AppMain.GMS_COCKPIT_2D_WORK[9];

        // Token: 0x04005856 RID: 22614
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] line_act = new AppMain.GMS_COCKPIT_2D_WORK[3];

        // Token: 0x04005857 RID: 22615
        public AppMain.GMS_COCKPIT_2D_WORK sonic_icon_act;

        // Token: 0x04005858 RID: 22616
        public AppMain.GMS_COCKPIT_2D_WORK sonic_icon_act2;

        // Token: 0x04005859 RID: 22617
        public AppMain.GMS_COCKPIT_2D_WORK tex_big_time_act;

        // Token: 0x0400585A RID: 22618
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] record_time_num_act = new AppMain.GMS_COCKPIT_2D_WORK[7];

        // Token: 0x0400585B RID: 22619
        public AppMain.GMS_COCKPIT_2D_WORK time_sonic_icon_act;

        // Token: 0x0400585C RID: 22620
        public AppMain.GMS_COCKPIT_2D_WORK tex_new_record_act;

        // Token: 0x0400585D RID: 22621
        public AppMain.GMS_COCKPIT_2D_WORK tex_retry_act;

        // Token: 0x0400585E RID: 22622
        public AppMain.GMS_COCKPIT_2D_WORK tex_back_slct_act;

        // Token: 0x0400585F RID: 22623
        public AppMain.GMS_COCKPIT_2D_WORK bg_retry;

        // Token: 0x04005860 RID: 22624
        public readonly CTrgAoAction trg_retry = new CTrgAoAction();

        // Token: 0x04005861 RID: 22625
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] btn_retry = new AppMain.GMS_COCKPIT_2D_WORK[3];

        // Token: 0x04005862 RID: 22626
        public readonly CTrgAoAction trg_back = new CTrgAoAction();

        // Token: 0x04005863 RID: 22627
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] btn_back = new AppMain.GMS_COCKPIT_2D_WORK[3];

        // Token: 0x04005864 RID: 22628
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] tex_spst_up_act = new AppMain.GMS_COCKPIT_2D_WORK[3];

        // Token: 0x04005865 RID: 22629
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] spst_num_act = new AppMain.GMS_COCKPIT_2D_WORK[7];

        // Token: 0x04005866 RID: 22630
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] icon_emer_up_act = new AppMain.GMS_COCKPIT_2D_WORK[7];

        // Token: 0x04005867 RID: 22631
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] icon_emer_down_act = new AppMain.GMS_COCKPIT_2D_WORK[7];

        // Token: 0x04005868 RID: 22632
        public AppMain.GMS_COCKPIT_2D_WORK icon_emer_light_act;

        // Token: 0x04005869 RID: 22633
        public AppMain.GMS_COCKPIT_2D_WORK tex_extend_act;

        // Token: 0x0400586A RID: 22634
        public AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate proc_input;

        // Token: 0x0400586B RID: 22635
        public AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate proc_update;

        // Token: 0x0400586C RID: 22636
        public AppMain.GMS_CLRDM_MAIN_WORK._WorkDelegate proc_calc_score;

        // Token: 0x0400586D RID: 22637
        public readonly uint[] time_score = new uint[2];

        // Token: 0x0400586E RID: 22638
        public readonly uint[] ring_score = new uint[2];

        // Token: 0x0400586F RID: 22639
        public readonly uint[] total_score = new uint[2];

        // Token: 0x04005870 RID: 22640
        public uint clear_time;

        // Token: 0x04005871 RID: 22641
        public ushort time_min;

        // Token: 0x04005872 RID: 22642
        public ushort time_sec;

        // Token: 0x04005873 RID: 22643
        public ushort time_msec;

        // Token: 0x04005874 RID: 22644
        public float timer;

        // Token: 0x04005875 RID: 22645
        public float flash_timer;

        // Token: 0x04005876 RID: 22646
        public uint flag;

        // Token: 0x04005877 RID: 22647
        public int idle_time;

        // Token: 0x04005878 RID: 22648
        public int count;

        // Token: 0x04005879 RID: 22649
        public int game_mode;

        // Token: 0x0400587A RID: 22650
        public bool is_clear_spe_stg;

        // Token: 0x0400587B RID: 22651
        public bool is_full_eme;

        // Token: 0x0400587C RID: 22652
        public bool is_get_eme;

        // Token: 0x0400587D RID: 22653
        public int has_eme_num;

        // Token: 0x0400587E RID: 22654
        public int get_eme_no;

        // Token: 0x0400587F RID: 22655
        public bool is_first_spe_clear;

        // Token: 0x04005880 RID: 22656
        public int next_evt;

        // Token: 0x04005881 RID: 22657
        public uint cur_retry_slct;

        // Token: 0x04005882 RID: 22658
        public ushort stage_id;

        // Token: 0x04005883 RID: 22659
        public ushort prev_spe_stage_id;

        // Token: 0x04005884 RID: 22660
        public bool nodisp_check;

        // Token: 0x0200024D RID: 589
        // (Invoke) Token: 0x060023BC RID: 9148
        public delegate void _WorkDelegate( AppMain.GMS_CLRDM_MAIN_WORK pArg );
    }

    // Token: 0x0200024E RID: 590
    private class GMS_CLRDM_MGR
    {
        // Token: 0x060023BF RID: 9151 RVA: 0x001496D6 File Offset: 0x001478D6
        public void Clear()
        {
            this.tcb = null;
        }

        // Token: 0x04005885 RID: 22661
        public AppMain.MTS_TASK_TCB tcb;
    }
}