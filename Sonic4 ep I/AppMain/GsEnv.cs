using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sonic4ep1;
using System.Globalization;

public partial class AppMain 
{
    // Token: 0x060017CE RID: 6094 RVA: 0x000D3F44 File Offset: 0x000D2144
    private static void GsEnvInit()
    {
        AppMain.g_gs_env_region = AppMain.GsEnvGetRegionIphone();
        AppMain.g_gs_env_language = AppMain.GsEnvGetLanguageIphone();
        switch ( AppMain.g_gs_env_language )
        {
            case 0:
                Strings.Culture = new CultureInfo( "ja-JP" );
                return;
            case 1:
                Strings.Culture = new CultureInfo( "en-US" );
                return;
            case 2:
                Strings.Culture = new CultureInfo( "fr-FR" );
                return;
            case 3:
                Strings.Culture = new CultureInfo( "it-IT" );
                return;
            case 4:
                Strings.Culture = new CultureInfo( "de-DE" );
                return;
            case 5:
                Strings.Culture = new CultureInfo( "es-ES" );
                return;
            case 6:
                Strings.Culture = new CultureInfo( "fi-FI" );
                return;
            case 7:
                Strings.Culture = new CultureInfo( "pt-BR" );
                return;
            case 8:
                Strings.Culture = new CultureInfo( "ru-RU" );
                return;
            case 9:
                Strings.Culture = new CultureInfo( "zh-CN" );
                return;
            case 10:
                Strings.Culture = new CultureInfo( "zh-TW" );
                return;
            default:
                Strings.Culture = new CultureInfo( "en" );
                return;
        }
    }

    // Token: 0x060017CF RID: 6095 RVA: 0x000D4061 File Offset: 0x000D2261
    private static AppMain.GSE_REGION GsEnvGetRegion()
    {
        return AppMain.g_gs_env_region;
    }

    // Token: 0x060017D0 RID: 6096 RVA: 0x000D4068 File Offset: 0x000D2268
    private static bool GsEnvIsRegionAsia()
    {
        return AppMain.g_gs_env_is_asia;
    }

    // Token: 0x060017D1 RID: 6097 RVA: 0x000D406F File Offset: 0x000D226F
    public static int GsEnvGetLanguage()
    {
        return AppMain.g_gs_env_language;
    }

    // Token: 0x060017D2 RID: 6098 RVA: 0x000D4076 File Offset: 0x000D2276
    private static AppMain.GSE_DECIDE_KEY GeEnvGetDecideKey()
    {
        return AppMain.g_gs_env_decide_key;
    }

    // Token: 0x060017D3 RID: 6099 RVA: 0x000D407D File Offset: 0x000D227D
    private static char GsEnvDebugGetDecideKeyChar()
    {
        return 'A';
    }

    // Token: 0x060017D4 RID: 6100 RVA: 0x000D4084 File Offset: 0x000D2284
    private static AppMain.GSE_REGION GsEnvGetRegionIphone()
    {
        AppMain.CRegionTable[] array = new AppMain.CRegionTable[]
        {
            new AppMain.CRegionTable("JP", AppMain.GSE_REGION.GSD_REGION_JP),
            new AppMain.CRegionTable("US", AppMain.GSE_REGION.GSD_REGION_US),
            new AppMain.CRegionTable("CA", AppMain.GSE_REGION.GSD_REGION_US),
            new AppMain.CRegionTable("PM", AppMain.GSE_REGION.GSD_REGION_US),
            new AppMain.CRegionTable("FR", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("IT", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("DE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("ES", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("AL", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("AD", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("AZ", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("AT", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("AM", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("BE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("BA", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("BG", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("BY", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("HR", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("CZ", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("DK", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("EE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("FO", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("FI", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("AX", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("GE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("GI", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("GR", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("GL", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("VA", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("HU", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("IS", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("IE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("LV", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("LI", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("LT", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("LU", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("MC", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("MD", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("ME", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("NL", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("NO", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("PL", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("PT", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("RO", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("SM", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("RS", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("SK", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("SI", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("SJ", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("SE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("CH", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("UA", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("MK", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("GB", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("GG", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("JE", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("IM", AppMain.GSE_REGION.GSD_REGION_EU),
            new AppMain.CRegionTable("BR", AppMain.GSE_REGION.GSD_REGION_US),
            new AppMain.CRegionTable("RU", AppMain.GSE_REGION.GSD_REGION_EU)
        };
        string name = CultureInfo.CurrentCulture.Name;
        for ( int i = 0; i < array.Length; i++ )
        {
            if ( name.IndexOf( array[i].country ) != -1 )
            {
                return array[i].region;
            }
        }
        return AppMain.GSE_REGION.GSD_REGION_US;
    }

    // Token: 0x060017D5 RID: 6101 RVA: 0x000D4658 File Offset: 0x000D2858
    private static int GsEnvGetLanguageIphone()
    {
        AppMain.CLanguageTable[] array = new AppMain.CLanguageTable[]
        {
            new AppMain.CLanguageTable("ja-JP", 0),
            new AppMain.CLanguageTable("en-US", 1),
            new AppMain.CLanguageTable("fr-FR", 2),
            new AppMain.CLanguageTable("it-IT", 3),
            new AppMain.CLanguageTable("de-DE", 4),
            new AppMain.CLanguageTable("es-ES", 5),
            new AppMain.CLanguageTable("fi-FI", 6),
            new AppMain.CLanguageTable("pt-BR", 7),
            new AppMain.CLanguageTable("ru-RU", 8),
            new AppMain.CLanguageTable("zh-CN", 9),
            new AppMain.CLanguageTable("zh-Hans", 9),
            new AppMain.CLanguageTable("zh-HK", 10),
            new AppMain.CLanguageTable("zh-MO", 10),
            new AppMain.CLanguageTable("zh-SG", 10),
            new AppMain.CLanguageTable("zh-TW", 10),
            new AppMain.CLanguageTable("zh-Hant", 10)
        };
        string name = CultureInfo.CurrentCulture.Name;
        for ( int i = 0; i < array.Length; i++ )
        {
            if ( name.IndexOf( array[i].lang ) != -1 )
            {
                return array[i].code;
            }
        }
        return 1;
    }
}
