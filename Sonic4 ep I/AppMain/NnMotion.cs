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

    // Token: 0x02000160 RID: 352
    public class NNS_SUBMOTION
    {
        // Token: 0x17000071 RID: 113
        // (get) Token: 0x060020E0 RID: 8416 RVA: 0x0013FC36 File Offset: 0x0013DE36
        // (set) Token: 0x060020E1 RID: 8417 RVA: 0x0013FC45 File Offset: 0x0013DE45
        public short Id0
        {
            get
            {
                return ( short )( this.Id & 65535 );
            }
            set
            {
                this.Id = ( ( this.Id & -65536 ) | ( ( int )value & 65535 ) );
            }
        }

        // Token: 0x17000072 RID: 114
        // (get) Token: 0x060020E2 RID: 8418 RVA: 0x0013FC61 File Offset: 0x0013DE61
        // (set) Token: 0x060020E3 RID: 8419 RVA: 0x0013FC73 File Offset: 0x0013DE73
        public short Id1
        {
            get
            {
                return ( short )( this.Id >> 16 & 65535 );
            }
            set
            {
                this.Id = ( ( this.Id & 65535 ) | ( int )value << 16 );
            }
        }

        // Token: 0x060020E4 RID: 8420 RVA: 0x0013FC8C File Offset: 0x0013DE8C
        public NNS_SUBMOTION()
        {
        }

        // Token: 0x060020E5 RID: 8421 RVA: 0x0013FC94 File Offset: 0x0013DE94
        public NNS_SUBMOTION( AppMain.NNS_SUBMOTION subMotion )
        {
            this.fType = subMotion.fType;
            this.fIPType = subMotion.fIPType;
            this.Id = subMotion.Id;
            this.StartFrame = subMotion.StartFrame;
            this.EndFrame = subMotion.EndFrame;
            this.StartKeyFrame = subMotion.StartKeyFrame;
            this.EndKeyFrame = subMotion.EndKeyFrame;
            this.nKeyFrame = subMotion.nKeyFrame;
            this.KeySize = subMotion.KeySize;
            this.pKeyList = subMotion.pKeyList;
        }

        // Token: 0x060020E6 RID: 8422 RVA: 0x0013FD20 File Offset: 0x0013DF20
        public AppMain.NNS_SUBMOTION Assign( AppMain.NNS_SUBMOTION subMotion )
        {
            if ( this != subMotion )
            {
                this.fType = subMotion.fType;
                this.fIPType = subMotion.fIPType;
                this.Id = subMotion.Id;
                this.StartFrame = subMotion.StartFrame;
                this.EndFrame = subMotion.EndFrame;
                this.StartKeyFrame = subMotion.StartKeyFrame;
                this.EndKeyFrame = subMotion.EndKeyFrame;
                this.nKeyFrame = subMotion.nKeyFrame;
                this.KeySize = subMotion.KeySize;
                this.pKeyList = subMotion.pKeyList;
            }
            return this;
        }

        // Token: 0x060020E7 RID: 8423 RVA: 0x0013FDAC File Offset: 0x0013DFAC
        public static AppMain.NNS_SUBMOTION Read( BinaryReader reader, uint motionType, long data0Pos )
        {
            AppMain.NNS_SUBMOTION nns_SUBMOTION = new AppMain.NNS_SUBMOTION();
            nns_SUBMOTION.fType = reader.ReadUInt32();
            nns_SUBMOTION.fIPType = reader.ReadUInt32();
            nns_SUBMOTION.Id = reader.ReadInt32();
            nns_SUBMOTION.StartFrame = reader.ReadSingle();
            nns_SUBMOTION.EndFrame = reader.ReadSingle();
            nns_SUBMOTION.StartKeyFrame = reader.ReadSingle();
            nns_SUBMOTION.EndKeyFrame = reader.ReadSingle();
            nns_SUBMOTION.nKeyFrame = reader.ReadInt32();
            nns_SUBMOTION.KeySize = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                switch ( motionType )
                {
                    case 1U:
                        AppMain.NNS_SUBMOTION.ReadNodeMotionKeyFrames( reader, nns_SUBMOTION );
                        break;
                    case 2U:
                        AppMain.NNS_SUBMOTION.ReadCameraMotionKeyFrames( reader, nns_SUBMOTION );
                        break;
                    case 3U:
                        break;
                    case 4U:
                        AppMain.NNS_SUBMOTION.ReadLightMotionKeyFrames( reader, nns_SUBMOTION );
                        break;
                    default:
                        if ( motionType != 8U )
                        {
                            if ( motionType == 16U )
                            {
                                AppMain.NNS_SUBMOTION.ReadMaterialMotionKeyFrames( reader, nns_SUBMOTION );
                            }
                        }
                        else
                        {
                            AppMain.NNS_SUBMOTION.ReadMorthMotionKeyFrames( reader, nns_SUBMOTION );
                        }
                        break;
                }
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_SUBMOTION;
        }

        // Token: 0x060020E8 RID: 8424 RVA: 0x0013FEB4 File Offset: 0x0013E0B4
        private static void ReadNodeMotionKeyFrames( BinaryReader reader, AppMain.NNS_SUBMOTION submotion )
        {
            uint num = submotion.fType & 3U;
            uint num2 = submotion.fType;
            uint num3 = submotion.fType & 4294967040U;
            uint num4 = submotion.fIPType & 3703U;
            if ( ( num3 & 1792U ) != 0U )
            {
                if ( 1U == num )
                {
                    uint num5 = num4;
                    if ( num5 != 1U && num5 != 16U )
                    {
                        submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class1.Read( reader, submotion.nKeyFrame );
                        return;
                    }
                    throw new NotImplementedException( "Investigation needed" );
                }
                else
                {
                    if ( 2U == num )
                    {
                        throw new NotImplementedException( "Investigation needed" );
                    }
                    throw new NotImplementedException( "Investigation needed" );
                }
            }
            else if ( ( num3 & 30720U ) != 0U )
            {
                if ( 1U == num )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                if ( 2U != num )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                uint num6 = num4;
                if ( num6 != 1U )
                {
                    submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class14.Read( reader, submotion.nKeyFrame );
                    return;
                }
                throw new NotImplementedException( "Investigation needed" );
            }
            else if ( ( num3 & 229376U ) != 0U )
            {
                if ( 1U == num )
                {
                    uint num7 = num4;
                    if ( num7 != 1U && num7 != 16U )
                    {
                        submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class1.Read( reader, submotion.nKeyFrame );
                        return;
                    }
                    throw new NotImplementedException( "Investigation needed" );
                }
                else
                {
                    if ( 2U == num )
                    {
                        throw new NotImplementedException( "Investigation needed" );
                    }
                    throw new NotImplementedException( "Investigation needed" );
                }
            }
            else if ( ( num3 & 786432U ) != 0U )
            {
                if ( 1U == num )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                if ( 2U == num )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                throw new NotImplementedException( "Investigation needed" );
            }
            else
            {
                if ( ( num3 & 1048576U ) == 0U )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                if ( 1U == num )
                {
                    submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class11.Read( reader, submotion.nKeyFrame );
                    return;
                }
                if ( 2U != num )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                if ( submotion.KeySize == 8 )
                {
                    submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class16.Read( reader, submotion.nKeyFrame );
                    return;
                }
                throw new NotImplementedException( "Investigation needed" );
            }
        }

        // Token: 0x060020E9 RID: 8425 RVA: 0x0014006D File Offset: 0x0013E26D
        private static void ReadCameraMotionKeyFrames( BinaryReader reader, AppMain.NNS_SUBMOTION submotion )
        {
            uint num = submotion.fType;
            uint num2 = submotion.fType;
            uint num3 = submotion.fType;
            uint num4 = submotion.fIPType;
            throw new NotImplementedException();
        }

        // Token: 0x060020EA RID: 8426 RVA: 0x00140090 File Offset: 0x0013E290
        private static void ReadLightMotionKeyFrames( BinaryReader reader, AppMain.NNS_SUBMOTION submotion )
        {
            uint num = submotion.fType;
            uint num2 = submotion.fType;
            uint num3 = submotion.fType;
            uint num4 = submotion.fIPType;
            throw new NotImplementedException();
        }

        // Token: 0x060020EB RID: 8427 RVA: 0x001400B3 File Offset: 0x0013E2B3
        private static void ReadMorthMotionKeyFrames( BinaryReader reader, AppMain.NNS_SUBMOTION submotion )
        {
            uint num = submotion.fType;
            uint num2 = submotion.fType;
            uint num3 = submotion.fType;
            uint num4 = submotion.fIPType;
            throw new NotImplementedException();
        }

        // Token: 0x060020EC RID: 8428 RVA: 0x001400D8 File Offset: 0x0013E2D8
        private static void ReadMaterialMotionKeyFrames( BinaryReader reader, AppMain.NNS_SUBMOTION submotion )
        {
            uint num = submotion.fType;
            uint num2 = submotion.fType;
            uint num3 = submotion.fType & 4294967040U;
            uint num4 = submotion.fIPType & 3703U;
            if ( ( num3 & 256U ) != 0U )
            {
                throw new NotImplementedException( "Investigation needed" );
            }
            if ( ( num3 & 3584U ) != 0U )
            {
                uint num5 = num4;
                if ( num5 != 1U && num5 != 16U )
                {
                    int keySize = submotion.KeySize;
                    if ( keySize == 8 )
                    {
                        submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class1.Read( reader, submotion.nKeyFrame );
                        return;
                    }
                    if ( keySize != 12 )
                    {
                        if ( keySize == 16 )
                        {
                            submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class5.Read( reader, submotion.nKeyFrame );
                            return;
                        }
                    }
                }
                throw new NotImplementedException( "Investigation needed" );
            }
            if ( ( num3 & 4096U ) != 0U )
            {
                throw new NotImplementedException( "Investigation needed" );
            }
            if ( ( num3 & 57344U ) != 0U )
            {
                uint num6 = num4;
                if ( num6 != 1U && num6 != 16U )
                {
                    submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class5.Read( reader, submotion.nKeyFrame );
                    return;
                }
                throw new NotImplementedException( "Investigation needed" );
            }
            else
            {
                if ( ( num3 & 65536U ) != 0U )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                if ( ( num3 & 131072U ) != 0U )
                {
                    throw new NotImplementedException( "Investigation needed" );
                }
                if ( ( num3 & 1835008U ) != 0U )
                {
                    uint num7 = num4;
                    if ( num7 != 1U && num7 != 16U )
                    {
                        submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class5.Read( reader, submotion.nKeyFrame );
                        return;
                    }
                    throw new NotImplementedException( "Investigation needed" );
                }
                else
                {
                    if ( ( num3 & 2097152U ) != 0U )
                    {
                        throw new NotImplementedException( "Investigation needed" );
                    }
                    if ( ( num3 & 4194304U ) != 0U )
                    {
                        uint num8 = num4;
                        if ( num8 == 1U || num8 == 16U )
                        {
                            return;
                        }
                        int keySize2 = submotion.KeySize;
                        if ( keySize2 != 8 )
                        {
                            return;
                        }
                        submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class1.Read( reader, submotion.nKeyFrame );
                        return;
                    }
                    else if ( ( num3 & 25165824U ) != 0U )
                    {
                        uint num9 = num4;
                        if ( num9 == 1U )
                        {
                            throw new NotImplementedException( "Investigation needed" );
                        }
                        if ( num9 == 16U )
                        {
                            submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class2.Read( reader, submotion.nKeyFrame );
                            return;
                        }
                        submotion.pKeyList = AppMain.NNS_MOTION_KEY_Class1.Read( reader, submotion.nKeyFrame );
                        return;
                    }
                    else
                    {
                        if ( ( num3 & 33554432U ) != 0U )
                        {
                            throw new NotImplementedException( "Investigation needed" );
                        }
                        throw new NotImplementedException( "Investigation needed" );
                    }
                }
            }
        }

        // Token: 0x04004E45 RID: 20037
        public uint fType;

        // Token: 0x04004E46 RID: 20038
        public uint fIPType;

        // Token: 0x04004E47 RID: 20039
        public int Id;

        // Token: 0x04004E48 RID: 20040
        public float StartFrame;

        // Token: 0x04004E49 RID: 20041
        public float EndFrame;

        // Token: 0x04004E4A RID: 20042
        public float StartKeyFrame;

        // Token: 0x04004E4B RID: 20043
        public float EndKeyFrame;

        // Token: 0x04004E4C RID: 20044
        public int nKeyFrame;

        // Token: 0x04004E4D RID: 20045
        public int KeySize;

        // Token: 0x04004E4E RID: 20046
        public object pKeyList;
    }

    // Token: 0x02000161 RID: 353
    public class NNS_MOTION : AppMain.IClearable
    {
        // Token: 0x060020ED RID: 8429 RVA: 0x001402DC File Offset: 0x0013E4DC
        public NNS_MOTION()
        {
        }

        // Token: 0x060020EE RID: 8430 RVA: 0x001402E4 File Offset: 0x0013E4E4
        public NNS_MOTION( AppMain.NNS_MOTION motion )
        {
            this.fType = motion.fType;
            this.StartFrame = motion.StartFrame;
            this.EndFrame = motion.EndFrame;
            this.nSubmotion = motion.nSubmotion;
            this.pSubmotion = motion.pSubmotion;
            this.FrameRate = motion.FrameRate;
            this.Reserved0 = motion.Reserved0;
            this.Reserved1 = motion.Reserved1;
        }

        // Token: 0x060020EF RID: 8431 RVA: 0x00140358 File Offset: 0x0013E558
        public AppMain.NNS_MOTION Assign( AppMain.NNS_MOTION motion )
        {
            if ( this != motion )
            {
                this.fType = motion.fType;
                this.StartFrame = motion.StartFrame;
                this.EndFrame = motion.EndFrame;
                this.nSubmotion = motion.nSubmotion;
                this.pSubmotion = motion.pSubmotion;
                this.FrameRate = motion.FrameRate;
                this.Reserved0 = motion.Reserved0;
                this.Reserved1 = motion.Reserved1;
            }
            return this;
        }

        // Token: 0x060020F0 RID: 8432 RVA: 0x001403CC File Offset: 0x0013E5CC
        public void Clear()
        {
            this.fType = 0U;
            this.StartFrame = 0f;
            this.EndFrame = 0f;
            this.nSubmotion = 0;
            this.pSubmotion = null;
            this.FrameRate = 0f;
            this.Reserved0 = 0U;
            this.Reserved1 = 0U;
        }

        // Token: 0x060020F1 RID: 8433 RVA: 0x00140420 File Offset: 0x0013E620
        public static AppMain.NNS_MOTION Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_MOTION nns_MOTION = new AppMain.NNS_MOTION();
            nns_MOTION.fType = reader.ReadUInt32();
            nns_MOTION.StartFrame = reader.ReadSingle();
            nns_MOTION.EndFrame = reader.ReadSingle();
            nns_MOTION.nSubmotion = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                nns_MOTION.pSubmotion = new AppMain.NNS_SUBMOTION[nns_MOTION.nSubmotion];
                for ( int i = 0; i < nns_MOTION.nSubmotion; i++ )
                {
                    nns_MOTION.pSubmotion[i] = AppMain.NNS_SUBMOTION.Read( reader, nns_MOTION.fType & 31U, data0Pos );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_MOTION.FrameRate = reader.ReadSingle();
            nns_MOTION.Reserved0 = reader.ReadUInt32();
            nns_MOTION.Reserved1 = reader.ReadUInt32();
            return nns_MOTION;
        }

        // Token: 0x04004E4F RID: 20047
        public uint fType;

        // Token: 0x04004E50 RID: 20048
        public float StartFrame;

        // Token: 0x04004E51 RID: 20049
        public float EndFrame;

        // Token: 0x04004E52 RID: 20050
        public int nSubmotion;

        // Token: 0x04004E53 RID: 20051
        public AppMain.NNS_SUBMOTION[] pSubmotion;

        // Token: 0x04004E54 RID: 20052
        public float FrameRate;

        // Token: 0x04004E55 RID: 20053
        public uint Reserved0;

        // Token: 0x04004E56 RID: 20054
        public uint Reserved1;
    }

    // Token: 0x02000162 RID: 354
    public class NNS_MOTION_BEZIER_HANDLE
    {
        // Token: 0x060020F2 RID: 8434 RVA: 0x001404F7 File Offset: 0x0013E6F7
        public NNS_MOTION_BEZIER_HANDLE()
        {
        }

        // Token: 0x060020F3 RID: 8435 RVA: 0x00140518 File Offset: 0x0013E718
        public NNS_MOTION_BEZIER_HANDLE( AppMain.NNS_MOTION_BEZIER_HANDLE bezierHandle )
        {
            this.In.Assign( bezierHandle.In );
            this.Out.Assign( bezierHandle.Out );
        }

        // Token: 0x060020F4 RID: 8436 RVA: 0x00140565 File Offset: 0x0013E765
        public AppMain.NNS_MOTION_BEZIER_HANDLE Assign( AppMain.NNS_MOTION_BEZIER_HANDLE bezierHandle )
        {
            if ( this != bezierHandle )
            {
                this.In.Assign( bezierHandle.In );
                this.Out.Assign( bezierHandle.Out );
            }
            return this;
        }

        // Token: 0x060020F5 RID: 8437 RVA: 0x00140590 File Offset: 0x0013E790
        public static AppMain.NNS_MOTION_BEZIER_HANDLE Read( BinaryReader reader )
        {
            AppMain.NNS_MOTION_BEZIER_HANDLE nns_MOTION_BEZIER_HANDLE = new AppMain.NNS_MOTION_BEZIER_HANDLE();
            nns_MOTION_BEZIER_HANDLE.In.Assign( AppMain.NNS_VECTOR2D.Read( reader ) );
            nns_MOTION_BEZIER_HANDLE.Out.Assign( AppMain.NNS_VECTOR2D.Read( reader ) );
            return nns_MOTION_BEZIER_HANDLE;
        }

        // Token: 0x04004E57 RID: 20055
        public readonly AppMain.NNS_VECTOR2D In = new AppMain.NNS_VECTOR2D();

        // Token: 0x04004E58 RID: 20056
        public readonly AppMain.NNS_VECTOR2D Out = new AppMain.NNS_VECTOR2D();
    }

    // Token: 0x02000163 RID: 355
    public class NNS_MOTION_SI_SPLINE_HANDLE
    {
        // Token: 0x060020F6 RID: 8438 RVA: 0x001405C8 File Offset: 0x0013E7C8
        public NNS_MOTION_SI_SPLINE_HANDLE()
        {
        }

        // Token: 0x060020F7 RID: 8439 RVA: 0x001405D0 File Offset: 0x0013E7D0
        public NNS_MOTION_SI_SPLINE_HANDLE( AppMain.NNS_MOTION_SI_SPLINE_HANDLE splineHandle )
        {
            this.In = splineHandle.In;
            this.Out = splineHandle.Out;
        }

        // Token: 0x060020F8 RID: 8440 RVA: 0x001405F0 File Offset: 0x0013E7F0
        public AppMain.NNS_MOTION_SI_SPLINE_HANDLE Assign( AppMain.NNS_MOTION_SI_SPLINE_HANDLE splineHandle )
        {
            if ( this != splineHandle )
            {
                this.In = splineHandle.In;
                this.Out = splineHandle.Out;
            }
            return this;
        }

        // Token: 0x060020F9 RID: 8441 RVA: 0x00140610 File Offset: 0x0013E810
        public static AppMain.NNS_MOTION_SI_SPLINE_HANDLE Read( BinaryReader reader )
        {
            return new AppMain.NNS_MOTION_SI_SPLINE_HANDLE
            {
                In = reader.ReadSingle(),
                Out = reader.ReadSingle()
            };
        }

        // Token: 0x04004E59 RID: 20057
        public float In;

        // Token: 0x04004E5A RID: 20058
        public float Out;
    }

    // Token: 0x02000164 RID: 356
    public struct NNS_MOTION_KEY_Class1
    {
        // Token: 0x060020FA RID: 8442 RVA: 0x0014063C File Offset: 0x0013E83C
        public NNS_MOTION_KEY_Class1( AppMain.NNS_MOTION_KEY_Class1 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x060020FB RID: 8443 RVA: 0x00140658 File Offset: 0x0013E858
        public AppMain.NNS_MOTION_KEY_Class1 Assign( AppMain.NNS_MOTION_KEY_Class1 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
            return this;
        }

        // Token: 0x060020FC RID: 8444 RVA: 0x0014067C File Offset: 0x0013E87C
        public static AppMain.NNS_MOTION_KEY_Class1 Read( BinaryReader reader )
        {
            return new AppMain.NNS_MOTION_KEY_Class1
            {
                Frame = reader.ReadSingle(),
                Value = reader.ReadSingle()
            };
        }

        // Token: 0x060020FD RID: 8445 RVA: 0x001406AC File Offset: 0x0013E8AC
        public static AppMain.NNS_MOTION_KEY_Class1[] Read( BinaryReader reader, int count )
        {
            AppMain.NNS_MOTION_KEY_Class1[] array = new AppMain.NNS_MOTION_KEY_Class1[count];
            for ( int i = 0; i < count; i++ )
            {
                array[i] = AppMain.NNS_MOTION_KEY_Class1.Read( reader );
            }
            return array;
        }

        // Token: 0x04004E5B RID: 20059
        public float Frame;

        // Token: 0x04004E5C RID: 20060
        public float Value;
    }

    // Token: 0x02000165 RID: 357
    public class NNS_MOTION_KEY_Class2
    {
        // Token: 0x060020FE RID: 8446 RVA: 0x001406DF File Offset: 0x0013E8DF
        public NNS_MOTION_KEY_Class2()
        {
        }

        // Token: 0x060020FF RID: 8447 RVA: 0x001406F2 File Offset: 0x0013E8F2
        public NNS_MOTION_KEY_Class2( AppMain.NNS_MOTION_KEY_Class2 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
            this.Bhandle.Assign( motionKey.Bhandle );
        }

        // Token: 0x06002100 RID: 8448 RVA: 0x0014072F File Offset: 0x0013E92F
        public AppMain.NNS_MOTION_KEY_Class2 Assign( AppMain.NNS_MOTION_KEY_Class2 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
                this.Bhandle.Assign( motionKey.Bhandle );
            }
            return this;
        }

        // Token: 0x06002101 RID: 8449 RVA: 0x00140760 File Offset: 0x0013E960
        public static AppMain.NNS_MOTION_KEY_Class2 Read( BinaryReader reader )
        {
            AppMain.NNS_MOTION_KEY_Class2 nns_MOTION_KEY_Class = new AppMain.NNS_MOTION_KEY_Class2();
            nns_MOTION_KEY_Class.Frame = reader.ReadSingle();
            nns_MOTION_KEY_Class.Value = reader.ReadSingle();
            nns_MOTION_KEY_Class.Bhandle.Assign( AppMain.NNS_MOTION_BEZIER_HANDLE.Read( reader ) );
            return nns_MOTION_KEY_Class;
        }

        // Token: 0x06002102 RID: 8450 RVA: 0x001407A0 File Offset: 0x0013E9A0
        public static AppMain.NNS_MOTION_KEY_Class2[] Read( BinaryReader reader, int count )
        {
            AppMain.NNS_MOTION_KEY_Class2[] array = new AppMain.NNS_MOTION_KEY_Class2[count];
            for ( int i = 0; i < count; i++ )
            {
                array[i] = AppMain.NNS_MOTION_KEY_Class2.Read( reader );
            }
            return array;
        }

        // Token: 0x04004E5D RID: 20061
        public float Frame;

        // Token: 0x04004E5E RID: 20062
        public float Value;

        // Token: 0x04004E5F RID: 20063
        public readonly AppMain.NNS_MOTION_BEZIER_HANDLE Bhandle = new AppMain.NNS_MOTION_BEZIER_HANDLE();
    }

    // Token: 0x02000166 RID: 358
    public class NNS_MOTION_KEY_Class3
    {
        // Token: 0x06002103 RID: 8451 RVA: 0x001407CA File Offset: 0x0013E9CA
        public NNS_MOTION_KEY_Class3()
        {
        }

        // Token: 0x06002104 RID: 8452 RVA: 0x001407DD File Offset: 0x0013E9DD
        public NNS_MOTION_KEY_Class3( AppMain.NNS_MOTION_KEY_Class3 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
            this.Shandle.Assign( motionKey.Shandle );
        }

        // Token: 0x06002105 RID: 8453 RVA: 0x0014081A File Offset: 0x0013EA1A
        public AppMain.NNS_MOTION_KEY_Class3 Assign( AppMain.NNS_MOTION_KEY_Class3 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
                this.Shandle.Assign( motionKey.Shandle );
            }
            return this;
        }

        // Token: 0x06002106 RID: 8454 RVA: 0x0014084C File Offset: 0x0013EA4C
        public static AppMain.NNS_MOTION_KEY_Class3 Read( BinaryReader reader )
        {
            AppMain.NNS_MOTION_KEY_Class3 nns_MOTION_KEY_Class = new AppMain.NNS_MOTION_KEY_Class3();
            nns_MOTION_KEY_Class.Frame = reader.ReadSingle();
            nns_MOTION_KEY_Class.Value = reader.ReadSingle();
            nns_MOTION_KEY_Class.Shandle.Assign( AppMain.NNS_MOTION_SI_SPLINE_HANDLE.Read( reader ) );
            return nns_MOTION_KEY_Class;
        }

        // Token: 0x04004E60 RID: 20064
        public float Frame;

        // Token: 0x04004E61 RID: 20065
        public float Value;

        // Token: 0x04004E62 RID: 20066
        public readonly AppMain.NNS_MOTION_SI_SPLINE_HANDLE Shandle = new AppMain.NNS_MOTION_SI_SPLINE_HANDLE();
    }

    // Token: 0x02000167 RID: 359
    public class NNS_MOTION_KEY_Class4
    {
        // Token: 0x06002107 RID: 8455 RVA: 0x0014088A File Offset: 0x0013EA8A
        public NNS_MOTION_KEY_Class4()
        {
        }

        // Token: 0x06002108 RID: 8456 RVA: 0x00140892 File Offset: 0x0013EA92
        public NNS_MOTION_KEY_Class4( AppMain.NNS_MOTION_KEY_Class4 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002109 RID: 8457 RVA: 0x001408B2 File Offset: 0x0013EAB2
        public AppMain.NNS_MOTION_KEY_Class4 Assign( AppMain.NNS_MOTION_KEY_Class4 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x04004E63 RID: 20067
        public float Frame;

        // Token: 0x04004E64 RID: 20068
        public AppMain.NNS_TEXCOORD Value;
    }

    // Token: 0x02000168 RID: 360
    public class NNS_MOTION_KEY_Class5
    {
        // Token: 0x0600210A RID: 8458 RVA: 0x001408D1 File Offset: 0x0013EAD1
        public NNS_MOTION_KEY_Class5()
        {
        }

        // Token: 0x0600210B RID: 8459 RVA: 0x001408E4 File Offset: 0x0013EAE4
        public NNS_MOTION_KEY_Class5( AppMain.NNS_MOTION_KEY_Class5 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value.Assign( motionKey.Value );
        }

        // Token: 0x0600210C RID: 8460 RVA: 0x00140915 File Offset: 0x0013EB15
        public AppMain.NNS_MOTION_KEY_Class5 Assign( AppMain.NNS_MOTION_KEY_Class5 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value.Assign( motionKey.Value );
            }
            return this;
        }

        // Token: 0x0600210D RID: 8461 RVA: 0x0014093C File Offset: 0x0013EB3C
        public static AppMain.NNS_MOTION_KEY_Class5 Read( BinaryReader reader )
        {
            AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = new AppMain.NNS_MOTION_KEY_Class5();
            nns_MOTION_KEY_Class.Frame = reader.ReadSingle();
            nns_MOTION_KEY_Class.Value.Assign( AppMain.NNS_VECTOR.Read( reader ) );
            return nns_MOTION_KEY_Class;
        }

        // Token: 0x0600210E RID: 8462 RVA: 0x00140970 File Offset: 0x0013EB70
        public static AppMain.NNS_MOTION_KEY_Class5[] Read( BinaryReader reader, int count )
        {
            AppMain.NNS_MOTION_KEY_Class5[] array = new AppMain.NNS_MOTION_KEY_Class5[count];
            for ( int i = 0; i < count; i++ )
            {
                array[i] = AppMain.NNS_MOTION_KEY_Class5.Read( reader );
            }
            return array;
        }

        // Token: 0x04004E65 RID: 20069
        public float Frame;

        // Token: 0x04004E66 RID: 20070
        public readonly AppMain.NNS_VECTOR Value = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
    }

    // Token: 0x02000169 RID: 361
    public class NNS_MOTION_KEY_Class6
    {
        // Token: 0x0600210F RID: 8463 RVA: 0x0014099A File Offset: 0x0013EB9A
        public NNS_MOTION_KEY_Class6()
        {
        }

        // Token: 0x06002110 RID: 8464 RVA: 0x001409AD File Offset: 0x0013EBAD
        public NNS_MOTION_KEY_Class6( AppMain.NNS_MOTION_KEY_Class6 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value.Assign( motionKey.Value );
        }

        // Token: 0x06002111 RID: 8465 RVA: 0x001409DE File Offset: 0x0013EBDE
        public AppMain.NNS_MOTION_KEY_Class6 Assign( AppMain.NNS_MOTION_KEY_Class6 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value.Assign( motionKey.Value );
            }
            return this;
        }

        // Token: 0x04004E67 RID: 20071
        public float Frame;

        // Token: 0x04004E68 RID: 20072
        public readonly AppMain.NNS_RGB Value = new AppMain.NNS_RGB();
    }

    // Token: 0x0200016A RID: 362
    public class NNS_MOTION_KEY_Class7
    {
        // Token: 0x06002112 RID: 8466 RVA: 0x00140A03 File Offset: 0x0013EC03
        public NNS_MOTION_KEY_Class7()
        {
        }

        // Token: 0x06002113 RID: 8467 RVA: 0x00140A0B File Offset: 0x0013EC0B
        public NNS_MOTION_KEY_Class7( AppMain.NNS_MOTION_KEY_Class7 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002114 RID: 8468 RVA: 0x00140A2B File Offset: 0x0013EC2B
        public AppMain.NNS_MOTION_KEY_Class7 Assign( AppMain.NNS_MOTION_KEY_Class7 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x04004E69 RID: 20073
        public float Frame;

        // Token: 0x04004E6A RID: 20074
        public AppMain.NNS_QUATERNION Value;
    }

    // Token: 0x0200016B RID: 363
    public class NNS_MOTION_KEY_Class8
    {
        // Token: 0x06002115 RID: 8469 RVA: 0x00140A4A File Offset: 0x0013EC4A
        public NNS_MOTION_KEY_Class8()
        {
        }

        // Token: 0x06002116 RID: 8470 RVA: 0x00140A52 File Offset: 0x0013EC52
        public NNS_MOTION_KEY_Class8( AppMain.NNS_MOTION_KEY_Class8 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002117 RID: 8471 RVA: 0x00140A72 File Offset: 0x0013EC72
        public AppMain.NNS_MOTION_KEY_Class8 Assign( AppMain.NNS_MOTION_KEY_Class8 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x04004E6B RID: 20075
        public float Frame;

        // Token: 0x04004E6C RID: 20076
        public int Value;
    }

    // Token: 0x0200016C RID: 364
    public class NNS_MOTION_KEY_Class9
    {
        // Token: 0x06002118 RID: 8472 RVA: 0x00140A91 File Offset: 0x0013EC91
        public NNS_MOTION_KEY_Class9()
        {
        }

        // Token: 0x06002119 RID: 8473 RVA: 0x00140AA4 File Offset: 0x0013ECA4
        public NNS_MOTION_KEY_Class9( AppMain.NNS_MOTION_KEY_Class9 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
            this.Bhandle.Assign( motionKey.Bhandle );
        }

        // Token: 0x0600211A RID: 8474 RVA: 0x00140AE1 File Offset: 0x0013ECE1
        public AppMain.NNS_MOTION_KEY_Class9 Assign( AppMain.NNS_MOTION_KEY_Class9 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
                this.Bhandle.Assign( motionKey.Bhandle );
            }
            return this;
        }

        // Token: 0x04004E6D RID: 20077
        public float Frame;

        // Token: 0x04004E6E RID: 20078
        public int Value;

        // Token: 0x04004E6F RID: 20079
        public readonly AppMain.NNS_MOTION_BEZIER_HANDLE Bhandle = new AppMain.NNS_MOTION_BEZIER_HANDLE();
    }

    // Token: 0x0200016D RID: 365
    public class NNS_MOTION_KEY_Class10
    {
        // Token: 0x0600211B RID: 8475 RVA: 0x00140B12 File Offset: 0x0013ED12
        public NNS_MOTION_KEY_Class10()
        {
        }

        // Token: 0x0600211C RID: 8476 RVA: 0x00140B25 File Offset: 0x0013ED25
        public NNS_MOTION_KEY_Class10( AppMain.NNS_MOTION_KEY_Class10 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
            this.Shandle.Assign( motionKey.Shandle );
        }

        // Token: 0x0600211D RID: 8477 RVA: 0x00140B62 File Offset: 0x0013ED62
        public AppMain.NNS_MOTION_KEY_Class10 Assign( AppMain.NNS_MOTION_KEY_Class10 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
                this.Shandle.Assign( motionKey.Shandle );
            }
            return this;
        }

        // Token: 0x04004E70 RID: 20080
        public float Frame;

        // Token: 0x04004E71 RID: 20081
        public int Value;

        // Token: 0x04004E72 RID: 20082
        public readonly AppMain.NNS_MOTION_SI_SPLINE_HANDLE Shandle = new AppMain.NNS_MOTION_SI_SPLINE_HANDLE();
    }

    // Token: 0x0200016E RID: 366
    public class NNS_MOTION_KEY_Class11
    {
        // Token: 0x0600211E RID: 8478 RVA: 0x00140B93 File Offset: 0x0013ED93
        public NNS_MOTION_KEY_Class11()
        {
        }

        // Token: 0x0600211F RID: 8479 RVA: 0x00140B9B File Offset: 0x0013ED9B
        public NNS_MOTION_KEY_Class11( AppMain.NNS_MOTION_KEY_Class11 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002120 RID: 8480 RVA: 0x00140BBB File Offset: 0x0013EDBB
        public AppMain.NNS_MOTION_KEY_Class11 Assign( AppMain.NNS_MOTION_KEY_Class11 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x06002121 RID: 8481 RVA: 0x00140BDC File Offset: 0x0013EDDC
        public static AppMain.NNS_MOTION_KEY_Class11 Read( BinaryReader reader )
        {
            return new AppMain.NNS_MOTION_KEY_Class11
            {
                Frame = reader.ReadSingle(),
                Value = reader.ReadInt32()
            };
        }

        // Token: 0x06002122 RID: 8482 RVA: 0x00140C08 File Offset: 0x0013EE08
        public static AppMain.NNS_MOTION_KEY_Class11[] Read( BinaryReader reader, int count )
        {
            AppMain.NNS_MOTION_KEY_Class11[] array = new AppMain.NNS_MOTION_KEY_Class11[count];
            for ( int i = 0; i < count; i++ )
            {
                array[i] = AppMain.NNS_MOTION_KEY_Class11.Read( reader );
            }
            return array;
        }

        // Token: 0x04004E73 RID: 20083
        public float Frame;

        // Token: 0x04004E74 RID: 20084
        public int Value;
    }

    // Token: 0x0200016F RID: 367
    public class NNS_MOTION_KEY_Class12
    {
        // Token: 0x06002123 RID: 8483 RVA: 0x00140C32 File Offset: 0x0013EE32
        public NNS_MOTION_KEY_Class12()
        {
        }

        // Token: 0x06002124 RID: 8484 RVA: 0x00140C3A File Offset: 0x0013EE3A
        public NNS_MOTION_KEY_Class12( AppMain.NNS_MOTION_KEY_Class12 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002125 RID: 8485 RVA: 0x00140C5A File Offset: 0x0013EE5A
        public AppMain.NNS_MOTION_KEY_Class12 Assign( AppMain.NNS_MOTION_KEY_Class12 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x04004E75 RID: 20085
        public float Frame;

        // Token: 0x04004E76 RID: 20086
        public uint Value;
    }

    // Token: 0x02000170 RID: 368
    public class NNS_MOTION_KEY_Class13
    {
        // Token: 0x06002126 RID: 8486 RVA: 0x00140C79 File Offset: 0x0013EE79
        public NNS_MOTION_KEY_Class13()
        {
        }

        // Token: 0x06002127 RID: 8487 RVA: 0x00140C81 File Offset: 0x0013EE81
        public NNS_MOTION_KEY_Class13( AppMain.NNS_MOTION_KEY_Class13 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002128 RID: 8488 RVA: 0x00140CA1 File Offset: 0x0013EEA1
        public AppMain.NNS_MOTION_KEY_Class13 Assign( AppMain.NNS_MOTION_KEY_Class13 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x04004E77 RID: 20087
        public float Frame;

        // Token: 0x04004E78 RID: 20088
        public AppMain.NNS_ROTATE_A32 Value;
    }

    // Token: 0x02000171 RID: 369
    public struct NNS_MOTION_KEY_Class14
    {
        // Token: 0x06002129 RID: 8489 RVA: 0x00140CC0 File Offset: 0x0013EEC0
        public static AppMain.NNS_MOTION_KEY_Class14 Read( BinaryReader reader )
        {
            return new AppMain.NNS_MOTION_KEY_Class14
            {
                Frame = reader.ReadInt16(),
                Value = reader.ReadInt16()
            };
        }

        // Token: 0x0600212A RID: 8490 RVA: 0x00140CF0 File Offset: 0x0013EEF0
        public static AppMain.NNS_MOTION_KEY_Class14[] Read( BinaryReader reader, int count )
        {
            AppMain.NNS_MOTION_KEY_Class14[] array = new AppMain.NNS_MOTION_KEY_Class14[count];
            for ( int i = 0; i < count; i++ )
            {
                array[i] = AppMain.NNS_MOTION_KEY_Class14.Read( reader );
            }
            return array;
        }

        // Token: 0x04004E79 RID: 20089
        public short Frame;

        // Token: 0x04004E7A RID: 20090
        public short Value;
    }

    // Token: 0x02000172 RID: 370
    public class NNS_MOTION_KEY_Class15
    {
        // Token: 0x0600212B RID: 8491 RVA: 0x00140D23 File Offset: 0x0013EF23
        public NNS_MOTION_KEY_Class15()
        {
        }

        // Token: 0x0600212C RID: 8492 RVA: 0x00140D36 File Offset: 0x0013EF36
        public NNS_MOTION_KEY_Class15( AppMain.NNS_MOTION_KEY_Class15 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
            this.Shandle.Assign( motionKey.Shandle );
        }

        // Token: 0x0600212D RID: 8493 RVA: 0x00140D73 File Offset: 0x0013EF73
        public AppMain.NNS_MOTION_KEY_Class15 Assign( AppMain.NNS_MOTION_KEY_Class15 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
                this.Shandle.Assign( motionKey.Shandle );
            }
            return this;
        }

        // Token: 0x04004E7B RID: 20091
        public short Frame;

        // Token: 0x04004E7C RID: 20092
        public short Value;

        // Token: 0x04004E7D RID: 20093
        public readonly AppMain.NNS_MOTION_SI_SPLINE_HANDLE Shandle = new AppMain.NNS_MOTION_SI_SPLINE_HANDLE();
    }

    // Token: 0x02000173 RID: 371
    public class NNS_MOTION_KEY_Class16
    {
        // Token: 0x0600212E RID: 8494 RVA: 0x00140DA4 File Offset: 0x0013EFA4
        public NNS_MOTION_KEY_Class16()
        {
        }

        // Token: 0x0600212F RID: 8495 RVA: 0x00140DAC File Offset: 0x0013EFAC
        public NNS_MOTION_KEY_Class16( AppMain.NNS_MOTION_KEY_Class16 motionKey )
        {
            this.Frame = motionKey.Frame;
            this.Value = motionKey.Value;
        }

        // Token: 0x06002130 RID: 8496 RVA: 0x00140DCC File Offset: 0x0013EFCC
        public AppMain.NNS_MOTION_KEY_Class16 Assign( AppMain.NNS_MOTION_KEY_Class16 motionKey )
        {
            if ( this != motionKey )
            {
                this.Frame = motionKey.Frame;
                this.Value = motionKey.Value;
            }
            return this;
        }

        // Token: 0x06002131 RID: 8497 RVA: 0x00140DEC File Offset: 0x0013EFEC
        public static AppMain.NNS_MOTION_KEY_Class16 Read( BinaryReader reader )
        {
            AppMain.NNS_MOTION_KEY_Class16 nns_MOTION_KEY_Class = new AppMain.NNS_MOTION_KEY_Class16();
            nns_MOTION_KEY_Class.Frame = reader.ReadInt16();
            nns_MOTION_KEY_Class.Value.x = reader.ReadInt16();
            nns_MOTION_KEY_Class.Value.y = reader.ReadInt16();
            nns_MOTION_KEY_Class.Value.z = reader.ReadInt16();
            return nns_MOTION_KEY_Class;
        }

        // Token: 0x06002132 RID: 8498 RVA: 0x00140E40 File Offset: 0x0013F040
        public static AppMain.NNS_MOTION_KEY_Class16[] Read( BinaryReader reader, int count )
        {
            AppMain.NNS_MOTION_KEY_Class16[] array = new AppMain.NNS_MOTION_KEY_Class16[count];
            for ( int i = 0; i < count; i++ )
            {
                array[i] = AppMain.NNS_MOTION_KEY_Class16.Read( reader );
            }
            return array;
        }

        // Token: 0x04004E7E RID: 20094
        public short Frame;

        // Token: 0x04004E7F RID: 20095
        public AppMain.NNS_ROTATE_A16 Value;
    }

    // Token: 0x020001A5 RID: 421
    private static class nncalctrsmotion
    {
        // Token: 0x04004F66 RID: 20326
        public static AppMain.NNS_OBJECT nnsObj;

        // Token: 0x04004F67 RID: 20327
        public static readonly AppMain.NNS_MATRIX nnsBaseMtx = new AppMain.NNS_MATRIX();

        // Token: 0x04004F68 RID: 20328
        public static AppMain.NNS_MATRIX[] nnsMtxPal;

        // Token: 0x04004F69 RID: 20329
        public static uint[] nnsNodeStatList;

        // Token: 0x04004F6A RID: 20330
        public static uint nnsNSFlag;

        // Token: 0x04004F6B RID: 20331
        public static AppMain.NNS_NODE[] nnsNodeList;

        // Token: 0x04004F6C RID: 20332
        public static AppMain.NNS_TRS[] nnsTrsList;

        // Token: 0x04004F6D RID: 20333
        public static AppMain.NNS_MATRIXSTACK nnsMstk;

        // Token: 0x04004F6E RID: 20334
        public static float nnsRootScale = 1f;

        // Token: 0x04004F6F RID: 20335
        public static AppMain.NNS_MOTION nnsMot0;

        // Token: 0x04004F70 RID: 20336
        public static AppMain.NNS_MOTION nnsMot1;

        // Token: 0x04004F71 RID: 20337
        public static float nnsFrame0;

        // Token: 0x04004F72 RID: 20338
        public static float nnsFrame1;

        // Token: 0x04004F73 RID: 20339
        public static float nnsRatio;

        // Token: 0x04004F74 RID: 20340
        public static int nnsSubMotIdx0;

        // Token: 0x04004F75 RID: 20341
        public static int nnsSubMotIdx1;
    }
}
