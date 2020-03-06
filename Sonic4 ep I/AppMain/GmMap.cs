using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public partial class AppMain
{
    // Token: 0x02000394 RID: 916
    public class GMS_MAP_OTHER_MAP_STATE
    {
        // Token: 0x0400610B RID: 24843
        public int[] map_block_num = new int[2];

        // Token: 0x0400610C RID: 24844
        public int[] map_size = new int[2];

        // Token: 0x0400610D RID: 24845
        public float[] scrl_scale = new float[2];

        // Token: 0x0400610E RID: 24846
        public float pos_z;

        // Token: 0x0400610F RID: 24847
        public uint command_state;

        // Token: 0x04006110 RID: 24848
        public float[] cam_ofst = new float[2];
    }

    // Token: 0x02000395 RID: 917
    public class GMS_MAP_SYS_WORK
    {
        // Token: 0x04006111 RID: 24849
        public uint flag;

        // Token: 0x04006112 RID: 24850
        public AppMain.GMS_MAP_OTHER_MAP_STATE[] map_state = AppMain.New<AppMain.GMS_MAP_OTHER_MAP_STATE>(5);

        // Token: 0x04006113 RID: 24851
        public float[] main_cam_user_disp = new float[2];

        // Token: 0x04006114 RID: 24852
        public float[] main_cam_user_target = new float[2];

        // Token: 0x04006115 RID: 24853
        public float[] main_cam_user_ofst = new float[2];

        // Token: 0x04006116 RID: 24854
        public bool auto_resize;
    }

    // Token: 0x02000396 RID: 918
    public class GMS_MAP_PRIM_DRAW_STACK
    {
        // Token: 0x04006117 RID: 24855
        public AppMain.AOS_TVX_VERTEX[] vtx;

        // Token: 0x04006118 RID: 24856
        public ushort vtx_num;

        // Token: 0x04006119 RID: 24857
        public AppMain.MP_BLOCK mp;

        // Token: 0x0400611A RID: 24858
        public float dx;

        // Token: 0x0400611B RID: 24859
        public float dy;

        // Token: 0x0400611C RID: 24860
        public float dz;
    }

    // Token: 0x02000397 RID: 919
    public class GMS_MAP_PRIM_DRAW_WORK
    {
        // Token: 0x0400611D RID: 24861
        public int tex_id;

        // Token: 0x0400611E RID: 24862
        public uint all_vtx_num;

        // Token: 0x0400611F RID: 24863
        public uint stack_num;

        // Token: 0x04006120 RID: 24864
        public uint op;

        // Token: 0x04006121 RID: 24865
        public AppMain.GMS_MAP_PRIM_DRAW_STACK[] stack = AppMain.New<AppMain.GMS_MAP_PRIM_DRAW_STACK>(255);
    }

    // Token: 0x02000398 RID: 920
    public class GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX
    {
        // Token: 0x04006122 RID: 24866
        public ushort tex_id;

        // Token: 0x04006123 RID: 24867
        public ushort mgr_id;
    }

    // Token: 0x02000399 RID: 921
    public class GMS_MAP_PRIM_DRAW_TVX_MGR
    {
        // Token: 0x060026E4 RID: 9956 RVA: 0x00150C8A File Offset: 0x0014EE8A
        public GMS_MAP_PRIM_DRAW_TVX_MGR( ushort motion_id, ushort time )
        {
            this.motion_id = motion_id;
            this.time = time;
        }

        // Token: 0x04006124 RID: 24868
        public ushort motion_id;

        // Token: 0x04006125 RID: 24869
        public ushort time;
    }

    // Token: 0x0200039A RID: 922
    public class GMS_MAP_PRIM_DRAW_TVX_UV_WORK
    {
        // Token: 0x04006126 RID: 24870
        public int mgr_index_tbl_num;

        // Token: 0x04006127 RID: 24871
        public DoubleType<uint[], AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX[]> mgr_index_tbl_addr;

        // Token: 0x04006128 RID: 24872
        public int[] mgr_tbl_num;

        // Token: 0x04006129 RID: 24873
        public DoubleType<uint[], AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[][]> mgr_tbl_addr;

        // Token: 0x0400612A RID: 24874
        public DoubleType<uint[], AppMain.NNS_TEXCOORD[][]> uv_mgr_tbl_addr;

        // Token: 0x0400612B RID: 24875
        public uint[] frame_index_tbl;

        // Token: 0x0400612C RID: 24876
        public uint[] frame_tbl;

        // Token: 0x0400612D RID: 24877
        public int[] tex_uv_index_tbl;
    }

    // Token: 0x020002C1 RID: 705
    public struct AT_HEADER
    {
        // Token: 0x04005C10 RID: 23568
        public uint block_num;

        // Token: 0x04005C11 RID: 23569
        public AppMain.AT_BLOCK[] blocks;
    }

    // Token: 0x020002C2 RID: 706
    public class AT_BLOCK
    {
        // Token: 0x060024AB RID: 9387 RVA: 0x0014AF90 File Offset: 0x00149190
        public AT_BLOCK()
        {
            this.at = new byte[8][];
            for ( int i = 0; i < 8; i++ )
            {
                this.at[i] = new byte[8];
            }
        }

        // Token: 0x04005C12 RID: 23570
        public byte[][] at;
    }


    // Token: 0x020002CD RID: 717
    public struct RG_HEADER
    {
        // Token: 0x04005C2F RID: 23599
        public ushort map_w;

        // Token: 0x04005C30 RID: 23600
        public ushort map_h;
    }

    // Token: 0x020002CE RID: 718
    public struct RG_OFFSET
    {
        // Token: 0x04005C31 RID: 23601
        public uint ofst;
    }

    // Token: 0x020002CF RID: 719
    public struct RG_BLOCK
    {
        // Token: 0x04005C32 RID: 23602
        public ushort rg_num;
    }

    // Token: 0x020002D0 RID: 720
    public struct RG_INFO
    {
        // Token: 0x04005C33 RID: 23603
        public byte x;

        // Token: 0x04005C34 RID: 23604
        public byte y;
    }

    // Token: 0x020002D1 RID: 721
    public struct DC_HEADER
    {
        // Token: 0x04005C35 RID: 23605
        public ushort map_w;

        // Token: 0x04005C36 RID: 23606
        public ushort map_h;
    }

    // Token: 0x020002D2 RID: 722
    public struct DC_OFFSET
    {
        // Token: 0x04005C37 RID: 23607
        public uint ofst;
    }

    // Token: 0x020002D3 RID: 723
    public struct DC_BLOCK
    {
        // Token: 0x04005C38 RID: 23608
        public ushort dc_num;
    }

    // Token: 0x020002D4 RID: 724
    public struct DC_INFO
    {
        // Token: 0x04005C39 RID: 23609
        public byte x;

        // Token: 0x04005C3A RID: 23610
        public byte y;

        // Token: 0x04005C3B RID: 23611
        public ushort id;
    }

    // Token: 0x020002BE RID: 702
    public struct DF_HEADER
    {
        // Token: 0x04005C0B RID: 23563
        public uint block_num;

        // Token: 0x04005C0C RID: 23564
        public AppMain.DF_BLOCK[] blocks;
    }

    // Token: 0x020002BF RID: 703
    public class DF_BLOCK
    {
        // Token: 0x04005C0D RID: 23565
        public readonly AppMain.DF_BLOCK.DF_CELL[,] df = new AppMain.DF_BLOCK.DF_CELL[8, 8];

        // Token: 0x020002C0 RID: 704
        public struct DF_CELL
        {
            // Token: 0x04005C0E RID: 23566
            public byte[] Data;

            // Token: 0x04005C0F RID: 23567
            public int Offset;
        }
    }

    // Token: 0x020002C3 RID: 707
    public struct DI_HEADER
    {
        // Token: 0x04005C13 RID: 23571
        public uint block_num;

        // Token: 0x04005C14 RID: 23572
        public AppMain.DI_BLOCK[] blocks;
    }

    // Token: 0x020002C4 RID: 708
    public class DI_BLOCK
    {
        // Token: 0x060024AC RID: 9388 RVA: 0x0014AFCC File Offset: 0x001491CC
        public DI_BLOCK()
        {
            this.di = new byte[8][];
            for ( int i = 0; i < 8; i++ )
            {
                this.di[i] = new byte[8];
            }
        }

        // Token: 0x04005C15 RID: 23573
        public byte[][] di;
    }


    // Token: 0x020002C9 RID: 713
    public struct EV_HEADER
    {
        // Token: 0x04005C22 RID: 23586
        public ushort map_w;

        // Token: 0x04005C23 RID: 23587
        public ushort map_h;
    }

    // Token: 0x020002CA RID: 714
    public struct EV_OFFSET
    {
        // Token: 0x04005C24 RID: 23588
        public uint ofst;
    }

    // Token: 0x020002CB RID: 715
    public struct EV_BLOCK
    {
        // Token: 0x04005C25 RID: 23589
        public ushort ev_num;
    }

    // Token: 0x020002CC RID: 716
    public struct EV_INFO
    {
        // Token: 0x04005C26 RID: 23590
        public byte x;

        // Token: 0x04005C27 RID: 23591
        public byte y;

        // Token: 0x04005C28 RID: 23592
        public ushort id;

        // Token: 0x04005C29 RID: 23593
        public ushort flag;

        // Token: 0x04005C2A RID: 23594
        public sbyte rect_x;

        // Token: 0x04005C2B RID: 23595
        public sbyte rect_y;

        // Token: 0x04005C2C RID: 23596
        public byte rect_w;

        // Token: 0x04005C2D RID: 23597
        public byte rect_h;

        // Token: 0x04005C2E RID: 23598
        public ushort user;
    }

    // Token: 0x17000068 RID: 104
    // (get) Token: 0x0600186D RID: 6253 RVA: 0x000DD9DF File Offset: 0x000DBBDF
    public static uint GMD_MAP_DRAW_WIDTH
    {
        get
        {
            return AppMain.gm_map_draw_size[0];
        }
    }

    // Token: 0x17000069 RID: 105
    // (get) Token: 0x0600186E RID: 6254 RVA: 0x000DD9E8 File Offset: 0x000DBBE8
    public static uint GMD_MAP_DRAW_HEIGHT
    {
        get
        {
            return AppMain.gm_map_draw_size[1];
        }
    }

    // Token: 0x0600186F RID: 6255 RVA: 0x000DD9F1 File Offset: 0x000DBBF1
    public static bool GMM_MAP_IS_RANGE( int _src, int _min, int _max )
    {
        return _min < _src && _src < _max;
    }

    // Token: 0x06001870 RID: 6256 RVA: 0x000DD9FD File Offset: 0x000DBBFD
    public static bool GMM_MAP_IS_RANGE( float _src, float _min, float _max )
    {
        return _min < _src && _src < _max;
    }

    // Token: 0x06001871 RID: 6257 RVA: 0x000DDA09 File Offset: 0x000DBC09
    private static void GmMapBuildDataInit()
    {
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 5 )
        {
            return;
        }
        AppMain.gm_map_reg_obj3d_num = 1;
        AppMain.gmMapBuildDrawMapTvxTexScroll();
        AppMain.gm_map_tex_load_init = true;
    }

    // Token: 0x06001872 RID: 6258 RVA: 0x000DDA28 File Offset: 0x000DBC28
    private static bool GmMapBuildDataLoop()
    {
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 5 )
        {
            return true;
        }
        if ( AppMain._am_displaylist_manager.regist_num >= 192 )
        {
            return false;
        }
        if ( AppMain.gm_map_tex_load_init )
        {
            AppMain.AoTexBuild( AppMain.gm_map_texture, ( AppMain.AMS_AMB_HEADER )AppMain.g_gm_gamedat_map[2] );
            AppMain.AoTexLoad( AppMain.gm_map_texture );
            AppMain.gm_map_tex_load_init = false;
        }
        if ( !AppMain.AoTexIsLoaded( AppMain.gm_map_texture ) )
        {
            return false;
        }
        AppMain.gm_map_tex_draw_count = 1;
        return true;
    }

    // Token: 0x06001873 RID: 6259 RVA: 0x000DDA94 File Offset: 0x000DBC94
    private static AppMain.DF_HEADER readDFFile( AppMain.AmbChunk data )
    {
        AppMain.DF_HEADER result = default(AppMain.DF_HEADER);
        result.block_num = BitConverter.ToUInt32( data.array, data.offset );
        result.blocks = new AppMain.DF_BLOCK[result.block_num];
        int num = data.offset + 4;
        int num2 = 0;
        while ( ( long )num2 < ( long )( ( ulong )result.block_num ) )
        {
            AppMain.DF_BLOCK df_BLOCK = new AppMain.DF_BLOCK();
            result.blocks[num2] = df_BLOCK;
            for ( int i = 0; i < 8; i++ )
            {
                for ( int j = 0; j < 8; j++ )
                {
                    df_BLOCK.df[i, j].Data = data.array;
                    df_BLOCK.df[i, j].Offset = num;
                    num += 8;
                }
            }
            num2++;
        }
        return result;
    }

    // Token: 0x06001874 RID: 6260 RVA: 0x000DDB58 File Offset: 0x000DBD58
    private static AppMain.DI_HEADER readDIFile( AppMain.AmbChunk data )
    {
        AppMain.DI_HEADER result = default(AppMain.DI_HEADER);
        using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
            {
                result.block_num = binaryReader.ReadUInt32();
                result.blocks = new AppMain.DI_BLOCK[result.block_num];
                int num = 0;
                while ( ( long )num < ( long )( ( ulong )result.block_num ) )
                {
                    result.blocks[num] = new AppMain.DI_BLOCK();
                    for ( int i = 0; i < 8; i++ )
                    {
                        result.blocks[num].di[i] = binaryReader.ReadBytes( 8 );
                    }
                    num++;
                }
            }
        }
        return result;
    }

    // Token: 0x06001875 RID: 6261 RVA: 0x000DDC38 File Offset: 0x000DBE38
    private static AppMain.AT_HEADER readATFile( AppMain.AmbChunk data )
    {
        AppMain.AT_HEADER result = default(AppMain.AT_HEADER);
        using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
            {
                result.block_num = binaryReader.ReadUInt32();
                result.blocks = new AppMain.AT_BLOCK[result.block_num];
                int num = 0;
                while ( ( long )num < ( long )( ( ulong )result.block_num ) )
                {
                    result.blocks[num] = new AppMain.AT_BLOCK();
                    for ( int i = 0; i < 8; i++ )
                    {
                        result.blocks[num].at[i] = binaryReader.ReadBytes( 8 );
                    }
                    num++;
                }
            }
        }
        return result;
    }

    // Token: 0x06001876 RID: 6262 RVA: 0x000DDD18 File Offset: 0x000DBF18
    private static AppMain.MP_HEADER readMPFile( AppMain.AmbChunk data )
    {
        if ( data.length == 0 )
        {
            return null;
        }
        AppMain.MP_HEADER mp_HEADER = new AppMain.MP_HEADER();
        using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
            {
                mp_HEADER.map_w = binaryReader.ReadUInt16();
                mp_HEADER.map_h = binaryReader.ReadUInt16();
                int num = (int)(mp_HEADER.map_w * mp_HEADER.map_h);
                mp_HEADER.blocks = new AppMain.MP_BLOCK[num];
                for ( int i = 0; i < num; i++ )
                {
                    mp_HEADER.blocks[i] = new AppMain.MP_BLOCK( binaryReader.ReadUInt16() );
                }
            }
        }
        return mp_HEADER;
    }

    // Token: 0x06001877 RID: 6263 RVA: 0x000DDDF4 File Offset: 0x000DBFF4
    private static AppMain.DC_HEADER readDCFile( byte[] data )
    {
        AppMain.DC_HEADER result = default(AppMain.DC_HEADER);
        AppMain.mppAssertNotImpl();
        return result;
    }

    // Token: 0x06001878 RID: 6264 RVA: 0x000DDE10 File Offset: 0x000DC010
    private static AppMain.MD_HEADER readMDFile( AppMain.AmbChunk data )
    {
        if ( data.length == 0 )
        {
            return null;
        }
        AppMain.MD_HEADER md_HEADER = new AppMain.MD_HEADER();
        using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
            {
                md_HEADER.map_w = binaryReader.ReadUInt16();
                md_HEADER.map_h = binaryReader.ReadUInt16();
                int num = (int)(md_HEADER.map_w * md_HEADER.map_h);
                md_HEADER.blocks = new AppMain.MD_BLOCK[num];
                for ( int i = 0; i < num; i++ )
                {
                    md_HEADER.blocks[i] = new AppMain.MD_BLOCK( binaryReader.ReadSByte() );
                }
            }
        }
        return md_HEADER;
    }

    // Token: 0x06001879 RID: 6265 RVA: 0x000DDEEC File Offset: 0x000DC0EC
    private static AppMain.RG_HEADER readRGFile( byte[] data )
    {
        AppMain.RG_HEADER result = default(AppMain.RG_HEADER);
        AppMain.mppAssertNotImpl();
        return result;
    }

    // Token: 0x0600187A RID: 6266 RVA: 0x000DDF08 File Offset: 0x000DC108
    private static AppMain.EV_HEADER readEVFile( byte[] data )
    {
        AppMain.EV_HEADER result = default(AppMain.EV_HEADER);
        AppMain.mppAssertNotImpl();
        return result;
    }

    // Token: 0x0600187B RID: 6267 RVA: 0x000DDF24 File Offset: 0x000DC124
    private static void GmMapBuildColData()
    {
        AppMain.MP_HEADER mp_HEADER = (AppMain.MP_HEADER)AppMain.g_gm_gamedat_map_set[4];
        AppMain.MP_HEADER mp_HEADER2 = (AppMain.MP_HEADER)AppMain.g_gm_gamedat_map_set[5];
        AppMain.g_gm_main_system.map_fcol.map_block_num_x = mp_HEADER.map_w;
        AppMain.g_gm_main_system.map_fcol.map_block_num_y = mp_HEADER.map_h;
        AppMain.g_gm_main_system.map_fcol.block_map_datap[0] = mp_HEADER.blocks;
        AppMain.g_gm_main_system.map_fcol.block_map_datap[1] = mp_HEADER2.blocks;
        AppMain.DF_HEADER df_HEADER = AppMain.readDFFile((AppMain.AmbChunk)AppMain.g_gm_gamedat_map_attr_set[1]);
        AppMain.DI_HEADER di_HEADER = AppMain.readDIFile((AppMain.AmbChunk)AppMain.g_gm_gamedat_map_attr_set[2]);
        AppMain.AT_HEADER at_HEADER = AppMain.readATFile((AppMain.AmbChunk)AppMain.g_gm_gamedat_map_attr_set[0]);
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            int num = 0;
            while ( ( long )num < ( long )( ( ulong )at_HEADER.block_num ) )
            {
                for ( int i = 0; i < 8; i++ )
                {
                    for ( int j = 0; j < 8; j++ )
                    {
                        byte[] array = at_HEADER.blocks[num].at[i];
                        int num2 = j;
                        array[num2] &= 253;
                    }
                }
                num++;
            }
        }
        AppMain.g_gm_main_system.map_fcol.diff_block_num = df_HEADER.block_num;
        AppMain.g_gm_main_system.map_fcol.dir_block_num = di_HEADER.block_num;
        AppMain.g_gm_main_system.map_fcol.attr_block_num = at_HEADER.block_num;
        AppMain.g_gm_main_system.map_fcol.cl_diff_datap = df_HEADER.blocks;
        AppMain.g_gm_main_system.map_fcol.direc_datap = di_HEADER.blocks;
        AppMain.g_gm_main_system.map_fcol.char_attr_datap = at_HEADER.blocks;
        AppMain.g_gm_main_system.map_fcol.left = 0;
        AppMain.g_gm_main_system.map_fcol.top = 0;
        AppMain.g_gm_main_system.map_fcol.right = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 );
        AppMain.g_gm_main_system.map_fcol.bottom = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_y * 64 );
        AppMain.g_gm_main_system.map_size[0] = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_x * 64 );
        AppMain.g_gm_main_system.map_size[1] = ( int )( AppMain.g_gm_main_system.map_fcol.map_block_num_y * 64 );
    }

    // Token: 0x0600187C RID: 6268 RVA: 0x000DE16D File Offset: 0x000DC36D
    private static void GmMapFlushData()
    {
        AppMain.gm_map_release_obj3d_num = 1;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 5 )
        {
            return;
        }
        AppMain.AoTexRelease( AppMain.gm_map_texture );
        AppMain.gmMapFlushDrawMapTvxTexScroll();
    }

    // Token: 0x0600187D RID: 6269 RVA: 0x000DE18D File Offset: 0x000DC38D
    private static bool GmMapFlushDataLoop()
    {
        return AppMain.GMM_MAIN_GET_ZONE_TYPE() == 5 || AppMain.AoTexIsReleased( AppMain.gm_map_texture );
    }

    // Token: 0x0600187E RID: 6270 RVA: 0x000DE1A8 File Offset: 0x000DC3A8
    private static void GmMapFlushColData()
    {
    }

    // Token: 0x0600187F RID: 6271 RVA: 0x000DE1AC File Offset: 0x000DC3AC
    private static void GmMapRelease()
    {
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.g_gm_gamedat_map[i] = null;
        }
    }

    // Token: 0x06001880 RID: 6272 RVA: 0x000DE1D4 File Offset: 0x000DC3D4
    private static void GmMapInit()
    {
        AppMain.ObjSetDiffCollision( AppMain.g_gm_main_system.map_fcol );
        if ( AppMain.g_gs_main_sys_info.stage_id >= 0 && AppMain.g_gs_main_sys_info.stage_id <= 2 )
        {
            AppMain.gmMapTransX = 1f;
        }
        else
        {
            AppMain.gmMapTransX = 0f;
        }
        AppMain.gm_map_tcb = AppMain.MTM_TASK_MAKE_TCB( new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMapMain ), new AppMain.GSF_TASK_PROCEDURE( AppMain.gmMapDest ), 0U, 0, 12288U, 5, () => new AppMain.GMS_MAP_SYS_WORK(), "GM_MAP_MAIN" );
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = new AppMain.GMS_MAP_SYS_WORK();
        AppMain.gm_map_tcb.work = gms_MAP_SYS_WORK;
        AppMain.gm_map_draw_command_state = 0U;
        AppMain.gm_map_draw_margin_adjust = 0U;
        uint stage_id = (uint)AppMain.g_gs_main_sys_info.stage_id;
        AppMain.GmMapSetMapDrawSize( 1 );
        gms_MAP_SYS_WORK.auto_resize = true;
        switch ( stage_id )
        {
            case 0U:
            case 1U:
            case 2U:
            case 4U:
            case 6U:
                AppMain.GmMapSetMapDrawSize( 0 );
                gms_MAP_SYS_WORK.auto_resize = false;
                break;
            case 3U:
            case 7U:
            case 11U:
            case 15U:
            case 16U:
                gms_MAP_SYS_WORK.auto_resize = false;
                break;
        }
        AppMain.gmMapCreateUsePrimMatrix();
        uint num = 3772834047U;
        if ( stage_id == 0U || stage_id == 1U )
        {
            num = uint.MaxValue;
        }
        if ( stage_id == 2U || stage_id == 3U )
        {
            num = 3767175935U;
        }
        else if ( stage_id == 14U )
        {
            num = 1616929023U;
        }
        AppMain.gm_map_prim_draw_tvx_color = num;
        AppMain.gm_map_prim_draw_tvx_alpha_set = null;
        if ( stage_id == 4U || stage_id == 5U || stage_id == 6U || stage_id == 7U )
        {
            AppMain.gm_map_prim_draw_tvx_alpha_set = AppMain.gm_map_prim_draw_tvx_alpha_set_z2;
        }
        AppMain.gm_map_draw_bgm_timer = AppMain.GMD_MAP_DRAW_BGM_TIMER;
        AppMain.GMS_MAP_OTHER_MAP_STATE[] map_state = gms_MAP_SYS_WORK.map_state;
        for ( int i = 0; i < 5; i++ )
        {
            if ( AppMain.g_gm_gamedat_map_set_add[i * 2] != null && AppMain.g_gm_gamedat_map_set_add[i * 2 + 1] != null )
            {
                gms_MAP_SYS_WORK.flag |= 1U << i;
                map_state[i].pos_z = AppMain.gm_map_addmap_pos_z_tbl[i];
                AppMain.MP_HEADER mp_HEADER = (AppMain.MP_HEADER)AppMain.g_gm_gamedat_map_set_add[i * 2];
                map_state[i].map_block_num[0] = ( int )mp_HEADER.map_w;
                map_state[i].map_block_num[1] = ( int )mp_HEADER.map_h;
                map_state[i].map_size[0] = map_state[i].map_block_num[0] * 64;
                map_state[i].map_size[1] = map_state[i].map_block_num[1] * 64;
                map_state[i].scrl_scale[0] = ( ( float )map_state[i].map_size[0] - ( float )AppMain.OBD_LCD_X ) / ( ( float )AppMain.g_gm_main_system.map_size[0] - ( float )AppMain.OBD_LCD_X );
                map_state[i].scrl_scale[1] = ( ( float )map_state[i].map_size[1] - ( float )AppMain.OBD_LCD_Y ) / ( ( float )AppMain.g_gm_main_system.map_size[1] - ( float )AppMain.OBD_LCD_Y );
                if ( AppMain.g_gs_main_sys_info.stage_id == 1 || AppMain.g_gs_main_sys_info.stage_id == 2 || AppMain.g_gs_main_sys_info.stage_id == 8 || AppMain.g_gs_main_sys_info.stage_id == 10 )
                {
                    map_state[i].command_state = AppMain.gm_map_addmap_command_state_z1_act2_3_z3_act1_3_tbl[i];
                }
                else if ( AppMain.g_gs_main_sys_info.stage_id == 16 )
                {
                    map_state[i].command_state = AppMain.gm_map_addmap_command_state_zf_tbl[i];
                }
                else
                {
                    map_state[i].command_state = AppMain.gm_map_addmap_command_state_tbl[i];
                }
            }
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 9 )
        {
            gms_MAP_SYS_WORK.map_state[2].pos_z = 160f;
            gms_MAP_SYS_WORK.map_state[3].pos_z = -96f;
            return;
        }
        if ( AppMain.g_gs_main_sys_info.stage_id == 16 )
        {
            gms_MAP_SYS_WORK.map_state[1].pos_z += -64f;
            gms_MAP_SYS_WORK.map_state[2].pos_z += -64f;
            gms_MAP_SYS_WORK.map_state[3].pos_z += -64f;
        }
    }

    // Token: 0x06001881 RID: 6273 RVA: 0x000DE586 File Offset: 0x000DC786
    private static void GmMapExit()
    {
        if ( AppMain.gm_map_tcb != null )
        {
            AppMain.mtTaskClearTcb( AppMain.gm_map_tcb );
        }
    }

    // Token: 0x06001882 RID: 6274 RVA: 0x000DE599 File Offset: 0x000DC799
    private static void GmMapSetDrawState( uint command_state )
    {
        AppMain.gm_map_draw_command_state = command_state;
    }

    // Token: 0x06001883 RID: 6275 RVA: 0x000DE5A1 File Offset: 0x000DC7A1
    private static void GmMapSetDrawMarginNormal()
    {
        AppMain.gm_map_draw_margin_adjust = 0U;
    }

    // Token: 0x06001884 RID: 6276 RVA: 0x000DE5A9 File Offset: 0x000DC7A9
    private static void GmMapSetDrawMarginMag()
    {
        AppMain.gm_map_draw_margin_adjust = 1U;
    }

    // Token: 0x06001885 RID: 6277 RVA: 0x000DE5B4 File Offset: 0x000DC7B4
    private static void GmMapDrawMap( AppMain.OBS_ACTION3D_NN_WORK obj3d_tbl, AppMain.MP_HEADER mp_header, AppMain.MD_HEADER md_header, float pos_x, float pos_y, float trans_x, float trans_y, float trans_z, bool loop_h )
    {
        float num = 0f;
        float num2 = 0f;
        int num3 = (int)pos_x >> 6;
        int num4 = (int)pos_y >> 6;
        int num5 = (int)(AppMain.GMD_MAP_DRAW_WIDTH + 2U + AppMain.gm_map_draw_margin_adjust * 2U);
        int num6 = (int)(AppMain.GMD_MAP_DRAW_HEIGHT + 2U + AppMain.gm_map_draw_margin_adjust * 2U);
        int num7 = num3 - (num5 >> 1);
        int num8 = num3 + (num5 >> 1);
        int num9 = num4 - (num6 >> 1);
        int num10 = num4 + (num6 >> 1);
        if ( num7 < 0 )
        {
            if ( !loop_h )
            {
                num7 = 0;
            }
            else
            {
                num7 += ( int )mp_header.map_w;
                num = ( float )( -( float )( mp_header.map_w << 6 ) );
            }
        }
        else if ( num7 >= ( int )mp_header.map_w )
        {
            if ( !loop_h )
            {
                num7 = ( int )mp_header.map_w - num5;
            }
            else
            {
                num7 -= ( int )mp_header.map_w;
                num = ( float )( mp_header.map_w << 6 );
            }
        }
        if ( num9 < 0 )
        {
            num9 = 0;
        }
        if ( num8 >= ( int )mp_header.map_w )
        {
            if ( !loop_h )
            {
                num8 = ( int )( mp_header.map_w - 1 );
            }
            else
            {
                num8 -= ( int )mp_header.map_w;
                num2 = ( float )( mp_header.map_w << 6 );
            }
        }
        else if ( num8 < 0 )
        {
            if ( !loop_h )
            {
                num8 = num5;
            }
            else
            {
                num8 += ( int )mp_header.map_w;
                num2 = ( float )( -( float )( mp_header.map_w << 6 ) );
            }
        }
        if ( num10 >= ( int )mp_header.map_h )
        {
            num10 = ( int )( mp_header.map_h - 1 );
        }
        if ( num7 >= num8 )
        {
            AppMain.gmMapDrawMapRange( obj3d_tbl, mp_header, md_header, trans_x + num, trans_y, trans_z, num7, ( int )( mp_header.map_w - 1 ), num9, num10 );
            AppMain.gmMapDrawMapRange( obj3d_tbl, mp_header, md_header, trans_x + num2, trans_y, trans_z, 0, num8, num9, num10 );
            return;
        }
        if ( loop_h )
        {
            AppMain.gmMapDrawMapRange( obj3d_tbl, mp_header, md_header, trans_x + num, trans_y, trans_z, num7, num8, num9, num10 );
            return;
        }
        AppMain.gmMapDrawMapRange( obj3d_tbl, mp_header, md_header, trans_x, trans_y, trans_z, num7, num8, num9, num10 );
    }

    // Token: 0x06001886 RID: 6278 RVA: 0x000DE740 File Offset: 0x000DC940
    private static void gmMapDrawMapRange( AppMain.OBS_ACTION3D_NN_WORK obj3d_tbl, AppMain.MP_HEADER mp_header, AppMain.MD_HEADER md_header, float trans_x, float trans_y, float trans_z, int block_left, int block_right, int block_top, int block_bottom )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001887 RID: 6279 RVA: 0x000DE748 File Offset: 0x000DC948
    private static void GmMapSetAddMapXLoop()
    {
        if ( AppMain.gm_map_tcb == null )
        {
            return;
        }
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
        gms_MAP_SYS_WORK.flag |= 2147483648U;
        AppMain.GMS_MAP_OTHER_MAP_STATE[] map_state = gms_MAP_SYS_WORK.map_state;
        for ( int i = 0; i < 5; i++ )
        {
            if ( ( gms_MAP_SYS_WORK.flag & 1U << i ) != 0U && map_state[i].map_size[0] != AppMain.g_gm_main_system.map_size[0] )
            {
                map_state[i].scrl_scale[0] = ( float )map_state[i].map_size[0] / ( float )AppMain.g_gm_main_system.map_size[0];
            }
        }
    }

    // Token: 0x06001888 RID: 6280 RVA: 0x000DE7DC File Offset: 0x000DC9DC
    private static void GmMapEnableAddMapUserScrlX()
    {
        if ( AppMain.gm_map_tcb == null )
        {
            return;
        }
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
        if ( ( gms_MAP_SYS_WORK.flag & 536870912U ) != 0U )
        {
            return;
        }
        gms_MAP_SYS_WORK.flag |= 536870912U;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        gms_MAP_SYS_WORK.main_cam_user_disp[0] = obs_CAMERA.disp_pos.x;
        gms_MAP_SYS_WORK.main_cam_user_disp[1] = obs_CAMERA.disp_pos.y;
        gms_MAP_SYS_WORK.main_cam_user_target[0] = obs_CAMERA.disp_pos.x;
        gms_MAP_SYS_WORK.main_cam_user_target[1] = obs_CAMERA.disp_pos.y;
        gms_MAP_SYS_WORK.main_cam_user_ofst[0] = ( gms_MAP_SYS_WORK.main_cam_user_ofst[1] = 0f );
    }

    // Token: 0x06001889 RID: 6281 RVA: 0x000DE898 File Offset: 0x000DCA98
    private static void GmMapDisenableAddMapUserScrlX()
    {
        if ( AppMain.gm_map_tcb == null )
        {
            return;
        }
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
        if ( ( gms_MAP_SYS_WORK.flag & 536870912U ) == 0U )
        {
            return;
        }
        gms_MAP_SYS_WORK.flag &= 3758096383U;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        float num = gms_MAP_SYS_WORK.main_cam_user_disp[0] + gms_MAP_SYS_WORK.main_cam_user_ofst[0] - obs_CAMERA.disp_pos.x;
        for ( int i = 0; i < 5; i++ )
        {
            if ( i != 1 )
            {
                gms_MAP_SYS_WORK.map_state[i].cam_ofst[0] += num * gms_MAP_SYS_WORK.map_state[i].scrl_scale[0];
            }
        }
    }

    // Token: 0x0600188A RID: 6282 RVA: 0x000DE94C File Offset: 0x000DCB4C
    private static void GmMapSetAddMapScrlScaleMagX( int map_type, int mag )
    {
        if ( AppMain.gm_map_tcb == null )
        {
            return;
        }
        if ( map_type == 1 || map_type >= 5 )
        {
            return;
        }
        if ( mag == 0 )
        {
            mag = 1;
        }
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
        AppMain.GMS_MAP_OTHER_MAP_STATE gms_MAP_OTHER_MAP_STATE = gms_MAP_SYS_WORK.map_state[map_type];
        if ( ( gms_MAP_SYS_WORK.flag & 2147483648U ) > 0U )
        {
            gms_MAP_OTHER_MAP_STATE.scrl_scale[0] = ( float )gms_MAP_OTHER_MAP_STATE.map_size[0] / ( float )AppMain.g_gm_main_system.map_size[0] / ( float )mag;
            return;
        }
        gms_MAP_OTHER_MAP_STATE.scrl_scale[0] = ( ( float )gms_MAP_OTHER_MAP_STATE.map_size[0] - ( float )AppMain.OBD_LCD_X ) / ( ( float )AppMain.g_gm_main_system.map_size[0] - ( float )AppMain.OBD_LCD_X ) / ( float )mag;
    }

    // Token: 0x0600188B RID: 6283 RVA: 0x000DE9EC File Offset: 0x000DCBEC
    private static void GmMapSetAddMapUserScrlXAddSize( float move_size )
    {
        if ( AppMain.gm_map_tcb == null )
        {
            return;
        }
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
        gms_MAP_SYS_WORK.main_cam_user_ofst[0] += move_size;
        float num = (float)AppMain.g_gm_main_system.map_size[0];
        if ( gms_MAP_SYS_WORK.main_cam_user_disp[0] + gms_MAP_SYS_WORK.main_cam_user_ofst[0] - ( float )AppMain.OBD_LCD_X >= num )
        {
            gms_MAP_SYS_WORK.main_cam_user_ofst[0] -= num;
            return;
        }
        if ( gms_MAP_SYS_WORK.main_cam_user_disp[0] + gms_MAP_SYS_WORK.main_cam_user_ofst[0] + ( float )AppMain.OBD_LCD_X <= -num )
        {
            gms_MAP_SYS_WORK.main_cam_user_ofst[0] += num;
        }
    }

    // Token: 0x0600188C RID: 6284 RVA: 0x000DEAA4 File Offset: 0x000DCCA4
    private static void GmMapGetAddMapCameraPos( AppMain.NNS_VECTOR main_disp_pos, AppMain.NNS_VECTOR main_target_pos, AppMain.NNS_VECTOR dest_disp_pos, AppMain.NNS_VECTOR dest_target_pos, int camera_id )
    {
        if ( AppMain.gm_map_tcb == null )
        {
            AppMain.mppAssertNotImpl();
            return;
        }
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
        AppMain.main_camera_pos[0].Assign( main_disp_pos );
        AppMain.main_camera_pos[1].Assign( main_target_pos );
        if ( ( gms_MAP_SYS_WORK.flag & 536870912U ) != 0U )
        {
            AppMain.main_camera_pos[0].x = gms_MAP_SYS_WORK.main_cam_user_disp[0] + gms_MAP_SYS_WORK.main_cam_user_ofst[0];
            AppMain.main_camera_pos[1].x = gms_MAP_SYS_WORK.main_cam_user_target[0] + gms_MAP_SYS_WORK.main_cam_user_ofst[0];
        }
        float num = AppMain.AMD_SCREEN_2D_WIDTH / 2f * 0.67438334f * 1f;
        float num2 = AppMain.AMD_SCREEN_2D_HEIGHT / 2f * 0.67438334f * 1f * 0.9f;
        float num3 = 0f + num;
        float num4 = (float)AppMain.g_gm_main_system.map_size[0] - num;
        float num5 = 0f + num2;
        float num6 = (float)AppMain.g_gm_main_system.map_size[1] - num2;
        AppMain.GMS_MAP_OTHER_MAP_STATE gms_MAP_OTHER_MAP_STATE;
        if ( camera_id == 2 )
        {
            gms_MAP_OTHER_MAP_STATE = gms_MAP_SYS_WORK.map_state[0];
        }
        else if ( camera_id >= 3 )
        {
            gms_MAP_OTHER_MAP_STATE = gms_MAP_SYS_WORK.map_state[camera_id - 3 + 2];
        }
        else
        {
            gms_MAP_OTHER_MAP_STATE = gms_MAP_SYS_WORK.map_state[0];
        }
        int num7 = 0;
        if ( ( gms_MAP_SYS_WORK.flag & 2147483648U ) == 0U )
        {
            if ( AppMain.main_camera_pos[num7].x <= num3 )
            {
                dest_disp_pos.x = num;
            }
            else if ( AppMain.main_camera_pos[num7].x >= num4 )
            {
                dest_disp_pos.x = ( float )gms_MAP_OTHER_MAP_STATE.map_size[0] - num;
            }
            else
            {
                dest_disp_pos.x = num + ( AppMain.main_camera_pos[num7].x - num ) * gms_MAP_OTHER_MAP_STATE.scrl_scale[0];
            }
        }
        else
        {
            dest_disp_pos.x = AppMain.main_camera_pos[num7].x * gms_MAP_OTHER_MAP_STATE.scrl_scale[0];
        }
        dest_disp_pos.x += gms_MAP_OTHER_MAP_STATE.cam_ofst[0];
        if ( -AppMain.main_camera_pos[num7].y <= num5 )
        {
            dest_disp_pos.y = -num2;
        }
        else if ( -AppMain.main_camera_pos[num7].y >= num6 )
        {
            dest_disp_pos.y = -( ( float )gms_MAP_OTHER_MAP_STATE.map_size[1] - num2 );
        }
        else
        {
            dest_disp_pos.y = -( num2 + ( -AppMain.main_camera_pos[num7].y - num2 ) * gms_MAP_OTHER_MAP_STATE.scrl_scale[1] );
        }
        dest_disp_pos.z = AppMain.main_camera_pos[num7].z;
        num7 = 1;
        if ( ( gms_MAP_SYS_WORK.flag & 2147483648U ) == 0U )
        {
            if ( AppMain.main_camera_pos[num7].x <= num3 )
            {
                dest_target_pos.x = num;
            }
            else if ( AppMain.main_camera_pos[num7].x >= num4 )
            {
                dest_target_pos.x = ( float )gms_MAP_OTHER_MAP_STATE.map_size[0] - num;
            }
            else
            {
                dest_target_pos.x = num + ( AppMain.main_camera_pos[num7].x - num ) * gms_MAP_OTHER_MAP_STATE.scrl_scale[0];
            }
        }
        else
        {
            dest_target_pos.x = AppMain.main_camera_pos[num7].x * gms_MAP_OTHER_MAP_STATE.scrl_scale[0];
        }
        dest_target_pos.x += gms_MAP_OTHER_MAP_STATE.cam_ofst[0];
        if ( -AppMain.main_camera_pos[num7].y <= num5 )
        {
            dest_target_pos.y = -num2;
        }
        else if ( -AppMain.main_camera_pos[num7].y >= num6 )
        {
            dest_target_pos.y = -( ( float )gms_MAP_OTHER_MAP_STATE.map_size[1] - num2 );
        }
        else
        {
            dest_target_pos.y = -( num2 + ( -AppMain.main_camera_pos[num7].y - num2 ) * gms_MAP_OTHER_MAP_STATE.scrl_scale[1] );
        }
        dest_target_pos.z = AppMain.main_camera_pos[num7].z;
    }

    // Token: 0x0600188D RID: 6285 RVA: 0x000DEE1C File Offset: 0x000DD01C
    private static void GmMapSetDispB( bool disp )
    {
        if ( AppMain.gm_map_tcb != null )
        {
            AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
            if ( disp )
            {
                gms_MAP_SYS_WORK.flag &= 4026531839U;
                return;
            }
            gms_MAP_SYS_WORK.flag |= 268435456U;
        }
    }

    // Token: 0x0600188E RID: 6286 RVA: 0x000DEE68 File Offset: 0x000DD068
    private static void GmMapSetDisp( bool disp )
    {
        if ( AppMain.gm_map_tcb != null )
        {
            AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)AppMain.gm_map_tcb.work;
            if ( disp )
            {
                gms_MAP_SYS_WORK.flag &= 4160749567U;
                return;
            }
            gms_MAP_SYS_WORK.flag |= 134217728U;
        }
    }

    // Token: 0x0600188F RID: 6287 RVA: 0x000DEEB4 File Offset: 0x000DD0B4
    private static bool GmMapIsDrawEnableMMapBack()
    {
        bool result = true;
        AppMain.OBS_CAMERA obs_CAMERA = AppMain.ObjCameraGet(AppMain.g_obj.glb_camera_id);
        float x = obs_CAMERA.disp_pos.x;
        float src = -obs_CAMERA.disp_pos.y;
        int stage_id = (int)AppMain.g_gs_main_sys_info.stage_id;
        int num = stage_id;
        switch ( num )
        {
            case 0:
                if ( AppMain.GMM_MAP_IS_RANGE( x, 5450f, 5725f ) && AppMain.GMM_MAP_IS_RANGE( src, 1010f, 1520f ) )
                {
                    result = false;
                }
                else if ( AppMain.GMM_MAP_IS_RANGE( x, 8010f, 8500f ) && AppMain.GMM_MAP_IS_RANGE( src, 1200f, 1650f ) )
                {
                    result = false;
                }
                else if ( AppMain.GMM_MAP_IS_RANGE( x, 10055f, 10695f ) && AppMain.GMM_MAP_IS_RANGE( src, 1025f, 1400f ) )
                {
                    result = false;
                }
                break;
            case 1:
                if ( AppMain.GMM_MAP_IS_RANGE( x, 3975f, 4650f ) && AppMain.GMM_MAP_IS_RANGE( src, 1555f, 2200f ) )
                {
                    result = false;
                }
                else if ( x > 12415f )
                {
                    result = false;
                }
                break;
            default:
                if ( num == 16 )
                {
                    if ( x < 2450f )
                    {
                        result = false;
                    }
                    else if ( AppMain.GMM_MAP_IS_RANGE( x, 3020f, 5600f ) )
                    {
                        result = false;
                    }
                    else if ( AppMain.GMM_MAP_IS_RANGE( x, 6590f, 9200f ) )
                    {
                        result = false;
                    }
                }
                break;
        }
        return result;
    }

    // Token: 0x06001890 RID: 6288 RVA: 0x000DF008 File Offset: 0x000DD208
    private static void GmMapSetLight()
    {
        AppMain.NNS_RGBA nns_RGBA = new AppMain.NNS_RGBA(1f, 1f, 1f, 1f);
        AppMain.NNS_VECTOR nns_VECTOR = new AppMain.NNS_VECTOR(1f, 1f, 1f);
        float intensity = 1f;
        if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 0 )
        {
            nns_VECTOR.x = -1f;
            nns_VECTOR.y = -1f;
            nns_VECTOR.z = -1f;
            nns_RGBA.r = 1f;
            nns_RGBA.g = 1f;
            nns_RGBA.b = 1f;
            nns_RGBA.a = 1f;
            intensity = 1f;
        }
        else if ( AppMain.GMM_MAIN_GET_ZONE_TYPE() == 3 )
        {
            nns_VECTOR.x = -0.2f;
            nns_VECTOR.y = 0.25f;
            nns_VECTOR.z = -1f;
            nns_RGBA.r = 1f;
            nns_RGBA.g = 1f;
            nns_RGBA.b = 1f;
            nns_RGBA.a = 1f;
            if ( AppMain.g_gs_main_sys_info.stage_id == 14 )
            {
                intensity = 0.4f;
            }
            else
            {
                intensity = 1f;
            }
        }
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.ObjDrawSetParallelLight( AppMain.NNE_LIGHT_5, ref nns_RGBA, intensity, nns_VECTOR );
    }

    // Token: 0x06001891 RID: 6289 RVA: 0x000DF13B File Offset: 0x000DD33B
    private static void GmMapSetMapDrawSize( int size )
    {
        AppMain.gm_map_draw_size[0] = AppMain.gm_map_set_draw_size[size, 0];
        AppMain.gm_map_draw_size[1] = AppMain.gm_map_set_draw_size[size, 1];
    }

    // Token: 0x06001892 RID: 6290 RVA: 0x000DF163 File Offset: 0x000DD363
    private static void gmMapDest( AppMain.MTS_TASK_TCB tcb )
    {
        AppMain.gm_map_tcb = null;
    }

    // Token: 0x06001893 RID: 6291 RVA: 0x000DF16C File Offset: 0x000DD36C
    private static void gmMapMain( AppMain.MTS_TASK_TCB tcb )
    {
        int num = AppMain.GMM_MAIN_GET_ZONE_TYPE();
        if ( num == 5 )
        {
            if ( ( AppMain.g_gm_main_system.game_flag & 268435456U ) != 0U && --AppMain.gm_map_draw_bgm_timer <= 0 )
            {
                AppMain.g_gm_main_system.game_flag |= 134217728U;
                AppMain.g_gm_main_system.game_flag &= 4026531839U;
            }
            return;
        }
        int num2 = 0;
        int num3 = AppMain.gm_map_add_tbl_use_no[num] + 1;
        AppMain.GMS_MAP_SYS_WORK gms_MAP_SYS_WORK = (AppMain.GMS_MAP_SYS_WORK)tcb.work;
        if ( ( gms_MAP_SYS_WORK.flag & 134217728U ) != 0U )
        {
            return;
        }
        if ( AppMain.ObjObjectPauseCheck( 0U ) == 0U )
        {
            AppMain.gmMapUpdateDrawMapTvxTexScroll();
        }
        if ( !AppMain.GmMainIsDrawEnable() )
        {
            return;
        }
        if ( ( AppMain.g_gm_main_system.game_flag & 268435456U ) != 0U && --AppMain.gm_map_draw_bgm_timer <= 0 )
        {
            AppMain.g_gm_main_system.game_flag |= 134217728U;
            AppMain.g_gm_main_system.game_flag &= 4026531839U;
        }
        AppMain.TVX_FILE[] tvxamb = (AppMain.TVX_FILE[])AppMain.g_gm_gamedat_map[1];
        AppMain.NNS_TEXLIST texlist = AppMain.AoTexGetTexList(AppMain.gm_map_texture);
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.gmMapMain_mtx;
        AppMain.nnMakeUnitMatrix( nns_MATRIX );
        AppMain.OBS_CAMERA obs_CAMERA;
        if ( gms_MAP_SYS_WORK.auto_resize )
        {
            obs_CAMERA = AppMain.ObjCameraGet( AppMain.g_obj.glb_camera_id );
            if ( ( obs_CAMERA.roll & 262143 ) != 0 )
            {
                AppMain.GmMapSetMapDrawSize( 0 );
            }
            else if ( ( obs_CAMERA.roll & 16384 ) != 0 )
            {
                AppMain.GmMapSetMapDrawSize( 2 );
            }
            else
            {
                AppMain.GmMapSetMapDrawSize( 1 );
            }
        }
        AppMain.GMS_MAP_OTHER_MAP_STATE[] map_state = gms_MAP_SYS_WORK.map_state;
        float x;
        float pos_y;
        AppMain.MP_HEADER mp_HEADER;
        AppMain.MD_HEADER md_HEADER;
        for ( int i = num3 - 1; i >= num2; i-- )
        {
            if ( ( gms_MAP_SYS_WORK.flag & 1U << i ) != 0U && ( i < 2 || AppMain.GmMapIsDrawEnableMMapBack() ) )
            {
                bool loop_h = false;
                if ( i != 1 && ( gms_MAP_SYS_WORK.flag & 2147483648U ) != 0U )
                {
                    loop_h = true;
                }
                AppMain.ObjDraw3DNNSetCameraEx( AppMain.gm_map_addmap_camera_tbl[i], 1, map_state[i].command_state );
                obs_CAMERA = AppMain.ObjCameraGet( AppMain.gm_map_addmap_camera_tbl[i] );
                x = obs_CAMERA.disp_pos.x;
                pos_y = -obs_CAMERA.disp_pos.y;
                AppMain.GmMapSetDrawState( map_state[i].command_state );
                mp_HEADER = ( AppMain.MP_HEADER )AppMain.g_gm_gamedat_map_set_add[i * 2];
                md_HEADER = ( AppMain.MD_HEADER )AppMain.g_gm_gamedat_map_set_add[1 + i * 2];
                AppMain.gmMapInitDrawMapTvx();
                AppMain.gmMapSetDrawMapTvx( tvxamb, mp_HEADER, md_HEADER, x, pos_y, AppMain.gmMapTransX, 0f, map_state[i].pos_z, loop_h, mp_HEADER.blocks[0], md_HEADER.blocks[0] );
                AppMain.gmMapExecuteDrawMapTvx( nns_MATRIX, texlist );
            }
        }
        AppMain.GmMapSetDrawState( 0U );
        AppMain.ObjDraw3DNNSetCameraEx( AppMain.g_obj.glb_camera_id, AppMain.g_obj.glb_camera_type, 0U );
        obs_CAMERA = AppMain.ObjCameraGet( AppMain.g_obj.glb_camera_id );
        x = obs_CAMERA.disp_pos.x;
        pos_y = -obs_CAMERA.disp_pos.y;
        AppMain.gmMapInitDrawMapTvx();
        if ( ( gms_MAP_SYS_WORK.flag & 268435456U ) == 0U )
        {
            mp_HEADER = ( AppMain.MP_HEADER )AppMain.g_gm_gamedat_map_set[1];
            md_HEADER = ( AppMain.MD_HEADER )AppMain.g_gm_gamedat_map_set[3];
            AppMain.gmMapSetDrawMapTvx( tvxamb, mp_HEADER, md_HEADER, x, pos_y, AppMain.gmMapTransX, 0f, -128f, false, mp_HEADER.blocks[0], md_HEADER.blocks[0] );
        }
        mp_HEADER = ( AppMain.MP_HEADER )AppMain.g_gm_gamedat_map_set[0];
        md_HEADER = ( AppMain.MD_HEADER )AppMain.g_gm_gamedat_map_set[2];
        AppMain.gmMapSetDrawMapTvx( tvxamb, mp_HEADER, md_HEADER, x, pos_y, AppMain.gmMapTransX, 0f, 128f, false, mp_HEADER.blocks[0], md_HEADER.blocks[0] );
        AppMain.gmMapExecuteDrawMapTvx( nns_MATRIX, texlist );
        if ( AppMain.gm_map_tex_draw_count > 0 )
        {
            AppMain.gm_map_tex_draw_count--;
            AppMain.ObjLoadInitDraw();
            if ( AppMain.gm_map_tex_draw_count == 0 )
            {
                AppMain.ObjLoadClearDraw();
            }
            for ( int j = 0; j < AppMain.gm_map_texture.texlist.nTex; j++ )
            {
                AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
                ams_PARAM_DRAW_PRIMITIVE.Clear();
                ams_PARAM_DRAW_PRIMITIVE.type = 0;
                ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
                ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
                ams_PARAM_DRAW_PRIMITIVE.bldDst = 771;
                ams_PARAM_DRAW_PRIMITIVE.aTest = 1;
                ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
                ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
                ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
                ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
                ams_PARAM_DRAW_PRIMITIVE.vwrap = 1;
                ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
                ams_PARAM_DRAW_PRIMITIVE.texlist = texlist;
                AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(4);
                AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
                int offset = nns_PRIM3D_PCT_ARRAY.offset;
                ams_PARAM_DRAW_PRIMITIVE.vtxPCT3D = nns_PRIM3D_PCT_ARRAY;
                ams_PARAM_DRAW_PRIMITIVE.count = 4;
                ams_PARAM_DRAW_PRIMITIVE.texId = j;
                buffer[offset].Pos.x = ( buffer[offset + 1].Pos.x = -1f );
                buffer[offset + 2].Pos.x = ( buffer[offset + 3].Pos.x = 1f );
                buffer[offset].Pos.y = ( buffer[offset + 2].Pos.y = -1f );
                buffer[offset + 1].Pos.y = ( buffer[offset + 3].Pos.y = 1f );
                buffer[offset].Pos.z = ( buffer[offset + 1].Pos.z = ( buffer[offset + 2].Pos.z = ( buffer[offset + 3].Pos.z = -1f ) ) );
                buffer[offset].Tex.u = ( buffer[offset + 1].Tex.u = 0f );
                buffer[offset + 2].Tex.u = ( buffer[offset + 3].Tex.u = 1f );
                buffer[offset].Tex.v = ( buffer[offset + 2].Tex.v = 0f );
                buffer[offset + 1].Tex.v = ( buffer[offset + 3].Tex.v = 1f );
                buffer[offset].Col = ( buffer[offset + 1].Col = ( buffer[offset + 2].Col = ( buffer[offset + 3].Col = uint.MaxValue ) ) );
                AppMain.ObjDraw3DNNDrawPrimitive( ams_PARAM_DRAW_PRIMITIVE, AppMain.gm_map_draw_command_state, 0, 0 );
                AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
            }
        }
    }

    // Token: 0x06001894 RID: 6292 RVA: 0x000DF868 File Offset: 0x000DDA68
    private static void gmMapInitDrawMapTvx()
    {
        AppMain.GMS_MAP_PRIM_DRAW_WORK[] array = AppMain.gm_map_prim_draw_work;
        for ( int i = 0; i < 16; i++ )
        {
            array[i].tex_id = -1;
            array[i].all_vtx_num = 0U;
            array[i].stack_num = 0U;
        }
    }

    // Token: 0x06001895 RID: 6293 RVA: 0x000DF8A4 File Offset: 0x000DDAA4
    private static void gmMapSetDrawMapTvx( AppMain.TVX_FILE[] tvxamb, AppMain.MP_HEADER mp_header, AppMain.MD_HEADER md_header, float pos_x, float pos_y, float trans_x, float trans_y, float trans_z, bool loop_h, AppMain.MP_BLOCK mp_block, AppMain.MD_BLOCK md_block )
    {
        float num = 0f;
        float num2 = 0f;
        int num3 = (int)pos_x >> 6;
        int num4 = (int)pos_y >> 6;
        int num5 = (int)(AppMain.GMD_MAP_DRAW_WIDTH + 2U + AppMain.gm_map_draw_margin_adjust * 2U);
        int num6 = (int)(AppMain.GMD_MAP_DRAW_HEIGHT + 2U + AppMain.gm_map_draw_margin_adjust * 2U);
        int num7 = num3 - (num5 >> 1);
        int num8 = num3 + (num5 >> 1);
        int num9 = num4 - (num6 >> 1);
        int num10 = num4 + (num6 >> 1);
        if ( num7 < 0 )
        {
            if ( !loop_h )
            {
                num7 = 0;
            }
            else
            {
                num7 += ( int )mp_header.map_w;
                num = ( float )( -( float )( mp_header.map_w << 6 ) );
            }
        }
        else if ( num7 >= ( int )mp_header.map_w )
        {
            if ( !loop_h )
            {
                num7 = ( int )mp_header.map_w - num5;
            }
            else
            {
                num7 -= ( int )mp_header.map_w;
                num = ( float )( mp_header.map_w << 6 );
            }
        }
        if ( num9 < 0 )
        {
            num9 = 0;
        }
        if ( num8 >= ( int )mp_header.map_w )
        {
            if ( !loop_h )
            {
                num8 = ( int )( mp_header.map_w - 1 );
            }
            else
            {
                num8 -= ( int )mp_header.map_w;
                num2 = ( float )( mp_header.map_w << 6 );
            }
        }
        else if ( num8 < 0 )
        {
            if ( !loop_h )
            {
                num8 = num5;
            }
            else
            {
                num8 += ( int )mp_header.map_w;
                num2 = ( float )( -( float )( mp_header.map_w << 6 ) );
            }
        }
        if ( num10 >= ( int )mp_header.map_h )
        {
            num10 = ( int )( mp_header.map_h - 1 );
        }
        if ( num7 >= num8 )
        {
            AppMain.gmMapSetDrawMapRangeTvx( tvxamb, mp_header, md_header, trans_x + num, trans_y, trans_z, num7, ( int )( mp_header.map_w - 1 ), num9, num10, mp_block, md_block );
            AppMain.gmMapSetDrawMapRangeTvx( tvxamb, mp_header, md_header, trans_x + num2, trans_y, trans_z, 0, num8, num9, num10, mp_block, md_block );
            return;
        }
        if ( loop_h )
        {
            AppMain.gmMapSetDrawMapRangeTvx( tvxamb, mp_header, md_header, trans_x + num, trans_y, trans_z, num7, num8, num9, num10, mp_block, md_block );
            return;
        }
        AppMain.gmMapSetDrawMapRangeTvx( tvxamb, mp_header, md_header, trans_x, trans_y, trans_z, num7, num8, num9, num10, mp_block, md_block );
    }

    // Token: 0x06001896 RID: 6294 RVA: 0x000DFA40 File Offset: 0x000DDC40
    private static void gmMapSetDrawMapRangeTvx( AppMain.TVX_FILE[] tvxamb, AppMain.MP_HEADER mp_header, AppMain.MD_HEADER md_header, float trans_x, float trans_y, float trans_z, int block_left, int block_right, int block_top, int block_bottom, AppMain.MP_BLOCK _mp_block, AppMain.MD_BLOCK _md_block )
    {
        for ( int i = 0; i < 24; i++ )
        {
            for ( int j = 0; j < 24; j++ )
            {
                AppMain.gm_map_block_check[i, j] = -1;
            }
        }
        uint gmd_MAP_DRAW_WIDTH = AppMain.GMD_MAP_DRAW_WIDTH;
        uint gmd_MAP_DRAW_HEIGHT = AppMain.GMD_MAP_DRAW_HEIGHT;
        AppMain.GMS_MAP_PRIM_DRAW_WORK[] array = AppMain.gm_map_prim_draw_work;
        for ( int k = block_left; k <= block_right; k++ )
        {
            int l = block_top;
            while ( l <= block_bottom )
            {
                int num = l * (int)mp_header.map_w + k;
                AppMain.MP_BLOCK mp = mp_header.blocks[num];
                float num2 = (float)k;
                float num3 = (float)l;
                int num4 = (int)mp.id;
                if ( num4 != 0 )
                {
                    goto IL_FA;
                }
                AppMain.MD_BLOCK md_BLOCK = md_header.blocks[num];
                int ofst_x = (int)md_BLOCK.ofst_x;
                int ofst_y = (int)md_BLOCK.ofst_y;
                if ( ( ofst_x | ofst_y ) != 0 )
                {
                    num += ( int )mp_header.map_w * ofst_y + ofst_x;
                    mp = mp_header.blocks[num];
                    num4 = ( int )mp.id;
                    num2 += ( float )ofst_x;
                    num3 += ( float )ofst_y;
                    goto IL_FA;
                }
                IL_24B:
                l++;
                continue;
                IL_FA:
                if ( num4 != 0 && AppMain.gm_map_block_check[8 + ( int )num2 - block_left, 8 + ( int )num3 - block_top] == -1 )
                {
                    AppMain.gm_map_block_check[8 + ( int )num2 - block_left, 8 + ( int )num3 - block_top] = ( short )num4;
                    num4--;
                    AppMain.TVX_FILE file = tvxamb[num4];
                    uint num5 = AppMain.AoTvxGetTextureNum(file);
                    for ( uint num6 = 0U; num6 < num5; num6 += 1U )
                    {
                        uint num7 = AppMain.AoTvxGetVertexNum(file, num6);
                        int num8 = AppMain.AoTvxGetTextureId(file, num6);
                        for ( int m = 0; m < 16; m++ )
                        {
                            if ( array[m].tex_id == -1 || array[m].tex_id == num8 )
                            {
                                array[m].tex_id = num8;
                                array[m].all_vtx_num += num7;
                                AppMain.GMS_MAP_PRIM_DRAW_STACK gms_MAP_PRIM_DRAW_STACK = array[m].stack[(int)((UIntPtr)array[m].stack_num)];
                                gms_MAP_PRIM_DRAW_STACK.vtx = AppMain.AoTvxGetVertex( file, num6 );
                                gms_MAP_PRIM_DRAW_STACK.vtx_num = ( ushort )num7;
                                gms_MAP_PRIM_DRAW_STACK.mp = mp;
                                gms_MAP_PRIM_DRAW_STACK.dx = trans_x + ( num2 + 0.5f ) * 64f;
                                gms_MAP_PRIM_DRAW_STACK.dy = -trans_y + ( -num3 - 0.5f ) * 64f;
                                gms_MAP_PRIM_DRAW_STACK.dz = trans_z;
                                array[m].stack_num += 1U;
                                break;
                            }
                        }
                    }
                    goto IL_24B;
                }
                goto IL_24B;
            }
        }
    }

    // Token: 0x06001897 RID: 6295 RVA: 0x000DFCB0 File Offset: 0x000DDEB0
    private static void gmMapExecuteDrawMapTvx( AppMain.NNS_MATRIX mtx, AppMain.NNS_TEXLIST texlist )
    {
        AppMain.AMS_PARAM_DRAW_PRIMITIVE ams_PARAM_DRAW_PRIMITIVE = AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Alloc();
        AppMain.GMS_MAP_PRIM_DRAW_WORK[] array = AppMain.gm_map_prim_draw_work;
        int[] array2 = AppMain.gm_map_prim_draw_tvx_alpha_set;
        AppMain.GMS_MAP_PRIM_DRAW_WORK[] array3 = AppMain.amDraw_GMS_MAP_PRIM_DRAW_WORK_Array_Pool.AllocArray(8);
        uint num = 0U;
        uint color = AppMain.gm_map_prim_draw_tvx_color;
        ams_PARAM_DRAW_PRIMITIVE.type = 1;
        ams_PARAM_DRAW_PRIMITIVE.ablend = 0;
        ams_PARAM_DRAW_PRIMITIVE.bldMode = 32774;
        ams_PARAM_DRAW_PRIMITIVE.aTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.zMask = 0;
        ams_PARAM_DRAW_PRIMITIVE.zTest = 1;
        ams_PARAM_DRAW_PRIMITIVE.noSort = 1;
        ams_PARAM_DRAW_PRIMITIVE.uwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.vwrap = 1;
        ams_PARAM_DRAW_PRIMITIVE.format3D = 4;
        ams_PARAM_DRAW_PRIMITIVE.texlist = texlist;
        uint num2 = 0U;
        while ( num2 < 16U && array[( int )( ( UIntPtr )num2 )].tex_id != -1 )
        {
            if ( array2 != null && array2[array[( int )( ( UIntPtr )num2 )].tex_id] != 0 )
            {
                if ( num >= 8U )
                {
                    break;
                }
                array3[( int )( ( UIntPtr )num )] = array[( int )( ( UIntPtr )num2 )];
                array3[( int )( ( UIntPtr )num )].op = ( uint )array2[array[( int )( ( UIntPtr )num2 )].tex_id];
                num += 1U;
            }
            else
            {
                ams_PARAM_DRAW_PRIMITIVE.count = ( int )( array[( int )( ( UIntPtr )num2 )].all_vtx_num + array[( int )( ( UIntPtr )num2 )].stack_num * 2U - 2U );
                AppMain.NNS_PRIM3D_PCT_ARRAY v_tbl_array = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(ams_PARAM_DRAW_PRIMITIVE.count);
                AppMain.gmMapExecuteDrawMapTvxCore( mtx, array[( int )( ( UIntPtr )num2 )], ams_PARAM_DRAW_PRIMITIVE, v_tbl_array, color );
            }
            num2 += 1U;
        }
        if ( array2 != null )
        {
            int num3 = 0;
            while ( ( long )num3 < ( long )( ( ulong )num ) )
            {
                switch ( array3[num3].op )
                {
                    case 1U:
                        ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
                        ams_PARAM_DRAW_PRIMITIVE.bldDst = 771;
                        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
                        ams_PARAM_DRAW_PRIMITIVE.aTest = 1;
                        break;
                    case 2U:
                        ams_PARAM_DRAW_PRIMITIVE.bldSrc = 770;
                        ams_PARAM_DRAW_PRIMITIVE.bldDst = 1;
                        ams_PARAM_DRAW_PRIMITIVE.ablend = 1;
                        ams_PARAM_DRAW_PRIMITIVE.aTest = 0;
                        break;
                }
                ams_PARAM_DRAW_PRIMITIVE.count = ( int )( array3[num3].all_vtx_num + array3[num3].stack_num * 2U - 2U );
                AppMain.NNS_PRIM3D_PCT_ARRAY v_tbl_array2 = AppMain.amDrawAlloc_NNS_PRIM3D_PCT(ams_PARAM_DRAW_PRIMITIVE.count);
                AppMain.gmMapExecuteDrawMapTvxCore( mtx, array3[num3], ams_PARAM_DRAW_PRIMITIVE, v_tbl_array2, color );
                num3++;
            }
        }
        AppMain.GlobalPool<AppMain.AMS_PARAM_DRAW_PRIMITIVE>.Release( ams_PARAM_DRAW_PRIMITIVE );
    }

    // Token: 0x06001898 RID: 6296 RVA: 0x000DFE98 File Offset: 0x000DE098
    private static void gmMapExecuteDrawMapTvxCore( AppMain.NNS_MATRIX mtx, AppMain.GMS_MAP_PRIM_DRAW_WORK work, AppMain.AMS_PARAM_DRAW_PRIMITIVE dat, AppMain.NNS_PRIM3D_PCT_ARRAY v_tbl_array, uint color )
    {
        int num = v_tbl_array.offset;
        AppMain.NNS_PRIM3D_PCT[] buffer = v_tbl_array.buffer;
        dat.vtxPCT3D = v_tbl_array;
        dat.texId = work.tex_id;
        AppMain.NNS_TEXCOORD nns_TEXCOORD;
        AppMain.gmMapGetDrawMapTvxTexScrollUV( dat.texId, out nns_TEXCOORD );
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        for ( uint num2 = 0U; num2 < work.stack_num; num2 += 1U )
        {
            AppMain.GMS_MAP_PRIM_DRAW_STACK gms_MAP_PRIM_DRAW_STACK = work.stack[(int)((UIntPtr)num2)];
            ushort num3 = (ushort)(gms_MAP_PRIM_DRAW_STACK.vtx_num / 3);
            float dx = gms_MAP_PRIM_DRAW_STACK.dx;
            float dy = gms_MAP_PRIM_DRAW_STACK.dy;
            float dz = gms_MAP_PRIM_DRAW_STACK.dz;
            AppMain.NNS_MATRIX mtx2 = AppMain.gmMapGetUsePrimMatrix((int)gms_MAP_PRIM_DRAW_STACK.mp.rot, (int)gms_MAP_PRIM_DRAW_STACK.mp.flip_h | (int)gms_MAP_PRIM_DRAW_STACK.mp.flip_v << 1);
            int num4 = num;
            AppMain.AOS_TVX_VERTEX[] vtx = gms_MAP_PRIM_DRAW_STACK.vtx;
            for ( int i = 0; i < ( int )gms_MAP_PRIM_DRAW_STACK.vtx_num; i++ )
            {
                snns_VECTOR.x = vtx[i].x;
                snns_VECTOR.y = vtx[i].y;
                snns_VECTOR.z = vtx[i].z;
                int num5 = num4 + i;
                AppMain.nnTransformVector( ref buffer[num5].Pos, mtx2, ref snns_VECTOR );
                AppMain.NNS_PRIM3D_PCT[] array = buffer;
                int num6 = num5;
                array[num6].Pos.x = array[num6].Pos.x + dx;
                AppMain.NNS_PRIM3D_PCT[] array2 = buffer;
                int num7 = num5;
                array2[num7].Pos.y = array2[num7].Pos.y + dy;
                AppMain.NNS_PRIM3D_PCT[] array3 = buffer;
                int num8 = num5;
                array3[num8].Pos.z = array3[num8].Pos.z + dz;
                buffer[num5].Tex.u = vtx[i].u + nns_TEXCOORD.u;
                buffer[num5].Tex.v = vtx[i].v + nns_TEXCOORD.v;
                buffer[num5].Col = ( vtx[i].c & color );
            }
            num += ( int )( gms_MAP_PRIM_DRAW_STACK.vtx_num + 2 );
            if ( num2 != 0U )
            {
                int num9 = num4 - 1;
                buffer[num9] = buffer[num9 + 1];
            }
            if ( num2 != work.stack_num - 1U )
            {
                int num9 = num4 + (int)(gms_MAP_PRIM_DRAW_STACK.vtx_num - 1);
                buffer[num9 + 1] = buffer[num9];
            }
        }
        AppMain.amMatrixPush( mtx );
        AppMain.ObjDraw3DNNDrawPrimitive( dat, AppMain.gm_map_draw_command_state, 0, 0 );
        AppMain.amMatrixPop();
    }

    // Token: 0x06001899 RID: 6297 RVA: 0x000E0118 File Offset: 0x000DE318
    private static void gmMapBuildDrawMapTvxTexScroll()
    {
        AppMain.GMS_MAP_PRIM_DRAW_TVX_UV_WORK gms_MAP_PRIM_DRAW_TVX_UV_WORK = AppMain.gm_map_prim_draw_uv_work;
        int num = 0;
        int num2 = 0;
        int num3 = AppMain.g_gm_gamedat_zone_type_tbl[(int)AppMain.g_gs_main_sys_info.stage_id];
        switch ( num3 )
        {
            case 0:
            case 5:
                return;
            case 1:
                num = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z2_num;
                num2 = 21;
                break;
            case 2:
                num = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z3_num;
                num2 = 4;
                break;
            case 3:
                num = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z4_num;
                num2 = 9;
                break;
            case 4:
                num = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_zf_num;
                num2 = 8;
                break;
        }
        uint num4 = 32U;
        uint num5 = (uint)((ulong)num4 + (ulong)((long)(4 * num)));
        uint num6 = (uint)((ulong)num5 + (ulong)((long)(4 * num)));
        gms_MAP_PRIM_DRAW_TVX_UV_WORK = new AppMain.GMS_MAP_PRIM_DRAW_TVX_UV_WORK();
        AppMain.gm_map_prim_draw_uv_work = gms_MAP_PRIM_DRAW_TVX_UV_WORK;
        gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_num = num;
        gms_MAP_PRIM_DRAW_TVX_UV_WORK.frame_index_tbl = new uint[num];
        gms_MAP_PRIM_DRAW_TVX_UV_WORK.frame_tbl = new uint[num];
        gms_MAP_PRIM_DRAW_TVX_UV_WORK.tex_uv_index_tbl = new int[num2];
        int i = 0;
        int num7 = gms_MAP_PRIM_DRAW_TVX_UV_WORK.tex_uv_index_tbl.Length;
        while ( i < num7 )
        {
            gms_MAP_PRIM_DRAW_TVX_UV_WORK.tex_uv_index_tbl[i] = -1;
            i++;
        }
        switch ( num3 )
        {
            case 0:
            case 5:
                return;
            case 1:
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z2;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_num = AppMain.gm_map_prim_draw_tvx_mgr_tbl_z2_num;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_tbl_z2;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.uv_mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_uv_mgr_tbl_z2;
                break;
            case 2:
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z3;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_num = AppMain.gm_map_prim_draw_tvx_mgr_tbl_z3_num;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_tbl_z3;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.uv_mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_uv_mgr_tbl_z3;
                break;
            case 3:
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_z4;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_num = AppMain.gm_map_prim_draw_tvx_mgr_tbl_z4_num;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_tbl_z4;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.uv_mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_uv_mgr_tbl_z4;
                break;
            case 4:
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_index_tbl_zf;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_num = AppMain.gm_map_prim_draw_tvx_mgr_tbl_zf_num;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_mgr_tbl_zf;
                gms_MAP_PRIM_DRAW_TVX_UV_WORK.uv_mgr_tbl_addr = AppMain.gm_map_prim_draw_tvx_uv_mgr_tbl_zf;
                break;
        }
        DoubleType<uint[], AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX[]> mgr_index_tbl_addr = gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_addr;
        int[] tex_uv_index_tbl = gms_MAP_PRIM_DRAW_TVX_UV_WORK.tex_uv_index_tbl;
        for ( int j = 0; j < num; j++ )
        {
            ushort tex_id = ((GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX[])mgr_index_tbl_addr)[j].tex_id;
            ushort mgr_id = ((GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX[])mgr_index_tbl_addr)[j].mgr_id;
            for ( int k = 0; k < num2; k++ )
            {
                if ( ( int )tex_id == k )
                {
                    tex_uv_index_tbl[k] = ( int )mgr_id;
                }
            }
        }
    }

    // Token: 0x0600189A RID: 6298 RVA: 0x000E036B File Offset: 0x000DE56B
    private static void gmMapFlushDrawMapTvxTexScroll()
    {
        AppMain.gm_map_prim_draw_uv_work = null;
    }

    // Token: 0x0600189B RID: 6299 RVA: 0x000E0374 File Offset: 0x000DE574
    private static void gmMapUpdateDrawMapTvxTexScroll()
    {
        AppMain.GMS_MAP_PRIM_DRAW_TVX_UV_WORK gms_MAP_PRIM_DRAW_TVX_UV_WORK = AppMain.gm_map_prim_draw_uv_work;
        if ( gms_MAP_PRIM_DRAW_TVX_UV_WORK != null )
        {
            int mgr_index_tbl_num = gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_num;
            int[] mgr_tbl_num = gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_num;
            uint[] frame_index_tbl = gms_MAP_PRIM_DRAW_TVX_UV_WORK.frame_index_tbl;
            uint[] frame_tbl = gms_MAP_PRIM_DRAW_TVX_UV_WORK.frame_tbl;
            AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX[] array = (AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR_INDEX[])gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_index_tbl_addr;
            for ( int i = 0; i < mgr_index_tbl_num; i++ )
            {
                ushort mgr_id = array[i].mgr_id;
                AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[][] array2 = (AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[][])gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_addr;
                AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[] array3 = array2[(int)mgr_id];
                if ( ( frame_tbl[( int )mgr_id] += 1U ) >= ( uint )array3[( int )( ( UIntPtr )frame_index_tbl[( int )mgr_id] )].time )
                {
                    frame_tbl[( int )mgr_id] = 0U;
                    frame_index_tbl[( int )mgr_id] = ( uint )( ( ulong )( frame_index_tbl[( int )mgr_id] + 1U ) % ( ulong )( ( long )mgr_tbl_num[( int )mgr_id] ) );
                }
            }
        }
    }

    // Token: 0x0600189C RID: 6300 RVA: 0x000E042C File Offset: 0x000DE62C
    private static void gmMapGetDrawMapTvxTexScrollUV( int tex_id, out AppMain.NNS_TEXCOORD scr_uv )
    {
        AppMain.GMS_MAP_PRIM_DRAW_TVX_UV_WORK gms_MAP_PRIM_DRAW_TVX_UV_WORK = AppMain.gm_map_prim_draw_uv_work;
        scr_uv.u = 0f;
        scr_uv.v = 0f;
        if ( gms_MAP_PRIM_DRAW_TVX_UV_WORK != null )
        {
            int num = gms_MAP_PRIM_DRAW_TVX_UV_WORK.tex_uv_index_tbl[tex_id];
            if ( -1 != num )
            {
                AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[][] array = (AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[][])gms_MAP_PRIM_DRAW_TVX_UV_WORK.mgr_tbl_addr;
                AppMain.GMS_MAP_PRIM_DRAW_TVX_MGR[] array2 = array[num];
                AppMain.NNS_TEXCOORD[][] array3 = (AppMain.NNS_TEXCOORD[][])gms_MAP_PRIM_DRAW_TVX_UV_WORK.uv_mgr_tbl_addr;
                AppMain.NNS_TEXCOORD[] array4 = array3[num];
                uint num2 = gms_MAP_PRIM_DRAW_TVX_UV_WORK.frame_index_tbl[num];
                ushort motion_id = array2[(int)((UIntPtr)num2)].motion_id;
                scr_uv.u = array4[( int )motion_id].u;
                scr_uv.v = array4[( int )motion_id].v;
            }
        }
    }

    // Token: 0x0600189D RID: 6301 RVA: 0x000E04C8 File Offset: 0x000DE6C8
    private static void gmMapCreateUsePrimMatrix()
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        for ( int i = 0; i < 4; i++ )
        {
            AppMain.nnMakeUnitMatrix( nns_MATRIX );
            AppMain.nnRotateZMatrix( nns_MATRIX, nns_MATRIX, i * 16384 );
            for ( int j = 0; j < 4; j++ )
            {
                AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.gm_map_use_prim_mtx[i * 4 + j];
                AppMain.nnCopyMatrix( nns_MATRIX2, nns_MATRIX );
                switch ( j )
                {
                    case 0:
                        AppMain.nnScaleMatrix( nns_MATRIX2, nns_MATRIX2, 1f, 1f, 1f );
                        break;
                    case 1:
                        AppMain.nnScaleMatrix( nns_MATRIX2, nns_MATRIX2, -1f, 1f, 1f );
                        break;
                    case 2:
                        AppMain.nnScaleMatrix( nns_MATRIX2, nns_MATRIX2, 1f, -1f, 1f );
                        break;
                    case 3:
                        AppMain.nnScaleMatrix( nns_MATRIX2, nns_MATRIX2, -1f, -1f, 1f );
                        break;
                }
                AppMain.nnTranslateMatrix( nns_MATRIX2, nns_MATRIX2, -32f, -32f, 0f );
            }
        }
    }

    // Token: 0x0600189E RID: 6302 RVA: 0x000E05B6 File Offset: 0x000DE7B6
    private static AppMain.NNS_MATRIX gmMapGetUsePrimMatrix( int rot, int flip )
    {
        return AppMain.gm_map_use_prim_mtx[rot * 4 + flip];
    }

    // Token: 0x0600189F RID: 6303 RVA: 0x000E05C4 File Offset: 0x000DE7C4
    private static void gmMapFallShaderSettingPrioPreMidMapUserFunc( object data )
    {
        AppMain.NNS_RGBA_U8 color = new AppMain.NNS_RGBA_U8(0, 0, 0, byte.MaxValue);
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain._am_render_manager.targetp;
        if ( ams_RENDER_TARGET == AppMain._gm_mapFar_render_work )
        {
            ams_RENDER_TARGET = AppMain._am_draw_target;
        }
        else
        {
            ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
        }
        if ( ams_RENDER_TARGET.width == 0 )
        {
            return;
        }
        AppMain.amRenderCopyTarget( ams_RENDER_TARGET, color );
    }

    // Token: 0x060018A0 RID: 6304 RVA: 0x000E0610 File Offset: 0x000DE810
    private static void gmMapDrawFallShaderPrioPreMidMapUserFunc( object data )
    {
        AppMain.AMS_RENDER_TARGET ams_RENDER_TARGET = AppMain._am_render_manager.targetp;
        if ( ams_RENDER_TARGET == AppMain._gm_mapFar_render_work )
        {
            ams_RENDER_TARGET = AppMain._am_draw_target;
        }
        else
        {
            ams_RENDER_TARGET = AppMain._gm_mapFar_render_work;
        }
        if ( ams_RENDER_TARGET.width == 0 )
        {
            return;
        }
        AppMain.amDrawGetProjectionMatrix();
    }
}
