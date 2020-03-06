using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.GamerServices;
using Sonic4ep1;

public partial class AppMain
{
    // Token: 0x02000328 RID: 808
    public struct AOS_SYS_GLOBAL
    {
        // Token: 0x04005E09 RID: 24073
        public bool is_show_ui;

        // Token: 0x04005E0A RID: 24074
        public bool is_signin_changed;

        // Token: 0x04005E0B RID: 24075
        public bool is_playing_device_bgm_music;
    }

    // Token: 0x0600162F RID: 5679 RVA: 0x000C1340 File Offset: 0x000BF540
    protected static void GetMBResult( IAsyncResult r )
    {
        try
        {
            if ( Guide.EndShowMessageBox( r ) == 0 )
            {
                AppMain.g_ao_sys_global.is_playing_device_bgm_music = false;
                try
                {
                    MediaPlayer.Stop();
                }
                catch ( Exception )
                {
                }
            }
        }
        finally
        {
            AppMain.g_ao_sys_global.is_show_ui = false;
        }
    }

    // Token: 0x06001630 RID: 5680 RVA: 0x000C13AC File Offset: 0x000BF5AC
    private static void AoSysInit()
    {
        AppMain.g_ao_sys_global.is_show_ui = false;
        AppMain.g_ao_sys_global.is_signin_changed = false;
        if ( !MediaPlayer.GameHasControl || MediaPlayer.State == MediaState.Playing )
        {
            AppMain.g_ao_sys_global.is_playing_device_bgm_music = true;
            List<string> list = new List<string>();
            list.Add( Strings.ID_YES );
            list.Add( Strings.ID_NO );
            string id_MUSIC_INTERRUPT_CAPTON = Strings.ID_MUSIC_INTERRUPT_CAPTON;
            string id_MUSIC_INTERRUPT_TEXT = Strings.ID_MUSIC_INTERRUPT_TEXT;
            AppMain.g_ao_sys_global.is_show_ui = true;
            Guide.BeginShowMessageBox( id_MUSIC_INTERRUPT_CAPTON, id_MUSIC_INTERRUPT_TEXT, list, 0, MessageBoxIcon.Warning, new AsyncCallback( AppMain.GetMBResult ), null );
        }
        else
        {
            AppMain.g_ao_sys_global.is_playing_device_bgm_music = false;
        }
        AppMain.aoSysInit();
    }

    // Token: 0x06001631 RID: 5681 RVA: 0x000C1446 File Offset: 0x000BF646
    private static void AoSysExit()
    {
        AppMain.aoSysExit();
    }

    // Token: 0x06001632 RID: 5682 RVA: 0x000C144D File Offset: 0x000BF64D
    private static bool AoSysIsShowPlatformUI()
    {
        return AppMain.g_ao_sys_global.is_show_ui;
    }

    // Token: 0x06001633 RID: 5683 RVA: 0x000C145E File Offset: 0x000BF65E
    private static bool AoSysIsChangeSigninState()
    {
        return AppMain.g_ao_sys_global.is_signin_changed;
    }

    // Token: 0x06001634 RID: 5684 RVA: 0x000C146A File Offset: 0x000BF66A
    private static void AoSysClearSigninState()
    {
        AppMain.g_ao_sys_global.is_signin_changed = false;
    }

    // Token: 0x06001635 RID: 5685 RVA: 0x000C1477 File Offset: 0x000BF677
    private static bool AoSysIsPlaySystemBgm()
    {
        return AppMain.g_ao_sys_global.is_playing_device_bgm_music;
    }

    // Token: 0x06001636 RID: 5686 RVA: 0x000C1483 File Offset: 0x000BF683
    private static void aoSysInit()
    {
    }

    // Token: 0x06001637 RID: 5687 RVA: 0x000C1485 File Offset: 0x000BF685
    private static void aoSysExit()
    {
    }

    // Token: 0x06001547 RID: 5447 RVA: 0x000B9237 File Offset: 0x000B7437
    public static void amSystemLog( string s )
    {
    }
}