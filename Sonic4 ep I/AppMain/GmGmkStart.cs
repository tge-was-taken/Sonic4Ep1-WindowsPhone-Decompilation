using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000DC8 RID: 3528 RVA: 0x00079848 File Offset: 0x00077A48
    private static AppMain.OBS_OBJECT_WORK GmGmkStartInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 4U ) == 0U )
        {
            AppMain.g_gm_main_system.resume_pos_x = pos_x;
            AppMain.g_gm_main_system.resume_pos_y = pos_y - 4096;
        }
        eve_rec.pos_x = byte.MaxValue;
        AppMain.GmCameraPosSet( AppMain.g_gm_main_system.resume_pos_x, AppMain.g_gm_main_system.resume_pos_y, 0 );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        AppMain.ObjObjectCameraSet( AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obs_CAMERA.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( obs_CAMERA.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obs_CAMERA.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ) );
        AppMain.GmCameraSetClipCamera( obs_CAMERA );
        return null;
    }
}
