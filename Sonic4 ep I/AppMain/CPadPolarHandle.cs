using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accel;

public partial class AppMain
{
    // Token: 0x02000145 RID: 325
    public class CPadPolarHandle
    {
        // Token: 0x06002096 RID: 8342 RVA: 0x0013F1A6 File Offset: 0x0013D3A6
        public static AppMain.CPadPolarHandle CreateInstance()
        {
            if ( AppMain.CPadPolarHandle.p_instance == null )
            {
                AppMain.CPadPolarHandle.p_instance = new AppMain.CPadPolarHandle();
            }
            return AppMain.CPadPolarHandle.p_instance;
        }

        // Token: 0x06002097 RID: 8343 RVA: 0x0013F1C0 File Offset: 0x0013D3C0
        public bool Create()
        {
            this.m_area.left = 0f;
            this.m_area.top = 0f;
            this.m_area.right = AppMain.AMD_SCREEN_2D_WIDTH;
            this.m_area.bottom = 288f;
            this.m_center.x = AppMain.AMD_SCREEN_2D_WIDTH * 0.5f;
            this.m_center.y = 144f;
            return this.create();
        }

        // Token: 0x06002098 RID: 8344 RVA: 0x0013F23C File Offset: 0x0013D43C
        public bool Create( CArray4<float> area )
        {
            this.m_area = area;
            this.m_center.x = ( this.m_area.left + this.m_area.right ) * 0.5f;
            this.m_center.y = ( this.m_area.top + this.m_area.bottom ) * 0.5f;
            return this.create();
        }

        // Token: 0x06002099 RID: 8345 RVA: 0x0013F2A8 File Offset: 0x0013D4A8
        public bool Create( float[] area )
        {
            this.m_area.left = area[0];
            this.m_area.top = area[1];
            this.m_area.right = area[2];
            this.m_area.bottom = area[3];
            this.m_center.x = ( this.m_area.left + this.m_area.right ) * 0.5f;
            this.m_center.y = ( this.m_area.top + this.m_area.bottom ) * 0.5f;
            return this.create();
        }

        // Token: 0x0600209A RID: 8346 RVA: 0x0013F344 File Offset: 0x0013D544
        public bool Create( float area_left, float area_top, float area_right, float area_bottom )
        {
            this.m_area.left = area_left;
            this.m_area.top = area_top;
            this.m_area.right = area_right;
            this.m_area.bottom = area_bottom;
            this.m_center.x = ( this.m_area.left + this.m_area.right ) * 0.5f;
            this.m_center.y = ( this.m_area.top + this.m_area.bottom ) * 0.5f;
            return this.create();
        }

        // Token: 0x0600209B RID: 8347 RVA: 0x0013F3D8 File Offset: 0x0013D5D8
        public bool Create( CArray2<float> center )
        {
            this.m_area.left = 0f;
            this.m_area.top = 0f;
            this.m_area.right = AppMain.AMD_SCREEN_2D_WIDTH;
            this.m_area.bottom = 288f;
            this.m_center = center;
            return this.create();
        }

        // Token: 0x0600209C RID: 8348 RVA: 0x0013F434 File Offset: 0x0013D634
        public bool Create( float center_x, float center_y )
        {
            this.m_area.left = 0f;
            this.m_area.top = 0f;
            this.m_area.right = AppMain.AMD_SCREEN_2D_WIDTH;
            this.m_area.bottom = 288f;
            this.m_center.x = center_x;
            this.m_center.y = center_y;
            return this.create();
        }

        // Token: 0x0600209D RID: 8349 RVA: 0x0013F49F File Offset: 0x0013D69F
        public bool Create( CArray4<float> area, CArray2<float> center )
        {
            this.m_area = area;
            this.m_center = center;
            return this.create();
        }

        // Token: 0x0600209E RID: 8350 RVA: 0x0013F4B8 File Offset: 0x0013D6B8
        public bool Create( float[] area, float[] center )
        {
            this.m_area.left = area[0];
            this.m_area.top = area[1];
            this.m_area.right = area[2];
            this.m_area.bottom = area[3];
            this.m_center.x = center[0];
            this.m_center.y = center[1];
            return this.create();
        }

