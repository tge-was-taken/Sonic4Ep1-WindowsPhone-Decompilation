using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001559 RID: 5465 RVA: 0x000B97D0 File Offset: 0x000B79D0
    private static AppMain.OBS_OBJECT_WORK GmGmkLoopInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkLoopLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkLoopInit( obj_work );
        return obj_work;
    }

    // Token: 0x0600155A RID: 5466 RVA: 0x000B9804 File Offset: 0x000B7A04
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkLoopLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_LOOP");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x0600155B RID: 5467 RVA: 0x000B9878 File Offset: 0x000B7A78
    private static void gmGmkLoopInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkLoopSetRect( obj_work );
        obj_work.move_flag |= 8448U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLoopMainFunc );
    }

    // Token: 0x0600155C RID: 5468 RVA: 0x000B98A4 File Offset: 0x000B7AA4
    private static void gmGmkLoopSetRect( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        short cLeft = (short)(-gms_ENEMY_3D_WORK.ene_com.eve_rec.width * 64 / 2);
        short cRight = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.width * 64 / 2);
        short cTop = (short)(-gms_ENEMY_3D_WORK.ene_com.eve_rec.height * 64 / 2);
        short cBottom = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.height * 64 / 2);
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, cLeft, cTop, -500, cRight, cBottom, 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkLoopDefFunc );
    }

    // Token: 0x0600155D RID: 5469 RVA: 0x000B9970 File Offset: 0x000B7B70
    private static void gmGmkLoopDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.UNREFERENCED_PARAMETER( target_rect );
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        parent_obj.user_flag |= 1U;
    }

    // Token: 0x0600155E RID: 5470 RVA: 0x000B9998 File Offset: 0x000B7B98
    private static void gmGmkLoopMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.user_flag & 1U ) != 0U )
        {
            AppMain.gmGmkLoopExecute( obj_work );
            obj_work.user_flag &= 4294967294U;
        }
    }

    // Token: 0x0600155F RID: 5471 RVA: 0x000B99BC File Offset: 0x000B7BBC
    private static void gmGmkLoopExecute( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int loop_x = (int)(gms_ENEMY_3D_WORK.ene_com.eve_rec.left * 64) * 4096;
        int loop_y = (int)(gms_ENEMY_3D_WORK.ene_com.eve_rec.top * 64) * 4096;
        AppMain.gmGmkLoopExecuteObj( loop_x, loop_y, 1 );
        AppMain.gmGmkLoopExecuteObj( loop_x, loop_y, 2 );
        AppMain.gmGmkLoopExecuteEffect( loop_x, loop_y );
        AppMain.gmGmkLoopExecuteRing( loop_x, loop_y );
        AppMain.gmGmkLoopExecuteCamera( loop_x, loop_y );
        AppMain.GmEveMgrCreateEventLcd( 0U );
    }

    // Token: 0x06001560 RID: 5472 RVA: 0x000B9A30 File Offset: 0x000B7C30
    private static void gmGmkLoopExecuteObj( int loop_x, int loop_y, int obj_type )
    {
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, ( ushort )obj_type ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ( ushort )obj_type ) )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + loop_x;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + loop_y;
        }
    }

    // Token: 0x06001561 RID: 5473 RVA: 0x000B9A7C File Offset: 0x000B7C7C
    private static void gmGmkLoopExecuteEffect( int loop_x, int loop_y )
    {
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 5 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 5 ) )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + loop_x;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + loop_y;
            if ( obs_OBJECT_WORK.obj_3des != null )
            {
                AppMain.GmEffect3DESSetDuplicateDraw( ( AppMain.GMS_EFFECT_3DES_WORK )obs_OBJECT_WORK, AppMain.FX_FX32_TO_F32( loop_x ), AppMain.FX_FX32_TO_F32( loop_y ), 0f );
            }
        }
    }

    // Token: 0x06001562 RID: 5474 RVA: 0x000B9AE8 File Offset: 0x000B7CE8
    private static void gmGmkLoopExecuteRing( int loop_x, int loop_y )
    {
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.GmRingGetWork();
        for ( AppMain.GMS_RING_WORK gms_RING_WORK = gms_RING_SYS_WORK.damage_ring_list_start; gms_RING_WORK != null; gms_RING_WORK = gms_RING_WORK.post_ring )
        {
            AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
            gms_RING_WORK2.pos.x = gms_RING_WORK2.pos.x + loop_x;
            AppMain.GMS_RING_WORK gms_RING_WORK3 = gms_RING_WORK;
            gms_RING_WORK3.pos.y = gms_RING_WORK3.pos.y + loop_y;
        }
    }

    // Token: 0x06001563 RID: 5475 RVA: 0x000B9B34 File Offset: 0x000B7D34
    private static void gmGmkLoopExecuteCamera( int loop_x, int loop_y )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        AppMain.GmCameraPosSet( AppMain.FX_F32_TO_FX32( obs_CAMERA.pos.x ) + loop_x, -AppMain.FX_F32_TO_FX32( obs_CAMERA.pos.y ) + loop_y, AppMain.FX_F32_TO_FX32( obs_CAMERA.pos.z ) );
        AppMain.ObjObjectCameraSet( AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obs_CAMERA.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obs_CAMERA.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ) );
        AppMain.GmCameraSetClipCamera( obs_CAMERA );
    }
}
