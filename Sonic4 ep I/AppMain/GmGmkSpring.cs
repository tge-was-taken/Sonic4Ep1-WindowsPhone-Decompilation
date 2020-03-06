using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000FBE RID: 4030 RVA: 0x0008922C File Offset: 0x0008742C
    private static AppMain.OBS_OBJECT_WORK GmGmkSpringInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_SPRING");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        int num;
        if ( eve_rec.id <= 79 )
        {
            num = ( int )( eve_rec.id - 70 );
        }
        else
        {
            num = ( int )( eve_rec.id - 70 + 1 - 21 );
        }
        if ( eve_rec.id == 71 || eve_rec.id == 73 || eve_rec.id == 75 || eve_rec.id == 77 )
        {
            if ( eve_rec.id == 71 || eve_rec.id == 75 )
            {
                AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_spring_obj_3d_list[1], gms_ENEMY_3D_WORK.obj_3d );
            }
            else
            {
                AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_spring_obj_3d_list[2], gms_ENEMY_3D_WORK.obj_3d );
            }
            AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 793 ), null, 0, null );
            obs_OBJECT_WORK.user_timer = 2;
            obs_OBJECT_WORK.user_work = 3U;
        }
        else
        {
            AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_spring_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
            AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 793 ), null, 0, null );
            obs_OBJECT_WORK.user_timer = 0;
            obs_OBJECT_WORK.user_work = 1U;
        }
        if ( eve_rec.id == 78 || eve_rec.id == 79 )
        {
            obs_OBJECT_WORK.pos.z = -655360;
        }
        else
        {
            obs_OBJECT_WORK.pos.z = -131072;
        }
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[0];
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkSpringDefFunc );
        obs_RECT_WORK.ppHit = null;
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.gm_gmk_spring_rect[num][0], AppMain.gm_gmk_spring_rect[num][1], AppMain.gm_gmk_spring_rect[num][2], AppMain.gm_gmk_spring_rect[num][3] );
        obs_RECT_WORK.flag |= 1024U;
        obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        AppMain.ObjRectWorkSet( obs_RECT_WORK, AppMain.gm_gmk_spring_rect[num][0], AppMain.gm_gmk_spring_rect[num][1], AppMain.gm_gmk_spring_rect[num][2], AppMain.gm_gmk_spring_rect[num][3] );
        obs_RECT_WORK.flag &= 4294967291U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.dir.z = AppMain.gm_gmk_spring_dir[num];
        if ( ( eve_rec.flag & 16 ) != 0 )
        {
            if ( eve_rec.width >= 64 )
            {
                eve_rec.width = 0;
            }
            if ( !AppMain.GmGmkSwitchIsOn( ( uint )eve_rec.width ) )
            {
                AppMain.gmGmkSpringSwitchOffInit( obs_OBJECT_WORK );
            }
            else
            {
                AppMain.gmGmkSpringFwInit( obs_OBJECT_WORK );
            }
        }
        else
        {
            AppMain.gmGmkSpringFwInit( obs_OBJECT_WORK );
        }
        if ( AppMain.GsGetMainSysInfo().stage_id == 14 )
        {
            obs_OBJECT_WORK.obj_3d.use_light_flag = 0U;
            obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        }
        else
        {
            int nMaterial = obs_OBJECT_WORK.obj_3d._object.nMaterial;
            if ( nMaterial == 1 )
            {
                AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = (AppMain.NNS_MATERIAL_GLES11_DESC)obs_OBJECT_WORK.obj_3d._object.pMatPtrList[0].pMaterial;
                nns_MATERIAL_GLES11_DESC.fFlag |= 3U;
            }
            else
            {
                AppMain.NNS_MATERIAL_GLES11_DESC[] array = (AppMain.NNS_MATERIAL_GLES11_DESC[])obs_OBJECT_WORK.obj_3d._object.pMatPtrList[0].pMaterial;
                for ( int i = 0; i < nMaterial; i++ )
                {
                    array[i].fFlag |= 3U;
                }
            }
        }
        obs_OBJECT_WORK.flag |= 1073741824U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000FBF RID: 4031 RVA: 0x000895BD File Offset: 0x000877BD
    public static void GmGmkSpringBuild()
    {
        AppMain.gm_gmk_spring_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 791 ), AppMain.GmGameDatGetGimmickData( 792 ), 0U );
    }

    // Token: 0x06000FC0 RID: 4032 RVA: 0x000895E0 File Offset: 0x000877E0
    public static void GmGmkSpringFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(791));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_spring_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06000FC1 RID: 4033 RVA: 0x00089610 File Offset: 0x00087810
    private static void gmGmkSpringFwInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.ObjDrawObjectActionSet( obj_work, obj_work.user_timer );
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 16 ) != 0 )
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpringSwitchOnMain );
        }
        else
        {
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpringFwMain );
        }
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 5 ) != 0 )
        {
            obj_work.disp_flag |= 32U;
        }
    }

    // Token: 0x06000FC2 RID: 4034 RVA: 0x0008968E File Offset: 0x0008788E
    private static void gmGmkSpringFwMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x06000FC3 RID: 4035 RVA: 0x00089690 File Offset: 0x00087890
    private static void gmGmkSpringActInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.ObjDrawObjectActionSet( obj_work, ( int )obj_work.user_work );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpringActMain );
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 4 ) != 0 )
        {
            obj_work.disp_flag |= 32U;
            return;
        }
        obj_work.disp_flag &= 4294967263U;
    }

    // Token: 0x06000FC4 RID: 4036 RVA: 0x000896F8 File Offset: 0x000878F8
    private static void gmGmkSpringActMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294573823U;
            AppMain.gmGmkSpringFwInit( obj_work );
        }
    }

    // Token: 0x06000FC5 RID: 4037 RVA: 0x0008973C File Offset: 0x0008793C
    private static void gmGmkSpringDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        int fall_dir = -1;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        AppMain.gmGmkSpringActInit( ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_COM_WORK );
        int num = AppMain.MTM_MATH_CLIP((int)gms_ENEMY_COM_WORK.eve_rec.left, 0, 7);
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 76 || gms_ENEMY_COM_WORK.eve_rec.id == 72 )
        {
            num = AppMain.MTM_MATH_CLIP( num, 0, 5 );
        }
        int num2 = 30720;
        num2 += 6144 * num;
        int num3 = -num2;
        if ( gms_ENEMY_COM_WORK.eve_rec.id == 74 || gms_ENEMY_COM_WORK.eve_rec.id == 70 )
        {
            num2 = 0;
        }
        else if ( gms_ENEMY_COM_WORK.eve_rec.id == 72 || gms_ENEMY_COM_WORK.eve_rec.id == 76 )
        {
            num3 = 0;
        }
        else
        {
            num2 = num2 * 181 >> 8;
            num3 = num3 * 181 >> 8;
        }
        if ( 73 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 75 )
        {
            num3 = -num3;
        }
        if ( ( 75 <= gms_ENEMY_COM_WORK.eve_rec.id && gms_ENEMY_COM_WORK.eve_rec.id <= 77 ) || gms_ENEMY_COM_WORK.eve_rec.id == 79 || gms_ENEMY_COM_WORK.eve_rec.id == 101 )
        {
            num2 = -num2;
        }
        if ( ( gms_ENEMY_COM_WORK.eve_rec.id == 76 || gms_ENEMY_COM_WORK.eve_rec.id == 72 ) && ( gms_ENEMY_COM_WORK.eve_rec.flag & 2 ) == 0 )
        {
            gms_PLAYER_WORK.obj_work.pos.y = gms_PLAYER_WORK.obj_work.pos.y + 8192;
        }
        if ( 1 <= gms_ENEMY_COM_WORK.eve_rec.height && gms_ENEMY_COM_WORK.eve_rec.height <= 4 )
        {
            fall_dir = ( int )( gms_ENEMY_COM_WORK.eve_rec.height - 1 ) * 16384;
        }
        AppMain.GmPlySeqInitSpringJump( gms_PLAYER_WORK, num2, num3, ( gms_ENEMY_COM_WORK.eve_rec.flag & 8 ) != 0, ( gms_ENEMY_COM_WORK.eve_rec.top >= 0 ) ? ( ( int )gms_ENEMY_COM_WORK.eve_rec.top * 4096 ) : 0, fall_dir, ( gms_ENEMY_COM_WORK.eve_rec.flag & 32 ) != 0 );
        AppMain.GmComEfctCreateSpring( gms_ENEMY_COM_WORK.obj_work, ( int )( ( mine_rect.rect.left + mine_rect.rect.right ) * 4096 / 2 ), ( int )( ( mine_rect.rect.top + mine_rect.rect.bottom ) * 4096 / 2 ) );
        if ( ( gms_ENEMY_COM_WORK.eve_rec.flag & 64 ) != 0 && ( AppMain.g_gs_main_sys_info.game_flag & 512U ) != 0U )
        {
            gms_PLAYER_WORK.gmk_flag2 |= 512U;
        }
    }

    // Token: 0x06000FC6 RID: 4038 RVA: 0x000899E4 File Offset: 0x00087BE4
    private static void gmGmkSpringSwitchOffInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.ObjDrawObjectActionSet( obj_work, obj_work.user_timer );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkSpringSwitchOffMain );
        obj_work.disp_flag |= 32U;
        obj_work.flag |= 2U;
    }

    // Token: 0x06000FC7 RID: 4039 RVA: 0x00089A34 File Offset: 0x00087C34
    private static void gmGmkSpringSwitchOffMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( AppMain.GmGmkSwitchIsOn( ( uint )gms_ENEMY_3D_WORK.ene_com.eve_rec.width ) )
        {
            obj_work.disp_flag &= 4294967263U;
            obj_work.flag &= 4294967293U;
            AppMain.GmComEfctCreateSpring( obj_work, ( int )( ( gms_ENEMY_3D_WORK.ene_com.rect_work[2].rect.left + gms_ENEMY_3D_WORK.ene_com.rect_work[2].rect.right ) * 4096 / 2 ), ( int )( ( gms_ENEMY_3D_WORK.ene_com.rect_work[2].rect.top + gms_ENEMY_3D_WORK.ene_com.rect_work[2].rect.bottom ) * 4096 / 2 ) );
            AppMain.gmGmkSpringFwInit( obj_work );
        }
    }

    // Token: 0x06000FC8 RID: 4040 RVA: 0x00089AFC File Offset: 0x00087CFC
    private static void gmGmkSpringSwitchOnMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( !AppMain.GmGmkSwitchIsOn( ( uint )gms_ENEMY_3D_WORK.ene_com.eve_rec.width ) )
        {
            AppMain.gmGmkSpringSwitchOffInit( obj_work );
        }
    }
}