using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000041 RID: 65
    public class GMS_ENEMY_COM_WORK : AppMain.IOBS_OBJECT_WORK
    {
        // Token: 0x06001D64 RID: 7524 RVA: 0x001381EB File Offset: 0x001363EB
        public static explicit operator AppMain.GMS_GMK_TRUCK_WORK( AppMain.GMS_ENEMY_COM_WORK p )
        {
            return ( AppMain.GMS_GMK_TRUCK_WORK )( ( AppMain.GMS_ENEMY_3D_WORK )p.holder );
        }

        // Token: 0x06001D65 RID: 7525 RVA: 0x001381FD File Offset: 0x001363FD
        public static explicit operator AppMain.GMS_BOSS5_CORE_WORK( AppMain.GMS_ENEMY_COM_WORK p )
        {
            return ( AppMain.GMS_BOSS5_CORE_WORK )p.holder;
        }

        // Token: 0x06001D66 RID: 7526 RVA: 0x0013820A File Offset: 0x0013640A
        public static explicit operator AppMain.GMS_ENEMY_3D_WORK( AppMain.GMS_ENEMY_COM_WORK p )
        {
            if ( p == null )
            {
                return null;
            }
            return ( AppMain.GMS_ENEMY_3D_WORK )p.holder;
        }

        // Token: 0x06001D67 RID: 7527 RVA: 0x0013821C File Offset: 0x0013641C
        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.obj_work;
        }

        // Token: 0x06001D68 RID: 7528 RVA: 0x00138224 File Offset: 0x00136424
        public static explicit operator AppMain.OBS_OBJECT_WORK( AppMain.GMS_ENEMY_COM_WORK work )
        {
            return work.obj_work;
        }

        // Token: 0x06001D69 RID: 7529 RVA: 0x0013822C File Offset: 0x0013642C
        public GMS_ENEMY_COM_WORK()
        {
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this, null );
        }

        // Token: 0x06001D6A RID: 7530 RVA: 0x0013827C File Offset: 0x0013647C
        public GMS_ENEMY_COM_WORK( object p )
        {
            this.holder = p;
            this.obj_work = AppMain.OBS_OBJECT_WORK.Create( this, p );
        }

        // Token: 0x04004854 RID: 18516
        public readonly AppMain.OBS_OBJECT_WORK obj_work;

        // Token: 0x04004855 RID: 18517
        public readonly AppMain.OBS_RECT_WORK[] rect_work = AppMain.New<AppMain.OBS_RECT_WORK>(3);

        // Token: 0x04004856 RID: 18518
        public readonly AppMain.OBS_COLLISION_WORK col_work = new AppMain.OBS_COLLISION_WORK();

        // Token: 0x04004857 RID: 18519
        public AppMain.GMS_EVE_RECORD_EVENT eve_rec;

        // Token: 0x04004858 RID: 18520
        public byte eve_x;

        // Token: 0x04004859 RID: 18521
        public byte vit;

        // Token: 0x0400485A RID: 18522
        public int born_pos_x;

        // Token: 0x0400485B RID: 18523
        public int born_pos_y;

        // Token: 0x0400485C RID: 18524
        public int invincible_timer;

        // Token: 0x0400485D RID: 18525
        public uint enemy_flag;

        // Token: 0x0400485E RID: 18526
        public ushort act_state;

        // Token: 0x0400485F RID: 18527
        public AppMain.OBS_OBJECT_WORK target_obj;

        // Token: 0x04004860 RID: 18528
        public AppMain.VecU16 target_dp_dir = default(AppMain.VecU16);

        // Token: 0x04004861 RID: 18529
        public AppMain.VecFx32 target_dp_pos = default(AppMain.VecFx32);

        // Token: 0x04004862 RID: 18530
        public int target_dp_dist;

        // Token: 0x04004863 RID: 18531
        public readonly object holder;
    }

    // Token: 0x060015AD RID: 5549 RVA: 0x000BD49C File Offset: 0x000BB69C
    private static void GmEneComActionSetDependHFlip( AppMain.OBS_OBJECT_WORK obj_work, int act_id_r, int act_id_l )
    {
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet( obj_work, act_id_l );
            return;
        }
        AppMain.ObjDrawObjectActionSet( obj_work, act_id_r );
    }

    // Token: 0x060015AE RID: 5550 RVA: 0x000BD4B7 File Offset: 0x000BB6B7
    private static void GmEneComActionSet3DNNBlendDependHFlip( AppMain.OBS_OBJECT_WORK obj_work, int act_id_r, int act_id_l )
    {
        if ( ( obj_work.disp_flag & 1U ) != 0U )
        {
            AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, act_id_l );
            return;
        }
        AppMain.ObjDrawObjectActionSet3DNNBlend( obj_work, act_id_r );
    }

    // Token: 0x060015AF RID: 5551 RVA: 0x000BD4D2 File Offset: 0x000BB6D2
    private static int GmEneComTargetIsLeft( AppMain.OBS_OBJECT_WORK mine_obj, AppMain.OBS_OBJECT_WORK target_obj )
    {
        if ( target_obj.pos.x < mine_obj.pos.x )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x060015B0 RID: 5552 RVA: 0x000BD4EF File Offset: 0x000BB6EF
    private static int GmEneComCheckMoveLimit( AppMain.OBS_OBJECT_WORK obj_work, int limit_left, int limit_right )
    {
        if ( ( ( obj_work.disp_flag & 1U ) != 0U && obj_work.pos.x <= limit_left ) || ( ( obj_work.disp_flag & 1U ) == 0U && obj_work.pos.x >= limit_right ) )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x060015B1 RID: 5553 RVA: 0x000BD52C File Offset: 0x000BB72C
    private static AppMain.OBS_OBJECT_WORK GmEneComCreateAtkObject( AppMain.OBS_OBJECT_WORK parent_obj, short view_out_ofst )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.GMM_EFFECT_CREATE_WORK(() => new AppMain.GMS_EFFECT_COM_WORK(), parent_obj, 0, parent_obj.tcb.am_tcb.name);
        AppMain.GMS_EFFECT_COM_WORK efct_com = (AppMain.GMS_EFFECT_COM_WORK)obs_OBJECT_WORK;
        obs_OBJECT_WORK.flag &= 4294967277U;
        obs_OBJECT_WORK.move_flag |= 256U;
        obs_OBJECT_WORK.view_out_ofst = view_out_ofst;
        AppMain.GmEffectRectInit( efct_com, AppMain.gm_ene_com_atk_obj_atk_flag_tbl, AppMain.gm_ene_com_atk_obj_def_flag_tbl, 1, 1 );
        return obs_OBJECT_WORK;
    }
}