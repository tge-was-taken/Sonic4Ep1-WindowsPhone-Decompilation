using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;

public partial class AppMain
{
    // Token: 0x02000026 RID: 38
    // (Invoke) Token: 0x06001D23 RID: 7459
    public delegate int AMTREffectProc( AppMain.AMS_TRAIL_EFFECT pEffect );

    // Token: 0x02000027 RID: 39
    public class AMS_TRAIL_EFFECT
    {
        // Token: 0x06001D26 RID: 7462 RVA: 0x00136DB0 File Offset: 0x00134FB0
        public void Clear()
        {
            this.pNext = null;
            this.pPrev = null;
            this.Procedure = null;
            this.Destractor = null;
            this.fFrame = ( this.fEndFrame = 0f );
            this.drawState = 0U;
            this.handleId = 0;
            this.flag = 0;
            this.Work.Clear();
        }

        // Token: 0x040047C5 RID: 18373
        public AppMain.AMS_TRAIL_EFFECT pNext;

        // Token: 0x040047C6 RID: 18374
        public AppMain.AMS_TRAIL_EFFECT pPrev;

        // Token: 0x040047C7 RID: 18375
        public DoubleType<AppMain.AMTREffectProc, int> Procedure;

        // Token: 0x040047C8 RID: 18376
        public DoubleType<AppMain.AMTREffectProc, int> Destractor;

        // Token: 0x040047C9 RID: 18377
        public float fFrame;

        // Token: 0x040047CA RID: 18378
        public float fEndFrame;

        // Token: 0x040047CB RID: 18379
        public uint drawState;

        // Token: 0x040047CC RID: 18380
        public ushort handleId;

        // Token: 0x040047CD RID: 18381
        public short flag;

        // Token: 0x040047CE RID: 18382
        public AppMain.AMS_TRAIL_PARAM Work = new AppMain.AMS_TRAIL_PARAM();
    }

    // Token: 0x02000028 RID: 40
    public class AMS_TRAIL_PARAM
    {
        // Token: 0x1700006B RID: 107
        // (get) Token: 0x06001D28 RID: 7464 RVA: 0x00136E2A File Offset: 0x0013502A
        public AppMain.VecFx32 trail_pos
        {
            get
            {
                return this.trail_obj_work.pos;
            }
        }

        // Token: 0x06001D29 RID: 7465 RVA: 0x00136E38 File Offset: 0x00135038
        public void Clear()
        {
            this.startColor.Clear();
            this.endColor.Clear();
            this.ptclColor.Clear();
            this.startSize = ( this.endSize = 0f );
            this.trail_obj_work = null;
            this.texlist = null;
            this.texId = 0;
            this.life = ( this.vanish_time = ( this.zBias = 0f ) );
            this.ptclSize = 0f;
            this.partsNum = ( this.ptclFlag = ( this.ptclTexId = ( this.blendType = ( this.zTest = ( this.zMask = 0 ) ) ) ) );
            this.time = ( this.vanish_rate = 0f );
            this.trailId = ( this.trailPartsId = ( this.trailPartsNum = ( this.state = 0 ) ) );
            this.list_no = 0;
        }

        // Token: 0x06001D2A RID: 7466 RVA: 0x00136F38 File Offset: 0x00135138
        public AppMain.AMS_TRAIL_PARAM Assign( AppMain.AMS_TRAIL_PARAM source )
        {
            if ( this == source )
            {
                return this;
            }
            this.startColor = source.startColor;
            this.endColor = source.endColor;
            this.ptclColor = source.ptclColor;
            this.startSize = source.startSize;
            this.endSize = source.endSize;
            this.trail_obj_work = source.trail_obj_work;
            this.texlist = source.texlist;
            this.texId = source.texId;
            this.life = source.life;
            this.vanish_time = source.vanish_time;
            this.zBias = source.zBias;
            this.ptclSize = source.ptclSize;
            this.partsNum = source.partsNum;
            this.ptclFlag = source.ptclFlag;
            this.ptclTexId = source.ptclTexId;
            this.blendType = source.blendType;
            this.zTest = source.zTest;
            this.zMask = source.zMask;
            this.time = source.time;
            this.vanish_rate = source.vanish_rate;
            this.trailId = source.trailId;
            this.trailPartsId = source.trailPartsId;
            this.trailPartsNum = source.trailPartsNum;
            this.state = source.state;
            this.list_no = source.list_no;
            return this;
        }

        // Token: 0x040047CF RID: 18383
        public AppMain.NNS_RGBA startColor;

        // Token: 0x040047D0 RID: 18384
        public AppMain.NNS_RGBA endColor;

        // Token: 0x040047D1 RID: 18385
        public AppMain.NNS_RGBA ptclColor;

        // Token: 0x040047D2 RID: 18386
        public float startSize;

        // Token: 0x040047D3 RID: 18387
        public float endSize;

        // Token: 0x040047D4 RID: 18388
        public AppMain.OBS_OBJECT_WORK trail_obj_work;

        // Token: 0x040047D5 RID: 18389
        public AppMain.NNS_TEXLIST texlist;

        // Token: 0x040047D6 RID: 18390
        public int texId;

        // Token: 0x040047D7 RID: 18391
        public float life;

        // Token: 0x040047D8 RID: 18392
        public float vanish_time;

        // Token: 0x040047D9 RID: 18393
        public float zBias;

        // Token: 0x040047DA RID: 18394
        public float ptclSize;

        // Token: 0x040047DB RID: 18395
        public short partsNum;

        // Token: 0x040047DC RID: 18396
        public short ptclFlag;

        // Token: 0x040047DD RID: 18397
        public short ptclTexId;

        // Token: 0x040047DE RID: 18398
        public short blendType;

        // Token: 0x040047DF RID: 18399
        public short zTest;

        // Token: 0x040047E0 RID: 18400
        public short zMask;

        // Token: 0x040047E1 RID: 18401
        public float time;

        // Token: 0x040047E2 RID: 18402
        public float vanish_rate;

        // Token: 0x040047E3 RID: 18403
        public short trailId;

        // Token: 0x040047E4 RID: 18404
        public short trailPartsId;

