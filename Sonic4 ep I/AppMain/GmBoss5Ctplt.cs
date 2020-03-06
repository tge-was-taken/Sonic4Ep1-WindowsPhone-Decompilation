using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200019E RID: 414
    public class GMS_BOSS5_CTPLT_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021F1 RID: 8689 RVA: 0x00141FEA File Offset: 0x001401EA
        public GMS_BOSS5_CTPLT_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060021F2 RID: 8690 RVA: 0x00141FFE File Offset: 0x001401FE
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.GMS_BOSS5_CTPLT_WORK p )
        {
            return p.ene_3d.ene_com;
        }

        // Token: 0x060021F3 RID: 8691 RVA: 0x0014200B File Offset: 0x0014020B
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04004F40 RID: 20288
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04004F41 RID: 20289
        public AppMain.MPP_VOID_GMS_BOSS5_CTPLT_WORK proc_update;
    }

    // Token: 0x06000798 RID: 1944 RVA: 0x000434F8 File Offset: 0x000416F8
    public static AppMain.OBS_OBJECT_WORK GmBoss5CtpltInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS5_CTPLT_WORK(), "BOSS5_CTPLT");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS5_CTPLT_WORK ctplt_work = (AppMain.GMS_BOSS5_CTPLT_WORK)obs_OBJECT_WORK;
        AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss5GetObject3dList()[4], gms_ENEMY_3D_WORK.obj_3d );
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obs_OBJECT_WORK, 0, AppMain.ObjDataGet( 748 ), null, 3, null );
        obs_OBJECT_WORK.flag &= 4294966271U;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss5CtpltMain );
        AppMain.gmBoss5CtpltProcInit( ctplt_work );
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000799 RID: 1945 RVA: 0x000435E0 File Offset: 0x000417E0
    public static void GmBoss5CtpltCreate( AppMain.GMS_BOSS5_BODY_WORK body_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(body_work);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(345, obs_OBJECT_WORK.pos.x, obs_OBJECT_WORK.pos.y, 0, 0, 0, 0, 0, 0);
        obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK.pos.x;
        obs_OBJECT_WORK2.pos.y = body_work.ground_v_pos;
        obs_OBJECT_WORK2.pos.z = AppMain.GMD_BOSS5_CTPLT_BG_FARSIDE_POS_Z;
    }

    // Token: 0x0600079A RID: 1946 RVA: 0x0004365C File Offset: 0x0004185C
    public static void gmBoss5CtpltSetObjCollisionRect( AppMain.GMS_BOSS5_CTPLT_WORK ctplt_work )
    {
        AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)ctplt_work;
        gms_ENEMY_COM_WORK.col_work.obj_col.obj = AppMain.GMM_BS_OBJ( ctplt_work );
        gms_ENEMY_COM_WORK.col_work.obj_col.width = AppMain.GMD_BOSS5_CTPLT_OBJ_COL_RECT_WIDTH_INT;
        gms_ENEMY_COM_WORK.col_work.obj_col.height = AppMain.GMD_BOSS5_CTPLT_OBJ_COL_RECT_HEIGHT_INT;
        gms_ENEMY_COM_WORK.col_work.obj_col.ofst_x = AppMain.GMD_BOSS5_CTPLT_OBJ_COL_RECT_OFST_X_INT;
        gms_ENEMY_COM_WORK.col_work.obj_col.ofst_y = AppMain.GMD_BOSS5_CTPLT_OBJ_COL_RECT_OFST_Y_INT;
    }

    // Token: 0x0600079B RID: 1947 RVA: 0x000436DC File Offset: 0x000418DC
    public static void gmBoss5CtpltMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS5_CTPLT_WORK gms_BOSS5_CTPLT_WORK = (AppMain.GMS_BOSS5_CTPLT_WORK)obj_work;
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obj_work.parent_obj;
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = gms_BOSS5_BODY_WORK.mgr_work;
        if ( ( mgr_work.flag & 33554432U ) != 0U )
        {
            AppMain.gmBoss5CtpltSetObjCollisionRect( gms_BOSS5_CTPLT_WORK );
        }
        if ( gms_BOSS5_CTPLT_WORK.proc_update != null )
        {
            gms_BOSS5_CTPLT_WORK.proc_update( gms_BOSS5_CTPLT_WORK );
        }
    }

    // Token: 0x0600079C RID: 1948 RVA: 0x0004372C File Offset: 0x0004192C
    public static void gmBoss5CtpltProcInit( AppMain.GMS_BOSS5_CTPLT_WORK ctplt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ctplt_work);
        AppMain.ObjDrawObjectActionSet3DNNMaterial( obs_OBJECT_WORK, 0 );
        obs_OBJECT_WORK.disp_flag |= 4U;
        ctplt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_CTPLT_WORK( AppMain.gmBoss5CtpltProcIdle );
    }

    // Token: 0x0600079D RID: 1949 RVA: 0x00043768 File Offset: 0x00041968
    public static void gmBoss5CtpltProcIdle( AppMain.GMS_BOSS5_CTPLT_WORK ctplt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ctplt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = gms_BOSS5_BODY_WORK.mgr_work;
        if ( ( mgr_work.flag & 8388608U ) != 0U )
        {
            obs_OBJECT_WORK.spd_add.y = AppMain.GMD_BOSS5_CTPLT_MOVE_DOWN_ACC;
            ctplt_work.proc_update = new AppMain.MPP_VOID_GMS_BOSS5_CTPLT_WORK( AppMain.gmBoss5CtpltProcMoveDown );
        }
    }

    // Token: 0x0600079E RID: 1950 RVA: 0x000437C0 File Offset: 0x000419C0
    public static void gmBoss5CtpltProcMoveDown( AppMain.GMS_BOSS5_CTPLT_WORK ctplt_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BS_OBJ(ctplt_work);
        AppMain.GMS_BOSS5_BODY_WORK gms_BOSS5_BODY_WORK = (AppMain.GMS_BOSS5_BODY_WORK)obs_OBJECT_WORK.parent_obj;
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = gms_BOSS5_BODY_WORK.mgr_work;
        if ( obs_OBJECT_WORK.pos.y > gms_BOSS5_BODY_WORK.ground_v_pos + AppMain.GMD_BOSS5_CTPLT_MOVE_DOWN_HIDE_HEIGHT )
        {
            mgr_work.flag |= 16777216U;
            obs_OBJECT_WORK.flag |= 4U;
        }
    }
}