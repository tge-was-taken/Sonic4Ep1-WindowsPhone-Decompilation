using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using er;
using er.web;
using gs.backup;
using Sonic4ep1;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Phone.Tasks;

public partial class AppMain
{
    // Token: 0x0200021C RID: 540
    private enum DME_TITLE_DATA_TYPE
    {
        // Token: 0x04005695 RID: 22165
        DME_TITLE_DATA_TYPE_CMN_DATA,
        // Token: 0x04005696 RID: 22166
        DME_TITLE_DATA_TYPE_LANG_DATA,
        // Token: 0x04005697 RID: 22167
        DME_TITLE_DATA_TYPE_MAX,
        // Token: 0x04005698 RID: 22168
        DME_TITLE_DATA_TYPE_NONE
    }

    // Token: 0x0200021D RID: 541
    private enum DME_TITLE_NEXT_EVT
    {
        // Token: 0x0400569A RID: 22170
        DME_TITLE_NEXT_EVT_MAINGAME_1_1,
        // Token: 0x0400569B RID: 22171
        DME_TITLE_NEXT_EVT_STAGESELECT,
        // Token: 0x0400569C RID: 22172
        DME_TITLE_NEXT_EVT_OPTION,
        // Token: 0x0400569D RID: 22173
        DME_TITLE_NEXT_EVT_RANKING,
        // Token: 0x0400569E RID: 22174
        DME_TITLE_NEXT_EVT_LOGO,
        // Token: 0x0400569F RID: 22175
        DME_TITLE_NEXT_EVT_TITLE,
        // Token: 0x040056A0 RID: 22176
        DME_TITLE_NEXT_EVT_MAX,
        // Token: 0x040056A1 RID: 22177
        DME_TITLE_NEXT_EVT_NONE
    }

    // Token: 0x0200021E RID: 542
    private enum DME_TITLE_MENU_TYPE
    {
        // Token: 0x040056A3 RID: 22179
        DME_TITLE_MENU_TYPE_START,
        // Token: 0x040056A4 RID: 22180
        DME_TITLE_MENU_TYPE_TUDUKI,
        // Token: 0x040056A5 RID: 22181
        DME_TITLE_MENU_TYPE_OPTION,
        // Token: 0x040056A6 RID: 22182
        DME_TITLE_MENU_TYPE_ACHIEVEMENTS,
        // Token: 0x040056A7 RID: 22183
        DME_TITLE_MENU_TYPE_LEADERBOARDS,
        // Token: 0x040056A8 RID: 22184
        DME_TITLE_MENU_TYPE_NUM,
        // Token: 0x040056A9 RID: 22185
        DME_TITLE_MENU_TYPE_NONE
    }

    // Token: 0x0200021F RID: 543
    private enum DME_TITLE_WIN_TYPE
    {
        // Token: 0x040056AB RID: 22187
        DME_TITLE_WIN_TYPE_DEL_DATA1,
        // Token: 0x040056AC RID: 22188
        DME_TITLE_WIN_TYPE_DEL_DATA2,
        // Token: 0x040056AD RID: 22189
        DME_TITLE_WIN_TYPE_DEL_DATA3,
        // Token: 0x040056AE RID: 22190
        DME_TITLE_WIN_TYPE_DEL_DATA4,
        // Token: 0x040056AF RID: 22191
        DME_TITLE_WIN_TYPE_DEL_DATA5,
        // Token: 0x040056B0 RID: 22192
        DME_TITLE_WIN_TYPE_MAX,
        // Token: 0x040056B1 RID: 22193
        DME_TITLE_WIN_TYPE_NONE
    }

    // Token: 0x02000220 RID: 544
    private enum DME_TITLE_ACT
    {
        // Token: 0x040056B3 RID: 22195
        ACT_BTN_L,
        // Token: 0x040056B4 RID: 22196
        ACT_BTN_C,
        // Token: 0x040056B5 RID: 22197
        ACT_BTN_R,
        // Token: 0x040056B6 RID: 22198
        ACT_BTN_L2,
        // Token: 0x040056B7 RID: 22199
        ACT_BTN_C2,
        // Token: 0x040056B8 RID: 22200
        ACT_BTN_R2,
        // Token: 0x040056B9 RID: 22201
        ACT_BTN_L3,
        // Token: 0x040056BA RID: 22202
        ACT_BTN_C3,
        // Token: 0x040056BB RID: 22203
        ACT_BTN_R3,
        // Token: 0x040056BC RID: 22204
        ACT_BTN_L4,
        // Token: 0x040056BD RID: 22205
        ACT_BTN_C4,
        // Token: 0x040056BE RID: 22206
        ACT_BTN_R4,
        // Token: 0x040056BF RID: 22207
        ACT_BTN_L5,
        // Token: 0x040056C0 RID: 22208
        ACT_BTN_C5,
        // Token: 0x040056C1 RID: 22209
        ACT_BTN_R5,
        // Token: 0x040056C2 RID: 22210
        ACT_BACK_BTN_L,
        // Token: 0x040056C3 RID: 22211
        ACT_BACK_BTN_R,
        // Token: 0x040056C4 RID: 22212
        ACT_GAME_BTN_L,
        // Token: 0x040056C5 RID: 22213
        ACT_GAME_BTN_R,
        // Token: 0x040056C6 RID: 22214
        ACT_TEX_START,
        // Token: 0x040056C7 RID: 22215
        ACT_TEX_GAME,
        // Token: 0x040056C8 RID: 22216
        ACT_TEX_TUDUKI,
        // Token: 0x040056C9 RID: 22217
        ACT_TEX_OPTION,
        // Token: 0x040056CA RID: 22218
        ACT_TEX_KANZENBAN,
        // Token: 0x040056CB RID: 22219
        ACT_TEX_ACHIEVEMENTS,
        // Token: 0x040056CC RID: 22220
        ACT_TEX_LEADERBOARDS,
        // Token: 0x040056CD RID: 22221
        ACT_TEX_TOP_BACK,
        // Token: 0x040056CE RID: 22222
        ACT_TEX_TOP_GAME,
        // Token: 0x040056CF RID: 22223
        ACT_WIN_TEX_MSG1,
        // Token: 0x040056D0 RID: 22224
        ACT_WIN_TEX_MSG2,
        // Token: 0x040056D1 RID: 22225
        ACT_BTN_CANCEL,
        // Token: 0x040056D2 RID: 22226
        ACT_BTN_X,
        // Token: 0x040056D3 RID: 22227
        ACT_WIN_NO_BTN_L,
        // Token: 0x040056D4 RID: 22228
        ACT_WIN_NO_BTN_C,
        // Token: 0x040056D5 RID: 22229
        ACT_WIN_NO_BTN_R,
        // Token: 0x040056D6 RID: 22230
        ACT_WIN_YES_BTN_L,
        // Token: 0x040056D7 RID: 22231
        ACT_WIN_YES_BTN_C,
        // Token: 0x040056D8 RID: 22232
        ACT_WIN_YES_BTN_R,
        // Token: 0x040056D9 RID: 22233
        ACT_TEX_YES,
        // Token: 0x040056DA RID: 22234
        ACT_TEX_NO,
        // Token: 0x040056DB RID: 22235
        ACT_TEX_BACK,
        // Token: 0x040056DC RID: 22236
        ACT_NUM,
        // Token: 0x040056DD RID: 22237
        ACT_LANG = 19,
        // Token: 0x040056DE RID: 22238
        ACT_NONE
    }

    // Token: 0x02000221 RID: 545
    public class DMS_TITLE_MAIN_WORK
    {
        // Token: 0x040056DF RID: 22239
        public readonly AppMain.AMS_FS[] arc_cmn_amb_fs = new AppMain.AMS_FS[4];

        // Token: 0x040056E0 RID: 22240
        public readonly AppMain.AMS_AMB_HEADER[] arc_cmn_amb = new AppMain.AMS_AMB_HEADER[4];

        // Token: 0x040056E1 RID: 22241
        public readonly AppMain.A2S_AMA_HEADER[] cmn_ama = new AppMain.A2S_AMA_HEADER[4];

        // Token: 0x040056E2 RID: 22242
        public readonly AppMain.AMS_AMB_HEADER[] cmn_amb = new AppMain.AMS_AMB_HEADER[4];

        // Token: 0x040056E3 RID: 22243
        public readonly AppMain.AOS_TEXTURE[] cmn_tex = AppMain.New<AppMain.AOS_TEXTURE>(4);

        // Token: 0x040056E4 RID: 22244
        public readonly AppMain.DMS_BUY_SCR_WORK buy_scr_work = new AppMain.DMS_BUY_SCR_WORK();

        // Token: 0x040056E5 RID: 22245
        public readonly AppMain.AMS_FS[] arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x040056E6 RID: 22246
        public readonly AppMain.AMS_FS[] file_arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x040056E7 RID: 22247
        public readonly AppMain.AMS_FS[] user_arc_amb_fs = new AppMain.AMS_FS[2];

        // Token: 0x040056E8 RID: 22248
        public AppMain.AMS_FS cmn_win_amb_fs;

        // Token: 0x040056E9 RID: 22249
        public AppMain.AMS_FS win_amb_fs;

        // Token: 0x040056EA RID: 22250
        public readonly AppMain.AMS_AMB_HEADER[] arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x040056EB RID: 22251
        public readonly AppMain.AMS_AMB_HEADER[] file_arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x040056EC RID: 22252
        public readonly AppMain.AMS_AMB_HEADER[] user_arc_amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x040056ED RID: 22253
        public AppMain.AMS_AMB_HEADER cmn_win_amb;

        // Token: 0x040056EE RID: 22254
        public AppMain.AMS_AMB_HEADER win_amb;

        // Token: 0x040056EF RID: 22255
        public readonly AppMain.A2S_AMA_HEADER[] ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x040056F0 RID: 22256
        public readonly AppMain.AMS_AMB_HEADER[] amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x040056F1 RID: 22257
        public readonly AppMain.AOS_TEXTURE[] tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x040056F2 RID: 22258
        public readonly AppMain.AOS_TEXTURE win_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x040056F3 RID: 22259
        public readonly AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[41];

        // Token: 0x040056F4 RID: 22260
        public AppMain.DMS_TITLE_MAIN_WORK._proc_ proc_input;

        // Token: 0x040056F5 RID: 22261
        public AppMain.DMS_TITLE_MAIN_WORK._proc_ proc_update;

        // Token: 0x040056F6 RID: 22262
        public AppMain.DMS_TITLE_MAIN_WORK._proc_ proc_win_input;

        // Token: 0x040056F7 RID: 22263
        public AppMain.DMS_TITLE_MAIN_WORK._proc_ proc_win_update;

        // Token: 0x040056F8 RID: 22264
        public AppMain.DMS_TITLE_MAIN_WORK._proc_ proc_draw;

        // Token: 0x040056F9 RID: 22265
        public float timer;

        // Token: 0x040056FA RID: 22266
        public float disp_timer;

        // Token: 0x040056FB RID: 22267
        public float win_timer;

        // Token: 0x040056FC RID: 22268
        public float mmenu_win_timer;

        // Token: 0x040056FD RID: 22269
        public uint flag;

        // Token: 0x040056FE RID: 22270
        public int disp_change_time;

        // Token: 0x040056FF RID: 22271
        public uint announce_flag;

        // Token: 0x04005700 RID: 22272
        public int win_mode;

        // Token: 0x04005701 RID: 22273
        public int cur_slct_menu;

        // Token: 0x04005702 RID: 22274
        public int prev_slct_menu;

        // Token: 0x04005703 RID: 22275
        public int win_cur_slct;

        // Token: 0x04005704 RID: 22276
        public int next_evt;

