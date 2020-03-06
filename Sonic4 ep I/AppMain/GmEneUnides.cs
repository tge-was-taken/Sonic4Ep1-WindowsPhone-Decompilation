using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000249 RID: 585
    public class GMS_ENE_UNIDES_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023B5 RID: 9141 RVA: 0x0014952B File Offset: 0x0014772B
        public GMS_ENE_UNIDES_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023B6 RID: 9142 RVA: 0x0014953F File Offset: 0x0014773F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x0400582D RID: 22573
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x0400582E RID: 22574
        public int spd_dec;

        // Token: 0x0400582F RID: 22575
        public int spd_dec_dist;

        // Token: 0x04005830 RID: 22576
        public int rot_x;

        // Token: 0x04005831 RID: 22577
        public int rot_y;

        // Token: 0x04005832 RID: 22578
        public int rot_z;

        // Token: 0x04005833 RID: 22579
        public float len;

        // Token: 0x04005834 RID: 22580
        public int num;

        // Token: 0x04005835 RID: 22581
        public int attack_first;

        // Token: 0x04005836 RID: 22582
        public int attack;

        // Token: 0x04005837 RID: 22583
        public int zoom_now;

        // Token: 0x04005838 RID: 22584
        public int stop;

        // Token: 0x04005839 RID: 22585
        public int timer;

        // Token: 0x0400583A RID: 22586
        public float zoom;
    }

    // Token: 0x06000DED RID: 3565 RVA: 0x0007AA93 File Offset: 0x00078C93
    private static void GmEneUnidesBuild()
    {
        AppMain.gm_ene_unides_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 690 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 691 ) ), 0U );
    }

    // Token: 0x06000DEE RID: 3566 RVA: 0x0007AAC0 File Offset: 0x00078CC0
    private static void GmEneUnidesFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(690));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_unides_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000DEF RID: 3567 RVA: 0x0007AAF4 File Offset: 0x00078CF4
    private static AppMain.OBS_OBJECT_WORK GmEneUnidesInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_UNIDES_WORK(), "ENE_UNIDES");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_unides_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 692 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 655360;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -8, 0, 8, 16 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -8, 16, 16 );
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -16, 19, 16 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 256U;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
            obs_OBJECT_WORK.dir.y = ( ushort )AppMain.AKM_DEGtoA16( 45 );
        }
        else
        {
            obs_OBJECT_WORK.dir.y = ( ushort )AppMain.AKM_DEGtoA16( -45 );
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_UNIDES_WORK.spd_dec = 76;
        gms_ENE_UNIDES_WORK.spd_dec_dist = 15360;
        gms_ENE_UNIDES_WORK.len = 17.5f;
        gms_ENE_UNIDES_WORK.rot_x = AppMain.AKM_DEGtoA32( 90f );
        gms_ENE_UNIDES_WORK.rot_y = AppMain.AKM_DEGtoA32( 0f );
        gms_ENE_UNIDES_WORK.rot_z = AppMain.AKM_DEGtoA32( 0f );
        gms_ENE_UNIDES_WORK.num = 0;
        AppMain.gmEneUnidesWaitInit( obs_OBJECT_WORK );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(309, pos_x, pos_y, 0, 0, 0, 0, 0, 0);
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK2 = (AppMain.GMS_ENE_UNIDES_WORK)obs_OBJECT_WORK2;
            gms_ENE_UNIDES_WORK2.num = i;
            gms_ENE_UNIDES_WORK.num++;
        }
        gms_ENE_UNIDES_WORK.attack = 0;
        gms_ENE_UNIDES_WORK.attack_first = 0;
        gms_ENE_UNIDES_WORK.zoom_now = 0;
        gms_ENE_UNIDES_WORK.zoom = 1f;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DF0 RID: 3568 RVA: 0x0007ADC0 File Offset: 0x00078FC0
    private static AppMain.OBS_OBJECT_WORK GmEneUnidesNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_UNIDES_WORK(), "ENE_UNIDES");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_unides_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 692 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 655360;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -6, -4, 6, 8 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, 0, 19, 32 );
        obs_RECT_WORK.flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.gmEneUnidesNeedleWaitInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DF1 RID: 3569 RVA: 0x0007AF14 File Offset: 0x00079114
    private static int gmEneUnidesGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
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

    // Token: 0x06000DF2 RID: 3570 RVA: 0x0007AF98 File Offset: 0x00079198
    private static void gmEneUnidesWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesWaitMain );
        obj_work.move_flag &= 4294967291U;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
    }

    // Token: 0x06000DF3 RID: 3571 RVA: 0x0007AFF4 File Offset: 0x000791F4
    private static void gmEneUnidesWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obj_work;
        if ( AppMain.gmEneUnidesGetLength2N( obj_work ) < 9216 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesAttackInit );
        }
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            gms_ENE_UNIDES_WORK.rot_y += AppMain.AKM_DEGtoA32( 1 );
            return;
        }
        gms_ENE_UNIDES_WORK.rot_y += AppMain.AKM_DEGtoA32( -1 );
    }

    // Token: 0x06000DF4 RID: 3572 RVA: 0x0007B058 File Offset: 0x00079258
    private static void gmEneUnidesWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obj_work;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesWalkMain );
        obj_work.move_flag &= 4294967291U;
        gms_ENE_UNIDES_WORK.timer = 60;
    }

    // Token: 0x06000DF5 RID: 3573 RVA: 0x0007B0AC File Offset: 0x000792AC
    private static void gmEneUnidesWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obj_work;
        if ( gms_ENE_UNIDES_WORK.timer > 0 )
        {
            gms_ENE_UNIDES_WORK.timer--;
            return;
        }
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -1536;
            return;
        }
        obj_work.spd.x = 1536;
    }

    // Token: 0x06000DF6 RID: 3574 RVA: 0x0007B103 File Offset: 0x00079303
    private static void gmEneUnidesFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneUnidesFlipInit( obj_work );
        }
    }

    // Token: 0x06000DF7 RID: 3575 RVA: 0x0007B125 File Offset: 0x00079325
    private static void gmEneUnidesFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesFlipMain );
    }

    // Token: 0x06000DF8 RID: 3576 RVA: 0x0007B140 File Offset: 0x00079340
    private static void gmEneUnidesFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneUnidesSetWalkSpeed( ( AppMain.GMS_ENE_UNIDES_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneUnidesWalkInit( obj_work );
        }
    }

    // Token: 0x06000DF9 RID: 3577 RVA: 0x0007B16C File Offset: 0x0007936C
    private static void gmEneUnidesAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesAttackMain );
        obj_work.move_flag &= 4294967291U;
    }

    // Token: 0x06000DFA RID: 3578 RVA: 0x0007B1A4 File Offset: 0x000793A4
    private static void gmEneUnidesAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obj_work;
        if ( gms_ENE_UNIDES_WORK.stop == 0 )
        {
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                gms_ENE_UNIDES_WORK.rot_y += AppMain.AKM_DEGtoA32( 1 );
            }
            else
            {
                gms_ENE_UNIDES_WORK.rot_y += AppMain.AKM_DEGtoA32( -1 );
            }
        }
        gms_ENE_UNIDES_WORK.attack = 1;
        if ( gms_ENE_UNIDES_WORK.zoom_now == 1 )
        {
            gms_ENE_UNIDES_WORK.zoom += 0.07f;
            if ( gms_ENE_UNIDES_WORK.zoom > 1.4f )
            {
                gms_ENE_UNIDES_WORK.zoom_now = 2;
            }
        }
        else if ( gms_ENE_UNIDES_WORK.zoom_now >= 2 && gms_ENE_UNIDES_WORK.zoom_now <= 12 )
        {
            gms_ENE_UNIDES_WORK.zoom_now++;
            gms_ENE_UNIDES_WORK.zoom -= 0.07f;
        }
        else if ( gms_ENE_UNIDES_WORK.zoom_now >= 13 && gms_ENE_UNIDES_WORK.zoom_now <= 23 )
        {
            gms_ENE_UNIDES_WORK.zoom_now++;
            gms_ENE_UNIDES_WORK.zoom += 0.07f;
        }
        else if ( gms_ENE_UNIDES_WORK.zoom > 1f )
        {
            gms_ENE_UNIDES_WORK.zoom -= 0.07f;
            if ( gms_ENE_UNIDES_WORK.zoom <= 1f )
            {
                gms_ENE_UNIDES_WORK.zoom = 1f;
                gms_ENE_UNIDES_WORK.stop = 0;
                gms_ENE_UNIDES_WORK.zoom_now = 0;
            }
        }
        obj_work.scale.x = AppMain.FX_F32_TO_FX32( gms_ENE_UNIDES_WORK.zoom );
        obj_work.scale.y = AppMain.FX_F32_TO_FX32( gms_ENE_UNIDES_WORK.zoom );
        obj_work.scale.z = AppMain.FX_F32_TO_FX32( gms_ENE_UNIDES_WORK.zoom );
        if ( gms_ENE_UNIDES_WORK.num == 0 && gms_ENE_UNIDES_WORK.zoom == 1f )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesWalkInit );
        }
    }

    // Token: 0x06000DFB RID: 3579 RVA: 0x0007B34C File Offset: 0x0007954C
    private static int gmEneUnidesSetWalkSpeed( AppMain.GMS_ENE_UNIDES_WORK unides_work )
    {
        return 0;
    }

    // Token: 0x06000DFC RID: 3580 RVA: 0x0007B35C File Offset: 0x0007955C
    private static void gmEneUnidesNeedleWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesNeedleWaitMain );
        obj_work.move_flag &= 4294967291U;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
    }

    // Token: 0x06000DFD RID: 3581 RVA: 0x0007B3B8 File Offset: 0x000795B8
    private static void gmEneUnidesNeedleWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obj_work;
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK2 = (AppMain.GMS_ENE_UNIDES_WORK)obj_work.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num = gms_ENE_UNIDES_WORK2.rot_y;
        int rot_x = gms_ENE_UNIDES_WORK2.rot_x;
        int rot_z = gms_ENE_UNIDES_WORK2.rot_z;
        float len = gms_ENE_UNIDES_WORK2.len;
        num += AppMain.AKM_DEGtoA32( 360 ) / 4 * gms_ENE_UNIDES_WORK.num;
        num %= AppMain.AKM_DEGtoA32( 360 );
        AppMain.nnMakeRotateXMatrix( nns_MATRIX, rot_x );
        AppMain.nnRotateZMatrix( nns_MATRIX, nns_MATRIX, rot_z );
        AppMain.nnRotateYMatrix( nns_MATRIX, nns_MATRIX, num );
        AppMain.nnMakeTranslateMatrix( nns_MATRIX2, len, 0f, 0f );
        AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX, nns_MATRIX2 );
        AppMain.SNNS_VECTOR snns_VECTOR;
        AppMain.nnCopyMatrixTranslationVector( out snns_VECTOR, nns_MATRIX3 );
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( snns_VECTOR.x ) + gms_ENE_UNIDES_WORK2.ene_3d_work.ene_com.obj_work.pos.x;
        obj_work.pos.y = AppMain.FX_F32_TO_FX32( snns_VECTOR.y ) + gms_ENE_UNIDES_WORK2.ene_3d_work.ene_com.obj_work.pos.y;
        obj_work.pos.z = 655360;
        if ( gms_ENE_UNIDES_WORK2.attack != 0 && ( double )snns_VECTOR.y >= ( double )len * 0.98 && gms_ENE_UNIDES_WORK2.stop == 0 )
        {
            if ( gms_ENE_UNIDES_WORK2.attack_first != 0 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesNeedleAttackInit );
            }
            else
            {
                gms_ENE_UNIDES_WORK2.zoom_now = 1;
                gms_ENE_UNIDES_WORK2.attack_first = 1;
                gms_ENE_UNIDES_WORK2.stop = 1;
            }
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX3 );
    }

    // Token: 0x06000DFE RID: 3582 RVA: 0x0007B550 File Offset: 0x00079750
    private static void gmEneUnidesNeedleAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIDES_WORK gms_ENE_UNIDES_WORK = (AppMain.GMS_ENE_UNIDES_WORK)obj_work.parent_obj;
        gms_ENE_UNIDES_WORK.num--;
        if ( ( gms_ENE_UNIDES_WORK.ene_3d_work.ene_com.obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -AppMain.FX_F32_TO_FX32( 1f );
        }
        else
        {
            obj_work.spd.x = AppMain.FX_F32_TO_FX32( 1f );
        }
        obj_work.parent_obj = null;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUnidesNeedleAttackMain );
    }

    // Token: 0x06000DFF RID: 3583 RVA: 0x0007B5D6 File Offset: 0x000797D6
    private static void gmEneUnidesNeedleAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.UNREFERENCED_PARAMETER( obj_work );
    }
}
