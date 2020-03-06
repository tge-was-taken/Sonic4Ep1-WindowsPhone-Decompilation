using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

public partial class AppMain
{
    // Token: 0x020001F3 RID: 499
    public class AMS_FS
    {
        // Token: 0x0600230D RID: 8973 RVA: 0x00147D6A File Offset: 0x00145F6A
        public static explicit operator AppMain.AMS_AMB_HEADER( AppMain.AMS_FS fs )
        {
            return AppMain.readAMBFile( fs );
        }

        // Token: 0x0600230E RID: 8974 RVA: 0x00147D74 File Offset: 0x00145F74
        public void makeAmbHeader()
        {
            this.amb_header = new AppMain.AMS_AMB_HEADER();
            this.amb_header.dir = this.dir;
            this.amb_header.file_num = this.count;
            this.amb_header.files = new string[this.files.Length];
            this.amb_header.types = new sbyte[this.types.Length];
            this.amb_header.flag = new sbyte[this.flag.Length];
            this.amb_header.offsets = new int[this.files.Length];
            this.amb_header.lengths = new int[this.files.Length];
            this.amb_header.data = this.data;
            this.amb_header.buf = new object[this.count];
            Array.Copy( this.files, 0, this.amb_header.files, 0, this.files.Length );
            Buffer.BlockCopy( this.types, 0, this.amb_header.types, 0, this.types.Length );
            Buffer.BlockCopy( this.flag, 0, this.amb_header.flag, 0, this.flag.Length );
            Buffer.BlockCopy( this.offsets, 0, this.amb_header.offsets, 0, this.offsets.Length * 4 );
            Buffer.BlockCopy( this.lengths, 0, this.amb_header.lengths, 0, this.lengths.Length * 4 );
            AppMain.amPreLoadAmbItems( this.amb_header );
        }

        // Token: 0x04005507 RID: 21767
        public string dir;

        // Token: 0x04005508 RID: 21768
        public int count;

        // Token: 0x04005509 RID: 21769
        public string[] files;

        // Token: 0x0400550A RID: 21770
        public sbyte[] types;

        // Token: 0x0400550B RID: 21771
        public sbyte[] flag;

        // Token: 0x0400550C RID: 21772
        public sbyte type;

        // Token: 0x0400550D RID: 21773
        public byte[] data;

        // Token: 0x0400550E RID: 21774
        public int[] offsets;

        // Token: 0x0400550F RID: 21775
        public int[] lengths;

        // Token: 0x04005510 RID: 21776
        public sbyte stat;

        // Token: 0x04005511 RID: 21777
        public string file_name;

        // Token: 0x04005512 RID: 21778
        public Stream stream;

        // Token: 0x04005513 RID: 21779
        public AppMain.FsBackgroundReadComplete callback;

        // Token: 0x04005514 RID: 21780
        public AppMain.AMS_AMB_HEADER amb_header;
    }

    // Token: 0x020001F4 RID: 500
    // (Invoke) Token: 0x06002311 RID: 8977
    public delegate void FsBackgroundReadComplete( AppMain.AMS_FS fs );


    // Token: 0x06000A78 RID: 2680 RVA: 0x0005C9A2 File Offset: 0x0005ABA2
    private static bool amFsIsComplete( AppMain.AMS_FS cdfsp )
    {
        return cdfsp.stat == 3;
    }

    // Token: 0x06000A79 RID: 2681 RVA: 0x0005C9AD File Offset: 0x0005ABAD
    public static AppMain.AMS_FS amFsReadBackground( string file_name )
    {
        AppMain.FsReadSpeedBytesPerFrame = 32768;
        return AppMain.amFsReadBackground( file_name, null );
    }

    // Token: 0x06000A7A RID: 2682 RVA: 0x0005C9C0 File Offset: 0x0005ABC0
    public static AppMain.AMS_FS amFsReadBackground( string file_name, int BytesPerFrame )
    {
        AppMain.FsReadSpeedBytesPerFrame = BytesPerFrame;
        return AppMain.amFsReadBackground( file_name, null );
    }

    // Token: 0x06000A7B RID: 2683 RVA: 0x0005C9D0 File Offset: 0x0005ABD0
    public static AppMain.AMS_FS amFsReadBackground( string file_name, AppMain.FsBackgroundReadComplete callback )
    {
        AppMain.AMS_FS ams_FS;
        if ( AppMain.ams_fsList.Count > 0 && AppMain.lastReadAMS_FS != null && AppMain.lastReadAMS_FS.file_name == file_name )
        {
            ams_FS = AppMain.ams_fsList.First.Value;
            AppMain.amFsExecuteBackgroundRead();
        }
        else
        {
            ams_FS = new AppMain.AMS_FS();
            ams_FS.callback = callback;
            ams_FS.file_name = file_name;
            ams_FS.stat = 2;
            AppMain.ams_fsList.AddLast( ams_FS );
            AppMain.lastReadAMS_FS = ams_FS;
        }
        return ams_FS;
    }

