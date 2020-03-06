using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002A5 RID: 677
    public class GMS_COCKPIT_COM_WORK
    {
        // Token: 0x0600245E RID: 9310 RVA: 0x0014A911 File Offset: 0x00148B11
        public GMS_COCKPIT_COM_WORK( object holder )
        {
            this.holder = holder;
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x0600245F RID: 9311 RVA: 0x0014A92C File Offset: 0x00148B2C
        public GMS_COCKPIT_COM_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x04005ADC RID: 23260
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04005ADD RID: 23261
        public readonly object holder;
    }

    // Token: 0x020002A6 RID: 678
    public class GMS_COCKPIT_2D_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002460 RID: 9312 RVA: 0x0014A940 File Offset: 0x00148B40
        public GMS_COCKPIT_2D_WORK()
        {
            this.cpit_com = new AppMain.GMS_COCKPIT_COM_WORK( this );
        }

        // Token: 0x06002461 RID: 9313 RVA: 0x0014A95F File Offset: 0x00148B5F
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.cpit_com.obj_work;
        }

        // Token: 0x06002462 RID: 9314 RVA: 0x0014A96C File Offset: 0x00148B6C
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_COCKPIT_2D_WORK work )
        {
            return work.cpit_com.obj_work;
        }

        // Token: 0x06002463 RID: 9315 RVA: 0x0014A979 File Offset: 0x00148B79
        public static explicit operator AppMain.GMS_COCKPIT_2D_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_COCKPIT_2D_WORK )( ( AppMain.GMS_COCKPIT_COM_WORK )work.holder ).holder;
        }

        // Token: 0x04005ADE RID: 23262
        public readonly AppMain.GMS_COCKPIT_COM_WORK cpit_com;

        // Token: 0x04005ADF RID: 23263
        public readonly AppMain.OBS_ACTION2D_AMA_WORK obj_2d = new AppMain.OBS_ACTION2D_AMA_WORK();
    }

    // Token: 0x020002A7 RID: 679
    public class GMS_COCKPIT_3DNN_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06002464 RID: 9316 RVA: 0x0014A990 File Offset: 0x00148B90
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.cpit_com.obj_work;
        }

        // Token: 0x04005AE0 RID: 23264
        public readonly AppMain.GMS_COCKPIT_COM_WORK cpit_com = new AppMain.GMS_COCKPIT_COM_WORK();

        // Token: 0x04005AE1 RID: 23265
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();
    }

    // Token: 0x06001263 RID: 4707 RVA: 0x000A0DCE File Offset: 0x0009EFCE
    private static AppMain.OBS_OBJECT_WORK GMM_COCKPIT_CREATE_WORK( AppMain.TaskWorkFactoryDelegate work_size, AppMain.OBS_OBJECT_WORK parent_obj, ushort sort_prio, string name )
    {
        return AppMain.GmCockpitCreateWork( work_size, parent_obj, sort_prio, name );
    }

    // Token: 0x06001264 RID: 4708 RVA: 0x000A0DDC File Offset: 0x0009EFDC
    private static AppMain.OBS_OBJECT_WORK GmCockpitCreateWork( AppMain.TaskWorkFactoryDelegate work_size, AppMain.OBS_OBJECT_WORK parent_obj, ushort sort_prio, string name )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT((ushort)(18432 + sort_prio), 5, 0, 0, work_size, name);
        if ( obs_OBJECT_WORK == null )
        {
            AppMain.mppAssertNotImpl();
            return null;
        }
        obs_OBJECT_WORK.obj_type = 6;
        obs_OBJECT_WORK.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.ObjDrawActionSummary );
        obs_OBJECT_WORK.ppOutSub = null;
        obs_OBJECT_WORK.ppIn = null;
        obs_OBJECT_WORK.ppMove = null;
        obs_OBJECT_WORK.ppActCall = null;
        obs_OBJECT_WORK.ppRec = null;
        obs_OBJECT_WORK.ppLast = null;
        obs_OBJECT_WORK.ppViewCheck = null;
        obs_OBJECT_WORK.spd_fall = 672;
        obs_OBJECT_WORK.spd_fall_max = 61440;
        if ( parent_obj != null )
        {
            obs_OBJECT_WORK.parent_obj = parent_obj;
            obs_OBJECT_WORK.pos.x = parent_obj.pos.x;
            obs_OBJECT_WORK.pos.y = parent_obj.pos.y;
            obs_OBJECT_WORK.pos.z = parent_obj.pos.z;
        }
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.move_flag |= 256U;
        return obs_OBJECT_WORK;
    }

}