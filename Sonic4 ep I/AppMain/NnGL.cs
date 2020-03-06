using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;

public partial class AppMain
{
    // Token: 0x0200013F RID: 319
    public class NNS_VTXARRAY_GL
    {
        // Token: 0x06002089 RID: 8329 RVA: 0x0013EC16 File Offset: 0x0013CE16
        public NNS_VTXARRAY_GL()
        {
        }

        // Token: 0x0600208A RID: 8330 RVA: 0x0013EC20 File Offset: 0x0013CE20
        public NNS_VTXARRAY_GL( AppMain.NNS_VTXARRAY_GL array )
        {
            this.Type = array.Type;
            this.Size = array.Size;
            this.DataType = array.DataType;
            this.Stride = array.Stride;
            this.Pointer = array.Pointer;
            this.Data = array.Data;
        }

        // Token: 0x0600208B RID: 8331 RVA: 0x0013EC7C File Offset: 0x0013CE7C
        public static AppMain.NNS_VTXARRAY_GL Read( BinaryReader reader, ByteBuffer vertexBuffer, uint vertexBufferOffset, int nVertex )
        {
            AppMain.NNS_VTXARRAY_GL nns_VTXARRAY_GL = new AppMain.NNS_VTXARRAY_GL();
            nns_VTXARRAY_GL.Type = reader.ReadUInt32();
            nns_VTXARRAY_GL.Size = reader.ReadInt32();
            nns_VTXARRAY_GL.DataType = reader.ReadUInt32();
            nns_VTXARRAY_GL.Stride = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                nns_VTXARRAY_GL.Pointer = vertexBuffer + ( int )( num - vertexBufferOffset );
            }
            return nns_VTXARRAY_GL;
        }

        // Token: 0x04004D18 RID: 19736
        public uint Type;

        // Token: 0x04004D19 RID: 19737
        public int Size;

        // Token: 0x04004D1A RID: 19738
        public uint DataType;

        // Token: 0x04004D1B RID: 19739
        public int Stride;

        // Token: 0x04004D1C RID: 19740
        public ByteBuffer Pointer;

