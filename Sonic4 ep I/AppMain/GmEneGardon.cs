using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020003D3 RID: 979
    public class GMS_ENE_GARDON_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600284E RID: 10318 RVA: 0x00152B29 File Offset: 0x00150D29
        public GMS_ENE_GARDON_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600284F RID: 10319 RVA: 0x00152B3D File Offset: 0x00150D3D
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06002850 RID: 10320 RVA: 0x00152B4F File Offset: 0x00150D4F
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_GARDON_WORK work )
        {
            return work.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x0400623E RID: 25150
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x0400623F RID: 25151
        public int spd_dec;

        // Token: 0x04006240 RID: 25152
        public int spd_dec_dist;

        // Token: 0x04006241 RID: 25153
        public int timer;

        // Token: 0x04006242 RID: 25154
        public int shield;
    }

    // Token: 0x06001B54 RID: 6996 RVA: 0x000F9F74 File Offset: 0x000F8174
    private static void GmEneGardonBuild()
    {
        AppMain.gm_ene_gardon_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 677 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 678 ) ), 0U );
    }

    // Token: 0x06001B55 RID: 6997 RVA: 0x000F9FA0 File Offset: 0x000F81A0
    private static void GmEneGardonFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(677));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_gardon_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001B56 RID: 6998 RVA: 0x000F9FD4 File Offset: 0x000F81D4
    private static AppMain.OBS_OBJECT_WORK GmEneGardonInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_GARDON_WORK(), "ENE_GARDON");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_gardon_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 679 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -24, 11, 0 );
        obs_RECT_WORK.flag |= 1024U;
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmEneGardonDefFunc );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -24, -32, 24, 0 );
        obs_RECT_WORK.flag |= 1024U;
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag &= 4294967291U;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -4, -8, 4, -2 );
        obs_OBJECT_WORK.move_flag |= 128U;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_GARDON_WORK.spd_dec = 51;
        gms_ENE_GARDON_WORK.spd_dec_dist = 10240;
        AppMain.gmEneGardonWalkInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B57 RID: 6999 RVA: 0x000FA1DC File Offset: 0x000F83DC
    private static int gmEneGardonGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
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

    // Token: 0x06001B58 RID: 7000 RVA: 0x000FA260 File Offset: 0x000F8460
    private static int gmEneGardonIsPlayerAttack()
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.seq_state == 19 || gms_PLAYER_WORK.seq_state == 17 || gms_PLAYER_WORK.seq_state == 10 )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001B59 RID: 7001 RVA: 0x000FA29C File Offset: 0x000F849C
    private static int gmEneGardonIsPlayerFront( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            if ( obj_work.pos.x > gms_PLAYER_WORK.obj_work.pos.x )
            {
                return 1;
            }
        }
        else if ( obj_work.pos.x < gms_PLAYER_WORK.obj_work.pos.x )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06001B5A RID: 7002 RVA: 0x000FA300 File Offset: 0x000F8500
    private static void gmEneGardonAtkRectOff( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        obs_RECT_WORK.flag &= 4294967291U;
    }

    // Token: 0x06001B5B RID: 7003 RVA: 0x000FA334 File Offset: 0x000F8534
    private static void gmEneGardonAtkRectOn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        obs_RECT_WORK.flag |= 4U;
    }

    // Token: 0x06001B5C RID: 7004 RVA: 0x000FA364 File Offset: 0x000F8564
    private static void gmEneGardonDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = my_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj2 = your_rect.parent_obj;
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)parent_obj2;
        if ( parent_obj2 != null && 1 == parent_obj2.obj_type )
        {
            if ( gms_PLAYER_WORK.seq_state == 19 || gms_PLAYER_WORK.seq_state == 20 )
            {
                if ( AppMain.gmEneGardonIsPlayerFront( parent_obj ) != 0 )
                {
                    AppMain.GmEneComActionSetDependHFlip( parent_obj, 8, 9 );
                    parent_obj.disp_flag &= 4294967291U;
                    gms_ENE_GARDON_WORK.shield = 1;
                    AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
                    gms_PLAYER_WORK.obj_work.spd.y = ( int )( ( float )gms_PLAYER_WORK.obj_work.spd.y * 1.5f );
                    AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate(parent_obj, 5);
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj.pos.x;
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj.pos.y;
                    AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 30f, 0f );
                    AppMain.GmSoundPlaySE( "Casino1" );
                    AppMain.gmEneGardonAtkRectOff( parent_obj );
                    return;
                }
                AppMain.GmEnemyDefaultDefFunc( my_rect, your_rect );
                return;
            }
            else if ( parent_obj.pos.y - AppMain.FX_F32_TO_FX32( 20f ) > parent_obj2.pos.y )
            {
                if ( AppMain.gmEneGardonIsPlayerFront( parent_obj ) != 0 || ( parent_obj.disp_flag & 1U ) != ( parent_obj2.disp_flag & 1U ) )
                {
                    AppMain.GmEneComActionSetDependHFlip( parent_obj, 8, 9 );
                    parent_obj.disp_flag &= 4294967291U;
                    gms_ENE_GARDON_WORK.shield = 1;
                    AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
                    gms_PLAYER_WORK.obj_work.spd.y = ( int )( ( float )gms_PLAYER_WORK.obj_work.spd.y * 1.5f );
                    AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate(parent_obj, 5);
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj.pos.x;
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj.pos.y;
                    AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, 0f, 30f, 0f );
                    AppMain.GmSoundPlaySE( "Casino1" );
                    return;
                }
                AppMain.GmEnemyDefaultDefFunc( my_rect, your_rect );
                return;
            }
            else
            {
                if ( AppMain.gmEneGardonIsPlayerFront( parent_obj ) != 0 )
                {
                    AppMain.GmEneComActionSetDependHFlip( parent_obj, 4, 5 );
                    parent_obj.disp_flag &= 4294967291U;
                    gms_ENE_GARDON_WORK.shield = 2;
                    gms_PLAYER_WORK.obj_work.disp_flag ^= 1U;
                    AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 10 );
                    if ( gms_PLAYER_WORK.obj_work.spd_m != 0 )
                    {
                        gms_PLAYER_WORK.obj_work.spd_m = -gms_PLAYER_WORK.obj_work.spd_m;
                        if ( AppMain.MTM_MATH_ABS( gms_PLAYER_WORK.obj_work.spd_m ) < 32768 )
                        {
                            if ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) != 0U )
                            {
                                gms_PLAYER_WORK.obj_work.spd_m = -32768;
                            }
                            else
                            {
                                gms_PLAYER_WORK.obj_work.spd_m = 32768;
                            }
                        }
                    }
                    else if ( parent_obj.pos.x > gms_PLAYER_WORK.obj_work.pos.x )
                    {
                        gms_PLAYER_WORK.obj_work.spd_m = -49152;
                        gms_PLAYER_WORK.obj_work.disp_flag |= 1U;
                    }
                    else
                    {
                        gms_PLAYER_WORK.obj_work.spd_m = 49152;
                        gms_PLAYER_WORK.obj_work.disp_flag &= 4294967294U;
                    }
                    AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate(parent_obj, 5);
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = parent_obj.pos.x;
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = parent_obj.pos.y;
                    AppMain.GmSoundPlaySE( "Casino1" );
                    return;
                }
                AppMain.GmEnemyDefaultDefFunc( my_rect, your_rect );
            }
        }
    }

    // Token: 0x06001B5D RID: 7005 RVA: 0x000FA708 File Offset: 0x000F8908
    private static void gmEneGardonWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWalkMain );
        obj_work.move_flag &= 4294967291U;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -1024;
            return;
        }
        obj_work.spd.x = 1024;
    }

    // Token: 0x06001B5E RID: 7006 RVA: 0x000FA780 File Offset: 0x000F8980
    private static void gmEneGardonWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obj_work;
        if ( gms_ENE_GARDON_WORK.shield != 0 )
        {
            obj_work.spd.x = 0;
            if ( ( obj_work.disp_flag & 8U ) != 0U )
            {
                if ( gms_ENE_GARDON_WORK.shield == 1 )
                {
                    AppMain.GmEneComActionSetDependHFlip( obj_work, 10, 11 );
                }
                else
                {
                    AppMain.GmEneComActionSetDependHFlip( obj_work, 6, 7 );
                }
                AppMain.gmEneGardonAtkRectOn( obj_work );
                gms_ENE_GARDON_WORK.shield = 0;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWalkWait );
            }
            return;
        }
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -1024;
        }
        else
        {
            obj_work.spd.x = 1024;
        }
        if ( obj_work.obj_3d.frame[0] >= 40f && obj_work.obj_3d.frame[0] <= 60f )
        {
            obj_work.spd.x = 0;
        }
        if ( obj_work.obj_3d.frame[0] >= 100f && obj_work.obj_3d.frame[0] <= 120f )
        {
            obj_work.spd.x = 0;
        }
        if ( AppMain.gmEneGardonGetLength2N( obj_work ) <= 4 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWaitToWalkInit );
            return;
        }
        if ( ( obj_work.move_flag & 4U ) != 0U || AppMain.GmEneComCheckMoveLimit( obj_work, ( int )obj_work.user_work, ( int )obj_work.user_flag ) == 0 )
        {
            AppMain.gmEneGardonWaitToFlipInit( obj_work );
        }
    }

    // Token: 0x06001B5F RID: 7007 RVA: 0x000FA8C3 File Offset: 0x000F8AC3
    private static void gmEneGardonWalkWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWaitToWalkInit );
        }
    }

    // Token: 0x06001B60 RID: 7008 RVA: 0x000FA8E4 File Offset: 0x000F8AE4
    private static void gmEneGardonWaitToFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWaitToFlipMain );
        obj_work.spd.x = 0;
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obj_work;
        gms_ENE_GARDON_WORK.timer = 1;
        AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
    }

    // Token: 0x06001B61 RID: 7009 RVA: 0x000FA92C File Offset: 0x000F8B2C
    private static void gmEneGardonWaitToFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obj_work;
        if ( gms_ENE_GARDON_WORK.timer > 0 )
        {
            gms_ENE_GARDON_WORK.timer--;
            return;
        }
        AppMain.gmEneGardonFlipInit( obj_work );
    }

    // Token: 0x06001B62 RID: 7010 RVA: 0x000FA960 File Offset: 0x000F8B60
    private static void gmEneGardonWaitToWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWaitToWalkMain );
        obj_work.spd.x = 0;
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obj_work;
        gms_ENE_GARDON_WORK.timer = 60;
        AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
        obj_work.disp_flag |= 4U;
        AppMain.gmEneGardonAtkRectOn( obj_work );
        gms_ENE_GARDON_WORK.shield = 0;
    }

    // Token: 0x06001B63 RID: 7011 RVA: 0x000FA9C4 File Offset: 0x000F8BC4
    private static void gmEneGardonWaitToWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obj_work;
        if ( gms_ENE_GARDON_WORK.shield != 0 )
        {
            obj_work.spd.x = 0;
            if ( ( obj_work.disp_flag & 8U ) != 0U )
            {
                if ( gms_ENE_GARDON_WORK.shield == 1 )
                {
                    AppMain.GmEneComActionSetDependHFlip( obj_work, 10, 11 );
                }
                else
                {
                    AppMain.GmEneComActionSetDependHFlip( obj_work, 6, 7 );
                }
                AppMain.gmEneGardonAtkRectOn( obj_work );
                gms_ENE_GARDON_WORK.shield = 0;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWalkWait );
            }
            return;
        }
        if ( AppMain.gmEneGardonGetLength2N( obj_work ) > 4 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWalkInit );
        }
    }

    // Token: 0x06001B64 RID: 7012 RVA: 0x000FAA4E File Offset: 0x000F8C4E
    private static void gmEneGardonFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 2, 3 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonFlipMain );
    }

    // Token: 0x06001B65 RID: 7013 RVA: 0x000FAA74 File Offset: 0x000F8C74
    private static void gmEneGardonFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_GARDON_WORK gms_ENE_GARDON_WORK = (AppMain.GMS_ENE_GARDON_WORK)obj_work;
        if ( gms_ENE_GARDON_WORK.shield != 0 )
        {
            obj_work.disp_flag ^= 1U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneGardonWalkMain );
            return;
        }
        AppMain.gmEneGardonSetWalkSpeed( ( AppMain.GMS_ENE_GARDON_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneGardonWalkInit( obj_work );
        }
    }

    // Token: 0x06001B66 RID: 7014 RVA: 0x000FAADC File Offset: 0x000F8CDC
    private static int gmEneGardonSetWalkSpeed( AppMain.GMS_ENE_GARDON_WORK gardon_work )
    {
        int result = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gardon_work;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 2 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, gardon_work.spd_dec, 1024 );
            }
            else if ( obs_OBJECT_WORK.pos.x <= ( int )( obs_OBJECT_WORK.user_work + ( uint )gardon_work.spd_dec_dist ) )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, gardon_work.spd_dec );
                result = 1;
                if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x > ( int )obs_OBJECT_WORK.user_work )
                {
                    obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_work - ( uint )obs_OBJECT_WORK.pos.x );
                    if ( obs_OBJECT_WORK.spd.x < -gardon_work.spd_dec )
                    {
                        obs_OBJECT_WORK.spd.x = -gardon_work.spd_dec;
                    }
                }
            }
            else if ( obs_OBJECT_WORK.spd.x > -1024 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -gardon_work.spd_dec, 1024 );
            }
        }
        else if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 2 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -gardon_work.spd_dec, 1024 );
        }
        else if ( obs_OBJECT_WORK.pos.x >= ( int )( obs_OBJECT_WORK.user_flag - ( uint )gardon_work.spd_dec_dist ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, gardon_work.spd_dec );
            result = 1;
            if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x < ( int )obs_OBJECT_WORK.user_flag )
            {
                obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_flag - ( uint )obs_OBJECT_WORK.pos.x );
                if ( obs_OBJECT_WORK.spd.x > gardon_work.spd_dec )
                {
                    obs_OBJECT_WORK.spd.x = gardon_work.spd_dec;
                }
            }
        }
        else if ( obs_OBJECT_WORK.spd.x < 1024 )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, gardon_work.spd_dec, 1024 );
        }
        return result;
    }
}
