using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x06001942 RID: 6466 RVA: 0x000E455C File Offset: 0x000E275C
    private static bool ObjLoadInitDraw()
    {
        AppMain.OBS_LOAD_INITIAL_WORK obs_LOAD_INITIAL_WORK = AppMain.obj_load_initial_work;
        for ( int i = 0; i < obs_LOAD_INITIAL_WORK.obj_num; i++ )
        {
            uint? num = default(uint?);
            AppMain.ObjDrawAction3DNN( obs_LOAD_INITIAL_WORK.obj_3d[i], default( AppMain.VecFx32? ), default( AppMain.VecU16? ), default( AppMain.VecFx32? ), ref num );
        }
        for ( int i = 0; i < obs_LOAD_INITIAL_WORK.es_num; i++ )
        {
            uint? num2 = default(uint?);
            AppMain.ObjDrawAction3DES( obs_LOAD_INITIAL_WORK.obj_3des[i], default( AppMain.VecFx32? ), default( AppMain.VecU16? ), default( AppMain.VecFx32? ), ref num2 );
        }
        return true;
    }

    // Token: 0x06001943 RID: 6467 RVA: 0x000E45FC File Offset: 0x000E27FC
    private static void ObjLoadClearDraw()
    {
        AppMain.obj_load_initial_work.obj_num = 0;
        AppMain.obj_load_initial_work.es_num = 0;
    }

    // Token: 0x06001944 RID: 6468 RVA: 0x000E4614 File Offset: 0x000E2814
    private static void ObjLoadSetInitDrawFlag( bool flag )
    {
        AppMain.obj_load_initial_set_flag = flag;
        AppMain.ObjLoadClearDraw();
    }

    // Token: 0x06001945 RID: 6469 RVA: 0x000E4624 File Offset: 0x000E2824
    private static object ObjDataLoadAmbIndex( AppMain.OBS_DATA_WORK data_work, int index, AppMain.AMS_AMB_HEADER amb )
    {
        object obj = null;
        if ( data_work != null )
        {
            if ( data_work.pData == null )
            {
                if ( amb != null )
                {
                    if ( amb.buf[index] != null )
                    {
                        data_work.pData = amb.buf[index];
                    }
                    else if ( amb.files[index].IndexOf( ".amb", StringComparison.InvariantCultureIgnoreCase ) != -1 )
                    {
                        string dir;
                        data_work.pData = AppMain.readAMBFile( AppMain.amBindGet( amb, index, out dir ) );
                        ( ( AppMain.AMS_AMB_HEADER )data_work.pData ).dir = dir;
                    }
                    else if ( amb.files[index].IndexOf( ".ame", StringComparison.InvariantCultureIgnoreCase ) != -1 )
                    {
                        string dir;
                        data_work.pData = AppMain.readAMEfile( AppMain.amBindGet( amb, index, out dir ) );
                    }
                    else if ( amb.files[index].IndexOf( ".ama", StringComparison.InvariantCultureIgnoreCase ) != -1 )
                    {
                        string dir;
                        data_work.pData = AppMain.readAMAFile( AppMain.amBindGet( amb, index, out dir ) );
                    }
                    else
                    {
                        string dir;
                        data_work.pData = AppMain.amBindGet( amb, index, out dir );
                    }
                    amb.buf[index] = data_work.pData;
                    data_work.num = 32768;
                    data_work.num += 1;
                }
            }
            else
            {
                data_work.num += 1;
            }
            return data_work.pData;
        }
        if ( amb != null )
        {
            if ( amb.buf[index] != null )
            {
                obj = amb.buf[index];
            }
            else if ( amb.files[index].IndexOf( ".amb", StringComparison.InvariantCultureIgnoreCase ) != -1 )
            {
                string dir2;
                obj = AppMain.readAMBFile( AppMain.amBindGet( amb, index, out dir2 ) );
                ( ( AppMain.AMS_AMB_HEADER )obj ).dir = dir2;
            }
            else if ( amb.files[index].IndexOf( ".ame", StringComparison.InvariantCultureIgnoreCase ) != -1 )
            {
                string dir2;
                obj = AppMain.readAMEfile( AppMain.amBindGet( amb, index, out dir2 ) );
            }
            else if ( amb.files[index].IndexOf( ".ama", StringComparison.InvariantCultureIgnoreCase ) != -1 )
            {
                string dir2;
                obj = AppMain.readAMAFile( AppMain.amBindGet( amb, index, out dir2 ) );
            }
            else
            {
                string dir2;
                obj = AppMain.amBindGet( amb, index, out dir2 );
            }
            amb.buf[index] = obj;
        }
        return obj;
    }

    // Token: 0x06001946 RID: 6470 RVA: 0x000E47FE File Offset: 0x000E29FE
    private static object ObjDataSet( AppMain.OBS_DATA_WORK pWork, object pData )
    {
        pWork.pData = pData;
        pWork.num += 1;
        return pWork.pData;
    }

    // Token: 0x06001947 RID: 6471 RVA: 0x000E481C File Offset: 0x000E2A1C
    private static object ObjDataGetInc( AppMain.OBS_DATA_WORK pWork )
    {
        if ( pWork.pData != null )
        {
            pWork.num += 1;
        }
        return pWork.pData;
    }

    // Token: 0x06001948 RID: 6472 RVA: 0x000E483C File Offset: 0x000E2A3C
    private static byte[] ObjDataLoad( AppMain.OBS_DATA_WORK data_work, string filename, object archive )
    {
        byte[] array = null;
        AppMain.sFile = filename;
        if ( data_work != null )
        {
            if ( data_work.pData == null )
            {
                if ( archive != null )
                {
                    AppMain.AmbChunk ambChunk = AppMain.amBindSearch((AppMain.AMS_AMB_HEADER)archive, AppMain.sFile);
                    array = new byte[ambChunk.length];
                    Buffer.BlockCopy( ambChunk.array, ambChunk.offset, array, 0, ambChunk.length );
                    data_work.pData = array;
                    data_work.num = 32768;
                    data_work.num += 1;
                }
                else
                {
                    byte[] pData;
                    AppMain.amFsRead( AppMain.sFile, out pData );
                    data_work.pData = pData;
                    if ( data_work.pData != null )
                    {
                        data_work.num += 1;
                    }
                }
            }
            else
            {
                data_work.num += 1;
            }
            return ( byte[] )data_work.pData;
        }
        if ( archive != null )
        {
            AppMain.AmbChunk ambChunk2 = AppMain.amBindSearch((AppMain.AMS_AMB_HEADER)archive, AppMain.sFile);
            array = new byte[ambChunk2.length];
            Buffer.BlockCopy( ambChunk2.array, ambChunk2.offset, array, 0, ambChunk2.length );
        }
        else
        {
            AppMain.amFsRead( AppMain.sFile, out array );
        }
        return array;
    }

    // Token: 0x06001949 RID: 6473 RVA: 0x000E4950 File Offset: 0x000E2B50
    private static void ObjDataRelease( AppMain.OBS_DATA_WORK pWork )
    {
        if ( pWork.num != 0 && pWork.pData != null )
        {
            pWork.num -= 1;
            if ( pWork.num == 0 )
            {
                pWork.pData = null;
            }
            if ( pWork.num == 32768 )
            {
                pWork.pData = null;
                pWork.num = 0;
            }
        }
    }
}