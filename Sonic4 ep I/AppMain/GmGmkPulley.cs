using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public partial class AppMain
{

    // Token: 0x020003C9 RID: 969
    public class GMS_GMK_PULLEY_REGISTER
    {
        // Token: 0x04006203 RID: 25091
        public ushort type;

        // Token: 0x04006204 RID: 25092
        public ushort flip;

        // Token: 0x04006205 RID: 25093
        public AppMain.VecFx32 vec;
    }

    // Token: 0x020003CA RID: 970
    public class GMS_GMK_PULLEY_MANAGER
    {
        // Token: 0x04006206 RID: 25094
        public uint tex_id;

        // Token: 0x04006207 RID: 25095
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04006208 RID: 25096
        public uint num;

        // Token: 0x04006209 RID: 25097
        public uint rsv;

        // Token: 0x0400620A RID: 25098
        public readonly AppMain.GMS_GMK_PULLEY_REGISTER[] reg = AppMain.New<AppMain.GMS_GMK_PULLEY_REGISTER>(32);
    }

    // Token: 0x020003CB RID: 971
    public class GMS_GMK_PULLEY_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x0600283A RID: 10298 RVA: 0x001529ED File Offset: 0x00150BED
        public GMS_GMK_PULLEY_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x0600283B RID: 10299 RVA: 0x00152A01 File Offset: 0x00150C01
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x0400620B RID: 25099
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x0400620C RID: 25100
        public AppMain.GSS_SND_SE_HANDLE se_handle;

        // Token: 0x0400620D RID: 25101
        public AppMain.GMS_EFFECT_3DES_WORK efct_work;
    }

    // Token: 0x06001B01 RID: 6913 RVA: 0x000F5808 File Offset: 0x000F3A08
    private static void GmGmkPulleyBuild()
    {
        AppMain.gm_gmk_pulley_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 819 ), AppMain.GmGameDatGetGimmickData( 820 ), 0U );
    }

    // Token: 0x06001B02 RID: 6914 RVA: 0x000F582C File Offset: 0x000F3A2C
    private static void GmGmkPulleyFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(819);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_pulley_obj_3d_list, ams_AMB_HEADER.file_num );
    }

    // Token: 0x06001B03 RID: 6915 RVA: 0x000F5864 File Offset: 0x000F3A64
    private static AppMain.OBS_OBJECT_WORK GmGmkPulleyBaseInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        pos_y -= 24576;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_RIDE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_PULLEY_WORK(), "GMK_PULLEY_BASE");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        ( ( AppMain.GMS_GMK_PULLEY_WORK )obs_OBJECT_WORK ).se_handle = null;
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmGmkPulleyBaseExit ) );
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_pulley_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, false, AppMain.ObjDataGet( 821 ), null, 0, null );
        AppMain.ObjDrawObjectActionSet( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194308U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[0].flag &= 4294967291U;
        gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag &= 4294967291U;
        AppMain.OBS_RECT_WORK obs_RECT_WORK = gms_ENEMY_3D_WORK.ene_com.rect_work[2];
        obs_RECT_WORK.ppHit = null;
        obs_RECT_WORK.ppDef = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmGmkPulleyDefFunc );
        AppMain.ObjRectAtkSet( obs_RECT_WORK, 0, 0 );
        AppMain.ObjRectDefSet( obs_RECT_WORK, 65534, 0 );
        AppMain.ObjRectWorkSet( obs_RECT_WORK, -4, 9, 4, 24 );
        obs_RECT_WORK.flag |= 1024U;
        obs_OBJECT_WORK.pos.z = 0;
        obs_OBJECT_WORK.ppFunc = null;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_3DNN_WORK(), obs_OBJECT_WORK, 0, "GMK_PULLEY_ROT");
        AppMain.GMS_EFFECT_3DNN_WORK gms_EFFECT_3DNN_WORK = (AppMain.GMS_EFFECT_3DNN_WORK)obs_OBJECT_WORK2;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK2, AppMain.gm_gmk_pulley_obj_3d_list[1], gms_EFFECT_3DNN_WORK.obj_3d );
        obs_OBJECT_WORK2.move_flag |= 8448U;
        obs_OBJECT_WORK2.disp_flag |= 4194304U;
        obs_OBJECT_WORK2.disp_flag &= 4294967039U;
        obs_OBJECT_WORK2.flag |= 16U;
        obs_OBJECT_WORK2.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyRotMain );
        ( ( AppMain.GMS_GMK_PULLEY_WORK )obs_OBJECT_WORK ).efct_work = null;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B04 RID: 6916 RVA: 0x000F5A98 File Offset: 0x000F3C98
    private static AppMain.OBS_OBJECT_WORK GmGmkPulleyPoleLInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        pos_y -= 24576;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_PULLEY_POLE_L");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_pulley_obj_3d_list[3], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.ppFunc = null;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyDrawSetPoleL );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B05 RID: 6917 RVA: 0x000F5B78 File Offset: 0x000F3D78
    private static AppMain.OBS_OBJECT_WORK GmGmkPulleyPoleRInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        pos_y -= 24576;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_PULLEY_POLE_R");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_pulley_obj_3d_list[2], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.ppFunc = null;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyDrawSetPoleR );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B06 RID: 6918 RVA: 0x000F5C58 File Offset: 0x000F3E58
    private static AppMain.OBS_OBJECT_WORK GmGmkPulleyRopeFInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        pos_y -= 24576;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_PULLEY_ROPE_F");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_pulley_obj_3d_list[4], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.ppFunc = null;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyDrawSetRopeN );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B07 RID: 6919 RVA: 0x000F5D38 File Offset: 0x000F3F38
    private static AppMain.OBS_OBJECT_WORK GmGmkPulleyRopeTInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        pos_y -= 24576;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_ENEMY_3D_WORK(), "GMK_PULLEY_ROPE_T");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_pulley_obj_3d_list[5], gms_ENEMY_3D_WORK.obj_3d );
        if ( eve_rec.id == 95 )
        {
            obs_OBJECT_WORK.dir.y = 32768;
        }
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        gms_ENEMY_3D_WORK.ene_com.col_work.obj_col.flag |= 134217728U;
        obs_OBJECT_WORK.pos.z = -131072;
        obs_OBJECT_WORK.ppFunc = null;
        if ( eve_rec.id == 95 )
        {
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyDrawSetRopeTL );
        }
        else
        {
            obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyDrawSetRopeTR );
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001B08 RID: 6920 RVA: 0x000F5E48 File Offset: 0x000F4048
    public static void GmGmkPulleyDrawServerMain()
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        AppMain.GMS_GMK_PULLEY_MANAGER gms_GMK_PULLEY_MANAGER = AppMain.gm_gmk_pulley_manager;
        if ( gms_GMK_PULLEY_MANAGER.num <= 0U )
        {
            return;
        }
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.type = 1;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 0;
        ams_PARAM_DRAW_PRIMITIVE.bldSrc = 768;
        ams_PARAM_DRAW_PRIMITIVE.bldDst = 774;
        ams_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        ams_PARAM_DRAW_PRIMITIVE.aTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
        ams_PARAM_DRAW_PRIMITIVE.texlist = gms_GMK_PULLEY_MANAGER.texlist;
        ams_PARAM_DRAW_PRIMITIVE.texId = ( int )gms_GMK_PULLEY_MANAGER.tex_id;
        uint col = AppMain.GmMainGetLightColor();
        ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.vwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.count = ( int )( gms_GMK_PULLEY_MANAGER.num * 6U - 2U );
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = AppMain.amDrawAlloc_NNS_PRIM3D_PCT( ams_PARAM_DRAW_PRIMITIVE.count );
        AppMain.NNS_PRIM3D_PCT[] buffer = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.buffer;
        int offset = ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D.offset;
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        int num = 0;
        while ( ( long )num < ( long )( ( ulong )gms_GMK_PULLEY_MANAGER.num ) )
        {
            int num2 = offset + num * 6;
            int num3 = offset + num * 6 - 1;
            int num4 = offset + num * 6 + 4;
            AppMain.GMS_GMK_PULLEY_REGISTER gms_GMK_PULLEY_REGISTER = gms_GMK_PULLEY_MANAGER.reg[num];
            Vector3 vector;
            vector.X = AppMain.FX_FX32_TO_F32( gms_GMK_PULLEY_REGISTER.vec.x );
            vector.Y = AppMain.FX_FX32_TO_F32( gms_GMK_PULLEY_REGISTER.vec.y );
            vector.Z = AppMain.FX_FX32_TO_F32( gms_GMK_PULLEY_REGISTER.vec.z );
            AppMain.NNS_VECTOR[] array = AppMain.gm_gmk_pulley_pos[(int)gms_GMK_PULLEY_REGISTER.type];
            AppMain.NNS_TEXCOORD[] array2 = AppMain.gm_gmk_pulley_tex[(int)gms_GMK_PULLEY_REGISTER.type];
            if ( gms_GMK_PULLEY_REGISTER.flip != 0 )
            {
                AppMain.nnMakeRotateYMatrix( nns_MATRIX, ( int )gms_GMK_PULLEY_REGISTER.flip );
            }
            float num5 = 0f;
            if ( gms_GMK_PULLEY_REGISTER.type == 2 )
            {
                num5 = 2f;
            }
            for ( int i = 0; i < 4; i++ )
            {
                if ( gms_GMK_PULLEY_REGISTER.flip != 0 )
                {
                    AppMain.nnTransformVector( nns_VECTOR, nns_MATRIX, array[i] );
                }
                else
                {
                    AppMain.nnCopyVector( nns_VECTOR, array[i] );
                }
                int num6 = num2 + i;
                buffer[num6].Pos.x = nns_VECTOR.x + vector.X;
                buffer[num6].Pos.y = nns_VECTOR.y - vector.Y + num5;
                buffer[num6].Pos.z = nns_VECTOR.z + vector.Z;
                buffer[num6].Tex.u = array2[i].u;
                buffer[num6].Tex.v = array2[i].v;
                buffer[num6].Col = col;
            }
            if ( num != 0 )
            {
                buffer[num3] = buffer[num2];
            }
            if ( ( long )num != ( long )( ( ulong )( gms_GMK_PULLEY_MANAGER.num - 1U ) ) )
            {
                buffer[num4] = buffer[num2 + 3];
            }
            num++;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeUnitMatrix( nns_MATRIX2 );
        AppMain.amMatrixPush( nns_MATRIX2 );
        AppMain.ObjDraw3DNNDrawPrimitive( ams_PARAM_DRAW_PRIMITIVE, 0U, 0, 0 );
        AppMain.amMatrixPop();
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX2 );
        gms_GMK_PULLEY_MANAGER.num = 0U;
    }

    // Token: 0x06001B09 RID: 6921 RVA: 0x000F6198 File Offset: 0x000F4398
    private static void gmGmkPulleyBaseExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_GMK_PULLEY_WORK gms_GMK_PULLEY_WORK = (AppMain.GMS_GMK_PULLEY_WORK)p;
        if ( gms_GMK_PULLEY_WORK.se_handle != null )
        {
            AppMain.GsSoundStopSeHandle( gms_GMK_PULLEY_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_PULLEY_WORK.se_handle );
            gms_GMK_PULLEY_WORK.se_handle = null;
        }
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06001B0A RID: 6922 RVA: 0x000F61E0 File Offset: 0x000F43E0
    private static void gmGmkPulleyDefFunc( AppMain.OBS_RECT_WORK mine_rect, AppMain.OBS_RECT_WORK match_rect )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)mine_rect.parent_obj;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)match_rect.parent_obj;
        if ( gms_ENEMY_COM_WORK == null )
        {
            return;
        }
        if ( gms_PLAYER_WORK == null || gms_PLAYER_WORK.obj_work.obj_type != 1 )
        {
            return;
        }
        if ( gms_PLAYER_WORK.gmk_obj == ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_COM_WORK )
        {
            return;
        }
        AppMain.GmPlySeqInitPulley( gms_PLAYER_WORK, gms_ENEMY_COM_WORK );
        AppMain.ObjDrawObjectActionSet3DNN( gms_ENEMY_COM_WORK.obj_work, 3, 0 );
        if ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) != 0U )
        {
            gms_ENEMY_COM_WORK.obj_work.dir.y = 32768;
        }
        else
        {
            gms_ENEMY_COM_WORK.obj_work.dir.y = 0;
        }
        gms_ENEMY_COM_WORK.obj_work.user_flag = ( uint )( ( ulong )gms_ENEMY_COM_WORK.obj_work.user_flag & 18446744073709518847UL );
        ( ( AppMain.OBS_OBJECT_WORK )gms_ENEMY_COM_WORK ).ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyMove );
        AppMain.ObjRectWorkSet( gms_ENEMY_COM_WORK.rect_work[2], -32, 9, 32, 24 );
    }

    // Token: 0x06001B0B RID: 6923 RVA: 0x000F62C4 File Offset: 0x000F44C4
    private static void gmGmkPulleyMove( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( gms_PLAYER_WORK.gmk_obj != obj_work )
        {
            AppMain.gmGmkPulleySecedeSet( obj_work, 0 );
            obj_work.flag |= 2U;
            obj_work.user_timer = 36;
            return;
        }
        if ( obj_work.spd.x > 0 )
        {
            obj_work.spd.x = obj_work.spd.x - 64;
            if ( obj_work.spd.x < 0 )
            {
                obj_work.spd.x = 0;
            }
        }
        else
        {
            obj_work.spd.x = obj_work.spd.x + 64;
            if ( obj_work.spd.x > 0 )
            {
                obj_work.spd.x = 0;
            }
        }
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 )
            {
                obj_work.spd.x = obj_work.spd.x - 128;
            }
            else
            {
                obj_work.spd.x = obj_work.spd.x + 128;
            }
        }
        if ( ( AppMain.g_gs_main_sys_info.game_flag & 1U ) != 0U )
        {
            int num = AppMain.MTM_MATH_CLIP(AppMain.GmPlayerKeyGetGimmickRotZ(gms_PLAYER_WORK), -24576, 24576);
            num = num * 160 / 24576;
            obj_work.spd.x = obj_work.spd.x + num;
        }
        else
        {
            int num2 = AppMain.MTM_MATH_CLIP(gms_PLAYER_WORK.key_rot_z, -24576, 24576);
            num2 = num2 * 160 / 24576;
            obj_work.spd.x = obj_work.spd.x + num2;
        }
        if ( gms_PLAYER_WORK.act_state != 59 && obj_work.spd.x > -256 && obj_work.spd.x < 256 )
        {
            obj_work.user_flag |= 32768U;
        }
        if ( ( gms_PLAYER_WORK.act_state != 59 && gms_PLAYER_WORK.act_state != 66 ) || ( gms_PLAYER_WORK.obj_work.disp_flag & 8U ) != 0U )
        {
            int num3;
            int id;
            if ( ( gms_PLAYER_WORK.obj_work.disp_flag & 1U ) != 0U )
            {
                num3 = 56;
                id = 0;
            }
            else
            {
                num3 = 56;
                id = 0;
            }
            if ( ( obj_work.spd.x < -256 || obj_work.spd.x > 256 ) && ( obj_work.user_flag & 32768U ) != 0U )
            {
                AppMain.GmPlayerActionChange( gms_PLAYER_WORK, 59 );
                AppMain.ObjDrawObjectActionSet3DNN( obj_work, 4, 0 );
                obj_work.user_flag = ( uint )( ( ulong )obj_work.user_flag & 18446744073709518847UL );
            }
            else if ( gms_PLAYER_WORK.act_state != num3 )
            {
                AppMain.GmPlayerActionChange( gms_PLAYER_WORK, num3 );
                gms_PLAYER_WORK.obj_work.disp_flag |= 4U;
                AppMain.ObjDrawObjectActionSet3DNN( obj_work, id, 0 );
                obj_work.disp_flag |= 4U;
            }
        }
        obj_work.dir.z = ( ushort )AppMain.MTM_MATH_CLIP( ( int )( ( short )( obj_work.spd.x / 4 ) ), -10240, 10240 );
        gms_ENEMY_3D_WORK.ene_com.target_dp_dir.z = obj_work.dir.z;
        int num4;
        int num5;
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 )
        {
            num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x - ( int )( gms_ENEMY_3D_WORK.ene_com.eve_rec.left * 64 ) * 4096;
            num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_x;
        }
        else
        {
            num4 = gms_ENEMY_3D_WORK.ene_com.born_pos_x;
            num5 = gms_ENEMY_3D_WORK.ene_com.born_pos_x + ( int )( gms_ENEMY_3D_WORK.ene_com.eve_rec.left * 64 ) * 4096;
        }
        if ( obj_work.pos.x < num4 )
        {
            if ( gms_PLAYER_WORK.obj_work.pos.x > num4 + 32768 )
            {
                gms_PLAYER_WORK.obj_work.pos.x = num4 + 32768;
            }
            AppMain.gmGmkPulleySonicTakeOffSet( gms_PLAYER_WORK, obj_work.spd.x );
            AppMain.gmGmkPulleySecedeSet( obj_work, num4 );
            obj_work.user_timer = 0;
        }
        else if ( obj_work.pos.x > num5 )
        {
            if ( gms_PLAYER_WORK.obj_work.pos.x < num5 - 32768 )
            {
                gms_PLAYER_WORK.obj_work.pos.x = num5 - 32768;
            }
            AppMain.gmGmkPulleySonicTakeOffSet( gms_PLAYER_WORK, obj_work.spd.x );
            AppMain.gmGmkPulleySecedeSet( obj_work, num5 );
            obj_work.user_timer = 0;
        }
        if ( obj_work.ppFunc == new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleyMove ) && AppMain.MTM_MATH_ABS( obj_work.spd.x ) > 4096 )
        {
            AppMain.gmGmkPulleySparkInit( obj_work );
        }
        else
        {
            AppMain.gmGmkPulleySparkKill( obj_work );
        }
        AppMain.ObjObjectMove( obj_work );
        if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 2 ) != 0 )
        {
            int num6 = AppMain.MTM_MATH_ABS(gms_ENEMY_3D_WORK.ene_com.born_pos_x - obj_work.pos.x);
            num6 /= 2;
            obj_work.pos.y = gms_ENEMY_3D_WORK.ene_com.born_pos_y + num6;
        }
    }

    // Token: 0x06001B0C RID: 6924 RVA: 0x000F6780 File Offset: 0x000F4980
    private static void gmGmkPulleySonicTakeOffSet( AppMain.GMS_PLAYER_WORK ply_work, int spd_x )
    {
        ply_work.obj_work.spd.y = 0;
        ply_work.obj_work.spd.z = 0;
        ply_work.obj_work.dir.z = 0;
        ply_work.obj_work.spd_m = spd_x;
        ply_work.obj_work.spd.y = -12288;
        AppMain.GmPlySeqChangeSequence( ply_work, 17 );
        if ( spd_x > 0 )
        {
            if ( ply_work.obj_work.spd.x < 16384 )
            {
                ply_work.obj_work.spd.x = 16384;
            }
            else if ( ply_work.obj_work.spd.x > 24576 )
            {
                ply_work.obj_work.spd.x = 24576;
            }
        }
        else if ( ply_work.obj_work.spd.x > -16384 )
        {
            ply_work.obj_work.spd.x = -16384;
        }
        else if ( ply_work.obj_work.spd.x < -24576 )
        {
            ply_work.obj_work.spd.x = -24576;
        }
        ply_work.obj_work.spd.x = ply_work.obj_work.spd.x / 2;
        ply_work.obj_work.spd.y = -12288;
        AppMain.GmPlySeqSetJumpState( ply_work, 0, 7U );
    }

    // Token: 0x06001B0D RID: 6925 RVA: 0x000F68E8 File Offset: 0x000F4AE8
    private static void gmGmkPulleySecedeSet( AppMain.OBS_OBJECT_WORK obj_work, int pos_x )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( pos_x != 0 )
        {
            obj_work.pos.x = pos_x;
        }
        obj_work.spd.x = 0;
        obj_work.spd.y = 0;
        obj_work.spd_m = 0;
        obj_work.dir.z = 0;
        gms_ENEMY_3D_WORK.ene_com.target_dp_dir.z = obj_work.dir.z;
        AppMain.ObjDrawObjectActionSet3DNN( obj_work, 5, 0 );
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkPulleySecede );
        AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[2], -4, 9, 4, 24 );
        AppMain.gmGmkPulleySparkKill( obj_work );
        AppMain.GMS_GMK_PULLEY_WORK gms_GMK_PULLEY_WORK = (AppMain.GMS_GMK_PULLEY_WORK)obj_work;
        if ( gms_GMK_PULLEY_WORK.se_handle != null )
        {
            AppMain.GsSoundStopSeHandle( gms_GMK_PULLEY_WORK.se_handle );
            AppMain.GsSoundFreeSeHandle( gms_GMK_PULLEY_WORK.se_handle );
            gms_GMK_PULLEY_WORK.se_handle = null;
        }
    }

    // Token: 0x06001B0E RID: 6926 RVA: 0x000F69B8 File Offset: 0x000F4BB8
    private static void gmGmkPulleySecede( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.user_timer != 0 )
        {
            obj_work.user_timer--;
            if ( obj_work.user_timer == 0 )
            {
                obj_work.flag &= 4294967293U;
            }
        }
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNN( obj_work, 0, 0 );
            obj_work.disp_flag |= 4U;
            obj_work.ppFunc = null;
        }
    }

    // Token: 0x06001B0F RID: 6927 RVA: 0x000F6A1C File Offset: 0x000F4C1C
    private static void gmGmkPulleyRotMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        obj_work.pos.Assign( parent_obj.pos );
        ushort num = (ushort)(parent_obj.spd.x >> 1);
        obj_work.dir.z = ( ushort )( obj_work.dir.z + num );
    }

    // Token: 0x06001B10 RID: 6928 RVA: 0x000F6A64 File Offset: 0x000F4C64
    private static void gmGmkPulleySparkInit( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        AppMain.GMS_GMK_PULLEY_WORK gms_GMK_PULLEY_WORK = (AppMain.GMS_GMK_PULLEY_WORK)obj_work;
        if ( gms_GMK_PULLEY_WORK.efct_work == null )
        {
            short dir_y = 0;
            short num = 0;
            gms_GMK_PULLEY_WORK.efct_work = AppMain.GmEfctZoneEsCreate( obj_work, 0, 6 );
            if ( obj_work.spd.x < 0 )
            {
                num = -16384;
                AppMain.GmComEfctAddDispOffsetF( gms_GMK_PULLEY_WORK.efct_work, 3f, 0f, 0f );
            }
            if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 2 ) != 0 )
            {
                if ( ( gms_ENEMY_3D_WORK.ene_com.eve_rec.flag & 1 ) != 0 )
                {
                    num += 4836;
                }
                else
                {
                    num += -4836;
                }
            }
            AppMain.GmComEfctAddDispRotationS( gms_GMK_PULLEY_WORK.efct_work, 0, dir_y, num );
            AppMain.GMS_GMK_PULLEY_WORK gms_GMK_PULLEY_WORK2 = (AppMain.GMS_GMK_PULLEY_WORK)obj_work;
            if ( gms_GMK_PULLEY_WORK2.se_handle == null || gms_GMK_PULLEY_WORK2.se_handle.au_player.sound[0] == null )
            {
                gms_GMK_PULLEY_WORK2.se_handle = AppMain.GsSoundAllocSeHandle();
                AppMain.GmSoundPlaySE( "Pulley", gms_GMK_PULLEY_WORK2.se_handle );
                return;
            }
            gms_GMK_PULLEY_WORK2.se_handle.snd_ctrl_param.volume = 1f;
        }
    }

    // Token: 0x06001B11 RID: 6929 RVA: 0x000F6B70 File Offset: 0x000F4D70
    private static void gmGmkPulleySparkKill( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_PULLEY_WORK gms_GMK_PULLEY_WORK = (AppMain.GMS_GMK_PULLEY_WORK)obj_work;
        if ( gms_GMK_PULLEY_WORK.efct_work != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )gms_GMK_PULLEY_WORK.efct_work );
            gms_GMK_PULLEY_WORK.efct_work = null;
            AppMain.GMS_GMK_PULLEY_WORK gms_GMK_PULLEY_WORK2 = (AppMain.GMS_GMK_PULLEY_WORK)obj_work;
            gms_GMK_PULLEY_WORK2.se_handle.snd_ctrl_param.volume = 0f;
        }
    }

    // Token: 0x06001B12 RID: 6930 RVA: 0x000F6BBF File Offset: 0x000F4DBF
    private static void gmGmkPulleyDrawSetRopeN( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkPulleyDrawSetObject( obj_work, 0 );
    }

    // Token: 0x06001B13 RID: 6931 RVA: 0x000F6BC8 File Offset: 0x000F4DC8
    private static void gmGmkPulleyDrawSetRopeTL( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkPulleyDrawSetObject( obj_work, 1 );
    }

    // Token: 0x06001B14 RID: 6932 RVA: 0x000F6BD1 File Offset: 0x000F4DD1
    private static void gmGmkPulleyDrawSetRopeTR( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkPulleyDrawSetObject( obj_work, 2 );
    }

    // Token: 0x06001B15 RID: 6933 RVA: 0x000F6BDA File Offset: 0x000F4DDA
    private static void gmGmkPulleyDrawSetPoleL( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkPulleyDrawSetObject( obj_work, 3 );
    }

    // Token: 0x06001B16 RID: 6934 RVA: 0x000F6BE3 File Offset: 0x000F4DE3
    private static void gmGmkPulleyDrawSetPoleR( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmGmkPulleyDrawSetObject( obj_work, 4 );
    }

    // Token: 0x06001B17 RID: 6935 RVA: 0x000F6BEC File Offset: 0x000F4DEC
    private static void gmGmkPulleyDrawSetObject( AppMain.OBS_OBJECT_WORK obj_work, int type )
    {
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.GMS_GMK_PULLEY_MANAGER gms_GMK_PULLEY_MANAGER = AppMain.gm_gmk_pulley_manager;
        gms_GMK_PULLEY_MANAGER.texlist = obj_work.obj_3d.texlist;
        gms_GMK_PULLEY_MANAGER.tex_id = 0U;
        AppMain.GMS_GMK_PULLEY_REGISTER gms_GMK_PULLEY_REGISTER = gms_GMK_PULLEY_MANAGER.reg[(int)((UIntPtr)gms_GMK_PULLEY_MANAGER.num)];
        gms_GMK_PULLEY_REGISTER.type = ( ushort )type;
        gms_GMK_PULLEY_REGISTER.flip = obj_work.dir.y;
        gms_GMK_PULLEY_REGISTER.vec.Assign( obj_work.pos );
        gms_GMK_PULLEY_MANAGER.num += 1U;
    }
}