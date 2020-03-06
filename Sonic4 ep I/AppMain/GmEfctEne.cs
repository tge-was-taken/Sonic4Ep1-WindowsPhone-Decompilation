using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000077 RID: 119
    public class GMS_EFCT_ENE_CREATE_PARAM
    {
        // Token: 0x06001E32 RID: 7730 RVA: 0x0013975C File Offset: 0x0013795C
        public GMS_EFCT_ENE_CREATE_PARAM()
        {
            this.create_param = new AppMain.GMS_EFFECT_CREATE_PARAM();
        }

        // Token: 0x06001E33 RID: 7731 RVA: 0x0013976F File Offset: 0x0013796F
        public GMS_EFCT_ENE_CREATE_PARAM( AppMain.GMS_EFFECT_CREATE_PARAM create_param, int arc_dwork_no, int ambtex_dwork_no, int ame_dwork_no, int ambtex_idx, uint stage_flag )
        {
            this.create_param = create_param;
            this.arc_dwork_no = arc_dwork_no;
            this.ambtex_dwork_no = ambtex_dwork_no;
            this.ame_dwork_no = ame_dwork_no;
            this.ambtex_idx = ambtex_idx;
            this.stage_flag = stage_flag;
        }

        // Token: 0x04004998 RID: 18840
        public readonly AppMain.GMS_EFFECT_CREATE_PARAM create_param;

        // Token: 0x04004999 RID: 18841
        public int arc_dwork_no;

        // Token: 0x0400499A RID: 18842
        public int ambtex_dwork_no;

        // Token: 0x0400499B RID: 18843
        public int ame_dwork_no;

        // Token: 0x0400499C RID: 18844
        public int ambtex_idx;

        // Token: 0x0400499D RID: 18845
        public uint stage_flag;
    }

    // Token: 0x0600029C RID: 668 RVA: 0x000160C6 File Offset: 0x000142C6
    public static uint GMM_EFCT_ENE_STAGE_FLAG( int stage_no )
    {
        return 1U << stage_no;
    }

    // Token: 0x0600029D RID: 669 RVA: 0x000160CE File Offset: 0x000142CE
    public static int GMM_EFCT_ENE_ARC_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.arc_dwork_no;
    }

    // Token: 0x0600029E RID: 670 RVA: 0x000160D6 File Offset: 0x000142D6
    public static int GMM_EFCT_ENE_AMBTEX_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ambtex_dwork_no;
    }

    // Token: 0x0600029F RID: 671 RVA: 0x000160DE File Offset: 0x000142DE
    public static int GMM_EFCT_ENE_TEXLIST_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ambtex_dwork_no + 1;
    }

    // Token: 0x060002A0 RID: 672 RVA: 0x000160E8 File Offset: 0x000142E8
    public static int GMM_EFCT_ENE_AME_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ame_dwork_no;
    }

    // Token: 0x060002A1 RID: 673 RVA: 0x000160F0 File Offset: 0x000142F0
    public static int GMM_EFCT_ENE_MODEL_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ame_dwork_no + 1;
    }

    // Token: 0x060002A2 RID: 674 RVA: 0x000160FA File Offset: 0x000142FA
    public static int GMM_EFCT_ENE_OBJECT_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ame_dwork_no + 2;
    }

    // Token: 0x060002A3 RID: 675 RVA: 0x00016104 File Offset: 0x00014304
    public static int GMM_EFCT_ENE_MDL_AMBTEX_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ame_dwork_no + 3;
    }

    // Token: 0x060002A4 RID: 676 RVA: 0x0001610E File Offset: 0x0001430E
    public static int GMM_EFCT_ENE_MDL_TEXLIST_DW_NO( AppMain.GMS_EFCT_ENE_CREATE_PARAM p_cr_param )
    {
        return p_cr_param.ame_dwork_no + 4;
    }

    // Token: 0x060002A5 RID: 677 RVA: 0x00016118 File Offset: 0x00014318
    public static void GmEfctEneBuildDataInit( int zone_no )
    {
        object obj = null;
        for ( int i = 0; i < 13; i++ )
        {
            AppMain.gm_efct_ene_tex_reg_id_list[i] = -1;
            AppMain.gm_efct_ene_model_reg_id_list[i] = -1;
        }
        AppMain.gm_efct_ene_target_zone_no = zone_no;
        for ( int j = 0; j < 13; j++ )
        {
            AppMain.GMS_EFCT_ENE_CREATE_PARAM gms_EFCT_ENE_CREATE_PARAM = AppMain.gm_efct_ene_create_param_tbl[j];
            int arc_dwork_no = gms_EFCT_ENE_CREATE_PARAM.arc_dwork_no;
            if ( ( gms_EFCT_ENE_CREATE_PARAM.stage_flag & AppMain.GMM_EFCT_ENE_STAGE_FLAG( zone_no ) ) != 0U )
            {
                AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(arc_dwork_no);
                AppMain.AMS_AMB_HEADER amb = AppMain.readAMBFile(AppMain.ObjDataGetInc(pWork));
                int model_idx = gms_EFCT_ENE_CREATE_PARAM.create_param.model_idx;
                int index = AppMain.GMM_EFCT_ENE_MODEL_DW_NO(gms_EFCT_ENE_CREATE_PARAM);
                int index2 = AppMain.GMM_EFCT_ENE_OBJECT_DW_NO(gms_EFCT_ENE_CREATE_PARAM);
                AppMain.OBS_DATA_WORK obs_DATA_WORK;
                AppMain.OBS_DATA_WORK texlist_dwork;
                if ( model_idx != -1 )
                {
                    AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( index ), model_idx, amb );
                    AppMain.gm_efct_ene_model_reg_id_list[j] = AppMain.ObjAction3dESModelLoadToDwork( AppMain.ObjDataGet( index2 ), ( AppMain.AmbChunk )AppMain.ObjDataGet( index ).pData, 0U );
                    obs_DATA_WORK = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MDL_AMBTEX_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                    texlist_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MDL_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                }
                else
                {
                    obs_DATA_WORK = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_AMBTEX_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                    texlist_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                }
                AppMain.ObjDataLoadAmbIndex( obs_DATA_WORK, gms_EFCT_ENE_CREATE_PARAM.ambtex_idx, amb );
                AppMain.gm_efct_ene_tex_reg_id_list[j] = AppMain.ObjAction3dESTextureLoadToDwork( texlist_dwork, AppMain.readAMBFile( obs_DATA_WORK.pData ), ref obj );
            }
        }
    }

    // Token: 0x060002A6 RID: 678 RVA: 0x00016260 File Offset: 0x00014460
    public static bool GmEfctEneBuildDataLoop()
    {
        bool flag = true;
        if ( AppMain.gm_efct_ene_target_zone_no == -1 )
        {
            return flag;
        }
        for ( int i = 0; i < 13; i++ )
        {
            AppMain.GMS_EFCT_ENE_CREATE_PARAM gms_EFCT_ENE_CREATE_PARAM = AppMain.gm_efct_ene_create_param_tbl[i];
            if ( ( gms_EFCT_ENE_CREATE_PARAM.stage_flag & AppMain.GMM_EFCT_ENE_STAGE_FLAG( AppMain.gm_efct_ene_target_zone_no ) ) != 0U )
            {
                if ( AppMain.gm_efct_ene_tex_reg_id_list[i] != -1 )
                {
                    if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_ene_tex_reg_id_list[i] ) )
                    {
                        AppMain.gm_efct_ene_tex_reg_id_list[i] = -1;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if ( AppMain.gm_efct_ene_model_reg_id_list[i] != -1 )
                {
                    if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_ene_model_reg_id_list[i] ) )
                    {
                        AppMain.gm_efct_ene_model_reg_id_list[i] = -1;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
        }
        if ( flag )
        {
            AppMain.gm_efct_ene_target_zone_no = -1;
        }
        return flag;
    }

    // Token: 0x060002A7 RID: 679 RVA: 0x000162F4 File Offset: 0x000144F4
    public static void GmEfctEneFlushDataInit( int zone_no )
    {
        AppMain.gm_efct_ene_target_zone_no = zone_no;
        for ( int i = 0; i < 13; i++ )
        {
            AppMain.GMS_EFCT_ENE_CREATE_PARAM gms_EFCT_ENE_CREATE_PARAM = AppMain.gm_efct_ene_create_param_tbl[i];
            if ( ( gms_EFCT_ENE_CREATE_PARAM.stage_flag & AppMain.GMM_EFCT_ENE_STAGE_FLAG( zone_no ) ) != 0U )
            {
                AppMain.OBS_DATA_WORK pWork;
                AppMain.OBS_DATA_WORK texlist_dwork;
                if ( gms_EFCT_ENE_CREATE_PARAM.create_param.model_idx != -1 )
                {
                    AppMain.gm_efct_ene_model_reg_id_list[i] = AppMain.ObjAction3dESModelReleaseDwork( AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_OBJECT_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ) );
                    AppMain.ObjDataRelease( AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MODEL_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ) );
                    pWork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MDL_AMBTEX_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                    texlist_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MDL_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                }
                else
                {
                    pWork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_AMBTEX_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                    texlist_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                }
                AppMain.gm_efct_ene_tex_reg_id_list[i] = AppMain.ObjAction3dESTextureReleaseDwork( texlist_dwork );
                AppMain.ObjDataRelease( pWork );
                AppMain.ObjDataRelease( AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_ARC_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ) );
            }
        }
    }

    // Token: 0x060002A8 RID: 680 RVA: 0x000163C0 File Offset: 0x000145C0
    public static bool GmEfctEneFlushDataLoop()
    {
        bool flag = true;
        if ( AppMain.gm_efct_ene_target_zone_no == -1 )
        {
            return flag;
        }
        for ( int i = 0; i < 13; i++ )
        {
            AppMain.GMS_EFCT_ENE_CREATE_PARAM gms_EFCT_ENE_CREATE_PARAM = AppMain.gm_efct_ene_create_param_tbl[i];
            if ( ( gms_EFCT_ENE_CREATE_PARAM.stage_flag & AppMain.GMM_EFCT_ENE_STAGE_FLAG( AppMain.gm_efct_ene_target_zone_no ) ) != 0U )
            {
                AppMain.OBS_DATA_WORK texlist_dwork;
                if ( gms_EFCT_ENE_CREATE_PARAM.create_param.model_idx != -1 )
                {
                    texlist_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MDL_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                }
                else
                {
                    texlist_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
                }
                if ( AppMain.gm_efct_ene_model_reg_id_list[i] != -1 )
                {
                    if ( AppMain.ObjAction3dESModelReleaseDworkCheck( AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_OBJECT_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ), AppMain.gm_efct_ene_model_reg_id_list[i] ) )
                    {
                        AppMain.gm_efct_ene_model_reg_id_list[i] = -1;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if ( AppMain.gm_efct_ene_tex_reg_id_list[i] != -1 )
                {
                    if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( texlist_dwork, AppMain.gm_efct_ene_tex_reg_id_list[i] ) )
                    {
                        AppMain.gm_efct_ene_tex_reg_id_list[i] = -1;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
        }
        if ( flag )
        {
            AppMain.gm_efct_ene_target_zone_no = -1;
        }
        return flag;
    }

    // Token: 0x060002A9 RID: 681 RVA: 0x00016490 File Offset: 0x00014690
    public static AppMain.GMS_EFFECT_3DES_WORK GmEfctEneEsCreate( AppMain.OBS_OBJECT_WORK parent_obj, int efct_ene_idx )
    {
        AppMain.GMS_EFCT_ENE_CREATE_PARAM gms_EFCT_ENE_CREATE_PARAM = AppMain.gm_efct_ene_create_param_tbl[efct_ene_idx];
        AppMain.OBS_DATA_WORK model_dwork;
        AppMain.OBS_DATA_WORK object_dwork;
        if ( gms_EFCT_ENE_CREATE_PARAM.create_param.model_idx != -1 )
        {
            model_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_MODEL_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
            object_dwork = AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_OBJECT_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) );
        }
        else
        {
            model_dwork = null;
            object_dwork = null;
        }
        return AppMain.GmEffect3dESCreateByParam( gms_EFCT_ENE_CREATE_PARAM.create_param, parent_obj, AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_ARC_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ).pData, AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_AME_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ), AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_AMBTEX_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ), AppMain.ObjDataGet( AppMain.GMM_EFCT_ENE_TEXLIST_DW_NO( gms_EFCT_ENE_CREATE_PARAM ) ), model_dwork, object_dwork );
    }
}
