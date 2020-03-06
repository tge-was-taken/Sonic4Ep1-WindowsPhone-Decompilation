using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000246 RID: 582
    public class GMS_GMK_STEAMP_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060023B0 RID: 9136 RVA: 0x001494D7 File Offset: 0x001476D7
        public GMS_GMK_STEAMP_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060023B1 RID: 9137 RVA: 0x001494EB File Offset: 0x001476EB
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x04005825 RID: 22565
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04005826 RID: 22566
        public int obj_type;

        // Token: 0x04005827 RID: 22567
        public int zdepth;

        // Token: 0x04005828 RID: 22568
        public AppMain.GMS_PLAYER_WORK ply_work;

        // Token: 0x04005829 RID: 22569
        public short timer;

        // Token: 0x0400582A RID: 22570
        public byte status;
    }

    // Token: 0x06001218 RID: 4632 RVA: 0x0009E500 File Offset: 0x0009C700
    private static AppMain.OBS_OBJECT_WORK GmGmkSpipeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_COM_WORK(), "GMK_S_PIPE");
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.move_flag |= 8480U;
        obs_OBJECT_WORK.pos.z = -131072;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_COM_WORK.rect_work[2];
        AppMain.ObjRectGroupSet( obs_RECT_WORK, 1, 1 );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 1 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectSet( obs_RECT_WORK.rect, ( short )( eve_rec.left * 2 ), ( short )( eve_rec.top * 2 ), ( short )( ( ushort )( eve_rec.width * 2 ) + ( ushort )( ( short )( eve_rec.left * 2 ) ) ), ( short )( ( ushort )( eve_rec.height * 2 ) + ( ushort )( ( short )( eve_rec.top * 2 ) ) ) );
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSpipeDefFunc );
        obs_RECT_WORK.parent_obj = obs_OBJECT_WORK;
        obs_RECT_WORK.flag |= 192U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001219 RID: 4633 RVA: 0x0009E5F8 File Offset: 0x0009C7F8
    private static void gmGmkSpipeDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state != 37 )
        {
            AppMain.GmPlySeqInitSpipe( gms_PLAYER_WORK );
        }
        gms_PLAYER_WORK.gmk_flag |= 65536U;
    }

    // Token: 0x06000DAA RID: 3498 RVA: 0x0007888C File Offset: 0x00076A8C
    private static void gmGmkSteamGateHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] && ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U )
        {
            AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)parent_obj;
            gms_PLAYER_WORK.obj_work.pos.y = parent_obj.pos.y;
            AppMain.GmPlySeqInitSteamPipeIn( gms_PLAYER_WORK );
            gms_GMK_STEAMP_WORK.status = 1;
            gms_GMK_STEAMP_WORK.ply_work = gms_PLAYER_WORK;
            parent_obj.flag |= 2U;
            AppMain.GMM_PAD_VIB_SMALL_TIME( 60f );
        }
        mine_rect.flag &= 4294573823U;
    }

    // Token: 0x06000DAB RID: 3499 RVA: 0x0007892C File Offset: 0x00076B2C
    private static void gmGmkSteamExitHit( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_PLAYER_WORK == AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )] && gms_PLAYER_WORK.seq_state == 57 && ( gms_PLAYER_WORK.player_flag & 1024U ) == 0U )
        {
            AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)parent_obj;
            gms_PLAYER_WORK.obj_work.spd.x = ( gms_PLAYER_WORK.obj_work.spd.y = 0 );
            gms_GMK_STEAMP_WORK.status = 1;
            gms_GMK_STEAMP_WORK.ply_work = gms_PLAYER_WORK;
            parent_obj.flag |= 2U;
        }
    }

    // Token: 0x06000DAC RID: 3500 RVA: 0x000789BC File Offset: 0x00076BBC
    private static void gmGmkSteamCrankCheck( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.obj_work.pos.x < obj_work.pos.x + 65536 && gms_PLAYER_WORK.obj_work.pos.x > obj_work.pos.x - 65536 && gms_PLAYER_WORK.obj_work.pos.y < obj_work.pos.y + 65536 && gms_PLAYER_WORK.obj_work.pos.y > obj_work.pos.y - 65536 )
        {
            if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U || gms_PLAYER_WORK.seq_state != 57 )
            {
                return;
            }
            if ( obj_work.user_flag != 0U )
            {
                return;
            }
            AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
            if ( gms_PLAYER_WORK.obj_work.spd.x != 0 )
            {
                int num = gms_PLAYER_WORK.obj_work.spd.x;
                int num2 = gms_PLAYER_WORK.obj_work.pos.x - num;
                if ( ( num > 0 && ( AppMain.tbl_gmk_pipe_vect[gms_GMK_STEAMP_WORK.obj_type] & 2 ) != 0 && num2 <= obj_work.pos.x && obj_work.pos.x <= gms_PLAYER_WORK.obj_work.pos.x ) || ( num < 0 && ( AppMain.tbl_gmk_pipe_vect[gms_GMK_STEAMP_WORK.obj_type] & 1 ) != 0 && gms_PLAYER_WORK.obj_work.pos.x <= obj_work.pos.x && obj_work.pos.x <= num2 ) )
                {
                    num2 = gms_PLAYER_WORK.obj_work.pos.x - obj_work.pos.x;
                    gms_PLAYER_WORK.obj_work.pos.x = obj_work.pos.x;
                    gms_PLAYER_WORK.obj_work.spd.x = 0;
                    gms_PLAYER_WORK.obj_work.pos.y = obj_work.pos.y;
                    if ( ( AppMain.tbl_gmk_pipe_vect[gms_GMK_STEAMP_WORK.obj_type] & 8 ) == 0 )
                    {
                        gms_PLAYER_WORK.obj_work.spd.y = -61440;
                        AppMain.OBS_OBJECT_WORK obj_work2 = gms_PLAYER_WORK.obj_work;
                        obj_work2.pos.y = obj_work2.pos.y - AppMain.MTM_MATH_ABS( num2 );
                    }
                    else
                    {
                        gms_PLAYER_WORK.obj_work.spd.y = 61440;
                        AppMain.OBS_OBJECT_WORK obj_work3 = gms_PLAYER_WORK.obj_work;
                        obj_work3.pos.y = obj_work3.pos.y + AppMain.MTM_MATH_ABS( num2 );
                    }
                    obj_work.flag |= 2U;
                    AppMain.GmSoundPlaySE( "PipeMoving" );
                    obj_work.user_flag = 1U;
                    return;
                }
            }
            else
            {
                int num = gms_PLAYER_WORK.obj_work.spd.y;
                int num2 = gms_PLAYER_WORK.obj_work.pos.y - num;
                if ( ( num > 0 && ( AppMain.tbl_gmk_pipe_vect[gms_GMK_STEAMP_WORK.obj_type] & 4 ) != 0 && num2 <= obj_work.pos.y && obj_work.pos.y <= gms_PLAYER_WORK.obj_work.pos.y ) || ( num < 0 && ( AppMain.tbl_gmk_pipe_vect[gms_GMK_STEAMP_WORK.obj_type] & 8 ) != 0 && gms_PLAYER_WORK.obj_work.pos.y <= obj_work.pos.y && obj_work.pos.y <= num2 ) )
                {
                    num2 = gms_PLAYER_WORK.obj_work.pos.y - obj_work.pos.y;
                    gms_PLAYER_WORK.obj_work.pos.y = obj_work.pos.y;
                    gms_PLAYER_WORK.obj_work.spd.y = 0;
                    gms_PLAYER_WORK.obj_work.pos.x = obj_work.pos.x;
                    if ( ( AppMain.tbl_gmk_pipe_vect[gms_GMK_STEAMP_WORK.obj_type] & 2 ) == 0 )
                    {
                        gms_PLAYER_WORK.obj_work.spd.x = 61440;
                        AppMain.OBS_OBJECT_WORK obj_work4 = gms_PLAYER_WORK.obj_work;
                        obj_work4.pos.x = obj_work4.pos.x + AppMain.MTM_MATH_ABS( num2 );
                    }
                    else
                    {
                        gms_PLAYER_WORK.obj_work.spd.x = -61440;
                        AppMain.OBS_OBJECT_WORK obj_work5 = gms_PLAYER_WORK.obj_work;
                        obj_work5.pos.x = obj_work5.pos.x - AppMain.MTM_MATH_ABS( num2 );
                    }
                    obj_work.flag |= 2U;
                    AppMain.GmSoundPlaySE( "PipeMoving" );
                    obj_work.user_flag = 1U;
                    return;
                }
            }
        }
        else
        {
            obj_work.user_flag = 0U;
        }
    }

    // Token: 0x06000DAD RID: 3501 RVA: 0x00078E04 File Offset: 0x00077004
    private static void gmGmkSteamPipeStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        switch ( gms_GMK_STEAMP_WORK.obj_type )
        {
            case 0:
            case 1:
            case 2:
            case 3:
                AppMain.gmGmkSteamCrankCheck( obj_work );
                return;
            case 4:
            case 5:
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipeStay_100 );
                return;
            case 6:
            case 7:
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipeStay_Exit );
                return;
        }
        obj_work.ppFunc = null;
    }

    // Token: 0x06000DAE RID: 3502 RVA: 0x00078E88 File Offset: 0x00077088
    private static void gmGmkSteamPipeStay_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        if ( gms_GMK_STEAMP_WORK.status != 0 )
        {
            switch ( gms_GMK_STEAMP_WORK.obj_type )
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 8:
                case 9:
                case 10:
                    break;
                case 4:
                case 5:
                    gms_GMK_STEAMP_WORK.timer = 60;
                    obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipe_GateIn );
                    AppMain.GmSoundPlaySE( "PipeIn" );
                    return;
                case 6:
                case 7:
                    gms_GMK_STEAMP_WORK.timer = 0;
                    AppMain.gmGmkSteamPipe_GateOutColClear( obj_work );
                    obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipe_GateOut );
                    break;
                default:
                    return;
            }
        }
    }

    // Token: 0x06000DAF RID: 3503 RVA: 0x00078F22 File Offset: 0x00077122
    private static void gmGmkSteamPipeStay_Exit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkSteamPipeStay_100( obj_work );
    }

    // Token: 0x06000DB0 RID: 3504 RVA: 0x00078F2C File Offset: 0x0007712C
    private static void gmGmkSteamPipe_GateIn( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK2 = gms_GMK_STEAMP_WORK;
        gms_GMK_STEAMP_WORK2.timer -= 1;
        if ( gms_GMK_STEAMP_WORK.timer <= 0 )
        {
            int spd_x;
            if ( gms_GMK_STEAMP_WORK.obj_type == 4 )
            {
                spd_x = 61440;
            }
            else
            {
                spd_x = -61440;
            }
            gms_GMK_STEAMP_WORK.ply_work.obj_work.move_flag |= 16U;
            AppMain.GmPlySeqGmkSpdSet( gms_GMK_STEAMP_WORK.ply_work, spd_x, 0 );
            gms_GMK_STEAMP_WORK.ply_work.gmk_flag2 |= 6U;
            AppMain.GmSoundPlaySE( "PipeMoving" );
            obj_work.ppFunc = null;
        }
    }

    // Token: 0x06000DB1 RID: 3505 RVA: 0x00078FBC File Offset: 0x000771BC
    private static void gmGmkSteamPipe_GateOut( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK2 = gms_GMK_STEAMP_WORK;
        gms_GMK_STEAMP_WORK2.timer -= 1;
        if ( gms_GMK_STEAMP_WORK.timer <= 0 )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.GmEfctCmnEsCreate(obj_work, 92);
            obs_OBJECT_WORK.pos.x = obj_work.pos.x;
            obs_OBJECT_WORK.pos.y = obj_work.pos.y;
            int spd_x;
            if ( ( obj_work.user_flag & 1U ) == 0U )
            {
                spd_x = 61440;
                obs_OBJECT_WORK.dir.z = 16384;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
                obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + 229376;
            }
            else
            {
                spd_x = -61440;
                obs_OBJECT_WORK.dir.z = 49152;
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
                obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x - 229376;
            }
            AppMain.GmPlySeqInitSteamPipeOut( gms_GMK_STEAMP_WORK.ply_work, spd_x );
            AppMain.GmSoundPlaySE( "PipeOut" );
            gms_GMK_STEAMP_WORK.timer = 8;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipe_GateOut_100 );
        }
    }

    // Token: 0x06000DB2 RID: 3506 RVA: 0x000790BC File Offset: 0x000772BC
    private static void gmGmkSteamPipe_GateOut_100( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK2 = gms_GMK_STEAMP_WORK;
        gms_GMK_STEAMP_WORK2.timer -= 1;
        if ( gms_GMK_STEAMP_WORK.timer <= 0 )
        {
            AppMain.gmGmkSteamPipe_GateOutColSet( obj_work );
            gms_GMK_STEAMP_WORK.status = 0;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipeStay_Exit );
        }
    }

    // Token: 0x06000DB3 RID: 3507 RVA: 0x00079108 File Offset: 0x00077308
    private static void gmGmkSteamPipe_GateOutColSet( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( ( ( AppMain.GMS_ENEMY_COM_WORK )obj_work ).eve_rec.flag & 2 ) == 0 )
        {
            AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.width = 64;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.height = 64;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = 0;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = -32;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
        }
    }

    // Token: 0x06000DB4 RID: 3508 RVA: 0x000791D8 File Offset: 0x000773D8
    private static void gmGmkSteamPipe_GateOutColClear( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.obj = null;
    }

    // Token: 0x06000DB5 RID: 3509 RVA: 0x00079208 File Offset: 0x00077408
    private static void gmGmkSteamPipeStart( AppMain.OBS_OBJECT_WORK obj_work, int type )
    {
        AppMain.GMS_GMK_STEAMP_WORK gms_GMK_STEAMP_WORK = (AppMain.GMS_GMK_STEAMP_WORK)obj_work;
        if ( type >= 4 && type < 8 )
        {
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.rect_work[0].flag &= 4294967291U;
            gms_GMK_STEAMP_WORK.gmk_work.ene_com.rect_work[1].flag &= 4294967291U;
            AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_GMK_STEAMP_WORK.gmk_work.ene_com.rect_work[2];
            obs_RECT_WORK.ppHit = null;
            if ( type < 6 )
            {
                obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSteamGateHit );
                gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
                gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.width = 32;
                gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.height = 16;
                gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = -14;
                gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = -34;
                gms_GMK_STEAMP_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
            }
            else
            {
                obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSteamExitHit );
            }
            AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
            AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
            AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.tbl_gm_gmk_steampipe_rect[type][0], AppMain.tbl_gm_gmk_steampipe_rect[type][1], AppMain.tbl_gm_gmk_steampipe_rect[type][2], AppMain.tbl_gm_gmk_steampipe_rect[type][3] );
            obs_RECT_WORK.flag |= 4U;
            obj_work.flag &= 4294967293U;
        }
        gms_GMK_STEAMP_WORK.obj_type = type;
        gms_GMK_STEAMP_WORK.status = 0;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSteamPipeStay );
    }

    // Token: 0x06000DB6 RID: 3510 RVA: 0x000793DC File Offset: 0x000775DC
    public static AppMain.OBS_OBJECT_WORK gmGmkSteamPipeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type, ushort model )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_STEAMP_WORK(), "Gmk_SteamPipe");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_steampipe_obj_3d_list[( int )model], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = ( int )( eve_rec.left * 8 ) * 4096;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DB7 RID: 3511 RVA: 0x00079488 File Offset: 0x00077688
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeGateRInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, 1);
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 65536;
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 4 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DB8 RID: 3512 RVA: 0x000794D4 File Offset: 0x000776D4
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeGateLInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, 0);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 65536;
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 5 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DB9 RID: 3513 RVA: 0x0007950C File Offset: 0x0007770C
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeGateEInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model;
        int type2;
        if ( ( eve_rec.flag & 1 ) == 0 )
        {
            model = 2;
            type2 = 6;
        }
        else
        {
            model = 3;
            type2 = 7;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.z = obs_OBJECT_WORK2.pos.z + 131072;
        obs_OBJECT_WORK.user_flag = ( uint )eve_rec.flag;
        if ( ( obs_OBJECT_WORK.user_flag & 1U ) == 0U )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x - 131072;
        }
        else
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
            obs_OBJECT_WORK4.pos.x = obs_OBJECT_WORK4.pos.x + 131072;
        }
        AppMain.gmGmkSteamPipe_GateOutColSet( obs_OBJECT_WORK );
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, type2 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DBA RID: 3514 RVA: 0x000795A4 File Offset: 0x000777A4
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeA1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 4;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 4;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 9 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DBB RID: 3515 RVA: 0x000795D4 File Offset: 0x000777D4
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeA2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 5;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 5;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 8 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DBC RID: 3516 RVA: 0x00079600 File Offset: 0x00077800
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeA3Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 4;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 4;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 9 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DBD RID: 3517 RVA: 0x00079630 File Offset: 0x00077830
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeA4Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 6;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 5;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 8 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DBE RID: 3518 RVA: 0x0007965C File Offset: 0x0007785C
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeB1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 7;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 6;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 9 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DBF RID: 3519 RVA: 0x0007968C File Offset: 0x0007788C
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeB2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 8;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 7;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 8 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC0 RID: 3520 RVA: 0x000796B8 File Offset: 0x000778B8
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeB3Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 7;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 6;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 9 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC1 RID: 3521 RVA: 0x000796E8 File Offset: 0x000778E8
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeB4Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 9;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 7;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 8 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC2 RID: 3522 RVA: 0x00079718 File Offset: 0x00077918
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeJ1Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 10;
        ushort z = 0;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 9;
            z = 16384;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        obs_OBJECT_WORK.dir.z = z;
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 0 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC3 RID: 3523 RVA: 0x0007975C File Offset: 0x0007795C
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeJ2Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 11;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 8;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 1 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC4 RID: 3524 RVA: 0x0007978C File Offset: 0x0007798C
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeJ3Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 12;
        ushort z = 0;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 8;
            z = 16384;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        obs_OBJECT_WORK.dir.z = z;
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 2 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC5 RID: 3525 RVA: 0x000797D0 File Offset: 0x000779D0
    public static AppMain.OBS_OBJECT_WORK GmGmkSteamPipeJ4Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        ushort model = 13;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 4 )
        {
            model = 9;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.gmGmkSteamPipeInit(eve_rec, pos_x, pos_y, type, model);
        AppMain.gmGmkSteamPipeStart( obs_OBJECT_WORK, 3 );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000DC6 RID: 3526 RVA: 0x000797FE File Offset: 0x000779FE
    public static void GmGmkSteamPipeBuild()
    {
        AppMain.gm_gmk_steampipe_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 921 ), AppMain.GmGameDatGetGimmickData( 922 ), 0U );
    }

    // Token: 0x06000DC7 RID: 3527 RVA: 0x00079820 File Offset: 0x00077A20
    public static void GmGmkSteamPipeFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(921);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_steampipe_obj_3d_list, ams_AMB_HEADER.file_num );
    }
}