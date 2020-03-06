using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000043 RID: 67
    public class GMS_EFCT_CMN_CREATE_PARAM
    {
        // Token: 0x06001DB0 RID: 7600 RVA: 0x00138683 File Offset: 0x00136883
        public GMS_EFCT_CMN_CREATE_PARAM()
        {
            this.create_param = new AppMain.GMS_EFFECT_CREATE_PARAM();
        }

        // Token: 0x06001DB1 RID: 7601 RVA: 0x00138696 File Offset: 0x00136896
        public GMS_EFCT_CMN_CREATE_PARAM( AppMain.GMS_EFFECT_CREATE_PARAM create_param, int mdl_ambtex_idx )
        {
            this.create_param = new AppMain.GMS_EFFECT_CREATE_PARAM();
            this.create_param.Assign( create_param );
            this.mdl_ambtex_idx = mdl_ambtex_idx;
        }

        // Token: 0x04004867 RID: 18535
        public readonly AppMain.GMS_EFFECT_CREATE_PARAM create_param;

        // Token: 0x04004868 RID: 18536
        public int mdl_ambtex_idx;
    }

    // Token: 0x060000A1 RID: 161 RVA: 0x000088AA File Offset: 0x00006AAA
    private static void GmEfctCmnBuildDataInit()
    {
        AppMain.gm_efct_cmn_proc_state = 1U;
    }

    // Token: 0x060000A2 RID: 162 RVA: 0x000088B4 File Offset: 0x00006AB4
    private static bool GmEfctCmnBuildDataLoopInitPart()
    {
        int num = 97 / AppMain.StageCount;
        int num2 = num * AppMain.stage;
        int num3 = num2 + num;
        if ( AppMain.stage == AppMain.StageCount - 1 )
        {
            num3 = 97;
        }
        for ( int i = num2; i < num3; i++ )
        {
            AppMain.GMS_EFCT_CMN_CREATE_PARAM gms_EFCT_CMN_CREATE_PARAM = AppMain.gm_efct_cmn_create_param_tbl[i];
            int model_idx = gms_EFCT_CMN_CREATE_PARAM.create_param.model_idx;
            int index = AppMain.gmEfctCmnGetModelDworkNo(i);
            int index2 = AppMain.gmEfctCmnGetObjectDworkNo(i);
            int mdl_ambtex_idx = gms_EFCT_CMN_CREATE_PARAM.mdl_ambtex_idx;
            int index3 = AppMain.gmEfctCmnGetMdlAmbtexDworkNo(i);
            int index4 = AppMain.gmEfctCmnGetMdlTexlistDworkNo(i);
            if ( model_idx != -1 )
            {
                AppMain.ambtex_dwork = AppMain.ObjDataGet( index3 );
                AppMain.ObjDataLoadAmbIndex( AppMain.ambtex_dwork, mdl_ambtex_idx, AppMain.eff_cmn_arc );
                AppMain.gm_efct_cmn_mdl_tex_reg_id_list[AppMain.model_reg_cnt] = AppMain.ObjAction3dESTextureLoadToDwork( AppMain.ObjDataGet( index4 ), AppMain.readAMBFile( AppMain.ambtex_dwork.pData ), ref AppMain.texlistbuf );
                AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( index ), model_idx, AppMain.eff_cmn_arc );
                AppMain.gm_efct_cmn_model_reg_id_list[AppMain.model_reg_cnt] = AppMain.ObjAction3dESModelLoadToDwork( AppMain.ObjDataGet( index2 ), ( AppMain.AmbChunk )AppMain.ObjDataGet( index ).pData, 0U );
                AppMain.model_reg_cnt++;
            }
        }
        if ( AppMain.stage == AppMain.StageCount - 1 )
        {
            AppMain.eff_cmn_arc = null;
            AppMain.ambtex_dwork = null;
            AppMain.texlistbuf = null;
            AppMain.model_reg_cnt = 0;
            AppMain.stage = 0;
            return true;
        }
        AppMain.stage++;
        return false;
    }

    // Token: 0x060000A3 RID: 163 RVA: 0x00008A10 File Offset: 0x00006C10
    private static void GmEfctCmnBuildDataLoopInit()
    {
        AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(5);
        AppMain.eff_cmn_arc = AppMain.readAMBFile( AppMain.ObjDataGetInc( pWork ) );
        AppMain.gm_efct_cmn_model_reg_num = 97;
        if ( AppMain.gm_efct_cmn_model_reg_num > 0 )
        {
            AppMain.gm_efct_cmn_model_reg_id_list = new int[AppMain.gm_efct_cmn_model_reg_num];
            AppMain.gm_efct_cmn_mdl_tex_reg_id_list = new int[AppMain.gm_efct_cmn_model_reg_num];
            for ( int i = 0; i < AppMain.gm_efct_cmn_model_reg_num; i++ )
            {
                AppMain.gm_efct_cmn_model_reg_id_list[i] = ( AppMain.gm_efct_cmn_mdl_tex_reg_id_list[i] = -1 );
            }
        }
        AppMain.ambtex_dwork = AppMain.ObjDataGet( 17 );
        AppMain.ObjDataLoadAmbIndex( AppMain.ambtex_dwork, 97, AppMain.eff_cmn_arc );
        AppMain.gm_efct_cmn_tex_reg_id = AppMain.ObjAction3dESTextureLoadToDwork( AppMain.ObjDataGet( 18 ), AppMain.readAMBFile( AppMain.ambtex_dwork.pData ), ref AppMain.texlistbuf );
        AppMain.GmEfctCmnBuildDataLoopInitPartWorking = true;
    }

    // Token: 0x060000A4 RID: 164 RVA: 0x00008ACC File Offset: 0x00006CCC
    private static bool GmEfctCmnBuildDataLoop()
    {
        bool flag = true;
        if ( AppMain.gm_efct_cmn_proc_state == 0U )
        {
            return true;
        }
        if ( AppMain.gm_efct_cmn_proc_state == 1U )
        {
            if ( AppMain.GsMainSysGetDisplayListRegistNum() < 192 )
            {
                if ( !AppMain.GmEfctCmnBuildDataLoopInitPartWorking )
                {
                    AppMain.GmEfctCmnBuildDataLoopInit();
                }
                else if ( AppMain.GmEfctCmnBuildDataLoopInitPart() )
                {
                    AppMain.gm_efct_cmn_proc_state = 2U;
                    AppMain.GmEfctCmnBuildDataLoopInitPartWorking = false;
                }
            }
            return false;
        }
        if ( AppMain.gm_efct_cmn_tex_reg_id != -1 )
        {
            if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_cmn_tex_reg_id ) )
            {
                AppMain.gm_efct_cmn_tex_reg_id = -1;
            }
            else
            {
                flag = false;
            }
        }
        for ( int i = 0; i < AppMain.gm_efct_cmn_model_reg_num; i++ )
        {
            if ( AppMain.gm_efct_cmn_mdl_tex_reg_id_list[i] != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_cmn_mdl_tex_reg_id_list[i] ) )
                {
                    AppMain.gm_efct_cmn_mdl_tex_reg_id_list[i] = -1;
                }
                else
                {
                    flag = false;
                }
            }
            if ( AppMain.gm_efct_cmn_model_reg_id_list[i] != -1 )
            {
                if ( AppMain.amDrawIsRegistComplete( AppMain.gm_efct_cmn_model_reg_id_list[i] ) )
                {
                    AppMain.gm_efct_cmn_model_reg_id_list[i] = -1;
                }
                else
                {
                    flag = false;
                }
            }
        }
        if ( flag )
        {
            AppMain.gm_efct_cmn_proc_state = 0U;
        }
        return flag;
    }

    // Token: 0x060000A5 RID: 165 RVA: 0x00008B9B File Offset: 0x00006D9B
    private static void GmEfctCmnFlushDataInit()
    {
        AppMain.gm_efct_cmn_proc_state = 1U;
    }

    // Token: 0x060000A6 RID: 166 RVA: 0x00008BA4 File Offset: 0x00006DA4
    private static void GmEfctCmnFlushDataLoopInit()
    {
        int num = 0;
        for ( int i = 0; i < 97; i++ )
        {
            AppMain.GMS_EFCT_CMN_CREATE_PARAM gms_EFCT_CMN_CREATE_PARAM = AppMain.gm_efct_cmn_create_param_tbl[i];
            int index = AppMain.gmEfctCmnGetModelDworkNo(i);
            int index2 = AppMain.gmEfctCmnGetObjectDworkNo(i);
            if ( gms_EFCT_CMN_CREATE_PARAM.create_param.model_idx != -1 )
            {
                AppMain.gm_efct_cmn_model_reg_id_list[num] = AppMain.ObjAction3dESModelReleaseDwork( AppMain.ObjDataGet( index2 ) );
                AppMain.OBS_DATA_WORK pWork = AppMain.ObjDataGet(index);
                AppMain.ObjDataRelease( pWork );
                AppMain.gm_efct_cmn_mdl_tex_reg_id_list[num] = AppMain.ObjAction3dESTextureReleaseDwork( AppMain.ObjDataGet( AppMain.gmEfctCmnGetMdlTexlistDworkNo( i ) ) );
                AppMain.ObjDataRelease( AppMain.ObjDataGet( AppMain.gmEfctCmnGetMdlAmbtexDworkNo( i ) ) );
                num++;
            }
        }
        AppMain.gm_efct_cmn_tex_reg_id = AppMain.ObjAction3dESTextureReleaseDwork( AppMain.ObjDataGet( 18 ) );
        AppMain.OBS_DATA_WORK pWork2 = AppMain.ObjDataGet(17);
        AppMain.ObjDataRelease( pWork2 );
        AppMain.OBS_DATA_WORK pWork3 = AppMain.ObjDataGet(5);
        AppMain.ObjDataRelease( pWork3 );
    }

    // Token: 0x060000A7 RID: 167 RVA: 0x00008C6C File Offset: 0x00006E6C
    private static bool GmEfctCmnFlushDataLoop()
    {
        bool flag = true;
        int num = 0;
        if ( AppMain.gm_efct_cmn_proc_state == 0U )
        {
            return true;
        }
        if ( AppMain.gm_efct_cmn_proc_state == 1U )
        {
            if ( AppMain.GsMainSysGetDisplayListRegistNum() < 240 )
            {
                AppMain.GmEfctCmnFlushDataLoopInit();
                AppMain.gm_efct_cmn_proc_state = 2U;
            }
            return false;
        }
        if ( AppMain.gm_efct_cmn_model_reg_num != 0 )
        {
            for ( int i = 0; i < 97; i++ )
            {
                AppMain.GMS_EFCT_CMN_CREATE_PARAM gms_EFCT_CMN_CREATE_PARAM = AppMain.gm_efct_cmn_create_param_tbl[i];
                if ( gms_EFCT_CMN_CREATE_PARAM.create_param.model_idx != -1 )
                {
                    if ( AppMain.gm_efct_cmn_model_reg_id_list[num] != -1 )
                    {
                        int index = AppMain.gmEfctCmnGetObjectDworkNo(i);
                        if ( AppMain.ObjAction3dESModelReleaseDworkCheck( AppMain.ObjDataGet( index ), AppMain.gm_efct_cmn_model_reg_id_list[num] ) )
                        {
                            AppMain.gm_efct_cmn_model_reg_id_list[num] = -1;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if ( AppMain.gm_efct_cmn_mdl_tex_reg_id_list[num] != -1 )
                    {
                        if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( AppMain.ObjDataGet( AppMain.gmEfctCmnGetMdlTexlistDworkNo( i ) ), AppMain.gm_efct_cmn_mdl_tex_reg_id_list[num] ) )
                        {
                            AppMain.gm_efct_cmn_mdl_tex_reg_id_list[num] = -1;
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
        if ( AppMain.gm_efct_cmn_tex_reg_id != -1 )
        {
            if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( AppMain.ObjDataGet( 18 ), AppMain.gm_efct_cmn_tex_reg_id ) )
            {
                AppMain.gm_efct_cmn_tex_reg_id = -1;
            }
            else
            {
                flag = false;
            }
        }
        if ( flag )
        {
            if ( AppMain.gm_efct_cmn_mdl_tex_reg_id_list != null )
            {
                AppMain.gm_efct_cmn_mdl_tex_reg_id_list = null;
            }
            if ( AppMain.gm_efct_cmn_model_reg_id_list != null )
            {
                AppMain.gm_efct_cmn_model_reg_id_list = null;
                AppMain.gm_efct_cmn_model_reg_num = 0;
            }
            AppMain.gm_efct_cmn_proc_state = 0U;
        }
        return flag;
    }

    // Token: 0x060000A8 RID: 168 RVA: 0x00008D90 File Offset: 0x00006F90
    private static AppMain.GMS_EFFECT_3DES_WORK GmEfctCmnEsCreate( AppMain.OBS_OBJECT_WORK parent_obj, int efct_cmn_idx )
    {
        AppMain.GMS_EFCT_CMN_CREATE_PARAM gms_EFCT_CMN_CREATE_PARAM = AppMain.gm_efct_cmn_create_param_tbl[efct_cmn_idx];
        AppMain.OBS_DATA_WORK model_dwork;
        AppMain.OBS_DATA_WORK object_dwork;
        AppMain.OBS_DATA_WORK obs_DATA_WORK;
        AppMain.OBS_DATA_WORK texlist_dwork;
        if ( gms_EFCT_CMN_CREATE_PARAM.create_param.model_idx != -1 )
        {
            int ame_idx = gms_EFCT_CMN_CREATE_PARAM.create_param.ame_idx;
            model_dwork = AppMain.ObjDataGet( AppMain.gmEfctCmnGetModelDworkNo( ame_idx ) );
            object_dwork = AppMain.ObjDataGet( AppMain.gmEfctCmnGetObjectDworkNo( ame_idx ) );
            obs_DATA_WORK = AppMain.ObjDataGet( AppMain.gmEfctCmnGetMdlAmbtexDworkNo( ame_idx ) );
            texlist_dwork = AppMain.ObjDataGet( AppMain.gmEfctCmnGetMdlTexlistDworkNo( ame_idx ) );
        }
        else
        {
            model_dwork = null;
            object_dwork = null;
            obs_DATA_WORK = AppMain.ObjDataGet( 17 );
            texlist_dwork = AppMain.ObjDataGet( 18 );
        }
        return AppMain.GmEffect3dESCreateByParam( gms_EFCT_CMN_CREATE_PARAM.create_param, parent_obj, AppMain.ObjDataGet( 5 ).pData, AppMain.ObjDataGet( AppMain.gmEfctCmnGetAmeDworkNo( gms_EFCT_CMN_CREATE_PARAM.create_param.ame_idx ) ), obs_DATA_WORK, texlist_dwork, model_dwork, object_dwork );
    }

    // Token: 0x060000A9 RID: 169 RVA: 0x00008E44 File Offset: 0x00007044
    private static void GmEfctCmnUpdateInvincibleMainPart( AppMain.GMS_EFFECT_3DES_WORK efct_3des )
    {
        AppMain.OBS_OBJECT_WORK obj_work = efct_3des.efct_com.obj_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = obj_work;
        obs_OBJECT_WORK.dir.z = ( ushort )( obs_OBJECT_WORK.dir.z + 1820 );
    }

    // Token: 0x060000AA RID: 170 RVA: 0x00008E78 File Offset: 0x00007078
    private static void GmEfctCmnUpdateInvincibleSubPart( AppMain.GMS_EFFECT_3DES_WORK efct_3des, AppMain.OBS_OBJECT_WORK ply_obj )
    {
        AppMain.OBS_OBJECT_WORK obj_work = efct_3des.efct_com.obj_work;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = obj_work;
        obs_OBJECT_WORK.dir.z = ( ushort )( obs_OBJECT_WORK.dir.z + 1820 );
        obj_work.spd.x = AppMain.FX_Mul( ply_obj.pos.x - obj_work.pos.x, 204 );
        obj_work.spd.y = AppMain.FX_Mul( ply_obj.pos.y - obj_work.pos.y, 204 );
        if ( ( obj_work.spd.x > 0 && ply_obj.move.x > 0 ) || ( obj_work.spd.x < 0 && ply_obj.move.x < 0 ) )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obj_work;
            obs_OBJECT_WORK2.spd.x = obs_OBJECT_WORK2.spd.x + AppMain.FX_Mul( ply_obj.move.x, 1024 );
        }
        if ( ( obj_work.spd.y > 0 && ply_obj.move.y > 0 ) || ( obj_work.spd.y < 0 && ply_obj.move.y < 0 ) )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obj_work;
            obs_OBJECT_WORK3.spd.y = obs_OBJECT_WORK3.spd.y + AppMain.FX_Mul( ply_obj.move.y, 1024 );
        }
    }

    // Token: 0x060000AB RID: 171 RVA: 0x00008FBF File Offset: 0x000071BF
    private static int gmEfctCmnGetAmeDworkNo( int ame_idx )
    {
        return 19 + ame_idx;
    }

    // Token: 0x060000AC RID: 172 RVA: 0x00008FC5 File Offset: 0x000071C5
    private static int gmEfctCmnGetModelDworkNo( int ame_idx )
    {
        return 117 + ame_idx;
    }

    // Token: 0x060000AD RID: 173 RVA: 0x00008FCB File Offset: 0x000071CB
    private static int gmEfctCmnGetObjectDworkNo( int ame_idx )
    {
        return 215 + ame_idx;
    }

    // Token: 0x060000AE RID: 174 RVA: 0x00008FD4 File Offset: 0x000071D4
    private static int gmEfctCmnGetMdlAmbtexDworkNo( int ame_idx )
    {
        return 313 + ame_idx;
    }

    // Token: 0x060000AF RID: 175 RVA: 0x00008FDD File Offset: 0x000071DD
    private static int gmEfctCmnGetMdlTexlistDworkNo( int ame_idx )
    {
        return 411 + ame_idx;
    }
}