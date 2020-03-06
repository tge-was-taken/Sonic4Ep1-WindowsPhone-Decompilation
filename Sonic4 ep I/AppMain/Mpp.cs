using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020000DC RID: 220
    // (Invoke) Token: 0x06001F2F RID: 7983
    public delegate void MPP_VOID_OBJECT_DELEGATE( object o );

    // Token: 0x020000DD RID: 221
    // (Invoke) Token: 0x06001F33 RID: 7987
    public delegate bool MPP_BOOL_NNSDRAWCALLBACKVAL_OBJECT_DELEGATE( AppMain.NNS_DRAWCALLBACK_VAL drawCallback, object p );

    // Token: 0x020000DE RID: 222
    // (Invoke) Token: 0x06001F37 RID: 7991
    public delegate void MPP_VOID_NNSMATRIX_NNSOBJECT_OBJECT( ref AppMain.NNS_MATRIX m, AppMain.NNS_OBJECT nnso, object o );

    // Token: 0x020000DF RID: 223
    // (Invoke) Token: 0x06001F3B RID: 7995
    public delegate void MPP_VOID_ARRAYNNSMATRIX_NNSOBJECT_OBJECT( AppMain.NNS_MATRIX[] m, AppMain.NNS_OBJECT nnso, object o );

    // Token: 0x020000E0 RID: 224
    // (Invoke) Token: 0x06001F3F RID: 7999
    public delegate void MPP_VOID_GMS_FIX_PART_WORK( AppMain.GMS_FIX_PART_WORK pPart );

    // Token: 0x020000E1 RID: 225
    // (Invoke) Token: 0x06001F43 RID: 8003
    public delegate void MPP_VOID_OBS_OBJECT_WORK( AppMain.OBS_OBJECT_WORK pPart );

    // Token: 0x020000E2 RID: 226
    // (Invoke) Token: 0x06001F47 RID: 8007
    public delegate void GMF_FIX_PART_INIT_FUNC( AppMain.GMS_FIX_MGR_WORK pArg );

    // Token: 0x020000E3 RID: 227
    // (Invoke) Token: 0x06001F4B RID: 8011
    public delegate void MPP_VOID_GMSGAMEDATLOADCONTEXT( AppMain.GMS_GAMEDAT_LOAD_CONTEXT p );

    // Token: 0x020000E4 RID: 228
    // (Invoke) Token: 0x06001F4F RID: 8015
    public delegate void MPP_OBJECT_STRING( string p );

    // Token: 0x020000E5 RID: 229
    // (Invoke) Token: 0x06001F53 RID: 8019
    public delegate void MPP_VOID_MOTION_NSSOBJECT_OBJECT( AppMain.AMS_MOTION motion, AppMain.NNS_OBJECT _object, object bmcb_param );

    // Token: 0x020000E6 RID: 230
    // (Invoke) Token: 0x06001F57 RID: 8023
    public delegate void MPP_VOID_GMS_BOSS1_BODY_WORK( AppMain.GMS_BOSS1_BODY_WORK wrk );

    // Token: 0x020000E7 RID: 231
    // (Invoke) Token: 0x06001F5B RID: 8027
    public delegate void MPP_VOID_GMS_BOSS1_EGG_WORK( AppMain.GMS_BOSS1_EGG_WORK wrk );

    // Token: 0x020000E8 RID: 232
    // (Invoke) Token: 0x06001F5F RID: 8031
    public delegate void MPP_VOID_GMS_BOSS1_CHAIN_WORK( AppMain.GMS_BOSS1_CHAIN_WORK wrk );

    // Token: 0x020000E9 RID: 233
    // (Invoke) Token: 0x06001F63 RID: 8035
    public delegate void MPP_VOID_GMS_BOSS2_BODY_WORK( AppMain.GMS_BOSS2_BODY_WORK wrk );

    // Token: 0x020000EA RID: 234
    // (Invoke) Token: 0x06001F67 RID: 8039
    public delegate void MPP_VOID_GMS_BOSS2_EGG_WORK( AppMain.GMS_BOSS2_EGG_WORK wrk );

    // Token: 0x020000EB RID: 235
    // (Invoke) Token: 0x06001F6B RID: 8043
    public delegate void MPP_VOID_GMS_BOSS2_BALL_WORK( AppMain.GMS_BOSS2_BALL_WORK wrk );

    // Token: 0x020000EC RID: 236
    // (Invoke) Token: 0x06001F6F RID: 8047
    public delegate void MPP_VOID_GMS_BOSS4_BODY_WORK( AppMain.GMS_BOSS4_BODY_WORK wrk );

    // Token: 0x020000ED RID: 237
    // (Invoke) Token: 0x06001F73 RID: 8051
    public delegate void MPP_VOID_GMS_BOSS4_EGG_WORK( AppMain.GMS_BOSS4_EGG_WORK wrk );

    // Token: 0x020000EE RID: 238
    // (Invoke) Token: 0x06001F77 RID: 8055
    public delegate void MPP_VOID_GMS_BOSS4_CHIBI_WORK( AppMain.GMS_BOSS4_CHIBI_WORK wrk );

    // Token: 0x020000EF RID: 239
    // (Invoke) Token: 0x06001F7B RID: 8059
    public delegate void MPP_VOID_GMS_BOSS4_CAP_WORK( AppMain.GMS_BOSS4_CAP_WORK wrk );

    // Token: 0x020000F0 RID: 240
    // (Invoke) Token: 0x06001F7F RID: 8063
    public delegate void MPP_VOID_GMS_BOSS5_BODY_WORK( AppMain.GMS_BOSS5_BODY_WORK wrk );

    // Token: 0x020000F1 RID: 241
    // (Invoke) Token: 0x06001F83 RID: 8067
    public delegate void MPP_VOID_GMS_BOSS5_ALARM_FADE_WORK( AppMain.GMS_BOSS5_ALARM_FADE_WORK wrk );

    // Token: 0x020000F2 RID: 242
    // (Invoke) Token: 0x06001F87 RID: 8071
    public delegate void MPP_VOID_GMS_BOSS5_MGR_WORK( AppMain.GMS_BOSS5_MGR_WORK wrk );

    // Token: 0x020000F3 RID: 243
    // (Invoke) Token: 0x06001F8B RID: 8075
    public delegate void MPP_VOID_GMS_BOSS5_CORE_WORK( AppMain.GMS_BOSS5_CORE_WORK wrk );

    // Token: 0x020000F4 RID: 244
    // (Invoke) Token: 0x06001F8F RID: 8079
    public delegate void MPP_VOID_GMS_BOSS5_ROCKET_WORK( AppMain.GMS_BOSS5_ROCKET_WORK wrk );

    // Token: 0x020000F5 RID: 245
    // (Invoke) Token: 0x06001F93 RID: 8083
    public delegate void MPP_VOID_GMS_BOSS5_TURRET_WORK( AppMain.GMS_BOSS5_TURRET_WORK wrk );

    // Token: 0x020000F6 RID: 246
    // (Invoke) Token: 0x06001F97 RID: 8087
    public delegate void MPP_VOID_GMS_BOSS5_EGG_WORK( AppMain.GMS_BOSS5_EGG_WORK wrk );

    // Token: 0x020000F7 RID: 247
    // (Invoke) Token: 0x06001F9B RID: 8091
    public delegate void MPP_VOID_GMS_BOSS5_CTPLT_WORK( AppMain.GMS_BOSS5_CTPLT_WORK wrk );

    // Token: 0x020000F8 RID: 248
    // (Invoke) Token: 0x06001F9F RID: 8095
    public delegate void MPP_VOID_GMS_BOSS5_LAND_WORK( AppMain.GMS_BOSS5_LAND_WORK wrk );

    // Token: 0x020000F9 RID: 249
    // (Invoke) Token: 0x06001FA3 RID: 8099
    public delegate void MPP_VOID_GMS_BOSS5_LDPART_WORK( AppMain.GMS_BOSS5_LDPART_WORK wrk );
}