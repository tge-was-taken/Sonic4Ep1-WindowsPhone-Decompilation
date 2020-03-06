using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020003D2 RID: 978
    public class GMS_GMK_ITEM_MAT_CB_PARAM
    {
        // Token: 0x0400623D RID: 25149
        public uint draw_id;
    }

    // Token: 0x06001B47 RID: 6983 RVA: 0x000F9344 File Offset: 0x000F7544
    private static AppMain.OBS_OBJECT_WORK GmGmkItemInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_ITEM");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        if ( eve_rec.byte_param[1] != 0 )
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_item_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_item_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        }
        obs_OBJECT_WORK.pos.z = -131072;
        gms_ENEMY_3D_WORK.obj_3d.material_cb_func = new AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE( AppMain.gmGmkItemMaterialCallback );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemOut );
        obs_OBJECT_WORK.user_work = AppMain.gm_gmk_item_matrial_user_data_tbl[( int )( AppMain.gmGmkItemConvEvtId( eve_rec.id ) - 63 )];
        obs_OBJECT_WORK.disp_flag |= 16777216U;
        AppMain.nnMakeUnitMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r );
        AppMain.nnTranslateMatrix( obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, obs_OBJECT_WORK.obj_3d.user_obj_mtx_r, 0f, -1f / AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.draw_scale.y ), 0f );
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkItemBodyDefFunc );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -30, -50, 30, 10 );
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkItemDamageDefFunc );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -30, -48, 30, 0 );
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = obs_OBJECT_WORK;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.width = 40;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.height = 32;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_x = -20;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = -32;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -8, -8, 8, 0 );
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.move_flag |= 512U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 16384U;
        if ( eve_rec.byte_param[1] != 0 )
        {
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.obj = null;
            obs_OBJECT_WORK.flag |= 2U;
            obs_OBJECT_WORK.move_flag &= 4294967151U;
            if ( ( eve_rec.flag & 1 ) != 0 )
            {
                obs_OBJECT_WORK.move_flag |= 8448U;
            }
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemFallCheckMain );
        }
        else
        {
            obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemMain );
            AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(obs_OBJECT_WORK, 40);
            AppMain.GmComEfctAddDispOffsetF( gms_EFFECT_3DES_WORK, 0f, -12.5f, 10f );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 16U;
            obs_OBJECT_WORK.user_flag_OBJECT = gms_EFFECT_3DES_WORK;
            if ( ( eve_rec.flag & 1 ) != 0 )
            {
                obs_OBJECT_WORK.move_flag &= 4294967151U;
                obs_OBJECT_WORK.move_flag |= 8448U;
                gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294967291U;
            }
        }
        obs_OBJECT_WORK.flag |= 1073741824U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B48 RID: 6984 RVA: 0x000F96F5 File Offset: 0x000F78F5
    public static void GmGmkItemBuild()
    {
        AppMain.gm_gmk_item_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 789 ), AppMain.GmGameDatGetGimmickData( 790 ), 0U );
    }

    // Token: 0x06001B49 RID: 6985 RVA: 0x000F9718 File Offset: 0x000F7918
    public static void GmGmkItemFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(789));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_item_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001B4A RID: 6986 RVA: 0x000F9748 File Offset: 0x000F7948
    private static void gmGmkItemMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( gms_ENEMY_3D_WORK.ene_com.eve_rec.byte_param[1] != 0 )
        {
            AppMain.ObjObjectAction3dNNModelReleaseCopy( obj_work );
            AppMain.ObjObjectCopyAction3dNNModel( obj_work, AppMain.gm_gmk_item_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
            obj_work.disp_flag |= 16777216U;
            AppMain.nnMakeUnitMatrix( obj_work.obj_3d.user_obj_mtx_r );
            AppMain.nnTranslateMatrix( obj_work.obj_3d.user_obj_mtx_r, obj_work.obj_3d.user_obj_mtx_r, 0f, -1f / AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.draw_scale.y ), 0f );
            if ( AppMain.g_gs_main_sys_info.stage_id == 2 )
            {
                AppMain.GmEfctZoneEsCreate( obj_work, 0, 1 );
            }
            else if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 2 )
            {
                if ( AppMain.GmMainIsWaterLevel() && obj_work.pos.y - 196608 >> 12 > ( int )AppMain.g_gm_main_system.water_level )
                {
                    AppMain.GmEfctZoneEsCreate( obj_work, 2, 9 );
                }
                else
                {
                    AppMain.GmEfctCmnEsCreate( obj_work, 39 );
                }
            }
            else
            {
                AppMain.GmEfctCmnEsCreate( obj_work, 39 );
            }
            AppMain.gmGmkItemCreatePopUpEffect( obj_work, ( int )obj_work.user_work );
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemEffectWatiMain );
            obj_work.user_timer = 245760;
            if ( AppMain.gmGmkItemConvEvtId( gms_ENEMY_3D_WORK.ene_com.eve_rec.id ) == 67 )
            {
                obj_work.user_timer = 1;
            }
            obj_work.flag |= 16U;
            if ( obj_work.user_flag != 0U )
            {
                AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obj_work.user_flag_OBJECT;
                gms_EFFECT_3DES_WORK.efct_com.obj_work.flag |= 8U;
            }
        }
        if ( ( obj_work.move_flag & 128U ) != 0U && ( obj_work.move_flag & 1U ) != 0U )
        {
            obj_work.move_flag &= 4294967151U;
            obj_work.spd.y = ( obj_work.spd_add.y = 0 );
            obj_work.flag &= 4294967293U;
        }
    }

    // Token: 0x06001B4B RID: 6987 RVA: 0x000F992C File Offset: 0x000F7B2C
    private static void gmGmkItemEffectWatiMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
        if ( obj_work.user_timer <= 0 )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            if ( gms_ENEMY_COM_WORK.target_obj != null )
            {
                switch ( AppMain.gmGmkItemConvEvtId( gms_ENEMY_COM_WORK.eve_rec.id ) )
                {
                    case 63:
                        AppMain.GmPlayerItemHiSpeedSet( ( AppMain.GMS_PLAYER_WORK )gms_ENEMY_COM_WORK.target_obj );
                        break;
                    case 64:
                        AppMain.GmPlayerItemInvincibleSet( ( AppMain.GMS_PLAYER_WORK )gms_ENEMY_COM_WORK.target_obj );
                        break;
                    case 65:
                        AppMain.GmPlayerItemRing10Set( ( AppMain.GMS_PLAYER_WORK )gms_ENEMY_COM_WORK.target_obj );
                        break;
                    case 66:
                        AppMain.GmPlayerItemBarrierSet( ( AppMain.GMS_PLAYER_WORK )gms_ENEMY_COM_WORK.target_obj );
                        break;
                    case 67:
                        AppMain.GmPlayerItem1UPSet( ( AppMain.GMS_PLAYER_WORK )gms_ENEMY_COM_WORK.target_obj );
                        break;
                }
            }
            gms_ENEMY_COM_WORK.target_obj = null;
            obj_work.flag &= 4294967279U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemFallCheckMain );
        }
        AppMain.gmGmkItemFallCheckMain( obj_work );
    }

    // Token: 0x06001B4C RID: 6988 RVA: 0x000F9A20 File Offset: 0x000F7C20
    private static void gmGmkItemFallCheckMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.move_flag & 128U ) != 0U && ( obj_work.move_flag & 1U ) != 0U )
        {
            obj_work.move_flag &= 4294967151U;
            obj_work.spd.y = ( obj_work.spd_add.y = 0 );
        }
    }

    // Token: 0x06001B4D RID: 6989 RVA: 0x000F9A71 File Offset: 0x000F7C71
    private static ushort gmGmkItemConvEvtId( ushort eve_id )
    {
        if ( AppMain.g_gs_main_sys_info.game_mode == 1 && eve_id == 67 )
        {
            eve_id = 65;
        }
        return eve_id;
    }

    // Token: 0x06001B4E RID: 6990 RVA: 0x000F9A8C File Offset: 0x000F7C8C
    private static void gmGmkItemOut( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        AppMain.GMS_GMK_ITEM_MAT_CB_PARAM gms_GMK_ITEM_MAT_CB_PARAM = AppMain.amDrawAlloc_GMS_GMK_ITEM_MAT_CB_PARAM();
        gms_GMK_ITEM_MAT_CB_PARAM.draw_id = ( uint )( ( ushort )obj_work.user_work );
        obj_3d.material_cb_param = gms_GMK_ITEM_MAT_CB_PARAM;
        AppMain.ObjDrawActionSummary( obj_work );
    }

    // Token: 0x06001B4F RID: 6991 RVA: 0x000F9AC0 File Offset: 0x000F7CC0
    private static void gmGmkItemBodyDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null || gms_PLAYER_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.obj_work.touch_obj == gms_ENEMY_COM_WORK.obj_work )
        {
            short num = gms_PLAYER_WORK.obj_work.field_rect[1];
            int num2 = (int)(gms_ENEMY_COM_WORK.col_work.obj_col.height + (ushort)gms_ENEMY_COM_WORK.col_work.obj_col.ofst_y) << 12;
            if ( gms_PLAYER_WORK.obj_work.pos.y + ( int )num >= gms_ENEMY_COM_WORK.obj_work.pos.y + num2 && gms_PLAYER_WORK.obj_work.move.y <= 0 )
            {
                gms_ENEMY_COM_WORK.obj_work.spd.y = -8192;
                gms_ENEMY_COM_WORK.obj_work.move_flag |= 144U;
                gms_ENEMY_COM_WORK.obj_work.move_flag &= 4294967294U;
                gms_ENEMY_COM_WORK.obj_work.flag |= 2U;
            }
        }
    }

    // Token: 0x06001B50 RID: 6992 RVA: 0x000F9BD0 File Offset: 0x000F7DD0
    private static void gmGmkItemDamageDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null || gms_PLAYER_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state != 19 && gms_PLAYER_WORK.seq_state != 10 && gms_PLAYER_WORK.obj_work.touch_obj == gms_ENEMY_COM_WORK.obj_work )
        {
            return;
        }
        if ( gms_PLAYER_WORK.seq_state != 19 && gms_PLAYER_WORK.seq_state != 10 )
        {
            if ( gms_PLAYER_WORK.obj_work.move.y <= 0 )
            {
                return;
            }
            if ( gms_PLAYER_WORK.obj_work.pos.x + ( ( int )gms_PLAYER_WORK.obj_work.field_rect[2] << 12 ) < gms_ENEMY_COM_WORK.obj_work.pos.x - 81920 || gms_PLAYER_WORK.obj_work.pos.x + ( ( int )gms_PLAYER_WORK.obj_work.field_rect[0] << 12 ) > gms_ENEMY_COM_WORK.obj_work.pos.x + 81920 )
            {
                return;
            }
        }
        gms_ENEMY_COM_WORK.eve_rec.byte_param[1] = 1;
        gms_ENEMY_COM_WORK.obj_work.flag |= 2U;
        gms_ENEMY_COM_WORK.col_work.obj_col.obj = null;
        gms_ENEMY_COM_WORK.obj_work.move_flag |= 144U;
        gms_ENEMY_COM_WORK.obj_work.move_flag &= 4294967294U;
        gms_ENEMY_COM_WORK.target_obj = gms_PLAYER_WORK.obj_work;
        AppMain.GmPlySeqAtkReactionInit( gms_PLAYER_WORK );
        AppMain.GmSoundPlaySE( "Enemy" );
        AppMain.GMM_PAD_VIB_SMALL();
    }

    // Token: 0x06001B51 RID: 6993 RVA: 0x000F9D54 File Offset: 0x000F7F54
    private static bool gmGmkItemMaterialCallback( AppMain.NNS_DRAWCALLBACK_VAL val, object param )
    {
        if ( param != null )
        {
            AppMain.GMS_GMK_ITEM_MAT_CB_PARAM gms_GMK_ITEM_MAT_CB_PARAM = (AppMain.GMS_GMK_ITEM_MAT_CB_PARAM)param;
            uint num = AppMain.ObjDraw3DNNGetMaterialUserData(val);
            if ( num == 0U || num == 64U || num == gms_GMK_ITEM_MAT_CB_PARAM.draw_id )
            {
                return AppMain.nnPutMaterialCore( val ) == 1;
            }
        }
        return false;
    }

    // Token: 0x06001B52 RID: 6994 RVA: 0x000F9D98 File Offset: 0x000F7F98
    private static void gmGmkItemCreatePopUpEffect( AppMain.OBS_OBJECT_WORK parent_obj, int mat_id )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), null, 0, "GMK_ITEM_POP");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_item_obj_3d_list[2], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK.pos.x = parent_obj.pos.x;
        obs_OBJECT_WORK.pos.y = parent_obj.pos.y + -86016;
        obs_OBJECT_WORK.pos.z = -524288;
        gms_EFFECT_3DNN_WORK.obj_3d.material_cb_func = new AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE( AppMain.gmGmkItemMaterialCallback );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemOut );
        obs_OBJECT_WORK.user_work = ( uint )mat_id;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = 6144 );
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkItemPopUpEffectMain );
        obs_OBJECT_WORK.spd.y = -10240;
        obs_OBJECT_WORK.spd_add.y = 320;
    }

    // Token: 0x06001B53 RID: 6995 RVA: 0x000F9EE0 File Offset: 0x000F80E0
    private static void gmGmkItemPopUpEffectMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.spd.y == 0 )
        {
            obj_work.user_timer = AppMain.ObjTimeCountDown( obj_work.user_timer );
            if ( obj_work.user_timer <= 0 )
            {
                obj_work.flag |= 4U;
                return;
            }
        }
        else if ( obj_work.spd.y + obj_work.spd_add.y >= 0 )
        {
            obj_work.spd.y = ( obj_work.spd_add.y = 0 );
            obj_work.user_timer = 122880;
            obj_work.move_flag |= 8192U;
        }
    }
}
