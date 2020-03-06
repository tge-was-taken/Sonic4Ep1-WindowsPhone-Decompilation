using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060018A1 RID: 6305 RVA: 0x000E0654 File Offset: 0x000DE854
    private static AppMain.OBS_OBJECT_WORK GmGmkScrewInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_SCREW");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 8480U;
        gms_ENEMY_COM_WORK.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_COM_WORK.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        obs_RECT_WORK.ppHit = null;
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkScrewDefFunc );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        if ( ( ( int )eve_rec.flag & AppMain.GMD_GMK_SCREW_EVE_FLAG_LEFT ) != 0 )
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -4, -8, -16, 0 );
        }
        else
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, 4, -8, 16, 0 );
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkScrewMain );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060018A2 RID: 6306 RVA: 0x000E0748 File Offset: 0x000DE948
    private static void gmGmkScrewMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.seq_state != 38 && gms_PLAYER_WORK.gmk_obj != obj_work )
        {
            obj_work.flag &= 4294967279U;
        }
    }

    // Token: 0x060018A3 RID: 6307 RVA: 0x000E0788 File Offset: 0x000DE988
    private static void gmGmkScrewDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state == 38 )
        {
            return;
        }
        int spd = gms_PLAYER_WORK.spd3;
        ushort flag = gms_ENEMY_COM_WORK.eve_rec.flag;
        if ( ( ( gms_PLAYER_WORK.obj_work.spd_m >= spd && ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_SCREW_EVE_FLAG_LEFT ) == 0 ) || ( gms_PLAYER_WORK.obj_work.spd_m <= -spd && ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_SCREW_EVE_FLAG_LEFT ) != 0 ) ) && ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmPlySeqInitScrew( gms_PLAYER_WORK, gms_ENEMY_COM_WORK, gms_ENEMY_COM_WORK.obj_work.pos.x, gms_ENEMY_COM_WORK.obj_work.pos.y, flag );
            gms_ENEMY_COM_WORK.obj_work.flag |= 16U;
        }
    }
}
