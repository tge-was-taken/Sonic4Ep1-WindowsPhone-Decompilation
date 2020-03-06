using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001F8 RID: 504
    public class GMS_OBJECT_WORK_ATK
    {
        // Token: 0x0600231C RID: 8988 RVA: 0x00147FA5 File Offset: 0x001461A5
        public GMS_OBJECT_WORK_ATK()
        {
            this.rect_work[0] = new AppMain.OBS_RECT_WORK();
            this.rect_work[1] = new AppMain.OBS_RECT_WORK();
        }

        // Token: 0x0400551E RID: 21790
        public readonly AppMain.OBS_OBJECT_WORK obj = AppMain.OBS_OBJECT_WORK.Create();

        // Token: 0x0400551F RID: 21791
        public readonly AppMain.OBS_RECT_WORK[] rect_work = new AppMain.OBS_RECT_WORK[2];
    }

    // Token: 0x060004DC RID: 1244 RVA: 0x00029D53 File Offset: 0x00027F53
    private static void GmObjCollision( AppMain.OBS_OBJECT_WORK obj_work )
    {
        obj_work.ride_obj = null;
        obj_work.touch_obj = null;
        AppMain.ObjObjectCollision( obj_work );
    }

    // Token: 0x060004DD RID: 1245 RVA: 0x00029D69 File Offset: 0x00027F69
    private static void GmObjPreFunc()
    {
    }

    // Token: 0x060004DE RID: 1246 RVA: 0x00029D6C File Offset: 0x00027F6C
    private static void GmObjRegistRectAuto( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( obj_work.rect_work.array != null && obj_work.rect_num > 0U )
        {
            int offset = obj_work.rect_work.offset;
            int num = offset + (int)obj_work.rect_num;
            for ( int i = offset; i < num; i++ )
            {
                AppMain.ObjObjectRectRegist( obj_work, obj_work.rect_work.array[i] );
            }
        }
        if ( obj_work.col_work != null && obj_work.col_work.obj_col.obj != null && AppMain.ObjObjectViewOutCheck( obj_work ) == 0 )
        {
            AppMain.ObjCollisionObjectRegist( obj_work.col_work.obj_col );
        }
    }

    // Token: 0x060004DF RID: 1247 RVA: 0x00029DF5 File Offset: 0x00027FF5
    private static void GmObjObjPreFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060004E0 RID: 1248 RVA: 0x00029DF7 File Offset: 0x00027FF7
    private static void GmObjObjPostFunc( AppMain.OBS_OBJECT_WORK obj_work )
    {
    }

    // Token: 0x060004E1 RID: 1249 RVA: 0x00029DF9 File Offset: 0x00027FF9
    private static bool GmObjCheckMapLeftLimit( AppMain.OBS_OBJECT_WORK obj_work, int ofst )
    {
        return ( obj_work.move_flag & 12U ) != 0U && obj_work.pos.x >> 12 <= AppMain.g_gm_main_system.map_fcol.left + ofst;
    }

    // Token: 0x060004E2 RID: 1250 RVA: 0x00029E2A File Offset: 0x0002802A
    private static bool GmObjCheckMapRightLimit( AppMain.OBS_OBJECT_WORK obj_work, int ofst )
    {
        return ( obj_work.move_flag & 12U ) != 0U && obj_work.pos.x >> 12 >= AppMain.g_gm_main_system.map_fcol.right - ofst;
    }

    // Token: 0x060004E3 RID: 1251 RVA: 0x00029E5C File Offset: 0x0002805C
    private static void GmObjSetClip( AppMain.OBS_OBJECT_WORK obj_work, short out_ofst, short plus_left, short plus_top, short plus_right, short plus_bottom )
    {
        obj_work.ppViewCheck = new AppMain.OBS_OBJECT_WORK_Delegate3( AppMain.ObjObjectViewOutCheck );
        obj_work.view_out_ofst = out_ofst;
        obj_work.view_out_ofst_plus[0] = plus_left;
        obj_work.view_out_ofst_plus[1] = plus_top;
        obj_work.view_out_ofst_plus[2] = plus_right;
        obj_work.view_out_ofst_plus[3] = plus_bottom;
        obj_work.flag &= 4294967279U;
    }

    // Token: 0x060004E4 RID: 1252 RVA: 0x00029EB8 File Offset: 0x000280B8
    private static void GmObjGetRotPosXY( int pos_x, int pos_y, ref int dest_x, ref int dest_y, ushort dir )
    {
        int num = AppMain.FX_Mul(pos_x, AppMain.mtMathSin((int)dir));
        int num2 = AppMain.FX_Mul(pos_x, AppMain.mtMathCos((int)dir));
        int num3 = AppMain.FX_Mul(pos_y, AppMain.mtMathSin((int)dir));
        int num4 = AppMain.FX_Mul(pos_y, AppMain.mtMathCos((int)dir));
        dest_x = num2 - num3;
        dest_y = num + num4;
    }

    // Token: 0x060004E5 RID: 1253 RVA: 0x00029F08 File Offset: 0x00028108
    private static void GmObjSetAllObjectNoDisp()
    {
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, ushort.MaxValue ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ushort.MaxValue ) )
        {
            if ( ( obs_OBJECT_WORK.flag & 12U ) == 0U )
            {
                obs_OBJECT_WORK.disp_flag |= 32U;
            }
        }
    }

    // Token: 0x060004E6 RID: 1254 RVA: 0x00029F4C File Offset: 0x0002814C
    private static void GmObjSetObjectNoFunc( uint obj_type_flag )
    {
        uint num = obj_type_flag & 2147483647U;
        ushort num2 = 0;
        while ( num2 < 31 && num != 0U )
        {
            if ( ( num & 1U ) != 0U )
            {
                for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, num2 ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, num2 ) )
                {
                    if ( ( obs_OBJECT_WORK.flag & 12U ) == 0U )
                    {
                        obs_OBJECT_WORK.flag |= 130U;
                        obs_OBJECT_WORK.move_flag |= 8448U;
                    }
                }
            }
            num2 += 1;
            num >>= 1;
        }
    }
}
