using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001011 RID: 4113 RVA: 0x0008BE68 File Offset: 0x0008A068
    public static AppMain.OBS_OBJECT_WORK GmGmkBubbleManagerInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkBubbleLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkBubbleManagerInit( obj_work );
        AppMain.gmGmkBubbleSetUserWorkIntervalNormal( obj_work, ( ushort )( eve_rec.left * 60 ) );
        return obj_work;
    }

    // Token: 0x06001012 RID: 4114 RVA: 0x0008BEAC File Offset: 0x0008A0AC
    public static AppMain.GMS_ENEMY_3D_WORK gmGmkBubbleLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_BUBBLE");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06001013 RID: 4115 RVA: 0x0008BF20 File Offset: 0x0008A120
    public static ushort gmGmkBubbleGameSystemGetWaterLevel()
    {
        return AppMain.g_gm_main_system.water_level;
    }

    // Token: 0x06001014 RID: 4116 RVA: 0x0008BF2C File Offset: 0x0008A12C
    public static void gmGmkBubbleManagerInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.move_flag |= 8448U;
        AppMain.gmGmkBubbleSetUserTimerCounter( obj_work, 0U );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleManagerMainWait );
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 2, 4);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleManagerEffectMain );
    }

    // Token: 0x06001015 RID: 4117 RVA: 0x0008BF8C File Offset: 0x0008A18C
    public static void gmGmkBubbleManagerMainWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = (int)(AppMain.gmGmkBubbleGameSystemGetWaterLevel() * 4096);
        if ( num > obj_work.pos.y )
        {
            return;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        uint num2 = AppMain.gmGmkBubbleGetUserTimerCounter(obj_work);
        if ( ( uint )( gms_ENEMY_3D_WORK.ene_com.eve_rec.top * 60 ) < num2 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleManagerMain );
        }
        AppMain.gmGmkBubbleAddUserTimerCounter( obj_work, 1 );
    }

    // Token: 0x06001016 RID: 4118 RVA: 0x0008BFF4 File Offset: 0x0008A1F4
    public static void gmGmkBubbleManagerMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = (int)(AppMain.gmGmkBubbleGameSystemGetWaterLevel() * 4096);
        if ( num > obj_work.pos.y )
        {
            return;
        }
        uint num2 = (uint)AppMain.gmGmkBubbleGetUserWorkIntervalNormal(obj_work);
        if ( num2 == 0U )
        {
            num2 = 60U;
        }
        uint num3 = AppMain.gmGmkBubbleGetUserTimerCounter(obj_work);
        if ( num3 % num2 == 0U )
        {
            AppMain.GMS_EFFECT_3DES_WORK effect_work = AppMain.GmEfctZoneEsCreate(obj_work, 2, 1);
            AppMain.gmGmkBubbleInit( effect_work );
        }
        AppMain.gmGmkBubbleAddUserTimerCounter( obj_work, 1 );
    }

    // Token: 0x06001017 RID: 4119 RVA: 0x0008C04C File Offset: 0x0008A24C
    public static void gmGmkBubbleManagerEffectMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int num = (int)(AppMain.gmGmkBubbleGameSystemGetWaterLevel() * 4096);
        if ( num > obj_work.pos.y )
        {
            obj_work.disp_flag |= 32U;
            return;
        }
        obj_work.disp_flag &= 4294967263U;
    }

    // Token: 0x06001018 RID: 4120 RVA: 0x0008C094 File Offset: 0x0008A294
    public static void gmGmkBubbleInit( AppMain.GMS_EFFECT_3DES_WORK effect_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)effect_work;
        obs_OBJECT_WORK.flag &= 4294967293U;
        obs_OBJECT_WORK.move_flag &= 4294958847U;
        obs_OBJECT_WORK.move_flag |= 4608U;
        obs_OBJECT_WORK.spd.y = ( int )( -( int )AppMain.GMD_GMK_BUBBLE_SPEED_Y );
        obs_OBJECT_WORK.pos.z = 1048576;
        AppMain.OBS_RECT_WORK[] rect_work = effect_work.efct_com.rect_work;
        AppMain.GmEffectRectInit( effect_work.efct_com, AppMain.gm_gmk_bubble_table_atk, AppMain.gm_gmk_bubble_table_def, 1, 1 );
        AppMain.ObjRectWorkSet( rect_work[0], -8, 7, 8, 8 );
        rect_work[0].flag |= 1028U;
        rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkBubbleDefFunc );
        rect_work[1].flag |= 3072U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleMainMoveLeft );
    }

    // Token: 0x06001019 RID: 4121 RVA: 0x0008C17C File Offset: 0x0008A37C
    public static void gmGmkBubbleDefFunc( AppMain.OBS_RECT_WORK own_rect, AppMain.OBS_RECT_WORK target_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = own_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = target_rect.parent_obj;
        if ( parent_obj2.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        AppMain.GmPlySeqInitBreathing( ply_work );
        AppMain.GmPlayerBreathingSet( ply_work );
        parent_obj.flag |= 4U;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(null, 2, 3);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj.pos.x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj.pos.y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = parent_obj.pos.z;
        AppMain.GMM_PAD_VIB_SMALL();
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleMainHit );
    }

    // Token: 0x0600101A RID: 4122 RVA: 0x0008C24C File Offset: 0x0008A44C
    public static void gmGmkBubbleMainMoveLeft( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.x = AppMain.gmGmkBubbleAddUserWorkSpeedX( obj_work, ( int )( -( int )AppMain.GMD_GMK_BUBBLE_SPEED_X_ADD ) );
        if ( ( long )obj_work.spd.x < -AppMain.GMD_GMK_BUBBLE_SPEED_X_MAX )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleMainMoveRight );
        }
        int num = (int)(AppMain.gmGmkBubbleGameSystemGetWaterLevel() * 4096);
        if ( num > obj_work.pos.y )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleMainEnd );
        }
    }

    // Token: 0x0600101B RID: 4123 RVA: 0x0008C2C4 File Offset: 0x0008A4C4
    public static void gmGmkBubbleMainMoveRight( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.spd.x = AppMain.gmGmkBubbleAddUserWorkSpeedX( obj_work, ( int )AppMain.GMD_GMK_BUBBLE_SPEED_X_ADD );
        if ( ( long )obj_work.spd.x > AppMain.GMD_GMK_BUBBLE_SPEED_X_MAX )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleMainMoveLeft );
        }
        int num = (int)(AppMain.gmGmkBubbleGameSystemGetWaterLevel() * 4096);
        if ( num > obj_work.pos.y )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBubbleMainEnd );
        }
    }

    // Token: 0x0600101C RID: 4124 RVA: 0x0008C33C File Offset: 0x0008A53C
    public static void gmGmkBubbleMainHit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer++;
        int num = AppMain.GMD_GMK_BUBBLE_FRAME_HIT_DELETE - obj_work.user_timer;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( num < AppMain.GMD_GMK_BUBBLE_HIT_EFFECT_NUM )
        {
            AppMain.GmPlyEfctCreateBubble( gms_PLAYER_WORK );
        }
        if ( num > 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_PLAYER_WORK;
            int num2 = obs_OBJECT_WORK.pos.x - obj_work.pos.x;
            int num3 = obs_OBJECT_WORK.pos.y - AppMain.GMD_GMK_BUBBLE_OFFSET_Y * 4096 - obj_work.pos.y;
            if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
            {
                num2 -= AppMain.GMD_GMK_BUBBLE_OFFSET_X * 4096;
            }
            else
            {
                num2 += AppMain.GMD_GMK_BUBBLE_OFFSET_X * 4096;
            }
            obj_work.spd.x = num2 / num;
            obj_work.spd.y = num3 / num;
            return;
        }
        obj_work.user_timer = 0;
        obj_work.flag |= 4U;
    }

    // Token: 0x0600101D RID: 4125 RVA: 0x0008C428 File Offset: 0x0008A628
    public static void gmGmkBubbleMainEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.flag |= 4U;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(null, 2, 2);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = obj_work.pos.x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = obj_work.pos.y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = obj_work.pos.z;
    }

    // Token: 0x0600101E RID: 4126 RVA: 0x0008C4AC File Offset: 0x0008A6AC
    public static void gmGmkBubbleSetUserWorkIntervalNormal( AppMain.OBS_OBJECT_WORK obj_work, ushort interval )
    {
        obj_work.user_work |= ( uint )( ( uint )interval << 16 );
    }

    // Token: 0x0600101F RID: 4127 RVA: 0x0008C4BF File Offset: 0x0008A6BF
    public static ushort gmGmkBubbleGetUserWorkIntervalNormal( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( ushort )( obj_work.user_work >> 16 );
    }

    // Token: 0x06001020 RID: 4128 RVA: 0x0008C4CB File Offset: 0x0008A6CB
    public static void gmGmkBubbleSetUserTimerCounter( AppMain.OBS_OBJECT_WORK obj_work, uint count )
    {
        obj_work.user_timer = ( int )count;
    }

    // Token: 0x06001021 RID: 4129 RVA: 0x0008C4D4 File Offset: 0x0008A6D4
    public static void gmGmkBubbleAddUserTimerCounter( AppMain.OBS_OBJECT_WORK obj_work, int count )
    {
        obj_work.user_timer += count;
    }

    // Token: 0x06001022 RID: 4130 RVA: 0x0008C4E4 File Offset: 0x0008A6E4
    public static uint gmGmkBubbleGetUserTimerCounter( AppMain.OBS_OBJECT_WORK obj_work )
    {
        return ( uint )obj_work.user_timer;
    }

    // Token: 0x06001023 RID: 4131 RVA: 0x0008C4EC File Offset: 0x0008A6EC
    public static int gmGmkBubbleAddUserWorkSpeedX( AppMain.OBS_OBJECT_WORK obj_work, int speed )
    {
        obj_work.user_work += ( uint )speed;
        return ( int )obj_work.user_work;
    }
}
