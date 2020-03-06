using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000190 RID: 400
    public class GMS_BOSS4_DIRECTION
    {
        // Token: 0x04004EED RID: 20205
        public int direction;

        // Token: 0x04004EEE RID: 20206
        public short cur_angle;

        // Token: 0x04004EEF RID: 20207
        public short orig_angle;

        // Token: 0x04004EF0 RID: 20208
        public int turn_angle;

        // Token: 0x04004EF1 RID: 20209
        public int turn_amount;

        // Token: 0x04004EF2 RID: 20210
        public int turn_spd;

        // Token: 0x04004EF3 RID: 20211
        public int turn_gen_var;

        // Token: 0x04004EF4 RID: 20212
        public int turn_gen_factor;
    }

    // Token: 0x02000191 RID: 401
    public class GMS_BOSS4_FLICKER_WORK
    {
        // Token: 0x060021C7 RID: 8647 RVA: 0x00141B94 File Offset: 0x0013FD94
        public void Clear()
        {
            this.is_active = false;
            this.cycles = 0U;
            this.interval_timer = 0U;
            this.cur_angle = 0;
            this.add_timer = 0;
            this.radius = 0f;
            this.interval_flk = 0U;
            this.color.Clear();
            Array.Clear( this.reserved, 0, this.reserved.Length );
        }

        // Token: 0x04004EF5 RID: 20213
        public bool is_active;

        // Token: 0x04004EF6 RID: 20214
        public uint cycles;

        // Token: 0x04004EF7 RID: 20215
        public uint interval_timer;

        // Token: 0x04004EF8 RID: 20216
        public int cur_angle;

        // Token: 0x04004EF9 RID: 20217
        public int add_timer;

        // Token: 0x04004EFA RID: 20218
        public float radius;

        // Token: 0x04004EFB RID: 20219
        public uint interval_flk;

        // Token: 0x04004EFC RID: 20220
        public readonly AppMain.NNS_RGB color = new AppMain.NNS_RGB();

        // Token: 0x04004EFD RID: 20221
        public readonly uint[] reserved = new uint[3];
    }

    // Token: 0x02000192 RID: 402
    public class GMS_BOSS4_MOVE
    {
        // Token: 0x04004EFE RID: 20222
        public AppMain.VecFx32 pos;

        // Token: 0x04004EFF RID: 20223
        public AppMain.VecFx32 start;

        // Token: 0x04004F00 RID: 20224
        public AppMain.VecFx32 end;

        // Token: 0x04004F01 RID: 20225
        public int now_count;

        // Token: 0x04004F02 RID: 20226
        public int max_count;

        // Token: 0x04004F03 RID: 20227
        public int type;
    }

    // Token: 0x02000193 RID: 403
    public class GMS_BOSS4_NODE_MATRIX
    {
        // Token: 0x04004F04 RID: 20228
        public string _id = "";

        // Token: 0x04004F05 RID: 20229
        public int initCount;

        // Token: 0x04004F06 RID: 20230
        public int useCount;

        // Token: 0x04004F07 RID: 20231
        public readonly AppMain.GMS_BS_CMN_BMCB_MGR mtn_mgr = new AppMain.GMS_BS_CMN_BMCB_MGR();

        // Token: 0x04004F08 RID: 20232
        public readonly AppMain.GMS_BS_CMN_SNM_WORK snm_work = new AppMain.GMS_BS_CMN_SNM_WORK();

        // Token: 0x04004F09 RID: 20233
        public readonly int[] work = new int[32];

        // Token: 0x04004F0A RID: 20234
        public AppMain.OBS_OBJECT_WORK obj_work;
    }

    // Token: 0x02000194 RID: 404
    public class GMS_BOSS4_1SHOT_TIMER
    {
        // Token: 0x04004F0B RID: 20235
        public uint timer;

        // Token: 0x04004F0C RID: 20236
        public bool is_active;
    }

    // Token: 0x02000195 RID: 405
    public class GMS_BOSS4_NOHIT_TIMER
    {
        // Token: 0x04004F0D RID: 20237
        public uint timer;

        // Token: 0x04004F0E RID: 20238
        public AppMain.GMS_ENEMY_COM_WORK ene_com;
    }

    // Token: 0x02000196 RID: 406
    public class GMS_BOSS4_CAP_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x060021CD RID: 8653 RVA: 0x00141C62 File Offset: 0x0013FE62
        public GMS_BOSS4_CAP_WORK()
        {
            this.ene_3d = new AppMain.GMS_ENEMY_3D_WORK( this );
        }

        // Token: 0x060021CE RID: 8654 RVA: 0x00141C97 File Offset: 0x0013FE97
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_3d.ene_com.obj_work;
        }

        // Token: 0x04004F0F RID: 20239
        public readonly AppMain.GMS_ENEMY_3D_WORK ene_3d;

        // Token: 0x04004F10 RID: 20240
        public int type;

        // Token: 0x04004F11 RID: 20241
        public uint flag;

        // Token: 0x04004F12 RID: 20242
        public readonly AppMain.GMS_BOSS4_1SHOT_TIMER timer = new AppMain.GMS_BOSS4_1SHOT_TIMER();

        // Token: 0x04004F13 RID: 20243
        public readonly int egg_act_id;

        // Token: 0x04004F14 RID: 20244
        public int cap_no;

        // Token: 0x04004F15 RID: 20245
        public readonly AppMain.GMS_BOSS4_EFF_BOMB_WORK bomb = new AppMain.GMS_BOSS4_EFF_BOMB_WORK();

        // Token: 0x04004F16 RID: 20246
        public int wait;

        // Token: 0x04004F17 RID: 20247
        public readonly AppMain.GMS_BOSS4_FLICKER_WORK flk_work = new AppMain.GMS_BOSS4_FLICKER_WORK();

        // Token: 0x04004F18 RID: 20248
        public int chibi_type;

        // Token: 0x04004F19 RID: 20249
        public AppMain.MPP_VOID_GMS_BOSS4_CAP_WORK proc_update;
    }

    // Token: 0x17000020 RID: 32
    // (get) Token: 0x06000E86 RID: 3718 RVA: 0x00081A18 File Offset: 0x0007FC18
    public static int GME_BOSS4_LIFE_H
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 3, 4 );
        }
    }

    // Token: 0x17000021 RID: 33
    // (get) Token: 0x06000E87 RID: 3719 RVA: 0x00081A21 File Offset: 0x0007FC21
    public static int GME_BOSS4_LIFE_L
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 1, 2 );
        }
    }

    // Token: 0x17000022 RID: 34
    // (get) Token: 0x06000E88 RID: 3720 RVA: 0x00081A2A File Offset: 0x0007FC2A
    public static uint GMD_BOSS4_CHIBI_LIFE_TIME
    {
        get
        {
            return ( uint )AppMain.GMM_BOSS4_PAL_TIME( 300f );
        }
    }

    // Token: 0x17000023 RID: 35
    // (get) Token: 0x06000E89 RID: 3721 RVA: 0x00081A36 File Offset: 0x0007FC36
    public static float GMD_BOSS4_CHIBI_HIT_CHIBI_ADDSPD
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 1f );
        }
    }

    // Token: 0x17000024 RID: 36
    // (get) Token: 0x06000E8A RID: 3722 RVA: 0x00081A42 File Offset: 0x0007FC42
    public static float GMD_BOSS4_CHIBI_SPD_LIMIT
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 2f );
        }
    }

    // Token: 0x17000025 RID: 37
    // (get) Token: 0x06000E8B RID: 3723 RVA: 0x00081A4E File Offset: 0x0007FC4E
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_Y_NORMAL
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -4.5f );
        }
    }

    // Token: 0x17000026 RID: 38
    // (get) Token: 0x06000E8C RID: 3724 RVA: 0x00081A5A File Offset: 0x0007FC5A
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_Y_BOUND
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -4.5f );
        }
    }

    // Token: 0x17000027 RID: 39
    // (get) Token: 0x06000E8D RID: 3725 RVA: 0x00081A66 File Offset: 0x0007FC66
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_Y_SPEED
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -4.5f );
        }
    }

    // Token: 0x17000028 RID: 40
    // (get) Token: 0x06000E8E RID: 3726 RVA: 0x00081A72 File Offset: 0x0007FC72
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_Y_BIG
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -3.5f );
        }
    }

    // Token: 0x17000029 RID: 41
    // (get) Token: 0x06000E8F RID: 3727 RVA: 0x00081A7E File Offset: 0x0007FC7E
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_Y_IRON
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2f );
        }
    }

    // Token: 0x1700002A RID: 42
    // (get) Token: 0x06000E90 RID: 3728 RVA: 0x00081A8A File Offset: 0x0007FC8A
    public static float GMD_BOSS4_CHIBI_FALL_SPD_NORMAL
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.1f );
        }
    }

    // Token: 0x1700002B RID: 43
    // (get) Token: 0x06000E91 RID: 3729 RVA: 0x00081A96 File Offset: 0x0007FC96
    public static float GMD_BOSS4_CHIBI_FALL_SPD_BOUND
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.1f );
        }
    }

    // Token: 0x1700002C RID: 44
    // (get) Token: 0x06000E92 RID: 3730 RVA: 0x00081AA2 File Offset: 0x0007FCA2
    public static float GMD_BOSS4_CHIBI_FALL_SPD_SPEED
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.2f );
        }
    }

    // Token: 0x1700002D RID: 45
    // (get) Token: 0x06000E93 RID: 3731 RVA: 0x00081AAE File Offset: 0x0007FCAE
    public static float GMD_BOSS4_CHIBI_FALL_SPD_BIG
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.1f );
        }
    }

    // Token: 0x1700002E RID: 46
    // (get) Token: 0x06000E94 RID: 3732 RVA: 0x00081ABA File Offset: 0x0007FCBA
    public static float GMD_BOSS4_CHIBI_FALL_SPD_IRON
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.18f );
        }
    }

    // Token: 0x1700002F RID: 47
    // (get) Token: 0x06000E95 RID: 3733 RVA: 0x00081AC6 File Offset: 0x0007FCC6
    public static int GMD_BOSS4_CHIBI_BOUND_FRAME
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_TIME( 10f );
        }
    }

    // Token: 0x17000030 RID: 48
    // (get) Token: 0x06000E96 RID: 3734 RVA: 0x00081AD2 File Offset: 0x0007FCD2
    public static float GMD_BOSS4_CHIBI_BOUND_MULTI_SPD_X
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 0.8f );
        }
    }

    // Token: 0x17000031 RID: 49
    // (get) Token: 0x06000E97 RID: 3735 RVA: 0x00081ADE File Offset: 0x0007FCDE
    public static float GMD_BOSS4_CHIBI_BOUND_ADD_SPD_X
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( 1.5f );
        }
    }

    // Token: 0x17000032 RID: 50
    // (get) Token: 0x06000E98 RID: 3736 RVA: 0x00081AEA File Offset: 0x0007FCEA
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_X_BOUND
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -1.2f );
        }
    }

    // Token: 0x17000033 RID: 51
    // (get) Token: 0x06000E99 RID: 3737 RVA: 0x00081AF6 File Offset: 0x0007FCF6
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_X_SPEED
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2.5f );
        }
    }

    // Token: 0x17000034 RID: 52
    // (get) Token: 0x06000E9A RID: 3738 RVA: 0x00081B02 File Offset: 0x0007FD02
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_X_BIG
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2f );
        }
    }

    // Token: 0x17000035 RID: 53
    // (get) Token: 0x06000E9B RID: 3739 RVA: 0x00081B0E File Offset: 0x0007FD0E
    public static float GMD_BOSS4_CHIBI_BOUND_SPD_X_IRON
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_SPEED( -2f );
        }
    }

    // Token: 0x17000036 RID: 54
    // (get) Token: 0x06000E9C RID: 3740 RVA: 0x00081B1A File Offset: 0x0007FD1A
    public static float GMD_BOSS4_CHIBI_BOUND_OUT_Y
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_ZOOM( 1.04f );
        }
    }

    // Token: 0x17000037 RID: 55
    // (get) Token: 0x06000E9D RID: 3741 RVA: 0x00081B26 File Offset: 0x0007FD26
    public static float GMD_BOSS4_CHIBI_BOUND_OUT_X
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_ZOOM( 0.95f );
        }
    }

    // Token: 0x17000038 RID: 56
    // (get) Token: 0x06000E9E RID: 3742 RVA: 0x00081B32 File Offset: 0x0007FD32
    public static float GMD_BOSS4_CHIBI_BOUND_IN_Y
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_ZOOM( 0.9f );
        }
    }

    // Token: 0x17000039 RID: 57
    // (get) Token: 0x06000E9F RID: 3743 RVA: 0x00081B3E File Offset: 0x0007FD3E
    public static float GMD_BOSS4_CHIBI_BOUND_IN_X
    {
        get
        {
            return AppMain.GMM_BOSS4_PAL_ZOOM( 1.15f );
        }
    }

    // Token: 0x1700003A RID: 58
    // (get) Token: 0x06000EA0 RID: 3744 RVA: 0x00081B4A File Offset: 0x0007FD4A
    public static float GMD_BOSS4_CHIBI_EXPLOSION_BASE_HIDE_TIME
    {
        get
        {
            return ( float )AppMain.GMM_BOSS4_PAL_TIME( 2f );
        }
    }

    // Token: 0x1700003B RID: 59
    // (get) Token: 0x06000EA1 RID: 3745 RVA: 0x00081B57 File Offset: 0x0007FD57
    public static float GMD_BOSS4_CHIBI_EXPLOSION_TASK_KILL_TIME
    {
        get
        {
            return ( float )AppMain.GMM_BOSS4_PAL_TIME( 60f );
        }
    }

    // Token: 0x06000EA2 RID: 3746 RVA: 0x00081B64 File Offset: 0x0007FD64
    public static void SET_FLAG( uint f, AppMain.GMS_BOSS4_CHIBI_WORK w )
    {
        w.flag |= f;
    }

    // Token: 0x06000EA3 RID: 3747 RVA: 0x00081B74 File Offset: 0x0007FD74
    public static void RESET_FLAG( uint f, AppMain.GMS_BOSS4_CHIBI_WORK w )
    {
        w.flag &= ~f;
    }

    // Token: 0x06000EA4 RID: 3748 RVA: 0x00081B85 File Offset: 0x0007FD85
    public static bool IS_FLAG( uint f, AppMain.GMS_BOSS4_CHIBI_WORK w )
    {
        return 0U != ( w.flag & f );
    }

    // Token: 0x06000EA5 RID: 3749 RVA: 0x00081B98 File Offset: 0x0007FD98
    private static int gmBoss4ChibiGetAttackType( int life )
    {
        AppMain.UNREFERENCED_PARAMETER( life );
        AppMain.gmBoss4ChibiGetAttackTypeStatics._index %= 20;
        int num;
        if ( AppMain.GmBoss4GetLife() >= AppMain.GME_BOSS4_LIFE_H )
        {
            if ( !AppMain.GmBoss4CheckBossRush() )
            {
                return 1;
            }
            num = AppMain.gmBoss4ChibiGetAttackTypeStatics.life3_tbl_f[AppMain.gmBoss4ChibiGetAttackTypeStatics._index];
        }
        else if ( AppMain.GmBoss4CheckBossRush() )
        {
            if ( AppMain.GmBoss4GetLife() < AppMain.GME_BOSS4_LIFE_H && AppMain.GmBoss4GetLife() > AppMain.GME_BOSS4_LIFE_L )
            {
                num = AppMain.gmBoss4ChibiGetAttackTypeStatics.life2_tbl_f[AppMain.gmBoss4ChibiGetAttackTypeStatics._index];
            }
            else
            {
                num = AppMain.gmBoss4ChibiGetAttackTypeStatics.life1_tbl_f[AppMain.gmBoss4ChibiGetAttackTypeStatics._index];
            }
        }
        else if ( AppMain.GmBoss4GetLife() < AppMain.GME_BOSS4_LIFE_H && AppMain.GmBoss4GetLife() > AppMain.GME_BOSS4_LIFE_L )
        {
            num = AppMain.gmBoss4ChibiGetAttackTypeStatics.life2_tbl[AppMain.gmBoss4ChibiGetAttackTypeStatics._index];
        }
        else
        {
            num = AppMain.gmBoss4ChibiGetAttackTypeStatics.life1_tbl[AppMain.gmBoss4ChibiGetAttackTypeStatics._index];
        }
        AppMain.gmBoss4ChibiGetAttackTypeStatics._index++;
        switch ( num )
        {
            default:
                return 1;
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
        }
    }

    // Token: 0x06000EA6 RID: 3750 RVA: 0x00081C7A File Offset: 0x0007FE7A
    private static int gmBoss4ChibiGetThrowType()
    {
        return AppMain.gmBoss4ChibiGetThrowType( 1 );
    }

    // Token: 0x06000EA7 RID: 3751 RVA: 0x00081C84 File Offset: 0x0007FE84
    private static int gmBoss4ChibiGetThrowType( int t )
    {
        AppMain.gmBoss4ChibiGetThrowTypeStatics._index %= 20;
        int result = AppMain.gmBoss4ChibiGetThrowTypeStatics._tbl[AppMain.gmBoss4ChibiGetThrowTypeStatics._index];
        AppMain.gmBoss4ChibiGetThrowTypeStatics._index++;
        return result;
    }

    // Token: 0x06000EA8 RID: 3752 RVA: 0x00081CB7 File Offset: 0x0007FEB7
    private static void GmBoss4ChibiBuild()
    {
        AppMain.ObjDataLoadAmbIndex( AppMain.ObjDataGet( 732 ), 4, AppMain.GMD_BOSS4_ARC );
    }

    // Token: 0x06000EA9 RID: 3753 RVA: 0x00081CCF File Offset: 0x0007FECF
    private static void GmBoss4ChibiFlush()
    {
        AppMain.ObjDataRelease( AppMain.ObjDataGet( 732 ) );
    }

    // Token: 0x06000EAA RID: 3754 RVA: 0x00081CE0 File Offset: 0x0007FEE0
    private static AppMain.OBS_OBJECT_WORK GmBoss4ChibiInit1st( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4ChibiInit( eve_rec, pos_x, pos_y + 65536, 0 );
    }

    // Token: 0x06000EAB RID: 3755 RVA: 0x00081CFC File Offset: 0x0007FEFC
    private static AppMain.OBS_OBJECT_WORK GmBoss4ChibiInit2nd( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4ChibiInit( eve_rec, pos_x, pos_y + 65536, 1 );
    }

    // Token: 0x06000EAC RID: 3756 RVA: 0x00081D18 File Offset: 0x0007FF18
    private static AppMain.OBS_OBJECT_WORK GmBoss4ChibiInit2ndSpeed( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4ChibiInit( eve_rec, pos_x, pos_y + 65536, 2 );
    }

    // Token: 0x06000EAD RID: 3757 RVA: 0x00081D34 File Offset: 0x0007FF34
    private static AppMain.OBS_OBJECT_WORK GmBoss4ChibiInit2ndBig( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4ChibiInit( eve_rec, pos_x, pos_y + 65536, 3 );
    }

    // Token: 0x06000EAE RID: 3758 RVA: 0x00081D50 File Offset: 0x0007FF50
    private static AppMain.OBS_OBJECT_WORK GmBoss4ChibiInit2ndIron( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        return AppMain.GmBoss4ChibiInit( eve_rec, pos_x, pos_y + 65536, 4 );
    }

    // Token: 0x06000EAF RID: 3759 RVA: 0x00081D6C File Offset: 0x0007FF6C
    private static void GmBoss4ChibiSetInvincible( bool flg )
    {
        AppMain.gm_chibi_inv_flag = flg;
    }

    // Token: 0x06000EB0 RID: 3760 RVA: 0x00081D74 File Offset: 0x0007FF74
    private static void GmBoss4ChibiExplosion()
    {
        AppMain.gm_chibi_exp_flag = true;
    }

    // Token: 0x06000EB1 RID: 3761 RVA: 0x00081D84 File Offset: 0x0007FF84
    private static AppMain.OBS_OBJECT_WORK GmBoss4ChibiInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, int type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_ENEMY_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS4_CHIBI_WORK(), "BOSS4_C.E");
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obs_OBJECT_WORK;
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)obs_OBJECT_WORK;
        gms_BOSS4_CHIBI_WORK.type = type;
        switch ( gms_BOSS4_CHIBI_WORK.type )
        {
            default:
                AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 3 ), gms_ENEMY_3D_WORK.obj_3d );
                break;
            case 2:
                AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 4 ), gms_ENEMY_3D_WORK.obj_3d );
                break;
            case 3:
                AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 5 ), gms_ENEMY_3D_WORK.obj_3d );
                break;
            case 4:
                AppMain.ObjObjectCopyAction3dNNModel( obs_OBJECT_WORK, AppMain.GmBoss4GetObj3D( 6 ), gms_ENEMY_3D_WORK.obj_3d );
                break;
        }
        AppMain.ObjObjectAction3dNNMotionLoad( obs_OBJECT_WORK, 0, true, AppMain.ObjDataGet( 732 ), null, 0, null );
        AppMain.ObjDrawObjectSetToon( obs_OBJECT_WORK );
        obs_OBJECT_WORK.disp_flag |= 134217728U;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 4194304U;
        obs_OBJECT_WORK.move_flag &= 4294963199U;
        obs_OBJECT_WORK.move_flag |= 128U;
        gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
        AppMain.ObjObjectFieldRectSet( obs_OBJECT_WORK, -20, -44, 20, -4 );
        AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4ChibiWaitLoad ), obs_OBJECT_WORK );
        AppMain.gm_chibi_exp_flag = false;
        AppMain.RESET_FLAG( 536870912U, gms_BOSS4_CHIBI_WORK );
        if ( gms_BOSS4_CHIBI_WORK.type != 0 )
        {
            AppMain.SET_FLAG( 536870912U, gms_BOSS4_CHIBI_WORK );
        }
        AppMain.mtTaskChangeTcbDestructor( obs_OBJECT_WORK.tcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.gmBoss4ChibiExit ) );
        obs_OBJECT_WORK.obj_3d.use_light_flag &= 4294967294U;
        obs_OBJECT_WORK.obj_3d.use_light_flag |= 64U;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000EB2 RID: 3762 RVA: 0x00081F50 File Offset: 0x00080150
    private static void gmBoss4ChibiAtkHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)my_rect.parent_obj.parent_obj;
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)my_rect.parent_obj;
        gms_BOSS4_BODY_WORK.flag[0] |= 268435456U;
        AppMain.GmEnemyDefaultAtkFunc( my_rect, your_rect );
        if ( gms_BOSS4_CHIBI_WORK.type != 0 )
        {
            AppMain.GMS_PLAYER_WORK ply_work = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
            if ( AppMain.GmPlayerKeyCheckWalkLeft( ply_work ) )
            {
                AppMain.GmPlayerSetReverse( ply_work );
            }
        }
        AppMain.SET_FLAG( 1073741824U, gms_BOSS4_CHIBI_WORK );
    }

    // Token: 0x06000EB3 RID: 3763 RVA: 0x00081FCC File Offset: 0x000801CC
    private static void gmBoss4ChibiDefHitFunc( AppMain.OBS_RECT_WORK my_rect, AppMain.OBS_RECT_WORK your_rect )
    {
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)my_rect.parent_obj;
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK2 = (AppMain.GMS_BOSS4_CHIBI_WORK)your_rect.parent_obj;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = (AppMain.OBS_OBJECT_WORK)gms_BOSS4_CHIBI_WORK;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = (AppMain.OBS_OBJECT_WORK)gms_BOSS4_CHIBI_WORK2;
        if ( !AppMain.IS_FLAG( 536870912U, gms_BOSS4_CHIBI_WORK ) )
        {
            return;
        }
        if ( !AppMain.IS_FLAG( 536870912U, gms_BOSS4_CHIBI_WORK2 ) )
        {
            return;
        }
        if ( obs_OBJECT_WORK.pos.x > obs_OBJECT_WORK2.pos.x )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x + AppMain.FX_F32_TO_FX32( 4f );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
            obs_OBJECT_WORK4.spd.x = obs_OBJECT_WORK4.spd.x + AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_HIT_CHIBI_ADDSPD );
        }
        if ( obs_OBJECT_WORK.pos.x < obs_OBJECT_WORK2.pos.x )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK5 = obs_OBJECT_WORK;
            obs_OBJECT_WORK5.pos.x = obs_OBJECT_WORK5.pos.x - AppMain.FX_F32_TO_FX32( 4f );
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK6 = obs_OBJECT_WORK;
            obs_OBJECT_WORK6.spd.x = obs_OBJECT_WORK6.spd.x - AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_HIT_CHIBI_ADDSPD );
        }
        if ( obs_OBJECT_WORK.pos.x == obs_OBJECT_WORK2.pos.x )
        {
            if ( obs_OBJECT_WORK.pos.y < obs_OBJECT_WORK.pos.y )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK7 = obs_OBJECT_WORK;
                obs_OBJECT_WORK7.pos.x = obs_OBJECT_WORK7.pos.x + AppMain.FX_F32_TO_FX32( 4f );
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK8 = obs_OBJECT_WORK;
                obs_OBJECT_WORK8.spd.x = obs_OBJECT_WORK8.spd.x + AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_HIT_CHIBI_ADDSPD );
            }
            else
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK9 = obs_OBJECT_WORK;
                obs_OBJECT_WORK9.pos.x = obs_OBJECT_WORK9.pos.x - AppMain.FX_F32_TO_FX32( 4f );
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK10 = obs_OBJECT_WORK;
                obs_OBJECT_WORK10.spd.x = obs_OBJECT_WORK10.spd.x - AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_HIT_CHIBI_ADDSPD );
            }
        }
        if ( obs_OBJECT_WORK.spd.x > AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT ) )
        {
            obs_OBJECT_WORK.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT );
        }
        if ( obs_OBJECT_WORK.spd.x < -AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT ) )
        {
            obs_OBJECT_WORK.spd.x = -AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT );
        }
    }

    // Token: 0x06000EB4 RID: 3764 RVA: 0x000821BC File Offset: 0x000803BC
    private static void gmBoss4ChibiWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)obj_work;
        if ( AppMain.GmBoss4IsBuilded() )
        {
            AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4ChibiMain ), obj_work );
            AppMain.GmBoss4UtilInit1ShotTimer( gms_BOSS4_CHIBI_WORK.timer, AppMain.GMD_BOSS4_CHIBI_LIFE_TIME );
            AppMain.GmBoss4UtilInitFlicker( obj_work, gms_BOSS4_CHIBI_WORK.flk_work, 1, 180, 4, ( int )( gms_BOSS4_CHIBI_WORK.timer.timer / 20U * 3U ), AppMain.gm_boss4_color_red );
            gms_BOSS4_CHIBI_WORK.count = -1;
            switch ( gms_BOSS4_CHIBI_WORK.type )
            {
                default:
                    AppMain.GmBsCmnSetAction( obj_work, 0, 0 );
                    obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_NORMAL );
                    break;
                case 1:
                    AppMain.GmBsCmnSetAction( obj_work, 0, 0 );
                    obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_BOUND );
                    break;
                case 2:
                    AppMain.GmBsCmnSetAction( obj_work, 0, 0 );
                    obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_SPEED );
                    break;
                case 3:
                    AppMain.GmBsCmnSetAction( obj_work, 0, 0 );
                    obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_BIG );
                    break;
                case 4:
                    AppMain.GmBsCmnSetAction( obj_work, 0, 0 );
                    obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_IRON );
                    break;
            }
            obj_work.spd_fall = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_FALL_SPD_NORMAL );
            obj_work.pos.z = 131072;
            gms_BOSS4_CHIBI_WORK.bound = 0;
            AppMain.GmBoss4UtilInitNodeMatrix( gms_BOSS4_CHIBI_WORK.node_work, obj_work, 1 );
            AppMain.GmBoss4UtilGetNodeMatrix( gms_BOSS4_CHIBI_WORK.node_work, 0 );
            AppMain.gmBoss4ChibiBoosterCreate( gms_BOSS4_CHIBI_WORK );
            AppMain.GmSoundPlaySE( "Boss4_01" );
        }
    }

    // Token: 0x06000EB5 RID: 3765 RVA: 0x00082338 File Offset: 0x00080538
    private static void gmBoss4ChibiExit( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK p = AppMain.mtTaskGetTcbWork(tcb);
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)p;
        AppMain.GmBoss4DecObjCreateCount();
        AppMain.GmBoss4UtilExitNodeMatrix( gms_BOSS4_CHIBI_WORK.node_work );
        AppMain.GmEnemyDefaultExit( tcb );
    }

    // Token: 0x06000EB6 RID: 3766 RVA: 0x0008236C File Offset: 0x0008056C
    private static void gmBoss4ChibiMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)obj_work;
        if ( AppMain.GmBsCmnIsActionEnd( obj_work ) != 0 )
        {
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
            AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[1], -10, -22, 10, -2 );
            gms_ENEMY_3D_WORK.ene_com.rect_work[1].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4ChibiAtkHitFunc );
            gms_ENEMY_3D_WORK.ene_com.rect_work[1].flag |= 33554432U;
            AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[2], -14, -26, 18, 2 );
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].ppHit = new AppMain.OBS_RECT_WORK_Delegate1( AppMain.gmBoss4ChibiDefHitFunc );
            AppMain.ObjRectGroupSet( gms_ENEMY_3D_WORK.ene_com.rect_work[2], 2, 4 );
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag &= 4294965247U;
            gms_ENEMY_3D_WORK.ene_com.rect_work[2].flag |= 4U;
            switch ( gms_BOSS4_CHIBI_WORK.type )
            {
                case 3:
                    AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[1], -30, -60, 30, 0 );
                    AppMain.ObjRectWorkSet( gms_ENEMY_3D_WORK.ene_com.rect_work[2], -44, -64, 44, 4 );
                    break;
            }
        }
        switch ( gms_BOSS4_CHIBI_WORK.type )
        {
            default:
                obj_work.spd_fall = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_FALL_SPD_NORMAL );
                break;
            case 1:
                obj_work.move_flag &= 4294443007U;
                obj_work.spd_fall = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_FALL_SPD_BOUND );
                obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
                break;
            case 2:
                obj_work.move_flag &= 4294443007U;
                obj_work.spd_fall = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_FALL_SPD_SPEED );
                obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
                if ( gms_BOSS4_CHIBI_WORK.bound == 0 )
                {
                    obj_work.pos.y = obj_work.pos.y + obj_work.spd.y;
                }
                break;
            case 3:
                obj_work.move_flag &= 4294443007U;
                obj_work.spd_fall = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_FALL_SPD_BIG );
                obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
                break;
            case 4:
                obj_work.move_flag &= 4294443007U;
                obj_work.spd_fall = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_FALL_SPD_IRON );
                obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
                obj_work.pos.x = obj_work.pos.x - AppMain.FX_F32_TO_FX32( 4f );
                break;
        }
        if ( obj_work.scale.y < AppMain.FX_F32_TO_FX32( 1f ) )
        {
            obj_work.scale.y = ( int )( ( float )obj_work.scale.y * AppMain.GMD_BOSS4_CHIBI_BOUND_OUT_Y );
            if ( obj_work.scale.y > AppMain.FX_F32_TO_FX32( 1f ) )
            {
                obj_work.scale.y = AppMain.FX_F32_TO_FX32( 1f );
            }
        }
        if ( obj_work.scale.x > AppMain.FX_F32_TO_FX32( 1f ) )
        {
            obj_work.scale.x = ( int )( ( float )obj_work.scale.x * AppMain.GMD_BOSS4_CHIBI_BOUND_OUT_X );
            if ( obj_work.scale.x < AppMain.FX_F32_TO_FX32( 1f ) )
            {
                obj_work.scale.x = AppMain.FX_F32_TO_FX32( 1f );
            }
        }
        if ( AppMain.gm_chibi_exp_flag )
        {
            AppMain.SET_FLAG( 1073741824U, gms_BOSS4_CHIBI_WORK );
        }
        AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK2 = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
        if ( AppMain.gm_chibi_inv_flag )
        {
            gms_ENEMY_3D_WORK2.ene_com.rect_work[1].flag |= 2048U;
        }
        else
        {
            gms_ENEMY_3D_WORK2.ene_com.rect_work[1].flag &= 4294965247U;
        }
        if ( ( obj_work.move_flag & 1U ) != 0U )
        {
            AppMain.SET_FLAG( 536870912U, gms_BOSS4_CHIBI_WORK );
            obj_work.move_flag &= 4294967294U;
            obj_work.move_flag &= 4294967167U;
            obj_work.move_flag |= 256U;
            gms_BOSS4_CHIBI_WORK.bnd_xspd = obj_work.spd.x;
            obj_work.spd.y = 0;
            obj_work.spd.x = 0;
            obj_work.spd_fall = 0;
            if ( gms_BOSS4_CHIBI_WORK.type == 4 )
            {
                gms_BOSS4_CHIBI_WORK.bound = 1000;
            }
            else
            {
                gms_BOSS4_CHIBI_WORK.bound = AppMain.GMD_BOSS4_CHIBI_BOUND_FRAME;
            }
            if ( gms_BOSS4_CHIBI_WORK.type == 3 )
            {
                AppMain.GmSoundPlaySE( "Boss4_03" );
            }
            else if ( gms_BOSS4_CHIBI_WORK.type != 4 )
            {
                AppMain.GmSoundPlaySE( "Boss4_02" );
            }
        }
        if ( gms_BOSS4_CHIBI_WORK.bound > 0 )
        {
            if ( --gms_BOSS4_CHIBI_WORK.bound == 0 )
            {
                obj_work.pos.y = obj_work.pos.y + AppMain.FX_F32_TO_FX32( -4f );
                obj_work.move_flag |= 128U;
                obj_work.move_flag &= 4294967039U;
                obj_work.move_flag &= 4294967294U;
                obj_work.spd.x = gms_BOSS4_CHIBI_WORK.bnd_xspd;
                switch ( gms_BOSS4_CHIBI_WORK.type )
                {
                    default:
                        obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_NORMAL );
                        if ( AppMain.GmBsCmnGetPlayerObj().pos.x < obj_work.pos.x )
                        {
                            obj_work.spd.x = ( int )( ( float )obj_work.spd.x * AppMain.GMD_BOSS4_CHIBI_BOUND_MULTI_SPD_X ) - AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_ADD_SPD_X );
                        }
                        else
                        {
                            obj_work.spd.x = ( int )( ( float )obj_work.spd.x * AppMain.GMD_BOSS4_CHIBI_BOUND_MULTI_SPD_X ) + AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_ADD_SPD_X );
                        }
                        if ( obj_work.spd.x > AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT ) )
                        {
                            obj_work.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT );
                        }
                        if ( obj_work.spd.x < -AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT ) )
                        {
                            obj_work.spd.x = -AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_SPD_LIMIT );
                        }
                        break;
                    case 1:
                        obj_work.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_X_BOUND );
                        obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_BOUND );
                        break;
                    case 2:
                        obj_work.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_X_SPEED );
                        obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_SPEED );
                        break;
                    case 3:
                        obj_work.spd.x = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_X_BIG );
                        obj_work.spd.y = AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_CHIBI_BOUND_SPD_Y_BIG );
                        break;
                    case 4:
                        obj_work.spd.x = AppMain.FX_F32_TO_FX32( 0.0 );
                        obj_work.spd.y = AppMain.FX_F32_TO_FX32( 0.0 );
                        break;
                }
            }
            else if ( gms_BOSS4_CHIBI_WORK.type != 4 )
            {
                obj_work.scale.y = ( int )( ( float )obj_work.scale.y * AppMain.GMD_BOSS4_CHIBI_BOUND_IN_Y );
                obj_work.scale.x = ( int )( ( float )obj_work.scale.x * AppMain.GMD_BOSS4_CHIBI_BOUND_IN_X );
                obj_work.spd_fall = 0;
                if ( obj_work.scale.y < AppMain.FX_F32_TO_FX32( 0.6f ) )
                {
                    obj_work.scale.y = AppMain.FX_F32_TO_FX32( 0.6f );
                }
                if ( obj_work.scale.x > AppMain.FX_F32_TO_FX32( 1.5f ) )
                {
                    obj_work.scale.x = AppMain.FX_F32_TO_FX32( 1.5f );
                }
            }
        }
        if ( gms_BOSS4_CHIBI_WORK.type != 4 )
        {
            AppMain.GmBoss4UtilLookAtPlayer( gms_BOSS4_CHIBI_WORK.dir, obj_work, 5 );
        }
        if ( AppMain.GmBoss4UtilUpdate1ShotTimer( gms_BOSS4_CHIBI_WORK.timer ) )
        {
            AppMain.SET_FLAG( 1073741824U, gms_BOSS4_CHIBI_WORK );
        }
        if ( gms_BOSS4_CHIBI_WORK.type == 0 && AppMain.GmBoss4UtilUpdateFlicker( obj_work, gms_BOSS4_CHIBI_WORK.flk_work ) )
        {
            int start = (int)(gms_BOSS4_CHIBI_WORK.timer.timer / 20U * 3U);
            AppMain.GmBoss4UtilInitFlicker( obj_work, gms_BOSS4_CHIBI_WORK.flk_work, 1, start, 2, 0, AppMain.gm_boss4_color_red );
        }
        if ( AppMain.IS_FLAG( 1073741824U, gms_BOSS4_CHIBI_WORK ) )
        {
            AppMain.RESET_FLAG( 1073741824U, gms_BOSS4_CHIBI_WORK );
            int id;
            switch ( gms_BOSS4_CHIBI_WORK.type )
            {
                default:
                    id = 736;
                    break;
                case 2:
                    id = 737;
                    break;
                case 3:
                    id = 738;
                    break;
            }
            AppMain.VecFx32 pos = obj_work.pos;
            pos.y += AppMain.FX_F32_TO_FX32( -16f );
            pos.z = 135168;
            AppMain.GmBoss4EffCommonInit( id, new AppMain.VecFx32?( pos ) );
            AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK3 = (AppMain.GMS_ENEMY_3D_WORK)obj_work;
            gms_ENEMY_3D_WORK3.ene_com.rect_work[1].flag &= 4294967291U;
            gms_ENEMY_3D_WORK3.ene_com.rect_work[2].flag &= 4294967291U;
            obj_work.spd_fall = 0;
            obj_work.spd.x = 0;
            obj_work.spd.y = 0;
            obj_work.move_flag &= 4294967294U;
            obj_work.move_flag |= 256U;
            obj_work.move_flag |= 256U;
            gms_BOSS4_CHIBI_WORK.wait = 0;
            AppMain.T_FUNC( new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4ChibiBomb ), obj_work );
            AppMain.GmSoundPlaySE( "Boss4_04" );
        }
        AppMain.GmBoss4UtilUpdateDirection( gms_BOSS4_CHIBI_WORK.dir, obj_work, true );
    }

    // Token: 0x06000EB7 RID: 3767 RVA: 0x00082CD8 File Offset: 0x00080ED8
    private static void gmBoss4ChibiBomb( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)obj_work;
        obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
        gms_BOSS4_CHIBI_WORK.wait++;
        if ( gms_BOSS4_CHIBI_WORK.wait >= 2 )
        {
            obj_work.disp_flag |= 32U;
        }
        if ( gms_BOSS4_CHIBI_WORK.wait < 60 )
        {
            return;
        }
        AppMain.GMM_BS_OBJ( gms_BOSS4_CHIBI_WORK ).flag |= 8U;
    }

    // Token: 0x06000EB8 RID: 3768 RVA: 0x00082D48 File Offset: 0x00080F48
    private static void gmBoss4ChibiFuncBoost( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_CHIBI_WORK gms_BOSS4_CHIBI_WORK = (AppMain.GMS_BOSS4_CHIBI_WORK)obj_work.parent_obj;
        AppMain.OBS_OBJECT_WORK parent_obj = obj_work.parent_obj;
        AppMain.MTM_ASSERT( ( int )gms_BOSS4_CHIBI_WORK.node_work.snm_work.reg_node_max );
        if ( ( obj_work.disp_flag & 8U ) != 0U )
        {
            obj_work.flag |= 4U;
        }
        if ( ( parent_obj.disp_flag & 32U ) != 0U )
        {
            AppMain.gmBoss4ChibiBoosterDelete( gms_BOSS4_CHIBI_WORK );
        }
        obj_work.disp_flag &= 4294967263U;
        if ( gms_BOSS4_CHIBI_WORK.dir.cur_angle < AppMain.AKM_DEGtoA16( 50 ) && gms_BOSS4_CHIBI_WORK.dir.cur_angle > AppMain.AKM_DEGtoA16( -50 ) )
        {
            obj_work.disp_flag |= 32U;
        }
        AppMain.GmBsCmnUpdateObject3DESStuckWithNode( obj_work, gms_BOSS4_CHIBI_WORK.node_work.snm_work, gms_BOSS4_CHIBI_WORK.node_work.work[0], 1 );
        obj_work.disp_flag &= 4294963199U;
        if ( ( AppMain.g_obj.flag & 1U ) != 0U )
        {
            obj_work.disp_flag |= 4096U;
            return;
        }
        obj_work.pos.x = obj_work.pos.x + parent_obj.spd.x;
        obj_work.pos.y = obj_work.pos.y + parent_obj.spd.y;
        obj_work.pos.x = obj_work.pos.x + AppMain.GmBoss4GetScrollOffset();
    }

    // Token: 0x06000EB9 RID: 3769 RVA: 0x00082E8F File Offset: 0x0008108F
    private static void gmBoss4ChibiBoosterCreate( AppMain.GMS_BOSS4_CHIBI_WORK chibi )
    {
    }

    // Token: 0x06000EBA RID: 3770 RVA: 0x00082E91 File Offset: 0x00081091
    private static void gmBoss4ChibiBoosterDelete( AppMain.GMS_BOSS4_CHIBI_WORK chibi )
    {
        if ( chibi.boost != null )
        {
            AppMain.ObjDrawKillAction3DES( ( AppMain.OBS_OBJECT_WORK )chibi.boost );
            chibi.boost = null;
        }
    }

    // Token: 0x1700003C RID: 60
    // (get) Token: 0x06000EBB RID: 3771 RVA: 0x00082EB2 File Offset: 0x000810B2
    public static AppMain.AMS_AMB_HEADER GMD_BOSS4_ARC
    {
        get
        {
            return AppMain.g_gm_gamedat_enemy_arc;
        }
    }

    // Token: 0x06000EBC RID: 3772 RVA: 0x00082EB9 File Offset: 0x000810B9
    public static T GMM_BOSS4_STAGE<T>( T s4, T sf )
    {
        if ( !AppMain.GmBoss4CheckBossRush() )
        {
            return s4;
        }
        return sf;
    }

    // Token: 0x1700003D RID: 61
    // (get) Token: 0x06000EBD RID: 3773 RVA: 0x00082EC5 File Offset: 0x000810C5
    public static int GMD_BOSS4_SCROLL_INIT_X
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 2500, 11000 );
        }
    }

    // Token: 0x1700003E RID: 62
    // (get) Token: 0x06000EBE RID: 3774 RVA: 0x00082ED6 File Offset: 0x000810D6
    public static int GMD_BOSS4_SCROLL_START_X
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 2500, 11000 );
        }
    }

    // Token: 0x1700003F RID: 63
    // (get) Token: 0x06000EBF RID: 3775 RVA: 0x00082EE7 File Offset: 0x000810E7
    public static int GMD_BOSS4_SCROLL_END_X
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 3972, 12536 );
        }
    }

    // Token: 0x17000040 RID: 64
    // (get) Token: 0x06000EC0 RID: 3776 RVA: 0x00082EF8 File Offset: 0x000810F8
    public static int GMD_BOSS4_SCROLL_OUT_X
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 2500, 11000 );
        }
    }

    // Token: 0x17000041 RID: 65
    // (get) Token: 0x06000EC1 RID: 3777 RVA: 0x00082F09 File Offset: 0x00081109
    public static int GMD_BOSS4_LIFE
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 8, 4 );
        }
    }

    // Token: 0x17000042 RID: 66
    // (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00082F12 File Offset: 0x00081112
    public static int GMD_BOSS4_EXTRA_ATK_THRESHOLD_LIFE
    {
        get
        {
            return AppMain.GMM_BOSS4_STAGE<int>( 3, 4 );
        }
    }

    // Token: 0x06000EC3 RID: 3779 RVA: 0x00082F1B File Offset: 0x0008111B
    public static int GMM_BOSS4_AREA_LEFT()
    {
        return AppMain.g_gm_main_system.map_fcol.left << 12;
    }

    // Token: 0x06000EC4 RID: 3780 RVA: 0x00082F2F File Offset: 0x0008112F
    public static int GMM_BOSS4_AREA_TOP()
    {
        return AppMain.g_gm_main_system.map_fcol.top << 12;
    }

    // Token: 0x06000EC5 RID: 3781 RVA: 0x00082F43 File Offset: 0x00081143
    public static int GMM_BOSS4_AREA_RIGHT()
    {
        return AppMain.g_gm_main_system.map_fcol.right << 12;
    }

    // Token: 0x06000EC6 RID: 3782 RVA: 0x00082F57 File Offset: 0x00081157
    public static int GMM_BOSS4_AREA_BOTTOM()
    {
        return AppMain.g_gm_main_system.map_fcol.bottom << 12;
    }

    // Token: 0x06000EC7 RID: 3783 RVA: 0x00082F6B File Offset: 0x0008116B
    public static int GMM_BOSS4_AREA_CENTER_X()
    {
        return AppMain.GMM_BOSS4_AREA_LEFT() + ( AppMain.GMM_BOSS4_AREA_RIGHT() - AppMain.GMM_BOSS4_AREA_LEFT() ) / 2;
    }

    // Token: 0x06000EC8 RID: 3784 RVA: 0x00082F80 File Offset: 0x00081180
    public static int GMM_BOSS4_AREA_CENTER_Y()
    {
        return AppMain.GMM_BOSS4_AREA_TOP() + ( AppMain.GMM_BOSS4_AREA_BOTTOM() - AppMain.GMM_BOSS4_AREA_TOP() ) / 2;
    }

    // Token: 0x06000EC9 RID: 3785 RVA: 0x00082F95 File Offset: 0x00081195
    private static AppMain.OBS_OBJECT_WORK GMM_BOSS4_CREATE_WORK( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return AppMain.GmEnemyCreateWork( eve_rec, pos_x, pos_y, work_size, 4342, name );
    }

    // Token: 0x06000ECA RID: 3786 RVA: 0x00082FA7 File Offset: 0x000811A7
    private static void GmBoss4SetLife( int life )
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work );
        AppMain.gm_boss4_mgr_work.life = life;
    }

    // Token: 0x06000ECB RID: 3787 RVA: 0x00082FBE File Offset: 0x000811BE
    private static int GmBoss4GetLife()
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work );
        if ( AppMain.gm_boss4_mgr_work == null )
        {
            return 0;
        }
        return AppMain.gm_boss4_mgr_work.life;
    }

    // Token: 0x06000ECC RID: 3788 RVA: 0x00082FDD File Offset: 0x000811DD
    private static AppMain.OBS_OBJECT_WORK GmBoss4GetBodyWork()
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work );
        if ( AppMain.gm_boss4_mgr_work == null )
        {
            return null;
        }
        return ( AppMain.OBS_OBJECT_WORK )AppMain.gm_boss4_mgr_work.body_work;
    }

    // Token: 0x06000ECD RID: 3789 RVA: 0x00083001 File Offset: 0x00081201
    private static AppMain.OBS_ACTION3D_NN_WORK GmBoss4GetObj3D( int n )
    {
        return AppMain.gm_boss4_obj_3d_list[n];
    }

    // Token: 0x06000ECE RID: 3790 RVA: 0x0008300A File Offset: 0x0008120A
    private static AppMain.GMS_BOSS4_PART_ACT_INFO GmBoss4GetActInfo( int act, int parts )
    {
        return AppMain.gm_boss4_act_id_tbl[act][parts];
    }

    // Token: 0x06000ECF RID: 3791 RVA: 0x00083018 File Offset: 0x00081218
    private static void GmBoss4Build()
    {
        object obj = AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.GMD_BOSS4_ARC);
        object obj2 = AppMain.ObjDataLoadAmbIndex(null, 1, AppMain.GMD_BOSS4_ARC);
        AppMain.gm_boss4_obj_3d_list = AppMain.GmGameDBuildRegBuildModel( ( AppMain.AMS_AMB_HEADER )obj, ( AppMain.AMS_AMB_HEADER )obj2, 0U );
        AppMain.GmBoss4BodyBuild();
        AppMain.GmBoss4EggmanBuild();
        AppMain.GmBoss4CapsuleBuild();
        AppMain.GmBoss4ChibiBuild();
        AppMain.GmBoss4EffectBuild();
    }

    // Token: 0x06000ED0 RID: 3792 RVA: 0x00083070 File Offset: 0x00081270
    private static void GmBoss4Flush()
    {
        AppMain.GmBoss4EffectFlush();
        AppMain.GmBoss4ChibiFlush();
        AppMain.GmBoss4CapsuleFlush();
        AppMain.GmBoss4EggmanFlush();
        AppMain.GmBoss4BodyFlush();
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = (AppMain.AMS_AMB_HEADER)AppMain.ObjDataLoadAmbIndex(null, 0, AppMain.GMD_BOSS4_ARC);
        AppMain.GmGameDBuildRegFlushModel( AppMain.gm_boss4_obj_3d_list, ams_AMB_HEADER.file_num );
        AppMain.gm_boss4_obj_3d_list = null;
        AppMain.gm_boss4_mgr_work = null;
    }

    // Token: 0x06000ED1 RID: 3793 RVA: 0x000830C4 File Offset: 0x000812C4
    private static bool GmBoss4IsBuilded()
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work );
        return 0U != ( AppMain.gm_boss4_mgr_work.flag & 1U );
    }

    // Token: 0x06000ED2 RID: 3794 RVA: 0x000830EC File Offset: 0x000812EC
    private static AppMain.OBS_OBJECT_WORK GmBoss4Init( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_BOSS4_CREATE_WORK(eve_rec, pos_x, pos_y, () => new AppMain.GMS_BOSS4_MGR_WORK(), "Boss4_MGR");
        AppMain.GMS_BOSS4_MGR_WORK gms_BOSS4_MGR_WORK = (AppMain.GMS_BOSS4_MGR_WORK)obs_OBJECT_WORK;
        AppMain.gm_boss4_mgr_work = gms_BOSS4_MGR_WORK;
        obs_OBJECT_WORK.flag |= 16U;
        obs_OBJECT_WORK.disp_flag |= 32U;
        obs_OBJECT_WORK.move_flag |= 8448U;
        gms_BOSS4_MGR_WORK.life = AppMain.GMD_BOSS4_LIFE;
        obs_OBJECT_WORK.pos.x = pos_x;
        obs_OBJECT_WORK.pos.y = pos_y;
        obs_OBJECT_WORK.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4MgrWaitLoad );
        AppMain.GmBoss4ScrollOff();
        AppMain.gm_boss4_is_2nd = false;
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 )
        {
            AppMain.GmMapSetAddMapScrlScaleMagX( 2, 1 );
            AppMain.GmMapSetAddMapScrlScaleMagX( 3, 1 );
            AppMain.GmMapSetAddMapScrlScaleMagX( 4, 1 );
            AppMain.GmMapSetAddMapXLoop();
            AppMain.GmMapEnableAddMapUserScrlX();
        }
        AppMain.gm_boss4_n_scroll_start = AppMain.GMD_BOSS4_SCROLL_START_X;
        AppMain.gm_boss4_n_scroll_end = AppMain.GMD_BOSS4_SCROLL_END_X;
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000ED3 RID: 3795 RVA: 0x000831EE File Offset: 0x000813EE
    private static int GmBoss4GetScrollOffset()
    {
        return AppMain.FX_F32_TO_FX32( ( float )AppMain.gm_boss4_n_offset_x );
    }

    // Token: 0x06000ED4 RID: 3796 RVA: 0x000831FB File Offset: 0x000813FB
    private static void gmBoss4SetPartTextureBurnt( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.gmBoss4SetPartTextureBurnt( obj_work, true );
    }

    // Token: 0x06000ED5 RID: 3797 RVA: 0x00083204 File Offset: 0x00081404
    private static void gmBoss4SetPartTextureBurnt( AppMain.OBS_OBJECT_WORK obj_work, bool burn )
    {
        AppMain.MTM_ASSERT( obj_work );
        AppMain.MTM_ASSERT( obj_work.obj_3d );
        AppMain.MTM_ASSERT( obj_work.disp_flag & 134217728U );
        obj_work.obj_3d.drawflag |= 268435456U;
        obj_work.obj_3d.draw_state.texoffset[0].mode = 2;
        if ( burn )
        {
            obj_work.obj_3d.draw_state.texoffset[0].u = 0.5f;
            return;
        }
        obj_work.obj_3d.draw_state.texoffset[0].u = 0f;
    }

    // Token: 0x06000ED6 RID: 3798 RVA: 0x0008329E File Offset: 0x0008149E
    private static bool gmBoss4IsScrollLockBusy()
    {
        return ( AppMain.g_gm_main_system.game_flag & 32768U ) != 0U;
    }

    // Token: 0x06000ED7 RID: 3799 RVA: 0x000832B8 File Offset: 0x000814B8
    private static void gmBoss4MgrWaitLoad( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.GMS_BOSS4_MGR_WORK gms_BOSS4_MGR_WORK = (AppMain.GMS_BOSS4_MGR_WORK)obj_work;
        bool flag = false;
        int x = obj_work.pos.x;
        int y = obj_work.pos.y;
        if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
        {
            if ( AppMain.GmMainDatLoadBossBattleLoadCheck( 3 ) )
            {
                flag = true;
            }
        }
        else
        {
            flag = true;
        }
        if ( flag )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmEventMgrLocalEventBirth(321, x, y, 0, 0, 0, 0, 0, 0);
            AppMain.GmBoss4IncObjCreateCount();
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = AppMain.GmEventMgrLocalEventBirth(322, x, y, 0, 0, 0, 0, 0, 0);
            AppMain.GmBoss4IncObjCreateCount();
            AppMain.GmBoss4CapsuleClear();
            for ( int i = 0; i < 6; i++ )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = AppMain.GmEventMgrLocalEventBirth(323, x, y, 0, 0, 0, 0, 0, 0);
                obs_OBJECT_WORK3.parent_obj = obs_OBJECT_WORK;
                AppMain.GmBoss4IncObjCreateCount();
            }
            AppMain.GMS_BOSS4_BODY_WORK gms_BOSS4_BODY_WORK = (AppMain.GMS_BOSS4_BODY_WORK)obs_OBJECT_WORK;
            gms_BOSS4_MGR_WORK.body_work = gms_BOSS4_BODY_WORK;
            gms_BOSS4_BODY_WORK.mgr_work = gms_BOSS4_MGR_WORK;
            obs_OBJECT_WORK.parent_obj = obj_work;
            obs_OBJECT_WORK2.parent_obj = obs_OBJECT_WORK;
            gms_BOSS4_BODY_WORK.parts_objs[0] = obs_OBJECT_WORK;
            gms_BOSS4_BODY_WORK.parts_objs[1] = obs_OBJECT_WORK2;
        }
        if ( flag )
        {
            gms_BOSS4_MGR_WORK.flag |= 1U;
            obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4MgrMain );
        }
    }

    // Token: 0x06000ED8 RID: 3800 RVA: 0x000833D0 File Offset: 0x000815D0
    private static void gmBoss4MgrWaitRelease( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( AppMain.GmBoss4IsAllCreatedObjDeleted() )
        {
            AppMain.GMS_ENEMY_COM_WORK gms_ENEMY_COM_WORK = (AppMain.GMS_ENEMY_COM_WORK)obj_work;
            gms_ENEMY_COM_WORK.enemy_flag |= 65536U;
            obj_work.flag |= 4U;
            AppMain.GmGameDatReleaseBossBattleStart( 3 );
        }
    }

    // Token: 0x06000ED9 RID: 3801 RVA: 0x00083414 File Offset: 0x00081614
    private static void gmBoss4MgrMain( AppMain.OBS_OBJECT_WORK obj_work )
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(0);
        if ( obs_CAMERA == null )
        {
            return;
        }
        AppMain.GMS_BOSS4_MGR_WORK gms_BOSS4_MGR_WORK = (AppMain.GMS_BOSS4_MGR_WORK)obj_work;
        if ( ( gms_BOSS4_MGR_WORK.flag & 2U ) != 0U )
        {
            if ( gms_BOSS4_MGR_WORK.body_work != null )
            {
                AppMain.GMM_BS_OBJ( gms_BOSS4_MGR_WORK.body_work ).flag |= 8U;
                gms_BOSS4_MGR_WORK.body_work = null;
            }
            if ( AppMain.GmBsCmnIsFinalZoneType( obj_work ) != 0 )
            {
                obj_work.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK( AppMain.gmBoss4MgrWaitRelease );
            }
        }
        AppMain.GmBoss4CapsuleUpdateRol( AppMain.GMD_BOSS4_CAP_ROTATE_SPD );
        obs_CAMERA.flag &= 4294967294U;
        float num = obs_CAMERA.disp_pos.x - obs_CAMERA.prev_disp_pos.x;
        if ( num < -( AppMain.GMD_BOSS4_SCROLL_SPD_MAX + 8f ) )
        {
            num = AppMain.gmBoss4MgrMainStatics.xold;
        }
        if ( num > AppMain.GMD_BOSS4_SCROLL_SPD_MAX + 8f )
        {
            num = AppMain.gmBoss4MgrMainStatics.xold;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id != 16 )
        {
            AppMain.GmMapSetAddMapUserScrlXAddSize( num );
        }
        AppMain.gmBoss4MgrMainStatics.xold = num;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)obs_OBJECT_WORK;
        if ( AppMain.gm_boss4_n_scroll != 0 || AppMain.gm_boss4_f_scroll_spd > 0f )
        {
            int left = AppMain.g_gm_main_system.map_fcol.left;
            int right = AppMain.g_gm_main_system.map_fcol.right;
            AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(AppMain.FX_FX32_TO_F32(AppMain.GmBoss4GetScrollOffset()), 0f, 0f);
            if ( nns_VECTOR.x < 0f )
            {
                AppMain.amTrailEFOffsetPos( 1, nns_VECTOR );
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
            obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x + AppMain.GmBoss4GetScrollOffset();
            int num2 = (int)AppMain.gm_boss4_f_scroll_spd * 4096;
            if ( ( gms_PLAYER_WORK.player_flag & 1024U ) != 0U )
            {
                num2 = 0;
            }
            if ( gms_PLAYER_WORK.seq_state == 17 && gms_PLAYER_WORK.obj_work.spd.x < AppMain.FX_F32_TO_FX32( 2f ) )
            {
                num2 /= 4;
            }
            if ( gms_PLAYER_WORK.seq_state == 20 && gms_PLAYER_WORK.obj_work.spd.x < AppMain.FX_F32_TO_FX32( 3f ) )
            {
                num2 /= 4;
            }
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
            obs_OBJECT_WORK3.pos.x = obs_OBJECT_WORK3.pos.x - num2;
            int num3 = obs_OBJECT_WORK.pos.x / 4096;
            if ( left + 48 > num3 )
            {
                obs_OBJECT_WORK.pos.x = ( left + 48 ) * 4096;
            }
            if ( right < num3 )
            {
                obs_OBJECT_WORK.pos.x = ( right - 2 ) * 4096;
            }
            AppMain.GMS_BOSS4_BODY_WORK body_work = gms_BOSS4_MGR_WORK.body_work;
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = (AppMain.OBS_OBJECT_WORK)body_work;
            if ( obs_OBJECT_WORK4 != null )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK5 = obs_OBJECT_WORK4;
                obs_OBJECT_WORK5.pos.x = obs_OBJECT_WORK5.pos.x + AppMain.GmBoss4GetScrollOffset();
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK6 = obs_OBJECT_WORK4;
                obs_OBJECT_WORK6.pos.x = obs_OBJECT_WORK6.pos.x - AppMain.FX_F32_TO_FX32( AppMain.gm_boss4_f_scroll_spd );
                if ( AppMain.gm_boss4_n_scroll == 1 )
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK7 = obs_OBJECT_WORK4;
                    obs_OBJECT_WORK7.pos.x = obs_OBJECT_WORK7.pos.x + AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_SCROLL_SPD_BOSS );
                }
                else
                {
                    AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK8 = obs_OBJECT_WORK4;
                    obs_OBJECT_WORK8.pos.x = obs_OBJECT_WORK8.pos.x + AppMain.FX_F32_TO_FX32( AppMain.GMD_BOSS4_SCROLL_SPD_BOSS_BROKEN );
                }
                int num4 = (int)AppMain.FX_FX32_TO_F32(obs_OBJECT_WORK4.pos.x);
                if ( left > num4 )
                {
                    obs_OBJECT_WORK4.pos.x = AppMain.FX_F32_TO_FX32( ( float )left );
                }
                if ( AppMain.gm_boss4_n_scroll == 1 )
                {
                    num4 = ( int )AppMain.FX_FX32_TO_F32( obs_OBJECT_WORK4.pos.x );
                    if ( ( float )right - 50f > ( float )num4 )
                    {
                        obs_OBJECT_WORK4.pos.x = AppMain.FX_F32_TO_FX32( ( float )right - 50f );
                    }
                }
            }
            if ( obs_OBJECT_WORK4 != null )
            {
                AppMain.GMS_ENEMY_3D_WORK gms_ENEMY_3D_WORK = (AppMain.GMS_ENEMY_3D_WORK)body_work;
                int num5 = Math.Abs(obs_OBJECT_WORK4.pos.x - obs_OBJECT_WORK.pos.x);
                if ( num5 > AppMain.FX_F32_TO_FX32( 140f ) )
                {
                    gms_ENEMY_3D_WORK.ene_com.enemy_flag |= 32768U;
                    return;
                }
                gms_ENEMY_3D_WORK.ene_com.enemy_flag &= 4294934527U;
            }
        }
    }

    // Token: 0x06000EDA RID: 3802 RVA: 0x000837CC File Offset: 0x000819CC
    private static void gmCameraForceScrollFunc( AppMain.OBS_CAMERA obj_cam )
    {
        AppMain.GMS_PLAYER_WORK gms_PLAYER_WORK = (AppMain.GMS_PLAYER_WORK)AppMain.GmBsCmnGetPlayerObj();
        if ( ( AppMain.g_gm_main_system.game_flag & 64U ) != 0U )
        {
            return;
        }
        if ( AppMain.gm_boss4_f_scroll_spd <= -100f && AppMain.gm_boss4_n_scroll_pt_x == 0 )
        {
            if ( obj_cam.pos.x != obj_cam.prev_pos.x )
            {
                AppMain.gm_boss4_f_scroll_spd = obj_cam.pos.x - obj_cam.prev_pos.x;
            }
            else
            {
                AppMain.gm_boss4_f_scroll_spd = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.move.x );
            }
            AppMain.gm_boss4_n_scroll_pt_x = ( int )( obj_cam.pos.x + AppMain.gm_boss4_f_scroll_spd );
        }
        if ( AppMain.gm_boss4_n_scroll != 0 )
        {
            AppMain.gm_boss4_f_scroll_spd += AppMain.GMD_BOSS4_SCROLL_SPD_ADD;
        }
        else
        {
            AppMain.gm_boss4_f_scroll_spd -= AppMain.GMD_BOSS4_SCROLL_SPD_SUB;
        }
        if ( AppMain.gm_boss4_f_scroll_spd > AppMain.gm_boss4_f_scroll_spd_max )
        {
            AppMain.gm_boss4_f_scroll_spd = AppMain.gm_boss4_f_scroll_spd_max;
        }
        if ( AppMain.gm_boss4_f_scroll_spd < 0f )
        {
            AppMain.gm_boss4_f_scroll_spd = 0f;
        }
        if ( AppMain.gm_boss4_n_scroll == 0 && AppMain.gm_boss4_f_scroll_spd == 0f )
        {
            AppMain.g_gm_main_system.map_fcol.left = 0;
            AppMain.g_gm_main_system.map_fcol.right = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 );
            AppMain.ObjCameraSetUserFunc( 0, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.GmCameraFunc ) );
            AppMain.GmGmkCamScrLimitRelease( 14 );
            AppMain.GmBoss4UtilPlayerStop( false );
            return;
        }
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.x );
        nns_VECTOR.y = AppMain.FXM_FX32_TO_FLOAT( -gms_PLAYER_WORK.obj_work.pos.y + 24576 );
        nns_VECTOR.z = AppMain.FXM_FX32_TO_FLOAT( gms_PLAYER_WORK.obj_work.pos.z );
        obj_cam.work.x = nns_VECTOR.x;
        obj_cam.work.y = nns_VECTOR.y;
        obj_cam.work.z = nns_VECTOR.z;
        if ( AppMain.gm_boss4_n_scroll == 0 )
        {
            AppMain.GmBoss4UtilPlayerStop( false );
            int num = (int)AppMain.FX_FX32_TO_F32(gms_PLAYER_WORK.obj_work.pos.x + gms_PLAYER_WORK.obj_work.spd.x);
            if ( ( float )num < ( float )AppMain.gm_boss4_n_scroll_pt_x - obj_cam.allow.x )
            {
                num += ( int )obj_cam.allow.x;
            }
            else if ( ( float )num > ( float )AppMain.gm_boss4_n_scroll_pt_x + obj_cam.allow.x )
            {
                num -= ( int )obj_cam.allow.x;
            }
            else
            {
                num = AppMain.gm_boss4_n_scroll_pt_x;
            }
            AppMain.gm_boss4_n_scroll_pt_x = num;
        }
        bool flag = false;
        if ( obj_cam.pos.x > ( float )AppMain.gm_boss4_n_scroll_pt_x )
        {
            flag = true;
        }
        obj_cam.prev_pos.x = obj_cam.pos.x;
        obj_cam.pos.x = ( float )AppMain.gm_boss4_n_scroll_pt_x;
        obj_cam.disp_pos.x = ( float )AppMain.gm_boss4_n_scroll_pt_x;
        obj_cam.target_pos.x = ( float )AppMain.gm_boss4_n_scroll_pt_x + AppMain.gmCameraForceScrollFuncStatics.ofst;
        AppMain.ObjObjectCameraSet( AppMain.FXM_FLOAT_TO_FX32( obj_cam.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_cam.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( obj_cam.disp_pos.x - ( float )( AppMain.OBD_LCD_X / 2 ) ), AppMain.FXM_FLOAT_TO_FX32( -obj_cam.disp_pos.y - ( float )( AppMain.OBD_LCD_Y / 2 ) ) );
        AppMain.GmCameraSetClipCamera( obj_cam );
        if ( flag && AppMain.g_gs_main_sys_info.stage_id >= 16 )
        {
            if ( AppMain.gm_boss4_n_scroll == 1 || AppMain.gm_boss4_n_scroll == 2 )
            {
                AppMain.GmDecoSetLoopState();
            }
            AppMain.GmEveMgrCreateEventLcd( 0U );
            AppMain.GmDecoClearLoopState();
        }
        AppMain.GmBoss4UtilIterateDamageRingInit();
        AppMain.GMS_RING_WORK gms_RING_WORK;
        if ( AppMain.gmCameraForceScrollFuncStatics._damage_cnt == 0 )
        {
            gms_RING_WORK = AppMain.GmBoss4UtilIterateDamageRingGet();
            if ( gms_RING_WORK != null )
            {
                AppMain.gmCameraForceScrollFuncStatics._damage_cnt++;
                AppMain.GmBoss4UtilIterateDamageRingInit();
                while ( ( gms_RING_WORK = AppMain.GmBoss4UtilIterateDamageRingGet() ) != null )
                {
                    AppMain.GMS_RING_WORK gms_RING_WORK2 = gms_RING_WORK;
                    gms_RING_WORK2.pos.x = gms_RING_WORK2.pos.x + AppMain.GmBoss4GetScrollOffset();
                    gms_RING_WORK.spd_x += AppMain.FX_F32_TO_FX32( 1f );
                }
            }
        }
        else if ( AppMain.GmBoss4UtilIterateDamageRingGet() == null )
        {
            AppMain.gmCameraForceScrollFuncStatics._damage_cnt = 0;
        }
        AppMain.GmBoss4UtilIterateDamageRingInit();
        while ( ( gms_RING_WORK = AppMain.GmBoss4UtilIterateDamageRingGet() ) != null )
        {
            AppMain.GMS_RING_WORK gms_RING_WORK3 = gms_RING_WORK;
            gms_RING_WORK3.pos.x = gms_RING_WORK3.pos.x + AppMain.GmBoss4GetScrollOffset();
            gms_RING_WORK.spd_x += AppMain.FX_F32_TO_FX32( -0.1f );
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GmBsCmnGetPlayerObj();
        AppMain.gmCameraForceScrollFuncStatics.ofst = ( AppMain.AMD_SCREEN_2D_WIDTH / ( float )AppMain.GSD_DISP_WIDTH - 1f ) * ( ( float )( obs_OBJECT_WORK.pos.x / 4096 ) - obj_cam.pos.x ) / 30f;
        bool enable = false;
        if ( AppMain.gm_boss4_n_scroll == 1 || AppMain.gm_boss4_n_scroll == 2 )
        {
            enable = true;
        }
        else
        {
            AppMain.GmDecoEndLoop();
        }
        float num2 = AppMain.gm_boss4_f_scroll_spd;
        if ( num2 < -100f )
        {
            num2 += ( float )( AppMain.GMD_BOSS4_SCROLL_END_X - AppMain.GMD_BOSS4_SCROLL_START_X );
        }
        if ( AppMain.gm_boss4_n_scroll == 2 )
        {
            if ( gms_PLAYER_WORK.seq_state == 1 )
            {
                AppMain.GmBoss4UtilPlayerStop( true );
            }
            if ( obs_OBJECT_WORK.pos.x > AppMain.FX_F32_TO_FX32( obj_cam.pos.x ) )
            {
                AppMain.GmPlayerSetAutoRun( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, ( int )( ( num2 + 0.6f ) * 4096f ), enable );
            }
            else
            {
                AppMain.GmPlayerSetAutoRun( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, ( int )( ( num2 + 1.4f ) * 4096f ), enable );
            }
        }
        else
        {
            AppMain.GmPlayerSetAutoRun( ( AppMain.GMS_PLAYER_WORK )obs_OBJECT_WORK, ( int )( ( num2 + -0.5f ) * 4096f ), enable );
        }
        AppMain.gm_boss4_n_scroll_pt_x += ( int )AppMain.gm_boss4_f_scroll_spd;
        AppMain.gm_boss4_n_offset_x = ( int )AppMain.gm_boss4_f_scroll_spd;
        if ( AppMain.gm_boss4_b_warpout )
        {
            AppMain.gm_boss4_b_warpout = false;
            int num3 = AppMain.GMD_BOSS4_SCROLL_OUT_X - AppMain.gm_boss4_n_scroll_pt_x;
            AppMain.gm_boss4_n_scroll_pt_x = AppMain.GMD_BOSS4_SCROLL_OUT_X;
            AppMain.gm_boss4_n_offset_x = num3;
        }
        if ( AppMain.gm_boss4_n_scroll_pt_x > AppMain.gm_boss4_n_scroll_end )
        {
            AppMain.gm_boss4_n_offset_x = -( AppMain.gm_boss4_n_scroll_end - AppMain.gm_boss4_n_scroll_start ) + ( int )AppMain.gm_boss4_f_scroll_spd;
            AppMain.gm_boss4_n_scroll_pt_x -= AppMain.gm_boss4_n_scroll_end - AppMain.gm_boss4_n_scroll_start;
        }
        AppMain.g_gm_main_system.map_fcol.left = AppMain.gm_boss4_n_scroll_pt_x - ( int )( AppMain.AMD_SCREEN_2D_WIDTH / 2f * 0.67438334f ) - 48;
        AppMain.g_gm_main_system.map_fcol.right = AppMain.gm_boss4_n_scroll_pt_x + ( int )( AppMain.AMD_SCREEN_2D_WIDTH / 2f * 0.67438334f );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x06000EDB RID: 3803 RVA: 0x00083DFC File Offset: 0x00081FFC
    private static AppMain.OBS_OBJECT_WORK GmBoss4ScrollInit( AppMain.GMS_EVE_RECORD_EVENT eve_rec, int pos_x, int pos_y, byte type )
    {
        AppMain.UNREFERENCED_PARAMETER( type );
        AppMain.UNREFERENCED_PARAMETER( pos_x );
        AppMain.UNREFERENCED_PARAMETER( pos_y );
        AppMain.UNREFERENCED_PARAMETER( eve_rec );
        AppMain.gm_boss4_n_scroll = 1;
        AppMain.gm_boss4_f_scroll_spd = AppMain.GMD_BOSS4_SCROLL_SPD_START;
        AppMain.gm_boss4_f_scroll_spd = -100f;
        AppMain.gm_boss4_n_scroll_pt_x = 0;
        AppMain.ObjCameraSetUserFunc( 0, new AppMain.OBJF_CAMERA_USER_FUNC( AppMain.gmCameraForceScrollFunc ) );
        AppMain.gm_boss4_is_2nd = true;
        return null;
    }

    // Token: 0x06000EDC RID: 3804 RVA: 0x00083E69 File Offset: 0x00082069
    private static void GmBoss4ScrollNext()
    {
        if ( AppMain.gm_boss4_n_scroll == 1 )
        {
            AppMain.gm_boss4_n_scroll = 2;
        }
        else if ( AppMain.gm_boss4_n_scroll == 2 )
        {
            AppMain.gm_boss4_n_scroll = 0;
        }
        AppMain.gm_boss4_n_offset_x = 0;
    }

    // Token: 0x06000EDD RID: 3805 RVA: 0x00083E8F File Offset: 0x0008208F
    private static void GmBoss4ScrollOff()
    {
        AppMain.gm_boss4_n_scroll = 0;
        AppMain.gm_boss4_n_offset_x = 0;
        AppMain.gm_boss4_f_scroll_spd = 0f;
        AppMain.gm_boss4_b_warpout = false;
    }

    // Token: 0x06000EDE RID: 3806 RVA: 0x00083EAD File Offset: 0x000820AD
    private static void GmBoss4ScrollOut()
    {
        AppMain.gm_boss4_b_warpout = true;
    }

    // Token: 0x06000EDF RID: 3807 RVA: 0x00083EB5 File Offset: 0x000820B5
    private static bool GmBoss4Is2ndStage()
    {
        return AppMain.gm_boss4_is_2nd;
    }

    // Token: 0x06000EE0 RID: 3808 RVA: 0x00083EBC File Offset: 0x000820BC
    private static bool GmBoss4CheckBossRush()
    {
        return AppMain.gm_boss4_mgr_work != null && 0 != AppMain.GmBsCmnIsFinalZoneType( AppMain.gm_boss4_mgr_work.Cast() );
    }

    // Token: 0x06000EE1 RID: 3809 RVA: 0x00083EDC File Offset: 0x000820DC
    private static void GmBoss4IncObjCreateCount()
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work != null );
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work.obj_create_cnt >= 0 );
        AppMain.gm_boss4_mgr_work.obj_create_cnt++;
    }

    // Token: 0x06000EE2 RID: 3810 RVA: 0x00083F15 File Offset: 0x00082115
    private static void GmBoss4DecObjCreateCount()
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work != null );
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work.obj_create_cnt > 0 );
        AppMain.gm_boss4_mgr_work.obj_create_cnt--;
    }

    // Token: 0x06000EE3 RID: 3811 RVA: 0x00083F4B File Offset: 0x0008214B
    private static bool GmBoss4IsAllCreatedObjDeleted()
    {
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work != null );
        AppMain.MTM_ASSERT( AppMain.gm_boss4_mgr_work.obj_create_cnt >= 0 );
        return AppMain.gm_boss4_mgr_work.obj_create_cnt <= 0;
    }
}