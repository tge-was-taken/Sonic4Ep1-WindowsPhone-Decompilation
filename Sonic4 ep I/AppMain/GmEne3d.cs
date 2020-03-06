using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000042 RID: 66
    public class GMS_ENEMY_3D_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001D6B RID: 7531 RVA: 0x001382D2 File Offset: 0x001364D2
        public GMS_ENEMY_3D_WORK()
        {
            this.ene_com = new AppMain.GMS_ENEMY_COM_WORK( this );
        }

        // Token: 0x06001D6C RID: 7532 RVA: 0x001382F1 File Offset: 0x001364F1
        public GMS_ENEMY_3D_WORK( object _holder )
        {
            this.ene_com = new AppMain.GMS_ENEMY_COM_WORK( this );
            this.holder = _holder;
        }

        // Token: 0x06001D6D RID: 7533 RVA: 0x00138317 File Offset: 0x00136517
        public static explicit operator AppMain.GMS_GMK_GEAR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_GEAR_WORK )p.holder;
        }

        // Token: 0x06001D6E RID: 7534 RVA: 0x00138324 File Offset: 0x00136524
        public static explicit operator AppMain.GMS_GMK_WATER_SLIDER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_WATER_SLIDER_WORK )p.holder;
        }

        // Token: 0x06001D6F RID: 7535 RVA: 0x00138331 File Offset: 0x00136531
        public static explicit operator AppMain.GMS_GMK_UPBUMPER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_UPBUMPER_WORK )p.holder;
        }

        // Token: 0x06001D70 RID: 7536 RVA: 0x0013833E File Offset: 0x0013653E
        public static explicit operator AppMain.GMS_GMK_STEAMP_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_STEAMP_WORK )p.holder;
        }

        // Token: 0x06001D71 RID: 7537 RVA: 0x0013834B File Offset: 0x0013654B
        public static explicit operator AppMain.GMS_GMK_SEESAW_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_SEESAW_WORK )p.holder;
        }

        // Token: 0x06001D72 RID: 7538 RVA: 0x00138358 File Offset: 0x00136558
        public static explicit operator AppMain.GMS_GMK_PWALL_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_PWALL_WORK )p.holder;
        }

        // Token: 0x06001D73 RID: 7539 RVA: 0x00138365 File Offset: 0x00136565
        public static explicit operator AppMain.GMS_GMK_PWALLCTRL_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_PWALLCTRL_WORK )p.holder;
        }

        // Token: 0x06001D74 RID: 7540 RVA: 0x00138372 File Offset: 0x00136572
        public static explicit operator AppMain.GMS_GMK_SHUTTER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_SHUTTER_WORK )p.holder;
        }

        // Token: 0x06001D75 RID: 7541 RVA: 0x0013837F File Offset: 0x0013657F
        public static explicit operator AppMain.GMS_GMK_P_STEAM_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_P_STEAM_WORK )p.holder;
        }

        // Token: 0x06001D76 RID: 7542 RVA: 0x0013838C File Offset: 0x0013658C
        public static explicit operator AppMain.GMS_GMK_PISTON_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_PISTON_WORK )p.holder;
        }

        // Token: 0x06001D77 RID: 7543 RVA: 0x00138399 File Offset: 0x00136599
        public static explicit operator AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_DRAIN_TANK_OUT_WORK )p.holder;
        }

        // Token: 0x06001D78 RID: 7544 RVA: 0x001383A6 File Offset: 0x001365A6
        public static explicit operator AppMain.GMS_GMK_CANNON_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_CANNON_WORK )p.holder;
        }

        // Token: 0x06001D79 RID: 7545 RVA: 0x001383B3 File Offset: 0x001365B3
        public static explicit operator AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_BOSS3_PILLAR_MAIN_WORK )p.holder;
        }

        // Token: 0x06001D7A RID: 7546 RVA: 0x001383C0 File Offset: 0x001365C0
        public static explicit operator AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_BOSS3_PILLAR_MANAGER_WORK )p.holder;
        }

        // Token: 0x06001D7B RID: 7547 RVA: 0x001383CD File Offset: 0x001365CD
        public static explicit operator AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_BOSS3_PILLAR_WALL_WORK )p.holder;
        }

        // Token: 0x06001D7C RID: 7548 RVA: 0x001383DA File Offset: 0x001365DA
        public static explicit operator AppMain.GMS_BOSS5_LAND_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_LAND_WORK )p.holder;
        }

        // Token: 0x06001D7D RID: 7549 RVA: 0x001383E7 File Offset: 0x001365E7
        public static explicit operator AppMain.GMS_BOSS5_CTPLT_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_CTPLT_WORK )p.holder;
        }

        // Token: 0x06001D7E RID: 7550 RVA: 0x001383F4 File Offset: 0x001365F4
        public static explicit operator AppMain.GMS_BOSS5_TURRET_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_TURRET_WORK )p.holder;
        }

        // Token: 0x06001D7F RID: 7551 RVA: 0x00138401 File Offset: 0x00136601
        public static explicit operator AppMain.GMS_BOSS5_EGG_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_EGG_WORK )p.holder;
        }

        // Token: 0x06001D80 RID: 7552 RVA: 0x0013840E File Offset: 0x0013660E
        public static explicit operator AppMain.GMS_BOSS5_ROCKET_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_ROCKET_WORK )p.holder;
        }

        // Token: 0x06001D81 RID: 7553 RVA: 0x0013841B File Offset: 0x0013661B
        public static explicit operator AppMain.GMS_BOSS5_MGR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_MGR_WORK )p.holder;
        }

        // Token: 0x06001D82 RID: 7554 RVA: 0x00138428 File Offset: 0x00136628
        public static explicit operator AppMain.GMS_BOSS5_BODY_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS5_BODY_WORK )p.holder;
        }

        // Token: 0x06001D83 RID: 7555 RVA: 0x00138435 File Offset: 0x00136635
        public static explicit operator AppMain.GMS_BOSS4_CHIBI_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS4_CHIBI_WORK )p.holder;
        }

        // Token: 0x06001D84 RID: 7556 RVA: 0x00138442 File Offset: 0x00136642
        public static explicit operator AppMain.GMS_BOSS4_BODY_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS4_BODY_WORK )p.holder;
        }

        // Token: 0x06001D85 RID: 7557 RVA: 0x0013844F File Offset: 0x0013664F
        public static explicit operator AppMain.GMS_BOSS4_CAP_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS4_CAP_WORK )p.holder;
        }

        // Token: 0x06001D86 RID: 7558 RVA: 0x0013845C File Offset: 0x0013665C
        public static explicit operator AppMain.GMS_BOSS4_EGG_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS4_EGG_WORK )p.holder;
        }

        // Token: 0x06001D87 RID: 7559 RVA: 0x00138469 File Offset: 0x00136669
        public static explicit operator AppMain.GMS_BOSS4_MGR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS4_MGR_WORK )p.holder;
        }

        // Token: 0x06001D88 RID: 7560 RVA: 0x00138476 File Offset: 0x00136676
        public static explicit operator AppMain.GMS_GMK_TRUCK_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_TRUCK_WORK )p.holder;
        }

        // Token: 0x06001D89 RID: 7561 RVA: 0x00138483 File Offset: 0x00136683
        public static explicit operator AppMain.GMS_BOSS2_BALL_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS2_BALL_WORK )p.holder;
        }

        // Token: 0x06001D8A RID: 7562 RVA: 0x00138490 File Offset: 0x00136690
        public static explicit operator AppMain.GMS_BOSS2_EGG_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS2_EGG_WORK )p.holder;
        }

        // Token: 0x06001D8B RID: 7563 RVA: 0x0013849D File Offset: 0x0013669D
        public static explicit operator AppMain.GMS_BOSS2_BODY_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS2_BODY_WORK )p.holder;
        }

        // Token: 0x06001D8C RID: 7564 RVA: 0x001384AA File Offset: 0x001366AA
        public static explicit operator AppMain.GMS_BOSS2_MGR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS2_MGR_WORK )p.holder;
        }

        // Token: 0x06001D8D RID: 7565 RVA: 0x001384B7 File Offset: 0x001366B7
        public static explicit operator AppMain.GMS_BOSS3_EGG_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS3_EGG_WORK )p.holder;
        }

        // Token: 0x06001D8E RID: 7566 RVA: 0x001384C4 File Offset: 0x001366C4
        public static explicit operator AppMain.GMS_BOSS3_BODY_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS3_BODY_WORK )p.holder;
        }

        // Token: 0x06001D8F RID: 7567 RVA: 0x001384D1 File Offset: 0x001366D1
        public static explicit operator AppMain.GMS_BOSS3_MGR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS3_MGR_WORK )p.holder;
        }

        // Token: 0x06001D90 RID: 7568 RVA: 0x001384DE File Offset: 0x001366DE
        public static explicit operator AppMain.GMS_ENE_UNIUNI_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_UNIUNI_WORK )p.holder;
        }

        // Token: 0x06001D91 RID: 7569 RVA: 0x001384EB File Offset: 0x001366EB
        public static explicit operator AppMain.GMS_ENE_UNIDES_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_UNIDES_WORK )p.holder;
        }

        // Token: 0x06001D92 RID: 7570 RVA: 0x001384F8 File Offset: 0x001366F8
        public static explicit operator AppMain.GMS_ENE_BUKU_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_BUKU_WORK )p.holder;
        }

        // Token: 0x06001D93 RID: 7571 RVA: 0x00138505 File Offset: 0x00136705
        public static explicit operator AppMain.GMS_ENE_T_STAR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_T_STAR_WORK )p.holder;
        }

        // Token: 0x06001D94 RID: 7572 RVA: 0x00138512 File Offset: 0x00136712
        public static explicit operator AppMain.GMS_ENE_KANI_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_KANI_WORK )p.holder;
        }

        // Token: 0x06001D95 RID: 7573 RVA: 0x0013851F File Offset: 0x0013671F
        public static explicit operator AppMain.GMS_ENE_KAMA_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            if ( p == null )
            {
                return null;
            }
            return ( AppMain.GMS_ENE_KAMA_WORK )p.holder;
        }

        // Token: 0x06001D96 RID: 7574 RVA: 0x00138531 File Offset: 0x00136731
        public static explicit operator AppMain.GMS_ENE_MOGU_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_MOGU_WORK )p.holder;
        }

        // Token: 0x06001D97 RID: 7575 RVA: 0x0013853E File Offset: 0x0013673E
        public static explicit operator AppMain.GMS_GMK_SPCTPLT_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_SPCTPLT_WORK )p.holder;
        }

        // Token: 0x06001D98 RID: 7576 RVA: 0x0013854B File Offset: 0x0013674B
        public static explicit operator AppMain.GMS_GMK_SLOT_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_SLOT_WORK )p.holder;
        }

        // Token: 0x06001D99 RID: 7577 RVA: 0x00138558 File Offset: 0x00136758
        public static explicit operator AppMain.GMS_GMK_STOPPER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_STOPPER_WORK )p.holder;
        }

        // Token: 0x06001D9A RID: 7578 RVA: 0x00138565 File Offset: 0x00136765
        public static explicit operator AppMain.GMS_ENE_HARO_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_HARO_WORK )p.holder;
        }

        // Token: 0x06001D9B RID: 7579 RVA: 0x00138572 File Offset: 0x00136772
        public static explicit operator AppMain.GMS_ENE_GARDON_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_GARDON_WORK )p.holder;
        }

        // Token: 0x06001D9C RID: 7580 RVA: 0x0013857F File Offset: 0x0013677F
        public static explicit operator AppMain.GMS_GMK_BUMPER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_BUMPER_WORK )p.holder;
        }

        // Token: 0x06001D9D RID: 7581 RVA: 0x0013858C File Offset: 0x0013678C
        public static explicit operator AppMain.GMS_BOSS1_CHAIN_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS1_CHAIN_WORK )p.holder;
        }

        // Token: 0x06001D9E RID: 7582 RVA: 0x00138599 File Offset: 0x00136799
        public static explicit operator AppMain.GMS_BOSS1_MGR_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS1_MGR_WORK )p.holder;
        }

        // Token: 0x06001D9F RID: 7583 RVA: 0x001385A6 File Offset: 0x001367A6
        public static explicit operator AppMain.GMS_BOSS1_EGG_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS1_EGG_WORK )p.holder;
        }

        // Token: 0x06001DA0 RID: 7584 RVA: 0x001385B3 File Offset: 0x001367B3
        public static explicit operator AppMain.GMS_BOSS1_BODY_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_BOSS1_BODY_WORK )p.holder;
        }

        // Token: 0x06001DA1 RID: 7585 RVA: 0x001385C0 File Offset: 0x001367C0
        public static explicit operator AppMain.GMS_GMK_PULLEY_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_PULLEY_WORK )p.holder;
        }

        // Token: 0x06001DA2 RID: 7586 RVA: 0x001385CD File Offset: 0x001367CD
        public static explicit operator AppMain.GMS_ENE_STING_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_ENE_STING_WORK )p.holder;
        }

        // Token: 0x06001DA3 RID: 7587 RVA: 0x001385DA File Offset: 0x001367DA
        public static explicit operator AppMain.GMS_GMK_BLAND_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_BLAND_WORK )p.holder;
        }

        // Token: 0x06001DA4 RID: 7588 RVA: 0x001385E7 File Offset: 0x001367E7
        public static explicit operator AppMain.GMS_GMK_PMARKER_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_PMARKER_WORK )p.holder;
        }

        // Token: 0x06001DA5 RID: 7589 RVA: 0x001385F4 File Offset: 0x001367F4
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.ene_com.obj_work;
        }

        // Token: 0x06001DA6 RID: 7590 RVA: 0x00138601 File Offset: 0x00136801
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return work.ene_com.obj_work;
        }

        // Token: 0x06001DA7 RID: 7591 RVA: 0x0013860E File Offset: 0x0013680E
        public static explicit operator AppMain.GMS_GMK_NEEDLE_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_GMK_NEEDLE_WORK )work.holder;
        }

        // Token: 0x06001DA8 RID: 7592 RVA: 0x0013861B File Offset: 0x0013681B
        public static explicit operator AppMain.GMS_ENE_HARI_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_ENE_HARI_WORK )work.holder;
        }

        // Token: 0x06001DA9 RID: 7593 RVA: 0x00138628 File Offset: 0x00136828
        public static explicit operator AppMain.GMS_ENE_MOTORA_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_ENE_MOTORA_WORK )work.holder;
        }

        // Token: 0x06001DAA RID: 7594 RVA: 0x00138635 File Offset: 0x00136835
        public static explicit operator AppMain.GMS_GMK_BOBJ_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_GMK_BOBJ_WORK )work.holder;
        }

        // Token: 0x06001DAB RID: 7595 RVA: 0x00138642 File Offset: 0x00136842
        public static explicit operator AppMain.GMS_GMK_BOBJ_PARTS( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_GMK_BOBJ_PARTS )work.holder;
        }

        // Token: 0x06001DAC RID: 7596 RVA: 0x0013864F File Offset: 0x0013684F
        public static explicit operator AppMain.GMS_GMK_BELTC_WORK( AppMain.GMS_ENEMY_3D_WORK p )
        {
            return ( AppMain.GMS_GMK_BELTC_WORK )p.holder;
        }

        // Token: 0x06001DAD RID: 7597 RVA: 0x0013865C File Offset: 0x0013685C
        public static explicit operator AppMain.GMS_GMK_ROCK_FALL_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_FALL_WORK )work.holder;
        }

        // Token: 0x06001DAE RID: 7598 RVA: 0x00138669 File Offset: 0x00136869
        public static explicit operator AppMain.GMS_GMK_ROCK_FALL_MGR_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_FALL_MGR_WORK )work.holder;
        }

        // Token: 0x06001DAF RID: 7599 RVA: 0x00138676 File Offset: 0x00136876
        public static explicit operator AppMain.GMS_GMK_ROCK_CHASE_WORK( AppMain.GMS_ENEMY_3D_WORK work )
        {
            return ( AppMain.GMS_GMK_ROCK_CHASE_WORK )work.holder;
        }

        // Token: 0x04004864 RID: 18532
        public readonly AppMain.GMS_ENEMY_COM_WORK ene_com;

        // Token: 0x04004865 RID: 18533
        public readonly AppMain.OBS_ACTION3D_NN_WORK obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();

        // Token: 0x04004866 RID: 18534
        public readonly object holder;
    }
}