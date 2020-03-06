using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600076C RID: 1900 RVA: 0x00041830 File Offset: 0x0003FA30
    private static AppMain.OBS_OBJECT_WORK GmGmkSsEnduranceInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_ENDURANCE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.view_out_ofst -= 128;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_endurance_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.user_flag = ( uint )( ( ~eve_rec.flag & 3 ) + 1 - ( ushort )eve_rec.byte_param[1] );
        obs_OBJECT_WORK.user_work = AppMain.gmGmkSsEnduranceColorSet( obs_OBJECT_WORK.user_flag );
        AppMain.gmGmkSsEnduranceScaleSet( obs_OBJECT_WORK );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsEnduranceWait );
        obs_OBJECT_WORK.user_timer = 0;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsEnduranceDrawFunc );
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        col_work.obj_col.width = 24;
        col_work.obj_col.height = 24;
        col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
        col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
        col_work.obj_col.attr = 2;
        col_work.obj_col.flag |= 134217760U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600076D RID: 1901 RVA: 0x000419E8 File Offset: 0x0003FBE8
    public static void GmGmkSsEnduranceBuild()
    {
        AppMain.gm_gmk_ss_endurance_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 903 ), AppMain.GmGameDatGetGimmickData( 904 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(906);
        AppMain.gm_gmk_ss_endurance_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x0600076E RID: 1902 RVA: 0x00041A28 File Offset: 0x0003FC28
    public static void GmGmkSsEnduranceFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(903);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_endurance_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_ss_endurance_obj_tvx_list = null;
    }

    // Token: 0x0600076F RID: 1903 RVA: 0x00041A58 File Offset: 0x0003FC58
    private static void gmGmkSsEnduranceWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_COLLISION_OBJ obj_col = obj_work.col_work.obj_col;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        if ( obj_col.toucher_obj == gms_PLAYER_WORK.obj_work )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsEnduranceDamage );
            obj_work.user_timer |= 30;
            AppMain.GmSoundPlaySE( "Special3" );
        }
        AppMain.gmGmkSsEnduranceUpdateUVTimer( obj_work );
        AppMain.GmGmkSsSquareBounce( obj_work );
    }

    // Token: 0x06000770 RID: 1904 RVA: 0x00041AE4 File Offset: 0x0003FCE4
    private static void gmGmkSsEnduranceDamage( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( AppMain.GmSplStageGetWork().flag & 4U ) != 0U )
        {
            obj_work.flag |= 4U;
            return;
        }
        uint num = (uint)(obj_work.user_timer & 255);
        num -= 1U;
        obj_work.user_timer = ( int )( ( ( long )obj_work.user_timer & unchecked(( long )( ( ulong )-256 )) ) | ( long )( ( ulong )( num & 255U ) ) );
        if ( num == 0U )
        {
            obj_work.user_flag -= 1U;
            byte[] byte_param = ((AppMain.GMS_ENEMY_3D_WORK)obj_work).ene_com.eve_rec.byte_param;
            int num2 = 1;
            byte_param[num2] += 1;
            if ( ( obj_work.user_flag & 2147483647U ) != 0U )
            {
                AppMain.gmGmkSsEnduranceScaleSet( obj_work );
                obj_work.user_work = AppMain.gmGmkSsEnduranceColorSet( obj_work.user_flag & 2147483647U );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsEnduranceWait );
            }
            else
            {
                obj_work.flag |= 4U;
                ( ( AppMain.GMS_ENEMY_3D_WORK )obj_work ).ene_com.enemy_flag |= 65536U;
                AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 5, 8);
                gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 512U;
            }
        }
        else
        {
            uint color_num = (uint)(((obj_work.user_timer & 12) >> 2) + 1);
            obj_work.user_work = AppMain.gmGmkSsEnduranceColorSet( color_num );
        }
        AppMain.gmGmkSsEnduranceUpdateUVTimer( obj_work );
        AppMain.GmGmkSsSquareBounce( obj_work );
    }

    // Token: 0x06000771 RID: 1905 RVA: 0x00041C30 File Offset: 0x0003FE30
    private static void gmGmkSsEnduranceDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.TVX_FILE tvx_FILE;
        if ( AppMain.gm_gmk_ss_endurance_obj_tvx_list.buf[0] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_ss_endurance_obj_tvx_list, 0 ) );
            AppMain.gm_gmk_ss_endurance_obj_tvx_list.buf[0] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.gm_gmk_ss_endurance_obj_tvx_list.buf[0];
        }
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        uint num = (uint)obj_work.user_timer >> 10 & 31U;
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.u = 0.125f * ( float )( AppMain.gm_gmk_ss_endurance_uv_parameter[( int )( ( UIntPtr )num )] % 4 ) + AppMain.gm_gmk_ss_endurance_mat_color[( int )( ( UIntPtr )obj_work.user_work )].u;
        gms_TVX_EX_WORK.coord.v = 0.125f * ( float )( AppMain.gm_gmk_ss_endurance_uv_parameter[( int )( ( UIntPtr )num )] / 4 ) + AppMain.gm_gmk_ss_endurance_mat_color[( int )( ( UIntPtr )obj_work.user_work )].v;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        AppMain.GmTvxSetModelEx( tvx_FILE, texlist, ref obj_work.pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_SCALE | AppMain.GMD_TVX_DISP_LIGHT_DISABLE, 0, ref gms_TVX_EX_WORK );
    }

    // Token: 0x06000772 RID: 1906 RVA: 0x00041D60 File Offset: 0x0003FF60
    private static void gmGmkSsEnduranceUpdateUVTimer( AppMain.OBS_OBJECT_WORK obj_work )
    {
        uint num = (uint)obj_work.user_timer >> 8 & 127U;
        num += 1U;
        if ( num >= 120U )
        {
            num = 0U;
        }
        obj_work.user_timer = ( int )( ( long )( obj_work.user_timer & 255 ) | ( long )( ( ulong )( ( ulong )num << 8 ) ) );
    }

    // Token: 0x06000773 RID: 1907 RVA: 0x00041D9D File Offset: 0x0003FF9D
    private static uint gmGmkSsEnduranceColorSet( uint color_num )
    {
        return ( uint )AppMain.gm_gmk_ss_endurance_color[( int )( ( UIntPtr )color_num )];
    }

    // Token: 0x06000774 RID: 1908 RVA: 0x00041DA8 File Offset: 0x0003FFA8
    private static void gmGmkSsEnduranceScaleSet( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int z = 4096;
        switch ( obj_work.user_flag & 2147483647U )
        {
            case 1U:
                z = 2867;
                break;
            case 2U:
                z = 3276;
                break;
            case 3U:
                z = 3686;
                break;
        }
        obj_work.scale.x = ( obj_work.scale.y = ( obj_work.scale.z = z ) );
    }
}