using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200002F RID: 47
    private struct GMS_PAD_VIB_WORK
    {
        // Token: 0x04004805 RID: 18437
        public int vib_type;

        // Token: 0x04004806 RID: 18438
        public float time;

        // Token: 0x04004807 RID: 18439
        public float add_dec_time;

        // Token: 0x04004808 RID: 18440
        public float int_vib_time;

        // Token: 0x04004809 RID: 18441
        public float int_stop_time;

        // Token: 0x0400480A RID: 18442
        public ushort left_vib;

        // Token: 0x0400480B RID: 18443
        public ushort right_vib;

        // Token: 0x0400480C RID: 18444
        public uint flag;

        // Token: 0x0400480D RID: 18445
        public float time_count;

        // Token: 0x0400480E RID: 18446
        public float int_count;

        // Token: 0x0400480F RID: 18447
        public uint prio;
    }

    // Token: 0x0600004D RID: 77 RVA: 0x00004891 File Offset: 0x00002A91
    public static void GMM_PAD_VIB_LARGE()
    {
        AppMain.GmPadVibSet( 1, 60f, 32768, 32768, 0f, 0f, 0f, 32768U );
    }

    // Token: 0x0600004E RID: 78 RVA: 0x000048BC File Offset: 0x00002ABC
    public static void GMM_PAD_VIB_MID()
    {
        AppMain.GmPadVibSet( 1, 30f, 16384, 16384, 0f, 0f, 0f, 16384U );
    }

    // Token: 0x0600004F RID: 79 RVA: 0x000048E7 File Offset: 0x00002AE7
    public static void GMM_PAD_VIB_SMALL()
    {
        AppMain.GmPadVibSet( 1, 30f, 8192, 8192, 0f, 0f, 0f, 8192U );
    }

    // Token: 0x06000050 RID: 80 RVA: 0x00004912 File Offset: 0x00002B12
    public static void GMM_PAD_VIB_LARGE_TIME( float time )
    {
        AppMain.GmPadVibSet( 1, time, 32768, 32768, 0f, 0f, 0f, 32768U );
    }

    // Token: 0x06000051 RID: 81 RVA: 0x00004939 File Offset: 0x00002B39
    public static void GMM_PAD_VIB_MID_TIME( float time )
    {
        AppMain.GmPadVibSet( 1, time, 16384, 16384, 0f, 0f, 0f, 16384U );
    }

    // Token: 0x06000052 RID: 82 RVA: 0x00004960 File Offset: 0x00002B60
    public static void GMM_PAD_VIB_SMALL_TIME( float time )
    {
        AppMain.GmPadVibSet( 1, time, 8192, 8192, 0f, 0f, 0f, 8192U );
    }

    // Token: 0x06000053 RID: 83 RVA: 0x00004987 File Offset: 0x00002B87
    public static void GMM_PAD_VIB_LARGE_NOEND()
    {
        AppMain.GmPadVibSet( 1, -1f, 32768, 32768, 0f, 0f, 0f, 32768U );
    }

    // Token: 0x06000054 RID: 84 RVA: 0x000049B2 File Offset: 0x00002BB2
    public static void GMM_PAD_VIB_MID_NOEND()
    {
        AppMain.GmPadVibSet( 1, -1f, 16384, 16384, 0f, 0f, 0f, 16384U );
    }

    // Token: 0x06000055 RID: 85 RVA: 0x000049DD File Offset: 0x00002BDD
    public static void GMM_PAD_VIB_SMALL_NOEND()
    {
        AppMain.GmPadVibSet( 1, -1f, 8192, 8192, 0f, 0f, 0f, 8192U );
    }

    // Token: 0x06000056 RID: 86 RVA: 0x00004A08 File Offset: 0x00002C08
    public static void GMM_PAD_VIB_STOP()
    {
        AppMain.GmPadVibSet( 0, 0f, 0, 0, 0f, 0f, 0f );
    }

    // Token: 0x06000057 RID: 87 RVA: 0x00004A26 File Offset: 0x00002C26
    private static void GmPadVibInit()
    {
    }

    // Token: 0x06000058 RID: 88 RVA: 0x00004A28 File Offset: 0x00002C28
    private static void GmPadVibExit()
    {
    }

    // Token: 0x06000059 RID: 89 RVA: 0x00004A2A File Offset: 0x00002C2A
    private static void GmPadVibSet( int vib_type, float time, ushort left_vib, ushort right_vib, float add_dec_time, float int_vib_time, float int_stop_time )
    {
        AppMain.GmPadVibSet( vib_type, time, left_vib, right_vib, add_dec_time, int_vib_time, int_stop_time, 0U );
    }

    // Token: 0x0600005A RID: 90 RVA: 0x00004A3C File Offset: 0x00002C3C
    private static void GmPadVibSet( int vib_type, float time, ushort left_vib, ushort right_vib, float add_dec_time, float int_vib_time, float int_stop_time, uint prio )
    {
    }

    // Token: 0x0600005B RID: 91 RVA: 0x00004A40 File Offset: 0x00002C40
    private void gmPadVibDMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_PAD_VIB_WORK gms_PAD_VIB_WORK = (AppMain.GMS_PAD_VIB_WORK)tcb.work;
        if ( AppMain.ObjObjectPauseCheck( 0U ) != 0U )
        {
            if ( ( gms_PAD_VIB_WORK.flag & 2U ) == 0U )
            {
                gms_PAD_VIB_WORK.flag |= 2U;
            }
            return;
        }
        gms_PAD_VIB_WORK.flag &= 4294967293U;
        if ( gms_PAD_VIB_WORK.time > 0f )
        {
            gms_PAD_VIB_WORK.time_count = AppMain.ObjTimeCountUpF( gms_PAD_VIB_WORK.time_count );
            if ( gms_PAD_VIB_WORK.time_count >= gms_PAD_VIB_WORK.time )
            {
                gms_PAD_VIB_WORK.vib_type = 0;
                gms_PAD_VIB_WORK.prio = 0U;
                gms_PAD_VIB_WORK.time = -1f;
            }
        }
        switch ( gms_PAD_VIB_WORK.vib_type )
        {
            case 0:
            case 1:
                break;
            case 2:
                if ( gms_PAD_VIB_WORK.time - gms_PAD_VIB_WORK.time_count < gms_PAD_VIB_WORK.add_dec_time )
                {
                    float num = (gms_PAD_VIB_WORK.time - gms_PAD_VIB_WORK.time_count) / gms_PAD_VIB_WORK.add_dec_time;
                    AppMain.nnRoundOff( ( float )gms_PAD_VIB_WORK.left_vib * num + 0.5f );
                    AppMain.nnRoundOff( ( float )gms_PAD_VIB_WORK.right_vib * num + 0.5f );
                    return;
                }
                break;
            case 3:
                if ( gms_PAD_VIB_WORK.time_count < gms_PAD_VIB_WORK.add_dec_time )
                {
                    float num = gms_PAD_VIB_WORK.time_count / gms_PAD_VIB_WORK.add_dec_time;
                    AppMain.nnRoundOff( ( float )gms_PAD_VIB_WORK.left_vib * num + 0.5f );
                    AppMain.nnRoundOff( ( float )gms_PAD_VIB_WORK.right_vib * num + 0.5f );
                    return;
                }
                break;
            case 4:
                gms_PAD_VIB_WORK.int_count = AppMain.ObjTimeCountUpF( gms_PAD_VIB_WORK.int_count );
                if ( ( gms_PAD_VIB_WORK.flag & 1U ) != 0U )
                {
                    if ( gms_PAD_VIB_WORK.int_count >= gms_PAD_VIB_WORK.int_stop_time )
                    {
                        gms_PAD_VIB_WORK.int_count = 0f;
                        gms_PAD_VIB_WORK.flag &= 4294967294U;
                        return;
                    }
                }
                else if ( gms_PAD_VIB_WORK.int_count >= gms_PAD_VIB_WORK.int_stop_time )
                {
                    gms_PAD_VIB_WORK.int_count = 0f;
                    gms_PAD_VIB_WORK.flag |= 1U;
                }
                break;
            default:
                return;
        }
    }

    // Token: 0x0600005C RID: 92 RVA: 0x00004C22 File Offset: 0x00002E22
    private void gmPadVibDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.AoPadSetVibration( 0, 0 );
        AppMain.gm_pad_vib_tcb = null;
    }
}