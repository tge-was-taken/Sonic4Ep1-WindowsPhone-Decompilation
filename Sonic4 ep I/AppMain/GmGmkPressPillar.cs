using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060003CD RID: 973 RVA: 0x0001E4C9 File Offset: 0x0001C6C9
    private static void GmGmkPressPillarBuild()
    {
        AppMain.gm_gmk_press_pillar_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 951 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 952 ) ), 0U );
        AppMain.GmGmkPressPillarClear();
    }

    // Token: 0x060003CE RID: 974 RVA: 0x0001E4FC File Offset: 0x0001C6FC
    private static void GmGmkPressPillarFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(951));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_press_pillar_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060003CF RID: 975 RVA: 0x0001E540 File Offset: 0x0001C740
    private static AppMain.OBS_OBJECT_WORK GmGmkPressPillarInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_P_PIL_TOP");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        uint num = 0U;
        if ( eve_rec.id == 285 )
        {
            num = 1U;
        }
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_press_pillar_obj_3d_list[( int )( ( UIntPtr )( 2U + num ) )], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -126976;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 512U;
        obs_OBJECT_WORK.move_flag |= 1040U;
        obs_OBJECT_WORK.flag |= 1U;
        obs_OBJECT_WORK.user_flag = 0U;
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.width = ( ushort )AppMain.GMD_GMK_PPIL_COL_WIDTH;
        col_work.obj_col.height = ( ushort )AppMain.GMD_GMK_PPIL_COL_HEIGHT;
        col_work.obj_col.ofst_x = ( short )( -col_work.obj_col.width / 2 );
        col_work.obj_col.ofst_y = 0;
        if ( eve_rec.id == 285 )
        {
            col_work.obj_col.ofst_y = ( short )( -( short )col_work.obj_col.height );
        }
        if ( eve_rec.id == 284 )
        {
            AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, ( short )( -AppMain.GMD_GMK_PPIL_COL_WIDTH / 2 + 2 ), -1, ( short )( AppMain.GMD_GMK_PPIL_COL_WIDTH / 2 - 2 ), AppMain.GMD_GMK_PPIL_COL_HEIGHT );
        }
        else
        {
            AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, ( short )( -AppMain.GMD_GMK_PPIL_COL_WIDTH / 2 + 2 ), ( short )( -AppMain.GMD_GMK_PPIL_COL_HEIGHT ), ( short )( AppMain.GMD_GMK_PPIL_COL_WIDTH / 2 - 2 ), -1 );
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarTopWait );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GMK_P_PIL_BODY");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK2;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_press_pillar_obj_3d_list[( int )( ( UIntPtr )num )], gms_EFFECT_3DNN_WORK.obj_3d );
        AppMain.ObjAction3dNNMaterialMotionLoad( gms_EFFECT_3DNN_WORK.obj_3d, 0, null, null, ( int )num, AppMain.readAMBFile( AppMain.ObjDataGet( 953 ).pData ) );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK2, 0 );
        obs_OBJECT_WORK2.pos.z = -131072;
        obs_OBJECT_WORK2.move_flag |= 256U;
        obs_OBJECT_WORK2.disp_flag |= 4194308U;
        obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarBodyFollow );
        obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GMK_P_PIL_SPRING" );
        gms_EFFECT_3DNN_WORK = ( AppMain.GMS_EFFECT_3DNN_WORK )obs_OBJECT_WORK2;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_press_pillar_obj_3d_list[4], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK2.pos.z = -131072;
        obs_OBJECT_WORK2.move_flag |= 256U;
        obs_OBJECT_WORK2.disp_flag |= 4194304U;
        obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarSpringFollow );
        return obs_OBJECT_WORK;
    }

    // Token: 0x060003D0 RID: 976 RVA: 0x0001E83F File Offset: 0x0001CA3F
    private static void GmGmkPressPillarStartup( uint id_num )
    {
        id_num &= AppMain.GMD_GMK_PPIL_ID_NUM_MASK;
        AppMain.gm_gmk_press_pillar_sw[( int )( ( UIntPtr )id_num )] = 1;
    }

    // Token: 0x060003D1 RID: 977 RVA: 0x0001E853 File Offset: 0x0001CA53
    private static void GmGmkPressPillarClear()
    {
        Array.Clear( AppMain.gm_gmk_press_pillar_sw, 0, AppMain.gm_gmk_press_pillar_sw.Length );
    }

    // Token: 0x060003D2 RID: 978 RVA: 0x0001E868 File Offset: 0x0001CA68
    private static void gmGmkPPillarTopWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = ((AppMain.GMS_ENEMY_COM_WORK)obj_work).eve_rec;
        byte b = (byte)((uint)eve_rec.flag & AppMain.GMD_GMK_PPIL_ID_NUM_MASK);
        if ( AppMain.gm_gmk_press_pillar_sw[( int )b] != 0 )
        {
            int num = (int)eve_rec.top << 10;
            num = AppMain.MTM_MATH_ABS( num );
            if ( num == 0 )
            {
                num = 4096;
            }
            if ( eve_rec.id == 284 )
            {
                obj_work.spd.y = -num;
            }
            else
            {
                obj_work.spd.y = num;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarTopMove );
        }
    }

    // Token: 0x060003D3 RID: 979 RVA: 0x0001E8EC File Offset: 0x0001CAEC
    private static void gmGmkPPillarTopMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = ((AppMain.GMS_ENEMY_COM_WORK)obj_work).eve_rec;
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        int num = (int)eve_rec.height << 12;
        bool flag = false;
        if ( num != 0 )
        {
            if ( eve_rec.id == 284 )
            {
                num = gms_ENEMY_COM_WORK.born_pos_y - num;
                if ( obj_work.pos.y <= num )
                {
                    obj_work.pos.y = num;
                    flag = true;
                }
            }
            else
            {
                num = gms_ENEMY_COM_WORK.born_pos_y + num;
                if ( obj_work.pos.y >= num )
                {
                    obj_work.pos.y = num;
                    flag = true;
                }
            }
        }
        if ( ( obj_work.move_flag & 15U ) != 0U )
        {
            flag = true;
        }
        if ( flag )
        {
            obj_work.spd.y = 0;
            obj_work.ppFunc = null;
            obj_work.user_flag |= AppMain.GMD_GMK_PPIL_COLHIT;
            if ( ( ( int )eve_rec.flag & AppMain.GMD_GMK_PPIL_FLAG_EFFECT ) == 0 )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctZoneEsCreate(obj_work, 3, 1);
                if ( eve_rec.id == 284 )
                {
                    obs_OBJECT_WORK.dir.z = 32768;
                }
            }
        }
    }

    // Token: 0x060003D4 RID: 980 RVA: 0x0001E9E4 File Offset: 0x0001CBE4
    private static void gmGmkPPillarBodyFollow( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        int num = parent_obj.pos.y;
        if ( ( ( AppMain.GMS_ENEMY_COM_WORK )parent_obj ).eve_rec.id == 284 )
        {
            num += AppMain.GMD_GMK_PPIL_PIL_OFS_MAX;
        }
        else
        {
            num -= AppMain.GMD_GMK_PPIL_PIL_OFS_MAX;
        }
        obj_work.pos.y = num;
        if ( ( parent_obj.user_flag & AppMain.GMD_GMK_PPIL_COLHIT ) == 0U )
        {
            if ( parent_obj.spd.y != 0 )
            {
                obj_work.user_timer = parent_obj.spd.y;
            }
            return;
        }
        if ( ( ( int )( ( AppMain.GMS_ENEMY_COM_WORK )parent_obj ).eve_rec.flag & AppMain.GMD_GMK_PPIL_FLAG_SHOCK_ABS ) != 0 )
        {
            obj_work.spd.y = 0;
            obj_work.ppFunc = null;
            return;
        }
        obj_work.spd.y = obj_work.user_timer;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarBodyMove );
        obj_work.user_flag = 0U;
    }

    // Token: 0x060003D5 RID: 981 RVA: 0x0001EABC File Offset: 0x0001CCBC
    private static void gmGmkPPillarBodyMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = ((AppMain.GMS_ENEMY_COM_WORK)parent_obj).eve_rec;
        int num = obj_work.spd.y * 3 / 4;
        if ( 16 < AppMain.MTM_MATH_ABS( num ) )
        {
            obj_work.spd.y = num;
        }
        else
        {
            if ( eve_rec.id == 284 )
            {
                obj_work.spd.y = -obj_work.user_timer / 32;
            }
            else
            {
                obj_work.spd.y = -obj_work.user_timer / 32;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarBodyMoveEx );
        }
        if ( eve_rec.id == 284 )
        {
            if ( obj_work.pos.y <= parent_obj.pos.y + AppMain.GMD_GMK_PPIL_PIL_OFS_MIN )
            {
                obj_work.pos.y = parent_obj.pos.y + AppMain.GMD_GMK_PPIL_PIL_OFS_MIN;
                obj_work.spd.y = 32;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarBodyMoveEx );
            }
        }
        else if ( obj_work.pos.y >= parent_obj.pos.y - AppMain.GMD_GMK_PPIL_PIL_OFS_MIN )
        {
            obj_work.pos.y = parent_obj.pos.y - AppMain.GMD_GMK_PPIL_PIL_OFS_MIN;
            obj_work.spd.y = -32;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarBodyMoveEx );
        }
        parent_obj.user_work = ( uint )obj_work.pos.y;
    }

    // Token: 0x060003D6 RID: 982 RVA: 0x0001EC24 File Offset: 0x0001CE24
    private static void gmGmkPPillarBodyMoveEx( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = ((AppMain.GMS_ENEMY_COM_WORK)parent_obj).eve_rec;
        if ( obj_work.user_flag == 0U )
        {
            obj_work.spd.y = obj_work.spd.y * 8 / 7;
            if ( 2048 <= AppMain.MTM_MATH_ABS( obj_work.spd.y ) )
            {
                obj_work.user_flag = 1U;
            }
        }
        else
        {
            int y = obj_work.spd.y * 7 / 8;
            if ( 128 < AppMain.MTM_MATH_ABS( obj_work.spd.y ) )
            {
                obj_work.spd.y = y;
            }
        }
        if ( eve_rec.id == 284 )
        {
            if ( obj_work.pos.y >= parent_obj.pos.y + AppMain.GMD_GMK_PPIL_PIL_OFS_MAX )
            {
                obj_work.pos.y = parent_obj.pos.y + AppMain.GMD_GMK_PPIL_PIL_OFS_MAX;
                obj_work.spd.y = 0;
                obj_work.ppFunc = null;
            }
        }
        else if ( obj_work.pos.y <= parent_obj.pos.y - AppMain.GMD_GMK_PPIL_PIL_OFS_MAX )
        {
            obj_work.pos.y = parent_obj.pos.y - AppMain.GMD_GMK_PPIL_PIL_OFS_MAX;
            obj_work.spd.y = 0;
            obj_work.ppFunc = null;
        }
        parent_obj.user_work = ( uint )obj_work.pos.y;
    }

    // Token: 0x060003D7 RID: 983 RVA: 0x0001ED74 File Offset: 0x0001CF74
    private static void gmGmkPPillarSpringFollow( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        int num = parent_obj.pos.y;
        if ( ( ( AppMain.GMS_ENEMY_COM_WORK )parent_obj ).eve_rec.id == 284 )
        {
            num += AppMain.GMD_GMK_PPIL_SPR_OFS_MAX;
        }
        else
        {
            num -= AppMain.GMD_GMK_PPIL_SPR_OFS_MAX;
        }
        obj_work.pos.y = num;
        if ( ( parent_obj.user_flag & AppMain.GMD_GMK_PPIL_COLHIT ) != 0U )
        {
            if ( ( ( int )( ( AppMain.GMS_ENEMY_COM_WORK )parent_obj ).eve_rec.flag & AppMain.GMD_GMK_PPIL_FLAG_SHOCK_ABS ) != 0 )
            {
                obj_work.ppFunc = null;
            }
            else
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPPillarSpringMove );
            }
            obj_work.spd.y = 0;
        }
    }

    // Token: 0x060003D8 RID: 984 RVA: 0x0001EE18 File Offset: 0x0001D018
    private static void gmGmkPPillarSpringMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = ((AppMain.GMS_ENEMY_COM_WORK)parent_obj).eve_rec;
        int num;
        int num2;
        float a;
        if ( eve_rec.id == 284 )
        {
            num = parent_obj.pos.y + AppMain.GMD_GMK_PPIL_PIL_OFS_MIN - ( int )parent_obj.user_work;
            num /= 2;
            obj_work.pos.y = parent_obj.pos.y + AppMain.GMD_GMK_PPIL_SPR_OFS_MIN - num;
            num2 = obj_work.pos.y - ( parent_obj.pos.y + AppMain.GMD_GMK_PPIL_SPR_OFS_MIN );
            num2 = AppMain.MTM_MATH_ABS( num2 );
            a = ( float )num2 / ( float )( AppMain.GMD_GMK_PPIL_SPR_OFS_MAX - AppMain.GMD_GMK_PPIL_SPR_OFS_MIN );
            obj_work.scale.y = AppMain.FXM_FLOAT_TO_FX32( a );
            return;
        }
        num = parent_obj.pos.y - AppMain.GMD_GMK_PPIL_PIL_OFS_MIN - ( int )parent_obj.user_work;
        num /= 2;
        obj_work.pos.y = parent_obj.pos.y - AppMain.GMD_GMK_PPIL_SPR_OFS_MIN - num;
        num2 = obj_work.pos.y - ( parent_obj.pos.y - AppMain.GMD_GMK_PPIL_SPR_OFS_MIN );
        num2 = AppMain.MTM_MATH_ABS( num2 );
        a = ( float )num2 / ( float )( AppMain.GMD_GMK_PPIL_SPR_OFS_MAX - AppMain.GMD_GMK_PPIL_SPR_OFS_MIN );
        obj_work.scale.y = AppMain.FXM_FLOAT_TO_FX32( a );
    }
}