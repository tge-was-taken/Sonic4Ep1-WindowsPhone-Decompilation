using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600084F RID: 2127 RVA: 0x00048944 File Offset: 0x00046B44
    public static void GmScoreCreateScore( int score, int pos_x, int pos_y, int scale, int vib_level )
    {
        int[] array = new int[5];
        int[] array2 = new int[]
        {
            10000,
            1000,
            100,
            10,
            1
        };
        if ( score <= 0 )
        {
            return;
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBM_OBJECT_TASK_DETAIL_INIT(18432, 5, 0, 0, () => new AppMain.GMS_SCORE_DISP_WORK(), null);
        AppMain.GMS_SCORE_DISP_WORK gms_SCORE_DISP_WORK = (AppMain.GMS_SCORE_DISP_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = pos_y + -65536;
        obs_OBJECT_WORK.pos.z = 1179648;
        obs_OBJECT_WORK.flag |= 18U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmScoreMainFunc );
        gms_SCORE_DISP_WORK.vib_level = vib_level;
        gms_SCORE_DISP_WORK.base_pos.Assign( obs_OBJECT_WORK.pos );
        gms_SCORE_DISP_WORK.scale = scale;
        gms_SCORE_DISP_WORK.rise_dist = -131072 + -8 * ( scale - 4096 );
        gms_SCORE_DISP_WORK.rise_spd = gms_SCORE_DISP_WORK.rise_dist * 2 / 30;
        gms_SCORE_DISP_WORK.rise_dec = -gms_SCORE_DISP_WORK.rise_spd / 30;
        gms_SCORE_DISP_WORK.timer = 184320;
        if ( score > 99999 )
        {
            score = 99999;
        }
        int num = score;
        bool flag = false;
        int num2 = 0;
        int i;
        for ( i = 0; i < 5; i++ )
        {
            array[4 - i] = num / array2[i];
            num -= array[4 - i] * array2[i];
            if ( !flag )
            {
                if ( array[4 - i] == 0 )
                {
                    array[4 - i] = -1;
                }
                else
                {
                    flag = true;
                    num2++;
                }
            }
            else
            {
                num2++;
            }
        }
        int num3 = ((num2 * 11 + (num2 - 1)) * 4096 >> 1) - 22528;
        int num4 = -49152;
        i = 0;
        while ( i < 5 && array[i] != -1 )
        {
            gms_SCORE_DISP_WORK.efct_work[i] = AppMain.GmEfctCmnEsCreate( obs_OBJECT_WORK, 56 + array[i] );
            AppMain.OBS_OBJECT_WORK obj_work = gms_SCORE_DISP_WORK.efct_work[i].efct_com.obj_work;
            AppMain.OBS_OBJECT_WORK obj_work2 = gms_SCORE_DISP_WORK.efct_work[i].efct_com.obj_work;
            gms_SCORE_DISP_WORK.efct_work[i].efct_com.obj_work.scale.z = scale;
            obj_work2.scale.y = scale;
            obj_work.scale.x = scale;
            gms_SCORE_DISP_WORK.efct_work[i].obj_3des.command_state = 10U;
            AppMain.GmComEfctSetDispOffset( gms_SCORE_DISP_WORK.efct_work[i], num3, 0, 0 );
            i++;
            num3 += num4;
        }
    }

    // Token: 0x06000850 RID: 2128 RVA: 0x00048BB0 File Offset: 0x00046DB0
    public static void gmScoreMainFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_SCORE_DISP_WORK gms_SCORE_DISP_WORK = (AppMain.GMS_SCORE_DISP_WORK)obj_work;
        AppMain.GMS_SCORE_DISP_WORK gms_SCORE_DISP_WORK2 = gms_SCORE_DISP_WORK;
        gms_SCORE_DISP_WORK2.base_pos.y = gms_SCORE_DISP_WORK2.base_pos.y + gms_SCORE_DISP_WORK.rise_spd;
        gms_SCORE_DISP_WORK.rise_spd += gms_SCORE_DISP_WORK.rise_dec;
        if ( gms_SCORE_DISP_WORK.rise_spd > 0 )
        {
            gms_SCORE_DISP_WORK.rise_spd = 0;
        }
        obj_work.pos.Assign( gms_SCORE_DISP_WORK.base_pos );
        if ( gms_SCORE_DISP_WORK.rise_spd != 0 )
        {
            gms_SCORE_DISP_WORK.vib_timer = AppMain.ObjTimeCountUp( gms_SCORE_DISP_WORK.vib_timer );
            int num = gms_SCORE_DISP_WORK.vib_timer >> 12 & 7;
            obj_work.pos.x = obj_work.pos.x + AppMain.FX_Mul( AppMain.gm_score_vib_tbl[num][0], AppMain.gm_score_vib_scale_tbl[gms_SCORE_DISP_WORK.vib_level] );
            obj_work.pos.y = obj_work.pos.y + AppMain.FX_Mul( AppMain.gm_score_vib_tbl[num][1], AppMain.gm_score_vib_scale_tbl[gms_SCORE_DISP_WORK.vib_level] );
        }
        gms_SCORE_DISP_WORK.timer = AppMain.ObjTimeCountDown( gms_SCORE_DISP_WORK.timer );
        if ( gms_SCORE_DISP_WORK.timer <= 0 )
        {
            for ( int i = 0; i < 5; i++ )
            {
                if ( gms_SCORE_DISP_WORK.efct_work[i] != null )
                {
                    gms_SCORE_DISP_WORK.efct_work[i].efct_com.obj_work.flag |= 8U;
                }
            }
            obj_work.flag |= 4U;
        }
    }
}