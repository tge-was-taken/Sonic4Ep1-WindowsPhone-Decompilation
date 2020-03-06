using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain 
{
    // Token: 0x06000B1F RID: 2847 RVA: 0x00064510 File Offset: 0x00062710
    private static AppMain.OBS_OBJECT_WORK GmGmkSsOblongInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_OBLONG");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_oblong_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.user_flag = 0U;
        obs_OBJECT_WORK.user_work = 0U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsOblongMain );
        obs_OBJECT_WORK.user_timer = 0;
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            obs_OBJECT_WORK.dir.z = 16384;
        }
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsOblongDrawFunc );
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            col_work.obj_col.width = 24;
            col_work.obj_col.height = 48;
        }
        else
        {
            col_work.obj_col.width = 48;
            col_work.obj_col.height = 24;
        }
        col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
        col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
        col_work.obj_col.attr = 2;
        col_work.obj_col.flag |= 134217760U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B20 RID: 2848 RVA: 0x000646F0 File Offset: 0x000628F0
    public static void GmGmkSsOblongBuild()
    {
        AppMain.gm_gmk_ss_oblong_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 987 ), AppMain.GmGameDatGetGimmickData( 988 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(990);
        AppMain.gm_gmk_ss_oblong_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06000B21 RID: 2849 RVA: 0x00064730 File Offset: 0x00062930
    public static void GmGmkSsOblongFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(987);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_oblong_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_ss_oblong_obj_tvx_list = null;
    }

    // Token: 0x06000B22 RID: 2850 RVA: 0x00064760 File Offset: 0x00062960
    private static void gmGmkSsOblongMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        obj_work.user_work = ( AppMain.g_gm_main_system.sync_time + 1U >> 5 & 3U );
        obj_work.user_timer++;
        if ( obj_work.user_timer >= 48 )
        {
            obj_work.user_timer = 0;
        }
        AppMain.GmGmkSsSquareBounce( obj_work );
    }

    // Token: 0x06000B23 RID: 2851 RVA: 0x000647C8 File Offset: 0x000629C8
    private static void gmGmkSsOblongDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        if ( AppMain.gmGmkSsOblongDrawFunctvx == null )
        {
            AppMain.gmGmkSsOblongDrawFunctvx = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_ss_oblong_obj_tvx_list, 0 ) );
        }
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        uint num = AppMain.GMD_TVX_DISP_LIGHT_DISABLE;
        uint num2 = 0U;
        if ( obj_work.dir.z != 0 )
        {
            num |= AppMain.GMD_TVX_DISP_ROTATE;
            num2 = ( uint )obj_work.dir.z;
        }
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        uint num3 = (uint)(obj_work.user_timer / 3);
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = 0.125f * ( num3 % 8U ) + AppMain.gm_gmk_ss_oblong_mat_color[( int )( ( UIntPtr )obj_work.user_work )].u;
        gms_TVX_EX_WORK.coord.v = 0.125f * ( num3 / 8U ) + AppMain.gm_gmk_ss_oblong_mat_color[( int )( ( UIntPtr )obj_work.user_work )].v;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        AppMain.GmTvxSetModelEx( AppMain.gmGmkSsOblongDrawFunctvx, texlist, ref obj_work.pos, ref obj_work.scale, num, ( short )num2, ref gms_TVX_EX_WORK );
    }
}

