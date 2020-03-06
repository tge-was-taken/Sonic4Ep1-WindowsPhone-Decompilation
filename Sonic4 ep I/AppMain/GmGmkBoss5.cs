using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600027D RID: 637 RVA: 0x00014808 File Offset: 0x00012A08
    private static AppMain.OBS_OBJECT_WORK GmGmkBoss5TriggerInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_GMK_BOSS5_TRIGGER_WORK(), "BOSS5_TRIGGER");
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag &= 4294967263U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        obs_OBJECT_WORK.move_flag &= 4294967167U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmGmkBoss5TriggerMain );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600027E RID: 638 RVA: 0x00014898 File Offset: 0x00012A98
    private static void gmGmkBoss5TriggerMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)AppMain.g_gm_main_system.ply_work[(int)((UIntPtr)0)];
        if ( obs_OBJECT_WORK != null && obs_OBJECT_WORK.pos.x >= obj_work.pos.x && AppMain.gmGmkBoss5TriggerTryAnnounce() )
        {
            obj_work.flag |= 4U;
        }
    }

    // Token: 0x0600027F RID: 639 RVA: 0x000148E8 File Offset: 0x00012AE8
    private static bool gmGmkBoss5TriggerTryAnnounce()
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject(null, 2);
        while ( obs_OBJECT_WORK != null )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obs_OBJECT_WORK;
            if ( gms_ENEMY_COM_WORK.eve_rec != null && gms_ENEMY_COM_WORK.eve_rec.id == 55 )
            {
                break;
            }
        }
        if ( obs_OBJECT_WORK == null )
        {
            return false;
        }
        AppMain.GMS_BOSS5_MGR_WORK mgr_work = (AppMain.GMS_BOSS5_MGR_WORK)obs_OBJECT_WORK;
        AppMain.GmBoss5MgrAnnouncePassedTrigger( mgr_work );
        return true;
    }

    // Token: 0x06000280 RID: 640 RVA: 0x00014933 File Offset: 0x00012B33
    private static void GmBoss5MgrAnnouncePassedTrigger( AppMain.GMS_BOSS5_MGR_WORK mgr_work )
    {
        mgr_work.flag |= 4194304U;
    }
}
