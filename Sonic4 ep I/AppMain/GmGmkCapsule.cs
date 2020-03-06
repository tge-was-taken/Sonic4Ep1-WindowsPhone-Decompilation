using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000268 RID: 616
    private struct GMS_GMK_CAPSULE_ANIMAL_SET_PARAM
    {
        // Token: 0x060023F8 RID: 9208 RVA: 0x00149F24 File Offset: 0x00148124
        public GMS_GMK_CAPSULE_ANIMAL_SET_PARAM( short ofx, short ofy, short ofz, byte tp, byte vc, ushort tm )
        {
            this.ofs_x = ofx;
            this.ofs_y = ofy;
            this.ofs_z = ofz;
            this.type = tp;
            this.vec = vc;
            this.time = tm;
        }

        // Token: 0x0400591E RID: 22814
        public short ofs_x;

        // Token: 0x0400591F RID: 22815
        public short ofs_y;

        // Token: 0x04005920 RID: 22816
        public short ofs_z;

        // Token: 0x04005921 RID: 22817
        public byte type;

        // Token: 0x04005922 RID: 22818
        public byte vec;

        // Token: 0x04005923 RID: 22819
        public ushort time;
    }

    // Token: 0x06001009 RID: 4105 RVA: 0x0008B784 File Offset: 0x00089984
    private static void GmGmkCapsuleBuild()
    {
        AppMain.gm_gmk_capsule_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 860 ), AppMain.GmGameDatGetGimmickData( 861 ), 0U );
    }

    // Token: 0x0600100A RID: 4106 RVA: 0x0008B7A8 File Offset: 0x000899A8
    private static void GmGmkCapsuleFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(860);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_capsule_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600100B RID: 4107 RVA: 0x0008B7E0 File Offset: 0x000899E0
    private static AppMain.OBS_OBJECT_WORK GmGmkCapsuleInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_CAPSULE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_capsule_obj_3d_list[2], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -393216;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.width = 32;
        col_work.obj_col.height = 40;
        col_work.obj_col.ofst_x = ( short )( -col_work.obj_col.width / 2 );
        col_work.obj_col.ofst_y = -76;
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppHit = null;
        obs_RECT_WORK.ppDef = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -4, -80, 4, -72 );
        obs_OBJECT_WORK.user_flag = ( uint )( ( ulong )obs_OBJECT_WORK.user_flag & 18446744073709551614UL );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCapsuleSwitchMain );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(301, pos_x, pos_y, gms_ENEMY_3D_WORK.ene_com.eve_rec.flag, gms_ENEMY_3D_WORK.ene_com.eve_rec.left, gms_ENEMY_3D_WORK.ene_com.eve_rec.top, gms_ENEMY_3D_WORK.ene_com.eve_rec.width, gms_ENEMY_3D_WORK.ene_com.eve_rec.height, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.view_out_ofst = obs_OBJECT_WORK.view_out_ofst;
        gms_ENEMY_3D_WORK = ( AppMain.GMS_ENEMY_3D_WORK )obs_OBJECT_WORK2;
        obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GMK_CAPSULE_BODY" );
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK2;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_capsule_obj_3d_list[1], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK2.pos.z = -131072;
        obs_OBJECT_WORK2.move_flag |= 8448U;
        obs_OBJECT_WORK2.disp_flag |= 4194304U;
        obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCapsuleKeyMain );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600100C RID: 4108 RVA: 0x0008BA70 File Offset: 0x00089C70
    private static AppMain.OBS_OBJECT_WORK GmGmkCapsuleBodyInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_CAPSULE_BODY");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_capsule_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 862 ), null, 0, null );
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.width = 64;
        col_work.obj_col.height = 60;
        col_work.obj_col.ofst_x = ( short )( -col_work.obj_col.width / 2 );
        col_work.obj_col.ofst_y = ( short )( -( short )col_work.obj_col.height );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkCapsuleBodyMain );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600100D RID: 4109 RVA: 0x0008BB94 File Offset: 0x00089D94
    private static void gmGmkCapsuleSwitchMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_COLLISION_OBJ obj_col = obj_work.col_work.obj_col;
        if ( obj_col.rider_obj != null )
        {
            obj_work.ofst.y = 24576;
            if ( ( obj_work.user_flag & 1U ) == 0U )
            {
                AppMain.g_gm_main_system.game_flag &= 4294966271U;
                AppMain.g_gm_main_system.game_flag |= 1048576U;
                AppMain.GMS_EFFECT_3DES_WORK efct_3des = AppMain.GmEfctCmnEsCreate(obj_work, 23);
                AppMain.GmEffect3DESSetDispOffset( efct_3des, 0f, 24f, 40f );
                AppMain.gmGmkCapsuleAnimalMake( obj_work );
                obj_work.user_timer = 1;
                AppMain.GmGmkCamScrLimitSet( new AppMain.GMS_EVE_RECORD_EVENT
                {
                    flag = 7,
                    left = -96,
                    top = -104,
                    width = 192,
                    height = 112
                }, obj_work.pos.x, obj_work.pos.y );
                AppMain.GMM_PAD_VIB_SMALL();
                AppMain.GmSoundPlaySE( "Capsule" );
                AppMain.GmPlySeqChangeBossGoal( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )], obj_work.pos.x, obj_work.pos.y );
            }
            obj_work.user_flag |= 1U;
        }
        else
        {
            obj_work.ofst.y = 0;
        }
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer++;
            if ( obj_work.user_timer == 420 )
            {
                AppMain.g_gm_main_system.game_flag |= 4U;
            }
        }
    }

    // Token: 0x0600100E RID: 4110 RVA: 0x0008BD04 File Offset: 0x00089F04
    private static void gmGmkCapsuleBodyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        if ( ( parent_obj.user_flag & 1U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNN( obj_work, 1, 0 );
            obj_work.ppFunc = null;
        }
    }

    // Token: 0x0600100F RID: 4111 RVA: 0x0008BD34 File Offset: 0x00089F34
    private static void gmGmkCapsuleKeyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        if ( ( parent_obj.user_flag & 1U ) != 0U )
        {
            obj_work.spd.x = 24576;
            obj_work.spd.y = -16384;
            obj_work.move_flag &= 4294959103U;
            obj_work.move_flag |= 128U;
            obj_work.ppFunc = null;
            AppMain.GMS_EFFECT_3DES_WORK efct_3des = AppMain.GmEfctCmnEsCreate(obj_work, 21);
            AppMain.GmEffect3DESSetDispOffset( efct_3des, 0f, 46f, 40f );
            efct_3des = AppMain.GmEfctCmnEsCreate( obj_work, 22 );
            AppMain.GmEffect3DESSetDispOffset( efct_3des, 0f, 46f, 40f );
        }
    }

    // Token: 0x06001010 RID: 4112 RVA: 0x0008BDDC File Offset: 0x00089FDC
    private static void gmGmkCapsuleAnimalMake( AppMain.OBS_OBJECT_WORK obj_work )
    {
        for ( ushort num = 0; num < 20; num += 1 )
        {
            AppMain.GmGmkAnimalInit( obj_work, ( int )AppMain.g_gm_gmk_capsule_animal_set[( int )num].ofs_x << 12, ( int )AppMain.g_gm_gmk_capsule_animal_set[( int )num].ofs_y << 12, ( int )AppMain.g_gm_gmk_capsule_animal_set[( int )num].ofs_z << 12, AppMain.g_gm_gmk_capsule_animal_set[( int )num].type, AppMain.g_gm_gmk_capsule_animal_set[( int )num].vec, AppMain.g_gm_gmk_capsule_animal_set[( int )num].time );
        }
    }
}
