using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060008DA RID: 2266 RVA: 0x00050571 File Offset: 0x0004E771
    public static void GmGmkBridgeBuild()
    {
        AppMain.gm_gmk_bridge_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 878 ), AppMain.GmGameDatGetGimmickData( 879 ), 0U );
    }

    // Token: 0x060008DB RID: 2267 RVA: 0x00050594 File Offset: 0x0004E794
    public static void GmGmkBridgeFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(AppMain.GmGameDatGetGimmickData(878));
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_bridge_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x060008DC RID: 2268 RVA: 0x000505D0 File Offset: 0x0004E7D0
    public static AppMain.OBS_OBJECT_WORK GmGmkBridgeInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_BRIDGE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_bridge_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        if ( ( eve_rec.flag & 1 ) != 0 )
        {
            obs_OBJECT_WORK.user_work = 3U;
        }
        else
        {
            obs_OBJECT_WORK.user_work = 2U;
        }
        obs_OBJECT_WORK.user_flag = 0U;
        obs_OBJECT_WORK.user_timer = 0;
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBridgeMain );
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBridgeDrawFunc );
        AppMain.OBS_COLLISION_WORK col_work = gms_ENEMY_3D_WORK.ene_com.col_work;
        col_work.obj_col.obj = obs_OBJECT_WORK;
        col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        col_work.obj_col.flag |= 134217728U;
        col_work.obj_col.width = ( ushort )( obs_OBJECT_WORK.user_work * 64U );
        col_work.obj_col.height = 16;
        col_work.obj_col.ofst_x = -96;
        col_work.obj_col.ofst_y = 0;
        col_work.obj_col.attr = 1;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GMK_SPILE");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK2;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_bridge_obj_3d_list[2], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK2.user_work = obs_OBJECT_WORK.user_work;
        obs_OBJECT_WORK2.pos.z = -131072;
        obs_OBJECT_WORK2.move_flag |= 8448U;
        obs_OBJECT_WORK2.disp_flag |= 4194304U;
        obs_OBJECT_WORK2.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBridgeDecoDrawFunc );
        obs_OBJECT_WORK2.obj_3d.drawflag |= 32U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x060008DD RID: 2269 RVA: 0x000507D8 File Offset: 0x0004E9D8
    public static void gmGmkBridgeMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.rider_obj == gms_PLAYER_WORK.obj_work )
        {
            if ( obj_work.user_timer < 16 )
            {
                obj_work.user_timer++;
            }
            obj_work.user_flag = ( uint )gms_PLAYER_WORK.obj_work.pos.x;
        }
        else if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
        }
        if ( obj_work.user_timer != 0 )
        {
            int num = (int)(obj_work.user_work * 53248U * 5U);
            num >>= 1;
            int numer = (int)(obj_work.user_flag - (uint)(obj_work.pos.x + -393216 + num));
            int num2 = AppMain.FX_Div(numer, num);
            num2 = AppMain.MTM_MATH_CLIP( num2, -4096, 4096 );
            num2 <<= 2;
            int a = AppMain.mtMathCos(num2) * 8 * obj_work.user_timer / 16;
            gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = ( short )( AppMain.MTM_MATH_ABS( a ) >> 12 );
            return;
        }
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y = 0;
    }

    // Token: 0x060008DE RID: 2270 RVA: 0x00050904 File Offset: 0x0004EB04
    public static void gmGmkBridgeDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        int num = (int)(obj_work.user_work * 53248U * 5U);
        int num2 = (int)(obj_work.user_flag - (uint)(obj_work.pos.x + -393216));
        int denom = num2;
        int denom2 = num - num2;
        int v = (int)gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.ofst_y << 12;
        obj_work.ofst.x = -366592;
        obj_work.ofst.y = 26624;
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        uint col = AppMain.GmMainGetLightColor();
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        AppMain.VecFx32 vecFx = default(AppMain.VecFx32);
        vecFx.x = obj_work.pos.x + obj_work.ofst.x;
        vecFx.y = -( obj_work.pos.y + obj_work.ofst.y );
        vecFx.z = obj_work.pos.z + obj_work.ofst.z;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, AppMain.FX_FX32_TO_F32( vecFx.x ), AppMain.FX_FX32_TO_F32( vecFx.y ), AppMain.FX_FX32_TO_F32( vecFx.z ) );
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.type = 0;
        ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 30U * obj_work.user_work );
        ams_PARAM_DRAW_PRIMITIVE.ablend = 0;
        ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
        ams_PARAM_DRAW_PRIMITIVE.bldDst = 771;
        ams_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        ams_PARAM_DRAW_PRIMITIVE.aTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
        ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.vwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.texlist = texlist;
        ams_PARAM_DRAW_PRIMITIVE.texId = 0;
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( ams_PARAM_DRAW_PRIMITIVE.count );
        AppMain.NNS_PRIM3D_PCT[] buffer = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
        int offset = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        for ( int i = 0; i < ( int )( ( short )obj_work.user_work ); i++ )
        {
            for ( int j = 0; j < 5; j++ )
            {
                if ( obj_work.user_timer != 0 )
                {
                    int num3 = i * 53248 * 5 + j * 53248;
                    int v2;
                    if ( num3 < num2 )
                    {
                        v2 = AppMain.FX_Div( num3, denom );
                    }
                    else if ( num3 > num2 )
                    {
                        num3 = num - num3;
                        v2 = AppMain.FX_Div( num3, denom2 );
                    }
                    else
                    {
                        v2 = 4096;
                    }
                    obj_work.ofst.y = 26624 + AppMain.FX_Mul( v, v2 ) * obj_work.user_timer / 16;
                }
                int num4 = j + 5 * i;
                float num5 = AppMain.FX_FX32_TO_F32(53248 * num4);
                float num6 = AppMain.FX_FX32_TO_F32(obj_work.ofst.y);
                int num7 = offset + num4 * 6;
                buffer[num7].Tex.u = ( buffer[num7 + 1].Tex.u = 0.1f );
                buffer[num7 + 2].Tex.u = ( buffer[num7 + 3].Tex.u = 0.9f );
                buffer[num7].Tex.v = ( buffer[num7 + 2].Tex.v = 0.1f );
                buffer[num7 + 1].Tex.v = ( buffer[num7 + 3].Tex.v = 0.9f );
                buffer[num7].Col = col;
                buffer[num7 + 1].Col = ( buffer[num7 + 2].Col = ( buffer[num7 + 3].Col = buffer[num7].Col ) );
                buffer[num7].Pos.x = ( buffer[num7 + 1].Pos.x = 6.5f + num5 );
                buffer[num7 + 2].Pos.x = ( buffer[num7 + 3].Pos.x = -6.5f + num5 );
                buffer[num7].Pos.y = ( buffer[num7 + 2].Pos.y = 13f - num6 );
                buffer[num7 + 1].Pos.y = ( buffer[num7 + 3].Pos.y = -1f - num6 );
                buffer[num7].Pos.z = ( buffer[num7 + 1].Pos.z = ( buffer[num7 + 2].Pos.z = ( buffer[num7 + 3].Pos.z = -1f ) ) );
                buffer[num7 + 4] = buffer[num7 + 2];
                buffer[num7 + 5] = buffer[num7 + 3];
                buffer[num7 + 3] = buffer[num7 + 1];
            }
        }
        AppMain.amMatrixPush( nns_MATRIX );
        AppMain.ObjDraw3DNNDrawPrimitive( ams_PARAM_DRAW_PRIMITIVE );
        AppMain.amMatrixPop();
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x060008DF RID: 2271 RVA: 0x00050EB8 File Offset: 0x0004F0B8
    public static void gmGmkBridgeDecoDrawFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.scale.x = -AppMain.MTM_MATH_ABS( obj_work.scale.x );
        obj_work.ofst.x = -393216;
        AppMain.ObjDrawActionSummary( obj_work );
        obj_work.scale.x = -obj_work.scale.x;
        obj_work.ofst.x = ( int )( 18446744073709158400UL + ( ulong )( obj_work.user_work * 53248U * 5U ) );
        AppMain.ObjDrawActionSummary( obj_work );
    }
}