        // Token: 0x040047E5 RID: 18405
        public short trailPartsNum;

        // Token: 0x040047E6 RID: 18406
        public short state;

        // Token: 0x040047E7 RID: 18407
        public short list_no;
    }

    // Token: 0x02000029 RID: 41
    public class AMS_TRAIL_PARTS
    {
        // Token: 0x06001D2C RID: 7468 RVA: 0x00137080 File Offset: 0x00135280
        public void Clear()
        {
            this.pos.Clear();
            this.sub_pos.Clear();
            this.dir.Clear();
            this.time = 0f;
            this.pNext = null;
            this.pPrev = null;
            this.m_Flag = 0U;
            this.partsId = 0;
            Array.Clear( this.Dummy, 0, this.Dummy.Length );
        }

        // Token: 0x040047E8 RID: 18408
        public readonly AppMain.NNS_VECTOR pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047E9 RID: 18409
        public readonly AppMain.NNS_VECTOR sub_pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047EA RID: 18410
        public readonly AppMain.NNS_VECTOR dir = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047EB RID: 18411
        public float time;

        // Token: 0x040047EC RID: 18412
        public AppMain.AMS_TRAIL_PARTS pNext;

        // Token: 0x040047ED RID: 18413
        public AppMain.AMS_TRAIL_PARTS pPrev;

        // Token: 0x040047EE RID: 18414
        public uint m_Flag;

        // Token: 0x040047EF RID: 18415
        public short partsId;

        // Token: 0x040047F0 RID: 18416
        public ushort[] Dummy = new ushort[5];
    }

    // Token: 0x0200002A RID: 42
    public class AMS_TRAIL_PARTSDATA
    {
        // Token: 0x06001D2E RID: 7470 RVA: 0x00137120 File Offset: 0x00135320
        public void Clear()
        {
            foreach ( AppMain.AMS_TRAIL_PARTS ams_TRAIL_PARTS in this.parts )
            {
                ams_TRAIL_PARTS.Clear();
            }
            this.trailHead.Clear();
            this.trailTail.Clear();
        }

        // Token: 0x040047F1 RID: 18417
        public AppMain.AMS_TRAIL_PARTS[] parts = AppMain.New<AppMain.AMS_TRAIL_PARTS>(64);

        // Token: 0x040047F2 RID: 18418
        public AppMain.AMS_TRAIL_PARTS trailHead = new AppMain.AMS_TRAIL_PARTS();

        // Token: 0x040047F3 RID: 18419
        public AppMain.AMS_TRAIL_PARTS trailTail = new AppMain.AMS_TRAIL_PARTS();
    }

    // Token: 0x0200002B RID: 43
    public class AMS_TRAIL_INTERFACE
    {
        // Token: 0x040047F4 RID: 18420
        public AppMain.AMS_TRAIL_PARTSDATA[] trailData = AppMain.New<AppMain.AMS_TRAIL_PARTSDATA>(8);

        // Token: 0x040047F5 RID: 18421
        public AppMain.AMS_TRAIL_EFFECT[] trailEffect = new AppMain.AMS_TRAIL_EFFECT[8];

        // Token: 0x040047F6 RID: 18422
        public short trailId;

        // Token: 0x040047F7 RID: 18423
        public short trailNum;

        // Token: 0x040047F8 RID: 18424
        public short trailState;
    }

    // Token: 0x0200002C RID: 44
    public class AMTRS_FC_PARAM
    {
        // Token: 0x040047F9 RID: 18425
        public float[] m_x = new float[4];

        // Token: 0x040047FA RID: 18426
        public float[] m_y = new float[4];

        // Token: 0x040047FB RID: 18427
        public float[] m_z = new float[4];

        // Token: 0x040047FC RID: 18428
        public float[] m_Dx = new float[4];

        // Token: 0x040047FD RID: 18429
        public float[] m_Dy = new float[4];

        // Token: 0x040047FE RID: 18430
        public float[] m_Dz = new float[4];

        // Token: 0x040047FF RID: 18431
        public AppMain.NNS_VECTOR4D m_CalcParam = new AppMain.NNS_VECTOR4D();

        // Token: 0x04004800 RID: 18432
        public float m_t;

        // Token: 0x04004801 RID: 18433
        public uint m_flag;
    }

    // Token: 0x06000025 RID: 37 RVA: 0x00002822 File Offset: 0x00000A22
    private static float AMD_FX32_TO_FLOAT( int a )
    {
        return ( float )a / 4096f;
    }

    // Token: 0x06000026 RID: 38 RVA: 0x0000282C File Offset: 0x00000A2C
    private static float AMD_FX32_TO_FLOAT( float a )
    {
        return a / 4096f;
    }

    // Token: 0x06000027 RID: 39 RVA: 0x00002836 File Offset: 0x00000A36
    public void xFFFFFF( object pFake )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000028 RID: 40 RVA: 0x00002840 File Offset: 0x00000A40
    private void amTrailEFInitialize()
    {
        AppMain._amTrailEF_head.Clear();
        AppMain._amTrailEF_tail.Clear();
        AppMain._amTrailEF_head.pNext = AppMain._amTrailEF_tail;
        AppMain._amTrailEF_head.pPrev = null;
        AppMain._amTrailEF_tail.pNext = null;
        AppMain._amTrailEF_tail.pPrev = AppMain._amTrailEF_head;
        AppMain._amTrailEF_alloc = 0;
        AppMain._amTrailEF_free = 0;
        for ( int i = 0; i < 8; i++ )
        {
            AppMain._amTrailEF_buf[i].Clear();
            AppMain._amTrailEF_ref[i] = AppMain._amTrailEF_buf[i];
        }
    }