    // Token: 0x06000A7C RID: 2684 RVA: 0x0005CA48 File Offset: 0x0005AC48
    private static AppMain.AMS_AMB_HEADER readAMBFile( AppMain.AMS_FS fs )
    {
        if ( fs.amb_header == null )
        {
            fs.makeAmbHeader();
        }
        return fs.amb_header;
    }

    // Token: 0x06000A7D RID: 2685 RVA: 0x0005CA5E File Offset: 0x0005AC5E
    private static AppMain.AMS_AMB_HEADER readAMBFile( object data )
    {
        if ( data is AppMain.AMS_AMB_HEADER )
        {
            return ( AppMain.AMS_AMB_HEADER )data;
        }
        if ( data is AppMain.AmbChunk )
        {
            AppMain.AmbChunk ambChunk = (AppMain.AmbChunk)data;
            return AppMain.readAMBFile( data );
        }
        return AppMain.readAMBFile( ( AppMain.AMS_FS )data );
    }

    // Token: 0x06000A7E RID: 2686 RVA: 0x0005CA90 File Offset: 0x0005AC90
    private static AppMain.AMS_AMB_HEADER readAMBFile( AppMain.AmbChunk buf )
    {
        byte[] array = buf.array;
        int offset = buf.offset;
        AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.searchPreloadedAmb(buf.amb, buf.offset);
        if ( ams_AMB_HEADER != null )
        {
            return ams_AMB_HEADER;
        }
        ams_AMB_HEADER = new AppMain.AMS_AMB_HEADER();
        using ( Stream stream = new MemoryStream( array, offset, array.Length - offset ) )
        {
            if ( offset == 0 )
            {
                ams_AMB_HEADER.data = new byte[stream.Length];
                stream.Read( ams_AMB_HEADER.data, 0, ams_AMB_HEADER.data.Length );
            }
            else
            {
                ams_AMB_HEADER.data = array;
            }
            stream.Position = 0L;
            using ( BinaryReader binaryReader = new BinaryReader( stream ) )
            {
                var tmp = binaryReader.ReadInt32();
                if ( tmp == 0x424d4123 )
                {
                    binaryReader.BaseStream.Seek( 12, SeekOrigin.Current );
                    ams_AMB_HEADER.file_num = binaryReader.ReadInt32();
                    var entryTableOffset = binaryReader.ReadInt32();
                    binaryReader.BaseStream.Seek( 4, SeekOrigin.Current );
                    var stringTableOffset = binaryReader.ReadInt32();

                    ams_AMB_HEADER.files = new string[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.types = new sbyte[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.offsets = new int[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.lengths = new int[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.buf = new object[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.flag = new sbyte[0];
                    for ( int i = 0; i < ams_AMB_HEADER.file_num; i++ )
                    {
                        binaryReader.BaseStream.Seek( entryTableOffset + ( i * 0x10 ), SeekOrigin.Begin );
                        ams_AMB_HEADER.offsets[i] = binaryReader.ReadInt32();
                        ams_AMB_HEADER.lengths[i] = binaryReader.ReadInt32();

                        binaryReader.BaseStream.Seek( stringTableOffset + ( i * 0x20 ), SeekOrigin.Begin );
                        ams_AMB_HEADER.files[i] = readChars( binaryReader );
                    }
                }
                else
                {
                    ams_AMB_HEADER.file_num = tmp;
                    ams_AMB_HEADER.files = new string[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.types = new sbyte[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.offsets = new int[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.lengths = new int[ams_AMB_HEADER.file_num];
                    ams_AMB_HEADER.buf = new object[ams_AMB_HEADER.file_num];
                    int num = binaryReader.ReadInt32();
                    ams_AMB_HEADER.flag = new sbyte[num];
                    for ( int i = 0; i < num; i++ )
                    {
                        ams_AMB_HEADER.flag[i] = binaryReader.ReadSByte();
                    }
                    for ( int j = 0; j < ams_AMB_HEADER.file_num; j++ )
                    {
                        ams_AMB_HEADER.files[j] = binaryReader.ReadString();
                        ams_AMB_HEADER.types[j] = binaryReader.ReadSByte();
                    }
                    for ( int k = 0; k < ams_AMB_HEADER.file_num; k++ )
                    {
                        ams_AMB_HEADER.offsets[k] = binaryReader.ReadInt32();
                    }
                    for ( int l = 0; l < ams_AMB_HEADER.file_num; l++ )
                    {
                        ams_AMB_HEADER.lengths[l] = binaryReader.ReadInt32();
                    }
                }
            }
            ams_AMB_HEADER.parent = buf.amb;
            AppMain.amPreLoadAmbItems( ams_AMB_HEADER );
        }
        return ams_AMB_HEADER;
    }

    // Token: 0x06000A7F RID: 2687 RVA: 0x0005CC94 File Offset: 0x0005AE94
    public static AppMain.AMS_AMB_HEADER searchPreloadedAmb( AppMain.AMS_AMB_HEADER amb, int offset )
    {
        for ( int i = 0; i < amb.file_num; i++ )
        {
            if ( amb.offsets[i] == offset && amb.buf[i] != null )
            {
                return ( AppMain.AMS_AMB_HEADER )amb.buf[i];
            }
        }
        for ( int j = 0; j < amb.file_num; j++ )
        {
            if ( amb.buf[j] is AppMain.AMS_AMB_HEADER )
            {
                AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.searchPreloadedAmb((AppMain.AMS_AMB_HEADER)amb.buf[j], offset);
                if ( ams_AMB_HEADER != null )
                {
                    return ams_AMB_HEADER;
                }
            }
        }
        return null;
    }

    // Token: 0x06000A80 RID: 2688 RVA: 0x0005CD10 File Offset: 0x0005AF10
    public static void amPreLoadAmbItems( AppMain.AMS_AMB_HEADER amb )
    {
        AppMain.AmbChunk ambChunk = new AppMain.AmbChunk(amb.data, 0, 0, amb);
        for ( int i = 0; i < amb.files.Length; i++ )
        {
            ambChunk.offset = amb.offsets[i];
            ambChunk.length = amb.lengths[i];
            string extension = Path.GetExtension(amb.files[i]);
            if ( extension == ".INM" || extension == ".INV" )
            {
                AppMain.NNS_MOTION nns_MOTION;
                AppMain.amMotionSetup( out nns_MOTION, ambChunk );
                amb.buf[i] = nns_MOTION;
            }
            else if ( extension == ".AMB" )
            {
                amb.buf[i] = AppMain.readAMBFile( ambChunk );
                AppMain.amPreLoadAmbItems( ( AppMain.AMS_AMB_HEADER )amb.buf[i] );
            }
            else if ( extension == ".AME" )
            {
                amb.buf[i] = AppMain.readAMEfile( ambChunk );
            }
        }
    }

    // Token: 0x06000A81 RID: 2689 RVA: 0x0005CDEC File Offset: 0x0005AFEC
    public static void amFsExecuteBackgroundRead()
    {
        if ( AppMain.ams_fsList.Count > 0 )
        {
            AppMain.AMS_FS value = AppMain.ams_fsList.First.Value;
            if ( value.stream == null )
            {
                value.stream = TitleContainer.OpenStream( "Content\\" + value.file_name );
                value.data = new byte[value.stream.Length];
                return;
            }
            int num = Math.Min(AppMain.FsReadSpeedBytesPerFrame, (int)value.stream.Length - (int)value.stream.Position);
            value.stream.Read( value.data, ( int )value.stream.Position, num );
            if ( value.stream.Position == value.stream.Length )
            {
                value.stream.Position = 0L;
                using ( BinaryReader binaryReader = new BinaryReader( value.stream ) )
                {
                    //23 41 4D 42
                    var tmp = binaryReader.ReadInt32();
                    if ( tmp == 0x424d4123 )
                    {
                        binaryReader.BaseStream.Seek( 12, SeekOrigin.Current );
                        value.count = binaryReader.ReadInt32();
                        var entryTableOffset = binaryReader.ReadInt32();
                        binaryReader.BaseStream.Seek( 4, SeekOrigin.Current );
                        var stringTableOffset = binaryReader.ReadInt32();

                        value.files = new string[value.count];
                        value.types = new sbyte[value.count];
                        value.offsets = new int[value.count];
                        value.lengths = new int[value.count];
                        value.flag = new sbyte[0];
                        for ( int i = 0; i < value.count; i++ )
                        {
                            binaryReader.BaseStream.Seek( entryTableOffset + ( i * 0x10 ), SeekOrigin.Begin );
                            value.offsets[i] = binaryReader.ReadInt32();
                            value.lengths[i] = binaryReader.ReadInt32();

                            binaryReader.BaseStream.Seek( stringTableOffset + ( i * 0x20 ), SeekOrigin.Begin );
                            value.files[i] = readChars( binaryReader );
                        }
                    }
                    else
                    {
                        value.count = tmp;
                        value.files = new string[value.count];
                        value.types = new sbyte[value.count];
                        value.offsets = new int[value.count];
                        value.lengths = new int[value.count];
                        int num2 = binaryReader.ReadInt32();
                        value.flag = new sbyte[num2];
                        for ( int i = 0; i < num2; i++ )
                        {
                            value.flag[i] = binaryReader.ReadSByte();
                        }
                        for ( int j = 0; j < value.count; j++ )
                        {
                            value.files[j] = binaryReader.ReadString();
                            value.types[j] = binaryReader.ReadSByte();
                        }
                        for ( int k = 0; k < value.count; k++ )
                        {
                            value.offsets[k] = binaryReader.ReadInt32();
                        }
                        for ( int l = 0; l < value.count; l++ )
                        {
                            value.lengths[l] = binaryReader.ReadInt32();
                        }
                    }
                }
                value.makeAmbHeader();
                value.stat = 3;
                value.stream = null;
                AppMain.ams_fsList.RemoveFirst();
                if ( value.callback != null )
                {
                    value.callback( value );
                }
            }
        }
    }

    // Token: 0x06000A82 RID: 2690 RVA: 0x0005D018 File Offset: 0x0005B218
    public AppMain.AMS_FS amFsReadBackground( int file_id, byte[] buf, int cache )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06000A83 RID: 2691 RVA: 0x0005D020 File Offset: 0x0005B220
    private AppMain.AMS_FS amFsReadBackground( int afs_id, string file_name, byte[] buf, int cache )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06000A84 RID: 2692 RVA: 0x0005D028 File Offset: 0x0005B228
    private AppMain.AMS_FS amFsReadFileList( int afs_id, string file_name, byte[] buf )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06000A85 RID: 2693 RVA: 0x0005D030 File Offset: 0x0005B230
    public static int amFsRead( string file_name, out byte[] buf )
    {
        int num = 0;
        using ( Stream stream = TitleContainer.OpenStream( file_name ) )
        {
            num = ( int )stream.Length;
            buf = new byte[num];
            stream.Read( buf, 0, num );
        }
        return num;
    }

    // Token: 0x06000A86 RID: 2694 RVA: 0x0005D080 File Offset: 0x0005B280
    public static byte[] amFsRead( string file_name )
    {
        byte[] array = null;
        using ( Stream stream = TitleContainer.OpenStream( "Content\\" + file_name ) )
        {
            int num = (int)stream.Length;
            array = new byte[num];
            stream.Read( array, 0, num );
        }
        return array;
    }

    // Token: 0x06000A87 RID: 2695 RVA: 0x0005D0D8 File Offset: 0x0005B2D8
    public static int amFsRead( string file_name, out Texture2D buf )
    {
        AppMain.mppAssertNotImpl();
        buf = null;
        return 0;
    }

    // Token: 0x06000A88 RID: 2696 RVA: 0x0005D0E3 File Offset: 0x0005B2E3
    private static void amFsClearRequest( AppMain.AMS_FS cdfsp )
    {
        AppMain.ams_fsList.Remove( cdfsp );
    }

    // Token: 0x06000A89 RID: 2697 RVA: 0x0005D0F1 File Offset: 0x0005B2F1
    private int amFsSearchPartition( string pname )
    {
        return -1;
    }

    // Token: 0x06000A8A RID: 2698 RVA: 0x0005D0F4 File Offset: 0x0005B2F4
    private int amFsSearchName( string fname )
    {
        return -1;
    }

    // Token: 0x06000A8B RID: 2699 RVA: 0x0005D0F7 File Offset: 0x0005B2F7
    private int amFsReadStart()
    {
        return 1;
    }

    // Token: 0x06000A8C RID: 2700 RVA: 0x0005D0FA File Offset: 0x0005B2FA
    private void amFsReadListNext( AppMain.AMS_FS cdfsp )
    {
    }

    // Token: 0x06000A8D RID: 2701 RVA: 0x0005D0FC File Offset: 0x0005B2FC
    private void amFsConvertPath( ref string out_name, ref string in_name )
    {
    }

    // Token: 0x06000A8E RID: 2702 RVA: 0x0005D0FE File Offset: 0x0005B2FE
    private string amFsGetColumn( string cp )
    {
        return cp;
    }

    // Token: 0x06000A8F RID: 2703 RVA: 0x0005D101 File Offset: 0x0005B301
    private string amFsGetNextColumn( string cp )
    {
        return this.amFsGetColumn( cp );
    }

    // Token: 0x06000A90 RID: 2704 RVA: 0x0005D10A File Offset: 0x0005B30A
    private string amFsGetNumber( string cp, int num )
    {
        return cp;
    }

    // Token: 0x06000A91 RID: 2705 RVA: 0x0005D10D File Offset: 0x0005B30D
    public string amFsGetString( string cp, string str )
    {
        return cp;
    }
}