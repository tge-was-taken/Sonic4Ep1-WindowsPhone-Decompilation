using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000075 RID: 117
    public class GMS_FADE_OBJ_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001E2B RID: 7723 RVA: 0x001396C8 File Offset: 0x001378C8
        public GMS_FADE_OBJ_WORK( object _obj ) : this()
        {
            this.m_pHolder = _obj;
        }

        // Token: 0x06001E2C RID: 7724 RVA: 0x001396D7 File Offset: 0x001378D7
        public GMS_FADE_OBJ_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this );
        }

        // Token: 0x06001E2D RID: 7725 RVA: 0x001396F6 File Offset: 0x001378F6
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x06001E2E RID: 7726 RVA: 0x001396FE File Offset: 0x001378FE
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_FADE_OBJ_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x06001E2F RID: 7727 RVA: 0x00139706 File Offset: 0x00137906
        public static explicit operator AppMain.GMS_BOSS5_ALARM_FADE_WORK( AppMain.GMS_FADE_OBJ_WORK p )
        {
            return ( AppMain.GMS_BOSS5_ALARM_FADE_WORK )p.m_pHolder;
        }

        // Token: 0x04004989 RID: 18825
        public object m_pHolder;

        // Token: 0x0400498A RID: 18826
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x0400498B RID: 18827
        public readonly AppMain.IZS_FADE_WORK fade_work = new AppMain.IZS_FADE_WORK();
    }

    // Token: 0x06000287 RID: 647 RVA: 0x0001514C File Offset: 0x0001334C
    private static void GmFadeSetFade( AppMain.GMS_FADE_OBJ_WORK fade_obj, uint fade_set_type, byte start_col_r, byte start_col_g, byte start_col_b, byte start_col_a, byte end_col_r, byte end_col_g, byte end_col_b, byte end_col_a, float time, int draw_start, int conti_state )
    {
        AppMain.IZS_FADE_WORK fade_work = fade_obj.fade_work;
        AppMain.IzFadeSetWork( fade_work, fade_work.dt_prio, fade_work.draw_state, fade_set_type, start_col_r, start_col_g, start_col_b, start_col_a, end_col_r, end_col_g, end_col_b, end_col_a, time, draw_start != 0, conti_state != 0 );
    }

    // Token: 0x06000288 RID: 648 RVA: 0x00015193 File Offset: 0x00013393
    private static int GmFadeIsEnd( AppMain.GMS_FADE_OBJ_WORK fade_obj )
    {
        if ( fade_obj.fade_work.count >= fade_obj.fade_work.time )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000289 RID: 649 RVA: 0x000151B0 File Offset: 0x000133B0
    private static AppMain.GMS_FADE_OBJ_WORK GmFadeCreateFadeObj( ushort prio, byte group, byte pause_level, AppMain.TaskWorkFactoryDelegate work_size, ushort dt_prio, uint draw_state )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(prio, group, pause_level, 0, work_size, "FADE_OBJ");
        AppMain.GMS_FADE_OBJ_WORK gms_FADE_OBJ_WORK = (AppMain.GMS_FADE_OBJ_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.obj_type = 7;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        gms_FADE_OBJ_WORK.fade_work.dt_prio = dt_prio;
        gms_FADE_OBJ_WORK.fade_work.draw_state = draw_state;
        gms_FADE_OBJ_WORK.fade_work.time = 1f;
        gms_FADE_OBJ_WORK.obj_work.ppOut = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmFadeDispFunc );
        return gms_FADE_OBJ_WORK;
    }

    // Token: 0x0600028A RID: 650 RVA: 0x00015240 File Offset: 0x00013440
    private static void gmFadeDispFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_FADE_OBJ_WORK gms_FADE_OBJ_WORK = (AppMain.GMS_FADE_OBJ_WORK)obj_work;
        if ( ( obj_work.disp_flag & 4112U ) == 0U )
        {
            AppMain.IzFadeUpdate( gms_FADE_OBJ_WORK.fade_work );
        }
        if ( ( obj_work.disp_flag & 32U ) == 0U )
        {
            AppMain.IzFadeDraw( gms_FADE_OBJ_WORK.fade_work );
        }
    }
}
