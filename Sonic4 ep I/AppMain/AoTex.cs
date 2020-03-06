using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000232 RID: 562
    public class AOS_TEXTURE : AppMain.IClearable
    {
        // Token: 0x06002393 RID: 9107 RVA: 0x00149142 File Offset: 0x00147342
        public void Clear()
        {
            this.texlist = null;
            this.texlist_buf = null;
            this.reg_id = 0;
            this.amb = null;
            this.txb = null;
        }

        // Token: 0x04005775 RID: 22389
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04005776 RID: 22390
        public object texlist_buf;

        // Token: 0x04005777 RID: 22391
        public int reg_id;

        // Token: 0x04005778 RID: 22392
        public AppMain.AMS_AMB_HEADER amb;

        // Token: 0x04005779 RID: 22393
        public AppMain.TXB_HEADER txb;
    }

    // Token: 0x06000CF4 RID: 3316 RVA: 0x000747B0 File Offset: 0x000729B0
    public static void AoTexBuild( AppMain.AOS_TEXTURE tex, AppMain.AMS_AMB_HEADER amb )
    {
        if ( tex == null )
        {
            return;
        }
        if ( amb == null )
        {
            return;
        }
        AppMain.aoTexInitTex( tex );
        tex.amb = amb;
        AppMain.AmbChunk ambChunk = AppMain.amBindSearchEx(amb, ".txb");
        tex.txb = AppMain.readTXBfile( ambChunk.array, ambChunk.offset, amb.dir );
        AppMain.TXB_HEADER txb = tex.txb;
    }

    // Token: 0x06000CF5 RID: 3317 RVA: 0x00074804 File Offset: 0x00072A04
    public static void AoTexLoad( AppMain.AOS_TEXTURE tex )
    {
        if ( tex == null || tex.txb == null || tex.amb == null || tex.reg_id >= 0 )
        {
            return;
        }
        uint num = AppMain.amTxbGetCount(tex.txb);
        AppMain.nnSetUpTexlist( out tex.texlist, ( int )num, ref tex.texlist_buf );
        AppMain.NNS_TEXFILELIST texfilelist = AppMain.amTxbGetTexFileList(tex.txb);
        tex.reg_id = AppMain.amTextureLoad( tex.texlist, texfilelist, null, tex.amb );
    }

    // Token: 0x06000CF6 RID: 3318 RVA: 0x00074871 File Offset: 0x00072A71
    public static bool AoTexIsLoaded( AppMain.AOS_TEXTURE tex )
    {
        if ( tex == null || tex.texlist == null )
        {
            return false;
        }
        if ( tex.reg_id >= 0 && AppMain.amDrawIsRegistComplete( tex.reg_id ) )
        {
            tex.reg_id = -1;
        }
        return tex.reg_id < 0;
    }

    // Token: 0x06000CF7 RID: 3319 RVA: 0x000748A9 File Offset: 0x00072AA9
    public static AppMain.NNS_TEXLIST AoTexGetTexList( AppMain.AOS_TEXTURE tex )
    {
        if ( tex == null || tex.texlist == null || tex.reg_id >= 0 )
        {
            return null;
        }
        return tex.texlist;
    }

    // Token: 0x06000CF8 RID: 3320 RVA: 0x000748C7 File Offset: 0x00072AC7
    public AppMain.TXB_HEADER AoTexGetTxb( ref AppMain.AOS_TEXTURE tex )
    {
        if ( tex == null || tex.texlist == null || tex.reg_id >= 0 )
        {
            return null;
        }
        return tex.txb;
    }

    // Token: 0x06000CF9 RID: 3321 RVA: 0x000748E9 File Offset: 0x00072AE9
    private static void AoTexRelease( AppMain.AOS_TEXTURE tex )
    {
        if ( !AppMain.AoTexIsLoaded( tex ) )
        {
            return;
        }
        tex.reg_id = AppMain.amTextureRelease( tex.texlist );
        tex.texlist = null;
    }

    // Token: 0x06000CFA RID: 3322 RVA: 0x0007490C File Offset: 0x00072B0C
    private static bool AoTexIsReleased( AppMain.AOS_TEXTURE tex )
    {
        if ( tex == null || tex.reg_id < 0 )
        {
            return true;
        }
        if ( AppMain.amDrawIsRegistComplete( tex.reg_id ) )
        {
            AppMain.aoTexInitTex( tex );
            return true;
        }
        return false;
    }

    // Token: 0x06000CFB RID: 3323 RVA: 0x00074932 File Offset: 0x00072B32
    private static void aoTexInitTex( AppMain.AOS_TEXTURE tex )
    {
        tex.texlist = null;
        tex.reg_id = -1;
        tex.amb = null;
        tex.txb = null;
    }
}