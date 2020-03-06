using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000278 RID: 632
    public enum AME_AME_NODE_TYPE : ushort
    {
        // Token: 0x040059A2 RID: 22946
        AME_AME_SUPER_CLASS_ID_MASK = 65280,
        // Token: 0x040059A3 RID: 22947
        AME_AME_CLASS_ID_MASK = 255,
        // Token: 0x040059A4 RID: 22948
        AME_AME_NODE_TYPE_OMNI,
        // Token: 0x040059A5 RID: 22949
        AME_AME_NODE_TYPE_DIRECTIONAL,
        // Token: 0x040059A6 RID: 22950
        AME_AME_NODE_TYPE_SURFACE,
        // Token: 0x040059A7 RID: 22951
        AME_AME_NODE_TYPE_CIRCLE,
        // Token: 0x040059A8 RID: 22952
        AME_AME_NODE_TYPE_SIMPLE_SPRITE = 512,
        // Token: 0x040059A9 RID: 22953
        AME_AME_NODE_TYPE_SPRITE,
        // Token: 0x040059AA RID: 22954
        AME_AME_NODE_TYPE_LINE,
        // Token: 0x040059AB RID: 22955
        AME_AME_NODE_TYPE_PLANE,
        // Token: 0x040059AC RID: 22956
        AME_AME_NODE_TYPE_MODEL,
        // Token: 0x040059AD RID: 22957
        AME_AME_NODE_TYPE_GRAVITY = 768,
        // Token: 0x040059AE RID: 22958
        AME_AME_NODE_TYPE_UNIFORM,
        // Token: 0x040059AF RID: 22959
        AME_AME_NODE_TYPE_RADIAL,
        // Token: 0x040059B0 RID: 22960
        AME_AME_NODE_TYPE_VORTEX,
        // Token: 0x040059B1 RID: 22961
        AME_AME_NODE_TYPE_DRAG,
        // Token: 0x040059B2 RID: 22962
        AME_AME_NODE_TYPE_NOISE,
        // Token: 0x040059B3 RID: 22963
        AME_AME_NODE_TYPE_USER_EMITTER = 264,
        // Token: 0x040059B4 RID: 22964
        AME_AME_NODE_TYPE_USER_PARTICLE = 520,
        // Token: 0x040059B5 RID: 22965
        AME_AME_NODE_TYPE_USER_FIELD = 776,
        // Token: 0x040059B6 RID: 22966
        AME_AME_NODE_TYPE_EMITTER = 256,
        // Token: 0x040059B7 RID: 22967
        AME_AME_NODE_TYPE_PARTICLE = 512,
        // Token: 0x040059B8 RID: 22968
        AME_AME_NODE_TYPE_FIELD = 768
    }

    // Token: 0x02000279 RID: 633
    public enum AME_AME_BLEND_MODE
    {
        // Token: 0x040059BA RID: 22970
        AME_AME_ALPHA_NORMAL,
        // Token: 0x040059BB RID: 22971
        AME_AME_ALPHA_ADD,
        // Token: 0x040059BC RID: 22972
        AME_AME_ALPHA_SUB,
        // Token: 0x040059BD RID: 22973
        AME_AME_ALPHA_SUB1
    }

    // Token: 0x0200027A RID: 634
    public class AMS_AME_BOUNDING
    {
        // Token: 0x06002420 RID: 9248 RVA: 0x0014A417 File Offset: 0x00148617
        public AppMain.AMS_AME_BOUNDING Assign( AppMain.AMS_AME_BOUNDING bound )
        {
            this.center.Assign( bound.center );
            this.radius = bound.radius;
            this.radius2 = bound.radius2;
            return this;
        }

        // Token: 0x06002421 RID: 9249 RVA: 0x0014A443 File Offset: 0x00148643
        public void Clear()
        {
            this.center.Clear();
            this.radius = 0f;
            this.radius2 = 0f;
        }

        // Token: 0x040059BE RID: 22974
        public readonly AppMain.NNS_VECTOR4D center = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x040059BF RID: 22975
        public float radius;

        // Token: 0x040059C0 RID: 22976
        public float radius2;
    }

    // Token: 0x0200027B RID: 635
    public class AMS_AME_NODE
    {
        // Token: 0x040059C1 RID: 22977
        public short id;

        // Token: 0x040059C2 RID: 22978
        public short type;

        // Token: 0x040059C3 RID: 22979
        public uint flag;

        // Token: 0x040059C4 RID: 22980
        public readonly char[] name = new char[12];

        // Token: 0x040059C5 RID: 22981
        public int child_offset;

        // Token: 0x040059C6 RID: 22982
        public AppMain.AMS_AME_NODE child;

        // Token: 0x040059C7 RID: 22983
        public int sibling_offset;

        // Token: 0x040059C8 RID: 22984
        public AppMain.AMS_AME_NODE sibling;

        // Token: 0x040059C9 RID: 22985
        public int parent_offset;

        // Token: 0x040059CA RID: 22986
        public AppMain.AMS_AME_NODE parent;
    }

    // Token: 0x0200027C RID: 636
    public class AMS_AME_NODE_TR_ROT : AppMain.AMS_AME_NODE
    {
        // Token: 0x040059CB RID: 22987
        public readonly AppMain.NNS_VECTOR4D translate = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x040059CC RID: 22988
        public AppMain.NNS_QUATERNION rotate;
    }

    // Token: 0x0200027D RID: 637
    public struct AMS_AME_TEX_ANIM_KEY
    {
        // Token: 0x040059CD RID: 22989
        public float time;

        // Token: 0x040059CE RID: 22990
        public float l;

        // Token: 0x040059CF RID: 22991
        public float t;

        // Token: 0x040059D0 RID: 22992
        public float r;

        // Token: 0x040059D1 RID: 22993
        public float b;
    }

    // Token: 0x0200027E RID: 638
    public class AMS_AME_TEX_ANIM
    {
        // Token: 0x040059D2 RID: 22994
        public float time;

        // Token: 0x040059D3 RID: 22995
        public int key_num;

        // Token: 0x040059D4 RID: 22996
        public AppMain.AMS_AME_TEX_ANIM_KEY[] key_buf;
    }

    // Token: 0x0200027F RID: 639
    public class AMS_AME_NODE_OMNI : AppMain.AMS_AME_NODE_TR_ROT
    {
        // Token: 0x040059D5 RID: 22997
        public float inheritance_rate;

        // Token: 0x040059D6 RID: 22998
        public float life;

        // Token: 0x040059D7 RID: 22999
        public float start_time;

        // Token: 0x040059D8 RID: 23000
        public float offset;

        // Token: 0x040059D9 RID: 23001
        public float offset_chaos;

        // Token: 0x040059DA RID: 23002
        public float speed;

        // Token: 0x040059DB RID: 23003
        public float speed_chaos;

        // Token: 0x040059DC RID: 23004
        public float max_count;

        // Token: 0x040059DD RID: 23005
        public float frequency;
    }

    // Token: 0x02000280 RID: 640
    public class AMS_AME_NODE_DIRECTIONAL : AppMain.AMS_AME_NODE_OMNI
    {
        // Token: 0x040059DE RID: 23006
        public float spread;

        // Token: 0x040059DF RID: 23007
        public float spread_variation;
    }

    // Token: 0x02000281 RID: 641
    public class AMS_AME_NODE_SURFACE : AppMain.AMS_AME_NODE_OMNI
    {
        // Token: 0x040059E0 RID: 23008
        public float width;

        // Token: 0x040059E1 RID: 23009
        public float width_variation;

        // Token: 0x040059E2 RID: 23010
        public float height;

        // Token: 0x040059E3 RID: 23011
        public float height_variation;
    }

    // Token: 0x02000282 RID: 642
    public class AMS_AME_NODE_CIRCLE : AppMain.AMS_AME_NODE_OMNI
    {
        // Token: 0x040059E4 RID: 23012
        public float spread;

        // Token: 0x040059E5 RID: 23013
        public float spread_variation;

        // Token: 0x040059E6 RID: 23014
        public float radius;

        // Token: 0x040059E7 RID: 23015
        public float radius_variation;
    }

    // Token: 0x02000283 RID: 643
    public class AMS_AME_NODE_SPRITE : AppMain.AMS_AME_NODE_TR_ROT
    {
        // Token: 0x040059E8 RID: 23016
        public float z_bias;

        // Token: 0x040059E9 RID: 23017
        public float inheritance_rate;

        // Token: 0x040059EA RID: 23018
        public float life;

        // Token: 0x040059EB RID: 23019
        public float start_time;

        // Token: 0x040059EC RID: 23020
        public float size;

        // Token: 0x040059ED RID: 23021
        public float size_chaos;

        // Token: 0x040059EE RID: 23022
        public float scale_x_start;

        // Token: 0x040059EF RID: 23023
        public float scale_x_end;

        // Token: 0x040059F0 RID: 23024
        public float scale_y_start;

        // Token: 0x040059F1 RID: 23025
        public float scale_y_end;

        // Token: 0x040059F2 RID: 23026
        public float twist_angle;

        // Token: 0x040059F3 RID: 23027
        public float twist_angle_chaos;

        // Token: 0x040059F4 RID: 23028
        public float twist_angle_speed;

        // Token: 0x040059F5 RID: 23029
        public AppMain.AMS_RGBA8888 color_start;

        // Token: 0x040059F6 RID: 23030
        public AppMain.AMS_RGBA8888 color_end;

        // Token: 0x040059F7 RID: 23031
        public int blend;

        // Token: 0x040059F8 RID: 23032
        public short texture_slot;

        // Token: 0x040059F9 RID: 23033
        public short texture_id;

        // Token: 0x040059FA RID: 23034
        public float cropping_l;

        // Token: 0x040059FB RID: 23035
        public float cropping_t;

        // Token: 0x040059FC RID: 23036
        public float cropping_r;

        // Token: 0x040059FD RID: 23037
        public float cropping_b;

        // Token: 0x040059FE RID: 23038
        public float scroll_u;

        // Token: 0x040059FF RID: 23039
        public float scroll_v;

        // Token: 0x04005A00 RID: 23040
        public AppMain.AMS_AME_TEX_ANIM tex_anim;
    }

    // Token: 0x02000284 RID: 644
    public class AMS_AME_NODE_LINE : AppMain.AMS_AME_NODE_TR_ROT
    {
        // Token: 0x04005A01 RID: 23041
        public float z_bias;

        // Token: 0x04005A02 RID: 23042
        public float inheritance_rate;

        // Token: 0x04005A03 RID: 23043
        public float life;

        // Token: 0x04005A04 RID: 23044
        public float start_time;

        // Token: 0x04005A05 RID: 23045
        public float length_start;

        // Token: 0x04005A06 RID: 23046
        public float length_end;

        // Token: 0x04005A07 RID: 23047
        public float inside_width_start;

        // Token: 0x04005A08 RID: 23048
        public float inside_width_end;

        // Token: 0x04005A09 RID: 23049
        public float outside_width_start;

        // Token: 0x04005A0A RID: 23050
        public float outside_width_end;

        // Token: 0x04005A0B RID: 23051
        public AppMain.AMS_RGBA8888 inside_color_start;

        // Token: 0x04005A0C RID: 23052
        public AppMain.AMS_RGBA8888 inside_color_end;

        // Token: 0x04005A0D RID: 23053
        public AppMain.AMS_RGBA8888 outside_color_start;

        // Token: 0x04005A0E RID: 23054
        public AppMain.AMS_RGBA8888 outside_color_end;

        // Token: 0x04005A0F RID: 23055
        public int blend;

        // Token: 0x04005A10 RID: 23056
        public short texture_slot;

        // Token: 0x04005A11 RID: 23057
        public short texture_id;

        // Token: 0x04005A12 RID: 23058
        public float cropping_l;

        // Token: 0x04005A13 RID: 23059
        public float cropping_t;

        // Token: 0x04005A14 RID: 23060
        public float cropping_r;

        // Token: 0x04005A15 RID: 23061
        public float cropping_b;

        // Token: 0x04005A16 RID: 23062
        public float scroll_u;

        // Token: 0x04005A17 RID: 23063
        public float scroll_v;

        // Token: 0x04005A18 RID: 23064
        public AppMain.AMS_AME_TEX_ANIM tex_anim;
    }

    // Token: 0x02000285 RID: 645
    public class AMS_AME_NODE_PLANE : AppMain.AMS_AME_NODE_TR_ROT
    {
        // Token: 0x04005A19 RID: 23065
        public readonly AppMain.NNS_VECTOR4D rotate_axis = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A1A RID: 23066
        public float z_bias;

        // Token: 0x04005A1B RID: 23067
        public float inheritance_rate;

        // Token: 0x04005A1C RID: 23068
        public float life;

        // Token: 0x04005A1D RID: 23069
        public float start_time;

        // Token: 0x04005A1E RID: 23070
        public float size;

        // Token: 0x04005A1F RID: 23071
        public float size_chaos;

        // Token: 0x04005A20 RID: 23072
        public float scale_x_start;

        // Token: 0x04005A21 RID: 23073
        public float scale_x_end;

        // Token: 0x04005A22 RID: 23074
        public float scale_y_start;

        // Token: 0x04005A23 RID: 23075
        public float scale_y_end;

        // Token: 0x04005A24 RID: 23076
        public AppMain.AMS_RGBA8888 color_start;

        // Token: 0x04005A25 RID: 23077
        public AppMain.AMS_RGBA8888 color_end;

        // Token: 0x04005A26 RID: 23078
        public int blend;

        // Token: 0x04005A27 RID: 23079
        public short texture_slot;

        // Token: 0x04005A28 RID: 23080
        public short texture_id;

        // Token: 0x04005A29 RID: 23081
        public float cropping_l;

        // Token: 0x04005A2A RID: 23082
        public float cropping_t;

        // Token: 0x04005A2B RID: 23083
        public float cropping_r;

        // Token: 0x04005A2C RID: 23084
        public float cropping_b;

        // Token: 0x04005A2D RID: 23085
        public float scroll_u;

        // Token: 0x04005A2E RID: 23086
        public float scroll_v;

        // Token: 0x04005A2F RID: 23087
        public AppMain.AMS_AME_TEX_ANIM tex_anim;
    }

    // Token: 0x02000286 RID: 646
    public class AMS_AME_NODE_MODEL : AppMain.AMS_AME_NODE_TR_ROT
    {
        // Token: 0x04005A30 RID: 23088
        public readonly AppMain.NNS_VECTOR4D rotate_axis = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A31 RID: 23089
        public readonly AppMain.NNS_VECTOR4D scale_start = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A32 RID: 23090
        public readonly AppMain.NNS_VECTOR4D scale_end = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A33 RID: 23091
        public float z_bias;

        // Token: 0x04005A34 RID: 23092
        public float inheritance_rate;

        // Token: 0x04005A35 RID: 23093
        public float life;

        // Token: 0x04005A36 RID: 23094
        public float start_time;

        // Token: 0x04005A37 RID: 23095
        public char[] model_name = new char[8];

        // Token: 0x04005A38 RID: 23096
        public int lod;

        // Token: 0x04005A39 RID: 23097
        public AppMain.AMS_RGBA8888 color_start;

        // Token: 0x04005A3A RID: 23098
        public AppMain.AMS_RGBA8888 color_end;

        // Token: 0x04005A3B RID: 23099
        public int blend;

        // Token: 0x04005A3C RID: 23100
        public float scroll_u;

        // Token: 0x04005A3D RID: 23101
        public float scroll_v;
    }

    // Token: 0x02000287 RID: 647
    public class AMS_AME_NODE_GRAVITY : AppMain.AMS_AME_NODE
    {
        // Token: 0x04005A3E RID: 23102
        public readonly AppMain.NNS_VECTOR4D direction = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A3F RID: 23103
        public float magnitude;
    }

    // Token: 0x02000288 RID: 648
    public class AMS_AME_NODE_UNIFORM : AppMain.AMS_AME_NODE
    {
        // Token: 0x04005A40 RID: 23104
        public readonly AppMain.NNS_VECTOR4D direction = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A41 RID: 23105
        public float magnitude;
    }

    // Token: 0x02000289 RID: 649
    public class AMS_AME_NODE_RADIAL : AppMain.AMS_AME_NODE
    {
        // Token: 0x04005A42 RID: 23106
        public readonly AppMain.NNS_VECTOR4D position = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A43 RID: 23107
        public float magnitude;

        // Token: 0x04005A44 RID: 23108
        public float attenuation;
    }

    // Token: 0x0200028A RID: 650
    public class AMS_AME_NODE_VORTEX : AppMain.AMS_AME_NODE
    {
        // Token: 0x04005A45 RID: 23109
        public readonly AppMain.NNS_VECTOR4D position = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A46 RID: 23110
        public readonly AppMain.NNS_VECTOR4D axis = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
    }

    // Token: 0x0200028B RID: 651
    public class AMS_AME_NODE_DRAG : AppMain.AMS_AME_NODE
    {
        // Token: 0x04005A47 RID: 23111
        public readonly AppMain.NNS_VECTOR4D position = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A48 RID: 23112
        public float magnitude;
    }

    // Token: 0x0200028C RID: 652
    public class AMS_AME_NODE_NOISE : AppMain.AMS_AME_NODE
    {
        // Token: 0x04005A49 RID: 23113
        public readonly AppMain.NNS_VECTOR4D axis = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();

        // Token: 0x04005A4A RID: 23114
        public float magnitude;
    }

    // Token: 0x0200028D RID: 653
    public class AMS_AME_HEADER
    {
        // Token: 0x04005A4B RID: 23115
        public byte[] file_id = new byte[4];

        // Token: 0x04005A4C RID: 23116
        public int file_version;

        // Token: 0x04005A4D RID: 23117
        public int node_num;

        // Token: 0x04005A4E RID: 23118
        public uint node_ofst;

        // Token: 0x04005A4F RID: 23119
        public AppMain.AMS_AME_NODE[] node;

        // Token: 0x04005A50 RID: 23120
        public readonly AppMain.AMS_AME_BOUNDING bounding = new AppMain.AMS_AME_BOUNDING();
    }

    // Token: 0x0200028E RID: 654
    public class AME_HEADER : AppMain.AMS_AME_HEADER
    {
    }
}