    // Token: 0x06000029 RID: 41 RVA: 0x000028C8 File Offset: 0x00000AC8
    private static void amTrailEFUpdate( ushort handleId )
    {
        for ( AppMain.AMS_TRAIL_EFFECT pNext = AppMain._amTrailEF_head.pNext; pNext != AppMain._amTrailEF_tail; pNext = pNext.pNext )
        {
            if ( pNext.Procedure != null && ( pNext.handleId & handleId ) != 0 && pNext.Procedure != -1 )
            {
                ( ( AppMain.AMTREffectProc )pNext.Procedure )( pNext );
                AppMain.AMS_TRAIL_PARAM work = pNext.Work;
                if ( ( ( int )work.state & 32768 ) != 0 )
                {
                    AppMain._amTrailEFDelete( pNext );
                }
                else
                {
                    pNext.fFrame += AppMain.amEffectGetUnitFrame();
                    if ( pNext.fEndFrame > 0f && pNext.fFrame > pNext.fEndFrame )
                    {
                        AppMain._amTrailEFDelete( pNext );
                    }
                }
            }
        }
        for ( AppMain.AMS_TRAIL_EFFECT pNext = AppMain._amTrailEF_head.pNext; pNext != AppMain._amTrailEF_tail; pNext = pNext.pNext )
        {
            if ( pNext.Procedure == -1 )
            {
                AppMain._amTrailEFDeleteEffectReal( pNext );
            }
        }
    }

    // Token: 0x0600002A RID: 42 RVA: 0x000029C0 File Offset: 0x00000BC0
    private static void amTrailEFDraw( ushort handleId, AppMain.NNS_TEXLIST texlist, uint state )
    {
        for ( AppMain.AMS_TRAIL_EFFECT pNext = AppMain._amTrailEF_head.pNext; pNext != AppMain._amTrailEF_tail; pNext = pNext.pNext )
        {
            if ( pNext.Procedure != null && ( pNext.handleId & handleId ) != 0 && pNext.Procedure != -1 )
            {
                pNext.drawState = state;
                AppMain.AMS_TRAIL_PARAM work = pNext.Work;
                work.texlist = texlist;
                AppMain._amTrailDrawNormal( pNext );
            }
        }
    }

    // Token: 0x0600002B RID: 43 RVA: 0x00002A34 File Offset: 0x00000C34
    private static void amTrailEFDeleteGroup( ushort handleId )
    {
        for ( AppMain.AMS_TRAIL_EFFECT pNext = AppMain._amTrailEF_head.pNext; pNext != AppMain._amTrailEF_tail; pNext = pNext.pNext )
        {
            if ( ( pNext.handleId & handleId ) != 0 )
            {
                AppMain._amTrailEFDelete( pNext );
            }
        }
    }

    // Token: 0x0600002C RID: 44 RVA: 0x00002A70 File Offset: 0x00000C70
    private static void amTrailEFOffsetPos( ushort handleId, AppMain.NNS_VECTOR offset )
    {
        for ( AppMain.AMS_TRAIL_EFFECT pNext = AppMain._amTrailEF_head.pNext; pNext != AppMain._amTrailEF_tail; pNext = pNext.pNext )
        {
            if ( ( pNext.handleId & handleId ) != 0 )
            {
                AppMain._amTrailAddPosition( pNext, offset );
            }
        }
    }

    // Token: 0x0600002D RID: 45 RVA: 0x00002AAC File Offset: 0x00000CAC
    private static void amTrailMakeEffect( AppMain.AMS_TRAIL_PARAM param, ushort handleId, short flag )
    {
        AppMain.AMS_TRAIL_INTERFACE ams_TRAIL_INTERFACE = AppMain.pTr;
        ams_TRAIL_INTERFACE.trailNum += 1;
        AppMain.AMS_TRAIL_EFFECT ams_TRAIL_EFFECT = AppMain._amTrailEFMake(handleId);
        if ( ams_TRAIL_EFFECT == null )
        {
            return;
        }
        ams_TRAIL_EFFECT.Procedure = new AppMain.AMTREffectProc( AppMain._amTrailUpdateNormal );
        ams_TRAIL_EFFECT.Destractor = new AppMain.AMTREffectProc( AppMain._amTrailFinalizeNormal );
        ams_TRAIL_EFFECT.fEndFrame = -1f;
        ams_TRAIL_EFFECT.flag = flag;
        AppMain.AMS_TRAIL_PARAM ams_TRAIL_PARAM = ams_TRAIL_EFFECT.Work;
        ams_TRAIL_PARAM = ams_TRAIL_PARAM.Assign( param );
        ams_TRAIL_PARAM.time = ams_TRAIL_PARAM.life * AppMain.amEffectGetUnitFrame();
        ams_TRAIL_PARAM.trailId = AppMain.pTr.trailId;
        if ( AppMain.pTr.trailEffect[( int )ams_TRAIL_PARAM.trailId] != null )
        {
            AppMain._amTrailEFDelete( AppMain.pTr.trailEffect[( int )ams_TRAIL_PARAM.trailId] );
        }
        AppMain.pTr.trailEffect[( int )ams_TRAIL_PARAM.trailId] = ams_TRAIL_EFFECT;
        AppMain._amTrailInitNormal( ams_TRAIL_EFFECT );
        AppMain.AMS_TRAIL_INTERFACE ams_TRAIL_INTERFACE2 = AppMain.pTr;
        ams_TRAIL_INTERFACE2.trailId += 1;
        if ( AppMain.pTr.trailId >= 8 )
        {
            AppMain.pTr.trailId = 0;
        }
    }

    // Token: 0x0600002E RID: 46 RVA: 0x00002BB4 File Offset: 0x00000DB4
    private static void _amTrailEFDelete( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        pEffect.Procedure = -1;
        if ( pEffect.Destractor != null && pEffect.Destractor != -1 )
        {
            ( ( AMTREffectProc )pEffect.Destractor )( pEffect );
        }
    }

    // Token: 0x0600002F RID: 47 RVA: 0x00002C08 File Offset: 0x00000E08
    private static AppMain.AMS_TRAIL_EFFECT _amTrailEFMake( ushort handleId )
    {
        AppMain.AMS_TRAIL_EFFECT ams_TRAIL_EFFECT = AppMain._amTrailEFAlloc();
        if ( ams_TRAIL_EFFECT == null )
        {
            return null;
        }
        AppMain._amTrailEF_tail.pPrev.pNext = ams_TRAIL_EFFECT;
        ams_TRAIL_EFFECT.pPrev = AppMain._amTrailEF_tail.pPrev;
        AppMain._amTrailEF_tail.pPrev = ams_TRAIL_EFFECT;
        ams_TRAIL_EFFECT.pNext = AppMain._amTrailEF_tail;
        ams_TRAIL_EFFECT.handleId = handleId;
        return ams_TRAIL_EFFECT;
    }

