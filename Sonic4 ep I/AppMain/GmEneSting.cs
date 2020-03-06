using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0200031F RID: 799
    public class GMS_ENE_STING_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002582 RID: 9602 RVA: 0x0014D8EE File Offset: 0x0014BAEE
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06002583 RID: 9603 RVA: 0x0014D900 File Offset: 0x0014BB00
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_STING_WORK work )
        {
            return work.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06002584 RID: 9604 RVA: 0x0014D912 File Offset: 0x0014BB12
        public GMS_ENE_STING_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x04005DC4 RID: 24004
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04005DC5 RID: 24005
        public readonly AppMain.OBS_RECT_WORK search_rect_work = new AppMain.OBS_RECT_WORK();

        // Token: 0x04005DC6 RID: 24006
        public int spd_dec;

        // Token: 0x04005DC7 RID: 24007
        public int spd_dec_dist;

        // Token: 0x04005DC8 RID: 24008
        public AppMain.GMS_EFFECT_3DES_WORK efct_r_jet;

        // Token: 0x04005DC9 RID: 24009
        public AppMain.GMS_EFFECT_3DES_WORK efct_l_jet;

        // Token: 0x04005DCA RID: 24010
        public AppMain.GMS_EFFECT_3DES_WORK efct_smoke;

        // Token: 0x04005DCB RID: 24011
        public int bullet_spd_x;

        // Token: 0x04005DCC RID: 24012
        public int bullet_spd_y;

        // Token: 0x04005DCD RID: 24013
        public short bullet_dir;

        // Token: 0x04005DCE RID: 24014
        public readonly AppMain.NNS_MATRIX jet_r_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005DCF RID: 24015
        public readonly AppMain.NNS_MATRIX jet_l_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005DD0 RID: 24016
        public readonly AppMain.NNS_MATRIX gun_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
    }


    // Token: 0x0600159C RID: 5532 RVA: 0x000BC5C8 File Offset: 0x000BA7C8
    private static AppMain.OBS_OBJECT_WORK GmEneStingInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_STING_WORK(), "ENE_STING");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_sting_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 669 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        gms_ENEMY_3D_WORK.obj_3d.mtn_cb_func = new AppMain.mtn_cb_func_delegate( AppMain.gmEneStingMotionCallback );
        gms_ENEMY_3D_WORK.obj_3d.mtn_cb_param = gms_ENE_STING_WORK;
        obs_OBJECT_WORK.pos.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -10, -8, 20, 8 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -18, -16, 28, 16 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -18, -16, 28, 16 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_RECT_WORK = gms_ENE_STING_WORK.search_rect_work;
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmEneStingSearchDefFunc );
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 1, 1 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.parent_obj = obs_OBJECT_WORK;
        AppMain.ObjRectWorkSet( obs_RECT_WORK, 0, 0, 128, 128 );
        obs_RECT_WORK.flag |= 1048804U;
        obs_OBJECT_WORK.ppRec = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneStingRegRectFunc );
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        if ( ( eve_rec.flag & ( ushort )AppMain.GMD_ENE_STING_EVE_FLAG_RIGHT ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_STING_WORK.spd_dec = ( int )AppMain.GMD_ENE_STING_SPD_X / ( AppMain.GMD_ENE_STING_TURN_FRAME / 2 );
        gms_ENE_STING_WORK.spd_dec_dist = ( int )AppMain.GMD_ENE_STING_SPD_X * ( AppMain.GMD_ENE_STING_TURN_FRAME / 2 ) / 2;
        AppMain.gmEneStingWalkInit( obs_OBJECT_WORK );
        AppMain.gmEneStingCreateJetEfct( gms_ENE_STING_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600159D RID: 5533 RVA: 0x000BC83C File Offset: 0x000BAA3C
    public static int gmEneStingSetWalkSpeed( AppMain.GMS_ENE_STING_WORK sting_work )
    {
        int result = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)sting_work;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 3 && obs_OBJECT_WORK.obj_3d.frame[0] >= ( float )( AppMain.GMD_ENE_STING_TURN_FRAME / 2 ) )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, sting_work.spd_dec, ( int )AppMain.GMD_ENE_STING_SPD_X );
            }
            else if ( obs_OBJECT_WORK.pos.x <= Convert.ToInt32( obs_OBJECT_WORK.user_work ) + sting_work.spd_dec_dist )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, sting_work.spd_dec );
                result = 1;
                if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x > ( int )obs_OBJECT_WORK.user_work )
                {
                    obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_work - ( uint )obs_OBJECT_WORK.pos.x );
                    if ( obs_OBJECT_WORK.spd.x < -sting_work.spd_dec )
                    {
                        obs_OBJECT_WORK.spd.x = -sting_work.spd_dec;
                    }
                }
            }
            else if ( obs_OBJECT_WORK.spd.x > ( int )( -( int )AppMain.GMD_ENE_STING_SPD_X ) )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -sting_work.spd_dec, ( int )AppMain.GMD_ENE_STING_SPD_X );
            }
        }
        else if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 2 && obs_OBJECT_WORK.obj_3d.frame[0] >= ( float )( AppMain.GMD_ENE_STING_TURN_FRAME / 2 ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -sting_work.spd_dec, ( int )AppMain.GMD_ENE_STING_SPD_X );
        }
        else if ( ( long )obs_OBJECT_WORK.pos.x >= ( long )( ( ulong )Convert.ToUInt32( obs_OBJECT_WORK.user_flag ) - ( ulong )( ( long )sting_work.spd_dec_dist ) ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, sting_work.spd_dec );
            result = 1;
            if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x < Convert.ToInt32( obs_OBJECT_WORK.user_flag ) )
            {
                obs_OBJECT_WORK.spd.x = Convert.ToInt32( obs_OBJECT_WORK.user_flag ) - obs_OBJECT_WORK.pos.x;
                if ( obs_OBJECT_WORK.spd.x > sting_work.spd_dec )
                {
                    obs_OBJECT_WORK.spd.x = sting_work.spd_dec;
                }
            }
        }
        else if ( obs_OBJECT_WORK.spd.x < ( int )AppMain.GMD_ENE_STING_SPD_X )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, sting_work.spd_dec, ( int )AppMain.GMD_ENE_STING_SPD_X );
        }
        return result;
    }

    // Token: 0x0600159E RID: 5534 RVA: 0x000BCAF0 File Offset: 0x000BACF0
    public static void GmEneStingBuild()
    {
        AppMain.gm_ene_sting_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 667 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 668 ) ), 0U );
    }

    // Token: 0x0600159F RID: 5535 RVA: 0x000BCB1C File Offset: 0x000BAD1C
    public static void GmEneStingFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(667));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_sting_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060015A0 RID: 5536 RVA: 0x000BCB4C File Offset: 0x000BAD4C
    public static void GmEneStingCreateBullet( AppMain.OBS_OBJECT_WORK parent_obj, int ofst_flash_x, int ofst_flash_y, int ofst_flash_z, int ofst_bul_x, int ofst_bul_y, int ofst_bul_z, int spd_x, int spd_y, short dir )
    {
        AppMain.GMS_EFFECT_COM_WORK gms_EFFECT_COM_WORK = (AppMain.GMS_EFFECT_COM_WORK)AppMain.GmEneComCreateAtkObject(parent_obj, 16);
        gms_EFFECT_COM_WORK.obj_work.parent_obj = null;
        AppMain.OBS_OBJECT_WORK obj_work = gms_EFFECT_COM_WORK.obj_work;
        obj_work.pos.x = obj_work.pos.x + ( ( ( parent_obj.disp_flag & 1U ) != 0U ) ? ( -ofst_bul_x ) : ofst_bul_x );
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_EFFECT_COM_WORK.obj_work;
        obj_work2.pos.y = obj_work2.pos.y + ofst_bul_y;
        AppMain.OBS_OBJECT_WORK obj_work3 = gms_EFFECT_COM_WORK.obj_work;
        obj_work3.pos.z = obj_work3.pos.z + ofst_bul_z;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_EFFECT_COM_WORK.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -8, -8, 8, 8 );
        obs_RECT_WORK.flag |= 4U;
        gms_EFFECT_COM_WORK.obj_work.spd.x = spd_x;
        gms_EFFECT_COM_WORK.obj_work.spd.y = spd_y;
        gms_EFFECT_COM_WORK.obj_work.view_out_ofst = 16;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(gms_EFFECT_COM_WORK.obj_work, 15);
        AppMain.GmComEfctSetDispRotationS( gms_EFFECT_3DES_WORK, 0, 0, dir );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 1024U;
        gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( parent_obj, 14 );
        AppMain.GmComEfctSetDispRotationS( gms_EFFECT_3DES_WORK, 0, 0, ( short )( ( int )dir - 32768 ) );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_obj = null;
        AppMain.OBS_OBJECT_WORK obj_work4 = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        obj_work4.pos.x = obj_work4.pos.x + ( ( ( parent_obj.disp_flag & 1U ) != 0U ) ? ( -ofst_flash_x ) : ofst_flash_x );
        AppMain.OBS_OBJECT_WORK obj_work5 = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        obj_work5.pos.y = obj_work5.pos.y + ofst_flash_y;
        AppMain.OBS_OBJECT_WORK obj_work6 = gms_EFFECT_3DES_WORK.efct_com.obj_work;
        obj_work6.pos.z = obj_work6.pos.z + ofst_flash_z;
    }

    // Token: 0x060015A1 RID: 5537 RVA: 0x000BCCE8 File Offset: 0x000BAEE8
    public static void gmEneStingJetEfctMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = (AppMain.NNS_MATRIX)obj_work.user_work_OBJECT;
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        if ( obj_work.parent_obj == null )
        {
            obj_work.flag |= 4U;
            return;
        }
        nns_VECTOR.x = nns_MATRIX.M03 - AppMain.FXM_FX32_TO_FLOAT( obj_work.parent_obj.pos.x );
        nns_VECTOR.y = -nns_MATRIX.M13 - AppMain.FXM_FX32_TO_FLOAT( obj_work.parent_obj.pos.y );
        nns_VECTOR.z = nns_MATRIX.M23 - AppMain.FXM_FX32_TO_FLOAT( obj_work.parent_obj.pos.z );
        if ( ( obj_work.parent_obj.disp_flag & 1U ) != 0U )
        {
            nns_VECTOR.x = -nns_VECTOR.x;
            nns_VECTOR.z = -nns_VECTOR.z;
        }
        nns_VECTOR.x += -3f;
        AppMain.GmComEfctSetDispOffsetF( ( AppMain.GMS_EFFECT_3DES_WORK )obj_work, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z );
        AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x060015A2 RID: 5538 RVA: 0x000BCDE9 File Offset: 0x000BAFE9
    public static void gmEneStingWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneStingWalkMain );
    }

    // Token: 0x060015A3 RID: 5539 RVA: 0x000BCE1C File Offset: 0x000BB01C
    public static void gmEneStingWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_STING_WORK sting_work = (AppMain.GMS_ENE_STING_WORK)obj_work;
        int num = AppMain.gmEneStingSetWalkSpeed(sting_work);
        if ( num != 0 )
        {
            AppMain.gmEneStingFlipInit( obj_work );
        }
    }

    // Token: 0x060015A4 RID: 5540 RVA: 0x000BCE40 File Offset: 0x000BB040
    public static void gmEneStingFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)obj_work;
        AppMain.GmEneComActionSetDependHFlip( obj_work, 2, 3 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneStingFlipMain );
        gms_ENE_STING_WORK.search_rect_work.flag &= 4294967291U;
        AppMain.gmEneStingClearJetEfct( gms_ENE_STING_WORK );
    }

    // Token: 0x060015A5 RID: 5541 RVA: 0x000BCE88 File Offset: 0x000BB088
    public static void gmEneStingCreateJetEfct( AppMain.GMS_ENE_STING_WORK sting_work )
    {
        if ( sting_work.efct_r_jet == null )
        {
            sting_work.efct_r_jet = AppMain.GmEfctEneEsCreate( ( AppMain.OBS_OBJECT_WORK )sting_work, 0 );
            AppMain.GmComEfctAddDispOffsetF( sting_work.efct_r_jet, -11f, -9f, 0f );
            sting_work.efct_r_jet.efct_com.obj_work.flag |= 524304U;
            sting_work.efct_r_jet.efct_com.obj_work.user_work_OBJECT = sting_work.jet_r_mtx;
            sting_work.efct_r_jet.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneStingJetEfctMain );
        }
        if ( sting_work.efct_l_jet == null )
        {
            sting_work.efct_l_jet = AppMain.GmEfctEneEsCreate( ( AppMain.OBS_OBJECT_WORK )sting_work, 0 );
            AppMain.GmComEfctAddDispOffsetF( sting_work.efct_l_jet, -11f, -9f, 0f );
            sting_work.efct_l_jet.efct_com.obj_work.flag |= 524304U;
            sting_work.efct_l_jet.efct_com.obj_work.user_work_OBJECT = sting_work.jet_l_mtx;
            sting_work.efct_l_jet.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneStingJetEfctMain );
        }
    }

    // Token: 0x060015A6 RID: 5542 RVA: 0x000BCFC0 File Offset: 0x000BB1C0
    public static void gmEneStingClearJetEfct( AppMain.GMS_ENE_STING_WORK sting_work )
    {
        if ( sting_work.efct_r_jet != null )
        {
            AppMain.ObjDrawKillAction3DES( sting_work.efct_r_jet.efct_com.obj_work );
            sting_work.efct_r_jet = null;
        }
        if ( sting_work.efct_l_jet != null )
        {
            AppMain.ObjDrawKillAction3DES( sting_work.efct_l_jet.efct_com.obj_work );
            sting_work.efct_l_jet = null;
        }
    }

    // Token: 0x060015A7 RID: 5543 RVA: 0x000BD018 File Offset: 0x000BB218
    public static void gmEneStingFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneStingSetWalkSpeed( ( AppMain.GMS_ENE_STING_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)obj_work;
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneStingCreateJetEfct( gms_ENE_STING_WORK );
            AppMain.gmEneStingWalkInit( obj_work );
            gms_ENE_STING_WORK = ( AppMain.GMS_ENE_STING_WORK )obj_work;
            gms_ENE_STING_WORK.search_rect_work.flag |= 4U;
        }
    }

    // Token: 0x060015A8 RID: 5544 RVA: 0x000BD076 File Offset: 0x000BB276
    public static void gmEneStingAtkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 4, 7 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneStingAtkMain );
        obj_work.spd.x = 0;
    }

    // Token: 0x060015A9 RID: 5545 RVA: 0x000BD0A8 File Offset: 0x000BB2A8
    public static void gmEneStingMotionCallback( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object param )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)param;
        AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
        AppMain.nnMultiplyMatrix( nns_MATRIX2, nns_MATRIX2, AppMain.amMatrixGetCurrent() );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_ENE_STING_NODE_ID_R_JET, motion.data, nns_MATRIX2 );
        gms_ENE_STING_WORK.jet_r_mtx.Assign( nns_MATRIX );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_ENE_STING_NODE_ID_L_JET, motion.data, nns_MATRIX2 );
        gms_ENE_STING_WORK.jet_l_mtx.Assign( nns_MATRIX );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_ENE_STING_NODE_ID_GUN, motion.data, nns_MATRIX2 );
        gms_ENE_STING_WORK.gun_mtx.Assign( nns_MATRIX );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
    }

    // Token: 0x060015AA RID: 5546 RVA: 0x000BD158 File Offset: 0x000BB358
    public static void gmEneStingSearchDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        if ( match_rect.parent_obj.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_PLAYER_WORK.rect_work[2];
        float num = AppMain.FXM_FX32_TO_FLOAT(gms_PLAYER_WORK.obj_work.pos.x) + (float)(obs_RECT_WORK.rect.left + obs_RECT_WORK.rect.right >> 1);
        float num2 = AppMain.FXM_FX32_TO_FLOAT(gms_PLAYER_WORK.obj_work.pos.y) + (float)(obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1);
        obs_RECT_WORK = gms_ENE_STING_WORK.ene_3d_work.ene_com.rect_work[2];
        float num3 = AppMain.FXM_FX32_TO_FLOAT(gms_ENE_STING_WORK.ene_3d_work.ene_com.obj_work.pos.x) + (float)(obs_RECT_WORK.rect.left + obs_RECT_WORK.rect.right >> 1);
        float num4 = AppMain.FXM_FX32_TO_FLOAT(gms_ENE_STING_WORK.ene_3d_work.ene_com.obj_work.pos.y + AppMain.GMD_ENE_STING_GUN_OFST_Y) + (float)(obs_RECT_WORK.rect.top + obs_RECT_WORK.rect.bottom >> 1);
        int num5;
        int num6;
        if ( ( gms_ENE_STING_WORK.ene_3d_work.ene_com.obj_work.disp_flag & 1U ) != 0U )
        {
            num5 = 32768 - AppMain.GMD_ENE_STING_SEARCH_DIR_START;
            num6 = 32768 - AppMain.GMD_ENE_STING_SEARCH_DIR_END;
        }
        else
        {
            num5 = AppMain.GMD_ENE_STING_SEARCH_DIR_START;
            num6 = AppMain.GMD_ENE_STING_SEARCH_DIR_END;
        }
        if ( num6 < num5 )
        {
            AppMain.MTM_MATH_SWAP<int>( ref num5, ref num6 );
        }
        float num7 = num - num3;
        float num8 = num2 - num4;
        int num9 = AppMain.nnArcTan2((double)num8, (double)num7);
        if ( num9 < num5 || num9 > num6 )
        {
            return;
        }
        gms_ENE_STING_WORK.bullet_spd_x = ( int )( ( float )AppMain.GMD_ENE_STING_BULLET_SPD * AppMain.nnCos( num9 ) );
        gms_ENE_STING_WORK.bullet_spd_y = ( int )( ( float )AppMain.GMD_ENE_STING_BULLET_SPD * AppMain.nnSin( num9 ) );
        if ( ( gms_ENE_STING_WORK.ene_3d_work.ene_com.obj_work.disp_flag & 1U ) != 0U )
        {
            gms_ENE_STING_WORK.bullet_dir = ( short )( num9 - 32768 );
        }
        else
        {
            gms_ENE_STING_WORK.bullet_dir = ( short )num9;
        }
        AppMain.gmEneStingAtkInit( ( AppMain.OBS_OBJECT_WORK )gms_ENE_STING_WORK );
        gms_ENE_STING_WORK.search_rect_work.flag &= 4294967291U;
    }

    // Token: 0x060015AB RID: 5547 RVA: 0x000BD37C File Offset: 0x000BB57C
    public static void gmEneStingRegRectFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)obj_work;
        AppMain.ObjObjectRectRegist( obj_work, gms_ENE_STING_WORK.search_rect_work );
    }

    // Token: 0x060015AC RID: 5548 RVA: 0x000BD39C File Offset: 0x000BB59C
    public static void gmEneStingAtkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_STING_WORK gms_ENE_STING_WORK = (AppMain.GMS_ENE_STING_WORK)obj_work;
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            if ( obj_work.user_timer != 0 )
            {
                return;
            }
            if ( obj_work.obj_3d.act_id[0] == 4 || obj_work.obj_3d.act_id[0] == 7 )
            {
                AppMain.GmEneStingCreateBullet( obj_work, AppMain.GMD_ENE_STING_BULLET_FLASH_OFST_X, AppMain.GMD_ENE_STING_BULLET_FLASH_OFST_Y, AppMain.GMD_ENE_STING_BULLET_FLASH_OFST_Z, AppMain.GMD_ENE_STING_BULLET_OFST_X, AppMain.GMD_ENE_STING_BULLET_OFST_Y, AppMain.GMD_ENE_STING_BULLET_OFST_Z, gms_ENE_STING_WORK.bullet_spd_x, gms_ENE_STING_WORK.bullet_spd_y, gms_ENE_STING_WORK.bullet_dir );
                AppMain.GmEneComActionSetDependHFlip( obj_work, 5, 8 );
                AppMain.GmSoundPlaySE( "Sting" );
            }
            else
            {
                AppMain.GmEneComActionSetDependHFlip( obj_work, 6, 9 );
            }
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            switch ( obj_work.obj_3d.act_id[0] )
            {
                case 4:
                case 7:
                    obj_work.user_timer = AppMain.GMD_ENE_STING_BULLET_WAIT;
                    return;
                case 5:
                case 8:
                    obj_work.user_timer = AppMain.GMD_ENE_STING_BULLET_AFTER_WAIT;
                    return;
                case 6:
                case 9:
                    AppMain.gmEneStingWalkInit( obj_work );
                    break;
                default:
                    return;
            }
        }
    }
}