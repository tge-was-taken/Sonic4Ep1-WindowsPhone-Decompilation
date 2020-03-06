using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000103 RID: 259
    public class NNS_CAMERA_TARGET_ROLL : AppMain.IClearable
    {
        // Token: 0x06001FB9 RID: 8121 RVA: 0x0013D170 File Offset: 0x0013B370
        public void Clear()
        {
            this.User = 0U;
            this.Fovy = 0;
            this.Aspect = 0f;
            this.ZNear = 0f;
            this.ZFar = 0f;
            this.Roll = 0;
            this.Position.Clear();
            this.Target.Clear();
        }

        // Token: 0x04004C1B RID: 19483
        public uint User;

        // Token: 0x04004C1C RID: 19484
        public int Fovy;

        // Token: 0x04004C1D RID: 19485
        public float Aspect;

        // Token: 0x04004C1E RID: 19486
        public float ZNear;

        // Token: 0x04004C1F RID: 19487
        public float ZFar;

        // Token: 0x04004C20 RID: 19488
        public readonly AppMain.NNS_VECTOR Position = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C21 RID: 19489
        public readonly AppMain.NNS_VECTOR Target = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C22 RID: 19490
        public int Roll;
    }

    // Token: 0x02000104 RID: 260
    public class NNS_CAMERA_TARGET_UPVECTOR
    {
        // Token: 0x04004C23 RID: 19491
        public uint User;

        // Token: 0x04004C24 RID: 19492
        public int Fovy;

        // Token: 0x04004C25 RID: 19493
        public float Aspect;

        // Token: 0x04004C26 RID: 19494
        public float ZNear;

        // Token: 0x04004C27 RID: 19495
        public float ZFar;

        // Token: 0x04004C28 RID: 19496
        public readonly AppMain.NNS_VECTOR Position = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C29 RID: 19497
        public readonly AppMain.NNS_VECTOR Target = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C2A RID: 19498
        public readonly AppMain.NNS_VECTOR UpVector = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
    }

    // Token: 0x02000105 RID: 261
    public class NNS_CAMERA_TARGET_UPTARGET
    {
        // Token: 0x04004C2B RID: 19499
        public uint User;

        // Token: 0x04004C2C RID: 19500
        public int Fovy;

        // Token: 0x04004C2D RID: 19501
        public float Aspect;

        // Token: 0x04004C2E RID: 19502
        public float ZNear;

        // Token: 0x04004C2F RID: 19503
        public float ZFar;

        // Token: 0x04004C30 RID: 19504
        public readonly AppMain.NNS_VECTOR Position = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C31 RID: 19505
        public readonly AppMain.NNS_VECTOR Target = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C32 RID: 19506
        public readonly AppMain.NNS_VECTOR UpTarget = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
    }

    // Token: 0x02000106 RID: 262
    public class NNS_CAMERA_ROTATION
    {
        // Token: 0x04004C33 RID: 19507
        public uint User;

        // Token: 0x04004C34 RID: 19508
        public int Fovy;

        // Token: 0x04004C35 RID: 19509
        public float Aspect;

        // Token: 0x04004C36 RID: 19510
        public float ZNear;

        // Token: 0x04004C37 RID: 19511
        public float ZFar;

        // Token: 0x04004C38 RID: 19512
        public readonly AppMain.NNS_VECTOR Position = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004C39 RID: 19513
        public readonly int RotType;

        // Token: 0x04004C3A RID: 19514
        public readonly AppMain.NNS_ROTATE_A32 Rotation = default(AppMain.NNS_ROTATE_A32);
    }

    // Token: 0x02000107 RID: 263
    public class NNS_CAMERAPTR
    {
        // Token: 0x04004C3B RID: 19515
        public uint fType;

        // Token: 0x04004C3C RID: 19516
        public object pCamera;
    }
}