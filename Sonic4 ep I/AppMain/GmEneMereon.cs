using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060003E1 RID: 993 RVA: 0x0001F524 File Offset: 0x0001D724
    private static void GmEneMereonBuild()
    {
        AppMain.gm_ene_mereon_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 670 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 672 ) ), 0U );
        AppMain.gm_ene_mereon_r_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 671 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 672 ) ), 0U );
    }

    // Token: 0x060003E2 RID: 994 RVA: 0x0001F584 File Offset: 0x0001D784
    private static void GmEneMereonFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(670));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_mereon_obj_3d_list, ams_AMB_HEADER.file_num );
        ams_AMB_HEADER = AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 671 ) );
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_mereon_r_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060003E3 RID: 995 RVA: 0x0001F5D8 File Offset: 0x0001D7D8
    private static AppMain.OBS_OBJECT_WORK GmEneMereonInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "ENE_MEREON");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_mereon_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 673 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -24, 11, 0 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag &= 4294967291U;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -4, -8, 4, 0 );
        obs_OBJECT_WORK.obj_3d.drawflag |= 8388608U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.flag |= 2U;
        AppMain.GmEneComActionSetDependHFlip( obs_OBJECT_WORK, 0, 1 );
        if ( eve_rec.id == 4 )
        {
            gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        }
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        AppMain.gmEneMereonHideSearchInit( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060003E4 RID: 996 RVA: 0x0001F798 File Offset: 0x0001D998
    private static void gmEneMereonHideSearchInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        obj_work.disp_flag &= 4294967294U;
        if ( gms_PLAYER_WORK.obj_work.pos.x < obj_work.pos.x )
        {
            obj_work.disp_flag |= 1U;
        }
        AppMain.gmEneMereonCheckFwFlip( obj_work );
        obj_work.disp_flag |= 32U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMereonHideSearchMain );
    }

    // Token: 0x060003E5 RID: 997 RVA: 0x0001F81C File Offset: 0x0001DA1C
    private static void gmEneMereonHideSearchMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        float[] array = new float[2];
        float[] array2 = new float[2];
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_PLAYER_WORK.rect_work[2];
        array[0] = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.x + ( obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1 ) );
        array[1] = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.y + ( obs_RECT_WORK.rect.left + obs_RECT_WORK.rect.right >> 1 ) );
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        array2[0] = AppMain.FXM_FX32_TO_FLOAT( obj_work.pos.x + ( obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1 ) );
        array2[1] = AppMain.FXM_FX32_TO_FLOAT( obj_work.pos.y + ( obs_RECT_WORK.rect.left + obs_RECT_WORK.rect.right >> 1 ) );
        float num = array2[0] - array[0];
        float num2 = array2[1] - array[1];
        float num3;
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 4 )
        {
            num3 = 96f;
        }
        else
        {
            num3 = 192f;
        }
        if ( num * num + num2 * num2 <= num3 * num3 )
        {
            obj_work.disp_flag &= 4294967263U;
            AppMain.gmEneMereonAppearInit( obj_work );
        }
    }

    // Token: 0x060003E6 RID: 998 RVA: 0x0001F978 File Offset: 0x0001DB78
    private static void gmEneMereonAppearInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        obj_work.disp_flag &= 4294967294U;
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 4 && gms_PLAYER_WORK.obj_work.pos.x > obj_work.pos.x )
        {
            obj_work.disp_flag |= 1U;
        }
        AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
        obj_work.disp_flag |= 4U;
        obj_work.disp_flag |= 134217728U;
        obj_work.obj_3d.draw_state.alpha.alpha = 0f;
        obj_work.user_timer = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMereonAppearMain );
    }

    // Token: 0x060003E7 RID: 999 RVA: 0x0001FA40 File Offset: 0x0001DC40
    private static void gmEneMereonAppearMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        obj_work.user_timer = AppMain.ObjTimeCountUp( obj_work.user_timer );
        int num;
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 4 )
        {
            num = 30;
        }
        else
        {
            num = 15;
        }
        obj_work.obj_3d.draw_state.alpha.alpha = ( float )obj_work.user_timer / ( float )( num * 4096 );
        if ( obj_work.user_timer >= num * 4096 )
        {
            obj_work.obj_3d.draw_state.alpha.alpha = 1f;
            obj_work.disp_flag &= 4160749567U;
            if ( gms_ENEMY_COM_WORK.eve_rec.id == 4 )
            {
                AppMain.gmEneMereonAtkInit( obj_work );
                return;
            }
            AppMain.gmEneMereonAtkRocketInit( obj_work );
        }
    }

    // Token: 0x060003E8 RID: 1000 RVA: 0x0001FAF6 File Offset: 0x0001DCF6
    private static void gmEneMereonAtkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 3, 4 );
        obj_work.flag &= 4294967293U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMereonAtkMain );
        obj_work.user_timer = 0;
    }

    // Token: 0x060003E9 RID: 1001 RVA: 0x0001FB28 File Offset: 0x0001DD28
    private static void gmEneMereonAtkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            int num = -8192;
            short num2 = -16384;
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                num = -num;
                num2 = ( short )( ( int )num2 + 32768 );
            }
            AppMain.GmEneStingCreateBullet( obj_work, -81920, -49152, 32768, -98304, -49152, 0, num, 0, num2 );
            AppMain.GmSoundPlaySE( "Sting" );
            AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 0, 1 );
            obj_work.user_timer = 122880;
        }
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
            if ( obj_work.user_timer == 0 )
            {
                AppMain.gmEneMereonHideInit( obj_work );
            }
        }
    }

    // Token: 0x060003EA RID: 1002 RVA: 0x0001FBC8 File Offset: 0x0001DDC8
    private static void gmEneMereonHideInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMereonHideMain );
        obj_work.disp_flag |= 134217728U;
        obj_work.obj_3d.draw_state.alpha.alpha = 1f;
        obj_work.user_timer = 122880;
    }

    // Token: 0x060003EB RID: 1003 RVA: 0x0001FC20 File Offset: 0x0001DE20
    private static void gmEneMereonHideMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        obj_work.obj_3d.draw_state.alpha.alpha = ( float )obj_work.user_timer / 122880f;
        if ( obj_work.user_timer <= 0 )
        {
            obj_work.obj_3d.draw_state.alpha.alpha = 1f;
            obj_work.disp_flag &= 4160749567U;
            obj_work.disp_flag |= 32U;
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060003EC RID: 1004 RVA: 0x0001FCB4 File Offset: 0x0001DEB4
    private static void gmEneMereonAtkRocketInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 2 );
        obj_work.move_flag &= 4294967039U;
        obj_work.move_flag |= 128U;
        obj_work.flag &= 4294967293U;
        obj_work.disp_flag &= 1U;
        obj_work.user_timer = 0;
        if ( AppMain.GmEneComTargetIsLeft( obj_work, AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work ) == 0 )
        {
            obj_work.user_timer = 4096;
        }
        obj_work.user_work = 0U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMereonRocketFallMain );
    }

    // Token: 0x060003ED RID: 1005 RVA: 0x0001FD50 File Offset: 0x0001DF50
    private static void gmEneMereonRocketFallMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer != 0 )
        {
            obj_work.dir.y = ( ushort )( ( int )obj_work.dir.y + obj_work.user_timer );
            if ( obj_work.dir.y >= 32768 )
            {
                obj_work.dir.y = 32768;
                obj_work.user_timer = 0;
            }
        }
        if ( obj_work.user_work != 0U )
        {
            obj_work.user_work = ( uint )AppMain.ObjTimeCountDown( ( int )obj_work.user_work );
            if ( obj_work.user_work == 0U )
            {
                AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
                AppMain.ObjAction3dNNMotionRelease( obj_work.obj_3d );
                AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
                AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_ene_mereon_r_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
                AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, AppMain.ObjDataGet( 673 ), null, 0, null );
                AppMain.ObjDrawObjectSetToon( obj_work );
                AppMain.ObjObjectFieldRectSet( obj_work, -4, -4, 4, 4 );
                AppMain.ObjDrawObjectActionSet( obj_work, 5 );
                obj_work.disp_flag |= 4U;
                if ( obj_work.dir.y != 0 || obj_work.user_timer != 0 )
                {
                    obj_work.dir.y = 0;
                    obj_work.disp_flag &= 4294967294U;
                }
                else
                {
                    obj_work.disp_flag |= 1U;
                }
                obj_work.move_flag |= 64U;
                if ( ( obj_work.disp_flag & 1U ) != 0U )
                {
                    obj_work.spd_m = -8192;
                }
                else
                {
                    obj_work.spd_m = 8192;
                }
                obj_work.move_flag |= 1024U;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMereonRocketMain );
                obj_work.user_flag = 0U;
                obj_work.user_timer = 0;
                AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate(obj_work, 1);
                AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, -38f, -11f, 0f );
                gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 524288U;
                return;
            }
        }
        else if ( ( obj_work.disp_flag & 8U ) != 0U && ( obj_work.move_flag & 1U ) != 0U )
        {
            obj_work.user_work = 4096U;
            AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctEneEsCreate(obj_work, 4);
            AppMain.GmComEfctAddDispOffsetF( efct_work, 0f, -16f, 16f );
        }
    }

    // Token: 0x060003EE RID: 1006 RVA: 0x0001FF54 File Offset: 0x0001E154
    private static void gmEneMereonRocketMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_flag == 0U && obj_work.dir.z + 8192 > 16384 )
        {
            obj_work.user_flag = 1U;
            obj_work.move_flag &= 4294967231U;
            obj_work.move_flag |= 257U;
            obj_work.spd.x = obj_work.spd_m;
        }
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            if ( obj_work.user_timer == 0 )
            {
                obj_work.move_flag |= 64U;
                obj_work.user_flag = 0U;
                obj_work.spd.x = 0;
                return;
            }
        }
        else if ( obj_work.user_flag != 0U )
        {
            obj_work.dir.z = AppMain.ObjRoopMove16( obj_work.dir.z, 0, 1024 );
            if ( obj_work.dir.z == 0 )
            {
                obj_work.user_timer = 4;
            }
        }
    }

    // Token: 0x060003EF RID: 1007 RVA: 0x0002003C File Offset: 0x0001E23C
    private static void gmEneMereonCheckFwFlip( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.obj_work.pos.x < obj_work.pos.x )
        {
            if ( obj_work.obj_3d.act_id[0] != 0 )
            {
                AppMain.ObjDrawObjectActionSet( obj_work, 0 );
                obj_work.disp_flag &= 4294967294U;
            }
        }
        else if ( gms_PLAYER_WORK.obj_work.pos.x > obj_work.pos.x && obj_work.obj_3d.act_id[0] != 1 )
        {
            AppMain.ObjDrawObjectActionSet( obj_work, 1 );
            obj_work.disp_flag |= 1U;
        }
        obj_work.disp_flag |= 4U;
    }
}