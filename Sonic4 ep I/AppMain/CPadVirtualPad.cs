using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Runtime.InteropServices;
using accel;

public partial class AppMain
{
    // Token: 0x020001FD RID: 509
    public class CPadVirtualPad
    {
        // Token: 0x06002326 RID: 8998 RVA: 0x001480BC File Offset: 0x001462BC
        public static AppMain.CPadVirtualPad CreateInstance()
        {
            if ( AppMain.CPadVirtualPad.p_instance == null )
            {
                AppMain.CPadVirtualPad.p_instance = new AppMain.CPadVirtualPad();
            }
            return AppMain.CPadVirtualPad.p_instance;
        }

        // Token: 0x06002327 RID: 8999 RVA: 0x001480D4 File Offset: 0x001462D4
        public bool Create()
        {
            this.m_area.left = 0f;
            this.m_area.top = 0f;
            this.m_area.right = AppMain.AMD_SCREEN_2D_WIDTH;
            this.m_area.bottom = 288f;
            return this.create();
        }

        // Token: 0x06002328 RID: 9000 RVA: 0x00148127 File Offset: 0x00146327
        public bool Create( ref CArray4<float> area )
        {
            this.m_area = area;
            return this.create();
        }

        // Token: 0x06002329 RID: 9001 RVA: 0x0014813C File Offset: 0x0014633C
        public bool Create( ref CArray2<float> area_xy1, ref CArray2<float> area_xy2 )
        {
            this.m_area.left = area_xy1.x;
            this.m_area.top = area_xy1.y;
            this.m_area.right = area_xy2.x;
            this.m_area.bottom = area_xy2.y;
            return this.create();
        }

        // Token: 0x0600232A RID: 9002 RVA: 0x00148194 File Offset: 0x00146394
        public bool Create( float[] area )
        {
            for ( int i = 0; i < 4; i++ )
            {
                this.m_area[i] = area[i];
            }
            return this.create();
        }

        // Token: 0x0600232B RID: 9003 RVA: 0x001481C2 File Offset: 0x001463C2
        public bool Create( float[] area_xy1, float[] area_xy2 )
        {
            this.m_area.left = area_xy1[0];
            this.m_area.top = area_xy1[1];
            this.m_area.right = area_xy2[0];
            this.m_area.bottom = area_xy2[1];
            return this.create();
        }

        // Token: 0x0600232C RID: 9004 RVA: 0x00148202 File Offset: 0x00146402
        public bool Create( float area_left, float area_top, float area_right, float area_bottom )
        {
            this.m_area.left = area_left;
            this.m_area.top = area_top;
            this.m_area.right = area_right;
            this.m_area.bottom = area_bottom;
            return this.create();
        }

        // Token: 0x0600232D RID: 9005 RVA: 0x0014823B File Offset: 0x0014643B
        public void Release()
        {
            if ( this.m_flag[0] )
            {
                this.m_flag[0] = false;
            }
        }

        // Token: 0x0600232E RID: 9006 RVA: 0x00148250 File Offset: 0x00146450
        public bool IsValid()
        {
            return this.m_flag[0];
        }

        // Token: 0x0600232F RID: 9007 RVA: 0x0014825C File Offset: 0x0014645C
        public void Update()
        {
            if ( this.m_flag[0] )
            {
                int i = 0;
                int num = this.m_focus.Length;
                while ( i < num )
                {
                    if ( this.m_focus[i] )
                    {
                        if ( !AppMain.amTpIsTouchOn( i ) || !this.isHit( AppMain._am_tp_touch[i].on ) )
                        {
                            this.m_focus[i] = false;
                        }
                    }
                    else if ( AppMain.amTpIsTouchOn( i ) && this.isHit( AppMain._am_tp_touch[i].on ) )
                    {
                        this.m_focus[i] = true;
                    }
                    i++;
                }
                ushort num2 = 0;
                int j = 0;
                int num3 = this.m_focus.Length;
                while ( j < num3 )
                {
                    if ( this.m_focus[j] )
                    {
                        num2 |= this.getOnFlag( AppMain._am_tp_touch[j].on );
                    }
                    j++;
                }
                if ( 12 == ( 12 & num2 ) )
                {
                    num2 &= 65531;
                }
                if ( 3 == ( 3 & num2 ) )
                {
                    num2 &= 65534;
                }
                this.m_on_flag.push_front( num2 );
            }
        }

        // Token: 0x06002330 RID: 9008 RVA: 0x00148346 File Offset: 0x00146546
        public ushort GetValue()
        {
            return this.m_on_flag[0];
        }

        // Token: 0x06002331 RID: 9009 RVA: 0x00148354 File Offset: 0x00146554
        public bool IsFocus( int tp_index )
        {
            return this.m_focus[tp_index];
        }

        // Token: 0x06002332 RID: 9010 RVA: 0x0014835E File Offset: 0x0014655E
        public bool create()
        {
            this.Release();
            this.m_flag[0] = true;
            return true;
        }

        // Token: 0x06002333 RID: 9011 RVA: 0x00148370 File Offset: 0x00146570
        public bool isHit( ushort[] point )
        {
            CArray2<float> pos = CArray2<float>.initializer((float)point[0], (float)point[1]);
            return this.isHit( pos );
        }

