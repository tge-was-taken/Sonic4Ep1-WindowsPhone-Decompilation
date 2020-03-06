using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000DD0 RID: 3536 RVA: 0x00079FE0 File Offset: 0x000781E0
    private static AppMain.OBS_OBJECT_WORK GmGmkSsArrowInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_ARROW");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_arrow_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsArrowMain );
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, 0, AppMain.readAMBFile( AppMain.ObjDataGet( 986 ).pData ) );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.dir.z = ( ushort )( eve_rec.width << 8 );
        int num = (int)(AppMain.g_gm_main_system.sync_time % 24U);
        int num2 = AppMain.MTM_MATH_CLIP((int)eve_rec.left, 0, 3) << 3;
        num -= num2;
        if ( num < 0 )
        {
            num += 24;
        }
        obs_OBJECT_WORK.user_timer = num;
        gms_ENEMY_3D_WORK.obj_3d.mat_frame = ( float )num;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DD1 RID: 3537 RVA: 0x0007A130 File Offset: 0x00078330
    public static void GmGmkSsArrowBuild()
    {
        AppMain.gm_gmk_ss_arrow_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 984 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 985 ) ), 0U );
    }

    // Token: 0x06000DD2 RID: 3538 RVA: 0x0007A15C File Offset: 0x0007835C
    public static void GmGmkSsArrowFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(984));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_arrow_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000DD3 RID: 3539 RVA: 0x0007A18C File Offset: 0x0007838C
    private static void gmGmkSsArrowMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() && ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        obj_work.user_timer++;
        if ( obj_work.user_timer >= 24 )
        {
            obj_work.user_timer = 0;
            AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        }
    }
}
