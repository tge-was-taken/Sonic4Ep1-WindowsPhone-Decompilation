using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x17000019 RID: 25
    // (get) Token: 0x0600070F RID: 1807 RVA: 0x0003EDF0 File Offset: 0x0003CFF0
    public static float GMD_BOSS4_CAP_ROTATE_SPD
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 6f );
        }
    }

    // Token: 0x1700001A RID: 26
    // (get) Token: 0x06000710 RID: 1808 RVA: 0x0003EDFC File Offset: 0x0003CFFC
    public static int GMD_BOSS4_CAP_ZOOM_TIME
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 270f );
        }
    }

    // Token: 0x1700001B RID: 27
    // (get) Token: 0x06000711 RID: 1809 RVA: 0x0003EE08 File Offset: 0x0003D008
    public static int GMD_BOSS4_CAP_ZOOM_TIME_RAND
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 60f );
        }
    }

    // Token: 0x06000712 RID: 1810 RVA: 0x0003EE14 File Offset: 0x0003D014
    public static void T_FUNC( AppMain.MPP_VOID_OBS_OBJECT_WORK func, AppMain.OBS_OBJECT_WORK w )
    {
        w.ppFunc = func;
    }

    // Token: 0x06000713 RID: 1811 RVA: 0x0003EE1D File Offset: 0x0003D01D
    public static void SET_FLAG( uint f, AppMain.GMS_BOSS4_CAP_WORK w )
    {
        w.flag |= f;
    }

    // Token: 0x06000714 RID: 1812 RVA: 0x0003EE2D File Offset: 0x0003D02D
    public static void RESET_FLAG( uint f, AppMain.GMS_BOSS4_CAP_WORK w )
    {
        w.flag &= ~f;
    }

    // Token: 0x06000715 RID: 1813 RVA: 0x0003EE3E File Offset: 0x0003D03E
    public static bool IS_FLAG( uint f, AppMain.GMS_BOSS4_CAP_WORK w )
    {
        return 0U != ( w.flag & f );
    }

    // Token: 0x06000716 RID: 1814 RVA: 0x0003EE4E File Offset: 0x0003D04E
    private static void GmBoss4CapsuleBuild()
    {
        AppMain._cap_no = 0;
        AppMain._cap_count = 0;
        AppMain._cap_inv_flag = 0;
        AppMain._cap_inv_hit = true;
        AppMain._cap_kill_flag = 0;
    }

    // Token: 0x06000717 RID: 1815 RVA: 0x0003EE6E File Offset: 0x0003D06E
    private static void GmBoss4CapsuleFlush()
    {
    }

    // Token: 0x06000718 RID: 1816 RVA: 0x0003EE70 File Offset: 0x0003D070
    private static AppMain.OBS_OBJECT_WORK GmBoss4CapsuleInit1st( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4CapsuleInit( eve_rec, pos_x, pos_y, 0 );
    }

    // Token: 0x06000719 RID: 1817 RVA: 0x0003EE86 File Offset: 0x0003D086
    private static AppMain.OBS_OBJECT_WORK GmBoss4CapsuleInit2nd( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4CapsuleInit( eve_rec, pos_x, pos_y, 1 );
    }

    // Token: 0x0600071A RID: 1818 RVA: 0x0003EE9C File Offset: 0x0003D09C
    private static void GmBoss4CapsuleSetInvincible( int inv )
    {
        AppMain.GmBoss4CapsuleSetInvincible( inv, true );
    }

    // Token: 0x0600071B RID: 1819 RVA: 0x0003EEA5 File Offset: 0x0003D0A5
    private static void GmBoss4CapsuleSetInvincible( int count, bool hit )
    {
        AppMain._cap_inv_flag = count;
        AppMain._cap_inv_hit = hit;
    }

    // Token: 0x0600071C RID: 1820 RVA: 0x0003EEB3 File Offset: 0x0003D0B3
    private static int GmBoss4CapsuleGetCount()
    {
        return AppMain._cap_count;
    }

    // Token: 0x0600071D RID: 1821 RVA: 0x0003EEBA File Offset: 0x0003D0BA
    private static void GmBoss4CapsuleClear()
    {
        AppMain._cap_count = 0;
    }

    // Token: 0x0600071E RID: 1822 RVA: 0x0003EEC2 File Offset: 0x0003D0C2
    private static void GmBoss4CapsuleExplosion()
    {
        AppMain._cap_kill_flag = 1;
    }

    // Token: 0x0600071F RID: 1823 RVA: 0x0003EED4 File Offset: 0x0003D0D4
    private static AppMain.OBS_OBJECT_WORK GmBoss4CapsuleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain._cap_kill_flag = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS4_CAP_WORK(), "BOSS4_CAP");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS4_CAP_WORK gms_BOSS4_CAP_WORK = (AppMain.GMS_BOSS4_CAP_WORK)obs_OBJECT_WORK;
        gms_BOSS4_CAP_WORK.cap_no = AppMain._cap_no++ % 6;
        gms_BOSS4_CAP_WORK.type = type;
        obs_OBJECT_WORK.move_flag |= 256U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 2 ), gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[0], -14, -30, 14, -2 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4CapsuleDamageDefFunc );
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[1], -1, -9, 1, -7 );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4CapsuleAtkHitFunc );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4CapsuleWaitLoad ), obs_OBJECT_WORK );
        if ( gms_BOSS4_CAP_WORK.chibi_type == 4 )
        {
            obs_OBJECT_WORK.disp_flag |= 32U;
        }
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss4CapsuleExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000720 RID: 1824 RVA: 0x0003F0C0 File Offset: 0x0003D2C0
    private static void GmBoss4CapsuleUpdateRol( float spd )
    {
        AppMain._cap_rot_y += AppMain.AKM_DEGtoA32( spd );
        AppMain._cap_rot_y %= AppMain.AKM_DEGtoA32( 360 );
        if ( AppMain._cap_rot_z_flag != 0 )
        {
            AppMain._cap_rot_z += AppMain.AKM_DEGtoA32( 1f );
            if ( AppMain._cap_rot_z >= AppMain.AKM_DEGtoA32( 45f ) )
            {
                AppMain._cap_rot_z_flag = 0;
            }
        }
        else
        {
            AppMain._cap_rot_z -= AppMain.AKM_DEGtoA32( 1f );
            if ( AppMain._cap_rot_z <= AppMain.AKM_DEGtoA32( -45f ) )
            {
                AppMain._cap_rot_z_flag = 1;
            }
        }
        if ( AppMain._cap_rot_x_flag != 0 )
        {
            AppMain._cap_rot_x += AppMain.AKM_DEGtoA32( 0.5f );
            if ( AppMain._cap_rot_x >= AppMain.AKM_DEGtoA32( 60f ) )
            {
                AppMain._cap_rot_x_flag = 0;
            }
        }
        else
        {
            AppMain._cap_rot_x -= AppMain.AKM_DEGtoA32( 0.5f );
            if ( AppMain._cap_rot_x <= AppMain.AKM_DEGtoA32( -60f ) )
            {
                AppMain._cap_rot_x_flag = 1;
            }
        }
        if ( AppMain._cap_len_time > 0f )
        {
            AppMain._cap_len_time -= 1f;
        }
        else if ( 0f != AppMain._cap_len_flag )
        {
            AppMain._cap_len += 2f;
            if ( AppMain._cap_len >= 100f )
            {
                AppMain._cap_len_flag = 0f;
            }
        }
        else
        {
            AppMain._cap_len -= 2f;
            if ( AppMain._cap_len <= 65f )
            {
                AppMain._cap_len_flag = 1f;
                AppMain._cap_len_time = ( float )AppMain.GMD_BOSS4_CAP_ZOOM_TIME + ( float )AppMain.GMD_BOSS4_CAP_ZOOM_TIME_RAND * ( ( float )( AppMain.random.Next() % 256 ) / 256f );
            }
        }
        if ( AppMain._cap_inv_flag > 900 )
        {
            AppMain._cap_inv_flag = 0;
        }
        if ( AppMain._cap_inv_flag > 0 )
        {
            AppMain._cap_inv_flag--;
            return;
        }
        AppMain._cap_inv_flag = 0;
    }

    // Token: 0x06000721 RID: 1825 RVA: 0x0003F288 File Offset: 0x0003D488
    private static void gmBoss4CapsuleWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CAP_WORK gms_BOSS4_CAP_WORK = (AppMain.GMS_BOSS4_CAP_WORK)obj_work;
        if ( AppMain.GmBoss4IsBuilded() )
        {
            if ( gms_BOSS4_CAP_WORK.type == 0 )
            {
                AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4CapsuleMain ), obj_work );
            }
            else
            {
                obj_work.move_flag &= 4294963199U;
                obj_work.move_flag |= 128U;
                AppMain.ObjObjectFieldRectSet( obj_work, -20, -40, 20, 0 );
                obj_work.dir.y = 0;
                gms_BOSS4_CAP_WORK.chibi_type = AppMain.gmBoss4ChibiGetAttackType( AppMain.GmBoss4GetLife() );
                AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4CapsuleMain2nd ), obj_work );
                if ( gms_BOSS4_CAP_WORK.chibi_type == 4 )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(329, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
                    obs_OBJECT_WORK.spd.x = AppMain.FX_F32_TO_FX32( 2f );
                    obs_OBJECT_WORK.spd.y = AppMain.FX_F32_TO_FX32( -3f );
                    AppMain.GmBoss4IncObjCreateCount();
                    obs_OBJECT_WORK.parent_obj = obj_work.parent_obj;
                    AppMain.GMM_BS_OBJ( gms_BOSS4_CAP_WORK ).flag |= 8U;
                }
            }
            AppMain._cap_count++;
            gms_BOSS4_CAP_WORK.wait = 0;
        }
    }

    // Token: 0x06000722 RID: 1826 RVA: 0x0003F3B5 File Offset: 0x0003D5B5
    private static void gmBoss4CapsuleExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GmBoss4DecObjCreateCount();
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000723 RID: 1827 RVA: 0x0003F3C4 File Offset: 0x0003D5C4
    private static void gmBoss4CapsuleMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS4_CAP_WORK gms_BOSS4_CAP_WORK = (AppMain.GMS_BOSS4_CAP_WORK)obj_work;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        if ( gms_BOSS4_CAP_WORK.wait > 0 )
        {
            obj_work.pos.z = 131072;
            AppMain.GmBoss4UtilUpdateFlicker( obj_work, gms_BOSS4_CAP_WORK.flk_work );
            if ( AppMain.GmBoss4UtilUpdate1ShotTimer( gms_BOSS4_CAP_WORK.timer ) )
            {
                AppMain.VecFx32 pos = obj_work.pos;
                pos.z = 135168;
                AppMain.GmBoss4EffCommonInit( 735, new AppMain.VecFx32?( pos ) );
                AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4CapsuleBomb ), obj_work );
            }
        }
        else
        {
            AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, gms_BOSS4_BODY_WORK.node_work.snm_work, gms_BOSS4_BODY_WORK.node_work.work[2], 0 );
            obj_work.pos.y = obj_work.pos.y + AppMain.FX_F32_TO_FX32( 20f );
            int num = AppMain._cap_rot_y;
            num += AppMain.AKM_DEGtoA32( 360 ) / 6 * gms_BOSS4_CAP_WORK.cap_no;
            num %= AppMain.AKM_DEGtoA32( 360 );
            AppMain.nnMakeRotateXMatrix( nns_MATRIX, AppMain._cap_rot_x );
            AppMain.nnRotateZMatrix( nns_MATRIX, nns_MATRIX, AppMain._cap_rot_z );
            AppMain.nnRotateYMatrix( nns_MATRIX, nns_MATRIX, num );
            AppMain.nnMakeTranslateMatrix( nns_MATRIX2, AppMain._cap_len, 0f, 0f );
            AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX, nns_MATRIX2 );
            AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            AppMain.nnCopyMatrixTranslationVector( nns_VECTOR, nns_MATRIX3 );
            obj_work.pos.x = obj_work.pos.x + AppMain.FX_F32_TO_FX32( nns_VECTOR.x );
            obj_work.pos.y = obj_work.pos.y + AppMain.FX_F32_TO_FX32( nns_VECTOR.y );
            obj_work.pos.z = obj_work.pos.z + AppMain.FX_F32_TO_FX32( nns_VECTOR.z );
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        }
        if ( AppMain._cap_kill_flag != 0 )
        {
            AppMain.VecFx32 pos2 = obj_work.pos;
            pos2.z = 135168;
            AppMain.GmBoss4EffCommonInit( 735, new AppMain.VecFx32?( pos2 ) );
            gms_BOSS4_CAP_WORK.wait = 30;
            AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4CapsuleBomb ), obj_work );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
            return;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( AppMain._cap_inv_flag != 0 )
        {
            if ( !AppMain._cap_inv_hit )
            {
                gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag |= 2048U;
                gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
            }
            gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag |= 2048U;
        }
        else
        {
            gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294965247U;
            gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag |= 4U;
            gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294965247U;
        }
        if ( AppMain.IS_FLAG( 1073741824U, gms_BOSS4_CAP_WORK ) )
        {
            AppMain._cap_count--;
            gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
            gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
            AppMain.RESET_FLAG( 1073741824U, gms_BOSS4_CAP_WORK );
            AppMain.GmBoss4UtilInitFlicker( obj_work, gms_BOSS4_CAP_WORK.flk_work );
            AppMain.GmBoss4UtilInit1ShotTimer( gms_BOSS4_CAP_WORK.timer, 20U );
            gms_BOSS4_CAP_WORK.wait = 60;
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000724 RID: 1828 RVA: 0x0003F758 File Offset: 0x0003D958
    private static void gmBoss4CapsuleMain2nd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CAP_WORK gms_BOSS4_CAP_WORK = (AppMain.GMS_BOSS4_CAP_WORK)obj_work;
        obj_work.move_flag &= 4294443007U;
        obj_work.spd_fall = AppMain.FX_F32_TO_FX32( 0.2f );
        obj_work.move_flag |= 128U;
        obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.VecFx32 pos = obj_work.pos;
            pos.z = 135168;
            AppMain.GmBoss4EffCommonInit( 735, new AppMain.VecFx32?( pos ) );
            gms_BOSS4_CAP_WORK.wait = 30;
            obj_work.spd.x = AppMain.FX_F32_TO_FX32( 0f );
            obj_work.spd.y = AppMain.FX_F32_TO_FX32( -1f );
            obj_work.move_flag &= 4294967294U;
            obj_work.move_flag |= 256U;
            ushort id;
            switch ( gms_BOSS4_CAP_WORK.chibi_type )
            {
                default:
                    id = 326;
                    break;
                case 2:
                    id = 327;
                    break;
                case 3:
                    id = 328;
                    break;
                case 4:
                    id = 329;
                    break;
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(id, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            obs_OBJECT_WORK.parent_obj = obj_work.parent_obj;
            AppMain.GmBoss4IncObjCreateCount();
            obs_OBJECT_WORK.spd.y = AppMain.FX_F32_TO_FX32( -4f );
            obs_OBJECT_WORK.spd.x = AppMain.FX_F32_TO_FX32( -1f );
            AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4CapsuleBomb2nd ), obj_work );
        }
    }

    // Token: 0x06000725 RID: 1829 RVA: 0x0003F8F0 File Offset: 0x0003DAF0
    private static void gmBoss4CapsuleAtkHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)my_rect.parent_obj.parent_obj;
        gms_BOSS4_BODY_WORK.flag[0] |= 268435456U;
        AppMain.GmEnemyDefaultAtkFunc( my_rect, your_rect );
    }

    // Token: 0x06000726 RID: 1830 RVA: 0x0003F934 File Offset: 0x0003DB34
    private static void gmBoss4CapsuleDamageDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        AppMain.GMS_BOSS4_CAP_WORK w = (AppMain.GMS_BOSS4_CAP_WORK)parent_obj;
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)parent_obj.parent_obj;
        if ( parent_obj2 != null && 1 == parent_obj2.obj_type )
        {
            if ( AppMain._cap_inv_flag > 0 )
            {
                return;
            }
            AppMain.GmBoss4UtilSetPlayerAttackReaction( parent_obj2, parent_obj );
            AppMain.GmSoundPlaySE( "Enemy" );
            AppMain.GmBoss4CapsuleSetInvincible( 30 );
            AppMain.GmBoss4UtilInitNoHitTimer( gms_BOSS4_BODY_WORK.nohit_work, ( AppMain.GMS_ENEMY_COM_WORK )gms_BOSS4_BODY_WORK, 25 );
            if ( !AppMain.IS_FLAG( 4U, w ) )
            {
                AppMain.SET_FLAG( 1073741824U, w );
                if ( ( gms_BOSS4_BODY_WORK.flag[0] & 4096U ) == 0U )
                {
                    gms_BOSS4_BODY_WORK.flag[0] |= 2048U;
                    gms_BOSS4_BODY_WORK.avoid_timer = 90;
                }
            }
        }
    }

    // Token: 0x06000727 RID: 1831 RVA: 0x0003F9F0 File Offset: 0x0003DBF0
    private static void gmBoss4CapsuleBomb( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CAP_WORK gms_BOSS4_CAP_WORK = (AppMain.GMS_BOSS4_CAP_WORK)obj_work;
        obj_work.disp_flag |= 32U;
        if ( gms_BOSS4_CAP_WORK.wait > 0 )
        {
            gms_BOSS4_CAP_WORK.wait--;
            if ( gms_BOSS4_CAP_WORK.wait == 30 )
            {
                if ( AppMain._cap_kill_flag != 0 )
                {
                    return;
                }
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(325, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
                AppMain.GmBoss4IncObjCreateCount();
                obs_OBJECT_WORK.parent_obj = obj_work.parent_obj;
            }
            return;
        }
        AppMain.GMM_BS_OBJ( gms_BOSS4_CAP_WORK ).flag |= 8U;
    }

    // Token: 0x06000728 RID: 1832 RVA: 0x0003FA88 File Offset: 0x0003DC88
    private static void gmBoss4CapsuleBomb2nd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CAP_WORK gms_BOSS4_CAP_WORK = (AppMain.GMS_BOSS4_CAP_WORK)obj_work;
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
        }
        else
        {
            obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        }
        if ( gms_BOSS4_CAP_WORK.wait > 0 )
        {
            gms_BOSS4_CAP_WORK.wait--;
            if ( gms_BOSS4_CAP_WORK.wait < 36 )
            {
                obj_work.disp_flag |= 32U;
            }
            return;
        }
        AppMain.GMM_BS_OBJ( gms_BOSS4_CAP_WORK ).flag |= 8U;
    }
}
