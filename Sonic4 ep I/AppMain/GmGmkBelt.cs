using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000074 RID: 116
    public class GMS_GMK_BELTC_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E27 RID: 7719 RVA: 0x00139688 File Offset: 0x00137888
        public GMS_GMK_BELTC_WORK()
        {
            this.gmk_work = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x06001E28 RID: 7720 RVA: 0x0013969C File Offset: 0x0013789C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001E29 RID: 7721 RVA: 0x001396AE File Offset: 0x001378AE
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_GMK_BELTC_WORK work )
        {
            return work.gmk_work.ene_com.obj_work;
        }

        // Token: 0x06001E2A RID: 7722 RVA: 0x001396C0 File Offset: 0x001378C0
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_GMK_BELTC_WORK work )
        {
            return work.gmk_work;
        }

        // Token: 0x04004980 RID: 18816
        public readonly AppMain.GMS_ENEMY_3D_WORK gmk_work;

        // Token: 0x04004981 RID: 18817
        public bool last_under;

        // Token: 0x04004982 RID: 18818
        public ushort vect;

        // Token: 0x04004983 RID: 18819
        public short width;

        // Token: 0x04004984 RID: 18820
        public int diradd;

        // Token: 0x04004985 RID: 18821
        public int rolldir;

        // Token: 0x04004986 RID: 18822
        public int speed;

        // Token: 0x04004987 RID: 18823
        public int roller;

        // Token: 0x04004988 RID: 18824
        public float tex_u;
    }

    // Token: 0x06000281 RID: 641 RVA: 0x00014950 File Offset: 0x00012B50
    private static AppMain.OBS_OBJECT_WORK GmGmkBeltConveyorInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.GMS_GMK_BELTC_WORK gms_GMK_BELTC_WORK = (AppMain.GMS_GMK_BELTC_WORK)AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BELTC_WORK(), "Gmk_BeltConveyor");
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_GMK_BELTC_WORK;
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)gms_GMK_BELTC_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.gm_gmk_beltconv_obj_3d_list[0], gms_ENEMY_3D_WORK.obj_3d );
        obs_OBJECT_WORK.pos.z = -69632;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBeltConveyor_ppOut );
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.flag |= 2U;
        gms_GMK_BELTC_WORK.width = ( short )( eve_rec.width * 2 );
        if ( eve_rec.left < 0 )
        {
            gms_GMK_BELTC_WORK.vect = 32768;
            gms_GMK_BELTC_WORK.roller = ( int )( -gms_GMK_BELTC_WORK.width * 4096 );
        }
        else
        {
            gms_GMK_BELTC_WORK.vect = 0;
            gms_GMK_BELTC_WORK.roller = ( int )( gms_GMK_BELTC_WORK.width * 4096 );
        }
        gms_GMK_BELTC_WORK.speed = 8192;
        int num;
        if ( ( eve_rec.flag & 15 ) < 15 )
        {
            num = ( int )( eve_rec.flag & 15 ) << 11;
        }
        else
        {
            num = -2048;
        }
        gms_GMK_BELTC_WORK.speed += num;
        gms_GMK_BELTC_WORK.rolldir = 0;
        if ( gms_GMK_BELTC_WORK.vect == 32768 )
        {
            gms_GMK_BELTC_WORK.speed = -gms_GMK_BELTC_WORK.speed;
        }
        gms_GMK_BELTC_WORK.diradd = 65536 * gms_GMK_BELTC_WORK.speed / 6 / 16;
        AppMain.gmGmkBeltConveyorStart( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000282 RID: 642 RVA: 0x00014AD0 File Offset: 0x00012CD0
    public static void GmGmkBeltConveyorBuild()
    {
        AppMain.gm_gmk_beltconv_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( AppMain.GmGameDatGetGimmickData( 844 ), AppMain.GmGameDatGetGimmickData( 845 ), 0U );
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(846);
        AppMain.gm_gmk_beltconv_obj_tvx_list = ams_AMB_HEADER;
    }

    // Token: 0x06000283 RID: 643 RVA: 0x00014B10 File Offset: 0x00012D10
    public static void GmGmkBeltConveyorFlush()
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.GmGameDatGetGimmickData(844);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_gmk_beltconv_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_gmk_beltconv_obj_3d_list = null;
        AppMain.gm_gmk_beltconv_obj_tvx_list = null;
    }

    // Token: 0x06000284 RID: 644 RVA: 0x00014B44 File Offset: 0x00012D44
    private static void gmGmkBeltConveyor_ppOut( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BELTC_WORK gms_GMK_BELTC_WORK = (AppMain.GMS_GMK_BELTC_WORK)obj_work;
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        if ( AppMain._tvx_roller == null )
        {
            AppMain._tvx_roller = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_beltconv_obj_tvx_list, 0 ) );
            AppMain._tvx_axis = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_beltconv_obj_tvx_list, 1 ) );
            AppMain._tvx_belt_up = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_beltconv_obj_tvx_list, 2 ) );
            AppMain._tvx_belt_down = new AppMain.TVX_FILE( ( AppMain.AmbChunk )AppMain.amBindGet( AppMain.gm_gmk_beltconv_obj_tvx_list, 3 ) );
        }
        AppMain.TVX_FILE tvx_roller = AppMain._tvx_roller;
        AppMain.TVX_FILE tvx_axis = AppMain._tvx_axis;
        AppMain.TVX_FILE tvx_belt_up = AppMain._tvx_belt_up;
        AppMain.TVX_FILE tvx_belt_down = AppMain._tvx_belt_down;
        AppMain.NNS_TEXLIST texlist = obj_work.obj_3d.texlist;
        short rotate_z = (short)(-(short)obj_work.dir.z);
        AppMain.VecFx32 pos = obj_work.pos;
        AppMain.GmTvxSetModel( tvx_roller, texlist, ref pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_ROTATE, rotate_z );
        pos.z += 4096;
        AppMain.GmTvxSetModel( tvx_axis, texlist, ref pos, ref obj_work.scale, 0U, 0 );
        pos.x += gms_GMK_BELTC_WORK.roller;
        AppMain.GmTvxSetModel( tvx_axis, texlist, ref pos, ref obj_work.scale, 0U, 0 );
        pos.z -= 4096;
        AppMain.GmTvxSetModel( tvx_roller, texlist, ref pos, ref obj_work.scale, AppMain.GMD_TVX_DISP_ROTATE, rotate_z );
        pos.x -= gms_GMK_BELTC_WORK.roller;
        int num = (gms_GMK_BELTC_WORK.vect == 0) ? 262144 : -262144;
        int num2 = gms_GMK_BELTC_WORK.roller;
        AppMain.GMS_TVX_EX_WORK gms_TVX_EX_WORK = default(AppMain.GMS_TVX_EX_WORK);
        gms_TVX_EX_WORK.u_wrap = 1;
        gms_TVX_EX_WORK.v_wrap = 1;
        gms_TVX_EX_WORK.coord.v = 0f;
        gms_TVX_EX_WORK.color = 0U;
        pos.y += -65536;
        pos.z = -73728;
        if ( gms_GMK_BELTC_WORK.vect == 32768 )
        {
            pos.x += num;
        }
        while ( num2 != 0 )
        {
            gms_TVX_EX_WORK.coord.u = gms_GMK_BELTC_WORK.tex_u;
            AppMain.GmTvxSetModelEx( tvx_belt_up, texlist, ref pos, ref obj_work.scale, 0U, 0, ref gms_TVX_EX_WORK );
            pos.y -= -131072;
            gms_TVX_EX_WORK.coord.u = -gms_GMK_BELTC_WORK.tex_u;
            AppMain.GmTvxSetModelEx( tvx_belt_down, texlist, ref pos, ref obj_work.scale, 0U, 0, ref gms_TVX_EX_WORK );
            pos.y += -131072;
            pos.x += num;
            num2 -= num;
        }
    }

    // Token: 0x06000285 RID: 645 RVA: 0x00014DE0 File Offset: 0x00012FE0
    private static void gmGmkBeltConveyorStay( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BELTC_WORK gms_GMK_BELTC_WORK = (AppMain.GMS_GMK_BELTC_WORK)obj_work;
        AppMain.OBS_OBJECT_WORK obj_work2 = AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)].obj_work;
        bool flag = false;
        if ( obj_work2.ride_obj == obj_work )
        {
            obj_work2.flow.x = gms_GMK_BELTC_WORK.speed;
            flag = true;
        }
        if ( gms_GMK_BELTC_WORK.last_under && !flag && AppMain.g_gm_main_system.ply_work[( int )( ( UIntPtr )0 )].seq_state == 1 && ( obj_work2.move_flag & 1U ) == 0U && ( ( gms_GMK_BELTC_WORK.speed > 0 && obj_work2.spd_m < 0 && obj_work2.pos.x > obj_work.pos.x ) || ( gms_GMK_BELTC_WORK.speed < 0 && obj_work2.spd_m > 0 && obj_work2.pos.x < obj_work.pos.x ) ) )
        {
            obj_work2.spd_m = gms_GMK_BELTC_WORK.speed;
        }
        gms_GMK_BELTC_WORK.last_under = flag;
        gms_GMK_BELTC_WORK.rolldir += gms_GMK_BELTC_WORK.diradd;
        obj_work.dir.z = ( ushort )( gms_GMK_BELTC_WORK.rolldir >> 12 );
        gms_GMK_BELTC_WORK.tex_u -= ( float )( gms_GMK_BELTC_WORK.speed >> 12 ) / 128f;
        while ( gms_GMK_BELTC_WORK.tex_u >= 0.125f )
        {
            gms_GMK_BELTC_WORK.tex_u -= 0.125f;
        }
        while ( gms_GMK_BELTC_WORK.tex_u <= -0.125f )
        {
            gms_GMK_BELTC_WORK.tex_u += 0.125f;
        }
    }

    // Token: 0x06000286 RID: 646 RVA: 0x00014F40 File Offset: 0x00013140
    private static void gmGmkBeltConveyorStart( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_GMK_BELTC_WORK gms_GMK_BELTC_WORK = (AppMain.GMS_GMK_BELTC_WORK)obj_work;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.obj = obj_work;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.diff_data = AppMain.g_gm_default_col;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 134217728U;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.width = ( ushort )gms_GMK_BELTC_WORK.width;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.ofst_x = ( short )( ( gms_GMK_BELTC_WORK.vect == 0 ) ? 0 : ( -gms_GMK_BELTC_WORK.width ) );
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.height = 8;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.ofst_y = -16;
        if ( ( ( ( AppMain.GMS_ENEMY_COM_WORK )obj_work ).eve_rec.flag & 16 ) != 0 )
        {
            AppMain.OBS_COLLISION_OBJ obj_col = gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col;
            obj_col.width += 16;
            AppMain.OBS_COLLISION_OBJ obj_col2 = gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col;
            obj_col2.ofst_x -= 16;
        }
        if ( ( ( ( AppMain.GMS_ENEMY_COM_WORK )obj_work ).eve_rec.flag & 32 ) != 0 )
        {
            AppMain.OBS_COLLISION_OBJ obj_col3 = gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col;
            obj_col3.width += 16;
        }
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.dir = 0;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.flag |= 32U;
        gms_GMK_BELTC_WORK.gmk_work.ene_com.col_work.obj_col.attr = 1;
        gms_GMK_BELTC_WORK.last_under = false;
        gms_GMK_BELTC_WORK.tex_u = 0f;
        obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBeltConveyorStay );
    }
}