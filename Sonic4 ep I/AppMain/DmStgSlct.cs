using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accel;
using er;
using gs.backup;

public partial class AppMain
{
    // Token: 0x020002AF RID: 687
    private enum DME_STGSLCT_ACT : uint
    {
        // Token: 0x04005B20 RID: 23328
        ACT_ZONE_BG_LT,
        // Token: 0x04005B21 RID: 23329
        ACT_ZONE_BG_LB,
        // Token: 0x04005B22 RID: 23330
        ACT_ZONE_BG_RT,
        // Token: 0x04005B23 RID: 23331
        ACT_ZONE_BG_RB,
        // Token: 0x04005B24 RID: 23332
        ACT_TAB_MODE_L,
        // Token: 0x04005B25 RID: 23333
        ACT_ICON_SONIC,
        // Token: 0x04005B26 RID: 23334
        ACT_REST_NUM_100,
        // Token: 0x04005B27 RID: 23335
        ACT_REST_NUM_10,
        // Token: 0x04005B28 RID: 23336
        ACT_REST_NUM_1,
        // Token: 0x04005B29 RID: 23337
        ACT_TAB_EMER,
        // Token: 0x04005B2A RID: 23338
        ACT_ICON_EMER_1,
        // Token: 0x04005B2B RID: 23339
        ACT_ICON_EMER_2,
        // Token: 0x04005B2C RID: 23340
        ACT_ICON_EMER_3,
        // Token: 0x04005B2D RID: 23341
        ACT_ICON_EMER_4,
        // Token: 0x04005B2E RID: 23342
        ACT_ICON_EMER_5,
        // Token: 0x04005B2F RID: 23343
        ACT_ICON_EMER_6,
        // Token: 0x04005B30 RID: 23344
        ACT_ICON_EMER_7,
        // Token: 0x04005B31 RID: 23345
        ACT_TEX_ZONE_UP,
        // Token: 0x04005B32 RID: 23346
        ACT_TEX_ZONE_UP_S,
        // Token: 0x04005B33 RID: 23347
        ACT_TAB_ZONE_SCR1,
        // Token: 0x04005B34 RID: 23348
        ACT_TAB_ZONE_SCR2,
        // Token: 0x04005B35 RID: 23349
        ACT_TAB_ZONE_SCR3,
        // Token: 0x04005B36 RID: 23350
        ACT_TAB_ZONE_SCR4,
        // Token: 0x04005B37 RID: 23351
        ACT_TAB_ZONE_SCR5,
        // Token: 0x04005B38 RID: 23352
        ACT_TAB_ZONE_SCR6,
        // Token: 0x04005B39 RID: 23353
        ACT_TAB_ZONE_SCR1_1a,
        // Token: 0x04005B3A RID: 23354
        ACT_TAB_ZONE_SCR1_2a,
        // Token: 0x04005B3B RID: 23355
        ACT_TAB_ZONE_SCR1_3a,
        // Token: 0x04005B3C RID: 23356
        ACT_TAB_ZONE_SCR2_1a,
        // Token: 0x04005B3D RID: 23357
        ACT_TAB_ZONE_SCR2_2a,
        // Token: 0x04005B3E RID: 23358
        ACT_TAB_ZONE_SCR2_3a,
        // Token: 0x04005B3F RID: 23359
        ACT_TAB_ZONE_SCR3_1a,
        // Token: 0x04005B40 RID: 23360
        ACT_TAB_ZONE_SCR3_2a,
        // Token: 0x04005B41 RID: 23361
        ACT_TAB_ZONE_SCR3_3a,
        // Token: 0x04005B42 RID: 23362
        ACT_TAB_ZONE_SCR4_1a,
        // Token: 0x04005B43 RID: 23363
        ACT_TAB_ZONE_SCR4_2a,
        // Token: 0x04005B44 RID: 23364
        ACT_TAB_ZONE_SCR4_3a,
        // Token: 0x04005B45 RID: 23365
        ACT_TAB_ZONE_TAB,
        // Token: 0x04005B46 RID: 23366
        ACT_TAB_ZONE_TEXT,
        // Token: 0x04005B47 RID: 23367
        ACT_TAB_ZONE_TEXT_S,
        // Token: 0x04005B48 RID: 23368
        ACT_TAB_ZONE_COVER1,
        // Token: 0x04005B49 RID: 23369
        ACT_TAB_ZONE_COVER2,
        // Token: 0x04005B4A RID: 23370
        ACT_TAB_ZONE_COVER3,
        // Token: 0x04005B4B RID: 23371
        ACT_ICON_DOWN_1,
        // Token: 0x04005B4C RID: 23372
        ACT_ICON_DOWN_2,
        // Token: 0x04005B4D RID: 23373
        ACT_ICON_DOWN_3,
        // Token: 0x04005B4E RID: 23374
        ACT_ICON_DOWN_4,
        // Token: 0x04005B4F RID: 23375
        ACT_ICON_DOWN_5,
        // Token: 0x04005B50 RID: 23376
        ACT_ICON_DOWN_6,
        // Token: 0x04005B51 RID: 23377
        ACT_ICON_L_ARROW,
        // Token: 0x04005B52 RID: 23378
        ACT_ICON_R_ARROW,
        // Token: 0x04005B53 RID: 23379
        ACT_TAB_STATE_L,
        // Token: 0x04005B54 RID: 23380
        ACT_TAB_STATE_C,
        // Token: 0x04005B55 RID: 23381
        ACT_TAB_STATE_R,
        // Token: 0x04005B56 RID: 23382
        ACT_TAB_STATE_L2,
        // Token: 0x04005B57 RID: 23383
        ACT_TAB_STATE_C2,
        // Token: 0x04005B58 RID: 23384
        ACT_TAB_STATE_R2,
        // Token: 0x04005B59 RID: 23385
        ACT_TAB_STATE_MOVE,
        // Token: 0x04005B5A RID: 23386
        ACT_TAB_TABLE2,
        // Token: 0x04005B5B RID: 23387
        ACT_TAB_TABLE1,
        // Token: 0x04005B5C RID: 23388
        ACT_TAB_TABLE3,
        // Token: 0x04005B5D RID: 23389
        ACT_TAB_SCR,
        // Token: 0x04005B5E RID: 23390
        ACT_TAB_SCR_BG,
        // Token: 0x04005B5F RID: 23391
        ACT_TAB_TEXT,
        // Token: 0x04005B60 RID: 23392
        ACT_TAB_A_NUM,
        // Token: 0x04005B61 RID: 23393
        ACT_TAB_MESS,
        // Token: 0x04005B62 RID: 23394
        ACT_TAB_LINE,
        // Token: 0x04005B63 RID: 23395
        ACT_TAB_ICON_EMER,
        // Token: 0x04005B64 RID: 23396
        ACT_TAB_NUM_SPE_STAGE,
        // Token: 0x04005B65 RID: 23397
        ACT_TAB_ICON_SPE_EMER,
        // Token: 0x04005B66 RID: 23398
        ACT_TAB_CURSOR_UP,
        // Token: 0x04005B67 RID: 23399
        ACT_TAB_CURSOR_DOWN,
        // Token: 0x04005B68 RID: 23400
        ACT_TAB_TEX_SCORE,
        // Token: 0x04005B69 RID: 23401
        ACT_TAB_TEX_TIME,
        // Token: 0x04005B6A RID: 23402
        ACT_TAB_TEX_BOSS,
        // Token: 0x04005B6B RID: 23403
        ACT_TAB_TEX_SPE_STAGE,
        // Token: 0x04005B6C RID: 23404
        ACT_TAB_S_NUM1,
        // Token: 0x04005B6D RID: 23405
        ACT_TAB_S_NUM2,
        // Token: 0x04005B6E RID: 23406
        ACT_TAB_S_NUM3,
        // Token: 0x04005B6F RID: 23407
        ACT_TAB_S_NUM4,
        // Token: 0x04005B70 RID: 23408
        ACT_TAB_S_NUM5,
        // Token: 0x04005B71 RID: 23409
        ACT_TAB_S_NUM6,
        // Token: 0x04005B72 RID: 23410
        ACT_TAB_S_NUM7,
        // Token: 0x04005B73 RID: 23411
        ACT_TAB_S_NUM8,
        // Token: 0x04005B74 RID: 23412
        ACT_TAB_S_NUM9,
        // Token: 0x04005B75 RID: 23413
        ACT_TAB_COVER2,
        // Token: 0x04005B76 RID: 23414
        ACT_TAB_COVER1,
        // Token: 0x04005B77 RID: 23415
        ACT_TAB_COVER3,
        // Token: 0x04005B78 RID: 23416
        ACT_TEX_BIG_TIME,
        // Token: 0x04005B79 RID: 23417
        ACT_TEX_BIG_SCORE,
        // Token: 0x04005B7A RID: 23418
        ACT_WIN_TEX_MSG,
        // Token: 0x04005B7B RID: 23419
        ACT_WIN_TEX_MSG2,
        // Token: 0x04005B7C RID: 23420
        ACT_WIN_TEX_MSG_SSONIC,
        // Token: 0x04005B7D RID: 23421
        ACT_WAVE_BG,
        // Token: 0x04005B7E RID: 23422
        ACT_DOWN_BG,
        // Token: 0x04005B7F RID: 23423
        ACT_BLUE_BG,
        // Token: 0x04005B80 RID: 23424
        ACT_BTN_CANCEL1,
        // Token: 0x04005B81 RID: 23425
        ACT_BTN_LB,
        // Token: 0x04005B82 RID: 23426
        ACT_BTN_MENU,
        // Token: 0x04005B83 RID: 23427
        ACT_BTN_LB_ARROW,
        // Token: 0x04005B84 RID: 23428
        ACT_BTN_RB_ARROW,
        // Token: 0x04005B85 RID: 23429
        ACT_BTN_CANCEL2,
        // Token: 0x04005B86 RID: 23430
        ACT_BTN_X,
        // Token: 0x04005B87 RID: 23431
        ACT_BTN_Y,
        // Token: 0x04005B88 RID: 23432
        ACT_BACK_BTN01_L,
        // Token: 0x04005B89 RID: 23433
        ACT_BACK_BTN01_R,
        // Token: 0x04005B8A RID: 23434
        ACT_YES_BTN_L,
        // Token: 0x04005B8B RID: 23435
        ACT_YES_BTN_C,
        // Token: 0x04005B8C RID: 23436
        ACT_YES_BTN_R,
        // Token: 0x04005B8D RID: 23437
        ACT_NO_BTN_L,
        // Token: 0x04005B8E RID: 23438
        ACT_NO_BTN_C,
        // Token: 0x04005B8F RID: 23439
        ACT_NO_BTN_R,
        // Token: 0x04005B90 RID: 23440
        ACT_TEX_FIX_BACK,
        // Token: 0x04005B91 RID: 23441
        ACT_TEX_BACK1,
        // Token: 0x04005B92 RID: 23442
        ACT_TEX_YES,
        // Token: 0x04005B93 RID: 23443
        ACT_TEX_NO,
        // Token: 0x04005B94 RID: 23444
        ACT_NUM,
        // Token: 0x04005B95 RID: 23445
        ACT_TAB_START = 58U,
        // Token: 0x04005B96 RID: 23446
        ACT_TAB_END = 84U,
        // Token: 0x04005B97 RID: 23447
        ACT_NONE
    }

    // Token: 0x020002B0 RID: 688
    private class DMS_STGSLCT_MAIN_WORK
    {
        // Token: 0x04005B98 RID: 23448
        public readonly AppMain.AMS_FS[] arc_cmn_amb_fs = new AppMain.AMS_FS[5];

        // Token: 0x04005B99 RID: 23449
        public readonly AppMain.AMS_AMB_HEADER[] arc_cmn_amb = new AppMain.AMS_AMB_HEADER[5];

        // Token: 0x04005B9A RID: 23450
        public readonly AppMain.A2S_AMA_HEADER[] cmn_ama = new AppMain.A2S_AMA_HEADER[5];

        // Token: 0x04005B9B RID: 23451
        public readonly AppMain.AMS_AMB_HEADER[] cmn_amb = new AppMain.AMS_AMB_HEADER[5];

        // Token: 0x04005B9C RID: 23452
        public readonly AppMain.AOS_TEXTURE[] cmn_tex = AppMain.New<AppMain.AOS_TEXTURE>(5);

        // Token: 0x04005B9D RID: 23453
        public readonly AppMain.AMS_FS[] arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x04005B9E RID: 23454
        public readonly AppMain.AMS_AMB_HEADER[] arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005B9F RID: 23455
        public AppMain.AMS_FS win_amb_fs;

        // Token: 0x04005BA0 RID: 23456
        public readonly AppMain.A2S_AMA_HEADER[] ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x04005BA1 RID: 23457
        public readonly AppMain.AMS_AMB_HEADER[] amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005BA2 RID: 23458
        public AppMain.AMS_AMB_HEADER win_amb;

        // Token: 0x04005BA3 RID: 23459
        public readonly AppMain.AOS_TEXTURE[] tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x04005BA4 RID: 23460
        public readonly AppMain.AOS_TEXTURE win_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x04005BA5 RID: 23461
        public readonly AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[116];

        // Token: 0x04005BA6 RID: 23462
        public readonly CTrgAoAction[] trg_zone = AppMain.New<CTrgAoAction>(6);

        // Token: 0x04005BA7 RID: 23463
        public readonly CTrgAoAction[] trg_act = AppMain.New<CTrgAoAction>(7);

        // Token: 0x04005BA8 RID: 23464
        public readonly CTrgAoAction[] trg_act_tab = AppMain.New<CTrgAoAction>(6);

        // Token: 0x04005BA9 RID: 23465
        public readonly CTrgAoAction[] trg_act_lr = AppMain.New<CTrgAoAction>(2);

        // Token: 0x04005BAA RID: 23466
        public readonly CTrgFlick trg_act_move = new CTrgFlick();

        // Token: 0x04005BAB RID: 23467
        public readonly CTrgAoAction[] trg_mode = AppMain.New<CTrgAoAction>(2);

        // Token: 0x04005BAC RID: 23468
        public readonly CTrgAoAction trg_cancel = new CTrgAoAction();

        // Token: 0x04005BAD RID: 23469
        public readonly CTrgAoAction[] trg_answer = AppMain.New<CTrgAoAction>(2);

        // Token: 0x04005BAE RID: 23470
        public AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_input_ proc_win_input;

        // Token: 0x04005BAF RID: 23471
        public AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_ proc_input;

        // Token: 0x04005BB0 RID: 23472
        public AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_ proc_win_update;

        // Token: 0x04005BB1 RID: 23473
        public AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_ proc_menu_update;

        // Token: 0x04005BB2 RID: 23474
        public AppMain.DMS_STGSLCT_MAIN_WORK._proc_draw_ proc_draw;

        // Token: 0x04005BB3 RID: 23475
        public int timer;

        // Token: 0x04005BB4 RID: 23476
        public uint flag;

        // Token: 0x04005BB5 RID: 23477
        public int state;

        // Token: 0x04005BB6 RID: 23478
        public float win_timer;

        // Token: 0x04005BB7 RID: 23479
        public uint disp_flag;

        // Token: 0x04005BB8 RID: 23480
        public int bg_timer;

        // Token: 0x04005BB9 RID: 23481
        public int zone_scr_timer;

        // Token: 0x04005BBA RID: 23482
        public uint announce_flag;

        // Token: 0x04005BBB RID: 23483
        public int next_evt;

        // Token: 0x04005BBC RID: 23484
        public int prev_evt;

        // Token: 0x04005BBD RID: 23485
        public readonly int[] n_sonic_hi_score = new int[17];

        // Token: 0x04005BBE RID: 23486
        public readonly int[] s_sonic_hi_score = new int[17];

        // Token: 0x04005BBF RID: 23487
        public readonly int[] n_sonic_record_time = new int[17];

        // Token: 0x04005BC0 RID: 23488
        public readonly int[] s_sonic_record_time = new int[17];

        // Token: 0x04005BC1 RID: 23489
        public readonly int[] hi_score = new int[24];

        // Token: 0x04005BC2 RID: 23490
        public readonly int[] record_time = new int[24];

        // Token: 0x04005BC3 RID: 23491
        public readonly int[] is_clear_stage = new int[24];

        // Token: 0x04005BC4 RID: 23492
        public int is_final_open;

        // Token: 0x04005BC5 RID: 23493
        public uint get_emerald;

        // Token: 0x04005BC6 RID: 23494
        public readonly uint[] eme_stage_no = new uint[7];

        // Token: 0x04005BC7 RID: 23495
        public uint cur_game_mode;

        // Token: 0x04005BC8 RID: 23496
        public uint player_stock;

        // Token: 0x04005BC9 RID: 23497
        public readonly float[,] win_act_pos = new float[13, 2];

        // Token: 0x04005BCA RID: 23498
        public readonly float[] win_size_rate = new float[2];

        // Token: 0x04005BCB RID: 23499
        public int win_mode;

        // Token: 0x04005BCC RID: 23500
        public int win_cur_slct;

        // Token: 0x04005BCD RID: 23501
        public bool win_is_disp_cover;

        // Token: 0x04005BCE RID: 23502
        public uint cur_zone;

        // Token: 0x04005BCF RID: 23503
        public uint chng_zone;

        // Token: 0x04005BD0 RID: 23504
        public readonly float[][] zone_pos = AppMain.New<float>(6, 2);

        // Token: 0x04005BD1 RID: 23505
        public readonly float[] move_spd = new float[2];

        // Token: 0x04005BD2 RID: 23506
        public uint efct_time;

        // Token: 0x04005BD3 RID: 23507
        public uint efct_out_flag;

        // Token: 0x04005BD4 RID: 23508
        public readonly float[] act_top_pos_x = new float[24];

        // Token: 0x04005BD5 RID: 23509
        public readonly float[] act_top_pos_y = new float[24];

        // Token: 0x04005BD6 RID: 23510
        public readonly float[] act_move_src = new float[2];

        // Token: 0x04005BD7 RID: 23511
        public readonly float[] act_move_dest = new float[2];

        // Token: 0x04005BD8 RID: 23512
        public readonly float[] act_move_pos_src = new float[24];

        // Token: 0x04005BD9 RID: 23513
        public readonly float[] act_move_pos_dst = new float[24];

        // Token: 0x04005BDA RID: 23514
        public float chaos_eme_pos_y;

        // Token: 0x04005BDB RID: 23515
        public float mode_tex_pos_y;

        // Token: 0x04005BDC RID: 23516
        public float mode_tex_frm;

        // Token: 0x04005BDD RID: 23517
        public int cur_stage;

        // Token: 0x04005BDE RID: 23518
        public int prev_stage;

        // Token: 0x04005BDF RID: 23519
        public int cur_vrtcl_stage;

        // Token: 0x04005BE0 RID: 23520
        public int prev_vrtcl_stage;

        // Token: 0x04005BE1 RID: 23521
        public int crsr_idx;

        // Token: 0x04005BE2 RID: 23522
        public int crsr_prev_idx;

        // Token: 0x04005BE3 RID: 23523
        public float crsr_pos_y;

        // Token: 0x04005BE4 RID: 23524
        public float crsr_move_src;

        // Token: 0x04005BE5 RID: 23525
        public float crsr_move_dst;

        // Token: 0x04005BE6 RID: 23526
        public int focus_disp_no;

        // Token: 0x04005BE7 RID: 23527
        public int prev_disp_no;

        // Token: 0x04005BE8 RID: 23528
        public bool is_disp_cover;

        // Token: 0x04005BE9 RID: 23529
        public readonly float[] act_tab_state_move_base_pos = new float[2];

        // Token: 0x04005BEA RID: 23530
        public readonly float[] obi_pos = new float[2];

        // Token: 0x04005BEB RID: 23531
        public readonly AppMain.AMS_PARAM_DRAW_PRIMITIVE up_bg_vrtx = new AppMain.AMS_PARAM_DRAW_PRIMITIVE();

        // Token: 0x04005BEC RID: 23532
        public int decide_zone_efct_dist_x;

        // Token: 0x04005BED RID: 23533
        public int decide_zone_efct_dist_y;

        // Token: 0x04005BEE RID: 23534
        public readonly float[] tex_u = new float[2];

        // Token: 0x04005BEF RID: 23535
        public readonly float[] tex_v = new float[2];

        // Token: 0x04005BF0 RID: 23536
        public AppMain.AOS_ACT_COL bg_fade;

        // Token: 0x04005BF1 RID: 23537
        public uint cur_bg_id;

        // Token: 0x04005BF2 RID: 23538
        public uint next_bg_id;

        // Token: 0x04005BF3 RID: 23539
        public uint zone_scr_id;

        // Token: 0x04005BF4 RID: 23540
        public uint mode_tex_move_frm;

        // Token: 0x04005BF5 RID: 23541
        public uint btn_l_disp_frm;

        // Token: 0x04005BF6 RID: 23542
        public uint btn_r_disp_frm;

        // Token: 0x04005BF7 RID: 23543
        public bool is_jp_region;

        // Token: 0x020002B1 RID: 689
        // (Invoke) Token: 0x0600247A RID: 9338
        public delegate void _proc_win_input_( AppMain.DMS_STGSLCT_MAIN_WORK work );

        // Token: 0x020002B2 RID: 690
        // (Invoke) Token: 0x0600247E RID: 9342
        public delegate void _proc_input_( AppMain.DMS_STGSLCT_MAIN_WORK work );

        // Token: 0x020002B3 RID: 691
        // (Invoke) Token: 0x06002482 RID: 9346
        public delegate void _proc_win_update_( AppMain.DMS_STGSLCT_MAIN_WORK work );

        // Token: 0x020002B4 RID: 692
        // (Invoke) Token: 0x06002486 RID: 9350
        public delegate void _proc_menu_update_( AppMain.DMS_STGSLCT_MAIN_WORK work );

