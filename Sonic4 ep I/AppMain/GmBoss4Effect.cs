using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000078 RID: 120
    public class GMS_BOSS4_EFF_BOMB_WORK
    {
        // Token: 0x0400499E RID: 18846
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x0400499F RID: 18847
        public int bomb_type;

        // Token: 0x040049A0 RID: 18848
        public uint interval_timer;

        // Token: 0x040049A1 RID: 18849
        public uint interval_min;

        // Token: 0x040049A2 RID: 18850
        public uint interval_max;

        // Token: 0x040049A3 RID: 18851
        public readonly int[] pos = new int[2];

        // Token: 0x040049A4 RID: 18852
        public readonly int[] area = new int[2];

        // Token: 0x040049A5 RID: 18853
        public int interval_timer_sound;
    }

    // Token: 0x02000079 RID: 121
    public class GMS_BOSS4_EFF_COMMON_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E35 RID: 7733 RVA: 0x001397C4 File Offset: 0x001379C4
        public GMS_BOSS4_EFF_COMMON_WORK()
        {
            this.eff_3des = new AppMain.GMS_EFFECT_3DES_WORK( this );
        }

        // Token: 0x06001E36 RID: 7734 RVA: 0x001397EE File Offset: 0x001379EE
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_3des.efct_com.obj_work;
        }

        // Token: 0x040049A6 RID: 18854
        public readonly AppMain.GMS_EFFECT_3DES_WORK eff_3des;

        // Token: 0x040049A7 RID: 18855
        public AppMain.GMS_BOSS4_NODE_MATRIX node_work;

        // Token: 0x040049A8 RID: 18856
        public int link;

        // Token: 0x040049A9 RID: 18857
        public readonly AppMain.NNS_VECTOR ofs = new AppMain.NNS_VECTOR();

        // Token: 0x040049AA RID: 18858
        public readonly AppMain.NNS_VECTOR rot = new AppMain.NNS_VECTOR();

        // Token: 0x040049AB RID: 18859
        public uint[] lookflag;

        // Token: 0x040049AC RID: 18860
        public uint lookmask;
    }

    // Token: 0x060002AA RID: 682 RVA: 0x00016514 File Offset: 0x00014714
    private static void GmBoss4EffectBuild()
    {
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 735 ), 5, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 736 ), 6, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 737 ), 7, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 738 ), 8, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 739 ), 9, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 740 ), 10, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 741 ), 11, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 742 ), 12, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 743 ), 13, AppMain.GMD_BOSS4_ARC );
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 744 ), 14, AppMain.GMD_BOSS4_ARC );
        for ( int i = 0; i < 9; i++ )
        {
            AppMain.GmEfctBossBuildSingleDataReg( 15, AppMain.ObjDataGet( 733 ), AppMain.ObjDataGet( 734 ), 0, null, null, AppMain.GMD_BOSS4_ARC );
        }
    }

    // Token: 0x060002AB RID: 683 RVA: 0x00016634 File Offset: 0x00014834
    private static void GmBoss4EffectFlush()
    {
        AppMain.GmEfctBossFlushSingleDataInit();
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 735 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 736 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 737 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 738 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 739 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 740 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 741 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 742 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 743 ) );
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 744 ) );
    }

    // Token: 0x060002AC RID: 684 RVA: 0x000166DC File Offset: 0x000148DC
    private static void GmBoss4EffChangeType( AppMain.GMS_EFFECT_3DES_WORK efct_work, uint type, uint init_flag )
    {
        efct_work.efct_com.obj_work.ppFunc = null;
        AppMain.GmEffect3DESSetupBase( efct_work, type, init_flag );
        efct_work.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffMainFuncDeleteAtEnd );
    }

    // Token: 0x060002AD RID: 685 RVA: 0x00016714 File Offset: 0x00014914
    private static AppMain.GMS_EFFECT_3DES_WORK GmBoss4EffCommonInit( int id, AppMain.VecFx32? pos )
    {
        return AppMain.GmBoss4EffCommonInit( id, pos, null, 2U, 1U, null, -1, default( AppMain.VecFx32? ), null, 0U );
    }

    // Token: 0x060002AE RID: 686 RVA: 0x00016738 File Offset: 0x00014938
    private static AppMain.GMS_EFFECT_3DES_WORK GmBoss4EffCommonInit( int id, AppMain.VecFx32? pos, AppMain.OBS_OBJECT_WORK parent_obj )
    {
        return AppMain.GmBoss4EffCommonInit( id, pos, parent_obj, 2U, 1U, null, -1, default( AppMain.VecFx32? ), null, 0U );
    }

    // Token: 0x060002AF RID: 687 RVA: 0x00016764 File Offset: 0x00014964
    private static AppMain.GMS_EFFECT_3DES_WORK GmBoss4EffCommonInit( int id, AppMain.VecFx32? pos, AppMain.OBS_OBJECT_WORK parent_obj, uint type, uint flag, AppMain.GMS_BOSS4_NODE_MATRIX mtx, int link, AppMain.VecFx32? rot, uint[] ctrl_flag, uint mask )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_BOSS4_EFF_COMMON_WORK(), parent_obj, 0, "B04_CapOver");
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = (AppMain.GMS_EFFECT_3DES_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS4_EFF_COMMON_WORK gms_BOSS4_EFF_COMMON_WORK = (AppMain.GMS_BOSS4_EFF_COMMON_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectAction3dESEffectLoad( AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ), gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( id ), null, 0, null );
        AppMain.ObjObjectAction3dESTextureLoad( AppMain.GMM_BS_OBJ( gms_EFFECT_3DES_WORK ), gms_EFFECT_3DES_WORK.obj_3des, AppMain.ObjDataGet( 733 ), null, 0, null, false );
        AppMain.ObjObjectAction3dESTextureSetByDwork( obs_OBJECT_WORK, AppMain.ObjDataGet( 734 ) );
        AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, type, flag );
        if ( pos != null )
        {
            AppMain.VEC_Set( ref obs_OBJECT_WORK.pos, pos.Value.x, pos.Value.y, pos.Value.z );
        }
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffMainFuncFlagLink );
        obs_OBJECT_WORK.flag |= 32U;
        gms_BOSS4_EFF_COMMON_WORK.lookflag = ctrl_flag;
        gms_BOSS4_EFF_COMMON_WORK.lookmask = mask;
        if ( gms_BOSS4_EFF_COMMON_WORK.lookflag != null )
        {
            gms_BOSS4_EFF_COMMON_WORK.lookflag[0] |= gms_BOSS4_EFF_COMMON_WORK.lookmask;
        }
        gms_BOSS4_EFF_COMMON_WORK.link = -1;
        if ( link >= 0 )
        {
            gms_BOSS4_EFF_COMMON_WORK.link = link;
            gms_BOSS4_EFF_COMMON_WORK.node_work = mtx;
            if ( rot != null )
            {
                AppMain.GmEffect3DESSetDispRotation( gms_EFFECT_3DES_WORK, AppMain.AKM_DEGtoA16( AppMain.FX_FX32_TO_F32( rot.Value.x ) ), AppMain.AKM_DEGtoA16( AppMain.FX_FX32_TO_F32( rot.Value.y ) ), AppMain.AKM_DEGtoA16( AppMain.FX_FX32_TO_F32( rot.Value.z ) ) );
            }
            if ( pos != null )
            {
                AppMain.GmEffect3DESAddDispOffset( gms_EFFECT_3DES_WORK, AppMain.FX_FX32_TO_F32( pos.Value.x ), AppMain.FX_FX32_TO_F32( pos.Value.y ), AppMain.FX_FX32_TO_F32( pos.Value.z ) );
            }
        }
        return gms_EFFECT_3DES_WORK;
    }

    // Token: 0x060002B0 RID: 688 RVA: 0x00016940 File Offset: 0x00014B40
    private static void GmBoss4EffBombInitCreate( AppMain.GMS_BOSS4_EFF_BOMB_WORK bomb_work, int bomb_type, AppMain.OBS_OBJECT_WORK parent_obj, int pos_x, int pos_y, int width, int height, uint interval_min, uint interval_max )
    {
        AppMain.MTM_ASSERT( bomb_work );
        AppMain.MTM_ASSERT( parent_obj );
        bomb_work.parent_obj = parent_obj;
        bomb_work.bomb_type = bomb_type;
        bomb_work.interval_timer = 0U;
        bomb_work.interval_min = interval_min;
        bomb_work.interval_max = interval_max;
        bomb_work.pos[0] = pos_x;
        bomb_work.pos[1] = pos_y;
        bomb_work.area[0] = width;
        bomb_work.area[1] = height;
        bomb_work.interval_timer_sound = 0;
    }

    // Token: 0x060002B1 RID: 689 RVA: 0x000169AC File Offset: 0x00014BAC
    private static void GmBoss4EffBombUpdateCreate( AppMain.GMS_BOSS4_EFF_BOMB_WORK bomb_work )
    {
        AppMain.MTM_ASSERT( bomb_work.parent_obj );
        bomb_work.pos[0] += AppMain.GmBoss4GetScrollOffset();
        if ( bomb_work.interval_timer != 0U )
        {
            bomb_work.interval_timer -= 1U;
            return;
        }
        int num = bomb_work.area[0];
        int num2 = bomb_work.area[1];
        int num3 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num);
        int num4 = AppMain.FX_Mul(AppMain.AkMathRandFx(), num2);
        int bomb_type = bomb_work.bomb_type;
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK;
        if ( bomb_type != 0 )
        {
            if ( bomb_type != 5 )
            {
                AppMain.MTM_ASSERT( false );
                return;
            }
            gms_EFFECT_3DES_WORK = AppMain.GmBoss4EffCommonInit( 743, default( AppMain.VecFx32? ) );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = null;
            AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, 2U, 64U );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffMainFuncDeleteAtEnd );
        }
        else
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( null, 7 );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = null;
            AppMain.GmEffect3DESSetupBase( gms_EFFECT_3DES_WORK, 2U, 1U );
            gms_EFFECT_3DES_WORK.efct_com.obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4EffMainFuncDeleteAtEnd );
            if ( --bomb_work.interval_timer_sound <= 0 )
            {
                bomb_work.interval_timer_sound = 3;
                AppMain.GmSoundPlaySE( "Boss0_02" );
            }
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(gms_EFFECT_3DES_WORK);
        AppMain.MTM_ASSERT( obs_OBJECT_WORK );
        obs_OBJECT_WORK.pos.x = bomb_work.pos[0] - ( num >> 1 ) + num3;
        obs_OBJECT_WORK.pos.y = bomb_work.pos[1] - ( num2 >> 1 ) + num4;
        obs_OBJECT_WORK.pos.z = AppMain.GMM_BS_OBJ( bomb_work.parent_obj ).pos.z + 131072;
        uint num5 = (uint)((long)AppMain.AkMathRandFx() * (long)((ulong)(bomb_work.interval_max - bomb_work.interval_max)) >> 12);
        bomb_work.interval_timer = bomb_work.interval_min + num5;
    }

    // Token: 0x060002B2 RID: 690 RVA: 0x00016B88 File Offset: 0x00014D88
    private static void gmBoss4EffMainFuncFlagLink( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_EFF_COMMON_WORK gms_BOSS4_EFF_COMMON_WORK = (AppMain.GMS_BOSS4_EFF_COMMON_WORK)obj_work;
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
        }
        else
        {
            obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
            if ( gms_BOSS4_EFF_COMMON_WORK.lookflag != null )
            {
                gms_BOSS4_EFF_COMMON_WORK.lookflag[0] &= ~gms_BOSS4_EFF_COMMON_WORK.lookmask;
            }
        }
        if ( gms_BOSS4_EFF_COMMON_WORK.lookflag != null && ( gms_BOSS4_EFF_COMMON_WORK.lookflag[0] & gms_BOSS4_EFF_COMMON_WORK.lookmask ) == 0U )
        {
            AppMain.ObjDrawKillAction3DES( obj_work );
        }
        if ( gms_BOSS4_EFF_COMMON_WORK.link >= 0 )
        {
            AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS4_EFF_COMMON_WORK.node_work.snm_work, gms_BOSS4_EFF_COMMON_WORK.node_work.work[gms_BOSS4_EFF_COMMON_WORK.link], 1 );
        }
    }

    // Token: 0x060002B3 RID: 691 RVA: 0x00016C72 File Offset: 0x00014E72
    private static void gmBoss4EffMainFuncDeleteAtEnd( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x060002B4 RID: 692 RVA: 0x00016CA4 File Offset: 0x00014EA4
    private static void gmBoss4EffDamageInit( object body_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.GMM_BS_OBJ(body_work);
        AppMain.GMS_EFFECT_3DES_WORK obj = AppMain.GmEfctBossCmnEsCreate(parent_obj, 0U);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(obj);
        obs_OBJECT_WORK.pos.z = obs_OBJECT_WORK.pos.z + 131072;
    }
}