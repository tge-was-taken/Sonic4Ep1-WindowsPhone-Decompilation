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
    // Token: 0x020001DC RID: 476
    public class Vector3_VertexData : OpenGL.GLVertexData
    {
        // Token: 0x060022CE RID: 8910 RVA: 0x00146E74 File Offset: 0x00145074
        public Vector3_VertexData( Vector3[] data )
        {
            OpenGL.GLVertexElementType[] array = new OpenGL.GLVertexElementType[1];
            this.compType_ = array;
            //base..ctor();
            this.data_ = data;
        }

        // Token: 0x170000A0 RID: 160
        // (get) Token: 0x060022CF RID: 8911 RVA: 0x00146E9C File Offset: 0x0014509C
        public OpenGL.GLVertexElementType[] DataComponents
        {
            get
            {
                return this.compType_;
            }
        }

        // Token: 0x170000A1 RID: 161
        // (get) Token: 0x060022D0 RID: 8912 RVA: 0x00146EA4 File Offset: 0x001450A4
        public int VertexCount
        {
            get
            {
                return this.data_.Length;
            }
        }

        // Token: 0x060022D1 RID: 8913 RVA: 0x00146EB0 File Offset: 0x001450B0
        public void ExtractTo( OpenGL.Vertex[] dst, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i].Position = this.data_[i];
            }
        }

        // Token: 0x060022D2 RID: 8914 RVA: 0x00146EE8 File Offset: 0x001450E8
        public void ExtractTo( OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count )
        {
            for ( int i = 0; i < count; i++ )
            {
                dst[i + dstOffset].Position = this.data_[i];
            }
        }

        // Token: 0x04005496 RID: 21654
        private Vector3[] data_;

        // Token: 0x04005497 RID: 21655
        protected OpenGL.GLVertexElementType[] compType_;
    }
}
