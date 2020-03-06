using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000156 RID: 342
    public class DMS_STFRL_SONIC_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020D0 RID: 8400 RVA: 0x0013FB6C File Offset: 0x0013DD6C
        public DMS_STFRL_SONIC_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x060020D1 RID: 8401 RVA: 0x0013FB80 File Offset: 0x0013DD80
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060020D2 RID: 8402 RVA: 0x0013FB88 File Offset: 0x0013DD88
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.DMS_STFRL_SONIC_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x04004DB1 RID: 19889
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004DB2 RID: 19890
        public short timer;

        // Token: 0x04004DB3 RID: 19891
        public ushort flag;

        // Token: 0x04004DB4 RID: 19892
        public float alpha;

        // Token: 0x04004DB5 RID: 19893
        public float alpha_spd;
    }

    // Token: 0x02000157 RID: 343
    public class DMS_STFRL_BOSS_BODY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020D3 RID: 8403 RVA: 0x0013FB90 File Offset: 0x0013DD90
        public DMS_STFRL_BOSS_BODY_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x060020D4 RID: 8404 RVA: 0x0013FBBA File Offset: 0x0013DDBA
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060020D5 RID: 8405 RVA: 0x0013FBC2 File Offset: 0x0013DDC2
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.DMS_STFRL_BOSS_BODY_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x04004DB6 RID: 19894
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004DB7 RID: 19895
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04004DB8 RID: 19896
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04004DB9 RID: 19897
        public int egg_snm_reg_id;

        // Token: 0x04004DBA RID: 19898
        public int body_snm_reg_id;

        // Token: 0x04004DBB RID: 19899
        public uint flag;

        // Token: 0x04004DBC RID: 19900
        public int timer;
    }

    // Token: 0x02000158 RID: 344
    public class DMS_STFRL_BOSS_EGG_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020D6 RID: 8406 RVA: 0x0013FBCA File Offset: 0x0013DDCA
        public DMS_STFRL_BOSS_EGG_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x060020D7 RID: 8407 RVA: 0x0013FBDE File Offset: 0x0013DDDE
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.DMS_STFRL_BOSS_EGG_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x060020D8 RID: 8408 RVA: 0x0013FBE6 File Offset: 0x0013DDE6
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x04004DBD RID: 19901
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004DBE RID: 19902
        public uint flag;

        // Token: 0x04004DBF RID: 19903
        public int timer;
    }

    // Token: 0x02000159 RID: 345
    public class DMS_STFRL_RING_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020D9 RID: 8409 RVA: 0x0013FBEE File Offset: 0x0013DDEE
        public DMS_STFRL_RING_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x060020DA RID: 8410 RVA: 0x0013FC26 File Offset: 0x0013DE26
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060020DB RID: 8411 RVA: 0x0013FC2E File Offset: 0x0013DE2E
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.DMS_STFRL_RING_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x04004DC0 RID: 19904
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004DC1 RID: 19905
        public AppMain.VecFx32 start_pos;

        // Token: 0x04004DC2 RID: 19906
        public readonly AppMain.VecFx32[] pos = new AppMain.VecFx32[6];

        // Token: 0x04004DC3 RID: 19907
        public AppMain.VecFx32 scale;

        // Token: 0x04004DC4 RID: 19908
        public readonly int[] spd_x = new int[6];

        // Token: 0x04004DC5 RID: 19909
        public readonly int[] spd_y = new int[6];

        // Token: 0x04004DC6 RID: 19910
        public AppMain.DMS_STFRL_RING_WORK._proc_efct_ proc_efct;

        // Token: 0x04004DC7 RID: 19911
        public int efct_start_time;

        // Token: 0x04004DC8 RID: 19912
        public int timer;

        // Token: 0x04004DC9 RID: 19913
        public int efct_timer;

        // Token: 0x04004DCA RID: 19914
        public uint flag;

        // Token: 0x04004DCB RID: 19915
        public float alpha;

        // Token: 0x04004DCC RID: 19916
        public float alpha_spd;

        // Token: 0x04004DCD RID: 19917
        public int disp_ring_pos_no;

        // Token: 0x04004DCE RID: 19918
        public int disp_efct_pos_no;

        // Token: 0x0200015A RID: 346
        // (Invoke) Token: 0x060020DD RID: 8413
        public delegate void _proc_efct_( AppMain.OBS_OBJECT_WORK work );
    }

    // Token: 0x020003D7 RID: 983
    public class DMS_STFRL_FS_DATA_MGR
    {
        // Token: 0x06002857 RID: 10327 RVA: 0x00152BDF File Offset: 0x00150DDF
        public void Clear()
        {
            this.arc_list_font_amb_fs = null;
            this.arc_scr_amb_fs = null;
            this.arc_end_amb_fs = null;
            this.arc_end_jp_amb_fs = null;
            Array.Clear( this.arc_cmn_amb_fs, 0, this.arc_cmn_amb_fs.Length );
            this.staff_list_fs = null;
        }

        // Token: 0x0400624C RID: 25164
        public AppMain.AMS_AMB_HEADER arc_list_font_amb_fs;

        // Token: 0x0400624D RID: 25165
        public AppMain.AMS_AMB_HEADER arc_scr_amb_fs;

        // Token: 0x0400624E RID: 25166
        public AppMain.AMS_AMB_HEADER arc_end_amb_fs;

        // Token: 0x0400624F RID: 25167
        public AppMain.AMS_AMB_HEADER arc_end_jp_amb_fs;

        // Token: 0x04006250 RID: 25168
        public readonly AppMain.AMS_AMB_HEADER[] arc_cmn_amb_fs = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04006251 RID: 25169
        public AppMain.AMS_FS staff_list_fs;
    }

    // Token: 0x020003D8 RID: 984
    public class DMS_STFRL_DATA_MGR
    {
        // Token: 0x06002859 RID: 10329 RVA: 0x00152C2C File Offset: 0x00150E2C
        public void Clear()
        {
            this.arc_font_amb = null;
            this.arc_scr_amb = null;
            this.arc_end_amb = null;
            this.arc_end_jp_amb = null;
            Array.Clear( this.arc_cmn_amb, 0, 2 );
            this.stf_list_ysd = null;
        }

        // Token: 0x04006252 RID: 25170
        public AppMain.AMS_AMB_HEADER arc_font_amb;

        // Token: 0x04006253 RID: 25171
        public AppMain.AMS_AMB_HEADER arc_scr_amb;

        // Token: 0x04006254 RID: 25172
        public AppMain.AMS_AMB_HEADER arc_end_amb;

        // Token: 0x04006255 RID: 25173
        public AppMain.AMS_AMB_HEADER arc_end_jp_amb;

        // Token: 0x04006256 RID: 25174
        public readonly AppMain.AMS_AMB_HEADER[] arc_cmn_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04006257 RID: 25175
        public AppMain.YSDS_HEADER stf_list_ysd;
    }

    // Token: 0x020003D9 RID: 985
    private enum DME_STFRL_ACT
    {
        // Token: 0x04006259 RID: 25177
        ACT_LIGHT_BG_LT,
        // Token: 0x0400625A RID: 25178
        ACT_LIGHT_BG_LB,
        // Token: 0x0400625B RID: 25179
        ACT_LIGHT_BG_RT,
        // Token: 0x0400625C RID: 25180
        ACT_LIGHT_BG_RB,
        // Token: 0x0400625D RID: 25181
        ACT_METAL_SONIC,
        // Token: 0x0400625E RID: 25182
        ACT_M_SONIC_EYE,
        // Token: 0x0400625F RID: 25183
        ACT_BLACK_BG,
        // Token: 0x04006260 RID: 25184
        ACT_WHITE_BG,
        // Token: 0x04006261 RID: 25185
        ACT_TEX_TRYAGAIN,
        // Token: 0x04006262 RID: 25186
        ACT_TEX_CONTINUED,
        // Token: 0x04006263 RID: 25187
        ACT_TEX_WIN_MSG,
        // Token: 0x04006264 RID: 25188
        ACT_NUM,
        // Token: 0x04006265 RID: 25189
        ACT_NONE
    }

    // Token: 0x020003DA RID: 986
    public class DMS_STFRL_MAIN_WORK
    {
        // Token: 0x04006266 RID: 25190
        public readonly AppMain.DMS_STFRL_DATA_MGR arc_data = new AppMain.DMS_STFRL_DATA_MGR();

        // Token: 0x04006267 RID: 25191
        public AppMain.AMS_AMB_HEADER arc_list_font_amb;

        // Token: 0x04006268 RID: 25192
        public AppMain.AMS_AMB_HEADER arc_scr_amb_fs;

        // Token: 0x04006269 RID: 25193
        public AppMain.AMS_AMB_HEADER arc_end_amb_fs;

        // Token: 0x0400626A RID: 25194
        public AppMain.AMS_AMB_HEADER arc_end_jp_amb_fs;

        // Token: 0x0400626B RID: 25195
        public readonly AppMain.AMS_AMB_HEADER[] arc_cmn_amb_fs = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x0400626C RID: 25196
        public AppMain.AMS_FS arc_list_font_amb_fs;

        // Token: 0x0400626D RID: 25197
        public object staff_list_fs;

        // Token: 0x0400626E RID: 25198
        public readonly AppMain.AOS_TEXTURE font_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x0400626F RID: 25199
        public readonly AppMain.AOS_TEXTURE[] scr_tex = AppMain.New<AppMain.AOS_TEXTURE>(3);

        // Token: 0x04006270 RID: 25200
        public AppMain.A2S_AMA_HEADER end_ama;

        // Token: 0x04006271 RID: 25201
        public AppMain.AMS_AMB_HEADER end_amb;

        // Token: 0x04006272 RID: 25202
        public readonly AppMain.AOS_TEXTURE end_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x04006273 RID: 25203
        public AppMain.A2S_AMA_HEADER end_jp_ama;

        // Token: 0x04006274 RID: 25204
        public AppMain.AMS_AMB_HEADER end_jp_amb;

        // Token: 0x04006275 RID: 25205
        public readonly AppMain.AOS_TEXTURE end_jp_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x04006276 RID: 25206
        public readonly AppMain.A2S_AMA_HEADER[] cmn_ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x04006277 RID: 25207
        public readonly AppMain.AMS_AMB_HEADER[] cmn_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04006278 RID: 25208
        public readonly AppMain.AOS_TEXTURE[] cmn_tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x04006279 RID: 25209
        public object stf_list_ysd;

        // Token: 0x0400627A RID: 25210
        public readonly AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[11];

        // Token: 0x0400627B RID: 25211
        public AppMain.DMS_STFRL_MAIN_WORK._proc_input_ proc_input;

        // Token: 0x0400627C RID: 25212
        public AppMain.DMS_STFRL_MAIN_WORK._proc_update_ proc_update;

        // Token: 0x0400627D RID: 25213
        public AppMain.DMS_STFRL_MAIN_WORK._proc_data_load_ proc_data_load;

        // Token: 0x0400627E RID: 25214
        public AppMain.DMS_STFRL_MAIN_WORK._proc_draw_ proc_draw;

        // Token: 0x0400627F RID: 25215
        public float timer;

        // Token: 0x04006280 RID: 25216
        public uint flag;

        // Token: 0x04006281 RID: 25217
        public float efct_timer;

        // Token: 0x04006282 RID: 25218
        public float fade_timer;

        // Token: 0x04006283 RID: 25219
        public float win_timer;

        // Token: 0x04006284 RID: 25220
        public float disp_frm_time;

        // Token: 0x04006285 RID: 25221
        public uint disp_mode;

        // Token: 0x04006286 RID: 25222
        public bool is_eme_comp;

        // Token: 0x04006287 RID: 25223
        public readonly float[] win_size_rate = new float[2];

        // Token: 0x04006288 RID: 25224
        public uint win_mode;

        // Token: 0x04006289 RID: 25225
        public uint announce_flag;

        // Token: 0x0400628A RID: 25226
        public float sonic_set_frame;

        // Token: 0x0400628B RID: 25227
        public float list_disp_pos_x;

        // Token: 0x0400628C RID: 25228
        public AppMain.AOS_ACT_COL list_col;

        // Token: 0x0400628D RID: 25229
        public float sonic_move_spd;

        // Token: 0x0400628E RID: 25230
        public int end_act_frm;

        // Token: 0x0400628F RID: 25231
        public int continue_act_frm;

        // Token: 0x04006290 RID: 25232
        public int load_data_num;

        // Token: 0x04006291 RID: 25233
        public bool is_full_staffroll;

        // Token: 0x04006292 RID: 25234
        public uint draw_state;

        // Token: 0x04006293 RID: 25235
        public uint cur_disp_scr_id;

        // Token: 0x04006294 RID: 25236
        public readonly bool[] data_disp_yet = new bool[3];

        // Token: 0x04006295 RID: 25237
        public readonly bool[] check_file_load = new bool[3];

        // Token: 0x04006296 RID: 25238
        public uint disp_list_page_num;

        // Token: 0x04006297 RID: 25239
        public uint cur_disp_list_page;

        // Token: 0x04006298 RID: 25240
        public uint prev_disp_list_page;

        // Token: 0x04006299 RID: 25241
        public uint disp_page_time;

        // Token: 0x0400629A RID: 25242
        public uint cur_disp_image;

        // Token: 0x0400629B RID: 25243
        public uint[] page_line_type;

        // Token: 0x0400629C RID: 25244
        public uint cur_page_list_alpha_data;

        // Token: 0x0400629D RID: 25245
        public uint cur_page_scr_alpha_data;

        // Token: 0x0400629E RID: 25246
        public AppMain.AOS_ACT_COL question_act_alpha;

        // Token: 0x0400629F RID: 25247
        public AppMain.DMS_STFRL_SONIC_WORK sonic_work;

        // Token: 0x040062A0 RID: 25248
        public AppMain.DMS_STFRL_BOSS_BODY_WORK body_work;

        // Token: 0x040062A1 RID: 25249
        public AppMain.DMS_STFRL_BOSS_EGG_WORK egg_work;

        // Token: 0x040062A2 RID: 25250
        public readonly AppMain.DMS_STFRL_RING_WORK[] ring_work = new AppMain.DMS_STFRL_RING_WORK[3];

        // Token: 0x040062A3 RID: 25251
        public AppMain.GSS_SND_SCB bgm_scb;

        // Token: 0x040062A4 RID: 25252
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x020003DB RID: 987
        // (Invoke) Token: 0x0600285D RID: 10333
        public delegate void _proc_input_( AppMain.DMS_STFRL_MAIN_WORK work );

        // Token: 0x020003DC RID: 988
        // (Invoke) Token: 0x06002861 RID: 10337
        public delegate void _proc_update_( AppMain.DMS_STFRL_MAIN_WORK work );

        // Token: 0x020003DD RID: 989
        // (Invoke) Token: 0x06002865 RID: 10341
        public delegate void _proc_data_load_( AppMain.DMS_STFRL_MAIN_WORK work );

        // Token: 0x020003DE RID: 990
        // (Invoke) Token: 0x06002869 RID: 10345
        public delegate void _proc_draw_( AppMain.DMS_STFRL_MAIN_WORK work );
    }

    // Token: 0x020003DF RID: 991
    public class DMS_STFRL_MGR
    {
        // Token: 0x040062A5 RID: 25253
        public AppMain.MTS_TASK_TCB tcb;
    }

    // Token: 0x06001B7B RID: 7035 RVA: 0x000FB99C File Offset: 0x000F9B9C
    private static void DmStaffRollBuildForGame()
    {
        AppMain.dm_stfrl_fs_data_mgr.Clear();
        AppMain.dm_stfrl_fs_data_mgr_p = AppMain.dm_stfrl_fs_data_mgr;
        int num = AppMain.GsEnvGetLanguage();
        AppMain.dm_stfrl_fs_data_mgr_p.arc_list_font_amb_fs = AppMain.GmGameDatGetGimmickData( 958 );
        AppMain.dm_stfrl_fs_data_mgr_p.arc_scr_amb_fs = AppMain.GmGameDatGetGimmickData( 960 );
        AppMain.dm_stfrl_fs_data_mgr_p.arc_end_amb_fs = AppMain.GmGameDatGetGimmickData( 972 );
        AppMain.dm_stfrl_fs_data_mgr_p.arc_end_jp_amb_fs = AppMain.GmGameDatGetGimmickData( AppMain.dm_stfrl_lng_amb_id_tbl[num] );
        AppMain.dm_stfrl_fs_data_mgr_p.arc_cmn_amb_fs[0] = AppMain.GmGameDatGetGimmickData( 959 );
        AppMain.dm_stfrl_fs_data_mgr_p.arc_cmn_amb_fs[1] = AppMain.GmGameDatGetGimmickData( AppMain.dm_stfrl_cmn_msg_lng_amb_id_tbl[num] );
    }

    // Token: 0x06001B7C RID: 7036 RVA: 0x000FBA48 File Offset: 0x000F9C48
    private static void DmStaffRollBuild( AppMain.DMS_STFRL_DATA_MGR data_mgr )
    {
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        AppMain.dm_stfrl_data_mgr.Clear();
        AppMain.dm_stfrl_data_mgr_p = AppMain.dm_stfrl_data_mgr;
        AppMain.dm_stfrl_data_mgr_p = data_mgr;
        AppMain.dm_stfrl_font_amb = data_mgr.arc_font_amb;
        AppMain.AoTexBuild( AppMain.dm_stfrl_font_tex, AppMain.dm_stfrl_font_amb );
        AppMain.AoTexLoad( AppMain.dm_stfrl_font_tex );
        AppMain.dm_stfrl_scr_amb = data_mgr.arc_scr_amb;
        AppMain.AoTexBuild( AppMain.dm_stfrl_scr_tex, AppMain.dm_stfrl_scr_amb );
        AppMain.AoTexLoad( AppMain.dm_stfrl_scr_tex );
        AppMain.dm_stfrl_end_cmn_ama = AppMain.readAMAFile( AppMain.amBindGet( data_mgr.arc_end_amb, 0 ) );
        string dir;
        AppMain.dm_stfrl_end_cmn_amb = AppMain.readAMBFile( AppMain.amBindGet( data_mgr.arc_end_amb, 1, out dir ) );
        AppMain.dm_stfrl_end_cmn_amb.dir = dir;
        AppMain.dm_stfrl_end_lng_ama = AppMain.readAMAFile( AppMain.amBindGet( data_mgr.arc_end_jp_amb, 0 ) );
        AppMain.dm_stfrl_end_lng_amb = AppMain.readAMBFile( AppMain.amBindGet( data_mgr.arc_end_jp_amb, 1, out dir ) );
        AppMain.dm_stfrl_end_lng_amb.dir = dir;
        AppMain.AoTexBuild( AppMain.dm_stfrl_end_tex, AppMain.dm_stfrl_end_cmn_amb );
        AppMain.AoTexLoad( AppMain.dm_stfrl_end_tex );
        AppMain.AoTexBuild( AppMain.dm_stfrl_end_jp_tex, AppMain.dm_stfrl_end_lng_amb );
        AppMain.AoTexLoad( AppMain.dm_stfrl_end_jp_tex );
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.dm_stfrl_cmn_ama[i] = AppMain.readAMAFile( AppMain.amBindGet( data_mgr.arc_cmn_amb[i], 0 ) );
            AppMain.dm_stfrl_cmn_amb[i] = AppMain.readAMBFile( AppMain.amBindGet( data_mgr.arc_cmn_amb[i], 1, out dir ) );
            AppMain.dm_stfrl_cmn_amb[i].dir = dir;
            AppMain.AoTexBuild( AppMain.dm_stfrl_cmn_tex[i], AppMain.dm_stfrl_cmn_amb[i] );
            AppMain.AoTexLoad( AppMain.dm_stfrl_cmn_tex[i] );
        }
    }

    // Token: 0x06001B7D RID: 7037 RVA: 0x000FBBD4 File Offset: 0x000F9DD4
    private static bool DmStaffRollBuildCheck()
    {
        return AppMain.dmStaffRollIsTexLoad() != 0;
    }

    // Token: 0x06001B7E RID: 7038 RVA: 0x000FBBE0 File Offset: 0x000F9DE0
    private static void DmStaffRollFlush()
    {
        AppMain.AoTexRelease( AppMain.dm_stfrl_font_tex );
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            AppMain.AoTexRelease( AppMain.dm_stfrl_scr_tex );
            AppMain.AoTexRelease( AppMain.dm_stfrl_end_tex );
            AppMain.AoTexRelease( AppMain.dm_stfrl_end_jp_tex );
            for ( int i = 0; i < 2; i++ )
            {
                AppMain.AoTexRelease( AppMain.dm_stfrl_cmn_tex[i] );
            }
        }
    }

    // Token: 0x06001B7F RID: 7039 RVA: 0x000FBC34 File Offset: 0x000F9E34
    private static bool DmStaffRollFlushCheck()
    {
        return AppMain.dmStaffRollIsTexRelease() != 0;
    }

    // Token: 0x06001B80 RID: 7040 RVA: 0x000FBC40 File Offset: 0x000F9E40
    private static void DmStaffRollStart( object arg )
    {
        AppMain.UNREFERENCED_PARAMETER( arg );
        short old_evt_id = AppMain.SyGetEvtInfo().old_evt_id;
        if ( old_evt_id == 9 )
        {
            AppMain.dm_stfrl_is_full_staffroll = true;
        }
        else
        {
            AppMain.dm_stfrl_is_full_staffroll = false;
        }
        if ( AppMain.dm_stfrl_mgr_p == null )
        {
            AppMain.dm_stfrl_mgr_p = AppMain.dm_stfrl_mgr;
        }
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 6 || cur_evt_id == 11 )
        {
            AppMain.dm_stfrl_is_pause_maingame = true;
        }
        else
        {
            AppMain.dm_stfrl_is_pause_maingame = false;
        }
        AppMain.dmStaffRollInit();
    }

    // Token: 0x06001B81 RID: 7041 RVA: 0x000FBCAD File Offset: 0x000F9EAD
    private static bool DmStaffRollIsExit()
    {
        return AppMain.dm_stfrl_mgr_p == null || AppMain.dm_stfrl_mgr_p.tcb == null;
    }

    // Token: 0x06001B82 RID: 7042 RVA: 0x000FBCC7 File Offset: 0x000F9EC7
    private static void DmStaffRollExit()
    {
        if ( AppMain.dm_stfrl_mgr_p.tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.dm_stfrl_mgr_p.tcb );
            AppMain.dm_stfrl_mgr_p.tcb = null;
        }
    }

    // Token: 0x06001B83 RID: 7043 RVA: 0x000FBCF8 File Offset: 0x000F9EF8
    private static void dmStaffRollInit()
    {
        AppMain.dm_stfrl_mgr_p.tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.dmStaffRollProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.dmStaffRollDest ), 0U, 32767, 12288U, 10, () => new AppMain.DMS_STFRL_MAIN_WORK(), "STAFFROLL_MAIN" );
        AppMain.DMS_STFRL_MAIN_WORK dms_STFRL_MAIN_WORK = (AppMain.DMS_STFRL_MAIN_WORK)AppMain.dm_stfrl_mgr_p.tcb.work;
        AppMain.AoActSysSetDrawStateEnable( true );
        AppMain.AoActSysSetDrawState( AppMain.AoActSysGetDrawState() );
        AppMain.dmStaffRollSetInitData( dms_STFRL_MAIN_WORK );
        dms_STFRL_MAIN_WORK.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcInit );
    }

    // Token: 0x06001B84 RID: 7044 RVA: 0x000FBD98 File Offset: 0x000F9F98
    private static void dmStaffRollSetInitData( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        main_work.disp_mode = 0U;
        main_work.disp_frm_time = 1f;
        main_work.question_act_alpha.r = byte.MaxValue;
        main_work.question_act_alpha.g = byte.MaxValue;
        main_work.question_act_alpha.b = byte.MaxValue;
        main_work.question_act_alpha.a = 0;
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 32U ) != 0U )
        {
            main_work.is_eme_comp = true;
            return;
        }
        main_work.is_eme_comp = false;
    }

    // Token: 0x06001B85 RID: 7045 RVA: 0x000FBE14 File Offset: 0x000FA014
    private static void dmStaffRollProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_STFRL_MAIN_WORK dms_STFRL_MAIN_WORK = (AppMain.DMS_STFRL_MAIN_WORK)tcb.work;
        if ( ( dms_STFRL_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.DmStaffRollExit();
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                AppMain.dmStaffRollSetNextEvt( dms_STFRL_MAIN_WORK );
            }
            return;
        }
        if ( ( dms_STFRL_MAIN_WORK.flag & 2147483648U ) != 0U && !AppMain.AoAccountIsCurrentEnable() )
        {
            dms_STFRL_MAIN_WORK.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
            dms_STFRL_MAIN_WORK.flag &= 2147483647U;
            dms_STFRL_MAIN_WORK.flag |= 1073741824U;
            if ( AppMain.dm_stfrl_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 1U, 1U, 80f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 1U, 1U, 64f );
            }
            if ( dms_STFRL_MAIN_WORK.bgm_scb != null )
            {
                AppMain.GsSoundStopBgm( dms_STFRL_MAIN_WORK.bgm_scb, 79 );
            }
            dms_STFRL_MAIN_WORK.flag &= 4294967291U;
            dms_STFRL_MAIN_WORK.flag &= 4294967293U;
            dms_STFRL_MAIN_WORK.proc_input = null;
            dms_STFRL_MAIN_WORK.win_timer = 0f;
            dms_STFRL_MAIN_WORK.win_mode = 0U;
        }
        if ( dms_STFRL_MAIN_WORK.proc_update != null )
        {
            dms_STFRL_MAIN_WORK.proc_update( dms_STFRL_MAIN_WORK );
        }
        if ( dms_STFRL_MAIN_WORK.proc_draw != null )
        {
            dms_STFRL_MAIN_WORK.proc_draw( dms_STFRL_MAIN_WORK );
        }
    }

    // Token: 0x06001B86 RID: 7046 RVA: 0x000FBF3E File Offset: 0x000FA13E
    private static void dmStaffRollDest( AppMain.MTS_TASK_TCB tcb )
    {
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            AppMain.ObjDrawESEffectSystemExit();
            AppMain.ObjCameraExit();
            AppMain.GmMainExitForStaffroll();
        }
    }

    // Token: 0x06001B87 RID: 7047 RVA: 0x000FBF58 File Offset: 0x000FA158
    private static void dmStaffRollSetNextEvt( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        short num;
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            num = 0;
            if ( ( main_work.flag & 1073741824U ) != 0U )
            {
                num = 1;
            }
            AppMain.SyDecideEvtCase( num );
            return;
        }
        num = AppMain.SyGetEvtInfo().old_evt_id;
        if ( ( main_work.flag & 1073741824U ) != 0U )
        {
            num = 1;
        }
        AppMain.SyDecideEvt( num );
    }

    // Token: 0x06001B88 RID: 7048 RVA: 0x000FBFA8 File Offset: 0x000FA1A8
    private static void dmStaffRollProcInit( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcLoadData );
            AppMain.DmStaffRollBuildForGame();
            main_work.arc_list_font_amb = AppMain.readAMBFile( AppMain.dm_stfrl_fs_data_mgr_p.arc_list_font_amb_fs );
            main_work.arc_scr_amb_fs = AppMain.readAMBFile( AppMain.dm_stfrl_fs_data_mgr_p.arc_scr_amb_fs );
            main_work.arc_end_amb_fs = AppMain.readAMBFile( AppMain.dm_stfrl_fs_data_mgr_p.arc_end_amb_fs );
            main_work.arc_end_jp_amb_fs = AppMain.readAMBFile( AppMain.dm_stfrl_fs_data_mgr_p.arc_end_jp_amb_fs );
            main_work.arc_cmn_amb_fs[0] = AppMain.readAMBFile( AppMain.dm_stfrl_fs_data_mgr_p.arc_cmn_amb_fs[0] );
            main_work.arc_cmn_amb_fs[1] = AppMain.readAMBFile( AppMain.dm_stfrl_fs_data_mgr_p.arc_cmn_amb_fs[1] );
            main_work.staff_list_fs = AppMain.amFsRead( "DEMO/STFRL/STAFF_LIST.YSD" );
        }
        else
        {
            main_work.arc_list_font_amb_fs = AppMain.amFsReadBackground( "DEMO/STFRL/D_STFRL_FONT.AMB" );
            main_work.staff_list_fs = AppMain.amFsRead( "DEMO/STFRL/STAFF_LIST.YSD" );
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcLoadData );
        }
        AppMain.GsMainSysSetSleepFlag( false );
    }

    // Token: 0x06001B89 RID: 7049 RVA: 0x000FC0A8 File Offset: 0x000FA2A8
    private static void dmStaffRollProcLoadData( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.dmStaffRollIsDataLoad( main_work ) != 0 )
        {
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                AppMain.dmStaffRollDataClearRequestFull( main_work );
                AppMain.DmStaffRollBuild( main_work.arc_data );
            }
            else
            {
                AppMain.dmStaffRollDataClearRequestEasy( main_work );
                AppMain.dmStaffRollDataBuildEasy( main_work );
            }
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcDataBuild );
        }
    }

    // Token: 0x06001B8A RID: 7050 RVA: 0x000FC0F8 File Offset: 0x000FA2F8
    private static void dmStaffRollProcDataBuild( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.DmStaffRollBuildCheck() )
        {
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                AppMain.dmStaffRollSetObjSystemData( main_work );
                main_work.ring_work[0] = AppMain.DmStfrlMdlCtrlSetRingObj( 0, 0U );
                main_work.ring_work[1] = AppMain.DmStfrlMdlCtrlSetRingObj( 20, 3U );
                main_work.ring_work[2] = AppMain.DmStfrlMdlCtrlSetRingObj( 40, 6U );
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcCreateAct );
            }
            else
            {
                main_work.flag |= 2147483648U;
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeIn );
                main_work.proc_draw = new AppMain.DMS_STFRL_MAIN_WORK._proc_draw_( AppMain.dmStaffRollProcActDraw );
                AppMain.IzFadeInitEasy( 0U, 0U, 64f );
            }
            if ( !AppMain.AoYsdFileIsYsdFile( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd ) )
            {
                AppMain.MTM_ASSERT( 0 );
            }
            main_work.disp_list_page_num = AppMain.AoYsdFileGetPageNum( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd );
            main_work.bgm_scb = AppMain.GsSoundAssignScb( 0 );
            main_work.bgm_scb.flag |= 2147483648U;
            main_work.se_handle = AppMain.GsSoundAllocSeHandle();
            if ( !AppMain.GsSoundIsRunning() )
            {
                AppMain.GsSoundBegin( 4096, 1U, 3 );
                main_work.flag |= 2048U;
            }
        }
    }

    // Token: 0x06001B8B RID: 7051 RVA: 0x000FC220 File Offset: 0x000FA420
    private static void dmStaffRollProcCreateAct( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 11U; num += 1U )
        {
            AppMain.A2S_AMA_HEADER ama;
            AppMain.AOS_TEXTURE tex;
            if ( num >= 8U )
            {
                ama = AppMain.dm_stfrl_end_lng_ama;
                tex = AppMain.dm_stfrl_end_jp_tex;
            }
            else
            {
                ama = AppMain.dm_stfrl_end_cmn_ama;
                tex = AppMain.dm_stfrl_end_tex;
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_staff[( int )( ( UIntPtr )num )] );
        }
        main_work.flag |= 2147483648U;
        main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeIn );
        main_work.proc_draw = new AppMain.DMS_STFRL_MAIN_WORK._proc_draw_( AppMain.dmStaffRollProcActDraw );
        AppMain.IzFadeInitEasy( 0U, 0U, 64f );
    }

    // Token: 0x06001B8C RID: 7052 RVA: 0x000FC2C0 File Offset: 0x000FA4C0
    private static void dmStaffRollProcFadeIn( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcNowStaffRoll );
            AppMain.dmStaffRollSetFadePageInfoEfctData( main_work );
            main_work.timer = 32f;
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                AppMain.GsSoundPlayBgm( main_work.bgm_scb, "snd_sng_ending", 0 );
            }
            else
            {
                AppMain.GsSoundPlayBgm( main_work.bgm_scb, "snd_sng_z1a1", 0 );
            }
            main_work.proc_input = new AppMain.DMS_STFRL_MAIN_WORK._proc_input_( AppMain.dmStaffRollInputProcStaffRollMain );
        }
    }

    // Token: 0x06001B8D RID: 7053 RVA: 0x000FC33C File Offset: 0x000FA53C
    private static void dmStaffRollProcDispWaitStaffList( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( ( main_work.flag & 4U ) != 0U )
        {
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcModeFadeOut );
            }
            else
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
            }
            if ( AppMain.dm_stfrl_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 80f, true );
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 1U, 80f );
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            }
            main_work.flag &= 4294967291U;
            return;
        }
        if ( main_work.timer <= 0f )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcNowStaffRoll );
            main_work.timer = 0f;
        }
        main_work.timer -= main_work.disp_frm_time;
    }

    // Token: 0x06001B8E RID: 7054 RVA: 0x000FC430 File Offset: 0x000FA630
    private static void dmStaffRollProcNowStaffRoll( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( ( main_work.flag & 4U ) != 0U )
        {
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcModeFadeOut );
            }
            else
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
            }
            if ( AppMain.dm_stfrl_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 80f, true );
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 1U, 80f );
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            }
            main_work.flag &= 4294967291U;
            return;
        }
        if ( main_work.fade_timer <= 0f )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcSetChangeData );
            main_work.fade_timer = 0f;
            return;
        }
        AppMain.dmStaffRollSetEfctChngAlphaListData( main_work );
        main_work.fade_timer -= main_work.disp_frm_time;
    }

    // Token: 0x06001B8F RID: 7055 RVA: 0x000FC528 File Offset: 0x000FA728
    private static void dmStaffRollProcSetChangeData( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( ( main_work.flag & 4U ) != 0U )
        {
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcModeFadeOut );
            }
            else
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
            }
            if ( AppMain.dm_stfrl_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 80f, true );
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 1U, 80f );
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            }
            main_work.flag &= 4294967291U;
            return;
        }
        main_work.cur_disp_list_page += 1U;
        if ( main_work.cur_disp_list_page <= main_work.disp_list_page_num - 1U )
        {
            AppMain.dmStaffRollSetFadePageInfoEfctData( main_work );
            main_work.timer = 32f;
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcDispWaitStaffList );
            AppMain.UNREFERENCED_PARAMETER( main_work );
            return;
        }
        main_work.cur_disp_list_page = main_work.disp_list_page_num - 1U;
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcModeFadeOut );
        }
        else
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
        }
        if ( AppMain.dm_stfrl_is_pause_maingame )
        {
            AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 80f, true );
            AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
            return;
        }
        AppMain.IzFadeInitEasy( 0U, 1U, 80f );
        AppMain.GsSoundStopBgm( main_work.bgm_scb, 80 );
    }

    // Token: 0x06001B90 RID: 7056 RVA: 0x000FC6AC File Offset: 0x000FA8AC
    private static void dmStaffRollProcModeFadeOut( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcModeFadeIn );
            main_work.disp_mode = 1U;
            if ( AppMain.dm_stfrl_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 0U, 80f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 0U, 80f );
            }
            AppMain.dmStaffRollSetupEndModel( main_work );
        }
    }

    // Token: 0x06001B91 RID: 7057 RVA: 0x000FC710 File Offset: 0x000FA910
    private static void dmStaffRollProcModeFadeIn( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcEndModeIdle );
            main_work.proc_input = new AppMain.DMS_STFRL_MAIN_WORK._proc_input_( AppMain.dmStaffRollInputProcWin );
            main_work.timer = 32f;
            main_work.flag |= 128U;
        }
    }

    // Token: 0x06001B92 RID: 7058 RVA: 0x000FC76C File Offset: 0x000FA96C
    private static void dmStaffRollProcEndModeIdle( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 256U ) != 0U && main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( ( main_work.flag & 4U ) == 0U )
        {
            if ( main_work.is_eme_comp )
            {
                if ( ( main_work.body_work.flag & 8U ) != 0U )
                {
                    main_work.question_act_alpha.a = ( byte )( main_work.question_act_alpha.a + 8 );
                    if ( main_work.question_act_alpha.a > 247 )
                    {
                        main_work.question_act_alpha.a = byte.MaxValue;
                        main_work.body_work.flag &= 4294967287U;
                    }
                }
                if ( ( main_work.body_work.flag & 16U ) != 0U )
                {
                    main_work.end_act_frm++;
                }
                if ( main_work.end_act_frm > 240 )
                {
                    main_work.flag |= 4096U;
                }
            }
            else
            {
                main_work.end_act_frm = 0;
            }
            if ( main_work.end_act_frm == 140 )
            {
                AppMain.GsSoundPlaySe( "Metal_Sonic", main_work.se_handle );
            }
            if ( main_work.sonic_work != null && main_work.body_work != null && ( main_work.sonic_work.flag & 1 ) != 0 )
            {
                main_work.body_work.flag |= 2U;
                ushort num = 1;
                AppMain.DMS_STFRL_SONIC_WORK sonic_work = main_work.sonic_work;
                sonic_work.flag &= ( ushort )~num;
            }
            if ( ( main_work.flag & 128U ) != 0U )
            {
                main_work.timer -= main_work.disp_frm_time;
                if ( main_work.timer <= 0f )
                {
                    main_work.flag &= 4294967167U;
                    main_work.flag |= 256U;
                    main_work.timer = 0f;
                }
            }
            return;
        }
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWinModeFadeOut );
            main_work.proc_input = null;
        }
        else
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
            main_work.proc_input = null;
        }
        main_work.flag &= 4294967291U;
        if ( AppMain.dm_stfrl_is_pause_maingame )
        {
            AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 80f, true );
            return;
        }
        AppMain.IzFadeInitEasy( 0U, 1U, 80f );
    }

    // Token: 0x06001B93 RID: 7059 RVA: 0x000FC98C File Offset: 0x000FAB8C
    private static void dmStaffRollProcWinModeFadeOut( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.dmStaffRollNodispEndModel( main_work );
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWinModeFadeIn );
            main_work.disp_mode = 2U;
            AppMain.IzFadeInitEasy( 0U, 0U, 80f );
            AppMain.GsSoundStopBgm( main_work.bgm_scb, 0 );
        }
    }

    // Token: 0x06001B94 RID: 7060 RVA: 0x000FC9CC File Offset: 0x000FABCC
    private static void dmStaffRollProcWinModeFadeIn( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWindowNodispIdle );
            if ( ( AppMain.g_gs_main_sys_info.game_flag & 32U ) == 0U )
            {
                main_work.announce_flag |= 1U;
            }
        }
    }

    // Token: 0x06001B95 RID: 7061 RVA: 0x000FCA0C File Offset: 0x000FAC0C
    private static void dmStaffRollProcWindowNodispIdle( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.announce_flag != 0U )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWindowOpenEfct );
            main_work.proc_input = null;
            main_work.win_timer = 0f;
            for ( int i = 0; i < 1; i++ )
            {
                if ( ( main_work.announce_flag & 1U << i ) != 0U )
                {
                    main_work.win_mode = ( uint )i;
                    break;
                }
            }
            main_work.flag |= 1024U;
            AppMain.GsSoundPlaySe( "Window", main_work.se_handle );
            return;
        }
        main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcTrophyCheck );
    }

    // Token: 0x06001B96 RID: 7062 RVA: 0x000FCAA0 File Offset: 0x000FACA0
    private static void dmStaffRollProcWindowOpenEfct( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 512U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWindowAnnounceIdle );
            main_work.proc_input = new AppMain.DMS_STFRL_MAIN_WORK._proc_input_( AppMain.dmStaffRollInputProcWin );
            main_work.flag |= 64U;
            main_work.flag &= 4294966783U;
            return;
        }
        AppMain.dmStaffRollSetWinOpenEfct( main_work );
    }

    // Token: 0x06001B97 RID: 7063 RVA: 0x000FCB08 File Offset: 0x000FAD08
    private static void dmStaffRollProcWindowAnnounceIdle( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( main_work.win_mode == 0U && ( main_work.flag & 4U ) != 0U )
        {
            main_work.proc_input = null;
            main_work.win_timer = 8f;
            main_work.flag &= 4294967231U;
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWindowCloseEfct );
            AppMain.GsSoundPlaySe( "Ok", main_work.se_handle );
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
        }
    }

    // Token: 0x06001B98 RID: 7064 RVA: 0x000FCB9C File Offset: 0x000FAD9C
    private static void dmStaffRollProcWindowCloseEfct( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 512U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcWindowNodispIdle );
            main_work.announce_flag &= ~( 1U << ( int )main_work.win_mode );
            main_work.flag &= 4294966271U;
            main_work.flag &= 4294966783U;
        }
        AppMain.dmStaffRollSetWinCloseEfct( main_work );
    }

    // Token: 0x06001B99 RID: 7065 RVA: 0x000FCC0C File Offset: 0x000FAE0C
    private static void dmStaffRollProcTrophyCheck( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFadeOut );
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            AppMain.HgTrophyTryAcquisition( 3 );
        }
        AppMain.IzFadeInitEasy( 0U, 1U, 80f );
    }

    // Token: 0x06001B9A RID: 7066 RVA: 0x000FCC3C File Offset: 0x000FAE3C
    private static void dmStaffRollProcFadeOut( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            if ( ( main_work.flag & 2048U ) != 0U )
            {
                AppMain.GsSoundHalt();
                AppMain.GsSoundEnd();
            }
            if ( main_work.bgm_scb != null )
            {
                AppMain.GsSoundStopBgm( main_work.bgm_scb, 0 );
                AppMain.GsSoundResignScb( main_work.bgm_scb );
                main_work.bgm_scb = null;
            }
            if ( main_work.se_handle != null )
            {
                AppMain.GsSoundFreeSeHandle( main_work.se_handle );
                main_work.se_handle = null;
            }
            main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcStopDraw );
            main_work.proc_draw = null;
        }
    }

    // Token: 0x06001B9B RID: 7067 RVA: 0x000FCCC4 File Offset: 0x000FAEC4
    private static void dmStaffRollProcStopDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 11; i++ )
        {
            if ( main_work.act[i] != null )
            {
                AppMain.AoActDelete( main_work.act[i] );
                main_work.act[i] = null;
            }
        }
        main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcDataRelease );
    }

    // Token: 0x06001B9C RID: 7068 RVA: 0x000FCD10 File Offset: 0x000FAF10
    private static void dmStaffRollProcDataRelease( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.DmStaffRollFlush();
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            AppMain.ObjObjectClearAllObject();
            AppMain.ObjPreExit();
        }
        main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcFinish );
    }

    // Token: 0x06001B9D RID: 7069 RVA: 0x000FCD3C File Offset: 0x000FAF3C
    private static void dmStaffRollProcFinish( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.DmStaffRollFlushCheck() )
        {
            for ( int i = 0; i < 11; i++ )
            {
                if ( main_work.act[i] != null )
                {
                    AppMain.AoActDelete( main_work.act[i] );
                    main_work.act[i] = null;
                }
            }
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                if ( AppMain.dm_stfrl_data_mgr_p.arc_font_amb != null )
                {
                    AppMain.dm_stfrl_data_mgr_p.arc_font_amb = null;
                }
                if ( AppMain.dm_stfrl_data_mgr_p.arc_scr_amb != null )
                {
                    AppMain.dm_stfrl_data_mgr_p.arc_scr_amb = null;
                }
                if ( AppMain.dm_stfrl_data_mgr_p.arc_end_amb != null )
                {
                    AppMain.dm_stfrl_data_mgr_p.arc_end_amb = null;
                }
                if ( AppMain.dm_stfrl_data_mgr_p.arc_end_jp_amb != null )
                {
                    AppMain.dm_stfrl_data_mgr_p.arc_end_jp_amb = null;
                }
                for ( int j = 0; j < 2; j++ )
                {
                    if ( AppMain.dm_stfrl_data_mgr_p.arc_cmn_amb[j] != null )
                    {
                        AppMain.dm_stfrl_data_mgr_p.arc_cmn_amb[j] = null;
                    }
                }
            }
            else if ( AppMain.dm_stfrl_font_amb != null )
            {
                AppMain.dm_stfrl_font_amb = null;
            }
            if ( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd != null )
            {
                AppMain.dm_stfrl_data_mgr_p.stf_list_ysd = null;
            }
            if ( main_work.page_line_type != null )
            {
                main_work.page_line_type = null;
            }
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                main_work.proc_update = new AppMain.DMS_STFRL_MAIN_WORK._proc_update_( AppMain.dmStaffRollProcSaveEndCheck );
                AppMain.DmSaveMenuStart( true, false );
            }
            else
            {
                main_work.flag |= 1U;
                main_work.proc_update = null;
            }
        }
        AppMain.GsMainSysSetSleepFlag( true );
    }

    // Token: 0x06001B9E RID: 7070 RVA: 0x000FCE7F File Offset: 0x000FB07F
    private static void dmStaffRollProcSaveEndCheck( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            main_work.flag |= 1U;
            main_work.proc_update = null;
            if ( ( main_work.flag & 2048U ) != 0U )
            {
                AppMain.GsSoundReset();
            }
            AppMain.GsFontRelease();
        }
    }

    // Token: 0x06001B9F RID: 7071 RVA: 0x000FCEB5 File Offset: 0x000FB0B5
    private static void dmStaffRollInputProcStaffRollMain( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            main_work.flag |= 4U;
            AppMain.setBackKeyRequest( false );
        }
    }

    // Token: 0x06001BA0 RID: 7072 RVA: 0x000FCEDA File Offset: 0x000FB0DA
    private static void dmStaffRollInputProcWin( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            main_work.flag |= 4U;
            AppMain.setBackKeyRequest( false );
        }
    }

    // Token: 0x06001BA1 RID: 7073 RVA: 0x000FCF00 File Offset: 0x000FB100
    private static void dmStaffRollProcActDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.dmStaffRollBGDraw( main_work );
        if ( main_work.disp_mode == 0U )
        {
            AppMain.dmStaffRollStaffListDraw( main_work );
            if ( AppMain.dm_stfrl_is_full_staffroll )
            {
                AppMain.dmStaffRollStageScrDraw( main_work );
            }
        }
        else if ( main_work.disp_mode == 1U && AppMain.dm_stfrl_is_full_staffroll )
        {
            AppMain.dmStaffRollEndActDraw( main_work );
        }
        if ( ( main_work.flag & 1024U ) != 0U && AppMain.dm_stfrl_is_full_staffroll )
        {
            AppMain.dmStaffRollWinActDraw( main_work );
        }
    }

    // Token: 0x06001BA2 RID: 7074 RVA: 0x000FCF64 File Offset: 0x000FB164
    private static void dmStaffRollBGDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.UNREFERENCED_PARAMETER( main_work );
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.mtx = null;
        ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = AppMain.amDrawAlloc_NNS_PRIM3D_PC( 4 );
        AppMain.NNS_PRIM3D_PC[] vtxPC3D = ams_PARAM_DRAW_PRIMITIVE.vtxPC3D;
        vtxPC3D[0].Pos.x = ( vtxPC3D[1].Pos.x = -160f );
        vtxPC3D[2].Pos.x = ( vtxPC3D[3].Pos.x = vtxPC3D[0].Pos.x + 1280f );
        vtxPC3D[0].Pos.y = ( vtxPC3D[2].Pos.y = 0f );
        vtxPC3D[1].Pos.y = ( vtxPC3D[3].Pos.y = 720f );
        vtxPC3D[0].Pos.z = ( vtxPC3D[1].Pos.z = ( vtxPC3D[2].Pos.z = ( vtxPC3D[3].Pos.z = -2f ) ) );
        vtxPC3D[0].Col = ( vtxPC3D[1].Col = ( vtxPC3D[2].Col = ( vtxPC3D[3].Col = AppMain.AMD_RGBA8888( 0, 0, 0, byte.MaxValue ) ) ) );
        ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
        ams_PARAM_DRAW_PRIMITIVE.type = 1;
        ams_PARAM_DRAW_PRIMITIVE.count = 4;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
        AppMain.amDrawGetPrimBlendParam( 0, ams_PARAM_DRAW_PRIMITIVE );
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 0;
        AppMain.AoActDrawCorWide( vtxPC3D, 0, 4U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE );
        AppMain.amDrawPrimitive3D( 40U, ams_PARAM_DRAW_PRIMITIVE );
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmStaffRollTaskBgDraw ), 2048, 0U );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x06001BA3 RID: 7075 RVA: 0x000FD15F File Offset: 0x000FB35F
    private static void dmStaffRollTaskBgDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 40U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06001BA4 RID: 7076 RVA: 0x000FD178 File Offset: 0x000FB378
    private static void dmStaffRollStageScrDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.mtx = null;
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.dmStaffRollStageScrDraw_DrawArray;
        AppMain.NNS_PRIM3D_PCT[] buffer = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
        int offset = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
        buffer[offset].Pos.x = ( buffer[offset + 1].Pos.x = 160f );
        buffer[offset + 2].Pos.x = ( buffer[offset + 3].Pos.x = 672f );
        buffer[offset].Pos.y = ( buffer[offset + 2].Pos.y = 216f );
        buffer[offset + 1].Pos.y = ( buffer[offset + 3].Pos.y = 504f );
        buffer[offset].Pos.z = ( buffer[offset + 1].Pos.z = ( buffer[offset + 2].Pos.z = ( buffer[offset + 3].Pos.z = -2f ) ) );
        buffer[offset].Col = ( buffer[offset + 1].Col = ( buffer[2].Col = ( buffer[3].Col = AppMain.AMD_RGBA8888( byte.MaxValue, byte.MaxValue, byte.MaxValue, ( byte )main_work.cur_page_scr_alpha_data ) ) ) );
        buffer[offset].Tex.u = ( buffer[offset + 1].Tex.u = 0f );
        buffer[offset + 2].Tex.u = ( buffer[offset + 3].Tex.u = 1f );
        buffer[offset].Tex.v = ( buffer[offset + 2].Tex.v = 0f );
        buffer[offset + 1].Tex.v = ( buffer[offset + 3].Tex.v = 0.5625f );
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        ams_PARAM_DRAW_PRIMITIVE.type = 1;
        ams_PARAM_DRAW_PRIMITIVE.count = 4;
        ams_PARAM_DRAW_PRIMITIVE.texlist = AppMain.AoTexGetTexList( AppMain.dm_stfrl_scr_tex );
        ams_PARAM_DRAW_PRIMITIVE.texId = ( int )main_work.cur_disp_image;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
        ams_PARAM_DRAW_PRIMITIVE.zOffset = -1f;
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 0;
        AppMain.AoActDrawCorWide( AppMain.dmStaffRollStageScrDraw_DrawArray, 0, 4U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT );
        AppMain.amDrawPrimitive3D( 30U, ams_PARAM_DRAW_PRIMITIVE );
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmStaffRollStageScrTaskDraw ), 2304, null );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x06001BA5 RID: 7077 RVA: 0x000FD46F File Offset: 0x000FB66F
    private static void dmStaffRollStageScrTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 30U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06001BA6 RID: 7078 RVA: 0x000FD488 File Offset: 0x000FB688
    private static void dmStaffRollStaffListDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        uint num = 0U;
        uint num2 = AppMain.AoYsdFileGetLineNum(AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page);
        main_work.page_line_type = new uint[num2];
        for ( uint num3 = 0U; num3 < num2; num3 += 1U )
        {
            main_work.page_line_type[( int )( ( UIntPtr )num3 )] = AppMain.AoYsdFileGetLineId( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page, num3 );
            num += AppMain.dm_stfrl_list_id_font_height_tbl[( int )( ( UIntPtr )main_work.page_line_type[( int )( ( UIntPtr )num3 )] )];
        }
        uint num4 = num / 2U;
        uint num5 = (uint)(360f - num4);
        for ( uint num6 = 0U; num6 < num2; num6 += 1U )
        {
            AppMain.dmStaffRollStaffListOneLineDraw( main_work, ( uint )( num5 * 0.9f * 0.9f + 5f + 32f ), num6 );
            num5 += AppMain.dm_stfrl_list_id_font_height_tbl[( int )( ( UIntPtr )main_work.page_line_type[( int )( ( UIntPtr )num6 )] )];
        }
        main_work.page_line_type = null;
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmStaffRollTaskDraw ), 2560, 0U );
    }

    // Token: 0x06001BA7 RID: 7079 RVA: 0x000FD57C File Offset: 0x000FB77C
    public static void dmStaffRollStaffListOneLineDraw( AppMain.DMS_STFRL_MAIN_WORK main_work, uint disp_pos_y, uint cur_line )
    {
        int i = 0;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        uint num = 0U;
        uint[] array = new uint[3];
        uint[] array2 = array;
        float num3;
        if ( AppMain.dm_stfrl_is_full_staffroll && main_work.cur_disp_list_page != main_work.disp_list_page_num - 1U )
        {
            uint num2 = AppMain.AoYsdFileGetPageOption(AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page);
            if ( ( 1U & num2 ) != 0U )
            {
                num3 = 0f;
            }
            else
            {
                num3 = 112f;
            }
        }
        else
        {
            num3 = 0f;
        }
        uint num4 = AppMain.AoYsdFileGetLineId(AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page, cur_line);
        uint num5;
        uint num6;
        int j;
        if ( num4 >= 4U && num4 <= 6U )
        {
            num = AppMain.dm_stfrl_list_logo_width_tbl[( int )( ( UIntPtr )num4 )];
            num5 = num / 2U;
            num6 = ( uint )( 480f - num5 + num3 );
            for ( j = 0; j < 3; j++ )
            {
                array2[j] = 255U;
            }
            int texId;
            if ( num4 == 6U )
            {
                if ( AppMain.GsEnvGetRegion() == AppMain.GSE_REGION.GSD_REGION_JP )
                {
                    texId = 3;
                }
                else
                {
                    texId = 4;
                }
            }
            else if ( num4 == 5U )
            {
                texId = 2;
            }
            else
            {
                texId = ( int )( num4 - 4U + 1U );
            }
            ams_PARAM_DRAW_PRIMITIVE.mtx = null;
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( 4 );
            AppMain.NNS_PRIM3D_PCT[] buffer = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
            int offset = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
            buffer[offset].Pos.x = ( buffer[offset + 1].Pos.x = num6 );
            buffer[offset + 2].Pos.x = ( buffer[offset + 3].Pos.x = num6 + num );
            buffer[offset].Pos.y = ( buffer[offset + 2].Pos.y = disp_pos_y );
            buffer[offset + 1].Pos.y = ( buffer[offset + 3].Pos.y = disp_pos_y + AppMain.dm_stfrl_list_id_font_height_tbl[( int )( ( UIntPtr )num4 )] );
            buffer[offset].Pos.z = ( buffer[offset + 1].Pos.z = ( buffer[offset + 2].Pos.z = ( buffer[offset + 3].Pos.z = -2f ) ) );
            buffer[offset].Col = ( buffer[offset + 1].Col = ( buffer[offset + 2].Col = ( buffer[offset + 3].Col = AppMain.AMD_RGBA8888( ( byte )array2[0], ( byte )array2[1], ( byte )array2[2], ( byte )main_work.cur_page_list_alpha_data ) ) ) );
            buffer[offset].Tex.u = ( buffer[offset + 1].Tex.u = 0f );
            buffer[offset + 2].Tex.u = ( buffer[offset + 3].Tex.u = 1f );
            buffer[offset].Tex.v = ( buffer[offset + 2].Tex.v = 0f );
            buffer[offset + 1].Tex.v = ( buffer[offset + 3].Tex.v = AppMain.dm_stfrl_list_id_font_height_tbl[( int )( ( UIntPtr )num4 )] / 128f );
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 1;
            ams_PARAM_DRAW_PRIMITIVE.count = 4;
            ams_PARAM_DRAW_PRIMITIVE.texlist = AppMain.AoTexGetTexList( AppMain.dm_stfrl_font_tex );
            ams_PARAM_DRAW_PRIMITIVE.texId = texId;
            ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
            ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
            ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
            ams_PARAM_DRAW_PRIMITIVE.zTest = 0;
            AppMain.AoActDrawCorWide( ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D, 0, 4U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
            AppMain.amDrawPrimitive3D( 20U, ams_PARAM_DRAW_PRIMITIVE );
            AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
            return;
        }
        int num7 = 0;
        float num8 = 32f * AppMain.dm_stfrl_list_id_font_size_tbl[(int)((UIntPtr)num4)];
        for ( j = 0; j < 3; j++ )
        {
            array2[j] = AppMain.dm_stfrl_list_id_font_color_tbl[( int )( ( UIntPtr )num4 )][j];
        }
        string text = AppMain.AoYsdFileGetLineString(AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page, cur_line);
        j = 0;
        int length = text.Length;
        while ( j < length )
        {
            uint num9 = (uint)text[j];
            float num10 = (float)AppMain.dm_stfrl_font_width_length_tbl[(int)((UIntPtr)num9)] * AppMain.dm_stfrl_list_id_font_size_tbl[(int)((UIntPtr)num4)];
            num += ( uint )num10;
            num7++;
            j++;
        }
        num5 = num / 2U;
        num6 = ( uint )( 480f - num5 + num3 );
        AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(6 * num7);
        int length2 = text.Length;
        while ( i < length2 )
        {
            ams_PARAM_DRAW_PRIMITIVE.Clear();
            byte b = (byte)text[i];
            byte b2 = (byte)AppMain.dm_stfrl_list_font_id_tbl[(int)b];
            byte b3;
            if ( b2 > 0 )
            {
                b3 = ( byte )( b2 % 16 );
            }
            else
            {
                b3 = 0;
            }
            byte b4;
            if ( b2 > 0 )
            {
                b4 = ( byte )( b2 / 16 );
            }
            else
            {
                b4 = 0;
            }
            ams_PARAM_DRAW_PRIMITIVE.mtx = null;
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY2 = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(4);
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY2;
            AppMain.NNS_PRIM3D_PCT[] buffer2 = nns_PRIM3D_PCT_ARRAY2.buffer;
            int offset2 = nns_PRIM3D_PCT_ARRAY2.offset;
            buffer2[offset2].Pos.x = ( buffer2[offset2 + 1].Pos.x = num6 );
            buffer2[offset2 + 2].Pos.x = ( buffer2[offset2 + 3].Pos.x = num6 + num8 );
            buffer2[offset2].Pos.y = ( buffer2[offset2 + 2].Pos.y = disp_pos_y );
            buffer2[offset2 + 1].Pos.y = ( buffer2[offset2 + 3].Pos.y = disp_pos_y + num8 );
            buffer2[offset2].Pos.z = ( buffer2[offset2 + 1].Pos.z = ( buffer2[offset2 + 2].Pos.z = ( buffer2[offset2 + 3].Pos.z = -2f ) ) );
            float num11 = (float)AppMain.dm_stfrl_font_width_length_tbl[(int)b] * AppMain.dm_stfrl_list_id_font_size_tbl[(int)((UIntPtr)num4)];
            num6 = ( uint )( num6 + num11 );
            buffer2[offset2].Col = ( buffer2[offset2 + 1].Col = ( buffer2[offset2 + 2].Col = ( buffer2[offset2 + 3].Col = AppMain.AMD_RGBA8888( array2[0], array2[1], array2[2], main_work.cur_page_list_alpha_data ) ) ) );
            buffer2[offset2].Tex.u = ( buffer2[offset2 + 1].Tex.u = ( float )b3 * 0.0625f );
            buffer2[offset2 + 2].Tex.u = ( buffer2[offset2 + 3].Tex.u = buffer2[offset2].Tex.u + 0.0625f );
            buffer2[offset2].Tex.v = ( buffer2[offset2 + 2].Tex.v = ( float )b4 * 0.125f );
            buffer2[offset2 + 1].Tex.v = ( buffer2[offset2 + 3].Tex.v = buffer2[offset2].Tex.v + 0.125f );
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 1;
            ams_PARAM_DRAW_PRIMITIVE.count = 4;
            ams_PARAM_DRAW_PRIMITIVE.texlist = AppMain.AoTexGetTexList( AppMain.dm_stfrl_font_tex );
            ams_PARAM_DRAW_PRIMITIVE.texId = 0;
            ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
            ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
            ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
            ams_PARAM_DRAW_PRIMITIVE.zTest = 0;
            AppMain.AoActDrawCorWide( nns_PRIM3D_PCT_ARRAY2, 0, 4U, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
            int num12 = nns_PRIM3D_PCT_ARRAY.offset + i * 6;
            nns_PRIM3D_PCT_ARRAY.buffer[num12] = buffer2[offset2];
            nns_PRIM3D_PCT_ARRAY.buffer[num12 + 1] = buffer2[offset2];
            nns_PRIM3D_PCT_ARRAY.buffer[num12 + 2] = buffer2[offset2 + 1];
            nns_PRIM3D_PCT_ARRAY.buffer[num12 + 3] = buffer2[offset2 + 2];
            nns_PRIM3D_PCT_ARRAY.buffer[num12 + 4] = buffer2[offset2 + 3];
            nns_PRIM3D_PCT_ARRAY.buffer[num12 + 5] = buffer2[offset2 + 3];
            if ( i + 1 >= text.Length )
            {
                ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
                ams_PARAM_DRAW_PRIMITIVE.count = 6 * num7;
                AppMain.amDrawPrimitive3D( 20U, ams_PARAM_DRAW_PRIMITIVE );
            }
            i++;
        }
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x06001BA8 RID: 7080 RVA: 0x000FDF0D File Offset: 0x000FC10D
    private static void dmStaffRollTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 20U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06001BA9 RID: 7081 RVA: 0x000FDF28 File Offset: 0x000FC128
    private static void dmStaffRollEndActDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 2304U );
        AppMain.AoActSysSetDrawStateEnable( true );
        AppMain.AoActSysSetDrawState( 30U );
        if ( ( main_work.flag & 4096U ) != 0U )
        {
            main_work.continue_act_frm++;
        }
        if ( main_work.is_eme_comp )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_end_tex ) );
            if ( main_work.end_act_frm > 0 )
            {
                for ( int i = 0; i <= 5; i++ )
                {
                    AppMain.AoActSortRegAction( main_work.act[i] );
                }
            }
            for ( int j = 6; j <= 7; j++ )
            {
                AppMain.AoActSortRegAction( main_work.act[j] );
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_end_jp_tex ) );
            AppMain.AoActSortRegAction( main_work.act[9] );
            AppMain.AoActSetFrame( main_work.act[9], ( float )main_work.end_act_frm );
        }
        else
        {
            AppMain.AoActSortRegAction( main_work.act[8] );
        }
        for ( int k = 0; k <= 7; k++ )
        {
            AppMain.AoActSetFrame( main_work.act[k], ( float )main_work.end_act_frm );
        }
        for ( int l = 0; l < 11; l++ )
        {
            if ( l <= 7 )
            {
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_end_tex ) );
            }
            else
            {
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_end_jp_tex ) );
            }
            AppMain.AoActUpdate( main_work.act[l], 0f );
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmStaffRollEndActTaskDraw ), 2304, 0U );
    }

    // Token: 0x06001BAA RID: 7082 RVA: 0x000FE084 File Offset: 0x000FC284
    private static void dmStaffRollEndActTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 30U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06001BAB RID: 7083 RVA: 0x000FE0A0 File Offset: 0x000FC2A0
    private static void dmStaffRollWinActDraw( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        AppMain.AoActSysSetDrawTaskPrio( 3072U );
        AppMain.AoActSysSetDrawStateEnable( true );
        AppMain.AoActSysSetDrawState( 50U );
        array2[0] = 641.25f;
        array2[1] = 303.75f;
        AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( AppMain.dm_stfrl_cmn_tex[0] ), 1U, 480f, 356f, array2[0] * main_work.win_size_rate[0], array2[1] * main_work.win_size_rate[1] * 0.9f, 50U );
        if ( ( main_work.flag & 64U ) != 0U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_cmn_tex[0] ) );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_cmn_tex[1] ) );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_end_jp_tex ) );
            AppMain.AoActSortRegAction( main_work.act[10] );
        }
        AppMain.AoActAcmPush();
        AppMain.AoActAcmInit();
        AppMain.AoActAcmApplyScale( 1.6875f, 1.6875f );
        AppMain.AoActAcmApplyTrans( AppMain.dm_stfrl_win_act_pos_tbl[3][0], AppMain.dm_stfrl_win_act_pos_tbl[3][1], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_stfrl_end_jp_tex ) );
        AppMain.AoActUpdate( main_work.act[10], 0f );
        AppMain.AoActAcmPop();
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmStaffRollWinActTaskDraw ), 3072, 0U );
    }

    // Token: 0x06001BAC RID: 7084 RVA: 0x000FE1E6 File Offset: 0x000FC3E6
    private static void dmStaffRollWinActTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 50U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06001BAD RID: 7085 RVA: 0x000FE1FF File Offset: 0x000FC3FF
    private static int dmStaffRollIsDataLoad( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            if ( main_work.staff_list_fs is AppMain.AMS_FS && !AppMain.amFsIsComplete( ( AppMain.AMS_FS )main_work.staff_list_fs ) )
            {
                return 0;
            }
        }
        else if ( !AppMain.amFsIsComplete( main_work.arc_list_font_amb_fs ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001BAE RID: 7086 RVA: 0x000FE23C File Offset: 0x000FC43C
    private static void dmStaffRollDataClearRequestFull( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        main_work.arc_data.arc_font_amb = main_work.arc_list_font_amb;
        main_work.arc_data.arc_scr_amb = AppMain.readAMBFile( main_work.arc_scr_amb_fs );
        main_work.arc_data.arc_end_amb = AppMain.readAMBFile( main_work.arc_end_amb_fs );
        main_work.arc_data.arc_end_jp_amb = AppMain.readAMBFile( main_work.arc_end_jp_amb_fs );
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            main_work.arc_data.arc_cmn_amb[( int )( ( UIntPtr )num )] = AppMain.readAMBFile( main_work.arc_cmn_amb_fs[( int )( ( UIntPtr )num )] );
        }
        main_work.arc_data.stf_list_ysd = new AppMain.YSDS_HEADER( ( byte[] )main_work.staff_list_fs );
        main_work.staff_list_fs = null;
    }

    // Token: 0x06001BAF RID: 7087 RVA: 0x000FE2E8 File Offset: 0x000FC4E8
    private static void dmStaffRollDataClearRequestEasy( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        main_work.arc_data.arc_font_amb = AppMain.readAMBFile( main_work.arc_list_font_amb_fs );
        main_work.arc_list_font_amb_fs = null;
        main_work.arc_list_font_amb_fs = null;
        main_work.arc_data.stf_list_ysd = new AppMain.YSDS_HEADER( ( byte[] )main_work.staff_list_fs );
        main_work.staff_list_fs = null;
        main_work.staff_list_fs = null;
    }

    // Token: 0x06001BB0 RID: 7088 RVA: 0x000FE342 File Offset: 0x000FC542
    private static void dmStaffRollDataBuildEasy( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.dm_stfrl_font_amb = main_work.arc_data.arc_font_amb;
        AppMain.AoTexBuild( AppMain.dm_stfrl_font_tex, AppMain.dm_stfrl_font_amb );
        AppMain.AoTexLoad( AppMain.dm_stfrl_font_tex );
        AppMain.dm_stfrl_data_mgr_p = main_work.arc_data;
    }

    // Token: 0x06001BB1 RID: 7089 RVA: 0x000FE378 File Offset: 0x000FC578
    private static int dmStaffRollIsTexLoad()
    {
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            if ( !AppMain.AoTexIsLoaded( AppMain.dm_stfrl_font_tex ) )
            {
                return 0;
            }
            if ( !AppMain.AoTexIsLoaded( AppMain.dm_stfrl_scr_tex ) )
            {
                return 0;
            }
            if ( !AppMain.AoTexIsLoaded( AppMain.dm_stfrl_end_tex ) )
            {
                return 0;
            }
            if ( !AppMain.AoTexIsLoaded( AppMain.dm_stfrl_end_jp_tex ) )
            {
                return 0;
            }
            for ( int i = 0; i < 2; i++ )
            {
                if ( !AppMain.AoTexIsLoaded( AppMain.dm_stfrl_cmn_tex[i] ) )
                {
                    return 0;
                }
            }
        }
        else if ( !AppMain.AoTexIsLoaded( AppMain.dm_stfrl_font_tex ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001BB2 RID: 7090 RVA: 0x000FE3F4 File Offset: 0x000FC5F4
    private static int dmStaffRollIsTexRelease()
    {
        if ( AppMain.dm_stfrl_is_full_staffroll )
        {
            if ( !AppMain.AoTexIsReleased( AppMain.dm_stfrl_font_tex ) )
            {
                return 0;
            }
            if ( !AppMain.AoTexIsReleased( AppMain.dm_stfrl_scr_tex ) )
            {
                return 0;
            }
            if ( !AppMain.AoTexIsReleased( AppMain.dm_stfrl_end_tex ) )
            {
                return 0;
            }
            if ( !AppMain.AoTexIsReleased( AppMain.dm_stfrl_end_jp_tex ) )
            {
                return 0;
            }
            for ( int i = 0; i < 2; i++ )
            {
                if ( !AppMain.AoTexIsReleased( AppMain.dm_stfrl_cmn_tex[i] ) )
                {
                    return 0;
                }
            }
        }
        else if ( !AppMain.AoTexIsReleased( AppMain.dm_stfrl_font_tex ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001BB3 RID: 7091 RVA: 0x000FE470 File Offset: 0x000FC670
    private static void dmStaffRollSetFadePageInfoEfctData( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        main_work.disp_page_time = AppMain.AoYsdFileGetPageTime( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page );
        main_work.disp_page_time = ( uint )( main_work.disp_page_time - 32f - 2f );
        main_work.fade_timer = main_work.disp_page_time;
        if ( AppMain.AoYsdFileIsPageShowImage( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page ) )
        {
            main_work.flag |= 16U;
            main_work.cur_disp_image = AppMain.AoYsdFileGetPageShowImageNo( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page );
            for ( int i = 0; i < 3; i++ )
            {
                if ( main_work.ring_work[i] != null )
                {
                    main_work.ring_work[i].flag |= 1U;
                }
            }
        }
        if ( AppMain.AoYsdFileIsPageHideImage( AppMain.dm_stfrl_data_mgr_p.stf_list_ysd, main_work.cur_disp_list_page ) )
        {
            main_work.flag |= 32U;
        }
    }

    // Token: 0x06001BB4 RID: 7092 RVA: 0x000FE554 File Offset: 0x000FC754
    private static void dmStaffRollSetEfctChngAlphaListData( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        int num = (int)main_work.cur_page_list_alpha_data;
        int num2 = (int)main_work.cur_page_scr_alpha_data;
        if ( main_work.fade_timer >= main_work.disp_page_time - 32f )
        {
            num += 8;
            if ( ( main_work.flag & 16U ) != 0U )
            {
                num2 += 8;
                if ( num2 >= 255 )
                {
                    num2 = 255;
                    main_work.flag &= 4294967279U;
                }
            }
        }
        else if ( main_work.fade_timer <= 32f )
        {
            num -= 8;
            if ( ( main_work.flag & 32U ) != 0U )
            {
                num2 -= 8;
                if ( num2 <= 0 )
                {
                    num2 = 0;
                    main_work.flag &= 4294967263U;
                }
            }
        }
        if ( num >= 255 )
        {
            num = 255;
        }
        if ( num <= 0 )
        {
            num = 0;
        }
        main_work.cur_page_list_alpha_data = ( uint )num;
        main_work.cur_page_scr_alpha_data = ( uint )num2;
    }

    // Token: 0x06001BB5 RID: 7093 RVA: 0x000FE614 File Offset: 0x000FC814
    private static void dmStaffRollSetWinOpenEfct( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.win_timer > 8f )
        {
            main_work.flag |= 512U;
            main_work.win_timer = 0f;
            for ( uint num = 0U; num < 2U; num += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 1f;
            }
        }
        else
        {
            main_work.win_timer += 1f;
        }
        for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
        {
            if ( 0f != main_work.win_timer )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = main_work.win_timer / 8f;
            }
            else
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
            if ( main_work.win_size_rate[( int )( ( UIntPtr )num2 )] > 1f )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
        }
    }

    // Token: 0x06001BB6 RID: 7094 RVA: 0x000FE6D8 File Offset: 0x000FC8D8
    private static void dmStaffRollSetWinCloseEfct( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( 0f != main_work.win_timer )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = main_work.win_timer / 8f;
            }
            else
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num )] = 0f;
            }
        }
        if ( main_work.win_timer < 0f )
        {
            main_work.flag |= 512U;
            main_work.win_timer = 0f;
            for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 0f;
            }
            return;
        }
        main_work.win_timer -= 1f;
    }

    // Token: 0x06001BB7 RID: 7095 RVA: 0x000FE77C File Offset: 0x000FC97C
    private static void dmStaffRollSetObjSystemData( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        AppMain.ObjDrawESEffectSystemInit( 0, 20480U, 5U );
        AppMain.ObjDrawSetNNCommandStateTbl( 0U, 1U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 1U, 2U, false );
        AppMain.ObjDrawSetNNCommandStateTbl( 2U, 3U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 3U, 5U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 4U, 11U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 5U, 12U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 6U, 9U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 7U, 4U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 8U, 8U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 9U, 7U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 10U, 10U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 11U, 6U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 12U, 0U, true );
        if ( ( AppMain.g_gm_main_system.game_flag & 512U ) != 0U )
        {
            AppMain.g_gm_main_system.game_time = 0U;
        }
        AppMain.g_gm_main_system.game_flag &= 4187479041U;
        AppMain.g_obj.flag = 4194408U;
        AppMain.g_obj.ppPre = null;
        AppMain.g_obj.ppPost = null;
        AppMain.g_obj.ppCollision = null;
        AppMain.g_obj.ppObjPre = new AppMain.OBJECT_WORK_Delegate( AppMain.GmObjObjPreFunc );
        AppMain.g_obj.ppObjPost = new AppMain.OBJECT_WORK_Delegate( AppMain.GmObjObjPostFunc );
        AppMain.g_obj.ppRegRecAuto = null;
        AppMain.g_obj.draw_scale.x = ( AppMain.g_obj.draw_scale.y = ( AppMain.g_obj.draw_scale.z = 13107 ) );
        AppMain.g_obj.inv_draw_scale.x = ( AppMain.g_obj.inv_draw_scale.y = ( AppMain.g_obj.inv_draw_scale.z = AppMain.FX_Div( 4096, AppMain.g_obj.draw_scale.x ) ) );
        AppMain.g_obj.depth = 128;
        AppMain.dmStaffRollInitLight();
        AppMain.dmStaffRollCameraInit();
        AppMain.GmEfctCmnBuildDataInit();
    }

    // Token: 0x06001BB8 RID: 7096 RVA: 0x000FE944 File Offset: 0x000FCB44
    private static void dmStaffRollSetupEndModel( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 3; i++ )
        {
            if ( main_work.ring_work[i] != null )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.ring_work[i];
                obs_OBJECT_WORK.ppOut = null;
                obs_OBJECT_WORK.flag |= 8U;
            }
        }
        AppMain.dmStaffRollSetBossObj( main_work );
        if ( main_work.is_eme_comp )
        {
            main_work.sonic_work = AppMain.DmStfrlMdlCtrlSetSonicObj();
        }
    }

    // Token: 0x06001BB9 RID: 7097 RVA: 0x000FE9A8 File Offset: 0x000FCBA8
    private static void dmStaffRollNodispEndModel( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        if ( main_work.body_work != null )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.body_work;
            obs_OBJECT_WORK.ppOut = null;
            obs_OBJECT_WORK.flag |= 8U;
        }
        if ( main_work.egg_work != null )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.egg_work;
            obs_OBJECT_WORK.ppOut = null;
            obs_OBJECT_WORK.flag |= 8U;
        }
        for ( int i = 0; i < 3; i++ )
        {
            if ( main_work.ring_work[i] != null )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.ring_work[i];
                obs_OBJECT_WORK.ppOut = null;
                obs_OBJECT_WORK.flag |= 8U;
            }
        }
        if ( main_work.sonic_work != null )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)main_work.sonic_work;
            obs_OBJECT_WORK.ppOut = null;
            obs_OBJECT_WORK.flag |= 8U;
        }
    }

    // Token: 0x06001BBA RID: 7098 RVA: 0x000FEA6B File Offset: 0x000FCC6B
    private static void dmStaffRollSetBossObj( AppMain.DMS_STFRL_MAIN_WORK main_work )
    {
        main_work.body_work = AppMain.DmStfrlMdlCtrlSetBodyObj();
        main_work.egg_work = AppMain.DmStfrlMdlCtrlSetEggObj( ( AppMain.OBS_OBJECT_WORK )main_work.body_work );
        if ( main_work.is_eme_comp )
        {
            main_work.body_work.flag |= 1U;
        }
    }

    // Token: 0x06001BBB RID: 7099 RVA: 0x000FEAAC File Offset: 0x000FCCAC
    private static void dmStaffRollInitLight()
    {
        AppMain.NNS_RGBA def_light_col = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.g_obj.ambient_color.r = 0.8f;
        AppMain.g_obj.ambient_color.g = 0.8f;
        AppMain.g_obj.ambient_color.b = 0.8f;
        nns_VECTOR.x = -1f;
        nns_VECTOR.y = -1f;
        nns_VECTOR.z = -1f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_0, ref def_light_col, 1f, nns_VECTOR );
        AppMain.g_gm_main_system.def_light_vec.Assign( nns_VECTOR );
        AppMain.g_gm_main_system.def_light_col = def_light_col;
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_6, ref def_light_col, 1f, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06001BBC RID: 7100 RVA: 0x000FEB8C File Offset: 0x000FCD8C
    private static void dmStaffRollCameraInit()
    {
        AppMain.NNS_VECTOR pos = new AppMain.NNS_VECTOR(0f, 0f, 50f);
        AppMain.ObjCameraInit( 0, pos, 4, 0, 8192 );
        AppMain.ObjCamera3dInit( 0 );
        AppMain.g_obj.glb_camera_id = 0;
        AppMain.g_obj.glb_camera_type = 1;
        AppMain.GmCameraDelayReset();
        AppMain.GmCameraAllowReset();
        AppMain.ObjCameraSetUserFunc( 0, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.dmStaffRollCameraFunc ) );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.scale = 0.67438334f;
        obs_CAMERA.ofst.z = 1000f;
    }

    // Token: 0x06001BBD RID: 7101 RVA: 0x000FEC18 File Offset: 0x000FCE18
    private static void dmStaffRollCameraFunc( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = AppMain.FXM_FX32_TO_FLOAT( 0 );
        nns_VECTOR.y = AppMain.FXM_FX32_TO_FLOAT( 0 );
        nns_VECTOR.z = AppMain.FXM_FX32_TO_FLOAT( 409600 );
        obj_camera.work.x = nns_VECTOR.x;
        obj_camera.work.y = nns_VECTOR.y;
        obj_camera.work.z = nns_VECTOR.z;
        obj_camera.prev_pos.x = obj_camera.pos.x;
        obj_camera.prev_pos.y = obj_camera.pos.y;
        obj_camera.prev_pos.z = obj_camera.pos.z;
        obj_camera.pos.x = 0f;
        obj_camera.pos.y = 0f;
        obj_camera.pos.z = 50f;
        obj_camera.disp_pos.x = obj_camera.pos.x;
        obj_camera.disp_pos.y = obj_camera.pos.y;
        obj_camera.disp_pos.z = obj_camera.pos.z;
        obj_camera.target_pos.Assign( obj_camera.disp_pos );
        obj_camera.target_pos.z -= 50f;
        AppMain.ObjObjectCameraSet( AppMain.FXM_FLOAT_TO_FX32( obj_camera.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_camera.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( obj_camera.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_camera.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ) );
        AppMain.GmCameraSetClipCamera( obj_camera );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }
}
