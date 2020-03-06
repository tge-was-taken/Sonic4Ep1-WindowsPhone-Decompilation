using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x060005CC RID: 1484 RVA: 0x00033F24 File Offset: 0x00032124
    private static void GmComEfctCreateRing( int pos_x, int pos_y )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(null, 50);
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.x = pos_x;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.y = pos_y;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.z = 655360;
    }

    // Token: 0x060005CD RID: 1485 RVA: 0x00033F80 File Offset: 0x00032180
    private static void GmComEfctCreateEneDeadSmoke( AppMain.OBS_OBJECT_WORK obj_work, int ofst_x, int ofst_y )
    {
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(null, 10);
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 2 )
        {
            if ( AppMain.GmMainIsWaterLevel() && obj_work.pos.y + ofst_y - 196608 >> 12 > ( int )AppMain.g_gm_main_system.water_level )
            {
                gms_EFFECT_3DES_WORK = AppMain.GmEfctZoneEsCreate( obj_work, 2, 0 );
            }
            else
            {
                gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( null, 10 );
            }
        }
        else
        {
            gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate( null, 10 );
        }
        gms_EFFECT_3DES_WORK.efct_com.obj_work.parent_obj = null;
        gms_EFFECT_3DES_WORK.efct_com.obj_work.pos.Assign( obj_work.pos );
        AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, ofst_x, ofst_y, 655360 );
    }

    // Token: 0x060005CE RID: 1486 RVA: 0x0003401F File Offset: 0x0003221F
    private static void GmComEfctCreateHitPlayer( AppMain.OBS_OBJECT_WORK obj_work, int ofst_x, int ofst_y )
    {
    }

    // Token: 0x060005CF RID: 1487 RVA: 0x00034024 File Offset: 0x00032224
    private static void GmComEfctCreateHitEnemy( AppMain.OBS_OBJECT_WORK obj_work, int ofst_x, int ofst_y )
    {
        AppMain.GMS_EFFECT_3DES_WORK efct_work = AppMain.GmEfctCmnEsCreate(obj_work, 37);
        AppMain.GmComEfctSetDispOffset( efct_work, ofst_x, ofst_y, 655360 );
    }

    // Token: 0x060005D0 RID: 1488 RVA: 0x00034047 File Offset: 0x00032247
    private static void GmComEfctCreateSpring( AppMain.OBS_OBJECT_WORK obj_work, int ofst_x, int ofst_y )
    {
        AppMain.GmComEfctCreateSpring( obj_work, ofst_x, ofst_y, 0 );
    }

    // Token: 0x060005D1 RID: 1489 RVA: 0x00034054 File Offset: 0x00032254
    private static void GmComEfctCreateSpring( AppMain.OBS_OBJECT_WORK obj_work, int ofst_x, int ofst_y, int ofst_z )
    {
        if ( AppMain.g_gs_main_sys_info.stage_id != 9 )
        {
            return;
        }
        AppMain.GMS_EFFECT_3DES_WORK gms_EFFECT_3DES_WORK = AppMain.GmEfctCmnEsCreate(obj_work, 77);
        AppMain.GmComEfctSetDispOffset( gms_EFFECT_3DES_WORK, ofst_x, ofst_y, 65536 + ofst_z );
        gms_EFFECT_3DES_WORK.obj_3des.ecb.drawObjState = 0U;
    }

    // Token: 0x060005D2 RID: 1490 RVA: 0x0003409C File Offset: 0x0003229C
    private static void GmComEfctSetDispOffset( AppMain.GMS_EFFECT_3DES_WORK efct_work, int ofst_x, int ofst_y, int ofst_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESSetDispOffset( efct_work, AppMain.FXM_FX32_TO_FLOAT( ofst_x ), AppMain.FXM_FX32_TO_FLOAT( -ofst_y ), AppMain.FXM_FX32_TO_FLOAT( ofst_z ) );
            return;
        }
        AppMain.GmEffect3DESSetDispOffset( efct_work, AppMain.FXM_FX32_TO_FLOAT( -ofst_z ), AppMain.FXM_FX32_TO_FLOAT( -ofst_y ), AppMain.FXM_FX32_TO_FLOAT( ofst_x ) );
    }

    // Token: 0x060005D3 RID: 1491 RVA: 0x000340F5 File Offset: 0x000322F5
    private static void GmComEfctSetDispOffsetF( AppMain.GMS_EFFECT_3DES_WORK efct_work, float ofst_x, float ofst_y, float ofst_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESSetDispOffset( efct_work, ofst_x, -ofst_y, ofst_z );
            return;
        }
        AppMain.GmEffect3DESSetDispOffset( efct_work, -ofst_z, -ofst_y, ofst_x );
    }

    // Token: 0x060005D4 RID: 1492 RVA: 0x00034128 File Offset: 0x00032328
    private static void GmComEfctAddDispOffset( AppMain.GMS_EFFECT_3DES_WORK efct_work, int ofst_x, int ofst_y, int ofst_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESAddDispOffset( efct_work, AppMain.FXM_FX32_TO_FLOAT( ofst_x ), AppMain.FXM_FX32_TO_FLOAT( -ofst_y ), AppMain.FXM_FX32_TO_FLOAT( ofst_z ) );
            return;
        }
        AppMain.GmEffect3DESAddDispOffset( efct_work, AppMain.FXM_FX32_TO_FLOAT( -ofst_z ), AppMain.FXM_FX32_TO_FLOAT( -ofst_y ), AppMain.FXM_FX32_TO_FLOAT( ofst_x ) );
    }

    // Token: 0x060005D5 RID: 1493 RVA: 0x00034181 File Offset: 0x00032381
    private static void GmComEfctAddDispOffsetF( AppMain.GMS_EFFECT_3DES_WORK efct_work, float ofst_x, float ofst_y, float ofst_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESAddDispOffset( efct_work, ofst_x, -ofst_y, ofst_z );
            return;
        }
        AppMain.GmEffect3DESAddDispOffset( efct_work, -ofst_z, -ofst_y, ofst_x );
    }

    // Token: 0x060005D6 RID: 1494 RVA: 0x000341B1 File Offset: 0x000323B1
    private static void GmComEfctSetDispRotation( AppMain.GMS_EFFECT_3DES_WORK efct_work, ushort dir_x, ushort dir_y, ushort dir_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESSetDispRotation( efct_work, ( short )dir_x, ( short )dir_y, ( short )dir_z );
            return;
        }
        AppMain.GmEffect3DESSetDispRotation( efct_work, ( short )( -( short )dir_z ), ( short )( -( short )dir_y ), ( short )dir_x );
    }

    // Token: 0x060005D7 RID: 1495 RVA: 0x000341E6 File Offset: 0x000323E6
    private static void GmComEfctSetDispRotationS( AppMain.GMS_EFFECT_3DES_WORK efct_work, short dir_x, short dir_y, short dir_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESSetDispRotation( efct_work, dir_x, dir_y, dir_z );
            return;
        }
        AppMain.GmEffect3DESSetDispRotation( efct_work, ( short )( -dir_z ), ( short )( -dir_y ), dir_x );
    }

    // Token: 0x060005D8 RID: 1496 RVA: 0x00034217 File Offset: 0x00032417
    private static void GmComEfctAddDispRotation( AppMain.GMS_EFFECT_3DES_WORK efct_work, ushort dir_x, ushort dir_y, ushort dir_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESAddDispRotation( efct_work, ( short )dir_x, ( short )dir_y, ( short )dir_z );
            return;
        }
        AppMain.GmEffect3DESAddDispRotation( efct_work, ( short )( -( short )dir_z ), ( short )( -( short )dir_y ), ( short )dir_x );
    }

    // Token: 0x060005D9 RID: 1497 RVA: 0x0003424C File Offset: 0x0003244C
    private static void GmComEfctAddDispRotationS( AppMain.GMS_EFFECT_3DES_WORK efct_work, short dir_x, short dir_y, short dir_z )
    {
        if ( ( efct_work.efct_com.obj_work.disp_flag & 4194304U ) != 0U )
        {
            AppMain.GmEffect3DESAddDispRotation( efct_work, dir_x, dir_y, dir_z );
            return;
        }
        AppMain.GmEffect3DESAddDispRotation( efct_work, ( short )-dir_z, ( short )-dir_y, dir_x );
    }
}