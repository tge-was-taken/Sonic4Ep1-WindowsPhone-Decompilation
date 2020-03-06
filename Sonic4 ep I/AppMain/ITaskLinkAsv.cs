using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000116 RID: 278
    public abstract class ITaskLinkAsv : AppMain.ITaskAsv
    {
        // Token: 0x06001FE3 RID: 8163 RVA: 0x0013D5B8 File Offset: 0x0013B7B8
        public void AttachTask()
        {
            this.AttachTask( "", 4096U, 0U, 2U, 0, 1U, uint.MaxValue );
        }

        // Token: 0x06001FE4 RID: 8164 RVA: 0x0013D5CF File Offset: 0x0013B7CF
        public void AttachTask( string name )
        {
            this.AttachTask( name, 4096U, 0U, 2U, 0, 1U, uint.MaxValue );
        }

        // Token: 0x06001FE5 RID: 8165 RVA: 0x0013D5E2 File Offset: 0x0013B7E2
        public void AttachTask( string name, uint priority )
        {
            this.AttachTask( name, priority, 0U, 2U, 0, 1U, uint.MaxValue );
        }

        // Token: 0x06001FE6 RID: 8166 RVA: 0x0013D5F1 File Offset: 0x0013B7F1
        public void AttachTask( string name, uint priority, uint user )
        {
            this.AttachTask( name, priority, user, 2U, 0, 1U, uint.MaxValue );
        }

        // Token: 0x06001FE7 RID: 8167 RVA: 0x0013D600 File Offset: 0x0013B800
        public void AttachTask( string name, uint priority, uint user, uint attribute )
        {
            this.AttachTask( name, priority, user, attribute, 0, 1U, uint.MaxValue );
        }

        // Token: 0x06001FE8 RID: 8168 RVA: 0x0013D610 File Offset: 0x0013B810
        public void AttachTask( string name, uint priority, uint user, uint attribute, int group )
        {
            this.AttachTask( name, priority, user, attribute, group, 1U, uint.MaxValue );
        }

        // Token: 0x06001FE9 RID: 8169 RVA: 0x0013D621 File Offset: 0x0013B821
        public void AttachTask( string name, uint priority, uint user, uint attribute, int group, uint stall_mask )
        {
            this.AttachTask( name, priority, user, attribute, group, stall_mask, uint.MaxValue );
        }

        // Token: 0x06001FEA RID: 8170 RVA: 0x0013D634 File Offset: 0x0013B834
        public void AttachTask( string name, uint priority, uint user, uint attribute, int group, uint stall_mask, uint run_mask )
        {
            this.DetachTask();
            this.m_task_tcb = AppMain.amTaskMake( new AppMain.TaskProc( AppMain.ITaskLinkAsv.procedure ), new AppMain.TaskProc( AppMain.ITaskLinkAsv.destructor ), priority, user, attribute, name, stall_mask, group, run_mask );
            this.m_task_tcb.work = new AppMain.ITaskLinkAsv.SWork();
            AppMain.ITaskLinkAsv.SWork swork = (AppMain.ITaskLinkAsv.SWork)AppMain.amTaskGetWork(this.m_task_tcb);
            swork.owner = this;
        }

        // Token: 0x06001FEB RID: 8171 RVA: 0x0013D69D File Offset: 0x0013B89D
        public void DetachTask()
        {
            if ( this.m_task_tcb != null )
            {
                AppMain.amTaskSetDestructor( this.m_task_tcb, null );
                AppMain.amTaskDelete( this.m_task_tcb );
                this.TaskDestructor( 0 );
                this.m_task_tcb = null;
            }
        }

        // Token: 0x06001FEC RID: 8172 RVA: 0x0013D6CC File Offset: 0x0013B8CC
        public static AppMain.ITaskLinkAsv CastFromTaskTcb( AppMain.AMS_TCB tcb )
        {
            if ( new AppMain.TaskProc( AppMain.ITaskLinkAsv.procedure ) == tcb.procedure || new AppMain.TaskProc( AppMain.ITaskLinkAsv.destructor ) == tcb.destructor )
            {
                AppMain.ITaskLinkAsv.SWork swork = (AppMain.ITaskLinkAsv.SWork)AppMain.amTaskGetWork(tcb);
                if ( swork.owner != null && swork.owner.m_task_tcb == tcb )
                {
                    return swork.owner;
                }
            }
            return null;
        }

        // Token: 0x06001FED RID: 8173 RVA: 0x0013D735 File Offset: 0x0013B935
        public override AppMain.AMS_TCB GetTaskTcb()
        {
            return this.m_task_tcb;
        }

        // Token: 0x06001FEE RID: 8174 RVA: 0x0013D73D File Offset: 0x0013B93D
        public bool IsTask()
        {
            return null != this.m_task_tcb;
        }

        // Token: 0x06001FEF RID: 8175 RVA: 0x0013D74B File Offset: 0x0013B94B
        protected virtual void TaskDestructor( int type )
        {
        }

        // Token: 0x06001FF0 RID: 8176 RVA: 0x0013D74D File Offset: 0x0013B94D
        private void TcbLinkDestructorCb()
        {
            this.TaskDestructor( 1 );
            this.m_task_tcb = null;
        }

        // Token: 0x06001FF1 RID: 8177 RVA: 0x0013D760 File Offset: 0x0013B960
        private static void procedure( AppMain.AMS_TCB tcb )
        {
            AppMain.ITaskLinkAsv.SWork swork = (AppMain.ITaskLinkAsv.SWork)AppMain.amTaskGetWork(tcb);
            swork.owner.operator_brackets();
        }

        // Token: 0x06001FF2 RID: 8178 RVA: 0x0013D784 File Offset: 0x0013B984
        private static void destructor( AppMain.AMS_TCB tcb )
        {
            AppMain.ITaskLinkAsv.SWork swork = (AppMain.ITaskLinkAsv.SWork)AppMain.amTaskGetWork(tcb);
            swork.owner.TcbLinkDestructorCb();
        }

        // Token: 0x04004C90 RID: 19600
        private AppMain.AMS_TCB m_task_tcb;

        // Token: 0x02000117 RID: 279
        protected class EDestructorCbType
        {
            // Token: 0x04004C91 RID: 19601
            public const int DetachTask = 0;

            // Token: 0x04004C92 RID: 19602
            public const int MtTaskClear = 1;

            // Token: 0x04004C93 RID: 19603
            public const int Max = 2;

            // Token: 0x04004C94 RID: 19604
            public const int None = 3;
        }

        // Token: 0x02000118 RID: 280
        private class SWork
        {
            // Token: 0x04004C95 RID: 19605
            public AppMain.ITaskLinkAsv owner;
        }
    }
}