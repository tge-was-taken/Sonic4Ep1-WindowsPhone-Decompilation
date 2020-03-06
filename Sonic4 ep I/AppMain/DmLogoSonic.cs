using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001C5 RID: 453
    public class DMS_LOGO_SONIC_WORK
    {
        // Token: 0x04005025 RID: 20517
        public uint flag;

        // Token: 0x04005026 RID: 20518
        public int timer;

        // Token: 0x04005027 RID: 20519
        public AppMain.AOS_ACTION[] act = new AppMain.AOS_ACTION[2];

        // Token: 0x04005028 RID: 20520
        public AppMain.DMS_LOGO_SONIC_WORK._func_ func;

        // Token: 0x020001C6 RID: 454
        // (Invoke) Token: 0x06002237 RID: 8759
        public delegate void _func_( AppMain.DMS_LOGO_SONIC_WORK work );
    }

    // Token: 0x060009A1 RID: 2465 RVA: 0x00056AF6 File Offset: 0x00054CF6
    public void DmLogoSonicInit( object arg )
    {
        if ( this.DmLogoSonicBuildCheck() )
        {
            this.dmLogoSonicStart();
            return;
        }
        AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicLoadWait ), null, 0U, ushort.MaxValue, 4096U, 0, null, "DM_LSONT_LW" );
        this.DmLogoSonicLoad();
    }

    // Token: 0x060009A2 RID: 2466 RVA: 0x00056B32 File Offset: 0x00054D32
    public void DmLogoSonicLoad()
    {
        this.DmLogoComLoadFileCreate( AppMain.dm_logo_sonic_load_tcb );
        this.DmLogoComLoadFileReg( AppMain.dm_logo_sonic_load_tcb, AppMain.dm_logo_sonic_com_fileinfo_list, AppMain.dm_logo_sonic_com_file_num );
        this.DmLogoComLoadFileStart( AppMain.dm_logo_sonic_load_tcb );
    }

    // Token: 0x060009A3 RID: 2467 RVA: 0x00056B60 File Offset: 0x00054D60
    public bool DmLogoSonicLoadCheck()
    {
        return AppMain.dm_logo_sonic_load_tcb.Target == null && AppMain.dm_logo_sonic_data[0] != null;
    }

    // Token: 0x060009A4 RID: 2468 RVA: 0x00056B7C File Offset: 0x00054D7C
    public void DmLogoSonicBuild()
    {
        AppMain.AMS_AMB_HEADER[] array = new AppMain.AMS_AMB_HEADER[1];
        AppMain.dm_logo_sonic_build_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicDataBuildMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicDataBuildDest ), 0U, ushort.MaxValue, 4096U, 0, null, "DM_LSONT_BUILD" );
        AppMain.dm_logo_sonic_aos_tex = AppMain.New<AppMain.AOS_TEXTURE>( 1 );
        string dir;
        array[0] = AppMain.readAMBFile( AppMain.amBindGet( AppMain.dm_logo_sonic_data[0], 1, out dir ) );
        array[0].dir = dir;
        AppMain.AOS_TEXTURE[] array2 = AppMain.dm_logo_sonic_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.AoTexBuild( array2[i], array[i] );
            AppMain.AoTexLoad( array2[i] );
        }
    }

    // Token: 0x060009A5 RID: 2469 RVA: 0x00056C14 File Offset: 0x00054E14
    public bool DmLogoSonicBuildCheck()
    {
        return AppMain.dm_logo_sonic_build_state;
    }

    // Token: 0x060009A6 RID: 2470 RVA: 0x00056C20 File Offset: 0x00054E20
    public void DmLogoSonicFlush()
    {
        AppMain.dm_logo_sonic_flush_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicDataFlushMain ), new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicDataFlushDest ), 0U, ushort.MaxValue, 4096U, 0, null, "DM_LSONT_FLUSH" );
        AppMain.AOS_TEXTURE[] array = AppMain.dm_logo_sonic_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.AoTexRelease( array[i] );
        }
    }

    // Token: 0x060009A7 RID: 2471 RVA: 0x00056C7B File Offset: 0x00054E7B
    public bool DmLogoSonicFlushCheck()
    {
        return !AppMain.dm_logo_sonic_build_state;
    }

    // Token: 0x060009A8 RID: 2472 RVA: 0x00056C88 File Offset: 0x00054E88
    public void DmLogoSonicRelease()
    {
        for ( int i = 0; i < 1; i++ )
        {
            AppMain.dm_logo_sonic_data[i] = null;
        }
    }

    // Token: 0x060009A9 RID: 2473 RVA: 0x00056CA9 File Offset: 0x00054EA9
    public bool DmLogoSonicReleaseCheck()
    {
        return AppMain.dm_logo_sonic_load_tcb.Target == null && AppMain.dm_logo_sonic_data[0] == null;
    }

    // Token: 0x060009AA RID: 2474 RVA: 0x00056CC3 File Offset: 0x00054EC3
    public void dmLogoSonicLoadWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( this.DmLogoSonicLoadCheck() )
        {
            this.DmLogoSonicBuild();
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicBuildWait ) );
        }
    }

    // Token: 0x060009AB RID: 2475 RVA: 0x00056CE5 File Offset: 0x00054EE5
    public void dmLogoSonicBuildWait( AppMain.MTS_TASK_TCB tcb )
    {
        if ( this.DmLogoSonicBuildCheck() )
        {
            AppMain.mtTaskClearTcb( tcb );
            this.dmLogoSonicStart();
        }
    }

    // Token: 0x060009AC RID: 2476 RVA: 0x00056CFC File Offset: 0x00054EFC
    public void dmLogoSonicActionCreate( AppMain.DMS_LOGO_SONIC_WORK logo_work )
    {
        AppMain.A2S_AMA_HEADER ama = AppMain.readAMAFile(AppMain.amBindGet(AppMain.dm_logo_sonic_data[0], 0));
        for ( uint num = 0U; num < 2U; num += 1U )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_logo_sonic_aos_tex[( int )AppMain.dm_logo_sonic_tex_id_tbl[( int )( ( UIntPtr )num )]] ) );
            logo_work.act[( int )( ( UIntPtr )num )] = AppMain.AoActCreate( ama, num );
        }
    }

    // Token: 0x060009AD RID: 2477 RVA: 0x00056D50 File Offset: 0x00054F50
    public void dmLogoSonicActionDelete( AppMain.DMS_LOGO_SONIC_WORK logo_work )
    {
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoActDelete( logo_work.act[i] );
        }
    }

    // Token: 0x060009AE RID: 2478 RVA: 0x00056D80 File Offset: 0x00054F80
    public void dmLogoSonicStart()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_RGB nns_RGB = new AppMain.NNS_RGB(1f, 1f, 1f);
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(this.dmLogoSonicMainFunc), null, 0U, 0, 4096U, 0, () => new AppMain.DMS_LOGO_SONIC_WORK(), "DM_LSONT_MAIN");
        AppMain.DMS_LOGO_SONIC_WORK dms_LOGO_SONIC_WORK = (AppMain.DMS_LOGO_SONIC_WORK)mts_TASK_TCB.work;
        AppMain.nnSetPrimitive3DMaterial( ref nns_RGBA, ref nns_RGB, 1f );
        AppMain.AoActSysSetDrawStateEnable( false );
        this.dmLogoSonicActionCreate( dms_LOGO_SONIC_WORK );
        AppMain.IzFadeInitEasy( 0U, 2U, 60f, true );
        dms_LOGO_SONIC_WORK.func = new AppMain.DMS_LOGO_SONIC_WORK._func_( this.dmLogoSonicFadeInWaitFunc );
    }

    // Token: 0x060009AF RID: 2479 RVA: 0x00056E48 File Offset: 0x00055048
    public void dmLogoSonicMainFunc( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOGO_SONIC_WORK dms_LOGO_SONIC_WORK = (AppMain.DMS_LOGO_SONIC_WORK)tcb.work;
        if ( AppMain.AoSysIsShowPlatformUI() )
        {
            if ( AppMain.IzFadeIsExe() )
            {
                AppMain.IzFadeSetStopUpdate1Frame( null );
            }
        }
        else
        {
            if ( dms_LOGO_SONIC_WORK.func != null )
            {
                dms_LOGO_SONIC_WORK.func( dms_LOGO_SONIC_WORK );
            }
            if ( ( dms_LOGO_SONIC_WORK.flag & 1U ) != 0U && ( dms_LOGO_SONIC_WORK.flag & 2U ) == 0U && ( AppMain.amTpIsTouchPush( 0 ) || AppMain.isBackKeyPressed() ) )
            {
                AppMain.setBackKeyRequest( false );
                dms_LOGO_SONIC_WORK.flag |= 2U;
                if ( AppMain.IzFadeIsEnd() )
                {
                    AppMain.IzFadeInitEasy( 0U, 3U, 10f, true );
                }
                dms_LOGO_SONIC_WORK.func = new AppMain.DMS_LOGO_SONIC_WORK._func_( this.dmLogoSonicFadeOutWaitFunc );
            }
            if ( ( dms_LOGO_SONIC_WORK.flag & 4U ) != 0U )
            {
                AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicPreEndWait ) );
                dms_LOGO_SONIC_WORK.timer = 0;
                return;
            }
        }
        float frame = 0f;
        if ( !AppMain.AoSysIsShowPlatformUI() )
        {
            frame = 1f;
        }
        AppMain.AoActSysSetDrawTaskPrio();
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.AoActSetTexture( AppMain.AoTexGetTexList( AppMain.dm_logo_sonic_aos_tex[( int )AppMain.dm_logo_sonic_tex_id_tbl[i]] ) );
            AppMain.AoActUpdate( dms_LOGO_SONIC_WORK.act[i], frame );
            AppMain.AoActDraw( dms_LOGO_SONIC_WORK.act[i] );
        }
    }

    // Token: 0x060009B0 RID: 2480 RVA: 0x00056F68 File Offset: 0x00055168
    public void dmLogoSonicFadeInWaitFunc( AppMain.DMS_LOGO_SONIC_WORK logo_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            logo_work.func = new AppMain.DMS_LOGO_SONIC_WORK._func_( this.dmLogoSonicDispWaitFunc );
            logo_work.timer = 0;
        }
    }

    // Token: 0x060009B1 RID: 2481 RVA: 0x00056F8C File Offset: 0x0005518C
    public void dmLogoSonicDispWaitFunc( AppMain.DMS_LOGO_SONIC_WORK logo_work )
    {
        logo_work.timer++;
        if ( logo_work.timer >= 120 )
        {
            logo_work.func = new AppMain.DMS_LOGO_SONIC_WORK._func_( this.dmLogoSonicFadeOutWaitFunc );
            AppMain.IzFadeInitEasy( 0U, 3U, 60f, true );
            logo_work.flag &= 4294967294U;
            return;
        }
        if ( logo_work.timer == 30 )
        {
            logo_work.flag |= 1U;
        }
    }

    // Token: 0x060009B2 RID: 2482 RVA: 0x00056FF8 File Offset: 0x000551F8
    public void dmLogoSonicFadeOutWaitFunc( AppMain.DMS_LOGO_SONIC_WORK logo_work )
    {
        if ( AppMain.IzFadeIsEnd() )
        {
            logo_work.flag |= 4U;
        }
    }

    // Token: 0x060009B3 RID: 2483 RVA: 0x00057010 File Offset: 0x00055210
    public void dmLogoSonicPreEndWait( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOGO_SONIC_WORK dms_LOGO_SONIC_WORK = (AppMain.DMS_LOGO_SONIC_WORK)tcb.work;
        dms_LOGO_SONIC_WORK.timer++;
        if ( dms_LOGO_SONIC_WORK.timer > 2 )
        {
            this.dmLogoSonicActionDelete( dms_LOGO_SONIC_WORK );
            this.DmLogoSonicFlush();
            AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicFlushWaitFunc ) );
        }
    }

    // Token: 0x060009B4 RID: 2484 RVA: 0x0005705F File Offset: 0x0005525F
    public void dmLogoSonicFlushWaitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !this.DmLogoSonicFlushCheck() )
        {
            return;
        }
        this.DmLogoSonicRelease();
        AppMain.mtTaskChangeTcbProcedure( tcb, new AppMain.GSF_TASK_PROCEDURE( this.dmLogoSonicRelesehWaitFunc ) );
    }

    // Token: 0x060009B5 RID: 2485 RVA: 0x00057082 File Offset: 0x00055282
    public void dmLogoSonicRelesehWaitFunc( AppMain.MTS_TASK_TCB tcb )
    {
        if ( !this.DmLogoSonicReleaseCheck() )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
        AppMain.SyChangeNextEvt();
    }

    // Token: 0x060009B6 RID: 2486 RVA: 0x00057098 File Offset: 0x00055298
    public static void dmLogoSonicLoadPostFunc( AppMain.DMS_LOGO_COM_LOAD_CONTEXT context )
    {
        AppMain.dm_logo_sonic_data[context.no] = AppMain.readAMBFile( context.fs_req );
    }

    // Token: 0x060009B7 RID: 2487 RVA: 0x000570B4 File Offset: 0x000552B4
    public void dmLogoSonicDataBuildMain( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        AppMain.AOS_TEXTURE[] array = AppMain.dm_logo_sonic_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            if ( !AppMain.AoTexIsLoaded( array[i] ) )
            {
                flag = false;
            }
        }
        if ( !flag )
        {
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
        AppMain.dm_logo_sonic_build_state = true;
    }

    // Token: 0x060009B8 RID: 2488 RVA: 0x000570F1 File Offset: 0x000552F1
    public void dmLogoSonicDataBuildDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_logo_sonic_build_tcb = null;
    }

    // Token: 0x060009B9 RID: 2489 RVA: 0x000570FC File Offset: 0x000552FC
    public void dmLogoSonicDataFlushMain( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        AppMain.AOS_TEXTURE[] array = AppMain.dm_logo_sonic_aos_tex;
        for ( int i = 0; i < 1; i++ )
        {
            if ( !AppMain.AoTexIsReleased( array[i] ) )
            {
                flag = false;
            }
        }
        if ( !flag )
        {
            return;
        }
        AppMain.dm_logo_sonic_aos_tex = null;
        AppMain.mtTaskClearTcb( tcb );
        AppMain.dm_logo_sonic_build_state = false;
    }

    // Token: 0x060009BA RID: 2490 RVA: 0x0005713F File Offset: 0x0005533F
    public void dmLogoSonicDataFlushDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.dm_logo_sonic_flush_tcb = null;
    }
}
