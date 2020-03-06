using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

public partial class AppMain
{
    // Token: 0x0200025E RID: 606
    public class AMS_RENDER_TARGET
    {
        // Token: 0x040058D8 RID: 22744
        public uint flag;

        // Token: 0x040058D9 RID: 22745
        public int surface_num;

        // Token: 0x040058DA RID: 22746
        public int width;

        // Token: 0x040058DB RID: 22747
        public int height;

        // Token: 0x040058DC RID: 22748
        public float aspect;

        // Token: 0x040058DD RID: 22749
        public RenderTarget2D target;
    }

    // Token: 0x0200025F RID: 607
    public class AMS_RENDER_MANAGER
    {
        // Token: 0x040058DE RID: 22750
        public AppMain.AMS_RENDER_TARGET targetp;

        // Token: 0x040058DF RID: 22751
        public AppMain.AMS_RENDER_TARGET target_now;
    }

    // Token: 0x06000F55 RID: 3925 RVA: 0x00087DCC File Offset: 0x00085FCC
    private static void amRenderInit()
    {
        AppMain.AMS_RENDER_MANAGER ams_RENDER_MANAGER = new AppMain.AMS_RENDER_MANAGER();
        new AppMain.AMS_RENDER_TARGET();
        AppMain.AMS_RENDER_TARGET am_render_default = AppMain._am_render_default;
        ams_RENDER_MANAGER = AppMain._am_render_manager;
        ams_RENDER_MANAGER.targetp = AppMain._am_render_default;
        ams_RENDER_MANAGER.target_now = AppMain._am_render_default;
    }

    // Token: 0x06000F56 RID: 3926 RVA: 0x00087E07 File Offset: 0x00086007
    private static AppMain.AMS_RENDER_TARGET amRenderSetTarget( AppMain.AMS_RENDER_TARGET target, uint flag, AppMain.NNS_RGBA_U8 color )
    {
        return AppMain.amRenderSetTarget( target, flag, color, 1f, 0 );
    }

    // Token: 0x06000F57 RID: 3927 RVA: 0x00087E17 File Offset: 0x00086017
    private static AppMain.AMS_RENDER_TARGET amRenderSetTarget( AppMain.AMS_RENDER_TARGET target )
    {
        return AppMain.amRenderSetTarget( target, 0U, null, 1f, 0 );
    }

    // Token: 0x06000F58 RID: 3928 RVA: 0x00087E27 File Offset: 0x00086027
    private static AppMain.AMS_RENDER_TARGET amRenderSetTarget( AppMain.AMS_RENDER_TARGET target, uint flag, AppMain.NNS_RGBA_U8 color, float z, int stencil )
    {
        return null;
    }

    // Token: 0x06000F59 RID: 3929 RVA: 0x00087E2A File Offset: 0x0008602A
    private static void amRenderSetTexture( int slot, AppMain.AMS_RENDER_TARGET target, int index )
    {
    }

    // Token: 0x06000F5A RID: 3930 RVA: 0x00087E2C File Offset: 0x0008602C
    private static void amRenderCopyTarget( AppMain.AMS_RENDER_TARGET target, AppMain.NNS_RGBA_U8 color )
    {
    }
}