        // Token: 0x06002334 RID: 9012 RVA: 0x00148394 File Offset: 0x00146594
        public bool isHit( CArray2<float> pos )
        {
            bool result = false;
            if ( pos.x >= this.m_area.left && this.m_area.right >= pos.x && pos.y >= this.m_area.top && this.m_area.bottom >= pos.y )
            {
                result = true;
            }
            return result;
        }

        // Token: 0x06002335 RID: 9013 RVA: 0x001483F8 File Offset: 0x001465F8
        public ushort getOnFlag( ushort[] point )
        {
            CArray2<float> pos = CArray2<float>.initializer((float)point[0], (float)point[1]);
            return this.getOnFlag( pos );
        }

        // Token: 0x06002336 RID: 9014 RVA: 0x0014841C File Offset: 0x0014661C
        public ushort getOnFlag( CArray2<float> pos )
        {
            CArray2<float> p = CArray2<float>.initializer((this.m_area.left + this.m_area.right) * 0.5f, (this.m_area.top + this.m_area.bottom) * 0.5f);
            pos.y -= 16f;
            pos.y /= 1.05f;
            ushort num = 0;
            float num2 = 0.4f;
            float num3 = (this.m_area.bottom - this.m_area.top) * num2 * 0.5f;
            CArray2<float> xy = CArray2<float>.initializer(this.m_area.left, p.y - num3);
            CArray2<float> xy2 = CArray2<float>.initializer(p.x, p.y + num3 - 17f);
            CArray2<float> xy3 = CArray2<float>.initializer(p.x, p.y - num3);
            CArray2<float> xy4 = CArray2<float>.initializer(this.m_area.right, p.y + num3 - 17f);
            if ( this.isHit( pos, xy3, xy4 ) )
            {
                num = 8;
            }
            else if ( this.isHit( pos, xy, xy2 ) )
            {
                num = 4;
            }
            if ( num == 0 )
            {
                CArray2<float> carray = CArray2<float>.initializer(this.m_area.left, this.m_area.top);
                CArray2<float> carray2 = CArray2<float>.initializer(this.m_area.right, this.m_area.top);
                CArray2<float> carray3 = CArray2<float>.initializer(this.m_area.left, this.m_area.bottom);
                CArray2<float> carray4 = CArray2<float>.initializer(this.m_area.right, this.m_area.bottom);
                if ( this.isHit( pos, p, carray2, carray4 ) )
                {
                    num = 8;
                }
                else if ( this.isHit( pos, p, carray3, carray ) )
                {
                    num = 4;
                }
                else if ( this.isHit( pos, p, carray, carray2 ) )
                {
                    num = 1;
                }
                else if ( this.isHit( pos, p, carray4, carray3 ) )
                {
                    num = 2;
                }
            }
            return num;
        }

        // Token: 0x06002337 RID: 9015 RVA: 0x00148608 File Offset: 0x00146808
        public bool isHit( CArray2<float> target, CArray2<float> xy1, CArray2<float> xy2 )
        {
            bool result = false;
            if ( target.x >= xy1.x && xy2.x >= target.x && target.y >= xy1.y && xy2.y >= target.y )
            {
                result = true;
            }
            return result;
        }

        // Token: 0x06002338 RID: 9016 RVA: 0x0014865C File Offset: 0x0014685C
        public bool isHit( CArray2<float> target, CArray2<float> p1, CArray2<float> p2, CArray2<float> p3 )
        {
            float num = AppMain.CPadVirtualPad.CLocalLogic.Cross(AppMain._SubrtactArray2(p1, target), AppMain._SubrtactArray2(p2, target));
            float num2 = AppMain.CPadVirtualPad.CLocalLogic.Cross(AppMain._SubrtactArray2(p2, target), AppMain._SubrtactArray2(p3, target));
            float num3 = AppMain.CPadVirtualPad.CLocalLogic.Cross(AppMain._SubrtactArray2(p3, target), AppMain._SubrtactArray2(p1, target));
            return 0f < num * num2 && 0f < num * num3;
        }

        // Token: 0x040055D5 RID: 21973
        private const int c_tp_index_max = 4;

        // Token: 0x040055D6 RID: 21974
        private static AppMain.CPadVirtualPad p_instance;

        // Token: 0x040055D7 RID: 21975
        private bool[] m_flag = new bool[1];

        // Token: 0x040055D8 RID: 21976
        private CArray4<float> m_area;

        // Token: 0x040055D9 RID: 21977
        private readonly bool[] m_focus = new bool[4];

        // Token: 0x040055DA RID: 21978
        private CCircularBuffer<ushort> m_on_flag = new CCircularBuffer<ushort>(2);

        // Token: 0x020001FE RID: 510
        private class CLocalLogic
        {
            // Token: 0x0600233B RID: 9019 RVA: 0x001486F0 File Offset: 0x001468F0
            public static float Cross( CArray2<float> p1, CArray2<float> p2 )
            {
                return p1.x * p2.y - p1.y * p2.x;
            }
        }

        // Token: 0x020001FF RID: 511
        private class BFlag
        {
            // Token: 0x040055DB RID: 21979
            public const int Setup = 0;

            // Token: 0x040055DC RID: 21980
            public const int Max = 1;

            // Token: 0x040055DD RID: 21981
            public const int None = 2;
        }
    }
}