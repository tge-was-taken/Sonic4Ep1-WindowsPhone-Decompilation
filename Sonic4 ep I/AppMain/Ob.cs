using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x020003A1 RID: 929
    public class OBS_DATA_WORK
    {
        // Token: 0x060026F3 RID: 9971 RVA: 0x00150DF6 File Offset: 0x0014EFF6
        public OBS_DATA_WORK()
        {
        }

        // Token: 0x060026F4 RID: 9972 RVA: 0x00150DFE File Offset: 0x0014EFFE
        public OBS_DATA_WORK( object pData, ushort num )
        {
            this.pData = pData;
            this.num = num;
        }

        // Token: 0x0400614A RID: 24906
        public object pData;

        // Token: 0x0400614B RID: 24907
        public ushort num;
    }

    // Token: 0x020003A2 RID: 930
    public class OBS_LOAD_INITIAL_WORK
    {
        // Token: 0x0400614C RID: 24908
        public int obj_num;

        // Token: 0x0400614D RID: 24909
        public readonly AppMain.OBS_ACTION3D_NN_WORK[] obj_3d = new AppMain.OBS_ACTION3D_NN_WORK[255];

        // Token: 0x0400614E RID: 24910
        public int es_num;

        // Token: 0x0400614F RID: 24911
        public readonly AppMain.OBS_ACTION3D_ES_WORK[] obj_3des = new AppMain.OBS_ACTION3D_ES_WORK[255];
    }

    // Token: 0x020003A3 RID: 931
    // (Invoke) Token: 0x060026F7 RID: 9975
    private delegate int pFunc_Delegate( AppMain.OBS_COLLISION_OBJ pColObj, int lPosX, int lPosY, ushort ucSuf, ushort[] pDir, uint[] pAttr );
}