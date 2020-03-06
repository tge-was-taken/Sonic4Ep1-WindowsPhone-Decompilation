using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000031 RID: 49
    private interface IOBS_OBJECT_WORK
    {
        // Token: 0x06001D39 RID: 7481
        AppMain.OBS_OBJECT_WORK Cast();
    }

    // Token: 0x02000362 RID: 866
    // (Invoke) Token: 0x06002610 RID: 9744
    public delegate void OBS_OBJECT_WORK_Delegate2( object o1, object o2, uint u );

    // Token: 0x02000363 RID: 867
    // (Invoke) Token: 0x06002614 RID: 9748
    public delegate int OBS_OBJECT_WORK_Delegate3( AppMain.OBS_OBJECT_WORK objectWork );

    // Token: 0x02000364 RID: 868
    // (Invoke) Token: 0x06002618 RID: 9752
    public delegate bool OBS_OBJECT_WORK_Delegate4( AppMain.OBS_OBJECT_WORK objectWork );

    // Token: 0x02000365 RID: 869
    public class OBS_OBJECT_WORK : AppMain.IClearable
    {
        // Token: 0x0600261B RID: 9755 RVA: 0x0014EA7C File Offset: 0x0014CC7C
        public OBS_OBJECT_WORK()
        {
        }

        // Token: 0x0600261C RID: 9756 RVA: 0x0014EB4F File Offset: 0x0014CD4F
        private OBS_OBJECT_WORK( object _holder ) : this( _holder, null )
        {
        }

        // Token: 0x0600261D RID: 9757 RVA: 0x0014EB5C File Offset: 0x0014CD5C
        private OBS_OBJECT_WORK( object _holder, object _primaryHolder )
        {
            this.holder = _holder;
            this.m_primaryHolder = _primaryHolder;
        }

        // Token: 0x0600261E RID: 9758 RVA: 0x0014EC3D File Offset: 0x0014CE3D
        public static AppMain.OBS_OBJECT_WORK Create()
        {
            return new AppMain.OBS_OBJECT_WORK();
        }

        // Token: 0x0600261F RID: 9759 RVA: 0x0014EC44 File Offset: 0x0014CE44
        public static AppMain.OBS_OBJECT_WORK Create( object _holder )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBS_OBJECT_WORK.Create();
            obs_OBJECT_WORK.holder = _holder;
            obs_OBJECT_WORK.m_primaryHolder = null;
            return obs_OBJECT_WORK;
        }

        // Token: 0x06002620 RID: 9760 RVA: 0x0014EC68 File Offset: 0x0014CE68
        public static AppMain.OBS_OBJECT_WORK Create( object _holder, object _primaryHolder )
        {
            AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.OBS_OBJECT_WORK.Create();
            obs_OBJECT_WORK.holder = _holder;
            obs_OBJECT_WORK.m_primaryHolder = _primaryHolder;
            return obs_OBJECT_WORK;
        }

        // Token: 0x06002621 RID: 9761 RVA: 0x0014EC8A File Offset: 0x0014CE8A
        public static explicit operator AppMain.GMS_GMK_WATER_SLIDER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_WATER_SLIDER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002622 RID: 9762 RVA: 0x0014EC97 File Offset: 0x0014CE97
        public static explicit operator AppMain.GMS_GMK_UPBUMPER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_UPBUMPER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002623 RID: 9763 RVA: 0x0014ECA4 File Offset: 0x0014CEA4
        public static explicit operator AppMain.GMS_GMK_STEAMP_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_STEAMP_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002624 RID: 9764 RVA: 0x0014ECB1 File Offset: 0x0014CEB1
        public static explicit operator AppMain.GMS_GMK_PWALL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PWALL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002625 RID: 9765 RVA: 0x0014ECBE File Offset: 0x0014CEBE
        public static explicit operator AppMain.GMS_GMK_SEESAWPARTS_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SEESAWPARTS_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x06002626 RID: 9766 RVA: 0x0014ECCB File Offset: 0x0014CECB
        public static explicit operator AppMain.GMS_GMK_PRESSWALL_PARTS( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PRESSWALL_PARTS )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x06002627 RID: 9767 RVA: 0x0014ECD8 File Offset: 0x0014CED8
        public static explicit operator AppMain.GMS_GMK_PWALLCTRL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PWALLCTRL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002628 RID: 9768 RVA: 0x0014ECE5 File Offset: 0x0014CEE5
        public static explicit operator AppMain.GMS_GMK_SEESAW_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SEESAW_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002629 RID: 9769 RVA: 0x0014ECF2 File Offset: 0x0014CEF2
        public static explicit operator AppMain.GMS_GMK_SHUTTER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SHUTTER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600262A RID: 9770 RVA: 0x0014ECFF File Offset: 0x0014CEFF
        public static explicit operator AppMain.GMS_GMK_P_STEAM_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_P_STEAM_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600262B RID: 9771 RVA: 0x0014ED0C File Offset: 0x0014CF0C
        public static explicit operator AppMain.GMS_GMK_PISTONROD_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PISTONROD_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x0600262C RID: 9772 RVA: 0x0014ED19 File Offset: 0x0014CF19
        public static explicit operator AppMain.GMS_GMK_PISTON_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PISTON_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600262D RID: 9773 RVA: 0x0014ED26 File Offset: 0x0014CF26
        public static explicit operator AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600262E RID: 9774 RVA: 0x0014ED33 File Offset: 0x0014CF33
        public static explicit operator AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600262F RID: 9775 RVA: 0x0014ED40 File Offset: 0x0014CF40
        public static explicit operator AppMain.GMS_BOSS5_LAND_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_LAND_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002630 RID: 9776 RVA: 0x0014ED4D File Offset: 0x0014CF4D
        public static explicit operator AppMain.GMS_BOSS5_CTPLT_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_CTPLT_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002631 RID: 9777 RVA: 0x0014ED5A File Offset: 0x0014CF5A
        public static explicit operator AppMain.GMS_BOSS5_ROCKET_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_ROCKET_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002632 RID: 9778 RVA: 0x0014ED67 File Offset: 0x0014CF67
        public static explicit operator AppMain.GMS_BOSS5_MGR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_MGR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002633 RID: 9779 RVA: 0x0014ED74 File Offset: 0x0014CF74
        public static explicit operator AppMain.GMS_BOSS5_BODY_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_BODY_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002634 RID: 9780 RVA: 0x0014ED81 File Offset: 0x0014CF81
        public static explicit operator AppMain.GMS_BOSS4_BODY_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS4_BODY_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002635 RID: 9781 RVA: 0x0014ED8E File Offset: 0x0014CF8E
        public static explicit operator AppMain.GMS_BOSS4_CAP_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS4_CAP_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002636 RID: 9782 RVA: 0x0014ED9B File Offset: 0x0014CF9B
        public static explicit operator AppMain.GMS_BOSS4_CHIBI_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS4_CHIBI_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002637 RID: 9783 RVA: 0x0014EDA8 File Offset: 0x0014CFA8
        public static explicit operator AppMain.GMS_BOSS4_EGG_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS4_EGG_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002638 RID: 9784 RVA: 0x0014EDB5 File Offset: 0x0014CFB5
        public static explicit operator AppMain.GMS_BOSS4_MGR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS4_MGR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002639 RID: 9785 RVA: 0x0014EDC2 File Offset: 0x0014CFC2
        public static explicit operator AppMain.GMS_GMK_TRUCK_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_TRUCK_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600263A RID: 9786 RVA: 0x0014EDCF File Offset: 0x0014CFCF
        public static explicit operator AppMain.GMS_BOSS2_BALL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS2_BALL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600263B RID: 9787 RVA: 0x0014EDDC File Offset: 0x0014CFDC
        public static explicit operator AppMain.GMS_BOSS2_EGG_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS2_EGG_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600263C RID: 9788 RVA: 0x0014EDE9 File Offset: 0x0014CFE9
        public static explicit operator AppMain.GMS_BOSS2_BODY_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS2_BODY_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600263D RID: 9789 RVA: 0x0014EDF6 File Offset: 0x0014CFF6
        public static explicit operator AppMain.GMS_BOSS2_MGR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS2_MGR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600263E RID: 9790 RVA: 0x0014EE03 File Offset: 0x0014D003
        public static explicit operator AppMain.GMS_BOSS3_EGG_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS3_EGG_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600263F RID: 9791 RVA: 0x0014EE10 File Offset: 0x0014D010
        public static explicit operator AppMain.GMS_BOSS3_BODY_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS3_BODY_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002640 RID: 9792 RVA: 0x0014EE1D File Offset: 0x0014D01D
        public static explicit operator AppMain.GMS_BOSS3_MGR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS3_MGR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002641 RID: 9793 RVA: 0x0014EE2A File Offset: 0x0014D02A
        public static explicit operator AppMain.GMS_ENE_UNIDES_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_UNIDES_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002642 RID: 9794 RVA: 0x0014EE37 File Offset: 0x0014D037
        public static explicit operator AppMain.GMS_ENE_UNIUNI_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_UNIUNI_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002643 RID: 9795 RVA: 0x0014EE44 File Offset: 0x0014D044
        public static explicit operator AppMain.GMS_ENE_BUKU_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_BUKU_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002644 RID: 9796 RVA: 0x0014EE51 File Offset: 0x0014D051
        public static explicit operator AppMain.GMS_ENE_T_STAR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_T_STAR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002645 RID: 9797 RVA: 0x0014EE5E File Offset: 0x0014D05E
        public static explicit operator AppMain.GMS_ENE_KANI_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_KANI_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002646 RID: 9798 RVA: 0x0014EE6B File Offset: 0x0014D06B
        public static explicit operator AppMain.GMS_ENE_KAMA_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_KAMA_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002647 RID: 9799 RVA: 0x0014EE78 File Offset: 0x0014D078
        public static explicit operator AppMain.GMS_ENE_MOGU_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_MOGU_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002648 RID: 9800 RVA: 0x0014EE85 File Offset: 0x0014D085
        public static explicit operator AppMain.GMS_PLAYER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            if ( p == null )
            {
                return null;
            }
            return ( AppMain.GMS_PLAYER_WORK )p.holder;
        }

        // Token: 0x06002649 RID: 9801 RVA: 0x0014EE97 File Offset: 0x0014D097
        public static explicit operator AppMain.GMS_GMK_SPCTPLT_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SPCTPLT_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600264A RID: 9802 RVA: 0x0014EEA4 File Offset: 0x0014D0A4
        public static explicit operator AppMain.GMS_GMK_SLOT_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SLOT_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600264B RID: 9803 RVA: 0x0014EEB1 File Offset: 0x0014D0B1
        public static explicit operator AppMain.GMS_GMK_CANNONPARTS_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_CANNONPARTS_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x0600264C RID: 9804 RVA: 0x0014EEBE File Offset: 0x0014D0BE
        public static explicit operator AppMain.GMS_BOSS5_LDPART_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_LDPART_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x0600264D RID: 9805 RVA: 0x0014EECB File Offset: 0x0014D0CB
        public static explicit operator AppMain.GMS_GMK_SLOTPARTS_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SLOTPARTS_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x0600264E RID: 9806 RVA: 0x0014EED8 File Offset: 0x0014D0D8
        public static explicit operator AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_EFF_SHOCKWAVE_SUB_WORK )( ( AppMain.GMS_EFFECT_3DES_WORK )p );
        }

        // Token: 0x0600264F RID: 9807 RVA: 0x0014EEE5 File Offset: 0x0014D0E5
        public static explicit operator AppMain.GMS_BOSS5_EFCT_GENERAL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_EFCT_GENERAL_WORK )( ( AppMain.GMS_EFFECT_3DES_WORK )p );
        }

        // Token: 0x06002650 RID: 9808 RVA: 0x0014EEF2 File Offset: 0x0014D0F2
        public static explicit operator AppMain.GMS_BOSS4_EFF_COMMON_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS4_EFF_COMMON_WORK )( ( AppMain.GMS_EFFECT_3DES_WORK )p );
        }

        // Token: 0x06002651 RID: 9809 RVA: 0x0014EEFF File Offset: 0x0014D0FF
        public static explicit operator AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_EFF_SHOCKWAVE_WORK )( ( AppMain.GMS_EFFECT_3DES_WORK )p );
        }

        // Token: 0x06002652 RID: 9810 RVA: 0x0014EF0C File Offset: 0x0014D10C
        public static explicit operator AppMain.GMS_GMK_POPSTEAMPARTS_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_POPSTEAMPARTS_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )p );
        }

        // Token: 0x06002653 RID: 9811 RVA: 0x0014EF19 File Offset: 0x0014D119
        public static explicit operator AppMain.GMS_BOSS1_FLASH_SCREEN_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_FLASH_SCREEN_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )p );
        }

        // Token: 0x06002654 RID: 9812 RVA: 0x0014EF26 File Offset: 0x0014D126
        public static explicit operator AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BS_CMN_NODE_CTRL_OBJECT )( ( AppMain.GMS_EFFECT_COM_WORK )p );
        }

        // Token: 0x06002655 RID: 9813 RVA: 0x0014EF33 File Offset: 0x0014D133
        public static explicit operator AppMain.GMS_ENE_HARO_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_HARO_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002656 RID: 9814 RVA: 0x0014EF40 File Offset: 0x0014D140
        public static explicit operator AppMain.GMS_GMK_STOPPER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_STOPPER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002657 RID: 9815 RVA: 0x0014EF4D File Offset: 0x0014D14D
        public static explicit operator AppMain.GMS_BOSS1_CHAIN_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_CHAIN_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002658 RID: 9816 RVA: 0x0014EF5A File Offset: 0x0014D15A
        public static explicit operator AppMain.GMS_ENE_GARDON_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_GARDON_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002659 RID: 9817 RVA: 0x0014EF67 File Offset: 0x0014D167
        public static explicit operator AppMain.GMS_GMK_BUMPER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BUMPER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600265A RID: 9818 RVA: 0x0014EF74 File Offset: 0x0014D174
        public static explicit operator AppMain.GMS_BOSS1_EGG_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_EGG_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600265B RID: 9819 RVA: 0x0014EF81 File Offset: 0x0014D181
        public static explicit operator AppMain.GMS_BOSS1_MGR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_MGR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600265C RID: 9820 RVA: 0x0014EF8E File Offset: 0x0014D18E
        public static explicit operator AppMain.GMS_BOSS1_BODY_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS1_BODY_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600265D RID: 9821 RVA: 0x0014EF9B File Offset: 0x0014D19B
        public static explicit operator AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600265E RID: 9822 RVA: 0x0014EFA8 File Offset: 0x0014D1A8
        public static explicit operator AppMain.GMS_GMK_BLAND_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BLAND_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600265F RID: 9823 RVA: 0x0014EFB5 File Offset: 0x0014D1B5
        public static explicit operator AppMain.GMS_GMK_BWALL_PARTS( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BWALL_PARTS )( ( AppMain.GMS_EFFECT_3DNN_WORK )p );
        }

        // Token: 0x06002660 RID: 9824 RVA: 0x0014EFC2 File Offset: 0x0014D1C2
        public static explicit operator AppMain.GMS_GMK_BWALL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BWALL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p.m_primaryHolder ).holder;
        }

        // Token: 0x06002661 RID: 9825 RVA: 0x0014EFD9 File Offset: 0x0014D1D9
        public static explicit operator AppMain.GMS_GMK_SW_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_SW_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p.m_primaryHolder ).holder;
        }

        // Token: 0x06002662 RID: 9826 RVA: 0x0014EFF0 File Offset: 0x0014D1F0
        public static explicit operator AppMain.GMS_GMK_PMARKER_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PMARKER_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p.m_primaryHolder );
        }

        // Token: 0x06002663 RID: 9827 RVA: 0x0014F002 File Offset: 0x0014D202
        public static explicit operator AppMain.GMS_EFFECT_3DNN_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_EFFECT_3DNN_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )p.holder ).holder;
        }

        // Token: 0x06002664 RID: 9828 RVA: 0x0014F019 File Offset: 0x0014D219
        public static explicit operator AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_CAM_SCR_LIMIT_WORK )p.m_primaryHolder;
        }

        // Token: 0x06002665 RID: 9829 RVA: 0x0014F026 File Offset: 0x0014D226
        public static explicit operator AppMain.GMS_ENE_STING_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_STING_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x06002666 RID: 9830 RVA: 0x0014F033 File Offset: 0x0014D233
        public static explicit operator AppMain.GMS_BOSS5_EGG_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_EGG_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p.m_primaryHolder );
        }

        // Token: 0x06002667 RID: 9831 RVA: 0x0014F045 File Offset: 0x0014D245
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p );
        }

        // Token: 0x06002668 RID: 9832 RVA: 0x0014F052 File Offset: 0x0014D252
        public static explicit operator AppMain.GMS_DECO_SUBMODEL_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_DECO_SUBMODEL_WORK )( ( AppMain.GMS_DECO_WORK )p.holder );
        }

        // Token: 0x06002669 RID: 9833 RVA: 0x0014F064 File Offset: 0x0014D264
        public static explicit operator AppMain.GMS_DECO_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_DECO_WORK )p.holder;
        }

        // Token: 0x0600266A RID: 9834 RVA: 0x0014F071 File Offset: 0x0014D271
        public static explicit operator AppMain.GMS_BOSS5_CORE_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_CORE_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p );
        }

        // Token: 0x0600266B RID: 9835 RVA: 0x0014F07E File Offset: 0x0014D27E
        public static explicit operator AppMain.GMS_ENEMY_COM_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            if ( p == null )
            {
                return null;
            }
            return ( AppMain.GMS_ENEMY_COM_WORK )p.holder;
        }

        // Token: 0x0600266C RID: 9836 RVA: 0x0014F090 File Offset: 0x0014D290
        public static explicit operator AppMain.GMS_SCORE_DISP_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_SCORE_DISP_WORK )p.holder;
        }

        // Token: 0x0600266D RID: 9837 RVA: 0x0014F09D File Offset: 0x0014D29D
        public static explicit operator AppMain.GMS_GMK_CANNON_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_CANNON_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600266E RID: 9838 RVA: 0x0014F0AA File Offset: 0x0014D2AA
        public static explicit operator AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600266F RID: 9839 RVA: 0x0014F0B7 File Offset: 0x0014D2B7
        public static explicit operator AppMain.GMS_BOSS5_TURRET_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_BOSS5_TURRET_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p.holder ).holder ).holder;
        }

        // Token: 0x06002670 RID: 9840 RVA: 0x0014F0D8 File Offset: 0x0014D2D8
        public static explicit operator AppMain.GMS_ENE_HARI_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_HARI_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p.holder ).holder ).holder;
        }

        // Token: 0x06002671 RID: 9841 RVA: 0x0014F0F9 File Offset: 0x0014D2F9
        public static explicit operator AppMain.GMS_GMK_PULLEY_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_PULLEY_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p.holder ).holder ).holder;
        }

        // Token: 0x06002672 RID: 9842 RVA: 0x0014F11A File Offset: 0x0014D31A
        public static explicit operator AppMain.GMS_ENE_MOTORA_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_ENE_MOTORA_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p.holder ).holder ).holder;
        }

        // Token: 0x06002673 RID: 9843 RVA: 0x0014F13B File Offset: 0x0014D33B
        public static explicit operator AppMain.GMS_GMK_BOBJ_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BOBJ_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )p.holder ).holder ).holder;
        }

        // Token: 0x06002674 RID: 9844 RVA: 0x0014F15C File Offset: 0x0014D35C
        public static explicit operator AppMain.GMS_GMK_BOBJ_PARTS( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BOBJ_PARTS )( ( AppMain.GMS_EFFECT_3DNN_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )p.holder ).holder ).holder;
        }

        // Token: 0x06002675 RID: 9845 RVA: 0x0014F17D File Offset: 0x0014D37D
        public static explicit operator AppMain.GMS_EFFECT_3DES_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_EFFECT_3DES_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )work.holder );
        }

        // Token: 0x06002676 RID: 9846 RVA: 0x0014F18F File Offset: 0x0014D38F
        public static explicit operator AppMain.DMS_STFRL_BOSS_BODY_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_STFRL_BOSS_BODY_WORK )work.holder;
        }

        // Token: 0x06002677 RID: 9847 RVA: 0x0014F19C File Offset: 0x0014D39C
        public static explicit operator AppMain.DMS_STFRL_BOSS_EGG_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_STFRL_BOSS_EGG_WORK )work.holder;
        }

        // Token: 0x06002678 RID: 9848 RVA: 0x0014F1A9 File Offset: 0x0014D3A9
        public static explicit operator AppMain.DMS_STFRL_RING_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_STFRL_RING_WORK )work.holder;
        }

        // Token: 0x06002679 RID: 9849 RVA: 0x0014F1B6 File Offset: 0x0014D3B6
        public static explicit operator AppMain.DMS_STFRL_SONIC_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.DMS_STFRL_SONIC_WORK )work.holder;
        }

        // Token: 0x0600267A RID: 9850 RVA: 0x0014F1C3 File Offset: 0x0014D3C3
        public static explicit operator AppMain.GMS_FADE_OBJ_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_FADE_OBJ_WORK )work.holder;
        }

        // Token: 0x0600267B RID: 9851 RVA: 0x0014F1D0 File Offset: 0x0014D3D0
        public static explicit operator AppMain.GMS_SMSG_2D_OBJ_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_SMSG_2D_OBJ_WORK )work.holder;
        }

        // Token: 0x0600267C RID: 9852 RVA: 0x0014F1DD File Offset: 0x0014D3DD
        public static explicit operator AppMain.GMS_GMK_GEAR_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_GEAR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600267D RID: 9853 RVA: 0x0014F1EA File Offset: 0x0014D3EA
        public static explicit operator AppMain.GMS_GMK_BELTC_WORK( AppMain.OBS_OBJECT_WORK p )
        {
            return ( AppMain.GMS_GMK_BELTC_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p );
        }

        // Token: 0x0600267E RID: 9854 RVA: 0x0014F1F7 File Offset: 0x0014D3F7
        public static explicit operator AppMain.GMS_GMK_ROCK_FALL_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_FALL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x0600267F RID: 9855 RVA: 0x0014F218 File Offset: 0x0014D418
        public static explicit operator AppMain.GMS_GMK_ROCK_FALL_MGR_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_FALL_MGR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x06002680 RID: 9856 RVA: 0x0014F239 File Offset: 0x0014D439
        public static explicit operator AppMain.GMS_BOSS5_ALARM_FADE_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_BOSS5_ALARM_FADE_WORK )( ( AppMain.GMS_FADE_OBJ_WORK )work.holder );
        }

        // Token: 0x06002681 RID: 9857 RVA: 0x0014F24B File Offset: 0x0014D44B
        public static explicit operator AppMain.GMS_BOSS5_FLASH_SCREEN_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_BOSS5_FLASH_SCREEN_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )work.holder );
        }

        // Token: 0x06002682 RID: 9858 RVA: 0x0014F25D File Offset: 0x0014D45D
        public static explicit operator AppMain.GMS_GMK_ROCK_CHASE_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_CHASE_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x06002683 RID: 9859 RVA: 0x0014F27E File Offset: 0x0014D47E
        public static explicit operator AppMain.GMS_GMK_SPEARPARTS_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_SPEARPARTS_WORK )( ( AppMain.GMS_EFFECT_3DNN_WORK )( ( AppMain.GMS_EFFECT_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x06002684 RID: 9860 RVA: 0x0014F29F File Offset: 0x0014D49F
        public static explicit operator AppMain.GMS_GMK_SPEAR_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_SPEAR_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x06002685 RID: 9861 RVA: 0x0014F2C0 File Offset: 0x0014D4C0
        public static explicit operator AppMain.GMS_GMK_ROCK_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x06002686 RID: 9862 RVA: 0x0014F2E1 File Offset: 0x0014D4E1
        public static explicit operator AppMain.GMS_GMK_SWWALL_WORK( AppMain.OBS_OBJECT_WORK work )
        {
            return ( AppMain.GMS_GMK_SWWALL_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )( ( AppMain.GMS_ENEMY_COM_WORK )work.holder ).holder ).holder;
        }

        // Token: 0x06002687 RID: 9863 RVA: 0x0014F304 File Offset: 0x0014D504
        public void Clear()
        {
            this.prev = ( this.next = ( this.draw_prev = ( this.draw_next = null ) ) );
            this.tcb = null;
            this.pause_level = 0;
            this.obj_type = 0;
            this.vib_timer = ( this.hitstop_timer = ( this.invincible_timer = 0 ) );
            this.view_out_ofst = 0;
            Array.Clear( this.view_out_ofst_plus, 0, this.view_out_ofst_plus.Length );
            this.user_work_OBJECT = null;
            this.user_flag_OBJECT = null;
            this.flag = 0U;
            this.move_flag = 0U;
            this.disp_flag = 0U;
            this.gmk_flag = 0U;
            this.sys_flag = 0U;
            this.user_timer = 0;
            this.dir.Clear();
            this.scale.Clear();
            this.pos.Clear();
            this.ofst.Clear();
            this.prev_ofst.Clear();
            this.parent_ofst.Clear();
            this.lock_obj = null;
            this.prev_pos.Clear();
            this.spd.Clear();
            this.spd_add.Clear();
            this.flow.Clear();
            this.move.Clear();
            this.spd_m = 0;
            this.dir_slope = ( this.dir_fall = 0 );
            this.spd_slope = ( this.spd_slope_max = ( this.spd_fall = ( this.spd_fall_max = ( this.push_max = 0 ) ) ) );
            this.col_flag = ( this.col_flag_prev = 0U );
            Array.Clear( this.field_rect, 0, this.field_rect.Length );
            this.field_ajst_w_db_f = ( this.field_ajst_w_db_b = ( this.field_ajst_w_dl_f = ( this.field_ajst_w_dl_b = 0 ) ) );
            this.field_ajst_w_dt_f = ( this.field_ajst_w_dt_b = ( this.field_ajst_w_dr_f = ( this.field_ajst_w_dr_b = 0 ) ) );
            this.field_ajst_h_db_r = ( this.field_ajst_h_db_l = ( this.field_ajst_h_dl_r = ( this.field_ajst_h_dl_l = 0 ) ) );
            this.field_ajst_h_dt_r = ( this.field_ajst_h_dt_l = ( this.field_ajst_h_dr_r = ( this.field_ajst_h_dr_l = 0 ) ) );
            this.ppFunc = ( this.ppIn = ( this.ppOut = ( this.ppOutSub = ( this.ppMove = null ) ) ) );
            this.ppActCall = null;
            this.ppRec = ( this.ppLast = ( this.ppCol = null ) );
            this.ppViewCheck = null;
            this.ppUserRelease = this.ppUserReleaseWait;
            this.ride_obj = ( this.touch_obj = ( this.lock_obj = ( this.locker_obj = null ) ) );
            this.parent_obj = null;
            this.ex_work = null;
            this.obj_3d = null;
            this.obj_3des = null;
            this.obj_2d = null;
            this.col_work = null;
            this.tbl_work = null;
            this.temp_ofst.Clear();
            this.prev_temp_ofst.Clear();
            this.rect_num = 0U;
            this.rect_work = null;
        }

        // Token: 0x170000BB RID: 187
        // (get) Token: 0x06002688 RID: 9864 RVA: 0x0014F634 File Offset: 0x0014D834
        // (set) Token: 0x06002689 RID: 9865 RVA: 0x0014F660 File Offset: 0x0014D860
        public uint user_flag
        {
            get
            {
                if ( this.__user_flag != null )
                {
                    return Convert.ToUInt32( ( this.__user_flag is ValueType ) ? this.__user_flag : 1 );
                }
                return 0U;
            }
            set
            {
                this.__user_flag = value;
            }
        }

        // Token: 0x170000BC RID: 188
        // (get) Token: 0x0600268A RID: 9866 RVA: 0x0014F66E File Offset: 0x0014D86E
        // (set) Token: 0x0600268B RID: 9867 RVA: 0x0014F67B File Offset: 0x0014D87B
        public uint user_work
        {
            get
            {
                return Convert.ToUInt32( this.__user_work );
            }
            set
            {
                this.__user_work = value;
            }
        }

        // Token: 0x170000BD RID: 189
        // (get) Token: 0x0600268C RID: 9868 RVA: 0x0014F689 File Offset: 0x0014D889
        // (set) Token: 0x0600268D RID: 9869 RVA: 0x0014F691 File Offset: 0x0014D891
        public object user_flag_OBJECT
        {
            get
            {
                return this.__user_flag;
            }
            set
            {
                this.__user_flag = value;
            }
        }

        // Token: 0x170000BE RID: 190
        // (get) Token: 0x0600268E RID: 9870 RVA: 0x0014F69A File Offset: 0x0014D89A
        // (set) Token: 0x0600268F RID: 9871 RVA: 0x0014F6A2 File Offset: 0x0014D8A2
        public object user_work_OBJECT
        {
            get
            {
                return this.__user_work;
            }
            set
            {
                this.__user_work = value;
            }
        }

        // Token: 0x06002690 RID: 9872 RVA: 0x0014F6AC File Offset: 0x0014D8AC
        public AppMain.OBS_OBJECT_WORK Assign( AppMain.OBS_OBJECT_WORK objectWork )
        {
            if ( this != objectWork )
            {
                this.prev = objectWork.prev;
                this.next = objectWork.next;
                this.draw_prev = objectWork.draw_prev;
                this.draw_next = objectWork.draw_next;
                this.tcb = objectWork.tcb;
                this.pause_level = objectWork.pause_level;
                this.obj_type = objectWork.obj_type;
                this.vib_timer = objectWork.vib_timer;
                this.hitstop_timer = objectWork.hitstop_timer;
                this.invincible_timer = objectWork.invincible_timer;
                this.view_out_ofst = objectWork.view_out_ofst;
                for ( int i = 0; i < this.view_out_ofst_plus.Length; i++ )
                {
                    this.view_out_ofst_plus[i] = objectWork.view_out_ofst_plus[i];
                }
                this.flag = objectWork.flag;
                this.move_flag = objectWork.move_flag;
                this.disp_flag = objectWork.disp_flag;
                this.gmk_flag = objectWork.gmk_flag;
                this.sys_flag = objectWork.sys_flag;
                this.user_flag = objectWork.user_flag;
                this.user_work = objectWork.user_work;
                this.user_timer = objectWork.user_timer;
                this.dir.Assign( objectWork.dir );
                this.scale.Assign( objectWork.scale );
                this.pos.Assign( objectWork.pos );
                this.ofst.Assign( objectWork.ofst );
                this.prev_ofst.Assign( objectWork.prev_ofst );
                this.parent_ofst.Assign( objectWork.parent_ofst );
                this.lock_ofst.Assign( objectWork.lock_ofst );
                this.prev_pos.Assign( objectWork.prev_pos );
                this.spd.Assign( objectWork.spd );
                this.spd_add.Assign( objectWork.spd_add );
                this.flow.Assign( objectWork.flow );
                this.move.Assign( objectWork.move );
                this.spd_m = objectWork.spd_m;
                this.dir_slope = objectWork.dir_slope;
                this.dir_fall = objectWork.dir_fall;
                this.spd_slope = objectWork.spd_slope;
                this.spd_slope_max = objectWork.spd_slope_max;
                this.spd_fall = objectWork.spd_fall;
                this.spd_fall_max = objectWork.spd_fall_max;
                this.push_max = objectWork.push_max;
                this.col_flag = objectWork.col_flag;
                this.col_flag_prev = objectWork.col_flag_prev;
                for ( int j = 0; j < this.field_rect.Length; j++ )
                {
                    this.field_rect[j] = objectWork.field_rect[j];
                }
                this.field_ajst_w_db_f = objectWork.field_ajst_w_db_f;
                this.field_ajst_w_db_b = objectWork.field_ajst_w_db_b;
                this.field_ajst_w_dl_f = objectWork.field_ajst_w_dl_f;
                this.field_ajst_w_dl_b = objectWork.field_ajst_w_dl_b;
                this.field_ajst_w_dt_f = objectWork.field_ajst_w_dt_f;
                this.field_ajst_w_dt_b = objectWork.field_ajst_w_dt_b;
                this.field_ajst_w_dr_f = objectWork.field_ajst_w_dr_f;
                this.field_ajst_w_dr_b = objectWork.field_ajst_w_dr_b;
                this.field_ajst_h_db_r = objectWork.field_ajst_h_db_r;
                this.field_ajst_h_db_l = objectWork.field_ajst_h_db_l;
                this.field_ajst_h_dl_r = objectWork.field_ajst_h_dl_r;
                this.field_ajst_h_dl_l = objectWork.field_ajst_h_dl_l;
                this.field_ajst_h_dt_r = objectWork.field_ajst_h_dt_r;
                this.field_ajst_h_dt_l = objectWork.field_ajst_h_dt_l;
                this.field_ajst_h_dr_r = objectWork.field_ajst_h_dr_r;
                this.field_ajst_h_dr_l = objectWork.field_ajst_h_dr_l;
                this.ppFunc = objectWork.ppFunc;
                this.ppIn = objectWork.ppIn;
                this.ppOut = objectWork.ppOut;
                this.ppOutSub = objectWork.ppOutSub;
                this.ppMove = objectWork.ppMove;
                this.ppActCall = objectWork.ppActCall;
                this.ppRec = objectWork.ppRec;
                this.ppLast = objectWork.ppLast;
                this.ppCol = objectWork.ppCol;
                this.ppViewCheck = objectWork.ppViewCheck;
                this.ppUserRelease = objectWork.ppUserRelease;
                this.ppUserReleaseWait = objectWork.ppUserReleaseWait;
                this.ride_obj = objectWork.ride_obj;
                this.touch_obj = objectWork.touch_obj;
                this.parent_obj = objectWork.parent_obj;
                this.lock_obj = objectWork.lock_obj;
                this.locker_obj = objectWork.locker_obj;
                this.ex_work = objectWork.ex_work;
                this.obj_3d = objectWork.obj_3d;
                this.obj_3des = objectWork.obj_3des;
                this.obj_2d = objectWork.obj_2d;
                this.col_work = objectWork.col_work;
                this.tbl_work = objectWork.tbl_work;
                this.temp_ofst.Assign( objectWork.temp_ofst );
                this.prev_temp_ofst.Assign( objectWork.prev_temp_ofst );
                this.rect_num = objectWork.rect_num;
                this.rect_work = objectWork.rect_work;
            }
            return this;
        }

        // Token: 0x04005F81 RID: 24449
        public AppMain.OBS_OBJECT_WORK prev;

        // Token: 0x04005F82 RID: 24450
        public AppMain.OBS_OBJECT_WORK next;

        // Token: 0x04005F83 RID: 24451
        public AppMain.OBS_OBJECT_WORK draw_prev;

        // Token: 0x04005F84 RID: 24452
        public AppMain.OBS_OBJECT_WORK draw_next;

        // Token: 0x04005F85 RID: 24453
        public AppMain.MTS_TASK_TCB tcb;

        // Token: 0x04005F86 RID: 24454
        public int pause_level;

        // Token: 0x04005F87 RID: 24455
        public ushort obj_type;

        // Token: 0x04005F88 RID: 24456
        public int vib_timer;

        // Token: 0x04005F89 RID: 24457
        public int hitstop_timer;

        // Token: 0x04005F8A RID: 24458
        public int invincible_timer;

        // Token: 0x04005F8B RID: 24459
        public short view_out_ofst;

        // Token: 0x04005F8C RID: 24460
        public readonly short[] view_out_ofst_plus = new short[4];

        // Token: 0x04005F8D RID: 24461
        public uint flag;

        // Token: 0x04005F8E RID: 24462
        public uint move_flag;

        // Token: 0x04005F8F RID: 24463
        public uint disp_flag;

        // Token: 0x04005F90 RID: 24464
        public uint gmk_flag;

        // Token: 0x04005F91 RID: 24465
        public uint sys_flag;

        // Token: 0x04005F92 RID: 24466
        private object __user_flag;

        // Token: 0x04005F93 RID: 24467
        private object __user_work;

        // Token: 0x04005F94 RID: 24468
        public int user_timer;

        // Token: 0x04005F95 RID: 24469
        public AppMain.VecU16 dir = default(AppMain.VecU16);

        // Token: 0x04005F96 RID: 24470
        public AppMain.VecFx32 scale = default(AppMain.VecFx32);

        // Token: 0x04005F97 RID: 24471
        public AppMain.VecFx32 pos = default(AppMain.VecFx32);

        // Token: 0x04005F98 RID: 24472
        public AppMain.VecFx32 ofst = default(AppMain.VecFx32);

        // Token: 0x04005F99 RID: 24473
        public AppMain.VecFx32 prev_ofst = default(AppMain.VecFx32);

        // Token: 0x04005F9A RID: 24474
        public AppMain.VecFx32 parent_ofst = default(AppMain.VecFx32);

        // Token: 0x04005F9B RID: 24475
        public AppMain.VecFx32 lock_ofst = default(AppMain.VecFx32);

        // Token: 0x04005F9C RID: 24476
        public AppMain.VecFx32 prev_pos = default(AppMain.VecFx32);

        // Token: 0x04005F9D RID: 24477
        public AppMain.VecFx32 spd = default(AppMain.VecFx32);

        // Token: 0x04005F9E RID: 24478
        public AppMain.VecFx32 spd_add = default(AppMain.VecFx32);

        // Token: 0x04005F9F RID: 24479
        public AppMain.VecFx32 flow = default(AppMain.VecFx32);

        // Token: 0x04005FA0 RID: 24480
        public AppMain.VecFx32 move = default(AppMain.VecFx32);

        // Token: 0x04005FA1 RID: 24481
        public int spd_m;

        // Token: 0x04005FA2 RID: 24482
        public ushort dir_slope;

        // Token: 0x04005FA3 RID: 24483
        public ushort dir_fall;

        // Token: 0x04005FA4 RID: 24484
        public int spd_slope;

        // Token: 0x04005FA5 RID: 24485
        public int spd_slope_max;

        // Token: 0x04005FA6 RID: 24486
        public int spd_fall;

        // Token: 0x04005FA7 RID: 24487
        public int spd_fall_max;

        // Token: 0x04005FA8 RID: 24488
        public int push_max;

        // Token: 0x04005FA9 RID: 24489
        public uint col_flag;

        // Token: 0x04005FAA RID: 24490
        public uint col_flag_prev;

        // Token: 0x04005FAB RID: 24491
        public readonly short[] field_rect = new short[4];

        // Token: 0x04005FAC RID: 24492
        public sbyte field_ajst_w_db_f;

        // Token: 0x04005FAD RID: 24493
        public sbyte field_ajst_w_db_b;

        // Token: 0x04005FAE RID: 24494
        public sbyte field_ajst_w_dl_f;

        // Token: 0x04005FAF RID: 24495
        public sbyte field_ajst_w_dl_b;

        // Token: 0x04005FB0 RID: 24496
        public sbyte field_ajst_w_dt_f;

        // Token: 0x04005FB1 RID: 24497
        public sbyte field_ajst_w_dt_b;

        // Token: 0x04005FB2 RID: 24498
        public sbyte field_ajst_w_dr_f;

        // Token: 0x04005FB3 RID: 24499
        public sbyte field_ajst_w_dr_b;

        // Token: 0x04005FB4 RID: 24500
        public sbyte field_ajst_h_db_r;

        // Token: 0x04005FB5 RID: 24501
        public sbyte field_ajst_h_db_l;

        // Token: 0x04005FB6 RID: 24502
        public sbyte field_ajst_h_dl_r;

        // Token: 0x04005FB7 RID: 24503
        public sbyte field_ajst_h_dl_l;

        // Token: 0x04005FB8 RID: 24504
        public sbyte field_ajst_h_dt_r;

        // Token: 0x04005FB9 RID: 24505
        public sbyte field_ajst_h_dt_l;

        // Token: 0x04005FBA RID: 24506
        public sbyte field_ajst_h_dr_r;

        // Token: 0x04005FBB RID: 24507
        public sbyte field_ajst_h_dr_l;

        // Token: 0x04005FBC RID: 24508
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppFunc;

        // Token: 0x04005FBD RID: 24509
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppIn;

        // Token: 0x04005FBE RID: 24510
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppOut;

        // Token: 0x04005FBF RID: 24511
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppOutSub;

        // Token: 0x04005FC0 RID: 24512
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppMove;

        // Token: 0x04005FC1 RID: 24513
        public AppMain.OBS_OBJECT_WORK_Delegate2 ppActCall;

        // Token: 0x04005FC2 RID: 24514
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppRec;

        // Token: 0x04005FC3 RID: 24515
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppLast;

        // Token: 0x04005FC4 RID: 24516
        public AppMain.MPP_VOID_OBS_OBJECT_WORK ppCol;

        // Token: 0x04005FC5 RID: 24517
        public AppMain.OBS_OBJECT_WORK_Delegate3 ppViewCheck;

        // Token: 0x04005FC6 RID: 24518
        public AppMain.OBS_OBJECT_WORK_Delegate4 ppUserRelease;

        // Token: 0x04005FC7 RID: 24519
        public AppMain.OBS_OBJECT_WORK_Delegate4 ppUserReleaseWait;

        // Token: 0x04005FC8 RID: 24520
        public AppMain.OBS_OBJECT_WORK ride_obj;

        // Token: 0x04005FC9 RID: 24521
        public AppMain.OBS_OBJECT_WORK touch_obj;

        // Token: 0x04005FCA RID: 24522
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x04005FCB RID: 24523
        public AppMain.OBS_OBJECT_WORK lock_obj;

        // Token: 0x04005FCC RID: 24524
        public AppMain.OBS_OBJECT_WORK locker_obj;

        // Token: 0x04005FCD RID: 24525
        public object ex_work;

        // Token: 0x04005FCE RID: 24526
        public AppMain.OBS_ACTION3D_NN_WORK obj_3d;

        // Token: 0x04005FCF RID: 24527
        public AppMain.OBS_ACTION3D_ES_WORK obj_3des;

        // Token: 0x04005FD0 RID: 24528
        public AppMain.OBS_ACTION2D_AMA_WORK obj_2d;

        // Token: 0x04005FD1 RID: 24529
        public AppMain.OBS_COLLISION_WORK col_work;

        // Token: 0x04005FD2 RID: 24530
        public AppMain.OBS_TBL_WORK tbl_work;

        // Token: 0x04005FD3 RID: 24531
        public AppMain.VecFx32 temp_ofst = default(AppMain.VecFx32);

        // Token: 0x04005FD4 RID: 24532
        public AppMain.VecFx32 prev_temp_ofst = default(AppMain.VecFx32);

        // Token: 0x04005FD5 RID: 24533
        public uint rect_num;

        // Token: 0x04005FD6 RID: 24534
        public AppMain.ArrayPointer<AppMain.OBS_RECT_WORK> rect_work;

        // Token: 0x04005FD7 RID: 24535
        public object holder;

        // Token: 0x04005FD8 RID: 24536
        public object m_primaryHolder;
    }

    // Token: 0x02000366 RID: 870
    // (Invoke) Token: 0x06002692 RID: 9874
    public delegate void OBF_ACT_CALLBACK( object o1, object o2, uint u );
}
