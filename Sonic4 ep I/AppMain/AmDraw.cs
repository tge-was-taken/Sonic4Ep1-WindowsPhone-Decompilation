using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public partial class AppMain
{
    // Token: 0x0200004B RID: 75
    public struct AMS_DRAW_VIDEO
    {
        // Token: 0x040048AF RID: 18607
        public float draw_width;

        // Token: 0x040048B0 RID: 18608
        public float draw_height;

        // Token: 0x040048B1 RID: 18609
        public float disp_width;

        // Token: 0x040048B2 RID: 18610
        public float disp_height;

        // Token: 0x040048B3 RID: 18611
        public bool wide_screen;

        // Token: 0x040048B4 RID: 18612
        public bool squeeze_screen;

        // Token: 0x040048B5 RID: 18613
        public float refresh_rate;

        // Token: 0x040048B6 RID: 18614
        public int video_standard;

        // Token: 0x040048B7 RID: 18615
        public float width_2d;

        // Token: 0x040048B8 RID: 18616
        public float height_2d;

        // Token: 0x040048B9 RID: 18617
        public float draw_aspect;

        // Token: 0x040048BA RID: 18618
        public float scale_x_2d;

        // Token: 0x040048BB RID: 18619
        public float scale_y_2d;

        // Token: 0x040048BC RID: 18620
        public float base_x_2d;

        // Token: 0x040048BD RID: 18621
        public float base_y_2d;
    }

    // Token: 0x0200004C RID: 76
    // (Invoke) Token: 0x06001DC1 RID: 7617
    public delegate void _am_draw_command_delegate( AppMain.AMS_COMMAND_HEADER ch, uint n );

    // Token: 0x0200004D RID: 77
    // (Invoke) Token: 0x06001DC5 RID: 7621
    public delegate void _am_draw_regist_delegate( AppMain.AMS_REGISTLIST l );

    // Token: 0x0200004E RID: 78
    public class AMS_COMMAND_HEADER
    {
        // Token: 0x06001DC8 RID: 7624 RVA: 0x00138995 File Offset: 0x00136B95
        public AMS_COMMAND_HEADER( AppMain.AMS_COMMAND_HEADER pHeader )
        {
            this.Assign( pHeader );
        }

        // Token: 0x06001DC9 RID: 7625 RVA: 0x001389A4 File Offset: 0x00136BA4
        public AMS_COMMAND_HEADER()
        {
        }

        // Token: 0x06001DCA RID: 7626 RVA: 0x001389AC File Offset: 0x00136BAC
        public void Assign( AppMain.AMS_COMMAND_HEADER pHeader )
        {
            this.state = pHeader.state;
            this.command_id = pHeader.command_id;
            this.param = pHeader.param;
        }

        // Token: 0x040048BE RID: 18622
        public uint state;

        // Token: 0x040048BF RID: 18623
        public int command_id;

        // Token: 0x040048C0 RID: 18624
        public object param;
    }

    // Token: 0x0200004F RID: 79
    public class AMS_DRAWSTATE_DIFFUSE
    {
        // Token: 0x06001DCB RID: 7627 RVA: 0x001389D2 File Offset: 0x00136BD2
        public AMS_DRAWSTATE_DIFFUSE()
        {
        }

        // Token: 0x06001DCC RID: 7628 RVA: 0x001389DA File Offset: 0x00136BDA
        public AMS_DRAWSTATE_DIFFUSE( AppMain.AMS_DRAWSTATE_DIFFUSE drawState )
        {
            this.mode = drawState.mode;
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
        }

        // Token: 0x06001DCD RID: 7629 RVA: 0x00138A12 File Offset: 0x00136C12
        public AppMain.AMS_DRAWSTATE_DIFFUSE Assign( AppMain.AMS_DRAWSTATE_DIFFUSE drawState )
        {
            this.mode = drawState.mode;
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
            return this;
        }

        // Token: 0x06001DCE RID: 7630 RVA: 0x00138A48 File Offset: 0x00136C48
        public void Clear()
        {
            this.mode = 0;
            this.r = ( this.g = ( this.b = 0f ) );
        }

        // Token: 0x040048C1 RID: 18625
        public int mode;

        // Token: 0x040048C2 RID: 18626
        public float r;

        // Token: 0x040048C3 RID: 18627
        public float g;

        // Token: 0x040048C4 RID: 18628
        public float b;
    }

    // Token: 0x02000050 RID: 80
    public class AMS_DRAWSTATE_AMBIENT
    {
        // Token: 0x06001DCF RID: 7631 RVA: 0x00138A79 File Offset: 0x00136C79
        public AMS_DRAWSTATE_AMBIENT()
        {
        }

        // Token: 0x06001DD0 RID: 7632 RVA: 0x00138A81 File Offset: 0x00136C81
        public AMS_DRAWSTATE_AMBIENT( AppMain.AMS_DRAWSTATE_AMBIENT drawState )
        {
            this.mode = drawState.mode;
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
        }

        // Token: 0x06001DD1 RID: 7633 RVA: 0x00138AB9 File Offset: 0x00136CB9
        public AppMain.AMS_DRAWSTATE_AMBIENT Assign( AppMain.AMS_DRAWSTATE_AMBIENT drawState )
        {
            this.mode = drawState.mode;
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
            return this;
        }

        // Token: 0x06001DD2 RID: 7634 RVA: 0x00138AEC File Offset: 0x00136CEC
        public void Clear()
        {
            this.mode = 0;
            this.r = ( this.g = ( this.b = 0f ) );
        }

        // Token: 0x040048C5 RID: 18629
        public int mode;

        // Token: 0x040048C6 RID: 18630
        public float r;

        // Token: 0x040048C7 RID: 18631
        public float g;

        // Token: 0x040048C8 RID: 18632
        public float b;
    }

    // Token: 0x02000051 RID: 81
    public class AMS_DRAWSTATE_ALPHA
    {
        // Token: 0x06001DD3 RID: 7635 RVA: 0x00138B1D File Offset: 0x00136D1D
        public AMS_DRAWSTATE_ALPHA()
        {
        }

        // Token: 0x06001DD4 RID: 7636 RVA: 0x00138B25 File Offset: 0x00136D25
        public AMS_DRAWSTATE_ALPHA( AppMain.AMS_DRAWSTATE_ALPHA drawState )
        {
            this.mode = drawState.mode;
            this.alpha = drawState.alpha;
        }

        // Token: 0x06001DD5 RID: 7637 RVA: 0x00138B45 File Offset: 0x00136D45
        public AppMain.AMS_DRAWSTATE_ALPHA Assign( AppMain.AMS_DRAWSTATE_ALPHA drawState )
        {
            this.mode = drawState.mode;
            this.alpha = drawState.alpha;
            return this;
        }

        // Token: 0x06001DD6 RID: 7638 RVA: 0x00138B60 File Offset: 0x00136D60
        public void Clear()
        {
            this.mode = 0;
            this.alpha = 0f;
        }

        // Token: 0x040048C9 RID: 18633
        public int mode;

        // Token: 0x040048CA RID: 18634
        public float alpha;
    }

    // Token: 0x02000052 RID: 82
    public class AMS_DRAWSTATE_SPECULAR
    {
        // Token: 0x06001DD7 RID: 7639 RVA: 0x00138B74 File Offset: 0x00136D74
        public AMS_DRAWSTATE_SPECULAR()
        {
        }

        // Token: 0x06001DD8 RID: 7640 RVA: 0x00138B7C File Offset: 0x00136D7C
        public AMS_DRAWSTATE_SPECULAR( AppMain.AMS_DRAWSTATE_SPECULAR drawState )
        {
            this.mode = drawState.mode;
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
        }

        // Token: 0x06001DD9 RID: 7641 RVA: 0x00138BB4 File Offset: 0x00136DB4
        public AppMain.AMS_DRAWSTATE_SPECULAR Assign( AppMain.AMS_DRAWSTATE_SPECULAR drawState )
        {
            this.mode = drawState.mode;
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
            return this;
        }

        // Token: 0x06001DDA RID: 7642 RVA: 0x00138BE8 File Offset: 0x00136DE8
        public void Clear()
        {
            this.mode = 0;
            this.r = ( this.g = ( this.b = 0f ) );
        }

        // Token: 0x040048CB RID: 18635
        public int mode;

        // Token: 0x040048CC RID: 18636
        public float r;

        // Token: 0x040048CD RID: 18637
        public float g;

        // Token: 0x040048CE RID: 18638
        public float b;
    }

    // Token: 0x02000053 RID: 83
    public class AMS_DRAWSTATE_ENVMAP
    {
        // Token: 0x06001DDB RID: 7643 RVA: 0x00138C19 File Offset: 0x00136E19
        public AMS_DRAWSTATE_ENVMAP()
        {
        }

        // Token: 0x06001DDC RID: 7644 RVA: 0x00138C2C File Offset: 0x00136E2C
        public AMS_DRAWSTATE_ENVMAP( AppMain.AMS_DRAWSTATE_ENVMAP drawState )
        {
            this.texsrc = drawState.texsrc;
            this.texmtx.Assign( drawState.texmtx );
        }

        // Token: 0x06001DDD RID: 7645 RVA: 0x00138C5D File Offset: 0x00136E5D
        public AppMain.AMS_DRAWSTATE_ENVMAP Assign( AppMain.AMS_DRAWSTATE_ENVMAP drawState )
        {
            if ( this != drawState )
            {
                this.texsrc = drawState.texsrc;
                this.texmtx.Assign( drawState.texmtx );
            }
            return this;
        }

        // Token: 0x06001DDE RID: 7646 RVA: 0x00138C82 File Offset: 0x00136E82
        public void Clear()
        {
            this.texsrc = 0;
            this.texmtx.Clear();
        }

        // Token: 0x040048CF RID: 18639
        public int texsrc;

        // Token: 0x040048D0 RID: 18640
        public readonly AppMain.NNS_MATRIX texmtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
    }

    // Token: 0x02000054 RID: 84
    public class AMS_DRAWSTATE_BLEND
    {
        // Token: 0x06001DDF RID: 7647 RVA: 0x00138C96 File Offset: 0x00136E96
        public AMS_DRAWSTATE_BLEND()
        {
        }

        // Token: 0x06001DE0 RID: 7648 RVA: 0x00138C9E File Offset: 0x00136E9E
        public AMS_DRAWSTATE_BLEND( AppMain.AMS_DRAWSTATE_BLEND drawState )
        {
            this.mode = drawState.mode;
        }

        // Token: 0x06001DE1 RID: 7649 RVA: 0x00138CB2 File Offset: 0x00136EB2
        public AppMain.AMS_DRAWSTATE_BLEND Assign( AppMain.AMS_DRAWSTATE_BLEND drawState )
        {
            this.mode = drawState.mode;
            return this;
        }

        // Token: 0x06001DE2 RID: 7650 RVA: 0x00138CC1 File Offset: 0x00136EC1
        public void Clear()
        {
            this.mode = 0;
        }

        // Token: 0x040048D1 RID: 18641
        public int mode;
    }

    // Token: 0x02000055 RID: 85
    public class AMS_DRAWSTATE_TEXOFFSET
    {
        // Token: 0x06001DE3 RID: 7651 RVA: 0x00138CCA File Offset: 0x00136ECA
        public AMS_DRAWSTATE_TEXOFFSET()
        {
        }

        // Token: 0x06001DE4 RID: 7652 RVA: 0x00138CD2 File Offset: 0x00136ED2
        public AMS_DRAWSTATE_TEXOFFSET( int mode, float u, float v )
        {
            this.mode = mode;
            this.u = u;
            this.v = v;
        }

        // Token: 0x06001DE5 RID: 7653 RVA: 0x00138CEF File Offset: 0x00136EEF
        public void Assign( AppMain.AMS_DRAWSTATE_TEXOFFSET p )
        {
            this.mode = p.mode;
            this.u = p.u;
            this.v = p.v;
        }

        // Token: 0x06001DE6 RID: 7654 RVA: 0x00138D15 File Offset: 0x00136F15
        internal void Clear()
        {
            this.mode = 0;
            this.u = 0f;
            this.v = 0f;
        }

        // Token: 0x040048D2 RID: 18642
        public int mode;

        // Token: 0x040048D3 RID: 18643
        public float u;

        // Token: 0x040048D4 RID: 18644
        public float v;
    }

    // Token: 0x02000056 RID: 86
    public class AMS_DRAWSTATE_FOG
    {
        // Token: 0x06001DE7 RID: 7655 RVA: 0x00138D34 File Offset: 0x00136F34
        public void Clear()
        {
            this.flag = 0;
        }

        // Token: 0x040048D5 RID: 18645
        public int flag;
    }

    // Token: 0x02000057 RID: 87
    public class AMS_DRAWSTATE_FOG_COLOR : AppMain.IClearable
    {
        // Token: 0x06001DE9 RID: 7657 RVA: 0x00138D45 File Offset: 0x00136F45
        public AMS_DRAWSTATE_FOG_COLOR()
        {
        }

        // Token: 0x06001DEA RID: 7658 RVA: 0x00138D4D File Offset: 0x00136F4D
        public AMS_DRAWSTATE_FOG_COLOR( AppMain.AMS_DRAWSTATE_FOG_COLOR drawState )
        {
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
        }

        // Token: 0x06001DEB RID: 7659 RVA: 0x00138D79 File Offset: 0x00136F79
        public AppMain.AMS_DRAWSTATE_FOG_COLOR Assign( AppMain.AMS_DRAWSTATE_FOG_COLOR drawState )
        {
            this.r = drawState.r;
            this.g = drawState.g;
            this.b = drawState.b;
            return this;
        }

        // Token: 0x06001DEC RID: 7660 RVA: 0x00138DA0 File Offset: 0x00136FA0
        public void Clear()
        {
            this.r = ( this.g = ( this.b = 0f ) );
        }

        // Token: 0x040048D6 RID: 18646
        public float r;

        // Token: 0x040048D7 RID: 18647
        public float g;

        // Token: 0x040048D8 RID: 18648
        public float b;
    }

    // Token: 0x02000058 RID: 88
    public class AMS_DRAWSTATE_FOG_RANGE
    {
        // Token: 0x06001DED RID: 7661 RVA: 0x00138DCA File Offset: 0x00136FCA
        public AMS_DRAWSTATE_FOG_RANGE()
        {
        }

        // Token: 0x06001DEE RID: 7662 RVA: 0x00138DD2 File Offset: 0x00136FD2
        public AMS_DRAWSTATE_FOG_RANGE( AppMain.AMS_DRAWSTATE_FOG_RANGE drawState )
        {
            this.fnear = drawState.fnear;
            this.ffar = drawState.ffar;
        }

        // Token: 0x06001DEF RID: 7663 RVA: 0x00138DF2 File Offset: 0x00136FF2
        public AppMain.AMS_DRAWSTATE_FOG_RANGE Assign( AppMain.AMS_DRAWSTATE_FOG_RANGE drawState )
        {
            this.fnear = drawState.fnear;
            this.ffar = drawState.ffar;
            return this;
        }

        // Token: 0x06001DF0 RID: 7664 RVA: 0x00138E10 File Offset: 0x00137010
        public void Clear()
        {
            this.fnear = ( this.ffar = 0f );
        }

        // Token: 0x040048D9 RID: 18649
        public float fnear;

        // Token: 0x040048DA RID: 18650
        public float ffar;
    }

    // Token: 0x02000059 RID: 89
    public class AMS_DRAWSTATE_Z_MODE
    {
        // Token: 0x06001DF1 RID: 7665 RVA: 0x00138E31 File Offset: 0x00137031
        public AMS_DRAWSTATE_Z_MODE()
        {
        }

        // Token: 0x06001DF2 RID: 7666 RVA: 0x00138E39 File Offset: 0x00137039
        public AMS_DRAWSTATE_Z_MODE( AppMain.AMS_DRAWSTATE_Z_MODE drawState )
        {
            this.compare = drawState.compare;
            this.update = drawState.update;
            this.func = drawState.func;
        }

        // Token: 0x06001DF3 RID: 7667 RVA: 0x00138E65 File Offset: 0x00137065
        public AppMain.AMS_DRAWSTATE_Z_MODE Assign( AppMain.AMS_DRAWSTATE_Z_MODE drawState )
        {
            this.compare = drawState.compare;
            this.update = drawState.update;
            this.func = drawState.func;
            return this;
        }

        // Token: 0x06001DF4 RID: 7668 RVA: 0x00138E8C File Offset: 0x0013708C
        public void Clear()
        {
            this.compare = 0U;
            this.update = 0U;
            this.func = 0;
        }

        // Token: 0x040048DB RID: 18651
        public uint compare;

        // Token: 0x040048DC RID: 18652
        public uint update;

        // Token: 0x040048DD RID: 18653
        public int func;
    }

    // Token: 0x0200005A RID: 90
    public class AMS_DRAWSTATE
    {
        // Token: 0x06001DF5 RID: 7669 RVA: 0x00138EA4 File Offset: 0x001370A4
        public AMS_DRAWSTATE()
        {
        }

        // Token: 0x06001DF6 RID: 7670 RVA: 0x00138F34 File Offset: 0x00137134
        public AMS_DRAWSTATE( AppMain.AMS_DRAWSTATE drawState )
        {
            this.drawflag = drawState.drawflag;
            this.diffuse.Assign( drawState.diffuse );
            this.ambient.Assign( drawState.ambient );
            this.specular.Assign( drawState.specular );
            this.envmap.Assign( drawState.envmap );
            this.alpha.Assign( drawState.alpha );
            this.blend.Assign( drawState.blend );
            for ( int i = 0; i < 4; i++ )
            {
                this.texoffset[i].Assign( drawState.texoffset[i] );
            }
            this.fog.flag = drawState.fog.flag;
            this.fog_color.Assign( drawState.fog_color );
            this.fog_range.Assign( drawState.fog_range );
            this.zmode.Assign( drawState.zmode );
        }

        // Token: 0x06001DF7 RID: 7671 RVA: 0x001390A8 File Offset: 0x001372A8
        public AppMain.AMS_DRAWSTATE Assign( AppMain.AMS_DRAWSTATE drawState )
        {
            if ( this != drawState )
            {
                this.drawflag = drawState.drawflag;
                this.diffuse.Assign( drawState.diffuse );
                this.ambient.Assign( drawState.ambient );
                this.specular.Assign( drawState.specular );
                this.envmap.Assign( drawState.envmap );
                this.alpha.Assign( drawState.alpha );
                this.blend.Assign( drawState.blend );
                for ( int i = 0; i < 4; i++ )
                {
                    this.texoffset[i].Assign( drawState.texoffset[i] );
                }
                this.fog.flag = drawState.fog.flag;
                this.fog_color.Assign( drawState.fog_color );
                this.fog_range.Assign( drawState.fog_range );
                this.zmode.Assign( drawState.zmode );
            }
            return this;
        }

        // Token: 0x06001DF8 RID: 7672 RVA: 0x001391A4 File Offset: 0x001373A4
        public void Clear()
        {
            this.drawflag = 0U;
            this.diffuse.Clear();
            this.ambient.Clear();
            this.specular.Clear();
            this.envmap.Clear();
            this.alpha.Clear();
            this.blend.Clear();
            for ( int i = 0; i < 4; i++ )
            {
                this.texoffset[i].Clear();
            }
            this.fog.Clear();
            this.fog_color.Clear();
            this.fog_range.Clear();
            this.zmode.Clear();
        }

        // Token: 0x040048DE RID: 18654
        public uint drawflag;

        // Token: 0x040048DF RID: 18655
        public readonly AppMain.AMS_DRAWSTATE_DIFFUSE diffuse = new AppMain.AMS_DRAWSTATE_DIFFUSE();

        // Token: 0x040048E0 RID: 18656
        public readonly AppMain.AMS_DRAWSTATE_AMBIENT ambient = new AppMain.AMS_DRAWSTATE_AMBIENT();

        // Token: 0x040048E1 RID: 18657
        public readonly AppMain.AMS_DRAWSTATE_SPECULAR specular = new AppMain.AMS_DRAWSTATE_SPECULAR();

        // Token: 0x040048E2 RID: 18658
        public readonly AppMain.AMS_DRAWSTATE_ENVMAP envmap = new AppMain.AMS_DRAWSTATE_ENVMAP();

        // Token: 0x040048E3 RID: 18659
        public readonly AppMain.AMS_DRAWSTATE_ALPHA alpha = new AppMain.AMS_DRAWSTATE_ALPHA();

        // Token: 0x040048E4 RID: 18660
        public readonly AppMain.AMS_DRAWSTATE_BLEND blend = new AppMain.AMS_DRAWSTATE_BLEND();

        // Token: 0x040048E5 RID: 18661
        public readonly AppMain.AMS_DRAWSTATE_TEXOFFSET[] texoffset = AppMain.New<AppMain.AMS_DRAWSTATE_TEXOFFSET>(4);

        // Token: 0x040048E6 RID: 18662
        public readonly AppMain.AMS_DRAWSTATE_FOG fog = new AppMain.AMS_DRAWSTATE_FOG();

        // Token: 0x040048E7 RID: 18663
        public readonly AppMain.AMS_DRAWSTATE_FOG_COLOR fog_color = new AppMain.AMS_DRAWSTATE_FOG_COLOR();

        // Token: 0x040048E8 RID: 18664
        public readonly AppMain.AMS_DRAWSTATE_FOG_RANGE fog_range = new AppMain.AMS_DRAWSTATE_FOG_RANGE();

        // Token: 0x040048E9 RID: 18665
        public readonly AppMain.AMS_DRAWSTATE_Z_MODE zmode = new AppMain.AMS_DRAWSTATE_Z_MODE();
    }

    // Token: 0x0200005B RID: 91
    public class AMS_COMMAND_BUFFER_HEADER
    {
        // Token: 0x040048EA RID: 18666
        public readonly uint[] system_flag = new uint[4];

        // Token: 0x040048EB RID: 18667
        public readonly uint[] debug_flag = new uint[4];

        // Token: 0x040048EC RID: 18668
        public ushort display_flag;

        // Token: 0x040048ED RID: 18669
        public ushort regist_flag;

        // Token: 0x040048EE RID: 18670
        public float icon_alpha;
    }

    // Token: 0x0200005C RID: 92
    public class AMS_DISPLAYLIST
    {
        // Token: 0x040048EF RID: 18671
        public int counter;

        // Token: 0x040048F0 RID: 18672
        public AppMain.ArrayPointer<object> command_buf;

        // Token: 0x040048F1 RID: 18673
        public AppMain.ArrayPointer<object> data_buf;

        // Token: 0x040048F2 RID: 18674
        public int command_buf_size;

        // Token: 0x040048F3 RID: 18675
        public int data_buf_size;
    }

    // Token: 0x0200005D RID: 93
    public class AMS_REGISTLIST
    {
        // Token: 0x040048F4 RID: 18676
        public int command_id;

        // Token: 0x040048F5 RID: 18677
        public object param;
    }

    // Token: 0x0200005E RID: 94
    public class AMS_DRAW_SORT
    {
        // Token: 0x06001DFC RID: 7676 RVA: 0x0013926F File Offset: 0x0013746F
        public AppMain.AMS_DRAW_SORT Assign( AppMain.AMS_DRAW_SORT sort )
        {
            this.key = sort.key;
            this.command = sort.command;
            return this;
        }

        // Token: 0x040048F6 RID: 18678
        public int key;

        // Token: 0x040048F7 RID: 18679
        public AppMain.AMS_COMMAND_HEADER command;
    }

    // Token: 0x0200005F RID: 95
    public class AMS_DISPLAYLIST_MANAGER
    {
        // Token: 0x040048F8 RID: 18680
        public int write_index;

        // Token: 0x040048F9 RID: 18681
        public int last_index;

        // Token: 0x040048FA RID: 18682
        public int read_index;

        // Token: 0x040048FB RID: 18683
        public AppMain.ArrayPointer<object> command_buf_ptr;

        // Token: 0x040048FC RID: 18684
        public AppMain.AMS_COMMAND_BUFFER_HEADER write_header;

        // Token: 0x040048FD RID: 18685
        public int reg_write_num;

        // Token: 0x040048FE RID: 18686
        public AppMain.AMS_COMMAND_BUFFER_HEADER read_header;

        // Token: 0x040048FF RID: 18687
        public int sort_num;

        // Token: 0x04004900 RID: 18688
        public readonly AppMain.AMS_DRAW_SORT[] sortlist = AppMain.New<AppMain.AMS_DRAW_SORT>(512);

        // Token: 0x04004901 RID: 18689
        public readonly AppMain.AMS_DISPLAYLIST[] displaylist = AppMain.New<AppMain.AMS_DISPLAYLIST>(4);

        // Token: 0x04004902 RID: 18690
        public int regist_num;

        // Token: 0x04004903 RID: 18691
        public int reg_write_index;

        // Token: 0x04004904 RID: 18692
        public int reg_read_index;

        // Token: 0x04004905 RID: 18693
        public int reg_end_index;

        // Token: 0x04004906 RID: 18694
        public readonly AppMain.AMS_REGISTLIST[] registlist = AppMain.New<AppMain.AMS_REGISTLIST>(256);
    }

    // Token: 0x02000060 RID: 96
    private class AMS_PARAM_MAKE_TASK
    {
        // Token: 0x04004907 RID: 18695
        public int prio;

        // Token: 0x04004908 RID: 18696
        public AppMain.TaskProc proc;

        // Token: 0x04004909 RID: 18697
        public object work_data;
    }

    // Token: 0x02000061 RID: 97
    private class AMS_PARAM_DRAW_OBJECT
    {
        // Token: 0x06001E00 RID: 7680 RVA: 0x001392CE File Offset: 0x001374CE
        public AMS_PARAM_DRAW_OBJECT()
        {
        }

        // Token: 0x06001E01 RID: 7681 RVA: 0x001392D6 File Offset: 0x001374D6
        public AMS_PARAM_DRAW_OBJECT( object _holder )
        {
            this.holder = _holder;
        }

        // Token: 0x06001E02 RID: 7682 RVA: 0x001392E5 File Offset: 0x001374E5
        public static explicit operator AppMain.OBS_DRAW_PARAM_3DNN_MODEL( AppMain.AMS_PARAM_DRAW_OBJECT ob )
        {
            return ( AppMain.OBS_DRAW_PARAM_3DNN_MODEL )ob.holder;
        }

        // Token: 0x0400490A RID: 18698
        public AppMain.NNS_OBJECT _object;

        // Token: 0x0400490B RID: 18699
        public AppMain.NNS_MATRIX mtx;

        // Token: 0x0400490C RID: 18700
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x0400490D RID: 18701
        public uint sub_obj_type;

        // Token: 0x0400490E RID: 18702
        public uint flag;

        // Token: 0x0400490F RID: 18703
        public AppMain.NNS_MATERIALCALLBACK_FUNC material_func;

        // Token: 0x04004910 RID: 18704
        public float scaleZ;

        // Token: 0x04004911 RID: 18705
        public readonly object holder;
    }

    // Token: 0x02000062 RID: 98
    private class AMS_PARAM_DRAW_OBJECT_MATERIAL : AppMain.AMS_PARAM_DRAW_OBJECT
    {
        // Token: 0x04004912 RID: 18706
        public AppMain.NNS_RGBA color;

        // Token: 0x04004913 RID: 18707
        public readonly AppMain.NNS_VECTOR scale = new AppMain.NNS_VECTOR();

        // Token: 0x04004914 RID: 18708
        public float scroll_u;

        // Token: 0x04004915 RID: 18709
        public float scroll_v;

        // Token: 0x04004916 RID: 18710
        public int blend;
    }

    // Token: 0x02000063 RID: 99
    private class AMS_PARAM_SORT_DRAW_OBJECT
    {
        // Token: 0x04004917 RID: 18711
        public uint drawflag;

        // Token: 0x04004918 RID: 18712
        public AppMain.AMS_PARAM_DRAW_OBJECT draw_object;

        // Token: 0x04004919 RID: 18713
        public AppMain.NNS_MATRIX[] mtx;

        // Token: 0x0400491A RID: 18714
        public uint[] nstat_list;

        // Token: 0x0400491B RID: 18715
        public AppMain.AMS_DRAWSTATE draw_state;
    }

    // Token: 0x02000064 RID: 100
    private class AMS_PARAM_DRAW_MOTION
    {
        // Token: 0x06001E05 RID: 7685 RVA: 0x0013930D File Offset: 0x0013750D
        public AMS_PARAM_DRAW_MOTION()
        {
        }

        // Token: 0x06001E06 RID: 7686 RVA: 0x00139315 File Offset: 0x00137515
        public AMS_PARAM_DRAW_MOTION( object _holder )
        {
            this.holder = _holder;
        }

        // Token: 0x06001E07 RID: 7687 RVA: 0x00139324 File Offset: 0x00137524
        public static explicit operator AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION( AppMain.AMS_PARAM_DRAW_MOTION mtn )
        {
            return ( AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION )mtn.holder;
        }

        // Token: 0x0400491C RID: 18716
        public AppMain.NNS_OBJECT _object;

        // Token: 0x0400491D RID: 18717
        public AppMain.NNS_MATRIX mtx;

        // Token: 0x0400491E RID: 18718
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x0400491F RID: 18719
        public uint sub_obj_type;

        // Token: 0x04004920 RID: 18720
        public uint flag;

        // Token: 0x04004921 RID: 18721
        public AppMain.NNS_MATERIALCALLBACK_FUNC material_func;

        // Token: 0x04004922 RID: 18722
        public AppMain.NNS_MOTION motion;

        // Token: 0x04004923 RID: 18723
        public float frame;

        // Token: 0x04004924 RID: 18724
        public readonly object holder;
    }

    // Token: 0x02000065 RID: 101
    private class AMS_PARAM_DRAW_MOTION_TRS : AppMain.IClearable
    {
        // Token: 0x06001E08 RID: 7688 RVA: 0x00139334 File Offset: 0x00137534
        public void Clear()
        {
            this._object = null;
            this.mtx = null;
            this.texlist = null;
            this.sub_obj_type = 0U;
            this.flag = 0U;
            this.material_func = null;
            this.motion = null;
            this.frame = 0f;
            this.trslist = null;
            this.mmotion = null;
            this.mframe = 0f;
        }

        // Token: 0x06001E09 RID: 7689 RVA: 0x00139396 File Offset: 0x00137596
        public AMS_PARAM_DRAW_MOTION_TRS()
        {
        }

        // Token: 0x06001E0A RID: 7690 RVA: 0x0013939E File Offset: 0x0013759E
        public AMS_PARAM_DRAW_MOTION_TRS( object _holder )
        {
            this.holder = _holder;
        }

        // Token: 0x06001E0B RID: 7691 RVA: 0x001393AD File Offset: 0x001375AD
        public static explicit operator AppMain.OBS_DRAW_PARAM_3DNN_MOTION( AppMain.AMS_PARAM_DRAW_MOTION_TRS param )
        {
            return ( AppMain.OBS_DRAW_PARAM_3DNN_MOTION )param.holder;
        }

        // Token: 0x04004925 RID: 18725
        public AppMain.NNS_OBJECT _object;

        // Token: 0x04004926 RID: 18726
        public AppMain.NNS_MATRIX mtx;

        // Token: 0x04004927 RID: 18727
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04004928 RID: 18728
        public uint sub_obj_type;

        // Token: 0x04004929 RID: 18729
        public uint flag;

        // Token: 0x0400492A RID: 18730
        public AppMain.NNS_MATERIALCALLBACK_FUNC material_func;

        // Token: 0x0400492B RID: 18731
        public AppMain.NNS_MOTION motion;

        // Token: 0x0400492C RID: 18732
        public float frame;

        // Token: 0x0400492D RID: 18733
        public AppMain.NNS_TRS[] trslist;

        // Token: 0x0400492E RID: 18734
        public AppMain.NNS_MOTION mmotion;

        // Token: 0x0400492F RID: 18735
        public float mframe;

        // Token: 0x04004930 RID: 18736
        public readonly object holder;
    }

    // Token: 0x02000066 RID: 102
    public class AMS_PARAM_DRAW_PRIMITIVE : AppMain.IClearable
    {
        // Token: 0x1700006D RID: 109
        // (get) Token: 0x06001E0C RID: 7692 RVA: 0x001393BA File Offset: 0x001375BA
        // (set) Token: 0x06001E0D RID: 7693 RVA: 0x001393C2 File Offset: 0x001375C2
        public int format3D
        {
            get
            {
                return this.formatXD;
            }
            set
            {
                this.formatXD = value;
            }
        }

        // Token: 0x1700006E RID: 110
        // (get) Token: 0x06001E0E RID: 7694 RVA: 0x001393CB File Offset: 0x001375CB
        // (set) Token: 0x06001E0F RID: 7695 RVA: 0x001393D3 File Offset: 0x001375D3
        public int format2D
        {
            get
            {
                return this.formatXD;
            }
            set
            {
                this.formatXD = value;
            }
        }

        // Token: 0x1700006F RID: 111
        // (get) Token: 0x06001E10 RID: 7696 RVA: 0x001393DC File Offset: 0x001375DC
        // (set) Token: 0x06001E11 RID: 7697 RVA: 0x001393E4 File Offset: 0x001375E4
        public float zOffset
        {
            get
            {
                return this.sortZ;
            }
            set
            {
                this.sortZ = value;
            }
        }

        // Token: 0x06001E12 RID: 7698 RVA: 0x001393F0 File Offset: 0x001375F0
        public void Assign( AppMain.AMS_PARAM_DRAW_PRIMITIVE other )
        {
            this.mtx = other.mtx;
            this.type = other.type;
            this.vtxPCT3D = other.vtxPCT3D;
            this.vtxPC3D = other.vtxPC3D;
            this.vtxPCT2D = other.vtxPCT2D;
            this.vtxPC2D = other.vtxPC2D;
            this.formatXD = other.formatXD;
            this.count = other.count;
            this.texlist = other.texlist;
            this.texId = other.texId;
            this.ablend = other.ablend;
            this.sortZ = other.sortZ;
            this.bldSrc = other.bldSrc;
            this.bldDst = other.bldDst;
            this.bldMode = other.bldMode;
            this.aTest = other.aTest;
            this.zMask = other.zMask;
            this.zTest = other.zTest;
            this.noSort = other.noSort;
            this.uwrap = other.vwrap;
            this.vwrap = other.vwrap;
        }

        // Token: 0x06001E13 RID: 7699 RVA: 0x001394FC File Offset: 0x001376FC
        public void Clear()
        {
            this.mtx = null;
            this.type = 0;
            this.vtxPCT3D = null;
            this.vtxPC3D = null;
            this.vtxPCT2D = null;
            this.vtxPC2D = null;
            this.formatXD = 0;
            this.count = 0;
            this.texlist = null;
            this.texId = 0;
            this.ablend = 0;
            this.sortZ = 0f;
            this.bldSrc = 0;
            this.bldDst = 0;
            this.bldMode = 0;
            this.aTest = 0;
            this.zMask = 0;
            this.zTest = 0;
            this.noSort = 0;
            this.uwrap = 0;
            this.vwrap = 0;
        }

        // Token: 0x04004931 RID: 18737
        public AppMain.NNS_MATRIX mtx;

        // Token: 0x04004932 RID: 18738
        public int type;

        // Token: 0x04004933 RID: 18739
        public AppMain.NNS_PRIM3D_PCT_ARRAY vtxPCT3D;

        // Token: 0x04004934 RID: 18740
        public AppMain.NNS_PRIM3D_PC[] vtxPC3D;

        // Token: 0x04004935 RID: 18741
        public AppMain.NNS_PRIM2D_PCT[] vtxPCT2D;

        // Token: 0x04004936 RID: 18742
        public AppMain.NNS_PRIM2D_PC[] vtxPC2D;

        // Token: 0x04004937 RID: 18743
        private int formatXD;

        // Token: 0x04004938 RID: 18744
        public int count;

        // Token: 0x04004939 RID: 18745
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x0400493A RID: 18746
        public int texId;

        // Token: 0x0400493B RID: 18747
        public int ablend;

        // Token: 0x0400493C RID: 18748
        public float sortZ;

        // Token: 0x0400493D RID: 18749
        public int bldSrc;

        // Token: 0x0400493E RID: 18750
        public int bldDst;

        // Token: 0x0400493F RID: 18751
        public int bldMode;

        // Token: 0x04004940 RID: 18752
        public short aTest;

        // Token: 0x04004941 RID: 18753
        public short zMask;

        // Token: 0x04004942 RID: 18754
        public short zTest;

        // Token: 0x04004943 RID: 18755
        public short noSort;

        // Token: 0x04004944 RID: 18756
        public int uwrap;

        // Token: 0x04004945 RID: 18757
        public int vwrap;
    }

    // Token: 0x02000067 RID: 103
    public class AMS_PARAM_SET_TEXOFFSET
    {
        // Token: 0x04004946 RID: 18758
        public int slot;

        // Token: 0x04004947 RID: 18759
        public AppMain.AMS_DRAWSTATE_TEXOFFSET texoffset;
    }

    // Token: 0x02000068 RID: 104
    public class AMS_PARAM_LOAD_TEXTURE
    {
        // Token: 0x04004948 RID: 18760
        public AppMain.NNS_TEXINFO pTexInfo;

        // Token: 0x04004949 RID: 18761
        public Texture2D tex;

        // Token: 0x0400494A RID: 18762
        public ushort minfilter;

        // Token: 0x0400494B RID: 18763
        public ushort magfilter;

        // Token: 0x0400494C RID: 18764
        public uint globalIndex;

        // Token: 0x0400494D RID: 18765
        public uint bank;

        // Token: 0x0400494E RID: 18766
        public uint flag;

        // Token: 0x0400494F RID: 18767
        public uint size;

        // Token: 0x04004950 RID: 18768
        public byte[] buf_delete;
    }

    // Token: 0x02000069 RID: 105
    public class AMS_PARAM_RELEASE_TEXTURE
    {
        // Token: 0x04004951 RID: 18769
        public AppMain.NNS_TEXLIST texlist;
    }

    // Token: 0x0200006A RID: 106
    public class AMS_PARAM_VERTEX_BUFFER_OBJECT
    {
        // Token: 0x04004952 RID: 18770
        public AppMain.NNS_OBJECT obj;

        // Token: 0x04004953 RID: 18771
        public AppMain.NNS_OBJECT srcobj;

        // Token: 0x04004954 RID: 18772
        public uint bindflag;

        // Token: 0x04004955 RID: 18773
        public uint drawflag;
    }

    // Token: 0x0200006B RID: 107
    public class AMS_PARAM_DELETE_VERTEX_OBJECT
    {
        // Token: 0x04004956 RID: 18774
        public AppMain.NNS_OBJECT obj;
    }

    // Token: 0x0200006C RID: 108
    public struct AMS_PARAM_LOAD_TEXTURE_IMAGE
    {
        // Token: 0x04004957 RID: 18775
        public Texture2D texture;

        // Token: 0x04004958 RID: 18776
        public int size;

        // Token: 0x04004959 RID: 18777
        public short minfilter;

        // Token: 0x0400495A RID: 18778
        public short magfilter;

        // Token: 0x0400495B RID: 18779
        public short u_wrap;

        // Token: 0x0400495C RID: 18780
        public short v_wrap;
    }

    // Token: 0x0200006D RID: 109
    public class AMS_PARAM_RELEASE_TEXTURE_IMAGE
    {
        // Token: 0x0400495D RID: 18781
        public Texture2D texture;
    }

    // Token: 0x0200006E RID: 110
    private class __amDrawObject
    {
        // Token: 0x0400495E RID: 18782
        public static AppMain.NNS_MATRIX[] plt_mtx;

        // Token: 0x0400495F RID: 18783
        public static uint[] nstat;
    }

    // Token: 0x06000195 RID: 405 RVA: 0x00010D87 File Offset: 0x0000EF87
    public static uint AMD_RGBA8888( uint r, uint g, uint b, uint a )
    {
        return ( r & 255U ) << 24 | ( g & 255U ) << 16 | ( b & 255U ) << 8 | ( a & 255U );
    }

    // Token: 0x06000196 RID: 406 RVA: 0x00010DB0 File Offset: 0x0000EFB0
    public static uint AMD_RGBA8888( byte r, byte g, byte b, byte a )
    {
        return ( uint )( ( int )( r & byte.MaxValue ) << 24 | ( int )( g & byte.MaxValue ) << 16 | ( int )( b & byte.MaxValue ) << 8 | ( int )( a & byte.MaxValue ) );
    }

    // Token: 0x06000197 RID: 407 RVA: 0x00010DD9 File Offset: 0x0000EFD9
    public static void amFlagOn( ref uint dst_, uint on_ )
    {
        dst_ |= on_;
    }

    // Token: 0x06000198 RID: 408 RVA: 0x00010DE1 File Offset: 0x0000EFE1
    public static void amFlagOff( ref uint dst_, uint off_ )
    {
        dst_ &= ~off_;
    }

    // Token: 0x06000199 RID: 409 RVA: 0x00010DEA File Offset: 0x0000EFEA
    public static void amFlagFlip( ref uint dst_, uint flip_ )
    {
        dst_ ^= flip_;
    }

    // Token: 0x0600019A RID: 410 RVA: 0x00010DF2 File Offset: 0x0000EFF2
    public static void amFlagOnOff( ref uint dst_, uint on_, uint off_ )
    {
        dst_ = ( ( dst_ & ~off_ ) | on_ );
    }

    // Token: 0x0600019B RID: 411 RVA: 0x00010DFD File Offset: 0x0000EFFD
    public static float amSqrt( float fs_ )
    {
        return AppMain.nnSqrt( fs_ );
    }

    // Token: 0x0600019C RID: 412 RVA: 0x00010E05 File Offset: 0x0000F005
    public static float amPow2( float n_ )
    {
        return n_ * n_;
    }

    // Token: 0x0600019D RID: 413 RVA: 0x00010E0A File Offset: 0x0000F00A
    public static float amPow3( float n_ )
    {
        return n_ * n_ * n_;
    }

    // Token: 0x0600019E RID: 414 RVA: 0x00010E11 File Offset: 0x0000F011
    public static bool amIsZerof( float fs )
    {
        return 0f >= fs && fs >= 0f;
    }

    // Token: 0x0600019F RID: 415 RVA: 0x00010E26 File Offset: 0x0000F026
    public static float amClamp( float n_, float min_, float max_ )
    {
        if ( n_ < min_ )
        {
            return min_;
        }
        if ( n_ <= max_ )
        {
            return n_;
        }
        return max_;
    }

    // Token: 0x060001A0 RID: 416 RVA: 0x00010E35 File Offset: 0x0000F035
    public static void amSinCos( float radian, out float pSn, out float pCs )
    {
        AppMain.nnSinCos( AppMain.NNM_RADtoA32( radian ), out pSn, out pCs );
    }

    // Token: 0x060001A1 RID: 417 RVA: 0x00010E44 File Offset: 0x0000F044
    public static void amSinCos( int angle, out float pSn, out float pCs )
    {
        AppMain.nnSinCos( angle, out pSn, out pCs );
    }

    // Token: 0x060001A2 RID: 418 RVA: 0x00010E4E File Offset: 0x0000F04E
    public static T amMax<T>( T a, T b ) where T : IComparable<T>
    {
        if ( a.CompareTo( b ) <= 0 )
        {
            return b;
        }
        return a;
    }

    // Token: 0x060001A3 RID: 419 RVA: 0x00010E64 File Offset: 0x0000F064
    public static T amMin<T>( T a, T b ) where T : IComparable<T>
    {
        if ( a.CompareTo( b ) >= 0 )
        {
            return b;
        }
        return a;
    }

    // Token: 0x060001A4 RID: 420 RVA: 0x00010E7C File Offset: 0x0000F07C
    public static uint AMD_FCOLTORGBA8888( float r, float g, float b, float a )
    {
        return ( ( uint )( r * 255f ) & 255U ) << 24 | ( ( uint )( g * 255f ) & 255U ) << 16 | ( ( uint )( b * 255f ) & 255U ) << 8 | ( ( uint )( a * 255f ) & 255U );
    }

    // Token: 0x17000001 RID: 1
    // (get) Token: 0x060001A5 RID: 421 RVA: 0x00010ECC File Offset: 0x0000F0CC
    // (set) Token: 0x060001A6 RID: 422 RVA: 0x00010ED8 File Offset: 0x0000F0D8
    public static float AMD_DISPLAY_WIDTH
    {
        get
        {
            return AppMain._am_draw_video.disp_width;
        }
        set
        {
            AppMain._am_draw_video.disp_width = value;
        }
    }

    // Token: 0x17000002 RID: 2
    // (get) Token: 0x060001A7 RID: 423 RVA: 0x00010EE5 File Offset: 0x0000F0E5
    // (set) Token: 0x060001A8 RID: 424 RVA: 0x00010EF1 File Offset: 0x0000F0F1
    public static float AMD_DISPLAY_HEIGHT
    {
        get
        {
            return AppMain._am_draw_video.disp_height;
        }
        set
        {
            AppMain._am_draw_video.disp_height = value;
        }
    }

    // Token: 0x17000003 RID: 3
    // (get) Token: 0x060001A9 RID: 425 RVA: 0x00010EFE File Offset: 0x0000F0FE
    // (set) Token: 0x060001AA RID: 426 RVA: 0x00010F0A File Offset: 0x0000F10A
    public static float AMD_SCREEN_WIDTH
    {
        get
        {
            return AppMain._am_draw_video.draw_width;
        }
        set
        {
            AppMain._am_draw_video.draw_width = value;
        }
    }

    // Token: 0x17000004 RID: 4
    // (get) Token: 0x060001AB RID: 427 RVA: 0x00010F17 File Offset: 0x0000F117
    // (set) Token: 0x060001AC RID: 428 RVA: 0x00010F23 File Offset: 0x0000F123
    public static float AMD_SCREEN_HEIGHT
    {
        get
        {
            return AppMain._am_draw_video.draw_height;
        }
        set
        {
            AppMain._am_draw_video.draw_height = value;
        }
    }

    // Token: 0x17000005 RID: 5
    // (get) Token: 0x060001AD RID: 429 RVA: 0x00010F30 File Offset: 0x0000F130
    // (set) Token: 0x060001AE RID: 430 RVA: 0x00010F3C File Offset: 0x0000F13C
    public static float AMD_SCREEN_2D_WIDTH
    {
        get
        {
            return AppMain._am_draw_video.width_2d;
        }
        set
        {
            AppMain._am_draw_video.width_2d = value;
        }
    }

    // Token: 0x17000006 RID: 6
    // (get) Token: 0x060001AF RID: 431 RVA: 0x00010F49 File Offset: 0x0000F149
    // (set) Token: 0x060001B0 RID: 432 RVA: 0x00010F55 File Offset: 0x0000F155
    public static float AMD_SCREEN_2D_HEIGHT
    {
        get
        {
            return AppMain._am_draw_video.height_2d;
        }
        set
        {
            AppMain._am_draw_video.height_2d = value;
        }
    }

    // Token: 0x17000007 RID: 7
    // (get) Token: 0x060001B1 RID: 433 RVA: 0x00010F62 File Offset: 0x0000F162
    // (set) Token: 0x060001B2 RID: 434 RVA: 0x00010F6E File Offset: 0x0000F16E
    public static float AMD_2D_SCALE_X
    {
        get
        {
            return AppMain._am_draw_video.scale_x_2d;
        }
        set
        {
            AppMain._am_draw_video.scale_x_2d = value;
        }
    }

    // Token: 0x17000008 RID: 8
    // (get) Token: 0x060001B3 RID: 435 RVA: 0x00010F7B File Offset: 0x0000F17B
    // (set) Token: 0x060001B4 RID: 436 RVA: 0x00010F87 File Offset: 0x0000F187
    public static float AMD_2D_SCALE_Y
    {
        get
        {
            return AppMain._am_draw_video.scale_y_2d;
        }
        set
        {
            AppMain._am_draw_video.scale_y_2d = value;
        }
    }

    // Token: 0x17000009 RID: 9
    // (get) Token: 0x060001B5 RID: 437 RVA: 0x00010F94 File Offset: 0x0000F194
    // (set) Token: 0x060001B6 RID: 438 RVA: 0x00010FA0 File Offset: 0x0000F1A0
    public static float AMD_2D_BASE_X
    {
        get
        {
            return AppMain._am_draw_video.base_x_2d;
        }
        set
        {
            AppMain._am_draw_video.base_x_2d = value;
        }
    }

    // Token: 0x1700000A RID: 10
    // (get) Token: 0x060001B7 RID: 439 RVA: 0x00010FAD File Offset: 0x0000F1AD
    // (set) Token: 0x060001B8 RID: 440 RVA: 0x00010FB9 File Offset: 0x0000F1B9
    public static float AMD_2D_BASE_Y
    {
        get
        {
            return AppMain._am_draw_video.base_y_2d;
        }
        set
        {
            AppMain._am_draw_video.base_y_2d = value;
        }
    }

    // Token: 0x1700000B RID: 11
    // (get) Token: 0x060001B9 RID: 441 RVA: 0x00010FC6 File Offset: 0x0000F1C6
    // (set) Token: 0x060001BA RID: 442 RVA: 0x00010FD2 File Offset: 0x0000F1D2
    public static float AMD_SCREEN_ASPECT
    {
        get
        {
            return AppMain._am_draw_video.draw_aspect;
        }
        set
        {
            AppMain._am_draw_video.draw_aspect = value;
        }
    }

    // Token: 0x1700000C RID: 12
    // (get) Token: 0x060001BB RID: 443 RVA: 0x00010FDF File Offset: 0x0000F1DF
    // (set) Token: 0x060001BC RID: 444 RVA: 0x00010FF0 File Offset: 0x0000F1F0
    public static int AMD_RENDER_WIDTH
    {
        get
        {
            return AppMain._am_render_manager.target_now.width;
        }
        set
        {
            AppMain._am_render_manager.target_now.width = value;
        }
    }

    // Token: 0x1700000D RID: 13
    // (get) Token: 0x060001BD RID: 445 RVA: 0x00011002 File Offset: 0x0000F202
    // (set) Token: 0x060001BE RID: 446 RVA: 0x00011013 File Offset: 0x0000F213
    public static int AMD_RENDER_HEIGHT
    {
        get
        {
            return AppMain._am_render_manager.target_now.height;
        }
        set
        {
            AppMain._am_render_manager.target_now.height = value;
        }
    }

    // Token: 0x1700000E RID: 14
    // (get) Token: 0x060001BF RID: 447 RVA: 0x00011025 File Offset: 0x0000F225
    // (set) Token: 0x060001C0 RID: 448 RVA: 0x00011036 File Offset: 0x0000F236
    public static float AMD_RENDER_ASPECT
    {
        get
        {
            return AppMain._am_render_manager.target_now.aspect;
        }
        set
        {
            AppMain._am_render_manager.target_now.aspect = value;
        }
    }

    // Token: 0x060001C1 RID: 449 RVA: 0x00011048 File Offset: 0x0000F248
    private static AppMain.AMS_PARAM_DRAW_PRIMITIVE amDrawAlloc_AMS_PARAM_DRAW_PRIMITIVE()
    {
        return AppMain.amDraw_AMS_PARAM_DRAW_PRIMITIVE_Pool.Alloc();
    }

    // Token: 0x060001C2 RID: 450 RVA: 0x00011054 File Offset: 0x0000F254
    private static AppMain.NNS_MATRIX amDrawAlloc_NNS_MATRIX()
    {
        return AppMain.amDraw_NNS_MATRIX_Pool.Alloc();
    }

    // Token: 0x060001C3 RID: 451 RVA: 0x00011060 File Offset: 0x0000F260
    private static AppMain.AMS_DRAWSTATE_FOG amDrawAlloc_AMS_DRAWSTATE_FOG()
    {
        return AppMain.amDraw_AMS_DRAWSTATE_FOG_Pool.Alloc();
    }

    // Token: 0x060001C4 RID: 452 RVA: 0x0001106C File Offset: 0x0000F26C
    private static AppMain.AMS_DRAWSTATE_FOG_COLOR amDrawAlloc_AMS_DRAWSTATE_FOG_COLOR()
    {
        return AppMain.amDraw_AMS_DRAWSTATE_FOG_COLOR_Pool.Alloc();
    }

    // Token: 0x060001C5 RID: 453 RVA: 0x00011078 File Offset: 0x0000F278
    private static AppMain.AMS_DRAWSTATE_FOG_RANGE amDrawAlloc_AMS_DRAWSTATE_FOG_RANGE()
    {
        return AppMain.amDraw_AMS_DRAWSTATE_FOG_RANGE_Pool.Alloc();
    }

    // Token: 0x060001C6 RID: 454 RVA: 0x00011084 File Offset: 0x0000F284
    private static AppMain.AMS_PARAM_MAKE_TASK amDrawAlloc_AMS_PARAM_MAKE_TASK()
    {
        return AppMain.amDraw_AMS_PARAM_MAKE_TASK_Pool.Alloc();
    }

    // Token: 0x060001C7 RID: 455 RVA: 0x00011090 File Offset: 0x0000F290
    private static AppMain.AMS_PARAM_DRAW_OBJECT_MATERIAL amDrawAlloc_AMS_PARAM_DRAW_OBJECT_MATERIAL()
    {
        return AppMain.amDraw_AMS_PARAM_DRAW_OBJECT_MATERIAL_Pool.Alloc();
    }

    // Token: 0x060001C8 RID: 456 RVA: 0x0001109C File Offset: 0x0000F29C
    private static AppMain.GMS_GMK_ITEM_MAT_CB_PARAM amDrawAlloc_GMS_GMK_ITEM_MAT_CB_PARAM()
    {
        return AppMain.amDraw_GMS_GMK_ITEM_MAT_CB_PARAM_Pool.Alloc();
    }

    // Token: 0x060001C9 RID: 457 RVA: 0x000110A8 File Offset: 0x0000F2A8
    private static AppMain.DMAP_PARAM_WATER amDrawAlloc_DMAP_PARAM_WATER()
    {
        return AppMain.amDraw_DMAP_PARAM_WATER_Pool.Alloc();
    }

    // Token: 0x060001CA RID: 458 RVA: 0x000110B4 File Offset: 0x0000F2B4
    private static AppMain.NNS_PRIM3D_PCT_ARRAY amDrawAlloc_NNS_PRIM3D_PCT( int count )
    {
        AppMain.NNS_PRIM3D_PCT_ALLOC_CNT++;
        if ( AppMain.NNS_PRIM3D_PCT_buf_size + count >= 16384 )
        {
            AppMain.NNS_PRIM3D_PCT_buf_size = 0;
        }
        if ( AppMain.NNS_PRIM3D_PCT_arrays_count >= 1024 )
        {
            AppMain.NNS_PRIM3D_PCT_arrays_count = 0;
        }
        AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.NNS_PRIM3D_PCT_arrays[AppMain.NNS_PRIM3D_PCT_arrays_count];
        nns_PRIM3D_PCT_ARRAY.buffer = AppMain.NNS_PRIM3D_PCT_buf;
        nns_PRIM3D_PCT_ARRAY.offset = AppMain.NNS_PRIM3D_PCT_buf_size;
        AppMain.NNS_PRIM3D_PCT_arrays_count++;
        AppMain.NNS_PRIM3D_PCT_buf_size += count;
        return nns_PRIM3D_PCT_ARRAY;
    }

    // Token: 0x060001CB RID: 459 RVA: 0x0001112E File Offset: 0x0000F32E
    private static AppMain.NNS_PRIM3D_PC[] amDrawAlloc_NNS_PRIM3D_PC( int count )
    {
        return AppMain.amDraw_NNS_PRIM3D_PC_Array_Pool.AllocArray( count );
    }

    // Token: 0x060001CC RID: 460 RVA: 0x0001113B File Offset: 0x0000F33B
    private static AppMain.NNS_TRS[] amDrawAlloc_NNS_TRS( int count )
    {
        return AppMain.amDraw_NNS_TRS_Array_Pool.AllocArray( count );
    }

    // Token: 0x060001CD RID: 461 RVA: 0x00011148 File Offset: 0x0000F348
    private static AppMain.NNS_MATERIALPTR[] amDrawAlloc_NNS_MATERIALPTR( int count )
    {
        return AppMain.amDraw_NNS_MATERIALPTR_Array_Pool.AllocArray( count );
    }

    // Token: 0x060001CE RID: 462 RVA: 0x00011155 File Offset: 0x0000F355
    private static AppMain.GMS_BS_CMN_CNM_NODE_INFO[] amDrawAlloc_GMS_BS_CMN_CNM_NODE_INFO( int count )
    {
        return AppMain.amDraw_GMS_BS_CMN_CNM_NODE_INFO_Array_Pool.AllocArray( count );
    }

    // Token: 0x060001CF RID: 463 RVA: 0x00011162 File Offset: 0x0000F362
    private static AppMain.GMS_BS_CMN_CNM_NODE_INFO amDrawAlloc_GMS_BS_CMN_CNM_NODE_INFO()
    {
        return AppMain.amDraw_GMS_BS_CMN_CNM_NODE_INFO_Pool.Alloc();
    }

    // Token: 0x060001D0 RID: 464 RVA: 0x0001116E File Offset: 0x0000F36E
    private static AppMain.GMS_BS_CMN_CNM_PARAM amDrawAlloc_GMS_BS_CMN_CNM_PARAM()
    {
        return AppMain.amDraw_GMS_BS_CMN_CNM_PARAM_Pool.Alloc();
    }

    // Token: 0x060001D1 RID: 465 RVA: 0x0001117A File Offset: 0x0000F37A
    private static AppMain.NNS_MATERIAL_STDSHADER_COLOR amDrawAlloc_NNS_MATERIAL_STDSHADER_COLOR()
    {
        return AppMain.amDraw_NNS_MATERIAL_STDSHADER_COLOR_Pool.Alloc();
    }

    // Token: 0x060001D2 RID: 466 RVA: 0x00011186 File Offset: 0x0000F386
    private static AppMain.NNS_MATERIAL_GLES11_DESC amDrawAlloc_NNS_MATERIAL_GLES11_DESC()
    {
        return AppMain.amDraw_NNS_MATERIAL_GLES11_DESC_Pool.Alloc();
    }

    // Token: 0x060001D3 RID: 467 RVA: 0x00011192 File Offset: 0x0000F392
    private static AppMain.NNS_MATERIALPTR amDrawAlloc_NNS_MATERIALPTR()
    {
        return AppMain.amDraw_NNS_MATERIALPTR_Pool.Alloc();
    }

    // Token: 0x060001D4 RID: 468 RVA: 0x0001119E File Offset: 0x0000F39E
    private static AppMain.OBS_DRAW_PARAM_3DNN_USER_FUNC amDrawAlloc_OBS_DRAW_PARAM_3DNN_USER_FUNC()
    {
        return AppMain.amDraw_OBS_DRAW_PARAM_3DNN_USER_FUNC_Pool.Alloc();
    }

    // Token: 0x060001D5 RID: 469 RVA: 0x000111AA File Offset: 0x0000F3AA
    private static AppMain.OBS_DRAW_PARAM_3DNN_MOTION amDrawAlloc_OBS_DRAW_PARAM_3DNN_MOTION()
    {
        return AppMain.amDraw_OBS_DRAW_PARAM_3DNN_MOTION_Pool.Alloc();
    }

    // Token: 0x060001D6 RID: 470 RVA: 0x000111B6 File Offset: 0x0000F3B6
    private static AppMain.OBS_DRAW_PARAM_3DNN_DRAW_MOTION amDrawAlloc_OBS_DRAW_PARAM_3DNN_DRAW_MOTION()
    {
        return AppMain.amDraw_OBS_DRAW_PARAM_3DNN_DRAW_MOTION_Pool.Alloc();
    }

    // Token: 0x060001D7 RID: 471 RVA: 0x000111C2 File Offset: 0x0000F3C2
    private static AppMain.AMS_PARAM_DRAW_MOTION_TRS amDrawAlloc_AMS_PARAM_DRAW_MOTION_TRS()
    {
        return AppMain.amDraw_AMS_PARAM_DRAW_MOTION_TRS_Pool.Alloc();
    }

    // Token: 0x060001D8 RID: 472 RVA: 0x000111CE File Offset: 0x0000F3CE
    private static AppMain.NNS_TRS amDrawAlloc_NNS_TRS()
    {
        return AppMain.amDraw_NNS_TRS_Pool.Alloc();
    }

    // Token: 0x060001D9 RID: 473 RVA: 0x000111DA File Offset: 0x0000F3DA
    private static AppMain.AOS_ACT_DRAW amDrawAlloc_AOS_ACT_DRAW()
    {
        return AppMain.amDraw_AOS_ACT_DRAW_Pool.Alloc();
    }

    // Token: 0x060001DA RID: 474 RVA: 0x000111E6 File Offset: 0x0000F3E6
    private static AppMain.NNS_OBJECT amDrawAlloc_NNS_OBJECT()
    {
        return AppMain.amDraw_NNS_OBJECT_Pool.Alloc();
    }

    // Token: 0x060001DB RID: 475 RVA: 0x000111F4 File Offset: 0x0000F3F4
    private static void amDrawResetCache()
    {
        AppMain.amDraw_AMS_PARAM_DRAW_PRIMITIVE_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_MATRIX_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AMS_PARAM_MAKE_TASK_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AMS_DRAWSTATE_FOG_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AMS_PARAM_DRAW_OBJECT_MATERIAL_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AMS_DRAWSTATE_FOG_COLOR_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AMS_DRAWSTATE_FOG_RANGE_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_PRIM3D_PC_Array_Pool.ReleaseUsedArrays();
        AppMain.amDraw_GMS_MAP_PRIM_DRAW_WORK_Array_Pool.ReleaseUsedArrays();
        AppMain.amDraw_OBS_DRAW_PARAM_3DNN_USER_FUNC_Pool.ReleaseUsedObjects();
        AppMain.amDraw_OBS_DRAW_PARAM_3DNN_MOTION_Pool.ReleaseUsedObjects();
        AppMain.amDraw_OBS_DRAW_PARAM_3DNN_DRAW_MOTION_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AMS_PARAM_DRAW_MOTION_TRS_Pool.ReleaseUsedObjects();
        AppMain.amDraw_GMS_GMK_ITEM_MAT_CB_PARAM_Pool.ReleaseUsedObjects();
        AppMain.amDraw_DMAP_PARAM_WATER_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_TRS_Pool.ReleaseUsedObjects();
        AppMain.amDraw_AOS_ACT_DRAW_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_OBJECT_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_TRS_Array_Pool.ReleaseUsedArrays();
        AppMain.amDraw_GMS_BS_CMN_CNM_NODE_INFO_Array_Pool.ReleaseUsedArrays();
        AppMain.amDraw_GMS_BS_CMN_CNM_NODE_INFO_Pool.ReleaseUsedObjects();
        AppMain.amDraw_GMS_BS_CMN_CNM_PARAM_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_MATERIAL_STDSHADER_COLOR_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_MATERIAL_GLES11_DESC_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_MATERIALPTR_Pool.ReleaseUsedObjects();
        AppMain.amDraw_NNS_MATERIALPTR_Array_Pool.ReleaseUsedArrays();
        AppMain.NNS_PRIM3D_PCT_buf_size = 0;
        AppMain.NNS_PRIM3D_PCT_arrays_count = 0;
    }

    // Token: 0x060001DC RID: 476 RVA: 0x00011314 File Offset: 0x0000F514
    private static void amDrawCreateBuffer( int command_size, int data_size, int work_size )
    {
        AppMain._am_draw_command_buf_max = command_size;
        AppMain._am_draw_data_buf_max = data_size;
        for ( int i = 0; i < 4; i++ )
        {
            AppMain._am_draw_command_buf[i] = new object[command_size];
            AppMain._am_draw_data_buf[i] = new object[data_size];
        }
    }

    // Token: 0x060001DD RID: 477 RVA: 0x00011353 File Offset: 0x0000F553
    private static void amDrawDeleteBuffer()
    {
    }

    // Token: 0x060001DE RID: 478 RVA: 0x00011355 File Offset: 0x0000F555
    public static void amDrawSetDrawCommandFunc( AppMain._am_draw_command_delegate func, AppMain._am_draw_command_delegate sort )
    {
        AppMain._am_draw_command_func = func;
        AppMain._am_draw_command_sort = sort;
    }

    // Token: 0x060001DF RID: 479 RVA: 0x00011363 File Offset: 0x0000F563
    private static void amDrawSetShaderCompile( int flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060001E0 RID: 480 RVA: 0x0001136A File Offset: 0x0000F56A
    private static void amDrawSetVSyncAlarm( AppMain.AMS_ALARM alarm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060001E1 RID: 481 RVA: 0x00011371 File Offset: 0x0000F571
    private static void amDrawWaitVSync()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060001E2 RID: 482 RVA: 0x00011378 File Offset: 0x0000F578
    public bool amDrawBegin()
    {
        return this.amDrawBegin( null, AppMain.AMD_RENDER_CLEAR_COLOR | AppMain.AMD_RENDER_CLEAR_DEPTH, null, 1f, 0 );
    }

    // Token: 0x060001E3 RID: 483 RVA: 0x00011394 File Offset: 0x0000F594
    public bool amDrawBegin( AppMain.AMS_RENDER_TARGET target, uint flag, AppMain.NNS_RGBA_U8 color, float depth, int stencil )
    {
        AppMain._am_draw_offset_x = 0;
        AppMain.amRenderSetTarget( target, flag, color, depth, stencil );
        if ( AppMain._am_draw_in_scene != 0 )
        {
            return true;
        }
        if ( flag != 0U )
        {
            uint num = 0U;
            if ( ( flag & AppMain.AMD_RENDER_CLEAR_COLOR ) != 0U )
            {
                if ( color != null )
                {
                    AppMain._am_draw_bg_color.r = color.r;
                    AppMain._am_draw_bg_color.g = color.g;
                    AppMain._am_draw_bg_color.b = color.b;
                    AppMain._am_draw_bg_color.a = color.a;
                }
                float red = (float)AppMain._am_draw_bg_color.r / 255f;
                float green = (float)AppMain._am_draw_bg_color.g / 255f;
                float blue = (float)AppMain._am_draw_bg_color.b / 255f;
                float alpha = (float)AppMain._am_draw_bg_color.a / 255f;
                OpenGL.glClearColor( red, green, blue, alpha );
                num |= 16384U;
            }
            if ( ( flag & AppMain.AMD_RENDER_CLEAR_DEPTH ) != 0U )
            {
                OpenGL.glClearDepthf( depth );
                num |= 256U;
            }
            OpenGL.glClear( num );
        }
        return true;
    }

    // Token: 0x060001E4 RID: 484 RVA: 0x0001148E File Offset: 0x0000F68E
    private static void amDrawEnd()
    {
        AppMain.amDrawEnd( null, 1f, 0 );
    }

    // Token: 0x060001E5 RID: 485 RVA: 0x0001149C File Offset: 0x0000F69C
    private static void amDrawEnd( AppMain.NNS_RGBA_U8 color, float z, int stencil )
    {
        if ( AppMain._am_draw_in_scene == 0 )
        {
            return;
        }
        AppMain._am_draw_in_scene = 0;
    }

    // Token: 0x060001E6 RID: 486 RVA: 0x000114AC File Offset: 0x0000F6AC
    private static void amDrawSetBGColor( AppMain.NNS_RGBA_U8 bgColor )
    {
        AppMain._am_draw_bg_color = bgColor;
    }

    // Token: 0x060001E7 RID: 487 RVA: 0x000114B4 File Offset: 0x0000F6B4
    private static AppMain.NNS_RGBA_U8 amDrawGetBGColor()
    {
        AppMain.mppAssertNotImpl();
        return AppMain._am_draw_bg_color;
    }

    // Token: 0x060001E8 RID: 488 RVA: 0x000114C0 File Offset: 0x0000F6C0
    private static void amDrawBeginScene()
    {
        AppMain._am_displaylist_manager.sort_num = 0;
    }

    // Token: 0x060001E9 RID: 489 RVA: 0x000114D0 File Offset: 0x0000F6D0
    public static void amDrawEndScene()
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        int sort_num = am_displaylist_manager.sort_num;
        am_displaylist_manager.sort_num = 0;
        if ( sort_num == 0 )
        {
            return;
        }
        AppMain.AMS_DRAW_SORT ams_DRAW_SORT = new AppMain.AMS_DRAW_SORT();
        AppMain.ArrayPointer<AppMain.AMS_DRAW_SORT> arrayPointer = new AppMain.ArrayPointer<AppMain.AMS_DRAW_SORT>(am_displaylist_manager.sortlist);
        int i = sort_num - 1;
        while ( i > 0 )
        {
            AppMain.ArrayPointer<AppMain.AMS_DRAW_SORT> pointer = arrayPointer;
            AppMain.ArrayPointer<AppMain.AMS_DRAW_SORT> arrayPointer2 = arrayPointer + 1;
            int num = (~pointer).key;
            int j = i;
            while ( j > 0 )
            {
                int key = (~arrayPointer2).key;
                if ( key >= num )
                {
                    num = key;
                    pointer = arrayPointer2;
                }
                j--;
                arrayPointer2 = ++arrayPointer2;
            }
            ams_DRAW_SORT.Assign( arrayPointer );
            ( ~arrayPointer ).Assign( ~pointer );
            ( ~pointer ).Assign( ams_DRAW_SORT );
            i--;
            arrayPointer = ++arrayPointer;
        }
        AppMain.amDrawPushState();
        arrayPointer = new AppMain.ArrayPointer<AppMain.AMS_DRAW_SORT>( am_displaylist_manager.sortlist );
        i = sort_num;
        while ( i > 0 )
        {
            AppMain.AMS_COMMAND_HEADER command = (~arrayPointer).command;
            if ( command.command_id >= 0 )
            {
                AppMain._am_draw_command_sort( command, 0U );
            }
            else
            {
                AppMain._am_draw_sort_system_exec[-command.command_id]( command, 0U );
            }
            i--;
            arrayPointer = ++arrayPointer;
        }
        AppMain.amDrawPopState();
    }

    // Token: 0x060001EA RID: 490 RVA: 0x0001160D File Offset: 0x0000F80D
    private static void amDrawBuildShader()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060001EB RID: 491 RVA: 0x00011614 File Offset: 0x0000F814
    private static void amDrawDisplay()
    {
        AppMain.amDrawDisplay( null, 0 );
    }

    // Token: 0x060001EC RID: 492 RVA: 0x00011620 File Offset: 0x0000F820
    private static void amDrawDisplay( AppMain.AMS_RENDER_TARGET target, int index )
    {
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain.amRenderSetTarget(null);
        if ( target == null )
        {
            target = ams_RENDER_TARGET;
        }
        if ( target != null )
        {
            AppMain.amRenderSetTexture( 0, target, index );
        }
        AppMain._am_draw_offset_x = 0;
    }

    // Token: 0x060001ED RID: 493 RVA: 0x0001164B File Offset: 0x0000F84B
    private static void amDrawInitDisplayList()
    {
        AppMain.amDrawInitDisplayList( 0 );
    }

    // Token: 0x060001EE RID: 494 RVA: 0x00011654 File Offset: 0x0000F854
    private static void amDrawInitDisplayList( int user_header_size )
    {
        AppMain._am_draw_task = AppMain.amTaskInitSystem( 256, 64, 1 );
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        am_displaylist_manager.write_index = 0;
        am_displaylist_manager.last_index = -1;
        am_displaylist_manager.read_index = -1;
        AppMain.AMS_DISPLAYLIST[] displaylist = am_displaylist_manager.displaylist;
        for ( int i = 0; i < 4; i++ )
        {
            displaylist[i].counter = -1;
            displaylist[i].command_buf = AppMain._am_draw_command_buf[i];
            displaylist[i].data_buf = AppMain._am_draw_data_buf[i];
            displaylist[i].command_buf_size = 0;
            displaylist[i].data_buf_size = 0;
        }
        am_displaylist_manager.regist_num = 0;
        am_displaylist_manager.reg_read_index = 0;
        am_displaylist_manager.reg_end_index = 0;
        am_displaylist_manager.reg_write_index = 0;
        am_displaylist_manager.reg_write_num = 0;
        AppMain.amDrawOpenDisplayList();
    }

    // Token: 0x060001EF RID: 495 RVA: 0x0001170C File Offset: 0x0000F90C
    private static void amDrawExitDisplayList()
    {
        AppMain.amTaskExitSystem( AppMain._am_draw_task );
    }

    // Token: 0x060001F0 RID: 496 RVA: 0x00011718 File Offset: 0x0000F918
    private static void amDrawOpenDisplayList()
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        AppMain.AMS_DISPLAYLIST ams_DISPLAYLIST = am_displaylist_manager.displaylist[am_displaylist_manager.write_index];
        ams_DISPLAYLIST.command_buf_size = 1;
        ams_DISPLAYLIST.data_buf_size = 0;
        ams_DISPLAYLIST.counter = 0;
        AppMain.ArrayPointer<object> command_buf = ams_DISPLAYLIST.command_buf;
        AppMain.AMS_COMMAND_BUFFER_HEADER ams_COMMAND_BUFFER_HEADER;
        if ( command_buf[0] == null )
        {
            ams_COMMAND_BUFFER_HEADER = new AppMain.AMS_COMMAND_BUFFER_HEADER();
            command_buf.SetPrimitive( ams_COMMAND_BUFFER_HEADER );
        }
        else
        {
            ams_COMMAND_BUFFER_HEADER = ( AppMain.AMS_COMMAND_BUFFER_HEADER )command_buf[0];
        }
        am_displaylist_manager.write_header = ams_COMMAND_BUFFER_HEADER;
        Array.Copy( AppMain._am_system_flag, ams_COMMAND_BUFFER_HEADER.system_flag, 4 );
        Array.Copy( AppMain._am_debug_flag, ams_COMMAND_BUFFER_HEADER.debug_flag, 4 );
        ams_COMMAND_BUFFER_HEADER.display_flag = 0;
        ams_COMMAND_BUFFER_HEADER.icon_alpha = 0f;
        am_displaylist_manager.command_buf_ptr = command_buf + 1;
    }

    // Token: 0x060001F1 RID: 497 RVA: 0x000117C8 File Offset: 0x0000F9C8
    private static void amDrawCloseDisplayList()
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        for ( int i = 0; i < 4; i++ )
        {
            if ( am_displaylist_manager.displaylist[i].counter >= 0 )
            {
                am_displaylist_manager.displaylist[i].counter++;
            }
        }
        am_displaylist_manager.last_index = am_displaylist_manager.write_index;
        am_displaylist_manager.write_index = ( am_displaylist_manager.write_index + 1 ) % 4;
        if ( am_displaylist_manager.write_index == am_displaylist_manager.read_index )
        {
            am_displaylist_manager.write_index = ( am_displaylist_manager.write_index + 1 ) % 4;
        }
        am_displaylist_manager.regist_num += am_displaylist_manager.reg_write_num;
        am_displaylist_manager.reg_end_index = am_displaylist_manager.reg_write_index;
        am_displaylist_manager.reg_write_num = 0;
        AppMain.amDrawOpenDisplayList();
    }

    // Token: 0x060001F2 RID: 498 RVA: 0x00011874 File Offset: 0x0000FA74
    private static int amDrawGetDisplayList()
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        int num = am_displaylist_manager.last_index;
        if ( am_displaylist_manager.read_index != -1 )
        {
            int num2 = am_displaylist_manager.read_index;
            int counter = am_displaylist_manager.displaylist[num2].counter;
            int num3 = 0;
            for ( int i = 0; i < 3; i++ )
            {
                num2 = ( num2 + 1 ) % 4;
                int counter2 = am_displaylist_manager.displaylist[num2].counter;
                if ( counter2 > num3 && counter2 < counter )
                {
                    num = num2;
                    num3 = counter2;
                }
            }
        }
        am_displaylist_manager.read_index = num;
        AppMain.AMS_COMMAND_BUFFER_HEADER read_header = (AppMain.AMS_COMMAND_BUFFER_HEADER)(~am_displaylist_manager.displaylist[num].command_buf);
        am_displaylist_manager.read_header = read_header;
        return num;
    }

    // Token: 0x060001F3 RID: 499 RVA: 0x00011910 File Offset: 0x0000FB10
    private static void amDrawRegistCommand( uint state, int command_id )
    {
        AppMain.amDrawRegistCommand( state, command_id, null );
    }

    // Token: 0x060001F4 RID: 500 RVA: 0x0001191C File Offset: 0x0000FB1C
    public static void amDrawRegistCommand( uint state, int command_id, object param )
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        AppMain.AMS_DISPLAYLIST ams_DISPLAYLIST = am_displaylist_manager.displaylist[am_displaylist_manager.write_index];
        ams_DISPLAYLIST.command_buf_size++;
        AppMain.AMS_COMMAND_HEADER ams_COMMAND_HEADER = (AppMain.AMS_COMMAND_HEADER)(~am_displaylist_manager.command_buf_ptr);
        if ( ams_COMMAND_HEADER == null )
        {
            ams_COMMAND_HEADER = new AppMain.AMS_COMMAND_HEADER();
        }
        am_displaylist_manager.command_buf_ptr.SetPrimitive( ams_COMMAND_HEADER );
        ams_COMMAND_HEADER.state = state;
        ams_COMMAND_HEADER.command_id = command_id;
        ams_COMMAND_HEADER.param = param;
        am_displaylist_manager.command_buf_ptr += 1;
    }

    // Token: 0x060001F5 RID: 501 RVA: 0x00011999 File Offset: 0x0000FB99
    private static int amDrawRegistCommand( int command_id )
    {
        return AppMain.amDrawRegistCommand( command_id, null );
    }

    // Token: 0x060001F6 RID: 502 RVA: 0x000119A4 File Offset: 0x0000FBA4
    public static int amDrawRegistCommand( int command_id, object param )
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        int reg_write_index = am_displaylist_manager.reg_write_index;
        AppMain.AMS_REGISTLIST ams_REGISTLIST = am_displaylist_manager.registlist[reg_write_index];
        ams_REGISTLIST.command_id = command_id;
        ams_REGISTLIST.param = param;
        am_displaylist_manager.reg_write_index = ( reg_write_index + 1 ) % 256;
        am_displaylist_manager.reg_write_num++;
        return reg_write_index;
    }

    // Token: 0x060001F7 RID: 503 RVA: 0x000119F3 File Offset: 0x0000FBF3
    public static bool amDrawIsRegistComplete( int index )
    {
        return AppMain._am_displaylist_manager.registlist[index].command_id == 0;
    }

    // Token: 0x060001F8 RID: 504 RVA: 0x00011A09 File Offset: 0x0000FC09
    private static byte[] amDrawGetDataBuffer()
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x060001F9 RID: 505 RVA: 0x00011A14 File Offset: 0x0000FC14
    public static void amDrawInitState()
    {
        AppMain._am_draw_state.drawflag = 0U;
        AppMain._am_draw_state.diffuse.mode = 3;
        AppMain._am_draw_state.diffuse.r = 1f;
        AppMain._am_draw_state.diffuse.g = 1f;
        AppMain._am_draw_state.diffuse.b = 1f;
        AppMain._am_draw_state.ambient.mode = 3;
        AppMain._am_draw_state.ambient.r = 1f;
        AppMain._am_draw_state.ambient.g = 1f;
        AppMain._am_draw_state.ambient.b = 1f;
        AppMain._am_draw_state.alpha.mode = 3;
        AppMain._am_draw_state.alpha.alpha = 1f;
        AppMain._am_draw_state.specular.mode = 3;
        AppMain._am_draw_state.specular.r = 1f;
        AppMain._am_draw_state.specular.g = 1f;
        AppMain._am_draw_state.specular.b = 1f;
        AppMain._am_draw_state.blend.mode = 0;
        AppMain._am_draw_state.envmap.texsrc = 1;
        AppMain._am_draw_state.zmode.compare = 1U;
        AppMain._am_draw_state.zmode.func = 515;
        AppMain._am_draw_state.zmode.update = 1U;
        AppMain.NNS_MATRIX texmtx = AppMain._am_draw_state.envmap.texmtx;
        AppMain.nnMakeUnitMatrix( texmtx );
        AppMain.nnTranslateMatrix( texmtx, texmtx, 0.5f, 0.5f, 0f );
        AppMain.nnScaleMatrix( texmtx, texmtx, 0.5f, 0.5f, 0f );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain._am_draw_state.texoffset[i].mode = 2;
            AppMain._am_draw_state.texoffset[i].u = 0f;
            AppMain._am_draw_state.texoffset[i].v = 0f;
        }
        AppMain.amDrawSetState( AppMain._am_draw_state );
    }

    // Token: 0x060001FA RID: 506 RVA: 0x00011C1E File Offset: 0x0000FE1E
    private static void amDrawPushState()
    {
        AppMain._am_draw_state_stack[AppMain._am_draw_state_stack_num++].Assign( AppMain._am_draw_state );
    }

    // Token: 0x060001FB RID: 507 RVA: 0x00011C3E File Offset: 0x0000FE3E
    private static void amDrawPopState()
    {
        AppMain._am_draw_state_stack_num--;
        AppMain.amDrawSetState( AppMain._am_draw_state_stack[AppMain._am_draw_state_stack_num] );
    }

    // Token: 0x060001FC RID: 508 RVA: 0x00011C5C File Offset: 0x0000FE5C
    private static void amDrawSetState( AppMain.AMS_DRAWSTATE state )
    {
        AppMain._am_draw_state.Assign( state );
        AppMain.nnSetMaterialControlDiffuse( state.diffuse.mode, state.diffuse.r, state.diffuse.g, state.diffuse.b );
        AppMain.nnSetMaterialControlAmbient( state.ambient.mode, state.ambient.r, state.ambient.g, state.ambient.b );
        AppMain.nnSetMaterialControlAlpha( state.alpha.mode, state.alpha.alpha );
        AppMain.nnSetMaterialControlBlendMode( state.blend.mode );
        AppMain.nnSetMaterialControlEnvTexMatrix( state.envmap.texsrc, AppMain._am_draw_state.envmap.texmtx );
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.nnSetMaterialControlTextureOffset( i, state.texoffset[i].mode, state.texoffset[i].u, state.texoffset[i].v );
        }
        AppMain.nnSetFogSwitch( state.fog.flag != 0 );
        AppMain.nnSetFogColor( state.fog_color.r, state.fog_color.g, state.fog_color.b );
        AppMain.nnSetFogRange( state.fog_range.fnear, state.fog_range.ffar );
    }

    // Token: 0x060001FD RID: 509 RVA: 0x00011DB1 File Offset: 0x0000FFB1
    private static AppMain.AMS_DRAWSTATE amDrawGetState( AppMain.AMS_DRAWSTATE state )
    {
        if ( state != null )
        {
            state.Assign( AppMain._am_draw_state );
        }
        return AppMain._am_draw_state;
    }

    // Token: 0x060001FE RID: 510 RVA: 0x00011DC7 File Offset: 0x0000FFC7
    private static AppMain.AMS_DRAWSTATE amDrawGetState()
    {
        return AppMain._am_draw_state;
    }

    // Token: 0x060001FF RID: 511 RVA: 0x00011DCE File Offset: 0x0000FFCE
    public static void amDrawSetProjection( AppMain.NNS_MATRIX proj_mtx, int proj_type )
    {
        AppMain._am_draw_proj_mtx.Assign( proj_mtx );
        AppMain._am_draw_proj_type = proj_type;
        AppMain.nnSetProjection( proj_mtx, proj_type );
    }

    // Token: 0x06000200 RID: 512 RVA: 0x00011DE9 File Offset: 0x0000FFE9
    private static AppMain.NNS_MATRIX amDrawGetProjectionMatrix()
    {
        return AppMain._am_draw_proj_mtx;
    }

    // Token: 0x06000201 RID: 513 RVA: 0x00011DF0 File Offset: 0x0000FFF0
    private static int amDrawGetProjectionType()
    {
        return AppMain._am_draw_proj_type;
    }

    // Token: 0x06000202 RID: 514 RVA: 0x00011DF7 File Offset: 0x0000FFF7
    private static void amDrawExecute()
    {
        AppMain.amTaskExecute( AppMain._am_draw_task );
        AppMain.amTaskReset( AppMain._am_draw_task );
    }

    // Token: 0x06000203 RID: 515 RVA: 0x00011E0D File Offset: 0x0001000D
    private static void amDrawExecCommand( uint state )
    {
        AppMain.amDrawExecCommand( state, 0U );
    }

    // Token: 0x06000204 RID: 516 RVA: 0x00011E18 File Offset: 0x00010018
    public static void amDrawExecCommand( uint state, uint drawflag )
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        AppMain.AMS_DISPLAYLIST ams_DISPLAYLIST = am_displaylist_manager.displaylist[am_displaylist_manager.read_index];
        object[] array = ams_DISPLAYLIST.command_buf.array;
        AppMain.AMS_COMMAND_BUFFER_HEADER ams_COMMAND_BUFFER_HEADER = (AppMain.AMS_COMMAND_BUFFER_HEADER)array[0];
        int num = ams_DISPLAYLIST.command_buf_size - 1;
        for ( int i = 0; i < num; i++ )
        {
            AppMain.AMS_COMMAND_HEADER ams_COMMAND_HEADER = (AppMain.AMS_COMMAND_HEADER)array[i + 1];
            if ( ams_COMMAND_HEADER.state == state )
            {
                if ( ams_COMMAND_HEADER.command_id >= 0 )
                {
                    AppMain._am_draw_command_func( ams_COMMAND_HEADER, drawflag );
                }
                else
                {
                    AppMain._am_draw_system_exec[-ams_COMMAND_HEADER.command_id]( ams_COMMAND_HEADER, drawflag );
                }
            }
        }
    }

    // Token: 0x06000205 RID: 517 RVA: 0x00011EAC File Offset: 0x000100AC
    private static void amDrawExecRegist()
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        int num = am_displaylist_manager.regist_num;
        int num2 = am_displaylist_manager.reg_read_index;
        int reg_end_index = am_displaylist_manager.reg_end_index;
        if ( num == 0 )
        {
            return;
        }
        num = 0;
        while ( num2 != reg_end_index )
        {
            AppMain.AMS_REGISTLIST ams_REGISTLIST = am_displaylist_manager.registlist[num2];
            num2 = ( num2 + 1 ) % 256;
            num++;
            AppMain._am_draw_regist_func[ams_REGISTLIST.command_id]( ams_REGISTLIST );
        }
        am_displaylist_manager.regist_num -= num;
        am_displaylist_manager.reg_read_index = num2;
    }

    // Token: 0x06000206 RID: 518 RVA: 0x00011F24 File Offset: 0x00010124
    private static void amDrawAddSort( AppMain.AMS_COMMAND_HEADER command, int key )
    {
        AppMain.AMS_DISPLAYLIST_MANAGER am_displaylist_manager = AppMain._am_displaylist_manager;
        if ( am_displaylist_manager.sort_num >= 512 )
        {
            AppMain.amSystemLog( "[WARN] sort_num over.\n" );
            return;
        }
        AppMain.AMS_DRAW_SORT ams_DRAW_SORT = am_displaylist_manager.sortlist[am_displaylist_manager.sort_num++];
        ams_DRAW_SORT.key = key;
        ams_DRAW_SORT.command = command;
    }

    // Token: 0x06000207 RID: 519 RVA: 0x00011F76 File Offset: 0x00010176
    private static object _amDrawConvVertex2D( AppMain.NNS_PRIM2D_P vs, int count )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06000208 RID: 520 RVA: 0x00011F80 File Offset: 0x00010180
    private static object _amDrawConvVertex2D( AppMain.NNS_PRIM2D_PC[] vs, int count )
    {
        AppMain.NNS_PRIM2D_PC[] array = AppMain.New<AppMain.NNS_PRIM2D_PC>(count);
        for ( int i = 0; i < count; i++ )
        {
            AppMain.amDrawConv2D( array[i].Pos, vs[i].Pos );
            array[i].Col = vs[i].Col;
        }
        return array;
    }

    // Token: 0x06000209 RID: 521 RVA: 0x00011FC6 File Offset: 0x000101C6
    private static void amDrawConv2D( AppMain.NNS_VECTOR2D vd, AppMain.NNS_VECTOR2D vs )
    {
        vd.Assign( vs );
    }

    // Token: 0x0600020A RID: 522 RVA: 0x00011FD0 File Offset: 0x000101D0
    private static object _amDrawConvVertex2D( AppMain.NNS_PRIM2D_PCT vs, int count )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x0600020B RID: 523 RVA: 0x00011FD8 File Offset: 0x000101D8
    private static void amDrawPrimitive2D( int format, int type, object vtx, int count, float pri )
    {
        switch ( format )
        {
            case 1:
                vtx = AppMain._amDrawConvVertex2D( ( AppMain.NNS_PRIM2D_PC[] )vtx, count );
                break;
            case 2:
                vtx = AppMain._amDrawConvVertex2D( ( AppMain.NNS_PRIM2D_PCT )vtx, count );
                break;
        }
        AppMain.nnDrawPrimitive2D( type, vtx, count, pri );
    }

    // Token: 0x0600020C RID: 524 RVA: 0x00012021 File Offset: 0x00010221
    private static void amDrawPrimitiveLine2D( AppMain.NNE_PRIM_LINE type, object vtx, int count, float pri )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600020D RID: 525 RVA: 0x00012028 File Offset: 0x00010228
    private static void amDrawPrimitivePoint2D( int format, object vtx, int count, float pri )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600020E RID: 526 RVA: 0x0001202F File Offset: 0x0001022F
    public static void amDrawMakeTask( AppMain.TaskProc proc, ushort prio )
    {
        AppMain.amDrawMakeTask( proc, prio, null );
    }

    // Token: 0x0600020F RID: 527 RVA: 0x0001203C File Offset: 0x0001023C
    public static void amDrawMakeTask( AppMain.TaskProc proc, ushort prio, object data )
    {
        AppMain.AMS_PARAM_MAKE_TASK ams_PARAM_MAKE_TASK = AppMain.amDraw_AMS_PARAM_MAKE_TASK_Pool.Alloc();
        ams_PARAM_MAKE_TASK.prio = ( int )prio;
        ams_PARAM_MAKE_TASK.proc = proc;
        ams_PARAM_MAKE_TASK.work_data = data;
        AppMain.amDrawRegistCommand( 16777216U, -1, ams_PARAM_MAKE_TASK );
    }

    // Token: 0x06000210 RID: 528 RVA: 0x00012075 File Offset: 0x00010275
    public static void amDrawSetWorldViewMatrix( AppMain.NNS_MATRIX mtx )
    {
        if ( mtx == null )
        {
            mtx = AppMain.amMatrixGetCurrent();
        }
        AppMain.nnCopyMatrix( AppMain._am_draw_world_view_matrix, mtx );
    }

    // Token: 0x06000211 RID: 529 RVA: 0x0001208C File Offset: 0x0001028C
    private static void amDrawMakeTask( AppMain.TaskProc proc, ushort prio, uint data )
    {
        AppMain.amDrawRegistCommand( 16777216U, -1, new AppMain.AMS_PARAM_MAKE_TASK
        {
            prio = ( int )prio,
            proc = proc,
            work_data = data
        } );
    }

    // Token: 0x06000212 RID: 530 RVA: 0x000120C5 File Offset: 0x000102C5
    private static void amDrawPrintColor( uint rgba )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000213 RID: 531 RVA: 0x000120CC File Offset: 0x000102CC
    private static void amDrawObject( uint state, AppMain.NNS_OBJECT obj, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000214 RID: 532 RVA: 0x000120D3 File Offset: 0x000102D3
    private static void amDrawObjectMaterialMotion( uint state, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000215 RID: 533 RVA: 0x000120DC File Offset: 0x000102DC
    public static void amDrawObjectSetMaterial( uint state, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, AppMain.NNS_VECTOR scale, ref AppMain.NNS_RGBA color, float u, float v, int blend, uint drawflag )
    {
        AppMain.amDrawObjectSetMaterial( state, _object, texlist, scale, ref color, u, v, blend, drawflag, null );
    }

    // Token: 0x06000216 RID: 534 RVA: 0x00012100 File Offset: 0x00010300
    public static void amDrawObjectSetMaterial( uint state, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, AppMain.NNS_VECTOR scale, ref AppMain.NNS_RGBA color, float u, float v, int blend, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.AMS_PARAM_DRAW_OBJECT_MATERIAL ams_PARAM_DRAW_OBJECT_MATERIAL = AppMain.amDrawAlloc_AMS_PARAM_DRAW_OBJECT_MATERIAL();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amDrawAlloc_NNS_MATRIX();
        AppMain.nnCopyMatrix( nns_MATRIX, AppMain.amMatrixGetCurrent() );
        ams_PARAM_DRAW_OBJECT_MATERIAL._object = _object;
        ams_PARAM_DRAW_OBJECT_MATERIAL.mtx = nns_MATRIX;
        ams_PARAM_DRAW_OBJECT_MATERIAL.sub_obj_type = 0U;
        ams_PARAM_DRAW_OBJECT_MATERIAL.flag = drawflag;
        ams_PARAM_DRAW_OBJECT_MATERIAL.texlist = texlist;
        ams_PARAM_DRAW_OBJECT_MATERIAL.scaleZ = -scale.z;
        AppMain.nnCopyVector( ams_PARAM_DRAW_OBJECT_MATERIAL.scale, scale );
        ams_PARAM_DRAW_OBJECT_MATERIAL.color = color;
        ams_PARAM_DRAW_OBJECT_MATERIAL.scroll_u = u;
        ams_PARAM_DRAW_OBJECT_MATERIAL.scroll_v = v;
        ams_PARAM_DRAW_OBJECT_MATERIAL.blend = blend;
        ams_PARAM_DRAW_OBJECT_MATERIAL.material_func = func;
        AppMain.amDrawRegistCommand( state, -8, ams_PARAM_DRAW_OBJECT_MATERIAL );
    }

    // Token: 0x06000217 RID: 535 RVA: 0x00012197 File Offset: 0x00010397
    private static void amDrawMotion( uint state, AppMain.NNS_MOTION motion, float frame, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000218 RID: 536 RVA: 0x0001219E File Offset: 0x0001039E
    private static void amDrawMotionMaterialMotion( uint state, AppMain.NNS_MOTION motion, float frame, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000219 RID: 537 RVA: 0x000121A8 File Offset: 0x000103A8
    public static void amDrawPrimitive3D( uint state, AppMain.AMS_PARAM_DRAW_PRIMITIVE setParam )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.amDrawAlloc_AMS_PARAM_DRAW_PRIMITIVE();
        ams_PARAM_DRAW_PRIMITIVE.Assign( setParam );
        if ( ams_PARAM_DRAW_PRIMITIVE.mtx == null )
        {
            ams_PARAM_DRAW_PRIMITIVE.mtx = AppMain.amDraw_NNS_MATRIX_Pool.Alloc();
            ams_PARAM_DRAW_PRIMITIVE.mtx.Assign( AppMain.amMatrixGetCurrent() );
        }
        AppMain.amDrawRegistCommand( state, -14, ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x0600021A RID: 538 RVA: 0x000121F4 File Offset: 0x000103F4
    private static void amDrawPrim2D( uint state, AppMain.AMS_PARAM_DRAW_PRIMITIVE setParam )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.Assign( setParam );
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnCopyMatrix( nns_MATRIX, AppMain.amMatrixGetCurrent() );
        ams_PARAM_DRAW_PRIMITIVE.mtx = nns_MATRIX;
        AppMain.amDrawRegistCommand( state, -13, ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x0600021B RID: 539 RVA: 0x00012230 File Offset: 0x00010430
    private static void amDrawGetPrimBlendParam( int type, AppMain.AMS_PARAM_DRAW_PRIMITIVE setParam )
    {
        switch ( type )
        {
            case 0:
                setParam.bldSrc = 770;
                setParam.bldDst = 771;
                setParam.bldMode = 32774;
                return;
            case 1:
                setParam.bldSrc = 770;
                setParam.bldDst = 1;
                setParam.bldMode = 32774;
                return;
            case 2:
                setParam.bldSrc = 770;
                setParam.bldDst = 1;
                setParam.bldMode = 32779;
                return;
            default:
                return;
        }
    }

    // Token: 0x0600021C RID: 540 RVA: 0x000122AF File Offset: 0x000104AF
    private static void amDrawSetMaterialDiffuse( uint state, int mode, float r, float g, float b )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600021D RID: 541 RVA: 0x000122B6 File Offset: 0x000104B6
    private static void amDrawSetMaterialAmbient( uint state, int mode, float r, float g, float b )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600021E RID: 542 RVA: 0x000122BD File Offset: 0x000104BD
    private static void amDrawSetMaterialAlpha( uint state, int mode, float alpha )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600021F RID: 543 RVA: 0x000122C4 File Offset: 0x000104C4
    private static void amDrawSetMaterialSpecular( uint state, int mode, float r, float g, float b )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000220 RID: 544 RVA: 0x000122CB File Offset: 0x000104CB
    private static void amDrawSetMaterialBlendMode( uint state, int mode )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000221 RID: 545 RVA: 0x000122D2 File Offset: 0x000104D2
    private static void amDrawSetMaterialTexOffset( uint state, int slot, int mode, float u, float v )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000222 RID: 546 RVA: 0x000122DC File Offset: 0x000104DC
    public static void amDrawSetFog( uint state, int flag )
    {
        AppMain.AMS_DRAWSTATE_FOG ams_DRAWSTATE_FOG = AppMain.amDrawAlloc_AMS_DRAWSTATE_FOG();
        ams_DRAWSTATE_FOG.flag = ( flag & 1 );
        AppMain.amDrawRegistCommand( state, -22, ams_DRAWSTATE_FOG );
    }

    // Token: 0x06000223 RID: 547 RVA: 0x00012304 File Offset: 0x00010504
    public static void amDrawSetFogColor( uint state, float r, float g, float b )
    {
        AppMain.AMS_DRAWSTATE_FOG_COLOR ams_DRAWSTATE_FOG_COLOR = AppMain.amDrawAlloc_AMS_DRAWSTATE_FOG_COLOR();
        ams_DRAWSTATE_FOG_COLOR.r = r;
        ams_DRAWSTATE_FOG_COLOR.g = g;
        ams_DRAWSTATE_FOG_COLOR.b = b;
        AppMain.amDrawRegistCommand( state, -23, ams_DRAWSTATE_FOG_COLOR );
    }

    // Token: 0x06000224 RID: 548 RVA: 0x00012338 File Offset: 0x00010538
    public static void amDrawSetFogRange( uint state, float fnear, float ffar )
    {
        AppMain.AMS_DRAWSTATE_FOG_RANGE ams_DRAWSTATE_FOG_RANGE = AppMain.amDrawAlloc_AMS_DRAWSTATE_FOG_RANGE();
        ams_DRAWSTATE_FOG_RANGE.fnear = fnear;
        ams_DRAWSTATE_FOG_RANGE.ffar = ffar;
        AppMain.amDrawRegistCommand( state, -24, ams_DRAWSTATE_FOG_RANGE );
    }

    // Token: 0x06000225 RID: 549 RVA: 0x00012362 File Offset: 0x00010562
    private static void amDrawSetZMode( uint state, bool compare, int func, bool update )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000226 RID: 550 RVA: 0x00012369 File Offset: 0x00010569
    private static void amDrawObject( AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000227 RID: 551 RVA: 0x00012370 File Offset: 0x00010570
    private static void amDrawObjectMaterialMotion( AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000228 RID: 552 RVA: 0x00012377 File Offset: 0x00010577
    private static void amDrawMotion( AppMain.NNS_MOTION motion, float frame, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000229 RID: 553 RVA: 0x00012380 File Offset: 0x00010580
    private static void amDrawMotionMaterialMotion( AppMain.NNS_MOTION motion, float frame, AppMain.NNS_OBJECT _object, AppMain.NNS_TEXLIST texlist, uint drawflag, AppMain.NNS_MATERIALCALLBACK_FUNC func )
    {
        AppMain.AMS_COMMAND_HEADER ams_COMMAND_HEADER = new AppMain.AMS_COMMAND_HEADER();
        AppMain.AMS_PARAM_DRAW_MOTION ams_PARAM_DRAW_MOTION = new AppMain.AMS_PARAM_DRAW_MOTION();
        ams_COMMAND_HEADER.command_id = -10;
        ams_COMMAND_HEADER.param = ams_PARAM_DRAW_MOTION;
        ams_PARAM_DRAW_MOTION._object = _object;
        ams_PARAM_DRAW_MOTION.mtx = null;
        ams_PARAM_DRAW_MOTION.sub_obj_type = 0U;
        ams_PARAM_DRAW_MOTION.flag = drawflag;
        ams_PARAM_DRAW_MOTION.texlist = texlist;
        ams_PARAM_DRAW_MOTION.motion = motion;
        ams_PARAM_DRAW_MOTION.frame = frame;
        ams_PARAM_DRAW_MOTION.material_func = func;
        AppMain._amDrawMotion( ams_COMMAND_HEADER, drawflag );
    }

    // Token: 0x0600022A RID: 554 RVA: 0x000123EC File Offset: 0x000105EC
    private static void amDrawSetMaterialDiffuse( int mode, float r, float g, float b )
    {
        if ( mode != -1 )
        {
            AppMain.nnSetMaterialControlDiffuse( mode, r, g, b );
            AppMain._am_draw_state.drawflag |= 1048576U;
        }
        else
        {
            AppMain._am_draw_state.drawflag &= 4293918719U;
        }
        AppMain._am_draw_state.diffuse.mode = mode;
        AppMain._am_draw_state.diffuse.r = r;
        AppMain._am_draw_state.diffuse.g = g;
        AppMain._am_draw_state.diffuse.b = b;
    }

    // Token: 0x0600022B RID: 555 RVA: 0x00012474 File Offset: 0x00010674
    private static void amDrawSetMaterialAmbient( int mode, float r, float g, float b )
    {
        if ( mode != -1 )
        {
            AppMain.nnSetMaterialControlAmbient( mode, r, g, b );
            AppMain._am_draw_state.drawflag |= 2097152U;
        }
        else
        {
            AppMain._am_draw_state.drawflag &= 4292870143U;
        }
        AppMain._am_draw_state.ambient.mode = mode;
        AppMain._am_draw_state.ambient.r = r;
        AppMain._am_draw_state.ambient.g = g;
        AppMain._am_draw_state.ambient.b = b;
    }

    // Token: 0x0600022C RID: 556 RVA: 0x000124FC File Offset: 0x000106FC
    private static void amDrawSetMaterialAlpha( int mode, float alpha )
    {
        if ( mode != -1 )
        {
            AppMain.nnSetMaterialControlAlpha( mode, alpha );
            AppMain._am_draw_state.drawflag |= 8388608U;
        }
        else
        {
            AppMain._am_draw_state.drawflag &= 4286578687U;
        }
        AppMain._am_draw_state.alpha.mode = mode;
        AppMain._am_draw_state.alpha.alpha = alpha;
    }

    // Token: 0x0600022D RID: 557 RVA: 0x00012564 File Offset: 0x00010764
    private static void amDrawSetMaterialSpecular( int mode, float r, float g, float b )
    {
        if ( mode != -1 )
        {
            AppMain._am_draw_state.drawflag |= 4194304U;
        }
        else
        {
            AppMain._am_draw_state.drawflag &= 4290772991U;
        }
        AppMain._am_draw_state.specular.mode = mode;
        AppMain._am_draw_state.specular.r = r;
        AppMain._am_draw_state.specular.g = g;
        AppMain._am_draw_state.specular.b = b;
    }

    // Token: 0x0600022E RID: 558 RVA: 0x000125E3 File Offset: 0x000107E3
    private static void amDrawSetMaterialEnvMap( uint state, int texsrc, AppMain.NNS_MATRIX texmtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600022F RID: 559 RVA: 0x000125EC File Offset: 0x000107EC
    private static void amDrawSetMaterialBlendMode( int mode )
    {
        if ( mode != -1 )
        {
            AppMain.nnSetMaterialControlBlendMode( mode );
            AppMain._am_draw_state.drawflag |= 33554432U;
        }
        else
        {
            AppMain._am_draw_state.drawflag &= 4261412863U;
        }
        AppMain._am_draw_state.blend.mode = mode;
    }

    // Token: 0x06000230 RID: 560 RVA: 0x00012644 File Offset: 0x00010844
    private static void amDrawSetMaterialTexOffset( int slot, int mode, float u, float v )
    {
        AppMain.ArrayPointer<AppMain.AMS_DRAWSTATE_TEXOFFSET> pointer;
        if ( slot != -1 )
        {
            if ( mode != -1 )
            {
                AppMain.nnSetMaterialControlTextureOffset( slot, mode, u, v );
                AppMain._am_draw_state.drawflag |= 268435456U;
            }
            else
            {
                AppMain._am_draw_state.drawflag &= 4026531839U;
            }
            pointer = new AppMain.ArrayPointer<AppMain.AMS_DRAWSTATE_TEXOFFSET>( AppMain._am_draw_state.texoffset, slot );
            ( ~pointer ).mode = mode;
            ( ~pointer ).u = u;
            ( ~pointer ).v = v;
            return;
        }
        pointer = new AppMain.ArrayPointer<AppMain.AMS_DRAWSTATE_TEXOFFSET>( AppMain._am_draw_state.texoffset, 0 );
        int i;
        if ( mode != -1 )
        {
            i = 0;
            while ( i < 4 )
            {
                AppMain.nnSetMaterialControlTextureOffset( i, mode, u, v );
                AppMain._am_draw_state.drawflag |= 268435456U;
                ( ~pointer ).mode = mode;
                ( ~pointer ).u = u;
                ( ~pointer ).v = v;
                i++;
                pointer = ++pointer;
            }
            return;
        }
        i = 0;
        while ( i < 4 )
        {
            AppMain._am_draw_state.drawflag &= 4026531839U;
            ( ~pointer ).mode = mode;
            ( ~pointer ).u = u;
            ( ~pointer ).v = v;
            i++;
            pointer = ++pointer;
        }
    }

    // Token: 0x06000231 RID: 561 RVA: 0x00012781 File Offset: 0x00010981
    private static void amDrawSetFog( int flag )
    {
        flag &= 1;
        AppMain.nnSetFogSwitch( flag != 0 );
        AppMain._am_draw_state.fog.flag = flag;
    }

    // Token: 0x06000232 RID: 562 RVA: 0x000127A4 File Offset: 0x000109A4
    private static void amDrawSetFogColor( float r, float g, float b )
    {
        AppMain.nnSetFogColor( r, g, b );
        AppMain._am_draw_state.fog_color.r = r;
        AppMain._am_draw_state.fog_color.g = g;
        AppMain._am_draw_state.fog_color.b = b;
    }

    // Token: 0x06000233 RID: 563 RVA: 0x000127DE File Offset: 0x000109DE
    private static void amDrawSetFogRange( float fnear, float ffar )
    {
        AppMain.nnSetFogRange( fnear, ffar );
        AppMain._am_draw_state.fog_range.fnear = fnear;
        AppMain._am_draw_state.fog_range.ffar = ffar;
    }

    // Token: 0x06000234 RID: 564 RVA: 0x00012808 File Offset: 0x00010A08
    private static void amDrawSetZMode( bool compare, int func, bool update )
    {
        AppMain.mppAssertNotImpl();
        AppMain._am_draw_state.zmode.compare = ( uint )( compare ? 1 : 0 );
        AppMain._am_draw_state.zmode.func = func;
        AppMain._am_draw_state.zmode.update = ( uint )( update ? 1 : 0 );
    }

    // Token: 0x06000235 RID: 565 RVA: 0x00012858 File Offset: 0x00010A58
    private static void _amDrawTaskMake( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_MAKE_TASK ams_PARAM_MAKE_TASK = (AppMain.AMS_PARAM_MAKE_TASK)command.param;
        AppMain.AMS_TCB ams_TCB = AppMain.amTaskMake(AppMain._am_draw_task, ams_PARAM_MAKE_TASK.proc, null, (uint)ams_PARAM_MAKE_TASK.prio, 0U, 0U, "DRAW");
        ams_TCB.work = ams_PARAM_MAKE_TASK.work_data;
    }

    // Token: 0x06000236 RID: 566 RVA: 0x0001289C File Offset: 0x00010A9C
    private static void _amDrawPrintf( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000237 RID: 567 RVA: 0x000128A3 File Offset: 0x00010AA3
    private static void _amDrawPrintColor( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000238 RID: 568 RVA: 0x000128AA File Offset: 0x00010AAA
    private static void _amDrawHeapMap( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000239 RID: 569 RVA: 0x000128B1 File Offset: 0x00010AB1
    private static void _amDrawThreadMap( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600023A RID: 570 RVA: 0x000128B8 File Offset: 0x00010AB8
    private static void _amDrawObject( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amDrawAlloc_NNS_MATRIX();
        AppMain.amMatrixPush();
        AppMain.AMS_PARAM_DRAW_OBJECT ams_PARAM_DRAW_OBJECT = (AppMain.AMS_PARAM_DRAW_OBJECT)command.param;
        int nNode = ams_PARAM_DRAW_OBJECT._object.nNode;
        if ( AppMain.__amDrawObject.plt_mtx == null || AppMain.__amDrawObject.plt_mtx.Length < nNode )
        {
            AppMain.__amDrawObject.nstat = new uint[nNode];
            AppMain.__amDrawObject.plt_mtx = new AppMain.NNS_MATRIX[nNode];
            for ( int i = 0; i < nNode; i++ )
            {
                AppMain.__amDrawObject.plt_mtx[i] = new AppMain.NNS_MATRIX();
            }
        }
        AppMain.NNS_MATRIX[] plt_mtx = AppMain.__amDrawObject.plt_mtx;
        uint[] nstat = AppMain.__amDrawObject.nstat;
        if ( ams_PARAM_DRAW_OBJECT.mtx != null )
        {
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain.amMatrixGetCurrent(), ams_PARAM_DRAW_OBJECT.mtx );
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain._am_draw_world_view_matrix, nns_MATRIX );
        }
        else
        {
            AppMain.nnMultiplyMatrix( nns_MATRIX, AppMain._am_draw_world_view_matrix, AppMain.amMatrixGetCurrent() );
        }
        AppMain.nnSetUpNodeStatusList( nstat, nNode, 0U );
        AppMain.nnCalcMatrixPalette( plt_mtx, nstat, ams_PARAM_DRAW_OBJECT._object, nns_MATRIX, AppMain._am_default_stack, 1U );
        if ( ams_PARAM_DRAW_OBJECT.texlist != null )
        {
            AppMain.nnSetTextureList( ams_PARAM_DRAW_OBJECT.texlist );
        }
        AppMain.nnSetMaterialCallback( ams_PARAM_DRAW_OBJECT.material_func );
        if ( command.command_id == -6 )
        {
            AppMain.nnDrawObject( ams_PARAM_DRAW_OBJECT._object, plt_mtx, nstat, ams_PARAM_DRAW_OBJECT.sub_obj_type | 256U | 512U | 7U, ams_PARAM_DRAW_OBJECT.flag | drawflag | AppMain._am_draw_state.drawflag, 0U );
        }
        else
        {
            AppMain.nnDrawMaterialMotionObject( ams_PARAM_DRAW_OBJECT._object, plt_mtx, nstat, ams_PARAM_DRAW_OBJECT.sub_obj_type | 256U | 512U | 7U, ams_PARAM_DRAW_OBJECT.flag | drawflag | AppMain._am_draw_state.drawflag );
        }
        if ( ams_PARAM_DRAW_OBJECT.material_func != null )
        {
            AppMain.nnSetMaterialCallback( null );
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x0600023B RID: 571 RVA: 0x00012A38 File Offset: 0x00010C38
    private static void _amDrawObjectSetMaterial( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_DRAW_OBJECT_MATERIAL ams_PARAM_DRAW_OBJECT_MATERIAL = (AppMain.AMS_PARAM_DRAW_OBJECT_MATERIAL)command.param;
        AppMain.amDrawPushState();
        if ( ( ams_PARAM_DRAW_OBJECT_MATERIAL.flag & 3145728U ) != 0U )
        {
            AppMain.amDrawSetMaterialDiffuse( 3, ams_PARAM_DRAW_OBJECT_MATERIAL.color.r, ams_PARAM_DRAW_OBJECT_MATERIAL.color.g, ams_PARAM_DRAW_OBJECT_MATERIAL.color.b );
            AppMain.amDrawSetMaterialAmbient( 3, ams_PARAM_DRAW_OBJECT_MATERIAL.color.r, ams_PARAM_DRAW_OBJECT_MATERIAL.color.g, ams_PARAM_DRAW_OBJECT_MATERIAL.color.b );
        }
        if ( ( ams_PARAM_DRAW_OBJECT_MATERIAL.flag & 8388608U ) != 0U )
        {
            AppMain.amDrawSetMaterialAlpha( 3, ams_PARAM_DRAW_OBJECT_MATERIAL.color.a );
        }
        if ( ( ams_PARAM_DRAW_OBJECT_MATERIAL.flag & 268435456U ) != 0U )
        {
            AppMain.amDrawSetMaterialTexOffset( 0, 1, ams_PARAM_DRAW_OBJECT_MATERIAL.scroll_u, ams_PARAM_DRAW_OBJECT_MATERIAL.scroll_v );
        }
        command.command_id = -6;
        AppMain._amDrawObject( command, drawflag );
        AppMain.amDrawPopState();
    }

    // Token: 0x0600023C RID: 572 RVA: 0x00012B06 File Offset: 0x00010D06
    private static void _amDrawMotion( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600023D RID: 573 RVA: 0x00012B0D File Offset: 0x00010D0D
    private static void _amDrawMotionTRS( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600023E RID: 574 RVA: 0x00012B14 File Offset: 0x00010D14
    private static void _amDrawPrimitive2D( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = (AppMain.AMS_PARAM_DRAW_PRIMITIVE)command.param;
        if ( ams_PARAM_DRAW_PRIMITIVE.texlist != null )
        {
            AppMain.nnSetPrimitiveTexNum( ams_PARAM_DRAW_PRIMITIVE.texlist, ams_PARAM_DRAW_PRIMITIVE.texId );
            AppMain.nnSetPrimitiveTexState( 0, 0, ams_PARAM_DRAW_PRIMITIVE.uwrap, ams_PARAM_DRAW_PRIMITIVE.vwrap );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.noSort != 0 || ams_PARAM_DRAW_PRIMITIVE.ablend == 0 )
        {
            AppMain._amDrawSetPrimitive2DParam( command, drawflag );
            AppMain.nnBeginDrawPrimitive2D( ams_PARAM_DRAW_PRIMITIVE.format2D, ams_PARAM_DRAW_PRIMITIVE.ablend );
            switch ( ams_PARAM_DRAW_PRIMITIVE.format2D )
            {
                case 1:
                    AppMain.amDrawPrimitive2D( ams_PARAM_DRAW_PRIMITIVE.format2D, ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPC2D, ams_PARAM_DRAW_PRIMITIVE.count, ams_PARAM_DRAW_PRIMITIVE.zOffset );
                    break;
                case 2:
                    AppMain.amDrawPrimitive2D( ams_PARAM_DRAW_PRIMITIVE.format2D, ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPCT2D, ams_PARAM_DRAW_PRIMITIVE.count, ams_PARAM_DRAW_PRIMITIVE.zOffset );
                    break;
            }
            AppMain.nnEndDrawPrimitive2D();
            return;
        }
        AppMain.AMS_COMMAND_HEADER ams_COMMAND_HEADER = new AppMain.AMS_COMMAND_HEADER(command);
        ams_COMMAND_HEADER.command_id = -3;
        ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        nns_MATRIX.Assign( AppMain.amMatrixGetCurrent() );
        ams_PARAM_DRAW_PRIMITIVE.Assign( ( AppMain.AMS_PARAM_DRAW_PRIMITIVE )command.param );
        ams_PARAM_DRAW_PRIMITIVE.mtx = nns_MATRIX;
        ams_COMMAND_HEADER.param = ams_PARAM_DRAW_PRIMITIVE;
        AppMain.amDrawAddSort( ams_COMMAND_HEADER, ( int )( ams_PARAM_DRAW_PRIMITIVE.zOffset * 100f ) );
    }

    // Token: 0x0600023F RID: 575 RVA: 0x00012C44 File Offset: 0x00010E44
    private static void _amDrawPrimitive3D( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = (AppMain.AMS_PARAM_DRAW_PRIMITIVE)command.param;
        if ( ams_PARAM_DRAW_PRIMITIVE.texlist != null && ams_PARAM_DRAW_PRIMITIVE.texId != -1 )
        {
            AppMain.nnSetPrimitiveTexNum( ams_PARAM_DRAW_PRIMITIVE.texlist, ams_PARAM_DRAW_PRIMITIVE.texId );
            AppMain.nnSetPrimitiveTexState( 0, 0, ams_PARAM_DRAW_PRIMITIVE.uwrap, ams_PARAM_DRAW_PRIMITIVE.vwrap );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.noSort != 0 || ams_PARAM_DRAW_PRIMITIVE.ablend == 0 )
        {
            AppMain._amDrawSetPrimitive3DParam( command, drawflag );
            AppMain.nnBeginDrawPrimitive3D( ams_PARAM_DRAW_PRIMITIVE.format3D, ams_PARAM_DRAW_PRIMITIVE.ablend, 0, 0 );
            switch ( ams_PARAM_DRAW_PRIMITIVE.format3D )
            {
                case 2:
                    AppMain.nnDrawPrimitive3D( ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPC3D, ams_PARAM_DRAW_PRIMITIVE.count );
                    break;
                case 4:
                    AppMain.nnDrawPrimitive3D( ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D, ams_PARAM_DRAW_PRIMITIVE.count );
                    break;
            }
            AppMain.nnEndDrawPrimitive3D();
            return;
        }
        command.command_id = -4;
        ams_PARAM_DRAW_PRIMITIVE = AppMain.amDrawAlloc_AMS_PARAM_DRAW_PRIMITIVE();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amDrawAlloc_NNS_MATRIX();
        AppMain.nnCopyMatrix( nns_MATRIX, AppMain.amMatrixGetCurrent() );
        ams_PARAM_DRAW_PRIMITIVE.Assign( ( AppMain.AMS_PARAM_DRAW_PRIMITIVE )command.param );
        ams_PARAM_DRAW_PRIMITIVE.mtx = nns_MATRIX;
        command.param = ams_PARAM_DRAW_PRIMITIVE;
        AppMain.amDrawAddSort( command, ( int )( ams_PARAM_DRAW_PRIMITIVE.sortZ * 100f ) );
    }

    // Token: 0x06000240 RID: 576 RVA: 0x00012D62 File Offset: 0x00010F62
    private static void _amDrawSortObject( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000241 RID: 577 RVA: 0x00012D69 File Offset: 0x00010F69
    private static AppMain.NNS_MATRIX amDrawGetWorldViewMatrix()
    {
        return AppMain._am_draw_world_view_matrix;
    }

    // Token: 0x06000242 RID: 578 RVA: 0x00012D70 File Offset: 0x00010F70
    private static void _amDrawSortPrimitive3D( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.NNS_MATRIX amDrawSortPrimitive3D_base_mtx = AppMain._amDrawSortPrimitive3D_base_mtx;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = (AppMain.AMS_PARAM_DRAW_PRIMITIVE)command.param;
        if ( ams_PARAM_DRAW_PRIMITIVE.texlist != null && ams_PARAM_DRAW_PRIMITIVE.texId != -1 )
        {
            AppMain.nnSetPrimitiveTexNum( ams_PARAM_DRAW_PRIMITIVE.texlist, ams_PARAM_DRAW_PRIMITIVE.texId );
            AppMain.nnSetPrimitiveTexState( 0, 0, 0, 0 );
        }
        AppMain.nnCopyMatrix( amDrawSortPrimitive3D_base_mtx, ams_PARAM_DRAW_PRIMITIVE.mtx );
        AppMain.nnMultiplyMatrix( amDrawSortPrimitive3D_base_mtx, AppMain.amDrawGetWorldViewMatrix(), amDrawSortPrimitive3D_base_mtx );
        AppMain.nnSetPrimitive3DMatrix( amDrawSortPrimitive3D_base_mtx );
        AppMain._amDrawSetPrimitive3DParam( command, drawflag );
        AppMain.nnBeginDrawPrimitive3D( ams_PARAM_DRAW_PRIMITIVE.format3D, ams_PARAM_DRAW_PRIMITIVE.ablend, 0, 0 );
        switch ( ams_PARAM_DRAW_PRIMITIVE.format3D )
        {
            case 2:
                AppMain.nnDrawPrimitive3D( ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPC3D, ams_PARAM_DRAW_PRIMITIVE.count );
                break;
            case 4:
                AppMain.nnDrawPrimitive3D( ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D, ams_PARAM_DRAW_PRIMITIVE.count );
                break;
        }
        AppMain.nnEndDrawPrimitive3D();
    }

    // Token: 0x06000243 RID: 579 RVA: 0x00012E44 File Offset: 0x00011044
    private static void _amDrawSortPrimitive2D( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = (AppMain.AMS_PARAM_DRAW_PRIMITIVE)command.param;
        AppMain.NNS_MATRIX amDrawSortPrimitive2D_mtx = AppMain._amDrawSortPrimitive2D_mtx;
        AppMain.nnMakeOrthoMatrix( amDrawSortPrimitive2D_mtx, 0f, 720f, 1080f, 0f, 1f, 3f );
        AppMain.amDrawSetProjection( amDrawSortPrimitive2D_mtx, 1 );
        if ( ams_PARAM_DRAW_PRIMITIVE.texlist != null && ams_PARAM_DRAW_PRIMITIVE.texId != -1 )
        {
            AppMain.nnSetPrimitiveTexNum( ams_PARAM_DRAW_PRIMITIVE.texlist, ams_PARAM_DRAW_PRIMITIVE.texId );
            AppMain.nnSetPrimitiveTexState( 0, 0, 0, 0 );
        }
        AppMain._amDrawSetPrimitive2DParam( command, drawflag );
        AppMain.nnBeginDrawPrimitive2D( ams_PARAM_DRAW_PRIMITIVE.format2D, ams_PARAM_DRAW_PRIMITIVE.ablend );
        switch ( ams_PARAM_DRAW_PRIMITIVE.format2D )
        {
            case 1:
                AppMain.nnDrawPrimitive2D( ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPC2D, ams_PARAM_DRAW_PRIMITIVE.count, ams_PARAM_DRAW_PRIMITIVE.zOffset );
                break;
            case 2:
                AppMain.nnDrawPrimitive2D( ams_PARAM_DRAW_PRIMITIVE.type, ams_PARAM_DRAW_PRIMITIVE.vtxPCT2D, ams_PARAM_DRAW_PRIMITIVE.count, ams_PARAM_DRAW_PRIMITIVE.zOffset );
                break;
        }
        AppMain.nnEndDrawPrimitive2D();
    }

    // Token: 0x06000244 RID: 580 RVA: 0x00012F2C File Offset: 0x0001112C
    private static void _amDrawSetDiffuse( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_DIFFUSE ams_DRAWSTATE_DIFFUSE = (AppMain.AMS_DRAWSTATE_DIFFUSE)command.param;
        AppMain.amDrawSetMaterialDiffuse( ams_DRAWSTATE_DIFFUSE.mode, ams_DRAWSTATE_DIFFUSE.r, ams_DRAWSTATE_DIFFUSE.g, ams_DRAWSTATE_DIFFUSE.b );
    }

    // Token: 0x06000245 RID: 581 RVA: 0x00012F64 File Offset: 0x00011164
    private static void _amDrawSetAmbient( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_AMBIENT ams_DRAWSTATE_AMBIENT = (AppMain.AMS_DRAWSTATE_AMBIENT)command.param;
        AppMain.amDrawSetMaterialAmbient( ams_DRAWSTATE_AMBIENT.mode, ams_DRAWSTATE_AMBIENT.r, ams_DRAWSTATE_AMBIENT.g, ams_DRAWSTATE_AMBIENT.b );
    }

    // Token: 0x06000246 RID: 582 RVA: 0x00012F9C File Offset: 0x0001119C
    private static void _amDrawSetAlpha( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_ALPHA ams_DRAWSTATE_ALPHA = (AppMain.AMS_DRAWSTATE_ALPHA)command.param;
        AppMain.amDrawSetMaterialAlpha( ams_DRAWSTATE_ALPHA.mode, ams_DRAWSTATE_ALPHA.alpha );
    }

    // Token: 0x06000247 RID: 583 RVA: 0x00012FC8 File Offset: 0x000111C8
    private static void _amDrawSetSpecular( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_SPECULAR ams_DRAWSTATE_SPECULAR = (AppMain.AMS_DRAWSTATE_SPECULAR)command.param;
        AppMain.amDrawSetMaterialSpecular( ams_DRAWSTATE_SPECULAR.mode, ams_DRAWSTATE_SPECULAR.r, ams_DRAWSTATE_SPECULAR.g, ams_DRAWSTATE_SPECULAR.b );
    }

    // Token: 0x06000248 RID: 584 RVA: 0x00012FFE File Offset: 0x000111FE
    private static void _amDrawSetEnvMap( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000249 RID: 585 RVA: 0x00013008 File Offset: 0x00011208
    private static void _amDrawSetBlend( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_BLEND ams_DRAWSTATE_BLEND = (AppMain.AMS_DRAWSTATE_BLEND)command.param;
        AppMain.amDrawSetMaterialBlendMode( ams_DRAWSTATE_BLEND.mode );
    }

    // Token: 0x0600024A RID: 586 RVA: 0x0001302C File Offset: 0x0001122C
    private static void _amDrawSetTexOffset( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_SET_TEXOFFSET ams_PARAM_SET_TEXOFFSET = (AppMain.AMS_PARAM_SET_TEXOFFSET)command.param;
        AppMain.amDrawSetMaterialTexOffset( ams_PARAM_SET_TEXOFFSET.slot, ams_PARAM_SET_TEXOFFSET.texoffset.mode, ams_PARAM_SET_TEXOFFSET.texoffset.u, ams_PARAM_SET_TEXOFFSET.texoffset.v );
    }

    // Token: 0x0600024B RID: 587 RVA: 0x00013074 File Offset: 0x00011274
    private static void _amDrawSetFog( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_FOG ams_DRAWSTATE_FOG = (AppMain.AMS_DRAWSTATE_FOG)command.param;
        AppMain.amDrawSetFog( ams_DRAWSTATE_FOG.flag );
    }

    // Token: 0x0600024C RID: 588 RVA: 0x00013098 File Offset: 0x00011298
    private static void _amDrawSetFogColor( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_FOG_COLOR ams_DRAWSTATE_FOG_COLOR = (AppMain.AMS_DRAWSTATE_FOG_COLOR)command.param;
        AppMain.amDrawSetFogColor( ams_DRAWSTATE_FOG_COLOR.r, ams_DRAWSTATE_FOG_COLOR.g, ams_DRAWSTATE_FOG_COLOR.b );
    }

    // Token: 0x0600024D RID: 589 RVA: 0x000130C8 File Offset: 0x000112C8
    private static void _amDrawSetFogRange( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_FOG_RANGE ams_DRAWSTATE_FOG_RANGE = (AppMain.AMS_DRAWSTATE_FOG_RANGE)command.param;
        AppMain.amDrawSetFogRange( ams_DRAWSTATE_FOG_RANGE.fnear, ams_DRAWSTATE_FOG_RANGE.ffar );
    }

    // Token: 0x0600024E RID: 590 RVA: 0x000130F4 File Offset: 0x000112F4
    private static void _amDrawSetZMode( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_DRAWSTATE_Z_MODE ams_DRAWSTATE_Z_MODE = (AppMain.AMS_DRAWSTATE_Z_MODE)command.param;
        AppMain.amDrawSetZMode( 0U != ams_DRAWSTATE_Z_MODE.compare, ams_DRAWSTATE_Z_MODE.func, 0U != ams_DRAWSTATE_Z_MODE.update );
    }

    // Token: 0x0600024F RID: 591 RVA: 0x00013130 File Offset: 0x00011330
    private static void _amDrawSetPrimitive3DParam( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = (AppMain.AMS_PARAM_DRAW_PRIMITIVE)command.param;
        if ( ams_PARAM_DRAW_PRIMITIVE.aTest != 0 )
        {
            AppMain.nnSetPrimitive3DAlphaFuncGL( 516U, 0.5f );
        }
        else
        {
            AppMain.nnSetPrimitive3DAlphaFuncGL( 519U, 0.5f );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.zMask != 0 )
        {
            AppMain.nnSetPrimitive3DDepthMaskGL( false );
        }
        else
        {
            AppMain.nnSetPrimitive3DDepthMaskGL( true );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.zTest != 0 )
        {
            AppMain.nnSetPrimitive3DDepthFuncGL( 515U );
        }
        else
        {
            AppMain.nnSetPrimitive3DDepthFuncGL( 519U );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.ablend != 0 && ams_PARAM_DRAW_PRIMITIVE.bldMode == 32774 )
        {
            uint bldDst = (uint)ams_PARAM_DRAW_PRIMITIVE.bldDst;
            if ( bldDst == 1U )
            {
                AppMain.nnSetPrimitiveBlend( 0 );
                return;
            }
            if ( bldDst == 771U )
            {
                AppMain.nnSetPrimitiveBlend( 1 );
                return;
            }
            AppMain.nnSetPrimitiveBlend( 1 );
        }
    }

    // Token: 0x06000250 RID: 592 RVA: 0x000131E4 File Offset: 0x000113E4
    private static void _amDrawSetPrimitive2DParam( AppMain.AMS_COMMAND_HEADER command, uint drawflag )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = (AppMain.AMS_PARAM_DRAW_PRIMITIVE)command.param;
        if ( ams_PARAM_DRAW_PRIMITIVE.aTest != 0 )
        {
            AppMain.nnSetPrimitive2DAlphaFuncGL( 516U, 0.5f );
        }
        else
        {
            AppMain.nnSetPrimitive2DAlphaFuncGL( 519U, 0.5f );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.zMask != 0 )
        {
            AppMain.nnSetPrimitive3DDepthMaskGL( false );
        }
        else
        {
            AppMain.nnSetPrimitive3DDepthMaskGL( true );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.zTest != 0 )
        {
            AppMain.nnSetPrimitive3DDepthFuncGL( 515U );
        }
        else
        {
            AppMain.nnSetPrimitive3DDepthFuncGL( 519U );
        }
        if ( ams_PARAM_DRAW_PRIMITIVE.ablend != 0 && ams_PARAM_DRAW_PRIMITIVE.bldMode == 32774 )
        {
            int bldDst = ams_PARAM_DRAW_PRIMITIVE.bldDst;
            if ( bldDst == 1 )
            {
                AppMain.nnSetPrimitiveBlend( 0 );
                return;
            }
            if ( bldDst == 771 )
            {
                AppMain.nnSetPrimitiveBlend( 1 );
                return;
            }
            AppMain.nnSetPrimitiveBlend( 1 );
        }
    }

    // Token: 0x06000251 RID: 593 RVA: 0x00013297 File Offset: 0x00011497
    private static void _amDrawRegistNop( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        regist.command_id = 0;
    }

    // Token: 0x06000252 RID: 594 RVA: 0x000132A8 File Offset: 0x000114A8
    private static void _amDrawLoadTexture( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.AMS_PARAM_LOAD_TEXTURE ams_PARAM_LOAD_TEXTURE = (AppMain.AMS_PARAM_LOAD_TEXTURE)regist.param;
        OpenGL.glGenTexture( out ams_PARAM_LOAD_TEXTURE.pTexInfo.TexName );
        OpenGL.glBindTexture( 3553U, ams_PARAM_LOAD_TEXTURE.pTexInfo.TexName );
        OpenGL.mppglTexImage2D( ams_PARAM_LOAD_TEXTURE.tex );
        AppMain._amSetTextureAttribute( ams_PARAM_LOAD_TEXTURE );
        ams_PARAM_LOAD_TEXTURE.buf_delete = null;
        regist.command_id = 0;
    }

    // Token: 0x06000253 RID: 595 RVA: 0x00013305 File Offset: 0x00011505
    private static void _amSetTextureAttribute( AppMain.AMS_PARAM_LOAD_TEXTURE param )
    {
        param.pTexInfo.Bank = param.bank;
        param.pTexInfo.GlobalIndex = param.globalIndex;
        param.pTexInfo.Flag = 0U;
    }

    // Token: 0x06000254 RID: 596 RVA: 0x00013338 File Offset: 0x00011538
    private static void _amDrawReleaseTexture( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.AMS_PARAM_RELEASE_TEXTURE ams_PARAM_RELEASE_TEXTURE = (AppMain.AMS_PARAM_RELEASE_TEXTURE)regist.param;
        int nTex = ams_PARAM_RELEASE_TEXTURE.texlist.nTex;
        AppMain.ArrayPointer<AppMain.NNS_TEXINFO> pointer = ams_PARAM_RELEASE_TEXTURE.texlist.pTexInfoList;
        int i = nTex - 1;
        pointer += nTex - 1;
        while ( i >= 0 )
        {
            if ( ( ~pointer ).TexName != 0U )
            {
                OpenGL.glDeleteTextures( 1, new uint[]
                {
                    (~pointer).TexName
                } );
            }
            i--;
            pointer = --pointer;
        }
        ams_PARAM_RELEASE_TEXTURE.texlist.nTex = -1;
        ams_PARAM_RELEASE_TEXTURE.texlist.pTexInfoList = null;
        ams_PARAM_RELEASE_TEXTURE.texlist = null;
        regist.command_id = 0;
    }

    // Token: 0x06000255 RID: 597 RVA: 0x000133E0 File Offset: 0x000115E0
    private static void _amDrawVertexBufferObject( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.AMS_PARAM_VERTEX_BUFFER_OBJECT ams_PARAM_VERTEX_BUFFER_OBJECT = (AppMain.AMS_PARAM_VERTEX_BUFFER_OBJECT)regist.param;
        AppMain.nnBindBufferObjectGL( ams_PARAM_VERTEX_BUFFER_OBJECT.obj, ams_PARAM_VERTEX_BUFFER_OBJECT.srcobj, ams_PARAM_VERTEX_BUFFER_OBJECT.bindflag );
        regist.command_id = 0;
    }

    // Token: 0x06000256 RID: 598 RVA: 0x00013418 File Offset: 0x00011618
    private static void _amDrawDeleteVertexObject( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.AMS_PARAM_DELETE_VERTEX_OBJECT ams_PARAM_DELETE_VERTEX_OBJECT = (AppMain.AMS_PARAM_DELETE_VERTEX_OBJECT)regist.param;
        AppMain.nnDeleteBufferObjectGL( ams_PARAM_DELETE_VERTEX_OBJECT.obj );
        regist.command_id = 0;
    }

    // Token: 0x06000257 RID: 599 RVA: 0x00013443 File Offset: 0x00011643
    private static void _amDrawLoadShaderObject( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        regist.command_id = 0;
    }

    // Token: 0x06000258 RID: 600 RVA: 0x00013451 File Offset: 0x00011651
    private static void _amDrawReleaseStdShader( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        regist.command_id = 0;
    }

    // Token: 0x06000259 RID: 601 RVA: 0x0001345F File Offset: 0x0001165F
    private static void _amDrawLoadShader( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        regist.command_id = 0;
    }

    // Token: 0x0600025A RID: 602 RVA: 0x0001346D File Offset: 0x0001166D
    private static void _amDrawBuildShader( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        regist.command_id = 0;
    }

    // Token: 0x0600025B RID: 603 RVA: 0x0001347B File Offset: 0x0001167B
    private static void _amDrawCreateShader( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        regist.command_id = 0;
    }

    // Token: 0x0600025C RID: 604 RVA: 0x00013489 File Offset: 0x00011689
    private static void _amDrawReleaseShader( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600025D RID: 605 RVA: 0x00013490 File Offset: 0x00011690
    private static void _amDrawLoadTextureImage( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_PARAM_LOAD_TEXTURE_IMAGE ams_PARAM_LOAD_TEXTURE_IMAGE = (AppMain.AMS_PARAM_LOAD_TEXTURE_IMAGE)regist.param;
        regist.command_id = 0;
    }

    // Token: 0x0600025E RID: 606 RVA: 0x000134AC File Offset: 0x000116AC
    private static void _amDrawReleaseTextureImage( AppMain.AMS_REGISTLIST regist )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_PARAM_RELEASE_TEXTURE_IMAGE ams_PARAM_RELEASE_TEXTURE_IMAGE = (AppMain.AMS_PARAM_RELEASE_TEXTURE_IMAGE)regist.param;
        if ( ams_PARAM_RELEASE_TEXTURE_IMAGE.texture != null )
        {
            ams_PARAM_RELEASE_TEXTURE_IMAGE.texture.Dispose();
            ams_PARAM_RELEASE_TEXTURE_IMAGE.texture = null;
        }
        regist.command_id = 0;
    }
}
