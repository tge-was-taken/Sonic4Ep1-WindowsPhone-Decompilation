using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001B2 RID: 434
    public class GMS_GMK_NEEDLE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002210 RID: 8720 RVA: 0x001422DB File Offset: 0x001404DB
        public GMS_GMK_NEEDLE_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002211 RID: 8721 RVA: 0x001422EF File Offset: 0x001404EF
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004FB9 RID: 20409
        public AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004FBA RID: 20410
        public int timer;

        // Token: 0x04004FBB RID: 20411
        public uint state;

        // Token: 0x04004FBC RID: 20412
        public int scale_timer;

        // Token: 0x04004FBD RID: 20413
        public uint scale_flag;

        // Token: 0x04004FBE RID: 20414
        public ushort needle_type;

        // Token: 0x04004FBF RID: 20415
        public ushort is_first_disp;

        // Token: 0x04004FC0 RID: 20416
        public uint color;
    }

    // Token: 0x060008C0 RID: 2240 RVA: 0x0004F090 File Offset: 0x0004D290
    private static AppMain.OBS_OBJECT_WORK GmGmkNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_NEEDLE_WORK(), "GMK_NEEDLE_MAIN");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        gms_GMK_NEEDLE_WORK.needle_type = AppMain.GmGmkNeedleGetType( eve_rec.id );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_needle_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleDrawFunc );
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = ( ushort )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][0];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = ( ushort )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][1];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][2];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][3];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.dir = ( ushort )( 16384 * gms_GMK_NEEDLE_WORK.needle_type );
        obs_OBJECT_WORK.pos.z = -4096;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][0], ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][1], -500, ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][2], ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][3], 500 );
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            if ( gms_GMK_NEEDLE_WORK.needle_type == 1 )
            {
                AppMain.OBS_RECT rect = obs_RECT_WORK.rect;
                rect.left -= 16;
            }
            else if ( gms_GMK_NEEDLE_WORK.needle_type == 3 )
            {
                AppMain.OBS_RECT rect2 = obs_RECT_WORK.rect;
                rect2.right += 16;
            }
        }
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK.flag |= 1024U;
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
            obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 4U;
        }
        obs_OBJECT_WORK.move_flag |= 8449U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_GMK_NEEDLE_WORK.state = 0U;
        AppMain.gmGmkNeedleFwInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.flag |= 1073741824U;
        gms_GMK_NEEDLE_WORK.color = uint.MaxValue;
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            gms_GMK_NEEDLE_WORK.color = 4288717055U;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            gms_GMK_NEEDLE_WORK.color = 2694881535U;
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x060008C1 RID: 2241 RVA: 0x0004F37C File Offset: 0x0004D57C
    private static AppMain.OBS_OBJECT_WORK GmGmkActNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_NEEDLE_WORK(), "GMK_NEEDLE_ACT_MAIN");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        gms_GMK_NEEDLE_WORK.needle_type = AppMain.GmGmkNeedleGetType( eve_rec.id );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_needle_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleDrawFunc );
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = ( ushort )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][0];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = ( ushort )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][1];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][2];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )AppMain.gm_gmk_col_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][3];
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.dir = ( ushort )( 32768 * ( gms_GMK_NEEDLE_WORK.needle_type - 4 ) );
        obs_OBJECT_WORK.pos.z = -4096;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][0], ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][1], -500, ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][2], ( short )AppMain.gm_gmk_atk_rect_tbl[( int )gms_GMK_NEEDLE_WORK.needle_type][3], 500 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK.flag |= 1024U;
        obs_OBJECT_WORK.move_flag |= 8449U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        obs_OBJECT_WORK.scale.y = 4096;
        AppMain.amFlagOn( ref obs_OBJECT_WORK.flag, 2U );
        AppMain.amFlagOff( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
        gms_GMK_NEEDLE_WORK.state = 0U;
        gms_GMK_NEEDLE_WORK.is_first_disp = 1;
        gms_GMK_NEEDLE_WORK.timer = -30;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkActNeedleFwMain );
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
            obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 4U;
        }
        gms_GMK_NEEDLE_WORK.color = uint.MaxValue;
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            gms_GMK_NEEDLE_WORK.color = 4288717055U;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            gms_GMK_NEEDLE_WORK.color = 2694881535U;
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x060008C2 RID: 2242 RVA: 0x0004F66F File Offset: 0x0004D86F
    private static AppMain.OBS_OBJECT_WORK GmGmkBackNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        return null;
    }

    // Token: 0x060008C3 RID: 2243 RVA: 0x0004F672 File Offset: 0x0004D872
    private static AppMain.OBS_OBJECT_WORK GmGmkStandNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        return null;
    }

    // Token: 0x060008C4 RID: 2244 RVA: 0x0004F678 File Offset: 0x0004D878
    public static void GmGmkNeedleBuild()
    {
        AppMain.gm_gmk_needle_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 822 ), AppMain.GmGameDatGetGimmickData( 823 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(824);
        AppMain.gm_gmk_needle_obj_tvx_list = ams_AMB_HEADER;
        AppMain.tvx_needle = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_needle_obj_tvx_list, 0 ) );
        AppMain.tvx_stand = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_needle_obj_tvx_list, 1 ) );
    }

    // Token: 0x060008C5 RID: 2245 RVA: 0x0004F6EC File Offset: 0x0004D8EC
    public static void GmGmkNeedleFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(822));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_needle_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_needle_obj_3d_list = null;
        AppMain.gm_gmk_needle_obj_tvx_list = null;
    }

    // Token: 0x060008C6 RID: 2246 RVA: 0x0004F728 File Offset: 0x0004D928
    private static void gmGmkNeedleFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkNeedleFwMain );
    }

    // Token: 0x060008C7 RID: 2247 RVA: 0x0004F758 File Offset: 0x0004D958
    private static void gmGmkNeedleFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        if ( gms_GMK_NEEDLE_WORK.needle_type == 0 )
        {
            AppMain.OBS_OBJECT_WORK rider_obj = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.rider_obj;
            if ( rider_obj != null && rider_obj.ride_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_3D_WORK )
            {
                if ( rider_obj.obj_type == 1 )
                {
                    obs_RECT_WORK.flag |= 4U;
                    return;
                }
            }
            else
            {
                obs_RECT_WORK.flag &= 4294967291U;
            }
        }
    }

    // Token: 0x060008C8 RID: 2248 RVA: 0x0004F7D8 File Offset: 0x0004D9D8
    private static void gmGmkActNeedleFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        if ( gms_GMK_NEEDLE_WORK.state == 0U )
        {
            AppMain.amFlagOff( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
        }
        else
        {
            AppMain.amFlagOn( ref obj_work.flag, 2U );
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkActNeedleFwMain );
    }

    // Token: 0x060008C9 RID: 2249 RVA: 0x0004F83C File Offset: 0x0004DA3C
    private static void gmGmkActNeedleFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        if ( gms_GMK_NEEDLE_WORK.needle_type == 4 )
        {
            AppMain.OBS_OBJECT_WORK rider_obj = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.rider_obj;
            if ( rider_obj != null && rider_obj.ride_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_3D_WORK )
            {
                if ( rider_obj.obj_type == 1 )
                {
                    AppMain.amFlagOff( ref obj_work.flag, 2U );
                }
            }
            else
            {
                AppMain.amFlagOn( ref obj_work.flag, 2U );
            }
        }
        if ( gms_GMK_NEEDLE_WORK.timer >= 60 )
        {
            gms_GMK_NEEDLE_WORK.timer = 0;
            AppMain.gmGmkActNeedleScalingInit( obj_work );
        }
        else
        {
            gms_GMK_NEEDLE_WORK.timer++;
        }
        if ( ( gms_GMK_NEEDLE_WORK.scale_flag & 1U ) != 0U )
        {
            AppMain.gmGmkActNeedleSetScaleColRect( obj_work );
        }
    }

    // Token: 0x060008CA RID: 2250 RVA: 0x0004F8F0 File Offset: 0x0004DAF0
    private static void gmGmkActNeedleScalingInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        if ( gms_GMK_NEEDLE_WORK.state == 1U )
        {
            AppMain.amFlagOn( ref obj_work.flag, 2U );
            AppMain.amFlagOn( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
            gms_GMK_NEEDLE_WORK.scale_flag |= 1U;
            gms_GMK_NEEDLE_WORK.scale_flag |= 4U;
        }
        else if ( gms_GMK_NEEDLE_WORK.is_first_disp == 0 )
        {
            obj_work.scale.y = 256;
            gms_GMK_NEEDLE_WORK.scale_flag |= 1U;
            gms_GMK_NEEDLE_WORK.scale_flag |= 2U;
        }
        else
        {
            gms_GMK_NEEDLE_WORK.scale_flag |= 1U;
            gms_GMK_NEEDLE_WORK.scale_flag |= 4U;
        }
        if ( gms_GMK_NEEDLE_WORK.is_first_disp != 0 )
        {
            AppMain.amFlagOn( ref obj_work.flag, 2U );
            AppMain.amFlagOn( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
            gms_GMK_NEEDLE_WORK.state = 1U;
            gms_GMK_NEEDLE_WORK.is_first_disp = 0;
        }
        AppMain.amFlagOff( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
        if ( gms_GMK_NEEDLE_WORK.needle_type == 4 )
        {
            AppMain.OBS_OBJECT_WORK rider_obj = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.rider_obj;
            if ( rider_obj != null && rider_obj.ride_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_3D_WORK )
            {
                if ( rider_obj.obj_type == 1 )
                {
                    AppMain.amFlagOff( ref obj_work.flag, 2U );
                }
            }
            else
            {
                AppMain.amFlagOn( ref obj_work.flag, 2U );
            }
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkActNeedleScalingMain );
    }

    // Token: 0x060008CB RID: 2251 RVA: 0x0004FA74 File Offset: 0x0004DC74
    private static void gmGmkActNeedleScalingMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        if ( gms_GMK_NEEDLE_WORK.timer >= 6 )
        {
            gms_GMK_NEEDLE_WORK.timer = 0;
            AppMain.gmGmkActNeedleRectWaitInit( obj_work );
            return;
        }
        AppMain.amFlagOn( ref obj_work.flag, 2U );
        if ( gms_GMK_NEEDLE_WORK.state == 0U )
        {
            obj_work.scale.y = obj_work.scale.y + 682;
        }
        else
        {
            obj_work.scale.y = obj_work.scale.y - 682;
        }
        if ( obj_work.scale.y > 4096 )
        {
            obj_work.scale.y = 4096;
        }
        else if ( obj_work.scale.y <= 0 )
        {
            obj_work.scale.y = 0;
        }
        AppMain.amFlagOff( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
        obj_work.scale.y = AppMain.MTM_MATH_CLIP( obj_work.scale.y, 0, 4096 );
        if ( ( gms_GMK_NEEDLE_WORK.scale_flag & 1U ) != 0U )
        {
            AppMain.gmGmkActNeedleSetScaleColRect( obj_work );
        }
        if ( gms_GMK_NEEDLE_WORK.needle_type == 4 )
        {
            AppMain.OBS_OBJECT_WORK rider_obj = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.rider_obj;
            if ( rider_obj != null && rider_obj.ride_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_3D_WORK )
            {
                if ( rider_obj.obj_type == 1 )
                {
                    AppMain.amFlagOff( ref obj_work.flag, 2U );
                }
            }
            else
            {
                AppMain.amFlagOn( ref obj_work.flag, 2U );
            }
        }
        gms_GMK_NEEDLE_WORK.timer++;
    }

    // Token: 0x060008CC RID: 2252 RVA: 0x0004FBE4 File Offset: 0x0004DDE4
    private static void gmGmkActNeedleRectWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkActNeedleRectWaitMain );
    }

    // Token: 0x060008CD RID: 2253 RVA: 0x0004FC14 File Offset: 0x0004DE14
    private static void gmGmkActNeedleRectWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.amFlagOff( ref gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag, 256U );
        AppMain.gmGmkActNeedleFwInit( obj_work );
        gms_GMK_NEEDLE_WORK.state ^= 1U;
        if ( gms_GMK_NEEDLE_WORK.state == 1U )
        {
            AppMain.GmSoundPlaySE( "Spine" );
        }
        if ( ( gms_GMK_NEEDLE_WORK.scale_flag & 1U ) != 0U )
        {
            AppMain.gmGmkActNeedleSetScaleColRect( obj_work );
        }
    }

    // Token: 0x060008CE RID: 2254 RVA: 0x0004FC94 File Offset: 0x0004DE94
    private static ushort GmGmkNeedleGetType( ushort type )
    {
        ushort result;
        if ( type < 97 )
        {
            ushort num = (ushort)(type - 91);
            result = ( ushort )AppMain.gm_gmk_ndl_type_tbl[( int )num];
        }
        else
        {
            ushort num = (ushort)(type - 97);
            num = ( ushort )( 4 + num );
            result = ( ushort )AppMain.gm_gmk_ndl_type_tbl[( int )num];
        }
        return result;
    }

    // Token: 0x060008CF RID: 2255 RVA: 0x0004FCD0 File Offset: 0x0004DED0
    private static void gmGmkActNeedleSetScaleColRect( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)gms_ENEMY_3D_WORK;
        gms_GMK_NEEDLE_WORK.scale_timer++;
        if ( ( gms_GMK_NEEDLE_WORK.scale_flag & 4U ) != 0U )
        {
            int num = (int)(gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height - 3);
            if ( num < 0 )
            {
                num = 0;
                gms_GMK_NEEDLE_WORK.scale_timer = 0;
                gms_GMK_NEEDLE_WORK.scale_flag &= 4294967294U;
                gms_GMK_NEEDLE_WORK.scale_flag &= 4294967291U;
            }
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = ( ushort )num;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )( -1 * ( int )gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height );
            return;
        }
        if ( ( gms_GMK_NEEDLE_WORK.scale_flag & 2U ) != 0U )
        {
            int num = (int)(gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height + 4);
            if ( num > 32 )
            {
                num = 32;
                gms_GMK_NEEDLE_WORK.scale_timer = 0;
                gms_GMK_NEEDLE_WORK.scale_flag &= 4294967294U;
                gms_GMK_NEEDLE_WORK.scale_flag &= 4294967293U;
            }
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = ( ushort )num;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )( -1 * ( int )gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height );
        }
    }

    // Token: 0x060008D0 RID: 2256 RVA: 0x0004FE28 File Offset: 0x0004E028
    private static void gmGmkNeedleDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.GMS_ENEMY_3D_WORK work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_NEEDLE_WORK gms_GMK_NEEDLE_WORK = (AppMain.GMS_GMK_NEEDLE_WORK)work;
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        AppMain.VecFx32 vecFx2 = new AppMain.VecFx32(4096, 4096, 4096);
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        short num = (short)(-49152 * (int)gms_GMK_NEEDLE_WORK.needle_type);
        if ( gms_GMK_NEEDLE_WORK.needle_type == 5 )
        {
            num = short.MinValue;
        }
        obj_work.dir.z = ( ushort )( -( ushort )num );
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = 0f;
        gms_TVX_EX_WORK.coord.v = 0f;
        gms_TVX_EX_WORK.color = gms_GMK_NEEDLE_WORK.color;
        for ( int i = 0; i < 5; i++ )
        {
            vecFx.z = obj_work.pos.z;
            if ( i >= 3 )
            {
                vecFx.z -= 8192;
            }
            switch ( gms_GMK_NEEDLE_WORK.needle_type )
            {
                case 0:
                case 4:
                    vecFx.x = obj_work.pos.x + AppMain.gm_gmk_disp_ofst_tbl_u[i][0];
                    vecFx.y = obj_work.pos.y + AppMain.gm_gmk_disp_ofst_tbl_u[i][1];
                    break;
                case 1:
                case 5:
                    vecFx.x = obj_work.pos.x + AppMain.gm_gmk_disp_ofst_tbl_l[i][0];
                    vecFx.y = obj_work.pos.y + AppMain.gm_gmk_disp_ofst_tbl_l[i][1];
                    break;
                case 2:
                    vecFx.x = obj_work.pos.x + AppMain.gm_gmk_disp_ofst_tbl_d[i][0];
                    vecFx.y = obj_work.pos.y + AppMain.gm_gmk_disp_ofst_tbl_d[i][1];
                    break;
                case 3:
                    vecFx.x = obj_work.pos.x + AppMain.gm_gmk_disp_ofst_tbl_r[i][0];
                    vecFx.y = obj_work.pos.y + AppMain.gm_gmk_disp_ofst_tbl_r[i][1];
                    break;
            }
            AppMain.GmTvxSetModelEx( AppMain.tvx_needle, texlist, ref vecFx, ref obj_work.scale, AppMain.GMD_TVX_DISP_ROTATE | AppMain.GMD_TVX_DISP_SCALE | AppMain.GMD_TVX_DISP_LIGHT_DISABLE, num, ref gms_TVX_EX_WORK );
            AppMain.GmTvxSetModel( AppMain.tvx_stand, texlist, ref vecFx, ref vecFx2, AppMain.GMD_TVX_DISP_ROTATE | AppMain.GMD_TVX_DISP_SCALE, num );
        }
    }

    // Token: 0x060008D1 RID: 2257 RVA: 0x000500A4 File Offset: 0x0004E2A4
    public static void GmGmkNeedleSetLight()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            nns_VECTOR.x = -0.1f;
            nns_VECTOR.y = -0.09f;
            nns_VECTOR.z = -0.93f;
        }
        else
        {
            nns_VECTOR.x = -1f;
            nns_VECTOR.y = -1f;
            nns_VECTOR.z = -1f;
        }
        nns_RGBA.r = 1f;
        nns_RGBA.g = 1f;
        nns_RGBA.b = 1f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        float intensity;
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            intensity = 0.8f;
        }
        else
        {
            intensity = 1f;
        }
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_2, ref nns_RGBA, intensity, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }
}
