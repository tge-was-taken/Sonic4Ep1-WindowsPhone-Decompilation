using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.IO;
using mpp;

public partial class AppMain
{
    // Token: 0x0200037A RID: 890
    private enum AME_IPHONE_DISPLAY_ORIENTATION
    {
        // Token: 0x04006056 RID: 24662
        AME_IPHONE_DISPLAY_ORIENTATION_NORMAL,
        // Token: 0x04006057 RID: 24663
        AME_IPHONE_DISPLAY_ORIENTATION_RIGHT,
        // Token: 0x04006058 RID: 24664
        AME_IPHONE_DISPLAY_ORIENTATION_HORIZON,
        // Token: 0x04006059 RID: 24665
        AME_IPHONE_DISPLAY_ORIENTATION_LEFT,
        // Token: 0x0400605A RID: 24666
        AME_IPHONE_DISPLAY_ORIENTATION_NUM
    }

    // Token: 0x0200037B RID: 891
    private enum AME_IPHONE_TP_TOUCH
    {
        // Token: 0x0400605C RID: 24668
        AME_IPHONE_TP_TOUCH_OFF,
        // Token: 0x0400605D RID: 24669
        AME_IPHONE_TP_TOUCH_ON,
        // Token: 0x0400605E RID: 24670
        AME_IPHONE_TP_TOUCH_NUM
    }

    // Token: 0x0200037C RID: 892
    private enum AME_IPHONE_TP_VALIDITY
    {
        // Token: 0x04006060 RID: 24672
        AME_IPHONE_TP_VALIDITY_INVALID,
        // Token: 0x04006061 RID: 24673
        AME_IPHONE_TP_VALIDITY_VALID,
        // Token: 0x04006062 RID: 24674
        AME_IPHONE_TP_VALIDITY_NUM
    }

    // Token: 0x0200037D RID: 893
    private class AMS_IPHONE_TP_DATA
    {
        // Token: 0x060026C2 RID: 9922 RVA: 0x00150338 File Offset: 0x0014E538
        internal void Assign( AppMain.AMS_IPHONE_TP_DATA data )
        {
            this.touch = data.touch;
            this.validity = data.validity;
            this.x = data.x;
            this.y = data.y;
        }

        // Token: 0x04006063 RID: 24675
        public int id;

        // Token: 0x04006064 RID: 24676
        public ushort touch;

        // Token: 0x04006065 RID: 24677
        public ushort validity;

        // Token: 0x04006066 RID: 24678
        public ushort x;

        // Token: 0x04006067 RID: 24679
        public ushort y;
    }

    // Token: 0x0200037E RID: 894
    private class AMS_IPHONE_ACCEL_DATA
    {
        // Token: 0x04006068 RID: 24680
        public readonly AppMain.NNS_VECTOR core = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04006069 RID: 24681
        public readonly AppMain.NNS_VECTOR sensor = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400606A RID: 24682
        public int rot_x;

        // Token: 0x0400606B RID: 24683
        public int rot_y;

        // Token: 0x0400606C RID: 24684
        public int rot_z;
    }

    // Token: 0x0200037F RID: 895
    private class AMS_IPHONE_TP_CTRL_DATA
    {
        // Token: 0x0400606D RID: 24685
        public AppMain.AMS_IPHONE_TP_DATA tpdata = new AppMain.AMS_IPHONE_TP_DATA();
    }

    // Token: 0x06001852 RID: 6226 RVA: 0x000DB300 File Offset: 0x000D9500
    public static void amIPhoneAccelerate( ref Vector3 accel )
    {
        AppMain.NNS_VECTOR core = AppMain._am_iphone_accel_data.core;
        AppMain.NNS_VECTOR sensor = AppMain._am_iphone_accel_data.sensor;
        core.x = accel.X;
        core.y = accel.Y;
        core.z = accel.Z;
        sensor.x = -core.y;
        sensor.y = core.x;
        sensor.z = core.z;
        AppMain._am_iphone_accel_data.rot_x = AppMain.nnArcTan2( ( double )( -( double )sensor.z ), ( double )( -( double )sensor.y ) );
        AppMain._am_iphone_accel_data.rot_z = AppMain.nnArcTan2( ( double )sensor.x, ( double )( -( double )sensor.y ) );
    }

