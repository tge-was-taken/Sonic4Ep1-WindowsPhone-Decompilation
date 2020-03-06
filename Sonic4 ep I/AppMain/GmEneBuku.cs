using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020003D4 RID: 980
    public class GMS_ENE_BUKU_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002851 RID: 10321 RVA: 0x00152B61 File Offset: 0x00150D61
        public GMS_ENE_BUKU_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002852 RID: 10322 RVA: 0x00152B75 File Offset: 0x00150D75
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06002853 RID: 10323 RVA: 0x00152B87 File Offset: 0x00150D87
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_BUKU_WORK work )
        {
            return work.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x04006243 RID: 25155
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04006244 RID: 25156
        public int spd_dec;

        // Token: 0x04006245 RID: 25157
        public int spd_dec_dist;

        // Token: 0x04006246 RID: 25158
        public int timer;
    }

    // Token: 0x06001B67 RID: 7015 RVA: 0x000FAD6F File Offset: 0x000F8F6F
    private static void GmEneBukuBuild()
    {
        AppMain.gm_ene_buku_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 696 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 697 ) ), 0U );
    }

    // Token: 0x06001B68 RID: 7016 RVA: 0x000FAD9C File Offset: 0x000F8F9C
    private static void GmEneBukuFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(696));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_buku_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001B69 RID: 7017 RVA: 0x000FADD0 File Offset: 0x000F8FD0
    private static AppMain.OBS_OBJECT_WORK GmEneBukuInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_BUKU_WORK(), "ENE_BUKU");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_BUKU_WORK gms_ENE_BUKU_WORK = (AppMain.GMS_ENE_BUKU_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_buku_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 698 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -8, -8, 8, 8 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -16, 16, 16 );
        obs_RECT_WORK.flag |= 4U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -16, 19, 16 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_BUKU_WORK.spd_dec = 102;
        gms_ENE_BUKU_WORK.spd_dec_dist = 20480;
        AppMain.gmEneBukuWalkInit( obs_OBJECT_WORK );
        AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctEneEsCreate(obs_OBJECT_WORK, 9);
        AppMain.GmComEfctSetDispOffsetF( efct_work, -24f, -5f, 0f );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B6A RID: 7018 RVA: 0x000FAFC8 File Offset: 0x000F91C8
    private static void gmEneBukuWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneBukuWalkMain );
        obj_work.move_flag &= 4294967291U;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
            return;
        }
        obj_work.spd.x = 2048;
    }

    // Token: 0x06001B6B RID: 7019 RVA: 0x000FB040 File Offset: 0x000F9240
    private static void gmEneBukuWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_BUKU_WORK gms_ENE_BUKU_WORK = (AppMain.GMS_ENE_BUKU_WORK)obj_work;
        int num = AppMain.gmEneBukuSetWalkSpeed(gms_ENE_BUKU_WORK);
        if ( num != 0 )
        {
            AppMain.gmEneBukuFlipInit( obj_work );
        }
        if ( gms_ENE_BUKU_WORK.timer > 0 )
        {
            gms_ENE_BUKU_WORK.timer--;
            return;
        }
        gms_ENE_BUKU_WORK.timer = 216000 + ( int )( AppMain.mtMathRand() % 30 );
    }

    // Token: 0x06001B6C RID: 7020 RVA: 0x000FB090 File Offset: 0x000F9290
    private static void gmEneBukuFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneBukuFlipInit( obj_work );
        }
    }

    // Token: 0x06001B6D RID: 7021 RVA: 0x000FB0B2 File Offset: 0x000F92B2
    private static void gmEneBukuFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 2, 3 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneBukuFlipMain );
    }

    // Token: 0x06001B6E RID: 7022 RVA: 0x000FB0D5 File Offset: 0x000F92D5
    private static void gmEneBukuFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneBukuSetWalkSpeed( ( AppMain.GMS_ENE_BUKU_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneBukuWalkInit( obj_work );
        }
    }

    // Token: 0x06001B6F RID: 7023 RVA: 0x000FB104 File Offset: 0x000F9304
    private static int gmEneBukuSetWalkSpeed( AppMain.GMS_ENE_BUKU_WORK buku_work )
    {
        int result = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)buku_work;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 3 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, buku_work.spd_dec, 2048 );
            }
            else if ( obs_OBJECT_WORK.pos.x <= ( int )( obs_OBJECT_WORK.user_work + ( uint )buku_work.spd_dec_dist ) )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, buku_work.spd_dec );
                result = 1;
                if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x > ( int )obs_OBJECT_WORK.user_work )
                {
                    obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_work - ( uint )obs_OBJECT_WORK.pos.x );
                    if ( obs_OBJECT_WORK.spd.x < -buku_work.spd_dec )
                    {
                        obs_OBJECT_WORK.spd.x = -buku_work.spd_dec;
                    }
                }
            }
            else if ( obs_OBJECT_WORK.spd.x > -2048 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -buku_work.spd_dec, 2048 );
            }
        }
        else if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 2 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -buku_work.spd_dec, 2048 );
        }
        else if ( obs_OBJECT_WORK.pos.x >= ( int )( obs_OBJECT_WORK.user_flag - ( uint )buku_work.spd_dec_dist ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, buku_work.spd_dec );
            result = 1;
            if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x < ( int )obs_OBJECT_WORK.user_flag )
            {
                obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_flag - ( uint )obs_OBJECT_WORK.pos.x );
                if ( obs_OBJECT_WORK.spd.x > buku_work.spd_dec )
                {
                    obs_OBJECT_WORK.spd.x = buku_work.spd_dec;
                }
            }
        }
        else if ( obs_OBJECT_WORK.spd.x < 2048 )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, buku_work.spd_dec, 2048 );
        }
        return result;
    }
}