        // Token: 0x0600209F RID: 8351 RVA: 0x0013F520 File Offset: 0x0013D720
        public bool Create( float area_left, float area_top, float area_right, float area_bottom, float center_x, float center_y )
        {
            this.m_area.left = area_left;
            this.m_area.top = area_top;
            this.m_area.right = area_right;
            this.m_area.bottom = area_bottom;
            this.m_center.x = center_x;
            this.m_center.y = center_y;
            return this.create();
        }

        // Token: 0x060020A0 RID: 8352 RVA: 0x0013F57E File Offset: 0x0013D77E
        public void Release()
        {
            if ( this.m_flag[0] )
            {
                this.m_flag[0] = false;
            }
        }

        // Token: 0x060020A1 RID: 8353 RVA: 0x0013F593 File Offset: 0x0013D793
        public bool IsValid()
        {
            return this.m_flag[0];
        }

        // Token: 0x060020A2 RID: 8354 RVA: 0x0013F5A0 File Offset: 0x0013D7A0
        public void Update()
        {
            if ( this.m_flag[0] )
            {
                if ( -1 == this.m_focus )
                {
                    int pushTpIndex = this.getPushTpIndex();
                    if ( 0 <= pushTpIndex )
                    {
                        this.m_focus = pushTpIndex;
                        float currentValue = this.getCurrentValue();
                        this.m_zero_point += currentValue;
                        return;
                    }
                }
                else
                {
                    if ( AppMain.amTpIsTouchOn( this.m_focus ) )
                    {
                        float currentValue2 = this.getCurrentValue();
                        this.m_value = currentValue2 - this.m_zero_point;
                        return;
                    }
                    if ( AppMain.amTpIsTouchPull( this.m_focus ) )
                    {
                        this.m_zero_point = -this.m_value;
                        this.m_focus = -1;
                    }
                }
            }
        }

        // Token: 0x060020A3 RID: 8355 RVA: 0x0013F62C File Offset: 0x0013D82C
        public float GetFloatValue()
        {
            return this.m_value;
        }

        // Token: 0x060020A4 RID: 8356 RVA: 0x0013F634 File Offset: 0x0013D834
        public int GetAngle32Value()
        {
            return AppMain.NNM_RADtoA32( this.m_value );
        }

        // Token: 0x060020A5 RID: 8357 RVA: 0x0013F641 File Offset: 0x0013D841
        public bool IsFocus()
        {
            return -1 != this.m_focus;
        }

        // Token: 0x060020A6 RID: 8358 RVA: 0x0013F64F File Offset: 0x0013D84F
        public int GetFocusTpIndex()
        {
            return this.m_focus;
        }

        // Token: 0x060020A7 RID: 8359 RVA: 0x0013F657 File Offset: 0x0013D857
        public void SetValue( float value )
        {
            this.m_zero_point = this.getCurrentValue() - value;
            this.m_value = value;
        }

        // Token: 0x060020A8 RID: 8360 RVA: 0x0013F66E File Offset: 0x0013D86E
        public void SetValue( int value )
        {
            this.SetValue( AppMain.NNM_A32toRAD( value ) );
        }

        // Token: 0x060020A9 RID: 8361 RVA: 0x0013F67C File Offset: 0x0013D87C
        private bool create()
        {
            this.Release();
            this.m_value = 0f;
            this.m_focus = this.getOnTpIndex();
            if ( 0 <= this.m_focus )
            {
                float currentValue = this.getCurrentValue();
                this.m_zero_point = currentValue;
            }
            else
            {
                this.m_zero_point = 0f;
            }
            this.m_flag[0] = true;
            return true;
        }

