using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x02000393 RID: 915
    public class AMS_AMB_HEADER
    {
        // Token: 0x04006100 RID: 24832
        public char[] file_id = new char[]
        {
            '#',
            'A',
            'M',
            'B'
        };

        // Token: 0x04006101 RID: 24833
        public sbyte[] flag;

        // Token: 0x04006102 RID: 24834
        public int file_num;

        // Token: 0x04006103 RID: 24835
        public string[] files;

        // Token: 0x04006104 RID: 24836
        public sbyte[] types;

        // Token: 0x04006105 RID: 24837
        public string dir = "";

        // Token: 0x04006106 RID: 24838
        public object[] buf;

        // Token: 0x04006107 RID: 24839
        public int[] offsets;

        // Token: 0x04006108 RID: 24840
        public int[] lengths;

        // Token: 0x04006109 RID: 24841
        public byte[] data;

        // Token: 0x0400610A RID: 24842
        public AppMain.AMS_AMB_HEADER parent;
    }

    // Token: 0x02000198 RID: 408
    public class AmbChunk
    {
        // Token: 0x060021E4 RID: 8676 RVA: 0x00141EA7 File Offset: 0x001400A7
        public AmbChunk()
        {
        }

        // Token: 0x060021E5 RID: 8677 RVA: 0x00141EAF File Offset: 0x001400AF
        public AmbChunk( byte[] array, int offset, int length, AppMain.AMS_AMB_HEADER parent )
        {
            this.array = array;
            this.offset = offset;
            this.length = length;
            this.amb = parent;
        }

        // Token: 0x04004F1D RID: 20253
        public AppMain.AMS_AMB_HEADER amb;

        // Token: 0x04004F1E RID: 20254
        public byte[] array;

        // Token: 0x04004F1F RID: 20255
        public int offset;

        // Token: 0x04004F20 RID: 20256
        public int length;
    }

    // Token: 0x06000746 RID: 1862 RVA: 0x0003FC40 File Offset: 0x0003DE40
    private static object amBindGet( AppMain.AMS_AMB_HEADER header, int index )
    {
        string dir;
        AppMain.AmbChunk ambChunk = AppMain.amBindGet(header, index, out dir);
        if ( header.files[index].IndexOf( ".amb", StringComparison.OrdinalIgnoreCase ) != -1 )
        {
            AppMain.AMS_AMB_HEADER ams_AMB_HEADER = AppMain.readAMBFile(ambChunk);
            ams_AMB_HEADER.dir = dir;
            return ams_AMB_HEADER;
        }
        return ambChunk;
    }

    // Token: 0x06000747 RID: 1863 RVA: 0x0003FC80 File Offset: 0x0003DE80
    private static AppMain.AmbChunk amBindGet( AppMain.AMS_AMB_HEADER header, int index, out string sPath )
    {
        sPath = null;
        AppMain.AmbChunk result = null;
        if ( index < header.file_num )
        {
            result = new AppMain.AmbChunk( header.data, header.offsets[index], header.lengths[index], header );
        }
        else
        {
            AppMain.mppAssertNotImpl();
        }
        return result;
    }

    // Token: 0x06000748 RID: 1864 RVA: 0x0003FCC0 File Offset: 0x0003DEC0
    private static AppMain.AmbChunk amBindGet( AppMain.AMS_FS header, int index )
    {
        string text;
        return AppMain.amBindGet( header, index, out text );
    }

    // Token: 0x06000749 RID: 1865 RVA: 0x0003FCD8 File Offset: 0x0003DED8
    private static AppMain.AmbChunk amBindGet( AppMain.AMS_FS header, int index, out string sPath )
    {
        sPath = null;
        byte[] array = null;
        int offset = -1;
        int length = 0;
        if ( index < header.count )
        {
            array = header.data;
            offset = header.offsets[index];
            length = header.lengths[index];
        }
        return new AppMain.AmbChunk( array, offset, length, header.amb_header );
    }

    // Token: 0x0600074A RID: 1866 RVA: 0x0003FD20 File Offset: 0x0003DF20
    public static AppMain.AmbChunk amBindSearch( AppMain.AMS_AMB_HEADER header, string filename )
    {
        for ( int i = 0; i < header.file_num; i++ )
        {
            if ( header.files[i] == filename )
            {
                return new AppMain.AmbChunk( header.data, header.offsets[i], header.lengths[i], header );
            }
        }
        return null;
    }

    // Token: 0x0600074B RID: 1867 RVA: 0x0003FD6C File Offset: 0x0003DF6C
    private static AppMain.AmbChunk amBindSearchEx( AppMain.AMS_AMB_HEADER header, string exname )
    {
        AppMain.AmbChunk result = null;
        for ( int i = 0; i < header.file_num; i++ )
        {
            if ( header.files[i].IndexOf( exname, 0, StringComparison.OrdinalIgnoreCase ) != -1 )
            {
                result = new AppMain.AmbChunk( header.data, header.offsets[i], header.lengths[i], header );
                break;
            }
        }
        return result;
    }

    // Token: 0x0600074C RID: 1868 RVA: 0x0003FDBF File Offset: 0x0003DFBF
    private byte[] amBindSearchID( ref AppMain.AMS_AMB_HEADER header, string file_id, byte[] top )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }
}