    // Token: 0x06001853 RID: 6227 RVA: 0x000DB3A9 File Offset: 0x000D95A9
    private static void amIPhoneRequestTouch( AppMain.AMS_IPHONE_TP_DATA DispData, int TouchIndex )
    {
        if ( DispData != null )
        {
            DispData.Assign( AppMain._am_iphone_tp_ctrl_data[TouchIndex].tpdata );
        }
    }

    // Token: 0x06001854 RID: 6228 RVA: 0x000DB3C0 File Offset: 0x000D95C0
    public static void setBackKeyRequest( bool val )
    {
        AppMain._am_is_back_key_pressed = val;
    }

    // Token: 0x06001855 RID: 6229 RVA: 0x000DB3C8 File Offset: 0x000D95C8
    public static bool isBackKeyPressed()
    {
        return AppMain._am_is_back_key_pressed;
    }

    // Token: 0x06001856 RID: 6230 RVA: 0x000DB3CF File Offset: 0x000D95CF
    public static void amKeyGetData()
    {
        AppMain._am_is_back_key_pressed = AppMain.back_key_is_pressed;
        AppMain.back_key_is_pressed = false;
    }

    // Token: 0x06001857 RID: 6231 RVA: 0x000DB3E4 File Offset: 0x000D95E4
    static bool wasPressed = false;
    public static void onTouchEvents()
    {
        // PATCH
        //TouchCollection state = TouchPanel.GetState();
        var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        var state = new List<TouchLocation>();

        state.Add( new TouchLocation( 0, mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released ?
            ( wasPressed ? TouchLocationState.Released : TouchLocationState.Moved ) : TouchLocationState.Pressed,
            new Vector2( mouseState.X, mouseState.Y ), TouchLocationState.Invalid, new Vector2() ) );

        wasPressed = mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;


        for ( int i = 0; i < 4; i++ )
        {
            AppMain.touchMarked[i] = false;
        }
        for ( int j = 0; j < 4; j++ )
        {
            int id = 0;
            TouchLocationState touchLocationState;
            if ( j >= state.Count )
            {
                touchLocationState = TouchLocationState.Invalid;
                AppMain.posVector.X = -1f;
                AppMain.posVector.Y = -1f;
                int num = 0;
                while ( num < 4 && AppMain.touchMarked[num] )
                {
                    num++;
                }
                int num2 = num;
                AppMain.touchMarked[num2] = true;
            }
            else
            {
                TouchLocation touchLocation = state[j];
                float x = touchLocation.Position.X;
                float y = touchLocation.Position.Y;
                AppMain.screen2real( ref x, ref y );
                AppMain.posVector.X = x;
                AppMain.posVector.Y = y;
                touchLocationState = touchLocation.State;
                id = touchLocation.Id;
                int num2 = AppMain.amFindTouchIndex(id);
                AppMain.touchMarked[num2] = true;
            }
            switch ( touchLocationState )
            {
                case TouchLocationState.Invalid:
                    AppMain.amIPhoneTouchCanceled( j );
                    break;
                case TouchLocationState.Released:
                    AppMain.amIPhoneTouchEnded( j );
                    break;
                case TouchLocationState.Pressed:
                    AppMain.amIPhoneTouchBegan( ref AppMain.posVector, j, id );
                    break;
                case TouchLocationState.Moved:
                    AppMain.amIPhoneTouchMoved( ref AppMain.posVector, j, id );
                    break;
            }
        }
    }

    // Token: 0x06001858 RID: 6232 RVA: 0x000DB528 File Offset: 0x000D9728
    private static void screen2real( ref float X, ref float Y )
    {
        Y *= 1.05f;
        Y += 16f;
    }

    // Token: 0x06001859 RID: 6233 RVA: 0x000DB540 File Offset: 0x000D9740
    private static int amFindTouchIndex( int id )
    {
        for ( int i = 0; i < 4; i++ )
        {
            if ( AppMain._am_iphone_tp_ctrl_data[i].tpdata.id == id )
            {
                return i;
            }
        }
        for ( int j = 0; j < 4; j++ )
        {
            if ( !AppMain.touchMarked[j] )
            {
                return j;
            }
        }
        return 0;
    }

