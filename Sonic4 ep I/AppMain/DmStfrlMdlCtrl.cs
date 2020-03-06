using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060005F1 RID: 1521 RVA: 0x00034A47 File Offset: 0x00032C47
    private static void DmStfrlMdlCtrlSonicBuild()
    {
        AppMain.dm_stfrl_sonic_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.readAMBFile( AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][0].pData ), AppMain.readAMBFile( AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][1].pData ), 0U );
    }

    // Token: 0x060005F2 RID: 1522 RVA: 0x00034A7C File Offset: 0x00032C7C
    private static void DmStfrlMdlCtrlSonicFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.g_gm_player_data_work[(int)((UIntPtr)0)][0].pData);
        AppMain.GmGameDBuildRegFlushModel( AppMain.dm_stfrl_sonic_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.dm_stfrl_sonic_obj_3d_list = null;
    }

    // Token: 0x060005F3 RID: 1523 RVA: 0x00034ABC File Offset: 0x00032CBC
    private static AppMain.DMS_STFRL_SONIC_WORK DmStfrlMdlCtrlSetSonicObj()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(24576, 0, 0, 0, () => new AppMain.DMS_STFRL_SONIC_WORK(), "STAFFROLL_SONIC");
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK = (AppMain.DMS_STFRL_SONIC_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.dm_stfrl_sonic_obj_3d_list[0], obs_OBJECT_WORK.obj_3d );
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.0625f;
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = dms_STFRL_SONIC_WORK.obj_work.obj_3d;
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.g_gm_player_data_work[( int )( ( UIntPtr )0 )][4], null, 0, null, 136, 16 );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194309U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.disp_flag |= 150995456U;
        obs_OBJECT_WORK.obj_3d.drawflag |= 8388608U;
        obs_OBJECT_WORK.pos.x = 0;
        obs_OBJECT_WORK.pos.y = 98304;
        obs_OBJECT_WORK.pos.z = -12288;
        obs_OBJECT_WORK.dir.y = ( ushort )AppMain.AKM_DEGtoA16( 90 );
        obs_OBJECT_WORK.obj_3d.draw_state.alpha.alpha = 1f;
        dms_STFRL_SONIC_WORK.alpha = 1f;
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 21 );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlSonicDrawFunc );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlSonicProcWaitSetup );
        return dms_STFRL_SONIC_WORK;
    }

    // Token: 0x060005F4 RID: 1524 RVA: 0x00034C40 File Offset: 0x00032E40
    private static void DmStfrlMdlCtrlBoss1Build()
    {
        AppMain.AMS_AMB_HEADER mdl_amb = AppMain.readAMBFile(AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.g_gm_gamedat_enemy_arc));
        AppMain.AMS_AMB_HEADER tex_amb = AppMain.readAMBFile(AppMain.ObjDataLoadAmbIndex(null, 1, AppMain.g_gm_gamedat_enemy_arc));
        AppMain.dm_stfrl_boss1_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( mdl_amb, tex_amb, 0U );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 728 ), 2, AppMain.g_gm_gamedat_enemy_arc );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 729 ), 3, AppMain.g_gm_gamedat_enemy_arc );
    }

    // Token: 0x060005F5 RID: 1525 RVA: 0x00034CAC File Offset: 0x00032EAC
    private static void DmStfrlMdlCtrlBoss1Flush()
    {
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 729 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 728 ) );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.g_gm_gamedat_enemy_arc);
        AppMain.GmGameDBuildRegFlushModel( AppMain.dm_stfrl_boss1_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.dm_stfrl_boss1_obj_3d_list = null;
    }

    // Token: 0x060005F6 RID: 1526 RVA: 0x00034D08 File Offset: 0x00032F08
    private static AppMain.DMS_STFRL_BOSS_BODY_WORK DmStfrlMdlCtrlSetBodyObj()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(24576, 0, 0, 0, () => new AppMain.DMS_STFRL_BOSS_BODY_WORK(), "BOSS1_BODY");
        AppMain.DMS_STFRL_BOSS_BODY_WORK result = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obs_OBJECT_WORK;
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.dmStfrlMdlCtrlBoss1BodyExit ) );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194309U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.dm_stfrl_boss1_obj_3d_list[0], obs_OBJECT_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 728 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.obj_3d.blend_spd = 0.125f;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcWaitSetup );
        return result;
    }

    // Token: 0x060005F7 RID: 1527 RVA: 0x00034E04 File Offset: 0x00033004
    private static AppMain.DMS_STFRL_BOSS_EGG_WORK DmStfrlMdlCtrlSetEggObj( AppMain.OBS_OBJECT_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(24576, 0, 0, 0, () => new AppMain.DMS_STFRL_BOSS_EGG_WORK(), "BOSS1_EGG");
        AppMain.DMS_STFRL_BOSS_EGG_WORK result = (AppMain.DMS_STFRL_BOSS_EGG_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.parent_obj = body_work;
        obs_OBJECT_WORK.move_flag |= 256U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.dm_stfrl_boss1_obj_3d_list[1], obs_OBJECT_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 729 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlEggProcWaitSetup );
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        return result;
    }

    // Token: 0x060005F8 RID: 1528 RVA: 0x00034EF5 File Offset: 0x000330F5
    private static void DmStfrlMdlCtrlRingBuild()
    {
        AppMain.dm_stfrl_ring_obj_3d = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 956 ), AppMain.GmGameDatGetGimmickData( 957 ), 0U );
    }

    // Token: 0x060005F9 RID: 1529 RVA: 0x00034F18 File Offset: 0x00033118
    private static void DmStfrlMdlCtrlRingFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(956);
        AppMain.GmGameDBuildRegFlushModel( AppMain.dm_stfrl_ring_obj_3d, ams_AMB_HEADER.file_num );
        AppMain.dm_stfrl_ring_obj_3d = null;
    }

    // Token: 0x060005FA RID: 1530 RVA: 0x00034F50 File Offset: 0x00033150
    private static AppMain.DMS_STFRL_RING_WORK DmStfrlMdlCtrlSetRingObj( int delay_time, uint type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(24576, 0, 0, 0, () => new AppMain.DMS_STFRL_RING_WORK(), "RING_OBJ");
        AppMain.DMS_STFRL_RING_WORK dms_STFRL_RING_WORK = (AppMain.DMS_STFRL_RING_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194309U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.dm_stfrl_ring_obj_3d[0], obs_OBJECT_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obs_OBJECT_WORK, 0, null, null, 0, AppMain.readAMBFile( AppMain.ObjDataGet( 4 ).pData ) );
        obs_OBJECT_WORK.disp_flag |= 4194309U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.disp_flag |= 150995456U;
        obs_OBJECT_WORK.obj_3d.drawflag |= 8388608U;
        obs_OBJECT_WORK.obj_3d.draw_state.alpha.alpha = 0f;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlRingDrawFunc );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlRingProcStartWait );
        dms_STFRL_RING_WORK.disp_ring_pos_no = ( int )type;
        dms_STFRL_RING_WORK.start_pos.x = AppMain.dm_stfrl_ring_disp_pos_tbl[dms_STFRL_RING_WORK.disp_ring_pos_no][0];
        dms_STFRL_RING_WORK.start_pos.y = AppMain.dm_stfrl_ring_disp_pos_tbl[dms_STFRL_RING_WORK.disp_ring_pos_no][1];
        dms_STFRL_RING_WORK.start_pos.z = -12288;
        dms_STFRL_RING_WORK.efct_start_time = delay_time;
        dms_STFRL_RING_WORK.disp_efct_pos_no = ( int )type;
        return dms_STFRL_RING_WORK;
    }

    // Token: 0x060005FB RID: 1531 RVA: 0x000350E8 File Offset: 0x000332E8
    private static void dmStfrlMdlCtrlSonicProcWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK = (AppMain.DMS_STFRL_SONIC_WORK)obj_work;
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK2 = dms_STFRL_SONIC_WORK;
        dms_STFRL_SONIC_WORK2.timer += 1;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( dms_STFRL_SONIC_WORK.timer > 300 )
            {
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 42 );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlSonicProcWaitChngDash2 );
                dms_STFRL_SONIC_WORK.timer = 0;
                return;
            }
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 21 );
        }
    }

    // Token: 0x060005FC RID: 1532 RVA: 0x0003514C File Offset: 0x0003334C
    private static void dmStfrlMdlCtrlSonicProcWaitChngDash2( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK = (AppMain.DMS_STFRL_SONIC_WORK)obj_work;
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK2 = dms_STFRL_SONIC_WORK;
        dms_STFRL_SONIC_WORK2.timer += 1;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( dms_STFRL_SONIC_WORK.timer > 30 )
            {
                obj_work.obj_3d.blend_spd = 0.125f;
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 9 );
                AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(obj_work, 53);
                AppMain.GmComEfctSetDispOffsetF( gms_EFFECT_3DES_WORK, -1.5f, 0f, 9f );
                gms_EFFECT_3DES_WORK.obj_3des.ecb.drawObjState = 0U;
                AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlSonicProcWaitMtnEnd );
                dms_STFRL_SONIC_WORK.timer = 0;
                return;
            }
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 42 );
        }
    }

    // Token: 0x060005FD RID: 1533 RVA: 0x000351F4 File Offset: 0x000333F4
    private static void dmStfrlMdlCtrlSonicProcWaitMtnEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK = (AppMain.DMS_STFRL_SONIC_WORK)obj_work;
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK2 = dms_STFRL_SONIC_WORK;
        dms_STFRL_SONIC_WORK2.timer += 1;
        if ( obj_work.spd_m <= 25292 )
        {
            obj_work.spd_m += 512;
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 9 );
            AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
            if ( dms_STFRL_SONIC_WORK.timer > 60 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlSonicProcWaitFadeEnd );
                AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 9 );
                AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
                dms_STFRL_SONIC_WORK.timer = 120;
            }
        }
    }

    // Token: 0x060005FE RID: 1534 RVA: 0x00035280 File Offset: 0x00033480
    private static void dmStfrlMdlCtrlSonicProcWaitFadeEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK = (AppMain.DMS_STFRL_SONIC_WORK)obj_work;
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK2 = dms_STFRL_SONIC_WORK;
        dms_STFRL_SONIC_WORK2.timer -= 1;
        obj_work.pos.x = obj_work.pos.x + 73728;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            if ( dms_STFRL_SONIC_WORK.timer <= 0 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlSonicProcIdle );
                dms_STFRL_SONIC_WORK.timer = 0;
                AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK3 = dms_STFRL_SONIC_WORK;
                dms_STFRL_SONIC_WORK3.flag |= 1;
                obj_work.disp_flag |= 32U;
                return;
            }
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 9 );
            AppMain.GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( obj_work );
        }
    }

    // Token: 0x060005FF RID: 1535 RVA: 0x00035313 File Offset: 0x00033513
    private static void dmStfrlMdlCtrlSonicProcIdle( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x06000600 RID: 1536 RVA: 0x00035318 File Offset: 0x00033518
    private static void dmStfrlMdlCtrlSonicDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_SONIC_WORK dms_STFRL_SONIC_WORK = (AppMain.DMS_STFRL_SONIC_WORK)obj_work;
        obj_work.obj_3d.draw_state.alpha.alpha = dms_STFRL_SONIC_WORK.alpha;
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06000601 RID: 1537 RVA: 0x00035350 File Offset: 0x00033550
    private static void dmStfrlMdlCtrlBoss1BodyExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obs_OBJECT_WORK;
        AppMain.GmBsCmnClearBossMotionCBSystem( obs_OBJECT_WORK );
        AppMain.GmBsCmnDeleteSNMWork( dms_STFRL_BOSS_BODY_WORK.snm_work );
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06000602 RID: 1538 RVA: 0x00035384 File Offset: 0x00033584
    private static void dmStfrlMdlCtrlBodyProcWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, dms_STFRL_BOSS_BODY_WORK.bmcb_mgr );
        AppMain.GmBsCmnCreateSNMWork( dms_STFRL_BOSS_BODY_WORK.snm_work, obj_work.obj_3d._object, 1 );
        AppMain.GmBsCmnAppendBossMotionCallback( dms_STFRL_BOSS_BODY_WORK.bmcb_mgr, dms_STFRL_BOSS_BODY_WORK.snm_work.bmcb_link );
        dms_STFRL_BOSS_BODY_WORK.egg_snm_reg_id = AppMain.GmBsCmnRegisterSNMNode( dms_STFRL_BOSS_BODY_WORK.snm_work, 11 );
        if ( ( dms_STFRL_BOSS_BODY_WORK.flag & 1U ) != 0U )
        {
            dms_STFRL_BOSS_BODY_WORK.timer = 0;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyCompInitStart );
            return;
        }
        dms_STFRL_BOSS_BODY_WORK.timer = 120;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyMain );
    }

    // Token: 0x06000603 RID: 1539 RVA: 0x00035424 File Offset: 0x00033624
    private static void dmStfrlMdlCtrlBodyProcBodyMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        obj_work.pos.x = 0;
        obj_work.pos.y = -65536;
        obj_work.pos.z = -81920;
        obj_work.dir.y = ( ushort )AppMain.AKM_DEGtoA16( 300 );
        if ( dms_STFRL_BOSS_BODY_WORK.timer != 0 )
        {
            dms_STFRL_BOSS_BODY_WORK.timer--;
            return;
        }
        dms_STFRL_BOSS_BODY_WORK.flag |= 2097152U;
    }

    // Token: 0x06000604 RID: 1540 RVA: 0x000354A4 File Offset: 0x000336A4
    private static void dmStfrlMdlCtrlBodyProcBodyCompInitStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        obj_work.pos.x = 0;
        obj_work.pos.y = -737280;
        obj_work.pos.z = -81920;
        obj_work.dir.y = ( ushort )AppMain.AKM_DEGtoA16( 300 );
        if ( ( dms_STFRL_BOSS_BODY_WORK.flag & 2U ) != 0U )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyCompStartWait );
            dms_STFRL_BOSS_BODY_WORK.flag &= 4294967293U;
        }
    }

    // Token: 0x06000605 RID: 1541 RVA: 0x00035528 File Offset: 0x00033728
    private static void dmStfrlMdlCtrlBodyProcBodyCompStartWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        dms_STFRL_BOSS_BODY_WORK.timer++;
        if ( dms_STFRL_BOSS_BODY_WORK.timer > 60 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyCompMoveDown );
            dms_STFRL_BOSS_BODY_WORK.timer = 0;
        }
    }

    // Token: 0x06000606 RID: 1542 RVA: 0x00035570 File Offset: 0x00033770
    private static void dmStfrlMdlCtrlBodyProcBodyCompMoveDown( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        obj_work.pos.y = obj_work.pos.y + 4096;
        if ( obj_work.pos.y >= -163840 )
        {
            obj_work.pos.y = -163840;
            dms_STFRL_BOSS_BODY_WORK.flag |= 2097152U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyCompLaughWait );
        }
    }

    // Token: 0x06000607 RID: 1543 RVA: 0x000355E8 File Offset: 0x000337E8
    private static void dmStfrlMdlCtrlBodyProcBodyCompLaughWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        dms_STFRL_BOSS_BODY_WORK.timer++;
        if ( dms_STFRL_BOSS_BODY_WORK.timer >= 180 )
        {
            dms_STFRL_BOSS_BODY_WORK.timer = 0;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyCompMoveUpWait );
            dms_STFRL_BOSS_BODY_WORK.flag &= 4294967291U;
        }
    }

    // Token: 0x06000608 RID: 1544 RVA: 0x00035640 File Offset: 0x00033840
    private static void dmStfrlMdlCtrlBodyProcBodyCompMoveUpWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work;
        obj_work.pos.y = obj_work.pos.y + -2457;
        if ( dms_STFRL_BOSS_BODY_WORK.timer > 100 )
        {
            dms_STFRL_BOSS_BODY_WORK.flag |= 16U;
        }
        else
        {
            dms_STFRL_BOSS_BODY_WORK.timer++;
        }
        if ( obj_work.pos.y <= -737280 )
        {
            obj_work.pos.y = -737280;
            dms_STFRL_BOSS_BODY_WORK.flag |= 8U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlBodyProcBodyCompEndWaitIdle );
            dms_STFRL_BOSS_BODY_WORK.timer = 0;
        }
    }

    // Token: 0x06000609 RID: 1545 RVA: 0x000356E2 File Offset: 0x000338E2
    private static void dmStfrlMdlCtrlBodyProcBodyCompEndWaitIdle( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x0600060A RID: 1546 RVA: 0x000356E4 File Offset: 0x000338E4
    private static void dmStfrlMdlCtrlEggProcWaitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.obj_3d.blend_spd = 0.025f;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlEggProcMain );
    }

    // Token: 0x0600060B RID: 1547 RVA: 0x00035708 File Offset: 0x00033908
    private static void dmStfrlMdlCtrlEggProcMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work.parent_obj;
        AppMain.DMS_STFRL_BOSS_EGG_WORK dms_STFRL_BOSS_EGG_WORK = (AppMain.DMS_STFRL_BOSS_EGG_WORK)obj_work;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, dms_STFRL_BOSS_BODY_WORK.snm_work, dms_STFRL_BOSS_BODY_WORK.egg_snm_reg_id, 1 );
        if ( ( dms_STFRL_BOSS_BODY_WORK.flag & 2097152U ) != 0U && ( dms_STFRL_BOSS_EGG_WORK.flag & 1U ) == 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 3 );
            obj_work.obj_3d.frame[0] = 0f;
            obj_work.obj_3d.blend_spd = 0.025f;
            dms_STFRL_BOSS_EGG_WORK.flag |= 1U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlEggProcMainIdle );
        }
    }

    // Token: 0x0600060C RID: 1548 RVA: 0x0003579C File Offset: 0x0003399C
    private static void dmStfrlMdlCtrlEggProcMainIdle( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_BOSS_BODY_WORK dms_STFRL_BOSS_BODY_WORK = (AppMain.DMS_STFRL_BOSS_BODY_WORK)obj_work.parent_obj;
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, dms_STFRL_BOSS_BODY_WORK.snm_work, dms_STFRL_BOSS_BODY_WORK.egg_snm_reg_id, 1 );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, 3 );
            obj_work.obj_3d.frame[0] = 0f;
            obj_work.obj_3d.blend_spd = 0.125f;
        }
    }

    // Token: 0x0600060D RID: 1549 RVA: 0x000357FC File Offset: 0x000339FC
    private static void dmStfrlMdlCtrlRingProcStartWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_RING_WORK dms_STFRL_RING_WORK = (AppMain.DMS_STFRL_RING_WORK)obj_work;
        if ( ( dms_STFRL_RING_WORK.flag & 1U ) != 0U )
        {
            dms_STFRL_RING_WORK.timer++;
            if ( dms_STFRL_RING_WORK.timer >= dms_STFRL_RING_WORK.efct_start_time )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlRingProcInitSetup );
                AppMain.dmStfrlMdlCtrlCreateRingEfct( dms_STFRL_RING_WORK.start_pos.x + AppMain.dm_stfrl_ring_efct_disp_offset_tbl[dms_STFRL_RING_WORK.disp_efct_pos_no][0], dms_STFRL_RING_WORK.start_pos.y + AppMain.dm_stfrl_ring_efct_disp_offset_tbl[dms_STFRL_RING_WORK.disp_efct_pos_no][1] );
                AppMain.dmStfrlMdlCtrlCreateRingEfct( dms_STFRL_RING_WORK.start_pos.x + AppMain.dm_stfrl_ring_efct_disp_offset_tbl[dms_STFRL_RING_WORK.disp_efct_pos_no + 1][0], dms_STFRL_RING_WORK.start_pos.y + AppMain.dm_stfrl_ring_efct_disp_offset_tbl[dms_STFRL_RING_WORK.disp_efct_pos_no + 1][1] );
                AppMain.dmStfrlMdlCtrlCreateRingEfct( dms_STFRL_RING_WORK.start_pos.x + AppMain.dm_stfrl_ring_efct_disp_offset_tbl[dms_STFRL_RING_WORK.disp_efct_pos_no + 2][0], dms_STFRL_RING_WORK.start_pos.y + AppMain.dm_stfrl_ring_efct_disp_offset_tbl[dms_STFRL_RING_WORK.disp_efct_pos_no + 2][1] );
                dms_STFRL_RING_WORK.timer = 0;
                dms_STFRL_RING_WORK.flag &= 4294967294U;
            }
        }
    }

    // Token: 0x0600060E RID: 1550 RVA: 0x0003591C File Offset: 0x00033B1C
    private static void dmStfrlMdlCtrlRingProcInitSetup( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_RING_WORK dms_STFRL_RING_WORK = (AppMain.DMS_STFRL_RING_WORK)obj_work;
        obj_work.obj_3d.draw_state.alpha.alpha = 0f;
        ushort num = 10922;
        ushort num2 = 0;
        for ( int i = 0; i < 6; i++ )
        {
            dms_STFRL_RING_WORK.pos[i].x = dms_STFRL_RING_WORK.start_pos.x;
            dms_STFRL_RING_WORK.pos[i].y = dms_STFRL_RING_WORK.start_pos.y;
            dms_STFRL_RING_WORK.pos[i].z = -3;
            dms_STFRL_RING_WORK.spd_x[i] = AppMain.mtMathSin( ( int )( ( ushort )( ( int )num2 + i * ( int )num ) ) );
            dms_STFRL_RING_WORK.spd_y[i] = AppMain.mtMathCos( ( int )( ( ushort )( ( int )num2 + i * ( int )num ) ) );
            dms_STFRL_RING_WORK.spd_y[i] += 512;
        }
        dms_STFRL_RING_WORK.alpha_spd = 0.1f;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlRingProcDispIdle );
    }

    // Token: 0x0600060F RID: 1551 RVA: 0x00035A18 File Offset: 0x00033C18
    private static void dmStfrlMdlCtrlRingProcDispIdle( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_RING_WORK dms_STFRL_RING_WORK = (AppMain.DMS_STFRL_RING_WORK)obj_work;
        for ( int i = 0; i < 6; i++ )
        {
            dms_STFRL_RING_WORK.spd_y[i] += 64;
        }
        dms_STFRL_RING_WORK.timer++;
        if ( dms_STFRL_RING_WORK.timer >= 10 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlRingProcNoDispIdle );
            dms_STFRL_RING_WORK.timer = 60;
            dms_STFRL_RING_WORK.alpha_spd = 0.016666668f;
        }
        if ( dms_STFRL_RING_WORK.alpha >= 1f )
        {
            dms_STFRL_RING_WORK.alpha = 1f;
            return;
        }
        dms_STFRL_RING_WORK.alpha = dms_STFRL_RING_WORK.alpha_spd * ( float )dms_STFRL_RING_WORK.timer;
    }

    // Token: 0x06000610 RID: 1552 RVA: 0x00035AC0 File Offset: 0x00033CC0
    private static void dmStfrlMdlCtrlRingProcNoDispIdle( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_RING_WORK dms_STFRL_RING_WORK = (AppMain.DMS_STFRL_RING_WORK)obj_work;
        for ( int i = 0; i < 6; i++ )
        {
            dms_STFRL_RING_WORK.spd_y[i] += 64;
        }
        dms_STFRL_RING_WORK.timer--;
        if ( dms_STFRL_RING_WORK.timer <= 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.dmStfrlMdlCtrlRingProcStartWait );
            dms_STFRL_RING_WORK.timer = 0;
            dms_STFRL_RING_WORK.disp_ring_pos_no++;
            if ( dms_STFRL_RING_WORK.disp_ring_pos_no > 12 )
            {
                dms_STFRL_RING_WORK.disp_ring_pos_no = 0;
            }
            dms_STFRL_RING_WORK.disp_efct_pos_no++;
            if ( dms_STFRL_RING_WORK.disp_efct_pos_no > 12 )
            {
                dms_STFRL_RING_WORK.disp_efct_pos_no = 0;
            }
            dms_STFRL_RING_WORK.start_pos.x = AppMain.dm_stfrl_ring_disp_pos_tbl[dms_STFRL_RING_WORK.disp_ring_pos_no][0];
            dms_STFRL_RING_WORK.start_pos.y = AppMain.dm_stfrl_ring_disp_pos_tbl[dms_STFRL_RING_WORK.disp_ring_pos_no][1];
        }
        if ( dms_STFRL_RING_WORK.alpha <= 0f )
        {
            dms_STFRL_RING_WORK.alpha = 0f;
            return;
        }
        dms_STFRL_RING_WORK.alpha = dms_STFRL_RING_WORK.alpha_spd * ( float )dms_STFRL_RING_WORK.timer;
    }

    // Token: 0x06000611 RID: 1553 RVA: 0x00035BCC File Offset: 0x00033DCC
    private static void dmStfrlMdlCtrlRingDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.DMS_STFRL_RING_WORK dms_STFRL_RING_WORK = (AppMain.DMS_STFRL_RING_WORK)obj_work;
        obj_work.dir.y = obj_work.dir.y;
        obj_work.obj_3d.draw_state.alpha.alpha = dms_STFRL_RING_WORK.alpha;
        for ( int i = 0; i < 6; i++ )
        {
            AppMain.VecFx32[] pos = dms_STFRL_RING_WORK.pos;
            int num = i;
            pos[num].x = pos[num].x + dms_STFRL_RING_WORK.spd_x[i];
            AppMain.VecFx32[] pos2 = dms_STFRL_RING_WORK.pos;
            int num2 = i;
            pos2[num2].y = pos2[num2].y + dms_STFRL_RING_WORK.spd_y[i];
            obj_work.pos.x = dms_STFRL_RING_WORK.pos[i].x;
            obj_work.pos.y = dms_STFRL_RING_WORK.pos[i].y;
            obj_work.pos.z = dms_STFRL_RING_WORK.pos[i].z;
            if ( i == 0 )
            {
                obj_work.disp_flag &= 4294967279U;
            }
            else
            {
                obj_work.disp_flag |= 16U;
            }
            AppMain.ObjDrawActionSummary( obj_work );
        }
    }

    // Token: 0x06000612 RID: 1554 RVA: 0x00035CE0 File Offset: 0x00033EE0
    private static void dmStfrlMdlCtrlCreateRingEfct( int pos_x, int pos_y )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(null, 50);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = pos_x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = pos_y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = -3;
    }
}