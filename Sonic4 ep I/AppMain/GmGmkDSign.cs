using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600077C RID: 1916 RVA: 0x0004234C File Offset: 0x0004054C
    private static AppMain.OBS_OBJECT_WORK GmGmkDSignInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_DSIGN");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_dsign_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -917504;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        int num = (int)(eve_rec.id - 287);
        num = AppMain.MTM_MATH_CLIP( num, 0, 3 );
        obs_OBJECT_WORK.dir.z = ( ushort )( num * 16384 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600077D RID: 1917 RVA: 0x00042415 File Offset: 0x00040615
    public static void GmGmkDSignBuild()
    {
        AppMain.gm_gmk_dsign_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 954 ), AppMain.GmGameDatGetGimmickData( 955 ), 0U );
    }

    // Token: 0x0600077E RID: 1918 RVA: 0x00042438 File Offset: 0x00040638
    public static void GmGmkDSignFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(954);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_dsign_obj_3d_list, ams_AMB_HEADER.file_num );
    }
}