using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020000BE RID: 190
    public class GMS_ENE_MOTORA_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001EE7 RID: 7911 RVA: 0x0013CAAA File Offset: 0x0013ACAA
        public GMS_ENE_MOTORA_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001EE8 RID: 7912 RVA: 0x0013CABE File Offset: 0x0013ACBE
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06001EE9 RID: 7913 RVA: 0x0013CAD0 File Offset: 0x0013ACD0
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_MOTORA_WORK work )
        {
            return work.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x04004B81 RID: 19329
        public AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04004B82 RID: 19330
        public int spd_dec;

        // Token: 0x04004B83 RID: 19331
        public int spd_dec_dist;
    }

    // Token: 0x060003D9 RID: 985 RVA: 0x0001EF58 File Offset: 0x0001D158
    private static AppMain.OBS_OBJECT_WORK GmEneMotoraInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_MOTORA_WORK(), "ENE_MOTORA");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_MOTORA_WORK gms_ENE_MOTORA_WORK = (AppMain.GMS_ENE_MOTORA_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_motora_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 663 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -24, 11, 0 );
        obs_RECT_WORK.flag |= 4U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
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
        gms_ENE_MOTORA_WORK.spd_dec = 102;
        gms_ENE_MOTORA_WORK.spd_dec_dist = 20480;
        AppMain.gmEneMotoraWalkInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060003DA RID: 986 RVA: 0x0001F128 File Offset: 0x0001D328
    public static void GmEneMotoraBuild()
    {
        AppMain.gm_ene_motora_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 661 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 662 ) ), 0U );
    }

    // Token: 0x060003DB RID: 987 RVA: 0x0001F154 File Offset: 0x0001D354
    public static void GmEneMotoraFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(661));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_motora_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060003DC RID: 988 RVA: 0x0001F184 File Offset: 0x0001D384
    public static void gmEneMotoraWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 1, 2 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMotoraWalkMain );
        obj_work.move_flag &= 4294967291U;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
            return;
        }
        obj_work.spd.x = 2048;
    }

    // Token: 0x060003DD RID: 989 RVA: 0x0001F1FC File Offset: 0x0001D3FC
    private static void gmEneMotoraWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_MOTORA_WORK motora_work = (AppMain.GMS_ENE_MOTORA_WORK)obj_work;
        bool flag = AppMain.gmEneMotoraSetWalkSpeed(motora_work);
        if ( flag )
        {
            AppMain.gmEneMotoraFlipInit( obj_work );
        }
    }

    // Token: 0x060003DE RID: 990 RVA: 0x0001F220 File Offset: 0x0001D420
    private static bool gmEneMotoraSetWalkSpeed( AppMain.GMS_ENE_MOTORA_WORK motora_work )
    {
        bool result = false;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)motora_work;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 4 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, motora_work.spd_dec, 2048 );
            }
            else if ( obs_OBJECT_WORK.pos.x <= Convert.ToInt32( obs_OBJECT_WORK.user_work ) + motora_work.spd_dec_dist )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, motora_work.spd_dec );
                result = true;
                if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x > Convert.ToInt32( obs_OBJECT_WORK.user_work ) )
                {
                    obs_OBJECT_WORK.spd.x = Convert.ToInt32( obs_OBJECT_WORK.user_work ) - obs_OBJECT_WORK.pos.x;
                    if ( obs_OBJECT_WORK.spd.x < -motora_work.spd_dec )
                    {
                        obs_OBJECT_WORK.spd.x = -motora_work.spd_dec;
                    }
                }
            }
            else if ( obs_OBJECT_WORK.spd.x > -2048 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -motora_work.spd_dec, 2048 );
            }
        }
        else if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 3 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -motora_work.spd_dec, 2048 );
        }
        else if ( obs_OBJECT_WORK.pos.x >= Convert.ToInt32( obs_OBJECT_WORK.user_flag ) - motora_work.spd_dec_dist )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, motora_work.spd_dec );
            result = true;
            if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x < Convert.ToInt32( obs_OBJECT_WORK.user_flag ) )
            {
                obs_OBJECT_WORK.spd.x = Convert.ToInt32( obs_OBJECT_WORK.user_flag ) - obs_OBJECT_WORK.pos.x;
                if ( obs_OBJECT_WORK.spd.x > motora_work.spd_dec )
                {
                    obs_OBJECT_WORK.spd.x = motora_work.spd_dec;
                }
            }
        }
        else if ( obs_OBJECT_WORK.spd.x < 2048 )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, motora_work.spd_dec, 2048 );
        }
        return result;
    }

    // Token: 0x060003DF RID: 991 RVA: 0x0001F4D4 File Offset: 0x0001D6D4
    private static void gmEneMotoraFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 3, 4 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMotoraFlipMain );
    }

    // Token: 0x060003E0 RID: 992 RVA: 0x0001F4F7 File Offset: 0x0001D6F7
    private static void gmEneMotoraFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneMotoraSetWalkSpeed( ( AppMain.GMS_ENE_MOTORA_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneMotoraWalkInit( obj_work );
        }
    }
}
