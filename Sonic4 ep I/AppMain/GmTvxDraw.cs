using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000142 RID: 322
    private class GMS_TVX_DRAW_STACK : AppMain.IClearable
    {
        // Token: 0x06002092 RID: 8338 RVA: 0x0013F0EC File Offset: 0x0013D2EC
        public void Clear()
        {
            this.vtx = null;
            this.pos.Clear();
            this.scale.Clear();
            this.disp_flag = ( this.vtx_num = 0U );
            this.rotate_z = 0;
            this.coord.Clear();
            this.color = 0U;
        }

        // Token: 0x04004D2F RID: 19759
        public AppMain.AOS_TVX_VERTEX[] vtx;

        // Token: 0x04004D30 RID: 19760
        public AppMain.VecFx32 pos;

        // Token: 0x04004D31 RID: 19761
        public AppMain.VecFx32 scale;

        // Token: 0x04004D32 RID: 19762
        public uint disp_flag;

        // Token: 0x04004D33 RID: 19763
        public uint vtx_num;

        // Token: 0x04004D34 RID: 19764
        public int rotate_z;

        // Token: 0x04004D35 RID: 19765
        public AppMain.NNS_TEXCOORD coord;

        // Token: 0x04004D36 RID: 19766
        public uint color;
    }

    // Token: 0x02000143 RID: 323
    private struct GMS_TVX_EX_WORK
    {
        // Token: 0x04004D37 RID: 19767
        public int u_wrap;

        // Token: 0x04004D38 RID: 19768
        public int v_wrap;

        // Token: 0x04004D39 RID: 19769
        public AppMain.NNS_TEXCOORD coord;

        // Token: 0x04004D3A RID: 19770
        public uint color;
    }

    // Token: 0x02000144 RID: 324
    private class GMS_TVX_DRAW_WORK : AppMain.IClearable
    {
        // Token: 0x06002094 RID: 8340 RVA: 0x0013F148 File Offset: 0x0013D348
        public void Clear()
        {
            this.tex = null;
            this.tex_id = 0;
            this.all_vtx_num = ( this.stack_num = 0U );
            this.u_wrap = ( this.v_wrap = 0 );
            AppMain.ClearArray<AppMain.GMS_TVX_DRAW_STACK>( this.stack );
        }

        // Token: 0x04004D3B RID: 19771
        public AppMain.NNS_TEXLIST tex;

        // Token: 0x04004D3C RID: 19772
        public int tex_id;

        // Token: 0x04004D3D RID: 19773
        public uint all_vtx_num;

        // Token: 0x04004D3E RID: 19774
        public uint stack_num;

        // Token: 0x04004D3F RID: 19775
        public int u_wrap;

        // Token: 0x04004D40 RID: 19776
        public int v_wrap;

        // Token: 0x04004D41 RID: 19777
        public AppMain.GMS_TVX_DRAW_STACK[] stack = AppMain.New<AppMain.GMS_TVX_DRAW_STACK>(AppMain.GMD_TVX_DRAW_STACK_NUM);
    }
}