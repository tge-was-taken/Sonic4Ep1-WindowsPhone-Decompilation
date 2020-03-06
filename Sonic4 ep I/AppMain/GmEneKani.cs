using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200024B RID: 587
    public class GMS_ENE_KANI_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023B8 RID: 9144 RVA: 0x00149588 File Offset: 0x00147788
        public GMS_ENE_KANI_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023B9 RID: 9145 RVA: 0x001495A7 File Offset: 0x001477A7
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x04005842 RID: 22594
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04005843 RID: 22595
        public int spd_dec;

        // Token: 0x04005844 RID: 22596
        public int spd_dec_dist;

        // Token: 0x04005845 RID: 22597
        public readonly AppMain.GMS_ENE_NODE_MATRIX node_work = new AppMain.GMS_ENE_NODE_MATRIX();

        // Token: 0x04005846 RID: 22598
        public int timer;

        // Token: 0x04005847 RID: 22599
        public int spd_x;

        // Token: 0x04005848 RID: 22600
        public int ata_futa;

        // Token: 0x04005849 RID: 22601
        public int walk_s;
    }

    // Token: 0x06000E00 RID: 3584 RVA: 0x0007B5DE File Offset: 0x000797DE
    public static void GmEneKaniBuild()
    {
        AppMain.gm_ene_kani_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 684 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 685 ) ), 0U );
    }

    // Token: 0x06000E01 RID: 3585 RVA: 0x0007B60C File Offset: 0x0007980C
    public static void GmEneKaniFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(684));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_kani_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000E02 RID: 3586 RVA: 0x0007B640 File Offset: 0x00079840
    public static AppMain.OBS_OBJECT_WORK GmEneKaniInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_KANI_WORK(), "ENE_KANI");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_KANI_WORK gms_ENE_KANI_WORK = (AppMain.GMS_ENE_KANI_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_kani_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 686 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
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
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -4, -8, 4, -2 );
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 128U;
        gms_ENE_KANI_WORK.walk_s = 0;
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            gms_ENE_KANI_WORK.walk_s = 1;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_KANI_WORK.spd_dec = 102;
        gms_ENE_KANI_WORK.spd_dec_dist = 20480;
        AppMain.gmEneKaniWalkInit( obs_OBJECT_WORK );
        AppMain.GmEneUtilInitNodeMatrix( gms_ENE_KANI_WORK.node_work, obs_OBJECT_WORK, 3 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEneExit ) );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_KANI_WORK.node_work, 16 );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        obs_OBJECT_WORK.flag |= 1073741824U;
        gms_ENE_KANI_WORK.ata_futa = 0;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000E03 RID: 3587 RVA: 0x0007B870 File Offset: 0x00079A70
    public static int gmEneKaniGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
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

    // Token: 0x06000E04 RID: 3588 RVA: 0x0007B8F4 File Offset: 0x00079AF4
    public static int gmEneKaniIsPlayerLeft( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        return AppMain.GmEneComTargetIsLeft( obj_work, gms_PLAYER_WORK.obj_work );
    }

    // Token: 0x06000E05 RID: 3589 RVA: 0x0007B91C File Offset: 0x00079B1C
    public static void gmEneKaniWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GmEneComActionSetDependHFlip( obj_work, 2, 2 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniWalkMain );
        obj_work.move_flag &= 4294967291U;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
        }
        else
        {
            obj_work.spd.x = 2048;
        }
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -24, 11, 0 );
        obs_RECT_WORK.flag |= 4U;
        AppMain.GMS_ENE_KANI_WORK gms_ENE_KANI_WORK = (AppMain.GMS_ENE_KANI_WORK)obj_work;
        if ( gms_ENE_KANI_WORK.walk_s != 0 )
        {
            gms_ENE_KANI_WORK.timer = 15;
            return;
        }
        gms_ENE_KANI_WORK.timer = ( int )( 10 + AppMain.mtMathRand() % 20 );
    }

    // Token: 0x06000E06 RID: 3590 RVA: 0x0007B9E8 File Offset: 0x00079BE8
    public static void gmEneKaniWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KANI_WORK gms_ENE_KANI_WORK = (AppMain.GMS_ENE_KANI_WORK)obj_work;
        if ( gms_ENE_KANI_WORK.ata_futa != 0 )
        {
            if ( gms_ENE_KANI_WORK.timer > 0 )
            {
                gms_ENE_KANI_WORK.timer--;
                return;
            }
            obj_work.obj_3d.speed[0] = 2f;
            obj_work.disp_flag ^= 1U;
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                obj_work.spd.x = -2048;
            }
            else
            {
                obj_work.spd.x = 2048;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniWalkMain );
            if ( gms_ENE_KANI_WORK.walk_s != 0 )
            {
                gms_ENE_KANI_WORK.timer = 15;
            }
            else
            {
                gms_ENE_KANI_WORK.timer = ( int )( 10 + AppMain.mtMathRand() % 20 );
            }
        }
        else
        {
            obj_work.obj_3d.speed[0] = 1f;
            if ( ( obj_work.move_flag & 4U ) != 0U || AppMain.GmEneComCheckMoveLimit( obj_work, ( int )obj_work.user_work, ( int )obj_work.user_flag ) == 0 )
            {
                AppMain.gmEneKaniFlipInit( obj_work );
                gms_ENE_KANI_WORK.timer = 0;
            }
        }
        if ( AppMain.gmEneKaniIsPlayerLeft( obj_work ) != 0 )
        {
            gms_ENE_KANI_WORK.ata_futa = 0;
            if ( AppMain.gmEneKaniGetLength2N( obj_work ) < 8464 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniAttackInit );
                return;
            }
        }
        else
        {
            gms_ENE_KANI_WORK.ata_futa = 1;
        }
    }

    // Token: 0x06000E07 RID: 3591 RVA: 0x0007BB18 File Offset: 0x00079D18
    public static void gmEneKaniAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet( obj_work, 0 );
        obj_work.disp_flag &= 4294967291U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniAttackMain );
        obj_work.spd.x = 0;
        AppMain.GmSoundPlaySE( "Kani" );
    }

    // Token: 0x06000E08 RID: 3592 RVA: 0x0007BB6C File Offset: 0x00079D6C
    public static void gmEneKaniAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.GMS_ENE_KANI_WORK gms_ENE_KANI_WORK = (AppMain.GMS_ENE_KANI_WORK)obj_work;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmEneUtilGetNodeMatrix(gms_ENE_KANI_WORK.node_work, 16);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = nns_MATRIX.M03 - AppMain.FX_FX32_TO_F32( obj_work.pos.x );
        nns_VECTOR.y = nns_MATRIX.M13 - AppMain.FX_FX32_TO_F32( -obj_work.pos.y );
        nns_VECTOR.z = nns_MATRIX.M23 - AppMain.FX_FX32_TO_F32( obj_work.pos.z );
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            nns_VECTOR.x = -nns_VECTOR.x;
        }
        AppMain.ObjRectWorkSet( obs_RECT_WORK, ( short )( -11 + ( short )nns_VECTOR.x ), ( short )( -24 - ( short )nns_VECTOR.y ), ( short )( 11 + ( short )nns_VECTOR.x ), ( short )-( short )nns_VECTOR.y );
        obs_RECT_WORK.flag |= 4U;
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniAttackEnd );
            AppMain.ObjDrawObjectActionSet( obj_work, 1 );
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000E09 RID: 3593 RVA: 0x0007BC8C File Offset: 0x00079E8C
    public static void gmEneKaniAttackEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.GMS_ENE_KANI_WORK gms_ENE_KANI_WORK = (AppMain.GMS_ENE_KANI_WORK)obj_work;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GmEneUtilGetNodeMatrix(gms_ENE_KANI_WORK.node_work, 16);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = nns_MATRIX.M03 - AppMain.FX_FX32_TO_F32( obj_work.pos.x );
        nns_VECTOR.y = nns_MATRIX.M13 - AppMain.FX_FX32_TO_F32( -obj_work.pos.y );
        nns_VECTOR.z = nns_MATRIX.M23 - AppMain.FX_FX32_TO_F32( obj_work.pos.z );
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            nns_VECTOR.x = -nns_VECTOR.x;
        }
        AppMain.ObjRectWorkSet( obs_RECT_WORK, ( short )( -11 + ( short )nns_VECTOR.x ), ( short )( -24 - ( short )nns_VECTOR.y ), ( short )( 11 + ( short )nns_VECTOR.x ), ( short )-( short )nns_VECTOR.y );
        obs_RECT_WORK.flag |= 4U;
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniWalkInit );
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000E0A RID: 3594 RVA: 0x0007BDA2 File Offset: 0x00079FA2
    public static void gmEneKaniFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneKaniFlipInit( obj_work );
        }
    }

    // Token: 0x06000E0B RID: 3595 RVA: 0x0007BDC4 File Offset: 0x00079FC4
    public static void gmEneKaniFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.x = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKaniFlipMain );
    }

    // Token: 0x06000E0C RID: 3596 RVA: 0x0007BDEB File Offset: 0x00079FEB
    public static void gmEneKaniFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneKaniSetWalkSpeed( ( AppMain.GMS_ENE_KANI_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneKaniWalkInit( obj_work );
        }
    }

    // Token: 0x06000E0D RID: 3597 RVA: 0x0007BE18 File Offset: 0x0007A018
    public static int gmEneKaniSetWalkSpeed( AppMain.GMS_ENE_KANI_WORK kani_work )
    {
        return 0;
    }
}