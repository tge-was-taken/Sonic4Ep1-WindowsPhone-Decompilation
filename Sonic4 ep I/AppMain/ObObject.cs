using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000354 RID: 852
    // (Invoke) Token: 0x060025EC RID: 9708
    public delegate void OBJECT_Delegate();

    // Token: 0x02000355 RID: 853
    // (Invoke) Token: 0x060025F0 RID: 9712
    public delegate void OBJECT_WORK_Delegate( AppMain.OBS_OBJECT_WORK work );

    // Token: 0x02000356 RID: 854
    public class OBS_OBJECT
    {
        // Token: 0x04005EEC RID: 24300
        public AppMain.VecFx32 glb_scale = default(AppMain.VecFx32);

        // Token: 0x04005EED RID: 24301
        public AppMain.VecFx32 draw_scale = default(AppMain.VecFx32);

        // Token: 0x04005EEE RID: 24302
        public readonly short[] offset = new short[2];

        // Token: 0x04005EEF RID: 24303
        public int speed;

        // Token: 0x04005EF0 RID: 24304
        public readonly int[] scroll = new int[2];

        // Token: 0x04005EF1 RID: 24305
        public int depth;

        // Token: 0x04005EF2 RID: 24306
        public uint timer;

        // Token: 0x04005EF3 RID: 24307
        public int timer_fx;

        // Token: 0x04005EF4 RID: 24308
        public uint flag;

        // Token: 0x04005EF5 RID: 24309
        public readonly short[] lcd_size = new short[2];

        // Token: 0x04005EF6 RID: 24310
        public readonly short[] clip_lcd_size = new short[2];

        // Token: 0x04005EF7 RID: 24311
        public int pause_level;

        // Token: 0x04005EF8 RID: 24312
        public float disp_width;

        // Token: 0x04005EF9 RID: 24313
        public float disp_height;

        // Token: 0x04005EFA RID: 24314
        public readonly int[][] camera = AppMain.New<int>(2, 2);

        // Token: 0x04005EFB RID: 24315
        public readonly int[] clip_camera = new int[2];

        // Token: 0x04005EFC RID: 24316
        public AppMain.OBJECT_Cam_Delegate pp3dCam;

        // Token: 0x04005EFD RID: 24317
        public readonly short[][] cam_scale_center = AppMain.New<short>(2, 2);

        // Token: 0x04005EFE RID: 24318
        public int glb_camera_id;

        // Token: 0x04005EFF RID: 24319
        public int glb_camera_type;

        // Token: 0x04005F00 RID: 24320
        public uint load_drawflag;

        // Token: 0x04005F01 RID: 24321
        public uint drawflag;

        // Token: 0x04005F02 RID: 24322
        public AppMain.NNS_RGB ambient_color = new AppMain.NNS_RGB();

        // Token: 0x04005F03 RID: 24323
        public readonly AppMain.OBS_LIGHT[] light = AppMain.New<AppMain.OBS_LIGHT>(AppMain.NNE_LIGHT_MAX);

        // Token: 0x04005F04 RID: 24324
        public uint def_user_light_flag;

        // Token: 0x04005F05 RID: 24325
        public sbyte col_through_dot;

        // Token: 0x04005F06 RID: 24326
        public AppMain.OBS_DATA_WORK[] pData;

        // Token: 0x04005F07 RID: 24327
        public int data_max;

        // Token: 0x04005F08 RID: 24328
        public AppMain.OBS_OBJECT_WORK obj_list_head;

        // Token: 0x04005F09 RID: 24329
        public AppMain.OBS_OBJECT_WORK obj_list_tail;

        // Token: 0x04005F0A RID: 24330
        public AppMain.OBS_OBJECT_WORK obj_draw_list_head;

        // Token: 0x04005F0B RID: 24331
        public AppMain.OBS_OBJECT_WORK obj_draw_list_tail;

        // Token: 0x04005F0C RID: 24332
        public AppMain.OBJECT_Delegate ppPre;

        // Token: 0x04005F0D RID: 24333
        public AppMain.OBJECT_Delegate ppPost;

        // Token: 0x04005F0E RID: 24334
        public AppMain.OBJECT_Delegate ppDrawSort;

        // Token: 0x04005F0F RID: 24335
        public AppMain.OBJECT_WORK_Delegate ppCollision;

        // Token: 0x04005F10 RID: 24336
        public AppMain.OBJECT_WORK_Delegate ppObjPre;

        // Token: 0x04005F11 RID: 24337
        public AppMain.OBJECT_WORK_Delegate ppObjPost;

        // Token: 0x04005F12 RID: 24338
        public AppMain.OBJECT_WORK_Delegate ppRegRecAuto;

        // Token: 0x04005F13 RID: 24339
        public AppMain.VecFx32 scale = default(AppMain.VecFx32);

        // Token: 0x04005F14 RID: 24340
        public AppMain.VecFx32 inv_scale = default(AppMain.VecFx32);

        // Token: 0x04005F15 RID: 24341
        public AppMain.VecFx32 inv_glb_scale = default(AppMain.VecFx32);

        // Token: 0x04005F16 RID: 24342
        public AppMain.VecFx32 inv_draw_scale = default(AppMain.VecFx32);
    }

    // Token: 0x02000357 RID: 855
    public class OBS_ACTION3D_MTN_LOAD_SETTING
    {
        // Token: 0x060025F4 RID: 9716 RVA: 0x0014E618 File Offset: 0x0014C818
        public void Clear()
        {
            this.enable = false;
            this.marge = false;
            this.data_work = null;
            this.filename = "";
            this.index = 0;
            this.archive = null;
        }

        // Token: 0x04005F17 RID: 24343
        public bool enable;

        // Token: 0x04005F18 RID: 24344
        public bool marge;

        // Token: 0x04005F19 RID: 24345
        public AppMain.OBS_DATA_WORK data_work;

        // Token: 0x04005F1A RID: 24346
        public string filename;

        // Token: 0x04005F1B RID: 24347
        public int index;

        // Token: 0x04005F1C RID: 24348
        public AppMain.AMS_AMB_HEADER archive;
    }

    // Token: 0x02000358 RID: 856
    // (Invoke) Token: 0x060025F7 RID: 9719
    public delegate void user_func_delegate( object o );

    // Token: 0x02000359 RID: 857
    // (Invoke) Token: 0x060025FB RID: 9723
    public delegate void mplt_cb_func_delegate( ref AppMain.NNS_MATRIX m, AppMain.NNS_OBJECT nnso, object o );

    // Token: 0x0200035A RID: 858
    // (Invoke) Token: 0x060025FF RID: 9727
    public delegate void mtn_cb_func_delegate( AppMain.AMS_MOTION m, AppMain.NNS_OBJECT nnso, object p );

    // Token: 0x0200035B RID: 859
    // (Invoke) Token: 0x06002603 RID: 9731
    public delegate bool material_cb_func_delegate( AppMain.NNS_DRAWCALLBACK_VAL callback, object o );

    // Token: 0x0200035C RID: 860
    public class OBS_ACTION3D_NN_WORK
    {
        // Token: 0x06002606 RID: 9734 RVA: 0x0014E650 File Offset: 0x0014C850
        public OBS_ACTION3D_NN_WORK()
        {
            for ( int i = 0; i < 4; i++ )
            {
                this.mtn_load_setting[i] = new AppMain.OBS_ACTION3D_MTN_LOAD_SETTING();
                this.mat_mtn_load_setting[i] = new AppMain.OBS_ACTION3D_MTN_LOAD_SETTING();
            }
        }

        // Token: 0x06002607 RID: 9735 RVA: 0x0014E718 File Offset: 0x0014C918
        public void Clear()
        {
            this._object = null;
            this.texlist = null;
            this.texlistbuf = null;
            this.motion = null;
            this.model = null;
            this.model_data_work = null;
            Array.Clear( this.mtn, 0, this.mtn.Length );
            Array.Clear( this.mtn_data_work, 0, this.mtn_data_work.Length );
            Array.Clear( this.mat_mtn, 0, this.mat_mtn.Length );
            Array.Clear( this.mat_mtn_data_work, 0, this.mat_mtn_data_work.Length );
            this.command_state = 0U;
            this.flag = 0U;
            this.marge = 0f;
            this.per = 0f;
            Array.Clear( this.act_id, 0, this.act_id.Length );
            Array.Clear( this.frame, 0, this.frame.Length );
            Array.Clear( this.speed, 0, this.speed.Length );
            this.mat_act_id = 0;
            this.mat_frame = 0f;
            this.mat_speed = 0f;
            this.user_obj_mtx.Clear();
            this.user_obj_mtx_r.Clear();
            this.blend_spd = 0f;
            this.sub_obj_type = 0U;
            this.drawflag = 0U;
            this.draw_state.Clear();
            this.use_light_flag = 0U;
            this.user_func = null;
            this.user_param = null;
            this.mplt_cb_func = null;
            this.mplt_cb_param = null;
            this.mtn_cb_func = null;
            this.mtn_cb_param = null;
            this.material_cb_func = null;
            this.material_cb_param = null;
            this.reg_index = 0;
            for ( int i = 0; i < 4; i++ )
            {
                this.mtn_load_setting[i].Clear();
                this.mat_mtn_load_setting[i].Clear();
            }
        }

        // Token: 0x04005F1D RID: 24349
        public AppMain.NNS_OBJECT _object;

        // Token: 0x04005F1E RID: 24350
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04005F1F RID: 24351
        public object texlistbuf;

        // Token: 0x04005F20 RID: 24352
        public AppMain.AMS_MOTION motion;

        // Token: 0x04005F21 RID: 24353
        public object model;

        // Token: 0x04005F22 RID: 24354
        public AppMain.OBS_DATA_WORK model_data_work;

        // Token: 0x04005F23 RID: 24355
        public readonly object[] mtn = new object[4];

        // Token: 0x04005F24 RID: 24356
        public readonly AppMain.OBS_DATA_WORK[] mtn_data_work = new AppMain.OBS_DATA_WORK[4];

        // Token: 0x04005F25 RID: 24357
        public readonly object[] mat_mtn = new object[4];

        // Token: 0x04005F26 RID: 24358
        public readonly AppMain.OBS_DATA_WORK[] mat_mtn_data_work = new AppMain.OBS_DATA_WORK[4];

        // Token: 0x04005F27 RID: 24359
        public uint command_state;

        // Token: 0x04005F28 RID: 24360
        public uint flag;

        // Token: 0x04005F29 RID: 24361
        public float marge;

        // Token: 0x04005F2A RID: 24362
        public float per;

        // Token: 0x04005F2B RID: 24363
        public readonly int[] act_id = new int[2];

        // Token: 0x04005F2C RID: 24364
        public readonly float[] frame = new float[2];

        // Token: 0x04005F2D RID: 24365
        public readonly float[] speed = new float[2];

        // Token: 0x04005F2E RID: 24366
        public int mat_act_id;

        // Token: 0x04005F2F RID: 24367
        public float mat_frame;

        // Token: 0x04005F30 RID: 24368
        public float mat_speed;

        // Token: 0x04005F31 RID: 24369
        public readonly AppMain.NNS_MATRIX user_obj_mtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005F32 RID: 24370
        public readonly AppMain.NNS_MATRIX user_obj_mtx_r = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x04005F33 RID: 24371
        public float blend_spd;

        // Token: 0x04005F34 RID: 24372
        public uint sub_obj_type;

        // Token: 0x04005F35 RID: 24373
        public uint drawflag;

        // Token: 0x04005F36 RID: 24374
        public readonly AppMain.AMS_DRAWSTATE draw_state = new AppMain.AMS_DRAWSTATE();

        // Token: 0x04005F37 RID: 24375
        public uint use_light_flag;

        // Token: 0x04005F38 RID: 24376
        public AppMain.MPP_VOID_OBJECT_DELEGATE user_func;

        // Token: 0x04005F39 RID: 24377
        public object user_param;

        // Token: 0x04005F3A RID: 24378
        public AppMain.MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT mplt_cb_func;

        // Token: 0x04005F3B RID: 24379
        public object mplt_cb_param;

        // Token: 0x04005F3C RID: 24380
        public AppMain.mtn_cb_func_delegate mtn_cb_func;

        // Token: 0x04005F3D RID: 24381
        public object mtn_cb_param;

        // Token: 0x04005F3E RID: 24382
        public AppMain.MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE material_cb_func;

        // Token: 0x04005F3F RID: 24383
        public object material_cb_param;

        // Token: 0x04005F40 RID: 24384
        public int reg_index;

        // Token: 0x04005F41 RID: 24385
        public readonly AppMain.OBS_ACTION3D_MTN_LOAD_SETTING[] mtn_load_setting = new AppMain.OBS_ACTION3D_MTN_LOAD_SETTING[4];

        // Token: 0x04005F42 RID: 24386
        public readonly AppMain.OBS_ACTION3D_MTN_LOAD_SETTING[] mat_mtn_load_setting = new AppMain.OBS_ACTION3D_MTN_LOAD_SETTING[4];

        // Token: 0x0200035D RID: 861
        public class CMPLT_Wrapper
        {
            // Token: 0x04005F43 RID: 24387
            public AppMain.GMS_BS_CMN_CNM_NODE_INFO[] m_pInfos;

            // Token: 0x04005F44 RID: 24388
            public ushort reg_node_cnt;
        }
    }

    // Token: 0x0200035E RID: 862
    public class OBS_ACTION3D_ES_WORK
    {
        // Token: 0x06002609 RID: 9737 RVA: 0x0014E8CC File Offset: 0x0014CACC
        public void Clear()
        {
            this.ecb = null;
            this.texlist = null;
            this.texlistbuf = null;
            this.texlist_data_work = null;
            this._object = null;
            this.object_data_work = null;
            this.eff = null;
            this.eff_data_work = null;
            this.ambtex = null;
            this.ambtex_data_work = null;
            this.model = null;
            this.model_data_work = null;
            this.flag = 0U;
            this.command_state = 0U;
            this.disp_rot.Clear();
            this.disp_ofst.Clear();
            this.dup_draw_ofst.Clear();
            this.user_dir_quat.Clear();
            this.user_attr = 0;
            this.tex_reg_index = 0;
            this.model_reg_index = 0;
            this.speed = 0f;
        }

        // Token: 0x04005F45 RID: 24389
        public AppMain.AMS_AME_ECB ecb;

        // Token: 0x04005F46 RID: 24390
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04005F47 RID: 24391
        public object texlistbuf;

        // Token: 0x04005F48 RID: 24392
        public AppMain.OBS_DATA_WORK texlist_data_work;

        // Token: 0x04005F49 RID: 24393
        public AppMain.NNS_OBJECT _object;

        // Token: 0x04005F4A RID: 24394
        public AppMain.OBS_DATA_WORK object_data_work;

        // Token: 0x04005F4B RID: 24395
        public object eff;

        // Token: 0x04005F4C RID: 24396
        public AppMain.OBS_DATA_WORK eff_data_work;

        // Token: 0x04005F4D RID: 24397
        public object ambtex;

        // Token: 0x04005F4E RID: 24398
        public AppMain.OBS_DATA_WORK ambtex_data_work;

        // Token: 0x04005F4F RID: 24399
        public object model;

        // Token: 0x04005F50 RID: 24400
        public AppMain.OBS_DATA_WORK model_data_work;

        // Token: 0x04005F51 RID: 24401
        public uint flag;

        // Token: 0x04005F52 RID: 24402
        public uint command_state;

        // Token: 0x04005F53 RID: 24403
        public AppMain.VecU16 disp_rot = default(AppMain.VecU16);

        // Token: 0x04005F54 RID: 24404
        public readonly AppMain.NNS_VECTOR4D disp_ofst = new AppMain.NNS_VECTOR4D();

        // Token: 0x04005F55 RID: 24405
        public readonly AppMain.NNS_VECTOR4D dup_draw_ofst = new AppMain.NNS_VECTOR4D();

        // Token: 0x04005F56 RID: 24406
        public AppMain.NNS_QUATERNION user_dir_quat = default(AppMain.NNS_QUATERNION);

        // Token: 0x04005F57 RID: 24407
        public int user_attr;

        // Token: 0x04005F58 RID: 24408
        public int tex_reg_index;

        // Token: 0x04005F59 RID: 24409
        public int model_reg_index;

        // Token: 0x04005F5A RID: 24410
        public float speed;
    }

    // Token: 0x0200035F RID: 863
    public class OBS_ACTION2D_AMA_WORK : AppMain.IClearable
    {
        // Token: 0x0600260B RID: 9739 RVA: 0x0014E9C0 File Offset: 0x0014CBC0
        public void Clear()
        {
            this.flag = 0U;
            this.act = null;
            this.ao_tex.Clear();
            this.texlist = null;
            this.ama = null;
            this.ama_data_work = null;
            this.act_id = 0U;
            this.frame = 0f;
            this.speed = 0f;
            this.type_node = 0;
            this.color.Clear();
            this.fade.Clear();
        }

        // Token: 0x04005F5B RID: 24411
        public uint flag;

        // Token: 0x04005F5C RID: 24412
        public AppMain.AOS_ACTION act;

        // Token: 0x04005F5D RID: 24413
        public readonly AppMain.AOS_TEXTURE ao_tex = new AppMain.AOS_TEXTURE();

        // Token: 0x04005F5E RID: 24414
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x04005F5F RID: 24415
        public AppMain.A2S_AMA_HEADER ama;

        // Token: 0x04005F60 RID: 24416
        public AppMain.OBS_DATA_WORK ama_data_work;

        // Token: 0x04005F61 RID: 24417
        public uint act_id;

        // Token: 0x04005F62 RID: 24418
        public float frame;

        // Token: 0x04005F63 RID: 24419
        public float speed;

        // Token: 0x04005F64 RID: 24420
        public int type_node;

        // Token: 0x04005F65 RID: 24421
        public AppMain.AOS_ACT_COL color;

        // Token: 0x04005F66 RID: 24422
        public AppMain.AOS_ACT_COL fade;
    }

    // Token: 0x060017D6 RID: 6102 RVA: 0x000D4829 File Offset: 0x000D2A29
    private static void ObjDispSRand( uint seed )
    {
        AppMain._obj_disp_rand = seed;
    }

    // Token: 0x060017D7 RID: 6103 RVA: 0x000D4831 File Offset: 0x000D2A31
    private static ushort ObjDispRand()
    {
        AppMain._obj_disp_rand = 1663525U * AppMain._obj_disp_rand + 1013904223U;
        return ( ushort )( AppMain._obj_disp_rand >> 16 );
    }

    // Token: 0x060017D8 RID: 6104 RVA: 0x000D4852 File Offset: 0x000D2A52
    private static int ObjSpdUpSet( int lSpd, int sSpd, int sMaxSpd )
    {
        lSpd += AppMain.FX_Mul( sSpd, AppMain.g_obj.speed );
        if ( sMaxSpd == 0 )
        {
            return lSpd;
        }
        if ( sSpd >= 0 )
        {
            if ( lSpd > sMaxSpd )
            {
                lSpd = sMaxSpd;
            }
        }
        else if ( lSpd < -sMaxSpd )
        {
            lSpd = -sMaxSpd;
        }
        return lSpd;
    }

    // Token: 0x060017D9 RID: 6105 RVA: 0x000D4884 File Offset: 0x000D2A84
    private static int ObjSpdDownSet( int lSpd, int sSpd )
    {
        if ( lSpd > 0 )
        {
            lSpd -= AppMain.FX_Mul( sSpd, AppMain.g_obj.speed );
            if ( lSpd < 0 )
            {
                lSpd = 0;
            }
        }
        else
        {
            lSpd += AppMain.FX_Mul( sSpd, AppMain.g_obj.speed );
            if ( lSpd > 0 )
            {
                lSpd = 0;
            }
        }
        return lSpd;
    }

    // Token: 0x060017DA RID: 6106 RVA: 0x000D48C4 File Offset: 0x000D2AC4
    private static int ObjShiftSet( int lPos, int sTag, ushort usShift, int usMax, int usMin )
    {
        if ( lPos == sTag )
        {
            return lPos;
        }
        if ( usMin == 0 )
        {
            usMin = 1;
        }
        int num = sTag - lPos >> (int)usShift;
        if ( usMax != 0 )
        {
            if ( num > usMax )
            {
                num = usMax;
            }
            if ( num < -usMax )
            {
                num = -usMax;
            }
        }
        if ( usMin != 0 )
        {
            if ( num > 0 )
            {
                if ( num < usMin )
                {
                    num = usMin;
                }
            }
            else if ( num < 0 )
            {
                if ( num > -usMin )
                {
                    num = -usMin;
                }
            }
            else
            {
                if ( sTag - lPos > 0 && num < usMin )
                {
                    num = usMin;
                }
                if ( sTag - lPos < 0 && num > -usMin )
                {
                    num = -usMin;
                }
            }
        }
        lPos += num;
        if ( num > 0 )
        {
            if ( lPos > sTag )
            {
                lPos = sTag;
            }
        }
        else if ( num < 0 && lPos < sTag )
        {
            lPos = sTag;
        }
        return lPos;
    }

    // Token: 0x060017DB RID: 6107 RVA: 0x000D4958 File Offset: 0x000D2B58
    private static int ObjDiffSet( int lPos, int sTag, int sSrc, ushort usShift, int usMax, int usMin )
    {
        if ( lPos == sTag )
        {
            return lPos;
        }
        if ( usMin == 0 )
        {
            usMin = 1;
        }
        int num = lPos - sSrc;
        num >>= ( int )usShift;
        if ( sTag > sSrc && num < 0 )
        {
            num = 0;
        }
        if ( sTag < sSrc && num > 0 )
        {
            num = 0;
        }
        if ( usMax != 0 )
        {
            if ( num > usMax )
            {
                num = usMax;
            }
            if ( num < -usMax )
            {
                num = -usMax;
            }
        }
        if ( usMin != 0 )
        {
            if ( num > 0 )
            {
                if ( num < usMin )
                {
                    num = usMin;
                }
            }
            else if ( num < 0 )
            {
                if ( num > -usMin )
                {
                    num = -usMin;
                }
            }
            else
            {
                if ( sTag - lPos > 0 && num < usMin )
                {
                    num = usMin;
                }
                if ( sTag - lPos < 0 && num > -usMin )
                {
                    num = -usMin;
                }
            }
        }
        lPos += num;
        if ( num > 0 )
        {
            if ( lPos > sTag )
            {
                lPos = sTag;
            }
        }
        else if ( num < 0 && lPos < sTag )
        {
            lPos = sTag;
        }
        return lPos;
    }

    // Token: 0x060017DC RID: 6108 RVA: 0x000D4A08 File Offset: 0x000D2C08
    private static int ObjAlphaSet( int sTag, int sSrc, ushort usAlpha )
    {
        if ( usAlpha == 0 )
        {
            return sSrc;
        }
        if ( usAlpha == 4096 )
        {
            return sTag;
        }
        int num = AppMain.FX_Mul(sTag - sSrc, (int)usAlpha);
        return sSrc + num;
    }

    // Token: 0x060017DD RID: 6109 RVA: 0x000D4A34 File Offset: 0x000D2C34
    private static byte ObjRoopMove8( byte ucDir, byte ucTag, sbyte cSpd )
    {
        if ( ucTag == ucDir )
        {
            return ucTag;
        }
        byte b = (byte)Math.Abs((int)(ucDir - ucTag));
        byte b2;
        if ( ucDir > ucTag )
        {
            b2 = ( byte )( 256 - ( int )ucDir + ( int )ucTag );
        }
        else
        {
            b2 = ( byte )( 256 - ( int )ucTag + ( int )ucDir );
        }
        if ( b <= b2 )
        {
            if ( ucDir > ucTag )
            {
                if ( ucTag > ucDir - ( byte )cSpd )
                {
                    ucDir = ucTag;
                }
                else
                {
                    ucDir -= ( byte )cSpd;
                }
            }
            else if ( ucDir < ucTag )
            {
                if ( ucTag < ucDir + ( byte )cSpd )
                {
                    ucDir = ucTag;
                }
                else
                {
                    ucDir += ( byte )cSpd;
                }
            }
        }
        else if ( ucDir > ucTag )
        {
            if ( ( int )ucTag + 256 < ( int )( ucDir + ( byte )cSpd ) )
            {
                ucDir = ucTag;
            }
            else
            {
                ucDir += ( byte )cSpd;
            }
        }
        else if ( ucDir < ucTag )
        {
            if ( ( int )ucTag > ( int )( ucDir - ( byte )cSpd ) + 256 )
            {
                ucDir = ucTag;
            }
            else
            {
                ucDir -= ( byte )cSpd;
            }
        }
        return ucDir;
    }

    // Token: 0x060017DE RID: 6110 RVA: 0x000D4ADC File Offset: 0x000D2CDC
    private static ushort ObjRoopMove16( ushort ucDir, ushort ucTag, short cSpd )
    {
        if ( ucTag == ucDir )
        {
            return ucTag;
        }
        ushort num = (ushort)Math.Abs((int)(ucDir - ucTag));
        ushort num2;
        if ( ucDir > ucTag )
        {
            num2 = ( ushort )( 65536 - ( int )ucDir + ( int )ucTag );
        }
        else
        {
            num2 = ( ushort )( 65536 - ( int )ucTag + ( int )ucDir );
        }
        if ( num <= num2 )
        {
            if ( ucDir > ucTag )
            {
                if ( ucTag > ucDir - ( ushort )cSpd )
                {
                    ucDir = ucTag;
                }
                else
                {
                    ucDir -= ( ushort )cSpd;
                }
            }
            else if ( ucDir < ucTag )
            {
                if ( ucTag < ucDir + ( ushort )cSpd )
                {
                    ucDir = ucTag;
                }
                else
                {
                    ucDir += ( ushort )cSpd;
                }
            }
        }
        else if ( ucDir > ucTag )
        {
            if ( ( int )ucTag + 65536 < ( int )( ucDir + ( ushort )cSpd ) )
            {
                ucDir = ucTag;
            }
            else
            {
                ucDir += ( ushort )cSpd;
            }
        }
        else if ( ucDir < ucTag )
        {
            if ( ( int )ucTag > ( int )( ucDir - ( ushort )cSpd ) + 65536 )
            {
                ucDir = ucTag;
            }
            else
            {
                ucDir -= ( ushort )cSpd;
            }
        }
        return ucDir;
    }

    // Token: 0x060017DF RID: 6111 RVA: 0x000D4B84 File Offset: 0x000D2D84
    private static short ObjRoopDiff16( ushort usDir1, ushort usDir2 )
    {
        if ( usDir2 == usDir1 )
        {
            return 0;
        }
        short num = (short)(usDir1 - usDir2);
        short num2;
        if ( usDir1 > usDir2 )
        {
            num2 = ( short )( 65536 - ( int )usDir1 + ( int )usDir2 );
        }
        else
        {
            num2 = ( short )( 65536 - ( int )usDir2 + ( int )usDir1 );
        }
        if ( Math.Abs( num ) > Math.Abs( num2 ) )
        {
            return num2;
        }
        return num;
    }

    // Token: 0x060017E0 RID: 6112 RVA: 0x000D4BCC File Offset: 0x000D2DCC
    private static int ObjSwingEndMove( AppMain.OBS_OBJECT_WORK pWork, int lSwingWork, int sSpdAdd, int sSpdDow, int sSpdMax )
    {
        if ( Math.Abs( lSwingWork ) < 4096 && Math.Abs( pWork.spd_m ) < 2048 )
        {
            lSwingWork = 0;
            pWork.spd_m = 0;
        }
        else
        {
            if ( lSwingWork < 0 )
            {
                if ( pWork.spd_m > 0 )
                {
                    pWork.spd_m = AppMain.ObjSpdDownSet( pWork.spd_m, sSpdDow );
                }
                pWork.spd_m = AppMain.ObjSpdUpSet( pWork.spd_m, -sSpdAdd, sSpdMax );
            }
            else
            {
                if ( pWork.spd_m < 0 )
                {
                    pWork.spd_m = AppMain.ObjSpdDownSet( pWork.spd_m, sSpdDow );
                }
                pWork.spd_m = AppMain.ObjSpdUpSet( pWork.spd_m, sSpdAdd, sSpdMax );
            }
            lSwingWork -= pWork.spd_m;
            pWork.dir.z = ( ushort )( lSwingWork & 65535 );
        }
        return lSwingWork;
    }

    // Token: 0x060017E1 RID: 6113 RVA: 0x000D4C8C File Offset: 0x000D2E8C
    private static void ObjNumCodeSet( ref uint pNum, uint sNum, uint ulMax )
    {
        short num = 0;
        if ( sNum >= ulMax )
        {
            if ( ulMax == 0U )
            {
                sNum = 0U;
            }
            else
            {
                sNum = ulMax - 1U;
            }
        }
        pNum = 0U;
        if ( ulMax >= 100U )
        {
            ulMax = ( uint )AppMain.FX_DivS32( ( int )ulMax, 10 );
            num = 0;
            for (; ; )
            {
                if ( sNum >= ulMax )
                {
                    uint num2 = (uint)AppMain.FX_DivS32((int)sNum, (int)ulMax);
                    pNum |= num2 << ( int )num;
                    sNum -= num2 * ulMax;
                }
                num += 4;
                if ( ulMax <= 10U )
                {
                    break;
                }
                ulMax = ( uint )AppMain.FX_DivS32( ( int )ulMax, 10 );
            }
        }
        pNum |= sNum << ( int )num;
        short num3 = num;
        while ( ( int )num >= num3 >> 1 )
        {
            uint num4 = (uint)((uint)(((ulong)pNum & (ulong)(15L << (int)(num3 - num & 31))) >> (int)(num3 - num)) << (int)num);
            uint num5 = (uint)((uint)(((ulong)pNum & (ulong)(15L << (int)(num & 31))) >> (int)num) << (int)(num3 - num));
            pNum &= ~( 15U << ( int )( num3 - num ) | 15U << ( int )num );
            pNum |= ( num4 | num5 );
            num -= 4;
        }
    }

    // Token: 0x060017E2 RID: 6114 RVA: 0x000D4D74 File Offset: 0x000D2F74
    private static ushort ObjObjectTouchCheck( AppMain.OBS_OBJECT_WORK pObj, ushort index )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = AppMain.ObjObjectRectGet(pObj, index);
        if ( obs_RECT_WORK != null )
        {
            return AppMain.ObjTouchCheck( pObj, obs_RECT_WORK );
        }
        return 0;
    }

    // Token: 0x060017E3 RID: 6115 RVA: 0x000D4D98 File Offset: 0x000D2F98
    private static ushort ObjObjectTouchCheckPush( AppMain.OBS_OBJECT_WORK pObj, ushort index )
    {
        AppMain.OBS_RECT_WORK obs_RECT_WORK = AppMain.ObjObjectRectGet(pObj, index);
        if ( obs_RECT_WORK != null )
        {
            return AppMain.ObjTouchCheckPush( pObj, obs_RECT_WORK );
        }
        return 0;
    }

    // Token: 0x060017E4 RID: 6116 RVA: 0x000D4DBC File Offset: 0x000D2FBC
    private static ushort ObjTouchCheck( AppMain.OBS_OBJECT_WORK pWork, AppMain.OBS_RECT_WORK pRect )
    {
        if ( AppMain.amTpIsTouchOn( 0 ) )
        {
            pRect.parent_obj = pWork;
            int num;
            int num2;
            if ( AppMain.g_obj.camera[0][1] > AppMain.g_obj.camera[1][1] )
            {
                num = AppMain.g_obj.camera[0][0] >> 12;
                num2 = AppMain.g_obj.camera[0][1] >> 12;
            }
            else
            {
                num = AppMain.g_obj.camera[1][0] >> 12;
                num2 = AppMain.g_obj.camera[1][1] >> 12;
            }
            return AppMain.ObjRectWorkPointCheck( pRect, ( int )( ( float )( AppMain._am_tp_touch[0].on[0] * ( ushort )AppMain.OBD_LCD_X ) / AppMain.AMD_DISPLAY_WIDTH + ( float )num ), ( int )( ( float )( AppMain._am_tp_touch[0].on[1] * ( ushort )AppMain.OBD_LCD_Y ) / AppMain.AMD_DISPLAY_HEIGHT + ( float )num2 ), 0 );
        }
        return 0;
    }

    // Token: 0x060017E5 RID: 6117 RVA: 0x000D4E8C File Offset: 0x000D308C
    private static ushort ObjTouchCheckPush( AppMain.OBS_OBJECT_WORK pWork, AppMain.OBS_RECT_WORK pRect )
    {
        if ( AppMain.amTpIsTouchPush( 0 ) )
        {
            pRect.parent_obj = pWork;
            int num;
            int num2;
            if ( AppMain.g_obj.camera[0][1] > AppMain.g_obj.camera[1][1] )
            {
                num = AppMain.g_obj.camera[0][0] >> 12;
                num2 = AppMain.g_obj.camera[0][1] >> 12;
            }
            else
            {
                num = AppMain.g_obj.camera[1][0] >> 12;
                num2 = AppMain.g_obj.camera[1][1] >> 12;
            }
            return AppMain.ObjRectWorkPointCheck( pRect, ( int )( ( float )( AppMain._am_tp_touch[0].on[0] * ( ushort )AppMain.OBD_LCD_X ) / AppMain.AMD_DISPLAY_WIDTH + ( float )num ), ( int )( ( float )( AppMain._am_tp_touch[0].on[1] * ( ushort )AppMain.OBD_LCD_Y ) / AppMain.AMD_DISPLAY_HEIGHT + ( float )num2 ), 0 );
        }
        return 0;
    }

    // Token: 0x060017E6 RID: 6118 RVA: 0x000D4F5C File Offset: 0x000D315C
    private static void ObjUtilGetRotPosXY( int pos_x, int pos_y, ref int dest_x, ref int dest_y, ushort dir )
    {
        int num = AppMain.FX_Mul(pos_x, AppMain.mtMathSin((int)dir));
        int num2 = AppMain.FX_Mul(pos_x, AppMain.mtMathCos((int)dir));
        int num3 = AppMain.FX_Mul(pos_y, AppMain.mtMathSin((int)dir));
        int num4 = AppMain.FX_Mul(pos_y, AppMain.mtMathCos((int)dir));
        dest_x = num2 - num3;
        dest_y = num + num4;
    }

    // Token: 0x060017E7 RID: 6119 RVA: 0x000D4FAB File Offset: 0x000D31AB
    private static float ObjSpdUpSetF( float spd, float add_apd, float max_spd )
    {
        spd += add_apd * AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.speed );
        if ( AppMain.amIsZerof( max_spd ) )
        {
            return spd;
        }
        if ( add_apd >= 0f )
        {
            if ( spd > max_spd )
            {
                spd = max_spd;
            }
        }
        else if ( spd < -max_spd )
        {
            spd = -max_spd;
        }
        return spd;
    }

    // Token: 0x060017E8 RID: 6120 RVA: 0x000D4FE8 File Offset: 0x000D31E8
    private static float ObjSpdDownSetF( float spd, float spd_dec )
    {
        if ( spd > 0f )
        {
            spd -= spd_dec * AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.speed );
            if ( spd < 0f )
            {
                spd = 0f;
            }
        }
        else
        {
            spd += spd_dec * AppMain.FXM_FX32_TO_FLOAT( AppMain.g_obj.speed );
            if ( spd > 0f )
            {
                spd = 0f;
            }
        }
        return spd;
    }

    // Token: 0x060017E9 RID: 6121 RVA: 0x000D5048 File Offset: 0x000D3248
    private static float ObjShiftSetF( float pos, float tag, int shift, float max, float min )
    {
        if ( pos == tag )
        {
            return pos;
        }
        if ( 0f == min )
        {
            min = 1f;
        }
        float num = (tag - pos) / (float)(1 << shift);
        if ( 0f != max )
        {
            if ( num > max )
            {
                num = max;
            }
            if ( num < -max )
            {
                num = -max;
            }
        }
        if ( 0f != min )
        {
            if ( num > 0f )
            {
                if ( num < min )
                {
                    num = min;
                }
            }
            else if ( num < 0f )
            {
                if ( num > -min )
                {
                    num = -min;
                }
            }
            else
            {
                if ( tag - pos > 0f && num < min )
                {
                    num = min;
                }
                if ( tag - pos < 0f && num > -min )
                {
                    num = -min;
                }
            }
        }
        pos += num;
        if ( num > 0f )
        {
            if ( pos > tag )
            {
                pos = tag;
            }
        }
        else if ( num < 0f && pos < tag )
        {
            pos = tag;
        }
        return pos;
    }

    // Token: 0x17000063 RID: 99
    // (get) Token: 0x060017EA RID: 6122 RVA: 0x000D5108 File Offset: 0x000D3308
    public static short OBD_LCD_X
    {
        get
        {
            return AppMain.g_obj.lcd_size[0];
        }
    }

    // Token: 0x17000064 RID: 100
    // (get) Token: 0x060017EB RID: 6123 RVA: 0x000D5116 File Offset: 0x000D3316
    public static short OBD_LCD_Y
    {
        get
        {
            return AppMain.g_obj.lcd_size[1];
        }
    }

    // Token: 0x17000065 RID: 101
    // (get) Token: 0x060017EC RID: 6124 RVA: 0x000D5124 File Offset: 0x000D3324
    public static short OBD_OBJ_CLIP_LCD_X
    {
        get
        {
            return AppMain.g_obj.clip_lcd_size[0];
        }
    }

    // Token: 0x17000066 RID: 102
    // (get) Token: 0x060017ED RID: 6125 RVA: 0x000D5132 File Offset: 0x000D3332
    public static short OBD_OBJ_CLIP_LCD_Y
    {
        get
        {
            return AppMain.g_obj.clip_lcd_size[1];
        }
    }

    // Token: 0x060017EE RID: 6126 RVA: 0x000D5140 File Offset: 0x000D3340
    public static AppMain.OBS_OBJECT_WORK OBM_OBJECT_TASK_DETAIL_INIT( ushort priority, byte group, byte pause_level, byte obj_pause_level, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        return AppMain.ObjObjectTaskDetailInit( priority, group, pause_level, obj_pause_level, work_size, name );
    }

    // Token: 0x060017EF RID: 6127 RVA: 0x000D514F File Offset: 0x000D334F
    public static void ObjObjectSetTexDoubleBuffer( object bank1, object bank2, object db_slot_flag )
    {
    }

    // Token: 0x060017F0 RID: 6128 RVA: 0x000D5151 File Offset: 0x000D3351
    public static void ObjObjectTaskNameSet( object obj, object name )
    {
    }

    // Token: 0x17000067 RID: 103
    // (get) Token: 0x060017F1 RID: 6129 RVA: 0x000D5153 File Offset: 0x000D3353
    // (set) Token: 0x060017F2 RID: 6130 RVA: 0x000D516B File Offset: 0x000D336B
    public static AppMain.OBS_OBJECT g_obj
    {
        get
        {
            if ( AppMain._g_obj == null )
            {
                AppMain._g_obj = new AppMain.OBS_OBJECT();
            }
            return AppMain._g_obj;
        }
        set
        {
            AppMain._g_obj = value;
        }
    }

    // Token: 0x060017F3 RID: 6131 RVA: 0x000D5174 File Offset: 0x000D3374
    private static void ObjInit( byte group, ushort prio, byte pause_level, short lcd_size_x, short lcd_size_y, float disp_width, float disp_height )
    {
        if ( AppMain.obj_ptcb != null )
        {
            AppMain.ObjExit();
        }
        AppMain.g_obj = new AppMain.OBS_OBJECT();
        AppMain.ObjDispSRand( 0U );
        AppMain.g_obj.speed = 4096;
        AppMain.g_obj.glb_scale.x = 4096;
        AppMain.g_obj.glb_scale.y = 4096;
        AppMain.g_obj.glb_scale.z = 4096;
        AppMain.g_obj.draw_scale.x = 4096;
        AppMain.g_obj.draw_scale.y = 4096;
        AppMain.g_obj.draw_scale.z = 4096;
        AppMain.g_obj.scale.x = 4096;
        AppMain.g_obj.scale.y = 4096;
        AppMain.g_obj.scale.z = 4096;
        AppMain.g_obj.inv_scale.x = 4096;
        AppMain.g_obj.inv_scale.y = 4096;
        AppMain.g_obj.inv_scale.z = 4096;
        AppMain.g_obj.inv_glb_scale.x = 4096;
        AppMain.g_obj.inv_glb_scale.y = 4096;
        AppMain.g_obj.inv_glb_scale.z = 4096;
        AppMain.g_obj.inv_draw_scale.x = 4096;
        AppMain.g_obj.inv_draw_scale.y = 4096;
        AppMain.g_obj.inv_draw_scale.z = 4096;
        AppMain.g_obj.depth = 4096;
        AppMain.g_obj.col_through_dot = 5;
        AppMain.g_obj.cam_scale_center[0][0] = ( short )( lcd_size_x / 2 );
        AppMain.g_obj.cam_scale_center[0][1] = ( short )( lcd_size_y / 2 );
        AppMain.g_obj.cam_scale_center[1][0] = ( short )( lcd_size_x / 2 );
        AppMain.g_obj.cam_scale_center[1][1] = ( short )( lcd_size_y / 2 );
        AppMain.g_obj.disp_width = disp_width;
        AppMain.g_obj.disp_height = disp_height;
        AppMain.g_obj.lcd_size[0] = lcd_size_x;
        AppMain.g_obj.lcd_size[1] = lcd_size_y;
        AppMain.g_obj.clip_lcd_size[0] = lcd_size_x;
        AppMain.g_obj.clip_lcd_size[1] = lcd_size_y;
        AppMain.g_obj.load_drawflag = 0U;
        AppMain.g_obj.drawflag = 0U;
        AppMain.g_obj.glb_camera_id = -1;
        AppMain.ObjRectCheckInit();
        AppMain.ObjCollisionObjectClear();
        AppMain.ObjCollisionObjectClear();
        AppMain.ObjDrawInit();
        AppMain.ObjLoadSetInitDrawFlag( false );
        if ( AppMain.obj_ptcb == null )
        {
            AppMain.obj_ptcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.objMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.objDestructor ), 0U, ( ushort )pause_level, ( uint )prio, ( int )group, null, "object" );
        }
    }

    // Token: 0x060017F4 RID: 6132 RVA: 0x000D5434 File Offset: 0x000D3634
    private static void ObjExit()
    {
        if ( AppMain.obj_ptcb != null )
        {
            for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( null, ushort.MaxValue ); obs_OBJECT_WORK != null; obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ushort.MaxValue ) )
            {
                obs_OBJECT_WORK.flag |= 4U;
            }
            AppMain.mtTaskChangeTcbProcedure( AppMain.obj_ptcb, new AppMain.GSF_TASK_PROCEDURE( AppMain.objExitWait ) );
            AppMain.g_obj.flag |= 2147483648U;
        }
    }

    // Token: 0x060017F5 RID: 6133 RVA: 0x000D549F File Offset: 0x000D369F
    private static void ObjPreExit()
    {
        AppMain.ObjCameraExit();
        AppMain.g_obj.glb_camera_id = -1;
    }

    // Token: 0x060017F6 RID: 6134 RVA: 0x000D54B1 File Offset: 0x000D36B1
    private static bool ObjIsInit()
    {
        return null != AppMain.obj_ptcb;
    }

    // Token: 0x060017F7 RID: 6135 RVA: 0x000D54BE File Offset: 0x000D36BE
    private static bool ObjIsExitWait()
    {
        return AppMain.obj_ptcb != null && ( AppMain.g_obj.flag & 2147483648U ) != 0U;
    }

    // Token: 0x060017F8 RID: 6136 RVA: 0x000D54DC File Offset: 0x000D36DC
    private static void ObjObjectPause( ushort pause_level )
    {
        AppMain.g_obj.flag |= 2U;
        AppMain.g_obj.pause_level = ( int )pause_level;
    }

    // Token: 0x060017F9 RID: 6137 RVA: 0x000D54FB File Offset: 0x000D36FB
    private static void ObjObjectPauseOut()
    {
        AppMain.g_obj.flag &= 4294967293U;
        AppMain.g_obj.pause_level = -1;
    }

    // Token: 0x060017FA RID: 6138 RVA: 0x000D551B File Offset: 0x000D371B
    private static uint ObjObjectPauseCheck( uint ulFlag )
    {
        if ( ( AppMain._g_obj.flag & 1U ) == 0U || ( ulFlag & 32U ) != 0U )
        {
            return 0U;
        }
        return 1U;
    }

    // Token: 0x060017FB RID: 6139 RVA: 0x000D5534 File Offset: 0x000D3734
    private static void ObjDataAlloc( int num )
    {
        if ( AppMain.obj_data_work_save != null )
        {
            AppMain.g_obj.pData = AppMain.obj_data_work_save;
            AppMain.g_obj.data_max = AppMain.obj_data_max_save;
            AppMain.obj_data_work_save = null;
            AppMain.obj_data_max_save = 0;
            return;
        }
        AppMain.g_obj.data_max = num;
        AppMain.g_obj.pData = AppMain.New<AppMain.OBS_DATA_WORK>( num );
    }

    // Token: 0x060017FC RID: 6140 RVA: 0x000D558E File Offset: 0x000D378E
    private static AppMain.OBS_DATA_WORK ObjDataGet( int index )
    {
        if ( AppMain.g_obj.data_max <= index )
        {
            return null;
        }
        return AppMain.g_obj.pData[index];
    }

    // Token: 0x060017FD RID: 6141 RVA: 0x000D55AB File Offset: 0x000D37AB
    private static void ObjDataFree()
    {
        AppMain.g_obj.data_max = 0;
        if ( AppMain.g_obj.pData != null )
        {
            AppMain.g_obj.pData = null;
        }
    }

    // Token: 0x060017FE RID: 6142 RVA: 0x000D55CF File Offset: 0x000D37CF
    private static void ObjObjectClipLCDSet( short size_x, short size_y )
    {
        AppMain.g_obj.clip_lcd_size[0] = size_x;
        AppMain.g_obj.clip_lcd_size[1] = size_y;
    }

    // Token: 0x060017FF RID: 6143 RVA: 0x000D55EB File Offset: 0x000D37EB
    private static void ObjObjectOffsetSet( short sX, short sY )
    {
        AppMain.g_obj.offset[0] = sX;
        AppMain.g_obj.offset[1] = sY;
    }

    // Token: 0x06001800 RID: 6144 RVA: 0x000D5607 File Offset: 0x000D3807
    private static void ObjObjectSpeedSet( int sSpd )
    {
        AppMain.g_obj.speed = sSpd;
    }

    // Token: 0x06001801 RID: 6145 RVA: 0x000D5614 File Offset: 0x000D3814
    private static int ObjObjectSpeedGet()
    {
        return AppMain.g_obj.speed;
    }

    // Token: 0x06001802 RID: 6146 RVA: 0x000D5620 File Offset: 0x000D3820
    private void ObjObjectScrollSet( int spd_x, int spd_y )
    {
        AppMain.g_obj.scroll[0] = spd_x;
        AppMain.g_obj.scroll[1] = spd_y;
    }

    // Token: 0x06001803 RID: 6147 RVA: 0x000D563C File Offset: 0x000D383C
    private static int ObjObjectScrollGetX()
    {
        return AppMain.g_obj.scroll[0];
    }

    // Token: 0x06001804 RID: 6148 RVA: 0x000D564A File Offset: 0x000D384A
    private static int ObjObjectScrollGetY()
    {
        return AppMain.g_obj.scroll[1];
    }

    // Token: 0x06001805 RID: 6149 RVA: 0x000D5658 File Offset: 0x000D3858
    private static void ObjObjectBeltSetDepth( int depth )
    {
        AppMain.g_obj.depth = depth;
    }

    // Token: 0x06001806 RID: 6150 RVA: 0x000D5665 File Offset: 0x000D3865
    private static int ObjObjectBeltGetDepth()
    {
        return AppMain.g_obj.depth;
    }

    // Token: 0x06001807 RID: 6151 RVA: 0x000D5671 File Offset: 0x000D3871
    public static void ObjObjectCameraSet( int x1, int y1, int x2, int y2 )
    {
        AppMain.g_obj.camera[0][0] = x1;
        AppMain.g_obj.camera[0][1] = y1;
        AppMain.g_obj.camera[1][0] = x2;
        AppMain.g_obj.camera[1][1] = y2;
    }

    // Token: 0x06001808 RID: 6152 RVA: 0x000D56AF File Offset: 0x000D38AF
    private static void ObjObjectClipCameraSet( int x, int y )
    {
        AppMain.g_obj.clip_camera[0] = x;
        AppMain.g_obj.clip_camera[1] = y;
    }

    // Token: 0x06001809 RID: 6153 RVA: 0x000D56CC File Offset: 0x000D38CC
    private static void ObjObjectCameraZSet( int z )
    {
        if ( z > 0 )
        {
            AppMain.g_obj.glb_scale.x = 4096 - ( z >> 1 );
            AppMain.g_obj.glb_scale.y = 4096 - ( z >> 1 );
        }
        else
        {
            AppMain.g_obj.glb_scale.x = 4096 - z;
            AppMain.g_obj.glb_scale.y = 4096 - z;
        }
        AppMain.g_obj.glb_scale.z = 4096;
    }

    // Token: 0x0600180A RID: 6154 RVA: 0x000D5756 File Offset: 0x000D3956
    private static AppMain.OBS_OBJECT_WORK ObjObjectTaskInit()
    {
        return AppMain.OBM_OBJECT_TASK_DETAIL_INIT( 4096, 1, 0, 0, () => AppMain.OBS_OBJECT_WORK.Create(), "object" );
    }

    // Token: 0x0600180B RID: 6155 RVA: 0x000D5788 File Offset: 0x000D3988
    private static AppMain.OBS_OBJECT_WORK ObjObjectTaskDetailInit( ushort prio, byte group, byte pause_level, byte obj_pause_level, AppMain.TaskWorkFactoryDelegate work_size, string name )
    {
        AppMain.MTS_TASK_TCB tcb = AppMain.MTM_TASK_MAKE_TCB(AppMain._ObjObjectMain, AppMain._ObjObjectExit, 0U, (ushort)pause_level, (uint)prio, (int)group, work_size, (name == null) ? "" : name);
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        obs_OBJECT_WORK.tcb = tcb;
        obs_OBJECT_WORK.pause_level = ( int )obj_pause_level;
        obs_OBJECT_WORK.scale.x = 4096;
        obs_OBJECT_WORK.scale.y = 4096;
        obs_OBJECT_WORK.scale.z = 4096;
        if ( ( AppMain.g_obj.flag & 8192U ) == 0U )
        {
            if ( ( AppMain.g_obj.flag & 16384U ) != 0U )
            {
                obs_OBJECT_WORK.flag |= 1048576U;
            }
            else
            {
                obs_OBJECT_WORK.flag |= 2097152U;
            }
        }
        obs_OBJECT_WORK.ppViewCheck = AppMain._ObjObjectViewOutCheck;
        if ( ( AppMain.g_obj.flag & 65536U ) != 0U )
        {
            obs_OBJECT_WORK.flag |= 16U;
        }
        obs_OBJECT_WORK.field_ajst_w_db_f = 2;
        obs_OBJECT_WORK.field_ajst_w_db_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dl_f = 2;
        obs_OBJECT_WORK.field_ajst_w_dl_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dt_f = 2;
        obs_OBJECT_WORK.field_ajst_w_dt_b = 4;
        obs_OBJECT_WORK.field_ajst_w_dr_f = 2;
        obs_OBJECT_WORK.field_ajst_w_dr_b = 4;
        obs_OBJECT_WORK.field_ajst_h_db_r = 1;
        obs_OBJECT_WORK.field_ajst_h_db_l = 1;
        obs_OBJECT_WORK.field_ajst_h_dl_r = 1;
        obs_OBJECT_WORK.field_ajst_h_dl_l = 1;
        obs_OBJECT_WORK.field_ajst_h_dt_r = 1;
        obs_OBJECT_WORK.field_ajst_h_dt_l = 1;
        obs_OBJECT_WORK.field_ajst_h_dr_r = 2;
        obs_OBJECT_WORK.field_ajst_h_dr_l = 2;
        AppMain.ObjObjectRegistObject( obs_OBJECT_WORK );
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600180C RID: 6156 RVA: 0x000D58EC File Offset: 0x000D3AEC
    public static void ObjObjectRegistObject( AppMain.OBS_OBJECT_WORK pWork )
    {
        pWork.prev = AppMain.g_obj.obj_list_tail;
        pWork.next = null;
        if ( pWork.prev != null )
        {
            pWork.prev.next = pWork;
        }
        else
        {
            AppMain.g_obj.obj_list_head = pWork;
        }
        AppMain.g_obj.obj_list_tail = pWork;
    }

    // Token: 0x0600180D RID: 6157 RVA: 0x000D593C File Offset: 0x000D3B3C
    private static void ObjObjectRevokeObject( AppMain.OBS_OBJECT_WORK pWork )
    {
        if ( pWork.prev != null )
        {
            pWork.prev.next = pWork.next;
        }
        else
        {
            AppMain.g_obj.obj_list_head = pWork.next;
        }
        if ( pWork.next != null )
        {
            pWork.next.prev = pWork.prev;
            return;
        }
        AppMain.g_obj.obj_list_tail = pWork.prev;
    }

    // Token: 0x0600180E RID: 6158 RVA: 0x000D59A0 File Offset: 0x000D3BA0
    private static void ObjObjectClearAllObject()
    {
        AppMain.OBS_OBJECT_WORK next;
        for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.g_obj.obj_list_head; obs_OBJECT_WORK != null; obs_OBJECT_WORK = next )
        {
            next = obs_OBJECT_WORK.next;
            obs_OBJECT_WORK.flag |= 4U;
        }
    }

    // Token: 0x0600180F RID: 6159 RVA: 0x000D59D4 File Offset: 0x000D3BD4
    private static bool ObjObjectCheckClearAllObject()
    {
        return AppMain.g_obj.obj_list_head == null;
    }

    // Token: 0x06001810 RID: 6160 RVA: 0x000D59E8 File Offset: 0x000D3BE8
    private static AppMain.OBS_OBJECT_WORK ObjObjectSearchRegistObject( AppMain.OBS_OBJECT_WORK obj_work, ushort obj_type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK;
        if ( obj_work == null )
        {
            obs_OBJECT_WORK = AppMain.g_obj.obj_list_head;
        }
        else
        {
            obs_OBJECT_WORK = obj_work.next;
        }
        while ( obs_OBJECT_WORK != null && obs_OBJECT_WORK.obj_type != obj_type && obj_type != 65535 )
        {
            obs_OBJECT_WORK = obs_OBJECT_WORK.next;
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06001811 RID: 6161 RVA: 0x000D5A2A File Offset: 0x000D3C2A
    private static void ObjObjectTypeSet( AppMain.OBS_OBJECT_WORK pObj, ushort usType )
    {
        pObj.obj_type = usType;
    }

    // Token: 0x06001812 RID: 6162 RVA: 0x000D5A33 File Offset: 0x000D3C33
    private static void ObjObjectParentSet( AppMain.OBS_OBJECT_WORK pObj, AppMain.OBS_OBJECT_WORK pParent, uint ulFlag )
    {
        pObj.parent_obj = pParent;
        pObj.flag &= 4294963711U;
        pObj.flag |= ( ulFlag & 3584U );
    }

    // Token: 0x06001813 RID: 6163 RVA: 0x000D5A62 File Offset: 0x000D3C62
    private static object ObjObjecExWorkAlloc( AppMain.OBS_OBJECT_WORK pObj, uint ulSize )
    {
        if ( pObj.ex_work != null )
        {
            pObj.ex_work = null;
        }
        if ( ulSize != 0U )
        {
            pObj.ex_work = new byte[ulSize];
            pObj.flag |= 8388608U;
        }
        return pObj.ex_work;
    }

    // Token: 0x06001814 RID: 6164 RVA: 0x000D5A9C File Offset: 0x000D3C9C
    public static void ObjObjectMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        if ( ( obs_OBJECT_WORK.flag & 4U ) != 0U )
        {
            AppMain.objObjectExitDataRelease( tcb );
            return;
        }
        if ( ( obs_OBJECT_WORK.flag & 8U ) != 0U )
        {
            obs_OBJECT_WORK.flag |= 4U;
            return;
        }
        if ( ( obs_OBJECT_WORK.flag & 16U ) == 0U && obs_OBJECT_WORK.ppViewCheck != null && obs_OBJECT_WORK.ppViewCheck( obs_OBJECT_WORK ) != 0 )
        {
            obs_OBJECT_WORK.flag |= 4U;
            return;
        }
        if ( AppMain.objObjectParent( obs_OBJECT_WORK ) != 0 )
        {
            return;
        }
        if ( obs_OBJECT_WORK.obj_3d != null )
        {
            if ( !AppMain.ObjAction3dNNModelLoadCheck( obs_OBJECT_WORK.obj_3d ) && ( obs_OBJECT_WORK.flag & 256U ) == 0U )
            {
                return;
            }
        }
        else if ( obs_OBJECT_WORK.obj_2d != null && !AppMain.ObjAction2dAMALoadCheck( obs_OBJECT_WORK.obj_2d ) && ( obs_OBJECT_WORK.flag & 256U ) == 0U )
        {
            return;
        }
        if ( AppMain._g_obj.ppObjPre != null )
        {
            AppMain._g_obj.ppObjPre( obs_OBJECT_WORK );
        }
        AppMain.objObjectColRideTouchCheck( obs_OBJECT_WORK );
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK2 = obs_OBJECT_WORK;
        obs_OBJECT_WORK2.pos.x = obs_OBJECT_WORK2.pos.x - obs_OBJECT_WORK.prev_temp_ofst.x;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK3 = obs_OBJECT_WORK;
        obs_OBJECT_WORK3.pos.y = obs_OBJECT_WORK3.pos.y - obs_OBJECT_WORK.prev_temp_ofst.y;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK4 = obs_OBJECT_WORK;
        obs_OBJECT_WORK4.pos.z = obs_OBJECT_WORK4.pos.z - obs_OBJECT_WORK.prev_temp_ofst.z;
        uint num = AppMain.ObjObjectPauseCheck(obs_OBJECT_WORK.flag);
        if ( ( num == 0U || ( obs_OBJECT_WORK.flag & 64U ) != 0U ) && obs_OBJECT_WORK.ppIn != null )
        {
            obs_OBJECT_WORK.ppIn( obs_OBJECT_WORK );
        }
        if ( ( obs_OBJECT_WORK.disp_flag & 536870912U ) != 0U && ( obs_OBJECT_WORK.flag & 1073741824U ) != 0U )
        {
            obs_OBJECT_WORK.flag |= 2147483648U;
            obs_OBJECT_WORK.disp_flag |= 1073741824U;
        }
        else
        {
            obs_OBJECT_WORK.flag &= 2147483647U;
            obs_OBJECT_WORK.disp_flag &= 3221225471U;
        }
        if ( num == 0U )
        {
            if ( obs_OBJECT_WORK.vib_timer != 0 )
            {
                obs_OBJECT_WORK.vib_timer = AppMain.ObjTimeCountDown( obs_OBJECT_WORK.vib_timer );
            }
            if ( obs_OBJECT_WORK.hitstop_timer != 0 )
            {
                obs_OBJECT_WORK.hitstop_timer = AppMain.ObjTimeCountDown( obs_OBJECT_WORK.hitstop_timer );
                if ( ( obs_OBJECT_WORK.flag & 8192U ) != 0U )
                {
                    obs_OBJECT_WORK.hitstop_timer = 0;
                }
            }
            if ( ( AppMain._g_obj.flag & 32768U ) == 0U || obs_OBJECT_WORK.hitstop_timer == 0 )
            {
                if ( obs_OBJECT_WORK.invincible_timer != 0 )
                {
                    obs_OBJECT_WORK.invincible_timer = AppMain.ObjTimeCountDown( obs_OBJECT_WORK.invincible_timer );
                }
                if ( ( obs_OBJECT_WORK.flag & 2147483776U ) == 0U && obs_OBJECT_WORK.ppFunc != null )
                {
                    obs_OBJECT_WORK.ppFunc( obs_OBJECT_WORK );
                }
            }
            if ( ( obs_OBJECT_WORK.flag & 2147483648U ) == 0U )
            {
                if ( ( obs_OBJECT_WORK.move_flag & 8192U ) == 0U && obs_OBJECT_WORK.ppMove != null )
                {
                    obs_OBJECT_WORK.ppMove( obs_OBJECT_WORK );
                }
                if ( ( AppMain._g_obj.flag & 48U ) != 0U && ( obs_OBJECT_WORK.move_flag & 256U ) == 0U && ( ( AppMain._g_obj.flag & 2097152U ) == 0U || obs_OBJECT_WORK.hitstop_timer == 0 ) )
                {
                    if ( obs_OBJECT_WORK.ppCol != null )
                    {
                        obs_OBJECT_WORK.ppCol( obs_OBJECT_WORK );
                    }
                    else if ( AppMain._g_obj.ppCollision != null )
                    {
                        AppMain._g_obj.ppCollision( obs_OBJECT_WORK );
                    }
                }
            }
        }
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK5 = obs_OBJECT_WORK;
        obs_OBJECT_WORK5.pos.x = obs_OBJECT_WORK5.pos.x + obs_OBJECT_WORK.temp_ofst.x;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK6 = obs_OBJECT_WORK;
        obs_OBJECT_WORK6.pos.y = obs_OBJECT_WORK6.pos.y + obs_OBJECT_WORK.temp_ofst.y;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK7 = obs_OBJECT_WORK;
        obs_OBJECT_WORK7.pos.z = obs_OBJECT_WORK7.pos.z + obs_OBJECT_WORK.temp_ofst.z;
        obs_OBJECT_WORK.prev_temp_ofst.x = obs_OBJECT_WORK.temp_ofst.x;
        obs_OBJECT_WORK.prev_temp_ofst.y = obs_OBJECT_WORK.temp_ofst.y;
        obs_OBJECT_WORK.prev_temp_ofst.z = obs_OBJECT_WORK.temp_ofst.z;
        if ( ( obs_OBJECT_WORK.flag & 2147483648U ) == 0U )
        {
            if ( num == 0U && obs_OBJECT_WORK.vib_timer != 0 && ( obs_OBJECT_WORK.flag & 16384U ) == 0U )
            {
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK8 = obs_OBJECT_WORK;
                obs_OBJECT_WORK8.ofst.x = obs_OBJECT_WORK8.ofst.x + ( int )AppMain.g_object_vib_tbl[obs_OBJECT_WORK.vib_timer >> 13 & 15];
                AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK9 = obs_OBJECT_WORK;
                obs_OBJECT_WORK9.ofst.y = obs_OBJECT_WORK9.ofst.y + ( int )AppMain.g_object_vib_tbl[( obs_OBJECT_WORK.vib_timer >> 13 ) + 1 & 15];
            }
            if ( ( num == 0U || ( obs_OBJECT_WORK.flag & 65536U ) != 0U ) && ( AppMain._g_obj.flag & 64U ) != 0U )
            {
                if ( obs_OBJECT_WORK.ppRec != null )
                {
                    obs_OBJECT_WORK.ppRec( obs_OBJECT_WORK );
                }
                if ( AppMain._g_obj.ppRegRecAuto != null )
                {
                    AppMain._g_obj.ppRegRecAuto( obs_OBJECT_WORK );
                }
            }
            if ( ( num == 0U || ( obs_OBJECT_WORK.flag & 262144U ) != 0U ) && obs_OBJECT_WORK.ppLast != null )
            {
                obs_OBJECT_WORK.ppLast( obs_OBJECT_WORK );
            }
        }
        if ( AppMain._g_obj.ppObjPost != null )
        {
            AppMain._g_obj.ppObjPost( obs_OBJECT_WORK );
        }
    }

    // Token: 0x06001815 RID: 6165 RVA: 0x000D5F48 File Offset: 0x000D4148
    private static void ObjObjectExit( AppMain.MTS_TASK_TCB pTcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(pTcb);
        if ( obs_OBJECT_WORK.obj_3d != null )
        {
            AppMain.ObjAction3dNNMotionRelease( obs_OBJECT_WORK.obj_3d );
            if ( ( obs_OBJECT_WORK.flag & 536870912U ) == 0U )
            {
                if ( obs_OBJECT_WORK.obj_3d._object != null )
                {
                    obs_OBJECT_WORK.obj_3d._object = null;
                }
                if ( obs_OBJECT_WORK.obj_3d.texlistbuf != null )
                {
                    obs_OBJECT_WORK.obj_3d.texlistbuf = null;
                }
            }
        }
        if ( obs_OBJECT_WORK.obj_3des != null )
        {
            if ( obs_OBJECT_WORK.obj_3des._object != null )
            {
                obs_OBJECT_WORK.obj_3des._object = null;
            }
            if ( obs_OBJECT_WORK.obj_3des.model_data_work != null )
            {
                AppMain.ObjDataRelease( obs_OBJECT_WORK.obj_3des.model_data_work );
                obs_OBJECT_WORK.obj_3des.model_data_work = null;
            }
            else if ( obs_OBJECT_WORK.obj_3des.model != null )
            {
                uint num = obs_OBJECT_WORK.obj_3des.flag & 262144U;
            }
            obs_OBJECT_WORK.obj_3des.model = null;
            if ( obs_OBJECT_WORK.obj_3des.texlistbuf != null )
            {
                obs_OBJECT_WORK.obj_3des.texlistbuf = null;
            }
            if ( obs_OBJECT_WORK.obj_3des.ambtex_data_work != null )
            {
                AppMain.ObjDataRelease( obs_OBJECT_WORK.obj_3des.ambtex_data_work );
                obs_OBJECT_WORK.obj_3des.ambtex_data_work = null;
            }
            else if ( obs_OBJECT_WORK.obj_3des.ambtex != null )
            {
                uint num2 = obs_OBJECT_WORK.obj_3des.flag & 131072U;
            }
            obs_OBJECT_WORK.obj_3des.ambtex = null;
            if ( obs_OBJECT_WORK.obj_3des.ecb != null )
            {
                AppMain.amEffectDelete( obs_OBJECT_WORK.obj_3des.ecb );
                obs_OBJECT_WORK.obj_3des.ecb = null;
            }
            if ( obs_OBJECT_WORK.obj_3des.eff_data_work != null )
            {
                AppMain.ObjDataRelease( obs_OBJECT_WORK.obj_3des.eff_data_work );
                obs_OBJECT_WORK.obj_3des.eff_data_work = null;
            }
            else if ( obs_OBJECT_WORK.obj_3des.eff != null )
            {
                uint num3 = obs_OBJECT_WORK.obj_3des.flag & 65536U;
            }
            obs_OBJECT_WORK.obj_3des.eff = null;
        }
        if ( obs_OBJECT_WORK.obj_2d != null && obs_OBJECT_WORK.obj_2d.act != null )
        {
            AppMain.AoActDelete( obs_OBJECT_WORK.obj_2d.act );
            obs_OBJECT_WORK.obj_2d.act = null;
        }
        if ( obs_OBJECT_WORK.col_work != null )
        {
            if ( obs_OBJECT_WORK.col_work.diff_data_work != null )
            {
                AppMain.ObjDataRelease( obs_OBJECT_WORK.col_work.diff_data_work );
            }
            else if ( obs_OBJECT_WORK.col_work.obj_col.diff_data != null )
            {
                uint num4 = obs_OBJECT_WORK.col_work.obj_col.flag & 134217728U;
            }
            if ( obs_OBJECT_WORK.col_work.dir_data_work != null )
            {
                AppMain.ObjDataRelease( obs_OBJECT_WORK.col_work.dir_data_work );
            }
            else if ( obs_OBJECT_WORK.col_work.obj_col.dir_data != null )
            {
                uint num5 = obs_OBJECT_WORK.col_work.obj_col.flag & 268435456U;
            }
            if ( obs_OBJECT_WORK.col_work.attr_data_work != null )
            {
                AppMain.ObjDataRelease( obs_OBJECT_WORK.col_work.attr_data_work );
            }
            else if ( obs_OBJECT_WORK.col_work.obj_col.attr_data != null )
            {
                uint num6 = obs_OBJECT_WORK.col_work.obj_col.flag & 536870912U;
            }
        }
        if ( ( obs_OBJECT_WORK.flag & 520093696U ) != 0U )
        {
            if ( ( obs_OBJECT_WORK.flag & 134217728U ) != 0U )
            {
                AppMain.OBS_ACTION3D_NN_WORK obj_3d = obs_OBJECT_WORK.obj_3d;
            }
            if ( ( obs_OBJECT_WORK.flag & 268435456U ) != 0U )
            {
                AppMain.OBS_ACTION3D_ES_WORK obj_3des = obs_OBJECT_WORK.obj_3des;
            }
            if ( ( obs_OBJECT_WORK.flag & 67108864U ) != 0U )
            {
                AppMain.OBS_ACTION2D_AMA_WORK obj_2d = obs_OBJECT_WORK.obj_2d;
            }
            if ( ( obs_OBJECT_WORK.flag & 16777216U ) != 0U )
            {
                AppMain.OBS_COLLISION_WORK col_work = obs_OBJECT_WORK.col_work;
            }
            if ( ( obs_OBJECT_WORK.flag & 33554432U ) != 0U )
            {
                // TODO: fix
                //null != obs_OBJECT_WORK.rect_work;
            }
        }
        if ( obs_OBJECT_WORK.ex_work != null )
        {
            uint num7 = obs_OBJECT_WORK.flag & 8388608U;
        }
        AppMain.ObjObjectRevokeObject( obs_OBJECT_WORK );
    }

    // Token: 0x06001816 RID: 6166 RVA: 0x000D62C8 File Offset: 0x000D44C8
    private static int ObjObjectViewOutCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        return AppMain.ObjViewOutCheck( pWork.pos.x, pWork.pos.y, pWork.view_out_ofst, pWork.view_out_ofst_plus[0], pWork.view_out_ofst_plus[1], pWork.view_out_ofst_plus[2], pWork.view_out_ofst_plus[3] );
    }

    // Token: 0x06001817 RID: 6167 RVA: 0x000D6318 File Offset: 0x000D4518
    private static void ObjObjectRectRegist( AppMain.OBS_OBJECT_WORK pWork, AppMain.OBS_RECT_WORK pRec )
    {
        if ( ( pWork.flag & 12U ) != 0U )
        {
            return;
        }
        if ( ( AppMain.g_obj.flag & 64U ) == 0U )
        {
            return;
        }
        if ( ( pWork.flag & 2U ) != 0U )
        {
            return;
        }
        pRec.parent_obj = pWork;
        pRec.flag &= 4294967292U;
        if ( AppMain.ObjObjectDirFallReverseCheck( pWork.dir_fall ) != 0U )
        {
            pRec.flag ^= 2U;
            pRec.flag ^= 1U;
        }
        AppMain.ObjRectRegist( pRec );
    }

    // Token: 0x06001818 RID: 6168 RVA: 0x000D6394 File Offset: 0x000D4594
    private static void ObjObjectGetRectBuf( AppMain.OBS_OBJECT_WORK pWork, AppMain.ArrayPointer<AppMain.OBS_RECT_WORK> rect_work, ushort rect_num )
    {
        if ( rect_num - 1 > 31 )
        {
            return;
        }
        if ( null != pWork.rect_work )
        {
            if ( ( pWork.flag & 33554432U ) == 0U )
            {
                return;
            }
            AppMain.ObjObjectReleaseRectBuf( pWork );
        }
        if ( rect_work == null )
        {
            pWork.rect_work = new AppMain.OBS_RECT_WORK[( int )rect_num];
            pWork.flag |= 33554432U;
            pWork.rect_num = ( uint )rect_num;
            return;
        }
        pWork.rect_num = ( uint )rect_num;
        pWork.rect_work = rect_work;
    }

    // Token: 0x06001819 RID: 6169 RVA: 0x000D641C File Offset: 0x000D461C
    private static void ObjObjectReleaseRectBuf( AppMain.OBS_OBJECT_WORK pWork )
    {
        if ( ( pWork.flag & 33554432U ) != 0U && null != pWork.rect_work )
        {
            pWork.rect_work = null;
            pWork.flag &= 4261412863U;
        }
    }

    // Token: 0x0600181A RID: 6170 RVA: 0x000D6468 File Offset: 0x000D4668
    private static void ObjObjectSetRectWork( AppMain.OBS_OBJECT_WORK pWork, AppMain.OBS_RECT_WORK rect_work )
    {
        rect_work.parent_obj = pWork;
        rect_work.group_no = 0;
        rect_work.target_g_flag = 1;
        rect_work.hit_power = 64;
        rect_work.def_power = 63;
        rect_work.hit_flag = 2;
        rect_work.def_flag = 1;
    }

    // Token: 0x0600181B RID: 6171 RVA: 0x000D649D File Offset: 0x000D469D
    private static AppMain.OBS_RECT_WORK ObjObjectRectGet( AppMain.OBS_OBJECT_WORK pWork, ushort usIndex )
    {
        return pWork.rect_work[( int )usIndex];
    }

    // Token: 0x0600181C RID: 6172 RVA: 0x000D64AC File Offset: 0x000D46AC
    private static int ObjViewOutCheck( int lPosX, int lPosY, short sOfst, short sLeft, short sTop, short sRight, short sBottom )
    {
        short num = AppMain.g_obj.clip_lcd_size[0];
        short num2 = AppMain._g_obj.clip_lcd_size[1];
        if ( AppMain._g_obj.glb_scale.x != 4096 )
        {
            num = ( short )AppMain.FX_Mul( ( int )num, 8192 - AppMain._g_obj.glb_scale.x );
        }
        if ( AppMain._g_obj.glb_scale.y != 4096 )
        {
            num2 = ( short )AppMain.FX_Mul( ( int )num2, 8192 - AppMain._g_obj.glb_scale.y );
        }
        if ( ( AppMain._g_obj.flag & 8U ) == 0U )
        {
            return 0;
        }
        int num3 = (AppMain._g_obj.clip_camera[0] >> 12) - (int)sOfst;
        int num4 = (AppMain._g_obj.clip_camera[1] >> 12) - (int)sOfst;
        int num5 = (int)num + ((int)sOfst << 1);
        int num6 = (int)num2 + ((int)sOfst << 1);
        num3 += ( int )sLeft;
        num4 += ( int )sTop;
        num6 += ( int )( -( int )sTop + sBottom );
        num5 += ( int )( -( int )sLeft + sRight );
        if ( num3 <= lPosX >> 12 && num3 + num5 >= lPosX >> 12 && num4 <= lPosY >> 12 && num4 + num6 >= lPosY >> 12 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x0600181D RID: 6173 RVA: 0x000D65C0 File Offset: 0x000D47C0
    private static void ObjObjectSpdDirFall( ref int sSpdX, ref int sSpdY, ushort ucDirFall )
    {
        int num = sSpdX;
        int num2 = sSpdY;
        float num3 = AppMain.nnSin((int)ucDirFall);
        float num4 = AppMain.nnCos((int)ucDirFall);
        float num5 = (float)num * num3;
        float num6 = (float)num * num4;
        float num7 = (float)num2 * num3;
        float num8 = (float)num2 * num4;
        sSpdX = ( int )AppMain.nnRoundOff( num6 - num7 );
        sSpdY = ( int )AppMain.nnRoundOff( num5 + num8 );
    }

    // Token: 0x0600181E RID: 6174 RVA: 0x000D6617 File Offset: 0x000D4817
    private static uint ObjObjectDirFallReverseCheck( ushort ucDirFall )
    {
        if ( ucDirFall > 24576 && ucDirFall < 40960 )
        {
            return 1U;
        }
        return 0U;
    }

    // Token: 0x0600181F RID: 6175 RVA: 0x000D662C File Offset: 0x000D482C
    private static int ObjTimeCountGet( int count )
    {
        if ( AppMain.g_obj.speed != 4096 )
        {
            return AppMain.FX_Mul( count, AppMain.g_obj.speed );
        }
        return count;
    }

    // Token: 0x06001820 RID: 6176 RVA: 0x000D6651 File Offset: 0x000D4851
    private static int ObjTimeCountDown( int timer )
    {
        if ( AppMain.g_obj.speed == 4096 )
        {
            timer -= 4096;
        }
        else
        {
            timer -= AppMain.FX_Mul( 4096, AppMain.g_obj.speed );
        }
        if ( timer < 0 )
        {
            timer = 0;
        }
        return timer;
    }

    // Token: 0x06001821 RID: 6177 RVA: 0x000D668F File Offset: 0x000D488F
    private static int ObjTimeCountUp( int timer )
    {
        if ( AppMain.g_obj.speed == 4096 )
        {
            timer += 4096;
        }
        else
        {
            timer += AppMain.FX_Mul( 4096, AppMain.g_obj.speed );
        }
        if ( timer < 0 )
        {
            timer = 0;
        }
        return timer;
    }

    // Token: 0x06001822 RID: 6178 RVA: 0x000D66D0 File Offset: 0x000D48D0
    private static float ObjTimeCountDownF( float timer )
    {
        if ( AppMain.g_obj.speed == 4096 )
        {
            timer -= 1f;
        }
        else
        {
            timer -= 1f * ( float )AppMain.g_obj.speed / 4096f;
        }
        if ( timer < 0f )
        {
            timer = 0f;
        }
        return timer;
    }

    // Token: 0x06001823 RID: 6179 RVA: 0x000D6724 File Offset: 0x000D4924
    private static float ObjTimeCountUpF( float timer )
    {
        if ( AppMain.g_obj.speed == 4096 )
        {
            timer += 1f;
        }
        else
        {
            timer += 1f * ( float )AppMain.g_obj.speed / 4096f;
        }
        if ( timer < 0f )
        {
            timer = 0f;
        }
        return timer;
    }

    // Token: 0x06001824 RID: 6180 RVA: 0x000D6778 File Offset: 0x000D4978
    private static int ObjObjectMapOutCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        return AppMain.ObjMapOutCheck( pWork.pos.x, pWork.pos.y, pWork.view_out_ofst, pWork.view_out_ofst_plus[0], pWork.view_out_ofst_plus[1], pWork.view_out_ofst_plus[2], pWork.view_out_ofst_plus[3] );
    }

    // Token: 0x06001825 RID: 6181 RVA: 0x000D67C8 File Offset: 0x000D49C8
    private static int ObjMapOutCheck( int lPosX, int lPosY, short sOfst, short sLeft, short sTop, short sRight, short sBottom )
    {
        int num;
        int num2;
        int num3;
        int num4;
        if ( ( AppMain.g_obj.flag & 16U ) != 0U )
        {
            AppMain.OBS_BLOCK_COLLISION obs_BLOCK_COLLISION = AppMain.ObjGetBlockCollision();
            if ( obs_BLOCK_COLLISION == null )
            {
                return 0;
            }
            num = obs_BLOCK_COLLISION.left - ( int )sOfst;
            num2 = obs_BLOCK_COLLISION.top - ( int )sOfst;
            num3 = obs_BLOCK_COLLISION.right - obs_BLOCK_COLLISION.left + ( ( int )sOfst << 1 );
            num4 = obs_BLOCK_COLLISION.bottom - obs_BLOCK_COLLISION.top + ( ( int )sOfst << 1 );
        }
        else
        {
            AppMain.OBS_DIFF_COLLISION obs_DIFF_COLLISION = AppMain.ObjGetDiffCollision();
            if ( obs_DIFF_COLLISION == null )
            {
                return 0;
            }
            num = obs_DIFF_COLLISION.left - ( int )sOfst;
            num2 = obs_DIFF_COLLISION.top - ( int )sOfst;
            num3 = obs_DIFF_COLLISION.right - obs_DIFF_COLLISION.left + ( ( int )sOfst << 1 );
            num4 = obs_DIFF_COLLISION.bottom - obs_DIFF_COLLISION.top + ( ( int )sOfst << 1 );
        }
        if ( num <= lPosX >> 12 && num + num3 >= lPosX >> 12 && num2 <= lPosY >> 12 && num2 + num4 >= lPosY >> 12 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001826 RID: 6182 RVA: 0x000D689C File Offset: 0x000D4A9C
    private static void objMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.g_obj.scale.x = AppMain.FX_Mul( AppMain.g_obj.glb_scale.x, AppMain.g_obj.draw_scale.x );
        AppMain.g_obj.scale.y = AppMain.FX_Mul( AppMain.g_obj.glb_scale.y, AppMain.g_obj.draw_scale.y );
        AppMain.g_obj.scale.z = AppMain.FX_Mul( AppMain.g_obj.glb_scale.z, AppMain.g_obj.draw_scale.z );
        AppMain.g_obj.inv_scale.x = AppMain.FX_Div( 4096, AppMain.g_obj.scale.x );
        AppMain.g_obj.inv_scale.y = AppMain.FX_Div( 4096, AppMain.g_obj.scale.y );
        AppMain.g_obj.inv_scale.z = AppMain.FX_Div( 4096, AppMain.g_obj.scale.z );
        if ( AppMain.g_obj.ppPre != null )
        {
            AppMain.g_obj.ppPre();
        }
        if ( ( AppMain.g_obj.flag & 64U ) != 0U )
        {
            AppMain.ObjRectCheckAllGroup();
        }
        if ( AppMain.g_obj.glb_camera_id >= 0 )
        {
            AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type, 15U );
            AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type, 0U );
        }
        if ( AppMain.g_obj.ppDrawSort != null )
        {
            AppMain.g_obj.ppDrawSort();
            for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.g_obj.obj_draw_list_head; obs_OBJECT_WORK != null; obs_OBJECT_WORK = obs_OBJECT_WORK.draw_next )
            {
                AppMain.objObjectDraw( obs_OBJECT_WORK );
            }
        }
        else
        {
            for ( AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.g_obj.obj_list_head; obs_OBJECT_WORK != null; obs_OBJECT_WORK = obs_OBJECT_WORK.next )
            {
                AppMain.objObjectDraw( obs_OBJECT_WORK );
            }
            AppMain.GmGmkPulleyDrawServerMain();
            AppMain.GmTvxExecuteDraw();
            AppMain.gmDecoDrawServerMain( null );
        }
        AppMain.ObjDrawAction2DAMADrawStart();
        AppMain.ObjDrawNNStart();
        if ( ( AppMain.g_obj.flag & 1U ) == 0U )
        {
            AppMain.ObjCollisionObjectClear();
        }
        AppMain.g_obj.timer_fx += AppMain.ObjTimeCountGet( 4096 );
        AppMain.g_obj.flag |= 4096U;
        if ( AppMain.g_obj.timer == ( uint )( AppMain.g_obj.timer_fx >> 12 ) )
        {
            AppMain.g_obj.flag &= 4294963199U;
        }
        AppMain.g_obj.timer = ( uint )( AppMain.g_obj.timer_fx >> 12 );
        if ( ( AppMain.g_obj.flag & 2U ) != 0U )
        {
            AppMain.g_obj.flag |= 1U;
        }
        else
        {
            AppMain.g_obj.flag &= 4294967294U;
        }
        if ( AppMain.g_obj.ppPost != null )
        {
            AppMain.g_obj.ppPost();
        }
    }

    // Token: 0x06001827 RID: 6183 RVA: 0x000D6B74 File Offset: 0x000D4D74
    private static void objObjectDraw( AppMain.OBS_OBJECT_WORK pWork )
    {
        uint num = 0U;
        uint num2 = AppMain.ObjObjectPauseCheck(pWork.flag);
        if ( ( pWork.flag & 4U ) == 0U )
        {
            if ( ( pWork.hitstop_timer != 0 && ( pWork.flag & 8192U ) == 0U ) || num2 != 0U )
            {
                num = ( pWork.disp_flag & 16U );
                pWork.disp_flag |= 16U;
            }
            if ( pWork.ppOut != null )
            {
                pWork.ppOut( pWork );
            }
            if ( pWork.ppOutSub != null )
            {
                pWork.ppOutSub( pWork );
            }
            if ( ( pWork.hitstop_timer != 0 && ( pWork.flag & 8192U ) == 0U ) || num2 != 0U )
            {
                pWork.disp_flag &= 4294967279U;
                pWork.disp_flag |= num;
            }
            if ( num2 == 0U )
            {
                pWork.prev_ofst.x = pWork.ofst.x;
                pWork.prev_ofst.y = pWork.ofst.y;
                pWork.prev_ofst.z = pWork.ofst.z;
                pWork.ofst.x = 0;
                pWork.ofst.y = 0;
                pWork.ofst.z = 0;
            }
        }
    }

    // Token: 0x06001828 RID: 6184 RVA: 0x000D6C98 File Offset: 0x000D4E98
    private static void objDestructor( AppMain.MTS_TASK_TCB pTcb )
    {
        AppMain.obj_ptcb = null;
        AppMain.ObjSetBlockCollision( null );
        AppMain.ObjSetDiffCollision( null );
        if ( ( AppMain.g_obj.flag & 1073741824U ) != 0U )
        {
            AppMain.obj_data_max_save = AppMain.g_obj.data_max;
            AppMain.obj_data_work_save = AppMain.g_obj.pData;
            AppMain.g_obj.data_max = 0;
            AppMain.g_obj.pData = null;
            return;
        }
        AppMain.ObjDataFree();
    }

    // Token: 0x06001829 RID: 6185 RVA: 0x000D6D04 File Offset: 0x000D4F04
    private static void objExitWait( AppMain.MTS_TASK_TCB pTcb )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject(null, ushort.MaxValue);
        if ( obs_OBJECT_WORK == null )
        {
            AppMain.mtTaskClearTcb( AppMain.obj_ptcb );
            AppMain.g_obj = new AppMain.OBS_OBJECT();
            return;
        }
        while ( obs_OBJECT_WORK != null )
        {
            obs_OBJECT_WORK.flag |= 4U;
            obs_OBJECT_WORK = AppMain.ObjObjectSearchRegistObject( obs_OBJECT_WORK, ushort.MaxValue );
        }
    }

    // Token: 0x0600182A RID: 6186 RVA: 0x000D6D54 File Offset: 0x000D4F54
    private static void objObjectExitDataRelease( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = false;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        if ( obs_OBJECT_WORK.ppUserRelease != null && obs_OBJECT_WORK.ppUserRelease( obs_OBJECT_WORK ) )
        {
            flag = true;
        }
        if ( obs_OBJECT_WORK.obj_3d != null && ( obs_OBJECT_WORK.flag & 536870912U ) == 0U )
        {
            AppMain.ObjAction3dNNModelRelease( obs_OBJECT_WORK.obj_3d );
            flag = true;
        }
        if ( obs_OBJECT_WORK.obj_3des != null )
        {
            if ( obs_OBJECT_WORK.obj_3des.texlist != null )
            {
                AppMain.ObjAction3dESTextureRelease( obs_OBJECT_WORK.obj_3des );
                flag = true;
            }
            if ( obs_OBJECT_WORK.obj_3des.model != null )
            {
                AppMain.ObjAction3dESModelRelease( obs_OBJECT_WORK.obj_3des );
                flag = true;
            }
        }
        if ( obs_OBJECT_WORK.obj_2d != null && obs_OBJECT_WORK.obj_2d.ao_tex.texlist != null )
        {
            AppMain.AoTexRelease( obs_OBJECT_WORK.obj_2d.ao_tex );
            flag = true;
        }
        if ( flag )
        {
            AppMain.mtTaskChangeTcbProcedure( tcb, AppMain._objObjectDataReleaseCheck );
            return;
        }
        AppMain.mtTaskClearTcb( tcb );
    }

    // Token: 0x0600182B RID: 6187 RVA: 0x000D6E24 File Offset: 0x000D5024
    private static void objObjectDataReleaseCheck( AppMain.MTS_TASK_TCB tcb )
    {
        bool flag = true;
        bool flag2 = true;
        bool flag3 = true;
        bool flag4 = true;
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = AppMain.mtTaskGetTcbWork(tcb);
        if ( obs_OBJECT_WORK.ppUserReleaseWait != null && obs_OBJECT_WORK.ppUserReleaseWait( obs_OBJECT_WORK ) )
        {
            flag = false;
        }
        if ( obs_OBJECT_WORK.obj_3d != null && ( obs_OBJECT_WORK.flag & 536870912U ) == 0U )
        {
            if ( AppMain.ObjAction3dNNModelReleaseCheck( obs_OBJECT_WORK.obj_3d ) )
            {
                flag2 = true;
                obs_OBJECT_WORK.obj_3d.reg_index = -1;
            }
            else
            {
                flag2 = false;
            }
        }
        if ( obs_OBJECT_WORK.obj_3des != null )
        {
            flag3 = true;
            if ( obs_OBJECT_WORK.obj_3des.ecb != null )
            {
                AppMain.ObjAction3dESEffectRelease( obs_OBJECT_WORK.obj_3des );
            }
            if ( !AppMain.ObjAction3dESModelReleaseCheck( obs_OBJECT_WORK.obj_3des ) )
            {
                flag3 = false;
            }
            if ( !AppMain.ObjAction3dESTextureReleaseCheck( obs_OBJECT_WORK.obj_3des ) )
            {
                flag3 = false;
            }
        }
        if ( obs_OBJECT_WORK.obj_2d != null && obs_OBJECT_WORK.obj_2d.ao_tex.texlist != null && !AppMain.AoTexIsReleased( obs_OBJECT_WORK.obj_2d.ao_tex ) )
        {
            flag4 = false;
        }
        if ( flag2 && flag3 && flag && flag4 )
        {
            AppMain.mtTaskClearTcb( tcb );
        }
    }

    // Token: 0x0600182C RID: 6188 RVA: 0x000D6F10 File Offset: 0x000D5110
    private static ushort objObjectParent( AppMain.OBS_OBJECT_WORK pWork )
    {
        AppMain.OBS_OBJECT_WORK parent_obj = pWork.parent_obj;
        if ( parent_obj != null )
        {
            if ( ( parent_obj.flag & 4U ) != 0U )
            {
                if ( ( pWork.flag & 512U ) == 0U )
                {
                    pWork.flag |= 4U;
                    pWork.parent_obj = null;
                    return 1;
                }
                pWork.parent_obj = null;
            }
            if ( AppMain.ObjObjectPauseCheck( pWork.flag ) == 0U )
            {
                if ( ( pWork.flag & 1024U ) != 0U )
                {
                    if ( ( pWork.flag & 131072U ) == 0U )
                    {
                        pWork.disp_flag &= 4294967292U;
                        pWork.disp_flag |= ( parent_obj.disp_flag & 3U );
                    }
                    if ( ( pWork.flag & 524288U ) == 0U )
                    {
                        pWork.disp_flag &= 4294967263U;
                        pWork.disp_flag |= ( parent_obj.disp_flag & 32U );
                    }
                    pWork.pos.x = parent_obj.pos.x + pWork.parent_ofst.x;
                    pWork.pos.y = parent_obj.pos.y + pWork.parent_ofst.y;
                    pWork.pos.z = parent_obj.pos.z + pWork.parent_ofst.z;
                    if ( ( pWork.disp_flag & 1U ) != 0U )
                    {
                        pWork.pos.x = parent_obj.pos.x - pWork.parent_ofst.x;
                    }
                    if ( ( pWork.disp_flag & 2U ) != 0U )
                    {
                        pWork.pos.y = parent_obj.pos.y - pWork.parent_ofst.y;
                    }
                    pWork.ofst.x = parent_obj.prev_ofst.x;
                    pWork.ofst.y = parent_obj.prev_ofst.y;
                    pWork.ofst.z = parent_obj.prev_ofst.z;
                    if ( parent_obj.hitstop_timer != 0 )
                    {
                        pWork.hitstop_timer = parent_obj.hitstop_timer;
                        pWork.hitstop_timer += AppMain.ObjTimeCountGet( 4096 );
                    }
                }
                if ( ( pWork.flag & 2048U ) != 0U )
                {
                    pWork.disp_flag &= 4294967235U;
                    pWork.disp_flag |= ( parent_obj.disp_flag & 60U );
                }
            }
        }
        return 0;
    }

    // Token: 0x0600182D RID: 6189 RVA: 0x000D7148 File Offset: 0x000D5348
    private static void ObjObjectCollision( AppMain.OBS_OBJECT_WORK pWork )
    {
        int x = pWork.pos.x;
        int y = pWork.pos.y;
        int x2 = pWork.pos.x;
        int y2 = pWork.pos.y;
        int x3 = pWork.prev_pos.x;
        int y3 = pWork.prev_pos.y;
        ushort num = 32768;
        uint num2 = 0U;
        uint num3 = 0U;
        pWork.col_flag_prev = pWork.col_flag;
        pWork.col_flag = 0U;
        if ( ( pWork.move_flag & 256U ) == 0U )
        {
            pWork.move_flag &= 4290772991U;
            if ( ( pWork.move_flag & 1U ) != 0U )
            {
                pWork.move_flag |= 4194304U;
            }
            pWork.move_flag &= 4294967280U;
            if ( ( pWork.move_flag & 1U ) == 0U )
            {
                num = ( ushort )( num >> 1 );
            }
            if ( Math.Abs( pWork.pos.x - pWork.prev_pos.x ) > ( int )num || Math.Abs( pWork.pos.y - pWork.prev_pos.y ) > ( int )num )
            {
                pWork.pos.x = pWork.prev_pos.x;
                pWork.pos.y = pWork.prev_pos.y;
                for (; ; )
                {
                    if ( Math.Abs( pWork.pos.x - x ) > ( int )num )
                    {
                        pWork.prev_pos.x = pWork.pos.x;
                        if ( x > pWork.prev_pos.x )
                        {
                            pWork.pos.x = pWork.prev_pos.x + ( int )num;
                        }
                        else
                        {
                            pWork.pos.x = pWork.prev_pos.x - ( int )num;
                        }
                    }
                    else
                    {
                        pWork.pos.x = x;
                    }
                    if ( Math.Abs( pWork.pos.y - y ) > ( int )num )
                    {
                        pWork.prev_pos.y = pWork.pos.y;
                        if ( y > pWork.prev_pos.y )
                        {
                            pWork.pos.y = pWork.prev_pos.y + ( int )num;
                        }
                        else
                        {
                            pWork.pos.y = pWork.prev_pos.y - ( int )num;
                        }
                    }
                    else
                    {
                        pWork.pos.y = y;
                    }
                    if ( pWork.pos.x == x && pWork.pos.y == y )
                    {
                        break;
                    }
                    x2 = pWork.pos.x;
                    y2 = pWork.pos.y;
                    AppMain.ObjDiffCollisionEarthCheck( pWork );
                    num2 |= pWork.col_flag;
                    num3 |= ( pWork.move_flag & 15U );
                    if ( x2 != pWork.pos.x )
                    {
                        x = pWork.pos.x;
                    }
                    if ( y2 != pWork.pos.y )
                    {
                        y = pWork.pos.y;
                    }
                }
            }
            AppMain.ObjDiffCollisionEarthCheck( pWork );
            num2 |= pWork.col_flag;
            pWork.col_flag = num2;
            pWork.move_flag |= num3;
            if ( ( pWork.move_flag & 32U ) != 0U && ( pWork.col_flag & 2U ) == 0U )
            {
                pWork.move_flag &= 4294967263U;
            }
        }
        pWork.prev_pos.x = x3;
        pWork.prev_pos.y = y3;
    }

    // Token: 0x0600182E RID: 6190 RVA: 0x000D747C File Offset: 0x000D567C
    private static void ObjObjectMove( AppMain.OBS_OBJECT_WORK pWork )
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        pWork.prev_pos.x = pWork.pos.x;
        pWork.prev_pos.y = pWork.pos.y;
        pWork.prev_pos.z = pWork.pos.z;
        if ( ( pWork.move_flag & 134217728U ) != 0U )
        {
            pWork.flow.x = 0;
            pWork.flow.y = 0;
            pWork.flow.z = 0;
        }
        int x = pWork.flow.x;
        int y = pWork.flow.y;
        if ( ( x != 0 || y != 0 ) && pWork.dir_fall != 0 )
        {
            AppMain.ObjObjectSpdDirFall( ref x, ref y, pWork.dir_fall );
        }
        if ( pWork.hitstop_timer != 0 )
        {
            pWork.move.x = AppMain.FX_Mul( x, AppMain._g_obj.speed );
            pWork.move.y = AppMain.FX_Mul( y, AppMain._g_obj.speed );
            pWork.move.z = AppMain.FX_Mul( pWork.flow.z, AppMain._g_obj.speed );
        }
        else
        {
            if ( ( pWork.move_flag & 1U ) == 0U )
            {
                if ( ( pWork.move_flag & 128U ) != 0U && ( pWork.move_flag & 1U ) == 0U )
                {
                    pWork.spd.y = pWork.spd.y + AppMain.FX_Mul( pWork.spd_fall, AppMain._g_obj.speed );
                }
                if ( ( pWork.move_flag & 128U ) != 0U && pWork.spd.y > pWork.spd_fall_max )
                {
                    pWork.spd.y = pWork.spd_fall_max;
                }
            }
            if ( ( pWork.move_flag & 64U ) != 0U )
            {
                if ( ( pWork.move_flag & 131072U ) != 0U && ( pWork.spd_m != 0 || ( pWork.move_flag & 262144U ) == 0U ) )
                {
                    int num4 = AppMain.FX_Mul(pWork.spd_slope, AppMain.mtMathSin((int)pWork.dir.z));
                    if ( num4 != 0 )
                    {
                        pWork.spd_m = AppMain.ObjSpdUpSet( pWork.spd_m, num4, pWork.spd_slope_max );
                    }
                    else if ( pWork.spd_m > 0 )
                    {
                        if ( pWork.spd_m > pWork.spd_slope_max )
                        {
                            pWork.spd_m = pWork.spd_slope_max;
                        }
                    }
                    else if ( pWork.spd_m < -pWork.spd_slope_max )
                    {
                        pWork.spd_m = -pWork.spd_slope_max;
                    }
                }
                if ( ( pWork.move_flag & 32768U ) == 0U )
                {
                    num = AppMain.FX_Mul( pWork.spd_m, AppMain.mtMathCos( ( int )pWork.dir.z ) );
                    num2 = AppMain.FX_Mul( pWork.spd_m, AppMain.mtMathSin( ( int )pWork.dir.z ) );
                }
            }
            if ( ( pWork.move_flag & 67108864U ) != 0U )
            {
                pWork.move.x = AppMain.FX_Mul( pWork.spd.x + num + x, AppMain._g_obj.speed );
                pWork.move.y = AppMain.FX_Mul( pWork.spd.y + num2 + y, AppMain._g_obj.speed );
            }
            else
            {
                pWork.move.x = AppMain.FX_Mul( pWork.spd.x + num + x + AppMain._g_obj.scroll[0], AppMain._g_obj.speed );
                pWork.move.y = AppMain.FX_Mul( pWork.spd.y + num2 + y + AppMain._g_obj.scroll[1], AppMain._g_obj.speed );
            }
            pWork.move.z = AppMain.FX_Mul( pWork.spd.z + num3 + pWork.flow.z, AppMain._g_obj.speed );
            AppMain.ObjObjectSpdDirFall( ref pWork.move.x, ref pWork.move.y, pWork.dir_fall );
        }
        pWork.pos.x = pWork.pos.x + pWork.move.x;
        pWork.pos.y = pWork.pos.y + pWork.move.y;
        pWork.pos.z = pWork.pos.z + pWork.move.z;
        pWork.spd.x = pWork.spd.x + pWork.spd_add.x;
        pWork.spd.y = pWork.spd.y + pWork.spd_add.y;
        pWork.spd.z = pWork.spd.z + pWork.spd_add.z;
        pWork.flow.x = 0;
        pWork.flow.y = 0;
        pWork.flow.z = 0;
    }

    // Token: 0x0600182F RID: 6191 RVA: 0x000D790C File Offset: 0x000D5B0C
    private static void objObjectColRideTouchCheck( AppMain.OBS_OBJECT_WORK pWork )
    {
        if ( pWork.col_work != null )
        {
            if ( pWork.col_work.obj_col.rider_obj != null && ( pWork.col_work.obj_col.rider_obj.flag & 4U ) != 0U )
            {
                pWork.col_work.obj_col.rider_obj = null;
            }
            if ( pWork.col_work.obj_col.toucher_obj != null && pWork.col_work.obj_col.toucher_obj != pWork.col_work.obj_col.rider_obj && pWork.col_work.obj_col.toucher_obj != null )
            {
                if ( AppMain.ObjObjectPauseCheck( pWork.flag ) == 0U && pWork.col_work.obj_col.toucher_obj != pWork.col_work.obj_col.rider_obj && ( pWork.col_work.obj_col.toucher_obj.move_flag & 16777216U ) != 0U && ( pWork.move_flag & 33554432U ) != 0U )
                {
                    int num = pWork.col_work.obj_col.toucher_obj.move.x;
                    num = AppMain.MTM_MATH_CLIP( num, -pWork.col_work.obj_col.toucher_obj.push_max, pWork.col_work.obj_col.toucher_obj.push_max );
                    num = AppMain.MTM_MATH_CLIP( num, -pWork.push_max, pWork.push_max );
                    pWork.flow.x = pWork.flow.x + num;
                }
                if ( ( pWork.col_work.obj_col.toucher_obj.flag & 4U ) != 0U )
                {
                    pWork.col_work.obj_col.toucher_obj = null;
                }
            }
        }
        if ( pWork.touch_obj != null )
        {
            if ( AppMain.ObjObjectPauseCheck( pWork.flag ) == 0U && ( pWork.touch_obj.move_flag & 33554432U ) != 0U && ( pWork.move_flag & 16777216U ) != 0U )
            {
                pWork.flow.x = pWork.flow.x + ( int )( ( short )( pWork.touch_obj.pos.x - pWork.touch_obj.prev_pos.x ) );
                if ( ( pWork.touch_obj.move.x & 4095 ) != 0 )
                {
                    if ( pWork.touch_obj.move.x > 0 )
                    {
                        pWork.flow.x = pWork.flow.x + ( 4096 - ( pWork.touch_obj.move.x & 4095 ) );
                    }
                    else
                    {
                        pWork.flow.x = pWork.flow.x - ( 4096 + ( pWork.touch_obj.move.x & 4095 ) );
                    }
                }
            }
            if ( ( pWork.touch_obj.flag & 4U ) != 0U )
            {
                pWork.touch_obj = null;
            }
        }
        if ( pWork.ride_obj != null )
        {
            if ( ( pWork.ride_obj.flag & 4U ) != 0U )
            {
                pWork.ride_obj = null;
                return;
            }
            if ( AppMain.ObjObjectPauseCheck( pWork.flag ) == 0U )
            {
                if ( ( pWork.ride_obj.move_flag & 256U ) != 0U )
                {
                    pWork.flow.x = pWork.flow.x + pWork.ride_obj.move.x;
                    pWork.flow.y = pWork.flow.y + pWork.ride_obj.move.y;
                    pWork.flow.z = pWork.flow.z + pWork.ride_obj.move.z;
                }
                else
                {
                    pWork.flow.x = pWork.flow.x + ( int )( ( short )( pWork.ride_obj.pos.x - pWork.ride_obj.prev_pos.x ) );
                    pWork.flow.y = pWork.flow.y + ( int )( ( short )( pWork.ride_obj.pos.y - pWork.ride_obj.prev_pos.y ) );
                    pWork.flow.z = pWork.flow.z + ( int )( ( short )( pWork.ride_obj.pos.z - pWork.ride_obj.prev_pos.z ) );
                }
                if ( ( pWork.ride_obj.move.y & 4095 ) != 0 )
                {
                    pWork.flow.y = pWork.flow.y + ( 4096 - ( pWork.ride_obj.move.y & 4095 ) );
                }
            }
        }
    }

    // Token: 0x06001830 RID: 6192 RVA: 0x000D7D57 File Offset: 0x000D5F57
    private static void ObjObjectFieldRectSet( AppMain.OBS_OBJECT_WORK pObj, short cLeft, short cTop, short cRight, short cBottom )
    {
        pObj.field_rect[0] = cLeft;
        pObj.field_rect[1] = cTop;
        pObj.field_rect[2] = cRight;
        pObj.field_rect[3] = cBottom;
        pObj.move_flag &= 4294967039U;
    }

    // Token: 0x06001831 RID: 6193 RVA: 0x000D7D90 File Offset: 0x000D5F90
    private static void ObjObjectFallSet( AppMain.OBS_OBJECT_WORK pObj, int fSpdFall, int fSpdFallMax )
    {
        pObj.spd_fall = fSpdFall;
        pObj.spd_fall_max = fSpdFallMax;
        pObj.move_flag |= 128U;
    }
}