using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000200 RID: 512
    // (Invoke) Token: 0x0600233F RID: 9023
    public delegate void _GMS_OVER_MGR_WORK_UD_( AppMain.GMS_OVER_MGR_WORK _gms_over_mgr_work );

    // Token: 0x02000201 RID: 513
    public class GMS_OVER_MGR_WORK
    {
        // Token: 0x06002342 RID: 9026 RVA: 0x00148721 File Offset: 0x00146921
        internal void Clear()
        {
            this.proc_update = null;
            this.proc_disp = null;
            this.wait_timer = 0U;
            Array.Clear( this.string_sub_parts, 0, this.string_sub_parts.Length );
            Array.Clear( this.fadeout_sub_parts, 0, this.fadeout_sub_parts.Length );
        }

        // Token: 0x040055DE RID: 21982
        public AppMain._GMS_OVER_MGR_WORK_UD_ proc_update;

        // Token: 0x040055DF RID: 21983
        public AppMain._GMS_OVER_MGR_WORK_UD_ proc_disp;

        // Token: 0x040055E0 RID: 21984
        public uint wait_timer;

        // Token: 0x040055E1 RID: 21985
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] string_sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[4];

        // Token: 0x040055E2 RID: 21986
        public readonly AppMain.GMS_COCKPIT_2D_WORK[] fadeout_sub_parts = new AppMain.GMS_COCKPIT_2D_WORK[2];
    }

    // Token: 0x06000B01 RID: 2817 RVA: 0x00063238 File Offset: 0x00061438
    private static void GmOverBuildDataInit()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.gm_over_textures[i].Clear();
            AppMain.gm_over_texamb_list[i] = ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataLoadAmbIndex( null, AppMain.gm_over_tex_amb_idx_tbl[AppMain.GsEnvGetLanguage()][i], AppMain.GmGameDatGetCockpitData() );
            AppMain.AoTexBuild( AppMain.gm_over_textures[i], AppMain.gm_over_texamb_list[i] );
            AppMain.AoTexLoad( AppMain.gm_over_textures[i] );
        }
    }

    // Token: 0x06000B02 RID: 2818 RVA: 0x000632A0 File Offset: 0x000614A0
    private static bool GmOverBuildDataLoop()
    {
        bool result = true;
        for ( int i = 0; i < 2; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( AppMain.gm_over_textures[i] ) )
            {
                result = false;
            }
        }
        return result;
    }

    // Token: 0x06000B03 RID: 2819 RVA: 0x000632CC File Offset: 0x000614CC
    private static void GmOverFlushDataInit()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoTexRelease( AppMain.gm_over_textures[i] );
        }
    }

    // Token: 0x06000B04 RID: 2820 RVA: 0x000632F4 File Offset: 0x000614F4
    private static bool GmOverFlushDataLoop()
    {
        bool result = true;
        for ( int i = 0; i < 2; i++ )
        {
            if ( AppMain.gm_over_texamb_list[i] != null )
            {
                if ( !AppMain.AoTexIsReleased( AppMain.gm_over_textures[i] ) )
                {
                    result = false;
                }
                else
                {
                    AppMain.gm_over_texamb_list[i] = null;
                    AppMain.gm_over_textures[i].Clear();
                }
            }
        }
        return result;
    }

    // Token: 0x06000B05 RID: 2821 RVA: 0x00063354 File Offset: 0x00061554
    private static void GmOverStart( int type )
    {
        SaveState.deleteSave();
        AppMain.gm_over_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmOverMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmOverDest ), 0U, 0, 18464U, 5, () => new AppMain.GMS_OVER_MGR_WORK(), "GM_OVER_MGR" );
        AppMain.GMS_OVER_MGR_WORK gms_OVER_MGR_WORK = (AppMain.GMS_OVER_MGR_WORK)AppMain.gm_over_tcb.work;
        gms_OVER_MGR_WORK.Clear();
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "GAME_OVER");
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK;
            AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK, gms_COCKPIT_2D_WORK.obj_2d, null, null, AppMain.gm_over_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][1], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_over_textures[1] ), AppMain.gm_over_string_act_id_tbl[AppMain.GsEnvGetLanguage()][i], 0 );
            gms_OVER_MGR_WORK.string_sub_parts[i] = gms_COCKPIT_2D_WORK;
            AppMain.gmOverSetActionHide( gms_COCKPIT_2D_WORK );
        }
        for ( int j = 0; j < 2; j++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_COCKPIT_CREATE_WORK(() => new AppMain.GMS_COCKPIT_2D_WORK(), null, 0, "GAME_OVER");
            AppMain.GMS_COCKPIT_2D_WORK gms_COCKPIT_2D_WORK2 = (AppMain.GMS_COCKPIT_2D_WORK)obs_OBJECT_WORK2;
            AppMain.ObjObjectAction2dAMALoadSetTexlist( obs_OBJECT_WORK2, gms_COCKPIT_2D_WORK2.obj_2d, null, null, AppMain.gm_over_ama_amb_idx_tbl[AppMain.GsEnvGetLanguage()][0], AppMain.GmGameDatGetCockpitData(), AppMain.AoTexGetTexList( AppMain.gm_over_textures[0] ), AppMain.gm_over_fadeout_act_id_tbl[j], 0 );
            gms_OVER_MGR_WORK.fadeout_sub_parts[j] = gms_COCKPIT_2D_WORK2;
            obs_OBJECT_WORK2.pos.z = -65536;
            obs_OBJECT_WORK2.disp_flag &= 4294967291U;
            AppMain.gmOverSetActionHide( gms_COCKPIT_2D_WORK2 );
        }
        switch ( type )
        {
            case 0:
                AppMain.gmOverProcUpdateGOInit( gms_OVER_MGR_WORK );
                break;
            case 1:
                AppMain.gmOverProcUpdateTOInit( gms_OVER_MGR_WORK );
                break;
        }
        gms_OVER_MGR_WORK.proc_disp = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcDispLoop );
    }

    // Token: 0x06000B06 RID: 2822 RVA: 0x00063539 File Offset: 0x00061739
    private static void GmOverExit()
    {
        if ( AppMain.gm_over_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_over_tcb );
            AppMain.gm_over_tcb = null;
        }
    }

    // Token: 0x06000B07 RID: 2823 RVA: 0x00063552 File Offset: 0x00061752
    private static bool gmOverIsSkipKeyOn()
    {
        if ( ( AppMain.AoPadDirect() & 240 ) != 0 || AppMain.isBackKeyPressed() )
        {
            AppMain.setBackKeyRequest( false );
            return true;
        }
        return false;
    }

    // Token: 0x06000B08 RID: 2824 RVA: 0x00063574 File Offset: 0x00061774
    private static void gmOverSetActionHide( AppMain.GMS_COCKPIT_2D_WORK cpit_2d )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)cpit_2d;
        obs_OBJECT_WORK.disp_flag |= 4128U;
    }

    // Token: 0x06000B09 RID: 2825 RVA: 0x0006359C File Offset: 0x0006179C
    private static void gmOverSetActionPlay( AppMain.GMS_COCKPIT_2D_WORK cpit_2d )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)cpit_2d;
        obs_OBJECT_WORK.disp_flag &= 4294963167U;
    }

    // Token: 0x06000B0A RID: 2826 RVA: 0x000635C4 File Offset: 0x000617C4
    private static void gmOverSetActionPause( AppMain.GMS_COCKPIT_2D_WORK cpit_2d )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)cpit_2d;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.disp_flag |= 4096U;
    }

    // Token: 0x06000B0B RID: 2827 RVA: 0x000635F9 File Offset: 0x000617F9
    private static void gmOverDest( AppMain.MTS_TASK_TCB tcb )
    {
    }

    // Token: 0x06000B0C RID: 2828 RVA: 0x000635FC File Offset: 0x000617FC
    private static void gmOverMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_OVER_MGR_WORK gms_OVER_MGR_WORK = (AppMain.GMS_OVER_MGR_WORK)tcb.work;
        if ( gms_OVER_MGR_WORK.proc_update != null )
        {
            gms_OVER_MGR_WORK.proc_update( gms_OVER_MGR_WORK );
        }
        if ( gms_OVER_MGR_WORK.proc_disp != null )
        {
            gms_OVER_MGR_WORK.proc_disp( gms_OVER_MGR_WORK );
        }
    }

    // Token: 0x06000B0D RID: 2829 RVA: 0x0006363D File Offset: 0x0006183D
    private static void gmOverProcUpdateGOInit( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        mgr_work.wait_timer = 30U;
        mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateGOWaitStart );
    }

    // Token: 0x06000B0E RID: 2830 RVA: 0x0006365C File Offset: 0x0006185C
    private static void gmOverProcUpdateGOWaitStart( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmOverSetActionPlay( mgr_work.string_sub_parts[0] );
        AppMain.gmOverSetActionPlay( mgr_work.string_sub_parts[1] );
        mgr_work.wait_timer = 480U;
        mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateGOLoop );
    }

    // Token: 0x06000B0F RID: 2831 RVA: 0x000636B8 File Offset: 0x000618B8
    private static void gmOverProcUpdateGOLoop( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        if ( AppMain.gmOverIsSkipKeyOn() )
        {
            mgr_work.wait_timer = 0U;
        }
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmOverSetActionPlay( mgr_work.fadeout_sub_parts[0] );
        mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateGOWaitFadeEnd );
    }

    // Token: 0x06000B10 RID: 2832 RVA: 0x0006370C File Offset: 0x0006190C
    private static void gmOverProcUpdateGOWaitFadeEnd( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)mgr_work.fadeout_sub_parts[0];
        if ( ( obs_OBJECT_WORK.disp_flag & 8U ) != 0U )
        {
            AppMain.IzFadeInitEasy( 0U, 1U, 1f );
            mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateGOWaitFinalizeFade );
        }
    }

    // Token: 0x06000B11 RID: 2833 RVA: 0x0006374F File Offset: 0x0006194F
    private static void gmOverProcUpdateGOWaitFinalizeFade( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.g_gm_main_system.game_flag |= 256U;
            mgr_work.proc_update = null;
        }
    }

    // Token: 0x06000B12 RID: 2834 RVA: 0x00063775 File Offset: 0x00061975
    private static void gmOverProcUpdateTOInit( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        mgr_work.wait_timer = 30U;
        mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateTOWaitStart );
    }

    // Token: 0x06000B13 RID: 2835 RVA: 0x00063794 File Offset: 0x00061994
    private static void gmOverProcUpdateTOWaitStart( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        if ( mgr_work.wait_timer != 0U )
        {
            mgr_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmOverSetActionPlay( mgr_work.string_sub_parts[2] );
        AppMain.gmOverSetActionPlay( mgr_work.string_sub_parts[3] );
        AppMain.gmOverSetActionPlay( mgr_work.fadeout_sub_parts[1] );
        mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateTOWaitFadeEnd );
    }

    // Token: 0x06000B14 RID: 2836 RVA: 0x000637F4 File Offset: 0x000619F4
    private static void gmOverProcUpdateTOWaitFadeEnd( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)mgr_work.fadeout_sub_parts[1];
        if ( ( obs_OBJECT_WORK.disp_flag & 8U ) != 0U )
        {
            AppMain.IzFadeInitEasy( 0U, 1U, 1f );
            mgr_work.proc_update = new AppMain._GMS_OVER_MGR_WORK_UD_( AppMain.gmOverProcUpdateTOWaitFinalizeFade );
        }
    }

    // Token: 0x06000B15 RID: 2837 RVA: 0x00063837 File Offset: 0x00061A37
    private static void gmOverProcUpdateTOWaitFinalizeFade( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            AppMain.g_gm_main_system.game_flag |= 256U;
            mgr_work.proc_update = null;
        }
    }

    // Token: 0x06000B16 RID: 2838 RVA: 0x0006385D File Offset: 0x00061A5D
    private static void gmOverProcDispLoop( AppMain.GMS_OVER_MGR_WORK mgr_work )
    {
    }
}
