using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000264 RID: 612
    public class GMS_GMK_SHUTTER_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023EF RID: 9199 RVA: 0x00149E6F File Offset: 0x0014806F
        public GMS_GMK_SHUTTER_WORK()
        {
            this.gimmick_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023F0 RID: 9200 RVA: 0x00149E8E File Offset: 0x0014808E
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_SHUTTER_WORK p )
        {
            return p.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x060023F1 RID: 9201 RVA: 0x00149EA0 File Offset: 0x001480A0
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gimmick_work.ene_com.obj_work;
        }

        // Token: 0x04005906 RID: 22790
        public readonly AppMain.GMS_ENEMY_3D_WORK gimmick_work;

        // Token: 0x04005907 RID: 22791
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d_parts = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04005908 RID: 22792
        public AppMain.GMS_EFFECT_3DES_WORK effect_work;
    }

    // Token: 0x06000FC9 RID: 4041 RVA: 0x00089B2D File Offset: 0x00087D2D
    public static void GmGmkShutterBuild()
    {
        AppMain.g_gm_gmk_shutter_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 938 ), AppMain.GmGameDatGetGimmickData( 939 ), 0U );
    }

    // Token: 0x06000FCA RID: 4042 RVA: 0x00089B50 File Offset: 0x00087D50
    public static void GmGmkShutterFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(938);
        AppMain.GmGameDBuildRegFlushModel( AppMain.g_gm_gmk_shutter_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.g_gm_gmk_shutter_obj_3d_list = null;
    }

    // Token: 0x06000FCB RID: 4043 RVA: 0x00089B80 File Offset: 0x00087D80
    private static AppMain.OBS_OBJECT_WORK GmGmkShutterInInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkShutterLoadObj(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkShutterInInit( obj_work );
        return obj_work;
    }

    // Token: 0x06000FCC RID: 4044 RVA: 0x00089BAC File Offset: 0x00087DAC
    private static AppMain.OBS_OBJECT_WORK GmGmkShutterOutInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkShutterLoadObj(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.gmGmkShutterOutInit( obj_work );
        return obj_work;
    }

    // Token: 0x06000FCD RID: 4045 RVA: 0x00089BD8 File Offset: 0x00087DD8
    private static void GmGmkShutterInChangeModeClose( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.pos.y <= ( int )obj_work.user_work )
        {
            return;
        }
        obj_work.spd.y = -16384;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkShutterInMainClose );
        obj_work.disp_flag &= 4294967263U;
        AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 4 && gms_GMK_SHUTTER_WORK.effect_work == null )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(null, 44);
            obs_OBJECT_WORK.pos.x = obj_work.pos.x + 65536;
            obs_OBJECT_WORK.pos.y = obj_work.pos.y - 131072;
            obs_OBJECT_WORK.pos.z = 393216;
            gms_GMK_SHUTTER_WORK.effect_work = ( AppMain.GMS_EFFECT_3DES_WORK )obs_OBJECT_WORK;
        }
    }

    // Token: 0x06000FCE RID: 4046 RVA: 0x00089CB0 File Offset: 0x00087EB0
    private static void GmGmkShutterOutChangeModeOpen( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.pos.y >= ( int )obj_work.user_work )
        {
            return;
        }
        obj_work.spd.y = 16384;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkShutterOutMainOpen );
        AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 4 && gms_GMK_SHUTTER_WORK.effect_work == null )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(null, 44);
            obs_OBJECT_WORK.pos.x = obj_work.pos.x - 65536;
            obs_OBJECT_WORK.pos.y = obj_work.pos.y + 131072;
            obs_OBJECT_WORK.pos.z = 393216;
            gms_GMK_SHUTTER_WORK.effect_work = ( AppMain.GMS_EFFECT_3DES_WORK )obs_OBJECT_WORK;
        }
    }

    // Token: 0x06000FCF RID: 4047 RVA: 0x00089D80 File Offset: 0x00087F80
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkShutterLoadObjNoModel( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_SHUTTER_WORK(), "GMK_SHUTTER");
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000FD0 RID: 4048 RVA: 0x00089DF4 File Offset: 0x00087FF4
    private static AppMain.GMS_ENEMY_3D_WORK gmGmkShutterLoadObj( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        int num2;
        if ( num == 1 )
        {
            num2 = 0;
        }
        else
        {
            if ( num != 4 )
            {
                return null;
            }
            num2 = 0;
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = AppMain.gmGmkShutterLoadObjNoModel(eve_rec, pos_x, pos_y, type);
        AppMain.OBS_OBJECT_WORK obj_work = gms_ENEMY_3D_WORK.ene_com.obj_work;
        AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.g_gm_gmk_shutter_obj_3d_list[num2], gms_ENEMY_3D_WORK.obj_3d );
        if ( num == 4 )
        {
            AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
            int num3 = 2;
            AppMain.ObjCopyAction3dNNModel( AppMain.g_gm_gmk_shutter_obj_3d_list[num3], gms_GMK_SHUTTER_WORK.obj_3d_parts );
            AppMain.ObjAction3dNNMaterialMotionLoad( gms_GMK_SHUTTER_WORK.obj_3d_parts, 0, null, null, 1, ( AppMain.AMS_AMB_HEADER )AppMain.ObjDataGet( 940 ).pData );
        }
        return gms_ENEMY_3D_WORK;
    }

    // Token: 0x06000FD1 RID: 4049 RVA: 0x00089E98 File Offset: 0x00088098
    private static void gmGmkShutterDestFuncForFinaleZone( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)AppMain.mtTaskGetTcbWork(tcb);
        AppMain.ObjAction3dNNMotionRelease( gms_GMK_SHUTTER_WORK.obj_3d_parts );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000FD2 RID: 4050 RVA: 0x00089EC4 File Offset: 0x000880C4
    private static void gmGmkShutterInInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 64;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 64;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height / 2 );
        obj_work.move_flag |= 256U;
        obj_work.disp_flag |= 4194336U;
        obj_work.flag |= 16U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        obj_work.pos.z = -655360;
        obj_work.user_work = ( uint )( obj_work.pos.y - 262144 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkShutterInMainWaitClose );
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 4 )
        {
            obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkShutterInOutFuncForFinalZone );
            AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkShutterDestFuncForFinaleZone ) );
        }
    }

    // Token: 0x06000FD3 RID: 4051 RVA: 0x0008A044 File Offset: 0x00088244
    private static void gmGmkShutterInOutFuncForFinalZone( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
        obj_work.ofst.x = AppMain.gm_gmk_shutter_disp_offset_for_final_zone[0] * 4096;
        obj_work.ofst.y = AppMain.gm_gmk_shutter_disp_offset_for_final_zone[1] * 4096;
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.VecFx32 pos = obj_work.pos;
        pos.x += obj_work.ofst.x;
        pos.y += obj_work.ofst.y;
        uint num = obj_work.disp_flag | 4U;
        if ( AppMain.ObjObjectPauseCheck( 0U ) == 0U )
        {
            AppMain.ObjDrawAction3DNNMaterialUpdate( gms_GMK_SHUTTER_WORK.obj_3d_parts, ref num );
        }
        AppMain.ObjDrawAction3DNN( gms_GMK_SHUTTER_WORK.obj_3d_parts, new AppMain.VecFx32?( pos ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref num );
    }

    // Token: 0x06000FD4 RID: 4052 RVA: 0x0008A10C File Offset: 0x0008830C
    private static void gmGmkShutterInMainWaitClose( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( obs_OBJECT_WORK.pos.x - obj_work.pos.x < 262144 )
        {
            return;
        }
        AppMain.GmGmkShutterInChangeModeClose( obj_work );
    }

    // Token: 0x06000FD5 RID: 4053 RVA: 0x0008A154 File Offset: 0x00088354
    private static void gmGmkShutterInMainClose( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        int a = (int)((ulong)obj_work.user_work - (ulong)((long)obj_work.pos.y));
        if ( AppMain.MTM_MATH_ABS( obs_OBJECT_WORK.pos.x - obj_work.pos.x ) < 131072 && obs_OBJECT_WORK.pos.y <= obj_work.pos.y && AppMain.MTM_MATH_ABS( a ) < 262144 )
        {
            int num = AppMain.g_gm_main_system.map_fcol.left + (AppMain.g_gm_main_system.map_fcol.right - AppMain.g_gm_main_system.map_fcol.left) / 2;
            if ( ( obs_OBJECT_WORK.move_flag & 1U ) != 0U )
            {
                int num2 = 16384;
                if ( num * 4096 < obs_OBJECT_WORK.pos.x )
                {
                    num2 *= -1;
                }
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.flow.x = obs_OBJECT_WORK2.flow.x + num2;
            }
            else
            {
                int num3 = 4096;
                if ( num * 4096 < obs_OBJECT_WORK.pos.x )
                {
                    num3 *= -1;
                }
                AppMain.GmPlySeqGmkInitGmkJump( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, num3, 0 );
                AppMain.GmPlySeqChangeSequenceState( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, 17 );
            }
        }
        if ( obj_work.pos.y <= ( int )obj_work.user_work )
        {
            obj_work.pos.y = ( int )obj_work.user_work;
            obj_work.spd.y = 0;
            obj_work.ppFunc = null;
            obj_work.ppMove = null;
            AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
            if ( gms_GMK_SHUTTER_WORK.effect_work != null )
            {
                AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_SHUTTER_WORK.effect_work );
                gms_GMK_SHUTTER_WORK.effect_work = null;
            }
        }
    }

    // Token: 0x06000FD6 RID: 4054 RVA: 0x0008A2F0 File Offset: 0x000884F0
    private static void gmGmkShutterOutInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = gms_ENEMY_3D_WORK.ene_com.obj_work;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 64;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 64;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width / 2 );
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )( -gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height / 2 );
        obj_work.move_flag |= 256U;
        obj_work.disp_flag |= 4194304U;
        obj_work.flag |= 16U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        obj_work.pos.z = -655360;
        obj_work.user_work = ( uint )( obj_work.pos.y + 262144 );
        obj_work.ppFunc = null;
        int num = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        if ( num == 4 )
        {
            obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkShutterOutOutFuncForFinalZone );
            AppMain.mtTaskChangeTcbDestructor( obj_work.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkShutterDestFuncForFinaleZone ) );
        }
    }

    // Token: 0x06000FD7 RID: 4055 RVA: 0x0008A464 File Offset: 0x00088664
    private static void gmGmkShutterOutOutFuncForFinalZone( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
        obj_work.ofst.x = -AppMain.gm_gmk_shutter_disp_offset_for_final_zone[0] * 4096;
        obj_work.ofst.y = AppMain.gm_gmk_shutter_disp_offset_for_final_zone[1] * 4096;
        AppMain.ObjDrawActionSummary( obj_work );
        AppMain.VecFx32 pos = obj_work.pos;
        pos.x += obj_work.ofst.x;
        pos.y += obj_work.ofst.y;
        uint num = obj_work.disp_flag | 4U;
        if ( AppMain.ObjObjectPauseCheck( 0U ) == 0U )
        {
            AppMain.ObjDrawAction3DNNMaterialUpdate( gms_GMK_SHUTTER_WORK.obj_3d_parts, ref num );
        }
        AppMain.ObjDrawAction3DNN( gms_GMK_SHUTTER_WORK.obj_3d_parts, new AppMain.VecFx32?( pos ), new AppMain.VecU16?( obj_work.dir ), obj_work.scale, ref num );
    }

    // Token: 0x06000FD8 RID: 4056 RVA: 0x0008A52C File Offset: 0x0008872C
    private static void gmGmkShutterOutMainOpen( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.pos.y >= ( int )obj_work.user_work )
        {
            obj_work.pos.y = ( int )obj_work.user_work;
            obj_work.spd.y = 0;
            obj_work.ppFunc = null;
            obj_work.ppMove = null;
            obj_work.disp_flag |= 32U;
            AppMain.GMS_GMK_SHUTTER_WORK gms_GMK_SHUTTER_WORK = (AppMain.GMS_GMK_SHUTTER_WORK)obj_work;
            if ( gms_GMK_SHUTTER_WORK.effect_work != null )
            {
                AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_SHUTTER_WORK.effect_work );
                gms_GMK_SHUTTER_WORK.effect_work = null;
            }
        }
    }
}