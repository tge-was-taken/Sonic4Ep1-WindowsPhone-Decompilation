using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000775 RID: 1909 RVA: 0x00041E20 File Offset: 0x00040020
    private static void GmGmkSsCircleBuild()
    {
        AppMain.gm_gmk_ss_circle_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 900 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 901 ) ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(902));
        AppMain.gm_gmk_ss_circle_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06000776 RID: 1910 RVA: 0x00041E6C File Offset: 0x0004006C
    private static void GmGmkSsCircleFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(900));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_circle_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_ss_circle_obj_tvx_list = null;
    }

    // Token: 0x06000777 RID: 1911 RVA: 0x00041EA8 File Offset: 0x000400A8
    private static AppMain.OBS_OBJECT_WORK GmGmkSsCircleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_CIRCLE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_circle_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.user_flag = 0U;
        if ( eve_rec.id == 194 )
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsOnewayMain );
            obs_OBJECT_WORK.disp_flag |= 134217728U;
            obs_OBJECT_WORK.obj_3d.drawflag |= 8388608U;
            obs_OBJECT_WORK.obj_3d.draw_state.alpha.alpha = 0.5f;
        }
        else
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsCircleMain );
            AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
            col_work.obj_col.obj = obs_OBJECT_WORK;
            col_work.obj_col.diff_data = AppMain.g_gm_default_col;
            col_work.obj_col.width = 24;
            col_work.obj_col.height = 24;
            col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
            col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
            col_work.obj_col.attr = 2;
            col_work.obj_col.flag |= 134217760U;
        }
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsCircleDrawFunc );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000778 RID: 1912 RVA: 0x00042094 File Offset: 0x00040294
    private static void GmGmkSsOnewayThrough( uint sw_no )
    {
        AppMain.GmSplStageSwSet( sw_no );
    }

    // Token: 0x06000779 RID: 1913 RVA: 0x0004209C File Offset: 0x0004029C
    private static void gmGmkSsCircleMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        if ( ( AppMain.g_gm_main_system.sync_time & 15U ) == 0U )
        {
            obj_work.dir.z = ( ushort )( obj_work.dir.z + 8192 );
        }
        AppMain.GmGmkSsSquareBounce( obj_work );
    }

    // Token: 0x0600077A RID: 1914 RVA: 0x000420F4 File Offset: 0x000402F4
    private static void gmGmkSsOnewayMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        if ( AppMain.GmSplStageSwCheck( ( uint )gms_ENEMY_3D_WORK.ene_com.eve_rec.flag ) )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsCircleMain );
            AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
            col_work.obj_col.obj = obj_work;
            col_work.obj_col.diff_data = AppMain.g_gm_default_col;
            col_work.obj_col.width = 24;
            col_work.obj_col.height = 24;
            col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
            col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
            col_work.obj_col.attr = 2;
            col_work.obj_col.flag |= 134217760U;
            obj_work.disp_flag &= 4160749567U;
            obj_work.obj_3d.drawflag &= 4286578687U;
            obj_work.obj_3d.draw_state.alpha.alpha = 1f;
        }
        AppMain.GmGmkSsSquareBounce( obj_work );
    }

    // Token: 0x0600077B RID: 1915 RVA: 0x00042234 File Offset: 0x00040434
    private static void gmGmkSsCircleDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
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
        if ( AppMain.gm_gmk_ss_circle_obj_tvx_list.buf[0] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_ss_circle_obj_tvx_list, 0 ) );
            AppMain.gm_gmk_ss_circle_obj_tvx_list.buf[0] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.gm_gmk_ss_circle_obj_tvx_list.buf[0];
        }
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        uint num = AppMain.GMD_TVX_DISP_LIGHT_DISABLE | AppMain.GMD_TVX_DISP_ROTATE;
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = 0f;
        gms_TVX_EX_WORK.coord.v = 0f;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        if ( obj_work.obj_3d.draw_state.alpha.alpha == 0.5f )
        {
            gms_TVX_EX_WORK.color = 4294967176U;
            num |= AppMain.GMD_TVX_DISP_BLEND;
        }
        AppMain.GmTvxSetModelEx( tvx_FILE, texlist, ref obj_work.pos, ref obj_work.scale, num, ( short )( -( short )obj_work.dir.z ), ref gms_TVX_EX_WORK );
    }
}