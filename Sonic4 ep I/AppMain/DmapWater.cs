using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000295 RID: 661
    public class DMAP_WATER_OBJ
    {
        // Token: 0x04005A6E RID: 23150
        public AppMain.AMS_MOTION motion;

        // Token: 0x04005A6F RID: 23151
        public AppMain.NNS_OBJECT _object;

        // Token: 0x04005A70 RID: 23152
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04005A71 RID: 23153
        public object texlistbuf;

        // Token: 0x04005A72 RID: 23154
        public float frame;
    }

    // Token: 0x02000296 RID: 662
    public class DMAP_PARAM_WATER
    {
        // Token: 0x04005A73 RID: 23155
        public float[] frame = new float[2];

        // Token: 0x04005A74 RID: 23156
        public float draw_u;

        // Token: 0x04005A75 RID: 23157
        public float draw_v;

        // Token: 0x04005A76 RID: 23158
        public float scale;

        // Token: 0x04005A77 RID: 23159
        public float pos_x;

        // Token: 0x04005A78 RID: 23160
        public float pos_y;

        // Token: 0x04005A79 RID: 23161
        public float pos_dy;

        // Token: 0x04005A7A RID: 23162
        public float repeat_u;

        // Token: 0x04005A7B RID: 23163
        public float repeat_v;

        // Token: 0x04005A7C RID: 23164
        public int rot_z;

        // Token: 0x04005A7D RID: 23165
        public uint color;
    }

    // Token: 0x02000297 RID: 663
    public class DMAP_WATER
    {
        // Token: 0x04005A7E RID: 23166
        public AppMain.AMS_AMB_HEADER amb_object;

        // Token: 0x04005A7F RID: 23167
        public AppMain.AMS_AMB_HEADER amb_texture;

        // Token: 0x04005A80 RID: 23168
        public int regist_index;

        // Token: 0x04005A81 RID: 23169
        public readonly AppMain.DMAP_WATER_OBJ[] _object = AppMain.New<AppMain.DMAP_WATER_OBJ>(2);

        // Token: 0x04005A82 RID: 23170
        public float draw_u;

        // Token: 0x04005A83 RID: 23171
        public float draw_v;

        // Token: 0x04005A84 RID: 23172
        public float scale;

        // Token: 0x04005A85 RID: 23173
        public float ofst_u;

        // Token: 0x04005A86 RID: 23174
        public float ofst_v;

        // Token: 0x04005A87 RID: 23175
        public float repeat_u;

        // Token: 0x04005A88 RID: 23176
        public float repeat_v;

        // Token: 0x04005A89 RID: 23177
        public float speed_u;

        // Token: 0x04005A8A RID: 23178
        public float speed_v;

        // Token: 0x04005A8B RID: 23179
        public float speed_surface;

        // Token: 0x04005A8C RID: 23180
        public float pos_x;

        // Token: 0x04005A8D RID: 23181
        public float pos_y;

        // Token: 0x04005A8E RID: 23182
        public float pos_dy;

        // Token: 0x04005A8F RID: 23183
        public int rot_z;

        // Token: 0x04005A90 RID: 23184
        public uint color;

        // Token: 0x04005A91 RID: 23185
        public float repeat_pos_x;

        // Token: 0x04005A92 RID: 23186
        public AppMain.DMAP_PARAM_WATER draw_param;

        // Token: 0x04005A93 RID: 23187
        public readonly AppMain.AOS_TEXTURE tex_color = new AppMain.AOS_TEXTURE();
    }
}