        // Token: 0x020002B5 RID: 693
        // (Invoke) Token: 0x0600248A RID: 9354
        public delegate void _proc_draw_( AppMain.DMS_STGSLCT_MAIN_WORK work );
    }

    // Token: 0x020002B6 RID: 694
    public class CActionDraw
    {
        // Token: 0x0600248D RID: 9357 RVA: 0x0014ADF4 File Offset: 0x00148FF4
        public void Entry( AppMain.A2S_AMA_HEADER ama, uint id, float frame, float x, float y )
        {
            if ( AppMain._am_sample_draw_enable )
            {
                AppMain.AOS_ACTION aos_ACTION = AppMain.AoActCreate(ama, id, frame);
                AppMain.AoActAcmPush();
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( x, y, 0f );
                AppMain.AoActUpdate( aos_ACTION, 0f );
                AppMain.AoActSortRegAction( aos_ACTION );
                AppMain.AoActAcmPop();
                this.m_action_array.push_back( aos_ACTION );
            }
        }

        // Token: 0x0600248E RID: 9358 RVA: 0x0014AE4C File Offset: 0x0014904C
        public void Entry( AppMain.A2S_AMA_HEADER ama, uint id, float frame, float x, float y, float scalex, float scaley )
        {
            if ( AppMain._am_sample_draw_enable )
            {
                AppMain.AOS_ACTION aos_ACTION = AppMain.AoActCreate(ama, id, frame);
                AppMain.AoActAcmPush();
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( x, y, 0f );
                AppMain.AoActAcmApplyScale( scalex, scaley );
                AppMain.AoActUpdate( aos_ACTION, 0f );
                AppMain.AoActSortRegAction( aos_ACTION );
                AppMain.AoActAcmPop();
                this.m_action_array.push_back( aos_ACTION );
            }
        }

        // Token: 0x0600248F RID: 9359 RVA: 0x0014AEAC File Offset: 0x001490AC
        public void Clear()
        {
            for ( int i = 0; i < this.m_action_array.size(); i++ )
            {
                AppMain.AoActDelete( this.m_action_array[i] );
            }
            this.m_action_array.clear();
        }

        // Token: 0x06002490 RID: 9360 RVA: 0x0014AEEB File Offset: 0x001490EB
        public void Draw()
        {
            if ( AppMain._am_sample_draw_enable )
            {
                AppMain.AoActSortExecute();
                AppMain.AoActSortDraw();
            }
            AppMain.AoActSortUnregAll();
        }

        // Token: 0x06002492 RID: 9362 RVA: 0x0014AF18 File Offset: 0x00149118
        public void CActionDraw_destructor()
        {
            this.Clear();
        }

        // Token: 0x04005BF8 RID: 23544
        public CCircularBuffer<AppMain.AOS_ACTION> m_action_array = new CCircularBuffer<AppMain.AOS_ACTION>(100);
    }


    // Token: 0x06001321 RID: 4897 RVA: 0x000A6137 File Offset: 0x000A4337
    private void DmStgSlctStart( object arg )
    {
        this.dmStgSlctInit();
    }

