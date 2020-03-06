using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002DF RID: 735
    public class GMS_BS_CMN_CNM_PARAM
    {
        // Token: 0x04005C72 RID: 23666
        public ushort reg_node_cnt;
    }

    // Token: 0x020002E0 RID: 736
    public class GMS_BS_CMN_DMG_FLICKER_WORK : AppMain.IClearable
    {
        // Token: 0x060024E8 RID: 9448 RVA: 0x0014B5C8 File Offset: 0x001497C8
        public void Clear()
        {
            this.is_active = 0;
            this.cycles = ( this.interval_timer = 0U );
            this.cur_angle = 0;
            this.radius = 0f;
        }

        // Token: 0x04005C73 RID: 23667
        public int is_active;

        // Token: 0x04005C74 RID: 23668
        public uint cycles;

        // Token: 0x04005C75 RID: 23669
        public uint interval_timer;

        // Token: 0x04005C76 RID: 23670
        public int cur_angle;

        // Token: 0x04005C77 RID: 23671
        public float radius;
    }

    // Token: 0x020002E1 RID: 737
    public class GMS_CMN_FLASH_SCR_WORK : AppMain.IClearable
    {
        // Token: 0x060024EA RID: 9450 RVA: 0x0014B608 File Offset: 0x00149808
        public void Clear()
        {
            this.fade_obj_work = null;
            this.active_flag = 0U;
            this.duration_frame = ( this.fi_frame = ( this.duration_timer = 0f ) );
        }

        // Token: 0x04005C78 RID: 23672
        public AppMain.GMS_FADE_OBJ_WORK fade_obj_work;

        // Token: 0x04005C79 RID: 23673
        public uint active_flag;

        // Token: 0x04005C7A RID: 23674
        public float duration_frame;

        // Token: 0x04005C7B RID: 23675
        public float fi_frame;

        // Token: 0x04005C7C RID: 23676
        public float duration_timer;
    }

    // Token: 0x020002E2 RID: 738
    public class GMS_BS_CMN_DELAY_SEARCH_WORK
    {
        // Token: 0x04005C7D RID: 23677
        public AppMain.VecFx32[] pos_hist_buf;

        // Token: 0x04005C7E RID: 23678
        public int cur_point;

        // Token: 0x04005C7F RID: 23679
        public int hist_num;

        // Token: 0x04005C80 RID: 23680
        public AppMain.OBS_OBJECT_WORK targ_obj;

        // Token: 0x04005C81 RID: 23681
        public int record_cnt;
    }

    // Token: 0x020002E3 RID: 739
    public class GMS_BS_CMN_BMCB_LINK : AppMain.IClearable
    {
        // Token: 0x060024ED RID: 9453 RVA: 0x0014B650 File Offset: 0x00149850
        public void Clear()
        {
            this.next = ( this.prev = null );
            this.bmcb_func = null;
            this.bmcb_param = null;
        }

        // Token: 0x04005C82 RID: 23682
        public AppMain.GMS_BS_CMN_BMCB_LINK next;

        // Token: 0x04005C83 RID: 23683
        public AppMain.GMS_BS_CMN_BMCB_LINK prev;

        // Token: 0x04005C84 RID: 23684
        public AppMain.MPP_VOID_MOTION_NSSOBJECT_OBJECT bmcb_func;

        // Token: 0x04005C85 RID: 23685
        public object bmcb_param;
    }

    // Token: 0x020002E4 RID: 740
    public class GMS_BS_CMN_BMCB_MGR : AppMain.IClearable
    {
        // Token: 0x060024EF RID: 9455 RVA: 0x0014B683 File Offset: 0x00149883
        public void Clear()
        {
            this.bmcb_head.Clear();
            this.bmcb_tail.Clear();
        }

        // Token: 0x04005C86 RID: 23686
        public readonly AppMain.GMS_BS_CMN_BMCB_LINK bmcb_head = new AppMain.GMS_BS_CMN_BMCB_LINK();

        // Token: 0x04005C87 RID: 23687
        public readonly AppMain.GMS_BS_CMN_BMCB_LINK bmcb_tail = new AppMain.GMS_BS_CMN_BMCB_LINK();
    }

    // Token: 0x020002E5 RID: 741
    public class GMS_BS_CMN_CNM_NODE_INFO
    {
        // Token: 0x060024F1 RID: 9457 RVA: 0x0014B6BC File Offset: 0x001498BC
        public void Assign( AppMain.GMS_BS_CMN_CNM_NODE_INFO p )
        {
            this.node_w_mtx.Assign( p.node_w_mtx );
            this.node_index = p.node_index;
            this.enable = p.enable;
            this.mode = p.mode;
            this.flag = p.flag;
        }

        // Token: 0x04005C88 RID: 23688
        public readonly AppMain.NNS_MATRIX node_w_mtx = new AppMain.NNS_MATRIX();

        // Token: 0x04005C89 RID: 23689
        public int node_index;

        // Token: 0x04005C8A RID: 23690
        public int enable;

        // Token: 0x04005C8B RID: 23691
        public uint mode;

        // Token: 0x04005C8C RID: 23692
        public uint flag;
    }

    // Token: 0x020002E6 RID: 742
    public class GMS_BS_CMN_CNM_MGR_WORK
    {
        // Token: 0x04005C8D RID: 23693
        public ushort reg_node_cnt;

        // Token: 0x04005C8E RID: 23694
        public ushort reg_node_max;

        // Token: 0x04005C8F RID: 23695
        public AppMain.GMS_BS_CMN_CNM_NODE_INFO[] node_info_list;
    }

    // Token: 0x020002E7 RID: 743
    public class GMS_BS_CMN_NODE_CTRL_OBJECT : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024F4 RID: 9460 RVA: 0x0014B726 File Offset: 0x00149926
        public GMS_BS_CMN_NODE_CTRL_OBJECT()
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
        }

        // Token: 0x060024F5 RID: 9461 RVA: 0x0014B750 File Offset: 0x00149950
        public GMS_BS_CMN_NODE_CTRL_OBJECT( object holder )
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
            this.m_pHolder = holder;
        }

        // Token: 0x060024F6 RID: 9462 RVA: 0x0014B781 File Offset: 0x00149981
        public static explicit operator AppMain.GMS_BOSS5_SCT_PART_NDC_WORK( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT p )
        {
            return ( AppMain.GMS_BOSS5_SCT_PART_NDC_WORK )p.m_pHolder;
        }

        // Token: 0x060024F7 RID: 9463 RVA: 0x0014B78E File Offset: 0x0014998E
        public static explicit operator AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT p )
        {
            return ( AppMain.GMS_BOSS2_EFFECT_SCATTER_WORK )p.m_pHolder;
        }

        // Token: 0x060024F8 RID: 9464 RVA: 0x0014B79B File Offset: 0x0014999B
        public static explicit operator AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT p )
        {
            return ( AppMain.GMS_BOSS1_EFF_SCT_PART_NDC_WORK )p.m_pHolder;
        }

        // Token: 0x060024F9 RID: 9465 RVA: 0x0014B7A8 File Offset: 0x001499A8
        public static explicit operator AppMain.GMS_EFFECT_COM_WORK( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT p )
        {
            return ( AppMain.GMS_EFFECT_COM_WORK )p.efct_com.obj_work;
        }

        // Token: 0x060024FA RID: 9466 RVA: 0x0014B7BA File Offset: 0x001499BA
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_com.obj_work;
        }

        // Token: 0x060024FB RID: 9467 RVA: 0x0014B7C7 File Offset: 0x001499C7
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT work )
        {
            return work.efct_com.obj_work;
        }

        // Token: 0x04005C90 RID: 23696
        public object m_pHolder;

        // Token: 0x04005C91 RID: 23697
        public readonly AppMain.GMS_EFFECT_COM_WORK efct_com;

        // Token: 0x04005C92 RID: 23698
        public AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work;

        // Token: 0x04005C93 RID: 23699
        public int cnm_reg_id;

        // Token: 0x04005C94 RID: 23700
        public AppMain.GMS_BS_CMN_SNM_WORK snm_work;

        // Token: 0x04005C95 RID: 23701
        public int snm_reg_id;

        // Token: 0x04005C96 RID: 23702
        public AppMain.NNS_QUATERNION user_quat;

        // Token: 0x04005C97 RID: 23703
        public readonly AppMain.NNS_VECTOR user_ofst = new AppMain.NNS_VECTOR();

        // Token: 0x04005C98 RID: 23704
        public uint user_timer;

        // Token: 0x04005C99 RID: 23705
        public readonly AppMain.NNS_MATRIX w_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005C9A RID: 23706
        public int is_enable;

        // Token: 0x04005C9B RID: 23707
        public AppMain.MPP_VOID_OBS_OBJECT_WORK proc_update;
    }

    // Token: 0x020002E8 RID: 744
    public class GMS_BS_CMN_SNM_NODE_INFO
    {
        // Token: 0x04005C9C RID: 23708
        public int node_index;

        // Token: 0x04005C9D RID: 23709
        public uint[] reserved = new uint[3];

        // Token: 0x04005C9E RID: 23710
        public readonly AppMain.NNS_MATRIX node_w_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
    }

    // Token: 0x020002E9 RID: 745
    public class GMS_BS_CMN_SNM_WORK
    {
        // Token: 0x04005C9F RID: 23711
        public readonly AppMain.GMS_BS_CMN_BMCB_LINK bmcb_link = new AppMain.GMS_BS_CMN_BMCB_LINK();

        // Token: 0x04005CA0 RID: 23712
        public ushort reg_node_cnt;

        // Token: 0x04005CA1 RID: 23713
        public ushort reg_node_max;

        // Token: 0x04005CA2 RID: 23714
        public uint[] reserved = new uint[3];

        // Token: 0x04005CA3 RID: 23715
        public AppMain.GMS_BS_CMN_SNM_NODE_INFO[] node_info_list;
    }

    // Token: 0x0600142C RID: 5164 RVA: 0x000B2B55 File Offset: 0x000B0D55
    private static AppMain.OBS_OBJECT_WORK GmBsCmnGetPlayerObj()
    {
        return ( AppMain.OBS_OBJECT_WORK )AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )];
    }

    // Token: 0x0600142D RID: 5165 RVA: 0x000B2B69 File Offset: 0x000B0D69
    private static int GmBsCmnIsFinalZoneType( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.GsGetMainSysInfo().stage_id == 16 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x0600142E RID: 5166 RVA: 0x000B2B7C File Offset: 0x000B0D7C
    private static void GmBsCmnSetAction( AppMain.OBS_OBJECT_WORK obj_work, int act_id, int is_repeat )
    {
        AppMain.GmBsCmnSetAction( obj_work, act_id, is_repeat, 0 );
    }

    // Token: 0x0600142F RID: 5167 RVA: 0x000B2B87 File Offset: 0x000B0D87
    private static void GmBsCmnSetAction( AppMain.OBS_OBJECT_WORK obj_work, int act_id, int is_repeat, int is_blend )
    {
        if ( is_blend != 0 )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, act_id );
        }
        else
        {
            AppMain.ObjDrawObjectActionSet( obj_work, act_id );
        }
        if ( is_repeat != 0 )
        {
            obj_work.disp_flag |= 4U;
            return;
        }
        obj_work.disp_flag &= 4294967291U;
    }

    // Token: 0x06001430 RID: 5168 RVA: 0x000B2BBD File Offset: 0x000B0DBD
    private static int GmBsCmnIsActionEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001431 RID: 5169 RVA: 0x000B2BCC File Offset: 0x000B0DCC
    private static void GmBsCmnSetObjSpd( AppMain.OBS_OBJECT_WORK obj_work, int spd_x, int spd_y )
    {
        AppMain.GmBsCmnSetObjSpd( obj_work, spd_x, spd_y, 0 );
    }

    // Token: 0x06001432 RID: 5170 RVA: 0x000B2BD7 File Offset: 0x000B0DD7
    private static void GmBsCmnSetObjSpd( AppMain.OBS_OBJECT_WORK obj_work, int spd_x, int spd_y, int spd_z )
    {
        obj_work.spd.x = spd_x;
        obj_work.spd.y = spd_y;
        obj_work.spd.z = spd_z;
    }

    // Token: 0x06001433 RID: 5171 RVA: 0x000B2C00 File Offset: 0x000B0E00
    private static void GmBsCmnSetObjSpdZero( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.x = ( obj_work.spd.y = ( obj_work.spd.z = 0 ) );
        obj_work.spd_add.x = ( obj_work.spd_add.y = ( obj_work.spd_add.z = 0 ) );
    }

    // Token: 0x06001434 RID: 5172 RVA: 0x000B2C5D File Offset: 0x000B0E5D
    private static int GmBsCmnIsActionEndPrecisely( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            return 1;
        }
        return AppMain.gmBsCmnCheckActionFrameOverrunOnNextUpdate( obj_work );
    }

    // Token: 0x06001435 RID: 5173 RVA: 0x000B2C74 File Offset: 0x000B0E74
    private static int GmBsCmnIsActionEndFlexibly( AppMain.OBS_OBJECT_WORK obj_work, float allow_ratio )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        float num = obj_3d.speed[0] * AppMain.FX_FX32_TO_F32(AppMain.g_obj.speed);
        float num2 = 0f;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            return 1;
        }
        AppMain.gmBsCmnCheckActionFrameOverrunOnNextUpdate( obj_work, ref num2 );
        if ( num2 > num * allow_ratio )
        {
            return AppMain.GmBsCmnIsActionEndPrecisely( obj_work );
        }
        return AppMain.GmBsCmnIsActionEnd( obj_work );
    }

    // Token: 0x06001436 RID: 5174 RVA: 0x000B2CD0 File Offset: 0x000B0ED0
    private static void GmBsCmnSetEfctAtkVsPly( AppMain.GMS_EFFECT_COM_WORK efct_com, short view_out_ofst )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)efct_com;
        obs_OBJECT_WORK.flag &= 4294967277U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.view_out_ofst = view_out_ofst;
        AppMain.GmEffectRectInit( efct_com, AppMain.gm_bs_cmn_efct_atk_flag_tbl, AppMain.gm_bs_cmn_efct_def_flag_tbl, 1, 1 );
    }

    // Token: 0x06001437 RID: 5175 RVA: 0x000B2D20 File Offset: 0x000B0F20
    private static int GmBsCmnCheckRectMajorOverlapH( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect, ref int center_ofst_x )
    {
        int num = 0;
        int num2 = 0;
        ushort num3 = 0;
        ushort num4 = 0;
        int result = 0;
        AppMain.ObjRectLTBSet( my_rect, ref num, default( int? ), default( int? ) );
        AppMain.ObjRectWHDSet( my_rect, ref num3, default( ushort? ), default( ushort? ) );
        int num5 = num + (int)num3;
        int num6 = num + (num3 >> 1);
        AppMain.ObjRectLTBSet( your_rect, ref num2, default( int? ), default( int? ) );
        AppMain.ObjRectWHDSet( your_rect, ref num4, default( ushort? ), default( ushort? ) );
        int num7 = num2 + (int)num4;
        int num8 = num2 + (num4 >> 1);
        if ( num6 < num8 )
        {
            if ( num5 >= num8 || num6 >= num2 )
            {
                result = 1;
            }
        }
        else if ( num8 < num6 )
        {
            if ( num7 >= num6 || num8 >= num )
            {
                result = 1;
            }
        }
        else
        {
            result = 1;
        }
        if ( center_ofst_x != 0 )
        {
            center_ofst_x = num8 - num6 << 12;
        }
        return result;
    }

    // Token: 0x06001438 RID: 5176 RVA: 0x000B2E08 File Offset: 0x000B1008
    private static int GmBsCmnCheckRectMajorOverlapV( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect, ref int center_ofst_y )
    {
        int num = 0;
        int num2 = 0;
        ushort num3 = 0;
        int result = 0;
        AppMain.ObjRectLTBSet( my_rect, default( int? ), ref num, default( int? ) );
        AppMain.ObjRectWHDSet( my_rect, default( ushort? ), ref num3, default( ushort? ) );
        int num4 = num + (int)num3;
        int num5 = num + (num3 >> 1);
        AppMain.ObjRectLTBSet( your_rect, default( int? ), ref num2, default( int? ) );
        ushort num6 = 0;
        AppMain.ObjRectWHDSet( your_rect, default( ushort? ), ref num6, default( ushort? ) );
        ushort num7 = num6;
        int num8 = num2 + (int)num7;
        int num9 = num2 + (num7 >> 1);
        if ( num5 < num9 )
        {
            if ( num4 >= num9 || num5 >= num2 )
            {
                result = 1;
            }
        }
        else if ( num9 < num5 )
        {
            if ( num8 >= num5 || num9 >= num )
            {
                result = 1;
            }
        }
        else
        {
            result = 1;
        }
        if ( center_ofst_y != 0 )
        {
            center_ofst_y = num9 - num5 << 12;
        }
        return result;
    }

    // Token: 0x06001439 RID: 5177 RVA: 0x000B2EEC File Offset: 0x000B10EC
    private uint GmBsCmnCheckRectHitSideHFirst( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        int num = 0;
        int num2 = 0;
        int num3 = AppMain.GmBsCmnCheckRectMajorOverlapH(my_rect, your_rect, ref num);
        AppMain.GmBsCmnCheckRectMajorOverlapV( my_rect, your_rect, ref num2 );
        if ( num3 != 0 )
        {
            if ( num2 < 0 )
            {
                return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_LEFT;
            }
            return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_RIGHT;
        }
        else
        {
            if ( num < 0 )
            {
                return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_TOP;
            }
            return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_BOTTOM;
        }
    }

    // Token: 0x0600143A RID: 5178 RVA: 0x000B2F34 File Offset: 0x000B1134
    public static uint GmBsCmnCheckRectHitSideVFirst( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        int num = 0;
        int num2 = 0;
        int num3 = AppMain.GmBsCmnCheckRectMajorOverlapV(my_rect, your_rect, ref num2);
        AppMain.GmBsCmnCheckRectMajorOverlapH( my_rect, your_rect, ref num );
        if ( num3 != 0 )
        {
            if ( num < 0 )
            {
                return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_LEFT;
            }
            return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_RIGHT;
        }
        else
        {
            if ( num2 < 0 )
            {
                return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_TOP;
            }
            return AppMain.GMD_BS_CMN_RECT_HIT_SIDE_BOTTOM;
        }
    }

    // Token: 0x0600143B RID: 5179 RVA: 0x000B2F7C File Offset: 0x000B117C
    private static void GmBsCmnInitBossMotionCBSystem( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr )
    {
        bmcb_mgr.Clear();
        bmcb_mgr.bmcb_head.next = bmcb_mgr.bmcb_tail;
        bmcb_mgr.bmcb_head.prev = null;
        bmcb_mgr.bmcb_tail.next = null;
        bmcb_mgr.bmcb_tail.prev = bmcb_mgr.bmcb_head;
        obj_work.obj_3d.mtn_cb_func = new AppMain.mtn_cb_func_delegate( AppMain.gmBsCmnBossMotionCallbackFunc );
        obj_work.obj_3d.mtn_cb_param = bmcb_mgr;
    }

    // Token: 0x0600143C RID: 5180 RVA: 0x000B2FEC File Offset: 0x000B11EC
    private static void GmBsCmnClearBossMotionCBSystem( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_BMCB_MGR gms_BS_CMN_BMCB_MGR = (AppMain.GMS_BS_CMN_BMCB_MGR)obj_work.obj_3d.mtn_cb_param;
        if ( gms_BS_CMN_BMCB_MGR == null )
        {
            return;
        }
        AppMain.GMS_BS_CMN_BMCB_LINK next;
        for ( AppMain.GMS_BS_CMN_BMCB_LINK gms_BS_CMN_BMCB_LINK = gms_BS_CMN_BMCB_MGR.bmcb_head.next; gms_BS_CMN_BMCB_LINK != null; gms_BS_CMN_BMCB_LINK = next )
        {
            next = gms_BS_CMN_BMCB_LINK.next;
            gms_BS_CMN_BMCB_LINK.next = null;
            gms_BS_CMN_BMCB_LINK.prev = null;
            if ( gms_BS_CMN_BMCB_LINK.bmcb_func == null )
            {
                break;
            }
        }
        gms_BS_CMN_BMCB_MGR.bmcb_head.next = ( gms_BS_CMN_BMCB_MGR.bmcb_head.prev = null );
        gms_BS_CMN_BMCB_MGR.bmcb_tail.next = ( gms_BS_CMN_BMCB_MGR.bmcb_tail.prev = null );
        gms_BS_CMN_BMCB_MGR.Clear();
        obj_work.obj_3d.mtn_cb_func = null;
        obj_work.obj_3d.mtn_cb_param = null;
    }

    // Token: 0x0600143D RID: 5181 RVA: 0x000B3092 File Offset: 0x000B1292
    private static void GmBsCmnAppendBossMotionCallback( AppMain.GMS_BS_CMN_BMCB_MGR bmcb_mgr, AppMain.GMS_BS_CMN_BMCB_LINK bmcb_link )
    {
        bmcb_link.prev = bmcb_mgr.bmcb_tail.prev;
        bmcb_link.prev.next = bmcb_link;
        bmcb_link.next = bmcb_mgr.bmcb_tail;
        bmcb_mgr.bmcb_tail.prev = bmcb_link;
    }

    // Token: 0x0600143E RID: 5182 RVA: 0x000B30C9 File Offset: 0x000B12C9
    private static void GmBsCmnCreateSNMWork( AppMain.GMS_BS_CMN_SNM_WORK snm_work, AppMain.NNS_OBJECT _object, ushort reg_max )
    {
        AppMain.UNREFERENCED_PARAMETER( _object );
        AppMain.gmBsCmnInitBossMotionCBLink( snm_work.bmcb_link, new AppMain.MPP_VOID_MOTION_NSSOBJECT_OBJECT( AppMain.gmBsCmnMotionCallbackStoreNodeMatrix ), snm_work );
        snm_work.reg_node_cnt = 0;
        snm_work.reg_node_max = reg_max;
        snm_work.node_info_list = AppMain.New<AppMain.GMS_BS_CMN_SNM_NODE_INFO>( ( int )reg_max );
    }

    // Token: 0x0600143F RID: 5183 RVA: 0x000B3103 File Offset: 0x000B1303
    private static void GmBsCmnDeleteSNMWork( AppMain.GMS_BS_CMN_SNM_WORK snm_work )
    {
        AppMain.gmBsCmnClearBossMotionCBLink( snm_work.bmcb_link );
        snm_work.reg_node_cnt = 0;
        snm_work.reg_node_max = 0;
        if ( snm_work.node_info_list != null )
        {
            snm_work.node_info_list = null;
        }
    }

    // Token: 0x06001440 RID: 5184 RVA: 0x000B3130 File Offset: 0x000B1330
    private static int GmBsCmnRegisterSNMNode( AppMain.GMS_BS_CMN_SNM_WORK snm_work, int node_index )
    {
        snm_work.node_info_list[( int )snm_work.reg_node_cnt].node_index = node_index;
        int reg_node_cnt = (int)snm_work.reg_node_cnt;
        snm_work.reg_node_cnt += 1;
        return reg_node_cnt;
    }

    // Token: 0x06001441 RID: 5185 RVA: 0x000B3167 File Offset: 0x000B1367
    private static AppMain.NNS_MATRIX GmBsCmnGetSNMMtx( AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id )
    {
        return snm_work.node_info_list[snm_reg_id].node_w_mtx;
    }

    // Token: 0x06001442 RID: 5186 RVA: 0x000B3178 File Offset: 0x000B1378
    private static void GmBsCmnUpdateObjectGeneralStuckWithNode( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, AppMain.NNS_MATRIX ofst_mtx )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(snm_work, snm_reg_id);
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obj_work.pos.y = -AppMain.FX_F32_TO_FX32( nns_MATRIX.M13 );
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
        if ( ofst_mtx != null )
        {
            AppMain.VEC_Set( ref obj_work.pos, obj_work.pos.x + AppMain.FX_F32_TO_FX32( ofst_mtx.M03 ), obj_work.pos.y - AppMain.FX_F32_TO_FX32( ofst_mtx.M13 ), obj_work.pos.z + AppMain.FX_F32_TO_FX32( ofst_mtx.M23 ) );
        }
    }

    // Token: 0x06001443 RID: 5187 RVA: 0x000B3223 File Offset: 0x000B1423
    private static void GmBsCmnUpdateObjectGeneralStuckWithNodeRelative( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, AppMain.VecFx32 pivot_cur_pos, AppMain.VecFx32 pivot_prev_pos )
    {
        AppMain.GmBsCmnUpdateObjectGeneralStuckWithNodeRelative( obj_work, snm_work, snm_reg_id, pivot_cur_pos, pivot_prev_pos, null );
    }

    // Token: 0x06001444 RID: 5188 RVA: 0x000B3234 File Offset: 0x000B1434
    private static void GmBsCmnUpdateObjectGeneralStuckWithNodeRelative( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, AppMain.VecFx32 pivot_cur_pos, AppMain.VecFx32 pivot_prev_pos, AppMain.NNS_MATRIX ofst_mtx )
    {
        AppMain.GmBsCmnUpdateObjectGeneralStuckWithNode( obj_work, snm_work, snm_reg_id, ofst_mtx );
        AppMain.VEC_Set( ref obj_work.pos, obj_work.pos.x - pivot_prev_pos.x + pivot_cur_pos.x, obj_work.pos.y - pivot_prev_pos.y + pivot_cur_pos.y, obj_work.pos.z - pivot_prev_pos.z + pivot_cur_pos.z );
    }

    // Token: 0x06001445 RID: 5189 RVA: 0x000B32A7 File Offset: 0x000B14A7
    private static void GmBsCmnUpdateObject3DNNStuckWithNode( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation )
    {
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, snm_work, snm_reg_id, b_rotation, null );
    }

    // Token: 0x06001446 RID: 5190 RVA: 0x000B32B4 File Offset: 0x000B14B4
    private static void GmBsCmnUpdateObject3DNNStuckWithNode( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation, AppMain.NNS_MATRIX ofst_mtx )
    {
        AppMain.NNS_MATRIX user_obj_mtx_r = obj_work.obj_3d.user_obj_mtx_r;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(snm_work, snm_reg_id);
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obj_work.pos.y = -AppMain.FX_F32_TO_FX32( nns_MATRIX.M13 );
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
        if ( b_rotation != 0 )
        {
            obj_work.disp_flag |= 16777216U;
            AppMain.AkMathNormalizeMtx( user_obj_mtx_r, nns_MATRIX );
        }
        else
        {
            obj_work.disp_flag &= 4278190079U;
            AppMain.nnMakeUnitMatrix( user_obj_mtx_r );
        }
        if ( ofst_mtx != null )
        {
            AppMain.NNS_MATRIX gmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx = AppMain.GmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx;
            AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR();
            AppMain.NNS_MATRIX gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot = AppMain.GmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot;
            AppMain.nnCopyMatrix( gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot, nns_MATRIX );
            gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot.M03 = ( gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot.M13 = ( gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot.M23 = 0f ) );
            AppMain.nnMultiplyMatrix( gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot, gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot, ofst_mtx );
            AppMain.nnCopyMatrixTranslationVector( nns_VECTOR, gmBsCmnUpdateObject3DNNStuckWithNode_node_w_rot );
            AppMain.VEC_Set( ref obj_work.pos, obj_work.pos.x + AppMain.FX_F32_TO_FX32( nns_VECTOR.x ), obj_work.pos.y - AppMain.FX_F32_TO_FX32( nns_VECTOR.y ), obj_work.pos.z + AppMain.FX_F32_TO_FX32( nns_VECTOR.z ) );
            AppMain.nnCopyMatrix( gmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx, ofst_mtx );
            gmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx.M03 = ( gmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx.M13 = ( gmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx.M23 = 0f ) );
            obj_work.disp_flag |= 16777216U;
            AppMain.nnMultiplyMatrix( user_obj_mtx_r, user_obj_mtx_r, gmBsCmnUpdateObject3DNNStuckWithNode_rot_mtx );
        }
    }

    // Token: 0x06001447 RID: 5191 RVA: 0x000B343C File Offset: 0x000B163C
    private static void GmBsCmnUpdateObject3DNNStuckWithNodeRelative( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation, AppMain.VecFx32 pivot_cur_pos, AppMain.VecFx32 pivot_prev_pos, AppMain.NNS_MATRIX ofst_mtx )
    {
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, snm_work, snm_reg_id, b_rotation, ofst_mtx );
        AppMain.VEC_Set( ref obj_work.pos, obj_work.pos.x - pivot_prev_pos.x + pivot_cur_pos.x, obj_work.pos.y - pivot_prev_pos.y + pivot_cur_pos.y, obj_work.pos.z - pivot_prev_pos.z + pivot_cur_pos.z );
    }

    // Token: 0x06001448 RID: 5192 RVA: 0x000B34B0 File Offset: 0x000B16B0
    private static void GmBsCmnUpdateObject3DESStuckWithNode( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation )
    {
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, snm_work, snm_reg_id, b_rotation, null );
    }

    // Token: 0x06001449 RID: 5193 RVA: 0x000B34BC File Offset: 0x000B16BC
    private static void GmBsCmnUpdateObject3DESStuckWithNode( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation, AppMain.NNS_MATRIX ofst_mtx )
    {
        AppMain.NNS_MATRIX gmBsCmnUpdateObject3DESStuckWithNode_nml_w_mtx = AppMain.GmBsCmnUpdateObject3DESStuckWithNode_nml_w_mtx;
        AppMain.NNS_QUATERNION user_dir_quat = obj_work.obj_3des.user_dir_quat;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmBsCmnGetSNMMtx(snm_work, snm_reg_id);
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obj_work.pos.y = -AppMain.FX_F32_TO_FX32( nns_MATRIX.M13 );
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
        if ( b_rotation != 0 )
        {
            obj_work.obj_3des.flag |= 32U;
            AppMain.AkMathNormalizeMtx( gmBsCmnUpdateObject3DESStuckWithNode_nml_w_mtx, nns_MATRIX );
            AppMain.nnMakeRotateMatrixQuaternion( out user_dir_quat, gmBsCmnUpdateObject3DESStuckWithNode_nml_w_mtx );
        }
        else
        {
            obj_work.obj_3des.flag &= 4294967263U;
            AppMain.nnMakeUnitQuaternion( ref user_dir_quat );
            AppMain.nnMakeUnitMatrix( gmBsCmnUpdateObject3DESStuckWithNode_nml_w_mtx );
        }
        if ( ofst_mtx != null )
        {
            AppMain.NNS_MATRIX gmBsCmnUpdateObject3DESStuckWithNode_rot_mtx = AppMain.GmBsCmnUpdateObject3DESStuckWithNode_rot_mtx;
            AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
            AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR();
            AppMain.NNS_MATRIX gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot = AppMain.GmBsCmnUpdateObject3DESStuckWithNode_node_w_rot;
            AppMain.nnCopyMatrix( gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot, nns_MATRIX );
            gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot.M03 = ( gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot.M13 = ( gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot.M23 = 0f ) );
            AppMain.nnMultiplyMatrix( gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot, gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot, ofst_mtx );
            AppMain.nnCopyMatrixTranslationVector( nns_VECTOR, gmBsCmnUpdateObject3DESStuckWithNode_node_w_rot );
            AppMain.VEC_Set( ref obj_work.pos, obj_work.pos.x + AppMain.FX_F32_TO_FX32( nns_VECTOR.x ), obj_work.pos.y - AppMain.FX_F32_TO_FX32( nns_VECTOR.y ), obj_work.pos.z + AppMain.FX_F32_TO_FX32( nns_VECTOR.z ) );
            AppMain.AkMathNormalizeMtx( gmBsCmnUpdateObject3DESStuckWithNode_rot_mtx, ofst_mtx );
            AppMain.nnMakeRotateMatrixQuaternion( out nns_QUATERNION, gmBsCmnUpdateObject3DESStuckWithNode_rot_mtx );
            obj_work.obj_3des.flag |= 32U;
            AppMain.nnMultiplyQuaternion( ref user_dir_quat, ref user_dir_quat, ref nns_QUATERNION );
        }
        obj_work.obj_3des.user_dir_quat.Assign( user_dir_quat );
    }

    // Token: 0x0600144A RID: 5194 RVA: 0x000B3665 File Offset: 0x000B1865
    private static void GmBsCmnUpdateObject3DESStuckWithNodeRelative( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation, AppMain.VecFx32 pivot_cur_pos, AppMain.VecFx32 pivot_prev_pos )
    {
        AppMain.GmBsCmnUpdateObject3DESStuckWithNodeRelative( obj_work, snm_work, snm_reg_id, b_rotation, pivot_cur_pos, pivot_prev_pos, null );
    }

    // Token: 0x0600144B RID: 5195 RVA: 0x000B3678 File Offset: 0x000B1878
    private static void GmBsCmnUpdateObject3DESStuckWithNodeRelative( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, int b_rotation, AppMain.VecFx32 pivot_cur_pos, AppMain.VecFx32 pivot_prev_pos, AppMain.NNS_MATRIX ofst_mtx )
    {
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, snm_work, snm_reg_id, b_rotation, ofst_mtx );
        AppMain.VEC_Set( ref obj_work.pos, obj_work.pos.x - pivot_prev_pos.x + pivot_cur_pos.x, obj_work.pos.y - pivot_prev_pos.y + pivot_cur_pos.y, obj_work.pos.z - pivot_prev_pos.z + pivot_cur_pos.z );
    }

    // Token: 0x0600144C RID: 5196 RVA: 0x000B36EC File Offset: 0x000B18EC
    private static void GmBsCmnInitCNMCb( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work )
    {
        obj_work.obj_3d.mplt_cb_func = new AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT( AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix );
        obj_work.obj_3d.mplt_cb_param = null;
    }

    // Token: 0x0600144D RID: 5197 RVA: 0x000B3711 File Offset: 0x000B1911
    private static void GmBsCmnClearCNMCb( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d.mplt_cb_func = null;
        obj_work.obj_3d.mplt_cb_param = null;
    }

    // Token: 0x0600144E RID: 5198 RVA: 0x000B372B File Offset: 0x000B192B
    private static void GmBsCmnCreateCNMMgrWork( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, AppMain.NNS_OBJECT _object, ushort reg_max )
    {
        AppMain.UNREFERENCED_PARAMETER( _object );
        cnm_mgr_work.reg_node_cnt = 0;
        cnm_mgr_work.reg_node_max = reg_max;
        cnm_mgr_work.node_info_list = AppMain.New<AppMain.GMS_BS_CMN_CNM_NODE_INFO>( ( int )reg_max );
    }

    // Token: 0x0600144F RID: 5199 RVA: 0x000B374D File Offset: 0x000B194D
    private static void GmBsCmnDeleteCNMMgrWork( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work )
    {
        cnm_mgr_work.reg_node_cnt = 0;
        cnm_mgr_work.reg_node_max = 0;
        if ( cnm_mgr_work.node_info_list != null )
        {
            cnm_mgr_work.node_info_list = null;
        }
    }

    // Token: 0x06001450 RID: 5200 RVA: 0x000B376C File Offset: 0x000B196C
    private static void GmBsCmnUpdateCNMParam( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work )
    {
        if ( obj_work.obj_3d.mplt_cb_func == null )
        {
            return;
        }
        AppMain.GMS_BS_CMN_CNM_PARAM gms_BS_CMN_CNM_PARAM = AppMain.amDrawAlloc_GMS_BS_CMN_CNM_PARAM();
        gms_BS_CMN_CNM_PARAM.reg_node_cnt = cnm_mgr_work.reg_node_cnt;
        AppMain.GMS_BS_CMN_CNM_NODE_INFO[] array = AppMain.amDrawAlloc_GMS_BS_CMN_CNM_NODE_INFO((int)cnm_mgr_work.reg_node_max);
        for ( int i = 0; i < ( int )cnm_mgr_work.reg_node_max; i++ )
        {
            array[i] = AppMain.amDrawAlloc_GMS_BS_CMN_CNM_NODE_INFO();
            array[i].Assign( cnm_mgr_work.node_info_list[i] );
        }
        AppMain.OBS_ACTION3D_NN_WORK.CMPLT_Wrapper cmplt_Wrapper = new AppMain.OBS_ACTION3D_NN_WORK.CMPLT_Wrapper();
        cmplt_Wrapper.m_pInfos = array;
        cmplt_Wrapper.reg_node_cnt = cnm_mgr_work.reg_node_cnt;
        obj_work.obj_3d.mplt_cb_param = cmplt_Wrapper;
    }

    // Token: 0x06001451 RID: 5201 RVA: 0x000B37F4 File Offset: 0x000B19F4
    private static int GmBsCmnRegisterCNMNode( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, int node_index )
    {
        cnm_mgr_work.node_info_list[( int )cnm_mgr_work.reg_node_cnt].node_index = node_index;
        int reg_node_cnt = (int)cnm_mgr_work.reg_node_cnt;
        cnm_mgr_work.reg_node_cnt += 1;
        return reg_node_cnt;
    }

    // Token: 0x06001452 RID: 5202 RVA: 0x000B382B File Offset: 0x000B1A2B
    private static void GmBsCmnSetCNMMtx( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, AppMain.NNS_MATRIX w_mtx, int cnm_reg_id )
    {
        AppMain.GmBsCmnSetCNMMtx( cnm_mgr_work, w_mtx, cnm_reg_id, 0 );
    }

    // Token: 0x06001453 RID: 5203 RVA: 0x000B3838 File Offset: 0x000B1A38
    private static void GmBsCmnSetCNMMtx( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, AppMain.NNS_MATRIX w_mtx, int cnm_reg_id, int enables )
    {
        AppMain.GMS_BS_CMN_CNM_NODE_INFO gms_BS_CMN_CNM_NODE_INFO = cnm_mgr_work.node_info_list[cnm_reg_id];
        AppMain.nnCopyMatrix( gms_BS_CMN_CNM_NODE_INFO.node_w_mtx, w_mtx );
        if ( enables != 0 )
        {
            gms_BS_CMN_CNM_NODE_INFO.enable = 1;
        }
    }

    // Token: 0x06001454 RID: 5204 RVA: 0x000B3864 File Offset: 0x000B1A64
    private static void GmBsCmnChangeCNMModeNode( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, int cnm_reg_id, uint mode )
    {
        cnm_mgr_work.node_info_list[cnm_reg_id].mode = mode;
    }

    // Token: 0x06001455 RID: 5205 RVA: 0x000B3874 File Offset: 0x000B1A74
    private static void GmBsCmnEnableCNMLocalCoordinate( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, int cnm_reg_id, int enable )
    {
        if ( enable != 0 )
        {
            cnm_mgr_work.node_info_list[cnm_reg_id].flag |= AppMain.GMD_BS_CMN_CNM_FLAG_LOCAL_COORDINATE;
            return;
        }
        cnm_mgr_work.node_info_list[cnm_reg_id].flag &= ~AppMain.GMD_BS_CMN_CNM_FLAG_LOCAL_COORDINATE;
    }

    // Token: 0x06001456 RID: 5206 RVA: 0x000B38AD File Offset: 0x000B1AAD
    private static void GmBsCmnEnableCNMInheritNodeScale( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, int cnm_reg_id, int enable )
    {
        if ( enable != 0 )
        {
            cnm_mgr_work.node_info_list[cnm_reg_id].flag |= AppMain.GMD_BS_CMN_CNM_FLAG_INHERIT_SCALE;
            return;
        }
        cnm_mgr_work.node_info_list[cnm_reg_id].flag &= ~AppMain.GMD_BS_CMN_CNM_FLAG_INHERIT_SCALE;
    }

    // Token: 0x06001457 RID: 5207 RVA: 0x000B38E6 File Offset: 0x000B1AE6
    private static void GmBsCmnEnableCNMMtxNode( AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, int cnm_reg_id, int enable )
    {
        if ( enable != 0 )
        {
            cnm_mgr_work.node_info_list[cnm_reg_id].enable = 1;
            return;
        }
        cnm_mgr_work.node_info_list[cnm_reg_id].enable = 0;
    }

    // Token: 0x06001458 RID: 5208 RVA: 0x000B3908 File Offset: 0x000B1B08
    private static AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT GmBsCmnCreateNodeControlObjectBySize( AppMain.OBS_OBJECT_WORK parent_obj, AppMain.GMS_BS_CMN_CNM_MGR_WORK cnm_mgr_work, int cnm_reg_id, AppMain.GMS_BS_CMN_SNM_WORK snm_work, int snm_reg_id, AppMain.TaskWorkFactoryDelegate work_size )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(work_size, parent_obj, 0, "bs_cmn_node_ctl_obj");
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obs_OBJECT_WORK;
        gms_BS_CMN_NODE_CTRL_OBJECT.cnm_mgr_work = cnm_mgr_work;
        gms_BS_CMN_NODE_CTRL_OBJECT.cnm_reg_id = cnm_reg_id;
        gms_BS_CMN_NODE_CTRL_OBJECT.snm_work = snm_work;
        gms_BS_CMN_NODE_CTRL_OBJECT.snm_reg_id = snm_reg_id;
        gms_BS_CMN_NODE_CTRL_OBJECT.is_enable = 0;
        AppMain.nnMakeUnitMatrix( gms_BS_CMN_NODE_CTRL_OBJECT.w_mtx );
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK.ppOut = null;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBsCmnNodeControlObjectMainFunc );
        return gms_BS_CMN_NODE_CTRL_OBJECT;
    }

    // Token: 0x06001459 RID: 5209 RVA: 0x000B3984 File Offset: 0x000B1B84
    private static void GmBsCmnAttachNCObjectToSNMNode( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT ndc_obj )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ndc_obj;
        AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR();
        AppMain.NNS_MATRIX nns_MATRIX = new AppMain.NNS_MATRIX();
        AppMain.NNS_MATRIX nns_MATRIX2 = new AppMain.NNS_MATRIX();
        AppMain.NNS_MATRIX nns_MATRIX3 = new AppMain.NNS_MATRIX();
        AppMain.nnCopyMatrix( nns_MATRIX, AppMain.GmBsCmnGetSNMMtx( ndc_obj.snm_work, ndc_obj.snm_reg_id ) );
        AppMain.AkMathNormalizeMtx( nns_MATRIX2, nns_MATRIX );
        AppMain.nnMakeRotateMatrixQuaternion( out ndc_obj.user_quat, nns_MATRIX2 );
        AppMain.nnTransformVector( nns_VECTOR, nns_MATRIX2, ndc_obj.user_ofst );
        AppMain.nnMakeTranslateMatrix( nns_MATRIX3, -nns_VECTOR.x, -nns_VECTOR.y, -nns_VECTOR.z );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX3, nns_MATRIX );
        AppMain.GmBsCmnEnableCNMInheritNodeScale( ndc_obj.cnm_mgr_work, ndc_obj.cnm_reg_id, 1 );
        obs_OBJECT_WORK.pos.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        obs_OBJECT_WORK.pos.y = AppMain.FX_F32_TO_FX32( -nns_MATRIX.M13 );
        obs_OBJECT_WORK.pos.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
    }

    // Token: 0x0600145A RID: 5210 RVA: 0x000B3A64 File Offset: 0x000B1C64
    private static void GmBsCmnSetWorldMtxFromNCObjectPosture( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT ndc_obj )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)ndc_obj;
        AppMain.nnMakeTranslateMatrix( ndc_obj.w_mtx, AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.pos.x ), AppMain.FX_FX32_TO_F32( -obs_OBJECT_WORK.pos.y ), AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK.pos.z ) );
        AppMain.nnQuaternionMatrix( ndc_obj.w_mtx, ndc_obj.w_mtx, ref ndc_obj.user_quat );
        AppMain.nnTranslateMatrix( ndc_obj.w_mtx, ndc_obj.w_mtx, ndc_obj.user_ofst.x, ndc_obj.user_ofst.y, ndc_obj.user_ofst.z );
    }

    // Token: 0x0600145B RID: 5211 RVA: 0x000B3AFD File Offset: 0x000B1CFD
    private static void GmBsCmnSetObject3DNNFadedColor( AppMain.OBS_OBJECT_WORK obj_work, AppMain.NNS_RGB color, float intensity )
    {
        AppMain.GmBsCmnSetObject3DNNFadedColor( obj_work, color, intensity, 0f, 10000f );
    }

    // Token: 0x0600145C RID: 5212 RVA: 0x000B3B11 File Offset: 0x000B1D11
    private static void GmBsCmnSetObject3DNNFadedColor( AppMain.OBS_OBJECT_WORK obj_work, AppMain.NNS_RGB color, float intensity, float radius )
    {
        AppMain.GmBsCmnSetObject3DNNFadedColor( obj_work, color, intensity, radius, 10000f );
    }

    // Token: 0x0600145D RID: 5213 RVA: 0x000B3B24 File Offset: 0x000B1D24
    private static void GmBsCmnSetObject3DNNFadedColor( AppMain.OBS_OBJECT_WORK obj_work, AppMain.NNS_RGB color, float intensity, float radius, float length )
    {
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        AppMain.AMS_DRAWSTATE draw_state = obj_work.obj_3d.draw_state;
        draw_state.fog.flag = 1;
        draw_state.fog_color.r = color.r;
        draw_state.fog_color.g = color.g;
        draw_state.fog_color.b = color.b;
        AppMain.ObjCameraDispPosGet( AppMain.g_obj.glb_camera_id, out snns_VECTOR );
        float num = AppMain.FX_FX32_TO_F32(obj_work.pos.z);
        float num2 = AppMain.nnAbs((double)(snns_VECTOR.z - num));
        float num3;
        float num4;
        if ( length * intensity > num2 )
        {
            num3 = 1.1754944E-38f;
            num4 = num3 + num2 / intensity;
        }
        else
        {
            num3 = num2 - length * intensity;
            if ( num3 <= 0f )
            {
                num3 = 1.1754944E-38f;
            }
            num4 = num3 + length;
        }
        draw_state.fog_range.fnear = num3 + radius;
        draw_state.fog_range.ffar = num4 - radius;
    }

    // Token: 0x0600145E RID: 5214 RVA: 0x000B3C0C File Offset: 0x000B1E0C
    private static void GmBsCmnClearObject3DNNFadedColor( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.AMS_DRAWSTATE draw_state = obj_work.obj_3d.draw_state;
        draw_state.fog.flag = AppMain.g_obj_draw_3dnn_draw_state.fog.flag;
        draw_state.fog_color.Assign( AppMain.g_obj_draw_3dnn_draw_state.fog_color );
        draw_state.fog_range.Assign( AppMain.g_obj_draw_3dnn_draw_state.fog_range );
    }

    // Token: 0x0600145F RID: 5215 RVA: 0x000B3C6B File Offset: 0x000B1E6B
    private static int GmBsCmnIsSetSafeObject3DNNFadedColor( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3d.draw_state.fog.flag == 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001460 RID: 5216 RVA: 0x000B3C87 File Offset: 0x000B1E87
    private static void GmBsCmnInitObject3DNNDamageFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work, float radius )
    {
        flk_work.is_active = 1;
        flk_work.cycles = AppMain.GMD_BS_CMN_DMG_FLICKER_DEFAULT_CYCLE;
        flk_work.interval_timer = 0U;
        flk_work.cur_angle = 0;
        flk_work.radius = radius;
        AppMain.GmBsCmnClearObject3DNNFadedColor( obj_work );
    }

    // Token: 0x06001461 RID: 5217 RVA: 0x000B3CB8 File Offset: 0x000B1EB8
    private static int GmBsCmnUpdateObject3DNNDamageFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work )
    {
        if ( flk_work.is_active == 0 )
        {
            return 1;
        }
        if ( flk_work.cycles != 0U )
        {
            if ( flk_work.interval_timer != 0U )
            {
                flk_work.interval_timer -= 1U;
            }
            else
            {
                flk_work.cur_angle += AppMain.AKM_DEGtoA32( 45f );
                if ( flk_work.cur_angle >= AppMain.AKM_DEGtoA32( 360f ) )
                {
                    flk_work.cur_angle = 0;
                    flk_work.cycles -= 1U;
                }
            }
            AppMain.GmBsCmnSetObject3DNNFadedColor( obj_work, AppMain.gm_bs_cmn_dmg_flicker_default_color, ( 1f - AppMain.nnCos( flk_work.cur_angle ) ) / 2f );
            return 0;
        }
        if ( flk_work.is_active != 0 )
        {
            AppMain.GmBsCmnEndObject3DNNDamageFlicker( obj_work, flk_work );
        }
        return 1;
    }

    // Token: 0x06001462 RID: 5218 RVA: 0x000B3D61 File Offset: 0x000B1F61
    private static void GmBsCmnEndObject3DNNDamageFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BS_CMN_DMG_FLICKER_WORK flk_work )
    {
        flk_work.Clear();
        AppMain.GmBsCmnClearObject3DNNFadedColor( obj_work );
    }

    // Token: 0x06001463 RID: 5219 RVA: 0x000B3D78 File Offset: 0x000B1F78
    private static AppMain.GMS_FADE_OBJ_WORK GmBsCmnInitScreenFadingColor( AppMain.NNS_RGBA_U8 start_color, AppMain.NNS_RGBA_U8 end_color, float frame )
    {
        AppMain.GMS_FADE_OBJ_WORK gms_FADE_OBJ_WORK = AppMain.GmFadeCreateFadeObj(6656, 3, 0, () => new AppMain.GMS_FADE_OBJ_WORK(), 61439, 10U);
        AppMain.GmFadeSetFade( gms_FADE_OBJ_WORK, 0U, start_color.r, start_color.g, start_color.b, start_color.a, end_color.r, end_color.g, end_color.b, end_color.a, frame, 0, 0 );
        return gms_FADE_OBJ_WORK;
    }

    // Token: 0x06001464 RID: 5220 RVA: 0x000B3DF1 File Offset: 0x000B1FF1
    private static int GmBsCmnUpdateScreenFadingColor( AppMain.GMS_FADE_OBJ_WORK fade_obj_work )
    {
        if ( AppMain.GmFadeIsEnd( fade_obj_work ) != 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001465 RID: 5221 RVA: 0x000B3DFE File Offset: 0x000B1FFE
    private static void GmBsCmnClearScreenFadingColor( AppMain.GMS_FADE_OBJ_WORK fade_obj_work )
    {
        fade_obj_work.obj_work.flag |= 8U;
    }

    // Token: 0x06001466 RID: 5222 RVA: 0x000B3E14 File Offset: 0x000B2014
    private static void GmBsCmnInitFlashScreen( AppMain.GMS_CMN_FLASH_SCR_WORK flash_work, float fo_frame, float duration_frame, float fi_frame )
    {
        AppMain.NNS_RGBA_U8 start_color = new AppMain.NNS_RGBA_U8(0, 0, 0, 0);
        AppMain.NNS_RGBA_U8 end_color = new AppMain.NNS_RGBA_U8(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        flash_work.Clear();
        flash_work.active_flag |= 3U;
        flash_work.fi_frame = fi_frame;
        flash_work.duration_timer = duration_frame;
        flash_work.fade_obj_work = AppMain.GmBsCmnInitScreenFadingColor( start_color, end_color, fo_frame );
    }

    // Token: 0x06001467 RID: 5223 RVA: 0x000B3E78 File Offset: 0x000B2078
    private static int GmBsCmnUpdateFlashScreen( AppMain.GMS_CMN_FLASH_SCR_WORK flash_work )
    {
        AppMain.NNS_RGBA_U8 end_color = new AppMain.NNS_RGBA_U8(0, 0, 0, 0);
        AppMain.NNS_RGBA_U8 start_color = new AppMain.NNS_RGBA_U8(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        if ( flash_work.active_flag == 0U )
        {
            return 1;
        }
        if ( AppMain.GmBsCmnUpdateScreenFadingColor( flash_work.fade_obj_work ) != 0 )
        {
            if ( ( flash_work.active_flag & 1U ) != 0U )
            {
                if ( flash_work.duration_timer > 0f )
                {
                    flash_work.duration_timer -= 1f;
                }
                else
                {
                    flash_work.active_flag &= 4294967294U;
                    AppMain.GmBsCmnClearScreenFadingColor( flash_work.fade_obj_work );
                    flash_work.fade_obj_work = AppMain.GmBsCmnInitScreenFadingColor( start_color, end_color, flash_work.fi_frame );
                }
            }
            else if ( ( flash_work.active_flag & 2U ) != 0U )
            {
                AppMain.GmBsCmnClearScreenFadingColor( flash_work.fade_obj_work );
                flash_work.fade_obj_work = null;
                flash_work.active_flag &= 4294967293U;
            }
        }
        return 0;
    }

    // Token: 0x06001468 RID: 5224 RVA: 0x000B3F49 File Offset: 0x000B2149
    private static void GmBsCmnClearFlashScreen( AppMain.GMS_CMN_FLASH_SCR_WORK flash_work )
    {
        if ( flash_work.fade_obj_work != null )
        {
            AppMain.GmBsCmnClearScreenFadingColor( flash_work.fade_obj_work );
            flash_work.fade_obj_work = null;
        }
        flash_work.Clear();
    }

    // Token: 0x06001469 RID: 5225 RVA: 0x000B3F6B File Offset: 0x000B216B
    private static void GmBsCmnInitDelaySearch( AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK dsearch_work, AppMain.OBS_OBJECT_WORK targ_obj, AppMain.VecFx32[] pos_hist_buf, int hist_num )
    {
        dsearch_work.pos_hist_buf = pos_hist_buf;
        dsearch_work.cur_point = -1;
        dsearch_work.hist_num = hist_num;
        dsearch_work.targ_obj = targ_obj;
        dsearch_work.record_cnt = 0;
        AppMain.GmBsCmnUpdateDelaySearch( dsearch_work );
    }

    // Token: 0x0600146A RID: 5226 RVA: 0x000B3F98 File Offset: 0x000B2198
    private static void GmBsCmnUpdateDelaySearch( AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK dsearch_work )
    {
        dsearch_work.cur_point++;
        if ( dsearch_work.cur_point >= dsearch_work.hist_num )
        {
            dsearch_work.cur_point = 0;
        }
        dsearch_work.record_cnt++;
        dsearch_work.pos_hist_buf[dsearch_work.cur_point].Assign( dsearch_work.targ_obj.pos );
    }

    // Token: 0x0600146B RID: 5227 RVA: 0x000B3FF8 File Offset: 0x000B21F8
    private static void GmBsCmnGetDelaySearchPos( AppMain.GMS_BS_CMN_DELAY_SEARCH_WORK dsearch_work, int delay_time, out AppMain.VecFx32 pos )
    {
        int num;
        if ( delay_time < dsearch_work.record_cnt )
        {
            num = dsearch_work.cur_point - delay_time;
            if ( num < 0 )
            {
                num = dsearch_work.hist_num + num;
            }
        }
        else
        {
            num = 0;
        }
        pos = dsearch_work.pos_hist_buf[num];
    }

    // Token: 0x0600146C RID: 5228 RVA: 0x000B4040 File Offset: 0x000B2240
    private static int gmBsCmnCheckActionFrameOverrunOnNextUpdate( AppMain.OBS_OBJECT_WORK obj_work, ref float overrun_frame )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        float num = obj_3d.speed[0] * AppMain.FX_FX32_TO_F32(AppMain.g_obj.speed);
        float num2 = AppMain.amMotionGetEndFrame(obj_3d.motion, obj_3d.act_id[0]) - AppMain.amMotionGetStartFrame(obj_3d.motion, obj_3d.act_id[0]);
        if ( obj_3d.frame[0] + num > num2 - 1f )
        {
            overrun_frame = obj_3d.frame[0] + num - ( num2 - 1f );
            return 1;
        }
        overrun_frame = 0f;
        return 0;
    }

    // Token: 0x0600146D RID: 5229 RVA: 0x000B40C8 File Offset: 0x000B22C8
    private static int gmBsCmnCheckActionFrameOverrunOnNextUpdate( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        float num = obj_3d.speed[0] * AppMain.FX_FX32_TO_F32(AppMain.g_obj.speed);
        float num2 = AppMain.amMotionGetEndFrame(obj_3d.motion, obj_3d.act_id[0]) - AppMain.amMotionGetStartFrame(obj_3d.motion, obj_3d.act_id[0]);
        if ( obj_3d.frame[0] + num > num2 - 1f )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x0600146E RID: 5230 RVA: 0x000B4133 File Offset: 0x000B2333
    private static void gmBsCmnInitBossMotionCBLink( AppMain.GMS_BS_CMN_BMCB_LINK bmcb_link, AppMain.MPP_VOID_MOTION_NSSOBJECT_OBJECT bmcb_func, object bmcb_param )
    {
        bmcb_link.Clear();
        bmcb_link.bmcb_func = bmcb_func;
        bmcb_link.bmcb_param = bmcb_param;
    }

    // Token: 0x0600146F RID: 5231 RVA: 0x000B4149 File Offset: 0x000B2349
    private static void gmBsCmnClearBossMotionCBLink( AppMain.GMS_BS_CMN_BMCB_LINK bmcb_link )
    {
        bmcb_link.Clear();
    }

    // Token: 0x06001470 RID: 5232 RVA: 0x000B4154 File Offset: 0x000B2354
    private static void gmBsCmnBossMotionCallbackFunc( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object mtn_cb_param )
    {
        AppMain.GMS_BS_CMN_BMCB_MGR gms_BS_CMN_BMCB_MGR = (AppMain.GMS_BS_CMN_BMCB_MGR)mtn_cb_param;
        AppMain.GMS_BS_CMN_BMCB_LINK next = gms_BS_CMN_BMCB_MGR.bmcb_head.next;
        while ( next != null && next.bmcb_func != null )
        {
            next.bmcb_func( motion, _object, next.bmcb_param );
            next = next.next;
        }
    }

    // Token: 0x06001471 RID: 5233 RVA: 0x000B419C File Offset: 0x000B239C
    private static void gmBsCmnMotionCallbackStoreNodeMatrix( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object mtn_cb_param )
    {
        AppMain.GMS_BS_CMN_SNM_WORK gms_BS_CMN_SNM_WORK = (AppMain.GMS_BS_CMN_SNM_WORK)mtn_cb_param;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmBsCmnMotionCallbackStoreNodeMatrix_base_mtx;
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, AppMain.amMatrixGetCurrent() );
        for ( int i = 0; i < ( int )gms_BS_CMN_SNM_WORK.reg_node_cnt; i++ )
        {
            int node_index = gms_BS_CMN_SNM_WORK.node_info_list[i].node_index;
            AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.gmBsCmnMotionCallbackStoreNodeMatrix_node_mtx;
            AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX2, _object, node_index, motion.data, nns_MATRIX );
            gms_BS_CMN_SNM_WORK.node_info_list[i].node_w_mtx.Assign( nns_MATRIX2 );
        }
    }

    // Token: 0x06001472 RID: 5234 RVA: 0x000B4218 File Offset: 0x000B2418
    private static void gmBsCmnMtxpltCallbackControlNodeMatrix( AppMain.NNS_MATRIX[] mtx_plt, AppMain.NNS_OBJECT _object, object mplt_cb_param )
    {
        if ( mplt_cb_param == null )
        {
            return;
        }
        ushort reg_node_cnt = ((AppMain.OBS_ACTION3D_NN_WORK.CMPLT_Wrapper)mplt_cb_param).reg_node_cnt;
        AppMain.GMS_BS_CMN_CNM_NODE_INFO[] pInfos = ((AppMain.OBS_ACTION3D_NN_WORK.CMPLT_Wrapper)mplt_cb_param).m_pInfos;
        AppMain.NNS_MATRIX[] array = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_orig_mtx_plt;
        if ( array == null || array.Length < _object.nMtxPal )
        {
            array = new AppMain.NNS_MATRIX[_object.nMtxPal];
            for ( int i = 0; i < _object.nMtxPal; i++ )
            {
                array[i] = AppMain.amDrawAlloc_NNS_MATRIX();
            }
        }
        for ( int j = 0; j < _object.nMtxPal; j++ )
        {
            array[j].Assign( mtx_plt[j] );
        }
        for ( int k = 0; k < ( int )reg_node_cnt; k++ )
        {
            AppMain.GMS_BS_CMN_CNM_NODE_INFO gms_BS_CMN_CNM_NODE_INFO = pInfos[k];
            if ( gms_BS_CMN_CNM_NODE_INFO.enable != 0 )
            {
                int iMatrix = (int)_object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].iMatrix;
                if ( iMatrix != -1 )
                {
                    AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_candidate_mtx;
                    AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_inv_view_mtx;
                    AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_node_w_mtx;
                    AppMain.nnInvertMatrix( nns_MATRIX2, AppMain.amDrawGetWorldViewMatrix() );
                    AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX2, mtx_plt[iMatrix] );
                    if ( ( gms_BS_CMN_CNM_NODE_INFO.flag & AppMain.GMD_BS_CMN_CNM_FLAG_LOCAL_COORDINATE ) != 0U )
                    {
                        AppMain.NNS_MATRIX nns_MATRIX4 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_cur_mtx;
                        AppMain.NNS_MATRIX nns_MATRIX5 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_inv_cur_mtx;
                        AppMain.NNS_MATRIX nns_MATRIX6 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_init_mtx;
                        int iParent = (int)_object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].iParent;
                        AppMain.nnInvertMatrix( nns_MATRIX6, _object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].InvInitMtx );
                        if ( gms_BS_CMN_CNM_NODE_INFO.mode == 0U )
                        {
                            AppMain.NNS_MATRIX nns_MATRIX7 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_parent_mtx;
                            AppMain.NNS_MATRIX nns_MATRIX8 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_diff_mtx;
                            AppMain.NNS_MATRIX nns_MATRIX9 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_parent_init_mtx;
                            AppMain.nnMultiplyMatrix( nns_MATRIX7, nns_MATRIX2, mtx_plt[( int )_object.pNodeList[iParent].iMatrix] );
                            AppMain.nnInvertMatrix( nns_MATRIX9, _object.pNodeList[iParent].InvInitMtx );
                            AppMain.nnMultiplyMatrix( nns_MATRIX7, nns_MATRIX7, nns_MATRIX9 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX8, _object.pNodeList[iParent].InvInitMtx, nns_MATRIX6 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX7, nns_MATRIX8 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX4, _object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].InvInitMtx );
                            AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX4, gms_BS_CMN_CNM_NODE_INFO.node_w_mtx );
                        }
                        else
                        {
                            AppMain.NNS_MATRIX nns_MATRIX10 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_parent_cur_mtx;
                            AppMain.NNS_MATRIX nns_MATRIX11 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_inv_parent_orig_mtx;
                            AppMain.nnCopyMatrix( nns_MATRIX4, nns_MATRIX );
                            AppMain.nnMultiplyMatrix( nns_MATRIX4, nns_MATRIX4, nns_MATRIX6 );
                            AppMain.gmBsCmnGetNodeInvWorldMtx( nns_MATRIX11, _object.pNodeList[iParent], nns_MATRIX2, array );
                            AppMain.gmBsCmnGetNodeWorldMtx( nns_MATRIX10, _object.pNodeList[iParent], nns_MATRIX2, mtx_plt );
                            AppMain.nnInvertMatrix( nns_MATRIX5, nns_MATRIX4 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX3, gms_BS_CMN_CNM_NODE_INFO.node_w_mtx, nns_MATRIX5 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX4, nns_MATRIX3 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX11, nns_MATRIX3 );
                            AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX10, nns_MATRIX3 );
                        }
                    }
                    else
                    {
                        AppMain.nnCopyMatrix( nns_MATRIX3, gms_BS_CMN_CNM_NODE_INFO.node_w_mtx );
                    }
                    if ( gms_BS_CMN_CNM_NODE_INFO.mode == 1U )
                    {
                        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX3, nns_MATRIX );
                    }
                    else if ( gms_BS_CMN_CNM_NODE_INFO.mode == 2U )
                    {
                        AppMain.NNS_MATRIX nns_MATRIX12 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_init_mtx;
                        AppMain.nnInvertMatrix( nns_MATRIX12, _object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].InvInitMtx );
                        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, nns_MATRIX12 );
                        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, nns_MATRIX3 );
                    }
                    else if ( ( gms_BS_CMN_CNM_NODE_INFO.flag & AppMain.GMD_BS_CMN_CNM_FLAG_INHERIT_SCALE ) != 0U && ( gms_BS_CMN_CNM_NODE_INFO.flag & AppMain.GMD_BS_CMN_CNM_FLAG_LOCAL_COORDINATE ) == 0U )
                    {
                        AppMain.NNS_MATRIX nns_MATRIX13 = AppMain.gmBsCmnMtxpltCallbackControlNodeMatrix_init_mtx;
                        AppMain.nnInvertMatrix( nns_MATRIX13, _object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].InvInitMtx );
                        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, nns_MATRIX13 );
                        AppMain.AkMathExtractScaleMtx( nns_MATRIX, nns_MATRIX );
                        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX3, nns_MATRIX );
                    }
                    else
                    {
                        AppMain.nnCopyMatrix( nns_MATRIX, nns_MATRIX3 );
                    }
                    if ( gms_BS_CMN_CNM_NODE_INFO.mode != 1U )
                    {
                        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, _object.pNodeList[gms_BS_CMN_CNM_NODE_INFO.node_index].InvInitMtx );
                    }
                    AppMain.nnMultiplyMatrix( mtx_plt[iMatrix], AppMain.amDrawGetWorldViewMatrix(), nns_MATRIX );
                }
            }
        }
    }

    // Token: 0x06001473 RID: 5235 RVA: 0x000B45A8 File Offset: 0x000B27A8
    private static void gmBsCmnNodeControlObjectMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT gms_BS_CMN_NODE_CTRL_OBJECT = (AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT)obj_work;
        if ( gms_BS_CMN_NODE_CTRL_OBJECT.proc_update != null )
        {
            gms_BS_CMN_NODE_CTRL_OBJECT.proc_update( obj_work );
        }
        else
        {
            AppMain.nnMakeUnitMatrix( gms_BS_CMN_NODE_CTRL_OBJECT.w_mtx );
        }
        AppMain.GmBsCmnSetCNMMtx( gms_BS_CMN_NODE_CTRL_OBJECT.cnm_mgr_work, gms_BS_CMN_NODE_CTRL_OBJECT.w_mtx, gms_BS_CMN_NODE_CTRL_OBJECT.cnm_reg_id );
        AppMain.GmBsCmnEnableCNMMtxNode( gms_BS_CMN_NODE_CTRL_OBJECT.cnm_mgr_work, gms_BS_CMN_NODE_CTRL_OBJECT.cnm_reg_id, gms_BS_CMN_NODE_CTRL_OBJECT.is_enable );
    }

    // Token: 0x06001474 RID: 5236 RVA: 0x000B460C File Offset: 0x000B280C
    private static void gmBsCmnGetNodeWorldMtx( AppMain.NNS_MATRIX dest_mtx, AppMain.NNS_NODE node, AppMain.NNS_MATRIX inv_view_mtx, AppMain.NNS_MATRIX[] mtx_plt )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmBsCmnGetNodeWorldMtx_init_mtx;
        AppMain.nnMultiplyMatrix( dest_mtx, inv_view_mtx, mtx_plt[( int )node.iMatrix] );
        AppMain.nnInvertMatrix( nns_MATRIX, node.InvInitMtx );
        AppMain.nnMultiplyMatrix( dest_mtx, dest_mtx, nns_MATRIX );
    }

    // Token: 0x06001475 RID: 5237 RVA: 0x000B4643 File Offset: 0x000B2843
    private static void gmBsCmnGetNodeInvWorldMtx( AppMain.NNS_MATRIX dest_mtx, AppMain.NNS_NODE node, AppMain.NNS_MATRIX inv_view_mtx, AppMain.NNS_MATRIX[] mtx_plt )
    {
        AppMain.nnMultiplyMatrix( dest_mtx, inv_view_mtx, mtx_plt[( int )node.iMatrix] );
        AppMain.nnInvertMatrix( dest_mtx, dest_mtx );
        AppMain.nnMultiplyMatrix( dest_mtx, node.InvInitMtx, dest_mtx );
    }
}
