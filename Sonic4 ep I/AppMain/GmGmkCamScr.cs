using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000181 RID: 385
    // (Invoke) Token: 0x0600219B RID: 8603
    public delegate void GMS_GMK_CAM_SCR_LIMIT_SETTING_func( AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK p );

    // Token: 0x02000182 RID: 386
    public class GMS_GMK_CAM_SCR_LIMIT_SETTING
    {
        // Token: 0x04004EBC RID: 20156
        public uint flag;

        // Token: 0x04004EBD RID: 20157
        public int[] limit_rect = new int[4];

        // Token: 0x04004EBE RID: 20158
        public AppMain.GMS_GMK_CAM_SCR_LIMIT_SETTING_func func;
    }

    // Token: 0x02000183 RID: 387
    public class GMS_GMK_CAM_SCR_LIMIT_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600219F RID: 8607 RVA: 0x001415FE File Offset: 0x0013F7FE
        public GMS_GMK_CAM_SCR_LIMIT_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_COM_WORK( this );
        }

        // Token: 0x060021A0 RID: 8608 RVA: 0x0014161D File Offset: 0x0013F81D
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK work )
        {
            return work.gmk_work;
        }

        // Token: 0x060021A1 RID: 8609 RVA: 0x00141625 File Offset: 0x0013F825
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.obj_work;
        }

        // Token: 0x04004EBF RID: 20159
        public readonly AppMain.GMS_ENEMY_COM_WORK gmk_work;

        // Token: 0x04004EC0 RID: 20160
        public readonly AppMain.GMS_GMK_CAM_SCR_LIMIT_SETTING limit_setting = new AppMain.GMS_GMK_CAM_SCR_LIMIT_SETTING();
    }

    // Token: 0x06000698 RID: 1688 RVA: 0x0003B50C File Offset: 0x0003970C
    private static AppMain.OBS_OBJECT_WORK GmGmkCamScrLimitInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK(), "GMK_CAM_SCRLMT");
        AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK gms_GMK_CAM_SCR_LIMIT_WORK = (AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
        obs_OBJECT_WORK.user_flag = ( uint )eve_rec.flag;
        obs_OBJECT_WORK.move_flag |= 8480U;
        obs_OBJECT_WORK.flag |= 16U;
        AppMain.GMS_GMK_CAM_SCR_LIMIT_SETTING limit_setting = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting;
        limit_setting.limit_rect[0] = ( obs_OBJECT_WORK.pos.x >> 12 ) + ( int )( eve_rec.left * 2 );
        limit_setting.limit_rect[2] = ( obs_OBJECT_WORK.pos.x >> 12 ) + ( int )( eve_rec.left * 2 ) + ( int )( eve_rec.width * 2 );
        limit_setting.limit_rect[1] = ( obs_OBJECT_WORK.pos.y >> 12 ) + ( int )( eve_rec.top * 2 );
        limit_setting.limit_rect[3] = ( obs_OBJECT_WORK.pos.y >> 12 ) + ( int )( eve_rec.top * 2 ) + ( int )( eve_rec.height * 2 );
        if ( eve_rec.id == 302 )
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCamScrLimitSetting );
            AppMain.g_gm_main_system.game_flag |= 32768U;
        }
        else
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCamScrLimitMain );
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000699 RID: 1689 RVA: 0x0003B670 File Offset: 0x00039870
    private static void gmGmkCamScrLimitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( obj_work.pos.x <= gms_PLAYER_WORK.obj_work.pos.x )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCamScrLimitSetting );
            AppMain.g_gm_main_system.game_flag |= 32768U;
        }
    }

    // Token: 0x0600069A RID: 1690 RVA: 0x0003B6D8 File Offset: 0x000398D8
    private static AppMain.OBS_OBJECT_WORK GmGmkCamScrLimitReleaseInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_SCRLMT_RELEASE");
        obs_OBJECT_WORK.user_flag = ( uint )eve_rec.flag;
        obs_OBJECT_WORK.user_timer = 0;
        obs_OBJECT_WORK.move_flag |= 8480U;
        obs_OBJECT_WORK.flag |= 16U;
        if ( eve_rec.id == 303 )
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCamScrLimitRelease );
            AppMain.g_gm_main_system.game_flag |= 32768U;
        }
        else
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCamScrLimitReleaseMain );
        }
        obs_OBJECT_WORK.user_work = 3U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600069B RID: 1691 RVA: 0x0003B79C File Offset: 0x0003999C
    private static void gmGmkCamScrLimitRelease( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        int num = AppMain.FXM_FLOAT_TO_FX32(obs_CAMERA.pos.x) >> 12;
        int num2 = -AppMain.FXM_FLOAT_TO_FX32(obs_CAMERA.pos.y) >> 12;
        int num3 = AppMain.FXM_FLOAT_TO_FX32(AppMain.AMD_SCREEN_2D_WIDTH / 2f * obs_CAMERA.scale) >> 12;
        int num4 = AppMain.FXM_FLOAT_TO_FX32(AppMain.AMD_SCREEN_2D_HEIGHT / 2f * obs_CAMERA.scale) >> 12;
        int user_work = (int)obj_work.user_work;
        int user_work2 = (int)obj_work.user_work;
        byte b = 1;
        if ( ( ( ushort )obj_work.user_flag & 1 ) != 0 && AppMain.g_gm_main_system.map_fcol.left != 0 )
        {
            if ( num - num3 > AppMain.g_gm_main_system.map_fcol.left )
            {
                AppMain.g_gm_main_system.map_fcol.left = 0;
            }
            else
            {
                AppMain.g_gm_main_system.map_fcol.left -= user_work;
                if ( AppMain.g_gm_main_system.map_fcol.left < 0 )
                {
                    AppMain.g_gm_main_system.map_fcol.left = 0;
                }
                b = 0;
            }
        }
        if ( ( ( ushort )obj_work.user_flag & 4 ) != 0 && AppMain.g_gm_main_system.map_fcol.right < ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 ) )
        {
            if ( num + num3 < AppMain.g_gm_main_system.map_fcol.right )
            {
                AppMain.g_gm_main_system.map_fcol.right = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 );
            }
            else
            {
                AppMain.g_gm_main_system.map_fcol.right += user_work;
                if ( AppMain.g_gm_main_system.map_fcol.right > ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 ) )
                {
                    AppMain.g_gm_main_system.map_fcol.right = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 );
                }
                b = 0;
            }
        }
        if ( ( ( ushort )obj_work.user_flag & 2 ) != 0 && AppMain.g_gm_main_system.map_fcol.top != 0 )
        {
            if ( num2 - num4 > AppMain.g_gm_main_system.map_fcol.top )
            {
                AppMain.g_gm_main_system.map_fcol.top = 0;
            }
            else
            {
                AppMain.g_gm_main_system.map_fcol.top -= user_work2;
                if ( AppMain.g_gm_main_system.map_fcol.top < 0 )
                {
                    AppMain.g_gm_main_system.map_fcol.top = 0;
                }
                b = 0;
            }
        }
        if ( ( ( ushort )obj_work.user_flag & 8 ) != 0 && AppMain.g_gm_main_system.map_fcol.bottom < ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_y * 64 ) )
        {
            if ( num2 + num4 < AppMain.g_gm_main_system.map_fcol.bottom )
            {
                AppMain.g_gm_main_system.map_fcol.bottom = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_y * 64 );
            }
            else
            {
                AppMain.g_gm_main_system.map_fcol.bottom += user_work2;
                if ( AppMain.g_gm_main_system.map_fcol.bottom > ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_y * 64 ) )
                {
                    AppMain.g_gm_main_system.map_fcol.bottom = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_y * 64 );
                }
                b = 0;
            }
        }
        if ( b != 0 && obj_work.user_timer != 0 )
        {
            obj_work.flag |= 8U;
            AppMain.g_gm_main_system.game_flag &= 4294934527U;
        }
        obj_work.user_timer++;
    }

    // Token: 0x0600069C RID: 1692 RVA: 0x0003BAF8 File Offset: 0x00039CF8
    private static void gmGmkCamScrLimitReleaseMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( obj_work.pos.x <= gms_PLAYER_WORK.obj_work.pos.x )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCamScrLimitRelease );
            AppMain.g_gm_main_system.game_flag |= 32768U;
        }
    }

    // Token: 0x0600069D RID: 1693 RVA: 0x0003BB58 File Offset: 0x00039D58
    private static void GmCamScrLimitSetDirect( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y )
    {
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            AppMain.g_gm_main_system.map_fcol.left = ( pos_x >> 12 ) + ( int )( eve_rec.left * 2 );
        }
        if ( ( eve_rec.flag & 4 ) != 0 )
        {
            AppMain.g_gm_main_system.map_fcol.right = ( pos_x >> 12 ) + ( int )( eve_rec.left * 2 ) + ( int )( eve_rec.width * 2 );
        }
        if ( ( eve_rec.flag & 2 ) != 0 )
        {
            AppMain.g_gm_main_system.map_fcol.top = ( pos_y >> 12 ) + ( int )( eve_rec.top * 2 );
        }
        if ( ( eve_rec.flag & 8 ) != 0 )
        {
            AppMain.g_gm_main_system.map_fcol.bottom = ( pos_y >> 12 ) + ( int )( eve_rec.top * 2 ) + ( int )( eve_rec.height * 2 );
        }
    }

    // Token: 0x0600069E RID: 1694 RVA: 0x0003BC10 File Offset: 0x00039E10
    private static void gmGmkCamScrLimitSetting( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK gms_GMK_CAM_SCR_LIMIT_WORK = (AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK)obj_work;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        int num = AppMain.FXM_FLOAT_TO_FX32(obs_CAMERA.pos.x) >> 12;
        int num2 = -AppMain.FXM_FLOAT_TO_FX32(obs_CAMERA.pos.y) >> 12;
        int num3 = 1;
        int num4 = 1;
        int num5 = AppMain.FXM_FLOAT_TO_FX32(AppMain.AMD_SCREEN_2D_WIDTH / 2f * obs_CAMERA.scale) >> 12;
        int num6 = AppMain.FXM_FLOAT_TO_FX32(AppMain.AMD_SCREEN_2D_HEIGHT / 2f * obs_CAMERA.scale) >> 12;
        byte b = 1;
        if ( ( Convert.ToInt32( obj_work.user_flag ) & 1 ) != 0 && AppMain.g_gm_main_system.map_fcol.left != gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[0] )
        {
            int num7 = num - num5;
            if ( num7 > gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[0] )
            {
                AppMain.g_gm_main_system.map_fcol.left = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[0];
            }
            else
            {
                if ( num7 > AppMain.g_gm_main_system.map_fcol.left )
                {
                    AppMain.g_gm_main_system.map_fcol.left = num7 + num3;
                }
                else
                {
                    AppMain.g_gm_main_system.map_fcol.left += num3;
                }
                if ( AppMain.g_gm_main_system.map_fcol.left > gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[0] )
                {
                    AppMain.g_gm_main_system.map_fcol.left = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[0];
                }
            }
            b = 0;
        }
        if ( ( Convert.ToInt32( obj_work.user_flag ) & 4 ) != 0 && AppMain.g_gm_main_system.map_fcol.right != gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[2] )
        {
            int num8 = num + num5;
            if ( num8 < gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[2] )
            {
                AppMain.g_gm_main_system.map_fcol.right = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[2];
            }
            else
            {
                if ( num8 < AppMain.g_gm_main_system.map_fcol.right )
                {
                    AppMain.g_gm_main_system.map_fcol.right = num8 - num3;
                }
                else
                {
                    AppMain.g_gm_main_system.map_fcol.right -= num3;
                }
                if ( AppMain.g_gm_main_system.map_fcol.right < gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[2] )
                {
                    AppMain.g_gm_main_system.map_fcol.right = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[2];
                }
            }
            b = 0;
        }
        if ( ( Convert.ToInt32( obj_work.user_flag ) & 2 ) != 0 && AppMain.g_gm_main_system.map_fcol.top != gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[1] )
        {
            int num9 = num2 - num6;
            if ( num9 > gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[1] )
            {
                AppMain.g_gm_main_system.map_fcol.top = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[1];
            }
            else
            {
                if ( num9 > AppMain.g_gm_main_system.map_fcol.top )
                {
                    AppMain.g_gm_main_system.map_fcol.top = num9 + num4;
                }
                else
                {
                    AppMain.g_gm_main_system.map_fcol.top += num4;
                }
                if ( AppMain.g_gm_main_system.map_fcol.top > gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[1] )
                {
                    AppMain.g_gm_main_system.map_fcol.top = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[1];
                }
            }
            b = 0;
        }
        if ( ( Convert.ToInt32( obj_work.user_flag ) & 8 ) != 0 && AppMain.g_gm_main_system.map_fcol.bottom != gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[3] )
        {
            int num10 = num2 + num6;
            if ( num10 < gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[3] )
            {
                AppMain.g_gm_main_system.map_fcol.bottom = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[3];
            }
            else
            {
                if ( num10 < AppMain.g_gm_main_system.map_fcol.bottom )
                {
                    AppMain.g_gm_main_system.map_fcol.bottom = num10 - num4;
                }
                else
                {
                    AppMain.g_gm_main_system.map_fcol.bottom -= num4;
                }
                if ( AppMain.g_gm_main_system.map_fcol.bottom < gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[3] )
                {
                    AppMain.g_gm_main_system.map_fcol.bottom = gms_GMK_CAM_SCR_LIMIT_WORK.limit_setting.limit_rect[3];
                }
            }
            b = 0;
        }
        if ( b != 0 )
        {
            obj_work.flag |= 8U;
            AppMain.g_gm_main_system.game_flag &= 4294934527U;
        }
    }

    // Token: 0x0600069F RID: 1695 RVA: 0x0003C060 File Offset: 0x0003A260
    private static AppMain.OBS_OBJECT_WORK GmGmkCamScrLimitRelease( byte flag )
    {
        return AppMain.GmEventMgrLocalEventBirth( 303, 0, 0, ( ushort )( flag & 15 ), 0, 0, 0, 0, 0 );
    }
}
