using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public partial class AppMain
{
    // Token: 0x02000035 RID: 53
    // (Invoke) Token: 0x06001D44 RID: 7492
    public delegate void _sts_proc_();

    // Token: 0x02000036 RID: 54
    public class GMS_EVE_MGR_WORK
    {
        // Token: 0x06001D47 RID: 7495 RVA: 0x001372FE File Offset: 0x001354FE
        public void Clear()
        {
            this.sts_proc = null;
            this.flag = 0U;
            Array.Clear( this.prev_pos, 0, 2 );
            Array.Clear( this.map_size, 0, 2 );
        }

        // Token: 0x04004830 RID: 18480
        public AppMain._sts_proc_ sts_proc;

        // Token: 0x04004831 RID: 18481
        public uint flag;

        // Token: 0x04004832 RID: 18482
        public float[] prev_pos = new float[2];

        // Token: 0x04004833 RID: 18483
        public ushort[] map_size = new ushort[2];
    }

    // Token: 0x02000037 RID: 55
    public class GMS_EVE_RECORD_DECORATE
    {
        // Token: 0x04004834 RID: 18484
        public byte pos_x;

        // Token: 0x04004835 RID: 18485
        public byte pos_y;

        // Token: 0x04004836 RID: 18486
        public ushort id;
    }

    // Token: 0x02000038 RID: 56
    public class GMS_EVE_RECORD_RING
    {
        // Token: 0x04004837 RID: 18487
        public byte pos_x;

        // Token: 0x04004838 RID: 18488
        public byte pos_y;
    }

    // Token: 0x02000039 RID: 57
    public class GMS_EVE_RECORD_EVENT
    {
        // Token: 0x1700006C RID: 108
        // (get) Token: 0x06001D4B RID: 7499 RVA: 0x00137358 File Offset: 0x00135558
        // (set) Token: 0x06001D4C RID: 7500 RVA: 0x0013736E File Offset: 0x0013556E
        public ushort word_param
        {
            get
            {
                return ( ushort )( ( int )this.byte_param[1] << 8 | ( int )this.byte_param[0] );
            }
            set
            {
                this.byte_param[0] = ( byte )( value & 255 );
                this.byte_param[1] = ( byte )( value >> 8 & 255 );
            }
        }

        // Token: 0x04004839 RID: 18489
        public byte pos_x;

        // Token: 0x0400483A RID: 18490
        public byte pos_y;

        // Token: 0x0400483B RID: 18491
        public ushort id;

        // Token: 0x0400483C RID: 18492
        public ushort flag;

        // Token: 0x0400483D RID: 18493
        public sbyte left;

        // Token: 0x0400483E RID: 18494
        public sbyte top;

        // Token: 0x0400483F RID: 18495
        public byte width;

        // Token: 0x04004840 RID: 18496
        public byte height;

        // Token: 0x04004841 RID: 18497
        public byte[] byte_param = new byte[2];
    }

    // Token: 0x0200003A RID: 58
    public class GMS_EVE_DATA_EV_LIST
    {
        // Token: 0x04004842 RID: 18498
        public ushort eve_num;

        // Token: 0x04004843 RID: 18499
        public AppMain.GMS_EVE_RECORD_EVENT[] eve_rec;
    }

    // Token: 0x0200003B RID: 59
    public class GMS_EVE_DATA_EV_HEADER
    {
        // Token: 0x06001D4F RID: 7503 RVA: 0x001373AE File Offset: 0x001355AE
        public GMS_EVE_DATA_EV_HEADER()
        {
        }

        // Token: 0x06001D50 RID: 7504 RVA: 0x001373B8 File Offset: 0x001355B8
        public GMS_EVE_DATA_EV_HEADER( AppMain.AmbChunk data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.width = binaryReader.ReadUInt16();
                    this.height = binaryReader.ReadUInt16();
                    int num = (int)(this.width * this.height);
                    this.ofst = new uint[num];
                    for ( int i = 0; i < num; i++ )
                    {
                        this.ofst[i] = binaryReader.ReadUInt32();
                    }
                    this.ev_list = AppMain.New<AppMain.GMS_EVE_DATA_EV_LIST>( num );
                    for ( int j = 0; j < num; j++ )
                    {
                        binaryReader.BaseStream.Seek( ( long )( ( ulong )this.ofst[j] ), 0 );
                        this.ev_list[j].eve_num = binaryReader.ReadUInt16();
                        if ( this.ev_list[j].eve_num > 0 )
                        {
                            this.ev_list[j].eve_rec = AppMain.New<AppMain.GMS_EVE_RECORD_EVENT>( ( int )this.ev_list[j].eve_num );
                            for ( int k = 0; k < ( int )this.ev_list[j].eve_num; k++ )
                            {
                                this.ev_list[j].eve_rec[k].pos_x = binaryReader.ReadByte();
                                this.ev_list[j].eve_rec[k].pos_y = binaryReader.ReadByte();
                                this.ev_list[j].eve_rec[k].id = binaryReader.ReadUInt16();
                                this.ev_list[j].eve_rec[k].flag = binaryReader.ReadUInt16();
                                this.ev_list[j].eve_rec[k].left = binaryReader.ReadSByte();
                                this.ev_list[j].eve_rec[k].top = binaryReader.ReadSByte();
                                this.ev_list[j].eve_rec[k].width = binaryReader.ReadByte();
                                this.ev_list[j].eve_rec[k].height = binaryReader.ReadByte();
                                this.ev_list[j].eve_rec[k].word_param = binaryReader.ReadUInt16();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06001D51 RID: 7505 RVA: 0x00137630 File Offset: 0x00135830
        public void loadData( byte[] data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.width = binaryReader.ReadUInt16();
                    this.height = binaryReader.ReadUInt16();
                    int num = (int)(this.width * this.height);
                    for ( int i = 0; i < num; i++ )
                    {
                        this.ev_list[i].eve_num = binaryReader.ReadUInt16();
                        if ( this.ev_list[i].eve_num > 0 )
                        {
                            for ( int j = 0; j < ( int )this.ev_list[i].eve_num; j++ )
                            {
                                byte pos_x = binaryReader.ReadByte();
                                byte pos_y = binaryReader.ReadByte();
                                ushort num2 = binaryReader.ReadUInt16();
                                ushort flag = binaryReader.ReadUInt16();
                                ushort word_param = binaryReader.ReadUInt16();
                                if ( num2 < 60 || ( 300 <= num2 && num2 < 300 ) || ( 308 <= num2 && num2 < 335 ) )
                                {
                                    this.ev_list[i].eve_rec[j].pos_x = pos_x;
                                    this.ev_list[i].eve_rec[j].pos_y = pos_y;
                                    this.ev_list[i].eve_rec[j].id = num2;
                                    this.ev_list[i].eve_rec[j].flag = flag;
                                    this.ev_list[i].eve_rec[j].word_param = word_param;
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06001D52 RID: 7506 RVA: 0x001377DC File Offset: 0x001359DC
        public byte[] saveData()
        {
            byte[] array = null;
            using ( MemoryStream memoryStream = new MemoryStream() )
            {
                using ( BinaryWriter binaryWriter = new BinaryWriter( memoryStream ) )
                {
                    binaryWriter.Write( this.width );
                    binaryWriter.Write( this.height );
                    int num = (int)(this.width * this.height);
                    for ( int i = 0; i < num; i++ )
                    {
                        binaryWriter.Write( this.ev_list[i].eve_num );
                        if ( this.ev_list[i].eve_num > 0 )
                        {
                            for ( int j = 0; j < ( int )this.ev_list[i].eve_num; j++ )
                            {
                                binaryWriter.Write( this.ev_list[i].eve_rec[j].pos_x );
                                binaryWriter.Write( this.ev_list[i].eve_rec[j].pos_y );
                                binaryWriter.Write( this.ev_list[i].eve_rec[j].id );
                                binaryWriter.Write( this.ev_list[i].eve_rec[j].flag );
                                binaryWriter.Write( this.ev_list[i].eve_rec[j].word_param );
                            }
                        }
                    }
                }
                byte[] array2 = memoryStream.ToArray();
                int num2 = array2.Length;
                array = new byte[num2];
                Array.Copy( array2, array, num2 );
            }
            return array;
        }

        // Token: 0x06001D53 RID: 7507 RVA: 0x00137978 File Offset: 0x00135B78
        public void Clear()
        {
            this.width = 0;
            this.height = 0;
            this.ofst = null;
            this.ev_list = null;
        }

        // Token: 0x04004844 RID: 18500
        public ushort width;

        // Token: 0x04004845 RID: 18501
        public ushort height;

        // Token: 0x04004846 RID: 18502
        public uint[] ofst;

        // Token: 0x04004847 RID: 18503
        public AppMain.GMS_EVE_DATA_EV_LIST[] ev_list;
    }

    // Token: 0x0200003C RID: 60
    public class GMS_EVE_DATA_RG_LIST
    {
        // Token: 0x04004848 RID: 18504
        public ushort ring_num;

        // Token: 0x04004849 RID: 18505
        public AppMain.GMS_EVE_RECORD_RING[] ring_data;
    }

    // Token: 0x0200003D RID: 61
    public class GMS_EVE_DATA_RG_HEADER
    {
        // Token: 0x06001D55 RID: 7509 RVA: 0x0013799E File Offset: 0x00135B9E
        public GMS_EVE_DATA_RG_HEADER()
        {
        }

        // Token: 0x06001D56 RID: 7510 RVA: 0x001379A8 File Offset: 0x00135BA8
        public GMS_EVE_DATA_RG_HEADER( AppMain.AmbChunk data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.width = binaryReader.ReadUInt16();
                    this.height = binaryReader.ReadUInt16();
                    int num = (int)(this.width * this.height);
                    this.ofst = new uint[num];
                    for ( int i = 0; i < num; i++ )
                    {
                        this.ofst[i] = binaryReader.ReadUInt32();
                    }
                    this.ring = AppMain.New<AppMain.GMS_EVE_DATA_RG_LIST>( num );
                    for ( int j = 0; j < num; j++ )
                    {
                        binaryReader.BaseStream.Seek( ( long )( ( ulong )this.ofst[j] ), 0 );
                        this.ring[j].ring_num = binaryReader.ReadUInt16();
                        if ( this.ring[j].ring_num > 0 )
                        {
                            this.ring[j].ring_data = AppMain.New<AppMain.GMS_EVE_RECORD_RING>( ( int )this.ring[j].ring_num );
                            for ( int k = 0; k < ( int )this.ring[j].ring_num; k++ )
                            {
                                this.ring[j].ring_data[k].pos_x = binaryReader.ReadByte();
                                this.ring[j].ring_data[k].pos_y = binaryReader.ReadByte();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06001D57 RID: 7511 RVA: 0x00137B50 File Offset: 0x00135D50
        public void loadData( byte[] data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.width = binaryReader.ReadUInt16();
                    this.height = binaryReader.ReadUInt16();
                    int num = (int)(this.width * this.height);
                    for ( int i = 0; i < num; i++ )
                    {
                        this.ring[i].ring_num = binaryReader.ReadUInt16();
                        if ( this.ring[i].ring_num > 0 )
                        {
                            for ( int j = 0; j < ( int )this.ring[i].ring_num; j++ )
                            {
                                this.ring[i].ring_data[j].pos_x = binaryReader.ReadByte();
                                this.ring[i].ring_data[j].pos_y = binaryReader.ReadByte();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06001D58 RID: 7512 RVA: 0x00137C48 File Offset: 0x00135E48
        public byte[] saveData()
        {
            byte[] array = null;
            using ( MemoryStream memoryStream = new MemoryStream() )
            {
                using ( BinaryWriter binaryWriter = new BinaryWriter( memoryStream ) )
                {
                    binaryWriter.Write( this.width );
                    binaryWriter.Write( this.height );
                    int num = (int)(this.width * this.height);
                    for ( int i = 0; i < num; i++ )
                    {
                        binaryWriter.Write( this.ring[i].ring_num );
                        if ( this.ring[i].ring_num > 0 )
                        {
                            for ( int j = 0; j < ( int )this.ring[i].ring_num; j++ )
                            {
                                binaryWriter.Write( this.ring[i].ring_data[j].pos_x );
                                binaryWriter.Write( this.ring[i].ring_data[j].pos_y );
                            }
                        }
                    }
                }
                byte[] array2 = memoryStream.ToArray();
                int num2 = array2.Length;
                array = new byte[num2];
                Array.Copy( array2, array, num2 );
            }
            return array;
        }

        // Token: 0x06001D59 RID: 7513 RVA: 0x00137D70 File Offset: 0x00135F70
        public void Clear()
        {
            this.width = 0;
            this.height = 0;
            this.ofst = null;
        }

        // Token: 0x0400484A RID: 18506
        public ushort width;

        // Token: 0x0400484B RID: 18507
        public ushort height;

        // Token: 0x0400484C RID: 18508
        public uint[] ofst;

        // Token: 0x0400484D RID: 18509
        public AppMain.GMS_EVE_DATA_RG_LIST[] ring;
    }

    // Token: 0x0200003E RID: 62
    public class GMS_EVE_DATA_DC_LIST
    {
        // Token: 0x0400484E RID: 18510
        public ushort dec_num;

        // Token: 0x0400484F RID: 18511
        public AppMain.GMS_EVE_RECORD_DECORATE[] dec_data;
    }

    // Token: 0x0200003F RID: 63
    public class GMS_EVE_DATA_DC_HEADER
    {
        // Token: 0x06001D5B RID: 7515 RVA: 0x00137D8F File Offset: 0x00135F8F
        public GMS_EVE_DATA_DC_HEADER()
        {
        }

        // Token: 0x06001D5C RID: 7516 RVA: 0x00137D98 File Offset: 0x00135F98
        public GMS_EVE_DATA_DC_HEADER( AppMain.AmbChunk data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.width = binaryReader.ReadUInt16();
                    this.height = binaryReader.ReadUInt16();
                    int num = (int)(this.width * this.height);
                    this.ofst = new uint[num];
                    for ( int i = 0; i < num; i++ )
                    {
                        this.ofst[i] = binaryReader.ReadUInt32();
                    }
                    this.dc_list = AppMain.New<AppMain.GMS_EVE_DATA_DC_LIST>( num );
                    for ( int j = 0; j < num; j++ )
                    {
                        binaryReader.BaseStream.Seek( ( long )( ( ulong )this.ofst[j] ), 0 );
                        this.dc_list[j].dec_num = binaryReader.ReadUInt16();
                        if ( this.dc_list[j].dec_num > 0 )
                        {
                            this.dc_list[j].dec_data = AppMain.New<AppMain.GMS_EVE_RECORD_DECORATE>( ( int )this.dc_list[j].dec_num );
                            for ( int k = 0; k < ( int )this.dc_list[j].dec_num; k++ )
                            {
                                this.dc_list[j].dec_data[k].pos_x = binaryReader.ReadByte();
                                this.dc_list[j].dec_data[k].pos_y = binaryReader.ReadByte();
                                this.dc_list[j].dec_data[k].id = binaryReader.ReadUInt16();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06001D5D RID: 7517 RVA: 0x00137F60 File Offset: 0x00136160
        public void loadData( byte[] data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.width = binaryReader.ReadUInt16();
                    this.height = binaryReader.ReadUInt16();
                    int num = (int)(this.width * this.height);
                    for ( int i = 0; i < num; i++ )
                    {
                        this.dc_list[i].dec_num = binaryReader.ReadUInt16();
                        if ( this.dc_list[i].dec_num > 0 )
                        {
                            for ( int j = 0; j < ( int )this.dc_list[i].dec_num; j++ )
                            {
                                this.dc_list[i].dec_data[j].pos_x = binaryReader.ReadByte();
                                this.dc_list[i].dec_data[j].pos_y = binaryReader.ReadByte();
                                this.dc_list[i].dec_data[j].id = binaryReader.ReadUInt16();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06001D5E RID: 7518 RVA: 0x00138078 File Offset: 0x00136278
        public byte[] saveData()
        {
            byte[] array2;
            using ( MemoryStream memoryStream = new MemoryStream() )
            {
                using ( BinaryWriter binaryWriter = new BinaryWriter( memoryStream ) )
                {
                    binaryWriter.Write( this.width );
                    binaryWriter.Write( this.height );
                    int num = (int)(this.width * this.height);
                    for ( int i = 0; i < num; i++ )
                    {
                        binaryWriter.Write( this.dc_list[i].dec_num );
                        if ( this.dc_list[i].dec_num > 0 )
                        {
                            for ( int j = 0; j < ( int )this.dc_list[i].dec_num; j++ )
                            {
                                binaryWriter.Write( this.dc_list[i].dec_data[j].pos_x );
                                binaryWriter.Write( this.dc_list[i].dec_data[j].pos_y );
                                binaryWriter.Write( this.dc_list[i].dec_data[j].id );
                            }
                        }
                    }
                }
                byte[] array = memoryStream.ToArray();
                int num2 = array.Length;
                array2 = new byte[num2];
                Array.Copy( array, array2, num2 );
            }
            return array2;
        }

        // Token: 0x06001D5F RID: 7519 RVA: 0x001381D4 File Offset: 0x001363D4
        public void Clear()
        {
            this.width = 0;
            this.height = 0;
            this.ofst = null;
        }

        // Token: 0x04004850 RID: 18512
        public ushort width;

        // Token: 0x04004851 RID: 18513
        public ushort height;

        // Token: 0x04004852 RID: 18514
        public uint[] ofst;

        // Token: 0x04004853 RID: 18515
        public AppMain.GMS_EVE_DATA_DC_LIST[] dc_list;
    }

    // Token: 0x02000040 RID: 64
    // (Invoke) Token: 0x06001D61 RID: 7521
    private delegate void _eve_func_( uint flag, ushort bx, ushort by, int[] r_on, int[] r_off );

    // Token: 0x0600007E RID: 126 RVA: 0x000073A0 File Offset: 0x000055A0
    private static void GmEventMgrInit()
    {
        AppMain.gm_eve_mgr_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEveMgrMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmEveMgrDest ), 0U, 0, 4240U, 5, () => new AppMain.GMS_EVE_MGR_WORK(), "GM_EVT_MGR" );
        AppMain.GMS_EVE_MGR_WORK gms_EVE_MGR_WORK = (AppMain.GMS_EVE_MGR_WORK)AppMain.gm_eve_mgr_tcb.work;
        gms_EVE_MGR_WORK.Clear();
        AppMain.g_gm_eve_mgr_work = gms_EVE_MGR_WORK;
        AppMain.g_gm_eve_mgr_work.map_size[0] = ( ushort )( AppMain.gm_eve_data.width << 8 );
        AppMain.g_gm_eve_mgr_work.map_size[1] = ( ushort )( AppMain.gm_eve_data.height << 8 );
    }

    // Token: 0x0600007F RID: 127 RVA: 0x00007447 File Offset: 0x00005647
    private static void GmEventMgrStart()
    {
        AppMain.GmEventMgrCreateEventEnforce();
        AppMain.g_gm_eve_mgr_work.sts_proc = new AppMain._sts_proc_( AppMain.gmEveMgrStateFuncSingleScr );
    }

    // Token: 0x06000080 RID: 128 RVA: 0x00007464 File Offset: 0x00005664
    private static void GmEventMgrCreateEventEnforce()
    {
        int[] array = new int[4];
        array[0] = 0;
        array[2] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 );
        array[1] = 0;
        array[3] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 );
        for ( ushort num = 0; num < AppMain.gm_eve_data.height; num += 1 )
        {
            for ( ushort num2 = 0; num2 < AppMain.gm_eve_data.width; num2 += 1 )
            {
                AppMain.gmEveMgrCreateEventBlkEvent( 4U, num2, num, array, null );
            }
        }
    }

    // Token: 0x06000081 RID: 129 RVA: 0x000074D8 File Offset: 0x000056D8
    public static void GmEventMgrExit()
    {
        if ( AppMain.gm_eve_mgr_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_eve_mgr_tcb );
        }
    }

    // Token: 0x06000082 RID: 130 RVA: 0x000074EC File Offset: 0x000056EC
    private static void gmEveMgrMain( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.GMS_EVE_MGR_WORK gms_EVE_MGR_WORK = (AppMain.GMS_EVE_MGR_WORK)tcb.work;
        if ( gms_EVE_MGR_WORK.sts_proc != null )
        {
            gms_EVE_MGR_WORK.sts_proc();
        }
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        if ( obs_CAMERA != null )
        {
            gms_EVE_MGR_WORK.prev_pos[0] = obs_CAMERA.disp_pos.x;
            gms_EVE_MGR_WORK.prev_pos[1] = obs_CAMERA.disp_pos.y;
        }
    }

    // Token: 0x06000083 RID: 131 RVA: 0x00007551 File Offset: 0x00005751
    private static void gmEveMgrDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.g_gm_eve_mgr_work = null;
        AppMain.gm_eve_mgr_tcb = null;
    }

    // Token: 0x06000084 RID: 132 RVA: 0x00007560 File Offset: 0x00005760
    private static void gmEveMgrCreateEventBlkEvent( uint flag, ushort bx, ushort by, int[] r_on, int[] r_off )
    {
        uint num = (uint)(bx + AppMain.gm_eve_data.width * by);
        AppMain.GMS_EVE_DATA_EV_LIST gms_EVE_DATA_EV_LIST = AppMain.gm_eve_data.ev_list[(int)((UIntPtr)num)];
        ushort eve_num = gms_EVE_DATA_EV_LIST.eve_num;
        AppMain.ArrayPointer<AppMain.GMS_EVE_RECORD_EVENT> pointer = new AppMain.ArrayPointer<AppMain.GMS_EVE_RECORD_EVENT>(gms_EVE_DATA_EV_LIST.eve_rec);
        int num2 = (int)bx << 8;
        int num3 = (int)by << 8;
        int i = 0;
        while ( i < ( int )eve_num )
        {
            if ( ( ( flag & 4U ) == 0U || ( pointer[0].flag & 32768 ) != 0 ) && pointer[0].pos_x != 255 )
            {
                int num4 = (int)pointer[0].pos_x + num2;
                int num5 = (int)pointer[0].pos_y + num3;
                int num6 = (int)AppMain.g_gm_event_size_tbl[(int)pointer[0].id];
                int num7 = num6 + 16 + 32;
                if ( ( flag & 1U ) == 0U || ( num4 >= r_on[0] - num7 && num4 <= r_on[2] + num7 && num5 >= r_on[1] - num7 && num5 <= r_on[3] + num7 ) )
                {
                    int num8 = num6 + 16;
                    if ( ( ( flag & 2U ) == 0U || num4 <= r_off[0] - num8 || num4 >= r_off[2] + num8 || num5 <= r_off[1] - num8 || num5 >= r_off[3] + num8 ) && pointer[0].id < 346 && AppMain.g_gm_event_tbl[( int )pointer[0].id] != null )
                    {
                        if ( ( ( int )pointer[0].flag & 4096 << ( int )( ( ushort )AppMain.GsGetGameLevel() ) ) != 0 )
                        {
                            pointer[0].pos_x = byte.MaxValue;
                        }
                        else
                        {
                            AppMain.g_gm_event_tbl[( int )pointer[0].id]( pointer[0], num4 << 12, num5 << 12, 0 );
                        }
                    }
                }
            }
            i++;
            pointer = ++pointer;
        }
    }

    // Token: 0x06000085 RID: 133 RVA: 0x00007738 File Offset: 0x00005938
    private static void gmEveMgrStateFuncSingleScr()
    {
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        if ( obs_CAMERA != null && ( obs_CAMERA.disp_pos.x != AppMain.g_gm_eve_mgr_work.prev_pos[0] || obs_CAMERA.disp_pos.y != AppMain.g_gm_eve_mgr_work.prev_pos[1] ) )
        {
            AppMain.GmEveMgrCreateEventLcd( 3U );
        }
    }

    // Token: 0x06000086 RID: 134 RVA: 0x00007790 File Offset: 0x00005990
    private static void GmEveMgrCreateEventLcd( uint flag )
    {
        int num = AppMain._g_obj.clip_camera[0] >> 12;
        int num2 = AppMain._g_obj.clip_camera[1] >> 12;
        int num3 = (int)AppMain._g_obj.clip_lcd_size[0];
        int num4 = (int)AppMain._g_obj.clip_lcd_size[1];
        AppMain.lcd_rect[0] = num;
        AppMain.lcd_rect[2] = num + num3;
        AppMain.lcd_rect[1] = num2;
        AppMain.lcd_rect[3] = num2 + num4;
        AppMain.lcd_rect[0] = AppMain.MTM_MATH_CLIP( AppMain.lcd_rect[0], 0, ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 ) );
        AppMain.lcd_rect[1] = AppMain.MTM_MATH_CLIP( AppMain.lcd_rect[1], 0, ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 ) );
        AppMain.lcd_rect[2] = AppMain.MTM_MATH_CLIP( AppMain.lcd_rect[2], 0, ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 ) );
        AppMain.lcd_rect[3] = AppMain.MTM_MATH_CLIP( AppMain.lcd_rect[3], 0, ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 ) );
        for ( int i = 0; i < 3; i++ )
        {
            AppMain._eve_func_ eve_func_ = AppMain.gm_evemgr_create_eve_func_tbl[i];
            int num5 = (int)AppMain.gm_evemgr_create_size_tbl[i];
            AppMain.ev_rect[0] = AppMain.lcd_rect[0];
            AppMain.ev_rect[2] = AppMain.lcd_rect[2];
            AppMain.ev_rect[1] = AppMain.lcd_rect[1];
            AppMain.ev_rect[3] = AppMain.lcd_rect[3];
            AppMain.block_rect[0] = AppMain.ev_rect[0] - 16 - num5 - 255 >> 8;
            AppMain.block_rect[2] = AppMain.ev_rect[2] + 16 + num5 + 255 >> 8;
            AppMain.block_rect[1] = AppMain.ev_rect[1] - 16 - num5 - 255 >> 8;
            AppMain.block_rect[3] = AppMain.ev_rect[3] + 16 + num5 + 255 >> 8;
            if ( AppMain.block_rect[0] < 0 )
            {
                AppMain.block_rect[0] = 0;
            }
            if ( AppMain.block_rect[2] >= ( int )AppMain.gm_eve_data.width )
            {
                AppMain.block_rect[2] = ( int )( AppMain.gm_eve_data.width - 1 );
            }
            if ( AppMain.block_rect[1] < 0 )
            {
                AppMain.block_rect[1] = 0;
            }
            if ( AppMain.block_rect[3] >= ( int )AppMain.gm_eve_data.height )
            {
                AppMain.block_rect[3] = ( int )( AppMain.gm_eve_data.height - 1 );
            }
            for ( ushort num6 = ( ushort )AppMain.block_rect[1]; num6 <= ( ushort )AppMain.block_rect[3]; num6 += 1 )
            {
                for ( ushort num7 = ( ushort )AppMain.block_rect[0]; num7 <= ( ushort )AppMain.block_rect[2]; num7 += 1 )
                {
                    eve_func_( flag, num7, num6, AppMain.ev_rect, AppMain.lcd_rect );
                }
            }
        }
    }

    // Token: 0x06000087 RID: 135 RVA: 0x00007A10 File Offset: 0x00005C10
    private static void gmEveMgrCreateEventBlkRing( uint flag, ushort bx, ushort by, int[] r_on, int[] r_off )
    {
        uint num = (uint)(bx + AppMain.gm_ring_data.width * by);
        AppMain.GMS_EVE_DATA_RG_LIST gms_EVE_DATA_RG_LIST = AppMain.gm_ring_data.ring[(int)((UIntPtr)num)];
        ushort ring_num = gms_EVE_DATA_RG_LIST.ring_num;
        AppMain.ArrayPointer<AppMain.GMS_EVE_RECORD_RING> pointer = new AppMain.ArrayPointer<AppMain.GMS_EVE_RECORD_RING>(gms_EVE_DATA_RG_LIST.ring_data);
        int num2 = (int)bx << 8;
        int num3 = (int)by << 8;
        int num4 = AppMain.GMD_RING_SIZE + 16 + 32;
        for ( ushort num5 = 0; num5 < ring_num; num5 += 1 )
        {
            if ( pointer[0].pos_x != 255 )
            {
                int num6 = (int)pointer[0].pos_x + num2;
                int num7 = (int)pointer[0].pos_y + num3;
                if ( num6 >= r_on[0] - num4 && num6 <= r_on[2] + num4 && num7 >= r_on[1] - num4 && num7 <= r_on[3] + num4 )
                {
                    AppMain.GmRingCreate( pointer, ( ( int )bx << 8 ) + ( int )pointer[0].pos_x << 12, ( ( int )by << 8 ) + ( int )pointer[0].pos_y << 12, 0 );
                }
            }
            pointer = ++pointer;
        }
    }

    // Token: 0x06000088 RID: 136 RVA: 0x00007B1C File Offset: 0x00005D1C
    private static void gmEveMgrCreateEventBlkDecorate( uint flag, ushort bx, ushort by, int[] r_on, int[] r_off )
    {
        uint num = (uint)(bx + AppMain.gm_deco_data.width * by);
        AppMain.GMS_EVE_DATA_DC_LIST gms_EVE_DATA_DC_LIST = AppMain.gm_deco_data.dc_list[(int)((UIntPtr)num)];
        ushort dec_num = gms_EVE_DATA_DC_LIST.dec_num;
        AppMain.ArrayPointer<AppMain.GMS_EVE_RECORD_DECORATE> pointer = new AppMain.ArrayPointer<AppMain.GMS_EVE_RECORD_DECORATE>(gms_EVE_DATA_DC_LIST.dec_data);
        int num2 = (int)bx << 8;
        int num3 = (int)by << 8;
        int i = 0;
        while ( i < ( int )dec_num )
        {
            if ( pointer[0].pos_x != 255 )
            {
                int num4 = (int)pointer[0].pos_x + num2;
                int num5 = (int)pointer[0].pos_y + num3;
                int num6 = (int)AppMain.g_gm_decorate_size_tbl[(int)pointer[0].id];
                int num7 = num6 + 16 + 32;
                if ( ( flag & 1U ) == 0U || ( num4 >= r_on[0] - num7 && num4 <= r_on[2] + num7 && num5 >= r_on[1] - num7 && num5 <= r_on[3] + num7 ) )
                {
                    int num8 = num6 + 16;
                    if ( ( ( flag & 2U ) == 0U || num4 <= r_off[0] - num8 || num4 >= r_off[2] + num8 || num5 <= r_off[1] - num8 || num5 >= r_off[3] + num8 ) && pointer[0].id < 184 && AppMain.g_gm_decorate_tbl[( int )pointer[0].id] != null )
                    {
                        AppMain.g_gm_decorate_tbl[( int )pointer[0].id]( pointer, num4 << 12, num5 << 12, 0 );
                    }
                }
            }
            i++;
            pointer = ++pointer;
        }
    }

    // Token: 0x06000089 RID: 137 RVA: 0x00007CA0 File Offset: 0x00005EA0
    private static void GmEventDataBuild()
    {
        AppMain.AMS_AMB_HEADER header = (AppMain.AMS_AMB_HEADER)AppMain.g_gm_gamedat_map[0];
        object obj = AppMain.amBindGet(header, 6);
        AppMain.gm_eve_data = new AppMain.GMS_EVE_DATA_EV_HEADER( ( AppMain.AmbChunk )obj );
        obj = AppMain.amBindGet( header, 8 );
        AppMain.gm_ring_data = new AppMain.GMS_EVE_DATA_RG_HEADER( ( AppMain.AmbChunk )obj );
        obj = AppMain.amBindGet( header, 7 );
        AppMain.gm_deco_data = new AppMain.GMS_EVE_DATA_DC_HEADER( ( AppMain.AmbChunk )obj );
    }

    // Token: 0x0600008A RID: 138 RVA: 0x00007D02 File Offset: 0x00005F02
    private static void GmEventDataFlush()
    {
        if ( AppMain.gm_eve_data != null )
        {
            AppMain.gm_eve_data = null;
        }
        if ( AppMain.gm_ring_data != null )
        {
            AppMain.gm_ring_data = null;
        }
        if ( AppMain.gm_deco_data != null )
        {
            AppMain.gm_deco_data = null;
        }
    }

    // Token: 0x0600008B RID: 139 RVA: 0x00007D2B File Offset: 0x00005F2B
    private static void GmEveMgrCreateStateEvent()
    {
        AppMain.GmEveMgrCreateEventLcd( 1U );
    }

    // Token: 0x0600008C RID: 140 RVA: 0x00007D34 File Offset: 0x00005F34
    private static void GmEventMgrCreateEventInRect( ushort left, ushort top, ushort right, ushort bottom )
    {
        int[] array = new int[4];
        ushort[] array2 = new ushort[4];
        array[0] = ( int )left;
        if ( array[0] > ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 ) )
        {
            array[0] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 );
        }
        array[1] = ( int )top;
        if ( array[1] > ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 ) )
        {
            array[1] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 );
        }
        array[2] = ( int )right;
        if ( array[2] > ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 ) )
        {
            array[2] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 );
        }
        array[3] = ( int )bottom;
        if ( array[3] > ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 ) )
        {
            array[3] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 );
        }
        array2[0] = ( ushort )( array[0] - 255 >> 8 );
        array2[2] = ( ushort )( array[2] + 255 >> 8 );
        array2[1] = ( ushort )( array[1] - 255 >> 8 );
        array2[3] = ( ushort )( array[3] + 255 >> 8 );
        for ( int i = 0; i < 3; i++ )
        {
            AppMain._eve_func_ eve_func_ = AppMain.gm_evemgr_create_eve_func_tbl[i];
            for ( ushort num = array2[1]; num <= array2[3]; num += 1 )
            {
                for ( ushort num2 = array2[0]; num2 <= array2[2]; num2 += 1 )
                {
                    eve_func_( 1U, num2, num, array, null );
                }
            }
        }
    }

    // Token: 0x0600008D RID: 141 RVA: 0x00007E74 File Offset: 0x00006074
    private static void GmEveMgrCreateEventAll()
    {
        int[] array = new int[4];
        array[0] = 0;
        array[2] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[0] - 1 );
        array[1] = 0;
        array[3] = ( int )( AppMain.g_gm_eve_mgr_work.map_size[1] - 1 );
        for ( int i = 0; i < 3; i++ )
        {
            AppMain._eve_func_ eve_func_ = AppMain.gm_evemgr_create_eve_func_tbl[i];
            for ( ushort num = 0; num < AppMain.gm_eve_data.height; num += 1 )
            {
                for ( ushort num2 = 0; num2 < AppMain.gm_eve_data.width; num2 += 1 )
                {
                    eve_func_( 0U, num2, num, array, null );
                }
            }
        }
    }

    // Token: 0x0600008E RID: 142 RVA: 0x00007F00 File Offset: 0x00006100
    private static AppMain.OBS_OBJECT_WORK GmEventMgrLocalEventBirth( ushort id, int pos_x, int pos_y, ushort flag, sbyte left, sbyte top, byte width, byte height, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = null;
        short num = AppMain.gmEventMgrLocalEventNoGet(0);
        if ( num != -1 )
        {
            AppMain.gm_eve_local_evt_record[( int )num].pos_x = byte.MaxValue;
            AppMain.gm_eve_local_evt_record[( int )num].pos_y = byte.MaxValue;
            AppMain.gm_eve_local_evt_record[( int )num].id = id;
            AppMain.gm_eve_local_evt_record[( int )num].flag = flag;
            AppMain.gm_eve_local_evt_record[( int )num].left = left;
            AppMain.gm_eve_local_evt_record[( int )num].top = top;
            AppMain.gm_eve_local_evt_record[( int )num].width = width;
            AppMain.gm_eve_local_evt_record[( int )num].height = height;
            AppMain.gm_eve_local_evt_record[( int )num].word_param = 0;
            obs_OBJECT_WORK = AppMain.g_gm_event_tbl[( int )id]( AppMain.gm_eve_local_evt_record[( int )num], pos_x, pos_y, type );
            if ( obs_OBJECT_WORK == null )
            {
                AppMain.GmEventMgrLocalEventRelease( AppMain.gm_eve_local_evt_record[( int )num] );
            }
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x0600008F RID: 143 RVA: 0x00007FC8 File Offset: 0x000061C8
    private static void GmEventMgrLocalRingBirth( int pos_x, int pos_y, byte type )
    {
        short num = AppMain.gmEventMgrLocalEventNoGet(1);
        if ( num != -1 )
        {
            AppMain.gm_eve_local_ring_record[( int )num].pos_x = byte.MaxValue;
            AppMain.gm_eve_local_ring_record[( int )num].pos_y = byte.MaxValue;
            AppMain.GmRingCreate( AppMain.gm_eve_local_ring_record[( int )num], pos_x, pos_y, ( int )type );
        }
    }

    // Token: 0x06000090 RID: 144 RVA: 0x00008014 File Offset: 0x00006214
    private static AppMain.OBS_OBJECT_WORK GmEventMgrLocalDecoBirth( ushort id, int pos_x, int pos_y, byte type )
    {
        AppMain.OBS_OBJECT_WORK obs_OBJECT_WORK = null;
        short num = AppMain.gmEventMgrLocalEventNoGet(2);
        if ( num != -1 )
        {
            AppMain.gm_eve_local_deco_record[( int )num].pos_x = byte.MaxValue;
            AppMain.gm_eve_local_deco_record[( int )num].pos_y = byte.MaxValue;
            AppMain.gm_eve_local_deco_record[( int )num].id = id;
            obs_OBJECT_WORK = AppMain.g_gm_decorate_tbl[( int )id]( AppMain.gm_eve_local_deco_record[( int )num], pos_x, pos_y, type );
            if ( obs_OBJECT_WORK == null )
            {
                AppMain.GmEventMgrLocalDecoRelease( AppMain.gm_eve_local_deco_record[( int )num] );
            }
        }
        return obs_OBJECT_WORK;
    }

    // Token: 0x06000091 RID: 145 RVA: 0x00008084 File Offset: 0x00006284
    private static short gmEventMgrLocalEventNoGet( int eve_type )
    {
        uint[] array;
        short num;
        switch ( eve_type )
        {
            case 0:
                array = AppMain.gm_eve_local_evt_obj_use_flag;
                num = 2;
                break;
            case 1:
                array = AppMain.gm_eve_local_ring_obj_use_flag;
                num = 2;
                break;
            case 2:
                array = AppMain.gm_eve_local_deco_obj_use_flag;
                num = 2;
                break;
            default:
                return 0;
        }
        for ( short num2 = 0; num2 < num; num2 += 1 )
        {
            if ( array[( int )num2] < 4294967295U )
            {
                for ( short num3 = 0; num3 < 32; num3 += 1 )
                {
                    if ( 0UL == ( ( ulong )array[( int )num2] & ( ulong )( 1L << ( int )( num3 & 31 ) ) ) )
                    {
                        array[( int )num2] |= 1U << ( int )num3;
                        return ( short )( num2 * 32 + num3 );
                    }
                }
            }
        }
        return -1;
    }

    // Token: 0x06000092 RID: 146 RVA: 0x00008120 File Offset: 0x00006320
    private static void GmEventMgrLocalEventRelease( AppMain.GMS_EVE_RECORD_EVENT eve_rec )
    {
        int num = Array.IndexOf<AppMain.GMS_EVE_RECORD_EVENT>(AppMain.gm_eve_local_evt_record, eve_rec);
        AppMain.gm_eve_local_evt_obj_use_flag[num >> 5] &= ~( 1U << num );
    }

    // Token: 0x06000093 RID: 147 RVA: 0x0000815C File Offset: 0x0000635C
    private static void GmEventMgrLocalRingRelease( AppMain.GMS_EVE_RECORD_RING eve_rec )
    {
        int num = Array.IndexOf<AppMain.GMS_EVE_RECORD_RING>(AppMain.gm_eve_local_ring_record, eve_rec);
        AppMain.gm_eve_local_ring_obj_use_flag[num >> 5] &= ~( 1U << num );
    }

    // Token: 0x06000094 RID: 148 RVA: 0x00008198 File Offset: 0x00006398
    private static void GmEventMgrLocalDecoRelease( AppMain.GMS_EVE_RECORD_DECORATE eve_rec )
    {
        int num = Array.IndexOf<AppMain.GMS_EVE_RECORD_DECORATE>(AppMain.gm_eve_local_deco_record, eve_rec);
        AppMain.gm_eve_local_deco_obj_use_flag[num >> 5] &= ~( 1U << num );
    }

    // Token: 0x06000095 RID: 149 RVA: 0x000081D4 File Offset: 0x000063D4
    private static uint GmEventMgrGetRingNum()
    {
        uint num = 0U;
        if ( AppMain.gm_ring_data != null )
        {
            uint num2 = (uint)(AppMain.gm_ring_data.width * AppMain.gm_ring_data.height);
            for ( uint num3 = 0U; num3 < num2; num3 += 1U )
            {
                num += ( uint )AppMain.gm_ring_data.ring[( int )( ( UIntPtr )num3 )].ring_num;
            }
        }
        return num;
    }
}