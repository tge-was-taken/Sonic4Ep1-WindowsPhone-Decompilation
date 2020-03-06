using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001202 RID: 4610 RVA: 0x0009DF88 File Offset: 0x0009C188
    private static AppMain.OBS_OBJECT_WORK GmGmkWaterAreaInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort water_level = (ushort)(eve_rec.left * 100 + eve_rec.top);
        ushort num = 0;
        ushort num2 = eve_rec.flag;
        ushort num3 = 0;
        while ( 10 > num3 )
        {
            if ( ( num2 & 1 ) != 0 )
            {
                num += ( ushort )( num3 + 1 );
            }
            num2 = ( ushort )( num2 >> 1 );
            num3 += 1;
        }
        if ( AppMain.gmGmkWaterAreaGetType( eve_rec ) == 0U )
        {
            if ( AppMain.gmGmkWaterAreaCheckRestart( pos_x, pos_y ) )
            {
                AppMain.GmWaterSurfaceRequestChangeWaterLevel( water_level, ( ushort )( num * 60 ), false );
            }
            eve_rec.pos_x = byte.MaxValue;
            return null;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkWaterAreaLoadObj(eve_rec, pos_x, pos_y, type);
        AppMain.gmGmkWaterAreaInit( gms_ENEMY_3D_WORK, water_level, num );
        return ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001203 RID: 4611 RVA: 0x0009E020 File Offset: 0x0009C220
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkWaterAreaLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_WATER_AREA");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001204 RID: 4612 RVA: 0x0009E094 File Offset: 0x0009C294
    private static void gmGmkWaterAreaInit( AppMain.GMS_ENEMY_3D_WORK gimmick_work, ushort water_level, ushort time )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gimmick_work;
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = gimmick_work.ene_com.eve_rec;
        uint type = AppMain.gmGmkWaterAreaGetType(eve_rec);
        byte width = eve_rec.width;
        byte height = eve_rec.height;
        AppMain.gmGmkWaterAreaSetRect( gimmick_work, width, height, type );
        gimmick_work.ene_com.target_obj = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        AppMain.gmGmkWaterAreaUserWorkSetLevel( obs_OBJECT_WORK, water_level );
        AppMain.gmGmkWaterAreaUserWorkSetTime( obs_OBJECT_WORK, time );
    }

    // Token: 0x06001205 RID: 4613 RVA: 0x0009E120 File Offset: 0x0009C320
    private static bool gmGmkWaterAreaCheckRestart( int pos_x, int pos_y )
    {
        int num = AppMain.MTM_MATH_ABS(AppMain.g_gm_main_system.resume_pos_x - pos_x);
        int num2 = AppMain.MTM_MATH_ABS(AppMain.g_gm_main_system.resume_pos_y - pos_y);
        return num2 <= 524288 && num <= 524288;
    }

    // Token: 0x06001206 RID: 4614 RVA: 0x0009E164 File Offset: 0x0009C364
    private static uint gmGmkWaterAreaGetType( AppMain.GMS_EVE_RECORD_EVENT eve_rec )
    {
        uint result = uint.MaxValue;
        switch ( eve_rec.id )
        {
            case 102:
                result = 1U;
                break;
            case 103:
                result = 2U;
                break;
            case 104:
                result = 3U;
                break;
            case 105:
                result = 4U;
                break;
            case 106:
                result = 0U;
                break;
        }
        return result;
    }

    // Token: 0x06001207 RID: 4615 RVA: 0x0009E1AC File Offset: 0x0009C3AC
    private static void gmGmkWaterAreaRequestChangeWatarLevel( AppMain.OBS_OBJECT_WORK obj_work )
    {
        ushort water_level = AppMain.gmGmkWaterAreaUserWorkGetLevel(obj_work);
        ushort num = AppMain.gmGmkWaterAreaUserWorkGetTime(obj_work);
        AppMain.GmWaterSurfaceRequestChangeWaterLevel( water_level, ( ushort )( num * 60 ), false );
    }

    // Token: 0x06001208 RID: 4616 RVA: 0x0009E1D4 File Offset: 0x0009C3D4
    private static void gmGmkWaterAreaSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work, byte width, byte height, uint type )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        if ( width < 34 )
        {
            width = 34;
        }
        if ( height < 34 )
        {
            height = 34;
        }
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, ( short )( -width / 2 ), ( short )( -height / 2 ), -500, ( short )( width / 2 ), ( short )( height / 2 ), 500 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 0, 0 );
        switch ( type )
        {
            case 0U:
                break;
            case 1U:
            case 2U:
            case 3U:
            case 4U:
                obs_RECT_WORK.flag |= 1024U;
                obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkWaterAreaDefFuncDelay );
                break;
            default:
                return;
        }
    }

    // Token: 0x06001209 RID: 4617 RVA: 0x0009E27C File Offset: 0x0009C47C
    private static bool gmGmkWaterAreaCheckDir( AppMain.OBS_OBJECT_WORK gimmick_obj_work, AppMain.OBS_OBJECT_WORK player_obj_work, uint type )
    {
        bool result = false;
        switch ( type )
        {
            case 0U:
                result = true;
                break;
            case 1U:
                if ( player_obj_work.pos.x < gimmick_obj_work.pos.x )
                {
                    result = true;
                }
                break;
            case 2U:
                if ( gimmick_obj_work.pos.x < player_obj_work.pos.x )
                {
                    result = true;
                }
                break;
            case 3U:
                if ( player_obj_work.pos.y < gimmick_obj_work.pos.y )
                {
                    result = true;
                }
                break;
            case 4U:
                if ( gimmick_obj_work.pos.y < player_obj_work.pos.y )
                {
                    result = true;
                }
                break;
        }
        return result;
    }

    // Token: 0x0600120A RID: 4618 RVA: 0x0009E31C File Offset: 0x0009C51C
    private static void gmGmkWaterAreaDefFuncDelay( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( !AppMain.gmGmkWaterAreaModeCheckWait( parent_obj ) )
        {
            return;
        }
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = gms_ENEMY_3D_WORK.ene_com.eve_rec;
        uint type = AppMain.gmGmkWaterAreaGetType(eve_rec);
        if ( AppMain.gmGmkWaterAreaCheckDir( parent_obj, parent_obj2, type ) )
        {
            AppMain.gmGmkWaterAreaModeChangeLady( parent_obj );
        }
    }

    // Token: 0x0600120B RID: 4619 RVA: 0x0009E36C File Offset: 0x0009C56C
    private static bool gmGmkWaterAreaModeCheckWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.ppFunc == null;
    }

    // Token: 0x0600120C RID: 4620 RVA: 0x0009E379 File Offset: 0x0009C579
    private static void gmGmkWaterAreaModeChangeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.flag &= 4294967279U;
        obj_work.ppFunc = null;
    }

    // Token: 0x0600120D RID: 4621 RVA: 0x0009E391 File Offset: 0x0009C591
    private static void gmGmkWaterAreaModeChangeLady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.flag &= 4294967279U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkWaterAreaMainLady );
    }

    // Token: 0x0600120E RID: 4622 RVA: 0x0009E3B4 File Offset: 0x0009C5B4
    private static void gmGmkWaterAreaModeChangeActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkWaterAreaRequestChangeWatarLevel( obj_work );
        obj_work.flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkWaterAreaMainActive );
        AppMain.gmGmkWaterAreaUserTimerSetCounter( obj_work, 0 );
        AppMain.gmGmkWaterAreaRequestChangeWatarLevel( obj_work );
        AppMain.GmWaterSurfaceSetFlagDraw( true );
    }

    // Token: 0x0600120F RID: 4623 RVA: 0x0009E3F0 File Offset: 0x0009C5F0
    private static void gmGmkWaterAreaMainLady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        if ( ( obs_RECT_WORK.flag & 131072U ) != 0U )
        {
            return;
        }
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = gms_ENEMY_3D_WORK.ene_com.eve_rec;
        uint type = AppMain.gmGmkWaterAreaGetType(eve_rec);
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        if ( AppMain.gmGmkWaterAreaCheckDir( obj_work, target_obj, type ) )
        {
            AppMain.gmGmkWaterAreaModeChangeWait( obj_work );
            return;
        }
        AppMain.gmGmkWaterAreaModeChangeActive( obj_work );
    }

    // Token: 0x06001210 RID: 4624 RVA: 0x0009E45C File Offset: 0x0009C65C
    private static void gmGmkWaterAreaMainActive( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = (int)AppMain.gmGmkWaterAreaUserWorkGetTime(obj_work);
        int num2 = AppMain.gmGmkWaterAreaUserTimerGetCounter(obj_work);
        AppMain.gmGmkWaterAreaUserTimerAddCounter( obj_work, 1 );
        if ( num2 >= num * 60 )
        {
            AppMain.gmGmkWaterAreaModeChangeWait( obj_work );
        }
    }

    // Token: 0x06001211 RID: 4625 RVA: 0x0009E48B File Offset: 0x0009C68B
    private static void gmGmkWaterAreaUserWorkSetLevel( AppMain.OBS_OBJECT_WORK obj_work, ushort level )
    {
        obj_work.user_work |= ( uint )( ( uint )level << 16 );
    }

    // Token: 0x06001212 RID: 4626 RVA: 0x0009E49E File Offset: 0x0009C69E
    private static ushort gmGmkWaterAreaUserWorkGetLevel( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( ushort )( obj_work.user_work >> 16 );
    }

    // Token: 0x06001213 RID: 4627 RVA: 0x0009E4AA File Offset: 0x0009C6AA
    private static void gmGmkWaterAreaUserWorkSetTime( AppMain.OBS_OBJECT_WORK obj_work, ushort time )
    {
        obj_work.user_work &= 4294901760U;
        obj_work.user_work |= ( uint )time;
    }

    // Token: 0x06001214 RID: 4628 RVA: 0x0009E4CC File Offset: 0x0009C6CC
    private static ushort gmGmkWaterAreaUserWorkGetTime( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( ushort )obj_work.user_work;
    }

    // Token: 0x06001215 RID: 4629 RVA: 0x0009E4D5 File Offset: 0x0009C6D5
    private static void gmGmkWaterAreaUserTimerSetCounter( AppMain.OBS_OBJECT_WORK obj_work, int time )
    {
        obj_work.user_timer = time;
    }

    // Token: 0x06001216 RID: 4630 RVA: 0x0009E4DE File Offset: 0x0009C6DE
    private static void gmGmkWaterAreaUserTimerAddCounter( AppMain.OBS_OBJECT_WORK obj_work, int time )
    {
        obj_work.user_timer += time;
    }

    // Token: 0x06001217 RID: 4631 RVA: 0x0009E4EE File Offset: 0x0009C6EE
    private static int gmGmkWaterAreaUserTimerGetCounter( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.user_timer;
    }
}
