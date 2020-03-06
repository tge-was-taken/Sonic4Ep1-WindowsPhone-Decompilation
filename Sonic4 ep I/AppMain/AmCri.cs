using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;

public partial class AppMain
{
    // Token: 0x02000259 RID: 601
    public class AMS_CRIAUDIO_INTERFACE
    {
        // Token: 0x060023D0 RID: 9168 RVA: 0x00149AF0 File Offset: 0x00147CF0
        public AMS_CRIAUDIO_INTERFACE()
        {
            this.auply = AppMain.New<AppMain.CriAuPlayer>( 8 );
            for ( int i = 0; i < 8; i++ )
            {
                this.auply[i].type = 1;
            }
        }

        // Token: 0x040058C1 RID: 22721
        public readonly AppMain.CriAuPlayer[] auply;
    }

    // Token: 0x02000084 RID: 132
    public class CriAuPlayer
    {
        // Token: 0x06001E44 RID: 7748 RVA: 0x00139912 File Offset: 0x00137B12
        public CriAuPlayer()
        {
            this.status = 0;
            this.cue = -1;
        }

        // Token: 0x06001E45 RID: 7749 RVA: 0x00139944 File Offset: 0x00137B44
        public static uint GetCueId( string name )
        {
            AppMain.SOUND_TABLE sound_TABLE = AppMain.sound_fx_list[name];
            return ( uint )sound_TABLE.cue;
        }

        // Token: 0x06001E46 RID: 7750 RVA: 0x00139964 File Offset: 0x00137B64
        public static string GetCueName( uint id )
        {
            foreach ( KeyValuePair<string, AppMain.SOUND_TABLE> keyValuePair in AppMain.sound_fx_list )
            {
                if ( ( long )keyValuePair.Value.cue == ( long )( ( ulong )id ) )
                {
                    return keyValuePair.Key;
                }
            }
            return null;
        }

        // Token: 0x06001E47 RID: 7751 RVA: 0x001399D0 File Offset: 0x00137BD0
        public void SetPitch( float val )
        {
            this.pitch = val;
        }

        // Token: 0x06001E48 RID: 7752 RVA: 0x001399D9 File Offset: 0x00137BD9
        public void SetAisac( string s, float val )
        {
            if ( this.type == 0 )
            {
                this.Pause( ( double )val < 0.1 );
            }
        }

        // Token: 0x06001E49 RID: 7753 RVA: 0x001399F6 File Offset: 0x00137BF6
        internal int GetStatus()
        {
            return this.status;
        }

        // Token: 0x06001E4A RID: 7754 RVA: 0x00139A00 File Offset: 0x00137C00
        internal void Stop()
        {
            if ( this.type == 0 )
            {
                this.activefx = 0;
                this.status_paused = false;
                for ( int i = 0; i < this.effectscount; i++ )
                {
                    if ( this.sound[i] != null )
                    {
                        this.sound[i].Stop();
                    }
                }
                this.status = 0;
                this.status_paused = false;
            }
            else
            {
                this.m_stGMState = MediaState.Stopped;
                if ( this.se_name != null && this.se_name == AppMain.CriAuPlayer.m_ActiveSong )
                {
                    MediaPlayer.Stop();
                }
                this.status = 0;
            }
            this.oldAisacParam = -1000f;
        }

