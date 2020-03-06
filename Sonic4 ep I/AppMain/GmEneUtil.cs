using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06000E0E RID: 3598 RVA: 0x0007BE28 File Offset: 0x0007A028
    public static void gmEneExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_ENE_KANI_WORK gms_ENE_KANI_WORK = (AppMain.GMS_ENE_KANI_WORK)p;
        AppMain.GmEneUtilExitNodeMatrix( gms_ENE_KANI_WORK.node_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000E0F RID: 3599 RVA: 0x0007BE54 File Offset: 0x0007A054
    public static void GmEneUtilExitNodeMatrix( AppMain.GMS_ENE_NODE_MATRIX node_work )
    {
        if ( node_work._id[0] != 'S' || node_work._id[1] != 'N' || node_work._id[2] != 'M' || node_work._id[3] != ' ' || node_work._id[4] != 'S' || node_work._id[5] != 'Y' || node_work._id[6] != 'S' )
        {
            return;
        }
        AppMain.GmBsCmnClearBossMotionCBSystem( node_work.obj_work );
        AppMain.GmBsCmnDeleteSNMWork( node_work.snm_work );
        node_work._id[0] = '\0';
    }

    // Token: 0x06000E10 RID: 3600 RVA: 0x0007BED8 File Offset: 0x0007A0D8
    public static AppMain.NNS_MATRIX GmEneUtilGetNodeMatrix( AppMain.GMS_ENE_NODE_MATRIX node_work, int node_id )
    {
        if ( node_work.work[node_id] < 0 )
        {
            node_work.work[node_id] = AppMain.GmBsCmnRegisterSNMNode( node_work.snm_work, node_id );
        }
        return AppMain.GmBsCmnGetSNMMtx( node_work.snm_work, node_work.work[node_id] );
    }

    // Token: 0x06000E11 RID: 3601 RVA: 0x0007BF1C File Offset: 0x0007A11C
    public static void GmEneUtilInitNodeMatrix( AppMain.GMS_ENE_NODE_MATRIX node_work, AppMain.OBS_OBJECT_WORK obj_work, int max_node )
    {
        node_work.initCount = max_node;
        node_work.useCount = 0;
        AppMain.GmBsCmnInitBossMotionCBSystem( obj_work, node_work.mtn_mgr );
        AppMain.GmBsCmnCreateSNMWork( node_work.snm_work, obj_work.obj_3d._object, ( ushort )max_node );
        AppMain.GmBsCmnAppendBossMotionCallback( node_work.mtn_mgr, node_work.snm_work.bmcb_link );
        node_work.obj_work = obj_work;
        for ( int i = 0; i < 32; i++ )
        {
            node_work.work[i] = -1;
        }
        node_work._id[0] = 'S';
        node_work._id[1] = 'N';
        node_work._id[2] = 'M';
        node_work._id[3] = ' ';
        node_work._id[4] = 'S';
        node_work._id[5] = 'Y';
        node_work._id[6] = 'S';
    }

    // Token: 0x06000E12 RID: 3602 RVA: 0x0007BFD4 File Offset: 0x0007A1D4
    public static void GmEneUtilSetMatrixNN( AppMain.OBS_OBJECT_WORK obj_work, AppMain.NNS_MATRIX w_mtx )
    {
        AppMain.NNS_MATRIX user_obj_mtx_r = obj_work.obj_3d.user_obj_mtx_r;
        obj_work.pos.x = AppMain.FX_F32_TO_FX32( w_mtx.M03 );
        obj_work.pos.y = -AppMain.FX_F32_TO_FX32( w_mtx.M13 );
        obj_work.pos.z = AppMain.FX_F32_TO_FX32( w_mtx.M23 );
        obj_work.disp_flag |= 16777216U;
        AppMain.AkMathNormalizeMtx( user_obj_mtx_r, w_mtx );
    }
}