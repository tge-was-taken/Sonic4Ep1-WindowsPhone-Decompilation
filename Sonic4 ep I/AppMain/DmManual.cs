using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accel;
using er;

public partial class AppMain
{
    // Token: 0x02000346 RID: 838
    private enum DME_MANUAL_DATA_TYPE
    {
        // Token: 0x04005EB9 RID: 24249
        DME_MANUAL_DATA_TYPE_CMN_DATA,
        // Token: 0x04005EBA RID: 24250
        DME_MANUAL_DATA_TYPE_LANG_DATA,
        // Token: 0x04005EBB RID: 24251
        DME_MANUAL_DATA_TYPE_MAX,
        // Token: 0x04005EBC RID: 24252
        DME_MANUAL_DATA_TYPE_NONE
    }

    // Token: 0x02000347 RID: 839
    public class DMS_MANUAL_MGR
    {
        // Token: 0x060025C8 RID: 9672 RVA: 0x0014E361 File Offset: 0x0014C561
        internal void Clear()
        {
            this.tcb = null;
        }

        // Token: 0x04005EBD RID: 24253
        public AppMain.MTS_TASK_TCB tcb;
    }

    // Token: 0x02000348 RID: 840
    public class DMS_MANUAL_MAIN_WORK
    {
        // Token: 0x060025CA RID: 9674 RVA: 0x0014E374 File Offset: 0x0014C574
        public DMS_MANUAL_MAIN_WORK()
        {
            this.tex = AppMain.New<AppMain.AOS_TEXTURE>( 2 );
            this.trg_btn = AppMain.New<CTrgAoAction>( 2 );
        }

        // Token: 0x04005EBE RID: 24254
        public AppMain.AMS_FS arc_amb;

        // Token: 0x04005EBF RID: 24255
        public AppMain.A2S_AMA_HEADER[] ama = new AppMain.A2S_AMA_HEADER[2];

        // Token: 0x04005EC0 RID: 24256
        public AppMain.AMS_AMB_HEADER[] amb = new AppMain.AMS_AMB_HEADER[2];

        // Token: 0x04005EC1 RID: 24257
        public AppMain.AOS_TEXTURE[] tex;

        // Token: 0x04005EC2 RID: 24258
        public AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[179];

        // Token: 0x04005EC3 RID: 24259
        public AppMain.DMS_MANUAL_MAIN_WORK._proc_input_ proc_input;

        // Token: 0x04005EC4 RID: 24260
        public AppMain.DMS_MANUAL_MAIN_WORK._proc_update_ proc_update;

        // Token: 0x04005EC5 RID: 24261
        public AppMain.DMS_MANUAL_MAIN_WORK._proc_draw_ proc_draw;

        // Token: 0x04005EC6 RID: 24262
        public float timer;

        // Token: 0x04005EC7 RID: 24263
        public uint flag;

        // Token: 0x04005EC8 RID: 24264
        public float efct_timer;

        // Token: 0x04005EC9 RID: 24265
        public int cur_disp_page;

        // Token: 0x04005ECA RID: 24266
        public int cur_disp_page_prev;

        // Token: 0x04005ECB RID: 24267
        public bool is_jp_region;

        // Token: 0x04005ECC RID: 24268
        public bool is_maingame_load;

        // Token: 0x04005ECD RID: 24269
        public uint draw_state;

        // Token: 0x04005ECE RID: 24270
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x04005ECF RID: 24271
        public CTrgAoAction[] trg_btn;

        // Token: 0x04005ED0 RID: 24272
        public CTrgAoAction trg_return = new CTrgAoAction();

        // Token: 0x02000349 RID: 841
        // (Invoke) Token: 0x060025CC RID: 9676
        public delegate void _proc_input_( AppMain.DMS_MANUAL_MAIN_WORK work );

        // Token: 0x0200034A RID: 842
        // (Invoke) Token: 0x060025D0 RID: 9680
        public delegate void _proc_update_( AppMain.DMS_MANUAL_MAIN_WORK work );

        // Token: 0x0200034B RID: 843
        // (Invoke) Token: 0x060025D4 RID: 9684
        public delegate void _proc_draw_( AppMain.DMS_MANUAL_MAIN_WORK work );
    }

