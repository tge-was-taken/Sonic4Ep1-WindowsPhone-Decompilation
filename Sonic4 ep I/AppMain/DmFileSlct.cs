using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200015B RID: 347
    private enum DME_FILESLCT_NEXT_EVT
    {
        // Token: 0x04004DD0 RID: 19920
        DME_FILESLCT_NEXT_EVT_MAINGAME,
        // Token: 0x04004DD1 RID: 19921
        DME_FILESLCT_NEXT_EVT_OPTION,
        // Token: 0x04004DD2 RID: 19922
        DME_FILESLCT_NEXT_EVT_MAINMENU,
        // Token: 0x04004DD3 RID: 19923
        DME_FILESLCT_NEXT_EVT_TITLE,
        // Token: 0x04004DD4 RID: 19924
        DME_FILESLCT_NEXT_EVT_MAX
    }

    // Token: 0x0200015C RID: 348
    private enum DME_FILESLCT_DATA_TYPE
    {
        // Token: 0x04004DD6 RID: 19926
        DME_FILESLCT_DATA_TYPE_CMN_DATA,
        // Token: 0x04004DD7 RID: 19927
        DME_FILESLCT_DATA_TYPE_LANG_DATA,
        // Token: 0x04004DD8 RID: 19928
        DME_FILESLCT_DATA_TYPE_MAX,
        // Token: 0x04004DD9 RID: 19929
        DME_FILESLCT_DATA_TYPE_NONE
    }

    // Token: 0x0200015D RID: 349
    private enum DME_FILESLCT_WIN
    {
        // Token: 0x04004DDB RID: 19931
        DME_FILESLCT_WIN_IS_DEL_FILE,
        // Token: 0x04004DDC RID: 19932
        DME_FILESLCT_WIN_DELETING_FILE,
        // Token: 0x04004DDD RID: 19933
        DME_FILESLCT_WIN_NUM,
        // Token: 0x04004DDE RID: 19934
        DME_FILESLCT_WIN_NONE
    }

    // Token: 0x0200015E RID: 350
    private enum DME_FILESLCT_SAVE_FILE
    {
        // Token: 0x04004DE0 RID: 19936
        DME_FILESLCT_SAVE_FILE_1,
        // Token: 0x04004DE1 RID: 19937
        DME_FILESLCT_SAVE_FILE_2,
        // Token: 0x04004DE2 RID: 19938
        DME_FILESLCT_SAVE_FILE_3,
        // Token: 0x04004DE3 RID: 19939
        DME_FILESLCT_SAVE_FILE_4,
        // Token: 0x04004DE4 RID: 19940
        DME_FILESLCT_SAVE_FILE_5,
        // Token: 0x04004DE5 RID: 19941
        DME_FILESLCT_SAVE_FILE_6,
        // Token: 0x04004DE6 RID: 19942
        DME_FILESLCT_SAVE_FILE_NUM,
        // Token: 0x04004DE7 RID: 19943
        DME_FILESLCT_SAVE_FILE_NONE
    }

    // Token: 0x0200015F RID: 351
    private enum DME_FILESLCT_ACT
    {
        // Token: 0x04004DE9 RID: 19945
        ACT_BACK_BG,
        // Token: 0x04004DEA RID: 19946
        ACT_ARROW_UP,
        // Token: 0x04004DEB RID: 19947
        ACT_ARROW_DOWN,
        // Token: 0x04004DEC RID: 19948
        ACT_UP_HIDE_BG,
        // Token: 0x04004DED RID: 19949
        ACT_DOWN_HIDE_BG,
        // Token: 0x04004DEE RID: 19950
        ACT_TEX_DEL,
        // Token: 0x04004DEF RID: 19951
        ACT_TEX_EXP1,
        // Token: 0x04004DF0 RID: 19952
        ACT_TEX_EXP2,
        // Token: 0x04004DF1 RID: 19953
        ACT_FILE_TAB1,
        // Token: 0x04004DF2 RID: 19954
        ACT_FILE_SCR_BASE,
        // Token: 0x04004DF3 RID: 19955
        ACT_FILE_TAB_NUM,
        // Token: 0x04004DF4 RID: 19956
        ACT_FILE_TAB_EMER,
        // Token: 0x04004DF5 RID: 19957
        ACT_FILE_SCR,
        // Token: 0x04004DF6 RID: 19958
        ACT_FILE_TIME_H_1,
        // Token: 0x04004DF7 RID: 19959
        ACT_FILE_TIME_H_2,
        // Token: 0x04004DF8 RID: 19960
        ACT_FILE_TIME_COLON,
        // Token: 0x04004DF9 RID: 19961
        ACT_FILE_TIME_M_1,
        // Token: 0x04004DFA RID: 19962
        ACT_FILE_TIME_M_2,
        // Token: 0x04004DFB RID: 19963
        ACT_FILE_ICON_EMER1,
        // Token: 0x04004DFC RID: 19964
        ACT_FILE_ICON_EMER2,
        // Token: 0x04004DFD RID: 19965
        ACT_FILE_ICON_EMER3,
        // Token: 0x04004DFE RID: 19966
        ACT_FILE_ICON_EMER4,
        // Token: 0x04004DFF RID: 19967
        ACT_FILE_ICON_EMER5,
        // Token: 0x04004E00 RID: 19968
        ACT_FILE_ICON_EMER6,
        // Token: 0x04004E01 RID: 19969
        ACT_FILE_ICON_EMER7,
        // Token: 0x04004E02 RID: 19970
        ACT_FILE_TEX_ALPHA1,
        // Token: 0x04004E03 RID: 19971
        ACT_FILE_TEX_ALPHA2,
        // Token: 0x04004E04 RID: 19972
        ACT_FILE_TEX_ALPHA3,
        // Token: 0x04004E05 RID: 19973
        ACT_FILE_TEX_ALPHA4,
        // Token: 0x04004E06 RID: 19974
        ACT_FILE_TEX_ALPHA5,
        // Token: 0x04004E07 RID: 19975
        ACT_FILE_TEX_ALPHA6,
        // Token: 0x04004E08 RID: 19976
        ACT_FILE_TEX_ALPHA7,
        // Token: 0x04004E09 RID: 19977
        ACT_FILE_TEX_ALPHA8,
        // Token: 0x04004E0A RID: 19978
        ACT_FILE_TEX_ALPHA9,
        // Token: 0x04004E0B RID: 19979
        ACT_FILE_TEX_ALPHA10,
        // Token: 0x04004E0C RID: 19980
        ACT_FILE_TAB3_B,
        // Token: 0x04004E0D RID: 19981
        ACT_FILE_TAB3_A,
        // Token: 0x04004E0E RID: 19982
        ACT_FILE_TAB3_C,
        // Token: 0x04004E0F RID: 19983
        ACT_FILE_TAB4_B,
        // Token: 0x04004E10 RID: 19984
        ACT_FILE_TAB4_A,
        // Token: 0x04004E11 RID: 19985
        ACT_FILE_TAB4_C,
        // Token: 0x04004E12 RID: 19986
        ACT_FILE_YEAR1,
        // Token: 0x04004E13 RID: 19987
        ACT_FILE_YEAR2,
        // Token: 0x04004E14 RID: 19988
        ACT_FILE_YEAR3,
        // Token: 0x04004E15 RID: 19989
        ACT_FILE_YEAR4,
        // Token: 0x04004E16 RID: 19990
        ACT_FILE_SLASH1,
        // Token: 0x04004E17 RID: 19991
        ACT_FILE_MON1,
        // Token: 0x04004E18 RID: 19992
        ACT_FILE_MON2,
        // Token: 0x04004E19 RID: 19993
        ACT_FILE_SLASH2,
        // Token: 0x04004E1A RID: 19994
        ACT_FILE_DAY1,
        // Token: 0x04004E1B RID: 19995
        ACT_FILE_DAY2,
        // Token: 0x04004E1C RID: 19996
        ACT_FILE_YEAR1_US,
        // Token: 0x04004E1D RID: 19997
        ACT_FILE_YEAR2_US,
        // Token: 0x04004E1E RID: 19998
        ACT_FILE_YEAR3_US,
        // Token: 0x04004E1F RID: 19999
        ACT_FILE_YEAR4_US,
        // Token: 0x04004E20 RID: 20000
        ACT_FILE_SLASH1_US,
        // Token: 0x04004E21 RID: 20001
        ACT_FILE_MON1_US,
        // Token: 0x04004E22 RID: 20002
        ACT_FILE_MON2_US,
        // Token: 0x04004E23 RID: 20003
        ACT_FILE_SLASH2_US,
        // Token: 0x04004E24 RID: 20004
        ACT_FILE_DAY1_US,
        // Token: 0x04004E25 RID: 20005
        ACT_FILE_DAY2_US,
        // Token: 0x04004E26 RID: 20006
        ACT_FILE_YEAR1_EU,
        // Token: 0x04004E27 RID: 20007
        ACT_FILE_YEAR2_EU,
        // Token: 0x04004E28 RID: 20008
        ACT_FILE_YEAR3_EU,
        // Token: 0x04004E29 RID: 20009
        ACT_FILE_YEAR4_EU,
        // Token: 0x04004E2A RID: 20010
        ACT_FILE_SLASH1_EU,
        // Token: 0x04004E2B RID: 20011
        ACT_FILE_MON1_EU,
        // Token: 0x04004E2C RID: 20012
        ACT_FILE_MON2_EU,
        // Token: 0x04004E2D RID: 20013
        ACT_FILE_SLASH2_EU,
        // Token: 0x04004E2E RID: 20014
        ACT_FILE_DAY1_EU,
        // Token: 0x04004E2F RID: 20015
        ACT_FILE_DAY2_EU,
        // Token: 0x04004E30 RID: 20016
        ACT_FILE_TEX_NAME,
        // Token: 0x04004E31 RID: 20017
        ACT_FILE_TEX_NEWGAME,
        // Token: 0x04004E32 RID: 20018
        ACT_WIN_TEX_BACK,
        // Token: 0x04004E33 RID: 20019
        ACT_WIN_TEX_MSG,
        // Token: 0x04004E34 RID: 20020
        ACT_FILESLCT_BACK_BTN,
        // Token: 0x04004E35 RID: 20021
        ACT_BTN_CANCEL,
        // Token: 0x04004E36 RID: 20022
        ACT_DEL_BTN,
        // Token: 0x04004E37 RID: 20023
        ACT_OBI_C,
        // Token: 0x04004E38 RID: 20024
        ACT_OBI_L,
        // Token: 0x04004E39 RID: 20025
        ACT_OBI_R,
        // Token: 0x04004E3A RID: 20026
        ACT_OBI_R2,
        // Token: 0x04004E3B RID: 20027
        ACT_WIN_LINE,
        // Token: 0x04004E3C RID: 20028
        ACT_TEX_WINTITLE,
        // Token: 0x04004E3D RID: 20029
        ACT_TEX_YES,
        // Token: 0x04004E3E RID: 20030
        ACT_TEX_NO,
        // Token: 0x04004E3F RID: 20031
        ACT_TEX_BACK,
        // Token: 0x04004E40 RID: 20032
        ACT_TEX_FIX_BACK,
        // Token: 0x04004E41 RID: 20033
        ACT_NUM,
        // Token: 0x04004E42 RID: 20034
        ACT_TAB_ALL_SRC = 8,
        // Token: 0x04004E43 RID: 20035
        ACT_TAB_ALL_DST = 37,
        // Token: 0x04004E44 RID: 20036
        ACT_NONE
    }
}