using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{

    // Token: 0x02000367 RID: 871
    public class GlobalPool<T> where T : class, AppMain.IClearable, new()
    {
        // Token: 0x06002696 RID: 9878 RVA: 0x0014FB4C File Offset: 0x0014DD4C
        public static T Alloc()
        {
            T result;
            if ( AppMain.GlobalPool<T>.cache_.Count > 0 )
            {
                int num = AppMain.GlobalPool<T>.cache_.Count - 1;
                result = AppMain.GlobalPool<T>.cache_[num];
                result.Clear();
                AppMain.GlobalPool<T>.cache_.RemoveAt( num );
            }
            else
            {
                result = Activator.CreateInstance<T>();
            }
            return result;
        }

        // Token: 0x06002697 RID: 9879 RVA: 0x0014FBA0 File Offset: 0x0014DDA0
        public static void Release( T obj )
        {
            AppMain.GlobalPool<T>.cache_.Add( obj );
        }

        // Token: 0x04005FD9 RID: 24537
        private static List<T> cache_ = new List<T>();
    }

    // Token: 0x02000368 RID: 872
    public class SimplePool<T> where T : class, new()
    {
        // Token: 0x06002699 RID: 9881 RVA: 0x0014FBB5 File Offset: 0x0014DDB5
        public SimplePool()
        {
            this.cache_ = new List<T>();
        }

        // Token: 0x0600269A RID: 9882 RVA: 0x0014FBC8 File Offset: 0x0014DDC8
        public T Alloc()
        {
            T result;
            if ( this.cache_.Count > 0 )
            {
                int num = this.cache_.Count - 1;
                result = this.cache_[num];
                this.cache_.RemoveAt( num );
            }
            else
            {
                result = Activator.CreateInstance<T>();
            }
            return result;
        }

        // Token: 0x0600269B RID: 9883 RVA: 0x0014FC13 File Offset: 0x0014DE13
        public void Release( T obj )
        {
            this.cache_.Add( obj );
        }

        // Token: 0x04005FDA RID: 24538
        private List<T> cache_;
    }

    // Token: 0x02000369 RID: 873
    public class Pool<T> where T : class, new()
    {
        // Token: 0x0600269C RID: 9884 RVA: 0x0014FC24 File Offset: 0x0014DE24
        public T Alloc()
        {
            T t;
            if ( this.freeObjectsCount_ > 0 )
            {
                int num = this.freeObjectsCount_ - 1;
                t = this.freeObjects_[num];
                this.freeObjects_[num] = default( T );
                this.freeObjectsCount_--;
            }
            else
            {
                t = Activator.CreateInstance<T>();
            }
            if ( this.usedObjects_.Length == this.usedObjectsCount_ )
            {
                T[] array = new T[this.usedObjects_.Length * 2];
                Array.Copy( this.usedObjects_, array, this.usedObjects_.Length );
                this.usedObjects_ = array;
            }
            this.usedObjects_[this.usedObjectsCount_] = t;
            this.usedObjectsCount_++;
            return t;
        }

        // Token: 0x0600269D RID: 9885 RVA: 0x0014FCD8 File Offset: 0x0014DED8
        public void Release( T obj )
        {
            if ( this.freeObjects_.Length == this.freeObjectsCount_ )
            {
                T[] array = new T[this.freeObjects_.Length * 2];
                Array.Copy( this.freeObjects_, array, this.freeObjects_.Length );
                this.freeObjects_ = array;
            }
            this.freeObjects_[this.freeObjectsCount_] = obj;
            this.freeObjectsCount_++;
            int i = Array.IndexOf<T>(this.usedObjects_, obj);
            if ( i >= 0 )
            {
                for ( i++; i < this.usedObjectsCount_; i++ )
                {
                    this.usedObjects_[i - 1] = this.usedObjects_[i];
                }
                this.usedObjectsCount_--;
            }
        }

        // Token: 0x0600269E RID: 9886 RVA: 0x0014FD8C File Offset: 0x0014DF8C
        public void ReleaseUsedObjects()
        {
            for ( int i = 0; i < this.usedObjectsCount_; i++ )
            {
                this.freeObjects_[this.freeObjectsCount_ + i] = this.usedObjects_[i];
            }
            this.freeObjectsCount_ += this.usedObjectsCount_;
            for ( int j = 0; j < this.usedObjectsCount_; j++ )
            {
                this.usedObjects_[j] = default( T );
            }
            this.usedObjectsCount_ = 0;
        }

        // Token: 0x0600269F RID: 9887 RVA: 0x0014FE0C File Offset: 0x0014E00C
        public void Clear()
        {
            for ( int i = 0; i < this.freeObjectsCount_; i++ )
            {
                this.freeObjects_[i] = default( T );
            }
            this.freeObjectsCount_ = 0;
            for ( int j = 0; j < this.usedObjectsCount_; j++ )
            {
                this.usedObjects_[j] = default( T );
            }
            this.usedObjectsCount_ = 0;
        }

        // Token: 0x04005FDB RID: 24539
        private int freeObjectsCount_;

        // Token: 0x04005FDC RID: 24540
        private int usedObjectsCount_;

        // Token: 0x04005FDD RID: 24541
        private T[] freeObjects_ = new T[1024];

        // Token: 0x04005FDE RID: 24542
        private T[] usedObjects_ = new T[1024];
    }

    // Token: 0x0200036A RID: 874
    public class ArrayPool<T> where T : new()
    {
        // Token: 0x060026A1 RID: 9889 RVA: 0x0014FE9C File Offset: 0x0014E09C
        public T[] AllocArray( int size )
        {
            int num = -1;
            int num2 = (this.freeArrays_.Count > 0) ? this.freeArrays_[0].Length : -1;
            for ( int i = 0; i < this.freeArrays_.Count; i++ )
            {
                int num3 = this.freeArrays_[i].Length;
                if ( num3 >= size && num3 <= num2 )
                {
                    num = i;
                }
            }
            T[] array;
            if ( num >= 0 )
            {
                array = this.freeArrays_[num];
                this.freeArrays_.RemoveAt( num );
            }
            else
            {
                array = new T[size];
            }
            this.usedArrays_.Add( array );
            return array;
        }

        // Token: 0x060026A2 RID: 9890 RVA: 0x0014FF31 File Offset: 0x0014E131
        public void ReleaseArray( T[] array )
        {
            this.freeArrays_.Add( array );
            this.usedArrays_.Remove( array );
        }

        // Token: 0x060026A3 RID: 9891 RVA: 0x0014FF4C File Offset: 0x0014E14C
        public void ReleaseUsedArrays()
        {
            this.freeArrays_.AddRange( this.usedArrays_ );
            this.usedArrays_.Clear();
        }

        // Token: 0x060026A4 RID: 9892 RVA: 0x0014FF6A File Offset: 0x0014E16A
        public void Clear()
        {
            this.freeArrays_.Clear();
            this.usedArrays_.Clear();
        }

        // Token: 0x04005FDF RID: 24543
        private List<T[]> freeArrays_ = new List<T[]>();

        // Token: 0x04005FE0 RID: 24544
        private List<T[]> usedArrays_ = new List<T[]>();
    }

    // Token: 0x0200036B RID: 875
    public class ArrayPoolFast<T> where T : new()
    {
        // Token: 0x060026A6 RID: 9894 RVA: 0x0014FFA0 File Offset: 0x0014E1A0
        public T[] AllocArray( int size )
        {
            int num = -1;
            for ( int i = 0; i < this.freeArrays_.Count; i++ )
            {
                if ( size <= this.freeArrays_[i].Length )
                {
                    num = i;
                    break;
                }
            }
            T[] array;
            if ( num >= 0 )
            {
                array = this.freeArrays_[num];
                this.freeArrays_.RemoveAt( num );
            }
            else
            {
                array = new T[size];
            }
            this.usedArrays_.Add( array );
            return array;
        }

        // Token: 0x060026A7 RID: 9895 RVA: 0x0015000D File Offset: 0x0014E20D
        public void ReleaseArray( T[] array )
        {
            this.freeArrays_.Add( array );
            this.usedArrays_.Remove( array );
        }

        // Token: 0x060026A8 RID: 9896 RVA: 0x00150028 File Offset: 0x0014E228
        public void ReleaseUsedArrays()
        {
            this.freeArrays_.AddRange( this.usedArrays_ );
            this.usedArrays_.Clear();
        }

        // Token: 0x060026A9 RID: 9897 RVA: 0x00150046 File Offset: 0x0014E246
        public void Clear()
        {
            this.freeArrays_.Clear();
            this.usedArrays_.Clear();
        }

        // Token: 0x060026AA RID: 9898 RVA: 0x0015005E File Offset: 0x0014E25E
        public int GetFreeCount()
        {
            return this.freeArrays_.Count;
        }

        // Token: 0x04005FE1 RID: 24545
        private List<T[]> freeArrays_ = new List<T[]>();

        // Token: 0x04005FE2 RID: 24546
        private List<T[]> usedArrays_ = new List<T[]>();
    }

    // Token: 0x0200036C RID: 876
    public class ArrayPoolMultisize<T> where T : new()
    {
        // Token: 0x060026AC RID: 9900 RVA: 0x0015008C File Offset: 0x0014E28C
        public T[] AllocArray( int size )
        {
            int num = this._GetArrayPoolIDBestForCapacity(size);
            return this.Arrays_[num].AllocArray( size );
        }

        // Token: 0x060026AD RID: 9901 RVA: 0x001500B4 File Offset: 0x0014E2B4
        public void ReleaseArray( T[] array )
        {
            int num = this._GetArrayPoolIDBestForCapacity(array.Length);
            this.Arrays_[num].ReleaseArray( array );
        }

        // Token: 0x060026AE RID: 9902 RVA: 0x001500E0 File Offset: 0x0014E2E0
        public void ReleaseUsedArrays()
        {
            for ( int i = 0; i < this.Arrays_.Count; i++ )
            {
                this.Arrays_[i].ReleaseUsedArrays();
            }
        }

        // Token: 0x060026AF RID: 9903 RVA: 0x00150114 File Offset: 0x0014E314
        public void Clear()
        {
            for ( int i = 0; i < this.Arrays_.Count; i++ )
            {
                this.Arrays_[i].Clear();
            }
        }

        // Token: 0x060026B0 RID: 9904 RVA: 0x00150148 File Offset: 0x0014E348
        public void AddCacheWithCapacity( int iCapacity, int iAmount )
        {
            if ( this.arrayElementCapacity_.Count > 0 && this.arrayElementCapacity_[this.arrayElementCapacity_.Count - 1] > iCapacity )
            {
                throw new NotSupportedException();
            }
            this.arrayElementCapacity_.Add( iCapacity );
            AppMain.ArrayPoolFast<T> arrayPoolFast = new AppMain.ArrayPoolFast<T>();
            for ( int i = 0; i < iAmount; i++ )
            {
                arrayPoolFast.AllocArray( iCapacity );
            }
            arrayPoolFast.ReleaseUsedArrays();
            this.Arrays_.Add( arrayPoolFast );
        }

        // Token: 0x060026B1 RID: 9905 RVA: 0x001501BC File Offset: 0x0014E3BC
        private int _GetArrayPoolIDBestForCapacity( int iCapacity )
        {
            for ( int i = 0; i < this.arrayElementCapacity_.Count; i++ )
            {
                if ( iCapacity <= this.arrayElementCapacity_[i] && this.Arrays_[i].GetFreeCount() > 0 )
                {
                    return i;
                }
            }
            if ( iCapacity <= this.arrayElementCapacity_[this.arrayElementCapacity_.Count - 1] )
            {
                return this.arrayElementCapacity_.Count - 1;
            }
            this.AddCacheWithCapacity( iCapacity, 1 );
            return this.arrayElementCapacity_.Count - 1;
        }

        // Token: 0x04005FE3 RID: 24547
        private List<int> arrayElementCapacity_ = new List<int>();

        // Token: 0x04005FE4 RID: 24548
        private List<AppMain.ArrayPoolFast<T>> Arrays_ = new List<AppMain.ArrayPoolFast<T>>();
    }
}