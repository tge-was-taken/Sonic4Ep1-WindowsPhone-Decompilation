using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000682 RID: 1666 RVA: 0x0003AB05 File Offset: 0x00038D05
    private static void GmGmkEnBmprBuild()
    {
        AppMain.g_gm_gmk_en_bmpr_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 852 ), AppMain.GmGameDatGetGimmickData( 853 ), 0U );
    }

    // Token: 0x06000683 RID: 1667 RVA: 0x0003AB28 File Offset: 0x00038D28
    private static void GmGmkEnBmprFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(852);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_en_bmpr_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_en_bmpr_obj_3d_list = null;
    }

    // Token: 0x06000684 RID: 1668 RVA: 0x0003AB58 File Offset: 0x00038D58
    private static AppMain.OBS_OBJECT_WORK GmGmkEnBmprInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int num = 3;
        if ( eve_rec.left > 0 && eve_rec.left < 3 )
        {
            num = ( int )eve_rec.left;
        }
        if ( num <= ( int )eve_rec.byte_param[1] )
        {
            return null;
        }
        int num2 = AppMain.gmGmkEnBmprCalcType((int)eve_rec.id);
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkEnBmprLoadObj(eve_rec, pos_x, pos_y, num2);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkEnBmprInit( obj_work, num2, num );
        return obj_work;
    }

    // Token: 0x06000685 RID: 1669 RVA: 0x0003ABB8 File Offset: 0x00038DB8
    private static uint gmGmkEnBmpreGameSystemGetSyncTime()
    {
        return AppMain.g_gm_main_system.sync_time;
    }

    // Token: 0x06000686 RID: 1670 RVA: 0x0003ABCC File Offset: 0x00038DCC
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkEnBmprLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_EN_BMPR");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000687 RID: 1671 RVA: 0x0003AC40 File Offset: 0x00038E40
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkEnBmprLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkEnBmprLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        int num = 3;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_en_bmpr_obj_3d_list[num], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.OBS_DATA_WORK data_work = AppMain.ObjDataGet(854);
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, 0, false, data_work, null, 0, null );
        AppMain.OBS_DATA_WORK data_work2 = AppMain.ObjDataGet(855);
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, 0, data_work2, null, 0, null );
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000688 RID: 1672 RVA: 0x0003ACA8 File Offset: 0x00038EA8
    private static void gmGmkEnBmprInit( AppMain.OBS_OBJECT_WORK obj_work, int en_bmpr_type, int life_max )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.gmGmkEnBmprSetRect( gms_ENEMY_3D_WORK, en_bmpr_type );
        obj_work.move_flag = 8448U;
        obj_work.user_flag |= 1U;
        obj_work.dir.z = AppMain.g_gm_gmk_en_bmpr_angle_z[en_bmpr_type];
        int num = life_max - (int)gms_ENEMY_3D_WORK.ene_com.eve_rec.byte_param[1];
        AppMain.gmGmkEnBmperSetUserWorkLife( obj_work, num );
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, AppMain.g_gm_gmk_en_bmpr_mat_motion_id[num] );
        obj_work.disp_flag |= 4194308U;
        obj_work.pos.z = -122880;
        obj_work.ppFunc = null;
        obj_work.ppMove = null;
        obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkEnBmprDrawFunc );
        AppMain.gmGmkEnBmprChangeModeWait( obj_work );
    }

    // Token: 0x06000689 RID: 1673 RVA: 0x0003AD60 File Offset: 0x00038F60
    private static void gmGmkEnBmprSetRect( AppMain.GMS_ENEMY_3D_WORK gimmick_work, int en_bmpr_type )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gimmick_work.ene_com.rect_work[2];
        short cLeft = AppMain.g_gmk_en_bmpr_rect[en_bmpr_type][0];
        short cRight = AppMain.g_gmk_en_bmpr_rect[en_bmpr_type][2];
        short cTop = AppMain.g_gmk_en_bmpr_rect[en_bmpr_type][1];
        short cBottom = AppMain.g_gmk_en_bmpr_rect[en_bmpr_type][3];
        AppMain.ObjRectWorkZSet( obs_RECT_WORK, cLeft, cTop, -500, cRight, cBottom, 500 );
        obs_RECT_WORK.flag |= 1024U;
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkEnBmprDefFunc );
    }

    // Token: 0x0600068A RID: 1674 RVA: 0x0003ADEC File Offset: 0x00038FEC
    private static void gmGmkEnBmprDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        if ( obj_3d.motion != null )
        {
            float num = AppMain.amMotionMaterialGetStartFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num2 = AppMain.amMotionMaterialGetEndFrame(obj_3d.motion, obj_3d.mat_act_id);
            float num3 = num2 - num;
            float num4 = AppMain.gmGmkEnBmpreGameSystemGetSyncTime();
            obj_3d.mat_frame = num4 % num3;
        }
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x0600068B RID: 1675 RVA: 0x0003AE4C File Offset: 0x0003904C
    private static int gmGmkEnBmprCalcType( int id )
    {
        return id - 164;
    }

    // Token: 0x0600068C RID: 1676 RVA: 0x0003AE64 File Offset: 0x00039064
    private static AppMain.VecFx32 gmGmkEnBmprNormalizeVectorXY( AppMain.VecFx32 vec )
    {
        AppMain.VecFx32 result = default(AppMain.VecFx32);
        int num = AppMain.FX_Mul(vec.x, vec.x) + AppMain.FX_Mul(vec.y, vec.y);
        num = AppMain.FX_Sqrt( num );
        if ( num == 0 )
        {
            result.x = 4096;
            result.y = 0;
        }
        else
        {
            int v = AppMain.FX_Div(4096, num);
            result.x = AppMain.FX_Mul( vec.x, v );
            result.y = AppMain.FX_Mul( vec.y, v );
        }
        result.z = 0;
        return result;
    }

    // Token: 0x0600068D RID: 1677 RVA: 0x0003AF00 File Offset: 0x00039100
    private static void gmGmkEnBmprDefFunc( AppMain.OBS_RECT_WORK gimmick_rect, AppMain.OBS_RECT_WORK player_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = gimmick_rect.parent_obj;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = player_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        int num = AppMain.gmGmkEnBmprCalcType((int)gms_ENEMY_3D_WORK.ene_com.eve_rec.id);
        parent_obj.dir.z = AppMain.g_gm_gmk_en_bmpr_angle_z[num];
        parent_obj2.dir.z = 0;
        int num2 = parent_obj2.spd.x;
        int num3 = parent_obj2.spd.y;
        if ( ( parent_obj2.move_flag & 32768U ) != 0U )
        {
            if ( parent_obj2.spd_m != 0 )
            {
                num2 = AppMain.FX_Mul( parent_obj2.spd_m, AppMain.mtMathCos( ( int )parent_obj2.dir.z ) );
                num3 = AppMain.FX_Mul( parent_obj2.spd_m, AppMain.mtMathSin( ( int )parent_obj2.dir.z ) );
            }
            else
            {
                AppMain.VecFx32 vecFx = AppMain.gmGmkEnBmprNormalizeVectorXY(new AppMain.VecFx32
                {
                    x = parent_obj2.pos.x - parent_obj.pos.x,
                    y = parent_obj2.pos.y - parent_obj.pos.y,
                    z = 0
                });
                num2 = AppMain.FX_Mul( vecFx.x, 98304 );
                num3 = AppMain.FX_Mul( vecFx.y, 98304 );
            }
        }
        int num4 = -12288;
        int num5 = parent_obj2.pos.x - parent_obj.pos.x;
        int num6 = parent_obj2.pos.y + num4 - parent_obj.pos.y;
        switch ( num )
        {
            case 0:
                num2 = 0;
                if ( num6 < 0 )
                {
                    num3 = -24576;
                }
                else
                {
                    num3 = 24576;
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = parent_obj;
                    obs_OBJECT_WORK.dir.z = ( ushort )( obs_OBJECT_WORK.dir.z + 32768 );
                }
                break;
            case 1:
                {
                    int num7 = AppMain.FX_Mul(24576, 2896);
                    if ( num6 < 0 )
                    {
                        num2 = -num7;
                        num3 = -num7;
                    }
                    else
                    {
                        num2 = num7;
                        num3 = num7;
                        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = parent_obj;
                        obs_OBJECT_WORK2.dir.z = ( ushort )( obs_OBJECT_WORK2.dir.z + 32768 );
                    }
                    break;
                }
            case 2:
                num3 = 0;
                if ( num5 < 0 )
                {
                    num2 = -24576;
                }
                else
                {
                    num2 = 24576;
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = parent_obj;
                    obs_OBJECT_WORK3.dir.z = ( ushort )( obs_OBJECT_WORK3.dir.z + 32768 );
                }
                break;
            case 3:
                {
                    int num8 = AppMain.FX_Mul(24576, 2896);
                    if ( num6 > 0 )
                    {
                        num2 = -num8;
                        num3 = num8;
                    }
                    else
                    {
                        num2 = num8;
                        num3 = -num8;
                        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = parent_obj;
                        obs_OBJECT_WORK4.dir.z = ( ushort )( obs_OBJECT_WORK4.dir.z + 32768 );
                    }
                    break;
                }
        }
        AppMain.GmPlySeqInitPinballAir( ( AppMain.GMS_PLAYER_WORK )parent_obj2, num2, num3, 5 );
        AppMain.gmGmkEnBmprChangeModeHit( parent_obj );
        int num9 = AppMain.gmGmkEnBmperGetUserWorkLife(parent_obj);
        if ( num9 <= 0 )
        {
            parent_obj.user_flag = ( uint )( ( ulong )parent_obj.user_flag & 18446744073709551614UL );
        }
        int num10 = 10;
        if ( AppMain.gmGmkEnBmprCheckGroupBonus( parent_obj ) != 0 )
        {
            num10 *= 50;
        }
        AppMain.GmPlayerAddScore( ( AppMain.GMS_PLAYER_WORK )parent_obj2, num10, parent_obj.pos.x, parent_obj.pos.y );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(parent_obj, 16);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj2.pos.x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj2.pos.y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = ( ushort )( AppMain.nnArcTan2( ( double )AppMain.FX_FX32_TO_F32( num3 ), ( double )AppMain.FX_FX32_TO_F32( num2 ) ) - 16384 );
        AppMain.GMM_PAD_VIB_SMALL();
    }

    // Token: 0x0600068E RID: 1678 RVA: 0x0003B2A4 File Offset: 0x000394A4
    private static int gmGmkEnBmprCheckGroupBonus( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = AppMain.gmGmkEnBmperGetUserWorkLife(obj_work);
        if ( num > 0 )
        {
            return 0;
        }
        sbyte top = gms_ENEMY_3D_WORK.ene_com.eve_rec.top;
        if ( top == 0 )
        {
            return 0;
        }
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 3 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 3 ) )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
            if ( obs_OBJECT_WORK != obj_work && ( gms_ENEMY_COM_WORK.eve_rec.id == 164 || gms_ENEMY_COM_WORK.eve_rec.id == 165 || gms_ENEMY_COM_WORK.eve_rec.id == 166 || gms_ENEMY_COM_WORK.eve_rec.id == 167 ) && gms_ENEMY_COM_WORK.eve_rec.top == top && ( Convert.ToInt32( obs_OBJECT_WORK.user_flag ) & 1 ) != 0 )
            {
                return 0;
            }
        }
        return 1;
    }

    // Token: 0x0600068F RID: 1679 RVA: 0x0003B36F File Offset: 0x0003956F
    private static void gmGmkEnBmprChangeModeWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 0, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkEnBmprMainWait );
    }

    // Token: 0x06000690 RID: 1680 RVA: 0x0003B38C File Offset: 0x0003958C
    private static void gmGmkEnBmprChangeModeHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmSoundPlaySE( "Casino7" );
        byte b = 1;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        byte[] byte_param = gms_ENEMY_3D_WORK.ene_com.eve_rec.byte_param;
        int num = 1;
        byte_param[num] += b;
        int num2 = AppMain.gmGmkEnBmperAddUserWorkLife(obj_work, (int)(-(int)b));
        if ( num2 < 0 )
        {
            return;
        }
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obj_work, AppMain.g_gm_gmk_en_bmpr_mat_motion_id[num2] );
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 1, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkEnBmprMainHit );
    }

    // Token: 0x06000691 RID: 1681 RVA: 0x0003B408 File Offset: 0x00039608
    private static void gmGmkEnBmprChangeModeLost( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 0, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkEnBmprMainLost );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(null, 19);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = obj_work.pos.x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = obj_work.pos.y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 131072;
    }

    // Token: 0x06000692 RID: 1682 RVA: 0x0003B492 File Offset: 0x00039692
    private static void gmGmkEnBmprMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.UNREFERENCED_PARAMETER( obj_work );
    }

    // Token: 0x06000693 RID: 1683 RVA: 0x0003B49C File Offset: 0x0003969C
    private static void gmGmkEnBmprMainHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            int num = AppMain.gmGmkEnBmperGetUserWorkLife(obj_work);
            if ( num > 0 )
            {
                AppMain.gmGmkEnBmprChangeModeWait( obj_work );
                return;
            }
            AppMain.gmGmkEnBmprChangeModeLost( obj_work );
        }
    }

    // Token: 0x06000694 RID: 1684 RVA: 0x0003B4CB File Offset: 0x000396CB
    private static void gmGmkEnBmprMainLost( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.flag |= 4U;
    }

    // Token: 0x06000695 RID: 1685 RVA: 0x0003B4DB File Offset: 0x000396DB
    private static void gmGmkEnBmperSetUserWorkLife( AppMain.OBS_OBJECT_WORK obj_work, int life )
    {
        obj_work.user_work = ( uint )life;
    }

    // Token: 0x06000696 RID: 1686 RVA: 0x0003B4E4 File Offset: 0x000396E4
    private static int gmGmkEnBmperGetUserWorkLife( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( int )obj_work.user_work;
    }

    // Token: 0x06000697 RID: 1687 RVA: 0x0003B4EC File Offset: 0x000396EC
    private static int gmGmkEnBmperAddUserWorkLife( AppMain.OBS_OBJECT_WORK obj_work, int add )
    {
        obj_work.user_work += ( uint )add;
        return ( int )obj_work.user_work;
    }
}