using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public partial class AppMain
{
    // Token: 0x020001A3 RID: 419
    public class AOS_STORAGE
    {
        // Token: 0x06002200 RID: 8704 RVA: 0x001420CD File Offset: 0x001402CD
        public AOS_STORAGE( bool init, int state, int error )
        {
            this.initialized = init;
            this.state = state;
            this.error = error;
        }

        // Token: 0x04004F51 RID: 20305
        public bool initialized;

        // Token: 0x04004F52 RID: 20306
        public int state;

        // Token: 0x04004F53 RID: 20307
        public int error;

        // Token: 0x04004F54 RID: 20308
        public bool save_success;

        // Token: 0x04004F55 RID: 20309
        public byte[] save_buf;

        // Token: 0x04004F56 RID: 20310
        public uint save_size;

        // Token: 0x04004F57 RID: 20311
        public bool load_success;

        // Token: 0x04004F58 RID: 20312
        public byte[] load_buf;

        // Token: 0x04004F59 RID: 20313
        public uint load_size;

        // Token: 0x04004F5A RID: 20314
        public bool del_success;

        // Token: 0x04004F5B RID: 20315
        public AppMain.AMS_TCB tcb;
    }

    // Token: 0x060007CC RID: 1996 RVA: 0x00044D80 File Offset: 0x00042F80
    private static void AoStorageInit()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        if ( aos_STORAGE.initialized )
        {
            return;
        }
        aos_STORAGE.initialized = false;
        aos_STORAGE.state = 0;
        aos_STORAGE.save_success = false;
        aos_STORAGE.save_buf = null;
        aos_STORAGE.save_size = 0U;
        aos_STORAGE.load_success = false;
        aos_STORAGE.load_buf = null;
        aos_STORAGE.load_size = 0U;
        aos_STORAGE.del_success = false;
        aos_STORAGE.tcb = null;
        aos_STORAGE.initialized = true;
    }

    // Token: 0x060007CD RID: 1997 RVA: 0x00044DEC File Offset: 0x00042FEC
    private static void AoStorageExit()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        if ( aos_STORAGE.initialized )
        {
            if ( aos_STORAGE.tcb != null )
            {
                AppMain.amTaskDelete( aos_STORAGE.tcb );
                aos_STORAGE.tcb = null;
            }
            aos_STORAGE.initialized = false;
            aos_STORAGE.state = 0;
            aos_STORAGE.save_success = false;
            aos_STORAGE.save_buf = null;
            aos_STORAGE.save_size = 0U;
            aos_STORAGE.load_success = false;
            aos_STORAGE.load_buf = null;
            aos_STORAGE.load_size = 0U;
            aos_STORAGE.del_success = false;
            aos_STORAGE.tcb = null;
            aos_STORAGE.initialized = false;
        }
    }

    // Token: 0x060007CE RID: 1998 RVA: 0x00044E6E File Offset: 0x0004306E
    private static void AoStorageSetSaveMsgFile( string file )
    {
    }

    // Token: 0x060007CF RID: 1999 RVA: 0x00044E70 File Offset: 0x00043070
    private static byte[] AoStorageGetSaveMsgFile()
    {
        return null;
    }

    // Token: 0x060007D0 RID: 2000 RVA: 0x00044E73 File Offset: 0x00043073
    private static bool AoStorageIsError()
    {
        return AppMain.aoStorageGetGlobal().error != 0;
    }

    // Token: 0x060007D1 RID: 2001 RVA: 0x00044E84 File Offset: 0x00043084
    private static int AoStorageGetError()
    {
        return AppMain.aoStorageGetGlobal().error;
    }

    // Token: 0x060007D2 RID: 2002 RVA: 0x00044E90 File Offset: 0x00043090
    private static void AoStorageClearError()
    {
        AppMain.aoStorageGetGlobal().error = 0;
    }

    // Token: 0x060007D3 RID: 2003 RVA: 0x00044EA0 File Offset: 0x000430A0
    private static void AoStorageSaveStart( byte[] data, uint size, bool is_first, bool is_new )
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        if ( aos_STORAGE.state != 0 )
        {
            AppMain.aoStorageSetError( 5 );
            return;
        }
        aos_STORAGE.state = 1;
        aos_STORAGE.save_success = false;
        aos_STORAGE.save_buf = data;
        aos_STORAGE.save_size = size;
        AppMain.aoStorageSaveThread();
        aos_STORAGE.tcb = AppMain.amTaskMake( new AppMain.TaskProc( AppMain.aoStorageSaveTaskProcedure ), null, 0U, 0U, 0U, "aoStorage::Save" );
        AppMain.amTaskStart( aos_STORAGE.tcb );
    }

    // Token: 0x060007D4 RID: 2004 RVA: 0x00044F0F File Offset: 0x0004310F
    private static bool AoStorageSaveFreeSpaceIsEnough()
    {
        return true;
    }

    // Token: 0x060007D5 RID: 2005 RVA: 0x00044F14 File Offset: 0x00043114
    private static bool AoStorageSaveIsFinished()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        return aos_STORAGE.state != 1;
    }

    // Token: 0x060007D6 RID: 2006 RVA: 0x00044F33 File Offset: 0x00043133
    private static bool AoStorageSaveIsSuccessed()
    {
        return AppMain.aoStorageGetGlobal().save_success;
    }

    // Token: 0x060007D7 RID: 2007 RVA: 0x00044F40 File Offset: 0x00043140
    private static void AoStorageLoadStart( byte[] data )
    {
        uint load_size = (uint)data.Length;
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        if ( aos_STORAGE.state != 0 )
        {
            AppMain.aoStorageSetError( 5 );
            return;
        }
        aos_STORAGE.state = 2;
        aos_STORAGE.load_success = false;
        aos_STORAGE.load_buf = data;
        aos_STORAGE.load_size = load_size;
        AppMain.aoStorageLoadThread();
        aos_STORAGE.tcb = AppMain.amTaskMake( new AppMain.TaskProc( AppMain.aoStorageLoadTaskProcedure ), null, 0U, 0U, 0U, "aoStorage::Load" );
        AppMain.amTaskStart( aos_STORAGE.tcb );
    }

    // Token: 0x060007D8 RID: 2008 RVA: 0x00044FB4 File Offset: 0x000431B4
    private static bool AoStorageLoadIsFinished()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        return aos_STORAGE.state != 2;
    }

    // Token: 0x060007D9 RID: 2009 RVA: 0x00044FD3 File Offset: 0x000431D3
    private static bool AoStorageLoadIsSuccessed()
    {
        return AppMain.aoStorageGetGlobal().load_success;
    }

    // Token: 0x060007DA RID: 2010 RVA: 0x00044FDF File Offset: 0x000431DF
    private static bool AoStorageLoadIsCreaterOwn()
    {
        return true;
    }

    // Token: 0x060007DB RID: 2011 RVA: 0x00044FE4 File Offset: 0x000431E4
    private static void AoStorageDeleteStart()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        if ( aos_STORAGE.state != 0 )
        {
            AppMain.aoStorageSetError( 5 );
            return;
        }
        AppMain.AoStorageClearError();
        string text = AppMain.aoStorageAllocSaveFilePath();
        try
        {
            if ( !File.Exists( text ) )
            {
                aos_STORAGE.del_success = false;
            }
            else
            {
                File.Delete( text );
                aos_STORAGE.del_success = true;
            }
        }
        catch ( Exception )
        {
            aos_STORAGE.del_success = false;
        }
        AppMain.aoStorageFreeSaveFilePath( text );
        aos_STORAGE.state = 0;
    }

    // Token: 0x060007DC RID: 2012 RVA: 0x00045064 File Offset: 0x00043264
    private static bool AoStorageDeleteIsFinished()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        return aos_STORAGE.state != 3;
    }

    // Token: 0x060007DD RID: 2013 RVA: 0x00045083 File Offset: 0x00043283
    private static bool AoStorageDeleteIsSuccessed()
    {
        return AppMain.aoStorageGetGlobal().del_success;
    }

    // Token: 0x060007DE RID: 2014 RVA: 0x0004508F File Offset: 0x0004328F
    private static bool AoStorageIsExecuteReal()
    {
        return true;
    }

    // Token: 0x060007DF RID: 2015 RVA: 0x00045092 File Offset: 0x00043292
    private static string aoStorageAllocSaveFilePath()
    {
        return AppMain.g_ao_storage_filename;
    }

    // Token: 0x060007E0 RID: 2016 RVA: 0x00045099 File Offset: 0x00043299
    private static void aoStorageFreeSaveFilePath( string path )
    {
    }

    // Token: 0x060007E1 RID: 2017 RVA: 0x0004509C File Offset: 0x0004329C
    private static uint AoStorageSaveMm( string path, byte[] data, int size )
    {
        try
        {
            using ( Stream isolatedStorageFileStream = File.Open( path, FileMode.OpenOrCreate ) )
            {
                isolatedStorageFileStream.Write( data, 0, size );
            }
            return 0U;
        }
        catch ( Exception )
        {
        }
        return 1U;
    }

    // Token: 0x060007E2 RID: 2018 RVA: 0x000450F4 File Offset: 0x000432F4
    private static void aoStorageSaveThread()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        string path = AppMain.aoStorageAllocSaveFilePath();
        uint num = AppMain.AoStorageSaveMm(path, aos_STORAGE.save_buf, (int)aos_STORAGE.save_size);
        AppMain.aoStorageFreeSaveFilePath( path );
        uint num2 = num;
        if ( num2 == 0U )
        {
            aos_STORAGE.save_success = true;
            return;
        }
        AppMain.aoStorageSetError( 2 );
    }

    // Token: 0x060007E3 RID: 2019 RVA: 0x0004513C File Offset: 0x0004333C
    private static void aoStorageSaveTaskProcedure( AppMain.AMS_TCB tcb )
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        AppMain.amTaskDelete( tcb );
        aos_STORAGE.save_buf = null;
        aos_STORAGE.save_size = 0U;
        aos_STORAGE.state = 0;
        aos_STORAGE.tcb = null;
    }

    // Token: 0x060007E4 RID: 2020 RVA: 0x00045174 File Offset: 0x00043374
    private static uint AoStorageLoadMm( string path, byte[] data, uint size )
    {
        try
        {
            if ( File.Exists( path ) )
            {
                using ( Stream isolatedStorageFileStream = File.Open( path, FileMode.Open ) )
                {
                    byte[] array = new byte[32768];
                    int num = 0;
                    using ( MemoryStream memoryStream = new MemoryStream() )
                    {
                        for (; ; )
                        {
                            int num2 = isolatedStorageFileStream.Read(array, 0, array.Length);
                            if ( num2 <= 0 )
                            {
                                break;
                            }
                            num = num2;
                            memoryStream.Write( array, 0, num2 );
                        }
                        Array.Copy( memoryStream.ToArray(), data, num );
                    }
                }
                return 0U;
            }
            return 1U;
        }
        catch ( Exception )
        {
        }
        return 1U;
    }

    // Token: 0x060007E5 RID: 2021 RVA: 0x00045230 File Offset: 0x00043430
    private static void aoStorageLoadThread()
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        string path = AppMain.aoStorageAllocSaveFilePath();
        uint num = AppMain.AoStorageLoadMm(path, aos_STORAGE.load_buf, aos_STORAGE.load_size);
        AppMain.aoStorageFreeSaveFilePath( path );
        uint num2 = num;
        if ( num2 == 0U )
        {
            aos_STORAGE.load_success = true;
            return;
        }
        AppMain.aoStorageSetError( 1 );
    }

    // Token: 0x060007E6 RID: 2022 RVA: 0x00045278 File Offset: 0x00043478
    private static void aoStorageLoadTaskProcedure( AppMain.AMS_TCB tcb )
    {
        AppMain.AOS_STORAGE aos_STORAGE = AppMain.aoStorageGetGlobal();
        AppMain.amTaskDelete( tcb );
        aos_STORAGE.load_buf = null;
        aos_STORAGE.load_size = 0U;
        aos_STORAGE.state = 0;
        aos_STORAGE.tcb = null;
    }

    // Token: 0x060007E7 RID: 2023 RVA: 0x000452AD File Offset: 0x000434AD
    private static AppMain.AOS_STORAGE aoStorageGetGlobal()
    {
        return AppMain.g_ao_storage;
    }

    // Token: 0x060007E8 RID: 2024 RVA: 0x000452B4 File Offset: 0x000434B4
    private static void aoStorageSetError( int error )
    {
        if ( AppMain.g_ao_storage.error == 0 || AppMain.g_ao_storage.error == 5 )
        {
            AppMain.g_ao_storage.error = error;
        }
    }
}