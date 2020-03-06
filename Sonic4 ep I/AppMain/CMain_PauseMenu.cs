using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ao;
using accel;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Runtime.InteropServices;
using er;
using setting;

public partial class AppMain
{
    // Token: 0x0200030F RID: 783
    private class CMain_PauseMenu : AppMain.ITaskLinkAsv
    {
        // Token: 0x0600253B RID: 9531 RVA: 0x0014C298 File Offset: 0x0014A498
        private CMain_PauseMenu()
        {
            this.m_procCount = new AppMain.CProcCount( this );
        }

        // Token: 0x0600253C RID: 9532 RVA: 0x0014C301 File Offset: 0x0014A501
        public static AppMain.CMain_PauseMenu CreateInstance()
        {
            return AppMain.CMain_PauseMenu.instance_;
        }

        // Token: 0x0600253D RID: 9533 RVA: 0x0014C308 File Offset: 0x0014A508
        public override void operator_brackets()
        {
            if ( this.m_flag[0] )
            {
                this.preUpdate();
            }
            this.m_procCount.operator_brackets();
            if ( this.m_flag[0] )
            {
                this.update();
                this.draw();
            }
        }

        // Token: 0x0600253E RID: 9534 RVA: 0x0014C33B File Offset: 0x0014A53B
        public bool Create()
        {
            return true;
        }

        // Token: 0x0600253F RID: 9535 RVA: 0x0014C340 File Offset: 0x0014A540
        public void Release()
        {
            if ( this.m_flag[0] )
            {
                if ( this.m_flag[3] )
                {
                    for ( int i = 0; i < this.m_file.Length; i++ )
                    {
                        this.m_file[0] = null;
                    }
                    this.m_flag[3] = false;
                    this.m_flag[4] = false;
                }
                base.DetachTask();
                this.m_flag.Initialize();
            }
        }

        // Token: 0x06002540 RID: 9536 RVA: 0x0014C3A0 File Offset: 0x0014A5A0
        public void LoadFile()
        {
            this.fileLoadingStart();
        }

        // Token: 0x06002541 RID: 9537 RVA: 0x0014C3A8 File Offset: 0x0014A5A8
        public void CreateTexture()
        {
            this.creatingStart();
        }

        // Token: 0x06002542 RID: 9538 RVA: 0x0014C3B0 File Offset: 0x0014A5B0
        public void ReleaseTexture()
        {
            this.releasingStart();
        }

        // Token: 0x06002543 RID: 9539 RVA: 0x0014C3B8 File Offset: 0x0014A5B8
        public void Start( uint prio )
        {
            this.fadeInStart( ( int )prio );
        }

        // Token: 0x06002544 RID: 9540 RVA: 0x0014C3C1 File Offset: 0x0014A5C1
        public void Cancel()
        {
            this.m_flag[8] = true;
        }

        // Token: 0x06002545 RID: 9541 RVA: 0x0014C3CC File Offset: 0x0014A5CC
        public bool IsValid()
        {
            return this.m_flag[6];
        }

        // Token: 0x06002546 RID: 9542 RVA: 0x0014C3D6 File Offset: 0x0014A5D6
        public bool IsEmpty()
        {
            return !this.m_flag[0];
        }

        // Token: 0x06002547 RID: 9543 RVA: 0x0014C3E3 File Offset: 0x0014A5E3
        public bool IsLoadFile()
        {
            return this.m_flag[4];
        }

        // Token: 0x06002548 RID: 9544 RVA: 0x0014C3ED File Offset: 0x0014A5ED
        public bool IsCreatedTexture()
        {
            return this.m_flag[6];
        }

        // Token: 0x06002549 RID: 9545 RVA: 0x0014C3F7 File Offset: 0x0014A5F7
        public bool IsReleasedTexture()
        {
            return !this.m_flag[5];
        }

        // Token: 0x0600254A RID: 9546 RVA: 0x0014C404 File Offset: 0x0014A604
        public bool IsPlay()
        {
            return !this.m_flag[7];
        }

        // Token: 0x0600254B RID: 9547 RVA: 0x0014C411 File Offset: 0x0014A611
        public int GetResult()
        {
            return this.m_return;
        }

        // Token: 0x0600254C RID: 9548 RVA: 0x0014C41C File Offset: 0x0014A61C
        private void preUpdate()
        {
            if ( this.m_flag[7] && !this.m_flag[1] )
            {
                for ( int i = 0; i < this.m_trg.Length; i++ )
                {
                    this.m_trg[i].Update();
                }
            }
        }

