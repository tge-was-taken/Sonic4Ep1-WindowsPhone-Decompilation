using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060008A8 RID: 2216 RVA: 0x0004E58C File Offset: 0x0004C78C
    private static AppMain.OBS_OBJECT_WORK GmGmkRockRideInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkRockRideLoadObj(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkRockRideWaitInit( obj_work );
        return obj_work;
    }

    // Token: 0x060008A9 RID: 2217 RVA: 0x0004E5B8 File Offset: 0x0004C7B8
    public static void GmGmkRockRideBuild()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(817));
        AppMain.TXB_HEADER txb = AppMain.readTXBfile(AppMain.amBindGet(ams_AMB_HEADER, 0));
        AppMain.g_gm_gmk_rock_ride_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 816 ) ), ams_AMB_HEADER, 0U, txb );
    }

    // Token: 0x060008AA RID: 2218 RVA: 0x0004E600 File Offset: 0x0004C800
    public static void GmGmkRockRideFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(816));
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_rock_ride_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_rock_ride_obj_3d_list = null;
    }

    // Token: 0x060008AB RID: 2219 RVA: 0x0004E63C File Offset: 0x0004C83C
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkRockRideLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_ROCK_WORK(), "GMK_ROCK_RIDE");
        AppMain.GMS_ENEMY_3D_WORK enemy_work = gms_GMK_ROCK_WORK.enemy_work;
        AppMain.OBS_OBJECT_WORK obj_work = gms_GMK_ROCK_WORK.enemy_work.ene_com.obj_work;
        enemy_work.ene_com.rect_work[0].flag &= 4294967291U;
        enemy_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_rock_ride_obj_3d_list[0], enemy_work.obj_3d );
        obj_work.obj_3d.use_light_flag &= 4294967294U;
        obj_work.obj_3d.use_light_flag |= 64U;
        return enemy_work;
    }

    // Token: 0x060008AC RID: 2220 RVA: 0x0004E703 File Offset: 0x0004C903
    private static void gmGmkRockRideMoveFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjObjectMove( obj_work );
    }

    // Token: 0x060008AD RID: 2221 RVA: 0x0004E70C File Offset: 0x0004C90C
    private static void gmGmkRockRideDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.VecU16 vecU = new AppMain.VecU16(obj_work.dir);
        ushort z = AppMain.gmGmkRockRideGetUserTimerAngleZ(obj_work);
        if ( obj_work.spd_m < 0 )
        {
            obj_work.dir.z = z;
        }
        else
        {
            obj_work.dir.z = z;
        }
        ushort x = (ushort)obj_work.user_work;
        obj_work.dir.x = x;
        AppMain.ObjDrawActionSummary( obj_work );
        obj_work.dir.Assign( vecU );
    }

    // Token: 0x060008AE RID: 2222 RVA: 0x0004E778 File Offset: 0x0004C978
    private static void gmGmkRockRideTcbDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_GMK_ROCK_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_ROCK_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_ROCK_WORK.se_handle );
            gms_GMK_ROCK_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x060008AF RID: 2223 RVA: 0x0004E7BC File Offset: 0x0004C9BC
    private static void gmGmkRockRideSetUserTimerAngleZ( AppMain.OBS_OBJECT_WORK obj_work, ushort angle_z )
    {
        obj_work.user_timer = ( int )angle_z;
    }

    // Token: 0x060008B0 RID: 2224 RVA: 0x0004E7C5 File Offset: 0x0004C9C5
    private static void gmGmkRockRideAddUserTimerAngleZ( AppMain.OBS_OBJECT_WORK obj_work, short angle_z )
    {
        obj_work.user_timer += ( int )angle_z;
    }

    // Token: 0x060008B1 RID: 2225 RVA: 0x0004E7D5 File Offset: 0x0004C9D5
    private static ushort gmGmkRockRideGetUserTimerAngleZ( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( ushort )obj_work.user_timer;
    }

    // Token: 0x060008B2 RID: 2226 RVA: 0x0004E7E0 File Offset: 0x0004C9E0
    private static void gmGmkRockRideWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockRideWaitSetRect( gms_ENEMY_3D_WORK );
        obj_work.flag |= 1U;
        obj_work.move_flag |= 8448U;
        obj_work.disp_flag |= 4194304U;
        obj_work.spd_m = 0;
        gms_ENEMY_3D_WORK.ene_com.target_obj = AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work;
        ushort angle_z = AppMain.mtMathRand();
        AppMain.gmGmkRockRideSetUserTimerAngleZ( obj_work, angle_z );
        obj_work.user_work = ( uint )AppMain.mtMathRand();
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        gms_GMK_ROCK_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideWaitMain );
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideDrawFunc );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkRockRideTcbDest ) );
    }

    // Token: 0x060008B3 RID: 2227 RVA: 0x0004E8BC File Offset: 0x0004CABC
    private static void gmGmkRockRideWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060008B4 RID: 2228 RVA: 0x0004E8C0 File Offset: 0x0004CAC0
    private static void gmGmkRockRideWaitDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.GMS_ENEMY_COM_WORK ene_com = gms_ENEMY_3D_WORK.ene_com;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        if ( ( parent_obj2.move_flag & 1U ) != 0U )
        {
            if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag != 0 )
            {
                if ( parent_obj.pos.x >= parent_obj2.pos.x )
                {
                    return;
                }
            }
            else if ( parent_obj.pos.x <= parent_obj2.pos.x )
            {
                return;
            }
            AppMain.GmPlySeqInitRockRideStart( gms_PLAYER_WORK, ene_com );
            AppMain.gmGmkRockRideStartInit( parent_obj );
            return;
        }
        int num = parent_obj.pos.x - parent_obj2.pos.x;
        int num2 = parent_obj.pos.y - parent_obj2.pos.y;
        int num3 = AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2);
        if ( num3 > 12845056 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state != 17 && gms_PLAYER_WORK.seq_state != 21 && gms_PLAYER_WORK.seq_state != 16 && gms_PLAYER_WORK.seq_state != 29 )
        {
            return;
        }
        int num4 = -(229376 - AppMain.MTM_MATH_ABS(num)) / 30;
        int spd_y = 0;
        if ( parent_obj.pos.x < parent_obj2.pos.x )
        {
            num4 = -num4;
        }
        AppMain.GmPlySeqInitPinballAir( gms_PLAYER_WORK, num4, spd_y, 60, 1, 0 );
    }

    // Token: 0x060008B5 RID: 2229 RVA: 0x0004EA18 File Offset: 0x0004CC18
    private static void gmGmkRockRideWaitSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, -48, -56, -500, 48, 56, 500 );
        obs_RECT_WORK.flag &= 4294966271U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkRockRideWaitDefFunc );
    }

    // Token: 0x060008B6 RID: 2230 RVA: 0x0004EA7C File Offset: 0x0004CC7C
    private static void gmGmkRockRideStartInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockRideStartSetRect( gimmick_work );
        AppMain.ObjObjectFieldRectSet( obj_work, -16, -16, 16, 16 );
        obj_work.flag &= 4294967294U;
        obj_work.move_flag &= 4294958847U;
        obj_work.move_flag |= 192U;
        obj_work.move_flag &= 4294836223U;
        obj_work.spd_m = 0;
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        AppMain.GmSoundPlaySE( "BigRock3", gms_GMK_ROCK_WORK.se_handle );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideStartMain );
        obj_work.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideMoveFunc );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideDrawFunc );
    }

    // Token: 0x060008B7 RID: 2231 RVA: 0x0004EB40 File Offset: 0x0004CD40
    private static void gmGmkRockRideStartMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.gmGmkRockRideAddUserTimerAngleZ( obj_work, ( short )( obj_work.spd_m >> 4 ) );
        int num = 224;
        if ( obj_work.pos.x < target_obj.pos.x )
        {
            num = -num;
        }
        obj_work.spd_m += num;
        if ( ( long )AppMain.MTM_MATH_ABS( obj_work.spd_m ) > 12288L )
        {
            AppMain.gmGmkRockRideRollInit( obj_work );
        }
        float num2 = AppMain.FX_FX32_TO_F32(AppMain.FX_Div(AppMain.MTM_MATH_ABS(obj_work.spd_m), 6));
        if ( num2 > 1f )
        {
            num2 = 1f;
        }
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        if ( gms_GMK_ROCK_WORK.se_handle != null )
        {
            gms_GMK_ROCK_WORK.se_handle.au_player.SetAisac( "Speed", num2 );
        }
    }

    // Token: 0x060008B8 RID: 2232 RVA: 0x0004EC08 File Offset: 0x0004CE08
    private static void gmGmkRockRideStartSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        AppMain.ObjRectDefSet( obs_RECT_WORK, ushort.MaxValue, 3 );
        obs_RECT_WORK.ppDef = null;
    }

    // Token: 0x060008B9 RID: 2233 RVA: 0x0004EC38 File Offset: 0x0004CE38
    private static void gmGmkRockRideRollInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockRideRollSetRect( gimmick_work );
        AppMain.ObjObjectFieldRectSet( obj_work, -16, -16, 16, 16 );
        obj_work.flag &= 4294967294U;
        obj_work.move_flag &= 4294958847U;
        obj_work.move_flag |= 131264U;
        obj_work.spd_slope = 192;
        obj_work.spd_slope_max = 61440;
        obj_work.pos.z = 131072;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideRollMainNoPlayer );
        obj_work.ppMove = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideMoveFunc );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideDrawFunc );
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        if ( gms_GMK_ROCK_WORK.effect_work == null )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 2, 18);
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = null;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.z = 98304;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_ofst.y = 131072;
            gms_GMK_ROCK_WORK.effect_work = gms_EFFECT_3DES_WORK;
        }
    }

    // Token: 0x060008BA RID: 2234 RVA: 0x0004ED54 File Offset: 0x0004CF54
    private static void gmGmkRockRideRollMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkRockRideAddUserTimerAngleZ( obj_work, ( short )( obj_work.spd_m >> 4 ) );
        float num = AppMain.FX_FX32_TO_F32(AppMain.FX_Div(AppMain.MTM_MATH_ABS(obj_work.spd_m), 6));
        if ( num > 1f )
        {
            num = 1f;
        }
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        if ( gms_GMK_ROCK_WORK.se_handle != null )
        {
            gms_GMK_ROCK_WORK.se_handle.au_player.SetAisac( "Speed", num );
        }
        if ( ( obj_work.move_flag & 4U ) != 0U || ( obj_work.move_flag & 8U ) != 0U )
        {
            AppMain.gmGmkRockRideStopInit( obj_work );
        }
        if ( gms_GMK_ROCK_WORK.vib_timer % 30 == 0 )
        {
            AppMain.GMM_PAD_VIB_SMALL_TIME( 10f );
        }
        gms_GMK_ROCK_WORK.vib_timer++;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.seq_state != 31 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideRollMainNoPlayer );
            AppMain.GMM_PAD_VIB_STOP();
            gms_GMK_ROCK_WORK.vib_timer = 0;
            obj_work.pos.z = -262144;
        }
    }

    // Token: 0x060008BB RID: 2235 RVA: 0x0004EE40 File Offset: 0x0004D040
    private static void gmGmkRockRideRollMainNoPlayer( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkRockRideAddUserTimerAngleZ( obj_work, ( short )( obj_work.spd_m >> 4 ) );
        float num = AppMain.FX_FX32_TO_F32(AppMain.FX_Div(AppMain.MTM_MATH_ABS(obj_work.spd_m), 6));
        if ( num > 1f )
        {
            num = 1f;
        }
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        if ( gms_GMK_ROCK_WORK.se_handle != null )
        {
            gms_GMK_ROCK_WORK.se_handle.au_player.SetAisac( "Speed", num );
        }
        if ( ( obj_work.move_flag & 4U ) != 0U || ( obj_work.move_flag & 8U ) != 0U )
        {
            AppMain.gmGmkRockRideStopInit( obj_work );
        }
    }

    // Token: 0x060008BC RID: 2236 RVA: 0x0004EEC0 File Offset: 0x0004D0C0
    private static void gmGmkRockRideRollDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.GMS_ENEMY_COM_WORK ene_com = gms_ENEMY_3D_WORK.ene_com;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        AppMain.GmPlySeqInitRockRide( ply_work, ene_com );
        own_rect.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkRockRideRollDefFunc );
        parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkRockRideRollMain );
        parent_obj.pos.z = 131072;
    }

    // Token: 0x060008BD RID: 2237 RVA: 0x0004EF38 File Offset: 0x0004D138
    private static void gmGmkRockRideRollSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, -48, -48, -500, 48, 48, 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkRockRideRollDefFunc );
    }

    // Token: 0x060008BE RID: 2238 RVA: 0x0004EF9C File Offset: 0x0004D19C
    private static void gmGmkRockRideStopInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkRockRideStopSetRect( gimmick_work );
        AppMain.ObjObjectFieldRectSet( obj_work, -16, -16, 16, 16 );
        obj_work.flag &= 4294967294U;
        obj_work.move_flag |= 256U;
        obj_work.move_flag &= 4294967294U;
        obj_work.spd_slope = 0;
        obj_work.spd_slope_max = 0;
        obj_work.spd_m = 0;
        AppMain.GMS_GMK_ROCK_WORK gms_GMK_ROCK_WORK = (AppMain.GMS_GMK_ROCK_WORK)obj_work;
        if ( gms_GMK_ROCK_WORK.se_handle != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_ROCK_WORK.se_handle );
        }
        obj_work.ppFunc = null;
        if ( gms_GMK_ROCK_WORK.effect_work != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_ROCK_WORK.effect_work );
        }
        AppMain.GMM_PAD_VIB_STOP();
    }

    // Token: 0x060008BF RID: 2239 RVA: 0x0004F048 File Offset: 0x0004D248
    private static void gmGmkRockRideStopSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, ushort.MaxValue, 3 );
        obs_RECT_WORK.ppDef = null;
    }
}