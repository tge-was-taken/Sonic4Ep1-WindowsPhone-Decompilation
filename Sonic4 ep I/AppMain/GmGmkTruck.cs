using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200017F RID: 383
    // (Invoke) Token: 0x06002194 RID: 8596
    public delegate void pfnGMS_GMK_TRUCK_WORK( AppMain.GMS_GMK_TRUCK_WORK a, AppMain.GMS_PLAYER_WORK b );

    // Token: 0x02000180 RID: 384
    public class GMS_GMK_TRUCK_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002197 RID: 8599 RVA: 0x00141570 File Offset: 0x0013F770
        public GMS_GMK_TRUCK_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06002198 RID: 8600 RVA: 0x001415C6 File Offset: 0x0013F7C6
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_TRUCK_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06002199 RID: 8601 RVA: 0x001415D8 File Offset: 0x0013F7D8
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004EAB RID: 20139
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004EAC RID: 20140
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_tire = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004EAD RID: 20141
        public AppMain.GMS_GMK_TRUCK_WORK seq;

        // Token: 0x04004EAE RID: 20142
        public AppMain.GMS_PLAYER_WORK target_player;

        // Token: 0x04004EAF RID: 20143
        public int tire_spd_for_dir;

        // Token: 0x04004EB0 RID: 20144
        public int tire_dir_spd;

        // Token: 0x04004EB1 RID: 20145
        public ushort tire_dir;

        // Token: 0x04004EB2 RID: 20146
        public readonly AppMain.NNS_MATRIX tire_pos_f = new AppMain.NNS_MATRIX();

        // Token: 0x04004EB3 RID: 20147
        public readonly AppMain.NNS_MATRIX tire_pos_b = new AppMain.NNS_MATRIX();

        // Token: 0x04004EB4 RID: 20148
        public readonly AppMain.NNS_MATRIX light_pos = new AppMain.NNS_MATRIX();

        // Token: 0x04004EB5 RID: 20149
        public readonly AppMain.NNS_VECTOR trans_r = new AppMain.NNS_VECTOR();

        // Token: 0x04004EB6 RID: 20150
        public ushort slope_z_dir;

        // Token: 0x04004EB7 RID: 20151
        public ushort slope_f_y_dir;

        // Token: 0x04004EB8 RID: 20152
        public ushort slope_f_z_dir;

        // Token: 0x04004EB9 RID: 20153
        public AppMain.GMS_EFFECT_3DES_WORK efct_f_spark;

        // Token: 0x04004EBA RID: 20154
        public AppMain.GMS_EFFECT_3DES_WORK efct_b_spark;

        // Token: 0x04004EBB RID: 20155
        public AppMain.GSS_SND_SE_HANDLE h_snd_lorry;
    }

    // Token: 0x06000669 RID: 1641 RVA: 0x00038B56 File Offset: 0x00036D56
    public static void GmGmkTruckBuild()
    {
        AppMain.gm_gmk_truck_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 928 ), AppMain.GmGameDatGetGimmickData( 929 ), 0U );
    }

    // Token: 0x0600066A RID: 1642 RVA: 0x00038B78 File Offset: 0x00036D78
    public static void GmGmkTruckFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(928);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_truck_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600066B RID: 1643 RVA: 0x00038BA8 File Offset: 0x00036DA8
    public static AppMain.OBS_OBJECT_WORK GmGmkTruckInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_TRUCK_WORK(), "GMK_TRUCK");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obs_OBJECT_WORK;
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkTruckDest ) );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_truck_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 930 ), null, 0, null );
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
        AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_truck_obj_3d_list[1], gms_GMK_TRUCK_WORK.obj_3d_tire );
        gms_ENEMY_3D_WORK.obj_3d.mtn_cb_func = new AppMain.mtn_cb_func_delegate( AppMain.gmGmkTruckMotionCallback );
        gms_ENEMY_3D_WORK.obj_3d.mtn_cb_param = gms_GMK_TRUCK_WORK;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckDispFunc );
        obs_OBJECT_WORK.flag |= 1U;
        obs_OBJECT_WORK.move_flag |= 128U;
        obs_OBJECT_WORK.disp_flag |= 16777220U;
        obs_OBJECT_WORK.disp_flag |= 16U;
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.125f;
        gms_GMK_TRUCK_WORK.trans_r.x = 0f;
        gms_GMK_TRUCK_WORK.trans_r.y = 0f;
        gms_GMK_TRUCK_WORK.trans_r.z = 4f / AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.draw_scale.x );
        AppMain.nnMakeUnitMatrix( gms_ENEMY_3D_WORK.obj_3d.user_obj_mtx_r );
        AppMain.nnTranslateMatrix( gms_ENEMY_3D_WORK.obj_3d.user_obj_mtx_r, gms_ENEMY_3D_WORK.obj_3d.user_obj_mtx_r, gms_GMK_TRUCK_WORK.trans_r.x, gms_GMK_TRUCK_WORK.trans_r.y, gms_GMK_TRUCK_WORK.trans_r.z );
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, ( short )AppMain.GMD_GMK_TRUCK_FIELD_RECT_LEFT, ( short )AppMain.GMD_GMK_TRUCK_FIELD_RECT_TOP, ( short )AppMain.GMD_GMK_TRUCK_FIELD_RECT_RIGHT, ( short )AppMain.GMD_GMK_TRUCK_FIELD_RECT_BOTTOM );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkTruckBodyDefFunc );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -64, -64, 64, 64 );
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = -0.85f;
        nns_VECTOR.y = -0.45f;
        nns_VECTOR.z = -3.05f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_1, ref nns_RGBA, 1f, nns_VECTOR );
        gms_ENEMY_3D_WORK.obj_3d.use_light_flag &= 4294967294U;
        gms_GMK_TRUCK_WORK.obj_3d_tire.use_light_flag &= 4294967294U;
        gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 2U;
        gms_GMK_TRUCK_WORK.obj_3d_tire.use_light_flag |= 2U;
        AppMain.gmGmkTruckCreateLightEfct( gms_GMK_TRUCK_WORK );
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 65536U;
        obs_OBJECT_WORK.obj_3d.command_state = 16U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600066C RID: 1644 RVA: 0x00038ED8 File Offset: 0x000370D8
    public static AppMain.OBS_OBJECT_WORK GmGmkTruckGravityInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_T_GRAVITY");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 1, 1 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        if ( 239 <= eve_rec.id && eve_rec.id <= 246 )
        {
            short[] array;
            if ( 239 <= eve_rec.id && eve_rec.id <= 242 )
            {
                array = AppMain.gm_gmk_t_gravity_r_rect_tbl;
            }
            else
            {
                array = AppMain.gm_gmk_t_gravity_rr_rect_tbl[( int )( eve_rec.id - 243 )];
            }
            AppMain.ObjRectSet( obs_RECT_WORK.rect, array[0], array[1], array[2], array[3] );
        }
        else
        {
            AppMain.ObjRectSet( obs_RECT_WORK.rect, ( short )( eve_rec.left << 1 ), ( short )( eve_rec.top << 1 ), ( short )( eve_rec.width + ( byte )eve_rec.left << 1 ), ( short )( eve_rec.height + ( byte )eve_rec.top << 1 ) );
        }
        obs_RECT_WORK.parent_obj = obs_OBJECT_WORK;
        obs_RECT_WORK.flag |= 192U;
        if ( 268 <= eve_rec.id && eve_rec.id <= 271 )
        {
            obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkTGravityForceChangeDefFunc );
        }
        else
        {
            obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkTGravityChangeDefFunc );
        }
        gms_ENEMY_COM_WORK.rect_work[1].flag &= 4294967291U;
        gms_ENEMY_COM_WORK.rect_work[0].flag &= 4294967291U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600066D RID: 1645 RVA: 0x00039094 File Offset: 0x00037294
    public static AppMain.OBS_OBJECT_WORK GmGmkTruckNoLandingInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_T_NOLANDING");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 1, 1 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectSet( obs_RECT_WORK.rect, ( short )( eve_rec.left << 1 ), ( short )( eve_rec.top << 1 ), ( short )( eve_rec.width + ( byte )eve_rec.left << 1 ), ( short )( eve_rec.height + ( byte )eve_rec.top << 1 ) );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkTNoLandingDefFunc );
        obs_RECT_WORK.parent_obj = obs_OBJECT_WORK;
        obs_RECT_WORK.flag |= 192U;
        gms_ENEMY_COM_WORK.rect_work[1].flag &= 4294967291U;
        gms_ENEMY_COM_WORK.rect_work[0].flag &= 4294967291U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600066E RID: 1646 RVA: 0x000391BC File Offset: 0x000373BC
    public static void gmGmkTruckDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_GMK_TRUCK_WORK.h_snd_lorry != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_TRUCK_WORK.h_snd_lorry );
            AppMain.GsSoundFreeSeHandle( gms_GMK_TRUCK_WORK.h_snd_lorry );
            gms_GMK_TRUCK_WORK.h_snd_lorry = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x0600066F RID: 1647 RVA: 0x00039200 File Offset: 0x00037400
    public static void gmGmkTruckInitMain( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.UNREFERENCED_PARAMETER( ply_work );
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work;
        obj_work.flag |= 2U;
        obj_work.move_flag |= 8448U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckMain );
        AppMain.gmGmkTruckCreateSparkEfct( gms_GMK_TRUCK_WORK, 27 );
        gms_GMK_TRUCK_WORK.h_snd_lorry = AppMain.GsSoundAllocSeHandle();
    }

    // Token: 0x06000670 RID: 1648 RVA: 0x00039260 File Offset: 0x00037460
    public static void gmGmkTruckMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work;
        if ( gms_GMK_TRUCK_WORK.target_player == null )
        {
            AppMain.gmGmkTruckInitDeathFall( obj_work, null );
            obj_work.ppFunc( obj_work );
            return;
        }
        if ( ( gms_GMK_TRUCK_WORK.target_player.player_flag & 262144U ) == 0U )
        {
            AppMain.gmGmkTruckInitFree( obj_work, gms_GMK_TRUCK_WORK.target_player );
            obj_work.ppFunc( obj_work );
            return;
        }
        if ( ( gms_GMK_TRUCK_WORK.target_player.gmk_flag2 & 64U ) != 0U )
        {
            AppMain.gmGmkTruckInitDeathFall( obj_work, gms_GMK_TRUCK_WORK.target_player );
            obj_work.ppFunc( obj_work );
            return;
        }
        if ( ( gms_GMK_TRUCK_WORK.target_player.player_flag & 1024U ) != 0U )
        {
            obj_work.pos.z = 983040;
        }
        AppMain.GMS_PLAYER_WORK target_player = gms_GMK_TRUCK_WORK.target_player;
        obj_work.prev_pos = obj_work.pos;
        obj_work.pos.x = target_player.obj_work.pos.x;
        obj_work.pos.y = target_player.obj_work.pos.y;
        obj_work.move.x = obj_work.pos.x - obj_work.prev_pos.x;
        obj_work.move.y = obj_work.pos.y - obj_work.prev_pos.y;
        obj_work.move.z = obj_work.pos.z - obj_work.prev_pos.z;
        obj_work.dir = target_player.obj_work.dir;
        obj_work.dir.z = ( ushort )( obj_work.dir.z + target_player.obj_work.dir_fall );
        obj_work.vib_timer = target_player.obj_work.vib_timer;
        obj_work.disp_flag &= 4294967279U;
        if ( ( target_player.obj_work.move_flag & 1U ) != 0U )
        {
            gms_GMK_TRUCK_WORK.tire_dir_spd = target_player.obj_work.spd_m;
        }
        else
        {
            gms_GMK_TRUCK_WORK.tire_dir_spd = AppMain.ObjSpdDownSet( gms_GMK_TRUCK_WORK.tire_dir_spd, 128 );
        }
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK2 = gms_GMK_TRUCK_WORK;
        gms_GMK_TRUCK_WORK2.tire_dir += ( ushort )AppMain.FX_Div( gms_GMK_TRUCK_WORK.tire_dir_spd, 65536 );
        int num = -1;
        uint num2 = 0U;
        if ( ( 0 <= target_player.act_state && target_player.act_state <= 7 ) || target_player.act_state == 69 || target_player.act_state == 70 || target_player.act_state == 74 || target_player.act_state == 76 || target_player.act_state == 75 )
        {
            num = 3;
            num2 = 4U;
        }
        else if ( 71 <= target_player.act_state && target_player.act_state <= 72 )
        {
            num = 0;
            num2 = 4U;
        }
        else if ( ( target_player.obj_work.move_flag & 1U ) == 0U )
        {
            num = 1;
            num2 = 4U;
        }
        else if ( ( target_player.obj_work.move_flag & 1U ) != 0U && ( target_player.obj_work.move_flag & 4194304U ) == 0U )
        {
            num = 2;
        }
        else if ( obj_work.obj_3d.act_id[0] == 2 && ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( target_player.obj_work.spd_m != 0 )
            {
                num = 0;
            }
            else
            {
                num = 3;
            }
            num2 = 4U;
        }
        else if ( 11 <= target_player.act_state && target_player.act_state <= 16 && ( obj_work.obj_3d.act_id[0] != 2 || ( obj_work.disp_flag & 8U ) != 0U ) )
        {
            num = 3;
            num2 = 4U;
        }
        if ( num != -1 && obj_work.obj_3d.act_id[0] != num )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, num );
            obj_work.disp_flag |= num2;
        }
        if ( obj_work.obj_3d.act_id[0] != 3 && ( 11 > target_player.act_state || target_player.act_state > 16 || obj_work.obj_3d.act_id[0] != 2 ) )
        {
            obj_work.obj_3d.frame[0] = target_player.obj_work.obj_3d.frame[0];
        }
        gms_GMK_TRUCK_WORK.slope_f_y_dir = 0;
        gms_GMK_TRUCK_WORK.slope_f_z_dir = 0;
        gms_GMK_TRUCK_WORK.slope_z_dir = 0;
        float num3;
        float num4;
        float num5;
        if ( ( target_player.player_flag & 4U ) == 0U )
        {
            num3 = 0f;
            num4 = 8f;
            num5 = -5f;
        }
        else
        {
            num3 = 0f;
            num4 = 8f;
            num5 = 5f;
        }
        AppMain.nnMakeUnitMatrix( obj_work.obj_3d.user_obj_mtx_r );
        AppMain.nnTranslateMatrix( obj_work.obj_3d.user_obj_mtx_r, obj_work.obj_3d.user_obj_mtx_r, gms_GMK_TRUCK_WORK.trans_r.x, gms_GMK_TRUCK_WORK.trans_r.y, gms_GMK_TRUCK_WORK.trans_r.z );
        if ( ( target_player.gmk_flag & 262144U ) != 0U && target_player.gmk_work3 != 0 )
        {
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            gms_GMK_TRUCK_WORK.slope_z_dir = ( ushort )target_player.gmk_work3;
            gms_GMK_TRUCK_WORK.slope_f_z_dir = ( ushort )( AppMain.MTM_MATH_ABS( target_player.gmk_work3 ) >> 2 );
            gms_GMK_TRUCK_WORK.slope_f_y_dir = ( ushort )( target_player.gmk_work3 >> 2 );
            AppMain.nnMakeUnitMatrix( nns_MATRIX );
            AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, -num3, -num4, -num5 );
            AppMain.nnRotateXMatrix( nns_MATRIX, nns_MATRIX, ( int )gms_GMK_TRUCK_WORK.slope_z_dir );
            AppMain.nnRotateYMatrix( nns_MATRIX, nns_MATRIX, ( int )gms_GMK_TRUCK_WORK.slope_f_y_dir );
            AppMain.nnRotateZMatrix( nns_MATRIX, nns_MATRIX, ( int )gms_GMK_TRUCK_WORK.slope_f_z_dir );
            AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, num3, num4, num5 );
            AppMain.nnMultiplyMatrix( obj_work.obj_3d.user_obj_mtx_r, obj_work.obj_3d.user_obj_mtx_r, nns_MATRIX );
            AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        }
        if ( ( target_player.obj_work.move_flag & 1U ) != 0U && AppMain.MTM_MATH_ABS( target_player.obj_work.spd_m ) >= AppMain.GMD_GMK_TRUCK_SPARK_EFCT_SMALL_MIN_SPD && ( gms_GMK_TRUCK_WORK.efct_f_spark == null || gms_GMK_TRUCK_WORK.efct_b_spark == null ) )
        {
            AppMain.gmGmkTruckCreateSparkEfct( gms_GMK_TRUCK_WORK, 27 );
        }
        if ( gms_GMK_TRUCK_WORK.h_snd_lorry.au_player.sound == null || gms_GMK_TRUCK_WORK.h_snd_lorry.au_player.sound[0] == null )
        {
            gms_GMK_TRUCK_WORK.h_snd_lorry = AppMain.GsSoundAllocSeHandle();
            gms_GMK_TRUCK_WORK.h_snd_lorry.au_player.SetAisac( "Speed", 0f );
            AppMain.GmSoundPlaySEForce( "Lorry", gms_GMK_TRUCK_WORK.h_snd_lorry, true );
        }
        AppMain.gmGmkTruckSetMoveSeParam( obj_work, gms_GMK_TRUCK_WORK.h_snd_lorry, target_player, ( ( target_player.player_flag & 16777216U ) != 0U ) ? 1 : 0 );
    }

    // Token: 0x06000671 RID: 1649 RVA: 0x0003980C File Offset: 0x00037A0C
    public static void gmGmkTruckInitFree( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work;
        gms_GMK_TRUCK_WORK.target_player = null;
        uint num;
        uint num2;
        if ( ply_work != null )
        {
            obj_work.spd = ply_work.obj_work.spd;
            obj_work.spd_m = ply_work.obj_work.spd_m;
            num = ply_work.obj_work.flag;
            num2 = ply_work.obj_work.move_flag;
        }
        else
        {
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            obj_work.spd.z = 0;
            num = 0U;
            num2 = 0U;
        }
        obj_work.flag &= 4294967294U;
        obj_work.flag |= ( 2U | ( num & 1U ) );
        obj_work.flag &= 4294967279U;
        obj_work.move_flag |= 192U;
        obj_work.move_flag &= 4294401791U;
        if ( ( num2 & 16U ) != 0U )
        {
            obj_work.move_flag |= 16U;
        }
        else
        {
            if ( obj_work.spd.x > obj_work.spd_m )
            {
                obj_work.spd_m = obj_work.spd.x;
            }
            obj_work.spd.x = 0;
            if ( obj_work.obj_3d.act_id[0] != 0 )
            {
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 0 );
                obj_work.disp_flag |= 4U;
            }
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckFreeMain );
    }

    // Token: 0x06000672 RID: 1650 RVA: 0x00039960 File Offset: 0x00037B60
    public static void gmGmkTruckFreeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work;
        if ( ( obj_work.move_flag & 1U ) != 0U && ( obj_work.move_flag & 16U ) != 0U )
        {
            if ( obj_work.spd.x > obj_work.spd_m )
            {
                obj_work.spd_m = obj_work.spd.x;
            }
            obj_work.spd.x = 0;
            obj_work.move_flag &= 4294967279U;
            if ( obj_work.obj_3d.act_id[0] != 0 )
            {
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 0 );
                obj_work.disp_flag |= 4U;
            }
            AppMain.GmSoundPlaySE( "Lorry4" );
        }
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            obj_work.spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, 128, 40960 );
        }
        else
        {
            obj_work.spd.x = AppMain.ObjSpdUpSet( obj_work.spd.x, 128, 40960 );
        }
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            gms_GMK_TRUCK_WORK.tire_dir_spd = obj_work.spd_m;
        }
        else
        {
            gms_GMK_TRUCK_WORK.tire_dir_spd = AppMain.ObjSpdDownSet( gms_GMK_TRUCK_WORK.tire_dir_spd, 128 );
        }
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK2 = gms_GMK_TRUCK_WORK;
        gms_GMK_TRUCK_WORK2.tire_dir += ( ushort )AppMain.FX_Div( gms_GMK_TRUCK_WORK.tire_dir_spd, 16384 );
        if ( ( obj_work.move_flag & 1U ) != 0U && AppMain.MTM_MATH_ABS( obj_work.spd_m ) >= AppMain.GMD_GMK_TRUCK_SPARK_EFCT_SMALL_MIN_SPD && ( gms_GMK_TRUCK_WORK.efct_f_spark == null || gms_GMK_TRUCK_WORK.efct_b_spark == null ) )
        {
            AppMain.gmGmkTruckCreateSparkEfct( gms_GMK_TRUCK_WORK, 27 );
        }
        AppMain.gmGmkTruckSetMoveSeParam( obj_work, gms_GMK_TRUCK_WORK.h_snd_lorry, null, 1 );
    }

    // Token: 0x06000673 RID: 1651 RVA: 0x00039AD4 File Offset: 0x00037CD4
    public static void gmGmkTruckInitDeathFall( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_PLAYER_WORK ply_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work;
        gms_GMK_TRUCK_WORK.target_player = null;
        if ( ply_work != null )
        {
            obj_work.spd = ply_work.obj_work.spd;
            obj_work.spd_m = ply_work.obj_work.spd_m;
        }
        else
        {
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            obj_work.spd.z = 0;
        }
        AppMain.ObjObjectSpdDirFall( ref obj_work.spd.x, ref obj_work.spd.y, AppMain.g_gm_main_system.pseudofall_dir );
        obj_work.spd.x = AppMain.FX_Mul( obj_work.spd.x, 4608 );
        obj_work.spd.y = AppMain.FX_Mul( obj_work.spd.y, 4608 );
        obj_work.spd_add.x = 0;
        obj_work.spd_add.y = obj_work.spd_fall;
        AppMain.ObjObjectSpdDirFall( ref obj_work.spd_add.x, ref obj_work.spd_add.y, AppMain.g_gm_main_system.pseudofall_dir );
        obj_work.flag |= 2U;
        obj_work.flag &= 4294967279U;
        obj_work.move_flag |= 272U;
        obj_work.move_flag &= 4294958975U;
        obj_work.pos.z = 983040;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckDeathFallMain );
    }

    // Token: 0x06000674 RID: 1652 RVA: 0x00039C44 File Offset: 0x00037E44
    public static void gmGmkTruckDeathFallMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.dir.z = ( ushort )( obj_work.dir.z + 1024 );
    }

    // Token: 0x06000675 RID: 1653 RVA: 0x00039C60 File Offset: 0x00037E60
    public static void gmGmkTruckDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work;
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.VecU16 dir = obj_work.dir;
        uint num = obj_work.disp_flag | 16777216U;
        AppMain.nnMakeRotateXYZMatrix( gms_GMK_TRUCK_WORK.obj_3d_tire.user_obj_mtx_r, ( int )gms_GMK_TRUCK_WORK.tire_dir, ( int )gms_GMK_TRUCK_WORK.slope_f_y_dir, ( int )gms_GMK_TRUCK_WORK.slope_f_z_dir );
        AppMain.VecFx32 vecFx;
        vecFx.x = AppMain.FXM_FLOAT_TO_FX32( gms_GMK_TRUCK_WORK.tire_pos_f.M03 );
        vecFx.y = AppMain.FXM_FLOAT_TO_FX32( -gms_GMK_TRUCK_WORK.tire_pos_f.M13 );
        vecFx.z = AppMain.FXM_FLOAT_TO_FX32( gms_GMK_TRUCK_WORK.tire_pos_f.M23 );
        AppMain.ObjDrawAction3DNN( gms_GMK_TRUCK_WORK.obj_3d_tire, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( dir ), obj_work.scale, ref num );
        vecFx.x = AppMain.FXM_FLOAT_TO_FX32( gms_GMK_TRUCK_WORK.tire_pos_b.M03 );
        vecFx.y = AppMain.FXM_FLOAT_TO_FX32( -gms_GMK_TRUCK_WORK.tire_pos_b.M13 );
        vecFx.z = AppMain.FXM_FLOAT_TO_FX32( gms_GMK_TRUCK_WORK.tire_pos_b.M23 );
        AppMain.ObjDrawAction3DNN( gms_GMK_TRUCK_WORK.obj_3d_tire, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( dir ), obj_work.scale, ref num );
    }

    // Token: 0x06000676 RID: 1654 RVA: 0x00039D7C File Offset: 0x00037F7C
    public static void gmGmkTruckBodyDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)gms_ENEMY_COM_WORK;
        gms_ENEMY_COM_WORK.obj_work.flag |= 16U;
        AppMain.GmPlayerSetTruckRide( gms_PLAYER_WORK, gms_ENEMY_COM_WORK.obj_work, gms_ENEMY_COM_WORK.obj_work.field_rect[0], gms_ENEMY_COM_WORK.obj_work.field_rect[1], gms_ENEMY_COM_WORK.obj_work.field_rect[2], gms_ENEMY_COM_WORK.obj_work.field_rect[3] );
        gms_GMK_TRUCK_WORK.target_player = gms_PLAYER_WORK;
        AppMain.gmGmkTruckInitMain( gms_ENEMY_COM_WORK.obj_work, gms_PLAYER_WORK );
    }

    // Token: 0x06000677 RID: 1655 RVA: 0x00039E28 File Offset: 0x00038028
    public static void gmGmkTruckMotionCallback( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object param )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)param;
        AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
        AppMain.nnMultiplyMatrix( nns_MATRIX2, nns_MATRIX2, AppMain.amMatrixGetCurrent() );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_GMK_TRUCK_NODE_ID_TIRE_POS_F, motion.data, nns_MATRIX2 );
        gms_GMK_TRUCK_WORK.tire_pos_f.Assign( nns_MATRIX );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_GMK_TRUCK_NODE_ID_TIRE_POS_B, motion.data, nns_MATRIX2 );
        gms_GMK_TRUCK_WORK.tire_pos_b.Assign( nns_MATRIX );
        AppMain.nnCalcNodeMatrixTRSList( nns_MATRIX, _object, AppMain.GMD_GMK_TRUCK_NODE_ID_LIGHT_POS, motion.data, nns_MATRIX2 );
        gms_GMK_TRUCK_WORK.light_pos.Assign( nns_MATRIX );
    }

    // Token: 0x06000678 RID: 1656 RVA: 0x00039ECC File Offset: 0x000380CC
    public static void gmGmkTruckSetMoveSeParam( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GSS_SND_SE_HANDLE h_snd, AppMain.GMS_PLAYER_WORK ply_work, int b_goal )
    {
        float num = 0f;
        if ( h_snd == null )
        {
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        if ( ply_work != null )
        {
            obs_OBJECT_WORK = ply_work.obj_work;
        }
        else
        {
            obs_OBJECT_WORK = obj_work;
        }
        int num2 = AppMain.MTM_MATH_ABS(obs_OBJECT_WORK.spd_m);
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U && num2 >= AppMain.GMD_GMK_TRUCK_SE_MIN_SPD )
        {
            if ( num2 >= AppMain.GMD_GMK_TRUCK_SE_MAX_SPD )
            {
                num = 1f;
            }
            else
            {
                num = AppMain.FXM_FX32_TO_FLOAT( AppMain.FX_Div( num2 - AppMain.GMD_GMK_TRUCK_SE_MIN_SPD, AppMain.GMD_GMK_TRUCK_SE_MAX_SPD - AppMain.GMD_GMK_TRUCK_SE_MIN_SPD ) );
                if ( num > 1f )
                {
                    num = 1f;
                }
            }
        }
        h_snd.au_player.SetAisac( "Speed", num );
        if ( b_goal != 0 )
        {
            AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
            float num3 = AppMain.FXM_FX32_TO_FLOAT(obs_OBJECT_WORK.pos.x) - obs_CAMERA.disp_pos.x;
            float num4 = AppMain.FXM_FX32_TO_FLOAT(obs_OBJECT_WORK.pos.y) - -obs_CAMERA.disp_pos.y;
            float num6;
            if ( num3 < AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST && num4 < AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST )
            {
                float num5 = num3 * num3 + num4 * num4;
                if ( num5 <= AppMain.GMD_GMK_TRUCK_SE_GOAL_MIN_DIST * AppMain.GMD_GMK_TRUCK_SE_GOAL_MIN_DIST )
                {
                    num6 = 1f;
                }
                else if ( num5 <= AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST * AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST )
                {
                    num6 = ( AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST * AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST - num5 ) / ( ( AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST - AppMain.GMD_GMK_TRUCK_SE_GOAL_MIN_DIST ) * ( AppMain.GMD_GMK_TRUCK_SE_GOAL_MAX_DIST - AppMain.GMD_GMK_TRUCK_SE_GOAL_MIN_DIST ) );
                    if ( num6 > 1f )
                    {
                        num6 = 1f;
                    }
                    else if ( num6 < 0f )
                    {
                        num6 = 0f;
                    }
                }
                else
                {
                    num6 = 0f;
                }
            }
            else
            {
                num6 = 0f;
            }
            h_snd.snd_ctrl_param.volume = num6;
        }
    }

    // Token: 0x06000679 RID: 1657 RVA: 0x0003A064 File Offset: 0x00038264
    public static void gmGmkTGravityChangeDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( ( ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_T_GRAVITY_A ) != 0 && ( gms_PLAYER_WORK.obj_work.flag & 1U ) != 0U ) || ( ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_T_GRAVITY_B ) != 0 && ( gms_PLAYER_WORK.obj_work.flag & 1U ) == 0U ) )
        {
            return;
        }
        ushort num6;
        if ( 239 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 246 )
        {
            int num;
            int num2;
            int num3;
            if ( 239 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 242 )
            {
                num = ( int )( gms_ENEMY_COM_WORK.eve_rec.id - 239 );
                if ( ( num & 2 ) != 0 )
                {
                    num2 = gms_ENEMY_COM_WORK.obj_work.pos.x + 524288;
                }
                else
                {
                    num2 = gms_ENEMY_COM_WORK.obj_work.pos.x - 524288;
                }
                if ( ( num + 1 & 2 ) != 0 )
                {
                    num3 = gms_ENEMY_COM_WORK.obj_work.pos.y - 524288;
                }
                else
                {
                    num3 = gms_ENEMY_COM_WORK.obj_work.pos.y + 524288;
                }
                gms_PLAYER_WORK.gmk_flag2 |= 8U;
            }
            else
            {
                num = ( int )( gms_ENEMY_COM_WORK.eve_rec.id - 243 );
                if ( ( num & 2 ) != 0 )
                {
                    num2 = gms_ENEMY_COM_WORK.obj_work.pos.x - 524288;
                }
                else
                {
                    num2 = gms_ENEMY_COM_WORK.obj_work.pos.x + 524288;
                }
                if ( ( num + 1 & 2 ) != 0 )
                {
                    num3 = gms_ENEMY_COM_WORK.obj_work.pos.y + 524288;
                }
                else
                {
                    num3 = gms_ENEMY_COM_WORK.obj_work.pos.y - 524288;
                }
            }
            float num4 = AppMain.FXM_FX32_TO_FLOAT(num2 - gms_PLAYER_WORK.obj_work.pos.x);
            float num5 = AppMain.FXM_FX32_TO_FLOAT(num3 - gms_PLAYER_WORK.obj_work.pos.y);
            if ( 239 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 242 )
            {
                if ( ( num & 2 ) != 0 )
                {
                    if ( num4 < 0f )
                    {
                        return;
                    }
                }
                else if ( num4 > 0f )
                {
                    return;
                }
                if ( ( num + 1 & 2 ) != 0 )
                {
                    if ( num5 > 0f )
                    {
                        return;
                    }
                }
                else if ( num5 < 0f )
                {
                    return;
                }
            }
            else
            {
                if ( ( num & 2 ) != 0 )
                {
                    if ( num4 > 0f )
                    {
                        return;
                    }
                }
                else if ( num4 < 0f )
                {
                    return;
                }
                if ( ( num + 1 & 2 ) != 0 )
                {
                    if ( num5 < 0f )
                    {
                        return;
                    }
                }
                else if ( num5 > 0f )
                {
                    return;
                }
            }
            num6 = ( ushort )( AppMain.nnArcTan2( ( double )( -( double )num5 ), ( double )num4 ) - 16384 );
            num6 = ( ushort )( 65536 - ( int )num6 );
            if ( 239 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 242 )
            {
                num6 -= 32768;
            }
        }
        else
        {
            num6 = AppMain.gm_gmk_t_gravity_flat_dir_tbl[( int )( gms_ENEMY_COM_WORK.eve_rec.id - 223 )];
        }
        if ( gms_PLAYER_WORK.jump_pseudofall_eve_id_cur != gms_ENEMY_COM_WORK.eve_rec.id )
        {
            gms_PLAYER_WORK.jump_pseudofall_eve_id_wait = gms_ENEMY_COM_WORK.eve_rec.id;
            return;
        }
        if ( ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_T_CLEAR_PSEUDOFALL_DIR_FIX ) != 0 )
        {
            gms_PLAYER_WORK.gmk_flag &= 4278190079U;
        }
        if ( ( gms_PLAYER_WORK.gmk_flag & 16777216U ) != 0U )
        {
            return;
        }
        AppMain.ObjObjectSpdDirFall( ref gms_PLAYER_WORK.obj_work.spd.x, ref gms_PLAYER_WORK.obj_work.spd.y, ( ushort )( -( num6 - gms_PLAYER_WORK.jump_pseudofall_dir ) ) );
        gms_PLAYER_WORK.jump_pseudofall_dir = num6;
        gms_PLAYER_WORK.jump_pseudofall_eve_id_set = gms_ENEMY_COM_WORK.eve_rec.id;
    }

    // Token: 0x0600067A RID: 1658 RVA: 0x0003A418 File Offset: 0x00038618
    public static void gmGmkTGravityForceChangeDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 || ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) != 0U )
        {
            return;
        }
        if ( ( ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_T_GRAVITY_A ) != 0 && ( gms_PLAYER_WORK.obj_work.flag & 1U ) != 0U ) || ( ( ( int )gms_ENEMY_COM_WORK.eve_rec.flag & AppMain.GMD_GMK_T_GRAVITY_B ) != 0 && ( gms_PLAYER_WORK.obj_work.flag & 1U ) == 0U ) )
        {
            return;
        }
        int num = (int)((gms_ENEMY_COM_WORK.eve_rec.id - 268) * 16384);
        ushort num2 = (ushort)(num - (int)gms_PLAYER_WORK.jump_pseudofall_dir);
        gms_PLAYER_WORK.jump_pseudofall_dir = ( ushort )num;
        int num3 = num - gms_PLAYER_WORK.ply_pseudofall_dir;
        if ( ( ushort )AppMain.MTM_MATH_ABS( num3 ) > 32768 )
        {
            if ( num3 < 0 )
            {
                gms_PLAYER_WORK.ply_pseudofall_dir += 65536 + num3;
            }
            else
            {
                gms_PLAYER_WORK.ply_pseudofall_dir += num3 - 65536;
            }
        }
        else
        {
            gms_PLAYER_WORK.ply_pseudofall_dir = num;
        }
        AppMain.ObjObjectSpdDirFall( ref gms_PLAYER_WORK.obj_work.spd.x, ref gms_PLAYER_WORK.obj_work.spd.y, ( ushort )-num2 );
        gms_PLAYER_WORK.gmk_flag |= 16777216U;
    }

    // Token: 0x0600067B RID: 1659 RVA: 0x0003A55C File Offset: 0x0003875C
    public static void gmGmkTNoLandingDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        gms_PLAYER_WORK.obj_work.sys_flag |= 1U << ( int )( gms_ENEMY_COM_WORK.eve_rec.id - 264 );
    }

    // Token: 0x0600067C RID: 1660 RVA: 0x0003A5C0 File Offset: 0x000387C0
    public static void gmGmkTruckCreateLightEfct( AppMain.GMS_GMK_TRUCK_WORK truck_work )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate((AppMain.OBS_OBJECT_WORK)truck_work, 2, 10);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.user_work_OBJECT = truck_work.light_pos;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckLightEfctMain );
        gms_EFFECT_3DES_WORK.efct_com.obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckLightEfctDispFunc );
    }

    // Token: 0x0600067D RID: 1661 RVA: 0x0003A62C File Offset: 0x0003882C
    public static void gmGmkTruckLightEfctMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.parent_obj == null )
        {
            obj_work.flag |= 4U;
            return;
        }
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work.parent_obj;
        obj_work.dir.z = ( ushort )( obj_work.parent_obj.dir.z + gms_GMK_TRUCK_WORK.slope_z_dir );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x0600067E RID: 1662 RVA: 0x0003A698 File Offset: 0x00038898
    public static void gmGmkTruckLightEfctDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.NNS_MATRIX nns_MATRIX = (AppMain.NNS_MATRIX)obj_work.user_work_OBJECT;
        if ( obj_work.parent_obj == null )
        {
            return;
        }
        obj_work.pos.x = AppMain.FXM_FLOAT_TO_FX32( nns_MATRIX.M03 );
        obj_work.pos.y = AppMain.FXM_FLOAT_TO_FX32( -nns_MATRIX.M13 );
        obj_work.pos.z = AppMain.FXM_FLOAT_TO_FX32( nns_MATRIX.M23 );
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x0600067F RID: 1663 RVA: 0x0003A704 File Offset: 0x00038904
    public static void gmGmkTruckCreateSparkEfct( AppMain.GMS_GMK_TRUCK_WORK truck_work, int efct_type )
    {
        if ( truck_work.efct_f_spark == null )
        {
            truck_work.efct_f_spark = AppMain.GmEfctZoneEsCreate( ( AppMain.OBS_OBJECT_WORK )truck_work, 2, efct_type );
            truck_work.efct_f_spark.efct_com.obj_work.flag |= 524304U;
            truck_work.efct_f_spark.efct_com.obj_work.user_work_OBJECT = truck_work.tire_pos_f;
            truck_work.efct_f_spark.efct_com.obj_work.user_timer = efct_type;
            truck_work.efct_f_spark.efct_com.obj_work.user_flag = 0U;
            truck_work.efct_f_spark.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckSparkEfctMain );
            truck_work.efct_f_spark.efct_com.obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckSparkEfctDispFunc );
        }
        if ( truck_work.efct_b_spark == null )
        {
            truck_work.efct_b_spark = AppMain.GmEfctZoneEsCreate( ( AppMain.OBS_OBJECT_WORK )truck_work, 2, efct_type );
            truck_work.efct_b_spark.efct_com.obj_work.flag |= 524304U;
            truck_work.efct_b_spark.efct_com.obj_work.user_work_OBJECT = truck_work.tire_pos_b;
            truck_work.efct_b_spark.efct_com.obj_work.user_timer = efct_type;
            truck_work.efct_b_spark.efct_com.obj_work.user_flag = 1U;
            truck_work.efct_b_spark.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckSparkEfctMain );
            truck_work.efct_b_spark.efct_com.obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkTruckSparkEfctDispFunc );
        }
    }

    // Token: 0x06000680 RID: 1664 RVA: 0x0003A8A4 File Offset: 0x00038AA4
    public static void gmGmkTruckSparkEfctMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work.parent_obj;
        if ( obj_work.parent_obj == null )
        {
            obj_work.flag |= 4U;
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_TRUCK_WORK.target_player;
        if ( obs_OBJECT_WORK == null )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )gms_GMK_TRUCK_WORK;
        }
        uint disp_flag = obj_work.disp_flag;
        if ( ( obs_OBJECT_WORK.move_flag & 1U ) == 0U )
        {
            obj_work.disp_flag |= 32U;
            return;
        }
        obj_work.disp_flag &= 4294967263U;
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.spd_m ) < AppMain.GMD_GMK_TRUCK_SPARK_EFCT_SMALL_MIN_SPD )
        {
            if ( ( disp_flag & 32U ) != 0U )
            {
                obj_work.flag |= 8U;
            }
            else
            {
                AppMain.ObjDrawKillAction3DES( obj_work );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
            }
            if ( obj_work.user_flag == 0U )
            {
                gms_GMK_TRUCK_WORK.efct_f_spark = null;
            }
            else
            {
                gms_GMK_TRUCK_WORK.efct_b_spark = null;
            }
        }
        AppMain.GmEffectDefaultMainFuncDeleteAtEnd( obj_work );
    }

    // Token: 0x06000681 RID: 1665 RVA: 0x0003A978 File Offset: 0x00038B78
    public static void gmGmkTruckSparkEfctDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_TRUCK_WORK gms_GMK_TRUCK_WORK = (AppMain.GMS_GMK_TRUCK_WORK)obj_work.parent_obj;
        AppMain.NNS_MATRIX nns_MATRIX = (AppMain.NNS_MATRIX)obj_work.user_work_OBJECT;
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        if ( obj_work.parent_obj == null )
        {
            AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_TRUCK_WORK.target_player;
        if ( obs_OBJECT_WORK == null )
        {
            obs_OBJECT_WORK = ( AppMain.OBS_OBJECT_WORK )gms_GMK_TRUCK_WORK;
        }
        AppMain.VecFx32 pos;
        pos.x = AppMain.FXM_FLOAT_TO_FX32( nns_MATRIX.M03 );
        pos.y = AppMain.FXM_FLOAT_TO_FX32( -nns_MATRIX.M13 );
        pos.z = AppMain.FXM_FLOAT_TO_FX32( nns_MATRIX.M23 );
        ushort dir_z;
        ushort ang;
        if ( obs_OBJECT_WORK.spd_m >= 0 )
        {
            obj_work.disp_flag &= 4294967294U;
            dir_z = ( ushort )( 8192 - obj_work.parent_obj.dir.z );
            ang = ( ushort )( -obj_work.parent_obj.dir.z - 2048 );
        }
        else
        {
            obj_work.disp_flag |= 1U;
            dir_z = ( ushort )( 8192 + obj_work.parent_obj.dir.z );
            ang = ( ushort )( obj_work.parent_obj.dir.z + 2048 );
        }
        obj_work.pos = pos;
        nns_VECTOR.x = AppMain.nnSin( ( int )ang ) * AppMain.GMD_GMK_TRUCK_EFCT_SPRAK_OFST_DIST;
        nns_VECTOR.y = AppMain.nnCos( ( int )ang ) * AppMain.GMD_GMK_TRUCK_EFCT_SPRAK_OFST_DIST;
        nns_VECTOR.z = 0f;
        AppMain.GmComEfctSetDispOffsetF( ( AppMain.GMS_EFFECT_3DES_WORK )obj_work, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z );
        AppMain.GmComEfctSetDispRotation( ( AppMain.GMS_EFFECT_3DES_WORK )obj_work, 0, 0, dir_z );
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }
}