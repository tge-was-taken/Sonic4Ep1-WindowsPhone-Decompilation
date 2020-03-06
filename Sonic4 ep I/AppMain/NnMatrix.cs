using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020001E2 RID: 482
    public class MatrixPool
    {
        // Token: 0x060022F1 RID: 8945 RVA: 0x001479B8 File Offset: 0x00145BB8
        public MatrixPool()
        {
            this.cache_ = new List<AppMain.NNS_MATRIX>();
        }

        // Token: 0x060022F2 RID: 8946 RVA: 0x001479CC File Offset: 0x00145BCC
        public AppMain.NNS_MATRIX Alloc()
        {
            AppMain.NNS_MATRIX result;
            if ( this.cache_.Count > 0 )
            {
                int num = this.cache_.Count - 1;
                result = this.cache_[num];
                this.cache_.RemoveAt( num );
            }
            else
            {
                result = new AppMain.NNS_MATRIX();
            }
            return result;
        }

        // Token: 0x060022F3 RID: 8947 RVA: 0x00147A17 File Offset: 0x00145C17
        public void Release( AppMain.NNS_MATRIX obj )
        {
            this.cache_.Add( obj );
        }

        // Token: 0x040054AC RID: 21676
        private List<AppMain.NNS_MATRIX> cache_;
    }

    // Token: 0x020001E3 RID: 483
    public class NNS_MATRIXSTACK
    {
        // Token: 0x060022F4 RID: 8948 RVA: 0x00147A25 File Offset: 0x00145C25
        public NNS_MATRIXSTACK( uint uiSize )
        {
            this.stack = new List<AppMain.NNS_MATRIX>( ( int )uiSize );
        }

        // Token: 0x060022F5 RID: 8949 RVA: 0x00147A44 File Offset: 0x00145C44
        public NNS_MATRIXSTACK()
        {
            this.stack = new List<AppMain.NNS_MATRIX>( 16 );
        }

        // Token: 0x060022F6 RID: 8950 RVA: 0x00147A64 File Offset: 0x00145C64
        public void push( AppMain.NNS_MATRIX matrix )
        {
            this.invert = null;
            this.stack.Add( matrix );
        }

        // Token: 0x060022F7 RID: 8951 RVA: 0x00147A7C File Offset: 0x00145C7C
        public AppMain.NNS_MATRIX pop()
        {
            this.invert = null;
            int num = this.stack.Count - 1;
            AppMain.NNS_MATRIX result = this.stack[num];
            this.stack.RemoveAt( num );
            return result;
        }

        // Token: 0x060022F8 RID: 8952 RVA: 0x00147AB8 File Offset: 0x00145CB8
        public AppMain.NNS_MATRIX get()
        {
            if ( this.stack.Count == 0 )
            {
                return this.identity;
            }
            return this.stack[this.stack.Count - 1];
        }

        // Token: 0x060022F9 RID: 8953 RVA: 0x00147AE6 File Offset: 0x00145CE6
        public void set( AppMain.NNS_MATRIX mtx )
        {
            if ( this.stack.Count > 0 )
            {
                this.stack[this.stack.Count - 1] = mtx;
                return;
            }
            this.push( mtx );
        }

        // Token: 0x060022FA RID: 8954 RVA: 0x00147B17 File Offset: 0x00145D17
        public void clear()
        {
            this.stack.Clear();
        }

        // Token: 0x060022FB RID: 8955 RVA: 0x00147B24 File Offset: 0x00145D24
        public AppMain.NNS_MATRIX getInvert()
        {
            if ( this.invert == null )
            {
                AppMain.NNS_MATRIX src = this.get();
                this.invert = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
                AppMain.nnInvertMatrix( this.invert, src );
            }
            return this.invert;
        }

        // Token: 0x040054AD RID: 21677
        private readonly AppMain.NNS_MATRIX identity = AppMain.NNS_MATRIX.CreateIdentity();

        // Token: 0x040054AE RID: 21678
        private List<AppMain.NNS_MATRIX> stack;

        // Token: 0x040054AF RID: 21679
        private AppMain.NNS_MATRIX invert;
    }
}