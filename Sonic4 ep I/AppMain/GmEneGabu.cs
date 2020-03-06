using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000959 RID: 2393 RVA: 0x00054712 File Offset: 0x00052912
    private static void GmEneGabuBuild()
    {
        AppMain.gm_ene_gabu_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 664 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 665 ) ), 0U );
    }

    // Token: 0x0600095A RID: 2394 RVA: 0x00054740 File Offset: 0x00052940
    private static void GmEneGabuFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(664));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_gabu_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600095B RID: 2395 RVA: 0x00054774 File Offset: 0x00052974
    private static AppMain.OBS_OBJECT_WORK GmEneGabuInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "ENE_GABU");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_gabu_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 666 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -16, 11, 16 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -24, 19, 24 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -24, 19, 24 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.move_flag |= 384U;
        obs_OBJECT_WORK.view_out_ofst_plus[1] = -256;
        int num = (int)(-(int)eve_rec.top) << 13;
        if ( num <= 0 )
        {
            num = 393216;
        }
        int num2 = (int)(eve_rec.flag & 7);
        if ( num2 <= 3 )
        {
            obs_OBJECT_WORK.user_timer = -24576 + -1024 * num2;
        }
        else
        {
            obs_OBJECT_WORK.user_timer = -24576 - -1024 * ( num2 - 3 );
        }
        int denom = AppMain.FX_Div(num * 2, -obs_OBJECT_WORK.user_timer);
        obs_OBJECT_WORK.spd_fall = AppMain.FX_Div( -obs_OBJECT_WORK.user_timer, denom );
        obs_OBJECT_WORK.user_work = ( uint )obs_OBJECT_WORK.pos.y;
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 1 );
        obs_OBJECT_WORK.disp_flag |= 4U;
        AppMain.gmEneGabuJumpInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600095C RID: 2396 RVA: 0x00054958 File Offset: 0x00052B58
    private static void gmEneGabuJumpInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3d.act_id[0] != 1 )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 1 );
            obj_work.disp_flag |= 4U;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGabuJumpMain );
        obj_work.spd.y = obj_work.user_timer;
    }

    // Token: 0x0600095D RID: 2397 RVA: 0x000549B4 File Offset: 0x00052BB4
    private static void gmEneGabuJumpMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3d.act_id[0] != 2 && obj_work.spd.y < 0 && -obj_work.spd.y / obj_work.spd_fall <= 20 )
        {
            AppMain.ObjDrawObjectActionSet( obj_work, 2 );
        }
        if ( obj_work.obj_3d.act_id[0] == 2 && ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 0 );
            obj_work.disp_flag |= 4U;
        }
        if ( obj_work.pos.y >= ( int )obj_work.user_work )
        {
            if ( ( ( ( AppMain.GMS_ENEMY_COM_WORK )obj_work ).eve_rec.flag & 128 ) != 0 )
            {
                AppMain.gmEneGabuJumpWaitInit( obj_work );
                return;
            }
            AppMain.gmEneGabuJumpInit( obj_work );
        }
    }

    // Token: 0x0600095E RID: 2398 RVA: 0x00054A64 File Offset: 0x00052C64
    private static void gmEneGabuJumpWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 1 );
        obj_work.disp_flag |= 4U;
        obj_work.user_flag = 61440U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGabuJumpWaitMain );
        obj_work.spd.y = 0;
        obj_work.move_flag &= 4294967167U;
    }

    // Token: 0x0600095F RID: 2399 RVA: 0x00054AC8 File Offset: 0x00052CC8
    private static void gmEneGabuJumpWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_flag = ( uint )AppMain.ObjTimeCountDown( ( int )obj_work.user_flag );
        if ( obj_work.user_flag == 0U )
        {
            obj_work.move_flag |= 128U;
            AppMain.gmEneGabuJumpInit( obj_work );
        }
    }
}