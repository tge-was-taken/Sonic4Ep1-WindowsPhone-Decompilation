using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060004F7 RID: 1271 RVA: 0x0002AAE4 File Offset: 0x00028CE4
    private static AppMain.OBS_OBJECT_WORK GmBoss5LandInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_BOSS5_LAND_PLACEMENT_INFO gms_BOSS5_LAND_PLACEMENT_INFO = new AppMain.GMS_BOSS5_LAND_PLACEMENT_INFO();
        if ( AppMain.gmBoss5LandGetPlacementInfo( gms_BOSS5_LAND_PLACEMENT_INFO ) == 0 )
        {
            return null;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, gms_BOSS5_LAND_PLACEMENT_INFO.pos_x, gms_BOSS5_LAND_PLACEMENT_INFO.pos_y, () => new AppMain.GMS_BOSS5_LAND_WORK(), "BOSS5_LAND");
        AppMain.GMS_BOSS5_LAND_WORK land_work = (AppMain.GMS_BOSS5_LAND_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.pos.z = -524288;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        for ( int i = 0; i < gms_BOSS5_LAND_PLACEMENT_INFO.part_num; i++ )
        {
            uint num = (uint)((long)i % 3L);
            AppMain.gmBoss5LandCreateLdPart( land_work, AppMain.gm_boss5_land_place_pattern_tbl[( int )( ( UIntPtr )num )], i );
        }
        AppMain.gmBoss5LandSetObjCollisionRect( land_work, gms_BOSS5_LAND_PLACEMENT_INFO.part_num );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5LandMain );
        AppMain.gmBoss5LandProcInit( land_work );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060004F8 RID: 1272 RVA: 0x0002AC0C File Offset: 0x00028E0C
    private static AppMain.GMS_BOSS5_LAND_WORK GmBoss5LandCreate( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(mgr_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(344, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0);
        if ( obs_OBJECT_WORK2 == null )
        {
            return null;
        }
        AppMain.GMS_BOSS5_LAND_WORK gms_BOSS5_LAND_WORK = (AppMain.GMS_BOSS5_LAND_WORK)obs_OBJECT_WORK2;
        gms_BOSS5_LAND_WORK.mgr_work = mgr_work;
        return ( AppMain.GMS_BOSS5_LAND_WORK )obs_OBJECT_WORK2;
    }

    // Token: 0x060004F9 RID: 1273 RVA: 0x0002AC60 File Offset: 0x00028E60
    private static int gmBoss5LandGetPlacementInfo( AppMain.GMS_BOSS5_LAND_PLACEMENT_INFO place_info )
    {
        AppMain.GMS_EVE_RECORD_EVENT gms_EVE_RECORD_EVENT = null;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        for ( obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_COM_WORK.eve_rec != null && gms_ENEMY_COM_WORK.eve_rec.id == 282 )
            {
                gms_EVE_RECORD_EVENT = gms_ENEMY_COM_WORK.eve_rec;
                break;
            }
        }
        if ( obs_OBJECT_WORK == null )
        {
            AppMain.mppAssertNotImpl();
            return 0;
        }
        place_info.pos_x = obs_OBJECT_WORK.pos.x;
        place_info.pos_y = obs_OBJECT_WORK.pos.y;
        int num = (int)(gms_EVE_RECORD_EVENT.left + (sbyte)gms_EVE_RECORD_EVENT.width);
        num <<= 3;
        place_info.part_num = ( int )( ( long )num / ( long )( ( ulong )AppMain.GMD_BOSS5_LAND_LDPART_WIDTH_INT ) );
        return 1;
    }

    // Token: 0x060004FA RID: 1274 RVA: 0x0002AD00 File Offset: 0x00028F00
    private static void gmBoss5LandSetObjCollisionRect( AppMain.GMS_BOSS5_LAND_WORK land_work, int part_num )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(land_work);
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)land_work;
        gms_ENEMY_COM_WORK.col_work.obj_col.obj = AppMain.GMM_BS_OBJ( land_work );
        gms_ENEMY_COM_WORK.col_work.obj_col.width = ( ushort )( ( long )part_num * ( long )( ( ulong )AppMain.GMD_BOSS5_LAND_LDPART_WIDTH_INT ) );
        gms_ENEMY_COM_WORK.col_work.obj_col.height = AppMain.GMD_BOSS5_LAND_LDPART_HEIGHT_INT;
        gms_ENEMY_COM_WORK.col_work.obj_col.ofst_x = 0;
        gms_ENEMY_COM_WORK.col_work.obj_col.ofst_y = 0;
        obs_OBJECT_WORK.view_out_ofst_plus[0] = ( short )( gms_ENEMY_COM_WORK.col_work.obj_col.ofst_x - ( short )gms_ENEMY_COM_WORK.col_work.obj_col.width );
        obs_OBJECT_WORK.view_out_ofst_plus[2] = ( short )( gms_ENEMY_COM_WORK.col_work.obj_col.ofst_x + ( short )gms_ENEMY_COM_WORK.col_work.obj_col.width );
    }

    // Token: 0x060004FB RID: 1275 RVA: 0x0002ADD8 File Offset: 0x00028FD8
    private static void gmBoss5LandDisableObjCollision( AppMain.GMS_BOSS5_LAND_WORK land_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)land_work;
        gms_ENEMY_COM_WORK.col_work.obj_col.obj = null;
    }

    // Token: 0x060004FC RID: 1276 RVA: 0x0002AE00 File Offset: 0x00029000
    private static void gmBoss5LandMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_LAND_WORK gms_BOSS5_LAND_WORK = (AppMain.GMS_BOSS5_LAND_WORK)obj_work;
        if ( gms_BOSS5_LAND_WORK.proc_update != null )
        {
            gms_BOSS5_LAND_WORK.proc_update( gms_BOSS5_LAND_WORK );
        }
    }

    // Token: 0x060004FD RID: 1277 RVA: 0x0002AE28 File Offset: 0x00029028
    private static void gmBoss5LandProcInit( AppMain.GMS_BOSS5_LAND_WORK land_work )
    {
        land_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_LAND_WORK( AppMain.gmBoss5LandProcUpdateIdle );
    }

    // Token: 0x060004FE RID: 1278 RVA: 0x0002AE3C File Offset: 0x0002903C
    private static void gmBoss5LandProcUpdateIdle( AppMain.GMS_BOSS5_LAND_WORK land_work )
    {
        if ( ( land_work.mgr_work.flag & 536870912U ) != 0U )
        {
            land_work.flag |= AppMain.GMD_BOSS5_LAND_FLAG_SHAKE_ACTIVE;
            land_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_LAND_WORK( AppMain.gmBoss5LandProcUpdateShake );
        }
    }

    // Token: 0x060004FF RID: 1279 RVA: 0x0002AE75 File Offset: 0x00029075
    private static void gmBoss5LandProcUpdateShake( AppMain.GMS_BOSS5_LAND_WORK land_work )
    {
        if ( ( land_work.mgr_work.flag & 1073741824U ) != 0U )
        {
            land_work.flag |= AppMain.GMD_BOSS5_LAND_FLAG_BREAK_ACTIVE;
            AppMain.gmBoss5LandDisableObjCollision( land_work );
            land_work.proc_update = null;
        }
    }

    // Token: 0x06000500 RID: 1280 RVA: 0x0002AEB0 File Offset: 0x000290B0
    private static AppMain.GMS_BOSS5_LDPART_WORK gmBoss5LandCreateLdPart( AppMain.GMS_BOSS5_LAND_WORK land_work, int land_type, int part_index )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(land_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_BOSS5_LDPART_WORK(), parent_obj, 0, "BOSS5_LAND_PART");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS5_LDPART_WORK gms_BOSS5_LDPART_WORK = (AppMain.GMS_BOSS5_LDPART_WORK)obs_OBJECT_WORK;
        gms_BOSS5_LDPART_WORK.part_index = part_index;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss5GetObject3dList()[AppMain.gm_boss5_land_mdl_amb_idx_tbl[land_type]], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.obj_3d.drawflag = ( uint )( ( ulong )obs_OBJECT_WORK.obj_3d.drawflag & ulong.MaxValue );
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obs_OBJECT_WORK, 0, AppMain.ObjDataGet( AppMain.gm_boss5_land_mat_mtn_dwork_no_tbl[land_type] ), null, AppMain.gm_boss5_land_mat_mtn_data_tbl[land_type], null );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        obs_OBJECT_WORK.flag |= 1024U;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.parent_ofst.x = AppMain.GMD_BOSS5_LAND_LDPART_WIDTH_FX / 2 + part_index * AppMain.GMD_BOSS5_LAND_LDPART_WIDTH_FX + AppMain.GMD_BOSS5_LAND_LDPART_CENTER_OFST_X_FX;
        obs_OBJECT_WORK.parent_ofst.y = AppMain.GMD_BOSS5_LAND_LDPART_HEIGHT_FX / 2 + AppMain.GMD_BOSS5_LAND_LDPART_CENTER_OFST_Y_FX;
        obs_OBJECT_WORK.parent_ofst.z = 0;
        gms_BOSS5_LDPART_WORK.pivot_parent_ofst[0] = obs_OBJECT_WORK.parent_ofst.x;
        gms_BOSS5_LDPART_WORK.pivot_parent_ofst[1] = obs_OBJECT_WORK.parent_ofst.y;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5LdPartMain );
        AppMain.gmBoss5LdPartProcInit( gms_BOSS5_LDPART_WORK );
        return gms_BOSS5_LDPART_WORK;
    }

    // Token: 0x06000501 RID: 1281 RVA: 0x0002B054 File Offset: 0x00029254
    private static void gmBoss5LdPartInitSpin( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        AppMain.nnMakeUnitQuaternion( ref ldpart_work.cur_rot_quat );
        AppMain.nnMakeUnitQuaternion( ref ldpart_work.rot_diff_quat );
        int num = 0;
        while ( ( long )num < ( long )( ( ulong )AppMain.GMD_BOSS5_LAND_LDPART_SPIN_ROT_AXIS_NUM ) )
        {
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            float num2 = AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()) * 2f - 1f;
            num2 = AppMain.MTM_MATH_CLIP( num2, -1f, 1f );
            short rand_angle = AppMain.AKM_DEGtoA16(360f * AppMain.FX_FX32_TO_F32(AppMain.AkMathRandFx()));
            AppMain.AkMathGetRandomUnitVector( nns_VECTOR, num2, rand_angle );
            AppMain.NNS_QUATERNION nns_QUATERNION;
            AppMain.nnMakeRotateAxisQuaternion( out nns_QUATERNION, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z, AppMain.GMD_BOSS5_LAND_LDPART_SPIN_ROT_SPD_DEG );
            AppMain.nnMultiplyQuaternion( ref ldpart_work.rot_diff_quat, ref nns_QUATERNION, ref ldpart_work.rot_diff_quat );
            num++;
        }
    }

    // Token: 0x06000502 RID: 1282 RVA: 0x0002B10C File Offset: 0x0002930C
    private static void gmBoss5LdPartUpdateSpin( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ldpart_work);
        AppMain.nnMultiplyQuaternion( ref ldpart_work.cur_rot_quat, ref ldpart_work.rot_diff_quat, ref ldpart_work.cur_rot_quat );
        AppMain.nnMakeQuaternionMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, ref ldpart_work.cur_rot_quat );
        obs_OBJECT_WORK.disp_flag |= 16777216U;
    }

    // Token: 0x06000503 RID: 1283 RVA: 0x0002B160 File Offset: 0x00029360
    private static void gmBoss5LdPartInitFall( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ldpart_work);
        int num = (int)AppMain.mtMathRand() % AppMain.GMD_BOSS5_LAND_LDPART_FALL_XY_DIR_RANGE_DEG;
        int ang = AppMain.AKM_DEGtoA32(num + (270 - AppMain.GMD_BOSS5_LAND_LDPART_FALL_XY_DIR_RANGE_DEG / 2));
        int z = AppMain.FX_Mul(AppMain.AkMathRandFx(), AppMain.GMD_BOSS5_LAND_LDPART_FALL_Z_SPD_MAX * 2) - AppMain.GMD_BOSS5_LAND_LDPART_FALL_Z_SPD_MAX;
        obs_OBJECT_WORK.spd.y = ( int )( 4096f * AppMain.GMD_BOSS5_LAND_LDPART_FALL_XY_SPD_FL * AppMain.nnSin( ang ) );
        obs_OBJECT_WORK.spd.x = ( int )( 4096f * AppMain.GMD_BOSS5_LAND_LDPART_FALL_XY_SPD_FL * AppMain.nnCos( ang ) );
        obs_OBJECT_WORK.spd.z = z;
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.move_flag |= 128U;
    }

    // Token: 0x06000504 RID: 1284 RVA: 0x0002B21C File Offset: 0x0002941C
    private static void gmBoss5LdPartInitVib( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        ldpart_work.vib_cnt = ( int )( AppMain.mtMathRand() % 40 );
        ldpart_work.vib_ofst[0] = ( ldpart_work.vib_ofst[1] = 0 );
    }

    // Token: 0x06000505 RID: 1285 RVA: 0x0002B24C File Offset: 0x0002944C
    private static void gmBoss5LdPartUpdateVib( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        ldpart_work.vib_ofst[0] = AppMain.FX_Mul( AppMain.gm_boss5_land_vib_tbl[ldpart_work.vib_cnt][0], AppMain.GMD_BOSS5_LAND_LDPART_VIB_AMPLITUDE );
        ldpart_work.vib_ofst[1] = AppMain.FX_Mul( AppMain.gm_boss5_land_vib_tbl[ldpart_work.vib_cnt][1], AppMain.GMD_BOSS5_LAND_LDPART_VIB_AMPLITUDE );
        ldpart_work.vib_cnt++;
        if ( ldpart_work.vib_cnt >= 40 )
        {
            ldpart_work.vib_cnt = 0;
        }
    }

    // Token: 0x06000506 RID: 1286 RVA: 0x0002B2B8 File Offset: 0x000294B8
    private static void gmBoss5LdPartClearVib( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        ldpart_work.vib_cnt = 0;
        ldpart_work.vib_ofst[0] = ( ldpart_work.vib_ofst[1] = 0 );
    }

    // Token: 0x06000507 RID: 1287 RVA: 0x0002B2E0 File Offset: 0x000294E0
    private static void gmBoss5LdPartMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_LDPART_WORK gms_BOSS5_LDPART_WORK = (AppMain.GMS_BOSS5_LDPART_WORK)obj_work;
        obj_work.parent_ofst.x = gms_BOSS5_LDPART_WORK.pivot_parent_ofst[0] + gms_BOSS5_LDPART_WORK.vib_ofst[0];
        obj_work.parent_ofst.y = gms_BOSS5_LDPART_WORK.pivot_parent_ofst[1] + gms_BOSS5_LDPART_WORK.vib_ofst[1];
        if ( gms_BOSS5_LDPART_WORK.proc_update != null )
        {
            gms_BOSS5_LDPART_WORK.proc_update( gms_BOSS5_LDPART_WORK );
        }
    }

    // Token: 0x06000508 RID: 1288 RVA: 0x0002B340 File Offset: 0x00029540
    private static void gmBoss5LdPartProcInit( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ldpart_work);
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.disp_flag |= 4U;
        ldpart_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_LDPART_WORK( AppMain.gmBoss5LdPartProcUpdateIdle );
    }

    // Token: 0x06000509 RID: 1289 RVA: 0x0002B37C File Offset: 0x0002957C
    private static void gmBoss5LdPartProcUpdateIdle( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ldpart_work);
        AppMain.GMS_BOSS5_LAND_WORK gms_BOSS5_LAND_WORK = (AppMain.GMS_BOSS5_LAND_WORK)obs_OBJECT_WORK.parent_obj;
        if ( ( gms_BOSS5_LAND_WORK.flag & AppMain.GMD_BOSS5_LAND_FLAG_SHAKE_ACTIVE ) != 0U )
        {
            AppMain.gmBoss5LdPartInitVib( ldpart_work );
            ldpart_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_LDPART_WORK( AppMain.gmBoss5LdPartProcUpdateShake );
        }
    }

    // Token: 0x0600050A RID: 1290 RVA: 0x0002B3C4 File Offset: 0x000295C4
    private static void gmBoss5LdPartProcUpdateShake( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ldpart_work);
        AppMain.GMS_BOSS5_LAND_WORK gms_BOSS5_LAND_WORK = (AppMain.GMS_BOSS5_LAND_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.gmBoss5LdPartUpdateVib( ldpart_work );
        if ( ( gms_BOSS5_LAND_WORK.flag & AppMain.GMD_BOSS5_LAND_FLAG_BREAK_ACTIVE ) != 0U )
        {
            AppMain.gmBoss5LdPartClearVib( ldpart_work );
            AppMain.gmBoss5LdPartInitSpin( ldpart_work );
            AppMain.gmBoss5LdPartInitFall( ldpart_work );
            ldpart_work.wait_timer = ( uint )( ldpart_work.part_index & 1 );
            ldpart_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_LDPART_WORK( AppMain.gmBoss5LdPartProcUpdateFall );
        }
    }

    // Token: 0x0600050B RID: 1291 RVA: 0x0002B42C File Offset: 0x0002962C
    private static void gmBoss5LdPartProcUpdateFall( AppMain.GMS_BOSS5_LDPART_WORK ldpart_work )
    {
        if ( ldpart_work.wait_timer != 0U )
        {
            ldpart_work.wait_timer -= 1U;
        }
        else if ( ldpart_work.brk_glass_cnt == 0U )
        {
            AppMain.GmBoss5EfctCreateBreakingGlass( AppMain.GMM_BS_OBJ( ldpart_work ) );
            ldpart_work.brk_glass_cnt += 1U;
        }
        AppMain.gmBoss5LdPartUpdateSpin( ldpart_work );
    }

    // Token: 0x0600050C RID: 1292 RVA: 0x0002B478 File Offset: 0x00029678
    private static void GmBoss5LandSetLight()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = 0f;
        nns_VECTOR.y = -0.2f;
        nns_VECTOR.z = -1f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_1, ref nns_RGBA, 1f, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }
}