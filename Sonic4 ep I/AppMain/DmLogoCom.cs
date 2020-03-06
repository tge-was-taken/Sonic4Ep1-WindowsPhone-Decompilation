using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200007A RID: 122
    public enum DME_LOGO_COM_LOAD_STATE
    {
        // Token: 0x040049AE RID: 18862
        DMD_LOGO_COM_LOAD_STATE_LOAD_WAIT,
        // Token: 0x040049AF RID: 18863
        DMD_LOGO_COM_LOAD_STATE_LOADING,
        // Token: 0x040049B0 RID: 18864
        DMD_LOGO_COM_LOAD_STATE_COMPLETE,
        // Token: 0x040049B1 RID: 18865
        DMD_LOGO_COM_LOAD_STATE_ERROR,
        // Token: 0x040049B2 RID: 18866
        DMD_LOGO_COM_LOAD_STATE_MAX
    }

    // Token: 0x0200007B RID: 123
    // (Invoke) Token: 0x06001E38 RID: 7736
    public delegate void post_func_Delegate( AppMain.DMS_LOGO_COM_LOAD_CONTEXT context );

    // Token: 0x0200007C RID: 124
    public class DMS_LOGO_COM_LOAD_FILE_INFO
    {
        // Token: 0x06001E3B RID: 7739 RVA: 0x00139800 File Offset: 0x00137A00
        public DMS_LOGO_COM_LOAD_FILE_INFO( string _file_path, AppMain.post_func_Delegate _post_func )
        {
            this.file_path = _file_path;
            this.post_func = _post_func;
        }

        // Token: 0x040049B3 RID: 18867
        public string file_path;

        // Token: 0x040049B4 RID: 18868
        public AppMain.post_func_Delegate post_func;
    }

    // Token: 0x0200007D RID: 125
    public class DMS_LOGO_COM_LOAD_CONTEXT
    {
        // Token: 0x040049B5 RID: 18869
        public AppMain.DME_LOGO_COM_LOAD_STATE state;

        // Token: 0x040049B6 RID: 18870
        public int no;

        // Token: 0x040049B7 RID: 18871
        public AppMain.DMS_LOGO_COM_LOAD_FILE_INFO file_info;

        // Token: 0x040049B8 RID: 18872
        public string file_path_buf;

        // Token: 0x040049B9 RID: 18873
        public AppMain.AMS_FS fs_req;
    }

    // Token: 0x0200007E RID: 126
    public class DMS_LOGO_COM_LOAD_WORK
    {
        // Token: 0x06001E3D RID: 7741 RVA: 0x00139820 File Offset: 0x00137A20
        public DMS_LOGO_COM_LOAD_WORK()
        {
            for ( int i = 0; i < this.context.Length; i++ )
            {
                this.context[i] = new AppMain.DMS_LOGO_COM_LOAD_CONTEXT();
            }
        }

        // Token: 0x040049BA RID: 18874
        public AppMain.Reference<AppMain.MTS_TASK_TCB> load_tcb_addr;

        // Token: 0x040049BB RID: 18875
        public int context_num;

        // Token: 0x040049BC RID: 18876
        public readonly AppMain.DMS_LOGO_COM_LOAD_CONTEXT[] context = new AppMain.DMS_LOGO_COM_LOAD_CONTEXT[10];
    }

    // Token: 0x060002B5 RID: 693 RVA: 0x00016CE4 File Offset: 0x00014EE4
    private AppMain.MTS_TASK_TCB DmLogoComLoadFileCreate( AppMain.Reference<AppMain.MTS_TASK_TCB> load_tcb_addr )
    {
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(null, new AppMain.GSF_TASK_PROCEDURE(this.dmLogoComDataLoadDest), 0U, ushort.MaxValue, 4096U, 0, () => new AppMain.DMS_LOGO_COM_LOAD_WORK(), "DM_LC_LOAD");
        AppMain.DMS_LOGO_COM_LOAD_WORK dms_LOGO_COM_LOAD_WORK = (AppMain.DMS_LOGO_COM_LOAD_WORK)mts_TASK_TCB.work;
        load_tcb_addr.Target = mts_TASK_TCB;
        dms_LOGO_COM_LOAD_WORK.load_tcb_addr = load_tcb_addr;
        return mts_TASK_TCB;
    }

    // Token: 0x060002B6 RID: 694 RVA: 0x00016D50 File Offset: 0x00014F50
    private void DmLogoComLoadFileReg( AppMain.Reference<AppMain.MTS_TASK_TCB> tcb, AppMain.DMS_LOGO_COM_LOAD_FILE_INFO[] file_info, int file_num )
    {
        AppMain.DMS_LOGO_COM_LOAD_WORK dms_LOGO_COM_LOAD_WORK = (AppMain.DMS_LOGO_COM_LOAD_WORK)tcb.Target.work;
        AppMain.ArrayPointer<AppMain.DMS_LOGO_COM_LOAD_CONTEXT> pointer = new AppMain.ArrayPointer<AppMain.DMS_LOGO_COM_LOAD_CONTEXT>(dms_LOGO_COM_LOAD_WORK.context, dms_LOGO_COM_LOAD_WORK.context_num);
        int num = 0;
        while ( num < file_num && dms_LOGO_COM_LOAD_WORK.context_num < 10 )
        {
            ( ~pointer ).no = dms_LOGO_COM_LOAD_WORK.context_num;
            ( ~pointer ).file_info = file_info[num];
            this.DmLogoComLoadFile( pointer );
            num++;
            dms_LOGO_COM_LOAD_WORK.context_num++;
            pointer = ++pointer;
        }
    }

    // Token: 0x060002B7 RID: 695 RVA: 0x00016DD8 File Offset: 0x00014FD8
    private void DmLogoComLoadFileStart( AppMain.Reference<AppMain.MTS_TASK_TCB> tcb )
    {
        AppMain.mtTaskChangeTcbProcedure( tcb.Target, new AppMain.GSF_TASK_PROCEDURE( this.dmLogoComDataLoadMain ) );
    }

    // Token: 0x060002B8 RID: 696 RVA: 0x00016DF4 File Offset: 0x00014FF4
    private AppMain.DME_LOGO_COM_LOAD_STATE DmLogoComLoadFile( AppMain.DMS_LOGO_COM_LOAD_CONTEXT context )
    {
        switch ( context.state )
        {
            case AppMain.DME_LOGO_COM_LOAD_STATE.DMD_LOGO_COM_LOAD_STATE_LOAD_WAIT:
                context.file_path_buf = context.file_info.file_path;
                context.fs_req = AppMain.amFsReadBackground( context.file_path_buf );
                if ( context.fs_req != null )
                {
                    context.state = AppMain.DME_LOGO_COM_LOAD_STATE.DMD_LOGO_COM_LOAD_STATE_LOADING;
                }
                break;
            case AppMain.DME_LOGO_COM_LOAD_STATE.DMD_LOGO_COM_LOAD_STATE_LOADING:
                if ( AppMain.amFsIsComplete( context.fs_req ) )
                {
                    if ( context.file_info.post_func != null )
                    {
                        context.file_info.post_func( context );
                    }
                    AppMain.amFsClearRequest( context.fs_req );
                    context.fs_req = null;
                    context.state = AppMain.DME_LOGO_COM_LOAD_STATE.DMD_LOGO_COM_LOAD_STATE_COMPLETE;
                }
                break;
        }
        return context.state;
    }

    // Token: 0x060002B9 RID: 697 RVA: 0x00016EA0 File Offset: 0x000150A0
    private void dmLogoComDataLoadMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOGO_COM_LOAD_WORK dms_LOGO_COM_LOAD_WORK = (AppMain.DMS_LOGO_COM_LOAD_WORK)tcb.work;
        AppMain.ArrayPointer<AppMain.DMS_LOGO_COM_LOAD_CONTEXT> pointer = dms_LOGO_COM_LOAD_WORK.context;
        int i = 0;
        while ( i < dms_LOGO_COM_LOAD_WORK.context_num )
        {
            AppMain.DME_LOGO_COM_LOAD_STATE dme_LOGO_COM_LOAD_STATE = this.DmLogoComLoadFile(pointer);
            if ( dme_LOGO_COM_LOAD_STATE != AppMain.DME_LOGO_COM_LOAD_STATE.DMD_LOGO_COM_LOAD_STATE_COMPLETE )
            {
                return;
            }
            i++;
            pointer = ++pointer;
        }
        AppMain.mtTaskClearTcb( tcb );
    }

    // Token: 0x060002BA RID: 698 RVA: 0x00016EF8 File Offset: 0x000150F8
    private void dmLogoComDataLoadDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.DMS_LOGO_COM_LOAD_WORK dms_LOGO_COM_LOAD_WORK = (AppMain.DMS_LOGO_COM_LOAD_WORK)tcb.work;
        if ( dms_LOGO_COM_LOAD_WORK.load_tcb_addr != null && dms_LOGO_COM_LOAD_WORK.load_tcb_addr.Target == tcb )
        {
            dms_LOGO_COM_LOAD_WORK.load_tcb_addr.Target = null;
        }
    }
}
