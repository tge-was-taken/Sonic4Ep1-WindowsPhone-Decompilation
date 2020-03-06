using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060003F0 RID: 1008 RVA: 0x000200F4 File Offset: 0x0001E2F4
    private static AppMain.OBS_OBJECT_WORK GmEneHariSenboInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_HARI_WORK(), "ENE_HARI");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        if ( eve_rec.id == 0 )
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_harisenbo_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_harisenbo_r_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        }
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 660 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.pos.z = 655360;
        gms_ENEMY_3D_WORK.obj_3d.mtn_cb_func = new AppMain.mtn_cb_func_delegate( AppMain.gmEneHariMotionCallback );
        gms_ENEMY_3D_WORK.obj_3d.mtn_cb_param = obs_OBJECT_WORK;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -12, -12, 12, 12 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -22, -22, 22, 22 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -22, -22, 22, 22 );
        obs_RECT_WORK.flag &= 4294967291U;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -4, -8, 4, 0 );
        obs_OBJECT_WORK.move_flag |= 8448U;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        if ( eve_rec.id == 0 )
        {
            AppMain.gmEneHarisenboFwInit( obs_OBJECT_WORK );
            obs_OBJECT_WORK.flag |= 1073741824U;
        }
        else
        {
            obs_OBJECT_WORK.user_work = ( uint )( eve_rec.width * 30 ) * 4096U;
            if ( obs_OBJECT_WORK.user_work == 0U )
            {
                obs_OBJECT_WORK.user_work = 1228800U;
            }
            obs_OBJECT_WORK.user_flag = ( uint )( eve_rec.height * 30 ) * 4096U;
            if ( obs_OBJECT_WORK.user_flag == 0U )
            {
                obs_OBJECT_WORK.user_flag = 1228800U;
            }
            AppMain.gmEneHarisenboRedAtkWaitInit( obs_OBJECT_WORK );
        }
        AppMain.gmEneHariCreateJetEfct( ( AppMain.GMS_ENE_HARI_WORK )obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060003F1 RID: 1009 RVA: 0x0002031C File Offset: 0x0001E51C
    public static void GmEneHariSenboBuild()
    {
        AppMain.gm_ene_harisenbo_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 658 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 659 ) ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(659));
        AppMain.AmbChunk ambChunk = AppMain.amBindGet(ams_AMB_HEADER, ams_AMB_HEADER.file_num - 1, out ams_AMB_HEADER.dir);
        AppMain.TXB_HEADER txb = AppMain.readTXBfile(ambChunk.array, ambChunk.offset);
        AppMain.gm_ene_harisenbo_r_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 658 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 659 ) ), 0U, txb );
    }

    // Token: 0x060003F2 RID: 1010 RVA: 0x000203B4 File Offset: 0x0001E5B4
    public static void GmEneHariSenboFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(658));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_harisenbo_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_harisenbo_r_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060003F3 RID: 1011 RVA: 0x000203F1 File Offset: 0x0001E5F1
    public static void gmEneHarisenboRedAtkWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 0 );
        obj_work.disp_flag |= 4U;
        obj_work.user_timer = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHarisenboRedAtkWaitMain );
    }

    // Token: 0x060003F4 RID: 1012 RVA: 0x00020428 File Offset: 0x0001E628
    private static void gmEneHarisenboRedAtkWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountUp( obj_work.user_timer );
        if ( obj_work.user_timer >= ( int )obj_work.user_work )
        {
            AppMain.gmEneHarisenboRedAtkInit( obj_work );
        }
    }

    // Token: 0x060003F5 RID: 1013 RVA: 0x00020450 File Offset: 0x0001E650
    private static void gmEneHarisenboRedAtkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 2 );
        obj_work.disp_flag |= 4U;
        obj_work.user_timer = 245760;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHarisenboRedAtkMain );
    }

    // Token: 0x060003F6 RID: 1014 RVA: 0x000204A0 File Offset: 0x0001E6A0
    private static void gmEneHarisenboRedAtkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_3d.act_id[0] == 2 )
        {
            obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
            if ( obj_work.user_timer == 0 )
            {
                AppMain.OBS_RECT_WORK obs_RECT_WORK = ((AppMain.GMS_ENEMY_3D_WORK)obj_work).ene_com.rect_work[0];
                obs_RECT_WORK.def_power = 2;
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 3 );
                return;
            }
        }
        else if ( obj_work.obj_3d.act_id[0] == 3 )
        {
            if ( ( obj_work.disp_flag & 8U ) != 0U )
            {
                AppMain.OBS_RECT_WORK obs_RECT_WORK = ((AppMain.GMS_ENEMY_3D_WORK)obj_work).ene_com.rect_work[1];
                AppMain.ObjRectWorkSet( obs_RECT_WORK, -24, -24, 24, 24 );
                obs_RECT_WORK.flag |= 4U;
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 1 );
                obj_work.disp_flag |= 4U;
                obj_work.user_timer = 0;
                return;
            }
        }
        else
        {
            obj_work.user_timer = AppMain.ObjTimeCountUp( obj_work.user_timer );
            if ( obj_work.user_timer >= ( int )obj_work.user_flag )
            {
                AppMain.OBS_RECT_WORK obs_RECT_WORK = ((AppMain.GMS_ENEMY_3D_WORK)obj_work).ene_com.rect_work[1];
                AppMain.ObjRectWorkSet( obs_RECT_WORK, -12, -12, 12, 12 );
                obs_RECT_WORK.flag |= 4U;
                obs_RECT_WORK = ( ( AppMain.GMS_ENEMY_3D_WORK )obj_work ).ene_com.rect_work[0];
                obs_RECT_WORK.def_power = 0;
                AppMain.gmEneHarisenboRedAtkWaitInit( obj_work );
            }
        }
    }

    // Token: 0x060003F7 RID: 1015 RVA: 0x000205D4 File Offset: 0x0001E7D4
    private static void gmEneHarisenboFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet( obj_work, 0 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHarisenboFwMain );
    }

    // Token: 0x060003F8 RID: 1016 RVA: 0x00020604 File Offset: 0x0001E804
    private static void gmEneHarisenboFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060003F9 RID: 1017 RVA: 0x00020608 File Offset: 0x0001E808
    private static void gmEneHariMotionCallback( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object param )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmEneHariMotionCallback_node_mtx;
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.gmEneHariMotionCallback_base_mtx;
        AppMain.GMS_ENE_HARI_WORK gms_ENE_HARI_WORK = (AppMain.GMS_ENE_HARI_WORK)((AppMain.OBS_OBJECT_WORK)param);
        AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
        AppMain.nnMultiplyMatrix( nns_MATRIX2, nns_MATRIX2, AppMain.amMatrixGetCurrent() );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, 7, motion.data, nns_MATRIX2 );
        gms_ENE_HARI_WORK.jet_mtx.Assign( nns_MATRIX );
    }

    // Token: 0x060003FA RID: 1018 RVA: 0x00020660 File Offset: 0x0001E860
    private static void gmEneHariCreateJetEfct( AppMain.GMS_ENE_HARI_WORK hari_work )
    {
        if ( hari_work.efct_jet == null )
        {
            hari_work.efct_jet = AppMain.GmEfctEneEsCreate( ( AppMain.OBS_OBJECT_WORK )hari_work, 12 );
            hari_work.efct_jet.efct_com.obj_work.flag |= 524304U;
            hari_work.efct_jet.efct_com.obj_work.user_work_OBJECT = hari_work.jet_mtx;
            hari_work.efct_jet.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneHariJetEfctMain );
        }
    }

    // Token: 0x060003FB RID: 1019 RVA: 0x000206E8 File Offset: 0x0001E8E8
    private static void gmEneHariJetEfctMain( AppMain.OBS_OBJECT_WORK obj_work )
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
        nns_VECTOR.y += 5f;
        AppMain.GmComEfctSetDispOffsetF( ( AppMain.GMS_EFFECT_3DES_WORK )obj_work, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z );
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }
}