    // Token: 0x06000030 RID: 48 RVA: 0x00002C60 File Offset: 0x00000E60
    private static AppMain.AMS_TRAIL_EFFECT _amTrailEFAlloc()
    {
        AppMain.AMS_TRAIL_EFFECT ams_TRAIL_EFFECT = AppMain._amTrailEF_ref[AppMain._amTrailEF_alloc];
        AppMain._amTrailEF_alloc++;
        if ( AppMain._amTrailEF_alloc >= 8 )
        {
            AppMain._amTrailEF_alloc = 0;
        }
        ams_TRAIL_EFFECT.Clear();
        return ams_TRAIL_EFFECT;
    }

    // Token: 0x06000031 RID: 49 RVA: 0x00002C9A File Offset: 0x00000E9A
    private static void _amTrailEFFree( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        AppMain._amTrailEF_ref[AppMain._amTrailEF_free] = pEffect;
        AppMain._amTrailEF_free++;
        if ( AppMain._amTrailEF_free >= 8 )
        {
            AppMain._amTrailEF_free = 0;
        }
    }

    // Token: 0x06000032 RID: 50 RVA: 0x00002CC2 File Offset: 0x00000EC2
    private static void _amTrailEFDeleteEffectReal( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        pEffect.pPrev.pNext = pEffect.pNext;
        pEffect.pNext.pPrev = pEffect.pPrev;
        AppMain._amTrailEFFree( pEffect );
    }

    // Token: 0x06000033 RID: 51 RVA: 0x00002CEC File Offset: 0x00000EEC
    private static void _amTrailInitNormal( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        AppMain.AMS_TRAIL_PARAM work = pEffect.Work;
        AppMain.AMS_TRAIL_PARTSDATA ams_TRAIL_PARTSDATA = AppMain.pTr.trailData[(int)work.trailId];
        AppMain.AMS_TRAIL_PARTS ams_TRAIL_PARTS = ams_TRAIL_PARTSDATA.parts[0];
        AppMain.AMS_TRAIL_PARTS trailTail = ams_TRAIL_PARTSDATA.trailTail;
        AppMain.AMS_TRAIL_PARTS trailHead = ams_TRAIL_PARTSDATA.trailHead;
        ams_TRAIL_PARTSDATA.Clear();
        ams_TRAIL_PARTS.pNext = trailTail;
        trailTail.pPrev = ams_TRAIL_PARTS;
        ams_TRAIL_PARTS.pPrev = trailHead;
        trailHead.pNext = ams_TRAIL_PARTS;
        if ( ( pEffect.flag & 1 ) != 0 )
        {
            ams_TRAIL_PARTS.pos.x = AppMain.AMD_FX32_TO_FLOAT( work.trail_pos.x );
            ams_TRAIL_PARTS.pos.y = -AppMain.AMD_FX32_TO_FLOAT( work.trail_pos.y );
            ams_TRAIL_PARTS.pos.z = AppMain.AMD_FX32_TO_FLOAT( work.zBias );
        }
        else
        {
            ams_TRAIL_PARTS.pos.x = MppBitConverter.Int32ToSingle( work.trail_pos.x );
            ams_TRAIL_PARTS.pos.y = MppBitConverter.Int32ToSingle( work.trail_pos.y );
            ams_TRAIL_PARTS.pos.z = MppBitConverter.Int32ToSingle( work.trail_pos.z );
        }
        ams_TRAIL_PARTS.time = work.life;
        ams_TRAIL_PARTS.partsId = 0;
        work.trailPartsId = 1;
        AppMain.AMS_TRAIL_PARAM ams_TRAIL_PARAM = work;
        ams_TRAIL_PARAM.trailPartsNum += 1;
    }

    // Token: 0x06000034 RID: 52 RVA: 0x00002E24 File Offset: 0x00001024
    private static int _amTrailFinalizeNormal( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        AppMain.AMS_TRAIL_PARAM work = pEffect.Work;
        if ( AppMain.pTr.trailNum > 0 )
        {
            AppMain.AMS_TRAIL_INTERFACE ams_TRAIL_INTERFACE = AppMain.pTr;
            ams_TRAIL_INTERFACE.trailNum -= 1;
            if ( AppMain.pTr.trailNum == 0 )
            {
                AppMain.AMS_TRAIL_INTERFACE ams_TRAIL_INTERFACE2 = AppMain.pTr;
                ams_TRAIL_INTERFACE2.trailState &= short.MaxValue;
            }
        }
        AppMain.pTr.trailEffect[( int )work.trailId] = null;
        return 0;
    }

