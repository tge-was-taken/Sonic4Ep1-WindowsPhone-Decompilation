using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000247 RID: 583
    public class GMS_GMK_SS_SQR_MAT_CB_PARAM
    {
        // Token: 0x0400582B RID: 22571
        public uint draw_id;
    }

    // Token: 0x06000DC9 RID: 3529 RVA: 0x00079928 File Offset: 0x00077B28
    private static void GmGmkSsSquareBuild()
    {
        AppMain.gm_gmk_ss_square_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 896 ), AppMain.GmGameDatGetGimmickData( 897 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(899);
        AppMain.gm_gmk_ss_square_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06000DCA RID: 3530 RVA: 0x00079968 File Offset: 0x00077B68
    private static void GmGmkSsSquareFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(896);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_square_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_ss_square_obj_tvx_list = null;
    }

    // Token: 0x06000DCB RID: 3531 RVA: 0x000799A0 File Offset: 0x00077BA0
    private static AppMain.OBS_OBJECT_WORK GmGmkSsSquareInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_SQUARE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_square_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.user_flag = ( obs_OBJECT_WORK.user_work = ( uint )( ( eve_rec.flag & 3 ) + 1 ) );
        obs_OBJECT_WORK.user_timer = AppMain.MTM_MATH_CLIP( ( int )eve_rec.left, 0, 8 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsSquareMain );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsSquareDrawFunc );
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        col_work.obj_col.width = 24;
        col_work.obj_col.height = 24;
        col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
        col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
        col_work.obj_col.attr = 2;
        col_work.obj_col.flag |= 134217760U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DCC RID: 3532 RVA: 0x00079B4C File Offset: 0x00077D4C
    private static void GmGmkSsSquareBounce( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_COLLISION_OBJ obj_col = obj_work.col_work.obj_col;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GMS_SPL_STG_WORK gms_SPL_STG_WORK = AppMain.GmSplStageGetWork();
        if ( obj_col.toucher_obj == gms_PLAYER_WORK.obj_work )
        {
            if ( gms_PLAYER_WORK.nudge_timer != 0 && ( gms_SPL_STG_WORK.flag & 2U ) == 0U )
            {
                AppMain.GmPlySeqInitPinballAir( gms_PLAYER_WORK, 0, -17408, 5, false );
                gms_SPL_STG_WORK.flag |= 1U;
                gms_SPL_STG_WORK.flag |= 2U;
            }
            else if ( ( obj_work.user_flag & 2147483648U ) == 0U && ( gms_SPL_STG_WORK.flag & 1U ) == 0U && ( AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd.x ) > 4096 || AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd.y ) > 4096 ) )
            {
                AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
                AppMain.VecFx32 vecFx = AppMain.gmGmkSsSquareNormalizeVectorXY(new AppMain.VecFx32
                {
                    x = obj_work2.prev_pos.x - obj_work.pos.x,
                    y = obj_work2.prev_pos.y - obj_work.pos.y,
                    z = 0
                });
                obj_work2.dir.z = 0;
                int num = AppMain.MTM_MATH_ABS(obj_work2.spd.x);
                int num2 = AppMain.MTM_MATH_ABS(obj_work2.spd.y);
                int num3 = AppMain.FX_Sqrt(AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2));
                num3 /= 2;
                num = AppMain.FX_Mul( vecFx.x, num3 );
                num2 = AppMain.FX_Mul( vecFx.y, num3 );
                AppMain.GmPlySeqInitPinballAir( gms_PLAYER_WORK, num, num2, 5, false );
                gms_SPL_STG_WORK.flag |= 1U;
            }
            obj_work.user_flag |= 2147483648U;
            return;
        }
        obj_work.user_flag &= 2147483647U;
    }

    // Token: 0x06000DCD RID: 3533 RVA: 0x00079D30 File Offset: 0x00077F30
    private static void gmGmkSsSquareMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        uint num = (uint)((obj_work.user_timer >> 3 & 127) + 1);
        if ( num >= 120U )
        {
            num = 0U;
        }
        obj_work.user_timer = ( int )( ( long )( obj_work.user_timer & 7 ) | ( long )( ( long )( ( ulong )num & 127UL ) << 3 ) );
        if ( obj_work.user_timer != 0 )
        {
            uint num2 = (uint)(obj_work.user_timer - 1 & 7);
            uint num3 = num2 + 2U & 7U;
            uint num4 = AppMain.g_gm_main_system.sync_time >> 3 & 7U;
            if ( num2 == num4 || num3 == num4 )
            {
                obj_work.user_work = ( obj_work.user_flag - 2U & 3U ) + 1U;
            }
            else
            {
                obj_work.user_work = ( obj_work.user_flag & 7U );
            }
        }
        AppMain.GmGmkSsSquareBounce( obj_work );
    }

    // Token: 0x06000DCE RID: 3534 RVA: 0x00079DE0 File Offset: 0x00077FE0
    private static AppMain.VecFx32 gmGmkSsSquareNormalizeVectorXY( AppMain.VecFx32 vec )
    {
        AppMain.VecFx32 result = default(AppMain.VecFx32);
        int num = AppMain.FX_Mul(vec.x, vec.x) + AppMain.FX_Mul(vec.y, vec.y);
        num = AppMain.FX_Sqrt( num );
        if ( num == 0 )
        {
            result.x = 4096;
            result.y = 0;
        }
        else
        {
            int v = AppMain.FX_Div(4096, num);
            result.x = AppMain.FX_Mul( vec.x, v );
            result.y = AppMain.FX_Mul( vec.y, v );
        }
        result.z = 0;
        int x = 0;
        int y = 0;
        AppMain.ObjUtilGetRotPosXY( result.x, result.y, ref x, ref y, ( ushort )-AppMain.g_gm_main_system.pseudofall_dir );
        result.x = x;
        result.y = y;
        return result;
    }

    // Token: 0x06000DCF RID: 3535 RVA: 0x00079EB4 File Offset: 0x000780B4
    private static void gmGmkSsSquareDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.TVX_FILE tvx_FILE;
        if ( AppMain.gm_gmk_ss_square_obj_tvx_list.buf[0] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_ss_square_obj_tvx_list, 0 ) );
            AppMain.gm_gmk_ss_square_obj_tvx_list.buf[0] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.gm_gmk_ss_square_obj_tvx_list.buf[0];
        }
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        uint num = (uint)(obj_work.user_timer >> 5 & 31);
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = 0.125f * ( float )( AppMain.gm_gmk_ss_square_uv_parameter[( int )( ( UIntPtr )num )] % 4 ) + AppMain.gm_gmk_ss_square_mat_color[( int )( ( UIntPtr )( obj_work.user_work - 1U ) )].u;
        gms_TVX_EX_WORK.coord.v = 0.125f * ( float )( AppMain.gm_gmk_ss_square_uv_parameter[( int )( ( UIntPtr )num )] / 4 ) + AppMain.gm_gmk_ss_square_mat_color[( int )( ( UIntPtr )( obj_work.user_work - 1U ) )].v;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        AppMain.GmTvxSetModelEx( tvx_FILE, texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_LIGHT_DISABLE, 0, ref gms_TVX_EX_WORK );
    }
}