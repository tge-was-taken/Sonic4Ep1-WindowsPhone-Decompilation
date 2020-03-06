using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200013C RID: 316
    public class Reference<T>
    {
        // Token: 0x06002080 RID: 8320 RVA: 0x0013EB02 File Offset: 0x0013CD02
        public Reference( T target )
        {
            this.target_ = target;
        }

        // Token: 0x17000070 RID: 112
        // (get) Token: 0x06002081 RID: 8321 RVA: 0x0013EB11 File Offset: 0x0013CD11
        // (set) Token: 0x06002082 RID: 8322 RVA: 0x0013EB19 File Offset: 0x0013CD19
        public T Target
        {
            get
            {
                return this.target_;
            }
            set
            {
                this.target_ = value;
            }
        }

        // Token: 0x04004D11 RID: 19729
        private T target_;
    }
}