        // Token: 0x04005705 RID: 22277
        public bool is_init_play;

        // Token: 0x04005706 RID: 22278
        public bool is_jp_region;

        // Token: 0x04005707 RID: 22279
        public bool is_no_save_data;

        // Token: 0x04005708 RID: 22280
        public float cur_crsr_pos_y;

        // Token: 0x04005709 RID: 22281
        public float src_crsr_pos_y;

        // Token: 0x0400570A RID: 22282
        public float dst_crsr_pos_y;

        // Token: 0x0400570B RID: 22283
        public readonly float[] decide_menu_frm = new float[5];

        // Token: 0x0400570C RID: 22284
        public int slct_menu_num;

        // Token: 0x0400570D RID: 22285
        public readonly float[] mmenu_win_size_rate = new float[2];

        // Token: 0x0400570E RID: 22286
        public readonly float[] win_size_rate = new float[2];

        // Token: 0x0400570F RID: 22287
        public uint disp_flag;

        // Token: 0x04005710 RID: 22288
        public readonly CTrgAoAction[] trg_slct = AppMain.New<CTrgAoAction>(5);

        // Token: 0x04005711 RID: 22289
        public readonly CTrgAoAction[] trg_answer = AppMain.New<CTrgAoAction>(2);

        // Token: 0x04005712 RID: 22290
        public readonly CTrgAoAction trg_return = new CTrgAoAction();

        // Token: 0x04005713 RID: 22291
        public readonly CTrgAoAction trg_game = new CTrgAoAction();

        // Token: 0x04005714 RID: 22292
        public uint flag_prev;

        // Token: 0x02000222 RID: 546
        // (Invoke) Token: 0x06002377 RID: 9079
        public delegate void _proc_( AppMain.DMS_TITLE_MAIN_WORK work );
    }

    // Token: 0x02000223 RID: 547
    public struct CLocalBtnBase_EBtn
    {
        // Token: 0x02000224 RID: 548
        public enum Type
        {
            // Token: 0x04005716 RID: 22294
            Left,
            // Token: 0x04005717 RID: 22295
            Center,
            // Token: 0x04005718 RID: 22296
            Right,
            // Token: 0x04005719 RID: 22297
            Max,
            // Token: 0x0400571A RID: 22298
            None
        }
    }

    // Token: 0x02000225 RID: 549
    public struct CLocalBtnBase_EType
    {
        // Token: 0x02000226 RID: 550
        public enum Type
        {
            // Token: 0x0400571C RID: 22300
            Dark,
            // Token: 0x0400571D RID: 22301
            Normal,
            // Token: 0x0400571E RID: 22302
            Max,
            // Token: 0x0400571F RID: 22303
            None
        }
    }

    // Token: 0x02000227 RID: 551
    public struct CLocalBtnBase_EAct
    {
        // Token: 0x02000228 RID: 552
        public enum Type
        {
            // Token: 0x04005721 RID: 22305
            Game,
            // Token: 0x04005722 RID: 22306
            Tuduki,
            // Token: 0x04005723 RID: 22307
            Option,
            // Token: 0x04005724 RID: 22308
            Achievements,
            // Token: 0x04005725 RID: 22309
            Leaderboards,
            // Token: 0x04005726 RID: 22310
            Max,
            // Token: 0x04005727 RID: 22311
            None
        }
    }

    // Token: 0x06000C5B RID: 3163 RVA: 0x0006BC80 File Offset: 0x00069E80
    private void DmTitleStart( object arg )
    {
        AppMain.dm_title_is_title_start = true;
        short old_evt_id = AppMain.SyGetEvtInfo().old_evt_id;
        if ( AppMain.dm_title_is_title_start )
        {
            SBackup sbackup = SBackup.CreateInstance();
            sbackup.Init();
        }
        this.dmTitleInit();
    }

    // Token: 0x06000C5C RID: 3164 RVA: 0x0006BCB7 File Offset: 0x00069EB7
    private void DmMainMenuStart( object arg )
    {
        AppMain.dm_title_is_title_start = false;
        this.dmTitleInit();
    }