    // Token: 0x0600185A RID: 6234 RVA: 0x000DB588 File Offset: 0x000D9788
    private static void amIPhoneTouchBegan( ref Vector2 touch, int i, int id )
    {
        AppMain.AMS_IPHONE_TP_DATA tpdata = AppMain._am_iphone_tp_ctrl_data[i].tpdata;
        tpdata.x = ( ushort )touch.X;
        tpdata.y = ( ushort )touch.Y;
        tpdata.id = id;
        tpdata.touch = 1;
        tpdata.validity = 1;
    }

    // Token: 0x0600185B RID: 6235 RVA: 0x000DB5D4 File Offset: 0x000D97D4
    private static void amIPhoneTouchMoved( ref Vector2 touch, int i, int id )
    {
        AppMain.AMS_IPHONE_TP_DATA tpdata = AppMain._am_iphone_tp_ctrl_data[i].tpdata;
        tpdata.x = ( ushort )touch.X;
        tpdata.y = ( ushort )touch.Y;
        tpdata.id = id;
        tpdata.touch = 1;
        tpdata.validity = 1;
    }

    // Token: 0x0600185C RID: 6236 RVA: 0x000DB620 File Offset: 0x000D9820
    private static void amIPhoneTouchCanceled()
    {
        for ( int i = 0; i < 4; i++ )
        {
            AppMain._am_iphone_tp_ctrl_data[i].tpdata.touch = 0;
            AppMain._am_iphone_tp_ctrl_data[i].tpdata.validity = 0;
        }
    }

    // Token: 0x0600185D RID: 6237 RVA: 0x000DB65D File Offset: 0x000D985D
    private static void amIPhoneTouchCanceled( int i )
    {
        AppMain._am_iphone_tp_ctrl_data[i].tpdata.touch = 0;
        AppMain._am_iphone_tp_ctrl_data[i].tpdata.validity = 0;
    }

    // Token: 0x0600185E RID: 6238 RVA: 0x000DB683 File Offset: 0x000D9883
    private static void amIPhoneTouchEnded( int i )
    {
        AppMain._am_iphone_tp_ctrl_data[i].tpdata.touch = 0;
    }

    // Token: 0x06001543 RID: 5443 RVA: 0x000B90C8 File Offset: 0x000B72C8
    public void amIPhoneInitNN()
    {
        OpenGL.init( AppMain.m_game, AppMain.m_graphicsDevice );
        OpenGL.glViewport( 0, 0, 480, 288 );
        int num = 480;
        int num2 = 320;
        AppMain.amRenderInit();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        new AppMain.NNS_VECTOR( 0f, 0f, -1f );
        new AppMain.NNS_RGBA( 1f, 1f, 1f, 1f );
        AppMain.NNS_CONFIG_GL config;
        config.WindowWidth = num;
        config.WindowHeight = num2;
        this.nnConfigureSystemGL( config );
        AppMain.nnMakePerspectiveMatrix( nns_MATRIX, AppMain.NNM_DEGtoA32( 45f ), ( float )num2 / ( float )num, 1f, 10000f );
        AppMain._am_draw_video.draw_aspect = ( float )num2 / ( float )num;
        AppMain.nnSetProjection( nns_MATRIX, 0 );
        AppMain._am_draw_video.draw_width = ( float )num;
        AppMain._am_draw_video.draw_height = ( float )num2;
        AppMain._am_draw_video.disp_width = ( float )num;
        AppMain._am_draw_video.disp_height = ( float )num2;
        AppMain._am_draw_video.width_2d = ( float )num;
        AppMain._am_draw_video.height_2d = ( float )num2;
        AppMain._am_draw_video.scale_x_2d = 1f;
        AppMain._am_draw_video.scale_y_2d = 1f;
        AppMain._am_draw_video.base_x_2d = 0f;
        AppMain._am_draw_video.base_y_2d = 0f;
        AppMain._am_draw_video.wide_screen = true;
        AppMain._am_draw_video.refresh_rate = 60f;
        AppMain.amRenderInit();
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06001544 RID: 5444 RVA: 0x000B9230 File Offset: 0x000B7430
    public static void amIPhoneExitNN()
    {
    }

    // Token: 0x06001545 RID: 5445 RVA: 0x000B9232 File Offset: 0x000B7432
    public static void amIPhoneSetTextureAttribute( AppMain.AMS_PARAM_LOAD_TEXTURE param )
    {
    }

    // Token: 0x06001546 RID: 5446 RVA: 0x000B9234 File Offset: 0x000B7434
    public static bool IsGLExtensionSupported( string extension )
    {
        return true;
    }
}
