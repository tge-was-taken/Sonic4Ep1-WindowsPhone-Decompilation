using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200019D RID: 413
    public class GMS_ENE_T_STAR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021EF RID: 8687 RVA: 0x00141FB9 File Offset: 0x001401B9
        public GMS_ENE_T_STAR_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060021F0 RID: 8688 RVA: 0x00141FD8 File Offset: 0x001401D8
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x04004F39 RID: 20281
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04004F3A RID: 20282
        public int spd_dec;

        // Token: 0x04004F3B RID: 20283
        public int spd_dec_dist;

        // Token: 0x04004F3C RID: 20284
        public int timer;

        // Token: 0x04004F3D RID: 20285
        public readonly AppMain.GMS_ENE_NODE_MATRIX node_work = new AppMain.GMS_ENE_NODE_MATRIX();

        // Token: 0x04004F3E RID: 20286
        public float fSpd;

        // Token: 0x04004F3F RID: 20287
        public ushort rotate;
    }

    // Token: 0x06000785 RID: 1925 RVA: 0x00042861 File Offset: 0x00040A61
    public static void GmEneTStarBuild()
    {
        AppMain.gm_ene_t_star_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 680 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 681 ) ), 0U );
    }

    // Token: 0x06000786 RID: 1926 RVA: 0x0004288C File Offset: 0x00040A8C
    public static void GmEneTStarFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(680));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_t_star_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000787 RID: 1927 RVA: 0x000428C0 File Offset: 0x00040AC0
    public static AppMain.OBS_OBJECT_WORK GmEneTStarInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_T_STAR_WORK(), "ENE_T_STAR");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_t_star_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 682 ), null, 0, null );
        AppMain.OBS_DATA_WORK data_work = AppMain.ObjDataGet(683);
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obs_OBJECT_WORK, 0, data_work, null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 655360;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -16, 16, 16 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -10, -10, 10, 10 );
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -20, -20, 20, 20 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 256U;
        if ( ( eve_rec.flag & 7 ) == 0 )
        {
            gms_ENE_T_STAR_WORK.fSpd = 1f;
        }
        else
        {
            gms_ENE_T_STAR_WORK.fSpd = 0f;
            if ( ( eve_rec.flag & 1 ) != 0 )
            {
                gms_ENE_T_STAR_WORK.fSpd += 0.5f;
            }
            if ( ( eve_rec.flag & 2 ) != 0 )
            {
                gms_ENE_T_STAR_WORK.fSpd += 0.25f;
            }
            if ( ( eve_rec.flag & 4 ) != 0 )
            {
                gms_ENE_T_STAR_WORK.fSpd += 0.125f;
            }
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        AppMain.gmEneTStarWaitInit( obs_OBJECT_WORK );
        AppMain.GmEneUtilInitNodeMatrix( gms_ENE_T_STAR_WORK.node_work, obs_OBJECT_WORK, 10 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEneTStarExit ) );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_T_STAR_WORK.node_work, 4 );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_T_STAR_WORK.node_work, 5 );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_T_STAR_WORK.node_work, 6 );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_T_STAR_WORK.node_work, 7 );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_T_STAR_WORK.node_work, 8 );
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK2 = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK2.ene_com.enemy_flag |= 32768U;
        obs_OBJECT_WORK.scale.x = AppMain.FX_F32_TO_FX32( 1.25f );
        obs_OBJECT_WORK.scale.y = AppMain.FX_F32_TO_FX32( 1.25f );
        obs_OBJECT_WORK.scale.z = AppMain.FX_F32_TO_FX32( 1.25f );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000788 RID: 1928 RVA: 0x00042BE0 File Offset: 0x00040DE0
    public static AppMain.OBS_OBJECT_WORK GmEneTStarNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_T_STAR_WORK(), "ENE_T_STAR");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_t_star_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 682 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 655360;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -12, 11, 12 );
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -16, 19, 16 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarNeedleMain );
        obs_OBJECT_WORK.scale.x = AppMain.FX_F32_TO_FX32( 1.25f );
        obs_OBJECT_WORK.scale.y = AppMain.FX_F32_TO_FX32( 1.25f );
        obs_OBJECT_WORK.scale.z = AppMain.FX_F32_TO_FX32( 1.25f );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000789 RID: 1929 RVA: 0x00042DC4 File Offset: 0x00040FC4
    public static void gmEneTStarExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)p;
        AppMain.GmEneUtilExitNodeMatrix( gms_ENE_T_STAR_WORK.node_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x0600078A RID: 1930 RVA: 0x00042DF0 File Offset: 0x00040FF0
    public static int gmEneTStarGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
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

    // Token: 0x0600078B RID: 1931 RVA: 0x00042E74 File Offset: 0x00041074
    public static AppMain.VecFx32 gmEneTStarGetPlayerVectorFx( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.VecFx32 result = default(AppMain.VecFx32);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        int num = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
        int num2 = gms_PLAYER_WORK.obj_work.pos.y - obj_work.pos.y;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            num = 2965504;
            num2 = 2965504;
        }
        int num3 = AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2);
        num3 = AppMain.FX_Sqrt( num3 );
        if ( num3 == 0 )
        {
            result.x = 0;
            result.y = 0;
        }
        else
        {
            int v = AppMain.FX_Div(4096, num3);
            result.x = AppMain.FX_Mul( num, v );
            result.y = AppMain.FX_Mul( num2, v );
        }
        result.z = 0;
        return result;
    }

    // Token: 0x0600078C RID: 1932 RVA: 0x00042F50 File Offset: 0x00041150
    public static void gmEneTStarWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarWaitMain );
        obj_work.move_flag &= 4294967291U;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
    }

    // Token: 0x0600078D RID: 1933 RVA: 0x00042FAB File Offset: 0x000411AB
    public static void gmEneTStarWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.gmEneTStarGetLength2N( obj_work ) < 16384 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarWalkInit );
        }
    }

    // Token: 0x0600078E RID: 1934 RVA: 0x00042FCC File Offset: 0x000411CC
    public static void gmEneTStarWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)obj_work;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarWalkMain );
        obj_work.move_flag &= 4294967291U;
        AppMain.VecFx32 vecFx = AppMain.gmEneTStarGetPlayerVectorFx(obj_work);
        obj_work.spd.x = ( int )( ( float )vecFx.x * 0.5f * gms_ENE_T_STAR_WORK.fSpd );
        obj_work.spd.y = ( int )( ( float )vecFx.y * 0.5f * gms_ENE_T_STAR_WORK.fSpd );
        gms_ENE_T_STAR_WORK.timer = 120;
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, 0 );
        gms_ENE_T_STAR_WORK.rotate = 0;
    }

    // Token: 0x0600078F RID: 1935 RVA: 0x00043078 File Offset: 0x00041278
    public static void gmEneTStarWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)obj_work;
        obj_work.disp_flag |= 4U;
        if ( gms_ENE_T_STAR_WORK.rotate > 0 )
        {
            obj_work.dir.z = ( ushort )( obj_work.dir.z + ( ushort )AppMain.AKM_DEGtoA16( 10 ) );
            AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK2 = gms_ENE_T_STAR_WORK;
            gms_ENE_T_STAR_WORK2.rotate -= 1;
            if ( gms_ENE_T_STAR_WORK.rotate == 0 )
            {
                obj_work.dir.z = 0;
            }
        }
        if ( gms_ENE_T_STAR_WORK.timer > 0 )
        {
            gms_ENE_T_STAR_WORK.timer--;
            if ( gms_ENE_T_STAR_WORK.timer == 60 )
            {
                gms_ENE_T_STAR_WORK.rotate = 36;
            }
            return;
        }
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        gms_ENE_T_STAR_WORK.timer = 15;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarStopMain );
    }

    // Token: 0x06000790 RID: 1936 RVA: 0x00043140 File Offset: 0x00041340
    public static void gmEneTStarStopMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)obj_work;
        obj_work.disp_flag |= 4U;
        if ( gms_ENE_T_STAR_WORK.timer > 0 )
        {
            gms_ENE_T_STAR_WORK.timer--;
            return;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarAttackInit );
        AppMain.GmEfctEneEsCreate( obj_work, 11 );
    }

    // Token: 0x06000791 RID: 1937 RVA: 0x00043198 File Offset: 0x00041398
    public static void gmEneTStarAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)obj_work;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
        AppMain.nnMakeRotateZMatrix( nns_MATRIX2, AppMain.AKM_DEGtoA32( 72 ) );
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        for ( int i = 0; i < 5; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(308, obj_work.pos.x, obj_work.pos.y, 0, 0, 0, 0, 0, 0);
            obs_OBJECT_WORK.parent_obj = obj_work;
            obs_OBJECT_WORK.dir.y = 49152;
            obs_OBJECT_WORK.dir.z = ( ushort )AppMain.AKM_DEGtoA16( -72 * i );
            nns_VECTOR.x = nns_MATRIX.M01;
            nns_VECTOR.y = nns_MATRIX.M11;
            nns_VECTOR.z = 0f;
            obs_OBJECT_WORK.spd.x = AppMain.FX_F32_TO_FX32( nns_VECTOR.x * 4f );
            obs_OBJECT_WORK.spd.y = -AppMain.FX_F32_TO_FX32( nns_VECTOR.y * 4f );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + AppMain.FX_F32_TO_FX32( nns_VECTOR.x * 10f );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y + -AppMain.FX_F32_TO_FX32( nns_VECTOR.y * 10f );
            AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, nns_MATRIX2 );
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
            gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate(obs_OBJECT_WORK, 10);
            gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = ( ushort )AppMain.AKM_DEGtoA16( -72 * i );
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        obj_work.disp_flag |= 32U;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarAttackMain );
        obj_work.move_flag &= 4294967291U;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        gms_ENE_T_STAR_WORK.timer = 300;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK2 = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        gms_ENEMY_3D_WORK2.ene_com.rect_work[1].flag &= 4294967291U;
        gms_ENEMY_3D_WORK2.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK2.ene_com.rect_work[2].flag &= 4294967291U;
        AppMain.GmSoundPlaySE( "Boss2_03" );
        gms_ENEMY_3D_WORK2.ene_com.enemy_flag |= 65536U;
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
    }

    // Token: 0x06000792 RID: 1938 RVA: 0x00043434 File Offset: 0x00041634
    public static void gmEneTStarAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_T_STAR_WORK gms_ENE_T_STAR_WORK = (AppMain.GMS_ENE_T_STAR_WORK)obj_work;
        if ( gms_ENE_T_STAR_WORK.timer > 0 )
        {
            gms_ENE_T_STAR_WORK.timer--;
            return;
        }
        obj_work.flag |= 8U;
    }

    // Token: 0x06000793 RID: 1939 RVA: 0x0004346E File Offset: 0x0004166E
    public static void gmEneTStarNeedleMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.UNREFERENCED_PARAMETER( obj_work );
    }

    // Token: 0x06000794 RID: 1940 RVA: 0x00043476 File Offset: 0x00041676
    public static void gmEneTStarFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneTStarFlipInit( obj_work );
        }
    }

    // Token: 0x06000795 RID: 1941 RVA: 0x00043498 File Offset: 0x00041698
    public static void gmEneTStarFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneTStarFlipMain );
    }

    // Token: 0x06000796 RID: 1942 RVA: 0x000434B3 File Offset: 0x000416B3
    public static void gmEneTStarFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneTStarSetWalkSpeed( ( AppMain.GMS_ENE_T_STAR_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneTStarWalkInit( obj_work );
        }
    }

    // Token: 0x06000797 RID: 1943 RVA: 0x000434E0 File Offset: 0x000416E0
    public static int gmEneTStarSetWalkSpeed( AppMain.GMS_ENE_T_STAR_WORK t_star_work )
    {
        return 0;
    }
}