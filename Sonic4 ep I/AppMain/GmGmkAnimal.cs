using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0200039C RID: 924
    public class GMS_GMK_ANIMAL_PARAM
    {
        // Token: 0x060026EA RID: 9962 RVA: 0x00150CE8 File Offset: 0x0014EEE8
        public GMS_GMK_ANIMAL_PARAM( int spd_x, int jump, int gravity )
        {
            this.spd_x = spd_x;
            this.jump = jump;
            this.gravity = gravity;
        }

        // Token: 0x04006134 RID: 24884
        public int spd_x;

        // Token: 0x04006135 RID: 24885
        public int jump;

        // Token: 0x04006136 RID: 24886
        public int gravity;
    }

    // Token: 0x060018AF RID: 6319 RVA: 0x000E13F4 File Offset: 0x000DF5F4
    private static AppMain.OBS_OBJECT_WORK GmGmkEndingAnimalInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_END_ANIMAL");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        uint user_work = (uint)(eve_rec.flag & 7);
        obs_OBJECT_WORK.user_work = user_work;
        AppMain.gmGmkAnimalObjSet( obs_OBJECT_WORK, gms_ENEMY_3D_WORK.obj_3d );
        if ( ( eve_rec.flag & 16 ) != 0 )
        {
            obs_OBJECT_WORK.user_flag = 2U;
        }
        else
        {
            obs_OBJECT_WORK.user_flag = 0U;
        }
        obs_OBJECT_WORK.disp_flag |= 4259840U;
        obs_OBJECT_WORK.move_flag &= 4294952703U;
        obs_OBJECT_WORK.move_flag |= 1680U;
        obs_OBJECT_WORK.spd.y = -AppMain.g_gm_gmk_animal_speed_param[( int )obs_OBJECT_WORK.user_work].jump;
        obs_OBJECT_WORK.spd_fall = AppMain.g_gm_gmk_animal_speed_param[( int )obs_OBJECT_WORK.user_work].gravity;
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.flag |= 512U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.flag &= 4294967279U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkEndingAnimalMove );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060018B0 RID: 6320 RVA: 0x000E1526 File Offset: 0x000DF726
    public static void GmGmkAnimalBuild()
    {
        AppMain.gm_gmk_animal_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 870 ), AppMain.GmGameDatGetGimmickData( 871 ), 0U );
    }

    // Token: 0x060018B1 RID: 6321 RVA: 0x000E1548 File Offset: 0x000DF748
    public static void GmGmkAnimalFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(870));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_animal_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060018B2 RID: 6322 RVA: 0x000E157C File Offset: 0x000DF77C
    public static AppMain.OBS_OBJECT_WORK GmGmkAnimalInit( AppMain.OBS_OBJECT_WORK parent_work, int ofs_x, int ofs_y, int ofs_z, byte type, byte vec, ushort timer )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), parent_work, 0, "GMK_ANIMAL");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst = 64;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + ofs_x;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
        obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + ofs_y;
        obs_OBJECT_WORK.pos.z = -131072 + ofs_z;
        if ( type != 0 )
        {
            type = ( byte )( type - 1 & 1 );
        }
        else
        {
            type = ( byte )( AppMain.mtMathRand() & 1 );
        }
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        obs_OBJECT_WORK.user_work = AppMain.g_gm_gmk_animal_type_id[num][( int )type];
        obs_OBJECT_WORK.user_flag = ( uint )vec;
        obs_OBJECT_WORK.user_timer = ( int )timer;
        AppMain.gmGmkAnimalObjSet( obs_OBJECT_WORK, gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.move_flag |= 16128U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.flag |= 512U;
        obs_OBJECT_WORK.flag |= 2U;
        obs_OBJECT_WORK.flag &= 4294967279U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkAnimalWait );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060018B3 RID: 6323 RVA: 0x000E16B6 File Offset: 0x000DF8B6
    private static void gmGmkAnimalObjSet( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_NN_WORK dest_obj_3d )
    {
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][0] )], dest_obj_3d );
        AppMain.ObjObjectFieldRectSet( obj_work, -2, -8, 2, 0 );
        obj_work.disp_flag |= 4259840U;
    }

    // Token: 0x060018B4 RID: 6324 RVA: 0x000E16F4 File Offset: 0x000DF8F4
    private static void gmGmkAnimalWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            return;
        }
        AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][1] )], obj_work.obj_3d );
        obj_work.move_flag &= 4294952703U;
        obj_work.move_flag |= 1680U;
        obj_work.spd.y = AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].jump;
        obj_work.spd_fall = AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].gravity;
        obj_work.pos.z = 131072;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkAnimalJump );
    }

    // Token: 0x060018B5 RID: 6325 RVA: 0x000E17B8 File Offset: 0x000DF9B8
    private static void gmGmkAnimalJump( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            if ( obj_work.user_flag != 0U )
            {
                obj_work.spd.x = AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].spd_x;
                AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
                AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][2] )], obj_work.obj_3d );
                obj_work.dir.y = 45056;
            }
            else
            {
                obj_work.spd.x = -AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].spd_x;
                AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
                AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][3] )], obj_work.obj_3d );
                obj_work.dir.y = 45056;
            }
            obj_work.spd.y = AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].jump;
            obj_work.move_flag |= 16U;
            obj_work.disp_flag &= 4290772735U;
        }
    }

    // Token: 0x060018B6 RID: 6326 RVA: 0x000E18C0 File Offset: 0x000DFAC0
    private static void gmGmkEndingAnimalMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            if ( ( ( ( AppMain.GMS_ENEMY_COM_WORK )obj_work ).eve_rec.flag & 24 ) == 0 || AppMain.GmEndingAnimalForwardChk() )
            {
                obj_work.spd.x = 0;
                AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
                AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][1] )], obj_work.obj_3d );
                obj_work.dir.y = 45056;
            }
            else
            {
                obj_work.user_flag = ( obj_work.user_flag + 1U & 3U );
                if ( ( obj_work.user_flag & 2U ) != 0U )
                {
                    obj_work.spd.x = AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].spd_x;
                    AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
                    AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][2] )], obj_work.obj_3d );
                    obj_work.dir.y = 45056;
                }
                else
                {
                    obj_work.spd.x = -AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].spd_x;
                    AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
                    AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_animal_obj_3d_list[( int )( ( UIntPtr )AppMain.g_gm_gmk_animal_obj_id[( int )obj_work.user_work][3] )], obj_work.obj_3d );
                    obj_work.dir.y = 45056;
                }
            }
            obj_work.spd.y = AppMain.g_gm_gmk_animal_speed_param[( int )obj_work.user_work].jump;
            obj_work.move_flag |= 16U;
            obj_work.disp_flag &= 4290772735U;
        }
    }
}