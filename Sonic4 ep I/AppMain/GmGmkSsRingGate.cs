using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000B17 RID: 2839 RVA: 0x0006387C File Offset: 0x00061A7C
    private static AppMain.OBS_OBJECT_WORK GmGmkSsRingGateInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SS_RINGGATE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.user_work = ( uint )AppMain.GmSplStageRingGateNumGet( ( ushort )eve_rec.left );
        obs_OBJECT_WORK.user_flag = ( uint )( eve_rec.flag & 1 );
        obs_OBJECT_WORK.user_timer = 20;
        if ( ( ushort )obs_OBJECT_WORK.user_work > ( ushort )AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].ring_num )
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_ringgate_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            uint num = AppMain.g_gm_main_system.sync_time % 128U;
            gms_ENEMY_3D_WORK.obj_3d.mat_frame = num;
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsRingGateDrawFunc );
            obs_OBJECT_WORK.user_flag = ( ( obs_OBJECT_WORK.user_flag & 1U ) | ( num & 127U ) << 8 );
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_ss_ringgate_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        }
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 2U;
        if ( ( ushort )obs_OBJECT_WORK.user_work > ( ushort )AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].ring_num )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GATERING");
            AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK2;
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_ss_ringgate_obj_3d_list[12], gms_EFFECT_3DNN_WORK.obj_3d );
            obs_OBJECT_WORK2.pos.z = -65536;
            obs_OBJECT_WORK2.move_flag |= 8448U;
            obs_OBJECT_WORK2.disp_flag &= 4294967039U;
            obs_OBJECT_WORK2.user_work = 0U;
            obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsRingGateNumMain );
            obs_OBJECT_WORK2.dir.y = 49152;
            obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GATENUM10" );
            gms_EFFECT_3DNN_WORK = ( AppMain.GMS_EFFECT_3DNN_WORK )obs_OBJECT_WORK2;
            obs_OBJECT_WORK2.user_timer = ( int )( obs_OBJECT_WORK.user_work / 10U );
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_ss_ringgate_obj_3d_list[2 + obs_OBJECT_WORK2.user_timer], gms_EFFECT_3DNN_WORK.obj_3d );
            obs_OBJECT_WORK2.pos.z = -65536;
            obs_OBJECT_WORK2.move_flag |= 8448U;
            obs_OBJECT_WORK2.disp_flag &= 4294967039U;
            obs_OBJECT_WORK2.user_work = 1U;
            obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsRingGateNumMain );
            obs_OBJECT_WORK2.dir.y = 49152;
            obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK( () => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GATENUM1" );
            gms_EFFECT_3DNN_WORK = ( AppMain.GMS_EFFECT_3DNN_WORK )obs_OBJECT_WORK2;
            obs_OBJECT_WORK2.user_timer = ( int )( obs_OBJECT_WORK.user_work % 10U );
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_ss_ringgate_obj_3d_list[2 + obs_OBJECT_WORK2.user_timer], gms_EFFECT_3DNN_WORK.obj_3d );
            obs_OBJECT_WORK2.pos.z = -65536;
            obs_OBJECT_WORK2.move_flag |= 8448U;
            obs_OBJECT_WORK2.disp_flag &= 4294967039U;
            obs_OBJECT_WORK2.user_work = 2U;
            obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsRingGateNumMain );
            obs_OBJECT_WORK2.dir.y = 49152;
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsRingGateMain );
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSsRingGateDefFunc );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -20, -52, 20, 52 );
            obs_OBJECT_WORK.dir.z = 16384;
        }
        else
        {
            AppMain.ObjRectWorkSet( obs_RECT_WORK, -52, -20, 52, 20 );
        }
        obs_RECT_WORK.flag |= 1024U;
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            col_work.obj_col.width = 24;
            col_work.obj_col.height = 96;
        }
        else
        {
            col_work.obj_col.width = 96;
            col_work.obj_col.height = 24;
        }
        col_work.obj_col.ofst_x = ( short )( -( short )( col_work.obj_col.width / 2 ) );
        col_work.obj_col.ofst_y = ( short )( -( short )( col_work.obj_col.height / 2 ) );
        col_work.obj_col.attr = 2;
        col_work.obj_col.flag |= 134217760U;
        if ( ( ushort )obs_OBJECT_WORK.user_work <= ( ushort )AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].ring_num )
        {
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = null;
            obs_OBJECT_WORK.ppFunc = null;
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000B18 RID: 2840 RVA: 0x00063DFC File Offset: 0x00061FFC
    public static void GmGmkSsRingGateBuild()
    {
        AppMain.gm_gmk_ss_ringgate_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 917 ), AppMain.GmGameDatGetGimmickData( 918 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(920);
        AppMain.gm_gmk_ss_ringgate_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06000B19 RID: 2841 RVA: 0x00063E3C File Offset: 0x0006203C
    public static void GmGmkSsRingGateFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(917);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_ss_ringgate_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_ss_ringgate_obj_tvx_list = null;
    }

    // Token: 0x06000B1A RID: 2842 RVA: 0x00063E6C File Offset: 0x0006206C
    private static void gmGmkSsRingGateMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        uint num = obj_work.user_flag >> 8 & 127U;
        num += 1U;
        obj_work.user_flag = ( ( obj_work.user_flag & 1U ) | ( num & 127U ) << 8 );
        if ( ( ushort )obj_work.user_work <= ( ushort )gms_PLAYER_WORK.ring_num )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = null;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSsRingGateVanish );
            obj_work.disp_flag |= 134217728U;
            obj_work.obj_3d.drawflag |= 8388608U;
            obj_work.obj_3d.draw_state.alpha.alpha = 1f;
            obj_work.user_timer = 20;
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate(obj_work, 5, 9);
            AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, 0f, 0f, 8f );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.dir.z = obj_work.dir.z;
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 512U;
        }
    }

    // Token: 0x06000B1B RID: 2843 RVA: 0x00063FB0 File Offset: 0x000621B0
    private static void gmGmkSsRingGateVanish( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer--;
        if ( obj_work.user_timer == 8 )
        {
            obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
            AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
            AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_ss_ringgate_obj_3d_list[1], ( ( AppMain.GMS_ENEMY_3D_WORK )obj_work ).obj_3d );
        }
        if ( ( float )obj_work.user_timer > 4f )
        {
            obj_work.obj_3d.draw_state.alpha.alpha = ( float )obj_work.user_timer / 20f;
            return;
        }
        obj_work.obj_3d.draw_state.alpha.alpha = 0.2f;
        obj_work.ppFunc = null;
    }

    // Token: 0x06000B1C RID: 2844 RVA: 0x00064058 File Offset: 0x00062258
    private static void gmGmkSsRingGateDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
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
        if ( gms_PLAYER_WORK.gmk_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_COM_WORK )
        {
            return;
        }
        int v = AppMain.FX_Mul(gms_PLAYER_WORK.obj_work.spd.x, 5120);
        int num = AppMain.FX_Mul(gms_PLAYER_WORK.obj_work.spd.y, 5120);
        short num2 = (short)AppMain.GmMainGetObjectRotation();
        if ( ( gms_ENEMY_COM_WORK.obj_work.user_flag & 1U ) != 0U )
        {
            if ( num2 > 0 )
            {
                num2 -= 16384;
            }
            else
            {
                num2 += 16384;
            }
        }
        num2 *= 2;
        num = -num;
        int num3 = AppMain.FX_Mul(v, AppMain.mtMathCos((int)num2));
        num3 += AppMain.FX_Mul( num, AppMain.mtMathSin( ( int )num2 ) );
        int num4 = AppMain.FX_Mul(num, AppMain.mtMathCos((int)num2));
        num4 -= AppMain.FX_Mul( v, AppMain.mtMathSin( ( int )num2 ) );
        gms_PLAYER_WORK.obj_work.spd.x = num3;
        gms_PLAYER_WORK.obj_work.spd.y = num4;
        gms_PLAYER_WORK.obj_work.spd_m = AppMain.FX_Mul( -gms_PLAYER_WORK.obj_work.spd_m, 5120 );
        AppMain.GMM_PAD_VIB_MID_TIME( 60f );
        gms_PLAYER_WORK.player_flag &= 4294967280U;
        gms_PLAYER_WORK.player_flag |= 1U;
    }

    // Token: 0x06000B1D RID: 2845 RVA: 0x000641C4 File Offset: 0x000623C4
    private static void gmGmkSsRingGateNumMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obj_work;
        if ( parent_obj.user_timer < 8 )
        {
            obj_work.flag |= 4U;
            return;
        }
        int num = (int)((ulong)parent_obj.user_work - (ulong)((long)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].ring_num));
        num = AppMain.MTM_MATH_CLIP( num, 0, 99 );
        if ( obj_work.user_work == 1U && num < 10 )
        {
            obj_work.disp_flag |= 32U;
            return;
        }
        bool flag = false;
        switch ( obj_work.user_work )
        {
            case 1U:
                if ( obj_work.user_timer != num / 10 )
                {
                    obj_work.user_timer = num / 10;
                    flag = true;
                }
                break;
            case 2U:
                if ( obj_work.user_timer != num % 10 )
                {
                    obj_work.user_timer = num % 10;
                    flag = true;
                }
                break;
        }
        if ( flag )
        {
            AppMain.ObjAction3dNNMotionRelease( obj_work.obj_3d );
            AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
            AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_ss_ringgate_obj_3d_list[2 + obj_work.user_timer], gms_EFFECT_3DNN_WORK.obj_3d );
        }
        obj_work.dir.z = AppMain.GmMainGetObjectRotation();
        obj_work.disp_flag |= ( parent_obj.disp_flag & 134217728U );
        obj_work.obj_3d.drawflag |= ( parent_obj.obj_3d.drawflag & 8388608U );
        obj_work.obj_3d.draw_state.alpha.alpha = parent_obj.obj_3d.draw_state.alpha.alpha;
        int num2 = parent_obj.pos.x;
        int num3 = parent_obj.pos.y;
        switch ( obj_work.user_work )
        {
            case 0U:
                num2 += AppMain.FX_Mul( -36864, AppMain.mtMathCos( ( int )obj_work.dir.z ) );
                num3 += AppMain.FX_Mul( -36864, AppMain.mtMathSin( ( int )obj_work.dir.z ) );
                break;
            case 2U:
                num2 += AppMain.FX_Mul( 36864, AppMain.mtMathCos( ( int )obj_work.dir.z ) );
                num3 += AppMain.FX_Mul( 36864, AppMain.mtMathSin( ( int )obj_work.dir.z ) );
                break;
        }
        obj_work.pos.x = num2;
        obj_work.pos.y = num3;
    }

    // Token: 0x06000B1E RID: 2846 RVA: 0x00064400 File Offset: 0x00062600
    private static void gmGmkSsRingGateDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.TVX_FILE tvx_FILE;
        if ( AppMain.gm_gmk_ss_ringgate_obj_tvx_list.buf[0] == null )
        {
            tvx_FILE = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_ss_ringgate_obj_tvx_list, 0 ) );
            AppMain.gm_gmk_ss_ringgate_obj_tvx_list.buf[0] = tvx_FILE;
        }
        else
        {
            tvx_FILE = ( AppMain.TVX_FILE )AppMain.gm_gmk_ss_ringgate_obj_tvx_list.buf[0];
        }
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        uint num = AppMain.GMD_TVX_DISP_LIGHT_DISABLE;
        uint num2 = 0U;
        if ( obj_work.dir.z != 0 )
        {
            num |= AppMain.GMD_TVX_DISP_ROTATE;
            num2 = ( uint )obj_work.dir.z;
        }
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        uint num3 = obj_work.user_flag >> 13 & 3U;
        gms_TVX_EX_WORK.u_wrap = 0;
        gms_TVX_EX_WORK.v_wrap = 0;
        gms_TVX_EX_WORK.coord.u = -0.25f * num3;
        gms_TVX_EX_WORK.coord.v = 0f;
        gms_TVX_EX_WORK.color = uint.MaxValue;
        AppMain.GmTvxSetModelEx( tvx_FILE, texlist, ref obj_work.pos, ref obj_work.scale, num, ( short )num2, ref gms_TVX_EX_WORK );
    }
}
