using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000352 RID: 850
    public class OBS_LIGHT
    {
        // Token: 0x170000B6 RID: 182
        // (get) Token: 0x060025E1 RID: 9697 RVA: 0x0014E4FD File Offset: 0x0014C6FD
        public AppMain.NNS_LIGHT_PARALLEL parallel
        {
            get
            {
                return ( AppMain.NNS_LIGHT_PARALLEL )this.light_data_;
            }
        }

        // Token: 0x170000B7 RID: 183
        // (get) Token: 0x060025E2 RID: 9698 RVA: 0x0014E50A File Offset: 0x0014C70A
        public AppMain.NNS_LIGHT_POINT point
        {
            get
            {
                return ( AppMain.NNS_LIGHT_POINT )this.light_data_;
            }
        }

        // Token: 0x170000B8 RID: 184
        // (get) Token: 0x060025E3 RID: 9699 RVA: 0x0014E517 File Offset: 0x0014C717
        public AppMain.NNS_LIGHT_TARGET_SPOT target_spot
        {
            get
            {
                return ( AppMain.NNS_LIGHT_TARGET_SPOT )this.light_data_;
            }
        }

        // Token: 0x170000B9 RID: 185
        // (get) Token: 0x060025E4 RID: 9700 RVA: 0x0014E524 File Offset: 0x0014C724
        public AppMain.NNS_LIGHT_ROTATION_SPOT rotation_spot
        {
            get
            {
                return ( AppMain.NNS_LIGHT_ROTATION_SPOT )this.light_data_;
            }
        }

        // Token: 0x170000BA RID: 186
        // (get) Token: 0x060025E5 RID: 9701 RVA: 0x0014E531 File Offset: 0x0014C731
        public AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light_param
        {
            get
            {
                return this.light_data_;
            }
        }

        // Token: 0x04005EE6 RID: 24294
        public const int ELT_LIGHT_PARALLEL = 0;

        // Token: 0x04005EE7 RID: 24295
        public const int ELT_LIGHT_POINT = 1;

        // Token: 0x04005EE8 RID: 24296
        public const int ELT_LIGHT_TARGET_SPOT = 2;

        // Token: 0x04005EE9 RID: 24297
        public const int ELT_LIGHT_ROTATION_SPOT = 3;

        // Token: 0x04005EEA RID: 24298
        public uint light_type;

        // Token: 0x04005EEB RID: 24299
        private readonly AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light_data_ = new AppMain.NNS_LIGHT_TARGET_DIRECTIONAL();
    }

    // Token: 0x02000353 RID: 851
    // (Invoke) Token: 0x060025E8 RID: 9704
    public delegate void OBJECT_Cam_Delegate( ref int fx1, ref int fx2 );
}
