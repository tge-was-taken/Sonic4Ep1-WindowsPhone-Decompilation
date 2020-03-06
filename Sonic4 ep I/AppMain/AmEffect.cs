using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;

public partial class AppMain
{
    // Token: 0x06001A51 RID: 6737 RVA: 0x000EB36E File Offset: 0x000E956E
    public static int amEffectIsDelete( AppMain.AMS_AME_ECB ecb )
    {
        if ( ecb.entry_num >= 0 )
        {
            return 0;
        }
        return 1;
    }

    // Token: 0x06001A52 RID: 6738 RVA: 0x000EB37C File Offset: 0x000E957C
    private AppMain.AMS_AME_ECB amEffectCreate( AppMain.AMS_AME_NODE node )
    {
        return this.amEffectCreate( node, 0, 0 );
    }

    // Token: 0x06001A53 RID: 6739 RVA: 0x000EB387 File Offset: 0x000E9587
    private AppMain.AMS_AME_ECB amEffectCreate( AppMain.AMS_AME_HEADER header )
    {
        return AppMain._amEffectCreate( header, 0, 0 );
    }

    // Token: 0x06001A54 RID: 6740 RVA: 0x000EB391 File Offset: 0x000E9591
    private void amEffectSetTransparency( AppMain.AMS_AME_ECB ecb, float t )
    {
        ecb.transparency = ( int )( t * 256f );
    }

    // Token: 0x06001A55 RID: 6741 RVA: 0x000EB3A1 File Offset: 0x000E95A1
    public static void amEffectSetSizeRate( AppMain.AMS_AME_ECB ecb, float t )
    {
        ecb.size_rate = t;
    }

    // Token: 0x06001A56 RID: 6742 RVA: 0x000EB3AC File Offset: 0x000E95AC
    public static void amEffectLerpColor( out AppMain.AMS_RGBA8888 pCO, ref AppMain.AMS_RGBA8888 pC1, ref AppMain.AMS_RGBA8888 pC2, float rate )
    {
        int num = (int)(rate * 256f);
        pCO = default( AppMain.AMS_RGBA8888 );
        pCO.r = ( byte )( ( ( int )pC1.r << 8 ) + ( int )( pC2.r - pC1.r ) * num >> 8 );
        pCO.g = ( byte )( ( ( int )pC1.g << 8 ) + ( int )( pC2.g - pC1.g ) * num >> 8 );
        pCO.b = ( byte )( ( ( int )pC1.b << 8 ) + ( int )( pC2.b - pC1.b ) * num >> 8 );
        pCO.a = ( byte )( ( ( int )pC1.a << 8 ) + ( int )( pC2.a - pC1.a ) * num >> 8 );
    }

    // Token: 0x06001A57 RID: 6743 RVA: 0x000EB44F File Offset: 0x000E964F
    public static void amEffectDisconnectLink( AppMain.AMS_AME_LIST list )
    {
        list.prev.next = list.next;
        list.next.prev = list.prev;
    }

    // Token: 0x06001A58 RID: 6744 RVA: 0x000EB473 File Offset: 0x000E9673
    private void amEffectRandomConeVector( ref Vector4 pOut, float s )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001A59 RID: 6745 RVA: 0x000EB47C File Offset: 0x000E967C
    public static void amEffectRandomConeVectorDeg( AppMain.NNS_VECTOR4D pOut, float s )
    {
        float num = AppMain.nnCos(AppMain.NNM_DEGtoA32(s));
        float num2 = AppMain.nnRandom() * (1f - num) + num;
        float num3 = (float)Math.Sqrt((double)(1f - num2 * num2));
        AppMain.amSinCos( AppMain.nnRandom() * 6.2831855f, out s, out num );
        AppMain.amVectorSet( pOut, num3 * num, num2, num3 * s );
        AppMain.amVectorUnit( pOut );
    }

    // Token: 0x06001A5A RID: 6746 RVA: 0x000EB4DF File Offset: 0x000E96DF
    private void _amConnectLinkToHead( AppMain.AMS_AME_LIST head, AppMain.AMS_AME_LIST list )
    {
        list.next = head.next;
        list.prev = head.next.prev;
        head.next.prev = list;
        head.next = list;
    }

    // Token: 0x06001A5B RID: 6747 RVA: 0x000EB511 File Offset: 0x000E9711
    public static void _amConnectLinkToTail( AppMain.AMS_AME_LIST tail, AppMain.AMS_AME_LIST list )
    {
        list.prev = tail.prev;
        list.next = tail.prev.next;
        tail.prev.next = list;
        tail.prev = list;
    }

