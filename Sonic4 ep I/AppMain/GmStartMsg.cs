using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001F5 RID: 501
    public class GMS_SMSG_2D_OBJ_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002314 RID: 8980 RVA: 0x00147F04 File Offset: 0x00146104
        public GMS_SMSG_2D_OBJ_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x06002315 RID: 8981 RVA: 0x00147F23 File Offset: 0x00146123
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x04005515 RID: 21781
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04005516 RID: 21782
        public readonly AppMain.OBS_ACTION2D_AMA_WORK obj_2d = new AppMain.OBS_ACTION2D_AMA_WORK();
    }

    // Token: 0x020001F6 RID: 502
    // (Invoke) Token: 0x06002317 RID: 8983
    public delegate void pfnGMS_SMSG_MGR_WORK( AppMain.GMS_SMSG_MGR_WORK p );

    // Token: 0x020001F7 RID: 503
    public class GMS_SMSG_MGR_WORK : AppMain.IClearable
    {
        // Token: 0x0600231A RID: 8986 RVA: 0x00147F2C File Offset: 0x0014612C
        public void Clear()
        {
            this.flag = 0U;
            this.timer = 0;
            this.msg_type = 0;
            this.func = null;
            Array.Clear( this.ama_2d_work, 0, this.ama_2d_work.Length );
            Array.Clear( this.ama_2d_work_act, 0, this.ama_2d_work_act.Length );
        }

        // Token: 0x04005517 RID: 21783
        public uint flag;

        // Token: 0x04005518 RID: 21784
        public int timer;

        // Token: 0x04005519 RID: 21785
        public int msg_type;

        // Token: 0x0400551A RID: 21786
        public AppMain.pfnGMS_SMSG_MGR_WORK func;

        // Token: 0x0400551B RID: 21787
        public float win_per;

        // Token: 0x0400551C RID: 21788
        public AppMain.GMS_SMSG_2D_OBJ_WORK[] ama_2d_work = new AppMain.GMS_SMSG_2D_OBJ_WORK[AppMain.GMD_SMSG_AMA_ACT_MAX];

        // Token: 0x0400551D RID: 21789
        public AppMain.GMS_SMSG_2D_OBJ_WORK[] ama_2d_work_act = new AppMain.GMS_SMSG_2D_OBJ_WORK[AppMain.GMD_SMSG_AMA_ACT_ACTION_MAX];
    }

    // Token: 0x06000A92 RID: 2706 RVA: 0x0005D110 File Offset: 0x0005B310
    public static void GmStartMsgExit()
    {
        if ( AppMain.gm_start_msg_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_start_msg_tcb );
            AppMain.gm_start_msg_tcb = null;
            AppMain.ObjDrawSetNNCommandStateTbl( 16U, uint.MaxValue, false );
            AppMain.ObjDrawSetNNCommandStateTbl( 17U, uint.MaxValue, false );
            AppMain.g_obj.ppPost = null;
            AppMain.g_gm_main_system.game_flag &= 4278190079U;
        }
    }

    // Token: 0x06000A93 RID: 2707 RVA: 0x0005D168 File Offset: 0x0005B368
    public static void GmStartMsgFlush()
    {
        int num = 2;
        if ( AppMain.g_gs_main_sys_info.stage_id != 5 )
        {
            num = 3;
        }
        AppMain.AOS_TEXTURE[] array = AppMain.gm_start_msg_aos_tex;
        for ( int i = 0; i < num; i++ )
        {
            AppMain.AoTexRelease( array[i] );
        }
    }

    // Token: 0x06000A94 RID: 2708 RVA: 0x0005D1A0 File Offset: 0x0005B3A0
    public static bool GmStartMsgFlushCheck()
    {
        bool flag = true;
        int num = 2;
        if ( AppMain.g_gs_main_sys_info.stage_id != 5 )
        {
            num = 3;
        }
        if ( AppMain.gm_start_msg_aos_tex != null )
        {
            AppMain.AOS_TEXTURE[] array = AppMain.gm_start_msg_aos_tex;
            for ( int i = 0; i < num; i++ )
            {
                if ( !AppMain.AoTexIsReleased( array[i] ) )
                {
                    flag = false;
                }
            }
            if ( flag )
            {
                AppMain.gm_start_msg_aos_tex = null;
            }
        }
        return flag;
    }

    // Token: 0x06000A95 RID: 2709 RVA: 0x0005D1F0 File Offset: 0x0005B3F0
    public static bool GmStartMsgBuildCheck()
    {
        bool result = true;
        int num = 2;
        if ( AppMain.g_gs_main_sys_info.stage_id != 5 )
        {
            num = 3;
        }
        if ( AppMain.gm_start_msg_aos_tex != null )
        {
            for ( int i = 0; i < num; i++ )
            {
                if ( !AppMain.AoTexIsLoaded( AppMain.gm_start_msg_aos_tex[i] ) )
                {
                    result = false;
                }
            }
        }
        return result;
    }

    // Token: 0x06000A96 RID: 2710 RVA: 0x0005D234 File Offset: 0x0005B434
    public static void GmStartMsgBuild()
    {
        int num = AppMain.GsEnvGetLanguage();
        object[] array = new object[3];
        AppMain.gm_start_msg_aos_tex = AppMain.New<AppMain.AOS_TEXTURE>( 3 );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(991);
        AppMain.AMS_AMB_HEADER header = AppMain.GmGameDatGetGimmickData(992);
        array[0] = AppMain.amBindGet( ams_AMB_HEADER, num * 2 + 1 );
        array[1] = AppMain.amBindGet( header, 1 );
        int num2 = 2;
        if ( AppMain.g_gs_main_sys_info.stage_id != 5 )
        {
            array[2] = AppMain.amBindGet( ams_AMB_HEADER, ams_AMB_HEADER.file_num - 1 );
            num2 = 3;
        }
        for ( int i = 0; i < num2; i++ )
        {
            AppMain.AOS_TEXTURE tex = AppMain.gm_start_msg_aos_tex[i];
            AppMain.AoTexBuild( tex, ( AppMain.AMS_AMB_HEADER )array[i] );
            AppMain.AoTexLoad( tex );
        }
    }

    // Token: 0x06000A97 RID: 2711 RVA: 0x0005D2DC File Offset: 0x0005B4DC
    public static void gmStartMsgObjPost()
    {
        if ( AppMain.gm_start_msg_tcb == null )
        {
            return;
        }
        AppMain.GMS_SMSG_MGR_WORK gms_SMSG_MGR_WORK = (AppMain.GMS_SMSG_MGR_WORK)AppMain.gm_start_msg_tcb.work;
        AppMain.ObjDraw3DNNUserFunc( new AppMain.OBF_DRAW_USER_DT_FUNC( AppMain.gmStartMsgDrawWindowPre_DT ), null, 0, 14U );
        AppMain.AoActSysSetDrawState( 14U );
        for ( int i = 0; i < ( int )AppMain.gm_start_msg_ama_act_num_tbl[gms_SMSG_MGR_WORK.msg_type]; i++ )
        {
            if ( gms_SMSG_MGR_WORK.ama_2d_work[i] != null )
            {
                AppMain.ObjDrawActionSummary( gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work );
            }
        }
        for ( int i = 0; i < AppMain.GMD_SMSG_AMA_ACT_ACTION_MAX; i++ )
        {
            if ( gms_SMSG_MGR_WORK.ama_2d_work_act[i] != null )
            {
                AppMain.ObjDrawActionSummary( gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work );
            }
        }
        AppMain.AoActSortExecute();
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
        AppMain.AoActSysSetDrawState( 6U );
    }

    // Token: 0x06000A98 RID: 2712 RVA: 0x0005D391 File Offset: 0x0005B591
    public static void gmStartMsgDrawWindowPre_DT( object param )
    {
        AppMain.AoActDrawPre();
    }

    // Token: 0x06000A99 RID: 2713 RVA: 0x0005D398 File Offset: 0x0005B598
    public static void gmStartMsgObjMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.gm_start_msg_end_state )
        {
            obj_work.flag |= 4U;
            obj_work.disp_flag |= 32U;
        }
    }

    // Token: 0x06000A9A RID: 2714 RVA: 0x0005D3C0 File Offset: 0x0005B5C0
    public static void gmStartMsgMain( AppMain.MTS_TASK_TCB tcb )
    {
        int num = AppMain.GsEnvGetLanguage();
        AppMain.GMS_SMSG_MGR_WORK gms_SMSG_MGR_WORK = (AppMain.GMS_SMSG_MGR_WORK)tcb.work;
        if ( gms_SMSG_MGR_WORK.func != null )
        {
            gms_SMSG_MGR_WORK.func( gms_SMSG_MGR_WORK );
        }
        if ( ( gms_SMSG_MGR_WORK.flag & AppMain.GMD_SMSG_FLAG_END ) != 0U )
        {
            AppMain.GmStartMsgExit();
            AppMain.GmPlySeqChangeFw( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
            AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].no_key_timer = 32768;
            AppMain.ObjObjectPauseOut();
            AppMain.g_gm_main_system.game_flag |= 3072U;
            return;
        }
        if ( ( gms_SMSG_MGR_WORK.flag & AppMain.GMD_SMSG_FLAG_WIN_DISP ) != 0U )
        {
            AppMain.ObjDraw3DNNUserFunc( new AppMain.OBF_DRAW_USER_DT_FUNC( AppMain.gmStartMsgDrawWindowPre_DT ), null, 0, 13U );
            AppMain.AoWinSysDrawState( 0, AppMain.AoTexGetTexList( AppMain.gm_start_msg_aos_tex[1] ), 0U, AppMain.gm_start_msg_win_size_tbl[gms_SMSG_MGR_WORK.msg_type][num][0], AppMain.gm_start_msg_win_size_tbl[gms_SMSG_MGR_WORK.msg_type][num][1], ( AppMain.gm_start_msg_win_size_tbl[gms_SMSG_MGR_WORK.msg_type][num][2] + -32f ) * gms_SMSG_MGR_WORK.win_per, ( AppMain.gm_start_msg_win_size_tbl[gms_SMSG_MGR_WORK.msg_type][num][3] + -32f ) * gms_SMSG_MGR_WORK.win_per * 0.9f - 16f, 13U );
        }
    }

    // Token: 0x06000A9B RID: 2715 RVA: 0x0005D504 File Offset: 0x0005B704
    public static void GmStartMsgInit()
    {
        int num = AppMain.GsEnvGetLanguage();
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        AppMain.g_gm_main_system.game_flag |= 16777216U;
        AppMain.gm_start_msg_end_state = false;
        AppMain.gm_start_msg_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmStartMsgMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmStartMsgDest ), 0U, 3, 18502U, 5, () => new AppMain.GMS_SMSG_MGR_WORK(), "GM_S_MSG_MGR" );
        AppMain.GMS_SMSG_MGR_WORK gms_SMSG_MGR_WORK = (AppMain.GMS_SMSG_MGR_WORK)AppMain.gm_start_msg_tcb.work;
        gms_SMSG_MGR_WORK.Clear();
        AppMain.ObjDrawSetNNCommandStateTbl( 16U, 13U, true );
        AppMain.ObjDrawSetNNCommandStateTbl( 17U, 14U, true );
        AppMain.g_obj.ppPost = new AppMain.OBJECT_Delegate( AppMain.gmStartMsgObjPost );
        ushort stage_id = AppMain.g_gs_main_sys_info.stage_id;
        if ( stage_id != 5 )
        {
            if ( stage_id == 9 )
            {
                gms_SMSG_MGR_WORK.msg_type = 1;
                goto IL_10B;
            }
            switch ( stage_id )
            {
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                    gms_SMSG_MGR_WORK.msg_type = 2;
                    goto IL_10B;
            }
        }
        gms_SMSG_MGR_WORK.msg_type = 0;
        IL_10B:
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(991);
        AppMain.NNS_TEXLIST texlist = AppMain.AoTexGetTexList(AppMain.gm_start_msg_aos_tex[0]);
        for ( int i = 0; i < ( int )AppMain.gm_start_msg_ama_act_num_tbl[gms_SMSG_MGR_WORK.msg_type]; i++ )
        {
            gms_SMSG_MGR_WORK.ama_2d_work[i] = ( AppMain.GMS_SMSG_2D_OBJ_WORK )AppMain.OBM_OBJECT_TASK_DETAIL_INIT( 18512, 5, 0, 3, () => new AppMain.GMS_SMSG_2D_OBJ_WORK(), "GM_SMSG" );
            uint num2 = (uint)i;
            if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
            {
                switch ( gms_SMSG_MGR_WORK.msg_type )
                {
                    case 1:
                        if ( num2 == 0U )
                        {
                            num2 = 2U;
                        }
                        break;
                    case 2:
                        if ( num2 == 0U )
                        {
                            num2 = 2U;
                        }
                        break;
                }
            }
            AppMain.ObjObjectAction2dAMALoadSetTexlist( gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work, gms_SMSG_MGR_WORK.ama_2d_work[i].obj_2d, null, null, num * 2, ams_AMB_HEADER, texlist, num2, 0 );
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.ppOut = null;
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmStartMsgObjMain );
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.disp_flag |= 32U;
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.flag |= 18U;
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.move_flag |= 8448U;
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.disp_flag |= 1048960U;
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.pos.x = AppMain.gm_start_msg_ama_act_pos_tbl[gms_SMSG_MGR_WORK.msg_type][num][i][0];
            gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.pos.y = AppMain.gm_start_msg_ama_act_pos_tbl[gms_SMSG_MGR_WORK.msg_type][num][i][1];
            if ( i == 0 )
            {
                gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.scale.x = AppMain.GMD_SMSG_ACT_SCALE;
                gms_SMSG_MGR_WORK.ama_2d_work[i].obj_work.scale.y = AppMain.GMD_SMSG_ACT_SCALE;
            }
        }
        for ( int i = 0; i < AppMain.GMD_SMSG_AMA_ACT_ACTION_MAX; i++ )
        {
            int num3 = AppMain.gm_start_msg_body_act_id_table[gms_SMSG_MGR_WORK.msg_type][i];
            if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) == 0U )
            {
                int num4 = num3;
                if ( num4 != -1 )
                {
                    switch ( num4 )
                    {
                        case 4:
                        case 5:
                            goto IL_366;
                        case 7:
                            num3 = 0;
                            goto IL_366;
                    }
                    num3 = -1;
                }
            }
            IL_366:
            if ( num3 < 0 )
            {
                gms_SMSG_MGR_WORK.ama_2d_work_act[i] = null;
            }
            else
            {
                gms_SMSG_MGR_WORK.ama_2d_work_act[i] = ( AppMain.GMS_SMSG_2D_OBJ_WORK )AppMain.OBM_OBJECT_TASK_DETAIL_INIT( 18512, 5, 0, 3, () => new AppMain.GMS_SMSG_2D_OBJ_WORK(), "GM_SMSG" );
                texlist = AppMain.AoTexGetTexList( AppMain.gm_start_msg_aos_tex[2] );
                AppMain.ObjObjectAction2dAMALoadSetTexlist( gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work, gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_2d, null, null, ams_AMB_HEADER.file_num - 2, ams_AMB_HEADER, texlist, ( uint )num3, 0 );
                gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work.ppOut = null;
                gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmStartMsgObjMain );
                gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work.disp_flag |= 32U;
                gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work.flag |= 18U;
                gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work.move_flag |= 8448U;
                gms_SMSG_MGR_WORK.ama_2d_work_act[i].obj_work.disp_flag |= 1048960U;
            }
        }
        gms_SMSG_MGR_WORK.func = new AppMain.pfnGMS_SMSG_MGR_WORK( AppMain.gmStartMsgMain_StartWait );
        AppMain.gmStartMsgMain_StartWait( gms_SMSG_MGR_WORK );
    }

    // Token: 0x06000A9C RID: 2716 RVA: 0x0005D9CD File Offset: 0x0005BBCD
    public static void gmStartMsgDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.UNREFERENCED_PARAMETER( tcb );
        AppMain.gm_start_msg_end_state = true;
    }

    // Token: 0x06000A9D RID: 2717 RVA: 0x0005D9DC File Offset: 0x0005BBDC
    public static void gmStartMsgMain_StartWait( AppMain.GMS_SMSG_MGR_WORK mgr_work )
    {
        if ( ( AppMain.g_gm_main_system.game_flag & 4096U ) != 0U )
        {
            return;
        }
        mgr_work.flag |= AppMain.GMD_SMSG_FLAG_WIN_DISP;
        AppMain.ObjObjectPause( 2 );
        AppMain.g_gm_main_system.game_flag &= 4294964223U;
        mgr_work.win_per = 0f;
        AppMain.GmSoundPlaySE( "Window" );
        mgr_work.timer = 0;
        mgr_work.func = new AppMain.pfnGMS_SMSG_MGR_WORK( AppMain.gmStartMsgMain_WindowOpen );
    }

    // Token: 0x06000A9E RID: 2718 RVA: 0x0005DA58 File Offset: 0x0005BC58
    public static void gmStartMsgMain_WindowOpen( AppMain.GMS_SMSG_MGR_WORK mgr_work )
    {
        mgr_work.timer++;
        if ( mgr_work.timer >= 8 )
        {
            mgr_work.win_per = 1f;
            for ( int i = 0; i < ( int )AppMain.gm_start_msg_ama_act_num_tbl[mgr_work.msg_type]; i++ )
            {
                mgr_work.ama_2d_work[i].obj_work.disp_flag &= 4294967263U;
            }
            for ( int i = 0; i < AppMain.GMD_SMSG_AMA_ACT_ACTION_MAX; i++ )
            {
                if ( mgr_work.ama_2d_work_act[i] != null )
                {
                    mgr_work.ama_2d_work_act[i].obj_work.disp_flag &= 4294967263U;
                }
            }
            mgr_work.timer = AppMain.GMD_SMSG_KEY_WAIT;
            mgr_work.func = new AppMain.pfnGMS_SMSG_MGR_WORK( AppMain.gmStartMsgMain_KeyWait );
            return;
        }
        mgr_work.win_per = ( float )mgr_work.timer / 8f;
    }

    // Token: 0x06000A9F RID: 2719 RVA: 0x0005DB24 File Offset: 0x0005BD24
    public static void gmStartMsgMain_KeyWait( AppMain.GMS_SMSG_MGR_WORK mgr_work )
    {
        if ( mgr_work.timer != 0 )
        {
            mgr_work.timer--;
            return;
        }
        if ( AppMain.amTpIsTouchOn( 0 ) )
        {
            for ( int i = 0; i < ( int )AppMain.gm_start_msg_ama_act_num_tbl[mgr_work.msg_type]; i++ )
            {
                mgr_work.ama_2d_work[i].obj_work.disp_flag |= 32U;
            }
            for ( int i = 0; i < AppMain.GMD_SMSG_AMA_ACT_ACTION_MAX; i++ )
            {
                if ( mgr_work.ama_2d_work_act[i] != null )
                {
                    mgr_work.ama_2d_work_act[i].obj_work.disp_flag |= 32U;
                }
            }
            mgr_work.timer = 8;
            mgr_work.func = new AppMain.pfnGMS_SMSG_MGR_WORK( AppMain.gmStartMsgMain_WindowClose );
        }
    }

    // Token: 0x06000AA0 RID: 2720 RVA: 0x0005DBD4 File Offset: 0x0005BDD4
    public static void gmStartMsgMain_WindowClose( AppMain.GMS_SMSG_MGR_WORK mgr_work )
    {
        mgr_work.timer--;
        if ( mgr_work.timer <= 0 )
        {
            mgr_work.win_per = 0f;
            mgr_work.func = null;
            mgr_work.flag |= AppMain.GMD_SMSG_FLAG_END;
            return;
        }
        mgr_work.win_per = ( float )mgr_work.timer / 8f;
    }
}