using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000088 RID: 136
    // (Invoke) Token: 0x06001E5E RID: 7774
    private delegate int ObjDiffCollision_pFunc_delegate( int i1, int i2, ushort us, ushort[] usa, uint[] uia );

    // Token: 0x02000089 RID: 137
    private class _ObjDiffCollision
    {
        // Token: 0x04004A34 RID: 18996
        public static AppMain.ObjDiffCollision_pFunc_delegate objGetColDataXPtr = new AppMain.ObjDiffCollision_pFunc_delegate(AppMain.objGetColDataX);

        // Token: 0x04004A35 RID: 18997
        public static AppMain.ObjDiffCollision_pFunc_delegate objGetColDataYPtr = new AppMain.ObjDiffCollision_pFunc_delegate(AppMain.objGetColDataY);
    }

    // Token: 0x0200008A RID: 138
    private class _objGetDiffCharData
    {
        // Token: 0x04004A36 RID: 18998
        public static byte[] diff_char = new byte[8];
    }

    // Token: 0x02000139 RID: 313
    public class OBS_DIFF_COLLISION
    {
        // Token: 0x0600207A RID: 8314 RVA: 0x0013E9C0 File Offset: 0x0013CBC0
        internal void Clear()
        {
            this.cl_diff_datap = null;
            this.direc_datap = null;
            this.block_map_datap[0] = null;
            this.block_map_datap[1] = null;
            this.char_attr_datap = null;
            this.map_block_num_x = 0;
            this.map_block_num_y = 0;
            this.diff_block_num = 0U;
            this.dir_block_num = 0U;
            this.attr_block_num = 0U;
            this.left = 0;
            this.top = 0;
            this.right = 0;
            this.bottom = 0;
        }

        // Token: 0x04004CF7 RID: 19703
        public AppMain.DF_BLOCK[] cl_diff_datap;

        // Token: 0x04004CF8 RID: 19704
        public AppMain.DI_BLOCK[] direc_datap;

        // Token: 0x04004CF9 RID: 19705
        public readonly AppMain.MP_BLOCK[][] block_map_datap = new AppMain.MP_BLOCK[2][];

        // Token: 0x04004CFA RID: 19706
        public AppMain.AT_BLOCK[] char_attr_datap;

        // Token: 0x04004CFB RID: 19707
        public ushort map_block_num_x;

        // Token: 0x04004CFC RID: 19708
        public ushort map_block_num_y;

        // Token: 0x04004CFD RID: 19709
        public uint diff_block_num;

        // Token: 0x04004CFE RID: 19710
        public uint dir_block_num;

        // Token: 0x04004CFF RID: 19711
        public uint attr_block_num;

        // Token: 0x04004D00 RID: 19712
        public int left;

        // Token: 0x04004D01 RID: 19713
        public int top;

        // Token: 0x04004D02 RID: 19714
        public int right;

        // Token: 0x04004D03 RID: 19715
        public int bottom;
    }

    // Token: 0x0200013A RID: 314
    public class OBS_BLOCK_COLLISION
    {
        // Token: 0x04004D04 RID: 19716
        public readonly byte[][] pData = new byte[2][];

        // Token: 0x04004D05 RID: 19717
        public uint width;

        // Token: 0x04004D06 RID: 19718
        public uint height;

        // Token: 0x04004D07 RID: 19719
        public int left;

        // Token: 0x04004D08 RID: 19720
        public int top;

        // Token: 0x04004D09 RID: 19721
        public int right;

        // Token: 0x04004D0A RID: 19722
        public int bottom;
    }

    // Token: 0x0200013B RID: 315
    public class OBS_COL_CHK_DATA : AppMain.IClearable
    {
        // Token: 0x0600207D RID: 8317 RVA: 0x0013EA5C File Offset: 0x0013CC5C
        public AppMain.OBS_COL_CHK_DATA Assign( AppMain.OBS_COL_CHK_DATA data )
        {
            if ( this != data )
            {
                this.pos_x = data.pos_x;
                this.pos_y = data.pos_y;
                this.dir = data.dir;
                this.dir = data.dir;
                this.attr = data.attr;
                this.attr = data.attr;
                this.flag = data.flag;
                this.vec = data.vec;
            }
            return this;
        }

        // Token: 0x0600207E RID: 8318 RVA: 0x0013EACE File Offset: 0x0013CCCE
        public void Clear()
        {
            this.pos_x = 0;
            this.pos_y = 0;
            this.dir = null;
            this.attr = null;
            this.flag = 0;
            this.vec = 0;
        }

        // Token: 0x04004D0B RID: 19723
        public int pos_x;

        // Token: 0x04004D0C RID: 19724
        public int pos_y;

        // Token: 0x04004D0D RID: 19725
        public ushort[] dir;

        // Token: 0x04004D0E RID: 19726
        public uint[] attr;

        // Token: 0x04004D0F RID: 19727
        public ushort flag;

        // Token: 0x04004D10 RID: 19728
        public ushort vec;
    }

    // Token: 0x02000360 RID: 864
    public class OBS_COLLISION_OBJ
    {
        // Token: 0x04005F67 RID: 24423
        public AppMain.OBS_OBJECT_WORK obj;

        // Token: 0x04005F68 RID: 24424
        public AppMain.OBS_OBJECT_WORK rider_obj;

        // Token: 0x04005F69 RID: 24425
        public AppMain.OBS_OBJECT_WORK toucher_obj;

        // Token: 0x04005F6A RID: 24426
        public AppMain.VecFx32 pos = default(AppMain.VecFx32);

        // Token: 0x04005F6B RID: 24427
        public short ofst_x;

        // Token: 0x04005F6C RID: 24428
        public short ofst_y;

        // Token: 0x04005F6D RID: 24429
        public uint flag;

        // Token: 0x04005F6E RID: 24430
        public ushort dir;

        // Token: 0x04005F6F RID: 24431
        public ushort attr;

        // Token: 0x04005F70 RID: 24432
        public byte[] diff_data;

        // Token: 0x04005F71 RID: 24433
        public byte[] dir_data;

        // Token: 0x04005F72 RID: 24434
        public byte[] attr_data;

        // Token: 0x04005F73 RID: 24435
        public ushort width;

        // Token: 0x04005F74 RID: 24436
        public ushort height;

        // Token: 0x04005F75 RID: 24437
        public AppMain.VecFx32 check_pos = default(AppMain.VecFx32);

        // Token: 0x04005F76 RID: 24438
        public short check_ofst_x;

        // Token: 0x04005F77 RID: 24439
        public short check_ofst_y;

        // Token: 0x04005F78 RID: 24440
        public int left;

        // Token: 0x04005F79 RID: 24441
        public int top;

        // Token: 0x04005F7A RID: 24442
        public int right;

        // Token: 0x04005F7B RID: 24443
        public int bottom;

        // Token: 0x04005F7C RID: 24444
        public ushort check_dir;
    }

    // Token: 0x02000361 RID: 865
    public class OBS_COLLISION_WORK
    {
        // Token: 0x04005F7D RID: 24445
        public readonly AppMain.OBS_COLLISION_OBJ obj_col = new AppMain.OBS_COLLISION_OBJ();

        // Token: 0x04005F7E RID: 24446
        public AppMain.OBS_DATA_WORK diff_data_work;

        // Token: 0x04005F7F RID: 24447
        public AppMain.OBS_DATA_WORK dir_data_work;

        // Token: 0x04005F80 RID: 24448
        public AppMain.OBS_DATA_WORK attr_data_work;
    }

    // Token: 0x0600011A RID: 282 RVA: 0x0000B465 File Offset: 0x00009665
    private static void objDiffAttrSet( AppMain.OBS_OBJECT_WORK pWork, uint ulAttr )
    {
        if ( ( ulAttr & 2U ) != 0U )
        {
            pWork.col_flag |= 1U;
        }
        if ( ( ulAttr & 4U ) != 0U )
        {
            pWork.col_flag |= 4U;
        }
    }

    // Token: 0x0600011B RID: 283 RVA: 0x0000B48D File Offset: 0x0000968D
    private static int objCollision( AppMain.OBS_COL_CHK_DATA pData )
    {
        if ( ( AppMain.g_obj.flag & 16U ) != 0U )
        {
            return AppMain.ObjBlockCollision( pData );
        }
        return AppMain.ObjDiffCollision( pData );
    }

    // Token: 0x0600011C RID: 284 RVA: 0x0000B4AB File Offset: 0x000096AB
    private static int objCollisionFast( AppMain.OBS_COL_CHK_DATA pData )
    {
        if ( ( AppMain.g_obj.flag & 16U ) != 0U )
        {
            return AppMain.ObjBlockCollision( pData );
        }
        return AppMain.ObjDiffCollisionFast( pData );
    }

    // Token: 0x0600011D RID: 285 RVA: 0x0000B4CC File Offset: 0x000096CC
    private static int ObjCollisionUnion( AppMain.OBS_OBJECT_WORK pWork, AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 32;
        if ( ( pWork.move_flag & 4096U ) == 0U )
        {
            num = AppMain.objCollision( pData );
        }
        if ( ( pWork.move_flag & 512U ) == 0U )
        {
            int num2 = AppMain.ObjCollisionObjectCheck(pWork, pData);
            if ( num > num2 )
            {
                num = num2;
            }
        }
        return num;
    }

    // Token: 0x0600011E RID: 286 RVA: 0x0000B514 File Offset: 0x00009714
    private static int ObjCollisionFastUnion( AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = AppMain.objCollisionFast(pData);
        int num2 = AppMain.ObjCollisionObjectFastCheck(pData);
        if ( num > num2 )
        {
            num = num2;
        }
        return num;
    }

    // Token: 0x0600011F RID: 287 RVA: 0x0000B53C File Offset: 0x0000973C
    private static void ObjDiffCollisionEarthCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.objDiffCollisionDirCheck( pWork );
    }

    // Token: 0x06000120 RID: 288 RVA: 0x0000B544 File Offset: 0x00009744
    private static void objDiffCollisionDirCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        pWork.col_flag = 0U;
        int sSpd;
        if ( ( pWork.dir_fall + 8192 & 16384 ) != 0 )
        {
            sSpd = pWork.move.y;
        }
        else
        {
            sSpd = pWork.move.x;
        }
        if ( ( pWork.move_flag & 1024U ) == 0U )
        {
            AppMain.objDiffCollisionDirWidthCheck( pWork, 0, sSpd );
        }
        if ( ( pWork.move_flag & 2048U ) == 0U )
        {
            AppMain.objDiffCollisionDirHeightCheck( pWork );
        }
        if ( ( pWork.move_flag & 1U ) != 0U && ( pWork.dir.z == 0 || pWork.dir.z == 32768 ) )
        {
            if ( ( pWork.dir_fall + 8192 & 16384 ) != 0 )
            {
                pWork.pos.x = ( pWork.pos.x & -4096 );
            }
            else
            {
                pWork.pos.y = ( pWork.pos.y & -4096 );
            }
        }
        if ( ( pWork.move_flag & 1024U ) == 0U )
        {
            AppMain.objDiffCollisionDirWidthCheck( pWork, 1, sSpd );
        }
    }

    // Token: 0x06000121 RID: 289 RVA: 0x0000B634 File Offset: 0x00009834
    private static ushort objDiffSufSet( AppMain.OBS_OBJECT_WORK pWork )
    {
        ushort num = 0;
        if ( ( pWork.move_flag & 32U ) != 0U )
        {
            num |= 128;
        }
        if ( ( pWork.move_flag & 1048576U ) == 0U )
        {
            num |= 128;
        }
        if ( ( pWork.flag & 1U ) != 0U )
        {
            num |= 1;
        }
        if ( ( pWork.move_flag & 524288U ) != 0U )
        {
            num |= 64;
        }
        return num;
    }

    // Token: 0x06000122 RID: 290 RVA: 0x0000B694 File Offset: 0x00009894
    private static void objDiffCollisionDirWidthCheck( AppMain.OBS_OBJECT_WORK pWork, byte ucWall, int sSpd )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        short num = 0;
        short num2 = 0;
        short num3 = 0;
        short num4 = 0;
        byte b = 0;
        byte b2 = 0;
        obs_COL_CHK_DATA.flag = AppMain.objDiffSufSet( pWork );
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA2 = obs_COL_CHK_DATA;
        obs_COL_CHK_DATA2.flag |= 128;
        int num5 = pWork.pos.x >> 12;
        int num6 = pWork.pos.y >> 12;
        ushort num7 = 16384;
        if ( ( pWork.dir.z + 8192 & 49152 ) >> 14 == 2 )
        {
            num7 += 32768;
        }
        if ( ( pWork.disp_flag & 1U ) == 0U )
        {
            num7 = ( ushort )-num7;
            b = 1;
        }
        num7 += pWork.dir_fall;
        switch ( pWork.dir_fall + 8192 >> 14 & 3 )
        {
            case 2:
                b ^= 1;
                num7 -= 32768;
                break;
        }
        if ( ( pWork.dir.z + 8192 & 49152 ) >> 14 == 2 )
        {
            b ^= 1;
        }
        if ( ( pWork.move_flag & 16U ) == 0U )
        {
            num7 += pWork.dir.z;
        }
        sbyte b3 = AppMain.objDiffCollisionSimpleOverCheck(pWork);
        if ( b3 > -4 )
        {
            b3 = 4;
        }
        else
        {
            b3 = ( sbyte )( -b3 + 1 );
        }
        if ( b3 >= ( sbyte )( pWork.field_rect[3] - pWork.field_rect[1] ) )
        {
            b3 = ( sbyte )( pWork.field_rect[3] - pWork.field_rect[1] - 1 );
        }
        switch ( ( num7 + 8192 & 49152 ) >> 14 )
        {
            case 0:
                num2 = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_w_db_f );
                num4 = num2;
                num = ( short )( pWork.field_rect[3] - ( short )pWork.field_ajst_w_db_b );
                num3 = ( short )( pWork.field_rect[1] + ( short )b3 );
                if ( b != 0 )
                {
                    num = ( short )-num;
                    num3 = ( short )-num3;
                }
                obs_COL_CHK_DATA.vec = 2;
                break;
            case 1:
                num = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_w_dl_f );
                num3 = num;
                num2 = ( short )( pWork.field_rect[3] - ( short )pWork.field_ajst_w_dl_b );
                num4 = ( short )( pWork.field_rect[1] + ( short )b3 );
                if ( b != 0 )
                {
                    num2 = ( short )-num2;
                    num4 = ( short )-num4;
                }
                obs_COL_CHK_DATA.vec = 1;
                break;
            case 2:
                num2 = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_w_dt_f );
                num4 = num2;
                num = ( short )( -( pWork.field_rect[3] - ( short )pWork.field_ajst_w_dt_b ) );
                num3 = ( short )( -( pWork.field_rect[1] + ( short )b3 ) );
                obs_COL_CHK_DATA.vec = 3;
                if ( b != 0 )
                {
                    num = ( short )-num;
                    num3 = ( short )-num3;
                }
                break;
            case 3:
                num = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_w_dr_f );
                num3 = num;
                num2 = ( short )( -( pWork.field_rect[3] - ( short )pWork.field_ajst_w_dr_b ) );
                num4 = ( short )( -( pWork.field_rect[1] + ( short )b3 ) );
                obs_COL_CHK_DATA.vec = 0;
                if ( b != 0 )
                {
                    num2 = ( short )-num2;
                    num4 = ( short )-num4;
                }
                break;
        }
        obs_COL_CHK_DATA.pos_x = num5 + ( int )num;
        obs_COL_CHK_DATA.pos_y = num6 + ( int )num2;
        sbyte b4 = (sbyte)AppMain.ObjCollisionUnion(pWork, obs_COL_CHK_DATA);
        obs_COL_CHK_DATA.pos_x = num5 + ( int )num3;
        obs_COL_CHK_DATA.pos_y = num6 + ( int )num4;
        sbyte b5 = (sbyte)AppMain.ObjCollisionUnion(pWork, obs_COL_CHK_DATA);
        if ( b4 >= b5 )
        {
            b4 = b5;
        }
        sbyte b6 = b4;
        if ( b4 <= 0 )
        {
            b2 |= 1;
            if ( ucWall == 0 )
            {
                AppMain.objDiffColDirMove( ref num5, ref num6, b4, obs_COL_CHK_DATA.vec );
            }
            else
            {
                pWork.move_flag |= 4U;
                if ( ( pWork.move_flag & 16384U ) == 0U )
                {
                    if ( ( pWork.dir_fall + 8192 & 16384 ) != 0 )
                    {
                        if ( obs_COL_CHK_DATA.vec == 3 && sSpd < 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                        if ( obs_COL_CHK_DATA.vec == 2 && sSpd > 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                    }
                    else
                    {
                        if ( obs_COL_CHK_DATA.vec == 1 && sSpd < 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                        if ( obs_COL_CHK_DATA.vec == 0 && sSpd > 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                    }
                }
                if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 && ( pWork.move_flag & 16384U ) == 0U && !AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
                {
                    pWork.spd_m = 0;
                }
            }
        }
        num7 += 32768;
        switch ( ( num7 + 8192 & 49152 ) >> 14 )
        {
            case 0:
                num2 = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_w_db_f );
                num4 = num2;
                num = ( short )( -( pWork.field_rect[3] - ( short )pWork.field_ajst_w_db_b ) );
                num3 = ( short )( -( pWork.field_rect[1] + ( short )b3 ) );
                obs_COL_CHK_DATA.vec = 2;
                if ( b != 0 )
                {
                    num = ( short )-num;
                    num3 = ( short )-num3;
                }
                break;
            case 1:
                num = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_w_dl_f );
                num3 = num;
                num2 = ( short )( -( pWork.field_rect[3] - ( short )pWork.field_ajst_w_dl_b ) );
                num4 = ( short )( -( pWork.field_rect[1] + ( short )b3 ) );
                obs_COL_CHK_DATA.vec = 1;
                if ( b != 0 )
                {
                    num2 = ( short )-num2;
                    num4 = ( short )-num4;
                }
                break;
            case 2:
                num2 = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_w_dt_f );
                num4 = num2;
                num = ( short )( pWork.field_rect[3] - ( short )pWork.field_ajst_w_dt_b );
                num3 = ( short )( pWork.field_rect[1] + ( short )b3 );
                obs_COL_CHK_DATA.vec = 3;
                if ( b != 0 )
                {
                    num = ( short )( -num );
                    num3 = ( short )( -num3 );
                }
                break;
            case 3:
                num = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_w_dr_f );
                num3 = num;
                num2 = ( short )( pWork.field_rect[3] - ( short )pWork.field_ajst_w_dr_b );
                num4 = ( short )( pWork.field_rect[1] + ( short )b3 );
                obs_COL_CHK_DATA.vec = 0;
                if ( b != 0 )
                {
                    num2 = ( short )-num2;
                    num4 = ( short )-num4;
                }
                break;
        }
        obs_COL_CHK_DATA.pos_x = num5 + ( int )num;
        obs_COL_CHK_DATA.pos_y = num6 + ( int )num2;
        b4 = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
        obs_COL_CHK_DATA.pos_x = num5 + ( int )num3;
        obs_COL_CHK_DATA.pos_y = num6 + ( int )num4;
        b5 = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
        if ( b4 >= b5 )
        {
            b4 = b5;
        }
        if ( b4 <= 0 )
        {
            b2 |= 2;
            if ( ucWall == 0 )
            {
                AppMain.objDiffColDirMove( ref num5, ref num6, b4, obs_COL_CHK_DATA.vec );
            }
            else
            {
                if ( ( pWork.move_flag & 4U ) == 0U || b6 < 0 || b4 < 0 )
                {
                    pWork.move_flag |= 8U;
                }
                if ( ( pWork.move_flag & 16384U ) == 0U )
                {
                    if ( ( pWork.dir_fall + 8192 & 16384 ) != 0 )
                    {
                        if ( obs_COL_CHK_DATA.vec == 3 && sSpd < 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                        if ( obs_COL_CHK_DATA.vec == 2 && sSpd > 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                    }
                    else
                    {
                        if ( obs_COL_CHK_DATA.vec == 1 && sSpd < 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                        if ( obs_COL_CHK_DATA.vec == 0 && sSpd > 0 )
                        {
                            pWork.spd_m = 0;
                            if ( ( pWork.move_flag & 536870912U ) == 0U )
                            {
                                pWork.spd.x = 0;
                            }
                        }
                    }
                }
            }
        }
        if ( ucWall == 0 )
        {
            pWork.pos.x = pWork.pos.x - ( ( pWork.pos.x >> 12 ) - num5 << 12 );
            pWork.pos.y = pWork.pos.y - ( ( pWork.pos.y >> 12 ) - num6 << 12 );
            if ( ( b2 & 3 ) != 0 && sSpd != 0 )
            {
                bool flag = (b2 & 2) == 2;
                bool flag2 = (pWork.disp_flag & 1U) == 1U;
                bool flag3 = sSpd > 0;
                if ( pWork.dir_fall == 49152 )
                {
                    flag3 = ( sSpd < 0 );
                }
                if ( flag ^ flag2 ^ flag3 )
                {
                    int num8;
                    if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 )
                    {
                        num8 = pWork.pos.y;
                    }
                    else
                    {
                        num8 = pWork.pos.x;
                    }
                    if ( sSpd > 0 )
                    {
                        if ( ( ( long )num8 & 4095L ) > 2048L )
                        {
                            num8 &= -4096;
                            num8 |= 2048;
                        }
                    }
                    else if ( ( ( long )num8 & 4095L ) < 2048L )
                    {
                        num8 &= -4096;
                        num8 |= 2048;
                    }
                    if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 )
                    {
                        pWork.pos.y = num8;
                    }
                    else
                    {
                        pWork.pos.x = num8;
                    }
                }
            }
        }
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
    }

    // Token: 0x06000123 RID: 291 RVA: 0x0000BF34 File Offset: 0x0000A134
    private static sbyte objDiffCollisionSimpleOverCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.flag = AppMain.objDiffSufSet( pWork );
        ushort num;
        if ( ( pWork.move_flag & 16U ) != 0U )
        {
            num = 0;
        }
        else
        {
            num = ( ushort )( ( pWork.dir.z + 8192 & 49152 ) >> 14 );
        }
        if ( pWork.dir_fall != 0 )
        {
            num += ( ushort )( ( pWork.dir_fall + 8192 & 49152 ) >> 14 );
            num &= 3;
        }
        short num2;
        short num3;
        short num4;
        short num5;
        switch ( num )
        {
            default:
                num2 = ( short )( pWork.field_rect[2] - 2 );
                num3 = ( short )( pWork.field_rect[0] + 2 );
                num4 = pWork.field_rect[1];
                num5 = pWork.field_rect[1];
                obs_COL_CHK_DATA.vec = 3;
                break;
            case 1:
                num4 = ( short )( pWork.field_rect[0] + 2 );
                num5 = ( short )( pWork.field_rect[2] - 2 );
                num2 = ( short )( -pWork.field_rect[1] );
                num3 = ( short )( -pWork.field_rect[1] );
                obs_COL_CHK_DATA.vec = 0;
                break;
            case 2:
                num2 = ( short )( pWork.field_rect[2] - 2 );
                num3 = ( short )( pWork.field_rect[0] + 2 );
                num4 = ( short )( -pWork.field_rect[1] );
                num5 = ( short )( -pWork.field_rect[1] );
                obs_COL_CHK_DATA.vec = 2;
                break;
            case 3:
                num4 = ( short )( pWork.field_rect[0] + 2 );
                num5 = ( short )( pWork.field_rect[2] - 2 );
                num2 = pWork.field_rect[1];
                num3 = pWork.field_rect[1];
                obs_COL_CHK_DATA.vec = 1;
                break;
        }
        obs_COL_CHK_DATA.pos_x = ( pWork.pos.x >> 12 ) + ( int )num2;
        obs_COL_CHK_DATA.pos_y = ( pWork.pos.y >> 12 ) + ( int )num4;
        sbyte b = (sbyte)AppMain.ObjCollisionUnion(pWork, obs_COL_CHK_DATA);
        obs_COL_CHK_DATA.pos_x = ( pWork.pos.x >> 12 ) + ( int )num3;
        obs_COL_CHK_DATA.pos_y = ( pWork.pos.y >> 12 ) + ( int )num5;
        sbyte b2 = (sbyte)AppMain.ObjCollisionUnion(pWork, obs_COL_CHK_DATA);
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        sbyte b3;
        if ( b < b2 )
        {
            b3 = b;
        }
        else
        {
            b3 = b2;
        }
        if ( b3 <= 0 )
        {
            return b3;
        }
        return 0;
    }

    // Token: 0x06000124 RID: 292 RVA: 0x0000C13C File Offset: 0x0000A33C
    private static void objDiffCollisionDirHeightCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        AppMain.OBS_OBJECT_WORK ride_obj = pWork.ride_obj;
        uint[] array = AppMain.objDiffCollisionDirHeightCheck_ulAttr;
        array[0] = 0U;
        ushort[] array2 = AppMain.objDiffCollisionDirHeightCheck_usDir1;
        array2[0] = 0;
        ushort[] array3 = AppMain.objDiffCollisionDirHeightCheck_usDir2;
        array3[0] = 0;
        ushort[] array4 = AppMain.objDiffCollisionDirHeightCheck_usDir3;
        array4[0] = 0;
        bool flag = false;
        obs_COL_CHK_DATA.flag = AppMain.objDiffSufSet( pWork );
        int num = pWork.pos.x >> 12;
        int num2 = pWork.pos.y >> 12;
        array2[0] = ( array3[0] = pWork.dir.z );
        ushort num3;
        if ( ( pWork.move_flag & 16U ) != 0U )
        {
            num3 = 0;
        }
        else
        {
            num3 = ( ushort )( ( pWork.dir.z + 8192 & 49152 ) >> 14 );
        }
        if ( pWork.dir_fall != 0 )
        {
            num3 += ( ushort )( ( pWork.dir_fall + 8192 & 49152 ) >> 14 );
            num3 &= 3;
        }
        short num4;
        short num5;
        short num6;
        short num7;
        short num8;
        short num9;
        int num10;
        int num11;
        switch ( num3 )
        {
            default:
                num4 = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_h_db_r );
                num5 = pWork.field_rect[3];
                num6 = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_h_db_l );
                num7 = pWork.field_rect[3];
                num8 = 0;
                num9 = ( short )( -( short )AppMain.g_obj.col_through_dot );
                obs_COL_CHK_DATA.vec = 2;
                num10 = pWork.move.x;
                num11 = pWork.move.y;
                break;
            case 1:
                num4 = ( short )( -pWork.field_rect[3] );
                num5 = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_h_dl_l );
                num6 = ( short )( -pWork.field_rect[3] );
                num7 = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_h_dl_r );
                num8 = ( short )( pWork.field_rect[3] - Math.Abs( pWork.field_rect[2] ) );
                num9 = 0;
                obs_COL_CHK_DATA.vec = 1;
                num11 = -pWork.move.x;
                num10 = -pWork.move.y;
                break;
            case 2:
                num4 = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_h_dt_r );
                num5 = ( short )( -pWork.field_rect[3] );
                num6 = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_h_dt_l );
                num7 = ( short )( -pWork.field_rect[3] );
                num8 = 0;
                num9 = ( short )AppMain.g_obj.col_through_dot;
                obs_COL_CHK_DATA.vec = 3;
                num10 = -pWork.move.x;
                num11 = -pWork.move.y;
                break;
            case 3:
                num4 = ( short )( pWork.field_rect[3] );
                num5 = ( short )( pWork.field_rect[0] - ( short )pWork.field_ajst_h_dr_l );
                num6 = ( short )( pWork.field_rect[3] );
                num7 = ( short )( pWork.field_rect[2] + ( short )pWork.field_ajst_h_dr_r );
                num8 = ( short )( -( pWork.field_rect[3] - Math.Abs( pWork.field_rect[0] ) ) );
                num9 = 0;
                obs_COL_CHK_DATA.vec = 0;
                num11 = pWork.move.x;
                num10 = pWork.move.y;
                break;
        }
        sbyte b;
        sbyte b2;
        sbyte b3;
        if ( ( pWork.move_flag & 32U ) == 0U )
        {
            if ( ( pWork.move_flag & 4194304U ) == 0U )
            {
                ushort flag2 = obs_COL_CHK_DATA.flag;
                AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA2 = obs_COL_CHK_DATA;
                obs_COL_CHK_DATA2.flag &= 65407;
                obs_COL_CHK_DATA.pos_x = num + ( int )( num4 + num8 );
                obs_COL_CHK_DATA.pos_y = num2 + ( int )( num5 + num9 );
                b = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
                obs_COL_CHK_DATA.pos_x = num + ( int )( num6 + num8 );
                obs_COL_CHK_DATA.pos_y = num2 + ( int )( num7 + num9 );
                b2 = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
                obs_COL_CHK_DATA.flag = flag2;
                pWork.ride_obj = ride_obj;
                if ( b < b2 )
                {
                    b3 = b;
                }
                else
                {
                    b3 = b2;
                }
                if ( b3 >= 0 )
                {
                    pWork.move_flag |= 1048576U;
                }
                else
                {
                    pWork.move_flag &= 4293918719U;
                }
            }
            else if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 || ( pWork.col_flag_prev & 4U ) != 0U )
            {
                pWork.move_flag |= 1048576U;
            }
            else
            {
                pWork.move_flag &= 4293918719U;
            }
        }
        if ( ( pWork.move_flag & 1048576U ) == 0U )
        {
            AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA3 = obs_COL_CHK_DATA;
            obs_COL_CHK_DATA3.flag |= 128;
        }
        obs_COL_CHK_DATA.attr = array;
        obs_COL_CHK_DATA.dir = array2;
        obs_COL_CHK_DATA.pos_x = num + ( int )num4;
        obs_COL_CHK_DATA.pos_y = num2 + ( int )num5;
        b = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
        AppMain.objDiffAttrSet( pWork, array[0] );
        obs_COL_CHK_DATA.dir = array3;
        obs_COL_CHK_DATA.pos_x = num + ( int )num6;
        obs_COL_CHK_DATA.pos_y = num2 + ( int )num7;
        b2 = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
        AppMain.objDiffAttrSet( pWork, array[0] );
        obs_COL_CHK_DATA.dir = array4;
        obs_COL_CHK_DATA.attr = null;
        obs_COL_CHK_DATA.pos_y = num2 + ( int )num5;
        if ( ( pWork.move_flag & 2097152U ) != 0U && ( pWork.move_flag & 512U ) == 0U )
        {
            short num12;
            int num13;
            if ( num4 > num6 )
            {
                num12 = ( short )( num4 - num6 - 1 );
                num13 = num + ( int )num6;
            }
            else
            {
                num12 = ( short )( num6 - num4 - 1 );
                num13 = num + ( int )num4;
            }
            byte b4 = 1;
            while ( ( short )b4 < num12 )
            {
                obs_COL_CHK_DATA.pos_x = num13 + ( int )b4;
                b3 = ( sbyte )AppMain.ObjCollisionObjectCheck( pWork, obs_COL_CHK_DATA );
                if ( b3 < b )
                {
                    b = b3;
                    array2 = array4;
                }
                b4 += 1;
            }
        }
        obs_COL_CHK_DATA.dir = null;
        obs_COL_CHK_DATA.attr = array;
        if ( ( num3 & 1 ) != 0 )
        {
            obs_COL_CHK_DATA.pos_x = num + ( int )num4;
            if ( num5 < num7 )
            {
                obs_COL_CHK_DATA.pos_y = num2 + ( int )num5 + ( Math.Abs( num5 ) + Math.Abs( num7 ) >> 1 );
            }
            else
            {
                obs_COL_CHK_DATA.pos_y = num2 + ( int )num7 + ( Math.Abs( num5 ) + Math.Abs( num7 ) >> 1 );
            }
        }
        else
        {
            obs_COL_CHK_DATA.pos_y = num2 + ( int )num7;
            if ( num4 < num6 )
            {
                obs_COL_CHK_DATA.pos_x = num + ( int )num4 + ( Math.Abs( num4 ) + Math.Abs( num6 ) >> 1 );
            }
            else
            {
                obs_COL_CHK_DATA.pos_x = num + ( int )num6 + ( Math.Abs( num4 ) + Math.Abs( num6 ) >> 1 );
            }
        }
        AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
        AppMain.objDiffAttrSet( pWork, array[0] );
        if ( ( pWork.col_flag & 4U ) != 0U && ( pWork.move_flag & 16U ) != 0U && num11 > 0 && ( pWork.col_flag & 1U ) == 0U && ( ( array2[0] + pWork.dir_fall >= 16384 && array2[0] + pWork.dir_fall <= 49152 ) || ( array3[0] + pWork.dir_fall >= 16384 && array3[0] + pWork.dir_fall <= 49152 ) ) )
        {
            b = 24;
            b2 = 24;
        }
        if ( b < b2 )
        {
            b3 = b;
        }
        else
        {
            b3 = b2;
        }
        if ( b3 != 0 )
        {
            if ( b3 < 0 )
            {
                if ( ( ( pWork.move_flag & 16U ) == 0U || num11 >= 0 ) && ( pWork.sys_flag & 17U << ( int )num3 ) == 0U )
                {
                    pWork.move_flag |= 1U;
                }
                if ( ( ( pWork.move_flag & 1073741824U ) == 0U && b3 >= -14 && ( pWork.move_flag & 1U ) != 0U ) || ( ( pWork.move_flag & 1073741824U ) != 0U && b3 >= -28 ) )
                {
                    if ( b3 < -16 && ( pWork.move_flag & 1073741824U ) != 0U )
                    {
                        flag = true;
                    }
                    AppMain.objDiffColDirMove( ref num, ref num2, b3, obs_COL_CHK_DATA.vec );
                    pWork.move_flag &= 4294901759U;
                }
            }
            else
            {
                if ( b3 == 1 )
                {
                    pWork.move_flag |= 65536U;
                }
                if ( ( pWork.move_flag & 16U ) == 0U )
                {
                    sbyte b5;
                    if ( ( num3 & 1 ) != 0 )
                    {
                        b5 = ( sbyte )( ( Math.Abs( num11 ) >> 12 ) + 3 );
                    }
                    else
                    {
                        b5 = ( sbyte )( ( Math.Abs( num10 ) >> 12 ) + 3 );
                    }
                    if ( b5 > 11 )
                    {
                        b5 = 11;
                    }
                    if ( b3 <= b5 && ( pWork.sys_flag & 17U << ( int )num3 ) == 0U )
                    {
                        pWork.move_flag |= 1U;
                        AppMain.objDiffColDirMove( ref num, ref num2, b3, obs_COL_CHK_DATA.vec );
                        if ( ( pWork.move_flag & 512U ) == 0U && ( pWork.move_flag & 64U ) == 0U && pWork.touch_obj == null )
                        {
                            obs_COL_CHK_DATA.attr = null;
                            obs_COL_CHK_DATA.dir = null;
                            obs_COL_CHK_DATA.pos_x = num + ( int )num4;
                            obs_COL_CHK_DATA.pos_y = num2 + ( int )num5;
                            AppMain.ObjCollisionObjectCheck( pWork, obs_COL_CHK_DATA );
                            obs_COL_CHK_DATA.pos_x = num + ( int )num6;
                            obs_COL_CHK_DATA.pos_y = num2 + ( int )num7;
                            AppMain.ObjCollisionObjectCheck( pWork, obs_COL_CHK_DATA );
                        }
                    }
                    else
                    {
                        pWork.move_flag &= 4294967294U;
                    }
                }
            }
        }
        else if ( ( ( pWork.move_flag & 16U ) == 0U || pWork.spd.y >= 0 ) && ( pWork.sys_flag & 17U << ( int )num3 ) == 0U )
        {
            pWork.move_flag |= 1U;
        }
        if ( ( pWork.move_flag & 1U ) != 0U )
        {
            if ( ( pWork.move_flag & 268435456U ) == 0U )
            {
                if ( ( pWork.col_flag & 1U ) == 0U && ( pWork.move_flag & 64U ) != 0U )
                {
                    if ( b >= b2 )
                    {
                        if ( b > b2 )
                        {
                            array2 = array3;
                        }
                        else if ( Math.Abs( ( int )( pWork.dir.z + pWork.dir_fall - array2[0] ) ) > Math.Abs( ( int )( pWork.dir.z + pWork.dir_fall - array3[0] ) ) )
                        {
                            array2 = array3;
                        }
                    }
                    if ( ( pWork.move_flag & 8388608U ) != 0U )
                    {
                        pWork.dir.z = AppMain.ObjRoopMove16( pWork.dir.z, ( ushort )( array2[0] - pWork.dir_fall ), 256 );
                    }
                    else
                    {
                        pWork.dir.z = ( ushort )( array2[0] - pWork.dir_fall );
                    }
                }
                else if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() && ( pWork.move_flag & 4194304U ) == 0U )
                {
                    pWork.dir.z = ( ushort )( -( ( AppMain.g_gm_main_system.pseudofall_dir + 8192 & 16383 ) - 8192 ) );
                }
            }
            if ( ( pWork.move_flag & 16384U ) == 0U && ( pWork.move_flag & 536870912U ) == 0U )
            {
                if ( ( pWork.move_flag & 16U ) != 0U )
                {
                    num3 = 0;
                }
                else
                {
                    num3 = ( ushort )( ( pWork.dir.z + 8192 & 49152 ) >> 14 );
                }
                switch ( num3 )
                {
                    default:
                        if ( pWork.spd.y > 0 )
                        {
                            if ( ( pWork.move_flag & 131072U ) != 0U )
                            {
                                pWork.spd.x = pWork.spd.x + ( pWork.spd.y * AppMain.mtMathSin( ( int )( pWork.dir.z - AppMain.g_gm_main_system.pseudofall_dir + pWork.dir_fall ) ) >> 12 );
                            }
                            pWork.spd.y = 0;
                        }
                        break;
                    case 1:
                        if ( pWork.spd.x < 0 )
                        {
                            pWork.spd.x = 0;
                        }
                        break;
                    case 2:
                        if ( pWork.spd.y < 0 )
                        {
                            pWork.spd.y = 0;
                        }
                        break;
                    case 3:
                        if ( pWork.spd.x > 0 )
                        {
                            pWork.spd.x = 0;
                        }
                        break;
                }
            }
        }
        else
        {
            pWork.ride_obj = ride_obj;
        }
        if ( ( pWork.move_flag & 1073741824U ) != 0U || num11 < 256 )
        {
            AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA4 = obs_COL_CHK_DATA;
            obs_COL_CHK_DATA4.flag |= 128;
            switch ( obs_COL_CHK_DATA.vec )
            {
                case 0:
                    num4 = ( short )( pWork.field_rect[0] + 2 );
                    num6 = ( short )( pWork.field_rect[0] + 2 );
                    obs_COL_CHK_DATA.vec = 1;
                    break;
                case 1:
                    num4 = ( short )( pWork.field_rect[2] - 2 );
                    num6 = ( short )( pWork.field_rect[2] - 2 );
                    obs_COL_CHK_DATA.vec = 0;
                    break;
                default:
                    num5 = ( short )( pWork.field_rect[1] + 2 );
                    num7 = ( short )( pWork.field_rect[1] + 2 );
                    obs_COL_CHK_DATA.vec = 3;
                    break;
                case 3:
                    num5 = ( short )( pWork.field_rect[3] - 2 );
                    num7 = ( short )( pWork.field_rect[3] - 2 );
                    obs_COL_CHK_DATA.vec = 2;
                    break;
            }
            obs_COL_CHK_DATA.attr = null;
            obs_COL_CHK_DATA.dir = null;
            obs_COL_CHK_DATA.pos_x = num + ( int )num4;
            obs_COL_CHK_DATA.pos_y = num2 + ( int )num5;
            b = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
            obs_COL_CHK_DATA.pos_x = num + ( int )num6;
            obs_COL_CHK_DATA.pos_y = num2 + ( int )num7;
            b2 = ( sbyte )AppMain.ObjCollisionUnion( pWork, obs_COL_CHK_DATA );
            sbyte b6;
            if ( b < b2 )
            {
                b6 = b;
            }
            else
            {
                b6 = b2;
            }
            if ( b6 <= 0 )
            {
                pWork.move_flag |= 2U;
                if ( ( ( pWork.move_flag & 1073741824U ) == 0U && b6 >= -14 ) || ( ( pWork.move_flag & 1073741824U ) != 0U && b6 >= -28 ) )
                {
                    if ( flag && ( pWork.move_flag & 1U ) != 0U )
                    {
                        if ( b3 > b6 )
                        {
                            AppMain.objDiffColDirMove( ref num, ref num2, ( sbyte )( b6 - b3 ), obs_COL_CHK_DATA.vec );
                        }
                    }
                    else
                    {
                        AppMain.objDiffColDirMove( ref num, ref num2, b6, obs_COL_CHK_DATA.vec );
                    }
                    if ( AppMain.g_gm_main_system.pseudofall_dir == 0 )
                    {
                        if ( ( pWork.move_flag & 16384U ) == 0U && ( pWork.move_flag & 536870912U ) == 0U && num11 < 0 )
                        {
                            if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 )
                            {
                                pWork.spd.y = 0;
                            }
                            else
                            {
                                pWork.spd.x = 0;
                            }
                        }
                    }
                    else if ( ( pWork.move_flag & 16384U ) == 0U )
                    {
                        pWork.spd_m = 0;
                        if ( ( pWork.move_flag & 536870912U ) == 0U )
                        {
                            pWork.spd.x = 0;
                            pWork.spd.y = 0;
                        }
                    }
                }
            }
        }
        pWork.pos.x = pWork.pos.x - ( ( pWork.pos.x >> 12 ) - num << 12 );
        pWork.pos.y = pWork.pos.y - ( ( pWork.pos.y >> 12 ) - num2 << 12 );
        if ( ( pWork.move_flag & 1U ) != 0U )
        {
            int num14;
            if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 )
            {
                num14 = pWork.pos.y;
            }
            else
            {
                num14 = pWork.pos.x;
            }
            if ( num11 > 0 )
            {
                if ( ( ( long )num14 & 4095L ) > 2048L )
                {
                    num14 &= -4096;
                    num14 |= 2048;
                }
            }
            else if ( ( ( long )num14 & 4095L ) < 2048L )
            {
                num14 &= -4096;
                num14 |= 2048;
            }
            if ( ( obs_COL_CHK_DATA.vec & 2 ) != 0 )
            {
                pWork.pos.y = num14;
            }
            else
            {
                pWork.pos.x = num14;
            }
        }
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
    }

    // Token: 0x06000125 RID: 293 RVA: 0x0000CF1C File Offset: 0x0000B11C
    private static void objDiffColDirMove( ref int lPosX, ref int lPosY, sbyte cDelta, ushort usColFlag )
    {
        switch ( usColFlag )
        {
            case 0:
                lPosX += ( int )cDelta;
                return;
            case 1:
                lPosX -= ( int )cDelta;
                return;
            default:
                lPosY += ( int )cDelta;
                return;
            case 3:
                lPosY -= ( int )cDelta;
                return;
        }
    }

    // Token: 0x06000329 RID: 809 RVA: 0x0001928F File Offset: 0x0001748F
    private static void ObjSetDiffCollision( AppMain.OBS_DIFF_COLLISION pFat )
    {
        AppMain._obj_fcol = pFat;
    }

    // Token: 0x0600032A RID: 810 RVA: 0x00019297 File Offset: 0x00017497
    private static AppMain.OBS_DIFF_COLLISION ObjGetDiffCollision()
    {
        return AppMain._obj_fcol;
    }

    // Token: 0x0600032B RID: 811 RVA: 0x000192A0 File Offset: 0x000174A0
    private static int ObjDiffCollisionDetFast( int lPosX, int lPosY, ushort usFlag, ushort usVec, ushort[] pDir, uint[] pAttr )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.pos_x = lPosX;
        obs_COL_CHK_DATA.pos_y = lPosY;
        obs_COL_CHK_DATA.dir = pDir;
        obs_COL_CHK_DATA.attr = pAttr;
        obs_COL_CHK_DATA.flag = usFlag;
        obs_COL_CHK_DATA.vec = usVec;
        int result = AppMain.ObjDiffCollisionFast(obs_COL_CHK_DATA);
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return result;
    }

    // Token: 0x0600032C RID: 812 RVA: 0x000192F0 File Offset: 0x000174F0
    private static int ObjDiffCollisionFast( AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 0;
        ushort num2 = 0;
        uint num3 = 0U;
        sbyte sDelta = 8;
        if ( AppMain._obj_fcol.cl_diff_datap == null )
        {
            switch ( pData.vec )
            {
                case 0:
                    num = AppMain._obj_fcol.right - pData.pos_x;
                    break;
                case 1:
                    num = pData.pos_x - AppMain._obj_fcol.left;
                    break;
                case 2:
                    num = AppMain._obj_fcol.bottom - pData.pos_y;
                    break;
                case 3:
                    num = pData.pos_y - AppMain._obj_fcol.top;
                    break;
            }
            return AppMain.MTM_MATH_CLIP( num, -31, 31 );
        }
        if ( pData.dir != null )
        {
            num2 = pData.dir[0];
        }
        if ( pData.attr != null )
        {
            num3 = pData.attr[0];
        }
        if ( ( pData.vec & 1 ) != 0 )
        {
            sDelta = -8;
        }
        sbyte sPix;
        if ( ( pData.vec & 2 ) != 0 )
        {
            num = AppMain.objGetColDataY( pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr );
            sPix = ( sbyte )( pData.pos_y & 7 );
        }
        else
        {
            num = AppMain.objGetColDataX( pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr );
            sPix = ( sbyte )( pData.pos_x & 7 );
        }
        if ( num == 0 )
        {
            if ( pData.dir != null )
            {
                pData.dir[0] = num2;
            }
            if ( pData.attr != null )
            {
                pData.attr[0] = num3;
            }
            return AppMain.field_objMapGetForward( sPix, sDelta );
        }
        if ( num == 8 )
        {
            return AppMain.field_objMapGetBack( sPix, sDelta );
        }
        return AppMain.field_objMapGetDiff( num, sPix, sDelta );
    }

    // Token: 0x0600032D RID: 813 RVA: 0x00019468 File Offset: 0x00017668
    private static int ObjDiffCollisionDet( int lPosX, int lPosY, ushort usFlag, ushort usVec, ushort[] pDir, uint[] pAttr )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.pos_x = lPosX;
        obs_COL_CHK_DATA.pos_y = lPosY;
        obs_COL_CHK_DATA.dir = pDir;
        obs_COL_CHK_DATA.attr = pAttr;
        obs_COL_CHK_DATA.flag = usFlag;
        obs_COL_CHK_DATA.vec = usVec;
        int result = AppMain.ObjDiffCollision(obs_COL_CHK_DATA);
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return result;
    }

    // Token: 0x0600032E RID: 814 RVA: 0x000194B8 File Offset: 0x000176B8
    private static int ObjDiffCollision( AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        ushort num4 = 0;
        uint num5 = 0U;
        sbyte b = 0;
        sbyte b2 = 0;
        if ( AppMain._obj_fcol.cl_diff_datap == null )
        {
            switch ( pData.vec )
            {
                case 0:
                    num = AppMain._obj_fcol.right - pData.pos_x;
                    break;
                case 1:
                    num = pData.pos_x - AppMain._obj_fcol.left;
                    break;
                case 2:
                    num = AppMain._obj_fcol.bottom - pData.pos_y;
                    break;
                case 3:
                    num = pData.pos_y - AppMain._obj_fcol.top;
                    break;
            }
            return AppMain.MTM_MATH_CLIP( num, -31, 31 );
        }
        if ( pData.dir != null )
        {
            num4 = pData.dir[0];
        }
        if ( pData.attr != null )
        {
            num5 = pData.attr[0];
        }
        if ( ( pData.vec & 2 ) != 0 )
        {
            b2 = 8;
            if ( ( pData.vec & 1 ) != 0 )
            {
                b2 = -8;
            }
        }
        else
        {
            b = 8;
            if ( ( pData.vec & 1 ) != 0 )
            {
                b = -8;
            }
        }
        sbyte sPix;
        bool flag;
        if ( ( pData.vec & 2 ) != 0 )
        {
            sPix = ( sbyte )( pData.pos_y & 7 );
            flag = true;
            num = AppMain.objGetColDataY( pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr );
        }
        else
        {
            sPix = ( sbyte )( pData.pos_x & 7 );
            flag = false;
            num = AppMain.objGetColDataX( pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr );
        }
        if ( num == 0 )
        {
            num2 += ( int )b;
            num3 += ( int )b2;
            if ( flag )
            {
                num = AppMain.objGetColDataY( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
            }
            else
            {
                num = AppMain.objGetColDataX( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
            }
            if ( num == 0 )
            {
                num2 += ( int )b;
                num3 += ( int )b2;
                if ( flag )
                {
                    num = AppMain.objGetColDataY( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
                }
                else
                {
                    num = AppMain.objGetColDataX( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
                }
                if ( num == 0 )
                {
                    if ( pData.dir != null )
                    {
                        pData.dir[0] = num4;
                    }
                    if ( pData.attr != null )
                    {
                        pData.attr[0] = num5;
                    }
                    return AppMain.field_objMapGetForward( sPix, ( sbyte )( b + b2 ) ) + 16;
                }
                if ( num == 8 )
                {
                    return AppMain.field_objMapGetBack( sPix, ( sbyte )( b + b2 ) ) + 16;
                }
                return AppMain.field_objMapGetDiff( num, sPix, ( sbyte )( b + b2 ) ) + 16;
            }
            else
            {
                if ( num == 8 )
                {
                    return AppMain.field_objMapGetBack( sPix, ( sbyte )( b + b2 ) ) + 8;
                }
                return AppMain.field_objMapGetDiff( num, sPix, ( sbyte )( b + b2 ) ) + 8;
            }
        }
        else
        {
            if ( num != 8 )
            {
                return AppMain.field_objMapGetDiff( num, sPix, ( sbyte )( b + b2 ) );
            }
            if ( pData.dir != null )
            {
                num4 = pData.dir[0];
            }
            if ( pData.attr != null )
            {
                num5 = pData.attr[0];
            }
            num2 -= ( int )b;
            num3 -= ( int )b2;
            if ( flag )
            {
                num = AppMain.objGetColDataY( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
            }
            else
            {
                num = AppMain.objGetColDataX( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
            }
            if ( num == 8 )
            {
                if ( pData.dir != null )
                {
                    num4 = pData.dir[0];
                }
                if ( pData.attr != null )
                {
                    num5 = pData.attr[0];
                }
                num2 -= ( int )b;
                num3 -= ( int )b2;
                if ( flag )
                {
                    num = AppMain.objGetColDataY( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
                }
                else
                {
                    num = AppMain.objGetColDataX( pData.pos_x + num2, pData.pos_y + num3, pData.flag, pData.dir, pData.attr );
                }
                if ( num == 0 )
                {
                    if ( pData.dir != null )
                    {
                        pData.dir[0] = num4;
                    }
                    if ( pData.attr != null )
                    {
                        pData.attr[0] = num5;
                    }
                    return AppMain.field_objMapGetForwardRev( sPix, ( sbyte )( b + b2 ) ) - 16;
                }
                if ( num == 8 )
                {
                    return AppMain.field_objMapGetBack( sPix, ( sbyte )( b + b2 ) ) - 16;
                }
                return AppMain.field_objMapGetDiff( num, sPix, ( sbyte )( b + b2 ) ) - 16;
            }
            else
            {
                if ( num == 0 )
                {
                    if ( pData.dir != null )
                    {
                        pData.dir[0] = num4;
                    }
                    if ( pData.attr != null )
                    {
                        pData.attr[0] = num5;
                    }
                    return AppMain.field_objMapGetForwardRev( sPix, ( sbyte )( b + b2 ) ) - 8;
                }
                return AppMain.field_objMapGetDiff( num, sPix, ( sbyte )( b + b2 ) ) - 8;
            }
        }
    }

    // Token: 0x0600032F RID: 815 RVA: 0x00019930 File Offset: 0x00017B30
    private static AppMain.MP_BLOCK objGetMapBlockData( int pos_x, int pos_y, ushort suf )
    {
        int num = pos_x >> 3;
        int num2 = pos_y >> 3;
        int num3 = num >> 3;
        int num4 = num2 >> 3;
        int num5 = (int)AppMain._obj_fcol.map_block_num_x * num4 + num3;
        if ( num5 < 0 )
        {
            num5 = 0;
        }
        return AppMain._obj_fcol.block_map_datap[( int )suf][num5];
    }

    // Token: 0x06000330 RID: 816 RVA: 0x00019984 File Offset: 0x00017B84
    private static byte[] objGetDiffCharData( int pos_x, int pos_y, ushort suf )
    {
        int num = pos_x >> 3;
        int num2 = pos_y >> 3;
        int num3 = num >> 3;
        int num4 = num2 >> 3;
        int pos_x2 = num - num3 * 8;
        int pos_y2 = num2 - num4 * 8;
        int num5 = (int)AppMain._obj_fcol.map_block_num_x * num4 + num3;
        if ( num5 < 0 )
        {
            num5 = 0;
        }
        AppMain.MP_BLOCK mp_BLOCK = AppMain._obj_fcol.block_map_datap[(int)suf][num5];
        int id = (int)mp_BLOCK.id;
        int num6;
        int num7;
        AppMain.objGetConv88Pos( pos_x2, pos_y2, ref mp_BLOCK, out num6, out num7 );
        AppMain.DF_BLOCK df_BLOCK = AppMain._obj_fcol.cl_diff_datap[id];
        AppMain.DF_BLOCK.DF_CELL df_CELL = df_BLOCK.df[num7, num6];
        byte[] diff_char = AppMain._objGetDiffCharData.diff_char;
        Buffer.BlockCopy( df_CELL.Data, df_CELL.Offset, diff_char, 0, 8 );
        return diff_char;
    }

    // Token: 0x06000331 RID: 817 RVA: 0x00019A40 File Offset: 0x00017C40
    private static sbyte objGetXDiffData( int pos_x, int pos_y, ushort suf )
    {
        byte[] array = AppMain.objGetDiffCharData(pos_x, pos_y, suf);
        int num = pos_x & 7;
        int num2 = pos_y & 7;
        AppMain.MP_BLOCK mp_block = AppMain.objGetMapBlockData(pos_x, pos_y, suf);
        AppMain.objGetConv88Pos( num, num2, ref mp_block, out num, out num2 );
        sbyte b;
        if ( ( mp_block.rot & 1 ) != 0 )
        {
            b = ( sbyte )array[num];
        }
        else
        {
            b = ( sbyte )array[num2];
        }
        b = ( sbyte )AppMain.objGetConvDiff( mp_block, ( byte )b );
        b &= 15;
        if ( ( b & 8 ) != 0 )
        {
            b |= -16;
        }
        if ( b == -8 )
        {
            b = 8;
        }
        return b;
    }

    // Token: 0x06000332 RID: 818 RVA: 0x00019ABC File Offset: 0x00017CBC
    private static sbyte objGetYDiffData( int pos_x, int pos_y, ushort suf )
    {
        byte[] array = AppMain.objGetDiffCharData(pos_x, pos_y, suf);
        int num = pos_x & 7;
        int num2 = pos_y & 7;
        AppMain.MP_BLOCK mp_block = AppMain.objGetMapBlockData(pos_x, pos_y, suf);
        AppMain.objGetConv88Pos( num, num2, ref mp_block, out num, out num2 );
        sbyte b;
        if ( ( mp_block.rot & 1 ) != 0 )
        {
            b = ( sbyte )array[num2];
        }
        else
        {
            b = ( sbyte )array[num];
        }
        b = ( sbyte )AppMain.objGetConvDiff( mp_block, ( byte )b );
        b = ( sbyte )( b >> 4 & 15 );
        if ( ( b & 8 ) != 0 )
        {
            b |= -16;
        }
        if ( b == -8 )
        {
            b = 8;
        }
        return b;
    }

    // Token: 0x06000333 RID: 819 RVA: 0x00019B38 File Offset: 0x00017D38
    private static ushort objGetDirData( int pos_x, int pos_y, ushort suf )
    {
        int num = pos_x >> 3;
        int num2 = pos_y >> 3;
        int num3 = num >> 3;
        int num4 = num2 >> 3;
        int pos_x2 = num - num3 * 8;
        int pos_y2 = num2 - num4 * 8;
        AppMain.MP_BLOCK mp_BLOCK = AppMain._obj_fcol.block_map_datap[(int)suf][(int)AppMain._obj_fcol.map_block_num_x * num4 + num3];
        int id = (int)mp_BLOCK.id;
        int rot = (int)mp_BLOCK.rot;
        int num5;
        int num6;
        AppMain.objGetConv88Pos( pos_x2, pos_y2, ref mp_BLOCK, out num5, out num6 );
        AppMain.DI_BLOCK di_BLOCK = AppMain._obj_fcol.direc_datap[id];
        ushort num7 = (ushort)(di_BLOCK.di[num6][num5] << 8);
        if ( mp_BLOCK.flip_h != 0 )
        {
            num7 = ( ushort )( -( ushort )( ( short )num7 ) );
        }
        if ( mp_BLOCK.flip_v != 0 )
        {
            num7 = ( ushort )( -( ( short )num7 + 16384 ) - 16384 );
        }
        num7 = ( ushort )( ( int )num7 + rot * 16384 );
        num7 = ( ushort )( -( ushort )( ( short )num7 ) );
        if ( ( ( ( int )num7 & -49153 ) ^ 8192 ) == 0 )
        {
            if ( ( num7 & 16384 ) != 0 )
            {
                num7 += 256;
            }
            else
            {
                num7 -= 256;
            }
        }
        return num7;
    }

    // Token: 0x06000334 RID: 820 RVA: 0x00019C40 File Offset: 0x00017E40
    private static void objGetConv88Pos( int pos_x, int pos_y, ref AppMain.MP_BLOCK mp_block, out int conv_pos_x, out int conv_pos_y )
    {
        int num;
        int num2;
        switch ( mp_block.rot )
        {
            case 1:
                num = 7 - pos_y;
                num2 = pos_x;
                break;
            case 2:
                num = 7 - pos_x;
                num2 = 7 - pos_y;
                break;
            case 3:
                num = pos_y;
                num2 = 7 - pos_x;
                break;
            default:
                num = pos_x;
                num2 = pos_y;
                break;
        }
        if ( mp_block.flip_h != 0 )
        {
            num = 7 - num;
        }
        if ( mp_block.flip_v != 0 )
        {
            num2 = 7 - num2;
        }
        conv_pos_x = num;
        conv_pos_y = num2;
    }

    // Token: 0x06000335 RID: 821 RVA: 0x00019CA8 File Offset: 0x00017EA8
    private static byte objGetConvDiff( AppMain.MP_BLOCK mp_block, byte diff )
    {
        byte b = (byte)(diff & 15);
        byte b2 = (byte)(diff >> 4 & 15);
        if ( mp_block.flip_h != 0 && ( b & 7 ) != 0 )
        {
            b = ( byte )( b + 8 & 15 );
        }
        if ( mp_block.flip_v != 0 && ( b2 & 7 ) != 0 )
        {
            b2 = ( byte )( b2 + 8 & 15 );
        }
        switch ( mp_block.rot )
        {
            case 1:
                {
                    byte b3 = b;
                    b = b2;
                    b2 = b3;
                    if ( ( b2 & 7 ) != 0 )
                    {
                        b2 = ( byte )( b2 + 8 & 15 );
                    }
                    break;
                }
            case 2:
                if ( ( b & 7 ) != 0 )
                {
                    b = ( byte )( b + 8 & 15 );
                }
                if ( ( b2 & 7 ) != 0 )
                {
                    b2 = ( byte )( b2 + 8 & 15 );
                }
                break;
            case 3:
                {
                    byte b3 = b;
                    b = b2;
                    b2 = b3;
                    if ( ( b & 7 ) != 0 )
                    {
                        b = ( byte )( b + 8 & 15 );
                    }
                    break;
                }
        }
        return ( byte )( ( int )( b & 15 ) | ( int )b2 << 4 );
    }

    // Token: 0x06000336 RID: 822 RVA: 0x00019D5C File Offset: 0x00017F5C
    private static int field_objMapGetDiff( int lCol, sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( lCol > 0 )
        {
            if ( sDelta > 0 )
            {
                result = lCol - ( int )( sPix + 1 );
            }
            else
            {
                result = ( int )( 8 - sPix );
            }
        }
        else if ( sDelta > 0 )
        {
            result = ( int )( -( int )( sPix + 1 ) );
        }
        else
        {
            result = lCol + ( int )sPix;
        }
        return result;
    }

    // Token: 0x06000337 RID: 823 RVA: 0x00019D90 File Offset: 0x00017F90
    private static int field_objMapGetForward( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( 8 - sPix );
        }
        else
        {
            result = ( int )( 1 + sPix );
        }
        return result;
    }

    // Token: 0x06000338 RID: 824 RVA: 0x00019DAC File Offset: 0x00017FAC
    private static int field_objMapGetBack( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( -( int )( sPix + 1 ) );
        }
        else
        {
            result = ( int )( sPix - 8 );
        }
        return result;
    }

    // Token: 0x06000339 RID: 825 RVA: 0x00019DCC File Offset: 0x00017FCC
    private int objMapGetBackFront( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( -( int )sPix );
        }
        else
        {
            result = ( int )( sPix - 8 );
        }
        return result;
    }

    // Token: 0x0600033A RID: 826 RVA: 0x00019DE8 File Offset: 0x00017FE8
    private static int field_objMapGetForwardRev( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( 8 - ( sPix + 1 ) );
        }
        else
        {
            result = ( int )sPix;
        }
        return result;
    }

    // Token: 0x0600033B RID: 827 RVA: 0x00019E04 File Offset: 0x00018004
    private static int objGetColDataX( int lPosX, int lPosY, ushort ucSuf, ushort[] pDir, uint[] pAttr )
    {
        sbyte b = 0;
        if ( ( ucSuf & 64 ) != 0 )
        {
            if ( ( int )( ( long )lPosX & unchecked(unchecked(( long )( ( ulong )-8 ))) ) > AppMain._obj_fcol.right - 1 || lPosX < AppMain._obj_fcol.left - 7 )
            {
                b = 8;
            }
            else if ( ( int )( ( ( long )lPosX & unchecked(unchecked(( long )( ( ulong )-8 ))) ) + 8L ) > AppMain._obj_fcol.right - 1 )
            {
                b = ( sbyte )( AppMain._obj_fcol.right - 1 & 7 );
                if ( b == 0 )
                {
                    b = 8;
                }
            }
            else if ( ( int )( ( long )lPosX & unchecked(unchecked(( long )( ( ulong )-8 ))) ) < AppMain._obj_fcol.left )
            {
                if ( ( AppMain._obj_fcol.left & 7 ) != 0 )
                {
                    b = ( sbyte )( 8 + ( 8 - ( AppMain._obj_fcol.left & 7 ) ) );
                }
                else
                {
                    b = 8;
                }
                b |= -16;
                if ( b == -8 )
                {
                    b = 8;
                }
            }
        }
        else
        {
            lPosX = AppMain.MTM_MATH_CLIP( lPosX, AppMain._obj_fcol.left, AppMain._obj_fcol.right - 1 );
            lPosY = AppMain.MTM_MATH_CLIP( lPosY, AppMain._obj_fcol.top, AppMain._obj_fcol.bottom - 1 );
        }
        sbyte b2 = AppMain.objGetXDiffData(lPosX, lPosY, (ushort)(ucSuf & 1));
        byte b3 = AppMain.objGetAttrData(lPosX, lPosY, (ushort)(ucSuf & 1));
        if ( ( ucSuf & 128 ) != 0 && ( b3 & 1 ) != 0 )
        {
            b2 = 0;
        }
        if ( Math.Abs( b2 ) < Math.Abs( b ) )
        {
            return ( int )b;
        }
        if ( pDir != null && b2 != 0 )
        {
            pDir[0] = AppMain.objGetDirData( lPosX, lPosY, ( ushort )( ucSuf & 1 ) );
        }
        if ( pAttr != null && b2 != 0 )
        {
            pAttr[0] = ( uint )b3;
        }
        return ( int )b2;
    }

    // Token: 0x0600033C RID: 828 RVA: 0x00019F5C File Offset: 0x0001815C
    private static int objGetColDataY( int lPosX, int lPosY, ushort ucSuf, ushort[] pDir, uint[] pAttr )
    {
        sbyte b;
        if ( ( ucSuf & 64 ) != 0 )
        {
            if ( ( int )( ( long )lPosY & unchecked(unchecked(( long )( ( ulong )-8 ))) ) > AppMain._obj_fcol.bottom - 1 || lPosY < AppMain._obj_fcol.top - 7 )
            {
                return 8;
            }
            if ( ( int )( ( ( long )lPosY & unchecked(unchecked(( long )( ( ulong )-8 ))) ) + 8L ) > AppMain._obj_fcol.bottom - 1 )
            {
                b = ( sbyte )( AppMain._obj_fcol.bottom - 1 & 7 );
                if ( b == 0 )
                {
                    b = 8;
                }
                return ( int )b;
            }
            if ( ( int )( ( long )lPosY & unchecked(unchecked(( long )( ( ulong )-8 ))) ) < AppMain._obj_fcol.top )
            {
                if ( ( AppMain._obj_fcol.top & 7 ) != 0 )
                {
                    b = ( sbyte )( 8 + ( 8 - ( AppMain._obj_fcol.top & 7 ) ) );
                }
                else
                {
                    b = 8;
                }
                b |= -16;
                if ( b == -8 )
                {
                    b = 8;
                }
                return ( int )b;
            }
        }
        else
        {
            lPosX = AppMain.MTM_MATH_CLIP( lPosX, AppMain._obj_fcol.left, AppMain._obj_fcol.right - 1 );
            lPosY = AppMain.MTM_MATH_CLIP( lPosY, AppMain._obj_fcol.top, AppMain._obj_fcol.bottom - 1 );
        }
        b = AppMain.objGetYDiffData( lPosX, lPosY, ( ushort )( ucSuf & 1 ) );
        byte b2 = AppMain.objGetAttrData(lPosX, lPosY, (ushort)(ucSuf & 1));
        if ( ( ucSuf & 128 ) != 0 && ( b2 & 1 ) != 0 )
        {
            b = 0;
        }
        if ( pDir != null && b != 0 )
        {
            pDir[0] = AppMain.objGetDirData( lPosX, lPosY, ( ushort )( ucSuf & 1 ) );
        }
        if ( pAttr != null && b != 0 )
        {
            pAttr[0] = ( uint )AppMain.objGetAttrData( lPosX, lPosY, ( ushort )( ucSuf & 1 ) );
        }
        return ( int )b;
    }

    // Token: 0x0600033D RID: 829 RVA: 0x0001A0A0 File Offset: 0x000182A0
    private static byte objGetAttrData( int pos_x, int pos_y, ushort suf )
    {
        int num = pos_x >> 3;
        int num2 = pos_y >> 3;
        int num3 = num >> 3;
        int num4 = num2 >> 3;
        int pos_x2 = num - num3 * 8;
        int pos_y2 = num2 - num4 * 8;
        int num5 = (int)AppMain._obj_fcol.map_block_num_x * num4 + num3;
        if ( num5 < 0 )
        {
            num5 = 0;
        }
        AppMain.MP_BLOCK mp_BLOCK = AppMain._obj_fcol.block_map_datap[(int)suf][num5];
        int id = (int)mp_BLOCK.id;
        int num6;
        int num7;
        AppMain.objGetConv88Pos( pos_x2, pos_y2, ref mp_BLOCK, out num6, out num7 );
        AppMain.AT_BLOCK at_BLOCK = AppMain._obj_fcol.char_attr_datap[id];
        return at_BLOCK.at[num7][num6];
    }

    // Token: 0x0600033E RID: 830 RVA: 0x0001A135 File Offset: 0x00018335
    private ushort ObjGetColDataDir( int lPosY, int lPosX, byte ucSuf )
    {
        return AppMain.objGetDirData( lPosX, lPosY, ( ushort )ucSuf );
    }

    // Token: 0x06001979 RID: 6521 RVA: 0x000E6384 File Offset: 0x000E4584
    private static void ObjObjectCollisionSet( AppMain.OBS_OBJECT_WORK pObj, AppMain.OBS_COLLISION_WORK pCol, short sOfstX, short sOfstY, ushort usWidth, ushort usHeight )
    {
        if ( pCol == null )
        {
            if ( pObj.col_work != null )
            {
                pCol = pObj.col_work;
            }
            else
            {
                pCol = new AppMain.OBS_COLLISION_WORK();
                pObj.flag |= 16777216U;
            }
        }
        pObj.col_work = pCol;
        pCol.obj_col.obj = pObj;
        pCol.obj_col.ofst_x = sOfstX;
        pCol.obj_col.ofst_y = sOfstY;
        pCol.obj_col.width = usWidth;
        pCol.obj_col.height = usHeight;
    }

    // Token: 0x0600197A RID: 6522 RVA: 0x000E6404 File Offset: 0x000E4604
    private static void ObjObjectCollisionDifSet( AppMain.OBS_OBJECT_WORK pObj, string pPath, AppMain.OBS_DATA_WORK pData, AppMain.AMS_AMB_HEADER pArchive )
    {
        if ( pObj.col_work != null )
        {
            pObj.col_work.diff_data_work = pData;
            pObj.col_work.obj_col.diff_data = AppMain.ObjDataLoad( pData, pPath, pArchive );
        }
    }

    // Token: 0x0600197B RID: 6523 RVA: 0x000E6432 File Offset: 0x000E4632
    private static void ObjObjectCollisionDirSet( AppMain.OBS_OBJECT_WORK pObj, string pPath, AppMain.OBS_DATA_WORK pData, AppMain.AMS_AMB_HEADER pArchive )
    {
        if ( pObj.col_work != null )
        {
            pObj.col_work.dir_data_work = pData;
            pObj.col_work.obj_col.dir_data = AppMain.ObjDataLoad( pData, pPath, pArchive );
        }
    }

    // Token: 0x0600197C RID: 6524 RVA: 0x000E6460 File Offset: 0x000E4660
    private static void ObjObjectCollisionAtrSet( AppMain.OBS_OBJECT_WORK pObj, string pPath, AppMain.OBS_DATA_WORK pData, AppMain.AMS_AMB_HEADER pArchive )
    {
        if ( pObj.col_work != null )
        {
            pObj.col_work.attr_data_work = pData;
            pObj.col_work.obj_col.attr_data = AppMain.ObjDataLoad( pData, pPath, pArchive );
        }
    }

    // Token: 0x0600197D RID: 6525 RVA: 0x000E6490 File Offset: 0x000E4690
    private static void ObjCollisionObjectRegist( AppMain.OBS_COLLISION_OBJ pObj )
    {
        if ( AppMain._obj_collision_num_nx >= 144 )
        {
            AppMain.MTM_ASSERT( 0 );
            return;
        }
        if ( pObj.obj != null && ( pObj.obj.flag & 12U ) != 0U )
        {
            return;
        }
        if ( pObj.rider_obj != null && pObj.rider_obj.ride_obj != pObj.obj )
        {
            pObj.rider_obj = null;
        }
        if ( pObj.toucher_obj != null && pObj.toucher_obj.touch_obj != pObj.obj )
        {
            pObj.toucher_obj = null;
        }
        AppMain._obj_collision_tbl_nx[( int )AppMain._obj_collision_num_nx] = pObj;
        AppMain._obj_collision_num_nx += 1;
        AppMain.VecFx32 check_pos = new AppMain.VecFx32(pObj.pos);
        if ( pObj.obj != null && ( pObj.flag & 16U ) == 0U )
        {
            check_pos.x += pObj.obj.pos.x;
            check_pos.y += pObj.obj.pos.y;
            check_pos.z += pObj.obj.pos.z;
        }
        pObj.check_pos = check_pos;
        pObj.flag &= 1073741823U;
        if ( pObj.obj != null )
        {
            if ( ( pObj.obj.disp_flag & 1U ) != 0U )
            {
                pObj.flag |= 1073741824U;
            }
            if ( ( pObj.obj.disp_flag & 2U ) != 0U )
            {
                pObj.flag |= 2147483648U;
            }
        }
        else
        {
            if ( ( pObj.flag & 1U ) != 0U )
            {
                pObj.flag |= 1073741824U;
            }
            if ( ( pObj.flag & 2U ) != 0U )
            {
                pObj.flag |= 2147483648U;
            }
        }
        AppMain.objCollsionOffsetSet( pObj, out pObj.check_ofst_x, out pObj.check_ofst_y );
        pObj.left = ( pObj.check_pos.x >> 12 ) + ( int )pObj.check_ofst_x;
        pObj.top = ( pObj.check_pos.y >> 12 ) + ( int )pObj.check_ofst_y;
        pObj.right = ( pObj.check_pos.x >> 12 ) + ( int )pObj.width + ( int )pObj.check_ofst_x;
        pObj.bottom = ( pObj.check_pos.y >> 12 ) + ( int )pObj.height + ( int )pObj.check_ofst_y;
        if ( ( pObj.flag & 64U ) == 0U )
        {
            pObj.check_dir = pObj.dir;
        }
        if ( ( pObj.flag & 32U ) == 0U && pObj.obj != null )
        {
            pObj.check_dir += ( ushort )( pObj.obj.dir.z + pObj.obj.dir_fall );
        }
    }

    // Token: 0x0600197E RID: 6526 RVA: 0x000E6720 File Offset: 0x000E4920
    private static void ObjCollisionObjectClear()
    {
        ushort num;
        for ( num = 0; num < ( ushort )AppMain._obj_collision_num_nx; num += 1 )
        {
            AppMain._obj_collision_tbl[( int )num] = AppMain._obj_collision_tbl_nx[( int )num];
        }
        while ( num < 144 )
        {
            AppMain._obj_collision_tbl_nx[( int )num] = null;
            num += 1;
        }
        AppMain._obj_collision_num = AppMain._obj_collision_num_nx;
        AppMain._obj_collision_num_nx = 0;
    }

    // Token: 0x0600197F RID: 6527 RVA: 0x000E6774 File Offset: 0x000E4974
    private static void objCollsionOffsetSet( AppMain.OBS_COLLISION_OBJ pCol, out short cOfstX, out short cOfstY )
    {
        cOfstX = pCol.ofst_x;
        cOfstY = pCol.ofst_y;
        if ( ( pCol.flag & 1073741824U ) != 0U )
        {
            cOfstX = ( short )( -pCol.ofst_x - ( short )pCol.width );
        }
        if ( ( pCol.flag & 2147483648U ) != 0U )
        {
            cOfstY = ( short )( -pCol.ofst_y - ( short )pCol.height );
        }
    }

    // Token: 0x06001980 RID: 6528 RVA: 0x000E67D0 File Offset: 0x000E49D0
    private static int ObjCollisionObjectFastCheckDet( int lPosX, int lPosY, ushort usFlag, ushort usVec, ushort[] pDir, uint[] pAttr )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.pos_x = lPosX;
        obs_COL_CHK_DATA.pos_y = lPosY;
        obs_COL_CHK_DATA.dir = pDir;
        obs_COL_CHK_DATA.attr = pAttr;
        obs_COL_CHK_DATA.flag = usFlag;
        obs_COL_CHK_DATA.vec = usVec;
        int result = AppMain.ObjCollisionObjectFastCheck(obs_COL_CHK_DATA);
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return result;
    }

    // Token: 0x06001981 RID: 6529 RVA: 0x000E6820 File Offset: 0x000E4A20
    private static int ObjCollisionObjectFastCheck( AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 24;
        int num2 = 0;
        int pos_x = pData.pos_x;
        int pos_y = pData.pos_y;
        if ( AppMain._obj_collision_num == 0 )
        {
            return num;
        }
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.Assign( pData );
        for ( ushort num3 = 0; num3 < ( ushort )AppMain._obj_collision_num; num3 += 1 )
        {
            AppMain.OBS_COLLISION_OBJ obs_COLLISION_OBJ = AppMain._obj_collision_tbl[(int)num3];
            if ( obs_COLLISION_OBJ.obj != null && ( obs_COLLISION_OBJ.flag & 256U ) == 0U )
            {
                obs_COL_CHK_DATA.pos_x = pData.pos_x;
                obs_COL_CHK_DATA.pos_y = pData.pos_y;
                if ( ( obs_COLLISION_OBJ.flag & 4U ) != 0U && obs_COLLISION_OBJ.check_dir != 0 )
                {
                    int num4 = (obs_COL_CHK_DATA.pos_x << 12) - obs_COLLISION_OBJ.check_pos.x;
                    int num5 = (obs_COL_CHK_DATA.pos_y << 12) - obs_COLLISION_OBJ.check_pos.y;
                    AppMain.ObjUtilGetRotPosXY( num4, num5, ref num4, ref num5, ( ushort )-obs_COLLISION_OBJ.check_dir );
                    obs_COL_CHK_DATA.pos_x = num4 + ( obs_COLLISION_OBJ.check_pos.x >> 12 );
                    obs_COL_CHK_DATA.pos_y = num5 + ( obs_COLLISION_OBJ.check_pos.y >> 12 );
                }
                if ( obs_COLLISION_OBJ.diff_data != null )
                {
                    num2 = AppMain.objFastCollisionDiffObject( obs_COLLISION_OBJ, obs_COL_CHK_DATA );
                    if ( num2 == 0 )
                    {
                        switch ( pData.vec )
                        {
                            case 0:
                                if ( obs_COLLISION_OBJ.obj.move.x < 0 )
                                {
                                    num2--;
                                }
                                break;
                            case 1:
                                if ( obs_COLLISION_OBJ.obj.move.x > 0 )
                                {
                                    num2--;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    switch ( pData.vec )
                    {
                        case 0:
                            num2 = obs_COLLISION_OBJ.left - pos_x;
                            if ( num2 == 0 && obs_COLLISION_OBJ.obj.move.x < 0 )
                            {
                                num2--;
                            }
                            break;
                        case 1:
                            num2 = pos_x - obs_COLLISION_OBJ.right;
                            if ( num2 == 0 && obs_COLLISION_OBJ.obj.move.x > 0 )
                            {
                                num2--;
                            }
                            break;
                        case 2:
                            num2 = obs_COLLISION_OBJ.top - pos_y;
                            break;
                        case 3:
                            num2 = pos_y - obs_COLLISION_OBJ.bottom;
                            break;
                    }
                    num2 = AppMain.MTM_MATH_CLIP( num2, -31, 31 );
                }
                if ( num > num2 )
                {
                    num = num2;
                }
            }
        }
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return num;
    }

    // Token: 0x06001982 RID: 6530 RVA: 0x000E6A5C File Offset: 0x000E4C5C
    private static int ObjCollisionObjectCheckDet( AppMain.OBS_OBJECT_WORK pObj, int lPosX, int lPosY, ushort usFlag, ushort usVec, ushort[] pDir, uint[] pAttr )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.pos_x = lPosX;
        obs_COL_CHK_DATA.pos_y = lPosY;
        obs_COL_CHK_DATA.dir = pDir;
        obs_COL_CHK_DATA.attr = pAttr;
        obs_COL_CHK_DATA.flag = usFlag;
        obs_COL_CHK_DATA.vec = usVec;
        int result = AppMain.ObjCollisionObjectCheck(pObj, obs_COL_CHK_DATA);
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return result;
    }

    // Token: 0x06001983 RID: 6531 RVA: 0x000E6AAC File Offset: 0x000E4CAC
    private static int ObjCollisionObjectCheck( AppMain.OBS_OBJECT_WORK pObj, AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 24;
        short num2 = 0;
        ushort num3 = 0;
        if ( AppMain._obj_collision_num == 0 )
        {
            return num;
        }
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.Assign( pData );
        ushort num4;
        if ( ( pObj.move_flag & 16U ) == 0U )
        {
            num2 = 1;
            num4 = 0;
        }
        else
        {
            num4 = pObj.dir.z;
        }
        switch ( ( num4 + 8192 & 49152 ) >> 14 )
        {
            case 1:
                if ( pData.vec == 1 && ( ( pObj.move_flag & 16U ) == 0U || pObj.move.x < 0 ) )
                {
                    num3 = 1;
                }
                break;
            case 2:
                if ( pData.vec == 3 && ( ( pObj.move_flag & 16U ) == 0U || pObj.move.y < 0 ) )
                {
                    num3 = 1;
                }
                break;
            case 3:
                if ( pData.vec == 0 && ( ( pObj.move_flag & 16U ) == 0U || pObj.move.x > 0 ) )
                {
                    num3 = 1;
                }
                break;
            default:
                if ( pData.vec == 2 && ( ( pObj.move_flag & 16U ) == 0U || pObj.move.y >= 0 ) )
                {
                    num3 = 1;
                }
                break;
        }
        short num5;
        if ( AppMain.GSM_MAIN_STAGE_IS_SPSTAGE_NOT_RETRY() )
        {
            num5 = 24;
        }
        else
        {
            num5 = 24;
        }
        for ( ushort num6 = 0; num6 < ( ushort )AppMain._obj_collision_num; num6 += 1 )
        {
            AppMain.OBS_COLLISION_OBJ obs_COLLISION_OBJ = AppMain._obj_collision_tbl[(int)num6];
            if ( obs_COLLISION_OBJ.obj != null && obs_COLLISION_OBJ.obj != pObj && ( obs_COLLISION_OBJ.flag & 256U ) == 0U )
            {
                obs_COL_CHK_DATA.pos_x = pData.pos_x;
                obs_COL_CHK_DATA.pos_y = pData.pos_y;
                if ( ( obs_COLLISION_OBJ.flag & 4U ) != 0U && obs_COLLISION_OBJ.check_dir != 0 )
                {
                    int num7 = (obs_COL_CHK_DATA.pos_x << 12) - obs_COLLISION_OBJ.check_pos.x;
                    int num8 = (obs_COL_CHK_DATA.pos_y << 12) - obs_COLLISION_OBJ.check_pos.y;
                    AppMain.ObjUtilGetRotPosXY( num7, num8, ref num7, ref num8, ( ushort )-obs_COLLISION_OBJ.check_dir );
                    obs_COL_CHK_DATA.pos_x = num7 + ( obs_COLLISION_OBJ.check_pos.x >> 12 );
                    obs_COL_CHK_DATA.pos_y = num8 + ( obs_COLLISION_OBJ.check_pos.y >> 12 );
                }
                if ( obs_COL_CHK_DATA.pos_x >= ( obs_COLLISION_OBJ.check_pos.x >> 12 ) - ( int )num5 + ( int )obs_COLLISION_OBJ.check_ofst_x && obs_COL_CHK_DATA.pos_x <= ( obs_COLLISION_OBJ.check_pos.x >> 12 ) + ( int )obs_COLLISION_OBJ.width + ( int )num5 + ( int )obs_COLLISION_OBJ.check_ofst_x && obs_COL_CHK_DATA.pos_y >= ( obs_COLLISION_OBJ.check_pos.y >> 12 ) - ( int )num5 + ( int )obs_COLLISION_OBJ.check_ofst_y && obs_COL_CHK_DATA.pos_y <= ( obs_COLLISION_OBJ.check_pos.y >> 12 ) + ( int )obs_COLLISION_OBJ.height + ( int )num5 + ( int )obs_COLLISION_OBJ.check_ofst_y )
                {
                    int num9;
                    if ( obs_COLLISION_OBJ.diff_data != null )
                    {
                        num9 = AppMain.objCollisionDiffObject( obs_COLLISION_OBJ, obs_COL_CHK_DATA );
                        if ( num9 == 0 )
                        {
                            switch ( pData.vec )
                            {
                                case 0:
                                    if ( obs_COLLISION_OBJ.obj != null && obs_COLLISION_OBJ.obj.move.x < 0 )
                                    {
                                        num9--;
                                    }
                                    break;
                                case 1:
                                    if ( obs_COLLISION_OBJ.obj != null && obs_COLLISION_OBJ.obj.move.x > 0 )
                                    {
                                        num9--;
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        num9 = 24;
                        switch ( pData.vec )
                        {
                            case 0:
                                if ( obs_COL_CHK_DATA.pos_x < obs_COLLISION_OBJ.right && obs_COL_CHK_DATA.pos_y > obs_COLLISION_OBJ.top && obs_COL_CHK_DATA.pos_y < obs_COLLISION_OBJ.bottom )
                                {
                                    num9 = obs_COLLISION_OBJ.left - obs_COL_CHK_DATA.pos_x;
                                    if ( num9 == 0 && obs_COLLISION_OBJ.obj != null && obs_COLLISION_OBJ.obj.move.x < 0 )
                                    {
                                        num9--;
                                    }
                                }
                                break;
                            case 1:
                                if ( obs_COLLISION_OBJ.left < obs_COL_CHK_DATA.pos_x && obs_COL_CHK_DATA.pos_y > obs_COLLISION_OBJ.top && obs_COL_CHK_DATA.pos_y < obs_COLLISION_OBJ.bottom )
                                {
                                    num9 = obs_COL_CHK_DATA.pos_x - obs_COLLISION_OBJ.right;
                                    if ( num9 == 0 && obs_COLLISION_OBJ.obj != null && obs_COLLISION_OBJ.obj.move.x > 0 )
                                    {
                                        num9--;
                                    }
                                }
                                break;
                            case 2:
                                if ( obs_COL_CHK_DATA.pos_y < obs_COLLISION_OBJ.bottom && obs_COL_CHK_DATA.pos_x > obs_COLLISION_OBJ.left && obs_COL_CHK_DATA.pos_x < obs_COLLISION_OBJ.right )
                                {
                                    num9 = obs_COLLISION_OBJ.top - obs_COL_CHK_DATA.pos_y;
                                }
                                break;
                            case 3:
                                if ( obs_COLLISION_OBJ.top < obs_COL_CHK_DATA.pos_y && obs_COL_CHK_DATA.pos_x > obs_COLLISION_OBJ.left && obs_COL_CHK_DATA.pos_x < obs_COLLISION_OBJ.right )
                                {
                                    num9 = obs_COL_CHK_DATA.pos_y - obs_COLLISION_OBJ.bottom;
                                }
                                break;
                        }
                        num9 = AppMain.MTM_MATH_CLIP( num9, -31, 31 );
                    }
                    if ( num > num9 )
                    {
                        num = num9;
                        if ( num <= ( int )num2 )
                        {
                            pObj.touch_obj = obs_COLLISION_OBJ.obj;
                            obs_COLLISION_OBJ.toucher_obj = pObj;
                        }
                        if ( num <= ( int )num2 && num3 != 0 )
                        {
                            pObj.ride_obj = obs_COLLISION_OBJ.obj;
                            obs_COLLISION_OBJ.rider_obj = pObj;
                            if ( pData.dir != null )
                            {
                                ushort[] dir = pData.dir;
                                int num10 = 0;
                                dir[num10] += obs_COLLISION_OBJ.check_dir;
                            }
                            if ( pData.attr != null && ( obs_COLLISION_OBJ.flag & 128U ) == 0U )
                            {
                                pData.attr[0] |= ( uint )( ( byte )obs_COLLISION_OBJ.attr );
                            }
                        }
                    }
                }
            }
        }
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return num;
    }

    // Token: 0x06001984 RID: 6532 RVA: 0x000E7048 File Offset: 0x000E5248
    private static AppMain.OBS_COLLISION_OBJ ObjCollisionDiffObjectGetCollisionObj( byte col_no )
    {
        if ( col_no < AppMain._obj_collision_num )
        {
            return AppMain._obj_collision_tbl[( int )col_no];
        }
        return null;
    }

    // Token: 0x06001985 RID: 6533 RVA: 0x000E705C File Offset: 0x000E525C
    private static int objFastCollisionDiffObject( AppMain.OBS_COLLISION_OBJ pColObj, AppMain.OBS_COL_CHK_DATA pData )
    {
        ushort num = 0;
        uint num2 = 0U;
        sbyte sDelta = 8;
        if ( pData.dir != null )
        {
            num = pData.dir[0];
        }
        if ( pData.attr != null )
        {
            num2 = pData.attr[0];
        }
        if ( ( pData.vec & 1 ) != 0 )
        {
            sDelta = -8;
        }
        int num3;
        sbyte sPix;
        if ( ( pData.vec & 2 ) != 0 )
        {
            num3 = AppMain.objGetColDataY( pColObj, pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr );
            sPix = ( sbyte )( pData.pos_y - pColObj.top & 7 );
        }
        else
        {
            num3 = AppMain.objGetColDataX( pColObj, pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr );
            sPix = ( sbyte )( pData.pos_x - pColObj.left & 7 );
        }
        if ( num3 == 0 )
        {
            if ( pData.dir != null )
            {
                pData.dir[0] = num;
            }
            if ( pData.attr != null )
            {
                pData.attr[0] = num2;
            }
            return AppMain.objMapGetForward( sPix, sDelta );
        }
        if ( num3 == 8 )
        {
            return AppMain.objMapGetBack( sPix, sDelta );
        }
        return AppMain.objMapGetDiff( num3, sPix, sDelta );
    }

    // Token: 0x06001986 RID: 6534 RVA: 0x000E715C File Offset: 0x000E535C
    private static int objCollisionDiffObject( AppMain.OBS_COLLISION_OBJ pColObj, AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 0;
        int num2 = 0;
        uint num3 = 0U;
        ushort num4 = 0;
        sbyte b = 0;
        sbyte b2 = 0;
        if ( pData.dir != null )
        {
            num4 = pData.dir[0];
        }
        if ( pData.attr != null )
        {
            num3 = pData.attr[0];
        }
        if ( ( pData.vec & 2 ) != 0 )
        {
            b2 = 8;
            if ( ( pData.vec & 1 ) != 0 )
            {
                b2 = -8;
            }
        }
        else
        {
            b = 8;
            if ( ( pData.vec & 1 ) != 0 )
            {
                b = -8;
            }
        }
        sbyte sPix;
        AppMain.pFunc_Delegate pFunc_Delegate;
        if ( ( pData.vec & 2 ) != 0 )
        {
            sPix = ( sbyte )( pData.pos_y - pColObj.top & 7 );
            pFunc_Delegate = AppMain._objGetColDataY;
        }
        else
        {
            sPix = ( sbyte )( pData.pos_x - pColObj.left & 7 );
            pFunc_Delegate = AppMain._objGetColDataX;
        }
        int num5 = pFunc_Delegate(pColObj, pData.pos_x, pData.pos_y, pData.flag, pData.dir, pData.attr);
        if ( num5 == 0 )
        {
            num += ( int )b;
            num2 += ( int )b2;
            num5 = pFunc_Delegate( pColObj, pData.pos_x + num, pData.pos_y + num2, pData.flag, pData.dir, pData.attr );
            if ( num5 == 0 )
            {
                num += ( int )b;
                num2 += ( int )b2;
                num5 = pFunc_Delegate( pColObj, pData.pos_x + num, pData.pos_y + num2, pData.flag, pData.dir, pData.attr );
                if ( num5 == 0 )
                {
                    if ( pData.dir != null )
                    {
                        pData.dir[0] = num4;
                    }
                    if ( pData.attr != null )
                    {
                        pData.attr[0] = num3;
                    }
                    return AppMain.objMapGetForward( sPix, ( sbyte )( b + b2 ) ) + 16;
                }
                if ( num5 == 8 )
                {
                    return AppMain.objMapGetBack( sPix, ( sbyte )( b + b2 ) ) + 16;
                }
                return AppMain.objMapGetDiff( num5, sPix, ( sbyte )( b + b2 ) ) + 16;
            }
            else
            {
                if ( num5 == 8 )
                {
                    return AppMain.objMapGetBack( sPix, ( sbyte )( b + b2 ) ) + 8;
                }
                return AppMain.objMapGetDiff( num5, sPix, ( sbyte )( b + b2 ) ) + 8;
            }
        }
        else
        {
            if ( num5 != 8 )
            {
                return AppMain.objMapGetDiff( num5, sPix, ( sbyte )( b + b2 ) );
            }
            if ( pData.dir != null )
            {
                num4 = pData.dir[0];
            }
            if ( pData.attr != null )
            {
                num3 = pData.attr[0];
            }
            num -= ( int )b;
            num2 -= ( int )b2;
            num5 = pFunc_Delegate( pColObj, pData.pos_x + num, pData.pos_y + num2, pData.flag, pData.dir, pData.attr );
            if ( num5 == 8 )
            {
                if ( pData.dir != null )
                {
                    num4 = pData.dir[0];
                }
                if ( pData.attr != null )
                {
                    num3 = pData.attr[0];
                }
                num -= ( int )b;
                num2 -= ( int )b2;
                num5 = pFunc_Delegate( pColObj, pData.pos_x + num, pData.pos_y + num2, pData.flag, pData.dir, pData.attr );
                if ( num5 == 0 )
                {
                    if ( pData.dir != null )
                    {
                        pData.dir[0] = num4;
                    }
                    if ( pData.attr != null )
                    {
                        pData.attr[0] = num3;
                    }
                    return AppMain.objMapGetForwardRev( sPix, ( sbyte )( b + b2 ) ) - 16;
                }
                if ( num5 == 8 )
                {
                    return AppMain.objMapGetBack( sPix, ( sbyte )( b + b2 ) ) - 16;
                }
                return AppMain.objMapGetDiff( num5, sPix, ( sbyte )( b + b2 ) ) - 16;
            }
            else
            {
                if ( num5 == 0 )
                {
                    if ( pData.dir != null )
                    {
                        pData.dir[0] = num4;
                    }
                    if ( pData.attr != null )
                    {
                        pData.attr[0] = num3;
                    }
                    return AppMain.objMapGetForwardRev( sPix, ( sbyte )( b + b2 ) ) - 8;
                }
                return AppMain.objMapGetDiff( num5, sPix, ( sbyte )( b + b2 ) ) - 8;
            }
        }
    }

    // Token: 0x06001987 RID: 6535 RVA: 0x000E7498 File Offset: 0x000E5698
    private static int objGetColDataX( AppMain.OBS_COLLISION_OBJ pColObj, int lPosX, int lPosY, ushort ucSuf, ushort[] pDir, uint[] pAttr )
    {
        sbyte b = 0;
        if ( lPosX < pColObj.left || lPosX >= pColObj.right )
        {
            return ( int )b;
        }
        if ( lPosY < pColObj.top || lPosY >= pColObj.bottom )
        {
            return ( int )b;
        }
        ushort num = (ushort)(lPosX - pColObj.left >> 3);
        ushort num2 = (ushort)(lPosY - pColObj.top >> 3);
        if ( ( pColObj.flag & 1073741824U ) != 0U )
        {
            num = ( ushort )( ( pColObj.width >> 3 ) - 1 - ( int )num );
        }
        if ( ( pColObj.flag & 2147483648U ) != 0U )
        {
            num2 = ( ushort )( ( pColObj.height >> 3 ) - 1 - ( int )num2 );
        }
        ushort num3 = (ushort)((int)num + (int)num2 * (pColObj.width >> 3));
        int num4 = lPosY - pColObj.top & 7;
        if ( ( pColObj.flag & 2147483648U ) != 0U )
        {
            num4 = 7 - num4;
        }
        b = ( sbyte )pColObj.diff_data[( ( int )num3 << 3 ) + num4];
        b &= 15;
        if ( ( b & 8 ) != 0 )
        {
            b |= -16;
        }
        if ( b == -8 )
        {
            b = 8;
        }
        if ( pColObj.attr_data != null )
        {
            if ( ( ucSuf & 128 ) != 0 && ( ( pColObj.attr_data[num3 >> 3] & 1 ) != 0 || ( pColObj.attr & 1 ) != 0 ) )
            {
                b = 0;
            }
        }
        else if ( ( ucSuf & 128 ) != 0 && ( pColObj.attr & 1 ) != 0 )
        {
            b = 0;
        }
        if ( ( pColObj.flag & 1073741824U ) != 0U && b != 8 && b != 0 )
        {
            if ( b > 0 )
            {
                b -= 8;
            }
            else
            {
                b += 8;
            }
        }
        if ( pDir != null && b != 0 )
        {
            ushort num5;
            if ( pColObj.dir_data != null )
            {
                num5 = ( ushort )( pColObj.dir_data[( int )num3] << 8 );
            }
            else
            {
                num5 = 0;
            }
            if ( ( pColObj.flag & 4U ) != 0U )
            {
                num5 += pColObj.check_dir;
            }
            if ( ( pColObj.flag & 8U ) != 0U )
            {
                if ( ( pColObj.flag & 1073741824U ) != 0U )
                {
                    num5 = ( ushort )( -( ushort )( ( short )num5 ) );
                }
                if ( ( pColObj.flag & 2147483648U ) != 0U )
                {
                    num5 = ( ushort )( -( ( short )num5 + 16384 ) - 16384 );
                }
            }
            pDir[0] = num5;
        }
        if ( pAttr != null && b != 0 )
        {
            if ( pColObj.attr_data != null )
            {
                pAttr[0] = ( uint )( ( ushort )pColObj.attr_data[num3 >> 3] | pColObj.attr );
            }
            else
            {
                pAttr[0] = ( uint )pColObj.attr;
            }
        }
        return ( int )b;
    }

    // Token: 0x06001988 RID: 6536 RVA: 0x000E768C File Offset: 0x000E588C
    private static int objGetColDataY( AppMain.OBS_COLLISION_OBJ pColObj, int lPosX, int lPosY, ushort ucSuf, ushort[] pDir, uint[] pAttr )
    {
        sbyte b = 0;
        if ( lPosX < pColObj.left || lPosX >= pColObj.right )
        {
            return ( int )b;
        }
        if ( lPosY < pColObj.top || lPosY >= pColObj.bottom )
        {
            return ( int )b;
        }
        ushort num = (ushort)(lPosX - pColObj.left >> 3);
        ushort num2 = (ushort)(lPosY - pColObj.top >> 3);
        if ( ( pColObj.flag & 1073741824U ) != 0U )
        {
            num = ( ushort )( ( pColObj.width >> 3 ) - 1 - ( int )num );
        }
        if ( ( pColObj.flag & 2147483648U ) != 0U )
        {
            num2 = ( ushort )( ( pColObj.height >> 3 ) - 1 - ( int )num2 );
        }
        ushort num3 = (ushort)((int)num + (int)num2 * (pColObj.width >> 3));
        int num4 = lPosX - pColObj.left & 7;
        if ( ( pColObj.flag & 1073741824U ) != 0U )
        {
            num4 = 7 - num4;
        }
        b = ( sbyte )pColObj.diff_data[( ( int )num3 << 3 ) + num4];
        b = ( sbyte )( b >> 4 );
        b &= 15;
        if ( ( b & 8 ) != 0 )
        {
            b |= -16;
        }
        if ( b == -8 )
        {
            b = 8;
        }
        if ( pColObj.attr_data != null )
        {
            if ( ( ucSuf & 128 ) != 0 && ( ( pColObj.attr_data[num3 >> 3] & 1 ) != 0 || ( pColObj.attr & 1 ) != 0 ) )
            {
                b = 0;
            }
        }
        else if ( ( ucSuf & 128 ) != 0 && ( pColObj.attr & 1 ) != 0 )
        {
            b = 0;
        }
        if ( ( pColObj.flag & 2147483648U ) != 0U && b != 8 && b != 0 )
        {
            if ( b > 0 )
            {
                b -= 8;
            }
            else
            {
                b += 8;
            }
        }
        if ( pDir != null && b != 0 )
        {
            ushort num5;
            if ( pColObj.dir_data != null )
            {
                num5 = ( ushort )( pColObj.dir_data[( int )num3] << 8 );
            }
            else
            {
                num5 = 0;
            }
            if ( ( pColObj.flag & 4U ) != 0U )
            {
                num5 += pColObj.check_dir;
            }
            if ( ( pColObj.flag & 8U ) != 0U )
            {
                if ( ( pColObj.flag & 1073741824U ) != 0U )
                {
                    num5 = ( ushort )( -( ushort )( ( short )num5 ) );
                }
                if ( ( pColObj.flag & 2147483648U ) != 0U )
                {
                    num5 = ( ushort )( -( ( short )num5 + 16384 ) - 16384 );
                }
            }
            pDir[0] = num5;
        }
        if ( pAttr != null && b != 0 )
        {
            if ( pColObj.attr_data != null )
            {
                pAttr[0] = ( uint )( ( ushort )pColObj.attr_data[num3 >> 3] | pColObj.attr );
            }
            else
            {
                pAttr[0] = ( uint )pColObj.attr;
            }
        }
        return ( int )b;
    }

    // Token: 0x06001989 RID: 6537 RVA: 0x000E7884 File Offset: 0x000E5A84
    private static int objMapGetDiff( int lCol, sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( lCol > 0 )
        {
            if ( sDelta > 0 )
            {
                result = lCol - ( int )( sPix + 1 );
            }
            else
            {
                result = ( int )( 8 - sPix );
            }
        }
        else if ( sDelta > 0 )
        {
            result = ( int )( -( int )( sPix + 1 ) );
        }
        else
        {
            result = lCol + ( int )sPix;
        }
        return result;
    }

    // Token: 0x0600198A RID: 6538 RVA: 0x000E78B8 File Offset: 0x000E5AB8
    private static int objMapGetForward( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( 8 - sPix );
        }
        else
        {
            result = ( int )( 1 + sPix );
        }
        return result;
    }

    // Token: 0x0600198B RID: 6539 RVA: 0x000E78D4 File Offset: 0x000E5AD4
    private static int objMapGetBack( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( -( int )( sPix + 1 ) );
        }
        else
        {
            result = ( int )( sPix - 8 );
        }
        return result;
    }

    // Token: 0x0600198C RID: 6540 RVA: 0x000E78F4 File Offset: 0x000E5AF4
    private static int objMapGetForwardRev( sbyte sPix, sbyte sDelta )
    {
        int result;
        if ( sDelta > 0 )
        {
            result = ( int )( 8 - ( sPix + 1 ) );
        }
        else
        {
            result = ( int )sPix;
        }
        return result;
    }

}