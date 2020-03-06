using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600056B RID: 1387 RVA: 0x0002E0A8 File Offset: 0x0002C2A8
    public static void GmGmkLandBuild()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.gm_gmk_land_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( AppMain.gm_gmk_land_obj_data[num][0] ), AppMain.GmGameDatGetGimmickData( AppMain.gm_gmk_land_obj_data[num][1] ), 0U );
        if ( num == 2 )
        {
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(810);
            AppMain.gm_gmk_land_3_obj_tvx_list = ams_AMB_HEADER;
        }
    }

    // Token: 0x0600056C RID: 1388 RVA: 0x0002E104 File Offset: 0x0002C304
    public static void GmGmkLandFlush()
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(AppMain.gm_gmk_land_obj_data[num][0]);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_land_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_land_3_obj_tvx_list = null;
    }

    // Token: 0x0600056D RID: 1389 RVA: 0x0002E150 File Offset: 0x0002C350
    public static AppMain.OBS_OBJECT_WORK GmGmkLandInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_RIDE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_LAND");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        int num2;
        ushort num3;
        if ( eve_rec.id == 82 )
        {
            num2 = 1;
            num3 = 1;
        }
        else if ( eve_rec.id == 83 )
        {
            num2 = 2;
            num3 = 2;
        }
        else
        {
            num2 = 0;
            num3 = 0;
        }
        int num4 = AppMain.gm_gmk_land_mdl_data[num][(int)num3];
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_land_obj_3d_list[num4], gms_ENEMY_3D_WORK.obj_3d );
        if ( num == 1 )
        {
            int id = num4;
            int index = num4;
            AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 805 ), null, 0, null );
            AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, id );
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, index, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 806 ).pData );
            AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
            obs_OBJECT_WORK.disp_flag |= 4U;
        }
        else if ( num == 4 )
        {
            int index2 = num4;
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, index2, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 815 ).pData );
            AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
            obs_OBJECT_WORK.disp_flag |= 16U;
            ( ( AppMain.NNS_MOTION_KEY_Class5[] )obs_OBJECT_WORK.obj_3d.motion.mmtn[0].pSubmotion[0].pKeyList )[0].Value.y = 1f;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag &= 4294967294U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 2U;
            gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 65536U;
        }
        if ( num == 2 )
        {
            if ( num4 == 0 )
            {
                obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLand3TvxDrawFunc );
            }
            else
            {
                obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLand3TvxRDrawFunc );
            }
        }
        obs_OBJECT_WORK.pos.z = -131072;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        if ( ( eve_rec.flag & 128 ) == 0 && eve_rec.id != 83 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.attr = 1;
        }
        switch ( AppMain.gm_gmk_land_col_type_tbl[num2] )
        {
            default:
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 48;
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 24;
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -17;
                if ( ( gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.attr & 1 ) != 0 )
                {
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 8;
                    AppMain.OBS_COLLISION_OBJ obj_col = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col;
                    obj_col.ofst_y += 1;
                }
                break;
            case 1:
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 80;
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 24;
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
                gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -17;
                if ( ( gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.attr & 1 ) != 0 )
                {
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 8;
                    AppMain.OBS_COLLISION_OBJ obj_col2 = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col;
                    obj_col2.ofst_y += 1;
                }
                break;
            case 2:
                if ( num != 2 )
                {
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 64;
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 64;
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -31;
                }
                else
                {
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 24;
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 32;
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
                    gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -15;
                }
                obs_OBJECT_WORK.field_rect[0] = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x;
                obs_OBJECT_WORK.field_rect[1] = gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y;
                obs_OBJECT_WORK.field_rect[2] = ( short )( gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x + ( short )gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width );
                obs_OBJECT_WORK.field_rect[3] = ( short )( ( short )gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y + ( short )gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height );
                break;
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        AppMain.gmGmkLandMoveInit( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600056E RID: 1390 RVA: 0x0002E764 File Offset: 0x0002C964
    public static AppMain.OBS_OBJECT_WORK GmGmkZ3LandPulleyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_RIDE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_LAND_PULLEY");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_land_obj_3d_list[2], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -163840;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.user_work = ( uint )( ( short )( eve_rec.left << 8 ) / 10 );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLand3TvxPulleyDrawFunc );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600056F RID: 1391 RVA: 0x0002E830 File Offset: 0x0002CA30
    public static AppMain.OBS_OBJECT_WORK GmGmkZ3LandRopeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_RIDE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_LAND_ROPE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_land_obj_3d_list[3], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -196608;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        if ( eve_rec.id == 275 )
        {
            obs_OBJECT_WORK.dir.z = 49152;
        }
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.dir.z = ( ushort )( obs_OBJECT_WORK2.dir.z + 32768 );
        }
        if ( eve_rec.left != 0 )
        {
            gms_ENEMY_3D_WORK.obj_3d.mat_speed = ( float )eve_rec.left / 10f;
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLand3TvxRopeMain );
        float num = 120f;
        float num2 = AppMain.g_gm_main_system.sync_time / (num / gms_ENEMY_3D_WORK.obj_3d.mat_speed);
        gms_ENEMY_3D_WORK.obj_3d.mat_frame = ( num2 - ( float )( ( int )num2 ) ) * num;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLand3TvxRopeDrawFunc );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000570 RID: 1392 RVA: 0x0002E988 File Offset: 0x0002CB88
    public static void gmGmkLandMoveInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        obj_work.prev_pos.x = ( obj_work.pos.x >> 12 ) + ( int )gms_ENEMY_3D_WORK.ene_com.eve_rec.left + ( gms_ENEMY_3D_WORK.ene_com.eve_rec.width >> 1 );
        obj_work.prev_pos.y = ( obj_work.pos.y >> 12 ) + ( int )gms_ENEMY_3D_WORK.ene_com.eve_rec.top + ( gms_ENEMY_3D_WORK.ene_com.eve_rec.height >> 1 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkLandMain );
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.width | gms_ENEMY_3D_WORK.ene_com.eve_rec.height ) == 0 )
        {
            return;
        }
        if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id != 128 )
        {
            int num;
            int num2;
            int num3;
            if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.height < gms_ENEMY_3D_WORK.ene_com.eve_rec.width )
            {
                num = gms_ENEMY_3D_WORK.ene_com.eve_rec.width >> 1;
                num2 = obj_work.pos.x >> 12;
                num3 = obj_work.prev_pos.x;
            }
            else
            {
                num = gms_ENEMY_3D_WORK.ene_com.eve_rec.height >> 1;
                num2 = obj_work.pos.y >> 12;
                num3 = obj_work.prev_pos.y;
            }
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 4 ) == 0 )
            {
                ushort num4;
                for ( num4 = 768; num4 > 256; num4 -= 4 )
                {
                    int num5 = num3 + (num * AppMain.mtMathSin((int)((ushort)(num4 << 6))) >> 12);
                    if ( num5 > num2 )
                    {
                        break;
                    }
                }
                obj_work.user_timer = ( int )num4;
            }
            else
            {
                obj_work.user_timer = 0;
                obj_work.user_flag = 0U;
            }
            short num6 = (short)((gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 48) >> 4 << 8);
            obj_work.user_timer -= ( int )num6;
            obj_work.user_timer &= 16383;
            return;
        }
        short num7 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.left * 2);
        short num8 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.top * 2);
        short num9 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.width * 2);
        short num10 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.height * 2);
        int num11 = (int)(num9 * 2 + num10 * 2);
        if ( num8 == 0 )
        {
            obj_work.user_timer = AppMain.MTM_MATH_ABS( ( int )num7 ) * 4096 / num11;
        }
        else if ( num7 == 0 )
        {
            obj_work.user_timer = ( num11 - AppMain.MTM_MATH_ABS( ( int )num8 ) ) * 4096 / num11;
        }
        else if ( num7 + num9 == 0 )
        {
            obj_work.user_timer = ( ( int )num9 + AppMain.MTM_MATH_ABS( ( int )num8 ) ) * 4096 / num11;
        }
        else
        {
            obj_work.user_timer = ( num11 - ( int )num10 - AppMain.MTM_MATH_ABS( ( int )num7 ) ) * 4096 / num11;
        }
        obj_work.view_out_ofst += 256;
    }

    // Token: 0x06000571 RID: 1393 RVA: 0x0002EC7C File Offset: 0x0002CE7C
    public static void gmGmkLandMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_COLLISION_OBJ obj_col = obj_work.col_work.obj_col;
        if ( obj_work.user_work < 30U )
        {
            AppMain.gmGmkLandMove( obj_work );
        }
        if ( obj_col.rider_obj != null && obj_col.rider_obj.ride_obj == obj_work )
        {
            gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 1U;
            if ( ( obj_work.disp_flag & 2U ) != 0U )
            {
                obj_work.ofst.y = -4096;
            }
            else
            {
                obj_work.ofst.y = 4096;
            }
        }
        if ( ( gms_ENEMY_3D_WORK.ene_com.enemy_flag & 1U ) != 0U )
        {
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 64 ) != 0 )
            {
                obj_work.user_work += 1U;
                if ( obj_work.user_work == 30U )
                {
                    obj_work.move_flag &= 4294959103U;
                    obj_work.move_flag |= 128U;
                    obj_work.prev_pos.x = obj_work.pos.x;
                    obj_work.prev_pos.y = obj_work.pos.y;
                    obj_work.spd_fall_max = 30720;
                    if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id == 83 )
                    {
                        obj_work.move_flag &= 4294967039U;
                        obj_work.move_flag |= 1024U;
                        obj_work.ppFunc = AppMain._gmGmkLandColFall;
                    }
                    else
                    {
                        obj_work.ppFunc = null;
                    }
                }
            }
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 4 ) != 0 )
            {
                obj_work.user_flag |= 65536U;
            }
        }
    }

    // Token: 0x06000572 RID: 1394 RVA: 0x0002EE14 File Offset: 0x0002D014
    public static void gmGmkLandMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        byte b = AppMain.gm_gmk_land_spd_tbl[(int)((byte)(gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 3))];
        ushort num = (ushort)obj_work.user_timer;
        int num4;
        int num5;
        if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.id != 128 )
        {
            int x = obj_work.prev_pos.x;
            int y = obj_work.prev_pos.y;
            short num2 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.width >> 1);
            short num3 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.height >> 1);
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 4 ) == 0 )
            {
                num = ( ushort )( AppMain.g_gm_main_system.sync_time * ( uint )b + ( uint )num & 1023U );
            }
            else if ( obj_work.user_flag == 0U )
            {
                num = ( ushort )( obj_work.user_timer & 1023 );
            }
            else
            {
                num = ( ushort )( ( uint )b * ( obj_work.user_flag & 1023U ) + ( uint )num & 1023U );
                obj_work.user_flag = ( ( obj_work.user_flag & 65536U ) | ( obj_work.user_flag + 1U & 1023U ) );
            }
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 8 ) != 0 )
            {
                num4 = ( x << 12 ) + ( int )num2 * AppMain.mtMathSin( ( int )( ( ushort )( ( ( int )num << 6 ) + 32768 ) ) );
                num5 = ( y << 12 ) + ( int )num3 * AppMain.mtMathSin( ( int )( ( ushort )( num << 6 ) ) );
            }
            else
            {
                num4 = ( x << 12 ) + ( int )num2 * AppMain.mtMathSin( ( int )( ( ushort )( num << 6 ) ) );
                num5 = ( y << 12 ) + ( int )num3 * AppMain.mtMathSin( ( int )( ( ushort )( num << 6 ) ) );
            }
        }
        else
        {
            short num6 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.left * 2);
            short num7 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.top * 2);
            short num8 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.width * 2);
            short num9 = (short)(gms_ENEMY_3D_WORK.ene_com.eve_rec.height * 2);
            int num10 = (int)(num8 * 2 + num9 * 2);
            if ( b != 0 )
            {
                num = ( ushort )( AppMain.g_gm_main_system.sync_time * ( uint )b + ( uint )num & 4095U );
            }
            else
            {
                num = ( ushort )( ( ( ulong )AppMain.g_gm_main_system.sync_time + ( ulong )( ( long )( num >> 2 ) ) & 1023UL ) << 2 );
            }
            int num11 = num10 * (int)num / 4096;
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 8 ) == 0 )
            {
                if ( num11 <= ( int )num8 )
                {
                    num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )( num6 + ( short )num11 ) << 12 );
                    num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )num7 << 12 );
                }
                else if ( num11 <= ( int )( num8 + num9 ) )
                {
                    num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )( num6 + num8 ) << 12 );
                    num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )( num7 + ( short )num11 - num8 ) << 12 );
                }
                else if ( num11 <= ( int )( num8 * 2 + num9 ) )
                {
                    num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )( num6 + num8 - ( ( short )num11 - num8 - num9 ) ) << 12 );
                    num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )( num7 + num9 ) << 12 );
                }
                else
                {
                    num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )num6 << 12 );
                    num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )( num7 + ( num9 - ( ( short )num11 - num8 * 2 - num9 ) ) ) << 12 );
                }
            }
            else if ( num11 <= ( int )num8 )
            {
                num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )( num6 + num8 - ( short )num11 ) << 12 );
                num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )num7 << 12 );
            }
            else if ( num11 <= ( int )( num8 + num9 ) )
            {
                num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )num6 << 12 );
                num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )( num7 + ( short )num11 - num8 ) << 12 );
            }
            else if ( num11 <= ( int )( num8 * 2 + num9 ) )
            {
                num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )( num6 + ( ( short )num11 - num8 - num9 ) ) << 12 );
                num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )( num7 + num9 ) << 12 );
            }
            else
            {
                num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( ( int )( num6 + num8 ) << 12 );
                num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_y + ( ( int )( num7 + ( num9 - ( ( short )num11 - num8 * 2 - num9 ) ) ) << 12 );
            }
        }
        obj_work.move.x = num4 - obj_work.pos.x;
        obj_work.move.y = num5 - obj_work.pos.y;
        obj_work.pos.x = num4;
        obj_work.pos.y = num5;
    }

    // Token: 0x06000573 RID: 1395 RVA: 0x0002F26F File Offset: 0x0002D46F
    public static void gmGmkLandColFall( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            obj_work.move_flag |= 256U;
            obj_work.ppFunc = null;
        }
    }

    // Token: 0x06000574 RID: 1396 RVA: 0x0002F294 File Offset: 0x0002D494
    public static void gmGmkZ3LandPulleyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.dir.z = ( ushort )( obj_work.dir.z + ( ushort )obj_work.user_work );
    }

    // Token: 0x06000575 RID: 1397 RVA: 0x0002F2B0 File Offset: 0x0002D4B0
    public static void gmGmkLand3TvxRopeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        obj_3d.mat_frame += obj_3d.mat_speed;
        if ( obj_3d.mat_frame >= 120f )
        {
            obj_3d.mat_frame -= 120f;
        }
    }

    // Token: 0x06000576 RID: 1398 RVA: 0x0002F2F8 File Offset: 0x0002D4F8
    public static void gmGmkLand3TvxDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.NNS_TEXCOORD nns_TEXCOORD = new AppMain.NNS_TEXCOORD(0f, 0f);
        AppMain.gmGmkLand3TvxDrawFuncEx( 0U, obj_work.obj_3d.texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_LIGHT_DISABLE, 0, ref nns_TEXCOORD );
    }

    // Token: 0x06000577 RID: 1399 RVA: 0x0002F354 File Offset: 0x0002D554
    public static void gmGmkLand3TvxRDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.NNS_TEXCOORD nns_TEXCOORD = new AppMain.NNS_TEXCOORD(0f, 0f);
        AppMain.gmGmkLand3TvxDrawFuncEx( 1U, obj_work.obj_3d.texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_LIGHT_DISABLE, 0, ref nns_TEXCOORD );
    }

    // Token: 0x06000578 RID: 1400 RVA: 0x0002F3B0 File Offset: 0x0002D5B0
    public static void gmGmkLand3TvxPulleyDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.NNS_TEXCOORD nns_TEXCOORD = new AppMain.NNS_TEXCOORD(0f, 0f);
        AppMain.gmGmkLand3TvxDrawFuncEx( 2U, obj_work.obj_3d.texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_LIGHT_DISABLE | AppMain.GMD_TVX_DISP_ROTATE, ( short )( -( short )obj_work.dir.z ), ref nns_TEXCOORD );
    }

    // Token: 0x06000579 RID: 1401 RVA: 0x0002F420 File Offset: 0x0002D620
    public static void gmGmkLand3TvxRopeDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.NNS_TEXCOORD nns_TEXCOORD = new AppMain.NNS_TEXCOORD(0f, 0f);
        nns_TEXCOORD.v = -0.25f * obj_work.obj_3d.mat_frame / 120f;
        AppMain.gmGmkLand3TvxDrawFuncEx( 3U, obj_work.obj_3d.texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_LIGHT_DISABLE | AppMain.GMD_TVX_DISP_ROTATE, ( short )( -( short )obj_work.dir.z ), ref nns_TEXCOORD );
    }

    // Token: 0x0600057A RID: 1402 RVA: 0x0002F4AC File Offset: 0x0002D6AC
    public static void gmGmkLand3TvxDrawFuncEx( uint tvx_index, AppMain.NNS_TEXLIST texlist, ref AppMain.VecFx32 pos, ref AppMain.VecFx32 scale, uint disp_flag, short dir_z, ref AppMain.NNS_TEXCOORD uv )
    {
        AppMain.TVX_FILE tvx_FILE;
        if ( AppMain.gm_gmk_land_3_obj_tvx_list.buf[( int )tvx_index] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_land_3_obj_tvx_list, ( int )tvx_index ) );
            AppMain.gm_gmk_land_3_obj_tvx_list.buf[( int )tvx_index] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.gm_gmk_land_3_obj_tvx_list.buf[( int )tvx_index];
        }
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = uv.u;
        gms_TVX_EX_WORK.coord.v = uv.v;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        AppMain.GmTvxSetModelEx( tvx_FILE, texlist, ref pos, ref scale, disp_flag, dir_z, ref gms_TVX_EX_WORK );
    }
}
