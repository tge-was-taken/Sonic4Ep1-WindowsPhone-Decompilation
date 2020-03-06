using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600077F RID: 1919 RVA: 0x00042460 File Offset: 0x00040660
    private static AppMain.OBS_OBJECT_WORK GmGmkBoss3RouteInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBoss3RouteLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkBoss3RouteInit( obj_work );
        return obj_work;
    }

    // Token: 0x06000780 RID: 1920 RVA: 0x00042494 File Offset: 0x00040694
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkBoss3RouteLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_BOSS3_ROUTE");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000781 RID: 1921 RVA: 0x00042508 File Offset: 0x00040708
    private static void gmGmkBoss3RouteInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 8448U;
        obj_work.flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss3RouteMainFunc );
        obj_work.ppOut = null;
        obj_work.ppMove = null;
    }

    // Token: 0x06000782 RID: 1922 RVA: 0x00042558 File Offset: 0x00040758
    private static bool gmGmkBoss3RouteCheckHit( AppMain.OBS_OBJECT_WORK target_obj_work, AppMain.OBS_OBJECT_WORK gimmick_obj_work )
    {
        int num = target_obj_work.pos.x - gimmick_obj_work.pos.x;
        int num2 = target_obj_work.pos.y - gimmick_obj_work.pos.y;
        if ( AppMain.MTM_MATH_ABS( num ) > 262144 || AppMain.MTM_MATH_ABS( num2 ) > 262144 )
        {
            return false;
        }
        int num3 = AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2);
        int num4 = AppMain.FX_Mul(262144, 262144);
        return num3 <= num4;
    }

    // Token: 0x06000783 RID: 1923 RVA: 0x000425D8 File Offset: 0x000407D8
    private static bool gmGmkBoss3RouteSetMoveParam( AppMain.OBS_OBJECT_WORK target_obj_work, AppMain.OBS_OBJECT_WORK gimmick_obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gimmick_obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        float num = (float)gms_ENEMY_3D_WORK.ene_com.eve_rec.width / 10f;
        if ( gms_PLAYER_WORK.obj_work.pos.y >= target_obj_work.pos.y && ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 && AppMain.ObjViewOutCheck( target_obj_work.pos.x, target_obj_work.pos.y, 96, 0, 0, 0, 0 ) != 0 )
        {
            target_obj_work.spd.x = 0;
            target_obj_work.spd.y = 0;
            return false;
        }
        int x = gimmick_obj_work.pos.x + (int)(gms_ENEMY_3D_WORK.ene_com.eve_rec.left * 64) * 4096;
        int x2 = gimmick_obj_work.pos.y + (int)(gms_ENEMY_3D_WORK.ene_com.eve_rec.top * 64) * 4096;
        float num2 = AppMain.FX_FX32_TO_F32(x);
        float num3 = AppMain.FX_FX32_TO_F32(x2);
        float num4 = AppMain.FX_FX32_TO_F32(target_obj_work.pos.x);
        float num5 = AppMain.FX_FX32_TO_F32(target_obj_work.pos.y);
        float num6 = num2 - num4;
        float num7 = num3 - num5;
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.amVectorSet( nns_VECTOR, num6, num7, 0f );
        float num8 = 1f / AppMain.nnLengthVector(nns_VECTOR);
        float x3 = num6 * num8 * num;
        float x4 = num7 * num8 * num;
        target_obj_work.spd.x = AppMain.FX_F32_TO_FX32( x3 );
        target_obj_work.spd.y = AppMain.FX_F32_TO_FX32( x4 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        return true;
    }

    // Token: 0x06000784 RID: 1924 RVA: 0x00042774 File Offset: 0x00040974
    private static void gmGmkBoss3RouteMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, 2 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, 2 ) )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_COM_WORK.eve_rec.id == 319 )
            {
                if ( AppMain.gmGmkBoss3RouteCheckHit( obs_OBJECT_WORK, obj_work ) )
                {
                    if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 2 ) != 0 )
                    {
                        obs_OBJECT_WORK.spd.x = 0;
                        obs_OBJECT_WORK.spd.y = 0;
                        obs_OBJECT_WORK.user_flag = 1U;
                        obj_work.flag |= 4U;
                        obj_work.ppFunc = null;
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 65536U;
                        return;
                    }
                    if ( AppMain.gmGmkBoss3RouteSetMoveParam( obs_OBJECT_WORK, obj_work ) )
                    {
                        obj_work.flag |= 4U;
                        obj_work.ppFunc = null;
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 65536U;
                    }
                }
                return;
            }
        }
    }
}