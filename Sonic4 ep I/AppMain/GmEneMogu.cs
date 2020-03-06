using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200026A RID: 618
    public class GMS_ENE_MOGU_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023FB RID: 9211 RVA: 0x00149F79 File Offset: 0x00148179
        public GMS_ENE_MOGU_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023FC RID: 9212 RVA: 0x00149F8D File Offset: 0x0014818D
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x060023FD RID: 9213 RVA: 0x00149F9F File Offset: 0x0014819F
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_MOGU_WORK work )
        {
            return work.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x04005930 RID: 22832
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04005931 RID: 22833
        public int spd_dec;

        // Token: 0x04005932 RID: 22834
        public int spd_dec_dist;

        // Token: 0x04005933 RID: 22835
        public int wait_time;

        // Token: 0x04005934 RID: 22836
        public int jumpdown;

        // Token: 0x04005935 RID: 22837
        public uint flag;
    }

    // Token: 0x06001033 RID: 4147 RVA: 0x0008CEE6 File Offset: 0x0008B0E6
    public static void GmEneMoguBuild()
    {
        AppMain.gm_ene_mogu_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 674 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 675 ) ), 0U );
    }

    // Token: 0x06001034 RID: 4148 RVA: 0x0008CF14 File Offset: 0x0008B114
    public static void GmEneMoguFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(674));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_mogu_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001035 RID: 4149 RVA: 0x0008CF48 File Offset: 0x0008B148
    public static AppMain.OBS_OBJECT_WORK GmEneMoguInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_MOGU_WORK(), "ENE_MOGU");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_MOGU_WORK gms_ENE_MOGU_WORK = (AppMain.GMS_ENE_MOGU_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_mogu_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 676 ), null, 0, null );
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
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -4, -44, 4, -38 );
        obs_OBJECT_WORK.move_flag |= 128U;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_MOGU_WORK.spd_dec = 102;
        gms_ENE_MOGU_WORK.spd_dec_dist = 20480;
        gms_ENE_MOGU_WORK.flag = 0U;
        AppMain.gmEneMoguWaitInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001036 RID: 4150 RVA: 0x0008D120 File Offset: 0x0008B320
    public static int gmEneMoguCheckWater( AppMain.GMS_ENE_MOGU_WORK mogu_work, short ofst )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)mogu_work;
        if ( !AppMain.GmMainIsWaterLevel() )
        {
            return 0;
        }
        if ( ( obs_OBJECT_WORK.pos.y >> 12 ) - ( int )ofst >= ( int )AppMain.g_gm_main_system.water_level )
        {
            if ( ( mogu_work.flag & 1U ) == 0U && ( mogu_work.flag & 2U ) != 0U )
            {
                AppMain.GmEfctCmnEsCreate( obs_OBJECT_WORK, 76 );
                AppMain.GmSoundPlaySE( "Spray" );
            }
            mogu_work.flag |= 1U;
            return 1;
        }
        if ( ( mogu_work.flag & 1U ) != 0U )
        {
            if ( ( mogu_work.flag & 2U ) != 0U )
            {
                AppMain.GmEfctCmnEsCreate( obs_OBJECT_WORK, 76 );
                AppMain.GmSoundPlaySE( "Spray" );
            }
            mogu_work.flag &= 4294967294U;
            return 1;
        }
        return 0;
    }

    // Token: 0x06001037 RID: 4151 RVA: 0x0008D1CC File Offset: 0x0008B3CC
    public static void gmEneMoguWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet( obj_work, 4 );
        obj_work.disp_flag |= 4U;
        obj_work.pos.z = -655360;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguWaitMain );
    }

    // Token: 0x06001038 RID: 4152 RVA: 0x0008D20C File Offset: 0x0008B40C
    public static void gmEneMoguWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_MOGU_WORK mogu_work = (AppMain.GMS_ENE_MOGU_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        int num = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
        int num2 = gms_PLAYER_WORK.obj_work.pos.y - obj_work.pos.y;
        int num3 = AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2);
        if ( num3 <= AppMain.FX_F32_TO_FX32( 25600f ) )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguJumpInit );
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
            if ( AppMain.gmEneMoguCheckWater( mogu_work, 48 ) == 0 )
            {
                gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate( obj_work, 7 );
                if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
                {
                    gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 393216;
                }
            }
            else
            {
                gms_EFFECT_3DES_WORK = AppMain.GmEfctEneEsCreate( obj_work, 8 );
            }
            AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, 0f, -30f, 0f );
        }
    }

    // Token: 0x06001039 RID: 4153 RVA: 0x0008D2F8 File Offset: 0x0008B4F8
    public static void gmEneMoguJumpInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_MOGU_WORK gms_ENE_MOGU_WORK = (AppMain.GMS_ENE_MOGU_WORK)obj_work;
        AppMain.ObjDrawObjectActionSet( obj_work, 4 );
        obj_work.disp_flag |= 4U;
        obj_work.spd.y = AppMain.FX_F32_TO_FX32( -6f );
        obj_work.spd_fall = AppMain.FX_F32_TO_FX32( 0.16f );
        obj_work.pos.y = obj_work.pos.y - AppMain.FX_F32_TO_FX32( 4f );
        obj_work.move_flag |= 128U;
        obj_work.move_flag &= 4294967294U;
        obj_work.move_flag &= 4294967291U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguJumpMain );
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
        }
        else
        {
            obj_work.spd.x = 2048;
        }
        AppMain.gmEneMoguCheckWater( gms_ENE_MOGU_WORK, 0 );
        gms_ENE_MOGU_WORK.jumpdown = 0;
    }

    // Token: 0x0600103A RID: 4154 RVA: 0x0008D3E0 File Offset: 0x0008B5E0
    public static void gmEneMoguJumpMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_MOGU_WORK gms_ENE_MOGU_WORK = (AppMain.GMS_ENE_MOGU_WORK)obj_work;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
        }
        else
        {
            obj_work.spd.x = 2048;
        }
        if ( obj_work.spd.y > 0 )
        {
            if ( gms_ENE_MOGU_WORK.jumpdown == 0 )
            {
                gms_ENE_MOGU_WORK.jumpdown = 1;
                AppMain.ObjDrawObjectActionSet( obj_work, 5 );
                obj_work.disp_flag |= 4U;
                obj_work.move_flag &= 4294967039U;
                AppMain.ObjObjectFieldRectSet( obj_work, -4, -8, 4, -2 );
                obj_work.pos.z = 0;
                gms_ENE_MOGU_WORK.flag |= 2U;
            }
            if ( ( obj_work.move_flag & 4U ) != 0U )
            {
                if ( ( obj_work.disp_flag & 1U ) != 0U )
                {
                    obj_work.disp_flag &= 4294967294U;
                }
                else
                {
                    obj_work.disp_flag |= 1U;
                }
            }
        }
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguJumpEnd );
        }
        AppMain.gmEneMoguCheckWater( gms_ENE_MOGU_WORK, 0 );
    }

    // Token: 0x0600103B RID: 4155 RVA: 0x0008D4F0 File Offset: 0x0008B6F0
    public static void gmEneMoguJumpEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_MOGU_WORK mogu_work = (AppMain.GMS_ENE_MOGU_WORK)obj_work;
        AppMain.gmEneMoguCheckWater( mogu_work, 0 );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguWalkInit );
        }
    }

    // Token: 0x0600103C RID: 4156 RVA: 0x0008D528 File Offset: 0x0008B728
    public static void gmEneMoguWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 6, 7 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguWalkMain );
        obj_work.move_flag &= 4294967291U;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
            return;
        }
        obj_work.spd.x = 2048;
    }

    // Token: 0x0600103D RID: 4157 RVA: 0x0008D5A0 File Offset: 0x0008B7A0
    public static void gmEneMoguWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GMS_ENE_MOGU_WORK gms_ENE_MOGU_WORK = (AppMain.GMS_ENE_MOGU_WORK)obj_work;
        AppMain.gmEneMoguCheckWater( gms_ENE_MOGU_WORK, 0 );
        int num = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
        int num2 = gms_PLAYER_WORK.obj_work.pos.y - obj_work.pos.y;
        int num3 = AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2);
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) != 0 )
        {
            num3 = AppMain.FX_F32_TO_FX32( 6400f ) + 1;
            gms_ENE_MOGU_WORK.wait_time = 216000;
        }
        if ( num3 <= AppMain.FX_F32_TO_FX32( 6400f ) )
        {
            gms_ENE_MOGU_WORK.wait_time = 0;
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                if ( AppMain.GmEneComTargetIsLeft( obj_work, gms_PLAYER_WORK.obj_work ) == 0 )
                {
                    AppMain.gmEneMoguFlipInit( obj_work );
                }
            }
            else if ( AppMain.GmEneComTargetIsLeft( obj_work, gms_PLAYER_WORK.obj_work ) != 0 )
            {
                AppMain.gmEneMoguFlipInit( obj_work );
            }
            if ( ( obj_work.move_flag & 4U ) != 0U )
            {
                AppMain.gmEneMoguJumpInit( obj_work );
            }
            return;
        }
        if ( gms_ENE_MOGU_WORK.wait_time > 0 )
        {
            gms_ENE_MOGU_WORK.wait_time--;
            if ( ( obj_work.move_flag & 4U ) != 0U )
            {
                AppMain.gmEneMoguJumpInit( obj_work );
            }
            return;
        }
        if ( AppMain.AkMathRandFx() > AppMain.FX_F32_TO_FX32( 0.5f ) )
        {
            AppMain.gmEneMoguFlipInit( obj_work );
        }
        gms_ENE_MOGU_WORK.wait_time = 216000;
    }

    // Token: 0x0600103E RID: 4158 RVA: 0x0008D6EA File Offset: 0x0008B8EA
    public static void gmEneMoguFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneMoguFlipInit( obj_work );
        }
    }

    // Token: 0x0600103F RID: 4159 RVA: 0x0008D70C File Offset: 0x0008B90C
    public static void gmEneMoguFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 2, 3 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneMoguFlipMain );
    }

    // Token: 0x06001040 RID: 4160 RVA: 0x0008D72F File Offset: 0x0008B92F
    public static void gmEneMoguFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmEneMoguSetWalkSpeed( ( AppMain.GMS_ENE_MOGU_WORK )obj_work );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneMoguWalkInit( obj_work );
        }
    }

    // Token: 0x06001041 RID: 4161 RVA: 0x0008D75C File Offset: 0x0008B95C
    public static int gmEneMoguSetWalkSpeed( AppMain.GMS_ENE_MOGU_WORK mogu_work )
    {
        int result = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)mogu_work;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 3 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, mogu_work.spd_dec, 2048 );
            }
            else if ( obs_OBJECT_WORK.pos.x <= ( int )( obs_OBJECT_WORK.user_work + ( uint )mogu_work.spd_dec_dist ) )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, mogu_work.spd_dec );
                result = 1;
                if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x > ( int )obs_OBJECT_WORK.user_work )
                {
                    obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_work - ( uint )obs_OBJECT_WORK.pos.x );
                    if ( obs_OBJECT_WORK.spd.x < -mogu_work.spd_dec )
                    {
                        obs_OBJECT_WORK.spd.x = -mogu_work.spd_dec;
                    }
                }
            }
            else if ( obs_OBJECT_WORK.spd.x > -2048 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -mogu_work.spd_dec, 2048 );
            }
        }
        else if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 2 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -mogu_work.spd_dec, 2048 );
        }
        else if ( obs_OBJECT_WORK.pos.x >= ( int )( obs_OBJECT_WORK.user_flag - ( uint )mogu_work.spd_dec_dist ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, mogu_work.spd_dec );
            result = 1;
            if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x < ( int )obs_OBJECT_WORK.user_flag )
            {
                obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_flag - ( uint )obs_OBJECT_WORK.pos.x );
                if ( obs_OBJECT_WORK.spd.x > mogu_work.spd_dec )
                {
                    obs_OBJECT_WORK.spd.x = mogu_work.spd_dec;
                }
            }
        }
        else if ( obs_OBJECT_WORK.spd.x < 2048 )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, mogu_work.spd_dec, 2048 );
        }
        return result;
    }
}