using System;
using System.Collections.Generic;
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
    // Token: 0x020001DD RID: 477
    public class NNS_PRIM3D_PCT_VertexData : OpenGL.GLVertexData
    {
        // Token: 0x060022D3 RID: 8915 RVA: 0x00146F20 File Offset: 0x00145120
        public NNS_PRIM3D_PCT_VertexData()
        {
            OpenGL.GLVertexElementType[] array = new OpenGL.GLVertexElementType[1];
            this.compType_ = array;
            //base..ctor();
        }

        // Token: 0x060022D4 RID: 8916 RVA: 0x00146F44 File Offset: 0x00145144
        public NNS_PRIM3D_PCT_VertexData( AppMain.NNS_PRIM3D_PCT[] data, int startIndex )
        {
            OpenGL.GLVertexElementType[] array = new OpenGL.GLVertexElementType[1];
            this.compType_ = array;
            //base..ctor();
            this.data_ = data;
            this.startIndex_ = startIndex;
        }

        // Token: 0x060022D5 RID: 8917 RVA: 0x00146F73 File Offset: 0x00145173
        public void Init( AppMain.NNS_PRIM3D_PCT[] data, int startIndex )
        {
            this.data_ = data;
            this.startIndex_ = startIndex;
        }

        // Token: 0x170000A2 RID: 162
        // (get) Token: 0x060022D6 RID: 8918 RVA: 0x00146F83 File Offset: 0x00145183
        public OpenGL.GLVertexElementType[] DataComponents
        {
            get
            {
                return this.compType_;
            }
        }

        // Token: 0x170000A3 RID: 163
        // (get) Token: 0x060022D7 RID: 8919 RVA: 0x00146F8B File Offset: 0x0014518B
        public int VertexCount
        {
            get
            {
                return this.data_.Length;
            }
        }

        // Token: 0x060022D8 RID: 8920 RVA: 0x00146F98 File Offset: 0x00145198
        public void ExtractTo( OpenGL.Vertex[] dst, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i].Position.X = this.data_[this.startIndex_ + i].Pos.x;
                dst[i].Position.Y = this.data_[this.startIndex_ + i].Pos.y;
                dst[i].Position.Z = this.data_[this.startIndex_ + i].Pos.z;
            }
        }

        // Token: 0x060022D9 RID: 8921 RVA: 0x00147044 File Offset: 0x00145244
        public void ExtractTo( OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i + dstOffset].Position.X = this.data_[this.startIndex_ + i].Pos.x;
                dst[i + dstOffset].Position.Y = this.data_[this.startIndex_ + i].Pos.y;
                dst[i + dstOffset].Position.Z = this.data_[this.startIndex_ + i].Pos.z;
            }
        }

        // Token: 0x04005498 RID: 21656
        private AppMain.NNS_PRIM3D_PCT[] data_;

        // Token: 0x04005499 RID: 21657
        private int startIndex_;

        // Token: 0x0400549A RID: 21658
        protected OpenGL.GLVertexElementType[] compType_;
    }

    // Token: 0x020001DE RID: 478
    public class NNS_PRIM3D_PCT_TexCoordData : OpenGL.GLVertexData
    {
        // Token: 0x060022DA RID: 8922 RVA: 0x001470F4 File Offset: 0x001452F4
        public NNS_PRIM3D_PCT_TexCoordData()
        {
        }

        // Token: 0x060022DB RID: 8923 RVA: 0x0014711C File Offset: 0x0014531C
        public NNS_PRIM3D_PCT_TexCoordData( AppMain.NNS_PRIM3D_PCT[] data, int startIndex )
        {
            this.data_ = data;
            this.startIndex_ = startIndex;
        }

        // Token: 0x060022DC RID: 8924 RVA: 0x0014714F File Offset: 0x0014534F
        public void Init( AppMain.NNS_PRIM3D_PCT[] data, int startIndex )
        {
            this.data_ = data;
            this.startIndex_ = startIndex;
        }

        // Token: 0x170000A4 RID: 164
        // (get) Token: 0x060022DD RID: 8925 RVA: 0x0014715F File Offset: 0x0014535F
        public OpenGL.GLVertexElementType[] DataComponents
        {
            get
            {
                return this.compType_;
            }
        }

        // Token: 0x170000A5 RID: 165
        // (get) Token: 0x060022DE RID: 8926 RVA: 0x00147167 File Offset: 0x00145367
        public int VertexCount
        {
            get
            {
                return this.data_.Length;
            }
        }

        // Token: 0x060022DF RID: 8927 RVA: 0x00147174 File Offset: 0x00145374
        public void ExtractTo( OpenGL.Vertex[] dst, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i].TextureCoordinate.X = this.data_[this.startIndex_ + i].Tex.u;
                dst[i].TextureCoordinate.Y = this.data_[this.startIndex_ + i].Tex.v;
            }
        }

        // Token: 0x060022E0 RID: 8928 RVA: 0x001471EC File Offset: 0x001453EC
        public void ExtractTo( OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i + dstOffset].TextureCoordinate.X = this.data_[this.startIndex_ + i].Tex.u;
                dst[i + dstOffset].TextureCoordinate.Y = this.data_[this.startIndex_ + i].Tex.v;
            }
        }

        // Token: 0x0400549B RID: 21659
        private AppMain.NNS_PRIM3D_PCT[] data_;

        // Token: 0x0400549C RID: 21660
        private int startIndex_;

        // Token: 0x0400549D RID: 21661
        protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[]
        {
            OpenGL.GLVertexElementType.TextureCoordinate0
        };
    }

    // Token: 0x020001DF RID: 479
    public class NNS_PRIM3D_PC_VertexData : OpenGL.GLVertexData
    {
        // Token: 0x060022E1 RID: 8929 RVA: 0x00147268 File Offset: 0x00145468
        public NNS_PRIM3D_PC_VertexData()
        {
            OpenGL.GLVertexElementType[] array = new OpenGL.GLVertexElementType[1];
            this.compType_ = array;
            //base..ctor();
        }

        // Token: 0x060022E2 RID: 8930 RVA: 0x0014728C File Offset: 0x0014548C
        public NNS_PRIM3D_PC_VertexData( AppMain.NNS_PRIM3D_PC[] data, int startIndex )
        {
            OpenGL.GLVertexElementType[] array = new OpenGL.GLVertexElementType[1];
            this.compType_ = array;
            //base..ctor();
            this.data_ = data;
            this.startIndex_ = startIndex;
        }

        // Token: 0x060022E3 RID: 8931 RVA: 0x001472BB File Offset: 0x001454BB
        public void Init( AppMain.NNS_PRIM3D_PC[] data, int startIndex )
        {
            this.data_ = data;
            this.startIndex_ = startIndex;
        }

        // Token: 0x170000A6 RID: 166
        // (get) Token: 0x060022E4 RID: 8932 RVA: 0x001472CB File Offset: 0x001454CB
        public OpenGL.GLVertexElementType[] DataComponents
        {
            get
            {
                return this.compType_;
            }
        }

        // Token: 0x170000A7 RID: 167
        // (get) Token: 0x060022E5 RID: 8933 RVA: 0x001472D3 File Offset: 0x001454D3
        public int VertexCount
        {
            get
            {
                return this.data_.Length;
            }
        }

        // Token: 0x060022E6 RID: 8934 RVA: 0x001472E0 File Offset: 0x001454E0
        public void ExtractTo( OpenGL.Vertex[] dst, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i].Position = ( Vector3 )this.data_[this.startIndex_ + i].Pos;
            }
        }

        // Token: 0x060022E7 RID: 8935 RVA: 0x00147324 File Offset: 0x00145524
        public void ExtractTo( OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i + dstOffset].Position = ( Vector3 )this.data_[this.startIndex_ + i].Pos;
            }
        }

        // Token: 0x0400549E RID: 21662
        private AppMain.NNS_PRIM3D_PC[] data_;

        // Token: 0x0400549F RID: 21663
        private int startIndex_;

        // Token: 0x040054A0 RID: 21664
        protected OpenGL.GLVertexElementType[] compType_;
    }
}
