using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200011B RID: 283
    public class ITask
    {
        // Token: 0x06002008 RID: 8200 RVA: 0x0013D8C3 File Offset: 0x0013BAC3
        public ITask( AppMain.IFunctor pFunctor )
        {
            this.m_pFunctor = pFunctor;
        }

        // Token: 0x06002009 RID: 8201 RVA: 0x0013D8D2 File Offset: 0x0013BAD2
        public virtual void operator_brackets()
        {
            this.m_pFunctor.operator_brackets();
        }

        // Token: 0x0600200A RID: 8202 RVA: 0x0013D8DF File Offset: 0x0013BADF
        public virtual AppMain.AMS_TCB GetTaskTcb()
        {
            AppMain.mppAssertNotImpl();
            return null;
        }

        // Token: 0x0600200B RID: 8203 RVA: 0x0013D8E7 File Offset: 0x0013BAE7
        public uint GetPriority()
        {
            return this.GetTaskTcb().priority;
        }

        // Token: 0x0600200C RID: 8204 RVA: 0x0013D8F4 File Offset: 0x0013BAF4
        public uint GetUser()
        {
            return this.GetTaskTcb().user_id;
        }

        // Token: 0x0600200D RID: 8205 RVA: 0x0013D901 File Offset: 0x0013BB01
        public uint GetAttribute()
        {
            return this.GetTaskTcb().attribute;
        }

        // Token: 0x0600200E RID: 8206 RVA: 0x0013D90E File Offset: 0x0013BB0E
        public int GetGroup()
        {
            return AppMain.ITask.c_group_default;
        }

        // Token: 0x0600200F RID: 8207 RVA: 0x0013D915 File Offset: 0x0013BB15
        public uint GetStallMask()
        {
            return AppMain.ITask.c_stall_mask_default;
        }

        // Token: 0x06002010 RID: 8208 RVA: 0x0013D91C File Offset: 0x0013BB1C
        public uint GetRunMask()
        {
            return AppMain.ITask.c_run_mask_default;
        }

        // Token: 0x04004C99 RID: 19609
        private AppMain.IFunctor m_pFunctor;

        // Token: 0x04004C9A RID: 19610
        public static uint c_priority_default = 4096U;

        // Token: 0x04004C9B RID: 19611
        public static uint c_user_default = 0U;

        // Token: 0x04004C9C RID: 19612
        public static uint c_attribute_default = 2U;

        // Token: 0x04004C9D RID: 19613
        public static int c_group_default = 0;

        // Token: 0x04004C9E RID: 19614
        public static uint c_stall_mask_default = 1U;

        // Token: 0x04004C9F RID: 19615
        public static uint c_run_mask_default = uint.MaxValue;

        // Token: 0x0200011C RID: 284
        // (Invoke) Token: 0x06002013 RID: 8211
        public delegate void FProc();
    }
}