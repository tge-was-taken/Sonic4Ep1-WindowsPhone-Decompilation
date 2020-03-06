using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000076 RID: 118
    public class GMS_ENE_HARO_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E30 RID: 7728 RVA: 0x00139713 File Offset: 0x00137913
        public GMS_ENE_HARO_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001E31 RID: 7729 RVA: 0x0013974A File Offset: 0x0013794A
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x0400498C RID: 18828
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x0400498D RID: 18829
        public int spd_dec;

        // Token: 0x0400498E RID: 18830
        public int spd_dec_dist;

        // Token: 0x0400498F RID: 18831
        public AppMain.VecFx32 vvv = default(AppMain.VecFx32);

        // Token: 0x04004990 RID: 18832
        public AppMain.VecFx32 vec = default(AppMain.VecFx32);

        // Token: 0x04004991 RID: 18833
        public int angle;

        // Token: 0x04004992 RID: 18834
        public int angle_add;

        // Token: 0x04004993 RID: 18835
        public int spd;

        // Token: 0x04004994 RID: 18836
        public int timer;

        // Token: 0x04004995 RID: 18837
        public int lighton;

        // Token: 0x04004996 RID: 18838
        public int targetAngle;

        // Token: 0x04004997 RID: 18839
        public readonly AppMain.GMS_ENE_NODE_MATRIX node_work = new AppMain.GMS_ENE_NODE_MATRIX();
    }

    // Token: 0x0600028B RID: 651 RVA: 0x00015283 File Offset: 0x00013483
    public static void GmEneHaroBuild()
    {
        AppMain.gm_ene_haro_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 687 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 688 ) ), 0U );
    }

    // Token: 0x0600028C RID: 652 RVA: 0x000152B0 File Offset: 0x000134B0
    public static void GmEneHaroFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(687));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_haro_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600028D RID: 653 RVA: 0x000152E4 File Offset: 0x000134E4
    public static AppMain.OBS_OBJECT_WORK GmEneHaroInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_HARO_WORK(), "ENE_HARO");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK = (AppMain.GMS_ENE_HARO_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_haro_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 689 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 655360;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -24, 11, 0 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 256U;
        if ( ( eve_rec.flag & ( ushort )AppMain.GMD_ENE_HARO_EVE_FLAG_RIGHT ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_HARO_WORK.spd_dec = ( int )AppMain.GMD_ENE_HARO_MOVE_SPD_X / ( AppMain.GMD_ENE_HARO_TURN_FRAME / 2 );
        gms_ENE_HARO_WORK.spd_dec_dist = ( int )AppMain.GMD_ENE_HARO_MOVE_SPD_X * ( AppMain.GMD_ENE_HARO_TURN_FRAME / 2 ) / 2;
        gms_ENE_HARO_WORK.vec.x = 0;
        gms_ENE_HARO_WORK.vec.y = AppMain.FX_F32_TO_FX32( 1.0 );
        gms_ENE_HARO_WORK.angle = 0;
        gms_ENE_HARO_WORK.angle_add = 0;
        gms_ENE_HARO_WORK.lighton = 0;
        AppMain.GmEneUtilInitNodeMatrix( gms_ENE_HARO_WORK.node_work, obs_OBJECT_WORK, 16 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEneHaroExit ) );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_HARO_WORK.node_work, 2 );
        AppMain.gmEneHaroWaitInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600028E RID: 654 RVA: 0x00015560 File Offset: 0x00013760
    public static void gmEneHaroExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK = (AppMain.GMS_ENE_HARO_WORK)p;
        AppMain.GmEneUtilExitNodeMatrix( gms_ENE_HARO_WORK.node_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x0600028F RID: 655 RVA: 0x0001558C File Offset: 0x0001378C
    public static int gmEneHaroGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            return int.MaxValue;
        }
        int x = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
        int x2 = gms_PLAYER_WORK.obj_work.pos.y - obj_work.pos.y;
        float num = AppMain.FX_FX32_TO_F32(x);
        float num2 = AppMain.FX_FX32_TO_F32(x2);
        return ( int )( num * num + num2 * num2 );
    }

    // Token: 0x06000290 RID: 656 RVA: 0x00015610 File Offset: 0x00013810
    public static int gmEneHaroIsPlayerLeft( AppMain.GMS_ENE_HARO_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 1024U ) != 0U )
        {
            return 1;
        }
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = obs_OBJECT_WORK.pos.x - obj_work.ene_3d_work.ene_com.obj_work.pos.x;
        vecFx.y = obs_OBJECT_WORK.pos.y - obj_work.ene_3d_work.ene_com.obj_work.pos.y;
        int num = AppMain.FX_Mul(vecFx.x, obj_work.vec.y) - AppMain.FX_Mul(vecFx.y, obj_work.vec.x);
        if ( num > 0 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06000291 RID: 657 RVA: 0x000156E8 File Offset: 0x000138E8
    public static int gmEneHaroIsPlayerCenter( AppMain.GMS_ENE_HARO_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 1024U ) != 0U )
        {
            return 1;
        }
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = obs_OBJECT_WORK.pos.x - obj_work.ene_3d_work.ene_com.obj_work.pos.x;
        vecFx.y = obs_OBJECT_WORK.pos.y - obj_work.ene_3d_work.ene_com.obj_work.pos.y;
        int num = AppMain.FX_Mul(vecFx.x, obj_work.vec.y) - AppMain.FX_Mul(vecFx.y, obj_work.vec.x);
        if ( num < AppMain.FX_F32_TO_FX32( 0.2f ) && num > -AppMain.FX_F32_TO_FX32( 0.2f ) )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000292 RID: 658 RVA: 0x000157D4 File Offset: 0x000139D4
    public static int gmEneHaroIsPlayerFront( AppMain.GMS_ENE_HARO_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 1024U ) != 0U )
        {
            return 1;
        }
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = obs_OBJECT_WORK.pos.x - obj_work.ene_3d_work.ene_com.obj_work.pos.x;
        vecFx.y = obs_OBJECT_WORK.pos.y - obj_work.ene_3d_work.ene_com.obj_work.pos.y;
        int num = AppMain.FX_Mul(vecFx.x, obj_work.vec.x) + AppMain.FX_Mul(vecFx.y, obj_work.vec.y);
        if ( num > 0 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000293 RID: 659 RVA: 0x000158AC File Offset: 0x00013AAC
    public static void gmEneHaroWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK = (AppMain.GMS_ENE_HARO_WORK)obj_work;
        AppMain.ObjDrawObjectActionSet( obj_work, 0 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHaroWaitMain );
        obj_work.move_flag &= 4294967291U;
        int num = AppMain.FX_Sqrt(AppMain.FX_Mul(gms_ENE_HARO_WORK.vec.x, gms_ENE_HARO_WORK.vec.x) + AppMain.FX_Mul(gms_ENE_HARO_WORK.vec.y, gms_ENE_HARO_WORK.vec.y));
        if ( num == 0 )
        {
            gms_ENE_HARO_WORK.vec.x = 0;
            gms_ENE_HARO_WORK.vec.y = AppMain.FX_F32_TO_FX32( 1f );
            return;
        }
        gms_ENE_HARO_WORK.vec.x = AppMain.FX_Div( gms_ENE_HARO_WORK.vec.x, num );
        gms_ENE_HARO_WORK.vec.y = AppMain.FX_Div( gms_ENE_HARO_WORK.vec.y, num );
    }

    // Token: 0x06000294 RID: 660 RVA: 0x00015998 File Offset: 0x00013B98
    public static void gmEneHaroWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.gmEneHaroGetLength2N( obj_work ) <= 10000 )
        {
            AppMain.GmSoundPlaySE( "Halogen" );
            obj_work.obj_3d.blend_spd = 0.05f;
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 1 );
            obj_work.disp_flag |= 4U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHaroWalkInit );
        }
    }

    // Token: 0x06000295 RID: 661 RVA: 0x000159F4 File Offset: 0x00013BF4
    public static void gmEneHaroWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK = (AppMain.GMS_ENE_HARO_WORK)obj_work;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHaroWalkMain );
        obj_work.move_flag &= 4294967291U;
        int num = AppMain.FX_Sqrt(AppMain.FX_Mul(gms_ENE_HARO_WORK.vec.x, gms_ENE_HARO_WORK.vec.x) + AppMain.FX_Mul(gms_ENE_HARO_WORK.vec.y, gms_ENE_HARO_WORK.vec.y));
        if ( num == 0 )
        {
            gms_ENE_HARO_WORK.vec.x = 0;
            gms_ENE_HARO_WORK.vec.y = AppMain.FX_F32_TO_FX32( 1f );
        }
        else
        {
            gms_ENE_HARO_WORK.vec.x = AppMain.FX_Div( gms_ENE_HARO_WORK.vec.x, num );
            gms_ENE_HARO_WORK.vec.y = AppMain.FX_Div( gms_ENE_HARO_WORK.vec.y, num );
        }
        gms_ENE_HARO_WORK.timer = 120;
        if ( gms_ENE_HARO_WORK.lighton == 0 )
        {
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate(obj_work, 6);
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneEffectMainFuncHarogen );
            gms_ENE_HARO_WORK.lighton = 1;
        }
        if ( AppMain.gmEneHaroGetLength2N( obj_work ) <= 10000 )
        {
            AppMain.GmSoundPlaySE( "Halogen" );
            AppMain.ObjDrawObjectActionSet( obj_work, 1 );
            obj_work.disp_flag |= 4U;
            return;
        }
        AppMain.ObjDrawObjectActionSet( obj_work, 1 );
        obj_work.disp_flag |= 4U;
    }

    // Token: 0x06000296 RID: 662 RVA: 0x00015B58 File Offset: 0x00013D58
    public static void gmEneHaroWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK = (AppMain.GMS_ENE_HARO_WORK)obj_work;
        if ( AppMain.gmEneHaroIsPlayerCenter( gms_ENE_HARO_WORK ) == 0 )
        {
            if ( AppMain.gmEneHaroIsPlayerLeft( gms_ENE_HARO_WORK ) != 0 )
            {
                gms_ENE_HARO_WORK.angle_add -= AppMain.AKM_DEGtoA32( 0.03f );
                if ( gms_ENE_HARO_WORK.angle_add < -AppMain.AKM_DEGtoA32( 0.35f ) )
                {
                    gms_ENE_HARO_WORK.angle_add = -AppMain.AKM_DEGtoA32( 0.35f );
                }
                gms_ENE_HARO_WORK.angle += gms_ENE_HARO_WORK.angle_add;
            }
            else
            {
                gms_ENE_HARO_WORK.angle_add += AppMain.AKM_DEGtoA32( 0.03f );
                if ( gms_ENE_HARO_WORK.angle_add > AppMain.AKM_DEGtoA32( 0.35f ) )
                {
                    gms_ENE_HARO_WORK.angle_add = AppMain.AKM_DEGtoA32( 0.35f );
                }
                gms_ENE_HARO_WORK.angle += gms_ENE_HARO_WORK.angle_add;
            }
            if ( gms_ENE_HARO_WORK.angle < -AppMain.AKM_DEGtoA32( 1.3f ) )
            {
                gms_ENE_HARO_WORK.angle = -AppMain.AKM_DEGtoA32( 1.3f );
            }
            if ( gms_ENE_HARO_WORK.angle > AppMain.AKM_DEGtoA32( 1.3f ) )
            {
                gms_ENE_HARO_WORK.angle = AppMain.AKM_DEGtoA32( 1.3f );
            }
        }
        int v = AppMain.FX_Cos(gms_ENE_HARO_WORK.angle);
        int num = AppMain.FX_Sin(gms_ENE_HARO_WORK.angle);
        gms_ENE_HARO_WORK.vec.x = AppMain.FX_Mul( gms_ENE_HARO_WORK.vec.x, v ) + AppMain.FX_Mul( gms_ENE_HARO_WORK.vec.y, num );
        gms_ENE_HARO_WORK.vec.y = AppMain.FX_Mul( gms_ENE_HARO_WORK.vec.x, -num ) + AppMain.FX_Mul( gms_ENE_HARO_WORK.vec.y, v );
        gms_ENE_HARO_WORK.vvv.x = ( int )( ( float )gms_ENE_HARO_WORK.vvv.x * 0.96f );
        gms_ENE_HARO_WORK.vvv.y = ( int )( ( float )gms_ENE_HARO_WORK.vvv.x * 0.96f );
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK2 = gms_ENE_HARO_WORK;
        gms_ENE_HARO_WORK2.vvv.x = gms_ENE_HARO_WORK2.vvv.x + gms_ENE_HARO_WORK.vec.x;
        AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK3 = gms_ENE_HARO_WORK;
        gms_ENE_HARO_WORK3.vvv.y = gms_ENE_HARO_WORK3.vvv.y + gms_ENE_HARO_WORK.vec.y;
        gms_ENE_HARO_WORK.spd = AppMain.FX_F32_TO_FX32( 1.5f );
        obj_work.spd.x = AppMain.FX_Mul( gms_ENE_HARO_WORK.vec.x, gms_ENE_HARO_WORK.spd );
        obj_work.spd.y = AppMain.FX_Mul( gms_ENE_HARO_WORK.vec.y, gms_ENE_HARO_WORK.spd );
        obj_work.spd.x = obj_work.spd.x + AppMain.FX_Mul( gms_ENE_HARO_WORK.vvv.x, AppMain.FX_F32_TO_FX32( 0.025 ) );
        obj_work.spd.y = obj_work.spd.y + AppMain.FX_Mul( gms_ENE_HARO_WORK.vvv.y, AppMain.FX_F32_TO_FX32( 0.025 ) );
        if ( gms_ENE_HARO_WORK.timer > 0 )
        {
            gms_ENE_HARO_WORK.timer--;
        }
        else
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHaroWalkInit );
        }
        if ( gms_ENE_HARO_WORK.vec.x < 0 )
        {
            obj_work.disp_flag &= 4294967294U;
            gms_ENE_HARO_WORK.targetAngle = AppMain.AKM_DEGtoA32( 250 );
        }
        else
        {
            obj_work.disp_flag &= 4294967294U;
            gms_ENE_HARO_WORK.targetAngle = AppMain.AKM_DEGtoA32( 330 );
        }
        if ( ( int )obj_work.dir.y > gms_ENE_HARO_WORK.targetAngle )
        {
            obj_work.dir.y = ( ushort )( obj_work.dir.y - ( ushort )AppMain.AKM_DEGtoA32( 5 ) );
        }
        if ( ( int )obj_work.dir.y < gms_ENE_HARO_WORK.targetAngle )
        {
            obj_work.dir.y = ( ushort )( obj_work.dir.y + ( ushort )AppMain.AKM_DEGtoA32( 5 ) );
        }
    }

    // Token: 0x06000297 RID: 663 RVA: 0x00015ED1 File Offset: 0x000140D1
    public static void gmEneHaroFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneHaroFlipInit( obj_work );
        }
    }

    // Token: 0x06000298 RID: 664 RVA: 0x00015EF3 File Offset: 0x000140F3
    public static void gmEneHaroFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHaroFlipMain );
    }

    // Token: 0x06000299 RID: 665 RVA: 0x00015F0E File Offset: 0x0001410E
    public static void gmEneHaroFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneHaroSetWalkSpeed( ( AppMain.GMS_ENE_HARO_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneHaroWalkInit( obj_work );
        }
    }

    // Token: 0x0600029A RID: 666 RVA: 0x00015F3C File Offset: 0x0001413C
    public static int gmEneHaroSetWalkSpeed( AppMain.GMS_ENE_HARO_WORK haro_work )
    {
        return 0;
    }

    // Token: 0x0600029B RID: 667 RVA: 0x00015F4C File Offset: 0x0001414C
    public static void gmEneEffectMainFuncHarogen( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.parent_obj != null )
        {
            AppMain.GMS_ENE_HARO_WORK gms_ENE_HARO_WORK = (AppMain.GMS_ENE_HARO_WORK)obj_work.parent_obj;
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmEneUtilGetNodeMatrix(gms_ENE_HARO_WORK.node_work, 2);
            if ( nns_MATRIX != null )
            {
                float num = nns_MATRIX.M03 - AppMain.FX_FX32_TO_F32(gms_ENE_HARO_WORK.ene_3d_work.ene_com.obj_work.pos.x);
                float num2 = nns_MATRIX.M13 + AppMain.FX_FX32_TO_F32(gms_ENE_HARO_WORK.ene_3d_work.ene_com.obj_work.pos.y);
                float num3 = nns_MATRIX.M23 - AppMain.FX_FX32_TO_F32(gms_ENE_HARO_WORK.ene_3d_work.ene_com.obj_work.pos.z);
                num += AppMain.FX_FX32_TO_F32( gms_ENE_HARO_WORK.ene_3d_work.ene_com.obj_work.spd.x );
                num2 -= AppMain.FX_FX32_TO_F32( gms_ENE_HARO_WORK.ene_3d_work.ene_com.obj_work.spd.y );
                num3 += AppMain.FX_FX32_TO_F32( gms_ENE_HARO_WORK.ene_3d_work.ene_com.obj_work.spd.z );
                obj_work.parent_ofst.x = AppMain.FX_F32_TO_FX32( num );
                obj_work.parent_ofst.y = -AppMain.FX_F32_TO_FX32( num2 - 10f );
                obj_work.parent_ofst.z = AppMain.FX_F32_TO_FX32( num3 );
            }
        }
        else
        {
            obj_work.flag |= 4U;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }
}
