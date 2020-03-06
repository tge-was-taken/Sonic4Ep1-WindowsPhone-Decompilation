using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;

public partial class AppMain
{
    // Token: 0x02000329 RID: 809
    public enum AOE_ACT_TYPE
    {
        // Token: 0x04005E0D RID: 24077
        AOD_ACT_TYPE_ACTION,
        // Token: 0x04005E0E RID: 24078
        AOD_ACT_TYPE_NODE,
        // Token: 0x04005E0F RID: 24079
        AOD_ACT_TYPE_NUM,
        // Token: 0x04005E10 RID: 24080
        AOD_ACT_TYPE_NONE
    }

    // Token: 0x0200032A RID: 810
    public enum AOE_ACT_HIT
    {
        // Token: 0x04005E12 RID: 24082
        AOD_ACT_HIT_RECT,
        // Token: 0x04005E13 RID: 24083
        AOD_ACT_HIT_CIRCLE,
        // Token: 0x04005E14 RID: 24084
        AOD_ACT_HIT_NUM,
        // Token: 0x04005E15 RID: 24085
        AOD_ACT_HIT_NONE
    }

    // Token: 0x0200032B RID: 811
    public enum AOE_ACT_CORW
    {
        // Token: 0x04005E17 RID: 24087
        AOD_ACT_CORW_NONE,
        // Token: 0x04005E18 RID: 24088
        AOD_ACT_CORW_CENTER,
        // Token: 0x04005E19 RID: 24089
        AOD_ACT_CORW_LEFT,
        // Token: 0x04005E1A RID: 24090
        AOD_ACT_CORW_RIGHT,
        // Token: 0x04005E1B RID: 24091
        AOD_ACT_CORW_LEFT_S,
        // Token: 0x04005E1C RID: 24092
        AOD_ACT_CORW_RIGHT_S,
        // Token: 0x04005E1D RID: 24093
        AOD_ACT_CORW_NUM
    }

    // Token: 0x0200032C RID: 812
    public struct AOS_ACT_COL : AppMain.IClearable
    {
        // Token: 0x0600259A RID: 9626 RVA: 0x0014DC68 File Offset: 0x0014BE68
        public void Clear()
        {
            this.a = ( this.b = ( this.g = ( this.r = 0 ) ) );
        }

        // Token: 0x170000B5 RID: 181
        // (get) Token: 0x0600259B RID: 9627 RVA: 0x0014DC97 File Offset: 0x0014BE97
        // (set) Token: 0x0600259C RID: 9628 RVA: 0x0014DCBC File Offset: 0x0014BEBC
        public uint c
        {
            get
            {
                return ( uint )( ( int )this.r << 24 | ( int )this.g << 16 | ( int )this.b << 8 | ( int )this.a );
            }
            set
            {
                this.r = ( byte )( value >> 24 & 255U );
                this.g = ( byte )( value >> 16 & 255U );
                this.b = ( byte )( value >> 8 & 255U );
                this.a = ( byte )( value & 255U );
            }
        }

        // Token: 0x04005E1E RID: 24094
        public byte a;

        // Token: 0x04005E1F RID: 24095
        public byte b;

        // Token: 0x04005E20 RID: 24096
        public byte g;

        // Token: 0x04005E21 RID: 24097
        public byte r;
    }

    // Token: 0x0200032D RID: 813
    public struct AOS_ACT_RECT
    {
        // Token: 0x0600259D RID: 9629 RVA: 0x0014DD0B File Offset: 0x0014BF0B
        public void Assign( ref AppMain.A2S_SUB_RECT rect )
        {
            this.left = rect.left;
            this.top = rect.top;
            this.right = rect.right;
            this.bottom = rect.bottom;
        }

        // Token: 0x0600259E RID: 9630 RVA: 0x0014DD40 File Offset: 0x0014BF40
        public void Clear()
        {
            this.left = ( this.top = ( this.right = ( this.bottom = 0f ) ) );
        }

        // Token: 0x04005E22 RID: 24098
        public float left;

        // Token: 0x04005E23 RID: 24099
        public float top;

        // Token: 0x04005E24 RID: 24100
        public float right;

        // Token: 0x04005E25 RID: 24101
        public float bottom;
    }

    // Token: 0x0200032E RID: 814
    public struct AOS_ACT_CIRCLE
    {
        // Token: 0x0600259F RID: 9631 RVA: 0x0014DD73 File Offset: 0x0014BF73
        public void Assign( ref AppMain.A2S_SUB_CIRCLE c )
        {
            this.center_x = c.center_x;
            this.center_y = c.center_y;
            this.radius = c.radius;
            this.pad = c.pad;
        }

        // Token: 0x04005E26 RID: 24102
        public float center_x;

        // Token: 0x04005E27 RID: 24103
        public float center_y;

        // Token: 0x04005E28 RID: 24104
        public float radius;

        // Token: 0x04005E29 RID: 24105
        public uint pad;
    }

    // Token: 0x0200032F RID: 815
    public class AOS_ACT_HITP
    {
        // Token: 0x060025A1 RID: 9633 RVA: 0x0014DDAD File Offset: 0x0014BFAD
        public void Assign( AppMain.AOS_ACT_HITP other )
        {
            this.flag = other.flag;
            this.type = other.type;
            this.scale_x = other.scale_x;
            this.scale_y = other.scale_y;
            this.rect = other.rect;
        }

        // Token: 0x060025A2 RID: 9634 RVA: 0x0014DDEC File Offset: 0x0014BFEC
        public void Clear()
        {
            this.flag = 0U;
            this.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_RECT;
            this.scale_x = ( this.scale_y = 0f );
        }

        // Token: 0x060025A3 RID: 9635 RVA: 0x0014DE1C File Offset: 0x0014C01C
        public void GetCircle( ref AppMain.AOS_ACT_CIRCLE circle )
        {
            circle.center_x = this.rect.left;
            circle.center_y = this.rect.top;
            circle.radius = this.rect.right;
            circle.pad = ( uint )this.rect.bottom;
        }

        // Token: 0x060025A4 RID: 9636 RVA: 0x0014DE70 File Offset: 0x0014C070
        public void SetCircle( ref AppMain.A2S_SUB_CIRCLE circle )
        {
            this.rect.left = circle.center_x;
            this.rect.top = circle.center_y;
            this.rect.right = circle.radius;
            this.rect.bottom = circle.pad;
        }

        // Token: 0x060025A5 RID: 9637 RVA: 0x0014DEC4 File Offset: 0x0014C0C4
        public void SetCircle( ref AppMain.AOS_ACT_CIRCLE circle )
        {
            this.rect.left = circle.center_x;
            this.rect.top = circle.center_y;
            this.rect.right = circle.radius;
            this.rect.bottom = circle.pad;
        }

        // Token: 0x04005E2A RID: 24106
        public uint flag;

        // Token: 0x04005E2B RID: 24107
        public AppMain.AOE_ACT_HIT type;

        // Token: 0x04005E2C RID: 24108
        public float scale_x;

        // Token: 0x04005E2D RID: 24109
        public float scale_y;

        // Token: 0x04005E2E RID: 24110
        public AppMain.AOS_ACT_RECT rect;
    }

    // Token: 0x02000330 RID: 816
    public class AOS_ACT_HIT
    {
        // Token: 0x04005E2F RID: 24111
        public AppMain.AOE_ACT_HIT type;

        // Token: 0x04005E30 RID: 24112
        public float center_x;

        // Token: 0x04005E31 RID: 24113
        public float center_y;

        // Token: 0x04005E32 RID: 24114
        public float rotate;

        // Token: 0x04005E33 RID: 24115
        public float scale_x;

        // Token: 0x04005E34 RID: 24116
        public float scale_y;

        // Token: 0x04005E35 RID: 24117
        public uint[] pad;

        // Token: 0x04005E36 RID: 24118
        public AppMain.AOS_ACT_RECT rect;

        // Token: 0x04005E37 RID: 24119
        public AppMain.AOS_ACT_CIRCLE circle;
    }

    // Token: 0x02000331 RID: 817
    public class AOS_SPRITE
    {
        // Token: 0x060025A8 RID: 9640 RVA: 0x0014DF34 File Offset: 0x0014C134
        public void Assign( AppMain.AOS_SPRITE from )
        {
            this.flag = from.flag;
            this.blend = from.blend;
            this.color = from.color;
            this.fade = from.fade;
            this.center_x = from.center_x;
            this.center_y = from.center_y;
            this.prio = from.prio;
            this.offset = from.offset;
            this.rotate = from.rotate;
            this.tex_id = from.tex_id;
            this.clamp = from.clamp;
            this.uv = from.uv;
            this.texlist = from.texlist;
            this.hit.Assign( from.hit );
        }

        // Token: 0x060025A9 RID: 9641 RVA: 0x0014DFF0 File Offset: 0x0014C1F0
        public void Clear()
        {
            this.flag = 0U;
            this.blend = 0U;
            this.color.Clear();
            this.fade.Clear();
            this.center_x = 0f;
            this.center_y = 0f;
            this.prio = 0f;
            this.offset.Clear();
            this.rotate = 0f;
            this.tex_id = 0;
            this.clamp = 0U;
            this.uv.Clear();
            this.texlist = null;
            this.hit.Clear();
        }

        // Token: 0x04005E38 RID: 24120
        public uint flag;

        // Token: 0x04005E39 RID: 24121
        public uint blend;

        // Token: 0x04005E3A RID: 24122
        public AppMain.AOS_ACT_COL color;

        // Token: 0x04005E3B RID: 24123
        public AppMain.AOS_ACT_COL fade;

        // Token: 0x04005E3C RID: 24124
        public float center_x;

        // Token: 0x04005E3D RID: 24125
        public float center_y;

        // Token: 0x04005E3E RID: 24126
        public float prio;

        // Token: 0x04005E3F RID: 24127
        public AppMain.AOS_ACT_RECT offset;

        // Token: 0x04005E40 RID: 24128
        public float rotate;

        // Token: 0x04005E41 RID: 24129
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04005E42 RID: 24130
        public int tex_id;

        // Token: 0x04005E43 RID: 24131
        public uint clamp;

        // Token: 0x04005E44 RID: 24132
        public AppMain.AOS_ACT_RECT uv;

        // Token: 0x04005E45 RID: 24133
        public readonly AppMain.AOS_ACT_HITP hit = new AppMain.AOS_ACT_HITP();
    }

    // Token: 0x02000332 RID: 818
    public class AOS_ACTION
    {
        // Token: 0x060025AA RID: 9642 RVA: 0x0014E084 File Offset: 0x0014C284
        public void Clear()
        {
            this.data = 0;
            this.flag = 0U;
            this.state = 0U;
            this.type = AppMain.AOE_ACT_TYPE.AOD_ACT_TYPE_ACTION;
            this.frame = 0f;
            this.last_key.Clear();
            this.child = null;
            this.sibling = null;
            this.sprite = null;
        }

        // Token: 0x04005E46 RID: 24134
        public object data;

        // Token: 0x04005E47 RID: 24135
        public uint flag;

        // Token: 0x04005E48 RID: 24136
        public uint state;

        // Token: 0x04005E49 RID: 24137
        public AppMain.AOE_ACT_TYPE type;

        // Token: 0x04005E4A RID: 24138
        public float frame;

        // Token: 0x04005E4B RID: 24139
        public AppMain._last_key last_key;

        // Token: 0x04005E4C RID: 24140
        public AppMain.AOS_ACTION child;

        // Token: 0x04005E4D RID: 24141
        public AppMain.AOS_ACTION sibling;

        // Token: 0x04005E4E RID: 24142
        public AppMain.AOS_SPRITE sprite;
    }

    // Token: 0x02000333 RID: 819
    public struct _last_key
    {
        // Token: 0x060025AC RID: 9644 RVA: 0x0014E0E8 File Offset: 0x0014C2E8
        public void Clear()
        {
            this.trs = ( this.mtn = ( this.anm = ( this.mat = ( this.atrs = ( this.amtn = ( this.amat = ( this.usr = ( this.hit = 0 ) ) ) ) ) ) ) );
        }

        // Token: 0x04005E4F RID: 24143
        public int trs;

        // Token: 0x04005E50 RID: 24144
        public int mtn;

        // Token: 0x04005E51 RID: 24145
        public int anm;

        // Token: 0x04005E52 RID: 24146
        public int mat;

        // Token: 0x04005E53 RID: 24147
        public int atrs;

        // Token: 0x04005E54 RID: 24148
        public int amtn;

        // Token: 0x04005E55 RID: 24149
        public int amat;

        // Token: 0x04005E56 RID: 24150
        public int usr;

        // Token: 0x04005E57 RID: 24151
        public int hit;
    }

    // Token: 0x02000334 RID: 820
    public class AOS_ACT_ACM
    {
        // Token: 0x060025AD RID: 9645 RVA: 0x0014E14C File Offset: 0x0014C34C
        public void Clear()
        {
            this.trans_x = ( this.trans_y = ( this.trans_z = 0f ) );
            this.trans_scale_x = ( this.trans_scale_y = 0f );
            this.scale_x = ( this.scale_y = 0f );
            this.rotate = 0f;
            this.color.Clear();
            this.fade.Clear();
        }

        // Token: 0x060025AE RID: 9646 RVA: 0x0014E1C0 File Offset: 0x0014C3C0
        public void Assign( AppMain.AOS_ACT_ACM acm )
        {
            this.trans_x = acm.trans_x;
            this.trans_y = acm.trans_y;
            this.trans_z = acm.trans_z;
            this.color = acm.color;
            this.fade = acm.fade;
            this.trans_scale_x = acm.trans_scale_x;
            this.trans_scale_y = acm.trans_scale_y;
            this.scale_x = acm.scale_x;
            this.scale_y = acm.scale_y;
            this.rotate = acm.rotate;
        }

        // Token: 0x04005E58 RID: 24152
        public float trans_x;

        // Token: 0x04005E59 RID: 24153
        public float trans_y;

        // Token: 0x04005E5A RID: 24154
        public float trans_z;

        // Token: 0x04005E5B RID: 24155
        public AppMain.AOS_ACT_COL color;

        // Token: 0x04005E5C RID: 24156
        public AppMain.AOS_ACT_COL fade;

        // Token: 0x04005E5D RID: 24157
        public float trans_scale_x;

        // Token: 0x04005E5E RID: 24158
        public float trans_scale_y;

        // Token: 0x04005E5F RID: 24159
        public float scale_x;

        // Token: 0x04005E60 RID: 24160
        public float scale_y;

        // Token: 0x04005E61 RID: 24161
        public float rotate;
    }

    // Token: 0x02000335 RID: 821
    public struct AOS_ACT_SORT
    {
        // Token: 0x060025B0 RID: 9648 RVA: 0x0014E24D File Offset: 0x0014C44D
        public void Clear()
        {
            this.z = 0f;
            this.sprite = null;
        }

        // Token: 0x04005E62 RID: 24162
        public AppMain.AOS_SPRITE sprite;

        // Token: 0x04005E63 RID: 24163
        public float z;
    }

    // Token: 0x02000336 RID: 822
    public class AOS_ACT_DRAW
    {
        // Token: 0x04005E64 RID: 24164
        public uint count;

        // Token: 0x04005E65 RID: 24165
        public AppMain.AOS_SPRITE[] sprite;
    }

    // Token: 0x06001638 RID: 5688 RVA: 0x000C1488 File Offset: 0x000BF688
    private static void AoActSysInit( uint spr_buf_num, uint act_buf_num, uint sort_buf_num, uint acm_stack_num )
    {
        if ( AppMain.g_ao_act_master_buf != null )
        {
            return;
        }
        if ( spr_buf_num == 0U )
        {
            spr_buf_num = 1U;
        }
        if ( act_buf_num == 0U )
        {
            act_buf_num = 1U;
        }
        if ( sort_buf_num == 0U )
        {
            sort_buf_num = 1U;
        }
        if ( acm_stack_num == 0U )
        {
            acm_stack_num = 1U;
        }
        AppMain.g_ao_act_spr_buf_size = spr_buf_num;
        if ( spr_buf_num > 0U )
        {
            AppMain.g_ao_act_spr_buf = AppMain.New<AppMain.AOS_SPRITE>( ( int )spr_buf_num );
            AppMain.g_ao_act_spr_ref = new AppMain.AOS_SPRITE[spr_buf_num];
        }
        else
        {
            AppMain.g_ao_act_spr_buf = null;
            AppMain.g_ao_act_spr_ref = null;
        }
        AppMain.g_ao_act_buf_size = act_buf_num;
        if ( act_buf_num > 0U )
        {
            AppMain.g_ao_act_buf = AppMain.New<AppMain.AOS_ACTION>( ( int )act_buf_num );
            AppMain.g_ao_act_ref = new AppMain.AOS_ACTION[act_buf_num];
        }
        else
        {
            AppMain.g_ao_act_buf = null;
            AppMain.g_ao_act_ref = null;
        }
        AppMain.g_ao_act_sort_buf_size = sort_buf_num;
        if ( sort_buf_num > 0U )
        {
            AppMain.g_ao_act_sort_buf = AppMain.New<AppMain.AOS_ACT_SORT>( ( int )sort_buf_num );
        }
        else
        {
            AppMain.g_ao_act_sort_buf = null;
        }
        AppMain.g_ao_act_acm_buf_size = acm_stack_num;
        if ( acm_stack_num > 0U )
        {
            AppMain.g_ao_act_acm_buf = AppMain.New<AppMain.AOS_ACT_ACM>( ( int )acm_stack_num );
        }
        else
        {
            AppMain.g_ao_act_acm_buf = null;
        }
        AppMain.g_ao_act_acm_flag_buf_size = acm_stack_num;
        if ( acm_stack_num > 0U )
        {
            AppMain.g_ao_act_acm_flag_buf = new uint[acm_stack_num];
        }
        else
        {
            AppMain.g_ao_act_acm_flag_buf = null;
        }
        AppMain.AoActSysReset();
    }

    // Token: 0x06001639 RID: 5689 RVA: 0x000C1590 File Offset: 0x000BF790
    private static void AoActSysReset()
    {
        AppMain.g_ao_act_sys_draw_prio = 4096U;
        AppMain.g_ao_act_sys_frame_rate = 1f;
        AppMain.g_ao_act_sys_adjust_x = 0f;
        AppMain.g_ao_act_sys_adjust_y = 0f;
        if ( AppMain.g_ao_act_spr_buf_size > 0U )
        {
            for ( int i = 0; i < AppMain.g_ao_act_spr_buf.Length; i++ )
            {
                AppMain.g_ao_act_spr_buf[i].Clear();
            }
            for ( uint num = 0U; num < AppMain.g_ao_act_spr_buf_size; num += 1U )
            {
                AppMain.g_ao_act_spr_ref[( int )( ( UIntPtr )num )] = AppMain.g_ao_act_spr_buf[( int )( ( UIntPtr )num )];
            }
        }
        AppMain.g_ao_act_spr_alloc = 0U;
        AppMain.g_ao_act_spr_free = 0U;
        AppMain.g_ao_act_spr_num = 0U;
        if ( AppMain.g_ao_act_buf_size > 0U )
        {
            for ( int j = 0; j < AppMain.g_ao_act_buf.Length; j++ )
            {
                AppMain.g_ao_act_buf[j].Clear();
            }
            for ( uint num2 = 0U; num2 < AppMain.g_ao_act_buf_size; num2 += 1U )
            {
                AppMain.g_ao_act_ref[( int )( ( UIntPtr )num2 )] = AppMain.g_ao_act_buf[( int )( ( UIntPtr )num2 )];
            }
        }
        AppMain.g_ao_act_alloc = 0U;
        AppMain.g_ao_act_free = 0U;
        AppMain.g_ao_act_num = 0U;
        if ( AppMain.g_ao_act_sort_buf_size > 0U )
        {
            AppMain.ArrayPointer<AppMain.AOS_ACT_SORT> pointer = AppMain.g_ao_act_sort_buf;
            int num3 = 0;
            while ( ( long )num3 < ( long )( ( ulong )AppMain.g_ao_act_sort_buf_size ) )
            {
                ( ~pointer ).Clear();
                pointer = ++pointer;
                num3++;
            }
        }
        AppMain.g_ao_act_sort_num = 0U;
        AppMain.g_ao_act_acm_cur = AppMain.g_ao_act_acm_buf;
        AppMain.g_ao_act_acm_num = 1U;
        if ( AppMain.g_ao_act_acm_buf_size > 0U )
        {
            AppMain.ArrayPointer<AppMain.AOS_ACT_ACM> pointer2 = AppMain.g_ao_act_acm_buf;
            int num4 = 0;
            while ( ( long )num4 < ( long )( ( ulong )AppMain.g_ao_act_acm_buf_size ) )
            {
                ( ~pointer2 ).Clear();
                pointer2 = ++pointer2;
                num4++;
            }
            AppMain.AoActAcmInit();
        }
        AppMain.g_ao_act_acm_flag_cur = AppMain.g_ao_act_acm_flag_buf;
        AppMain.g_ao_act_acm_flag_num = 1U;
        if ( AppMain.g_ao_act_acm_flag_buf_size > 0U )
        {
            AppMain.ArrayPointer<uint> pointer3 = AppMain.g_ao_act_acm_flag_buf;
            int num5 = 0;
            while ( ( long )num5 < ( long )( ( ulong )AppMain.g_ao_act_acm_flag_buf_size ) )
            {
                pointer3.SetPrimitive( 0U );
                pointer3 = ++pointer3;
                num5++;
            }
            AppMain.AoActAcmSetFlag();
        }
        AppMain.AoActSysClearPeak();
        AppMain.g_ao_act_texlist = null;
    }