    // Token: 0x060017B1 RID: 6065 RVA: 0x000D23A8 File Offset: 0x000D05A8
    private static void DmManualBuild( AppMain.AMS_AMB_HEADER[] arc_amb )
    {
        AppMain.dm_manual_mgr.Clear();
        AppMain.dm_manual_mgr_p = AppMain.dm_manual_mgr;
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.dm_manual_tex[i].Clear();
        }
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.dm_manual_ama[i] = AppMain.readAMAFile( AppMain.amBindGet( arc_amb[i], 0 ) );
            string dir;
            AppMain.dm_manual_amb[i] = AppMain.readAMBFile( AppMain.amBindGet( arc_amb[i], 1, out dir ) );
            AppMain.dm_manual_amb[i].dir = dir;
        }
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexBuild( AppMain.dm_manual_tex[i], AppMain.dm_manual_amb[i] );
            AppMain.AoTexLoad( AppMain.dm_manual_tex[i] );
        }
    }

    // Token: 0x060017B2 RID: 6066 RVA: 0x000D2453 File Offset: 0x000D0653
    private static bool DmManualBuildCheck()
    {
        return AppMain.dmManualIsTexLoad() != 0;
    }

    // Token: 0x060017B3 RID: 6067 RVA: 0x000D2460 File Offset: 0x000D0660
    private static void DmManualFlush()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexRelease( AppMain.dm_manual_tex[i] );
        }
    }

    // Token: 0x060017B4 RID: 6068 RVA: 0x000D2485 File Offset: 0x000D0685
    private static bool DmManualFlushCheck()
    {
        return AppMain.dmManualIsTexRelease() != 0;
    }

    // Token: 0x060017B5 RID: 6069 RVA: 0x000D2491 File Offset: 0x000D0691
    private static void DmManualStart()
    {
        AppMain.dmManualInit();
    }

    // Token: 0x060017B6 RID: 6070 RVA: 0x000D2498 File Offset: 0x000D0698
    private static bool DmManualIsExit()
    {
        return AppMain.dm_manual_mgr_p.tcb == null;
    }

    // Token: 0x060017B7 RID: 6071 RVA: 0x000D24A9 File Offset: 0x000D06A9
    private static void DmManualExit()
    {
        if ( AppMain.dm_manual_mgr_p.tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.dm_manual_mgr_p.tcb );
            AppMain.dm_manual_mgr_p.tcb = null;
        }
    }

    // Token: 0x060017B8 RID: 6072 RVA: 0x000D24D8 File Offset: 0x000D06D8
    private static void dmManualInit()
    {
        AppMain.dm_manual_mgr_p.tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.dmManualProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.dmManualDest ), 0U, 32767, 12288U, 10, () => new AppMain.DMS_MANUAL_MAIN_WORK(), "MANUAL_MAIN" );
        AppMain.DMS_MANUAL_MAIN_WORK dms_MANUAL_MAIN_WORK = (AppMain.DMS_MANUAL_MAIN_WORK)AppMain.dm_manual_mgr_p.tcb.work;
        dms_MANUAL_MAIN_WORK.draw_state = ( AppMain.AoActSysGetDrawStateEnable() ? 1U : 0U );
        AppMain.AoActSysSetDrawStateEnable( dms_MANUAL_MAIN_WORK.draw_state != 0U );
        if ( dms_MANUAL_MAIN_WORK.draw_state != 0U )
        {
            AppMain.dm_manual_draw_state = AppMain.AoActSysGetDrawState();
            AppMain.AoActSysSetDrawState( AppMain.dm_manual_draw_state );
        }
        if ( AppMain.GeEnvGetDecideKey() == AppMain.GSE_DECIDE_KEY.GSD_DECIDE_KEY_O )
        {
            dms_MANUAL_MAIN_WORK.is_jp_region = true;
        }
        else
        {
            dms_MANUAL_MAIN_WORK.is_jp_region = false;
        }
        AppMain.dmManualSetInitData( dms_MANUAL_MAIN_WORK );
        short cur_evt_id = AppMain.SyGetEvtInfo().cur_evt_id;
        if ( cur_evt_id == 6 || cur_evt_id == 11 )
        {
            AppMain.dm_manual_is_pause_maingame = true;
            dms_MANUAL_MAIN_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        }
        dms_MANUAL_MAIN_WORK.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcInit );
    }

    // Token: 0x060017B9 RID: 6073 RVA: 0x000D25E4 File Offset: 0x000D07E4
    private static void dmManualSetInitData( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        main_work.cur_disp_page = 0;
        main_work.cur_disp_page_prev = -1;
    }

    // Token: 0x060017BA RID: 6074 RVA: 0x000D25F4 File Offset: 0x000D07F4
    private static void dmManualProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_MANUAL_MAIN_WORK dms_MANUAL_MAIN_WORK = (AppMain.DMS_MANUAL_MAIN_WORK)tcb.work;
        if ( ( dms_MANUAL_MAIN_WORK.flag & 1U ) != 0U )
        {
            AppMain.DmManualExit();
        }
        if ( ( dms_MANUAL_MAIN_WORK.flag & 2147483648U ) != 0U && !AppMain.AoAccountIsCurrentEnable() )
        {
            dms_MANUAL_MAIN_WORK.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcFadeOut );
            dms_MANUAL_MAIN_WORK.flag &= 2147483647U;
            if ( AppMain.dm_manual_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 1U, 1U, 32f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 1U, 1U, 32f );
            }
            dms_MANUAL_MAIN_WORK.flag &= 4294967291U;
            dms_MANUAL_MAIN_WORK.flag &= 4294967293U;
            dms_MANUAL_MAIN_WORK.proc_input = null;
        }
        if ( dms_MANUAL_MAIN_WORK.proc_update != null )
        {
            dms_MANUAL_MAIN_WORK.proc_update( dms_MANUAL_MAIN_WORK );
        }
        if ( dms_MANUAL_MAIN_WORK.proc_draw != null )
        {
            dms_MANUAL_MAIN_WORK.proc_draw( dms_MANUAL_MAIN_WORK );
        }
    }

    // Token: 0x060017BB RID: 6075 RVA: 0x000D26D1 File Offset: 0x000D08D1
    private static void dmManualDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060017BC RID: 6076 RVA: 0x000D26D3 File Offset: 0x000D08D3
    private static void dmManualProcInit( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        main_work.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcCreateAct );
        main_work.flag |= 2147483648U;
    }

    // Token: 0x060017BD RID: 6077 RVA: 0x000D26FC File Offset: 0x000D08FC
    private static void dmManualProcCreateAct( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        for ( uint num = 0U; num <= 13U; num += 1U )
        {
            AppMain.A2S_AMA_HEADER ama = AppMain.dm_manual_ama[0];
            AppMain.AOS_TEXTURE tex = AppMain.dm_manual_tex[0];
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_m[( int )( ( UIntPtr )num )] );
        }
        for ( uint num2 = 10U; num2 <= 11U; num2 += 1U )
        {
            main_work.trg_btn[( int )( ( UIntPtr )( num2 - 10U ) )].Create( main_work.act[( int )( ( UIntPtr )num2 )] );
        }
        main_work.trg_return.Create( main_work.act[13] );
        for ( uint num3 = 119U; num3 <= 120U; num3 += 1U )
        {
            AppMain.A2S_AMA_HEADER ama = AppMain.dm_manual_ama[1];
            AppMain.AOS_TEXTURE tex = AppMain.dm_manual_tex[1];
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( tex ) );
            main_work.act[( int )( ( UIntPtr )num3 )] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_m[( int )( ( UIntPtr )num3 )] );
        }
        main_work.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcFadeIn );
        main_work.proc_draw = new AppMain.DMS_MANUAL_MAIN_WORK._proc_draw_( AppMain.dmManualProcActDraw );
        if ( AppMain.dm_manual_is_pause_maingame )
        {
            AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 0U, 32f, true );
            return;
        }
        AppMain.IzFadeInitEasy( 0U, 0U, 32f );
    }

    // Token: 0x060017BE RID: 6078 RVA: 0x000D281E File Offset: 0x000D0A1E
    private static void dmManualProcFadeIn( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.IzFadeExit();
            main_work.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcWaitInput );
            main_work.proc_input = new AppMain.DMS_MANUAL_MAIN_WORK._proc_input_( AppMain.dmManualInputProcMain );
        }
    }

    // Token: 0x060017BF RID: 6079 RVA: 0x000D285C File Offset: 0x000D0A5C
    private static void dmManualProcWaitInput( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        if ( main_work.proc_input != null )
        {
            main_work.proc_input( main_work );
        }
        int[] array = new int[]
        {
            12,
            13,
            119
        };
        int i = 0;
        int num = array.Length;
        while ( i < num )
        {
            AppMain.AOS_ACTION aos_ACTION = main_work.act[array[i]];
            float frame;
            if ( main_work.trg_return.GetState( 0U )[10] && main_work.trg_return.GetState( 0U )[1] )
            {
                frame = 2f;
            }
            else if ( main_work.trg_return.GetState( 0U )[0] )
            {
                frame = 1f;
            }
            else if ( 2f <= aos_ACTION.frame )
            {
                frame = aos_ACTION.frame;
            }
            else
            {
                frame = 0f;
            }
            AppMain.AoActSetFrame( aos_ACTION, frame );
            i++;
        }
        if ( ( main_work.flag & 2U ) != 0U )
        {
            main_work.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcFadeOut );
            if ( AppMain.dm_manual_is_pause_maingame )
            {
                AppMain.IzFadeInitEasyColor( 0, 32767, 61439, 18U, 0U, 1U, 32f, true );
            }
            else
            {
                AppMain.IzFadeInitEasy( 0U, 1U, 32f );
            }
            if ( !AppMain.dm_manual_is_pause_maingame )
            {
                AppMain.DmSoundPlaySE( "Cancel" );
            }
            else
            {
                AppMain.GsSoundPlaySe( "Cancel", main_work.se_handle );
            }
            main_work.flag &= 4294967291U;
            main_work.flag &= 4294967293U;
            return;
        }
        if ( ( main_work.flag & 8U ) != 0U )
        {
            main_work.cur_disp_page++;
            if ( main_work.cur_disp_page > 14 )
            {
                main_work.cur_disp_page = 14;
            }
            else if ( !AppMain.dm_manual_is_pause_maingame )
            {
                AppMain.DmSoundPlaySE( "Cursol" );
            }
            else
            {
                AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
            }
            main_work.flag &= 4294967287U;
            return;
        }
        if ( ( main_work.flag & 16U ) != 0U )
        {
            main_work.cur_disp_page--;
            if ( main_work.cur_disp_page < 0 )
            {
                main_work.cur_disp_page = 0;
            }
            else if ( !AppMain.dm_manual_is_pause_maingame )
            {
                AppMain.DmSoundPlaySE( "Cursol" );
            }
            else
            {
                AppMain.GsSoundPlaySe( "Cursol", main_work.se_handle );
            }
            main_work.flag &= 4294967279U;
        }
    }

    // Token: 0x060017C0 RID: 6080 RVA: 0x000D2A71 File Offset: 0x000D0C71
    private static void dmManualProcFadeOut( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            main_work.proc_update = new AppMain.DMS_MANUAL_MAIN_WORK._proc_update_( AppMain.dmManualProcStopDraw );
            main_work.proc_draw = null;
            if ( main_work.se_handle != null )
            {
                AppMain.GsSoundFreeSeHandle( main_work.se_handle );
                main_work.se_handle = null;
            }
        }
    }

    // Token: 0x060017C1 RID: 6081 RVA: 0x000D2AB0 File Offset: 0x000D0CB0
    private static void dmManualInputProcMain( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        if ( ( main_work.trg_return.GetState( 0U )[10] && main_work.trg_return.GetState( 0U )[1] ) || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            main_work.flag |= 2U;
            return;
        }
        if ( main_work.trg_btn[1].GetState( 0U )[7] )
        {
            if ( main_work.trg_btn[1].GetState( 0U )[8] || main_work.cur_disp_page != 14 )
            {
                main_work.flag |= 8U;
            }
            return;
        }
        if ( main_work.trg_btn[0].GetState( 0U )[7] && ( main_work.trg_btn[0].GetState( 0U )[8] || main_work.cur_disp_page != 0 ) )
        {
            main_work.flag |= 16U;
        }
    }

    // Token: 0x060017C2 RID: 6082 RVA: 0x000D2B8C File Offset: 0x000D0D8C
    private static void dmManualProcStopDraw( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        for ( int i = 0; i < 179; i++ )
        {
            if ( main_work.act[i] != null )
            {
                AppMain.AoActDelete( main_work.act[i] );
                main_work.act[i] = null;
            }
        }
        for ( int j = 0; j < main_work.trg_btn.Length; j++ )
        {
            CTrgAoAction ctrgAoAction = main_work.trg_btn[j];
            ctrgAoAction.Release();
        }
        CTrgAoAction trg_return = main_work.trg_return;
        trg_return.Release();
        main_work.proc_update = null;
        main_work.flag |= 1U;
    }

    // Token: 0x060017C3 RID: 6083 RVA: 0x000D2C0D File Offset: 0x000D0E0D
    private static void dmManualProcActDraw( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        AppMain.dmManualCommonBgDraw( main_work );
        AppMain.dmManualPageDraw( main_work );
        AppMain.dmManualCommonDraw( main_work );
        if ( main_work.draw_state > 0U )
        {
            AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.dmManualTaskDraw ), 32768, 0U );
        }
    }

    // Token: 0x060017C4 RID: 6084 RVA: 0x000D2C41 File Offset: 0x000D0E41
    private static void dmManualTaskDraw( AppMain.AMS_TCB tcb )
    {
        AppMain.AoActDrawPre();
        AppMain.amDrawExecCommand( AppMain.dm_manual_draw_state );
        AppMain.amDrawEndScene();
    }

    // Token: 0x060017C5 RID: 6085 RVA: 0x000D2C58 File Offset: 0x000D0E58
    private static void dmManualCommonBgDraw( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 6144U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[0] ) );
        for ( int i = 0; i <= 4; i++ )
        {
            AppMain.AoActSortRegAction( main_work.act[i] );
        }
        for ( int j = 0; j <= 4; j++ )
        {
            AppMain.AoActUpdate( main_work.act[j], 0f );
            if ( j == 3 )
            {
                AppMain.AOS_SPRITE sprite = main_work.act[j].sprite;
                sprite.offset.top = sprite.offset.top - 1f;
                AppMain.AOS_SPRITE sprite2 = main_work.act[j].sprite;
                sprite2.offset.left = sprite2.offset.left - 2f;
            }
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x060017C6 RID: 6086 RVA: 0x000D2D10 File Offset: 0x000D0F10
    private static void dmManualCommonDraw( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 12288U );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[0] ) );
        for ( int i = 5; i <= 11; i++ )
        {
            if ( i == 5 )
            {
                if ( main_work.cur_disp_page >= 9 )
                {
                    AppMain.AoActSortRegAction( main_work.act[i] );
                }
            }
            else if ( i == 10 )
            {
                if ( main_work.cur_disp_page != 0 )
                {
                    AppMain.AoActSortRegAction( main_work.act[i] );
                }
            }
            else if ( i == 11 )
            {
                if ( main_work.cur_disp_page != 14 )
                {
                    AppMain.AoActSortRegAction( main_work.act[i] );
                }
            }
            else
            {
                AppMain.AoActSortRegAction( main_work.act[i] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[1] ) );
        for ( int j = 119; j < 120; j++ )
        {
            AppMain.AoActSortRegAction( main_work.act[j] );
        }
        if ( main_work.cur_disp_page >= 1 )
        {
            AppMain.AoActSortRegAction( main_work.act[120] );
        }
        for ( int k = 12; k <= 13; k++ )
        {
            AppMain.AoActSortRegAction( main_work.act[k] );
        }
        float frame;
        if ( main_work.cur_disp_page != 0 )
        {
            frame = ( float )( main_work.cur_disp_page / 10 );
        }
        else
        {
            frame = 0f;
        }
        float num = (float)(main_work.cur_disp_page % 10);
        if ( main_work.cur_disp_page == 9 )
        {
            AppMain.AoActSetFrame( main_work.act[5], 0f );
            AppMain.AoActSetFrame( main_work.act[6], 0f );
        }
        else if ( main_work.cur_disp_page < 10 )
        {
            AppMain.AoActSetFrame( main_work.act[5], 0f );
            AppMain.AoActSetFrame( main_work.act[6], ( float )main_work.cur_disp_page + 1f );
        }
        else
        {
            AppMain.AoActSetFrame( main_work.act[5], frame );
            AppMain.AoActSetFrame( main_work.act[6], num + 1f );
        }
        AppMain.AoActSetFrame( main_work.act[8], 0f );
        AppMain.AoActSetFrame( main_work.act[9], 0f );
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[0] ) );
        for ( int l = 5; l < 10; l++ )
        {
            AppMain.AoActUpdate( main_work.act[l], 0f );
        }
        for ( int m = 10; m <= 11; m++ )
        {
            AppMain.AoActUpdate( main_work.act[m], 1f );
        }
        for ( int n = 12; n <= 13; n++ )
        {
            float frame2 = (2f <= main_work.act[n].frame) ? 1f : 0f;
            AppMain.AoActUpdate( main_work.act[n], frame2 );
        }
        for ( int num2 = 0; num2 < main_work.trg_btn.Length; num2++ )
        {
            main_work.trg_btn[num2].Update();
        }
        main_work.trg_return.Update();
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[1] ) );
        for ( int num3 = 119; num3 < 120; num3++ )
        {
            float frame3 = (2f <= main_work.act[num3].frame) ? 1f : 0f;
            AppMain.AoActUpdate( main_work.act[num3], frame3 );
        }
        for ( int num4 = 120; num4 <= 120; num4++ )
        {
            AppMain.AoActUpdate( main_work.act[num4], 0f );
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x060017C7 RID: 6087 RVA: 0x000D3048 File Offset: 0x000D1248
    private static void dmManualPageDraw( AppMain.DMS_MANUAL_MAIN_WORK main_work )
    {
        AppMain.AoActSysSetDrawTaskPrio( 8192U );
        int cur_disp_page = main_work.cur_disp_page;
        int num = AppMain.dm_manual_disp_act_cmn_tbl[cur_disp_page][0];
        int num2 = AppMain.dm_manual_disp_act_cmn_tbl[cur_disp_page][1];
        int num3 = AppMain.dm_manual_disp_act_lang_tbl[cur_disp_page][0];
        int num4 = AppMain.dm_manual_disp_act_lang_tbl[cur_disp_page][1];
        bool flag = main_work.cur_disp_page_prev != main_work.cur_disp_page;
        if ( flag && 0 <= main_work.cur_disp_page_prev )
        {
            for ( int i = AppMain.dm_manual_disp_act_cmn_tbl[main_work.cur_disp_page_prev][0]; i <= AppMain.dm_manual_disp_act_cmn_tbl[main_work.cur_disp_page_prev][1]; i++ )
            {
                AppMain.AoActDelete( main_work.act[i] );
                main_work.act[i] = null;
            }
            for ( int j = AppMain.dm_manual_disp_act_lang_tbl[main_work.cur_disp_page_prev][0]; j <= AppMain.dm_manual_disp_act_lang_tbl[main_work.cur_disp_page_prev][1]; j++ )
            {
                AppMain.AoActDelete( main_work.act[j] );
                main_work.act[j] = null;
            }
        }
        main_work.cur_disp_page_prev = main_work.cur_disp_page;
        for ( int k = num; k <= num2; k++ )
        {
            if ( flag )
            {
                AppMain.A2S_AMA_HEADER ama = AppMain.dm_manual_ama[0];
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[0] ) );
                main_work.act[k] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_m[k] );
            }
            if ( k != 118 )
            {
                AppMain.AoActSortRegAction( main_work.act[k] );
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[1] ) );
        for ( int l = num3; l <= num4; l++ )
        {
            if ( flag )
            {
                AppMain.A2S_AMA_HEADER ama = AppMain.dm_manual_ama[1];
                main_work.act[l] = AppMain.AoActCreate( ama, AppMain.g_dm_act_id_tbl_m[l] );
                if ( AppMain.GsEnvGetLanguage() == 6 )
                {
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 9U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 120f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 10U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 125f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 48U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 120f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 49U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 125f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 18U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 90f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 19U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 200f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 52U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 90f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 53U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 200f;
                    }
                }
                if ( AppMain.GsEnvGetLanguage() == 7 )
                {
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 9U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 180f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 10U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 185f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 48U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 180f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 49U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 185f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 18U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 280f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 19U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 235f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 52U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 280f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 53U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 235f;
                    }
                }
                if ( AppMain.GsEnvGetLanguage() == 8 )
                {
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 9U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 160f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 10U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 245f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 48U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 160f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 49U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 245f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 18U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 19U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 220f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 52U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 53U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 220f;
                    }
                }
                if ( AppMain.GsEnvGetLanguage() == 9 )
                {
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 9U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 10U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 225f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 48U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 49U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 225f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 18U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 19U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 52U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 53U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                }
                if ( AppMain.GsEnvGetLanguage() == 10 )
                {
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 9U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 10U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 225f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 48U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 49U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 225f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 18U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 19U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 52U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                    if ( AppMain.g_dm_act_id_tbl_m[l] == 53U )
                    {
                        ( ( AppMain.A2S_AMA_ACT )main_work.act[l].data ).mtn.trs_tbl[0].trs_x = 110f;
                    }
                }
            }
            AppMain.AoActSortRegAction( main_work.act[l] );
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[0] ) );
        for ( int m = num; m <= num2; m++ )
        {
            if ( m != 118 )
            {
                AppMain.AoActUpdate( main_work.act[m], 1f );
                if ( main_work.cur_disp_page_prev != 8 )
                {
                    main_work.act[m].sprite.center_y -= 16f;
                    if ( main_work.cur_disp_page_prev == 6 || main_work.cur_disp_page_prev == 7 || main_work.cur_disp_page_prev == 10 || main_work.cur_disp_page_prev == 12 )
                    {
                        main_work.act[m].sprite.center_y -= 16f;
                    }
                    if ( m == 14 )
                    {
                        AppMain.AOS_SPRITE sprite = main_work.act[m].sprite;
                        sprite.offset.right = sprite.offset.right + 1f;
                    }
                }
                if ( ( m >= 54 && m <= 55 ) || ( m >= 59 && m <= 61 ) || ( m == 65 || m == 80 || m == 81 || m == 25 || m == 24 || ( m >= 91 && m <= 93 ) ) || ( m >= 103 && m <= 105 ) )
                {
                    main_work.act[m].sprite.center_y += 16f;
                }
                if ( m >= 82 && m <= 90 )
                {
                    AppMain.AOS_SPRITE sprite2 = main_work.act[m].sprite;
                    sprite2.offset.top = sprite2.offset.top + 40f;
                    AppMain.AOS_SPRITE sprite3 = main_work.act[m].sprite;
                    sprite3.offset.bottom = sprite3.offset.bottom - 40f;
                }
                else if ( m >= 114 && m <= 116 )
                {
                    AppMain.AOS_SPRITE sprite4 = main_work.act[m].sprite;
                    sprite4.offset.top = sprite4.offset.top + 80f;
                    AppMain.AOS_SPRITE sprite5 = main_work.act[m].sprite;
                    sprite5.offset.bottom = sprite5.offset.bottom - 80f;
                }
                else if ( ( m >= 67 && m <= 72 ) || ( m >= 94 && m <= 102 ) || m == 80 || m == 81 )
                {
                    AppMain.AOS_SPRITE sprite6 = main_work.act[m].sprite;
                    sprite6.offset.top = sprite6.offset.top + 20f;
                    AppMain.AOS_SPRITE sprite7 = main_work.act[m].sprite;
                    sprite7.offset.bottom = sprite7.offset.bottom - 20f;
                    if ( m == 80 || m == 81 )
                    {
                        AppMain.AOS_SPRITE sprite8 = main_work.act[m].sprite;
                        sprite8.offset.left = sprite8.offset.left + 25f;
                        AppMain.AOS_SPRITE sprite9 = main_work.act[m].sprite;
                        sprite9.offset.right = sprite9.offset.right - 25f;
                    }
                }
                else if ( m == 117 )
                {
                    main_work.act[m].sprite.center_y += 70f;
                }
            }
        }
        AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_manual_tex[1] ) );
        for ( int n = num3; n <= num4; n++ )
        {
            AppMain.AoActUpdate( main_work.act[n], 1f );
            if ( main_work.cur_disp_page_prev < 3 || main_work.cur_disp_page_prev > 9 || main_work.cur_disp_page_prev == 7 )
            {
                main_work.act[n].sprite.center_y -= 16f;
            }
            if ( n == num3 && ( main_work.cur_disp_page_prev < 3 || main_work.cur_disp_page_prev > 12 ) )
            {
                main_work.act[n].sprite.center_y += 16f;
            }
            if ( n == 143 || n == 144 )
            {
                main_work.act[n].sprite.center_y -= 16f;
            }
            else if ( ( n >= 147 && n <= 148 ) || ( n >= 151 && n <= 152 ) || n == 157 || n == 174 || n == 170 || n == 161 || n == 162 || main_work.cur_disp_page_prev == 11 )
            {
                main_work.act[n].sprite.center_y += 16f;
            }
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
    }

    // Token: 0x060017C8 RID: 6088 RVA: 0x000D3EE0 File Offset: 0x000D20E0
    private static int dmManualIsTexLoad()
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( AppMain.dm_manual_tex[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x060017C9 RID: 6089 RVA: 0x000D3F0C File Offset: 0x000D210C
    private static int dmManualIsTexRelease()
    {
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsReleased( AppMain.dm_manual_tex[i] ) )
            {
                return 0;
            }
        }
        return 1;
    }

}