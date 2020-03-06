using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200024A RID: 586
    public class GMS_ENE_NODE_MATRIX
    {
        // Token: 0x0400583B RID: 22587
        public char[] _id = new char[8];

        // Token: 0x0400583C RID: 22588
        public int initCount;

        // Token: 0x0400583D RID: 22589
        public int useCount;

        // Token: 0x0400583E RID: 22590
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR mtn_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x0400583F RID: 22591
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04005840 RID: 22592
        public int[] work = new int[32];

        // Token: 0x04005841 RID: 22593
        public AppMain.OBS_OBJECT_WORK obj_work;
    }

    // Token: 0x06000096 RID: 150 RVA: 0x00008222 File Offset: 0x00006422
    private static AppMain.OBS_OBJECT_WORK GMM_ENEMY_CREATE_RIDE_WORK( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return AppMain.GmEnemyCreateWork( eve_rec, pos_x, pos_y, work_size, 4342, name );
    }

    // Token: 0x06000097 RID: 151 RVA: 0x00008234 File Offset: 0x00006434
    private static AppMain.OBS_OBJECT_WORK GMM_ENEMY_CREATE_WORK( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return AppMain.GmEnemyCreateWork( eve_rec, pos_x, pos_y, work_size, 5376, name );
    }

    // Token: 0x06000098 RID: 152 RVA: 0x00008250 File Offset: 0x00006450
    private static AppMain.OBS_OBJECT_WORK GmEnemyCreateWork( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.TaskWorkFactoryDelegate work_size, ushort prio, string name )
    {
        ushort[] array = new ushort[]
        {
            default(ushort),
            2,
            1
        };
        ushort[] array2 = new ushort[]
        {
            65533,
            ushort.MaxValue,
            65534
        };
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(prio, 2, 0, 0, work_size, name);
        if ( obs_OBJECT_WORK == null )
        {
            return null;
        }
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.GmEnemyDefaultExit ) );
        if ( eve_rec != null )
        {
            gms_ENEMY_COM_WORK.eve_rec = eve_rec;
            gms_ENEMY_COM_WORK.eve_x = eve_rec.pos_x;
            eve_rec.pos_x = byte.MaxValue;
            if ( eve_rec.id < 60 || ( 300 <= eve_rec.id && eve_rec.id < 300 ) || ( 308 <= eve_rec.id && eve_rec.id < 335 ) )
            {
                obs_OBJECT_WORK.obj_type = 2;
            }
            else
            {
                obs_OBJECT_WORK.obj_type = 3;
            }
            obs_OBJECT_WORK.view_out_ofst = ( short )( AppMain.g_gm_event_size_tbl[( int )eve_rec.id] + 16 + 32 + 16 + 128 );
            if ( ( eve_rec.flag & 2048 ) != 0 )
            {
                obs_OBJECT_WORK.flag |= 16U;
            }
            else
            {
                obs_OBJECT_WORK.ppViewCheck = new AppMain.OBS_OBJECT_WORK_Delegate3( AppMain.ObjObjectViewOutCheck );
            }
        }
        else
        {
            obs_OBJECT_WORK.obj_type = 2;
        }
        obs_OBJECT_WORK.ppOut = AppMain._ObjDrawActionSummary;
        obs_OBJECT_WORK.ppOutSub = null;
        obs_OBJECT_WORK.ppIn = AppMain._GmEnemyDefaultInFunc;
        obs_OBJECT_WORK.ppMove = AppMain._GmEnemyDefaultMoveFunc;
        obs_OBJECT_WORK.ppActCall = AppMain._gmEnemyActionCallBack;
        obs_OBJECT_WORK.ppRec = AppMain._gmEnemyDefaultRecFunc;
        obs_OBJECT_WORK.ppLast = null;
        obs_OBJECT_WORK.ppFunc = null;
        gms_ENEMY_COM_WORK.born_pos_x = pos_x;
        gms_ENEMY_COM_WORK.born_pos_y = pos_y;
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = pos_y;
        obs_OBJECT_WORK.spd_fall = 672;
        obs_OBJECT_WORK.spd_fall_max = 61440;
        obs_OBJECT_WORK.flag |= 1U;
        obs_OBJECT_WORK.move_flag |= 524288U;
        obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = ( obs_OBJECT_WORK.scale.z = 4096 ) );
        AppMain.ObjObjectGetRectBuf( obs_OBJECT_WORK, gms_ENEMY_COM_WORK.rect_work, 3 );
        for ( int i = 0; i < 3; i++ )
        {
            AppMain.ObjRectGroupSet( gms_ENEMY_COM_WORK.rect_work[i], 1, 1 );
            AppMain.ObjRectAtkSet( gms_ENEMY_COM_WORK.rect_work[i], array[i], 1 );
            AppMain.ObjRectDefSet( gms_ENEMY_COM_WORK.rect_work[i], array2[i], 0 );
            gms_ENEMY_COM_WORK.rect_work[i].parent_obj = obs_OBJECT_WORK;
            gms_ENEMY_COM_WORK.rect_work[i].flag &= 4294967291U;
        }
        gms_ENEMY_COM_WORK.rect_work[0].ppDef = AppMain._GmEnemyDefaultDefFunc;
        gms_ENEMY_COM_WORK.rect_work[1].ppHit = AppMain._GmEnemyDefaultAtkFunc;
        gms_ENEMY_COM_WORK.rect_work[0].flag |= 128U;
        gms_ENEMY_COM_WORK.rect_work[2].flag |= 1048800U;
        obs_OBJECT_WORK.col_work = gms_ENEMY_COM_WORK.col_work;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000099 RID: 153 RVA: 0x00008534 File Offset: 0x00006734
    private static void GmEnemyDefaultExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)AppMain.mtTaskGetTcbWork(tcb);
        if ( gms_ENEMY_COM_WORK.eve_rec != null && gms_ENEMY_COM_WORK.eve_rec.pos_x == 255 && gms_ENEMY_COM_WORK.eve_rec.pos_y == 255 )
        {
            AppMain.GmEventMgrLocalEventRelease( gms_ENEMY_COM_WORK.eve_rec );
        }
        else if ( ( gms_ENEMY_COM_WORK.enemy_flag & 65536U ) == 0U && gms_ENEMY_COM_WORK.eve_rec != null )
        {
            gms_ENEMY_COM_WORK.eve_rec.pos_x = gms_ENEMY_COM_WORK.eve_x;
        }
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x0600009A RID: 154 RVA: 0x000085B4 File Offset: 0x000067B4
    private static void GmEnemyActionSet( AppMain.GMS_ENEMY_COM_WORK ene_com, ushort id )
    {
        ene_com.rect_work[0].flag &= 4294967291U;
        ene_com.rect_work[1].flag &= 4294967291U;
        ene_com.rect_work[2].flag &= 4294967291U;
        if ( ene_com.obj_work.obj_3d != null )
        {
            AppMain.ObjDrawObjectActionSet3DNN( ene_com.obj_work, ( int )id, 0 );
        }
    }

    // Token: 0x0600009B RID: 155 RVA: 0x00008620 File Offset: 0x00006820
    private static void GmEnemyDefaultDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = null;
        if ( match_rect.parent_obj != null && match_rect.parent_obj.obj_type == 1 )
        {
            gms_PLAYER_WORK = ( AppMain.GMS_PLAYER_WORK )match_rect.parent_obj;
        }
        if ( gms_ENEMY_COM_WORK.vit == 0 )
        {
            if ( ( gms_ENEMY_COM_WORK.obj_work.move_flag & 4096U ) == 0U || gms_ENEMY_COM_WORK.obj_work.obj_type == 3 )
            {
                gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
            }
            gms_ENEMY_COM_WORK.obj_work.flag |= 2U;
            gms_ENEMY_COM_WORK.rect_work[0].flag |= 2048U;
            gms_ENEMY_COM_WORK.rect_work[1].flag |= 2048U;
            gms_ENEMY_COM_WORK.rect_work[2].flag |= 2048U;
            if ( gms_ENEMY_COM_WORK.obj_work.obj_type == 2 )
            {
                AppMain.GmSoundPlaySE( "Enemy" );
                AppMain.GmComEfctCreateHitPlayer( gms_ENEMY_COM_WORK.obj_work, ( int )( ( mine_rect.rect.left + mine_rect.rect.right ) * 4096 / 2 ), ( int )( ( mine_rect.rect.top + mine_rect.rect.bottom ) * 4096 / 2 ) );
                AppMain.GmComEfctCreateEneDeadSmoke( gms_ENEMY_COM_WORK.obj_work, ( int )( ( mine_rect.rect.left + mine_rect.rect.right ) * 4096 / 2 ), ( int )( ( mine_rect.rect.top + mine_rect.rect.bottom ) * 4096 / 2 ) );
                AppMain.GmGmkAnimalInit( gms_ENEMY_COM_WORK.obj_work, 0, 0, 0, 0, 0, 0 );
                AppMain.GMM_PAD_VIB_SMALL();
                if ( gms_PLAYER_WORK != null )
                {
                    AppMain.GmPlayerComboScore( gms_PLAYER_WORK, gms_ENEMY_COM_WORK.obj_work.pos.x, gms_ENEMY_COM_WORK.obj_work.pos.y + -65536 );
                }
                AppMain.HgTrophyIncEnemyKillCount( gms_ENEMY_COM_WORK.obj_work );
            }
            gms_ENEMY_COM_WORK.obj_work.flag |= 8U;
        }
        else
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK2 = gms_ENEMY_COM_WORK;
            gms_ENEMY_COM_WORK2.vit -= 1;
            byte[] byte_param = gms_ENEMY_COM_WORK.eve_rec.byte_param;
            int num = 1;
            byte_param[num] += 1;
            gms_ENEMY_COM_WORK.invincible_timer = 245760;
            gms_ENEMY_COM_WORK.rect_work[1].hit_power = 0;
        }
        if ( gms_PLAYER_WORK != null && gms_PLAYER_WORK.obj_work.obj_type == 1 )
        {
            AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
        }
    }

    // Token: 0x0600009C RID: 156 RVA: 0x0000886A File Offset: 0x00006A6A
    private static void GmEnemyDefaultAtkFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
    }

    // Token: 0x0600009D RID: 157 RVA: 0x0000886C File Offset: 0x00006A6C
    private static void GmEnemyDefaultMoveFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjObjectMove( obj_work );
    }

    // Token: 0x0600009E RID: 158 RVA: 0x00008874 File Offset: 0x00006A74
    private static void GmEnemyDefaultInFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
        if ( gms_ENEMY_COM_WORK.target_obj != null && ( gms_ENEMY_COM_WORK.target_obj.flag & 4U ) != 0U )
        {
            gms_ENEMY_COM_WORK.target_obj = null;
        }
    }

    // Token: 0x0600009F RID: 159 RVA: 0x000088A6 File Offset: 0x00006AA6
    private static void gmEnemyDefaultRecFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060000A0 RID: 160 RVA: 0x000088A8 File Offset: 0x00006AA8
    private static void gmEnemyActionCallBack( object cmd_work, object act_work, uint data )
    {
    }
}
