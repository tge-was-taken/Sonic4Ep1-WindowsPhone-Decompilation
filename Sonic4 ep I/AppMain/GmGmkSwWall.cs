using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200019A RID: 410
    public class GMS_GMK_SWWALL_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021E7 RID: 8679 RVA: 0x00141EEA File Offset: 0x001400EA
        public GMS_GMK_SWWALL_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060021E8 RID: 8680 RVA: 0x00141F1A File Offset: 0x0014011A
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SWWALL_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060021E9 RID: 8681 RVA: 0x00141F2C File Offset: 0x0014012C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004F23 RID: 20259
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004F24 RID: 20260
        public readonly AppMain.OBS_ACTION3D_NN_WORK[] obj_3d_opt = AppMain.New<AppMain.OBS_ACTION3D_NN_WORK>(2);

        // Token: 0x04004F25 RID: 20261
        public uint id;

        // Token: 0x04004F26 RID: 20262
        public int wall_size;

        // Token: 0x04004F27 RID: 20263
        public int wall_draw_size;

        // Token: 0x04004F28 RID: 20264
        public ushort wall_type;

        // Token: 0x04004F29 RID: 20265
        public ushort gear_dir;

        // Token: 0x04004F2A RID: 20266
        public ushort gear_base_dir;

        // Token: 0x04004F2B RID: 20267
        public AppMain.VecFx32 gear_pos;

        // Token: 0x04004F2C RID: 20268
        public AppMain.VecFx32 gearbase_pos;

        // Token: 0x04004F2D RID: 20269
        public int wall_spd;

        // Token: 0x04004F2E RID: 20270
        public byte[] col_dir_buf = new byte[128];

        // Token: 0x04004F2F RID: 20271
        public AppMain.GSS_SND_SE_HANDLE h_snd;
    }

    // Token: 0x0600074D RID: 1869 RVA: 0x0003FDC7 File Offset: 0x0003DFC7
    public static void GmGmkSwWallBuild()
    {
        AppMain.gm_gmk_sw_wall_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 934 ) ), AppMain.readAMBFile( AppMain.GmGameDatGetGimmickData( 935 ) ), 0U );
    }

    // Token: 0x0600074E RID: 1870 RVA: 0x0003FDF4 File Offset: 0x0003DFF4
    public static void GmGmkSwWallFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(934));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_sw_wall_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x0600074F RID: 1871 RVA: 0x0003FE28 File Offset: 0x0003E028
    public static AppMain.OBS_OBJECT_WORK GmGmkSwWallInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SWWALL_WORK(), "GMK_SW_WALL");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_sw_wall_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        if ( 256 <= eve_rec.id && eve_rec.id <= 259 )
        {
            AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_sw_wall_obj_3d_list[1], gms_GMK_SWWALL_WORK.obj_3d_opt[0] );
            AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_sw_wall_obj_3d_list[2], gms_GMK_SWWALL_WORK.obj_3d_opt[1] );
            gms_GMK_SWWALL_WORK.obj_3d_opt[1].drawflag |= 32U;
            gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 1U;
        }
        else
        {
            gms_GMK_SWWALL_WORK.h_snd = AppMain.GsSoundAllocSeHandle();
        }
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkSwWallDest ) );
        obs_OBJECT_WORK.pos.z = -655360;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwWallDispFunc );
        gms_GMK_SWWALL_WORK.id = ( uint )AppMain.MTM_MATH_CLIP( ( int )eve_rec.left, 0, 64 );
        ushort num;
        ushort num2;
        if ( 248 <= eve_rec.id && eve_rec.id <= 251 )
        {
            gms_GMK_SWWALL_WORK.wall_size = 524288;
            num = ( ushort )( eve_rec.id - 248 );
            num2 = 32;
        }
        else if ( 252 <= eve_rec.id && eve_rec.id <= 255 )
        {
            gms_GMK_SWWALL_WORK.wall_size = 1048576;
            num = ( ushort )( eve_rec.id - 252 );
            num2 = 32;
        }
        else
        {
            gms_GMK_SWWALL_WORK.wall_size = 393216;
            num = ( ushort )( eve_rec.id - 256 );
            num2 = 24;
            gms_GMK_SWWALL_WORK.gear_pos.Assign( obs_OBJECT_WORK.pos );
            gms_GMK_SWWALL_WORK.gearbase_pos.Assign( obs_OBJECT_WORK.pos );
            switch ( eve_rec.id )
            {
                default:
                    {
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK2 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK2.gear_pos.x = gms_GMK_SWWALL_WORK2.gear_pos.x + -144179;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK3 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK3.gear_pos.y = gms_GMK_SWWALL_WORK3.gear_pos.y + 68812;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK4 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK4.gearbase_pos.x = gms_GMK_SWWALL_WORK4.gearbase_pos.x + -196608;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK5 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK5.gearbase_pos.y = gms_GMK_SWWALL_WORK5.gearbase_pos.y + 49152;
                        gms_GMK_SWWALL_WORK.gear_base_dir = 62806;
                        break;
                    }
                case 257:
                    {
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK6 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK6.gear_pos.x = gms_GMK_SWWALL_WORK6.gear_pos.x - -144179;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK7 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK7.gear_pos.y = gms_GMK_SWWALL_WORK7.gear_pos.y + 68812;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK8 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK8.gearbase_pos.x = gms_GMK_SWWALL_WORK8.gearbase_pos.x - -196608;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK9 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK9.gearbase_pos.y = gms_GMK_SWWALL_WORK9.gearbase_pos.y + 49152;
                        gms_GMK_SWWALL_WORK.gear_base_dir = 2730;
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 4U;
                        break;
                    }
                case 258:
                    {
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK10 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK10.gear_pos.x = gms_GMK_SWWALL_WORK10.gear_pos.x + 68812;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK11 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK11.gear_pos.y = gms_GMK_SWWALL_WORK11.gear_pos.y + -144179;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK12 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK12.gearbase_pos.x = gms_GMK_SWWALL_WORK12.gearbase_pos.x + 49152;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK13 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK13.gearbase_pos.y = gms_GMK_SWWALL_WORK13.gearbase_pos.y + -196608;
                        gms_GMK_SWWALL_WORK.gear_base_dir = 8192;
                        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 4U;
                        obs_OBJECT_WORK.dir.z = 49152;
                        break;
                    }
                case 259:
                    {
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK14 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK14.gear_pos.x = gms_GMK_SWWALL_WORK14.gear_pos.x + 68812;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK15 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK15.gear_pos.y = gms_GMK_SWWALL_WORK15.gear_pos.y - -144179;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK16 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK16.gearbase_pos.x = gms_GMK_SWWALL_WORK16.gearbase_pos.x + 49152;
                        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK17 = gms_GMK_SWWALL_WORK;
                        gms_GMK_SWWALL_WORK17.gearbase_pos.y = gms_GMK_SWWALL_WORK17.gearbase_pos.y - -196608;
                        gms_GMK_SWWALL_WORK.gear_base_dir = 2730;
                        obs_OBJECT_WORK.dir.z = 49152;
                        break;
                    }
            }
        }
        gms_GMK_SWWALL_WORK.wall_type = num;
        if ( AppMain.GmGmkSwitchTypeIsGear( gms_GMK_SWWALL_WORK.id ) && ( AppMain.GmGmkSwitchGetPer( gms_GMK_SWWALL_WORK.id ) != 0 || !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) && ( AppMain.GmGmkSwitchGetPer( gms_GMK_SWWALL_WORK.id ) != 4096 || AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) )
        {
            int num3 = AppMain.GmGmkSwitchGetPer(gms_GMK_SWWALL_WORK.id);
            if ( AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) )
            {
                if ( ( eve_rec.flag & 1 ) != 0 )
                {
                    num3 = 4096 - num3;
                }
            }
            else if ( ( eve_rec.flag & 1 ) == 0 )
            {
                num3 = 4096 - num3;
            }
            gms_GMK_SWWALL_WORK.wall_draw_size = AppMain.FX_Mul( gms_GMK_SWWALL_WORK.wall_size, num3 );
        }
        else if ( ( AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) && ( eve_rec.flag & 1 ) != 0 ) || ( !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) && ( eve_rec.flag & 1 ) == 0 ) )
        {
            gms_GMK_SWWALL_WORK.wall_draw_size = gms_GMK_SWWALL_WORK.wall_size;
        }
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.dir_data = gms_GMK_SWWALL_WORK.col_dir_buf;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        col_work.obj_col.flag |= 402653216U;
        if ( num <= 1 )
        {
            col_work.obj_col.height = num2;
            col_work.obj_col.ofst_y = -16;
        }
        else
        {
            col_work.obj_col.width = num2;
            col_work.obj_col.ofst_x = -16;
        }
        AppMain.gmGmkSwWallSetCol( col_work, gms_GMK_SWWALL_WORK.wall_size, gms_GMK_SWWALL_WORK.wall_draw_size, num );
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        if ( gms_GMK_SWWALL_WORK.wall_draw_size == 0 || gms_GMK_SWWALL_WORK.wall_draw_size == gms_GMK_SWWALL_WORK.wall_size )
        {
            AppMain.gmGmkSwWallFwInit( obs_OBJECT_WORK );
        }
        else if ( ( AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) && ( eve_rec.flag & 1 ) != 0 ) || ( !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) && ( eve_rec.flag & 1 ) == 0 ) )
        {
            AppMain.gmGmkSwWallCloseInit( obs_OBJECT_WORK );
        }
        else
        {
            AppMain.gmGmkSwWallOpenInit( obs_OBJECT_WORK );
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000750 RID: 1872 RVA: 0x00040430 File Offset: 0x0003E630
    public static void gmGmkSwWallDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.enemy_flag & 2U ) != 0U )
        {
            AppMain.ObjAction3dNNMotionRelease( gms_GMK_SWWALL_WORK.obj_3d_opt[1] );
        }
        if ( gms_GMK_SWWALL_WORK.h_snd != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_SWWALL_WORK.h_snd );
            AppMain.GsSoundFreeSeHandle( gms_GMK_SWWALL_WORK.h_snd );
            gms_GMK_SWWALL_WORK.h_snd = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000751 RID: 1873 RVA: 0x00040498 File Offset: 0x0003E698
    public static void gmGmkSwWallFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        obj_work.flag &= 4294967279U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwWallFwMain );
        obj_work.col_work.obj_col.obj = obj_work;
        if ( gms_GMK_SWWALL_WORK.h_snd != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_SWWALL_WORK.h_snd );
        }
    }

    // Token: 0x06000752 RID: 1874 RVA: 0x000404F4 File Offset: 0x0003E6F4
    public static void gmGmkSwWallFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec;
        if ( gms_GMK_SWWALL_WORK.wall_draw_size != 0 )
        {
            if ( ( ( eve_rec.flag & 1 ) == 0 && AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) || ( ( eve_rec.flag & 1 ) != 0 && !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) )
            {
                AppMain.gmGmkSwWallOpenInit( obj_work );
            }
        }
        else if ( ( ( eve_rec.flag & 1 ) != 0 && AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) || ( ( eve_rec.flag & 1 ) == 0 && !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) )
        {
            AppMain.gmGmkSwWallCloseInit( obj_work );
        }
        AppMain.gmGmkSwWallCheckColOff( gms_GMK_SWWALL_WORK );
    }

    // Token: 0x06000753 RID: 1875 RVA: 0x00040594 File Offset: 0x0003E794
    public static void gmGmkSwWallOpenInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        if ( AppMain.GmGmkSwitchTypeIsGear( gms_GMK_SWWALL_WORK.id ) )
        {
            gms_GMK_SWWALL_WORK.wall_spd = 0;
        }
        else
        {
            gms_GMK_SWWALL_WORK.wall_spd = 16384;
        }
        obj_work.flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwWallOpenMain );
        obj_work.col_work.obj_col.obj = obj_work;
        if ( gms_GMK_SWWALL_WORK.h_snd != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_SWWALL_WORK.h_snd );
            AppMain.GmSoundPlaySE( "Boss3_01", gms_GMK_SWWALL_WORK.h_snd );
        }
    }

    // Token: 0x06000754 RID: 1876 RVA: 0x00040620 File Offset: 0x0003E820
    public static void gmGmkSwWallOpenMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        if ( ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 && AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) || ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) == 0 && !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) )
        {
            AppMain.gmGmkSwWallCloseInit( obj_work );
        }
        if ( gms_GMK_SWWALL_WORK.wall_spd != 0 )
        {
            gms_GMK_SWWALL_WORK.wall_draw_size -= gms_GMK_SWWALL_WORK.wall_spd;
        }
        else
        {
            int num = AppMain.GmGmkSwitchGetPer(gms_GMK_SWWALL_WORK.id);
            if ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                num = 4096 - num;
            }
            gms_GMK_SWWALL_WORK.wall_draw_size = AppMain.FX_Mul( gms_GMK_SWWALL_WORK.wall_size, num );
        }
        if ( gms_GMK_SWWALL_WORK.wall_draw_size <= 0 )
        {
            gms_GMK_SWWALL_WORK.wall_draw_size = 0;
            AppMain.gmGmkSwWallFwInit( obj_work );
        }
        gms_GMK_SWWALL_WORK.gear_dir = ( ushort )( gms_GMK_SWWALL_WORK.wall_draw_size / 64 * 16 );
        if ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.id == 257 || gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.id == 258 )
        {
            gms_GMK_SWWALL_WORK.gear_dir = ( ushort )-gms_GMK_SWWALL_WORK.gear_dir;
        }
        AppMain.gmGmkSwWallSetCol( gms_GMK_SWWALL_WORK.gmk_work.ene_com.col_work, gms_GMK_SWWALL_WORK.wall_size, gms_GMK_SWWALL_WORK.wall_draw_size, gms_GMK_SWWALL_WORK.wall_type );
    }

    // Token: 0x06000755 RID: 1877 RVA: 0x00040778 File Offset: 0x0003E978
    public static void gmGmkSwWallCloseInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        if ( AppMain.GmGmkSwitchTypeIsGear( gms_GMK_SWWALL_WORK.id ) )
        {
            gms_GMK_SWWALL_WORK.wall_spd = 0;
        }
        else
        {
            gms_GMK_SWWALL_WORK.wall_spd = 16384;
        }
        obj_work.flag |= 16U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSwWallCloseMain );
        obj_work.col_work.obj_col.obj = obj_work;
        if ( gms_GMK_SWWALL_WORK.h_snd != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_SWWALL_WORK.h_snd );
            AppMain.GmSoundPlaySE( "Boss3_01", gms_GMK_SWWALL_WORK.h_snd );
        }
    }

    // Token: 0x06000756 RID: 1878 RVA: 0x00040804 File Offset: 0x0003EA04
    public static void gmGmkSwWallCloseMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        if ( ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 && !AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) || ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) == 0 && AppMain.GmGmkSwitchIsOn( gms_GMK_SWWALL_WORK.id ) ) )
        {
            AppMain.gmGmkSwWallOpenInit( obj_work );
        }
        if ( gms_GMK_SWWALL_WORK.wall_spd != 0 )
        {
            gms_GMK_SWWALL_WORK.wall_draw_size += gms_GMK_SWWALL_WORK.wall_spd;
        }
        else
        {
            int num = AppMain.GmGmkSwitchGetPer(gms_GMK_SWWALL_WORK.id);
            if ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                num = 4096 - num;
            }
            gms_GMK_SWWALL_WORK.wall_draw_size = AppMain.FX_Mul( gms_GMK_SWWALL_WORK.wall_size, num );
        }
        if ( gms_GMK_SWWALL_WORK.wall_draw_size >= gms_GMK_SWWALL_WORK.wall_size )
        {
            gms_GMK_SWWALL_WORK.wall_draw_size = gms_GMK_SWWALL_WORK.wall_size;
            AppMain.gmGmkSwWallFwInit( obj_work );
        }
        gms_GMK_SWWALL_WORK.gear_dir = ( ushort )( gms_GMK_SWWALL_WORK.wall_draw_size / 64 * 16 );
        if ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.id == 257 || gms_GMK_SWWALL_WORK.gmk_work.ene_com.eve_rec.id == 258 )
        {
            gms_GMK_SWWALL_WORK.gear_dir = ( ushort )-gms_GMK_SWWALL_WORK.gear_dir;
        }
        AppMain.gmGmkSwWallSetCol( gms_GMK_SWWALL_WORK.gmk_work.ene_com.col_work, gms_GMK_SWWALL_WORK.wall_size, gms_GMK_SWWALL_WORK.wall_draw_size, gms_GMK_SWWALL_WORK.wall_type );
        AppMain.gmGmkSwWallCheckColOff( gms_GMK_SWWALL_WORK );
    }

    // Token: 0x06000757 RID: 1879 RVA: 0x0004096C File Offset: 0x0003EB6C
    public static void gmGmkSwWallDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SWWALL_WORK gms_GMK_SWWALL_WORK = (AppMain.GMS_GMK_SWWALL_WORK)obj_work;
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        AppMain.VecFx32 scale = default(AppMain.VecFx32);
        AppMain.VecU16 vecU = default(AppMain.VecU16);
        int i = (gms_GMK_SWWALL_WORK.wall_draw_size + 131071) / 131072;
        AppMain.OBS_COLLISION_WORK col_work = gms_GMK_SWWALL_WORK.gmk_work.ene_com.col_work;
        vecFx.Assign( obj_work.pos );
        int num2;
        int num = num2 = 0;
        if ( gms_GMK_SWWALL_WORK.wall_type <= 1 )
        {
            if ( gms_GMK_SWWALL_WORK.wall_type == 0 )
            {
                vecFx.x += ( int )( col_work.obj_col.width + ( ushort )col_work.obj_col.ofst_x - 16 ) << 12;
                num2 = -131072;
            }
            else
            {
                vecFx.x += ( int )( col_work.obj_col.ofst_x + 16 ) << 12;
                num2 = 131072;
            }
        }
        else if ( gms_GMK_SWWALL_WORK.wall_type == 2 )
        {
            vecFx.y += ( int )( col_work.obj_col.height + ( ushort )col_work.obj_col.ofst_y - 16 ) << 12;
            num = -131072;
        }
        else
        {
            vecFx.y += ( int )( col_work.obj_col.ofst_y + 16 ) << 12;
            num = 131072;
        }
        uint disp_flag = obj_work.disp_flag;
        if ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.enemy_flag & 2U ) != 0U )
        {
            while ( i > 0 )
            {
                AppMain.ObjDrawAction3DNN( obj_work.obj_3d, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref disp_flag );
                i--;
                vecFx.x += num2;
                vecFx.y += num;
            }
        }
        else
        {
            while ( i > 0 )
            {
                AppMain.ObjDrawAction3DNN( obj_work.obj_3d, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref disp_flag );
                i--;
                vecFx.x += num2;
                vecFx.y += num;
            }
        }
        if ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.enemy_flag & 1U ) != 0U )
        {
            vecU.x = ( vecU.y = 0 );
            vecU.z = ( ushort )( gms_GMK_SWWALL_WORK.gear_dir + gms_GMK_SWWALL_WORK.gear_base_dir );
            AppMain.ObjDrawAction3DNN( gms_GMK_SWWALL_WORK.obj_3d_opt[0], new AppMain.VecFx32?( gms_GMK_SWWALL_WORK.gear_pos ), new AppMain.VecU16?( vecU ), obj_work.scale, ref disp_flag );
            scale.x = ( scale.y = ( scale.z = 4096 ) );
            if ( ( gms_GMK_SWWALL_WORK.gmk_work.ene_com.enemy_flag & 4U ) != 0U )
            {
                scale.x = -scale.x;
            }
            AppMain.ObjDrawAction3DNN( gms_GMK_SWWALL_WORK.obj_3d_opt[1], new AppMain.VecFx32?( gms_GMK_SWWALL_WORK.gearbase_pos ), new AppMain.VecU16?( obj_work.dir ), scale, ref disp_flag );
        }
    }

    // Token: 0x06000758 RID: 1880 RVA: 0x00040C34 File Offset: 0x0003EE34
    public static void gmGmkSwWallSetCol( AppMain.OBS_COLLISION_WORK col_work, int size, int draw_size, ushort wall_type )
    {
        if ( wall_type <= 1 )
        {
            col_work.obj_col.width = ( ushort )( ( long )( ( draw_size >> 12 ) + 7 ) & unchecked(( long )( ( ulong )-8 )) );
            if ( wall_type == 0 )
            {
                col_work.obj_col.ofst_x = ( short )( ( -size >> 13 ) - ( ( int )col_work.obj_col.width - ( draw_size >> 12 ) ) );
            }
            else
            {
                col_work.obj_col.ofst_x = ( short )( ( size >> 1 ) - draw_size >> 12 );
            }
            AppMain.gmGmkSwWallSetColDir( col_work.obj_col.dir_data, col_work.obj_col.width + 7 >> 3, col_work.obj_col.height + 7 >> 3, false );
            return;
        }
        col_work.obj_col.height = ( ushort )( ( long )( ( draw_size >> 12 ) + 7 ) & unchecked(( long )( ( ulong )-8 )) );
        if ( wall_type == 2 )
        {
            col_work.obj_col.ofst_y = ( short )( ( -size >> 13 ) - ( ( int )col_work.obj_col.height - ( draw_size >> 12 ) ) );
        }
        else
        {
            col_work.obj_col.ofst_y = ( short )( ( size >> 1 ) - draw_size >> 12 );
        }
        AppMain.gmGmkSwWallSetColDir( col_work.obj_col.dir_data, col_work.obj_col.width + 7 >> 3, col_work.obj_col.height + 7 >> 3, true );
    }

    // Token: 0x06000759 RID: 1881 RVA: 0x00040D4C File Offset: 0x0003EF4C
    public static void gmGmkSwWallSetColDir( byte[] buf, int width, int height, bool wall )
    {
        if ( AppMain.g_gs_main_sys_info.stage_id != 9 )
        {
            return;
        }
        if ( width <= 0 || height <= 0 )
        {
            return;
        }
        int num = width >> 1;
        int num2 = height >> 1;
        if ( wall )
        {
            AppMain.ArrayPointer<byte> arrayPointer = buf;
            int i = 0;
            while ( i < height )
            {
                AppMain.ArrayPointer<byte> pointer = arrayPointer;
                int j = 0;
                while ( j < num )
                {
                    pointer.SetPrimitive( 192 );
                    j++;
                    pointer = ++pointer;
                }
                while ( j < width )
                {
                    pointer.SetPrimitive( 64 );
                    j++;
                    pointer = ++pointer;
                }
                i++;
                arrayPointer += width;
            }
            arrayPointer = new AppMain.ArrayPointer<byte>( buf, 1 );
            i = 1;
            while ( i < width - 1 )
            {
                arrayPointer.SetPrimitive( 0 );
                i++;
                arrayPointer = ++arrayPointer;
            }
            if ( height > 1 )
            {
                arrayPointer = new AppMain.ArrayPointer<byte>( buf, ( height - 1 ) * width + 1 );
                i = 1;
                while ( i < width - 1 )
                {
                    arrayPointer.SetPrimitive( 128 );
                    i++;
                    arrayPointer = ++arrayPointer;
                }
                return;
            }
        }
        else
        {
            AppMain.ArrayPointer<byte> arrayPointer = buf;
            int i;
            for ( i = 0; i < num2; i++ )
            {
                int j = 0;
                while ( j < width )
                {
                    arrayPointer.SetPrimitive( 0 );
                    j++;
                    arrayPointer = ++arrayPointer;
                }
            }
            while ( i < height )
            {
                int j = 0;
                while ( j < width )
                {
                    arrayPointer.SetPrimitive( 128 );
                    j++;
                    arrayPointer = ++arrayPointer;
                }
                i++;
            }
            arrayPointer = new AppMain.ArrayPointer<byte>( buf, width );
            i = 1;
            while ( i < height - 1 )
            {
                arrayPointer.SetPrimitive( 192 );
                i++;
                arrayPointer += width;
            }
            if ( width > 1 )
            {
                arrayPointer = new AppMain.ArrayPointer<byte>( buf, width + ( width - 1 ) );
                i = 1;
                while ( i < height - 1 )
                {
                    arrayPointer.SetPrimitive( 64 );
                    i++;
                    arrayPointer += width;
                }
            }
        }
    }

    // Token: 0x0600075A RID: 1882 RVA: 0x00040F04 File Offset: 0x0003F104
    public static void gmGmkSwWallCheckColOff( AppMain.GMS_GMK_SWWALL_WORK swwall_work )
    {
        if ( AppMain.g_gs_main_sys_info.stage_id != 9 )
        {
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)swwall_work;
        AppMain.GMS_EVE_RECORD_EVENT eve_rec = swwall_work.gmk_work.ene_com.eve_rec;
        if ( eve_rec.id == 248 || eve_rec.id == 249 || eve_rec.id == 252 || eve_rec.id == 253 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
            int num = obs_OBJECT_WORK2.pos.x >> 12;
            int num2 = obs_OBJECT_WORK2.pos.y >> 12;
            int num3 = obs_OBJECT_WORK.pos.x >> 12;
            int num4 = obs_OBJECT_WORK.pos.y >> 12;
            int num5 = swwall_work.wall_size >> 12;
            if ( num3 - ( num5 >> 1 ) < num + ( int )obs_OBJECT_WORK2.field_rect[2] && num3 + ( num5 >> 1 ) > num + ( int )obs_OBJECT_WORK2.field_rect[0] && num4 + ( int )obs_OBJECT_WORK.col_work.obj_col.ofst_y + 8 <= num2 + ( int )obs_OBJECT_WORK2.field_rect[3] && num4 + ( int )obs_OBJECT_WORK.col_work.obj_col.ofst_y + ( int )obs_OBJECT_WORK.col_work.obj_col.height > num2 + ( int )obs_OBJECT_WORK2.field_rect[1] )
            {
                obs_OBJECT_WORK.col_work.obj_col.obj = null;
                return;
            }
            obs_OBJECT_WORK.col_work.obj_col.obj = obs_OBJECT_WORK;
        }
    }
}