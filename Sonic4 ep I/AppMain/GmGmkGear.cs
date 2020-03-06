using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200014A RID: 330
    public class GMS_GMK_GEAR_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060020B7 RID: 8375 RVA: 0x0013F9A1 File Offset: 0x0013DBA1
        public GMS_GMK_GEAR_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060020B8 RID: 8376 RVA: 0x0013F9CB File Offset: 0x0013DBCB
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x060020B9 RID: 8377 RVA: 0x0013F9DD File Offset: 0x0013DBDD
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_GEAR_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04004D67 RID: 19815
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004D68 RID: 19816
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_gear_opt = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004D69 RID: 19817
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_gear_opt_ashiba = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004D6A RID: 19818
        public uint col_type;

        // Token: 0x04004D6B RID: 19819
        public float dir_speed;

        // Token: 0x04004D6C RID: 19820
        public float dir_temp;

        // Token: 0x04004D6D RID: 19821
        public ushort prev_dir;

        // Token: 0x04004D6E RID: 19822
        public ushort move_draw_dir;

        // Token: 0x04004D6F RID: 19823
        public ushort old_move_draw_dir;

        // Token: 0x04004D70 RID: 19824
        public short move_draw_dir_spd;

        // Token: 0x04004D71 RID: 19825
        public short move_draw_dir_ofst;

        // Token: 0x04004D72 RID: 19826
        public short move_draw_dir_limit;

        // Token: 0x04004D73 RID: 19827
        public ushort move_stagger_dir_cnt;

        // Token: 0x04004D74 RID: 19828
        public ushort move_stagger_step;

        // Token: 0x04004D75 RID: 19829
        public int move_stagger_dir_spd;

        // Token: 0x04004D76 RID: 19830
        public int stop_timer;

        // Token: 0x04004D77 RID: 19831
        public int rect_ret_timer;

        // Token: 0x04004D78 RID: 19832
        public int move_end_x;

        // Token: 0x04004D79 RID: 19833
        public int move_end_y;

        // Token: 0x04004D7A RID: 19834
        public int ret_max_speed;

        // Token: 0x04004D7B RID: 19835
        public bool vib_end;

        // Token: 0x04004D7C RID: 19836
        public int open_rot_dist;

        // Token: 0x04004D7D RID: 19837
        public ushort gear_sw_dir_base;

        // Token: 0x04004D7E RID: 19838
        public int close_rot_spd;

        // Token: 0x04004D7F RID: 19839
        public AppMain.OBS_OBJECT_WORK gear_end_obj;

        // Token: 0x04004D80 RID: 19840
        public AppMain.OBS_OBJECT_WORK move_gear_obj;

        // Token: 0x04004D81 RID: 19841
        public AppMain.OBS_OBJECT_WORK sw_gear_obj;

        // Token: 0x04004D82 RID: 19842
        public AppMain.GSS_SND_SE_HANDLE h_snd_gear;
    }

    // Token: 0x0600057B RID: 1403 RVA: 0x0002F564 File Offset: 0x0002D764
    private static AppMain.OBS_OBJECT_WORK GmGmkGearInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        if ( eve_rec.id == 184 )
        {
            obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK( eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_GEAR_WORK(), "GMK_GEAR_SW" );
        }
        else
        {
            obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_RIDE_WORK( eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_GEAR_WORK(), "GMK_GEAR" );
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obs_OBJECT_WORK;
        if ( eve_rec.id == 182 && eve_rec.byte_param[1] != 0 )
        {
            obs_OBJECT_WORK.disp_flag |= 32U;
            obs_OBJECT_WORK.move_flag |= 8448U;
            obs_OBJECT_WORK.flag |= 2U;
            return obs_OBJECT_WORK;
        }
        obs_OBJECT_WORK.ppIn = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearInFunc );
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkGearDest ) );
        gms_GMK_GEAR_WORK.h_snd_gear = AppMain.GsSoundAllocSeHandle();
        AppMain.GmSoundStopSE( gms_GMK_GEAR_WORK.h_snd_gear );
        AppMain.GmSoundPlaySE( "Gear", gms_GMK_GEAR_WORK.h_snd_gear );
        if ( eve_rec.id == 181 )
        {
            float num = 0.2f;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_gear_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            obs_OBJECT_WORK.pos.z = -131072;
            obs_OBJECT_WORK.ppLast = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearLastFunc );
            num += 0.2f * ( float )AppMain.MTM_MATH_CLIP( ( int )eve_rec.left, 0, 3 );
            gms_GMK_GEAR_WORK.h_snd_gear.au_player.SetAisac( "Speed", num );
        }
        else if ( eve_rec.id == 182 )
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_gear_move_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            obs_OBJECT_WORK.pos.z = -131072;
            AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_gear_opt_obj_3d_list[0], gms_GMK_GEAR_WORK.obj_3d_gear_opt );
            AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_gear_opt_obj_3d_list[1], gms_GMK_GEAR_WORK.obj_3d_gear_opt_ashiba );
            obs_OBJECT_WORK.ppLast = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearMoveLastFunc );
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_gear_sw_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            obs_OBJECT_WORK.pos.z = -131072;
            AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_gear_opt_obj_3d_list[0], gms_GMK_GEAR_WORK.obj_3d_gear_opt );
            AppMain.ObjCopyAction3dNNModel( AppMain.gm_gmk_gear_opt_obj_3d_list[1], gms_GMK_GEAR_WORK.obj_3d_gear_opt_ashiba );
            obs_OBJECT_WORK.ppLast = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearMoveLastFunc );
        }
        AppMain.OBS_COLLISION_WORK col_work = gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work;
        col_work.obj_col.obj = ( AppMain.OBS_OBJECT_WORK )gms_GMK_GEAR_WORK;
        col_work.obj_col.width = 176;
        col_work.obj_col.height = 176;
        col_work.obj_col.ofst_x = -88;
        col_work.obj_col.ofst_y = -88;
        col_work.obj_col.flag |= 402653216U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        gms_ENEMY_3D_WORK.obj_3d.use_light_flag &= 4294967294U;
        gms_ENEMY_3D_WORK.obj_3d.use_light_flag |= 2U;
        gms_GMK_GEAR_WORK.obj_3d_gear_opt_ashiba.use_light_flag &= 4294967294U;
        gms_GMK_GEAR_WORK.obj_3d_gear_opt_ashiba.use_light_flag |= 2U;
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            gms_GMK_GEAR_WORK.obj_3d_gear_opt.use_light_flag &= 4294967294U;
            gms_GMK_GEAR_WORK.obj_3d_gear_opt.use_light_flag |= 2U;
        }
        if ( eve_rec.id == 181 )
        {
            obs_OBJECT_WORK.move_flag |= 8192U;
            obs_OBJECT_WORK.move_flag |= 256U;
            gms_GMK_GEAR_WORK.dir_speed = 32f + ( float )AppMain.MTM_MATH_CLIP( ( int )eve_rec.left, 0, 3 ) * 32f;
            if ( ( eve_rec.flag & 1 ) != 0 )
            {
                gms_GMK_GEAR_WORK.dir_speed = -gms_GMK_GEAR_WORK.dir_speed;
            }
            int num2 = (int)(65536f / AppMain.MTM_MATH_ABS(gms_GMK_GEAR_WORK.dir_speed));
            gms_GMK_GEAR_WORK.dir_temp = ( float )( ( ulong )AppMain.g_gm_main_system.sync_time % ( ulong )( ( long )num2 ) ) * gms_GMK_GEAR_WORK.dir_speed;
            gms_GMK_GEAR_WORK.dir_temp += ( float )( AppMain.MTM_MATH_CLIP( ( int )eve_rec.top, 0, 3 ) * 2048 );
            float num3 = gms_GMK_GEAR_WORK.dir_temp / 65536f;
            if ( AppMain.MTM_MATH_ABS( num3 ) >= 1f )
            {
                gms_GMK_GEAR_WORK.dir_temp -= num3 * 65536f;
            }
            if ( gms_GMK_GEAR_WORK.dir_speed > 0f )
            {
                obs_OBJECT_WORK.dir.z = ( ushort )( ( uint )AppMain.nnRoundOff( gms_GMK_GEAR_WORK.dir_temp ) / 1024U * 1024U );
            }
            else
            {
                obs_OBJECT_WORK.dir.z = ( ushort )( ( uint )( AppMain.nnRoundOff( gms_GMK_GEAR_WORK.dir_temp ) + 1023f ) / 1024U * 1024U );
            }
            gms_GMK_GEAR_WORK.prev_dir = obs_OBJECT_WORK.dir.z;
            AppMain.gmGmkGearChangeCol( gms_GMK_GEAR_WORK );
            AppMain.gmGmkGearFwInit( obs_OBJECT_WORK );
        }
        else if ( eve_rec.id == 182 )
        {
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearMoveSwDraw );
            byte[] array;
            if ( AppMain.gm_gmk_gear_add_data[16] is AppMain.AmbChunk )
            {
                AppMain.AmbChunk ambChunk = (AppMain.AmbChunk)AppMain.gm_gmk_gear_add_data[16];
                array = new byte[ambChunk.length];
                Buffer.BlockCopy( ambChunk.array, ambChunk.offset, array, 0, ambChunk.length );
                AppMain.gm_gmk_gear_add_data[16] = array;
            }
            else
            {
                array = ( byte[] )AppMain.gm_gmk_gear_add_data[16];
            }
            col_work.obj_col.diff_data = array;
            byte[] array2;
            if ( AppMain.gm_gmk_gear_add_data[17] is AppMain.AmbChunk )
            {
                AppMain.AmbChunk ambChunk2 = (AppMain.AmbChunk)AppMain.gm_gmk_gear_add_data[17];
                array2 = new byte[ambChunk2.length];
                Buffer.BlockCopy( ambChunk2.array, ambChunk2.offset, array2, 0, ambChunk2.length );
                AppMain.gm_gmk_gear_add_data[17] = array2;
            }
            else
            {
                array2 = ( byte[] )AppMain.gm_gmk_gear_add_data[17];
            }
            col_work.obj_col.dir_data = array2;
            obs_OBJECT_WORK.flag &= 4294967294U;
            obs_OBJECT_WORK.disp_flag |= 16777472U;
            obs_OBJECT_WORK.move_flag &= 4294967039U;
            obs_OBJECT_WORK.move_flag |= 704U;
            if ( ( eve_rec.flag & 8 ) != 0 )
            {
                obs_OBJECT_WORK.user_flag |= 4U;
            }
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
            obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkMoveGearBodyDefFunc );
            obs_RECT_WORK.ppHit = null;
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -16, -72, 16, -48 );
            obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
            obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkMoveGearDefFunc );
            obs_RECT_WORK.ppHit = null;
            AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
            AppMain.ObjRectDefSet( obs_RECT_WORK, 65527, 0 );
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -80, -80, 80, 80 );
            obs_RECT_WORK.flag |= 32U;
            AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -8, -8, 8, 8 );
            if ( type == 0 )
            {
                obs_OBJECT_WORK.move_flag |= 1U;
                obs_OBJECT_WORK.prev_pos.Assign( obs_OBJECT_WORK.pos );
                if ( ( eve_rec.flag & 1 ) != 0 )
                {
                    obs_OBJECT_WORK.dir.z = 16384;
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + 32768;
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK3.prev_pos.x = obs_OBJECT_WORK3.prev_pos.x - 32768;
                    obs_OBJECT_WORK.move.x = 65536;
                    obs_OBJECT_WORK.spd.x = 65536;
                    obs_OBJECT_WORK.move_flag &= 4294967167U;
                    obs_OBJECT_WORK.user_flag |= 8U;
                }
                else
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK4.pos.y = obs_OBJECT_WORK4.pos.y + 32768;
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK5 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK5.prev_pos.y = obs_OBJECT_WORK5.prev_pos.y - 32768;
                    obs_OBJECT_WORK.move.y = 65536;
                    obs_OBJECT_WORK.spd.y = 65536;
                    obs_OBJECT_WORK.user_flag &= 4294967287U;
                }
                AppMain.g_obj.ppCollision( obs_OBJECT_WORK );
                obs_OBJECT_WORK.move_flag |= 1U;
                vecFx.Assign( obs_OBJECT_WORK.pos );
                obs_OBJECT_WORK.prev_pos.Assign( obs_OBJECT_WORK.pos );
                obs_OBJECT_WORK.move.x = ( obs_OBJECT_WORK.move.y = 0 );
                obs_OBJECT_WORK.spd.x = ( obs_OBJECT_WORK.spd.y = 0 );
                if ( ( eve_rec.flag & 1 ) != 0 )
                {
                    if ( ( eve_rec.flag & 2 ) != 0 )
                    {
                        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK6 = obs_OBJECT_WORK;
                        obs_OBJECT_WORK6.prev_pos.y = obs_OBJECT_WORK6.prev_pos.y - 32768;
                        obs_OBJECT_WORK.move.y = 32768;
                        obs_OBJECT_WORK.spd.y = 32768;
                        obs_OBJECT_WORK.disp_flag |= 1U;
                    }
                    else
                    {
                        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK7 = obs_OBJECT_WORK;
                        obs_OBJECT_WORK7.prev_pos.y = obs_OBJECT_WORK7.prev_pos.y + 32768;
                        obs_OBJECT_WORK.move.y = -32768;
                        obs_OBJECT_WORK.spd.y = -32768;
                    }
                }
                else if ( ( eve_rec.flag & 2 ) != 0 )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK8 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK8.prev_pos.x = obs_OBJECT_WORK8.prev_pos.x - 32768;
                    obs_OBJECT_WORK.move.x = 32768;
                    obs_OBJECT_WORK.spd.x = 32768;
                    obs_OBJECT_WORK.disp_flag |= 1U;
                }
                else
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK9 = obs_OBJECT_WORK;
                    obs_OBJECT_WORK9.prev_pos.x = obs_OBJECT_WORK9.prev_pos.x + 32768;
                    obs_OBJECT_WORK.move.x = -32768;
                    obs_OBJECT_WORK.spd.x = -32768;
                }
                AppMain.g_obj.ppCollision( obs_OBJECT_WORK );
                if ( ( obs_OBJECT_WORK.move_flag & 8U ) != 0U )
                {
                    if ( ( eve_rec.flag & 1 ) != 0 )
                    {
                        obs_OBJECT_WORK.prev_pos.y = vecFx.y;
                    }
                    else
                    {
                        obs_OBJECT_WORK.prev_pos.x = vecFx.x;
                    }
                }
                else
                {
                    obs_OBJECT_WORK.pos.Assign( vecFx );
                }
                if ( ( eve_rec.flag & 2 ) != 0 )
                {
                    gms_GMK_GEAR_WORK.move_end_x = ( gms_GMK_GEAR_WORK.move_end_y = 0 );
                }
                else
                {
                    gms_GMK_GEAR_WORK.move_end_x = ( gms_GMK_GEAR_WORK.move_end_y = int.MaxValue );
                }
                obs_OBJECT_WORK.prev_pos.Assign( obs_OBJECT_WORK.pos );
                obs_OBJECT_WORK.move.x = ( obs_OBJECT_WORK.move.y = 0 );
                obs_OBJECT_WORK.spd.x = ( obs_OBJECT_WORK.spd.y = 0 );
                obs_OBJECT_WORK.disp_flag &= 4294967294U;
                obs_OBJECT_WORK.move_flag |= 1U;
                AppMain.gmGmkMoveGearFwInit( obs_OBJECT_WORK );
            }
            else
            {
                AppMain.nnMakeRotateZMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, 2730 );
                AppMain.gmGmkMoveGearEndInit( obs_OBJECT_WORK );
            }
        }
        else
        {
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearMoveSwDraw );
            byte[] array3;
            if ( AppMain.gm_gmk_gear_add_data[16] is AppMain.AmbChunk )
            {
                AppMain.AmbChunk ambChunk3 = (AppMain.AmbChunk)AppMain.gm_gmk_gear_add_data[16];
                array3 = new byte[ambChunk3.length];
                Buffer.BlockCopy( ambChunk3.array, ambChunk3.offset, array3, 0, ambChunk3.length );
                AppMain.gm_gmk_gear_add_data[16] = array3;
            }
            else
            {
                array3 = ( byte[] )AppMain.gm_gmk_gear_add_data[16];
            }
            col_work.obj_col.diff_data = array3;
            byte[] array4;
            if ( AppMain.gm_gmk_gear_add_data[17] is AppMain.AmbChunk )
            {
                AppMain.AmbChunk ambChunk4 = (AppMain.AmbChunk)AppMain.gm_gmk_gear_add_data[17];
                array4 = new byte[ambChunk4.length];
                Buffer.BlockCopy( ambChunk4.array, ambChunk4.offset, array4, 0, ambChunk4.length );
                AppMain.gm_gmk_gear_add_data[17] = array4;
            }
            else
            {
                array4 = ( byte[] )AppMain.gm_gmk_gear_add_data[17];
            }
            col_work.obj_col.dir_data = array4;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[1];
            AppMain.ObjRectGroupSet( obs_RECT_WORK, 0, 2 );
            obs_RECT_WORK.ppDef = null;
            obs_RECT_WORK.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkGearSwitchAtkHitFunc );
            AppMain.ObjRectAtkSet( obs_RECT_WORK, 8, 1 );
            AppMain.ObjRectDefSet( obs_RECT_WORK, ushort.MaxValue, 0 );
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -92, -92, 92, 92 );
            obs_RECT_WORK.flag |= 1024U;
            obs_OBJECT_WORK.disp_flag |= 16777472U;
            obs_OBJECT_WORK.move_flag |= 8448U;
            gms_GMK_GEAR_WORK.open_rot_dist = 65536;
            if ( eve_rec.height > 0 )
            {
                gms_GMK_GEAR_WORK.close_rot_spd = 65536 / ( int )( eve_rec.height * 30 );
            }
            AppMain.gmGmkGearSwFwInit( obs_OBJECT_WORK );
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600057C RID: 1404 RVA: 0x000301E4 File Offset: 0x0002E3E4
    private static AppMain.OBS_OBJECT_WORK GmGmkGearMoveEndInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_RIDE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_GEAR_WORK(), "GMK_GEAR_END");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        if ( eve_rec.byte_param[1] != 0 )
        {
            AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GmEventMgrLocalEventBirth(182, pos_x, pos_y, 0, 0, 0, 0, 0, 1);
            obs_OBJECT_WORK.parent_obj = parent_obj;
            obs_OBJECT_WORK.flag |= 18U;
        }
        else
        {
            obs_OBJECT_WORK.ppIn = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearInFunc );
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[1];
            AppMain.ObjRectGroupSet( obs_RECT_WORK, 0, 2 );
            obs_RECT_WORK.ppDef = null;
            obs_RECT_WORK.ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkMoveGearEndAtkHitFunc );
            AppMain.ObjRectAtkSet( obs_RECT_WORK, 8, 1 );
            AppMain.ObjRectDefSet( obs_RECT_WORK, ushort.MaxValue, 0 );
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -32, -32, 32, 32 );
            obs_RECT_WORK.flag |= 1024U;
            AppMain.gmGmkMoveGearEndSwitchFwInit( obs_OBJECT_WORK );
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600057D RID: 1405 RVA: 0x000302F4 File Offset: 0x0002E4F4
    public static void GmGmkGearSetLight()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = -0.35f;
        nns_VECTOR.y = 2.25f;
        nns_VECTOR.z = -0.9f;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        float intensity;
        if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            intensity = 0.9f;
        }
        else
        {
            intensity = 1f;
        }
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_1, ref nns_RGBA, intensity, nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x0600057E RID: 1406 RVA: 0x00030380 File Offset: 0x0002E580
    public static void GmGmkGearBuild()
    {
        AppMain.AMS_AMB_HEADER header = AppMain.GmGameDatGetGimmickData(887);
        for ( int i = 0; i < 19; i++ )
        {
            AppMain.gm_gmk_gear_add_data[i] = ( AppMain.AmbChunk )AppMain.amBindGet( header, i );
        }
        AppMain.gm_gmk_gear_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 888 ), AppMain.GmGameDatGetGimmickData( 889 ), 0U );
        AppMain.gm_gmk_gear_move_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 890 ), AppMain.GmGameDatGetGimmickData( 889 ), 0U );
        AppMain.gm_gmk_gear_sw_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 890 ), AppMain.GmGameDatGetGimmickData( 889 ), 0U, AppMain.readTXBfile( AppMain.gm_gmk_gear_add_data[18] ) );
        AppMain.gm_gmk_gear_opt_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 891 ), AppMain.GmGameDatGetGimmickData( 889 ), 0U );
    }

    // Token: 0x0600057F RID: 1407 RVA: 0x00030444 File Offset: 0x0002E644
    public static void GmGmkGearFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(888);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_gear_obj_3d_list, ams_AMB_HEADER.file_num );
        ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData( 890 );
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_gear_move_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_gear_sw_obj_3d_list, ams_AMB_HEADER.file_num );
        ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData( 891 );
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_gear_opt_obj_3d_list, ams_AMB_HEADER.file_num );
        for ( int i = 0; i < AppMain.gm_gmk_gear_add_data.Length; i++ )
        {
            AppMain.gm_gmk_gear_add_data[i] = null;
        }
    }

    // Token: 0x06000580 RID: 1408 RVA: 0x000304CC File Offset: 0x0002E6CC
    private static void gmGmkGearInFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.GmEnemyDefaultInFunc( obj_work );
        if ( gms_GMK_GEAR_WORK.gear_end_obj != null && ( gms_GMK_GEAR_WORK.gear_end_obj.flag & 12U ) != 0U )
        {
            gms_GMK_GEAR_WORK.gear_end_obj = null;
        }
        if ( gms_GMK_GEAR_WORK.move_gear_obj != null && ( gms_GMK_GEAR_WORK.move_gear_obj.flag & 12U ) != 0U )
        {
            gms_GMK_GEAR_WORK.move_gear_obj = null;
        }
        if ( gms_GMK_GEAR_WORK.sw_gear_obj != null && ( gms_GMK_GEAR_WORK.sw_gear_obj.flag & 12U ) != 0U )
        {
            gms_GMK_GEAR_WORK.sw_gear_obj = null;
        }
    }

    // Token: 0x06000581 RID: 1409 RVA: 0x00030544 File Offset: 0x0002E744
    private static void gmGmkGearDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_GMK_GEAR_WORK.h_snd_gear != null )
        {
            AppMain.GmSoundStopSE( gms_GMK_GEAR_WORK.h_snd_gear );
            AppMain.GsSoundFreeSeHandle( gms_GMK_GEAR_WORK.h_snd_gear );
            gms_GMK_GEAR_WORK.h_snd_gear = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000582 RID: 1410 RVA: 0x00030588 File Offset: 0x0002E788
    private static void gmGmkGearFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearFwMain );
    }

    // Token: 0x06000583 RID: 1411 RVA: 0x0003059C File Offset: 0x0002E79C
    private static void gmGmkGearFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        gms_GMK_GEAR_WORK.dir_temp += gms_GMK_GEAR_WORK.dir_speed;
        if ( gms_GMK_GEAR_WORK.dir_temp < -65536f )
        {
            gms_GMK_GEAR_WORK.dir_temp += 65536f;
        }
        else if ( gms_GMK_GEAR_WORK.dir_temp > 65536f )
        {
            gms_GMK_GEAR_WORK.dir_temp -= 65536f;
        }
        gms_GMK_GEAR_WORK.prev_dir = obj_work.dir.z;
        if ( gms_GMK_GEAR_WORK.dir_speed > 0f )
        {
            obj_work.dir.z = ( ushort )( ( int )AppMain.nnRoundOff( gms_GMK_GEAR_WORK.dir_temp ) / 1024 * 1024 );
        }
        else
        {
            obj_work.dir.z = ( ushort )( ( ( int )AppMain.nnRoundOff( gms_GMK_GEAR_WORK.dir_temp ) + 1023 ) / 1024 * 1024 );
        }
        gms_GMK_GEAR_WORK.col_type = ( uint )( obj_work.dir.z / 1024 % 8 );
        AppMain.gmGmkGearChangeCol( gms_GMK_GEAR_WORK );
        if ( gms_GMK_GEAR_WORK.prev_dir != obj_work.dir.z && obj_work.col_work.obj_col.rider_obj != null && obj_work.col_work.obj_col.rider_obj.obj_type == 1 )
        {
            AppMain.OBS_OBJECT_WORK rider_obj = obj_work.col_work.obj_col.rider_obj;
            float num = AppMain.FXM_FX32_TO_FLOAT(rider_obj.pos.x - obj_work.pos.x);
            float num2 = -AppMain.FXM_FX32_TO_FLOAT(rider_obj.pos.y - obj_work.pos.y);
            int ang = (int)(obj_work.dir.z - gms_GMK_GEAR_WORK.prev_dir);
            float num3 = AppMain.nnCos(ang) * num + AppMain.nnSin(ang) * num2;
            float num4 = -AppMain.nnSin(ang) * num + AppMain.nnCos(ang) * num2;
            rider_obj.prev_pos.x = rider_obj.pos.x;
            rider_obj.prev_pos.y = rider_obj.pos.y;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = rider_obj;
            obs_OBJECT_WORK.pos.x = obs_OBJECT_WORK.pos.x + AppMain.FXM_FLOAT_TO_FX32( num3 - num );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = rider_obj;
            obs_OBJECT_WORK2.pos.y = obs_OBJECT_WORK2.pos.y + -AppMain.FXM_FLOAT_TO_FX32( num4 - num2 );
            rider_obj.move.x = rider_obj.pos.x - rider_obj.prev_pos.x;
            rider_obj.move.y = rider_obj.pos.y - rider_obj.prev_pos.y;
        }
    }

    // Token: 0x06000584 RID: 1412 RVA: 0x00030808 File Offset: 0x0002EA08
    private static void gmGmkGearChangeCol( AppMain.GMS_GMK_GEAR_WORK gear_work )
    {
        byte[] array;
        if ( AppMain.gm_gmk_gear_add_data[( int )( ( UIntPtr )( gear_work.col_type * 2U ) )] is AppMain.AmbChunk )
        {
            AppMain.AmbChunk ambChunk = (AppMain.AmbChunk)AppMain.gm_gmk_gear_add_data[(int)((UIntPtr)(gear_work.col_type * 2U))];
            array = new byte[ambChunk.length];
            Buffer.BlockCopy( ambChunk.array, ambChunk.offset, array, 0, ambChunk.length );
            AppMain.gm_gmk_gear_add_data[( int )( ( UIntPtr )( gear_work.col_type * 2U ) )] = array;
        }
        else
        {
            array = ( byte[] )AppMain.gm_gmk_gear_add_data[( int )( ( UIntPtr )( gear_work.col_type * 2U ) )];
        }
        gear_work.gmk_work.ene_com.col_work.obj_col.diff_data = array;
    }

    // Token: 0x06000585 RID: 1413 RVA: 0x000308A8 File Offset: 0x0002EAA8
    private static void gmGmkMoveGearFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.rect_ret_timer == 0 )
        {
            gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294965247U;
            gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294965247U;
        }
        obj_work.flag &= 4294967279U;
        obj_work.spd_m = 0;
        obj_work.spd.x = ( obj_work.spd.y = 0 );
        obj_work.spd_add.x = ( obj_work.spd_add.y = 0 );
        gms_GMK_GEAR_WORK.vib_end = false;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearFwMain );
    }

    // Token: 0x06000586 RID: 1414 RVA: 0x00030970 File Offset: 0x0002EB70
    private static void gmGmkMoveGearFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.rect_ret_timer != 0 )
        {
            gms_GMK_GEAR_WORK.rect_ret_timer = AppMain.ObjTimeCountDown( gms_GMK_GEAR_WORK.rect_ret_timer );
            if ( gms_GMK_GEAR_WORK.rect_ret_timer == 0 )
            {
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294965247U;
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294965247U;
            }
        }
    }

    // Token: 0x06000587 RID: 1415 RVA: 0x000309EC File Offset: 0x0002EBEC
    private static void gmGmkMoveGearMoveInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        obj_work.user_flag &= 4294967294U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag |= 2048U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294965247U;
        obj_work.flag |= 16U;
        obj_work.move_flag &= 4294959103U;
        gms_GMK_GEAR_WORK.stop_timer = 737280;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearMoveMain );
    }

    // Token: 0x06000588 RID: 1416 RVA: 0x00030A94 File Offset: 0x0002EC94
    private static void gmGmkMoveGearMoveMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj;
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.gmk_obj != obj_work )
        {
            gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj = null;
            AppMain.gmGmkMoveGearRetWaitInit( obj_work );
            return;
        }
        AppMain.gmGmkMoveGearSetSpd( obj_work, -gms_PLAYER_WORK.obj_work.spd_m );
        if ( obj_work.spd_m != 0 && !gms_GMK_GEAR_WORK.vib_end )
        {
            AppMain.GMM_PAD_VIB_SMALL_TIME( 60f );
            gms_GMK_GEAR_WORK.vib_end = true;
        }
        if ( gms_PLAYER_WORK.obj_work.spd_m == 0 )
        {
            gms_GMK_GEAR_WORK.stop_timer = AppMain.ObjTimeCountDown( gms_GMK_GEAR_WORK.stop_timer );
        }
        else
        {
            gms_GMK_GEAR_WORK.stop_timer = 737280;
        }
        if ( gms_GMK_GEAR_WORK.stop_timer == 0 )
        {
            gms_GMK_GEAR_WORK.gmk_work.ene_com.enemy_flag |= 1U;
            gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj = null;
            AppMain.gmGmkMoveGearRetInit( obj_work );
        }
    }

    // Token: 0x06000589 RID: 1417 RVA: 0x00030B78 File Offset: 0x0002ED78
    private static void gmGmkMoveGearRetWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        gms_GMK_GEAR_WORK.rect_ret_timer = 65536;
        obj_work.flag &= 4294967293U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearRetWaitMain );
    }

    // Token: 0x0600058A RID: 1418 RVA: 0x00030BB8 File Offset: 0x0002EDB8
    private static void gmGmkMoveGearRetWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.rect_ret_timer != 0 )
        {
            gms_GMK_GEAR_WORK.rect_ret_timer = AppMain.ObjTimeCountDown( gms_GMK_GEAR_WORK.rect_ret_timer );
            if ( gms_GMK_GEAR_WORK.rect_ret_timer == 0 )
            {
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294965247U;
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294965247U;
            }
        }
        AppMain.gmGmkMoveGearSetSpd( obj_work, AppMain.ObjSpdDownSet( obj_work.spd_m, 1024 ) );
        if ( obj_work.spd_m == 0 )
        {
            gms_GMK_GEAR_WORK.stop_timer = AppMain.ObjTimeCountDown( gms_GMK_GEAR_WORK.stop_timer );
            if ( gms_GMK_GEAR_WORK.stop_timer == 0 )
            {
                AppMain.gmGmkMoveGearRetInit( obj_work );
            }
        }
    }

    // Token: 0x0600058B RID: 1419 RVA: 0x00030C70 File Offset: 0x0002EE70
    private static void gmGmkMoveGearRetInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        gms_GMK_GEAR_WORK.rect_ret_timer = 0;
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag & 2048U ) != 0U )
        {
            gms_GMK_GEAR_WORK.rect_ret_timer = 65536;
        }
        if ( ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) == 0 && obj_work.pos.x == gms_GMK_GEAR_WORK.gmk_work.ene_com.born_pos_x ) || ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 && obj_work.pos.y == gms_GMK_GEAR_WORK.gmk_work.ene_com.born_pos_y ) )
        {
            AppMain.gmGmkMoveGearFwInit( obj_work );
            return;
        }
        gms_GMK_GEAR_WORK.ret_max_speed = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearRetMain );
    }

    // Token: 0x0600058C RID: 1420 RVA: 0x00030D44 File Offset: 0x0002EF44
    private static void gmGmkMoveGearRetMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        bool flag = false;
        int spd_m = obj_work.spd_m;
        if ( gms_GMK_GEAR_WORK.rect_ret_timer != 0 )
        {
            gms_GMK_GEAR_WORK.rect_ret_timer = AppMain.ObjTimeCountDown( gms_GMK_GEAR_WORK.rect_ret_timer );
            if ( gms_GMK_GEAR_WORK.rect_ret_timer == 0 )
            {
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294965247U;
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294965247U;
            }
        }
        if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) != 0 )
        {
            if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 )
            {
                if ( obj_work.pos.y < gms_ENEMY_COM_WORK.born_pos_y )
                {
                    spd_m = AppMain.ObjSpdUpSet( -obj_work.spd_m, -512, 16384 );
                }
                else
                {
                    flag = true;
                }
                if ( ( obj_work.move_flag & 4U ) != 0U )
                {
                    flag = true;
                }
            }
            else
            {
                if ( obj_work.pos.x < gms_ENEMY_COM_WORK.born_pos_x )
                {
                    spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, 512, 16384 );
                }
                else
                {
                    flag = true;
                }
                if ( ( obj_work.move_flag & 4U ) != 0U )
                {
                    flag = true;
                }
            }
        }
        else if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 )
        {
            if ( obj_work.pos.y > gms_ENEMY_COM_WORK.born_pos_y )
            {
                spd_m = AppMain.ObjSpdUpSet( -obj_work.spd_m, 512, 16384 );
            }
            else
            {
                flag = true;
            }
            if ( ( obj_work.move_flag & 8U ) != 0U )
            {
                flag = true;
            }
        }
        else
        {
            if ( obj_work.pos.x > gms_ENEMY_COM_WORK.born_pos_x )
            {
                spd_m = AppMain.ObjSpdUpSet( obj_work.spd_m, -512, 16384 );
            }
            else
            {
                flag = true;
            }
            if ( ( obj_work.move_flag & 8U ) != 0U )
            {
                flag = true;
            }
        }
        if ( AppMain.MTM_MATH_ABS( obj_work.spd_m ) > gms_GMK_GEAR_WORK.ret_max_speed )
        {
            gms_GMK_GEAR_WORK.ret_max_speed = AppMain.MTM_MATH_ABS( obj_work.spd_m );
        }
        if ( flag )
        {
            if ( gms_GMK_GEAR_WORK.ret_max_speed >= 14336 )
            {
                obj_work.vib_timer = 65536;
            }
            AppMain.gmGmkMoveGearSetSpd( obj_work, 0 );
            AppMain.gmGmkMoveGearFwInit( obj_work );
            return;
        }
        AppMain.gmGmkMoveGearSetSpd( obj_work, spd_m );
    }

    // Token: 0x0600058D RID: 1421 RVA: 0x00030F4C File Offset: 0x0002F14C
    private static void gmGmkMoveGearSwitchExeInit( AppMain.OBS_OBJECT_WORK obj_work, short cam_ofst_x, short cam_ofst_y )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        obj_work.user_flag |= 1U;
        obj_work.flag |= 2U;
        if ( gms_ENEMY_COM_WORK.target_obj != null && gms_ENEMY_COM_WORK.target_obj.obj_type == 1 )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)gms_ENEMY_COM_WORK.target_obj;
            AppMain.GmPlayerCameraOffsetSet( gms_PLAYER_WORK, ( short )( gms_PLAYER_WORK.gmk_camera_center_ofst_x + cam_ofst_x ), ( short )( gms_PLAYER_WORK.gmk_camera_center_ofst_y + cam_ofst_y ) );
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearSwitchExeMain );
    }

    // Token: 0x0600058E RID: 1422 RVA: 0x00030FC8 File Offset: 0x0002F1C8
    private static void gmGmkMoveGearSwitchExeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.sw_gear_obj == null )
        {
            AppMain.gmGmkMoveGearEndInit( obj_work );
            return;
        }
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK2 = (AppMain.GMS_GMK_GEAR_WORK)gms_GMK_GEAR_WORK.sw_gear_obj;
        if ( gms_GMK_GEAR_WORK2.open_rot_dist <= 0 )
        {
            AppMain.gmGmkMoveGearSetSpd( obj_work, 0 );
            if ( gms_GMK_GEAR_WORK2.gmk_work.ene_com.eve_rec.height == 0 )
            {
                gms_ENEMY_COM_WORK.eve_rec.byte_param[1] = 1;
            }
            AppMain.gmGmkMoveGearEndStaggerInit( obj_work );
            return;
        }
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj;
        if ( gms_PLAYER_WORK == null || ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
        {
            gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj = null;
            AppMain.gmGmkMoveGearRetWaitInit( obj_work );
            return;
        }
        int num = 0;
        if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 )
        {
            if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) == 0 && gms_PLAYER_WORK.obj_work.spd_m < 16384 )
            {
                num = 256;
            }
            else if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) != 0 && gms_PLAYER_WORK.obj_work.spd_m > -16384 )
            {
                num = -256;
            }
        }
        else if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) == 0 && gms_PLAYER_WORK.obj_work.spd_m > -16384 )
        {
            num = -256;
        }
        else if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) != 0 && gms_PLAYER_WORK.obj_work.spd_m < 16384 )
        {
            num = 256;
        }
        if ( num != 0 )
        {
            gms_PLAYER_WORK.obj_work.spd_m = AppMain.ObjSpdUpSet( gms_PLAYER_WORK.obj_work.spd_m, num, 16384 );
        }
        AppMain.gmGmkMoveGearSetSpd( obj_work, -gms_PLAYER_WORK.obj_work.spd_m );
    }

    // Token: 0x0600058F RID: 1423 RVA: 0x0003116C File Offset: 0x0002F36C
    private static void gmGmkMoveGearEndStaggerInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj;
        obj_work.user_flag &= 4294967294U;
        obj_work.user_flag |= 2U;
        obj_work.flag |= 2U;
        obj_work.move_flag |= 8448U;
        gms_GMK_GEAR_WORK.move_stagger_dir_cnt = 0;
        gms_GMK_GEAR_WORK.move_stagger_dir_spd = gms_PLAYER_WORK.obj_work.spd_m;
        obj_work.user_timer = gms_GMK_GEAR_WORK.move_stagger_dir_spd;
        gms_GMK_GEAR_WORK.move_stagger_step = 0;
        obj_work.user_work = ( uint )gms_GMK_GEAR_WORK.move_stagger_step;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearEndStaggerMain );
    }

    // Token: 0x06000590 RID: 1424 RVA: 0x0003121C File Offset: 0x0002F41C
    private static void gmGmkMoveGearEndStaggerMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj;
        if ( gms_PLAYER_WORK != null && gms_PLAYER_WORK.gmk_obj == obj_work )
        {
            int num;
            if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                num = -96;
            }
            else
            {
                num = 96;
            }
            switch ( gms_GMK_GEAR_WORK.move_stagger_step )
            {
                case 0:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd = gms_GMK_GEAR_WORK.move_stagger_dir_spd * 9 / 10;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK2 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK2.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( AppMain.MTM_MATH_ABS( gms_GMK_GEAR_WORK.move_stagger_dir_spd ) <= 128 )
                        {
                            AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK3 = gms_GMK_GEAR_WORK;
                            gms_GMK_GEAR_WORK3.move_stagger_step += 1;
                            gms_GMK_GEAR_WORK.move_stagger_dir_spd = 0;
                            gms_GMK_GEAR_WORK.move_stagger_dir_cnt = 0;
                            gms_GMK_GEAR_WORK.move_draw_dir_limit = gms_GMK_GEAR_WORK.move_draw_dir_ofst;
                        }
                        break;
                    }
                case 1:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd += num * 3 / 2;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK4 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK4.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( gms_GMK_GEAR_WORK.move_stagger_dir_cnt == 0 )
                        {
                            if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
                            {
                                if ( gms_GMK_GEAR_WORK.move_draw_dir_ofst < gms_GMK_GEAR_WORK.move_draw_dir_limit / 2 )
                                {
                                    gms_GMK_GEAR_WORK.move_stagger_dir_cnt = 1;
                                }
                            }
                            else if ( gms_GMK_GEAR_WORK.move_draw_dir_ofst > gms_GMK_GEAR_WORK.move_draw_dir_limit / 2 )
                            {
                                gms_GMK_GEAR_WORK.move_stagger_dir_cnt = 1;
                            }
                        }
                        else
                        {
                            AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK5 = gms_GMK_GEAR_WORK;
                            gms_GMK_GEAR_WORK5.move_stagger_dir_cnt += 1;
                            if ( gms_GMK_GEAR_WORK.move_stagger_dir_cnt == 3 )
                            {
                                AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK6 = gms_GMK_GEAR_WORK;
                                gms_GMK_GEAR_WORK6.move_stagger_step += 1;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd -= num * 3 / 2;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK7 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK7.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( AppMain.MTM_MATH_ABS( gms_GMK_GEAR_WORK.move_stagger_dir_spd ) <= 128 )
                        {
                            gms_GMK_GEAR_WORK.move_stagger_dir_spd = 0;
                            if ( ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 && AppMain.GmPlayerKeyCheckWalkRight( gms_PLAYER_WORK ) ) || ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) == 0 && AppMain.GmPlayerKeyCheckWalkLeft( gms_PLAYER_WORK ) ) )
                            {
                                AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK8 = gms_GMK_GEAR_WORK;
                                gms_GMK_GEAR_WORK8.move_stagger_step += 1;
                            }
                            else
                            {
                                gms_GMK_GEAR_WORK.move_stagger_step = 5;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd -= num;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK9 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK9.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( AppMain.MTM_MATH_ABS( ( int )gms_GMK_GEAR_WORK.move_draw_dir_ofst ) > 1820 )
                        {
                            AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK10 = gms_GMK_GEAR_WORK;
                            gms_GMK_GEAR_WORK10.move_stagger_step += 1;
                        }
                        break;
                    }
                case 4:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd += num;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK11 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK11.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( AppMain.MTM_MATH_ABS( gms_GMK_GEAR_WORK.move_stagger_dir_spd ) <= 128 )
                        {
                            gms_GMK_GEAR_WORK.move_stagger_step = 1;
                            gms_GMK_GEAR_WORK.move_stagger_dir_spd = 0;
                            gms_GMK_GEAR_WORK.move_stagger_dir_cnt = 0;
                            gms_GMK_GEAR_WORK.move_draw_dir_limit = gms_GMK_GEAR_WORK.move_draw_dir_ofst;
                        }
                        break;
                    }
                case 5:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd -= num;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK12 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK12.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( AppMain.MTM_MATH_ABS( ( int )gms_GMK_GEAR_WORK.move_draw_dir_ofst ) <= 309 )
                        {
                            AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK13 = gms_GMK_GEAR_WORK;
                            gms_GMK_GEAR_WORK13.move_stagger_step += 1;
                        }
                        break;
                    }
                case 6:
                    {
                        gms_GMK_GEAR_WORK.move_stagger_dir_spd += num;
                        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK14 = gms_GMK_GEAR_WORK;
                        gms_GMK_GEAR_WORK14.move_draw_dir_ofst += ( short )( gms_GMK_GEAR_WORK.move_stagger_dir_spd >> 5 );
                        if ( AppMain.MTM_MATH_ABS( gms_GMK_GEAR_WORK.move_stagger_dir_spd ) <= 128 )
                        {
                            gms_GMK_GEAR_WORK.move_stagger_dir_spd = 0;
                            gms_GMK_GEAR_WORK.move_draw_dir_ofst /= 2;
                            AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK15 = gms_GMK_GEAR_WORK;
                            gms_GMK_GEAR_WORK15.move_stagger_step += 1;
                        }
                        break;
                    }
                case 7:
                    if ( gms_GMK_GEAR_WORK.move_draw_dir_ofst != 0 )
                    {
                        gms_GMK_GEAR_WORK.move_draw_dir_ofst /= 2;
                    }
                    if ( ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 && AppMain.GmPlayerKeyCheckWalkRight( gms_PLAYER_WORK ) ) || ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) == 0 && AppMain.GmPlayerKeyCheckWalkLeft( gms_PLAYER_WORK ) ) )
                    {
                        gms_GMK_GEAR_WORK.move_stagger_step = 3;
                        gms_GMK_GEAR_WORK.move_draw_dir_ofst = 0;
                    }
                    break;
            }
            obj_work.user_work = ( uint )gms_GMK_GEAR_WORK.move_stagger_step;
            obj_work.user_timer = gms_GMK_GEAR_WORK.move_stagger_dir_spd;
            AppMain.gmGmkMoveGearSetSpd( obj_work, 0 );
            return;
        }
        obj_work.user_flag &= 4294967293U;
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK16 = (AppMain.GMS_GMK_GEAR_WORK)gms_GMK_GEAR_WORK.sw_gear_obj;
        if ( gms_GMK_GEAR_WORK16.gmk_work.ene_com.eve_rec.height == 0 )
        {
            gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.byte_param[1] = 1;
            AppMain.gmGmkMoveGearEndInit( obj_work );
            return;
        }
        AppMain.gmGmkMoveGearSwitchRetWaitInit( obj_work );
    }

    // Token: 0x06000591 RID: 1425 RVA: 0x000316AC File Offset: 0x0002F8AC
    private static void gmGmkMoveGearEndInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        obj_work.flag |= 2U;
        obj_work.move_flag |= 8448U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.enemy_flag |= 1U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj = null;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearEndMain );
    }

    // Token: 0x06000592 RID: 1426 RVA: 0x0003171C File Offset: 0x0002F91C
    private static void gmGmkMoveGearEndMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        short move_draw_dir_ofst = gms_GMK_GEAR_WORK.move_draw_dir_ofst;
        gms_GMK_GEAR_WORK.move_draw_dir_ofst = ( short )AppMain.ObjSpdDownSet( ( int )gms_GMK_GEAR_WORK.move_draw_dir_ofst, 64 );
        AppMain.gmGmkMoveGearSetSpd( obj_work, 0 );
    }

    // Token: 0x06000593 RID: 1427 RVA: 0x00031754 File Offset: 0x0002F954
    private static void gmGmkMoveGearSwitchRetWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        obj_work.flag |= 18U;
        obj_work.move_flag |= 8448U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.enemy_flag |= 1U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj = null;
        obj_work.user_timer = 245760;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearSwitchRetWaitMain );
    }

    // Token: 0x06000594 RID: 1428 RVA: 0x000317D0 File Offset: 0x0002F9D0
    private static void gmGmkMoveGearSwitchRetWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.sw_gear_obj == null )
        {
            obj_work.flag &= 4294967279U;
            AppMain.gmGmkMoveGearEndInit( obj_work );
            return;
        }
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.col_work.obj_col.rider_obj == null )
        {
            if ( obj_work.user_timer == 0 )
            {
                AppMain.gmGmkMoveGearSwitchRetInit( obj_work );
            }
        }
        else
        {
            obj_work.user_timer = 245760;
        }
        if ( gms_GMK_GEAR_WORK.move_draw_dir_ofst != 0 )
        {
            gms_GMK_GEAR_WORK.move_draw_dir_ofst = ( short )AppMain.ObjSpdDownSet( ( int )gms_GMK_GEAR_WORK.move_draw_dir_ofst, 64 );
            AppMain.gmGmkMoveGearSetSpd( obj_work, 0 );
        }
    }

    // Token: 0x06000595 RID: 1429 RVA: 0x00031864 File Offset: 0x0002FA64
    private static void gmGmkMoveGearSwitchRetInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        obj_work.flag &= 4294967293U;
        obj_work.move_flag &= 4294958847U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.enemy_flag &= 4294967280U;
        obj_work.user_flag &= 4294967294U;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[0].flag |= 2048U;
        gms_GMK_GEAR_WORK.rect_ret_timer = 0;
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag & 2048U ) != 0U )
        {
            gms_GMK_GEAR_WORK.rect_ret_timer = 65536;
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearSwitchRetMain );
    }

    // Token: 0x06000596 RID: 1430 RVA: 0x00031928 File Offset: 0x0002FB28
    private static void gmGmkMoveGearSwitchRetMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.sw_gear_obj == null )
        {
            obj_work.flag &= 4294967279U;
            AppMain.gmGmkMoveGearEndInit( obj_work );
            return;
        }
        if ( gms_GMK_GEAR_WORK.rect_ret_timer != 0 )
        {
            gms_GMK_GEAR_WORK.rect_ret_timer = AppMain.ObjTimeCountDown( gms_GMK_GEAR_WORK.rect_ret_timer );
            if ( gms_GMK_GEAR_WORK.rect_ret_timer == 0 )
            {
                gms_GMK_GEAR_WORK.gmk_work.ene_com.rect_work[2].flag &= 4294965247U;
            }
        }
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK2 = (AppMain.GMS_GMK_GEAR_WORK)gms_GMK_GEAR_WORK.sw_gear_obj;
        if ( gms_GMK_GEAR_WORK2.open_rot_dist >= 65536 )
        {
            AppMain.gmGmkMoveGearSetSpd( obj_work, 0 );
            AppMain.gmGmkMoveGearRetInit( obj_work );
            return;
        }
        int num = gms_GMK_GEAR_WORK2.close_rot_spd;
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 2 ) == 0 )
            {
                num = -num;
            }
        }
        else if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            num = -num;
        }
        AppMain.gmGmkMoveGearSetSpd( obj_work, -num << 5 );
        obj_work.spd_m = 0;
    }

    // Token: 0x06000597 RID: 1431 RVA: 0x00031A30 File Offset: 0x0002FC30
    private static bool gmGmkMoveGearCheckSwitchMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.obj_type != 3 || ( ( AppMain.GMS_ENEMY_COM_WORK )obj_work ).eve_rec.id != 182 )
        {
            return false;
        }
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 2 ) != 0 )
            {
                if ( obj_work.pos.y <= gms_GMK_GEAR_WORK.move_end_y )
                {
                    return true;
                }
            }
            else if ( obj_work.pos.y >= gms_GMK_GEAR_WORK.move_end_y )
            {
                return true;
            }
        }
        else if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            if ( obj_work.pos.x <= gms_GMK_GEAR_WORK.move_end_x )
            {
                return true;
            }
        }
        else if ( obj_work.pos.x >= gms_GMK_GEAR_WORK.move_end_x )
        {
            return true;
        }
        return false;
    }

    // Token: 0x06000598 RID: 1432 RVA: 0x00031B08 File Offset: 0x0002FD08
    private static void gmGmkMoveGearSetSpd( AppMain.OBS_OBJECT_WORK obj_work, int spd_m )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        int num = spd_m;
        int num2;
        int num3;
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            num2 = gms_GMK_GEAR_WORK.gmk_work.ene_com.born_pos_y - obj_work.pos.y;
            num3 = gms_GMK_GEAR_WORK.move_end_y - obj_work.pos.y;
            spd_m = -spd_m;
        }
        else
        {
            num2 = gms_GMK_GEAR_WORK.gmk_work.ene_com.born_pos_x - obj_work.pos.x;
            num3 = gms_GMK_GEAR_WORK.move_end_x - obj_work.pos.x;
        }
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            if ( spd_m < 0 )
            {
                if ( num3 > spd_m )
                {
                    spd_m = num3;
                }
            }
            else if ( num2 < spd_m )
            {
                spd_m = num2;
            }
        }
        else if ( spd_m > 0 )
        {
            if ( num3 < spd_m )
            {
                spd_m = num3;
            }
        }
        else if ( num2 > spd_m )
        {
            spd_m = num2;
        }
        obj_work.spd_m = spd_m;
        if ( spd_m != 0 && ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            obj_work.spd.x = obj_work.spd.x + 4096;
        }
        gms_GMK_GEAR_WORK.old_move_draw_dir = gms_GMK_GEAR_WORK.move_draw_dir;
        gms_GMK_GEAR_WORK.move_draw_dir_spd = ( short )( -num >> 5 );
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK2 = gms_GMK_GEAR_WORK;
        gms_GMK_GEAR_WORK2.move_draw_dir += ( ushort )gms_GMK_GEAR_WORK.move_draw_dir_spd;
        AppMain.nnMakeRotateZMatrix( obj_work.obj_3d.user_obj_mtx_r, ( int )( gms_GMK_GEAR_WORK.move_draw_dir * 2 + ( ushort )gms_GMK_GEAR_WORK.move_draw_dir_ofst ) );
        if ( gms_GMK_GEAR_WORK.old_move_draw_dir != gms_GMK_GEAR_WORK.move_draw_dir && ( ( obj_work.col_work.obj_col.rider_obj != null && obj_work.col_work.obj_col.rider_obj.obj_type == 1 && ( ( AppMain.GMS_PLAYER_WORK )obj_work.col_work.obj_col.rider_obj ).gmk_obj == null ) || ( obj_work.col_work.obj_col.toucher_obj != null && obj_work.col_work.obj_col.toucher_obj.obj_type == 1 && ( ( AppMain.GMS_PLAYER_WORK )obj_work.col_work.obj_col.toucher_obj ).gmk_obj == null ) ) && gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj == null )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obj_work.col_work.obj_col.rider_obj;
            if ( gms_PLAYER_WORK == null )
            {
                gms_PLAYER_WORK = ( AppMain.GMS_PLAYER_WORK )obj_work.col_work.obj_col.toucher_obj;
            }
            if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.gmk_obj == obj_work )
            {
                return;
            }
            AppMain.gmGmkGearSetRotFlow( obj_work, gms_PLAYER_WORK, ( int )( ( ( short )gms_GMK_GEAR_WORK.move_draw_dir - ( short )gms_GMK_GEAR_WORK.old_move_draw_dir ) * 2 ) );
        }
    }

    // Token: 0x06000599 RID: 1433 RVA: 0x00031D74 File Offset: 0x0002FF74
    private static void gmGmkMoveGearBodyDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)mine_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        if ( gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.gmk_obj == parent_obj || ( gms_PLAYER_WORK.obj_work.move_flag & 1U ) == 0U || gms_PLAYER_WORK.seq_state == 0 || ( 3 <= gms_PLAYER_WORK.seq_state && gms_PLAYER_WORK.seq_state <= 8 ) )
        {
            return;
        }
        if ( ( gms_PLAYER_WORK.obj_work.pos.x <= parent_obj.pos.x - 16384 || gms_PLAYER_WORK.obj_work.pos.x >= parent_obj.pos.x + 16384 ) && ( gms_PLAYER_WORK.obj_work.prev_pos.x > parent_obj.pos.x || gms_PLAYER_WORK.obj_work.pos.x < parent_obj.pos.x ) && ( gms_PLAYER_WORK.obj_work.prev_pos.x < parent_obj.pos.x || gms_PLAYER_WORK.obj_work.pos.x > parent_obj.pos.x ) )
        {
            return;
        }
        gms_GMK_GEAR_WORK.gmk_work.ene_com.target_dp_pos.x = 0;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.target_dp_pos.y = -262144 - ( int )( gms_PLAYER_WORK.obj_work.field_rect[3] * 4096 );
        gms_GMK_GEAR_WORK.gmk_work.ene_com.target_dp_pos.z = gms_PLAYER_WORK.obj_work.pos.z - parent_obj.pos.z;
        gms_GMK_GEAR_WORK.gmk_work.ene_com.enemy_flag &= 4294967280U;
        AppMain.GmPlySeqInitMoveGear( gms_PLAYER_WORK, parent_obj, ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 4 ) == 0 );
        gms_GMK_GEAR_WORK.gmk_work.ene_com.target_obj = ( AppMain.OBS_OBJECT_WORK )gms_PLAYER_WORK;
        AppMain.gmGmkMoveGearMoveInit( parent_obj );
    }

    // Token: 0x0600059A RID: 1434 RVA: 0x00031F6C File Offset: 0x0003016C
    private static void gmGmkMoveGearDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)mine_rect.parent_obj;
        if ( match_rect.parent_obj.obj_type != 3 )
        {
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 183 )
        {
            gms_GMK_GEAR_WORK.move_end_x = match_rect.parent_obj.pos.x;
            gms_GMK_GEAR_WORK.move_end_y = match_rect.parent_obj.pos.y;
            if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 1 ) != 0 )
            {
                gms_GMK_GEAR_WORK.gear_end_obj = match_rect.parent_obj;
                return;
            }
        }
        else if ( ( ( AppMain.GMS_ENEMY_COM_WORK )match_rect.parent_obj ).eve_rec.id == 184 )
        {
            gms_GMK_GEAR_WORK.sw_gear_obj = match_rect.parent_obj;
        }
    }

    // Token: 0x0600059B RID: 1435 RVA: 0x00032024 File Offset: 0x00030224
    private static void gmGmkMoveGearEndSwitchFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 && gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.byte_param[1] == 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkMoveGearEndSwitchFwMain );
        }
    }

    // Token: 0x0600059C RID: 1436 RVA: 0x0003207C File Offset: 0x0003027C
    private static void gmGmkMoveGearEndSwitchFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.move_gear_obj != null )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)gms_GMK_GEAR_WORK.move_gear_obj;
            if ( gms_ENEMY_COM_WORK.eve_rec.byte_param[1] != 0 )
            {
                gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.byte_param[1] = 1;
                obj_work.parent_obj = gms_GMK_GEAR_WORK.move_gear_obj;
                obj_work.flag |= 16U;
                obj_work.ppFunc = null;
            }
        }
    }

    // Token: 0x0600059D RID: 1437 RVA: 0x000320F0 File Offset: 0x000302F0
    private static void gmGmkMoveGearEndAtkHitFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        if ( match_rect.parent_obj.obj_type != 3 )
        {
            AppMain.ObjRectFuncNoHit( mine_rect, match_rect );
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK.eve_rec.id != 182 )
        {
            AppMain.ObjRectFuncNoHit( mine_rect, match_rect );
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK2 = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        if ( ( gms_ENEMY_COM_WORK2.eve_rec.flag & 1 ) != 0 )
        {
            AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)mine_rect.parent_obj;
            gms_GMK_GEAR_WORK.move_gear_obj = match_rect.parent_obj;
        }
    }

    // Token: 0x0600059E RID: 1438 RVA: 0x0003216C File Offset: 0x0003036C
    private static void gmGmkGearSwFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        gms_GMK_GEAR_WORK.open_rot_dist = 65536;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearSwFwMain );
        gms_GMK_GEAR_WORK.move_gear_obj = null;
    }

    // Token: 0x0600059F RID: 1439 RVA: 0x000321A4 File Offset: 0x000303A4
    private static void gmGmkGearSwFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060005A0 RID: 1440 RVA: 0x000321A6 File Offset: 0x000303A6
    private static void gmGmkGearSwRotExtWaitInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearSwFwMain ) )
        {
            AppMain.GmSoundPlaySE( "Gear2", null );
        }
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearSwRotExtWaitMain );
    }

    // Token: 0x060005A1 RID: 1441 RVA: 0x000321E0 File Offset: 0x000303E0
    private static void gmGmkGearSwRotExtWaitMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.move_gear_obj == null )
        {
            AppMain.gmGmkGearSwFwInit( obj_work );
            return;
        }
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK2 = (AppMain.GMS_GMK_GEAR_WORK)gms_GMK_GEAR_WORK.move_gear_obj;
        int num = (int)((gms_GMK_GEAR_WORK.move_draw_dir - 5461) / 5461 * 2);
        int num2 = (int)((gms_GMK_GEAR_WORK2.move_draw_dir - 2730) / 5461 * 2);
        if ( num != num2 )
        {
            gms_GMK_GEAR_WORK.move_draw_dir = ( ushort )( -( ushort )( ( int )gms_GMK_GEAR_WORK2.move_draw_dir - ( 2730 - num2 * 5461 ) / 2 ) );
            AppMain.gmGmkGearSwRotExtInit( obj_work );
        }
    }

    // Token: 0x060005A2 RID: 1442 RVA: 0x00032263 File Offset: 0x00030463
    private static void gmGmkGearSwRotExtInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkGearSwRotExtMain );
    }

    // Token: 0x060005A3 RID: 1443 RVA: 0x00032278 File Offset: 0x00030478
    private static void gmGmkGearSwRotExtMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( gms_GMK_GEAR_WORK.move_gear_obj == null )
        {
            obj_work.flag &= 4294967279U;
            AppMain.gmGmkGearSwFwInit( obj_work );
            return;
        }
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK2 = (AppMain.GMS_GMK_GEAR_WORK)gms_GMK_GEAR_WORK.move_gear_obj;
        int num = (int)gms_GMK_GEAR_WORK2.move_draw_dir_spd;
        gms_GMK_GEAR_WORK.move_draw_dir = ( ushort )( ( int )gms_GMK_GEAR_WORK.move_draw_dir - num );
        gms_GMK_GEAR_WORK.move_draw_dir_ofst = ( short )-gms_GMK_GEAR_WORK2.move_draw_dir_ofst;
        AppMain.nnMakeRotateZMatrix( obj_work.obj_3d.user_obj_mtx_r, ( int )( gms_GMK_GEAR_WORK.move_draw_dir * 2 + ( ushort )gms_GMK_GEAR_WORK.move_draw_dir_ofst ) );
        if ( gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj != null && gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj.obj_type == 1 )
        {
            AppMain.gmGmkGearSetRotFlow( obj_work, ( AppMain.GMS_PLAYER_WORK )gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work.obj_col.rider_obj, -num * 2 );
        }
        else if ( gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work.obj_col.toucher_obj != null && gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work.obj_col.toucher_obj.obj_type == 1 )
        {
            AppMain.gmGmkGearSetRotFlow( obj_work, ( AppMain.GMS_PLAYER_WORK )gms_GMK_GEAR_WORK.gmk_work.ene_com.col_work.obj_col.toucher_obj, -num * 2 );
        }
        if ( ( gms_GMK_GEAR_WORK2.gmk_work.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            if ( ( gms_GMK_GEAR_WORK2.gmk_work.ene_com.eve_rec.flag & 2 ) == 0 )
            {
                num = -num;
            }
        }
        else if ( ( gms_GMK_GEAR_WORK2.gmk_work.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            num = -num;
        }
        gms_GMK_GEAR_WORK.open_rot_dist += num;
        int numer = AppMain.MTM_MATH_CLIP(gms_GMK_GEAR_WORK.open_rot_dist, 0, 65536);
        if ( num <= 0 )
        {
            AppMain.GmGmkSwitchSetOnGearSwitch( ( uint )gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.width, AppMain.FX_Div( numer, 65536 ) );
        }
        else
        {
            AppMain.GmGmkSwitchSetOffGearSwitch( ( uint )gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.width, AppMain.FX_Div( numer, 65536 ) );
        }
        if ( gms_GMK_GEAR_WORK.open_rot_dist > 0 )
        {
            if ( gms_GMK_GEAR_WORK.open_rot_dist >= 65536 )
            {
                obj_work.flag &= 4294967279U;
                AppMain.gmGmkGearSwFwInit( obj_work );
            }
            return;
        }
        if ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.height == 0 )
        {
            gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.byte_param[1] = 1;
            obj_work.ppFunc = null;
            gms_GMK_GEAR_WORK.move_gear_obj = null;
            return;
        }
        obj_work.flag |= 16U;
    }

    // Token: 0x060005A4 RID: 1444 RVA: 0x00032508 File Offset: 0x00030708
    private static void gmGmkGearSwitchAtkHitFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        if ( match_rect.parent_obj.obj_type != 3 )
        {
            AppMain.ObjRectFuncNoHit( mine_rect, match_rect );
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK.eve_rec.id != 182 )
        {
            AppMain.ObjRectFuncNoHit( mine_rect, match_rect );
            return;
        }
        if ( gms_ENEMY_COM_WORK.target_obj == null )
        {
            AppMain.ObjRectFuncNoHit( mine_rect, match_rect );
            return;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK2 = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK.eve_rec.width != gms_ENEMY_COM_WORK2.eve_rec.width )
        {
            return;
        }
        if ( !AppMain.gmGmkMoveGearCheckSwitchMove( match_rect.parent_obj ) )
        {
            AppMain.ObjRectFuncNoHit( mine_rect, match_rect );
            return;
        }
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)mine_rect.parent_obj;
        gms_GMK_GEAR_WORK.move_gear_obj = match_rect.parent_obj;
        AppMain.gmGmkMoveGearSwitchExeInit( match_rect.parent_obj, ( short )gms_ENEMY_COM_WORK2.eve_rec.left, ( short )( -( short )gms_ENEMY_COM_WORK2.eve_rec.top ) );
        AppMain.gmGmkGearSwRotExtWaitInit( mine_rect.parent_obj );
    }

    // Token: 0x060005A5 RID: 1445 RVA: 0x000325E4 File Offset: 0x000307E4
    private static void gmGmkGearSetRotFlow( AppMain.OBS_OBJECT_WORK gear_obj, AppMain.GMS_PLAYER_WORK ply_work, int move_dir )
    {
        int num = ply_work.obj_work.pos.x - gear_obj.pos.x;
        int num2 = ply_work.obj_work.pos.y - gear_obj.pos.y;
        float num3 = AppMain.FXM_FX32_TO_FLOAT(num);
        float num4 = AppMain.FXM_FX32_TO_FLOAT(num2);
        int num5 = AppMain.nnArcTan2((double)(-(double)num4), (double)num3);
        float num6 = AppMain.nnSqrt(num3 * num3 + num4 * num4);
        int ang = num5 + move_dir;
        int num7 = AppMain.FXM_FLOAT_TO_FX32(AppMain.nnCos(ang) * num6);
        int num8 = -AppMain.FXM_FLOAT_TO_FX32(AppMain.nnSin(ang) * num6);
        int num9 = AppMain.FX_Mul(num7 - num, 5120);
        if ( AppMain.MTM_MATH_ABS( num9 ) < 4096 )
        {
            if ( num9 > 0 || gear_obj.spd_m > 0 )
            {
                num9 = 4096;
            }
            else
            {
                num9 = -4096;
            }
        }
        if ( ply_work.obj_work.ride_obj == gear_obj )
        {
            AppMain.OBS_OBJECT_WORK obj_work = ply_work.obj_work;
            obj_work.flow.x = obj_work.flow.x + num9;
            AppMain.OBS_OBJECT_WORK obj_work2 = ply_work.obj_work;
            obj_work2.flow.y = obj_work2.flow.y + ( num8 - num2 );
            return;
        }
        if ( ply_work.obj_work.ride_obj == null && ply_work.obj_work.touch_obj == gear_obj )
        {
            if ( ( move_dir > 0 && ply_work.obj_work.spd_m < -32768 && ply_work.obj_work.pos.y > gear_obj.pos.y ) || ( move_dir < 0 && ply_work.obj_work.spd_m > 32768 && ply_work.obj_work.pos.y < gear_obj.pos.y ) )
            {
                ply_work.obj_work.move_flag &= 4294967294U;
                return;
            }
            if ( ( ply_work.obj_work.move_flag & 1U ) != 0U && ( ( move_dir < 0 && ply_work.obj_work.spd_m >= 0 && ply_work.obj_work.pos.x > gear_obj.pos.x ) || ( move_dir > 0 && ply_work.obj_work.spd_m <= 0 && ply_work.obj_work.pos.x < gear_obj.pos.x ) ) )
            {
                AppMain.OBS_OBJECT_WORK obj_work3 = ply_work.obj_work;
                obj_work3.flow.x = obj_work3.flow.x + ( num9 + gear_obj.move.x ) * 2;
                AppMain.OBS_OBJECT_WORK obj_work4 = ply_work.obj_work;
                obj_work4.flow.y = obj_work4.flow.y + ( num8 - num2 );
                ply_work.obj_work.move_flag &= 4294967294U;
            }
        }
    }

    // Token: 0x060005A6 RID: 1446 RVA: 0x00032864 File Offset: 0x00030A64
    private static void gmGmkGearMoveSwDraw( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.VecFx32 vecFx;
        vecFx.x = obj_work.pos.x;
        vecFx.y = obj_work.pos.y;
        vecFx.z = obj_work.pos.z + 786432;
        gms_GMK_GEAR_WORK.obj_3d_gear_opt.user_obj_mtx_r.Assign( obj_work.obj_3d.user_obj_mtx_r );
        AppMain.ObjDrawAction3DNN( gms_GMK_GEAR_WORK.obj_3d_gear_opt, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref obj_work.disp_flag );
        vecFx.z = obj_work.pos.z + 524288;
        gms_GMK_GEAR_WORK.obj_3d_gear_opt_ashiba.user_obj_mtx_r.Assign( obj_work.obj_3d.user_obj_mtx_r );
        AppMain.ObjDrawAction3DNN( gms_GMK_GEAR_WORK.obj_3d_gear_opt_ashiba, new AppMain.VecFx32?( vecFx ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref obj_work.disp_flag );
    }

    // Token: 0x060005A7 RID: 1447 RVA: 0x0003295C File Offset: 0x00030B5C
    private static void gmGmkGearLastFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        if ( ( obj_work.flag & 12U ) != 0U )
        {
            return;
        }
        if ( gms_GMK_GEAR_WORK.h_snd_gear == null )
        {
            return;
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        float num = AppMain.FXM_FX32_TO_FLOAT(gms_GMK_GEAR_WORK.gmk_work.ene_com.obj_work.pos.x) - obs_CAMERA.disp_pos.x;
        float num2 = AppMain.FXM_FX32_TO_FLOAT(gms_GMK_GEAR_WORK.gmk_work.ene_com.obj_work.pos.y) - -obs_CAMERA.disp_pos.y;
        float num4;
        if ( num < 400f && num2 < 400f )
        {
            float num3 = num * num + num2 * num2;
            if ( num3 <= 10000f )
            {
                num4 = 1f;
            }
            else if ( num3 <= 160000f )
            {
                num4 = ( 160000f - num3 ) / 90000f;
                if ( num4 > 1f )
                {
                    num4 = 1f;
                }
                else if ( num4 < 0f )
                {
                    num4 = 0f;
                }
            }
            else
            {
                num4 = 0f;
            }
        }
        else
        {
            num4 = 0f;
        }
        gms_GMK_GEAR_WORK.h_snd_gear.snd_ctrl_param.volume = num4;
    }

    // Token: 0x060005A8 RID: 1448 RVA: 0x00032A7C File Offset: 0x00030C7C
    private static void gmGmkGearMoveLastFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_GEAR_WORK gms_GMK_GEAR_WORK = (AppMain.GMS_GMK_GEAR_WORK)obj_work;
        float num = 0f;
        if ( obj_work.flag != 0U )
        {
            return;
        }
        if ( gms_GMK_GEAR_WORK.h_snd_gear == null )
        {
            return;
        }
        int num2;
        if ( gms_GMK_GEAR_WORK.gmk_work.ene_com.eve_rec.id == 182 )
        {
            num2 = AppMain.MTM_MATH_ABS( ( int )gms_GMK_GEAR_WORK.move_draw_dir_spd );
            short a = (short)(gms_GMK_GEAR_WORK.move_draw_dir_ofst >> 3);
            num2 += AppMain.MTM_MATH_ABS( ( int )a );
        }
        else if ( gms_GMK_GEAR_WORK.move_gear_obj != null )
        {
            num2 = AppMain.MTM_MATH_ABS( ( int )( ( AppMain.GMS_GMK_GEAR_WORK )gms_GMK_GEAR_WORK.move_gear_obj ).move_draw_dir_spd );
        }
        else
        {
            num2 = 0;
        }
        if ( num2 >= 4 )
        {
            if ( num2 >= 864 )
            {
                num = 1f;
            }
            else
            {
                num = AppMain.FXM_FX32_TO_FLOAT( AppMain.FX_Div( num2 - 4, 860 ) );
                if ( num > 1f )
                {
                    num = 1f;
                }
            }
        }
        gms_GMK_GEAR_WORK.h_snd_gear.au_player.SetAisac( "Speed", num );
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        float num3 = AppMain.FXM_FX32_TO_FLOAT(gms_GMK_GEAR_WORK.gmk_work.ene_com.obj_work.pos.x) - obs_CAMERA.disp_pos.x;
        float num4 = AppMain.FXM_FX32_TO_FLOAT(gms_GMK_GEAR_WORK.gmk_work.ene_com.obj_work.pos.y) - -obs_CAMERA.disp_pos.y;
        float num6;
        if ( num3 < 600f && num4 < 600f )
        {
            float num5 = num3 * num3 + num4 * num4;
            if ( num5 <= 90000f )
            {
                num6 = 1f;
            }
            else if ( num5 <= 360000f )
            {
                num6 = ( 360000f - num5 ) / 90000f;
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
        gms_GMK_GEAR_WORK.h_snd_gear.snd_ctrl_param.volume = num6;
    }
}