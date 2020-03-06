using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000269 RID: 617
    public class GMS_ENE_UNIUNI_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023F9 RID: 9209 RVA: 0x00149F53 File Offset: 0x00148153
        public GMS_ENE_UNIUNI_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023FA RID: 9210 RVA: 0x00149F67 File Offset: 0x00148167
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x04005924 RID: 22820
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04005925 RID: 22821
        public int spd_dec;

        // Token: 0x04005926 RID: 22822
        public int spd_dec_dist;

        // Token: 0x04005927 RID: 22823
        public int rot_x;

        // Token: 0x04005928 RID: 22824
        public int rot_y;

        // Token: 0x04005929 RID: 22825
        public int rot_z;

        // Token: 0x0400592A RID: 22826
        public float len;

        // Token: 0x0400592B RID: 22827
        public float len_target;

        // Token: 0x0400592C RID: 22828
        public float len_spd;

        // Token: 0x0400592D RID: 22829
        public int num;

        // Token: 0x0400592E RID: 22830
        public int attack;

        // Token: 0x0400592F RID: 22831
        public int timer;
    }

    // Token: 0x06001024 RID: 4132 RVA: 0x0008C502 File Offset: 0x0008A702
    private static void GmEneUniuniBuild()
    {
        AppMain.gm_ene_uniuni_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 693 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 694 ) ), 0U );
    }

    // Token: 0x06001025 RID: 4133 RVA: 0x0008C530 File Offset: 0x0008A730
    private static void GmEneUniuniFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(693));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_uniuni_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001026 RID: 4134 RVA: 0x0008C564 File Offset: 0x0008A764
    private static AppMain.OBS_OBJECT_WORK GmEneUniuniInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_UNIUNI_WORK(), "ENE_UNIUNI");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK = (AppMain.GMS_ENE_UNIUNI_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_uniuni_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 695 ), null, 0, null );
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
        gms_ENE_UNIUNI_WORK.spd_dec = 76;
        gms_ENE_UNIUNI_WORK.spd_dec_dist = 15360;
        gms_ENE_UNIUNI_WORK.len = 17.5f;
        gms_ENE_UNIUNI_WORK.len_target = 35.5f;
        gms_ENE_UNIUNI_WORK.len_spd = 1f;
        gms_ENE_UNIUNI_WORK.rot_x = AppMain.AKM_DEGtoA32( 90f );
        gms_ENE_UNIUNI_WORK.rot_y = AppMain.AKM_DEGtoA32( 0f );
        gms_ENE_UNIUNI_WORK.rot_z = AppMain.AKM_DEGtoA32( 0f );
        gms_ENE_UNIUNI_WORK.num = 0;
        AppMain.gmEneUniuniWalkInit( obs_OBJECT_WORK );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(310, pos_x, pos_y, 0, 0, 0, 0, 0, 0);
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK2 = (AppMain.GMS_ENE_UNIUNI_WORK)obs_OBJECT_WORK2;
            gms_ENE_UNIUNI_WORK2.num = i;
            gms_ENE_UNIUNI_WORK.num++;
        }
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001027 RID: 4135 RVA: 0x0008C818 File Offset: 0x0008AA18
    private static AppMain.OBS_OBJECT_WORK GmEneUniuniNeedleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_UNIUNI_WORK(), "ENE_UNIUNI");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_uniuni_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 695 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 655360;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -4, -4, 4, 4 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, 0, 19, 32 );
        obs_RECT_WORK.flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.gmEneUniuniNeedleWaitInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001028 RID: 4136 RVA: 0x0008C96C File Offset: 0x0008AB6C
    private static int gmEneUniuniGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
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

    // Token: 0x06001029 RID: 4137 RVA: 0x0008C9F0 File Offset: 0x0008ABF0
    private static void gmEneUniuniWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK = (AppMain.GMS_ENE_UNIUNI_WORK)obj_work;
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUniuniWalkMain );
        obj_work.move_flag &= 4294967291U;
        gms_ENE_UNIUNI_WORK.timer = 1;
    }

    // Token: 0x0600102A RID: 4138 RVA: 0x0008CA44 File Offset: 0x0008AC44
    private static void gmEneUniuniWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK = (AppMain.GMS_ENE_UNIUNI_WORK)obj_work;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -1536;
        }
        else
        {
            obj_work.spd.x = 1536;
        }
        if ( gms_ENE_UNIUNI_WORK.len_target == 17.5f )
        {
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                gms_ENE_UNIUNI_WORK.rot_y += AppMain.AKM_DEGtoA32( 1 );
            }
            else
            {
                gms_ENE_UNIUNI_WORK.rot_y += AppMain.AKM_DEGtoA32( -1 );
            }
        }
        else
        {
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                gms_ENE_UNIUNI_WORK.rot_y += AppMain.AKM_DEGtoA32( 0.5f );
            }
            else
            {
                gms_ENE_UNIUNI_WORK.rot_y += AppMain.AKM_DEGtoA32( -0.5f );
            }
            obj_work.spd.x = 0;
        }
        if ( gms_ENE_UNIUNI_WORK.len_target > gms_ENE_UNIUNI_WORK.len )
        {
            gms_ENE_UNIUNI_WORK.len += gms_ENE_UNIUNI_WORK.len_spd;
            if ( gms_ENE_UNIUNI_WORK.len_target <= gms_ENE_UNIUNI_WORK.len )
            {
                gms_ENE_UNIUNI_WORK.len = gms_ENE_UNIUNI_WORK.len_target;
            }
            gms_ENE_UNIUNI_WORK.len_spd += 0.03f;
        }
        if ( gms_ENE_UNIUNI_WORK.len_target < gms_ENE_UNIUNI_WORK.len )
        {
            gms_ENE_UNIUNI_WORK.len -= gms_ENE_UNIUNI_WORK.len_spd;
            if ( gms_ENE_UNIUNI_WORK.len_target >= gms_ENE_UNIUNI_WORK.len )
            {
                gms_ENE_UNIUNI_WORK.len = gms_ENE_UNIUNI_WORK.len_target;
            }
            gms_ENE_UNIUNI_WORK.len_spd -= 0.05f;
            if ( gms_ENE_UNIUNI_WORK.len_spd < 0.1f )
            {
                gms_ENE_UNIUNI_WORK.len_spd = 0.1f;
            }
        }
        if ( gms_ENE_UNIUNI_WORK.timer > 0 )
        {
            gms_ENE_UNIUNI_WORK.timer--;
            return;
        }
        if ( gms_ENE_UNIUNI_WORK.len_target == 17.5f )
        {
            gms_ENE_UNIUNI_WORK.timer = 120;
            gms_ENE_UNIUNI_WORK.len_spd = 0f;
            gms_ENE_UNIUNI_WORK.len_target = 35.5f;
            return;
        }
        if ( gms_ENE_UNIUNI_WORK.len_target == 35.5f )
        {
            gms_ENE_UNIUNI_WORK.timer = 120;
            gms_ENE_UNIUNI_WORK.len_spd = 1f;
            gms_ENE_UNIUNI_WORK.len_target = 17.5f;
        }
    }

    // Token: 0x0600102B RID: 4139 RVA: 0x0008CC2C File Offset: 0x0008AE2C
    private static void gmEneUniuniFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneUniuniFlipInit( obj_work );
        }
    }

    // Token: 0x0600102C RID: 4140 RVA: 0x0008CC4E File Offset: 0x0008AE4E
    private static void gmEneUniuniFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUniuniFlipMain );
    }

    // Token: 0x0600102D RID: 4141 RVA: 0x0008CC69 File Offset: 0x0008AE69
    private static void gmEneUniuniFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneUniuniSetWalkSpeed( ( AppMain.GMS_ENE_UNIUNI_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneUniuniWalkInit( obj_work );
        }
    }

    // Token: 0x0600102E RID: 4142 RVA: 0x0008CC98 File Offset: 0x0008AE98
    private static int gmEneUniuniSetWalkSpeed( AppMain.GMS_ENE_UNIUNI_WORK uniuni_work )
    {
        return 0;
    }

    // Token: 0x0600102F RID: 4143 RVA: 0x0008CCA8 File Offset: 0x0008AEA8
    private static void gmEneUniuniNeedleWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUniuniNeedleWaitMain );
        obj_work.move_flag &= 4294967291U;
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
    }

    // Token: 0x06001030 RID: 4144 RVA: 0x0008CD04 File Offset: 0x0008AF04
    private static void gmEneUniuniNeedleWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK = (AppMain.GMS_ENE_UNIUNI_WORK)obj_work;
        AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK2 = (AppMain.GMS_ENE_UNIUNI_WORK)obj_work.parent_obj;
        int num = gms_ENE_UNIUNI_WORK2.rot_y;
        int rot_x = gms_ENE_UNIUNI_WORK2.rot_x;
        int rot_z = gms_ENE_UNIUNI_WORK2.rot_z;
        float len = gms_ENE_UNIUNI_WORK2.len;
        num += AppMain.AKM_DEGtoA32( 360 ) / 4 * gms_ENE_UNIUNI_WORK.num;
        num %= AppMain.AKM_DEGtoA32( 360 );
        AppMain.SNNS_MATRIX snns_MATRIX;
        AppMain.nnMakeRotateXMatrix( out snns_MATRIX, rot_x );
        AppMain.nnRotateZMatrix( ref snns_MATRIX, ref snns_MATRIX, rot_z );
        AppMain.nnRotateYMatrix( ref snns_MATRIX, ref snns_MATRIX, num );
        AppMain.SNNS_MATRIX snns_MATRIX2;
        AppMain.nnMakeTranslateMatrix( out snns_MATRIX2, len, 0f, 0f );
        AppMain.SNNS_MATRIX snns_MATRIX3;
        AppMain.nnMultiplyMatrix( out snns_MATRIX3, ref snns_MATRIX, ref snns_MATRIX2 );
        AppMain.SNNS_VECTOR snns_VECTOR;
        AppMain.nnCopyMatrixTranslationVector( out snns_VECTOR, ref snns_MATRIX3 );
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( snns_VECTOR.x ) + gms_ENE_UNIUNI_WORK2.ene_3d_work.ene_com.obj_work.pos.x;
        obj_work.pos.y = AppMain.FX_F32_TO_FX32( snns_VECTOR.y ) + gms_ENE_UNIUNI_WORK2.ene_3d_work.ene_com.obj_work.pos.y;
        obj_work.pos.z = 655360;
        if ( gms_ENE_UNIUNI_WORK2.attack != 0 && ( double )snns_VECTOR.y >= ( double )len * 0.98 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUniuniNeedleAttackInit );
        }
    }

    // Token: 0x06001031 RID: 4145 RVA: 0x0008CE58 File Offset: 0x0008B058
    private static void gmEneUniuniNeedleAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_UNIUNI_WORK gms_ENE_UNIUNI_WORK = (AppMain.GMS_ENE_UNIUNI_WORK)obj_work.parent_obj;
        gms_ENE_UNIUNI_WORK.num--;
        if ( ( gms_ENE_UNIUNI_WORK.ene_3d_work.ene_com.obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -AppMain.FX_F32_TO_FX32( 1f );
        }
        else
        {
            obj_work.spd.x = AppMain.FX_F32_TO_FX32( 1f );
        }
        obj_work.parent_obj = null;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneUniuniNeedleAttackMain );
    }

    // Token: 0x06001032 RID: 4146 RVA: 0x0008CEDE File Offset: 0x0008B0DE
    private static void gmEneUniuniNeedleAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.UNREFERENCED_PARAMETER( obj_work );
    }
}
