using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0200010F RID: 271
    public class GMS_DECOGLARE_PARAM
    {
        // Token: 0x06001FCB RID: 8139 RVA: 0x0013D457 File Offset: 0x0013B657
        public GMS_DECOGLARE_PARAM( uint rgba, float Size, float Sort, int Ablend )
        {
            this.color = rgba;
            this.size = Size;
            this.sort_z = Sort;
            this.ablend = Ablend;
        }

        // Token: 0x04004C6C RID: 19564
        public readonly uint color;

        // Token: 0x04004C6D RID: 19565
        public float size;

        // Token: 0x04004C6E RID: 19566
        public float sort_z;

        // Token: 0x04004C6F RID: 19567
        public int ablend;
    }

    // Token: 0x02000110 RID: 272
    public class GMDECO_GLARE_INTERFACE : AppMain.IClearable
    {
        // Token: 0x06001FCC RID: 8140 RVA: 0x0013D47C File Offset: 0x0013B67C
        public void Clear()
        {
            this.amb_header = null;
            this.tex_buf = null;
            this.texlistbuf = null;
            this.texlist = null;
            this.texId = ( this.regId = ( this.drawFlag = 0 ) );
        }

        // Token: 0x04004C70 RID: 19568
        public AppMain.AMS_AMB_HEADER amb_header;

        // Token: 0x04004C71 RID: 19569
        public AppMain.NNS_TEXFILELIST tex_buf;

        // Token: 0x04004C72 RID: 19570
        public object texlistbuf;

        // Token: 0x04004C73 RID: 19571
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04004C74 RID: 19572
        public int texId;

        // Token: 0x04004C75 RID: 19573
        public int regId;

        // Token: 0x04004C76 RID: 19574
        public int drawFlag;
    }

    // Token: 0x060004F3 RID: 1267 RVA: 0x0002A5F4 File Offset: 0x000287F4
    public static void GmDecoGlareSetData( AppMain.AMS_AMB_HEADER amb_header )
    {
        AppMain.pIF.Clear();
        string dir;
        AppMain.pIF.amb_header = AppMain.readAMBFile( AppMain.amBindGet( amb_header, 1, out dir ) );
        AppMain.pIF.amb_header.dir = dir;
        AppMain.TXB_HEADER txb = AppMain.readTXBfile(AppMain.amBindGet(AppMain.pIF.amb_header, 0));
        AppMain.pIF.tex_buf = AppMain.amTxbGetTexFileList( txb );
        AppMain.mppAssertNotImpl();
        AppMain.nnSetUpTexlist( out AppMain.pIF.texlist, AppMain.pIF.tex_buf.nTex, ref AppMain.pIF.texlistbuf );
        AppMain.pIF.regId = AppMain.amTextureLoad( AppMain.pIF.texlist, AppMain.pIF.tex_buf, null, AppMain.pIF.amb_header );
        AppMain.pIF.drawFlag = 1;
        AppMain.pIF.texId = 0;
    }

    // Token: 0x060004F4 RID: 1268 RVA: 0x0002A6CC File Offset: 0x000288CC
    public static void GmDecoGlareDraw( AppMain.OBS_OBJECT_WORK obj_work )
    {
        int user_work = (int)obj_work.user_work;
        if ( user_work < 14 )
        {
            return;
        }
        int num = user_work;
        AppMain.GMS_DECOGLARE_PARAM gms_DECOGLARE_PARAM;
        switch ( num )
        {
            case 14:
                break;
            case 15:
                gms_DECOGLARE_PARAM = AppMain._gm_decoGlare_param[1];
                goto IL_65;
            case 16:
                goto IL_53;
            default:
                if ( num == 54 )
                {
                    gms_DECOGLARE_PARAM = AppMain._gm_decoGlare_param[3];
                    goto IL_65;
                }
                switch ( num )
                {
                    case 109:
                        break;
                    case 110:
                        goto IL_53;
                    default:
                        return;
                }
                break;
        }
        gms_DECOGLARE_PARAM = AppMain._gm_decoGlare_param[0];
        goto IL_65;
        IL_53:
        gms_DECOGLARE_PARAM = AppMain._gm_decoGlare_param[2];
        IL_65:
        if ( !AppMain.amDrawIsRegistComplete( AppMain.pIF.regId ) )
        {
            return;
        }
        if ( AppMain.pIF.drawFlag != 1 )
        {
            return;
        }
        if ( ( obj_work.disp_flag & 32U ) != 0U )
        {
            return;
        }
        AppMain.VecFx32 vecFx = new AppMain.VecFx32(obj_work.pos);
        float num2 = (float)(vecFx.x >> 12);
        float num3 = -(float)(vecFx.y >> 12);
        float z = 256f;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
        switch ( gms_DECOGLARE_PARAM.ablend )
        {
            case 0:
                AppMain.amDrawGetPrimBlendParam( 0, ams_PARAM_DRAW_PRIMITIVE );
                break;
            case 1:
                AppMain.amDrawGetPrimBlendParam( 1, ams_PARAM_DRAW_PRIMITIVE );
                break;
        }
        AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(6);
        AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
        int offset = nns_PRIM3D_PCT_ARRAY.offset;
        float num4 = gms_DECOGLARE_PARAM.size * 0.5f;
        float num5 = gms_DECOGLARE_PARAM.size * 0.5f;
        num2 += 10f;
        num3 -= 10f;
        buffer[offset].Pos.Assign( num2 - num4, num3 + num5, z );
        buffer[offset + 1].Pos.Assign( num2 + num4, num3 + num5, z );
        buffer[offset + 2].Pos.Assign( num2 - num4, num3 - num5, z );
        buffer[offset + 5].Pos.Assign( num2 + num4, num3 - num5, z );
        buffer[offset].Col = gms_DECOGLARE_PARAM.color;
        buffer[offset + 1].Col = gms_DECOGLARE_PARAM.color;
        buffer[offset + 2].Col = gms_DECOGLARE_PARAM.color;
        buffer[offset + 5].Col = gms_DECOGLARE_PARAM.color;
        buffer[offset].Tex.u = 0f;
        buffer[offset].Tex.v = 0f;
        buffer[offset + 1].Tex.u = 1f;
        buffer[offset + 1].Tex.v = 0f;
        buffer[offset + 2].Tex.u = 0f;
        buffer[offset + 2].Tex.v = 1f;
        buffer[offset + 5].Tex.u = 1f;
        buffer[offset + 5].Tex.v = 1f;
        buffer[offset + 3] = buffer[offset + 1];
        buffer[offset + 4] = buffer[offset + 2];
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        ams_PARAM_DRAW_PRIMITIVE.type = 0;
        ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
        ams_PARAM_DRAW_PRIMITIVE.texlist = AppMain.pIF.texlist;
        ams_PARAM_DRAW_PRIMITIVE.texId = AppMain.pIF.texId;
        ams_PARAM_DRAW_PRIMITIVE.count = 6;
        ams_PARAM_DRAW_PRIMITIVE.sortZ = gms_DECOGLARE_PARAM.sort_z;
        AppMain.amDrawPrimitive3D( 4U, ams_PARAM_DRAW_PRIMITIVE );
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x060004F5 RID: 1269 RVA: 0x0002AA74 File Offset: 0x00028C74
    public static void GmDecoGlareDataRelease()
    {
        AppMain.pIF.drawFlag = 2;
        if ( AppMain.pIF.texlist != null )
        {
            AppMain.pIF.regId = AppMain.amTextureRelease( AppMain.pIF.texlist );
            AppMain.pIF.texlist = null;
        }
        if ( AppMain.pIF.texlistbuf != null )
        {
            AppMain.pIF.texlistbuf = null;
        }
    }

    // Token: 0x060004F6 RID: 1270 RVA: 0x0002AAD3 File Offset: 0x00028CD3
    public static AppMain.GMDECO_GLARE_INTERFACE GmDecoGlareGetGlobal()
    {
        return AppMain.pIF;
    }
}
