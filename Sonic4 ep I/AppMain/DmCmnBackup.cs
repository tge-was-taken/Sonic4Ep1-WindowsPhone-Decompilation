using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gs.backup;

public partial class AppMain
{
    // Token: 0x060009D3 RID: 2515 RVA: 0x00057848 File Offset: 0x00055A48
    private static void DmCmnBackupLoad()
    {
        SBackup sbackup = SBackup.CreateInstance();
        AppMain.AoStorageClearError();
        byte[] data = sbackup.getData();
        AppMain.AoStorageLoadStart( data );
        sbackup.setData( data );
    }

    // Token: 0x060009D4 RID: 2516 RVA: 0x00057874 File Offset: 0x00055A74
    private static bool DmCmnBackupIsLoadFinished()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( AppMain.AoStorageLoadIsFinished() )
        {
            gss_MAIN_SYS_INFO.cmp_backup.setData( gss_MAIN_SYS_INFO.backup.getData() );
            return true;
        }
        return false;
    }

    // Token: 0x060009D5 RID: 2517 RVA: 0x000578A8 File Offset: 0x00055AA8
    private static bool DmCmnBackupIsLoadSuccessed()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        bool result;
        if ( AppMain.AoStorageLoadIsSuccessed() )
        {
            gss_MAIN_SYS_INFO.is_save_run = 1U;
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

    // Token: 0x060009D6 RID: 2518 RVA: 0x000578D4 File Offset: 0x00055AD4
    private static void DmCmnBackupSave( bool is_first, bool is_new, bool is_del )
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        SBackup sbackup = SBackup.CreateInstance();
        byte[] data = sbackup.getData();
        uint size = (uint)data.Length;
        AppMain.AoStorageClearError();
        if ( is_first )
        {
            AppMain.AoStorageSaveStart( data, size, true, false );
            gss_MAIN_SYS_INFO.cmp_backup.setData( gss_MAIN_SYS_INFO.backup.getData() );
            return;
        }
        if ( is_new )
        {
            AppMain.AoStorageSaveStart( data, size, false, true );
            gss_MAIN_SYS_INFO.cmp_backup.setData( gss_MAIN_SYS_INFO.backup.getData() );
            return;
        }
        if ( gss_MAIN_SYS_INFO.is_save_run != 0U )
        {
            bool flag = AppMain.dmCmnBackupIsCmpSaveData();
            if ( flag )
            {
                AppMain.AoStorageSaveStart( data, size, false, false );
                gss_MAIN_SYS_INFO.cmp_backup.setData( gss_MAIN_SYS_INFO.backup.getData() );
            }
        }
    }

    // Token: 0x060009D7 RID: 2519 RVA: 0x00057978 File Offset: 0x00055B78
    private static bool DmCmnBackupIsSaveFinished()
    {
        return AppMain.AoStorageSaveIsFinished();
    }

    // Token: 0x060009D8 RID: 2520 RVA: 0x00057984 File Offset: 0x00055B84
    private static bool DmCmnBackupIsSaveSuccessed()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        bool result;
        if ( AppMain.AoStorageSaveIsSuccessed() )
        {
            gss_MAIN_SYS_INFO.is_save_run = 1U;
            result = true;
        }
        else
        {
            int num = AppMain.AoStorageGetError();
            if ( num == 2 )
            {
                gss_MAIN_SYS_INFO.is_save_run = 0U;
                result = true;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }

    // Token: 0x060009D9 RID: 2521 RVA: 0x000579C8 File Offset: 0x00055BC8
    private static bool dmCmnBackupIsCmpSaveData()
    {
        return !AppMain.dmCmnBackupMathCompare();
    }

    // Token: 0x060009DA RID: 2522 RVA: 0x000579E8 File Offset: 0x00055BE8
    private static bool dmCmnBackupMathCompare()
    {
        AppMain.GSS_MAIN_SYS_INFO gss_MAIN_SYS_INFO = AppMain.GsGetMainSysInfo();
        if ( gss_MAIN_SYS_INFO.is_save_run == 0U )
        {
            return true;
        }
        SSystem ssystem = SSystem.CreateInstance();
        SStage sstage = SStage.CreateInstance();
        SSpecial sspecial = SSpecial.CreateInstance();
        SOption soption = SOption.CreateInstance();
        SSystem system = gss_MAIN_SYS_INFO.cmp_backup.GetSystem();
        SStage sstage2 = gss_MAIN_SYS_INFO.cmp_backup.GetStage();
        SSpecial special = gss_MAIN_SYS_INFO.cmp_backup.GetSpecial();
        SOption option = gss_MAIN_SYS_INFO.cmp_backup.GetOption();
        if ( ssystem.GetPlayerStock() != system.GetPlayerStock() )
        {
            return false;
        }
        if ( ssystem.GetKilled() != system.GetKilled() )
        {
            return false;
        }
        if ( ssystem.GetClearCount() != system.GetClearCount() )
        {
            return false;
        }
        for ( int i = 0; i < 7; i++ )
        {
            SSystem.EAnnounce index = (SSystem.EAnnounce)i;
            if ( ssystem.IsAnnounce( index ) != system.IsAnnounce( index ) )
            {
                return false;
            }
        }
        return AppMain.memcmp( sstage2.getData(), sstage.getData() ) == 0 && AppMain.memcmp( special.getData(), sspecial.getData() ) == 0 && AppMain.memcmp( option.getData(), soption.getData() ) == 0;
    }
}