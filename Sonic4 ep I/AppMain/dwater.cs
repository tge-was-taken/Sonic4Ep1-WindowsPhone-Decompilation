using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x0600118D RID: 4493 RVA: 0x00099C4C File Offset: 0x00097E4C
    private static int dwaterInit()
    {
        if ( AppMain._dmap_water == null )
        {
            AppMain._dmap_water = new AppMain.DMAP_WATER();
        }
        AppMain._dmap_water.repeat_u = 1f;
        AppMain._dmap_water.repeat_v = 1f;
        AppMain._dmap_water.speed_u = 0.001f;
        AppMain._dmap_water.speed_v = -0.001f;
        AppMain._dmap_water.speed_surface = 0.001f;
        AppMain._dmap_water.regist_index = -1;
        AppMain._dmap_water.repeat_pos_x = 280f;
        AppMain.dwaterSetColor( 0.65f, 1f, 0.75f );
        return AppMain._dmap_water.regist_index;
    }

    // Token: 0x0600118E RID: 4494 RVA: 0x00099CF0 File Offset: 0x00097EF0
    private static void dwaterExit()
    {
        if ( AppMain._dmap_water != null )
        {
            for ( int i = 0; i < 2; i++ )
            {
                if ( AppMain._dmap_water._object[i]._object != null )
                {
                    AppMain._dmap_water._object[i]._object = null;
                }
                if ( AppMain._dmap_water._object[i].texlistbuf != null )
                {
                    AppMain._dmap_water._object[i].texlistbuf = null;
                }
                if ( AppMain._dmap_water._object[i].motion != null )
                {
                    AppMain.amMotionDelete( AppMain._dmap_water._object[i].motion );
                }
            }
        }
        AppMain._dmap_water = null;
    }

    // Token: 0x0600118F RID: 4495 RVA: 0x00099D89 File Offset: 0x00097F89
    private static void dwaterSetObjectAMB( AppMain.AMS_AMB_HEADER amb_obj, AppMain.AMS_AMB_HEADER amb_tex )
    {
        AppMain._dmap_water.amb_object = amb_obj;
        AppMain._dmap_water.amb_texture = amb_tex;
    }

    // Token: 0x06001190 RID: 4496 RVA: 0x00099DA4 File Offset: 0x00097FA4
    private static int dwaterLoadObject( uint objflag )
    {
        int result = 1;
        AppMain.ArrayPointer<AppMain.DMAP_WATER_OBJ> pointer = new AppMain.ArrayPointer<AppMain.DMAP_WATER_OBJ>(AppMain._dmap_water._object);
        int i;
        if ( AppMain._dmap_water.regist_index != -1 )
        {
            if ( !AppMain.amDrawIsRegistComplete( AppMain._dmap_water.regist_index ) )
            {
                return 0;
            }
            AppMain._dmap_water.regist_index = -1;
            if ( ( ~pointer )._object != null )
            {
                i = 0;
                while ( i < 2 )
                {
                    object obj = AppMain._dmap_water.amb_object.buf[2 + i];
                    ( ~pointer ).motion = AppMain.amMotionCreate( ( ~pointer )._object );
                    AppMain.amMotionMaterialRegistFile( ( ~pointer ).motion, 0, obj );
                    AppMain.amMotionMaterialSet( ( ~pointer ).motion, 0 );
                    AppMain.amMotionMaterialSetFrame( ( ~pointer ).motion, AppMain.amMotionMaterialGetStartFrame( ( ~pointer ).motion, 0 ) );
                    i++;
                    pointer = ++pointer;
                }
                return 1;
            }
        }
        i = 0;
        while ( i < 2 )
        {
            object obj = AppMain.amBindGet(AppMain._dmap_water.amb_object, i);
            AppMain._dmap_water.regist_index = AppMain.amObjectLoad( out ( ~pointer )._object, out ( ~pointer ).texlist, out ( ~pointer ).texlistbuf, obj, objflag, null, AppMain._dmap_water.amb_texture );
            result = 0;
            i++;
            pointer = ++pointer;
        }
        return result;
    }

    // Token: 0x06001191 RID: 4497 RVA: 0x00099EF1 File Offset: 0x000980F1
    private static int dwaterLoadTexture( object water_image, int water_size, object color_image, int color_size )
    {
        return 0;
    }

    // Token: 0x06001192 RID: 4498 RVA: 0x00099EF4 File Offset: 0x000980F4
    private static int dwaterRelease()
    {
        int result = -1;
        if ( AppMain._dmap_water != null )
        {
            for ( int i = 0; i < 2; i++ )
            {
                if ( AppMain._dmap_water._object[i]._object != null )
                {
                    result = AppMain.amObjectRelease( AppMain._dmap_water._object[i]._object, AppMain._dmap_water._object[i].texlist );
                }
            }
        }
        return result;
    }

    // Token: 0x06001193 RID: 4499 RVA: 0x00099F52 File Offset: 0x00098152
    private static void dwaterSetColor( float r, float g, float b )
    {
    }

    // Token: 0x06001194 RID: 4500 RVA: 0x00099F54 File Offset: 0x00098154
    private static void dwaterUpdate( float speed, float pos_x, float pos_y, float dy, int rot_z, float scale )
    {
        float num = 0.006666667f;
        AppMain._dmap_water.speed_surface += 0.0005f;
        if ( AppMain._dmap_water.speed_surface > 1f )
        {
            AppMain._dmap_water.speed_surface -= 1f;
        }
        AppMain._dmap_water.pos_x = pos_x;
        AppMain._dmap_water.pos_y = pos_y;
        AppMain._dmap_water.pos_dy = dy;
        AppMain._dmap_water.rot_z = rot_z;
        AppMain._dmap_water.scale = scale;
        float num2 = AppMain._dmap_water.ofst_u + AppMain._dmap_water.speed_u * speed;
        if ( num2 >= 0f )
        {
            num2 -= AppMain.floorf( num2 );
        }
        else
        {
            num2 = 1f - ( -num2 - AppMain.floorf( -num2 ) );
        }
        AppMain._dmap_water.ofst_u = num2;
        num2 = AppMain._dmap_water.ofst_v + AppMain._dmap_water.speed_v * speed;
        if ( num2 >= 0f )
        {
            num2 -= AppMain.floorf( num2 );
        }
        else
        {
            num2 = 1f - ( -num2 - AppMain.floorf( -num2 ) );
        }
        AppMain._dmap_water.ofst_v = num2;
        float num3 = num * AppMain._dmap_water.repeat_u / 1.15f;
        num2 = AppMain._dmap_water.ofst_u + pos_x * num3;
        if ( num2 >= 0f )
        {
            num2 -= AppMain.floorf( num2 );
        }
        else
        {
            num2 = 1f - ( -num2 - AppMain.floorf( -num2 ) );
        }
        AppMain._dmap_water.draw_u = num2;
        AppMain._dmap_water.draw_v = AppMain._dmap_water.ofst_v;
        AppMain.ArrayPointer<AppMain.DMAP_WATER_OBJ> pointer = new AppMain.ArrayPointer<AppMain.DMAP_WATER_OBJ>(AppMain._dmap_water._object);
        int i = 0;
        while ( i < 2 )
        {
            AppMain.AMS_MOTION motion = (~pointer).motion;
            num2 = ( ~pointer ).frame + speed;
            float num4 = AppMain.amMotionMaterialGetStartFrame(motion, 0);
            float num5 = AppMain.amMotionMaterialGetEndFrame(motion, 0);
            while ( num2 >= num5 )
            {
                num2 = num4 + ( num2 - num5 );
            }
            ( ~pointer ).frame = num2;
            i++;
            pointer = ++pointer;
        }
    }

    // Token: 0x06001195 RID: 4501 RVA: 0x0009A144 File Offset: 0x00098344
    private static void dwaterGetParam( AppMain.DMAP_PARAM_WATER param )
    {
        param.frame[0] = AppMain._dmap_water._object[0].frame;
        param.frame[1] = AppMain._dmap_water._object[1].frame;
        param.draw_u = AppMain._dmap_water.draw_u;
        param.draw_v = AppMain._dmap_water.draw_v;
        param.scale = AppMain._dmap_water.scale;
        param.pos_x = AppMain._dmap_water.pos_x;
        param.pos_y = AppMain._dmap_water.pos_y;
        param.pos_dy = AppMain._dmap_water.pos_dy;
        param.repeat_u = AppMain._dmap_water.repeat_u;
        param.repeat_v = AppMain._dmap_water.repeat_v;
        param.rot_z = AppMain._dmap_water.rot_z;
        param.color = AppMain._dmap_water.color;
    }

    // Token: 0x06001196 RID: 4502 RVA: 0x0009A224 File Offset: 0x00098424
    private static void dwaterSetParam()
    {
        AppMain.DMAP_PARAM_WATER dmap_PARAM_WATER = AppMain.amDrawAlloc_DMAP_PARAM_WATER();
        AppMain.dwaterGetParam( dmap_PARAM_WATER );
        AppMain.amDrawMakeTask( new AppMain.TaskProc( AppMain._dwaterSetParam ), 0, dmap_PARAM_WATER );
    }

    // Token: 0x06001197 RID: 4503 RVA: 0x0009A250 File Offset: 0x00098450
    private static void dwaterDrawReflection( uint state, uint drawflag )
    {
        AppMain.amMatrixPush();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.DMAP_WATER_OBJ dmap_WATER_OBJ = AppMain._dmap_water._object[1];
        AppMain.AMS_MOTION motion = dmap_WATER_OBJ.motion;
        AppMain.amMotionMaterialSetFrame( motion, AppMain._dmap_water._object[1].frame );
        AppMain.amMotionMaterialCalc( motion );
        float num = AppMain._dmap_water.pos_x / (AppMain._dmap_water.repeat_pos_x * AppMain._dmap_water.scale);
        num = AppMain.floorf( num - 0.5f ) * ( AppMain._dmap_water.repeat_pos_x * AppMain._dmap_water.scale );
        float y = AppMain._dmap_water.pos_y + AppMain._dmap_water.pos_dy;
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.nnMakeTranslateMatrix( nns_MATRIX, num, y, AppMain.FX_FX32_TO_F32( -1179648 ) );
            AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, AppMain._dmap_water.scale, AppMain._dmap_water.scale, 1f );
            AppMain.ObjDraw3DNNMotionMaterialMotion( motion, dmap_WATER_OBJ.texlist, drawflag, 0U, null, null, state, null, null, null, null, null, 1U );
            num += AppMain._dmap_water.repeat_pos_x * AppMain._dmap_water.scale;
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x06001198 RID: 4504 RVA: 0x0009A370 File Offset: 0x00098570
    private static void dwaterDrawSurface( uint state, uint drawflag )
    {
        AppMain.amMatrixPush();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.amMatrixGetCurrent();
        AppMain.DMAP_WATER_OBJ dmap_WATER_OBJ = AppMain._dmap_water._object[0];
        AppMain.AMS_MOTION motion = dmap_WATER_OBJ.motion;
        AppMain.amMotionMaterialSetFrame( motion, AppMain._dmap_water._object[0].frame );
        AppMain.amMotionMaterialCalc( motion );
        float num = AppMain._dmap_water.pos_x / (AppMain._dmap_water.repeat_pos_x * AppMain._dmap_water.scale);
        num = AppMain.floorf( num - 0.5f ) * ( AppMain._dmap_water.repeat_pos_x * AppMain._dmap_water.scale );
        float y = AppMain._dmap_water.pos_y + AppMain._dmap_water.pos_dy;
        for ( int i = 0; i < 2; i++ )
        {
            AppMain.nnMakeTranslateMatrix( nns_MATRIX, num, y, AppMain.FX_FX32_TO_F32( 917504 ) );
            AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, AppMain._dmap_water.scale, AppMain._dmap_water.scale * 2f, 1f );
            AppMain.ObjDraw3DNNMotionMaterialMotion( motion, dmap_WATER_OBJ.texlist, drawflag, 0U, null, null, state, null, null, null, null, null, 1U );
            num += AppMain._dmap_water.repeat_pos_x * AppMain._dmap_water.scale;
        }
        AppMain.amMatrixPop();
    }

    // Token: 0x06001199 RID: 4505 RVA: 0x0009A494 File Offset: 0x00098694
    private static void dwaterDrawWater( AppMain.AMS_RENDER_TARGET texture )
    {
        AppMain.DMAP_PARAM_WATER draw_param = AppMain._dmap_water.draw_param;
        AppMain.amDrawPushState();
        AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(0f, draw_param.pos_dy, -0.5f);
        AppMain.nnTransformVector( nns_VECTOR, AppMain.amDrawGetProjectionMatrix(), nns_VECTOR );
        float draw_u = draw_param.draw_u;
        float draw_v = draw_param.draw_v;
        float repeat_u = draw_param.repeat_u;
        float scale = draw_param.scale;
        float repeat_v = draw_param.repeat_v;
        float scale2 = draw_param.scale;
        float y = nns_VECTOR.y;
        int rot_z = draw_param.rot_z;
        uint color = draw_param.color;
        AppMain.amDrawPopState();
    }

    // Token: 0x0600119A RID: 4506 RVA: 0x0009A518 File Offset: 0x00098718
    private static void _dwaterSetParam( AppMain.AMS_TCB tcbp )
    {
        AppMain.DMAP_PARAM_WATER draw_param = (AppMain.DMAP_PARAM_WATER)AppMain.amTaskGetWork(tcbp);
        AppMain._dmap_water.draw_param = draw_param;
    }
}