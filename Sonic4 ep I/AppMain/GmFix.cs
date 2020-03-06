using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000184 RID: 388
    public class GMS_FIX_PART_WORK
    {
        // Token: 0x060021A2 RID: 8610 RVA: 0x00141632 File Offset: 0x0013F832
        public GMS_FIX_PART_WORK( object _holder )
        {
            this.holder = _holder;
        }

        // Token: 0x060021A3 RID: 8611 RVA: 0x00141641 File Offset: 0x0013F841
        public GMS_FIX_PART_WORK()
        {
        }

        // Token: 0x060021A4 RID: 8612 RVA: 0x00141649 File Offset: 0x0013F849
        public static explicit operator AppMain.GMS_FIX_PART_VIRTUAL_PAD( AppMain.GMS_FIX_PART_WORK p )
        {
            return ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )p.holder;
        }

        // Token: 0x060021A5 RID: 8613 RVA: 0x00141656 File Offset: 0x0013F856
        public static explicit operator AppMain.GMS_FIX_PART_SCORE( AppMain.GMS_FIX_PART_WORK p )
        {
            return ( AppMain.GMS_FIX_PART_SCORE )p.holder;
        }

        // Token: 0x060021A6 RID: 8614 RVA: 0x00141663 File Offset: 0x0013F863
        public static explicit operator AppMain.GMS_FIX_PART_TIMER( AppMain.GMS_FIX_PART_WORK p )
        {
            return ( AppMain.GMS_FIX_PART_TIMER )p.holder;
        }

        // Token: 0x060021A7 RID: 8615 RVA: 0x00141670 File Offset: 0x0013F870
        public static explicit operator AppMain.GMS_FIX_PART_RINGCOUNT( AppMain.GMS_FIX_PART_WORK p )
        {
            return ( AppMain.GMS_FIX_PART_RINGCOUNT )p.holder;
        }

        // Token: 0x060021A8 RID: 8616 RVA: 0x0014167D File Offset: 0x0013F87D
        public static explicit operator AppMain.GMS_FIX_PART_CHALLENGE( AppMain.GMS_FIX_PART_WORK p )
        {
            return ( AppMain.GMS_FIX_PART_CHALLENGE )p.holder;
        }

        // Token: 0x060021A9 RID: 8617 RVA: 0x0014168A File Offset: 0x0013F88A
        public static explicit operator AppMain.GMS_FIX_MGR_WORK( AppMain.GMS_FIX_PART_WORK p )
        {
            return p.parent_mgr;
        }

        // Token: 0x060021AA RID: 8618 RVA: 0x00141694 File Offset: 0x0013F894
        public void Clear()
        {
            this.parent_mgr = null;
            this.part_type = 0;
            this.flag = 0U;
            this.blink_timer = ( this.blink_on_time = ( this.blink_off_time = 0U ) );
            this.proc_update = ( this.proc_disp = null );
        }

        // Token: 0x04004EC1 RID: 20161
        public readonly object holder;

        // Token: 0x04004EC2 RID: 20162
        public AppMain.GMS_FIX_MGR_WORK parent_mgr;

        // Token: 0x04004EC3 RID: 20163
        public int part_type;

        // Token: 0x04004EC4 RID: 20164
        public uint flag;

        // Token: 0x04004EC5 RID: 20165
        public uint blink_timer;

        // Token: 0x04004EC6 RID: 20166
        public uint blink_on_time;

        // Token: 0x04004EC7 RID: 20167
        public uint blink_off_time;

        // Token: 0x04004EC8 RID: 20168
        public AppMain.MPP_VOID_GMS_FIX_PART_WORK proc_update;

        // Token: 0x04004EC9 RID: 20169
        public AppMain.MPP_VOID_GMS_FIX_PART_WORK proc_disp;
    }

    // Token: 0x02000185 RID: 389
    public class GMS_FIX_PART_RINGCOUNT
    {
        // Token: 0x060021AB RID: 8619 RVA: 0x001416DF File Offset: 0x0013F8DF
        public static explicit operator AppMain.GMS_FIX_PART_WORK( AppMain.GMS_FIX_PART_RINGCOUNT pObj )
        {
            return pObj.part_work;
        }

        // Token: 0x060021AC RID: 8620 RVA: 0x001416E7 File Offset: 0x0013F8E7
        public GMS_FIX_PART_RINGCOUNT()
        {
            this.part_work = new AppMain.GMS_FIX_PART_WORK( this );
        }

        // Token: 0x060021AD RID: 8621 RVA: 0x00141713 File Offset: 0x0013F913
        public void Clear()
        {
            this.part_work.Clear();
            Array.Clear( this.sub_parts, 0, this.sub_parts.Length );
            Array.Clear( this.digit_list, 0, this.digit_list.Length );
        }

        // Token: 0x04004ECA RID: 20170
        public readonly AppMain.GMS_FIX_PART_WORK part_work;

        // Token: 0x04004ECB RID: 20171
        public AppMain.GMS_COCKPIT_2D_WORK[] sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[4];

        // Token: 0x04004ECC RID: 20172
        public int[] digit_list = new int[3];
    }

    // Token: 0x02000186 RID: 390
    public class GMS_FIX_PART_SCORE
    {
        // Token: 0x060021AE RID: 8622 RVA: 0x00141748 File Offset: 0x0013F948
        public GMS_FIX_PART_SCORE()
        {
            this.part_work = new AppMain.GMS_FIX_PART_WORK( this );
        }

        // Token: 0x060021AF RID: 8623 RVA: 0x00141776 File Offset: 0x0013F976
        public void Clear()
        {
            this.part_work.Clear();
            Array.Clear( this.sub_parts, 0, this.sub_parts.Length );
            Array.Clear( this.digit_list, 0, this.digit_list.Length );
        }

        // Token: 0x060021B0 RID: 8624 RVA: 0x001417AB File Offset: 0x0013F9AB
        public static explicit operator AppMain.GMS_FIX_PART_WORK( AppMain.GMS_FIX_PART_SCORE pScore )
        {
            return pScore.part_work;
        }

        // Token: 0x04004ECD RID: 20173
        public readonly AppMain.GMS_FIX_PART_WORK part_work;

        // Token: 0x04004ECE RID: 20174
        public AppMain.GMS_COCKPIT_2D_WORK[] sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[10];

        // Token: 0x04004ECF RID: 20175
        public int[] digit_list = new int[9];
    }

    // Token: 0x02000187 RID: 391
    public class GMS_FIX_PART_TIMER
    {
        // Token: 0x060021B1 RID: 8625 RVA: 0x001417B3 File Offset: 0x0013F9B3
        public GMS_FIX_PART_TIMER()
        {
            this.part_work = new AppMain.GMS_FIX_PART_WORK( this );
        }

        // Token: 0x060021B2 RID: 8626 RVA: 0x001417EC File Offset: 0x0013F9EC
        public static explicit operator AppMain.GMS_FIX_PART_WORK( AppMain.GMS_FIX_PART_TIMER p )
        {
            return p.part_work;
        }

        // Token: 0x060021B3 RID: 8627 RVA: 0x001417F4 File Offset: 0x0013F9F4
        public void Clear()
        {
            this.part_work.Clear();
            Array.Clear( this.sub_parts, 0, this.sub_parts.Length );
            this.flag = 0U;
            Array.Clear( this.digit_list, 0, this.digit_list.Length );
            this.digit_frame_ofst = ( this.deco_char_frame_ofst = 0f );
            this.cur_sec = 0;
            this.reserved[0] = 0;
            this.fade_ratio = ( this.scale_ratio = 0f );
            this.flash_act_phase = 0U;
        }

        // Token: 0x04004ED0 RID: 20176
        public readonly AppMain.GMS_FIX_PART_WORK part_work;

        // Token: 0x04004ED1 RID: 20177
        public AppMain.GMS_COCKPIT_2D_WORK[] sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[8];

        // Token: 0x04004ED2 RID: 20178
        public uint flag;

        // Token: 0x04004ED3 RID: 20179
        public int[] digit_list = new int[5];

        // Token: 0x04004ED4 RID: 20180
        public float digit_frame_ofst;

        // Token: 0x04004ED5 RID: 20181
        public float deco_char_frame_ofst;

        // Token: 0x04004ED6 RID: 20182
        public ushort cur_sec;

        // Token: 0x04004ED7 RID: 20183
        public ushort[] reserved = new ushort[1];

        // Token: 0x04004ED8 RID: 20184
        public float fade_ratio;

        // Token: 0x04004ED9 RID: 20185
        public float scale_ratio;

        // Token: 0x04004EDA RID: 20186
        public uint flash_act_phase;
    }

    // Token: 0x02000188 RID: 392
    public class GMS_FIX_PART_CHALLENGE
    {
        // Token: 0x060021B4 RID: 8628 RVA: 0x0014187A File Offset: 0x0013FA7A
        public GMS_FIX_PART_CHALLENGE()
        {
            this.part_work = new AppMain.GMS_FIX_PART_WORK( this );
        }

        // Token: 0x060021B5 RID: 8629 RVA: 0x001418A6 File Offset: 0x0013FAA6
        public static explicit operator AppMain.GMS_FIX_PART_WORK( AppMain.GMS_FIX_PART_CHALLENGE p )
        {
            return p.part_work;
        }

        // Token: 0x060021B6 RID: 8630 RVA: 0x001418AE File Offset: 0x0013FAAE
        public void Clear()
        {
            this.part_work.Clear();
            Array.Clear( this.sub_parts, 0, this.sub_parts.Length );
            Array.Clear( this.digit_list, 0, this.digit_list.Length );
        }

        // Token: 0x04004EDB RID: 20187
        public AppMain.GMS_FIX_PART_WORK part_work;

        // Token: 0x04004EDC RID: 20188
        public AppMain.GMS_COCKPIT_2D_WORK[] sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[5];

        // Token: 0x04004EDD RID: 20189
        public int[] digit_list = new int[3];
    }

    // Token: 0x02000189 RID: 393
    public class GMS_FIX_PART_VIRTUAL_PAD
    {
        // Token: 0x060021B7 RID: 8631 RVA: 0x001418E3 File Offset: 0x0013FAE3
        public GMS_FIX_PART_VIRTUAL_PAD()
        {
            this.part_work = new AppMain.GMS_FIX_PART_WORK( this );
        }

        // Token: 0x060021B8 RID: 8632 RVA: 0x0014190F File Offset: 0x0013FB0F
        public static explicit operator AppMain.GMS_FIX_PART_WORK( AppMain.GMS_FIX_PART_VIRTUAL_PAD p )
        {
            return p.part_work;
        }

        // Token: 0x060021B9 RID: 8633 RVA: 0x00141918 File Offset: 0x0013FB18
        public void Clear()
        {
            this.part_work.Clear();
            this.pause_icon_frame[0] = ( this.pause_icon_frame[1] = 0f );
            Array.Clear( this.sub_parts, 0, this.sub_parts.Length );
        }

        // Token: 0x04004EDE RID: 20190
        public AppMain.GMS_FIX_PART_WORK part_work;

        // Token: 0x04004EDF RID: 20191
        public AppMain.GMS_COCKPIT_2D_WORK[] sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[4];

        // Token: 0x04004EE0 RID: 20192
        public float[] pause_icon_frame = new float[2];
    }

    // Token: 0x0200018A RID: 394
    public class GMS_FIX_MGR_WORK
    {
        // Token: 0x060021BA RID: 8634 RVA: 0x0014195C File Offset: 0x0013FB5C
        public GMS_FIX_MGR_WORK()
        {
        }

        // Token: 0x060021BB RID: 8635 RVA: 0x001419B4 File Offset: 0x0013FBB4
        public GMS_FIX_MGR_WORK( AppMain.GMS_FIX_PART_WORK holder )
        {
            this.holder = holder;
        }

        // Token: 0x060021BC RID: 8636 RVA: 0x00141A14 File Offset: 0x0013FC14
        public void Clear()
        {
            this.flag = ( this.req_flag = 0U );
            this.proc_update = null;
            Array.Clear( this.part_work, 0, 5 );
            this.part_ringcount.Clear();
            this.part_score.Clear();
            this.part_timer.Clear();
            this.part_challenge.Clear();
            this.part_virtual_pad.Clear();
        }

        // Token: 0x060021BD RID: 8637 RVA: 0x00141A7C File Offset: 0x0013FC7C
        public static explicit operator AppMain.GMS_FIX_PART_WORK( AppMain.GMS_FIX_MGR_WORK p )
        {
            return ( AppMain.GMS_FIX_PART_WORK )p.holder;
        }

        // Token: 0x04004EE1 RID: 20193
        public uint flag;

        // Token: 0x04004EE2 RID: 20194
        public uint req_flag;

        // Token: 0x04004EE3 RID: 20195
        public AppMain.MPP_VOID_GMS_FIX_PART_WORK proc_update;

        // Token: 0x04004EE4 RID: 20196
        public AppMain.GMS_FIX_PART_WORK[] part_work = new AppMain.GMS_FIX_PART_WORK[5];

        // Token: 0x04004EE5 RID: 20197
        public AppMain.GMS_FIX_PART_RINGCOUNT part_ringcount = new AppMain.GMS_FIX_PART_RINGCOUNT();

        // Token: 0x04004EE6 RID: 20198
        public AppMain.GMS_FIX_PART_SCORE part_score = new AppMain.GMS_FIX_PART_SCORE();

        // Token: 0x04004EE7 RID: 20199
        public AppMain.GMS_FIX_PART_TIMER part_timer = new AppMain.GMS_FIX_PART_TIMER();

        // Token: 0x04004EE8 RID: 20200
        public AppMain.GMS_FIX_PART_CHALLENGE part_challenge = new AppMain.GMS_FIX_PART_CHALLENGE();

        // Token: 0x04004EE9 RID: 20201
        public AppMain.GMS_FIX_PART_VIRTUAL_PAD part_virtual_pad = new AppMain.GMS_FIX_PART_VIRTUAL_PAD();

        // Token: 0x04004EEA RID: 20202
        public readonly object holder;
    }

    // Token: 0x0200018B RID: 395
    private class gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_SUPER_SONIC
    {
        // Token: 0x060021BE RID: 8638 RVA: 0x00141A8C File Offset: 0x0013FC8C
        public static void OutFunc( AppMain.OBS_OBJECT_WORK obj_work )
        {
            if ( AppMain.gm_fix_tcb != null )
            {
                AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
                if ( ( 512U & gms_FIX_MGR_WORK.flag ) == 0U )
                {
                    AppMain.ObjDrawActionSummary( obj_work );
                }
            }
        }
    }

    // Token: 0x0200018C RID: 396
    private class gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_PAUSE
    {
        // Token: 0x060021C0 RID: 8640 RVA: 0x00141ACC File Offset: 0x0013FCCC
        public static void OutFunc( AppMain.OBS_OBJECT_WORK obj_work )
        {
            if ( AppMain.gm_fix_tcb != null )
            {
                AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
                if ( ( 1024U & gms_FIX_MGR_WORK.flag ) == 0U )
                {
                    AppMain.ObjDrawActionSummary( obj_work );
                }
            }
        }
    }

    // Token: 0x0200018D RID: 397
    private class gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_ACTION
    {
        // Token: 0x060021C2 RID: 8642 RVA: 0x00141B0C File Offset: 0x0013FD0C
        public static void OutFunc( AppMain.OBS_OBJECT_WORK obj_work )
        {
            if ( AppMain.gm_fix_tcb != null )
            {
                AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
                if ( ( 2048U & gms_FIX_MGR_WORK.flag ) == 0U )
                {
                    AppMain.ObjDrawActionSummary( obj_work );
                }
            }
        }
    }

    // Token: 0x0200018E RID: 398
    private class gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_MOVE_PAD
    {
        // Token: 0x060021C4 RID: 8644 RVA: 0x00141B4C File Offset: 0x0013FD4C
        public static void OutFunc( AppMain.OBS_OBJECT_WORK obj_work )
        {
            if ( AppMain.gm_fix_tcb != null )
            {
                AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
                if ( ( 4096U & gms_FIX_MGR_WORK.flag ) == 0U )
                {
                    AppMain.ObjDrawActionSummary( obj_work );
                }
            }
        }
    }

    // Token: 0x0200018F RID: 399
    private struct SKeyToFrame
    {
        // Token: 0x04004EEB RID: 20203
        public int key;

        // Token: 0x04004EEC RID: 20204
        public float frame;
    }

    // Token: 0x060006A0 RID: 1696 RVA: 0x0003C088 File Offset: 0x0003A288
    private static void GmFixBuildDataInit()
    {
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.gm_fix_textures[i].Clear();
        }
        for ( int j = 0; j < 3; j++ )
        {
            AppMain.gm_fix_texamb_list[j] = AppMain.ObjDataLoadAmbIndex( null, AppMain.gm_fix_tex_amb_idx_tbl[AppMain.GsEnvGetLanguage()][j], AppMain.GmGameDatGetCockpitData() );
            AppMain.AoTexBuild( AppMain.gm_fix_textures[j], ( AppMain.AMS_AMB_HEADER )AppMain.gm_fix_texamb_list[j] );
            AppMain.AoTexLoad( AppMain.gm_fix_textures[j] );
        }
    }

    // Token: 0x060006A1 RID: 1697 RVA: 0x0003C0FC File Offset: 0x0003A2FC
    private static bool GmFixBuildDataLoop()
    {
        bool result = true;
        for ( int i = 0; i < 3; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( AppMain.gm_fix_textures[i] ) )
            {
                result = false;
            }
        }
        return result;
    }

    // Token: 0x060006A2 RID: 1698 RVA: 0x0003C128 File Offset: 0x0003A328
    private static void GmFixFlushDataInit()
    {
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.AoTexRelease( AppMain.gm_fix_textures[i] );
        }
    }

    // Token: 0x060006A3 RID: 1699 RVA: 0x0003C150 File Offset: 0x0003A350
    private static bool GmFixFlushDataLoop()
    {
        bool result = true;
        for ( int i = 0; i < 3; i++ )
        {
            if ( AppMain.gm_fix_texamb_list[i] != null )
            {
                if ( !AppMain.AoTexIsReleased( AppMain.gm_fix_textures[i] ) )
                {
                    result = false;
                }
                else
                {
                    AppMain.gm_fix_texamb_list[i] = null;
                    AppMain.gm_fix_textures[i].Clear();
                }
            }
        }
        return result;
    }

    // Token: 0x060006A4 RID: 1700 RVA: 0x0003C1A4 File Offset: 0x0003A3A4
    private static void GmFixInit()
    {
        AppMain.gm_fix_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmFixProcMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmFixDest ), 0U, 0, 18432U, 5, () => new AppMain.GMS_FIX_MGR_WORK(), "GM_FIX_MGR" );
        AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
        gms_FIX_MGR_WORK.Clear();
        AppMain.GMF_FIX_PART_INIT_FUNC[] array;
        if ( AppMain.gmFixIsSpecialStage() )
        {
            array = AppMain.gm_fix_ss_part_init_func_tbl;
            gms_FIX_MGR_WORK.flag |= 4U;
        }
        else if ( AppMain.gmFixIsTimeAttack() )
        {
            if ( AppMain.gmFixIsStage22() )
            {
                array = AppMain.gm_fix_ta_s22_part_init_func_tbl;
            }
            else
            {
                array = AppMain.gm_fix_ta_part_init_func_tbl;
            }
        }
        else
        {
            array = AppMain.gm_fix_part_init_func_tbl;
        }
        for ( int i = 0; i < 5; i++ )
        {
            if ( array[i] != null )
            {
                array[i]( gms_FIX_MGR_WORK );
            }
        }
        gms_FIX_MGR_WORK.proc_update = null;
    }

    // Token: 0x060006A5 RID: 1701 RVA: 0x0003C275 File Offset: 0x0003A475
    private static void GmFixExit()
    {
        if ( AppMain.gm_fix_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_fix_tcb );
            AppMain.gm_fix_tcb = null;
        }
    }

    // Token: 0x060006A6 RID: 1702 RVA: 0x0003C28E File Offset: 0x0003A48E
    private static void GmFixSetDisp( bool enable )
    {
        AppMain.GmFixSetDispEx( enable, enable, enable, enable, enable );
    }

    // Token: 0x060006A7 RID: 1703 RVA: 0x0003C29C File Offset: 0x0003A49C
    private static void GmFixSetDispEx( bool enable, bool enable_ss, bool enable_pause, bool enable_action, bool enable_move )
    {
        if ( AppMain.gm_fix_tcb != null )
        {
            AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
            if ( gms_FIX_MGR_WORK != null )
            {
                int num = (enable ? 2 : 0) | (enable_ss ? 512 : 0) | (enable_pause ? 1024 : 0) | (enable_action ? 2048 : 0) | (enable_move ? 4096 : 0);
                int num2 = (enable ? 0 : 2) | (enable_ss ? 0 : 512) | (enable_pause ? 0 : 1024) | (enable_action ? 0 : 2048) | (enable_move ? 0 : 4096);
                gms_FIX_MGR_WORK.flag &= ( uint )( ~( uint )num );
                gms_FIX_MGR_WORK.flag |= ( uint )num2;
            }
        }
    }

    // Token: 0x060006A8 RID: 1704 RVA: 0x0003C358 File Offset: 0x0003A558
    private static bool GmFixIsDisp()
    {
        if ( AppMain.gm_fix_tcb != null )
        {
            AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
            if ( gms_FIX_MGR_WORK != null && ( gms_FIX_MGR_WORK.flag & 2U ) == 0U )
            {
                return true;
            }
        }
        return false;
    }

    // Token: 0x060006A9 RID: 1705 RVA: 0x0003C38C File Offset: 0x0003A58C
    private static void GmFixRequestTimerFlash()
    {
        if ( AppMain.gm_fix_tcb != null )
        {
            AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
            if ( gms_FIX_MGR_WORK != null )
            {
                gms_FIX_MGR_WORK.req_flag |= 1U;
            }
        }
    }

    // Token: 0x060006AA RID: 1706 RVA: 0x0003C3C4 File Offset: 0x0003A5C4
    private static void gmFixSubpartOutFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.gm_fix_tcb == null )
        {
            return;
        }
        AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)AppMain.gm_fix_tcb.work;
        if ( ( gms_FIX_MGR_WORK.flag & 2U ) == 0U )
        {
            AppMain.ObjDrawActionSummary( obj_work );
        }
    }

    // Token: 0x060006AB RID: 1707 RVA: 0x0003C3F9 File Offset: 0x0003A5F9
    private static void gmFixSetFrameStatic( AppMain.OBS_OBJECT_WORK obj_work, float frame )
    {
        obj_work.obj_2d.frame = frame;
        obj_work.obj_2d.speed = 0f;
    }

    // Token: 0x060006AC RID: 1708 RVA: 0x0003C418 File Offset: 0x0003A618
    private static void gmFixUpdatePart( AppMain.GMS_FIX_PART_WORK part_work )
    {
        if ( ( part_work.flag & 1U ) == 0U )
        {
            return;
        }
        if ( AppMain.gmFixCheckClear( part_work ) )
        {
            AppMain.gmFixUnregisterPart( part_work );
            return;
        }
        if ( part_work.proc_update != null )
        {
            part_work.proc_update( part_work );
        }
        if ( part_work.proc_disp != null && ( part_work.flag & 2U ) == 0U )
        {
            part_work.proc_disp( part_work );
        }
    }

    // Token: 0x060006AD RID: 1709 RVA: 0x0003C471 File Offset: 0x0003A671
    private static bool gmFixCheckClear( AppMain.GMS_FIX_PART_WORK part_work )
    {
        return AppMain.gm_fix_tcb == null || part_work.parent_mgr == null || ( part_work.parent_mgr.flag & 1U ) != 0U;
    }

    // Token: 0x060006AE RID: 1710 RVA: 0x0003C498 File Offset: 0x0003A698
    private static bool gmFixIsSpecialStage()
    {
        switch ( AppMain.GsGetMainSysInfo().stage_id )
        {
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
                return true;
            default:
                return false;
        }
    }

    // Token: 0x060006AF RID: 1711 RVA: 0x0003C4DA File Offset: 0x0003A6DA
    private static bool gmFixIsTimeAttack()
    {
        return AppMain.GsGetMainSysInfo().game_mode == 1;
    }

    // Token: 0x060006B0 RID: 1712 RVA: 0x0003C4EC File Offset: 0x0003A6EC
    private static bool gmFixIsStage22()
    {
        ushort stage_id = AppMain.GsGetMainSysInfo().stage_id;
        return stage_id == 5;
    }

    // Token: 0x060006B1 RID: 1713 RVA: 0x0003C50C File Offset: 0x0003A70C
    private static bool gmFixIsStageTruck()
    {
        ushort stage_id = AppMain.GsGetMainSysInfo().stage_id;
        return stage_id == 9;
    }

    // Token: 0x060006B2 RID: 1714 RVA: 0x0003C52C File Offset: 0x0003A72C
    private static int gmFixGetPlan()
    {
        int result = 0;
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( AppMain.gmFixIsStageTruck() )
        {
            if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
            {
                result = 1;
            }
        }
        else if ( AppMain.gmFixIsSpecialStage() )
        {
            if ( ( 512U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
            {
                result = 1;
            }
        }
        else if ( ( 1U & gss_MAIN_SYS_INFO.game_flag ) != 0U )
        {
            result = 2;
        }
        return result;
    }

    // Token: 0x060006B3 RID: 1715 RVA: 0x0003C580 File Offset: 0x0003A780
    private static short gmFixGetRingNum()
    {
        if ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] != null )
        {
            return AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].ring_num;
        }
        return 0;
    }

    // Token: 0x060006B4 RID: 1716 RVA: 0x0003C5A5 File Offset: 0x0003A7A5
    private static uint gmFixGetScore()
    {
        if ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] != null )
        {
            return AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].score;
        }
        return 0U;
    }

    // Token: 0x060006B5 RID: 1717 RVA: 0x0003C5CA File Offset: 0x0003A7CA
    private static uint gmFixGetGameTime()
    {
        if ( AppMain.g_gm_main_system.game_time >= 35999U )
        {
            return 35999U;
        }
        return AppMain.g_gm_main_system.game_time;
    }

    // Token: 0x060006B6 RID: 1718 RVA: 0x0003C5F0 File Offset: 0x0003A7F0
    private static uint gmFixGetChallengeNum()
    {
        uint a = 0U;
        if ( AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] > 0U )
        {
            a = AppMain.g_gm_main_system.player_rest_num[( int )( ( UIntPtr )0 )] - 1U;
        }
        return ( uint )AppMain.MTM_MATH_CLIP( ( int )a, 0, 999 );
    }

    // Token: 0x060006B7 RID: 1719 RVA: 0x0003C62D File Offset: 0x0003A82D
    private static void gmFixInitBlink( AppMain.GMS_FIX_PART_WORK part_work, uint on_time, uint off_time )
    {
        part_work.blink_timer = on_time + off_time;
        part_work.blink_on_time = on_time;
        part_work.blink_off_time = off_time;
    }

    // Token: 0x060006B8 RID: 1720 RVA: 0x0003C648 File Offset: 0x0003A848
    private static bool gmFixUpdateBlink( AppMain.GMS_FIX_PART_WORK part_work )
    {
        if ( part_work.blink_timer != 0U )
        {
            part_work.blink_timer -= 1U;
        }
        bool result = part_work.blink_timer >= part_work.blink_off_time;
        if ( part_work.blink_timer == 0U )
        {
            part_work.blink_timer = part_work.blink_on_time + part_work.blink_off_time;
        }
        return result;
    }

    // Token: 0x060006B9 RID: 1721 RVA: 0x0003C69D File Offset: 0x0003A89D
    private static void gmFixDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x060006BA RID: 1722 RVA: 0x0003C6A0 File Offset: 0x0003A8A0
    private static void gmFixProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_FIX_MGR_WORK gms_FIX_MGR_WORK = (AppMain.GMS_FIX_MGR_WORK)tcb.work;
        if ( gms_FIX_MGR_WORK.proc_update != null )
        {
            AppMain.mppAssertNotImpl();
        }
        for ( int i = 0; i < 5; i++ )
        {
            if ( gms_FIX_MGR_WORK.part_work[i] != null )
            {
                AppMain.gmFixUpdatePart( gms_FIX_MGR_WORK.part_work[i] );
            }
        }
    }

    // Token: 0x060006BB RID: 1723 RVA: 0x0003C6E9 File Offset: 0x0003A8E9
    private static void gmFixRegisterPart( AppMain.GMS_FIX_MGR_WORK mgr_work, AppMain.GMS_FIX_PART_WORK part_work, int part_type )
    {
        mgr_work.part_work[part_type] = part_work;
        part_work.part_type = part_type;
        part_work.parent_mgr = mgr_work;
        part_work.flag |= 1U;
    }

    // Token: 0x060006BC RID: 1724 RVA: 0x0003C710 File Offset: 0x0003A910
    private static void gmFixUnregisterPart( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_MGR_WORK parent_mgr = part_work.parent_mgr;
        if ( parent_mgr != null )
        {
            parent_mgr.part_work[part_work.part_type] = null;
        }
        part_work.part_type = -1;
        part_work.parent_mgr = null;
        part_work.flag &= 4294967294U;
    }

    // Token: 0x060006BD RID: 1725 RVA: 0x0003C752 File Offset: 0x0003A952
    private static bool gmFixProcessRequest( AppMain.GMS_FIX_MGR_WORK mgr_work, uint req_flag_bit )
    {
        if ( ( mgr_work.req_flag & req_flag_bit ) != 0U )
        {
            mgr_work.req_flag &= ~req_flag_bit;
            return true;
        }
        return false;
    }

    // Token: 0x060006BE RID: 1726 RVA: 0x0003C778 File Offset: 0x0003A978
    private static void gmFixRingCountPartInit( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        AppMain.GMS_FIX_PART_WORK gms_FIX_PART_WORK = (AppMain.GMS_FIX_PART_WORK)mgr_work.part_ringcount;
        AppMain.gmFixRegisterPart( mgr_work, gms_FIX_PART_WORK, 0 );
        gms_FIX_PART_WORK.proc_update = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixRingCountPartProcUpdateMain );
        gms_FIX_PART_WORK.proc_disp = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixRingCountPartProcDispMain );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "FIX_RING");
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmFixSubpartOutFunc );
            AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_fix_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][0], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_fix_textures[0] ), ( uint )AppMain.gm_fix_ringcount_act_id_tbl[i], 0 );
            AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK, 0f );
            if ( i != 0 )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + AppMain.FX_F32_TO_FX32( 5f );
            }
            ( ( AppMain.GMS_FIX_PART_RINGCOUNT )gms_FIX_PART_WORK ).sub_parts[i] = ( AppMain.GMS_COCKPIT_2D_WORK )obs_OBJECT_WORK;
        }
    }

    // Token: 0x060006BF RID: 1727 RVA: 0x0003C884 File Offset: 0x0003AA84
    private static void gmFixRingCountPartProcUpdateMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_RINGCOUNT part_ringcount = (AppMain.GMS_FIX_PART_RINGCOUNT)part_work;
        AppMain.gmFixRingCountPartUpdateDigitList( part_ringcount );
        if ( AppMain.gmFixGetRingNum() == 0 )
        {
            if ( ( part_work.flag & 4U ) == 0U )
            {
                part_work.flag |= 4U;
                AppMain.gmFixInitBlink( part_work, 10U, 10U );
                return;
            }
        }
        else
        {
            part_work.flag &= 4294967291U;
        }
    }

    // Token: 0x060006C0 RID: 1728 RVA: 0x0003C8D8 File Offset: 0x0003AAD8
    private static void gmFixRingCountPartProcDispMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_RINGCOUNT part_ringcount = (AppMain.GMS_FIX_PART_RINGCOUNT)part_work;
        if ( ( part_work.flag & 4U ) != 0U )
        {
            if ( AppMain.gmFixUpdateBlink( part_work ) )
            {
                part_work.flag &= 4294967287U;
            }
            else
            {
                part_work.flag |= 8U;
            }
        }
        else
        {
            part_work.flag &= 4294967287U;
        }
        if ( ( part_work.flag & 8U ) != 0U )
        {
            AppMain.gmFixRingCountPartSetDispDigits( part_ringcount, false );
        }
        else
        {
            AppMain.gmFixRingCountPartSetDispDigits( part_ringcount, true );
        }
        AppMain.gmFixRingCountPartUpdateActionDigitsType( part_ringcount );
    }

    // Token: 0x060006C1 RID: 1729 RVA: 0x0003C950 File Offset: 0x0003AB50
    private static void gmFixRingCountPartUpdateDigitList( AppMain.GMS_FIX_PART_RINGCOUNT part_ringcount )
    {
        int num = (int)AppMain.gmFixGetRingNum();
        AppMain.AkUtilNumValueToDigits( num, part_ringcount.digit_list, 3 );
        if ( num == 0 )
        {
            for ( int i = 0; i < 3; i++ )
            {
                part_ringcount.digit_list[i] = 10;
            }
        }
    }

    // Token: 0x060006C2 RID: 1730 RVA: 0x0003C98C File Offset: 0x0003AB8C
    private static void gmFixRingCountPartUpdateActionDigitsType( AppMain.GMS_FIX_PART_RINGCOUNT part_ringcount )
    {
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.GMS_COCKPIT_2D_WORK work = part_ringcount.sub_parts[AppMain.gm_fix_part_ring_count_digit_subpart_idx_tbl[i]];
            AppMain.gmFixSetFrameStatic( ( AppMain.OBS_OBJECT_WORK )work, AppMain.gm_fix_part_ring_count_digit_type_frame_tbl[part_ringcount.digit_list[i]] );
        }
    }

    // Token: 0x060006C3 RID: 1731 RVA: 0x0003C9D0 File Offset: 0x0003ABD0
    private static void gmFixRingCountPartSetDispDigits( AppMain.GMS_FIX_PART_RINGCOUNT part_ringcount, bool enable )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( i != 0 )
            {
                if ( enable )
                {
                    ( ( AppMain.OBS_OBJECT_WORK )part_ringcount.sub_parts[i] ).disp_flag &= 4294967263U;
                }
                else
                {
                    ( ( AppMain.OBS_OBJECT_WORK )part_ringcount.sub_parts[i] ).disp_flag |= 32U;
                }
            }
        }
    }

    // Token: 0x060006C4 RID: 1732 RVA: 0x0003CA30 File Offset: 0x0003AC30
    private static void gmFixScorePartInit( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        int num = 0;
        AppMain.GMS_FIX_PART_WORK gms_FIX_PART_WORK = (AppMain.GMS_FIX_PART_WORK)mgr_work.part_score;
        AppMain.gmFixRegisterPart( mgr_work, gms_FIX_PART_WORK, 1 );
        gms_FIX_PART_WORK.proc_update = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixScorePartProcUpdateMain );
        gms_FIX_PART_WORK.proc_disp = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixScorePartProcDispMain );
        if ( AppMain.gmFixIsStage22() )
        {
            AppMain.act_id_tblgmFixScorePartInit = AppMain.gm_fix_score_stage22_act_id_tbl[AppMain.gmFixGetPlan()];
        }
        else
        {
            AppMain.act_id_tblgmFixScorePartInit = AppMain.gm_fix_score_act_id_tbl;
            num = 0;
        }
        for ( int i = 0; i < 10; i++ )
        {
            if ( AppMain.act_id_tblgmFixScorePartInit[i] < 0 )
            {
                ( ( AppMain.GMS_FIX_PART_SCORE )gms_FIX_PART_WORK ).sub_parts[i] = null;
            }
            else
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "FIX_SCORE");
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
                obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmFixSubpartOutFunc );
                AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_fix_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][0], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_fix_textures[0] ), ( uint )AppMain.act_id_tblgmFixScorePartInit[i], 0 );
                AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK, 0f );
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + num;
                if ( i != 0 )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + AppMain.FX_F32_TO_FX32( 2f );
                }
                ( ( AppMain.GMS_FIX_PART_SCORE )gms_FIX_PART_WORK ).sub_parts[i] = ( AppMain.GMS_COCKPIT_2D_WORK )obs_OBJECT_WORK;
            }
        }
    }

    // Token: 0x060006C5 RID: 1733 RVA: 0x0003CB9C File Offset: 0x0003AD9C
    private static void gmFixScorePartProcUpdateMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_SCORE part_score = (AppMain.GMS_FIX_PART_SCORE)part_work;
        AppMain.gmFixScorePartUpdateDigitList( part_score );
    }

    // Token: 0x060006C6 RID: 1734 RVA: 0x0003CBB8 File Offset: 0x0003ADB8
    private static void gmFixScorePartProcDispMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_SCORE part_score = (AppMain.GMS_FIX_PART_SCORE)part_work;
        AppMain.gmFixScorePartUpdateActionDigitsType( part_score );
    }

    // Token: 0x060006C7 RID: 1735 RVA: 0x0003CBD4 File Offset: 0x0003ADD4
    private static void gmFixScorePartUpdateDigitList( AppMain.GMS_FIX_PART_SCORE part_score )
    {
        int val = (int)AppMain.gmFixGetScore();
        AppMain.AkUtilNumValueToDigits( val, part_score.digit_list, 9 );
    }

    // Token: 0x060006C8 RID: 1736 RVA: 0x0003CBF8 File Offset: 0x0003ADF8
    private static void gmFixScorePartUpdateActionDigitsType( AppMain.GMS_FIX_PART_SCORE part_score )
    {
        for ( int i = 0; i < 9; i++ )
        {
            AppMain.GMS_COCKPIT_2D_WORK work = part_score.sub_parts[AppMain.gm_fix_part_score_digit_subpart_idx_tbl[i]];
            AppMain.gmFixSetFrameStatic( ( AppMain.OBS_OBJECT_WORK )work, AppMain.gm_fix_part_common_digit_type_frame_tbl[part_score.digit_list[i]] );
        }
    }

    // Token: 0x060006C9 RID: 1737 RVA: 0x0003CC44 File Offset: 0x0003AE44
    private static void gmFixTimerPartInit( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        AppMain.GMS_FIX_PART_WORK gms_FIX_PART_WORK = (AppMain.GMS_FIX_PART_WORK)mgr_work.part_timer;
        AppMain.GMS_FIX_PART_TIMER part_timer = mgr_work.part_timer;
        AppMain.gmFixRegisterPart( mgr_work, gms_FIX_PART_WORK, 2 );
        gms_FIX_PART_WORK.proc_update = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixTimerPartProcUpdateMain );
        gms_FIX_PART_WORK.proc_disp = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixTimerPartProcDispMain );
        if ( AppMain.gmFixIsTimeAttack() )
        {
            AppMain.act_id_tblgmFixTimerPartInit = AppMain.gm_fix_timer_timeattack_act_id_tbl;
            part_timer.flag |= 1U;
        }
        else
        {
            AppMain.act_id_tblgmFixTimerPartInit = AppMain.gm_fix_timer_act_id_tbl;
        }
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "FIX_TIMER");
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmFixSubpartOutFunc );
            AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_fix_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][0], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_fix_textures[0] ), ( uint )AppMain.act_id_tblgmFixTimerPartInit[i], 0 );
            AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK, 0f );
            if ( AppMain.gmFixIsTimeAttack() )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + AppMain.FX_F32_TO_FX32( -98f );
                if ( i != 0 )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + AppMain.FX_F32_TO_FX32( 5f );
                }
            }
            else if ( i != 0 )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
                obs_OBJECT_WORK4.pos.y = obs_OBJECT_WORK4.pos.y + AppMain.FX_F32_TO_FX32( 5f );
            }
            ( ( AppMain.GMS_FIX_PART_TIMER )gms_FIX_PART_WORK ).sub_parts[i] = ( AppMain.GMS_COCKPIT_2D_WORK )obs_OBJECT_WORK;
        }
    }

    // Token: 0x060006CA RID: 1738 RVA: 0x0003CDD4 File Offset: 0x0003AFD4
    private static void gmFixTimerSSPartInit( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        AppMain.GMS_FIX_PART_WORK gms_FIX_PART_WORK = (AppMain.GMS_FIX_PART_WORK)mgr_work.part_timer;
        AppMain.GMS_FIX_PART_TIMER part_timer = mgr_work.part_timer;
        AppMain.gmFixRegisterPart( mgr_work, gms_FIX_PART_WORK, 2 );
        gms_FIX_PART_WORK.proc_update = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixTimerPartProcUpdateMain );
        gms_FIX_PART_WORK.proc_disp = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixTimerPartProcDispMain );
        part_timer.flag |= 1U;
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "FIX_TIMER_SS");
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
            int num;
            int num2;
            if ( i == 0 )
            {
                num = 2;
                num2 = 2;
            }
            else
            {
                num = 1;
                num2 = 1;
            }
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmFixSubpartOutFunc );
            AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_fix_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][num], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_fix_textures[num2] ), ( uint )AppMain.gm_fix_timer_ss_act_id_tbl[AppMain.GsEnvGetLanguage()][i], 0 );
            AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK, 0f );
            ( ( AppMain.GMS_FIX_PART_TIMER )gms_FIX_PART_WORK ).sub_parts[i] = ( AppMain.GMS_COCKPIT_2D_WORK )obs_OBJECT_WORK;
        }
    }

    // Token: 0x060006CB RID: 1739 RVA: 0x0003CEF8 File Offset: 0x0003B0F8
    private static void gmFixTimerPartProcUpdateMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_TIMER gms_FIX_PART_TIMER = (AppMain.GMS_FIX_PART_TIMER)part_work;
        AppMain.gmFixTimerPartUpdateDigitList( gms_FIX_PART_TIMER );
        if ( AppMain.gmFixProcessRequest( part_work.parent_mgr, 1U ) )
        {
            AppMain.gmFixTimerPartInitFlashAction( gms_FIX_PART_TIMER );
        }
        else
        {
            AppMain.gmFixTimerPartUpdateFlashAction( gms_FIX_PART_TIMER );
        }
        if ( AppMain.gmFixTimerPartIsTimeRunningOut( part_work.parent_mgr ) )
        {
            ushort? num = new ushort?(0);
            ushort? num2 = default(ushort?);
            AppMain.AkUtilFrame60ToTime( AppMain.gmFixGetGameTime(), ref num2, ref num, ref num2 );
            if ( ( part_work.flag & 4U ) == 0U )
            {
                part_work.flag |= 4U;
                AppMain.gmFixInitBlink( part_work, 10U, 10U );
                gms_FIX_PART_TIMER.cur_sec = ( ushort )( ( int )( num - 1 ) );
            }
            if ( gms_FIX_PART_TIMER.cur_sec != num )
            {
                gms_FIX_PART_TIMER.cur_sec = num.Value;
                AppMain.GmSoundPlaySE( "Countdown" );
                return;
            }
        }
        else
        {
            part_work.flag &= 4294967291U;
        }
    }

    // Token: 0x060006CC RID: 1740 RVA: 0x0003D008 File Offset: 0x0003B208
    private static void gmFixTimerPartProcDispMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_TIMER part_timer = (AppMain.GMS_FIX_PART_TIMER)part_work;
        if ( ( part_work.flag & 4U ) != 0U )
        {
            AppMain.gmFixTimerPartSetDigitsRed( part_timer, true );
            if ( AppMain.gmFixUpdateBlink( part_work ) )
            {
                part_work.flag &= 4294967287U;
            }
            else
            {
                part_work.flag |= 8U;
            }
        }
        else
        {
            AppMain.gmFixTimerPartSetDigitsRed( part_timer, false );
            part_work.flag &= 4294967287U;
        }
        if ( ( part_work.flag & 8U ) != 0U )
        {
            AppMain.gmFixTimerPartSetDispDigits( part_timer, false );
        }
        else
        {
            AppMain.gmFixTimerPartSetDispDigits( part_timer, true );
        }
        AppMain.gmFixTimerPartUpdateActionDigitsType( part_timer );
    }

    // Token: 0x060006CD RID: 1741 RVA: 0x0003D08C File Offset: 0x0003B28C
    private static void gmFixTimerPartUpdateDigitList( AppMain.GMS_FIX_PART_TIMER part_timer )
    {
        ushort val = 0;
        ushort val2 = 0;
        ushort val3 = 0;
        AppMain.AkUtilFrame60ToTime( AppMain.gmFixGetGameTime(), ref val3, ref val2, ref val );
        int num = 0;
        AppMain.AkUtilNumValueToDigits( ( int )val, new AppMain.ArrayPointer<int>( part_timer.digit_list, num ), AppMain.digit_num_listgmFixTimerPartUpdateDigitList[0] );
        num += AppMain.digit_num_listgmFixTimerPartUpdateDigitList[0];
        AppMain.AkUtilNumValueToDigits( ( int )val2, new AppMain.ArrayPointer<int>( part_timer.digit_list, num ), AppMain.digit_num_listgmFixTimerPartUpdateDigitList[1] );
        num += AppMain.digit_num_listgmFixTimerPartUpdateDigitList[1];
        AppMain.AkUtilNumValueToDigits( ( int )val3, new AppMain.ArrayPointer<int>( part_timer.digit_list, num ), AppMain.digit_num_listgmFixTimerPartUpdateDigitList[2] );
        num += AppMain.digit_num_listgmFixTimerPartUpdateDigitList[2];
    }

    // Token: 0x060006CE RID: 1742 RVA: 0x0003D120 File Offset: 0x0003B320
    private static void gmFixTimerPartUpdateActionDigitsType( AppMain.GMS_FIX_PART_TIMER part_timer )
    {
        int num = 0;
        while ( ( long )num < 5L )
        {
            AppMain.GMS_COCKPIT_2D_WORK work = part_timer.sub_parts[AppMain.gm_fix_part_timer_digit_subpart_idx_tbl[num]];
            AppMain.gmFixSetFrameStatic( ( AppMain.OBS_OBJECT_WORK )work, AppMain.gm_fix_part_common_digit_type_frame_tbl[part_timer.digit_list[num]] + part_timer.digit_frame_ofst );
            num++;
        }
        int num2 = 0;
        while ( ( long )num2 < 2L )
        {
            AppMain.GMS_COCKPIT_2D_WORK work2 = part_timer.sub_parts[AppMain.gm_fix_part_timer_deco_char_subpart_idx_tbl[num2]];
            AppMain.gmFixSetFrameStatic( ( AppMain.OBS_OBJECT_WORK )work2, 0f + part_timer.deco_char_frame_ofst );
            num2++;
        }
    }

    // Token: 0x060006CF RID: 1743 RVA: 0x0003D1A0 File Offset: 0x0003B3A0
    private static void gmFixTimerPartSetDispDigits( AppMain.GMS_FIX_PART_TIMER part_timer, bool enable )
    {
        for ( int i = 0; i < 8; i++ )
        {
            if ( i != 0 )
            {
                if ( enable )
                {
                    ( ( AppMain.OBS_OBJECT_WORK )part_timer.sub_parts[i] ).disp_flag &= 4294967263U;
                }
                else
                {
                    ( ( AppMain.OBS_OBJECT_WORK )part_timer.sub_parts[i] ).disp_flag |= 32U;
                }
            }
        }
    }

    // Token: 0x060006D0 RID: 1744 RVA: 0x0003D1F7 File Offset: 0x0003B3F7
    private static void gmFixTimerPartSetDigitsRed( AppMain.GMS_FIX_PART_TIMER part_timer, bool enable )
    {
        if ( ( part_timer.flag & 1U ) != 0U )
        {
            AppMain.gmFixTimerPartSetTexRedDigits( part_timer, enable );
            return;
        }
        AppMain.gmFixTimerPartSetColorRedDigits( part_timer, enable );
    }

    // Token: 0x060006D1 RID: 1745 RVA: 0x0003D214 File Offset: 0x0003B414
    private static void gmFixTimerPartSetColorRedDigits( AppMain.GMS_FIX_PART_TIMER part_timer, bool enable )
    {
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)part_timer.sub_parts[i];
            if ( i != 0 )
            {
                if ( enable )
                {
                    obs_OBJECT_WORK.obj_2d.color.c = 4278190335U;
                }
                else
                {
                    obs_OBJECT_WORK.obj_2d.color.c = uint.MaxValue;
                }
            }
        }
    }

    // Token: 0x060006D2 RID: 1746 RVA: 0x0003D269 File Offset: 0x0003B469
    private static void gmFixTimerPartSetTexRedDigits( AppMain.GMS_FIX_PART_TIMER part_timer, bool enable )
    {
        if ( enable )
        {
            part_timer.digit_frame_ofst = 10f;
            part_timer.deco_char_frame_ofst = 1f;
            return;
        }
        part_timer.digit_frame_ofst = 0f;
        part_timer.deco_char_frame_ofst = 0f;
    }

    // Token: 0x060006D3 RID: 1747 RVA: 0x0003D29C File Offset: 0x0003B49C
    private static bool gmFixTimerPartIsTimeRunningOut( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        ushort num = 0;
        ushort num2 = 0;
        AppMain.AkUtilFrame60ToTime( AppMain.gmFixGetGameTime(), ref num, ref num2 );
        if ( ( mgr_work.flag & 4U ) != 0U )
        {
            return num <= 0 && num2 < 20;
        }
        return num >= 9 && num2 + 20 >= 60;
    }

    // Token: 0x060006D4 RID: 1748 RVA: 0x0003D2E2 File Offset: 0x0003B4E2
    private static void gmFixTimerPartInitFlashAction( AppMain.GMS_FIX_PART_TIMER part_timer )
    {
        part_timer.flag |= 2U;
        part_timer.fade_ratio = 0f;
        part_timer.scale_ratio = 0f;
        part_timer.flash_act_phase = 0U;
    }

    // Token: 0x060006D5 RID: 1749 RVA: 0x0003D32C File Offset: 0x0003B52C
    private static void gmFixTimerPartUpdateFlashAction( AppMain.GMS_FIX_PART_TIMER part_timer )
    {
        bool flag = false;
        if ( ( part_timer.flag & 2U ) == 0U )
        {
            return;
        }
        switch ( part_timer.flash_act_phase )
        {
            case 0U:
                part_timer.fade_ratio += 0.5f;
                part_timer.scale_ratio += 0.25f;
                part_timer.fade_ratio = AppMain.MTM_MATH_CLIP( part_timer.fade_ratio, 0f, 1f );
                part_timer.scale_ratio = AppMain.MTM_MATH_CLIP( part_timer.fade_ratio, 0f, 1f );
                if ( part_timer.scale_ratio >= 1f )
                {
                    part_timer.flash_act_phase += 1U;
                }
                break;
            case 1U:
                part_timer.fade_ratio -= 0.02f;
                part_timer.scale_ratio -= 0.05f;
                part_timer.fade_ratio = AppMain.MTM_MATH_CLIP( part_timer.fade_ratio, 0f, 1f );
                part_timer.scale_ratio = AppMain.MTM_MATH_CLIP( part_timer.scale_ratio, 0f, 1f );
                if ( part_timer.fade_ratio <= 0f )
                {
                    part_timer.flash_act_phase += 1U;
                }
                break;
            default:
                flag = true;
                break;
        }
        uint[] array = new uint[]
        {
            1U,
            2U,
            3U,
            4U,
            5U,
            6U,
            7U
        };
        uint num = (uint)array.Length;
        if ( !flag )
        {
            int y = 4096 + (int)(part_timer.scale_ratio * 2048f);
            byte a = (byte)AppMain.MTM_MATH_CLIP(255f * part_timer.fade_ratio, 0f, 255f);
            for ( uint num2 = 0U; num2 < num; num2 += 1U )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)part_timer.sub_parts[(int)((UIntPtr)array[(int)((UIntPtr)num2)])];
                obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = y );
                obs_OBJECT_WORK.obj_2d.fade.b = ( obs_OBJECT_WORK.obj_2d.fade.g = ( obs_OBJECT_WORK.obj_2d.fade.r = byte.MaxValue ) );
                obs_OBJECT_WORK.obj_2d.fade.a = a;
            }
            return;
        }
        part_timer.fade_ratio = 0f;
        part_timer.scale_ratio = 0f;
        part_timer.flash_act_phase = 0U;
        for ( uint num3 = 0U; num3 < num; num3 += 1U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = (AppMain.OBS_OBJECT_WORK)part_timer.sub_parts[(int)((UIntPtr)array[(int)((UIntPtr)num3)])];
            obs_OBJECT_WORK2.scale.x = ( obs_OBJECT_WORK2.scale.y = 4096 );
            obs_OBJECT_WORK2.obj_2d.fade.a = ( obs_OBJECT_WORK2.obj_2d.fade.b = ( obs_OBJECT_WORK2.obj_2d.fade.g = ( obs_OBJECT_WORK2.obj_2d.fade.r = 0 ) ) );
        }
        part_timer.flag &= 4294967293U;
    }

    // Token: 0x060006D6 RID: 1750 RVA: 0x0003D614 File Offset: 0x0003B814
    private static void gmFixChallengePartInit( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        AppMain.GMS_FIX_PART_WORK gms_FIX_PART_WORK = (AppMain.GMS_FIX_PART_WORK)mgr_work.part_challenge;
        AppMain.gmFixRegisterPart( mgr_work, gms_FIX_PART_WORK, 3 );
        gms_FIX_PART_WORK.proc_update = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixChallengePartProcUpdateMain );
        gms_FIX_PART_WORK.proc_disp = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixChallengePartProcDispMain );
        for ( int i = 0; i < 5; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "FIX_CHALLENGE");
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmFixSubpartOutFunc );
            AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_fix_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][0], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_fix_textures[0] ), ( uint )AppMain.gm_fix_challenge_act_id_tbl[AppMain.gmFixGetPlan()][i], 0 );
            AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK, 0f );
            ( ( AppMain.GMS_FIX_PART_CHALLENGE )gms_FIX_PART_WORK ).sub_parts[i] = ( AppMain.GMS_COCKPIT_2D_WORK )obs_OBJECT_WORK;
        }
    }

    // Token: 0x060006D7 RID: 1751 RVA: 0x0003D708 File Offset: 0x0003B908
    private static void gmFixChallengePartProcUpdateMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_CHALLENGE gms_FIX_PART_CHALLENGE = (AppMain.GMS_FIX_PART_CHALLENGE)part_work;
        float frame = 0f;
        if ( AppMain.g_gm_main_system.ply_work[0] != null )
        {
            if ( ( AppMain.g_gm_main_system.ply_work[0].player_flag & 16384U ) != 0U )
            {
                frame = 1f;
            }
            else
            {
                frame = 0f;
            }
        }
        AppMain.gmFixSetFrameStatic( ( AppMain.OBS_OBJECT_WORK )gms_FIX_PART_CHALLENGE.sub_parts[0], frame );
        AppMain.gmFixChallengePartUpdateDigitList( gms_FIX_PART_CHALLENGE );
    }

    // Token: 0x060006D8 RID: 1752 RVA: 0x0003D770 File Offset: 0x0003B970
    private static void gmFixChallengePartProcDispMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_CHALLENGE part_challenge = (AppMain.GMS_FIX_PART_CHALLENGE)part_work;
        AppMain.gmFixChallengePartUpdateActionDigitsType( part_challenge );
    }

    // Token: 0x060006D9 RID: 1753 RVA: 0x0003D78C File Offset: 0x0003B98C
    private static void gmFixChallengePartUpdateDigitList( AppMain.GMS_FIX_PART_CHALLENGE part_challenge )
    {
        int val = (int)AppMain.gmFixGetChallengeNum();
        AppMain.AkUtilNumValueToDigits( val, part_challenge.digit_list, 3 );
    }

    // Token: 0x060006DA RID: 1754 RVA: 0x0003D7B0 File Offset: 0x0003B9B0
    private static void gmFixChallengePartUpdateActionDigitsType( AppMain.GMS_FIX_PART_CHALLENGE part_challenge )
    {
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.GMS_COCKPIT_2D_WORK work = part_challenge.sub_parts[AppMain.gm_fix_part_challenge_digit_subpart_idx_tbl[i]];
            AppMain.gmFixSetFrameStatic( ( AppMain.OBS_OBJECT_WORK )work, AppMain.gm_fix_part_common_digit_type_frame_tbl[part_challenge.digit_list[i]] );
        }
    }

    // Token: 0x060006DB RID: 1755 RVA: 0x0003D7F8 File Offset: 0x0003B9F8
    private static void gmFixVirtualPadPartInit( AppMain.GMS_FIX_MGR_WORK mgr_work )
    {
        AppMain.MPP_VOID_OBS_OBJECT_WORK[] array = new AppMain.MPP_VOID_OBS_OBJECT_WORK[]
        {
            new AppMain.MPP_VOID_OBS_OBJECT_WORK(AppMain.gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_SUPER_SONIC.OutFunc),
            new AppMain.MPP_VOID_OBS_OBJECT_WORK(AppMain.gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_PAUSE.OutFunc),
            new AppMain.MPP_VOID_OBS_OBJECT_WORK(AppMain.gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_ACTION.OutFunc),
            new AppMain.MPP_VOID_OBS_OBJECT_WORK(AppMain.gmFixVirtualPadOutClassGMD_FIX_MGR_FLAG_HIDE_VIRTUAL_PAD_PART_MOVE_PAD.OutFunc)
        };
        AppMain.GMS_FIX_PART_WORK gms_FIX_PART_WORK = (AppMain.GMS_FIX_PART_WORK)mgr_work.part_virtual_pad;
        AppMain.gmFixRegisterPart( mgr_work, gms_FIX_PART_WORK, 4 );
        gms_FIX_PART_WORK.proc_update = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixVirtualPadPartProcUpdateMain );
        gms_FIX_PART_WORK.proc_disp = new AppMain.MPP_VOID_GMS_FIX_PART_WORK( AppMain.gmFixVirtualPadPartProcDispMain );
        int i = 0;
        int num = 4;
        while ( i < num )
        {
            if ( AppMain.gm_fix_virtual_pad_act_id_tbl[AppMain.gmFixGetPlan()][i] < 0 )
            {
                ( ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )gms_FIX_PART_WORK ).sub_parts[i] = null;
            }
            else
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "FIX_VIRTUAL_PAD");
                AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
                obs_OBJECT_WORK.ppOut = array[i];
                AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_fix_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][0], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_fix_textures[0] ), ( uint )AppMain.gm_fix_virtual_pad_act_id_tbl[AppMain.gmFixGetPlan()][i], 0 );
                AppMain.amFlagOff( ref obs_OBJECT_WORK.disp_flag, 32U );
                AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK, 0f );
                if ( 1 == i )
                {
                    if ( AppMain.gmFixIsSpecialStage() )
                    {
                        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                        obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + AppMain.FX_F32_TO_FX32( 400f );
                    }
                    else if ( AppMain.gmFixIsTimeAttack() )
                    {
                        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                        obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x + AppMain.FX_F32_TO_FX32( 200f );
                    }
                }
                ( ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )gms_FIX_PART_WORK ).sub_parts[i] = ( AppMain.GMS_COCKPIT_2D_WORK )obs_OBJECT_WORK;
            }
            i++;
        }
        switch ( AppMain.GsEnvGetLanguage() )
        {
            case 3:
            case 5:
                ( ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )gms_FIX_PART_WORK ).pause_icon_frame[0] = 2f;
                ( ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )gms_FIX_PART_WORK ).pause_icon_frame[1] = 3f;
                goto IL_219;
        }
        ( ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )gms_FIX_PART_WORK ).pause_icon_frame[0] = 0f;
        ( ( AppMain.GMS_FIX_PART_VIRTUAL_PAD )gms_FIX_PART_WORK ).pause_icon_frame[1] = 1f;
        IL_219:
        AppMain.amFlagOff( ref gms_FIX_PART_WORK.flag, 2U );
    }

    // Token: 0x060006DC RID: 1756 RVA: 0x0003DA2C File Offset: 0x0003BC2C
    private static void gmFixVirtualPadPartProcUpdateMain( AppMain.GMS_FIX_PART_WORK part_work )
    {
        AppMain.GMS_FIX_PART_VIRTUAL_PAD gms_FIX_PART_VIRTUAL_PAD = (AppMain.GMS_FIX_PART_VIRTUAL_PAD)part_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_FIX_PART_VIRTUAL_PAD.sub_parts[0];
        if ( AppMain.gmFixVirtualPadPartIsDispSuperSonicIcon( gms_FIX_PART_VIRTUAL_PAD ) )
        {
            AppMain.amFlagOff( ref obs_OBJECT_WORK.disp_flag, 32U );
        }
        else
        {
            AppMain.amFlagOn( ref obs_OBJECT_WORK.disp_flag, 32U );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = (AppMain.OBS_OBJECT_WORK)gms_FIX_PART_VIRTUAL_PAD.sub_parts[1];
        if ( AppMain.gmFixVirtualPadPartIsDispPauseIcon( gms_FIX_PART_VIRTUAL_PAD ) )
        {
            AppMain.amFlagOff( ref obs_OBJECT_WORK2.disp_flag, 32U );
            if ( AppMain.gmFixVirtualPadPartIsOnPauseIcon( gms_FIX_PART_VIRTUAL_PAD ) )
            {
                AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK2, gms_FIX_PART_VIRTUAL_PAD.pause_icon_frame[1] );
            }
            else
            {
                AppMain.gmFixSetFrameStatic( obs_OBJECT_WORK2, gms_FIX_PART_VIRTUAL_PAD.pause_icon_frame[0] );
            }
        }
        else
        {
            AppMain.amFlagOn( ref obs_OBJECT_WORK2.disp_flag, 32U );
        }
        switch ( AppMain.gmFixGetPlan() )
        {
            case 0:
                return;
            case 1:
                break;
            case 2:
                {
                    AppMain.OBS_OBJECT_WORK obj_work = (AppMain.OBS_OBJECT_WORK)gms_FIX_PART_VIRTUAL_PAD.sub_parts[3];
                    float frame = AppMain.gmFixVirtualPadPartGetMovePadFrame(gms_FIX_PART_VIRTUAL_PAD);
                    AppMain.gmFixSetFrameStatic( obj_work, frame );
                    break;
                }
            default:
                return;
        }
        AppMain.OBS_OBJECT_WORK obj_work2 = (AppMain.OBS_OBJECT_WORK)gms_FIX_PART_VIRTUAL_PAD.sub_parts[2];
        if ( AppMain.gmFixVirtualPadPartIsOnActionIcon( gms_FIX_PART_VIRTUAL_PAD ) )
        {
            AppMain.gmFixSetFrameStatic( obj_work2, 1f );
            return;
        }
        AppMain.gmFixSetFrameStatic( obj_work2, 0f );
    }

    // Token: 0x060006DD RID: 1757 RVA: 0x0003DB33 File Offset: 0x0003BD33
    private static void gmFixVirtualPadPartProcDispMain( AppMain.GMS_FIX_PART_WORK pArg )
    {
    }

    // Token: 0x060006DE RID: 1758 RVA: 0x0003DB35 File Offset: 0x0003BD35
    private static bool gmFixVirtualPadPartIsDispSuperSonicIcon( AppMain.GMS_FIX_PART_VIRTUAL_PAD pArg )
    {
        return AppMain.GmPlayerIsTransformSuperSonic( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
    }

    // Token: 0x060006DF RID: 1759 RVA: 0x0003DB49 File Offset: 0x0003BD49
    private static bool gmFixVirtualPadPartIsDispPauseIcon( AppMain.GMS_FIX_PART_VIRTUAL_PAD pArg )
    {
        return true;
    }

    // Token: 0x060006E0 RID: 1760 RVA: 0x0003DB4C File Offset: 0x0003BD4C
    private static bool gmFixVirtualPadPartIsOnPauseIcon( AppMain.GMS_FIX_PART_VIRTUAL_PAD pArg )
    {
        bool result = false;
        if ( ( AppMain.GmPauseCheckExecutable() || ( AppMain.g_gm_main_system.game_flag & 192U ) != 0U ) && 0 <= AppMain.GmMainKeyCheckPauseKeyOn() )
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060006E1 RID: 1761 RVA: 0x0003DB80 File Offset: 0x0003BD80
    private static float gmFixVirtualPadPartGetMovePadFrame( AppMain.GMS_FIX_PART_VIRTUAL_PAD pArg )
    {
        AppMain.CPadVirtualPad cpadVirtualPad = AppMain.CPadVirtualPad.CreateInstance();
        ushort value = cpadVirtualPad.GetValue();
        float result = 0f;
        for ( int i = 0; i < AppMain.c_key_to_frame_table.Length; i++ )
        {
            AppMain.SKeyToFrame skeyToFrame = AppMain.c_key_to_frame_table[i];
            if ( ( skeyToFrame.key & ( int )value ) != 0 )
            {
                result = skeyToFrame.frame;
                break;
            }
        }
        return result;
    }

    // Token: 0x060006E2 RID: 1762 RVA: 0x0003DBDA File Offset: 0x0003BDDA
    private static bool gmFixVirtualPadPartIsOnActionIcon( AppMain.GMS_FIX_PART_VIRTUAL_PAD pArg )
    {
        return AppMain.GmPlayerKeyCheckJumpKeyOn( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] );
    }
}