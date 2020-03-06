using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001564 RID: 5476 RVA: 0x000B9BFC File Offset: 0x000B7DFC
    private static AppMain.OBS_OBJECT_WORK GmGmkForceSpinSetInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_FORCE_SPIN_SET");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        AppMain.ObjRectSet( obs_RECT_WORK.rect, ( short )eve_rec.left, ( short )eve_rec.top, ( short )( eve_rec.width + ( byte )eve_rec.left ), ( short )( eve_rec.height + ( byte )eve_rec.top ) );
        obs_OBJECT_WORK.move_flag |= 8480U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkForceSpinSetMain );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001565 RID: 5477 RVA: 0x000B9CB0 File Offset: 0x000B7EB0
    private static AppMain.OBS_OBJECT_WORK GmGmkForceSpinResetInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_FORCE_SPIN_RESET");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        AppMain.ObjRectSet( obs_RECT_WORK.rect, ( short )eve_rec.left, ( short )eve_rec.top, ( short )( eve_rec.width + ( byte )eve_rec.left ), ( short )( eve_rec.height + ( byte )eve_rec.top ) );
        obs_OBJECT_WORK.move_flag |= 8480U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkForceSpinResetMain );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001566 RID: 5478 RVA: 0x000B9D5C File Offset: 0x000B7F5C
    private static void gmGmkForceSpinSetMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || ( gms_PLAYER_WORK.obj_work.flag & 2U ) != 0U || ( AppMain.g_gm_main_system.game_flag & 262656U ) != 0U )
        {
            return;
        }
        if ( AppMain.gmGmkForceSpinRectChk( obj_work, gms_PLAYER_WORK ) && gms_PLAYER_WORK.seq_state != 51 && gms_PLAYER_WORK.seq_state != 52 && gms_PLAYER_WORK.seq_state != 53 )
        {
            if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 )
            {
                AppMain.GmPlySeqGmkInitForceSpinDec( gms_PLAYER_WORK );
                return;
            }
            AppMain.GmPlySeqGmkInitForceSpin( gms_PLAYER_WORK );
        }
    }

    // Token: 0x06001567 RID: 5479 RVA: 0x000B9DF4 File Offset: 0x000B7FF4
    private static void gmGmkForceSpinResetMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || ( gms_PLAYER_WORK.obj_work.flag & 2U ) != 0U || ( AppMain.g_gm_main_system.game_flag & 262656U ) != 0U )
        {
            return;
        }
        if ( AppMain.gmGmkForceSpinRectChk( obj_work, gms_PLAYER_WORK ) && ( gms_PLAYER_WORK.seq_state == 51 || gms_PLAYER_WORK.seq_state == 52 || gms_PLAYER_WORK.seq_state == 53 ) )
        {
            if ( ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
            {
                gms_PLAYER_WORK.no_spddown_timer = 0;
                if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 )
                {
                    AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 10 );
                    return;
                }
                AppMain.GmPlySeqInitFw( gms_PLAYER_WORK );
                return;
            }
            else
            {
                AppMain.GmPlySeqGmkInitSpinFall( gms_PLAYER_WORK, gms_PLAYER_WORK.obj_work.spd.x, gms_PLAYER_WORK.obj_work.spd.y );
            }
        }
    }

    // Token: 0x06001568 RID: 5480 RVA: 0x000B9ECC File Offset: 0x000B80CC
    private static bool gmGmkForceSpinRectChk( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        return ply_work.obj_work.pos.x >= obj_work.pos.x + ( ( int )obs_RECT_WORK.rect.left << 12 ) && ply_work.obj_work.pos.x <= obj_work.pos.x + ( ( int )obs_RECT_WORK.rect.right << 12 ) && ply_work.obj_work.pos.y >= obj_work.pos.y + ( ( int )obs_RECT_WORK.rect.top << 12 ) && ply_work.obj_work.pos.y <= obj_work.pos.y + ( ( int )obs_RECT_WORK.rect.bottom << 12 );
    }
}