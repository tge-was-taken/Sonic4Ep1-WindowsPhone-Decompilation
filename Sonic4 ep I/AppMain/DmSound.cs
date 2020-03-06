using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000EE4 RID: 3812 RVA: 0x00083F82 File Offset: 0x00082182
    private static void DmSoundBuild()
    {
    }

    // Token: 0x06000EE5 RID: 3813 RVA: 0x00083F84 File Offset: 0x00082184
    private static bool DmSoundBuildCheck()
    {
        return true;
    }

    // Token: 0x06000EE6 RID: 3814 RVA: 0x00083F87 File Offset: 0x00082187
    private static void DmSoundFlush()
    {
    }

    // Token: 0x06000EE7 RID: 3815 RVA: 0x00083F89 File Offset: 0x00082189
    private static void DmSoundInit()
    {
        AppMain.GsSoundReset();
        AppMain.dm_sound_bgm_scb = AppMain.GsSoundAssignScb( 0 );
        AppMain.dm_sound_jingle_scb = AppMain.GsSoundAssignScb( 0 );
        AppMain.GsSoundBegin( 4096, 1U, 3 );
    }

    // Token: 0x06000EE8 RID: 3816 RVA: 0x00083FB4 File Offset: 0x000821B4
    private static void DmSoundExit()
    {
        AppMain.GsSoundHalt();
        AppMain.GsSoundEnd();
        if ( AppMain.dm_sound_jingle_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.dm_sound_jingle_scb, 0 );
            AppMain.GsSoundResignScb( AppMain.dm_sound_jingle_scb );
            AppMain.dm_sound_jingle_scb = null;
        }
        if ( AppMain.dm_sound_bgm_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.dm_sound_bgm_scb, 0 );
            AppMain.GsSoundResignScb( AppMain.dm_sound_bgm_scb );
            AppMain.dm_sound_bgm_scb = null;
        }
        AppMain.GsSoundReset();
    }

    // Token: 0x06000EE9 RID: 3817 RVA: 0x00084014 File Offset: 0x00082214
    private static void DmSoundPlaySE( string cue_name )
    {
        AppMain.GsSoundPlaySe( cue_name );
    }

    // Token: 0x06000EEA RID: 3818 RVA: 0x0008401C File Offset: 0x0008221C
    private static void DmSoundPlayBGM( string cue_name, int fade_frame )
    {
        if ( AppMain.dm_sound_bgm_scb != null )
        {
            AppMain.GsSoundPlayBgm( AppMain.dm_sound_bgm_scb, cue_name, fade_frame );
        }
        AppMain.dm_sound_bgm_scb.flag |= 2147483648U;
    }

    // Token: 0x06000EEB RID: 3819 RVA: 0x00084047 File Offset: 0x00082247
    private static void DmSoundStopBGM( int fade_frame )
    {
        AppMain.DmSoundStopStageBGM( fade_frame );
    }

    // Token: 0x06000EEC RID: 3820 RVA: 0x0008404F File Offset: 0x0008224F
    private static void DmSoundPlayMenuBGM( int idx, int fade_frame )
    {
        if ( AppMain.dm_sound_bgm_scb != null )
        {
            AppMain.GsSoundPlayBgm( AppMain.dm_sound_bgm_scb, AppMain.dm_sound_bgm_name_list[idx], fade_frame );
        }
        AppMain.dm_sound_bgm_scb.flag |= 2147483648U;
    }

    // Token: 0x06000EED RID: 3821 RVA: 0x00084080 File Offset: 0x00082280
    private static void DmSoundStopStageBGM( int fade_frame )
    {
        if ( AppMain.dm_sound_bgm_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.dm_sound_bgm_scb, fade_frame );
        }
    }

    // Token: 0x06000EEE RID: 3822 RVA: 0x00084094 File Offset: 0x00082294
    private static void DmSoundPauseStageBGM( int fade_frame )
    {
        if ( AppMain.dm_sound_bgm_scb != null )
        {
            AppMain.GsSoundPauseBgm( AppMain.dm_sound_bgm_scb, fade_frame );
        }
    }

    // Token: 0x06000EEF RID: 3823 RVA: 0x000840A8 File Offset: 0x000822A8
    private static void DmSoundResumeStageBGM( int fade_frame )
    {
        if ( AppMain.dm_sound_bgm_scb != null )
        {
            AppMain.GsSoundResumeBgm( AppMain.dm_sound_bgm_scb, fade_frame );
        }
    }

    // Token: 0x06000EF0 RID: 3824 RVA: 0x000840BC File Offset: 0x000822BC
    private static void DmSoundPlayJingle( int jngl_idx, int fade_frame )
    {
        AppMain.GsSoundStopBgm( AppMain.dm_sound_jingle_scb );
        AppMain.GsSoundPlayBgm( AppMain.dm_sound_jingle_scb, AppMain.dm_sound_jingle_name_list[jngl_idx], fade_frame );
        AppMain.dm_sound_jingle_scb.flag |= 2147483648U;
    }

    // Token: 0x06000EF1 RID: 3825 RVA: 0x000840F0 File Offset: 0x000822F0
    private static void DmSoundStopJingle( int fade_frame )
    {
        AppMain.GsSoundStopBgm( AppMain.dm_sound_jingle_scb, fade_frame );
    }

    // Token: 0x06000EF2 RID: 3826 RVA: 0x00084100 File Offset: 0x00082300
    private static void DmSoundSetVolumeSE( float volume )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        float num;
        if ( volume != 0f )
        {
            num = volume / 10f;
        }
        else
        {
            num = 0f;
        }
        gss_MAIN_SYS_INFO.se_volume = num;
        AppMain.GsSoundSetVolume( 1, num );
    }

    // Token: 0x06000EF3 RID: 3827 RVA: 0x00084140 File Offset: 0x00082340
    private static void DmSoundSetVolumeBGM( float volume )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        float num;
        if ( volume != 0f )
        {
            num = volume / 10f;
        }
        else
        {
            num = 0f;
        }
        gss_MAIN_SYS_INFO.bgm_volume = num;
        AppMain.GsSoundSetVolume( 0, num );
    }

    // Token: 0x06000EF4 RID: 3828 RVA: 0x0008417F File Offset: 0x0008237F
    private static bool DmSoundIsStopStageBGM()
    {
        return AppMain.GsSoundIsBgmStop( AppMain.dm_sound_bgm_scb );
    }

    // Token: 0x06000EF5 RID: 3829 RVA: 0x00084190 File Offset: 0x00082390
    private static bool DmSoundIsStopJingle()
    {
        return AppMain.GsSoundIsBgmStop( AppMain.dm_sound_jingle_scb );
    }
}