    // Token: 0x06001A5C RID: 6748 RVA: 0x000EB544 File Offset: 0x000E9744
    public static void amEffectSystemInit()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_RGB nns_RGB = new AppMain.NNS_RGB(1f, 1f, 1f);
        AppMain.nnSetPrimitive3DMaterial( ref nns_RGBA, ref nns_RGB, 1f );
        AppMain._am_enable_draw = 1;
        AppMain._am_unit_frame = 1f;
        AppMain._am_unit_time = 0.016666668f;
        AppMain._am_ecb_alloc = 0;
        AppMain._am_ecb_free = 0;
        AppMain._am_ecb_head.Clear();
        AppMain._am_ecb_tail.Clear();
        AppMain._am_ecb_head.next = AppMain._am_ecb_tail;
        AppMain._am_ecb_tail.prev = AppMain._am_ecb_head;
        AppMain._am_ecb_buf = AppMain.New<AppMain.AMS_AME_ECB>( 128 );
        AppMain._am_ecb_ref = new AppMain.AMS_AME_ECB[128];
        for ( int i = 0; i < 128; i++ )
        {
            AppMain._am_ecb_ref[i] = AppMain._am_ecb_buf[i];
        }
        AppMain._am_entry_alloc = 0;
        AppMain._am_entry_free = 0;
        AppMain._am_entry_buf = new AppMain.AMS_AME_ENTRY[512];
        AppMain._am_entry_ref = new AppMain.AMS_AME_ENTRY[512];
        for ( int j = 0; j < 512; j++ )
        {
            AppMain._am_entry_buf[j] = new AppMain.AMS_AME_ENTRY();
            AppMain._am_entry_ref[j] = AppMain._am_entry_buf[j];
        }
        AppMain._am_runtime_alloc = 0;
        AppMain._am_runtime_free = 0;
        AppMain._am_runtime_buf = new AppMain.AMS_AME_RUNTIME[512];
        AppMain._am_runtime_ref = new AppMain.AMS_AME_RUNTIME[512];
        for ( int k = 0; k < 512; k++ )
        {
            AppMain._am_runtime_buf[k] = new AppMain.AMS_AME_RUNTIME();
            AppMain._am_runtime_ref[k] = AppMain._am_runtime_buf[k];
        }
        AppMain._am_work_alloc = 0;
        AppMain._am_work_free = 0;
        AppMain._am_work_buf = new AppMain.AMS_AME_RUNTIME_WORK[1024];
        AppMain._am_work_ref = new AppMain.AMS_AME_RUNTIME_WORK[1024];
        for ( int l = 0; l < 1024; l++ )
        {
            AppMain._am_work_buf[l] = new AppMain.AMS_AME_RUNTIME_WORK();
            AppMain._am_work_ref[l] = AppMain._am_work_buf[l];
        }
    }

    // Token: 0x06001A5D RID: 6749 RVA: 0x000EB732 File Offset: 0x000E9932
    private void amEffectSystemReset()
    {
        AppMain.mppAssertNotImpl();
        AppMain.amEffectSystemInit();
    }

    // Token: 0x06001A5E RID: 6750 RVA: 0x000EB740 File Offset: 0x000E9940
    public static void amEffectExecute()
    {
        for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
        {
            if ( ams_AME_ECB.entry_num < 0 )
            {
                AppMain._amEffectFinalize( ams_AME_ECB );
            }
        }
    }

    // Token: 0x06001A5F RID: 6751 RVA: 0x000EB784 File Offset: 0x000E9984
    private void amEffectRegistCustomFunc( int classId, AppMain.AMS_AME_CUSTOM_PARAM pParam )
    {
        AppMain.mppAssertNotImpl();
        int num = classId & 65280;
        int num2 = num;
        int num3;
        if ( num2 == 256 )
        {
            num3 = ( classId & 255 ) << 2;
            AppMain._am_emitter_func[num3] = pParam.pInitFunc;
            AppMain._am_emitter_func[num3 + 1] = pParam.pUpdateFunc;
            AppMain._am_emitter_func[num3 + 2] = pParam.pDrawFunc;
            return;
        }
        if ( num2 == 512 )
        {
            num3 = ( classId & 255 ) << 2;
            AppMain._am_particle_func[num3] = pParam.pInitFunc;
            AppMain._am_particle_func[num3 + 1] = pParam.pUpdateFunc;
            AppMain._am_particle_func[num3 + 2] = pParam.pDrawFunc;
            return;
        }
        if ( num2 != 768 )
        {
            return;
        }
        num3 = ( classId & 255 );
        AppMain._am_field_func[num3] = pParam.pFieldFunc;
    }

    // Token: 0x06001A60 RID: 6752 RVA: 0x000EB83C File Offset: 0x000E9A3C
    private void amEffectUnregistCustomFunc( int classId )
    {
        AppMain.mppAssertNotImpl();
        int num = classId & 65280;
        int num2 = num;
        int num3;
        if ( num2 == 256 )
        {
            num3 = ( classId & 255 ) << 2;
            AppMain._am_emitter_func[num3] = null;
            AppMain._am_emitter_func[num3 + 1] = null;
            AppMain._am_emitter_func[num3 + 2] = null;
            return;
        }
        if ( num2 == 512 )
        {
            num3 = ( classId & 255 ) << 2;
            AppMain._am_particle_func[num3] = null;
            AppMain._am_particle_func[num3 + 1] = null;
            AppMain._am_particle_func[num3 + 2] = null;
            return;
        }
        if ( num2 != 768 )
        {
            return;
        }
        num3 = ( classId & 255 );
        AppMain._am_field_func[num3] = null;
    }

    // Token: 0x06001A61 RID: 6753 RVA: 0x000EB8CF File Offset: 0x000E9ACF
    public static void amEffectSetObject( AppMain.AMS_AME_ECB ecb, AppMain.NNS_OBJECT object_, int state )
    {
        ecb.pObj = object_;
        ecb.drawObjState = ( uint )state;
    }

    // Token: 0x06001A62 RID: 6754 RVA: 0x000EB8DF File Offset: 0x000E9ADF
    private static void amEffectSetWorldViewMatrix( AppMain.NNS_MATRIX mtx )
    {
        AppMain.nnCopyMatrix( AppMain._am_ef_worldViewMtx, mtx );
    }

    // Token: 0x06001A63 RID: 6755 RVA: 0x000EB8EC File Offset: 0x000E9AEC
    public static void amEffectSetCameraPos( ref AppMain.SNNS_VECTOR pos )
    {
        AppMain.nnCopyVector( AppMain._am_ef_camPos, ref pos );
    }

    // Token: 0x06001A64 RID: 6756 RVA: 0x000EB8F9 File Offset: 0x000E9AF9
    public static void amEffectSetCameraPos( AppMain.NNS_VECTOR pos )
    {
        AppMain.nnCopyVector( AppMain._am_ef_camPos, pos );
    }

    // Token: 0x06001A65 RID: 6757 RVA: 0x000EB906 File Offset: 0x000E9B06
    private void amEffectEnableDraw( int flag )
    {
        AppMain.mppAssertNotImpl();
        AppMain._am_enable_draw = flag;
    }

    // Token: 0x06001A66 RID: 6758 RVA: 0x000EB913 File Offset: 0x000E9B13
    public static void amEffectSetUnitTime( float speed, int frame_rate )
    {
        AppMain._am_unit_frame = speed;
        AppMain._am_unit_time = speed / ( float )frame_rate;
    }

    // Token: 0x06001A67 RID: 6759 RVA: 0x000EB924 File Offset: 0x000E9B24
    public static float amEffectGetUnitFrame()
    {
        return AppMain._am_unit_frame;
    }

    // Token: 0x06001A68 RID: 6760 RVA: 0x000EB92C File Offset: 0x000E9B2C
    private AppMain.AMS_AME_NODE amEffectSearchNode( AppMain.AMS_AME_NODE node, int id )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_AME_NODE ams_AME_NODE = null;
        if ( ( int )node.id == id )
        {
            return node;
        }
        if ( node.child != null )
        {
            ams_AME_NODE = this.amEffectSearchNode( node.child, id );
            if ( ams_AME_NODE != null )
            {
                return ams_AME_NODE;
            }
        }
        if ( node.sibling != null )
        {
            ams_AME_NODE = this.amEffectSearchNode( node.sibling, id );
        }
        return ams_AME_NODE;
    }

    // Token: 0x06001A69 RID: 6761 RVA: 0x000EB97D File Offset: 0x000E9B7D
    private AppMain.AMS_AME_NODE amEffectSearchNode( AppMain.AME_HEADER header, int id )
    {
        return this.amEffectSearchNode( header.node[0], id );
    }

    // Token: 0x06001A6A RID: 6762 RVA: 0x000EB98E File Offset: 0x000E9B8E
    private AppMain.AMS_AME_ECB amEffectCreate( AppMain.AMS_AME_NODE node, int attribute, int priority )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06001A6B RID: 6763 RVA: 0x000EB998 File Offset: 0x000E9B98
    private static AppMain.AMS_AME_ECB _amEffectCreate( AppMain.AMS_AME_HEADER header, int attribute, int priority )
    {
        AppMain.AMS_AME_ECB ams_AME_ECB = AppMain._am_ecb_ref[AppMain._am_ecb_alloc];
        AppMain._am_ecb_alloc++;
        if ( AppMain._am_ecb_alloc >= 128 )
        {
            AppMain._am_ecb_alloc = 0;
        }
        ams_AME_ECB.Clear();
        ams_AME_ECB.attribute = attribute;
        ams_AME_ECB.priority = priority;
        ams_AME_ECB.transparency = 256;
        ams_AME_ECB.size_rate = 1f;
        AppMain.amVectorInit( ams_AME_ECB.translate );
        AppMain.amQuatInit( ref ams_AME_ECB.rotate );
        ams_AME_ECB.bounding.Assign( header.bounding );
        AppMain.AMS_AME_ECB ams_AME_ECB2 = (AppMain.AMS_AME_ECB)AppMain._am_ecb_head.next;
        while ( ams_AME_ECB2 != AppMain._am_ecb_tail && ams_AME_ECB2.priority <= priority )
        {
            ams_AME_ECB2 = ( AppMain.AMS_AME_ECB )ams_AME_ECB2.next;
        }
        ams_AME_ECB2.prev.next = ams_AME_ECB;
        ams_AME_ECB.prev = ams_AME_ECB2.prev;
        ams_AME_ECB2.prev = ams_AME_ECB;
        ams_AME_ECB.next = ams_AME_ECB2;
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = new AppMain.AMS_AME_CREATE_PARAM();
        AppMain.NNS_VECTOR4D amEffectCreate_vec = AppMain._amEffectCreate_vec;
        AppMain.AMS_AME_NODE ams_AME_NODE = header.node[0];
        AppMain.amVectorInit( amEffectCreate_vec );
        while ( ams_AME_NODE != null )
        {
            ams_AME_CREATE_PARAM.ecb = ams_AME_ECB;
            ams_AME_CREATE_PARAM.runtime = null;
            ams_AME_CREATE_PARAM.node = ams_AME_NODE;
            ams_AME_CREATE_PARAM.position = amEffectCreate_vec;
            ams_AME_CREATE_PARAM.velocity = amEffectCreate_vec;
            ams_AME_CREATE_PARAM.parent_position = amEffectCreate_vec;
            ams_AME_CREATE_PARAM.parent_velocity = amEffectCreate_vec;
            int num = AppMain.AMD_AME_SUPER_CLASS_ID(ams_AME_NODE);
            if ( num != 256 )
            {
                if ( num == 512 )
                {
                    AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._amCreateRuntimeParticle(ams_AME_CREATE_PARAM);
                    ams_AME_RUNTIME.state |= 8192;
                }
            }
            else
            {
                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._amCreateRuntimeEmitter(ams_AME_CREATE_PARAM);
                ams_AME_RUNTIME.state |= 8192;
            }
            ams_AME_NODE = ams_AME_NODE.sibling;
        }
        ams_AME_ECB.skip_update = 1;
        return ams_AME_ECB;
    }

    // Token: 0x06001A6C RID: 6764 RVA: 0x000EBB38 File Offset: 0x000E9D38
    private void amEffectDeleteGroup( int attr, int flag )
    {
        AppMain.mppAssertNotImpl();
        uint num = (uint)(attr & -65536);
        uint num2 = (uint)(attr & 65535);
        if ( num == 0U )
        {
            num = 4294901760U;
        }
        switch ( flag )
        {
            case 0:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) != 0L && ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) != 0L )
                    {
                        AppMain.amEffectDelete( ams_AME_ECB );
                    }
                }
                return;
            case 1:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) | ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) ) == ( long )attr )
                    {
                        AppMain.amEffectDelete( ams_AME_ECB );
                    }
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06001A6D RID: 6765 RVA: 0x000EBC04 File Offset: 0x000E9E04
    public static void amEffectKill( AppMain.AMS_AME_ECB ecb )
    {
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            AppMain.AMS_AME_NODE node = runtime.node;
            if ( ( AppMain.AMD_AME_NODE_TYPE( node ) & 65280 ) == 256 && ( runtime.state & 32768 ) == 0 )
            {
                if ( runtime.spawn_runtime != null )
                {
                    runtime.spawn_runtime.state |= 16384;
                }
                runtime.state |= 32768;
                AppMain.AMS_AME_LIST next = runtime.child_head.next;
                AppMain.AMS_AME_LIST child_tail = runtime.child_tail;
                while ( next != child_tail )
                {
                    AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)next;
                    ams_AME_RUNTIME.state |= 16384;
                    next = next.next;
                }
                if ( runtime.parent_runtime != null )
                {
                    AppMain.amEffectDisconnectLink( runtime );
                    AppMain.AMS_AME_RUNTIME parent_runtime = runtime.parent_runtime;
                    parent_runtime.work_num -= 1;
                }
            }
        }
    }

    // Token: 0x06001A6E RID: 6766 RVA: 0x000EBCF4 File Offset: 0x000E9EF4
    private void amEffectKillGroup( int attr, int flag )
    {
        uint num = (uint)(attr & -65536);
        uint num2 = (uint)(attr & 65535);
        if ( num == 0U )
        {
            num = 4294901760U;
        }
        switch ( flag )
        {
            case 0:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) != 0L && ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) != 0L )
                    {
                        AppMain.amEffectKill( ams_AME_ECB );
                    }
                }
                return;
            case 1:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) != 0L && ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) == ( long )( ( ulong )num2 ) )
                    {
                        AppMain.amEffectKill( ams_AME_ECB );
                    }
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06001A6F RID: 6767 RVA: 0x000EBDBC File Offset: 0x000E9FBC
    public static void amEffectUpdate( AppMain.AMS_AME_ECB ecb )
    {
        if ( ecb.entry_num <= 0 )
        {
            return;
        }
        if ( ecb.skip_update != 0 )
        {
            ecb.skip_update = 0;
        }
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            AppMain.AMS_AME_NODE node = runtime.node;
            int num = AppMain.AMD_AME_NODE_TYPE(node);
            if ( ( runtime.state & 16384 ) != 0 && runtime.work_num + runtime.active_num == 0 )
            {
                if ( runtime.spawn_runtime != null )
                {
                    runtime.spawn_runtime.state |= 16384;
                }
                runtime.state |= 32768;
            }
            else
            {
                int num2 = num & 65280;
                if ( num2 != 256 )
                {
                    if ( num2 == 512 )
                    {
                        if ( runtime.work_num != 0 )
                        {
                            AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_head.next;
                            AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK2 = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_tail;
                            while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                            {
                                AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK3 = ams_AME_RUNTIME_WORK;
                                ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                                ams_AME_RUNTIME_WORK3.time += AppMain._am_unit_frame;
                                if ( ams_AME_RUNTIME_WORK3.time > 0f )
                                {
                                    ams_AME_RUNTIME_WORK3.time -= AppMain._am_unit_frame;
                                    AppMain.amEffectDisconnectLink( ams_AME_RUNTIME_WORK3 );
                                    AppMain._amConnectLinkToTail( runtime.active_tail, ams_AME_RUNTIME_WORK3 );
                                    AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = runtime;
                                    ams_AME_RUNTIME.work_num -= 1;
                                    AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = runtime;
                                    ams_AME_RUNTIME2.active_num += 1;
                                }
                            }
                        }
                        AppMain.AmeDelegateFunc ameDelegateFunc = AppMain._am_particle_func[((num & 255) << 2) + 1];
                        ameDelegateFunc( runtime );
                        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK4 = (AppMain.AMS_AME_RUNTIME_WORK)runtime.active_head.next;
                        AppMain.AMS_AME_LIST active_tail = runtime.active_tail;
                        for ( AppMain.AMS_AME_LIST next = runtime.active_head.next; next != active_tail; next = ams_AME_RUNTIME_WORK4.next )
                        {
                            ams_AME_RUNTIME_WORK4 = ( AppMain.AMS_AME_RUNTIME_WORK )next;
                            for ( AppMain.AMS_AME_NODE ams_AME_NODE = node.child; ams_AME_NODE != null; ams_AME_NODE = ams_AME_NODE.sibling )
                            {
                                if ( AppMain.AMD_AME_IS_FIELD( ams_AME_NODE ) )
                                {
                                    AppMain.AmeFieldFunc ameFieldFunc = AppMain._am_field_func[AppMain.AMD_AME_NODE_TYPE(ams_AME_NODE) & 255];
                                    ameFieldFunc( runtime.ecb, ams_AME_NODE, ams_AME_RUNTIME_WORK4 );
                                }
                            }
                        }
                    }
                }
                else if ( runtime.work != null )
                {
                    AppMain.AmeDelegateFunc ameDelegateFunc2 = AppMain._am_emitter_func[((num & 255) << 2) + 1];
                    if ( runtime.work != null )
                    {
                        if ( ameDelegateFunc2( runtime ) != 0 )
                        {
                            runtime.state |= 32768;
                            AppMain.AMS_AME_LIST next2 = runtime.child_head.next;
                            AppMain.AMS_AME_LIST child_tail = runtime.child_tail;
                            while ( next2 != child_tail )
                            {
                                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME3 = (AppMain.AMS_AME_RUNTIME)next2;
                                ams_AME_RUNTIME3.state |= 16384;
                                next2 = next2.next;
                            }
                            if ( runtime.parent_runtime != null )
                            {
                                AppMain.amEffectDisconnectLink( runtime );
                                AppMain.AMS_AME_RUNTIME parent_runtime = runtime.parent_runtime;
                                parent_runtime.work_num -= 1;
                            }
                        }
                        else
                        {
                            for ( AppMain.AMS_AME_NODE ams_AME_NODE2 = node.child; ams_AME_NODE2 != null; ams_AME_NODE2 = ams_AME_NODE2.sibling )
                            {
                                if ( AppMain.AMD_AME_IS_FIELD( ams_AME_NODE2 ) )
                                {
                                    AppMain.AmeFieldFunc ameFieldFunc2 = AppMain._am_field_func[AppMain.AMD_AME_NODE_TYPE(ams_AME_NODE2) & 255];
                                    ameFieldFunc2( runtime.ecb, ams_AME_NODE2, runtime.work );
                                }
                            }
                        }
                    }
                }
            }
        }
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime2 = ams_AME_ENTRY.runtime;
            if ( ( runtime2.state & 32768 ) != 0 )
            {
                AppMain._amFreeRuntime( ams_AME_ENTRY.runtime );
                AppMain._amDelEntry( ecb, ams_AME_ENTRY );
            }
        }
        if ( ecb.entry_num == 0 )
        {
            AppMain.amEffectDelete( ecb );
        }
    }

    // Token: 0x06001A70 RID: 6768 RVA: 0x000EC128 File Offset: 0x000EA328
    private void amEffectUpdateGroup( int attr, int flag )
    {
        uint num = (uint)(attr & -65536);
        uint num2 = (uint)(attr & 65535);
        if ( num == 0U )
        {
            num = 4294901760U;
        }
        switch ( flag )
        {
            case 0:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) != 0L && ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) != 0L )
                    {
                        AppMain.amEffectUpdate( ams_AME_ECB );
                    }
                }
                return;
            case 1:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) | ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) ) == ( long )attr )
                    {
                        AppMain.amEffectUpdate( ams_AME_ECB );
                    }
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06001A71 RID: 6769 RVA: 0x000EC1F0 File Offset: 0x000EA3F0
    public static void amEffectDraw( AppMain.AMS_AME_ECB ecb, AppMain.NNS_TEXLIST texlist, uint state )
    {
        ecb.drawState = state;
        if ( AppMain._am_enable_draw == 0 )
        {
            return;
        }
        if ( ecb.entry_num <= 0 )
        {
            return;
        }
        if ( ecb.bounding.radius > 0f )
        {
            AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
            if ( AppMain._amEffectFrustumCulling( nns_VECTOR4D, AppMain._am_view_frustum, ecb.bounding ) == 0 )
            {
                return;
            }
            AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        }
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            runtime.texlist = texlist;
            int num = AppMain.AMD_AME_SUPER_CLASS_ID(runtime.node);
            if ( num == 512 && runtime.active_num != 0 )
            {
                AppMain.AmeDelegateFunc ameDelegateFunc = AppMain._am_particle_func[(AppMain.AMD_AME_CLASS_ID(runtime.node) << 2) + 2];
                ameDelegateFunc( runtime );
            }
        }
    }

    // Token: 0x06001A72 RID: 6770 RVA: 0x000EC2AC File Offset: 0x000EA4AC
    private void amEffectDrawGroup( AppMain.NNS_TEXLIST texlist, int attr, uint state, int flag )
    {
        if ( AppMain._am_enable_draw == 0 )
        {
            return;
        }
        uint num = (uint)(attr & -65536);
        uint num2 = (uint)(attr & 65535);
        if ( num == 0U )
        {
            num = 4294901760U;
        }
        switch ( flag )
        {
            case 0:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( 0L != ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) && 0L != ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) )
                    {
                        AppMain.amEffectDraw( ams_AME_ECB, texlist, state );
                    }
                }
                return;
            case 1:
                for ( AppMain.AMS_AME_ECB ams_AME_ECB = ( AppMain.AMS_AME_ECB )AppMain._am_ecb_head.next; ams_AME_ECB != AppMain._am_ecb_tail; ams_AME_ECB = ( AppMain.AMS_AME_ECB )ams_AME_ECB.next )
                {
                    if ( ( ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num ) ) | ( ( long )ams_AME_ECB.attribute & ( long )( ( ulong )num2 ) ) ) == ( long )attr )
                    {
                        AppMain.amEffectDraw( ams_AME_ECB, texlist, state );
                    }
                }
                return;
            default:
                return;
        }
    }

    // Token: 0x06001A73 RID: 6771 RVA: 0x000EC380 File Offset: 0x000EA580
    public static void amEffectSetTranslate( AppMain.AMS_AME_ECB ecb, ref AppMain.SNNS_VECTOR4D translate )
    {
        AppMain.amVectorCopy( ecb.translate, ref translate );
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            if ( ( runtime.state & 8192 ) != 0 && ( runtime.node.flag & 67108864U ) == 0U )
            {
                if ( runtime.work != null )
                {
                    AppMain.amVectorAdd( runtime.work.position, ( ( AppMain.AMS_AME_NODE_TR_ROT )runtime.node ).translate, ref translate );
                }
                if ( runtime.work_num + runtime.active_num != 0 )
                {
                    AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_head.next;
                    AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK2 = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_tail;
                    while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                    {
                        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK.position, ( ( AppMain.AMS_AME_NODE_TR_ROT )runtime.node ).translate, ref translate );
                        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                    }
                    ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_head.next;
                    ams_AME_RUNTIME_WORK2 = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_tail;
                    while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                    {
                        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK.position, ( ( AppMain.AMS_AME_NODE_TR_ROT )runtime.node ).translate, ref translate );
                        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                    }
                }
            }
        }
    }

    // Token: 0x06001A74 RID: 6772 RVA: 0x000EC4B8 File Offset: 0x000EA6B8
    public static void amEffectSetTranslate( AppMain.AMS_AME_ECB ecb, AppMain.NNS_VECTOR4D translate )
    {
        AppMain.amVectorCopy( ecb.translate, translate );
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            if ( ( runtime.state & 8192 ) != 0 && ( runtime.node.flag & 67108864U ) == 0U )
            {
                if ( runtime.work != null )
                {
                    AppMain.amVectorAdd( runtime.work.position, ( ( AppMain.AMS_AME_NODE_TR_ROT )runtime.node ).translate, translate );
                }
                if ( runtime.work_num + runtime.active_num != 0 )
                {
                    AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_head.next;
                    AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK2 = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_tail;
                    while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                    {
                        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK.position, ( ( AppMain.AMS_AME_NODE_TR_ROT )runtime.node ).translate, translate );
                        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                    }
                    ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_head.next;
                    ams_AME_RUNTIME_WORK2 = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_tail;
                    while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                    {
                        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK.position, ( ( AppMain.AMS_AME_NODE_TR_ROT )runtime.node ).translate, translate );
                        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                    }
                }
            }
        }
    }

    // Token: 0x06001A75 RID: 6773 RVA: 0x000EC5F0 File Offset: 0x000EA7F0
    private void amEffectTranslate( AppMain.AMS_AME_ECB ecb, AppMain.NNS_VECTOR4D translate )
    {
        AppMain.amVectorAdd( ecb.translate, translate );
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            if ( ( runtime.state & 8192 ) != 0 && ( runtime.node.flag & 67108864U ) == 0U )
            {
                if ( runtime.work != null )
                {
                    AppMain.amVectorAdd( runtime.work.position, translate );
                }
                if ( runtime.work_num + runtime.active_num != 0 )
                {
                    AppMain.AMS_AME_LIST next = runtime.work_head.next;
                    AppMain.AMS_AME_LIST ams_AME_LIST = runtime.work_tail;
                    while ( next != ams_AME_LIST )
                    {
                        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)next;
                        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK.position, translate );
                        next = next.next;
                    }
                    next = runtime.active_head.next;
                    ams_AME_LIST = runtime.active_tail;
                    while ( next != ams_AME_LIST )
                    {
                        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)next;
                        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK.position, translate );
                        next = next.next;
                    }
                }
            }
        }
    }

    // Token: 0x06001A76 RID: 6774 RVA: 0x000EC6E8 File Offset: 0x000EA8E8
    private void amEffectSetRotate( AppMain.AMS_AME_ECB ecb, int x, int y, int z )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION, x, y, z );
        AppMain.amEffectSetRotate( ecb, ref nns_QUATERNION );
    }

    // Token: 0x06001A77 RID: 6775 RVA: 0x000EC710 File Offset: 0x000EA910
    public static void amEffectSetRotate( AppMain.AMS_AME_ECB ecb, ref AppMain.NNS_QUATERNION q )
    {
        AppMain.amEffectSetRotate( ecb, ref q, 0 );
    }

    // Token: 0x06001A78 RID: 6776 RVA: 0x000EC71C File Offset: 0x000EA91C
    public static void amEffectSetRotate( AppMain.AMS_AME_ECB ecb, ref AppMain.NNS_QUATERNION q, int offset )
    {
        ecb.rotate = q;
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            if ( ( runtime.state & 8192 ) != 0 && ( runtime.node.flag & 134217728U ) == 0U )
            {
                if ( runtime.work != null )
                {
                    if ( offset != 0 )
                    {
                        AppMain.amQuatMulti( ref runtime.work.rotate[0], ref ( ( AppMain.AMS_AME_NODE_OMNI )runtime.node ).rotate, ref q );
                    }
                    else
                    {
                        runtime.work.rotate[0] = q;
                    }
                }
                if ( runtime.work_num + runtime.active_num != 0 )
                {
                    AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_head.next;
                    AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK2 = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_tail;
                    while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                    {
                        if ( offset != 0 )
                        {
                            AppMain.amQuatMulti( ref ams_AME_RUNTIME_WORK.rotate[0], ref ( ( AppMain.AMS_AME_NODE_OMNI )runtime.node ).rotate, ref q );
                        }
                        else
                        {
                            ams_AME_RUNTIME_WORK.rotate[0] = q;
                        }
                        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                    }
                    ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_head.next;
                    ams_AME_RUNTIME_WORK2 = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_tail;
                    while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
                    {
                        if ( offset != 0 )
                        {
                            AppMain.amQuatMulti( ref ams_AME_RUNTIME_WORK.rotate[0], ref ( ( AppMain.AMS_AME_NODE_OMNI )runtime.node ).rotate, ref q );
                        }
                        else
                        {
                            ams_AME_RUNTIME_WORK.rotate[0] = q;
                        }
                        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
                    }
                }
            }
        }
    }

    // Token: 0x06001A79 RID: 6777 RVA: 0x000EC8C0 File Offset: 0x000EAAC0
    private void amEffectRotate( AppMain.AMS_AME_ECB ecb, int x, int y, int z )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.amQuatEulerToQuatXYZ( ref nns_QUATERNION, x, y, z );
        this.amEffectRotate( ecb, ref nns_QUATERNION );
    }

    // Token: 0x06001A7A RID: 6778 RVA: 0x000EC8EC File Offset: 0x000EAAEC
    private void amEffectRotate( AppMain.AMS_AME_ECB ecb, ref AppMain.NNS_QUATERNION q )
    {
        AppMain.amQuatMulti( ref ecb.rotate, ref ecb.rotate, ref q );
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            if ( ( runtime.state & 8192 ) != 0 && ( runtime.node.flag & 134217728U ) == 0U )
            {
                if ( runtime.work != null )
                {
                    AppMain.amQuatMulti( ref runtime.work.rotate[0], ref runtime.work.rotate[0], ref q );
                }
                if ( runtime.work_num + runtime.active_num != 0 )
                {
                    AppMain.AMS_AME_LIST next = runtime.work_head.next;
                    AppMain.AMS_AME_LIST ams_AME_LIST = runtime.work_tail;
                    while ( next != ams_AME_LIST )
                    {
                        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)next;
                        if ( runtime.work != null )
                        {
                            AppMain.amQuatMulti( ref ams_AME_RUNTIME_WORK.rotate[0], ref runtime.work.rotate[0], ref q );
                        }
                        next = next.next;
                    }
                    next = runtime.active_head.next;
                    ams_AME_LIST = runtime.active_tail;
                    while ( next != ams_AME_LIST )
                    {
                        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)next;
                        if ( runtime.work != null )
                        {
                            AppMain.amQuatMulti( ref ams_AME_RUNTIME_WORK.rotate[0], ref runtime.work.rotate[0], ref q );
                        }
                        next = next.next;
                    }
                }
            }
        }
    }

    // Token: 0x06001A7B RID: 6779 RVA: 0x000ECA41 File Offset: 0x000EAC41
    private void amEffectCreateParticle( AppMain.AMS_AME_CREATE_PARAM param )
    {
        AppMain._amCreateParticle( param );
    }

    // Token: 0x06001A7C RID: 6780 RVA: 0x000ECA49 File Offset: 0x000EAC49
    public static int _amEffectFrustumCulling( AppMain.NNS_VECTOR4D pPos, AppMain.AMS_FRUSTUM pFrustum, AppMain.AMS_AME_BOUNDING pBounding )
    {
        return 1;
    }

    // Token: 0x06001A7D RID: 6781 RVA: 0x000ECA4C File Offset: 0x000EAC4C
    public static void _amEffectFinalize( AppMain.AMS_AME_ECB ecb )
    {
        for ( AppMain.AMS_AME_ENTRY ams_AME_ENTRY = ecb.entry_head; ams_AME_ENTRY != null; ams_AME_ENTRY = ( AppMain.AMS_AME_ENTRY )ams_AME_ENTRY.next )
        {
            AppMain.AMS_AME_RUNTIME runtime = ams_AME_ENTRY.runtime;
            AppMain.AMS_AME_NODE node = runtime.node;
            if ( AppMain.AMD_AME_SUPER_CLASS_ID( node ) == 256 && runtime.parent_runtime != null )
            {
                AppMain.amEffectDisconnectLink( runtime );
                AppMain.AMS_AME_RUNTIME parent_runtime = runtime.parent_runtime;
                parent_runtime.work_num -= 1;
            }
            AppMain._amFreeRuntime( ams_AME_ENTRY.runtime );
            AppMain._amDelEntry( ecb, ams_AME_ENTRY );
        }
        ecb.prev.next = ecb.next;
        ecb.next.prev = ecb.prev;
        AppMain._am_ecb_ref[AppMain._am_ecb_free] = ecb;
        AppMain._am_ecb_free++;
        if ( AppMain._am_ecb_free >= 128 )
        {
            AppMain._am_ecb_free = 0;
        }
    }

    // Token: 0x06001A7E RID: 6782 RVA: 0x000ECB0C File Offset: 0x000EAD0C
    public static AppMain.AMS_AME_RUNTIME _amCreateRuntimeEmitter( AppMain.AMS_AME_CREATE_PARAM param )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._amAllocRuntime();
        ams_AME_RUNTIME.ecb = param.ecb;
        ams_AME_RUNTIME.node = param.node;
        ams_AME_RUNTIME.child_head.next = ams_AME_RUNTIME.child_tail;
        ams_AME_RUNTIME.child_tail.prev = ams_AME_RUNTIME.child_head;
        ams_AME_RUNTIME.work_head.next = ams_AME_RUNTIME.work_tail;
        ams_AME_RUNTIME.work_tail.prev = ams_AME_RUNTIME.work_head;
        ams_AME_RUNTIME.active_head.next = ams_AME_RUNTIME.active_tail;
        ams_AME_RUNTIME.active_tail.prev = ams_AME_RUNTIME.active_head;
        AppMain._amAddEntry( param.ecb, ams_AME_RUNTIME );
        ams_AME_RUNTIME.work = AppMain._amAllocRuntimeWork();
        param.work = ams_AME_RUNTIME.work;
        AppMain.AmeDelegateFunc ameDelegateFunc = AppMain._am_emitter_func[(AppMain.AMD_AME_NODE_TYPE(param.node) & 255) << 2];
        ameDelegateFunc( param );
        for ( AppMain.AMS_AME_NODE ams_AME_NODE = param.node.child; ams_AME_NODE != null; ams_AME_NODE = ams_AME_NODE.sibling )
        {
            if ( !AppMain.AMD_AME_IS_FIELD( ams_AME_NODE ) )
            {
                AppMain.AMS_AME_RUNTIME list = AppMain._amCreateRuntimeGroup(param.ecb, ams_AME_NODE);
                AppMain._amConnectLinkToTail( ams_AME_RUNTIME.child_tail, list );
                ams_AME_RUNTIME.child_num++;
            }
        }
        return ams_AME_RUNTIME;
    }

    // Token: 0x06001A7F RID: 6783 RVA: 0x000ECC2C File Offset: 0x000EAE2C
    private static AppMain.AMS_AME_RUNTIME _amCreateRuntimeParticle( AppMain.AMS_AME_CREATE_PARAM param )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._amAllocRuntime();
        ams_AME_RUNTIME.ecb = param.ecb;
        ams_AME_RUNTIME.node = param.node;
        ams_AME_RUNTIME.state = 16384;
        ams_AME_RUNTIME.child_head.next = ams_AME_RUNTIME.child_tail;
        ams_AME_RUNTIME.child_tail.prev = ams_AME_RUNTIME.child_head;
        ams_AME_RUNTIME.work_head.next = ams_AME_RUNTIME.work_tail;
        ams_AME_RUNTIME.work_tail.prev = ams_AME_RUNTIME.work_head;
        ams_AME_RUNTIME.active_head.next = ams_AME_RUNTIME.active_tail;
        ams_AME_RUNTIME.active_tail.prev = ams_AME_RUNTIME.active_head;
        for ( AppMain.AMS_AME_NODE ams_AME_NODE = param.node.child; ams_AME_NODE != null; ams_AME_NODE = ams_AME_NODE.sibling )
        {
            if ( AppMain.AMD_AME_IS_PARTICLE( ams_AME_NODE ) )
            {
                ams_AME_RUNTIME.spawn_runtime = AppMain._amCreateRuntimeGroup( param.ecb, ams_AME_NODE );
                break;
            }
        }
        AppMain._amAddEntry( param.ecb, ams_AME_RUNTIME );
        param.runtime = ams_AME_RUNTIME;
        AppMain._amCreateParticle( param );
        return ams_AME_RUNTIME;
    }

    // Token: 0x06001A80 RID: 6784 RVA: 0x000ECD18 File Offset: 0x000EAF18
    public static AppMain.AMS_AME_RUNTIME _amCreateRuntimeGroup( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._amAllocRuntime();
        ams_AME_RUNTIME.ecb = ecb;
        ams_AME_RUNTIME.node = node;
        ams_AME_RUNTIME.child_head.next = ams_AME_RUNTIME.child_tail;
        ams_AME_RUNTIME.child_tail.prev = ams_AME_RUNTIME.child_head;
        ams_AME_RUNTIME.work_head.next = ams_AME_RUNTIME.work_tail;
        ams_AME_RUNTIME.work_tail.prev = ams_AME_RUNTIME.work_head;
        ams_AME_RUNTIME.active_head.next = ams_AME_RUNTIME.active_tail;
        ams_AME_RUNTIME.active_tail.prev = ams_AME_RUNTIME.active_head;
        for ( AppMain.AMS_AME_NODE ams_AME_NODE = node.child; ams_AME_NODE != null; ams_AME_NODE = ams_AME_NODE.sibling )
        {
            if ( AppMain.AMD_AME_IS_PARTICLE( ams_AME_NODE ) )
            {
                ams_AME_RUNTIME.spawn_runtime = AppMain._amCreateRuntimeGroup( ecb, ams_AME_NODE );
                break;
            }
        }
        AppMain._amAddEntry( ecb, ams_AME_RUNTIME );
        return ams_AME_RUNTIME;
    }

    // Token: 0x06001A81 RID: 6785 RVA: 0x000ECDD4 File Offset: 0x000EAFD4
    public static void _amCreateEmitter( AppMain.AMS_AME_CREATE_PARAM param )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._amCreateRuntimeEmitter(param);
        ams_AME_RUNTIME.parent_runtime = param.runtime;
        AppMain._amConnectLinkToTail( ams_AME_RUNTIME.work_tail, ams_AME_RUNTIME );
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = ams_AME_RUNTIME;
        ams_AME_RUNTIME2.work_num += 1;
        param.runtime = ams_AME_RUNTIME;
        param.node = ams_AME_RUNTIME.node;
        param.work = ams_AME_RUNTIME.work;
    }

    // Token: 0x06001A82 RID: 6786 RVA: 0x000ECE30 File Offset: 0x000EB030
    public static void _amCreateParticle( AppMain.AMS_AME_CREATE_PARAM param )
    {
        AppMain.AMS_AME_RUNTIME_WORK_MODEL work = (AppMain.AMS_AME_RUNTIME_WORK_MODEL)AppMain._amAllocRuntimeWork();
        param.work = work;
        AppMain.AmeDelegateFunc ameDelegateFunc = AppMain._am_particle_func[(AppMain.AMD_AME_NODE_TYPE(param.node) & 255) << 2];
        ameDelegateFunc( param );
        if ( work.time < 0f )
        {
            AppMain._amConnectLinkToTail( param.runtime.work_tail, ( AppMain.AMS_AME_LIST )work );
            AppMain.AMS_AME_RUNTIME runtime = param.runtime;
            runtime.work_num += 1;
            return;
        }
        AppMain._amConnectLinkToTail( param.runtime.active_tail, ( AppMain.AMS_AME_LIST )work );
        AppMain.AMS_AME_RUNTIME runtime2 = param.runtime;
        runtime2.active_num += 1;
    }

    // Token: 0x06001A83 RID: 6787 RVA: 0x000ECEDC File Offset: 0x000EB0DC
    public static void _amCreateSpawnParticle( AppMain.AMS_AME_RUNTIME runtime, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorInit( nns_VECTOR4D );
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = AppMain.GlobalPool<AppMain.AMS_AME_CREATE_PARAM>.Alloc();
        ams_AME_CREATE_PARAM.ecb = runtime.ecb;
        ams_AME_CREATE_PARAM.runtime = runtime.spawn_runtime;
        ams_AME_CREATE_PARAM.node = runtime.spawn_runtime.node;
        ams_AME_CREATE_PARAM.position = nns_VECTOR4D;
        ams_AME_CREATE_PARAM.velocity = nns_VECTOR4D;
        ams_AME_CREATE_PARAM.parent_position = work.position;
        ams_AME_CREATE_PARAM.parent_velocity = work.velocity;
        if ( ( runtime.state & 8192 ) != 0 )
        {
            runtime.spawn_runtime.state |= 8192;
        }
        AppMain._amCreateParticle( ams_AME_CREATE_PARAM );
        if ( AppMain.AMD_AME_NODE_TYPE( runtime.node ) == AppMain.AMD_AME_NODE_TYPE( ams_AME_CREATE_PARAM.node ) )
        {
            AppMain.AMS_AME_NODE node = runtime.node;
            AppMain.AMS_AME_NODE node2 = ams_AME_CREATE_PARAM.node;
            switch ( AppMain.AMD_AME_NODE_TYPE( ams_AME_CREATE_PARAM.node ) )
            {
                case 512:
                    {
                        AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE ams_AME_RUNTIME_WORK_SIMPLE_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE)work;
                        AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2 = (AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE)ams_AME_CREATE_PARAM.work;
                        if ( ( node.flag & node2.flag & 131072U ) != 0U && ( ( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.flag ^ ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.flag ) & 8U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.flag ^= 8U;
                            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.set_st( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.z, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.y, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.x, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.w );
                        }
                        if ( ( node.flag & node2.flag & 262144U ) != 0U && ( ( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.flag ^ ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.flag ) & 16U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.flag ^= 16U;
                            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.set_st( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.x, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.w, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.z, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE2.st.y );
                        }
                        break;
                    }
                case 513:
                    {
                        AppMain.AMS_AME_RUNTIME_WORK_SPRITE ams_AME_RUNTIME_WORK_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SPRITE)work;
                        AppMain.AMS_AME_RUNTIME_WORK_SPRITE ams_AME_RUNTIME_WORK_SPRITE2 = (AppMain.AMS_AME_RUNTIME_WORK_SPRITE)ams_AME_CREATE_PARAM.work;
                        if ( ( node.flag & node2.flag & 4U ) != 0U )
                        {
                            if ( ( ams_AME_RUNTIME_WORK_SPRITE.flag & 4U ) != 0U )
                            {
                                ams_AME_RUNTIME_WORK_SPRITE2.flag |= 4U;
                            }
                            else
                            {
                                ams_AME_RUNTIME_WORK_SPRITE2.flag &= 4294967291U;
                            }
                        }
                        if ( ( node.flag & node2.flag & 131072U ) != 0U && ( ( ams_AME_RUNTIME_WORK_SPRITE.flag ^ ams_AME_RUNTIME_WORK_SPRITE2.flag ) & 8U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_SPRITE2.flag ^= 8U;
                            ams_AME_RUNTIME_WORK_SPRITE2.set_st( ams_AME_RUNTIME_WORK_SPRITE2.st.z, ams_AME_RUNTIME_WORK_SPRITE2.st.y, ams_AME_RUNTIME_WORK_SPRITE2.st.x, ams_AME_RUNTIME_WORK_SPRITE2.st.w );
                        }
                        if ( ( node.flag & node2.flag & 262144U ) != 0U && ( ( ams_AME_RUNTIME_WORK_SPRITE.flag ^ ams_AME_RUNTIME_WORK_SPRITE2.flag ) & 16U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_SPRITE2.flag ^= 16U;
                            ams_AME_RUNTIME_WORK_SPRITE2.set_st( ams_AME_RUNTIME_WORK_SPRITE2.st.x, ams_AME_RUNTIME_WORK_SPRITE2.st.w, ams_AME_RUNTIME_WORK_SPRITE2.st.z, ams_AME_RUNTIME_WORK_SPRITE2.st.y );
                        }
                        break;
                    }
                case 514:
                    {
                        AppMain.AMS_AME_RUNTIME_WORK_LINE ams_AME_RUNTIME_WORK_LINE = (AppMain.AMS_AME_RUNTIME_WORK_LINE)work;
                        AppMain.AMS_AME_RUNTIME_WORK_LINE ams_AME_RUNTIME_WORK_LINE2 = (AppMain.AMS_AME_RUNTIME_WORK_LINE)ams_AME_CREATE_PARAM.work;
                        if ( ( node.flag & node2.flag & 131072U ) != 0U && ( ( ams_AME_RUNTIME_WORK_LINE.flag ^ ams_AME_RUNTIME_WORK_LINE2.flag ) & 8U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_LINE2.flag ^= 8U;
                            ams_AME_RUNTIME_WORK_LINE2.set_st( ams_AME_RUNTIME_WORK_LINE2.st.z, ams_AME_RUNTIME_WORK_LINE2.st.y, ams_AME_RUNTIME_WORK_LINE2.st.x, ams_AME_RUNTIME_WORK_LINE2.st.w );
                        }
                        if ( ( node.flag & node2.flag & 262144U ) != 0U && ( ( ams_AME_RUNTIME_WORK_LINE.flag ^ ams_AME_RUNTIME_WORK_LINE2.flag ) & 16U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_LINE2.flag ^= 16U;
                            ams_AME_RUNTIME_WORK_LINE2.set_st( ams_AME_RUNTIME_WORK_LINE2.st.x, ams_AME_RUNTIME_WORK_LINE2.st.w, ams_AME_RUNTIME_WORK_LINE2.st.z, ams_AME_RUNTIME_WORK_LINE2.st.y );
                        }
                        break;
                    }
                case 515:
                    {
                        AppMain.AMS_AME_RUNTIME_WORK_PLANE ams_AME_RUNTIME_WORK_PLANE = (AppMain.AMS_AME_RUNTIME_WORK_PLANE)work;
                        AppMain.AMS_AME_RUNTIME_WORK_PLANE ams_AME_RUNTIME_WORK_PLANE2 = (AppMain.AMS_AME_RUNTIME_WORK_PLANE)ams_AME_CREATE_PARAM.work;
                        if ( ( node.flag & node2.flag & 131072U ) != 0U && ( ( ams_AME_RUNTIME_WORK_PLANE.flag ^ ams_AME_RUNTIME_WORK_PLANE2.flag ) & 8U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_PLANE2.flag ^= 8U;
                            ams_AME_RUNTIME_WORK_PLANE2.set_st( ams_AME_RUNTIME_WORK_PLANE2.st.z, ams_AME_RUNTIME_WORK_PLANE2.st.y, ams_AME_RUNTIME_WORK_PLANE2.st.x, ams_AME_RUNTIME_WORK_PLANE2.st.w );
                        }
                        if ( ( node.flag & node2.flag & 262144U ) != 0U && ( ( ams_AME_RUNTIME_WORK_PLANE.flag ^ ams_AME_RUNTIME_WORK_PLANE2.flag ) & 16U ) != 0U )
                        {
                            ams_AME_RUNTIME_WORK_PLANE2.flag ^= 16U;
                            ams_AME_RUNTIME_WORK_PLANE2.set_st( ams_AME_RUNTIME_WORK_PLANE2.st.x, ams_AME_RUNTIME_WORK_PLANE2.st.w, ams_AME_RUNTIME_WORK_PLANE2.st.z, ams_AME_RUNTIME_WORK_PLANE2.st.y );
                        }
                        break;
                    }
            }
        }
        AppMain.GlobalPool<AppMain.AMS_AME_CREATE_PARAM>.Release( ams_AME_CREATE_PARAM );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
    }

    // Token: 0x06001A84 RID: 6788 RVA: 0x000ED484 File Offset: 0x000EB684
    public static AppMain.AMS_AME_RUNTIME _amAllocRuntime()
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = AppMain._am_runtime_ref[AppMain._am_runtime_alloc];
        AppMain._am_runtime_alloc++;
        if ( AppMain._am_runtime_alloc >= 512 )
        {
            AppMain._am_runtime_alloc = 0;
        }
        ams_AME_RUNTIME.Clear();
        return ams_AME_RUNTIME;
    }

    // Token: 0x06001A85 RID: 6789 RVA: 0x000ED4C4 File Offset: 0x000EB6C4
    public static void _amFreeRuntime( AppMain.AMS_AME_RUNTIME runtime )
    {
        if ( runtime.work != null )
        {
            AppMain.AMS_AME_RUNTIME_WORK work = runtime.work;
            AppMain.amEffectFreeRuntimeWork( work );
        }
        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_head.next;
        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK2 = (AppMain.AMS_AME_RUNTIME_WORK)runtime.work_tail;
        while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
        {
            AppMain.amEffectFreeRuntimeWork( ams_AME_RUNTIME_WORK );
            ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
        }
        ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_head.next;
        ams_AME_RUNTIME_WORK2 = ( AppMain.AMS_AME_RUNTIME_WORK )runtime.active_tail;
        while ( ams_AME_RUNTIME_WORK != ams_AME_RUNTIME_WORK2 )
        {
            AppMain.amEffectFreeRuntimeWork( ams_AME_RUNTIME_WORK );
            ams_AME_RUNTIME_WORK = ( AppMain.AMS_AME_RUNTIME_WORK )ams_AME_RUNTIME_WORK.next;
        }
        AppMain._am_runtime_ref[AppMain._am_runtime_free] = runtime;
        AppMain._am_runtime_free++;
        if ( AppMain._am_runtime_free >= 512 )
        {
            AppMain._am_runtime_free = 0;
        }
    }

    // Token: 0x06001A86 RID: 6790 RVA: 0x000ED57C File Offset: 0x000EB77C
    public static AppMain.AMS_AME_RUNTIME_WORK _amAllocRuntimeWork()
    {
        AppMain.AMS_AME_RUNTIME_WORK ams_AME_RUNTIME_WORK = AppMain._am_work_ref[AppMain._am_work_alloc];
        AppMain._am_work_alloc++;
        if ( AppMain._am_work_alloc >= 1024 )
        {
            AppMain._am_work_alloc = 0;
        }
        ams_AME_RUNTIME_WORK.Clear();
        return ams_AME_RUNTIME_WORK;
    }

    // Token: 0x06001A87 RID: 6791 RVA: 0x000ED5BA File Offset: 0x000EB7BA
    public static void amEffectFreeRuntimeWork( AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain._am_work_ref[AppMain._am_work_free] = work;
        AppMain._am_work_free++;
        if ( AppMain._am_work_free >= 1024 )
        {
            AppMain._am_work_free = 0;
        }
    }

    // Token: 0x06001A88 RID: 6792 RVA: 0x000ED5E8 File Offset: 0x000EB7E8
    public static void _amAddEntry( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_RUNTIME runtime )
    {
        AppMain.AMS_AME_ENTRY ams_AME_ENTRY = AppMain._am_entry_ref[AppMain._am_entry_alloc];
        AppMain._am_entry_alloc++;
        if ( AppMain._am_entry_alloc >= 512 )
        {
            AppMain._am_entry_alloc = 0;
        }
        ams_AME_ENTRY.runtime = runtime;
        if ( ecb.entry_head == null )
        {
            ecb.entry_head = ams_AME_ENTRY;
            ams_AME_ENTRY.prev = null;
        }
        if ( ecb.entry_tail != null )
        {
            ams_AME_ENTRY.prev = ecb.entry_tail;
            ecb.entry_tail.next = ams_AME_ENTRY;
        }
        ecb.entry_tail = ams_AME_ENTRY;
        ams_AME_ENTRY.next = null;
        ecb.entry_num++;
    }

    // Token: 0x06001A89 RID: 6793 RVA: 0x000ED678 File Offset: 0x000EB878
    public static void _amDelEntry( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_ENTRY entry )
    {
        if ( entry.prev == null )
        {
            ecb.entry_head = ( AppMain.AMS_AME_ENTRY )entry.next;
        }
        else
        {
            entry.prev.next = entry.next;
        }
        if ( entry.next == null )
        {
            ecb.entry_tail = ( AppMain.AMS_AME_ENTRY )entry.prev;
        }
        else
        {
            entry.next.prev = entry.prev;
        }
        AppMain._am_entry_ref[AppMain._am_entry_free] = entry;
        AppMain._am_entry_free++;
        if ( AppMain._am_entry_free >= 512 )
        {
            AppMain._am_entry_free = 0;
        }
        ecb.entry_num--;
    }

    // Token: 0x06001A8A RID: 6794 RVA: 0x000ED718 File Offset: 0x000EB918
    private static int _amEffectSetDrawMode( AppMain.AMS_AME_RUNTIME runtime, AppMain.AMS_PARAM_DRAW_PRIMITIVE param, int NodeBlend )
    {
        AppMain.AMS_AME_NODE node = runtime.node;
        int num = 0;
        param.ablend = num;
        if ( ( node.flag & 2U ) != 0U )
        {
            param.aTest = 1;
        }
        else
        {
            param.aTest = 0;
        }
        if ( ( node.flag & 33554432U ) != 0U )
        {
            param.zMask = 1;
        }
        else
        {
            param.zMask = 0;
        }
        if ( ( node.flag & 16777216U ) == 0U )
        {
            param.zTest = 0;
        }
        else
        {
            param.zTest = 1;
        }
        if ( ( node.flag & 1U ) != 0U )
        {
            num = 1;
            param.ablend = num;
            if ( NodeBlend != 50 )
            {
                if ( NodeBlend != 162 )
                {
                    if ( NodeBlend == 674 )
                    {
                        param.bldSrc = 770;
                        param.bldDst = 1;
                        param.bldMode = 32779;
                    }
                }
                else
                {
                    param.bldSrc = 770;
                    param.bldDst = 1;
                    param.bldMode = 32774;
                }
            }
            else
            {
                param.bldSrc = 770;
                param.bldDst = 771;
                param.bldMode = 32774;
            }
        }
        return num;
    }

    // Token: 0x06001A8B RID: 6795 RVA: 0x000ED81C File Offset: 0x000EBA1C
    private static uint _amEffectSetMaterial( AppMain.AMS_AME_RUNTIME runtime, ref int blend, int NodeBlend )
    {
        AppMain.AMS_AME_NODE node = runtime.node;
        uint num = 0U;
        if ( ( node.flag & 1U ) != 0U )
        {
            num |= 8389632U;
            if ( NodeBlend != 50 )
            {
                if ( NodeBlend != 162 )
                {
                    if ( NodeBlend == 674 )
                    {
                        blend = 2;
                    }
                }
                else
                {
                    blend = 1;
                }
            }
            else
            {
                blend = 0;
            }
        }
        return num;
    }

    // Token: 0x06001A8C RID: 6796 RVA: 0x000ED86C File Offset: 0x000EBA6C
    private static int _amInitOmni( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_OMNI ams_AME_NODE_OMNI = (AppMain.AMS_AME_NODE_OMNI)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_OMNI ams_AME_RUNTIME_WORK_OMNI = (AppMain.AMS_AME_RUNTIME_WORK_OMNI)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_OMNI.time = -ams_AME_NODE_OMNI.start_time;
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_OMNI.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_OMNI.position, ams_AME_NODE_OMNI.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_OMNI.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_OMNI.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_OMNI.velocity, ams_AME_CREATE_PARAM.velocity );
        ams_AME_RUNTIME_WORK_OMNI.rotate = ams_AME_NODE_OMNI.rotate;
        float size_rate = ams_AME_CREATE_PARAM.ecb.size_rate;
        ams_AME_RUNTIME_WORK_OMNI.offset = ams_AME_NODE_OMNI.offset * size_rate;
        ams_AME_RUNTIME_WORK_OMNI.offset_chaos = ams_AME_NODE_OMNI.offset_chaos * size_rate;
        return 0;
    }

    // Token: 0x06001A8D RID: 6797 RVA: 0x000ED934 File Offset: 0x000EBB34
    private static int _amUpdateOmni( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_OMNI ams_AME_NODE_OMNI = (AppMain.AMS_AME_NODE_OMNI)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_RUNTIME_WORK_OMNI ams_AME_RUNTIME_WORK_OMNI = (AppMain.AMS_AME_RUNTIME_WORK_OMNI)ams_AME_RUNTIME.work;
        ams_AME_RUNTIME_WORK_OMNI.time += AppMain._am_unit_frame;
        if ( ams_AME_RUNTIME_WORK_OMNI.time <= 0f )
        {
            return 0;
        }
        if ( ams_AME_NODE_OMNI.life != -1f && ams_AME_RUNTIME_WORK_OMNI.time >= ams_AME_NODE_OMNI.life )
        {
            return 1;
        }
        AppMain.NNS_VECTOR4D amEffect_vel = AppMain._amEffect_vel;
        AppMain.amVectorScale( amEffect_vel, ams_AME_RUNTIME_WORK_OMNI.velocity, AppMain._am_unit_time );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_OMNI.position, amEffect_vel );
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        ams_AME_RUNTIME_WORK_OMNI.offset = ams_AME_NODE_OMNI.offset * size_rate;
        ams_AME_RUNTIME_WORK_OMNI.offset_chaos = ams_AME_NODE_OMNI.offset_chaos * size_rate;
        AppMain.NNS_VECTOR4D amEffect_position = AppMain._amEffect_position;
        AppMain.NNS_VECTOR4D amEffect_velocity = AppMain._amEffect_velocity;
        AppMain.NNS_VECTOR4D amEffect_direction = AppMain._amEffect_direction;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.child_head.next;
        AppMain.AMS_AME_LIST child_tail = ams_AME_RUNTIME.child_tail;
        while ( next != child_tail )
        {
            AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = (AppMain.AMS_AME_RUNTIME)next;
            ams_AME_RUNTIME2.amount += ams_AME_NODE_OMNI.frequency * AppMain._am_unit_frame;
            while ( ams_AME_RUNTIME2.amount >= 1f )
            {
                ams_AME_RUNTIME2.amount -= 1f;
                ams_AME_RUNTIME2.count += 1U;
                if ( ams_AME_NODE_OMNI.max_count != -1f && ( float )( ams_AME_RUNTIME2.work_num + ams_AME_RUNTIME2.active_num ) < ams_AME_NODE_OMNI.max_count )
                {
                    AppMain.AMS_AME_CREATE_PARAM amEffect_create_param = AppMain._amEffect_create_param;
                    amEffect_create_param.Clear();
                    AppMain.amVectorRandom( amEffect_direction );
                    AppMain.amVectorScale( amEffect_velocity, amEffect_direction, ams_AME_RUNTIME_WORK_OMNI.offset + ams_AME_RUNTIME_WORK_OMNI.offset_chaos * AppMain.nnRandom() );
                    amEffect_position.Assign( amEffect_velocity );
                    AppMain.amVectorScale( amEffect_velocity, amEffect_direction, ams_AME_NODE_OMNI.speed + ams_AME_NODE_OMNI.speed_chaos * AppMain.nnRandom() );
                    amEffect_create_param.ecb = ams_AME_RUNTIME.ecb;
                    amEffect_create_param.runtime = ams_AME_RUNTIME2;
                    amEffect_create_param.node = ams_AME_RUNTIME2.node;
                    amEffect_create_param.parent_position = ams_AME_RUNTIME_WORK_OMNI.position;
                    amEffect_create_param.parent_velocity = ams_AME_RUNTIME_WORK_OMNI.velocity;
                    amEffect_create_param.position = amEffect_position;
                    amEffect_create_param.velocity = amEffect_velocity;
                    int num = AppMain.AMD_AME_SUPER_CLASS_ID(ams_AME_RUNTIME2.node);
                    if ( num != 256 )
                    {
                        if ( num == 512 )
                        {
                            AppMain._amCreateParticle( amEffect_create_param );
                        }
                    }
                    else
                    {
                        AppMain._amCreateEmitter( amEffect_create_param );
                    }
                }
            }
            next = next.next;
        }
        return 0;
    }

    // Token: 0x06001A8E RID: 6798 RVA: 0x000EDB95 File Offset: 0x000EBD95
    private static int _amDrawOmni( object r )
    {
        return 0;
    }

    // Token: 0x06001A8F RID: 6799 RVA: 0x000EDB98 File Offset: 0x000EBD98
    private static int _amInitDirectional( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_DIRECTIONAL ams_AME_NODE_DIRECTIONAL = (AppMain.AMS_AME_NODE_DIRECTIONAL)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL ams_AME_RUNTIME_WORK_DIRECTIONAL = (AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_DIRECTIONAL.time = -ams_AME_NODE_DIRECTIONAL.start_time;
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_DIRECTIONAL.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_DIRECTIONAL.position, ams_AME_NODE_DIRECTIONAL.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_DIRECTIONAL.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_DIRECTIONAL.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_DIRECTIONAL.velocity, ams_AME_CREATE_PARAM.velocity );
        ams_AME_RUNTIME_WORK_DIRECTIONAL.rotate = ams_AME_NODE_DIRECTIONAL.rotate;
        ams_AME_RUNTIME_WORK_DIRECTIONAL.spread = ams_AME_NODE_DIRECTIONAL.spread;
        return 0;
    }

    // Token: 0x06001A90 RID: 6800 RVA: 0x000EDC44 File Offset: 0x000EBE44
    private static int _amUpdateDirectional( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_DIRECTIONAL ams_AME_NODE_DIRECTIONAL = (AppMain.AMS_AME_NODE_DIRECTIONAL)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL ams_AME_RUNTIME_WORK_DIRECTIONAL = new AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL(ams_AME_RUNTIME.work);
        ams_AME_RUNTIME_WORK_DIRECTIONAL.time += AppMain._am_unit_frame;
        if ( ams_AME_RUNTIME_WORK_DIRECTIONAL.time <= 0f )
        {
            return 0;
        }
        if ( ams_AME_NODE_DIRECTIONAL.life != -1f && ams_AME_RUNTIME_WORK_DIRECTIONAL.time >= ams_AME_NODE_DIRECTIONAL.life )
        {
            return 1;
        }
        AppMain.NNS_VECTOR4D amEffect_vel = AppMain._amEffect_vel;
        AppMain.amVectorScale( amEffect_vel, ams_AME_RUNTIME_WORK_DIRECTIONAL.velocity, AppMain._am_unit_time );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_DIRECTIONAL.position, amEffect_vel );
        ams_AME_RUNTIME_WORK_DIRECTIONAL.spread += ams_AME_NODE_DIRECTIONAL.spread_variation * AppMain._am_unit_time;
        AppMain.NNS_MATRIX amEffect_mtx = AppMain._amEffect_mtx;
        AppMain.nnMakeUnitMatrix( amEffect_mtx );
        AppMain.amMatrixPush( amEffect_mtx );
        AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_DIRECTIONAL.rotate;
        AppMain.amQuatToMatrix( null, ref rotate, null );
        ams_AME_RUNTIME_WORK_DIRECTIONAL.rotate = rotate;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.child_head.next;
        AppMain.AMS_AME_LIST child_tail = ams_AME_RUNTIME.child_tail;
        AppMain.NNS_VECTOR4D amEffect_position = AppMain._amEffect_position;
        AppMain.NNS_VECTOR4D amEffect_velocity = AppMain._amEffect_velocity;
        AppMain.NNS_VECTOR4D amEffect_direction = AppMain._amEffect_direction;
        while ( next != child_tail )
        {
            AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = (AppMain.AMS_AME_RUNTIME)next;
            ams_AME_RUNTIME2.amount += ams_AME_NODE_DIRECTIONAL.frequency * AppMain._am_unit_frame;
            while ( ams_AME_RUNTIME2.amount >= 1f )
            {
                ams_AME_RUNTIME2.amount -= 1f;
                ams_AME_RUNTIME2.count += 1U;
                if ( ams_AME_NODE_DIRECTIONAL.max_count != -1f && ( float )( ams_AME_RUNTIME2.work_num + ams_AME_RUNTIME2.active_num ) < ams_AME_NODE_DIRECTIONAL.max_count )
                {
                    AppMain.AMS_AME_CREATE_PARAM amEffect_create_param = AppMain._amEffect_create_param;
                    amEffect_create_param.Clear();
                    AppMain.amEffectRandomConeVectorDeg( amEffect_direction, ams_AME_RUNTIME_WORK_DIRECTIONAL.spread );
                    AppMain.amMatrixCalcPoint( amEffect_direction, amEffect_direction );
                    AppMain.amVectorScale( amEffect_velocity, amEffect_direction, ams_AME_NODE_DIRECTIONAL.offset + ams_AME_NODE_DIRECTIONAL.offset_chaos * AppMain.nnRandom() );
                    amEffect_position.Assign( amEffect_velocity );
                    AppMain.amVectorScale( amEffect_velocity, amEffect_direction, ams_AME_NODE_DIRECTIONAL.speed + ams_AME_NODE_DIRECTIONAL.speed_chaos * AppMain.nnRandom() );
                    amEffect_create_param.ecb = ams_AME_RUNTIME.ecb;
                    amEffect_create_param.runtime = ams_AME_RUNTIME2;
                    amEffect_create_param.node = ams_AME_RUNTIME2.node;
                    amEffect_create_param.parent_position = ams_AME_RUNTIME_WORK_DIRECTIONAL.position;
                    amEffect_create_param.parent_velocity = ams_AME_RUNTIME_WORK_DIRECTIONAL.velocity;
                    amEffect_create_param.position = amEffect_position;
                    amEffect_create_param.velocity = amEffect_velocity;
                    int num = AppMain.AMD_AME_SUPER_CLASS_ID(ams_AME_RUNTIME2.node);
                    if ( num != 256 )
                    {
                        if ( num == 512 )
                        {
                            AppMain._amCreateParticle( amEffect_create_param );
                        }
                    }
                    else
                    {
                        AppMain._amCreateEmitter( amEffect_create_param );
                    }
                }
            }
            next = next.next;
        }
        AppMain.amMatrixPop();
        return 0;
    }

    // Token: 0x06001A91 RID: 6801 RVA: 0x000EDED6 File Offset: 0x000EC0D6
    private static int _amDrawDirectional( object r )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        return 0;
    }

    // Token: 0x06001A92 RID: 6802 RVA: 0x000EDEE8 File Offset: 0x000EC0E8
    private static int _amInitSurface( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_SURFACE ams_AME_NODE_SURFACE = (AppMain.AMS_AME_NODE_SURFACE)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_SURFACE ams_AME_RUNTIME_WORK_SURFACE = (AppMain.AMS_AME_RUNTIME_WORK_SURFACE)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_SURFACE.time = -ams_AME_NODE_SURFACE.start_time;
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SURFACE.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SURFACE.position, ams_AME_NODE_SURFACE.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_SURFACE.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_SURFACE.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SURFACE.velocity, ams_AME_CREATE_PARAM.velocity );
        ams_AME_RUNTIME_WORK_SURFACE.rotate = ams_AME_NODE_SURFACE.rotate;
        float size_rate = ams_AME_CREATE_PARAM.ecb.size_rate;
        ams_AME_RUNTIME_WORK_SURFACE.width = ams_AME_NODE_SURFACE.width * size_rate;
        ams_AME_RUNTIME_WORK_SURFACE.height = ams_AME_NODE_SURFACE.height * size_rate;
        ams_AME_RUNTIME_WORK_SURFACE.offset = ams_AME_NODE_SURFACE.offset * size_rate;
        ams_AME_RUNTIME_WORK_SURFACE.offset_chaos = ams_AME_NODE_SURFACE.offset_chaos * size_rate;
        return 0;
    }

    // Token: 0x06001A93 RID: 6803 RVA: 0x000EDFCC File Offset: 0x000EC1CC
    private static int _amUpdateSurface( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_SURFACE ams_AME_NODE_SURFACE = (AppMain.AMS_AME_NODE_SURFACE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_RUNTIME_WORK_SURFACE ams_AME_RUNTIME_WORK_SURFACE = (AppMain.AMS_AME_RUNTIME_WORK_SURFACE)ams_AME_RUNTIME.work;
        ams_AME_RUNTIME_WORK_SURFACE.time += AppMain._am_unit_frame;
        if ( ams_AME_RUNTIME_WORK_SURFACE.time <= 0f )
        {
            return 0;
        }
        if ( ams_AME_NODE_SURFACE.life != -1f && ams_AME_RUNTIME_WORK_SURFACE.time >= ams_AME_NODE_SURFACE.life )
        {
            return 1;
        }
        AppMain.NNS_VECTOR4D amEffect_vel = AppMain._amEffect_vel;
        AppMain.amVectorScale( amEffect_vel, ams_AME_RUNTIME_WORK_SURFACE.velocity, AppMain._am_unit_time );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SURFACE.position, amEffect_vel );
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        if ( ams_AME_NODE_SURFACE.width_variation != 0f || ams_AME_NODE_SURFACE.height_variation != 0f )
        {
            ams_AME_RUNTIME_WORK_SURFACE.width += ams_AME_NODE_SURFACE.width_variation * AppMain._am_unit_time;
            ams_AME_RUNTIME_WORK_SURFACE.height += ams_AME_NODE_SURFACE.height_variation * AppMain._am_unit_time;
        }
        else
        {
            ams_AME_RUNTIME_WORK_SURFACE.width = ams_AME_NODE_SURFACE.width * size_rate;
            ams_AME_RUNTIME_WORK_SURFACE.height = ams_AME_NODE_SURFACE.height * size_rate;
        }
        ams_AME_RUNTIME_WORK_SURFACE.offset = ams_AME_NODE_SURFACE.offset * size_rate;
        ams_AME_RUNTIME_WORK_SURFACE.offset_chaos = ams_AME_NODE_SURFACE.offset_chaos * size_rate;
        AppMain.NNS_MATRIX amEffect_mtx = AppMain._amEffect_mtx;
        AppMain.nnMakeUnitMatrix( amEffect_mtx );
        AppMain.amMatrixPush( amEffect_mtx );
        AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_SURFACE.rotate;
        AppMain.amQuatToMatrix( null, ref rotate, null );
        ams_AME_RUNTIME_WORK_SURFACE.rotate = rotate;
        AppMain.NNS_VECTOR4D amEffect_position = AppMain._amEffect_position;
        AppMain.NNS_VECTOR4D amEffect_velocity = AppMain._amEffect_velocity;
        AppMain.NNS_VECTOR4D amEffect_direction = AppMain._amEffect_direction;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.child_head.next;
        AppMain.AMS_AME_LIST child_tail = ams_AME_RUNTIME.child_tail;
        while ( next != child_tail )
        {
            AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = (AppMain.AMS_AME_RUNTIME)next;
            ams_AME_RUNTIME2.amount += ams_AME_NODE_SURFACE.frequency * AppMain._am_unit_frame;
            while ( ams_AME_RUNTIME2.amount >= 1f )
            {
                ams_AME_RUNTIME2.amount -= 1f;
                ams_AME_RUNTIME2.count += 1U;
                if ( ams_AME_NODE_SURFACE.max_count != -1f && ( float )( ams_AME_RUNTIME2.work_num + ams_AME_RUNTIME2.active_num ) < ams_AME_NODE_SURFACE.max_count )
                {
                    AppMain.AMS_AME_CREATE_PARAM amEffect_create_param = AppMain._amEffect_create_param;
                    AppMain.amVectorSet( amEffect_direction, 0f, 1f, 0f );
                    float num = AppMain.nnRandom() / 2f + AppMain.nnRandom() * 0.5f;
                    float num2 = ams_AME_RUNTIME_WORK_SURFACE.width * num - ams_AME_RUNTIME_WORK_SURFACE.width * 0.5f;
                    num = AppMain.nnRandom() / 2f + AppMain.nnRandom() * 0.5f;
                    float num3 = ams_AME_RUNTIME_WORK_SURFACE.height * num - ams_AME_RUNTIME_WORK_SURFACE.height * 0.5f;
                    if ( ( ams_AME_NODE_SURFACE.flag & 1U ) != 0U )
                    {
                        float num4 = AppMain.nnRandom();
                        bool flag = false;
                        if ( AppMain.nnRandom() > 0.5f )
                        {
                            flag = true;
                        }
                        if ( num4 > 0.5f )
                        {
                            num2 = ams_AME_RUNTIME_WORK_SURFACE.width * 0.5f;
                            num2 = ( ( num2 > 0f && flag ) ? ( -num2 ) : num2 );
                        }
                        else
                        {
                            num3 = ams_AME_RUNTIME_WORK_SURFACE.height * 0.5f;
                            num3 = ( ( num3 > 0f && flag ) ? ( -num3 ) : num3 );
                        }
                    }
                    AppMain.amVectorSet( amEffect_position, num2, 0f, num3 );
                    AppMain.amMatrixCalcPoint( amEffect_position, amEffect_position );
                    AppMain.amMatrixCalcPoint( amEffect_direction, amEffect_direction );
                    AppMain.amVectorScale( amEffect_velocity, amEffect_direction, ams_AME_RUNTIME_WORK_SURFACE.offset + ams_AME_RUNTIME_WORK_SURFACE.offset_chaos * AppMain.nnRandom() );
                    AppMain.amVectorAdd( amEffect_position, amEffect_velocity );
                    AppMain.amVectorScale( amEffect_velocity, amEffect_direction, ams_AME_NODE_SURFACE.speed + ams_AME_NODE_SURFACE.speed_chaos * AppMain.nnRandom() );
                    amEffect_create_param.ecb = ams_AME_RUNTIME.ecb;
                    amEffect_create_param.runtime = ams_AME_RUNTIME2;
                    amEffect_create_param.node = ams_AME_RUNTIME2.node;
                    amEffect_create_param.parent_position = ams_AME_RUNTIME_WORK_SURFACE.position;
                    amEffect_create_param.parent_velocity = ams_AME_RUNTIME_WORK_SURFACE.velocity;
                    amEffect_create_param.position = amEffect_position;
                    amEffect_create_param.velocity = amEffect_velocity;
                    int num5 = AppMain.AMD_AME_NODE_TYPE(ams_AME_RUNTIME2.node) & 65280;
                    if ( num5 != 256 )
                    {
                        if ( num5 == 512 )
                        {
                            AppMain._amCreateParticle( amEffect_create_param );
                        }
                    }
                    else
                    {
                        AppMain._amCreateEmitter( amEffect_create_param );
                    }
                }
            }
            next = next.next;
        }
        AppMain.amMatrixPop();
        return 0;
    }

    // Token: 0x06001A94 RID: 6804 RVA: 0x000EE3E0 File Offset: 0x000EC5E0
    private static int _amDrawSurface( object r )
    {
        AppMain.mppAssertNotImpl();
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        return 0;
    }

    // Token: 0x06001A95 RID: 6805 RVA: 0x000EE3F0 File Offset: 0x000EC5F0
    private static int _amInitCircle( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_CIRCLE ams_AME_NODE_CIRCLE = (AppMain.AMS_AME_NODE_CIRCLE)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_CIRCLE ams_AME_RUNTIME_WORK_CIRCLE = (AppMain.AMS_AME_RUNTIME_WORK_CIRCLE)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_CIRCLE.time = -ams_AME_NODE_CIRCLE.start_time;
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_CIRCLE.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_CIRCLE.position, ams_AME_NODE_CIRCLE.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_CIRCLE.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_CIRCLE.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_CIRCLE.velocity, ams_AME_CREATE_PARAM.velocity );
        ams_AME_RUNTIME_WORK_CIRCLE.rotate = ams_AME_NODE_CIRCLE.rotate;
        float size_rate = ams_AME_CREATE_PARAM.ecb.size_rate;
        ams_AME_RUNTIME_WORK_CIRCLE.spread = ams_AME_NODE_CIRCLE.spread;
        ams_AME_RUNTIME_WORK_CIRCLE.radius = ams_AME_NODE_CIRCLE.radius * size_rate;
        ams_AME_RUNTIME_WORK_CIRCLE.offset = ams_AME_NODE_CIRCLE.offset * size_rate;
        ams_AME_RUNTIME_WORK_CIRCLE.offset_chaos = ams_AME_NODE_CIRCLE.offset_chaos * size_rate;
        return 0;
    }

    // Token: 0x06001A96 RID: 6806 RVA: 0x000EE4D4 File Offset: 0x000EC6D4
    private static int _amUpdateCircle( object rr )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)rr;
        AppMain.AMS_AME_NODE_CIRCLE ams_AME_NODE_CIRCLE = (AppMain.AMS_AME_NODE_CIRCLE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_RUNTIME_WORK_CIRCLE ams_AME_RUNTIME_WORK_CIRCLE = (AppMain.AMS_AME_RUNTIME_WORK_CIRCLE)ams_AME_RUNTIME.work;
        ams_AME_RUNTIME_WORK_CIRCLE.time += AppMain._am_unit_frame;
        if ( ams_AME_RUNTIME_WORK_CIRCLE.time <= 0f )
        {
            return 0;
        }
        if ( ams_AME_NODE_CIRCLE.life != -1f && ams_AME_RUNTIME_WORK_CIRCLE.time >= ams_AME_NODE_CIRCLE.life )
        {
            return 1;
        }
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorScale( nns_VECTOR4D, ams_AME_RUNTIME_WORK_CIRCLE.velocity, AppMain._am_unit_time );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_CIRCLE.position, nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        ams_AME_RUNTIME_WORK_CIRCLE.spread += ams_AME_NODE_CIRCLE.spread_variation * AppMain._am_unit_time;
        if ( ams_AME_NODE_CIRCLE.radius_variation != 0f )
        {
            ams_AME_RUNTIME_WORK_CIRCLE.radius += ams_AME_NODE_CIRCLE.radius_variation * AppMain._am_unit_time;
        }
        else
        {
            ams_AME_RUNTIME_WORK_CIRCLE.radius = ams_AME_NODE_CIRCLE.radius * size_rate;
        }
        ams_AME_RUNTIME_WORK_CIRCLE.offset = ams_AME_NODE_CIRCLE.offset * size_rate;
        ams_AME_RUNTIME_WORK_CIRCLE.offset_chaos = ams_AME_NODE_CIRCLE.offset_chaos * size_rate;
        AppMain.NNS_MATRIX amUpdateCircle_mtx = AppMain._amUpdateCircle_mtx;
        AppMain.nnMakeUnitMatrix( amUpdateCircle_mtx );
        AppMain.amMatrixPush( amUpdateCircle_mtx );
        AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_CIRCLE.rotate;
        AppMain.amQuatToMatrix( null, ref rotate, null );
        ams_AME_RUNTIME_WORK_CIRCLE.rotate = rotate;
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D3 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D4 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.child_head.next;
        AppMain.AMS_AME_LIST child_tail = ams_AME_RUNTIME.child_tail;
        while ( next != child_tail )
        {
            AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = (AppMain.AMS_AME_RUNTIME)next;
            ams_AME_RUNTIME2.amount += ams_AME_NODE_CIRCLE.frequency * AppMain._am_unit_frame;
            while ( ams_AME_RUNTIME2.amount >= 1f )
            {
                ams_AME_RUNTIME2.amount -= 1f;
                ams_AME_RUNTIME2.count += 1U;
                if ( ams_AME_NODE_CIRCLE.max_count != -1f && ( float )( ams_AME_RUNTIME2.work_num + ams_AME_RUNTIME2.active_num ) < ams_AME_NODE_CIRCLE.max_count )
                {
                    AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = new AppMain.AMS_AME_CREATE_PARAM();
                    AppMain.amVectorSet( nns_VECTOR4D4, 0f, 1f, 0f );
                    float num = ams_AME_RUNTIME_WORK_CIRCLE.radius;
                    int angle = (int)(AppMain.nnRandom() * 10000000f);
                    if ( ( ams_AME_NODE_CIRCLE.flag & 1U ) == 0U )
                    {
                        num *= AppMain.nnRandom();
                    }
                    else if ( ( ams_AME_NODE_CIRCLE.flag & 2U ) != 0U )
                    {
                        int num2 = (int)ams_AME_NODE_CIRCLE.max_count;
                        angle = ( int )( ( long )( 65535 / num2 ) * ( long )( ( ulong )ams_AME_RUNTIME2.count % ( ulong )( ( long )num2 ) ) );
                    }
                    float num3;
                    float num4;
                    AppMain.amSinCos( angle, out num3, out num4 );
                    AppMain.amVectorSet( nns_VECTOR4D2, num3 * num, 0f, num4 * num );
                    AppMain.NNS_VECTOR4D nns_VECTOR4D5 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
                    AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
                    AppMain.amVectorOuterProduct( nns_VECTOR4D5, nns_VECTOR4D4, nns_VECTOR4D2 );
                    AppMain.amVectorUnit( nns_VECTOR4D5 );
                    AppMain.amQuatRotAxisToQuat( ref nns_QUATERNION, nns_VECTOR4D5, AppMain.NNM_DEGtoRAD( ( int )ams_AME_RUNTIME_WORK_CIRCLE.spread ) );
                    AppMain.amQuatMultiVector( nns_VECTOR4D4, nns_VECTOR4D4, ref nns_QUATERNION, null );
                    AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D5 );
                    AppMain.amMatrixCalcVector( nns_VECTOR4D2, nns_VECTOR4D2 );
                    AppMain.amMatrixCalcVector( nns_VECTOR4D4, nns_VECTOR4D4 );
                    AppMain.amVectorScale( nns_VECTOR4D3, nns_VECTOR4D4, ams_AME_RUNTIME_WORK_CIRCLE.offset + ams_AME_RUNTIME_WORK_CIRCLE.offset_chaos * AppMain.nnRandom() );
                    AppMain.amVectorAdd( nns_VECTOR4D2, nns_VECTOR4D3 );
                    AppMain.amVectorScale( nns_VECTOR4D3, nns_VECTOR4D4, ams_AME_NODE_CIRCLE.speed + ams_AME_NODE_CIRCLE.speed_chaos * AppMain.nnRandom() );
                    ams_AME_CREATE_PARAM.ecb = ams_AME_RUNTIME.ecb;
                    ams_AME_CREATE_PARAM.runtime = ams_AME_RUNTIME2;
                    ams_AME_CREATE_PARAM.node = ams_AME_RUNTIME2.node;
                    ams_AME_CREATE_PARAM.parent_position = ams_AME_RUNTIME_WORK_CIRCLE.position;
                    ams_AME_CREATE_PARAM.parent_velocity = ams_AME_RUNTIME_WORK_CIRCLE.velocity;
                    ams_AME_CREATE_PARAM.position = nns_VECTOR4D2;
                    ams_AME_CREATE_PARAM.velocity = nns_VECTOR4D3;
                    int num5 = AppMain.AMD_AME_NODE_TYPE(ams_AME_RUNTIME2.node) & 65280;
                    if ( num5 != 256 )
                    {
                        if ( num5 == 512 )
                        {
                            AppMain._amCreateParticle( ams_AME_CREATE_PARAM );
                        }
                    }
                    else
                    {
                        AppMain._amCreateEmitter( ams_AME_CREATE_PARAM );
                    }
                }
            }
            next = next.next;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D3 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D4 );
        AppMain.amMatrixPop();
        return 0;
    }

    // Token: 0x06001A97 RID: 6807 RVA: 0x000EE8BD File Offset: 0x000ECABD
    private static int _amDrawCircle( object r )
    {
        return 0;
    }

    // Token: 0x06001A98 RID: 6808 RVA: 0x000EE8C0 File Offset: 0x000ECAC0
    public static int _amInitSimpleSprite( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = (AppMain.AMS_AME_NODE_SPRITE)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE ams_AME_RUNTIME_WORK_SIMPLE_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.time = -ams_AME_NODE_SPRITE.start_time;
        ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_color( ams_AME_NODE_SPRITE.color_start.r, ams_AME_NODE_SPRITE.color_start.g, ams_AME_NODE_SPRITE.color_start.b, ( byte )( ( int )ams_AME_NODE_SPRITE.color_start.a * ams_AME_CREATE_PARAM.ecb.transparency >> 8 ) );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.position, ams_AME_NODE_SPRITE.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_SPRITE.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.velocity, ams_AME_CREATE_PARAM.velocity );
        float num = ams_AME_NODE_SPRITE.size + ams_AME_NODE_SPRITE.size_chaos * AppMain.nnRandom();
        ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_size( num * ams_AME_NODE_SPRITE.scale_x_start, num * ams_AME_NODE_SPRITE.scale_y_start, num, 0f );
        if ( ( ams_AME_NODE_SPRITE.flag & 32768U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.tex_time = 0f;
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.tex_no = 0;
            if ( ( ams_AME_NODE_SPRITE.flag & 524288U ) != 0U )
            {
                ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.tex_no = ( int )( 100f * AppMain.nnRandom() ) % ams_AME_NODE_SPRITE.tex_anim.key_num;
            }
            AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = ams_AME_NODE_SPRITE.tex_anim.key_buf[ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.tex_no];
            Vector4 vector = new Vector4(ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b);
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_st( vector.X, vector.Y, vector.Z, vector.W );
        }
        else if ( ( ams_AME_NODE_SPRITE.flag & 8192U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_st( ams_AME_NODE_SPRITE.cropping_l, ams_AME_NODE_SPRITE.cropping_t, ams_AME_NODE_SPRITE.cropping_r, ams_AME_NODE_SPRITE.cropping_b );
        }
        else
        {
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_st( 0f, 0f, 1f, 1f );
        }
        if ( ( ams_AME_NODE_SPRITE.flag & 1048576U ) != 0U || ( ( ams_AME_NODE_SPRITE.flag & 131072U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.flag |= 8U;
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_st( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.z, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.y, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.x, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.w );
        }
        if ( ( ams_AME_NODE_SPRITE.flag & 2097152U ) != 0U || ( ( ams_AME_NODE_SPRITE.flag & 262144U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.flag |= 16U;
            ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.set_st( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.x, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.w, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.z, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st.y );
        }
        return 0;
    }

    // Token: 0x06001A99 RID: 6809 RVA: 0x000EEBC4 File Offset: 0x000ECDC4
    public static int _amUpdateSimpleSprite( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = (AppMain.AMS_AME_NODE_SPRITE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        int transparency = ams_AME_RUNTIME.ecb.transparency;
        float num;
        float num2;
        if ( ams_AME_NODE_SPRITE.life >= 0f )
        {
            num = ams_AME_NODE_SPRITE.life;
            num2 = 1f / num;
        }
        else
        {
            num = float.MaxValue;
            num2 = 0f;
        }
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        float num3 = ams_AME_NODE_SPRITE.scale_x_start * size_rate;
        float num4 = ams_AME_NODE_SPRITE.scale_y_start * size_rate;
        float num5 = ams_AME_NODE_SPRITE.scale_x_end * size_rate;
        float num6 = ams_AME_NODE_SPRITE.scale_y_end * size_rate;
        while ( next != active_tail )
        {
            AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE work = (AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE)((AppMain.AMS_AME_RUNTIME_WORK)next);
            work.time += AppMain._am_unit_frame;
            float num7 = work.time * num2;
            AppMain.NNS_VECTOR4D amEffect_vel = AppMain._amEffect_vel;
            AppMain.amVectorScale( amEffect_vel, work.velocity, AppMain._am_unit_time );
            AppMain.amVectorAdd( work.position, amEffect_vel );
            if ( work.time >= num )
            {
                if ( ams_AME_RUNTIME.spawn_runtime != null )
                {
                    AppMain._amCreateSpawnParticle( ams_AME_RUNTIME, work );
                }
                AppMain.amEffectDisconnectLink( ( AppMain.AMS_AME_LIST )work );
                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = ams_AME_RUNTIME;
                ams_AME_RUNTIME2.active_num -= 1;
                AppMain.amEffectFreeRuntimeWork( work );
            }
            else
            {
                float num8 = 1f - num7;
                float num9 = num3 * num8 + num5 * num7;
                float num10 = num4 * num8 + num6 * num7;
                AppMain.Vector4D_Buf size = work.size;
                work.set_size( size.z * num9, size.z * num10, size.z, size.w );
                AppMain.AMS_RGBA8888 ams_RGBA;
                AppMain.amEffectLerpColor( out ams_RGBA, ref ams_AME_NODE_SPRITE.color_start, ref ams_AME_NODE_SPRITE.color_end, num7 );
                ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * transparency >> 8 );
                work.set_color( ams_RGBA.color );
                if ( ( ams_AME_NODE_SPRITE.flag & 32768U ) != 0U )
                {
                    AppMain.AMS_AME_TEX_ANIM tex_anim = ams_AME_NODE_SPRITE.tex_anim;
                    if ( ( work.flag & 2U ) == 0U )
                    {
                        work.tex_time += AppMain._am_unit_frame;
                        if ( work.tex_time >= tex_anim.key_buf[work.tex_no].time )
                        {
                            work.tex_time = 0f;
                            work.tex_no++;
                            if ( work.tex_no == tex_anim.key_num )
                            {
                                if ( ( ams_AME_NODE_SPRITE.flag & 65536U ) != 0U )
                                {
                                    work.tex_no = 0;
                                }
                                else
                                {
                                    work.tex_no = tex_anim.key_num - 1;
                                    work.flag |= 2U;
                                }
                            }
                        }
                    }
                    AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = tex_anim.key_buf[work.tex_no];
                    Vector4 vector = new Vector4(ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b);
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        float x = vector.X;
                        vector.X = vector.Z;
                        vector.Z = x;
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        float y = vector.Y;
                        vector.Y = vector.W;
                        vector.W = y;
                    }
                    work.set_st( vector.X, vector.Y, vector.Z, vector.W );
                }
                else if ( ( ams_AME_NODE_SPRITE.flag & 16384U ) != 0U )
                {
                    float num11 = ams_AME_NODE_SPRITE.scroll_u * AppMain._am_unit_time;
                    float num12 = ams_AME_NODE_SPRITE.scroll_v * AppMain._am_unit_time;
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        num11 = -num11;
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        num12 = -num12;
                    }
                    AppMain.Vector4D_Quat st = work.st;
                    Vector4 vector2 = new Vector4(st.x + num11, st.y + num12, st.z + num11, st.w + num12);
                    work.set_st( vector2.X, vector2.Y, vector2.Z, vector2.W );
                }
            }
            next = next.next;
        }
        return 0;
    }

    // Token: 0x06001A9A RID: 6810 RVA: 0x000EEFD0 File Offset: 0x000ED1D0
    public static int _amDrawSimpleSprite( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = (AppMain.AMS_AME_NODE_SPRITE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE ams_AME_RUNTIME_WORK_SIMPLE_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE)((AppMain.AMS_AME_RUNTIME_WORK)ams_AME_RUNTIME.active_head.next);
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.amDrawAlloc_AMS_PARAM_DRAW_PRIMITIVE();
        int ablend = AppMain._amEffectSetDrawMode(ams_AME_RUNTIME, ams_PARAM_DRAW_PRIMITIVE, ams_AME_NODE_SPRITE.blend);
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR2 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR3 = default(AppMain.SNNS_VECTOR);
        float z_bias = ams_AME_NODE_SPRITE.z_bias;
        AppMain.amVectorSet( ref snns_VECTOR, z_bias * AppMain._am_ef_worldViewMtx.M20, z_bias * AppMain._am_ef_worldViewMtx.M21, z_bias * AppMain._am_ef_worldViewMtx.M22 );
        AppMain.amVectorSet( ref snns_VECTOR2, AppMain._am_ef_worldViewMtx.M10, AppMain._am_ef_worldViewMtx.M11, AppMain._am_ef_worldViewMtx.M12 );
        AppMain.amVectorSet( ref snns_VECTOR3, AppMain._am_ef_worldViewMtx.M00, AppMain._am_ef_worldViewMtx.M01, AppMain._am_ef_worldViewMtx.M02 );
        AppMain.SNNS_VECTOR snns_VECTOR4 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR5 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR6 = default(AppMain.SNNS_VECTOR);
        if ( ( ams_AME_NODE_SPRITE.flag & 4096U ) != 0U )
        {
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT((int)(6 * ams_AME_RUNTIME.active_num));
            AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
            int num = nns_PRIM3D_PCT_ARRAY.offset;
            float sortZ = 0f;
            while ( next != active_tail )
            {
                ams_AME_RUNTIME_WORK_SIMPLE_SPRITE = ( AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE )( ( AppMain.AMS_AME_RUNTIME_WORK )next );
                AppMain.nnScaleVector( ref snns_VECTOR5, ref snns_VECTOR3, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.size.y );
                AppMain.nnScaleVector( ref snns_VECTOR6, ref snns_VECTOR2, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.size.x );
                AppMain.amVectorAdd( ref snns_VECTOR4, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.position, ref snns_VECTOR );
                sortZ = AppMain.nnDistanceVector( ref snns_VECTOR4, AppMain._am_ef_camPos );
                AppMain.nnSubtractVector( ref buffer[num + 2].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref buffer[num + 2].Pos, ref buffer[num + 2].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref buffer[num].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref buffer[num].Pos, ref buffer[num].Pos, ref snns_VECTOR6 );
                AppMain.nnSubtractVector( ref buffer[num + 5].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref buffer[num + 5].Pos, ref buffer[num + 5].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref buffer[num + 1].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref buffer[num + 1].Pos, ref buffer[num + 1].Pos, ref snns_VECTOR6 );
                buffer[num + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.r, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.g, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.b, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.a );
                buffer[num].Col = ( buffer[num + 1].Col = ( buffer[num + 2].Col = buffer[num + 5].Col ) );
                AppMain.Vector4D_Quat st = ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.st;
                buffer[num].Tex.u = st.x;
                buffer[num].Tex.v = st.y;
                buffer[num + 1].Tex.u = st.z;
                buffer[num + 1].Tex.v = st.y;
                buffer[num + 2].Tex.u = st.x;
                buffer[num + 2].Tex.v = st.w;
                buffer[num + 5].Tex.u = st.z;
                buffer[num + 5].Tex.v = st.w;
                buffer[num + 3] = buffer[num + 1];
                buffer[num + 4] = buffer[num + 2];
                num += 6;
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = ( int )ams_AME_NODE_SPRITE.texture_id;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        else
        {
            AppMain.NNS_PRIM3D_PC[] array = AppMain.amDrawAlloc_NNS_PRIM3D_PC((int)(6 * ams_AME_RUNTIME.active_num));
            int num2 = 0;
            AppMain.NNS_PRIM3D_PC[] vtxPC3D = array;
            float sortZ2 = 0f;
            while ( next != active_tail )
            {
                ams_AME_RUNTIME_WORK_SIMPLE_SPRITE = ( AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE )( ( AppMain.AMS_AME_RUNTIME_WORK )next );
                AppMain.nnScaleVector( ref snns_VECTOR5, ref snns_VECTOR3, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.size.x );
                AppMain.nnScaleVector( ref snns_VECTOR6, ref snns_VECTOR2, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.size.y );
                AppMain.amVectorAdd( ref snns_VECTOR4, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.position, ref snns_VECTOR );
                sortZ2 = AppMain.nnDistanceVector( ref snns_VECTOR4, AppMain._am_ef_camPos );
                AppMain.nnSubtractVector( ref array[num2 + 2].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref array[num2 + 2].Pos, ref array[num2 + 2].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref array[num2].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref array[num2].Pos, ref array[num2].Pos, ref snns_VECTOR6 );
                AppMain.nnSubtractVector( ref array[num2 + 5].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref array[num2 + 5].Pos, ref array[num2 + 5].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref array[num2 + 1].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref array[num2 + 1].Pos, ref array[num2 + 1].Pos, ref snns_VECTOR6 );
                array[num2 + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.r, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.g, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.b, ams_AME_RUNTIME_WORK_SIMPLE_SPRITE.color.a );
                array[num2].Col = ( array[num2 + 1].Col = ( array[num2 + 2].Col = array[num2 + 5].Col ) );
                array[num2 + 3] = array[num2 + 1];
                array[num2 + 4] = array[num2 + 2];
                num2 += 6;
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = vtxPC3D;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = -1;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ2;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        return 0;
    }

    // Token: 0x06001A9B RID: 6811 RVA: 0x000EF784 File Offset: 0x000ED984
    public static int _amInitSprite( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = (AppMain.AMS_AME_NODE_SPRITE)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_SPRITE ams_AME_RUNTIME_WORK_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SPRITE)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_SPRITE.time = -ams_AME_NODE_SPRITE.start_time;
        AppMain.AMS_RGBA8888 color_start = ams_AME_NODE_SPRITE.color_start;
        color_start.color = ams_AME_NODE_SPRITE.color_start.color;
        color_start.a = ( byte )( ( int )color_start.a * ams_AME_CREATE_PARAM.ecb.transparency >> 8 );
        ams_AME_RUNTIME_WORK_SPRITE.set_color( color_start.color );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SPRITE.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SPRITE.position, ams_AME_NODE_SPRITE.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_SPRITE.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_SPRITE.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_SPRITE.velocity, ams_AME_CREATE_PARAM.velocity );
        float num = ams_AME_NODE_SPRITE.size + ams_AME_NODE_SPRITE.size_chaos * AppMain.nnRandom();
        ams_AME_RUNTIME_WORK_SPRITE.set_size( num * ams_AME_NODE_SPRITE.scale_x_start, num * ams_AME_NODE_SPRITE.scale_x_start, num, 0f );
        ams_AME_RUNTIME_WORK_SPRITE.twist = ams_AME_NODE_SPRITE.twist_angle + ams_AME_NODE_SPRITE.twist_angle_chaos * AppMain.nnRandom();
        if ( ( ams_AME_NODE_SPRITE.flag & 4U ) != 0U && AppMain.nnRandom() > 0.5f )
        {
            ams_AME_RUNTIME_WORK_SPRITE.flag |= 4U;
        }
        if ( ( ams_AME_RUNTIME_WORK_SPRITE.flag & 4U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_SPRITE.twist_speed = -ams_AME_NODE_SPRITE.twist_angle_speed;
        }
        else
        {
            ams_AME_RUNTIME_WORK_SPRITE.twist_speed = ams_AME_NODE_SPRITE.twist_angle_speed;
        }
        if ( ( ams_AME_NODE_SPRITE.flag & 32768U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_SPRITE.tex_time = 0f;
            ams_AME_RUNTIME_WORK_SPRITE.tex_no = 0;
            if ( ( ams_AME_NODE_SPRITE.flag & 524288U ) != 0U )
            {
                ams_AME_RUNTIME_WORK_SPRITE.tex_no = ( int )( 100f * AppMain.nnRandom() ) % ams_AME_NODE_SPRITE.tex_anim.key_num;
            }
            AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = ams_AME_NODE_SPRITE.tex_anim.key_buf[ams_AME_RUNTIME_WORK_SPRITE.tex_no];
            ams_AME_RUNTIME_WORK_SPRITE.set_st( ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b );
        }
        else if ( ( ams_AME_NODE_SPRITE.flag & 8192U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_SPRITE.set_st( ams_AME_NODE_SPRITE.cropping_l, ams_AME_NODE_SPRITE.cropping_t, ams_AME_NODE_SPRITE.cropping_r, ams_AME_NODE_SPRITE.cropping_b );
        }
        else
        {
            ams_AME_RUNTIME_WORK_SPRITE.set_st( 0f, 0f, 1f, 1f );
        }
        if ( ( ams_AME_NODE_SPRITE.flag & 1048576U ) != 0U || ( ( ams_AME_NODE_SPRITE.flag & 131072U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_SPRITE.flag |= 8U;
            ams_AME_RUNTIME_WORK_SPRITE.set_st( ams_AME_RUNTIME_WORK_SPRITE.st.z, ams_AME_RUNTIME_WORK_SPRITE.st.y, ams_AME_RUNTIME_WORK_SPRITE.st.x, ams_AME_RUNTIME_WORK_SPRITE.st.w );
        }
        if ( ( ams_AME_NODE_SPRITE.flag & 2097152U ) != 0U || ( ( ams_AME_NODE_SPRITE.flag & 262144U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_SPRITE.flag |= 16U;
            ams_AME_RUNTIME_WORK_SPRITE.set_st( ams_AME_RUNTIME_WORK_SPRITE.st.x, ams_AME_RUNTIME_WORK_SPRITE.st.w, ams_AME_RUNTIME_WORK_SPRITE.st.z, ams_AME_RUNTIME_WORK_SPRITE.st.y );
        }
        return 0;
    }

    // Token: 0x06001A9C RID: 6812 RVA: 0x000EFAD0 File Offset: 0x000EDCD0
    public static int _amUpdateSprite( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = (AppMain.AMS_AME_NODE_SPRITE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        int transparency = ams_AME_RUNTIME.ecb.transparency;
        float num;
        float num2;
        if ( ams_AME_NODE_SPRITE.life >= 0f )
        {
            num = ams_AME_NODE_SPRITE.life;
            num2 = 1f / num;
        }
        else
        {
            num = float.MaxValue;
            num2 = 0f;
        }
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        float num3 = ams_AME_NODE_SPRITE.scale_x_start * size_rate;
        float num4 = ams_AME_NODE_SPRITE.scale_y_start * size_rate;
        float num5 = ams_AME_NODE_SPRITE.scale_x_end * size_rate;
        float num6 = ams_AME_NODE_SPRITE.scale_y_end * size_rate;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        while ( next != active_tail )
        {
            AppMain.AMS_AME_RUNTIME_WORK_SPRITE work = (AppMain.AMS_AME_RUNTIME_WORK_SPRITE)((AppMain.AMS_AME_RUNTIME_WORK)next);
            work.time += AppMain._am_unit_frame;
            float num7 = work.time * num2;
            AppMain.amVectorScale( nns_VECTOR4D, work.velocity, AppMain._am_unit_time );
            AppMain.amVectorAdd( work.position, nns_VECTOR4D );
            if ( work.time >= num )
            {
                if ( ams_AME_RUNTIME.spawn_runtime != null )
                {
                    AppMain._amCreateSpawnParticle( ams_AME_RUNTIME, work );
                }
                AppMain.amEffectDisconnectLink( ( AppMain.AMS_AME_LIST )work );
                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = ams_AME_RUNTIME;
                ams_AME_RUNTIME2.active_num -= 1;
                AppMain.amEffectFreeRuntimeWork( work );
            }
            else
            {
                float num8 = 1f - num7;
                float num9 = num3 * num8 + num5 * num7;
                float num10 = num4 * num8 + num6 * num7;
                work.set_size( work.size.z * num9, work.size.z * num10, work.size.z, work.size.w );
                work.twist += work.twist_speed * AppMain._am_unit_time;
                AppMain.AMS_RGBA8888 ams_RGBA;
                AppMain.amEffectLerpColor( out ams_RGBA, ref ams_AME_NODE_SPRITE.color_start, ref ams_AME_NODE_SPRITE.color_end, num7 );
                ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * transparency >> 8 );
                work.set_color( ams_RGBA.color );
                if ( ( ams_AME_NODE_SPRITE.flag & 32768U ) != 0U )
                {
                    AppMain.AMS_AME_TEX_ANIM tex_anim = ams_AME_NODE_SPRITE.tex_anim;
                    if ( ( work.flag & 2U ) == 0U )
                    {
                        work.tex_time += AppMain._am_unit_frame;
                        if ( work.tex_time >= tex_anim.key_buf[work.tex_no].time )
                        {
                            work.tex_time = 0f;
                            work.tex_no++;
                            if ( work.tex_no == tex_anim.key_num )
                            {
                                if ( ( ams_AME_NODE_SPRITE.flag & 65536U ) != 0U )
                                {
                                    work.tex_no = 0;
                                }
                                else
                                {
                                    work.tex_no = tex_anim.key_num - 1;
                                    work.flag |= 2U;
                                }
                            }
                        }
                    }
                    AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = tex_anim.key_buf[work.tex_no];
                    work.set_st( ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b );
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        work.set_st( work.st.z, work.st.y, work.st.x, work.st.w );
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        work.set_st( work.st.x, work.st.w, work.st.z, work.st.y );
                    }
                }
                else if ( ( ams_AME_NODE_SPRITE.flag & 16384U ) != 0U )
                {
                    float num11 = ams_AME_NODE_SPRITE.scroll_u * AppMain._am_unit_time;
                    float num12 = ams_AME_NODE_SPRITE.scroll_v * AppMain._am_unit_time;
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        num11 = -num11;
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        num12 = -num12;
                    }
                    work.set_st( work.st.x + num11, work.st.y + num12, work.st.z + num11, work.st.w + num12 );
                }
            }
            next = next.next;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        return 0;
    }

    // Token: 0x06001A9D RID: 6813 RVA: 0x000EFF40 File Offset: 0x000EE140
    public static int _amDrawSprite( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = (AppMain.AMS_AME_NODE_SPRITE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        int ablend = AppMain._amEffectSetDrawMode(ams_AME_RUNTIME, ams_PARAM_DRAW_PRIMITIVE, ams_AME_NODE_SPRITE.blend);
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR2 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR3 = default(AppMain.SNNS_VECTOR);
        float z_bias = ams_AME_NODE_SPRITE.z_bias;
        AppMain.amVectorSet( ref snns_VECTOR, z_bias * AppMain._am_ef_worldViewMtx.M20, z_bias * AppMain._am_ef_worldViewMtx.M21, z_bias * AppMain._am_ef_worldViewMtx.M22 );
        AppMain.amVectorSet( ref snns_VECTOR2, AppMain._am_ef_worldViewMtx.M10, AppMain._am_ef_worldViewMtx.M11, AppMain._am_ef_worldViewMtx.M12 );
        AppMain.amVectorSet( ref snns_VECTOR3, AppMain._am_ef_worldViewMtx.M00, AppMain._am_ef_worldViewMtx.M01, AppMain._am_ef_worldViewMtx.M02 );
        AppMain.SNNS_VECTOR snns_VECTOR4 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR5 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR6 = default(AppMain.SNNS_VECTOR);
        if ( ( ams_AME_NODE_SPRITE.flag & 4096U ) != 0U )
        {
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT((int)(6 * ams_AME_RUNTIME.active_num));
            AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
            int num = nns_PRIM3D_PCT_ARRAY.offset;
            float sortZ = 0f;
            while ( next != active_tail )
            {
                AppMain.AMS_AME_RUNTIME_WORK_SPRITE ams_AME_RUNTIME_WORK_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SPRITE)((AppMain.AMS_AME_RUNTIME_WORK)next);
                float num2;
                float num3;
                AppMain.amSinCos( ams_AME_RUNTIME_WORK_SPRITE.twist, out num2, out num3 );
                AppMain.amVectorGetAverage( ref snns_VECTOR5, ref snns_VECTOR3, ref snns_VECTOR2, num3, -num2 );
                AppMain.amVectorGetAverage( ref snns_VECTOR6, ref snns_VECTOR3, ref snns_VECTOR2, num2, num3 );
                AppMain.nnScaleVector( ref snns_VECTOR5, ref snns_VECTOR5, ams_AME_RUNTIME_WORK_SPRITE.size.x );
                AppMain.nnScaleVector( ref snns_VECTOR6, ref snns_VECTOR6, ams_AME_RUNTIME_WORK_SPRITE.size.y );
                AppMain.amVectorAdd( ref snns_VECTOR4, ams_AME_RUNTIME_WORK_SPRITE.position, ref snns_VECTOR );
                sortZ = AppMain.nnDistanceVector( ref snns_VECTOR4, AppMain._am_ef_camPos );
                AppMain.nnSubtractVector( ref buffer[num].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref buffer[num].Pos, ref buffer[num].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref buffer[num + 1].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref buffer[num + 1].Pos, ref buffer[num + 1].Pos, ref snns_VECTOR6 );
                AppMain.nnSubtractVector( ref buffer[num + 2].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref buffer[num + 2].Pos, ref buffer[num + 2].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref buffer[num + 5].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref buffer[num + 5].Pos, ref buffer[num + 5].Pos, ref snns_VECTOR6 );
                buffer[num + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_SPRITE.color.r, ams_AME_RUNTIME_WORK_SPRITE.color.g, ams_AME_RUNTIME_WORK_SPRITE.color.b, ams_AME_RUNTIME_WORK_SPRITE.color.a );
                buffer[num].Col = ( buffer[num + 1].Col = ( buffer[num + 2].Col = buffer[num + 5].Col ) );
                buffer[num].Tex.u = ams_AME_RUNTIME_WORK_SPRITE.st.x;
                buffer[num].Tex.v = ams_AME_RUNTIME_WORK_SPRITE.st.y;
                buffer[num + 1].Tex.u = ams_AME_RUNTIME_WORK_SPRITE.st.z;
                buffer[num + 1].Tex.v = ams_AME_RUNTIME_WORK_SPRITE.st.y;
                buffer[num + 2].Tex.u = ams_AME_RUNTIME_WORK_SPRITE.st.x;
                buffer[num + 2].Tex.v = ams_AME_RUNTIME_WORK_SPRITE.st.w;
                buffer[num + 5].Tex.u = ams_AME_RUNTIME_WORK_SPRITE.st.z;
                buffer[num + 5].Tex.v = ams_AME_RUNTIME_WORK_SPRITE.st.w;
                buffer[num + 3] = buffer[num + 1];
                buffer[num + 4] = buffer[num + 2];
                num += 6;
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = ( int )ams_AME_NODE_SPRITE.texture_id;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        else
        {
            AppMain.NNS_PRIM3D_PC[] array = AppMain.amDrawAlloc_NNS_PRIM3D_PC((int)(6 * ams_AME_RUNTIME.active_num));
            int num4 = 0;
            AppMain.NNS_PRIM3D_PC[] vtxPC3D = array;
            float sortZ2 = 0f;
            while ( next != active_tail )
            {
                AppMain.AMS_AME_RUNTIME_WORK_SPRITE ams_AME_RUNTIME_WORK_SPRITE = (AppMain.AMS_AME_RUNTIME_WORK_SPRITE)((AppMain.AMS_AME_RUNTIME_WORK)next);
                float num5;
                float num6;
                AppMain.amSinCos( ams_AME_RUNTIME_WORK_SPRITE.twist, out num5, out num6 );
                AppMain.amVectorGetAverage( ref snns_VECTOR5, ref snns_VECTOR3, ref snns_VECTOR2, num6, -num5 );
                AppMain.amVectorGetAverage( ref snns_VECTOR6, ref snns_VECTOR3, ref snns_VECTOR2, num5, num6 );
                AppMain.nnScaleVector( ref snns_VECTOR5, ref snns_VECTOR5, ams_AME_RUNTIME_WORK_SPRITE.size.x );
                AppMain.nnScaleVector( ref snns_VECTOR6, ref snns_VECTOR6, ams_AME_RUNTIME_WORK_SPRITE.size.y );
                AppMain.amVectorAdd( ref snns_VECTOR4, ams_AME_RUNTIME_WORK_SPRITE.position, ref snns_VECTOR );
                sortZ2 = AppMain.nnDistanceVector( ref snns_VECTOR4, AppMain._am_ef_camPos );
                AppMain.nnSubtractVector( ref array[num4].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref array[num4].Pos, ref array[num4].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref array[num4 + 1].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnAddVector( ref array[num4 + 1].Pos, ref array[num4 + 1].Pos, ref snns_VECTOR6 );
                AppMain.nnSubtractVector( ref array[num4 + 2].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref array[num4 + 2].Pos, ref array[num4 + 2].Pos, ref snns_VECTOR6 );
                AppMain.nnAddVector( ref array[num4 + 5].Pos, ref snns_VECTOR4, ref snns_VECTOR5 );
                AppMain.nnSubtractVector( ref array[num4 + 5].Pos, ref array[num4 + 5].Pos, ref snns_VECTOR6 );
                array[num4 + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_SPRITE.color.r, ams_AME_RUNTIME_WORK_SPRITE.color.g, ams_AME_RUNTIME_WORK_SPRITE.color.b, ams_AME_RUNTIME_WORK_SPRITE.color.a );
                array[num4].Col = ( array[num4 + 1].Col = ( array[num4 + 2].Col = array[num4 + 5].Col ) );
                array[num4 + 3] = array[num4 + 1];
                array[num4 + 4] = array[num4 + 2];
                num4 += 6;
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = vtxPC3D;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = -1;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ2;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
        return 0;
    }

    // Token: 0x06001A9E RID: 6814 RVA: 0x000F0784 File Offset: 0x000EE984
    public static int _amInitLine( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_LINE ams_AME_NODE_LINE = (AppMain.AMS_AME_NODE_LINE)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_LINE ams_AME_RUNTIME_WORK_LINE = (AppMain.AMS_AME_RUNTIME_WORK_LINE)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_LINE.time = -ams_AME_NODE_LINE.start_time;
        ams_AME_RUNTIME_WORK_LINE.length = ams_AME_NODE_LINE.length_start;
        ams_AME_RUNTIME_WORK_LINE.inside_width = ams_AME_NODE_LINE.inside_width_start;
        ams_AME_RUNTIME_WORK_LINE.outside_width = ams_AME_NODE_LINE.outside_width_start;
        AppMain.AMS_RGBA8888 ams_RGBA = ams_AME_NODE_LINE.inside_color_start;
        ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * ams_AME_CREATE_PARAM.ecb.transparency >> 8 );
        ams_AME_RUNTIME_WORK_LINE.set_inside_color( ams_RGBA.color );
        ams_RGBA = ams_AME_NODE_LINE.outside_color_start;
        ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * ams_AME_CREATE_PARAM.ecb.transparency >> 8 );
        ams_AME_RUNTIME_WORK_LINE.set_outside_color( ams_RGBA.color );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_LINE.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_LINE.position, ams_AME_NODE_LINE.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_LINE.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_LINE.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_LINE.velocity, ams_AME_CREATE_PARAM.velocity );
        if ( ( ams_AME_NODE_LINE.flag & 32768U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_LINE.tex_time = 0f;
            ams_AME_RUNTIME_WORK_LINE.tex_no = 0;
            if ( ( ams_AME_NODE_LINE.flag & 524288U ) != 0U )
            {
                ams_AME_RUNTIME_WORK_LINE.tex_no = ( int )( 100f * AppMain.nnRandom() ) % ams_AME_NODE_LINE.tex_anim.key_num;
            }
            AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = ams_AME_NODE_LINE.tex_anim.key_buf[ams_AME_RUNTIME_WORK_LINE.tex_no];
            ams_AME_RUNTIME_WORK_LINE.set_st( ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b );
        }
        else if ( ( ams_AME_NODE_LINE.flag & 8192U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_LINE.set_st( ams_AME_NODE_LINE.cropping_l, ams_AME_NODE_LINE.cropping_t, ams_AME_NODE_LINE.cropping_r, ams_AME_NODE_LINE.cropping_b );
        }
        else
        {
            ams_AME_RUNTIME_WORK_LINE.set_st( 0f, 0f, 1f, 1f );
        }
        if ( ( ams_AME_NODE_LINE.flag & 1048576U ) != 0U || ( ( ams_AME_NODE_LINE.flag & 131072U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_LINE.flag |= 8U;
            ams_AME_RUNTIME_WORK_LINE.set_st( ams_AME_RUNTIME_WORK_LINE.st.z, ams_AME_RUNTIME_WORK_LINE.st.y, ams_AME_RUNTIME_WORK_LINE.st.x, ams_AME_RUNTIME_WORK_LINE.st.w );
        }
        if ( ( ams_AME_NODE_LINE.flag & 2097152U ) != 0U || ( ( ams_AME_NODE_LINE.flag & 262144U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_LINE.flag |= 16U;
            ams_AME_RUNTIME_WORK_LINE.set_st( ams_AME_RUNTIME_WORK_LINE.st.x, ams_AME_RUNTIME_WORK_LINE.st.w, ams_AME_RUNTIME_WORK_LINE.st.z, ams_AME_RUNTIME_WORK_LINE.st.y );
        }
        return 0;
    }

    // Token: 0x06001A9F RID: 6815 RVA: 0x000F0A7C File Offset: 0x000EEC7C
    public static int _amUpdateLine( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_LINE ams_AME_NODE_LINE = (AppMain.AMS_AME_NODE_LINE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        int transparency = ams_AME_RUNTIME.ecb.transparency;
        float num;
        float num2;
        if ( ams_AME_NODE_LINE.life >= 0f )
        {
            num = ams_AME_NODE_LINE.life;
            num2 = 1f / num;
        }
        else
        {
            num = 1E+38f;
            num2 = 0f;
        }
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        float num3 = ams_AME_NODE_LINE.length_start * size_rate;
        float num4 = ams_AME_NODE_LINE.length_end * size_rate;
        float num5 = ams_AME_NODE_LINE.inside_width_start * size_rate;
        float num6 = ams_AME_NODE_LINE.outside_width_start * size_rate;
        float num7 = ams_AME_NODE_LINE.inside_width_end * size_rate;
        float num8 = ams_AME_NODE_LINE.outside_width_end * size_rate;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        while ( next != active_tail )
        {
            AppMain.AMS_AME_RUNTIME_WORK_LINE work = (AppMain.AMS_AME_RUNTIME_WORK_LINE)((AppMain.AMS_AME_RUNTIME_WORK)next);
            work.time += AppMain._am_unit_frame;
            float num9 = work.time * num2;
            AppMain.amVectorScale( nns_VECTOR4D, work.velocity, AppMain._am_unit_time );
            AppMain.amVectorAdd( work.position, nns_VECTOR4D );
            if ( work.time >= num )
            {
                if ( ams_AME_RUNTIME.spawn_runtime != null )
                {
                    AppMain._amCreateSpawnParticle( ams_AME_RUNTIME, work );
                }
                AppMain.amEffectDisconnectLink( ( AppMain.AMS_AME_LIST )work );
                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = ams_AME_RUNTIME;
                ams_AME_RUNTIME2.active_num -= 1;
                AppMain.amEffectFreeRuntimeWork( work );
            }
            else
            {
                float num10 = 1f - num9;
                work.length = num3 * num10 + num4 * num9;
                work.inside_width = num5 * num10 + num7 * num9;
                work.outside_width = num6 * num10 + num8 * num9;
                AppMain.AMS_RGBA8888 ams_RGBA;
                AppMain.amEffectLerpColor( out ams_RGBA, ref ams_AME_NODE_LINE.inside_color_start, ref ams_AME_NODE_LINE.inside_color_end, num9 );
                ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * transparency >> 8 );
                work.set_inside_color( ams_RGBA.color );
                AppMain.amEffectLerpColor( out ams_RGBA, ref ams_AME_NODE_LINE.outside_color_start, ref ams_AME_NODE_LINE.outside_color_end, num9 );
                ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * transparency >> 8 );
                work.set_outside_color( ams_RGBA.color );
                if ( ( ams_AME_NODE_LINE.flag & 32768U ) != 0U )
                {
                    AppMain.AMS_AME_TEX_ANIM tex_anim = ams_AME_NODE_LINE.tex_anim;
                    if ( ( work.flag & 2U ) == 0U )
                    {
                        work.tex_time += AppMain._am_unit_frame;
                        if ( work.tex_time >= tex_anim.key_buf[work.tex_no].time )
                        {
                            work.tex_time = 0f;
                            work.tex_no++;
                            if ( work.tex_no == tex_anim.key_num )
                            {
                                if ( ( ams_AME_NODE_LINE.flag & 65536U ) != 0U )
                                {
                                    work.tex_no = 0;
                                }
                                else
                                {
                                    work.tex_no = tex_anim.key_num - 1;
                                    work.flag |= 2U;
                                }
                            }
                        }
                    }
                    AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = tex_anim.key_buf[work.tex_no];
                    work.set_st( ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b );
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        work.set_st( work.st.z, work.st.y, work.st.x, work.st.w );
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        work.set_st( work.st.x, work.st.w, work.st.z, work.st.y );
                    }
                }
                else if ( ( ams_AME_NODE_LINE.flag & 16384U ) != 0U )
                {
                    float num11 = ams_AME_NODE_LINE.scroll_u * AppMain._am_unit_time;
                    float num12 = ams_AME_NODE_LINE.scroll_v * AppMain._am_unit_time;
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        num11 = -num11;
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        num12 = -num12;
                    }
                    work.set_st( work.st.x + num11, work.st.w + num11, work.st.z + num12, work.st.y + num12 );
                }
            }
            next = next.next;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        return 0;
    }

    // Token: 0x06001AA0 RID: 6816 RVA: 0x000F0EF0 File Offset: 0x000EF0F0
    public static int _amDrawLine( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_LINE ams_AME_NODE_LINE = (AppMain.AMS_AME_NODE_LINE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.amDrawAlloc_AMS_PARAM_DRAW_PRIMITIVE();
        int ablend = AppMain._amEffectSetDrawMode(ams_AME_RUNTIME, ams_PARAM_DRAW_PRIMITIVE, ams_AME_NODE_LINE.blend);
        AppMain.NNS_VECTOR4D amDrawLine_offset = AppMain._amDrawLine_offset;
        AppMain.NNS_VECTOR4D amDrawLine_eye = AppMain._amDrawLine_eye;
        float z_bias = ams_AME_NODE_LINE.z_bias;
        AppMain.amVectorSet( amDrawLine_offset, z_bias * AppMain._am_ef_worldViewMtx.M20, z_bias * AppMain._am_ef_worldViewMtx.M21, z_bias * AppMain._am_ef_worldViewMtx.M22 );
        AppMain.amVectorSet( amDrawLine_eye, AppMain._am_ef_worldViewMtx.M20, AppMain._am_ef_worldViewMtx.M21, AppMain._am_ef_worldViewMtx.M22 );
        AppMain.NNS_VECTOR4D amDrawLine_pos = AppMain._amDrawLine_pos0;
        AppMain.NNS_VECTOR4D amDrawLine_pos2 = AppMain._amDrawLine_pos1;
        AppMain.NNS_VECTOR amDrawLine_vel = AppMain._amDrawLine_vel;
        AppMain.NNS_VECTOR amDrawLine_cross = AppMain._amDrawLine_cross;
        if ( ( ams_AME_NODE_LINE.flag & 4096U ) != 0U )
        {
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT((int)(6 * ams_AME_RUNTIME.active_num));
            AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
            int num = nns_PRIM3D_PCT_ARRAY.offset;
            float sortZ = 0f;
            while ( next != active_tail )
            {
                AppMain.AMS_AME_RUNTIME_WORK_LINE ams_AME_RUNTIME_WORK_LINE = (AppMain.AMS_AME_RUNTIME_WORK_LINE)((AppMain.AMS_AME_RUNTIME_WORK)next);
                AppMain.amVectorUnit( amDrawLine_vel, ams_AME_RUNTIME_WORK_LINE.velocity );
                AppMain.nnScaleVector( amDrawLine_pos, amDrawLine_vel, ams_AME_RUNTIME_WORK_LINE.length );
                AppMain.amVectorAdd( amDrawLine_pos2, ams_AME_RUNTIME_WORK_LINE.position, amDrawLine_offset );
                AppMain.nnAddVector( amDrawLine_pos, amDrawLine_pos, amDrawLine_pos2 );
                sortZ = AppMain.nnDistanceVector( amDrawLine_pos, AppMain._am_ef_camPos );
                AppMain.nnCrossProductVector( amDrawLine_cross, amDrawLine_vel, amDrawLine_eye );
                AppMain.nnNormalizeVector( amDrawLine_cross, amDrawLine_cross );
                AppMain.nnScaleVector( amDrawLine_vel, amDrawLine_cross, ams_AME_RUNTIME_WORK_LINE.outside_width );
                AppMain.nnSubtractVector( ref buffer[num].Pos, amDrawLine_pos, amDrawLine_vel );
                AppMain.nnAddVector( ref buffer[num + 1].Pos, amDrawLine_pos, amDrawLine_vel );
                AppMain.nnScaleVector( amDrawLine_vel, amDrawLine_cross, ams_AME_RUNTIME_WORK_LINE.inside_width );
                AppMain.nnSubtractVector( ref buffer[num + 2].Pos, amDrawLine_pos2, amDrawLine_vel );
                AppMain.nnAddVector( ref buffer[num + 5].Pos, amDrawLine_pos2, amDrawLine_vel );
                buffer[num + 1].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_LINE.outside_color.r, ams_AME_RUNTIME_WORK_LINE.outside_color.g, ams_AME_RUNTIME_WORK_LINE.outside_color.b, ams_AME_RUNTIME_WORK_LINE.outside_color.a );
                buffer[num].Col = buffer[num + 1].Col;
                buffer[num + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_LINE.inside_color.r, ams_AME_RUNTIME_WORK_LINE.inside_color.g, ams_AME_RUNTIME_WORK_LINE.inside_color.b, ams_AME_RUNTIME_WORK_LINE.inside_color.a );
                buffer[num + 2].Col = buffer[num + 5].Col;
                AppMain.Vector4D_Quat st = ams_AME_RUNTIME_WORK_LINE.st;
                buffer[num].Tex.u = st.x;
                buffer[num].Tex.v = st.y;
                buffer[num + 1].Tex.u = st.z;
                buffer[num + 1].Tex.v = st.y;
                buffer[num + 2].Tex.u = st.x;
                buffer[num + 2].Tex.v = st.w;
                buffer[num + 5].Tex.u = st.z;
                buffer[num + 5].Tex.v = st.w;
                buffer[num + 3] = buffer[num + 1];
                buffer[num + 4] = buffer[num + 2];
                num += 6;
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = ( int )ams_AME_NODE_LINE.texture_id;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        else
        {
            AppMain.NNS_PRIM3D_PC[] array = new AppMain.NNS_PRIM3D_PC[(int)(6 * ams_AME_RUNTIME.active_num)];
            int num2 = 0;
            AppMain.NNS_PRIM3D_PC[] vtxPC3D = array;
            float sortZ2 = 0f;
            while ( next != active_tail )
            {
                AppMain.AMS_AME_RUNTIME_WORK_LINE ams_AME_RUNTIME_WORK_LINE = (AppMain.AMS_AME_RUNTIME_WORK_LINE)((AppMain.AMS_AME_RUNTIME_WORK)next);
                AppMain.amVectorUnit( amDrawLine_vel, ams_AME_RUNTIME_WORK_LINE.velocity );
                AppMain.nnScaleVector( amDrawLine_pos, amDrawLine_vel, ams_AME_RUNTIME_WORK_LINE.length );
                AppMain.amVectorAdd( amDrawLine_pos2, ams_AME_RUNTIME_WORK_LINE.position, amDrawLine_offset );
                AppMain.nnAddVector( amDrawLine_pos, amDrawLine_pos, amDrawLine_pos2 );
                sortZ2 = AppMain.nnDistanceVector( amDrawLine_pos, AppMain._am_ef_camPos );
                AppMain.nnCrossProductVector( amDrawLine_cross, amDrawLine_vel, amDrawLine_eye );
                AppMain.nnNormalizeVector( amDrawLine_cross, amDrawLine_cross );
                AppMain.nnScaleVector( amDrawLine_vel, amDrawLine_cross, ams_AME_RUNTIME_WORK_LINE.outside_width );
                AppMain.nnSubtractVector( ref array[num2].Pos, amDrawLine_pos, amDrawLine_vel );
                AppMain.nnAddVector( ref array[num2 + 1].Pos, amDrawLine_pos, amDrawLine_vel );
                AppMain.nnScaleVector( amDrawLine_vel, amDrawLine_cross, ams_AME_RUNTIME_WORK_LINE.inside_width );
                AppMain.nnSubtractVector( ref array[num2 + 2].Pos, amDrawLine_pos2, amDrawLine_vel );
                AppMain.nnAddVector( ref array[num2 + 5].Pos, amDrawLine_pos2, amDrawLine_vel );
                array[num2 + 1].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_LINE.outside_color.r, ams_AME_RUNTIME_WORK_LINE.outside_color.g, ams_AME_RUNTIME_WORK_LINE.outside_color.b, ams_AME_RUNTIME_WORK_LINE.outside_color.a );
                array[num2].Col = array[num2 + 1].Col;
                array[num2 + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_LINE.inside_color.r, ams_AME_RUNTIME_WORK_LINE.inside_color.g, ams_AME_RUNTIME_WORK_LINE.inside_color.b, ams_AME_RUNTIME_WORK_LINE.inside_color.a );
                array[num2 + 2].Col = array[num2 + 5].Col;
                array[num2 + 3] = array[num2 + 1];
                array[num2 + 4] = array[num2 + 2];
                num2 += 6;
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = vtxPC3D;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = -1;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ2;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        return 0;
    }

    // Token: 0x06001AA1 RID: 6817 RVA: 0x000F1624 File Offset: 0x000EF824
    public static int _amInitPlane( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_PLANE ams_AME_NODE_PLANE = (AppMain.AMS_AME_NODE_PLANE)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_PLANE ams_AME_RUNTIME_WORK_PLANE = (AppMain.AMS_AME_RUNTIME_WORK_PLANE)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_PLANE.time = -ams_AME_NODE_PLANE.start_time;
        AppMain.AMS_RGBA8888 color_start = ams_AME_NODE_PLANE.color_start;
        ams_AME_RUNTIME_WORK_PLANE.set_color( color_start.r, color_start.g, color_start.b, ( byte )( ( int )color_start.a * ams_AME_CREATE_PARAM.ecb.transparency >> 8 ) );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_PLANE.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_PLANE.position, ams_AME_NODE_PLANE.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_PLANE.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_PLANE.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_PLANE.velocity, ams_AME_CREATE_PARAM.velocity );
        if ( ( ams_AME_NODE_PLANE.flag & 4U ) != 0U )
        {
            AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
            float radian = AppMain.nnRandom() * 2f * 3.1415927f;
            AppMain.amVectorRandom( nns_VECTOR4D );
            AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_PLANE.rotate;
            AppMain.amQuatRotAxisToQuat( ref rotate, nns_VECTOR4D, radian );
            ams_AME_RUNTIME_WORK_PLANE.rotate = rotate;
            AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        }
        else
        {
            ams_AME_RUNTIME_WORK_PLANE.rotate = ams_AME_NODE_PLANE.rotate;
        }
        if ( ( ams_AME_NODE_PLANE.flag & 8U ) != 0U )
        {
            AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
            AppMain.amVectorRandom( nns_VECTOR4D2 );
            ams_AME_RUNTIME_WORK_PLANE.set_rotate_axis( nns_VECTOR4D2.x, nns_VECTOR4D2.y, nns_VECTOR4D2.z, ams_AME_NODE_PLANE.rotate_axis.w );
            AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
        }
        else
        {
            ams_AME_RUNTIME_WORK_PLANE.rotate_axis.Assign( ams_AME_NODE_PLANE.rotate_axis );
        }
        float num = ams_AME_NODE_PLANE.size + ams_AME_NODE_PLANE.size_chaos * AppMain.nnRandom();
        ams_AME_RUNTIME_WORK_PLANE.set_size( num * ams_AME_NODE_PLANE.scale_x_start, num * ams_AME_NODE_PLANE.scale_y_start, num, 0f );
        if ( ( ams_AME_NODE_PLANE.flag & 32768U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_PLANE.tex_time = 0f;
            ams_AME_RUNTIME_WORK_PLANE.tex_no = 0;
            if ( ( ams_AME_NODE_PLANE.flag & 524288U ) != 0U )
            {
                ams_AME_RUNTIME_WORK_PLANE.tex_no = ( int )( 100f * AppMain.nnRandom() ) % ams_AME_NODE_PLANE.tex_anim.key_num;
            }
            AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = ams_AME_NODE_PLANE.tex_anim.key_buf[ams_AME_RUNTIME_WORK_PLANE.tex_no];
            ams_AME_RUNTIME_WORK_PLANE.set_st( ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b );
        }
        else if ( ( ams_AME_NODE_PLANE.flag & 8192U ) != 0U )
        {
            ams_AME_RUNTIME_WORK_PLANE.set_st( ams_AME_NODE_PLANE.cropping_l, ams_AME_NODE_PLANE.cropping_t, ams_AME_NODE_PLANE.cropping_r, ams_AME_NODE_PLANE.cropping_b );
        }
        else
        {
            ams_AME_RUNTIME_WORK_PLANE.set_st( 0f, 0f, 1f, 1f );
        }
        if ( ( ams_AME_NODE_PLANE.flag & 1048576U ) != 0U || ( ( ams_AME_NODE_PLANE.flag & 131072U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_PLANE.flag |= 8U;
            ams_AME_RUNTIME_WORK_PLANE.set_st( ams_AME_RUNTIME_WORK_PLANE.st.z, ams_AME_RUNTIME_WORK_PLANE.st.y, ams_AME_RUNTIME_WORK_PLANE.st.x, ams_AME_RUNTIME_WORK_PLANE.st.w );
        }
        if ( ( ams_AME_NODE_PLANE.flag & 2097152U ) != 0U || ( ( ams_AME_NODE_PLANE.flag & 262144U ) != 0U && AppMain.nnRandom() > 0.5f ) )
        {
            ams_AME_RUNTIME_WORK_PLANE.flag |= 16U;
            ams_AME_RUNTIME_WORK_PLANE.set_st( ams_AME_RUNTIME_WORK_PLANE.st.x, ams_AME_RUNTIME_WORK_PLANE.st.w, ams_AME_RUNTIME_WORK_PLANE.st.z, ams_AME_RUNTIME_WORK_PLANE.st.y );
        }
        return 0;
    }

    // Token: 0x06001AA2 RID: 6818 RVA: 0x000F19BC File Offset: 0x000EFBBC
    public static int _amUpdatePlane( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_PLANE ams_AME_NODE_PLANE = (AppMain.AMS_AME_NODE_PLANE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        int transparency = ams_AME_RUNTIME.ecb.transparency;
        float num;
        float num2;
        if ( ams_AME_NODE_PLANE.life >= 0f )
        {
            num = ams_AME_NODE_PLANE.life;
            num2 = 1f / num;
        }
        else
        {
            num = float.MaxValue;
            num2 = 0f;
        }
        float size_rate = ams_AME_RUNTIME.ecb.size_rate;
        float num3 = ams_AME_NODE_PLANE.scale_x_start * size_rate;
        float num4 = ams_AME_NODE_PLANE.scale_y_start * size_rate;
        float num5 = ams_AME_NODE_PLANE.scale_x_end * size_rate;
        float num6 = ams_AME_NODE_PLANE.scale_y_end * size_rate;
        AppMain.NNS_VECTOR4D amEffect_vel = AppMain._amEffect_vel;
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        while ( next != active_tail )
        {
            AppMain.AMS_AME_RUNTIME_WORK_PLANE work = (AppMain.AMS_AME_RUNTIME_WORK_PLANE)((AppMain.AMS_AME_RUNTIME_WORK)next);
            work.time += AppMain._am_unit_frame;
            float num7 = work.time * num2;
            AppMain.amVectorScale( amEffect_vel, work.velocity, AppMain._am_unit_time );
            AppMain.amVectorAdd( work.position, amEffect_vel );
            if ( work.time >= num )
            {
                if ( ams_AME_RUNTIME.spawn_runtime != null )
                {
                    AppMain._amCreateSpawnParticle( ams_AME_RUNTIME, ( AppMain.AMS_AME_RUNTIME_WORK )( ( AppMain.AMS_AME_LIST )work ) );
                }
                AppMain.amEffectDisconnectLink( ( AppMain.AMS_AME_LIST )work );
                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = ams_AME_RUNTIME;
                ams_AME_RUNTIME2.active_num -= 1;
                AppMain.amEffectFreeRuntimeWork( ( AppMain.AMS_AME_RUNTIME_WORK )( ( AppMain.AMS_AME_LIST )work ) );
            }
            else
            {
                nns_VECTOR4D.x = work.rotate_axis.x;
                nns_VECTOR4D.y = work.rotate_axis.y;
                nns_VECTOR4D.z = work.rotate_axis.z;
                nns_VECTOR4D.w = work.rotate_axis.w;
                AppMain.amQuatRotAxisToQuat( ref nns_QUATERNION, nns_VECTOR4D, nns_VECTOR4D.w * AppMain._am_unit_time );
                AppMain.NNS_QUATERNION rotate = work.rotate;
                AppMain.amQuatMulti( ref rotate, ref nns_QUATERNION, ref rotate );
                work.rotate = rotate;
                float num8 = 1f - num7;
                float num9 = num3 * num8 + num5 * num7;
                float num10 = num4 * num8 + num6 * num7;
                work.set_size( work.size.z * num9, work.size.z * num10, work.size.z, work.size.w );
                AppMain.AMS_RGBA8888 ams_RGBA;
                AppMain.amEffectLerpColor( out ams_RGBA, ref ams_AME_NODE_PLANE.color_start, ref ams_AME_NODE_PLANE.color_end, num7 );
                ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * transparency >> 8 );
                work.set_color( ams_RGBA.color );
                if ( ( ams_AME_NODE_PLANE.flag & 32768U ) != 0U )
                {
                    AppMain.AMS_AME_TEX_ANIM tex_anim = ams_AME_NODE_PLANE.tex_anim;
                    if ( ( work.flag & 2U ) == 0U )
                    {
                        work.tex_time += AppMain._am_unit_frame;
                        if ( work.tex_time >= tex_anim.key_buf[work.tex_no].time )
                        {
                            work.tex_time = 0f;
                            work.tex_no++;
                            if ( work.tex_no == tex_anim.key_num )
                            {
                                if ( ( ams_AME_NODE_PLANE.flag & 65536U ) != 0U )
                                {
                                    work.tex_no = 0;
                                }
                                else
                                {
                                    work.tex_no = tex_anim.key_num - 1;
                                    work.flag |= 2U;
                                }
                            }
                        }
                    }
                    AppMain.AMS_AME_TEX_ANIM_KEY ams_AME_TEX_ANIM_KEY = tex_anim.key_buf[work.tex_no];
                    work.set_st( ams_AME_TEX_ANIM_KEY.l, ams_AME_TEX_ANIM_KEY.t, ams_AME_TEX_ANIM_KEY.r, ams_AME_TEX_ANIM_KEY.b );
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        work.set_st( work.st.z, work.st.y, work.st.x, work.st.w );
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        work.set_st( work.st.x, work.st.w, work.st.z, work.st.y );
                    }
                }
                else if ( ( ams_AME_NODE_PLANE.flag & 16384U ) != 0U )
                {
                    float num11 = ams_AME_NODE_PLANE.scroll_u * AppMain._am_unit_time;
                    float num12 = ams_AME_NODE_PLANE.scroll_v * AppMain._am_unit_time;
                    if ( ( work.flag & 8U ) != 0U )
                    {
                        num11 = -num11;
                    }
                    if ( ( work.flag & 16U ) != 0U )
                    {
                        num12 = -num12;
                    }
                    work.set_st( work.st.x + num11, work.st.y + num12, work.st.z + num11, work.st.w + num12 );
                }
            }
            next = next.next;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        return 0;
    }

    // Token: 0x06001AA3 RID: 6819 RVA: 0x000F1EB8 File Offset: 0x000F00B8
    public static int _amDrawPlane( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_PLANE ams_AME_NODE_PLANE = (AppMain.AMS_AME_NODE_PLANE)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        int ablend = AppMain._amEffectSetDrawMode(ams_AME_RUNTIME, ams_PARAM_DRAW_PRIMITIVE, ams_AME_NODE_PLANE.blend);
        AppMain.SNNS_VECTOR4D snns_VECTOR4D = default(AppMain.SNNS_VECTOR4D);
        float z_bias = ams_AME_NODE_PLANE.z_bias;
        AppMain.amVectorSet( out snns_VECTOR4D, z_bias * AppMain._am_ef_worldViewMtx.M20, z_bias * AppMain._am_ef_worldViewMtx.M21, z_bias * AppMain._am_ef_worldViewMtx.M22 );
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        if ( ( ams_AME_NODE_PLANE.flag & 4096U ) != 0U )
        {
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT((int)(6 * ams_AME_RUNTIME.active_num));
            AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
            int num = nns_PRIM3D_PCT_ARRAY.offset;
            float sortZ = 0f;
            while ( next != active_tail )
            {
                AppMain.AMS_AME_RUNTIME_WORK_PLANE ams_AME_RUNTIME_WORK_PLANE = (AppMain.AMS_AME_RUNTIME_WORK_PLANE)((AppMain.AMS_AME_RUNTIME_WORK)next);
                AppMain.amMatrixPush();
                AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
                float x = ams_AME_RUNTIME_WORK_PLANE.size.x;
                float y = ams_AME_RUNTIME_WORK_PLANE.size.y;
                AppMain.amVectorAdd( ref snns_VECTOR, ams_AME_RUNTIME_WORK_PLANE.position, ref snns_VECTOR4D );
                AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_PLANE.rotate;
                AppMain.amQuatMultiMatrix( ref rotate, ref snns_VECTOR );
                ams_AME_RUNTIME_WORK_PLANE.rotate = rotate;
                sortZ = AppMain.nnDistanceVector( ref snns_VECTOR, AppMain._am_ef_camPos );
                buffer[num].Pos.Assign( -x, y, 0f );
                buffer[num + 1].Pos.Assign( x, y, 0f );
                buffer[num + 2].Pos.Assign( -x, -y, 0f );
                buffer[num + 5].Pos.Assign( x, -y, 0f );
                AppMain.nnTransformVector( ref buffer[num].Pos, mtx, ref buffer[num].Pos );
                AppMain.nnTransformVector( ref buffer[num + 1].Pos, mtx, ref buffer[num + 1].Pos );
                AppMain.nnTransformVector( ref buffer[num + 2].Pos, mtx, ref buffer[num + 2].Pos );
                AppMain.nnTransformVector( ref buffer[num + 5].Pos, mtx, ref buffer[num + 5].Pos );
                buffer[num + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_PLANE.color.r, ams_AME_RUNTIME_WORK_PLANE.color.g, ams_AME_RUNTIME_WORK_PLANE.color.b, ams_AME_RUNTIME_WORK_PLANE.color.a );
                buffer[num].Col = ( buffer[num + 1].Col = ( buffer[num + 2].Col = buffer[num + 5].Col ) );
                buffer[num].Tex.u = ams_AME_RUNTIME_WORK_PLANE.st.x;
                buffer[num].Tex.v = ams_AME_RUNTIME_WORK_PLANE.st.y;
                buffer[num + 1].Tex.u = ams_AME_RUNTIME_WORK_PLANE.st.z;
                buffer[num + 1].Tex.v = ams_AME_RUNTIME_WORK_PLANE.st.y;
                buffer[num + 2].Tex.u = ams_AME_RUNTIME_WORK_PLANE.st.x;
                buffer[num + 2].Tex.v = ams_AME_RUNTIME_WORK_PLANE.st.w;
                buffer[num + 5].Tex.u = ams_AME_RUNTIME_WORK_PLANE.st.z;
                buffer[num + 5].Tex.v = ams_AME_RUNTIME_WORK_PLANE.st.w;
                buffer[num + 3] = buffer[num + 1];
                buffer[num + 4] = buffer[num + 2];
                num += 6;
                AppMain.amMatrixPop();
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = ( int )ams_AME_NODE_PLANE.texture_id;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        else
        {
            AppMain.NNS_PRIM3D_PC[] array = AppMain.amDrawAlloc_NNS_PRIM3D_PC((int)(6 * ams_AME_RUNTIME.active_num));
            int num2 = 0;
            AppMain.NNS_PRIM3D_PC[] vtxPC3D = array;
            float sortZ2 = 0f;
            while ( next != active_tail )
            {
                AppMain.AMS_AME_RUNTIME_WORK_PLANE ams_AME_RUNTIME_WORK_PLANE = (AppMain.AMS_AME_RUNTIME_WORK_PLANE)((AppMain.AMS_AME_RUNTIME_WORK)next);
                AppMain.amMatrixPush();
                AppMain.NNS_MATRIX mtx = AppMain.amMatrixGetCurrent();
                float x2 = ams_AME_RUNTIME_WORK_PLANE.size.x;
                float y2 = ams_AME_RUNTIME_WORK_PLANE.size.y;
                AppMain.amVectorAdd( ref snns_VECTOR, ams_AME_RUNTIME_WORK_PLANE.position, ref snns_VECTOR4D );
                AppMain.NNS_QUATERNION rotate2 = ams_AME_RUNTIME_WORK_PLANE.rotate;
                AppMain.amQuatMultiMatrix( ref rotate2, ref snns_VECTOR );
                ams_AME_RUNTIME_WORK_PLANE.rotate = rotate2;
                sortZ2 = AppMain.nnDistanceVector( ref snns_VECTOR, AppMain._am_ef_camPos );
                array[num2].Pos.Assign( -x2, y2, 0f );
                array[num2 + 1].Pos.Assign( x2, y2, 0f );
                array[num2 + 2].Pos.Assign( -x2, -y2, 0f );
                array[num2 + 5].Pos.Assign( x2, -y2, 0f );
                AppMain.nnTransformVector( ref array[num2].Pos, mtx, ref array[num2].Pos );
                AppMain.nnTransformVector( ref array[num2 + 1].Pos, mtx, ref array[num2 + 1].Pos );
                AppMain.nnTransformVector( ref array[num2 + 2].Pos, mtx, ref array[num2 + 2].Pos );
                AppMain.nnTransformVector( ref array[num2 + 5].Pos, mtx, ref array[num2 + 5].Pos );
                array[num2 + 5].Col = AppMain.AMD_RGBA8888( ams_AME_RUNTIME_WORK_PLANE.color.r, ams_AME_RUNTIME_WORK_PLANE.color.g, ams_AME_RUNTIME_WORK_PLANE.color.b, ams_AME_RUNTIME_WORK_PLANE.color.a );
                array[num2].Col = ( array[num2 + 1].Col = ( array[num2 + 2].Col = array[num2 + 5].Col ) );
                array[num2 + 3] = array[num2 + 1];
                array[num2 + 4] = array[num2 + 2];
                num2 += 6;
                AppMain.amMatrixPop();
                next = next.next;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = vtxPC3D;
            ams_PARAM_DRAW_PRIMITIVE.texlist = ams_AME_RUNTIME.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = -1;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ams_AME_RUNTIME.active_num );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ2;
            AppMain.amDrawPrimitive3D( ams_AME_RUNTIME.ecb.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
        return 0;
    }

    // Token: 0x06001AA4 RID: 6820 RVA: 0x000F26A0 File Offset: 0x000F08A0
    public static int _amInitModel( object p )
    {
        AppMain.AMS_AME_CREATE_PARAM ams_AME_CREATE_PARAM = (AppMain.AMS_AME_CREATE_PARAM)p;
        AppMain.AMS_AME_NODE_MODEL ams_AME_NODE_MODEL = (AppMain.AMS_AME_NODE_MODEL)ams_AME_CREATE_PARAM.node;
        AppMain.AMS_AME_RUNTIME_WORK_MODEL ams_AME_RUNTIME_WORK_MODEL = (AppMain.AMS_AME_RUNTIME_WORK_MODEL)ams_AME_CREATE_PARAM.work;
        ams_AME_RUNTIME_WORK_MODEL.time = -ams_AME_NODE_MODEL.start_time;
        ams_AME_RUNTIME_WORK_MODEL.scale.Assign( ams_AME_NODE_MODEL.scale_start );
        ams_AME_RUNTIME_WORK_MODEL.set_color( ams_AME_NODE_MODEL.color_start.color );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_MODEL.position, ams_AME_CREATE_PARAM.parent_position, ams_AME_CREATE_PARAM.position );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_MODEL.position, ams_AME_NODE_MODEL.translate );
        AppMain.amVectorScale( ams_AME_RUNTIME_WORK_MODEL.velocity, ams_AME_CREATE_PARAM.parent_velocity, ams_AME_NODE_MODEL.inheritance_rate );
        AppMain.amVectorAdd( ams_AME_RUNTIME_WORK_MODEL.velocity, ams_AME_CREATE_PARAM.velocity );
        if ( ( ams_AME_NODE_MODEL.flag & 4U ) != 0U )
        {
            AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
            AppMain.amVectorRandom( nns_VECTOR4D );
            AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_MODEL.rotate;
            AppMain.amQuatRotAxisToQuat( ref rotate, nns_VECTOR4D, AppMain.nnRandom() * 2f * 3.1415927f );
            ams_AME_RUNTIME_WORK_MODEL.rotate = rotate;
        }
        else
        {
            ams_AME_RUNTIME_WORK_MODEL.rotate = ams_AME_NODE_MODEL.rotate;
        }
        if ( ( ams_AME_NODE_MODEL.flag & 8U ) != 0U )
        {
            AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
            AppMain.amVectorRandom( nns_VECTOR4D2 );
            ams_AME_RUNTIME_WORK_MODEL.set_rotate_axis( nns_VECTOR4D2.x, nns_VECTOR4D2.y, nns_VECTOR4D2.z, ams_AME_NODE_MODEL.rotate_axis.w );
        }
        else
        {
            ams_AME_RUNTIME_WORK_MODEL.rotate_axis.Assign( ams_AME_NODE_MODEL.rotate_axis );
        }
        return 0;
    }

    // Token: 0x06001AA5 RID: 6821 RVA: 0x000F2800 File Offset: 0x000F0A00
    public static int _amUpdateModel( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_MODEL ams_AME_NODE_MODEL = (AppMain.AMS_AME_NODE_MODEL)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_RUNTIME_WORK_MODEL work = (AppMain.AMS_AME_RUNTIME_WORK_MODEL)((AppMain.AMS_AME_RUNTIME_WORK)ams_AME_RUNTIME.active_head.next);
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        int transparency = ams_AME_RUNTIME.ecb.transparency;
        float num;
        float num2;
        if ( ams_AME_NODE_MODEL.life >= 0f )
        {
            num = ams_AME_NODE_MODEL.life;
            num2 = 1f / num;
        }
        else
        {
            num = float.MaxValue;
            num2 = 0f;
        }
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorScale( nns_VECTOR4D, ams_AME_NODE_MODEL.scale_start, ams_AME_RUNTIME.ecb.size_rate );
        AppMain.amVectorScale( nns_VECTOR4D2, ams_AME_NODE_MODEL.scale_end, ams_AME_RUNTIME.ecb.size_rate );
        while ( next != active_tail )
        {
            work = ( AppMain.AMS_AME_RUNTIME_WORK_MODEL )( ( AppMain.AMS_AME_RUNTIME_WORK )next );
            work.time += AppMain._am_unit_frame;
            float num3 = work.time * num2;
            AppMain.NNS_VECTOR4D nns_VECTOR4D3 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
            AppMain.amVectorScale( nns_VECTOR4D3, work.velocity, AppMain._am_unit_time );
            AppMain.amVectorAdd( work.position, nns_VECTOR4D3 );
            AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D3 );
            if ( work.time >= num )
            {
                if ( ams_AME_RUNTIME.spawn_runtime != null )
                {
                    AppMain._amCreateSpawnParticle( ams_AME_RUNTIME, work );
                }
                AppMain.amEffectDisconnectLink( ( AppMain.AMS_AME_LIST )work );
                AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME2 = ams_AME_RUNTIME;
                ams_AME_RUNTIME2.active_num -= 1;
                AppMain.amEffectFreeRuntimeWork( work );
            }
            else
            {
                AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
                AppMain.NNS_VECTOR4D nns_VECTOR4D4 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
                AppMain.Vector4D_Buf rotate_axis = work.rotate_axis;
                nns_VECTOR4D4.x = rotate_axis.x;
                nns_VECTOR4D4.y = rotate_axis.y;
                nns_VECTOR4D4.z = rotate_axis.z;
                nns_VECTOR4D4.w = rotate_axis.w;
                AppMain.amQuatRotAxisToQuat( ref nns_QUATERNION, nns_VECTOR4D4, nns_VECTOR4D4.w * AppMain._am_unit_time );
                AppMain.NNS_QUATERNION rotate = work.rotate;
                AppMain.amQuatMulti( ref rotate, ref rotate, ref nns_QUATERNION );
                work.rotate = rotate;
                AppMain.amVectorGetInner( nns_VECTOR4D4, nns_VECTOR4D, nns_VECTOR4D2, num3 );
                work.set_scale( nns_VECTOR4D4 );
                AppMain.AMS_RGBA8888 ams_RGBA;
                AppMain.amEffectLerpColor( out ams_RGBA, ref ams_AME_NODE_MODEL.color_start, ref ams_AME_NODE_MODEL.color_end, num3 );
                ams_RGBA.a = ( byte )( ( int )ams_RGBA.a * transparency >> 8 );
                work.set_color( ams_RGBA.color );
                work.scroll_u += ams_AME_NODE_MODEL.scroll_u * AppMain._am_unit_time;
                work.scroll_v += ams_AME_NODE_MODEL.scroll_v * AppMain._am_unit_time;
                AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D4 );
            }
            next = work.next;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
        return 0;
    }

    // Token: 0x06001AA6 RID: 6822 RVA: 0x000F2A98 File Offset: 0x000F0C98
    public static int _amDrawModel( object r )
    {
        AppMain.AMS_AME_RUNTIME ams_AME_RUNTIME = (AppMain.AMS_AME_RUNTIME)r;
        AppMain.AMS_AME_NODE_MODEL ams_AME_NODE_MODEL = (AppMain.AMS_AME_NODE_MODEL)ams_AME_RUNTIME.node;
        AppMain.AMS_AME_ECB ecb = ams_AME_RUNTIME.ecb;
        AppMain.NNS_RGBA nns_RGBA = default(AppMain.NNS_RGBA);
        int blend = -1;
        if ( ams_AME_RUNTIME.ecb.pObj == null )
        {
            return 0;
        }
        uint num = AppMain._amEffectSetMaterial(ams_AME_RUNTIME, ref blend, ams_AME_NODE_MODEL.blend);
        float z_bias = ams_AME_NODE_MODEL.z_bias;
        AppMain.SNNS_VECTOR4D snns_VECTOR4D;
        AppMain.amVectorSet( out snns_VECTOR4D, z_bias * AppMain._am_ef_worldViewMtx.M20, z_bias * AppMain._am_ef_worldViewMtx.M21, z_bias * AppMain._am_ef_worldViewMtx.M22 );
        AppMain.AMS_AME_LIST active_tail = ams_AME_RUNTIME.active_tail;
        AppMain.AMS_AME_LIST next = ams_AME_RUNTIME.active_head.next;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        while ( next != active_tail )
        {
            AppMain.AMS_AME_RUNTIME_WORK_MODEL ams_AME_RUNTIME_WORK_MODEL = (AppMain.AMS_AME_RUNTIME_WORK_MODEL)((AppMain.AMS_AME_RUNTIME_WORK)next);
            AppMain.amMatrixPush();
            AppMain.SNNS_VECTOR4D snns_VECTOR4D2;
            AppMain.amVectorAdd( out snns_VECTOR4D2, ams_AME_RUNTIME_WORK_MODEL.position, ref snns_VECTOR4D );
            AppMain.NNS_QUATERNION rotate = ams_AME_RUNTIME_WORK_MODEL.rotate;
            AppMain.amQuatMultiMatrix( ref rotate, ref snns_VECTOR4D2 );
            ams_AME_RUNTIME_WORK_MODEL.rotate = rotate;
            float num2 = ams_AME_RUNTIME_WORK_MODEL.scroll_u;
            float num3 = ams_AME_RUNTIME_WORK_MODEL.scroll_v;
            num |= 268435456U;
            if ( num2 >= 1f )
            {
                num2 -= ( float )( ( int )num2 );
            }
            else
            {
                while ( num2 < 0f )
                {
                    num2 += 1f;
                }
            }
            if ( num3 >= 1f )
            {
                num3 -= ( float )( ( int )num3 );
            }
            else
            {
                while ( num3 < 0f )
                {
                    num3 += 1f;
                }
            }
            num |= 3145728U;
            nns_RGBA.a = ( float )ams_AME_RUNTIME_WORK_MODEL.color.a * 0.003921569f;
            nns_RGBA.r = ( float )ams_AME_RUNTIME_WORK_MODEL.color.r * 0.003921569f;
            nns_RGBA.g = ( float )ams_AME_RUNTIME_WORK_MODEL.color.g * 0.003921569f;
            nns_RGBA.b = ( float )ams_AME_RUNTIME_WORK_MODEL.color.b * 0.003921569f;
            AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.amMatrixGetCurrent();
            nns_MATRIX.Assign( nns_MATRIX2 );
            AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, ams_AME_RUNTIME_WORK_MODEL.scale.x, ams_AME_RUNTIME_WORK_MODEL.scale.y, ams_AME_RUNTIME_WORK_MODEL.scale.z );
            AppMain.nnCopyMatrix( nns_MATRIX2, nns_MATRIX );
            nns_VECTOR.x = ams_AME_RUNTIME_WORK_MODEL.scale.x;
            nns_VECTOR.y = ams_AME_RUNTIME_WORK_MODEL.scale.y;
            nns_VECTOR.z = ams_AME_RUNTIME_WORK_MODEL.scale.z;
            AppMain.amDrawObjectSetMaterial( ams_AME_RUNTIME.ecb.drawObjState, ecb.pObj, ams_AME_RUNTIME.texlist, nns_VECTOR, ref nns_RGBA, num2, num3, blend, num );
            ams_AME_RUNTIME_WORK_MODEL.set_scale( nns_VECTOR );
            AppMain.amMatrixPop();
            next = ams_AME_RUNTIME_WORK_MODEL.next;
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
        return 0;
    }

    // Token: 0x06001AA7 RID: 6823 RVA: 0x000F2D60 File Offset: 0x000F0F60
    public static void _amApplyGravity( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.AMS_AME_NODE_GRAVITY ams_AME_NODE_GRAVITY = (AppMain.AMS_AME_NODE_GRAVITY)node;
        float am_unit_time = AppMain._am_unit_time;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorCopy( nns_VECTOR4D2, ams_AME_NODE_GRAVITY.direction );
        if ( ( ams_AME_NODE_GRAVITY.flag & 2U ) != 0U )
        {
            AppMain.amQuatMultiVector( nns_VECTOR4D2, nns_VECTOR4D2, ref ecb.rotate, null );
        }
        AppMain.amVectorScale( nns_VECTOR4D, nns_VECTOR4D2, ams_AME_NODE_GRAVITY.magnitude * am_unit_time * am_unit_time * 0.5f );
        AppMain.amVectorAdd( work.position, nns_VECTOR4D );
        AppMain.amVectorScale( nns_VECTOR4D, nns_VECTOR4D2, ams_AME_NODE_GRAVITY.magnitude * am_unit_time );
        AppMain.amVectorAdd( work.velocity, nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
    }

    // Token: 0x06001AA8 RID: 6824 RVA: 0x000F2DF4 File Offset: 0x000F0FF4
    public static void _amApplyUniform( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.AMS_AME_NODE_UNIFORM ams_AME_NODE_UNIFORM = (AppMain.AMS_AME_NODE_UNIFORM)node;
        float am_unit_time = AppMain._am_unit_time;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorScale( nns_VECTOR4D, ams_AME_NODE_UNIFORM.direction, ams_AME_NODE_UNIFORM.magnitude * am_unit_time );
        if ( ( ams_AME_NODE_UNIFORM.flag & 2U ) != 0U )
        {
            AppMain.amQuatMultiVector( nns_VECTOR4D, nns_VECTOR4D, ref ecb.rotate, null );
        }
        AppMain.amVectorAdd( work.position, nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
    }

    // Token: 0x06001AA9 RID: 6825 RVA: 0x000F2E54 File Offset: 0x000F1054
    public static void _amApplyRadial( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.AMS_AME_NODE_RADIAL ams_AME_NODE_RADIAL = (AppMain.AMS_AME_NODE_RADIAL)node;
        float am_unit_time = AppMain._am_unit_time;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorCopy( nns_VECTOR4D2, ams_AME_NODE_RADIAL.position );
        if ( ( ams_AME_NODE_RADIAL.flag & 1U ) != 0U )
        {
            AppMain.amVectorAdd( nns_VECTOR4D2, ecb.translate );
        }
        AppMain.amVectorSub( nns_VECTOR4D, work.position, nns_VECTOR4D2 );
        float num = 1f / (float)Math.Pow((double)AppMain.amVectorScalor(nns_VECTOR4D), (double)ams_AME_NODE_RADIAL.attenuation);
        AppMain.amVectorScaleUnit( nns_VECTOR4D, nns_VECTOR4D, ams_AME_NODE_RADIAL.magnitude * num * am_unit_time );
        AppMain.amVectorAdd( work.position, nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
    }

    // Token: 0x06001AAA RID: 6826 RVA: 0x000F2EF4 File Offset: 0x000F10F4
    public static void _amApplyVortex( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.AMS_AME_NODE_VORTEX ams_AME_NODE_VORTEX = (AppMain.AMS_AME_NODE_VORTEX)node;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D3 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D4 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorCopy( nns_VECTOR4D, ams_AME_NODE_VORTEX.position );
        AppMain.amVectorCopy( nns_VECTOR4D3, ams_AME_NODE_VORTEX.axis );
        if ( ( ams_AME_NODE_VORTEX.flag & 1U ) != 0U )
        {
            AppMain.amVectorAdd( nns_VECTOR4D, ecb.translate );
        }
        if ( ( ams_AME_NODE_VORTEX.flag & 2U ) != 0U )
        {
            AppMain.amQuatMultiVector( nns_VECTOR4D3, nns_VECTOR4D3, ref ecb.rotate, null );
        }
        AppMain.amVectorSub( nns_VECTOR4D2, work.position, nns_VECTOR4D );
        AppMain.amVectorOuterProduct( nns_VECTOR4D4, nns_VECTOR4D3, nns_VECTOR4D2 );
        AppMain.amVectorScale( nns_VECTOR4D2, nns_VECTOR4D4, AppMain._am_unit_time );
        AppMain.amVectorAdd( work.velocity, nns_VECTOR4D2 );
        AppMain.amVectorOuterProduct( nns_VECTOR4D4, nns_VECTOR4D3, nns_VECTOR4D4 );
        AppMain.amVectorScale( nns_VECTOR4D2, nns_VECTOR4D4, AppMain._am_unit_time );
        AppMain.amVectorAdd( work.velocity, nns_VECTOR4D2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D3 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D4 );
    }

    // Token: 0x06001AAB RID: 6827 RVA: 0x000F2FD4 File Offset: 0x000F11D4
    public static void _amApplyDrag( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.AMS_AME_NODE_DRAG ams_AME_NODE_DRAG = (AppMain.AMS_AME_NODE_DRAG)node;
        float am_unit_time = AppMain._am_unit_time;
        AppMain.NNS_VECTOR4D nns_VECTOR4D = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D2 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.NNS_VECTOR4D nns_VECTOR4D3 = AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Alloc();
        AppMain.amVectorCopy( nns_VECTOR4D3, ams_AME_NODE_DRAG.position );
        if ( ( ams_AME_NODE_DRAG.flag & 1U ) != 0U )
        {
            AppMain.amVectorAdd( nns_VECTOR4D3, ecb.translate );
        }
        AppMain.amVectorSub( nns_VECTOR4D2, work.position, nns_VECTOR4D3 );
        AppMain.amVectorUnit( nns_VECTOR4D2 );
        AppMain.amVectorScale( nns_VECTOR4D, nns_VECTOR4D2, ams_AME_NODE_DRAG.magnitude * am_unit_time * am_unit_time * 0.5f );
        AppMain.amVectorAdd( work.position, nns_VECTOR4D );
        AppMain.amVectorScale( nns_VECTOR4D, nns_VECTOR4D2, ams_AME_NODE_DRAG.magnitude * am_unit_time );
        AppMain.amVectorAdd( work.velocity, nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR4D>.Release( nns_VECTOR4D3 );
    }

    // Token: 0x06001AAC RID: 6828 RVA: 0x000F308C File Offset: 0x000F128C
    public static void _amApplyNoise( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work )
    {
        AppMain.AMS_AME_NODE_NOISE ams_AME_NODE_NOISE = (AppMain.AMS_AME_NODE_NOISE)node;
        float num = ams_AME_NODE_NOISE.magnitude * AppMain._am_unit_time;
        AppMain.SNNS_VECTOR4D snns_VECTOR4D;
        snns_VECTOR4D.x = ( AppMain.nnRandom() - 0.5f ) * num * ams_AME_NODE_NOISE.axis.x;
        snns_VECTOR4D.y = ( AppMain.nnRandom() - 0.5f ) * num * ams_AME_NODE_NOISE.axis.y;
        snns_VECTOR4D.z = ( AppMain.nnRandom() - 0.5f ) * num * ams_AME_NODE_NOISE.axis.z;
        snns_VECTOR4D.w = 1f;
        AppMain.amVectorAdd( work.position, ref snns_VECTOR4D );
    }

    // Token: 0x06001AAD RID: 6829 RVA: 0x000F3126 File Offset: 0x000F1326
    public static void amEffectDelete( AppMain.AMS_AME_ECB ecb )
    {
        ecb.entry_num = -1;
    }
}