    // Token: 0x06000035 RID: 53 RVA: 0x00002E90 File Offset: 0x00001090
    private static int _amTrailUpdateNormal( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        AppMain.AMS_TRAIL_PARAM work = pEffect.Work;
        AppMain.AMS_TRAIL_PARTSDATA ams_TRAIL_PARTSDATA = AppMain.pTr.trailData[(int)work.trailId];
        AppMain.AMS_TRAIL_PARTS ams_TRAIL_PARTS = ams_TRAIL_PARTSDATA.parts[(int)work.trailPartsId];
        AppMain.AMS_TRAIL_PARTS trailTail = ams_TRAIL_PARTSDATA.trailTail;
        AppMain.AMS_TRAIL_PARTS trailHead = ams_TRAIL_PARTSDATA.trailHead;
        if ( ( work.state & -32768 ) != 0 )
        {
            return 1;
        }
        AppMain.AMS_TRAIL_PARTS pPrev = trailTail.pPrev;
        if ( ams_TRAIL_PARTS.pNext != null && ams_TRAIL_PARTS == trailHead.pNext )
        {
            trailHead.pNext.pNext.pPrev = trailHead;
            trailHead.pNext = trailHead.pNext.pNext;
        }
        ams_TRAIL_PARTS.Clear();
        ams_TRAIL_PARTS.pNext = trailTail;
        ams_TRAIL_PARTS.pPrev = trailTail.pPrev;
        trailTail.pPrev = ams_TRAIL_PARTS;
        ams_TRAIL_PARTS.pPrev.pNext = ams_TRAIL_PARTS;
        if ( ( pEffect.flag & 1 ) != 0 )
        {
            ams_TRAIL_PARTS.pos.x = AppMain.AMD_FX32_TO_FLOAT( work.trail_pos.x );
            ams_TRAIL_PARTS.pos.y = -AppMain.AMD_FX32_TO_FLOAT( work.trail_pos.y );
            ams_TRAIL_PARTS.pos.z = AppMain.AMD_FX32_TO_FLOAT( work.zBias );
        }
        else
        {
            ams_TRAIL_PARTS.pos.x = MppBitConverter.Int32ToSingle( work.trail_pos.x );
            ams_TRAIL_PARTS.pos.y = MppBitConverter.Int32ToSingle( work.trail_pos.y );
            ams_TRAIL_PARTS.pos.z = MppBitConverter.Int32ToSingle( work.trail_pos.z );
        }
        AppMain.nnSubtractVector( ams_TRAIL_PARTS.dir, ams_TRAIL_PARTS.pos, ams_TRAIL_PARTS.pPrev.pos );
        if ( AppMain.amIsZerof( ams_TRAIL_PARTS.dir.x ) && AppMain.amIsZerof( ams_TRAIL_PARTS.dir.y ) && AppMain.amIsZerof( ams_TRAIL_PARTS.dir.z ) )
        {
            ams_TRAIL_PARTS.dir.x = 1f;
        }
        AppMain._amTrailAddParts( ams_TRAIL_PARTS, work );
        ams_TRAIL_PARTS.m_Flag |= 1U;
        work.time -= AppMain.amEffectGetUnitFrame();
        if ( work.time < 0f )
        {
            work.time = 0f;
            AppMain.AMS_TRAIL_PARAM ams_TRAIL_PARAM = work;
            ams_TRAIL_PARAM.state |= short.MinValue;
        }
        return 0;
    }

