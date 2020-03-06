using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001F9 RID: 505
    public class GMS_PLAYER_PACKET
    {
        // Token: 0x04005520 RID: 21792
        public AppMain.VecFx32 pos = default(AppMain.VecFx32);

        // Token: 0x04005521 RID: 21793
        public ushort disp_flag;

        // Token: 0x04005522 RID: 21794
        public short anime_speed;

        // Token: 0x04005523 RID: 21795
        public byte act_state;

        // Token: 0x04005524 RID: 21796
        public byte dir_x;

        // Token: 0x04005525 RID: 21797
        public byte dir_y;

        // Token: 0x04005526 RID: 21798
        public byte dir_z;

        // Token: 0x04005527 RID: 21799
        public uint move_flag;

        // Token: 0x04005528 RID: 21800
        public uint player_flag;

        // Token: 0x04005529 RID: 21801
        public uint gmk_flag;

        // Token: 0x0400552A RID: 21802
        public short move_x;

        // Token: 0x0400552B RID: 21803
        public short move_y;

        // Token: 0x0400552C RID: 21804
        public int camera_pos_x;

        // Token: 0x0400552D RID: 21805
        public int camera_pos_y;

        // Token: 0x0400552E RID: 21806
        public uint time;
    }

    // Token: 0x020001FA RID: 506
    // (Invoke) Token: 0x0600231F RID: 8991
    public delegate void seq_func_delegate( AppMain.GMS_PLAYER_WORK ply_work );

    // Token: 0x020001FB RID: 507
    public class GMS_PLAYER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002322 RID: 8994 RVA: 0x00147FF2 File Offset: 0x001461F2
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_PLAYER_WORK work )
        {
            if ( work == null )
            {
                return null;
            }
            return work.obj_work;
        }

        // Token: 0x06002323 RID: 8995 RVA: 0x00147FFF File Offset: 0x001461FF
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x06002324 RID: 8996 RVA: 0x00148008 File Offset: 0x00146208
        public GMS_PLAYER_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x0400552F RID: 21807
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04005530 RID: 21808
        public readonly AppMain.OBS_ACTION3D_NN_WORK[] obj_3d = new AppMain.OBS_ACTION3D_NN_WORK[4];

        // Token: 0x04005531 RID: 21809
        public readonly AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_work = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>(8);

        // Token: 0x04005532 RID: 21810
        public readonly AppMain.OBS_RECT_WORK[] rect_work = AppMain.New<AppMain.OBS_RECT_WORK>(3);

        // Token: 0x04005533 RID: 21811
        public byte char_id;

        // Token: 0x04005534 RID: 21812
        public byte player_id;

        // Token: 0x04005535 RID: 21813
        public byte ctrl_id;

        // Token: 0x04005536 RID: 21814
        public byte camera_no;

        // Token: 0x04005537 RID: 21815
        public int spin_state;

        // Token: 0x04005538 RID: 21816
        public int act_state;

        // Token: 0x04005539 RID: 21817
        public int prev_act_state;

        // Token: 0x0400553A RID: 21818
        public int seq_state;

        // Token: 0x0400553B RID: 21819
        public int prev_seq_state;

        // Token: 0x0400553C RID: 21820
        public int timer;

        // Token: 0x0400553D RID: 21821
        public uint player_flag;

        // Token: 0x0400553E RID: 21822
        public uint gmk_flag;

        // Token: 0x0400553F RID: 21823
        public uint gmk_flag2;

        // Token: 0x04005540 RID: 21824
        public int dash_power;

        // Token: 0x04005541 RID: 21825
        public int prev_walk_roll_spd_max;

        // Token: 0x04005542 RID: 21826
        public AppMain.seq_func_delegate seq_func;

        // Token: 0x04005543 RID: 21827
        public AppMain.seq_func_delegate[] seq_init_tbl;

        // Token: 0x04005544 RID: 21828
        public AppMain.GMS_PLY_SEQ_STATE_DATA[] seq_state_data_tbl;

        // Token: 0x04005545 RID: 21829
        public readonly AppMain.NNS_MATRIX ex_obj_mtx_r = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005546 RID: 21830
        public short spin_se_timer;

        // Token: 0x04005547 RID: 21831
        public short spin_back_se_timer;

        // Token: 0x04005548 RID: 21832
        public short tension;

        // Token: 0x04005549 RID: 21833
        public short over_limit_spd;

        // Token: 0x0400554A RID: 21834
        public int no_spddown_timer;

        // Token: 0x0400554B RID: 21835
        public int spd_add;

        // Token: 0x0400554C RID: 21836
        public int spd_max;

        // Token: 0x0400554D RID: 21837
        public int spd_dec;

        // Token: 0x0400554E RID: 21838
        public int spd_spin;

        // Token: 0x0400554F RID: 21839
        public int spd_add_spin;

        // Token: 0x04005550 RID: 21840
        public int spd_max_spin;

        // Token: 0x04005551 RID: 21841
        public int spd_dec_spin;

        // Token: 0x04005552 RID: 21842
        public int spd_max_boost;

        // Token: 0x04005553 RID: 21843
        public int spd_add_nitro;

        // Token: 0x04005554 RID: 21844
        public int spd_max_nitro;

        // Token: 0x04005555 RID: 21845
        public int spd_dec_nitro;

        // Token: 0x04005556 RID: 21846
        public int spd_chk_nitro;

        // Token: 0x04005557 RID: 21847
        public int spd_max_add_slope;

        // Token: 0x04005558 RID: 21848
        public int spd_jump;

        // Token: 0x04005559 RID: 21849
        public int spd_work_max;

        // Token: 0x0400555A RID: 21850
        public int spd_jump_add;

        // Token: 0x0400555B RID: 21851
        public int spd_jump_max;

        // Token: 0x0400555C RID: 21852
        public int spd_jump_dec;

        // Token: 0x0400555D RID: 21853
        public int spd_add_spin_pinball;

        // Token: 0x0400555E RID: 21854
        public int spd_max_spin_pinball;

        // Token: 0x0400555F RID: 21855
        public int spd_dec_spin_pinball;

        // Token: 0x04005560 RID: 21856
        public int spd_max_add_slope_spin_pinball;

        // Token: 0x04005561 RID: 21857
        public int time_air;

        // Token: 0x04005562 RID: 21858
        public int time_damage;

        // Token: 0x04005563 RID: 21859
        public int spd1;

        // Token: 0x04005564 RID: 21860
        public int spd2;

        // Token: 0x04005565 RID: 21861
        public int spd3;

        // Token: 0x04005566 RID: 21862
        public int spd4;

        // Token: 0x04005567 RID: 21863
        public int spd5;

        // Token: 0x04005568 RID: 21864
        public AppMain.VecFx32 boost_pos1 = default(AppMain.VecFx32);

        // Token: 0x04005569 RID: 21865
        public AppMain.VecFx32 boost_pos2 = default(AppMain.VecFx32);

        // Token: 0x0400556A RID: 21866
        public short spd_pool;

        // Token: 0x0400556B RID: 21867
        public short ring_num;

        // Token: 0x0400556C RID: 21868
        public short ring_stage_num;

        // Token: 0x0400556D RID: 21869
        public uint score;

        // Token: 0x0400556E RID: 21870
        public int invincible_timer;

        // Token: 0x0400556F RID: 21871
        public int genocide_timer;

        // Token: 0x04005570 RID: 21872
        public int pressure_timer;

        // Token: 0x04005571 RID: 21873
        public int disapprove_item_catch_timer;

        // Token: 0x04005572 RID: 21874
        public int water_timer;

        // Token: 0x04005573 RID: 21875
        public int no_key_timer;

        // Token: 0x04005574 RID: 21876
        public int homing_timer;

        // Token: 0x04005575 RID: 21877
        public int hi_speed_timer;

        // Token: 0x04005576 RID: 21878
        public int homing_boost_timer;

        // Token: 0x04005577 RID: 21879
        public int fall_timer;

        // Token: 0x04005578 RID: 21880
        public int no_jump_move_timer;

        // Token: 0x04005579 RID: 21881
        public int maxdash_timer;

        // Token: 0x0400557A RID: 21882
        public int super_sonic_ring_timer;

        // Token: 0x0400557B RID: 21883
        public int camera_stop_timer;

        // Token: 0x0400557C RID: 21884
        public int camera_ofst_x;

        // Token: 0x0400557D RID: 21885
        public int camera_ofst_y;

        // Token: 0x0400557E RID: 21886
        public int camera_ofst_tag_x;

        // Token: 0x0400557F RID: 21887
        public int camera_ofst_tag_y;

        // Token: 0x04005580 RID: 21888
        public int camera_jump_pos_y;

        // Token: 0x04005581 RID: 21889
        public AppMain.OBS_OBJECT_WORK enemy_obj;

        // Token: 0x04005582 RID: 21890
        public AppMain.OBS_OBJECT_WORK cursol_enemy_obj;

        // Token: 0x04005583 RID: 21891
        public ushort pgm_turn_dir;

        // Token: 0x04005584 RID: 21892
        public ushort pgm_turn_spd;

        // Token: 0x04005585 RID: 21893
        public ushort[] pgm_turn_dir_tbl;

        // Token: 0x04005586 RID: 21894
        public int pgm_turn_tbl_cnt;

        // Token: 0x04005587 RID: 21895
        public int pgm_turn_tbl_num;

        // Token: 0x04005588 RID: 21896
        public int fall_act_state;

        // Token: 0x04005589 RID: 21897
        public int scroll_spd_x;

        // Token: 0x0400558A RID: 21898
        public uint score_combo_cnt;

        // Token: 0x0400558B RID: 21899
        public AppMain.OBS_OBJECT_WORK gmk_obj;

        // Token: 0x0400558C RID: 21900
        public short gmk_camera_ofst_x;

        // Token: 0x0400558D RID: 21901
        public short gmk_camera_ofst_y;

        // Token: 0x0400558E RID: 21902
        public short gmk_camera_center_ofst_x;

        // Token: 0x0400558F RID: 21903
        public short gmk_camera_center_ofst_y;

        // Token: 0x04005590 RID: 21904
        public short gmk_camera_gmk_center_ofst_x;

        // Token: 0x04005591 RID: 21905
        public short gmk_camera_gmk_center_ofst_y;

        // Token: 0x04005592 RID: 21906
        public short gmk_map_limit_left;

        // Token: 0x04005593 RID: 21907
        public short gmk_map_limit_right;

        // Token: 0x04005594 RID: 21908
        public short gmk_map_limit_top;

        // Token: 0x04005595 RID: 21909
        public short gmk_map_limit_bottom;

        // Token: 0x04005596 RID: 21910
        public int gmk_work0;

        // Token: 0x04005597 RID: 21911
        public int gmk_work1;

        // Token: 0x04005598 RID: 21912
        public int gmk_work2;

        // Token: 0x04005599 RID: 21913
        public int gmk_work3;

        // Token: 0x0400559A RID: 21914
        public object opt_anime;

        // Token: 0x0400559B RID: 21915
        public ushort prev_dir_fall;

        // Token: 0x0400559C RID: 21916
        public ushort prev_dir_fall2;

        // Token: 0x0400559D RID: 21917
        public int dir_fall_fix_timer;

        // Token: 0x0400559E RID: 21918
        public int ply_pseudofall_dir;

        // Token: 0x0400559F RID: 21919
        public ushort jump_pseudofall_dir;

        // Token: 0x040055A0 RID: 21920
        public ushort jump_pseudofall_eve_id_set;

        // Token: 0x040055A1 RID: 21921
        public ushort jump_pseudofall_eve_id_cur;

        // Token: 0x040055A2 RID: 21922
        public ushort jump_pseudofall_eve_id_wait;

        // Token: 0x040055A3 RID: 21923
        public int truck_left_flip_timer;

        // Token: 0x040055A4 RID: 21924
        public AppMain.OBS_OBJECT_WORK truck_obj;

        // Token: 0x040055A5 RID: 21925
        public ushort truck_prev_dir;

        // Token: 0x040055A6 RID: 21926
        public ushort truck_prev_dir_fall;

        // Token: 0x040055A7 RID: 21927
        public readonly AppMain.NNS_MATRIX truck_mtx_ply_mtn_pos = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x040055A8 RID: 21928
        public ushort truck_stick_prev_dir;

        // Token: 0x040055A9 RID: 21929
        public AppMain.OBS_OBJECT_WORK efct_spin_jump_blur;

        // Token: 0x040055AA RID: 21930
        public AppMain.OBS_OBJECT_WORK efct_spin_dash_blur;

        // Token: 0x040055AB RID: 21931
        public AppMain.OBS_OBJECT_WORK efct_spin_dash_cir_blur;

        // Token: 0x040055AC RID: 21932
        public AppMain.OBS_OBJECT_WORK efct_spin_start_blur;

        // Token: 0x040055AD RID: 21933
        public AppMain.OBS_OBJECT_WORK efct_run_spray;

        // Token: 0x040055AE RID: 21934
        public float light_rate;

        // Token: 0x040055AF RID: 21935
        public int light_anm_flag;

        // Token: 0x040055B0 RID: 21936
        public short speed_curse;

        // Token: 0x040055B1 RID: 21937
        public short prev_speed_curse;

        // Token: 0x040055B2 RID: 21938
        public int warp_pos_x;

        // Token: 0x040055B3 RID: 21939
        public int warp_pos_y;

        // Token: 0x040055B4 RID: 21940
        public byte graind_id;

        // Token: 0x040055B5 RID: 21941
        public byte graind_prev_ride;

        // Token: 0x040055B6 RID: 21942
        public short nudge_di_timer;

        // Token: 0x040055B7 RID: 21943
        public short nudge_timer;

        // Token: 0x040055B8 RID: 21944
        public int nudge_ofst_x;

        // Token: 0x040055B9 RID: 21945
        public bool is_nudge;

        // Token: 0x040055BA RID: 21946
        public readonly AppMain.NNS_VECTOR calc_accel = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040055BB RID: 21947
        public ushort key_on;

        // Token: 0x040055BC RID: 21948
        public ushort key_push;

        // Token: 0x040055BD RID: 21949
        public ushort key_repeat;

        // Token: 0x040055BE RID: 21950
        public ushort key_release;

        // Token: 0x040055BF RID: 21951
        public int key_rot_z;

        // Token: 0x040055C0 RID: 21952
        public int key_walk_rot_z;

        // Token: 0x040055C1 RID: 21953
        public readonly ushort[] key_map = new ushort[8];

        // Token: 0x040055C2 RID: 21954
        public readonly int[] key_repeat_timer = new int[8];

        // Token: 0x040055C3 RID: 21955
        public int prev_key_rot_z;

        // Token: 0x040055C4 RID: 21956
        public int accel_counter;

        // Token: 0x040055C5 RID: 21957
        public int dir_vec_add;

        // Token: 0x040055C6 RID: 21958
        public int control_type;

        // Token: 0x040055C7 RID: 21959
        public ushort[] jump_rect;

        // Token: 0x040055C8 RID: 21960
        public ushort[] ssonic_rect;

        // Token: 0x040055C9 RID: 21961
        public int safe_timer;

        // Token: 0x040055CA RID: 21962
        public int safe_jump_timer;

        // Token: 0x040055CB RID: 21963
        public int safe_spin_timer;

        // Token: 0x040055CC RID: 21964
        public uint net_ref_atk_time;

        // Token: 0x040055CD RID: 21965
        public readonly AppMain.GMS_PLAYER_PACKET[] player_packet = AppMain.New<AppMain.GMS_PLAYER_PACKET>(4);

        // Token: 0x040055CE RID: 21966
        public int packet_camera_pos_x;

        // Token: 0x040055CF RID: 21967
        public int packet_camera_pos_y;

        // Token: 0x040055D0 RID: 21968
        public short use_packet_buf_no;
    }

    // Token: 0x020001FC RID: 508
    public class GMS_PLAYER_RESET_ACT_WORK
    {
        // Token: 0x040055D1 RID: 21969
        public readonly float[] frame = new float[2];

        // Token: 0x040055D2 RID: 21970
        public float blend_spd;

        // Token: 0x040055D3 RID: 21971
        public float marge;

        // Token: 0x040055D4 RID: 21972
        public uint obj_3d_flag;
    }

    // Token: 0x06000AA1 RID: 2721 RVA: 0x0005DC30 File Offset: 0x0005BE30
    public static bool GMM_PLAYER_IS_TOUCH_SUPER_SONIC_REGION( int x, int y )
    {
        return x > 390 && x < 475 && y > 5 && y < 85;
    }

    // Token: 0x06000AA2 RID: 2722 RVA: 0x0005DC4F File Offset: 0x0005BE4F
    public static void GMD_PLAYER_WATER_SET( ref int fSpd )
    {
        fSpd >>= 1;
    }

    // Token: 0x06000AA3 RID: 2723 RVA: 0x0005DC57 File Offset: 0x0005BE57
    public static void GMD_PLAYER_WATERJUMP_SET( ref int fSpd )
    {
        fSpd = ( fSpd >> 1 ) + ( fSpd >> 2 );
    }

    // Token: 0x06000AA4 RID: 2724 RVA: 0x0005DC64 File Offset: 0x0005BE64
    public static int GMD_PLAYER_WATER_GET( int fSpd )
    {
        return fSpd >> 1;
    }

    // Token: 0x06000AA5 RID: 2725 RVA: 0x0005DC69 File Offset: 0x0005BE69
    public static int GMD_PLAYER_WATERJUMP_GET( int fSpd )
    {
        return ( fSpd >> 1 ) + ( fSpd >> 2 );
    }

    // Token: 0x06000AA6 RID: 2726 RVA: 0x0005DC74 File Offset: 0x0005BE74
    private static void GmPlayerBuild()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile((AppMain.AMS_FS)AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][0].pData);
        AppMain.AMS_AMB_HEADER amb_tex = AppMain.readAMBFile((AppMain.AMS_FS)AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][1].pData);
        AppMain.g_gm_ply_son_obj_3d_list = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>( ams_AMB_HEADER.file_num );
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(AppMain.g_gm_ply_son_obj_3d_list);
        int i = 0;
        while ( i < ams_AMB_HEADER.file_num )
        {
            AppMain.ObjAction3dNNModelLoad( pointer, null, null, i, ams_AMB_HEADER, null, amb_tex, 0U );
            i++;
            pointer = ++pointer;
        }
        ams_AMB_HEADER = AppMain.readAMBFile( ( AppMain.AMS_FS )AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][2].pData );
        amb_tex = AppMain.readAMBFile( ( AppMain.AMS_FS )AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][3].pData );
        AppMain.g_gm_ply_sson_obj_3d_list = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>( ams_AMB_HEADER.file_num );
        pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>( AppMain.g_gm_ply_sson_obj_3d_list );
        i = 0;
        while ( i < ams_AMB_HEADER.file_num )
        {
            AppMain.ObjAction3dNNModelLoad( pointer, null, null, i, ams_AMB_HEADER, null, amb_tex, 0U );
            i++;
            pointer = ++pointer;
        }
        AppMain.gm_ply_obj_3d_list_tbl = new AppMain.OBS_ACTION3D_NN_WORK[][][]
        {
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            },
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            },
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            },
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            },
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            },
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            },
            new AppMain.OBS_ACTION3D_NN_WORK[][]
            {
                AppMain.g_gm_ply_son_obj_3d_list,
                AppMain.g_gm_ply_sson_obj_3d_list
            }
        };
    }

    // Token: 0x06000AA7 RID: 2727 RVA: 0x0005DE64 File Offset: 0x0005C064
    private static void GmPlayerFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile((AppMain.AMS_FS)AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][0].pData);
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(AppMain.g_gm_ply_son_obj_3d_list);
        int i = 0;
        while ( i < ams_AMB_HEADER.file_num )
        {
            AppMain.ObjAction3dNNModelRelease( pointer );
            i++;
            pointer = ++pointer;
        }
        ams_AMB_HEADER = AppMain.readAMBFile( ( AppMain.AMS_FS )AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][2].pData );
        pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>( AppMain.g_gm_ply_sson_obj_3d_list );
        i = 0;
        while ( i < ams_AMB_HEADER.file_num )
        {
            AppMain.ObjAction3dNNModelRelease( ~pointer );
            i++;
            pointer = ++pointer;
        }
    }

    // Token: 0x06000AA8 RID: 2728 RVA: 0x0005DF04 File Offset: 0x0005C104
    private static bool GmPlayerBuildCheck()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile((AppMain.AMS_FS)AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][0].pData);
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(AppMain.g_gm_ply_son_obj_3d_list);
        int i = 0;
        while ( i < ams_AMB_HEADER.file_num )
        {
            if ( !AppMain.ObjAction3dNNModelLoadCheck( pointer ) )
            {
                return false;
            }
            i++;
            pointer = ++pointer;
        }
        ams_AMB_HEADER = AppMain.readAMBFile( ( AppMain.AMS_FS )AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][2].pData );
        pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>( AppMain.g_gm_ply_sson_obj_3d_list );
        i = 0;
        while ( i < ams_AMB_HEADER.file_num )
        {
            if ( !AppMain.ObjAction3dNNModelLoadCheck( pointer ) )
            {
                return false;
            }
            i++;
            pointer = ++pointer;
        }
        return true;
    }

    // Token: 0x06000AA9 RID: 2729 RVA: 0x0005DFAC File Offset: 0x0005C1AC
    private static bool GmPlayerFlushCheck()
    {
        if ( AppMain.g_gm_ply_son_obj_3d_list != null )
        {
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile((AppMain.AMS_FS)AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][0].pData);
            AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(AppMain.g_gm_ply_son_obj_3d_list);
            int i = 0;
            while ( i < ams_AMB_HEADER.file_num )
            {
                if ( !AppMain.ObjAction3dNNModelReleaseCheck( pointer ) )
                {
                    return false;
                }
                i++;
                pointer = ++pointer;
            }
            AppMain.g_gm_ply_son_obj_3d_list = null;
        }
        if ( AppMain.g_gm_ply_sson_obj_3d_list != null )
        {
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile((AppMain.AMS_FS)AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][2].pData);
            AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(AppMain.g_gm_ply_sson_obj_3d_list);
            int i = 0;
            while ( i < ams_AMB_HEADER.file_num )
            {
                if ( !AppMain.ObjAction3dNNModelReleaseCheck( pointer ) )
                {
                    return false;
                }
                i++;
                pointer = ++pointer;
            }
            AppMain.g_gm_ply_sson_obj_3d_list = null;
        }
        return true;
    }

    // Token: 0x06000AAA RID: 2730 RVA: 0x0005E070 File Offset: 0x0005C270
    private static void GmPlayerRelease()
    {
        int num = 0;
        while ( ( long )num < 1L )
        {
            for ( int i = 0; i < 5; i++ )
            {
                AppMain.ObjDataRelease( AppMain.g_gm_player_data_work[num][i] );
            }
            num++;
        }
    }

    // Token: 0x06000AAB RID: 2731 RVA: 0x0005E0B8 File Offset: 0x0005C2B8
    private static AppMain.GMS_PLAYER_WORK GmPlayerInit( int char_id, ushort ctrl_id, ushort player_id, ushort camera_id )
    {
        ushort[] array = new ushort[]
        {
            default(ushort),
            6,
            1
        };
        ushort[] array2 = new ushort[]
        {
            65533,
            ushort.MaxValue,
            65534
        };
        if ( char_id >= 7 )
        {
            char_id = 0;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(4352, 1, 0, 0, () => new AppMain.GMS_PLAYER_WORK(), "PLAYER OBJ");
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmPlayerExit ) );
        obs_OBJECT_WORK.ppUserRelease = new AppMain.OBS_OBJECT_WORK_Delegate4( AppMain.gmPlayerObjRelease );
        obs_OBJECT_WORK.ppUserReleaseWait = new AppMain.OBS_OBJECT_WORK_Delegate4( AppMain.gmPlayerObjReleaseWait );
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK;
        gms_PLAYER_WORK.player_id = ( byte )player_id;
        gms_PLAYER_WORK.camera_no = ( byte )camera_id;
        gms_PLAYER_WORK.ctrl_id = ( byte )ctrl_id;
        gms_PLAYER_WORK.char_id = ( byte )char_id;
        gms_PLAYER_WORK.act_state = -1;
        gms_PLAYER_WORK.prev_act_state = -1;
        AppMain.nnMakeUnitMatrix( gms_PLAYER_WORK.ex_obj_mtx_r );
        AppMain.GmPlayerInitModel( gms_PLAYER_WORK );
        gms_PLAYER_WORK.key_map[0] = 1;
        gms_PLAYER_WORK.key_map[1] = 2;
        gms_PLAYER_WORK.key_map[2] = 4;
        gms_PLAYER_WORK.key_map[3] = 8;
        gms_PLAYER_WORK.key_map[4] = 32;
        gms_PLAYER_WORK.key_map[5] = 128;
        gms_PLAYER_WORK.key_map[6] = 64;
        gms_PLAYER_WORK.key_map[7] = 16;
        obs_OBJECT_WORK.obj_type = 1;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.flag |= 1U;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerDispFunc );
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            obs_OBJECT_WORK.ppIn = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerDefaultInFunc );
        }
        else
        {
            obs_OBJECT_WORK.ppIn = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerSplStgInFunc );
        }
        obs_OBJECT_WORK.ppLast = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerDefaultLastFunc );
        obs_OBJECT_WORK.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmPlySeqMoveFunc );
        obs_OBJECT_WORK.disp_flag |= 2048U;
        AppMain.GmPlySeqSetSeqState( gms_PLAYER_WORK );
        AppMain.GmPlayerStateInit( gms_PLAYER_WORK );
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -6, -12, 6, 13 );
        AppMain.ObjObjectGetRectBuf( obs_OBJECT_WORK, gms_PLAYER_WORK.rect_work, 3 );
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.ObjRectGroupSet( gms_PLAYER_WORK.rect_work[i], 0, 2 );
            AppMain.ObjRectAtkSet( gms_PLAYER_WORK.rect_work[i], array[i], 1 );
            AppMain.ObjRectDefSet( gms_PLAYER_WORK.rect_work[i], array2[i], 0 );
            gms_PLAYER_WORK.rect_work[i].parent_obj = obs_OBJECT_WORK;
            gms_PLAYER_WORK.rect_work[i].flag &= 4294967291U;
            gms_PLAYER_WORK.rect_work[i].rect.back = -16;
            gms_PLAYER_WORK.rect_work[i].rect.front = 16;
        }
        gms_PLAYER_WORK.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmPlayerDefFunc );
        gms_PLAYER_WORK.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmPlayerAtkFunc );
        gms_PLAYER_WORK.rect_work[0].flag |= 128U;
        gms_PLAYER_WORK.rect_work[1].flag |= 32U;
        gms_PLAYER_WORK.rect_work[2].flag |= 224U;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -7, -8, 7, 10 );
            AppMain.ObjRectWorkZSet( gms_PLAYER_WORK.rect_work[2], -11, -11, -500, 11, 11, 500 );
            AppMain.ObjRectWorkZSet( gms_PLAYER_WORK.rect_work[0], -12, -12, -500, 12, 12, 500 );
            AppMain.ObjRectWorkZSet( gms_PLAYER_WORK.rect_work[1], -13, -13, -500, 13, 13, 500 );
        }
        else
        {
            AppMain.ObjRectWorkZSet( gms_PLAYER_WORK.rect_work[2], -8, -19, -500, 8, 13, 500 );
            AppMain.ObjRectWorkZSet( gms_PLAYER_WORK.rect_work[0], -8, -19, -500, 8, 13, 500 );
            AppMain.ObjRectWorkZSet( gms_PLAYER_WORK.rect_work[1], -16, -19, -500, 16, 13, 500 );
        }
        gms_PLAYER_WORK.rect_work[1].flag &= 4294967291U;
        AppMain.ObjRectWorkZSet( AppMain.gm_ply_touch_rect[0], -16, -51, -500, 64, 37, 500 );
        AppMain.ObjRectWorkZSet( AppMain.gm_ply_touch_rect[1], -64, -51, -500, -16, 37, 500 );
        gms_PLAYER_WORK.calc_accel.x = 0f;
        gms_PLAYER_WORK.calc_accel.y = 0f;
        gms_PLAYER_WORK.calc_accel.z = 0f;
        gms_PLAYER_WORK.control_type = 2;
        gms_PLAYER_WORK.jump_rect = AppMain.gm_player_push_jump_key_rect[2];
        gms_PLAYER_WORK.ssonic_rect = AppMain.gm_player_push_ssonic_key_rect[2];
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
        {
            gms_PLAYER_WORK.control_type = 0;
            gms_PLAYER_WORK.jump_rect = AppMain.gm_player_push_jump_key_rect[0];
            gms_PLAYER_WORK.ssonic_rect = AppMain.gm_player_push_ssonic_key_rect[0];
        }
        gms_PLAYER_WORK.accel_counter = 0;
        gms_PLAYER_WORK.dir_vec_add = 0;
        gms_PLAYER_WORK.spin_se_timer = 0;
        gms_PLAYER_WORK.spin_back_se_timer = 0;
        gms_PLAYER_WORK.safe_timer = 0;
        gms_PLAYER_WORK.safe_jump_timer = 0;
        gms_PLAYER_WORK.safe_spin_timer = 0;
        if ( gms_PLAYER_WORK.player_id == 0 )
        {
            AppMain.gm_pos_x = gms_PLAYER_WORK.obj_work.pos.x >> 12;
            AppMain.gm_pos_y = gms_PLAYER_WORK.obj_work.pos.y >> 12;
            AppMain.gm_pos_z = gms_PLAYER_WORK.obj_work.pos.z >> 12;
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerMain );
        AppMain.GmPlySeqChangeFw( gms_PLAYER_WORK );
        if ( !SaveState.resumePlayer_2( gms_PLAYER_WORK ) )
        {
            gms_PLAYER_WORK.obj_work.pos.x = AppMain.g_gm_main_system.resume_pos_x;
            gms_PLAYER_WORK.obj_work.pos.y = AppMain.g_gm_main_system.resume_pos_y;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 5 )
        {
            AppMain.GmPlayerSetPinballSonic( gms_PLAYER_WORK );
        }
        else if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.GmPlayerSetSplStgSonic( gms_PLAYER_WORK );
        }
        return gms_PLAYER_WORK;
    }

    // Token: 0x06000AAC RID: 2732 RVA: 0x0005E664 File Offset: 0x0005C864
    private static void GmPlayerResetInit( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.player_flag &= 4290772991U;
        AppMain.g_obj.flag &= 4294966271U;
        AppMain.g_obj.scroll[0] = ( AppMain.g_obj.scroll[1] = 0 );
        ply_work.player_flag &= 4290766847U;
        ply_work.gmk_flag &= 3556759567U;
        ply_work.graind_id = 0;
        ply_work.graind_prev_ride = 0;
        ply_work.gmk_flag &= 4294967291U;
        ply_work.spd_pool = 0;
        ply_work.obj_work.scale.x = ( ply_work.obj_work.scale.y = ( ply_work.obj_work.scale.z = 4096 ) );
        AppMain.GmPlayerStateInit( ply_work );
        AppMain.GmPlayerStateGimmickInit( ply_work );
    }

    // Token: 0x06000AAD RID: 2733 RVA: 0x0005E744 File Offset: 0x0005C944
    private static void GmPlayerInitModel( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(ply_work.obj_3d_work);
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.OBS_ACTION3D_NN_WORK[] array = AppMain.gm_ply_obj_3d_list_tbl[(int)ply_work.char_id][i];
            int j = 0;
            while ( j < 4 )
            {
                AppMain.ObjCopyAction3dNNModel( array[j], pointer );
                ( ~pointer ).blend_spd = 0.25f;
                AppMain.ObjDrawSetToon( pointer );
                ( ~pointer ).use_light_flag &= 4294967294U;
                ( ~pointer ).use_light_flag |= 64U;
                j++;
                pointer = ++pointer;
            }
        }
        obj_work.obj_3d = ply_work.obj_3d_work[0];
        obj_work.flag |= 536870912U;
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, true, AppMain.g_gm_player_data_work[( int )ply_work.player_id][4], null, 0, null, 136, 16 );
        obj_work.disp_flag |= 16777728U;
        for ( int i = 1; i < 8; i++ )
        {
            ply_work.obj_3d_work[i].motion = ply_work.obj_3d_work[0].motion;
        }
        AppMain.GmPlayerSetModel( ply_work, 0 );
    }

    // Token: 0x06000AAE RID: 2734 RVA: 0x0005E870 File Offset: 0x0005CA70
    private static void GmPlayerSetModel( AppMain.GMS_PLAYER_WORK ply_work, int model_set )
    {
        ply_work.obj_3d[0] = ply_work.obj_3d_work[model_set * 4];
        ply_work.obj_3d[1] = ply_work.obj_3d_work[model_set * 4 + 1];
        ply_work.obj_3d[2] = ply_work.obj_3d_work[model_set * 4 + 2];
        ply_work.obj_3d[3] = ply_work.obj_3d_work[model_set * 4 + 3];
        int num = ply_work.act_state;
        if ( num == -1 )
        {
            num = 0;
        }
        ply_work.obj_work.obj_3d = ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][num]];
    }

    // Token: 0x06000AAF RID: 2735 RVA: 0x0005E8F8 File Offset: 0x0005CAF8
    private static void GmPlayerStateInit( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.seq_init_tbl = AppMain.g_gm_ply_seq_init_tbl_list[( int )ply_work.char_id];
        AppMain.GmPlayerSpdParameterSet( ply_work );
        ply_work.obj_work.dir.x = 0;
        ply_work.obj_work.dir.y = 0;
        ply_work.obj_work.dir.z = 0;
        ply_work.obj_work.spd_m = 0;
        ply_work.obj_work.spd.x = 0;
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd.z = 0;
        if ( ( ply_work.gmk_flag & 256U ) == 0U )
        {
            ply_work.obj_work.pos.z = 0;
        }
        ply_work.obj_work.ride_obj = null;
        if ( ( ply_work.gmk_flag & 1536U ) == 0U )
        {
            ply_work.gmk_obj = null;
            ply_work.gmk_camera_ofst_x = 0;
            ply_work.gmk_camera_ofst_y = 0;
            ply_work.gmk_camera_gmk_center_ofst_x = 0;
            ply_work.gmk_camera_gmk_center_ofst_y = 0;
            ply_work.gmk_flag &= 4227858183U;
        }
        ply_work.gmk_work0 = 0;
        ply_work.gmk_work1 = 0;
        ply_work.gmk_work2 = 0;
        ply_work.gmk_work3 = 0;
        ply_work.spd_work_max = 0;
        ply_work.camera_jump_pos_y = 0;
        if ( ( ply_work.graind_id & 128 ) != 0 )
        {
            ply_work.obj_work.flag |= 1U;
        }
        ply_work.gmk_flag &= 3720345596U;
        ply_work.player_flag &= 4294367568U;
        ply_work.obj_work.flag &= 4294967293U;
        ply_work.obj_work.flag |= 16U;
        ply_work.obj_work.disp_flag &= 4294966991U;
        ply_work.obj_work.move_flag &= 3623816416U;
        ply_work.obj_work.move_flag |= 1076756672U;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.move_flag &= 4294705151U;
        }
        else if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            ply_work.obj_work.move_flag &= 4294705151U;
            ply_work.obj_work.move_flag |= 536875008U;
        }
        ply_work.no_jump_move_timer = 0;
        if ( ply_work.obj_work.obj_3d != null )
        {
            ply_work.obj_work.obj_3d.blend_spd = 0.25f;
        }
    }

    // Token: 0x06000AB0 RID: 2736 RVA: 0x0005EB60 File Offset: 0x0005CD60
    private static void GmPlayerStateGimmickInit( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.gmk_obj = null;
        ply_work.gmk_camera_ofst_x = 0;
        ply_work.gmk_camera_ofst_y = 0;
        ply_work.gmk_camera_gmk_center_ofst_x = 0;
        ply_work.gmk_camera_gmk_center_ofst_y = 0;
        ply_work.gmk_work0 = 0;
        ply_work.gmk_work1 = 0;
        ply_work.gmk_work2 = 0;
        ply_work.gmk_work3 = 0;
        ply_work.obj_work.dir.x = 0;
        ply_work.obj_work.dir.y = 0;
        ply_work.score_combo_cnt = 0U;
        AppMain.GmPlayerCameraOffsetSet( ply_work, 0, 0 );
        AppMain.GmCameraAllowReset();
        if ( ( ply_work.graind_id & 128 ) != 0 )
        {
            ply_work.obj_work.flag |= 1U;
            ply_work.graind_id = 0;
        }
        ply_work.player_flag &= 4294434128U;
        ply_work.gmk_flag &= 4227612431U;
        ply_work.gmk_flag2 &= 4294967097U;
        ply_work.obj_work.disp_flag &= 4294967007U;
        ply_work.obj_work.move_flag &= 3623816447U;
        ply_work.obj_work.move_flag |= 1076232384U;
        ply_work.no_jump_move_timer = 0;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.move_flag &= 4294705151U;
            return;
        }
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            ply_work.obj_work.move_flag &= 4294705151U;
            ply_work.obj_work.move_flag |= 536875008U;
        }
    }

    // Token: 0x06000AB1 RID: 2737 RVA: 0x0005ECE8 File Offset: 0x0005CEE8
    private static void GmPlayerSpdParameterSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.spd_add = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_add;
        ply_work.spd_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_max;
        ply_work.spd1 = ( int )( ( double )ply_work.spd_max * 0.15 );
        ply_work.spd2 = ( int )( ( double )ply_work.spd_max * 0.3 );
        ply_work.spd3 = ( int )( ( double )ply_work.spd_max * 0.5 );
        ply_work.spd4 = ( int )( ( double )ply_work.spd_max * 0.7 );
        ply_work.spd5 = ( int )( ( double )ply_work.spd_max * 0.9 );
        ply_work.spd_dec = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_dec;
        ply_work.spd_spin = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_spin;
        ply_work.spd_add_spin = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_add_spin;
        ply_work.spd_max_spin = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_max_spin;
        ply_work.spd_dec_spin = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_dec_spin;
        ply_work.spd_max_add_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_max_add_slope;
        ply_work.spd_jump = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_jump;
        ply_work.time_air = ( int )AppMain.g_gm_player_parameter[( int )ply_work.char_id].time_air << 12;
        ply_work.time_damage = ( int )AppMain.g_gm_player_parameter[( int )ply_work.char_id].time_damage << 12;
        ply_work.fall_timer = ( int )AppMain.g_gm_player_parameter[( int )ply_work.char_id].fall_wait_time << 12;
        ply_work.spd_jump_add = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_jump_add;
        ply_work.spd_jump_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_jump_max;
        ply_work.spd_jump_dec = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_jump_dec;
        ply_work.spd_add_spin_pinball = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_add_spin_pinball;
        ply_work.spd_max_spin_pinball = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_max_spin_pinball;
        ply_work.spd_dec_spin_pinball = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_dec_spin_pinball;
        ply_work.spd_max_add_slope_spin_pinball = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_max_add_slope_spin_pinball;
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            if ( ( ply_work.player_flag & 262144U ) != 0U )
            {
                ply_work.obj_work.dir_slope = 512;
            }
            else
            {
                ply_work.obj_work.dir_slope = 192;
            }
        }
        else
        {
            ply_work.obj_work.dir_slope = 1;
        }
        ply_work.obj_work.spd_slope = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope;
        ply_work.obj_work.spd_slope_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_slope_max;
        ply_work.obj_work.spd_fall = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall;
        ply_work.obj_work.spd_fall_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall_max;
        ply_work.obj_work.push_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].push_max;
        if ( ( ply_work.player_flag & 67108864U ) != 0U )
        {
            AppMain.GMD_PLAYER_WATERJUMP_SET( ref ply_work.spd_jump );
            AppMain.GMD_PLAYER_WATER_SET( ref ply_work.obj_work.spd_fall );
        }
        if ( ply_work.hi_speed_timer != 0 )
        {
            ply_work.spd_add <<= 1;
            if ( ply_work.spd_add > 61440 )
            {
                ply_work.spd_add = 61440;
            }
            ply_work.spd_max <<= 1;
            if ( ply_work.spd_max > 61440 )
            {
                ply_work.spd_max = 61440;
            }
            ply_work.spd_dec <<= 1;
            ply_work.spd_spin <<= 1;
            ply_work.spd_add_spin <<= 1;
            ply_work.spd_max_spin <<= 1;
            if ( ply_work.spd_max_spin > 61440 )
            {
                ply_work.spd_max_spin = 61440;
            }
            ply_work.spd_dec_spin <<= 1;
            ply_work.spd_max_add_slope <<= 1;
            ply_work.spd_jump_add <<= 1;
            ply_work.spd_jump_max <<= 1;
            if ( ply_work.spd_jump_max > 61440 )
            {
                ply_work.spd_jump_max = 61440;
            }
            ply_work.spd_jump_dec <<= 1;
        }
    }

    // Token: 0x06000AB2 RID: 2738 RVA: 0x0005F18C File Offset: 0x0005D38C
    private static void GmPlayerSpdParameterSetWater( AppMain.GMS_PLAYER_WORK ply_work, bool water )
    {
        ply_work.spd_jump = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_jump;
        ply_work.obj_work.spd_fall = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall;
        if ( water )
        {
            AppMain.GMD_PLAYER_WATERJUMP_SET( ref ply_work.spd_jump );
            AppMain.GMD_PLAYER_WATER_SET( ref ply_work.obj_work.spd_fall );
        }
    }

    // Token: 0x06000AB3 RID: 2739 RVA: 0x0005F1F2 File Offset: 0x0005D3F2
    private static void GmPlayerSetAtk( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.rect_work[1].flag |= 4U;
        AppMain.ObjRectHitAgain( ply_work.rect_work[1] );
    }

    // Token: 0x06000AB4 RID: 2740 RVA: 0x0005F216 File Offset: 0x0005D416
    private static void GmPlayerSetDefInvincible( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.rect_work[0].def_power = 3;
    }

    // Token: 0x06000AB5 RID: 2741 RVA: 0x0005F226 File Offset: 0x0005D426
    private static void GmPlayerSetDefNormal( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.rect_work[0].def_power = 0;
    }

    // Token: 0x06000AB6 RID: 2742 RVA: 0x0005F236 File Offset: 0x0005D436
    private static void GmPlayerBreathingSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.water_timer = 0;
    }

    // Token: 0x06000AB7 RID: 2743 RVA: 0x0005F23F File Offset: 0x0005D43F
    private static void GmPlayerSetMarkerPoint( AppMain.GMS_PLAYER_WORK ply_work, int pos_x, int pos_y )
    {
        AppMain.g_gm_main_system.time_save = AppMain.g_gm_main_system.game_time;
        AppMain.g_gm_main_system.resume_pos_x = pos_x;
        AppMain.g_gm_main_system.resume_pos_y = pos_y - ( ( int )ply_work.obj_work.field_rect[3] << 12 );
    }

    // Token: 0x06000AB8 RID: 2744 RVA: 0x0005F27C File Offset: 0x0005D47C
    private static void GmPlayerSetSuperSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerStateInit( ply_work );
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.obj_work.pos.z = -32768;
            ply_work.gmk_flag |= 536870912U;
        }
        if ( ( ply_work.player_flag & 131072U ) != 0U )
        {
            ply_work.char_id = 4;
        }
        else if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.char_id = 6;
        }
        else
        {
            ply_work.char_id = 1;
        }
        ply_work.player_flag |= 16384U;
        AppMain.GmPlayerSetModel( ply_work, 1 );
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
        ply_work.obj_work.move_flag |= 16U;
        ply_work.obj_work.move_flag &= 4294967152U;
        ply_work.obj_work.flag |= 2U;
        AppMain.GmPlyEfctCreateSuperAuraDeco( ply_work );
        AppMain.GmPlyEfctCreateSuperAuraBase( ply_work );
        ply_work.super_sonic_ring_timer = int.MaxValue;
        ply_work.light_rate = 0f;
        ply_work.light_anm_flag = 0;
        AppMain.g_gm_main_system.game_flag |= 524288U;
        AppMain.GmSoundPlaySE( "Transform" );
        if ( AppMain.g_gs_main_sys_info.stage_id != 28 )
        {
            AppMain.GmSoundPlayJingleInvincible();
        }
    }

    // Token: 0x06000AB9 RID: 2745 RVA: 0x0005F3B8 File Offset: 0x0005D5B8
    private static void GmPlayerSetEndSuperSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) != 0U )
        {
            ply_work.char_id = 3;
        }
        else if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            ply_work.char_id = 5;
        }
        else
        {
            ply_work.char_id = 0;
        }
        ply_work.player_flag &= 4294950911U;
        AppMain.GmPlayerSetModel( ply_work, 0 );
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.GmPlyEfctCreateSuperEnd( ply_work );
        AppMain.GmPlayerSetDefLight();
        AppMain.GmPlayerSetDefRimParam( ply_work );
    }

    // Token: 0x06000ABA RID: 2746 RVA: 0x0005F430 File Offset: 0x0005D630
    private static void GmPlayerSetDefLight()
    {
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_6, ref AppMain.g_gm_main_system.ply_light_col, 1f, AppMain.g_gm_main_system.ply_light_vec );
    }

    // Token: 0x06000ABB RID: 2747 RVA: 0x0005F458 File Offset: 0x0005D658
    private static void GmPlayerSetSplStgSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.obj_work.move_flag |= 139520U;
        ply_work.obj_work.move_flag &= 4294705151U;
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.GmPlayerActionChange( ply_work, 39 );
        ply_work.obj_work.disp_flag |= 4U;
    }

    // Token: 0x06000ABC RID: 2748 RVA: 0x0005F4BC File Offset: 0x0005D6BC
    private static void GmPlayerSetPinballSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            ply_work.char_id = 4;
        }
        else
        {
            ply_work.char_id = 3;
        }
        ply_work.player_flag |= 131072U;
        ply_work.obj_work.move_flag &= 4294705151U;
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.GmPlayerActionChange( ply_work, 39 );
        ply_work.obj_work.disp_flag |= 4U;
    }

    // Token: 0x06000ABD RID: 2749 RVA: 0x0005F538 File Offset: 0x0005D738
    private static void GmPlayerSetEndPinballSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            ply_work.char_id = 1;
        }
        else
        {
            ply_work.char_id = 0;
        }
        ply_work.player_flag &= 4294836223U;
        ply_work.obj_work.move_flag |= 262144U;
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
    }

    // Token: 0x06000ABE RID: 2750 RVA: 0x0005F598 File Offset: 0x0005D798
    private static void GmPlayerSetTruckRide( AppMain.GMS_PLAYER_WORK ply_work, AppMain.OBS_OBJECT_WORK truck_obj, short field_left, short field_top, short field_right, short field_bottom )
    {
        bool flag = false;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ply_work;
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            ply_work.char_id = 6;
        }
        else
        {
            ply_work.char_id = 5;
        }
        ply_work.player_flag |= 262144U;
        ply_work.obj_work.move_flag &= 4294705151U;
        ply_work.gmk_flag2 &= 4294967294U;
        ply_work.truck_obj = truck_obj;
        ply_work.obj_work.ppRec = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerRectTruckFunc );
        ply_work.obj_work.ppCol = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmPlayerTruckCollisionFunc );
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(ply_work.obj_3d_work);
        int i = 0;
        while ( i < 8 )
        {
            ( ~pointer ).mtn_cb_func = new AppMain.mtn_cb_func_delegate( AppMain.gmGmkPlayerMotionCallbackTruck );
            ( ~pointer ).mtn_cb_param = ply_work;
            i++;
            pointer = ++pointer;
        }
        AppMain.nnMakeUnitMatrix( ply_work.truck_mtx_ply_mtn_pos );
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, field_left, field_top, field_right, field_bottom );
        obs_OBJECT_WORK.field_ajst_w_db_f = 3;
        obs_OBJECT_WORK.field_ajst_w_db_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dl_f = 3;
        obs_OBJECT_WORK.field_ajst_w_dl_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dt_f = 3;
        obs_OBJECT_WORK.field_ajst_w_dt_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dr_f = 3;
        obs_OBJECT_WORK.field_ajst_w_dr_b = 4;
        obs_OBJECT_WORK.field_ajst_h_db_r = 3;
        obs_OBJECT_WORK.field_ajst_h_db_l = 3;
        obs_OBJECT_WORK.field_ajst_h_dl_r = 3;
        obs_OBJECT_WORK.field_ajst_h_dl_l = 3;
        obs_OBJECT_WORK.field_ajst_h_dt_r = 3;
        obs_OBJECT_WORK.field_ajst_h_dt_l = 3;
        obs_OBJECT_WORK.field_ajst_h_dr_r = 3;
        obs_OBJECT_WORK.field_ajst_h_dr_l = 3;
        AppMain.ObjRectWorkSet( ply_work.rect_work[2], -8, ( short )( -32 + field_bottom ), 8, field_bottom );
        AppMain.ObjRectWorkSet( ply_work.rect_work[0], -8, ( short )( -48 + field_bottom ), 8, ( short )( -16 + field_bottom ) );
        AppMain.ObjRectWorkSet( ply_work.rect_work[1], -16, ( short )( -48 + field_bottom ), 16, ( short )( -16 + field_bottom ) );
        ply_work.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        obs_CAMERA.user_func = new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.GmCameraTruckFunc );
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            AppMain.GmPlayerSetReverse( ply_work );
        }
        if ( ply_work.seq_state == 39 )
        {
            flag = true;
        }
        AppMain.GmPlySeqChangeFw( ply_work );
        if ( flag )
        {
            AppMain.GmPlySeqInitDemoFw( ply_work );
        }
    }

    // Token: 0x06000ABF RID: 2751 RVA: 0x0005F7D0 File Offset: 0x0005D9D0
    private static void GmPlayerSetEndTruckRide( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ply_work;
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            ply_work.char_id = 1;
        }
        else
        {
            ply_work.char_id = 0;
        }
        ply_work.player_flag &= 4294705151U;
        ply_work.obj_work.move_flag |= 262144U;
        ply_work.obj_work.ppRec = null;
        ply_work.obj_work.ppCol = null;
        AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_NN_WORK>(ply_work.obj_3d_work);
        int i = 0;
        while ( i < 8 )
        {
            ( ~pointer ).mtn_cb_func = null;
            ( ~pointer ).mtn_cb_param = null;
            i++;
            pointer = ++pointer;
        }
        AppMain.GmPlySeqSetSeqState( ply_work );
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.ObjObjectFieldRectSet( ply_work.obj_work, -6, -12, 6, 13 );
        obs_OBJECT_WORK.field_ajst_w_db_f = 2;
        obs_OBJECT_WORK.field_ajst_w_db_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dl_f = 2;
        obs_OBJECT_WORK.field_ajst_w_dl_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dt_f = 2;
        obs_OBJECT_WORK.field_ajst_w_dt_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dr_f = 2;
        obs_OBJECT_WORK.field_ajst_w_dr_b = 4;
        obs_OBJECT_WORK.field_ajst_h_db_r = 1;
        obs_OBJECT_WORK.field_ajst_h_db_l = 1;
        obs_OBJECT_WORK.field_ajst_h_dl_r = 1;
        obs_OBJECT_WORK.field_ajst_h_dl_l = 1;
        obs_OBJECT_WORK.field_ajst_h_dt_r = 1;
        obs_OBJECT_WORK.field_ajst_h_dt_l = 1;
        obs_OBJECT_WORK.field_ajst_h_dr_r = 2;
        obs_OBJECT_WORK.field_ajst_h_dr_l = 2;
        AppMain.ObjRectWorkZSet( ply_work.rect_work[2], -8, -19, -500, 8, 13, 500 );
        AppMain.ObjRectWorkZSet( ply_work.rect_work[0], -8, -19, -500, 8, 13, 500 );
        AppMain.ObjRectWorkZSet( ply_work.rect_work[1], -16, -19, -500, 16, 13, 500 );
        ply_work.rect_work[1].flag &= 4294967291U;
        ply_work.obj_work.dir_fall = 0;
        AppMain.g_gm_main_system.pseudofall_dir = 0;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        obs_CAMERA.user_func = new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.GmCameraFunc );
    }

    // Token: 0x06000AC0 RID: 2752 RVA: 0x0005F9B8 File Offset: 0x0005DBB8
    private static void GmPlayerSetGoalState( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 131072U ) != 0U )
        {
            AppMain.GmPlayerSetEndPinballSonic( ply_work );
        }
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            AppMain.gmPlayerSuperSonicToSonic( ply_work );
        }
        AppMain.GmPlayerSetDefInvincible( ply_work );
        ply_work.invincible_timer = 0;
        ply_work.genocide_timer = 0;
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            AppMain.ObjRectWorkSet( ply_work.rect_work[2], 0, -37, 16, -5 );
        }
    }

    // Token: 0x06000AC1 RID: 2753 RVA: 0x0005FA24 File Offset: 0x0005DC24
    private static void GmPlayerSetAutoRun( AppMain.GMS_PLAYER_WORK ply_work, int scroll_spd_x, bool enable )
    {
        if ( enable )
        {
            ply_work.player_flag |= 32768U;
            ply_work.scroll_spd_x = scroll_spd_x;
            return;
        }
        ply_work.player_flag &= 4294934527U;
    }

    // Token: 0x06000AC2 RID: 2754 RVA: 0x0005FA58 File Offset: 0x0005DC58
    private static void GmPlayerRingGet( AppMain.GMS_PLAYER_WORK ply_work, short add_ring )
    {
        short ring_num = ply_work.ring_num;
        ply_work.ring_num += add_ring;
        ply_work.ring_num = ( short )AppMain.MTM_MATH_CLIP( ( int )ply_work.ring_num, 0, 999 );
        ply_work.ring_stage_num += add_ring;
        ply_work.ring_stage_num = ( short )AppMain.MTM_MATH_CLIP( ( int )ply_work.ring_stage_num, 0, 9999 );
        AppMain.GmRingGetSE();
        if ( AppMain.g_gs_main_sys_info.game_mode == 1 )
        {
            return;
        }
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            if ( ( ply_work.player_flag & 16384U ) == 0U && AppMain.g_gs_main_sys_info.game_mode != 1 )
            {
                for ( short num = 100; num <= 900; num += 100 )
                {
                    if ( ring_num < num && ply_work.ring_num >= num )
                    {
                        AppMain.GmPlayerStockGet( ply_work, 1 );
                        AppMain.GmSoundPlayJingle1UP( true );
                    }
                }
                return;
            }
        }
        else if ( ring_num < 50 && ply_work.ring_num >= 50 )
        {
            AppMain.GmPlayerStockGet( ply_work, 1 );
            AppMain.GmSoundPlayJingle1UP( true );
        }
    }

    // Token: 0x06000AC3 RID: 2755 RVA: 0x0005FB3C File Offset: 0x0005DD3C
    private static void GmPlayerRingDec( AppMain.GMS_PLAYER_WORK ply_work, short dec_ring )
    {
        if ( AppMain.GMM_MAIN_USE_SUPER_SONIC() )
        {
            return;
        }
        ply_work.ring_num -= dec_ring;
        ply_work.ring_num = ( short )AppMain.MTM_MATH_CLIP( ( int )ply_work.ring_num, 0, 999 );
        ply_work.ring_stage_num -= dec_ring;
        ply_work.ring_stage_num = ( short )AppMain.MTM_MATH_CLIP( ( int )ply_work.ring_stage_num, 0, 9999 );
    }

    // Token: 0x06000AC4 RID: 2756 RVA: 0x0005FBA0 File Offset: 0x0005DDA0
    private static void GmPlayerStockGet( AppMain.GMS_PLAYER_WORK ply_work, short add_stock )
    {
        if ( AppMain.g_gs_main_sys_info.game_mode == 1 && ( 21 > AppMain.g_gs_main_sys_info.stage_id || AppMain.g_gs_main_sys_info.stage_id > 27 ) )
        {
            return;
        }
        AppMain.g_gm_main_system.player_rest_num[( int )ply_work.player_id] += ( uint )add_stock;
        AppMain.g_gm_main_system.player_rest_num[( int )ply_work.player_id] = AppMain.MTM_MATH_CLIP( AppMain.g_gm_main_system.player_rest_num[( int )ply_work.player_id], 0U, 1000U );
        AppMain.HgTrophyTryAcquisition( 5 );
    }

    // Token: 0x06000AC5 RID: 2757 RVA: 0x0005FC2C File Offset: 0x0005DE2C
    private static void GmPlayerAddScore( AppMain.GMS_PLAYER_WORK ply_work, int score, int pos_x, int pos_y )
    {
        ply_work.score += ( uint )score;
        AppMain.GmScoreCreateScore( score, pos_x, pos_y, 4096, 0 );
    }

    // Token: 0x06000AC6 RID: 2758 RVA: 0x0005FC4A File Offset: 0x0005DE4A
    private static void GmPlayerAddScoreNoDisp( AppMain.GMS_PLAYER_WORK ply_work, int score )
    {
        ply_work.score += ( uint )score;
    }

    // Token: 0x06000AC7 RID: 2759 RVA: 0x0005FC5C File Offset: 0x0005DE5C
    private static void GmPlayerComboScore( AppMain.GMS_PLAYER_WORK ply_work, int pos_x, int pos_y )
    {
        if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
        {
            ply_work.score_combo_cnt = 0U;
        }
        else
        {
            ply_work.score_combo_cnt += 1U;
            if ( ply_work.score_combo_cnt > 9999U )
            {
                ply_work.score_combo_cnt = 9999U;
            }
        }
        uint num;
        if ( ply_work.score_combo_cnt == 0U )
        {
            num = 0U;
        }
        else if ( ply_work.score_combo_cnt - 1U >= 5U )
        {
            num = 4U;
        }
        else
        {
            num = ply_work.score_combo_cnt - 1U;
        }
        int num2 = AppMain.gm_ply_score_combo_tbl[(int)((UIntPtr)num)];
        ply_work.score += ( uint )num2;
        AppMain.GmScoreCreateScore( num2, pos_x, pos_y, AppMain.gm_ply_score_combo_scale_tbl[( int )( ( UIntPtr )num )], AppMain.gm_ply_score_combo_vib_level_tbl[( int )( ( UIntPtr )num )] );
    }

    // Token: 0x06000AC8 RID: 2760 RVA: 0x0005FCFA File Offset: 0x0005DEFA
    private static void GmPlayerItemHiSpeedSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.hi_speed_timer = 3686400;
        AppMain.GmPlayerSpdParameterSet( ply_work );
        AppMain.GmSoundChangeSpeedupBGM();
    }

    // Token: 0x06000AC9 RID: 2761 RVA: 0x0005FD12 File Offset: 0x0005DF12
    private static void GmPlayerItemInvincibleSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmSoundPlayJingleInvincible();
        if ( ply_work.genocide_timer == 0 )
        {
            AppMain.GmPlyEfctCreateInvincible( ply_work );
        }
        ply_work.genocide_timer = 4091904;
    }

    // Token: 0x06000ACA RID: 2762 RVA: 0x0005FD32 File Offset: 0x0005DF32
    private static void GmPlayerItemRing10Set( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerRingGet( ply_work, 10 );
    }

    // Token: 0x06000ACB RID: 2763 RVA: 0x0005FD3C File Offset: 0x0005DF3C
    private static void GmPlayerItemBarrierSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 268435456U ) == 0U )
        {
            AppMain.GmPlyEfctCreateBarrier( ply_work );
            AppMain.GmSoundPlaySE( "Barrier" );
        }
        ply_work.player_flag |= 268435456U;
    }

    // Token: 0x06000ACC RID: 2764 RVA: 0x0005FD6E File Offset: 0x0005DF6E
    private static void GmPlayerItem1UPSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GmPlayerStockGet( ply_work, 1 );
        AppMain.GmSoundPlayJingle1UP( true );
    }

    // Token: 0x06000ACD RID: 2765 RVA: 0x0005FD80 File Offset: 0x0005DF80
    private static void GmPlayerActionChange( AppMain.GMS_PLAYER_WORK ply_work, int act_state )
    {
        ply_work.prev_act_state = ply_work.act_state;
        ply_work.act_state = act_state;
        ply_work.obj_work.obj_3d = ply_work.obj_3d[( int )AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][act_state]];
        ply_work.obj_work.obj_3d.motion._object = ply_work.obj_work.obj_3d._object;
        int id;
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            id = ( int )AppMain.g_gm_player_motion_left_tbl[( int )ply_work.char_id][act_state];
        }
        else
        {
            id = ( int )AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][act_state];
        }
        if ( ply_work.prev_act_state == -1 || AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][act_state] != AppMain.g_gm_player_model_tbl[( int )ply_work.char_id][ply_work.prev_act_state] || AppMain.g_gm_player_mtn_blend_setting_tbl[( int )ply_work.char_id][ply_work.prev_act_state] == 0 || AppMain.g_gm_player_mtn_blend_setting_tbl[( int )ply_work.char_id][act_state] == 0 )
        {
            AppMain.ObjDrawObjectActionSet3DNN( ply_work.obj_work, id, 0 );
            return;
        }
        AppMain.ObjDrawObjectActionSet3DNNBlend( ply_work.obj_work, id );
        if ( act_state == 26 || act_state == 27 )
        {
            ply_work.obj_work.obj_3d.blend_spd = 0.125f;
            return;
        }
        if ( 19 <= ply_work.prev_act_state && ply_work.prev_act_state < 22 && ( act_state == 40 || act_state == 42 ) )
        {
            ply_work.obj_work.obj_3d.blend_spd = 0.125f;
            return;
        }
        if ( ply_work.prev_act_state == 0 && act_state == 19 )
        {
            ply_work.obj_work.obj_3d.blend_spd = 0.125f;
            return;
        }
        if ( ply_work.prev_seq_state == 20 )
        {
            ply_work.obj_work.obj_3d.blend_spd = 0.083333336f;
            return;
        }
        ply_work.obj_work.obj_3d.blend_spd = 0.25f;
    }

    // Token: 0x06000ACE RID: 2766 RVA: 0x0005FF38 File Offset: 0x0005E138
    private static void GmPlayerSaveResetAction( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_PLAYER_RESET_ACT_WORK reset_act_work )
    {
        reset_act_work.frame[0] = ply_work.obj_work.obj_3d.frame[0];
        reset_act_work.frame[1] = ply_work.obj_work.obj_3d.frame[1];
        reset_act_work.blend_spd = ply_work.obj_work.obj_3d.blend_spd;
        reset_act_work.marge = ply_work.obj_work.obj_3d.marge;
        reset_act_work.obj_3d_flag = ply_work.obj_work.obj_3d.flag;
    }

    // Token: 0x06000ACF RID: 2767 RVA: 0x0005FFBC File Offset: 0x0005E1BC
    private static void GmPlayerResetAction( AppMain.GMS_PLAYER_WORK ply_work, AppMain.GMS_PLAYER_RESET_ACT_WORK reset_act_work )
    {
        int[] array = AppMain.New<int>(2);
        float[] array2 = new float[2];
        array[0] = ply_work.act_state;
        array[1] = ply_work.prev_act_state;
        uint disp_flag = ply_work.obj_work.disp_flag;
        AppMain.GmPlayerActionChange( ply_work, array[1] );
        AppMain.GmPlayerActionChange( ply_work, array[0] );
        ply_work.obj_work.obj_3d.frame[0] = reset_act_work.frame[0];
        ply_work.obj_work.obj_3d.frame[1] = reset_act_work.frame[1];
        ply_work.obj_work.obj_3d.blend_spd = reset_act_work.blend_spd;
        ply_work.obj_work.obj_3d.marge = reset_act_work.marge;
        ply_work.obj_work.obj_3d.flag &= 4294967294U;
        ply_work.obj_work.obj_3d.flag |= ( reset_act_work.obj_3d_flag & 1U );
        ply_work.obj_work.disp_flag |= ( disp_flag & 12U );
        for ( int i = 0; i < 2; i++ )
        {
            array2[i] = AppMain.amMotionGetEndFrame( ply_work.obj_work.obj_3d.motion, ply_work.obj_work.obj_3d.act_id[i] ) - AppMain.amMotionGetStartFrame( ply_work.obj_work.obj_3d.motion, ply_work.obj_work.obj_3d.act_id[i] );
            if ( ply_work.obj_work.obj_3d.frame[i] >= array2[i] )
            {
                ply_work.obj_work.obj_3d.frame[i] = 0f;
            }
        }
    }

    // Token: 0x06000AD0 RID: 2768 RVA: 0x00060148 File Offset: 0x0005E348
    private static void GmPlayerWalkActionSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = AppMain.MTM_MATH_ABS(ply_work.obj_work.spd_m);
        bool flag = false;
        short num2 = (short)ply_work.obj_work.dir.z;
        if ( ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && num2 > 4096 ) || ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && num2 < -4096 && ( ply_work.gmk_flag & 131072U ) == 0U ) )
        {
            flag = true;
            ply_work.maxdash_timer = 122880;
        }
        int act_state;
        if ( num < ply_work.spd1 )
        {
            act_state = 19;
        }
        else if ( num < ply_work.spd2 )
        {
            act_state = 20;
            if ( ( ply_work.player_flag & 512U ) == 0U )
            {
                AppMain.GmPlyEfctCreateRunDust( ply_work );
            }
        }
        else if ( num < ply_work.spd3 )
        {
            act_state = 21;
            if ( ( ply_work.player_flag & 512U ) == 0U )
            {
                AppMain.GmPlyEfctCreateDash1Dust( ply_work );
            }
        }
        else if ( num < ply_work.spd4 && ( flag || ply_work.maxdash_timer != 0 ) )
        {
            act_state = 22;
            AppMain.GmPlyEfctCreateRollDash( ply_work );
            if ( ( ply_work.player_flag & 512U ) == 0U )
            {
                AppMain.GmPlyEfctCreateDash2Dust( ply_work );
            }
            AppMain.GmPlyEfctCreateDash2Impact( ply_work );
            AppMain.GmPlyEfctCreateSuperAuraDash( ply_work );
        }
        else
        {
            act_state = 21;
            if ( ( ply_work.player_flag & 512U ) == 0U )
            {
                AppMain.GmPlyEfctCreateDash1Dust( ply_work );
            }
        }
        AppMain.GmPlayerActionChange( ply_work, act_state );
        ply_work.obj_work.disp_flag |= 4U;
    }

    // Token: 0x06000AD1 RID: 2769 RVA: 0x00060290 File Offset: 0x0005E490
    private static void GmPlayerWalkActionCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        bool flag = false;
        short num = (short)ply_work.obj_work.dir.z;
        int num2 = AppMain.MTM_MATH_ABS(ply_work.obj_work.spd_m);
        if ( ( ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && num > 4096 ) || ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && num < -4096 ) ) && ( ply_work.gmk_flag & 131072U ) == 0U )
        {
            flag = true;
            ply_work.maxdash_timer = 122880;
        }
        if ( ply_work.act_state < 19 || ply_work.act_state > 22 )
        {
            AppMain.GmPlayerActionChange( ply_work, 19 );
        }
        if ( ( ply_work.obj_work.disp_flag & 8U ) != 0U )
        {
            if ( ply_work.act_state == 19 )
            {
                if ( num2 >= ply_work.spd2 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 20 );
                    if ( ( ply_work.player_flag & 512U ) == 0U )
                    {
                        AppMain.GmPlyEfctCreateRunDust( ply_work );
                    }
                }
            }
            else if ( ply_work.act_state == 20 )
            {
                if ( num2 >= ply_work.spd3 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 21 );
                    if ( ( ply_work.player_flag & 512U ) == 0U )
                    {
                        AppMain.GmPlyEfctCreateDash1Dust( ply_work );
                    }
                }
                else if ( num2 < ply_work.spd2 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 19 );
                }
            }
            else if ( ply_work.act_state == 21 )
            {
                if ( num2 >= ply_work.spd_max && ( flag || ply_work.maxdash_timer != 0 ) )
                {
                    AppMain.GmPlayerActionChange( ply_work, 22 );
                    AppMain.GmPlyEfctCreateRollDash( ply_work );
                    if ( ( ply_work.player_flag & 512U ) == 0U )
                    {
                        AppMain.GmPlyEfctCreateDash2Dust( ply_work );
                    }
                    AppMain.GmPlyEfctCreateDash2Impact( ply_work );
                }
                else if ( num2 < ply_work.spd3 )
                {
                    AppMain.GmPlayerActionChange( ply_work, 20 );
                    if ( ( ply_work.player_flag & 512U ) == 0U )
                    {
                        AppMain.GmPlyEfctCreateRunDust( ply_work );
                    }
                }
            }
            else if ( ply_work.act_state == 22 && ( num2 < ply_work.spd_max || ( !flag && ply_work.maxdash_timer == 0 ) ) )
            {
                AppMain.GmPlayerActionChange( ply_work, 21 );
                if ( ( ply_work.player_flag & 512U ) == 0U )
                {
                    AppMain.GmPlyEfctCreateDash1Dust( ply_work );
                }
            }
        }
        ply_work.obj_work.disp_flag |= 4U;
    }

    // Token: 0x06000AD2 RID: 2770 RVA: 0x00060480 File Offset: 0x0005E680
    private static void GmPlayerAnimeSpeedSetWalk( AppMain.GMS_PLAYER_WORK ply_work, int spd_set )
    {
        int num = AppMain.MTM_MATH_ABS((spd_set >> 3) + (spd_set >> 2));
        if ( num <= 4096 )
        {
            num = 4096;
        }
        if ( num >= 32768 )
        {
            num = 32768;
        }
        if ( ply_work.act_state == 22 )
        {
            num = 4096;
        }
        else if ( ( ply_work.act_state == 26 || ply_work.act_state == 27 ) && ( ply_work.obj_work.obj_3d.flag & 1U ) != 0U && num > 4096 )
        {
            num = 4096;
        }
        if ( ply_work.obj_work.obj_3d != null )
        {
            ply_work.obj_work.obj_3d.speed[0] = AppMain.FXM_FX32_TO_FLOAT( num );
            ply_work.obj_work.obj_3d.speed[1] = AppMain.FXM_FX32_TO_FLOAT( num );
        }
    }

    // Token: 0x06000AD3 RID: 2771 RVA: 0x0006053C File Offset: 0x0005E73C
    private static void GmPlayerSpdSet( AppMain.GMS_PLAYER_WORK ply_work, int spd_x, int spd_y )
    {
        ply_work.no_spddown_timer = 524288;
        if ( spd_x < 0 )
        {
            ply_work.obj_work.disp_flag |= 1U;
        }
        else
        {
            ply_work.obj_work.disp_flag &= 4294967294U;
        }
        if ( ( ply_work.obj_work.move_flag & 16U ) != 0U )
        {
            if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd.x > spd_x ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd.x < spd_x ) )
            {
                ply_work.obj_work.spd.x = spd_x;
            }
            if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) < AppMain.MTM_MATH_ABS( spd_y ) )
            {
                ply_work.obj_work.spd.y = spd_y;
                return;
            }
        }
        else
        {
            switch ( ( ply_work.obj_work.dir.z + 8192 & 49152 ) >> 6 )
            {
                case 0:
                case 2:
                    if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd_m > spd_x ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd_m < spd_x ) )
                    {
                        ply_work.obj_work.spd_m = spd_x;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.y ) < AppMain.MTM_MATH_ABS( spd_y ) )
                    {
                        ply_work.obj_work.spd.y = spd_y;
                        if ( ply_work.obj_work.spd.y < 0 )
                        {
                            ply_work.obj_work.move_flag |= 16U;
                            return;
                        }
                    }
                    break;
                case 1:
                    if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd_m > spd_y ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd_m < spd_y ) )
                    {
                        ply_work.obj_work.spd_m = spd_y;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < AppMain.MTM_MATH_ABS( spd_x ) )
                    {
                        ply_work.obj_work.spd.x = spd_x;
                        return;
                    }
                    break;
                case 3:
                    if ( ( ( ply_work.obj_work.disp_flag & 1U ) != 0U && ply_work.obj_work.spd_m > -spd_y ) || ( ( ply_work.obj_work.disp_flag & 1U ) == 0U && ply_work.obj_work.spd_m < -spd_y ) )
                    {
                        ply_work.obj_work.spd_m = -spd_y;
                    }
                    if ( AppMain.MTM_MATH_ABS( ply_work.obj_work.spd.x ) < AppMain.MTM_MATH_ABS( spd_x ) )
                    {
                        ply_work.obj_work.spd.x = spd_x;
                    }
                    break;
                default:
                    return;
            }
        }
    }

    // Token: 0x06000AD4 RID: 2772 RVA: 0x000607E4 File Offset: 0x0005E9E4
    private static void GmPlayerSetReverse( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.player_flag &= 2147483375U;
        ply_work.pgm_turn_dir = 0;
        ply_work.pgm_turn_spd = 0;
        ply_work.obj_work.disp_flag ^= 1U;
        if ( AppMain.g_gm_player_motion_left_tbl[( int )ply_work.char_id][ply_work.act_state] != AppMain.g_gm_player_motion_right_tbl[( int )ply_work.char_id][ply_work.act_state] )
        {
            float[] array = new float[2];
            uint num = ply_work.obj_work.disp_flag & 12U;
            array[0] = ply_work.obj_work.obj_3d.frame[0];
            AppMain.GmPlayerActionChange( ply_work, ply_work.act_state );
            ply_work.obj_work.obj_3d.frame[0] = array[0];
            ply_work.obj_work.obj_3d.marge = 0f;
            ply_work.obj_work.obj_3d.flag &= 4294967294U;
            ply_work.obj_work.disp_flag |= num;
        }
    }

    // Token: 0x06000AD5 RID: 2773 RVA: 0x000608DC File Offset: 0x0005EADC
    private static void GmPlayerSetReverseOnlyState( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.player_flag &= 2147483375U;
        ply_work.pgm_turn_dir = 0;
        ply_work.pgm_turn_spd = 0;
        ply_work.obj_work.disp_flag ^= 1U;
    }

    // Token: 0x06000AD6 RID: 2774 RVA: 0x00060914 File Offset: 0x0005EB14
    private static bool GmPlayerKeyCheckWalkLeft( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            if ( ( ply_work.key_on & 4 ) != 0 || ply_work.key_rot_z < 0 )
            {
                return true;
            }
        }
        else if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
        {
            if ( ( ply_work.key_on & 4 ) != 0 )
            {
                return true;
            }
        }
        else if ( ( ply_work.key_on & 4 ) != 0 || ply_work.key_walk_rot_z < 0 )
        {
            return true;
        }
        return false;
    }

    // Token: 0x06000AD7 RID: 2775 RVA: 0x00060974 File Offset: 0x0005EB74
    private static bool GmPlayerKeyCheckWalkRight( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 262144U ) != 0U )
        {
            if ( ( ply_work.key_on & 8 ) != 0 || ply_work.key_rot_z > 0 )
            {
                return true;
            }
        }
        else if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
        {
            if ( ( ply_work.key_on & 8 ) != 0 )
            {
                return true;
            }
        }
        else if ( ( ply_work.key_on & 8 ) != 0 || ply_work.key_walk_rot_z > 0 )
        {
            return true;
        }
        return false;
    }

    // Token: 0x06000AD8 RID: 2776 RVA: 0x000609D4 File Offset: 0x0005EBD4
    private static bool GmPlayerKeyCheckJumpKeyOn( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.key_on & 160 ) != 0;
    }

    // Token: 0x06000AD9 RID: 2777 RVA: 0x000609E7 File Offset: 0x0005EBE7
    private static bool GmPlayerKeyCheckJumpKeyPush( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.key_push & 160 ) != 0;
    }

    // Token: 0x06000ADA RID: 2778 RVA: 0x000609FC File Offset: 0x0005EBFC
    private static int GmPlayerKeyGetGimmickRotZ( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int result;
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
        {
            result = ply_work.key_walk_rot_z;
        }
        else
        {
            result = ply_work.key_rot_z;
        }
        return result;
    }

    // Token: 0x06000ADB RID: 2779 RVA: 0x00060A2A File Offset: 0x0005EC2A
    private static bool GmPlayerKeyCheckTransformKeyPush( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( ply_work.key_push & 80 ) != 0;
    }

    // Token: 0x06000ADC RID: 2780 RVA: 0x00060A3C File Offset: 0x0005EC3C
    private static void GmPlayerSetLight( AppMain.NNS_VECTOR light_vec, ref AppMain.NNS_RGBA light_col )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.nnNormalizeVector( nns_VECTOR, light_vec );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_6, ref light_col, 1f, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000ADD RID: 2781 RVA: 0x00060A6E File Offset: 0x0005EC6E
    private static void GmPlayerSetDefRimParam( AppMain.GMS_PLAYER_WORK ply_work )
    {
    }

    // Token: 0x06000ADE RID: 2782 RVA: 0x00060A70 File Offset: 0x0005EC70
    private void GmPlayerSetRimParam( AppMain.GMS_PLAYER_WORK ply_work, AppMain.NNS_RGB toon_rim_param )
    {
    }

    // Token: 0x06000ADF RID: 2783 RVA: 0x00060A74 File Offset: 0x0005EC74
    private static bool GmPlayerCheckGimmickEnable( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.gmk_obj != null && ply_work.gmk_obj.obj_type == 3 )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)ply_work.gmk_obj;
            if ( gms_ENEMY_COM_WORK.target_obj == ( AppMain.OBS_OBJECT_WORK )ply_work )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x06000AE0 RID: 2784 RVA: 0x00060AB4 File Offset: 0x0005ECB4
    private static bool GmPlayerIsTransformSuperSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        return ( AppMain.g_gm_main_system.game_flag & 1048576U ) == 0U && ( ply_work.player_flag & 1049600U ) == 0U && ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() && ( AppMain.g_gs_main_sys_info.game_flag & 32U ) != 0U && ply_work.ring_num >= 50 && ( ply_work.player_flag & 16384U ) == 0U );
    }

    // Token: 0x06000AE1 RID: 2785 RVA: 0x00060B14 File Offset: 0x0005ED14
    private static void GmPlayerCameraOffsetSet( AppMain.GMS_PLAYER_WORK ply_work, short ofs_x, short ofs_y )
    {
        ply_work.gmk_camera_center_ofst_x = ofs_x;
        ply_work.gmk_camera_center_ofst_y = ofs_y;
    }

    // Token: 0x06000AE2 RID: 2786 RVA: 0x00060B24 File Offset: 0x0005ED24
    private static bool GmPlayerIsStateWait( AppMain.GMS_PLAYER_WORK ply_work )
    {
        bool result = false;
        if ( ply_work.act_state >= 2 && ply_work.act_state <= 7 )
        {
            result = true;
        }
        return result;
    }

    // Token: 0x06000AE3 RID: 2787 RVA: 0x00060B48 File Offset: 0x0005ED48
    private static bool gmPlayerObjRelease( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d = null;
        return true;
    }

    // Token: 0x06000AE4 RID: 2788 RVA: 0x00060B54 File Offset: 0x0005ED54
    private static bool gmPlayerObjReleaseWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        AppMain.ObjAction3dNNMotionRelease( gms_PLAYER_WORK.obj_3d_work[0] );
        for ( int i = 1; i < 8; i++ )
        {
            gms_PLAYER_WORK.obj_3d_work[i].motion = null;
        }
        return false;
    }

    // Token: 0x06000AE5 RID: 2789 RVA: 0x00060B90 File Offset: 0x0005ED90
    private static void gmPlayerExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.g_gm_main_system.ply_work[( int )gms_PLAYER_WORK.player_id] = null;
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06000AE6 RID: 2790 RVA: 0x00060BC4 File Offset: 0x0005EDC4
    private static void gmPlayerMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        if ( gms_PLAYER_WORK.spin_se_timer > 0 )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK2 = gms_PLAYER_WORK;
            gms_PLAYER_WORK2.spin_se_timer -= 1;
        }
        if ( gms_PLAYER_WORK.spin_back_se_timer > 0 )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK3 = gms_PLAYER_WORK;
            gms_PLAYER_WORK3.spin_back_se_timer -= 1;
        }
        AppMain.GmPlySeqMain( gms_PLAYER_WORK );
    }

    // Token: 0x06000AE7 RID: 2791 RVA: 0x00060C10 File Offset: 0x0005EE10
    private static void gmPlayerDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        ushort y = 0;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx_r );
        if ( ( gms_PLAYER_WORK.gmk_flag & 32768U ) != 0U )
        {
            AppMain.nnMultiplyMatrix( obj_3d.user_obj_mtx_r, obj_3d.user_obj_mtx_r, gms_PLAYER_WORK.ex_obj_mtx_r );
        }
        float num = 0f;
        float num2 = -15f;
        if ( ( ( gms_PLAYER_WORK.player_flag & 131072U ) != 0U && ( 26 > gms_PLAYER_WORK.act_state || gms_PLAYER_WORK.act_state > 30 ) ) || AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            num2 = -21f;
        }
        else if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U && ( gms_PLAYER_WORK.gmk_flag2 & 64U ) == 0U )
        {
            num = 0f;
            num2 = 0f;
        }
        AppMain.nnTranslateMatrix( obj_3d.user_obj_mtx_r, obj_3d.user_obj_mtx_r, 0f, num2 / AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.draw_scale.y ), num / AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.draw_scale.x ) );
        if ( ( gms_PLAYER_WORK.player_flag & 2147483920U ) != 0U )
        {
            y = gms_PLAYER_WORK.obj_work.dir.y;
            AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
            obj_work2.dir.y = ( ushort )( obj_work2.dir.y + gms_PLAYER_WORK.pgm_turn_dir );
        }
        AppMain.ObjDrawActionSummary( obj_work );
        if ( ( gms_PLAYER_WORK.player_flag & 2147483920U ) != 0U )
        {
            gms_PLAYER_WORK.obj_work.dir.y = y;
        }
    }

    // Token: 0x06000AE8 RID: 2792 RVA: 0x00060D68 File Offset: 0x0005EF68
    private static void gmPlayerDefaultInFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        AppMain.gmPlayerKeyGet( gms_PLAYER_WORK );
        AppMain.gmPlayerWaterCheck( gms_PLAYER_WORK );
        AppMain.gmPlayerTimeOverCheck( gms_PLAYER_WORK );
        AppMain.gmPlayerFallDownCheck( gms_PLAYER_WORK );
        AppMain.gmPlayerPressureCheck( gms_PLAYER_WORK );
        AppMain.gmPlayerGetHomingTarget( gms_PLAYER_WORK );
        AppMain.gmPlayerSuperSonicCheck( gms_PLAYER_WORK );
        AppMain.gmPlayerPushSet( gms_PLAYER_WORK );
        AppMain.gmPlayerEarthTouch( gms_PLAYER_WORK );
        if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
        {
            gms_PLAYER_WORK.truck_prev_dir = gms_PLAYER_WORK.obj_work.dir.z;
            gms_PLAYER_WORK.truck_prev_dir_fall = gms_PLAYER_WORK.obj_work.dir_fall;
        }
        if ( gms_PLAYER_WORK.gmk_obj != null && ( gms_PLAYER_WORK.gmk_obj.flag & 4U ) != 0U )
        {
            gms_PLAYER_WORK.gmk_obj = null;
        }
        if ( gms_PLAYER_WORK.invincible_timer != 0 )
        {
            gms_PLAYER_WORK.invincible_timer = AppMain.ObjTimeCountDown( gms_PLAYER_WORK.invincible_timer );
            if ( ( gms_PLAYER_WORK.invincible_timer & 16384 ) != 0 )
            {
                gms_PLAYER_WORK.obj_work.disp_flag |= 32U;
            }
            else
            {
                gms_PLAYER_WORK.obj_work.disp_flag &= 4294967263U;
            }
            if ( gms_PLAYER_WORK.invincible_timer == 0 )
            {
                gms_PLAYER_WORK.obj_work.disp_flag &= 4294967263U;
                AppMain.GmPlayerSetDefNormal( gms_PLAYER_WORK );
            }
        }
        if ( gms_PLAYER_WORK.disapprove_item_catch_timer != 0 )
        {
            gms_PLAYER_WORK.disapprove_item_catch_timer = AppMain.ObjTimeCountDown( gms_PLAYER_WORK.disapprove_item_catch_timer );
        }
        if ( gms_PLAYER_WORK.genocide_timer != 0 )
        {
            gms_PLAYER_WORK.genocide_timer = AppMain.ObjTimeCountDown( gms_PLAYER_WORK.genocide_timer );
        }
        if ( gms_PLAYER_WORK.genocide_timer != 0 || ( gms_PLAYER_WORK.player_flag & 16384U ) != 0U )
        {
            gms_PLAYER_WORK.water_timer = 0;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_PLAYER_WORK.rect_work[2];
            AppMain.OBS_RECT_WORK obs_RECT_WORK2 = obs_RECT_WORK;
            obs_RECT_WORK2.hit_flag |= 2;
            obs_RECT_WORK.hit_power = 3;
            obs_RECT_WORK = gms_PLAYER_WORK.rect_work[0];
            obs_RECT_WORK.def_flag = ushort.MaxValue;
        }
        else if ( ( gms_PLAYER_WORK.rect_work[2].hit_flag & 2 ) != 0 )
        {
            gms_PLAYER_WORK.obj_work.disp_flag &= 4294967263U;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_PLAYER_WORK.rect_work[2];
            ushort num = 65533;
            obs_RECT_WORK.hit_flag &= num;
            obs_RECT_WORK.hit_power = 1;
            obs_RECT_WORK = gms_PLAYER_WORK.rect_work[0];
            obs_RECT_WORK.def_flag = 65533;
            AppMain.GmSoundStopJingleInvincible();
        }
        if ( gms_PLAYER_WORK.hi_speed_timer != 0 )
        {
            gms_PLAYER_WORK.hi_speed_timer = AppMain.ObjTimeCountDown( gms_PLAYER_WORK.hi_speed_timer );
            if ( gms_PLAYER_WORK.hi_speed_timer == 0 )
            {
                AppMain.GmPlayerSpdParameterSet( gms_PLAYER_WORK );
            }
        }
        if ( gms_PLAYER_WORK.homing_timer != 0 )
        {
            gms_PLAYER_WORK.homing_timer = AppMain.ObjTimeCountDown( gms_PLAYER_WORK.homing_timer );
        }
        if ( ( gms_PLAYER_WORK.player_flag & 262144U ) != 0U )
        {
            gms_PLAYER_WORK.obj_work.sys_flag &= 4294967055U;
            if ( ( gms_PLAYER_WORK.obj_work.sys_flag & 1U ) != 0U )
            {
                gms_PLAYER_WORK.obj_work.sys_flag |= 16U;
            }
            if ( ( gms_PLAYER_WORK.obj_work.sys_flag & 2U ) != 0U )
            {
                gms_PLAYER_WORK.obj_work.sys_flag |= 32U;
            }
            if ( ( gms_PLAYER_WORK.obj_work.sys_flag & 4U ) != 0U )
            {
                gms_PLAYER_WORK.obj_work.sys_flag |= 64U;
            }
            if ( ( gms_PLAYER_WORK.obj_work.sys_flag & 8U ) != 0U )
            {
                gms_PLAYER_WORK.obj_work.sys_flag |= 128U;
            }
            gms_PLAYER_WORK.obj_work.sys_flag &= 4294967280U;
            gms_PLAYER_WORK.gmk_flag2 &= 4294967279U;
            if ( ( gms_PLAYER_WORK.gmk_flag2 & 8U ) != 0U )
            {
                gms_PLAYER_WORK.gmk_flag2 |= 16U;
            }
            gms_PLAYER_WORK.gmk_flag2 &= 4294967287U;
            if ( gms_PLAYER_WORK.jump_pseudofall_eve_id_set == 0 )
            {
                gms_PLAYER_WORK.jump_pseudofall_eve_id_cur = gms_PLAYER_WORK.jump_pseudofall_eve_id_wait;
            }
            gms_PLAYER_WORK.jump_pseudofall_eve_id_set = 0;
            gms_PLAYER_WORK.jump_pseudofall_eve_id_wait = 0;
            ushort num3;
            int num4;
            int num5;
            if ( ( ( gms_PLAYER_WORK.gmk_flag2 & 256U ) == 0U || ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U ) && gms_PLAYER_WORK.seq_state != 39 )
            {
                int num2 = -gms_PLAYER_WORK.key_rot_z;
                if ( ( AppMain.g_gs_main_sys_info.game_flag & 512U ) != 0U )
                {
                    num2 = num2 * 38 / 10;
                    if ( ( AppMain.fall_rot_buf_gmPlayerDefaultInFunc > 0 && num2 >= 0 ) || ( AppMain.fall_rot_buf_gmPlayerDefaultInFunc < 0 && num2 <= 0 ) )
                    {
                        num2 += AppMain.fall_rot_buf_gmPlayerDefaultInFunc;
                    }
                    AppMain.fall_rot_buf_gmPlayerDefaultInFunc = 0;
                    if ( num2 > 5120 )
                    {
                        AppMain.fall_rot_buf_gmPlayerDefaultInFunc += num2 - 5120;
                        if ( AppMain.fall_rot_buf_gmPlayerDefaultInFunc > 49152 )
                        {
                            AppMain.fall_rot_buf_gmPlayerDefaultInFunc = 49152;
                        }
                        num2 = 5120;
                    }
                    else if ( num2 < -5120 )
                    {
                        AppMain.fall_rot_buf_gmPlayerDefaultInFunc += num2 + 5120;
                        if ( AppMain.fall_rot_buf_gmPlayerDefaultInFunc < -49152 )
                        {
                            AppMain.fall_rot_buf_gmPlayerDefaultInFunc = -49152;
                        }
                        num2 = -5120;
                    }
                }
                else
                {
                    num2 /= 24;
                }
                num3 = ( ushort )( gms_PLAYER_WORK.obj_work.dir.z + ( gms_PLAYER_WORK.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir ) );
                num4 = 60075;
                num5 = 5460;
                if ( ( int )num3 > num5 && ( int )num3 < num4 )
                {
                    if ( num3 > 32768 && num2 > 0 )
                    {
                        num2 = 0;
                    }
                    else if ( num3 <= 32768 && num2 <= 0 )
                    {
                        num2 = 0;
                    }
                }
                if ( ( gms_PLAYER_WORK.gmk_flag & 262144U ) != 0U && ( gms_PLAYER_WORK.gmk_flag & 1073741824U ) == 0U )
                {
                    num2 = 0;
                }
                if ( ( AppMain.g_gm_main_system.game_flag & 16384U ) != 0U || ( gms_PLAYER_WORK.player_flag & 1048576U ) != 0U )
                {
                    if ( ( short )num3 < 0 )
                    {
                        num2 = ( int )( ( short )num3 );
                    }
                    else if ( ( short )num3 > 0 )
                    {
                        num2 = ( int )( ( short )num3 );
                    }
                    else
                    {
                        num2 = 0;
                    }
                }
                int num6 = num2;
                if ( num6 > 32768 )
                {
                    num6 -= 65536;
                }
                else if ( num6 < -32768 )
                {
                    num6 += 65536;
                }
                int num7 = num6;
                if ( AppMain.MTM_MATH_ABS( num7 ) > 5120 )
                {
                    if ( num7 >= 0 )
                    {
                        num7 = 5120;
                    }
                    else
                    {
                        num7 = -5120;
                    }
                }
                gms_PLAYER_WORK.ply_pseudofall_dir += num7;
                AppMain.g_gm_main_system.pseudofall_dir = ( ushort )gms_PLAYER_WORK.ply_pseudofall_dir;
            }
            gms_PLAYER_WORK.prev_dir_fall = obj_work.dir_fall;
            if ( ( obj_work.move_flag & 1U ) != 0U )
            {
                obj_work.dir_fall = ( ushort )( AppMain.g_gm_main_system.pseudofall_dir + 8192 & 49152 );
            }
            else
            {
                obj_work.dir_fall = ( ushort )( gms_PLAYER_WORK.jump_pseudofall_dir + 8192 & 49152 );
            }
            if ( gms_PLAYER_WORK.prev_dir_fall != obj_work.dir_fall )
            {
                AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
                obj_work2.dir.z = ( ushort )( obj_work2.dir.z - ( obj_work.dir_fall - gms_PLAYER_WORK.prev_dir_fall ) );
            }
            num4 = 60075;
            num5 = 5460;
            if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
            {
                num3 = ( ushort )( gms_PLAYER_WORK.obj_work.dir.z + ( gms_PLAYER_WORK.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir ) );
                if ( ( int )num3 > num5 && ( int )num3 < num4 )
                {
                    if ( num3 > 32768 )
                    {
                        gms_PLAYER_WORK.ply_pseudofall_dir -= num4 - ( int )num3;
                    }
                    else if ( num3 <= 32768 )
                    {
                        gms_PLAYER_WORK.ply_pseudofall_dir += ( int )num3 - num5;
                    }
                }
            }
            num3 = ( ushort )( gms_PLAYER_WORK.obj_work.dir.z + ( gms_PLAYER_WORK.obj_work.dir_fall - AppMain.g_gm_main_system.pseudofall_dir ) );
            if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
            {
                if ( ( gms_PLAYER_WORK.gmk_flag2 & 24U ) == 0U && 27392 < num3 && num3 < 38144 )
                {
                    if ( gms_PLAYER_WORK.truck_prev_dir == obj_work.dir.z )
                    {
                        gms_PLAYER_WORK.obj_work.spd_m = 0;
                        if ( ( gms_PLAYER_WORK.gmk_flag & 262144U ) == 0U )
                        {
                            gms_PLAYER_WORK.gmk_flag |= 262144U;
                            AppMain.GmPlySeqGmkInitTruckDanger( gms_PLAYER_WORK, gms_PLAYER_WORK.truck_obj );
                            AppMain.GmPlayerSpdParameterSet( gms_PLAYER_WORK );
                        }
                    }
                }
                else if ( ( gms_PLAYER_WORK.gmk_flag & 262144U ) == 0U )
                {
                    gms_PLAYER_WORK.truck_stick_prev_dir = num3;
                }
            }
            if ( ( gms_PLAYER_WORK.gmk_flag & 1074003968U ) == 1074003968U && ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) == 0U || 27392 >= num3 || num3 >= 38144 ) )
            {
                gms_PLAYER_WORK.player_flag |= 1U;
                AppMain.GmPlayerSpdParameterSet( gms_PLAYER_WORK );
            }
            if ( ( gms_PLAYER_WORK.gmk_flag & 2147483648U ) != 0U )
            {
                gms_PLAYER_WORK.gmk_flag &= 1073479679U;
                gms_PLAYER_WORK.obj_work.vib_timer = 0;
                AppMain.GmPlayerSetDefNormal( gms_PLAYER_WORK );
                AppMain.GmPlayerSpdParameterSet( gms_PLAYER_WORK );
            }
        }
    }

    // Token: 0x06000AE9 RID: 2793 RVA: 0x00061540 File Offset: 0x0005F740
    private static void gmPlayerSplStgInFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        AppMain.gmPlayerKeyGet( gms_PLAYER_WORK );
        AppMain.gmPlayerTimeOverCheck( gms_PLAYER_WORK );
        AppMain.gmPlayerEarthTouch( gms_PLAYER_WORK );
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
            AppMain.g_gm_main_system.pseudofall_dir = ( ushort )( -( ushort )obs_CAMERA.roll );
            gms_PLAYER_WORK.prev_dir_fall2 = gms_PLAYER_WORK.prev_dir_fall;
            gms_PLAYER_WORK.prev_dir_fall = obj_work.dir_fall;
            obj_work.dir_fall = ( ushort )( AppMain.g_gm_main_system.pseudofall_dir + 8192 & 49152 );
            gms_PLAYER_WORK.jump_pseudofall_dir = AppMain.g_gm_main_system.pseudofall_dir;
        }
        if ( gms_PLAYER_WORK.gmk_obj != null && ( gms_PLAYER_WORK.gmk_obj.flag & 4U ) != 0U )
        {
            gms_PLAYER_WORK.gmk_obj = null;
        }
    }

    // Token: 0x06000AEA RID: 2794 RVA: 0x000615F4 File Offset: 0x0005F7F4
    private static void gmPlayerRectTruckFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        if ( ( ( ( obj_work.move_flag & 1U ) != 0U && AppMain.MTM_MATH_ABS( obj_work.spd_m ) > 256 ) || ( obj_work.move_flag & 1U ) == 0U ) && ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U && gms_PLAYER_WORK.seq_state != 22 )
        {
            AppMain.GmPlayerSetAtk( gms_PLAYER_WORK );
            return;
        }
        gms_PLAYER_WORK.rect_work[1].flag &= 4294967291U;
    }

    // Token: 0x06000AEB RID: 2795 RVA: 0x00061664 File Offset: 0x0005F864
    private static void gmPlayerDefaultLastFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work;
        AppMain.gmPlayerCameraOffset( gms_PLAYER_WORK );
        if ( gms_PLAYER_WORK.gmk_obj == null || ( gms_PLAYER_WORK.gmk_flag & 8U ) != 0U )
        {
            obj_work.move_flag &= 4294950911U;
        }
        if ( ( gms_PLAYER_WORK.player_flag & 32768U ) != 0U && obj_work.pos.x >> 12 > AppMain.g_gm_main_system.map_fcol.left + 128 )
        {
            obj_work.move_flag |= 16384U;
        }
    }

    // Token: 0x06000AEC RID: 2796 RVA: 0x000616E8 File Offset: 0x0005F8E8
    private static void gmPlayerTruckCollisionFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        bool flag = false;
        uint num = 0U;
        int num2 = 0;
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        AppMain.VecFx32 vecFx2 = default(AppMain.VecFx32);
        AppMain.VecFx32 vecFx3 = default(AppMain.VecFx32);
        ushort num3 = 0;
        ushort dir_fall = 0;
        if ( ( obj_work.move_flag & 1U ) != 0U && ( obj_work.move_flag & 16U ) == 0U && AppMain.MTM_MATH_ABS( obj_work.spd_m ) >= 16384 )
        {
            flag = true;
            num = obj_work.move_flag;
            num2 = obj_work.spd_m;
            vecFx.Assign( obj_work.spd );
            vecFx2.Assign( obj_work.pos );
            vecFx3.Assign( obj_work.move );
            num3 = obj_work.dir.z;
            dir_fall = obj_work.dir_fall;
        }
        if ( AppMain.g_obj.ppCollision != null )
        {
            AppMain.g_obj.ppCollision( obj_work );
        }
        if ( flag && ( obj_work.move_flag & 1U ) != 0U )
        {
            ushort num4 = (ushort)(obj_work.dir.z - num3);
            if ( num2 > 0 )
            {
                if ( 4096 > num4 || num4 > 16384 )
                {
                    return;
                }
            }
            else if ( 61440 < num4 || num4 < 32768 )
            {
                return;
            }
            obj_work.move_flag = num;
            obj_work.spd_m = AppMain.FX_Mul( num2, 4096 );
            obj_work.spd.Assign( vecFx );
            obj_work.pos.Assign( vecFx2 );
            obj_work.move.Assign( vecFx3 );
            obj_work.dir.z = num3;
            obj_work.dir_fall = dir_fall;
            obj_work.move_flag = ( num & 4294967294U );
            ( ( AppMain.GMS_PLAYER_WORK )obj_work ).gmk_flag2 |= 1U;
        }
        if ( ( obj_work.move_flag & 4194305U ) == 4194305U )
        {
            if ( obj_work.dir_fall != ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir_fall )
            {
                ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir = ( ushort )( ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir + ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir_fall - obj_work.dir_fall );
                ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir_fall = obj_work.dir_fall;
            }
            if ( AppMain.MTM_MATH_ABS( ( int )( ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir - obj_work.dir.z ) ) > 1024 )
            {
                obj_work.dir.z = AppMain.ObjRoopMove16( ( ( AppMain.GMS_PLAYER_WORK )obj_work ).truck_prev_dir, obj_work.dir.z, 1024 );
            }
        }
    }

    // Token: 0x06000AED RID: 2797 RVA: 0x00061918 File Offset: 0x0005FB18
    private static void gmPlayerAtkFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
    }

    // Token: 0x06000AEE RID: 2798 RVA: 0x0006191C File Offset: 0x0005FB1C
    private static void gmPlayerDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)mine_rect.parent_obj;
        AppMain.HgTrophyIncPlayerDamageCount( gms_PLAYER_WORK );
        if ( ( gms_PLAYER_WORK.obj_work.move_flag & 32768U ) != 0U )
        {
            int x = gms_PLAYER_WORK.obj_work.spd.x;
        }
        else
        {
            int spd_m = gms_PLAYER_WORK.obj_work.spd_m;
        }
        if ( match_rect.parent_obj.obj_type == 3 )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)match_rect.parent_obj;
            if ( ( 91 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 94 ) || gms_ENEMY_COM_WORK.eve_rec.id == 97 || gms_ENEMY_COM_WORK.eve_rec.id == 98 )
            {
                AppMain.GmSoundPlaySE( "Damage2" );
            }
        }
        if ( ( gms_PLAYER_WORK.player_flag & 268435456U ) == 0U && gms_PLAYER_WORK.ring_num == 0 )
        {
            AppMain.GmPlySeqChangeDeath( gms_PLAYER_WORK );
            return;
        }
        uint gmk_flag = gms_PLAYER_WORK.gmk_flag;
        AppMain.GmPlayerStateInit( gms_PLAYER_WORK );
        if ( ( gms_PLAYER_WORK.player_flag & 268435456U ) == 0U )
        {
            if ( gms_PLAYER_WORK.ring_num != 0 )
            {
                AppMain.GmSoundPlaySE( "Ring2" );
            }
            AppMain.GmRingDamageSet( gms_PLAYER_WORK );
            AppMain.GmComEfctCreateHitEnemy( gms_PLAYER_WORK.obj_work, ( int )( ( mine_rect.rect.left + mine_rect.rect.right ) * 4096 / 2 ), ( int )( ( mine_rect.rect.top + mine_rect.rect.bottom ) * 4096 / 2 ) );
        }
        if ( ( gms_PLAYER_WORK.player_flag & 805306368U ) != 0U )
        {
            AppMain.GmSoundPlaySE( "Damage1" );
        }
        gms_PLAYER_WORK.player_flag &= 3489660927U;
        gms_PLAYER_WORK.invincible_timer = gms_PLAYER_WORK.time_damage;
        AppMain.GmPlySeqChangeDamage( gms_PLAYER_WORK );
    }

    // Token: 0x06000AEF RID: 2799 RVA: 0x00061AA4 File Offset: 0x0005FCA4
    private static void gmPlayerPushSet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.seq_state == 18 && ply_work.act_state == 18 )
        {
            ply_work.obj_work.move_flag |= 16777216U;
            return;
        }
        ply_work.obj_work.move_flag &= 4278190079U;
    }

    // Token: 0x06000AF0 RID: 2800 RVA: 0x00061AF4 File Offset: 0x0005FCF4
    private static void gmPlayerEarthTouch( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.gmk_flag & 1U ) != 0U && ( ply_work.obj_work.move_flag & 15U ) != 0U )
        {
            if ( ( ply_work.obj_work.move_flag & 1U ) != 0U )
            {
                AppMain.GmPlySeqLandingSet( ply_work, 0 );
            }
            else if ( ( ply_work.obj_work.move_flag & 2U ) != 0U )
            {
                if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
                {
                    AppMain.GmPlySeqLandingSet( ply_work, 24576 );
                }
                else
                {
                    AppMain.GmPlySeqLandingSet( ply_work, 40960 );
                }
                AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
                obs_COL_CHK_DATA.pos_x = ply_work.obj_work.pos.x >> 12;
                obs_COL_CHK_DATA.pos_y = ( ply_work.obj_work.pos.y >> 12 ) + ( int )ply_work.obj_work.field_rect[1] - 4;
                obs_COL_CHK_DATA.flag = ( ushort )( ply_work.obj_work.flag & 1U );
                obs_COL_CHK_DATA.vec = 3;
                ushort[] array = new ushort[1];
                obs_COL_CHK_DATA.dir = array;
                obs_COL_CHK_DATA.attr = null;
                ushort num = ply_work.obj_work.dir.z;
                array[0] = num;
                AppMain.ObjDiffCollisionFast( obs_COL_CHK_DATA );
                num = array[0];
                ply_work.obj_work.dir.z = num;
                AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
            }
            else if ( ( ply_work.obj_work.move_flag & 4U ) != 0U )
            {
                if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
                {
                    AppMain.GmPlySeqLandingSet( ply_work, 16384 );
                }
                else
                {
                    AppMain.GmPlySeqLandingSet( ply_work, 49152 );
                }
            }
            else if ( ( ply_work.obj_work.move_flag & 8U ) != 0U )
            {
                if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
                {
                    AppMain.GmPlySeqLandingSet( ply_work, 49152 );
                }
                else
                {
                    AppMain.GmPlySeqLandingSet( ply_work, 16384 );
                }
            }
            if ( ( ply_work.gmk_flag & 2048U ) != 0U )
            {
                if ( ply_work.obj_work.dir.z < 32768 )
                {
                    ply_work.obj_work.disp_flag |= 1U;
                    ply_work.obj_work.spd_m = -AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
                }
                else
                {
                    ply_work.obj_work.disp_flag &= 4294967294U;
                    ply_work.obj_work.spd_m = AppMain.MTM_MATH_ABS( ply_work.obj_work.spd_m );
                }
            }
            else
            {
                if ( ( ply_work.gmk_flag & 33554432U ) != 0U )
                {
                    ply_work.obj_work.disp_flag ^= 1U;
                }
                if ( ( ply_work.gmk_flag & 2U ) != 0U )
                {
                    ply_work.obj_work.disp_flag ^= 1U;
                    ply_work.obj_work.spd_m = -ply_work.obj_work.spd_m;
                }
            }
            ply_work.obj_work.move_flag |= 1U;
            ply_work.gmk_flag &= 4261410812U;
            AppMain.GmPlySeqChangeFw( ply_work );
        }
    }

    // Token: 0x06000AF1 RID: 2801 RVA: 0x00061DA0 File Offset: 0x0005FFA0
    private static void gmPlayerWaterCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( AppMain.GmMainIsWaterLevel() )
        {
            if ( ( ply_work.obj_work.pos.y >> 12 ) - -10 < ( int )AppMain.g_gm_main_system.water_level )
            {
                if ( ( ply_work.player_flag & 67108864U ) != 0U )
                {
                    if ( ( AppMain.g_gm_main_system.game_flag & 8192U ) == 0U )
                    {
                        AppMain.GmPlyEfctCreateSpray( ply_work );
                        AppMain.GmSoundPlaySE( "Spray" );
                    }
                    AppMain.GmSoundStopJingleObore();
                    AppMain.GmPlayerSpdParameterSetWater( ply_work, false );
                }
                ply_work.player_flag &= 4227858431U;
                ply_work.water_timer = 0;
                ply_work.obj_work.spd_fall = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall;
                ply_work.obj_work.spd_fall_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall_max;
                return;
            }
            bool flag = false;
            if ( ( ply_work.player_flag & 67108864U ) == 0U )
            {
                if ( ( AppMain.g_gm_main_system.game_flag & 8192U ) == 0U )
                {
                    AppMain.GmPlyEfctCreateSpray( ply_work );
                    AppMain.GmPlyEfctCreateBubble( ply_work );
                    AppMain.GmSoundPlaySE( "Spray" );
                }
                AppMain.GmPlayerSpdParameterSetWater( ply_work, true );
            }
            ply_work.player_flag |= 67108864U;
            if ( ( ply_work.player_flag & 16778240U ) == 0U )
            {
                if ( ( ply_work.obj_work.pos.y >> 12 ) - 4 >= ( int )AppMain.g_gm_main_system.water_level )
                {
                    ply_work.water_timer = AppMain.ObjTimeCountUp( ply_work.water_timer );
                }
                else
                {
                    ply_work.water_timer = 0;
                    AppMain.GmPlyEfctCreateRunSpray( ply_work );
                    flag = true;
                }
            }
            if ( ( ply_work.player_flag & 16778240U ) == 0U )
            {
                if ( ( ply_work.water_timer >> 12 ) % 50 == 0 && ply_work.water_timer < ply_work.time_air )
                {
                    AppMain.GmPlyEfctCreateBubble( ply_work );
                }
                if ( !flag && ( ply_work.water_timer >> 12 ) % 300 == 0 )
                {
                    if ( ( ply_work.gmk_flag & 524288U ) == 0U )
                    {
                        AppMain.GmSoundPlaySE( "Attention" );
                    }
                    ply_work.gmk_flag |= 524288U;
                }
                else
                {
                    ply_work.gmk_flag &= 4294443007U;
                }
                int num = ply_work.time_air - ply_work.water_timer;
                if ( num >= 245760 && num - 245760 <= 2457600 && ( num - 245760 >> 12 ) % 120 == 0 )
                {
                    uint num2 = (uint)((num - 245760 >> 12) / 120);
                    num2 = AppMain.MTM_MATH_CLIP( num2, 0U, 5U );
                    AppMain.GmPlyEfctWaterCount( ply_work, num2 );
                }
                if ( num == 2826240 )
                {
                    AppMain.GmSoundPlayJingleObore();
                }
                else if ( num > 2826240 )
                {
                    AppMain.GmSoundStopJingleObore();
                }
                if ( ply_work.water_timer > ply_work.time_air )
                {
                    AppMain.GmPlySeqChangeDeath( ply_work );
                    ply_work.obj_work.spd.y = 0;
                    AppMain.GmPlyEfctWaterDeath( ply_work );
                    return;
                }
            }
        }
        else
        {
            if ( ( ply_work.player_flag & 67108864U ) != 0U )
            {
                ply_work.obj_work.spd_fall = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall;
                ply_work.obj_work.spd_fall_max = AppMain.g_gm_player_parameter[( int )ply_work.char_id].spd_fall_max;
            }
            ply_work.player_flag &= 4227858431U;
            ply_work.water_timer = 0;
            ply_work.gmk_flag &= 4294443007U;
        }
    }

    // Token: 0x06000AF2 RID: 2802 RVA: 0x000620B0 File Offset: 0x000602B0
    private static void gmPlayerTimeOverCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( AppMain.g_gm_main_system.game_flag & 1327676U ) != 0U )
        {
            return;
        }
        if ( ( ply_work.player_flag & 65536U ) != 0U )
        {
            return;
        }
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            if ( ( ply_work.player_flag & 1024U ) == 0U && AppMain.g_gm_main_system.game_time >= 35999U )
            {
                AppMain.GmPlySeqChangeDeath( ply_work );
                AppMain.g_gm_main_system.game_flag |= 512U;
                AppMain.g_gm_main_system.time_save = 0U;
                AppMain.g_gs_main_sys_info.game_flag |= 8U;
                return;
            }
        }
        else if ( AppMain.g_gm_main_system.game_time <= 0U )
        {
            AppMain.g_gm_main_system.game_flag |= 262144U;
            AppMain.g_gm_main_system.time_save = 0U;
            AppMain.g_gs_main_sys_info.game_flag |= 8U;
            ply_work.obj_work.move_flag |= 8448U;
        }
    }

    // Token: 0x06000AF3 RID: 2803 RVA: 0x0006219C File Offset: 0x0006039C
    private static void gmPlayerFallDownCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 1024U ) == 0U && AppMain.g_gm_main_system.map_size[1] - 16 << 12 <= ply_work.obj_work.pos.y )
        {
            AppMain.GmPlySeqChangeDeath( ply_work );
        }
    }

    // Token: 0x06000AF4 RID: 2804 RVA: 0x000621D8 File Offset: 0x000603D8
    private static void gmPlayerPressureCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 2048U ) != 0U && ply_work.obj_work.touch_obj == null && ( ply_work.obj_work.move_flag & 4U ) != 0U && ( ply_work.obj_work.move_flag & 8U ) != 0U )
        {
            AppMain.GmPlySeqChangeDeath( ply_work );
        }
        if ( ply_work.obj_work.touch_obj != null && ( ply_work.player_flag & 4096U ) == 0U && ( ply_work.obj_work.touch_obj.obj_type != 3 || ( ply_work.obj_work.touch_obj.obj_type == 3 && ( ( ( AppMain.GMS_ENEMY_COM_WORK )ply_work.obj_work.touch_obj ).enemy_flag & 16384U ) == 0U ) ) )
        {
            if ( ply_work.obj_work.ride_obj == null && ( ply_work.obj_work.move_flag & 1U ) != 0U && ( ply_work.obj_work.move_flag & 2U ) != 0U && ply_work.obj_work.touch_obj.move.y <= 0 )
            {
                return;
            }
            if ( ( ( ply_work.obj_work.move_flag & 1U ) != 0U && ( ply_work.obj_work.move_flag & 2U ) != 0U ) || ( ( ply_work.obj_work.move_flag & 4U ) != 0U && ( ply_work.obj_work.move_flag & 8U ) != 0U ) )
            {
                AppMain.GmPlySeqChangeDeath( ply_work );
            }
        }
    }

    // Token: 0x06000AF5 RID: 2805 RVA: 0x00062314 File Offset: 0x00060514
    private static void gmPlayerSuperSonicCheck( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ( ply_work.player_flag & 16384U ) != 0U )
        {
            ply_work.super_sonic_ring_timer = AppMain.ObjTimeCountDown( ply_work.super_sonic_ring_timer );
            if ( ply_work.super_sonic_ring_timer == 0 )
            {
                ply_work.ring_num -= 1;
                if ( ply_work.ring_num <= 0 )
                {
                    ply_work.ring_num = 0;
                    AppMain.gmPlayerSuperSonicToSonic( ply_work );
                    return;
                }
                ply_work.super_sonic_ring_timer = 245760;
            }
        }
    }

    // Token: 0x06000AF6 RID: 2806 RVA: 0x0006237C File Offset: 0x0006057C
    private static void gmPlayerSuperSonicToSonic( AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_PLAYER_RESET_ACT_WORK reset_act_work = new AppMain.GMS_PLAYER_RESET_ACT_WORK();
        AppMain.GmPlayerSaveResetAction( ply_work, reset_act_work );
        AppMain.GmPlayerSetEndSuperSonic( ply_work );
        if ( ( ( ( ply_work.obj_work.move_flag & 1U ) == 0U || ( ply_work.obj_work.move_flag & 16U ) != 0U ) && ply_work.act_state == 21 ) || ply_work.act_state == 22 )
        {
            AppMain.GmPlayerActionChange( ply_work, 42 );
            ply_work.obj_work.disp_flag |= 4U;
            return;
        }
        AppMain.GmPlayerResetAction( ply_work, reset_act_work );
    }

    // Token: 0x06000AF7 RID: 2807 RVA: 0x000623F4 File Offset: 0x000605F4
    private static void gmPlayerGetHomingTarget( AppMain.GMS_PLAYER_WORK ply_work )
    {
        float num = AppMain.FXM_FX32_TO_FLOAT(786432) * AppMain.FXM_FX32_TO_FLOAT(786432);
        float num2 = 1.5f;
        if ( ply_work.homing_boost_timer != 0 )
        {
            num2 = 1f;
            ply_work.homing_boost_timer = AppMain.ObjTimeCountDown( ply_work.homing_boost_timer );
        }
        if ( ply_work.enemy_obj != null && ( ply_work.enemy_obj.flag & 4U ) != 0U )
        {
            ply_work.enemy_obj = null;
        }
        AppMain.OBS_RECT_WORK obs_RECT_WORK = ply_work.rect_work[2];
        float num3 = AppMain.FXM_FX32_TO_FLOAT(ply_work.obj_work.pos.x);
        float num4 = AppMain.FXM_FX32_TO_FLOAT(ply_work.obj_work.pos.y + (obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1));
        int num5;
        int num6;
        if ( ( ply_work.obj_work.disp_flag & 1U ) != 0U )
        {
            num5 = 32768;
            num6 = 18205;
        }
        else
        {
            num5 = 0;
            num6 = 14563;
        }
        if ( num6 < num5 )
        {
            AppMain.MTM_MATH_SWAP<int>( ref num5, ref num6 );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject(null, ushort.MaxValue);
        AppMain.OBS_OBJECT_WORK enemy_obj = null;
        while ( obs_OBJECT_WORK != null )
        {
            if ( ( obs_OBJECT_WORK.disp_flag & 32U ) == 0U )
            {
                AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK;
                if ( obs_OBJECT_WORK.obj_type == 3 )
                {
                    gms_ENEMY_COM_WORK = ( AppMain.GMS_ENEMY_COM_WORK )obs_OBJECT_WORK;
                    if ( ( gms_ENEMY_COM_WORK.enemy_flag & 32768U ) != 0U )
                    {
                        goto IL_2CF;
                    }
                    if ( ( 63 > gms_ENEMY_COM_WORK.eve_rec.id || gms_ENEMY_COM_WORK.eve_rec.id > 67 || gms_ENEMY_COM_WORK.eve_rec.byte_param[1] != 0 ) && ( 70 > gms_ENEMY_COM_WORK.eve_rec.id || gms_ENEMY_COM_WORK.eve_rec.id > 79 ) && ( 100 > gms_ENEMY_COM_WORK.eve_rec.id || gms_ENEMY_COM_WORK.eve_rec.id > 101 ) && 130 != gms_ENEMY_COM_WORK.eve_rec.id && ( 112 > gms_ENEMY_COM_WORK.eve_rec.id || gms_ENEMY_COM_WORK.eve_rec.id > 114 ) && 163 != gms_ENEMY_COM_WORK.eve_rec.id && 86 != gms_ENEMY_COM_WORK.eve_rec.id && 161 != gms_ENEMY_COM_WORK.eve_rec.id && 247 != gms_ENEMY_COM_WORK.eve_rec.id )
                    {
                        goto IL_2CF;
                    }
                }
                else
                {
                    if ( obs_OBJECT_WORK.obj_type != 2 )
                    {
                        goto IL_2CF;
                    }
                    gms_ENEMY_COM_WORK = ( AppMain.GMS_ENEMY_COM_WORK )obs_OBJECT_WORK;
                    if ( ( gms_ENEMY_COM_WORK.enemy_flag & 32768U ) != 0U )
                    {
                        goto IL_2CF;
                    }
                }
                obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
                float num7 = AppMain.FXM_FX32_TO_FLOAT(obs_OBJECT_WORK.pos.x);
                float num8 = AppMain.FXM_FX32_TO_FLOAT(obs_OBJECT_WORK.pos.y + (obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1));
                float num9 = num7 - num3;
                float num10 = num8 - num4;
                int num11 = AppMain.nnArcTan2((double)num10, (double)num9);
                if ( num11 >= num5 && num11 <= num6 )
                {
                    num10 *= num2;
                    float num12 = num9 * num9 + num10 * num10;
                    if ( num12 < num )
                    {
                        num = num12;
                        enemy_obj = obs_OBJECT_WORK;
                    }
                }
            }
            IL_2CF:
            obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ushort.MaxValue );
        }
        ply_work.enemy_obj = enemy_obj;
        if ( ply_work.cursol_enemy_obj != ply_work.enemy_obj || !AppMain.GmPlySeqCheckAcceptHoming( ply_work ) )
        {
            ply_work.cursol_enemy_obj = null;
        }
    }

    // Token: 0x06000AF8 RID: 2808 RVA: 0x00062708 File Offset: 0x00060908
    private static void gmPlayerKeyGet( AppMain.GMS_PLAYER_WORK ply_work )
    {
        if ( ply_work.no_key_timer != 0 || ( ply_work.player_flag & 4194304U ) != 0U )
        {
            ply_work.no_key_timer = AppMain.ObjTimeCountDown( ply_work.no_key_timer );
            ply_work.key_on = 0;
            ply_work.key_push = 0;
            ply_work.key_repeat = 0;
            ply_work.key_release = 0;
            ply_work.key_rot_z = 0;
            ply_work.key_walk_rot_z = 0;
            return;
        }
        if ( ( ply_work.player_flag & 4194304U ) == 0U && ply_work.player_id == 0 )
        {
            int num = AppMain.gmPlayerKeyGetRotZ(ply_work);
            ply_work.prev_key_rot_z = ply_work.key_rot_z;
            ply_work.key_rot_z = num;
            ushort num2 = AppMain.gmPlayerRemapKey(ply_work, 0, num);
            ushort num3 = (ushort)(ply_work.key_on ^ num2);
            ply_work.key_push = ( ushort )( ( num3 & num2 ) );
            ply_work.key_release = ( ushort )( ( num3 & ~num2 ) );
            ply_work.key_on = num2;
            ply_work.key_repeat = 0;
            for ( int i = 0; i < 8; i++ )
            {
                if ( ( ( uint )ply_work.key_on & AppMain.gm_key_map_key_list[i] ) == 0U )
                {
                    ply_work.key_repeat_timer[i] = 30;
                }
                else if ( --ply_work.key_repeat_timer[i] == 0 )
                {
                    ply_work.key_repeat |= ( ushort )( ( ply_work.key_on & ( ushort )AppMain.gm_key_map_key_list[i] ) );
                    ply_work.key_repeat_timer[i] = 5;
                }
            }
            ply_work.key_walk_rot_z = 0;
            if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
            {
                if ( ( ply_work.key_on & 8 ) != 0 )
                {
                    ply_work.key_walk_rot_z = 32767;
                }
                else if ( ( ply_work.key_on & 4 ) != 0 )
                {
                    ply_work.key_walk_rot_z = -32767;
                }
            }
            else
            {
                ply_work.key_walk_rot_z = num;
            }
        }
        if ( AppMain.GMM_MAIN_STAGE_IS_ENDING() )
        {
            AppMain.GmEndingPlyKeyCustom( ply_work );
        }
    }

    // Token: 0x06000AF9 RID: 2809 RVA: 0x0006289C File Offset: 0x00060A9C
    private static ushort gmPlayerRemapKey( AppMain.GMS_PLAYER_WORK ply_work, ushort key, int key_rot_z )
    {
        ushort num = (ushort)((int)key & -240);
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() || AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            if ( ( AppMain.g_gs_main_sys_info.game_flag & 512U ) != 0U )
            {
                AppMain.CPadPolarHandle cpadPolarHandle = AppMain.CPadPolarHandle.CreateInstance();
                int focusTpIndex = cpadPolarHandle.GetFocusTpIndex();
                if ( AppMain.gmPlayerIsInputDPadJumpKey( ply_work, focusTpIndex ) )
                {
                    num |= ply_work.key_map[4];
                }
                if ( AppMain.gmPlayerIsInputDPadSSonicKey( ply_work, focusTpIndex ) )
                {
                    num |= ply_work.key_map[6];
                }
            }
            else
            {
                num |= AppMain.gmPlayerRemapKeyIPhoneZone32SS( ply_work );
            }
        }
        else if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
        {
            AppMain.CPadVirtualPad cpadVirtualPad = AppMain.CPadVirtualPad.CreateInstance();
            ushort value = cpadVirtualPad.GetValue();
            if ( ( 8 & value ) != 0 )
            {
                num |= ply_work.key_map[3];
            }
            else if ( ( 4 & value ) != 0 )
            {
                num |= ply_work.key_map[2];
            }
            else if ( ( 1 & value ) != 0 )
            {
                num |= ply_work.key_map[0];
            }
            else if ( ( 2 & value ) != 0 )
            {
                num |= ply_work.key_map[1];
            }
            if ( AppMain.gmPlayerIsInputDPadJumpKey( ply_work, -1 ) )
            {
                num |= ply_work.key_map[4];
            }
            if ( AppMain.gmPlayerIsInputDPadSSonicKey( ply_work, -1 ) )
            {
                num |= ply_work.key_map[6];
            }
        }
        else
        {
            if ( key_rot_z > 1024 )
            {
                num |= 8;
            }
            else if ( key_rot_z < -1024 )
            {
                num |= 4;
            }
            num |= AppMain.gmPlayerRemapKeyIPhone( ply_work );
        }
        if ( ( 32 & key ) != 0 )
        {
            num |= ply_work.key_map[4];
        }
        if ( ( 128 & key ) != 0 )
        {
            num |= ply_work.key_map[5];
        }
        if ( ( 64 & key ) != 0 )
        {
            num |= ply_work.key_map[6];
        }
        if ( ( 16 & key ) != 0 )
        {
            num |= ply_work.key_map[7];
        }
        return num;
    }

    // Token: 0x06000AFA RID: 2810 RVA: 0x00062A34 File Offset: 0x00060C34
    private static int gmPlayerKeyGetRotZ( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ply_work.is_nudge = false;
        int stage_id = (int)AppMain.g_gs_main_sys_info.stage_id;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.NNS_VECTOR core = AppMain._am_iphone_accel_data.core;
            AppMain.NNS_VECTOR calc_accel = ply_work.calc_accel;
            calc_accel.x = core.x * 0.1f + calc_accel.x * 0.9f;
            calc_accel.y = core.y * 0.1f + calc_accel.y * 0.9f;
            calc_accel.y = core.y * 0.1f + calc_accel.y * 0.9f;
            float num = core.x - calc_accel.x;
            float num2 = core.y - calc_accel.y;
            float num3 = core.z - calc_accel.z;
            float num4 = AppMain.nnSqrt(num * num + num2 * num2 + num3 * num3);
            if ( num4 >= 2f )
            {
                ply_work.is_nudge = true;
            }
        }
        int num5;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() && ( AppMain.g_gs_main_sys_info.game_flag & 512U ) != 0U )
        {
            num5 = AppMain.g_gm_main_system.polar_diff;
        }
        else if ( stage_id == 9 && ( AppMain.g_gs_main_sys_info.game_flag & 512U ) != 0U )
        {
            num5 = AppMain.g_gm_main_system.polar_diff;
        }
        else
        {
            num5 = ( int )( AppMain._am_iphone_accel_data.sensor.x * 16384f );
            if ( num5 < 2048 && num5 > -2048 )
            {
                num5 = 0;
            }
            else
            {
                num5 *= 3;
                if ( num5 > 32768 )
                {
                    num5 = 32768;
                }
                else if ( num5 < -32768 )
                {
                    num5 = -32768;
                }
            }
        }
        return num5;
    }

    // Token: 0x06000AFB RID: 2811 RVA: 0x00062BBC File Offset: 0x00060DBC
    private static ushort gmPlayerRemapKeyIPhone( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ushort num = 0;
        if ( AppMain.GmMainKeyCheckPauseKeyPush() != -1 )
        {
            return num;
        }
        int seq_state = ply_work.seq_state;
        if ( ply_work.safe_timer > 0 )
        {
            ply_work.safe_timer--;
            if ( AppMain.amTpIsTouchPull( 0 ) )
            {
                ply_work.safe_timer = 0;
                ply_work.safe_jump_timer = 10;
            }
            else if ( ply_work.safe_timer == 0 )
            {
                ply_work.safe_spin_timer = 3;
            }
        }
        else if ( ply_work.safe_jump_timer > 0 )
        {
            ply_work.safe_jump_timer--;
            num |= 32;
        }
        else if ( ply_work.safe_spin_timer != 0 )
        {
            uint num2 = ply_work.obj_work.disp_flag & 1U;
            if ( AppMain.amTpIsTouchPull( 0 ) )
            {
                ply_work.safe_spin_timer = 0;
            }
            switch ( ply_work.safe_spin_timer )
            {
                case 1:
                    num |= 2;
                    if ( !AppMain.amTpIsTouchPull( 0 ) && ( seq_state == 6 || seq_state == 7 || seq_state == 8 ) )
                    {
                        num |= 32;
                    }
                    break;
                case 2:
                    if ( seq_state != 2 )
                    {
                        ply_work.safe_spin_timer = 1;
                    }
                    num |= 2;
                    break;
                case 3:
                    {
                        ushort num3;
                        if ( AppMain.ObjTouchCheck( ply_work.obj_work, AppMain.gm_ply_touch_rect[1] ) != 0 )
                        {
                            if ( num2 != 0U )
                            {
                                num3 = 8;
                            }
                            else
                            {
                                num3 = 4;
                            }
                            ply_work.safe_spin_timer = 2;
                        }
                        else
                        {
                            num3 = 2;
                            ply_work.safe_spin_timer = 1;
                        }
                        num |= num3;
                        break;
                    }
            }
        }
        else
        {
            bool flag = AppMain.amTpIsTouchOn(0);
            bool flag2 = AppMain.amTpIsTouchPush(0);
            if ( AppMain.GmPlayerIsTransformSuperSonic( ply_work ) && flag && AppMain.GMM_PLAYER_IS_TOUCH_SUPER_SONIC_REGION( ( int )AppMain._am_tp_touch[0].on[0], ( int )AppMain._am_tp_touch[0].on[1] ) )
            {
                num |= 80;
            }
            if ( ( num & 80 ) == 0 )
            {
                ushort num4 = 0;
                uint num5 = ply_work.obj_work.disp_flag & 1U;
                ushort num6 = AppMain.ObjTouchCheck(ply_work.obj_work, AppMain.gm_ply_touch_rect[0]);
                if ( num6 == 0 && AppMain.ObjTouchCheck( ply_work.obj_work, AppMain.gm_ply_touch_rect[1] ) != 0 )
                {
                    num6 = 1;
                    if ( num5 != 0U )
                    {
                        num4 = 8;
                    }
                    else
                    {
                        num4 = 4;
                    }
                }
                if ( num6 != 0 )
                {
                    if ( AppMain._am_tp_touch[0].on[0] < 80 || AppMain._am_tp_touch[0].on[0] > 400 )
                    {
                        ply_work.safe_timer = 25;
                    }
                    else if ( seq_state == 2 )
                    {
                        if ( flag2 || flag )
                        {
                            num |= 2;
                        }
                    }
                    else if ( seq_state == 12 || seq_state == 11 )
                    {
                        if ( flag2 || flag )
                        {
                            num |= 2;
                        }
                    }
                    else if ( seq_state == 0 || seq_state == 9 )
                    {
                        if ( num4 != 0 )
                        {
                            num |= num4;
                        }
                        else if ( flag2 || flag )
                        {
                            num |= 2;
                        }
                    }
                    else if ( seq_state == 6 || seq_state == 7 || seq_state == 8 )
                    {
                        if ( flag2 || flag )
                        {
                            num |= 34;
                        }
                    }
                    else if ( seq_state == 1 || ply_work.spin_state == 3 )
                    {
                        if ( flag2 || flag )
                        {
                            ply_work.spin_state = 3;
                            num |= 2;
                        }
                    }
                    else if ( flag2 || flag )
                    {
                        ply_work.spin_state = 0;
                        num |= 32;
                    }
                }
                else
                {
                    ply_work.spin_state = 0;
                    if ( flag2 || flag )
                    {
                        num |= 32;
                    }
                }
            }
        }
        return num;
    }

    // Token: 0x06000AFC RID: 2812 RVA: 0x00062EA8 File Offset: 0x000610A8
    private static ushort gmPlayerRemapKeyIPhoneZone32SS( AppMain.GMS_PLAYER_WORK ply_work )
    {
        ushort num = 0;
        if ( AppMain.GmMainKeyCheckPauseKeyPush() != -1 )
        {
            return num;
        }
        for ( int i = 0; i < 4; i++ )
        {
            bool flag = AppMain.amTpIsTouchOn(i);
            bool flag2 = AppMain.amTpIsTouchPush(i);
            if ( AppMain.GmPlayerIsTransformSuperSonic( ply_work ) && flag && AppMain.GMM_PLAYER_IS_TOUCH_SUPER_SONIC_REGION( ( int )AppMain._am_tp_touch[i].on[0], ( int )AppMain._am_tp_touch[i].on[1] ) )
            {
                num |= 80;
            }
            if ( ( num & 80 ) == 0 && ( flag2 || flag ) )
            {
                num |= 32;
            }
            if ( num != 0 )
            {
                break;
            }
        }
        return num;
    }

    // Token: 0x06000AFD RID: 2813 RVA: 0x00062F28 File Offset: 0x00061128
    private static bool gmPlayerIsInputDPadJumpKey( AppMain.GMS_PLAYER_WORK ply_work, int ignore_key )
    {
        int control_type = ply_work.control_type;
        if ( control_type == 2 )
        {
            return false;
        }
        if ( ply_work.jump_rect == null )
        {
            AppMain.mppAssertNotImpl();
            return false;
        }
        bool result = false;
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( i != ignore_key || AppMain.amTpIsTouchPush( i ) ) && AppMain.amTpIsTouchOn( i ) )
            {
                short num = (short)AppMain._am_tp_touch[i].on[0];
                short num2 = (short)AppMain._am_tp_touch[i].on[1];
                if ( ply_work.jump_rect[0] <= ( ushort )num && num <= ( short )ply_work.jump_rect[2] && ply_work.jump_rect[1] <= ( ushort )num2 && num2 <= ( short )ply_work.jump_rect[3] )
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }

    // Token: 0x06000AFE RID: 2814 RVA: 0x00062FC8 File Offset: 0x000611C8
    private static bool gmPlayerIsInputDPadSSonicKey( AppMain.GMS_PLAYER_WORK ply_work, int ignore_key )
    {
        int control_type = ply_work.control_type;
        if ( control_type == 2 )
        {
            return false;
        }
        bool result = false;
        for ( int i = 0; i < 4; i++ )
        {
            if ( ( i != ignore_key || AppMain.amTpIsTouchPush( i ) ) && AppMain.amTpIsTouchOn( i ) )
            {
                short num = (short)AppMain._am_tp_touch[i].on[0];
                short num2 = (short)AppMain._am_tp_touch[i].on[1];
                if ( ply_work.ssonic_rect[0] <= ( ushort )num && num <= ( short )ply_work.ssonic_rect[2] && ply_work.ssonic_rect[1] <= ( ushort )num2 && num2 <= ( short )ply_work.ssonic_rect[3] )
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }

    // Token: 0x06000AFF RID: 2815 RVA: 0x00063058 File Offset: 0x00061258
    private static void gmPlayerCameraOffset( AppMain.GMS_PLAYER_WORK ply_work )
    {
        byte b = 4;
        if ( ply_work.player_id != 0 )
        {
            return;
        }
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            return;
        }
        if ( ply_work.gmk_obj == null )
        {
            ply_work.gmk_flag &= 4227858431U;
            ply_work.gmk_camera_gmk_center_ofst_x = 0;
            ply_work.gmk_camera_gmk_center_ofst_y = 0;
        }
        short num = 0;
        short num2 = 0;
        if ( ( ply_work.player_flag & 8192U ) != 0U )
        {
            ply_work.camera_ofst_x -= ply_work.camera_ofst_x >> 2;
            ply_work.camera_ofst_y -= ply_work.camera_ofst_y >> 2;
        }
        else if ( ( ply_work.gmk_flag & 67108864U ) != 0U )
        {
            ply_work.camera_ofst_x += ply_work.camera_ofst_tag_x - ply_work.camera_ofst_x + ( ( int )( ply_work.gmk_camera_center_ofst_x + ply_work.gmk_camera_gmk_center_ofst_x ) << 12 ) >> ( int )b;
            ply_work.camera_ofst_y += ply_work.camera_ofst_tag_y - ply_work.camera_ofst_y + ( ( int )( ply_work.gmk_camera_center_ofst_y + ply_work.gmk_camera_gmk_center_ofst_y ) << 12 ) >> ( int )b;
        }
        else
        {
            ply_work.camera_ofst_x += ply_work.camera_ofst_tag_x - ply_work.camera_ofst_x + ( ( int )ply_work.gmk_camera_center_ofst_x << 12 ) >> ( int )b;
            ply_work.camera_ofst_y += ply_work.camera_ofst_tag_y - ply_work.camera_ofst_y + ( ( int )ply_work.gmk_camera_center_ofst_y << 12 ) >> ( int )b;
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.ofst.x = AppMain.FXM_FX32_TO_FLOAT( ( ( int )num << 12 ) + ply_work.camera_ofst_x );
        obs_CAMERA.ofst.y = AppMain.FXM_FX32_TO_FLOAT( ( ( int )num2 << 12 ) + ply_work.camera_ofst_y );
    }

    // Token: 0x06000B00 RID: 2816 RVA: 0x000631E0 File Offset: 0x000613E0
    public static void gmGmkPlayerMotionCallbackTruck( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object param )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)param;
        AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
        AppMain.nnMultiplyMatrix( nns_MATRIX2, nns_MATRIX2, AppMain.amMatrixGetCurrent() );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_PLAYER_NODE_ID_TRUCK_CENTER, motion.data, nns_MATRIX2 );
        nns_MATRIX.Assign( gms_PLAYER_WORK.truck_mtx_ply_mtn_pos );
    }
}
