using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain 
{
    // Token: 0x020003D5 RID: 981
    public class GMS_EFCT_ZONE_CREATE_PARAM
    {
        // Token: 0x06002854 RID: 10324 RVA: 0x00152B99 File Offset: 0x00150D99
        public GMS_EFCT_ZONE_CREATE_PARAM()
        {
            this.create_param = new AppMain.GMS_EFFECT_CREATE_PARAM();
        }

        // Token: 0x06002855 RID: 10325 RVA: 0x00152BAC File Offset: 0x00150DAC
        public GMS_EFCT_ZONE_CREATE_PARAM( AppMain.GMS_EFFECT_CREATE_PARAM create_param, int model_dwork_no, int mdl_ambtex_idx )
        {
            this.create_param = create_param;
            this.mdl_ambtex_idx = mdl_ambtex_idx;
            this.model_dwork_no = model_dwork_no;
        }

        // Token: 0x04006247 RID: 25159
        public readonly AppMain.GMS_EFFECT_CREATE_PARAM create_param;

        // Token: 0x04006248 RID: 25160
        public int model_dwork_no;

        // Token: 0x04006249 RID: 25161
        public int mdl_ambtex_idx;
    }

    // Token: 0x020003D6 RID: 982
    public class GMS_EFCT_ZONE_CREATE_INFO
    {
        // Token: 0x06002856 RID: 10326 RVA: 0x00152BC9 File Offset: 0x00150DC9
        public GMS_EFCT_ZONE_CREATE_INFO( AppMain.GMS_EFCT_ZONE_CREATE_PARAM[] zone_create_param, int num )
        {
            this.zone_create_param = zone_create_param;
            this.num = num;
        }

        // Token: 0x0400624A RID: 25162
        public AppMain.GMS_EFCT_ZONE_CREATE_PARAM[] zone_create_param;

        // Token: 0x0400624B RID: 25163
        public int num;
    }

    // Token: 0x06001B70 RID: 7024 RVA: 0x000FB397 File Offset: 0x000F9597
    private static void GmEfctZoneBuildDataInit( int zone_no )
    {
        AppMain.gm_efct_zone_proc_state = 1;
        AppMain.gm_efct_zone_target_zone_no = zone_no;
    }

    // Token: 0x06001B71 RID: 7025 RVA: 0x000FB3A8 File Offset: 0x000F95A8
    private static void GmEfctZoneBuildDataLoopInit()
    {
        object obj = null;
        AppMain.GMS_EFCT_ZONE_CREATE_INFO gms_EFCT_ZONE_CREATE_INFO = AppMain.gm_efct_zone_create_info[AppMain.gm_efct_zone_target_zone_no];
        int num = 0;
        AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(6);
        AppMain.AMS_AMB_HEADER amb = AppMain.readAMBFile(AppMain.ObjDataGetInc(pWork));
        AppMain.gm_efct_zone_model_reg_num = 1;
        if ( AppMain.gm_efct_zone_model_reg_num > 0 )
        {
            AppMain.gm_efct_zone_model_reg_id_list = new int[AppMain.gm_efct_zone_model_reg_num];
            AppMain.gm_efct_zone_mdl_tex_reg_id_list = new int[AppMain.gm_efct_zone_model_reg_num];
            for ( int i = 0; i < AppMain.gm_efct_zone_model_reg_num; i++ )
            {
                AppMain.gm_efct_zone_model_reg_id_list[i] = -1;
                AppMain.gm_efct_zone_mdl_tex_reg_id_list[i] = -1;
            }
        }
        AppMain.OBS_DATA_WORK obs_DATA_WORK = AppMain.ObjDataGet(509);
        AppMain.ObjDataLoadAmbIndex( obs_DATA_WORK, AppMain.gm_efct_zone_texamb_index_tbl[AppMain.gm_efct_zone_target_zone_no], amb );
        AppMain.gm_efct_zone_tex_reg_id = AppMain.ObjAction3dESTextureLoadToDwork( AppMain.ObjDataGet( 510 ), AppMain.readAMBFile( obs_DATA_WORK.pData ), ref obj );
        for ( int j = 0; j < gms_EFCT_ZONE_CREATE_INFO.num; j++ )
        {
            int model_idx = gms_EFCT_ZONE_CREATE_INFO.zone_create_param[j].create_param.model_idx;
            int model_dwork_no = gms_EFCT_ZONE_CREATE_INFO.zone_create_param[j].model_dwork_no;
            int index = AppMain.gmEfctZoneGetObjectDworkNo(model_dwork_no);
            int mdl_ambtex_idx = gms_EFCT_ZONE_CREATE_INFO.zone_create_param[j].mdl_ambtex_idx;
            int index2 = AppMain.gmEfctZoneGetMdlAmbtexDworkNo(model_dwork_no);
            int index3 = AppMain.gmEfctZoneGetMdlTexlistDworkNo(model_dwork_no);
            if ( model_idx != -1 )
            {
                obs_DATA_WORK = AppMain.ObjDataGet( index2 );
                AppMain.ObjDataLoadAmbIndex( obs_DATA_WORK, mdl_ambtex_idx, amb );
                AppMain.gm_efct_zone_mdl_tex_reg_id_list[num] = AppMain.ObjAction3dESTextureLoadToDwork( AppMain.ObjDataGet( index3 ), AppMain.readAMBFile( obs_DATA_WORK.pData ), ref obj );
                AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( model_dwork_no ), model_idx, amb );
                AppMain.gm_efct_zone_model_reg_id_list[num] = AppMain.ObjAction3dESModelLoadToDwork( AppMain.ObjDataGet( index ), ( AppMain.AmbChunk )AppMain.ObjDataGet( model_dwork_no ).pData, 0U );
                num++;
            }
        }
    }

    // Token: 0x06001B72 RID: 7026 RVA: 0x000FB550 File Offset: 0x000F9750
    private static bool GmEfctZoneBuildDataLoop()
    {
        bool flag = true;
        if ( AppMain.gm_efct_zone_target_zone_no == -1 )
        {
            return flag;
        }
        if ( AppMain.gm_efct_zone_proc_state == 0 )
        {
            return true;
        }
        if ( AppMain.gm_efct_zone_proc_state == 1 )
        {
            if ( AppMain.GsMainSysGetDisplayListRegistNum() < 208 )
            {
                AppMain.GmEfctZoneBuildDataLoopInit();
                AppMain.gm_efct_zone_proc_state = 2;
            }
            return false;
        }
        if ( AppMain.gm_efct_zone_tex_reg_id != -1 )
        {
            if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_zone_tex_reg_id ) )
            {
                AppMain.gm_efct_zone_tex_reg_id = -1;
            }
            else
            {
                flag = false;
            }
        }
        for ( int i = 0; i < AppMain.gm_efct_zone_model_reg_num; i++ )
        {
            if ( AppMain.gm_efct_zone_mdl_tex_reg_id_list[i] != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_zone_mdl_tex_reg_id_list[i] ) )
                {
                    AppMain.gm_efct_zone_mdl_tex_reg_id_list[i] = -1;
                }
                else
                {
                    flag = false;
                }
            }
            if ( AppMain.gm_efct_zone_model_reg_id_list[i] != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_zone_model_reg_id_list[i] ) )
                {
                    AppMain.gm_efct_zone_model_reg_id_list[i] = -1;
                }
                else
                {
                    flag = false;
                }
            }
        }
        if ( flag )
        {
            AppMain.gm_efct_zone_target_zone_no = -1;
            AppMain.gm_efct_zone_proc_state = 0;
        }
        return flag;
    }

    // Token: 0x06001B73 RID: 7027 RVA: 0x000FB619 File Offset: 0x000F9819
    private static void GmEfctZoneFlushDataInit( int zone_no )
    {
        AppMain.gm_efct_zone_proc_state = 1;
        AppMain.gm_efct_zone_target_zone_no = zone_no;
    }

    // Token: 0x06001B74 RID: 7028 RVA: 0x000FB628 File Offset: 0x000F9828
    private static void GmEfctZoneFlushDataLoopInit()
    {
        AppMain.GMS_EFCT_ZONE_CREATE_INFO gms_EFCT_ZONE_CREATE_INFO = AppMain.gm_efct_zone_create_info[AppMain.gm_efct_zone_target_zone_no];
        int num = 0;
        for ( int i = 0; i < gms_EFCT_ZONE_CREATE_INFO.num; i++ )
        {
            AppMain.GMS_EFCT_ZONE_CREATE_PARAM gms_EFCT_ZONE_CREATE_PARAM = gms_EFCT_ZONE_CREATE_INFO.zone_create_param[i];
            int model_dwork_no = gms_EFCT_ZONE_CREATE_PARAM.model_dwork_no;
            int index = AppMain.gmEfctZoneGetObjectDworkNo(model_dwork_no);
            if ( gms_EFCT_ZONE_CREATE_PARAM.create_param.model_idx != -1 )
            {
                AppMain.gm_efct_zone_model_reg_id_list[num] = AppMain.ObjAction3dESModelReleaseDwork( AppMain.ObjDataGet( index ) );
                AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(model_dwork_no);
                AppMain.ObjDataRelease( pWork );
                AppMain.gm_efct_zone_mdl_tex_reg_id_list[num] = AppMain.ObjAction3dESTextureReleaseDwork( AppMain.ObjDataGet( AppMain.gmEfctZoneGetMdlTexlistDworkNo( model_dwork_no ) ) );
                AppMain.ObjDataRelease( AppMain.ObjDataGet( AppMain.gmEfctZoneGetMdlAmbtexDworkNo( model_dwork_no ) ) );
                num++;
            }
        }
        AppMain.gm_efct_zone_tex_reg_id = AppMain.ObjAction3dESTextureReleaseDwork( AppMain.ObjDataGet( 510 ) );
        AppMain.OBS_DATA_WORK pWork2 = AppMain.ObjDataGet(509);
        AppMain.ObjDataRelease( pWork2 );
        AppMain.OBS_DATA_WORK pWork3 = AppMain.ObjDataGet(6);
        AppMain.ObjDataRelease( pWork3 );
    }

    // Token: 0x06001B75 RID: 7029 RVA: 0x000FB710 File Offset: 0x000F9910
    private static bool GmEfctZoneFlushDataLoop()
    {
        bool flag = true;
        int num = 0;
        if ( AppMain.gm_efct_zone_proc_state == 0 )
        {
            return true;
        }
        if ( AppMain.gm_efct_zone_proc_state == 1 )
        {
            if ( AppMain.GsMainSysGetDisplayListRegistNum() < 248 )
            {
                AppMain.GmEfctZoneFlushDataLoopInit();
                AppMain.gm_efct_zone_proc_state = 2;
            }
            return false;
        }
        AppMain.GMS_EFCT_ZONE_CREATE_INFO gms_EFCT_ZONE_CREATE_INFO = AppMain.gm_efct_zone_create_info[AppMain.gm_efct_zone_target_zone_no];
        if ( AppMain.gm_efct_zone_model_reg_num != 0 )
        {
            for ( int i = 0; i < gms_EFCT_ZONE_CREATE_INFO.num; i++ )
            {
                AppMain.GMS_EFCT_ZONE_CREATE_PARAM gms_EFCT_ZONE_CREATE_PARAM = gms_EFCT_ZONE_CREATE_INFO.zone_create_param[i];
                int model_dwork_no = gms_EFCT_ZONE_CREATE_PARAM.model_dwork_no;
                int index = AppMain.gmEfctZoneGetObjectDworkNo(model_dwork_no);
                if ( gms_EFCT_ZONE_CREATE_PARAM.create_param.model_idx != -1 )
                {
                    if ( AppMain.gm_efct_zone_model_reg_id_list[num] != -1 )
                    {
                        if ( AppMain.ObjAction3dESModelReleaseDworkCheck( AppMain.ObjDataGet( index ), AppMain.gm_efct_zone_model_reg_id_list[num] ) )
                        {
                            AppMain.gm_efct_zone_model_reg_id_list[num] = -1;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if ( AppMain.gm_efct_zone_mdl_tex_reg_id_list[num] != -1 )
                    {
                        if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( AppMain.ObjDataGet( AppMain.gmEfctZoneGetMdlTexlistDworkNo( model_dwork_no ) ), AppMain.gm_efct_zone_mdl_tex_reg_id_list[num] ) )
                        {
                            AppMain.gm_efct_zone_mdl_tex_reg_id_list[num] = -1;
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
        if ( AppMain.gm_efct_zone_tex_reg_id != -1 )
        {
            if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( AppMain.ObjDataGet( 510 ), AppMain.gm_efct_zone_tex_reg_id ) )
            {
                AppMain.gm_efct_zone_tex_reg_id = -1;
            }
            else
            {
                flag = false;
            }
        }
        if ( flag )
        {
            if ( AppMain.gm_efct_zone_mdl_tex_reg_id_list != null )
            {
                AppMain.gm_efct_zone_mdl_tex_reg_id_list = null;
            }
            if ( AppMain.gm_efct_zone_model_reg_id_list != null )
            {
                AppMain.gm_efct_zone_model_reg_id_list = null;
                AppMain.gm_efct_zone_model_reg_num = 0;
            }
            AppMain.gm_efct_zone_target_zone_no = -1;
            AppMain.gm_efct_zone_proc_state = 0;
        }
        return flag;
    }

    // Token: 0x06001B76 RID: 7030 RVA: 0x000FB85C File Offset: 0x000F9A5C
    private static AppMain.GMS_EFFECT_3DES_WORK GmEfctZoneEsCreate( AppMain.OBS_OBJECT_WORK parent_obj, int zone_no, int efct_zone_idx )
    {
        AppMain.GMS_EFCT_ZONE_CREATE_INFO gms_EFCT_ZONE_CREATE_INFO = AppMain.gm_efct_zone_create_info[zone_no];
        AppMain.GMS_EFCT_ZONE_CREATE_PARAM gms_EFCT_ZONE_CREATE_PARAM = gms_EFCT_ZONE_CREATE_INFO.zone_create_param[efct_zone_idx];
        AppMain.OBS_DATA_WORK model_dwork;
        AppMain.OBS_DATA_WORK object_dwork;
        AppMain.OBS_DATA_WORK obs_DATA_WORK;
        AppMain.OBS_DATA_WORK texlist_dwork;
        if ( gms_EFCT_ZONE_CREATE_PARAM.create_param.model_idx != -1 )
        {
            int model_dwork_no = gms_EFCT_ZONE_CREATE_PARAM.model_dwork_no;
            int index = AppMain.gmEfctZoneGetObjectDworkNo(model_dwork_no);
            model_dwork = AppMain.ObjDataGet( model_dwork_no );
            object_dwork = AppMain.ObjDataGet( index );
            obs_DATA_WORK = AppMain.ObjDataGet( AppMain.gmEfctZoneGetMdlAmbtexDworkNo( model_dwork_no ) );
            texlist_dwork = AppMain.ObjDataGet( AppMain.gmEfctZoneGetMdlTexlistDworkNo( model_dwork_no ) );
        }
        else
        {
            model_dwork = null;
            object_dwork = null;
            obs_DATA_WORK = AppMain.ObjDataGet( 509 );
            texlist_dwork = AppMain.ObjDataGet( 510 );
        }
        return AppMain.GmEffect3dESCreateByParam( gms_EFCT_ZONE_CREATE_PARAM.create_param, parent_obj, AppMain.ObjDataGet( 6 ).pData, AppMain.ObjDataGet( AppMain.gmEfctZoneGetAmeDworkNo( zone_no, gms_EFCT_ZONE_CREATE_PARAM.create_param.ame_idx ) ), obs_DATA_WORK, texlist_dwork, model_dwork, object_dwork );
    }

    // Token: 0x06001B77 RID: 7031 RVA: 0x000FB91C File Offset: 0x000F9B1C
    private static int gmEfctZoneGetAmeDworkNo( int zone_no, int ame_amb_idx )
    {
        int num = 511;
        for ( int i = 0; i < zone_no; i++ )
        {
            num += AppMain.gm_efct_zone_texamb_index_tbl[i];
        }
        return num + ame_amb_idx;
    }

    // Token: 0x06001B78 RID: 7032 RVA: 0x000FB948 File Offset: 0x000F9B48
    private static int gmEfctZoneGetObjectDworkNo( int model_dwork_no )
    {
        return 584 + ( model_dwork_no - 582 );
    }

    // Token: 0x06001B79 RID: 7033 RVA: 0x000FB964 File Offset: 0x000F9B64
    private static int gmEfctZoneGetMdlAmbtexDworkNo( int model_dwork_no )
    {
        return 586 + ( model_dwork_no - 586 );
    }

    // Token: 0x06001B7A RID: 7034 RVA: 0x000FB980 File Offset: 0x000F9B80
    private static int gmEfctZoneGetMdlTexlistDworkNo( int model_dwork_no )
    {
        return 588 + ( model_dwork_no - 588 );
    }
}

