using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200011D RID: 285
    public class ITaskLink : AppMain.ITask
    {
        // Token: 0x06002016 RID: 8214 RVA: 0x0013D94D File Offset: 0x0013BB4D
        public void AttachTask( string name )
        {
            this.AttachTask( name, AppMain.ITask.c_priority_default, AppMain.ITask.c_user_default, AppMain.ITask.c_attribute_default, AppMain.ITask.c_group_default, AppMain.ITask.c_stall_mask_default, AppMain.ITask.c_run_mask_default );
        }

        // Token: 0x06002017 RID: 8215 RVA: 0x0013D974 File Offset: 0x0013BB74
        public void AttachTask( string name, uint priority )
        {
            this.AttachTask( name, priority, AppMain.ITask.c_user_default, AppMain.ITask.c_attribute_default, AppMain.ITask.c_group_default, AppMain.ITask.c_stall_mask_default, AppMain.ITask.c_run_mask_default );
        }

        // Token: 0x06002018 RID: 8216 RVA: 0x0013D997 File Offset: 0x0013BB97
        public void AttachTask( string name, uint priority, uint user )
        {
            this.AttachTask( name, priority, user, AppMain.ITask.c_attribute_default, AppMain.ITask.c_group_default, AppMain.ITask.c_stall_mask_default, AppMain.ITask.c_run_mask_default );
        }

        // Token: 0x06002019 RID: 8217 RVA: 0x0013D9B6 File Offset: 0x0013BBB6
        public void AttachTask( string name, uint priority, uint user, uint attribute )
        {
            this.AttachTask( name, priority, user, attribute, AppMain.ITask.c_group_default, AppMain.ITask.c_stall_mask_default, AppMain.ITask.c_run_mask_default );
        }

        // Token: 0x0600201A RID: 8218 RVA: 0x0013D9D2 File Offset: 0x0013BBD2
        public void AttachTask( string name, uint priority, uint user, uint attribute, int group )
        {
            this.AttachTask( name, priority, user, attribute, group, AppMain.ITask.c_stall_mask_default, AppMain.ITask.c_run_mask_default );
        }

        // Token: 0x0600201B RID: 8219 RVA: 0x0013D9EB File Offset: 0x0013BBEB
        public void AttachTask( string name, uint priority, uint user, uint attribute, int group, uint stall_mask )
        {
            this.AttachTask( name, priority, user, attribute, group, stall_mask, AppMain.ITask.c_run_mask_default );
        }

        // Token: 0x0600201C RID: 8220 RVA: 0x0013DA04 File Offset: 0x0013BC04
        public void AttachTask( string name, uint priority, uint user, uint attribute, int group, uint stall_mask, uint run_mask )
        {
            this.DetachTask();
            this.m_task_tcb = AppMain.amTaskMake( new AppMain.TaskProc( AppMain.ITaskLink.procedure ), new AppMain.TaskProc( AppMain.ITaskLink.destructor ), priority, user, attribute, name, stall_mask, group, run_mask );
            this.m_task_tcb.work = new AppMain.ITaskLink.SWork();
            AppMain.ITaskLink.SWork swork = (AppMain.ITaskLink.SWork)AppMain.amTaskGetWork(this.m_task_tcb);
            swork.owner = this;
        }

        // Token: 0x0600201D RID: 8221 RVA: 0x0013DA6D File Offset: 0x0013BC6D
        public void DetachTask()
        {
            if ( this.m_task_tcb != null )
            {
                AppMain.amTaskSetDestructor( this.m_task_tcb, null );
                AppMain.amTaskDelete( this.m_task_tcb );
                this.TaskDestructor( AppMain.ITaskLink.EDestructorCbType.Type.DetachTask );
                this.m_task_tcb = null;
            }
        }

        // Token: 0x0600201E RID: 8222 RVA: 0x0013DA9C File Offset: 0x0013BC9C
        public static AppMain.ITaskLink CastFromTaskTcb( AppMain.AMS_TCB tcb )
        {
            AppMain.mppAssertNotImpl();
            return null;
        }

        // Token: 0x0600201F RID: 8223 RVA: 0x0013DAA4 File Offset: 0x0013BCA4
        public override AppMain.AMS_TCB GetTaskTcb()
        {
            return this.m_task_tcb;
        }

        // Token: 0x06002020 RID: 8224 RVA: 0x0013DAAC File Offset: 0x0013BCAC
        public bool IsTask()
        {
            return this.m_task_tcb != null;
        }

        // Token: 0x06002021 RID: 8225 RVA: 0x0013DAB9 File Offset: 0x0013BCB9
        public ITaskLink( AppMain.IFunctor pFunctor ) : base( pFunctor )
        {
            this.m_task_tcb = null;
        }

        // Token: 0x06002022 RID: 8226 RVA: 0x0013DACC File Offset: 0x0013BCCC
        ~ITaskLink()
        {
            this.DetachTask();
        }

        // Token: 0x06002023 RID: 8227 RVA: 0x0013DAF8 File Offset: 0x0013BCF8
        protected virtual void TaskDestructor( AppMain.ITaskLink.EDestructorCbType.Type type )
        {
        }

        // Token: 0x06002024 RID: 8228 RVA: 0x0013DAFA File Offset: 0x0013BCFA
        private void TcbLinkDestructorCb()
        {
            AppMain.mppAssertNotImpl();
        }

        // Token: 0x06002025 RID: 8229 RVA: 0x0013DB04 File Offset: 0x0013BD04
        private static void procedure( AppMain.AMS_TCB tcb )
        {
            AppMain.ITaskLink.SWork swork = (AppMain.ITaskLink.SWork)AppMain.amTaskGetWork(tcb);
            AppMain.ITaskLink owner = swork.owner;
            owner.operator_brackets();
        }

        // Token: 0x06002026 RID: 8230 RVA: 0x0013DB2A File Offset: 0x0013BD2A
        private static void destructor( AppMain.AMS_TCB tcb )
        {
            AppMain.mppAssertNotImpl();
        }

        // Token: 0x04004CA0 RID: 19616
        private AppMain.AMS_TCB m_task_tcb;

        // Token: 0x0200011E RID: 286
        protected struct EDestructorCbType
        {
            // Token: 0x0200011F RID: 287
            public enum Type
            {
                // Token: 0x04004CA2 RID: 19618
                DetachTask,
                // Token: 0x04004CA3 RID: 19619
                MtTaskClear,
                // Token: 0x04004CA4 RID: 19620
                Max,
                // Token: 0x04004CA5 RID: 19621
                None
            }
        }

        // Token: 0x02000120 RID: 288
        private class SWork
        {
            // Token: 0x04004CA6 RID: 19622
            public AppMain.ITaskLink owner;
        }
    }
}
