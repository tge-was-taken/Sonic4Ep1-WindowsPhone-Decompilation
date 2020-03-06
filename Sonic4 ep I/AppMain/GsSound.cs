using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Globalization;
using Microsoft.Xna.Framework;

public partial class AppMain
{
    // Token: 0x02000087 RID: 135
    public class SOUND_TABLE
    {
        // Token: 0x06001E5C RID: 7772 RVA: 0x0013A4C0 File Offset: 0x001386C0
        public SOUND_TABLE( int count )
        {
            this.count = count;
            this.volume = new float[count];
            this.filename = new string[count];
            this.loop = new bool[count];
            this.loopStart = new int[count];
            this.loopEnd = new int[count];
            this.pitch = new float[count];
            this.asiac = new AppMain.AISAC_LIST[count];
        }

        // Token: 0x04004A28 RID: 18984
        public int cue;

        // Token: 0x04004A29 RID: 18985
        public int type;

        // Token: 0x04004A2A RID: 18986
        public string name;

        // Token: 0x04004A2B RID: 18987
        public string uid;

        // Token: 0x04004A2C RID: 18988
        public float[] volume;

        // Token: 0x04004A2D RID: 18989
        public string[] filename;

        // Token: 0x04004A2E RID: 18990
        public bool[] loop;

        // Token: 0x04004A2F RID: 18991
        public int[] loopStart;

        // Token: 0x04004A30 RID: 18992
        public int[] loopEnd;

        // Token: 0x04004A31 RID: 18993
        public float[] pitch;

        // Token: 0x04004A32 RID: 18994
        public int count;

        // Token: 0x04004A33 RID: 18995
        public AppMain.AISAC_LIST[] asiac;
    }

    // Token: 0x02000080 RID: 128
    public class GSS_SND_SYS_MAIN_INFO
    {
        // Token: 0x06001E3E RID: 7742 RVA: 0x00139860 File Offset: 0x00137A60
        internal void Clear()
        {
            this.flag = 0U;
            this.system_cnt_vol = 0f;
            this.suspend_wait_count = 0;
        }

        // Token: 0x040049F2 RID: 18930
        public uint flag;

        // Token: 0x040049F3 RID: 18931
        public float system_cnt_vol;

        // Token: 0x040049F4 RID: 18932
        public int suspend_wait_count;
    }

    // Token: 0x02000081 RID: 129
    public class GSS_SND_CTRL_PARAM : AppMain.IClearable
    {
        // Token: 0x06001E40 RID: 7744 RVA: 0x00139884 File Offset: 0x00137A84
        public void Clear()
        {
            this.fade_state = 0U;
            this.fade_frame_max = ( this.fade_frame_cnt = 0 );
            this.pitch = ( this.fade_vol = ( this.fade_sub_vol = ( this.volume = 0f ) ) );
        }

        // Token: 0x040049F5 RID: 18933
        public uint fade_state;

        // Token: 0x040049F6 RID: 18934
        public int fade_frame_max;

        // Token: 0x040049F7 RID: 18935
        public int fade_frame_cnt;

        // Token: 0x040049F8 RID: 18936
        public float fade_vol;

        // Token: 0x040049F9 RID: 18937
        public float fade_sub_vol;

        // Token: 0x040049FA RID: 18938
        public float volume;

        // Token: 0x040049FB RID: 18939
        public float pitch;
    }

    // Token: 0x02000082 RID: 130
    public class GSS_SND_SCB
    {
        // Token: 0x06001E42 RID: 7746 RVA: 0x001398D6 File Offset: 0x00137AD6
        internal void Clear()
        {
            this.flag = 0U;
            this.snd_data_type = 0;
            this.snd_ctrl_param.Clear();
            this.auply_no = 0;
            this.cur_pause_level = 0U;
        }

        // Token: 0x040049FC RID: 18940
        public uint flag;

        // Token: 0x040049FD RID: 18941
        public int snd_data_type;

        // Token: 0x040049FE RID: 18942
        public readonly AppMain.GSS_SND_CTRL_PARAM snd_ctrl_param = new AppMain.GSS_SND_CTRL_PARAM();

        // Token: 0x040049FF RID: 18943
        public int auply_no;

        // Token: 0x04004A00 RID: 18944
        public uint cur_pause_level;

        // Token: 0x04004A01 RID: 18945
        public AppMain.GSS_SND_SCB.error_state noplay_error_state;

        // Token: 0x02000083 RID: 131
        public struct error_state
        {
            // Token: 0x04004A02 RID: 18946
            public uint sample;

            // Token: 0x04004A03 RID: 18947
            public uint counter;
        }
    }



    // Token: 0x02000085 RID: 133
    public class GSS_SND_SE_HANDLE : AppMain.IClearable
    {
        // Token: 0x06001E59 RID: 7769 RVA: 0x0013A456 File Offset: 0x00138656
        public void Clear()
        {
            this.flag = 0U;
            this.snd_ctrl_param.Clear();
            this.cur_pause_level = 0U;
            this.au_player.Destroy();
            this.au_player = null;
        }

        // Token: 0x04004A21 RID: 18977
        public uint flag;

        // Token: 0x04004A22 RID: 18978
        public AppMain.CriAuPlayer au_player;

        // Token: 0x04004A23 RID: 18979
        public readonly AppMain.GSS_SND_CTRL_PARAM snd_ctrl_param = new AppMain.GSS_SND_CTRL_PARAM();

        // Token: 0x04004A24 RID: 18980
        public uint cur_pause_level;
    }

    // Token: 0x02000086 RID: 134
    public class AISAC_LIST
    {
        // Token: 0x06001E5B RID: 7771 RVA: 0x0013A496 File Offset: 0x00138696
        public AISAC_LIST( int count )
        {
            this.count = count;
            this.types = new int[count];
            this.values = new float[count][][];
        }

        // Token: 0x04004A25 RID: 18981
        public int count;

        // Token: 0x04004A26 RID: 18982
        public int[] types;

        // Token: 0x04004A27 RID: 18983
        public float[][][] values;
    }

    // Token: 0x060002BF RID: 703 RVA: 0x00016F3C File Offset: 0x0001513C
    private static bool _FillBGMCache( int iListIndex )
    {
        string[] array = AppMain.bgmLists[iListIndex];
        for ( int i = 0; i < array.Length; i++ )
        {
            AppMain.SOUND_TABLE sound_TABLE = AppMain.sound_bgm_list[array[i]];
            Song song = Sonic4Ep1.pInstance.Content.Load<Song>("Sound/" + sound_TABLE.filename[0]);
            AppMain.bgmPreloadedList.Add( sound_TABLE.filename[0], song );
        }
        return true;
    }

    // Token: 0x060002C0 RID: 704 RVA: 0x00016FA4 File Offset: 0x000151A4
    private static Song _GetPreloadedBGM( string sName )
    {
        Song result;
        if ( !AppMain.bgmPreloadedList.TryGetValue( sName, out result ) )
        {
            return null;
        }
        return result;
    }

    // Token: 0x060002C1 RID: 705 RVA: 0x00016FC8 File Offset: 0x000151C8
    public static bool PrepareBGMForLevel( int iLevel )
    {
        if ( AppMain.m_iBGMPreparedLevel == iLevel )
        {
            return true;
        }
        AppMain.bgmPreloadedList.Clear();
        AppMain._FillBGMCache( 0 );
        int num = 0;
        if ( iLevel >= 0 && iLevel <= 3 )
        {
            num = 1;
        }
        else if ( iLevel >= 4 && iLevel <= 7 )
        {
            num = 2;
        }
        else if ( iLevel >= 8 && iLevel <= 11 )
        {
            num = 3;
        }
        else if ( iLevel >= 12 && iLevel <= 15 )
        {
            num = 4;
        }
        if ( num != 0 )
        {
            AppMain._FillBGMCache( num );
        }
        AppMain.m_iBGMPreparedLevel = iLevel;
        return true;
    }

    // Token: 0x060002C2 RID: 706 RVA: 0x00017034 File Offset: 0x00015234
    private static bool GsSoundIsBgmStop( AppMain.GSS_SND_SCB scb )
    {
        return ( scb.flag & 1U ) == 0U || ( scb.flag & 2U ) != 0U;
    }

    // Token: 0x060002C3 RID: 707 RVA: 0x0001704D File Offset: 0x0001524D
    private static bool GsSoundIsBgmPause( AppMain.GSS_SND_SCB scb )
    {
        return ( scb.flag & 1U ) != 0U && scb.cur_pause_level == 2147483647U && ( scb.flag & 4U ) != 0U;
    }