        // Token: 0x04004D1D RID: 19741
        public OpenGL.GLVertexData Data;
    }

    // Token: 0x02000140 RID: 320
    public class NNS_VTXLIST_GL_DESC
    {
        // Token: 0x0600208C RID: 8332 RVA: 0x0013ECDC File Offset: 0x0013CEDC
        public static AppMain.NNS_VTXLIST_GL_DESC Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = new AppMain.NNS_VTXLIST_GL_DESC();
            nns_VTXLIST_GL_DESC.Type = reader.ReadUInt32();
            nns_VTXLIST_GL_DESC.nVertex = reader.ReadInt32();
            nns_VTXLIST_GL_DESC.nArray = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            nns_VTXLIST_GL_DESC.VertexBufferSize = reader.ReadInt32();
            uint num2 = reader.ReadUInt32();
            long position = reader.BaseStream.Position;
            reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num2 ), 0 );
            byte[] array = new byte[nns_VTXLIST_GL_DESC.VertexBufferSize];
            reader.Read( array, 0, array.Length );
            nns_VTXLIST_GL_DESC.pVertexBuffer = ByteBuffer.Wrap( array );
            reader.BaseStream.Seek( position, 0 );
            if ( num != 0U )
            {
                position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                nns_VTXLIST_GL_DESC.pArray = new AppMain.NNS_VTXARRAY_GL[nns_VTXLIST_GL_DESC.nArray];
                for ( int i = 0; i < nns_VTXLIST_GL_DESC.nArray; i++ )
                {
                    nns_VTXLIST_GL_DESC.pArray[i] = AppMain.NNS_VTXARRAY_GL.Read( reader, nns_VTXLIST_GL_DESC.pVertexBuffer, num2, nns_VTXLIST_GL_DESC.nVertex );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_VTXLIST_GL_DESC.nMatrix = reader.ReadInt32();
            uint num3 = reader.ReadUInt32();
            if ( num3 != 0U )
            {
                position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num3 ), 0 );
                nns_VTXLIST_GL_DESC.pMatrixIndices = new ushort[nns_VTXLIST_GL_DESC.nMatrix];
                for ( int j = 0; j < nns_VTXLIST_GL_DESC.nMatrix; j++ )
                {
                    nns_VTXLIST_GL_DESC.pMatrixIndices[j] = reader.ReadUInt16();
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_VTXLIST_GL_DESC.BufferName = reader.ReadUInt32();
            return nns_VTXLIST_GL_DESC;
        }

        // Token: 0x0600208D RID: 8333 RVA: 0x0013EE78 File Offset: 0x0013D078
        public AppMain.NNS_VTXLIST_GL_DESC Assign( AppMain.NNS_VTXLIST_GL_DESC desc )
        {
            this.Type = desc.Type;
            this.nVertex = desc.nVertex;
            this.nArray = desc.nArray;
            this.pArray = desc.pArray;
            this.VertexBufferSize = desc.VertexBufferSize;
            this.pVertexBuffer = desc.pVertexBuffer;
            this.nMatrix = desc.nMatrix;
            this.pMatrixIndices = desc.pMatrixIndices;
            this.BufferName = desc.BufferName;
            return this;
        }

        // Token: 0x04004D1E RID: 19742
        public uint Type;

        // Token: 0x04004D1F RID: 19743
        public int nVertex;

        // Token: 0x04004D20 RID: 19744
        public int nArray;

        // Token: 0x04004D21 RID: 19745
        public AppMain.NNS_VTXARRAY_GL[] pArray;

        // Token: 0x04004D22 RID: 19746
        public int VertexBufferSize;

        // Token: 0x04004D23 RID: 19747
        public ByteBuffer pVertexBuffer;

        // Token: 0x04004D24 RID: 19748
        public int nMatrix;

        // Token: 0x04004D25 RID: 19749
        public ushort[] pMatrixIndices;

        // Token: 0x04004D26 RID: 19750
        public uint BufferName;
    }

    // Token: 0x02000141 RID: 321
    public class NNS_PRIMLIST_GL_DESC
    {
        // Token: 0x0600208F RID: 8335 RVA: 0x0013EEFC File Offset: 0x0013D0FC
        public static AppMain.NNS_PRIMLIST_GL_DESC Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC = new AppMain.NNS_PRIMLIST_GL_DESC();
            nns_PRIMLIST_GL_DESC.Mode = reader.ReadUInt32();
            uint num = reader.ReadUInt32();
            long position = reader.BaseStream.Position;
            reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
            nns_PRIMLIST_GL_DESC.pCounts = new int[1];
            nns_PRIMLIST_GL_DESC.pCounts[0] = reader.ReadInt32();
            reader.BaseStream.Seek( position, 0 );
            nns_PRIMLIST_GL_DESC.DataType = reader.ReadUInt32();
            uint num2 = reader.ReadUInt32();
            nns_PRIMLIST_GL_DESC.nPrim = reader.ReadInt32();
            nns_PRIMLIST_GL_DESC.IndexBufferSize = reader.ReadInt32();
            uint num3 = reader.ReadUInt32();
            position = reader.BaseStream.Position;
            reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num3 ), 0 );
            byte[] array = new byte[nns_PRIMLIST_GL_DESC.IndexBufferSize];
            reader.Read( array, 0, nns_PRIMLIST_GL_DESC.IndexBufferSize );
            nns_PRIMLIST_GL_DESC.pIndexBuffer = ByteBuffer.Wrap( array );
            reader.BaseStream.Seek( position, 0 );
            nns_PRIMLIST_GL_DESC.pIndices = new UShortBuffer[nns_PRIMLIST_GL_DESC.nPrim];
            position = reader.BaseStream.Position;
            reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num2 ), 0 );
            for ( int i = 0; i < nns_PRIMLIST_GL_DESC.nPrim; i++ )
            {
                uint num4 = reader.ReadUInt32();
                nns_PRIMLIST_GL_DESC.pIndices[i] = ( nns_PRIMLIST_GL_DESC.pIndexBuffer + ( int )( num4 - num3 ) ).AsUShortBuffer();
            }
            reader.BaseStream.Seek( position, 0 );
            nns_PRIMLIST_GL_DESC.BufferName = reader.ReadUInt32();
            return nns_PRIMLIST_GL_DESC;
        }

        // Token: 0x06002090 RID: 8336 RVA: 0x0013F074 File Offset: 0x0013D274
        public AppMain.NNS_PRIMLIST_GL_DESC Assign( AppMain.NNS_PRIMLIST_GL_DESC desc )
        {
            this.Mode = desc.Mode;
            this.pCounts = desc.pCounts;
            this.DataType = desc.DataType;
            this.pIndices = desc.pIndices;
            this.nPrim = desc.nPrim;
            this.IndexBufferSize = desc.IndexBufferSize;
            this.pIndexBuffer = desc.pIndexBuffer;
            this.BufferName = desc.BufferName;
            return this;
        }

        // Token: 0x04004D27 RID: 19751
        public uint Mode;

        // Token: 0x04004D28 RID: 19752
        public int[] pCounts;

        // Token: 0x04004D29 RID: 19753
        public uint DataType;

        // Token: 0x04004D2A RID: 19754
        public UShortBuffer[] pIndices;

        // Token: 0x04004D2B RID: 19755
        public int nPrim;

        // Token: 0x04004D2C RID: 19756
        public int IndexBufferSize;

        // Token: 0x04004D2D RID: 19757
        public ByteBuffer pIndexBuffer;

        // Token: 0x04004D2E RID: 19758
        public uint BufferName;
    }
}