        // Token: 0x060020AA RID: 8362 RVA: 0x0013F6D4 File Offset: 0x0013D8D4
        private float getCurrentValue()
        {
            float result;
            if ( 0 <= this.m_focus && AppMain.amTpIsTouchOn( this.m_focus ) )
            {
                ushort[] on = AppMain._am_tp_touch[this.m_focus].on;
                if ( AppMain.amTpIsTouchPush( this.m_focus ) )
                {
                    this.m_around = 0;
                }
                else if ( ( float )on[0] <= this.m_center.x && this.m_prev.x <= this.m_center.x )
                {
                    if ( this.m_center.y <= ( float )on[1] )
                    {
                        if ( this.m_prev.y < this.m_center.y )
                        {
                            this.m_around--;
                        }
                    }
                    else if ( this.m_center.y <= this.m_prev.y )
                    {
                        this.m_around++;
                    }
                }
                this.m_prev = CArray2<float>.initializer( ( float )on[0], ( float )on[1] );
                CArray2<float> carray = AppMain._SubrtactArray2(this.m_prev, this.m_center);
                result = ( float )Math.Atan2( ( double )carray.y, ( double )carray.x ) + AppMain.CPadPolarHandle.c_pi * ( float )this.m_around;
            }
            else
            {
                result = 0f;
            }
            return result;
        }

        // Token: 0x060020AB RID: 8363 RVA: 0x0013F804 File Offset: 0x0013DA04
        private int getOnTpIndex()
        {
            int result = -1;
            int i = 0;
            int num = AppMain._am_tp_touch.Length;
            while ( i < num )
            {
                if ( AppMain.amTpIsTouchOn( i ) && this.isHit( AppMain._am_tp_touch[i].on ) )
                {
                    result = i;
                    break;
                }
                i++;
            }
            return result;
        }

        // Token: 0x060020AC RID: 8364 RVA: 0x0013F848 File Offset: 0x0013DA48
        private int getPushTpIndex()
        {
            int result = -1;
            int i = 0;
            int num = AppMain._am_tp_touch.Length;
            while ( i < num )
            {
                if ( AppMain.amTpIsTouchPush( i ) && this.isHit( AppMain._am_tp_touch[i].push ) )
                {
                    result = i;
                    break;
                }
                i++;
            }
            return result;
        }

        // Token: 0x060020AD RID: 8365 RVA: 0x0013F88C File Offset: 0x0013DA8C
        private bool isHit( ushort[] point )
        {
            return this.isHit( CArray2<float>.initializer( ( float )point[0], ( float )point[1] ) );
        }

        // Token: 0x060020AE RID: 8366 RVA: 0x0013F8A4 File Offset: 0x0013DAA4
        private bool isHit( CArray2<float> pos )
        {
            bool result = false;
            if ( pos.x >= this.m_area.left && this.m_area.right >= pos.x && pos.y >= this.m_area.top && this.m_area.bottom >= pos.y )
            {
                result = true;
            }
            return result;
        }

        // Token: 0x04004D42 RID: 19778
        private bool[] m_flag = new bool[1];

        // Token: 0x04004D43 RID: 19779
        private CArray4<float> m_area;

        // Token: 0x04004D44 RID: 19780
        private CArray2<float> m_center;

        // Token: 0x04004D45 RID: 19781
        private int m_focus;

        // Token: 0x04004D46 RID: 19782
        private CArray2<float> m_prev;

        // Token: 0x04004D47 RID: 19783
        private int m_around;

        // Token: 0x04004D48 RID: 19784
        private float m_value;

        // Token: 0x04004D49 RID: 19785
        private float m_zero_point;

        // Token: 0x04004D4A RID: 19786
        public static AppMain.CPadPolarHandle p_instance = null;

        // Token: 0x04004D4B RID: 19787
        public static readonly float c_pi = (float)Math.Atan2(0.0, -1.0) * 2f;

        // Token: 0x02000146 RID: 326
        private class BFlag
        {
            // Token: 0x04004D4C RID: 19788
            public const int Setup = 0;

            // Token: 0x04004D4D RID: 19789
            public const int Max = 1;

            // Token: 0x04004D4E RID: 19790
            public const int None = 2;
        }
    }
}