    // Token: 0x060002C4 RID: 708 RVA: 0x00017074 File Offset: 0x00015274
    private static void fillSoundTable( string filename, Dictionary<string, AppMain.SOUND_TABLE> list )
    {
        using ( Stream stream = TitleContainer.OpenStream( "Content\\SOUND\\" + filename ) )
        {
            using ( StreamReader streamReader = new StreamReader( stream ) )
            {
                while ( streamReader.Peek() >= 0 )
                {
                    string text = streamReader.ReadLine();
                    string[] array = text.Split(new char[]
                    {
                        '|'
                    });
                    int count = array.Length;
                    AppMain.SOUND_TABLE sound_TABLE = new AppMain.SOUND_TABLE(count);
                    for ( int i = 0; i < array.Length; i++ )
                    {
                        int num = array[i].IndexOf("Aisac");
                        if ( num != -1 )
                        {
                            string text2 = array[i].Substring(num);
                            array[i] = array[i].Substring( 0, num - 1 );
                            string[] array2 = text2.Split(new char[]
                            {
                                '#'
                            });
                            sound_TABLE.asiac[i] = new AppMain.AISAC_LIST( array2.Length - 1 );
                            for ( int j = 1; j < array2.Length; j++ )
                            {
                                string[] array3 = null;
                                if ( array2[j].StartsWith( "Volume" ) )
                                {
                                    sound_TABLE.asiac[i].types[j - 1] = 0;
                                    array3 = array2[j].Substring( 7 ).Split( new char[]
                                    {
                                        ' '
                                    } );
                                }
                                else if ( array2[j].StartsWith( "Pitch" ) )
                                {
                                    sound_TABLE.asiac[i].types[j - 1] = 1;
                                    array3 = array2[j].Substring( 6 ).Split( new char[]
                                    {
                                        ' '
                                    } );
                                }
                                sound_TABLE.asiac[i].values[j - 1] = new float[array3.Length][];
                                for ( int k = 0; k < array3.Length; k++ )
                                {
                                    string[] array4 = array3[k].Split(new char[]
                                    {
                                        ','
                                    });
                                    sound_TABLE.asiac[i].values[j - 1][k] = new float[2];
                                    sound_TABLE.asiac[i].values[j - 1][k][0] = float.Parse( array4[0], CultureInfo.InvariantCulture );
                                    sound_TABLE.asiac[i].values[j - 1][k][1] = ( ( sound_TABLE.asiac[i].types[j - 1] == 1 ) ? ( float.Parse( array4[1], CultureInfo.InvariantCulture ) / 1000f ) : float.Parse( array4[1], CultureInfo.InvariantCulture ) );
                                }
                            }
                        }
                        string[] array5 = array[i].Split(new char[]
                        {
                            ','
                        });
                        if ( i == 0 )
                        {
                            sound_TABLE.name = array5[0];
                            sound_TABLE.cue = int.Parse( array5[1] );
                            sound_TABLE.uid = array5[2];
                        }
                        sound_TABLE.volume[i] = float.Parse( array5[( i == 0 ) ? 3 : 0], CultureInfo.InvariantCulture );
                        if ( sound_TABLE.volume[i] > 1f )
                        {
                            sound_TABLE.volume[i] = 1f;
                        }
                        else if ( sound_TABLE.volume[i] < -1f )
                        {
                            sound_TABLE.volume[i] = -1f;
                        }
                        sound_TABLE.pitch[i] = ( float )int.Parse( array5[( i == 0 ) ? 4 : 1] ) / 1000f;
                        sound_TABLE.filename[i] = array5[( i == 0 ) ? 5 : 2];
                        sound_TABLE.loop[i] = ( ( int.Parse( array5[( i == 0 ) ? 6 : 3] ) == 1 ) ? true : false );
                        sound_TABLE.loopStart[i] = int.Parse( array5[( i == 0 ) ? 7 : 4] );
                        sound_TABLE.loopEnd[i] = int.Parse( array5[( i == 0 ) ? 8 : 5] );
                    }
                    list[sound_TABLE.name] = sound_TABLE;
                }
            }
        }
    }

    // Token: 0x060002C5 RID: 709 RVA: 0x00017480 File Offset: 0x00015680
    public static void MediaPlayer_MediaStateChanged( object sender, EventArgs e )
    {
        if ( AppMain.g_ao_sys_global.is_playing_device_bgm_music )
        {
            return;
        }
        MediaState state = MediaPlayer.State;
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        string text = (MediaPlayer.Queue.ActiveSong != null) ? MediaPlayer.Queue.ActiveSong.Name : null;
        for ( int i = 0; i < ams_CRIAUDIO_INTERFACE.auply.Length; i++ )
        {
            if ( text != null && ams_CRIAUDIO_INTERFACE.auply[i].se_name != null && ams_CRIAUDIO_INTERFACE.auply[i].se_name != null && text == "Sound\\" + AppMain.sound_bgm_list[ams_CRIAUDIO_INTERFACE.auply[i].se_name].filename[0] )
            {
                double totalMilliseconds = AppMain.CriAuPlayer.m_songBGM.Duration.TotalMilliseconds;
                double totalMilliseconds2 = MediaPlayer.PlayPosition.TotalMilliseconds;
                if ( state == MediaState.Paused && ams_CRIAUDIO_INTERFACE.auply[i].m_stGMState != MediaState.Paused )
                {
                    if ( totalMilliseconds2 + 1.0 >= totalMilliseconds || totalMilliseconds2 == 0.0 )
                    {
                        if ( !ams_CRIAUDIO_INTERFACE.auply[i].m_bLoop && ams_CRIAUDIO_INTERFACE.auply[i].se_name.IndexOf( "_speedup" ) != -1 )
                        {
                            string cue = ams_CRIAUDIO_INTERFACE.auply[i].se_name.Replace("_speedup", "");
                            ams_CRIAUDIO_INTERFACE.auply[i].SetCue( cue );
                            ams_CRIAUDIO_INTERFACE.auply[i].Play();
                            return;
                        }
                        ams_CRIAUDIO_INTERFACE.auply[i].m_stGMState = MediaState.Stopped;
                        ams_CRIAUDIO_INTERFACE.auply[i].status = 3;
                        return;
                    }
                    else if ( ams_CRIAUDIO_INTERFACE.auply[i].m_stGMState == MediaState.Playing )
                    {
                        MediaPlayer.Resume();
                        return;
                    }
                }
                else if ( state == MediaState.Stopped && ams_CRIAUDIO_INTERFACE.auply[i].m_stGMState != MediaState.Stopped )
                {
                    if ( totalMilliseconds2 == 0.0 && !ams_CRIAUDIO_INTERFACE.auply[i].m_bLoop && ams_CRIAUDIO_INTERFACE.auply[i].se_name.IndexOf( "_speedup" ) != -1 )
                    {
                        string cue2 = ams_CRIAUDIO_INTERFACE.auply[i].se_name.Replace("_speedup", "");
                        ams_CRIAUDIO_INTERFACE.auply[i].SetCue( cue2 );
                        ams_CRIAUDIO_INTERFACE.auply[i].Play();
                        return;
                    }
                    ams_CRIAUDIO_INTERFACE.auply[i].m_stGMState = state;
                    ams_CRIAUDIO_INTERFACE.auply[i].status = 3;
                }
                return;
            }
        }
    }

