using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020003CC RID: 972
    public class GMS_GMK_PWALL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600283C RID: 10300 RVA: 0x00152A13 File Offset: 0x00150C13
        public GMS_GMK_PWALL_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600283D RID: 10301 RVA: 0x00152A27 File Offset: 0x00150C27
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_PWALL_WORK p )
        {
            return p.gmk_work;
        }

        // Token: 0x0600283E RID: 10302 RVA: 0x00152A2F File Offset: 0x00150C2F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0600283F RID: 10303 RVA: 0x00152A41 File Offset: 0x00150C41
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_PWALL_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0400620E RID: 25102
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x0400620F RID: 25103
        public int master_posy;

        // Token: 0x04006210 RID: 25104
        public int wall_speed;

        // Token: 0x04006211 RID: 25105
        public short wall_vibration;

        // Token: 0x04006212 RID: 25106
        public short wall_effect_build_timer;

        // Token: 0x04006213 RID: 25107
        public int wall_height;

        // Token: 0x04006214 RID: 25108
        public int wall_brake;

        // Token: 0x04006215 RID: 25109
        public int wall_timer;

        // Token: 0x04006216 RID: 25110
        public bool ply_death;

        // Token: 0x04006217 RID: 25111
        public bool stop_wall;

        // Token: 0x04006218 RID: 25112
        public AppMain.OBS_OBJECT_WORK efct_obj;

        // Token: 0x04006219 RID: 25113
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x0400621A RID: 25114
        public uint mat_timer;

        // Token: 0x0400621B RID: 25115
        public uint mat_timer_line;
    }

    // Token: 0x020003CD RID: 973
    public class GMS_GMK_PWALLCTRL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002840 RID: 10304 RVA: 0x00152A53 File Offset: 0x00150C53
        public GMS_GMK_PWALLCTRL_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002841 RID: 10305 RVA: 0x00152A67 File Offset: 0x00150C67
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x17000137 RID: 311
        // (get) Token: 0x06002842 RID: 10306 RVA: 0x00152A79 File Offset: 0x00150C79
        // (set) Token: 0x06002843 RID: 10307 RVA: 0x00152A81 File Offset: 0x00150C81
        public int line_left
        {
            get
            {
                return this.line_top;
            }
            set
            {
                this.line_top = value;
            }
        }

        // Token: 0x17000138 RID: 312
        // (get) Token: 0x06002844 RID: 10308 RVA: 0x00152A8A File Offset: 0x00150C8A
        // (set) Token: 0x06002845 RID: 10309 RVA: 0x00152A92 File Offset: 0x00150C92
        public int line_right
        {
            get
            {
                return this.line_bottom;
            }
            set
            {
                this.line_bottom = value;
            }
        }

        // Token: 0x0400621C RID: 25116
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x0400621D RID: 25117
        public int line_top;

        // Token: 0x0400621E RID: 25118
        public int line_bottom;

        // Token: 0x0400621F RID: 25119
        public AppMain.GMS_PLAYER_WORK ply_work;

        // Token: 0x04006220 RID: 25120
        public int last_ply_x;

        // Token: 0x04006221 RID: 25121
        public int last_ply_y;
    }

    // Token: 0x020003CE RID: 974
    public class GMS_GMK_PRESSWALL_PARTS : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002846 RID: 10310 RVA: 0x00152A9B File Offset: 0x00150C9B
        public GMS_GMK_PRESSWALL_PARTS()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x06002847 RID: 10311 RVA: 0x00152AAF File Offset: 0x00150CAF
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x04006222 RID: 25122
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x04006223 RID: 25123
        public int ofst_y;

        // Token: 0x04006224 RID: 25124
        public int master_posy;
    }

    // Token: 0x06001B18 RID: 6936 RVA: 0x000F6C7C File Offset: 0x000F4E7C
    private static AppMain.OBS_OBJECT_WORK GmGmkPressWallInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_PWALL_WORK(), "Gmk_PressWall");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_PWALL_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_PWALL_WORK;
        if ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 2 )
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_presswall_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWall_ppOut );
            if ( eve_rec.height == 0 )
            {
                gms_GMK_PWALL_WORK.wall_height = 0;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y - 524288;
            }
            else
            {
                gms_GMK_PWALL_WORK.wall_height = ( int )( eve_rec.height * 64 ) * 4096;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y - gms_GMK_PWALL_WORK.wall_height;
            }
            obs_OBJECT_WORK.pos.z = 913408;
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_presswall_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWall_ppOut );
            AppMain.ObjAction3dNNMaterialMotionLoad( obs_OBJECT_WORK.obj_3d, 0, null, null, 1, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 895 ).pData );
            AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
            obs_OBJECT_WORK.disp_flag |= 4U;
            if ( eve_rec.height == 0 )
            {
                gms_GMK_PWALL_WORK.wall_height = 0;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
                obs_OBJECT_WORK4.pos.y = obs_OBJECT_WORK4.pos.y - 786432;
            }
            else
            {
                gms_GMK_PWALL_WORK.wall_height = ( int )( eve_rec.height * 192 ) * 4096;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK5 = obs_OBJECT_WORK;
                obs_OBJECT_WORK5.pos.y = obs_OBJECT_WORK5.pos.y - gms_GMK_PWALL_WORK.wall_height;
            }
            obs_OBJECT_WORK.pos.z = 1044480;
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        if ( eve_rec.width != 0 )
        {
            gms_GMK_PWALL_WORK.wall_speed = ( int )eve_rec.width * 4096 / 10;
        }
        else
        {
            gms_GMK_PWALL_WORK.wall_speed = 4096;
        }
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkPressWallExit ) );
        gms_GMK_PWALL_WORK.se_handle = null;
        AppMain.gmGmkPressWallStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B19 RID: 6937 RVA: 0x000F6EC4 File Offset: 0x000F50C4
    private static AppMain.OBS_OBJECT_WORK GmGmkPressWallStopInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        if ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 2 && AppMain.pwall == null )
        {
            obs_OBJECT_WORK = AppMain.GmGmkPressWallInit( eve_rec, pos_x, pos_y, type );
            obs_OBJECT_WORK.user_flag = 1U;
        }
        obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK( eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "Gmk_PressWallStopper" );
        obs_OBJECT_WORK.user_flag = 0U;
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            obs_OBJECT_WORK.user_flag = 1U;
        }
        AppMain.gmGmkPressWallStopperStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B1A RID: 6938 RVA: 0x000F6F50 File Offset: 0x000F5150
    private static AppMain.OBS_OBJECT_WORK GmGmkPressWallControlerInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_PWALLCTRL_WORK(), "Gmk_PressWallControler");
        AppMain.GMS_GMK_PWALLCTRL_WORK gms_GMK_PWALLCTRL_WORK = (AppMain.GMS_GMK_PWALLCTRL_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = null;
        obs_RECT_WORK.ppHit = null;
        obs_RECT_WORK.flag &= 4294967291U;
        if ( eve_rec.left != 0 )
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, ( short )( eve_rec.left * 2 ), 0, ( short )( eve_rec.width * 2 ), 1 );
            obs_OBJECT_WORK.user_flag = 0U;
            obs_OBJECT_WORK.user_timer = ( int )eve_rec.height * 819;
        }
        else
        {
            obs_RECT_WORK.ppDef = null;
            obs_RECT_WORK.ppHit = null;
            AppMain.ObjRectWorkSet( obs_RECT_WORK, 0, ( short )( eve_rec.top * 2 ), 1, ( short )( eve_rec.height * 2 ) );
            gms_GMK_PWALLCTRL_WORK.line_top = ( int )( eve_rec.top * 2 ) * 4096 + obs_OBJECT_WORK.pos.y;
            gms_GMK_PWALLCTRL_WORK.line_bottom = ( int )( eve_rec.height * 2 ) * 4096 + obs_OBJECT_WORK.pos.y;
            obs_OBJECT_WORK.user_flag = 1U;
            obs_OBJECT_WORK.user_timer = ( int )eve_rec.width * 819;
        }
        obs_OBJECT_WORK.flag &= 4294967293U;
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            obs_OBJECT_WORK.user_flag |= 2U;
        }
        if ( ( eve_rec.flag & 2 ) != 0 )
        {
            obs_OBJECT_WORK.user_flag |= 4U;
        }
        AppMain.gmGmkPressWallControlerStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B1B RID: 6939 RVA: 0x000F70D5 File Offset: 0x000F52D5
    public static void GmGmkPressWallBuild()
    {
        AppMain.gm_gmk_presswall_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 892 ), AppMain.GmGameDatGetGimmickData( 893 ), 0U );
        AppMain.pwall = null;
    }

    // Token: 0x06001B1C RID: 6940 RVA: 0x000F70FC File Offset: 0x000F52FC
    public static void GmGmkPressWallFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(892);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_presswall_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001B1D RID: 6941 RVA: 0x000F7124 File Offset: 0x000F5324
    private static void gmGmkPressWall_ppOut( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        obj_work.pos.y = gms_GMK_PWALL_WORK.master_posy;
        obj_work.pos.y = obj_work.pos.y + obj_work.user_timer;
        if ( gms_GMK_PWALL_WORK.wall_height == 0 )
        {
            while ( obj_work.pos.y + 786432 < AppMain.g_obj.camera[0][1] )
            {
                obj_work.pos.y = obj_work.pos.y + 786432;
            }
            while ( obj_work.pos.y > AppMain.g_obj.camera[0][1] )
            {
                obj_work.pos.y = obj_work.pos.y - 786432;
            }
            for ( int i = obj_work.pos.y - AppMain.g_obj.camera[0][1]; i < 1048576; i += 786432 )
            {
                AppMain.ObjDrawActionSummary( obj_work );
                obj_work.pos.y = obj_work.pos.y + 786432;
            }
        }
        else
        {
            for ( int i = 0; i < gms_GMK_PWALL_WORK.wall_height; i += 786432 )
            {
                AppMain.ObjDrawActionSummary( obj_work );
                obj_work.pos.y = obj_work.pos.y + 786432;
            }
        }
        obj_work.pos.y = AppMain.g_obj.camera[0][1];
    }

    // Token: 0x06001B1E RID: 6942 RVA: 0x000F7274 File Offset: 0x000F5474
    private static void gmGmkPressWallStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.g_obj.camera[0][0] >= obj_work.pos.x || ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 2 && obj_work.user_flag != 0U ) )
        {
            AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.diff_data = AppMain.g_gm_default_col;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.width = 192;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = -192;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.height = 256;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = 0;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 134217824U;
            AppMain.OBS_COLLISION_OBJ obj_col = gms_GMK_PWALL_WORK.gmk_work.ene_com.col_work.obj_col;
            obj_col.attr &= 65534;
            obj_work.disp_flag &= 4294967263U;
            if ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 2 && gms_GMK_PWALL_WORK.wall_height > 0 )
            {
                AppMain.gmGmkPressWallCreateRail( obj_work, gms_GMK_PWALL_WORK.wall_height, gms_GMK_PWALL_WORK.master_posy );
            }
            if ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 3 )
            {
                AppMain.gmGmkPressWallCreateParts( obj_work, gms_GMK_PWALL_WORK.master_posy, gms_GMK_PWALL_WORK.wall_height );
                gms_GMK_PWALL_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294967291U;
                gms_GMK_PWALL_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
                gms_GMK_PWALL_WORK.gmk_work.ene_com.rect_work[1].flag |= 4U;
                AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_PWALL_WORK.gmk_work.ene_com.rect_work[1];
                AppMain.ObjRectWorkZSet( obs_RECT_WORK, -16, 0, -32, 0, 192, 32 );
                obs_RECT_WORK.flag |= 4U;
                obs_RECT_WORK.flag |= 1024U;
                obj_work.flag &= 4294967293U;
                obs_RECT_WORK.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkPressWallZ4Hit );
            }
            if ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 2 && obj_work.user_flag != 0U )
            {
                obj_work.user_flag_OBJECT = null;
            }
            else
            {
                AppMain.GMM_PAD_VIB_MID_TIME( 60f );
                gms_GMK_PWALL_WORK.se_handle = AppMain.GsSoundAllocSeHandle();
                AppMain.GmSoundPlaySEForce( "MovingWall", gms_GMK_PWALL_WORK.se_handle );
            }
            gms_GMK_PWALL_WORK.efct_obj = null;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForce );
            AppMain.gmGmkPressWallForce( obj_work );
        }
    }

    // Token: 0x06001B1F RID: 6943 RVA: 0x000F7558 File Offset: 0x000F5758
    private static void gmGmkPressWallForce( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            gms_GMK_PWALL_WORK.ply_death = true;
            gms_GMK_PWALL_WORK.wall_speed = 0;
            AppMain.gmGmkPressWallSeStop( obj_work );
        }
        if ( AppMain.g_gm_gamedat_zone_type_tbl[( int )AppMain.g_gs_main_sys_info.stage_id] == 2 )
        {
            if ( gms_GMK_PWALL_WORK.wall_speed == 0 || gms_GMK_PWALL_WORK.ply_death )
            {
                AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK2 = gms_GMK_PWALL_WORK;
                gms_GMK_PWALL_WORK2.wall_vibration &= 3;
                AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK3 = gms_GMK_PWALL_WORK;
                gms_GMK_PWALL_WORK3.wall_vibration += 3;
                gms_GMK_PWALL_WORK.wall_brake = gms_GMK_PWALL_WORK.wall_speed;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForce_100 );
                AppMain.gmGmkPressWallForce_100( obj_work );
                return;
            }
            obj_work.pos.x = obj_work.pos.x + gms_GMK_PWALL_WORK.wall_speed;
            obj_work.user_timer = AppMain.wall_vib[( int )( gms_GMK_PWALL_WORK.wall_vibration & 7 )];
            AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK4 = gms_GMK_PWALL_WORK;
            gms_GMK_PWALL_WORK4.wall_vibration += 1;
            if ( gms_GMK_PWALL_WORK.wall_effect_build_timer == 0 )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctZoneEsCreate(null, 2, 32);
                obs_OBJECT_WORK.pos.x = obj_work.pos.x;
                obs_OBJECT_WORK.pos.y = AppMain.g_obj.camera[0][1];
                obs_OBJECT_WORK.pos.z = obj_work.pos.z;
                obs_OBJECT_WORK.spd.x = gms_GMK_PWALL_WORK.wall_speed;
                gms_GMK_PWALL_WORK.wall_effect_build_timer = ( short )( ( AppMain.mtMathRand() & 63 ) + 90 );
            }
            AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK5 = gms_GMK_PWALL_WORK;
            gms_GMK_PWALL_WORK5.wall_effect_build_timer -= 1;
            obj_work.pos.y = AppMain.g_obj.camera[0][1];
        }
        else
        {
            obj_work.pos.x = obj_work.pos.x + gms_GMK_PWALL_WORK.wall_speed;
            if ( gms_GMK_PWALL_WORK.ply_death || gms_GMK_PWALL_WORK.wall_speed == 0 )
            {
                if ( gms_GMK_PWALL_WORK.efct_obj != null )
                {
                    AppMain.ObjDrawKillAction3DES( gms_GMK_PWALL_WORK.efct_obj );
                    gms_GMK_PWALL_WORK.efct_obj = null;
                    gms_GMK_PWALL_WORK.wall_effect_build_timer = 0;
                }
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForceZ4_Stop );
            }
            else if ( ( obj_work.user_flag & 1U ) != 0U || gms_GMK_PWALL_WORK.ply_death )
            {
                gms_GMK_PWALL_WORK.wall_brake = gms_GMK_PWALL_WORK.wall_speed;
                obj_work.user_flag &= 4294967294U;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForceZ4_Hit );
                if ( gms_GMK_PWALL_WORK.efct_obj != null )
                {
                    AppMain.ObjDrawKillAction3DES( gms_GMK_PWALL_WORK.efct_obj );
                    gms_GMK_PWALL_WORK.efct_obj = null;
                    gms_GMK_PWALL_WORK.wall_effect_build_timer = 0;
                }
            }
            else
            {
                AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK6 = gms_GMK_PWALL_WORK;
                gms_GMK_PWALL_WORK6.wall_effect_build_timer -= 1;
            }
        }
        if ( gms_GMK_PWALL_WORK != AppMain.pwall )
        {
            obj_work.flag |= 8U;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.enemy_flag |= 65536U;
            AppMain.gmGmkPressWallSeStop( obj_work );
        }
    }

    // Token: 0x06001B20 RID: 6944 RVA: 0x000F77F4 File Offset: 0x000F59F4
    private static void gmGmkPressWallForce_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        gms_GMK_PWALL_WORK.wall_brake -= gms_GMK_PWALL_WORK.wall_speed / 20;
        obj_work.pos.x = obj_work.pos.x + gms_GMK_PWALL_WORK.wall_brake;
        if ( gms_GMK_PWALL_WORK.wall_vibration < 20 )
        {
            obj_work.user_timer = AppMain.wall_vib[( int )gms_GMK_PWALL_WORK.wall_vibration];
            AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK2 = gms_GMK_PWALL_WORK;
            gms_GMK_PWALL_WORK2.wall_vibration += 1;
            return;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForce_200 );
        AppMain.gmGmkPressWallSeStop( obj_work );
    }

    // Token: 0x06001B21 RID: 6945 RVA: 0x000F787C File Offset: 0x000F5A7C
    private static void gmGmkPressWallForce_200( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        if ( gms_GMK_PWALL_WORK != AppMain.pwall )
        {
            obj_work.flag |= 8U;
            gms_GMK_PWALL_WORK.gmk_work.ene_com.enemy_flag |= 65536U;
        }
    }

    // Token: 0x06001B22 RID: 6946 RVA: 0x000F78C4 File Offset: 0x000F5AC4
    private static void gmGmkPressWallForceZ4_Hit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            gms_GMK_PWALL_WORK.ply_death = true;
            gms_GMK_PWALL_WORK.wall_speed = 0;
            AppMain.gmGmkPressWallSeStop( obj_work );
        }
        gms_GMK_PWALL_WORK.wall_brake -= gms_GMK_PWALL_WORK.wall_speed / 64;
        if ( gms_GMK_PWALL_WORK.wall_brake <= 0 || gms_GMK_PWALL_WORK.wall_speed == 0 )
        {
            gms_GMK_PWALL_WORK.wall_brake = 0;
            if ( !gms_GMK_PWALL_WORK.ply_death && gms_GMK_PWALL_WORK.wall_speed != 0 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForceZ4_Hit_100 );
            }
            else
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForceZ4_Stop );
            }
        }
        if ( gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] > 0f )
        {
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] -= 0.015625f;
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[1] -= 0.015625f;
            gms_GMK_PWALL_WORK.mat_timer += 1U;
            if ( gms_GMK_PWALL_WORK.mat_timer > gms_GMK_PWALL_WORK.mat_timer_line )
            {
                obj_work.disp_flag &= 4294963199U;
                gms_GMK_PWALL_WORK.mat_timer_line = gms_GMK_PWALL_WORK.mat_timer;
                gms_GMK_PWALL_WORK.mat_timer = 0U;
            }
            else
            {
                obj_work.disp_flag |= 4096U;
            }
        }
        obj_work.pos.x = obj_work.pos.x + gms_GMK_PWALL_WORK.wall_brake;
    }

    // Token: 0x06001B23 RID: 6947 RVA: 0x000F7A44 File Offset: 0x000F5C44
    private static void gmGmkPressWallForceZ4_Hit_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            gms_GMK_PWALL_WORK.ply_death = true;
            gms_GMK_PWALL_WORK.wall_speed = 0;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForceZ4_Stop );
            return;
        }
        gms_GMK_PWALL_WORK.wall_brake += gms_GMK_PWALL_WORK.wall_speed / 64;
        if ( gms_GMK_PWALL_WORK.wall_brake >= gms_GMK_PWALL_WORK.wall_speed )
        {
            gms_GMK_PWALL_WORK.wall_brake = gms_GMK_PWALL_WORK.wall_speed;
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] = 1f;
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[1] = 1f;
            gms_GMK_PWALL_WORK.mat_timer = 0U;
            gms_GMK_PWALL_WORK.mat_timer_line = 0U;
            obj_work.disp_flag &= 4294963199U;
            obj_work.flag &= 4294967293U;
            gms_GMK_PWALL_WORK.ply_death = false;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallForce );
        }
        if ( gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] < 1f )
        {
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] += 0.015625f;
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[1] += 0.015625f;
            gms_GMK_PWALL_WORK.mat_timer += 1U;
            if ( gms_GMK_PWALL_WORK.mat_timer > gms_GMK_PWALL_WORK.mat_timer_line )
            {
                obj_work.disp_flag |= 4096U;
                gms_GMK_PWALL_WORK.mat_timer_line = gms_GMK_PWALL_WORK.mat_timer;
                gms_GMK_PWALL_WORK.mat_timer = 0U;
            }
            else
            {
                obj_work.disp_flag &= 4294963199U;
            }
        }
        obj_work.pos.x = obj_work.pos.x + gms_GMK_PWALL_WORK.wall_brake;
    }

    // Token: 0x06001B24 RID: 6948 RVA: 0x000F7C18 File Offset: 0x000F5E18
    private static void gmGmkPressWallForceZ4_Stop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        if ( gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] > 0f )
        {
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] -= 0.015625f;
            gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[1] -= 0.015625f;
            gms_GMK_PWALL_WORK.mat_timer += 1U;
            if ( gms_GMK_PWALL_WORK.mat_timer > gms_GMK_PWALL_WORK.mat_timer_line )
            {
                obj_work.disp_flag &= 4294963199U;
                gms_GMK_PWALL_WORK.mat_timer_line = gms_GMK_PWALL_WORK.mat_timer;
                gms_GMK_PWALL_WORK.mat_timer = 0U;
            }
            else
            {
                obj_work.disp_flag |= 4096U;
            }
            if ( gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] <= 0f )
            {
                gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[0] = 0f;
                gms_GMK_PWALL_WORK.gmk_work.obj_3d.speed[1] = 0f;
                obj_work.disp_flag |= 4096U;
                AppMain.gmGmkPressWallSeStop( obj_work );
            }
        }
    }

    // Token: 0x06001B25 RID: 6949 RVA: 0x000F7D4C File Offset: 0x000F5F4C
    private static void gmGmkPressWallZ4Hit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        parent_obj.flag |= 2U;
        parent_obj.user_flag |= 1U;
        AppMain.GmEnemyDefaultAtkFunc( mine_rect, match_rect );
    }

    // Token: 0x06001B26 RID: 6950 RVA: 0x000F7D84 File Offset: 0x000F5F84
    private static void gmGmkPressWallSeStop( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        if ( gms_GMK_PWALL_WORK.se_handle != null )
        {
            AppMain.GsSoundStopSeHandle( gms_GMK_PWALL_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_PWALL_WORK.se_handle );
            gms_GMK_PWALL_WORK.se_handle = null;
        }
    }

    // Token: 0x06001B27 RID: 6951 RVA: 0x000F7DC0 File Offset: 0x000F5FC0
    private static void gmGmkPressWallStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work;
        AppMain.pwall = gms_GMK_PWALL_WORK;
        obj_work.flag |= 16U;
        gms_GMK_PWALL_WORK.wall_vibration = 0;
        gms_GMK_PWALL_WORK.wall_effect_build_timer = 0;
        gms_GMK_PWALL_WORK.master_posy = obj_work.pos.y;
        AppMain.pwall.stop_wall = false;
        obj_work.disp_flag |= 32U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallStay );
    }

    // Token: 0x06001B28 RID: 6952 RVA: 0x000F7E34 File Offset: 0x000F6034
    private static void gmGmkPressWallStopperMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.pwall == null )
        {
            obj_work.flag |= 8U;
            return;
        }
        if ( obj_work.user_flag != 0U && ( obj_work.pos.y < AppMain.g_obj.camera[0][1] - 524288 || obj_work.pos.y > AppMain.g_obj.camera[0][1] + 1572864 ) )
        {
            return;
        }
        if ( AppMain.pwall.gmk_work.ene_com.obj_work.pos.x > obj_work.pos.x )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            AppMain.pwall.gmk_work.ene_com.obj_work.pos.x = obj_work.pos.x;
            AppMain.pwall.wall_speed = 0;
            obj_work.flag |= 8U;
            gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
        }
        if ( obj_work.user_work_OBJECT != AppMain.pwall )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK2 = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            obj_work.flag |= 8U;
            gms_ENEMY_COM_WORK2.enemy_flag |= 65536U;
        }
    }

    // Token: 0x06001B29 RID: 6953 RVA: 0x000F7F5C File Offset: 0x000F615C
    private static void gmGmkPressWallStopperStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_work_OBJECT = AppMain.pwall;
        obj_work.disp_flag |= 32U;
        obj_work.move_flag |= 8960U;
        obj_work.flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallStopperMain );
    }

    // Token: 0x06001B2A RID: 6954 RVA: 0x000F7FB8 File Offset: 0x000F61B8
    private static void gmGmkPressWallControler( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALLCTRL_WORK gms_GMK_PWALLCTRL_WORK = (AppMain.GMS_GMK_PWALLCTRL_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK ply_work = gms_GMK_PWALLCTRL_WORK.ply_work;
        if ( AppMain.pwall != null && ( obj_work.user_flag & 1U ) != 0U && obj_work.pos.x > gms_GMK_PWALLCTRL_WORK.last_ply_x && obj_work.pos.x <= ply_work.obj_work.pos.x && ( ( obj_work.user_flag & 2U ) == 0U || ( ply_work.obj_work.pos.y >= gms_GMK_PWALLCTRL_WORK.line_top && ply_work.obj_work.pos.y <= gms_GMK_PWALLCTRL_WORK.line_bottom ) ) )
        {
            if ( ( obj_work.user_flag & 4U ) != 0U && AppMain.pwall.gmk_work.ene_com.obj_work.pos.x <= AppMain.g_obj.camera[0][0] - 32768 )
            {
                AppMain.pwall.gmk_work.ene_com.obj_work.pos.x = AppMain.g_obj.camera[0][0] - 32768;
            }
            AppMain.pwall.wall_speed = obj_work.user_timer;
            if ( AppMain.pwall.wall_speed == 0 )
            {
                AppMain.pwall.stop_wall = true;
            }
            obj_work.flag |= 8U;
            gms_GMK_PWALLCTRL_WORK.gmk_work.ene_com.enemy_flag |= 65536U;
            return;
        }
        gms_GMK_PWALLCTRL_WORK.last_ply_x = ply_work.obj_work.pos.x;
        gms_GMK_PWALLCTRL_WORK.last_ply_y = ply_work.obj_work.pos.y;
    }

    // Token: 0x06001B2B RID: 6955 RVA: 0x000F8150 File Offset: 0x000F6350
    private static void gmGmkPressWallControlerStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PWALLCTRL_WORK gms_GMK_PWALLCTRL_WORK = (AppMain.GMS_GMK_PWALLCTRL_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        gms_GMK_PWALLCTRL_WORK.ply_work = gms_PLAYER_WORK;
        gms_GMK_PWALLCTRL_WORK.last_ply_x = gms_PLAYER_WORK.obj_work.pos.x;
        gms_GMK_PWALLCTRL_WORK.last_ply_y = gms_PLAYER_WORK.obj_work.pos.y;
        obj_work.disp_flag |= 32U;
        obj_work.move_flag |= 8960U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallControler );
    }

    // Token: 0x06001B2C RID: 6956 RVA: 0x000F81D8 File Offset: 0x000F63D8
    private static void gmGmkPressWallParts( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = obj_work.parent_obj.pos.x;
    }

    // Token: 0x06001B2D RID: 6957 RVA: 0x000F81F8 File Offset: 0x000F63F8
    private static void gmGmkPressWallRail( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PRESSWALL_PARTS gms_GMK_PRESSWALL_PARTS = (AppMain.GMS_GMK_PRESSWALL_PARTS)obj_work;
        AppMain.GMS_GMK_PWALL_WORK gms_GMK_PWALL_WORK = (AppMain.GMS_GMK_PWALL_WORK)obj_work.parent_obj;
        obj_work.pos.x = obj_work.parent_obj.pos.x;
        obj_work.pos.y = gms_GMK_PWALL_WORK.master_posy;
        obj_work.pos.y = obj_work.pos.y + obj_work.parent_obj.user_timer;
        obj_work.pos.y = obj_work.pos.y + gms_GMK_PRESSWALL_PARTS.ofst_y;
    }

    // Token: 0x06001B2E RID: 6958 RVA: 0x000F8288 File Offset: 0x000F6488
    private static void gmGmkPressWallCreateRail( AppMain.OBS_OBJECT_WORK parent_obj, int height, int pos_y )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_PRESSWALL_PARTS(), parent_obj, 0, "PresswallRail-Top");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_presswall_obj_3d_list[2], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.pos.y = pos_y;
        obs_OBJECT_WORK.pos.z = parent_obj.pos.z + 4096;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.disp_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        ( ( AppMain.GMS_GMK_PRESSWALL_PARTS )obs_OBJECT_WORK ).ofst_y = -8192;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallRail );
        obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_GMK_PRESSWALL_PARTS(), parent_obj, 0, "PresswallRail-Botom" );
        gms_EFFECT_3DNN_WORK = ( AppMain.GMS_EFFECT_3DNN_WORK )obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_presswall_obj_3d_list[1], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.pos.y = pos_y + height;
        obs_OBJECT_WORK.pos.z = parent_obj.pos.z + 4096;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.disp_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        ( ( AppMain.GMS_GMK_PRESSWALL_PARTS )obs_OBJECT_WORK ).ofst_y = height - 65536;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallRail );
    }

    // Token: 0x06001B2F RID: 6959 RVA: 0x000F8448 File Offset: 0x000F6648
    private static void gmGmkPressWallZ4Parts_ppOut( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PRESSWALL_PARTS gms_GMK_PRESSWALL_PARTS = (AppMain.GMS_GMK_PRESSWALL_PARTS)obj_work;
        obj_work.pos.y = gms_GMK_PRESSWALL_PARTS.master_posy;
        while ( obj_work.pos.y + 786432 < AppMain.g_obj.camera[0][1] )
        {
            obj_work.pos.y = obj_work.pos.y + 786432;
        }
        while ( obj_work.pos.y > AppMain.g_obj.camera[0][1] )
        {
            obj_work.pos.y = obj_work.pos.y - 786432;
        }
        for ( int i = obj_work.pos.y - AppMain.g_obj.camera[0][1]; i < 1048576; i += 786432 )
        {
            AppMain.ObjDrawActionSummary( obj_work );
            obj_work.pos.y = obj_work.pos.y + 786432;
        }
    }

    // Token: 0x06001B30 RID: 6960 RVA: 0x000F852C File Offset: 0x000F672C
    private static void gmGmkPressWallCreateParts( AppMain.OBS_OBJECT_WORK parent_obj, int pos_y, int height )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = null;
        for ( int i = 0; i < 3; i++ )
        {
            obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_GMK_PRESSWALL_PARTS(), parent_obj, 0, "PresswallZ4Parts" );
            AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_presswall_obj_3d_list[( int )( ( UIntPtr )AppMain.tbl_gmk_z4PressWall_model[i] )], gms_EFFECT_3DNN_WORK.obj_3d );
            obs_OBJECT_WORK.flag &= 4294966271U;
            obs_OBJECT_WORK.pos.y = pos_y;
            obs_OBJECT_WORK.pos.z = parent_obj.pos.z + AppMain.tbl_gmk_z4PressWall_ofst_z[i];
            obs_OBJECT_WORK.disp_flag |= 4194304U;
            obs_OBJECT_WORK.disp_flag |= 256U;
            obs_OBJECT_WORK.disp_flag |= 134217728U;
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallParts );
            AppMain.GMS_GMK_PRESSWALL_PARTS gms_GMK_PRESSWALL_PARTS = (AppMain.GMS_GMK_PRESSWALL_PARTS)obs_OBJECT_WORK;
            gms_GMK_PRESSWALL_PARTS.master_posy = pos_y;
            if ( height == 0 )
            {
                obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPressWallZ4Parts_ppOut );
            }
        }
        AppMain.ObjAction3dNNMaterialMotionLoad( obs_OBJECT_WORK.obj_3d, 0, null, null, 0, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 895 ).pData );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.obj_3d.mat_speed = 1f;
        obs_OBJECT_WORK.disp_flag |= 4U;
    }

    // Token: 0x06001B31 RID: 6961 RVA: 0x000F8688 File Offset: 0x000F6888
    private static void gmGmkPressWallExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        if ( AppMain.pwall == ( AppMain.GMS_GMK_PWALL_WORK )obs_OBJECT_WORK )
        {
            AppMain.pwall = null;
        }
        AppMain.gmGmkPressWallSeStop( obs_OBJECT_WORK );
        AppMain.GmEnemyDefaultExit( tcb );
    }
}
