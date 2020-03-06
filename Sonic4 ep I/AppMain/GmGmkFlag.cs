using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060018A4 RID: 6308 RVA: 0x000E0878 File Offset: 0x000DEA78
    private static AppMain.OBS_OBJECT_WORK GmGmkFlagChangeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_FLAG_CNG");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 1, 1 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectSet( obs_RECT_WORK.rect, ( short )eve_rec.left, ( short )eve_rec.top, ( short )( eve_rec.width + ( byte )eve_rec.left ), ( short )( eve_rec.height + ( byte )eve_rec.top ) );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkFlagChangeDefFunc );
        obs_RECT_WORK.parent_obj = obs_OBJECT_WORK;
        obs_RECT_WORK.flag |= 192U;
        obs_OBJECT_WORK.move_flag |= 8480U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060018A5 RID: 6309 RVA: 0x000E0950 File Offset: 0x000DEB50
    private static void gmGmkFlagChangeDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        if ( match_rect.parent_obj == null )
        {
            return;
        }
        if ( match_rect.parent_obj.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_PLAYER_WORK;
        ushort id = gms_ENEMY_COM_WORK.eve_rec.id;
        if ( id <= 162 )
        {
            if ( id <= 99 )
            {
                switch ( id )
                {
                    case 60:
                        if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 128 ) != 0 )
                        {
                            if ( gms_PLAYER_WORK.seq_state != 29 && gms_PLAYER_WORK.seq_state != 49 && gms_PLAYER_WORK.seq_state != 50 && gms_PLAYER_WORK.seq_state != 42 )
                            {
                                return;
                            }
                            gms_PLAYER_WORK.gmk_flag |= 2048U;
                        }
                        if ( obs_OBJECT_WORK.obj_type == 1 && ( obs_OBJECT_WORK.move_flag & 16U ) != 0U )
                        {
                            gms_PLAYER_WORK.gmk_flag |= 1U;
                            if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 16 ) != 0 )
                            {
                                gms_PLAYER_WORK.gmk_flag |= 2U;
                                return;
                            }
                            if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) != 0 )
                            {
                                if ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) == 0U )
                                {
                                    gms_PLAYER_WORK.gmk_flag |= 33554432U;
                                    return;
                                }
                            }
                            else if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 && ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) != 0U )
                            {
                                gms_PLAYER_WORK.gmk_flag |= 33554432U;
                                return;
                            }
                        }
                        break;
                    case 61:
                        obs_OBJECT_WORK.flag &= 4294967294U;
                        if ( obs_OBJECT_WORK.obj_type == 1 )
                        {
                            gms_PLAYER_WORK.graind_prev_ride = 0;
                            return;
                        }
                        break;
                    case 62:
                        obs_OBJECT_WORK.flag |= 1U;
                        if ( obs_OBJECT_WORK.obj_type == 1 )
                        {
                            gms_PLAYER_WORK.graind_prev_ride = 0;
                            return;
                        }
                        break;
                    default:
                        if ( id != 99 )
                        {
                            return;
                        }
                        if ( obs_OBJECT_WORK.obj_type == 1 )
                        {
                            AppMain.GmPlySeqChangeDeath( gms_PLAYER_WORK );
                            return;
                        }
                        break;
                }
            }
            else if ( id != 131 )
            {
                if ( id != 162 )
                {
                    return;
                }
                if ( obs_OBJECT_WORK.obj_type == 1 )
                {
                    AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
                    obs_CAMERA.flag |= 2147483648U;
                    return;
                }
            }
            else if ( obs_OBJECT_WORK.obj_type == 1 )
            {
                ushort flag = gms_ENEMY_COM_WORK.eve_rec.flag;
                short num = (short)(flag & 7);
                if ( ( flag & 8 ) != 0 )
                {
                    num = ( short )-num;
                }
                gms_PLAYER_WORK.gmk_camera_center_ofst_x = ( short )( num << 3 );
                num = ( short )( ( flag & 112 ) >> 4 );
                if ( ( flag & 128 ) != 0 )
                {
                    num = ( short )-num;
                }
                gms_PLAYER_WORK.gmk_camera_center_ofst_y = ( short )( num << 3 );
                return;
            }
        }
        else if ( id <= 277 )
        {
            if ( id != 195 )
            {
                switch ( id )
                {
                    case 276:
                        AppMain.GmEndingPlyNopSet();
                        return;
                    case 277:
                        AppMain.GmEndingPlyBrakeSet();
                        return;
                    default:
                        return;
                }
            }
            else if ( obs_OBJECT_WORK.obj_type == 1 )
            {
                AppMain.GmGmkSsOnewayThrough( ( uint )gms_ENEMY_COM_WORK.eve_rec.flag );
                return;
            }
        }
        else
        {
            if ( id == 283 )
            {
                AppMain.GmMainDatLoadBossBattleStart( ( int )gms_ENEMY_COM_WORK.eve_rec.flag );
                gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
                gms_ENEMY_COM_WORK.obj_work.flag |= 10U;
                return;
            }
            if ( id != 286 )
            {
                return;
            }
            AppMain.GmGmkPressPillarStartup( ( uint )gms_ENEMY_COM_WORK.eve_rec.flag );
        }
    }
}