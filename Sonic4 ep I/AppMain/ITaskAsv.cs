using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000114 RID: 276
    public abstract class ITaskAsv
    {
        // Token: 0x06001FD5 RID: 8149
        public abstract void operator_brackets();

        // Token: 0x06001FD6 RID: 8150 RVA: 0x0013D578 File Offset: 0x0013B778
        public static implicit operator AppMain.AMS_TCB( AppMain.ITaskAsv task )
        {
            return task.GetTaskTcb();
        }

        // Token: 0x06001FD7 RID: 8151
        public abstract AppMain.AMS_TCB GetTaskTcb();

        // Token: 0x06001FD8 RID: 8152 RVA: 0x0013D580 File Offset: 0x0013B780
        public uint GetPriority()
        {
            return this.GetTaskTcb().priority;
        }

        // Token: 0x06001FD9 RID: 8153 RVA: 0x0013D58D File Offset: 0x0013B78D
        public uint GetUser()
        {
            return this.GetTaskTcb().user_id;
        }

        // Token: 0x06001FDA RID: 8154 RVA: 0x0013D59A File Offset: 0x0013B79A
        public uint GetAttribute()
        {
            return this.GetTaskTcb().attribute;
        }

        // Token: 0x06001FDB RID: 8155 RVA: 0x0013D5A7 File Offset: 0x0013B7A7
        public int GetGroup()
        {
            return 0;
        }

        // Token: 0x06001FDC RID: 8156 RVA: 0x0013D5AA File Offset: 0x0013B7AA
        public uint GetStallMask()
        {
            return 1U;
        }

        // Token: 0x06001FDD RID: 8157 RVA: 0x0013D5AD File Offset: 0x0013B7AD
        public uint GetRunMask()
        {
            return uint.MaxValue;
        }

        // Token: 0x04004C8A RID: 19594
        public const uint c_priority_default = 4096U;

        // Token: 0x04004C8B RID: 19595
        public const uint c_user_default = 0U;

        // Token: 0x04004C8C RID: 19596
        public const uint c_attribute_default = 2U;

        // Token: 0x04004C8D RID: 19597
        public const int c_group_default = 0;

        // Token: 0x04004C8E RID: 19598
        public const uint c_stall_mask_default = 1U;

        // Token: 0x04004C8F RID: 19599
        public const uint c_run_mask_default = 4294967295U;

        // Token: 0x02000115 RID: 277
        // (Invoke) Token: 0x06001FE0 RID: 8160
        public delegate void FProc();
    }
}