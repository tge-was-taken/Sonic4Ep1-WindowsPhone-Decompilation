using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000531 RID: 1329 RVA: 0x0002BE21 File Offset: 0x0002A021
    private static void GmGmkTarzanRopeBuild()
    {
        AppMain.g_gm_gmk_tarzan_rope_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 829 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 830 ) ), 0U );
    }

    // Token: 0x06000532 RID: 1330 RVA: 0x0002BE4C File Offset: 0x0002A04C
    private static void GmGmkTarzanRopeFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(829));
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_tarzan_rope_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_tarzan_rope_obj_3d_list = null;
    }

    // Token: 0x06000533 RID: 1331 RVA: 0x0002BE80 File Offset: 0x0002A080
    private static AppMain.OBS_OBJECT_WORK GmGmkTarzanRopeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int type2;
        switch ( eve_rec.id )
        {
            case 112:
                type2 = 0;
                break;
            case 113:
                type2 = 1;
                break;
            case 114:
                type2 = 2;
                break;
            default:
                return null;
        }
        float length = 1f + (float)eve_rec.left / 100f;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkTarzanRopeLoadObj(eve_rec, pos_x, pos_y, type2);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkTarzanRopeInit( obj_work, type2, length );
        return obj_work;
    }

    // Token: 0x06000534 RID: 1332 RVA: 0x0002BEF0 File Offset: 0x0002A0F0
    private static void gmGmkTarzanRopeMotionCallback( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT obj, object val )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)((AppMain.OBS_OBJECT_WORK)val);
        if ( gms_ENEMY_3D_WORK.ene_com.target_obj == null )
        {
            return;
        }
        AppMain.NNS_MATRIX nns_MATRIX = new AppMain.NNS_MATRIX();
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, AppMain.amMatrixGetCurrent() );
        AppMain.nnCalcNodeMatrixTRSList( AppMain.g_gm_gmk_tarzan_rope_active_matrix, obj, 13, motion.data, nns_MATRIX );
    }

    // Token: 0x06000535 RID: 1333 RVA: 0x0002BF50 File Offset: 0x0002A150
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkTarzanRopeLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_T_ROPE");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000536 RID: 1334 RVA: 0x0002BFC4 File Offset: 0x0002A1C4
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkTarzanRopeLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkTarzanRopeLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        int num;
        if ( eve_rec.left >= 50 )
        {
            num = 2;
        }
        else if ( eve_rec.left >= 20 )
        {
            num = 1;
        }
        else
        {
            num = 0;
        }
        int num2 = AppMain.g_gm_gmk_tarzan_rope_model_id[num];
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_tarzan_rope_obj_3d_list[num2], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, AppMain.ObjDataGet( 831 ), null, 0, null );
        obj_work.obj_3d.mtn_cb_func = new AppMain.mtn_cb_func_delegate( AppMain.gmGmkTarzanRopeMotionCallback );
        obj_work.obj_3d.mtn_cb_param = obj_work;
        AppMain.NNS_OBJECT @object = obj_work.obj_3d._object;
        float num3 = @object.pNodeList[0].Translation.y;
        num3 *= ( float )eve_rec.left / 30f;
        int num4 = AppMain.FX_F32_TO_FX32(num3);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = obj_work;
        obs_OBJECT_WORK.pos.y = obs_OBJECT_WORK.pos.y - num4;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000537 RID: 1335 RVA: 0x0002C0B0 File Offset: 0x0002A2B0
    private static void gmGmkTarzanRopeInit( AppMain.OBS_OBJECT_WORK obj_work, int type, float length )
    {
        AppMain.GMS_ENEMY_3D_WORK gimmick_work = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkTarzanRopeSetRect( gimmick_work, type );
        obj_work.move_flag = 8448U;
        obj_work.disp_flag |= 4194304U;
        obj_work.obj_3d.drawflag |= 32U;
        int id = AppMain.g_gm_gmk_tarzan_rope_motion_id[type];
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, id, 0 );
        obj_work.disp_flag |= 16U;
        int angle = 0;
        switch ( type )
        {
            case 0:
                angle = 0;
                break;
            case 1:
                angle = -16384;
                break;
            case 2:
                angle = 16384;
                break;
        }
        AppMain.gmGmkTarzanRopeSetUserWorkTargetAngle( obj_work, angle );
        AppMain.gmGmkTarzanRopeSetUserTimerCurrentAngle( obj_work, angle );
        AppMain.gmGmkTarzanRopeeSetUserFlagType( obj_work, type );
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTarzanRopeDrawFunc );
    }

    // Token: 0x06000538 RID: 1336 RVA: 0x0002C17C File Offset: 0x0002A37C
    private static void gmGmkTarzanRopeSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work, int type )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        float num = 1f + (float)gimmick_work.ene_com.eve_rec.left / 100f;
        short num2 = (short)(64f * num);
        switch ( type )
        {
            case 0:
                AppMain.ObjRectWorkZSet( obs_RECT_WORK, -32, -32, -500, 32, ( short )( num2 - 32 ), 500 );
                break;
            case 1:
                AppMain.ObjRectWorkZSet( obs_RECT_WORK, ( short )-num2, -48, -500, 0, -16, 500 );
                break;
            case 2:
                AppMain.ObjRectWorkZSet( obs_RECT_WORK, 0, -48, -500, num2, -16, 500 );
                break;
        }
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkTarzanRopeDefFunc );
    }

    // Token: 0x06000539 RID: 1337 RVA: 0x0002C254 File Offset: 0x0002A454
    private static float gmGmkTarzanRopeCalcFlame( AppMain.OBS_OBJECT_WORK obj_work, int angle )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        int num = 16384;
        int num2 = -16384;
        if ( angle > num )
        {
            angle = num;
        }
        else if ( angle < num2 )
        {
            angle = num2;
        }
        float num3 = AppMain.amMotionGetStartFrame(obj_3d.motion, obj_3d.act_id[0]);
        float num4 = AppMain.amMotionGetEndFrame(obj_3d.motion, obj_3d.act_id[0]);
        float num5 = (num4 - num3) / 2f;
        float num6 = (float)angle / (float)num;
        return num5 - num6 * ( num4 - num3 ) / 4f;
    }

    // Token: 0x0600053A RID: 1338 RVA: 0x0002C2D4 File Offset: 0x0002A4D4
    private static void gmGmkTarzanRopeDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( obj_3d.motion == null )
        {
            return;
        }
        obj_3d.frame[0] = AppMain.gmGmkTarzanRopeCalcFlame( obj_work, AppMain.gmGmkTarzanRopeGetUserTimerCurrentAngle( obj_work ) );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x0600053B RID: 1339 RVA: 0x0002C30C File Offset: 0x0002A50C
    private static void gmGmkTarzanRopeDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        if ( gms_PLAYER_WORK.seq_state == 35 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state == 19 )
        {
            AppMain.GMM_PAD_VIB_SMALL();
        }
        AppMain.GmPlySeqInitTarzanRope( gms_PLAYER_WORK, gms_ENEMY_3D_WORK.ene_com );
        parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTarzanRopeMainWait );
        gms_ENEMY_3D_WORK.ene_com.target_obj = parent_obj2;
        int num = AppMain.gmGmkTarzanRopeGetUserFlagType(parent_obj);
        int num2;
        if ( num == 0 )
        {
            num2 = parent_obj2.spd.x >> 2;
            if ( num2 > 240 )
            {
                num2 += AppMain.MTM_MATH_ABS( parent_obj2.spd.y >> 2 );
            }
            else if ( num2 < -240 )
            {
                num2 -= AppMain.MTM_MATH_ABS( parent_obj2.spd.y >> 2 );
            }
            if ( num2 > 16384 )
            {
                num2 = 16384;
            }
            else if ( num2 < -16384 )
            {
                num2 = -16384;
            }
        }
        else
        {
            num2 = AppMain.gmGmkTarzanRopeGetUserTimerCurrentAngle( parent_obj );
        }
        switch ( num )
        {
            case 0:
                {
                    ushort num3 = (ushort)((parent_obj.pos.y >> 12) - 32);
                    ushort num4 = (ushort)(parent_obj2.pos.y >> 12);
                    gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294901760U;
                    if ( num4 > num3 )
                    {
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= ( uint )( num4 - num3 );
                    }
                    break;
                }
            case 1:
                {
                    ushort num3 = (ushort)(parent_obj.pos.x >> 12);
                    ushort num4 = (ushort)(parent_obj2.pos.x >> 12);
                    gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294901760U;
                    if ( num4 < num3 )
                    {
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= ( uint )( num3 - num4 );
                    }
                    break;
                }
            case 2:
                {
                    ushort num3 = (ushort)(parent_obj.pos.x >> 12);
                    ushort num4 = (ushort)(parent_obj2.pos.x >> 12);
                    gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294901760U;
                    if ( num4 > num3 )
                    {
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= ( uint )( num4 - num3 );
                    }
                    break;
                }
        }
        AppMain.gmGmkTarzanRopeSetUserWorkTargetAngle( parent_obj, num2 );
        num = 0;
        AppMain.gmGmkTarzanRopeeSetUserFlagType( parent_obj, num );
        AppMain.gmGmkTarzanRopeSetRect( gms_ENEMY_3D_WORK, num );
        parent_obj2.spd_m = 0;
        parent_obj2.spd.x = 0;
        parent_obj2.spd.y = 0;
        parent_obj2.dir.z = 0;
    }

    // Token: 0x0600053C RID: 1340 RVA: 0x0002C584 File Offset: 0x0002A784
    private static int gmGmkTarzanRopeUpdateAngleCurrent( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current )
    {
        int num = AppMain.MTM_MATH_ABS(angle_target);
        int num2 = AppMain.MTM_MATH_ABS(angle_current);
        int num3 = 1920;
        float num4 = (float)(num - num2) / 20480f;
        if ( num4 > 0.55f )
        {
            num4 = 0.55f;
        }
        else if ( num4 < -0.55f )
        {
            num4 = -0.55f;
        }
        num3 = ( int )( ( float )num3 * ( AppMain.MTM_MATH_ABS( num4 ) + 0.05f ) );
        if ( angle_target < angle_current )
        {
            num3 = -num3;
        }
        return AppMain.gmGmkTarzanRopeAddUserTimerCurrentAngle( obj_work, num3 );
    }

    // Token: 0x0600053D RID: 1341 RVA: 0x0002C5F0 File Offset: 0x0002A7F0
    private static int gmGmkTarzanRopeUpdateAngleTarget( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current, bool flag_motion_change )
    {
        if ( angle_target > 0 )
        {
            angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, -48 );
            if ( angle_target > 16384 )
            {
                angle_target = 16384;
            }
            else if ( angle_target < 0 )
            {
                angle_target = 0;
            }
            if ( angle_current >= angle_target )
            {
                angle_target = -angle_target;
                AppMain.gmGmkTarzanRopeSetUserWorkTargetAngle( obj_work, angle_target );
                if ( flag_motion_change )
                {
                    AppMain.gmGmkTarzanRopeChangeDirMotion( obj_work, angle_current );
                }
            }
        }
        else if ( angle_target < 0 )
        {
            angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, 48 );
            if ( angle_target < -16384 )
            {
                angle_target = -16384;
            }
            else if ( angle_target > 0 )
            {
                angle_target = 0;
            }
            if ( angle_current <= angle_target )
            {
                angle_target = -angle_target;
                AppMain.gmGmkTarzanRopeSetUserWorkTargetAngle( obj_work, angle_target );
                if ( flag_motion_change )
                {
                    AppMain.gmGmkTarzanRopeChangeDirMotion( obj_work, angle_current );
                }
            }
        }
        return angle_target;
    }

    // Token: 0x0600053E RID: 1342 RVA: 0x0002C680 File Offset: 0x0002A880
    private static void gmGmkTarzanRopeChangeDirMotion( AppMain.OBS_OBJECT_WORK obj_work, int angle_current )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work2.obj_3d;
        float num = AppMain.amMotionGetStartFrame(obj_3d.motion, obj_3d.act_id[0]);
        float num2 = 34f;
        if ( ( obj_work2.disp_flag & 1U ) != 0U )
        {
            if ( angle_current < 0 )
            {
                obj_3d.frame[0] = num;
            }
            else if ( angle_current > 0 )
            {
                obj_3d.frame[0] = num2;
            }
        }
        else if ( angle_current < 0 )
        {
            obj_3d.frame[0] = num2;
        }
        else if ( angle_current > 0 )
        {
            obj_3d.frame[0] = num;
        }
        obj_work2.disp_flag &= 4294967279U;
    }

    // Token: 0x0600053F RID: 1343 RVA: 0x0002C71C File Offset: 0x0002A91C
    private static void gmGmkTarzanRopeUpdatePlayerMotion( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current )
    {
        AppMain.UNREFERENCED_PARAMETER( obj_work );
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work2.obj_3d;
        float num = 34f;
        int num2 = AppMain.MTM_MATH_ABS(angle_target);
        int num3 = AppMain.MTM_MATH_ABS(angle_current);
        if ( num2 < 1792 && num3 < 1792 )
        {
            int a = AppMain.gmGmkTarzanRopeGetGimmickRotZ(gms_PLAYER_WORK);
            if ( gms_PLAYER_WORK.act_state != 64 && AppMain.MTM_MATH_ABS( a ) < 208 )
            {
                AppMain.GmPlayerActionChange( gms_PLAYER_WORK, 64 );
                obj_work2.disp_flag |= 4U;
            }
            return;
        }
        if ( gms_PLAYER_WORK.act_state == 64 )
        {
            AppMain.GmPlayerActionChange( gms_PLAYER_WORK, 63 );
            obj_work2.disp_flag |= 4U;
            return;
        }
        if ( ( obj_work2.disp_flag & 1U ) != 0U )
        {
            if ( angle_target > 0 && angle_current > 0 )
            {
                if ( obj_3d.frame[0] > num )
                {
                    obj_work2.disp_flag |= 16U;
                    return;
                }
            }
            else if ( angle_target < 0 && angle_current < 0 && obj_3d.frame[0] < num )
            {
                obj_work2.disp_flag |= 16U;
                return;
            }
        }
        else if ( angle_target > 0 && angle_current > 0 )
        {
            if ( obj_3d.frame[0] < num )
            {
                obj_work2.disp_flag |= 16U;
                return;
            }
        }
        else if ( angle_target < 0 && angle_current < 0 && obj_3d.frame[0] > num )
        {
            obj_work2.disp_flag |= 16U;
        }
    }

    // Token: 0x06000540 RID: 1344 RVA: 0x0002C860 File Offset: 0x0002AA60
    private static int gmGmkTarzanRopeApplyKeyLeft( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)target_obj;
        int num = AppMain.MTM_MATH_ABS(angle_target);
        int num2 = AppMain.MTM_MATH_ABS(angle_current);
        int num3 = AppMain.gmGmkTarzanRopeGetGimmickRotZ(ply_work);
        if ( num < 1792 && num2 < 1792 )
        {
            if ( num3 < 0 )
            {
                angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, -1792 );
            }
        }
        else if ( angle_target < 0 )
        {
            if ( num3 < 0 )
            {
                angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, -132 );
            }
            else if ( num3 > 0 )
            {
                angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, 31 );
            }
        }
        return angle_target;
    }

    // Token: 0x06000541 RID: 1345 RVA: 0x0002C8EC File Offset: 0x0002AAEC
    private static int gmGmkTarzanRopeApplyKeyRight( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)target_obj;
        int num = AppMain.MTM_MATH_ABS(angle_target);
        int num2 = AppMain.MTM_MATH_ABS(angle_current);
        int num3 = AppMain.gmGmkTarzanRopeGetGimmickRotZ(ply_work);
        if ( num < 1792 && num2 < 1792 )
        {
            if ( num3 > 0 )
            {
                angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, 1792 );
            }
        }
        else if ( angle_target > 0 )
        {
            if ( num3 > 0 )
            {
                angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, 132 );
            }
            else if ( num3 < 0 )
            {
                angle_target = AppMain.gmGmkTarzanRopeAddUserWorkTargetAngle( obj_work, -31 );
            }
        }
        return angle_target;
    }

    // Token: 0x06000542 RID: 1346 RVA: 0x0002C978 File Offset: 0x0002AB78
    private static void gmGmkTarzanRopeCheckStop( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current )
    {
        int num = AppMain.MTM_MATH_ABS(angle_target);
        int num2 = AppMain.MTM_MATH_ABS(angle_current);
        if ( num < 208 && num2 < 208 )
        {
            AppMain.gmGmkTarzanRopeSetUserTimerCurrentAngle( obj_work, 0 );
            AppMain.gmGmkTarzanRopeSetUserWorkTargetAngle( obj_work, 0 );
        }
    }

    // Token: 0x06000543 RID: 1347 RVA: 0x0002C9B4 File Offset: 0x0002ABB4
    private static bool gmGmkTarzanRopeCheckPlayerJump( AppMain.OBS_OBJECT_WORK obj_work, int angle_target, int angle_current )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)target_obj;
        if ( AppMain.gmGmkTarzanRopeGetCatchWait( obj_work ) > 0U )
        {
            return false;
        }
        if ( AppMain.GmPlayerKeyCheckJumpKeyPush( ply_work ) )
        {
            target_obj.disp_flag &= 4294967279U;
            target_obj.spd_m = 0;
            target_obj.spd.x = 0;
            target_obj.spd.y = 0;
            target_obj.dir.z = 0;
            target_obj.spd_add.x = 0;
            target_obj.spd_add.y = 0;
            target_obj.spd_add.z = 0;
            float num = 1f + (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.left / 10000f;
            int num2 = (int)((float)angle_target * 0.8f * num);
            int num3 = (int)((float)AppMain.MTM_MATH_ABS(angle_current) * 2.3f * num);
            if ( angle_target == 0 && angle_current == 0 )
            {
                num2 = 0;
                num3 = 16384;
            }
            else if ( ( angle_target < 0 && 0 < angle_current ) || ( 0 < angle_target && angle_current < 0 ) )
            {
                if ( AppMain.MTM_MATH_ABS( angle_target + angle_current ) < 1792 )
                {
                    num2 = -num2;
                }
                else
                {
                    num2 = 0;
                    num3 = 16384;
                }
            }
            AppMain.GmPlySeqGmkInitGmkJump( ply_work, num2, -num3 );
            AppMain.GmPlySeqChangeSequenceState( ply_work, 17 );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTarzanRopeMainEnd );
            gms_ENEMY_3D_WORK.ene_com.target_obj = null;
            return true;
        }
        return false;
    }

    // Token: 0x06000544 RID: 1348 RVA: 0x0002CB04 File Offset: 0x0002AD04
    private static void gmGmkTarzanRopeUpdatePlayerPos( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK target_obj = gms_ENEMY_3D_WORK.ene_com.target_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)target_obj;
        AppMain.NNS_MATRIX nns_MATRIX = new AppMain.NNS_MATRIX();
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        nns_MATRIX.M11 = AppMain.g_gm_gmk_tarzan_rope_active_matrix.M11;
        nns_MATRIX.M22 = AppMain.g_gm_gmk_tarzan_rope_active_matrix.M00;
        nns_MATRIX.M21 = AppMain.g_gm_gmk_tarzan_rope_active_matrix.M01;
        nns_MATRIX.M12 = AppMain.g_gm_gmk_tarzan_rope_active_matrix.M10;
        nns_MATRIX.M03 = -5f;
        AppMain.AkMathNormalizeMtx( gms_PLAYER_WORK.ex_obj_mtx_r, nns_MATRIX );
        if ( ( target_obj.disp_flag & 1U ) != 0U )
        {
            gms_PLAYER_WORK.ex_obj_mtx_r.M21 = -gms_PLAYER_WORK.ex_obj_mtx_r.M21;
            gms_PLAYER_WORK.ex_obj_mtx_r.M12 = -gms_PLAYER_WORK.ex_obj_mtx_r.M12;
            nns_MATRIX.M03 = -nns_MATRIX.M03;
        }
        int num = (int)((int)(gms_ENEMY_3D_WORK.ene_com.enemy_flag & 65535U) << 12);
        num += 24576;
        if ( num > 393216 )
        {
            num = 393216;
        }
        gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294901760U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= ( uint )( num >> 12 );
        float num2 = (float)num / 393216f;
        num2 = -num2 * 20f;
        num2 += 15f;
        AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(0f, num2, 0f);
        AppMain.nnTransformVector( nns_VECTOR, nns_MATRIX, nns_VECTOR );
        target_obj.pos.x = AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_tarzan_rope_active_matrix.M03 + nns_VECTOR.z );
        target_obj.pos.y = -AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_tarzan_rope_active_matrix.M13 + nns_VECTOR.y );
        target_obj.pos.z = AppMain.FX_F32_TO_FX32( AppMain.g_gm_gmk_tarzan_rope_active_matrix.M23 + nns_VECTOR.x );
        gms_PLAYER_WORK.gmk_flag |= 32768U;
    }

    // Token: 0x06000545 RID: 1349 RVA: 0x0002CCE8 File Offset: 0x0002AEE8
    private static void gmGmkTarzanRopeMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || gms_PLAYER_WORK.seq_state == 22 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTarzanRopeMainEnd );
            gms_ENEMY_3D_WORK.ene_com.target_obj = null;
            gms_PLAYER_WORK.gmk_flag &= 4294934527U;
            return;
        }
        int angle_target = AppMain.gmGmkTarzanRopeGetUserWorkTargetAngle(obj_work);
        int angle_current = AppMain.gmGmkTarzanRopeGetUserTimerCurrentAngle(obj_work);
        AppMain.gmGmkTarzanRopeInitCatchWait( obj_work );
        if ( AppMain.gmGmkTarzanRopeCheckPlayerJump( obj_work, angle_target, angle_current ) )
        {
            return;
        }
        angle_current = AppMain.gmGmkTarzanRopeUpdateAngleCurrent( obj_work, angle_target, angle_current );
        angle_target = AppMain.gmGmkTarzanRopeUpdateAngleTarget( obj_work, angle_target, angle_current, true );
        AppMain.gmGmkTarzanRopeCheckStop( obj_work, angle_target, angle_current );
        AppMain.gmGmkTarzanRopeUpdatePlayerPos( obj_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTarzanRopeMainKey );
    }

    // Token: 0x06000546 RID: 1350 RVA: 0x0002CDA8 File Offset: 0x0002AFA8
    private static void gmGmkTarzanRopeMainKey( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || gms_PLAYER_WORK.seq_state == 22 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTarzanRopeMainEnd );
            gms_ENEMY_3D_WORK.ene_com.target_obj = null;
            gms_PLAYER_WORK.gmk_flag &= 4294934527U;
            return;
        }
        int num = AppMain.gmGmkTarzanRopeGetUserWorkTargetAngle(obj_work);
        int angle_current = AppMain.gmGmkTarzanRopeGetUserTimerCurrentAngle(obj_work);
        AppMain.gmGmkTarzanRopeUpdateCatchWait( obj_work );
        if ( AppMain.gmGmkTarzanRopeCheckPlayerJump( obj_work, num, angle_current ) )
        {
            return;
        }
        if ( num <= 0 )
        {
            num = AppMain.gmGmkTarzanRopeApplyKeyLeft( obj_work, num, angle_current );
        }
        if ( num >= 0 )
        {
            num = AppMain.gmGmkTarzanRopeApplyKeyRight( obj_work, num, angle_current );
        }
        angle_current = AppMain.gmGmkTarzanRopeUpdateAngleCurrent( obj_work, num, angle_current );
        num = AppMain.gmGmkTarzanRopeUpdateAngleTarget( obj_work, num, angle_current, true );
        AppMain.gmGmkTarzanRopeUpdatePlayerMotion( obj_work, num, angle_current );
        AppMain.gmGmkTarzanRopeCheckStop( obj_work, num, angle_current );
        AppMain.gmGmkTarzanRopeUpdatePlayerPos( obj_work );
    }

    // Token: 0x06000547 RID: 1351 RVA: 0x0002CE78 File Offset: 0x0002B078
    private static void gmGmkTarzanRopeMainEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int angle_target = AppMain.gmGmkTarzanRopeGetUserWorkTargetAngle(obj_work);
        int angle_current = AppMain.gmGmkTarzanRopeGetUserTimerCurrentAngle(obj_work);
        AppMain.gmGmkTarzanRopeUpdateAngleCurrent( obj_work, angle_target, angle_current );
        AppMain.gmGmkTarzanRopeUpdateAngleTarget( obj_work, angle_target, angle_current, false );
        AppMain.gmGmkTarzanRopeCheckStop( obj_work, angle_target, angle_current );
    }

    // Token: 0x06000548 RID: 1352 RVA: 0x0002CEB0 File Offset: 0x0002B0B0
    private static int gmGmkTarzanRopeGetGimmickRotZ( AppMain.GMS_PLAYER_WORK ply_work )
    {
        int num = AppMain.GmPlayerKeyGetGimmickRotZ(ply_work);
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) == 0U )
        {
            num = num;
        }
        return num;
    }

    // Token: 0x06000549 RID: 1353 RVA: 0x0002CED5 File Offset: 0x0002B0D5
    private static void gmGmkTarzanRopeSetUserWorkTargetAngle( AppMain.OBS_OBJECT_WORK obj_work, int angle )
    {
        obj_work.user_work = ( uint )angle;
    }

    // Token: 0x0600054A RID: 1354 RVA: 0x0002CEDE File Offset: 0x0002B0DE
    private static int gmGmkTarzanRopeGetUserWorkTargetAngle( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( int )obj_work.user_work;
    }

    // Token: 0x0600054B RID: 1355 RVA: 0x0002CEE6 File Offset: 0x0002B0E6
    private static int gmGmkTarzanRopeAddUserWorkTargetAngle( AppMain.OBS_OBJECT_WORK obj_work, int angle )
    {
        obj_work.user_work += ( uint )angle;
        return ( int )obj_work.user_work;
    }

    // Token: 0x0600054C RID: 1356 RVA: 0x0002CEFC File Offset: 0x0002B0FC
    private static void gmGmkTarzanRopeSetUserTimerCurrentAngle( AppMain.OBS_OBJECT_WORK obj_work, int angle )
    {
        obj_work.user_timer = angle;
    }

    // Token: 0x0600054D RID: 1357 RVA: 0x0002CF05 File Offset: 0x0002B105
    private static int gmGmkTarzanRopeGetUserTimerCurrentAngle( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.user_timer;
    }

    // Token: 0x0600054E RID: 1358 RVA: 0x0002CF0D File Offset: 0x0002B10D
    private static int gmGmkTarzanRopeAddUserTimerCurrentAngle( AppMain.OBS_OBJECT_WORK obj_work, int angle )
    {
        obj_work.user_timer += angle;
        return obj_work.user_timer;
    }

    // Token: 0x0600054F RID: 1359 RVA: 0x0002CF23 File Offset: 0x0002B123
    private static void gmGmkTarzanRopeeSetUserFlagType( AppMain.OBS_OBJECT_WORK obj_work, int type )
    {
        obj_work.user_flag |= ( uint )( ( uint )( ( ushort )type ) << 16 );
    }

    // Token: 0x06000550 RID: 1360 RVA: 0x0002CF37 File Offset: 0x0002B137
    private static int gmGmkTarzanRopeGetUserFlagType( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( int )( obj_work.user_flag >> 16 );
    }

    // Token: 0x06000551 RID: 1361 RVA: 0x0002CF42 File Offset: 0x0002B142
    private static void gmGmkTarzanRopeInitCatchWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_flag |= 10U;
    }

    // Token: 0x06000552 RID: 1362 RVA: 0x0002CF54 File Offset: 0x0002B154
    private static void gmGmkTarzanRopeUpdateCatchWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        uint num = obj_work.user_flag & 255U;
        if ( num > 0U )
        {
            num -= 1U;
        }
        obj_work.user_flag = ( uint )( ( ( ulong )obj_work.user_flag & 18446744073709551360UL ) | ( ulong )num );
    }

    // Token: 0x06000553 RID: 1363 RVA: 0x0002CF90 File Offset: 0x0002B190
    private static uint gmGmkTarzanRopeGetCatchWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return obj_work.user_flag & 255U;
    }
}