        // Token: 0x0600254D RID: 9549 RVA: 0x0014C460 File Offset: 0x0014A660
        private void update()
        {
            if ( this.m_flag[7] )
            {
                AppMain.AoActAcmPush();
                AppMain.AoActAcmApplyTrans( 0f, 0f, -1000f );
                for ( int i = 0; i < this.m_act.Length; i++ )
                {
                    this.m_act[i].Update();
                    if ( i == 16 || i == 15 )
                    {
                        this.m_act[i].act.sprite.center_y += 5f;
                    }
                }
                AppMain.AoActAcmPop();
            }
        }

        // Token: 0x0600254E RID: 9550 RVA: 0x0014C4E4 File Offset: 0x0014A6E4
        private void draw()
        {
            if ( AppMain._am_sample_draw_enable && this.m_flag[7] && !this.m_flag[1] )
            {
                for ( int i = 0; i < this.m_act.Length; i++ )
                {
                    this.m_act[i].Draw();
                }
            }
        }

        // Token: 0x0600254F RID: 9551 RVA: 0x0014C52C File Offset: 0x0014A72C
        private void fileLoadingStart()
        {
            this.m_file[0] = AppMain.readAMAFile( "G_COM/MENU/G_PAUSE.AMA" );
            this.pause_amb = AppMain.amFsReadBackground( "G_COM/MENU/G_PAUSE.AMB" );
            this.m_file[1] = AppMain.readAMAFile( "G_COM/MENU/G_PAUSE_L.AMA" );
            int num = AppMain.GsEnvGetLanguage();
            this.lang_amb = AppMain.amFsReadBackground( file.c_lang_amb[num] );
            this.m_flag[0] = true;
            this.m_flag[3] = true;
            base.AttachTask( "gmPauseMenu.Load", 28928U, 0U, 0U );
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.fileLoading ) );
        }

        // Token: 0x06002550 RID: 9552 RVA: 0x0014C5C0 File Offset: 0x0014A7C0
        private void fileLoading()
        {
            if ( !AppMain.amFsIsComplete( this.pause_amb ) )
            {
                return;
            }
            this.m_file[2] = AppMain.readAMBFile( this.pause_amb );
            AppMain.GsEnvGetLanguage();
            if ( !AppMain.amFsIsComplete( this.lang_amb ) )
            {
                return;
            }
            this.m_file[3] = AppMain.readAMBFile( this.lang_amb );
            this.m_flag[4] = true;
            base.DetachTask();
        }

        // Token: 0x06002551 RID: 9553 RVA: 0x0014C624 File Offset: 0x0014A824
        private void creatingStart()
        {
            for ( int i = 0; i < AppMain.CMain_PauseMenu.c_local_create_table.Length; i++ )
            {
                int num = AppMain.CMain_PauseMenu.c_local_create_table[i];
                AppMain.AoTexBuild( this.m_tex[i], ( AppMain.AMS_AMB_HEADER )this.m_file[num] );
                AppMain.AoTexLoad( this.m_tex[i] );
            }
            this.m_flag[5] = true;
            base.AttachTask( "gmPauseMenu.Build", 28928U, 0U, 0U );
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.creating ) );
        }

        // Token: 0x06002552 RID: 9554 RVA: 0x0014C6A4 File Offset: 0x0014A8A4
        private void creating()
        {
            bool flag = true;
            for ( int i = 0; i < this.m_tex.Length; i++ )
            {
                if ( !AppMain.AoTexIsLoaded( this.m_tex[i] ) )
                {
                    flag = false;
                    break;
                }
            }
            if ( flag )
            {
                this.m_flag[6] = true;
                base.DetachTask();
            }
        }

        // Token: 0x06002553 RID: 9555 RVA: 0x0014C6EB File Offset: 0x0014A8EB
        private void fadeInStart()
        {
            this.fadeInStart( 28928 );
        }

        // Token: 0x06002554 RID: 9556 RVA: 0x0014C6F8 File Offset: 0x0014A8F8
        private void fadeInStart( int prio )
        {
            if ( !AppMain.CMain_PauseMenu.canGoStageSelect() )
            {
                AppMain.CMain_PauseMenu.local_create_action_table[11].idx = 2;
                AppMain.CMain_PauseMenu.local_create_action_table[14].idx = 7;
            }
            else
            {
                AppMain.CMain_PauseMenu.local_create_action_table[11].idx = 1;
                AppMain.CMain_PauseMenu.local_create_action_table[14].idx = 5;
            }
            if ( AppMain.CMain_PauseMenu.isSpecialStage() )
            {
                AppMain.CMain_PauseMenu.local_create_action_table[13].idx = 6;
            }
            else
            {
                AppMain.CMain_PauseMenu.local_create_action_table[13].idx = 4;
            }
            for ( int i = 0; i < 17; i++ )
            {
                AppMain.CMain_PauseMenu.SLocalCreateActionTable slocalCreateActionTable = AppMain.CMain_PauseMenu.local_create_action_table[i];
                AppMain.A2S_AMA_HEADER ama = (AppMain.A2S_AMA_HEADER)this.m_file[slocalCreateActionTable.file];
                AppMain.CMain_PauseMenu.SAction saction = this.m_act[i];
                saction.act = AppMain.AoActCreate( ama, ( uint )slocalCreateActionTable.idx );
                saction.tex = this.m_tex[slocalCreateActionTable.tex];
                saction.flag[0] = true;
                saction.flag[1] = true;
                saction.AcmInit();
            }
            for ( int j = 0; j < 3; j++ )
            {
                AppMain.CMain_PauseMenu.SAction saction2 = this.m_act[AppMain.CMain_PauseMenu.c_local_create_trg_table[j]];
                CTrgAoAction ctrgAoAction = this.m_trg[j];
                ctrgAoAction.Create( saction2.act );
            }
            this.m_flag[7] = true;
            this.m_act[0].flag[1] = false;
            this.m_act[0].scale = new Vector2( 0f, 0f );
            this.m_se_handle = AppMain.GsSoundAllocSeHandle();
            base.AttachTask( "gmPauseMenu.Execute", ( uint )prio, 0U, 0U );
            this.playSe( 0 );
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.fadeIn ) );
        }

        // Token: 0x06002555 RID: 9557 RVA: 0x0014C880 File Offset: 0x0014AA80
        private void fadeIn()
        {
            if ( 15U < this.m_procCount.GetCount() )
            {
                this.playSe( 3 );
                this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.fadeIn2 ) );
            }
        }

        // Token: 0x06002556 RID: 9558 RVA: 0x0014C8B0 File Offset: 0x0014AAB0
        private void fadeIn2()
        {
            float num = this.m_procCount.GetCount() / 8U;
            this.m_act[0].scale = new Vector2( num, num );
            if ( 8U < this.m_procCount.GetCount() )
            {
                this.waitStart();
            }
        }

        // Token: 0x06002557 RID: 9559 RVA: 0x0014C8F8 File Offset: 0x0014AAF8
        private void waitStart()
        {
            for ( int i = 1; i < 13; i++ )
            {
                this.m_act[i].flag[1] = false;
            }
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.wait ) );
        }

        // Token: 0x06002558 RID: 9560 RVA: 0x0014C93C File Offset: 0x0014AB3C
        private void wait()
        {
            bool flag = false;
            for ( int i = 0; i < AppMain._am_tp_touch.Length; i++ )
            {
                if ( AppMain.amTpIsTouchOn( i ) )
                {
                    flag = true;
                    break;
                }
            }
            if ( !flag || 60U < this.m_procCount.GetCount() )
            {
                this.selectStart();
            }
        }

        // Token: 0x06002559 RID: 9561 RVA: 0x0014C984 File Offset: 0x0014AB84
        private void selectStart()
        {
            for ( int i = 0; i < this.m_act.Length; i++ )
            {
                this.m_act[i].flag[0] = true;
                AppMain.AoActSetFrame( this.m_act[i].act, 0f );
                this.m_act[i].pos = new Vector3( 0f, 0f, 0f );
            }
            for ( int j = 1; j < 13; j++ )
            {
                this.m_act[j].flag[1] = false;
            }
            for ( int k = 13; k < 17; k++ )
            {
                this.m_act[k].flag[1] = true;
            }
            this.m_return = 6;
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.select ) );
        }

        // Token: 0x0600255A RID: 9562 RVA: 0x0014CA48 File Offset: 0x0014AC48
        private void select()
        {
            int num = -1;
            for ( int i = 0; i < AppMain.CMain_PauseMenu.c_trg_table_select.Length; i++ )
            {
                CTrgAoAction ctrgAoAction = this.m_trg[AppMain.CMain_PauseMenu.c_trg_table_select[i]];
                float frame;
                if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
                {
                    frame = 2f;
                    num = i;
                }
                else if ( ctrgAoAction.GetState( 0U )[0] )
                {
                    frame = 3f;
                }
                else
                {
                    frame = 0f;
                }
                for ( int j = 0; j < AppMain.CMain_PauseMenu.c_btn_action_table_select[i].Length; j++ )
                {
                    int[] array = AppMain.CMain_PauseMenu.c_btn_action_table_select[i];
                    AppMain.AoActSetFrame( this.m_act[array[j]].act, frame );
                }
            }
            if ( -1 != num )
            {
                int[] array2 = AppMain.CMain_PauseMenu.c_btn_action_table_select[num];
                for ( int k = array2[0]; k < array2[2] + 1; k++ )
                {
                    this.m_act[k].flag[0] = false;
                }
                this.m_return = AppMain.CMain_PauseMenu.TrgIdxToReturnIdx( num );
            }
            else if ( this.m_flag[8] )
            {
                this.m_return = 4;
            }
            if ( 0 <= AppMain.GmMainKeyCheckPauseKeyPush() )
            {
                this.pauseBtnCancelStart();
                return;
            }
            if ( AppMain.isBackKeyPressed() )
            {
                this.m_return = 4;
                AppMain.setBackKeyRequest( false );
            }
            switch ( this.m_return )
            {
                case 4:
                    this.playSe( 1 );
                    this.enterEfctStart();
                    return;
                case 6:
                    return;
            }
            this.playSe( 0 );
            this.reallyStart();
        }

        // Token: 0x0600255B RID: 9563 RVA: 0x0014CBB0 File Offset: 0x0014ADB0
        private void reallyStart()
        {
            for ( int i = 0; i < this.m_act.Length; i++ )
            {
                AppMain.CMain_PauseMenu.SAction saction = this.m_act[i];
                saction.flag[0] = true;
                AppMain.AoActSetFrame( saction.act, 0f );
                saction.pos = new Vector3( 0f, 0f, 0f );
            }
            for ( int j = 7; j < 10; j++ )
            {
                this.m_act[j].flag[1] = true;
            }
            for ( int k = 13; k < 15; k++ )
            {
                AppMain.CMain_PauseMenu.SAction saction2 = this.m_act[k];
                float num = 1.6875f;
                saction2.pos = new Vector3( 480f, 269f, 0f );
                saction2.scale = new Vector2( num, num );
            }
            switch ( this.m_return )
            {
                case 0:
                    this.m_act[13].flag[1] = false;
                    this.m_act[14].flag[1] = true;
                    this.m_act[10].flag[1] = true;
                    this.m_act[11].flag[1] = true;
                    this.m_act[12].flag[1] = true;
                    this.m_act[15].flag[1] = false;
                    this.m_act[16].flag[1] = false;
                    for ( int l = 1; l < 4; l++ )
                    {
                        this.m_act[l].pos = new Vector3( 0f, 194f, 0f );
                    }
                    for ( int m = 4; m < 7; m++ )
                    {
                        this.m_act[m].pos = new Vector3( 0f, 194f, 0f );
                    }
                    break;
                case 2:
                case 3:
                    this.m_act[13].flag[1] = true;
                    this.m_act[14].flag[1] = false;
                    this.m_act[10].flag[1] = true;
                    this.m_act[11].flag[1] = true;
                    this.m_act[12].flag[1] = true;
                    this.m_act[15].flag[1] = false;
                    this.m_act[16].flag[1] = false;
                    for ( int n = 1; n < 4; n++ )
                    {
                        this.m_act[n].pos = new Vector3( 380f, 194f, 0f );
                    }
                    for ( int num2 = 4; num2 < 7; num2++ )
                    {
                        this.m_act[num2].pos = new Vector3( -380f, 194f, 0f );
                    }
                    break;
            }
            this.m_really = 6;
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.really ) );
        }

        // Token: 0x0600255C RID: 9564 RVA: 0x0014CE70 File Offset: 0x0014B070
        private void really()
        {
            int num = -1;
            for ( int i = 0; i < AppMain.CMain_PauseMenu.c_trg_table.Length; i++ )
            {
                CTrgAoAction ctrgAoAction = this.m_trg[AppMain.CMain_PauseMenu.c_trg_table[i]];
                float frame;
                if ( ctrgAoAction.GetState( 0U )[10] && ctrgAoAction.GetState( 0U )[1] )
                {
                    frame = 2f;
                    num = i;
                }
                else if ( ctrgAoAction.GetState( 0U )[0] )
                {
                    frame = 3f;
                }
                else
                {
                    frame = 0f;
                }
                for ( int j = 0; j < AppMain.CMain_PauseMenu.c_btn_action_table[i].Length; j++ )
                {
                    int[] array = AppMain.CMain_PauseMenu.c_btn_action_table[i];
                    AppMain.AoActSetFrame( this.m_act[array[j]].act, frame );
                }
            }
            if ( -1 != num )
            {
                int[] array2 = AppMain.CMain_PauseMenu.c_btn_action_table[num];
                for ( int k = array2[0]; k < array2[2] + 1; k++ )
                {
                    this.m_act[k].flag[0] = false;
                }
                this.m_really = AppMain.CMain_PauseMenu.TrgIdxToReturnIdx( num );
            }
            else if ( this.m_flag[8] )
            {
                this.m_really = 4;
            }
            if ( 0 <= AppMain.GmMainKeyCheckPauseKeyPush() )
            {
                this.m_return = 4;
                this.pauseBtnCancelStart();
                return;
            }
            if ( AppMain.isBackKeyPressed() )
            {
                this.m_return = 4;
                AppMain.setBackKeyRequest( false );
                this.playSe( 1 );
                this.selectStart();
                return;
            }
            if ( 6 == this.m_really )
            {
                return;
            }
            if ( this.m_return == this.m_really )
            {
                this.playSe( 0 );
                this.enterEfctStart();
                return;
            }
            this.playSe( 1 );
            this.selectStart();
        }

        // Token: 0x0600255D RID: 9565 RVA: 0x0014CFE4 File Offset: 0x0014B1E4
        private void enterEfctStart()
        {
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.enterEfct ) );
        }

        // Token: 0x0600255E RID: 9566 RVA: 0x0014CFFD File Offset: 0x0014B1FD
        private void enterEfct()
        {
            if ( 10U < this.m_procCount.GetCount() )
            {
                this.fadeOutStart();
            }
        }

        // Token: 0x0600255F RID: 9567 RVA: 0x0014D014 File Offset: 0x0014B214
        private void pauseBtnCancelStart()
        {
            this.playSe( 0 );
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.pauseBtnCancel ) );
        }

        // Token: 0x06002560 RID: 9568 RVA: 0x0014D034 File Offset: 0x0014B234
        private void pauseBtnCancel()
        {
            if ( 15U < this.m_procCount.GetCount() )
            {
                this.fadeOutStart();
            }
        }

        // Token: 0x06002561 RID: 9569 RVA: 0x0014D04C File Offset: 0x0014B24C
        private void fadeOutStart()
        {
            foreach ( AppMain.CMain_PauseMenu.SAction saction in this.m_act )
            {
                saction.flag[0] = true;
                saction.flag[1] = true;
            }
            this.m_act[0].flag[0] = false;
            this.m_act[0].flag[1] = false;
            this.playSe( 3 );
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.fadeOut ) );
        }

        // Token: 0x06002562 RID: 9570 RVA: 0x0014D0C4 File Offset: 0x0014B2C4
        private void fadeOut()
        {
            float num = 1f - this.m_procCount.GetCount() / 8U;
            this.m_act[0].scale = new Vector2( num, num );
            if ( 8U < this.m_procCount.GetCount() )
            {
                foreach ( AppMain.CMain_PauseMenu.SAction saction in this.m_act )
                {
                    AppMain.AoActDelete( saction.act );
                }
                AppMain.GsSoundFreeSeHandle( this.m_se_handle );
                this.m_flag[7] = false;
                base.DetachTask();
            }
        }

        // Token: 0x06002563 RID: 9571 RVA: 0x0014D148 File Offset: 0x0014B348
        private void releasingStart()
        {
            foreach ( AppMain.AOS_TEXTURE tex2 in this.m_tex )
            {
                AppMain.AoTexRelease( tex2 );
            }
            base.AttachTask( "gmPauseMenu.Flush", 28928U, 0U, 0U );
            this.m_procCount.SetProc( new AppMain.ITaskAsv.FProc( this.releasing ) );
        }

        // Token: 0x06002564 RID: 9572 RVA: 0x0014D1A0 File Offset: 0x0014B3A0
        private void releasing()
        {
            bool flag = true;
            foreach ( AppMain.AOS_TEXTURE tex2 in this.m_tex )
            {
                if ( !AppMain.AoTexIsReleased( tex2 ) )
                {
                    flag = false;
                    break;
                }
            }
            if ( flag )
            {
                this.m_flag[5] = false;
                this.m_flag[6] = false;
                base.DetachTask();
            }
        }

        // Token: 0x06002565 RID: 9573 RVA: 0x0014D1EF File Offset: 0x0014B3EF
        private void playSe( int se )
        {
            AppMain.GmSoundPlaySE( AppMain.CMain_PauseMenu.c_se_name_tbl[se] );
        }

        // Token: 0x06002566 RID: 9574 RVA: 0x0014D1FD File Offset: 0x0014B3FD
        private static bool canGoStageSelect()
        {
            return AppMain.GsMainSysIsStageClear( 0 ) && !AppMain.GsTrialIsTrial();
        }

        // Token: 0x06002567 RID: 9575 RVA: 0x0014D211 File Offset: 0x0014B411
        private static bool isSpecialStage()
        {
            return AppMain.GSM_MAIN_STAGE_IS_SPSTAGE();
        }

        // Token: 0x06002568 RID: 9576 RVA: 0x0014D218 File Offset: 0x0014B418
        private static int TrgIdxToReturnIdx( int trg_idx )
        {
            int num = AppMain.CMain_PauseMenu.c_return_table[trg_idx];
            if ( !AppMain.CMain_PauseMenu.canGoStageSelect() && 2 == num )
            {
                num = 3;
            }
            return num;
        }

        // Token: 0x04005D4C RID: 23884
        private const uint c_pause_btn_se_frame = 15U;

        // Token: 0x04005D4D RID: 23885
        private const uint c_fade_in_frame = 8U;

        // Token: 0x04005D4E RID: 23886
        private const uint c_fade_out_frame = 8U;

        // Token: 0x04005D4F RID: 23887
        private const uint c_fade_enter_efct_frame = 10U;

        // Token: 0x04005D50 RID: 23888
        public AppMain.AMS_FS pause_amb;

        // Token: 0x04005D51 RID: 23889
        public AppMain.AMS_FS lang_amb;

        // Token: 0x04005D52 RID: 23890
        private static AppMain.CMain_PauseMenu instance_ = new AppMain.CMain_PauseMenu();

        // Token: 0x04005D53 RID: 23891
        private static readonly int[] c_return_table = new int[]
        {
            default(int),
            2,
            4
        };

        // Token: 0x04005D54 RID: 23892
        private readonly bool[] m_flag = new bool[9];

        // Token: 0x04005D55 RID: 23893
        private int m_return;

        // Token: 0x04005D56 RID: 23894
        private int m_really;

        // Token: 0x04005D57 RID: 23895
        private readonly AppMain.AMS_FS[] m_fs = new AppMain.AMS_FS[4];

        // Token: 0x04005D58 RID: 23896
        private readonly object[] m_file = new object[4];

        // Token: 0x04005D59 RID: 23897
        private readonly AppMain.AOS_TEXTURE[] m_tex = AppMain.New<AppMain.AOS_TEXTURE>(2);

        // Token: 0x04005D5A RID: 23898
        private AppMain.CMain_PauseMenu.SAction[] m_act = AppMain.New<AppMain.CMain_PauseMenu.SAction>(17);

        // Token: 0x04005D5B RID: 23899
        private readonly CTrgAoAction[] m_trg = AppMain.New<CTrgAoAction>(3);

        // Token: 0x04005D5C RID: 23900
        private AppMain.GSS_SND_SE_HANDLE m_se_handle;

        // Token: 0x04005D5D RID: 23901
        private AppMain.CProcCount m_procCount;

        // Token: 0x04005D5E RID: 23902
        private static readonly int[] c_local_create_table = new int[]
        {
            2,
            3
        };

        // Token: 0x04005D5F RID: 23903
        private static AppMain.CMain_PauseMenu.SLocalCreateActionTable[] local_create_action_table = new AppMain.CMain_PauseMenu.SLocalCreateActionTable[]
        {
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 0
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 1
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 2
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 3
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 4
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 5
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 6
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 7
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 8
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 0,
                tex = 0,
                idx = 9
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 0
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 1
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 3
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 4
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 5
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 9
            },
            new AppMain.CMain_PauseMenu.SLocalCreateActionTable
            {
                file = 1,
                tex = 1,
                idx = 8
            }
        };

        // Token: 0x04005D60 RID: 23904
        private static int[] c_local_create_trg_table = new int[]
        {
            2,
            5,
            8
        };

        // Token: 0x04005D61 RID: 23905
        private static readonly int[] c_trg_table_select = new int[]
        {
            default(int),
            1,
            2
        };

        // Token: 0x04005D62 RID: 23906
        private static readonly int[][] c_btn_action_table_select = new int[][]
        {
            new int[]
            {
                1,
                2,
                3
            },
            new int[]
            {
                4,
                5,
                6
            },
            new int[]
            {
                7,
                8,
                9
            }
        };

        // Token: 0x04005D63 RID: 23907
        private static readonly int[] c_trg_table = new int[]
        {
            default(int),
            1
        };

        // Token: 0x04005D64 RID: 23908
        private static readonly int[][] c_btn_action_table = new int[][]
        {
            new int[]
            {
                1,
                2,
                3
            },
            new int[]
            {
                4,
                5,
                6
            }
        };

        // Token: 0x04005D65 RID: 23909
        private static readonly string[] c_se_name_tbl = new string[]
        {
            "Ok",
            "Cancel",
            "Window",
            "Pause"
        };

        // Token: 0x02000310 RID: 784
        private class EReturn
        {
            // Token: 0x04005D66 RID: 23910
            public const int Retry = 0;

            // Token: 0x04005D67 RID: 23911
            public const int Option = 1;

            // Token: 0x04005D68 RID: 23912
            public const int Back = 2;

            // Token: 0x04005D69 RID: 23913
            public const int MainMenu = 3;

            // Token: 0x04005D6A RID: 23914
            public const int Cancel = 4;

            // Token: 0x04005D6B RID: 23915
            public const int Max = 5;

            // Token: 0x04005D6C RID: 23916
            public const int None = 6;
        }

        // Token: 0x02000311 RID: 785
        private class BFlag
        {
            // Token: 0x04005D6D RID: 23917
            public const int Create = 0;

            // Token: 0x04005D6E RID: 23918
            public const int NoUpdate = 1;

            // Token: 0x04005D6F RID: 23919
            public const int NoDraw = 2;

            // Token: 0x04005D70 RID: 23920
            public const int LoadFile = 3;

            // Token: 0x04005D71 RID: 23921
            public const int LoadedFile = 4;

            // Token: 0x04005D72 RID: 23922
            public const int CreateTexture = 5;

            // Token: 0x04005D73 RID: 23923
            public const int CreatedTexture = 6;

            // Token: 0x04005D74 RID: 23924
            public const int Start = 7;

            // Token: 0x04005D75 RID: 23925
            public const int ReqCancel = 8;

            // Token: 0x04005D76 RID: 23926
            public const int Max = 9;

            // Token: 0x04005D77 RID: 23927
            public const int None = 10;
        }

        // Token: 0x02000312 RID: 786
        private class EMemFile
        {
            // Token: 0x04005D78 RID: 23928
            public const int Ama = 0;

            // Token: 0x04005D79 RID: 23929
            public const int AmaLang = 1;

            // Token: 0x04005D7A RID: 23930
            public const int Amb = 2;

            // Token: 0x04005D7B RID: 23931
            public const int AmbLang = 3;

            // Token: 0x04005D7C RID: 23932
            public const int Max = 4;

            // Token: 0x04005D7D RID: 23933
            public const int None = 5;
        }

        // Token: 0x02000313 RID: 787
        private class ETex
        {
            // Token: 0x04005D7E RID: 23934
            public const int Amb = 0;

            // Token: 0x04005D7F RID: 23935
            public const int AmbLang = 1;

            // Token: 0x04005D80 RID: 23936
            public const int Max = 2;

            // Token: 0x04005D81 RID: 23937
            public const int None = 3;
        }

        // Token: 0x02000314 RID: 788
        private class EAct
        {
            // Token: 0x04005D82 RID: 23938
            public const int Bgi = 0;

            // Token: 0x04005D83 RID: 23939
            public const int Btn1Left = 1;

            // Token: 0x04005D84 RID: 23940
            public const int Btn1Center = 2;

            // Token: 0x04005D85 RID: 23941
            public const int Btn1Right = 3;

            // Token: 0x04005D86 RID: 23942
            public const int Btn3Left = 4;

            // Token: 0x04005D87 RID: 23943
            public const int Btn3Center = 5;

            // Token: 0x04005D88 RID: 23944
            public const int Btn3Right = 6;

            // Token: 0x04005D89 RID: 23945
            public const int Btn4Left = 7;

            // Token: 0x04005D8A RID: 23946
            public const int Btn4Center = 8;

            // Token: 0x04005D8B RID: 23947
            public const int Btn4Right = 9;

            // Token: 0x04005D8C RID: 23948
            public const int Retry = 10;

            // Token: 0x04005D8D RID: 23949
            public const int Back = 11;

            // Token: 0x04005D8E RID: 23950
            public const int Cancel = 12;

            // Token: 0x04005D8F RID: 23951
            public const int MsgRetry = 13;

            // Token: 0x04005D90 RID: 23952
            public const int MsgReturn = 14;

            // Token: 0x04005D91 RID: 23953
            public const int No = 15;

            // Token: 0x04005D92 RID: 23954
            public const int Yes = 16;

            // Token: 0x04005D93 RID: 23955
            public const int Max = 17;

            // Token: 0x04005D94 RID: 23956
            public const int None = 18;
        }

        // Token: 0x02000315 RID: 789
        private class ETrg
        {
            // Token: 0x04005D95 RID: 23957
            public const int Btn1 = 0;

            // Token: 0x04005D96 RID: 23958
            public const int Btn3 = 1;

            // Token: 0x04005D97 RID: 23959
            public const int Btn4 = 2;

            // Token: 0x04005D98 RID: 23960
            public const int Max = 3;

            // Token: 0x04005D99 RID: 23961
            public const int None = 4;
        }

        // Token: 0x02000316 RID: 790
        private class SAction
        {
            // Token: 0x06002570 RID: 9584 RVA: 0x0014D68D File Offset: 0x0014B88D
            public void AcmInit()
            {
                this.pos = new Vector3( 0f, 0f, 0f );
                this.scale = new Vector2( 1f, 1f );
                this.color.c = uint.MaxValue;
            }

            // Token: 0x06002571 RID: 9585 RVA: 0x0014D6CC File Offset: 0x0014B8CC
            public void Update()
            {
                AppMain.AoActAcmPush();
                float frame = this.flag[0] ? 0f : 1f;
                AppMain.AoActSetTexture( AppMain.AoTexGetTexList( this.tex ) );
                if ( 1f != this.scale.X || 1f != this.scale.Y )
                {
                    AppMain.AoActAcmApplyScale( this.scale.X, this.scale.Y );
                }
                if ( 0f != this.pos.X || 0f != this.pos.Y || 0f != this.pos.Z )
                {
                    AppMain.AoActAcmApplyTrans( this.pos.X, this.pos.Y, this.pos.Z );
                }
                if ( 4294967295U != this.color.c )
                {
                    AppMain.AoActAcmApplyColor( this.color );
                }
                AppMain.AoActUpdate( this.act, frame );
                AppMain.AoActAcmPop();
            }

            // Token: 0x06002572 RID: 9586 RVA: 0x0014D7CA File Offset: 0x0014B9CA
            public void Draw()
            {
                if ( !this.flag[1] )
                {
                    AppMain.AoActSortRegAction( this.act );
                }
            }

            // Token: 0x04005D9A RID: 23962
            public AppMain.AOS_ACTION act;

            // Token: 0x04005D9B RID: 23963
            public AppMain.AOS_TEXTURE tex;

            // Token: 0x04005D9C RID: 23964
            public readonly bool[] flag = new bool[2];

            // Token: 0x04005D9D RID: 23965
            public Vector2 scale;

            // Token: 0x04005D9E RID: 23966
            public Vector3 pos;

            // Token: 0x04005D9F RID: 23967
            public AppMain.AOS_ACT_COL color;

            // Token: 0x02000317 RID: 791
            public class BFlag
            {
                // Token: 0x04005DA0 RID: 23968
                public const int NoUpdate = 0;

                // Token: 0x04005DA1 RID: 23969
                public const int NoDraw = 1;

                // Token: 0x04005DA2 RID: 23970
                public const int Max = 2;

                // Token: 0x04005DA3 RID: 23971
                public const int None = 3;
            }
        }

        // Token: 0x02000318 RID: 792
        private class ESe
        {
            // Token: 0x04005DA4 RID: 23972
            public const int Enter = 0;

            // Token: 0x04005DA5 RID: 23973
            public const int Cancel = 1;

            // Token: 0x04005DA6 RID: 23974
            public const int Window = 2;

            // Token: 0x04005DA7 RID: 23975
            public const int Pause = 3;

            // Token: 0x04005DA8 RID: 23976
            public const int Max = 4;

            // Token: 0x04005DA9 RID: 23977
            public const int None = 5;
        }

        // Token: 0x02000319 RID: 793
        private class SLocalCreateActionTable
        {
            // Token: 0x04005DAA RID: 23978
            public int file;

            // Token: 0x04005DAB RID: 23979
            public int tex;

            // Token: 0x04005DAC RID: 23980
            public int idx;
        }
    }
}
