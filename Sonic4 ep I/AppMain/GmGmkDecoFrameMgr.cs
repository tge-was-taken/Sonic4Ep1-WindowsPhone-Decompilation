using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060004EF RID: 1263 RVA: 0x0002A404 File Offset: 0x00028604
    private static AppMain.OBS_OBJECT_WORK GmGmkDecoFrameMgrInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        if ( eve_rec.byte_param[1] != 0 )
        {
            eve_rec.pos_x = byte.MaxValue;
            return null;
        }
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            int index = 0;
            if ( eve_rec.id == 293 )
            {
                index = 1;
            }
            AppMain.GmDecoSetFrameMotion( 0, index );
            eve_rec.pos_x = byte.MaxValue;
            eve_rec.byte_param[1] = 1;
            return null;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.gmGmkDecoFrameMgrLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.gmGmkDecoFrameMgrInit( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060004F0 RID: 1264 RVA: 0x0002A480 File Offset: 0x00028680
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkDecoFrameMgrLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_DECO_FRAME_MGR");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x060004F1 RID: 1265 RVA: 0x0002A4F4 File Offset: 0x000286F4
    private static void gmGmkDecoFrameMgrInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 32U;
        obj_work.move_flag |= 8448U;
        obj_work.flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDecoFrameMgrMainFunc );
        obj_work.ppOut = null;
        obj_work.ppMove = null;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        obj_work.user_timer = ( int )( gms_ENEMY_3D_WORK.ene_com.eve_rec.byte_param[1] * 2 );
    }

    // Token: 0x060004F2 RID: 1266 RVA: 0x0002A574 File Offset: 0x00028774
    private static void gmGmkDecoFrameMgrMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer >= 510 )
        {
            obj_work.flag |= 4U;
            return;
        }
        obj_work.user_timer++;
        int index = 0;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id == 293 )
        {
            index = 1;
        }
        AppMain.GmDecoSetFrameMotion( obj_work.user_timer, index );
        gms_ENEMY_3D_WORK.ene_com.eve_rec.byte_param[1] = ( byte )( obj_work.user_timer / 2 );
    }
}