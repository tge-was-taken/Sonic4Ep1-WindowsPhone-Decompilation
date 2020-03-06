using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200024F RID: 591
    public class GMS_BOSS5_TURRET_SEQ_VUL_SHOT_INFO
    {
        // Token: 0x060023C1 RID: 9153 RVA: 0x001496E7 File Offset: 0x001478E7
        public GMS_BOSS5_TURRET_SEQ_VUL_SHOT_INFO( int a, uint b, int c )
        {
            this.life_threshold = a;
            this.wait_time = b;
            this.shot_num = c;
        }

        // Token: 0x04005886 RID: 22662
        public int life_threshold;

        // Token: 0x04005887 RID: 22663
        public uint wait_time;

        // Token: 0x04005888 RID: 22664
        public int shot_num;
    }

    // Token: 0x02000250 RID: 592
    public class GMS_BOSS5_TURRET_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023C2 RID: 9154 RVA: 0x00149704 File Offset: 0x00147904
        public GMS_BOSS5_TURRET_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023C3 RID: 9155 RVA: 0x0014973C File Offset: 0x0014793C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04005889 RID: 22665
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x0400588A RID: 22666
        public AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK proc_update;

        // Token: 0x0400588B RID: 22667
        public uint flag;

        // Token: 0x0400588C RID: 22668
        public uint wait_timer;

        // Token: 0x0400588D RID: 22669
        public int fire_dir_z;

        // Token: 0x0400588E RID: 22670
        public AppMain.NNS_QUATERNION disp_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x0400588F RID: 22671
        public int trt_slide_type;

        // Token: 0x04005890 RID: 22672
        public float trt_slide_length;

        // Token: 0x04005891 RID: 22673
        public int cvr_slide_type;

        // Token: 0x04005892 RID: 22674
        public float cvr_slide_ratio;

        // Token: 0x04005893 RID: 22675
        public int vul_shot_remain;

        // Token: 0x04005894 RID: 22676
        public int vul_burst_timer;

        // Token: 0x04005895 RID: 22677
        public int vul_shot_angle;

        // Token: 0x04005896 RID: 22678
        public AppMain.VecFx32 vul_fire_pos = default(AppMain.VecFx32);

        // Token: 0x04005897 RID: 22679
        public AppMain.VecFx32 vul_bullet_pos = default(AppMain.VecFx32);
    }

    // Token: 0x06000E68 RID: 3688 RVA: 0x00080E60 File Offset: 0x0007F060
    public static AppMain.OBS_OBJECT_WORK GmBoss5TurretInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_TURRET_WORK(), "BOSS5_TRT");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS5_TURRET_WORK trt_work = (AppMain.GMS_BOSS5_TURRET_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss5GetObject3dList()[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = AppMain.GMD_BOSS5_DEFAULT_BLEND_SPD;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 256U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.gmBoss5TurretInitDispRot( trt_work );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5TurretMain );
        AppMain.gmBoss5TurretProcInit( trt_work );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000E69 RID: 3689 RVA: 0x00080F6C File Offset: 0x0007F16C
    public static AppMain.GMS_BOSS5_TURRET_WORK GmBoss5TurretStartUp( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(333, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        return ( AppMain.GMS_BOSS5_TURRET_WORK )obs_OBJECT_WORK2;
    }

    // Token: 0x06000E6A RID: 3690 RVA: 0x00080FB4 File Offset: 0x0007F1B4
    public static void gmBoss5TurretGetDispRotatedOfstPos( AppMain.GMS_BOSS5_TURRET_WORK trt_work, ref AppMain.VecFx32 src_ofst_pos, out AppMain.VecFx32 dest_ofst_pos )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, AppMain.FX_FX32_TO_F32( src_ofst_pos.x ), AppMain.FX_FX32_TO_F32( -src_ofst_pos.y ), AppMain.FX_FX32_TO_F32( src_ofst_pos.z ) );
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX, ref trt_work.disp_quat );
        AppMain.nnTransformVector( nns_VECTOR, nns_MATRIX, nns_VECTOR );
        dest_ofst_pos = new AppMain.VecFx32( AppMain.FX_F32_TO_FX32( nns_VECTOR.x ), AppMain.FX_F32_TO_FX32( -nns_VECTOR.y ), AppMain.FX_F32_TO_FX32( nns_VECTOR.z ) );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000E6B RID: 3691 RVA: 0x00081044 File Offset: 0x0007F244
    public static void gmBoss5TurretGetVulcanFirePos( AppMain.GMS_BOSS5_TURRET_WORK trt_work, ref AppMain.VecFx32 out_pos )
    {
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(0, 0, AppMain.GMD_BOSS5_TURRET_VULCAN_FIRE_OFST_FORWARD);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(trt_work);
        AppMain.VecFx32 vecFx2;
        AppMain.gmBoss5TurretGetDispRotatedOfstPos( trt_work, ref vecFx, out vecFx2 );
        AppMain.VEC_Set( ref out_pos, obs_OBJECT_WORK.pos.x + vecFx2.x, obs_OBJECT_WORK.pos.y + vecFx2.y, obs_OBJECT_WORK.pos.z + AppMain.GMD_BOSS5_TURRET_VULCAN_FIRE_OFST_Z );
    }

    // Token: 0x06000E6C RID: 3692 RVA: 0x000810B4 File Offset: 0x0007F2B4
    public static void gmBoss5TurretGetVulcanBulletPos( AppMain.GMS_BOSS5_TURRET_WORK trt_work, ref AppMain.VecFx32 out_pos )
    {
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(0, 0, AppMain.GMD_BOSS5_TURRET_VULCAN_BULLET_OFST_FORWARD);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(trt_work);
        AppMain.VecFx32 vecFx2;
        AppMain.gmBoss5TurretGetDispRotatedOfstPos( trt_work, ref vecFx, out vecFx2 );
        AppMain.VEC_Set( ref out_pos, obs_OBJECT_WORK.pos.x + vecFx2.x, obs_OBJECT_WORK.pos.y + vecFx2.y, obs_OBJECT_WORK.pos.z + AppMain.GMD_BOSS5_TURRET_VULCAN_BULLET_OFST_Z );
    }

    // Token: 0x06000E6D RID: 3693 RVA: 0x00081124 File Offset: 0x0007F324
    public static void gmBoss5TurretInitDispRot( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(trt_work);
        obs_OBJECT_WORK.disp_flag &= 4278190079U;
        AppMain.nnMakeUnitQuaternion( ref trt_work.disp_quat );
        AppMain.nnMakeUnitMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r );
    }

    // Token: 0x06000E6E RID: 3694 RVA: 0x00081168 File Offset: 0x0007F368
    public static void gmBoss5TurretUpdateDispRot( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(trt_work);
        obs_OBJECT_WORK.disp_flag |= 16777216U;
        AppMain.nnMakeQuaternionMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, ref trt_work.disp_quat );
    }

    // Token: 0x06000E6F RID: 3695 RVA: 0x000811A4 File Offset: 0x0007F3A4
    public static void gmBoss5TurretUpdateDirFollowingPos( AppMain.GMS_BOSS5_TURRET_WORK trt_work, ref AppMain.VecFx32 targ_pos, float deg )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(trt_work);
        int num = (int)(65535L & (long)AppMain.nnArcTan2((double)AppMain.FX_FX32_TO_F32(targ_pos.y - obs_OBJECT_WORK.pos.y), (double)AppMain.FX_FX32_TO_F32(targ_pos.x - obs_OBJECT_WORK.pos.x)));
        int num2 = (int)(65535L & (long)(num - trt_work.fire_dir_z));
        int num3;
        if ( num2 >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            num2 = -( AppMain.AKM_DEGtoA32( 360 ) - num2 );
            num3 = AppMain.AKM_DEGtoA32( -deg );
        }
        else
        {
            num3 = AppMain.AKM_DEGtoA32( deg );
        }
        if ( AppMain.MTM_MATH_ABS( num2 ) <= AppMain.MTM_MATH_ABS( num3 ) )
        {
            num3 = num2;
        }
        trt_work.fire_dir_z = ( int )( ( short )( 65535L & ( long )( trt_work.fire_dir_z + num3 ) ) );
    }

    // Token: 0x06000E70 RID: 3696 RVA: 0x0008125C File Offset: 0x0007F45C
    public static void gmBoss5TurretSetRoundFaceRot( AppMain.GMS_BOSS5_TURRET_WORK trt_work, int dir_z_angle, int tilt_near_angle )
    {
        int rz = (int)(65535L & (long)(-(long)dir_z_angle));
        AppMain.nnMakeRotateXZYQuaternion( out trt_work.disp_quat, AppMain.AKM_DEGtoA32( 90 ), -tilt_near_angle, AppMain.AKM_DEGtoA32( 90 ) );
        AppMain.NNS_QUATERNION nns_QUATERNION;
        AppMain.nnMakeRotateXYZQuaternion( out nns_QUATERNION, 0, 0, rz );
        AppMain.nnMultiplyQuaternion( ref trt_work.disp_quat, ref nns_QUATERNION, ref trt_work.disp_quat );
    }

    // Token: 0x06000E71 RID: 3697 RVA: 0x000812B0 File Offset: 0x0007F4B0
    public static void gmBoss5TurretUpdateDirFacePly( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.gmBoss5TurretUpdateDirFollowingPos( trt_work, ref obs_OBJECT_WORK.pos, AppMain.GMD_BOSS5_TURRET_FACE_PLY_SPD_DEG );
        float num = AppMain.nnSin(trt_work.fire_dir_z);
        if ( num < 0f )
        {
            num = 0f;
        }
        int tilt_near_angle = (int)(num * (float)(65535L & (long)AppMain.GMD_BOSS5_TURRET_TILT_NEAR_ANGLE));
        AppMain.gmBoss5TurretSetRoundFaceRot( trt_work, trt_work.fire_dir_z, tilt_near_angle );
    }

    // Token: 0x06000E72 RID: 3698 RVA: 0x0008130D File Offset: 0x0007F50D
    public static void gmBoss5TurretInitVulcanBurstShot( AppMain.GMS_BOSS5_TURRET_WORK trt_work, int shot_num )
    {
        trt_work.vul_shot_remain = shot_num;
        trt_work.vul_burst_timer = AppMain.GMD_BOSS5_TURRET_VULCAN_SHOT_INTERVAL;
        trt_work.vul_shot_angle = trt_work.fire_dir_z;
        AppMain.gmBoss5TurretGetVulcanFirePos( trt_work, ref trt_work.vul_fire_pos );
        AppMain.gmBoss5TurretGetVulcanBulletPos( trt_work, ref trt_work.vul_bullet_pos );
    }

    // Token: 0x06000E73 RID: 3699 RVA: 0x00081348 File Offset: 0x0007F548
    public static int gmBoss5TurretUpdateVulcanBurstShot( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        if ( trt_work.vul_shot_remain != 0 )
        {
            if ( trt_work.vul_burst_timer != 0 )
            {
                trt_work.vul_burst_timer--;
            }
            else
            {
                AppMain.gmBoss5TurretGetVulcanFirePos( trt_work, ref trt_work.vul_fire_pos );
                AppMain.gmBoss5TurretGetVulcanBulletPos( trt_work, ref trt_work.vul_bullet_pos );
                AppMain.GmBoss5EfctCreateVulcanFire( trt_work, trt_work.vul_fire_pos, trt_work.vul_shot_angle );
                AppMain.GmBoss5EfctCreateVulcanBullet( trt_work, trt_work.vul_bullet_pos, trt_work.vul_shot_angle, AppMain.GMD_BOSS5_TURRET_VULCAN_BULLET_SPD );
                trt_work.vul_shot_remain--;
                trt_work.vul_burst_timer = AppMain.GMD_BOSS5_TURRET_VULCAN_SHOT_INTERVAL;
            }
            return 0;
        }
        return 1;
    }

    // Token: 0x06000E74 RID: 3700 RVA: 0x000813D4 File Offset: 0x0007F5D4
    public static void gmBoss5TurretClearVulcanBurstShot( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        trt_work.vul_shot_remain = 0;
        trt_work.vul_burst_timer = 0;
    }

    // Token: 0x06000E75 RID: 3701 RVA: 0x000813E4 File Offset: 0x0007F5E4
    public static void gmBoss5TurretInitPartsPose( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        int[] array = new int[]
        {
            gms_BOSS5_BODY_WORK.pole_cnm_reg_id,
            gms_BOSS5_BODY_WORK.cover_cnm_reg_id
        };
        int num = 2;
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        for ( int i = 0; i < num; i++ )
        {
            AppMain.GmBsCmnChangeCNMModeNode( gms_BOSS5_BODY_WORK.cnm_mgr_work, array[i], 1U );
            AppMain.GmBsCmnEnableCNMLocalCoordinate( gms_BOSS5_BODY_WORK.cnm_mgr_work, array[i], 1 );
            AppMain.GmBsCmnEnableCNMMtxNode( gms_BOSS5_BODY_WORK.cnm_mgr_work, array[i], 1 );
            AppMain.GmBsCmnSetCNMMtx( gms_BOSS5_BODY_WORK.cnm_mgr_work, nns_MATRIX, array[i] );
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000E76 RID: 3702 RVA: 0x00081488 File Offset: 0x0007F688
    public static void gmBoss5TurretEndPartsPose( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        int[] array = new int[]
        {
            gms_BOSS5_BODY_WORK.pole_cnm_reg_id,
            gms_BOSS5_BODY_WORK.cover_cnm_reg_id
        };
        int num = 2;
        for ( int i = 0; i < num; i++ )
        {
            AppMain.GmBsCmnEnableCNMMtxNode( gms_BOSS5_BODY_WORK.cnm_mgr_work, array[i], 0 );
        }
    }

    // Token: 0x06000E77 RID: 3703 RVA: 0x000814E2 File Offset: 0x0007F6E2
    public static void gmBoss5TurretInitSlideTurret( AppMain.GMS_BOSS5_TURRET_WORK trt_work, int slide_type )
    {
        trt_work.trt_slide_type = slide_type;
        if ( slide_type == 0 )
        {
            trt_work.trt_slide_length = 0f;
            return;
        }
        trt_work.trt_slide_length = AppMain.GMD_BOSS5_TURRET_SLIDE_LENGTH_MAX;
    }

    // Token: 0x06000E78 RID: 3704 RVA: 0x00081508 File Offset: 0x0007F708
    public static int gmBoss5TurretUpdateSlideTurret( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        int result;
        if ( trt_work.trt_slide_type == 0 )
        {
            if ( trt_work.trt_slide_length < AppMain.GMD_BOSS5_TURRET_SLIDE_LENGTH_MAX )
            {
                trt_work.trt_slide_length += AppMain.GMD_BOSS5_TURRET_SLIDE_RAISE_SPD_F;
                result = 0;
            }
            else
            {
                trt_work.trt_slide_length = AppMain.GMD_BOSS5_TURRET_SLIDE_LENGTH_MAX;
                result = 1;
            }
        }
        else if ( trt_work.trt_slide_length > 0f )
        {
            trt_work.trt_slide_length -= AppMain.GMD_BOSS5_TURRET_SLIDE_LOWER_SPD_F;
            result = 0;
        }
        else
        {
            trt_work.trt_slide_length = 0f;
            result = 1;
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeTranslateMatrix( nns_MATRIX, 0f, trt_work.trt_slide_length + AppMain.GMD_BOSS5_TURRET_SLIDE_POLE_DISP_OFST_Y, 0f );
        AppMain.GmBsCmnSetCNMMtx( gms_BOSS5_BODY_WORK.cnm_mgr_work, nns_MATRIX, gms_BOSS5_BODY_WORK.pole_cnm_reg_id );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        return result;
    }

    // Token: 0x06000E79 RID: 3705 RVA: 0x000815CB File Offset: 0x0007F7CB
    public static void gmBoss5TurretInitSlideCover( AppMain.GMS_BOSS5_TURRET_WORK trt_work, int slide_type )
    {
        trt_work.cvr_slide_type = slide_type;
        if ( slide_type == 0 )
        {
            trt_work.cvr_slide_ratio = 0f;
            return;
        }
        trt_work.cvr_slide_ratio = 1f;
    }

    // Token: 0x06000E7A RID: 3706 RVA: 0x000815F0 File Offset: 0x0007F7F0
    public static int gmBoss5TurretUpdateSlideCover( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        int result;
        if ( trt_work.cvr_slide_type == 0 )
        {
            if ( trt_work.cvr_slide_ratio < 1f )
            {
                trt_work.cvr_slide_ratio += AppMain.GMD_BOSS5_TURRET_COVER_SLIDE_OPEN_RATIO_SPD_F;
                result = 0;
            }
            else
            {
                trt_work.cvr_slide_ratio = 1f;
                result = 1;
            }
        }
        else if ( trt_work.cvr_slide_ratio > 0f )
        {
            trt_work.cvr_slide_ratio -= AppMain.GMD_BOSS5_TURRET_COVER_SLIDE_CLOSE_RATIO_SPD_F;
            result = 0;
        }
        else
        {
            trt_work.cvr_slide_ratio = 0f;
            result = 1;
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        float num = 1f + trt_work.cvr_slide_ratio * (AppMain.GMD_BOSS5_TURRET_COVER_SLIDE_SCALE_MAX - 1f);
        AppMain.nnMakeRotateXMatrix( nns_MATRIX, AppMain.AKM_DEGtoA32( trt_work.cvr_slide_ratio * AppMain.GMD_BOSS5_TURRET_COVER_SLIDE_DEG_MAX ) );
        AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, num, num, num );
        AppMain.GmBsCmnSetCNMMtx( gms_BOSS5_BODY_WORK.cnm_mgr_work, nns_MATRIX, gms_BOSS5_BODY_WORK.cover_cnm_reg_id );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        return result;
    }

    // Token: 0x06000E7B RID: 3707 RVA: 0x000816D4 File Offset: 0x0007F8D4
    public static void gmBoss5TurretMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_TURRET_WORK gms_BOSS5_TURRET_WORK = (AppMain.GMS_BOSS5_TURRET_WORK)obj_work;
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmBoss5TurretMain_trt_ofst;
        if ( gms_BOSS5_TURRET_WORK.proc_update != null )
        {
            gms_BOSS5_TURRET_WORK.proc_update( gms_BOSS5_TURRET_WORK );
        }
        AppMain.nnMakeTranslateMatrix( nns_MATRIX, 0f, gms_BOSS5_TURRET_WORK.trt_slide_length, 0f );
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNodeRelative( obj_work, gms_BOSS5_BODY_WORK.snm_work, gms_BOSS5_BODY_WORK.pole_snm_reg_id, 0, obj_work.parent_obj.pos, gms_BOSS5_BODY_WORK.pivot_prev_pos, nns_MATRIX );
        AppMain.gmBoss5TurretUpdateDispRot( gms_BOSS5_TURRET_WORK );
    }

    // Token: 0x06000E7C RID: 3708 RVA: 0x0008174F File Offset: 0x0007F94F
    public static void gmBoss5TurretProcInit( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateStandby );
    }

    // Token: 0x06000E7D RID: 3709 RVA: 0x00081764 File Offset: 0x0007F964
    public static void gmBoss5TurretProcUpdateStandby( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        if ( ( gms_BOSS5_BODY_WORK.flag & 512U ) != 0U || AppMain.gmBoss5TurretSeqGetVulcanShotNum( trt_work ) <= 0 )
        {
            return;
        }
        if ( trt_work.wait_timer != 0U )
        {
            trt_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5TurretInitPartsPose( trt_work );
        AppMain.gmBoss5TurretInitSlideCover( trt_work, 0 );
        AppMain.gmBoss5TurretUpdateDirFollowingPos( trt_work, ref AppMain.GmBsCmnGetPlayerObj().pos, 360f );
        trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateOpen );
    }

    // Token: 0x06000E7E RID: 3710 RVA: 0x000817E5 File Offset: 0x0007F9E5
    public static void gmBoss5TurretProcUpdateOpen( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        if ( AppMain.gmBoss5TurretUpdateSlideCover( trt_work ) != 0 )
        {
            AppMain.gmBoss5TurretInitSlideTurret( trt_work, 0 );
            trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateAppear );
        }
    }

    // Token: 0x06000E7F RID: 3711 RVA: 0x00081808 File Offset: 0x0007FA08
    public static void gmBoss5TurretProcUpdateAppear( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.gmBoss5TurretUpdateDirFacePly( trt_work );
        if ( AppMain.gmBoss5TurretUpdateSlideTurret( trt_work ) != 0 )
        {
            trt_work.wait_timer = AppMain.GMD_BOSS5_TURRET_FACE_TIME;
            trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateFace );
        }
    }

    // Token: 0x06000E80 RID: 3712 RVA: 0x00081838 File Offset: 0x0007FA38
    public static void gmBoss5TurretProcUpdateFace( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        AppMain.gmBoss5TurretUpdateDirFacePly( trt_work );
        if ( ( gms_BOSS5_BODY_WORK.flag & 512U ) != 0U )
        {
            trt_work.wait_timer = 0U;
            trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateDisappear );
            return;
        }
        if ( trt_work.wait_timer != 0U )
        {
            trt_work.wait_timer -= 1U;
            return;
        }
        AppMain.gmBoss5TurretInitVulcanBurstShot( trt_work, AppMain.gmBoss5TurretSeqGetVulcanShotNum( trt_work ) );
        trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateFire );
    }

    // Token: 0x06000E81 RID: 3713 RVA: 0x000818BC File Offset: 0x0007FABC
    public static void gmBoss5TurretProcUpdateFire( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        if ( AppMain.gmBoss5TurretUpdateVulcanBurstShot( trt_work ) != 0 || ( gms_BOSS5_BODY_WORK.flag & 512U ) != 0U )
        {
            AppMain.gmBoss5TurretClearVulcanBurstShot( trt_work );
            AppMain.gmBoss5TurretInitSlideTurret( trt_work, 1 );
            trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateDisappear );
        }
    }

    // Token: 0x06000E82 RID: 3714 RVA: 0x0008190F File Offset: 0x0007FB0F
    public static void gmBoss5TurretProcUpdateDisappear( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        if ( AppMain.gmBoss5TurretUpdateSlideTurret( trt_work ) != 0 )
        {
            trt_work.wait_timer = AppMain.gmBoss5TurretSeqGetVulcanWaitTime( trt_work );
            AppMain.gmBoss5TurretInitSlideCover( trt_work, 1 );
            trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateClose );
        }
    }

    // Token: 0x06000E83 RID: 3715 RVA: 0x0008193E File Offset: 0x0007FB3E
    public static void gmBoss5TurretProcUpdateClose( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        if ( AppMain.gmBoss5TurretUpdateSlideCover( trt_work ) != 0 )
        {
            AppMain.gmBoss5TurretEndPartsPose( trt_work );
            trt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.gmBoss5TurretProcUpdateStandby );
        }
    }

    // Token: 0x06000E84 RID: 3716 RVA: 0x00081960 File Offset: 0x0007FB60
    public static uint gmBoss5TurretSeqGetVulcanWaitTime( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        int life = gms_BOSS5_BODY_WORK.mgr_work.life;
        AppMain.GMS_BOSS5_TURRET_SEQ_VUL_SHOT_INFO gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO = null;
        for ( int i = 0; i < 5; i++ )
        {
            if ( life <= AppMain.gm_boss5_trt_seq_vul_shot_info_tbl[i].life_threshold )
            {
                gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO = AppMain.gm_boss5_trt_seq_vul_shot_info_tbl[i];
                break;
            }
        }
        if ( gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO == null )
        {
            return 0U;
        }
        return gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO.wait_time;
    }

    // Token: 0x06000E85 RID: 3717 RVA: 0x000819BC File Offset: 0x0007FBBC
    public static int gmBoss5TurretSeqGetVulcanShotNum( AppMain.GMS_BOSS5_TURRET_WORK trt_work )
    {
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)AppMain.GMM_BS_OBJ(trt_work).parent_obj;
        int life = gms_BOSS5_BODY_WORK.mgr_work.life;
        AppMain.GMS_BOSS5_TURRET_SEQ_VUL_SHOT_INFO gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO = null;
        for ( int i = 0; i < 5; i++ )
        {
            if ( life <= AppMain.gm_boss5_trt_seq_vul_shot_info_tbl[i].life_threshold )
            {
                gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO = AppMain.gm_boss5_trt_seq_vul_shot_info_tbl[i];
                break;
            }
        }
        if ( gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO == null )
        {
            return 0;
        }
        return gms_BOSS5_TURRET_SEQ_VUL_SHOT_INFO.shot_num;
    }
}