    // Token: 0x06000036 RID: 54 RVA: 0x000030B0 File Offset: 0x000012B0
    private static void _amTrailDrawNormal( AppMain.AMS_TRAIL_EFFECT pEffect )
    {
        AppMain.AMS_TRAIL_PARAM work = pEffect.Work;
        AppMain.AMS_TRAIL_PARTSDATA ams_TRAIL_PARTSDATA = AppMain.pTr.trailData[(int)work.trailId];
        AppMain.AMS_TRAIL_PARTS trailTail = ams_TRAIL_PARTSDATA.trailTail;
        AppMain.AMS_TRAIL_PARTS trailHead = ams_TRAIL_PARTSDATA.trailHead;
        AppMain.AMS_TRAIL_PARTS pPrev = trailTail.pPrev;
        if ( trailTail.pPrev.pPrev == trailHead )
        {
            return;
        }
        if ( work.time <= 0f )
        {
            return;
        }
        AppMain.NNS_RGBA startColor = work.startColor;
        AppMain.NNS_RGBA ptclColor = work.ptclColor;
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        float num = 1f;
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        int ablend = 1;
        AppMain.amDrawGetPrimBlendParam( ( int )work.blendType, ams_PARAM_DRAW_PRIMITIVE );
        if ( work.zTest != 0 )
        {
            ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        }
        if ( work.zMask != 0 )
        {
            ams_PARAM_DRAW_PRIMITIVE.zMask = 1;
        }
        AppMain.amVectorSet( nns_VECTOR3, 0f, 0f, 1f );
        if ( work.time < work.vanish_time )
        {
            num = work.time / work.vanish_time;
        }
        work.vanish_rate = num;
        startColor.a = work.startColor.a * num;
        ptclColor.a = work.ptclColor.a * num;
        float startSize = work.startSize;
        float ptclSize = work.ptclSize;
        if ( work.ptclFlag != 0 && work.ptclTexId != -1 )
        {
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(6);
            AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
            int offset = nns_PRIM3D_PCT_ARRAY.offset;
            float sortZ = AppMain.nnDistanceVector(pPrev.pos, AppMain._am_ef_camPos);
            AppMain.mppAssertNotImpl();
            buffer[offset].Col = AppMain.AMD_FCOLTORGBA8888( ptclColor.r, ptclColor.g, ptclColor.b, ptclColor.a );
            buffer[offset + 1].Col = ( buffer[offset + 2].Col = ( buffer[offset + 5].Col = buffer[offset].Col ) );
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
            ams_PARAM_DRAW_PRIMITIVE.texlist = work.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = ( int )work.ptclTexId;
            ams_PARAM_DRAW_PRIMITIVE.count = 6;
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( pEffect.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        if ( work.trailPartsNum < 3 )
        {
            return;
        }
        if ( work.texlist == null || work.texId == -1 )
        {
            AppMain.NNS_PRIM3D_PC[] array = AppMain.amDrawAlloc_NNS_PRIM3D_PC((int)(6 * (work.trailPartsNum - 1)));
            AppMain.NNS_PRIM3D_PC[] vtxPC3D = array;
            int num2 = 0;
            float sortZ = AppMain.nnDistanceVector(pPrev.pos, AppMain._am_ef_camPos);
            AppMain.nnCrossProductVector( nns_VECTOR, nns_VECTOR3, pPrev.dir );
            AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
            AppMain.nnScaleVector( nns_VECTOR2, nns_VECTOR, startSize );
            AppMain.nnAddVector( ref array[0].Pos, pPrev.pos, nns_VECTOR2 );
            AppMain.nnAddVector( ref array[1].Pos, pPrev.pPrev.pos, nns_VECTOR2 );
            AppMain.nnSubtractVector( ref array[2].Pos, pPrev.pos, nns_VECTOR2 );
            AppMain.nnSubtractVector( ref array[5].Pos, pPrev.pPrev.pos, nns_VECTOR2 );
            array[5].Col = AppMain.AMD_FCOLTORGBA8888( startColor.r, startColor.g, startColor.b, startColor.a );
            array[0].Col = ( array[1].Col = ( array[2].Col = array[5].Col ) );
            array[3] = array[1];
            array[4] = array[2];
            num2 += 6;
            pPrev = pPrev.pPrev;
            work.list_no = 1;
            while ( pPrev != trailHead.pNext )
            {
                AppMain.mppAssertNotImpl();
                pPrev.m_Flag &= 4294967293U;
                AppMain.AMS_TRAIL_PARAM ams_TRAIL_PARAM = work;
                ams_TRAIL_PARAM.list_no += 1;
                AppMain._amTrailDrawPartsNormal( pPrev, work, array, num2 );
                pPrev = pPrev.pPrev;
                num2 += 6;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 2;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPC3D = vtxPC3D;
            ams_PARAM_DRAW_PRIMITIVE.texlist = work.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = work.texId;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ( work.trailPartsNum - 1 ) );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( pEffect.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        else
        {
            AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY2 = AppMain.amDrawAlloc_NNS_PRIM3D_PCT((int)(6 * (work.trailPartsNum - 1)));
            AppMain.NNS_PRIM3D_PCT[] buffer2 = nns_PRIM3D_PCT_ARRAY2.buffer;
            int offset2 = nns_PRIM3D_PCT_ARRAY2.offset;
            int num3 = offset2;
            float num4 = (float)(work.trailPartsNum - 1) / (float)work.trailPartsNum;
            num4 *= work.vanish_rate;
            float sortZ = AppMain.nnDistanceVector(pPrev.pos, AppMain._am_ef_camPos);
            AppMain.nnCrossProductVector( nns_VECTOR, nns_VECTOR3, pPrev.dir );
            AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
            AppMain.nnScaleVector( nns_VECTOR2, nns_VECTOR, startSize );
            AppMain.nnAddVector( ref buffer2[offset2].Pos, pPrev.pos, nns_VECTOR2 );
            AppMain.nnAddVector( ref buffer2[offset2 + 1].Pos, pPrev.pPrev.pos, nns_VECTOR2 );
            AppMain.nnSubtractVector( ref buffer2[offset2 + 2].Pos, pPrev.pos, nns_VECTOR2 );
            AppMain.nnSubtractVector( ref buffer2[offset2 + 5].Pos, pPrev.pPrev.pos, nns_VECTOR2 );
            buffer2[offset2 + 5].Col = AppMain.AMD_FCOLTORGBA8888( startColor.r, startColor.g, startColor.b, startColor.a );
            buffer2[offset2].Col = ( buffer2[offset2 + 1].Col = ( buffer2[offset2 + 2].Col = buffer2[offset2 + 5].Col ) );
            buffer2[offset2].Tex.u = 1f;
            buffer2[offset2].Tex.v = 0f;
            buffer2[offset2 + 1].Tex.u = num4;
            buffer2[offset2 + 1].Tex.v = 0f;
            buffer2[offset2 + 2].Tex.u = 1f;
            buffer2[offset2 + 2].Tex.v = 1f;
            buffer2[offset2 + 5].Tex.u = num4;
            buffer2[offset2 + 5].Tex.v = 1f;
            buffer2[offset2 + 3] = buffer2[offset2 + 1];
            buffer2[offset2 + 4] = buffer2[offset2 + 2];
            num3 += 6;
            pPrev = pPrev.pPrev;
            work.list_no = 1;
            while ( pPrev != trailHead.pNext )
            {
                pPrev.m_Flag &= 4294967293U;
                AppMain.AMS_TRAIL_PARAM ams_TRAIL_PARAM2 = work;
                ams_TRAIL_PARAM2.list_no += 1;
                AppMain._amTrailDrawPartsNormalTex( pPrev, work, buffer2, num3 );
                pPrev = pPrev.pPrev;
                num3 += 6;
            }
            ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
            ams_PARAM_DRAW_PRIMITIVE.type = 0;
            ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY2;
            ams_PARAM_DRAW_PRIMITIVE.texlist = work.texlist;
            ams_PARAM_DRAW_PRIMITIVE.texId = work.texId;
            ams_PARAM_DRAW_PRIMITIVE.count = ( int )( 6 * ( work.trailPartsNum - 1 ) );
            ams_PARAM_DRAW_PRIMITIVE.ablend = ablend;
            ams_PARAM_DRAW_PRIMITIVE.sortZ = sortZ;
            AppMain.amDrawPrimitive3D( pEffect.drawState, ams_PARAM_DRAW_PRIMITIVE );
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
    }

    // Token: 0x06000037 RID: 55 RVA: 0x000039AC File Offset: 0x00001BAC
    private static void _amTrailDrawPartsNormal( AppMain.AMS_TRAIL_PARTS pNow, AppMain.AMS_TRAIL_PARAM work, AppMain.NNS_PRIM3D_PC[] _pv, int pv )
    {
        int num = pv - 6;
        float scale = work.startSize;
        float num2 = (float)(work.trailPartsNum - work.list_no) / (float)work.trailPartsNum;
        scale = work.startSize * num2 + work.endSize * ( 1f - num2 );
        num2 *= work.vanish_rate;
        AppMain.NNS_RGBA nns_RGBA;
        nns_RGBA.r = work.startColor.r * num2 + work.endColor.r * ( 1f - num2 );
        nns_RGBA.g = work.startColor.g * num2 + work.endColor.g * ( 1f - num2 );
        nns_RGBA.b = work.startColor.b * num2 + work.endColor.b * ( 1f - num2 );
        nns_RGBA.a = work.startColor.a * num2 + work.endColor.a * ( 1f - num2 );
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.nnDistanceVector( pNow.pos, AppMain._am_ef_camPos );
        AppMain.amVectorSet( nns_VECTOR3, 0f, 0f, 1f );
        AppMain.nnCrossProductVector( nns_VECTOR, nns_VECTOR3, pNow.dir );
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.nnScaleVector( nns_VECTOR2, nns_VECTOR, scale );
        AppMain.nnAddVector( ref _pv[pv + 1].Pos, pNow.pPrev.pos, nns_VECTOR2 );
        AppMain.nnSubtractVector( ref _pv[pv + 5].Pos, pNow.pPrev.pos, nns_VECTOR2 );
        _pv[pv] = _pv[num + 1];
        _pv[pv + 2] = _pv[num + 5];
        _pv[pv + 4] = _pv[num + 2];
        _pv[pv + 5].Col = AppMain.AMD_FCOLTORGBA8888( nns_RGBA.r, nns_RGBA.g, nns_RGBA.b, nns_RGBA.a );
        _pv[pv + 1].Col = _pv[pv + 5].Col;
        _pv[pv + 3] = _pv[pv + 1];
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
    }

    // Token: 0x06000038 RID: 56 RVA: 0x00003C0C File Offset: 0x00001E0C
    private static void _amTrailDrawPartsNormalTex( AppMain.AMS_TRAIL_PARTS pNow, AppMain.AMS_TRAIL_PARAM work, AppMain.NNS_PRIM3D_PCT[] _pv, int pv )
    {
        int num = pv - 6;
        float scale = work.startSize;
        float num2 = (float)(work.trailPartsNum - work.list_no) / (float)work.trailPartsNum;
        num2 *= work.vanish_rate;
        scale = work.startSize * num2 + work.endSize * ( 1f - num2 );
        AppMain.NNS_RGBA nns_RGBA;
        nns_RGBA.r = work.startColor.r * num2 + work.endColor.r * ( 1f - num2 );
        nns_RGBA.g = work.startColor.g * num2 + work.endColor.g * ( 1f - num2 );
        nns_RGBA.b = work.startColor.b * num2 + work.endColor.b * ( 1f - num2 );
        nns_RGBA.a = work.startColor.a * num2 + work.endColor.a * ( 1f - num2 );
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.nnDistanceVector( pNow.pos, AppMain._am_ef_camPos );
        AppMain.amVectorSet( nns_VECTOR3, 0f, 0f, 1f );
        AppMain.nnCrossProductVector( nns_VECTOR, nns_VECTOR3, pNow.dir );
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.nnScaleVector( nns_VECTOR2, nns_VECTOR, scale );
        AppMain.nnAddVector( ref _pv[pv + 1].Pos, pNow.pPrev.pos, nns_VECTOR2 );
        AppMain.nnSubtractVector( ref _pv[pv + 5].Pos, pNow.pPrev.pos, nns_VECTOR2 );
        _pv[pv] = _pv[num + 1];
        _pv[pv + 2] = _pv[num + 5];
        _pv[pv + 4] = _pv[pv + 2];
        _pv[pv + 5].Col = AppMain.AMD_FCOLTORGBA8888( nns_RGBA.r, nns_RGBA.g, nns_RGBA.b, nns_RGBA.a );
        _pv[pv + 1].Col = _pv[pv + 5].Col;
        _pv[pv + 1].Tex.u = num2;
        _pv[pv + 1].Tex.v = 0f;
        _pv[pv + 5].Tex.u = num2;
        _pv[pv + 5].Tex.v = 1f;
        _pv[pv + 3] = _pv[pv + 1];
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
    }

    // Token: 0x06000039 RID: 57 RVA: 0x00003EC4 File Offset: 0x000020C4
    private static void _amTrailAddParts( AppMain.AMS_TRAIL_PARTS pNew, AppMain.AMS_TRAIL_PARAM work )
    {
        AppMain.AMS_TRAIL_PARTSDATA ams_TRAIL_PARTSDATA = AppMain.pTr.trailData[(int)work.trailId];
        AppMain.AMS_TRAIL_PARTS trailHead = ams_TRAIL_PARTSDATA.trailHead;
        pNew.time = work.life;
        pNew.partsId = work.trailPartsId;
        work.trailPartsId += 1;
        work.trailPartsNum += 1;
        if ( work.trailPartsNum >= work.partsNum )
        {
            work.trailPartsNum = work.partsNum;
            work.trailPartsId = trailHead.pNext.partsId;
        }
        if ( work.trailPartsNum >= 64 )
        {
            work.trailPartsNum = 64;
            work.trailPartsId = trailHead.pNext.partsId;
        }
    }

    // Token: 0x0600003A RID: 58 RVA: 0x00003F70 File Offset: 0x00002170
    private static void _amTrailAddPosition( AppMain.AMS_TRAIL_EFFECT pEffect, AppMain.NNS_VECTOR offset )
    {
        AppMain.AMS_TRAIL_PARAM work = pEffect.Work;
        AppMain.AMS_TRAIL_PARTSDATA ams_TRAIL_PARTSDATA = AppMain.pTr.trailData[(int)work.trailId];
        AppMain.AMS_TRAIL_PARTS trailTail = ams_TRAIL_PARTSDATA.trailTail;
        AppMain.AMS_TRAIL_PARTS trailHead = ams_TRAIL_PARTSDATA.trailHead;
        AppMain.AMS_TRAIL_PARTS pPrev = trailTail.pPrev;
        if ( trailTail.pPrev.pPrev == trailHead )
        {
            return;
        }
        if ( work.time <= 0f )
        {
            return;
        }
        while ( pPrev != trailHead )
        {
            AppMain.nnAddVector( pPrev.pos, pPrev.pos, offset );
            pPrev = pPrev.pPrev;
        }
    }

    // Token: 0x0600003B RID: 59 RVA: 0x00003FEC File Offset: 0x000021EC
    private static int _amTrailCalcSplinePos( AppMain.NNS_VECTOR[] Pos, AppMain.NNS_VECTOR[] Dir, AppMain.AMS_TRAIL_PARTS pNPP, AppMain.AMS_TRAIL_PARTS pNP, AppMain.AMS_TRAIL_PARTS pNow, AppMain.AMS_TRAIL_PARTS pNext, float len, int MaxComp )
    {
        AppMain.AMTRS_FC_PARAM amtrs_FC_PARAM = new AppMain.AMTRS_FC_PARAM();
        amtrs_FC_PARAM.m_flag = 0U;
        if ( pNPP != null )
        {
            amtrs_FC_PARAM.m_x[0] = pNPP.pos.x;
            amtrs_FC_PARAM.m_y[0] = pNPP.pos.y;
            amtrs_FC_PARAM.m_z[0] = pNPP.pos.z;
        }
        else
        {
            amtrs_FC_PARAM.m_flag |= 1U;
        }
        amtrs_FC_PARAM.m_x[1] = pNP.pos.x;
        amtrs_FC_PARAM.m_y[1] = pNP.pos.y;
        amtrs_FC_PARAM.m_z[1] = pNP.pos.z;
        amtrs_FC_PARAM.m_x[2] = pNow.pos.x;
        amtrs_FC_PARAM.m_y[2] = pNow.pos.y;
        amtrs_FC_PARAM.m_z[2] = pNow.pos.z;
        if ( pNext != null )
        {
            amtrs_FC_PARAM.m_x[3] = pNext.pos.x;
            amtrs_FC_PARAM.m_y[3] = pNext.pos.y;
            amtrs_FC_PARAM.m_z[3] = pNext.pos.z;
        }
        else
        {
            amtrs_FC_PARAM.m_flag |= 2U;
        }
        amtrs_FC_PARAM.m_flag |= 512U;
        if ( pNPP != null )
        {
            amtrs_FC_PARAM.m_Dx[0] = pNPP.dir.x;
            amtrs_FC_PARAM.m_Dy[0] = pNPP.dir.y;
            amtrs_FC_PARAM.m_Dz[0] = pNPP.dir.z;
        }
        else
        {
            amtrs_FC_PARAM.m_flag |= 1U;
        }
        amtrs_FC_PARAM.m_Dx[1] = pNP.dir.x;
        amtrs_FC_PARAM.m_Dy[1] = pNP.dir.y;
        amtrs_FC_PARAM.m_Dz[1] = pNP.dir.z;
        amtrs_FC_PARAM.m_Dx[2] = pNow.dir.x;
        amtrs_FC_PARAM.m_Dy[2] = pNow.dir.y;
        amtrs_FC_PARAM.m_Dz[2] = pNow.dir.z;
        if ( pNext != null )
        {
            amtrs_FC_PARAM.m_Dx[3] = pNext.dir.x;
            amtrs_FC_PARAM.m_Dy[3] = pNext.dir.y;
            amtrs_FC_PARAM.m_Dz[3] = pNext.dir.z;
        }
        else
        {
            amtrs_FC_PARAM.m_flag |= 2U;
        }
        amtrs_FC_PARAM.m_flag |= 512U;
        return AppMain._amTrailCalcSplinePos( Pos, Dir, amtrs_FC_PARAM, len, MaxComp );
    }

    // Token: 0x0600003C RID: 60 RVA: 0x00004258 File Offset: 0x00002458
    private static int _amTrailCalcSplinePos( AppMain.NNS_VECTOR[] pos, AppMain.NNS_VECTOR[] dir, AppMain.AMTRS_FC_PARAM FcWk, float len, int MaxComp )
    {
        int num = (int)len;
        num = ( int )AppMain.amClamp( ( float )num, 0f, ( float )MaxComp );
        AppMain._amTrailCalcSpline( FcWk, FcWk.m_x );
        for ( int i = 0; i < num; i++ )
        {
            float t = (float)(i + 1) / (float)(num + 1);
            pos[i].x = AppMain._amTrailGetValue( FcWk, t );
        }
        AppMain._amTrailCalcSpline( FcWk, FcWk.m_y );
        for ( int i = 0; i < num; i++ )
        {
            float t = (float)(i + 1) / (float)(num + 1);
            pos[i].y = AppMain._amTrailGetValue( FcWk, t );
        }
        AppMain._amTrailCalcSpline( FcWk, FcWk.m_z );
        for ( int i = 0; i < num; i++ )
        {
            float t = (float)(i + 1) / (float)(num + 1);
            pos[i].z = AppMain._amTrailGetValue( FcWk, t );
        }
        AppMain._amTrailCalcSpline( FcWk, FcWk.m_Dx );
        for ( int i = 0; i < num; i++ )
        {
            float t = (float)(i + 1) / (float)(num + 1);
            dir[i].x = AppMain._amTrailGetValue( FcWk, t );
        }
        AppMain._amTrailCalcSpline( FcWk, FcWk.m_Dy );
        for ( int i = 0; i < num; i++ )
        {
            float t = (float)(i + 1) / (float)(num + 1);
            dir[i].y = AppMain._amTrailGetValue( FcWk, t );
        }
        AppMain._amTrailCalcSpline( FcWk, FcWk.m_Dz );
        for ( int i = 0; i < num; i++ )
        {
            float t = (float)(i + 1) / (float)(num + 1);
            dir[i].z = AppMain._amTrailGetValue( FcWk, t );
        }
        return num;
    }

    // Token: 0x0600003D RID: 61 RVA: 0x000043A4 File Offset: 0x000025A4
    private static void _amTrailCalcSpline( AppMain.AMTRS_FC_PARAM param, float[] P )
    {
        float num;
        float num2;
        switch ( param.m_flag & 3U )
        {
            case 1U:
                num = ( P[2] - P[1] ) / 4f;
                num2 = ( P[3] - P[1] ) / 1f;
                break;
            case 2U:
                num = ( P[2] - P[0] ) / 1f;
                num2 = ( P[2] - P[1] ) / 4f;
                break;
            default:
                num = ( P[2] - P[0] ) / 2f;
                num2 = ( P[3] - P[1] ) / 2f;
                break;
        }
        param.m_CalcParam.x = 2f * P[1] - 2f * P[2] + num + num2;
        param.m_CalcParam.y = -3f * P[1] + 3f * P[2] - 2f * num - num2;
        param.m_CalcParam.z = num;
        param.m_CalcParam.w = P[1];
        param.m_flag |= 256U;
    }

    // Token: 0x0600003E RID: 62 RVA: 0x000044A8 File Offset: 0x000026A8
    private static float _amTrailGetValue( AppMain.AMTRS_FC_PARAM param, float t )
    {
        float result = 0f;
        if ( ( param.m_flag & 256U ) == 0U )
        {
            return result;
        }
        AppMain.NNS_VECTOR4D calcParam = param.m_CalcParam;
        return t * t * t * calcParam.x + t * t * calcParam.y + t * calcParam.z;
    }
}
