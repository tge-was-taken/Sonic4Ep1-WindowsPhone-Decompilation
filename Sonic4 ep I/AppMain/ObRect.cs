using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200025A RID: 602
    public class OBS_RECT : AppMain.IClearable
    {
        // Token: 0x060023D1 RID: 9169 RVA: 0x00149B2C File Offset: 0x00147D2C
        public void Clear()
        {
            this.left = ( this.top = ( this.back = 0 ) );
            this.right = 0;
            this.width = 0;
            this.height = 0;
            this.bottom = 0;
            this.height = 0;
            this.front = 0;
            this.depth = 0;
        }

        // Token: 0x170000AD RID: 173
        // (get) Token: 0x060023D2 RID: 9170 RVA: 0x00149B83 File Offset: 0x00147D83
        // (set) Token: 0x060023D3 RID: 9171 RVA: 0x00149B8C File Offset: 0x00147D8C
        public ushort width
        {
            get
            {
                return ( ushort )this.right;
            }
            set
            {
                this.right = ( short )value;
            }
        }

        // Token: 0x170000AE RID: 174
        // (get) Token: 0x060023D4 RID: 9172 RVA: 0x00149B96 File Offset: 0x00147D96
        // (set) Token: 0x060023D5 RID: 9173 RVA: 0x00149B9F File Offset: 0x00147D9F
        public ushort height
        {
            get
            {
                return ( ushort )this.bottom;
            }
            set
            {
                this.bottom = ( short )value;
            }
        }

        // Token: 0x170000AF RID: 175
        // (get) Token: 0x060023D6 RID: 9174 RVA: 0x00149BA9 File Offset: 0x00147DA9
        // (set) Token: 0x060023D7 RID: 9175 RVA: 0x00149BB1 File Offset: 0x00147DB1
        public short depth
        {
            get
            {
                return this.front;
            }
            set
            {
                this.front = value;
            }
        }

        // Token: 0x040058C2 RID: 22722
        public short left;

        // Token: 0x040058C3 RID: 22723
        public short top;

        // Token: 0x040058C4 RID: 22724
        public short back;

        // Token: 0x040058C5 RID: 22725
        public short right;

        // Token: 0x040058C6 RID: 22726
        public short bottom;

        // Token: 0x040058C7 RID: 22727
        public short front;

        // Token: 0x040058C8 RID: 22728
        public AppMain.VecFx32 pos = default(AppMain.VecFx32);
    }

    // Token: 0x0200025B RID: 603
    // (Invoke) Token: 0x060023DA RID: 9178
    public delegate void OBS_RECT_WORK_Delegate1( AppMain.OBS_RECT_WORK rectWork1, AppMain.OBS_RECT_WORK rectWork2 );

    // Token: 0x0200025C RID: 604
    // (Invoke) Token: 0x060023DE RID: 9182
    public delegate uint OBS_RECT_WORK_Delegate2( AppMain.OBS_RECT_WORK rectWork1, AppMain.OBS_RECT_WORK rectWork2 );

    // Token: 0x0200025D RID: 605
    public class OBS_RECT_WORK : AppMain.IClearable
    {
        // Token: 0x060023E1 RID: 9185 RVA: 0x00149BD0 File Offset: 0x00147DD0
        public void Clear()
        {
            this.rect.Clear();
            this.flag = 0U;
            this.parent_obj = null;
            this.ppHit = ( this.ppDef = null );
            this.ppCheck = null;
            this.hit_power = ( this.def_power = 0 );
            this.hit_flag = ( this.def_flag = 0 );
            this.group_no = ( this.target_g_flag = 0 );
            this.attr_flag = ( this.user_data = 0U );
            this.pDataWork = null;
        }

        // Token: 0x040058C9 RID: 22729
        public readonly AppMain.OBS_RECT rect = new AppMain.OBS_RECT();

        // Token: 0x040058CA RID: 22730
        public uint flag;

        // Token: 0x040058CB RID: 22731
        public AppMain.OBS_OBJECT_WORK parent_obj;

        // Token: 0x040058CC RID: 22732
        public AppMain.OBS_RECT_WORK_Delegate1 ppHit;

        // Token: 0x040058CD RID: 22733
        public AppMain.OBS_RECT_WORK_Delegate1 ppDef;

        // Token: 0x040058CE RID: 22734
        public AppMain.OBS_RECT_WORK_Delegate2 ppCheck;

        // Token: 0x040058CF RID: 22735
        public short hit_power;

        // Token: 0x040058D0 RID: 22736
        public short def_power;

        // Token: 0x040058D1 RID: 22737
        public ushort hit_flag;

        // Token: 0x040058D2 RID: 22738
        public ushort def_flag;

        // Token: 0x040058D3 RID: 22739
        public byte group_no;

        // Token: 0x040058D4 RID: 22740
        public byte target_g_flag;

        // Token: 0x040058D5 RID: 22741
        public uint attr_flag;

        // Token: 0x040058D6 RID: 22742
        public uint user_data;

        // Token: 0x040058D7 RID: 22743
        public object pDataWork;
    }

    // Token: 0x06000F04 RID: 3844 RVA: 0x000842EF File Offset: 0x000824EF
    public static bool OBM_LINE_AND_LINE( int x0, int w0, int x1, int w1 )
    {
        return ( x0 <= x1 && x0 + w0 >= x1 ) || ( x0 >= x1 && x1 + w1 >= x0 );
    }

    // Token: 0x06000F05 RID: 3845 RVA: 0x0008430C File Offset: 0x0008250C
    public static bool OBM_POINT_IN_LINE( int x0, int w0, int x1 )
    {
        return x0 <= x1 && x0 + w0 >= x1;
    }

    // Token: 0x06000F06 RID: 3846 RVA: 0x00084320 File Offset: 0x00082520
    public static AppMain.OBS_RECT ObjRectSet( AppMain.OBS_RECT pRec, short cLeft, short cTop, short cRight, short cBottom )
    {
        pRec.left = cLeft;
        pRec.top = cTop;
        pRec.right = cRight;
        pRec.bottom = cBottom;
        pRec.back = -16;
        pRec.front = 16;
        if ( pRec.right < pRec.left )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.left, ref pRec.right );
        }
        if ( pRec.bottom < pRec.top )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.top, ref pRec.bottom );
        }
        AppMain.VEC_Set( ref pRec.pos, 0, 0, 0 );
        return pRec;
    }

    // Token: 0x06000F07 RID: 3847 RVA: 0x000843A8 File Offset: 0x000825A8
    public static AppMain.OBS_RECT ObjRectZSet( AppMain.OBS_RECT pRec, short cLeft, short cTop, short cBack, short cRight, short cBottom, short cFront )
    {
        pRec.left = cLeft;
        pRec.top = cTop;
        pRec.right = cRight;
        pRec.bottom = cBottom;
        pRec.back = cBack;
        pRec.front = cFront;
        if ( pRec.right < pRec.left )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.left, ref pRec.right );
        }
        if ( pRec.bottom < pRec.top )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.top, ref pRec.bottom );
        }
        if ( pRec.front < pRec.back )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.back, ref pRec.front );
        }
        AppMain.VEC_Set( ref pRec.pos, 0, 0, 0 );
        return pRec;
    }

    // Token: 0x06000F08 RID: 3848 RVA: 0x00084450 File Offset: 0x00082650
    public static AppMain.OBS_RECT ObjRectAllSet( AppMain.OBS_RECT pRec, AppMain.VecFx32 pos, short cLeft, short cTop, short cBack, short cRight, short cBottom, short cFront )
    {
        pRec.pos.Assign( pos );
        pRec.left = cLeft;
        pRec.top = cTop;
        pRec.right = cRight;
        pRec.bottom = cBottom;
        pRec.back = cBack;
        pRec.front = cFront;
        if ( pRec.right < pRec.left )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.left, ref pRec.right );
        }
        if ( pRec.bottom < pRec.top )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.top, ref pRec.bottom );
        }
        if ( pRec.front < pRec.back )
        {
            AppMain.MTM_MATH_SWAP<short>( ref pRec.back, ref pRec.front );
        }
        return pRec;
    }

    // Token: 0x06000F09 RID: 3849 RVA: 0x000844F5 File Offset: 0x000826F5
    public static AppMain.OBS_RECT ObjRectWorkSet( AppMain.OBS_RECT_WORK pRec, short cLeft, short cTop, short cRight, short cBottom )
    {
        pRec.flag |= 4U;
        return AppMain.ObjRectSet( pRec.rect, cLeft, cTop, cRight, cBottom );
    }

    // Token: 0x06000F0A RID: 3850 RVA: 0x00084515 File Offset: 0x00082715
    public static AppMain.OBS_RECT ObjRectWorkZSet( AppMain.OBS_RECT_WORK pRec, short cLeft, short cTop, short cBack, short cRight, short cBottom, short cFront )
    {
        pRec.flag |= 4U;
        return AppMain.ObjRectZSet( pRec.rect, cLeft, cTop, cBack, cRight, cBottom, cFront );
    }

    // Token: 0x06000F0B RID: 3851 RVA: 0x00084539 File Offset: 0x00082739
    public static AppMain.OBS_RECT ObjRectWorkAllSet( AppMain.OBS_RECT_WORK pRec, AppMain.VecFx32 pos, short cLeft, short cTop, short cBack, short cRight, short cBottom, short cFront )
    {
        pRec.flag |= 4U;
        return AppMain.ObjRectAllSet( pRec.rect, pos, cLeft, cTop, cBack, cRight, cBottom, cFront );
    }

    // Token: 0x06000F0C RID: 3852 RVA: 0x0008455F File Offset: 0x0008275F
    public static void ObjRectGroupSet( AppMain.OBS_RECT_WORK pRec, byte group_no, byte target_g_flag )
    {
        pRec.group_no = group_no;
        pRec.target_g_flag = target_g_flag;
    }

    // Token: 0x06000F0D RID: 3853 RVA: 0x00084570 File Offset: 0x00082770
    public static void ObjRectAtkSet( AppMain.OBS_RECT_WORK pRec, ushort usHitFlag, short sHitPower )
    {
        pRec.flag |= 4U;
        pRec.hit_flag = usHitFlag;
        pRec.hit_power = sHitPower;
        pRec.flag &= 4294966783U;
        pRec.flag &= 4294901759U;
    }

    // Token: 0x06000F0E RID: 3854 RVA: 0x000845BD File Offset: 0x000827BD
    public static void ObjRectDefSet( AppMain.OBS_RECT_WORK pRec, ushort usDefFlag, short sDefPower )
    {
        pRec.flag |= 4U;
        pRec.def_flag = usDefFlag;
        pRec.def_power = sDefPower;
        pRec.flag &= 4294967039U;
    }

    // Token: 0x06000F0F RID: 3855 RVA: 0x000845ED File Offset: 0x000827ED
    public static void ObjRectHitAgain( AppMain.OBS_RECT_WORK pRec )
    {
        if ( ( pRec.flag & 1024U ) == 0U )
        {
            pRec.flag &= 4294967039U;
            pRec.flag &= 4294966783U;
        }
    }

    // Token: 0x06000F10 RID: 3856 RVA: 0x00084624 File Offset: 0x00082824
    public static void ObjRectCheckInit()
    {
        Array.Clear( AppMain._obj_user_resist_nx, 0, AppMain._obj_user_resist_nx.Length );
        Array.Clear( AppMain._obj_user_resist, 0, AppMain._obj_user_resist.Length );
        Array.Clear( AppMain._obj_user_resist_num, 0, AppMain._obj_user_resist_num.Length );
        Array.Clear( AppMain._obj_user_resist_num_nx, 0, AppMain._obj_user_resist_num_nx.Length );
        Array.Clear( AppMain._obj_user_flag, 0, AppMain._obj_user_flag.Length );
        Array.Clear( AppMain._obj_user_flag_nx, 0, AppMain._obj_user_flag_nx.Length );
        AppMain._obj_user_resist_all_num = 0;
        AppMain._obj_user_resist_all_num_nx = 0;
        AppMain._obj_ulFlagBackA = 0U;
        AppMain._obj_ulFlagBackD = 0U;
        AppMain._obj_ucNoHit = 0;
    }

    // Token: 0x06000F11 RID: 3857 RVA: 0x000846BC File Offset: 0x000828BC
    private static void objRectCheckOut()
    {
        Array.Copy( AppMain._obj_user_resist_nx, AppMain._obj_user_resist, AppMain._obj_user_resist.Length );
        Array.Clear( AppMain._obj_user_resist_nx, 0, AppMain._obj_user_resist_nx.Length );
        Array.Copy( AppMain._obj_user_resist_num_nx, AppMain._obj_user_resist_num, AppMain._obj_user_resist_num.Length );
        Array.Clear( AppMain._obj_user_resist_num_nx, 0, AppMain._obj_user_resist_num_nx.Length );
        Array.Copy( AppMain._obj_user_flag_nx, AppMain._obj_user_flag, AppMain._obj_user_flag.Length );
        Array.Clear( AppMain._obj_user_flag_nx, 0, AppMain._obj_user_flag_nx.Length );
        AppMain._obj_user_resist_all_num = AppMain._obj_user_resist_all_num_nx;
        AppMain._obj_user_resist_all_num_nx = 0;
        for ( ushort num = 0; num < AppMain._obj_user_resist_all_num - 1; num += 1 )
        {
            for ( ushort num2 = ( ushort )( AppMain._obj_user_resist_all_num - 1 ); num2 > num; num2 -= 1 )
            {
                if ( AppMain._obj_user_resist[( int )num2].group_no < AppMain._obj_user_resist[( int )( num2 - 1 )].group_no )
                {
                    AppMain.OBS_RECT_WORK obs_RECT_WORK = AppMain._obj_user_resist[(int)(num2 - 1)];
                    AppMain._obj_user_resist[( int )( num2 - 1 )] = AppMain._obj_user_resist[( int )num2];
                    AppMain._obj_user_resist[( int )num2] = obs_RECT_WORK;
                }
            }
        }
    }

    // Token: 0x06000F12 RID: 3858 RVA: 0x000847B8 File Offset: 0x000829B8
    private static void ObjRectRegist( AppMain.OBS_RECT_WORK pObj )
    {
        if ( ( pObj.flag & 4U ) != 0U && pObj.group_no < 8 && AppMain._obj_user_resist_all_num_nx < 80 )
        {
            AppMain._obj_user_resist_nx[( int )AppMain._obj_user_resist_all_num_nx] = pObj;
            ushort[] obj_user_flag_nx = AppMain._obj_user_flag_nx;
            byte group_no = pObj.group_no;
            obj_user_flag_nx[( int )group_no] = ( ushort )( ( obj_user_flag_nx[( int )group_no] | ( ushort )pObj.target_g_flag ) );
            byte[] obj_user_resist_num_nx = AppMain._obj_user_resist_num_nx;
            byte group_no2 = pObj.group_no;
            obj_user_resist_num_nx[( int )group_no2] = ( byte )( obj_user_resist_num_nx[( int )group_no2] + 1 );
            AppMain._obj_user_resist_all_num_nx += 1;
        }
    }

    // Token: 0x06000F13 RID: 3859 RVA: 0x0008483C File Offset: 0x00082A3C
    private static void ObjRectCheckAllGroup()
    {
        if ( ( AppMain.g_obj.flag & 131072U ) != 0U )
        {
            AppMain.objRectCheckOut();
        }
        AppMain._obj_ulFlagBackA = 0U;
        AppMain._obj_ulFlagBackD = 0U;
        AppMain._obj_ucNoHit = 0;
        for ( ushort num = 0; num < AppMain._obj_user_resist_all_num; num += 1 )
        {
            if ( AppMain._obj_user_resist[( int )num] != null && ( AppMain._obj_user_resist[( int )num].flag & 1024U ) != 0U )
            {
                AppMain._obj_user_resist[( int )num].flag &= 4294836223U;
            }
        }
        ushort num2 = 0;
        for ( ushort num = 0; num < 8; num += 1 )
        {
            ushort num3 = 0;
            for ( byte b = 0; b < 8; b += 1 )
            {
                if ( AppMain._obj_user_resist_num[( int )b] != 0 && ( ( int )AppMain._obj_user_flag[( int )num] & 1 << ( int )b ) != 0 )
                {
                    AppMain.objRectCheckGroup( new AppMain.ArrayPointer<AppMain.OBS_RECT_WORK>( AppMain._obj_user_resist, ( int )num2 ), new AppMain.ArrayPointer<AppMain.OBS_RECT_WORK>( AppMain._obj_user_resist, ( int )num3 ), AppMain._obj_user_resist_num[( int )num], AppMain._obj_user_resist_num[( int )b], b );
                }
                num3 += ( ushort )AppMain._obj_user_resist_num[( int )b];
            }
            num2 += ( ushort )AppMain._obj_user_resist_num[( int )num];
        }
        for ( ushort num = 0; num < AppMain._obj_user_resist_all_num; num += 1 )
        {
            if ( AppMain._obj_user_resist[( int )num] != null )
            {
                if ( ( AppMain._obj_user_resist[( int )num].flag & 65536U ) != 0U )
                {
                    AppMain._obj_user_resist[( int )num].flag |= 512U;
                    AppMain._obj_user_resist[( int )num].flag &= 4294901759U;
                }
                if ( ( AppMain._obj_user_resist[( int )num].flag & 1024U ) != 0U && ( AppMain._obj_user_resist[( int )num].flag & 131072U ) == 0U )
                {
                    AppMain._obj_user_resist[( int )num].flag &= 4294705151U;
                }
            }
        }
        if ( ( AppMain.g_obj.flag & 131072U ) == 0U )
        {
            AppMain.objRectCheckOut();
        }
    }

    // Token: 0x06000F14 RID: 3860 RVA: 0x000849F0 File Offset: 0x00082BF0
    private static AppMain.OBS_RECT_WORK ObjRectRegistGet( byte ucGroup, short sIndex )
    {
        ushort num = 0;
        for ( short num2 = 0; num2 < 8; num2 += 1 )
        {
            if ( ( ( int )ucGroup & 1 << ( int )num2 ) != 0 )
            {
                if ( sIndex < ( short )AppMain._obj_user_resist_num[( int )num2] )
                {
                    return AppMain._obj_user_resist[( int )( num + ( ushort )sIndex )];
                }
                sIndex -= ( short )AppMain._obj_user_resist_num[( int )num2];
                num += ( ushort )AppMain._obj_user_resist_num[( int )num2];
                if ( sIndex <= 0 )
                {
                }
            }
            else
            {
                num += ( ushort )AppMain._obj_user_resist_num[( int )num2];
            }
        }
        return null;
    }

    // Token: 0x06000F15 RID: 3861 RVA: 0x00084A58 File Offset: 0x00082C58
    private static AppMain.OBS_RECT_WORK ObjRectRegistNxGet( byte ucGroup, short sIndex )
    {
        ushort num = 0;
        for ( short num2 = 0; num2 < 8; num2 += 1 )
        {
            if ( ( ( int )ucGroup & 1 << ( int )num2 ) != 0 )
            {
                if ( sIndex < ( short )AppMain._obj_user_resist_num_nx[( int )num2] )
                {
                    return AppMain._obj_user_resist_nx[( int )( num + ( ushort )sIndex )];
                }
                sIndex -= ( short )AppMain._obj_user_resist_num_nx[( int )num2];
                num += ( ushort )AppMain._obj_user_resist_num_nx[( int )num2];
                if ( sIndex <= 0 )
                {
                }
            }
            else
            {
                num += ( ushort )AppMain._obj_user_resist_num_nx[( int )num2];
            }
        }
        return null;
    }

    // Token: 0x06000F16 RID: 3862 RVA: 0x00084AC0 File Offset: 0x00082CC0
    private static void objRectCheckGroup( AppMain.ArrayPointer<AppMain.OBS_RECT_WORK> GroupA, AppMain.ArrayPointer<AppMain.OBS_RECT_WORK> GroupD, byte GroupNumA, byte GroupNumD, byte Index )
    {
        int x = 0;
        int x2 = 0;
        int x3 = 0;
        int x4 = 0;
        int num = 0;
        int num2 = 0;
        ushort w = 0;
        ushort w2 = 0;
        ushort w3 = 0;
        ushort w4 = 0;
        ushort num3 = 0;
        ushort num4 = 0;
        for ( ushort num5 = 0; num5 < ( ushort )GroupNumA; num5 += 1 )
        {
            AppMain.OBS_RECT_WORK obs_RECT_WORK = GroupA[(int)num5];
            if ( obs_RECT_WORK != null && ( obs_RECT_WORK.flag & 2048U ) == 0U && ( obs_RECT_WORK.flag & 4U ) != 0U && ( ( int )obs_RECT_WORK.target_g_flag & 1 << ( int )Index ) != 0 && ( obs_RECT_WORK.parent_obj == null || ( obs_RECT_WORK.parent_obj.flag & 6U ) == 0U ) )
            {
                AppMain.ObjRectLTBSet( obs_RECT_WORK, ref x, ref x2, ref num );
                AppMain.ObjRectWHDSet( obs_RECT_WORK, ref w, ref w2, ref num3 );
                for ( ushort num6 = 0; num6 < ( ushort )GroupNumD; num6 += 1 )
                {
                    AppMain.OBS_RECT_WORK obs_RECT_WORK2 = GroupD[(int)num6];
                    if ( GroupA[( int )num5] == null )
                    {
                        break;
                    }
                    if ( obs_RECT_WORK2 != null && obs_RECT_WORK2 != obs_RECT_WORK && ( obs_RECT_WORK2.parent_obj != obs_RECT_WORK.parent_obj || obs_RECT_WORK2.parent_obj == null ) && ( ( obs_RECT_WORK2.flag | obs_RECT_WORK.flag ) & 2048U ) == 0U && ( obs_RECT_WORK2.flag & 4U ) != 0U && ( obs_RECT_WORK2.parent_obj == null || ( obs_RECT_WORK2.parent_obj.flag & 6U ) == 0U ) )
                    {
                        AppMain.ObjRectLTBSet( obs_RECT_WORK2, ref x3, ref x4, ref num2 );
                        AppMain.ObjRectWHDSet( obs_RECT_WORK2, ref w3, ref w4, ref num4 );
                        if ( ( ( obs_RECT_WORK2.flag | obs_RECT_WORK.flag ) & 524288U ) != 0U || ( AppMain.OBM_LINE_AND_LINE( x, ( int )w, x3, ( int )w3 ) && AppMain.OBM_LINE_AND_LINE( x2, ( int )w2, x4, ( int )w4 ) ) )
                        {
                            ushort num7 = AppMain.objRectCheckFuncCall(obs_RECT_WORK, obs_RECT_WORK2);
                            if ( ( num7 & 1 ) != 0 )
                            {
                                if ( ( obs_RECT_WORK.flag & 65536U ) != 0U )
                                {
                                    obs_RECT_WORK.flag |= 512U;
                                    obs_RECT_WORK.flag &= 4294901759U;
                                }
                                GroupA.SetPrimitive( ( int )num5, null );
                            }
                            if ( ( num7 & 2 ) != 0 )
                            {
                                if ( ( obs_RECT_WORK2.flag & 65536U ) != 0U )
                                {
                                    obs_RECT_WORK2.flag |= 512U;
                                    obs_RECT_WORK2.flag &= 4294901759U;
                                }
                                GroupD.SetPrimitive( ( int )num6, null );
                            }
                        }
                    }
                }
            }
        }
    }

    // Token: 0x06000F17 RID: 3863 RVA: 0x00084CE4 File Offset: 0x00082EE4
    private static void ObjRectPosGet( AppMain.VecFx32 vPos, AppMain.OBS_RECT_WORK pRec )
    {
        if ( pRec.parent_obj != null && ( pRec.flag & 4096U ) == 0U )
        {
            vPos.x = pRec.parent_obj.pos.x + pRec.rect.pos.x;
            vPos.y = pRec.parent_obj.pos.y + pRec.rect.pos.y;
            vPos.z = pRec.parent_obj.pos.z + pRec.rect.pos.z;
            return;
        }
        vPos.x = pRec.rect.pos.x;
        vPos.y = pRec.rect.pos.y;
        vPos.z = pRec.rect.pos.z;
    }

    // Token: 0x06000F18 RID: 3864 RVA: 0x00084DC8 File Offset: 0x00082FC8
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, ref int lLeft, ref int lTop, ref int lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref lLeft, ref lTop, ref lBack, true, true, true );
    }

    // Token: 0x06000F19 RID: 3865 RVA: 0x00084DD6 File Offset: 0x00082FD6
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, int? lLeft, ref int lTop, ref int lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref AppMain.mppIntNULL, ref lTop, ref lBack, false, true, true );
    }

    // Token: 0x06000F1A RID: 3866 RVA: 0x00084DE8 File Offset: 0x00082FE8
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, ref int lLeft, int? lTop, ref int lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref lLeft, ref AppMain.mppIntNULL, ref lBack, true, false, true );
    }

    // Token: 0x06000F1B RID: 3867 RVA: 0x00084DFA File Offset: 0x00082FFA
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, int? lLeft, int? lTop, ref int lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref AppMain.mppIntNULL, ref AppMain.mppIntNULL, ref lBack, false, false, true );
    }

    // Token: 0x06000F1C RID: 3868 RVA: 0x00084E10 File Offset: 0x00083010
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, ref int lLeft, ref int lTop, int? lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref lLeft, ref lTop, ref AppMain.mppIntNULL, true, true, false );
    }

    // Token: 0x06000F1D RID: 3869 RVA: 0x00084E22 File Offset: 0x00083022
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, int? lLeft, ref int lTop, int? lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref AppMain.mppIntNULL, ref lTop, ref AppMain.mppIntNULL, false, true, false );
    }

    // Token: 0x06000F1E RID: 3870 RVA: 0x00084E38 File Offset: 0x00083038
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, ref int lLeft, int? lTop, int? lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref lLeft, ref AppMain.mppIntNULL, ref AppMain.mppIntNULL, true, false, false );
    }

    // Token: 0x06000F1F RID: 3871 RVA: 0x00084E4E File Offset: 0x0008304E
    private static void ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, int? lLeft, int? lTop, int? lBack )
    {
        AppMain._ObjRectLTBSet( pRec, ref AppMain.mppIntNULL, ref AppMain.mppIntNULL, ref AppMain.mppIntNULL, false, false, false );
    }

    // Token: 0x06000F20 RID: 3872 RVA: 0x00084E68 File Offset: 0x00083068
    private static void _ObjRectLTBSet( AppMain.OBS_RECT_WORK pRec, ref int lLeft, ref int lTop, ref int lBack, bool lLeftValid, bool lTopValid, bool lBackValid )
    {
        if ( pRec.parent_obj != null && ( pRec.flag & 4096U ) == 0U )
        {
            if ( lLeftValid )
            {
                int num;
                if ( ( ( pRec.parent_obj.disp_flag & 1U ) ^ ( pRec.flag & 1U ) ) != 0U )
                {
                    num = ( int )( -( int )pRec.rect.right );
                }
                else
                {
                    num = ( int )pRec.rect.left;
                }
                if ( pRec.parent_obj.scale.x != 4096 )
                {
                    num = AppMain.FX_Mul( num, pRec.parent_obj.scale.x );
                }
                if ( AppMain._g_obj.draw_scale.x != 4096 && ( pRec.parent_obj.disp_flag & 1048576U ) == 0U && ( AppMain._g_obj.flag & 4194304U ) == 0U )
                {
                    num = AppMain.FX_Mul( num, AppMain._g_obj.draw_scale.x );
                }
                lLeft = ( pRec.parent_obj.pos.x + pRec.rect.pos.x >> 12 ) + num;
            }
            if ( lTopValid )
            {
                int num;
                if ( ( ( pRec.parent_obj.disp_flag & 2U ) ^ ( pRec.flag & 2U ) ) != 0U )
                {
                    num = ( int )( -( int )pRec.rect.bottom );
                }
                else
                {
                    num = ( int )pRec.rect.top;
                }
                if ( pRec.parent_obj.scale.y != 4096 )
                {
                    num = AppMain.FX_Mul( num, pRec.parent_obj.scale.y );
                }
                if ( AppMain._g_obj.draw_scale.y != 4096 && ( pRec.parent_obj.disp_flag & 1048576U ) == 0U && ( AppMain._g_obj.flag & 4194304U ) == 0U )
                {
                    num = AppMain.FX_Mul( num, AppMain._g_obj.draw_scale.y );
                }
                lTop = ( pRec.parent_obj.pos.y + pRec.rect.pos.y >> 12 ) + num;
            }
            if ( lBackValid )
            {
                int num = (int)pRec.rect.back;
                if ( pRec.parent_obj.scale.z != 4096 )
                {
                    num = AppMain.FX_Mul( num, pRec.parent_obj.scale.z );
                }
                if ( AppMain._g_obj.draw_scale.z != 4096 && ( pRec.parent_obj.disp_flag & 1048576U ) == 0U && ( AppMain.g_obj.flag & 4194304U ) == 0U )
                {
                    num = AppMain.FX_Mul( num, AppMain.g_obj.draw_scale.z );
                }
                lBack = ( pRec.parent_obj.pos.z + pRec.rect.pos.z >> 12 ) + num;
                return;
            }
        }
        else
        {
            if ( lLeftValid )
            {
                int num;
                if ( ( pRec.flag & 1U ) != 0U )
                {
                    num = ( int )( -( int )pRec.rect.right );
                }
                else
                {
                    num = ( int )pRec.rect.left;
                }
                lLeft = ( pRec.rect.pos.x >> 12 ) + num;
            }
            if ( lTopValid )
            {
                int num;
                if ( ( pRec.flag & 2U ) != 0U )
                {
                    num = ( int )( -( int )pRec.rect.bottom );
                }
                else
                {
                    num = ( int )pRec.rect.top;
                }
                lTop = ( pRec.rect.pos.y >> 12 ) + num;
            }
            if ( lBackValid )
            {
                lBack = ( pRec.rect.pos.z >> 12 ) + ( int )pRec.rect.back;
            }
        }
    }

    // Token: 0x06000F21 RID: 3873 RVA: 0x000851B5 File Offset: 0x000833B5
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ref ushort usWidth, ref ushort usHeight, ref ushort usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref usWidth, ref usHeight, ref usDepth, true, true, true );
    }

    // Token: 0x06000F22 RID: 3874 RVA: 0x000851C3 File Offset: 0x000833C3
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ushort? usWidth, ref ushort usHeight, ref ushort usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref AppMain.mppUshortNULL, ref usHeight, ref usDepth, false, true, true );
    }

    // Token: 0x06000F23 RID: 3875 RVA: 0x000851D5 File Offset: 0x000833D5
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ref ushort usWidth, ushort? usHeight, ref ushort usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref usWidth, ref AppMain.mppUshortNULL, ref usDepth, true, false, true );
    }

    // Token: 0x06000F24 RID: 3876 RVA: 0x000851E7 File Offset: 0x000833E7
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ushort? usWidth, ushort? usHeight, ref ushort usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref AppMain.mppUshortNULL, ref AppMain.mppUshortNULL, ref usDepth, false, false, true );
    }

    // Token: 0x06000F25 RID: 3877 RVA: 0x000851FD File Offset: 0x000833FD
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ref ushort usWidth, ref ushort usHeight, ushort? usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref usWidth, ref usHeight, ref AppMain.mppUshortNULL, true, true, false );
    }

    // Token: 0x06000F26 RID: 3878 RVA: 0x0008520F File Offset: 0x0008340F
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ushort? usWidth, ref ushort usHeight, ushort? usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref AppMain.mppUshortNULL, ref usHeight, ref AppMain.mppUshortNULL, false, true, false );
    }

    // Token: 0x06000F27 RID: 3879 RVA: 0x00085225 File Offset: 0x00083425
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ref ushort usWidth, ushort? usHeight, ushort? usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref usWidth, ref AppMain.mppUshortNULL, ref AppMain.mppUshortNULL, true, false, false );
    }

    // Token: 0x06000F28 RID: 3880 RVA: 0x0008523B File Offset: 0x0008343B
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ushort? usWidth, ushort? usHeight, ushort? usDepth )
    {
        AppMain.ObjRectWHDSet( pRec, ref AppMain.mppUshortNULL, ref AppMain.mppUshortNULL, ref AppMain.mppUshortNULL, false, false, false );
    }

    // Token: 0x06000F29 RID: 3881 RVA: 0x00085258 File Offset: 0x00083458
    private static void ObjRectWHDSet( AppMain.OBS_RECT_WORK pRec, ref ushort usWidth, ref ushort usHeight, ref ushort usDepth, bool usWidthValid, bool usHeightValid, bool usDepthValid )
    {
        if ( pRec.parent_obj != null && ( pRec.flag & 4096U ) == 0U )
        {
            if ( usWidthValid )
            {
                usWidth = ( ushort )( pRec.rect.right - pRec.rect.left );
                int num = 4096;
                if ( pRec.parent_obj.scale.x != 4096 )
                {
                    num = pRec.parent_obj.scale.x;
                }
                if ( AppMain._g_obj.draw_scale.x != 4096 && ( pRec.parent_obj.disp_flag & 1048576U ) == 0U && ( AppMain._g_obj.flag & 4194304U ) == 0U )
                {
                    num = AppMain.FX_Mul( num, AppMain._g_obj.draw_scale.x );
                }
                if ( num != 4096 )
                {
                    usWidth = ( ushort )AppMain.FX_Mul( ( int )usWidth, num );
                }
            }
            if ( usHeightValid )
            {
                usHeight = ( ushort )( pRec.rect.bottom - pRec.rect.top );
                int num = 4096;
                if ( pRec.parent_obj.scale.y != 4096 )
                {
                    num = pRec.parent_obj.scale.y;
                }
                if ( AppMain._g_obj.draw_scale.y != 4096 && ( pRec.parent_obj.disp_flag & 1048576U ) == 0U && ( AppMain._g_obj.flag & 4194304U ) == 0U )
                {
                    num = AppMain.FX_Mul( num, AppMain._g_obj.draw_scale.y );
                }
                if ( num != 4096 )
                {
                    usHeight = ( ushort )AppMain.FX_Mul( ( int )usHeight, num );
                }
            }
            if ( usDepthValid )
            {
                usDepth = ( ushort )( pRec.rect.front - pRec.rect.back );
                int num = 4096;
                if ( pRec.parent_obj.scale.z != 4096 )
                {
                    num = pRec.parent_obj.scale.z;
                }
                if ( AppMain._g_obj.draw_scale.z != 4096 && ( pRec.parent_obj.disp_flag & 1048576U ) == 0U && ( AppMain._g_obj.flag & 4194304U ) == 0U )
                {
                    num = AppMain.FX_Mul( num, AppMain._g_obj.draw_scale.z );
                }
                if ( num != 4096 )
                {
                    usDepth = ( ushort )AppMain.FX_Mul( ( int )usDepth, num );
                    return;
                }
            }
        }
        else
        {
            if ( usWidthValid )
            {
                usWidth = ( ushort )( pRec.rect.right - pRec.rect.left );
            }
            if ( usHeightValid )
            {
                usHeight = ( ushort )( pRec.rect.bottom - pRec.rect.top );
            }
            if ( usDepthValid )
            {
                usDepth = ( ushort )( pRec.rect.front - pRec.rect.back );
            }
        }
    }

    // Token: 0x06000F2A RID: 3882 RVA: 0x000854F5 File Offset: 0x000836F5
    private static ushort ObjRectFlagCheck( uint ulAtkFlag, uint usDefFlag, int lAtkPower, int lDefPower )
    {
        if ( ( ulAtkFlag & ~( usDefFlag != 0U ? 1 : 0 ) ) != 0U && lAtkPower >= lDefPower )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000F2B RID: 3883 RVA: 0x00085504 File Offset: 0x00083704
    private static void ObjRectFuncblank( AppMain.OBS_RECT_WORK pObjA, AppMain.OBS_RECT_WORK pObjD )
    {
    }

    // Token: 0x06000F2C RID: 3884 RVA: 0x00085508 File Offset: 0x00083708
    private static ushort objRectCheckFuncCall( AppMain.OBS_RECT_WORK pObjA, AppMain.OBS_RECT_WORK pObjD )
    {
        ushort num = 0;
        AppMain._obj_ulFlagBackA = pObjA.flag;
        AppMain._obj_ulFlagBackD = pObjD.flag;
        if ( ( pObjA.flag & 512U ) != 0U && ( pObjD.flag & 256U ) != 0U )
        {
            return num;
        }
        if ( AppMain.ObjRectFlagCheck( ( uint )pObjA.hit_flag, ( uint )pObjD.def_flag, ( int )pObjA.hit_power, ( int )pObjD.def_power ) != 0 )
        {
            if ( pObjA.ppCheck != null && pObjA.ppCheck( pObjA, pObjD ) == 0U )
            {
                return num;
            }
            if ( pObjD.ppCheck != null && pObjD.ppCheck( pObjD, pObjA ) == 0U )
            {
                return num;
            }
            if ( ( pObjD.flag & 1088U ) == 0U && ( pObjA.flag & 1088U ) == 0U )
            {
                pObjA.flag |= 65536U;
            }
            if ( ( pObjD.flag & 1152U ) == 0U && ( pObjA.flag & 1152U ) == 0U )
            {
                pObjD.flag |= 256U;
            }
            if ( ( pObjA.flag & 1024U ) == 0U || ( pObjA.flag & 262144U ) == 0U )
            {
                if ( ( pObjA.flag & 1024U ) != 0U )
                {
                    pObjA.flag |= 262144U;
                }
                if ( pObjA.ppHit != null )
                {
                    pObjA.ppHit( pObjA, pObjD );
                }
            }
            if ( AppMain._obj_ucNoHit != 0 )
            {
                AppMain._obj_ucNoHit = 0;
                return num;
            }
            if ( ( pObjA.flag & 1024U ) != 0U )
            {
                pObjA.flag |= 131072U;
            }
            if ( ( pObjD.flag & 1024U ) == 0U || ( pObjD.flag & 262144U ) == 0U )
            {
                if ( ( pObjD.flag & 1024U ) != 0U )
                {
                    pObjD.flag |= 262144U;
                }
                if ( pObjD.ppDef != null )
                {
                    pObjD.ppDef( pObjD, pObjA );
                }
            }
            if ( AppMain._obj_ucNoHit != 0 )
            {
                AppMain._obj_ucNoHit = 0;
                return num;
            }
            if ( ( pObjD.flag & 1024U ) != 0U )
            {
                pObjD.flag |= 131072U;
            }
            if ( ( pObjA.flag & 32U ) == 0U )
            {
                num |= 1;
            }
            if ( ( pObjD.flag & 32U ) == 0U )
            {
                num |= 2;
            }
        }
        return num;
    }

    // Token: 0x06000F2D RID: 3885 RVA: 0x0008571C File Offset: 0x0008391C
    private static void ObjRectFuncNoHit( AppMain.OBS_RECT_WORK pMine, AppMain.OBS_RECT_WORK pDamage )
    {
        pMine.flag = AppMain._obj_ulFlagBackA;
        pDamage.flag = AppMain._obj_ulFlagBackD;
        AppMain._obj_ucNoHit = 1;
    }

    // Token: 0x06000F2E RID: 3886 RVA: 0x0008573C File Offset: 0x0008393C
    private static ushort ObjRectWorkCheck( AppMain.OBS_RECT_WORK pObj1, AppMain.OBS_RECT_WORK pObj2 )
    {
        if ( ( pObj1.flag & 4U ) != 0U && ( pObj2.flag & 4U ) != 0U && ( pObj1.flag & 2048U ) == 0U && ( pObj2.flag & 2048U ) == 0U )
        {
            int x = 0;
            int x2 = 0;
            int x3 = 0;
            int x4 = 0;
            ushort w = 0;
            ushort w2 = 0;
            ushort w3 = 0;
            ushort w4 = 0;
            int num = 0;
            int num2 = 0;
            ushort num3 = 0;
            ushort num4 = 0;
            if ( pObj1.parent_obj != null && ( pObj1.parent_obj.flag & 6U ) != 0U )
            {
                return 0;
            }
            if ( pObj2.parent_obj != null && ( pObj2.parent_obj.flag & 6U ) != 0U )
            {
                return 0;
            }
            AppMain.ObjRectLTBSet( pObj1, ref x, ref x2, ref num );
            AppMain.ObjRectLTBSet( pObj2, ref x3, ref x4, ref num2 );
            AppMain.ObjRectWHDSet( pObj1, ref w, ref w2, ref num3 );
            AppMain.ObjRectWHDSet( pObj2, ref w3, ref w4, ref num4 );
            if ( AppMain.OBM_LINE_AND_LINE( x, ( int )w, x3, ( int )w3 ) && AppMain.OBM_LINE_AND_LINE( x2, ( int )w2, x4, ( int )w4 ) )
            {
                return 1;
            }
        }
        return 0;
    }

    // Token: 0x06000F2F RID: 3887 RVA: 0x00085824 File Offset: 0x00083A24
    private static ushort ObjRectCheck( AppMain.OBS_RECT pObj1, AppMain.OBS_RECT pObj2 )
    {
        int x = (pObj1.pos.x >> 12) + (int)pObj1.left;
        int x2 = (pObj1.pos.y >> 12) + (int)pObj1.top;
        int z = pObj1.pos.z;
        short back = pObj1.back;
        int x3 = (pObj2.pos.x >> 12) + (int)pObj2.left;
        int x4 = (pObj2.pos.y >> 12) + (int)pObj2.top;
        int z2 = pObj2.pos.z;
        short back2 = pObj2.back;
        ushort w = (ushort)(pObj1.right - pObj1.left);
        ushort w2 = (ushort)(pObj1.bottom - pObj1.top);
        ushort w3 = (ushort)(pObj2.right - pObj2.left);
        ushort w4 = (ushort)(pObj2.bottom - pObj2.top);
        short front = pObj1.front;
        short back3 = pObj1.back;
        short front2 = pObj1.front;
        short back4 = pObj2.back;
        if ( AppMain.OBM_LINE_AND_LINE( x, ( int )w, x3, ( int )w3 ) && AppMain.OBM_LINE_AND_LINE( x2, ( int )w2, x4, ( int )w4 ) )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000F30 RID: 3888 RVA: 0x00085928 File Offset: 0x00083B28
    private static ushort ObjRectWorkPointCheck( AppMain.OBS_RECT_WORK pObj, int lX, int lY, int lZ )
    {
        if ( ( pObj.flag & 4U ) != 0U && ( pObj.flag & 2048U ) == 0U )
        {
            int x = 0;
            int x2 = 0;
            int num = 0;
            ushort w = 0;
            ushort w2 = 0;
            ushort num2 = 0;
            AppMain.ObjRectLTBSet( pObj, ref x, ref x2, ref num );
            AppMain.ObjRectWHDSet( pObj, ref w, ref w2, ref num2 );
            if ( AppMain.OBM_POINT_IN_LINE( x, ( int )w, lX ) && AppMain.OBM_POINT_IN_LINE( x2, ( int )w2, lY ) )
            {
                return 1;
            }
        }
        return 0;
    }

    // Token: 0x06000F31 RID: 3889 RVA: 0x00085998 File Offset: 0x00083B98
    private static ushort ObjRectPointCheck( AppMain.OBS_RECT pObj, int lX, int lY, int lZ )
    {
        int x = (int)pObj.left + (pObj.pos.x >> 12);
        int x2 = (int)pObj.top + (pObj.pos.y >> 12);
        short back = pObj.back;
        int z = pObj.pos.z;
        ushort w = (ushort)(pObj.right - pObj.left);
        ushort w2 = (ushort)(pObj.bottom - pObj.top);
        short front = pObj.front;
        short back2 = pObj.back;
        if ( AppMain.OBM_POINT_IN_LINE( x, ( int )w, lX ) && AppMain.OBM_POINT_IN_LINE( x2, ( int )w2, lY ) )
        {
            return 1;
        }
        return 0;
    }

    // Token: 0x06000F32 RID: 3890 RVA: 0x00085A30 File Offset: 0x00083C30
    private static int ObjRectCenterX( AppMain.OBS_RECT_WORK pWork )
    {
        int num = pWork.rect.pos.x + (pWork.rect.left + pWork.rect.right >> 1 << 12);
        if ( pWork.parent_obj != null )
        {
            num += pWork.parent_obj.pos.x;
        }
        return num;
    }

    // Token: 0x06000F33 RID: 3891 RVA: 0x00085A88 File Offset: 0x00083C88
    private static int ObjRectCenterY( AppMain.OBS_RECT_WORK pWork )
    {
        int num = pWork.rect.pos.y + (pWork.rect.top + pWork.rect.bottom >> 1 << 12);
        if ( pWork.parent_obj != null )
        {
            num += pWork.parent_obj.pos.y;
        }
        return num;
    }

    // Token: 0x06000F34 RID: 3892 RVA: 0x00085AE0 File Offset: 0x00083CE0
    private static int ObjRectCenterZ( AppMain.OBS_RECT_WORK pWork )
    {
        int num = pWork.rect.pos.z + (pWork.rect.back + pWork.rect.front >> 1 << 12);
        if ( pWork.parent_obj != null )
        {
            num += pWork.parent_obj.pos.z;
        }
        return num;
    }

    // Token: 0x06000F35 RID: 3893 RVA: 0x00085B38 File Offset: 0x00083D38
    private static int ObjRectHitCenterX( AppMain.OBS_RECT_WORK pWork, AppMain.OBS_RECT_WORK pAttacker )
    {
        int[] array = new int[4];
        ushort num = 0;
        byte b = 0;
        byte b2 = 0;
        AppMain.ObjRectLTBSet( pWork, ref array[0], default( int? ), default( int? ) );
        AppMain.ObjRectWHDSet( pWork, ref num, default( ushort? ), default( ushort? ) );
        array[1] = array[0] + ( int )num;
        AppMain.ObjRectLTBSet( pAttacker, ref array[2], default( int? ), default( int? ) );
        AppMain.ObjRectWHDSet( pAttacker, ref num, default( ushort? ), default( ushort? ) );
        array[3] = array[2] + ( int )num;
        int num2 = array[(int)b];
        byte b3 = b;
        b += 1;
        if ( array[( int )b] > num2 )
        {
            num2 = array[( int )b];
            b3 = b;
        }
        b += 1;
        if ( array[( int )b] > num2 )
        {
            num2 = array[( int )b];
            b3 = b;
        }
        b += 1;
        if ( array[( int )b] > num2 )
        {
            num2 = array[( int )b];
            b3 = b;
        }
        b += 1;
        b = 0;
        int num3 = array[(int)b];
        byte b4 = b;
        b += 1;
        if ( array[( int )b] < num3 )
        {
            num3 = array[( int )b];
            b4 = b;
        }
        b += 1;
        if ( array[( int )b] < num3 )
        {
            num3 = array[( int )b];
            b4 = b;
        }
        b += 1;
        if ( array[( int )b] < num3 )
        {
            num3 = array[( int )b];
            b4 = b;
        }
        b += 1;
        b = 0;
        for (; ; )
        {
            if ( b != b3 && b != b4 )
            {
                array[( int )b2] = array[( int )b];
                if ( b2 != 0 )
                {
                    break;
                }
                b2 += 1;
            }
            b += 1;
        }
        int num4 = Math.Abs(array[0] - array[1] >> 1);
        if ( array[0] > array[1] )
        {
            num4 += array[1];
        }
        else
        {
            num4 += array[0];
        }
        return num4 << 12;
    }

    // Token: 0x06000F36 RID: 3894 RVA: 0x00085CE8 File Offset: 0x00083EE8
    private static int ObjRectHitCenterY( AppMain.OBS_RECT_WORK pWork, AppMain.OBS_RECT_WORK pAttacker )
    {
        int[] array = new int[4];
        ushort num = 0;
        byte b = 0;
        byte b2 = 0;
        AppMain.ObjRectLTBSet( pWork, default( int? ), ref array[0], default( int? ) );
        AppMain.ObjRectWHDSet( pWork, default( ushort? ), ref num, default( ushort? ) );
        array[1] = array[0] + ( int )num;
        AppMain.ObjRectLTBSet( pAttacker, default( int? ), ref array[2], default( int? ) );
        AppMain.ObjRectWHDSet( pAttacker, default( ushort? ), ref num, default( ushort? ) );
        array[3] = array[2] + ( int )num;
        int num2 = array[(int)b];
        byte b3 = b;
        b += 1;
        if ( array[( int )b] > num2 )
        {
            num2 = array[( int )b];
            b3 = b;
        }
        b += 1;
        if ( array[( int )b] > num2 )
        {
            num2 = array[( int )b];
            b3 = b;
        }
        b += 1;
        if ( array[( int )b] > num2 )
        {
            num2 = array[( int )b];
            b3 = b;
        }
        b += 1;
        b = 0;
        int num3 = array[(int)b];
        byte b4 = b;
        b += 1;
        if ( array[( int )b] < num3 )
        {
            num3 = array[( int )b];
            b4 = b;
        }
        b += 1;
        if ( array[( int )b] < num3 )
        {
            num3 = array[( int )b];
            b4 = b;
        }
        b += 1;
        if ( array[( int )b] < num3 )
        {
            num3 = array[( int )b];
            b4 = b;
        }
        b += 1;
        b = 0;
        for (; ; )
        {
            if ( b != b3 && b != b4 )
            {
                array[( int )b2] = array[( int )b];
                if ( b2 != 0 )
                {
                    break;
                }
                b2 += 1;
            }
            b += 1;
        }
        int num4 = Math.Abs(array[0] - array[1] >> 1);
        if ( array[0] > array[1] )
        {
            num4 += array[1];
        }
        else
        {
            num4 += array[0];
        }
        return num4 << 12;
    }

    // Token: 0x06000F37 RID: 3895 RVA: 0x00085E98 File Offset: 0x00084098
    private static void ObjDebugRectActionInit()
    {
    }
}