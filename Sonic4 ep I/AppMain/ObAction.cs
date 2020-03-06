using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600194A RID: 6474 RVA: 0x000E49A8 File Offset: 0x000E2BA8
    private static void ObjAction3dNNModelLoad( AppMain.OBS_ACTION3D_NN_WORK obj_3d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, string filename_tex, AppMain.AMS_AMB_HEADER amb_tex, uint drawflag )
    {
        object obj = null;
        string filepath = null;
        obj_3d.command_state = 0U;
        obj_3d.marge = 0f;
        obj_3d.per = 1f;
        obj_3d.use_light_flag = AppMain.g_obj.def_user_light_flag;
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx_r );
        for ( int i = 0; i < 2; i++ )
        {
            obj_3d.speed[i] = 1f;
        }
        obj_3d.mat_speed = 1f;
        obj_3d.blend_spd = 0.25f;
        obj_3d.drawflag = drawflag;
        obj_3d.draw_state.Assign( AppMain.g_obj_draw_3dnn_draw_state );
        if ( archive != null )
        {
            obj_3d.flag |= 65536U;
        }
        if ( filename != null && filename != "" )
        {
            obj = AppMain.ObjDataLoad( data_work, filename, archive );
            if ( archive != null && obj == null )
            {
                obj_3d.flag &= 4294901759U;
                obj = AppMain.ObjDataLoad( data_work, filename, null );
            }
        }
        else if ( archive != null )
        {
            obj = AppMain.ObjDataLoadAmbIndex( data_work, index, archive );
            if ( obj == null )
            {
                obj_3d.flag &= 4294901759U;
            }
        }
        else if ( data_work != null )
        {
            obj = AppMain.ObjDataGetInc( data_work );
        }
        if ( obj == null )
        {
            return;
        }
        obj_3d.model = obj;
        if ( data_work != null )
        {
            obj_3d.model_data_work = data_work;
        }
        if ( filename_tex != null && filename_tex != "" )
        {
            AppMain.sFile = filename_tex;
            filepath = AppMain.sFile;
        }
        else
        {
            AppMain.sFile = "";
        }
        obj_3d.reg_index = AppMain.amObjectLoad( out obj_3d._object, out obj_3d.texlist, out obj_3d.texlistbuf, obj, drawflag | AppMain.g_obj.load_drawflag, filepath, amb_tex );
        if ( AppMain.obj_load_initial_set_flag )
        {
            AppMain.OBS_LOAD_INITIAL_WORK obs_LOAD_INITIAL_WORK = AppMain.obj_load_initial_work;
            if ( obs_LOAD_INITIAL_WORK.obj_num < 255 )
            {
                obs_LOAD_INITIAL_WORK.obj_3d[obs_LOAD_INITIAL_WORK.obj_num] = obj_3d;
                obs_LOAD_INITIAL_WORK.obj_num++;
            }
        }
        obj_3d.flag |= 2147483648U;
        obj_3d.flag &= 3221225471U;
    }

    // Token: 0x0600194B RID: 6475 RVA: 0x000E4B90 File Offset: 0x000E2D90
    private static void ObjCopyAction3dNNModel( AppMain.OBS_ACTION3D_NN_WORK src_obj_3d, AppMain.OBS_ACTION3D_NN_WORK dest_obj_3d )
    {
        dest_obj_3d._object = src_obj_3d._object;
        dest_obj_3d.texlist = src_obj_3d.texlist;
        dest_obj_3d.texlistbuf = src_obj_3d.texlistbuf;
        dest_obj_3d.model = src_obj_3d.model;
        dest_obj_3d.model_data_work = src_obj_3d.model_data_work;
        dest_obj_3d.command_state = src_obj_3d.command_state;
        dest_obj_3d.flag = src_obj_3d.flag;
        dest_obj_3d.marge = 0f;
        dest_obj_3d.per = 1f;
        dest_obj_3d.use_light_flag = src_obj_3d.use_light_flag;
        for ( int i = 0; i < 2; i++ )
        {
            dest_obj_3d.speed[i] = 1f;
        }
        dest_obj_3d.mat_speed = 1f;
        AppMain.nnMakeUnitMatrix( dest_obj_3d.user_obj_mtx );
        AppMain.nnMakeUnitMatrix( dest_obj_3d.user_obj_mtx_r );
        dest_obj_3d.blend_spd = 0.25f;
        dest_obj_3d.sub_obj_type = src_obj_3d.sub_obj_type;
        dest_obj_3d.drawflag = src_obj_3d.drawflag;
        dest_obj_3d.draw_state.Assign( AppMain.g_obj_draw_3dnn_draw_state );
        dest_obj_3d.reg_index = -1;
    }

    // Token: 0x0600194C RID: 6476 RVA: 0x000E4C88 File Offset: 0x000E2E88
    private static void ObjObjectCopyAction3dNNModel( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_NN_WORK src_obj_3d, AppMain.OBS_ACTION3D_NN_WORK dest_obj_3d )
    {
        if ( dest_obj_3d == null )
        {
            if ( obj_work.obj_3d != null )
            {
                dest_obj_3d = obj_work.obj_3d;
            }
            else
            {
                dest_obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();
            }
            dest_obj_3d.Clear();
            obj_work.flag |= 134217728U;
        }
        obj_work.flag |= 536870912U;
        AppMain.ObjCopyAction3dNNModel( src_obj_3d, dest_obj_3d );
        obj_work.obj_3d = dest_obj_3d;
    }

    // Token: 0x0600194D RID: 6477 RVA: 0x000E4CEC File Offset: 0x000E2EEC
    private static void ObjObjectAction3dNNModelReleaseCopy( AppMain.OBS_OBJECT_WORK obj_work )
    {
        if ( ( obj_work.flag & 134217728U ) != 0U )
        {
            obj_work.obj_3d = null;
            obj_work.flag &= 4160749567U;
        }
        obj_work.obj_3d = null;
        obj_work.flag &= 3758096383U;
    }

    // Token: 0x0600194E RID: 6478 RVA: 0x000E4D3C File Offset: 0x000E2F3C
    private static void ObjObjectAction3dNNModelLoad( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_NN_WORK obj_3d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, string filename_tex, AppMain.AMS_AMB_HEADER amb_tex, uint drawflag )
    {
        if ( obj_3d == null )
        {
            if ( obj_work.obj_3d != null )
            {
                obj_3d = obj_work.obj_3d;
            }
            else
            {
                obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();
            }
            obj_3d.Clear();
            obj_work.flag |= 134217728U;
        }
        obj_work.obj_3d = obj_3d;
        AppMain.ObjAction3dNNModelLoad( obj_3d, data_work, filename, index, archive, filename_tex, amb_tex, drawflag );
    }

    // Token: 0x0600194F RID: 6479 RVA: 0x000E4D98 File Offset: 0x000E2F98
    private static void ObjAction3dNNModelLoadTxb( AppMain.OBS_ACTION3D_NN_WORK obj_3d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, string filename_tex, AppMain.AMS_AMB_HEADER amb_tex, uint drawflag, AppMain.TXB_HEADER txb )
    {
        object obj = null;
        string filepath = null;
        obj_3d.command_state = 0U;
        obj_3d.marge = 0f;
        obj_3d.per = 1f;
        obj_3d.use_light_flag = AppMain.g_obj.def_user_light_flag;
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx );
        AppMain.nnMakeUnitMatrix( obj_3d.user_obj_mtx_r );
        for ( int i = 0; i < 2; i++ )
        {
            obj_3d.speed[i] = 1f;
        }
        obj_3d.blend_spd = 0.25f;
        obj_3d.drawflag = drawflag;
        obj_3d.draw_state.Assign( AppMain.g_obj_draw_3dnn_draw_state );
        if ( archive != null )
        {
            obj_3d.flag |= 65536U;
        }
        if ( filename != null )
        {
            obj = AppMain.ObjDataLoad( data_work, filename, archive );
            if ( archive != null && obj == null )
            {
                obj_3d.flag &= 4294901759U;
                obj = AppMain.ObjDataLoad( data_work, filename, null );
            }
        }
        else if ( archive != null )
        {
            obj = AppMain.ObjDataLoadAmbIndex( data_work, index, archive );
            if ( obj == null )
            {
                obj_3d.flag &= 4294901759U;
            }
        }
        else if ( data_work != null )
        {
            obj = AppMain.ObjDataGetInc( data_work );
        }
        if ( obj == null )
        {
            return;
        }
        obj_3d.model = obj;
        if ( data_work != null )
        {
            obj_3d.model_data_work = data_work;
        }
        if ( filename_tex != null && filename_tex != "" )
        {
            AppMain.sFile = filename_tex;
            filepath = AppMain.sFile;
        }
        else
        {
            AppMain.sFile = "";
        }
        obj_3d.reg_index = AppMain.amObjectLoad( out obj_3d._object, AppMain.amTxbGetTexFileList( txb ), out obj_3d.texlist, out obj_3d.texlistbuf, obj, drawflag | AppMain.g_obj.load_drawflag, filepath, amb_tex );
        if ( AppMain.obj_load_initial_set_flag )
        {
            AppMain.OBS_LOAD_INITIAL_WORK obs_LOAD_INITIAL_WORK = AppMain.obj_load_initial_work;
            if ( obs_LOAD_INITIAL_WORK.obj_num < 255 )
            {
                obs_LOAD_INITIAL_WORK.obj_3d[obs_LOAD_INITIAL_WORK.obj_num] = obj_3d;
                obs_LOAD_INITIAL_WORK.obj_num++;
            }
        }
        obj_3d.flag |= 2147483648U;
        obj_3d.flag &= 3221225471U;
    }

    // Token: 0x06001950 RID: 6480 RVA: 0x000E4F70 File Offset: 0x000E3170
    private static void ObjObjectAction3dNNModelLoadTxb( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_NN_WORK obj_3d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, string filename_tex, AppMain.AMS_AMB_HEADER amb_tex, uint drawflag, AppMain.TXB_HEADER txb )
    {
        if ( obj_3d == null )
        {
            if ( obj_work.obj_3d != null )
            {
                obj_3d = obj_work.obj_3d;
            }
            else
            {
                obj_3d = new AppMain.OBS_ACTION3D_NN_WORK();
            }
            obj_3d.Clear();
            obj_work.flag |= 134217728U;
        }
        obj_work.obj_3d = obj_3d;
        AppMain.ObjAction3dNNModelLoadTxb( obj_3d, data_work, filename, index, archive, filename_tex, amb_tex, drawflag, txb );
    }

    // Token: 0x06001951 RID: 6481 RVA: 0x000E4FCC File Offset: 0x000E31CC
    private static void ObjAction3dNNMotionLoad( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int reg_file_id, bool marge, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive )
    {
        AppMain.ObjAction3dNNMotionLoad( obj_3d, reg_file_id, marge, data_work, filename, index, archive, 64, 16 );
    }

    // Token: 0x06001952 RID: 6482 RVA: 0x000E4FEC File Offset: 0x000E31EC
    private static void ObjAction3dNNMotionLoad( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int reg_file_id, bool marge, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, int motion_num, int mmotion_num )
    {
        object obj = null;
        if ( ( obj_3d.flag & 1073741824U ) == 0U )
        {
            obj_3d.flag |= 536870912U;
            AppMain.OBS_ACTION3D_MTN_LOAD_SETTING obs_ACTION3D_MTN_LOAD_SETTING = obj_3d.mtn_load_setting[reg_file_id];
            obs_ACTION3D_MTN_LOAD_SETTING.enable = true;
            obs_ACTION3D_MTN_LOAD_SETTING.marge = marge;
            obs_ACTION3D_MTN_LOAD_SETTING.data_work = data_work;
            obs_ACTION3D_MTN_LOAD_SETTING.filename = "";
            if ( filename != null )
            {
                obs_ACTION3D_MTN_LOAD_SETTING.filename = filename;
            }
            obs_ACTION3D_MTN_LOAD_SETTING.index = index;
            obs_ACTION3D_MTN_LOAD_SETTING.archive = archive;
            return;
        }
        if ( archive != null )
        {
            obj_3d.flag |= 131072U << reg_file_id;
        }
        if ( filename != null && filename != "" )
        {
            obj = AppMain.ObjDataLoad( data_work, filename, archive );
            if ( archive != null && obj == null )
            {
                obj_3d.flag &= ~( 131072U << reg_file_id );
                obj = AppMain.ObjDataLoad( data_work, filename, null );
            }
        }
        else if ( archive != null )
        {
            obj = AppMain.ObjDataLoadAmbIndex( data_work, index, archive );
            if ( archive != null && obj == null )
            {
                obj_3d.flag &= ~( 131072U << reg_file_id );
            }
        }
        else if ( data_work != null )
        {
            obj = AppMain.ObjDataGetInc( data_work );
        }
        if ( obj == null )
        {
            return;
        }
        obj_3d.mtn[reg_file_id] = obj;
        if ( data_work != null )
        {
            obj_3d.mtn_data_work[reg_file_id] = data_work;
        }
        if ( obj_3d.motion == null )
        {
            obj_3d.motion = AppMain.amMotionCreate( obj_3d._object, motion_num, mmotion_num, marge ? 1 : 0 );
        }
        if ( obj is AppMain.AMS_AMB_HEADER || obj is AppMain.AMS_FS )
        {
            AppMain.AMS_AMB_HEADER amb = AppMain.readAMBFile(obj);
            AppMain.amMotionRegistFile( obj_3d.motion, reg_file_id, amb );
            return;
        }
        AppMain.amMotionRegistFile( obj_3d.motion, reg_file_id, obj );
    }

    // Token: 0x06001953 RID: 6483 RVA: 0x000E5170 File Offset: 0x000E3370
    private static void ObjObjectAction3dNNMotionLoad( AppMain.OBS_OBJECT_WORK obj_work, int reg_file_id, bool marge, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive )
    {
        AppMain.ObjObjectAction3dNNMotionLoad( obj_work, reg_file_id, marge, data_work, filename, index, archive, 64, 16 );
    }

    // Token: 0x06001954 RID: 6484 RVA: 0x000E5190 File Offset: 0x000E3390
    private static void ObjObjectAction3dNNMotionLoad( AppMain.OBS_OBJECT_WORK obj_work, int reg_file_id, bool marge, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, int motion_num, int mmotion_num )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        AppMain.ObjAction3dNNMotionLoad( obj_3d, reg_file_id, marge, data_work, filename, index, archive, motion_num, mmotion_num );
    }

    // Token: 0x06001955 RID: 6485 RVA: 0x000E51B7 File Offset: 0x000E33B7
    private static void ObjAction3dNNMaterialMotionLoad( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int reg_file_id, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive )
    {
        AppMain.ObjAction3dNNMaterialMotionLoad( obj_3d, reg_file_id, data_work, filename, index, archive, 64, 16 );
    }

    // Token: 0x06001956 RID: 6486 RVA: 0x000E51CC File Offset: 0x000E33CC
    private static void ObjAction3dNNMaterialMotionLoad( AppMain.OBS_ACTION3D_NN_WORK obj_3d, int reg_file_id, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, int motion_num, int mmotion_num )
    {
        object obj = null;
        if ( ( obj_3d.flag & 1073741824U ) == 0U )
        {
            obj_3d.flag |= 268435456U;
            AppMain.OBS_ACTION3D_MTN_LOAD_SETTING obs_ACTION3D_MTN_LOAD_SETTING = obj_3d.mat_mtn_load_setting[reg_file_id];
            obs_ACTION3D_MTN_LOAD_SETTING.enable = true;
            obs_ACTION3D_MTN_LOAD_SETTING.marge = false;
            obs_ACTION3D_MTN_LOAD_SETTING.data_work = data_work;
            obs_ACTION3D_MTN_LOAD_SETTING.filename = "";
            if ( filename != null && filename != "" )
            {
                obs_ACTION3D_MTN_LOAD_SETTING.filename = filename;
            }
            obs_ACTION3D_MTN_LOAD_SETTING.index = index;
            obs_ACTION3D_MTN_LOAD_SETTING.archive = archive;
            return;
        }
        if ( archive != null )
        {
            obj_3d.flag |= 4096U << reg_file_id;
        }
        if ( filename != null && filename != "" )
        {
            obj = AppMain.ObjDataLoad( data_work, filename, archive );
            if ( archive != null && obj == null )
            {
                obj_3d.flag &= ~( 4096U << reg_file_id );
                obj = AppMain.ObjDataLoad( data_work, filename, null );
            }
        }
        else if ( archive != null )
        {
            obj = AppMain.ObjDataLoadAmbIndex( data_work, index, archive );
            if ( archive != null && obj == null )
            {
                obj_3d.flag &= ~( 4096U << reg_file_id );
            }
        }
        else if ( data_work != null )
        {
            obj = AppMain.ObjDataGetInc( data_work );
        }
        if ( obj == null )
        {
            return;
        }
        obj_3d.mat_mtn[reg_file_id] = obj;
        if ( data_work != null )
        {
            obj_3d.mat_mtn_data_work[reg_file_id] = data_work;
        }
        if ( obj_3d.motion == null )
        {
            obj_3d.motion = AppMain.amMotionCreate( obj_3d._object, motion_num, mmotion_num, 0 );
        }
        if ( obj is AppMain.AMS_AMB_HEADER || obj is AppMain.AMS_FS )
        {
            AppMain.AMS_AMB_HEADER amb = AppMain.readAMBFile(obj);
            AppMain.amMotionMaterialRegistFile( obj_3d.motion, reg_file_id, amb );
            return;
        }
        AppMain.amMotionMaterialRegistFile( obj_3d.motion, reg_file_id, obj );
    }

    // Token: 0x06001957 RID: 6487 RVA: 0x000E534E File Offset: 0x000E354E
    private static void ObjObjectAction3dNNMaterialMotionLoad( AppMain.OBS_OBJECT_WORK obj_work, int reg_file_id, AppMain.OBS_DATA_WORK data_work, string filename, int index, object archive )
    {
        AppMain.ObjObjectAction3dNNMaterialMotionLoad( obj_work, reg_file_id, data_work, filename, index, archive, 64, 16 );
    }

    // Token: 0x06001958 RID: 6488 RVA: 0x000E5364 File Offset: 0x000E3564
    private static void ObjObjectAction3dNNMaterialMotionLoad( AppMain.OBS_OBJECT_WORK obj_work, int reg_file_id, AppMain.OBS_DATA_WORK data_work, string filename, int index, object archive, int motion_num, int mmotion_num )
    {
        AppMain.OBS_ACTION3D_NN_WORK obj_3d = obj_work.obj_3d;
        AppMain.ObjAction3dNNMaterialMotionLoad( obj_3d, reg_file_id, data_work, filename, index, ( AppMain.AMS_AMB_HEADER )archive, motion_num, mmotion_num );
    }

    // Token: 0x06001959 RID: 6489 RVA: 0x000E5390 File Offset: 0x000E3590
    private static bool ObjAction3dNNModelLoadCheck( AppMain.OBS_ACTION3D_NN_WORK obj_3d )
    {
        if ( ( obj_3d.flag & 2147483648U ) != 0U )
        {
            if ( AppMain.amDrawIsRegistComplete( obj_3d.reg_index ) )
            {
                obj_3d.flag &= 2147483647U;
                obj_3d.flag |= 1073741824U;
                obj_3d.reg_index = -1;
                if ( obj_3d.model_data_work != null )
                {
                    AppMain.ObjDataRelease( obj_3d.model_data_work );
                    obj_3d.model_data_work = null;
                }
                else if ( obj_3d.model != null && ( obj_3d.flag & 65536U ) == 0U )
                {
                    obj_3d.model = null;
                }
                obj_3d.flag &= 4294901759U;
                obj_3d.model = null;
                if ( ( obj_3d.flag & 536870912U ) != 0U )
                {
                    int i = 0;
                    AppMain.ArrayPointer<AppMain.OBS_ACTION3D_MTN_LOAD_SETTING> pointer = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_MTN_LOAD_SETTING>(obj_3d.mtn_load_setting);
                    while ( i < 4 )
                    {
                        if ( ( ~pointer ).enable )
                        {
                            AppMain.ObjAction3dNNMotionLoad( obj_3d, i, ( ~pointer ).marge, ( ~pointer ).data_work, ( ~pointer ).filename, ( ~pointer ).index, ( ~pointer ).archive );
                            ( ~pointer ).enable = false;
                        }
                        i++;
                        pointer = ++pointer;
                    }
                    obj_3d.flag &= 3758096383U;
                }
                if ( ( obj_3d.flag & 268435456U ) != 0U )
                {
                    int j = 0;
                    AppMain.ArrayPointer<AppMain.OBS_ACTION3D_MTN_LOAD_SETTING> pointer2 = new AppMain.ArrayPointer<AppMain.OBS_ACTION3D_MTN_LOAD_SETTING>(obj_3d.mat_mtn_load_setting);
                    while ( j < 4 )
                    {
                        if ( ( ~pointer2 ).enable )
                        {
                            AppMain.ObjAction3dNNMaterialMotionLoad( obj_3d, j, ( ~pointer2 ).data_work, ( ~pointer2 ).filename, ( ~pointer2 ).index, ( ~pointer2 ).archive );
                            ( ~pointer2 ).enable = false;
                        }
                        j++;
                        pointer2 = ++pointer2;
                    }
                    obj_3d.flag &= 4026531839U;
                }
                return true;
            }
        }
        else if ( ( obj_3d.flag & 1073741824U ) != 0U )
        {
            return true;
        }
        return false;
    }

    // Token: 0x0600195A RID: 6490 RVA: 0x000E5574 File Offset: 0x000E3774
    private static void ObjAction3dNNModelRelease( AppMain.OBS_ACTION3D_NN_WORK obj_3d )
    {
        obj_3d.reg_index = AppMain.amObjectRelease( obj_3d._object, obj_3d.texlist );
        obj_3d.flag |= 134217728U;
    }

    // Token: 0x0600195B RID: 6491 RVA: 0x000E55A0 File Offset: 0x000E37A0
    private static bool ObjAction3dNNModelReleaseCheck( AppMain.OBS_ACTION3D_NN_WORK obj_3d )
    {
        if ( ( obj_3d.flag & 1207959552U ) == 0U )
        {
            return true;
        }
        if ( AppMain.amDrawIsRegistComplete( obj_3d.reg_index ) )
        {
            if ( obj_3d._object != null )
            {
                obj_3d._object = null;
            }
            if ( obj_3d.texlistbuf != null )
            {
                obj_3d.texlistbuf = null;
            }
            obj_3d.flag &= 3087007743U;
            if ( obj_3d.model_data_work != null )
            {
                AppMain.ObjDataRelease( obj_3d.model_data_work );
                obj_3d.model_data_work = null;
            }
            else if ( obj_3d.model != null && ( obj_3d.flag & 65536U ) == 0U )
            {
                obj_3d.model = null;
            }
            obj_3d.flag &= 4294901759U;
            return true;
        }
        return false;
    }

    // Token: 0x0600195C RID: 6492 RVA: 0x000E5648 File Offset: 0x000E3848
    private static void ObjAction3dNNMotionRelease( AppMain.OBS_ACTION3D_NN_WORK obj_3d )
    {
        if ( obj_3d.motion != null )
        {
            AppMain.amMotionDelete( obj_3d.motion );
            obj_3d.motion = null;
        }
        for ( int i = 0; i < 4; i++ )
        {
            if ( obj_3d.mtn_data_work[i] != null )
            {
                AppMain.ObjDataRelease( obj_3d.mtn_data_work[i] );
                obj_3d.mtn_data_work[i] = null;
            }
            else if ( obj_3d.mtn[i] != null )
            {
                uint num = obj_3d.flag & 131072U << i;
            }
            obj_3d.flag &= ~( 131072U << i );
            obj_3d.mtn[i] = null;
            if ( obj_3d.mat_mtn_data_work[i] != null )
            {
                AppMain.ObjDataRelease( obj_3d.mat_mtn_data_work[i] );
                obj_3d.mat_mtn_data_work[i] = null;
            }
            else if ( obj_3d.mat_mtn[i] != null )
            {
                uint num2 = obj_3d.flag & 4096U << i;
            }
            obj_3d.flag &= ~( 4096U << i );
            obj_3d.mat_mtn[i] = null;
        }
    }

    // Token: 0x0600195D RID: 6493 RVA: 0x000E5740 File Offset: 0x000E3940
    private static void ObjAction3dESEffectLoad( AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, int user_attr, int ecb_prio )
    {
        object obj = null;
        obj_3des.command_state = 0U;
        obj_3des.user_attr = user_attr;
        obj_3des.speed = 1f;
        if ( archive != null )
        {
            obj_3des.flag |= 65536U;
        }
        if ( filename != null && filename != "" )
        {
            obj = AppMain.ObjDataLoad( data_work, filename, archive );
            if ( archive != null && obj == null )
            {
                obj_3des.flag &= 4294901759U;
                obj = AppMain.ObjDataLoad( data_work, filename, null );
            }
        }
        else if ( archive != null )
        {
            obj = AppMain.ObjDataLoadAmbIndex( data_work, index, archive );
            if ( obj == null )
            {
                obj_3des.flag &= 4294901759U;
            }
        }
        else if ( data_work != null )
        {
            obj = AppMain.ObjDataGetInc( data_work );
        }
        if ( obj == null )
        {
            return;
        }
        obj_3des.eff = obj;
        if ( data_work != null )
        {
            obj_3des.eff_data_work = data_work;
        }
        obj_3des.ecb = AppMain._amEffectCreate( ( AppMain.AMS_AME_HEADER )obj_3des.eff, user_attr, ecb_prio );
    }

    // Token: 0x0600195E RID: 6494 RVA: 0x000E581B File Offset: 0x000E3A1B
    private static void ObjObjectAction3dESEffectLoad( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive )
    {
        AppMain.ObjObjectAction3dESEffectLoad( obj_work, obj_3des, data_work, filename, index, archive, 0, 0 );
    }

    // Token: 0x0600195F RID: 6495 RVA: 0x000E582C File Offset: 0x000E3A2C
    private static void ObjObjectAction3dESEffectLoad( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, int user_attr, int ecb_prio )
    {
        if ( obj_3des == null )
        {
            if ( obj_work.obj_3des != null )
            {
                obj_3des = obj_work.obj_3des;
            }
            else
            {
                obj_3des = new AppMain.OBS_ACTION3D_ES_WORK();
            }
            obj_3des.Clear();
            obj_work.flag |= 268435456U;
        }
        obj_work.obj_3des = obj_3des;
        AppMain.ObjAction3dESEffectLoad( obj_3des, data_work, filename, index, archive, user_attr, ecb_prio );
    }

    // Token: 0x06001960 RID: 6496 RVA: 0x000E5884 File Offset: 0x000E3A84
    private static void ObjAction3dESEffectRelease( AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        AppMain.amEffectDelete( obj_3des.ecb );
        obj_3des.ecb = null;
    }

    // Token: 0x06001961 RID: 6497 RVA: 0x000E5898 File Offset: 0x000E3A98
    private static void ObjAction3dESTextureLoad( AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, bool load_tex )
    {
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = null;
        if ( archive != null )
        {
            obj_3des.flag |= 131072U;
        }
        if ( filename != null && filename != "" )
        {
            ams_AMB_HEADER = AppMain.readAMBFile( AppMain.ObjDataLoad( data_work, filename, archive ) );
            if ( archive != null && ams_AMB_HEADER == null )
            {
                obj_3des.flag &= 4294836223U;
                ams_AMB_HEADER = AppMain.readAMBFile( AppMain.ObjDataLoad( data_work, filename, null ) );
            }
        }
        else if ( archive != null )
        {
            ams_AMB_HEADER = AppMain.readAMBFile( AppMain.ObjDataLoadAmbIndex( data_work, index, archive ) );
            if ( ams_AMB_HEADER == null )
            {
                obj_3des.flag &= 4294836223U;
            }
        }
        else if ( data_work != null )
        {
            ams_AMB_HEADER = AppMain.readAMBFile( AppMain.ObjDataGetInc( data_work ) );
        }
        if ( ams_AMB_HEADER == null )
        {
            return;
        }
        obj_3des.ambtex = ams_AMB_HEADER;
        if ( data_work != null )
        {
            obj_3des.ambtex_data_work = data_work;
        }
        if ( load_tex )
        {
            AppMain.TXB_HEADER txb = AppMain.readTXBfile(AppMain.amBindGet(ams_AMB_HEADER, 0));
            uint num = AppMain.amTxbGetCount(txb);
            obj_3des.texlistbuf = null;
            AppMain.nnSetUpTexlist( out obj_3des.texlist, ( int )num, ref obj_3des.texlistbuf );
            if ( AppMain.obj_load_initial_set_flag )
            {
                AppMain.OBS_LOAD_INITIAL_WORK obs_LOAD_INITIAL_WORK = AppMain.obj_load_initial_work;
                if ( obs_LOAD_INITIAL_WORK.es_num < 255 )
                {
                    obs_LOAD_INITIAL_WORK.obj_3des[obs_LOAD_INITIAL_WORK.es_num] = obj_3des;
                    obs_LOAD_INITIAL_WORK.es_num++;
                }
            }
            obj_3des.tex_reg_index = AppMain.amTextureLoad( obj_3des.texlist, AppMain.amTxbGetTexFileList( txb ), filename, ams_AMB_HEADER );
            obj_3des.flag |= 1073741824U;
        }
    }

    // Token: 0x06001962 RID: 6498 RVA: 0x000E59EA File Offset: 0x000E3BEA
    private static void ObjObjectAction3dESTextureLoad( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, bool load_tex )
    {
        AppMain.ObjAction3dESTextureLoad( obj_3des, data_work, filename, index, archive, load_tex );
    }

    // Token: 0x06001963 RID: 6499 RVA: 0x000E59FC File Offset: 0x000E3BFC
    private static void ObjAction3dESTextureRelease( AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        if ( obj_3des.texlist_data_work != null )
        {
            obj_3des.tex_reg_index = AppMain.ObjAction3dESTextureReleaseDwork( obj_3des.texlist_data_work );
        }
        else
        {
            obj_3des.tex_reg_index = AppMain.amTextureRelease( obj_3des.texlist );
        }
        if ( obj_3des.tex_reg_index != -1 )
        {
            obj_3des.flag |= 1073741824U;
            return;
        }
        obj_3des.texlist_data_work = null;
        obj_3des.texlist = null;
        obj_3des.texlistbuf = null;
    }

    // Token: 0x06001964 RID: 6500 RVA: 0x000E5A68 File Offset: 0x000E3C68
    private static bool ObjAction3dESTextureReleaseCheck( AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        if ( ( obj_3des.flag & 1073741824U ) == 0U )
        {
            return true;
        }
        if ( obj_3des.texlist_data_work != null )
        {
            if ( AppMain.ObjAction3dESTextureReleaseDworkCheck( obj_3des.texlist_data_work, obj_3des.tex_reg_index ) )
            {
                obj_3des.texlist_data_work = null;
                obj_3des.texlist = null;
                obj_3des.texlistbuf = null;
                obj_3des.tex_reg_index = -1;
                obj_3des.flag &= 3221225471U;
                return true;
            }
        }
        else if ( AppMain.amDrawIsRegistComplete( obj_3des.tex_reg_index ) )
        {
            obj_3des.texlist = null;
            obj_3des.texlistbuf = null;
            obj_3des.tex_reg_index = -1;
            obj_3des.flag &= 3221225471U;
            return true;
        }
        return false;
    }

    // Token: 0x06001965 RID: 6501 RVA: 0x000E5B08 File Offset: 0x000E3D08
    private static int ObjAction3dESTextureLoadToDwork( AppMain.OBS_DATA_WORK texlist_dwork, AppMain.AMS_AMB_HEADER amb_tex, ref object texlist_buf )
    {
        int result;
        if ( texlist_dwork.pData == null )
        {
            AppMain.TXB_HEADER txb = AppMain.readTXBfile(AppMain.amBindGet(amb_tex, 0));
            uint num = AppMain.amTxbGetCount(txb);
            texlist_buf = null;
            AppMain.NNS_TEXLIST nns_TEXLIST;
            AppMain.nnSetUpTexlist( out nns_TEXLIST, ( int )num, ref texlist_buf );
            result = AppMain.amTextureLoad( nns_TEXLIST, AppMain.amTxbGetTexFileList( txb ), null, amb_tex );
            AppMain.ObjDataSet( texlist_dwork, nns_TEXLIST );
        }
        else
        {
            AppMain.ObjDataGetInc( texlist_dwork );
            result = -1;
            texlist_buf = null;
        }
        return result;
    }

    // Token: 0x06001966 RID: 6502 RVA: 0x000E5B68 File Offset: 0x000E3D68
    private static int ObjAction3dESTextureReleaseDwork( AppMain.OBS_DATA_WORK texlist_dwork )
    {
        int result = -1;
        if ( texlist_dwork.num != 0 && texlist_dwork.pData != null )
        {
            texlist_dwork.num -= 1;
            if ( texlist_dwork.num == 0 )
            {
                result = AppMain.amTextureRelease( ( AppMain.NNS_TEXLIST )texlist_dwork.pData );
            }
        }
        return result;
    }

    // Token: 0x06001967 RID: 6503 RVA: 0x000E5BB0 File Offset: 0x000E3DB0
    private static bool ObjAction3dESTextureReleaseDworkCheck( AppMain.OBS_DATA_WORK texlist_dwork, int reg_index )
    {
        if ( AppMain.amDrawIsRegistComplete( reg_index ) )
        {
            texlist_dwork.pData = null;
            return true;
        }
        return false;
    }

    // Token: 0x06001968 RID: 6504 RVA: 0x000E5BC4 File Offset: 0x000E3DC4
    private static void ObjObjectAction3dESTextureSetByDwork( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_DATA_WORK texlist_dwork )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = obj_work.obj_3des;
        object obj = null;
        AppMain.ObjAction3dESTextureLoadToDwork( texlist_dwork, null, ref obj );
        obj_3des.texlist_data_work = texlist_dwork;
        obj_3des.texlist = ( AppMain.NNS_TEXLIST )texlist_dwork.pData;
        obj_3des.texlistbuf = texlist_dwork.pData;
    }

    // Token: 0x06001969 RID: 6505 RVA: 0x000E5C08 File Offset: 0x000E3E08
    private static void ObjAction3dESModelLoad( AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, uint drawflag, bool load_model )
    {
        object obj = null;
        if ( archive != null )
        {
            obj_3des.flag |= 262144U;
        }
        if ( filename != null && filename != "" )
        {
            obj = AppMain.ObjDataLoad( data_work, filename, archive );
            if ( archive != null && obj == null )
            {
                obj_3des.flag &= 4294705151U;
                obj = AppMain.ObjDataLoad( data_work, filename, null );
            }
        }
        else if ( archive != null )
        {
            obj = AppMain.ObjDataLoadAmbIndex( data_work, index, archive );
            if ( obj == null )
            {
                obj_3des.flag &= 4294705151U;
            }
        }
        else if ( data_work != null )
        {
            obj = AppMain.ObjDataGetInc( data_work );
        }
        if ( obj == null )
        {
            return;
        }
        obj_3des.model = obj;
        if ( data_work != null )
        {
            obj_3des.model_data_work = data_work;
        }
        if ( load_model )
        {
            AppMain.NNS_TEXLIST nns_TEXLIST = null;
            object obj2 = null;
            obj_3des.model_reg_index = AppMain.amObjectLoad( out obj_3des._object, out nns_TEXLIST, out obj2, obj, drawflag | AppMain.g_obj.load_drawflag, null, null );
            obj2 = null;
            obj_3des.flag |= 2147483648U;
            AppMain.amEffectSetObject( obj_3des.ecb, obj_3des._object, 16 );
        }
    }

    // Token: 0x0600196A RID: 6506 RVA: 0x000E5D03 File Offset: 0x000E3F03
    private static void ObjObjectAction3dESModelLoad( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION3D_ES_WORK obj_3des, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, uint drawflag, bool load_model )
    {
        AppMain.ObjAction3dESModelLoad( obj_3des, data_work, filename, index, archive, drawflag, load_model );
    }

    // Token: 0x0600196B RID: 6507 RVA: 0x000E5D18 File Offset: 0x000E3F18
    private static void ObjAction3dESModelRelease( AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        if ( obj_3des.object_data_work != null )
        {
            obj_3des.model_reg_index = AppMain.ObjAction3dESModelReleaseDwork( obj_3des.object_data_work );
        }
        else
        {
            obj_3des.model_reg_index = AppMain.amObjectRelease( obj_3des._object );
        }
        if ( obj_3des.model_reg_index != -1 )
        {
            obj_3des.flag |= 2147483648U;
            return;
        }
        obj_3des.object_data_work = null;
        obj_3des._object = null;
    }

    // Token: 0x0600196C RID: 6508 RVA: 0x000E5D7C File Offset: 0x000E3F7C
    private static bool ObjAction3dESModelReleaseCheck( AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        if ( ( obj_3des.flag & 2147483648U ) == 0U )
        {
            return true;
        }
        if ( obj_3des.object_data_work != null )
        {
            if ( AppMain.ObjAction3dESModelReleaseDworkCheck( obj_3des.object_data_work, obj_3des.model_reg_index ) )
            {
                obj_3des.object_data_work = null;
                obj_3des._object = null;
                obj_3des.model_reg_index = -1;
                obj_3des.flag &= 2147483647U;
                return true;
            }
        }
        else if ( AppMain.amDrawIsRegistComplete( obj_3des.model_reg_index ) )
        {
            obj_3des._object = null;
            obj_3des.model_reg_index = -1;
            obj_3des.flag &= 2147483647U;
            return true;
        }
        return false;
    }

    // Token: 0x0600196D RID: 6509 RVA: 0x000E5E10 File Offset: 0x000E4010
    private static int ObjAction3dESModelLoadToDwork( AppMain.OBS_DATA_WORK object_dwork, object model, uint drawflag )
    {
        int result;
        if ( object_dwork.pData == null )
        {
            AppMain.NNS_TEXLIST nns_TEXLIST = null;
            object obj = null;
            AppMain.NNS_OBJECT pData;
            result = AppMain.amObjectLoad( out pData, out nns_TEXLIST, out obj, model, drawflag | AppMain.g_obj.load_drawflag, null, null );
            obj = null;
            AppMain.ObjDataSet( object_dwork, pData );
        }
        else
        {
            AppMain.ObjDataGetInc( object_dwork );
            result = -1;
        }
        return result;
    }

    // Token: 0x0600196E RID: 6510 RVA: 0x000E5E5C File Offset: 0x000E405C
    private static int ObjAction3dESModelReleaseDwork( AppMain.OBS_DATA_WORK object_dwork )
    {
        int result = -1;
        if ( object_dwork.num != 0 && object_dwork.pData != null )
        {
            object_dwork.num -= 1;
            if ( object_dwork.num == 0 )
            {
                result = AppMain.amObjectRelease( ( AppMain.NNS_OBJECT )object_dwork.pData );
            }
        }
        return result;
    }

    // Token: 0x0600196F RID: 6511 RVA: 0x000E5EA4 File Offset: 0x000E40A4
    private static bool ObjAction3dESModelReleaseDworkCheck( AppMain.OBS_DATA_WORK object_dwork, int reg_index )
    {
        if ( AppMain.amDrawIsRegistComplete( reg_index ) )
        {
            object_dwork.pData = null;
            return true;
        }
        return false;
    }

    // Token: 0x06001970 RID: 6512 RVA: 0x000E5EB8 File Offset: 0x000E40B8
    private static void ObjObjectAction3dESModelSetByDwork( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_DATA_WORK object_dwork )
    {
        AppMain.OBS_ACTION3D_ES_WORK obj_3des = obj_work.obj_3des;
        AppMain.ObjAction3dESModelLoadToDwork( object_dwork, null, 0U );
        obj_3des.object_data_work = object_dwork;
        obj_3des._object = ( AppMain.NNS_OBJECT )object_dwork.pData;
        AppMain.amEffectSetObject( obj_3des.ecb, obj_3des._object, 16 );
    }

    // Token: 0x06001971 RID: 6513 RVA: 0x000E5F00 File Offset: 0x000E4100
    private static bool ObjAction3dESEffectLoadCheck( AppMain.OBS_ACTION3D_ES_WORK obj_3des )
    {
        bool result = true;
        if ( ( obj_3des.flag & 1073741824U ) != 0U )
        {
            if ( AppMain.amDrawIsRegistComplete( obj_3des.tex_reg_index ) )
            {
                obj_3des.flag &= 3221225471U;
                obj_3des.tex_reg_index = -1;
            }
            else
            {
                result = false;
            }
        }
        if ( ( obj_3des.flag & 2147483648U ) != 0U )
        {
            if ( AppMain.amDrawIsRegistComplete( obj_3des.model_reg_index ) )
            {
                obj_3des.flag &= 2147483647U;
                obj_3des.tex_reg_index = -1;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }

    // Token: 0x06001972 RID: 6514 RVA: 0x000E5F80 File Offset: 0x000E4180
    private static void ObjAction2dAMALoad( AppMain.OBS_ACTION2D_AMA_WORK obj_2d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, AppMain.AMS_AMB_HEADER amb_tex, uint id, int type_node )
    {
        AppMain.A2S_AMA_HEADER a2S_AMA_HEADER = null;
        AppMain.ObjAction2dAMAWorkInit( obj_2d );
        if ( archive != null )
        {
            obj_2d.flag |= 2147483648U;
        }
        if ( filename != null )
        {
            a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataLoad( data_work, filename, archive ) );
            if ( archive != null && a2S_AMA_HEADER == null )
            {
                obj_2d.flag &= 2147483647U;
                a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataLoad( data_work, filename, null ) );
            }
        }
        else if ( archive != null )
        {
            a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataLoadAmbIndex( data_work, index, archive ) );
            if ( a2S_AMA_HEADER == null )
            {
                obj_2d.flag &= 2147483647U;
            }
        }
        else if ( data_work != null )
        {
            a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataGetInc( data_work ) );
        }
        if ( a2S_AMA_HEADER == null )
        {
            return;
        }
        obj_2d.ama = a2S_AMA_HEADER;
        if ( data_work != null )
        {
            obj_2d.ama_data_work = data_work;
        }
        obj_2d.type_node = type_node;
        obj_2d.act_id = id;
        AppMain.AoTexBuild( obj_2d.ao_tex, amb_tex );
        AppMain.AoTexLoad( obj_2d.ao_tex );
        obj_2d.flag |= 1073741824U;
        obj_2d.flag &= 3758096383U;
    }

    // Token: 0x06001973 RID: 6515 RVA: 0x000E6080 File Offset: 0x000E4280
    private static void ObjObjectAction2dAMALoad( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION2D_AMA_WORK obj_2d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, AppMain.AMS_AMB_HEADER amb_tex, uint id, int type_node )
    {
        if ( obj_2d == null )
        {
            if ( obj_work.obj_2d != null )
            {
                obj_2d = obj_work.obj_2d;
            }
            else
            {
                obj_2d = new AppMain.OBS_ACTION2D_AMA_WORK();
            }
            obj_2d.Clear();
            obj_work.flag |= 67108864U;
        }
        obj_work.obj_2d = obj_2d;
        AppMain.ObjAction2dAMALoad( obj_2d, data_work, filename, index, archive, amb_tex, id, type_node );
    }

    // Token: 0x06001974 RID: 6516 RVA: 0x000E60DC File Offset: 0x000E42DC
    private static void ObjAction2dAMALoadSetTexlist( AppMain.OBS_ACTION2D_AMA_WORK obj_2d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, AppMain.NNS_TEXLIST texlist, uint id, int type_node )
    {
        AppMain.A2S_AMA_HEADER a2S_AMA_HEADER = null;
        AppMain.ObjAction2dAMAWorkInit( obj_2d );
        if ( archive != null )
        {
            obj_2d.flag |= 2147483648U;
        }
        if ( filename != null )
        {
            a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataLoad( data_work, filename, archive ) );
            if ( archive != null && a2S_AMA_HEADER == null )
            {
                obj_2d.flag &= 2147483647U;
                a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataLoad( data_work, filename, null ) );
            }
        }
        else if ( archive != null )
        {
            a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataLoadAmbIndex( data_work, index, archive ) );
            if ( a2S_AMA_HEADER == null )
            {
                obj_2d.flag &= 2147483647U;
            }
        }
        else if ( data_work != null )
        {
            a2S_AMA_HEADER = AppMain.readAMAFile( AppMain.ObjDataGetInc( data_work ) );
        }
        if ( a2S_AMA_HEADER == null )
        {
            return;
        }
        obj_2d.ama = a2S_AMA_HEADER;
        if ( data_work != null )
        {
            obj_2d.ama_data_work = data_work;
        }
        obj_2d.type_node = type_node;
        obj_2d.act_id = id;
        obj_2d.texlist = texlist;
        obj_2d.flag |= 536870912U;
        AppMain.ObjAction2dAMACreate( obj_2d );
    }

    // Token: 0x06001975 RID: 6517 RVA: 0x000E61C0 File Offset: 0x000E43C0
    private static void ObjObjectAction2dAMALoadSetTexlist( AppMain.OBS_OBJECT_WORK obj_work, AppMain.OBS_ACTION2D_AMA_WORK obj_2d, AppMain.OBS_DATA_WORK data_work, string filename, int index, AppMain.AMS_AMB_HEADER archive, AppMain.NNS_TEXLIST texlist, uint id, int type_node )
    {
        if ( obj_2d == null )
        {
            if ( obj_work.obj_2d != null )
            {
                obj_2d = obj_work.obj_2d;
            }
            else
            {
                obj_2d = new AppMain.OBS_ACTION2D_AMA_WORK();
            }
            obj_2d.Clear();
            obj_work.flag |= 67108864U;
        }
        obj_work.obj_2d = obj_2d;
        AppMain.ObjAction2dAMALoadSetTexlist( obj_2d, data_work, filename, index, archive, texlist, id, type_node );
    }

    // Token: 0x06001976 RID: 6518 RVA: 0x000E621C File Offset: 0x000E441C
    private static void ObjAction2dAMAWorkInit( AppMain.OBS_ACTION2D_AMA_WORK obj_2d )
    {
        obj_2d.Clear();
        obj_2d.speed = 1f;
        obj_2d.color.a = byte.MaxValue;
        obj_2d.color.r = byte.MaxValue;
        obj_2d.color.g = byte.MaxValue;
        obj_2d.color.b = byte.MaxValue;
        obj_2d.fade.a = 0;
        obj_2d.fade.r = 0;
        obj_2d.fade.g = 0;
        obj_2d.fade.b = 0;
    }

    // Token: 0x06001977 RID: 6519 RVA: 0x000E62AC File Offset: 0x000E44AC
    private static void ObjAction2dAMACreate( AppMain.OBS_ACTION2D_AMA_WORK obj_2d )
    {
        AppMain.AoActSetTexture( obj_2d.texlist );
        if ( obj_2d.type_node != 0 )
        {
            obj_2d.act = AppMain.AoActCreateNode( obj_2d.ama, obj_2d.act_id, 0f );
        }
        else
        {
            obj_2d.act = AppMain.AoActCreate( obj_2d.ama, obj_2d.act_id, 0f );
        }
        AppMain.AoActSetTexture( null );
    }

    // Token: 0x06001978 RID: 6520 RVA: 0x000E630C File Offset: 0x000E450C
    private static bool ObjAction2dAMALoadCheck( AppMain.OBS_ACTION2D_AMA_WORK obj_2d )
    {
        if ( ( obj_2d.flag & 1073741824U ) != 0U )
        {
            if ( AppMain.AoTexIsLoaded( obj_2d.ao_tex ) )
            {
                obj_2d.texlist = AppMain.AoTexGetTexList( obj_2d.ao_tex );
                obj_2d.flag &= 3221225471U;
                obj_2d.flag |= 536870912U;
                AppMain.ObjAction2dAMACreate( obj_2d );
                return true;
            }
        }
        else if ( ( obj_2d.flag & 536870912U ) != 0U )
        {
            return true;
        }
        return false;
    }
}
