using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0200026B RID: 619
    private class GMS_CAMERA_WORK
    {
        // Token: 0x04005936 RID: 22838
        public int flag;

        // Token: 0x04005937 RID: 22839
        public int timer;

        // Token: 0x04005938 RID: 22840
        public int offset;

        // Token: 0x04005939 RID: 22841
        public float scale_now;

        // Token: 0x0400593A RID: 22842
        public float scale_target;

        // Token: 0x0400593B RID: 22843
        public float scale_spd;
    }


    // Token: 0x06001042 RID: 4162 RVA: 0x0008DA10 File Offset: 0x0008BC10
    private static void GmCameraInit()
    {
        AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(177f, -15800f, 50f);
        AppMain.ObjCameraInit( 0, nns_VECTOR, 4, 0, 8192 );
        AppMain.ObjCamera3dInit( 0 );
        AppMain.g_obj.glb_camera_id = 0;
        AppMain.g_obj.glb_camera_type = 1;
        AppMain.GmCameraDelayReset();
        AppMain.GmCameraAllowReset();
        AppMain.ObjCameraSetUserFunc( 0, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.GmCameraFunc ) );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.scale = 0.67438334f;
        obs_CAMERA.ofst.z = 1000f;
        AppMain.gm_camera_vibration.x = 0f;
        AppMain.gm_camera_vibration.y = 0f;
        AppMain.gm_camera_vibration.z = 0f;
        AppMain.gm_camera_work.flag = 0;
        AppMain.gm_camera_work.timer = 0;
        AppMain.gm_camera_work.offset = 0;
        AppMain.gm_camera_work.scale_now = 1f;
        AppMain.gm_camera_work.scale_target = 1f;
        AppMain.gm_camera_work.scale_spd = 0.1f;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 0 || num == 1 || num == 2 || num == 4 || num == 5 )
        {
            AppMain.NNS_VECTOR pos = new AppMain.NNS_VECTOR(0f, 0f, 60f);
            AppMain.ObjCameraInit( 1, pos, 4, 0, 8192 );
            AppMain.ObjCamera3dInit( 1 );
            AppMain.ObjCameraSetUserFunc( 1, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.gmCameraFuncMapFar ) );
            obs_CAMERA = AppMain.ObjCameraGet( 1 );
            obs_CAMERA.command_state = 1U;
            if ( 2 == num )
            {
                obs_CAMERA.fovy = AppMain.NNM_DEGtoA32( 40f );
            }
            else
            {
                obs_CAMERA.fovy = AppMain.NNM_DEGtoA32( 40f );
            }
            obs_CAMERA.znear = 0.1f;
            obs_CAMERA.zfar = 32768f;
        }
        AppMain.NNS_VECTOR pos2 = new AppMain.NNS_VECTOR(177f, -15800f, 50f);
        int[] array = new int[]
        {
            2,
            3,
            4,
            5
        };
        int[] array2 = new int[]
        {
            0,
            4,
            6,
            8
        };
        uint[] array3 = new uint[4];
        array3[0] = 7U;
        uint[] array4 = array3;
        for ( int i = 0; i < 4; i++ )
        {
            if ( AppMain.g_gm_gamedat_map_set_add[array2[i]] != null )
            {
                AppMain.ObjCameraInit( array[i], pos2, 4, 0, 8192 );
                AppMain.ObjCamera3dInit( array[i] );
                AppMain.ObjCameraSetUserFunc( array[i], new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.gmCameraFuncAddMap ) );
                AppMain.OBS_CAMERA obs_CAMERA2 = AppMain.ObjCameraGet(array[i]);
                obs_CAMERA2.scale = 0.67438334f;
                obs_CAMERA2.ofst.z = 1000f;
                obs_CAMERA2.command_state = array4[i];
            }
        }
        AppMain.NNS_VECTOR pos3 = new AppMain.NNS_VECTOR(nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z);
        AppMain.ObjCameraInit( 6, pos3, 4, 0, 8192 );
        AppMain.ObjCamera3dInit( 6 );
        AppMain.ObjCameraSetUserFunc( 6, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.gmCameraFuncWater ) );
        obs_CAMERA = AppMain.ObjCameraGet( 6 );
        obs_CAMERA.command_state = 9U;
        obs_CAMERA.scale = 0.67438334f;
        obs_CAMERA.ofst.z = 1000f;
    }

    // Token: 0x06001043 RID: 4163 RVA: 0x0008DD04 File Offset: 0x0008BF04
    private static void GmCameraExit()
    {
    }

    // Token: 0x06001044 RID: 4164 RVA: 0x0008DD08 File Offset: 0x0008BF08
    public static void GmCameraPosSet( int pos_x, int pos_y, int pos_z )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        float num = (float)(AppMain.GSD_DISP_WIDTH / 2) * obs_CAMERA.scale;
        float num2 = (float)(AppMain.GSD_DISP_HEIGHT / 2) * obs_CAMERA.scale;
        float num3 = (float)AppMain.g_gm_main_system.map_fcol.bottom - (float)(AppMain.GSD_DISP_HEIGHT / 2) * obs_CAMERA.scale;
        obs_CAMERA.pos.x = AppMain.FXM_FX32_TO_FLOAT( pos_x );
        if ( obs_CAMERA.pos.x < num )
        {
            obs_CAMERA.pos.x = num;
        }
        obs_CAMERA.pos.y = -AppMain.FXM_FX32_TO_FLOAT( pos_y );
        if ( obs_CAMERA.pos.y > -num2 )
        {
            obs_CAMERA.pos.y = -num2;
        }
        if ( obs_CAMERA.pos.y > num3 )
        {
            obs_CAMERA.pos.y = num3;
        }
        obs_CAMERA.pos.z = AppMain.FXM_FX32_TO_FLOAT( pos_z ) + 50f;
        obs_CAMERA.disp_pos.x = obs_CAMERA.pos.x;
        obs_CAMERA.disp_pos.y = obs_CAMERA.pos.y;
        obs_CAMERA.disp_pos.z = obs_CAMERA.pos.z;
    }

    // Token: 0x06001045 RID: 4165 RVA: 0x0008DE29 File Offset: 0x0008C029
    private static void GmCameraVibrationSet( int vib_x, int vib_y, int vib_z )
    {
        AppMain.gm_camera_vibration.x = AppMain.FXM_FX32_TO_FLOAT( vib_x );
        AppMain.gm_camera_vibration.y = AppMain.FXM_FX32_TO_FLOAT( vib_y );
        AppMain.gm_camera_vibration.z = AppMain.FXM_FX32_TO_FLOAT( vib_z );
    }

    // Token: 0x06001046 RID: 4166 RVA: 0x0008DE5B File Offset: 0x0008C05B
    private static void GmCameraAllowSet( float alw_x, float alw_y, float alw_z )
    {
        AppMain.gm_camera_option_allow_pos.x = alw_x;
        AppMain.gm_camera_option_allow_pos.y = alw_y;
        AppMain.gm_camera_option_allow_pos.z = alw_z;
        AppMain.ObjCameraAllowSet( 0, AppMain.gm_camera_option_allow_pos );
    }

    // Token: 0x06001047 RID: 4167 RVA: 0x0008DE89 File Offset: 0x0008C089
    private static void GmCameraAllowReset()
    {
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.ObjCameraAllowSet( 0, AppMain.gm_camera_common_allow_pos );
            return;
        }
        AppMain.ObjCameraAllowSet( 0, AppMain.gm_camera_splstg_allow_pos );
    }

    // Token: 0x06001048 RID: 4168 RVA: 0x0008DEAC File Offset: 0x0008C0AC
    private static void GmCameraDelaySet( float dly_x, float dly_y, float dly_z )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = dly_x;
        nns_VECTOR.y = dly_y;
        nns_VECTOR.z = dly_z;
        AppMain.ObjCameraPlaySet( 0, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06001049 RID: 4169 RVA: 0x0008DEE4 File Offset: 0x0008C0E4
    private static void GmCameraDelayReset()
    {
        AppMain.NNS_VECTOR ofst = new AppMain.NNS_VECTOR(50f, 50f, 0f);
        AppMain.NNS_VECTOR ofst2 = new AppMain.NNS_VECTOR(0f, 0f, 0f);
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            AppMain.ObjCameraPlaySet( 0, ofst );
            return;
        }
        AppMain.ObjCameraPlaySet( 0, ofst2 );
    }

    // Token: 0x0600104A RID: 4170 RVA: 0x0008DF31 File Offset: 0x0008C131
    private static void GmCameraScaleSet( float scale_target, float scale_spd )
    {
        AppMain.gm_camera_work.scale_target = scale_target;
        AppMain.gm_camera_work.scale_spd = scale_spd;
    }

    // Token: 0x0600104B RID: 4171 RVA: 0x0008DF49 File Offset: 0x0008C149
    public static void GmCameraSetClipCamera( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.ObjObjectClipCameraSet( AppMain.g_obj.camera[0][0], AppMain.g_obj.camera[0][1] );
    }

    // Token: 0x0600104C RID: 4172 RVA: 0x0008DF6C File Offset: 0x0008C16C
    private static void GmCameraFunc( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.SNNS_VECTOR snns_VECTOR;
        snns_VECTOR.x = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.x );
        snns_VECTOR.z = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.z );
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            snns_VECTOR.y = AppMain.FXM_FX32_TO_FLOAT( -gms_PLAYER_WORK.obj_work.pos.y + 24576 );
        }
        else
        {
            snns_VECTOR.y = AppMain.FXM_FX32_TO_FLOAT( -gms_PLAYER_WORK.obj_work.pos.y + 8192 );
        }
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U && ( gms_PLAYER_WORK.player_flag & 65536U ) == 0U )
        {
            snns_VECTOR.x = obj_camera.work.x;
            snns_VECTOR.y = obj_camera.work.y;
            snns_VECTOR.z = obj_camera.work.z;
        }
        else
        {
            obj_camera.work.x = snns_VECTOR.x;
            obj_camera.work.y = snns_VECTOR.y;
            obj_camera.work.z = snns_VECTOR.z;
        }
        obj_camera.prev_pos.x = obj_camera.pos.x;
        obj_camera.prev_pos.y = obj_camera.pos.y;
        obj_camera.prev_pos.z = obj_camera.pos.z;
        if ( ( obj_camera.flag & 1U ) != 0U )
        {
            if ( obj_camera.target_obj != null )
            {
                obj_camera.pos.x = snns_VECTOR.x;
                obj_camera.pos.y = snns_VECTOR.y;
                obj_camera.pos.z = snns_VECTOR.z;
            }
            return;
        }
        AppMain.gmCameraScaleChange( obj_camera );
        if ( ( obj_camera.flag & 2U ) != 0U )
        {
            obj_camera.pos.x = AppMain.ObjShiftSetF( obj_camera.pos.x, snns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.x, obj_camera.spd_add.x );
            obj_camera.pos.y = AppMain.ObjShiftSetF( obj_camera.pos.y, snns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.y, obj_camera.spd_add.y );
            obj_camera.pos.z = AppMain.ObjShiftSetF( obj_camera.pos.z, snns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.z, obj_camera.spd_add.z );
        }
        else
        {
            obj_camera.allow.x = obj_camera.allow_limit.x;
            obj_camera.allow.z = obj_camera.allow_limit.z;
            if ( ( gms_PLAYER_WORK.obj_work.move_flag & 16U ) != 0U )
            {
                obj_camera.allow.y = obj_camera.allow_limit.y;
            }
            else
            {
                obj_camera.allow.y = Math.Max( obj_camera.allow.y - 4f, 0f );
            }
            if ( snns_VECTOR.x < obj_camera.pos.x - obj_camera.allow.x )
            {
                snns_VECTOR.x += obj_camera.allow.x;
            }
            else if ( snns_VECTOR.x > obj_camera.pos.x + obj_camera.allow.x )
            {
                snns_VECTOR.x -= obj_camera.allow.x;
            }
            else
            {
                snns_VECTOR.x = obj_camera.pos.x;
            }
            if ( snns_VECTOR.y < obj_camera.pos.y - obj_camera.allow.y )
            {
                snns_VECTOR.y += obj_camera.allow.y;
            }
            else if ( snns_VECTOR.y > obj_camera.pos.y + obj_camera.allow.y )
            {
                snns_VECTOR.y -= obj_camera.allow.y;
            }
            else
            {
                snns_VECTOR.y = obj_camera.pos.y;
            }
            if ( snns_VECTOR.x != obj_camera.pos.x )
            {
                obj_camera.spd.x = AppMain.ObjSpdUpSetF( obj_camera.spd.x, obj_camera.spd_add.x, obj_camera.spd_max.x );
            }
            else
            {
                obj_camera.spd.x = AppMain.ObjSpdDownSetF( obj_camera.spd.x, obj_camera.spd_add.x );
            }
            if ( snns_VECTOR.y != obj_camera.pos.y )
            {
                obj_camera.spd.y = AppMain.ObjSpdUpSetF( obj_camera.spd.y, obj_camera.spd_add.y, obj_camera.spd_max.y );
            }
            else
            {
                obj_camera.spd.y = AppMain.ObjSpdDownSetF( obj_camera.spd.y, obj_camera.spd_add.y );
            }
            if ( snns_VECTOR.z != obj_camera.pos.z )
            {
                obj_camera.spd.z = AppMain.ObjSpdUpSetF( obj_camera.spd.z, obj_camera.spd_add.z, obj_camera.spd_max.z );
            }
            else
            {
                obj_camera.spd.z = AppMain.ObjSpdDownSetF( obj_camera.spd.z, obj_camera.spd_add.z );
            }
            if ( snns_VECTOR.x > obj_camera.pos.x )
            {
                obj_camera.pos.x += obj_camera.spd.x;
                if ( obj_camera.pos.x > snns_VECTOR.x )
                {
                    obj_camera.pos.x = snns_VECTOR.x;
                }
            }
            else
            {
                obj_camera.pos.x -= obj_camera.spd.x;
                if ( obj_camera.pos.x < snns_VECTOR.x )
                {
                    obj_camera.pos.x = snns_VECTOR.x;
                }
            }
            if ( snns_VECTOR.y > obj_camera.pos.y )
            {
                obj_camera.pos.y += obj_camera.spd.y;
                if ( obj_camera.pos.y > snns_VECTOR.y )
                {
                    obj_camera.pos.y = snns_VECTOR.y;
                }
            }
            else
            {
                obj_camera.pos.y -= obj_camera.spd.y;
                if ( obj_camera.pos.y < snns_VECTOR.y )
                {
                    obj_camera.pos.y = snns_VECTOR.y;
                }
            }
            if ( snns_VECTOR.z > obj_camera.pos.z )
            {
                obj_camera.pos.z += obj_camera.spd.z;
                if ( obj_camera.pos.z > snns_VECTOR.z )
                {
                    obj_camera.pos.z = snns_VECTOR.z;
                }
            }
            else
            {
                obj_camera.pos.z -= obj_camera.spd.z;
                if ( obj_camera.pos.z < snns_VECTOR.z )
                {
                    obj_camera.pos.z = snns_VECTOR.z;
                }
            }
        }
        if ( AppMain.MTM_MATH_ABS( snns_VECTOR.z - obj_camera.pos.z ) > obj_camera.play_ofst_max.z )
        {
            if ( snns_VECTOR.z > obj_camera.pos.z )
            {
                obj_camera.pos.z = snns_VECTOR.z - obj_camera.play_ofst_max.z;
            }
            else
            {
                obj_camera.pos.z = snns_VECTOR.z + obj_camera.play_ofst_max.z;
            }
        }
        obj_camera.disp_ofst.x = AppMain.gm_camera_vibration.x / 16f;
        obj_camera.disp_ofst.y = AppMain.gm_camera_vibration.y / 16f;
        obj_camera.disp_ofst.z = AppMain.gm_camera_vibration.z / 16f;
        AppMain.gm_camera_vibration.x = AppMain.gmCameraVibCheck( AppMain.gm_camera_vibration.x );
        AppMain.gm_camera_vibration.y = AppMain.gmCameraVibCheck( AppMain.gm_camera_vibration.y );
        AppMain.gm_camera_vibration.z = AppMain.gmCameraVibCheck( AppMain.gm_camera_vibration.z );
        obj_camera.pos.z = 50f;
        AppMain.SNNS_VECTOR snns_VECTOR2;
        snns_VECTOR2.x = obj_camera.ofst.x;
        snns_VECTOR2.y = obj_camera.ofst.y;
        snns_VECTOR2.z = obj_camera.ofst.z;
        if ( obj_camera.scale < 0.67438334f )
        {
            float num = obj_camera.scale - 0.33719167f;
            num /= 0.33719167f;
            snns_VECTOR2.x *= num;
            snns_VECTOR2.y *= num;
        }
        obj_camera.disp_pos.x = obj_camera.pos.x + snns_VECTOR2.x;
        obj_camera.disp_pos.y = obj_camera.pos.y + snns_VECTOR2.y;
        obj_camera.disp_pos.z = obj_camera.pos.z + snns_VECTOR2.z;
        AppMain.gmCameraLookupCheck( obj_camera );
        float num2 = (float)AppMain.g_gm_main_system.map_fcol.left + (float)(AppMain.GSD_DISP_WIDTH / 2) * obj_camera.scale;
        float num3 = (float)AppMain.g_gm_main_system.map_fcol.right - (float)(AppMain.GSD_DISP_WIDTH / 2) * obj_camera.scale;
        float num4 = (float)AppMain.g_gm_main_system.map_fcol.top + (float)(AppMain.GSD_DISP_HEIGHT / 2) * obj_camera.scale;
        float num5 = (float)AppMain.g_gm_main_system.map_fcol.bottom - (float)(AppMain.GSD_DISP_HEIGHT / 2) * obj_camera.scale;
        if ( obj_camera.disp_pos.x < num2 )
        {
            obj_camera.disp_pos.x = num2;
            if ( obj_camera.disp_pos.x > num3 )
            {
                obj_camera.disp_pos.x = ( num3 + num2 ) / 2f;
            }
        }
        else if ( obj_camera.disp_pos.x > num3 )
        {
            obj_camera.disp_pos.x = num3;
            if ( obj_camera.disp_pos.x < num2 )
            {
                obj_camera.disp_pos.x = ( num3 + num2 ) / 2f;
            }
        }
        if ( obj_camera.disp_pos.y > -num4 )
        {
            obj_camera.disp_pos.y = -num4;
        }
        if ( obj_camera.disp_pos.y < -num5 )
        {
            obj_camera.disp_pos.y = -num5;
        }
        obj_camera.target_pos.Assign( obj_camera.disp_pos );
        obj_camera.target_pos.z -= 50f;
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            if ( ( obj_camera.flag & 2147483648U ) != 0U && ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
            {
                short num6 = (short)-(short)gms_PLAYER_WORK.obj_work.dir.z;
                short num7 = (short)obj_camera.roll;
                short roll;
                if ( ( ushort )num6 > 16384 && ( ushort )num6 < 49152 )
                {
                    roll = ( short )( ( ( ushort )num6 + ( ushort )num7 ) / 2 );
                }
                else
                {
                    roll = ( short )( ( num6 + num7 ) / 2 );
                }
                obj_camera.roll = ( int )roll;
                obj_camera.flag &= 2147483647U;
            }
            else
            {
                obj_camera.roll = obj_camera.roll * 9 / 10;
                obj_camera.flag &= 2147483647U;
            }
        }
        AppMain.ObjObjectCameraSet( AppMain.FXM_FLOAT_TO_FX32( obj_camera.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_camera.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( obj_camera.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_camera.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ) );
        AppMain.GmCameraSetClipCamera( obj_camera );
    }

    // Token: 0x0600104D RID: 4173 RVA: 0x0008EB28 File Offset: 0x0008CD28
    private static void gmCameraFuncMapFar( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obj_camera.pos.Assign( AppMain.GmMapFarGetCameraPos( obs_CAMERA.disp_pos ) );
        obj_camera.target_pos.Assign( AppMain.GmMapFarGetCameraTarget( obj_camera.pos ) );
        obj_camera.disp_pos.Assign( obj_camera.pos );
        if ( !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            obj_camera.roll = obs_CAMERA.roll;
        }
    }

    // Token: 0x0600104E RID: 4174 RVA: 0x0008EB90 File Offset: 0x0008CD90
    private static void gmCameraFuncAddMap( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obj_camera.prev_pos.Assign( obj_camera.pos );
        obj_camera.prev_disp_pos.Assign( obj_camera.disp_pos );
        obj_camera.disp_pos.Assign( obs_CAMERA.disp_pos );
        obj_camera.pos.Assign( obs_CAMERA.pos );
        obj_camera.ofst.Assign( obs_CAMERA.ofst );
        obj_camera.disp_ofst.Assign( obs_CAMERA.disp_ofst );
        obj_camera.target_ofst.Assign( obs_CAMERA.target_ofst );
        obj_camera.play_ofst_max.Assign( obs_CAMERA.play_ofst_max );
        obj_camera.camup_obj = obs_CAMERA.camup_obj;
        obj_camera.camup_pos.Assign( obs_CAMERA.camup_pos );
        obj_camera.roll = obs_CAMERA.roll;
        obj_camera.up_vec.Assign( obs_CAMERA.up_vec );
        obj_camera.scale = obs_CAMERA.scale;
        obj_camera.left = obs_CAMERA.left;
        obj_camera.right = obs_CAMERA.right;
        obj_camera.bottom = obs_CAMERA.bottom;
        obj_camera.top = obs_CAMERA.top;
        obj_camera.znear = obs_CAMERA.znear;
        obj_camera.zfar = obs_CAMERA.zfar;
        obj_camera.aspect = obs_CAMERA.aspect;
        AppMain.GmMapGetAddMapCameraPos( obs_CAMERA.disp_pos, obs_CAMERA.target_pos, obj_camera.disp_pos, obj_camera.target_pos, obj_camera.camera_id );
    }

    // Token: 0x0600104F RID: 4175 RVA: 0x0008ECF4 File Offset: 0x0008CEF4
    private static void gmCameraFuncWater( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        AppMain.nnCopyVector( obj_camera.pos, obs_CAMERA.pos );
        AppMain.nnCopyVector( obj_camera.target_pos, obs_CAMERA.target_pos );
        AppMain.nnCopyVector( obj_camera.disp_pos, obs_CAMERA.disp_pos );
    }

    // Token: 0x06001050 RID: 4176 RVA: 0x0008ED3C File Offset: 0x0008CF3C
    private static void GmCameraTruckFunc( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U && ( gms_PLAYER_WORK.player_flag & 65536U ) == 0U )
        {
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
            return;
        }
        nns_VECTOR.x = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.x );
        nns_VECTOR.y = AppMain.FXM_FX32_TO_FLOAT( -gms_PLAYER_WORK.obj_work.pos.y + 24576 );
        nns_VECTOR.z = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.z );
        obj_camera.work.x = nns_VECTOR.x;
        obj_camera.work.y = nns_VECTOR.y;
        obj_camera.work.z = nns_VECTOR.z;
        obj_camera.prev_pos.x = obj_camera.pos.x;
        obj_camera.prev_pos.y = obj_camera.pos.y;
        obj_camera.prev_pos.z = obj_camera.pos.z;
        if ( ( obj_camera.flag & 1U ) != 0U )
        {
            if ( obj_camera.target_obj != null )
            {
                obj_camera.pos.x = nns_VECTOR.x;
                obj_camera.pos.y = nns_VECTOR.y;
                obj_camera.pos.z = nns_VECTOR.z;
            }
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
            return;
        }
        if ( ( obj_camera.flag & 2U ) != 0U )
        {
            obj_camera.pos.x = AppMain.ObjShiftSetF( obj_camera.pos.x, nns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.x, obj_camera.spd_add.x );
            obj_camera.pos.y = AppMain.ObjShiftSetF( obj_camera.pos.y, nns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.y, obj_camera.spd_add.y );
            obj_camera.pos.z = AppMain.ObjShiftSetF( obj_camera.pos.z, nns_VECTOR.x, ( int )obj_camera.shift, obj_camera.spd_max.z, obj_camera.spd_add.z );
        }
        else
        {
            obj_camera.allow.x = obj_camera.allow_limit.x;
            obj_camera.allow.z = obj_camera.allow_limit.z;
            if ( ( gms_PLAYER_WORK.obj_work.move_flag & 16U ) != 0U )
            {
                obj_camera.allow.y = obj_camera.allow_limit.y;
            }
            else
            {
                obj_camera.allow.y = Math.Max( obj_camera.allow.y - 4f, 0f );
            }
            if ( nns_VECTOR.x < obj_camera.pos.x - obj_camera.allow.x )
            {
                nns_VECTOR.x += obj_camera.allow.x;
            }
            else if ( nns_VECTOR.x > obj_camera.pos.x + obj_camera.allow.x )
            {
                nns_VECTOR.x -= obj_camera.allow.x;
            }
            else
            {
                nns_VECTOR.x = obj_camera.pos.x;
            }
            if ( nns_VECTOR.y < obj_camera.pos.y - obj_camera.allow.y )
            {
                nns_VECTOR.y += obj_camera.allow.y;
            }
            else if ( nns_VECTOR.y > obj_camera.pos.y + obj_camera.allow.y )
            {
                nns_VECTOR.y -= obj_camera.allow.y;
            }
            else
            {
                nns_VECTOR.y = obj_camera.pos.y;
            }
            if ( nns_VECTOR.x != obj_camera.pos.x )
            {
                obj_camera.spd.x = AppMain.ObjSpdUpSetF( obj_camera.spd.x, obj_camera.spd_add.x, obj_camera.spd_max.x );
            }
            else
            {
                obj_camera.spd.x = AppMain.ObjSpdDownSetF( obj_camera.spd.x, obj_camera.spd_add.x );
            }
            if ( nns_VECTOR.y != obj_camera.pos.y )
            {
                obj_camera.spd.y = AppMain.ObjSpdUpSetF( obj_camera.spd.y, obj_camera.spd_add.y, obj_camera.spd_max.y );
            }
            else
            {
                obj_camera.spd.y = AppMain.ObjSpdDownSetF( obj_camera.spd.y, obj_camera.spd_add.y );
            }
            if ( nns_VECTOR.z != obj_camera.pos.z )
            {
                obj_camera.spd.z = AppMain.ObjSpdUpSetF( obj_camera.spd.z, obj_camera.spd_add.z, obj_camera.spd_max.z );
            }
            else
            {
                obj_camera.spd.z = AppMain.ObjSpdDownSetF( obj_camera.spd.z, obj_camera.spd_add.z );
            }
            if ( nns_VECTOR.x > obj_camera.pos.x )
            {
                obj_camera.pos.x += obj_camera.spd.x;
                if ( obj_camera.pos.x > nns_VECTOR.x )
                {
                    obj_camera.pos.x = nns_VECTOR.x;
                }
            }
            else
            {
                obj_camera.pos.x -= obj_camera.spd.x;
                if ( obj_camera.pos.x < nns_VECTOR.x )
                {
                    obj_camera.pos.x = nns_VECTOR.x;
                }
            }
            if ( nns_VECTOR.y > obj_camera.pos.y )
            {
                obj_camera.pos.y += obj_camera.spd.y;
                if ( obj_camera.pos.y > nns_VECTOR.y )
                {
                    obj_camera.pos.y = nns_VECTOR.y;
                }
            }
            else
            {
                obj_camera.pos.y -= obj_camera.spd.y;
                if ( obj_camera.pos.y < nns_VECTOR.y )
                {
                    obj_camera.pos.y = nns_VECTOR.y;
                }
            }
            if ( nns_VECTOR.z > obj_camera.pos.z )
            {
                obj_camera.pos.z += obj_camera.spd.z;
                if ( obj_camera.pos.z > nns_VECTOR.z )
                {
                    obj_camera.pos.z = nns_VECTOR.z;
                }
            }
            else
            {
                obj_camera.pos.z -= obj_camera.spd.z;
                if ( obj_camera.pos.z < nns_VECTOR.z )
                {
                    obj_camera.pos.z = nns_VECTOR.z;
                }
            }
        }
        if ( AppMain.MTM_MATH_ABS( nns_VECTOR.z - obj_camera.pos.z ) > obj_camera.play_ofst_max.z )
        {
            if ( nns_VECTOR.z > obj_camera.pos.z )
            {
                obj_camera.pos.z = nns_VECTOR.z - obj_camera.play_ofst_max.z;
            }
            else
            {
                obj_camera.pos.z = nns_VECTOR.z + obj_camera.play_ofst_max.z;
            }
        }
        obj_camera.disp_ofst.x = AppMain.gm_camera_vibration.x / 16f;
        obj_camera.disp_ofst.y = AppMain.gm_camera_vibration.y / 16f;
        obj_camera.disp_ofst.z = AppMain.gm_camera_vibration.z / 16f;
        AppMain.gm_camera_vibration.x = AppMain.gmCameraVibCheck( AppMain.gm_camera_vibration.x );
        AppMain.gm_camera_vibration.y = AppMain.gmCameraVibCheck( AppMain.gm_camera_vibration.y );
        AppMain.gm_camera_vibration.z = AppMain.gmCameraVibCheck( AppMain.gm_camera_vibration.z );
        obj_camera.pos.z = 50f;
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR2.x = obj_camera.ofst.x;
        nns_VECTOR2.y = obj_camera.ofst.y;
        nns_VECTOR2.z = obj_camera.ofst.z;
        if ( obj_camera.scale < 0.67438334f )
        {
            float num = obj_camera.scale - 0.33719167f;
            num /= 0.33719167f;
            nns_VECTOR2.x *= num;
            nns_VECTOR2.y *= num;
        }
        obj_camera.disp_pos.x = obj_camera.pos.x + nns_VECTOR2.x;
        obj_camera.disp_pos.y = obj_camera.pos.y + nns_VECTOR2.y;
        obj_camera.disp_pos.z = obj_camera.pos.z + nns_VECTOR2.z;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.gmCameraLookupCheck( obj_camera );
        float num2 = (float)AppMain.g_gm_main_system.map_fcol.left + (float)(AppMain.GSD_DISP_WIDTH / 2) * obj_camera.scale;
        float num3 = (float)AppMain.g_gm_main_system.map_fcol.right - (float)(AppMain.GSD_DISP_WIDTH / 2) * obj_camera.scale;
        float num4 = (float)AppMain.g_gm_main_system.map_fcol.top + (float)(AppMain.GSD_DISP_HEIGHT / 2) * obj_camera.scale;
        float num5 = (float)AppMain.g_gm_main_system.map_fcol.bottom - (float)(AppMain.GSD_DISP_HEIGHT / 2) * obj_camera.scale;
        if ( obj_camera.disp_pos.x < num2 )
        {
            obj_camera.disp_pos.x = num2;
        }
        if ( obj_camera.disp_pos.x > num3 )
        {
            obj_camera.disp_pos.x = num3;
        }
        if ( obj_camera.disp_pos.y > -num4 )
        {
            obj_camera.disp_pos.y = -num4;
        }
        if ( obj_camera.disp_pos.y < -num5 )
        {
            obj_camera.disp_pos.y = -num5;
        }
        obj_camera.target_pos.Assign( obj_camera.disp_pos );
        obj_camera.target_pos.z -= 50f;
        int num6 = 4608;
        if ( ( gms_PLAYER_WORK.gmk_flag2 & 32U ) != 0U )
        {
            num6 = 672;
        }
        int num7 = -gms_PLAYER_WORK.ply_pseudofall_dir - obj_camera.roll;
        if ( num7 > 32768 )
        {
            num7 -= 65536;
        }
        else if ( num7 < -32768 )
        {
            num7 += 65536;
        }
        int num8;
        if ( AppMain.MTM_MATH_ABS( num7 ) < 128 )
        {
            num8 = num7;
        }
        else
        {
            num8 = num7 >> 4;
            if ( AppMain.MTM_MATH_ABS( num8 ) > 3328 )
            {
                num8 += num8 - 3328;
            }
            if ( AppMain.MTM_MATH_ABS( num8 ) > num6 )
            {
                if ( num8 >= 0 )
                {
                    num8 = num6;
                }
                else
                {
                    num8 = -num6;
                }
            }
            else if ( AppMain.MTM_MATH_ABS( num8 ) < 128 )
            {
                if ( num8 >= 0 )
                {
                    num8 = 128;
                }
                else
                {
                    num8 = -128;
                }
            }
        }
        obj_camera.roll += num8;
        if ( obj_camera.roll > 65536 )
        {
            obj_camera.roll -= 65536;
            gms_PLAYER_WORK.ply_pseudofall_dir += 65536;
        }
        else if ( obj_camera.roll < -65536 )
        {
            obj_camera.roll += 65536;
            gms_PLAYER_WORK.ply_pseudofall_dir -= 65536;
        }
        AppMain.ObjObjectCameraSet( AppMain.FXM_FLOAT_TO_FX32( obj_camera.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_camera.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( obj_camera.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_camera.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ) );
        AppMain.GmCameraSetClipCamera( obj_camera );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06001051 RID: 4177 RVA: 0x0008F8B8 File Offset: 0x0008DAB8
    private static float gmCameraVibCheck( float vib )
    {
        if ( vib != 0f )
        {
            if ( vib > 0f )
            {
                vib = 0f - ( vib - 1f );
                if ( vib > 0f )
                {
                    vib = 0f;
                }
            }
            else
            {
                vib = 0f - ( vib + 1f );
                if ( vib < 0f )
                {
                    vib = 0f;
                }
            }
        }
        return vib;
    }

    // Token: 0x06001052 RID: 4178 RVA: 0x0008F914 File Offset: 0x0008DB14
    private static void gmCameraLookupCheck( AppMain.OBS_CAMERA obj_camera )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        int num = 0;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE() )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state == 4 && ( gms_PLAYER_WORK.key_on & 1 ) != 0 )
        {
            num = 1;
        }
        if ( gms_PLAYER_WORK.seq_state == 7 && ( gms_PLAYER_WORK.key_on & 2 ) != 0 )
        {
            num = 2;
        }
        if ( ( AppMain.gm_camera_work.flag & num ) != 0 && AppMain.gm_camera_work.timer > 90 )
        {
            if ( ( AppMain.gm_camera_work.flag & 1 ) != 0 )
            {
                AppMain.gm_camera_work.offset += 2;
            }
            else
            {
                AppMain.gm_camera_work.offset -= 2;
            }
            int num2 = gms_PLAYER_WORK.camera_ofst_y >> 12;
            AppMain.gm_camera_work.offset = AppMain.MTM_MATH_CLIP( AppMain.gm_camera_work.offset, -96 - num2, 80 - num2 );
        }
        else
        {
            if ( ( AppMain.gm_camera_work.flag & num ) != 0 )
            {
                AppMain.gm_camera_work.timer++;
            }
            else if ( num != 0 )
            {
                AppMain.gm_camera_work.flag = num;
                AppMain.gm_camera_work.timer = 1;
            }
            else
            {
                AppMain.gm_camera_work.flag = 0;
                AppMain.gm_camera_work.timer = 0;
            }
            if ( AppMain.gm_camera_work.offset > 0 )
            {
                AppMain.gm_camera_work.offset -= 2;
                if ( AppMain.gm_camera_work.offset < 0 )
                {
                    AppMain.gm_camera_work.offset = 0;
                }
            }
            else if ( AppMain.gm_camera_work.offset < 0 )
            {
                AppMain.gm_camera_work.offset += 2;
                if ( AppMain.gm_camera_work.offset > 0 )
                {
                    AppMain.gm_camera_work.offset = 0;
                }
            }
        }
        switch ( ( ushort )( obj_camera.roll + 8192 >> 14 ) )
        {
            case 0:
                obj_camera.disp_pos.y += ( float )AppMain.gm_camera_work.offset;
                return;
            case 1:
                obj_camera.disp_pos.x -= ( float )AppMain.gm_camera_work.offset;
                return;
            case 2:
                obj_camera.disp_pos.y -= ( float )AppMain.gm_camera_work.offset;
                return;
            case 3:
                obj_camera.disp_pos.x += ( float )AppMain.gm_camera_work.offset;
                return;
            default:
                return;
        }
    }

    // Token: 0x06001053 RID: 4179 RVA: 0x0008FB4C File Offset: 0x0008DD4C
    private static void gmCameraScaleChange( AppMain.OBS_CAMERA obj_camera )
    {
        if ( AppMain.gm_camera_work.scale_now == AppMain.gm_camera_work.scale_target )
        {
            return;
        }
        if ( AppMain.gm_camera_work.scale_now < AppMain.gm_camera_work.scale_target )
        {
            AppMain.gm_camera_work.scale_now += AppMain.gm_camera_work.scale_spd;
            if ( AppMain.gm_camera_work.scale_now > AppMain.gm_camera_work.scale_target )
            {
                AppMain.gm_camera_work.scale_now = AppMain.gm_camera_work.scale_target;
            }
        }
        else if ( AppMain.gm_camera_work.scale_now > AppMain.gm_camera_work.scale_target )
        {
            AppMain.gm_camera_work.scale_now -= AppMain.gm_camera_work.scale_spd;
            if ( AppMain.gm_camera_work.scale_now < AppMain.gm_camera_work.scale_target )
            {
                AppMain.gm_camera_work.scale_now = AppMain.gm_camera_work.scale_target;
            }
        }
        obj_camera.scale = 0.67438334f / AppMain.gm_camera_work.scale_now;
    }
}