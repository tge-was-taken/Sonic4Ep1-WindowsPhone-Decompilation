using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public partial class AppMain
{
    // Token: 0x020002F9 RID: 761
    public class YSDS_HEADER
    {
        // Token: 0x0600251D RID: 9501 RVA: 0x0014BAC8 File Offset: 0x00149CC8
        public YSDS_HEADER( byte[] data )
        {
            using ( MemoryStream memoryStream = new MemoryStream( data ) )
            {
                using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
                {
                    this.masic = binaryReader.ReadBytes( 4 );
                    this.page_num = binaryReader.ReadUInt32();
                    this.pages = AppMain.New<AppMain.YSDS_PAGE>( ( int )this.page_num );
                    int num = 0;
                    while ( ( long )num < ( long )( ( ulong )this.page_num ) )
                    {
                        this.pages[num].time = binaryReader.ReadUInt32();
                        this.pages[num].show = binaryReader.ReadInt32();
                        this.pages[num].hide = binaryReader.ReadInt32();
                        this.pages[num].option = binaryReader.ReadUInt32();
                        this.pages[num].line_num = binaryReader.ReadUInt32();
                        this.pages[num].line_tbl_ofst = binaryReader.ReadUInt32();
                        this.pages[num].lines = AppMain.New<AppMain.YSDS_LINE>( ( int )this.pages[num].line_num );
                        num++;
                    }
                    int num2 = 0;
                    while ( ( long )num2 < ( long )( ( ulong )this.page_num ) )
                    {
                        binaryReader.BaseStream.Seek( ( long )( ( ulong )this.pages[num2].line_tbl_ofst ), 0 );
                        int num3 = 0;
                        while ( ( long )num3 < ( long )( ( ulong )this.pages[num2].line_num ) )
                        {
                            this.pages[num2].lines[num3].id = binaryReader.ReadUInt32();
                            this.pages[num2].lines[num3].str_ofst = binaryReader.ReadUInt32();
                            num3++;
                        }
                        num2++;
                    }
                    int num4 = 0;
                    while ( ( long )num4 < ( long )( ( ulong )this.page_num ) )
                    {
                        int num5 = 0;
                        while ( ( long )num5 < ( long )( ( ulong )this.pages[num4].line_num ) )
                        {
                            binaryReader.BaseStream.Seek( ( long )( ( ulong )this.pages[num4].lines[num5].str_ofst ), 0 );
                            this.pages[num4].lines[num5].s = AppMain.readChars( binaryReader );
                            num5++;
                        }
                        num4++;
                    }
                }
            }
        }

        // Token: 0x04005D02 RID: 23810
        public byte[] masic;

        // Token: 0x04005D03 RID: 23811
        public uint page_num;

        // Token: 0x04005D04 RID: 23812
        public AppMain.YSDS_PAGE[] pages;
    }

    // Token: 0x020002FA RID: 762
    public class YSDS_PAGE
    {
        // Token: 0x04005D05 RID: 23813
        public uint time;

        // Token: 0x04005D06 RID: 23814
        public int show;

        // Token: 0x04005D07 RID: 23815
        public int hide;

        // Token: 0x04005D08 RID: 23816
        public uint option;

        // Token: 0x04005D09 RID: 23817
        public uint line_num;

        // Token: 0x04005D0A RID: 23818
        public uint line_tbl_ofst;

        // Token: 0x04005D0B RID: 23819
        public AppMain.YSDS_LINE[] lines;
    }

    // Token: 0x020002FB RID: 763
    public class YSDS_LINE
    {
        // Token: 0x04005D0C RID: 23820
        public uint id;

        // Token: 0x04005D0D RID: 23821
        public uint str_ofst;

        // Token: 0x04005D0E RID: 23822
        public string s;
    }

    // Token: 0x0600151A RID: 5402 RVA: 0x000B88DE File Offset: 0x000B6ADE
    private static bool AoYsdFileIsYsdFile( object file )
    {
        return file is AppMain.YSDS_HEADER;
    }

    // Token: 0x0600151B RID: 5403 RVA: 0x000B88E9 File Offset: 0x000B6AE9
    private static uint AoYsdFileGetPageNum( AppMain.YSDS_HEADER file )
    {
        if ( !AppMain.AoYsdFileIsYsdFile( file ) )
        {
            return 0U;
        }
        return file.page_num;
    }

    // Token: 0x0600151C RID: 5404 RVA: 0x000B88FB File Offset: 0x000B6AFB
    private static uint AoYsdFileGetPageTime( AppMain.YSDS_HEADER file, uint page_no )
    {
        if ( page_no >= AppMain.AoYsdFileGetPageNum( file ) )
        {
            return 0U;
        }
        return file.pages[( int )( ( UIntPtr )page_no )].time;
    }

    // Token: 0x0600151D RID: 5405 RVA: 0x000B8916 File Offset: 0x000B6B16
    private static bool AoYsdFileIsPageShowImage( AppMain.YSDS_HEADER file, uint page_no )
    {
        return page_no < AppMain.AoYsdFileGetPageNum( file ) && file.pages[( int )( ( UIntPtr )page_no )].show >= 0;
    }

    // Token: 0x0600151E RID: 5406 RVA: 0x000B8937 File Offset: 0x000B6B37
    private static uint AoYsdFileGetPageShowImageNo( AppMain.YSDS_HEADER file, uint page_no )
    {
        if ( !AppMain.AoYsdFileIsPageShowImage( file, page_no ) )
        {
            return 0U;
        }
        return ( uint )file.pages[( int )( ( UIntPtr )page_no )].show;
    }

    // Token: 0x0600151F RID: 5407 RVA: 0x000B8952 File Offset: 0x000B6B52
    private static bool AoYsdFileIsPageHideImage( AppMain.YSDS_HEADER file, uint page_no )
    {
        return page_no < AppMain.AoYsdFileGetPageNum( file ) && file.pages[( int )( ( UIntPtr )page_no )].hide >= 0;
    }

    // Token: 0x06001520 RID: 5408 RVA: 0x000B8973 File Offset: 0x000B6B73
    private static uint AoYsdFileGetPageOption( AppMain.YSDS_HEADER file, uint page_no )
    {
        if ( page_no >= AppMain.AoYsdFileGetPageNum( file ) )
        {
            return 0U;
        }
        return file.pages[( int )( ( UIntPtr )page_no )].option;
    }

    // Token: 0x06001521 RID: 5409 RVA: 0x000B898E File Offset: 0x000B6B8E
    private static uint AoYsdFileGetLineNum( AppMain.YSDS_HEADER file, uint page_no )
    {
        return file.pages[( int )( ( UIntPtr )page_no )].line_num;
    }

    // Token: 0x06001522 RID: 5410 RVA: 0x000B899E File Offset: 0x000B6B9E
    private static uint AoYsdFileGetLineId( AppMain.YSDS_HEADER file, uint page_no, uint line_no )
    {
        return file.pages[( int )( ( UIntPtr )page_no )].lines[( int )( ( UIntPtr )line_no )].id;
    }

    // Token: 0x06001523 RID: 5411 RVA: 0x000B89B6 File Offset: 0x000B6BB6
    private static string AoYsdFileGetLineString( AppMain.YSDS_HEADER file, uint page_no, uint line_no )
    {
        return file.pages[( int )( ( UIntPtr )page_no )].lines[( int )( ( UIntPtr )line_no )].s;
    }
}
