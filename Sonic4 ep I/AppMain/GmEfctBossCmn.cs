using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001BD RID: 445
    public class GMS_EFCT_BOSS_CMN_CREATE_PARAM
    {
        // Token: 0x06002225 RID: 8741 RVA: 0x00142456 File Offset: 0x00140656
        public GMS_EFCT_BOSS_CMN_CREATE_PARAM()
        {
            this.create_param = new AppMain.GMS_EFFECT_CREATE_PARAM();
        }

        // Token: 0x06002226 RID: 8742 RVA: 0x00142469 File Offset: 0x00140669
        public GMS_EFCT_BOSS_CMN_CREATE_PARAM( AppMain.GMS_EFFECT_CREATE_PARAM create_param, int mdl_ambtex_idx )
        {
            this.create_param = create_param;
            this.mdl_ambtex_idx = mdl_ambtex_idx;
        }

        // Token: 0x04004FF9 RID: 20473
        public readonly AppMain.GMS_EFFECT_CREATE_PARAM create_param;

        // Token: 0x04004FFA RID: 20474
        public int mdl_ambtex_idx;
    }

    // Token: 0x020001BE RID: 446
    public class GMS_EFCT_BOSS_SINGLE_BUILD_WORK
    {
        // Token: 0x04004FFB RID: 20475
        public int tex_reg_id;

        // Token: 0x04004FFC RID: 20476
        public int model_reg_id;

        // Token: 0x04004FFD RID: 20477
        public AppMain.OBS_DATA_WORK ambtex_dwork;

        // Token: 0x04004FFE RID: 20478
        public AppMain.OBS_DATA_WORK texlist_dwork;

        // Token: 0x04004FFF RID: 20479
        public AppMain.OBS_DATA_WORK model_dwork;

        // Token: 0x04005000 RID: 20480
        public AppMain.OBS_DATA_WORK object_dwork;
    }

    // Token: 0x06000960 RID: 2400 RVA: 0x00054AFC File Offset: 0x00052CFC
    public static void GmEfctBossCmnBuildDataInit()
    {
        object obj = null;
        int num = 0;
        AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(15);
        AppMain.AMS_AMB_HEADER amb = AppMain.readAMBFile(AppMain.ObjDataGetInc(pWork));
        AppMain.gm_efct_boss_cmn_model_reg_num = 6;
        if ( AppMain.gm_efct_boss_cmn_model_reg_num > 0 )
        {
            AppMain.gm_efct_boss_cmn_model_reg_id_list = new int[AppMain.gm_efct_boss_cmn_model_reg_num];
            AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list = new int[AppMain.gm_efct_boss_cmn_model_reg_num];
            for ( int i = 0; i < AppMain.gm_efct_boss_cmn_model_reg_num; i++ )
            {
                AppMain.gm_efct_boss_cmn_model_reg_id_list[i] = -1;
                AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[i] = -1;
            }
        }
        AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(621);
        AppMain.ObjDataLoadAmbIndex( obs_DATA_WORK, 6, amb );
        AppMain.gm_efct_boss_cmn_tex_reg_id = AppMain.ObjAction3dESTextureLoadToDwork( AppMain.ObjDataGet( 622 ), AppMain.readAMBFile( obs_DATA_WORK.pData ), ref obj );
        for ( int j = 0; j < 6; j++ )
        {
            AppMain.GMS_EFCT_BOSS_CMN_CREATE_PARAM gms_EFCT_BOSS_CMN_CREATE_PARAM = AppMain.gm_efct_boss_cmn_create_param_tbl[j];
            int model_idx = gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param.model_idx;
            int index = AppMain.gmEfctBossCmnGetModelDworkNo(j);
            int index2 = AppMain.gmEfctBossCmnGetObjectDworkNo(j);
            int mdl_ambtex_idx = gms_EFCT_BOSS_CMN_CREATE_PARAM.mdl_ambtex_idx;
            int index3 = AppMain.gmEfctBossCmnGetMdlAmbtexDworkNo(j);
            int index4 = AppMain.gmEfctBossCmnGetMdlTexlistDworkNo(j);
            if ( model_idx != -1 )
            {
                obs_DATA_WORK = AppMain.ObjDataGet( index3 );
                AppMain.ObjDataLoadAmbIndex( obs_DATA_WORK, mdl_ambtex_idx, amb );
                AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[num] = AppMain.ObjAction3dESTextureLoadToDwork( AppMain.ObjDataGet( index4 ), AppMain.readAMBFile( obs_DATA_WORK.pData ), ref obj );
                AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( index ), model_idx, amb );
                AppMain.gm_efct_boss_cmn_model_reg_id_list[num] = AppMain.ObjAction3dESModelLoadToDwork( AppMain.ObjDataGet( index2 ), ( AppMain.AmbChunk )AppMain.ObjDataGet( index ).pData, 0U );
                num++;
            }
        }
    }

    // Token: 0x06000961 RID: 2401 RVA: 0x00054C78 File Offset: 0x00052E78
    public static bool GmEfctBossCmnBuildDataLoop()
    {
        bool result = true;
        if ( AppMain.gm_efct_boss_cmn_tex_reg_id != -1 )
        {
            if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_boss_cmn_tex_reg_id ) )
            {
                AppMain.gm_efct_boss_cmn_tex_reg_id = -1;
            }
            else
            {
                result = false;
            }
        }
        for ( int i = 0; i < AppMain.gm_efct_boss_cmn_model_reg_num; i++ )
        {
            if ( AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[i] != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[i] ) )
                {
                    AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[i] = -1;
                }
                else
                {
                    result = false;
                }
            }
            if ( AppMain.gm_efct_boss_cmn_model_reg_id_list[i] != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_boss_cmn_model_reg_id_list[i] ) )
                {
                    AppMain.gm_efct_boss_cmn_model_reg_id_list[i] = -1;
                }
                else
                {
                    result = false;
                }
            }
        }
        return result;
    }

    // Token: 0x06000962 RID: 2402 RVA: 0x00054D00 File Offset: 0x00052F00
    public static void GmEfctBossCmnFlushDataInit()
    {
        int num = 0;
        for ( int i = 0; i < 6; i++ )
        {
            AppMain.GMS_EFCT_BOSS_CMN_CREATE_PARAM gms_EFCT_BOSS_CMN_CREATE_PARAM = AppMain.gm_efct_boss_cmn_create_param_tbl[i];
            int index = AppMain.gmEfctBossCmnGetModelDworkNo(i);
            int index2 = AppMain.gmEfctBossCmnGetObjectDworkNo(i);
            if ( gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param.model_idx != -1 )
            {
                AppMain.gm_efct_boss_cmn_model_reg_id_list[num] = AppMain.ObjAction3dESModelReleaseDwork( AppMain.ObjDataGet( index2 ) );
                AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(index);
                AppMain.ObjDataRelease( pWork );
                AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[num] = AppMain.ObjAction3dESTextureReleaseDwork( AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetMdlTexlistDworkNo( i ) ) );
                AppMain.ObjDataRelease( AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetMdlAmbtexDworkNo( i ) ) );
                num++;
            }
        }
        AppMain.gm_efct_boss_cmn_tex_reg_id = AppMain.ObjAction3dESTextureReleaseDwork( AppMain.ObjDataGet( 622 ) );
        AppMain.OBS_DATA_WORK pWork2 = AppMain.ObjDataGet(621);
        AppMain.ObjDataRelease( pWork2 );
        AppMain.OBS_DATA_WORK pWork3 = AppMain.ObjDataGet(15);
        AppMain.ObjDataRelease( pWork3 );
    }

    // Token: 0x06000963 RID: 2403 RVA: 0x00054DD0 File Offset: 0x00052FD0
    public static bool GmEfctBossCmnFlushDataLoop()
    {
        bool flag = true;
        int num = 0;
        if ( AppMain.gm_efct_boss_cmn_model_reg_num != 0 )
        {
            for ( int i = 0; i < 6; i++ )
            {
                AppMain.GMS_EFCT_BOSS_CMN_CREATE_PARAM gms_EFCT_BOSS_CMN_CREATE_PARAM = AppMain.gm_efct_boss_cmn_create_param_tbl[i];
                if ( gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param.model_idx != -1 )
                {
                    if ( AppMain.gm_efct_boss_cmn_model_reg_id_list[num] != -1 )
                    {
                        int index = AppMain.gmEfctBossCmnGetObjectDworkNo(i);
                        if ( AppMain.ObjAction3dESModelReleaseDworkCheck( AppMain.ObjDataGet( index ), AppMain.gm_efct_boss_cmn_model_reg_id_list[num] ) )
                        {
                            AppMain.gm_efct_boss_cmn_model_reg_id_list[num] = -1;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if ( AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[num] != -1 )
                    {
                        if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetMdlTexlistDworkNo( i ) ), AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[num] ) )
                        {
                            AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list[num] = -1;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    num++;
                }
            }
        }
        if ( AppMain.gm_efct_boss_cmn_tex_reg_id != -1 )
        {
            if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( AppMain.ObjDataGet( 622 ), AppMain.gm_efct_boss_cmn_tex_reg_id ) )
            {
                AppMain.gm_efct_boss_cmn_tex_reg_id = -1;
            }
            else
            {
                flag = false;
            }
        }
        if ( flag )
        {
            if ( AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list != null )
            {
                AppMain.gm_efct_boss_cmn_mdl_tex_reg_id_list = null;
            }
            if ( AppMain.gm_efct_boss_cmn_model_reg_id_list != null )
            {
                AppMain.gm_efct_boss_cmn_model_reg_id_list = null;
                AppMain.gm_efct_boss_cmn_model_reg_num = 0;
            }
        }
        return flag;
    }

    // Token: 0x06000964 RID: 2404 RVA: 0x00054EC5 File Offset: 0x000530C5
    public static void GmEfctBossBuildSingleDataInit()
    {
        AppMain.gm_efct_boss_single_reg_num = 0;
    }

    // Token: 0x06000965 RID: 2405 RVA: 0x00054ED0 File Offset: 0x000530D0
    public static void GmEfctBossBuildSingleDataReg( int tex_index, AppMain.OBS_DATA_WORK ambtex_dwork, AppMain.OBS_DATA_WORK texlist_dwork, int model_index, AppMain.OBS_DATA_WORK model_dwork, AppMain.OBS_DATA_WORK object_dwork, AppMain.AMS_AMB_HEADER arc )
    {
        object obj = null;
        AppMain.GMS_EFCT_BOSS_SINGLE_BUILD_WORK gms_EFCT_BOSS_SINGLE_BUILD_WORK = AppMain.gm_efct_boss_single_build_list[AppMain.gm_efct_boss_single_reg_num];
        AppMain.gm_efct_boss_single_reg_num++;
        AppMain.ObjDataLoadAmbIndex( ambtex_dwork, tex_index, arc );
        gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id = AppMain.ObjAction3dESTextureLoadToDwork( texlist_dwork, AppMain.readAMBFile( ambtex_dwork.pData ), ref obj );
        gms_EFCT_BOSS_SINGLE_BUILD_WORK.ambtex_dwork = ambtex_dwork;
        gms_EFCT_BOSS_SINGLE_BUILD_WORK.texlist_dwork = texlist_dwork;
        if ( model_dwork != null )
        {
            AppMain.ObjDataLoadAmbIndex( model_dwork, model_index, arc );
            gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id = AppMain.ObjAction3dESModelLoadToDwork( object_dwork, ( AppMain.AmbChunk )model_dwork.pData, 0U );
            gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_dwork = model_dwork;
            gms_EFCT_BOSS_SINGLE_BUILD_WORK.object_dwork = object_dwork;
            return;
        }
        gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id = -1;
        gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_dwork = null;
        gms_EFCT_BOSS_SINGLE_BUILD_WORK.object_dwork = null;
    }

    // Token: 0x06000966 RID: 2406 RVA: 0x00054F78 File Offset: 0x00053178
    public static bool GmEfctBossBuildSingleDataLoop()
    {
        bool result = true;
        for ( int i = 0; i < AppMain.gm_efct_boss_single_reg_num; i++ )
        {
            AppMain.GMS_EFCT_BOSS_SINGLE_BUILD_WORK gms_EFCT_BOSS_SINGLE_BUILD_WORK = AppMain.gm_efct_boss_single_build_list[i];
            if ( gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id ) )
                {
                    gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id = -1;
                }
                else
                {
                    result = false;
                }
            }
            if ( gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id ) )
                {
                    gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id = -1;
                }
                else
                {
                    result = false;
                }
            }
        }
        return result;
    }

    // Token: 0x06000967 RID: 2407 RVA: 0x00054FE4 File Offset: 0x000531E4
    public static void GmEfctBossFlushSingleDataInit()
    {
        for ( int i = 0; i < AppMain.gm_efct_boss_single_reg_num; i++ )
        {
            AppMain.GMS_EFCT_BOSS_SINGLE_BUILD_WORK gms_EFCT_BOSS_SINGLE_BUILD_WORK = AppMain.gm_efct_boss_single_build_list[i];
            if ( gms_EFCT_BOSS_SINGLE_BUILD_WORK.object_dwork != null )
            {
                gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id = AppMain.ObjAction3dESModelReleaseDwork( gms_EFCT_BOSS_SINGLE_BUILD_WORK.object_dwork );
                AppMain.ObjDataRelease( gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_dwork );
                gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_dwork = null;
            }
            gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id = AppMain.ObjAction3dESTextureReleaseDwork( gms_EFCT_BOSS_SINGLE_BUILD_WORK.texlist_dwork );
            AppMain.ObjDataRelease( gms_EFCT_BOSS_SINGLE_BUILD_WORK.ambtex_dwork );
            gms_EFCT_BOSS_SINGLE_BUILD_WORK.ambtex_dwork = null;
        }
    }

    // Token: 0x06000968 RID: 2408 RVA: 0x00055058 File Offset: 0x00053258
    public static bool GmEfctBossFlushSingleDataLoop()
    {
        bool flag = true;
        for ( int i = 0; i < AppMain.gm_efct_boss_single_reg_num; i++ )
        {
            AppMain.GMS_EFCT_BOSS_SINGLE_BUILD_WORK gms_EFCT_BOSS_SINGLE_BUILD_WORK = AppMain.gm_efct_boss_single_build_list[i];
            if ( gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id != -1 )
            {
                if ( AppMain.ObjAction3dESModelReleaseDworkCheck( gms_EFCT_BOSS_SINGLE_BUILD_WORK.object_dwork, gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id ) )
                {
                    gms_EFCT_BOSS_SINGLE_BUILD_WORK.model_reg_id = -1;
                    gms_EFCT_BOSS_SINGLE_BUILD_WORK.object_dwork = null;
                }
                else
                {
                    flag = false;
                }
            }
            if ( gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id != -1 )
            {
                if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( gms_EFCT_BOSS_SINGLE_BUILD_WORK.texlist_dwork, gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id ) )
                {
                    gms_EFCT_BOSS_SINGLE_BUILD_WORK.tex_reg_id = -1;
                    gms_EFCT_BOSS_SINGLE_BUILD_WORK.texlist_dwork = null;
                }
                else
                {
                    flag = false;
                }
            }
        }
        if ( flag )
        {
            AppMain.gm_efct_boss_single_reg_num = 0;
        }
        return flag;
    }

    // Token: 0x06000969 RID: 2409 RVA: 0x000550E8 File Offset: 0x000532E8
    public static AppMain.GMS_EFFECT_3DES_WORK GmEfctBossCmnEsCreate( AppMain.OBS_OBJECT_WORK parent_obj, uint efct_bscmn_idx )
    {
        AppMain.GMS_EFCT_BOSS_CMN_CREATE_PARAM gms_EFCT_BOSS_CMN_CREATE_PARAM = AppMain.gm_efct_boss_cmn_create_param_tbl[(int)((UIntPtr)efct_bscmn_idx)];
        AppMain.OBS_DATA_WORK model_dwork;
        AppMain.OBS_DATA_WORK object_dwork;
        AppMain.OBS_DATA_WORK obs_DATA_WORK;
        AppMain.OBS_DATA_WORK texlist_dwork;
        if ( gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param.model_idx != -1 )
        {
            int ame_idx = gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param.ame_idx;
            model_dwork = AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetModelDworkNo( ame_idx ) );
            object_dwork = AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetObjectDworkNo( ame_idx ) );
            obs_DATA_WORK = AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetMdlAmbtexDworkNo( ame_idx ) );
            texlist_dwork = AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetMdlTexlistDworkNo( ame_idx ) );
        }
        else
        {
            model_dwork = null;
            object_dwork = null;
            obs_DATA_WORK = AppMain.ObjDataGet( 621 );
            texlist_dwork = AppMain.ObjDataGet( 622 );
        }
        return AppMain.GmEffect3dESCreateByParam( gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param, parent_obj, AppMain.ObjDataGet( 15 ).pData, AppMain.ObjDataGet( AppMain.gmEfctBossCmnGetAmeDworkNo( gms_EFCT_BOSS_CMN_CREATE_PARAM.create_param.ame_idx ) ), obs_DATA_WORK, texlist_dwork, model_dwork, object_dwork );
    }

    // Token: 0x0600096A RID: 2410 RVA: 0x000551A2 File Offset: 0x000533A2
    public static int gmEfctBossCmnGetAmeDworkNo( int ame_idx )
    {
        return 623 + ame_idx;
    }

    // Token: 0x0600096B RID: 2411 RVA: 0x000551AB File Offset: 0x000533AB
    public static int gmEfctBossCmnGetModelDworkNo( int ame_idx )
    {
        return 630 + ame_idx;
    }

    // Token: 0x0600096C RID: 2412 RVA: 0x000551B4 File Offset: 0x000533B4
    public static int gmEfctBossCmnGetObjectDworkNo( int ame_idx )
    {
        return 637 + ame_idx;
    }

    // Token: 0x0600096D RID: 2413 RVA: 0x000551BD File Offset: 0x000533BD
    public static int gmEfctBossCmnGetMdlAmbtexDworkNo( int ame_idx )
    {
        return 644 + ame_idx;
    }

    // Token: 0x0600096E RID: 2414 RVA: 0x000551C6 File Offset: 0x000533C6
    public static int gmEfctBossCmnGetMdlTexlistDworkNo( int ame_idx )
    {
        return 651 + ame_idx;
    }

}