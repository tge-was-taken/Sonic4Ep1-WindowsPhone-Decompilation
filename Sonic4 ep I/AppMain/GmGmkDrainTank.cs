using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200029E RID: 670
    public class GMS_GMK_DRAIN_TANK_OUT_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600244C RID: 9292 RVA: 0x0014A875 File Offset: 0x00148A75
        public GMS_GMK_DRAIN_TANK_OUT_WORK()
        {
            this.enemy_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600244D RID: 9293 RVA: 0x0014A889 File Offset: 0x00148A89
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.enemy_work.ene_com.obj_work;
        }

        // Token: 0x04005AC2 RID: 23234
        public readonly AppMain.GMS_ENEMY_3D_WORK enemy_work;

        // Token: 0x04005AC3 RID: 23235
        public bool flag_dir_left;

        // Token: 0x04005AC4 RID: 23236
        public int base_pos_x;

        // Token: 0x04005AC5 RID: 23237
        public int base_pos_y;

        // Token: 0x04005AC6 RID: 23238
        public int player_offset_x;

        // Token: 0x04005AC7 RID: 23239
        public int player_offset_y;

        // Token: 0x04005AC8 RID: 23240
        public int camera_roll;

        // Token: 0x04005AC9 RID: 23241
        public int counter_roll_key;
    }


    // Token: 0x17000043 RID: 67
    // (get) Token: 0x0600121A RID: 4634 RVA: 0x0009E656 File Offset: 0x0009C856
    public static int GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH
    {
        get
        {
            return ( int )( AppMain.OBD_LCD_X + 256 );
        }
    }

    // Token: 0x17000044 RID: 68
    // (get) Token: 0x0600121B RID: 4635 RVA: 0x0009E663 File Offset: 0x0009C863
    public static int GMD_GMK_DRAIN_TANK_DRAW_WATER_HEIGHT
    {
        get
        {
            return ( int )( AppMain.OBD_LCD_Y + 256 );
        }
    }

    // Token: 0x0600121C RID: 4636 RVA: 0x0009E670 File Offset: 0x0009C870
    private static AppMain.OBS_OBJECT_WORK GmGmkDrainTankInitIn( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkDrainTankLoadObj(eve_rec, pos_x, pos_y, 0, 0U);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkDrainTankInInit( obj_work );
        return obj_work;
    }

    // Token: 0x0600121D RID: 4637 RVA: 0x0009E69C File Offset: 0x0009C89C
    private static AppMain.OBS_OBJECT_WORK GmGmkDrainTankInitOut( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( pos_x - 524288 < obs_OBJECT_WORK.pos.x )
        {
            return null;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkDrainTankLoadObj(eve_rec, pos_x, pos_y, 1, 1U);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkDrainTankOutInit( obj_work );
        return obj_work;
    }

    // Token: 0x0600121E RID: 4638 RVA: 0x0009E6F0 File Offset: 0x0009C8F0
    private static AppMain.OBS_OBJECT_WORK GmGmkDrainTankSplashInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkDrainTankLoadObj(eve_rec, pos_x, pos_y, 2, 2U);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkDrainTankSplashInit( obj_work );
        return obj_work;
    }

    // Token: 0x0600121F RID: 4639 RVA: 0x0009E71B File Offset: 0x0009C91B
    public static void GmGmkDrainTankBuild()
    {
        AppMain.g_gm_gmk_drain_tank_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 923 ), AppMain.GmGameDatGetGimmickData( 924 ), 0U );
    }

    // Token: 0x06001220 RID: 4640 RVA: 0x0009E73C File Offset: 0x0009C93C
    public static void GmGmkDrainTankFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(923);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_drain_tank_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_drain_tank_obj_3d_list = null;
    }

    // Token: 0x06001221 RID: 4641 RVA: 0x0009E778 File Offset: 0x0009C978
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkDrainTankLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK;
        if ( type == 1 )
        {
            AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK(), "GMK_DRAIN_TANK");
            gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x = pos_x + 262144;
            gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_y = pos_y;
            gms_ENEMY_3D_WORK = gms_GMK_DRAIN_TANK_OUT_WORK.enemy_work;
        }
        else
        {
            gms_ENEMY_3D_WORK = ( AppMain.GMS_ENEMY_3D_WORK )AppMain.GMM_ENEMY_CREATE_WORK( eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_DRAIN_TANK" );
        }
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001222 RID: 4642 RVA: 0x0009E840 File Offset: 0x0009CA40
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkDrainTankLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type, uint model_id )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkDrainTankLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_drain_tank_obj_3d_list[( int )( ( UIntPtr )model_id )], gms_ENEMY_3D_WORK.obj_3d );
        if ( type == 2 )
        {
            int index = 0;
            object pData = AppMain.ObjDataGet(925).pData;
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_ENEMY_3D_WORK.obj_3d, 0, null, null, index, ( AppMain.AMS_AMB_HEADER )pData );
        }
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001223 RID: 4643 RVA: 0x0009E8A4 File Offset: 0x0009CAA4
    private static ushort gmGmkDrainTankGameSystemGetWaterLevel()
    {
        return AppMain.g_gm_main_system.water_level;
    }

    // Token: 0x06001224 RID: 4644 RVA: 0x0009E8B0 File Offset: 0x0009CAB0
    private static void gmGmkDrainTankInInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.ObjObjectFieldRectSet( obj_work, -16, 0, 0, 14 );
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 16;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 32;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = -16;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -32;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankDrawFuncIn );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankInMainReady );
        obj_work.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.obj_3d.command_state = 8U;
        obj_work.pos.z = 1441792;
    }

    // Token: 0x06001225 RID: 4645 RVA: 0x0009E9A0 File Offset: 0x0009CBA0
    private static void gmGmkDrainTankOutInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.ObjObjectFieldRectSet( obj_work, 0, 0, 32, 16 );
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankDrawFuncOut );
        AppMain.gmGmkDrainTankOutChangeModeReady( obj_work );
        obj_work.disp_flag |= 4194304U;
        obj_work.move_flag |= 128U;
        obj_work.flag |= 16U;
        gms_ENEMY_3D_WORK.obj_3d.command_state = 8U;
        obj_work.pos.z = 1441792;
        AppMain.GmWaterSurfaceRequestChangeWaterLevel( ( ushort )AppMain.FX_FX32_TO_F32( obj_work.pos.y - 196608 ), 0, false );
        AppMain.GmWaterSurfaceSetFlagEnableRef( false );
        AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkDrainTankTcbDestOut ) );
    }

    // Token: 0x06001226 RID: 4646 RVA: 0x0009EA64 File Offset: 0x0009CC64
    private static void gmGmkDrainTankSplashInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 4194304U;
        obj_work.move_flag = 8448U;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        obj_work.pos.z = 262144;
        obj_work.disp_flag |= 134217728U;
        obj_work.obj_3d.drawflag |= 8388608U;
        obj_work.obj_3d.draw_state.alpha.alpha = 1f;
        obj_work.user_timer = 60;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankSplashMainFunc );
        obj_work.ppMove = null;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 2, 34);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankSplashEffectMain );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.move_flag = 384U;
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        obj_work2.pos.y = obj_work2.pos.y + -131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = obj_work.pos.z + 131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.spd.x = 49152;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.spd.y = 12288;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.spd_add.x = -1376;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.spd_add.y = 0;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK2 = AppMain.GmEfctZoneEsCreate(obj_work, 2, 35);
        AppMain.OBS_OBJECT_WORK obj_work3 = gms_EFFECT_3DES_WORK2.efct_com.obj_work;
        obj_work3.pos.y = obj_work3.pos.y + -65536;
        gms_EFFECT_3DES_WORK2.efct_com.obj_work.pos.z = obj_work.pos.z + 131072;
    }

    // Token: 0x06001227 RID: 4647 RVA: 0x0009EC40 File Offset: 0x0009CE40
    private static void gmGmkDrainTankDrawFuncIn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, 8U );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06001228 RID: 4648 RVA: 0x0009EC5C File Offset: 0x0009CE5C
    private static void gmGmkDrainTankDrawFuncOut( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 32U ) == 0U )
        {
            AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
            int num = -(int)AppMain.FX_FX32_TO_F32(gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_y) - 64;
            num /= 64;
            num = ( num - 1 ) * 64;
            int num2 = (int)AppMain.FX_FX32_TO_F32(gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x) - 96;
            num2 /= 64;
            num2 *= 64;
            int num3 = num2 - 152;
            int num4 = num + 96;
            int num5 = num2 + 64;
            AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, 9U );
            AppMain.GmWaterSurfaceDrawNoWaterField( AppMain.FX_FX32_TO_F32( obj_work.pos.x ), -AppMain.FX_FX32_TO_F32( obj_work.pos.y ) + ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_HEIGHT, AppMain.FX_FX32_TO_F32( obj_work.pos.x ) + ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH, -AppMain.FX_FX32_TO_F32( obj_work.pos.y ) - ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_HEIGHT );
            AppMain.GmWaterSurfaceDrawNoWaterField( ( float )num2, -AppMain.FX_FX32_TO_F32( gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_y ) + ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_HEIGHT, AppMain.FX_FX32_TO_F32( gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x ) + ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH, ( float )num4 );
            AppMain.GmWaterSurfaceDrawNoWaterField( AppMain.FX_FX32_TO_F32( gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x ) - ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH, ( float )num, AppMain.FX_FX32_TO_F32( gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x ) + ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH, ( float )( num - AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_HEIGHT ) );
            AppMain.GmWaterSurfaceDrawNoWaterField( ( float )( num3 - AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH ), -AppMain.FX_FX32_TO_F32( gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_y ) + ( float )AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_HEIGHT, ( float )num3, ( float )num );
            AppMain.GmWaterSurfaceDrawNoWaterField( ( float )num5, ( float )num4, ( float )( num5 + AppMain.GMD_GMK_DRAIN_TANK_DRAW_WATER_WIDTH ), ( float )num );
        }
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, 1, 8U );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06001229 RID: 4649 RVA: 0x0009EDF2 File Offset: 0x0009CFF2
    private static void gmGmkDrainTankTcbDestOut( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GmWaterSurfaceSetFlagEnableRef( true );
        AppMain.g_gm_main_system.game_flag &= 4294959103U;
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x0600122A RID: 4650 RVA: 0x0009EE18 File Offset: 0x0009D018
    private static bool gmGmkDrainTankInCheckDeleteTask( AppMain.OBS_OBJECT_WORK obj_work, int cmp_x, int cmp_y )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        int num = AppMain.MTM_MATH_ABS(obj_work.pos.x - obj_work2.pos.x);
        int num2 = AppMain.MTM_MATH_ABS(obj_work.pos.y - obj_work2.pos.y);
        return num > cmp_x || num2 > cmp_y;
    }

    // Token: 0x0600122B RID: 4651 RVA: 0x0009EE7F File Offset: 0x0009D07F
    private static void gmGmkDrainTankInRequestDeleteTask( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.flag |= 4U;
    }

    // Token: 0x0600122C RID: 4652 RVA: 0x0009EE90 File Offset: 0x0009D090
    private static void gmGmkDrainTankInMainReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            return;
        }
        if ( AppMain.gmGmkDrainTankInCheckDeleteTask( obj_work, 1843200, 1228800 ) )
        {
            AppMain.gmGmkDrainTankInRequestDeleteTask( obj_work );
            return;
        }
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        if ( obj_work.pos.x + 65536 < obj_work2.pos.x )
        {
            obj_work.pos.y = obj_work.pos.y + 32768;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankInMainWait );
            obj_work.move_flag |= 128U;
        }
    }

    // Token: 0x0600122D RID: 4653 RVA: 0x0009EF34 File Offset: 0x0009D134
    private static void gmGmkDrainTankInMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            return;
        }
        if ( AppMain.gmGmkDrainTankInCheckDeleteTask( obj_work, 1843200, 1228800 ) )
        {
            AppMain.gmGmkDrainTankInRequestDeleteTask( obj_work );
        }
    }

    // Token: 0x0600122E RID: 4654 RVA: 0x0009EF78 File Offset: 0x0009D178
    private static bool gmGmkDrainTankOutCheckDeleteTask( AppMain.OBS_OBJECT_WORK obj_work, int cmp_x, int cmp_y )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        int num = AppMain.MTM_MATH_ABS(gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x - obj_work2.pos.x);
        int num2 = AppMain.MTM_MATH_ABS(gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_y - obj_work2.pos.y);
        return num > cmp_x || num2 > cmp_y;
    }

    // Token: 0x0600122F RID: 4655 RVA: 0x0009EFE0 File Offset: 0x0009D1E0
    private static void gmGmkDrainTankOutRequestDeleteTask( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK ply_work = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GmPlayerCameraOffsetSet( ply_work, 0, 0 );
        AppMain.GmCameraAllowReset();
        AppMain.GmWaterSurfaceRequestChangeWaterLevel( ushort.MaxValue, 0, false );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankOutMainWaitDelete );
    }

    // Token: 0x06001230 RID: 4656 RVA: 0x0009F026 File Offset: 0x0009D226
    private static void gmGmkDrainTankOutChangeModeReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.x = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankOutMainReady );
    }

    // Token: 0x06001231 RID: 4657 RVA: 0x0009F048 File Offset: 0x0009D248
    private static void gmGmkDrainTankOutChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        gms_GMK_DRAIN_TANK_OUT_WORK.player_offset_x = obj_work2.pos.x - gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x;
        gms_GMK_DRAIN_TANK_OUT_WORK.player_offset_y = obj_work2.pos.y - gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_y;
        obj_work.spd.x = 0;
        gms_GMK_DRAIN_TANK_OUT_WORK.counter_roll_key = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankOutMainWait );
    }

    // Token: 0x06001232 RID: 4658 RVA: 0x0009F0C6 File Offset: 0x0009D2C6
    private static void gmGmkDrainTankOutChangeModeDamage( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.x = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankOutMainDamage );
    }

    // Token: 0x06001233 RID: 4659 RVA: 0x0009F0E8 File Offset: 0x0009D2E8
    private static void gmGmkDrainTankOutChangeModeSplash( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)gms_ENEMY_3D_WORK;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        if ( gms_GMK_DRAIN_TANK_OUT_WORK.flag_dir_left )
        {
            obj_work2.spd.x = -65536;
        }
        else
        {
            obj_work2.spd.x = 65536;
        }
        obj_work2.pos.y = obj_work.pos.y;
        obj_work2.move_flag |= 256U;
        AppMain.GmPlayerBreathingSet( gms_PLAYER_WORK );
        obj_work.move_flag |= 256U;
        AppMain.g_gm_main_system.game_flag |= 8192U;
        AppMain.GmEventMgrLocalEventBirth( 305, obj_work.pos.x, obj_work.pos.y + 65536, gms_ENEMY_3D_WORK.ene_com.eve_rec.flag, gms_ENEMY_3D_WORK.ene_com.eve_rec.left, gms_ENEMY_3D_WORK.ene_com.eve_rec.top, gms_ENEMY_3D_WORK.ene_com.eve_rec.width, gms_ENEMY_3D_WORK.ene_com.eve_rec.height, 0 );
        AppMain.GmSoundPlaySE( "Fluid2" );
        AppMain.GMM_PAD_VIB_SMALL();
        AppMain.GmPlayerCameraOffsetSet( gms_PLAYER_WORK, 0, 0 );
        AppMain.GmCameraAllowReset();
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankOutMainSplash );
    }

    // Token: 0x06001234 RID: 4660 RVA: 0x0009F23E File Offset: 0x0009D43E
    private static void gmGmkDrainTankOutChangeModeEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkDrainTankOutMainEnd );
    }

    // Token: 0x06001235 RID: 4661 RVA: 0x0009F254 File Offset: 0x0009D454
    private static void gmGmkDrainTankOutMainReady( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            AppMain.gmGmkDrainTankOutUpdateDie( obj_work );
            int num = (int)AppMain.FX_FX32_TO_F32(gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x);
            num /= 64;
            num -= 3;
            num *= 262144;
            if ( obj_work2.pos.x < num )
            {
                AppMain.g_gm_main_system.game_flag |= 8192U;
            }
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            return;
        }
        if ( AppMain.gmGmkDrainTankOutCheckDeleteTask( obj_work, 1843200, 1228800 ) )
        {
            AppMain.gmGmkDrainTankOutRequestDeleteTask( obj_work );
            return;
        }
        int num2 = (int)(AppMain.gmGmkDrainTankGameSystemGetWaterLevel() * 4096);
        if ( num2 + 196608 < obj_work2.pos.y )
        {
            AppMain.gmGmkDrainTankOutChangeModeWait( obj_work );
            gms_GMK_DRAIN_TANK_OUT_WORK.flag_dir_left = AppMain.gmGmkDrainTankOutCheckDirLeft( obj_work, obj_work2 );
            int x = obj_work2.spd.x;
            AppMain.GmPlySeqInitDrainTank( gms_PLAYER_WORK );
            gms_GMK_DRAIN_TANK_OUT_WORK.player_offset_x += x * 5;
            AppMain.gmGmkDrainTankOutUpdateCameraOffset( gms_PLAYER_WORK, gms_GMK_DRAIN_TANK_OUT_WORK );
            AppMain.GmCameraAllowSet( 10f, 10f, 10f );
        }
    }

    // Token: 0x06001236 RID: 4662 RVA: 0x0009F37C File Offset: 0x0009D57C
    private static void gmGmkDrainTankOutMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            AppMain.gmGmkDrainTankOutUpdateDie( obj_work );
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            return;
        }
        if ( AppMain.gmGmkDrainTankOutCheckDeleteTask( obj_work, 1843200, 1228800 ) )
        {
            AppMain.gmGmkDrainTankOutRequestDeleteTask( obj_work );
            return;
        }
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        if ( gms_PLAYER_WORK.seq_state == 22 )
        {
            AppMain.gmGmkDrainTankOutChangeModeDamage( obj_work );
            return;
        }
        if ( ( obj_work.move_flag & 1U ) == 0U )
        {
            AppMain.gmGmkDrainTankOutChangeModeSplash( obj_work );
            return;
        }
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        int num = AppMain.GmPlayerKeyGetGimmickRotZ(gms_PLAYER_WORK);
        if ( AppMain.MTM_MATH_ABS( num ) > 8192 )
        {
            gms_GMK_DRAIN_TANK_OUT_WORK.counter_roll_key++;
        }
        else
        {
            gms_GMK_DRAIN_TANK_OUT_WORK.counter_roll_key = 0;
        }
        if ( gms_GMK_DRAIN_TANK_OUT_WORK.counter_roll_key >= 0 )
        {
            AppMain.gmGmkDrainTankOutUpdateCameraRoll( gms_GMK_DRAIN_TANK_OUT_WORK, num );
            if ( 19 == gms_GMK_DRAIN_TANK_OUT_WORK.counter_roll_key % 20 && AppMain.MTM_MATH_ABS( gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll ) < AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX )
            {
                AppMain.GmSoundPlaySE( "Fluid1" );
            }
        }
        if ( AppMain.gmGmkDrainTankOutCheckKeyDir( obj_work, gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll ) )
        {
            int x = gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll >> 3;
            obj_work.spd.x = x;
            float a = AppMain.FX_FX32_TO_F32(gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll >> 4);
            a = AppMain.MTM_MATH_ABS( a );
            AppMain.GmWaterSurfaceRequestAddWatarLevel( AppMain.MTM_MATH_ABS( a ), 0, true );
        }
        AppMain.gmGmkDrainTankOutAdjustPlayerOffsetBuoyancy( gms_GMK_DRAIN_TANK_OUT_WORK );
        AppMain.gmGmkDrainTankOutAdjustPlayerOffsetWave( gms_GMK_DRAIN_TANK_OUT_WORK, obj_work2 );
        AppMain.gmGmkDrainTankOutApplyPlayerOffset( obj_work2, gms_GMK_DRAIN_TANK_OUT_WORK );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.roll = gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll;
        AppMain.gmGmkDrainTankOutUpdateCameraOffset( gms_PLAYER_WORK, gms_GMK_DRAIN_TANK_OUT_WORK );
    }

    // Token: 0x06001237 RID: 4663 RVA: 0x0009F4EC File Offset: 0x0009D6EC
    private static void gmGmkDrainTankOutMainDamage( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            AppMain.gmGmkDrainTankOutUpdateDie( obj_work );
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            return;
        }
        if ( AppMain.gmGmkDrainTankOutCheckDeleteTask( obj_work, 1843200, 1228800 ) )
        {
            AppMain.gmGmkDrainTankOutRequestDeleteTask( obj_work );
            return;
        }
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.gmGmkDrainTankOutUpdateCameraRollDamage( gms_GMK_DRAIN_TANK_OUT_WORK );
        int num = (AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX - AppMain.MTM_MATH_ABS(gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll)) * 4;
        int num2 = num >> 3;
        if ( gms_GMK_DRAIN_TANK_OUT_WORK.flag_dir_left )
        {
            obj_work.spd.x = num2;
        }
        else
        {
            obj_work.spd.x = -num2;
        }
        float num3 = AppMain.FX_FX32_TO_F32(num >> 4);
        AppMain.GmWaterSurfaceRequestAddWatarLevel( -num3, 0, true );
        obj_work.user_timer++;
        if ( ( obj_work2.move_flag & 1U ) != 0U )
        {
            obj_work.user_timer = 0;
            AppMain.gmGmkDrainTankOutChangeModeWait( obj_work );
            AppMain.GmPlySeqInitDrainTank( gms_PLAYER_WORK );
            return;
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.roll = gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll;
        AppMain.gmGmkDrainTankOutUpdateCameraOffset( gms_PLAYER_WORK, gms_GMK_DRAIN_TANK_OUT_WORK );
        AppMain.gmGmkDrainTankOutSinkRing();
    }

    // Token: 0x06001238 RID: 4664 RVA: 0x0009F600 File Offset: 0x0009D800
    private static void gmGmkDrainTankOutMainSplash( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            AppMain.gmGmkDrainTankOutUpdateDie( obj_work );
            return;
        }
        if ( AppMain.gmGmkDrainTankOutCheckDeleteTask( obj_work, 1638400, 1228800 ) )
        {
            AppMain.gmGmkDrainTankOutRequestDeleteTask( obj_work );
            return;
        }
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.GmWaterSurfaceRequestAddWatarLevel( 0.001f, 0, true );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.roll = gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll;
        if ( gms_GMK_DRAIN_TANK_OUT_WORK.base_pos_x < obj_work2.pos.x )
        {
            obj_work2.move_flag |= 128U;
            obj_work2.move_flag &= 4294967039U;
            obj_work2.spd.x = 65536;
            obj_work2.spd_add.x = -896;
            AppMain.GmPlayerCameraOffsetSet( gms_PLAYER_WORK, 0, 0 );
            AppMain.GmCameraAllowReset();
            AppMain.gmGmkDrainTankOutChangeModeEnd( obj_work );
        }
    }

    // Token: 0x06001239 RID: 4665 RVA: 0x0009F6E0 File Offset: 0x0009D8E0
    private static void gmGmkDrainTankOutMainEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            AppMain.gmGmkDrainTankOutUpdateDie( obj_work );
            return;
        }
        if ( AppMain.gmGmkDrainTankOutCheckDeleteTask( obj_work, 1638400, 1228800 ) )
        {
            AppMain.gmGmkDrainTankOutRequestDeleteTask( obj_work );
            AppMain.GmPlySeqInitDrainTankFall( gms_PLAYER_WORK );
        }
    }

    // Token: 0x0600123A RID: 4666 RVA: 0x0009F730 File Offset: 0x0009D930
    private static void gmGmkDrainTankOutMainWaitDelete( AppMain.OBS_OBJECT_WORK obj_work )
    {
        ushort num = AppMain.gmGmkDrainTankGameSystemGetWaterLevel();
        if ( num != 65535 )
        {
            return;
        }
        obj_work.flag |= 4U;
    }

    // Token: 0x0600123B RID: 4667 RVA: 0x0009F75C File Offset: 0x0009D95C
    private static void gmGmkDrainTankOutUpdateDie( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)obj_work;
        AppMain.gmGmkDrainTankOutUpdateCameraRollDie( gms_GMK_DRAIN_TANK_OUT_WORK );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        obs_CAMERA.roll = gms_GMK_DRAIN_TANK_OUT_WORK.camera_roll;
    }

    // Token: 0x0600123C RID: 4668 RVA: 0x0009F789 File Offset: 0x0009D989
    private static bool gmGmkDrainTankOutCheckDirLeft( AppMain.OBS_OBJECT_WORK gimmick_obj_work, AppMain.OBS_OBJECT_WORK player_obj_work )
    {
        return player_obj_work.pos.x >= gimmick_obj_work.pos.x;
    }

    // Token: 0x0600123D RID: 4669 RVA: 0x0009F7A8 File Offset: 0x0009D9A8
    private static void gmGmkDrainTankOutAdjustPlayerOffsetBuoyancy( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work )
    {
        int num = (int)(AppMain.gmGmkDrainTankGameSystemGetWaterLevel() * 4096) + 131072;
        if ( num > out_work.base_pos_y )
        {
            num = out_work.base_pos_y;
        }
        int num2 = num - (out_work.base_pos_y + out_work.player_offset_y);
        if ( AppMain.MTM_MATH_ABS( num2 ) > 2048 )
        {
            if ( num2 < 0 )
            {
                num2 = -2048;
            }
            else
            {
                num2 = 2048;
            }
        }
        out_work.player_offset_y += num2;
    }

    // Token: 0x0600123E RID: 4670 RVA: 0x0009F814 File Offset: 0x0009DA14
    private static void gmGmkDrainTankOutAdjustPlayerOffsetWave( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work, AppMain.OBS_OBJECT_WORK player_obj_work )
    {
        int num = out_work.camera_roll >> 2;
        if ( ( player_obj_work.move_flag & 4U ) == 0U )
        {
            if ( out_work.camera_roll < 0 )
            {
                player_obj_work.disp_flag |= 1U;
            }
            else if ( out_work.camera_roll > 0 )
            {
                player_obj_work.disp_flag &= 4294967294U;
            }
            out_work.player_offset_x += num;
            return;
        }
        if ( ( player_obj_work.disp_flag & 1U ) != 0U )
        {
            out_work.player_offset_x += AppMain.FX_F32_TO_FX32( 0.4f );
            return;
        }
        out_work.player_offset_x -= AppMain.FX_F32_TO_FX32( 0.4f );
    }

    // Token: 0x0600123F RID: 4671 RVA: 0x0009F8B0 File Offset: 0x0009DAB0
    private static void gmGmkDrainTankOutApplyPlayerOffset( AppMain.OBS_OBJECT_WORK player_obj_work, AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work )
    {
        int num = out_work.base_pos_x + out_work.player_offset_x;
        int num2 = out_work.base_pos_y + out_work.player_offset_y;
        player_obj_work.spd.x = num - player_obj_work.pos.x;
        player_obj_work.spd.y = num2 - player_obj_work.pos.y;
    }

    // Token: 0x06001240 RID: 4672 RVA: 0x0009F90C File Offset: 0x0009DB0C
    private static void gmGmkDrainTankOutUpdateCameraRoll( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work, int rot_z )
    {
        if ( rot_z >= -8192 )
        {
            if ( rot_z > 8192 )
            {
                if ( out_work.camera_roll >= AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX )
                {
                    out_work.camera_roll = AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX;
                    return;
                }
                out_work.camera_roll += AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_SPEED;
            }
            return;
        }
        if ( out_work.camera_roll <= -AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX )
        {
            out_work.camera_roll = -AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX;
            return;
        }
        out_work.camera_roll -= AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_SPEED;
    }

    // Token: 0x06001241 RID: 4673 RVA: 0x0009F984 File Offset: 0x0009DB84
    private static void gmGmkDrainTankOutUpdateCameraRollDamage( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work )
    {
        int num = AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_SPEED * 4;
        if ( out_work.flag_dir_left )
        {
            out_work.camera_roll += num;
            if ( out_work.camera_roll < -AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX )
            {
                out_work.camera_roll = -AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX;
                return;
            }
        }
        else
        {
            out_work.camera_roll -= num;
            if ( out_work.camera_roll > AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX )
            {
                out_work.camera_roll = AppMain.GMD_GMK_DRAIN_TANK_ROLL_ANGLE_MAX;
            }
        }
    }

    // Token: 0x06001242 RID: 4674 RVA: 0x0009F9F0 File Offset: 0x0009DBF0
    private static void gmGmkDrainTankOutUpdateCameraRollDie( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work )
    {
        out_work.camera_roll -= out_work.camera_roll / 5;
    }

    // Token: 0x06001243 RID: 4675 RVA: 0x0009FA08 File Offset: 0x0009DC08
    private static void gmGmkDrainTankOutUpdateCameraOffset( AppMain.GMS_PLAYER_WORK player_work, AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK out_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)player_work;
        float num = AppMain.FX_FX32_TO_F32(out_work.base_pos_x - 737280 - obs_OBJECT_WORK.pos.x);
        AppMain.GmPlayerCameraOffsetSet( player_work, ( short )num, 0 );
    }

    // Token: 0x06001244 RID: 4676 RVA: 0x0009FA44 File Offset: 0x0009DC44
    private static bool gmGmkDrainTankOutCheckKeyDir( AppMain.OBS_OBJECT_WORK gimmick_obj_work, int camera_roll )
    {
        AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK gms_GMK_DRAIN_TANK_OUT_WORK = (AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK)gimmick_obj_work;
        return ( camera_roll < 0 && gms_GMK_DRAIN_TANK_OUT_WORK.flag_dir_left ) || ( camera_roll > 0 && !gms_GMK_DRAIN_TANK_OUT_WORK.flag_dir_left );
    }

    // Token: 0x06001245 RID: 4677 RVA: 0x0009FA78 File Offset: 0x0009DC78
    private static void gmGmkDrainTankOutSinkRing()
    {
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.GmRingGetWork();
        for ( AppMain.GMS_RING_WORK gms_RING_WORK = gms_RING_SYS_WORK.damage_ring_list_start; gms_RING_WORK != null; gms_RING_WORK = gms_RING_WORK.post_ring )
        {
            gms_RING_WORK.spd_y = 4096;
            gms_RING_WORK.spd_x /= 2;
        }
    }

    // Token: 0x06001246 RID: 4678 RVA: 0x0009FAB8 File Offset: 0x0009DCB8
    private static void gmGmkDrainTankSplashMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer--;
        if ( obj_work.user_timer > 0 )
        {
            float alpha = (float)obj_work.user_timer / 60f;
            obj_work.obj_3d.draw_state.alpha.alpha = alpha;
            return;
        }
        obj_work.disp_flag |= 16U;
        obj_work.ppFunc = null;
    }

    // Token: 0x06001247 RID: 4679 RVA: 0x0009FB17 File Offset: 0x0009DD17
    private static void gmGmkDrainTankSplashEffectMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.dir.z = ( ushort )( obj_work.dir.z + 3840 );
    }
}