    // Token: 0x06000C5D RID: 3165 RVA: 0x0006BCCC File Offset: 0x00069ECC
    private void dmTitleInit()
    {
        GC.Collect();
        AppMain.AoActSysSetDrawStateEnable( true );
        AppMain.AoActSysSetDrawState( 10U );
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(this.dmTitleProcMain), new AppMain.GSF_TASK_PROCEDURE(this.dmTitleDest), 0U, 0, 8192U, 10, () => new AppMain.DMS_TITLE_MAIN_WORK(), "TITLE_MAIN");
        AppMain.DMS_TITLE_MAIN_WORK dms_TITLE_MAIN_WORK = (AppMain.DMS_TITLE_MAIN_WORK)mts_TASK_TCB.work;
        this.dmTitleSetInitDispData( dms_TITLE_MAIN_WORK );
        if ( AppMain.dm_title_is_title_start )
        {
            AppMain.AoAccountClearCurrentId();
        }
        if ( AppMain.GeEnvGetDecideKey() == AppMain.GSE_DECIDE_KEY.GSD_DECIDE_KEY_O )
        {
            dms_TITLE_MAIN_WORK.is_jp_region = true;
        }
        else
        {
            dms_TITLE_MAIN_WORK.is_jp_region = false;
        }
        dms_TITLE_MAIN_WORK.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleLoadFontData );
    }

    // Token: 0x06000C5E RID: 3166 RVA: 0x0006BD7C File Offset: 0x00069F7C
    private void dmTitleSetInitDispData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        switch ( AppMain.SyGetEvtInfo().old_evt_id )
        {
            case 5:
                main_work.cur_slct_menu = 1;
                goto IL_74;
            case 6:
                main_work.cur_slct_menu = 0;
                goto IL_74;
            case 8:
                if ( !AppMain.GsMainSysIsStageClear( 0 ) || AppMain.GsTrialIsTrial() )
                {
                    main_work.cur_slct_menu = 1;
                    goto IL_74;
                }
                main_work.cur_slct_menu = 2;
                goto IL_74;
            case 10:
                main_work.cur_slct_menu = 1;
                goto IL_74;
        }
        main_work.cur_slct_menu = 0;
        IL_74:
        main_work.disp_flag |= 2U;
        if ( AppMain.GsTrialIsTrial() )
        {
            main_work.cur_crsr_pos_y = AppMain.dm_title_crsr_trial_pos_y_tbl[main_work.cur_slct_menu];
            return;
        }
        main_work.cur_crsr_pos_y = ( float )main_work.cur_slct_menu * AppMain.dm_title_crsr_pos_y_tbl[1] + AppMain.dm_title_crsr_pos_y_tbl[0];
    }

    // Token: 0x06000C5F RID: 3167 RVA: 0x0006BE44 File Offset: 0x0006A044
    private void dmTitleProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_TITLE_MAIN_WORK dms_TITLE_MAIN_WORK = (AppMain.DMS_TITLE_MAIN_WORK)tcb.work;
        dms_TITLE_MAIN_WORK.flag_prev = dms_TITLE_MAIN_WORK.flag;
        if ( ( dms_TITLE_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.mtTaskClearTcb( tcb );
            this.dmTitleSetNextEvent( dms_TITLE_MAIN_WORK );
        }
        if ( ( dms_TITLE_MAIN_WORK.flag & 2147483648U ) != 0U && AppMain.event_after_buy )
        {
            dms_TITLE_MAIN_WORK.is_init_play = true;
            dms_TITLE_MAIN_WORK.is_no_save_data = true;
            AppMain.event_after_buy = false;
            dms_TITLE_MAIN_WORK.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeOut );
            dms_TITLE_MAIN_WORK.flag &= 2147483647U;
            dms_TITLE_MAIN_WORK.flag |= 1073741824U;
            AppMain.IzFadeInitEasy( 1U, 1U, 32f );
            AppMain.DmSndBgmPlayerExit();
            dms_TITLE_MAIN_WORK.flag |= 524288U;
            dms_TITLE_MAIN_WORK.flag &= 4294967291U;
            dms_TITLE_MAIN_WORK.flag &= 4294967293U;
            dms_TITLE_MAIN_WORK.proc_input = null;
            dms_TITLE_MAIN_WORK.proc_win_input = null;
            dms_TITLE_MAIN_WORK.win_timer = 0f;
            dms_TITLE_MAIN_WORK.win_cur_slct = 0;
            dms_TITLE_MAIN_WORK.win_mode = 0;
        }
        if ( dms_TITLE_MAIN_WORK.proc_win_update != null )
        {
            dms_TITLE_MAIN_WORK.proc_win_update( dms_TITLE_MAIN_WORK );
        }
        if ( dms_TITLE_MAIN_WORK.proc_update != null )
        {
            dms_TITLE_MAIN_WORK.proc_update( dms_TITLE_MAIN_WORK );
        }
        if ( dms_TITLE_MAIN_WORK.proc_draw != null )
        {
            dms_TITLE_MAIN_WORK.proc_draw( dms_TITLE_MAIN_WORK );
        }
    }

    // Token: 0x06000C60 RID: 3168 RVA: 0x0006BF89 File Offset: 0x0006A189
    private void dmTitleDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06000C61 RID: 3169 RVA: 0x0006BF8C File Offset: 0x0006A18C
    private void dmTitleSetNextEvent( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        short evt_case = 0;
        if ( ( main_work.flag & 1073741824U ) != 0U )
        {
            evt_case = 5;
            main_work.flag &= 3221225471U;
            AppMain.SyDecideEvtCase( evt_case );
            AppMain.SyChangeNextEvt();
            return;
        }
        if ( ( main_work.flag & 1048576U ) != 0U )
        {
            evt_case = 4;
            main_work.flag &= 4293918719U;
            AppMain.SyDecideEvtCase( evt_case );
            AppMain.SyChangeNextEvt();
            return;
        }
        switch ( main_work.cur_slct_menu )
        {
            case 0:
                evt_case = 0;
                this.dmTitleSetFirstPlayData( main_work );
                AppMain.nextDemoLevel = 0;
                AppMain.g_gs_main_sys_info.stage_id = 0;
                AppMain.g_gs_main_sys_info.char_id[0] = 0;
                AppMain.g_gs_main_sys_info.game_mode = 0;
                if ( AppMain.GsTrialIsTrial() )
                {
                    AppMain.g_gs_main_sys_info.rest_player_num = 3U;
                }
                AppMain.g_gs_main_sys_info.game_flag &= 4294967167U;
                AppMain.GmMainGSInit();
                break;
            case 1:
                if ( !AppMain.GsMainSysIsStageClear( 0 ) || main_work.is_init_play )
                {
                    evt_case = 0;
                    AppMain.g_gs_main_sys_info.stage_id = 0;
                    AppMain.g_gs_main_sys_info.char_id[0] = 0;
                    AppMain.g_gs_main_sys_info.game_mode = 0;
                    AppMain.g_gs_main_sys_info.game_flag &= 4294967167U;
                    AppMain.GmMainGSInit();
                }
                else
                {
                    evt_case = 1;
                }
                break;
            case 2:
                evt_case = 2;
                AppMain.dm_opt_show_xboxlive = false;
                break;
            case 3:
                evt_case = 2;
                LiveFeature.getInstance().ShowAchievements();
                AppMain.dm_opt_show_xboxlive = true;
                break;
            case 4:
                evt_case = 2;
                LiveFeature.getInstance().ShowLeaderboards();
                AppMain.dm_opt_show_xboxlive = true;
                break;
        }
        AppMain.SyDecideEvtCase( evt_case );
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x06000C62 RID: 3170 RVA: 0x0006C116 File Offset: 0x0006A316
    private void dmTitleLoadFontData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.GsFontBuild();
        main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleIsLoadFontData );
    }

    // Token: 0x06000C63 RID: 3171 RVA: 0x0006C12F File Offset: 0x0006A32F
    private void dmTitleIsLoadFontData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.GsFontIsBuilded() )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleLoadRequest );
        }
    }

    // Token: 0x06000C64 RID: 3172 RVA: 0x0006C14C File Offset: 0x0006A34C
    private void dmTitleLoadRequest( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        main_work.arc_amb_fs[0] = AppMain.amFsReadBackground( "DEMO/TITLE/D_TITLE.AMB" );
        main_work.arc_amb_fs[1] = AppMain.amFsReadBackground( AppMain.dm_title_file_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        for ( int i = 0; i < 3; i++ )
        {
            main_work.arc_cmn_amb_fs[i] = AppMain.amFsReadBackground( AppMain.dm_title_menu_cmn_amb_name_tbl[i] );
        }
        main_work.arc_cmn_amb_fs[3] = AppMain.amFsReadBackground( AppMain.dm_title_menu_cmn_lng_amb_name_tbl[AppMain.GsEnvGetLanguage()] );
        this.DmTitleOpLoad();
        main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcLoadWait );
    }

    // Token: 0x06000C65 RID: 3173 RVA: 0x0006C1D4 File Offset: 0x0006A3D4
    private void dmTitleProcLoadWait( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( this.dmTitleIsDataLoad( main_work ) )
        {
            for ( int i = 0; i < 2; i++ )
            {
                main_work.arc_amb[i] = AppMain.readAMBFile( main_work.arc_amb_fs[i] );
                main_work.ama[i] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_amb[i], 0 ) );
                if ( i == 0 )
                {
                    main_work.ama[i].act_tbl[0].ofst.top = 50f;
                    main_work.ama[i].act_tbl[0].ofst.bottom = -50f;
                    main_work.ama[i].act_tbl[1].ofst.top = 50f;
                    main_work.ama[i].act_tbl[1].ofst.bottom = -50f;
                    main_work.ama[i].act_tbl[1].hit.hit_tbl[0].rect.top = -50f;
                    main_work.ama[i].act_tbl[1].hit.hit_tbl[0].rect.bottom = 50f;
                    main_work.ama[i].act_tbl[2].ofst.top = 50f;
                    main_work.ama[i].act_tbl[2].ofst.bottom = -50f;
                }
                if ( i == 1 )
                {
                    main_work.ama[i].act_num += 2U;
                    AppMain.A2S_AMA_ACT[] array = new AppMain.A2S_AMA_ACT[main_work.ama[i].act_num];
                    Array.Copy( main_work.ama[i].act_tbl, array, ( int )( main_work.ama[i].act_num - 2U ) );
                    uint num = main_work.ama[i].act_num - 2U;
                    array[( int )( ( UIntPtr )num )] = new AppMain.A2S_AMA_ACT();
                    array[( int )( ( UIntPtr )num )].Assign( array[0] );
                    array[( int )( ( UIntPtr )( num + 1U ) )] = new AppMain.A2S_AMA_ACT();
                    array[( int )( ( UIntPtr )( num + 1U ) )].Assign( array[1] );
                    array[( int )( ( UIntPtr )num )].anm.anm_tbl[0].tex_id = 9;
                    array[( int )( ( UIntPtr )( num + 1U ) )].anm.anm_tbl[0].tex_id = 10;
                    main_work.ama[i].act_tbl = array;
                }
                string dir;
                main_work.amb[i] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_amb[i], 1, out dir ) );
                main_work.amb[i].dir = dir;
                AppMain.amFsClearRequest( main_work.arc_amb_fs[i] );
                main_work.arc_amb_fs[i] = null;
                AppMain.AoTexBuild( main_work.tex[i], main_work.amb[i] );
                if ( i == 1 )
                {
                    main_work.tex[i].txb.texfilelist.nTex += 2;
                    AppMain.NNS_TEXFILE[] array2 = AppMain.New<AppMain.NNS_TEXFILE>(main_work.tex[i].txb.texfilelist.nTex);
                    for ( int j = 0; j < main_work.tex[i].txb.texfilelist.nTex; j++ )
                    {
                        int num2 = (j < main_work.tex[i].txb.texfilelist.nTex - 2) ? j : (main_work.tex[i].txb.texfilelist.nTex - 2 - 1);
                        array2[j].Bank = main_work.tex[i].txb.texfilelist.pTexFileList[num2].Bank;
                        array2[j].fType = main_work.tex[i].txb.texfilelist.pTexFileList[num2].fType;
                        array2[j].Filename = main_work.tex[i].txb.texfilelist.pTexFileList[num2].Filename;
                        array2[j].MinFilter = main_work.tex[i].txb.texfilelist.pTexFileList[num2].MinFilter;
                        array2[j].MagFilter = main_work.tex[i].txb.texfilelist.pTexFileList[num2].MagFilter;
                        array2[j].GlobalIndex = main_work.tex[i].txb.texfilelist.pTexFileList[num2].GlobalIndex;
                    }
                    switch ( AppMain.GsEnvGetLanguage() )
                    {
                        case 0:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_JP.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_JP.PNG";
                            break;
                        case 1:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_US.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_US.PNG";
                            break;
                        case 2:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_FR.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_FR.PNG";
                            break;
                        case 3:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_IT.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_IT.PNG";
                            break;
                        case 4:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_GE.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_GE.PNG";
                            break;
                        case 5:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_SP.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_SP.PNG";
                            break;
                        case 6:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_FI.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_FI.PNG";
                            break;
                        case 7:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_PT.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_PT.PNG";
                            break;
                        case 8:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_RU.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_RU.PNG";
                            break;
                        case 9:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_CN.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_CN.PNG";
                            break;
                        case 10:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_HK.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_HK.PNG";
                            break;
                        default:
                            array2[main_work.tex[i].txb.texfilelist.nTex - 2].Filename = "D_TITLE_TEX_TROPHY_US.PNG";
                            array2[main_work.tex[i].txb.texfilelist.nTex - 1].Filename = "D_TITLE_TEX_LB_US.PNG";
                            break;
                    }
                    main_work.tex[i].txb.texfilelist.pTexFileList = array2;
                }
                AppMain.AoTexLoad( main_work.tex[i] );
            }
            for ( int k = 0; k < 4; k++ )
            {
                main_work.arc_cmn_amb[k] = AppMain.readAMBFile( main_work.arc_cmn_amb_fs[k] );
                main_work.cmn_ama[k] = AppMain.readAMAFile( AppMain.amBindGet( main_work.arc_cmn_amb[k], 0 ) );
                string dir2;
                main_work.cmn_amb[k] = AppMain.readAMBFile( AppMain.amBindGet( main_work.arc_cmn_amb[k], 1, out dir2 ) );
                main_work.cmn_amb[k].dir = dir2;
                AppMain.amFsClearRequest( main_work.arc_cmn_amb_fs[k] );
                main_work.arc_cmn_amb_fs[k] = null;
                AppMain.AoTexBuild( main_work.cmn_tex[k], main_work.cmn_amb[k] );
                AppMain.AoTexLoad( main_work.cmn_tex[k] );
            }
            this.DmTitleOpBuild();
            AppMain.DmSndBgmPlayerInit();
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcTexBuildWait );
        }
    }

    // Token: 0x06000C66 RID: 3174 RVA: 0x0006CB1C File Offset: 0x0006AD1C
    private void dmTitleProcTexBuildWait( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( this.dmTitleIsTexLoad( main_work ) && AppMain.DmSndBgmPlayerIsSndSysBuild() )
        {
            for ( int i = 0; i < 41; i++ )
            {
                int num = 38;
                int num2 = 32;
                AppMain.A2S_AMA_HEADER a2S_AMA_HEADER;
                AppMain.AOS_TEXTURE tex;
                if ( i >= num )
                {
                    a2S_AMA_HEADER = main_work.cmn_ama[3];
                    tex = main_work.cmn_tex[3];
                }
                else if ( i >= num2 )
                {
                    a2S_AMA_HEADER = main_work.cmn_ama[2];
                    tex = main_work.cmn_tex[2];
                }
                else if ( i >= 30 )
                {
                    a2S_AMA_HEADER = main_work.cmn_ama[0];
                    tex = main_work.cmn_tex[0];
                }
                else if ( i < 19 )
                {
                    a2S_AMA_HEADER = main_work.ama[0];
                    tex = main_work.tex[0];
                }
                else
                {
                    a2S_AMA_HEADER = main_work.ama[1];
                    tex = main_work.tex[1];
                    switch ( i )
                    {
                        case 20:
                            a2S_AMA_HEADER.act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[i] )].mtn.trs_tbl[0].trs_y = 90f;
                            break;
                        case 21:
                            a2S_AMA_HEADER.act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[i] )].mtn.trs_tbl[0].trs_y = 200f;
                            break;
                        case 22:
                            a2S_AMA_HEADER.act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[i] )].mtn.trs_tbl[0].trs_y = 310f;
                            break;
                        case 24:
                            a2S_AMA_HEADER.act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[i] )].mtn.trs_tbl[0].trs_y = 420f;
                            break;
                        case 25:
                            a2S_AMA_HEADER.act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[i] )].mtn.trs_tbl[0].trs_y = 530f;
                            break;
                    }
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
                main_work.act[i] = AppMain.AoActCreate( a2S_AMA_HEADER, AppMain.dm_title_g_dm_act_id_tbl[i] );
            }
            int[] array = new int[]
            {
                1,
                4,
                7,
                10,
                13
            };
            int j = 0;
            int num3 = array.Length;
            while ( j < num3 )
            {
                CTrgAoAction ctrgAoAction = main_work.trg_slct[j];
                ctrgAoAction.Create( main_work.act[array[j]] );
                j++;
            }
            int[] array2 = new int[]
            {
                33,
                36
            };
            int k = 0;
            int num4 = array2.Length;
            while ( k < num4 )
            {
                CTrgAoAction ctrgAoAction2 = main_work.trg_answer[k];
                ctrgAoAction2.Create( main_work.act[array2[k]] );
                k++;
            }
            int num5 = 16;
            CTrgAoAction trg_return = main_work.trg_return;
            trg_return.Create( main_work.act[num5] );
            int num6 = 18;
            CTrgAoAction trg_game = main_work.trg_game;
            trg_game.Create( main_work.act[num6] );
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcCheckLoadingEnd );
            this.DmTitleOpInit();
            AppMain.AoActSysSetDrawState( 10U );
            AppMain.AoActSysSetDrawStateEnable( true );
        }
    }

    // Token: 0x06000C67 RID: 3175 RVA: 0x0006CDE4 File Offset: 0x0006AFE4
    private void dmTitleProcCheckLoadingEnd( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.dm_title_is_title_start )
        {
            main_work.disp_change_time = 40;
            main_work.flag |= 8U;
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeIn );
            main_work.proc_draw = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleDrawSetProcDispData );
            main_work.flag |= 512U;
            this.DmTitleOpDispRightEnable( true );
            for ( int i = 0; i < 2; i++ )
            {
                main_work.mmenu_win_size_rate[i] = 0f;
            }
            AppMain.IzFadeInitEasy( 1U, 0U, 32f );
            XBOXLive.allowShowUpdate = true;
            return;
        }
        main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeIn );
        this.dmTitleSetMenuInfo( main_work );
        this.DmTitleOpSetRetOptionState();
        main_work.proc_draw = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleDrawSetProcDispData );
        main_work.flag |= 1024U;
        main_work.flag |= 2097152U;
        this.DmTitleOpDispRightEnable( false );
        for ( int j = 0; j < 2; j++ )
        {
            main_work.mmenu_win_size_rate[j] = 1f;
        }
    }

    // Token: 0x06000C68 RID: 3176 RVA: 0x0006CEEC File Offset: 0x0006B0EC
    private void dmTitleProcFadeIn( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            if ( AppMain.dm_title_is_title_start )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWaitInput );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcTitle );
                AppMain.DmSndBgmPlayerPlayBgm( 1 );
            }
            else
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuIdle );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcMainMenu );
                main_work.flag |= 2147483648U;
                AppMain.DmSndBgmPlayerPlayBgm( 0 );
            }
            main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowNodispIdle );
        }
    }

    // Token: 0x06000C69 RID: 3177 RVA: 0x0006CF8C File Offset: 0x0006B18C
    private void dmTitleProcWaitInput( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        main_work.timer += 1f;
        if ( main_work.timer > 3600f )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeOut );
            main_work.proc_input = null;
            main_work.timer = 0f;
            main_work.flag |= 1048576U;
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            AppMain.DmSndBgmPlayerExit();
            main_work.flag |= 524288U;
            return;
        }
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( ( main_work.flag & 32U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcDecideEfct );
            main_work.proc_input = null;
            main_work.timer = 0f;
            main_work.flag &= 4294967263U;
            AppMain.DmSoundPlaySE( "Ok" );
            AppMain.DmSndBgmPlayerBgmStop();
        }
    }

    // Token: 0x06000C6A RID: 3178 RVA: 0x0006D074 File Offset: 0x0006B274
    private void dmTitleProcDecideEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( main_work.timer >= 60f && AppMain.AoAccountSetCurrentIdIsFinished() )
        {
            if ( AppMain.AoAccountGetCurrentId() >= 0 )
            {
                main_work.flag &= 4294966783U;
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcCheckTrialIdle );
                AppMain.GsRebootSetTitle();
            }
            else
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWaitInput );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcTitle );
                AppMain.DmSndBgmPlayerPlayBgm( 1 );
            }
            main_work.timer = 0f;
            return;
        }
        main_work.timer += 1f;
    }

    // Token: 0x06000C6B RID: 3179 RVA: 0x0006D110 File Offset: 0x0006B310
    private void dmTitleProcCheckTrialIdle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.GsTrialCheckIsFinished() )
        {
            if ( AppMain.GsTrialIsTrial() )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuOpenWin );
                main_work.proc_input = null;
                main_work.flag |= 2147483648U;
                main_work.flag |= 4096U;
                main_work.flag |= 2097152U;
                main_work.is_init_play = false;
                main_work.slct_menu_num = 3;
                main_work.cur_slct_menu = 0;
                main_work.cur_crsr_pos_y = AppMain.dm_title_crsr_trial_pos_y_tbl[main_work.cur_slct_menu];
                AppMain.DmSndBgmPlayerPlayBgm( 0 );
                return;
            }
            AppMain.DmSaveStart( 1U, false, false );
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFileSlctWaitDataLoad );
            AppMain.DmSndBgmPlayerPlayBgm( 0 );
        }
    }

    // Token: 0x06000C6C RID: 3180 RVA: 0x0006D1CC File Offset: 0x0006B3CC
    private void dmTitleProcFileSlctWaitDataLoad( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            if ( AppMain.DmCmnBackupIsLoadSuccessed() )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuOpenWin );
                main_work.proc_input = null;
                main_work.flag |= 2147483648U;
                main_work.flag |= 4096U;
                main_work.flag |= 2097152U;
                if ( AppMain.GsMainSysIsStageClear( 0 ) )
                {
                    main_work.is_init_play = false;
                    main_work.slct_menu_num = 3;
                    main_work.cur_slct_menu = 1;
                }
                else
                {
                    main_work.is_init_play = true;
                    main_work.slct_menu_num = 3;
                    main_work.cur_slct_menu = 0;
                }
                main_work.flag |= 2097152U;
                if ( AppMain.GsTrialIsTrial() )
                {
                    main_work.cur_crsr_pos_y = AppMain.dm_title_crsr_trial_pos_y_tbl[main_work.cur_slct_menu];
                }
                else
                {
                    main_work.cur_crsr_pos_y = ( float )main_work.cur_slct_menu * AppMain.dm_title_crsr_pos_y_tbl[1] + AppMain.dm_title_crsr_pos_y_tbl[0];
                }
                this.dmTitleSetLoadSysData( main_work );
                return;
            }
            int num = AppMain.AoStorageGetError();
            main_work.is_init_play = true;
            main_work.slct_menu_num = 3;
            if ( num == 1 )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFileSlctSaveStartWait );
                return;
            }
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuOpenWin );
            main_work.proc_input = null;
            main_work.flag |= 2147483648U;
            main_work.flag |= 4096U;
            main_work.flag |= 2097152U;
            this.dmTitleSetInitSaveData( main_work );
            this.dmTitleSetInitSysData( main_work );
        }
    }

    // Token: 0x06000C6D RID: 3181 RVA: 0x0006D34C File Offset: 0x0006B54C
    private void dmTitleProcFileSlctSaveStartWait( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            AppMain.DmSaveStart( 4U, true, false );
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFileSlctWaitDataSave );
        }
    }

    // Token: 0x06000C6E RID: 3182 RVA: 0x0006D370 File Offset: 0x0006B570
    private void dmTitleProcFileSlctWaitDataSave( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            if ( !AppMain.DmCmnBackupIsSaveSuccessed() )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWaitInput );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcTitle );
                main_work.flag |= 512U;
                main_work.flag &= 4294966271U;
                main_work.flag &= 2147483647U;
                main_work.timer = 0f;
                AppMain.DmSndBgmPlayerPlayBgm( 1 );
                return;
            }
            SBackup sbackup = SBackup.CreateInstance();
            sbackup.Init();
            main_work.is_init_play = true;
            this.dmTitleSetInitSysData( main_work );
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuOpenWin );
            main_work.proc_input = null;
            main_work.flag |= 2147483648U;
            main_work.flag |= 2097152U;
        }
    }

    // Token: 0x06000C6F RID: 3183 RVA: 0x0006D454 File Offset: 0x0006B654
    private void dmTitleProcMainMenuOpenWin( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 4194304U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuIdle );
            main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcMainMenu );
            main_work.mmenu_win_timer = 0f;
            main_work.flag |= 1024U;
            main_work.flag &= 4294966783U;
            main_work.flag &= 4290772991U;
            this.DmTitleOpDispRightEnable( false );
            if ( AppMain.GsTrialIsTrial() || main_work.is_init_play )
            {
                main_work.cur_slct_menu = 0;
            }
            else
            {
                main_work.cur_slct_menu = 1;
            }
            if ( AppMain.GsTrialIsTrial() )
            {
                main_work.cur_crsr_pos_y = AppMain.dm_title_crsr_trial_pos_y_tbl[main_work.cur_slct_menu];
            }
            else
            {
                main_work.cur_crsr_pos_y = ( float )main_work.cur_slct_menu * AppMain.dm_title_crsr_pos_y_tbl[1] + AppMain.dm_title_crsr_pos_y_tbl[0];
            }
            SaveState.showResumeWarning();
            return;
        }
        this.dmTitleSetMMenuWinOpenEfct( main_work );
    }

    // Token: 0x06000C70 RID: 3184 RVA: 0x0006D544 File Offset: 0x0006B744
    private void dmTitleProcMainMenuCloseWin( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 4194304U ) != 0U )
        {
            AppMain.AoAccountClearCurrentId();
            SBackup sbackup = SBackup.CreateInstance();
            sbackup.Init();
            main_work.flag &= 2147483647U;
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWaitInput );
            main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcTitle );
            main_work.flag |= 512U;
            main_work.flag &= 4294966271U;
            main_work.flag &= 4292870143U;
            this.DmTitleOpDispRightEnable( true );
            AppMain.DmSndBgmPlayerPlayBgm( 1 );
            main_work.mmenu_win_timer = 0f;
            main_work.flag &= 4292870143U;
            main_work.flag &= 4290772991U;
            return;
        }
        this.dmTitleSetMMenuWinCloseEfct( main_work );
    }

    // Token: 0x06000C71 RID: 3185 RVA: 0x0006D624 File Offset: 0x0006B824
    private void dmTitleProcMainMenuIdle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        if ( SaveState.shouldResume() )
        {
            main_work.cur_slct_menu = 0;
            main_work.flag |= 4U;
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuCloseWin );
            main_work.proc_input = null;
            main_work.mmenu_win_timer = 8f;
            main_work.flag &= 4294966271U;
            main_work.flag &= 4294967293U;
            main_work.flag &= 4294967291U;
            AppMain.DmSoundPlaySE( "Cancel" );
            return;
        }
        if ( ( main_work.flag & 4U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuDecideEfct );
            main_work.proc_input = null;
            main_work.timer = 0f;
            main_work.flag &= 4294967293U;
            main_work.flag &= 4294967291U;
            AppMain.DmSoundPlaySE( "Ok" );
            return;
        }
        if ( ( main_work.flag & 2048U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuCompBuyIdle );
            main_work.proc_input = null;
            main_work.timer = 0f;
            main_work.flag |= 262144U;
            Upsell.launchUpsellScreen( main_work.buy_scr_work );
            main_work.flag &= 4294965247U;
            return;
        }
        if ( ( main_work.flag & 64U ) != 0U || ( main_work.flag & 128U ) != 0U )
        {
            this.dmTitleSetChngFocusCrsrData( main_work );
            AppMain.DmSoundPlaySE( "Cursol" );
            main_work.flag &= 4294967231U;
            main_work.flag &= 4294967167U;
        }
        if ( ( main_work.flag & 256U ) != 0U )
        {
            this.dmTitleSetCtrlFocusChangeEfct( main_work );
            if ( this.dmTitleIsCtrlFocusChangeEfctEnd( main_work ) )
            {
                main_work.flag &= 4294967039U;
            }
        }
    }

    // Token: 0x06000C72 RID: 3186 RVA: 0x0006D800 File Offset: 0x0006BA00
    private void dmTitleProcMainMenuCompBuyFadeOut( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuCompBuyIdle );
            Upsell.launchUpsellScreen( main_work.buy_scr_work );
            main_work.flag &= 2147483647U;
            main_work.disp_flag &= 4294967293U;
        }
        if ( ( main_work.flag & 256U ) != 0U )
        {
            this.dmTitleSetCtrlFocusChangeEfct( main_work );
            if ( this.dmTitleIsCtrlFocusChangeEfctEnd( main_work ) )
            {
                main_work.flag &= 4294967039U;
            }
        }
    }

    // Token: 0x06000C73 RID: 3187 RVA: 0x0006D884 File Offset: 0x0006BA84
    private void dmTitleProcMainMenuCompBuyIdle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( !Upsell.showUpsell )
        {
            if ( AppMain.DmBuyScreenGetResult( main_work.buy_scr_work ) == 0 )
            {
                if ( !AppMain.GsTrialIsTrial() )
                {
                    main_work.is_init_play = true;
                    main_work.is_no_save_data = true;
                    AppMain.event_after_buy = true;
                }
                if ( ( main_work.flag & 262144U ) != 0U )
                {
                    main_work.flag &= 4294705151U;
                }
                else
                {
                    AppMain.IzFadeInitEasy( 1U, 0U, 32f );
                }
                AppMain.DmSndBgmPlayerPlayBgm( 0 );
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuCompBuyFadeIn );
                main_work.disp_flag |= 2U;
                return;
            }
            if ( ( main_work.flag & 262144U ) != 0U )
            {
                main_work.flag &= 4294705151U;
            }
            else
            {
                AppMain.IzFadeInitEasy( 1U, 0U, 32f );
            }
            AppMain.DmSndBgmPlayerPlayBgm( 0 );
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuCompBuyFadeIn );
            main_work.disp_flag |= 2U;
        }
    }

    // Token: 0x06000C74 RID: 3188 RVA: 0x0006D96C File Offset: 0x0006BB6C
    public static void dmTitleProcMainMenuComUpsellScreenFinished()
    {
        AppMain.IzFadeInitEasy( 1U, 0U, 32f );
        AppMain.DmSndBgmPlayerPlayBgm( 0 );
    }

    // Token: 0x06000C75 RID: 3189 RVA: 0x0006D980 File Offset: 0x0006BB80
    private void dmTitleProcMainMenuCompBuyFadeIn( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            if ( AppMain.DmBuyScreenGetResult( main_work.buy_scr_work ) == 0 )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuIdle );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcMainMenu );
                main_work.flag |= 2147483648U;
                if ( !AppMain.GsTrialIsTrial() )
                {
                    main_work.is_init_play = true;
                    main_work.is_no_save_data = true;
                    AppMain.event_after_buy = true;
                }
            }
            else
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuIdle );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcMainMenu );
                main_work.flag |= 2147483648U;
            }
            for ( int i = 0; i < 5; i++ )
            {
                main_work.decide_menu_frm[i] = 0f;
            }
        }
    }

    // Token: 0x06000C76 RID: 3190 RVA: 0x0006DA46 File Offset: 0x0006BC46
    private void dmTitleProcMainMenuTrophyIdle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
    }

    // Token: 0x06000C77 RID: 3191 RVA: 0x0006DA48 File Offset: 0x0006BC48
    private void dmTitleProcMainMenuDecideEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 256U ) != 0U )
        {
            this.dmTitleSetCtrlFocusChangeEfct( main_work );
            if ( this.dmTitleIsCtrlFocusChangeEfctEnd( main_work ) )
            {
                main_work.flag &= 4294967039U;
            }
        }
        int cur_slct_menu = main_work.cur_slct_menu;
        if ( main_work.timer <= 15f )
        {
            main_work.decide_menu_frm[cur_slct_menu] += 1f;
            main_work.timer += 1f;
            return;
        }
        if ( cur_slct_menu == 4 && ( AppMain.GsTrialIsTrial() || XBOXLive.signinStatus == XBOXLive.SigninStatus.UpdateNeeded || XBOXLive.signinStatus == XBOXLive.SigninStatus.Local ) )
        {
            for ( int i = 0; i < 5; i++ )
            {
                main_work.decide_menu_frm[i] = 0f;
            }
            main_work.flag &= 4294967291U;
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuIdle );
            main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcMainMenu );
            if ( !Guide.IsVisible )
            {
                if ( XBOXLive.signinStatus == XBOXLive.SigninStatus.UpdateNeeded )
                {
                    XBOXLive.displayTitleUpdateMessage = true;
                    return;
                }
                List<string> list = new List<string>();
                list.Add( Strings.ID_OK );
                string text;
                if ( AppMain.GsTrialIsTrial() )
                {
                    text = Strings.ID_LB_BUY;
                }
                else if ( XBOXLive.signinStatus == XBOXLive.SigninStatus.Local )
                {
                    text = Strings.ID_LB_OFFLINE;
                }
                else
                {
                    text = Strings.ID_LB_UPDATE;
                }
                AppMain.g_ao_sys_global.is_show_ui = true;
                Guide.BeginShowMessageBox( " ", text, list, 0, MessageBoxIcon.Alert, new AsyncCallback( AppMain.TitleMBResult ), null );
            }
            return;
        }
        if ( cur_slct_menu == 0 && SaveState.shouldResume() )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeOut );
        }
        else if ( cur_slct_menu == 0 && !main_work.is_init_play && !AppMain.GsTrialIsTrial() )
        {
            if ( this.dmTitleIsSaveRunning() )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuDelSaveWin );
                main_work.announce_flag |= 1U;
                main_work.flag &= 4292869119U;
                return;
            }
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeOut );
            return;
        }
        else
        {
            if ( AppMain.GsTrialIsTrial() && cur_slct_menu == 1 )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuCompBuyFadeOut );
                main_work.proc_input = null;
                main_work.timer = 0f;
                AppMain.IzFadeInitEasy( 0U, 1U, 32f );
                AppMain.DmSndBgmPlayerBgmStop();
                return;
            }
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeOut );
        }
        main_work.timer = 0f;
        for ( int j = 0; j < 5; j++ )
        {
            main_work.decide_menu_frm[j] = 0f;
        }
        AppMain.IzFadeInitEasy( 0U, 1U, 32f );
        if ( cur_slct_menu == 0 )
        {
            AppMain.DmSndBgmPlayerExit();
            main_work.flag |= 524288U;
        }
    }

    // Token: 0x06000C78 RID: 3192 RVA: 0x0006DCD8 File Offset: 0x0006BED8
    protected static void TitleMBResult( IAsyncResult userResult )
    {
        AppMain.g_ao_sys_global.is_show_ui = false;
    }

    // Token: 0x06000C79 RID: 3193 RVA: 0x0006DCE8 File Offset: 0x0006BEE8
    private void dmTitleProcMainMenuDelSaveWin( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 8192U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuIdle );
            main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcMainMenu );
            main_work.timer = 0f;
            main_work.flag &= 4294959103U;
            for ( int i = 0; i < 5; i++ )
            {
                main_work.decide_menu_frm[i] = 0f;
            }
            main_work.flag |= 2098176U;
        }
        else if ( ( main_work.flag & 16384U ) != 0U )
        {
            SOption soption = SOption.CreateInstance();
            SOption.EControl.Type control = soption.GetControl();
            this.dmTitleSetInitSaveData( main_work );
            soption.SetControl( control );
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcSaveInitData );
            AppMain.DmSaveMenuStart( false, false );
            main_work.flag &= 4294950911U;
        }
        if ( ( main_work.flag & 256U ) != 0U )
        {
            this.dmTitleSetCtrlFocusChangeEfct( main_work );
            if ( this.dmTitleIsCtrlFocusChangeEfctEnd( main_work ) )
            {
                main_work.flag &= 4294967039U;
            }
        }
    }

    // Token: 0x06000C7A RID: 3194 RVA: 0x0006DDF8 File Offset: 0x0006BFF8
    private void dmTitleProcSaveInitData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.DmSaveIsExit() )
        {
            if ( !AppMain.GsTrialIsTrial() && !AppMain.DmCmnBackupIsSaveSuccessed() )
            {
                main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWaitInput );
                main_work.proc_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcTitle );
                main_work.flag |= 512U;
                main_work.flag &= 4294966271U;
                main_work.flag &= 2147483647U;
                AppMain.DmSndBgmPlayerPlayBgm( 1 );
                return;
            }
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFadeOut );
            main_work.timer = 0f;
            AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            AppMain.DmSndBgmPlayerExit();
            main_work.flag |= 524288U;
        }
    }

    // Token: 0x06000C7B RID: 3195 RVA: 0x0006DEBE File Offset: 0x0006C0BE
    private void dmTitleProcFadeOut( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            this.DmTitleOpExit();
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcDataRelease );
            main_work.proc_draw = null;
        }
    }

    // Token: 0x06000C7C RID: 3196 RVA: 0x0006DEE8 File Offset: 0x0006C0E8
    private void dmTitleProcWindowNodispIdle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( main_work.proc_win_input != null )
        {
            main_work.proc_win_input( main_work );
        }
        if ( main_work.announce_flag != 0U )
        {
            main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowOpenEfct );
            main_work.proc_input = null;
            main_work.proc_win_input = null;
            main_work.win_timer = 0f;
            for ( int i = 0; i < 5; i++ )
            {
                if ( ( ( ulong )main_work.announce_flag & ( ulong )( 1L << ( i & 31 ) ) ) != 0UL )
                {
                    main_work.win_mode = i;
                    break;
                }
            }
            main_work.win_cur_slct = 1;
            AppMain.DmSoundPlaySE( "Window" );
            main_work.flag |= 131072U;
        }
    }

    // Token: 0x06000C7D RID: 3197 RVA: 0x0006DF88 File Offset: 0x0006C188
    private void dmTitleProcWindowOpenEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 65536U ) != 0U )
        {
            main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowAnnounceIdle );
            main_work.proc_win_input = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleInputProcWindow );
            main_work.disp_flag |= 1U;
            main_work.flag &= 4294901759U;
            return;
        }
        this.dmTitleSetWinOpenEfct( main_work );
    }

    // Token: 0x06000C7E RID: 3198 RVA: 0x0006DFF0 File Offset: 0x0006C1F0
    private void dmTitleProcWindowAnnounceIdle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( main_work.proc_win_input != null )
        {
            main_work.proc_win_input( main_work );
        }
        if ( main_work.win_mode == 0 )
        {
            if ( ( main_work.flag & 4U ) != 0U && main_work.win_cur_slct == 0 )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowCloseEfct );
                AppMain.DmSoundPlaySE( "Ok" );
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
                return;
            }
            if ( ( main_work.flag & 2U ) != 0U || ( main_work.win_cur_slct == 1 && ( main_work.flag & 4U ) != 0U ) )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowCloseEfct );
                AppMain.DmSoundPlaySE( "Cancel" );
                main_work.flag |= 2U;
                main_work.flag &= 4294967291U;
                return;
            }
        }
        else if ( main_work.win_mode == 1 )
        {
            if ( ( main_work.flag & 4U ) != 0U && main_work.win_cur_slct == 0 )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowCloseEfct );
                AppMain.DmSoundPlaySE( "Ok" );
                main_work.flag &= 4294967291U;
                main_work.flag &= 4294967293U;
                return;
            }
            if ( ( main_work.flag & 2U ) != 0U || ( main_work.win_cur_slct == 1 && ( main_work.flag & 4U ) != 0U ) )
            {
                main_work.proc_input = null;
                main_work.proc_win_input = null;
                main_work.win_timer = 8f;
                main_work.disp_flag &= 4294967294U;
                main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowCloseEfct );
                AppMain.DmSoundPlaySE( "Cancel" );
                main_work.flag |= 2U;
                main_work.flag &= 4294967291U;
            }
        }
    }

    // Token: 0x06000C7F RID: 3199 RVA: 0x0006E218 File Offset: 0x0006C418
    private void dmTitleProcWindowCloseEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 65536U ) != 0U )
        {
            main_work.proc_win_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWindowNodispIdle );
            main_work.announce_flag &= ~( 1U << main_work.win_mode );
            if ( main_work.win_mode == 0 || main_work.win_mode == 1 )
            {
                if ( ( main_work.flag & 2U ) != 0U )
                {
                    main_work.flag |= 8192U;
                    main_work.flag &= 4294967293U;
                }
                else if ( main_work.win_mode == 0 )
                {
                    main_work.announce_flag |= 2U;
                }
                else if ( main_work.win_mode == 1 )
                {
                    main_work.flag |= 16384U;
                }
            }
            else if ( ( main_work.flag & 2U ) != 0U )
            {
                main_work.flag |= 16777216U;
                main_work.flag &= 4294967293U;
            }
            else if ( main_work.win_mode == 2 )
            {
                main_work.flag |= 8388608U;
            }
            else if ( main_work.win_mode == 3 )
            {
                main_work.flag |= 33554432U;
            }
            else
            {
                main_work.flag |= 67108864U;
            }
            main_work.flag &= 4294836223U;
            main_work.flag &= 4294901759U;
        }
        this.dmTitleSetWinCloseEfct( main_work );
    }

    // Token: 0x06000C80 RID: 3200 RVA: 0x0006E384 File Offset: 0x0006C584
    private void dmTitleProcDataRelease( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( this.DmTitleOpExitEndCheck() )
        {
            for ( int i = 0; i < 2; i++ )
            {
                AppMain.AoTexRelease( main_work.tex[i] );
            }
            for ( int j = 0; j < 4; j++ )
            {
                AppMain.AoTexRelease( main_work.cmn_tex[j] );
            }
            this.DmTitleOpFlush();
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcFinish );
        }
    }

    // Token: 0x06000C81 RID: 3201 RVA: 0x0006E3E4 File Offset: 0x0006C5E4
    private void dmTitleProcFinish( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( this.dmTitleIsTexRelease( main_work ) )
        {
            int num = main_work.trg_slct.Length;
            for ( int i = 0; i < num; i++ )
            {
                main_work.trg_slct[i].Release();
            }
            int num2 = main_work.trg_answer.Length;
            for ( int j = 0; j < num2; j++ )
            {
                main_work.trg_answer[j].Release();
            }
            main_work.trg_return.Release();
            main_work.trg_game.Release();
            for ( int k = 0; k < 41; k++ )
            {
                if ( main_work.act[k] != null )
                {
                    AppMain.AoActDelete( main_work.act[k] );
                    main_work.act[k] = null;
                }
            }
            for ( int l = 0; l < 2; l++ )
            {
                if ( main_work.arc_amb[l] != null )
                {
                    main_work.arc_amb[l] = null;
                }
            }
            for ( int m = 0; m < 4; m++ )
            {
                if ( main_work.arc_cmn_amb[m] != null )
                {
                    main_work.arc_cmn_amb[m] = null;
                }
            }
            this.DmTitleOpRelease();
            main_work.proc_update = new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcWaitFinished );
        }
    }

    // Token: 0x06000C82 RID: 3202 RVA: 0x0006E4F0 File Offset: 0x0006C6F0
    private void dmTitleProcWaitFinished( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( this.DmTitleOpReleaseCheck() )
        {
            if ( ( main_work.flag & 524288U ) != 0U )
            {
                if ( !AppMain.DmSndBgmPlayerIsTaskExit() )
                {
                    return;
                }
                main_work.flag &= 4294443007U;
            }
            main_work.flag |= 1U;
            main_work.proc_update = null;
        }
    }

    // Token: 0x06000C83 RID: 3203 RVA: 0x0006E544 File Offset: 0x0006C744
    private void dmTitleInputProcTitle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.amTpIsTouchPush( 0 ) )
        {
            int num = 0;
            AppMain.AoAccountSetCurrentIdStart( ( uint )( ( ushort )num ) );
            main_work.flag |= 32U;
        }
        if ( AppMain.isBackKeyPressed() )
        {
            AppMain.finish();
            AppMain.setBackKeyRequest( false );
        }
    }

    // Token: 0x06000C84 RID: 3204 RVA: 0x0006E588 File Offset: 0x0006C788
    private void dmTitleInputProcMainMenu( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        int num = main_work.trg_slct.Length;
        if ( !LiveFeature.isInterrupted() )
        {
            for ( int i = 0; i < num; i++ )
            {
                CTrgAoAction ctrgAoAction = main_work.trg_slct[i];
                if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
                {
                    main_work.cur_slct_menu = i;
                    main_work.flag |= 4U;
                    break;
                }
            }
        }
        if ( ( 4U & main_work.flag ) == 0U )
        {
            CTrgAoAction trg_return = main_work.trg_return;
            if ( ( trg_return.GetState( 0U )[10] && trg_return.GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
            {
                AppMain.setBackKeyRequest( false );
                if ( LiveFeature.isInterrupted() )
                {
                    LiveFeature.endInterrupt();
                }
                else
                {
                    main_work.flag |= 2U;
                }
            }
            CTrgAoAction trg_game = main_work.trg_game;
            if ( trg_game.GetState( 0U )[10] && trg_game.GetState( 0U )[1] )
            {
                int num2 = AppMain.GsEnvGetLanguage();
                string url;
                if ( num2 == 0 )
                {
                    url = "http://sega.jp/kt/microsoft/smart/";
                }
                else
                {
                    url = "http://sega.com/apps";
                }
                AppMain.DmSoundPlaySE( "Ok" );
                erWeb.StartWeb( url );
            }
        }
    }

    // Token: 0x06000C85 RID: 3205 RVA: 0x0006E6A4 File Offset: 0x0006C8A4
    private void dmTitleInputProcWindow( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        CTrgAoAction[] trg_answer = main_work.trg_answer;
        if ( ( trg_answer[0].GetState( 0U )[10] && trg_answer[0].GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            main_work.win_cur_slct = 1;
            main_work.flag |= 4U;
        }
        if ( trg_answer[1].GetState( 0U )[10] && trg_answer[1].GetState( 0U )[1] )
        {
            main_work.win_cur_slct = 0;
            main_work.flag |= 4U;
        }
    }

    // Token: 0x06000C86 RID: 3206 RVA: 0x0006E738 File Offset: 0x0006C938
    private void dmTitleDrawSetProcDispData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        float num = 0f;
        if ( ( main_work.disp_flag & 2U ) != 0U )
        {
            AppMain.AoActSysSetDrawTaskPrio( 32768U );
            this.DmTitleOpDraw2D();
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
            AppMain.AoActSortUnregAll();
            if ( ( main_work.flag & 512U ) != 0U && this.DmTitleOpIsLogoActFinish() )
            {
                this.dmTitleDrawProcTitle( main_work );
            }
            if ( ( main_work.flag & 2097152U ) != 0U )
            {
                AppMain.AoActSysSetDrawTaskPrio( 35840U );
                if ( ( double )main_work.mmenu_win_size_rate[0] >= 0.9 || AppMain.AoAccountIsCurrentEnable() )
                {
                    int[] array = new int[]
                    {
                        800,
                        540
                    };
                    bool flag = AppMain.GsTrialIsTrial();
                    bool flag2 = !main_work.is_init_play;
                    AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( main_work.cmn_tex[2] ), 0U, 480f, 311.9f, ( float )array[0] * main_work.mmenu_win_size_rate[0], ( float )array[1] * main_work.mmenu_win_size_rate[1] * 0.9f + num, 10U );
                }
            }
            if ( ( main_work.flag & 1024U ) != 0U )
            {
                if ( ( main_work.flag_prev & 1024U ) == 0U )
                {
                    main_work.trg_return.ResetState();
                    int i = 15;
                    int num2 = 17;
                    while ( i < num2 )
                    {
                        AppMain.AoActSetFrame( main_work.act[i], 0f );
                        i++;
                    }
                    main_work.trg_game.ResetState();
                    int j = 17;
                    int num3 = 19;
                    while ( j < num3 )
                    {
                        AppMain.AoActSetFrame( main_work.act[j], 0f );
                        j++;
                    }
                }
                this.dmTitleDrawProcMainMenu( main_work );
            }
            if ( ( main_work.flag & 131072U ) != 0U )
            {
                this.dmTitleWinSelectDraw( main_work );
            }
        }
        AppMain.amDrawMakeTask( new AppMain.TaskProc( this.dmTitleTaskDraw ), 32768, 0U );
    }

    // Token: 0x06000C87 RID: 3207 RVA: 0x0006E8F0 File Offset: 0x0006CAF0
    private void dmTitleDrawProcTitle( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 33792U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        if ( ( main_work.flag & 8U ) != 0U )
        {
            AppMain.AoActSortRegAction( main_work.act[19] );
        }
        if ( ( main_work.flag & 16U ) != 0U )
        {
            if ( main_work.disp_timer >= 4f )
            {
                main_work.disp_timer = 0f;
                main_work.flag ^= 8U;
            }
            else
            {
                main_work.disp_timer += 1f;
            }
        }
        else if ( main_work.disp_timer >= ( float )main_work.disp_change_time )
        {
            main_work.flag ^= 8U;
            if ( ( main_work.flag & 8U ) != 0U )
            {
                main_work.disp_change_time = 40;
            }
            else
            {
                main_work.disp_change_time = 30;
            }
            main_work.disp_timer = 0f;
        }
        else
        {
            main_work.disp_timer += 1f;
        }
        if ( AppMain.GeEnvGetDecideKey() == AppMain.GSE_DECIDE_KEY.GSD_DECIDE_KEY_O )
        {
            AppMain.AoActSetFrame( main_work.act[19], 0f );
        }
        else
        {
            AppMain.AoActSetFrame( main_work.act[19], 1f );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActUpdate( main_work.act[19], 0f );
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06000C88 RID: 3208 RVA: 0x0006EA34 File Offset: 0x0006CC34
    private void dmTitleDrawProcMainMenu( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        bool is_trial = AppMain.GsTrialIsTrial();
        bool has_save_data = !main_work.is_init_play;
        this.dmTitleDrawProcMainMenuIphone( main_work, has_save_data, is_trial );
    }

    // Token: 0x06000C89 RID: 3209 RVA: 0x0006EA5A File Offset: 0x0006CC5A
    private void CLocalBtnBase_Update( AppMain.AOS_ACTION src, AppMain.ArrayPointer<AppMain.AOS_ACTION> btn, CTrgAoAction trg )
    {
        this.CLocalBtnBase_Update( src, btn, trg, 0f );
    }

    // Token: 0x06000C8A RID: 3210 RVA: 0x0006EA6C File Offset: 0x0006CC6C
    private void CLocalBtnBase_Update( AppMain.AOS_ACTION src, AppMain.ArrayPointer<AppMain.AOS_ACTION> btn, CTrgAoAction trg, float frame )
    {
        AppMain.AoActAcmPush();
        AppMain.AoActAcmInit();
        int[] array = new int[]
        {
            (int)src.sprite.center_x,
            (int)src.sprite.center_y
        };
        AppMain.AoActAcmApplyTrans( ( float )array[0], ( float )array[1], 1f );
        AppMain.AoActUpdate( btn[0], frame );
        AppMain.AoActUpdate( btn[1], frame );
        AppMain.AoActUpdate( btn[2], frame );
        trg.Update();
        AppMain.AoActAcmPop();
    }

    // Token: 0x06000C8B RID: 3211 RVA: 0x0006EAF4 File Offset: 0x0006CCF4
    private void CLocalBtnBase_Draw( AppMain.ArrayPointer<AppMain.AOS_ACTION> btn )
    {
        AppMain.AoActSortRegAction( btn[0] );
        AppMain.AoActSortRegAction( btn[1] );
        AppMain.AoActSortRegAction( btn[2] );
    }

    // Token: 0x06000C8C RID: 3212 RVA: 0x0006EB1D File Offset: 0x0006CD1D
    private void CLocalBtnBase_SetFrame( AppMain.ArrayPointer<AppMain.AOS_ACTION> btn, float frame )
    {
        AppMain.AoActSetFrame( btn[0], frame );
        AppMain.AoActSetFrame( btn[1], frame );
        AppMain.AoActSetFrame( btn[2], frame );
    }

    // Token: 0x06000C8D RID: 3213 RVA: 0x0006EB7C File Offset: 0x0006CD7C
    private void dmTitleDrawProcMainMenuIphone( AppMain.DMS_TITLE_MAIN_WORK main_work, bool has_save_data, bool is_trial )
    {
        AppMain.AoActSysSetDrawTaskPrio( 33792U );
        int[] array = new int[]
        {
            20,
            21,
            22,
            24,
            25
        };
        bool flag = has_save_data;
        int[] array2 = new int[]
        {
            0,
            3,
            6,
            9,
            12
        };
        float[] array3 = new float[5];
        float[] array4 = array3;
        if ( is_trial )
        {
            array[1] = 23;
            flag = true;
        }
        if ( new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcMainMenuDecideEfct ) == main_work.proc_update )
        {
            array4[main_work.cur_slct_menu] = 1f;
        }
        else if ( ( !AppMain.IzFadeIsExe() || AppMain.IzFadeIsEnd() ) && !( new AppMain.DMS_TITLE_MAIN_WORK._proc_( this.dmTitleProcSaveInitData ) == main_work.proc_update ) && ( 131072U & main_work.flag ) == 0U )
        {
            float frame;
            for ( int i = 0; i < 5; i++ )
            {
                if ( main_work.trg_slct[i].GetState( 0U )[10] && main_work.trg_slct[i].GetState( 0U )[1] )
                {
                    frame = 2f;
                }
                else if ( main_work.trg_slct[i].GetState( 0U )[0] )
                {
                    frame = 1f;
                }
                else
                {
                    frame = 0f;
                }
                AppMain.AoActSetFrame( main_work.act[array[i]], frame );
                this.CLocalBtnBase_SetFrame( new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[i] ), frame );
            }
            if ( main_work.trg_return.GetState( 0U )[10] && main_work.trg_return.GetState( 0U )[1] )
            {
                frame = 2f;
            }
            else if ( main_work.trg_return.GetState( 0U )[0] )
            {
                frame = 1f;
            }
            else if ( 2f <= main_work.act[15].frame )
            {
                frame = main_work.act[15].frame;
            }
            else
            {
                frame = 0f;
            }
            AppMain.AoActSetFrame( main_work.act[26], frame );
            int j = 15;
            int num = 17;
            while ( j < num )
            {
                AppMain.AoActSetFrame( main_work.act[j], frame );
                j++;
            }
            if ( main_work.trg_game.GetState( 0U )[10] && main_work.trg_game.GetState( 0U )[1] )
            {
                frame = 2f;
            }
            else if ( main_work.trg_game.GetState( 0U )[0] )
            {
                frame = 1f;
            }
            else if ( 2f <= main_work.act[17].frame )
            {
                frame = main_work.act[17].frame;
            }
            else
            {
                frame = 0f;
            }
            AppMain.AoActSetFrame( main_work.act[27], frame );
            int k = 17;
            int num2 = 19;
            while ( k < num2 )
            {
                AppMain.AoActSetFrame( main_work.act[k], frame );
                k++;
            }
        }
        if ( !LiveFeature.isInterrupted() )
        {
            if ( !flag )
            {
                main_work.ama[1].act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[20] )].mtn.trs_tbl[0].trs_y = 140f;
                main_work.ama[1].act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[22] )].mtn.trs_tbl[0].trs_y = 250f;
                main_work.ama[1].act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[24] )].mtn.trs_tbl[0].trs_y = 360f;
                main_work.ama[1].act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[25] )].mtn.trs_tbl[0].trs_y = 470f;
            }
            else
            {
                main_work.ama[1].act_tbl[( int )( ( UIntPtr )AppMain.dm_title_g_dm_act_id_tbl[21] )].mtn.trs_tbl[0].trs_y = 200f;
            }
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
            AppMain.AoActUpdate( main_work.act[array[0]], array4[0] );
            if ( flag )
            {
                AppMain.AoActUpdate( main_work.act[array[1]], array4[1] );
                main_work.act[array[1]].sprite.center_y = 200f;
            }
            AppMain.AoActUpdate( main_work.act[array[2]], array4[2] );
            AppMain.AoActUpdate( main_work.act[array[3]], array4[3] );
            AppMain.AoActUpdate( main_work.act[array[4]], array4[4] );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
            this.CLocalBtnBase_Update( main_work.act[array[0]], new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[0] ), main_work.trg_slct[0], array4[0] );
            if ( flag )
            {
                this.CLocalBtnBase_Update( main_work.act[array[1]], new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[1] ), main_work.trg_slct[1], array4[1] );
            }
            this.CLocalBtnBase_Update( main_work.act[array[2]], new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[2] ), main_work.trg_slct[2], array4[2] );
            this.CLocalBtnBase_Update( main_work.act[array[3]], new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[3] ), main_work.trg_slct[3], array4[3] );
            this.CLocalBtnBase_Update( main_work.act[array[4]], new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[4] ), main_work.trg_slct[4], array4[4] );
        }
        float frame2 = (2f <= main_work.act[15].frame) ? 1f : 0f;
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActUpdate( main_work.act[26], frame2 );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        int l = 15;
        int num3 = 17;
        while ( l < num3 )
        {
            AppMain.AoActUpdate( main_work.act[l], frame2 );
            l++;
        }
        main_work.trg_return.Update();
        float frame3 = (2f <= main_work.act[17].frame) ? 1f : 0f;
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
        AppMain.AoActUpdate( main_work.act[27], frame3 );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[0] ) );
        int m = 17;
        int num4 = 19;
        while ( m < num4 )
        {
            AppMain.AoActUpdate( main_work.act[m], frame3 );
            m++;
        }
        main_work.trg_game.Update();
        if ( !LiveFeature.isInterrupted() )
        {
            this.CLocalBtnBase_Draw( new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[0] ) );
            AppMain.AoActSortRegAction( main_work.act[array[0]] );
            main_work.act[array[0]].sprite.center_y -= 3f;
            if ( flag )
            {
                this.CLocalBtnBase_Draw( new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[1] ) );
                AppMain.AoActSortRegAction( main_work.act[array[1]] );
                main_work.act[array[1]].sprite.center_y -= 3f;
            }
            this.CLocalBtnBase_Draw( new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[2] ) );
            AppMain.AoActSortRegAction( main_work.act[array[2]] );
            main_work.act[array[2]].sprite.center_y -= 3f;
            this.CLocalBtnBase_Draw( new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[3] ) );
            AppMain.AoActSortRegAction( main_work.act[array[3]] );
            main_work.act[array[3]].sprite.center_y -= 3f;
            this.CLocalBtnBase_Draw( new AppMain.ArrayPointer<AppMain.AOS_ACTION>( main_work.act, array2[4] ) );
            AppMain.AoActSortRegAction( main_work.act[array[4]] );
            main_work.act[array[4]].sprite.center_y -= 3f;
        }
        if ( ( 2097152U & main_work.flag ) != 0U && ( 131072U & main_work.flag ) == 0U )
        {
            int n = 15;
            int num5 = 17;
            while ( n < num5 )
            {
                AppMain.AoActSortRegAction( main_work.act[n] );
                n++;
            }
            AppMain.AoActSortRegAction( main_work.act[26] );
            int num6 = 17;
            int num7 = 19;
            while ( num6 < num7 )
            {
                AppMain.AoActSortRegAction( main_work.act[num6] );
                num6++;
            }
            AppMain.AoActSortRegAction( main_work.act[27] );
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x06000C8E RID: 3214 RVA: 0x0006F3B0 File Offset: 0x0006D5B0
    private void dmTitleWinSelectDraw( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 35840U );
        AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( main_work.cmn_tex[2] ), 0U, 480f, 356f, 708.75f * main_work.win_size_rate[0], 303.75f * main_work.win_size_rate[1] * 0.9f, 10U );
        if ( ( main_work.disp_flag & 1U ) != 0U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[2] ) );
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
            switch ( main_work.win_mode )
            {
                case 0:
                    {
                        int i = 32;
                        int num = 38;
                        while ( i < num )
                        {
                            AppMain.AoActSortRegAction( main_work.act[i] );
                            i++;
                        }
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                        AppMain.AoActSortRegAction( main_work.act[28] );
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
                        AppMain.AoActSortRegAction( main_work.act[38] );
                        AppMain.AoActSortRegAction( main_work.act[39] );
                        break;
                    }
                case 1:
                    {
                        int j = 32;
                        int num2 = 38;
                        while ( j < num2 )
                        {
                            AppMain.AoActSortRegAction( main_work.act[j] );
                            j++;
                        }
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                        AppMain.AoActSortRegAction( main_work.act[29] );
                        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
                        AppMain.AoActSortRegAction( main_work.act[38] );
                        AppMain.AoActSortRegAction( main_work.act[39] );
                        break;
                    }
            }
            AppMain.AoActAcmPush();
            for ( int k = 0; k < 3; k++ )
            {
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( AppMain.dm_title_win_act_pos_tbl[k + 1, 0], AppMain.dm_title_win_act_pos_tbl[k + 1, 1], 0f );
                if ( k <= 1 )
                {
                    AppMain.AoActAcmApplyScale( 1.6875f, 1.6875f );
                }
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.tex[1] ) );
                AppMain.AoActUpdate( main_work.act[28 + k], 0f );
            }
            for ( int l = 1; l < 3; l++ )
            {
                int num3 = 37;
                AppMain.AoActAcmInit();
                AppMain.AoActAcmApplyTrans( AppMain.dm_title_win_act_pos_tbl[l + 4, 0], AppMain.dm_title_win_act_pos_tbl[l + 4, 1], 0f );
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[3] ) );
                AppMain.AoActUpdate( main_work.act[num3 + l], 0f );
                main_work.act[num3 + l].sprite.center_y += 5f;
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( main_work.cmn_tex[2] ) );
                int[,] array = new int[,]
                {
                    {
                        0,
                        -1
                    },
                    {
                        35,
                        37
                    },
                    {
                        32,
                        34
                    }
                };
                AppMain.AoActUpdate( main_work.act[array[l, 0] + 1], 0f );
                int[] array2 = new int[3];
                array2[0] = -1;
                array2[1] = 1;
                int[] array3 = array2;
                CTrgAoAction ctrgAoAction = main_work.trg_answer[array3[l]];
                if ( 0 <= array3[l] )
                {
                    ctrgAoAction.Update();
                }
                float frame = ctrgAoAction.GetState(0U)[0] ? 1f : 0f;
                int m = array[l, 0];
                int num4 = array[l, 1] + 1;
                while ( m < num4 )
                {
                    AppMain.AoActSetFrame( main_work.act[m], frame );
                    AppMain.AoActUpdate( main_work.act[m], 0f );
                    m++;
                }
            }
            AppMain.AoActAcmPop();
            AppMain.AoActSortExecute();
            AppMain.AoActSortDraw();
            AppMain.AoActSortUnregAll();
        }
    }

    // Token: 0x06000C8F RID: 3215 RVA: 0x0006F730 File Offset: 0x0006D930
    private void dmTitleTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( 10U );
        AppMain.amDrawEndScene();
    }

    // Token: 0x06000C90 RID: 3216 RVA: 0x0006F744 File Offset: 0x0006D944
    private bool dmTitleIsDataLoad( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_amb_fs[i] ) )
            {
                return false;
            }
        }
        for ( int j = 0; j < 4; j++ )
        {
            if ( !AppMain.amFsIsComplete( main_work.arc_cmn_amb_fs[j] ) )
            {
                return false;
            }
        }
        return this.DmTitleOpLoadCheck();
    }

    // Token: 0x06000C91 RID: 3217 RVA: 0x0006F798 File Offset: 0x0006D998
    private bool dmTitleIsTexLoad( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.tex[i] ) )
            {
                return false;
            }
        }
        for ( int j = 0; j < 4; j++ )
        {
            if ( !AppMain.AoTexIsLoaded( main_work.cmn_tex[j] ) )
            {
                return false;
            }
        }
        return AppMain.GsFontIsBuilded() && this.DmTitleOpBuildCheck();
    }

    // Token: 0x06000C92 RID: 3218 RVA: 0x0006F7F4 File Offset: 0x0006D9F4
    private bool dmTitleIsTexRelease( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.tex[i] ) )
            {
                return false;
            }
        }
        for ( int j = 0; j < 4; j++ )
        {
            if ( !AppMain.AoTexIsReleased( main_work.cmn_tex[j] ) )
            {
                return false;
            }
        }
        return this.DmTitleOpFlushCheck();
    }

    // Token: 0x06000C93 RID: 3219 RVA: 0x0006F848 File Offset: 0x0006DA48
    private void dmTitleSetChngFocusCrsrData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( ( main_work.flag & 64U ) != 0U )
        {
            main_work.prev_slct_menu = main_work.cur_slct_menu;
            main_work.cur_slct_menu = this.dmTitleGetRevisedMenuFocus( main_work.cur_slct_menu, -1, main_work.slct_menu_num );
            main_work.src_crsr_pos_y = main_work.cur_crsr_pos_y;
            if ( AppMain.GsTrialIsTrial() )
            {
                main_work.dst_crsr_pos_y = AppMain.dm_title_crsr_trial_pos_y_tbl[main_work.cur_slct_menu];
            }
            else
            {
                main_work.dst_crsr_pos_y = AppMain.dm_title_crsr_pos_y_tbl[0] + ( float )main_work.cur_slct_menu * AppMain.dm_title_crsr_pos_y_tbl[1];
            }
            main_work.flag |= 256U;
        }
        if ( ( main_work.flag & 128U ) != 0U )
        {
            main_work.prev_slct_menu = main_work.cur_slct_menu;
            main_work.cur_slct_menu = this.dmTitleGetRevisedMenuFocus( main_work.cur_slct_menu, 1, main_work.slct_menu_num );
            main_work.src_crsr_pos_y = main_work.cur_crsr_pos_y;
            if ( AppMain.GsTrialIsTrial() )
            {
                main_work.dst_crsr_pos_y = AppMain.dm_title_crsr_trial_pos_y_tbl[main_work.cur_slct_menu];
            }
            else
            {
                main_work.dst_crsr_pos_y = AppMain.dm_title_crsr_pos_y_tbl[0] + ( float )main_work.cur_slct_menu * AppMain.dm_title_crsr_pos_y_tbl[1];
            }
            main_work.flag |= 256U;
        }
    }

    // Token: 0x06000C94 RID: 3220 RVA: 0x0006F964 File Offset: 0x0006DB64
    private int dmTitleGetRevisedMenuFocus( int idx, int diff, int menu_num )
    {
        int num = idx + diff;
        if ( num < 0 )
        {
            num = menu_num - 1;
        }
        if ( num >= menu_num )
        {
            num = 0;
        }
        return num;
    }

    // Token: 0x06000C95 RID: 3221 RVA: 0x0006F984 File Offset: 0x0006DB84
    private void dmTitleSetCtrlFocusChangeEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        float[] array = new float[2];
        float[] array2 = array;
        float[] array3 = new float[2];
        float[] array4 = array3;
        array4[1] = main_work.dst_crsr_pos_y - main_work.src_crsr_pos_y;
        array2[1] = array4[1] / 8f;
        main_work.cur_crsr_pos_y += array2[1];
    }

    // Token: 0x06000C96 RID: 3222 RVA: 0x0006F9D0 File Offset: 0x0006DBD0
    private void dmTitleSetWinOpenEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( main_work.win_timer > 8f )
        {
            main_work.flag |= 65536U;
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

    // Token: 0x06000C97 RID: 3223 RVA: 0x0006FA94 File Offset: 0x0006DC94
    private void dmTitleSetWinCloseEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
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
            main_work.flag |= 65536U;
            main_work.win_timer = 0f;
            for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
            {
                main_work.win_size_rate[( int )( ( UIntPtr )num2 )] = 0f;
            }
            return;
        }
        main_work.win_timer -= 1f;
    }

    // Token: 0x06000C98 RID: 3224 RVA: 0x0006FB38 File Offset: 0x0006DD38
    private void dmTitleSetMMenuWinOpenEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( 0f == main_work.mmenu_win_timer )
        {
            AppMain.DmSoundPlaySE( "Window" );
        }
        if ( main_work.mmenu_win_timer > 8f )
        {
            main_work.flag |= 4194304U;
            main_work.mmenu_win_timer = 0f;
            for ( uint num = 0U; num < 2U; num += 1U )
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num )] = 1f;
            }
        }
        else
        {
            main_work.mmenu_win_timer += 1f;
        }
        for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
        {
            if ( main_work.mmenu_win_timer != 0f )
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num2 )] = main_work.mmenu_win_timer / 8f;
            }
            else
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
            if ( main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num2 )] > 1f )
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num2 )] = 1f;
            }
        }
    }

    // Token: 0x06000C99 RID: 3225 RVA: 0x0006FC10 File Offset: 0x0006DE10
    private void dmTitleSetMMenuWinCloseEfct( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            if ( main_work.mmenu_win_timer != 0f )
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num )] = main_work.mmenu_win_timer / 8f;
            }
            else
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num )] = 0f;
            }
        }
        if ( main_work.mmenu_win_timer < 0f )
        {
            main_work.flag |= 4194304U;
            main_work.mmenu_win_timer = 0f;
            for ( uint num2 = 0U; num2 < 2U; num2 += 1U )
            {
                main_work.mmenu_win_size_rate[( int )( ( UIntPtr )num2 )] = 0f;
            }
            return;
        }
        main_work.mmenu_win_timer -= 1f;
    }

    // Token: 0x06000C9A RID: 3226 RVA: 0x0006FCB4 File Offset: 0x0006DEB4
    private bool dmTitleIsCtrlFocusChangeEfctEnd( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        float num = main_work.dst_crsr_pos_y - main_work.src_crsr_pos_y;
        if ( main_work.cur_crsr_pos_y >= main_work.dst_crsr_pos_y && num >= 0f )
        {
            main_work.cur_crsr_pos_y = main_work.dst_crsr_pos_y;
            main_work.timer = 0f;
            return true;
        }
        if ( main_work.cur_crsr_pos_y <= main_work.dst_crsr_pos_y && num <= 0f )
        {
            main_work.cur_crsr_pos_y = main_work.dst_crsr_pos_y;
            main_work.timer = 0f;
            return true;
        }
        main_work.timer += 1f;
        return false;
    }

    // Token: 0x06000C9B RID: 3227 RVA: 0x0006FD48 File Offset: 0x0006DF48
    private void dmTitleSetLoadSysData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        uint num = 0U;
        SOption soption = SOption.CreateInstance();
        int volumeBgm = (int)soption.GetVolumeBgm();
        int volumeSe = (int)soption.GetVolumeSe();
        gss_MAIN_SYS_INFO.bgm_volume = ( float )( volumeBgm / 10 );
        gss_MAIN_SYS_INFO.se_volume = ( float )( volumeSe / 10 );
        AppMain.DmSoundSetVolumeBGM( gss_MAIN_SYS_INFO.bgm_volume );
        AppMain.DmSoundSetVolumeSE( gss_MAIN_SYS_INFO.se_volume );
        gss_MAIN_SYS_INFO.game_flag |= 64U;
        SSpecial sspecial = SSpecial.CreateInstance();
        for ( int i = 0; i < 7; i++ )
        {
            if ( sspecial[( int )( ( ushort )i )].IsGetEmerald() )
            {
                num |= 1U << i;
            }
        }
        if ( num == 127U )
        {
            gss_MAIN_SYS_INFO.game_flag |= 32U;
        }
        else
        {
            gss_MAIN_SYS_INFO.game_flag &= 4294967263U;
        }
        SSystem ssystem = SSystem.CreateInstance();
        gss_MAIN_SYS_INFO.rest_player_num = ssystem.GetPlayerStock();
        gss_MAIN_SYS_INFO.ene_kill_count = ssystem.GetKilled();
        gss_MAIN_SYS_INFO.final_clear_count = ssystem.GetClearCount();
        switch ( SOption.CreateInstance().GetControl() )
        {
            case SOption.EControl.Type.VirtualPadDown:
                gss_MAIN_SYS_INFO.game_flag &= 4294966783U;
                gss_MAIN_SYS_INFO.game_flag |= 1U;
                goto IL_169;
            case SOption.EControl.Type.VirtualPadUp:
                gss_MAIN_SYS_INFO.game_flag |= 512U;
                gss_MAIN_SYS_INFO.game_flag |= 1U;
                goto IL_169;
        }
        gss_MAIN_SYS_INFO.game_flag &= 4294966783U;
        gss_MAIN_SYS_INFO.game_flag &= 4294967294U;
        IL_169:
        gss_MAIN_SYS_INFO.is_spe_clear = false;
        gss_MAIN_SYS_INFO.is_first_play = false;
    }

    // Token: 0x06000C9C RID: 3228 RVA: 0x0006FECC File Offset: 0x0006E0CC
    private void dmTitleSetInitSysData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        SOption soption = SOption.CreateInstance();
        int volumeBgm = (int)soption.GetVolumeBgm();
        int volumeSe = (int)soption.GetVolumeSe();
        gss_MAIN_SYS_INFO.bgm_volume = ( float )volumeBgm / 10f;
        gss_MAIN_SYS_INFO.se_volume = ( float )volumeSe / 10f;
        AppMain.DmSoundSetVolumeBGM( gss_MAIN_SYS_INFO.bgm_volume );
        AppMain.DmSoundSetVolumeSE( gss_MAIN_SYS_INFO.se_volume );
        soption.IsVibration();
        gss_MAIN_SYS_INFO.game_flag |= 64U;
        gss_MAIN_SYS_INFO.game_flag &= 4294967263U;
        gss_MAIN_SYS_INFO.rest_player_num = 3U;
        gss_MAIN_SYS_INFO.is_spe_clear = false;
        gss_MAIN_SYS_INFO.is_first_play = false;
    }

    // Token: 0x06000C9D RID: 3229 RVA: 0x0006FF65 File Offset: 0x0006E165
    private void dmTitleSetMenuInfo( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        if ( AppMain.GsTrialIsTrial() )
        {
            main_work.slct_menu_num = 3;
            main_work.is_init_play = true;
            return;
        }
        if ( !AppMain.GsMainSysIsStageClear( 0 ) )
        {
            main_work.slct_menu_num = 3;
            main_work.is_init_play = true;
            return;
        }
        main_work.slct_menu_num = 3;
        main_work.is_init_play = false;
    }

    // Token: 0x06000C9E RID: 3230 RVA: 0x0006FFA4 File Offset: 0x0006E1A4
    private void dmTitleSetFirstPlayData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        SSystem ssystem = SSystem.CreateInstance();
        gss_MAIN_SYS_INFO.rest_player_num = 3U;
        ssystem.SetPlayerStock( gss_MAIN_SYS_INFO.rest_player_num );
        this.dmTitleSetLoadSysData( main_work );
    }

    // Token: 0x06000C9F RID: 3231 RVA: 0x0006FFD8 File Offset: 0x0006E1D8
    private void dmTitleSetInitSaveData( AppMain.DMS_TITLE_MAIN_WORK main_work )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        GSS_BACKUP backup = gss_MAIN_SYS_INFO.backup;
        backup.Init();
    }

    // Token: 0x06000CA0 RID: 3232 RVA: 0x0006FFF8 File Offset: 0x0006E1F8
    private bool dmTitleIsSaveRunning()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        return gss_MAIN_SYS_INFO.is_save_run != 0U;
    }

    // Token: 0x06000CA1 RID: 3233 RVA: 0x0007001C File Offset: 0x0006E21C
    private bool dmTitleIsChangeOptVol()
    {
        SOption soption = SOption.CreateInstance();
        return soption.GetVolumeBgm() != 100U || soption.GetVolumeSe() != 100U;
    }
}
