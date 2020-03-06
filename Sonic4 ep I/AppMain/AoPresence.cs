using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200007F RID: 127
    private enum AOE_PRESENCE
    {
        // Token: 0x040049BE RID: 18878
        AOD_PRESENCE_STANDBY,
        // Token: 0x040049BF RID: 18879
        AOD_PRESENCE_Z11T,
        // Token: 0x040049C0 RID: 18880
        AOD_PRESENCE_Z11S,
        // Token: 0x040049C1 RID: 18881
        AOD_PRESENCE_Z12T,
        // Token: 0x040049C2 RID: 18882
        AOD_PRESENCE_Z12S,
        // Token: 0x040049C3 RID: 18883
        AOD_PRESENCE_Z13T,
        // Token: 0x040049C4 RID: 18884
        AOD_PRESENCE_Z13S,
        // Token: 0x040049C5 RID: 18885
        AOD_PRESENCE_Z1BT,
        // Token: 0x040049C6 RID: 18886
        AOD_PRESENCE_Z1BS,
        // Token: 0x040049C7 RID: 18887
        AOD_PRESENCE_Z21T,
        // Token: 0x040049C8 RID: 18888
        AOD_PRESENCE_Z21S,
        // Token: 0x040049C9 RID: 18889
        AOD_PRESENCE_Z22T,
        // Token: 0x040049CA RID: 18890
        AOD_PRESENCE_Z22S,
        // Token: 0x040049CB RID: 18891
        AOD_PRESENCE_Z23T,
        // Token: 0x040049CC RID: 18892
        AOD_PRESENCE_Z23S,
        // Token: 0x040049CD RID: 18893
        AOD_PRESENCE_Z2BT,
        // Token: 0x040049CE RID: 18894
        AOD_PRESENCE_Z2BS,
        // Token: 0x040049CF RID: 18895
        AOD_PRESENCE_Z31T,
        // Token: 0x040049D0 RID: 18896
        AOD_PRESENCE_Z31S,
        // Token: 0x040049D1 RID: 18897
        AOD_PRESENCE_Z32T,
        // Token: 0x040049D2 RID: 18898
        AOD_PRESENCE_Z32S,
        // Token: 0x040049D3 RID: 18899
        AOD_PRESENCE_Z33T,
        // Token: 0x040049D4 RID: 18900
        AOD_PRESENCE_Z33S,
        // Token: 0x040049D5 RID: 18901
        AOD_PRESENCE_Z3BT,
        // Token: 0x040049D6 RID: 18902
        AOD_PRESENCE_Z3BS,
        // Token: 0x040049D7 RID: 18903
        AOD_PRESENCE_Z41T,
        // Token: 0x040049D8 RID: 18904
        AOD_PRESENCE_Z41S,
        // Token: 0x040049D9 RID: 18905
        AOD_PRESENCE_Z42T,
        // Token: 0x040049DA RID: 18906
        AOD_PRESENCE_Z42S,
        // Token: 0x040049DB RID: 18907
        AOD_PRESENCE_Z43T,
        // Token: 0x040049DC RID: 18908
        AOD_PRESENCE_Z43S,
        // Token: 0x040049DD RID: 18909
        AOD_PRESENCE_Z4BT,
        // Token: 0x040049DE RID: 18910
        AOD_PRESENCE_Z4BS,
        // Token: 0x040049DF RID: 18911
        AOD_PRESENCE_ZFBT,
        // Token: 0x040049E0 RID: 18912
        AOD_PRESENCE_ZFBS,
        // Token: 0x040049E1 RID: 18913
        AOD_PRESENCE_SS1T,
        // Token: 0x040049E2 RID: 18914
        AOD_PRESENCE_SS1S,
        // Token: 0x040049E3 RID: 18915
        AOD_PRESENCE_SS2T,
        // Token: 0x040049E4 RID: 18916
        AOD_PRESENCE_SS2S,
        // Token: 0x040049E5 RID: 18917
        AOD_PRESENCE_SS3T,
        // Token: 0x040049E6 RID: 18918
        AOD_PRESENCE_SS3S,
        // Token: 0x040049E7 RID: 18919
        AOD_PRESENCE_SS4T,
        // Token: 0x040049E8 RID: 18920
        AOD_PRESENCE_SS4S,
        // Token: 0x040049E9 RID: 18921
        AOD_PRESENCE_SS5T,
        // Token: 0x040049EA RID: 18922
        AOD_PRESENCE_SS5S,
        // Token: 0x040049EB RID: 18923
        AOD_PRESENCE_SS6T,
        // Token: 0x040049EC RID: 18924
        AOD_PRESENCE_SS6S,
        // Token: 0x040049ED RID: 18925
        AOD_PRESENCE_SS7T,
        // Token: 0x040049EE RID: 18926
        AOD_PRESENCE_SS7S,
        // Token: 0x040049EF RID: 18927
        AOD_PRESENCE_NUM,
        // Token: 0x040049F0 RID: 18928
        AOD_PRESENCE_NONE,
        // Token: 0x040049F1 RID: 18929
        AOD_PRESENCE_DEFAULT = 0
    }

    // Token: 0x060002BB RID: 699 RVA: 0x00016F33 File Offset: 0x00015133
    private static void AoPresenceInit()
    {
    }

    // Token: 0x060002BC RID: 700 RVA: 0x00016F35 File Offset: 0x00015135
    private static bool AoPresenceInitialized()
    {
        return true;
    }

    // Token: 0x060002BD RID: 701 RVA: 0x00016F38 File Offset: 0x00015138
    private static void AoPresenceExit()
    {
    }

    // Token: 0x060002BE RID: 702 RVA: 0x00016F3A File Offset: 0x0001513A
    private static void AoPresenceSet( AppMain.AOE_PRESENCE presence, bool is_trial )
    {
    }
}