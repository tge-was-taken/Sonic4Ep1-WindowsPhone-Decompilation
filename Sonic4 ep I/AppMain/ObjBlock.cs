using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000004 RID: 4
    public enum OBE_BLOCK_COL_ID
    {
        // Token: 0x0400473E RID: 18238
        OBD_BLOCK_COL_EMPTY,
        // Token: 0x0400473F RID: 18239
        OBD_BLOCK_COL_FILL,
        // Token: 0x04004740 RID: 18240
        OBD_BLOCK_COL_FILL_THROUGH,
        // Token: 0x04004741 RID: 18241
        OBD_BLOCK_COL_ID_MAX
    }

    // Token: 0x02000005 RID: 5
    // (Invoke) Token: 0x06001CD8 RID: 7384
    public delegate int _obj_block_collision_func_delegate( AppMain.OBS_COL_CHK_DATA data );

    // Token: 0x06000010 RID: 16 RVA: 0x000020D7 File Offset: 0x000002D7
    private static void ObjSetBlockCollision( AppMain.OBS_BLOCK_COLLISION pCol )
    {
        AppMain._obj_bcol = pCol;
    }

    // Token: 0x06000011 RID: 17 RVA: 0x000020DF File Offset: 0x000002DF
    private static AppMain.OBS_BLOCK_COLLISION ObjGetBlockCollision()
    {
        return AppMain._obj_bcol;
    }

    // Token: 0x06000012 RID: 18 RVA: 0x000020E8 File Offset: 0x000002E8
    private static int ObjBlockCollisionDet( int lPosX, int lPosY, ushort usFlag, ushort usVec, ushort[] pDir, uint[] pAttr )
    {
        AppMain.OBS_COL_CHK_DATA obs_COL_CHK_DATA = AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Alloc();
        obs_COL_CHK_DATA.pos_x = lPosX;
        obs_COL_CHK_DATA.pos_y = lPosY;
        obs_COL_CHK_DATA.dir = pDir;
        obs_COL_CHK_DATA.attr = pAttr;
        obs_COL_CHK_DATA.flag = usFlag;
        obs_COL_CHK_DATA.vec = usVec;
        int result = AppMain.ObjBlockCollision(obs_COL_CHK_DATA);
        AppMain.GlobalPool<AppMain.OBS_COL_CHK_DATA>.Release( obs_COL_CHK_DATA );
        return result;
    }

    // Token: 0x06000013 RID: 19 RVA: 0x00002138 File Offset: 0x00000338
    private static int ObjBlockCollision( AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 0;
        short num2 = 0;
        short num3 = 0;
        if ( AppMain._obj_bcol.pData[0] == null )
        {
            switch ( pData.vec )
            {
                case 0:
                    num = AppMain._obj_bcol.right - pData.pos_x;
                    break;
                case 1:
                    num = pData.pos_x - AppMain._obj_bcol.left;
                    break;
                case 2:
                    num = AppMain._obj_bcol.bottom - pData.pos_y;
                    break;
                case 3:
                    num = pData.pos_y - AppMain._obj_bcol.top;
                    break;
            }
            return AppMain.MTM_MATH_CLIP( num, -31, 31 );
        }
        if ( pData.dir != null )
        {
            ushort num4 = pData.dir[0];
        }
        if ( pData.attr != null )
        {
            uint num5 = pData.attr[0];
        }
        num = AppMain.objGetBlockColData( pData );
        if ( ( pData.vec & 2 ) != 0 )
        {
            short num6 = (short)(pData.pos_y & 15);
            if ( ( pData.vec & 1 ) != 0 )
            {
                num6 -= ( short )num;
            }
            else
            {
                num6 += ( short )num;
            }
            if ( num6 == 0 )
            {
                num3 = -16;
            }
            else if ( num6 == 15 )
            {
                num3 = 16;
            }
        }
        else
        {
            short num6 = (short)(pData.pos_x & 15);
            if ( ( pData.vec & 1 ) != 0 )
            {
                num6 -= ( short )num;
            }
            else
            {
                num6 += ( short )num;
            }
            if ( num6 == 0 )
            {
                num2 = -16;
            }
            else if ( num6 == 15 )
            {
                num2 = 16;
            }
        }
        if ( num2 != 0 || num3 != 0 )
        {
            uint num7 = 0U;
            ushort num8 = 0;
            if ( pData.dir != null )
            {
                num8 = pData.dir[0];
            }
            if ( pData.attr != null )
            {
                num7 = pData.attr[0];
            }
            pData.pos_x += ( int )num2;
            pData.pos_y += ( int )num3;
            num = AppMain.objGetBlockColData( pData );
            pData.pos_x -= ( int )num2;
            pData.pos_y -= ( int )num3;
            if ( num >= 0 )
            {
                if ( pData.dir != null )
                {
                    pData.dir[0] = num8;
                }
                if ( pData.attr != null )
                {
                    pData.attr[0] = num7;
                }
            }
            if ( num2 < 0 )
            {
                num2 += 1;
            }
            if ( num2 > 0 )
            {
                num2 -= 1;
            }
            if ( num3 < 0 )
            {
                num3 += 1;
            }
            if ( num3 > 0 )
            {
                num3 -= 1;
            }
            if ( ( pData.vec & 1 ) != 0 )
            {
                num -= ( int )( num2 + num3 );
            }
            else
            {
                num += ( int )( num2 + num3 );
            }
        }
        return num;
    }

    // Token: 0x06000014 RID: 20 RVA: 0x00002348 File Offset: 0x00000548
    private static int objGetBlockColData( AppMain.OBS_COL_CHK_DATA pData )
    {
        int num = 0;
        int num2 = 0;
        if ( ( pData.flag & 64 ) != 0 )
        {
            int num3 = AppMain.objBlockColLimit(pData);
            if ( num3 < 0 )
            {
                return num3;
            }
        }
        else
        {
            num = AppMain.MTM_MATH_CLIP( pData.pos_x, AppMain._obj_bcol.left, AppMain._obj_bcol.right - 1 );
            num2 = AppMain.MTM_MATH_CLIP( pData.pos_y, AppMain._obj_bcol.top, AppMain._obj_bcol.bottom - 1 );
        }
        uint num4 = (uint)((long)(num2 >> 4) * (long)((ulong)AppMain._obj_bcol.width) + (long)(num >> 4));
        ushort num5 = (ushort)AppMain._obj_bcol.pData[(int)(pData.flag & 1)][(int)((UIntPtr)num4)];
        return AppMain._obj_block_collision_func[( int )num5]( pData );
    }

    // Token: 0x06000015 RID: 21 RVA: 0x000023F4 File Offset: 0x000005F4
    private static int objBlockColLimit( AppMain.OBS_COL_CHK_DATA pData )
    {
        switch ( pData.vec )
        {
            case 0:
                goto IL_6E;
            case 1:
                goto IL_96;
            case 2:
                if ( AppMain._obj_bcol.bottom - 1 < pData.pos_y )
                {
                    return AppMain._obj_bcol.bottom - 1 - pData.pos_y;
                }
                break;
            case 3:
                break;
            default:
                return 1;
        }
        if ( AppMain._obj_bcol.top > pData.pos_y )
        {
            return pData.pos_y - AppMain._obj_bcol.top;
        }
        IL_6E:
        if ( AppMain._obj_bcol.right - 1 < pData.pos_x )
        {
            return AppMain._obj_bcol.right - 1 - pData.pos_x;
        }
        IL_96:
        if ( AppMain._obj_bcol.left > pData.pos_x )
        {
            return pData.pos_x - AppMain._obj_bcol.left;
        }
        return 1;
    }

    // Token: 0x06000016 RID: 22 RVA: 0x000024BC File Offset: 0x000006BC
    private static int objBlockCalcEmpty( AppMain.OBS_COL_CHK_DATA pData )
    {
        switch ( pData.vec )
        {
            case 0:
                return 15 - ( pData.pos_x & 15 );
            case 1:
                return pData.pos_x & 15;
            case 2:
                return 15 - ( pData.pos_y & 15 );
            case 3:
                return pData.pos_y & 15;
            default:
                return 15;
        }
    }

    // Token: 0x06000017 RID: 23 RVA: 0x00002518 File Offset: 0x00000718
    private static int objBlockCalcFill( AppMain.OBS_COL_CHK_DATA pData )
    {
        switch ( pData.vec )
        {
            case 0:
                return -( pData.pos_x & 15 );
            case 1:
                return -( 15 - ( pData.pos_x & 15 ) );
            case 2:
                return -( pData.pos_y & 15 );
            case 3:
                return -( 15 - ( pData.pos_y & 15 ) );
            default:
                return 15;
        }
    }

    // Token: 0x06000018 RID: 24 RVA: 0x00002578 File Offset: 0x00000778
    private static int objBlockColEmpty( AppMain.OBS_COL_CHK_DATA pData )
    {
        if ( pData.dir != null )
        {
            pData.dir[0] = 0;
        }
        return AppMain.objBlockCalcEmpty( pData );
    }

    // Token: 0x06000019 RID: 25 RVA: 0x00002591 File Offset: 0x00000791
    private static int objBlockColBlockFill( AppMain.OBS_COL_CHK_DATA pData )
    {
        if ( pData.dir != null )
        {
            pData.dir[0] = 0;
        }
        return AppMain.objBlockCalcFill( pData );
    }

    // Token: 0x0600001A RID: 26 RVA: 0x000025AC File Offset: 0x000007AC
    private static int objBlockColBlockFillThrough( AppMain.OBS_COL_CHK_DATA pData )
    {
        if ( pData.dir != null )
        {
            pData.dir[0] = 0;
        }
        if ( pData.attr != null )
        {
            pData.attr[0] |= 2U;
        }
        if ( ( pData.flag & 128 ) != 0 )
        {
            return AppMain.objBlockCalcEmpty( pData );
        }
        return AppMain.objBlockCalcFill( pData );
    }
}