    // Token: 0x0600163A RID: 5690 RVA: 0x000C1760 File Offset: 0x000BF960
    private static void AoActSysExit()
    {
        if ( AppMain.g_ao_act_master_buf != null )
        {
            AppMain.g_ao_act_master_buf = null;
        }
        AppMain.g_ao_act_sys_frame_rate = 1f;
        AppMain.g_ao_act_sys_adjust_x = 0f;
        AppMain.g_ao_act_sys_adjust_y = 0f;
        AppMain.g_ao_act_master_buf = null;
        AppMain.g_ao_act_spr_buf = null;
        AppMain.g_ao_act_spr_ref = null;
        AppMain.g_ao_act_spr_alloc = 0U;
        AppMain.g_ao_act_spr_free = 0U;
        AppMain.g_ao_act_spr_buf_size = 0U;
        AppMain.g_ao_act_spr_num = 0U;
        AppMain.g_ao_act_spr_peak = 0U;
        AppMain.g_ao_act_buf = null;
        AppMain.g_ao_act_ref = null;
        AppMain.g_ao_act_alloc = 0U;
        AppMain.g_ao_act_free = 0U;
        AppMain.g_ao_act_buf_size = 0U;
        AppMain.g_ao_act_num = 0U;
        AppMain.g_ao_act_peak = 0U;
        AppMain.g_ao_act_sort_buf = null;
        AppMain.g_ao_act_sort_buf_size = 0U;
        AppMain.g_ao_act_sort_num = 0U;
        AppMain.g_ao_act_sort_peak = 0U;
        AppMain.g_ao_act_acm_buf = null;
        AppMain.g_ao_act_acm_cur = null;
        AppMain.g_ao_act_acm_buf_size = 0U;
        AppMain.g_ao_act_acm_num = 0U;
        AppMain.g_ao_act_acm_peak = 0U;
        AppMain.g_ao_act_acm_flag_buf = null;
        AppMain.g_ao_act_acm_flag_cur = null;
        AppMain.g_ao_act_acm_flag_buf_size = 0U;
        AppMain.g_ao_act_acm_flag_num = 0U;
        AppMain.g_ao_act_acm_flag_peak = 0U;
        AppMain.g_ao_act_texlist = null;
    }

    // Token: 0x0600163B RID: 5691 RVA: 0x000C1865 File Offset: 0x000BFA65
    private static uint AoActSysGetSprBufferSize()
    {
        return AppMain.g_ao_act_spr_buf_size;
    }

    // Token: 0x0600163C RID: 5692 RVA: 0x000C186C File Offset: 0x000BFA6C
    private static uint AoActSysGetSprBufferRemain()
    {
        return AppMain.g_ao_act_spr_buf_size - AppMain.g_ao_act_spr_num;
    }

    // Token: 0x0600163D RID: 5693 RVA: 0x000C1879 File Offset: 0x000BFA79
    private static uint AoActSysGetSprBufferPeak()
    {
        return AppMain.g_ao_act_spr_peak;
    }

    // Token: 0x0600163E RID: 5694 RVA: 0x000C1880 File Offset: 0x000BFA80
    private static uint AoActSysGetActBufferSize()
    {
        return AppMain.g_ao_act_buf_size;
    }

    // Token: 0x0600163F RID: 5695 RVA: 0x000C1887 File Offset: 0x000BFA87
    private static uint AoActSysGetActBufferRemain()
    {
        return AppMain.g_ao_act_buf_size - AppMain.g_ao_act_num;
    }

    // Token: 0x06001640 RID: 5696 RVA: 0x000C1894 File Offset: 0x000BFA94
    private static uint AoActSysGetActBufferPeak()
    {
        return AppMain.g_ao_act_peak;
    }

    // Token: 0x06001641 RID: 5697 RVA: 0x000C189B File Offset: 0x000BFA9B
    private static uint AoActSysGetSortBufferSize()
    {
        return AppMain.g_ao_act_sort_buf_size;
    }

    // Token: 0x06001642 RID: 5698 RVA: 0x000C18A2 File Offset: 0x000BFAA2
    private static uint AoActSysGetSortBufferRemain()
    {
        return AppMain.g_ao_act_sort_buf_size - AppMain.g_ao_act_sort_num;
    }

    // Token: 0x06001643 RID: 5699 RVA: 0x000C18AF File Offset: 0x000BFAAF
    private static uint AoActSysGetSortBufferPeak()
    {
        return AppMain.g_ao_act_sort_peak;
    }

    // Token: 0x06001644 RID: 5700 RVA: 0x000C18B6 File Offset: 0x000BFAB6
    public static uint AoActSysGetAcmStackSize()
    {
        return AppMain.g_ao_act_acm_buf_size;
    }

    // Token: 0x06001645 RID: 5701 RVA: 0x000C18BD File Offset: 0x000BFABD
    public static uint AoActSysGetAcmStackRemain()
    {
        return AppMain.g_ao_act_acm_buf_size - AppMain.g_ao_act_acm_num;
    }

    // Token: 0x06001646 RID: 5702 RVA: 0x000C18CA File Offset: 0x000BFACA
    public static uint AoActSysGetAcmBufferPeak()
    {
        return AppMain.g_ao_act_acm_peak;
    }

    // Token: 0x06001647 RID: 5703 RVA: 0x000C18D1 File Offset: 0x000BFAD1
    public static uint AoActSysGetAcmFlagStackSize()
    {
        return AppMain.g_ao_act_acm_flag_buf_size;
    }

    // Token: 0x06001648 RID: 5704 RVA: 0x000C18D8 File Offset: 0x000BFAD8
    public static uint AoActSysGetAcmFlagStackRemain()
    {
        return AppMain.g_ao_act_acm_flag_buf_size - AppMain.g_ao_act_acm_flag_num;
    }

    // Token: 0x06001649 RID: 5705 RVA: 0x000C18E5 File Offset: 0x000BFAE5
    public static uint AoActSysGetAcmFlagBufferPeak()
    {
        return AppMain.g_ao_act_acm_flag_peak;
    }

    // Token: 0x0600164A RID: 5706 RVA: 0x000C18EC File Offset: 0x000BFAEC
    public static void AoActSysClearPeak()
    {
        AppMain.g_ao_act_spr_peak = 0U;
        AppMain.g_ao_act_peak = 0U;
        AppMain.g_ao_act_sort_peak = 0U;
        AppMain.g_ao_act_acm_peak = 0U;
        AppMain.g_ao_act_acm_flag_peak = 0U;
    }

    // Token: 0x0600164B RID: 5707 RVA: 0x000C190C File Offset: 0x000BFB0C
    public static void AoActSysSetDrawTaskPrio()
    {
        AppMain.AoActSysSetDrawTaskPrio( 4096U );
    }

    // Token: 0x0600164C RID: 5708 RVA: 0x000C1918 File Offset: 0x000BFB18
    public static void AoActSysSetDrawTaskPrio( uint prio )
    {
        AppMain.g_ao_act_sys_draw_prio = prio;
    }

    // Token: 0x0600164D RID: 5709 RVA: 0x000C1920 File Offset: 0x000BFB20
    public static uint AoActSysGetDrawTaskPrio()
    {
        return AppMain.g_ao_act_sys_draw_prio;
    }

    // Token: 0x0600164E RID: 5710 RVA: 0x000C1927 File Offset: 0x000BFB27
    public static void AoActSysSetDrawStateEnable( bool enable )
    {
        AppMain.g_ao_act_sys_draw_state_enable = enable;
    }

    // Token: 0x0600164F RID: 5711 RVA: 0x000C192F File Offset: 0x000BFB2F
    public static bool AoActSysGetDrawStateEnable()
    {
        return AppMain.g_ao_act_sys_draw_state_enable;
    }

    // Token: 0x06001650 RID: 5712 RVA: 0x000C1936 File Offset: 0x000BFB36
    public static void AoActSysSetDrawState( uint state )
    {
        AppMain.g_ao_act_sys_draw_state = state;
    }

    // Token: 0x06001651 RID: 5713 RVA: 0x000C193E File Offset: 0x000BFB3E
    public static uint AoActSysGetDrawState()
    {
        return AppMain.g_ao_act_sys_draw_state;
    }

    // Token: 0x06001652 RID: 5714 RVA: 0x000C1945 File Offset: 0x000BFB45
    public static void AoActSysSetFrameRate( float rate )
    {
        AppMain.g_ao_act_sys_frame_rate = rate;
    }

    // Token: 0x06001653 RID: 5715 RVA: 0x000C194D File Offset: 0x000BFB4D
    public static float AoActSysGetFrameRate()
    {
        return AppMain.g_ao_act_sys_frame_rate;
    }

    // Token: 0x06001654 RID: 5716 RVA: 0x000C1954 File Offset: 0x000BFB54
    public static void AoActSysSetAdjust( float x, float y )
    {
        AppMain.g_ao_act_sys_adjust_x = x;
        AppMain.g_ao_act_sys_adjust_y = y;
    }

    // Token: 0x06001655 RID: 5717 RVA: 0x000C1962 File Offset: 0x000BFB62
    public static void AoActSysAddAdjust( float x, float y )
    {
        AppMain.g_ao_act_sys_adjust_x += x;
        AppMain.g_ao_act_sys_adjust_y += y;
    }

    // Token: 0x06001656 RID: 5718 RVA: 0x000C197C File Offset: 0x000BFB7C
    public static float AoActSysGetAdjustX()
    {
        return AppMain.g_ao_act_sys_adjust_x;
    }

    // Token: 0x06001657 RID: 5719 RVA: 0x000C1983 File Offset: 0x000BFB83
    public static float AoActSysGetAdjustY()
    {
        return AppMain.g_ao_act_sys_adjust_y;
    }

    // Token: 0x06001658 RID: 5720 RVA: 0x000C198A File Offset: 0x000BFB8A
    public static void AoActSetTexture( AppMain.NNS_TEXLIST texlist )
    {
        AppMain.g_ao_act_texlist = texlist;
    }

    // Token: 0x06001659 RID: 5721 RVA: 0x000C1992 File Offset: 0x000BFB92
    public static AppMain.NNS_TEXLIST AoActGetTexture()
    {
        return AppMain.g_ao_act_texlist;
    }

    // Token: 0x0600165A RID: 5722 RVA: 0x000C199C File Offset: 0x000BFB9C
    public static AppMain.AOS_SPRITE AoActSprCreate( AppMain.A2S_AMA_HEADER ama, uint id, float frame )
    {
        AppMain.AOS_SPRITE aos_SPRITE = AppMain.aoActAllocSprite();
        if ( aos_SPRITE == null )
        {
            return null;
        }
        AppMain.AoActSprApply( aos_SPRITE, ama, id, frame );
        return aos_SPRITE;
    }

    // Token: 0x0600165B RID: 5723 RVA: 0x000C19BE File Offset: 0x000BFBBE
    public static void AoActSprDelete( AppMain.AOS_SPRITE spr )
    {
        AppMain.aoActFreeSprite( spr );
    }

