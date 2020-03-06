using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x020003CF RID: 975
    public class GmkPopSteamData
    {
        // Token: 0x04006225 RID: 25125
        public const int GME_GMK_RECT_DATA_DEF_LEFT = 0;

        // Token: 0x04006226 RID: 25126
        public const int GME_GMK_RECT_DATA_DEF_TOP = 1;

        // Token: 0x04006227 RID: 25127
        public const int GME_GMK_RECT_DATA_DEF_RIGHT = 2;

        // Token: 0x04006228 RID: 25128
        public const int GME_GMK_RECT_DATA_DEF_BOTTOM = 3;

        // Token: 0x04006229 RID: 25129
        public const int GME_GMK_RECT_DATA_MAX = 4;

        // Token: 0x0400622A RID: 25130
        public const int GME_GMK_TYPE_MAX = 4;
    }

    // Token: 0x020003D0 RID: 976
    public class GMS_GMK_P_STEAM_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002849 RID: 10313 RVA: 0x00152AC9 File Offset: 0x00150CC9
        public GMS_GMK_P_STEAM_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600284A RID: 10314 RVA: 0x00152AE9 File Offset: 0x00150CE9
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0400622B RID: 25131
        public const int GMD_GMK_PSTEAM_STAT_HIT = 1;

        // Token: 0x0400622C RID: 25132
        public const int GMD_GMK_PSTEAM_STAT_TRUE = 2;

        // Token: 0x0400622D RID: 25133
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x0400622E RID: 25134
        public int obj_type;

        // Token: 0x0400622F RID: 25135
        public short timer;

        // Token: 0x04006230 RID: 25136
        public ushort steamvect;

        // Token: 0x04006231 RID: 25137
        public short steamsize;

        // Token: 0x04006232 RID: 25138
        public short steamwait;

        // Token: 0x04006233 RID: 25139
        public int steampower;

        // Token: 0x04006234 RID: 25140
        public ushort status;

        // Token: 0x04006235 RID: 25141
        public AppMain.GMS_PLAYER_WORK ply_work;

        // Token: 0x04006236 RID: 25142
        public AppMain.OBS_OBJECT_WORK opt_timer;

        // Token: 0x04006237 RID: 25143
        public AppMain.OBS_OBJECT_WORK opt_steam;

        // Token: 0x04006238 RID: 25144
        public AppMain.OBS_OBJECT_WORK[] opt_steam_int = new AppMain.OBS_OBJECT_WORK[3];

        // Token: 0x04006239 RID: 25145
        public int pos_x;

        // Token: 0x0400623A RID: 25146
        public int pos_y;
    }

    // Token: 0x020003D1 RID: 977
    public class GMS_GMK_POPSTEAMPARTS_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600284B RID: 10315 RVA: 0x00152AFB File Offset: 0x00150CFB
        public GMS_GMK_POPSTEAMPARTS_WORK()
        {
            this.eff_work = new AppMain.GMS_EFFECT_3DNN_WORK( this );
        }

        // Token: 0x0600284C RID: 10316 RVA: 0x00152B0F File Offset: 0x00150D0F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_work.efct_com.obj_work;
        }

        // Token: 0x0400623B RID: 25147
        public readonly AppMain.GMS_EFFECT_3DNN_WORK eff_work;

        // Token: 0x0400623C RID: 25148
        public int z_off;
    }

    // Token: 0x06001B32 RID: 6962 RVA: 0x000F86BC File Offset: 0x000F68BC
    private static AppMain.OBS_OBJECT_WORK GmGmkPopSteamUInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkPopSteamInit(eve_rec, pos_x, pos_y, type, 0);
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamStart );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B33 RID: 6963 RVA: 0x000F86E8 File Offset: 0x000F68E8
    private static AppMain.OBS_OBJECT_WORK GmGmkPopSteamRInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkPopSteamInit(eve_rec, pos_x, pos_y, type, 1);
        obs_OBJECT_WORK.dir.z = 16384;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamStart );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B34 RID: 6964 RVA: 0x000F8724 File Offset: 0x000F6924
    private static AppMain.OBS_OBJECT_WORK GmGmkPopSteamDInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkPopSteamInit(eve_rec, pos_x, pos_y, type, 2);
        obs_OBJECT_WORK.dir.z = 32768;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamStart );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B35 RID: 6965 RVA: 0x000F8760 File Offset: 0x000F6960
    private static AppMain.OBS_OBJECT_WORK GmGmkPopSteamLInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkPopSteamInit(eve_rec, pos_x, pos_y, type, 3);
        obs_OBJECT_WORK.dir.z = 49152;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamStart );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B36 RID: 6966 RVA: 0x000F879B File Offset: 0x000F699B
    public static void GmGmkPopSteamBuild()
    {
        AppMain.gm_gmk_popsteam_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 926 ), AppMain.GmGameDatGetGimmickData( 927 ), 0U );
    }

    // Token: 0x06001B37 RID: 6967 RVA: 0x000F87BC File Offset: 0x000F69BC
    public static void GmGmkPopSteamFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(926);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_popsteam_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001B38 RID: 6968 RVA: 0x000F87E4 File Offset: 0x000F69E4
    private static void gmGmkBeltPopSteam_ppOutUseDirModel( AppMain.OBS_OBJECT_WORK obj_work )
    {
        ushort z = obj_work.dir.z;
        obj_work.dir.z = 0;
        AppMain.ObjDrawActionSummary( obj_work );
        obj_work.dir.z = z;
    }

    // Token: 0x06001B39 RID: 6969 RVA: 0x000F881C File Offset: 0x000F6A1C
    private static void _gmGmkPopSteam( AppMain.GMS_GMK_P_STEAM_WORK pwork )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( ( pwork.status & 1 ) != 0 )
        {
            if ( gms_PLAYER_WORK.seq_state == 24 )
            {
                pwork.ply_work = null;
                pwork.status &= 65532;
                return;
            }
            int num;
            int num2;
            if ( ( pwork.steamvect & 16384 ) != 0 )
            {
                num = 0;
                num2 = pwork.steampower;
                if ( ( pwork.steamvect & 32768 ) != 0 )
                {
                    num2 = -num2;
                }
            }
            else
            {
                num2 = 0;
                num = pwork.steampower;
                if ( ( pwork.steamvect & 32768 ) != 0 )
                {
                    num = -num;
                }
            }
            AppMain.GmPlySeqGmkInitPopSteamJump( gms_PLAYER_WORK, num, num2, ( int )pwork.gmk_work.ene_com.eve_rec.top << 13 );
            if ( ( pwork.status & 2 ) == 0 )
            {
                AppMain.GmSoundPlaySE( "Steam" );
                AppMain.GMM_PAD_VIB_SMALL();
            }
            pwork.status |= 2;
        }
        else
        {
            pwork.status &= 65533;
        }
        pwork.status &= 65534;
    }

    // Token: 0x06001B3A RID: 6970 RVA: 0x000F891D File Offset: 0x000F6B1D
    private static void gmGmkPopSteamStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamStay_100 );
        AppMain.gmGmkPopSteamStay_100( obj_work );
    }

    // Token: 0x06001B3B RID: 6971 RVA: 0x000F8938 File Offset: 0x000F6B38
    private static void gmGmkPopSteamStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK pwork = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work;
        AppMain._gmGmkPopSteam( pwork );
    }

    // Token: 0x06001B3C RID: 6972 RVA: 0x000F8954 File Offset: 0x000F6B54
    private static void gmGmkPopSteamInterval( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work;
        obj_work.flag &= 4294967293U;
        gms_GMK_P_STEAM_WORK.opt_steam = ( AppMain.OBS_OBJECT_WORK )AppMain.GmEfctCmnEsCreate( obj_work, ( int )AppMain.tbl_popsteam_effct[0][( int )gms_GMK_P_STEAM_WORK.steamsize] );
        gms_GMK_P_STEAM_WORK.opt_steam.dir.z = obj_work.dir.z;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamInterval_100 );
        AppMain.gmGmkPopSteamInterval_100( obj_work );
    }

    // Token: 0x06001B3D RID: 6973 RVA: 0x000F89CC File Offset: 0x000F6BCC
    private static void gmGmkPopSteamInterval_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work;
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK2 = gms_GMK_P_STEAM_WORK;
        gms_GMK_P_STEAM_WORK2.timer -= ( short )( gms_GMK_P_STEAM_WORK.steamwait / 60 );
        if ( gms_GMK_P_STEAM_WORK.timer <= 0 )
        {
            if ( gms_GMK_P_STEAM_WORK.opt_steam != null )
            {
                AppMain.ObjDrawKillAction3DES( gms_GMK_P_STEAM_WORK.opt_steam );
                gms_GMK_P_STEAM_WORK.opt_steam = null;
            }
            gms_GMK_P_STEAM_WORK.timer = 0;
            AppMain.gmGmkPopSteamWait( obj_work );
            return;
        }
        AppMain._gmGmkPopSteam( gms_GMK_P_STEAM_WORK );
    }

    // Token: 0x06001B3E RID: 6974 RVA: 0x000F8A30 File Offset: 0x000F6C30
    private static void gmGmkPopSteamWait( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work;
        for ( int i = 0; i < 3; i++ )
        {
            gms_GMK_P_STEAM_WORK.opt_steam_int[i] = null;
        }
        obj_work.flag |= 2U;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamWait_100 );
        AppMain.gmGmkPopSteamWait_100( obj_work );
    }

    // Token: 0x06001B3F RID: 6975 RVA: 0x000F8A80 File Offset: 0x000F6C80
    private static void gmGmkPopSteamWait_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work;
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK2 = gms_GMK_P_STEAM_WORK;
        gms_GMK_P_STEAM_WORK2.timer += 1;
        if ( gms_GMK_P_STEAM_WORK.timer >= gms_GMK_P_STEAM_WORK.steamwait )
        {
            if ( gms_GMK_P_STEAM_WORK.opt_steam_int[0] != null )
            {
                for ( int i = 0; i < 3; i++ )
                {
                    AppMain.ObjDrawKillAction3DES( gms_GMK_P_STEAM_WORK.opt_steam_int[i] );
                    gms_GMK_P_STEAM_WORK.opt_steam_int[i] = null;
                }
            }
            obj_work.user_timer = 0;
            obj_work.pos.x = gms_GMK_P_STEAM_WORK.pos_x;
            obj_work.pos.y = gms_GMK_P_STEAM_WORK.pos_y;
            AppMain.gmGmkPopSteamInterval( obj_work );
            return;
        }
        if ( gms_GMK_P_STEAM_WORK.timer >= gms_GMK_P_STEAM_WORK.steamwait * 3 / 4 )
        {
            obj_work.pos.x = gms_GMK_P_STEAM_WORK.pos_x + ( ( int )AppMain.tbl_psteam_viv[obj_work.user_timer][0] << 12 );
            obj_work.pos.y = gms_GMK_P_STEAM_WORK.pos_y + ( ( int )AppMain.tbl_psteam_viv[obj_work.user_timer][1] << 12 );
            obj_work.user_timer++;
            obj_work.user_timer %= 10;
        }
        AppMain._gmGmkPopSteam( gms_GMK_P_STEAM_WORK );
    }

    // Token: 0x06001B40 RID: 6976 RVA: 0x000F8B88 File Offset: 0x000F6D88
    private static void _ModgmGmkPopSteamStart( AppMain.GMS_GMK_P_STEAM_WORK pwork, ref short u )
    {
        if ( pwork.steamsize == 2 )
        {
            u /= 96;
            u *= 128;
            return;
        }
        if ( pwork.steamsize == 0 )
        {
            u /= 96;
            u *= 64;
        }
    }

    // Token: 0x06001B41 RID: 6977 RVA: 0x000F8BC0 File Offset: 0x000F6DC0
    private static void gmGmkPopSteamStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work;
        gms_GMK_P_STEAM_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
        gms_GMK_P_STEAM_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_P_STEAM_WORK.gmk_work.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkPopSteamHit );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_upbumper_rect[gms_GMK_P_STEAM_WORK.obj_type][0], AppMain.tbl_gm_gmk_upbumper_rect[gms_GMK_P_STEAM_WORK.obj_type][1], AppMain.tbl_gm_gmk_upbumper_rect[gms_GMK_P_STEAM_WORK.obj_type][2], AppMain.tbl_gm_gmk_upbumper_rect[gms_GMK_P_STEAM_WORK.obj_type][3] );
        obs_RECT_WORK.flag &= 4294966271U;
        obj_work.flag &= 4294967293U;
        switch ( gms_GMK_P_STEAM_WORK.obj_type )
        {
            case 0:
                obj_work.dir.z = 0;
                gms_GMK_P_STEAM_WORK.steamvect = 49152;
                AppMain._ModgmGmkPopSteamStart( gms_GMK_P_STEAM_WORK, ref obs_RECT_WORK.rect.top );
                break;
            case 1:
                obj_work.dir.z = 16384;
                gms_GMK_P_STEAM_WORK.steamvect = 0;
                AppMain._ModgmGmkPopSteamStart( gms_GMK_P_STEAM_WORK, ref obs_RECT_WORK.rect.right );
                break;
            case 2:
                obj_work.dir.z = 32768;
                gms_GMK_P_STEAM_WORK.steamvect = 16384;
                AppMain._ModgmGmkPopSteamStart( gms_GMK_P_STEAM_WORK, ref obs_RECT_WORK.rect.bottom );
                break;
            case 3:
                obj_work.dir.z = 49152;
                gms_GMK_P_STEAM_WORK.steamvect = 32768;
                AppMain._ModgmGmkPopSteamStart( gms_GMK_P_STEAM_WORK, ref obs_RECT_WORK.rect.left );
                break;
            default:
                AppMain._ModgmGmkPopSteamStart( gms_GMK_P_STEAM_WORK, ref obs_RECT_WORK.rect.top );
                break;
        }
        gms_GMK_P_STEAM_WORK.timer = 0;
        gms_GMK_P_STEAM_WORK.status = 0;
        gms_GMK_P_STEAM_WORK.opt_steam = null;
        gms_GMK_P_STEAM_WORK.pos_x = obj_work.pos.x;
        gms_GMK_P_STEAM_WORK.pos_y = obj_work.pos.y;
        if ( gms_GMK_P_STEAM_WORK.steamwait > 0 )
        {
            uint num = AppMain.g_gm_main_system.sync_time;
            num %= ( uint )( gms_GMK_P_STEAM_WORK.steamwait + 60 );
            if ( num < 60U )
            {
                gms_GMK_P_STEAM_WORK.timer = ( short )( ( ulong )num * ( ulong )( ( long )gms_GMK_P_STEAM_WORK.steamwait ) / 60UL );
                AppMain.gmGmkPopSteamInterval( obj_work );
            }
            else
            {
                gms_GMK_P_STEAM_WORK.timer = ( short )( ( long )gms_GMK_P_STEAM_WORK.steamwait - ( long )( ( ulong )( num - 60U ) ) );
                AppMain.gmGmkPopSteamWait( obj_work );
            }
            AppMain.create_steampipe( obj_work, gms_GMK_P_STEAM_WORK.obj_type );
            gms_GMK_P_STEAM_WORK.opt_timer = AppMain.create_steamtimer( obj_work, gms_GMK_P_STEAM_WORK.obj_type );
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(obj_work, (int)AppMain.tbl_popsteam_effct[1][(int)gms_GMK_P_STEAM_WORK.steamsize]);
        obs_OBJECT_WORK.dir.z = obj_work.dir.z;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z - 4096;
        AppMain.gmGmkPopSteamStay( obj_work );
    }

    // Token: 0x06001B42 RID: 6978 RVA: 0x000F8E9C File Offset: 0x000F709C
    private static void gmGmkPopSteamHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] )
        {
            gms_GMK_P_STEAM_WORK.ply_work = gms_PLAYER_WORK;
            AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK2 = gms_GMK_P_STEAM_WORK;
            gms_GMK_P_STEAM_WORK2.status |= 1;
        }
        mine_rect.flag &= 4294573823U;
    }

    // Token: 0x06001B43 RID: 6979 RVA: 0x000F8F00 File Offset: 0x000F7100
    private static void create_steampipe( AppMain.OBS_OBJECT_WORK parent_obj, int obj_type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_POPSTEAMPARTS_WORK(), null, 0, "Gmk_PopSteamPipe");
        AppMain.GMS_GMK_POPSTEAMPARTS_WORK gms_GMK_POPSTEAMPARTS_WORK = (AppMain.GMS_GMK_POPSTEAMPARTS_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_popsteam_obj_3d_list[AppMain.tbl_popsteam_pipe_model_id[obj_type]], gms_GMK_POPSTEAMPARTS_WORK.eff_work.obj_3d );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBeltPopSteam_ppOutUseDirModel );
        obs_OBJECT_WORK.parent_obj = parent_obj;
        obs_OBJECT_WORK.pos.x = parent_obj.pos.x + AppMain.tbl_popsteam_pipe_off[obj_type][0];
        obs_OBJECT_WORK.pos.y = parent_obj.pos.y + AppMain.tbl_popsteam_pipe_off[obj_type][1];
        obs_OBJECT_WORK.pos.z = parent_obj.pos.z - 65536;
        obs_OBJECT_WORK.dir.z = parent_obj.dir.z;
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.disp_flag &= 4294967039U;
        obs_OBJECT_WORK.ppFunc = null;
    }

    // Token: 0x06001B44 RID: 6980 RVA: 0x000F9038 File Offset: 0x000F7238
    private static void gmGmkPopSteamTimer( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obj_work.parent_obj;
        uint num = 65536U;
        int num2 = 4096;
        num *= ( uint )gms_GMK_P_STEAM_WORK.timer;
        num /= ( uint )gms_GMK_P_STEAM_WORK.steamwait;
        obj_work.dir.z = obj_work.parent_obj.dir.z;
        obj_work.dir.z = ( ushort )( obj_work.dir.z + ( ushort )num );
        num2 += ( int )num;
        obj_work.parent_ofst.z = num2 >> 3;
        obj_work.ofst.x = obj_work.parent_obj.ofst.x;
        obj_work.ofst.y = obj_work.parent_obj.ofst.x;
    }

    // Token: 0x06001B45 RID: 6981 RVA: 0x000F90F0 File Offset: 0x000F72F0
    private static AppMain.OBS_OBJECT_WORK create_steamtimer( AppMain.OBS_OBJECT_WORK parent_obj, int obj_type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_GMK_POPSTEAMPARTS_WORK(), null, 0, "Gmk_PopSteamTimer");
        AppMain.GMS_GMK_POPSTEAMPARTS_WORK gms_GMK_POPSTEAMPARTS_WORK = (AppMain.GMS_GMK_POPSTEAMPARTS_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_popsteam_obj_3d_list[12], gms_GMK_POPSTEAMPARTS_WORK.eff_work.obj_3d );
        obs_OBJECT_WORK.parent_obj = parent_obj;
        obs_OBJECT_WORK.parent_ofst.x = AppMain.tbl_popsteam_timer_off[obj_type][0];
        obs_OBJECT_WORK.parent_ofst.y = AppMain.tbl_popsteam_timer_off[obj_type][1];
        obs_OBJECT_WORK.parent_ofst.z = 0;
        obs_OBJECT_WORK.dir.z = parent_obj.dir.z;
        obs_OBJECT_WORK.flag |= 1024U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.disp_flag &= 4294967039U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPopSteamTimer );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B46 RID: 6982 RVA: 0x000F91FC File Offset: 0x000F73FC
    private static AppMain.OBS_OBJECT_WORK gmGmkPopSteamInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, int obj_type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_P_STEAM_WORK(), "Gmk_PopSteam");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        int num = AppMain.tbl_popsteam_model_id[obj_type][0];
        if ( eve_rec.height == 0 )
        {
            num = AppMain.tbl_popsteam_model_id[obj_type][1];
        }
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_popsteam_obj_3d_list[num], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBeltPopSteam_ppOutUseDirModel );
        obs_OBJECT_WORK.pos.z = 622592;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.GMS_GMK_P_STEAM_WORK gms_GMK_P_STEAM_WORK = (AppMain.GMS_GMK_P_STEAM_WORK)obs_OBJECT_WORK;
        if ( ( eve_rec.flag & 3 ) == 2 )
        {
            gms_GMK_P_STEAM_WORK.steamsize = 2;
        }
        else if ( ( eve_rec.flag & 3 ) == 1 )
        {
            gms_GMK_P_STEAM_WORK.steamsize = 0;
        }
        else
        {
            gms_GMK_P_STEAM_WORK.steamsize = 1;
        }
        gms_GMK_P_STEAM_WORK.steampower = ( int )( eve_rec.width * 2 );
        gms_GMK_P_STEAM_WORK.steampower <<= 12;
        if ( gms_GMK_P_STEAM_WORK.steampower == 0 )
        {
            gms_GMK_P_STEAM_WORK.steampower = 61440;
        }
        gms_GMK_P_STEAM_WORK.steamwait = ( short )( eve_rec.height * 2 );
        gms_GMK_P_STEAM_WORK.obj_type = obj_type;
        return obs_OBJECT_WORK;
    }
}
