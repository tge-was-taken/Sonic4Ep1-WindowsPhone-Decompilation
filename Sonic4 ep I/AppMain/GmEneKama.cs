using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001BA RID: 442
    public class GMS_ENE_KAMA_FADE_ANIME_PAT
    {
        // Token: 0x0600221F RID: 8735 RVA: 0x001423CD File Offset: 0x001405CD
        public GMS_ENE_KAMA_FADE_ANIME_PAT()
        {
            this.col = new AppMain.NNS_RGB();
        }

        // Token: 0x06002220 RID: 8736 RVA: 0x001423E0 File Offset: 0x001405E0
        public GMS_ENE_KAMA_FADE_ANIME_PAT( AppMain.NNS_RGB c, float inten, int fr )
        {
            this.col = c;
            this.intensity = inten;
            this.frame = fr;
        }

        // Token: 0x04004FE5 RID: 20453
        public readonly AppMain.NNS_RGB col;

        // Token: 0x04004FE6 RID: 20454
        public float intensity;

        // Token: 0x04004FE7 RID: 20455
        public int frame;
    }

    // Token: 0x020001BB RID: 443
    public class GMS_ENE_KAMA_FADE_ANIME
    {
        // Token: 0x06002221 RID: 8737 RVA: 0x001423FD File Offset: 0x001405FD
        public GMS_ENE_KAMA_FADE_ANIME( uint num, AppMain.GMS_ENE_KAMA_FADE_ANIME_PAT[] pat )
        {
            this.pat_num = num;
            this.anime_pat = pat;
        }

        // Token: 0x04004FE8 RID: 20456
        public uint pat_num;

        // Token: 0x04004FE9 RID: 20457
        public AppMain.GMS_ENE_KAMA_FADE_ANIME_PAT[] anime_pat;
    }

    // Token: 0x020001BC RID: 444
    public class GMS_ENE_KAMA_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002222 RID: 8738 RVA: 0x00142413 File Offset: 0x00140613
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06002223 RID: 8739 RVA: 0x00142425 File Offset: 0x00140625
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENE_KAMA_WORK work )
        {
            return work.ene_3d_work.ene_com.obj_work;
        }

        // Token: 0x06002224 RID: 8740 RVA: 0x00142437 File Offset: 0x00140637
        public GMS_ENE_KAMA_WORK()
        {
            this.ene_3d_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x04004FEA RID: 20458
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d_work;

        // Token: 0x04004FEB RID: 20459
        public int spd_dec;

        // Token: 0x04004FEC RID: 20460
        public int spd_dec_dist;

        // Token: 0x04004FED RID: 20461
        public int hand;

        // Token: 0x04004FEE RID: 20462
        public readonly AppMain.GMS_ENE_NODE_MATRIX node_work = new AppMain.GMS_ENE_NODE_MATRIX();

        // Token: 0x04004FEF RID: 20463
        public int attack;

        // Token: 0x04004FF0 RID: 20464
        public int timer;

        // Token: 0x04004FF1 RID: 20465
        public int rot_z;

        // Token: 0x04004FF2 RID: 20466
        public int rot_z_add;

        // Token: 0x04004FF3 RID: 20467
        public int atk_wait;

        // Token: 0x04004FF4 RID: 20468
        public int walk_s;

        // Token: 0x04004FF5 RID: 20469
        public int ata_futa;

        // Token: 0x04004FF6 RID: 20470
        public AppMain.GMS_ENE_KAMA_FADE_ANIME anime_data;

        // Token: 0x04004FF7 RID: 20471
        public uint anime_pat_no;

        // Token: 0x04004FF8 RID: 20472
        public int anime_frame;
    }

    // Token: 0x0600093A RID: 2362 RVA: 0x00052EEB File Offset: 0x000510EB
    private static void GmEneKamaBuild()
    {
        AppMain.gm_ene_kama_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 699 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetEnemyData( 700 ) ), 0U );
    }

    // Token: 0x0600093B RID: 2363 RVA: 0x00052F18 File Offset: 0x00051118
    private static void GmEneKamaFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetEnemyData(699));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_ene_kama_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600093C RID: 2364 RVA: 0x00052F4C File Offset: 0x0005114C
    private static AppMain.OBS_OBJECT_WORK GmEneKamaInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_KAMA_WORK(), "ENE_KAMA");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_kama_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 701 ), null, 0, null );
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
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -4, -8, 4, 0 );
        obs_OBJECT_WORK.move_flag |= 128U;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 1U;
        }
        if ( ( eve_rec.flag & 2 ) != 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 2U;
            obs_OBJECT_WORK.move_flag &= 4294967167U;
            obs_OBJECT_WORK.dir.z = ( ushort )AppMain.AKM_DEGtoA16( 180 );
            obs_OBJECT_WORK.disp_flag ^= 1U;
        }
        gms_ENE_KAMA_WORK.atk_wait = 0;
        if ( ( eve_rec.flag & 4 ) != 0 )
        {
            gms_ENE_KAMA_WORK.atk_wait += 10;
        }
        if ( ( eve_rec.flag & 8 ) != 0 )
        {
            gms_ENE_KAMA_WORK.atk_wait += 20;
        }
        if ( ( eve_rec.flag & 16 ) != 0 )
        {
            gms_ENE_KAMA_WORK.atk_wait += 30;
        }
        gms_ENE_KAMA_WORK.walk_s = 0;
        if ( ( eve_rec.flag & 32 ) != 0 )
        {
            gms_ENE_KAMA_WORK.walk_s = 1;
        }
        obs_OBJECT_WORK.user_work = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )eve_rec.left << 12 ) );
        obs_OBJECT_WORK.user_flag = ( uint )( obs_OBJECT_WORK.pos.x + ( ( int )( eve_rec.left + ( sbyte )eve_rec.width ) << 12 ) );
        gms_ENE_KAMA_WORK.spd_dec = 102;
        gms_ENE_KAMA_WORK.spd_dec_dist = 20480;
        AppMain.gmEneKamaWalkInit( obs_OBJECT_WORK );
        gms_ENE_KAMA_WORK.attack = 0;
        AppMain.GmEneUtilInitNodeMatrix( gms_ENE_KAMA_WORK.node_work, obs_OBJECT_WORK, 32 );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEneKamaExit ) );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_KAMA_WORK.node_work, 9 );
        AppMain.GmEneUtilGetNodeMatrix( gms_ENE_KAMA_WORK.node_work, 6 );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(311, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth( 312, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0 );
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        obs_OBJECT_WORK.flag |= 1073741824U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600093D RID: 2365 RVA: 0x0005328E File Offset: 0x0005148E
    private static AppMain.OBS_OBJECT_WORK GmEneKamaLeftHandInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        return AppMain.gmEneKamaHandInit( eve_rec, pos_x, pos_y, 1 );
    }

    // Token: 0x0600093E RID: 2366 RVA: 0x00053299 File Offset: 0x00051499
    private static AppMain.OBS_OBJECT_WORK GmEneKamaRightHandInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        return AppMain.gmEneKamaHandInit( eve_rec, pos_x, pos_y, 0 );
    }

    // Token: 0x0600093F RID: 2367 RVA: 0x000532A4 File Offset: 0x000514A4
    private static int gmEneKamaGetLength2N( AppMain.OBS_OBJECT_WORK obj_work )
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

    // Token: 0x06000940 RID: 2368 RVA: 0x00053328 File Offset: 0x00051528
    private static int gmEneKamaIsPlayerFront( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( obj_work.disp_flag & 2U ) != 0U )
        {
            if ( ( obj_work.disp_flag & 1U ) == 0U )
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

    // Token: 0x06000941 RID: 2369 RVA: 0x000533E0 File Offset: 0x000515E0
    private static AppMain.VecFx32 gmEneKamaGetPlayerVectorFx( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.VecFx32 result = default(AppMain.VecFx32);
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        int num = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
        int num2 = gms_PLAYER_WORK.obj_work.pos.y - obj_work.pos.y;
        if ( num > AppMain.FX_F32_TO_FX32( 1000f ) || num < AppMain.FX_F32_TO_FX32( -1000f ) )
        {
            num = 1000;
        }
        if ( num2 > AppMain.FX_F32_TO_FX32( 1000f ) || num2 < AppMain.FX_F32_TO_FX32( -1000f ) )
        {
            num2 = 1000;
        }
        int num3 = AppMain.FX_Mul(num, num) + AppMain.FX_Mul(num2, num2);
        num3 = AppMain.FX_Sqrt( num3 );
        if ( num3 == 0 )
        {
            result.x = 0;
            result.y = 0;
        }
        else
        {
            int v = AppMain.FX_Div(4096, num3);
            result.x = AppMain.FX_Mul( num, v );
            result.y = AppMain.FX_Mul( num2, v );
        }
        result.z = 0;
        return result;
    }

    // Token: 0x06000942 RID: 2370 RVA: 0x000534E4 File Offset: 0x000516E4
    private static AppMain.VecFx32 gmEneKamaGetParentVectorFx( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.VecFx32 result = default(AppMain.VecFx32);
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work.parent_obj;
        int num;
        int num2;
        if ( gms_ENE_KAMA_WORK == null )
        {
            num = 1000;
            num2 = 1000;
        }
        else
        {
            num = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.obj_work.pos.x - obj_work.pos.x;
            num2 = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.obj_work.pos.y - obj_work.pos.y;
        }
        if ( num > AppMain.FX_F32_TO_FX32( 1000f ) || num < AppMain.FX_F32_TO_FX32( -1000f ) )
        {
            num = 1000;
        }
        if ( num2 > AppMain.FX_F32_TO_FX32( 1000f ) || num2 < AppMain.FX_F32_TO_FX32( -1000f ) )
        {
            num2 = 1000;
        }
        int num3 = AppMain.FX_F32_TO_FX32(Math.Sqrt((double)(AppMain.FX_FX32_TO_F32(num) * AppMain.FX_FX32_TO_F32(num) + AppMain.FX_FX32_TO_F32(num2) + AppMain.FX_FX32_TO_F32(num2))));
        if ( num3 == 0 )
        {
            result.x = 0;
            result.y = 0;
        }
        else
        {
            int v = AppMain.FX_Div(4096, num3);
            result.x = AppMain.FX_Mul( num, v );
            result.y = AppMain.FX_Mul( num2, v );
        }
        result.z = 0;
        return result;
    }

    // Token: 0x06000943 RID: 2371 RVA: 0x00053620 File Offset: 0x00051820
    private static AppMain.OBS_OBJECT_WORK gmEneKamaHandInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENE_KAMA_WORK(), "ENE_KAMA");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obs_OBJECT_WORK;
        if ( type == 1 )
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_kama_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_ene_kama_obj_3d_list[2], gms_ENEMY_3D_WORK.obj_3d );
        }
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.z = 0;
        gms_ENE_KAMA_WORK.ene_3d_work.ene_com.enemy_flag |= 32768U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -11, -24, 11, 0 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -19, -32, 19, 0 );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENE_KAMA_WORK.hand = type;
        AppMain.gmEneKamaHandWaitInit( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000944 RID: 2372 RVA: 0x000537C8 File Offset: 0x000519C8
    private static void gmEneKamaExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)p;
        AppMain.GmEneUtilExitNodeMatrix( gms_ENE_KAMA_WORK.node_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000945 RID: 2373 RVA: 0x000537F4 File Offset: 0x000519F4
    private static void gmEneKamaWalkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmEneComActionSetDependHFlip( obj_work, 6, 7 );
        obj_work.disp_flag |= 4U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaWalkMain );
        obj_work.move_flag &= 4294967291U;
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            obj_work.spd.x = -2048;
        }
        else
        {
            obj_work.spd.x = 2048;
        }
        if ( obj_work.user_flag == obj_work.user_work )
        {
            obj_work.spd.x = 0;
            AppMain.GmEneComActionSetDependHFlip( obj_work, 8, 9 );
            obj_work.disp_flag |= 4U;
        }
    }

    // Token: 0x06000946 RID: 2374 RVA: 0x0005389C File Offset: 0x00051A9C
    private static void gmEneKamaWalkMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK kama_work = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        if ( AppMain.gmEneKamaIsPlayerFront( obj_work ) != 0 && AppMain.gmEneKamaGetLength2N( obj_work ) <= 12544 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaAttackInit );
            return;
        }
        if ( ( obj_work.disp_flag & 2U ) != 0U )
        {
            obj_work.move_flag &= 4294967167U;
            if ( ( obj_work.move_flag & 1U ) == 0U )
            {
                obj_work.spd.y = obj_work.spd.y - obj_work.spd_fall;
            }
            else
            {
                obj_work.spd.y = 0;
            }
        }
        if ( obj_work.user_flag == obj_work.user_work )
        {
            return;
        }
        int num = AppMain.gmEneKamaSetWalkSpeed(kama_work);
        if ( num != 0 )
        {
            AppMain.gmEneKamaFlipInit( obj_work );
        }
    }

    // Token: 0x06000947 RID: 2375 RVA: 0x00053943 File Offset: 0x00051B43
    private static void gmEneKamaFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.gmEneKamaFlipInit( obj_work );
        }
    }

    // Token: 0x06000948 RID: 2376 RVA: 0x00053965 File Offset: 0x00051B65
    private static void gmEneKamaFlipInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d.blend_spd = 0.1f;
        AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 4, 5 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaFlipMain );
        obj_work.spd.x = 0;
    }

    // Token: 0x06000949 RID: 2377 RVA: 0x000539A4 File Offset: 0x00051BA4
    private static void gmEneKamaFlipMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            obj_work.obj_3d.blend_spd = 1f;
            AppMain.gmEneKamaSetWalkSpeed( ( AppMain.GMS_ENE_KAMA_WORK )obj_work );
            AppMain.gmEneKamaWalkInit( obj_work );
        }
    }

    // Token: 0x0600094A RID: 2378 RVA: 0x000539E0 File Offset: 0x00051BE0
    private static void gmEneKamaAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        AppMain.GmEneComActionSetDependHFlip( obj_work, 2, 3 );
        obj_work.disp_flag &= 4294967291U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaAttackPreMain );
        obj_work.move_flag &= 4294967291U;
        obj_work.spd.x = 0;
        gms_ENE_KAMA_WORK.timer = gms_ENE_KAMA_WORK.atk_wait;
    }

    // Token: 0x0600094B RID: 2379 RVA: 0x00053A44 File Offset: 0x00051C44
    private static void gmEneKamaAttackPreMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( gms_ENE_KAMA_WORK.timer <= 0 )
            {
                AppMain.GmEneComActionSetDependHFlip( obj_work, 0, 1 );
                obj_work.disp_flag &= 4294967291U;
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaAttackMain );
                obj_work.move_flag &= 4294967291U;
                obj_work.spd.x = 0;
                gms_ENE_KAMA_WORK.timer = 7;
                return;
            }
            gms_ENE_KAMA_WORK.timer--;
        }
    }

    // Token: 0x0600094C RID: 2380 RVA: 0x00053AC8 File Offset: 0x00051CC8
    private static void gmEneKamaAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        if ( gms_ENE_KAMA_WORK.timer > 0 )
        {
            gms_ENE_KAMA_WORK.timer--;
            return;
        }
        gms_ENE_KAMA_WORK.attack = 1;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaAttackWait );
    }

    // Token: 0x0600094D RID: 2381 RVA: 0x00053B10 File Offset: 0x00051D10
    private static void gmEneKamaAttackWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        if ( gms_ENE_KAMA_WORK.ata_futa != 0 )
        {
            if ( gms_ENE_KAMA_WORK.timer > 0 )
            {
                gms_ENE_KAMA_WORK.timer--;
                return;
            }
            if ( AppMain.gmEneKamaGetLength2N( obj_work ) <= 12544 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaFlashInit );
                return;
            }
            obj_work.obj_3d.speed[0] = 2f;
            AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 4, 5 );
            obj_work.disp_flag &= 4294967291U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaFlipAtafuta );
            obj_work.spd.x = 0;
            if ( gms_ENE_KAMA_WORK.walk_s != 0 )
            {
                gms_ENE_KAMA_WORK.timer = 15;
                return;
            }
            gms_ENE_KAMA_WORK.timer = ( int )( 10 + AppMain.mtMathRand() % 20 );
        }
    }

    // Token: 0x0600094E RID: 2382 RVA: 0x00053BD0 File Offset: 0x00051DD0
    private static void gmEneKamaFlipAtafuta( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.disp_flag ^= 1U;
            AppMain.gmEneKamaSetWalkSpeed( ( AppMain.GMS_ENE_KAMA_WORK )obj_work );
            AppMain.GmEneComActionSetDependHFlip( obj_work, 6, 7 );
            obj_work.disp_flag |= 4U;
            if ( ( obj_work.disp_flag & 1U ) != 0U )
            {
                obj_work.spd.x = -2048;
            }
            else
            {
                obj_work.spd.x = 2048;
            }
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaAttackWait );
        }
    }

    // Token: 0x0600094F RID: 2383 RVA: 0x00053C58 File Offset: 0x00051E58
    private static void gmEneKamaFlashInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        obj_work.spd.x = 0;
        obj_work.obj_3d.speed[0] = 1f;
        AppMain.GmBsCmnClearObject3DNNFadedColor( obj_work );
        obj_work.disp_flag |= 134217728U;
        AppMain.gmEneKamaFadeAnimeSet( gms_ENE_KAMA_WORK, AppMain.gm_ene_kama_blink_anime );
        obj_work.obj_3d.blend_spd = 0.125f;
        AppMain.GmEneComActionSet3DNNBlendDependHFlip( obj_work, 10, 11 );
        obj_work.disp_flag |= 4U;
        gms_ENE_KAMA_WORK.timer = 180;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaFlashMain );
    }

    // Token: 0x06000950 RID: 2384 RVA: 0x00053CF4 File Offset: 0x00051EF4
    private static void gmEneKamaFlashMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        AppMain.gmEneKamaFadeAnimeUpdate( ( AppMain.GMS_ENE_KAMA_WORK )obj_work, 4096, 1 );
        if ( gms_ENE_KAMA_WORK.timer-- < 0 )
        {
            AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctCmnEsCreate(obj_work, 9);
            if ( ( obj_work.disp_flag & 2U ) != 0U )
            {
                AppMain.GmComEfctSetDispOffsetF( efct_work, 0f, 20f, 0f );
            }
            else
            {
                AppMain.GmComEfctSetDispOffsetF( efct_work, 0f, -20f, 0f );
            }
            gms_ENE_KAMA_WORK.ene_3d_work.ene_com.enemy_flag |= 65536U;
            gms_ENE_KAMA_WORK.timer = 180;
            AppMain.GmSoundPlaySE( "Boss2_03" );
            obj_work.disp_flag |= 32U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaFlashEnd );
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.rect_work[1];
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -30, -30, 30, 10 );
            obs_RECT_WORK.flag |= 4U;
            AppMain.GmGmkAnimalInit( obj_work, 0, 0, 0, 0, 0, 0 );
            obs_RECT_WORK = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.rect_work[0];
            obs_RECT_WORK.flag &= 4294967291U;
            obs_RECT_WORK = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.rect_work[2];
            obs_RECT_WORK.flag &= 4294967291U;
        }
    }

    // Token: 0x06000951 RID: 2385 RVA: 0x00053E44 File Offset: 0x00052044
    private static void gmEneKamaFlashEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.rect_work[1];
        obs_RECT_WORK.flag &= 4294967291U;
        if ( gms_ENE_KAMA_WORK.timer-- < 0 )
        {
            obj_work.flag |= 8U;
        }
    }

    // Token: 0x06000952 RID: 2386 RVA: 0x00053E9C File Offset: 0x0005209C
    private static int gmEneKamaSetWalkSpeed( AppMain.GMS_ENE_KAMA_WORK kama_work )
    {
        int result = 0;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)kama_work;
        if ( ( obs_OBJECT_WORK.disp_flag & 1U ) != 0U )
        {
            if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 5 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, kama_work.spd_dec, 2048 );
            }
            else if ( obs_OBJECT_WORK.pos.x <= ( int )( obs_OBJECT_WORK.user_work + ( uint )kama_work.spd_dec_dist ) )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, kama_work.spd_dec );
                result = 1;
                if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x > ( int )obs_OBJECT_WORK.user_work )
                {
                    obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_work - ( uint )obs_OBJECT_WORK.pos.x );
                    if ( obs_OBJECT_WORK.spd.x < -kama_work.spd_dec )
                    {
                        obs_OBJECT_WORK.spd.x = -kama_work.spd_dec;
                    }
                }
            }
            else if ( obs_OBJECT_WORK.spd.x > -2048 )
            {
                obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -kama_work.spd_dec, 2048 );
            }
        }
        else if ( obs_OBJECT_WORK.obj_3d.act_id[0] == 4 && obs_OBJECT_WORK.obj_3d.frame[0] >= 20f )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, -kama_work.spd_dec, 2048 );
        }
        else if ( obs_OBJECT_WORK.pos.x >= ( int )( obs_OBJECT_WORK.user_flag - ( uint )kama_work.spd_dec_dist ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdDownSet( obs_OBJECT_WORK.spd.x, kama_work.spd_dec );
            result = 1;
            if ( obs_OBJECT_WORK.spd.x == 0 && obs_OBJECT_WORK.pos.x < ( int )obs_OBJECT_WORK.user_flag )
            {
                obs_OBJECT_WORK.spd.x = ( int )( obs_OBJECT_WORK.user_flag - ( uint )obs_OBJECT_WORK.pos.x );
                if ( obs_OBJECT_WORK.spd.x > kama_work.spd_dec )
                {
                    obs_OBJECT_WORK.spd.x = kama_work.spd_dec;
                }
            }
        }
        else if ( obs_OBJECT_WORK.spd.x < 2048 )
        {
            obs_OBJECT_WORK.spd.x = AppMain.ObjSpdUpSet( obs_OBJECT_WORK.spd.x, kama_work.spd_dec, 2048 );
        }
        return result;
    }

    // Token: 0x06000953 RID: 2387 RVA: 0x00054130 File Offset: 0x00052330
    private static void gmEneKamaHandWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        gms_ENE_KAMA_WORK.rot_z = 0;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.rect_work[1];
        obs_RECT_WORK.flag &= 4294967291U;
        obj_work.ofst.x = 0;
        obj_work.ofst.y = 0;
        obj_work.dir.z = 0;
        obj_work.flag &= 4294966783U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaHandWaitMain );
    }

    // Token: 0x06000954 RID: 2388 RVA: 0x000541B8 File Offset: 0x000523B8
    private static void gmEneKamaHandWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK2 = (AppMain.GMS_ENE_KAMA_WORK)obj_work.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmEneKamaHandWaitMain_msm;
        if ( obj_work.parent_obj == null )
        {
            obj_work.spd.x = 0;
            obj_work.spd_fall = AppMain.FX_F32_TO_FX32( 0.2f );
            obj_work.move_flag |= 128U;
            return;
        }
        AppMain.NNS_MATRIX nns_MATRIX2;
        if ( gms_ENE_KAMA_WORK.hand == 1 )
        {
            nns_MATRIX2 = AppMain.GmEneUtilGetNodeMatrix( gms_ENE_KAMA_WORK2.node_work, 9 );
        }
        else
        {
            nns_MATRIX2 = AppMain.GmEneUtilGetNodeMatrix( gms_ENE_KAMA_WORK2.node_work, 6 );
        }
        if ( nns_MATRIX2.M03 == 0f && nns_MATRIX2.M13 == 0f )
        {
            return;
        }
        AppMain.nnMakeScaleMatrix( nns_MATRIX, 1f, 1f, 1f );
        AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX2, nns_MATRIX );
        AppMain.GmEneUtilSetMatrixNN( obj_work, nns_MATRIX );
        if ( gms_ENE_KAMA_WORK2.attack != 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaHandAttackInit );
        }
    }

    // Token: 0x06000955 RID: 2389 RVA: 0x00054294 File Offset: 0x00052494
    private static void gmEneKamaHandAttackInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK2 = (AppMain.GMS_ENE_KAMA_WORK)obj_work.parent_obj;
        AppMain.VecFx32 vecFx = AppMain.gmEneKamaGetPlayerVectorFx(obj_work);
        obj_work.spd.x = ( int )( ( float )vecFx.x * 1.75f );
        obj_work.spd.y = ( int )( ( float )vecFx.y * 1.75f );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmEneKamaHandAttackMain );
        gms_ENE_KAMA_WORK.timer = 120;
        if ( ( gms_ENE_KAMA_WORK2.ene_3d_work.ene_com.obj_work.disp_flag & 2U ) != 0U )
        {
            obj_work.disp_flag |= 2U;
        }
        if ( ( gms_ENE_KAMA_WORK2.ene_3d_work.ene_com.obj_work.disp_flag & 1U ) != 0U )
        {
            gms_ENE_KAMA_WORK.rot_z_add = -AppMain.AKM_DEGtoA32( 15 );
        }
        else
        {
            gms_ENE_KAMA_WORK.rot_z_add = AppMain.AKM_DEGtoA32( 15 );
        }
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENE_KAMA_WORK.ene_3d_work.ene_com.rect_work[1];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -8, -8, 8, 8 );
        obs_RECT_WORK.flag |= 4U;
        obj_work.flag |= 512U;
        obj_work.pos.z = 655360;
        AppMain.GmSoundPlaySE( "Kama" );
    }

    // Token: 0x06000956 RID: 2390 RVA: 0x000543C0 File Offset: 0x000525C0
    private static void gmEneKamaHandAttackMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK = (AppMain.GMS_ENE_KAMA_WORK)obj_work;
        gms_ENE_KAMA_WORK.rot_z += gms_ENE_KAMA_WORK.rot_z_add;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmEneKamaHandAttackMain_rmat;
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.gmEneKamaHandAttackMain_tmat;
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.gmEneKamaHandAttackMain_mat;
        AppMain.nnMakeRotateZMatrix( nns_MATRIX, gms_ENE_KAMA_WORK.rot_z );
        if ( ( obj_work.disp_flag & 2U ) != 0U )
        {
            AppMain.nnMakeTranslateMatrix( nns_MATRIX2, 10f, 10f, 0f );
        }
        else
        {
            AppMain.nnMakeTranslateMatrix( nns_MATRIX2, 10f, -10f, 0f );
        }
        AppMain.nnMultiplyMatrix( nns_MATRIX3, nns_MATRIX, nns_MATRIX2 );
        obj_work.ofst.x = AppMain.FX_F32_TO_FX32( nns_MATRIX3.M03 );
        obj_work.ofst.y = AppMain.FX_F32_TO_FX32( nns_MATRIX3.M13 );
        obj_work.dir.z = ( ushort )gms_ENE_KAMA_WORK.rot_z;
        if ( gms_ENE_KAMA_WORK.timer > 0 )
        {
            AppMain.VecFx32 vecFx = AppMain.gmEneKamaGetPlayerVectorFx(obj_work);
            int num = (int)((float)obj_work.spd.x / 1.75f);
            int num2 = (int)((float)obj_work.spd.y / 1.75f);
            int num3 = AppMain.FX_Mul(vecFx.x, num2) - AppMain.FX_Mul(vecFx.y, num);
            if ( num3 < 0 )
            {
                num = AppMain.FX_Mul( AppMain.FX_Cos( ( int )( ( short )AppMain.AKM_DEGtoA32( 1f ) ) ), num ) - AppMain.FX_Mul( AppMain.FX_Sin( ( int )( ( short )AppMain.AKM_DEGtoA32( 1f ) ) ), num2 );
                num2 = AppMain.FX_Mul( AppMain.FX_Sin( ( int )( ( short )AppMain.AKM_DEGtoA32( 1f ) ) ), num ) + AppMain.FX_Mul( AppMain.FX_Cos( ( int )( ( short )AppMain.AKM_DEGtoA32( 1f ) ) ), num2 );
            }
            else
            {
                num = AppMain.FX_Mul( AppMain.FX_Cos( ( int )( ( short )AppMain.AKM_DEGtoA32( -1f ) ) ), num ) - AppMain.FX_Mul( AppMain.FX_Sin( ( int )( ( short )AppMain.AKM_DEGtoA32( -1f ) ) ), num2 );
                num2 = AppMain.FX_Mul( AppMain.FX_Sin( ( int )( ( short )AppMain.AKM_DEGtoA32( -1f ) ) ), num ) + AppMain.FX_Mul( AppMain.FX_Cos( ( int )( ( short )AppMain.AKM_DEGtoA32( -1f ) ) ), num2 );
            }
            obj_work.spd.x = ( int )( ( float )num * 1.75f );
            obj_work.spd.y = ( int )( ( float )num2 * 1.75f );
            gms_ENE_KAMA_WORK.timer--;
            return;
        }
        obj_work.spd.x = 0;
        obj_work.spd_fall = AppMain.FX_F32_TO_FX32( 0.2f );
        obj_work.move_flag |= 128U;
        AppMain.GMS_ENE_KAMA_WORK gms_ENE_KAMA_WORK2 = (AppMain.GMS_ENE_KAMA_WORK)obj_work.parent_obj;
        if ( gms_ENE_KAMA_WORK2 != null )
        {
            gms_ENE_KAMA_WORK2.ata_futa = 1;
        }
    }

    // Token: 0x06000957 RID: 2391 RVA: 0x00054629 File Offset: 0x00052829
    private static void gmEneKamaFadeAnimeSet( AppMain.GMS_ENE_KAMA_WORK kama_work, AppMain.GMS_ENE_KAMA_FADE_ANIME anime_data )
    {
        kama_work.anime_data = anime_data;
        kama_work.anime_pat_no = 0U;
        kama_work.anime_frame = 0;
    }

    // Token: 0x06000958 RID: 2392 RVA: 0x00054640 File Offset: 0x00052840
    private static void gmEneKamaFadeAnimeUpdate( AppMain.GMS_ENE_KAMA_WORK kama_work, int speed, int repeat )
    {
        AppMain.GMS_ENE_KAMA_FADE_ANIME anime_data = kama_work.anime_data;
        AppMain.GMS_ENE_KAMA_FADE_ANIME_PAT gms_ENE_KAMA_FADE_ANIME_PAT = anime_data.anime_pat[(int)((UIntPtr)kama_work.anime_pat_no)];
        kama_work.anime_frame += speed;
        while ( kama_work.anime_frame >= gms_ENE_KAMA_FADE_ANIME_PAT.frame )
        {
            kama_work.anime_frame -= gms_ENE_KAMA_FADE_ANIME_PAT.frame;
            kama_work.anime_pat_no += 1U;
            if ( kama_work.anime_pat_no < anime_data.pat_num )
            {
                gms_ENE_KAMA_FADE_ANIME_PAT = anime_data.anime_pat[( int )( ( UIntPtr )kama_work.anime_pat_no )];
            }
            else if ( repeat != 0 )
            {
                kama_work.anime_pat_no = 0U;
                gms_ENE_KAMA_FADE_ANIME_PAT = anime_data.anime_pat[( int )( ( UIntPtr )kama_work.anime_pat_no )];
            }
            else
            {
                kama_work.anime_pat_no = anime_data.pat_num - 1U;
                kama_work.anime_frame = gms_ENE_KAMA_FADE_ANIME_PAT.frame - 1;
            }
        }
        AppMain.GmBsCmnSetObject3DNNFadedColor( ( AppMain.OBS_OBJECT_WORK )kama_work, gms_ENE_KAMA_FADE_ANIME_PAT.col, gms_ENE_KAMA_FADE_ANIME_PAT.intensity );
    }
}
