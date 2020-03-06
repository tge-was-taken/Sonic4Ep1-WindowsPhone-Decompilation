using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;

public partial class AppMain
{
    // Token: 0x02000324 RID: 804
    public struct AOS_TVX_VERTEX
    {
        // Token: 0x06002593 RID: 9619 RVA: 0x0014DA68 File Offset: 0x0014BC68
        public AOS_TVX_VERTEX( byte[] data, int offset )
        {
            this.x = MppBitConverter.ToSingle( data, offset );
            this.y = MppBitConverter.ToSingle( data, offset + 4 );
            this.z = MppBitConverter.ToSingle( data, offset + 8 );
            this.c = MppBitConverter.ToUInt32( data, offset + 12 );
            this.u = MppBitConverter.ToSingle( data, offset + 16 );
            this.v = MppBitConverter.ToSingle( data, offset + 20 );
        }

        // Token: 0x170000B2 RID: 178
        // (get) Token: 0x06002594 RID: 9620 RVA: 0x0014DAD0 File Offset: 0x0014BCD0
        public static uint SizeBytes
        {
            get
            {
                return 32U;
            }
        }

        // Token: 0x04005DFA RID: 24058
        public float x;

        // Token: 0x04005DFB RID: 24059
        public float y;

        // Token: 0x04005DFC RID: 24060
        public float z;

        // Token: 0x04005DFD RID: 24061
        public uint c;

        // Token: 0x04005DFE RID: 24062
        public float u;

        // Token: 0x04005DFF RID: 24063
        public float v;
    }

    // Token: 0x02000325 RID: 805
    public struct TVXS_HEADER
    {
        // Token: 0x06002595 RID: 9621 RVA: 0x0014DAD4 File Offset: 0x0014BCD4
        public TVXS_HEADER( byte[] data, int offset )
        {
            this.tex_num = MppBitConverter.ToUInt32( data, offset + 4 );
            this.tex_tbl_ofst = MppBitConverter.ToUInt32( data, offset + 8 );
        }

        // Token: 0x170000B3 RID: 179
        // (get) Token: 0x06002596 RID: 9622 RVA: 0x0014DAF4 File Offset: 0x0014BCF4
        public static uint SizeBytes
        {
            get
            {
                return 16U;
            }
        }

        // Token: 0x04005E00 RID: 24064
        public uint tex_num;

        // Token: 0x04005E01 RID: 24065
        public uint tex_tbl_ofst;
    }

    // Token: 0x02000326 RID: 806
    public struct TVXS_TEXTURE
    {
        // Token: 0x06002597 RID: 9623 RVA: 0x0014DAF8 File Offset: 0x0014BCF8
        public TVXS_TEXTURE( byte[] data, int offset )
        {
            this.tex_id = MppBitConverter.ToInt32( data, offset );
            this.vtx_num = MppBitConverter.ToUInt32( data, offset + 4 );
            this.vtx_tbl_ofst = MppBitConverter.ToUInt32( data, offset + 8 );
            this.prim_type = MppBitConverter.ToUInt32( data, offset + 12 );
        }

        // Token: 0x170000B4 RID: 180
        // (get) Token: 0x06002598 RID: 9624 RVA: 0x0014DB35 File Offset: 0x0014BD35
        public static int SizeBytes
        {
            get
            {
                return 16;
            }
        }

        // Token: 0x04005E02 RID: 24066
        public int tex_id;

        // Token: 0x04005E03 RID: 24067
        public uint vtx_num;

        // Token: 0x04005E04 RID: 24068
        public uint vtx_tbl_ofst;

        // Token: 0x04005E05 RID: 24069
        public uint prim_type;
    }

    // Token: 0x02000327 RID: 807
    public class TVX_FILE
    {
        // Token: 0x06002599 RID: 9625 RVA: 0x0014DB3C File Offset: 0x0014BD3C
        public TVX_FILE( AppMain.AmbChunk data )
        {
            this.header = new AppMain.TVXS_HEADER( data.array, data.offset );
            this.textures = new AppMain.TVXS_TEXTURE[this.header.tex_num];
            this.vertexes = new AppMain.AOS_TVX_VERTEX[this.header.tex_num][];
            for ( int i = 0; i < this.textures.Length; i++ )
            {
                int offset = (int)((ulong)this.header.tex_tbl_ofst + (ulong)((long)(i * AppMain.TVXS_TEXTURE.SizeBytes))) + data.offset;
                this.textures[i] = new AppMain.TVXS_TEXTURE( data.array, offset );
                this.vertexes[i] = new AppMain.AOS_TVX_VERTEX[this.textures[i].vtx_num];
                int num = 0;
                while ( ( long )num < ( long )( ( ulong )this.textures[i].vtx_num ) )
                {
                    offset = ( int )( ( ulong )this.textures[i].vtx_tbl_ofst + ( ulong )( ( long )( num * ( int )AppMain.AOS_TVX_VERTEX.SizeBytes ) ) ) + data.offset;
                    this.vertexes[i][num] = new AppMain.AOS_TVX_VERTEX( data.array, offset );
                    num++;
                }
            }
        }

        // Token: 0x04005E06 RID: 24070
        public AppMain.TVXS_HEADER header;

        // Token: 0x04005E07 RID: 24071
        public AppMain.TVXS_TEXTURE[] textures;

        // Token: 0x04005E08 RID: 24072
        public AppMain.AOS_TVX_VERTEX[][] vertexes;
    }

    // Token: 0x06001629 RID: 5673 RVA: 0x000C12E9 File Offset: 0x000BF4E9
    private static bool AoTvxIsTvxFile( object file )
    {
        return true;
    }

    // Token: 0x0600162A RID: 5674 RVA: 0x000C12EC File Offset: 0x000BF4EC
    private static uint AoTvxGetTextureNum( AppMain.TVX_FILE file )
    {
        return file.header.tex_num;
    }

    // Token: 0x0600162B RID: 5675 RVA: 0x000C12F9 File Offset: 0x000BF4F9
    private static int AoTvxGetTextureId( AppMain.TVX_FILE file, uint tex_no )
    {
        return file.textures[( int )( ( UIntPtr )tex_no )].tex_id;
    }

    // Token: 0x0600162C RID: 5676 RVA: 0x000C130D File Offset: 0x000BF50D
    private static uint AoTvxGetPrimitiveType( AppMain.TVX_FILE file, uint tex_no )
    {
        return file.textures[( int )( ( UIntPtr )tex_no )].prim_type;
    }

    // Token: 0x0600162D RID: 5677 RVA: 0x000C1321 File Offset: 0x000BF521
    private static uint AoTvxGetVertexNum( AppMain.TVX_FILE file, uint tex_no )
    {
        return file.textures[( int )( ( UIntPtr )tex_no )].vtx_num;
    }

    // Token: 0x0600162E RID: 5678 RVA: 0x000C1335 File Offset: 0x000BF535
    private static AppMain.AOS_TVX_VERTEX[] AoTvxGetVertex( AppMain.TVX_FILE file, uint tex_no )
    {
        return file.vertexes[( int )( ( UIntPtr )tex_no )];
    }
}
