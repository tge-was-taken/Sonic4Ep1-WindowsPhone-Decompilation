using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000242 RID: 578
    // (Invoke) Token: 0x060023A5 RID: 9125
    public delegate void _ring_work_func_delegate_( AppMain.GMS_RING_WORK gms_ring_work );

    // Token: 0x02000243 RID: 579
    // (Invoke) Token: 0x060023A9 RID: 9129
    public delegate ushort _rec_func_( AppMain.OBS_RECT obs_rect1, AppMain.OBS_RECT obs_rect2 );

    // Token: 0x02000244 RID: 580
    public class GMS_RING_SYS_WORK : AppMain.IClearable
    {
        // Token: 0x060023AC RID: 9132 RVA: 0x0014930C File Offset: 0x0014750C
        public void Clear()
        {
            this.flag = 0U;
            this.ring_draw_func = null;
            this.rec_func = null;
            this.col_func = null;
            this.dir = 0;
            Array.Clear( this.damage_num, 0, 1 );
            this.player_num = 0;
            this.ref_spd_base = 0;
            this.ring_list_start = null;
            this.ring_list_end = null;
            this.twinkle_list_start = null;
            this.twinkle_list_end = null;
            this.damage_ring_list_start = null;
            this.damage_ring_list_end = null;
            this.slot_ring_list_start = null;
            this.slot_ring_list_end = null;
            this.ring_list_cnt = 0;
            Array.Clear( this.ring_list, 0, 96 );
            AppMain.ClearArray<AppMain.GMS_RING_WORK>( this.ring_list_buf );
            this.wait_slot_ring_num = 0;
            this.slot_ring_create_dir = 0;
            this.slot_target_obj = null;
            this.slot_ring_timer = 0;
            this.draw_ring_count = 0;
            this.draw_ring_uv_frame = 0;
            AppMain.ClearArray<AppMain.VecFx32>( this.draw_ring_pos );
            Array.Clear( this.h_snd_ring, 0, 2 );
            this.ring_se_cnt = 0;
            this.color = 0U;
            this.se_wait = 0;
        }

        // Token: 0x040057FD RID: 22525
        public uint flag;

        // Token: 0x040057FE RID: 22526
        public AppMain._ring_work_func_delegate_ ring_draw_func;

        // Token: 0x040057FF RID: 22527
        public AppMain._rec_func_ rec_func;

        // Token: 0x04005800 RID: 22528
        public AppMain._ring_work_func_delegate_ col_func;

        // Token: 0x04005801 RID: 22529
        public ushort dir;

        // Token: 0x04005802 RID: 22530
        public byte[] damage_num = new byte[1];

        // Token: 0x04005803 RID: 22531
        public byte player_num;

        // Token: 0x04005804 RID: 22532
        public short ref_spd_base;

        // Token: 0x04005805 RID: 22533
        public AppMain.GMS_RING_WORK ring_list_start;

        // Token: 0x04005806 RID: 22534
        public AppMain.GMS_RING_WORK ring_list_end;

        // Token: 0x04005807 RID: 22535
        public AppMain.GMS_RING_WORK twinkle_list_start;

        // Token: 0x04005808 RID: 22536
        public AppMain.GMS_RING_WORK twinkle_list_end;

        // Token: 0x04005809 RID: 22537
        public AppMain.GMS_RING_WORK damage_ring_list_start;

        // Token: 0x0400580A RID: 22538
        public AppMain.GMS_RING_WORK damage_ring_list_end;

        // Token: 0x0400580B RID: 22539
        public AppMain.GMS_RING_WORK slot_ring_list_start;

        // Token: 0x0400580C RID: 22540
        public AppMain.GMS_RING_WORK slot_ring_list_end;

        // Token: 0x0400580D RID: 22541
        public int ring_list_cnt;

        // Token: 0x0400580E RID: 22542
        public AppMain.GMS_RING_WORK[] ring_list = new AppMain.GMS_RING_WORK[96];

        // Token: 0x0400580F RID: 22543
        public AppMain.GMS_RING_WORK[] ring_list_buf = AppMain.New<AppMain.GMS_RING_WORK>(96);

        // Token: 0x04005810 RID: 22544
        public int wait_slot_ring_num;

        // Token: 0x04005811 RID: 22545
        public ushort slot_ring_create_dir;

        // Token: 0x04005812 RID: 22546
        public AppMain.OBS_OBJECT_WORK slot_target_obj;

        // Token: 0x04005813 RID: 22547
        public int slot_ring_timer;

        // Token: 0x04005814 RID: 22548
        public ushort draw_ring_count;

        // Token: 0x04005815 RID: 22549
        public ushort draw_ring_uv_frame;

        // Token: 0x04005816 RID: 22550
        public AppMain.VecFx32[] draw_ring_pos = AppMain.New<AppMain.VecFx32>(96);

        // Token: 0x04005817 RID: 22551
        public AppMain.GSS_SND_SE_HANDLE[] h_snd_ring = new AppMain.GSS_SND_SE_HANDLE[2];

        // Token: 0x04005818 RID: 22552
        public int ring_se_cnt;

        // Token: 0x04005819 RID: 22553
        public uint color;

        // Token: 0x0400581A RID: 22554
        public int se_wait;
    }

    // Token: 0x02000245 RID: 581
    public class GMS_RING_WORK : AppMain.IClearable
    {
        // Token: 0x060023AE RID: 9134 RVA: 0x0014945C File Offset: 0x0014765C
        public void Clear()
        {
            this.pos.Clear();
            this.scale.Clear();
            this.spd_x = 0;
            this.spd_y = 0;
            this.timer = 0;
            this.flag = 0;
            this.eve_rec = null;
            this.pre_ring = null;
            this.post_ring = null;
            this.duct_obj = null;
        }

        // Token: 0x0400581B RID: 22555
        public AppMain.VecFx32 pos = default(AppMain.VecFx32);

        // Token: 0x0400581C RID: 22556
        public AppMain.VecFx32 scale = default(AppMain.VecFx32);

        // Token: 0x0400581D RID: 22557
        public int spd_x;

        // Token: 0x0400581E RID: 22558
        public int spd_y;

        // Token: 0x0400581F RID: 22559
        public short timer;

        // Token: 0x04005820 RID: 22560
        public ushort flag;

        // Token: 0x04005821 RID: 22561
        public AppMain.GMS_EVE_RECORD_RING eve_rec;

        // Token: 0x04005822 RID: 22562
        public AppMain.GMS_RING_WORK pre_ring;

        // Token: 0x04005823 RID: 22563
        public AppMain.GMS_RING_WORK post_ring;

        // Token: 0x04005824 RID: 22564
        public AppMain.OBS_OBJECT_WORK duct_obj;
    }

    // Token: 0x06000D8C RID: 3468 RVA: 0x0007683C File Offset: 0x00074A3C
    public static void GmRingBuild()
    {
        AppMain.gm_ring_obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();
        AppMain.ObjAction3dNNModelLoad( AppMain.gm_ring_obj_3d, null, null, 0, AppMain.readAMBFile( ( AppMain.AMS_FS )AppMain.ObjDataGet( 2 ).pData ), null, AppMain.readAMBFile( ( AppMain.AMS_FS )AppMain.ObjDataGet( 3 ).pData ), 0U );
    }

    // Token: 0x06000D8D RID: 3469 RVA: 0x0007688C File Offset: 0x00074A8C
    public static AppMain.GMS_RING_SYS_WORK GmRingGetWork()
    {
        return AppMain.gm_ring_sys_work;
    }

    // Token: 0x06000D8E RID: 3470 RVA: 0x00076893 File Offset: 0x00074A93
    public static int GmRingFlushCheck()
    {
        if ( AppMain.gm_ring_obj_3d == null )
        {
            return 1;
        }
        if ( AppMain.ObjAction3dNNModelReleaseCheck( AppMain.gm_ring_obj_3d ) )
        {
            AppMain.gm_ring_obj_3d = null;
            return 1;
        }
        return 0;
    }

    // Token: 0x06000D8F RID: 3471 RVA: 0x000768B3 File Offset: 0x00074AB3
    public static void GmRingFlush()
    {
        AppMain.ObjAction3dNNMotionRelease( AppMain.gm_ring_obj_3d );
        AppMain.ObjAction3dNNModelRelease( AppMain.gm_ring_obj_3d );
    }

    // Token: 0x06000D90 RID: 3472 RVA: 0x000768C9 File Offset: 0x00074AC9
    public static int GmRingBuildCheck()
    {
        if ( AppMain.ObjAction3dNNModelLoadCheck( AppMain.gm_ring_obj_3d ) )
        {
            if ( AppMain.gm_ring_obj_3d.mat_mtn[0] == null )
            {
                AppMain.ObjAction3dNNMaterialMotionLoad( AppMain.gm_ring_obj_3d, 0, null, null, 0, AppMain.readAMBFile( AppMain.ObjDataGet( 4 ).pData ) );
            }
            return 1;
        }
        return 0;
    }

    // Token: 0x06000D91 RID: 3473 RVA: 0x00076906 File Offset: 0x00074B06
    public static void GmRingExit()
    {
        if ( AppMain.gm_ring_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_ring_tcb );
        }
    }

    // Token: 0x06000D92 RID: 3474 RVA: 0x0007691C File Offset: 0x00074B1C
    public static AppMain.GMS_RING_WORK GmRingCreate( AppMain.GMS_EVE_RECORD_RING eve_rec, int pos_x, int pos_y, int pos_z )
    {
        if ( AppMain.gm_ring_sys_work == null )
        {
            return null;
        }
        AppMain.GMS_RING_WORK gms_RING_WORK = AppMain.gmRingAllocRingWork();
        if ( gms_RING_WORK == null )
        {
            return null;
        }
        gms_RING_WORK.pos.x = pos_x;
        gms_RING_WORK.pos.y = pos_y;
        gms_RING_WORK.pos.z = pos_z;
        gms_RING_WORK.spd_x = 0;
        gms_RING_WORK.spd_y = 0;
        gms_RING_WORK.scale.x = ( gms_RING_WORK.scale.y = ( gms_RING_WORK.scale.z = AppMain.gm_ring_scale ) );
        gms_RING_WORK.timer = 0;
        gms_RING_WORK.flag = 0;
        if ( eve_rec != null )
        {
            eve_rec.pos_x = byte.MaxValue;
        }
        gms_RING_WORK.eve_rec = eve_rec;
        gms_RING_WORK.duct_obj = null;
        AppMain.gmRingAttachRingList( gms_RING_WORK );
        return gms_RING_WORK;
    }

    // Token: 0x06000D93 RID: 3475 RVA: 0x000769CC File Offset: 0x00074BCC
    public static AppMain.GMS_RING_WORK gmRingAllocRingWork()
    {
        if ( AppMain.gm_ring_sys_work.ring_list_cnt >= 96 )
        {
            return null;
        }
        AppMain.GMS_RING_WORK result = AppMain.gm_ring_sys_work.ring_list[AppMain.gm_ring_sys_work.ring_list_cnt];
        AppMain.gm_ring_sys_work.ring_list_cnt++;
        return result;
    }

    // Token: 0x06000D94 RID: 3476 RVA: 0x00076A14 File Offset: 0x00074C14
    public static void gmRingAttachRingList( AppMain.GMS_RING_WORK ring_work )
    {
        if ( AppMain.gm_ring_sys_work.ring_list_end != null )
        {
            AppMain.gm_ring_sys_work.ring_list_end.post_ring = ring_work;
            ring_work.pre_ring = AppMain.gm_ring_sys_work.ring_list_end;
            ring_work.post_ring = null;
            AppMain.gm_ring_sys_work.ring_list_end = ring_work;
            return;
        }
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.gm_ring_sys_work;
        AppMain.gm_ring_sys_work.ring_list_end = ring_work;
        gms_RING_SYS_WORK.ring_list_start = ring_work;
        ring_work.pre_ring = ( ring_work.post_ring = null );
    }

    // Token: 0x06000D95 RID: 3477 RVA: 0x00076A90 File Offset: 0x00074C90
    public static void GmRingInit()
    {
        AppMain.MTS_TASK_TCB mts_TASK_TCB = AppMain.MTM_TASK_MAKE_TCB(new AppMain.GSF_TASK_PROCEDURE(AppMain.gmRingMain), new AppMain.GSF_TASK_PROCEDURE(AppMain.gmRingDest), 0U, 0, 7680U, 5, () => new AppMain.GMS_RING_SYS_WORK(), "GM RING MAIN");
        if ( mts_TASK_TCB == null )
        {
            return;
        }
        AppMain.gm_ring_tcb = mts_TASK_TCB;
        AppMain.gm_ring_sys_work = ( AppMain.GMS_RING_SYS_WORK )mts_TASK_TCB.work;
        AppMain.gm_ring_sys_work.Clear();
        AppMain.gm_ring_sys_work.h_snd_ring[0] = AppMain.GsSoundAllocSeHandle();
        AppMain.gm_ring_sys_work.h_snd_ring[1] = AppMain.GsSoundAllocSeHandle();
        AppMain.gm_ring_sys_work.h_snd_ring[0].flag |= 2147483648U;
        AppMain.gm_ring_sys_work.h_snd_ring[1].flag |= 2147483648U;
        AppMain.gm_ring_sys_work.player_num = 1;
        for ( int i = 0; i < 96; i++ )
        {
            AppMain.GMS_RING_WORK gms_RING_WORK = AppMain.gm_ring_sys_work.ring_list_buf[i];
            AppMain.gm_ring_sys_work.ring_list[i] = gms_RING_WORK;
        }
        AppMain.gm_ring_scale = 4096;
        AppMain.gm_ring_fall_acc_x = 0;
        AppMain.gm_ring_fall_acc_y = 288;
        if ( 21 <= AppMain.g_gs_main_sys_info.stage_id && AppMain.g_gs_main_sys_info.stage_id <= 27 )
        {
            AppMain.g_gm_ring_size = ( short )( ( double )( AppMain.OBD_LCD_X - AppMain.OBD_LCD_Y ) * 1.4 + 20.0 );
            AppMain.gm_ring_die_offset = ( short )( ( double )( AppMain.OBD_LCD_X - AppMain.OBD_LCD_Y ) * 1.4 + 72.0 );
        }
        else
        {
            AppMain.g_gm_ring_size = 20;
            AppMain.gm_ring_die_offset = 72;
        }
        AppMain.gm_ring_sys_work.rec_func = new AppMain._rec_func_( AppMain.gmRingHitFuncNormal );
        AppMain.gm_ring_sys_work.col_func = new AppMain._ring_work_func_delegate_( AppMain.gmRingMoveCollsion );
        AppMain.gm_ring_sys_work.ref_spd_base = 8192;
        AppMain.gm_ring_sys_work.ring_draw_func = new AppMain._ring_work_func_delegate_( AppMain.gmRingDrawFuncRing3D );
        AppMain.gm_ring_sys_work.se_wait = 0;
        AppMain.gm_ring_sys_work.color = uint.MaxValue;
        if ( AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 3 )
        {
            AppMain.gm_ring_sys_work.color = 4292927743U;
        }
        else if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
        {
            AppMain.gm_ring_sys_work.color = 3233857791U;
        }
        AppMain.gm_ring_sys_work.dir = 49152;
        AppMain.ObjDrawAction3dActionSet3DNNMaterial( AppMain.gm_ring_obj_3d, 0 );
    }

    // Token: 0x06000D96 RID: 3478 RVA: 0x00076CF4 File Offset: 0x00074EF4
    private static void gmRingMain( AppMain.MTS_TASK_TCB tcb )
    {
        if ( ( AppMain.gm_ring_sys_work.flag & 1U ) != 0U )
        {
            AppMain.gm_ring_sys_work.ring_se_cnt = 0;
            return;
        }
        if ( AppMain.g_obj.glb_camera_id >= 0 )
        {
            AppMain.ObjDraw3DNNSetCamera( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type );
        }
        if ( AppMain.gm_ring_sys_work.se_wait > 0 )
        {
            AppMain.gm_ring_sys_work.se_wait--;
        }
        AppMain.gmRingDrawBegin();
        AppMain.GMS_RING_WORK gms_RING_WORK;
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            gms_RING_WORK = AppMain.gm_ring_sys_work.ring_list_start;
            while ( gms_RING_WORK != null )
            {
                AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
                gms_RING_WORK = gms_RING_WORK2.post_ring;
                AppMain.gm_ring_sys_work.ring_draw_func( gms_RING_WORK2 );
            }
            gms_RING_WORK = AppMain.gm_ring_sys_work.damage_ring_list_start;
            while ( gms_RING_WORK != null )
            {
                AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
                gms_RING_WORK = gms_RING_WORK2.post_ring;
                if ( gms_RING_WORK2.timer > 32 || ( gms_RING_WORK2.timer & 2 ) != 0 )
                {
                    AppMain.gm_ring_sys_work.ring_draw_func( gms_RING_WORK2 );
                }
            }
            gms_RING_WORK = AppMain.gm_ring_sys_work.slot_ring_list_start;
            while ( gms_RING_WORK != null )
            {
                AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
                gms_RING_WORK = gms_RING_WORK2.post_ring;
                AppMain.gm_ring_sys_work.ring_draw_func( gms_RING_WORK2 );
            }
            AppMain.gmRingDrawEnd();
            AppMain.gm_ring_sys_work.ring_se_cnt = 0;
            return;
        }
        for ( int i = 0; i < ( int )AppMain.gm_ring_sys_work.player_num; i++ )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[i];
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_PLAYER_WORK.rect_work[2];
            AppMain.ply_rect[i].pos.x = gms_PLAYER_WORK.obj_work.pos.x;
            AppMain.ply_rect[i].pos.y = gms_PLAYER_WORK.obj_work.pos.y;
            AppMain.ply_rect[i].pos.z = gms_PLAYER_WORK.obj_work.pos.z;
            short num;
            short num2;
            if ( ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) ^ ( obs_RECT_WORK.flag & 1U ) ) != 0U )
            {
                num = ( short )-obs_RECT_WORK.rect.right;
                num2 = ( short )-obs_RECT_WORK.rect.left;
            }
            else
            {
                num = obs_RECT_WORK.rect.left;
                num2 = obs_RECT_WORK.rect.right;
            }
            if ( gms_PLAYER_WORK.obj_work.scale.x != 4096 )
            {
                num = ( short )AppMain.FX_Mul( ( int )num, gms_PLAYER_WORK.obj_work.scale.x );
                num2 = ( short )AppMain.FX_Mul( ( int )num2, gms_PLAYER_WORK.obj_work.scale.x );
            }
            AppMain.ply_rect[i].left = num;
            AppMain.ply_rect[i].right = num2;
            if ( ( ( gms_PLAYER_WORK.obj_work.disp_flag & 2U ) ^ ( obs_RECT_WORK.flag & 2U ) ) != 0U )
            {
                num = ( short )-obs_RECT_WORK.rect.bottom;
                num2 = ( short )-obs_RECT_WORK.rect.top;
            }
            else
            {
                num = obs_RECT_WORK.rect.top;
                num2 = obs_RECT_WORK.rect.bottom;
            }
            if ( gms_PLAYER_WORK.obj_work.scale.y != 4096 )
            {
                num = ( short )AppMain.FX_Mul( ( int )num, gms_PLAYER_WORK.obj_work.scale.y );
                num2 = ( short )AppMain.FX_Mul( ( int )num2, gms_PLAYER_WORK.obj_work.scale.y );
            }
            AppMain.ply_rect[i].top = num;
            AppMain.ply_rect[i].bottom = num2;
            AppMain.ply_rect[i].back = 0;
            AppMain.ply_rect[i].front = 0;
        }
        AppMain.ring_rect.left = -9;
        AppMain.ring_rect.top = -9;
        AppMain.ring_rect.right = 9;
        AppMain.ring_rect.bottom = 9;
        AppMain.ring_rect.back = -8;
        AppMain.ring_rect.front = 8;
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.gm_ring_sys_work;
        if ( ( gms_RING_SYS_WORK.draw_ring_uv_frame += 1 ) >= 64 )
        {
            AppMain.gm_ring_sys_work.draw_ring_uv_frame = 0;
        }
        if ( ( AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].player_flag & 262144U ) != 0U )
        {
            AppMain.gm_ring_fall_acc_x = ( short )AppMain.FX_Mul( -288, AppMain.mtMathSin( ( int )AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work.dir_fall ) );
            AppMain.gm_ring_fall_acc_y = ( short )AppMain.FX_Mul( 288, AppMain.mtMathCos( ( int )AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].obj_work.dir_fall ) );
        }
        if ( AppMain.gm_ring_sys_work.wait_slot_ring_num != 0 )
        {
            AppMain.gm_ring_sys_work.slot_ring_timer--;
            if ( AppMain.gm_ring_sys_work.slot_ring_timer <= 0 )
            {
                if ( AppMain.gm_ring_sys_work.wait_slot_ring_num >= 2 )
                {
                    AppMain.GmRingCreateSlotRing( AppMain.gm_ring_sys_work.slot_target_obj, 1048576, AppMain.gm_ring_sys_work.slot_ring_create_dir );
                    AppMain.GmRingCreateSlotRing( AppMain.gm_ring_sys_work.slot_target_obj, 1048576, ( ushort )( AppMain.gm_ring_sys_work.slot_ring_create_dir + 32768 - 2048 ) );
                    AppMain.gm_ring_sys_work.wait_slot_ring_num -= 2;
                }
                else
                {
                    AppMain.GmRingCreateSlotRing( AppMain.gm_ring_sys_work.slot_target_obj, 1048576, AppMain.gm_ring_sys_work.slot_ring_create_dir );
                    AppMain.gm_ring_sys_work.wait_slot_ring_num--;
                }
                AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK2 = AppMain.gm_ring_sys_work;
                gms_RING_SYS_WORK2.slot_ring_create_dir -= 2048;
                AppMain.gm_ring_sys_work.slot_ring_timer = 4;
            }
        }
        gms_RING_WORK = AppMain.gm_ring_sys_work.ring_list_start;
        while ( gms_RING_WORK != null )
        {
            AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
            gms_RING_WORK = gms_RING_WORK2.post_ring;
            if ( AppMain.ObjViewOutCheck( gms_RING_WORK2.pos.x, gms_RING_WORK2.pos.y, AppMain.gm_ring_die_offset, 0, 0, 0, 0 ) != 0 )
            {
                if ( gms_RING_WORK2.eve_rec != null )
                {
                    gms_RING_WORK2.eve_rec.pos_x = ( byte )( gms_RING_WORK2.pos.x >> 12 & 255 );
                }
                AppMain.gmRingDetachRingList( gms_RING_WORK2 );
                AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
            }
            else
            {
                AppMain.gm_ring_sys_work.ring_draw_func( gms_RING_WORK2 );
                AppMain.ring_rect.pos.z = 0;
                int i = 0;
                int num3 = 0;
                while ( i < ( int )AppMain.gm_ring_sys_work.player_num )
                {
                    AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[i];
                    if ( ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U )
                    {
                        AppMain.ring_rect.pos.x = gms_RING_WORK2.pos.x;
                        AppMain.ring_rect.pos.y = gms_RING_WORK2.pos.y;
                        if ( AppMain.gm_ring_sys_work.rec_func( AppMain.ply_rect[i], AppMain.ring_rect ) != 0 )
                        {
                            num3 = 1;
                            AppMain.GmPlayerRingGet( gms_PLAYER_WORK, 1 );
                            AppMain.GmComEfctCreateRing( AppMain.ring_rect.pos.x, AppMain.ring_rect.pos.y );
                        }
                    }
                    i++;
                }
                if ( num3 != 0 )
                {
                    gms_RING_WORK2.timer = 0;
                    AppMain.gmRingDetachRingList( gms_RING_WORK2 );
                    AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
                }
            }
        }
        gms_RING_WORK = AppMain.gm_ring_sys_work.damage_ring_list_start;
        while ( gms_RING_WORK != null )
        {
            AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
            gms_RING_WORK = gms_RING_WORK2.post_ring;
            if ( AppMain.ObjViewOutCheck( gms_RING_WORK2.pos.x, gms_RING_WORK2.pos.y, 196, 0, 0, 0, 0 ) != 0 )
            {
                AppMain.gmRingDetachDamageRingList( gms_RING_WORK2 );
                AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
            }
            else
            {
                AppMain.GMS_RING_WORK gms_RING_WORK3 = gms_RING_WORK2;
                gms_RING_WORK3.pos.x = gms_RING_WORK3.pos.x + gms_RING_WORK2.spd_x;
                if ( ( gms_RING_WORK2.flag & 4 ) != 0 )
                {
                    AppMain.GMS_RING_WORK gms_RING_WORK4 = gms_RING_WORK2;
                    gms_RING_WORK4.pos.y = gms_RING_WORK4.pos.y - gms_RING_WORK2.spd_y;
                }
                else
                {
                    AppMain.GMS_RING_WORK gms_RING_WORK5 = gms_RING_WORK2;
                    gms_RING_WORK5.pos.y = gms_RING_WORK5.pos.y + gms_RING_WORK2.spd_y;
                }
                gms_RING_WORK2.spd_x += ( int )AppMain.gm_ring_fall_acc_x;
                gms_RING_WORK2.spd_y += ( int )AppMain.gm_ring_fall_acc_y;
                AppMain.gm_ring_sys_work.col_func( gms_RING_WORK2 );
                AppMain.GMS_RING_WORK gms_RING_WORK6 = gms_RING_WORK2;
                gms_RING_WORK6.timer -= 1;
                if ( gms_RING_WORK2.timer == 0 )
                {
                    AppMain.gmRingDetachDamageRingList( gms_RING_WORK2 );
                    AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
                }
                else
                {
                    if ( gms_RING_WORK2.timer <= 216 )
                    {
                        AppMain.ring_rect.pos.z = 0;
                        int i = 0;
                        int num3 = 0;
                        while ( i < ( int )AppMain.gm_ring_sys_work.player_num )
                        {
                            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[i];
                            if ( ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U )
                            {
                                AppMain.ring_rect.pos.x = gms_RING_WORK2.pos.x;
                                AppMain.ring_rect.pos.y = gms_RING_WORK2.pos.y;
                                if ( AppMain.gm_ring_sys_work.rec_func( AppMain.ply_rect[i], AppMain.ring_rect ) != 0 )
                                {
                                    num3 = 1;
                                    short ring_stage_num = gms_PLAYER_WORK.ring_stage_num;
                                    AppMain.GmPlayerRingGet( gms_PLAYER_WORK, 1 );
                                    if ( ring_stage_num < 999 )
                                    {
                                        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK2 = gms_PLAYER_WORK;
                                        gms_PLAYER_WORK2.ring_stage_num -= 1;
                                    }
                                    AppMain.GmComEfctCreateRing( AppMain.ring_rect.pos.x, AppMain.ring_rect.pos.y );
                                    if ( ( AppMain.gm_ring_sys_work.flag & 16777216U << i ) != 0U )
                                    {
                                        AppMain.gm_ring_sys_work.flag &= ~( 16777216U << i );
                                    }
                                }
                            }
                            i++;
                        }
                        if ( num3 != 0 )
                        {
                            gms_RING_WORK2.timer = 0;
                            AppMain.gmRingDetachDamageRingList( gms_RING_WORK2 );
                            AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
                        }
                    }
                    if ( gms_RING_WORK2.timer > 32 || ( gms_RING_WORK2.timer & 2 ) != 0 )
                    {
                        AppMain.gm_ring_sys_work.ring_draw_func( gms_RING_WORK2 );
                    }
                }
            }
        }
        if ( AppMain.gm_ring_sys_work.damage_ring_list_start == null )
        {
            for ( int i = 0; i < ( int )AppMain.gm_ring_sys_work.player_num; i++ )
            {
                if ( ( AppMain.gm_ring_sys_work.flag & 16777216U << i ) != 0U )
                {
                    AppMain.gm_ring_sys_work.damage_num[i] = 0;
                    AppMain.gm_ring_sys_work.flag &= ~( 16777216U << i );
                }
            }
        }
        gms_RING_WORK = AppMain.gm_ring_sys_work.slot_ring_list_start;
        while ( gms_RING_WORK != null )
        {
            AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
            gms_RING_WORK = gms_RING_WORK2.post_ring;
            if ( AppMain.ObjViewOutCheck( gms_RING_WORK2.pos.x, gms_RING_WORK2.pos.y, 512, 0, 0, 0, 0 ) != 0 )
            {
                AppMain.gmRingDetachSlotRingList( gms_RING_WORK2 );
                AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
            }
            else
            {
                AppMain.GMS_RING_WORK gms_RING_WORK7 = gms_RING_WORK2;
                gms_RING_WORK7.pos.x = gms_RING_WORK7.pos.x + gms_RING_WORK2.spd_x;
                AppMain.GMS_RING_WORK gms_RING_WORK8 = gms_RING_WORK2;
                gms_RING_WORK8.pos.y = gms_RING_WORK8.pos.y + gms_RING_WORK2.spd_y;
                AppMain.gm_ring_sys_work.ring_draw_func( gms_RING_WORK2 );
                AppMain.ring_rect.pos.z = 0;
                int i = 0;
                int num3 = 0;
                while ( i < ( int )AppMain.gm_ring_sys_work.player_num )
                {
                    AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[i];
                    if ( ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U )
                    {
                        AppMain.ring_rect.pos.x = gms_RING_WORK2.pos.x;
                        AppMain.ring_rect.pos.y = gms_RING_WORK2.pos.y;
                        if ( AppMain.gm_ring_sys_work.rec_func( AppMain.ply_rect[i], AppMain.ring_rect ) != 0 )
                        {
                            num3 = 1;
                            AppMain.GmPlayerRingGet( gms_PLAYER_WORK, 1 );
                            AppMain.GmComEfctCreateRing( AppMain.ring_rect.pos.x, AppMain.ring_rect.pos.y );
                        }
                    }
                    i++;
                }
                if ( num3 != 0 )
                {
                    gms_RING_WORK2.timer = 0;
                    AppMain.gmRingDetachSlotRingList( gms_RING_WORK2 );
                    AppMain.gmRingFreeRingWork( gms_RING_WORK2 );
                }
            }
        }
        AppMain.gmRingDrawEnd();
        AppMain.gm_ring_sys_work.ring_se_cnt = 0;
    }

    // Token: 0x06000D97 RID: 3479 RVA: 0x000777DC File Offset: 0x000759DC
    private static void gmRingFreeRingWork( AppMain.GMS_RING_WORK ring_work )
    {
        AppMain.gm_ring_sys_work.ring_list_cnt--;
        AppMain.gm_ring_sys_work.ring_list[AppMain.gm_ring_sys_work.ring_list_cnt] = ring_work;
    }

    // Token: 0x06000D98 RID: 3480 RVA: 0x00077806 File Offset: 0x00075A06
    private static ushort gmRingHitFuncNormal( AppMain.OBS_RECT ply_rect, AppMain.OBS_RECT ring_rect )
    {
        return AppMain.ObjRectCheck( ply_rect, ring_rect );
    }

    // Token: 0x06000D99 RID: 3481 RVA: 0x0007780F File Offset: 0x00075A0F
    private static void gmRingDrawBegin()
    {
        AppMain.gm_ring_sys_work.draw_ring_count = 0;
    }

    // Token: 0x06000D9A RID: 3482 RVA: 0x0007781C File Offset: 0x00075A1C
    private static void gmRingDrawEnd()
    {
        if ( AppMain.gm_ring_sys_work.draw_ring_count <= 0 )
        {
            return;
        }
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.VecU16 vecU = default(AppMain.VecU16);
        vecU.x = 0;
        vecU.y = AppMain.gm_ring_sys_work.dir;
        vecU.z = AppMain.GmMainGetObjectRotation();
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.gm_ring_sys_work;
        uint draw_ring_count = (uint)AppMain.gm_ring_sys_work.draw_ring_count;
        AppMain.SNNS_VECTOR snns_VECTOR;
        AppMain.ObjCameraDispPosGet( 0, out snns_VECTOR );
        float num;
        float num2;
        AppMain.nnSinCos( ( int )vecU.z + -8192, out num, out num2 );
        num *= 13.576385f;
        num2 *= 13.576385f;
        float num3;
        float num4;
        AppMain.nnSinCos( ( int )vecU.z + -24576, out num3, out num4 );
        num3 *= 13.576385f;
        num4 *= 13.576385f;
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(gms_RING_SYS_WORK.draw_ring_pos[0]);
        AppMain.SNNS_MATRIX snns_MATRIX = default(AppMain.SNNS_MATRIX);
        AppMain.nnMakeUnitMatrix( ref snns_MATRIX );
        AppMain.nnTranslateMatrix( ref snns_MATRIX, ref snns_MATRIX, AppMain.FX_FX32_TO_F32( vecFx.x ), -AppMain.FX_FX32_TO_F32( vecFx.y ), AppMain.FX_FX32_TO_F32( vecFx.z ) );
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.type = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.count = ( int )( 6U * draw_ring_count - 2U );
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.ablend = 0;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldSrc = 768;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldDst = 774;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.aTest = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.zMask = 0;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.zTest = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.noSort = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.texlist = AppMain.gm_ring_obj_3d.texlist;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.texId = 0;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.uwrap = 1;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.vwrap = 1;
        uint color = AppMain.gm_ring_sys_work.color;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( AppMain._AMS_PARAM_DRAW_PRIMITIVE.count );
        AppMain.NNS_PRIM3D_PCT[] buffer = AppMain._AMS_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
        int offset = AppMain._AMS_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.format3D = 4;
        int num5 = 0;
        while ( ( long )num5 < ( long )( ( ulong )draw_ring_count ) )
        {
            int num6 = offset + 6 * num5;
            ushort num7 = (ushort)(AppMain.gm_ring_sys_work.draw_ring_uv_frame / 4);
            buffer[num6].Tex.u = ( buffer[num6 + 1].Tex.u = AppMain.gm_ring_roll_uv[0][( int )num7] );
            buffer[num6 + 2].Tex.u = ( buffer[num6 + 3].Tex.u = AppMain.gm_ring_roll_uv[0][( int )num7] + 0.25f );
            buffer[num6].Tex.v = ( buffer[num6 + 2].Tex.v = AppMain.gm_ring_roll_uv[1][( int )num7] );
            buffer[num6 + 1].Tex.v = ( buffer[num6 + 3].Tex.v = AppMain.gm_ring_roll_uv[1][( int )num7] + 0.25f );
            buffer[num6].Col = color;
            buffer[num6 + 1].Col = ( buffer[num6 + 2].Col = ( buffer[num6 + 3].Col = buffer[num6].Col ) );
            buffer[num6].Pos.x = num + AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].x - vecFx.x );
            buffer[num6 + 1].Pos.x = num3 + AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].x - vecFx.x );
            buffer[num6 + 2].Pos.x = -num3 + AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].x - vecFx.x );
            buffer[num6 + 3].Pos.x = -num + AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].x - vecFx.x );
            buffer[num6].Pos.y = num2 - AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].y - vecFx.y );
            buffer[num6 + 1].Pos.y = num4 - AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].y - vecFx.y );
            buffer[num6 + 2].Pos.y = -num4 - AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].y - vecFx.y );
            buffer[num6 + 3].Pos.y = -num2 - AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].y - vecFx.y );
            buffer[num6].Pos.z = ( buffer[num6 + 1].Pos.z = ( buffer[num6 + 2].Pos.z = ( buffer[num6 + 3].Pos.z = -1f + AppMain.FX_FX32_TO_F32( gms_RING_SYS_WORK.draw_ring_pos[num5].z - vecFx.z ) ) ) );
            if ( num5 != 0 )
            {
                buffer[num6 - 1] = buffer[num6];
            }
            if ( ( long )( num5 + 1 ) < ( long )( ( ulong )draw_ring_count ) )
            {
                buffer[num6 + 4] = buffer[num6 + 3];
            }
            num5++;
        }
        AppMain._AMS_PARAM_DRAW_PRIMITIVE.sortZ = AppMain.nnDistanceVector( ref buffer[offset].Pos, ref snns_VECTOR );
        AppMain.amMatrixPush( ref snns_MATRIX );
        AppMain.ObjDraw3DNNDrawPrimitive( AppMain._AMS_PARAM_DRAW_PRIMITIVE );
        AppMain.amMatrixPop();
    }

    // Token: 0x06000D9B RID: 3483 RVA: 0x00077E68 File Offset: 0x00076068
    private static void gmRingDest( AppMain.MTS_TASK_TCB tcb )
    {
        for ( AppMain.GMS_RING_WORK gms_RING_WORK = AppMain.gm_ring_sys_work.ring_list_start; gms_RING_WORK != null; gms_RING_WORK = gms_RING_WORK.post_ring )
        {
            if ( gms_RING_WORK.eve_rec != null )
            {
                gms_RING_WORK.eve_rec.pos_x = ( byte )( gms_RING_WORK.pos.x >> 12 & 255 );
            }
        }
        for ( int i = 0; i < 2; i++ )
        {
            if ( AppMain.gm_ring_sys_work.h_snd_ring[i] != null )
            {
                AppMain.GmSoundStopSE( AppMain.gm_ring_sys_work.h_snd_ring[i] );
                AppMain.GsSoundFreeSeHandle( AppMain.gm_ring_sys_work.h_snd_ring[i] );
                AppMain.gm_ring_sys_work.h_snd_ring[i] = null;
            }
        }
        AppMain.gm_ring_tcb = null;
        AppMain.gm_ring_sys_work = null;
    }

    // Token: 0x06000D9C RID: 3484 RVA: 0x00077F0C File Offset: 0x0007610C
    private static void gmRingMoveCollsion( AppMain.GMS_RING_WORK ring_work )
    {
        int num = 0;
        int num2 = ring_work.spd_y;
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        if ( ( ring_work.flag & 4 ) != 0 )
        {
            num2 = -num2;
        }
        if ( ( ring_work.flag & 2 ) != 0 )
        {
            obs_COL_CHK_DATA.flag = 1;
        }
        else
        {
            obs_COL_CHK_DATA.flag = 0;
        }
        obs_COL_CHK_DATA.dir = null;
        obs_COL_CHK_DATA.attr = null;
        obs_COL_CHK_DATA.pos_x = ring_work.pos.x >> 12;
        obs_COL_CHK_DATA.pos_y = ring_work.pos.y >> 12;
        if ( ring_work.spd_y > 0 )
        {
            obs_COL_CHK_DATA.pos_y += 9;
            obs_COL_CHK_DATA.vec = 2;
            num = AppMain.ObjDiffCollisionFast( obs_COL_CHK_DATA );
            if ( num < 0 )
            {
                if ( ( ring_work.flag & 4 ) != 0 )
                {
                    ring_work.pos.y = ring_work.pos.y - ( num << 12 );
                }
                else
                {
                    ring_work.pos.y = ring_work.pos.y + ( num << 12 );
                }
            }
        }
        else if ( ring_work.spd_y < 0 )
        {
            obs_COL_CHK_DATA.pos_y += -9;
            obs_COL_CHK_DATA.vec = 3;
            num = AppMain.ObjDiffCollisionFast( obs_COL_CHK_DATA );
            if ( num < 0 )
            {
                if ( ( ring_work.flag & 4 ) != 0 )
                {
                    ring_work.pos.y = ring_work.pos.y + ( num << 12 );
                }
                else
                {
                    ring_work.pos.y = ring_work.pos.y - ( num << 12 );
                }
            }
        }
        if ( num < 0 )
        {
            ring_work.spd_y -= ring_work.spd_y >> 2;
            ring_work.spd_y = -ring_work.spd_y;
        }
        num = 0;
        obs_COL_CHK_DATA.pos_y = ring_work.pos.y >> 12;
        if ( ring_work.spd_x > 0 )
        {
            obs_COL_CHK_DATA.pos_x += 9;
            obs_COL_CHK_DATA.vec = 0;
            num = AppMain.ObjDiffCollisionFast( obs_COL_CHK_DATA );
            if ( num < 0 )
            {
                ring_work.pos.x = ring_work.pos.x + ( num << 12 );
            }
        }
        else if ( ring_work.spd_x < 0 )
        {
            obs_COL_CHK_DATA.pos_x += -9;
            obs_COL_CHK_DATA.vec = 1;
            num = AppMain.ObjDiffCollisionFast( obs_COL_CHK_DATA );
            if ( num < 0 )
            {
                ring_work.pos.x = ring_work.pos.x - ( num << 12 );
            }
        }
        if ( num < 0 )
        {
            ring_work.spd_x -= ring_work.spd_x >> 2;
            ring_work.spd_x = -ring_work.spd_x;
        }
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
    }

    // Token: 0x06000D9D RID: 3485 RVA: 0x00078138 File Offset: 0x00076338
    private static void gmRingDetachSlotRingList( AppMain.GMS_RING_WORK ring_work )
    {
        if ( ring_work.pre_ring == null )
        {
            AppMain.gm_ring_sys_work.slot_ring_list_start = ring_work.post_ring;
        }
        else
        {
            ring_work.pre_ring.post_ring = ring_work.post_ring;
        }
        if ( ring_work.post_ring == null )
        {
            AppMain.gm_ring_sys_work.slot_ring_list_end = ring_work.pre_ring;
            return;
        }
        ring_work.post_ring.pre_ring = ring_work.pre_ring;
    }

    // Token: 0x06000D9E RID: 3486 RVA: 0x0007819C File Offset: 0x0007639C
    private static void gmRingDetachRingList( AppMain.GMS_RING_WORK ring_work )
    {
        if ( ring_work.pre_ring == null )
        {
            AppMain.gm_ring_sys_work.ring_list_start = ring_work.post_ring;
        }
        else
        {
            ring_work.pre_ring.post_ring = ring_work.post_ring;
        }
        if ( ring_work.post_ring == null )
        {
            AppMain.gm_ring_sys_work.ring_list_end = ring_work.pre_ring;
            return;
        }
        ring_work.post_ring.pre_ring = ring_work.pre_ring;
    }

    // Token: 0x06000D9F RID: 3487 RVA: 0x00078200 File Offset: 0x00076400
    private static AppMain.GMS_RING_WORK GmRingCreateSlotRing( AppMain.OBS_OBJECT_WORK target_obj, int dist, ushort dir )
    {
        if ( AppMain.gm_ring_sys_work == null )
        {
            return null;
        }
        AppMain.GMS_RING_WORK gms_RING_WORK = AppMain.gmRingAllocRingWork();
        if ( gms_RING_WORK == null )
        {
            return null;
        }
        gms_RING_WORK.pos.x = target_obj.pos.x + AppMain.FX_Mul( dist, AppMain.mtMathCos( ( int )dir ) );
        gms_RING_WORK.pos.y = target_obj.pos.y + AppMain.FX_Mul( -dist, AppMain.mtMathSin( ( int )dir ) );
        gms_RING_WORK.pos.z = target_obj.pos.z;
        gms_RING_WORK.spd_x = AppMain.FX_Mul( 24576, AppMain.mtMathCos( ( int )( dir + 32768 ) ) );
        gms_RING_WORK.spd_y = AppMain.FX_Mul( -24576, AppMain.mtMathSin( ( int )( dir + 32768 ) ) );
        gms_RING_WORK.scale.x = ( gms_RING_WORK.scale.y = ( gms_RING_WORK.scale.z = 4096 ) );
        gms_RING_WORK.timer = 0;
        gms_RING_WORK.flag = 0;
        gms_RING_WORK.eve_rec = null;
        gms_RING_WORK.duct_obj = null;
        AppMain.gmRingAttachSlotRingList( gms_RING_WORK );
        return gms_RING_WORK;
    }

    // Token: 0x06000DA0 RID: 3488 RVA: 0x00078308 File Offset: 0x00076508
    private static void gmRingDetachDamageRingList( AppMain.GMS_RING_WORK ring_work )
    {
        if ( ring_work.pre_ring == null )
        {
            AppMain.gm_ring_sys_work.damage_ring_list_start = ring_work.post_ring;
        }
        else
        {
            ring_work.pre_ring.post_ring = ring_work.post_ring;
        }
        if ( ring_work.post_ring == null )
        {
            AppMain.gm_ring_sys_work.damage_ring_list_end = ring_work.pre_ring;
            return;
        }
        ring_work.post_ring.pre_ring = ring_work.pre_ring;
    }

    // Token: 0x06000DA1 RID: 3489 RVA: 0x0007836C File Offset: 0x0007656C
    private static void gmRingAttachSlotRingList( AppMain.GMS_RING_WORK ring_work )
    {
        if ( AppMain.gm_ring_sys_work.slot_ring_list_end != null )
        {
            AppMain.gm_ring_sys_work.slot_ring_list_end.post_ring = ring_work;
            ring_work.pre_ring = AppMain.gm_ring_sys_work.slot_ring_list_end;
            ring_work.post_ring = null;
            AppMain.gm_ring_sys_work.slot_ring_list_end = ring_work;
            return;
        }
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.gm_ring_sys_work;
        AppMain.gm_ring_sys_work.slot_ring_list_end = ring_work;
        gms_RING_SYS_WORK.slot_ring_list_start = ring_work;
        ring_work.pre_ring = ( ring_work.post_ring = null );
    }

    // Token: 0x06000DA2 RID: 3490 RVA: 0x000783E0 File Offset: 0x000765E0
    private static void gmRingDrawFuncRing3D( AppMain.GMS_RING_WORK ring_work )
    {
        AppMain.VecU16 vecU = default(AppMain.VecU16);
        vecU.x = 0;
        vecU.y = AppMain.gm_ring_sys_work.dir;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        vecU.z = ( ushort )( -( ushort )obs_CAMERA.roll );
        int draw_ring_count = (int)AppMain.gm_ring_sys_work.draw_ring_count;
        AppMain.gm_ring_sys_work.draw_ring_pos[draw_ring_count].x = ring_work.pos.x;
        AppMain.gm_ring_sys_work.draw_ring_pos[draw_ring_count].y = ring_work.pos.y;
        AppMain.gm_ring_sys_work.draw_ring_pos[draw_ring_count].z = ring_work.pos.z;
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.gm_ring_sys_work;
        gms_RING_SYS_WORK.draw_ring_count += 1;
    }

    // Token: 0x06000DA3 RID: 3491 RVA: 0x000784AC File Offset: 0x000766AC
    private static void GmRingGetSE()
    {
        bool flag = true;
        if ( AppMain.gm_ring_sys_work.ring_se_cnt >= 1 )
        {
            return;
        }
        if ( AppMain.gm_ring_sys_work.se_wait > 0 )
        {
            return;
        }
        if ( AppMain.gm_ring_sys_work != null )
        {
            if ( ( AppMain.gm_ring_sys_work.flag & 8U ) != 0U )
            {
                flag = false;
            }
            AppMain.gm_ring_sys_work.flag ^= 8U;
            AppMain.gm_ring_sys_work.se_wait = 3;
        }
        if ( flag )
        {
            AppMain.GmSoundPlaySE( "Ring1L", AppMain.gm_ring_sys_work.h_snd_ring[0] );
        }
        else
        {
            AppMain.GmSoundPlaySE( "Ring1R", AppMain.gm_ring_sys_work.h_snd_ring[1] );
        }
        AppMain.gm_ring_sys_work.ring_se_cnt++;
    }

    // Token: 0x06000DA4 RID: 3492 RVA: 0x0007854E File Offset: 0x0007674E
    private static void GmRingDamageSet( AppMain.GMS_PLAYER_WORK ply_obj )
    {
        AppMain.GmRingDamageSetNum( ply_obj, ply_obj.ring_num );
    }

    // Token: 0x06000DA5 RID: 3493 RVA: 0x0007855C File Offset: 0x0007675C
    private static void GmRingDamageSetNum( AppMain.GMS_PLAYER_WORK ply_work, short ring_num )
    {
        int num = 0;
        int num2 = 0;
        int num3 = 1160;
        byte player_id = ply_work.player_id;
        ushort num4 = (ushort)(8 | ((int)player_id << 4 & 16));
        if ( AppMain.gm_ring_sys_work == null )
        {
            return;
        }
        if ( ring_num > ply_work.ring_num )
        {
            ring_num = ply_work.ring_num;
        }
        else if ( ring_num < 0 )
        {
            AppMain.mppAssertNotImpl();
            return;
        }
        ply_work.ring_num -= ring_num;
        if ( ring_num > 32 )
        {
            ring_num = 32;
        }
        AppMain.gm_ring_sys_work.flag |= 16777216U << ( int )player_id;
        if ( ( ply_work.obj_work.flag & 1U ) != 0U )
        {
            num4 |= 2;
        }
        num3 += ( int )AppMain.gm_ring_sys_work.damage_num[( int )player_id] << 8;
        ushort dir_fall = ply_work.obj_work.dir_fall;
        for ( int i = 0; i < ( int )ring_num; i++ )
        {
            if ( num3 >= 0 )
            {
                int num5 = num3 >> 8;
                num5 = ( ( num5 >= 6 ) ? ( -num5 + 9 ) : num5 );
                num = AppMain.mtMathSin( ( int )( ( ushort )( ( num3 + ( int )dir_fall & 255 ) << 8 ) ) ) << 4 >> num5;
                num2 = AppMain.mtMathCos( ( int )( ( ushort )( ( num3 + ( int )dir_fall & 255 ) << 8 ) ) ) << 4 >> num5;
                num -= num >> 2;
                num2 -= num2 >> 2;
                num3 += 16;
                num3 |= 128;
            }
            if ( AppMain.GmRingCreateDamageRing( ply_work.obj_work.pos.x, ply_work.obj_work.pos.y, 0, num, num2, num4 ) == null )
            {
                break;
            }
            num3 = -num3;
            num = -num;
        }
        if ( AppMain.gm_ring_sys_work.damage_num[( int )player_id] < AppMain.gm_ring_damege_num_tbl[AppMain.g_gs_main_sys_info.level] )
        {
            byte[] damage_num = AppMain.gm_ring_sys_work.damage_num;
            byte b = player_id;
            damage_num[( int )b] = ( byte )( damage_num[( int )b] + 1 );
        }
    }

    // Token: 0x06000DA6 RID: 3494 RVA: 0x00078708 File Offset: 0x00076908
    private static AppMain.GMS_RING_WORK GmRingCreateDamageRing( int pos_x, int pos_y, int pos_z, int spd_x, int spd_y, ushort flag )
    {
        if ( AppMain.gm_ring_sys_work == null )
        {
            return null;
        }
        AppMain.GMS_RING_WORK gms_RING_WORK = AppMain.gmRingAllocRingWork();
        if ( gms_RING_WORK == null )
        {
            return null;
        }
        gms_RING_WORK.pos.x = pos_x;
        gms_RING_WORK.pos.y = pos_y;
        gms_RING_WORK.pos.z = pos_z;
        gms_RING_WORK.spd_x = spd_x;
        gms_RING_WORK.spd_y = spd_y;
        gms_RING_WORK.scale.x = ( gms_RING_WORK.scale.y = ( gms_RING_WORK.scale.z = 4096 ) );
        gms_RING_WORK.timer = ( short )( 256 + ( AppMain.mtMathRand() & 31 ) );
        gms_RING_WORK.flag = flag;
        gms_RING_WORK.eve_rec = null;
        gms_RING_WORK.duct_obj = null;
        AppMain.gmRingAttachDamageRingList( gms_RING_WORK );
        return gms_RING_WORK;
    }

    // Token: 0x06000DA7 RID: 3495 RVA: 0x000787BC File Offset: 0x000769BC
    private static void gmRingAttachDamageRingList( AppMain.GMS_RING_WORK ring_work )
    {
        if ( AppMain.gm_ring_sys_work.damage_ring_list_end != null )
        {
            AppMain.gm_ring_sys_work.damage_ring_list_end.post_ring = ring_work;
            ring_work.pre_ring = AppMain.gm_ring_sys_work.damage_ring_list_end;
            ring_work.post_ring = null;
            AppMain.gm_ring_sys_work.damage_ring_list_end = ring_work;
            return;
        }
        AppMain.GMS_RING_SYS_WORK gms_RING_SYS_WORK = AppMain.gm_ring_sys_work;
        AppMain.gm_ring_sys_work.damage_ring_list_end = ring_work;
        gms_RING_SYS_WORK.damage_ring_list_start = ring_work;
        ring_work.pre_ring = ( ring_work.post_ring = null );
    }

    // Token: 0x06000DA8 RID: 3496 RVA: 0x00078830 File Offset: 0x00076A30
    private static void GmRingSlotSetNum( AppMain.GMS_PLAYER_WORK ply_work, int ring_num )
    {
        if ( AppMain.gm_ring_sys_work == null || ring_num <= 0 )
        {
            return;
        }
        AppMain.gm_ring_sys_work.wait_slot_ring_num = ring_num;
        AppMain.gm_ring_sys_work.slot_ring_create_dir = 0;
        AppMain.gm_ring_sys_work.slot_target_obj = ( AppMain.OBS_OBJECT_WORK )ply_work;
    }

    // Token: 0x06000DA9 RID: 3497 RVA: 0x00078864 File Offset: 0x00076A64
    private static int GmRingCheckRestSlotRing()
    {
        if ( AppMain.gm_ring_sys_work == null )
        {
            return 0;
        }
        if ( AppMain.gm_ring_sys_work.wait_slot_ring_num != 0 || AppMain.gm_ring_sys_work.slot_ring_list_start != null )
        {
            return 1;
        }
        return 0;
    }
}