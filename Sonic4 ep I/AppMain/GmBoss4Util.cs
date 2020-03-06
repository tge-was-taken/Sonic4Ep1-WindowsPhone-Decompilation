using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060006E3 RID: 1763 RVA: 0x0003DBEE File Offset: 0x0003BDEE
    public static float GMM_BOSS4_PAL_SPEED( float spd )
    {
        if ( !AppMain.GmBoss4UtilCheckPAL() )
        {
            return spd;
        }
        return spd * 1.2f;
    }

    // Token: 0x060006E4 RID: 1764 RVA: 0x0003DC00 File Offset: 0x0003BE00
    public static int GMM_BOSS4_PAL_TIME( float time )
    {
        if ( !AppMain.GmBoss4UtilCheckPAL() )
        {
            return ( int )time;
        }
        return ( int )( time * 0.8333333f );
    }

    // Token: 0x060006E5 RID: 1765 RVA: 0x0003DC14 File Offset: 0x0003BE14
    public static float GMM_BOSS4_PAL_ZOOM( float zoom )
    {
        if ( !AppMain.GmBoss4UtilCheckPAL() )
        {
            return zoom;
        }
        if ( zoom < 1f )
        {
            return zoom * 0.8333333f;
        }
        return zoom * 1.2f;
    }

    // Token: 0x060006E6 RID: 1766 RVA: 0x0003DC36 File Offset: 0x0003BE36
    private static void GmBoss4UtilInit1ShotTimer( AppMain.GMS_BOSS4_1SHOT_TIMER one_shot_timer, uint frame )
    {
        AppMain.MTM_ASSERT( one_shot_timer );
        one_shot_timer.timer = frame;
        one_shot_timer.is_active = true;
    }

    // Token: 0x060006E7 RID: 1767 RVA: 0x0003DC4C File Offset: 0x0003BE4C
    private static bool GmBoss4UtilUpdate1ShotTimer( AppMain.GMS_BOSS4_1SHOT_TIMER one_shot_timer )
    {
        AppMain.MTM_ASSERT( one_shot_timer );
        if ( !one_shot_timer.is_active )
        {
            return false;
        }
        if ( one_shot_timer.timer != 0U )
        {
            one_shot_timer.timer -= 1U;
            return false;
        }
        one_shot_timer.is_active = false;
        return true;
    }

    // Token: 0x060006E8 RID: 1768 RVA: 0x0003DC80 File Offset: 0x0003BE80
    private static void GmBoss4UtilInitNodeMatrix( AppMain.GMS_BOSS4_NODE_MATRIX node_work, AppMain.OBS_OBJECT_WORK obj_work, int max_node )
    {
        node_work.initCount = max_node;
        node_work.useCount = 0;
        AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, node_work.mtn_mgr );
        AppMain.GmBsCmnCreateSNMWork( node_work.snm_work, obj_work.obj_3d._object, ( ushort )max_node );
        AppMain.GmBsCmnAppendBossMotionCallback( node_work.mtn_mgr, node_work.snm_work.bmcb_link );
        node_work.obj_work = obj_work;
        for ( int i = 0; i < 32; i++ )
        {
            node_work.work[i] = -1;
        }
        node_work._id = "SNM SYS";
    }

    // Token: 0x060006E9 RID: 1769 RVA: 0x0003DCFD File Offset: 0x0003BEFD
    private static void GmBoss4UtilExitNodeMatrix( AppMain.GMS_BOSS4_NODE_MATRIX node_work )
    {
        if ( node_work._id != "SNM SYS" )
        {
            return;
        }
        AppMain.GmBsCmnClearBossMotionCBSystem( node_work.obj_work );
        AppMain.GmBsCmnDeleteSNMWork( node_work.snm_work );
        node_work._id = "";
    }

    // Token: 0x060006EA RID: 1770 RVA: 0x0003DD34 File Offset: 0x0003BF34
    private static AppMain.NNS_MATRIX GmBoss4UtilGetNodeMatrix( AppMain.GMS_BOSS4_NODE_MATRIX node_work, int node_id )
    {
        if ( node_work.work[node_id] < 0 )
        {
            node_work.work[node_id] = AppMain.GmBsCmnRegisterSNMNode( node_work.snm_work, node_id );
        }
        return AppMain.GmBsCmnGetSNMMtx( node_work.snm_work, node_work.work[node_id] );
    }

    // Token: 0x060006EB RID: 1771 RVA: 0x0003DD75 File Offset: 0x0003BF75
    private static void GmBoss4UtilSetNodeMatrixNN( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BOSS4_NODE_MATRIX node_work, int node_id )
    {
        AppMain.GmBsCmnUpdateObject3DNNStuckWithNode( obj_work, node_work.snm_work, node_work.work[node_id], 1 );
    }

    // Token: 0x060006EC RID: 1772 RVA: 0x0003DD8C File Offset: 0x0003BF8C
    private static void GmBoss4UtilSetMatrixNN( AppMain.OBS_OBJECT_WORK obj_work, AppMain.NNS_MATRIX w_mtx )
    {
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3d );
        AppMain.NNS_MATRIX user_obj_mtx_r = obj_work.obj_3d.user_obj_mtx_r;
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( w_mtx.M03 );
        obj_work.pos.y = -AppMain.FX_F32_TO_FX32( w_mtx.M13 );
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( w_mtx.M23 );
        obj_work.disp_flag |= 16777216U;
        AppMain.AkMathNormalizeMtx( user_obj_mtx_r, w_mtx );
    }

    // Token: 0x060006ED RID: 1773 RVA: 0x0003DE12 File Offset: 0x0003C012
    private static void GmBoss4UtilSetNodeMatrixES( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BOSS4_NODE_MATRIX node_work, int node_id )
    {
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, node_work.snm_work, node_work.work[node_id], 1 );
    }

    // Token: 0x060006EE RID: 1774 RVA: 0x0003DE2C File Offset: 0x0003C02C
    private static void GmBoss4UtilSetMatrixES( AppMain.OBS_OBJECT_WORK obj_work, AppMain.NNS_MATRIX w_mtx )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3des );
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( w_mtx.M03 );
        obj_work.pos.y = -AppMain.FX_F32_TO_FX32( w_mtx.M13 );
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( w_mtx.M23 );
        obj_work.obj_3des.flag |= 32U;
        AppMain.AkMathNormalizeMtx( nns_MATRIX, w_mtx );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x060006EF RID: 1775 RVA: 0x0003DEB4 File Offset: 0x0003C0B4
    private static void GmBoss4UtilPlayerStop( bool b )
    {
        if ( b )
        {
            AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
            gms_PLAYER_WORK.no_key_timer = 737280;
            return;
        }
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK2 = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
        gms_PLAYER_WORK2.no_key_timer = 0;
    }

    // Token: 0x060006F0 RID: 1776 RVA: 0x0003DEED File Offset: 0x0003C0ED
    private static void GmBoss4UtilTimerStop( bool b )
    {
        if ( b )
        {
            AppMain.g_gm_main_system.game_flag &= 4294966271U;
            return;
        }
        AppMain.g_gm_main_system.game_flag |= 1024U;
    }

    // Token: 0x060006F1 RID: 1777 RVA: 0x0003DF20 File Offset: 0x0003C120
    private static void GmBoss4UtilInitMove( AppMain.GMS_BOSS4_MOVE _work, AppMain.VecFx32 start, AppMain.VecFx32 end, int count, int type )
    {
        _work.start.x = start.x;
        _work.start.y = start.y;
        _work.start.z = start.z;
        _work.end.x = end.x;
        _work.end.y = end.y;
        _work.end.z = end.z;
        _work.max_count = count;
        _work.type = type;
        _work.now_count = 0;
    }

    // Token: 0x060006F2 RID: 1778 RVA: 0x0003DFB0 File Offset: 0x0003C1B0
    private static bool GmBoss4UtilUpdateMove( AppMain.GMS_BOSS4_MOVE _work )
    {
        AppMain.VecFx32 vecFx;
        return AppMain.GmBoss4UtilUpdateMove( _work, out vecFx );
    }

    // Token: 0x060006F3 RID: 1779 RVA: 0x0003DFC8 File Offset: 0x0003C1C8
    private static bool GmBoss4UtilUpdateMove( AppMain.GMS_BOSS4_MOVE _work, out AppMain.VecFx32 pos )
    {
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = _work.end.x - _work.start.x;
        vecFx.y = _work.end.y - _work.start.y;
        vecFx.z = _work.end.z - _work.start.z;
        if ( _work.now_count < _work.max_count )
        {
            _work.now_count++;
        }
        if ( _work.now_count >= _work.max_count )
        {
            _work.now_count = _work.max_count;
            _work.pos.x = _work.end.x;
            _work.pos.y = _work.end.y;
            _work.pos.z = _work.end.z;
            pos.x = _work.end.x;
            pos.y = _work.end.y;
            pos.z = _work.end.z;
            return true;
        }
        if ( _work.type == 0 )
        {
            _work.pos.x = ( int )( ( float )_work.start.x + ( float )vecFx.x * ( ( float )_work.now_count / ( float )_work.max_count ) );
            _work.pos.y = ( int )( ( float )_work.start.y + ( float )vecFx.y * ( ( float )_work.now_count / ( float )_work.max_count ) );
            _work.pos.z = ( int )( ( float )_work.start.z + ( float )vecFx.z * ( ( float )_work.now_count / ( float )_work.max_count ) );
        }
        else if ( ( double )( ( float )_work.now_count / ( float )_work.max_count ) <= 0.5 )
        {
            int num = AppMain.FX_Cos(AppMain.AKM_DEGtoA32(180f * ((float)_work.now_count / (float)_work.max_count)));
            float num2 = 0.5f - (float)num * 0.00024414062f * 0.5f;
            _work.pos.x = _work.start.x + ( int )( ( float )vecFx.x * num2 );
            _work.pos.y = _work.start.y + ( int )( ( float )vecFx.y * num2 );
            _work.pos.z = _work.start.z + ( int )( ( float )vecFx.z * num2 );
        }
        else
        {
            int num3 = AppMain.FX_Cos(AppMain.AKM_DEGtoA32(180f * ((float)_work.now_count / (float)_work.max_count)));
            float num4 = (float)num3 * 0.00024414062f * 0.5f;
            _work.pos.x = _work.start.x + ( int )( ( float )vecFx.x * ( 0.5f - num4 ) );
            _work.pos.y = _work.start.y + ( int )( ( float )vecFx.y * ( 0.5f - num4 ) );
            _work.pos.z = _work.start.z + ( int )( ( float )vecFx.z * ( 0.5f - num4 ) );
        }
        pos.x = _work.pos.x;
        pos.y = _work.pos.y;
        pos.z = _work.pos.z;
        return false;
    }

    // Token: 0x060006F4 RID: 1780 RVA: 0x0003E328 File Offset: 0x0003C528
    private static void GmBoss4UtilUpdateMovePosition( AppMain.GMS_BOSS4_MOVE _work, AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = _work.pos.x;
        obj_work.pos.y = _work.pos.y;
        obj_work.pos.z = _work.pos.z;
    }

    // Token: 0x060006F5 RID: 1781 RVA: 0x0003E378 File Offset: 0x0003C578
    private static bool GmBoss4UtilIsDirectionPositiveFromCurrent( AppMain.GMS_BOSS4_DIRECTION _work, short target_angle )
    {
        int num = (int)(65535L & (long)(_work.cur_angle - target_angle));
        return num >= AppMain.AKM_DEGtoA32( 180 );
    }

    // Token: 0x060006F6 RID: 1782 RVA: 0x0003E3A7 File Offset: 0x0003C5A7
    private static void GmBoss4UtilUpdateDirection( AppMain.GMS_BOSS4_DIRECTION _work, AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GmBoss4UtilUpdateDirection( _work, obj_work, false );
    }

    // Token: 0x060006F7 RID: 1783 RVA: 0x0003E3B1 File Offset: 0x0003C5B1
    private static void GmBoss4UtilUpdateDirection( AppMain.GMS_BOSS4_DIRECTION _work, AppMain.OBS_OBJECT_WORK obj_work, bool flag )
    {
        if ( _work.direction == 1 )
        {
            obj_work.disp_flag |= 1U;
        }
        else
        {
            obj_work.disp_flag &= 4294967294U;
        }
        if ( flag )
        {
            return;
        }
        obj_work.dir.y = ( ushort )_work.cur_angle;
    }

    // Token: 0x060006F8 RID: 1784 RVA: 0x0003E3F1 File Offset: 0x0003C5F1
    private static void GmBoss4UtilSetDirectionNormal( AppMain.GMS_BOSS4_DIRECTION _work )
    {
        if ( _work.direction == 1 )
        {
            AppMain.GmBoss4UtilSetDirection( _work, AppMain.GMD_BOSS4_LEFTWARD_ANGLE );
        }
        else
        {
            AppMain.GmBoss4UtilSetDirection( _work, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE );
        }
        _work.orig_angle = 0;
        _work.turn_angle = 0;
    }

    // Token: 0x060006F9 RID: 1785 RVA: 0x0003E422 File Offset: 0x0003C622
    private static void GmBoss4UtilSetDirection( AppMain.GMS_BOSS4_DIRECTION _work, short deg )
    {
        _work.cur_angle = deg;
    }

    // Token: 0x060006FA RID: 1786 RVA: 0x0003E42C File Offset: 0x0003C62C
    private static void GmBoss4UtilInitTurn( AppMain.GMS_BOSS4_DIRECTION _work, int turn_amount, int turn_spd )
    {
        AppMain.MTM_ASSERT( 0 == ( int.MinValue & ( turn_amount ^ turn_spd ) ) );
        _work.orig_angle = _work.cur_angle;
        _work.turn_angle = 0;
        _work.turn_amount = turn_amount;
        _work.turn_spd = turn_spd;
        AppMain.GmBoss4UtilSetDirection( _work, ( short )( ( int )_work.orig_angle + _work.turn_angle ) );
    }

    // Token: 0x060006FB RID: 1787 RVA: 0x0003E480 File Offset: 0x0003C680
    private static void GmBoss4UtilInitTurn( AppMain.GMS_BOSS4_DIRECTION _work, short dest_angle, int frame, bool is_positive )
    {
        AppMain.MTM_ASSERT( frame > 0 );
        int num2;
        if ( is_positive )
        {
            ushort num = (ushort)(dest_angle - _work.cur_angle);
            num2 = ( int )num;
        }
        else
        {
            ushort num = (ushort)((int)dest_angle - AppMain.AKM_DEGtoA32(360) - ((int)_work.cur_angle - AppMain.AKM_DEGtoA32(360)));
            num2 = ( int )num - AppMain.AKM_DEGtoA32( 360 );
        }
        int turn_spd = num2 / frame;
        AppMain.GmBoss4UtilInitTurn( _work, num2, turn_spd );
    }

    // Token: 0x060006FC RID: 1788 RVA: 0x0003E4E0 File Offset: 0x0003C6E0
    private static bool GmBoss4UtilUpdateTurn( AppMain.GMS_BOSS4_DIRECTION _work, float spd_rate )
    {
        bool flag = false;
        AppMain.MTM_ASSERT( spd_rate >= 0f );
        float num = spd_rate * (float)_work.turn_spd;
        AppMain.MTM_ASSERT( AppMain.MTM_MATH_ABS( num ) <= 2.1474836E+09f );
        _work.turn_angle += ( int )num;
        if ( _work.turn_spd > 0 )
        {
            if ( _work.turn_angle >= _work.turn_amount )
            {
                flag = true;
            }
        }
        else if ( _work.turn_spd < 0 && _work.turn_angle <= _work.turn_amount )
        {
            flag = true;
        }
        if ( flag )
        {
            _work.turn_angle = _work.turn_amount;
        }
        AppMain.GmBoss4UtilSetDirection( _work, ( short )( ( int )_work.orig_angle + _work.turn_angle ) );
        return flag;
    }

    // Token: 0x060006FD RID: 1789 RVA: 0x0003E588 File Offset: 0x0003C788
    private static void GmBoss4UtilInitTurnGently( AppMain.GMS_BOSS4_DIRECTION _work, short dest_angle, int frame, bool is_positive )
    {
        AppMain.MTM_ASSERT( frame > 0 );
        _work.orig_angle = _work.cur_angle;
        _work.turn_angle = 0;
        _work.turn_spd = 0;
        if ( is_positive )
        {
            ushort num = (ushort)(dest_angle - _work.cur_angle);
            _work.turn_amount = ( int )num;
        }
        else
        {
            ushort num = (ushort)((int)dest_angle - AppMain.AKM_DEGtoA32(360) - ((int)_work.cur_angle - AppMain.AKM_DEGtoA32(360)));
            _work.turn_amount = ( int )num - AppMain.AKM_DEGtoA32( 360 );
        }
        _work.turn_gen_var = 0;
        float num2 = 180f / (float)frame;
        AppMain.MTM_ASSERT( AppMain.MTM_MATH_ABS( num2 ) <= 2.1474836E+09f );
        _work.turn_gen_factor = AppMain.AKM_DEGtoA32( num2 );
        AppMain.GmBoss4UtilSetDirection( _work, ( short )( ( int )_work.orig_angle + _work.turn_angle ) );
    }

    // Token: 0x060006FE RID: 1790 RVA: 0x0003E648 File Offset: 0x0003C848
    private static bool GmBoss4UtilUpdateTurnGently( AppMain.GMS_BOSS4_DIRECTION _work )
    {
        bool flag = false;
        AppMain.MTM_ASSERT( _work.turn_gen_factor > 0 );
        _work.turn_gen_var += _work.turn_gen_factor;
        if ( _work.turn_gen_var >= AppMain.AKM_DEGtoA32( 180 ) )
        {
            _work.turn_gen_var = AppMain.AKM_DEGtoA32( 180 );
            flag = true;
        }
        float num = (float)_work.turn_amount * 0.5f * (1f - AppMain.nnCos(_work.turn_gen_var));
        AppMain.MTM_ASSERT( AppMain.MTM_MATH_ABS( num ) <= 2.1474836E+09f );
        _work.turn_angle = ( int )num;
        if ( flag )
        {
            _work.turn_angle = _work.turn_amount;
        }
        AppMain.GmBoss4UtilSetDirection( _work, ( short )( ( int )_work.orig_angle + _work.turn_angle ) );
        return flag;
    }

    // Token: 0x060006FF RID: 1791 RVA: 0x0003E700 File Offset: 0x0003C900
    private static bool GmBoss4UtilLookAtPlayer( AppMain.GMS_BOSS4_DIRECTION _work, AppMain.OBS_OBJECT_WORK obj_work, int time )
    {
        if ( AppMain.GmBsCmnGetPlayerObj().pos.x < obj_work.pos.x )
        {
            _work.direction = 1;
            AppMain.GmBoss4UtilInitTurnGently( _work, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, time, false );
        }
        else
        {
            _work.direction = 0;
            AppMain.GmBoss4UtilInitTurnGently( _work, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE, time, true );
        }
        return AppMain.GmBoss4UtilUpdateTurnGently( _work );
    }

    // Token: 0x06000700 RID: 1792 RVA: 0x0003E75C File Offset: 0x0003C95C
    private static bool GmBoss4UtilLookAtPlayerCheckDirection( AppMain.GMS_BOSS4_DIRECTION _work, AppMain.OBS_OBJECT_WORK obj_work, int time )
    {
        if ( AppMain.GmBsCmnGetPlayerObj().pos.x < obj_work.pos.x )
        {
            if ( _work.direction != 1 )
            {
                _work.direction = 1;
                AppMain.GmBoss4UtilInitTurnGently( _work, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, time, false );
            }
        }
        else if ( _work.direction != 0 )
        {
            _work.direction = 0;
            AppMain.GmBoss4UtilInitTurnGently( _work, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE, time, true );
        }
        return AppMain.GmBoss4UtilUpdateTurnGently( _work );
    }

    // Token: 0x06000701 RID: 1793 RVA: 0x0003E7C8 File Offset: 0x0003C9C8
    private static bool GmBoss4UtilLookAtCenter( AppMain.GMS_BOSS4_DIRECTION _work, AppMain.OBS_OBJECT_WORK obj_work, int time )
    {
        if ( AppMain.GMM_BOSS4_AREA_CENTER_X() < obj_work.pos.x )
        {
            _work.direction = 1;
            AppMain.GmBoss4UtilInitTurnGently( _work, AppMain.GMD_BOSS4_LEFTWARD_ANGLE, time, false );
        }
        else
        {
            _work.direction = 0;
            AppMain.GmBoss4UtilInitTurnGently( _work, AppMain.GMD_BOSS4_RIGHTWARD_ANGLE, time, true );
        }
        return AppMain.GmBoss4UtilUpdateTurnGently( _work );
    }

    // Token: 0x06000702 RID: 1794 RVA: 0x0003E817 File Offset: 0x0003CA17
    private static bool GmBoss4UtilLookAt( AppMain.GMS_BOSS4_DIRECTION _work )
    {
        return AppMain.GmBoss4UtilUpdateTurnGently( _work );
    }

    // Token: 0x06000703 RID: 1795 RVA: 0x0003E81F File Offset: 0x0003CA1F
    private static void GmBoss4UtilInitFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BOSS4_FLICKER_WORK flk_work )
    {
        AppMain.GmBoss4UtilInitFlicker( obj_work, flk_work, 3, 0, 4, 0, AppMain.gm_boss4_color_white );
    }

    // Token: 0x06000704 RID: 1796 RVA: 0x0003E834 File Offset: 0x0003CA34
    private static void GmBoss4UtilInitFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BOSS4_FLICKER_WORK flk_work, int times, int start, int spd, int interval, AppMain.NNS_RGB rgb )
    {
        int add_timer = AppMain.AKM_DEGtoA32(360f / (float)(spd + 1));
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3d );
        AppMain.MTM_ASSERT( flk_work );
        flk_work.is_active = true;
        flk_work.cycles = ( uint )times;
        flk_work.interval_timer = ( uint )start;
        flk_work.cur_angle = 0;
        flk_work.add_timer = add_timer;
        flk_work.interval_flk = ( uint )interval;
        flk_work.color.r = rgb.r;
        flk_work.color.g = rgb.g;
        flk_work.color.b = rgb.b;
        AppMain.GmBsCmnClearObject3DNNFadedColor( obj_work );
    }

    // Token: 0x06000705 RID: 1797 RVA: 0x0003E8D0 File Offset: 0x0003CAD0
    private static bool GmBoss4UtilUpdateFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BOSS4_FLICKER_WORK flk_work )
    {
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3d );
        AppMain.MTM_ASSERT( flk_work );
        if ( !flk_work.is_active )
        {
            return true;
        }
        if ( flk_work.cycles != 0U )
        {
            if ( flk_work.interval_timer != 0U )
            {
                flk_work.interval_timer -= 1U;
            }
            else
            {
                flk_work.cur_angle += flk_work.add_timer;
                if ( flk_work.cur_angle >= AppMain.AKM_DEGtoA32( 360f ) )
                {
                    flk_work.cur_angle = 0;
                    flk_work.cycles -= 1U;
                    flk_work.interval_timer = flk_work.interval_flk;
                }
            }
            AppMain.GmBsCmnSetObject3DNNFadedColor( obj_work, flk_work.color, ( 1f - AppMain.nnCos( flk_work.cur_angle ) ) / 2f );
            return false;
        }
        if ( flk_work.is_active )
        {
            AppMain.GmBoss4UtilEndFlicker( obj_work, flk_work );
        }
        return true;
    }

    // Token: 0x06000706 RID: 1798 RVA: 0x0003E99C File Offset: 0x0003CB9C
    private static void GmBoss4UtilEndFlicker( AppMain.OBS_OBJECT_WORK obj_work, AppMain.GMS_BOSS4_FLICKER_WORK flk_work )
    {
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3d );
        AppMain.MTM_ASSERT( flk_work );
        flk_work.Clear();
        AppMain.GmBsCmnClearObject3DNNFadedColor( obj_work );
    }

    // Token: 0x06000707 RID: 1799 RVA: 0x0003E9C4 File Offset: 0x0003CBC4
    private static void GmBoss4UtilRotateVecFx32( ref AppMain.VecFx32 f, int angle )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        nns_MATRIX.M00 = 1f;
        nns_MATRIX.M10 = 0f;
        nns_MATRIX.M20 = 0f;
        nns_MATRIX.M30 = 0f;
        nns_MATRIX.M01 = 0f;
        nns_MATRIX.M11 = 1f;
        nns_MATRIX.M21 = 0f;
        nns_MATRIX.M31 = 0f;
        nns_MATRIX.M02 = 0f;
        nns_MATRIX.M12 = 0f;
        nns_MATRIX.M22 = 1f;
        nns_MATRIX.M32 = 0f;
        nns_MATRIX.M03 = 0f;
        nns_MATRIX.M13 = 0f;
        nns_MATRIX.M23 = 0f;
        nns_MATRIX.M33 = 1f;
        AppMain.nnMakeRotateZMatrix( nns_MATRIX, angle );
        AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, AppMain.FX_FX32_TO_F32( f.x ), AppMain.FX_FX32_TO_F32( f.y ), AppMain.FX_FX32_TO_F32( f.z ) );
        f.x = AppMain.FX_F32_TO_FX32( nns_MATRIX.M03 );
        f.y = AppMain.FX_F32_TO_FX32( nns_MATRIX.M13 );
        f.z = AppMain.FX_F32_TO_FX32( nns_MATRIX.M23 );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000708 RID: 1800 RVA: 0x0003EAEF File Offset: 0x0003CCEF
    private static void GmBoss4UtilIterateDamageRingInit()
    {
        AppMain.gm_boss4_util_ring = AppMain.GmRingGetWork().damage_ring_list_start;
    }

    // Token: 0x06000709 RID: 1801 RVA: 0x0003EB00 File Offset: 0x0003CD00
    private static AppMain.GMS_RING_WORK GmBoss4UtilIterateDamageRingGet()
    {
        AppMain.GMS_RING_WORK gms_RING_WORK = AppMain.gm_boss4_util_ring;
        if ( gms_RING_WORK == null )
        {
            return null;
        }
        AppMain.gm_boss4_util_ring = gms_RING_WORK.post_ring;
        return gms_RING_WORK;
    }

    // Token: 0x0600070A RID: 1802 RVA: 0x0003EB24 File Offset: 0x0003CD24
    private static void GmBoss4UtilSetPlayerAttackReaction( AppMain.OBS_OBJECT_WORK player, AppMain.OBS_OBJECT_WORK enemy )
    {
        AppMain.UNREFERENCED_PARAMETER( enemy );
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)player;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBoss4GetBodyWork();
        if ( ( gms_PLAYER_WORK.obj_work.move_flag & 16U ) != 0U )
        {
            AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
            AppMain.GmPlySeqSetJumpState( gms_PLAYER_WORK, 0, 5U );
            gms_PLAYER_WORK.obj_work.spd_m = 0;
            if ( obs_OBJECT_WORK != null )
            {
                if ( gms_PLAYER_WORK.obj_work.pos.x < obs_OBJECT_WORK.pos.x )
                {
                    gms_PLAYER_WORK.obj_work.spd.x = -AppMain.FX_F32_TO_FX32( 5f );
                    if ( AppMain.GmBoss4GetScrollOffset() != 0 )
                    {
                        gms_PLAYER_WORK.obj_work.spd.x = AppMain.FX_F32_TO_FX32( 3f );
                    }
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.x = AppMain.FX_F32_TO_FX32( 5f );
                }
            }
            else
            {
                if ( gms_PLAYER_WORK.obj_work.move.x >= 0 )
                {
                    gms_PLAYER_WORK.obj_work.spd.x = -AppMain.FX_F32_TO_FX32( 5f );
                    if ( AppMain.GmBoss4GetScrollOffset() != 0 )
                    {
                        gms_PLAYER_WORK.obj_work.spd.x = AppMain.FX_F32_TO_FX32( 3f );
                    }
                }
                else
                {
                    gms_PLAYER_WORK.obj_work.spd.x = AppMain.FX_F32_TO_FX32( 5f );
                }
                int seq_state = gms_PLAYER_WORK.seq_state;
            }
            gms_PLAYER_WORK.obj_work.spd.y = -AppMain.FX_F32_TO_FX32( 4f );
            AppMain.GmPlySeqSetNoJumpMoveTime( gms_PLAYER_WORK, 102400 );
            return;
        }
        gms_PLAYER_WORK.obj_work.disp_flag ^= 1U;
        AppMain.GmPlySeqChangeSequence( gms_PLAYER_WORK, 10 );
        if ( gms_PLAYER_WORK.obj_work.spd_m != 0 )
        {
            gms_PLAYER_WORK.obj_work.spd_m = -gms_PLAYER_WORK.obj_work.spd_m;
            return;
        }
        int num = 0;
        if ( obs_OBJECT_WORK != null )
        {
            num = obs_OBJECT_WORK.pos.x;
        }
        if ( num > gms_PLAYER_WORK.obj_work.pos.x )
        {
            gms_PLAYER_WORK.obj_work.spd_m = -49152;
            gms_PLAYER_WORK.obj_work.disp_flag |= 1U;
            return;
        }
        gms_PLAYER_WORK.obj_work.spd_m = 49152;
        gms_PLAYER_WORK.obj_work.disp_flag &= 4294967294U;
    }

    // Token: 0x0600070B RID: 1803 RVA: 0x0003ED3A File Offset: 0x0003CF3A
    private static bool GmBoss4UtilCheckPAL()
    {
        return false;
    }

    // Token: 0x0600070C RID: 1804 RVA: 0x0003ED3D File Offset: 0x0003CF3D
    private static bool GmBoss4UtilIsScrollLocking()
    {
        return AppMain.g_gm_main_system.map_fcol.left != 0 || AppMain.g_gm_main_system.map_fcol.right != ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 );
    }

    // Token: 0x0600070D RID: 1805 RVA: 0x0003ED76 File Offset: 0x0003CF76
    private static void GmBoss4UtilInitNoHitTimer( AppMain.GMS_BOSS4_NOHIT_TIMER work, AppMain.GMS_ENEMY_COM_WORK ene_com, int time )
    {
        work.ene_com = ene_com;
        work.timer = ( uint )( time + 1 );
        AppMain.GmBoss4UtilUpdateNoHitTimer( work );
    }

    // Token: 0x0600070E RID: 1806 RVA: 0x0003ED90 File Offset: 0x0003CF90
    private static bool GmBoss4UtilUpdateNoHitTimer( AppMain.GMS_BOSS4_NOHIT_TIMER work )
    {
        AppMain.GMS_ENEMY_COM_WORK ene_com = work.ene_com;
        if ( work.timer > 0U )
        {
            work.timer -= 1U;
            ene_com.rect_work[1].flag |= 2048U;
            return false;
        }
        ene_com.rect_work[1].flag &= 4294965247U;
        return true;
    }

}