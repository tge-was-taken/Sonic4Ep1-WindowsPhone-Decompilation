using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001AC RID: 428
    public class GMS_SOUND_1SHOT_JINGLE_WORK
    {
        // Token: 0x06002204 RID: 8708 RVA: 0x0014223C File Offset: 0x0014043C
        internal void Clear()
        {
            this.bgm_fade_in_frame = 0;
        }

        // Token: 0x04004F9E RID: 20382
        public int bgm_fade_in_frame;
    }

    // Token: 0x020001AD RID: 429
    public class GMS_SOUND_BGM_FADE_WORK
    {
        // Token: 0x04004F9F RID: 20383
        public float start_vol;

        // Token: 0x04004FA0 RID: 20384
        public float end_vol;

        // Token: 0x04004FA1 RID: 20385
        public float fade_spd;

        // Token: 0x04004FA2 RID: 20386
        public float now_vol;

        // Token: 0x04004FA3 RID: 20387
        public int frame;

        // Token: 0x04004FA4 RID: 20388
        public AppMain.GSS_SND_SCB snd_scb;

        // Token: 0x04004FA5 RID: 20389
        public AppMain.GMS_SOUND_BGM_FADE_WORK next;

        // Token: 0x04004FA6 RID: 20390
        public AppMain.GMS_SOUND_BGM_FADE_WORK prev;
    }

    // Token: 0x020001AE RID: 430
    public class GMS_SOUND_BGM_FADE_MGR_WORK
    {
        // Token: 0x06002207 RID: 8711 RVA: 0x00142255 File Offset: 0x00140455
        internal void Clear()
        {
            this.num = 0;
            this.head = null;
            this.tail = null;
        }

        // Token: 0x04004FA7 RID: 20391
        public int num;

        // Token: 0x04004FA8 RID: 20392
        public AppMain.GMS_SOUND_BGM_FADE_WORK head;

        // Token: 0x04004FA9 RID: 20393
        public AppMain.GMS_SOUND_BGM_FADE_WORK tail;
    }

    // Token: 0x020001AF RID: 431
    public class GMS_SOUND_BGM_WIN_BOSS_MGR_WORK
    {
        // Token: 0x06002209 RID: 8713 RVA: 0x00142274 File Offset: 0x00140474
        internal void Clear()
        {
            this.timer = 0;
        }

        // Token: 0x04004FAA RID: 20394
        public int timer;
    }

    // Token: 0x0600081D RID: 2077 RVA: 0x0004794B File Offset: 0x00045B4B
    private static void GmSoundBuild()
    {
    }

    // Token: 0x0600081E RID: 2078 RVA: 0x0004794D File Offset: 0x00045B4D
    private static bool GmSoundBuildCheck()
    {
        return true;
    }

    // Token: 0x0600081F RID: 2079 RVA: 0x00047950 File Offset: 0x00045B50
    private static void GmSoundFlush()
    {
    }

    // Token: 0x06000820 RID: 2080 RVA: 0x00047954 File Offset: 0x00045B54
    private static void GmSoundInit()
    {
        AppMain.GsSoundReset();
        AppMain.gm_sound_bgm_scb = AppMain.GsSoundAssignScb( 0 );
        AppMain.gm_sound_bgm_sub_scb = AppMain.GsSoundAssignScb( 0 );
        AppMain.gm_sound_jingle_scb = AppMain.GsSoundAssignScb( 0 );
        AppMain.gm_sound_jingle_bgm_scb = AppMain.GsSoundAssignScb( 0 );
        AppMain.GsSoundBegin( 3, 32767U, 5 );
        AppMain.gm_sound_flag = 0U;
        AppMain.gm_sound_1shot_tcb = null;
        AppMain.gm_sound_bgm_win_boss_tcb = null;
    }

    // Token: 0x06000821 RID: 2081 RVA: 0x000479B0 File Offset: 0x00045BB0
    private static void GmSoundExit()
    {
        if ( AppMain.gm_sound_1shot_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_sound_1shot_tcb );
        }
        if ( AppMain.gm_sound_bgm_fade_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_sound_bgm_fade_tcb );
        }
        if ( AppMain.gm_sound_bgm_win_boss_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_sound_bgm_win_boss_tcb );
        }
        AppMain.GsSoundHalt();
        AppMain.GsSoundEnd();
        if ( AppMain.gm_sound_jingle_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.gm_sound_jingle_scb, 0 );
            AppMain.GsSoundResignScb( AppMain.gm_sound_jingle_scb );
            AppMain.gm_sound_jingle_scb = null;
        }
        if ( AppMain.gm_sound_bgm_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_scb, 0 );
            AppMain.GsSoundResignScb( AppMain.gm_sound_bgm_scb );
            AppMain.gm_sound_bgm_scb = null;
        }
        if ( AppMain.gm_sound_bgm_sub_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_sub_scb, 0 );
            AppMain.GsSoundResignScb( AppMain.gm_sound_bgm_sub_scb );
            AppMain.gm_sound_bgm_sub_scb = null;
        }
        if ( AppMain.gm_sound_jingle_bgm_scb != null )
        {
            AppMain.GsSoundStopBgm( AppMain.gm_sound_jingle_bgm_scb, 0 );
            AppMain.GsSoundResignScb( AppMain.gm_sound_jingle_bgm_scb );
            AppMain.gm_sound_jingle_bgm_scb = null;
        }
    }

    // Token: 0x06000822 RID: 2082 RVA: 0x00047A82 File Offset: 0x00045C82
    public static void GmSoundPlaySE( string cue_name )
    {
        AppMain.GmSoundPlaySE( cue_name, null );
    }

    // Token: 0x06000823 RID: 2083 RVA: 0x00047A8B File Offset: 0x00045C8B
    private static void GmSoundPlaySE( string cue_name, AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.GsSoundPlaySe( cue_name, se_handle );
    }

    // Token: 0x06000824 RID: 2084 RVA: 0x00047A94 File Offset: 0x00045C94
    private static void GmSoundPlaySEForce( string cue_name, AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.GsSoundPlaySeForce( cue_name, se_handle, 0, false );
    }

    // Token: 0x06000825 RID: 2085 RVA: 0x00047A9F File Offset: 0x00045C9F
    private static void GmSoundPlaySEForce( string cue_name, AppMain.GSS_SND_SE_HANDLE se_handle, bool dontplay )
    {
        AppMain.GsSoundPlaySeForce( cue_name, se_handle, 0, dontplay );
    }

    // Token: 0x06000826 RID: 2086 RVA: 0x00047AAA File Offset: 0x00045CAA
    private static void GmSoundPlayBGM( string cue_name, int fade_frame )
    {
        AppMain.GmSoundPlayStageBGM( fade_frame );
    }

    // Token: 0x06000827 RID: 2087 RVA: 0x00047AB4 File Offset: 0x00045CB4
    private static void GmSoundPlayStageBGM( int fade_frame )
    {
        AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 1f );
        AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, false );
        AppMain.GsSoundPlayBgm( AppMain.gm_sound_bgm_scb, AppMain.gm_sound_bgm_name_list[( int )AppMain.g_gs_main_sys_info.stage_id], fade_frame );
        AppMain.gm_sound_bgm_scb.flag |= 2147483648U;
    }

    // Token: 0x06000828 RID: 2088 RVA: 0x00047B0C File Offset: 0x00045D0C
    private static void GmSoundStopBGM( int fade_frame )
    {
        AppMain.GmSoundStopStageBGM( fade_frame );
    }

    // Token: 0x06000829 RID: 2089 RVA: 0x00047B14 File Offset: 0x00045D14
    private static void GmSoundStopStageBGM( int fade_frame )
    {
        AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_scb, fade_frame );
    }

    // Token: 0x0600082A RID: 2090 RVA: 0x00047B21 File Offset: 0x00045D21
    private static void GmSoundPauseStageBGM( int fade_frame )
    {
        AppMain.GsSoundPauseBgm( AppMain.gm_sound_bgm_scb, fade_frame );
    }

    // Token: 0x0600082B RID: 2091 RVA: 0x00047B2E File Offset: 0x00045D2E
    private static void GmSoundResumeStageBGM( int fade_frame )
    {
        AppMain.GsSoundResumeBgm( AppMain.gm_sound_bgm_scb, fade_frame );
    }

    // Token: 0x0600082C RID: 2092 RVA: 0x00047B3C File Offset: 0x00045D3C
    private static void GmSoundChangeSpeedupBGM()
    {
        bool flag = false;
        bool flag2 = false;
        AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_sub_scb, 0 );
        if ( AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            flag = true;
        }
        if ( ( AppMain.gm_sound_flag & 80U ) != 0U )
        {
            flag2 = true;
        }
        if ( flag || flag2 )
        {
            AppMain.GmSoundStopStageBGM( 0 );
        }
        else
        {
            AppMain.GmSoundStopStageBGM( 0 );
        }
        if ( flag )
        {
            AppMain.GmSoundPauseStageBGM( 0 );
        }
        AppMain.GSS_SND_SCB gss_SND_SCB = AppMain.gm_sound_bgm_scb;
        AppMain.gm_sound_bgm_scb = AppMain.gm_sound_bgm_sub_scb;
        AppMain.gm_sound_bgm_sub_scb = gss_SND_SCB;
        AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 1f );
        AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, false );
        AppMain.GsSoundPlayBgm( AppMain.gm_sound_bgm_scb, AppMain.gm_sound_speedup_bgm_name_list[( int )AppMain.g_gs_main_sys_info.stage_id], 0 );
        AppMain.gm_sound_bgm_scb.flag |= 2147483648U;
        if ( flag2 )
        {
            AppMain.gmSoundSetBGMFadeEnd( AppMain.gm_sound_bgm_scb );
            AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 0f );
            AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, true );
        }
    }

    // Token: 0x0600082D RID: 2093 RVA: 0x00047C18 File Offset: 0x00045E18
    private static void GmSoundChangeAngryBossBGM()
    {
        bool flag = false;
        bool flag2 = false;
        AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_sub_scb, 0 );
        if ( AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            flag = true;
        }
        if ( ( AppMain.gm_sound_flag & 80U ) != 0U )
        {
            flag2 = true;
        }
        if ( flag || flag2 )
        {
            AppMain.GmSoundStopStageBGM( 0 );
        }
        else
        {
            AppMain.GmSoundStopStageBGM( 15 );
        }
        AppMain.GSS_SND_SCB gss_SND_SCB = AppMain.gm_sound_bgm_scb;
        AppMain.gm_sound_bgm_scb = AppMain.gm_sound_bgm_sub_scb;
        AppMain.gm_sound_bgm_sub_scb = gss_SND_SCB;
        AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 1f );
        AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, false );
        AppMain.GsSoundPlayBgm( AppMain.gm_sound_bgm_scb, "snd_sng_boss2", 15 );
        AppMain.gm_sound_bgm_scb.flag |= 2147483648U;
        if ( flag )
        {
            AppMain.GmSoundPauseStageBGM( 0 );
        }
        if ( flag2 )
        {
            AppMain.gmSoundSetBGMFadeEnd( AppMain.gm_sound_bgm_scb );
            AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 0f );
            AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, true );
        }
    }

    // Token: 0x0600082E RID: 2094 RVA: 0x00047CF0 File Offset: 0x00045EF0
    private static void GmSoundChangeWinBossBGM()
    {
        if ( AppMain.g_gs_main_sys_info.stage_id >= 16 )
        {
            return;
        }
        if ( AppMain.gm_sound_bgm_win_boss_tcb == null )
        {
            AppMain.gm_sound_bgm_win_boss_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSoundBGMWinBossFunc ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSoundBGMWinBossDest ), 0U, 0, 32767U, 5, () => new AppMain.GMS_SOUND_BGM_WIN_BOSS_MGR_WORK(), "GM_SOUND_WB" );
            AppMain.GMS_SOUND_BGM_WIN_BOSS_MGR_WORK gms_SOUND_BGM_WIN_BOSS_MGR_WORK = (AppMain.GMS_SOUND_BGM_WIN_BOSS_MGR_WORK)AppMain.gm_sound_bgm_win_boss_tcb.work;
            gms_SOUND_BGM_WIN_BOSS_MGR_WORK.Clear();
            gms_SOUND_BGM_WIN_BOSS_MGR_WORK.timer = AppMain.gm_sound_bgm_win_boss_wait_frame_list[AppMain.GMM_MAIN_GET_ZONE_TYPE()];
        }
    }

    // Token: 0x0600082F RID: 2095 RVA: 0x00047D88 File Offset: 0x00045F88
    private static void GmSoundChangeFinalBossBGM()
    {
        bool flag = false;
        bool flag2 = false;
        AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_sub_scb, 0 );
        if ( AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            flag = true;
        }
        if ( ( AppMain.gm_sound_flag & 80U ) != 0U )
        {
            flag2 = true;
        }
        if ( flag || flag2 )
        {
            AppMain.GmSoundStopStageBGM( 0 );
        }
        else
        {
            AppMain.GmSoundStopStageBGM( 15 );
        }
        AppMain.GSS_SND_SCB gss_SND_SCB = AppMain.gm_sound_bgm_scb;
        AppMain.gm_sound_bgm_scb = AppMain.gm_sound_bgm_sub_scb;
        AppMain.gm_sound_bgm_sub_scb = gss_SND_SCB;
        AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 1f );
        AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, false );
        AppMain.GsSoundPlayBgm( AppMain.gm_sound_bgm_scb, "snd_sng_final", 15 );
        AppMain.gm_sound_bgm_scb.flag |= 2147483648U;
        if ( flag )
        {
            AppMain.GmSoundPauseStageBGM( 0 );
        }
        if ( flag2 )
        {
            AppMain.gmSoundSetBGMFadeEnd( AppMain.gm_sound_bgm_scb );
            AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 0f );
            AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, true );
        }
    }

    // Token: 0x06000830 RID: 2096 RVA: 0x00047E59 File Offset: 0x00046059
    public static void GmSoundPlayJingle( uint jngl_idx )
    {
        AppMain.GmSoundPlayJingle( jngl_idx, 0 );
    }

    // Token: 0x06000831 RID: 2097 RVA: 0x00047E64 File Offset: 0x00046064
    public static void GmSoundPlayJingle( uint jngl_idx, int fade_frame )
    {
        AppMain.GsSoundScbSetVolume( AppMain.gm_sound_jingle_scb, 1f );
        AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_jingle_scb, false );
        AppMain.GsSoundStopBgm( AppMain.gm_sound_jingle_scb );
        AppMain.GsSoundPlayBgm( AppMain.gm_sound_jingle_scb, AppMain.gm_sound_jingle_name_list[( int )( ( UIntPtr )jngl_idx )], fade_frame );
        AppMain.gm_sound_jingle_scb.flag |= 2147483648U;
    }

    // Token: 0x06000832 RID: 2098 RVA: 0x00047EBE File Offset: 0x000460BE
    private static void GmSoundStopJingle( int fade_frame )
    {
        AppMain.GsSoundStopBgm( AppMain.gm_sound_jingle_scb, fade_frame );
    }

    // Token: 0x06000833 RID: 2099 RVA: 0x00047ECC File Offset: 0x000460CC
    private static void GmSoundPlayBGMJingle( uint jngl_idx, int fade_frame )
    {
        AppMain.GsSoundScbSetVolume( AppMain.gm_sound_jingle_bgm_scb, 1f );
        AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_jingle_bgm_scb, false );
        AppMain.GsSoundStopBgm( AppMain.gm_sound_jingle_bgm_scb );
        AppMain.GsSoundPlayBgm( AppMain.gm_sound_jingle_bgm_scb, AppMain.gm_sound_jingle_name_list[( int )( ( UIntPtr )jngl_idx )], fade_frame );
        AppMain.gm_sound_jingle_bgm_scb.flag |= 2147483648U;
    }

    // Token: 0x06000834 RID: 2100 RVA: 0x00047F26 File Offset: 0x00046126
    private static void GmSoundStopBGMJingle( int fade_frame )
    {
        AppMain.GsSoundStopBgm( AppMain.gm_sound_jingle_bgm_scb, fade_frame );
    }

    // Token: 0x06000835 RID: 2101 RVA: 0x00047F33 File Offset: 0x00046133
    private static void GmSoundPauseBGMJingle( int fade_frame )
    {
        AppMain.GsSoundPauseBgm( AppMain.gm_sound_jingle_bgm_scb, fade_frame );
    }

    // Token: 0x06000836 RID: 2102 RVA: 0x00047F40 File Offset: 0x00046140
    private static void GmSoundResumeBGMJingle( int fade_frame )
    {
        AppMain.GsSoundResumeBgm( AppMain.gm_sound_jingle_bgm_scb, fade_frame );
    }

    // Token: 0x06000837 RID: 2103 RVA: 0x00047F4D File Offset: 0x0004614D
    private static void GmSoundSetVolumeSE( float volume )
    {
        AppMain.GsSoundSetVolume( 1, volume );
    }

    // Token: 0x06000838 RID: 2104 RVA: 0x00047F56 File Offset: 0x00046156
    private static void GmSoundSetVolumeBGM( float volume )
    {
        AppMain.GsSoundSetVolume( 0, volume );
    }

    // Token: 0x06000839 RID: 2105 RVA: 0x00047F60 File Offset: 0x00046160
    private static void GmSoundPlayJingleObore()
    {
        if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_jingle_bgm_scb ) )
        {
            return;
        }
        if ( ( AppMain.gm_sound_flag & 1U ) != 0U )
        {
            return;
        }
        if ( !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            AppMain.GmSoundPauseStageBGM( 0 );
        }
        AppMain.GmSoundPlayBGMJingle( 6U, 0 );
        if ( ( AppMain.gm_sound_flag & 32U ) != 0U )
        {
            AppMain.gmSoundSetBGMFadeEnd( AppMain.gm_sound_jingle_bgm_scb );
            AppMain.GsSoundScbSetVolume( AppMain.gm_sound_jingle_bgm_scb, 0f );
            AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_jingle_bgm_scb, true );
        }
        AppMain.gm_sound_flag |= 1U;
    }

    // Token: 0x0600083A RID: 2106 RVA: 0x00047FD8 File Offset: 0x000461D8
    private static void GmSoundStopJingleObore()
    {
        if ( ( AppMain.gm_sound_flag & 1U ) == 0U )
        {
            return;
        }
        if ( !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_jingle_bgm_scb ) && ( AppMain.gm_sound_flag & 32U ) == 0U )
        {
            AppMain.GmSoundStopBGMJingle( 15 );
        }
        else
        {
            AppMain.GmSoundStopBGMJingle( 0 );
        }
        if ( ( AppMain.gm_sound_flag & 2147483648U ) == 0U )
        {
            AppMain.GmSoundResumeStageBGM( 0 );
        }
        AppMain.gm_sound_flag &= 4294967294U;
    }

    // Token: 0x0600083B RID: 2107 RVA: 0x00048034 File Offset: 0x00046234
    private static void GmSoundPlayJingleInvincible()
    {
        if ( ( AppMain.gm_sound_flag & 4U ) != 0U )
        {
            return;
        }
        if ( !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            AppMain.GmSoundPauseStageBGM( 0 );
        }
        AppMain.GmSoundPlayBGMJingle( 4U, 0 );
        if ( ( AppMain.gm_sound_flag & 32U ) != 0U )
        {
            AppMain.gmSoundSetBGMFadeEnd( AppMain.gm_sound_jingle_bgm_scb );
            AppMain.GsSoundScbSetVolume( AppMain.gm_sound_jingle_bgm_scb, 0f );
            AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_jingle_bgm_scb, true );
        }
        AppMain.gm_sound_flag |= 4U;
        AppMain.gm_sound_flag &= 4294967294U;
    }

    // Token: 0x0600083C RID: 2108 RVA: 0x000480AC File Offset: 0x000462AC
    private static void GmSoundStopJingleInvincible()
    {
        if ( ( AppMain.gm_sound_flag & 4U ) == 0U )
        {
            return;
        }
        if ( !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_jingle_bgm_scb ) && ( AppMain.gm_sound_flag & 32U ) == 0U )
        {
            AppMain.GmSoundStopBGMJingle( 0 );
        }
        else
        {
            AppMain.GmSoundStopBGMJingle( 0 );
        }
        if ( ( AppMain.gm_sound_flag & 2147483648U ) == 0U )
        {
            AppMain.GmSoundResumeStageBGM( 0 );
        }
        AppMain.gm_sound_flag &= 4294967291U;
    }

    // Token: 0x0600083D RID: 2109 RVA: 0x00048108 File Offset: 0x00046308
    private static bool GmBGMIsAlreadyPlaying()
    {
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        return ams_CRIAUDIO_INTERFACE.auply[AppMain.gm_sound_bgm_scb.auply_no] != null && ams_CRIAUDIO_INTERFACE.auply[AppMain.gm_sound_bgm_scb.auply_no].se_name == AppMain.gm_sound_bgm_name_list[( int )AppMain.g_gs_main_sys_info.stage_id] && !ams_CRIAUDIO_INTERFACE.auply[AppMain.gm_sound_bgm_scb.auply_no].IsPaused();
    }

    // Token: 0x0600083E RID: 2110 RVA: 0x00048176 File Offset: 0x00046376
    private static void GmSoundPlayJingle1UP( bool ret_last_sound )
    {
        if ( ret_last_sound )
        {
            AppMain.gmSoundPlay1ShotJingle( 0U, 0, 0, 0 );
            return;
        }
        AppMain.GmSoundPlayJingle( 0U, 0 );
    }

    // Token: 0x0600083F RID: 2111 RVA: 0x0004818C File Offset: 0x0004638C
    private static void GmSoundPlayGameOver()
    {
        AppMain.GmSoundStopStageBGM( 15 );
        AppMain.GmSoundStopBGMJingle( 15 );
        if ( AppMain.gm_sound_1shot_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_sound_1shot_tcb );
        }
        AppMain.GmSoundPlayJingle( 7U, 0 );
    }

    // Token: 0x06000840 RID: 2112 RVA: 0x000481B4 File Offset: 0x000463B4
    private static void GmSoundPlayClear()
    {
        AppMain.GmSoundStopStageBGM( 15 );
        AppMain.GmSoundStopBGMJingle( 15 );
        if ( AppMain.gm_sound_1shot_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_sound_1shot_tcb );
        }
        AppMain.GmSoundPlayJingle( 1U, 0 );
    }

    // Token: 0x06000841 RID: 2113 RVA: 0x000481DC File Offset: 0x000463DC
    private static void GmSoundPlayClearFinal()
    {
        AppMain.GmSoundStopStageBGM( 15 );
        AppMain.GmSoundStopBGMJingle( 15 );
        if ( AppMain.gm_sound_1shot_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_sound_1shot_tcb );
        }
        AppMain.GmSoundPlayJingle( 2U, 0 );
    }

    // Token: 0x06000842 RID: 2114 RVA: 0x00048204 File Offset: 0x00046404
    private static void GmSoundAllPause()
    {
        AppMain.gm_sound_flag &= 4043309055U;
        if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_jingle_scb ) && !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_jingle_scb ) )
        {
            AppMain.GsSoundPauseBgm( AppMain.gm_sound_jingle_scb, 0 );
            AppMain.gm_sound_flag |= 67108864U;
        }
        if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_jingle_bgm_scb ) && !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_jingle_bgm_scb ) )
        {
            AppMain.GsSoundPauseBgm( AppMain.gm_sound_jingle_bgm_scb, 0 );
            AppMain.gm_sound_flag |= 33554432U;
        }
        if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_bgm_scb ) && !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            AppMain.GsSoundPauseBgm( AppMain.gm_sound_bgm_scb, 0 );
            AppMain.gm_sound_flag |= 16777216U;
        }
        AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_sub_scb, 0 );
        AppMain.GsSoundPauseSe( 128U );
        AppMain.gm_sound_flag |= 134217728U;
    }

    // Token: 0x06000843 RID: 2115 RVA: 0x000482E0 File Offset: 0x000464E0
    private static void GmSoundAllResume()
    {
        if ( ( AppMain.gm_sound_flag & 67108864U ) != 0U )
        {
            AppMain.GsSoundResumeBgm( AppMain.gm_sound_jingle_scb, 0 );
        }
        else if ( ( AppMain.gm_sound_flag & 33554432U ) != 0U )
        {
            AppMain.GsSoundResumeBgm( AppMain.gm_sound_jingle_bgm_scb, 0 );
        }
        else if ( ( AppMain.gm_sound_flag & 16777216U ) != 0U )
        {
            AppMain.GsSoundResumeBgm( AppMain.gm_sound_bgm_scb, 0 );
        }
        AppMain.GsSoundResumeSe( 128U );
        AppMain.gm_sound_flag &= 4043309055U;
    }

    // Token: 0x06000844 RID: 2116 RVA: 0x0004835C File Offset: 0x0004655C
    private static void gmSoundPlay1ShotJingle( uint jngl_idx, int jingle_fade_in_frame, int bgm_fade_out_frame, int bgm_fade_in_frame )
    {
        AppMain.gm_sound_flag |= 2147483648U;
        if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_bgm_scb ) && !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            AppMain.GmSoundPauseStageBGM( bgm_fade_out_frame );
        }
        if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_jingle_bgm_scb ) && !AppMain.GsSoundIsBgmPause( AppMain.gm_sound_jingle_bgm_scb ) )
        {
            AppMain.GmSoundPauseBGMJingle( bgm_fade_out_frame );
        }
        if ( AppMain.gm_sound_1shot_tcb != null )
        {
            AppMain.GmSoundStopJingle( 0 );
        }
        else
        {
            AppMain.gm_sound_1shot_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSound1ShotJingleFunc ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSound1ShotJingleDest ), 0U, 0, 32767U, 5, () => new AppMain.GMS_SOUND_1SHOT_JINGLE_WORK(), "GM_SOUND_1SH" );
        }
        AppMain.GMS_SOUND_1SHOT_JINGLE_WORK gms_SOUND_1SHOT_JINGLE_WORK = (AppMain.GMS_SOUND_1SHOT_JINGLE_WORK)AppMain.gm_sound_1shot_tcb.work;
        gms_SOUND_1SHOT_JINGLE_WORK.Clear();
        AppMain.GmSoundPlayJingle( jngl_idx, jingle_fade_in_frame );
        gms_SOUND_1SHOT_JINGLE_WORK.bgm_fade_in_frame = bgm_fade_in_frame;
    }

    // Token: 0x06000845 RID: 2117 RVA: 0x00048434 File Offset: 0x00046634
    private static void gmSound1ShotJingleFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( ( AppMain.gm_sound_flag & 134217728U ) != 0U )
        {
            return;
        }
        AppMain.GMS_SOUND_1SHOT_JINGLE_WORK gms_SOUND_1SHOT_JINGLE_WORK = (AppMain.GMS_SOUND_1SHOT_JINGLE_WORK)AppMain.gm_sound_1shot_tcb.work;
        if ( AppMain.GsSoundIsBgmStop( AppMain.gm_sound_jingle_scb ) )
        {
            AppMain.GmSoundStopJingle( 0 );
            AppMain.gm_sound_flag &= 2147483647U;
            if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_jingle_bgm_scb ) && AppMain.GsSoundIsBgmPause( AppMain.gm_sound_jingle_bgm_scb ) )
            {
                AppMain.GmSoundResumeBGMJingle( gms_SOUND_1SHOT_JINGLE_WORK.bgm_fade_in_frame );
            }
            else if ( !AppMain.GsSoundIsBgmStop( AppMain.gm_sound_bgm_scb ) && AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
            {
                AppMain.GmSoundResumeStageBGM( gms_SOUND_1SHOT_JINGLE_WORK.bgm_fade_in_frame );
            }
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x06000846 RID: 2118 RVA: 0x000484CF File Offset: 0x000466CF
    private static void gmSound1ShotJingleDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_sound_1shot_tcb = null;
    }

    // Token: 0x06000847 RID: 2119 RVA: 0x000484E0 File Offset: 0x000466E0
    private static void gmSoundSetBGMFade( AppMain.GSS_SND_SCB snd_scb, float start_vol, float end_vol, int frame )
    {
        if ( AppMain.GsSoundIsBgmStop( AppMain.gm_sound_bgm_scb ) )
        {
            return;
        }
        if ( AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
        {
            return;
        }
        AppMain.gmSoundSetBGMFadeEnd( snd_scb );
        if ( frame <= 0 )
        {
            frame = 1;
        }
        AppMain.GMS_SOUND_BGM_FADE_MGR_WORK gms_SOUND_BGM_FADE_MGR_WORK;
        if ( AppMain.gm_sound_bgm_fade_tcb == null )
        {
            AppMain.gm_sound_bgm_fade_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSoundBGMFadeFunc ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmSoundBGMFadeDest ), 0U, 0, 32767U, 5, () => new AppMain.GMS_SOUND_BGM_FADE_MGR_WORK(), "GM_SOUND_BFADE" );
            gms_SOUND_BGM_FADE_MGR_WORK = ( AppMain.GMS_SOUND_BGM_FADE_MGR_WORK )AppMain.gm_sound_bgm_fade_tcb.work;
            gms_SOUND_BGM_FADE_MGR_WORK.Clear();
        }
        gms_SOUND_BGM_FADE_MGR_WORK = ( AppMain.GMS_SOUND_BGM_FADE_MGR_WORK )AppMain.gm_sound_bgm_fade_tcb.work;
        AppMain.gmSoundBGMFadeAttachList( gms_SOUND_BGM_FADE_MGR_WORK, new AppMain.GMS_SOUND_BGM_FADE_WORK
        {
            snd_scb = snd_scb,
            start_vol = start_vol,
            end_vol = end_vol,
            frame = frame,
            fade_spd = ( end_vol - start_vol ) / ( float )frame,
            now_vol = start_vol
        } );
    }

    // Token: 0x06000848 RID: 2120 RVA: 0x000485CC File Offset: 0x000467CC
    private static void gmSoundSetBGMFadeEnd( AppMain.GSS_SND_SCB snd_scb )
    {
        if ( AppMain.gm_sound_bgm_fade_tcb != null )
        {
            AppMain.GMS_SOUND_BGM_FADE_MGR_WORK gms_SOUND_BGM_FADE_MGR_WORK = (AppMain.GMS_SOUND_BGM_FADE_MGR_WORK)AppMain.gm_sound_bgm_fade_tcb.work;
            AppMain.GMS_SOUND_BGM_FADE_WORK next;
            for ( AppMain.GMS_SOUND_BGM_FADE_WORK gms_SOUND_BGM_FADE_WORK = gms_SOUND_BGM_FADE_MGR_WORK.head; gms_SOUND_BGM_FADE_WORK != null; gms_SOUND_BGM_FADE_WORK = next )
            {
                next = gms_SOUND_BGM_FADE_WORK.next;
                if ( gms_SOUND_BGM_FADE_WORK.snd_scb == snd_scb )
                {
                    AppMain.gmSoundBGMFadeDetachList( gms_SOUND_BGM_FADE_MGR_WORK, gms_SOUND_BGM_FADE_WORK );
                }
            }
            if ( gms_SOUND_BGM_FADE_MGR_WORK.num <= 0 )
            {
                AppMain.mtTaskClearTcb( AppMain.gm_sound_bgm_fade_tcb );
            }
        }
    }

    // Token: 0x06000849 RID: 2121 RVA: 0x0004862C File Offset: 0x0004682C
    private static void gmSoundBGMFadeFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SOUND_BGM_FADE_MGR_WORK gms_SOUND_BGM_FADE_MGR_WORK = (AppMain.GMS_SOUND_BGM_FADE_MGR_WORK)tcb.work;
        AppMain.GMS_SOUND_BGM_FADE_WORK next;
        for ( AppMain.GMS_SOUND_BGM_FADE_WORK gms_SOUND_BGM_FADE_WORK = gms_SOUND_BGM_FADE_MGR_WORK.head; gms_SOUND_BGM_FADE_WORK != null; gms_SOUND_BGM_FADE_WORK = next )
        {
            next = gms_SOUND_BGM_FADE_WORK.next;
            gms_SOUND_BGM_FADE_WORK.now_vol += gms_SOUND_BGM_FADE_WORK.fade_spd;
            gms_SOUND_BGM_FADE_WORK.frame--;
            if ( gms_SOUND_BGM_FADE_WORK.frame <= 0 )
            {
                gms_SOUND_BGM_FADE_WORK.now_vol = gms_SOUND_BGM_FADE_WORK.end_vol;
            }
            AppMain.GsSoundScbSetVolume( gms_SOUND_BGM_FADE_WORK.snd_scb, gms_SOUND_BGM_FADE_WORK.now_vol );
            if ( gms_SOUND_BGM_FADE_WORK.frame <= 0 || AppMain.GsSoundIsBgmStop( gms_SOUND_BGM_FADE_WORK.snd_scb ) )
            {
                if ( gms_SOUND_BGM_FADE_WORK.now_vol > 0f )
                {
                    AppMain.GsSoundScbSetSeqMute( gms_SOUND_BGM_FADE_WORK.snd_scb, false );
                }
                else
                {
                    AppMain.GsSoundScbSetSeqMute( gms_SOUND_BGM_FADE_WORK.snd_scb, true );
                }
                AppMain.gmSoundBGMFadeDetachList( gms_SOUND_BGM_FADE_MGR_WORK, gms_SOUND_BGM_FADE_WORK );
            }
        }
        if ( gms_SOUND_BGM_FADE_MGR_WORK.num <= 0 )
        {
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x0600084A RID: 2122 RVA: 0x000486FC File Offset: 0x000468FC
    private static void gmSoundBGMFadeDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SOUND_BGM_FADE_MGR_WORK gms_SOUND_BGM_FADE_MGR_WORK = (AppMain.GMS_SOUND_BGM_FADE_MGR_WORK)tcb.work;
        AppMain.GMS_SOUND_BGM_FADE_WORK next;
        for ( AppMain.GMS_SOUND_BGM_FADE_WORK gms_SOUND_BGM_FADE_WORK = gms_SOUND_BGM_FADE_MGR_WORK.head; gms_SOUND_BGM_FADE_WORK != null; gms_SOUND_BGM_FADE_WORK = next )
        {
            next = gms_SOUND_BGM_FADE_WORK.next;
            AppMain.gmSoundBGMFadeDetachList( gms_SOUND_BGM_FADE_MGR_WORK, gms_SOUND_BGM_FADE_WORK );
        }
        if ( AppMain.gm_sound_bgm_fade_tcb == tcb )
        {
            AppMain.gm_sound_bgm_fade_tcb = null;
        }
    }

    // Token: 0x0600084B RID: 2123 RVA: 0x00048744 File Offset: 0x00046944
    private static void gmSoundBGMFadeAttachList( AppMain.GMS_SOUND_BGM_FADE_MGR_WORK mgr_work, AppMain.GMS_SOUND_BGM_FADE_WORK fade_work )
    {
        if ( mgr_work.tail != null )
        {
            fade_work.prev = mgr_work.tail;
            mgr_work.tail.next = fade_work;
            mgr_work.tail = fade_work;
        }
        else
        {
            mgr_work.head = fade_work;
            mgr_work.tail = fade_work;
        }
        mgr_work.num++;
    }

    // Token: 0x0600084C RID: 2124 RVA: 0x00048798 File Offset: 0x00046998
    private static void gmSoundBGMFadeDetachList( AppMain.GMS_SOUND_BGM_FADE_MGR_WORK mgr_work, AppMain.GMS_SOUND_BGM_FADE_WORK fade_work )
    {
        if ( fade_work.prev != null )
        {
            fade_work.prev.next = fade_work.next;
        }
        else
        {
            mgr_work.head = fade_work.next;
        }
        if ( fade_work.next != null )
        {
            fade_work.next.prev = fade_work.prev;
        }
        else
        {
            mgr_work.tail = fade_work.prev;
        }
        mgr_work.num--;
    }

    // Token: 0x0600084D RID: 2125 RVA: 0x00048804 File Offset: 0x00046A04
    private static void gmSoundBGMWinBossFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_SOUND_BGM_WIN_BOSS_MGR_WORK gms_SOUND_BGM_WIN_BOSS_MGR_WORK = (AppMain.GMS_SOUND_BGM_WIN_BOSS_MGR_WORK)tcb.work;
        if ( ( AppMain.gm_sound_flag & 134217728U ) != 0U )
        {
            return;
        }
        gms_SOUND_BGM_WIN_BOSS_MGR_WORK.timer--;
        if ( gms_SOUND_BGM_WIN_BOSS_MGR_WORK.timer <= 0 )
        {
            bool flag = false;
            bool flag2 = false;
            AppMain.GsSoundStopBgm( AppMain.gm_sound_bgm_sub_scb, 0 );
            if ( AppMain.GsSoundIsBgmPause( AppMain.gm_sound_bgm_scb ) )
            {
                flag = true;
            }
            if ( ( AppMain.gm_sound_flag & 80U ) != 0U )
            {
                flag2 = true;
            }
            if ( flag || flag2 )
            {
                AppMain.GmSoundStopStageBGM( 0 );
            }
            else
            {
                AppMain.GmSoundStopStageBGM( 30 );
            }
            AppMain.GSS_SND_SCB gss_SND_SCB = AppMain.gm_sound_bgm_scb;
            AppMain.gm_sound_bgm_scb = AppMain.gm_sound_bgm_sub_scb;
            AppMain.gm_sound_bgm_sub_scb = gss_SND_SCB;
            AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 1f );
            AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, false );
            AppMain.GsSoundPlayBgm( AppMain.gm_sound_bgm_scb, AppMain.gm_sound_bgm_win_boss_name_list[AppMain.GMM_MAIN_GET_ZONE_TYPE()], 30 );
            AppMain.gm_sound_bgm_scb.flag |= 2147483648U;
            if ( flag )
            {
                AppMain.GmSoundPauseStageBGM( 0 );
            }
            if ( flag2 )
            {
                AppMain.gmSoundSetBGMFadeEnd( AppMain.gm_sound_bgm_scb );
                AppMain.GsSoundScbSetVolume( AppMain.gm_sound_bgm_scb, 0f );
                AppMain.GsSoundScbSetSeqMute( AppMain.gm_sound_bgm_scb, true );
            }
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x0600084E RID: 2126 RVA: 0x00048915 File Offset: 0x00046B15
    private static void gmSoundBGMWinBossDest( AppMain.MTS_TASK_TCB tcb )
    {
        if ( tcb == AppMain.gm_sound_bgm_win_boss_tcb )
        {
            AppMain.gm_sound_bgm_win_boss_tcb = null;
        }
    }
}