    // Token: 0x06001322 RID: 4898 RVA: 0x000A6148 File Offset: 0x000A4348
    private void dmStgSlctInit()
    {
        AppMain.AoActSysSetDrawStateEnable( false );
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(this.dmStgSlctProcMain), new AppMain.GSF_TASK_PROCEDURE(this.dmStgSlctDest), 0U, 0, 8192U, 0, () => new AppMain.DMS_STGSLCT_MAIN_WORK(), "STGSLCT_MAIN");
        AppMain.DMS_STGSLCT_MAIN_WORK dms_STGSLCT_MAIN_WORK = (AppMain.DMS_STGSLCT_MAIN_WORK)mts_TASK_TCB.work;
        if ( AppMain.GeEnvGetDecideKey() == AppMain.GSE_DECIDE_KEY.GSD_DECIDE_KEY_O )
        {
            dms_STGSLCT_MAIN_WORK.is_jp_region = true;
        }
        else
        {
            dms_STGSLCT_MAIN_WORK.is_jp_region = false;
        }
        this.dmStgSlctSetInitData( dms_STGSLCT_MAIN_WORK );
        this.dmStgSlctSetHiScore( dms_STGSLCT_MAIN_WORK );
        this.dmStgSlctSetClearInfo( dms_STGSLCT_MAIN_WORK );
        this.dmStgSlctSetAnnounceMsg( dms_STGSLCT_MAIN_WORK );
        dms_STGSLCT_MAIN_WORK.tex_u[0] = ( dms_STGSLCT_MAIN_WORK.tex_u[1] = ( dms_STGSLCT_MAIN_WORK.tex_v[0] = ( dms_STGSLCT_MAIN_WORK.tex_v[1] = 0.1f ) ) );
        dms_STGSLCT_MAIN_WORK.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctLoadFontData );
    }

    // Token: 0x06001323 RID: 4899 RVA: 0x000A6224 File Offset: 0x000A4424
    private void dmStgSlctSetInitData( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        AppMain.UNREFERENCED_PARAMETER( main_work );
        short old_evt_id = AppMain.SyGetEvtInfo().old_evt_id;
        if ( old_evt_id == 6 || old_evt_id == 11 )
        {
            AppMain.dm_stgslct_is_stage_start = true;
            main_work.cur_game_mode = ( uint )AppMain.g_gs_main_sys_info.game_mode;
        }
        else if ( old_evt_id == 3 || old_evt_id == 4 )
        {
            AppMain.dm_stgslct_is_stage_start = false;
            main_work.cur_game_mode = 0U;
        }
        else if ( old_evt_id == 7 )
        {
            AppMain.dm_stgslct_is_stage_start = true;
            main_work.cur_game_mode = ( uint )AppMain.g_gs_main_sys_info.game_mode;
            main_work.flag |= 16777216U;
        }
        else
        {
            AppMain.dm_stgslct_is_stage_start = false;
            main_work.cur_game_mode = 0U;
        }
        main_work.bg_fade.r = byte.MaxValue;
        main_work.bg_fade.g = byte.MaxValue;
        main_work.bg_fade.b = byte.MaxValue;
        main_work.bg_fade.a = 0;
        if ( AppMain.dm_stgslct_is_stage_start )
        {
            if ( AppMain.g_gs_main_sys_info.stage_id < 16 )
            {
                main_work.cur_stage = this.dmStgSlctSetNextFocusAct( main_work, ( int )AppMain.g_gs_main_sys_info.stage_id );
                main_work.cur_zone = AppMain.dm_stgslct_act_zone_no_tbl[main_work.cur_stage];
                main_work.chng_zone = 7U;
                main_work.focus_disp_no = 0;
                main_work.crsr_idx = main_work.cur_stage % 4;
            }
            else if ( AppMain.g_gs_main_sys_info.stage_id >= 28 )
            {
                main_work.cur_stage = 0;
                main_work.cur_zone = 0U;
                main_work.chng_zone = 7U;
                main_work.focus_disp_no = 0;
                main_work.crsr_idx = 0;
            }
            else if ( AppMain.g_gs_main_sys_info.stage_id >= 21 )
            {
                if ( AppMain.g_gs_main_sys_info.prev_stage_id != 65535 )
                {
                    main_work.cur_stage = this.dmStgSlctSetNextFocusAct( main_work, ( int )AppMain.g_gs_main_sys_info.prev_stage_id );
                    main_work.cur_zone = AppMain.dm_stgslct_act_zone_no_tbl[main_work.cur_stage];
                    main_work.chng_zone = 7U;
                    main_work.focus_disp_no = 0;
                    main_work.crsr_idx = main_work.cur_stage % 4;
                }
                else
                {
                    main_work.cur_stage = ( int )( ( ulong )AppMain.dm_stgslct_zone_act_num_tbl[5][0] + ( ulong )( ( long )( AppMain.g_gs_main_sys_info.stage_id - 21 ) ) );
                    main_work.cur_zone = 5U;
                    main_work.chng_zone = 7U;
                    if ( main_work.cur_stage <= 20 )
                    {
                        main_work.focus_disp_no = main_work.cur_stage - 17;
                        main_work.crsr_idx = 0;
                    }
                    else
                    {
                        main_work.focus_disp_no = 3;
                        main_work.crsr_idx = main_work.cur_stage - 20;
                    }
                }
            }
            else
            {
                main_work.cur_stage = 16;
                main_work.cur_zone = 4U;
                main_work.chng_zone = 7U;
                main_work.focus_disp_no = 0;
                main_work.crsr_idx = 0;
            }
            if ( main_work.cur_zone != 4U )
            {
                main_work.crsr_pos_y = this.dm_stgslct_act_crsr_disp_y_pos_tbl[main_work.crsr_idx];
            }
            else
            {
                main_work.crsr_pos_y = 320f;
            }
        }
        main_work.btn_l_disp_frm = 12U;
        main_work.btn_r_disp_frm = 12U;
        main_work.cur_bg_id = main_work.cur_zone;
        main_work.obi_pos[0] = 0f;
        main_work.obi_pos[1] = 1120f;
    }

    // Token: 0x06001324 RID: 4900 RVA: 0x000A64E2 File Offset: 0x000A46E2
    private void dmStgSlctSetHiScore( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
    }

    // Token: 0x06001325 RID: 4901 RVA: 0x000A64E4 File Offset: 0x000A46E4
    private void dmStgSlctSetClearInfo( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = 0U;
        SStage sstage = SStage.CreateInstance();
        for ( uint num2 = 0U; num2 <= 16U; num2 += 1U )
        {
            main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )] = ( int )sstage[( int )num2].GetHighScore( false );
            main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )] = ( int )sstage[( int )num2].GetHighScore( true );
            if ( main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )] != 1000000000 && main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )] != 1000000000 )
            {
                if ( main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )] >= main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )] )
                {
                    main_work.hi_score[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )];
                }
                else
                {
                    main_work.hi_score[( int )( ( UIntPtr )num2 )] = main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )];
                }
            }
            else if ( main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )] == 1000000000 && main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )] == 1000000000 )
            {
                main_work.hi_score[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )];
            }
            else if ( main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )] == 1000000000 )
            {
                main_work.hi_score[( int )( ( UIntPtr )num2 )] = main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )];
            }
            else if ( main_work.s_sonic_hi_score[( int )( ( UIntPtr )num2 )] == 1000000000 )
            {
                main_work.hi_score[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )];
            }
            else
            {
                main_work.hi_score[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_hi_score[( int )( ( UIntPtr )num2 )];
            }
            if ( main_work.hi_score[( int )( ( UIntPtr )num2 )] > 1000000000 )
            {
                main_work.hi_score[( int )( ( UIntPtr )num2 )] = 999999999;
            }
            main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )] = ( int )sstage[( int )num2].GetFastTime( false );
            main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )] = ( int )sstage[( int )num2].GetFastTime( true );
            if ( main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )] != 36000 && main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )] != 36000 )
            {
                if ( main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )] <= main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )] )
                {
                    main_work.record_time[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )];
                }
                else
                {
                    main_work.record_time[( int )( ( UIntPtr )num2 )] = main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )];
                }
            }
            else if ( main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )] == 36000 && main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )] == 36000 )
            {
                main_work.record_time[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )];
            }
            else if ( main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )] == 36000 )
            {
                main_work.record_time[( int )( ( UIntPtr )num2 )] = main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )];
            }
            else if ( main_work.s_sonic_record_time[( int )( ( UIntPtr )num2 )] == 36000 )
            {
                main_work.record_time[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )];
            }
            else
            {
                main_work.record_time[( int )( ( UIntPtr )num2 )] = main_work.n_sonic_record_time[( int )( ( UIntPtr )num2 )];
            }
            if ( main_work.record_time[( int )( ( UIntPtr )num2 )] > 36000 )
            {
                main_work.record_time[( int )( ( UIntPtr )num2 )] = 35999;
            }
        }
        SSpecial sspecial = SSpecial.CreateInstance();
        for ( uint num2 = 0U; num2 < 7U; num2 += 1U )
        {
            main_work.hi_score[( int )( ( UIntPtr )( num2 + 17U ) )] = ( int )sspecial[( int )num2].GetHighScore();
            if ( main_work.hi_score[( int )( ( UIntPtr )( num2 + 17U ) )] > 1000000000 )
            {
                main_work.hi_score[( int )( ( UIntPtr )( num2 + 17U ) )] = 999999999;
            }
            main_work.record_time[( int )( ( UIntPtr )( num2 + 17U ) )] = ( int )sspecial[( int )num2].GetFastTime();
            if ( main_work.record_time[( int )( ( UIntPtr )num2 )] > 36000 )
            {
                main_work.record_time[( int )( ( UIntPtr )num2 )] = 35999;
            }
        }
        for ( uint num2 = 0U; num2 < 24U; num2 += 1U )
        {
            if ( main_work.hi_score[( int )( ( UIntPtr )num2 )] == 1000000000 && main_work.record_time[( int )( ( UIntPtr )num2 )] == 36000 )
            {
                main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] = 0;
            }
            else
            {
                main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] = 1;
            }
        }
        for ( uint num2 = 0U; num2 < 24U; num2 += 1U )
        {
            if ( num2 > 16U && main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] == 0 )
            {
                main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] = -1;
            }
            if ( num2 == 17U )
            {
                main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] = 1;
            }
            else if ( num2 == 16U )
            {
                for ( uint num3 = 3U; num3 < 16U; num3 += 4U )
                {
                    if ( main_work.is_clear_stage[( int )( ( UIntPtr )num3 )] != 1 )
                    {
                        num = 1U;
                    }
                }
                if ( num != 0U )
                {
                    main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] = -1;
                }
            }
            else if ( num2 < 16U && ( num2 + 1U ) % 4U == 0U )
            {
                for ( uint num3 = 0U; num3 < 3U; num3 += 1U )
                {
                    if ( main_work.is_clear_stage[( int )( ( UIntPtr )( num2 - 3U + num3 ) )] == 0 )
                    {
                        num = 1U;
                    }
                }
                if ( num != 0U )
                {
                    main_work.is_clear_stage[( int )( ( UIntPtr )num2 )] = -1;
                }
            }
            num = 0U;
        }
        if ( main_work.is_clear_stage[3] == 1 && main_work.is_clear_stage[7] == 1 && main_work.is_clear_stage[11] == 1 && main_work.is_clear_stage[15] == 1 )
        {
            main_work.is_final_open |= 1;
        }
        main_work.player_stock = AppMain.g_gs_main_sys_info.rest_player_num;
        for ( uint num2 = 0U; num2 < 7U; num2 += 1U )
        {
            if ( sspecial[( int )num2].IsGetEmerald() )
            {
                main_work.is_final_open |= 2;
                main_work.get_emerald |= 1U << ( int )num2;
                main_work.eme_stage_no[( int )( ( UIntPtr )num2 )] = AppMain.dm_stgslct_eme_get_act_no_tbl[( int )sspecial[( int )num2].GetEmeraldStage()];
            }
            else
            {
                main_work.is_clear_stage[( int )( ( UIntPtr )( 17U + num2 ) )] = -1;
            }
        }
    }

    // Token: 0x06001326 RID: 4902 RVA: 0x000A69A8 File Offset: 0x000A4BA8
    private void dmStgSlctSetAnnounceMsg( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        SSystem ssystem = SSystem.CreateInstance();
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenZoneSelect ) && main_work.is_clear_stage[0] == 1 )
        {
            main_work.announce_flag |= 4U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenZoneSelect, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenZone1Boss ) && main_work.is_clear_stage[0] == 1 && main_work.is_clear_stage[1] == 1 && main_work.is_clear_stage[2] == 1 )
        {
            main_work.announce_flag |= 8U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenZone1Boss, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenZone2Boss ) && main_work.is_clear_stage[4] == 1 && main_work.is_clear_stage[5] == 1 && main_work.is_clear_stage[6] == 1 )
        {
            main_work.announce_flag |= 16U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenZone2Boss, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenZone3Boss ) && main_work.is_clear_stage[8] == 1 && main_work.is_clear_stage[9] == 1 && main_work.is_clear_stage[10] == 1 )
        {
            main_work.announce_flag |= 32U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenZone3Boss, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenZone4Boss ) && main_work.is_clear_stage[12] == 1 && main_work.is_clear_stage[13] == 1 && main_work.is_clear_stage[14] == 1 )
        {
            main_work.announce_flag |= 64U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenZone4Boss, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenFinalZone ) && main_work.is_clear_stage[3] == 1 && main_work.is_clear_stage[7] == 1 && main_work.is_clear_stage[11] == 1 && main_work.is_clear_stage[15] == 1 )
        {
            main_work.announce_flag |= 128U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenFinalZone, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenSuperSonic ) && main_work.is_clear_stage[23] == 1 )
        {
            main_work.announce_flag |= 256U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenSuperSonic, true );
        }
        if ( !ssystem.IsAnnounce( SSystem.EAnnounce.OpenSpecialStage ) && ( main_work.is_final_open & 2 ) != 0 )
        {
            main_work.announce_flag |= 512U;
            ssystem.SetAnnounce( SSystem.EAnnounce.OpenSpecialStage, true );
        }
    }

    // Token: 0x06001327 RID: 4903 RVA: 0x000A6B9C File Offset: 0x000A4D9C
    private void dmStgSlctProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_STGSLCT_MAIN_WORK dms_STGSLCT_MAIN_WORK = (AppMain.DMS_STGSLCT_MAIN_WORK)tcb.work;
        if ( ( dms_STGSLCT_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.mtTaskClearTcb( tcb );
            this.dmStgSlctSetNextEvt( dms_STGSLCT_MAIN_WORK );
        }
        if ( ( dms_STGSLCT_MAIN_WORK.flag & 2147483648U ) != 0U && !AppMain.AoAccountIsCurrentEnable() )
        {
            dms_STGSLCT_MAIN_WORK.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFadeOut );
            dms_STGSLCT_MAIN_WORK.flag &= 2147483647U;
            dms_STGSLCT_MAIN_WORK.next_evt = 4;
            AppMain.IzFadeInitEasy( 1U, 1U, 32f );
            AppMain.DmSndBgmPlayerExit();
            dms_STGSLCT_MAIN_WORK.flag |= 33554432U;
            dms_STGSLCT_MAIN_WORK.flag &= 4294967291U;
            dms_STGSLCT_MAIN_WORK.flag &= 4294967293U;
            dms_STGSLCT_MAIN_WORK.proc_input = null;
            dms_STGSLCT_MAIN_WORK.proc_win_input = null;
            dms_STGSLCT_MAIN_WORK.win_timer = 0f;
            dms_STGSLCT_MAIN_WORK.win_cur_slct = 0;
            dms_STGSLCT_MAIN_WORK.win_mode = 1;
            dms_STGSLCT_MAIN_WORK.win_is_disp_cover = false;
        }
        this.dmStgSlctSetBgFadeEfct( dms_STGSLCT_MAIN_WORK );
        if ( dms_STGSLCT_MAIN_WORK.proc_win_update != null )
        {
            dms_STGSLCT_MAIN_WORK.proc_win_update( dms_STGSLCT_MAIN_WORK );
        }
        if ( dms_STGSLCT_MAIN_WORK.proc_menu_update != null )
        {
            dms_STGSLCT_MAIN_WORK.proc_menu_update( dms_STGSLCT_MAIN_WORK );
        }
        if ( dms_STGSLCT_MAIN_WORK.proc_draw != null )
        {
            dms_STGSLCT_MAIN_WORK.proc_draw( dms_STGSLCT_MAIN_WORK );
        }
    }

    // Token: 0x06001328 RID: 4904 RVA: 0x000A6CC4 File Offset: 0x000A4EC4
    private void dmStgSlctDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06001329 RID: 4905 RVA: 0x000A6CC8 File Offset: 0x000A4EC8
    private void dmStgSlctSetNextEvt( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        ushort num = (ushort)main_work.cur_stage;
        switch ( main_work.next_evt )
        {
            case 0:
                AppMain.g_gs_main_sys_info.stage_id = num;
                AppMain.g_gs_main_sys_info.prev_stage_id = ushort.MaxValue;
                AppMain.g_gs_main_sys_info.char_id[0] = 0;
                AppMain.g_gs_main_sys_info.game_mode = ( int )main_work.cur_game_mode;
                if ( main_work.is_clear_stage[23] == 1 )
                {
                    AppMain.g_gs_main_sys_info.game_flag |= 32U;
                }
                else
                {
                    AppMain.g_gs_main_sys_info.game_flag &= 4294967263U;
                }
                AppMain.g_gs_main_sys_info.game_flag &= 4294967167U;
                AppMain.GmMainGSInit();
                break;
            case 1:
                AppMain.g_gs_main_sys_info.stage_id = ( ushort )( num + 4 );
                AppMain.g_gs_main_sys_info.prev_stage_id = ushort.MaxValue;
                if ( main_work.is_clear_stage[23] == 1 )
                {
                    AppMain.g_gs_main_sys_info.game_flag |= 32U;
                }
                else
                {
                    AppMain.g_gs_main_sys_info.game_flag &= 4294967263U;
                }
                AppMain.g_gs_main_sys_info.game_mode = ( int )main_work.cur_game_mode;
                AppMain.g_gs_main_sys_info.game_flag &= 4294967167U;
                break;
            case 2:
                AppMain.dm_stgslct_is_stage_start = true;
                if ( main_work.cur_zone == 5U )
                {
                    AppMain.g_gs_main_sys_info.stage_id = ( ushort )( num + 4 );
                    AppMain.g_gs_main_sys_info.prev_stage_id = ushort.MaxValue;
                }
                else
                {
                    AppMain.g_gs_main_sys_info.stage_id = num;
                    AppMain.g_gs_main_sys_info.prev_stage_id = ushort.MaxValue;
                }
                if ( main_work.cur_game_mode == 0U )
                {
                    AppMain.g_gs_main_sys_info.game_mode = 0;
                }
                else
                {
                    AppMain.g_gs_main_sys_info.game_mode = 1;
                }
                break;
        }
        short evt_case = (short)main_work.next_evt;
        AppMain.SyDecideEvtCase( evt_case );
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x0600132A RID: 4906 RVA: 0x000A6E86 File Offset: 0x000A5086
    private void dmStgSlctLoadFontData( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        AppMain.GsFontBuild();
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctIsLoadFontData );
    }

    // Token: 0x0600132B RID: 4907 RVA: 0x000A6E9F File Offset: 0x000A509F
    private void dmStgSlctIsLoadFontData( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( AppMain.GsFontIsBuilded() )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctLoadRequest );
        }
    }

    // Token: 0x0600132C RID: 4908 RVA: 0x000A6EBC File Offset: 0x000A50BC
    private void dmStgSlctLoadRequest( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        main_work.arc_amb_fs[0] = AppMain.amFsReadBackground( "DEMO/STGSLCT/D_STGSLCT.AMB" );
        main_work.arc_amb_fs[1] = AppMain.amFsReadBackground( AppMain.dm_stgslct_main_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        for ( int i = 0; i < 4; i++ )
        {
            main_work.arc_cmn_amb_fs[i] = AppMain.amFsReadBackground( AppMain.dm_stgslct_menu_cmn_amb_name_tbl[i] );
        }
        main_work.arc_cmn_amb_fs[4] = AppMain.amFsReadBackground( AppMain.dm_stgslct_menu_cmn_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcLoadWait );
    }

    // Token: 0x0600132D RID: 4909 RVA: 0x000A6F40 File Offset: 0x000A5140
    private void dmStgSlctProcLoadWait( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( this.dmStgSlctIsDataLoad( main_work ) != 0 )
        {
            for ( int i = 0; i < 2; i++ )
            {
                main_work.arc_amb[i] = AppMain.readAMBFile( main_work.arc_amb_fs[i] );
                main_work.arc_amb_fs[i] = null;
                main_work.ama[i] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_amb[i], 0 ) );
                string dir;
                main_work.amb[i] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_amb[i], 1, out dir ) );
                main_work.amb[i].dir = dir;
                AppMain.amFsClearRequest( main_work.arc_amb_fs[i] );
                main_work.arc_amb_fs[i] = null;
                AppMain.AoTexBuild( main_work.tex[i], main_work.amb[i] );
                AppMain.AoTexLoad( main_work.tex[i] );
            }
            AppMain.GsFontBuild();
            AppMain.DmSndBgmPlayerInit();
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcLoadWait2 );
        }
    }

    // Token: 0x0600132E RID: 4910 RVA: 0x000A7024 File Offset: 0x000A5224
    private void dmStgSlctProcLoadWait2( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( this.dmStgSlctIsTexLoad( main_work ) == 1 && AppMain.DmSndBgmPlayerIsSndSysBuild() )
        {
            for ( int i = 0; i < 5; i++ )
            {
                main_work.arc_cmn_amb[i] = AppMain.readAMBFile( main_work.arc_cmn_amb_fs[i] );
                main_work.arc_cmn_amb_fs[i] = null;
                main_work.cmn_ama[i] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_cmn_amb[i], 0 ) );
                string dir;
                main_work.cmn_amb[i] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_cmn_amb[i], 1, out dir ) );
                main_work.cmn_amb[i].dir = dir;
                main_work.arc_cmn_amb_fs[i] = null;
                AppMain.AoTexBuild( main_work.cmn_tex[i], main_work.cmn_amb[i] );
                AppMain.AoTexLoad( main_work.cmn_tex[i] );
            }
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcTexBuildWait );
        }
    }

    // Token: 0x0600132F RID: 4911 RVA: 0x000A70FB File Offset: 0x000A52FB
    private void dmStgSlctProcTexBuildWait( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( this.dmStgSlctIsTexLoad2( main_work ) == 1 && AppMain.DmSndBgmPlayerIsSndSysBuild() )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcCheckLoadingEnd );
            AppMain.DmSaveMenuStart( true, false );
        }
    }

    // Token: 0x06001330 RID: 4912 RVA: 0x000A7127 File Offset: 0x000A5327
    private void dmStgSlctProcCheckLoadingEnd( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcCreateAct );
            AppMain.DmSndBgmPlayerPlayBgm( 0 );
            main_work.flag |= 2147483648U;
        }
    }

    // Token: 0x06001331 RID: 4913 RVA: 0x000A715C File Offset: 0x000A535C
    private void dmStgSlctProcCreateAct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 116U; num += 1U )
        {
            AppMain.A2S_AMA_HEADER ama;
            AppMain.AOS_TEXTURE tex;
            if ( num >= 112U )
            {
                ama = main_work.cmn_ama[4];
                tex = main_work.cmn_tex[4];
            }
            else if ( 104U <= num && num <= 105U )
            {
                ama = main_work.cmn_ama[3];
                tex = main_work.cmn_tex[3];
            }
            else if ( 106U <= num && num <= 111U )
            {
                ama = main_work.cmn_ama[3];
                tex = main_work.cmn_tex[3];
            }
            else if ( num >= 96U )
            {
                ama = main_work.cmn_ama[1];
                tex = main_work.cmn_tex[1];
            }
            else if ( num >= 93U )
            {
                ama = main_work.cmn_ama[0];
                tex = main_work.cmn_tex[0];
            }
            else if ( num >= 88U )
            {
                ama = main_work.ama[1];
                tex = main_work.tex[1];
            }
            else if ( num == 18U || ( num >= 72U && num <= 75U ) || num == 39U || num == 63U || num == 65U )
            {
                ama = main_work.ama[1];
                tex = main_work.tex[1];
            }
            else
            {
                ama = main_work.ama[0];
                tex = main_work.tex[0];
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_stg_slct[( int )( ( UIntPtr )num )] );
        }
        AppMain.AoActUpdate( main_work.act[57], 0f );
        main_work.act_tab_state_move_base_pos[0] = main_work.act[57].sprite.center_x;
        main_work.act_tab_state_move_base_pos[1] = main_work.act[57].sprite.center_y;
        int i = 0;
        int num2 = AppMain.arrayof(main_work.trg_zone);
        while ( i < num2 )
        {
            main_work.trg_zone[i].Create( main_work.act[37] );
            i++;
        }
        int j = 0;
        int num3 = AppMain.arrayof(main_work.trg_act);
        while ( j < num3 )
        {
            main_work.trg_act[j].Create( main_work.act[58] );
            j++;
        }
        int k = 0;
        int num4 = AppMain.arrayof(main_work.trg_act_tab);
        while ( k < num4 )
        {
            main_work.trg_act_tab[k].Create( main_work.act[43 + k] );
            k++;
        }
        int l = 0;
        int num5 = AppMain.arrayof(main_work.trg_act_lr);
        while ( l < num5 )
        {
            CTrgAoAction ctrgAoAction = main_work.trg_act_lr[l];
            int num6 = (l == 0) ? 49 : 50;
            ctrgAoAction.Create( main_work.act[num6] );
            l++;
        }
        CTrgFlick trg_act_move = main_work.trg_act_move;
        trg_act_move.Create( 50, 90, ( int )AppMain.AMD_SCREEN_2D_WIDTH - 100, 258 );
        trg_act_move.SetMoveThreshold( 4 );
        int m = 0;
        int num7 = AppMain.arrayof(main_work.trg_mode);
        while ( m < num7 )
        {
            CTrgAoAction ctrgAoAction2 = main_work.trg_mode[m];
            int num8 = (m == 0) ? 52 : 55;
            ctrgAoAction2.Create( main_work.act[num8] );
            m++;
        }
        CTrgAoAction trg_cancel = main_work.trg_cancel;
        trg_cancel.Create( main_work.act[105] );
        int n = 0;
        int num9 = AppMain.arrayof(main_work.trg_answer);
        while ( n < num9 )
        {
            CTrgAoAction ctrgAoAction3 = main_work.trg_answer[n];
            int num10 = (n == 0) ? 110 : 107;
            ctrgAoAction3.Create( main_work.act[num10] );
            n++;
        }
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcSetDispEfctData );
    }

    // Token: 0x06001332 RID: 4914 RVA: 0x000A74A0 File Offset: 0x000A56A0
    private void dmStgSlctProcSetDispEfctData( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        if ( ( main_work.announce_flag & 4U ) != 0U || ( main_work.announce_flag & 512U ) != 0U || ( main_work.announce_flag & 128U ) != 0U )
        {
            main_work.flag |= 131072U;
        }
        if ( AppMain.dm_stgslct_is_stage_start && ( main_work.flag & 131072U ) == 0U )
        {
            main_work.proc_draw = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_draw_( this.dmStgSlctStageSelectDraw );
            main_work.state = 1;
        }
        else
        {
            main_work.proc_draw = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_draw_( this.dmStgSlctZoneSelectDraw );
            main_work.state = 0;
            main_work.cur_zone = ( main_work.cur_zone = uint.MaxValue );
        }
        if ( main_work.state == 0 )
        {
            if ( main_work.is_final_open == 3 )
            {
                for ( uint num3 = 0U; num3 < 6U; num3 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num3 )][0] = AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )num3 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num3 )][1] = AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )num3 )][1];
                }
            }
            else if ( ( main_work.is_final_open & 2 ) != 0 )
            {
                for ( uint num4 = 0U; num4 < 6U; num4 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num4 )][0] = AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )num4 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num4 )][1] = AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )num4 )][1];
                }
            }
            else if ( ( main_work.is_final_open & 1 ) != 0 )
            {
                for ( uint num5 = 0U; num5 < 6U; num5 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num5 )][0] = AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )num5 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num5 )][1] = AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )num5 )][1];
                }
            }
            else
            {
                for ( uint num6 = 0U; num6 < 6U; num6 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num6 )][0] = AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )num6 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num6 )][1] = AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )num6 )][1];
                }
            }
            for ( uint num7 = 0U; num7 < 24U; num7 += 1U )
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num7 )] = 1120f;
                main_work.act_top_pos_y[( int )( ( UIntPtr )num7 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num7 )];
            }
            main_work.mode_tex_pos_y = 180f;
            main_work.chaos_eme_pos_y = 0f;
            main_work.mode_tex_move_frm = 0U;
        }
        else
        {
            if ( main_work.is_final_open == 3 )
            {
                for ( uint num8 = 0U; num8 < 6U; num8 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num8 )][0] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num8 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num8 )][1] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num8 )][1];
                }
            }
            else if ( ( main_work.is_final_open & 2 ) != 0 )
            {
                for ( uint num9 = 0U; num9 < 6U; num9 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num9 )][0] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num9 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num9 )][1] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num9 )][1];
                }
            }
            else if ( ( main_work.is_final_open & 1 ) != 0 )
            {
                for ( uint num10 = 0U; num10 < 6U; num10 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num10 )][0] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num10 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num10 )][1] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num10 )][1];
                }
            }
            else
            {
                for ( uint num11 = 0U; num11 < 6U; num11 += 1U )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num11 )][0] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num11 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num11 )][1] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num11 )][1];
                }
            }
            for ( uint num12 = num; num12 < num2; num12 += 1U )
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num12 )] = 100f;
                if ( main_work.cur_zone != 5U )
                {
                    main_work.act_top_pos_y[( int )( ( UIntPtr )num12 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num12 )];
                }
                else
                {
                    main_work.act_top_pos_y[( int )( ( UIntPtr )num12 )] = this.dm_stgslct_act_tab_disp_y_pos_tbl[main_work.focus_disp_no];
                }
            }
            this.dmStgSlctStageSelectChngZoneSetInZoneScroll( main_work, main_work.cur_stage );
            main_work.mode_tex_pos_y = 0f;
            main_work.chaos_eme_pos_y = 180f;
            main_work.mode_tex_move_frm = 5U;
        }
        main_work.crsr_pos_y = AppMain.dm_stgslct_act_disp_y_pos_tbl[0];
        main_work.proc_draw = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_draw_( this.dmStgSlctProcActDraw );
        AppMain.IzFadeInitEasy( 0U, 0U, 32f );
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFadeIn );
    }

    // Token: 0x06001333 RID: 4915 RVA: 0x000A78B4 File Offset: 0x000A5AB4
    private void dmStgSlctProcFadeIn( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            if ( ( main_work.flag & 131072U ) != 0U )
            {
                AppMain.IzFadeInitEasy( 0U, 3U, 32f );
                main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcSetWhiteFlashEfct );
                return;
            }
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcSetSlctStartData );
        }
    }

    // Token: 0x06001334 RID: 4916 RVA: 0x000A790C File Offset: 0x000A5B0C
    private void dmStgSlctProcSetWhiteFlashEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeInitEasy( 0U, 2U, 32f );
            main_work.flag &= 4294836223U;
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcIsWhiteFlashEfctEnd );
        }
    }

    // Token: 0x06001335 RID: 4917 RVA: 0x000A7945 File Offset: 0x000A5B45
    private void dmStgSlctProcIsWhiteFlashEfctEnd( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcSetSlctStartData );
        }
    }

    // Token: 0x06001336 RID: 4918 RVA: 0x000A7968 File Offset: 0x000A5B68
    private void dmStgSlctProcSetSlctStartData( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle );
        if ( main_work.state == 0 )
        {
            main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcZoneSelect );
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcZoneSelectIdle );
        }
        else
        {
            main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelect );
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectIdle );
            main_work.disp_flag |= 2U;
        }
        main_work.zone_scr_id = 0U;
    }

    // Token: 0x06001337 RID: 4919 RVA: 0x000A79F0 File Offset: 0x000A5BF0
    private void dmStgSlctProcZoneSelectIdle( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        CTrgAoAction trg_cancel = main_work.trg_cancel;
        float num = main_work.act[104].frame;
        if ( trg_cancel.GetState( 0U )[10] && trg_cancel.GetState( 0U )[1] )
        {
            num = 2f;
        }
        else if ( trg_cancel.GetState( 0U )[0] )
        {
            num = 1f;
        }
        else if ( 2f > num )
        {
            num = 0f;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int i = 104; i <= 105; i++ )
        {
            AppMain.AoActSetFrame( main_work.act[i], num );
            AppMain.AoActUpdate( main_work.act[i], 0f );
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
            main_work.proc_win_input = null;
            main_work.proc_input = null;
            main_work.proc_win_update = null;
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFadeOut );
            main_work.next_evt = 3;
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            AppMain.DmSoundPlaySE( "Cancel" );
            return;
        }
        if ( ( main_work.flag & 4U ) != 0U )
        {
            AppMain.DmSoundPlaySE( "Ok" );
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcZoneSelectDecideEfct );
            main_work.flag |= 262144U;
            main_work.timer = 0;
            return;
        }
        this.dmStgSlctSetZoneScrChangeEfct( main_work );
    }

    // Token: 0x06001338 RID: 4920 RVA: 0x000A7B68 File Offset: 0x000A5D68
    private void dmStgSlctProcZoneSelectDecideEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        main_work.timer++;
        this.dmStgSlctSetDecideZoneEfctPos( main_work );
        if ( this.dmStgSlctIsDecideZoneEfctPos( main_work ) )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcZoneSelectOutEfct );
            main_work.flag &= 4294967291U;
            for ( uint num = 0U; num < 6U; num += 1U )
            {
                if ( main_work.cur_zone != num )
                {
                    main_work.efct_out_flag |= 1U << ( int )num;
                }
            }
            main_work.decide_zone_efct_dist_x = 0;
            main_work.decide_zone_efct_dist_y = 0;
            main_work.cur_stage = ( int )AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
            main_work.prev_stage = main_work.cur_stage;
            main_work.proc_input = null;
            main_work.timer = 0;
            main_work.trg_act_move.ResetState();
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
            return;
        }
        this.dmStgSlctSetZoneScrChangeEfct( main_work );
    }

    // Token: 0x06001339 RID: 4921 RVA: 0x000A7C50 File Offset: 0x000A5E50
    private void dmStgSlctProcZoneSelectOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        if ( this.dmStgSlctIsZonePosOutEfct( main_work ) )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectInEfct );
            main_work.efct_time = 0U;
            for ( uint num3 = 0U; num3 < 6U; num3 += 1U )
            {
                if ( main_work.cur_zone != num3 )
                {
                    main_work.zone_pos[( int )( ( UIntPtr )num3 )][0] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num3 )][0];
                    main_work.zone_pos[( int )( ( UIntPtr )num3 )][1] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num3 )][1];
                }
            }
            for ( uint num4 = num; num4 < num2; num4 += 1U )
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num4 )] = 1120f;
                if ( main_work.cur_zone != 5U )
                {
                    main_work.act_top_pos_y[( int )( ( UIntPtr )num4 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num4 )];
                }
                else
                {
                    main_work.act_top_pos_y[( int )( ( UIntPtr )num4 )] = this.dm_stgslct_act_tab_disp_y_pos_tbl[0];
                }
            }
            main_work.state = 1;
            main_work.mode_tex_move_frm = 0U;
            main_work.is_disp_cover = false;
            this.dmStgSlctStageSelectChngZoneSetInZoneScroll( main_work );
            return;
        }
        this.dmStgSlctSetZonePosOutEfct( main_work );
        if ( main_work.efct_time == 20U )
        {
            main_work.efct_out_flag |= 1U << ( int )main_work.cur_zone;
        }
        main_work.efct_time += 1U;
        this.dmStgSlctSetZoneScrChangeEfct( main_work );
    }

    // Token: 0x0600133A RID: 4922 RVA: 0x000A7D8C File Offset: 0x000A5F8C
    private void dmStgSlctProcStageSelectInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        this.dmStgSlctSetStagePosInEfct( main_work );
        if ( !this.dmStgSlctIsStagePosInEfct( main_work ) )
        {
            main_work.mode_tex_move_frm += 1U;
            if ( main_work.mode_tex_move_frm > 5U )
            {
                main_work.mode_tex_move_frm = 5U;
            }
            return;
        }
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectIdle );
        if ( main_work.proc_win_update == new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle ) )
        {
            main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelect );
        }
        main_work.disp_flag |= 2U;
        main_work.crsr_idx = 0;
        if ( main_work.cur_zone != 4U )
        {
            main_work.crsr_pos_y = this.dm_stgslct_act_crsr_disp_y_pos_tbl[main_work.crsr_idx];
            return;
        }
        main_work.crsr_pos_y = 320f;
    }

    // Token: 0x0600133B RID: 4923 RVA: 0x000A7E44 File Offset: 0x000A6044
    private void dmStgSlctProcStageSelectIdle( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        CTrgAoAction trg_cancel = main_work.trg_cancel;
        float num = main_work.act[104].frame;
        if ( !main_work.trg_act_move.GetState( 0U )[15] && trg_cancel.GetState( 0U )[14] )
        {
            if ( trg_cancel.GetState( 0U )[10] && trg_cancel.GetState( 0U )[1] )
            {
                num = 2f;
            }
            else if ( trg_cancel.GetState( 0U )[0] )
            {
                num = 1f;
            }
            else
            {
                num = 0f;
            }
        }
        else if ( 2f > num )
        {
            num = 0f;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int i = 104; i <= 105; i++ )
        {
            AppMain.AoActSetFrame( main_work.act[i], num );
            AppMain.AoActUpdate( main_work.act[i], 0f );
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectOutEfct );
            AppMain.DmSoundPlaySE( "Cancel" );
            main_work.flag &= 4294967293U;
            main_work.proc_input = null;
            main_work.disp_flag &= 4294967293U;
            return;
        }
        if ( ( main_work.flag & 4U ) != 0U )
        {
            if ( !this.dmStgSlctIsCanSelectAct( main_work ) )
            {
                main_work.flag &= 4294967291U;
                main_work.is_disp_cover = false;
                return;
            }
            AppMain.DmSoundPlaySE( "Ok" );
            main_work.flag &= 4294967291U;
            main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowOpenEfct );
            main_work.proc_input = null;
            main_work.proc_win_input = null;
            main_work.win_timer = 0f;
            main_work.win_cur_slct = 0;
            main_work.win_mode = 1;
            main_work.win_is_disp_cover = false;
            main_work.win_timer = -10.5f;
            return;
        }
        else
        {
            if ( ( main_work.flag & 524288U ) != 0U )
            {
                main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFadeOut );
                AppMain.IzFadeInitEasy( 0U, 1U, 32f );
                main_work.next_evt = 2;
                AppMain.DmSoundPlaySE( "Ok" );
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 0f;
                main_work.win_cur_slct = 0;
                main_work.flag &= 4294443007U;
                return;
            }
            if ( ( main_work.flag & 32U ) != 0U )
            {
                main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectChngZone );
                main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelectChngZone );
                AppMain.DmSoundPlaySE( "Cursol" );
                main_work.timer = 0;
                this.dmStgSlctStageSelectChngZoneSetInZoneScroll( main_work );
                return;
            }
            if ( ( main_work.flag & 64U ) != 0U )
            {
                main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectChngVrtclAct );
                main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelectMove );
                this.dmStgSlctSetFocusChangeEfctData( main_work );
                main_work.timer = 0;
            }
            return;
        }
    }

    // Token: 0x0600133C RID: 4924 RVA: 0x000A8108 File Offset: 0x000A6308
    private void dmStgSlctProcStageSelectChngZone( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( this.dmStgSlctIsStageZoneChangeEfct( main_work ) )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectIdle );
            if ( main_work.proc_win_update == new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle ) )
            {
                main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelect );
            }
            main_work.flag &= 4294967263U;
            return;
        }
        this.dmStgSlctSetStageZoneChangeEfct( main_work );
    }

    // Token: 0x0600133D RID: 4925 RVA: 0x000A8188 File Offset: 0x000A6388
    private void dmStgSlctProcStageSelectChngVrtclAct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( ( main_work.flag & 2048U ) != 0U || ( main_work.flag & 4096U ) != 0U )
        {
            this.dmStgSlctSetFocusChangeEfctData( main_work );
            AppMain.DmSoundPlaySE( "Cursol" );
            main_work.timer = 0;
            main_work.flag &= 4294965247U;
            main_work.flag &= 4294963199U;
            return;
        }
        if ( ( main_work.flag & 64U ) == 0U && ( main_work.flag & 128U ) == 0U )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectIdle );
            if ( main_work.proc_win_update == new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle ) )
            {
                main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelect );
            }
            main_work.timer = 0;
            return;
        }
        if ( ( main_work.flag & 64U ) != 0U )
        {
            this.dmStgSlctSetStageVrtclChangeEfct( main_work );
            if ( this.dmStgSlctIsStageVrtclChangeEfct( main_work ) )
            {
                main_work.flag &= 4294967231U;
            }
        }
        if ( ( main_work.flag & 128U ) != 0U )
        {
            this.dmStgSlctSetStageCrsrChangeEfct( main_work );
            if ( this.dmStgSlctIsStageCrsrChangeEfct( main_work ) )
            {
                main_work.flag &= 4294967167U;
            }
        }
        main_work.timer++;
    }

    // Token: 0x0600133E RID: 4926 RVA: 0x000A82C8 File Offset: 0x000A64C8
    private void dmStgSlctProcStageSelectOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( this.dmStgSlctIsStagePosOutEfct( main_work ) )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcZoneSelectInEfct );
            main_work.state = 0;
            for ( int i = 0; i < 6; i++ )
            {
                if ( main_work.is_final_open == 3 )
                {
                    main_work.zone_pos[i][0] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[i][0];
                    main_work.zone_pos[i][1] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[i][1];
                }
                else if ( ( main_work.is_final_open & 2 ) != 0 )
                {
                    main_work.zone_pos[i][0] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[i][0];
                    main_work.zone_pos[i][1] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[i][1];
                }
                else if ( ( main_work.is_final_open & 1 ) != 0 )
                {
                    main_work.zone_pos[i][0] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[i][0];
                    main_work.zone_pos[i][1] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[i][1];
                }
                else
                {
                    main_work.zone_pos[i][0] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[i][0];
                    main_work.zone_pos[i][1] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[i][1];
                }
            }
            main_work.mode_tex_move_frm = 0U;
            main_work.zone_scr_id = 0U;
            main_work.is_disp_cover = false;
            return;
        }
        this.dmStgSlctSetStagePosOutEfct( main_work );
        main_work.mode_tex_move_frm += 1U;
        if ( main_work.mode_tex_move_frm > 10U )
        {
            main_work.mode_tex_move_frm = 10U;
        }
    }

    // Token: 0x0600133F RID: 4927 RVA: 0x000A8408 File Offset: 0x000A6608
    private void dmStgSlctProcZoneSelectInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( this.dmStgSlctIsZonePosInEfct( main_work ) )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcZoneSelectIdle );
            for ( int i = 0; i < 6; i++ )
            {
                if ( main_work.is_final_open == 3 )
                {
                    for ( uint num = 0U; num < 6U; num += 1U )
                    {
                        main_work.zone_pos[( int )( ( UIntPtr )num )][0] = AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][0];
                        main_work.zone_pos[( int )( ( UIntPtr )num )][1] = AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][1];
                    }
                }
                else if ( ( main_work.is_final_open & 2 ) != 0 )
                {
                    for ( uint num2 = 0U; num2 < 6U; num2 += 1U )
                    {
                        main_work.zone_pos[( int )( ( UIntPtr )num2 )][0] = AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )num2 )][0];
                        main_work.zone_pos[( int )( ( UIntPtr )num2 )][1] = AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )num2 )][1];
                    }
                }
                else if ( ( main_work.is_final_open & 1 ) != 0 )
                {
                    for ( uint num3 = 0U; num3 < 6U; num3 += 1U )
                    {
                        main_work.zone_pos[( int )( ( UIntPtr )num3 )][0] = AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )num3 )][0];
                        main_work.zone_pos[( int )( ( UIntPtr )num3 )][1] = AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )num3 )][1];
                    }
                }
                else
                {
                    for ( uint num4 = 0U; num4 < 6U; num4 += 1U )
                    {
                        main_work.zone_pos[( int )( ( UIntPtr )num4 )][0] = AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )num4 )][0];
                        main_work.zone_pos[( int )( ( UIntPtr )num4 )][1] = AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )num4 )][1];
                    }
                }
            }
            if ( main_work.proc_win_update == new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle ) )
            {
                main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcZoneSelect );
            }
            return;
        }
        this.dmStgSlctSetZonePosInEfct( main_work );
        main_work.cur_zone = uint.MaxValue;
    }

    // Token: 0x06001340 RID: 4928 RVA: 0x000A8588 File Offset: 0x000A6788
    private void dmStgSlctProcWindowNodispIdle( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.proc_win_input != null )
        {
            main_work.proc_win_input( main_work );
        }
        if ( ( main_work.flag & 8U ) != 0U || main_work.announce_flag != 0U )
        {
            main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowOpenEfct );
            main_work.proc_input = null;
            main_work.proc_win_input = null;
            main_work.win_timer = 0f;
            for ( uint num = 2U; num < 10U; num += 1U )
            {
                if ( ( ( ulong )main_work.announce_flag & ( ulong )( 1L << ( int )( num & 31U ) ) ) != 0UL )
                {
                    main_work.win_mode = ( int )num;
                    break;
                }
            }
            main_work.flag &= 4294967287U;
            AppMain.DmSoundPlaySE( "Window" );
        }
    }

    // Token: 0x06001341 RID: 4929 RVA: 0x000A8628 File Offset: 0x000A6828
    private void dmStgSlctProcWindowOpenEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 16U ) != 0U )
        {
            main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowAnnounceIdle );
            main_work.proc_win_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_input_( this.dmStgSlctInputProcWinDispIdle );
            AppMain.ArrayPointer<AppMain.AOS_ACTION> arrayPointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 106);
            AppMain.ArrayPointer<AppMain.AOS_ACTION> pointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 112);
            while ( arrayPointer != pointer )
            {
                AppMain.AoActSetFrame( ~arrayPointer, 0f );
                arrayPointer = ++arrayPointer;
            }
            int i = 0;
            int num = AppMain.arrayof(main_work.trg_answer);
            while ( i < num )
            {
                main_work.trg_answer[i].ResetState();
                i++;
            }
            main_work.disp_flag |= 1U;
            main_work.flag &= 4294967279U;
        }
        else
        {
            this.dmStgSlctSetWinOpenEfct( main_work );
        }
        this.dmStgSlctWinSelectDraw( main_work );
    }

    // Token: 0x06001342 RID: 4930 RVA: 0x000A86FC File Offset: 0x000A68FC
    private void dmStgSlctProcWindowAnnounceIdle( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.proc_win_input != null )
        {
            main_work.proc_win_input( main_work );
        }
        if ( main_work.win_mode == 0 )
        {
            if ( ( main_work.flag & 4U ) != 0U )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFadeOut );
                AppMain.IzFadeInitEasy( 0U, 1U, 32f );
                if ( main_work.win_cur_slct == 0 )
                {
                    main_work.next_evt = 2;
                    AppMain.DmSoundPlaySE( "Ok" );
                }
                else
                {
                    main_work.next_evt = 3;
                    AppMain.DmSoundPlaySE( "Ok" );
                }
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
            }
            else if ( ( main_work.flag & 2U ) != 0U )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowCloseEfct );
                AppMain.DmSoundPlaySE( "Cancel" );
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
            }
        }
        else if ( main_work.win_mode != 1 )
        {
            if ( ( main_work.flag & 4U ) != 0U || ( main_work.flag & 2U ) != 0U )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowCloseEfct );
                AppMain.DmSoundPlaySE( "Ok" );
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
            }
        }
        else if ( ( main_work.flag & 4U ) != 0U && main_work.win_cur_slct == 0 )
        {
            main_work.proc_input = null;
            main_work.proc_win_input = null;
            main_work.win_timer = 8f;
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFadeOut );
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            if ( main_work.cur_zone == 5U )
            {
                main_work.next_evt = 1;
            }
            else
            {
                main_work.next_evt = 0;
            }
            AppMain.DmSndBgmPlayerExit();
            main_work.flag |= 33554432U;
            AppMain.DmSoundPlaySE( "Ok" );
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
        }
        else if ( ( main_work.flag & 4U ) != 0U || ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_input = null;
            main_work.proc_win_input = null;
            main_work.win_timer = 8f;
            main_work.disp_flag &= 4294967294U;
            main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowCloseEfct );
            if ( ( main_work.flag & 2U ) != 0U )
            {
                AppMain.DmSoundPlaySE( "Cancel" );
            }
            else
            {
                AppMain.DmSoundPlaySE( "Ok" );
            }
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
        }
        this.dmStgSlctWinSelectDraw( main_work );
    }

    // Token: 0x06001343 RID: 4931 RVA: 0x000A89F8 File Offset: 0x000A6BF8
    private void dmStgSlctProcWindowCloseEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 16U ) != 0U )
        {
            main_work.proc_win_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle );
            main_work.announce_flag &= ~( 1U << main_work.win_mode );
            if ( main_work.announce_flag == 0U )
            {
                if ( main_work.state == 0 )
                {
                    main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcZoneSelect );
                }
                else if ( main_work.state == 1 )
                {
                    main_work.proc_input = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_input_( this.dmStgSlctInputProcStageSelect );
                    main_work.is_disp_cover = false;
                }
            }
            main_work.flag &= 4294967279U;
        }
        this.dmStgSlctSetWinCloseEfct( main_work );
        this.dmStgSlctWinSelectDraw( main_work );
    }

    // Token: 0x06001344 RID: 4932 RVA: 0x000A8AA1 File Offset: 0x000A6CA1
    private void dmStgSlctProcFadeOut( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_win_update = null;
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStopDraw );
            main_work.proc_draw = null;
            main_work.timer = 0;
        }
    }

    // Token: 0x06001345 RID: 4933 RVA: 0x000A8AD1 File Offset: 0x000A6CD1
    private void dmStgSlctProcStopDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcDataRelease );
    }

    // Token: 0x06001346 RID: 4934 RVA: 0x000A8AE8 File Offset: 0x000A6CE8
    private void dmStgSlctProcDataRelease( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexRelease( main_work.tex[i] );
        }
        for ( int j = 0; j < 5; j++ )
        {
            AppMain.AoTexRelease( main_work.cmn_tex[j] );
        }
        main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcFinish );
    }

    // Token: 0x06001347 RID: 4935 RVA: 0x000A8B3C File Offset: 0x000A6D3C
    private void dmStgSlctProcFinish( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( this.dmStgSlctIsTexRelease( main_work ) == 1 )
        {
            for ( int i = 0; i < main_work.trg_zone.Length; i++ )
            {
                main_work.trg_zone[i].Release();
            }
            for ( int j = 0; j < main_work.trg_act.Length; j++ )
            {
                main_work.trg_act[j].Release();
            }
            for ( int k = 0; k < main_work.trg_act_tab.Length; k++ )
            {
                main_work.trg_act_tab[k].Release();
            }
            for ( int l = 0; l < main_work.trg_act_lr.Length; l++ )
            {
                main_work.trg_act_lr[l].Release();
            }
            CTrgFlick trg_act_move = main_work.trg_act_move;
            trg_act_move.Release();
            for ( int m = 0; m < main_work.trg_mode.Length; m++ )
            {
                main_work.trg_mode[m].Release();
            }
            CTrgAoAction trg_cancel = main_work.trg_cancel;
            trg_cancel.Release();
            for ( int n = 0; n < main_work.trg_answer.Length; n++ )
            {
                main_work.trg_answer[n].Release();
            }
            for ( int num = 0; num < 116; num++ )
            {
                if ( main_work.act[num] != null )
                {
                    AppMain.AoActDelete( main_work.act[num] );
                    main_work.act[num] = null;
                }
            }
            for ( int num2 = 0; num2 < 2; num2++ )
            {
                main_work.arc_amb[num2] = null;
            }
            for ( int num3 = 0; num3 < 5; num3++ )
            {
                main_work.arc_cmn_amb[num3] = null;
            }
            main_work.proc_win_update = null;
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcWaitFinished );
        }
    }

    // Token: 0x06001348 RID: 4936 RVA: 0x000A8CC0 File Offset: 0x000A6EC0
    private void dmStgSlctProcWaitFinished( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 33554432U ) != 0U )
        {
            if ( AppMain.DmSndBgmPlayerIsTaskExit() )
            {
                main_work.flag |= 1U;
                main_work.proc_win_update = null;
                main_work.proc_menu_update = null;
                main_work.flag &= 4261412863U;
                return;
            }
        }
        else
        {
            main_work.flag |= 1U;
            main_work.proc_win_update = null;
            main_work.proc_menu_update = null;
        }
    }

    // Token: 0x06001349 RID: 4937 RVA: 0x000A8D48 File Offset: 0x000A6F48
    private void dmStgSlctInputProcZoneSelect( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint cur_zone = main_work.cur_zone;
        if ( ( main_work.trg_cancel.GetState( 0U )[10] && main_work.trg_cancel.GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
        {
            main_work.flag |= 2U;
            AppMain.setBackKeyRequest( false );
            return;
        }
        for ( int i = 0; i < AppMain.arrayof( main_work.trg_zone ); i++ )
        {
            int[] array = new int[]
            {
                0,
                1,
                2,
                3,
                4,
                5
            };
            CTrgAoAction ctrgAoAction = main_work.trg_zone[i];
            if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
            {
                main_work.cur_zone = ( uint )array[i];
                main_work.flag |= 4U;
                break;
            }
            if ( ctrgAoAction.GetState( 0U )[2] )
            {
                main_work.cur_zone = ( uint )array[i];
                main_work.is_disp_cover = true;
                break;
            }
            if ( ctrgAoAction.GetState( 0U )[13] )
            {
                main_work.cur_zone = uint.MaxValue;
                main_work.is_disp_cover = false;
            }
        }
        if ( main_work.cur_zone == 7U )
        {
            main_work.cur_zone = cur_zone;
        }
    }

    // Token: 0x0600134A RID: 4938 RVA: 0x000A8E60 File Offset: 0x000A7060
    private void dmStgSlctInputProcStageSelect( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = num + AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        uint num3 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        if ( main_work.is_clear_stage[3] == 1 && main_work.is_clear_stage[7] == 1 && main_work.is_clear_stage[11] == 1 )
        {
            int num4 = main_work.is_clear_stage[15];
        }
        uint num5 = 17U;
        while ( num5 < 24U && main_work.is_clear_stage[( int )( ( UIntPtr )num5 )] == -1 )
        {
            num5 += 1U;
        }
        if ( AppMain.isBackKeyPressed() || ( !main_work.trg_act_move.GetState( 0U )[15] && main_work.trg_cancel.GetState( 0U )[14] && main_work.trg_cancel.GetState( 0U )[10] && main_work.trg_cancel.GetState( 0U )[1] ) )
        {
            AppMain.setBackKeyRequest( false );
            main_work.flag |= 2U;
            return;
        }
        float num6;
        if ( !main_work.trg_act_move.GetState( 0U )[15] && ( main_work.trg_mode[0].GetState( 0U )[14] || main_work.trg_mode[1].GetState( 0U )[14] ) )
        {
            if ( main_work.trg_mode[0].GetState( 0U )[10] && main_work.trg_mode[0].GetState( 0U )[1] )
            {
                num6 = 2f;
            }
            else if ( main_work.trg_mode[1].GetState( 0U )[10] && main_work.trg_mode[1].GetState( 0U )[1] )
            {
                num6 = 2f;
            }
            else if ( main_work.trg_mode[0].GetState( 0U )[0] || main_work.trg_mode[1].GetState( 0U )[0] )
            {
                num6 = 1f;
            }
            else
            {
                num6 = 0f;
            }
        }
        else if ( 2f < main_work.act[51].frame )
        {
            num6 = -1f;
        }
        else
        {
            num6 = 0f;
        }
        if ( 0f <= num6 )
        {
            if ( 2f == num6 )
            {
                main_work.cur_game_mode ^= 1U;
                AppMain.DmSoundPlaySE( "Cursol" );
            }
            AppMain.ArrayPointer<AppMain.AOS_ACTION> arrayPointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 51);
            AppMain.ArrayPointer<AppMain.AOS_ACTION> pointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 57);
            while ( arrayPointer != pointer )
            {
                AppMain.AoActSetFrame( ~arrayPointer, num6 );
                arrayPointer = ++arrayPointer;
            }
            AppMain.ArrayPointer<AppMain.AOS_ACTION> arrayPointer2 = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 88);
            AppMain.ArrayPointer<AppMain.AOS_ACTION> pointer2 = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 90);
            while ( arrayPointer2 != pointer2 )
            {
                AppMain.AoActSetFrame( ~arrayPointer2, num6 );
                arrayPointer2 = ++arrayPointer2;
            }
        }
        uint num7 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        if ( 3U < num7 )
        {
            num7 = 3U;
        }
        uint num8 = (uint)main_work.focus_disp_no;
        uint num9 = num8 + num7;
        while ( num8 < num9 )
        {
            CTrgAoAction ctrgAoAction = main_work.trg_act[(int)((UIntPtr)num8)];
            if ( ctrgAoAction.GetState( 0U )[8] )
            {
                main_work.cur_stage = ( int )( num + num8 );
                main_work.is_disp_cover = true;
            }
            if ( ctrgAoAction.GetState( 0U )[13] )
            {
                main_work.is_disp_cover = false;
            }
            if ( ctrgAoAction.GetState( 0U )[4] )
            {
                main_work.cur_stage = ( int )( num + num8 );
                main_work.is_disp_cover = true;
                main_work.flag |= 4U;
                return;
            }
            num8 += 1U;
        }
        bool flag = false;
        bool flag2 = false;
        bool flag3 = false;
        int is_final_open = main_work.is_final_open;
        int i = 0;
        int num10 = AppMain.arrayof(main_work.trg_act_tab);
        while ( i < num10 )
        {
            int num11 = i;
            if ( ( 2 & is_final_open ) == 0 || ( 1 & is_final_open ) != 0 )
            {
                goto IL_3AD;
            }
            switch ( i )
            {
                case 4:
                    num11 = 5;
                    goto IL_3AD;
                case 5:
                    break;
                default:
                    goto IL_3AD;
            }
            IL_3FE:
            i++;
            continue;
            IL_3AD:
            CTrgAoAction ctrgAoAction2 = main_work.trg_act_tab[i];
            if ( !ctrgAoAction2.GetState( 0U )[8] || ( ulong )main_work.cur_zone == ( ulong )( ( long )num11 ) )
            {
                goto IL_3FE;
            }
            main_work.chng_zone = main_work.cur_zone;
            main_work.cur_zone = ( uint )num11;
            if ( main_work.chng_zone < main_work.cur_zone )
            {
                flag2 = true;
                goto IL_3FE;
            }
            flag = true;
            goto IL_3FE;
        }
        int j = 0;
        int num12 = AppMain.arrayof(main_work.trg_act_lr);
        while ( j < num12 )
        {
            CTrgAoAction ctrgAoAction3 = main_work.trg_act_lr[j];
            if ( !main_work.trg_act_move.GetState( 0U )[15] && ctrgAoAction3.GetState( 0U )[7] && ctrgAoAction3.GetState( 0U )[14] )
            {
                main_work.chng_zone = main_work.cur_zone;
                main_work.cur_zone = ( uint )this.dmStgSlctGetRevisedZoneNo( ( int )main_work.cur_zone, ( j == 0 ) ? -1 : 1, 1 & is_final_open, 2 & is_final_open );
                if ( j == 0 )
                {
                    flag = true;
                }
                else
                {
                    flag2 = true;
                }
            }
            j++;
        }
        CTrgStateEx state = main_work.trg_act_move.GetState(0U);
        CArray2<float> dragSpeed = state.GetDragSpeed();
        if ( 3f <= Math.Abs( dragSpeed.x ) && Math.Abs( dragSpeed.y ) < Math.Abs( dragSpeed.x ) )
        {
            if ( 0f <= dragSpeed.x )
            {
                flag = true;
            }
            else
            {
                flag2 = true;
            }
            main_work.chng_zone = main_work.cur_zone;
            main_work.cur_zone = ( uint )this.dmStgSlctGetRevisedZoneNo( ( int )main_work.cur_zone, flag ? 1 : -1, 1 & is_final_open, 2 & is_final_open );
        }
        else if ( state[10] )
        {
            if ( state[15] )
            {
                int num13 = 0;
                int num14;
                switch ( main_work.cur_zone )
                {
                    case 4U:
                        num14 = 0;
                        break;
                    case 5U:
                        num14 = 4;
                        break;
                    default:
                        num14 = 1;
                        break;
                }
                int num15 = (int)((float)((int)AppMain.dm_stgslct_act_disp_y_pos_tbl[0]) - main_work.act_top_pos_y[(int)((UIntPtr)num)] + 60f);
                num15 -= ( int )( dragSpeed.y * 120f * 0.25f );
                num15 /= 120;
                num15 = ( int )AppMain.amClamp( ( float )num15, ( float )num13, ( float )num14 );
                main_work.prev_disp_no = main_work.focus_disp_no;
                main_work.focus_disp_no = num15;
                main_work.flag |= 64U;
            }
        }
        else if ( state[9] )
        {
            IntPair lastMove = state.GetLastMove();
            if ( lastMove.second != 0 )
            {
                int num16 = (int)num;
                while ( ( long )num16 < ( long )( ( ulong )num2 ) )
                {
                    main_work.act_top_pos_y[num16] += ( float )( lastMove.second * 2 );
                    num16++;
                }
                flag3 = true;
            }
        }
        if ( flag || flag2 || flag3 || ( 64U & main_work.flag ) != 0U )
        {
            int k = 0;
            int num17 = AppMain.arrayof(main_work.trg_act);
            while ( k < num17 )
            {
                main_work.trg_act[k].DelLock();
                k++;
            }
            main_work.is_disp_cover = false;
        }
        if ( flag )
        {
            num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
            num2 = num + AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][1];
            main_work.flag |= 32U;
            main_work.act_move_dest[0] = 1120f;
            main_work.act_move_dest[1] = 100f;
            if ( main_work.cur_zone == 4U )
            {
                main_work.crsr_pos_y = 320f;
                main_work.crsr_idx = 0;
            }
            if ( main_work.chng_zone == 4U )
            {
                main_work.crsr_pos_y = 160f;
                main_work.crsr_idx = 0;
            }
            main_work.prev_disp_no = main_work.focus_disp_no;
            main_work.focus_disp_no = 0;
            main_work.cur_stage = ( int )( ( long )( main_work.crsr_idx + main_work.focus_disp_no ) + ( long )( ( ulong )num ) );
            this.dmStgSlctSetActChngZonePosInit( main_work, -1 );
            AppMain.DmSoundPlaySE( "Cursol" );
            if ( ( AppMain.AoPadMRepeat() & 256 ) != 0 || ( AppMain.AoPadMStand() & 256 ) != 0 )
            {
                main_work.flag |= 4194304U;
                main_work.btn_l_disp_frm = 0U;
            }
            main_work.timer = 0;
            return;
        }
        if ( flag2 )
        {
            num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
            num2 = num + AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][1];
            main_work.flag |= 32U;
            main_work.act_move_dest[0] = -1120f;
            main_work.act_move_dest[1] = 100f;
            if ( main_work.cur_zone == 4U )
            {
                main_work.crsr_pos_y = 320f;
                main_work.crsr_idx = 0;
            }
            if ( main_work.chng_zone == 4U )
            {
                main_work.crsr_pos_y = 160f;
                main_work.crsr_idx = 0;
            }
            main_work.prev_disp_no = main_work.focus_disp_no;
            main_work.focus_disp_no = 0;
            main_work.cur_stage = ( int )( ( long )( main_work.crsr_idx + main_work.focus_disp_no ) + ( long )( ( ulong )num ) );
            this.dmStgSlctSetActChngZonePosInit( main_work, 1 );
            AppMain.DmSoundPlaySE( "Cursol" );
            if ( ( AppMain.AoPadMRepeat() & 2048 ) != 0 || ( AppMain.AoPadMStand() & 2048 ) != 0 )
            {
                main_work.flag |= 8388608U;
                main_work.btn_r_disp_frm = 0U;
            }
            main_work.timer = 0;
        }
    }

    // Token: 0x0600134B RID: 4939 RVA: 0x000A9700 File Offset: 0x000A7900
    private void dmStgSlctInputProcStageSelectChngZone( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        int is_final_open = 0;
        int is_spe_open = 0;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        uint num3 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        int num4 = 3;
        if ( main_work.is_clear_stage[3] == 1 && main_work.is_clear_stage[7] == 1 && main_work.is_clear_stage[11] == 1 && main_work.is_clear_stage[15] == 1 )
        {
            is_final_open = 1;
            num4 = 4;
        }
        for ( uint num5 = 17U; num5 < 24U; num5 += 1U )
        {
            if ( main_work.is_clear_stage[( int )( ( UIntPtr )num5 )] != -1 )
            {
                is_spe_open = 1;
                num4 = 5;
                break;
            }
            is_spe_open = 0;
        }
        if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_CANCEL ) != 0 )
        {
            main_work.flag |= 2U;
            return;
        }
        if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_DECIDE ) != 0 )
        {
            main_work.flag |= 4U;
            return;
        }
        if ( ( AppMain.AoPadStand() & 64 ) != 0 )
        {
            main_work.cur_game_mode ^= 1U;
            main_work.mode_tex_frm = 1f;
            AppMain.DmSoundPlaySE( "Cursol" );
            return;
        }
        this.dmStgSlctInputChangeEvtRanking( main_work );
        if ( ( ( int )AppMain.AoPadMRepeat() & AppMain.GSD_KEY_LEFT ) != 0 || ( AppMain.AoPadMRepeat() & 256 ) != 0 )
        {
            if ( ( ( int )AppMain.AoPadMStand() & AppMain.GSD_KEY_LEFT ) != 0 || ( AppMain.AoPadMStand() & 256 ) != 0 || main_work.cur_zone != 0U )
            {
                main_work.chng_zone = main_work.cur_zone;
                main_work.cur_zone = ( uint )this.dmStgSlctGetRevisedZoneNo( ( int )main_work.cur_zone, -1, is_final_open, is_spe_open );
                num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
                uint num6 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
                main_work.flag |= 32U;
                main_work.act_move_dest[0] = 1120f;
                main_work.act_move_dest[1] = 100f;
                if ( main_work.cur_zone == 4U )
                {
                    main_work.crsr_pos_y = 320f;
                    main_work.crsr_idx = 0;
                }
                if ( main_work.chng_zone == 4U )
                {
                    main_work.crsr_pos_y = 160f;
                    main_work.crsr_idx = 0;
                }
                main_work.prev_disp_no = main_work.focus_disp_no;
                main_work.focus_disp_no = 0;
                main_work.cur_stage = ( int )( ( long )( main_work.crsr_idx + main_work.focus_disp_no ) + ( long )( ( ulong )num ) );
                this.dmStgSlctSetActChngZonePosInit( main_work, -1 );
                AppMain.DmSoundPlaySE( "Cursol" );
                if ( ( AppMain.AoPadMRepeat() & 256 ) != 0 || ( AppMain.AoPadMStand() & 256 ) != 0 )
                {
                    main_work.flag |= 4194304U;
                    main_work.btn_l_disp_frm = 0U;
                }
                main_work.timer = 0;
            }
            return;
        }
        if ( ( ( ( int )AppMain.AoPadMRepeat() & AppMain.GSD_KEY_RIGHT ) != 0 || ( AppMain.AoPadMRepeat() & 2048 ) != 0 ) && ( ( ( int )AppMain.AoPadMStand() & AppMain.GSD_KEY_RIGHT ) != 0 || ( AppMain.AoPadMStand() & 2048 ) != 0 || main_work.cur_zone != ( uint )num4 ) )
        {
            main_work.chng_zone = main_work.cur_zone;
            main_work.cur_zone = ( uint )this.dmStgSlctGetRevisedZoneNo( ( int )main_work.cur_zone, 1, is_final_open, is_spe_open );
            num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
            uint num7 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
            main_work.flag |= 32U;
            main_work.act_move_dest[0] = -1120f;
            main_work.act_move_dest[1] = 100f;
            if ( main_work.cur_zone == 4U )
            {
                main_work.crsr_pos_y = 320f;
                main_work.crsr_idx = 0;
            }
            if ( main_work.chng_zone == 4U )
            {
                main_work.crsr_pos_y = 160f;
                main_work.crsr_idx = 0;
            }
            main_work.prev_disp_no = main_work.focus_disp_no;
            main_work.focus_disp_no = 0;
            main_work.cur_stage = ( int )( ( long )( main_work.crsr_idx + main_work.focus_disp_no ) + ( long )( ( ulong )num ) );
            this.dmStgSlctSetActChngZonePosInit( main_work, 1 );
            AppMain.DmSoundPlaySE( "Cursol" );
            if ( ( AppMain.AoPadMRepeat() & 2048 ) != 0 || ( AppMain.AoPadMStand() & 2048 ) != 0 )
            {
                main_work.flag |= 8388608U;
                main_work.btn_r_disp_frm = 0U;
            }
            main_work.timer = 0;
        }
    }

    // Token: 0x0600134C RID: 4940 RVA: 0x000A9AC4 File Offset: 0x000A7CC4
    private void dmStgSlctInputProcStageSelectMove( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = num + AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        uint num3 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] - 1U;
        if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_CANCEL ) != 0 )
        {
            main_work.flag |= 2U;
            return;
        }
        if ( ( ( int )AppMain.AoPadStand() & AppMain.GSD_KEY_DECIDE ) != 0 )
        {
            main_work.flag |= 4U;
            return;
        }
        if ( ( AppMain.AoPadStand() & 64 ) != 0 )
        {
            main_work.cur_game_mode ^= 1U;
            main_work.mode_tex_frm = 1f;
            AppMain.DmSoundPlaySE( "Cursol" );
            return;
        }
        this.dmStgSlctInputChangeEvtRanking( main_work );
        if ( ( ( int )AppMain.AoPadMRepeat() & AppMain.GSD_KEY_UP ) != 0 )
        {
            if ( ( ( int )AppMain.AoPadMStand() & AppMain.GSD_KEY_UP ) != 0 || main_work.cur_stage != ( int )num )
            {
                if ( main_work.cur_zone == 4U )
                {
                    return;
                }
                if ( main_work.crsr_idx == 0 )
                {
                    if ( num3 > 3U )
                    {
                        main_work.flag |= 64U;
                    }
                    else
                    {
                        main_work.flag |= 128U;
                    }
                }
                else
                {
                    main_work.flag |= 128U;
                }
                main_work.flag |= 2048U;
            }
            return;
        }
        if ( ( ( int )AppMain.AoPadMRepeat() & AppMain.GSD_KEY_DOWN ) != 0 && ( ( ( int )AppMain.AoPadMStand() & AppMain.GSD_KEY_DOWN ) != 0 || main_work.cur_stage != ( int )( num2 - 1U ) ) )
        {
            if ( main_work.cur_zone == 4U )
            {
                return;
            }
            if ( main_work.crsr_idx == 3 )
            {
                if ( num3 > 3U )
                {
                    main_work.flag |= 64U;
                }
                else
                {
                    main_work.flag |= 128U;
                }
            }
            else
            {
                main_work.flag |= 128U;
            }
            main_work.flag |= 4096U;
        }
    }

    // Token: 0x0600134D RID: 4941 RVA: 0x000A9C80 File Offset: 0x000A7E80
    private void dmStgSlctInputChangeEvtRanking( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( ( AppMain.AoPadStand() & 16 ) != 0 )
        {
            main_work.flag |= 524288U;
        }
    }

    // Token: 0x0600134E RID: 4942 RVA: 0x000A9CA0 File Offset: 0x000A7EA0
    private void dmStgSlctInputProcWinDispIdle( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.win_mode == 1 )
        {
            int i = 0;
            int num = 2;
            while ( i < num )
            {
                AppMain.ArrayPointer<AppMain.AOS_ACTION> arrayPointer = null;
                AppMain.ArrayPointer<AppMain.AOS_ACTION> pointer = null;
                int win_cur_slct = 0;
                uint num2 = 0U;
                CTrgAoAction ctrgAoAction;
                switch ( 114 + i )
                {
                    case 114:
                        ctrgAoAction = main_work.trg_answer[1];
                        arrayPointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, 106 );
                        pointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, 109 );
                        win_cur_slct = 0;
                        num2 = 4U;
                        break;
                    case 115:
                        ctrgAoAction = main_work.trg_answer[0];
                        arrayPointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, 109 );
                        pointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, 112 );
                        win_cur_slct = 1;
                        num2 = 2U;
                        break;
                    default:
                        ctrgAoAction = null;
                        break;
                }
                float frame;
                if ( AppMain.isBackKeyPressed() )
                {
                    AppMain.setBackKeyRequest( false );
                    win_cur_slct = 1;
                    num2 = 2U;
                    main_work.flag |= num2;
                    main_work.win_cur_slct = win_cur_slct;
                    frame = 2f;
                }
                else if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
                {
                    frame = 2f;
                    main_work.win_cur_slct = win_cur_slct;
                    main_work.flag |= num2;
                }
                else if ( ctrgAoAction.GetState( 0U )[0] )
                {
                    frame = 1f;
                }
                else if ( 2f <= ( ~arrayPointer ).frame )
                {
                    frame = ( ~arrayPointer ).frame;
                }
                else
                {
                    frame = 0f;
                }
                while ( arrayPointer != pointer )
                {
                    AppMain.AoActSetFrame( arrayPointer, frame );
                    AppMain.AoActUpdate( arrayPointer, 0f );
                    arrayPointer = ++arrayPointer;
                }
                i++;
            }
            return;
        }
        if ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            main_work.flag |= 2U;
        }
    }

    // Token: 0x0600134F RID: 4943 RVA: 0x000A9E65 File Offset: 0x000A8065
    private void dmStgSlctProcActDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        this.dmStgSlctSetObiEfctPos( main_work );
        this.dmStgSlctCommonDraw( main_work );
        this.dmStgSlctZoneSelectDraw( main_work );
        if ( main_work.state == 1 )
        {
            this.dmStgSlctStageSelectDraw( main_work );
        }
        this.dmStgSlctCommonFixDraw( main_work );
        this.dmStgSlctMakeVertexAct( main_work, main_work.up_bg_vrtx );
    }

    // Token: 0x06001350 RID: 4944 RVA: 0x000A9EA0 File Offset: 0x000A80A0
    private void dmStgSlctCommonDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 4096U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        if ( 4294967295U == main_work.cur_bg_id )
        {
            AppMain.AoActSortRegAction( main_work.act[93] );
            AppMain.AoActAcmPush();
            AppMain.AoActAcmInit();
            AppMain.AoActAcmApplyFade( main_work.bg_fade );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[0] ) );
            AppMain.AoActUpdate( main_work.act[93], 1f );
            AppMain.AoActAcmPop();
        }
        else
        {
            for ( int i = 0; i < 4; i++ )
            {
                AppMain.AoActSortRegAction( main_work.act[i] );
                AppMain.AoActSetFrame( main_work.act[i], main_work.cur_bg_id );
                AppMain.AoActAcmPush();
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyFade( main_work.bg_fade );
                AppMain.AoActUpdate( main_work.act[i], 0f );
                AppMain.AoActAcmPop();
            }
        }
        if ( AppMain._am_sample_draw_enable )
        {
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
        }
        AppMain.AoActSortUnregAll();
        AppMain.AoActSysSetDrawTaskPrio( 11264U );
        for ( int j = 94; j <= 95; j++ )
        {
            AppMain.AoActSortRegAction( main_work.act[j] );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[0] ) );
        for ( int k = 94; k <= 95; k++ )
        {
            AppMain.AoActUpdate( main_work.act[k], 0f );
        }
        if ( AppMain._am_sample_draw_enable )
        {
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
        }
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06001351 RID: 4945 RVA: 0x000AA000 File Offset: 0x000A8200
    private void dmStgSlctCommonFixDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 12288U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        for ( int i = 4; i <= 9; i++ )
        {
            AppMain.AoActSortRegAction( main_work.act[i] );
        }
        for ( int j = 10; j <= 16; j++ )
        {
            if ( ( ( ulong )main_work.get_emerald & ( ulong )( 1L << ( j - 10 & 31 ) ) ) != 0UL )
            {
                AppMain.AoActSortRegAction( main_work.act[j] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[1] ) );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        if ( main_work.state == 1 )
        {
            if ( main_work.cur_game_mode != 1U )
            {
                AppMain.AoActSortRegAction( main_work.act[51] );
                AppMain.AoActSortRegAction( main_work.act[52] );
                AppMain.AoActSortRegAction( main_work.act[53] );
            }
            else
            {
                AppMain.AoActSortRegAction( main_work.act[54] );
                AppMain.AoActSortRegAction( main_work.act[55] );
                AppMain.AoActSortRegAction( main_work.act[56] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        if ( main_work.cur_game_mode == 1U )
        {
            AppMain.AoActSortRegAction( main_work.act[88] );
        }
        else
        {
            AppMain.AoActSortRegAction( main_work.act[89] );
        }
        main_work.mode_tex_frm = 0f;
        if ( 4294967295U == main_work.cur_bg_id || main_work.state == 0 )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActSortRegAction( main_work.act[18] );
        }
        else if ( main_work.cur_zone != 5U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            AppMain.AoActSortRegAction( main_work.act[17] );
        }
        else
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActSortRegAction( main_work.act[18] );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[4] ) );
        if ( 0f == main_work.win_size_rate[0] && 0f == main_work.win_size_rate[1] )
        {
            AppMain.AoActSortRegAction( main_work.act[112] );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
            for ( int k = 104; k <= 105; k++ )
            {
                AppMain.AoActSortRegAction( main_work.act[k] );
            }
        }
        this.dmStgSlctSetSonicStockDispFrame( main_work );
        if ( main_work.is_jp_region )
        {
            AppMain.AoActSetFrame( main_work.act[96], 0f );
        }
        else
        {
            AppMain.AoActSetFrame( main_work.act[96], 1f );
        }
        AppMain.AoActSetFrame( main_work.act[17], main_work.cur_zone );
        float frame = 0f;
        if ( 4294967295U == main_work.cur_bg_id || main_work.state == 0 )
        {
            frame = 1f;
        }
        AppMain.AoActSetFrame( main_work.act[18], frame );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        for ( int l = 4; l <= 8; l++ )
        {
            AppMain.AoActUpdate( main_work.act[l], 0f );
        }
        AppMain.AoActAcmPush();
        for ( int m = 9; m <= 16; m++ )
        {
            AppMain.AoActAcmInit();
            AppMain.AoActAcmApplyTrans( 0f, main_work.chaos_eme_pos_y, 0f );
            AppMain.AoActUpdate( main_work.act[m], 0f );
        }
        AppMain.AoActAcmPop();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        AppMain.AoActAcmPush();
        bool flag = false;
        if ( main_work.proc_win_update != null && new AppMain.DMS_STGSLCT_MAIN_WORK._proc_win_update_( this.dmStgSlctProcWindowNodispIdle ) != main_work.proc_win_update )
        {
            flag = true;
        }
        if ( main_work.trg_act_move.GetState( 0U )[15] || flag || ( !main_work.trg_mode[0].GetState( 0U )[14] && !main_work.trg_mode[1].GetState( 0U )[14] ) )
        {
            AppMain.AoActUpdate( main_work.act[57] );
        }
        float[] array = new float[]
        {
            main_work.act[57].sprite.center_x - main_work.act_tab_state_move_base_pos[0],
            main_work.act[57].sprite.center_y - main_work.act_tab_state_move_base_pos[1]
        };
        for ( int n = 51; n <= 56; n++ )
        {
            AppMain.AoActAcmInit();
            AppMain.AoActAcmApplyTrans( 0f, main_work.mode_tex_pos_y, 0f );
            AppMain.AoActAcmApplyTrans( array[0], array[1], 0f );
            float frame2 = (2f <= main_work.act[n].frame) ? 1f : 0f;
            AppMain.AoActUpdate( main_work.act[n], frame2 );
        }
        AppMain.AoActAcmPop();
        int num = 0;
        int num2 = AppMain.arrayof(main_work.trg_mode);
        while ( num < num2 )
        {
            main_work.trg_mode[num].Update();
            num++;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        AppMain.AoActUpdate( main_work.act[17], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActUpdate( main_work.act[18], 0f );
        AppMain.AoActAcmPush();
        for ( int num3 = 88; num3 <= 89; num3++ )
        {
            AppMain.AoActAcmInit();
            AppMain.AoActAcmApplyTrans( 0f, main_work.mode_tex_pos_y, 0f );
            AppMain.AoActAcmApplyTrans( array[0], array[1], 0f );
            float frame3 = (2f <= main_work.act[num3].frame) ? 1f : 0f;
            AppMain.AoActUpdate( main_work.act[num3], frame3 );
        }
        AppMain.AoActAcmPop();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[4] ) );
        AppMain.AoActUpdate( main_work.act[112], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
        for ( int num4 = 104; num4 <= 105; num4++ )
        {
            float frame4 = (2f <= main_work.act[num4].frame) ? 1f : 0f;
            AppMain.AoActUpdate( main_work.act[num4], frame4 );
        }
        CTrgAoAction trg_cancel = main_work.trg_cancel;
        trg_cancel.Update();
        uint num5;
        float x;
        if ( main_work.is_final_open == 3 )
        {
            num5 = 6U;
            x = 0f;
        }
        else if ( ( main_work.is_final_open & 2 ) != 0 || ( main_work.is_final_open & 1 ) != 0 )
        {
            num5 = 5U;
            x = 24f;
        }
        else if ( ( main_work.is_final_open & 2 ) != 0 || ( main_work.is_final_open & 1 ) != 0 )
        {
            num5 = 5U;
            x = 24f;
        }
        else
        {
            num5 = 4U;
            x = 64f;
        }
        if ( main_work.state == 1 )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            for ( uint num6 = 0U; num6 < num5; num6 += 1U )
            {
                AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 43U + num6 ) )] );
                if ( main_work.cur_zone == num6 )
                {
                    AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 43U + num6 ) )], 0f );
                }
                else
                {
                    AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 43U + num6 ) )], 1f );
                }
                if ( ( main_work.is_final_open & 2 ) != 0 && main_work.cur_zone == 5U && num6 == 4U && ( main_work.is_final_open & 1 ) == 0 )
                {
                    AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 43U + num6 ) )], 0f );
                }
                AppMain.AoActAcmPush();
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( x, 0f, 0f );
                AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )( 43U + num6 ) )], 0f );
                AppMain.AOS_ACT_HITP hit = main_work.act[(int)((UIntPtr)(43U + num6))].sprite.hit;
                hit.rect.bottom = hit.rect.bottom + 25f;
                AppMain.AOS_ACT_HITP hit2 = main_work.act[(int)((UIntPtr)(43U + num6))].sprite.hit;
                hit2.rect.top = hit2.rect.top - 30f;
                CTrgAoAction ctrgAoAction = main_work.trg_act_tab[(int)((UIntPtr)num6)];
                ctrgAoAction.Update();
                AppMain.AoActAcmPop();
            }
        }
        if ( AppMain._am_sample_draw_enable )
        {
            AppMain.AoActSortExecuteFix();
            AppMain.AoActSortDraw();
        }
        AppMain.AoActSortUnregAll();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        if ( AppMain._am_sample_draw_enable )
        {
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
        }
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06001352 RID: 4946 RVA: 0x000AA7F8 File Offset: 0x000A89F8
    private void dmStgSlctSetSonicStockDispFrame( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        int[] array = new int[3];
        int[] array2 = array;
        int num = 1;
        int num2 = (int)(main_work.player_stock - 1U);
        if ( num2 < 0 )
        {
            num2 = 0;
        }
        if ( ( long )num2 > 999L )
        {
            num2 = 999;
        }
        for ( uint num3 = 0U; num3 < 3U; num3 += 1U )
        {
            for ( uint num4 = 0U; num4 < 3U - num3 - 1U; num4 += 1U )
            {
                num *= 10;
            }
            if ( num2 >= num )
            {
                array2[( int )( ( UIntPtr )num3 )] = num2 / num;
                num2 -= array2[( int )( ( UIntPtr )num3 )] * num;
            }
            else
            {
                array2[( int )( ( UIntPtr )num3 )] = 0;
            }
            num = 1;
        }
        for ( uint num5 = 0U; num5 < 3U; num5 += 1U )
        {
            AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 6U + num5 ) )], ( float )array2[( int )( ( UIntPtr )num5 )] );
        }
    }

    // Token: 0x06001353 RID: 4947 RVA: 0x000AA89C File Offset: 0x000A8A9C
    private void dmStgSlctZoneSelectDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        for ( uint num = 0U; num < 6U; num += 1U )
        {
            this.dmStgSlctOneZoneTableDraw( main_work, num );
        }
        if ( ( main_work.flag & 262144U ) != 0U )
        {
            int decide_zone_efct_dist_x = main_work.decide_zone_efct_dist_x;
            int decide_zone_efct_dist_y = main_work.decide_zone_efct_dist_y;
        }
    }

    // Token: 0x06001354 RID: 4948 RVA: 0x000AA8E8 File Offset: 0x000A8AE8
    private void dmStgSlctOneZoneTableDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work, uint i )
    {
        if ( ( main_work.announce_flag & 4U ) != 0U )
        {
            if ( ( main_work.flag & 131072U ) != 0U && i != 0U )
            {
                return;
            }
        }
        else if ( ( main_work.announce_flag & 128U ) != 0U )
        {
            if ( ( main_work.flag & 131072U ) != 0U && i == 4U )
            {
                return;
            }
        }
        else if ( ( main_work.announce_flag & 512U ) != 0U && ( main_work.flag & 131072U ) != 0U && i == 5U )
        {
            return;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        AppMain.AoActSortRegAction( main_work.act[37] );
        AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 19U + i ) )] );
        if ( i != 5U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            AppMain.AoActSortRegAction( main_work.act[38] );
        }
        else
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActSortRegAction( main_work.act[39] );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        if ( main_work.cur_zone != i && main_work.is_disp_cover )
        {
            AppMain.AoActSortRegAction( main_work.act[41] );
            AppMain.AoActSortRegAction( main_work.act[40] );
            AppMain.AoActSortRegAction( main_work.act[42] );
        }
        AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 19U + i ) )], main_work.zone_scr_id );
        if ( i < 4U )
        {
            AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 25U + i * 3U ) )] );
            AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 26U + i * 3U ) )] );
            AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 27U + i * 3U ) )] );
            AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 25U + i * 3U ) )], main_work.zone_scr_id );
            AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 26U + i * 3U ) )], main_work.zone_scr_id );
            AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 27U + i * 3U ) )], main_work.zone_scr_id );
        }
        AppMain.AoActSetFrame( main_work.act[38], i );
        int num;
        int num2;
        if ( ( main_work.flag & 262144U ) != 0U && main_work.cur_zone == i )
        {
            num = main_work.decide_zone_efct_dist_x;
            num2 = main_work.decide_zone_efct_dist_y;
        }
        else
        {
            num = 0;
            num2 = 0;
        }
        AppMain.AoActAcmPush();
        AppMain.AoActAcmInit();
        AppMain.AoActAcmApplyTrans( main_work.zone_pos[( int )( ( UIntPtr )i )][0] + ( float )num, main_work.zone_pos[( int )( ( UIntPtr )i )][1] + ( float )num2, 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        AppMain.AoActUpdate( main_work.act[37], 0f );
        AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )( 19U + i ) )], 0f );
        CTrgAoAction ctrgAoAction = main_work.trg_zone[(int)((UIntPtr)i)];
        ctrgAoAction.Update();
        for ( i = 25U; i <= 36U; i += 1U )
        {
            AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )i )], 0f );
        }
        AppMain.AoActUpdate( main_work.act[41], 0f );
        AppMain.AoActUpdate( main_work.act[40], 0f );
        AppMain.AoActUpdate( main_work.act[42], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        AppMain.AoActUpdate( main_work.act[38], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActUpdate( main_work.act[39], 0f );
        AppMain.AoActAcmPop();
        if ( AppMain._am_sample_draw_enable )
        {
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
        }
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06001355 RID: 4949 RVA: 0x000AAC40 File Offset: 0x000A8E40
    private void dmStgSlctStageSelectDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        this.dmStgSlctSetDrawStageSelectTable( main_work, main_work.cur_zone, true );
        if ( ( main_work.flag & 32U ) != 0U && main_work.chng_zone != 7U )
        {
            this.dmStgSlctSetDrawStageSelectTable( main_work, main_work.chng_zone );
        }
        CTrgFlick trg_act_move = main_work.trg_act_move;
        trg_act_move.Update();
        if ( main_work.state == 1 && main_work.cur_zone == 5U )
        {
            main_work.disp_flag |= 4U;
        }
        else
        {
            main_work.disp_flag &= 4294967291U;
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        if ( ( main_work.disp_flag & 2U ) != 0U && 4U != main_work.cur_zone )
        {
            if ( 0 < main_work.focus_disp_no || ( 64U & main_work.flag ) != 0U )
            {
                AppMain.AoActSortRegAction( main_work.act[70] );
            }
            int num = (5U == main_work.cur_zone) ? 4 : 1;
            if ( main_work.focus_disp_no < num || ( 64U & main_work.flag ) != 0U )
            {
                AppMain.AoActSortRegAction( main_work.act[71] );
            }
        }
        AppMain.AoActAcmPush();
        for ( uint num2 = 70U; num2 <= 71U; num2 += 1U )
        {
            AppMain.AoActAcmInit();
            AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )num2 )], 1f );
        }
        AppMain.AoActAcmPop();
        if ( AppMain._am_sample_draw_enable )
        {
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
        }
        AppMain.AoActSortUnregAll();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        if ( ( main_work.disp_flag & 2U ) != 0U )
        {
            uint num2;
            for ( num2 = 0U; num2 < 2U; num2 += 1U )
            {
                AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 49U + num2 ) )] );
                AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )( 49U + num2 ) )], 1f );
            }
            num2 = 0U;
            int num3 = AppMain.arrayof(main_work.trg_act_lr);
            while ( ( ulong )num2 < ( ulong )( ( long )num3 ) )
            {
                main_work.trg_act_lr[( int )( ( UIntPtr )num2 )].Update();
                num2 += 1U;
            }
            if ( AppMain._am_sample_draw_enable )
            {
                AppMain.AoActSortExecute();
                AppMain.AoActSortDraw();
            }
            AppMain.AoActSortUnregAll();
        }
    }

    // Token: 0x06001356 RID: 4950 RVA: 0x000AAE22 File Offset: 0x000A9022
    private void dmStgSlctSetDrawStageSelectTable( AppMain.DMS_STGSLCT_MAIN_WORK main_work, uint zone )
    {
        this.dmStgSlctSetDrawStageSelectTable( main_work, zone, false );
    }

    // Token: 0x06001357 RID: 4951 RVA: 0x000AAE30 File Offset: 0x000A9030
    private void dmStgSlctSetDrawStageSelectTable( AppMain.DMS_STGSLCT_MAIN_WORK main_work, uint zone, bool is_trg_update )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)zone)][1] + num;
        AppMain.CActionDraw cactionDraw = AppMain.stgSelect_act_draw_sys;
        cactionDraw.Clear();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            for ( uint num4 = 58U; num4 <= 60U; num4 += 1U )
            {
                this.dmStgSlctSetTableActiveInfo( main_work, num3 );
                AppMain.AoActAcmPush();
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f, 0f );
                AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )num4 )], 0f );
                AppMain.AoActAcmPop();
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[( int )( ( UIntPtr )num4 )], main_work.act[( int )( ( UIntPtr )num4 )].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            if ( is_trg_update && num <= num3 && ( ulong )num3 < ( ulong )num + ( ulong )( ( long )AppMain.arrayof( main_work.trg_act ) ) )
            {
                uint num5 = num3 - num;
                CTrgAoAction ctrgAoAction = main_work.trg_act[(int)((UIntPtr)num5)];
                ctrgAoAction.Update();
            }
        }
        cactionDraw.Draw();
        cactionDraw.Clear();
        if ( zone != 5U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                AppMain.AoActUpdate( main_work.act[62], 0f );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[62], main_work.act[62].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                this.dmStgSlctSetTableActiveInfo( main_work, num3 );
                AppMain.AoActUpdate( main_work.act[61], 0f );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[61], main_work.act[61].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            cactionDraw.Draw();
            cactionDraw.Clear();
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                if ( num3 == 16U )
                {
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActUpdate( main_work.act[74], 0f );
                    cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[74], main_work.act[74].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                }
                else if ( ( num3 + 1U ) % 4U != 0U || num3 == 0U )
                {
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActUpdate( main_work.act[63], 0f );
                    cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[63], main_work.act[63].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f - 4f );
                }
                else
                {
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActUpdate( main_work.act[74], 0f );
                    cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[74], main_work.act[74].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                }
            }
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                if ( num3 != 16U && ( ( num3 + 1U ) % 4U != 0U || num3 == 0U ) )
                {
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                    AppMain.AoActSetFrame( main_work.act[64], this.dm_stgslct_act_num_disp_id_tbl[( int )( ( UIntPtr )num3 )] );
                    AppMain.AoActUpdate( main_work.act[64], 0f );
                    cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[64], main_work.act[64].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                }
            }
            cactionDraw.Draw();
            cactionDraw.Clear();
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                this.dmStgSlctSetTableActiveInfo( main_work, num3 );
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                AppMain.AoActUpdate( main_work.act[65], 0f );
                cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[65], main_work.act[65].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                AppMain.AoActUpdate( main_work.act[66], 0f );
                AppMain.AoActSortRegAction( main_work.act[66] );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[66], main_work.act[66].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            cactionDraw.Draw();
            cactionDraw.Clear();
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                for ( uint num6 = 0U; num6 < 7U; num6 += 1U )
                {
                    if ( main_work.eme_stage_no[( int )( ( UIntPtr )num6 )] == num3 && ( ( ulong )main_work.get_emerald & ( ulong )( 1L << ( int )( num6 & 31U ) ) ) != 0UL )
                    {
                        AppMain.AoActUpdate( main_work.act[67], 0f );
                        AppMain.AoActSetFrame( main_work.act[67], num6 );
                        cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[67], main_work.act[67].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                        break;
                    }
                }
            }
            cactionDraw.Draw();
            cactionDraw.Clear();
        }
        else
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                AppMain.AoActUpdate( main_work.act[75], 0f );
                cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[75], main_work.act[75].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            cactionDraw.Draw();
            cactionDraw.Clear();
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                if ( AppMain.GsMainSysIsStageClear( ( int )( 21U + ( num3 - num ) ) ) )
                {
                    AppMain.AoActSetFrame( main_work.act[69], num3 - num );
                    AppMain.AoActUpdate( main_work.act[69], 0f );
                    cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[69], main_work.act[69].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                }
            }
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                AppMain.AoActSetFrame( main_work.act[68], this.dm_stgslct_act_num_disp_id_tbl[( int )( ( UIntPtr )num3 )] );
                AppMain.AoActUpdate( main_work.act[68], 0f );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[68], main_work.act[68].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            cactionDraw.Draw();
            cactionDraw.Clear();
        }
        if ( main_work.cur_game_mode == 0U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            uint num3;
            for ( num3 = num; num3 < num2; num3 += 1U )
            {
                AppMain.AoActUpdate( main_work.act[72], 0f );
                cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[72], main_work.act[72].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            num3 = num;

            IL_8F9:
            while ( num3 < num2 )
            {
                this.dmStgSlctSetScoreDispFrame( main_work, zone, num3 );
                for ( uint num7 = 0U; num7 < 9U; num7 += 1U )
                {
                    if ( 0f != main_work.act[( int )( ( UIntPtr )( 76U + num7 ) )].frame )
                    {
                        IL_8EF:
                        while ( num7 < 9U )
                        {
                            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                            AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )( 76U + num7 ) )], 0f );
                            cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[( int )( ( UIntPtr )( 76U + num7 ) )], main_work.act[( int )( ( UIntPtr )( 76U + num7 ) )].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                            num7 += 1U;
                        }
                        num3 += 1U;
                        goto IL_8F9;
                    }
                }
                throw new NotImplementedException();
                //goto IL_8EF;
            }
        }
        else
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                AppMain.AoActUpdate( main_work.act[73], 0f );
                cactionDraw.Entry( main_work.ama[1], AppMain.g_dm_act_id_tbl_stg_slct[73], main_work.act[73].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                this.dmStgSlctSetScoreDispFrame( main_work, zone, num3 );
                for ( uint num6 = 0U; num6 < 7U; num6 += 1U )
                {
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
                    AppMain.AoActUpdate( main_work.act[( int )( ( UIntPtr )( 76U + num6 ) )], 0f );
                    cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[( int )( ( UIntPtr )( 76U + num6 ) )], main_work.act[( int )( ( UIntPtr )( 76U + num6 ) )].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                }
            }
        }
        cactionDraw.Draw();
        cactionDraw.Clear();
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            this.dmStgSlctSetScoreDispFrame( main_work, zone, num3 );
            if ( AppMain._am_sample_draw_enable )
            {
                AppMain.AoActSortExecute();
                AppMain.AoActSortDraw();
            }
            AppMain.AoActSortUnregAll();
        }
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            if ( main_work.cur_stage != ( int )num3 && main_work.is_disp_cover )
            {
                AppMain.AoActUpdate( main_work.act[85], 0f );
                AppMain.AoActUpdate( main_work.act[86], 0f );
                AppMain.AoActUpdate( main_work.act[87], 0f );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[87], main_work.act[87].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[86], main_work.act[86].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
                cactionDraw.Entry( main_work.ama[0], AppMain.g_dm_act_id_tbl_stg_slct[85], main_work.act[85].frame, main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )], main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] + ( num3 - num ) * 120f );
            }
        }
        cactionDraw.Draw();
        cactionDraw.Clear();
    }

    // Token: 0x06001358 RID: 4952 RVA: 0x000AB9DC File Offset: 0x000A9BDC
    private void dmStgSlctSetScoreDispFrame( AppMain.DMS_STGSLCT_MAIN_WORK main_work, uint zone, uint act_no )
    {
        int[] array = AppMain.dmStgSlctSetScoreDispFrame_tmp_digit;
        Array.Clear( array, 0, array.Length );
        int num = 1;
        ushort num2 = 0;
        ushort num3 = 0;
        ushort num4 = 0;
        int[] array2 = AppMain.dmStgSlctSetScoreDispFrame_time_digit;
        Array.Clear( array2, 0, array2.Length );
        bool flag = false;
        if ( main_work.cur_game_mode == 0U )
        {
            if ( main_work.hi_score[( int )( ( UIntPtr )act_no )] != 1000000000 )
            {
                int num5 = main_work.hi_score[(int)((UIntPtr)act_no)];
                for ( uint num6 = 0U; num6 < 9U; num6 += 1U )
                {
                    if ( 9U - num6 - 1U <= 0U )
                    {
                        num5 = 1;
                    }
                    else
                    {
                        for ( uint num7 = 0U; num7 < 9U - num6 - 1U; num7 += 1U )
                        {
                            num *= 10;
                        }
                    }
                    if ( num5 >= num )
                    {
                        AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 76U + num6 ) )] );
                        if ( num6 >= 8U )
                        {
                            array[( int )( ( UIntPtr )num6 )] = 0;
                        }
                        else
                        {
                            array[( int )( ( UIntPtr )num6 )] = num5 / num;
                            num5 -= array[( int )( ( UIntPtr )num6 )] * num - 1;
                        }
                        flag = true;
                    }
                    else
                    {
                        if ( flag )
                        {
                            AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 76U + num6 ) )] );
                        }
                        array[( int )( ( UIntPtr )num6 )] = 0;
                    }
                    num = 1;
                }
                for ( uint num8 = 0U; num8 < 9U; num8 += 1U )
                {
                    AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 76U + num8 ) )], ( float )array[( int )( ( UIntPtr )num8 )] );
                }
                return;
            }
            for ( uint num9 = 0U; num9 < 9U; num9 += 1U )
            {
                AppMain.AoActSortRegAction( main_work.act[( int )( ( UIntPtr )( 76U + num9 ) )] );
                AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 76U + num9 ) )], 10f );
            }
            return;
        }
        else
        {
            if ( main_work.record_time[( int )( ( UIntPtr )act_no )] != 36000 )
            {
                AppMain.AkUtilFrame60ToTime( ( uint )main_work.record_time[( int )( ( UIntPtr )act_no )], ref num2, ref num3, ref num4 );
                float num10 = (float)num3;
                if ( num10 >= 10f )
                {
                    array2[0] = ( int )( num10 / 10f );
                    num10 -= ( float )array2[0] * 10f;
                }
                else
                {
                    array2[0] = 0;
                }
                array2[1] = ( int )num10;
                AppMain.AoActSetFrame( main_work.act[76], ( float )num2 );
                AppMain.AoActSetFrame( main_work.act[77], 11f );
                AppMain.AoActSetFrame( main_work.act[78], ( float )array2[0] );
                AppMain.AoActSetFrame( main_work.act[79], ( float )array2[1] );
                AppMain.AoActSetFrame( main_work.act[80], 11f );
                num10 = ( float )num4;
                if ( num10 >= 10f )
                {
                    array2[0] = ( int )( num10 / 10f );
                    num10 -= ( float )array2[0] * 10f;
                }
                else
                {
                    array2[0] = 0;
                }
                array2[1] = ( int )num10;
                AppMain.AoActSetFrame( main_work.act[81], ( float )array2[0] );
                AppMain.AoActSetFrame( main_work.act[82], ( float )array2[1] );
                return;
            }
            for ( uint num11 = 0U; num11 < 7U; num11 += 1U )
            {
                if ( num11 == 1U || num11 == 4U )
                {
                    AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 76U + num11 ) )], 11f );
                }
                else
                {
                    AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )( 76U + num11 ) )], 10f );
                }
            }
            return;
        }
    }

    // Token: 0x06001359 RID: 4953 RVA: 0x000ABCB4 File Offset: 0x000A9EB4
    private void dmStgSlctWinSelectDraw( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        AppMain.AoActSysSetDrawTaskPrio( 16384U );
        array2[0] = 705.6f;
        array2[1] = 302.4f;
        int win_mode = main_work.win_mode;
        if ( win_mode == 1 )
        {
            float[] array3 = new float[]
            {
                1.01f,
                1.27f
            };
            for ( int i = 0; i < 2; i++ )
            {
                array2[i] *= array3[i];
            }
        }
        if ( 0f < main_work.win_size_rate[0] && 0f < main_work.win_size_rate[1] )
        {
            AppMain.AoWinSysDrawTask( 0, AppMain.AoTexGetTexList( main_work.cmn_tex[3] ), 0U, 480f, 360f, array2[0] * main_work.win_size_rate[0], array2[1] * main_work.win_size_rate[1], 13568 );
        }
        if ( ( main_work.disp_flag & 1U ) != 0U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[4] ) );
            switch ( main_work.win_mode )
            {
                case 1:
                    {
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
                        int j = 106;
                        int num = 111;
                        while ( j <= num )
                        {
                            AppMain.AoActSortRegAction( main_work.act[j] );
                            j++;
                        }
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                        AppMain.AoActSortRegAction( main_work.act[91] );
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[4] ) );
                        AppMain.AoActSortRegAction( main_work.act[114] );
                        AppMain.AoActSortRegAction( main_work.act[115] );
                        if ( main_work.cur_zone != 5U )
                        {
                            AppMain.AoActSetFrame( main_work.act[91], 0f );
                        }
                        else
                        {
                            AppMain.AoActSetFrame( main_work.act[91], 1f );
                        }
                        break;
                    }
                case 2:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[2][1] );
                    break;
                case 3:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[3][1] );
                    break;
                case 4:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[4][1] );
                    break;
                case 5:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[5][1] );
                    break;
                case 6:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[6][1] );
                    break;
                case 7:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[7][1] );
                    break;
                case 8:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[92] );
                    break;
                case 9:
                    AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                    AppMain.AoActSortRegAction( main_work.act[90] );
                    AppMain.AoActSetFrame( main_work.act[90], this.dm_stgslct_win_act_frm_tbl[9][1] );
                    break;
            }
            if ( main_work.is_jp_region )
            {
                AppMain.AoActSetFrame( main_work.act[101], 0f );
            }
            else
            {
                AppMain.AoActSetFrame( main_work.act[101], 1f );
            }
            AppMain.AoActAcmPush();
            for ( int k = 0; k < 3; k++ )
            {
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( this.dm_stgslct_win_act_pos_tbl[k + 1][0], this.dm_stgslct_win_act_pos_tbl[k + 1][1], 0f );
                if ( k == 0 )
                {
                    AppMain.AoActAcmApplyTrans( this.dm_stgslct_back_text_length_tbl[AppMain.GsEnvGetLanguage()], 0f, 0f );
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[1] ) );
                AppMain.AoActUpdate( main_work.act[101 + k], 0f );
            }
            AppMain.AoActAcmPop();
            AppMain.AoActAcmPush();
            for ( int l = 0; l < 5; l++ )
            {
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( this.dm_stgslct_win_act_pos_tbl[4 + l][0], this.dm_stgslct_win_act_pos_tbl[4 + l][1], 0f );
                AppMain.AoActAcmApplyScale( 1.6800001f, 1.6800001f );
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                AppMain.AoActUpdate( main_work.act[90 + l], 0f );
            }
            AppMain.AoActAcmPop();
            AppMain.AoActAcmPush();
            int num2 = 113;
            for ( int m = 0; m < 3; m++ )
            {
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( this.dm_stgslct_win_act_pos_tbl[11 + m][0], this.dm_stgslct_win_act_pos_tbl[11 + m][1], 0f );
                if ( main_work.win_mode == 8 && m == 2 )
                {
                    AppMain.AoActAcmApplyTrans( 0f, 16f, 0f );
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[4] ) );
                AppMain.AoActUpdate( main_work.act[num2 + m], 0f );
                main_work.act[num2 + m].sprite.center_y += 5f;
                CTrgAoAction ctrgAoAction;
                switch ( num2 + m )
                {
                    case 114:
                        {
                            ctrgAoAction = main_work.trg_answer[1];
                            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
                            AppMain.ArrayPointer<AppMain.AOS_ACTION> arrayPointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 106);
                            AppMain.ArrayPointer<AppMain.AOS_ACTION> pointer = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 109);
                            while ( arrayPointer != pointer )
                            {
                                float frame = (2f <= (~arrayPointer).frame) ? 1f : 0f;
                                AppMain.AoActUpdate( arrayPointer, frame );
                                arrayPointer = ++arrayPointer;
                            }
                            break;
                        }
                    case 115:
                        {
                            ctrgAoAction = main_work.trg_answer[0];
                            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
                            AppMain.ArrayPointer<AppMain.AOS_ACTION> arrayPointer2 = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 109);
                            AppMain.ArrayPointer<AppMain.AOS_ACTION> pointer2 = new AppMain.ArrayPointer<AppMain.AOS_ACTION>(main_work.act, 112);
                            while ( arrayPointer2 != pointer2 )
                            {
                                float frame2 = (2f <= (~arrayPointer2).frame) ? 1f : 0f;
                                AppMain.AoActUpdate( arrayPointer2, frame2 );
                                arrayPointer2 = ++arrayPointer2;
                            }
                            break;
                        }
                    default:
                        ctrgAoAction = null;
                        break;
                }
                if ( ctrgAoAction != null )
                {
                    ctrgAoAction.Update();
                }
            }
            AppMain.AoActAcmPop();
            if ( AppMain._am_sample_draw_enable )
            {
                AppMain.AoActSortExecute();
                AppMain.AoActSortDraw();
            }
            AppMain.AoActSortUnregAll();
        }
    }

    // Token: 0x0600135A RID: 4954 RVA: 0x000AC39C File Offset: 0x000AA59C
    private int dmStgSlctIsDataLoad( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_amb_fs[i] ) )
            {
                return 0;
            }
        }
        for ( int j = 0; j < 5; j++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_cmn_amb_fs[j] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x0600135B RID: 4955 RVA: 0x000AC3E4 File Offset: 0x000AA5E4
    private int dmStgSlctIsTexLoad( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.tex[i] ) )
            {
                return 0;
            }
        }
        if ( !AppMain.GsFontIsBuilded() )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x0600135C RID: 4956 RVA: 0x000AC418 File Offset: 0x000AA618
    private int dmStgSlctIsTexLoad2( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 5; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.cmn_tex[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x0600135D RID: 4957 RVA: 0x000AC444 File Offset: 0x000AA644
    private int dmStgSlctIsTexRelease( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.tex[i] ) )
            {
                return 0;
            }
        }
        for ( int j = 0; j < 5; j++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.cmn_tex[j] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x0600135E RID: 4958 RVA: 0x000AC48C File Offset: 0x000AA68C
    private void dmStgSlctSetDecideZoneEfctPos( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.timer < 6 )
        {
            main_work.decide_zone_efct_dist_x = 0;
            main_work.decide_zone_efct_dist_y = 8;
            return;
        }
        main_work.decide_zone_efct_dist_x = 0;
        main_work.decide_zone_efct_dist_y = 0;
    }

    // Token: 0x0600135F RID: 4959 RVA: 0x000AC4B4 File Offset: 0x000AA6B4
    private bool dmStgSlctIsDecideZoneEfctPos( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        return main_work.timer > 10;
    }

    // Token: 0x06001360 RID: 4960 RVA: 0x000AC4C4 File Offset: 0x000AA6C4
    private void dmStgSlctSetZonePosOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        for ( uint num = 0U; num < 6U; num += 1U )
        {
            if ( ( ( ulong )main_work.efct_out_flag & ( ulong )( 1L << ( int )( num & 31U ) ) ) != 0UL && num != main_work.cur_zone )
            {
                if ( main_work.is_final_open == 3 )
                {
                    array4[0] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][0] - AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][0];
                    array4[1] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][1] - AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][1];
                }
                else if ( ( main_work.is_final_open & 2 ) != 0 )
                {
                    array4[0] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][0] - AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][0];
                    array4[1] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][1] - AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][1];
                }
                else if ( ( main_work.is_final_open & 1 ) != 0 )
                {
                    array4[0] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][0] - AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][0];
                    array4[1] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][1] - AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][1];
                }
                else
                {
                    array4[0] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][0] - AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][0];
                    array4[1] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[( int )( ( UIntPtr )num )][1] - AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )num )][1];
                }
                array2[0] = array4[0] / 16f;
                array2[1] = array4[1] / 16f;
                main_work.zone_pos[( int )( ( UIntPtr )num )][0] += array2[0];
                main_work.zone_pos[( int )( ( UIntPtr )num )][1] += array2[1];
            }
        }
        this.dmStgSlctSetEmeTableOutEfct( main_work );
    }

    // Token: 0x06001361 RID: 4961 RVA: 0x000AC65C File Offset: 0x000AA85C
    private bool dmStgSlctIsZonePosOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.is_final_open == 3 )
        {
            if ( ( main_work.zone_pos[0][0] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[0][0] || main_work.zone_pos[0][1] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[0][1] ) && main_work.cur_zone != 0U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[1][0] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[1][0] || main_work.zone_pos[1][1] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[1][1] ) && main_work.cur_zone != 1U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[2][0] < AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[2][0] || main_work.zone_pos[2][1] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[2][1] ) && main_work.cur_zone != 2U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[3][0] < AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[3][0] || main_work.zone_pos[3][1] < AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[3][1] ) && main_work.cur_zone != 3U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[4][0] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[4][0] || main_work.zone_pos[4][1] < AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[4][1] ) && main_work.cur_zone != 4U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[5][0] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[5][0] || main_work.zone_pos[5][1] > AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[5][1] ) && main_work.cur_zone != 5U )
            {
                return false;
            }
        }
        else if ( ( main_work.is_final_open & 2 ) != 0 )
        {
            if ( ( main_work.zone_pos[0][0] > AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[0][0] || main_work.zone_pos[0][1] > AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[0][1] ) && main_work.cur_zone != 0U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[1][0] > AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[1][0] || main_work.zone_pos[1][1] > AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[1][1] ) && main_work.cur_zone != 1U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[2][0] < AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[2][0] || main_work.zone_pos[2][1] > AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[2][1] ) && main_work.cur_zone != 2U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[3][0] < AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[3][0] || main_work.zone_pos[3][1] < AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[3][1] ) && main_work.cur_zone != 3U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[5][0] > AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[5][0] || main_work.zone_pos[5][1] < AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[5][1] ) && main_work.cur_zone != 5U )
            {
                return false;
            }
        }
        else if ( ( main_work.is_final_open & 1 ) != 0 )
        {
            if ( ( main_work.zone_pos[0][0] > AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[0][0] || main_work.zone_pos[0][1] > AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[0][1] ) && main_work.cur_zone != 0U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[1][0] > AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[1][0] || main_work.zone_pos[1][1] > AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[1][1] ) && main_work.cur_zone != 1U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[2][0] < AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[2][0] || main_work.zone_pos[2][1] > AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[2][1] ) && main_work.cur_zone != 2U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[3][0] < AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[3][0] || main_work.zone_pos[3][1] < AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[3][1] ) && main_work.cur_zone != 3U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[4][0] > AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[4][0] || main_work.zone_pos[4][1] < AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[4][1] ) && main_work.cur_zone != 4U )
            {
                return false;
            }
        }
        else
        {
            if ( ( main_work.zone_pos[0][0] > AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[0][0] || main_work.zone_pos[0][1] > AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[0][1] ) && main_work.cur_zone != 0U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[1][0] > AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[1][0] || main_work.zone_pos[1][1] < AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[1][1] ) && main_work.cur_zone != 1U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[2][0] < AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[2][0] || main_work.zone_pos[2][1] > AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[2][1] ) && main_work.cur_zone != 2U )
            {
                return false;
            }
            if ( ( main_work.zone_pos[3][0] < AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[3][0] || main_work.zone_pos[3][1] < AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[3][1] ) && main_work.cur_zone != 3U )
            {
                return false;
            }
        }
        main_work.efct_out_flag = 0U;
        return this.dmStgSlctIsEmeTableOutEfctEnd( main_work );
    }

    // Token: 0x06001362 RID: 4962 RVA: 0x000ACAD4 File Offset: 0x000AACD4
    private void dmStgSlctSetStagePosInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] > 100f )
        {
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                array4[0] = -1020f;
                array2[0] = array4[0] / 16f;
                main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] += array2[0];
            }
        }
        this.dmStgSlctSetDecideZonePosOutEfct( main_work );
        this.dmStgSlctSetModeTexInEfct( main_work );
    }

    // Token: 0x06001363 RID: 4963 RVA: 0x000ACB7C File Offset: 0x000AAD7C
    private bool dmStgSlctIsStagePosInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        if ( !this.dmStgSlctIsModeTexInEfctEnd( main_work ) )
        {
            return false;
        }
        if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] <= 100f && main_work.zone_pos[( int )( ( UIntPtr )main_work.cur_zone )][0] < AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[0][0] )
        {
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] = 100f;
            }
            main_work.zone_pos[( int )( ( UIntPtr )main_work.cur_zone )][0] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[0][0];
            return true;
        }
        return false;
    }

    // Token: 0x06001364 RID: 4964 RVA: 0x000ACC1C File Offset: 0x000AAE1C
    private void dmStgSlctSetStagePosOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            array4[0] = 1020f;
            array2[0] = array4[0] / 16f;
            main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] += array2[0];
        }
        this.dmStgSlctSetModeTexOutEfct( main_work );
    }

    // Token: 0x06001365 RID: 4965 RVA: 0x000ACCB0 File Offset: 0x000AAEB0
    private bool dmStgSlctIsStagePosOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        if ( !this.dmStgSlctIsModeTexOutEfctEnd( main_work ) )
        {
            return false;
        }
        if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] >= 1120f )
        {
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] = 1120f;
            }
            return true;
        }
        return false;
    }

    // Token: 0x06001366 RID: 4966 RVA: 0x000ACD1C File Offset: 0x000AAF1C
    private void dmStgSlctSetZonePosInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        for ( int i = 0; i < 6; i++ )
        {
            if ( main_work.is_final_open == 3 )
            {
                array4[0] = AppMain.dm_stgslct_a_zone_disp_pos_tbl[i][0] - AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[i][0];
                array4[1] = AppMain.dm_stgslct_a_zone_disp_pos_tbl[i][1] - AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[i][1];
            }
            else if ( ( main_work.is_final_open & 2 ) != 0 )
            {
                array4[0] = AppMain.dm_stgslct_s_zone_disp_pos_tbl[i][0] - AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[i][0];
                array4[1] = AppMain.dm_stgslct_s_zone_disp_pos_tbl[i][1] - AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[i][1];
            }
            else if ( ( main_work.is_final_open & 1 ) != 0 )
            {
                array4[0] = AppMain.dm_stgslct_f_zone_disp_pos_tbl[i][0] - AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[i][0];
                array4[1] = AppMain.dm_stgslct_f_zone_disp_pos_tbl[i][1] - AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[i][1];
            }
            else
            {
                array4[0] = AppMain.dm_stgslct_n_zone_disp_pos_tbl[i][0] - AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[i][0];
                array4[1] = AppMain.dm_stgslct_n_zone_disp_pos_tbl[i][1] - AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[i][1];
            }
            array2[0] = array4[0] / 16f;
            array2[1] = array4[1] / 16f;
            main_work.zone_pos[i][0] += array2[0];
            main_work.zone_pos[i][1] += array2[1];
        }
        this.dmStgSlctSetEmeTableInEfct( main_work );
        main_work.timer++;
    }

    // Token: 0x06001367 RID: 4967 RVA: 0x000ACE8C File Offset: 0x000AB08C
    private bool dmStgSlctIsZonePosInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.is_final_open == 3 )
        {
            if ( main_work.zone_pos[0][0] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[0][0] || main_work.zone_pos[0][1] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[0][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[1][0] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[1][0] || main_work.zone_pos[1][1] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[1][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[2][0] > AppMain.dm_stgslct_a_zone_disp_pos_tbl[2][0] || main_work.zone_pos[2][1] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[2][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[3][0] > AppMain.dm_stgslct_a_zone_disp_pos_tbl[3][0] || main_work.zone_pos[3][1] > AppMain.dm_stgslct_a_zone_disp_pos_tbl[3][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[4][0] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[4][0] || main_work.zone_pos[4][1] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[4][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[5][0] < AppMain.dm_stgslct_a_zone_disp_pos_tbl[5][0] || main_work.zone_pos[5][1] > AppMain.dm_stgslct_a_zone_disp_pos_tbl[5][1] )
            {
                return false;
            }
        }
        else if ( ( main_work.is_final_open & 2 ) != 0 )
        {
            if ( main_work.zone_pos[0][0] < AppMain.dm_stgslct_s_zone_disp_pos_tbl[0][0] || main_work.zone_pos[0][1] < AppMain.dm_stgslct_s_zone_disp_pos_tbl[0][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[1][0] < AppMain.dm_stgslct_s_zone_disp_pos_tbl[1][0] || main_work.zone_pos[1][1] < AppMain.dm_stgslct_s_zone_disp_pos_tbl[1][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[2][0] > AppMain.dm_stgslct_s_zone_disp_pos_tbl[2][0] || main_work.zone_pos[2][1] < AppMain.dm_stgslct_s_zone_disp_pos_tbl[2][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[3][0] > AppMain.dm_stgslct_s_zone_disp_pos_tbl[3][0] || main_work.zone_pos[3][1] > AppMain.dm_stgslct_s_zone_disp_pos_tbl[3][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[5][0] < AppMain.dm_stgslct_s_zone_disp_pos_tbl[5][0] || main_work.zone_pos[5][1] > AppMain.dm_stgslct_s_zone_disp_pos_tbl[5][1] )
            {
                return false;
            }
        }
        else if ( ( main_work.is_final_open & 1 ) != 0 )
        {
            if ( main_work.zone_pos[0][0] < AppMain.dm_stgslct_f_zone_disp_pos_tbl[0][0] || main_work.zone_pos[0][1] < AppMain.dm_stgslct_f_zone_disp_pos_tbl[0][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[1][0] < AppMain.dm_stgslct_f_zone_disp_pos_tbl[1][0] || main_work.zone_pos[1][1] < AppMain.dm_stgslct_f_zone_disp_pos_tbl[1][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[2][0] > AppMain.dm_stgslct_f_zone_disp_pos_tbl[2][0] || main_work.zone_pos[2][1] < AppMain.dm_stgslct_f_zone_disp_pos_tbl[2][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[3][0] > AppMain.dm_stgslct_f_zone_disp_pos_tbl[3][0] || main_work.zone_pos[3][1] > AppMain.dm_stgslct_f_zone_disp_pos_tbl[3][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[4][0] < AppMain.dm_stgslct_f_zone_disp_pos_tbl[4][0] || main_work.zone_pos[4][1] > AppMain.dm_stgslct_f_zone_disp_pos_tbl[4][1] )
            {
                return false;
            }
        }
        else
        {
            if ( main_work.zone_pos[0][0] < AppMain.dm_stgslct_n_zone_disp_pos_tbl[0][0] || main_work.zone_pos[0][1] < AppMain.dm_stgslct_n_zone_disp_pos_tbl[0][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[1][0] < AppMain.dm_stgslct_n_zone_disp_pos_tbl[1][0] || main_work.zone_pos[1][1] > AppMain.dm_stgslct_n_zone_disp_pos_tbl[1][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[2][0] > AppMain.dm_stgslct_n_zone_disp_pos_tbl[2][0] || main_work.zone_pos[2][1] < AppMain.dm_stgslct_n_zone_disp_pos_tbl[2][1] )
            {
                return false;
            }
            if ( main_work.zone_pos[3][0] > AppMain.dm_stgslct_n_zone_disp_pos_tbl[3][0] || main_work.zone_pos[3][1] > AppMain.dm_stgslct_n_zone_disp_pos_tbl[3][1] )
            {
                return false;
            }
        }
        return this.dmStgSlctIsEmeTableInEfctEnd( main_work );
    }

    // Token: 0x06001368 RID: 4968 RVA: 0x000AD244 File Offset: 0x000AB444
    private void dmStgSlctSetDecideZonePosOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        if ( main_work.is_final_open == 3 )
        {
            array4[0] = AppMain.dm_stgslct_a_zone_nodisp_pos_tbl[0][0] - AppMain.dm_stgslct_a_zone_disp_pos_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
        }
        else if ( ( main_work.is_final_open & 2 ) != 0 )
        {
            array4[0] = AppMain.dm_stgslct_s_zone_nodisp_pos_tbl[0][0] - AppMain.dm_stgslct_s_zone_disp_pos_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
        }
        else if ( ( main_work.is_final_open & 1 ) != 0 )
        {
            array4[0] = AppMain.dm_stgslct_f_zone_nodisp_pos_tbl[0][0] - AppMain.dm_stgslct_f_zone_disp_pos_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
        }
        else
        {
            array4[0] = AppMain.dm_stgslct_n_zone_nodisp_pos_tbl[0][0] - AppMain.dm_stgslct_n_zone_disp_pos_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
        }
        array2[0] = array4[0] / 16f;
        main_work.zone_pos[( int )( ( UIntPtr )main_work.cur_zone )][0] += array2[0];
    }

    // Token: 0x06001369 RID: 4969 RVA: 0x000AD328 File Offset: 0x000AB528
    private void dmStgSlctSetStageZoneChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.chng_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.chng_zone)][1] + num;
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            array4[0] = main_work.act_move_dest[0] - main_work.act_move_src[0];
            array2[0] = array4[0] / 16f;
            main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] += array2[0];
        }
        num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
        num2 = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][1] + num;
        for ( uint num4 = num; num4 < num2; num4 += 1U )
        {
            array4[1] = main_work.act_move_dest[1] - main_work.act_move_src[1];
            array2[1] = array4[1] / 16f;
            main_work.act_top_pos_x[( int )( ( UIntPtr )num4 )] += array2[1];
        }
    }

    // Token: 0x0600136A RID: 4970 RVA: 0x000AD430 File Offset: 0x000AB630
    private bool dmStgSlctIsStageZoneChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        byte b = 0;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.chng_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.chng_zone)][1] + num;
        if ( main_work.act_move_dest[0] > 0f )
        {
            if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] >= main_work.act_move_dest[0] )
            {
                for ( uint num3 = num; num3 < num2; num3 += 1U )
                {
                    main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] = main_work.act_move_dest[0];
                }
                b |= 1;
            }
            num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
            num2 = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][1] + num;
            if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] >= main_work.act_move_dest[1] )
            {
                for ( uint num4 = num; num4 < num2; num4 += 1U )
                {
                    main_work.act_top_pos_x[( int )( ( UIntPtr )num4 )] = main_work.act_move_dest[1];
                }
                b |= 2;
            }
        }
        else if ( main_work.act_move_dest[0] < 0f )
        {
            if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] <= main_work.act_move_dest[0] )
            {
                for ( uint num5 = num; num5 < num2; num5 += 1U )
                {
                    main_work.act_top_pos_x[( int )( ( UIntPtr )num5 )] = main_work.act_move_dest[0];
                }
                b |= 1;
            }
            num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
            num2 = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][1] + num;
            if ( main_work.act_top_pos_x[( int )( ( UIntPtr )num )] <= main_work.act_move_dest[1] )
            {
                for ( uint num6 = num; num6 < num2; num6 += 1U )
                {
                    main_work.act_top_pos_x[( int )( ( UIntPtr )num6 )] = main_work.act_move_dest[1];
                }
                b |= 2;
            }
        }
        return b == 3;
    }

    // Token: 0x0600136B RID: 4971 RVA: 0x000AD5C0 File Offset: 0x000AB7C0
    private void dmStgSlctSetStageVrtclChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            array4[1] = main_work.act_move_pos_dst[( int )( ( UIntPtr )num3 )] - main_work.act_move_pos_src[( int )( ( UIntPtr )num3 )];
            array2[1] = array4[1] / 12f;
            main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] += array2[1];
        }
    }

    // Token: 0x0600136C RID: 4972 RVA: 0x000AD65C File Offset: 0x000AB85C
    private bool dmStgSlctIsStageVrtclChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        if ( ( float )main_work.timer >= 12f )
        {
            for ( uint num3 = num; num3 < num2; num3 += 1U )
            {
                main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] = main_work.act_move_pos_dst[( int )( ( UIntPtr )num3 )];
            }
            return true;
        }
        return false;
    }

    // Token: 0x0600136D RID: 4973 RVA: 0x000AD6C0 File Offset: 0x000AB8C0
    private void dmStgSlctSetStageCrsrChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float num = main_work.crsr_move_dst - main_work.crsr_move_src;
        float num2 = num / 8f;
        main_work.crsr_pos_y += num2;
    }

    // Token: 0x0600136E RID: 4974 RVA: 0x000AD6FD File Offset: 0x000AB8FD
    private bool dmStgSlctIsStageCrsrChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( ( float )main_work.timer >= 8f )
        {
            main_work.crsr_pos_y = main_work.crsr_move_dst;
            return true;
        }
        return false;
    }

    // Token: 0x0600136F RID: 4975 RVA: 0x000AD71C File Offset: 0x000AB91C
    private void dmStgSlctSetWinOpenEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( 0f <= main_work.win_timer && main_work.win_timer < 1f )
        {
            AppMain.DmSoundPlaySE( "Window" );
        }
        if ( main_work.win_timer > 8f )
        {
            main_work.flag |= 16U;
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
            if ( main_work.win_timer != 0f )
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

    // Token: 0x06001370 RID: 4976 RVA: 0x000AD800 File Offset: 0x000ABA00
    private void dmStgSlctSetWinCloseEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( main_work.win_timer != 0f )
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
            main_work.flag |= 16U;
            main_work.win_timer = 0f;
            for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 0f;
            }
            return;
        }
        main_work.win_timer -= 1f;
    }

    // Token: 0x06001371 RID: 4977 RVA: 0x000AD8A0 File Offset: 0x000ABAA0
    private void dmStgSlctSetActChngZonePosInit( AppMain.DMS_STGSLCT_MAIN_WORK main_work, int diff )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.chng_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.chng_zone)][1] + num;
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] = 100f;
        }
        main_work.act_move_src[0] = main_work.act_top_pos_x[( int )( ( UIntPtr )num )];
        num = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][0];
        num2 = AppMain.dm_stgslct_zone_act_num_tbl[( int )( ( UIntPtr )main_work.cur_zone )][1] + num;
        for ( uint num3 = num; num3 < num2; num3 += 1U )
        {
            if ( diff > 0 )
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] = 1120f;
                main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num3 )];
            }
            else
            {
                main_work.act_top_pos_x[( int )( ( UIntPtr )num3 )] = -1120f;
                main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num3 )];
            }
        }
        main_work.act_move_src[1] = main_work.act_top_pos_x[( int )( ( UIntPtr )num )];
    }

    // Token: 0x06001372 RID: 4978 RVA: 0x000AD984 File Offset: 0x000ABB84
    private void dmStgSlctSetFocusChangeEfctData( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        int diff = 0;
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = num + AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        uint num3 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1];
        if ( ( main_work.flag & 2048U ) != 0U )
        {
            diff = -1;
        }
        else if ( ( main_work.flag & 4096U ) != 0U )
        {
            diff = 1;
        }
        main_work.prev_stage = main_work.cur_stage;
        main_work.prev_disp_no = main_work.focus_disp_no;
        if ( ( main_work.flag & 64U ) != 0U )
        {
            uint cur_zone = main_work.cur_zone;
            if ( cur_zone == 4U )
            {
                for ( uint num4 = num; num4 < num2; num4 += 1U )
                {
                    main_work.act_move_pos_src[( int )( ( UIntPtr )num4 )] = main_work.act_top_pos_y[( int )( ( UIntPtr )num4 )];
                    main_work.act_move_pos_dst[( int )( ( UIntPtr )num4 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num4 )];
                }
            }
            else
            {
                for ( uint num5 = num; num5 < num2; num5 += 1U )
                {
                    main_work.act_move_pos_src[( int )( ( UIntPtr )num5 )] = main_work.act_top_pos_y[( int )( ( UIntPtr )num5 )];
                    main_work.act_move_pos_dst[( int )( ( UIntPtr )num5 )] = this.dm_stgslct_act_tab_disp_y_pos_tbl[main_work.focus_disp_no];
                }
            }
            if ( ( main_work.flag & 2048U ) != 0U && main_work.prev_disp_no == 0 && main_work.focus_disp_no == 3 )
            {
                main_work.flag |= 128U;
            }
            if ( ( main_work.flag & 4096U ) != 0U && main_work.prev_disp_no == 3 && main_work.focus_disp_no == 0 )
            {
                main_work.flag |= 128U;
            }
            if ( ( main_work.focus_disp_no == 3 && main_work.prev_disp_no == 0 ) || ( main_work.focus_disp_no == 0 && main_work.prev_disp_no == 3 ) )
            {
                main_work.crsr_prev_idx = main_work.crsr_idx;
                int prev_disp_no = main_work.prev_disp_no;
                main_work.crsr_idx = this.dmStgSlctGetRevisedStageCrsrNo( main_work.crsr_idx, diff, ( int )main_work.cur_zone, main_work.prev_disp_no );
                main_work.crsr_move_src = this.dm_stgslct_act_crsr_disp_y_pos_tbl[main_work.crsr_prev_idx];
                main_work.crsr_move_dst = this.dm_stgslct_act_crsr_disp_y_pos_tbl[main_work.crsr_idx];
                main_work.flag &= 4294967167U;
            }
            else if ( ( ( main_work.flag & 2048U ) == 0U || main_work.focus_disp_no != 0 || main_work.prev_disp_no != 0 ) && ( ( main_work.flag & 4096U ) == 0U || main_work.focus_disp_no != 3 || main_work.prev_disp_no != 3 ) )
            {
                main_work.flag &= 4294967167U;
            }
        }
        if ( ( main_work.flag & 128U ) != 0U )
        {
            main_work.crsr_prev_idx = main_work.crsr_idx;
            int prev_disp_no2 = main_work.prev_disp_no;
            main_work.crsr_idx = this.dmStgSlctGetRevisedStageCrsrNo( main_work.crsr_idx, diff, ( int )main_work.cur_zone, main_work.prev_disp_no );
            main_work.crsr_move_src = this.dm_stgslct_act_crsr_disp_y_pos_tbl[main_work.crsr_prev_idx];
            main_work.crsr_move_dst = this.dm_stgslct_act_crsr_disp_y_pos_tbl[main_work.crsr_idx];
        }
        main_work.cur_stage = ( int )( ( long )( main_work.crsr_idx + main_work.focus_disp_no ) + ( long )( ( ulong )num ) );
    }

    // Token: 0x06001373 RID: 4979 RVA: 0x000ADC48 File Offset: 0x000ABE48
    private int dmStgSlctGetRevisedStageVrtclNo( int idx, int diff, int zone_no, int crsr_idx )
    {
        AppMain.UNREFERENCED_PARAMETER( zone_no );
        int num = idx + diff;
        if ( num < 0 )
        {
            if ( crsr_idx == 0 )
            {
                num = 3;
            }
            else
            {
                num = 0;
            }
        }
        if ( num >= 4 )
        {
            if ( crsr_idx == 3 )
            {
                num = 0;
            }
            else
            {
                num = 3;
            }
        }
        return num;
    }

    // Token: 0x06001374 RID: 4980 RVA: 0x000ADC84 File Offset: 0x000ABE84
    private int dmStgSlctGetRevisedStageCrsrNo( int idx, int diff, int zone_no, int disp_act )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[zone_no][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[zone_no][1];
        int num3 = idx + diff;
        int num4 = (int)(AppMain.dm_stgslct_zone_act_num_tbl[zone_no][1] - 4U);
        if ( num4 < 0 )
        {
            num4 = 0;
        }
        if ( num3 < 0 )
        {
            if ( disp_act == 0 )
            {
                num3 = 3;
            }
            else
            {
                num3 = 0;
            }
        }
        if ( num3 > 3 )
        {
            if ( disp_act == num4 )
            {
                num3 = 0;
            }
            else
            {
                num3 = 3;
            }
        }
        return num3;
    }

    // Token: 0x06001375 RID: 4981 RVA: 0x000ADCE0 File Offset: 0x000ABEE0
    private int dmStgSlctGetRevisedZoneNo( int idx, int diff, int is_final_open, int is_spe_open )
    {
        int num;
        if ( is_final_open != 0 )
        {
            num = idx + diff;
            if ( is_spe_open != 0 )
            {
                if ( num < 0 )
                {
                    num = 5;
                }
                if ( num >= 6 )
                {
                    num = 0;
                }
            }
            else
            {
                if ( num < 0 )
                {
                    num = 4;
                }
                if ( num > 4 )
                {
                    num = 0;
                }
            }
        }
        else if ( is_spe_open != 0 )
        {
            num = idx + diff;
            if ( num == 4 )
            {
                if ( diff > 0 )
                {
                    num = 5;
                }
                else
                {
                    num = 3;
                }
            }
            if ( num < 0 )
            {
                num = 5;
            }
            if ( num >= 6 )
            {
                num = 0;
            }
        }
        else
        {
            num = idx + diff;
            if ( num < 0 )
            {
                num = 3;
            }
            if ( num > 3 )
            {
                num = 0;
            }
        }
        return num;
    }

    // Token: 0x06001376 RID: 4982 RVA: 0x000ADD4C File Offset: 0x000ABF4C
    private void dmStgSlctSetTableActiveInfo( AppMain.DMS_STGSLCT_MAIN_WORK main_work, uint cnt )
    {
        if ( main_work.is_clear_stage[( int )( ( UIntPtr )cnt )] < 0 )
        {
            for ( uint num = 58U; num <= 60U; num += 1U )
            {
                AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )num )], 1f );
            }
            AppMain.AoActSetFrame( main_work.act[61], 17f );
            AppMain.AoActSetFrame( main_work.act[65], 17f );
            return;
        }
        for ( uint num2 = 58U; num2 <= 60U; num2 += 1U )
        {
            AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )num2 )], 0f );
        }
        AppMain.AoActSetFrame( main_work.act[61], this.dm_stgslct_disp_msg_id_table_tbl[( int )( ( UIntPtr )cnt )] );
        AppMain.AoActSetFrame( main_work.act[65], this.dm_stgslct_disp_msg_id_table_tbl[( int )( ( UIntPtr )cnt )] );
        if ( main_work.hi_score[( int )( ( UIntPtr )cnt )] == 1000000000 && main_work.cur_game_mode == 1U )
        {
            for ( uint num3 = 58U; num3 <= 60U; num3 += 1U )
            {
                AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )num3 )], 1f );
            }
            return;
        }
        for ( uint num4 = 58U; num4 <= 60U; num4 += 1U )
        {
            AppMain.AoActSetFrame( main_work.act[( int )( ( UIntPtr )num4 )], 0f );
        }
    }

    // Token: 0x06001377 RID: 4983 RVA: 0x000ADE58 File Offset: 0x000AC058
    private bool dmStgSlctIsCanSelectAct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.is_clear_stage[main_work.cur_stage] == -1 )
        {
            main_work.flag &= 4294967291U;
            return false;
        }
        return main_work.hi_score[main_work.cur_stage] != 1000000000 || main_work.cur_game_mode != 1U;
    }

    // Token: 0x06001378 RID: 4984 RVA: 0x000ADEA8 File Offset: 0x000AC0A8
    private void dmStgSlctSetObiEfctPos( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( main_work.obi_pos[( int )( ( UIntPtr )num )] < -1120f )
            {
                main_work.obi_pos[( int )( ( UIntPtr )num )] = 1120f;
            }
            main_work.obi_pos[( int )( ( UIntPtr )num )] += -3f;
        }
    }

    // Token: 0x06001379 RID: 4985 RVA: 0x000ADEFD File Offset: 0x000AC0FD
    private void dmStgSlctMakeVertexAct( AppMain.DMS_STGSLCT_MAIN_WORK main_work, AppMain.AMS_PARAM_DRAW_PRIMITIVE param )
    {
        if ( main_work.proc_menu_update != null && !( main_work.proc_menu_update == new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectIdle ) ) )
        {
            main_work.proc_menu_update = new AppMain.DMS_STGSLCT_MAIN_WORK._proc_menu_update_( this.dmStgSlctProcStageSelectChngVrtclAct );
        }
    }

    // Token: 0x0600137A RID: 4986 RVA: 0x000ADF38 File Offset: 0x000AC138
    private void dmStgSlctDrawVertexAct( AppMain.AMS_TCB tcb_p )
    {
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 120U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x0600137B RID: 4987 RVA: 0x000ADF4C File Offset: 0x000AC14C
    private void dmStgSlctSetEmeTableInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float num = -180f;
        float num2 = num / 16f;
        main_work.chaos_eme_pos_y += num2;
    }

    // Token: 0x0600137C RID: 4988 RVA: 0x000ADF81 File Offset: 0x000AC181
    private bool dmStgSlctIsEmeTableInEfctEnd( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.chaos_eme_pos_y <= 0f )
        {
            main_work.chaos_eme_pos_y = 0f;
            return true;
        }
        return false;
    }

    // Token: 0x0600137D RID: 4989 RVA: 0x000ADFA0 File Offset: 0x000AC1A0
    private void dmStgSlctSetEmeTableOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float num = 180f;
        float num2 = num / 16f;
        main_work.chaos_eme_pos_y += num2;
    }

    // Token: 0x0600137E RID: 4990 RVA: 0x000ADFD5 File Offset: 0x000AC1D5
    private bool dmStgSlctIsEmeTableOutEfctEnd( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.chaos_eme_pos_y >= 180f )
        {
            main_work.chaos_eme_pos_y = 180f;
            return true;
        }
        return false;
    }

    // Token: 0x0600137F RID: 4991 RVA: 0x000ADFF4 File Offset: 0x000AC1F4
    private void dmStgSlctSetModeTexInEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float num = -180f;
        float num2 = num / 16f;
        main_work.mode_tex_pos_y += num2;
    }

    // Token: 0x06001380 RID: 4992 RVA: 0x000AE029 File Offset: 0x000AC229
    private bool dmStgSlctIsModeTexInEfctEnd( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.mode_tex_pos_y <= 0f )
        {
            main_work.mode_tex_pos_y = 0f;
            return true;
        }
        return false;
    }

    // Token: 0x06001381 RID: 4993 RVA: 0x000AE048 File Offset: 0x000AC248
    private void dmStgSlctSetModeTexOutEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        float num = 180f;
        float num2 = num / 16f;
        main_work.mode_tex_pos_y += num2;
    }

    // Token: 0x06001382 RID: 4994 RVA: 0x000AE07D File Offset: 0x000AC27D
    private bool dmStgSlctIsModeTexOutEfctEnd( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.mode_tex_pos_y >= 180f )
        {
            main_work.mode_tex_pos_y = 180f;
            return true;
        }
        return false;
    }

    // Token: 0x06001383 RID: 4995 RVA: 0x000AE09C File Offset: 0x000AC29C
    private void dmStgSlctSetBgFadeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        int num = (int)main_work.bg_fade.a;
        if ( main_work.cur_zone != main_work.cur_bg_id )
        {
            main_work.flag |= 2097152U;
            main_work.next_bg_id = main_work.cur_zone;
        }
        if ( ( main_work.flag & 2097152U ) != 0U )
        {
            if ( num < 255 )
            {
                num += 20;
            }
            else
            {
                num = 255;
                main_work.cur_bg_id = main_work.next_bg_id;
                main_work.flag &= 4292870143U;
            }
        }
        else if ( num > 0 )
        {
            num -= 20;
        }
        else
        {
            num = 0;
        }
        num = AppMain.MTM_MATH_CLIP( num, 0, 255 );
        main_work.bg_fade.a = ( byte )num;
    }

    // Token: 0x06001384 RID: 4996 RVA: 0x000AE14D File Offset: 0x000AC34D
    private void dmStgSlctSetZoneScrChangeEfct( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        if ( main_work.zone_scr_id > 360U )
        {
            main_work.zone_scr_id = 0U;
            return;
        }
        main_work.zone_scr_id += 1U;
    }

    // Token: 0x06001385 RID: 4997 RVA: 0x000AE174 File Offset: 0x000AC374
    private int dmStgSlctSetNextFocusAct( AppMain.DMS_STGSLCT_MAIN_WORK main_work, int set_stage_id )
    {
        if ( set_stage_id >= 21 )
        {
            return ( int )( ( uint )( ( ulong )AppMain.dm_stgslct_zone_act_num_tbl[5][0] + ( ulong )( ( long )( set_stage_id - 21 ) ) ) );
        }
        if ( set_stage_id >= 16 )
        {
            return 16;
        }
        if ( !AppMain.g_gs_main_sys_info.is_first_play )
        {
            return set_stage_id;
        }
        if ( AppMain.g_gs_main_sys_info.game_mode == 1 )
        {
            return set_stage_id;
        }
        if ( ( main_work.flag & 16777216U ) != 0U )
        {
            return set_stage_id;
        }
        uint num = AppMain.dm_stgslct_act_zone_no_tbl[(int)((UIntPtr)set_stage_id)];
        uint num2 = AppMain.dm_stgslct_zone_array_act_tbl[(int)((UIntPtr)set_stage_id)];
        for ( uint num3 = ( uint )( set_stage_id - ( int )num2 ); num3 < ( uint )( set_stage_id - ( int )num2 + 4 ); num3 += 1U )
        {
            if ( !AppMain.GsMainSysIsStageClear( ( int )num3 ) )
            {
                return ( int )num3;
            }
        }
        for ( uint num4 = 0U; num4 < 4U; num4 += 1U )
        {
            uint num5 = num4;
            uint num6 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)num5)][0];
            for ( int i = 0; i < 4; i++ )
            {
                if ( !AppMain.GsMainSysIsStageClear( ( int )( ( ulong )num6 + ( ulong )( ( long )i ) ) ) )
                {
                    return ( int )( ( ulong )num6 + ( ulong )( ( long )i ) );
                }
            }
        }
        return 16;
    }

    // Token: 0x06001386 RID: 4998 RVA: 0x000AE258 File Offset: 0x000AC458
    private bool dmStgSlctIsBossFocus( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        bool result = false;
        switch ( main_work.cur_zone )
        {
            case 4U:
            case 5U:
                break;
            default:
                if ( main_work.cur_game_mode == 0U )
                {
                    uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
                    uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
                    uint num3 = 0U;
                    for ( uint num4 = num; num4 < num2; num4 += 1U )
                    {
                        if ( 1 == main_work.is_clear_stage[( int )( ( UIntPtr )num4 )] )
                        {
                            num3 += 1U;
                        }
                    }
                    if ( 3U == num3 )
                    {
                        result = true;
                    }
                }
                break;
        }
        return result;
    }

    // Token: 0x06001387 RID: 4999 RVA: 0x000AE2D4 File Offset: 0x000AC4D4
    private void dmStgSlctStageSelectChngZoneSetInZoneScroll( AppMain.DMS_STGSLCT_MAIN_WORK main_work )
    {
        this.dmStgSlctStageSelectChngZoneSetInZoneScroll( main_work, 0 );
    }

    // Token: 0x06001388 RID: 5000 RVA: 0x000AE2E0 File Offset: 0x000AC4E0
    private void dmStgSlctStageSelectChngZoneSetInZoneScroll( AppMain.DMS_STGSLCT_MAIN_WORK main_work, int stage )
    {
        uint num = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][0];
        uint num2 = AppMain.dm_stgslct_zone_act_num_tbl[(int)((UIntPtr)main_work.cur_zone)][1] + num;
        switch ( main_work.cur_zone )
        {
            case 4U:
                main_work.focus_disp_no = 0;
                for ( uint num3 = num; num3 < num2; num3 += 1U )
                {
                    main_work.act_top_pos_y[( int )( ( UIntPtr )num3 )] = AppMain.dm_stgslct_act_disp_y_pos_tbl[( int )( ( UIntPtr )num3 )];
                }
                return;
            case 5U:
                {
                    int a = stage - 18;
                    main_work.focus_disp_no = AppMain.MTM_MATH_CLIP( a, 0, 4 );
                    for ( uint num4 = num; num4 < num2; num4 += 1U )
                    {
                        main_work.act_top_pos_y[( int )( ( UIntPtr )num4 )] = this.dm_stgslct_act_tab_disp_y_pos_tbl[main_work.focus_disp_no];
                    }
                    return;
                }
            default:
                if ( this.dmStgSlctIsBossFocus( main_work ) )
                {
                    main_work.focus_disp_no = 1;
                }
                else
                {
                    if ( stage <= 7 )
                    {
                        if ( stage != 3 && stage != 7 )
                        {
                            goto IL_D8;
                        }
                    }
                    else if ( stage != 11 && stage != 15 )
                    {
                        goto IL_D8;
                    }
                    main_work.focus_disp_no = 1;
                    goto IL_DF;
                    IL_D8:
                    main_work.focus_disp_no = 0;
                }
                IL_DF:
                for ( uint num5 = num; num5 < num2; num5 += 1U )
                {
                    main_work.act_top_pos_y[( int )( ( UIntPtr )num5 )] = this.dm_stgslct_act_tab_disp_y_pos_tbl[main_work.focus_disp_no];
                }
                return;
        }
    }
}