    // Token: 0x060002C6 RID: 710 RVA: 0x000176E0 File Offset: 0x000158E0
    private static void GsSoundInit()
    {
        MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>( AppMain.MediaPlayer_MediaStateChanged );
        if ( AppMain.sound_fx_list == null )
        {
            AppMain.sound_fx_list = new Dictionary<string, AppMain.SOUND_TABLE>( 130 );
            AppMain.fillSoundTable( "SND_FX.inf", AppMain.sound_fx_list );
        }
        if ( AppMain.sound_bgm_list == null )
        {
            AppMain.sound_bgm_list = new Dictionary<string, AppMain.SOUND_TABLE>( 50 );
            AppMain.fillSoundTable( "SND_BGM.inf", AppMain.sound_bgm_list );
        }
        AppMain.LoadPrioritySoundsIntoCache();
        GC.Collect();
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        AppMain.gsSoundInitSystemMainInfo();
        AppMain.gsSoundInitSndScbHeap();
        AppMain.gsSoundInitSeHandleHeap();
        int num;
        int num2;
        AppMain.GetSavedSoundVolumes( out num, out num2 );
        gss_MAIN_SYS_INFO.bgm_volume = ( float )num / 10f;
        gss_MAIN_SYS_INFO.se_volume = ( float )num2 / 10f;
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.GsSoundSetVolume( i, 1f );
        }
    }

    // Token: 0x060002C7 RID: 711 RVA: 0x000177A0 File Offset: 0x000159A0
    private static void GetSavedSoundVolumes( out int vol_bgm, out int vol_se )
    {
        vol_bgm = 10;
        vol_se = 10;
        try
        {
            using ( Stream isolatedStorageFileStream = File.Open( AppMain.g_ao_storage_filename, FileMode.Open ) )
            {
                isolatedStorageFileStream.Seek( 72L, 0 );
                BinaryReader binaryReader = new BinaryReader(isolatedStorageFileStream);
                vol_bgm = binaryReader.ReadInt32();
                vol_se = binaryReader.ReadInt32();
            }
        }
        catch ( Exception )
        {
        }
    }

    // Token: 0x060002C8 RID: 712 RVA: 0x00017818 File Offset: 0x00015A18
    private static void GsSoundHalt()
    {
        AppMain.amCriAudioGetGlobal();
        for ( int i = 0; i < 8; i++ )
        {
            if ( ( AppMain.gs_sound_scb_heap[i].flag & 1U ) != 0U )
            {
                AppMain.GsSoundStopBgm( AppMain.gs_sound_scb_heap[i] );
            }
        }
    }

    // Token: 0x060002C9 RID: 713 RVA: 0x00017854 File Offset: 0x00015A54
    private static void LoadSFX( AppMain.SOUND_TABLE tbl )
    {
        try
        {
            for ( int i = 0; i < tbl.count; i++ )
            {
                byte[] array = null;
                int num = 0;
                int num2 = 0;
                AppMain.CriAuPlayer.LoadSound( tbl.filename[i], tbl.loop[i], ref tbl.loopStart[i], ref tbl.loopEnd[i], out array, ref num2, ref num, false );
            }
        }
        catch ( FileNotFoundException ex )
        {
            string text = ex.ToString();
            text += text;
            AppMain.mppSoundNotImplAssert();
        }
    }

    // Token: 0x060002CA RID: 714 RVA: 0x000178DC File Offset: 0x00015ADC
    private static void LoadPrioritySoundsIntoCache()
    {
        if ( !AppMain.b_bPrioritySoundsLoaded )
        {
            AppMain.LoadSFX( AppMain.sound_fx_list["Sega_Logo"] );
            AppMain.LoadSFX( AppMain.sound_fx_list["Ok"] );
            AppMain.LoadSFX( AppMain.sound_fx_list["Window"] );
            AppMain.LoadSFX( AppMain.sound_fx_list["Cancel"] );
            AppMain.LoadSFX( AppMain.sound_fx_list["Cursol"] );
            AppMain.b_bPrioritySoundsLoaded = true;
        }
    }

    // Token: 0x060002CB RID: 715 RVA: 0x0001795C File Offset: 0x00015B5C
    private static bool SoundPartialCache( int iPercent )
    {
        if ( AppMain.g_bSoundsPrecached )
        {
            return true;
        }
        int count = AppMain.sound_fx_list.Count;
        int num = Math.Min(Math.Max(count * iPercent / 100, 1), count - AppMain.g_iCurrentCachedIndex);
        for ( int i = AppMain.g_iCurrentCachedIndex; i < AppMain.g_iCurrentCachedIndex + num; i++ )
        {
            AppMain.LoadSFX( Enumerable.ElementAt<KeyValuePair<string, AppMain.SOUND_TABLE>>( AppMain.sound_fx_list, i ).Value );
        }
        AppMain.g_iCurrentCachedIndex += num;
        AppMain.g_bSoundsPrecached = ( AppMain.g_iCurrentCachedIndex == count );
        return AppMain.g_bSoundsPrecached;
    }

    // Token: 0x060002CC RID: 716 RVA: 0x000179E4 File Offset: 0x00015BE4
    private static void GsSoundReset()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.GsSoundSetVolume( i, 1f );
        }
        AppMain.gsSoundResetSeHandleHeap();
        AppMain.gsSoundResetSndScbHeap();
        AppMain.gsSoundResetSystemMainInfo();
    }

    // Token: 0x060002CD RID: 717 RVA: 0x00017A18 File Offset: 0x00015C18
    private static void GsSoundExit()
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.GsSoundSetVolume( i, 0f );
        }
        AppMain.GsSoundHalt();
        AppMain.GsSoundEnd();
        AppMain.gsSoundClearSeHandleHeap();
        AppMain.gsSoundResetSndScbHeap();
        AppMain.gsSoundClearSystemMainInfo();
    }

    // Token: 0x060002CE RID: 718 RVA: 0x00017A55 File Offset: 0x00015C55
    private static void GsSoundBegin( ushort task_pause_level, uint task_prio, int task_group )
    {
        AppMain.GsSoundSetVolumeFromMainSysInfo();
        AppMain.gs_sound_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gsSoundProcMain ), null, 0U, task_pause_level, task_prio, task_group, null, "GS_SND_MAIN" );
    }

    // Token: 0x060002CF RID: 719 RVA: 0x00017A7D File Offset: 0x00015C7D
    private static void GsSoundEnd()
    {
        if ( AppMain.gs_sound_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gs_sound_tcb );
            AppMain.gs_sound_tcb = null;
        }
    }

    // Token: 0x060002D0 RID: 720 RVA: 0x00017A96 File Offset: 0x00015C96
    private static bool GsSoundIsRunning()
    {
        return AppMain.gs_sound_tcb != null;
    }

    // Token: 0x060002D1 RID: 721 RVA: 0x00017AA2 File Offset: 0x00015CA2
    private static AppMain.GSS_SND_SYS_MAIN_INFO GsSoundGetSysMainInfo()
    {
        return AppMain.gs_sound_sys_main_info;
    }

    // Token: 0x060002D2 RID: 722 RVA: 0x00017AA9 File Offset: 0x00015CA9
    private static void GsSoundPlaySe( string se_name )
    {
        AppMain.GsSoundPlaySe( se_name, null, 0 );
    }

    // Token: 0x060002D3 RID: 723 RVA: 0x00017AB3 File Offset: 0x00015CB3
    private static void GsSoundPlaySe( string se_name, AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.GsSoundPlaySe( se_name, se_handle, 0 );
    }

    // Token: 0x060002D4 RID: 724 RVA: 0x00017ABD File Offset: 0x00015CBD
    private static void GsSoundPlaySe( string se_name, AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.gsSoundPlaySe( se_name, 0U, se_handle, fade_frame );
    }

    // Token: 0x060002D5 RID: 725 RVA: 0x00017AC8 File Offset: 0x00015CC8
    private static void GsSoundPlaySeForce( string se_name )
    {
        AppMain.GsSoundPlaySeForce( se_name, null, 0 );
    }

    // Token: 0x060002D6 RID: 726 RVA: 0x00017AD2 File Offset: 0x00015CD2
    private static void GsSoundPlaySeForce( string se_name, AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.GsSoundPlaySeForce( se_name, se_handle, 0 );
    }

    // Token: 0x060002D7 RID: 727 RVA: 0x00017ADC File Offset: 0x00015CDC
    private static void GsSoundPlaySeForce( string se_name, AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.gsSoundPlaySe( se_name, 0U, se_handle, fade_frame );
    }

    // Token: 0x060002D8 RID: 728 RVA: 0x00017AE7 File Offset: 0x00015CE7
    private static void GsSoundPlaySeForce( string se_name, AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame, bool bDontPlay )
    {
        AppMain.gsSoundPlaySe( se_name, 0U, se_handle, fade_frame, bDontPlay );
    }

    // Token: 0x060002D9 RID: 729 RVA: 0x00017AF3 File Offset: 0x00015CF3
    private static void GsSoundPlaySeByIdForce( uint se_id, AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.gsSoundPlaySe( null, se_id, se_handle, fade_frame );
    }

    // Token: 0x060002DA RID: 730 RVA: 0x00017AFE File Offset: 0x00015CFE
    private static void GsSoundStopSe()
    {
        AppMain.GsSoundStopSe( 0, false );
    }

    // Token: 0x060002DB RID: 731 RVA: 0x00017B08 File Offset: 0x00015D08
    private static void GsSoundStopSe( int fade_frame, bool is_immediate )
    {
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.GSS_SND_SE_HANDLE gss_SND_SE_HANDLE = AppMain.gs_sound_se_handle_heap[i];
            if ( ( gss_SND_SE_HANDLE.flag & 1U ) != 0U )
            {
                AppMain.gsSoundCriSeStop( gss_SND_SE_HANDLE, fade_frame, is_immediate );
            }
        }
    }

    // Token: 0x060002DC RID: 732 RVA: 0x00017B3C File Offset: 0x00015D3C
    private static void GsSoundPauseSe( uint pause_level )
    {
        AppMain.GsSoundPauseSe( pause_level, 0 );
    }

    // Token: 0x060002DD RID: 733 RVA: 0x00017B48 File Offset: 0x00015D48
    private static void GsSoundPauseSe( uint pause_level, int fade_frame )
    {
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.GSS_SND_SE_HANDLE gss_SND_SE_HANDLE = AppMain.gs_sound_se_handle_heap[i];
            if ( ( gss_SND_SE_HANDLE.flag & 1U ) != 0U )
            {
                if ( gss_SND_SE_HANDLE.cur_pause_level < pause_level )
                {
                    gss_SND_SE_HANDLE.cur_pause_level = pause_level;
                }
                AppMain.gsSoundCriSePause( gss_SND_SE_HANDLE, fade_frame );
            }
        }
    }

    // Token: 0x060002DE RID: 734 RVA: 0x00017B8B File Offset: 0x00015D8B
    private static void GsSoundResumeSe( uint pause_level )
    {
        AppMain.GsSoundResumeSe( pause_level, 0 );
    }

    // Token: 0x060002DF RID: 735 RVA: 0x00017B94 File Offset: 0x00015D94
    private static void GsSoundResumeSe( uint pause_level, int fade_frame )
    {
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.GSS_SND_SE_HANDLE gss_SND_SE_HANDLE = AppMain.gs_sound_se_handle_heap[i];
            if ( ( gss_SND_SE_HANDLE.flag & 1U ) != 0U && gss_SND_SE_HANDLE.cur_pause_level <= pause_level )
            {
                gss_SND_SE_HANDLE.cur_pause_level = 0U;
                AppMain.gsSoundCriSeResume( gss_SND_SE_HANDLE, fade_frame );
            }
        }
    }

    // Token: 0x060002E0 RID: 736 RVA: 0x00017BD7 File Offset: 0x00015DD7
    private static void GmSoundStopSE( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.GsSoundStopSeHandle( se_handle, 0 );
    }

    // Token: 0x060002E1 RID: 737 RVA: 0x00017BE0 File Offset: 0x00015DE0
    private static void GsSoundStopSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.GsSoundStopSeHandle( se_handle, 0 );
    }

    // Token: 0x060002E2 RID: 738 RVA: 0x00017BE9 File Offset: 0x00015DE9
    private static void GsSoundStopSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.gsSoundCriSeStop( se_handle, fade_frame, false, false );
    }

    // Token: 0x060002E3 RID: 739 RVA: 0x00017BF4 File Offset: 0x00015DF4
    private static void GsSoundPlayBgm( AppMain.GSS_SND_SCB scb, string bgm_name, int fade_frame )
    {
        scb.cur_pause_level = 0U;
        if ( scb.snd_data_type == 1 )
        {
            return;
        }
        if ( AppMain.g_ao_sys_global.is_playing_device_bgm_music )
        {
            return;
        }
        AppMain.gsSoundCriStrmStop( scb, 0 );
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        AppMain.CriAuPlayer criAuPlayer = ams_CRIAUDIO_INTERFACE.auply[scb.auply_no];
        if ( criAuPlayer != null )
        {
            criAuPlayer.ReleaseCue();
            criAuPlayer.ResetParameters();
        }
        for ( int i = 0; i < ams_CRIAUDIO_INTERFACE.auply.Length; i++ )
        {
            if ( ams_CRIAUDIO_INTERFACE.auply[i].se_name == bgm_name )
            {
                ams_CRIAUDIO_INTERFACE.auply[i].ReleaseCue();
                ams_CRIAUDIO_INTERFACE.auply[i].ResetParameters();
                break;
            }
        }
        AppMain.amCriAudioStrmPlay( ( uint )scb.auply_no, bgm_name );
        AppMain.gsSoundCriStrmSetFadeIn( scb, fade_frame );
        AppMain.gsSoundUpdateVolume();
        criAuPlayer.Update();
    }

    // Token: 0x060002E4 RID: 740 RVA: 0x00017CAB File Offset: 0x00015EAB
    private static void GsSoundStopBgm( AppMain.GSS_SND_SCB scb )
    {
        AppMain.GsSoundStopBgm( scb, 0 );
    }

    // Token: 0x060002E5 RID: 741 RVA: 0x00017CB4 File Offset: 0x00015EB4
    private static void GsSoundStopBgm( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        if ( scb.snd_data_type == 1 )
        {
            return;
        }
        if ( AppMain.g_ao_sys_global.is_playing_device_bgm_music )
        {
            return;
        }
        AppMain.gsSoundCriStrmStop( scb, fade_frame );
    }

    // Token: 0x060002E6 RID: 742 RVA: 0x00017CD4 File Offset: 0x00015ED4
    private static void GsSoundPauseBgm( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        if ( ( scb.flag & 1U ) != 0U )
        {
            if ( scb.cur_pause_level < 2147483647U )
            {
                scb.cur_pause_level = 2147483647U;
            }
            if ( scb.snd_data_type == 1 )
            {
                return;
            }
            if ( AppMain.g_ao_sys_global.is_playing_device_bgm_music )
            {
                return;
            }
            AppMain.gsSoundCriStrmPause( scb, fade_frame );
        }
    }

    // Token: 0x060002E7 RID: 743 RVA: 0x00017D21 File Offset: 0x00015F21
    private static void GsSoundResumeBgm( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        if ( ( scb.flag & 1U ) != 0U && scb.cur_pause_level <= 2147483647U )
        {
            scb.cur_pause_level = 0U;
            if ( scb.snd_data_type == 1 )
            {
                return;
            }
            if ( AppMain.g_ao_sys_global.is_playing_device_bgm_music )
            {
                return;
            }
            AppMain.gsSoundCriStrmResume( scb, fade_frame );
        }
    }

    // Token: 0x060002E8 RID: 744 RVA: 0x00017D60 File Offset: 0x00015F60
    private static void GsSoundSetVolumeFromMainSysInfo()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        AppMain.GsSoundSetVolume( 0, gss_MAIN_SYS_INFO.bgm_volume );
        AppMain.GsSoundSetVolume( 1, gss_MAIN_SYS_INFO.se_volume );
    }

    // Token: 0x060002E9 RID: 745 RVA: 0x00017D8B File Offset: 0x00015F8B
    private static float GsSoundGetVolume( int snd_type )
    {
        return AppMain.gs_sound_volume[snd_type];
    }

    // Token: 0x060002EA RID: 746 RVA: 0x00017D94 File Offset: 0x00015F94
    private static void GsSoundSetVolume( int snd_type, float vol )
    {
        AppMain.gs_sound_volume[snd_type] = vol;
        if ( snd_type == 1 )
        {
            SoundEffect.MasterVolume = vol;
        }
    }

    // Token: 0x060002EB RID: 747 RVA: 0x00017DA8 File Offset: 0x00015FA8
    private static void GsSoundScbSetVolume( AppMain.GSS_SND_SCB scb, float vol )
    {
        if ( scb.snd_data_type == 1 )
        {
            return;
        }
        scb.snd_ctrl_param.volume = vol;
    }

    // Token: 0x060002EC RID: 748 RVA: 0x00017DC0 File Offset: 0x00015FC0
    private static void GsSoundScbSetSeqMute( AppMain.GSS_SND_SCB scb, bool mute_on )
    {
        int snd_data_type = scb.snd_data_type;
    }

    // Token: 0x060002ED RID: 749 RVA: 0x00017DCC File Offset: 0x00015FCC
    private static AppMain.GSS_SND_SCB GsSoundAssignScb( int snd_data_type )
    {
        for ( int i = 0; i < 8; i++ )
        {
            if ( ( ( int )AppMain.gs_sound_scb_heap_usage_flag[i >> 3] & 1 << ( i & 7 ) ) == 0 )
            {
                byte[] array = AppMain.gs_sound_scb_heap_usage_flag;
                int num = i >> 3;
                array[num] |= ( byte )( 1 << ( i & 7 ) );
                AppMain.gsSoundInitSndScb( AppMain.gs_sound_scb_heap[i], i, snd_data_type );
                return AppMain.gs_sound_scb_heap[i];
            }
        }
        return null;
    }

    // Token: 0x060002EE RID: 750 RVA: 0x00017E33 File Offset: 0x00016033
    private static void GsSoundResignScb( AppMain.GSS_SND_SCB scb )
    {
    }

    // Token: 0x060002EF RID: 751 RVA: 0x00017E38 File Offset: 0x00016038
    private static AppMain.GSS_SND_SE_HANDLE GsSoundAllocSeHandle()
    {
        for ( int i = 0; i < 16; i++ )
        {
            if ( ( ( int )AppMain.gs_sound_se_handle_heap_usage_flag[i >> 3] & 1 << ( i & 7 ) ) == 0 )
            {
                byte[] array = AppMain.gs_sound_se_handle_heap_usage_flag;
                int num = i >> 3;
                array[num] |= ( byte )( 1 << ( i & 7 ) );
                AppMain.gsSoundInitSeHandle( AppMain.gs_sound_se_handle_heap[i] );
                AppMain.gs_sound_se_handle_heap[i].snd_ctrl_param.pitch = 0f;
                return AppMain.gs_sound_se_handle_heap[i];
            }
        }
        AppMain.gsSoundInitSeHandle( AppMain.gs_sound_se_handle_error );
        AppMain.gs_sound_se_handle_error.snd_ctrl_param.pitch = 0f;
        return AppMain.gs_sound_se_handle_error;
    }

    // Token: 0x060002F0 RID: 752 RVA: 0x00017ED8 File Offset: 0x000160D8
    private static void GsSoundFreeSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        if ( AppMain.gs_sound_se_handle_error == se_handle )
        {
            AppMain.gsSoundClearSeHandle( AppMain.gs_sound_se_handle_error );
            return;
        }
        for ( int i = 0; i < 16; i++ )
        {
            if ( AppMain.gs_sound_se_handle_heap[i] == se_handle )
            {
                AppMain.gsSoundClearSeHandle( se_handle );
                byte[] array = AppMain.gs_sound_se_handle_heap_usage_flag;
                int num = i >> 3;
                array[num] &= ( byte )( ~( byte )( 1 << ( i & 7 ) ) );
                return;
            }
        }
    }

    // Token: 0x060002F1 RID: 753 RVA: 0x00017F3A File Offset: 0x0001613A
    private static void GsSoundRequestFreeSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        se_handle.flag |= 16U;
    }

    // Token: 0x060002F2 RID: 754 RVA: 0x00017F4B File Offset: 0x0001614B
    private static void GsSoundEnterHBM( object arg )
    {
    }

    // Token: 0x060002F3 RID: 755 RVA: 0x00017F4D File Offset: 0x0001614D
    private static void GsSoundLeaveHBM( object arg )
    {
    }

    // Token: 0x060002F4 RID: 756 RVA: 0x00017F4F File Offset: 0x0001614F
    private static int GsSoundFadeHBM( object arg )
    {
        return -1;
    }

    // Token: 0x060002F5 RID: 757 RVA: 0x00017F54 File Offset: 0x00016154
    private static void gsSoundProcMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.amCriAudioGetGlobal();
        AppMain.gsSoundUpdateSystemSuspendWait();
        AppMain.gsSoundUpdateSystemControlVolume();
        for ( int i = 0; i < 8; i++ )
        {
            if ( ( AppMain.gs_sound_scb_heap[i].flag & 1U ) != 0U )
            {
                AppMain.gsSoundUpdateSndScb( AppMain.gs_sound_scb_heap[i] );
            }
        }
        for ( int j = 0; j < 16; j++ )
        {
            AppMain.GSS_SND_SE_HANDLE gss_SND_SE_HANDLE = AppMain.gs_sound_se_handle_heap[j];
            if ( ( gss_SND_SE_HANDLE.flag & 1U ) != 0U )
            {
                AppMain.gsSoundUpdateSndSeHandle( gss_SND_SE_HANDLE );
            }
        }
        if ( ( AppMain.gs_sound_se_handle_error.flag & 1U ) != 0U )
        {
            AppMain.gsSoundUpdateSndSeHandle( AppMain.gs_sound_se_handle_error );
        }
        AppMain.gsSoundUpdateVolume();
        for ( int k = 0; k < 16; k++ )
        {
            AppMain.GSS_SND_SE_HANDLE gss_SND_SE_HANDLE2 = AppMain.gs_sound_se_handle_heap[k];
            if ( ( gss_SND_SE_HANDLE2.flag & 1U ) != 0U )
            {
                switch ( gss_SND_SE_HANDLE2.au_player.GetStatus() )
                {
                    case 0:
                    case 3:
                        break;
                    case 1:
                    case 2:
                        goto IL_104;
                    case 4:
                        gss_SND_SE_HANDLE2.au_player.Stop();
                        break;
                    default:
                        goto IL_104;
                }
                if ( ( gss_SND_SE_HANDLE2.flag & 16U ) != 0U )
                {
                    AppMain.GsSoundFreeSeHandle( gss_SND_SE_HANDLE2 );
                    goto IL_125;
                }
                if ( ( gss_SND_SE_HANDLE2.flag & 2U ) != 0U && ( gss_SND_SE_HANDLE2.flag & 2147483648U ) == 0U )
                {
                    AppMain.gsSoundClearSeHandle( gss_SND_SE_HANDLE2 );
                    goto IL_125;
                }
                goto IL_125;
                IL_104:
                gss_SND_SE_HANDLE2.au_player.Update();
            }
            else if ( ( gss_SND_SE_HANDLE2.flag & 16U ) != 0U )
            {
                AppMain.GsSoundFreeSeHandle( gss_SND_SE_HANDLE2 );
            }
            IL_125:;
        }
        if ( ( AppMain.gs_sound_se_handle_error.flag & 1U ) != 0U )
        {
            switch ( AppMain.gs_sound_se_handle_error.au_player.GetStatus() )
            {
                case 0:
                case 3:
                    break;
                case 1:
                case 2:
                    goto IL_1B4;
                case 4:
                    AppMain.gs_sound_se_handle_error.au_player.Stop();
                    break;
                default:
                    goto IL_1B4;
            }
            if ( ( AppMain.gs_sound_se_handle_error.flag & 16U ) != 0U )
            {
                AppMain.GsSoundFreeSeHandle( AppMain.gs_sound_se_handle_error );
                goto IL_1DE;
            }
            if ( ( AppMain.gs_sound_se_handle_error.flag & 2U ) != 0U )
            {
                AppMain.gsSoundClearSeHandle( AppMain.gs_sound_se_handle_error );
                goto IL_1DE;
            }
            goto IL_1DE;
            IL_1B4:
            AppMain.gs_sound_se_handle_error.au_player.Update();
        }
        else if ( ( AppMain.gs_sound_se_handle_error.flag & 16U ) != 0U )
        {
            AppMain.GsSoundFreeSeHandle( AppMain.gs_sound_se_handle_error );
        }
        IL_1DE:
        for ( int l = 0; l < 8; l++ )
        {
            if ( ( AppMain.gs_sound_scb_heap[l].flag & 1U ) != 0U )
            {
                AppMain.gsSoundUpdateSndScbStatus( AppMain.gs_sound_scb_heap[l] );
            }
        }
        for ( int m = 0; m < 16; m++ )
        {
            if ( ( AppMain.gs_sound_se_handle_heap[m].flag & 1U ) != 0U )
            {
                AppMain.gsSoundUpdateSeHandleStatus( AppMain.gs_sound_se_handle_heap[m] );
            }
        }
        if ( ( AppMain.gs_sound_se_handle_error.flag & 1U ) != 0U )
        {
            AppMain.gsSoundUpdateSeHandleStatus( AppMain.gs_sound_se_handle_error );
        }
    }

    // Token: 0x060002F6 RID: 758 RVA: 0x000181B4 File Offset: 0x000163B4
    private static void gsSoundInitSystemMainInfo()
    {
        AppMain.gsSoundClearSystemMainInfo();
    }

    // Token: 0x060002F7 RID: 759 RVA: 0x000181BB File Offset: 0x000163BB
    private static void gsSoundResetSystemMainInfo()
    {
        AppMain.gs_sound_sys_main_info.flag &= 4294967293U;
    }

    // Token: 0x060002F8 RID: 760 RVA: 0x000181D0 File Offset: 0x000163D0
    private static void gsSoundClearSystemMainInfo()
    {
        AppMain.gs_sound_sys_main_info.Clear();
    }

    // Token: 0x060002F9 RID: 761 RVA: 0x000181DC File Offset: 0x000163DC
    private static void gsSoundSetEnableSystemControlVolume( bool enable )
    {
        if ( enable )
        {
            AppMain.gs_sound_sys_main_info.flag |= 1U;
            return;
        }
        AppMain.gs_sound_sys_main_info.flag &= 4294967294U;
    }

    // Token: 0x060002FA RID: 762 RVA: 0x00018207 File Offset: 0x00016407
    private static bool gsSoundIsSystemControlVolumeEnabled()
    {
        return ( AppMain.gs_sound_sys_main_info.flag & 1U ) != 0U;
    }

    // Token: 0x060002FB RID: 763 RVA: 0x0001821A File Offset: 0x0001641A
    private static void gsSoundUpdateSystemControlVolume()
    {
        AppMain.gsSoundIsSystemControlVolumeEnabled();
    }

    // Token: 0x060002FC RID: 764 RVA: 0x00018224 File Offset: 0x00016424
    private static float gsSoundGetGlobalVolume()
    {
        float num = 1f;
        if ( AppMain.gsSoundIsSystemControlVolumeEnabled() )
        {
            num *= AppMain.gs_sound_sys_main_info.system_cnt_vol;
        }
        if ( AppMain.gsSoundIsSystemSuspendWait() )
        {
            num = 0f;
        }
        return num;
    }

    // Token: 0x060002FD RID: 765 RVA: 0x00018259 File Offset: 0x00016459
    private static float gsSoundGetSndScbMuteVolume( AppMain.GSS_SND_SCB scb )
    {
        if ( AppMain.GsSystemBgmIsPlay() && ( scb.flag & 2147483648U ) != 0U )
        {
            return 0f;
        }
        return 1f;
    }

    // Token: 0x060002FE RID: 766 RVA: 0x0001827B File Offset: 0x0001647B
    private static void gsSoundInitSndScbHeap()
    {
        AppMain.gsSoundResetSndScbHeap();
    }

    // Token: 0x060002FF RID: 767 RVA: 0x00018284 File Offset: 0x00016484
    private static void gsSoundResetSndScbHeap()
    {
        for ( int i = 0; i < 8; i++ )
        {
            AppMain.gsSoundClearSndScb( AppMain.gs_sound_scb_heap[i], AppMain.gsSoundGetAuplyNo( i ) );
        }
        Array.Clear( AppMain.gs_sound_scb_heap_usage_flag, 0, AppMain.gs_sound_scb_heap_usage_flag.Length );
    }

    // Token: 0x06000300 RID: 768 RVA: 0x000182C4 File Offset: 0x000164C4
    private static uint gsSndGetFreeScbNum()
    {
        uint num = 8U;
        int num2 = 1;
        for ( int i = 0; i < num2; i++ )
        {
            num -= ( uint )AppMain.AkMathCountBitPopulation( ( uint )AppMain.gs_sound_scb_heap_usage_flag[i] );
        }
        return num;
    }

    // Token: 0x06000301 RID: 769 RVA: 0x000182F4 File Offset: 0x000164F4
    private static void gsSoundInitSndScb( AppMain.GSS_SND_SCB scb, int scb_no, int snd_data_type )
    {
        AppMain.gsSoundClearSndScb( scb, AppMain.gsSoundGetAuplyNo( scb_no ) );
        scb.snd_data_type = snd_data_type;
        if ( snd_data_type != 1 )
        {
            scb.auply_no = AppMain.gsSoundGetAuplyNo( scb_no );
            scb.snd_ctrl_param.fade_vol = 1f;
            scb.snd_ctrl_param.fade_sub_vol = 1f;
            scb.snd_ctrl_param.volume = 1f;
        }
        scb.noplay_error_state.sample = uint.MaxValue;
        scb.noplay_error_state.counter = 0U;
        scb.flag |= 1U;
    }

    // Token: 0x06000302 RID: 770 RVA: 0x0001837C File Offset: 0x0001657C
    private static void gsSoundClearSndScb( AppMain.GSS_SND_SCB scb, int auply_no )
    {
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        AppMain.CriAuPlayer criAuPlayer = ams_CRIAUDIO_INTERFACE.auply[auply_no];
        if ( criAuPlayer != null )
        {
            criAuPlayer.ReleaseCue();
            criAuPlayer.ResetParameters();
        }
        scb.Clear();
    }

    // Token: 0x06000303 RID: 771 RVA: 0x000183B0 File Offset: 0x000165B0
    private static void gsSoundUpdateSndScb( AppMain.GSS_SND_SCB scb )
    {
        if ( scb.snd_data_type == 1 )
        {
            return;
        }
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        AppMain.CriAuPlayer criAuPlayer = ams_CRIAUDIO_INTERFACE.auply[scb.auply_no];
        AppMain.gsSoundUpdateSndCtrl( scb.snd_ctrl_param, criAuPlayer );
        if ( AppMain.gsSoundCheckSndScbStop( scb ) || ( 6U & scb.flag ) != 0U )
        {
            scb.noplay_error_state.sample = uint.MaxValue;
            scb.noplay_error_state.counter = 0U;
            return;
        }
        uint numPlayedSamples = (uint)criAuPlayer.GetNumPlayedSamples();
        if ( scb.noplay_error_state.sample != numPlayedSamples )
        {
            scb.noplay_error_state.sample = numPlayedSamples;
            scb.noplay_error_state.counter = 0U;
            return;
        }
        uint num = 90U;
        uint counter;
        scb.noplay_error_state.counter = ( counter = scb.noplay_error_state.counter ) + 1U;
        if ( num < counter )
        {
            scb.noplay_error_state.sample = uint.MaxValue;
            scb.noplay_error_state.counter = 0U;
        }
    }

    // Token: 0x06000304 RID: 772 RVA: 0x00018474 File Offset: 0x00016674
    private static void gsSoundUpdateSndScbStatus( AppMain.GSS_SND_SCB scb )
    {
        if ( AppMain.gsSoundCheckSndScbStop( scb ) )
        {
            scb.flag |= 2U;
        }
        else
        {
            scb.flag &= 4294967293U;
        }
        if ( AppMain.gsSoundCheckSndScbPause( scb ) )
        {
            scb.flag |= 4U;
            return;
        }
        scb.flag &= 4294967291U;
    }

    // Token: 0x06000305 RID: 773 RVA: 0x000184D0 File Offset: 0x000166D0
    private static bool gsSoundCheckSndScbPause( AppMain.GSS_SND_SCB scb )
    {
        if ( scb.snd_data_type == 1 )
        {
            return false;
        }
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        return scb.snd_ctrl_param.fade_state == 3U || ams_CRIAUDIO_INTERFACE.auply[scb.auply_no].IsPaused();
    }

    // Token: 0x06000306 RID: 774 RVA: 0x00018514 File Offset: 0x00016714
    private static bool gsSoundCheckSndScbStop( AppMain.GSS_SND_SCB scb )
    {
        if ( scb.snd_data_type == 1 )
        {
            return true;
        }
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        switch ( ams_CRIAUDIO_INTERFACE.auply[scb.auply_no].GetStatus() )
        {
            case 0:
            case 3:
            case 4:
                return true;
        }
        return false;
    }

    // Token: 0x06000307 RID: 775 RVA: 0x00018564 File Offset: 0x00016764
    private static int gsSoundGetAuplyNo( int scb_no )
    {
        return scb_no;
    }

    // Token: 0x06000308 RID: 776 RVA: 0x00018568 File Offset: 0x00016768
    private static void gsSoundCriStrmSetFadeIn( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        if ( scb.snd_data_type != 0 )
        {
            return;
        }
        if ( fade_frame == 0 )
        {
            scb.snd_ctrl_param.fade_state = 0U;
            scb.snd_ctrl_param.fade_frame_max = 0;
            scb.snd_ctrl_param.fade_frame_cnt = 0;
            scb.snd_ctrl_param.fade_vol = 1f;
        }
        else
        {
            scb.snd_ctrl_param.fade_state = 1U;
            scb.snd_ctrl_param.fade_frame_max = fade_frame;
            scb.snd_ctrl_param.fade_frame_cnt = 0;
            scb.snd_ctrl_param.fade_vol = 0f;
        }
        scb.snd_ctrl_param.fade_sub_vol = 1f;
    }

    // Token: 0x06000309 RID: 777 RVA: 0x000185FB File Offset: 0x000167FB
    private static void gsSoundCriStrmStop( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        AppMain.gsSoundCriStrmStop( scb, fade_frame, false );
    }

    // Token: 0x0600030A RID: 778 RVA: 0x00018608 File Offset: 0x00016808
    private static void gsSoundCriStrmStop( AppMain.GSS_SND_SCB scb, int fade_frame, bool is_takeover )
    {
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        if ( scb.snd_data_type != 0 )
        {
            return;
        }
        if ( is_takeover )
        {
            scb.snd_ctrl_param.fade_sub_vol = scb.snd_ctrl_param.fade_sub_vol * scb.snd_ctrl_param.fade_vol;
        }
        else
        {
            scb.snd_ctrl_param.fade_sub_vol = 1f;
        }
        if ( fade_frame == 0 )
        {
            scb.snd_ctrl_param.fade_state = 0U;
            scb.snd_ctrl_param.fade_frame_max = ( scb.snd_ctrl_param.fade_frame_cnt = 0 );
            scb.snd_ctrl_param.fade_vol = 0f;
            ams_CRIAUDIO_INTERFACE.auply[scb.auply_no].Stop();
            return;
        }
        scb.snd_ctrl_param.fade_state = 2U;
        scb.snd_ctrl_param.fade_frame_max = fade_frame;
        scb.snd_ctrl_param.fade_frame_cnt = 0;
        scb.snd_ctrl_param.fade_vol = 1f;
    }

    // Token: 0x0600030B RID: 779 RVA: 0x000186DC File Offset: 0x000168DC
    private static void gsSoundCriStrmPause( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        if ( scb.snd_data_type != 0 )
        {
            return;
        }
        if ( scb.snd_ctrl_param.fade_state == 2U )
        {
            AppMain.gsSoundCriStrmStop( scb, fade_frame, true );
            return;
        }
        if ( fade_frame == 0 )
        {
            scb.snd_ctrl_param.fade_state = 0U;
            scb.snd_ctrl_param.fade_frame_max = ( scb.snd_ctrl_param.fade_frame_cnt = 0 );
            scb.snd_ctrl_param.fade_vol = 0f;
            ams_CRIAUDIO_INTERFACE.auply[scb.auply_no].Pause( true );
            return;
        }
        scb.snd_ctrl_param.fade_state = 3U;
        scb.snd_ctrl_param.fade_frame_max = fade_frame;
        scb.snd_ctrl_param.fade_frame_cnt = 0;
        scb.snd_ctrl_param.fade_vol = 1f;
    }

    // Token: 0x0600030C RID: 780 RVA: 0x00018790 File Offset: 0x00016990
    private static void gsSoundCriStrmResume( AppMain.GSS_SND_SCB scb, int fade_frame )
    {
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        if ( scb.snd_data_type != 0 )
        {
            return;
        }
        if ( !AppMain.gsSoundCheckSndScbPause( scb ) )
        {
            return;
        }
        ams_CRIAUDIO_INTERFACE.auply[scb.auply_no].Pause( false );
        if ( fade_frame == 0 )
        {
            scb.snd_ctrl_param.fade_state = 0U;
            scb.snd_ctrl_param.fade_frame_max = ( scb.snd_ctrl_param.fade_frame_cnt = 0 );
            scb.snd_ctrl_param.fade_vol = 1f;
            return;
        }
        AppMain.gsSoundCriStrmSetFadeIn( scb, fade_frame );
    }

    // Token: 0x0600030D RID: 781 RVA: 0x0001880C File Offset: 0x00016A0C
    private static void gsSoundUpdateSndCtrl( AppMain.GSS_SND_CTRL_PARAM snd_ctrl_param, AppMain.CriAuPlayer au_player )
    {
        AppMain.amCriAudioGetGlobal();
        if ( snd_ctrl_param.fade_state == 1U || snd_ctrl_param.fade_state == 2U || snd_ctrl_param.fade_state == 3U )
        {
            if ( snd_ctrl_param.fade_frame_max <= snd_ctrl_param.fade_frame_cnt )
            {
                if ( snd_ctrl_param.fade_state == 1U )
                {
                    snd_ctrl_param.fade_vol = 1f;
                }
                else
                {
                    if ( snd_ctrl_param.fade_state == 3U )
                    {
                        au_player.Pause( true );
                    }
                    else
                    {
                        au_player.Stop( 1 );
                    }
                    snd_ctrl_param.fade_vol = 0f;
                }
                snd_ctrl_param.fade_state = 0U;
                snd_ctrl_param.fade_frame_max = ( snd_ctrl_param.fade_frame_cnt = 0 );
                return;
            }
            switch ( au_player.GetStatus() )
            {
                case 2:
                case 3:
                    if ( !au_player.IsPaused() )
                    {
                        float num;
                        if ( snd_ctrl_param.fade_frame_max == 0 )
                        {
                            num = 1f;
                        }
                        else
                        {
                            num = 1f * ( ( float )snd_ctrl_param.fade_frame_cnt / ( float )snd_ctrl_param.fade_frame_max );
                        }
                        if ( snd_ctrl_param.fade_state == 1U )
                        {
                            snd_ctrl_param.fade_vol = num;
                        }
                        else
                        {
                            snd_ctrl_param.fade_vol = 1f - num;
                        }
                        snd_ctrl_param.fade_frame_cnt++;
                        return;
                    }
                    break;
                default:
                    snd_ctrl_param.fade_vol = 0f;
                    return;
            }
        }
        else
        {
            if ( au_player.IsPaused() )
            {
                snd_ctrl_param.fade_vol = 0f;
                return;
            }
            snd_ctrl_param.fade_vol = 1f;
        }
    }

    // Token: 0x0600030E RID: 782 RVA: 0x00018940 File Offset: 0x00016B40
    private static void gsSoundSeHandleUpdateVolume( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        if ( se_handle.au_player != null )
        {
            se_handle.au_player.SetVolume( se_handle.snd_ctrl_param.volume * se_handle.snd_ctrl_param.fade_vol * se_handle.snd_ctrl_param.fade_sub_vol * AppMain.gsSoundGetGlobalVolume() );
            se_handle.au_player.SetPitch( se_handle.snd_ctrl_param.pitch );
        }
    }

    // Token: 0x0600030F RID: 783 RVA: 0x000189A0 File Offset: 0x00016BA0
    private static void gsSoundUpdateVolume()
    {
        AppMain.AMS_CRIAUDIO_INTERFACE ams_CRIAUDIO_INTERFACE = AppMain.amCriAudioGetGlobal();
        for ( int i = 0; i < 8; i++ )
        {
            if ( ( AppMain.gs_sound_scb_heap[i].flag & 1U ) != 0U && AppMain.gs_sound_scb_heap[i].snd_data_type == 0 )
            {
                int status = ams_CRIAUDIO_INTERFACE.auply[AppMain.gs_sound_scb_heap[i].auply_no].GetStatus();
                if ( status != 0 && 3 != status )
                {
                    ams_CRIAUDIO_INTERFACE.auply[AppMain.gs_sound_scb_heap[i].auply_no].SetVolume( AppMain.gs_sound_volume[0] * AppMain.gs_sound_scb_heap[i].snd_ctrl_param.volume * AppMain.gs_sound_scb_heap[i].snd_ctrl_param.fade_vol * AppMain.gs_sound_scb_heap[i].snd_ctrl_param.fade_sub_vol * AppMain.gsSoundGetGlobalVolume() * AppMain.gsSoundGetSndScbMuteVolume( AppMain.gs_sound_scb_heap[i] ) );
                }
            }
        }
        for ( int j = 0; j < 16; j++ )
        {
            if ( ( AppMain.gs_sound_se_handle_heap[j].flag & 1U ) != 0U && AppMain.gsSoundIsSeHandleCueSet( AppMain.gs_sound_se_handle_heap[j] ) )
            {
                AppMain.gsSoundSeHandleUpdateVolume( AppMain.gs_sound_se_handle_heap[j] );
            }
        }
        if ( ( AppMain.gs_sound_se_handle_error.flag & 1U ) != 0U && AppMain.gsSoundIsSeHandleCueSet( AppMain.gs_sound_se_handle_error ) )
        {
            AppMain.gsSoundSeHandleUpdateVolume( AppMain.gs_sound_se_handle_error );
        }
    }

    // Token: 0x06000310 RID: 784 RVA: 0x00018ACC File Offset: 0x00016CCC
    private static void gsSoundInitSeHandleHeap()
    {
        AppMain.gsSoundResetSeHandleHeap();
    }

    // Token: 0x06000311 RID: 785 RVA: 0x00018AD4 File Offset: 0x00016CD4
    private static void gsSoundResetSeHandleHeap()
    {
        AppMain.AMS_CRIAUDIO_INTERFACE cri_if = AppMain.amCriAudioGetGlobal();
        AppMain.gsSoundClearSeHandleHeap();
        for ( int i = 0; i < 16; i++ )
        {
            AppMain.gs_sound_se_handle_heap[i].au_player = AppMain.CriAuPlayer.Create( cri_if );
        }
        AppMain.gs_sound_se_handle_error.au_player = AppMain.CriAuPlayer.Create( cri_if );
        AppMain.gs_sound_se_handle_default = AppMain.New<AppMain.GSS_SND_SE_HANDLE>( 3 );
        for ( int j = 0; j < AppMain.gs_sound_se_handle_default.Length; j++ )
        {
            AppMain.gs_sound_se_handle_default[j] = AppMain.GsSoundAllocSeHandle();
        }
    }

    // Token: 0x06000312 RID: 786 RVA: 0x00018B44 File Offset: 0x00016D44
    private static void gsSoundClearSeHandleHeap()
    {
        AppMain.amCriAudioGetGlobal();
        if ( AppMain.gs_sound_se_handle_default != null )
        {
            for ( int i = 0; i < AppMain.gs_sound_se_handle_default.Length; i++ )
            {
                AppMain.GsSoundFreeSeHandle( AppMain.gs_sound_se_handle_default[i] );
            }
            AppMain.gs_sound_se_handle_default = null;
        }
        for ( int j = 0; j < 16; j++ )
        {
            AppMain.gsSoundClearSeHandle( AppMain.gs_sound_se_handle_heap[j] );
            if ( AppMain.gs_sound_se_handle_heap[j].au_player != null )
            {
                AppMain.gs_sound_se_handle_heap[j].au_player.Destroy();
                AppMain.gs_sound_se_handle_heap[j].au_player = null;
            }
        }
        AppMain.gsSoundClearSeHandle( AppMain.gs_sound_se_handle_error );
        if ( AppMain.gs_sound_se_handle_error.au_player != null )
        {
            AppMain.gs_sound_se_handle_error.au_player.Destroy();
            AppMain.gs_sound_se_handle_error.au_player = null;
        }
        Array.Clear( AppMain.gs_sound_se_handle_heap_usage_flag, 0, AppMain.gs_sound_se_handle_heap_usage_flag.Length );
    }

    // Token: 0x06000313 RID: 787 RVA: 0x00018C0C File Offset: 0x00016E0C
    private static uint gsSoundGetFreeSeHandleNum()
    {
        uint num = 16U;
        int num2 = 2;
        for ( int i = 0; i < num2; i++ )
        {
            num -= ( uint )AppMain.AkMathCountBitPopulation( ( uint )AppMain.gs_sound_se_handle_heap_usage_flag[i] );
        }
        return num;
    }

    // Token: 0x06000314 RID: 788 RVA: 0x00018C3A File Offset: 0x00016E3A
    private static void gsSoundInitSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.gsSoundInitSeHandle( se_handle, false );
    }

    // Token: 0x06000315 RID: 789 RVA: 0x00018C44 File Offset: 0x00016E44
    private static void gsSoundInitSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle, bool b_reset )
    {
        AppMain.amCriAudioGetGlobal();
        if ( se_handle.au_player != null && 1 == se_handle.au_player.GetStatus() )
        {
            se_handle.au_player.Update();
        }
        AppMain.gsSoundClearSeHandle( se_handle, b_reset );
        se_handle.flag |= 1U;
        se_handle.snd_ctrl_param.fade_vol = 1f;
        se_handle.snd_ctrl_param.fade_sub_vol = 1f;
        se_handle.snd_ctrl_param.volume = 1f;
    }

    // Token: 0x06000316 RID: 790 RVA: 0x00018CBD File Offset: 0x00016EBD
    private static void gsSoundClearSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.gsSoundClearSeHandle( se_handle, false );
    }

    // Token: 0x06000317 RID: 791 RVA: 0x00018CC8 File Offset: 0x00016EC8
    private static void gsSoundClearSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle, bool b_takeover_cue )
    {
        AppMain.amCriAudioGetGlobal();
        se_handle.flag = 0U;
        se_handle.snd_ctrl_param.fade_vol = 0f;
        se_handle.snd_ctrl_param.fade_sub_vol = 0f;
        se_handle.snd_ctrl_param.volume = 0f;
        se_handle.cur_pause_level = 0U;
        if ( se_handle.au_player != null )
        {
            if ( !b_takeover_cue )
            {
                se_handle.au_player.ReleaseCue();
            }
            se_handle.au_player.ResetParameters();
        }
    }

    // Token: 0x06000318 RID: 792 RVA: 0x00018D3A File Offset: 0x00016F3A
    private static void gsSoundUpdateSndSeHandle( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.gsSoundUpdateSndCtrl( se_handle.snd_ctrl_param, se_handle.au_player );
    }

    // Token: 0x06000319 RID: 793 RVA: 0x00018D50 File Offset: 0x00016F50
    private static void gsSoundUpdateSeHandleStatus( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        if ( AppMain.gsSoundCheckSeHandleStop( se_handle ) )
        {
            se_handle.flag |= 4U;
        }
        else
        {
            se_handle.flag &= 4294967291U;
        }
        if ( AppMain.gsSoundCheckSeHandlePause( se_handle ) )
        {
            se_handle.flag |= 8U;
            return;
        }
        se_handle.flag &= 4294967287U;
    }

    // Token: 0x0600031A RID: 794 RVA: 0x00018DAA File Offset: 0x00016FAA
    private static bool gsSoundCheckSeHandlePause( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.amCriAudioGetGlobal();
        return se_handle.au_player != null && ( se_handle.snd_ctrl_param.fade_state == 3U || se_handle.au_player.IsPaused() );
    }

    // Token: 0x0600031B RID: 795 RVA: 0x00018DD8 File Offset: 0x00016FD8
    private static bool gsSoundCheckSeHandleStop( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.amCriAudioGetGlobal();
        if ( se_handle.au_player != null )
        {
            switch ( se_handle.au_player.GetStatus() )
            {
                case 0:
                case 3:
                case 4:
                    return true;
            }
            return false;
        }
        return true;
    }

    // Token: 0x0600031C RID: 796 RVA: 0x00018E20 File Offset: 0x00017020
    private static bool gsSoundIsSeHandleCueSet( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        AppMain.amCriAudioGetGlobal();
        if ( se_handle.au_player != null )
        {
            int status = se_handle.au_player.GetStatus();
            return status != 0 && status != 3;
        }
        return false;
    }

    // Token: 0x0600031D RID: 797 RVA: 0x00018E54 File Offset: 0x00017054
    private static AppMain.GSS_SND_SE_HANDLE gsSoundGetDefaultSeHandle()
    {
        for ( int i = 0; i < AppMain.gs_sound_se_handle_default.Length; i++ )
        {
            if ( AppMain.gs_sound_se_handle_default[i].au_player.sound == null || AppMain.gs_sound_se_handle_default[i].au_player.sound[0] == null || AppMain.gs_sound_se_handle_default[i].au_player.sound[0].State == SoundState.Stopped )
            {
                return AppMain.gs_sound_se_handle_default[i];
            }
        }
        return AppMain.gs_sound_se_handle_default[0];
    }

    // Token: 0x0600031E RID: 798 RVA: 0x00018EC8 File Offset: 0x000170C8
    private static void gsSoundCriSeSetFadeIn( AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        if ( fade_frame == 0 )
        {
            se_handle.snd_ctrl_param.fade_state = 0U;
            se_handle.snd_ctrl_param.fade_frame_max = 0;
            se_handle.snd_ctrl_param.fade_frame_cnt = 0;
            se_handle.snd_ctrl_param.fade_vol = 1f;
        }
        else
        {
            se_handle.snd_ctrl_param.fade_state = 1U;
            se_handle.snd_ctrl_param.fade_frame_max = fade_frame;
            se_handle.snd_ctrl_param.fade_frame_cnt = 0;
            se_handle.snd_ctrl_param.fade_vol = 0f;
        }
        se_handle.snd_ctrl_param.fade_sub_vol = 1f;
    }

    // Token: 0x0600031F RID: 799 RVA: 0x00018F52 File Offset: 0x00017152
    private static void gsSoundCriSeStop( AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame, bool is_immediate )
    {
        AppMain.gsSoundCriSeStop( se_handle, fade_frame, is_immediate, false );
    }

    // Token: 0x06000320 RID: 800 RVA: 0x00018F60 File Offset: 0x00017160
    private static void gsSoundCriSeStop( AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame, bool is_immediate, bool is_takeover )
    {
        AppMain.amCriAudioGetGlobal();
        if ( ( se_handle.flag & 1U ) != 0U && se_handle.au_player != null )
        {
            if ( is_takeover )
            {
                se_handle.snd_ctrl_param.fade_sub_vol = se_handle.snd_ctrl_param.fade_sub_vol * se_handle.snd_ctrl_param.fade_vol;
            }
            else
            {
                se_handle.snd_ctrl_param.fade_sub_vol = 1f;
            }
            if ( fade_frame == 0 )
            {
                se_handle.snd_ctrl_param.fade_state = 0U;
                se_handle.snd_ctrl_param.fade_frame_max = ( se_handle.snd_ctrl_param.fade_frame_cnt = 0 );
                se_handle.snd_ctrl_param.fade_vol = 0f;
                if ( is_immediate )
                {
                    se_handle.au_player.Stop( 1 );
                    return;
                }
                se_handle.au_player.Stop();
                return;
            }
            else
            {
                se_handle.snd_ctrl_param.fade_state = 2U;
                se_handle.snd_ctrl_param.fade_frame_max = fade_frame;
                se_handle.snd_ctrl_param.fade_frame_cnt = 0;
                se_handle.snd_ctrl_param.fade_vol = 1f;
            }
        }
    }

    // Token: 0x06000321 RID: 801 RVA: 0x0001904C File Offset: 0x0001724C
    private static void gsSoundCriSePause( AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.amCriAudioGetGlobal();
        if ( se_handle.snd_ctrl_param.fade_state == 2U )
        {
            AppMain.gsSoundCriSeStop( se_handle, fade_frame, true, true );
            return;
        }
        if ( fade_frame == 0 )
        {
            se_handle.snd_ctrl_param.fade_state = 0U;
            se_handle.snd_ctrl_param.fade_frame_max = ( se_handle.snd_ctrl_param.fade_frame_cnt = 0 );
            se_handle.snd_ctrl_param.fade_vol = 0f;
            se_handle.au_player.Pause( true );
            return;
        }
        se_handle.snd_ctrl_param.fade_state = 3U;
        se_handle.snd_ctrl_param.fade_frame_max = fade_frame;
        se_handle.snd_ctrl_param.fade_frame_cnt = 0;
        se_handle.snd_ctrl_param.fade_vol = 1f;
    }

    // Token: 0x06000322 RID: 802 RVA: 0x000190F4 File Offset: 0x000172F4
    private static void gsSoundCriSeResume( AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.amCriAudioGetGlobal();
        if ( !AppMain.gsSoundCheckSeHandlePause( se_handle ) )
        {
            return;
        }
        se_handle.au_player.Pause( false );
        if ( fade_frame == 0 )
        {
            se_handle.snd_ctrl_param.fade_state = 0U;
            se_handle.snd_ctrl_param.fade_frame_max = ( se_handle.snd_ctrl_param.fade_frame_cnt = 0 );
            se_handle.snd_ctrl_param.fade_vol = 1f;
            return;
        }
        AppMain.gsSoundCriSeSetFadeIn( se_handle, fade_frame );
    }

    // Token: 0x06000323 RID: 803 RVA: 0x0001915D File Offset: 0x0001735D
    private static void gsSoundStopSe( AppMain.GSS_SND_SE_HANDLE se_handle )
    {
        se_handle.au_player.Pause( true );
        se_handle.au_player.Stop( 0 );
    }

    // Token: 0x06000324 RID: 804 RVA: 0x00019177 File Offset: 0x00017377
    private static void gsSoundPlaySe( string se_name, uint se_id, AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame )
    {
        AppMain.gsSoundPlaySe( se_name, se_id, se_handle, fade_frame, false );
    }

    // Token: 0x06000325 RID: 805 RVA: 0x00019184 File Offset: 0x00017384
    private static void gsSoundPlaySe( string se_name, uint se_id, AppMain.GSS_SND_SE_HANDLE se_handle, int fade_frame, bool bDontPlay )
    {
        AppMain.amCriAudioGetGlobal();
        if ( se_handle == null )
        {
            se_handle = AppMain.gsSoundGetDefaultSeHandle();
        }
        if ( se_handle.au_player.IsPaused() )
        {
            se_handle.au_player.Stop( 1 );
        }
        if ( ( se_handle.flag & 2147483648U ) != 0U )
        {
            AppMain.gsSoundInitSeHandle( se_handle, true );
            se_handle.flag |= 2147483648U;
        }
        else
        {
            AppMain.gsSoundInitSeHandle( se_handle, true );
        }
        se_handle.flag |= 2U;
        if ( se_name == null )
        {
            se_name = AppMain.CriAuPlayer.GetCueName( se_id );
        }
        se_handle.au_player.SetCue( se_name );
        AppMain.gsSoundCriSeSetFadeIn( se_handle, fade_frame );
        AppMain.gsSoundSeHandleUpdateVolume( se_handle );
        if ( !bDontPlay )
        {
            se_handle.au_player.Play();
        }
    }

    // Token: 0x06000326 RID: 806 RVA: 0x0001922C File Offset: 0x0001742C
    private static bool gsSoundIsSystemSuspendWait()
    {
        bool result = false;
        if ( AppMain.GsSoundGetSysMainInfo().suspend_wait_count > 0 )
        {
            result = true;
        }
        return result;
    }

    // Token: 0x06000327 RID: 807 RVA: 0x0001924C File Offset: 0x0001744C
    private static void gsSoundUpdateSystemSuspendWait()
    {
        AppMain.GSS_SND_SYS_MAIN_INFO gss_SND_SYS_MAIN_INFO = AppMain.GsSoundGetSysMainInfo();
        if ( gss_SND_SYS_MAIN_INFO.suspend_wait_count > 0 )
        {
            gss_SND_SYS_MAIN_INFO.suspend_wait_count--;
        }
        if ( AppMain.GsMainSysGetSuspendedFlag() )
        {
            gss_SND_SYS_MAIN_INFO.suspend_wait_count = 8;
        }
    }

    // Token: 0x06000328 RID: 808 RVA: 0x00019284 File Offset: 0x00017484
    private static void GsSoundPlaySeById( uint se_id )
    {
        AppMain.gsSoundPlaySe( null, se_id, null, 0 );
    }
}
