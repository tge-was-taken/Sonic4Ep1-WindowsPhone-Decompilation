using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000197 RID: 407
    public struct ArrayPointer<T>
    {
        // Token: 0x060021CF RID: 8655 RVA: 0x00141CA9 File Offset: 0x0013FEA9
        public ArrayPointer( T[] _array )
        {
            this = new AppMain.ArrayPointer<T>( _array, 0 );
        }

        // Token: 0x060021D0 RID: 8656 RVA: 0x00141CB3 File Offset: 0x0013FEB3
        public ArrayPointer( T[] _array, int _offset )
        {
            this.array = _array;
            this.offset = _offset;
        }

        // Token: 0x060021D1 RID: 8657 RVA: 0x00141CC3 File Offset: 0x0013FEC3
        public static AppMain.ArrayPointer<T> operator ++( AppMain.ArrayPointer<T> _pointer )
        {
            _pointer.offset++;
            return _pointer;
        }

        // Token: 0x060021D2 RID: 8658 RVA: 0x00141CD5 File Offset: 0x0013FED5
        public static AppMain.ArrayPointer<T> operator --( AppMain.ArrayPointer<T> _pointer )
        {
            _pointer.offset--;
            return _pointer;
        }

        // Token: 0x060021D3 RID: 8659 RVA: 0x00141CE7 File Offset: 0x0013FEE7
        public static AppMain.ArrayPointer<T> operator +( AppMain.ArrayPointer<T> _pointer, int _offset )
        {
            _pointer.offset += _offset;
            return _pointer;
        }

        // Token: 0x060021D4 RID: 8660 RVA: 0x00141CF9 File Offset: 0x0013FEF9
        public static AppMain.ArrayPointer<T> operator -( AppMain.ArrayPointer<T> _pointer, int _offset )
        {
            _pointer.offset -= _offset;
            return _pointer;
        }

        // Token: 0x060021D5 RID: 8661 RVA: 0x00141D0B File Offset: 0x0013FF0B
        public static bool operator <( AppMain.ArrayPointer<T> _pointer1, AppMain.ArrayPointer<T> _pointer2 )
        {
            if ( _pointer1.array != _pointer2.array )
            {
                throw new InvalidOperationException();
            }
            return _pointer1.offset < _pointer2.offset;
        }

        // Token: 0x060021D6 RID: 8662 RVA: 0x00141D33 File Offset: 0x0013FF33
        public static bool operator >( AppMain.ArrayPointer<T> _pointer1, AppMain.ArrayPointer<T> _pointer2 )
        {
            if ( _pointer1.array != _pointer2.array )
            {
                throw new InvalidOperationException();
            }
            return _pointer1.offset > _pointer2.offset;
        }

        // Token: 0x060021D7 RID: 8663 RVA: 0x00141D5B File Offset: 0x0013FF5B
        public static bool operator ==( AppMain.ArrayPointer<T> _pointer1, AppMain.ArrayPointer<T> _pointer2 )
        {
            return _pointer1.array == _pointer2.array && _pointer1.offset == _pointer2.offset;
        }

        // Token: 0x060021D8 RID: 8664 RVA: 0x00141D7F File Offset: 0x0013FF7F
        public static bool operator !=( AppMain.ArrayPointer<T> _pointer1, AppMain.ArrayPointer<T> _pointer2 )
        {
            return _pointer1.array != _pointer2.array || _pointer1.offset != _pointer2.offset;
        }

        // Token: 0x060021D9 RID: 8665 RVA: 0x00141DA6 File Offset: 0x0013FFA6
        public static T operator ~( AppMain.ArrayPointer<T> _pointer )
        {
            return _pointer.array[_pointer.offset];
        }

        // Token: 0x1700009A RID: 154
        public T this[int _index]
        {
            get
            {
                return this.array[this.offset + _index];
            }
        }

        // Token: 0x060021DB RID: 8667 RVA: 0x00141DD0 File Offset: 0x0013FFD0
        public T[] GetInternalArray()
        {
            return this.array;
        }

        // Token: 0x060021DC RID: 8668 RVA: 0x00141DD8 File Offset: 0x0013FFD8
        public AppMain.ArrayPointer<T> Clone()
        {
            AppMain.ArrayPointer<T> result = new AppMain.ArrayPointer<T>(this.array, this.offset);
            return result;
        }

        // Token: 0x060021DD RID: 8669 RVA: 0x00141DF9 File Offset: 0x0013FFF9
        public static implicit operator AppMain.ArrayPointer<T>( T[] _array )
        {
            return new AppMain.ArrayPointer<T>( _array );
        }

        // Token: 0x060021DE RID: 8670 RVA: 0x00141E01 File Offset: 0x00140001
        public static implicit operator T( AppMain.ArrayPointer<T> _pointer )
        {
            return _pointer.array[_pointer.offset];
        }

        // Token: 0x060021DF RID: 8671 RVA: 0x00141E16 File Offset: 0x00140016
        public T SetPrimitive( T value )
        {
            this.array[this.offset] = value;
            return value;
        }

        // Token: 0x060021E0 RID: 8672 RVA: 0x00141E2B File Offset: 0x0014002B
        public T SetPrimitive( int index, T value )
        {
            this.array[this.offset + index] = value;
            return value;
        }

        // Token: 0x060021E1 RID: 8673 RVA: 0x00141E42 File Offset: 0x00140042
        public override int GetHashCode()
        {
            return this.array.GetHashCode() ^ this.offset.GetHashCode();
        }

        // Token: 0x060021E2 RID: 8674 RVA: 0x00141E5C File Offset: 0x0014005C
        public override bool Equals( object obj )
        {
            if ( obj is AppMain.ArrayPointer<T> )
            {
                AppMain.ArrayPointer<T> arrayPointer = (AppMain.ArrayPointer<T>)obj;
                return arrayPointer.array == this.array && arrayPointer.offset == this.offset;
            }
            return false;
        }

        // Token: 0x04004F1A RID: 20250
        public T[] array;

        // Token: 0x04004F1B RID: 20251
        public int offset;

        // Token: 0x04004F1C RID: 20252
        public static readonly AppMain.ArrayPointer<T> NULL = default(AppMain.ArrayPointer<T>);
    }
}