    // Token: 0x0600165C RID: 5724 RVA: 0x000C19C8 File Offset: 0x000BFBC8
    public static void AoActSprApply( AppMain.AOS_SPRITE spr, AppMain.A2S_AMA_HEADER ama, uint id, float frame )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = ama.act_tbl[(int)((UIntPtr)id)];
        while ( a2S_AMA_ACT.next != null && a2S_AMA_ACT.frm_num <= frame )
        {
            frame -= a2S_AMA_ACT.frm_num;
            a2S_AMA_ACT = a2S_AMA_ACT.next;
        }
        float frame2 = frame;
        int key = -1;
        AppMain.aoActSearchTrsKey( a2S_AMA_ACT, ref frame2, ref key );
        float frame3 = frame;
        int key2 = -1;
        AppMain.aoActSearchMtnKey( a2S_AMA_ACT, ref frame3, ref key2 );
        float frame4 = frame;
        int key3 = -1;
        AppMain.aoActSearchAnmKey( a2S_AMA_ACT, ref frame4, ref key3 );
        float frame5 = frame;
        int key4 = -1;
        AppMain.aoActSearchMatKey( a2S_AMA_ACT, ref frame5, ref key4 );
        float frame6 = frame;
        int key5 = -1;
        AppMain.aoActSearchHitKey( a2S_AMA_ACT, ref frame6, ref key5 );
        spr.flag = a2S_AMA_ACT.flag;
        spr.offset.left = a2S_AMA_ACT.ofst.left;
        spr.offset.right = a2S_AMA_ACT.ofst.right;
        spr.offset.top = a2S_AMA_ACT.ofst.top;
        spr.offset.bottom = a2S_AMA_ACT.ofst.bottom;
        float num = 0f;
        float num2 = 0f;
        if ( a2S_AMA_ACT.mtn == null )
        {
            spr.center_x = 0f;
            spr.center_y = 0f;
            spr.prio = 0f;
            spr.rotate = 0f;
        }
        else
        {
            AppMain.aoActMakeTrs( a2S_AMA_ACT.mtn.trs_key_num, a2S_AMA_ACT.mtn.trs_frm_num, a2S_AMA_ACT.mtn.trs_key_tbl, a2S_AMA_ACT.mtn.trs_tbl, key, frame2, ref spr.center_x, ref spr.center_y, ref spr.prio );
            AppMain.aoActMakeMtn( a2S_AMA_ACT.mtn.mtn_key_num, a2S_AMA_ACT.mtn.mtn_frm_num, a2S_AMA_ACT.mtn.mtn_key_tbl, a2S_AMA_ACT.mtn.mtn_tbl, key2, frame3, out num, out num2, out spr.rotate );
            spr.offset.left = spr.offset.left * num;
            spr.offset.right = spr.offset.right * num;
            spr.offset.top = spr.offset.top * num2;
            spr.offset.bottom = spr.offset.bottom * num2;
        }
        if ( a2S_AMA_ACT.anm == null )
        {
            spr.tex_id = -1;
            spr.color.r = byte.MaxValue;
            spr.color.g = byte.MaxValue;
            spr.color.b = byte.MaxValue;
            spr.color.a = byte.MaxValue;
            spr.fade.r = 0;
            spr.fade.g = 0;
            spr.fade.b = 0;
            spr.fade.a = 0;
        }
        else
        {
            AppMain.aoActMakeAnm( a2S_AMA_ACT.anm.anm_key_num, a2S_AMA_ACT.anm.anm_frm_num, a2S_AMA_ACT.anm.anm_key_tbl, a2S_AMA_ACT.anm.anm_tbl, key3, frame4, ref spr.tex_id, ref spr.uv, ref spr.clamp );
            AppMain.aoActMakeMat( a2S_AMA_ACT.anm.mat_key_num, a2S_AMA_ACT.anm.mat_frm_num, a2S_AMA_ACT.anm.mat_key_tbl, a2S_AMA_ACT.anm.mat_tbl, key4, frame5, ref spr.color, ref spr.fade, out spr.blend );
        }
        if ( a2S_AMA_ACT.hit == null )
        {
            spr.hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
        }
        else
        {
            AppMain.aoActMakeHit( a2S_AMA_ACT.hit.hit_key_num, a2S_AMA_ACT.hit.hit_frm_num, a2S_AMA_ACT.hit.hit_key_tbl, a2S_AMA_ACT.hit.hit_tbl, key5, frame6, spr.hit );
            spr.hit.scale_x = num;
            spr.hit.scale_y = num2;
        }
        AppMain.aoActAcmSprite( spr );
    }

    // Token: 0x0600165D RID: 5725 RVA: 0x000C1D5C File Offset: 0x000BFF5C
    public static void AoActSprDraw( AppMain.AOS_SPRITE spr )
    {
        if ( AppMain.g_ao_act_sys_draw_state_enable )
        {
            AppMain.aoActDrawSprState( spr );
            return;
        }
        AppMain.AOS_ACT_DRAW aos_ACT_DRAW = new AppMain.AOS_ACT_DRAW();
        aos_ACT_DRAW.count = 1U;
        aos_ACT_DRAW.sprite = new AppMain.AOS_SPRITE[1];
        aos_ACT_DRAW.sprite[0].Assign( spr );
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain.aoActDrawTask ), ( ushort )AppMain.g_ao_act_sys_draw_prio, aos_ACT_DRAW );
    }

    // Token: 0x0600165E RID: 5726 RVA: 0x000C1DB6 File Offset: 0x000BFFB6
    public static AppMain.AOS_ACTION AoActCreate( AppMain.A2S_AMA_HEADER ama, uint id )
    {
        return AppMain.AoActCreate( ama, id, 0f );
    }

    // Token: 0x0600165F RID: 5727 RVA: 0x000C1DC4 File Offset: 0x000BFFC4
    public static AppMain.AOS_ACTION AoActCreate( AppMain.A2S_AMA_HEADER ama, uint id, float frame )
    {
        if ( id >= ama.act_num )
        {
            return null;
        }
        AppMain.A2S_AMA_ACT data = ama.act_tbl[(int)((UIntPtr)id)];
        AppMain.AOS_ACTION aos_ACTION = AppMain.aoActAllocAction();
        if ( aos_ACTION == null )
        {
            return null;
        }
        AppMain.AoActAcmPush();
        AppMain.AoActAcmFlagPush( 0U, uint.MaxValue );
        aos_ACTION.data = data;
        aos_ACTION.flag = 0U;
        aos_ACTION.state = 0U;
        aos_ACTION.type = AppMain.AOE_ACT_TYPE.AOD_ACT_TYPE_ACTION;
        aos_ACTION.frame = frame;
        aos_ACTION.last_key.trs = -1;
        aos_ACTION.last_key.mtn = -1;
        aos_ACTION.last_key.anm = -1;
        aos_ACTION.last_key.mat = -1;
        aos_ACTION.last_key.atrs = -1;
        aos_ACTION.last_key.amtn = -1;
        aos_ACTION.last_key.amat = -1;
        aos_ACTION.last_key.usr = -1;
        aos_ACTION.last_key.hit = -1;
        aos_ACTION.child = null;
        aos_ACTION.sibling = null;
        aos_ACTION.sprite = AppMain.AoActSprCreate( ama, id, frame );
        if ( aos_ACTION.sprite == null )
        {
            AppMain.AoActDelete( aos_ACTION );
            AppMain.AoActAcmFlagPop();
            AppMain.AoActAcmPop();
            return null;
        }
        AppMain.AoActAcmFlagPop();
        AppMain.AoActAcmPop();
        return aos_ACTION;
    }

    // Token: 0x06001660 RID: 5728 RVA: 0x000C1ED1 File Offset: 0x000C00D1
    public static AppMain.AOS_ACTION AoActCreateNode( AppMain.A2S_AMA_HEADER ama, uint id, float frame )
    {
        return AppMain.AoActCreateNodeSub( ama, id, frame, false );
    }

    // Token: 0x06001661 RID: 5729 RVA: 0x000C1EDC File Offset: 0x000C00DC
    public static AppMain.AOS_ACTION AoActCreateNodeSub( AppMain.A2S_AMA_HEADER ama, uint id, float frame, bool sib )
    {
        if ( id >= ama.node_num )
        {
            return null;
        }
        AppMain.A2S_AMA_NODE a2S_AMA_NODE = ama.node_tbl[(int)((UIntPtr)id)];
        AppMain.AOS_ACTION aos_ACTION = AppMain.aoActAllocAction();
        if ( aos_ACTION == null )
        {
            return null;
        }
        AppMain.AoActAcmPush();
        AppMain.AoActAcmFlagPush( 0U, uint.MaxValue );
        aos_ACTION.data = a2S_AMA_NODE;
        aos_ACTION.flag = 0U;
        aos_ACTION.state = 0U;
        aos_ACTION.type = AppMain.AOE_ACT_TYPE.AOD_ACT_TYPE_NODE;
        aos_ACTION.frame = frame;
        aos_ACTION.last_key.trs = -1;
        aos_ACTION.last_key.mtn = -1;
        aos_ACTION.last_key.anm = -1;
        aos_ACTION.last_key.mat = -1;
        aos_ACTION.last_key.atrs = -1;
        aos_ACTION.last_key.amtn = -1;
        aos_ACTION.last_key.amat = -1;
        aos_ACTION.last_key.usr = -1;
        aos_ACTION.last_key.hit = -1;
        aos_ACTION.child = null;
        aos_ACTION.sibling = null;
        if ( a2S_AMA_NODE.act_offset != 0 )
        {
            aos_ACTION.sprite = AppMain.AoActSprCreate( ama, a2S_AMA_NODE.act.id, frame );
            if ( aos_ACTION.sprite == null )
            {
                AppMain.AoActDelete( aos_ACTION );
                AppMain.AoActAcmFlagPop();
                AppMain.AoActAcmPop();
                return null;
            }
        }
        else
        {
            aos_ACTION.sprite = null;
        }
        if ( a2S_AMA_NODE.child_offset != 0 )
        {
            aos_ACTION.child = AppMain.AoActCreateNodeSub( ama, a2S_AMA_NODE.child.id, frame, true );
            if ( aos_ACTION.child == null )
            {
                AppMain.AoActAcmFlagPop();
                AppMain.AoActAcmPop();
                return aos_ACTION;
            }
        }
        AppMain.AoActAcmFlagPop();
        AppMain.AoActAcmPop();
        if ( sib && a2S_AMA_NODE.sibling_offset != 0 )
        {
            aos_ACTION.sibling = AppMain.AoActCreateNodeSub( ama, a2S_AMA_NODE.sibling.id, frame, true );
            if ( aos_ACTION.sibling == null )
            {
                return aos_ACTION;
            }
        }
        return aos_ACTION;
    }

    // Token: 0x06001662 RID: 5730 RVA: 0x000C2068 File Offset: 0x000C0268
    public static void AoActDelete( AppMain.AOS_ACTION act )
    {
        if ( act.sibling != null )
        {
            AppMain.AoActDelete( act.sibling );
            act.sibling = null;
        }
        if ( act.child != null )
        {
            AppMain.AoActDelete( act.child );
            act.child = null;
        }
        if ( act.sprite != null )
        {
            AppMain.AoActSprDelete( act.sprite );
            act.sprite = null;
        }
        AppMain.aoActFreeAction( act );
    }

    // Token: 0x06001663 RID: 5731 RVA: 0x000C20C9 File Offset: 0x000C02C9
    public static void AoActSetFrame( AppMain.AOS_ACTION act, float frame )
    {
        do
        {
            act.frame = frame;
            act.flag |= 1U;
            if ( act.child != null )
            {
                AppMain.AoActSetFrame( act.child, frame );
            }
            act = act.sibling;
        }
        while ( act != null );
    }

    // Token: 0x06001664 RID: 5732 RVA: 0x000C20FF File Offset: 0x000C02FF
    public static void AoActUpdate( AppMain.AOS_ACTION act )
    {
        AppMain.AoActUpdate( act, 1f );
    }

    // Token: 0x06001665 RID: 5733 RVA: 0x000C210C File Offset: 0x000C030C
    public static void AoActUpdate( AppMain.AOS_ACTION act, float frame )
    {
        act.frame += AppMain.g_ao_act_sys_frame_rate * frame;
        if ( act.frame < 0f )
        {
            act.frame = 0f;
        }
        act.flag |= 1U;
        if ( act.child != null )
        {
            AppMain.AoActSetFrame( act.child, act.frame );
        }
        AppMain.aoActApply( act );
        act.state = AppMain.aoActGetAmaActState( AppMain.aoActGetAmaAct( act ), act.frame );
    }

    // Token: 0x06001666 RID: 5734 RVA: 0x000C2189 File Offset: 0x000C0389
    private static void AoActDraw( AppMain.AOS_ACTION act )
    {
        AppMain.AoActDraw( act, false );
    }

    // Token: 0x06001667 RID: 5735 RVA: 0x000C2194 File Offset: 0x000C0394
    private static void AoActDraw( AppMain.AOS_ACTION act, bool sort )
    {
        if ( AppMain.g_ao_act_sort_num >= AppMain.g_ao_act_sort_buf_size )
        {
            return;
        }
        AppMain.ArrayPointer<AppMain.AOS_ACT_SORT> arrayPointer = AppMain.g_ao_act_sort_buf;
        uint num = AppMain.g_ao_act_sort_buf_size;
        uint num2 = AppMain.g_ao_act_sort_num;
        uint num3 = AppMain.g_ao_act_sort_peak;
        AppMain.g_ao_act_sort_buf += ( int )AppMain.g_ao_act_sort_num;
        AppMain.g_ao_act_sort_buf_size -= AppMain.g_ao_act_sort_num;
        AppMain.g_ao_act_sort_num = 0U;
        AppMain.g_ao_act_sort_peak = 0U;
        AppMain.AoActSortRegAction( act );
        uint num4 = AppMain.g_ao_act_sort_num;
        if ( sort )
        {
            AppMain.AoActSortExecute();
        }
        AppMain.AoActSortDraw();
        AppMain.AoActSortUnregAll();
        AppMain.g_ao_act_sort_buf = arrayPointer;
        AppMain.g_ao_act_sort_buf_size = num;
        AppMain.g_ao_act_sort_num = num2;
        AppMain.g_ao_act_sort_peak = num3;
        if ( AppMain.g_ao_act_sort_num + num4 > AppMain.g_ao_act_sort_peak )
        {
            AppMain.g_ao_act_sort_peak = AppMain.g_ao_act_sort_num + num4;
        }
    }

    // Token: 0x06001668 RID: 5736 RVA: 0x000C2249 File Offset: 0x000C0449
    public static uint AoActGetState( AppMain.AOS_ACTION act )
    {
        if ( act != null )
        {
            return act.state;
        }
        return 1023U;
    }

    // Token: 0x06001669 RID: 5737 RVA: 0x000C225A File Offset: 0x000C045A
    public static bool AoActIsEnd( AppMain.AOS_ACTION act )
    {
        return act == null || AppMain.aoActIsAmaActEnd( AppMain.aoActGetAmaAct( act ), act.frame );
    }

    // Token: 0x0600166A RID: 5738 RVA: 0x000C2274 File Offset: 0x000C0474
    public static bool AoActIsEndTrs( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaTrsEnd( a2S_AMA_ACT.mtn, act.frame );
    }

    // Token: 0x0600166B RID: 5739 RVA: 0x000C22A0 File Offset: 0x000C04A0
    public static bool AoActIsEndMtn( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaMtnEnd( a2S_AMA_ACT.mtn, act.frame );
    }

    // Token: 0x0600166C RID: 5740 RVA: 0x000C22CC File Offset: 0x000C04CC
    public static bool AoActIsEndAnm( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaAnmEnd( a2S_AMA_ACT.anm, act.frame );
    }

    // Token: 0x0600166D RID: 5741 RVA: 0x000C22F8 File Offset: 0x000C04F8
    public static bool AoActIsEndMat( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaMatEnd( a2S_AMA_ACT.anm, act.frame );
    }

    // Token: 0x0600166E RID: 5742 RVA: 0x000C2324 File Offset: 0x000C0524
    public static bool AoActIsEndAcmTrs( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaAcmTrsEnd( a2S_AMA_ACT.acm, act.frame );
    }

    // Token: 0x0600166F RID: 5743 RVA: 0x000C2350 File Offset: 0x000C0550
    public static bool AoActIsEndAcmMtn( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaAcmMtnEnd( a2S_AMA_ACT.acm, act.frame );
    }

    // Token: 0x06001670 RID: 5744 RVA: 0x000C237C File Offset: 0x000C057C
    public static bool AoActIsEndAcmMat( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaAcmMatEnd( a2S_AMA_ACT.acm, act.frame );
    }

    // Token: 0x06001671 RID: 5745 RVA: 0x000C23A8 File Offset: 0x000C05A8
    public static bool AoActIsEndUsr( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaUsrEnd( a2S_AMA_ACT.usr, act.frame );
    }

    // Token: 0x06001672 RID: 5746 RVA: 0x000C23D4 File Offset: 0x000C05D4
    public static bool AoActIsEndHit( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        return a2S_AMA_ACT == null || AppMain.aoActIsAmaHitEnd( a2S_AMA_ACT.hit, act.frame );
    }

    // Token: 0x06001673 RID: 5747 RVA: 0x000C2400 File Offset: 0x000C0600
    public static void AoActSortRegSprite( AppMain.AOS_SPRITE spr )
    {
        if ( AppMain.g_ao_act_sort_num >= AppMain.g_ao_act_sort_buf_size )
        {
            return;
        }
        AppMain.g_ao_act_sort_buf.array[( int )( AppMain.g_ao_act_sort_num + ( uint )AppMain.g_ao_act_sort_buf.offset )].sprite = spr;
        AppMain.g_ao_act_sort_buf.array[( int )( AppMain.g_ao_act_sort_num + ( uint )AppMain.g_ao_act_sort_buf.offset )].z = spr.prio;
        AppMain.g_ao_act_sort_num += 1U;
        if ( AppMain.g_ao_act_sort_num > AppMain.g_ao_act_sort_peak )
        {
            AppMain.g_ao_act_sort_peak = AppMain.g_ao_act_sort_num;
        }
    }

    // Token: 0x06001674 RID: 5748 RVA: 0x000C248C File Offset: 0x000C068C
    public static void AoActSortUnregSprite( AppMain.AOS_SPRITE spr )
    {
        int num = 0;
        while ( ( long )num < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
        {
            if ( AppMain.g_ao_act_sort_buf[num].sprite == spr )
            {
                int num2 = 0;
                while ( ( long )num2 < ( long )( ( ulong )AppMain.g_ao_act_sort_num - ( ulong )( ( long )num ) - 1UL ) )
                {
                    AppMain.g_ao_act_sort_buf.array[num2 + num + AppMain.g_ao_act_sort_buf.offset] = AppMain.g_ao_act_sort_buf.array[num2 + num + 1 + AppMain.g_ao_act_sort_buf.offset];
                    num2++;
                }
                AppMain.g_ao_act_sort_num -= 1U;
                if ( AppMain.g_ao_act_sort_num > AppMain.g_ao_act_sort_peak )
                {
                    AppMain.g_ao_act_sort_peak = AppMain.g_ao_act_sort_num;
                    return;
                }
                break;
            }
            else
            {
                num++;
            }
        }
    }

    // Token: 0x06001675 RID: 5749 RVA: 0x000C2548 File Offset: 0x000C0748
    public static void AoActSortRegAction( AppMain.AOS_ACTION act )
    {
        if ( act.sprite != null )
        {
            AppMain.AoActSortRegSprite( act.sprite );
        }
        if ( act.child != null )
        {
            AppMain.AoActSortRegAction( act.child );
        }
        if ( act.sibling != null )
        {
            AppMain.AoActSortRegAction( act.sibling );
        }
    }

    // Token: 0x06001676 RID: 5750 RVA: 0x000C2583 File Offset: 0x000C0783
    public static void AoActSortUnregAction( AppMain.AOS_ACTION act )
    {
        if ( act.sprite != null )
        {
            AppMain.AoActSortUnregSprite( act.sprite );
        }
        if ( act.child != null )
        {
            AppMain.AoActSortUnregAction( act.child );
        }
        if ( act.sibling != null )
        {
            AppMain.AoActSortUnregAction( act.sibling );
        }
    }

    // Token: 0x06001677 RID: 5751 RVA: 0x000C25BE File Offset: 0x000C07BE
    public static void AoActSortUnregAll()
    {
        AppMain.g_ao_act_sort_num = 0U;
    }

    // Token: 0x06001678 RID: 5752 RVA: 0x000C25C8 File Offset: 0x000C07C8
    public static void AoActSortExecute()
    {
        AppMain.AOS_ACT_SORT[] array = AppMain.g_ao_act_sort_buf.array;
        int num = 0;
        while ( ( long )num < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
        {
            bool flag = true;
            int num2 = num + 1;
            while ( ( long )num2 < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
            {
                if ( array[num2].z > array[num2 - 1].z )
                {
                    AppMain.AOS_ACT_SORT aos_ACT_SORT = array[num2];
                    array[num2] = array[num2 - 1];
                    array[num2 - 1] = aos_ACT_SORT;
                    flag = false;
                }
                num2++;
            }
            if ( flag )
            {
                return;
            }
            num++;
        }
    }

    // Token: 0x06001679 RID: 5753 RVA: 0x000C2670 File Offset: 0x000C0870
    public static void AoActSortExecuteFix()
    {
        AppMain.AOS_ACT_SORT[] array = AppMain.g_ao_act_sort_buf.array;
        int i = 0;
        while ( ( long )i < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
        {
            bool flag = true;
            int num = (int)(AppMain.g_ao_act_sort_num - 1U);
            while ( i < num )
            {
                if ( array[num].z > array[num - 1].z )
                {
                    AppMain.AOS_ACT_SORT aos_ACT_SORT = array[num];
                    array[num] = array[num - 1];
                    array[num - 1] = aos_ACT_SORT;
                    flag = false;
                }
                num--;
            }
            if ( flag )
            {
                return;
            }
            i++;
        }
    }

    // Token: 0x0600167A RID: 5754 RVA: 0x000C2714 File Offset: 0x000C0914
    public static void AoActSortDraw()
    {
        if ( AppMain.g_ao_act_sort_num == 0U )
        {
            return;
        }
        if ( AppMain.g_ao_act_sys_draw_state_enable )
        {
            AppMain.aoActDrawSortState();
            return;
        }
        AppMain.AOS_ACT_DRAW aos_ACT_DRAW = AppMain.amDrawAlloc_AOS_ACT_DRAW();
        aos_ACT_DRAW.count = AppMain.g_ao_act_sort_num;
        aos_ACT_DRAW.sprite = new AppMain.AOS_SPRITE[AppMain.g_ao_act_sort_num];
        int num = 0;
        while ( ( long )num < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
        {
            aos_ACT_DRAW.sprite[num] = AppMain.AOS_SPRITE_Pool.Alloc();
            aos_ACT_DRAW.sprite[num].Assign( AppMain.g_ao_act_sort_buf[num].sprite );
            num++;
        }
        AppMain.amDrawMakeTask( AppMain.aoActDrawTask_TaskProc, ( ushort )AppMain.g_ao_act_sys_draw_prio, aos_ACT_DRAW );
    }

    // Token: 0x0600167B RID: 5755 RVA: 0x000C27AA File Offset: 0x000C09AA
    public static void AoActAcmInit()
    {
        AppMain.AoActAcmInit( null );
    }

    // Token: 0x0600167C RID: 5756 RVA: 0x000C27B4 File Offset: 0x000C09B4
    public static void AoActAcmInit( AppMain.AOS_ACT_ACM acm )
    {
        if ( acm == null )
        {
            acm = AppMain.g_ao_act_acm_cur;
        }
        acm.trans_x = 0f;
        acm.trans_y = 0f;
        acm.trans_z = 0f;
        acm.color.r = byte.MaxValue;
        acm.color.g = byte.MaxValue;
        acm.color.b = byte.MaxValue;
        acm.color.a = byte.MaxValue;
        acm.fade.r = 0;
        acm.fade.g = 0;
        acm.fade.b = 0;
        acm.fade.a = 0;
        acm.trans_scale_x = 1f;
        acm.trans_scale_y = 1f;
        acm.scale_x = 1f;
        acm.scale_y = 1f;
        acm.rotate = 0f;
    }

    // Token: 0x0600167D RID: 5757 RVA: 0x000C2898 File Offset: 0x000C0A98
    public static void AoActAcmPush()
    {
        AppMain.AoActAcmPush( null );
    }

    // Token: 0x0600167E RID: 5758 RVA: 0x000C28A0 File Offset: 0x000C0AA0
    public static void AoActAcmPush( AppMain.AOS_ACT_ACM acm )
    {
        if ( AppMain.g_ao_act_acm_num >= AppMain.g_ao_act_acm_buf_size )
        {
            return;
        }
        if ( acm == null )
        {
            acm = AppMain.g_ao_act_acm_cur.array[AppMain.g_ao_act_acm_cur.offset];
        }
        AppMain.g_ao_act_acm_cur.offset = AppMain.g_ao_act_acm_cur.offset + 1;
        AppMain.g_ao_act_acm_cur.array[AppMain.g_ao_act_acm_cur.offset].Assign( acm );
        AppMain.g_ao_act_acm_num += 1U;
        if ( AppMain.g_ao_act_acm_num > AppMain.g_ao_act_acm_peak )
        {
            AppMain.g_ao_act_acm_peak = AppMain.g_ao_act_acm_num;
        }
    }

    // Token: 0x0600167F RID: 5759 RVA: 0x000C2923 File Offset: 0x000C0B23
    public static void AoActAcmPop()
    {
        AppMain.AoActAcmPop( 1U );
    }

    // Token: 0x06001680 RID: 5760 RVA: 0x000C292C File Offset: 0x000C0B2C
    public static void AoActAcmPop( uint count )
    {
        while ( count > 0U )
        {
            if ( AppMain.g_ao_act_acm_cur == AppMain.g_ao_act_acm_buf )
            {
                return;
            }
            AppMain.g_ao_act_acm_cur -= 1;
            AppMain.g_ao_act_acm_num -= 1U;
            count -= 1U;
        }
        if ( AppMain.g_ao_act_acm_num > AppMain.g_ao_act_acm_peak )
        {
            AppMain.g_ao_act_acm_peak = AppMain.g_ao_act_acm_num;
        }
    }

    // Token: 0x06001681 RID: 5761 RVA: 0x000C2988 File Offset: 0x000C0B88
    private void AoActAcmSet( AppMain.AOS_ACT_ACM acm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001682 RID: 5762 RVA: 0x000C2990 File Offset: 0x000C0B90
    public static void AoActAcmApply( AppMain.AOS_ACT_ACM acm )
    {
        AppMain.AoActAcmApplyTrans( acm.trans_x, acm.trans_y, acm.trans_z );
        AppMain.AoActAcmApplyColor( acm.color );
        AppMain.AoActAcmApplyFade( acm.fade );
        AppMain.AoActAcmApplyTransScale( acm.trans_scale_x, acm.trans_scale_y );
        AppMain.AoActAcmApplyScale( acm.scale_x, acm.scale_y );
        AppMain.AoActAcmApplyRotate( acm.rotate );
    }

    // Token: 0x06001683 RID: 5763 RVA: 0x000C29F7 File Offset: 0x000C0BF7
    private void AoActAcmApplyTrans( Vector3 trs )
    {
        AppMain.AoActAcmApplyTrans( trs.X, trs.Y, trs.Z );
    }

    // Token: 0x06001684 RID: 5764 RVA: 0x000C2A14 File Offset: 0x000C0C14
    public static void AoActAcmApplyTrans( float x, float y, float z )
    {
        ( ~AppMain.g_ao_act_acm_cur ).trans_x += ( ~AppMain.g_ao_act_acm_cur ).trans_scale_x * x;
        ( ~AppMain.g_ao_act_acm_cur ).trans_y += ( ~AppMain.g_ao_act_acm_cur ).trans_scale_y * y;
        ( ~AppMain.g_ao_act_acm_cur ).trans_z += z;
    }

    // Token: 0x06001685 RID: 5765 RVA: 0x000C2A88 File Offset: 0x000C0C88
    public static void AoActAcmApplyColor( AppMain.AOS_ACT_COL col )
    {
        AppMain.AOS_ACT_COL color = (~AppMain.g_ao_act_acm_cur).color;
        color.r = ( byte )( ( uint )( color.r * col.r ) >> 8 );
        color.g = ( byte )( ( uint )( color.g * col.g ) >> 8 );
        color.b = ( byte )( ( uint )( color.b * col.b ) >> 8 );
        color.a = ( byte )( ( uint )( color.a * col.a ) >> 8 );
        ( ~AppMain.g_ao_act_acm_cur ).color = color;
    }

    // Token: 0x06001686 RID: 5766 RVA: 0x000C2B1C File Offset: 0x000C0D1C
    public static void AoActAcmApplyFade( AppMain.AOS_ACT_COL fade )
    {
        AppMain.AOS_ACT_COL fade2 = (~AppMain.g_ao_act_acm_cur).fade;
        uint num = (uint)(fade2.r + fade.r);
        if ( num > 255U )
        {
            fade2.r = byte.MaxValue;
        }
        else
        {
            fade2.r = ( byte )num;
        }
        num = ( uint )( fade2.g + fade.g );
        if ( num > 255U )
        {
            fade2.g = byte.MaxValue;
        }
        else
        {
            fade2.g = ( byte )num;
        }
        num = ( uint )( fade2.b + fade.b );
        if ( num > 255U )
        {
            fade2.b = byte.MaxValue;
        }
        else
        {
            fade2.b = ( byte )num;
        }
        num = ( uint )( fade2.a + fade.a );
        if ( num > 255U )
        {
            fade2.a = byte.MaxValue;
        }
        else
        {
            fade2.a = ( byte )num;
        }
        ( ~AppMain.g_ao_act_acm_cur ).fade = fade2;
    }

    // Token: 0x06001687 RID: 5767 RVA: 0x000C2C05 File Offset: 0x000C0E05
    public static void AoActAcmApplyTransScale( Vector3 tscl )
    {
        AppMain.AoActAcmApplyTransScale( tscl.X, tscl.Y );
    }

    // Token: 0x06001688 RID: 5768 RVA: 0x000C2C1A File Offset: 0x000C0E1A
    public static void AoActAcmApplyTransScale( float x, float y )
    {
        ( ~AppMain.g_ao_act_acm_cur ).trans_scale_x *= x;
        ( ~AppMain.g_ao_act_acm_cur ).trans_scale_y *= y;
    }

    // Token: 0x06001689 RID: 5769 RVA: 0x000C2C4A File Offset: 0x000C0E4A
    public static void AoActAcmApplyScale( Vector3 scl )
    {
        AppMain.AoActAcmApplyScale( scl.X, scl.Y );
    }

    // Token: 0x0600168A RID: 5770 RVA: 0x000C2C5F File Offset: 0x000C0E5F
    public static void AoActAcmApplyScale( float x, float y )
    {
        ( ~AppMain.g_ao_act_acm_cur ).scale_x *= x;
        ( ~AppMain.g_ao_act_acm_cur ).scale_y *= y;
    }

    // Token: 0x0600168B RID: 5771 RVA: 0x000C2C8F File Offset: 0x000C0E8F
    public static void AoActAcmApplyRotate( float rot )
    {
        ( ~AppMain.g_ao_act_acm_cur ).rotate += rot;
    }

    // Token: 0x0600168C RID: 5772 RVA: 0x000C2CA8 File Offset: 0x000C0EA8
    public static void AoActAcmSetFlag( uint flag )
    {
        AppMain.g_ao_act_acm_flag_cur.SetPrimitive( flag );
    }

    // Token: 0x0600168D RID: 5773 RVA: 0x000C2CB6 File Offset: 0x000C0EB6
    public static void AoActAcmSetFlag()
    {
        AppMain.AoActAcmSetFlag( 0U );
    }

    // Token: 0x0600168E RID: 5774 RVA: 0x000C2CBE File Offset: 0x000C0EBE
    public static uint AoActAcmGetFlag()
    {
        return AppMain.g_ao_act_acm_flag_cur;
    }

    // Token: 0x0600168F RID: 5775 RVA: 0x000C2CCC File Offset: 0x000C0ECC
    public static void AoActAcmFlagPush( uint on, uint off )
    {
        if ( AppMain.g_ao_act_acm_flag_num >= AppMain.g_ao_act_acm_flag_buf_size )
        {
            return;
        }
        uint num = AppMain.g_ao_act_acm_flag_cur;
        AppMain.g_ao_act_acm_flag_cur += 1;
        num |= on;
        num &= ~off;
        AppMain.g_ao_act_acm_flag_cur.SetPrimitive( num );
        AppMain.g_ao_act_acm_flag_num += 1U;
        if ( AppMain.g_ao_act_acm_flag_num > AppMain.g_ao_act_acm_flag_peak )
        {
            AppMain.g_ao_act_acm_flag_peak = AppMain.g_ao_act_acm_flag_num;
        }
    }

    // Token: 0x06001690 RID: 5776 RVA: 0x000C2D38 File Offset: 0x000C0F38
    public static void AoActAcmFlagPop()
    {
        AppMain.AoActAcmFlagPop( 1U );
    }

    // Token: 0x06001691 RID: 5777 RVA: 0x000C2D40 File Offset: 0x000C0F40
    public static void AoActAcmFlagPop( uint count )
    {
        while ( count > 0U )
        {
            if ( AppMain.g_ao_act_acm_flag_cur == AppMain.g_ao_act_acm_flag_buf )
            {
                return;
            }
            AppMain.g_ao_act_acm_flag_cur -= 1;
            AppMain.g_ao_act_acm_flag_num -= 1U;
            count -= 1U;
        }
        if ( AppMain.g_ao_act_acm_flag_num > AppMain.g_ao_act_acm_flag_peak )
        {
            AppMain.g_ao_act_acm_flag_peak = AppMain.g_ao_act_acm_flag_num;
        }
    }

    // Token: 0x06001692 RID: 5778 RVA: 0x000C2D9C File Offset: 0x000C0F9C
    public static bool AoActGetHitSpr( AppMain.AOS_ACT_HIT hit, AppMain.AOS_SPRITE spr )
    {
        if ( spr.hit.type >= AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NUM )
        {
            hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
            return false;
        }
        hit.type = spr.hit.type;
        hit.center_x = spr.center_x;
        hit.center_y = spr.center_y;
        hit.scale_x = spr.hit.scale_x;
        hit.scale_y = spr.hit.scale_y;
        if ( ( spr.hit.flag & 2U ) != 0U )
        {
            hit.rotate = 0f;
        }
        else
        {
            hit.rotate = spr.rotate;
        }
        switch ( hit.type )
        {
            case AppMain.AOE_ACT_HIT.AOD_ACT_HIT_RECT:
                hit.rect.left = spr.hit.rect.left;
                hit.rect.top = spr.hit.rect.top;
                hit.rect.right = spr.hit.rect.right;
                hit.rect.bottom = spr.hit.rect.bottom;
                break;
            case AppMain.AOE_ACT_HIT.AOD_ACT_HIT_CIRCLE:
                hit.circle.center_x = spr.hit.rect.left;
                hit.circle.center_y = spr.hit.rect.top;
                hit.circle.radius = spr.hit.rect.right;
                break;
            default:
                hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
                return false;
        }
        return true;
    }

    // Token: 0x06001693 RID: 5779 RVA: 0x000C2F18 File Offset: 0x000C1118
    public static bool AoActGetHitAct( AppMain.ArrayPointer<AppMain.AOS_ACT_HIT> hit, AppMain.AOS_ACTION act )
    {
        return AppMain.AoActGetHitSpr( hit, AppMain.AoActUtilGetSprFromAct( act ) );
    }

    // Token: 0x06001694 RID: 5780 RVA: 0x000C2F2C File Offset: 0x000C112C
    public static uint AoActGetHitNum( AppMain.AOS_ACTION act )
    {
        uint num = 0U;
        if ( AppMain.AoActUtilGetSprFromAct( act ).hit.type < AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NUM )
        {
            num += 1U;
        }
        if ( act.child != null )
        {
            num += AppMain.AoActGetHitNum( act.child );
        }
        if ( act.sibling != null )
        {
            num += AppMain.AoActGetHitNum( act.sibling );
        }
        return num;
    }

    // Token: 0x06001695 RID: 5781 RVA: 0x000C2F7F File Offset: 0x000C117F
    public static uint AoActGetHitTbl( AppMain.ArrayPointer<AppMain.AOS_ACT_HIT> hit_tbl, AppMain.AOS_ACTION act )
    {
        return AppMain.AoActGetHitTbl( hit_tbl, uint.MaxValue, act );
    }

    // Token: 0x06001696 RID: 5782 RVA: 0x000C2F8C File Offset: 0x000C118C
    public static uint AoActGetHitTbl( AppMain.ArrayPointer<AppMain.AOS_ACT_HIT> hit_tbl, uint size, AppMain.AOS_ACTION act )
    {
        uint num = 0U;
        if ( AppMain.AoActUtilGetSprFromAct( act ).hit.type < AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NUM )
        {
            if ( size < 1U )
            {
                return num;
            }
            AppMain.AoActGetHitSpr( hit_tbl[( int )num], AppMain.AoActUtilGetSprFromAct( act ) );
            num += 1U;
            size -= 1U;
        }
        if ( act.child != null )
        {
            uint num2 = AppMain.AoActGetHitTbl(hit_tbl + (int)num, size, act.child);
            num += num2;
            if ( size <= num2 )
            {
                return num;
            }
            size -= num2;
        }
        if ( act.sibling != null )
        {
            uint num3 = AppMain.AoActGetHitTbl(hit_tbl + (int)num, size, act.sibling);
            num += num3;
            if ( size <= num3 )
            {
                return num;
            }
            size -= num3;
        }
        return num;
    }

    // Token: 0x06001697 RID: 5783 RVA: 0x000C302C File Offset: 0x000C122C
    public static bool AoActGetHitActId( AppMain.AOS_ACT_HIT hit, AppMain.AOS_ACTION act, uint id )
    {
        AppMain.AOS_ACTION aos_ACTION = AppMain.AoActUtilGetActFromId(act, id);
        if ( aos_ACTION == null )
        {
            hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
            return false;
        }
        return AppMain.AoActGetHitAct( new AppMain.AOS_ACT_HIT[]
        {
            hit
        }, aos_ACTION );
    }

    // Token: 0x06001698 RID: 5784 RVA: 0x000C3064 File Offset: 0x000C1264
    public static bool AoActHitTest( AppMain.AOS_ACT_HIT hit, float x, float y )
    {
        if ( hit.type >= AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NUM )
        {
            return false;
        }
        x -= hit.center_x;
        y -= hit.center_y;
        float num = 0f;
        float num2 = 0f;
        AppMain.amSinCos( AppMain.NNM_DEGtoA32( -hit.rotate ), out num, out num2 );
        float num3 = x * num2 - y * num;
        float num4 = x * num + y * num2;
        x = num3 / hit.scale_x;
        y = num4 / hit.scale_y;
        switch ( hit.type )
        {
            case AppMain.AOE_ACT_HIT.AOD_ACT_HIT_RECT:
                if ( x >= hit.rect.left && x <= hit.rect.right && y >= hit.rect.top && y <= hit.rect.bottom )
                {
                    return true;
                }
                break;
            case AppMain.AOE_ACT_HIT.AOD_ACT_HIT_CIRCLE:
                num3 = x - hit.circle.center_x;
                num4 = y - hit.circle.center_y;
                if ( num3 * num3 + num4 * num4 <= hit.circle.radius * hit.circle.radius )
                {
                    return true;
                }
                break;
        }
        return false;
    }

    // Token: 0x06001699 RID: 5785 RVA: 0x000C3173 File Offset: 0x000C1373
    public static bool AoActHitTestCorReverse( AppMain.AOS_ACT_HIT hit, float x, float y )
    {
        AppMain.AoActCorReverse( ref x, ref y );
        return AppMain.AoActHitTest( hit, x, y );
    }

    // Token: 0x0600169A RID: 5786 RVA: 0x000C3188 File Offset: 0x000C1388
    public static uint AoActUtilGetActNum( AppMain.AOS_ACTION act )
    {
        if ( act == null )
        {
            return 0U;
        }
        uint num = 1U;
        num += AppMain.AoActUtilGetActNum( act.child );
        return num + AppMain.AoActUtilGetActNum( act.sibling );
    }

    // Token: 0x0600169B RID: 5787 RVA: 0x000C31BC File Offset: 0x000C13BC
    public static AppMain.AOS_ACTION AoActUtilGetActFromId( AppMain.AOS_ACTION act, uint id )
    {
        AppMain.AOS_ACTION aos_ACTION = null;
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        if ( a2S_AMA_ACT.id == id )
        {
            aos_ACTION = act;
        }
        else
        {
            if ( act.child != null )
            {
                aos_ACTION = AppMain.AoActUtilGetActFromId( act.child, id );
            }
            if ( aos_ACTION == null && act.sibling != null )
            {
                aos_ACTION = AppMain.AoActUtilGetActFromId( act.sibling, id );
            }
        }
        return aos_ACTION;
    }

    // Token: 0x0600169C RID: 5788 RVA: 0x000C320D File Offset: 0x000C140D
    public static AppMain.AOS_SPRITE AoActUtilGetSprFromAct( AppMain.AOS_ACTION act )
    {
        return act.sprite;
    }

    // Token: 0x0600169D RID: 5789 RVA: 0x000C3218 File Offset: 0x000C1418
    public static void AoActDrawCorWide( AppMain.ArrayPointer<AppMain.NNS_PRIM3D_PN> v, uint v_num, AppMain.AOE_ACT_CORW type )
    {
        switch ( type )
        {
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE:
                {
                    int num = 0;
                    while ( ( long )num < ( long )( ( ulong )v_num ) )
                    {
                        v[num].Pos.x *= 1.125f;
                        num++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER:
                {
                    int num2 = 0;
                    while ( ( long )num2 < ( long )( ( ulong )v_num ) )
                    {
                        v[num2].Pos.x += 60f;
                        num2++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT:
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT:
                {
                    float num3 = 120f;
                    int num4 = 0;
                    while ( ( long )num4 < ( long )( ( ulong )v_num ) )
                    {
                        v[num4].Pos.x += num3;
                        num4++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S:
                {
                    int num5 = 0;
                    while ( ( long )num5 < ( long )( ( ulong )v_num ) )
                    {
                        v[num5].Pos.x += ( float )AppMain.g_ao_act_wide_shift;
                        num5++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S:
                {
                    float num6 = 120f;
                    num6 -= ( float )AppMain.g_ao_act_wide_shift;
                    int num7 = 0;
                    while ( ( long )num7 < ( long )( ( ulong )v_num ) )
                    {
                        v[num7].Pos.x += num6;
                        num7++;
                    }
                    break;
                }
            default:
                return;
        }
    }

    // Token: 0x0600169E RID: 5790 RVA: 0x000C3344 File Offset: 0x000C1544
    public static void AoActDrawCorWide( AppMain.NNS_PRIM3D_PC[] v, int i0, uint v_num, AppMain.AOE_ACT_CORW type )
    {
        switch ( type )
        {
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE:
                {
                    int num = 0;
                    while ( ( long )num < ( long )( ( ulong )v_num ) )
                    {
                        int num2 = i0 + num;
                        v[num2].Pos.x = v[num2].Pos.x * 1.125f;
                        num++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER:
                {
                    int num3 = 0;
                    while ( ( long )num3 < ( long )( ( ulong )v_num ) )
                    {
                        int num4 = i0 + num3;
                        v[num4].Pos.x = v[num4].Pos.x + 60f;
                        num3++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT:
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT:
                {
                    float num5 = 120f;
                    int num6 = 0;
                    while ( ( long )num6 < ( long )( ( ulong )v_num ) )
                    {
                        int num7 = i0 + num6;
                        v[num7].Pos.x = v[num7].Pos.x + num5;
                        num6++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S:
                {
                    int num8 = 0;
                    while ( ( long )num8 < ( long )( ( ulong )v_num ) )
                    {
                        int num9 = i0 + num8;
                        v[num9].Pos.x = v[num9].Pos.x + ( float )AppMain.g_ao_act_wide_shift;
                        num8++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S:
                {
                    float num10 = 120f;
                    num10 -= ( float )AppMain.g_ao_act_wide_shift;
                    int num11 = 0;
                    while ( ( long )num11 < ( long )( ( ulong )v_num ) )
                    {
                        int num12 = i0 + num11;
                        v[num12].Pos.x = v[num12].Pos.x + num10;
                        num11++;
                    }
                    break;
                }
            default:
                return;
        }
    }

    // Token: 0x0600169F RID: 5791 RVA: 0x000C3478 File Offset: 0x000C1678
    public static void AoActDrawCorWide( AppMain.NNS_PRIM3D_PCT_ARRAY array, int i0, uint v_num, AppMain.AOE_ACT_CORW type )
    {
        AppMain.NNS_PRIM3D_PCT[] buffer = array.buffer;
        i0 += array.offset;
        switch ( type )
        {
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE:
                {
                    int num = 0;
                    while ( ( long )num < ( long )( ( ulong )v_num ) )
                    {
                        AppMain.NNS_PRIM3D_PCT[] array2 = buffer;
                        int num2 = i0 + num;
                        array2[num2].Pos.x = array2[num2].Pos.x * 1.125f;
                        num++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER:
                {
                    int num3 = 0;
                    while ( ( long )num3 < ( long )( ( ulong )v_num ) )
                    {
                        AppMain.NNS_PRIM3D_PCT[] array3 = buffer;
                        int num4 = i0 + num3;
                        array3[num4].Pos.x = array3[num4].Pos.x + 60f;
                        num3++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT:
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT:
                {
                    float num5 = 120f;
                    int num6 = 0;
                    while ( ( long )num6 < ( long )( ( ulong )v_num ) )
                    {
                        AppMain.NNS_PRIM3D_PCT[] array4 = buffer;
                        int num7 = i0 + num6;
                        array4[num7].Pos.x = array4[num7].Pos.x + num5;
                        num6++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S:
                {
                    int num8 = 0;
                    while ( ( long )num8 < ( long )( ( ulong )v_num ) )
                    {
                        AppMain.NNS_PRIM3D_PCT[] array5 = buffer;
                        int num9 = i0 + num8;
                        array5[num9].Pos.x = array5[num9].Pos.x + ( float )AppMain.g_ao_act_wide_shift;
                        num8++;
                    }
                    return;
                }
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S:
                {
                    float num10 = 120f;
                    num10 -= ( float )AppMain.g_ao_act_wide_shift;
                    int num11 = 0;
                    while ( ( long )num11 < ( long )( ( ulong )v_num ) )
                    {
                        AppMain.NNS_PRIM3D_PCT[] array6 = buffer;
                        int num12 = i0 + num11;
                        array6[num12].Pos.x = array6[num12].Pos.x + num10;
                        num11++;
                    }
                    break;
                }
            default:
                return;
        }
    }

    // Token: 0x060016A0 RID: 5792 RVA: 0x000C35C0 File Offset: 0x000C17C0
    private void AoActDrawCorWide( ref float x, ref float y, AppMain.AOE_ACT_CORW type )
    {
        float num = x;
        float num2 = y;
        switch ( type )
        {
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE:
                num *= 1.125f;
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER:
                num += 60f;
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT:
                num += 120f;
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S:
                num += ( float )AppMain.g_ao_act_wide_shift;
                break;
            case AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S:
                num += 120f - ( float )AppMain.g_ao_act_wide_shift;
                break;
        }
        x = num;
        y = num2;
    }

    // Token: 0x060016A1 RID: 5793 RVA: 0x000C3634 File Offset: 0x000C1834
    public static void AoActCorReverse( ref float x, ref float y )
    {
        float num = x;
        float num2 = y;
        num *= 2.25f;
        num2 *= 2.25f;
        num *= 0.8888889f;
        x = num;
        y = num2;
    }

    // Token: 0x060016A2 RID: 5794 RVA: 0x000C3665 File Offset: 0x000C1865
    public static AppMain.AOS_ACTION AoActUtilGetChild( AppMain.AOS_ACTION act )
    {
        return act.child;
    }

    // Token: 0x060016A3 RID: 5795 RVA: 0x000C366D File Offset: 0x000C186D
    public static AppMain.AOS_ACTION AoActUtilGetSibling( AppMain.AOS_ACTION act )
    {
        return act.sibling;
    }

    // Token: 0x060016A4 RID: 5796 RVA: 0x000C3675 File Offset: 0x000C1875
    public static bool AoActIsAma( byte[] file, int offset )
    {
        return file[offset + 1] == AppMain.AmaMagicId[1] && file[offset + 2] == AppMain.AmaMagicId[2] && file[offset + 3] == AppMain.AmaMagicId[3];
    }

    // Token: 0x060016A5 RID: 5797 RVA: 0x000C36A4 File Offset: 0x000C18A4
    public static void AoActDrawPre()
    {
        AppMain.NNS_MATRIX aoActDrawPre_mtx = AppMain.AoActDrawPre_mtx;
        aoActDrawPre_mtx.Clear();
        AppMain.nnMakeOrthoMatrix( aoActDrawPre_mtx, 0f, 720f, 1080f, 0f, 1f, 3f );
        AppMain.amDrawSetProjection( aoActDrawPre_mtx, 1 );
        AppMain.nnMakeUnitMatrix( aoActDrawPre_mtx );
        AppMain.nnRotateZMatrix( aoActDrawPre_mtx, aoActDrawPre_mtx, AppMain.NNM_DEGtoA32( 90f ) );
        AppMain.nnTranslateMatrix( aoActDrawPre_mtx, aoActDrawPre_mtx, 0f, -720f, 0f );
        AppMain.amDrawSetWorldViewMatrix( aoActDrawPre_mtx );
        AppMain.nnSetPrimitive3DMatrix( aoActDrawPre_mtx );
    }

    // Token: 0x060016A6 RID: 5798 RVA: 0x000C3724 File Offset: 0x000C1924
    public static void aoActAcmSprite( AppMain.AOS_SPRITE spr )
    {
        AppMain.AOS_ACT_ACM aos_ACT_ACM = ~AppMain.g_ao_act_acm_cur;
        uint num = ~AppMain.g_ao_act_acm_flag_cur;
        if ( ( num & 32U ) == 0U )
        {
            spr.offset.left = spr.offset.left * aos_ACT_ACM.scale_x;
            spr.offset.right = spr.offset.right * aos_ACT_ACM.scale_x;
            spr.offset.top = spr.offset.top * aos_ACT_ACM.scale_y;
            spr.offset.bottom = spr.offset.bottom * aos_ACT_ACM.scale_y;
            if ( ( spr.hit.flag & 1U ) == 0U )
            {
                spr.hit.scale_x *= aos_ACT_ACM.scale_x;
                spr.hit.scale_y *= aos_ACT_ACM.scale_y;
            }
            if ( aos_ACT_ACM.rotate != 0f )
            {
                float num2;
                float num3;
                AppMain.amSinCos( AppMain.NNM_DEGtoA32( aos_ACT_ACM.rotate ), out num2, out num3 );
                float center_x = spr.center_x * num3 - spr.center_y * num2;
                float center_y = spr.center_x * num2 + spr.center_y * num3;
                spr.center_x = center_x;
                spr.center_y = center_y;
                spr.rotate += aos_ACT_ACM.rotate;
            }
            spr.center_x *= aos_ACT_ACM.trans_scale_x;
            spr.center_y *= aos_ACT_ACM.trans_scale_y;
        }
        if ( ( num & 8U ) == 0U )
        {
            spr.center_x += aos_ACT_ACM.trans_x;
            spr.center_y += aos_ACT_ACM.trans_y;
            spr.prio += aos_ACT_ACM.trans_z;
        }
        if ( ( num & 16U ) == 0U )
        {
            spr.color.r = ( byte )( ( uint )( spr.color.r * aos_ACT_ACM.color.r ) >> 8 );
            spr.color.g = ( byte )( ( uint )( spr.color.g * aos_ACT_ACM.color.g ) >> 8 );
            spr.color.b = ( byte )( ( uint )( spr.color.b * aos_ACT_ACM.color.b ) >> 8 );
            spr.color.a = ( byte )( ( uint )( spr.color.a * aos_ACT_ACM.color.a ) >> 8 );
            uint num4 = (uint)(spr.fade.r + aos_ACT_ACM.fade.r);
            if ( num4 > 255U )
            {
                spr.fade.r = byte.MaxValue;
            }
            else
            {
                spr.fade.r = ( byte )num4;
            }
            num4 = ( uint )( spr.fade.g + aos_ACT_ACM.fade.g );
            if ( num4 > 255U )
            {
                spr.fade.g = byte.MaxValue;
            }
            else
            {
                spr.fade.g = ( byte )num4;
            }
            num4 = ( uint )( spr.fade.b + aos_ACT_ACM.fade.b );
            if ( num4 > 255U )
            {
                spr.fade.b = byte.MaxValue;
            }
            else
            {
                spr.fade.b = ( byte )num4;
            }
            num4 = ( uint )( spr.fade.a + aos_ACT_ACM.fade.a );
            if ( num4 > 255U )
            {
                spr.fade.a = byte.MaxValue;
                return;
            }
            spr.fade.a = ( byte )num4;
        }
    }

    // Token: 0x060016A7 RID: 5799 RVA: 0x000C3A64 File Offset: 0x000C1C64
    public static void aoActApply( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT a2S_AMA_ACT = AppMain.aoActGetAmaAct(act);
        AppMain.AoActAcmPush();
        if ( a2S_AMA_ACT != null && ( act.flag & 1U ) != 0U )
        {
            float num = act.frame;
            while ( a2S_AMA_ACT.next != null && a2S_AMA_ACT.frm_num <= num )
            {
                num -= a2S_AMA_ACT.frm_num;
                a2S_AMA_ACT = a2S_AMA_ACT.next;
            }
            float frame = num;
            AppMain.aoActSearchTrsKey( a2S_AMA_ACT, ref frame, ref act.last_key.trs );
            float frame2 = num;
            AppMain.aoActSearchMtnKey( a2S_AMA_ACT, ref frame2, ref act.last_key.mtn );
            float frame3 = num;
            AppMain.aoActSearchAnmKey( a2S_AMA_ACT, ref frame3, ref act.last_key.anm );
            float frame4 = num;
            AppMain.aoActSearchMatKey( a2S_AMA_ACT, ref frame4, ref act.last_key.mat );
            float frame5 = num;
            AppMain.aoActSearchHitKey( a2S_AMA_ACT, ref frame5, ref act.last_key.hit );
            AppMain.AOS_SPRITE sprite = act.sprite;
            sprite.flag = a2S_AMA_ACT.flag;
            sprite.offset.left = a2S_AMA_ACT.ofst.left;
            sprite.offset.right = a2S_AMA_ACT.ofst.right;
            sprite.offset.top = a2S_AMA_ACT.ofst.top;
            sprite.offset.bottom = a2S_AMA_ACT.ofst.bottom;
            float num2;
            float num3;
            if ( a2S_AMA_ACT.mtn == null )
            {
                sprite.center_x = 0f;
                sprite.center_y = 0f;
                sprite.prio = 0f;
                num2 = 1f;
                num3 = 1f;
                sprite.rotate = 0f;
            }
            else
            {
                AppMain.aoActMakeTrs( a2S_AMA_ACT.mtn.trs_key_num, a2S_AMA_ACT.mtn.trs_frm_num, a2S_AMA_ACT.mtn.trs_key_tbl, a2S_AMA_ACT.mtn.trs_tbl, act.last_key.trs, frame, ref sprite.center_x, ref sprite.center_y, ref sprite.prio );
                AppMain.aoActMakeMtn( a2S_AMA_ACT.mtn.mtn_key_num, a2S_AMA_ACT.mtn.mtn_frm_num, a2S_AMA_ACT.mtn.mtn_key_tbl, a2S_AMA_ACT.mtn.mtn_tbl, act.last_key.mtn, frame2, out num2, out num3, out sprite.rotate );
                AppMain.AOS_SPRITE aos_SPRITE = sprite;
                aos_SPRITE.offset.left = aos_SPRITE.offset.left * num2;
                AppMain.AOS_SPRITE aos_SPRITE2 = sprite;
                aos_SPRITE2.offset.right = aos_SPRITE2.offset.right * num2;
                AppMain.AOS_SPRITE aos_SPRITE3 = sprite;
                aos_SPRITE3.offset.top = aos_SPRITE3.offset.top * num3;
                AppMain.AOS_SPRITE aos_SPRITE4 = sprite;
                aos_SPRITE4.offset.bottom = aos_SPRITE4.offset.bottom * num3;
            }
            if ( a2S_AMA_ACT.anm == null )
            {
                sprite.tex_id = -1;
                sprite.color.r = byte.MaxValue;
                sprite.color.g = byte.MaxValue;
                sprite.color.b = byte.MaxValue;
                sprite.color.a = byte.MaxValue;
                sprite.fade.r = 0;
                sprite.fade.g = 0;
                sprite.fade.b = 0;
                sprite.fade.a = 0;
            }
            else
            {
                AppMain.aoActMakeAnm( a2S_AMA_ACT.anm.anm_key_num, a2S_AMA_ACT.anm.anm_frm_num, a2S_AMA_ACT.anm.anm_key_tbl, a2S_AMA_ACT.anm.anm_tbl, act.last_key.anm, frame3, ref sprite.tex_id, ref sprite.uv, ref sprite.clamp );
                AppMain.aoActMakeMat( a2S_AMA_ACT.anm.mat_key_num, a2S_AMA_ACT.anm.mat_frm_num, a2S_AMA_ACT.anm.mat_key_tbl, a2S_AMA_ACT.anm.mat_tbl, act.last_key.mat, frame4, ref sprite.color, ref sprite.fade, out sprite.blend );
            }
            if ( a2S_AMA_ACT.hit == null )
            {
                sprite.hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
            }
            else
            {
                AppMain.aoActMakeHit( a2S_AMA_ACT.hit.hit_key_num, a2S_AMA_ACT.hit.hit_frm_num, a2S_AMA_ACT.hit.hit_key_tbl, a2S_AMA_ACT.hit.hit_tbl, act.last_key.hit, frame5, sprite.hit );
                sprite.hit.scale_x = num2;
                sprite.hit.scale_y = num3;
            }
            sprite.texlist = AppMain.g_ao_act_texlist;
            AppMain.aoActAcmSprite( sprite );
            if ( a2S_AMA_ACT.acm != null )
            {
                float frame6 = num;
                AppMain.aoActSearchAcmTrsKey( a2S_AMA_ACT, ref frame6, ref act.last_key.atrs );
                float frame7 = num;
                AppMain.aoActSearchAcmMtnKey( a2S_AMA_ACT, ref frame7, ref act.last_key.amtn );
                float frame8 = num;
                AppMain.aoActSearchAcmMatKey( a2S_AMA_ACT, ref frame8, ref act.last_key.amat );
                AppMain.AOS_ACT_ACM aos_ACT_ACM = new AppMain.AOS_ACT_ACM();
                if ( ( a2S_AMA_ACT.acm.flag & 16U ) != 0U )
                {
                    aos_ACT_ACM.trans_x = sprite.center_x;
                    aos_ACT_ACM.trans_y = sprite.center_y;
                    aos_ACT_ACM.trans_z = sprite.prio;
                }
                else
                {
                    AppMain.aoActMakeTrs( a2S_AMA_ACT.acm.trs_key_num, a2S_AMA_ACT.acm.trs_frm_num, a2S_AMA_ACT.acm.trs_key_tbl, a2S_AMA_ACT.acm.trs_tbl, act.last_key.atrs, frame6, ref aos_ACT_ACM.trans_x, ref aos_ACT_ACM.trans_y, ref aos_ACT_ACM.trans_z );
                }
                if ( ( a2S_AMA_ACT.acm.flag & 8U ) != 0U )
                {
                    aos_ACT_ACM.trans_scale_x = 1f;
                    aos_ACT_ACM.trans_scale_y = 1f;
                    aos_ACT_ACM.scale_x = num2;
                    aos_ACT_ACM.scale_y = num3;
                    aos_ACT_ACM.rotate = sprite.rotate;
                }
                else
                {
                    AppMain.aoActMakeAcm( a2S_AMA_ACT.acm.acm_key_num, a2S_AMA_ACT.acm.acm_frm_num, a2S_AMA_ACT.acm.acm_key_tbl, a2S_AMA_ACT.acm.acm_tbl, act.last_key.amtn, frame7, ref aos_ACT_ACM.trans_scale_x, ref aos_ACT_ACM.trans_scale_y, ref aos_ACT_ACM.scale_x, ref aos_ACT_ACM.scale_y, ref aos_ACT_ACM.rotate );
                }
                if ( ( a2S_AMA_ACT.acm.flag & 32U ) != 0U )
                {
                    aos_ACT_ACM.color = sprite.color;
                    aos_ACT_ACM.fade = sprite.fade;
                }
                else
                {
                    uint num4;
                    AppMain.aoActMakeMat( a2S_AMA_ACT.acm.mat_key_num, a2S_AMA_ACT.acm.mat_frm_num, a2S_AMA_ACT.acm.mat_key_tbl, a2S_AMA_ACT.acm.mat_tbl, act.last_key.amat, frame8, ref aos_ACT_ACM.color, ref aos_ACT_ACM.fade, out num4 );
                }
                AppMain.AoActAcmApply( aos_ACT_ACM );
            }
        }
        act.flag &= 4294967294U;
        if ( act.child != null )
        {
            AppMain.aoActApply( act.child );
        }
        AppMain.AoActAcmPop();
        if ( act.sibling != null )
        {
            AppMain.aoActApply( act.sibling );
        }
    }

    // Token: 0x060016A8 RID: 5800 RVA: 0x000C40E0 File Offset: 0x000C22E0
    public static void aoActSearchTrsKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.mtn == null || act.mtn.trs_key_tbl == null || act.mtn.trs_frm_num == 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_MTN mtn = act.mtn;
        if ( ( mtn.flag & 2U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, mtn.trs_frm_num );
        }
        else if ( frame >= mtn.trs_frm_num )
        {
            frame = mtn.trs_frm_num;
        }
        AppMain.aoActSerachKey( mtn.trs_key_tbl, mtn.trs_key_num, ref frame, ref key );
    }

    // Token: 0x060016A9 RID: 5801 RVA: 0x000C4168 File Offset: 0x000C2368
    public static void aoActSearchMtnKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.mtn == null || act.mtn.mtn_key_tbl == null || act.mtn.mtn_frm_num == 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_MTN mtn = act.mtn;
        if ( ( mtn.flag & 1U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, mtn.mtn_frm_num );
        }
        else if ( frame >= mtn.mtn_frm_num )
        {
            frame = mtn.mtn_frm_num;
        }
        AppMain.aoActSerachKey( mtn.mtn_key_tbl, mtn.mtn_key_num, ref frame, ref key );
    }

    // Token: 0x060016AA RID: 5802 RVA: 0x000C41F0 File Offset: 0x000C23F0
    public static void aoActSearchAnmKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.anm == null || act.anm.anm_key_tbl == null || act.anm.anm_frm_num == 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_ANM anm = act.anm;
        if ( ( anm.flag & 1U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, anm.anm_frm_num );
        }
        else if ( frame >= anm.anm_frm_num )
        {
            frame = anm.anm_frm_num;
        }
        AppMain.aoActSerachKey( anm.anm_key_tbl, anm.anm_key_num, ref frame, ref key );
    }

    // Token: 0x060016AB RID: 5803 RVA: 0x000C4278 File Offset: 0x000C2478
    public static void aoActSearchMatKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.anm == null || act.anm.mat_key_tbl == null || act.anm.mat_frm_num == 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_ANM anm = act.anm;
        if ( ( anm.flag & 2U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, anm.mat_frm_num );
        }
        else if ( frame >= anm.mat_frm_num )
        {
            frame = anm.mat_frm_num;
        }
        AppMain.aoActSerachKey( anm.mat_key_tbl, anm.mat_key_num, ref frame, ref key );
    }

    // Token: 0x060016AC RID: 5804 RVA: 0x000C4300 File Offset: 0x000C2500
    public static void aoActSearchAcmTrsKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.acm == null || act.acm.trs_key_tbl == null || act.acm.trs_frm_num == 0U || ( act.acm.flag & 16U ) != 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_ACM acm = act.acm;
        if ( ( acm.flag & 2U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, acm.trs_frm_num );
        }
        else if ( frame >= acm.trs_frm_num )
        {
            frame = acm.trs_frm_num;
        }
        AppMain.aoActSerachKey( acm.trs_key_tbl, acm.trs_key_num, ref frame, ref key );
    }

    // Token: 0x060016AD RID: 5805 RVA: 0x000C4398 File Offset: 0x000C2598
    public static void aoActSearchAcmMtnKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.acm == null || act.acm.acm_key_tbl == null || act.acm.acm_frm_num == 0U || ( act.acm.flag & 8U ) != 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_ACM acm = act.acm;
        if ( ( acm.flag & 1U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, acm.acm_frm_num );
        }
        else if ( frame >= acm.acm_frm_num )
        {
            frame = acm.acm_frm_num;
        }
        AppMain.aoActSerachKey( acm.acm_key_tbl, acm.acm_key_num, ref frame, ref key );
    }

    // Token: 0x060016AE RID: 5806 RVA: 0x000C4430 File Offset: 0x000C2630
    public static void aoActSearchAcmMatKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.acm == null || act.acm.mat_key_tbl == null || act.acm.mat_frm_num == 0U || ( act.acm.flag & 32U ) != 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_ACM acm = act.acm;
        if ( ( acm.flag & 4U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, acm.mat_frm_num );
        }
        else if ( frame >= acm.mat_frm_num )
        {
            frame = acm.mat_frm_num;
        }
        AppMain.aoActSerachKey( acm.mat_key_tbl, acm.mat_key_num, ref frame, ref key );
    }

    // Token: 0x060016AF RID: 5807 RVA: 0x000C44C8 File Offset: 0x000C26C8
    public static void aoActSearchHitKey( AppMain.A2S_AMA_ACT act, ref float frame, ref int key )
    {
        if ( act == null || act.hit == null || act.hit.hit_key_tbl == null || act.hit.hit_frm_num == 0U )
        {
            frame = 0f;
            key = -1;
            return;
        }
        AppMain.A2S_AMA_HIT hit = act.hit;
        if ( ( hit.flag & 1U ) != 0U )
        {
            frame = AppMain.aoActGetLoopFrame( frame, hit.hit_frm_num );
        }
        else if ( frame >= hit.hit_frm_num )
        {
            frame = hit.hit_frm_num;
        }
        AppMain.aoActSerachKey( hit.hit_key_tbl, hit.hit_key_num, ref frame, ref key );
    }

    // Token: 0x060016B0 RID: 5808 RVA: 0x000C4550 File Offset: 0x000C2750
    public static void aoActMakeTrs( uint key_num, uint frm_num, AppMain.A2S_SUB_KEY[] key_tbl, AppMain.A2S_SUB_TRS[] trs_tbl, int key, float frame, ref float trans_x, ref float trans_y, ref float trans_z )
    {
        if ( key < 0 || key_num == 0U )
        {
            trans_x = 0f;
            trans_y = 0f;
            trans_z = 0f;
            return;
        }
        uint num = 0U;
        float rate;
        if ( !AppMain.aoActGetInterpolInfo( key_tbl, key_num, frm_num, frame, ( uint )key, ref num, out rate ) )
        {
            AppMain.A2S_SUB_TRS a2S_SUB_TRS = trs_tbl[(int)((UIntPtr)key)];
            trans_x = a2S_SUB_TRS.trs_x;
            trans_y = a2S_SUB_TRS.trs_y;
            trans_z = a2S_SUB_TRS.trs_z;
            return;
        }
        AppMain.A2S_SUB_TRS a2S_SUB_TRS2 = trs_tbl[(int)((UIntPtr)key)];
        AppMain.A2S_SUB_TRS a2S_SUB_TRS3 = trs_tbl[(int)((UIntPtr)num)];
        rate = AppMain.aoActGetAcceleRate( rate, a2S_SUB_TRS2.trs_accele );
        if ( key_tbl[( int )( ( UIntPtr )key )].interpol == 2U && key_num >= 4U )
        {
            int num2 = key - 1;
            if ( num2 < 0 )
            {
                num2 = ( int )( key_num - 1U );
            }
            int num3 = (int)(num + 1U);
            if ( num3 >= ( int )key_num )
            {
                num3 = 0;
            }
            AppMain.A2S_SUB_TRS t = trs_tbl[num2];
            AppMain.A2S_SUB_TRS t2 = trs_tbl[num3];
            AppMain.aoActGetInterpolSpline( t, a2S_SUB_TRS2, a2S_SUB_TRS3, t2, rate, ref trans_x, ref trans_y, ref trans_z );
            return;
        }
        trans_x = AppMain.aoActInterpolF32( a2S_SUB_TRS2.trs_x, a2S_SUB_TRS3.trs_x, rate );
        trans_y = AppMain.aoActInterpolF32( a2S_SUB_TRS2.trs_y, a2S_SUB_TRS3.trs_y, rate );
        trans_z = AppMain.aoActInterpolF32( a2S_SUB_TRS2.trs_z, a2S_SUB_TRS3.trs_z, rate );
    }

    // Token: 0x060016B1 RID: 5809 RVA: 0x000C4668 File Offset: 0x000C2868
    public static void aoActMakeMtn( uint key_num, uint frm_num, AppMain.A2S_SUB_KEY[] key_tbl, AppMain.A2S_SUB_MTN[] mtn_tbl, int key, float frame, out float scale_x, out float scale_y, out float rotate )
    {
        if ( key < 0 || key_num == 0U )
        {
            scale_x = 1f;
            scale_y = 1f;
            rotate = 0f;
            return;
        }
        uint num = 0U;
        float rate;
        if ( !AppMain.aoActGetInterpolInfo( key_tbl, key_num, frm_num, frame, ( uint )key, ref num, out rate ) )
        {
            AppMain.A2S_SUB_MTN a2S_SUB_MTN = mtn_tbl[(int)((UIntPtr)key)];
            scale_x = a2S_SUB_MTN.scl_x;
            scale_y = a2S_SUB_MTN.scl_y;
            rotate = a2S_SUB_MTN.rot;
            return;
        }
        AppMain.A2S_SUB_MTN a2S_SUB_MTN2 = mtn_tbl[(int)((UIntPtr)key)];
        AppMain.A2S_SUB_MTN a2S_SUB_MTN3 = mtn_tbl[(int)((UIntPtr)num)];
        float rate2 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_MTN2.scl_accele);
        float rate3 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_MTN2.rot_accele);
        scale_x = AppMain.aoActInterpolF32( a2S_SUB_MTN2.scl_x, a2S_SUB_MTN3.scl_x, rate2 );
        scale_y = AppMain.aoActInterpolF32( a2S_SUB_MTN2.scl_y, a2S_SUB_MTN3.scl_y, rate2 );
        rotate = AppMain.aoActInterpolF32( a2S_SUB_MTN2.rot, a2S_SUB_MTN3.rot, rate3 );
    }

    // Token: 0x060016B2 RID: 5810 RVA: 0x000C4740 File Offset: 0x000C2940
    public static void aoActMakeAnm( uint key_num, uint frm_num, AppMain.A2S_SUB_KEY[] key_tbl, AppMain.A2S_SUB_ANM[] anm_tbl, int key, float frame, ref int tex_id, ref AppMain.AOS_ACT_RECT rect, ref uint clamp )
    {
        if ( key < 0 || key_num == 0U )
        {
            tex_id = -1;
            return;
        }
        uint num = 0U;
        float rate;
        if ( !AppMain.aoActGetInterpolInfo( key_tbl, key_num, frm_num, frame, ( uint )key, ref num, out rate ) )
        {
            AppMain.A2S_SUB_ANM a2S_SUB_ANM = anm_tbl[(int)((UIntPtr)key)];
            tex_id = a2S_SUB_ANM.tex_id;
            rect.left = a2S_SUB_ANM.texel.left;
            rect.top = a2S_SUB_ANM.texel.top;
            rect.right = a2S_SUB_ANM.texel.right;
            rect.bottom = a2S_SUB_ANM.texel.bottom;
            clamp = a2S_SUB_ANM.clamp;
            return;
        }
        AppMain.A2S_SUB_ANM a2S_SUB_ANM2 = anm_tbl[(int)((UIntPtr)key)];
        AppMain.A2S_SUB_ANM a2S_SUB_ANM3 = anm_tbl[(int)((UIntPtr)num)];
        rate = AppMain.aoActGetAcceleRate( rate, a2S_SUB_ANM2.texel_accele );
        tex_id = a2S_SUB_ANM2.tex_id;
        rect.left = AppMain.aoActInterpolF32( a2S_SUB_ANM2.texel.left, a2S_SUB_ANM3.texel.left, rate );
        rect.top = AppMain.aoActInterpolF32( a2S_SUB_ANM2.texel.top, a2S_SUB_ANM3.texel.top, rate );
        rect.right = AppMain.aoActInterpolF32( a2S_SUB_ANM2.texel.right, a2S_SUB_ANM3.texel.right, rate );
        rect.bottom = AppMain.aoActInterpolF32( a2S_SUB_ANM2.texel.bottom, a2S_SUB_ANM3.texel.bottom, rate );
        clamp = a2S_SUB_ANM2.clamp;
    }

    // Token: 0x060016B3 RID: 5811 RVA: 0x000C4894 File Offset: 0x000C2A94
    public static void aoActMakeMat( uint key_num, uint frm_num, AppMain.A2S_SUB_KEY[] key_tbl, AppMain.A2S_SUB_MAT[] mat_tbl, int key, float frame, ref AppMain.AOS_ACT_COL color, ref AppMain.AOS_ACT_COL fade, out uint blend )
    {
        if ( key < 0 || key_num == 0U )
        {
            color.r = byte.MaxValue;
            color.g = byte.MaxValue;
            color.b = byte.MaxValue;
            color.a = byte.MaxValue;
            fade.r = 0;
            fade.g = 0;
            fade.b = 0;
            fade.a = 0;
            blend = 1U;
            return;
        }
        uint num = 0U;
        float rate;
        if ( !AppMain.aoActGetInterpolInfo( key_tbl, key_num, frm_num, frame, ( uint )key, ref num, out rate ) )
        {
            AppMain.A2S_SUB_MAT a2S_SUB_MAT = mat_tbl[(int)((UIntPtr)key)];
            color.r = a2S_SUB_MAT.base_.r;
            color.g = a2S_SUB_MAT.base_.g;
            color.b = a2S_SUB_MAT.base_.b;
            color.a = a2S_SUB_MAT.base_.a;
            fade.r = a2S_SUB_MAT.fade.r;
            fade.g = a2S_SUB_MAT.fade.g;
            fade.b = a2S_SUB_MAT.fade.b;
            fade.a = a2S_SUB_MAT.fade.a;
            blend = a2S_SUB_MAT.blend;
            return;
        }
        AppMain.A2S_SUB_MAT a2S_SUB_MAT2 = mat_tbl[(int)((UIntPtr)key)];
        AppMain.A2S_SUB_MAT a2S_SUB_MAT3 = mat_tbl[(int)((UIntPtr)num)];
        float rate2 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_MAT2.base_accele);
        float rate3 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_MAT2.fade_accele);
        color = AppMain.aoActInterpolCol( a2S_SUB_MAT2.base_, a2S_SUB_MAT3.base_, rate2 );
        fade = AppMain.aoActInterpolCol( a2S_SUB_MAT2.fade, a2S_SUB_MAT3.fade, rate3 );
        blend = a2S_SUB_MAT2.blend;
    }

    // Token: 0x060016B4 RID: 5812 RVA: 0x000C4A24 File Offset: 0x000C2C24
    public static void aoActMakeAcm( uint key_num, uint frm_num, AppMain.A2S_SUB_KEY[] key_tbl, AppMain.A2S_SUB_ACM[] acm_tbl, int key, float frame, ref float tscale_x, ref float tscale_y, ref float scale_x, ref float scale_y, ref float rotate )
    {
        if ( key < 0 || key_num == 0U )
        {
            tscale_x = 1f;
            tscale_y = 1f;
            scale_x = 1f;
            scale_y = 1f;
            rotate = 0f;
            return;
        }
        uint num = 0U;
        float rate;
        if ( !AppMain.aoActGetInterpolInfo( key_tbl, key_num, frm_num, frame, ( uint )key, ref num, out rate ) )
        {
            AppMain.A2S_SUB_ACM a2S_SUB_ACM = acm_tbl[(int)((UIntPtr)key)];
            tscale_x = a2S_SUB_ACM.trs_scl_x;
            tscale_y = a2S_SUB_ACM.trs_scl_y;
            scale_x = a2S_SUB_ACM.scl_x;
            scale_y = a2S_SUB_ACM.scl_y;
            rotate = a2S_SUB_ACM.rot;
            return;
        }
        AppMain.A2S_SUB_ACM a2S_SUB_ACM2 = acm_tbl[(int)((UIntPtr)key)];
        AppMain.A2S_SUB_ACM a2S_SUB_ACM3 = acm_tbl[(int)((UIntPtr)num)];
        float rate2 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_ACM2.trs_scl_accele);
        float rate3 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_ACM2.scl_accele);
        float rate4 = AppMain.aoActGetAcceleRate(rate, a2S_SUB_ACM2.rot_accele);
        tscale_x = AppMain.aoActInterpolF32( a2S_SUB_ACM2.trs_scl_x, a2S_SUB_ACM3.trs_scl_x, rate2 );
        tscale_y = AppMain.aoActInterpolF32( a2S_SUB_ACM2.trs_scl_y, a2S_SUB_ACM3.trs_scl_y, rate2 );
        scale_x = AppMain.aoActInterpolF32( a2S_SUB_ACM2.scl_x, a2S_SUB_ACM3.scl_x, rate3 );
        scale_y = AppMain.aoActInterpolF32( a2S_SUB_ACM2.scl_y, a2S_SUB_ACM3.scl_y, rate3 );
        rotate = AppMain.aoActInterpolF32( a2S_SUB_ACM2.rot, a2S_SUB_ACM3.rot, rate4 );
    }

    // Token: 0x060016B5 RID: 5813 RVA: 0x000C4B7C File Offset: 0x000C2D7C
    public static void aoActMakeHit( uint key_num, uint frm_num, AppMain.A2S_SUB_KEY[] key_tbl, AppMain.A2S_SUB_HIT[] hit_tbl, int key, float frame, AppMain.AOS_ACT_HITP hit )
    {
        hit.scale_x = 1f;
        hit.scale_y = 1f;
        if ( key < 0 || key_num == 0U )
        {
            hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
            return;
        }
        uint num = 0U;
        float rate;
        if ( !AppMain.aoActGetInterpolInfo( key_tbl, key_num, frm_num, frame, ( uint )key, ref num, out rate ) )
        {
            AppMain.A2S_SUB_HIT a2S_SUB_HIT = hit_tbl[(int)((UIntPtr)key)];
            hit.flag = a2S_SUB_HIT.flag;
            switch ( a2S_SUB_HIT.type )
            {
                case 1U:
                    hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_RECT;
                    hit.rect.Assign( ref a2S_SUB_HIT.rect );
                    return;
                case 2U:
                    hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_CIRCLE;
                    hit.rect.Assign( ref a2S_SUB_HIT.rect );
                    return;
                default:
                    hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
                    return;
            }
        }
        else
        {
            AppMain.A2S_SUB_HIT a2S_SUB_HIT2 = hit_tbl[(int)((UIntPtr)key)];
            AppMain.A2S_SUB_HIT a2S_SUB_HIT3 = hit_tbl[(int)((UIntPtr)num)];
            if ( a2S_SUB_HIT2.type != a2S_SUB_HIT3.type )
            {
                hit.flag = a2S_SUB_HIT2.flag;
                switch ( a2S_SUB_HIT2.type )
                {
                    case 1U:
                        hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_RECT;
                        hit.rect.Assign( ref a2S_SUB_HIT2.rect );
                        return;
                    case 2U:
                        hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_CIRCLE;
                        hit.SetCircle( ref a2S_SUB_HIT2.circle );
                        return;
                    default:
                        hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
                        return;
                }
            }
            else
            {
                rate = AppMain.aoActGetAcceleRate( rate, a2S_SUB_HIT2.hit_accele );
                hit.flag = a2S_SUB_HIT2.flag;
                switch ( a2S_SUB_HIT2.type )
                {
                    case 1U:
                        hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_RECT;
                        hit.rect = new AppMain.AOS_ACT_RECT
                        {
                            left = AppMain.aoActInterpolF32( a2S_SUB_HIT2.rect.left, a2S_SUB_HIT3.rect.left, rate ),
                            top = AppMain.aoActInterpolF32( a2S_SUB_HIT2.rect.top, a2S_SUB_HIT3.rect.top, rate ),
                            right = AppMain.aoActInterpolF32( a2S_SUB_HIT2.rect.right, a2S_SUB_HIT3.rect.right, rate ),
                            bottom = AppMain.aoActInterpolF32( a2S_SUB_HIT2.rect.bottom, a2S_SUB_HIT3.rect.bottom, rate )
                        };
                        return;
                    case 2U:
                        {
                            hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_CIRCLE;
                            AppMain.AOS_ACT_CIRCLE aos_ACT_CIRCLE = default(AppMain.AOS_ACT_CIRCLE);
                            aos_ACT_CIRCLE.center_x = AppMain.aoActInterpolF32( a2S_SUB_HIT2.circle.center_x, a2S_SUB_HIT3.circle.center_x, rate );
                            aos_ACT_CIRCLE.center_y = AppMain.aoActInterpolF32( a2S_SUB_HIT2.circle.center_y, a2S_SUB_HIT3.circle.center_y, rate );
                            aos_ACT_CIRCLE.radius = AppMain.aoActInterpolF32( a2S_SUB_HIT2.circle.radius, a2S_SUB_HIT3.circle.radius, rate );
                            hit.SetCircle( ref aos_ACT_CIRCLE );
                            return;
                        }
                    default:
                        hit.type = AppMain.AOE_ACT_HIT.AOD_ACT_HIT_NONE;
                        return;
                }
            }
        }
    }

    // Token: 0x060016B6 RID: 5814 RVA: 0x000C4E30 File Offset: 0x000C3030
    public static void aoActSerachKey( AppMain.A2S_SUB_KEY[] key, uint key_num, ref float frame, ref int last )
    {
        if ( frame < 1f )
        {
            frame = 0f;
            last = 0;
            return;
        }
        uint num = (uint)frame;
        uint num2;
        if ( last < 0 )
        {
            num2 = key_num / 2U;
            for ( uint num3 = ( key_num + 1U ) / 2U; num3 > 1U; num3 = ( num3 + 1U ) / 2U )
            {
                if ( key[( int )( ( UIntPtr )num2 )].frm <= num )
                {
                    num2 += num3 / 2U;
                }
                else
                {
                    num2 -= num3 / 2U;
                }
            }
            if ( key[( int )( ( UIntPtr )num2 )].frm > num )
            {
                num2 -= 1U;
            }
        }
        else
        {
            num2 = ( uint )last;
            for (; ; )
            {
                if ( key[( int )( ( UIntPtr )num2 )].frm <= num )
                {
                    if ( key[( int )( ( UIntPtr )( num2 + 1U ) )].frm > num )
                    {
                        goto IL_A8;
                    }
                    num2 += 1U;
                }
                else
                {
                    num2 -= 1U;
                }
                if ( num2 <= 0U )
                {
                    break;
                }
                if ( num2 >= key_num - 1U )
                {
                    goto Block_9;
                }
            }
            num2 = 0U;
            goto IL_A8;
            Block_9:
            num2 = key_num - 1U;
        }
        IL_A8:
        last = ( int )num2;
        frame -= key[( int )( ( UIntPtr )num2 )].frm;
    }

    // Token: 0x060016B7 RID: 5815 RVA: 0x000C4EFC File Offset: 0x000C30FC
    public static float aoActGetLoopFrame( float frame, uint len )
    {
        uint num = (uint)frame % len;
        float num2 = frame - (uint)frame;
        return num + num2;
    }

    // Token: 0x060016B8 RID: 5816 RVA: 0x000C4F1C File Offset: 0x000C311C
    public static bool aoActGetInterpolInfo( AppMain.A2S_SUB_KEY[] key_tbl, uint key_num, uint frm_num, float frame, uint key1, ref uint key2, out float rate )
    {
        AppMain.A2S_SUB_KEY a2S_SUB_KEY = key_tbl[(int)key1];
        if ( ( a2S_SUB_KEY.interpol != 1U && a2S_SUB_KEY.interpol != 2U ) || key_num <= 1U )
        {
            rate = 0f;
            return false;
        }
        if ( key1 + 1U < key_num )
        {
            key2 = key1 + 1U;
            AppMain.A2S_SUB_KEY a2S_SUB_KEY2 = key_tbl[(int)(key1 + 1U)];
            rate = frame / ( a2S_SUB_KEY2.frm - a2S_SUB_KEY.frm );
        }
        else
        {
            key2 = 0U;
            rate = frame / ( frm_num - a2S_SUB_KEY.frm );
        }
        return true;
    }

    // Token: 0x060016B9 RID: 5817 RVA: 0x000C4FA4 File Offset: 0x000C31A4
    public static void aoActGetInterpolSpline( AppMain.A2S_SUB_TRS t0, AppMain.A2S_SUB_TRS t1, AppMain.A2S_SUB_TRS t2, AppMain.A2S_SUB_TRS t3, float rate, ref float trans_x, ref float trans_y, ref float trans_z )
    {
        float num = rate * rate;
        float num2 = num * rate;
        float num3 = -0.5f * (num2 + rate) + num;
        float num4 = 1.5f * num2 - 2.5f * num + 1f;
        float num5 = -1.5f * num2 + 2f * num + 0.5f * rate;
        float num6 = 0.5f * (num2 - num);
        trans_x = t0.trs_x * num3 + t1.trs_x * num4 + t2.trs_x * num5 + t3.trs_x * num6;
        trans_y = t0.trs_y * num3 + t1.trs_y * num4 + t2.trs_y * num5 + t3.trs_y * num6;
        trans_z = t0.trs_z * num3 + t1.trs_z * num4 + t2.trs_z * num5 + t3.trs_z * num6;
    }

    // Token: 0x060016BA RID: 5818 RVA: 0x000C507E File Offset: 0x000C327E
    public static float aoActGetAcceleRate( float rate, float accele )
    {
        return rate * accele + rate * rate * ( 1f - accele );
    }

    // Token: 0x060016BB RID: 5819 RVA: 0x000C5090 File Offset: 0x000C3290
    public static AppMain.AOS_SPRITE aoActAllocSprite()
    {
        if ( AppMain.g_ao_act_spr_num >= AppMain.g_ao_act_spr_buf_size )
        {
            return null;
        }
        AppMain.AOS_SPRITE result = AppMain.g_ao_act_spr_ref[(int)((UIntPtr)AppMain.g_ao_act_spr_alloc)];
        AppMain.g_ao_act_spr_alloc += 1U;
        if ( AppMain.g_ao_act_spr_alloc >= AppMain.g_ao_act_spr_buf_size )
        {
            AppMain.g_ao_act_spr_alloc = 0U;
        }
        AppMain.g_ao_act_spr_num += 1U;
        if ( AppMain.g_ao_act_spr_num > AppMain.g_ao_act_spr_peak )
        {
            AppMain.g_ao_act_spr_peak = AppMain.g_ao_act_spr_num;
        }
        return result;
    }

    // Token: 0x060016BC RID: 5820 RVA: 0x000C50FC File Offset: 0x000C32FC
    public static void aoActFreeSprite( AppMain.AOS_SPRITE spr )
    {
        if ( AppMain.g_ao_act_spr_num == 0U )
        {
            return;
        }
        AppMain.AoActSortUnregSprite( spr );
        AppMain.g_ao_act_spr_ref[( int )( ( UIntPtr )AppMain.g_ao_act_spr_free )] = spr;
        AppMain.g_ao_act_spr_free += 1U;
        if ( AppMain.g_ao_act_spr_free >= AppMain.g_ao_act_spr_buf_size )
        {
            AppMain.g_ao_act_spr_free = 0U;
        }
        AppMain.g_ao_act_spr_num -= 1U;
        if ( AppMain.g_ao_act_spr_num > AppMain.g_ao_act_spr_peak )
        {
            AppMain.g_ao_act_spr_peak = AppMain.g_ao_act_spr_num;
        }
    }

    // Token: 0x060016BD RID: 5821 RVA: 0x000C5164 File Offset: 0x000C3364
    public static AppMain.AOS_ACTION aoActAllocAction()
    {
        if ( AppMain.g_ao_act_num >= AppMain.g_ao_act_buf_size )
        {
            return null;
        }
        AppMain.AOS_ACTION result = AppMain.g_ao_act_ref[(int)((UIntPtr)AppMain.g_ao_act_alloc)];
        AppMain.g_ao_act_alloc += 1U;
        if ( AppMain.g_ao_act_alloc >= AppMain.g_ao_act_buf_size )
        {
            AppMain.g_ao_act_alloc = 0U;
        }
        AppMain.g_ao_act_num += 1U;
        if ( AppMain.g_ao_act_num > AppMain.g_ao_act_peak )
        {
            AppMain.g_ao_act_peak = AppMain.g_ao_act_num;
        }
        return result;
    }

    // Token: 0x060016BE RID: 5822 RVA: 0x000C51D0 File Offset: 0x000C33D0
    public static void aoActFreeAction( AppMain.AOS_ACTION act )
    {
        if ( AppMain.g_ao_act_num == 0U )
        {
            return;
        }
        if ( Array.IndexOf<AppMain.AOS_ACTION>( AppMain.g_ao_act_buf, act ) < 0 )
        {
            return;
        }
        AppMain.AoActSortUnregAction( act );
        AppMain.g_ao_act_ref[( int )( ( UIntPtr )AppMain.g_ao_act_free )] = act;
        AppMain.g_ao_act_free += 1U;
        if ( AppMain.g_ao_act_free >= AppMain.g_ao_act_buf_size )
        {
            AppMain.g_ao_act_free = 0U;
        }
        AppMain.g_ao_act_num -= 1U;
        if ( AppMain.g_ao_act_num > AppMain.g_ao_act_peak )
        {
            AppMain.g_ao_act_peak = AppMain.g_ao_act_num;
        }
    }

    // Token: 0x060016BF RID: 5823 RVA: 0x000C5248 File Offset: 0x000C3448
    public static uint aoActGetAmaActState( AppMain.A2S_AMA_ACT act, float frame )
    {
        uint num = 0U;
        if ( act != null )
        {
            while ( act.next != null )
            {
                float num2 = act.frm_num;
                if ( num2 > frame )
                {
                    break;
                }
                frame -= num2;
                act = act.next;
            }
            if ( AppMain.aoActIsAmaActEnd( act, frame ) )
            {
                num |= 1U;
            }
            if ( AppMain.aoActIsAmaTrsEnd( act.mtn, frame ) )
            {
                num |= 2U;
            }
            if ( AppMain.aoActIsAmaMtnEnd( act.mtn, frame ) )
            {
                num |= 4U;
            }
            if ( AppMain.aoActIsAmaAnmEnd( act.anm, frame ) )
            {
                num |= 8U;
            }
            if ( AppMain.aoActIsAmaMatEnd( act.anm, frame ) )
            {
                num |= 16U;
            }
            if ( act.acm != null )
            {
                if ( ( act.acm.flag & 16U ) != 0U )
                {
                    if ( AppMain.aoActIsAmaTrsEnd( act.mtn, frame ) )
                    {
                        num |= 32U;
                    }
                }
                else if ( AppMain.aoActIsAmaAcmTrsEnd( act.acm, frame ) )
                {
                    num |= 32U;
                }
                if ( ( act.acm.flag & 8U ) != 0U )
                {
                    if ( AppMain.aoActIsAmaMtnEnd( act.mtn, frame ) )
                    {
                        num |= 64U;
                    }
                }
                else if ( AppMain.aoActIsAmaAcmMtnEnd( act.acm, frame ) )
                {
                    num |= 64U;
                }
                if ( ( act.acm.flag & 32U ) != 0U )
                {
                    if ( AppMain.aoActIsAmaMatEnd( act.anm, frame ) )
                    {
                        num |= 128U;
                    }
                }
                else if ( AppMain.aoActIsAmaAcmMatEnd( act.acm, frame ) )
                {
                    num |= 128U;
                }
            }
            if ( AppMain.aoActIsAmaUsrEnd( act.usr, frame ) )
            {
                num |= 256U;
            }
            if ( AppMain.aoActIsAmaHitEnd( act.hit, frame ) )
            {
                num |= 512U;
            }
        }
        return num;
    }

    // Token: 0x060016C0 RID: 5824 RVA: 0x000C53BC File Offset: 0x000C35BC
    public static bool aoActIsAmaActEnd( AppMain.A2S_AMA_ACT act, float frame )
    {
        return act == null || act.frm_num <= frame;
    }

    // Token: 0x060016C1 RID: 5825 RVA: 0x000C53CF File Offset: 0x000C35CF
    public static bool aoActIsAmaTrsEnd( AppMain.A2S_AMA_MTN mtn, float frame )
    {
        if ( mtn != null && mtn.trs_key_tbl != null )
        {
            if ( ( mtn.flag & 2U ) != 0U )
            {
                return false;
            }
            if ( mtn.trs_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C2 RID: 5826 RVA: 0x000C53F6 File Offset: 0x000C35F6
    public static bool aoActIsAmaMtnEnd( AppMain.A2S_AMA_MTN mtn, float frame )
    {
        if ( mtn != null && mtn.mtn_key_tbl != null )
        {
            if ( ( mtn.flag & 1U ) != 0U )
            {
                return false;
            }
            if ( mtn.mtn_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C3 RID: 5827 RVA: 0x000C541D File Offset: 0x000C361D
    public static bool aoActIsAmaAnmEnd( AppMain.A2S_AMA_ANM anm, float frame )
    {
        if ( anm != null && anm.anm_key_tbl != null )
        {
            if ( ( anm.flag & 1U ) != 0U )
            {
                return false;
            }
            if ( anm.anm_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C4 RID: 5828 RVA: 0x000C5444 File Offset: 0x000C3644
    public static bool aoActIsAmaMatEnd( AppMain.A2S_AMA_ANM anm, float frame )
    {
        if ( anm != null && anm.mat_key_tbl != null )
        {
            if ( ( anm.flag & 2U ) != 0U )
            {
                return false;
            }
            if ( anm.mat_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C5 RID: 5829 RVA: 0x000C546B File Offset: 0x000C366B
    public static bool aoActIsAmaAcmTrsEnd( AppMain.A2S_AMA_ACM acm, float frame )
    {
        if ( acm != null && acm.trs_key_tbl != null )
        {
            if ( ( acm.flag & 2U ) != 0U )
            {
                return false;
            }
            if ( acm.trs_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C6 RID: 5830 RVA: 0x000C5492 File Offset: 0x000C3692
    public static bool aoActIsAmaAcmMtnEnd( AppMain.A2S_AMA_ACM acm, float frame )
    {
        if ( acm != null && acm.acm_key_tbl != null )
        {
            if ( ( acm.flag & 1U ) != 0U )
            {
                return false;
            }
            if ( acm.acm_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C7 RID: 5831 RVA: 0x000C54B9 File Offset: 0x000C36B9
    public static bool aoActIsAmaAcmMatEnd( AppMain.A2S_AMA_ACM acm, float frame )
    {
        if ( acm != null && acm.mat_key_tbl != null )
        {
            if ( ( acm.flag & 4U ) != 0U )
            {
                return false;
            }
            if ( acm.mat_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C8 RID: 5832 RVA: 0x000C54E0 File Offset: 0x000C36E0
    public static bool aoActIsAmaUsrEnd( AppMain.A2S_AMA_USR usr, float frame )
    {
        if ( usr != null && usr.usr_key_tbl != null )
        {
            if ( ( usr.flag & 1U ) != 0U )
            {
                return false;
            }
            if ( usr.usr_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016C9 RID: 5833 RVA: 0x000C5507 File Offset: 0x000C3707
    public static bool aoActIsAmaHitEnd( AppMain.A2S_AMA_HIT hit, float frame )
    {
        if ( hit != null && hit.hit_key_tbl != null )
        {
            if ( ( hit.flag & 1U ) != 0U )
            {
                return false;
            }
            if ( hit.hit_frm_num > frame )
            {
                return false;
            }
        }
        return true;
    }

    // Token: 0x060016CA RID: 5834 RVA: 0x000C5530 File Offset: 0x000C3730
    public static AppMain.A2S_AMA_ACT aoActGetAmaAct( AppMain.AOS_ACTION act )
    {
        AppMain.A2S_AMA_ACT result = null;
        if ( act == null )
        {
            return null;
        }
        switch ( act.type )
        {
            case AppMain.AOE_ACT_TYPE.AOD_ACT_TYPE_ACTION:
                result = ( AppMain.A2S_AMA_ACT )act.data;
                break;
            case AppMain.AOE_ACT_TYPE.AOD_ACT_TYPE_NODE:
                result = ( ( AppMain.A2S_AMA_NODE )act.data ).act;
                break;
        }
        return result;
    }

    // Token: 0x060016CB RID: 5835 RVA: 0x000C557B File Offset: 0x000C377B
    public static float aoActInterpolF32( float d1, float d2, float rate )
    {
        return d1 * ( 1f - rate ) + d2 * rate;
    }

    // Token: 0x060016CC RID: 5836 RVA: 0x000C558C File Offset: 0x000C378C
    public static AppMain.AOS_ACT_COL aoActInterpolCol( AppMain.A2S_SUB_COL d1, AppMain.A2S_SUB_COL d2, float rate )
    {
        AppMain.AOS_ACT_COL result = default(AppMain.AOS_ACT_COL);
        int num = (int)(255f * rate);
        if ( num < 0 )
        {
            num = 0;
        }
        else if ( num > 255 )
        {
            num = 255;
        }
        int num2 = 255 - num;
        result.r = ( byte )( ( ( int )d1.r * num2 + ( int )d2.r * num ) / 255 );
        result.g = ( byte )( ( ( int )d1.g * num2 + ( int )d2.g * num ) / 255 );
        result.b = ( byte )( ( ( int )d1.b * num2 + ( int )d2.b * num ) / 255 );
        result.a = ( byte )( ( ( int )d1.a * num2 + ( int )d2.a * num ) / 255 );
        return result;
    }

    // Token: 0x060016CD RID: 5837 RVA: 0x000C5650 File Offset: 0x000C3850
    public static void aoActDrawTask( AppMain.AMS_TCB tcb )
    {
        AppMain.AOS_ACT_DRAW aos_ACT_DRAW = (AppMain.AOS_ACT_DRAW)AppMain.amTaskGetWork(tcb);
        AppMain.amDrawPushState();
        AppMain.amDrawInitState();
        AppMain.AoActDrawPre();
        AppMain.nnSetPrimitive3DAlphaFuncGL( 519U, 0.5f );
        AppMain.nnSetPrimitive3DDepthMaskGL( false );
        AppMain.nnSetPrimitive3DDepthFuncGL( 519U );
        for ( uint num = 0U; num < aos_ACT_DRAW.count; num += 1U )
        {
            AppMain.AOS_SPRITE aos_SPRITE = aos_ACT_DRAW.sprite[(int)((UIntPtr)num)];
            uint blend = aos_SPRITE.blend;
            if ( blend == 2U )
            {
                AppMain.nnSetPrimitiveBlend( 0 );
            }
            else
            {
                AppMain.nnSetPrimitiveBlend( 1 );
            }
            bool flag;
            if ( aos_SPRITE.fade.a > 0 )
            {
                AppMain.amDrawSetFogColor( ( float )aos_SPRITE.fade.r / 255f, ( float )aos_SPRITE.fade.g / 255f, ( float )aos_SPRITE.fade.b / 255f );
                float num2 = 2f - (float)aos_SPRITE.fade.a / 255f;
                AppMain.amDrawSetFogRange( num2, num2 + 1f );
                AppMain.amDrawSetFog( 1 );
                flag = true;
            }
            else
            {
                AppMain.amDrawSetFog( 0 );
                flag = false;
            }
            if ( aos_SPRITE.tex_id >= 0 && aos_SPRITE.texlist != null )
            {
                AppMain.nnSetPrimitiveTexNum( aos_SPRITE.texlist, aos_SPRITE.tex_id );
                int uwrap;
                if ( ( aos_SPRITE.clamp & 2U ) != 0U )
                {
                    uwrap = 1;
                }
                else
                {
                    uwrap = 0;
                }
                int vwrap;
                if ( ( aos_SPRITE.clamp & 1U ) != 0U )
                {
                    vwrap = 1;
                }
                else
                {
                    vwrap = 0;
                }
                AppMain.nnSetPrimitiveTexState( 0, 0, uwrap, vwrap );
                int blend2;
                if ( aos_SPRITE.blend == 0U )
                {
                    blend2 = 0;
                }
                else
                {
                    blend2 = 1;
                }
                AppMain.nnBeginDrawPrimitive3D( 4, blend2, 0, 0 );
                AppMain.NNS_PRIM3D_PCT[] array = AppMain.aoActDrawTask_pct;
                AppMain.aoActDrawTask_pct_array.buffer = array;
                AppMain.aoActDrawTask_pct_array.offset = 0;
                do
                {
                    array[0].Tex.u = ( array[1].Tex.u = aos_SPRITE.uv.left );
                    array[2].Tex.u = ( array[3].Tex.u = aos_SPRITE.uv.right );
                    array[0].Tex.v = ( array[2].Tex.v = aos_SPRITE.uv.top );
                    array[1].Tex.v = ( array[3].Tex.v = aos_SPRITE.uv.bottom );
                    array[0].Col = ( uint )( ( int )aos_SPRITE.color.r << 24 | ( int )aos_SPRITE.color.g << 16 | ( int )aos_SPRITE.color.b << 8 | ( int )aos_SPRITE.color.a );
                    array[1].Col = ( array[2].Col = ( array[3].Col = array[0].Col ) );
                    array[0].Pos.x = ( array[1].Pos.x = aos_SPRITE.offset.left );
                    array[2].Pos.x = ( array[3].Pos.x = aos_SPRITE.offset.right );
                    array[0].Pos.y = ( array[2].Pos.y = aos_SPRITE.offset.top );
                    array[1].Pos.y = ( array[3].Pos.y = aos_SPRITE.offset.bottom );
                    array[0].Pos.z = ( array[1].Pos.z = ( array[2].Pos.z = ( array[3].Pos.z = -2f ) ) );
                    if ( aos_SPRITE.rotate != 0f )
                    {
                        float num3;
                        float num4;
                        AppMain.amSinCos( AppMain.NNM_RADtoA32( aos_SPRITE.rotate ), out num3, out num4 );
                        for ( int i = 0; i < 4; i++ )
                        {
                            float x = array[i].Pos.x * num4 - array[i].Pos.y * num3;
                            float y = array[i].Pos.x * num3 + array[i].Pos.y * num4;
                            array[i].Pos.x = x;
                            array[i].Pos.y = y;
                        }
                    }
                    AppMain.NNS_PRIM3D_PCT[] array2 = array;
                    int num5 = 0;
                    array2[num5].Pos.x = array2[num5].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array3 = array;
                    int num6 = 1;
                    array3[num6].Pos.x = array3[num6].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array4 = array;
                    int num7 = 2;
                    array4[num7].Pos.x = array4[num7].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array5 = array;
                    int num8 = 3;
                    array5[num8].Pos.x = array5[num8].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array6 = array;
                    int num9 = 0;
                    array6[num9].Pos.y = array6[num9].Pos.y + aos_SPRITE.center_y;
                    AppMain.NNS_PRIM3D_PCT[] array7 = array;
                    int num10 = 1;
                    array7[num10].Pos.y = array7[num10].Pos.y + aos_SPRITE.center_y;
                    AppMain.NNS_PRIM3D_PCT[] array8 = array;
                    int num11 = 2;
                    array8[num11].Pos.y = array8[num11].Pos.y + aos_SPRITE.center_y;
                    AppMain.NNS_PRIM3D_PCT[] array9 = array;
                    int num12 = 3;
                    array9[num12].Pos.y = array9[num12].Pos.y + aos_SPRITE.center_y;
                    if ( AppMain.SyGetEvtInfo().cur_evt_id >= 3 )
                    {
                        float num13 = array[1].Pos.y - array[0].Pos.y;
                        AppMain.NNS_PRIM3D_PCT[] array10 = array;
                        int num14 = 0;
                        array10[num14].Pos.y = array10[num14].Pos.y * 0.9f;
                        AppMain.NNS_PRIM3D_PCT[] array11 = array;
                        int num15 = 0;
                        array11[num15].Pos.y = array11[num15].Pos.y + 32f;
                        AppMain.NNS_PRIM3D_PCT[] array12 = array;
                        int num16 = 2;
                        array12[num16].Pos.y = array12[num16].Pos.y * 0.9f;
                        AppMain.NNS_PRIM3D_PCT[] array13 = array;
                        int num17 = 2;
                        array13[num17].Pos.y = array13[num17].Pos.y + 32f;
                        array[1].Pos.y = array[0].Pos.y + num13;
                        array[3].Pos.y = array[2].Pos.y + num13;
                    }
                    AppMain.aoActDrawCorW( AppMain.aoActDrawTask_pct_array, 0, 4U, aos_SPRITE.flag );
                    array[5] = array[3];
                    array[4] = array[1];
                    array[3] = array[2];
                    AppMain.nnDrawPrimitive3D( 0, AppMain.aoActDrawTask_pct_array, 6 );
                    if ( num + 1U < aos_ACT_DRAW.count )
                    {
                        AppMain.AOS_SPRITE aos_SPRITE2 = aos_ACT_DRAW.sprite[(int)((UIntPtr)(num + 1U))];
                        if ( aos_SPRITE.blend == aos_SPRITE2.blend && aos_SPRITE.fade.c == aos_SPRITE2.fade.c && aos_SPRITE.texlist == aos_SPRITE2.texlist && aos_SPRITE.tex_id == aos_SPRITE2.tex_id && aos_SPRITE.clamp == aos_SPRITE2.clamp )
                        {
                            aos_SPRITE = aos_SPRITE2;
                            num += 1U;
                        }
                        else
                        {
                            aos_SPRITE = null;
                        }
                    }
                    else
                    {
                        aos_SPRITE = null;
                    }
                }
                while ( aos_SPRITE != null );
                AppMain.nnEndDrawPrimitive3D();
            }
            else
            {
                AppMain.nnSetPrimitiveTexNum( null, -1 );
                int blend3;
                if ( aos_SPRITE.blend == 0U )
                {
                    blend3 = 0;
                }
                else
                {
                    blend3 = 1;
                }
                AppMain.nnBeginDrawPrimitive3D( 2, blend3, 0, 0 );
                AppMain.NNS_PRIM3D_PC[] array14 = AppMain.aoActDrawTask_pc;
                do
                {
                    array14[0].Col = ( uint )( ( int )aos_SPRITE.color.r << 24 | ( int )aos_SPRITE.color.g << 16 | ( int )aos_SPRITE.color.b << 8 | ( int )aos_SPRITE.color.a );
                    array14[1].Col = ( array14[2].Col = ( array14[3].Col = array14[0].Col ) );
                    array14[0].Pos.x = ( array14[1].Pos.x = aos_SPRITE.offset.left );
                    array14[2].Pos.x = ( array14[3].Pos.x = aos_SPRITE.offset.right );
                    array14[0].Pos.y = ( array14[2].Pos.y = aos_SPRITE.offset.top );
                    array14[1].Pos.y = ( array14[3].Pos.y = aos_SPRITE.offset.bottom );
                    array14[0].Pos.z = ( array14[1].Pos.z = ( array14[2].Pos.z = ( array14[3].Pos.z = -2f ) ) );
                    if ( aos_SPRITE.rotate != 0f )
                    {
                        float num18;
                        float num19;
                        AppMain.amSinCos( AppMain.NNM_DEGtoA32( aos_SPRITE.rotate ), out num18, out num19 );
                        for ( int j = 0; j < 4; j++ )
                        {
                            float x2 = array14[j].Pos.x * num19 - array14[j].Pos.y * num18;
                            float y2 = array14[j].Pos.x * num18 + array14[j].Pos.y * num19;
                            array14[j].Pos.x = x2;
                            array14[j].Pos.y = y2;
                        }
                    }
                    AppMain.NNS_PRIM3D_PC[] array15 = array14;
                    int num20 = 0;
                    array15[num20].Pos.x = array15[num20].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PC[] array16 = array14;
                    int num21 = 1;
                    array16[num21].Pos.x = array16[num21].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PC[] array17 = array14;
                    int num22 = 2;
                    array17[num22].Pos.x = array17[num22].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PC[] array18 = array14;
                    int num23 = 3;
                    array18[num23].Pos.x = array18[num23].Pos.x + aos_SPRITE.center_x;
                    AppMain.NNS_PRIM3D_PC[] array19 = array14;
                    int num24 = 0;
                    array19[num24].Pos.y = array19[num24].Pos.y + aos_SPRITE.center_y;
                    AppMain.NNS_PRIM3D_PC[] array20 = array14;
                    int num25 = 1;
                    array20[num25].Pos.y = array20[num25].Pos.y + aos_SPRITE.center_y;
                    AppMain.NNS_PRIM3D_PC[] array21 = array14;
                    int num26 = 2;
                    array21[num26].Pos.y = array21[num26].Pos.y + aos_SPRITE.center_y;
                    AppMain.NNS_PRIM3D_PC[] array22 = array14;
                    int num27 = 3;
                    array22[num27].Pos.y = array22[num27].Pos.y + aos_SPRITE.center_y;
                    float num28 = array14[1].Pos.y - array14[0].Pos.y;
                    AppMain.NNS_PRIM3D_PC[] array23 = array14;
                    int num29 = 0;
                    array23[num29].Pos.y = array23[num29].Pos.y * 0.9f;
                    AppMain.NNS_PRIM3D_PC[] array24 = array14;
                    int num30 = 0;
                    array24[num30].Pos.y = array24[num30].Pos.y + 32f;
                    AppMain.NNS_PRIM3D_PC[] array25 = array14;
                    int num31 = 2;
                    array25[num31].Pos.y = array25[num31].Pos.y * 0.9f;
                    AppMain.NNS_PRIM3D_PC[] array26 = array14;
                    int num32 = 2;
                    array26[num32].Pos.y = array26[num32].Pos.y + 32f;
                    array14[1].Pos.y = array14[0].Pos.y + num28;
                    array14[3].Pos.y = array14[2].Pos.y + num28;
                    AppMain.aoActDrawCorW( array14, 0, 4U, aos_SPRITE.flag );
                    array14[5] = array14[3];
                    array14[4] = array14[1];
                    array14[3] = array14[2];
                    AppMain.nnDrawPrimitive3D( 0, array14, 6 );
                    if ( num + 1U < aos_ACT_DRAW.count )
                    {
                        AppMain.AOS_SPRITE aos_SPRITE2 = aos_ACT_DRAW.sprite[(int)((UIntPtr)(num + 1U))];
                        if ( aos_SPRITE.blend == aos_SPRITE2.blend && aos_SPRITE.fade.c == aos_SPRITE2.fade.c && ( aos_SPRITE2.texlist == null || aos_SPRITE2.tex_id < 0 ) )
                        {
                            aos_SPRITE = aos_SPRITE2;
                            num += 1U;
                        }
                        else
                        {
                            aos_SPRITE = null;
                        }
                    }
                    else
                    {
                        aos_SPRITE = null;
                    }
                }
                while ( aos_SPRITE != null );
                AppMain.nnEndDrawPrimitive3D();
            }
            if ( flag )
            {
                AppMain.amDrawSetFog( 0 );
            }
        }
        AppMain.amDrawPopState();
    }

    // Token: 0x060016CE RID: 5838 RVA: 0x000C6371 File Offset: 0x000C4571
    public static void aoActDrawSprState( AppMain.AOS_SPRITE spr_tbl )
    {
        AppMain.aoActDrawSprState_spr_tbl[0] = spr_tbl;
        AppMain.aoActDrawSprState( AppMain.aoActDrawSprState_spr_tbl, 1U );
    }

    // Token: 0x060016CF RID: 5839 RVA: 0x000C6388 File Offset: 0x000C4588
    public static void aoActDrawSprState( AppMain.AOS_SPRITE[] spr_tbl, uint num )
    {
        uint num3;
        for ( uint num2 = 0U; num2 < num; num2 += num3 )
        {
            AppMain.AOS_SPRITE aos_SPRITE = spr_tbl[(int)((UIntPtr)num2)];
            num3 = 1U;
            uint num4 = num2 + 1U;
            while ( num4 < num )
            {
                AppMain.AOS_SPRITE aos_SPRITE2 = spr_tbl[(int)((UIntPtr)num4)];
                if ( aos_SPRITE.blend != aos_SPRITE2.blend || aos_SPRITE.fade.c != aos_SPRITE2.fade.c || aos_SPRITE.texlist != aos_SPRITE2.texlist || aos_SPRITE.tex_id != aos_SPRITE2.tex_id || aos_SPRITE.clamp != aos_SPRITE2.clamp )
                {
                    break;
                }
                num4 += 1U;
                num3 += 1U;
            }
            AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
            if ( aos_SPRITE.fade.a > 0 )
            {
                AppMain.amDrawSetFogColor( AppMain.g_ao_act_sys_draw_state, ( float )aos_SPRITE.fade.r / 255f, ( float )aos_SPRITE.fade.g / 255f, ( float )aos_SPRITE.fade.b / 255f );
                float num5 = 2f - (float)aos_SPRITE.fade.a / 255f;
                AppMain.amDrawSetFogRange( AppMain.g_ao_act_sys_draw_state, num5, num5 + 1f );
                AppMain.amDrawSetFog( AppMain.g_ao_act_sys_draw_state, 1 );
            }
            else
            {
                AppMain.amDrawSetFog( AppMain.g_ao_act_sys_draw_state, 0 );
            }
            ams_PARAM_DRAW_PRIMITIVE.mtx = null;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6U * num3 );
            if ( aos_SPRITE.blend == 0U )
            {
                ams_PARAM_DRAW_PRIMITIVE.ablend = 0;
            }
            else
            {
                ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
            }
            ams_PARAM_DRAW_PRIMITIVE.sortZ = 0f;
            ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
            ams_PARAM_DRAW_PRIMITIVE.bldDst = 771;
            ams_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
            ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
            ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
            ams_PARAM_DRAW_PRIMITIVE.zTest = 0;
            ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
            if ( aos_SPRITE.tex_id >= 0 && aos_SPRITE.texlist != null )
            {
                ams_PARAM_DRAW_PRIMITIVE.texlist = aos_SPRITE.texlist;
                ams_PARAM_DRAW_PRIMITIVE.texId = aos_SPRITE.tex_id;
                if ( ( aos_SPRITE.clamp & 2U ) != 0U )
                {
                    ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
                }
                else
                {
                    ams_PARAM_DRAW_PRIMITIVE.uwrap = 0;
                }
                if ( ( aos_SPRITE.clamp & 1U ) != 0U )
                {
                    ams_PARAM_DRAW_PRIMITIVE.vwrap = 1;
                }
                else
                {
                    ams_PARAM_DRAW_PRIMITIVE.vwrap = 0;
                }
                ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( ( int )( 6U * num3 ) );
                AppMain.NNS_PRIM3D_PCT[] buffer = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
                int offset = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
                ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
                int num6 = 0;
                while ( ( long )num6 < ( long )( ( ulong )num3 ) )
                {
                    AppMain.AOS_SPRITE aos_SPRITE3 = spr_tbl[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num6)))))];
                    int num7 = offset + 6 * num6;
                    buffer[num7].Tex.u = ( buffer[num7 + 1].Tex.u = aos_SPRITE3.uv.left );
                    buffer[num7 + 2].Tex.u = ( buffer[num7 + 3].Tex.u = aos_SPRITE3.uv.right );
                    buffer[num7].Tex.v = ( buffer[num7 + 2].Tex.v = aos_SPRITE3.uv.top );
                    buffer[num7 + 1].Tex.v = ( buffer[num7 + 3].Tex.v = aos_SPRITE3.uv.bottom );
                    buffer[num7].Col = ( uint )( ( int )aos_SPRITE3.color.r << 24 | ( int )aos_SPRITE3.color.g << 16 | ( int )aos_SPRITE3.color.b << 8 | ( int )aos_SPRITE3.color.a );
                    buffer[num7 + 1].Col = ( buffer[num7 + 2].Col = ( buffer[num7 + 3].Col = buffer[num7].Col ) );
                    buffer[num7].Pos.x = ( buffer[num7 + 1].Pos.x = aos_SPRITE3.offset.left );
                    buffer[num7 + 2].Pos.x = ( buffer[num7 + 3].Pos.x = aos_SPRITE3.offset.right );
                    buffer[num7].Pos.y = ( buffer[num7 + 2].Pos.y = aos_SPRITE3.offset.top );
                    buffer[num7 + 1].Pos.y = ( buffer[num7 + 3].Pos.y = aos_SPRITE3.offset.bottom );
                    buffer[num7].Pos.z = ( buffer[num7 + 1].Pos.z = ( buffer[num7 + 2].Pos.z = ( buffer[num7 + 3].Pos.z = -2f ) ) );
                    if ( aos_SPRITE3.rotate != 0f )
                    {
                        float num8;
                        float num9;
                        AppMain.amSinCos( AppMain.NNM_DEGtoA32( aos_SPRITE3.rotate ), out num8, out num9 );
                        for ( int i = 0; i < 4; i++ )
                        {
                            int num10 = num7 + i;
                            float x = buffer[num10].Pos.x * num9 - buffer[num10].Pos.y * num8;
                            float y = buffer[num10].Pos.x * num8 + buffer[num10].Pos.y * num9;
                            buffer[num10].Pos.x = x;
                            buffer[num10].Pos.y = y;
                        }
                    }
                    AppMain.NNS_PRIM3D_PCT[] array = buffer;
                    int num11 = num7;
                    array[num11].Pos.x = array[num11].Pos.x + aos_SPRITE3.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array2 = buffer;
                    int num12 = num7 + 1;
                    array2[num12].Pos.x = array2[num12].Pos.x + aos_SPRITE3.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array3 = buffer;
                    int num13 = num7 + 2;
                    array3[num13].Pos.x = array3[num13].Pos.x + aos_SPRITE3.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array4 = buffer;
                    int num14 = num7 + 3;
                    array4[num14].Pos.x = array4[num14].Pos.x + aos_SPRITE3.center_x;
                    AppMain.NNS_PRIM3D_PCT[] array5 = buffer;
                    int num15 = num7;
                    array5[num15].Pos.y = array5[num15].Pos.y + aos_SPRITE3.center_y;
                    AppMain.NNS_PRIM3D_PCT[] array6 = buffer;
                    int num16 = num7 + 1;
                    array6[num16].Pos.y = array6[num16].Pos.y + aos_SPRITE3.center_y;
                    AppMain.NNS_PRIM3D_PCT[] array7 = buffer;
                    int num17 = num7 + 2;
                    array7[num17].Pos.y = array7[num17].Pos.y + aos_SPRITE3.center_y;
                    AppMain.NNS_PRIM3D_PCT[] array8 = buffer;
                    int num18 = num7 + 3;
                    array8[num18].Pos.y = array8[num18].Pos.y + aos_SPRITE3.center_y;
                    float num19 = buffer[num7 + 1].Pos.y - buffer[num7].Pos.y;
                    AppMain.NNS_PRIM3D_PCT[] array9 = buffer;
                    int num20 = num7;
                    array9[num20].Pos.y = array9[num20].Pos.y * 0.9f;
                    AppMain.NNS_PRIM3D_PCT[] array10 = buffer;
                    int num21 = num7;
                    array10[num21].Pos.y = array10[num21].Pos.y + 32f;
                    AppMain.NNS_PRIM3D_PCT[] array11 = buffer;
                    int num22 = num7 + 2;
                    array11[num22].Pos.y = array11[num22].Pos.y * 0.9f;
                    AppMain.NNS_PRIM3D_PCT[] array12 = buffer;
                    int num23 = num7 + 2;
                    array12[num23].Pos.y = array12[num23].Pos.y + 32f;
                    buffer[num7 + 1].Pos.y = buffer[num7].Pos.y + num19;
                    buffer[num7 + 3].Pos.y = buffer[num7 + 2].Pos.y + num19;
                    AppMain.aoActDrawCorW( ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D, num7 - offset, 4U, aos_SPRITE3.flag );
                    buffer[num7 + 5] = buffer[num7 + 3];
                    buffer[num7 + 4] = buffer[num7 + 1];
                    buffer[num7 + 3] = buffer[num7 + 2];
                    num6++;
                }
            }
            else
            {
                ams_PARAM_DRAW_PRIMITIVE.texlist = null;
                ams_PARAM_DRAW_PRIMITIVE.texId = -1;
                AppMain.NNS_PRIM3D_PC[] array13 = AppMain.amDrawAlloc_NNS_PRIM3D_PC((int)(6U * num3));
                ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = array13;
                ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
                int num24 = 0;
                while ( ( long )num24 < ( long )( ( ulong )num3 ) )
                {
                    AppMain.AOS_SPRITE aos_SPRITE4 = spr_tbl[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num24)))))];
                    int num25 = 6 * num24;
                    array13[num25].Col = ( uint )( ( int )aos_SPRITE4.color.r << 24 | ( int )aos_SPRITE4.color.g << 16 | ( int )aos_SPRITE4.color.b << 8 | ( int )aos_SPRITE4.color.a );
                    array13[num25 + 1].Col = ( array13[num25 + 2].Col = ( array13[num25 + 3].Col = array13[num25].Col ) );
                    array13[num25].Pos.x = ( array13[num25 + 1].Pos.x = aos_SPRITE4.offset.left );
                    array13[num25 + 2].Pos.x = ( array13[num25 + 3].Pos.x = aos_SPRITE4.offset.right );
                    array13[num25].Pos.y = ( array13[num25 + 2].Pos.y = aos_SPRITE4.offset.top );
                    array13[num25 + 1].Pos.y = ( array13[num25 + 3].Pos.y = aos_SPRITE4.offset.bottom );
                    array13[num25].Pos.z = ( array13[num25 + 1].Pos.z = ( array13[num25 + 2].Pos.z = ( array13[num25 + 3].Pos.z = -2f ) ) );
                    if ( aos_SPRITE4.rotate != 0f )
                    {
                        float num26;
                        float num27;
                        AppMain.amSinCos( AppMain.NNM_DEGtoA32( aos_SPRITE4.rotate ), out num26, out num27 );
                        for ( int j = 0; j < 4; j++ )
                        {
                            int num28 = num25 + j;
                            float x2 = array13[num28].Pos.x * num27 - array13[num28].Pos.y * num26;
                            float y2 = array13[num28].Pos.x * num26 + array13[num28].Pos.y * num27;
                            array13[num28].Pos.x = x2;
                            array13[num28].Pos.y = y2;
                        }
                    }
                    AppMain.NNS_PRIM3D_PC[] array14 = array13;
                    int num29 = num25;
                    array14[num29].Pos.x = array14[num29].Pos.x + aos_SPRITE4.center_x;
                    AppMain.NNS_PRIM3D_PC[] array15 = array13;
                    int num30 = num25 + 1;
                    array15[num30].Pos.x = array15[num30].Pos.x + aos_SPRITE4.center_x;
                    AppMain.NNS_PRIM3D_PC[] array16 = array13;
                    int num31 = num25 + 2;
                    array16[num31].Pos.x = array16[num31].Pos.x + aos_SPRITE4.center_x;
                    AppMain.NNS_PRIM3D_PC[] array17 = array13;
                    int num32 = num25 + 3;
                    array17[num32].Pos.x = array17[num32].Pos.x + aos_SPRITE4.center_x;
                    AppMain.NNS_PRIM3D_PC[] array18 = array13;
                    int num33 = num25;
                    array18[num33].Pos.y = array18[num33].Pos.y + aos_SPRITE4.center_y;
                    AppMain.NNS_PRIM3D_PC[] array19 = array13;
                    int num34 = num25 + 1;
                    array19[num34].Pos.y = array19[num34].Pos.y + aos_SPRITE4.center_y;
                    AppMain.NNS_PRIM3D_PC[] array20 = array13;
                    int num35 = num25 + 2;
                    array20[num35].Pos.y = array20[num35].Pos.y + aos_SPRITE4.center_y;
                    AppMain.NNS_PRIM3D_PC[] array21 = array13;
                    int num36 = num25 + 3;
                    array21[num36].Pos.y = array21[num36].Pos.y + aos_SPRITE4.center_y;
                    float num37 = array13[num25 + 1].Pos.y - array13[num25].Pos.y;
                    AppMain.NNS_PRIM3D_PC[] array22 = array13;
                    int num38 = num25;
                    array22[num38].Pos.y = array22[num38].Pos.y * 0.9f;
                    AppMain.NNS_PRIM3D_PC[] array23 = array13;
                    int num39 = num25;
                    array23[num39].Pos.y = array23[num39].Pos.y + 32f;
                    AppMain.NNS_PRIM3D_PC[] array24 = array13;
                    int num40 = num25 + 2;
                    array24[num40].Pos.y = array24[num40].Pos.y * 0.9f;
                    AppMain.NNS_PRIM3D_PC[] array25 = array13;
                    int num41 = num25 + 2;
                    array25[num41].Pos.y = array25[num41].Pos.y + 32f;
                    array13[num25 + 1].Pos.y = array13[num25].Pos.y + num37;
                    array13[num25 + 3].Pos.y = array13[num25 + 2].Pos.y + num37;
                    AppMain.aoActDrawCorW( array13, num25, 4U, aos_SPRITE4.flag );
                    array13[num25 + 5] = array13[num25 + 3];
                    array13[num25 + 4] = array13[num25 + 1];
                    array13[num25 + 3] = array13[num25 + 2];
                    num24++;
                }
            }
            AppMain.amDrawPrimitive3D( AppMain.g_ao_act_sys_draw_state, ams_PARAM_DRAW_PRIMITIVE );
            AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
        }
        AppMain.amDrawSetFog( AppMain.g_ao_act_sys_draw_state, 0 );
    }

    // Token: 0x060016D0 RID: 5840 RVA: 0x000C71D0 File Offset: 0x000C53D0
    public static void aoActDrawSortState()
    {
        if ( AppMain.g_ao_act_sort_num > 0U )
        {
            if ( AppMain.aoActDrawSortState_spr_tbl == null || ( long )AppMain.aoActDrawSortState_spr_tbl.Length < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
            {
                AppMain.aoActDrawSortState_spr_tbl = new AppMain.AOS_SPRITE[AppMain.g_ao_act_sort_num];
            }
            int num = 0;
            while ( ( long )num < ( long )( ( ulong )AppMain.g_ao_act_sort_num ) )
            {
                AppMain.aoActDrawSortState_spr_tbl[num] = AppMain.g_ao_act_sort_buf[num].sprite;
                num++;
            }
            AppMain.aoActDrawSprState( AppMain.aoActDrawSortState_spr_tbl, AppMain.g_ao_act_sort_num );
        }
    }

    // Token: 0x060016D1 RID: 5841 RVA: 0x000C7244 File Offset: 0x000C5444
    public static void aoActDrawCorW( AppMain.ArrayPointer<AppMain.NNS_PRIM3D_PN> v, uint vnum, uint flag )
    {
        switch ( flag & 3U )
        {
            case 0U:
                AppMain.AoActDrawCorWide( v, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE );
                return;
            case 1U:
                AppMain.AoActDrawCorWide( v, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
                return;
            case 2U:
                if ( ( flag & 16U ) != 0U )
                {
                    AppMain.AoActDrawCorWide( v, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S );
                    return;
                }
                AppMain.AoActDrawCorWide( v, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT );
                return;
            case 3U:
                if ( ( flag & 16U ) != 0U )
                {
                    AppMain.AoActDrawCorWide( v, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S );
                    return;
                }
                AppMain.AoActDrawCorWide( v, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT );
                return;
            default:
                return;
        }
    }

    // Token: 0x060016D2 RID: 5842 RVA: 0x000C72B0 File Offset: 0x000C54B0
    public static void aoActDrawCorW( AppMain.NNS_PRIM3D_PC[] v, int i0, uint vnum, uint flag )
    {
        switch ( flag & 3U )
        {
            case 0U:
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE );
                return;
            case 1U:
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
                return;
            case 2U:
                if ( ( flag & 16U ) != 0U )
                {
                    AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S );
                    return;
                }
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT );
                return;
            case 3U:
                if ( ( flag & 16U ) != 0U )
                {
                    AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S );
                    return;
                }
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT );
                return;
            default:
                return;
        }
    }

    // Token: 0x060016D3 RID: 5843 RVA: 0x000C7320 File Offset: 0x000C5520
    public static void aoActDrawCorW( AppMain.NNS_PRIM3D_PCT_ARRAY v, int i0, uint vnum, uint flag )
    {
        switch ( flag & 3U )
        {
            case 0U:
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_NONE );
                return;
            case 1U:
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_CENTER );
                return;
            case 2U:
                if ( ( flag & 16U ) != 0U )
                {
                    AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT_S );
                    return;
                }
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_LEFT );
                return;
            case 3U:
                if ( ( flag & 16U ) != 0U )
                {
                    AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT_S );
                    return;
                }
                AppMain.AoActDrawCorWide( v, i0, vnum, AppMain.AOE_ACT_CORW.AOD_ACT_CORW_RIGHT );
                return;
            default:
                return;
        }
    }
}