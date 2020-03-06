using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002DB RID: 731
    public class GMS_EFFECT_3DNN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024C3 RID: 9411 RVA: 0x0014B253 File Offset: 0x00149453
        public GMS_EFFECT_3DNN_WORK()
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
        }

        // Token: 0x060024C4 RID: 9412 RVA: 0x0014B272 File Offset: 0x00149472
        public GMS_EFFECT_3DNN_WORK( object _holder )
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
            this.holder = _holder;
        }

        // Token: 0x060024C5 RID: 9413 RVA: 0x0014B298 File Offset: 0x00149498
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_com.obj_work;
        }

        // Token: 0x060024C6 RID: 9414 RVA: 0x0014B2A5 File Offset: 0x001494A5
        public static explicit operator AppMain.GMS_GMK_PRESSWALL_PARTS( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_PRESSWALL_PARTS )work.holder;
        }

        // Token: 0x060024C7 RID: 9415 RVA: 0x0014B2B2 File Offset: 0x001494B2
        public static explicit operator AppMain.GMS_GMK_SEESAWPARTS_WORK( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_SEESAWPARTS_WORK )work.holder;
        }

        // Token: 0x060024C8 RID: 9416 RVA: 0x0014B2BF File Offset: 0x001494BF
        public static explicit operator AppMain.GMS_GMK_POPSTEAMPARTS_WORK( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_POPSTEAMPARTS_WORK )work.holder;
        }

        // Token: 0x060024C9 RID: 9417 RVA: 0x0014B2CC File Offset: 0x001494CC
        public static explicit operator AppMain.GMS_GMK_PISTONROD_WORK( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_PISTONROD_WORK )work.holder;
        }

        // Token: 0x060024CA RID: 9418 RVA: 0x0014B2D9 File Offset: 0x001494D9
        public static explicit operator AppMain.GMS_GMK_CANNONPARTS_WORK( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_CANNONPARTS_WORK )work.holder;
        }

        // Token: 0x060024CB RID: 9419 RVA: 0x0014B2E6 File Offset: 0x001494E6
        public static explicit operator AppMain.GMS_BOSS5_LDPART_WORK( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_BOSS5_LDPART_WORK )work.holder;
        }

        // Token: 0x060024CC RID: 9420 RVA: 0x0014B2F3 File Offset: 0x001494F3
        public static explicit operator AppMain.GMS_GMK_SLOTPARTS_WORK( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_SLOTPARTS_WORK )work.holder;
        }

        // Token: 0x060024CD RID: 9421 RVA: 0x0014B300 File Offset: 0x00149500
        public static explicit operator AppMain.GMS_GMK_BWALL_PARTS( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_BWALL_PARTS )work.holder;
        }

        // Token: 0x060024CE RID: 9422 RVA: 0x0014B30D File Offset: 0x0014950D
        public static explicit operator AppMain.GMS_GMK_BOBJ_PARTS( AppMain.GMS_EFFECT_3DNN_WORK work )
        {
            return ( AppMain.GMS_GMK_BOBJ_PARTS )work.holder;
        }

        // Token: 0x04005C5F RID: 23647
        public AppMain.GMS_EFFECT_COM_WORK efct_com;

        // Token: 0x04005C60 RID: 23648
        public AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04005C61 RID: 23649
        public readonly object holder;
    }

    // Token: 0x020002DC RID: 732
    public class GMS_EFFECT_CREATE_PARAM
    {
        // Token: 0x060024CF RID: 9423 RVA: 0x0014B31C File Offset: 0x0014951C
        public GMS_EFFECT_CREATE_PARAM( int ame_idx, uint pos_type, uint init_flag, AppMain.NNS_VECTOR disp_ofst, AppMain.NNS_ROTATE_A16 disp_rot, float scale, AppMain.MPP_VOID_OBS_OBJECT_WORK main_func, int model_idx )
        {
            this.ame_idx = ame_idx;
            this.pos_type = pos_type;
            this.init_flag = init_flag;
            this.disp_ofst = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            this.disp_ofst.Assign( disp_ofst );
            this.disp_rot = disp_rot;
            this.scale = scale;
            this.main_func = main_func;
            this.model_idx = model_idx;
        }

        // Token: 0x060024D0 RID: 9424 RVA: 0x0014B37D File Offset: 0x0014957D
        public GMS_EFFECT_CREATE_PARAM()
        {
            this.disp_ofst = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
            this.disp_rot = default( AppMain.NNS_ROTATE_A16 );
        }

        // Token: 0x060024D1 RID: 9425 RVA: 0x0014B39C File Offset: 0x0014959C
        public void Assign( AppMain.GMS_EFFECT_CREATE_PARAM param )
        {
            this.ame_idx = param.ame_idx;
            this.pos_type = param.pos_type;
            this.init_flag = param.init_flag;
            this.disp_ofst.Assign( param.disp_ofst );
            this.disp_rot = param.disp_rot;
            this.scale = param.scale;
            this.main_func = param.main_func;
            this.model_idx = param.model_idx;
        }

        // Token: 0x04005C62 RID: 23650
        public int ame_idx;

        // Token: 0x04005C63 RID: 23651
        public uint pos_type;

        // Token: 0x04005C64 RID: 23652
        public uint init_flag;

        // Token: 0x04005C65 RID: 23653
        public readonly AppMain.NNS_VECTOR disp_ofst;

        // Token: 0x04005C66 RID: 23654
        public AppMain.NNS_ROTATE_A16 disp_rot;

        // Token: 0x04005C67 RID: 23655
        public float scale;

        // Token: 0x04005C68 RID: 23656
        public AppMain.MPP_VOID_OBS_OBJECT_WORK main_func;

        // Token: 0x04005C69 RID: 23657
        public int model_idx;
    }

    // Token: 0x020002DD RID: 733
    public class GMS_EFFECT_3DES_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024D2 RID: 9426 RVA: 0x0014B40F File Offset: 0x0014960F
        public void Clear()
        {
            this.efct_com.Clear();
            this.obj_3des.Clear();
            this.saved_pos_type = 0U;
            this.saved_init_flag = 0U;
        }

        // Token: 0x060024D3 RID: 9427 RVA: 0x0014B435 File Offset: 0x00149635
        public static explicit operator AppMain.GMS_EFFECT_COM_WORK( AppMain.GMS_EFFECT_3DES_WORK work )
        {
            return work.efct_com;
        }

        // Token: 0x060024D4 RID: 9428 RVA: 0x0014B43D File Offset: 0x0014963D
        public static explicit operator AppMain.GMS_BOSS5_EFCT_GENERAL_WORK( AppMain.GMS_EFFECT_3DES_WORK work )
        {
            return ( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK )work.m_pHolder;
        }

        // Token: 0x060024D5 RID: 9429 RVA: 0x0014B44A File Offset: 0x0014964A
        public static explicit operator AppMain.GMS_BOSS4_EFF_COMMON_WORK( AppMain.GMS_EFFECT_3DES_WORK work )
        {
            return ( AppMain.GMS_BOSS4_EFF_COMMON_WORK )work.m_pHolder;
        }

        // Token: 0x060024D6 RID: 9430 RVA: 0x0014B457 File Offset: 0x00149657
        public static explicit operator AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK( AppMain.GMS_EFFECT_3DES_WORK work )
        {
            return ( AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK )work.m_pHolder;
        }

        // Token: 0x060024D7 RID: 9431 RVA: 0x0014B464 File Offset: 0x00149664
        public static explicit operator AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK( AppMain.GMS_EFFECT_3DES_WORK work )
        {
            return ( AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK )work.m_pHolder;
        }

        // Token: 0x060024D8 RID: 9432 RVA: 0x0014B471 File Offset: 0x00149671
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.efct_com.obj_work;
        }

        // Token: 0x060024D9 RID: 9433 RVA: 0x0014B47E File Offset: 0x0014967E
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_EFFECT_3DES_WORK work )
        {
            return work.efct_com.obj_work;
        }

        // Token: 0x060024DA RID: 9434 RVA: 0x0014B48B File Offset: 0x0014968B
        public GMS_EFFECT_3DES_WORK()
        {
            this.efct_com = new AppMain.GMS_EFFECT_COM_WORK( this );
        }

        // Token: 0x060024DB RID: 9435 RVA: 0x0014B4B5 File Offset: 0x001496B5
        public GMS_EFFECT_3DES_WORK( object pHolder ) : this()
        {
            this.m_pHolder = pHolder;
        }

        // Token: 0x04005C6A RID: 23658
        public readonly AppMain.GMS_EFFECT_COM_WORK efct_com = new AppMain.GMS_EFFECT_COM_WORK();

        // Token: 0x04005C6B RID: 23659
        public readonly AppMain.OBS_ACTION3D_ES_WORK obj_3des = new AppMain.OBS_ACTION3D_ES_WORK();

        // Token: 0x04005C6C RID: 23660
        public uint saved_pos_type;

        // Token: 0x04005C6D RID: 23661
        public uint saved_init_flag;

        // Token: 0x04005C6E RID: 23662
        public object m_pHolder;
    }

    // Token: 0x020002DE RID: 734
    public class GMS_EFFECT_COM_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060024DC RID: 9436 RVA: 0x0014B4C4 File Offset: 0x001496C4
        public void Clear()
        {
            this.obj_work.Clear();
            for ( int i = 0; i < 2; i++ )
            {
                this.rect_work[i].Clear();
            }
        }

        // Token: 0x060024DD RID: 9437 RVA: 0x0014B4F5 File Offset: 0x001496F5
        public static explicit operator AppMain.GMS_BOSS1_FLASH_SCREEN_WORK( AppMain.GMS_EFFECT_COM_WORK p )
        {
            return ( AppMain.GMS_BOSS1_FLASH_SCREEN_WORK )p.holder;
        }

        // Token: 0x060024DE RID: 9438 RVA: 0x0014B502 File Offset: 0x00149702
        public static explicit operator AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( AppMain.GMS_EFFECT_COM_WORK p )
        {
            return ( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT )p.holder;
        }

        // Token: 0x060024DF RID: 9439 RVA: 0x0014B50F File Offset: 0x0014970F
        public static explicit operator AppMain.GMS_EFFECT_COM_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            if ( work.holder is AppMain.GMS_EFFECT_COM_WORK )
            {
                return ( AppMain.GMS_EFFECT_COM_WORK )work.holder;
            }
            return ( ( AppMain.GMS_EFFECT_3DES_WORK )work.holder ).efct_com;
        }

        // Token: 0x060024E0 RID: 9440 RVA: 0x0014B53A File Offset: 0x0014973A
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x060024E1 RID: 9441 RVA: 0x0014B542 File Offset: 0x00149742
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_EFFECT_COM_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x060024E2 RID: 9442 RVA: 0x0014B54A File Offset: 0x0014974A
        public GMS_EFFECT_COM_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x060024E3 RID: 9443 RVA: 0x0014B56A File Offset: 0x0014976A
        public GMS_EFFECT_COM_WORK( object _holder )
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
            this.holder = _holder;
        }

        // Token: 0x060024E4 RID: 9444 RVA: 0x0014B591 File Offset: 0x00149791
        public static explicit operator AppMain.GMS_GMK_POPSTEAMPARTS_WORK( AppMain.GMS_EFFECT_COM_WORK work )
        {
            return ( AppMain.GMS_GMK_POPSTEAMPARTS_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )work.holder );
        }

        // Token: 0x060024E5 RID: 9445 RVA: 0x0014B5A3 File Offset: 0x001497A3
        public static explicit operator AppMain.GMS_BOSS5_FLASH_SCREEN_WORK( AppMain.GMS_EFFECT_COM_WORK work )
        {
            return ( AppMain.GMS_BOSS5_FLASH_SCREEN_WORK )work.holder;
        }

        // Token: 0x060024E6 RID: 9446 RVA: 0x0014B5B0 File Offset: 0x001497B0
        public static explicit operator AppMain.GMS_EFFECT_3DES_WORK( AppMain.GMS_EFFECT_COM_WORK work )
        {
            return ( AppMain.GMS_EFFECT_3DES_WORK )work.holder;
        }

        // Token: 0x04005C6F RID: 23663
        public AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04005C70 RID: 23664
        public AppMain.OBS_RECT_WORK[] rect_work = AppMain.New<AppMain.OBS_RECT_WORK>(2);

        // Token: 0x04005C71 RID: 23665
        public readonly object holder;
    }

    // Token: 0x06001414 RID: 5140 RVA: 0x000B235D File Offset: 0x000B055D
    public static AppMain.OBS_OBJECT_WORK GMM_EFFECT_CREATE_WORK( AppMain.TaskWorkFactoryDelegate work_size, AppMain.OBS_OBJECT_WORK parent_obj, ushort sort_prio, string name )
    {
        return AppMain.GmEffectCreateWork( work_size, parent_obj, sort_prio );
    }

    // Token: 0x06001415 RID: 5141 RVA: 0x000B2367 File Offset: 0x000B0567
    private static void GmEffectInit()
    {
    }

    // Token: 0x06001416 RID: 5142 RVA: 0x000B2369 File Offset: 0x000B0569
    private static void GmEffectExit()
    {
    }

    // Token: 0x06001417 RID: 5143 RVA: 0x000B236C File Offset: 0x000B056C
    private static AppMain.OBS_OBJECT_WORK GmEffectCreateWork( AppMain.TaskWorkFactoryDelegate work_size, AppMain.OBS_OBJECT_WORK parent_obj, ushort sort_prio )
    {
        if ( work_size == null )
        {
            work_size = AppMain._GmEffectCreateWork_Delegate;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT((ushort)(6656 + sort_prio), 3, 0, 0, work_size, null);
        if ( obs_OBJECT_WORK == null )
        {
            return null;
        }
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, AppMain._GmEffectDefaultExit );
        obs_OBJECT_WORK.obj_type = 5;
        obs_OBJECT_WORK.ppOut = AppMain._ObjDrawActionSummaryDelegate;
        obs_OBJECT_WORK.ppOutSub = null;
        obs_OBJECT_WORK.ppIn = null;
        obs_OBJECT_WORK.ppMove = AppMain._ObjObjectMoveDelegate;
        obs_OBJECT_WORK.ppActCall = null;
        obs_OBJECT_WORK.ppRec = AppMain._gmEffectDefaultRecFuncDelegate;
        obs_OBJECT_WORK.ppLast = null;
        obs_OBJECT_WORK.spd_fall = 672;
        obs_OBJECT_WORK.spd_fall_max = 61440;
        if ( parent_obj != null )
        {
            obs_OBJECT_WORK.parent_obj = parent_obj;
            obs_OBJECT_WORK.pos.x = parent_obj.pos.x;
            obs_OBJECT_WORK.pos.y = parent_obj.pos.y;
            obs_OBJECT_WORK.pos.z = parent_obj.pos.z;
        }
        obs_OBJECT_WORK.disp_flag |= 256U;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.flag |= 1U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001418 RID: 5144 RVA: 0x000B2493 File Offset: 0x000B0693
    private static void GmEffectDefaultExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.ObjObjectExit( tcb );
    }

    // Token: 0x06001419 RID: 5145 RVA: 0x000B249C File Offset: 0x000B069C
    private static AppMain.GMS_EFFECT_3DES_WORK GmEffect3dESCreateByParam( AppMain.GMS_EFFECT_CREATE_PARAM create_param, AppMain.OBS_OBJECT_WORK parent_obj, object arc, AppMain.OBS_DATA_WORK ame_dwork, AppMain.OBS_DATA_WORK ambtex_dwork, AppMain.OBS_DATA_WORK texlist_dwork, AppMain.OBS_DATA_WORK model_dwork, AppMain.OBS_DATA_WORK object_dwork )
    {
        return AppMain.GmEffect3dESCreateByParam( create_param, parent_obj, arc, ame_dwork, ambtex_dwork, texlist_dwork, model_dwork, object_dwork, AppMain._GmEffect3dESTaskDelegate );
    }

    // Token: 0x0600141A RID: 5146 RVA: 0x000B24C8 File Offset: 0x000B06C8
    private static AppMain.GMS_EFFECT_3DES_WORK GmEffect3dESCreateByParam( AppMain.GMS_EFFECT_CREATE_PARAM create_param, AppMain.OBS_OBJECT_WORK parent_obj, object arc, AppMain.OBS_DATA_WORK ame_dwork, AppMain.OBS_DATA_WORK ambtex_dwork, AppMain.OBS_DATA_WORK texlist_dwork, AppMain.OBS_DATA_WORK model_dwork, AppMain.OBS_DATA_WORK object_dwork, AppMain.TaskWorkFactoryDelegate work_size )
    {
        if ( work_size == null )
        {
            work_size = ( () => new AppMain.GMS_EFFECT_3DES_WORK() );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(work_size, parent_obj, 0, "EF_3DES_CREATE_BY_PARAM");
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectAction3dESEffectLoad( obs_OBJECT_WORK, gms_EFFECT_3DES_WORK.obj_3des, ame_dwork, null, create_param.ame_idx, ( AppMain.AMS_AMB_HEADER )arc );
        AppMain.ObjObjectAction3dESTextureLoad( obs_OBJECT_WORK, obs_OBJECT_WORK.obj_3des, ambtex_dwork, null, 0, null, false );
        AppMain.ObjObjectAction3dESTextureSetByDwork( obs_OBJECT_WORK, texlist_dwork );
        if ( model_dwork != null && create_param.model_idx != -1 )
        {
            AppMain.ObjObjectAction3dESModelLoad( obs_OBJECT_WORK, obs_OBJECT_WORK.obj_3des, model_dwork, null, 0, null, 0U, false );
            if ( object_dwork != null )
            {
                AppMain.ObjObjectAction3dESModelSetByDwork( obs_OBJECT_WORK, object_dwork );
            }
        }
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, create_param.pos_type, create_param.init_flag );
        AppMain.GmEffect3DESSetDispOffset( gms_EFFECT_3DES_WORK, create_param.disp_ofst.x, create_param.disp_ofst.y, create_param.disp_ofst.z );
        AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, create_param.disp_rot.x, create_param.disp_rot.y, create_param.disp_rot.z );
        AppMain.GmEffect3DESSetScale( gms_EFFECT_3DES_WORK, create_param.scale );
        obs_OBJECT_WORK.ppFunc = create_param.main_func;
        return gms_EFFECT_3DES_WORK;
    }

    // Token: 0x0600141B RID: 5147 RVA: 0x000B25F0 File Offset: 0x000B07F0
    private static AppMain.GMS_EFFECT_3DES_WORK GmEffect3dESCreateDummy( AppMain.OBS_OBJECT_WORK parent_obj )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DES_WORK(), parent_obj, 0, "EF_3DES_DUMMY");
        obs_OBJECT_WORK.disp_flag |= 8U;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.obj_3des = gms_EFFECT_3DES_WORK.obj_3des;
        obs_OBJECT_WORK.ppOut = null;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.GmEffectDefaultMainFuncDeleteAtEnd );
        return gms_EFFECT_3DES_WORK;
    }

    // Token: 0x0600141C RID: 5148 RVA: 0x000B2664 File Offset: 0x000B0864
    private static void GmEffectRectInit( AppMain.GMS_EFFECT_COM_WORK efct_com, ushort[] atk_flag_tbl, ushort[] def_flag_tbl, byte my_group, byte target_group_flag )
    {
        AppMain.OBS_OBJECT_WORK obj_work = efct_com.obj_work;
        AppMain.ObjObjectGetRectBuf( obj_work, efct_com.rect_work, 2 );
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.ObjRectGroupSet( efct_com.rect_work[i], my_group, target_group_flag );
            AppMain.ObjRectAtkSet( efct_com.rect_work[i], atk_flag_tbl[i], 1 );
            AppMain.ObjRectDefSet( efct_com.rect_work[i], def_flag_tbl[i], 0 );
            efct_com.rect_work[i].parent_obj = obj_work;
            efct_com.rect_work[i].flag &= 4294967291U;
        }
        efct_com.rect_work[0].ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.GmEffectDefaultDefFunc );
        efct_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.GmEffectDefaultAtkFunc );
    }

    // Token: 0x0600141D RID: 5149 RVA: 0x000B271E File Offset: 0x000B091E
    private static void GmEffectDefaultDefFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
    }

    // Token: 0x0600141E RID: 5150 RVA: 0x000B2720 File Offset: 0x000B0920
    private static void GmEffectDefaultAtkFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
    }

    // Token: 0x0600141F RID: 5151 RVA: 0x000B2724 File Offset: 0x000B0924
    private static void GmEffect3DESSetupBase( AppMain.GMS_EFFECT_3DES_WORK efct_3des, uint pos_type, uint init_flag )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)efct_3des;
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = obs_OBJECT_WORK.obj_3des;
        efct_3des.saved_pos_type = pos_type;
        efct_3des.saved_init_flag = init_flag;
        switch ( pos_type )
        {
            case 0U:
                obj_3des.flag &= 4294967294U;
                obj_3des.flag &= 4294967293U;
                break;
            case 1U:
                obj_3des.flag |= 1U;
                obj_3des.flag &= 4294967293U;
                break;
            case 2U:
                obj_3des.flag |= 1U;
                obj_3des.flag |= 2U;
                break;
            default:
                AppMain.mppAssertNotImpl();
                break;
        }
        if ( ( init_flag & 1U ) != 0U )
        {
            obs_OBJECT_WORK.disp_flag |= 4194304U;
        }
        else
        {
            obs_OBJECT_WORK.disp_flag &= 4290772991U;
        }
        if ( ( init_flag & 2U ) != 0U )
        {
            obs_OBJECT_WORK.flag |= 1024U;
        }
        else
        {
            obs_OBJECT_WORK.flag &= 4294966271U;
        }
        if ( ( init_flag & 4U ) != 0U )
        {
            obj_3des.flag |= 8U;
        }
        else
        {
            obj_3des.flag &= 4294967287U;
        }
        if ( ( init_flag & 16U ) != 0U )
        {
            obs_OBJECT_WORK.disp_flag &= 4294967039U;
        }
        else
        {
            obs_OBJECT_WORK.disp_flag |= 256U;
        }
        if ( ( init_flag & 64U ) != 0U )
        {
            obj_3des.flag |= 16U;
        }
        else
        {
            obj_3des.flag &= 4294967279U;
        }
        if ( ( init_flag & 32U ) != 0U )
        {
            obs_OBJECT_WORK.flag &= 4294443007U;
        }
        else
        {
            obs_OBJECT_WORK.flag |= 524288U;
        }
        obs_OBJECT_WORK.ppFunc = AppMain._GmEffectDefaultMainFuncDeleteAtEnd;
    }

    // Token: 0x06001420 RID: 5152 RVA: 0x000B28C8 File Offset: 0x000B0AC8
    private static void GmEffect3DESChangeBase( AppMain.GMS_EFFECT_3DES_WORK efct_3des, uint pos_type, uint init_flag )
    {
        AppMain.OBS_OBJECT_WORK obj_work = efct_3des.efct_com.obj_work;
        AppMain.MPP_VOID_OBS_OBJECT_WORK ppFunc = obj_work.ppFunc;
        obj_work.ppFunc = null;
        AppMain.GmEffect3DESSetupBase( efct_3des, pos_type, init_flag );
        obj_work.ppFunc = ppFunc;
    }

    // Token: 0x06001421 RID: 5153 RVA: 0x000B2900 File Offset: 0x000B0B00
    private static void GmEffect3DESSetDispOffset( AppMain.GMS_EFFECT_3DES_WORK efct_3des, float ofst_x, float ofst_y, float ofst_z )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = efct_3des.efct_com.obj_work.obj_3des;
        AppMain.amVectorSet( obj_3des.disp_ofst, ofst_x, ofst_y, ofst_z );
    }

    // Token: 0x06001422 RID: 5154 RVA: 0x000B292C File Offset: 0x000B0B2C
    private static void GmEffect3DESAddDispOffset( AppMain.GMS_EFFECT_3DES_WORK efct_3des, float ofst_add_x, float ofst_add_y, float ofst_add_z )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = efct_3des.efct_com.obj_work.obj_3des;
        AppMain.amVectorAdd( obj_3des.disp_ofst, ofst_add_x, ofst_add_y, ofst_add_z );
    }

    // Token: 0x06001423 RID: 5155 RVA: 0x000B2958 File Offset: 0x000B0B58
    private static void GmEffect3DESSetDispOffsetCircleX( AppMain.GMS_EFFECT_3DES_WORK efct_3des, float radius, short angle )
    {
        AppMain.GmEffect3DESSetDispOffset( efct_3des, 0f, radius * AppMain.nnSin( ( int )angle ), radius * AppMain.nnCos( ( int )angle ) );
    }

    // Token: 0x06001424 RID: 5156 RVA: 0x000B2978 File Offset: 0x000B0B78
    private static void GmEffect3DESSetDispRotation( AppMain.GMS_EFFECT_3DES_WORK efct_3des, short rot_x, short rot_y, short rot_z )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = efct_3des.efct_com.obj_work.obj_3des;
        obj_3des.disp_rot.x = ( ushort )rot_x;
        obj_3des.disp_rot.y = ( ushort )rot_y;
        obj_3des.disp_rot.z = ( ushort )rot_z;
    }

    // Token: 0x06001425 RID: 5157 RVA: 0x000B29C0 File Offset: 0x000B0BC0
    private static void GmEffect3DESAddDispRotation( AppMain.GMS_EFFECT_3DES_WORK efct_3des, short rot_add_x, short rot_add_y, short rot_add_z )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = efct_3des.efct_com.obj_work.obj_3des;
        obj_3des.disp_rot.x = ( ushort )( ( short )( 65535L & ( long )( obj_3des.disp_rot.x + ( ushort )rot_add_x ) ) );
        obj_3des.disp_rot.y = ( ushort )( ( short )( 65535L & ( long )( obj_3des.disp_rot.y + ( ushort )rot_add_y ) ) );
        obj_3des.disp_rot.z = ( ushort )( ( short )( 65535L & ( long )( obj_3des.disp_rot.z + ( ushort )rot_add_z ) ) );
    }

    // Token: 0x06001426 RID: 5158 RVA: 0x000B2A44 File Offset: 0x000B0C44
    private static void GmEffect3DESSetDuplicateDraw( AppMain.GMS_EFFECT_3DES_WORK efct_3des, float ofst_x, float ofst_y, float ofst_z )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = efct_3des.efct_com.obj_work.obj_3des;
        AppMain.amVectorSet( obj_3des.dup_draw_ofst, ofst_x, ofst_y, ofst_z );
        obj_3des.flag |= 64U;
    }

    // Token: 0x06001427 RID: 5159 RVA: 0x000B2A80 File Offset: 0x000B0C80
    private static void GmEffect3DESClearDuplicateDraw( AppMain.GMS_EFFECT_3DES_WORK efct_3des )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = efct_3des.efct_com.obj_work.obj_3des;
        AppMain.amVectorInit( obj_3des.dup_draw_ofst );
        obj_3des.flag &= 4294967231U;
    }

    // Token: 0x06001428 RID: 5160 RVA: 0x000B2AB8 File Offset: 0x000B0CB8
    private static void GmEffectDefaultMainFuncDeleteAtEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x06001429 RID: 5161 RVA: 0x000B2AD2 File Offset: 0x000B0CD2
    private static void GmEffectDefaultMainFuncDeleteAtEndCopyDirZ( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( obj_work.parent_obj != null )
        {
            obj_work.dir.z = obj_work.parent_obj.dir.z;
        }
    }

    // Token: 0x0600142A RID: 5162 RVA: 0x000B2B0F File Offset: 0x000B0D0F
    private static void gmEffectDefaultRecFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x0600142B RID: 5163 RVA: 0x000B2B14 File Offset: 0x000B0D14
    private static void GmEffect3DESSetScale( AppMain.GMS_EFFECT_3DES_WORK efct_3des, float scale_rate )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)efct_3des;
        obs_OBJECT_WORK.scale.x = ( obs_OBJECT_WORK.scale.y = ( obs_OBJECT_WORK.scale.z = AppMain.FX_F32_TO_FX32( scale_rate ) ) );
    }
}