        // Token: 0x06001E4B RID: 7755 RVA: 0x00139A94 File Offset: 0x00137C94
        internal void Update()
        {
            bool flag = true;
            if ( this.type == 0 )
            {
                if ( this.cue == 128 )
                {
                    if ( this.status == 2 && !this.status_paused )
                    {
                        if ( this.sound[0].State == SoundState.Stopped && this.sound[1].State == SoundState.Paused )
                        {
                            this.activefx = 1;
                            this.sound[1].Play();
                            flag = false;
                        }
                        else
                        {
                            flag = ( this.sound[0].State == SoundState.Stopped && this.sound[1].State == SoundState.Stopped );
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                    this.sound[this.activefx].Volume = this.volume[0];
                }
                else
                {
                    for ( int i = 0; i < this.effectscount; i++ )
                    {
                        if ( this.sound[i] != null )
                        {
                            this.sound[i].Volume = this.volume[i];
                            if ( this.status != 2 || this.sound[i].State != SoundState.Stopped )
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
                if ( flag )
                {
                    this.status = 3;
                }
            }
            if ( this.type == 1 )
            {
                if ( AppMain.CriAuPlayer.m_ActiveSong == this.se_name && this.m_fBGVolume != this.volume[0] )
                {
                    MediaPlayer.Volume = this.volume[0];
                    this.m_fBGVolume = this.volume[0];
                }
                if ( this.status != 2 || this.m_stGMState != MediaState.Stopped )
                {
                    flag = false;
                }
                if ( flag )
                {
                    this.status = 3;
                }
            }
        }

        // Token: 0x06001E4C RID: 7756 RVA: 0x00139C07 File Offset: 0x00137E07
        internal void Stop( int mode )
        {
            this.Stop();
            if ( mode == 0 )
            {
                this.ReleaseCue();
            }
        }

        // Token: 0x06001E4D RID: 7757 RVA: 0x00139C18 File Offset: 0x00137E18
        internal void Pause( bool pause )
        {
            if ( this.type == 0 )
            {
                if ( this.cue == 128 )
                {
                    if ( this.sound[this.activefx] != null )
                    {
                        if ( pause )
                        {
                            this.sound[this.activefx].Pause();
                        }
                        else
                        {
                            this.sound[this.activefx].Resume();
                        }
                    }
                }
                else
                {
                    for ( int i = 0; i < this.effectscount; i++ )
                    {
                        if ( this.sound[i] != null )
                        {
                            if ( pause )
                            {
                                this.sound[i].Pause();
                            }
                            else
                            {
                                this.sound[i].Resume();
                            }
                        }
                    }
                }
                this.status_paused = pause;
                return;
            }
            if ( pause )
            {
                this.m_stGMState = MediaState.Paused;
                if ( this.se_name == AppMain.CriAuPlayer.m_ActiveSong )
                {
                    MediaPlayer.Pause();
                    return;
                }
            }
            else
            {
                if ( AppMain.CriAuPlayer.m_ActiveSong != this.se_name )
                {
                    string text = this.se_name;
                    this.se_name = null;
                    this.SetCue( text );
                    this.Play();
                    return;
                }
                this.m_stGMState = MediaState.Playing;
                MediaPlayer.Resume();
            }
        }

        // Token: 0x06001E4E RID: 7758 RVA: 0x00139D18 File Offset: 0x00137F18
        internal void SetVolume( float volume )
        {
            if ( this.aisac == null )
            {
                if ( this.type == 0 )
                {
                    for ( int i = 0; i < this.effectscount; i++ )
                    {
                        if ( this.sound[i] != null )
                        {
                            this.volume[i] = volume;
                            this.sound[i].Volume = volume;
                        }
                    }
                    return;
                }
                if ( AppMain.CriAuPlayer.m_ActiveSong == this.se_name && this.m_fBGVolume != volume )
                {
                    this.m_fBGVolume = volume;
                    this.volume[0] = volume;
                    MediaPlayer.Volume = volume;
                }
            }
        }

        // Token: 0x06001E4F RID: 7759 RVA: 0x00139D9C File Offset: 0x00137F9C
        public static int LoadSound( string fileName, bool loop, ref int loopStart, ref int loopEnd, out byte[] byteArray, ref int sampleRate, ref int channels, bool bgMusic )
        {
            byteArray = null;
            if ( !bgMusic && AppMain.cacheFxSounds.ContainsKey( fileName ) )
            {
                return 0;
            }
            int result = 0;
            using ( Stream stream = TitleContainer.OpenStream( "Content\\SOUND\\" + fileName + ".wav" ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( stream ) )
                {
                    if ( !bgMusic )
                    {
                        SoundEffect soundEffect = SoundEffect.FromStream(stream);
                        AppMain.cacheFxSounds.Add( fileName, soundEffect );
                    }
                    else
                    {
                        binaryReader.ReadInt32();
                        binaryReader.ReadInt32();
                        binaryReader.ReadInt32();
                        binaryReader.ReadInt32();
                        int num = binaryReader.ReadInt32();
                        binaryReader.ReadInt16();
                        channels = ( int )binaryReader.ReadInt16();
                        sampleRate = binaryReader.ReadInt32();
                        binaryReader.ReadInt32();
                        int num2 = (int)binaryReader.ReadInt16();
                        binaryReader.ReadInt16();
                        if ( num == 18 )
                        {
                            int num3 = (int)binaryReader.ReadInt16();
                            binaryReader.ReadBytes( num3 );
                        }
                        binaryReader.ReadInt32();
                        int num4 = binaryReader.ReadInt32();
                        byteArray = binaryReader.ReadBytes( num4 );
                        result = num4;
                        if ( loop && loopEnd == 0 )
                        {
                            loopEnd = byteArray.Length;
                        }
                        loopStart += loopStart % num2;
                        loopEnd -= loopEnd % num2;
                    }
                }
            }
            return result;
        }

        // Token: 0x06001E50 RID: 7760 RVA: 0x00139EDC File Offset: 0x001380DC
        internal void SetCue( string se_name )
        {
            try
            {
                while ( this.se_name != null )
                {
                    if ( !( this.se_name != se_name ) )
                    {
                        this.Stop();
                        this.status = 1;
                        return;
                    }
                    this.se_name = null;
                }
                AppMain.SOUND_TABLE sound_TABLE = null;
                if ( AppMain.sound_fx_list.ContainsKey( se_name ) )
                {
                    this.cue = -1;
                    this.type = 0;
                    sound_TABLE = AppMain.sound_fx_list[se_name];
                }
                else if ( AppMain.sound_bgm_list.ContainsKey( se_name ) )
                {
                    this.type = 1;
                    sound_TABLE = AppMain.sound_bgm_list[se_name];
                }
                if ( sound_TABLE != null )
                {
                    this.effectscount = sound_TABLE.count;
                    this.se_name = se_name;
                    this.aisac_list = sound_TABLE.asiac;
                    this.cue = sound_TABLE.cue;
                    this.sound = new SoundEffectInstance[this.effectscount];
                    this.volume = new float[this.effectscount];
                    if ( this.type == 0 )
                    {
                        this.activefx = 0;
                        this.status_paused = false;
                        for ( int i = 0; i < this.effectscount; i++ )
                        {
                            if ( AppMain.cacheFxSounds.ContainsKey( sound_TABLE.filename[i] ) )
                            {
                                SoundEffect soundEffect = AppMain.cacheFxSounds[sound_TABLE.filename[i]];
                                this.m_sndEffect = soundEffect;
                                if ( sound_TABLE.loop[i] )
                                {
                                    SoundEffectInstance soundEffectInstance = null;
                                    try
                                    {
                                        soundEffectInstance = soundEffect.CreateInstance();
                                    }
                                    catch ( Exception )
                                    {
                                        GC.Collect();
                                        try
                                        {
                                            soundEffectInstance = soundEffect.CreateInstance();
                                        }
                                        catch ( Exception )
                                        {
                                            this.status = 4;
                                            return;
                                        }
                                    }
                                    this.sound[i] = soundEffectInstance;
                                    this.sound[i].IsLooped = sound_TABLE.loop[i];
                                    soundEffectInstance.Volume = 0f;
                                    soundEffectInstance.Pitch = this.pitch;
                                    soundEffectInstance.Play();
                                    soundEffectInstance.Pause();
                                    soundEffectInstance.Volume = sound_TABLE.volume[i];
                                }
                                else
                                {
                                    this.sound[i] = soundEffect.CreateInstance();
                                    this.sound[i].Volume = sound_TABLE.volume[i];
                                    this.sound[i].Play();
                                }
                            }
                            else
                            {
                                AppMain.mppAssertNotImpl();
                            }
                        }
                    }
                    else
                    {
                        AppMain.CriAuPlayer.m_songBGM = AppMain._GetPreloadedBGM( sound_TABLE.filename[0] );
                        if ( AppMain.CriAuPlayer.m_songBGM == null )
                        {
                            AppMain.CriAuPlayer.m_songBGM = Sonic4Ep1.pInstance.Content.Load<Song>( "Sound/" + sound_TABLE.filename[0] );
                            AppMain.bgmPreloadedList.Add( sound_TABLE.filename[0], AppMain.CriAuPlayer.m_songBGM );
                        }
                        AppMain.CriAuPlayer.m_ActiveSong = se_name;
                        this.m_fBGVolume = -1f;
                        this.m_bLoop = sound_TABLE.loop[0];
                    }
                    this.status = 1;
                }
                else
                {
                    this.status = 4;
                }
            }
            catch ( Exception ex )
            {
                ex.ToString();
                this.status = 4;
            }
        }

        // Token: 0x06001E51 RID: 7761 RVA: 0x0013A1C4 File Offset: 0x001383C4
        internal void Play()
        {
            if ( this.type == 1 )
            {
                if ( this.se_name != AppMain.CriAuPlayer.m_ActiveSong )
                {
                    string text = this.se_name;
                    this.se_name = null;
                    this.SetCue( text );
                }
                if ( this.se_name != null && this.se_name == AppMain.CriAuPlayer.m_ActiveSong )
                {
                    try
                    {
                        MediaPlayer.IsRepeating = this.m_bLoop;
                        MediaPlayer.Stop();
                        this.m_stGMState = MediaState.Playing;
                        MediaPlayer.Play( AppMain.CriAuPlayer.m_songBGM );
                    }
                    catch ( UnauthorizedAccessException )
                    {
                        AppMain.g_ao_sys_global.is_playing_device_bgm_music = true;
                    }
                }
                this.status = 2;
                return;
            }
            if ( this.cue == 128 )
            {
                this.activefx = 0;
                if ( this.sound[0] != null )
                {
                    this.sound[this.activefx].Resume();
                }
            }
            else
            {
                for ( int i = 0; i < this.effectscount; i++ )
                {
                    if ( this.sound[i] != null )
                    {
                        this.sound[i].Pitch = this.pitch;
                        this.sound[i].Resume();
                    }
                    else if ( this.m_sndEffect != null )
                    {
                        this.m_sndEffect.Play();
                    }
                }
            }
            this.status = 2;
        }

        // Token: 0x06001E52 RID: 7762 RVA: 0x0013A2F0 File Offset: 0x001384F0
        internal void ReleaseCue()
        {
            this.se_name = null;
            this.aisac = null;
            this.activefx = -1;
            this.status_paused = false;
            if ( this.type == 0 )
            {
                for ( int i = 0; i < this.effectscount; i++ )
                {
                    if ( this.sound[i] != null )
                    {
                        this.sound[i].Stop();
                        this.sound[i].Dispose();
                        this.sound[i] = null;
                    }
                }
                this.cue = -1;
                this.status = 0;
            }
            else
            {
                this.m_stGMState = MediaState.Stopped;
                if ( this.se_name != null && this.se_name == AppMain.CriAuPlayer.m_ActiveSong )
                {
                    MediaPlayer.Stop();
                }
                AppMain.CriAuPlayer.m_ActiveSong = null;
                this.status = 0;
            }
            this.oldAisacParam = -1000f;
        }

        // Token: 0x06001E53 RID: 7763 RVA: 0x0013A3B0 File Offset: 0x001385B0
        internal void ResetParameters()
        {
            for ( int i = 0; i < this.effectscount; i++ )
            {
                this.volume[i] = 1f;
                this.aisac = null;
            }
        }

        // Token: 0x06001E54 RID: 7764 RVA: 0x0013A3E4 File Offset: 0x001385E4
        internal bool IsPaused()
        {
            if ( this.type != 0 )
            {
                return this.m_stGMState == MediaState.Paused;
            }
            if ( this.cue == 128 )
            {
                return this.status_paused;
            }
            int num = 0;
            if ( num < this.effectscount )
            {
                if ( this.sound[num] != null )
                {
                    return this.sound[num].State == SoundState.Paused;
                }
            }
            return false;
        }

        // Token: 0x06001E55 RID: 7765 RVA: 0x0013A442 File Offset: 0x00138642
        internal int GetNumPlayedSamples()
        {
            return 1;
        }

        // Token: 0x06001E56 RID: 7766 RVA: 0x0013A445 File Offset: 0x00138645
        internal void Destroy()
        {
            this.ReleaseCue();
        }

        // Token: 0x06001E57 RID: 7767 RVA: 0x0013A44D File Offset: 0x0013864D
        internal static AppMain.CriAuPlayer Create( AppMain.AMS_CRIAUDIO_INTERFACE cri_if )
        {
            return new AppMain.CriAuPlayer();
        }

        // Token: 0x04004A04 RID: 18948
        public const int TYPE_FX = 0;

        // Token: 0x04004A05 RID: 18949
        public const int TYPE_BGM = 1;

        // Token: 0x04004A06 RID: 18950
        public const int STOP_MODE_RELEASE = 0;

        // Token: 0x04004A07 RID: 18951
        public const int STOP_MODE_IMMEDIATE = 1;

        // Token: 0x04004A08 RID: 18952
        public const int STATUS_STOP = 0;

        // Token: 0x04004A09 RID: 18953
        public const int STATUS_PREP = 1;

        // Token: 0x04004A0A RID: 18954
        public const int STATUS_PLAYING = 2;

        // Token: 0x04004A0B RID: 18955
        public const int STATUS_PLAYEND = 3;

        // Token: 0x04004A0C RID: 18956
        public const int STATUS_ERROR = 4;

        // Token: 0x04004A0D RID: 18957
        private const float NON_AISAC = -1000f;

        // Token: 0x04004A0E RID: 18958
        public MediaState m_stGMState;

        // Token: 0x04004A0F RID: 18959
        public float m_fBGVolume;

        // Token: 0x04004A10 RID: 18960
        public static string m_ActiveSong;

        // Token: 0x04004A11 RID: 18961
        public int type;

        // Token: 0x04004A12 RID: 18962
        public bool status_paused;

        // Token: 0x04004A13 RID: 18963
        public string se_name;

        // Token: 0x04004A14 RID: 18964
        private string aisac;

        // Token: 0x04004A15 RID: 18965
        public int cue = -1;

        // Token: 0x04004A16 RID: 18966
        private int activefx = -1;

        // Token: 0x04004A17 RID: 18967
        private float[] volume;

        // Token: 0x04004A18 RID: 18968
        public bool m_bLoop;

        // Token: 0x04004A19 RID: 18969
        private float pitch;

        // Token: 0x04004A1A RID: 18970
        public int status;

        // Token: 0x04004A1B RID: 18971
        public SoundEffectInstance[] sound;

        // Token: 0x04004A1C RID: 18972
        private SoundEffect m_sndEffect;

        // Token: 0x04004A1D RID: 18973
        private AppMain.AISAC_LIST[] aisac_list;

        // Token: 0x04004A1E RID: 18974
        private float oldAisacParam = -1000f;

        // Token: 0x04004A1F RID: 18975
        private int effectscount;

        // Token: 0x04004A20 RID: 18976
        public static Song m_songBGM;
    }

    // Token: 0x06000EF6 RID: 3830 RVA: 0x000841A1 File Offset: 0x000823A1
    public static AppMain.AMS_CRIAUDIO_INTERFACE amCriAudioGetGlobal()
    {
        return AppMain.pAu;
    }

    // Token: 0x06000EF7 RID: 3831 RVA: 0x000841A8 File Offset: 0x000823A8
    private void amCriAudioInit()
    {
    }

    // Token: 0x06000EF8 RID: 3832 RVA: 0x000841AC File Offset: 0x000823AC
    private void amCriAudioExit()
    {
        for ( uint num = 0U; num < 8U; num += 1U )
        {
            if ( AppMain.pAu.auply[( int )( ( UIntPtr )num )] != null )
            {
                AppMain.pAu.auply[( int )( ( UIntPtr )num )].Destroy();
                AppMain.pAu.auply[( int )( ( UIntPtr )num )] = null;
            }
        }
    }

    // Token: 0x06000EF9 RID: 3833 RVA: 0x000841F4 File Offset: 0x000823F4
    private void amCriAudioCreateCueSheet( string filePath, int csbType, int prio )
    {
    }

    // Token: 0x06000EFA RID: 3834 RVA: 0x000841F8 File Offset: 0x000823F8
    private void amCriAudioDestroyCueSheet( int csbType )
    {
        for ( uint num = 0U; num < 8U; num += 1U )
        {
            if ( AppMain.pAu.auply[( int )( ( UIntPtr )num )] != null )
            {
                AppMain.pAu.auply[( int )( ( UIntPtr )num )].Destroy();
                AppMain.pAu.auply[( int )( ( UIntPtr )num )] = null;
            }
        }
    }

    // Token: 0x06000EFB RID: 3835 RVA: 0x00084240 File Offset: 0x00082440
    private void amCriAudioExcuteMain()
    {
        for ( uint num = 0U; num < 8U; num += 1U )
        {
            if ( AppMain.pAu.auply[( int )( ( UIntPtr )num )] != null )
            {
                int status = AppMain.pAu.auply[(int)((UIntPtr)num)].GetStatus();
                if ( status != 0 )
                {
                    AppMain.pAu.auply[( int )( ( UIntPtr )num )].Update();
                }
            }
        }
    }

    // Token: 0x06000EFC RID: 3836 RVA: 0x00084290 File Offset: 0x00082490
    private static void amCriAudioStrmPlay( uint Id, string CueName )
    {
        AppMain.pAu.auply[( int )( ( UIntPtr )Id )].Stop();
        AppMain.pAu.auply[( int )( ( UIntPtr )Id )].SetCue( CueName );
        AppMain.pAu.auply[( int )( ( UIntPtr )Id )].Play();
    }
}