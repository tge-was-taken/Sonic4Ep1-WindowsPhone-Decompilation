using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0200019B RID: 411
    public class GMS_GMK_SW_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021EA RID: 8682 RVA: 0x00141F3E File Offset: 0x0014013E
        public GMS_GMK_SW_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060021EB RID: 8683 RVA: 0x00141F5D File Offset: 0x0014015D
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SW_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060021EC RID: 8684 RVA: 0x00141F6F File Offset: 0x0014016F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004F30 RID: 20272
        public AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004F31 RID: 20273
        public AppMain.OBS_ACTION3D_NN_WORK obj_3d_base = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004F32 RID: 20274
        public int top_pos_y;

        // Token: 0x04004F33 RID: 20275
        public uint id;

        // Token: 0x04004F34 RID: 20276
        public int time;
    }

    // Token: 0x0200019C RID: 412
    private class GMS_GMK_SW_STATE_WORK : AppMain.IClearable
    {
        // Token: 0x060021ED RID: 8685 RVA: 0x00141F84 File Offset: 0x00140184
        public void Clear()
        {
            this.sw = ( this.gear = false );
            this.time = ( this.per = 0 );
        }

        // Token: 0x04004F35 RID: 20277
        public bool sw;

        // Token: 0x04004F36 RID: 20278
        public int time;

        // Token: 0x04004F37 RID: 20279
        public bool gear;

        // Token: 0x04004F38 RID: 20280
        public int per;
    }

    // Token: 0x0600075B RID: 1883 RVA: 0x00041068 File Offset: 0x0003F268
    private static void GmGmkSwitchBuildTypeZone3()
    {
        AppMain.gm_gmk_switch_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 931 ), AppMain.GmGameDatGetGimmickData( 932 ), 0U );
        AppMain.ClearArray<AppMain.GMS_GMK_SW_STATE_WORK>( AppMain.gm_gmk_switch_state );
    }

    // Token: 0x0600075C RID: 1884 RVA: 0x00041093 File Offset: 0x0003F293
    private static void GmGmkSwitchBuildTypeZone4()
    {
        AppMain.gm_gmk_switch_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 931 ), AppMain.GmGameDatGetGimmickData( 932 ), 0U );
        AppMain.ClearArray<AppMain.GMS_GMK_SW_STATE_WORK>( AppMain.gm_gmk_switch_state );
    }

    // Token: 0x0600075D RID: 1885 RVA: 0x000410BE File Offset: 0x0003F2BE
    private static void GmGmkSwitchReBuild()
    {
        AppMain.ClearArray<AppMain.GMS_GMK_SW_STATE_WORK>( AppMain.gm_gmk_switch_state );
    }

    // Token: 0x0600075E RID: 1886 RVA: 0x000410CC File Offset: 0x0003F2CC
    private static void GmGmkSwitchFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(931);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_switch_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600075F RID: 1887 RVA: 0x000410FC File Offset: 0x0003F2FC
    private static AppMain.OBS_OBJECT_WORK GmGmkSwitchInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SW_WORK(), "GMK_SWITCH");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_GMK_SW_WORK gms_GMK_SW_WORK = (AppMain.GMS_GMK_SW_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_switch_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 2 )
        {
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, AppMain.ObjDataGet( 933 ), null, 0, null, 1, 1 );
            AppMain.ObjDrawAction3dActionSet3DNNMaterial( gms_ENEMY_3D_WORK.obj_3d, 0 );
            obs_OBJECT_WORK.disp_flag |= 4U;
        }
        AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_switch_obj_3d_list[0], gms_GMK_SW_WORK.obj_3d_base );
        obs_OBJECT_WORK.pos.z = -262144;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwDispFunc );
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.width = 32;
        col_work.obj_col.height = 24;
        col_work.obj_col.ofst_x = -16;
        col_work.obj_col.ofst_y = -14;
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            col_work.obj_col.obj = null;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
            obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSwitchDefFunc );
            obs_RECT_WORK.ppHit = null;
            AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
            AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -20, 16, -4 );
            obs_RECT_WORK.flag |= 132U;
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        gms_GMK_SW_WORK.id = ( uint )AppMain.MTM_MATH_CLIP( ( int )eve_rec.left, 0, 64 );
        gms_GMK_SW_WORK.time = ( int )( eve_rec.width * 60 ) * 4096 + ( int )eve_rec.top * 4096;
        if ( gms_GMK_SW_WORK.time != 0 && gms_GMK_SW_WORK.time < 12288 )
        {
            gms_GMK_SW_WORK.time = 12288;
        }
        if ( AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].sw )
        {
            gms_GMK_SW_WORK.top_pos_y = -10;
            AppMain.gmGmkSwOnInit( obs_OBJECT_WORK, false );
        }
        else
        {
            gms_GMK_SW_WORK.top_pos_y = -14;
            AppMain.gmGmkSwOffInit( obs_OBJECT_WORK );
        }
        AppMain.gmGmkSwSetCol( gms_GMK_SW_WORK.gmk_work.ene_com.col_work, gms_GMK_SW_WORK.top_pos_y );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000760 RID: 1888 RVA: 0x0004136F File Offset: 0x0003F56F
    private static bool GmGmkSwitchIsOn( uint sw_id )
    {
        return AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].sw;
    }

    // Token: 0x06000761 RID: 1889 RVA: 0x0004137E File Offset: 0x0003F57E
    private static bool GmGmkSwitchTypeIsGear( uint sw_id )
    {
        return AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].gear;
    }

    // Token: 0x06000762 RID: 1890 RVA: 0x0004138D File Offset: 0x0003F58D
    private static void GmGmkSwitchSetOnGearSwitch( uint sw_id, int per )
    {
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].sw = true;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].gear = true;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].per = per;
    }

    // Token: 0x06000763 RID: 1891 RVA: 0x000413B9 File Offset: 0x0003F5B9
    private static void GmGmkSwitchSetOffGearSwitch( uint sw_id, int per )
    {
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].sw = false;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].gear = true;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].per = per;
    }

    // Token: 0x06000764 RID: 1892 RVA: 0x000413E5 File Offset: 0x0003F5E5
    private static int GmGmkSwitchGetPer( uint sw_id )
    {
        return AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )sw_id )].per;
    }

    // Token: 0x06000765 RID: 1893 RVA: 0x000413F4 File Offset: 0x0003F5F4
    private static void gmGmkSwOffInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SW_WORK gms_GMK_SW_WORK = (AppMain.GMS_GMK_SW_WORK)obj_work;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].sw = false;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time = 0;
        obj_work.flag &= 4294967279U;
        if ( gms_GMK_SW_WORK.top_pos_y < -14 )
        {
            gms_GMK_SW_WORK.top_pos_y = -14;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwOffMain );
    }

    // Token: 0x06000766 RID: 1894 RVA: 0x00041464 File Offset: 0x0003F664
    private static void gmGmkSwOffMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SW_WORK gms_GMK_SW_WORK = (AppMain.GMS_GMK_SW_WORK)obj_work;
        if ( gms_GMK_SW_WORK.top_pos_y > -14 )
        {
            gms_GMK_SW_WORK.top_pos_y += -2;
            if ( gms_GMK_SW_WORK.top_pos_y < -14 )
            {
                gms_GMK_SW_WORK.top_pos_y = -14;
            }
            AppMain.gmGmkSwSetCol( gms_GMK_SW_WORK.gmk_work.ene_com.col_work, gms_GMK_SW_WORK.top_pos_y );
        }
        if ( ( gms_GMK_SW_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj != null && gms_GMK_SW_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj.obj_type == 1 ) || ( gms_GMK_SW_WORK.gmk_work.ene_com.enemy_flag & 1U ) != 0U )
        {
            AppMain.gmGmkSwOnInit( obj_work, true );
        }
        gms_GMK_SW_WORK.gmk_work.ene_com.enemy_flag &= 4294967294U;
    }

    // Token: 0x06000767 RID: 1895 RVA: 0x00041530 File Offset: 0x0003F730
    private static void gmGmkSwOnInit( AppMain.OBS_OBJECT_WORK obj_work, bool now_on )
    {
        AppMain.GMS_GMK_SW_WORK gms_GMK_SW_WORK = (AppMain.GMS_GMK_SW_WORK)obj_work;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].sw = true;
        AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time = gms_GMK_SW_WORK.time;
        if ( gms_GMK_SW_WORK.time != 0 )
        {
            obj_work.flag |= 16U;
        }
        if ( gms_GMK_SW_WORK.top_pos_y > -10 )
        {
            gms_GMK_SW_WORK.top_pos_y = -10;
        }
        if ( now_on )
        {
            AppMain.GmSoundPlaySE( "Switch" );
            AppMain.GMM_PAD_VIB_SMALL();
            AppMain.GmComEfctCreateSpring( obj_work, 0, -32768, -obj_work.pos.z );
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwOnMain );
    }

    // Token: 0x06000768 RID: 1896 RVA: 0x000415D4 File Offset: 0x0003F7D4
    private static void gmGmkSwOnMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SW_WORK gms_GMK_SW_WORK = (AppMain.GMS_GMK_SW_WORK)obj_work;
        if ( gms_GMK_SW_WORK.top_pos_y < -10 )
        {
            gms_GMK_SW_WORK.top_pos_y += 2;
            if ( gms_GMK_SW_WORK.top_pos_y > -10 )
            {
                gms_GMK_SW_WORK.top_pos_y = -10;
            }
            AppMain.gmGmkSwSetCol( gms_GMK_SW_WORK.gmk_work.ene_com.col_work, gms_GMK_SW_WORK.top_pos_y );
        }
        gms_GMK_SW_WORK.gmk_work.ene_com.enemy_flag &= 4294967294U;
        if ( ( gms_GMK_SW_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj != null && gms_GMK_SW_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj.obj_type == 1 ) || ( gms_GMK_SW_WORK.gmk_work.ene_com.enemy_flag & 1U ) != 0U )
        {
            AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time = gms_GMK_SW_WORK.time;
        }
        else if ( AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time != 0 )
        {
            AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time = AppMain.ObjTimeCountDown( AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time );
            if ( AppMain.gm_gmk_switch_state[( int )( ( UIntPtr )gms_GMK_SW_WORK.id )].time == 0 )
            {
                AppMain.gmGmkSwOffInit( obj_work );
            }
        }
        gms_GMK_SW_WORK.gmk_work.ene_com.enemy_flag &= 4294967294U;
    }

    // Token: 0x06000769 RID: 1897 RVA: 0x00041724 File Offset: 0x0003F924
    private static void gmGmkSwitchDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        gms_ENEMY_COM_WORK.enemy_flag |= 1U;
    }

    // Token: 0x0600076A RID: 1898 RVA: 0x00041770 File Offset: 0x0003F970
    private static void gmGmkSwDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SW_WORK gms_GMK_SW_WORK = (AppMain.GMS_GMK_SW_WORK)obj_work;
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        uint disp_flag = obj_work.disp_flag;
        vecFx.Assign( obj_work.pos );
        vecFx.y += gms_GMK_SW_WORK.top_pos_y << 12;
        AppMain.ObjDrawAction3DNN( obj_work.obj_3d, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref obj_work.disp_flag );
        AppMain.ObjDrawAction3DNN( gms_GMK_SW_WORK.obj_3d_base, new AppMain.VecFx32?( obj_work.pos ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref disp_flag );
    }

    // Token: 0x0600076B RID: 1899 RVA: 0x00041808 File Offset: 0x0003FA08
    private static void gmGmkSwSetCol( AppMain.OBS_COLLISION_WORK col_work, int top_pos_y )
    {
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            return;
        }
        col_work.obj_col.ofst_y = ( short )top_pos_y;
    }
}