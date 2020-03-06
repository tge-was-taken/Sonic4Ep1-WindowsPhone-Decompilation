using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using mpp;

public partial class AppMain
{

    // Token: 0x020003B0 RID: 944
    private enum AME_AME_USER_ATTRIBUTE : uint
    {
        // Token: 0x0400618C RID: 24972
        AME_AME_ATTR_INCLUSIVE,
        // Token: 0x0400618D RID: 24973
        AME_AME_ATTR_EXCLUSIVE,
        // Token: 0x0400618E RID: 24974
        AME_AME_ATTR_GROUP_MASK = 4294901760U,
        // Token: 0x0400618F RID: 24975
        AME_AME_ATTR_USER_MASK = 65535U,
        // Token: 0x04006190 RID: 24976
        AME_AME_ATTR_GROUP_ALL = 4294901760U,
        // Token: 0x04006191 RID: 24977
        AME_AME_ATTR_GROUP_00 = 65536U,
        // Token: 0x04006192 RID: 24978
        AME_AME_ATTR_GROUP_01 = 131072U,
        // Token: 0x04006193 RID: 24979
        AME_AME_ATTR_GROUP_02 = 262144U,
        // Token: 0x04006194 RID: 24980
        AME_AME_ATTR_GROUP_03 = 524288U,
        // Token: 0x04006195 RID: 24981
        AME_AME_ATTR_GROUP_04 = 1048576U,
        // Token: 0x04006196 RID: 24982
        AME_AME_ATTR_GROUP_05 = 2097152U,
        // Token: 0x04006197 RID: 24983
        AME_AME_ATTR_GROUP_06 = 4194304U,
        // Token: 0x04006198 RID: 24984
        AME_AME_ATTR_GROUP_07 = 8388608U,
        // Token: 0x04006199 RID: 24985
        AME_AME_ATTR_GROUP_08 = 16777216U,
        // Token: 0x0400619A RID: 24986
        AME_AME_ATTR_GROUP_09 = 33554432U,
        // Token: 0x0400619B RID: 24987
        AME_AME_ATTR_GROUP_0a = 67108864U,
        // Token: 0x0400619C RID: 24988
        AME_AME_ATTR_GROUP_0b = 134217728U,
        // Token: 0x0400619D RID: 24989
        AME_AME_ATTR_GROUP_0c = 268435456U,
        // Token: 0x0400619E RID: 24990
        AME_AME_ATTR_GROUP_0d = 536870912U,
        // Token: 0x0400619F RID: 24991
        AME_AME_ATTR_GROUP_0e = 1073741824U,
        // Token: 0x040061A0 RID: 24992
        AME_AME_ATTR_GROUP_0f = 2147483648U
    }

    // Token: 0x020003B1 RID: 945
    public class AMS_FRUSTUM
    {
        // Token: 0x040061A1 RID: 24993
        private Matrix viewMatrix;

        // Token: 0x040061A2 RID: 24994
        private float width;

        // Token: 0x040061A3 RID: 24995
        private float height;

        // Token: 0x040061A4 RID: 24996
        private float nearClip;

        // Token: 0x040061A5 RID: 24997
        private float farClip;

        // Token: 0x040061A6 RID: 24998
        private float lrNormalX;

        // Token: 0x040061A7 RID: 24999
        private float lrNormalZ;

        // Token: 0x040061A8 RID: 25000
        private float tbNormalY;

        // Token: 0x040061A9 RID: 25001
        private float tbNormalZ;
    }

    // Token: 0x020003B2 RID: 946
    public class AMS_AME_LIST
    {
        // Token: 0x06002706 RID: 9990 RVA: 0x00150ED6 File Offset: 0x0014F0D6
        public virtual void Clear()
        {
            this.next = null;
            this.prev = null;
        }

        // Token: 0x040061AA RID: 25002
        public AppMain.AMS_AME_LIST next;

        // Token: 0x040061AB RID: 25003
        public AppMain.AMS_AME_LIST prev;
    }

    // Token: 0x020003B3 RID: 947
    public class AMS_AME_RUNTIME : AppMain.AMS_AME_LIST
    {
        // Token: 0x06002708 RID: 9992 RVA: 0x00150EF0 File Offset: 0x0014F0F0
        public new void Clear()
        {
            this.next = null;
            this.prev = null;
            this.state = 0;
            this.amount = 0f;
            this.count = 0U;
            this.ecb = null;
            this.node = null;
            this.parent_runtime = null;
            this.spawn_runtime = null;
            this.work = null;
            this.child_head.Clear();
            this.child_tail.Clear();
            this.child_num = 0;
            this.work_head.Clear();
            this.work_tail.Clear();
            this.active_head.Clear();
            this.active_tail.Clear();
            this.work_num = 0;
            this.active_num = 0;
            this.texlist = null;
        }

        // Token: 0x040061AC RID: 25004
        public int state;

        // Token: 0x040061AD RID: 25005
        public float amount;

        // Token: 0x040061AE RID: 25006
        public uint count;

        // Token: 0x040061AF RID: 25007
        public AppMain.AMS_AME_ECB ecb;

        // Token: 0x040061B0 RID: 25008
        public AppMain.AMS_AME_NODE node;

        // Token: 0x040061B1 RID: 25009
        public AppMain.AMS_AME_RUNTIME parent_runtime;

        // Token: 0x040061B2 RID: 25010
        public AppMain.AMS_AME_RUNTIME spawn_runtime;

        // Token: 0x040061B3 RID: 25011
        public AppMain.AMS_AME_RUNTIME_WORK work;

        // Token: 0x040061B4 RID: 25012
        public readonly AppMain.AMS_AME_LIST child_head = new AppMain.AMS_AME_LIST();

        // Token: 0x040061B5 RID: 25013
        public readonly AppMain.AMS_AME_LIST child_tail = new AppMain.AMS_AME_LIST();

        // Token: 0x040061B6 RID: 25014
        public int child_num;

        // Token: 0x040061B7 RID: 25015
        public readonly AppMain.AMS_AME_LIST work_head = new AppMain.AMS_AME_RUNTIME_WORK();

        // Token: 0x040061B8 RID: 25016
        public readonly AppMain.AMS_AME_LIST work_tail = new AppMain.AMS_AME_RUNTIME_WORK();

        // Token: 0x040061B9 RID: 25017
        public readonly AppMain.AMS_AME_LIST active_head = new AppMain.AMS_AME_RUNTIME_WORK();

        // Token: 0x040061BA RID: 25018
        public readonly AppMain.AMS_AME_LIST active_tail = new AppMain.AMS_AME_RUNTIME_WORK();

        // Token: 0x040061BB RID: 25019
        public short work_num;

        // Token: 0x040061BC RID: 25020
        public short active_num;

        // Token: 0x040061BD RID: 25021
        public AppMain.NNS_TEXLIST texlist;
    }

    // Token: 0x020003B4 RID: 948
    public struct Vector4D_Buf
    {
        // Token: 0x0600270A RID: 9994 RVA: 0x00150FFD File Offset: 0x0014F1FD
        public Vector4D_Buf( byte[] data, int offset )
        {
            this.data_ = data;
            this.offset_ = offset;
        }

        // Token: 0x170000C0 RID: 192
        // (get) Token: 0x0600270B RID: 9995 RVA: 0x0015100D File Offset: 0x0014F20D
        // (set) Token: 0x0600270C RID: 9996 RVA: 0x00151020 File Offset: 0x0014F220
        public float x
        {
            get
            {
                return BitConverter.ToSingle( this.data_, this.offset_ );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.data_, this.offset_ );
            }
        }

        // Token: 0x170000C1 RID: 193
        // (get) Token: 0x0600270D RID: 9997 RVA: 0x00151034 File Offset: 0x0014F234
        // (set) Token: 0x0600270E RID: 9998 RVA: 0x00151049 File Offset: 0x0014F249
        public float y
        {
            get
            {
                return BitConverter.ToSingle( this.data_, this.offset_ + 4 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.data_, this.offset_ + 4 );
            }
        }

        // Token: 0x170000C2 RID: 194
        // (get) Token: 0x0600270F RID: 9999 RVA: 0x0015105F File Offset: 0x0014F25F
        // (set) Token: 0x06002710 RID: 10000 RVA: 0x00151074 File Offset: 0x0014F274
        public float z
        {
            get
            {
                return BitConverter.ToSingle( this.data_, this.offset_ + 8 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.data_, this.offset_ + 8 );
            }
        }

        // Token: 0x170000C3 RID: 195
        // (get) Token: 0x06002711 RID: 10001 RVA: 0x0015108A File Offset: 0x0014F28A
        // (set) Token: 0x06002712 RID: 10002 RVA: 0x001510A0 File Offset: 0x0014F2A0
        public float w
        {
            get
            {
                return BitConverter.ToSingle( this.data_, this.offset_ + 12 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.data_, this.offset_ + 12 );
            }
        }

        // Token: 0x06002713 RID: 10003 RVA: 0x001510B7 File Offset: 0x0014F2B7
        public void Assign( AppMain.Vector4D_Buf v )
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        // Token: 0x06002714 RID: 10004 RVA: 0x001510ED File Offset: 0x0014F2ED
        public void Assign( AppMain.NNS_VECTOR4D v )
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        // Token: 0x06002715 RID: 10005 RVA: 0x0015111F File Offset: 0x0014F31F
        public void Assign( AppMain.NNS_VECTOR v )
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        // Token: 0x170000C4 RID: 196
        // (get) Token: 0x06002716 RID: 10006 RVA: 0x00151145 File Offset: 0x0014F345
        public static int SizeBytes
        {
            get
            {
                return 16;
            }
        }

        // Token: 0x040061BE RID: 25022
        private readonly byte[] data_;

        // Token: 0x040061BF RID: 25023
        private readonly int offset_;
    }

    // Token: 0x020003B5 RID: 949
    public struct Vector4D_Quat
    {
        // Token: 0x06002717 RID: 10007 RVA: 0x00151149 File Offset: 0x0014F349
        public Vector4D_Quat( AppMain.NNS_QUATERNION[] quat )
        {
            this.quat_ = quat;
        }

        // Token: 0x170000C5 RID: 197
        // (get) Token: 0x06002718 RID: 10008 RVA: 0x00151152 File Offset: 0x0014F352
        public float x
        {
            get
            {
                return this.quat_[0].x;
            }
        }

        // Token: 0x170000C6 RID: 198
        // (get) Token: 0x06002719 RID: 10009 RVA: 0x00151165 File Offset: 0x0014F365
        public float y
        {
            get
            {
                return this.quat_[0].y;
            }
        }

        // Token: 0x170000C7 RID: 199
        // (get) Token: 0x0600271A RID: 10010 RVA: 0x00151178 File Offset: 0x0014F378
        public float z
        {
            get
            {
                return this.quat_[0].z;
            }
        }

        // Token: 0x170000C8 RID: 200
        // (get) Token: 0x0600271B RID: 10011 RVA: 0x0015118B File Offset: 0x0014F38B
        public float w
        {
            get
            {
                return this.quat_[0].w;
            }
        }

        // Token: 0x0600271C RID: 10012 RVA: 0x0015119E File Offset: 0x0014F39E
        public void Assign( float x, float y, float z, float w )
        {
            this.quat_[0] = new AppMain.NNS_QUATERNION( x, y, z, w );
        }

        // Token: 0x0600271D RID: 10013 RVA: 0x001511BB File Offset: 0x0014F3BB
        public void Assign( AppMain.NNS_VECTOR4D v )
        {
            this.quat_[0] = new AppMain.NNS_QUATERNION( v.x, v.y, v.z, v.w );
        }

        // Token: 0x0600271E RID: 10014 RVA: 0x001511EB File Offset: 0x0014F3EB
        public static explicit operator AppMain.NNS_QUATERNION( AppMain.Vector4D_Quat v )
        {
            return v.quat_[0];
        }

        // Token: 0x040061C0 RID: 25024
        private readonly AppMain.NNS_QUATERNION[] quat_;
    }

    // Token: 0x020003B6 RID: 950
    public struct AMS_RGBA8888_Buf
    {
        // Token: 0x0600271F RID: 10015 RVA: 0x001511FF File Offset: 0x0014F3FF
        public AMS_RGBA8888_Buf( byte[] data, int offset )
        {
            this.data_ = data;
            this.offset_ = offset;
        }

        // Token: 0x170000C9 RID: 201
        // (get) Token: 0x06002720 RID: 10016 RVA: 0x0015120F File Offset: 0x0014F40F
        // (set) Token: 0x06002721 RID: 10017 RVA: 0x0015121E File Offset: 0x0014F41E
        public byte r
        {
            get
            {
                return this.data_[this.offset_];
            }
            set
            {
                this.data_[this.offset_] = value;
            }
        }

        // Token: 0x170000CA RID: 202
        // (get) Token: 0x06002722 RID: 10018 RVA: 0x0015122E File Offset: 0x0014F42E
        // (set) Token: 0x06002723 RID: 10019 RVA: 0x0015123F File Offset: 0x0014F43F
        public byte g
        {
            get
            {
                return this.data_[this.offset_ + 1];
            }
            set
            {
                this.data_[this.offset_ + 1] = value;
            }
        }

        // Token: 0x170000CB RID: 203
        // (get) Token: 0x06002724 RID: 10020 RVA: 0x00151251 File Offset: 0x0014F451
        // (set) Token: 0x06002725 RID: 10021 RVA: 0x00151262 File Offset: 0x0014F462
        public byte b
        {
            get
            {
                return this.data_[this.offset_ + 2];
            }
            set
            {
                this.data_[this.offset_ + 2] = value;
            }
        }

        // Token: 0x170000CC RID: 204
        // (get) Token: 0x06002726 RID: 10022 RVA: 0x00151274 File Offset: 0x0014F474
        // (set) Token: 0x06002727 RID: 10023 RVA: 0x00151285 File Offset: 0x0014F485
        public byte a
        {
            get
            {
                return this.data_[this.offset_ + 3];
            }
            set
            {
                this.data_[this.offset_ + 3] = value;
            }
        }

        // Token: 0x170000CD RID: 205
        // (get) Token: 0x06002728 RID: 10024 RVA: 0x00151297 File Offset: 0x0014F497
        // (set) Token: 0x06002729 RID: 10025 RVA: 0x001512AA File Offset: 0x0014F4AA
        public uint color
        {
            get
            {
                return BitConverter.ToUInt32( this.data_, this.offset_ );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.data_, this.offset_ );
            }
        }

        // Token: 0x170000CE RID: 206
        // (get) Token: 0x0600272A RID: 10026 RVA: 0x001512BE File Offset: 0x0014F4BE
        public static int SizeBytes
        {
            get
            {
                return 4;
            }
        }

        // Token: 0x040061C1 RID: 25025
        private readonly byte[] data_;

        // Token: 0x040061C2 RID: 25026
        private readonly int offset_;
    }

    // Token: 0x020003B7 RID: 951
    public class AMS_AME_RUNTIME_WORK : AppMain.AMS_AME_LIST
    {
        // Token: 0x0600272B RID: 10027 RVA: 0x001512C4 File Offset: 0x0014F4C4
        public override void Clear()
        {
            this.time = 0f;
            this.flag = 0U;
            this.position.Clear();
            this.velocity.Clear();
            this.rotate[0].Clear();
            Array.Clear( this.dummy, 0, 64 );
            this.next = null;
            this.prev = null;
        }

        // Token: 0x0600272C RID: 10028 RVA: 0x00151326 File Offset: 0x0014F526
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_MODEL( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_MODEL( work );
        }

        // Token: 0x0600272D RID: 10029 RVA: 0x0015132E File Offset: 0x0014F52E
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL( work );
        }

        // Token: 0x0600272E RID: 10030 RVA: 0x00151336 File Offset: 0x0014F536
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_OMNI( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_OMNI( work );
        }

        // Token: 0x0600272F RID: 10031 RVA: 0x0015133E File Offset: 0x0014F53E
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE( work );
        }

        // Token: 0x06002730 RID: 10032 RVA: 0x00151346 File Offset: 0x0014F546
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_SPRITE( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_SPRITE( work );
        }

        // Token: 0x06002731 RID: 10033 RVA: 0x0015134E File Offset: 0x0014F54E
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_LINE( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_LINE( work );
        }

        // Token: 0x06002732 RID: 10034 RVA: 0x00151356 File Offset: 0x0014F556
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_PLANE( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_PLANE( work );
        }

        // Token: 0x06002733 RID: 10035 RVA: 0x0015135E File Offset: 0x0014F55E
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_SURFACE( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_SURFACE( work );
        }

        // Token: 0x06002734 RID: 10036 RVA: 0x00151366 File Offset: 0x0014F566
        public static explicit operator AppMain.AMS_AME_RUNTIME_WORK_CIRCLE( AppMain.AMS_AME_RUNTIME_WORK work )
        {
            return new AppMain.AMS_AME_RUNTIME_WORK_CIRCLE( work );
        }

        // Token: 0x040061C3 RID: 25027
        public float time;

        // Token: 0x040061C4 RID: 25028
        public uint flag;

        // Token: 0x040061C5 RID: 25029
        public readonly AppMain.NNS_VECTOR4D position = new AppMain.NNS_VECTOR4D();

        // Token: 0x040061C6 RID: 25030
        public readonly AppMain.NNS_VECTOR4D velocity = new AppMain.NNS_VECTOR4D();

        // Token: 0x040061C7 RID: 25031
        public readonly AppMain.NNS_QUATERNION[] rotate = new AppMain.NNS_QUATERNION[1];

        // Token: 0x040061C8 RID: 25032
        public readonly byte[] dummy = new byte[64];
    }

    // Token: 0x020003B8 RID: 952
    public struct AMS_AME_RUNTIME_WORK_DIRECTIONAL
    {
        // Token: 0x06002736 RID: 10038 RVA: 0x001513A5 File Offset: 0x0014F5A5
        public AMS_AME_RUNTIME_WORK_DIRECTIONAL( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
        }

        // Token: 0x170000CF RID: 207
        // (get) Token: 0x06002737 RID: 10039 RVA: 0x001513AE File Offset: 0x0014F5AE
        // (set) Token: 0x06002738 RID: 10040 RVA: 0x001513BB File Offset: 0x0014F5BB
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x170000D0 RID: 208
        // (get) Token: 0x06002739 RID: 10041 RVA: 0x001513C9 File Offset: 0x0014F5C9
        // (set) Token: 0x0600273A RID: 10042 RVA: 0x001513D6 File Offset: 0x0014F5D6
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x170000D1 RID: 209
        // (get) Token: 0x0600273B RID: 10043 RVA: 0x001513E4 File Offset: 0x0014F5E4
        // (set) Token: 0x0600273C RID: 10044 RVA: 0x001513F1 File Offset: 0x0014F5F1
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x170000D2 RID: 210
        // (get) Token: 0x0600273D RID: 10045 RVA: 0x001513FF File Offset: 0x0014F5FF
        // (set) Token: 0x0600273E RID: 10046 RVA: 0x0015140C File Offset: 0x0014F60C
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x170000D3 RID: 211
        // (get) Token: 0x0600273F RID: 10047 RVA: 0x0015141A File Offset: 0x0014F61A
        // (set) Token: 0x06002740 RID: 10048 RVA: 0x00151427 File Offset: 0x0014F627
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x170000D4 RID: 212
        // (get) Token: 0x06002741 RID: 10049 RVA: 0x0015143A File Offset: 0x0014F63A
        // (set) Token: 0x06002742 RID: 10050 RVA: 0x00151447 File Offset: 0x0014F647
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x170000D5 RID: 213
        // (get) Token: 0x06002743 RID: 10051 RVA: 0x0015145A File Offset: 0x0014F65A
        // (set) Token: 0x06002744 RID: 10052 RVA: 0x00151472 File Offset: 0x0014F672
        public AppMain.NNS_QUATERNION rotate
        {
            get
            {
                return this.rtm_work_.rotate[0];
            }
            set
            {
                this.rtm_work_.rotate[0] = value;
            }
        }

        // Token: 0x170000D6 RID: 214
        // (get) Token: 0x06002745 RID: 10053 RVA: 0x0015148B File Offset: 0x0014F68B
        // (set) Token: 0x06002746 RID: 10054 RVA: 0x0015149E File Offset: 0x0014F69E
        public float spread
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 0 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 0 );
            }
        }

        // Token: 0x06002747 RID: 10055 RVA: 0x001514B2 File Offset: 0x0014F6B2
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_DIRECTIONAL work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061C9 RID: 25033
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003B9 RID: 953
    public struct AMS_AME_RUNTIME_WORK_OMNI
    {
        // Token: 0x06002748 RID: 10056 RVA: 0x001514BB File Offset: 0x0014F6BB
        public AMS_AME_RUNTIME_WORK_OMNI( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
        }

        // Token: 0x170000D7 RID: 215
        // (get) Token: 0x06002749 RID: 10057 RVA: 0x001514C4 File Offset: 0x0014F6C4
        // (set) Token: 0x0600274A RID: 10058 RVA: 0x001514D1 File Offset: 0x0014F6D1
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x170000D8 RID: 216
        // (get) Token: 0x0600274B RID: 10059 RVA: 0x001514DF File Offset: 0x0014F6DF
        // (set) Token: 0x0600274C RID: 10060 RVA: 0x001514EC File Offset: 0x0014F6EC
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x170000D9 RID: 217
        // (get) Token: 0x0600274D RID: 10061 RVA: 0x001514FA File Offset: 0x0014F6FA
        // (set) Token: 0x0600274E RID: 10062 RVA: 0x00151507 File Offset: 0x0014F707
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x170000DA RID: 218
        // (get) Token: 0x0600274F RID: 10063 RVA: 0x00151515 File Offset: 0x0014F715
        // (set) Token: 0x06002750 RID: 10064 RVA: 0x00151522 File Offset: 0x0014F722
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x170000DB RID: 219
        // (get) Token: 0x06002751 RID: 10065 RVA: 0x00151530 File Offset: 0x0014F730
        // (set) Token: 0x06002752 RID: 10066 RVA: 0x0015153D File Offset: 0x0014F73D
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x170000DC RID: 220
        // (get) Token: 0x06002753 RID: 10067 RVA: 0x00151550 File Offset: 0x0014F750
        // (set) Token: 0x06002754 RID: 10068 RVA: 0x0015155D File Offset: 0x0014F75D
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x170000DD RID: 221
        // (get) Token: 0x06002755 RID: 10069 RVA: 0x00151570 File Offset: 0x0014F770
        // (set) Token: 0x06002756 RID: 10070 RVA: 0x00151588 File Offset: 0x0014F788
        public AppMain.NNS_QUATERNION rotate
        {
            get
            {
                return this.rtm_work_.rotate[0];
            }
            set
            {
                this.rtm_work_.rotate[0] = value;
            }
        }

        // Token: 0x170000DE RID: 222
        // (get) Token: 0x06002757 RID: 10071 RVA: 0x001515A1 File Offset: 0x0014F7A1
        // (set) Token: 0x06002758 RID: 10072 RVA: 0x001515B4 File Offset: 0x0014F7B4
        public float offset
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 0 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 0 );
            }
        }

        // Token: 0x170000DF RID: 223
        // (get) Token: 0x06002759 RID: 10073 RVA: 0x001515C8 File Offset: 0x0014F7C8
        // (set) Token: 0x0600275A RID: 10074 RVA: 0x001515DB File Offset: 0x0014F7DB
        public float offset_chaos
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 4 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 4 );
            }
        }

        // Token: 0x0600275B RID: 10075 RVA: 0x001515EF File Offset: 0x0014F7EF
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_OMNI work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061CA RID: 25034
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003BA RID: 954
    public struct AMS_AME_RUNTIME_WORK_SURFACE
    {
        // Token: 0x0600275C RID: 10076 RVA: 0x001515F8 File Offset: 0x0014F7F8
        public AMS_AME_RUNTIME_WORK_SURFACE( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
        }

        // Token: 0x170000E0 RID: 224
        // (get) Token: 0x0600275D RID: 10077 RVA: 0x00151601 File Offset: 0x0014F801
        // (set) Token: 0x0600275E RID: 10078 RVA: 0x0015160E File Offset: 0x0014F80E
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x170000E1 RID: 225
        // (get) Token: 0x0600275F RID: 10079 RVA: 0x0015161C File Offset: 0x0014F81C
        // (set) Token: 0x06002760 RID: 10080 RVA: 0x00151629 File Offset: 0x0014F829
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x170000E2 RID: 226
        // (get) Token: 0x06002761 RID: 10081 RVA: 0x00151637 File Offset: 0x0014F837
        // (set) Token: 0x06002762 RID: 10082 RVA: 0x00151644 File Offset: 0x0014F844
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x170000E3 RID: 227
        // (get) Token: 0x06002763 RID: 10083 RVA: 0x00151652 File Offset: 0x0014F852
        // (set) Token: 0x06002764 RID: 10084 RVA: 0x0015165F File Offset: 0x0014F85F
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x170000E4 RID: 228
        // (get) Token: 0x06002765 RID: 10085 RVA: 0x0015166D File Offset: 0x0014F86D
        // (set) Token: 0x06002766 RID: 10086 RVA: 0x0015167A File Offset: 0x0014F87A
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x170000E5 RID: 229
        // (get) Token: 0x06002767 RID: 10087 RVA: 0x0015168D File Offset: 0x0014F88D
        // (set) Token: 0x06002768 RID: 10088 RVA: 0x0015169A File Offset: 0x0014F89A
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x170000E6 RID: 230
        // (get) Token: 0x06002769 RID: 10089 RVA: 0x001516AD File Offset: 0x0014F8AD
        // (set) Token: 0x0600276A RID: 10090 RVA: 0x001516C5 File Offset: 0x0014F8C5
        public AppMain.NNS_QUATERNION rotate
        {
            get
            {
                return this.rtm_work_.rotate[0];
            }
            set
            {
                this.rtm_work_.rotate[0] = value;
            }
        }

        // Token: 0x170000E7 RID: 231
        // (get) Token: 0x0600276B RID: 10091 RVA: 0x001516DE File Offset: 0x0014F8DE
        // (set) Token: 0x0600276C RID: 10092 RVA: 0x001516F1 File Offset: 0x0014F8F1
        public float width
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 0 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 0 );
            }
        }

        // Token: 0x170000E8 RID: 232
        // (get) Token: 0x0600276D RID: 10093 RVA: 0x00151705 File Offset: 0x0014F905
        // (set) Token: 0x0600276E RID: 10094 RVA: 0x00151718 File Offset: 0x0014F918
        public float height
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 4 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 4 );
            }
        }

        // Token: 0x170000E9 RID: 233
        // (get) Token: 0x0600276F RID: 10095 RVA: 0x0015172C File Offset: 0x0014F92C
        // (set) Token: 0x06002770 RID: 10096 RVA: 0x0015173F File Offset: 0x0014F93F
        public float offset
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 8 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 8 );
            }
        }

        // Token: 0x170000EA RID: 234
        // (get) Token: 0x06002771 RID: 10097 RVA: 0x00151753 File Offset: 0x0014F953
        // (set) Token: 0x06002772 RID: 10098 RVA: 0x00151767 File Offset: 0x0014F967
        public float offset_chaos
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 12 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 12 );
            }
        }

        // Token: 0x06002773 RID: 10099 RVA: 0x0015177C File Offset: 0x0014F97C
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_SURFACE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061CB RID: 25035
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003BB RID: 955
    public struct AMS_AME_RUNTIME_WORK_CIRCLE
    {
        // Token: 0x06002774 RID: 10100 RVA: 0x00151785 File Offset: 0x0014F985
        public AMS_AME_RUNTIME_WORK_CIRCLE( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
        }

        // Token: 0x170000EB RID: 235
        // (get) Token: 0x06002775 RID: 10101 RVA: 0x0015178E File Offset: 0x0014F98E
        // (set) Token: 0x06002776 RID: 10102 RVA: 0x0015179B File Offset: 0x0014F99B
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x170000EC RID: 236
        // (get) Token: 0x06002777 RID: 10103 RVA: 0x001517A9 File Offset: 0x0014F9A9
        // (set) Token: 0x06002778 RID: 10104 RVA: 0x001517B6 File Offset: 0x0014F9B6
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x170000ED RID: 237
        // (get) Token: 0x06002779 RID: 10105 RVA: 0x001517C4 File Offset: 0x0014F9C4
        // (set) Token: 0x0600277A RID: 10106 RVA: 0x001517D1 File Offset: 0x0014F9D1
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x170000EE RID: 238
        // (get) Token: 0x0600277B RID: 10107 RVA: 0x001517DF File Offset: 0x0014F9DF
        // (set) Token: 0x0600277C RID: 10108 RVA: 0x001517EC File Offset: 0x0014F9EC
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x170000EF RID: 239
        // (get) Token: 0x0600277D RID: 10109 RVA: 0x001517FA File Offset: 0x0014F9FA
        // (set) Token: 0x0600277E RID: 10110 RVA: 0x00151807 File Offset: 0x0014FA07
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x170000F0 RID: 240
        // (get) Token: 0x0600277F RID: 10111 RVA: 0x0015181A File Offset: 0x0014FA1A
        // (set) Token: 0x06002780 RID: 10112 RVA: 0x00151827 File Offset: 0x0014FA27
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x170000F1 RID: 241
        // (get) Token: 0x06002781 RID: 10113 RVA: 0x0015183A File Offset: 0x0014FA3A
        // (set) Token: 0x06002782 RID: 10114 RVA: 0x00151852 File Offset: 0x0014FA52
        public AppMain.NNS_QUATERNION rotate
        {
            get
            {
                return this.rtm_work_.rotate[0];
            }
            set
            {
                this.rtm_work_.rotate[0] = value;
            }
        }

        // Token: 0x170000F2 RID: 242
        // (get) Token: 0x06002783 RID: 10115 RVA: 0x0015186B File Offset: 0x0014FA6B
        // (set) Token: 0x06002784 RID: 10116 RVA: 0x0015187E File Offset: 0x0014FA7E
        public float spread
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 0 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 0 );
            }
        }

        // Token: 0x170000F3 RID: 243
        // (get) Token: 0x06002785 RID: 10117 RVA: 0x00151892 File Offset: 0x0014FA92
        // (set) Token: 0x06002786 RID: 10118 RVA: 0x001518A5 File Offset: 0x0014FAA5
        public float radius
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 4 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 4 );
            }
        }

        // Token: 0x170000F4 RID: 244
        // (get) Token: 0x06002787 RID: 10119 RVA: 0x001518B9 File Offset: 0x0014FAB9
        // (set) Token: 0x06002788 RID: 10120 RVA: 0x001518CC File Offset: 0x0014FACC
        public float offset
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 8 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 8 );
            }
        }

        // Token: 0x170000F5 RID: 245
        // (get) Token: 0x06002789 RID: 10121 RVA: 0x001518E0 File Offset: 0x0014FAE0
        // (set) Token: 0x0600278A RID: 10122 RVA: 0x001518F4 File Offset: 0x0014FAF4
        public float offset_chaos
        {
            get
            {
                return BitConverter.ToSingle( this.rtm_work_.dummy, 12 );
            }
            set
            {
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, 12 );
            }
        }

        // Token: 0x0600278B RID: 10123 RVA: 0x00151909 File Offset: 0x0014FB09
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_CIRCLE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061CC RID: 25036
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003BC RID: 956
    public struct AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE
    {
        // Token: 0x0600278C RID: 10124 RVA: 0x00151914 File Offset: 0x0014FB14
        public AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
            this.st_ = new AppMain.Vector4D_Quat( rtm_work.rotate );
            this.size_ = new AppMain.Vector4D_Buf( rtm_work.dummy, 0 );
            this.color_ = new AppMain.AMS_RGBA8888_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes );
        }

        // Token: 0x170000F6 RID: 246
        // (get) Token: 0x0600278D RID: 10125 RVA: 0x00151961 File Offset: 0x0014FB61
        // (set) Token: 0x0600278E RID: 10126 RVA: 0x0015196E File Offset: 0x0014FB6E
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x170000F7 RID: 247
        // (get) Token: 0x0600278F RID: 10127 RVA: 0x0015197C File Offset: 0x0014FB7C
        // (set) Token: 0x06002790 RID: 10128 RVA: 0x00151989 File Offset: 0x0014FB89
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x170000F8 RID: 248
        // (get) Token: 0x06002791 RID: 10129 RVA: 0x00151997 File Offset: 0x0014FB97
        // (set) Token: 0x06002792 RID: 10130 RVA: 0x001519A4 File Offset: 0x0014FBA4
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x170000F9 RID: 249
        // (get) Token: 0x06002793 RID: 10131 RVA: 0x001519B2 File Offset: 0x0014FBB2
        // (set) Token: 0x06002794 RID: 10132 RVA: 0x001519BF File Offset: 0x0014FBBF
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x170000FA RID: 250
        // (get) Token: 0x06002795 RID: 10133 RVA: 0x001519CD File Offset: 0x0014FBCD
        // (set) Token: 0x06002796 RID: 10134 RVA: 0x001519DA File Offset: 0x0014FBDA
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x170000FB RID: 251
        // (get) Token: 0x06002797 RID: 10135 RVA: 0x001519ED File Offset: 0x0014FBED
        // (set) Token: 0x06002798 RID: 10136 RVA: 0x001519FA File Offset: 0x0014FBFA
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x170000FC RID: 252
        // (get) Token: 0x06002799 RID: 10137 RVA: 0x00151A0D File Offset: 0x0014FC0D
        public AppMain.Vector4D_Quat st
        {
            get
            {
                return this.st_;
            }
        }

        // Token: 0x0600279A RID: 10138 RVA: 0x00151A18 File Offset: 0x0014FC18
        public void set_st( float x, float y, float z, float w )
        {
            this.st.Assign( x, y, z, w );
        }

        // Token: 0x170000FD RID: 253
        // (get) Token: 0x0600279B RID: 10139 RVA: 0x00151A38 File Offset: 0x0014FC38
        public AppMain.Vector4D_Buf size
        {
            get
            {
                return this.size_;
            }
        }

        // Token: 0x0600279C RID: 10140 RVA: 0x00151A40 File Offset: 0x0014FC40
        public void set_size( float x, float y, float z, float w )
        {
            this.size_.x = x;
            this.size_.y = y;
            this.size_.z = z;
            this.size_.w = w;
        }

        // Token: 0x0600279D RID: 10141 RVA: 0x00151A73 File Offset: 0x0014FC73
        public void set_size( AppMain.NNS_VECTOR4D v )
        {
            this.size_.Assign( v );
        }

        // Token: 0x170000FE RID: 254
        // (get) Token: 0x0600279E RID: 10142 RVA: 0x00151A81 File Offset: 0x0014FC81
        public AppMain.AMS_RGBA8888_Buf color
        {
            get
            {
                return this.color_;
            }
        }

        // Token: 0x0600279F RID: 10143 RVA: 0x00151A89 File Offset: 0x0014FC89
        public void set_color( byte r, byte g, byte b, byte a )
        {
            this.color_.r = r;
            this.color_.g = g;
            this.color_.b = b;
            this.color_.a = a;
        }

        // Token: 0x060027A0 RID: 10144 RVA: 0x00151ABC File Offset: 0x0014FCBC
        public void set_color( uint c )
        {
            this.color_.color = c;
        }

        // Token: 0x170000FF RID: 255
        // (get) Token: 0x060027A1 RID: 10145 RVA: 0x00151ACC File Offset: 0x0014FCCC
        // (set) Token: 0x060027A2 RID: 10146 RVA: 0x00151AF8 File Offset: 0x0014FCF8
        public float tex_time
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x17000100 RID: 256
        // (get) Token: 0x060027A3 RID: 10147 RVA: 0x00151B24 File Offset: 0x0014FD24
        // (set) Token: 0x060027A4 RID: 10148 RVA: 0x00151B50 File Offset: 0x0014FD50
        public int tex_no
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                return BitConverter.ToInt32( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x060027A5 RID: 10149 RVA: 0x00151B7D File Offset: 0x0014FD7D
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x060027A6 RID: 10150 RVA: 0x00151B86 File Offset: 0x0014FD86
        public static implicit operator AppMain.AMS_AME_RUNTIME_WORK( AppMain.AMS_AME_RUNTIME_WORK_SIMPLE_SPRITE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061CD RID: 25037
        private AppMain.Vector4D_Quat st_;

        // Token: 0x040061CE RID: 25038
        private AppMain.Vector4D_Buf size_;

        // Token: 0x040061CF RID: 25039
        private AppMain.AMS_RGBA8888_Buf color_;

        // Token: 0x040061D0 RID: 25040
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003BD RID: 957
    public struct AMS_AME_RUNTIME_WORK_SPRITE
    {
        // Token: 0x060027A7 RID: 10151 RVA: 0x00151B90 File Offset: 0x0014FD90
        public AMS_AME_RUNTIME_WORK_SPRITE( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
            this.st_ = new AppMain.Vector4D_Quat( rtm_work.rotate );
            this.size_ = new AppMain.Vector4D_Buf( rtm_work.dummy, 0 );
            this.color_ = new AppMain.AMS_RGBA8888_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes );
        }

        // Token: 0x17000101 RID: 257
        // (get) Token: 0x060027A8 RID: 10152 RVA: 0x00151BDD File Offset: 0x0014FDDD
        // (set) Token: 0x060027A9 RID: 10153 RVA: 0x00151BEA File Offset: 0x0014FDEA
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x17000102 RID: 258
        // (get) Token: 0x060027AA RID: 10154 RVA: 0x00151BF8 File Offset: 0x0014FDF8
        // (set) Token: 0x060027AB RID: 10155 RVA: 0x00151C05 File Offset: 0x0014FE05
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x17000103 RID: 259
        // (get) Token: 0x060027AC RID: 10156 RVA: 0x00151C13 File Offset: 0x0014FE13
        // (set) Token: 0x060027AD RID: 10157 RVA: 0x00151C20 File Offset: 0x0014FE20
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x17000104 RID: 260
        // (get) Token: 0x060027AE RID: 10158 RVA: 0x00151C2E File Offset: 0x0014FE2E
        // (set) Token: 0x060027AF RID: 10159 RVA: 0x00151C3B File Offset: 0x0014FE3B
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x17000105 RID: 261
        // (get) Token: 0x060027B0 RID: 10160 RVA: 0x00151C49 File Offset: 0x0014FE49
        // (set) Token: 0x060027B1 RID: 10161 RVA: 0x00151C56 File Offset: 0x0014FE56
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x17000106 RID: 262
        // (get) Token: 0x060027B2 RID: 10162 RVA: 0x00151C69 File Offset: 0x0014FE69
        // (set) Token: 0x060027B3 RID: 10163 RVA: 0x00151C76 File Offset: 0x0014FE76
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x17000107 RID: 263
        // (get) Token: 0x060027B4 RID: 10164 RVA: 0x00151C89 File Offset: 0x0014FE89
        public AppMain.Vector4D_Quat st
        {
            get
            {
                return this.st_;
            }
        }

        // Token: 0x060027B5 RID: 10165 RVA: 0x00151C91 File Offset: 0x0014FE91
        public void set_st( float x, float y, float z, float w )
        {
            this.st_.Assign( x, y, z, w );
        }

        // Token: 0x17000108 RID: 264
        // (get) Token: 0x060027B6 RID: 10166 RVA: 0x00151CA3 File Offset: 0x0014FEA3
        public AppMain.Vector4D_Buf size
        {
            get
            {
                return this.size_;
            }
        }

        // Token: 0x060027B7 RID: 10167 RVA: 0x00151CAB File Offset: 0x0014FEAB
        public void set_size( float x, float y, float z, float w )
        {
            this.size_.x = x;
            this.size_.y = y;
            this.size_.z = z;
            this.size_.w = w;
        }

        // Token: 0x060027B8 RID: 10168 RVA: 0x00151CDE File Offset: 0x0014FEDE
        public void set_size( AppMain.NNS_VECTOR4D v )
        {
            this.size_.Assign( v );
        }

        // Token: 0x17000109 RID: 265
        // (get) Token: 0x060027B9 RID: 10169 RVA: 0x00151CEC File Offset: 0x0014FEEC
        public AppMain.AMS_RGBA8888_Buf color
        {
            get
            {
                return this.color_;
            }
        }

        // Token: 0x060027BA RID: 10170 RVA: 0x00151CF4 File Offset: 0x0014FEF4
        public void set_color( byte r, byte g, byte b, byte a )
        {
            this.color_.r = r;
            this.color_.g = g;
            this.color_.b = b;
            this.color_.a = a;
        }

        // Token: 0x060027BB RID: 10171 RVA: 0x00151D27 File Offset: 0x0014FF27
        public void set_color( uint c )
        {
            this.color_.color = c;
        }

        // Token: 0x1700010A RID: 266
        // (get) Token: 0x060027BC RID: 10172 RVA: 0x00151D38 File Offset: 0x0014FF38
        // (set) Token: 0x060027BD RID: 10173 RVA: 0x00151D64 File Offset: 0x0014FF64
        public float twist
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x1700010B RID: 267
        // (get) Token: 0x060027BE RID: 10174 RVA: 0x00151D90 File Offset: 0x0014FF90
        // (set) Token: 0x060027BF RID: 10175 RVA: 0x00151DBC File Offset: 0x0014FFBC
        public float twist_speed
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x1700010C RID: 268
        // (get) Token: 0x060027C0 RID: 10176 RVA: 0x00151DEC File Offset: 0x0014FFEC
        // (set) Token: 0x060027C1 RID: 10177 RVA: 0x00151E18 File Offset: 0x00150018
        public float tex_time
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 8;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 8;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x1700010D RID: 269
        // (get) Token: 0x060027C2 RID: 10178 RVA: 0x00151E48 File Offset: 0x00150048
        // (set) Token: 0x060027C3 RID: 10179 RVA: 0x00151E78 File Offset: 0x00150078
        public int tex_no
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 12;
                return BitConverter.ToInt32( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 12;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x060027C4 RID: 10180 RVA: 0x00151EA6 File Offset: 0x001500A6
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_SPRITE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x060027C5 RID: 10181 RVA: 0x00151EAF File Offset: 0x001500AF
        public static implicit operator AppMain.AMS_AME_RUNTIME_WORK( AppMain.AMS_AME_RUNTIME_WORK_SPRITE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061D1 RID: 25041
        private AppMain.Vector4D_Quat st_;

        // Token: 0x040061D2 RID: 25042
        private AppMain.Vector4D_Buf size_;

        // Token: 0x040061D3 RID: 25043
        private AppMain.AMS_RGBA8888_Buf color_;

        // Token: 0x040061D4 RID: 25044
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003BE RID: 958
    public struct AMS_AME_RUNTIME_WORK_LINE
    {
        // Token: 0x060027C6 RID: 10182 RVA: 0x00151EB8 File Offset: 0x001500B8
        public AMS_AME_RUNTIME_WORK_LINE( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
            this.st_ = new AppMain.Vector4D_Quat( rtm_work.rotate );
            this.inside_color_ = new AppMain.AMS_RGBA8888_Buf( rtm_work.dummy, 0 );
            this.outside_color_ = new AppMain.AMS_RGBA8888_Buf( rtm_work.dummy, AppMain.AMS_RGBA8888_Buf.SizeBytes );
        }

        // Token: 0x1700010E RID: 270
        // (get) Token: 0x060027C7 RID: 10183 RVA: 0x00151F05 File Offset: 0x00150105
        // (set) Token: 0x060027C8 RID: 10184 RVA: 0x00151F12 File Offset: 0x00150112
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x1700010F RID: 271
        // (get) Token: 0x060027C9 RID: 10185 RVA: 0x00151F20 File Offset: 0x00150120
        // (set) Token: 0x060027CA RID: 10186 RVA: 0x00151F2D File Offset: 0x0015012D
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x17000110 RID: 272
        // (get) Token: 0x060027CB RID: 10187 RVA: 0x00151F3B File Offset: 0x0015013B
        // (set) Token: 0x060027CC RID: 10188 RVA: 0x00151F48 File Offset: 0x00150148
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x17000111 RID: 273
        // (get) Token: 0x060027CD RID: 10189 RVA: 0x00151F56 File Offset: 0x00150156
        // (set) Token: 0x060027CE RID: 10190 RVA: 0x00151F63 File Offset: 0x00150163
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x17000112 RID: 274
        // (get) Token: 0x060027CF RID: 10191 RVA: 0x00151F71 File Offset: 0x00150171
        // (set) Token: 0x060027D0 RID: 10192 RVA: 0x00151F7E File Offset: 0x0015017E
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x17000113 RID: 275
        // (get) Token: 0x060027D1 RID: 10193 RVA: 0x00151F91 File Offset: 0x00150191
        // (set) Token: 0x060027D2 RID: 10194 RVA: 0x00151F9E File Offset: 0x0015019E
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x17000114 RID: 276
        // (get) Token: 0x060027D3 RID: 10195 RVA: 0x00151FB1 File Offset: 0x001501B1
        public AppMain.Vector4D_Quat st
        {
            get
            {
                return this.st_;
            }
        }

        // Token: 0x060027D4 RID: 10196 RVA: 0x00151FB9 File Offset: 0x001501B9
        public void set_st( float x, float y, float z, float w )
        {
            this.st_.Assign( x, y, z, w );
        }

        // Token: 0x17000115 RID: 277
        // (get) Token: 0x060027D5 RID: 10197 RVA: 0x00151FCB File Offset: 0x001501CB
        public AppMain.AMS_RGBA8888_Buf inside_color
        {
            get
            {
                return this.inside_color_;
            }
        }

        // Token: 0x060027D6 RID: 10198 RVA: 0x00151FD3 File Offset: 0x001501D3
        public void set_inside_color( byte r, byte g, byte b, byte a )
        {
            this.inside_color_.r = r;
            this.inside_color_.g = g;
            this.inside_color_.b = b;
            this.inside_color_.a = a;
        }

        // Token: 0x060027D7 RID: 10199 RVA: 0x00152006 File Offset: 0x00150206
        public void set_inside_color( uint c )
        {
            this.inside_color_.color = c;
        }

        // Token: 0x17000116 RID: 278
        // (get) Token: 0x060027D8 RID: 10200 RVA: 0x00152014 File Offset: 0x00150214
        public AppMain.AMS_RGBA8888_Buf outside_color
        {
            get
            {
                return this.outside_color_;
            }
        }

        // Token: 0x060027D9 RID: 10201 RVA: 0x0015201C File Offset: 0x0015021C
        public void set_outside_color( byte r, byte g, byte b, byte a )
        {
            this.outside_color_.r = r;
            this.outside_color_.g = g;
            this.outside_color_.b = b;
            this.outside_color_.a = a;
        }

        // Token: 0x060027DA RID: 10202 RVA: 0x0015204F File Offset: 0x0015024F
        public void set_outside_color( uint c )
        {
            this.outside_color_.color = c;
        }

        // Token: 0x17000117 RID: 279
        // (get) Token: 0x060027DB RID: 10203 RVA: 0x00152060 File Offset: 0x00150260
        // (set) Token: 0x060027DC RID: 10204 RVA: 0x0015208C File Offset: 0x0015028C
        public float inside_width
        {
            get
            {
                int num = AppMain.AMS_RGBA8888_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.AMS_RGBA8888_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x17000118 RID: 280
        // (get) Token: 0x060027DD RID: 10205 RVA: 0x001520B8 File Offset: 0x001502B8
        // (set) Token: 0x060027DE RID: 10206 RVA: 0x001520E4 File Offset: 0x001502E4
        public float outside_width
        {
            get
            {
                int num = AppMain.AMS_RGBA8888_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.AMS_RGBA8888_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x17000119 RID: 281
        // (get) Token: 0x060027DF RID: 10207 RVA: 0x00152114 File Offset: 0x00150314
        // (set) Token: 0x060027E0 RID: 10208 RVA: 0x00152140 File Offset: 0x00150340
        public float length
        {
            get
            {
                int num = AppMain.AMS_RGBA8888_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 8;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.AMS_RGBA8888_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 8;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x1700011A RID: 282
        // (get) Token: 0x060027E1 RID: 10209 RVA: 0x00152170 File Offset: 0x00150370
        // (set) Token: 0x060027E2 RID: 10210 RVA: 0x001521A0 File Offset: 0x001503A0
        public float tex_time
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 12;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 12;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x1700011B RID: 283
        // (get) Token: 0x060027E3 RID: 10211 RVA: 0x001521D0 File Offset: 0x001503D0
        // (set) Token: 0x060027E4 RID: 10212 RVA: 0x00152200 File Offset: 0x00150400
        public int tex_no
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 16;
                return BitConverter.ToInt32( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 16;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x060027E5 RID: 10213 RVA: 0x0015222E File Offset: 0x0015042E
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_LINE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x060027E6 RID: 10214 RVA: 0x00152237 File Offset: 0x00150437
        public static implicit operator AppMain.AMS_AME_RUNTIME_WORK( AppMain.AMS_AME_RUNTIME_WORK_LINE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061D5 RID: 25045
        private AppMain.Vector4D_Quat st_;

        // Token: 0x040061D6 RID: 25046
        private AppMain.AMS_RGBA8888_Buf inside_color_;

        // Token: 0x040061D7 RID: 25047
        private AppMain.AMS_RGBA8888_Buf outside_color_;

        // Token: 0x040061D8 RID: 25048
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003BF RID: 959
    public struct AMS_AME_RUNTIME_WORK_PLANE
    {
        // Token: 0x060027E7 RID: 10215 RVA: 0x00152240 File Offset: 0x00150440
        public AMS_AME_RUNTIME_WORK_PLANE( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
            this.rotate_axis_ = new AppMain.Vector4D_Buf( rtm_work.dummy, 0 );
            this.st_ = new AppMain.Vector4D_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes );
            this.size_ = new AppMain.Vector4D_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes + AppMain.Vector4D_Buf.SizeBytes );
            this.color_ = new AppMain.AMS_RGBA8888_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes * 3 );
        }

        // Token: 0x1700011C RID: 284
        // (get) Token: 0x060027E8 RID: 10216 RVA: 0x001522B0 File Offset: 0x001504B0
        // (set) Token: 0x060027E9 RID: 10217 RVA: 0x001522BD File Offset: 0x001504BD
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x1700011D RID: 285
        // (get) Token: 0x060027EA RID: 10218 RVA: 0x001522CB File Offset: 0x001504CB
        // (set) Token: 0x060027EB RID: 10219 RVA: 0x001522D8 File Offset: 0x001504D8
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x1700011E RID: 286
        // (get) Token: 0x060027EC RID: 10220 RVA: 0x001522E6 File Offset: 0x001504E6
        // (set) Token: 0x060027ED RID: 10221 RVA: 0x001522F3 File Offset: 0x001504F3
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x1700011F RID: 287
        // (get) Token: 0x060027EE RID: 10222 RVA: 0x00152301 File Offset: 0x00150501
        // (set) Token: 0x060027EF RID: 10223 RVA: 0x0015230E File Offset: 0x0015050E
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x17000120 RID: 288
        // (get) Token: 0x060027F0 RID: 10224 RVA: 0x0015231C File Offset: 0x0015051C
        // (set) Token: 0x060027F1 RID: 10225 RVA: 0x00152329 File Offset: 0x00150529
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x17000121 RID: 289
        // (get) Token: 0x060027F2 RID: 10226 RVA: 0x0015233C File Offset: 0x0015053C
        // (set) Token: 0x060027F3 RID: 10227 RVA: 0x00152349 File Offset: 0x00150549
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x17000122 RID: 290
        // (get) Token: 0x060027F4 RID: 10228 RVA: 0x0015235C File Offset: 0x0015055C
        // (set) Token: 0x060027F5 RID: 10229 RVA: 0x00152374 File Offset: 0x00150574
        public AppMain.NNS_QUATERNION rotate
        {
            get
            {
                return this.rtm_work_.rotate[0];
            }
            set
            {
                this.rtm_work_.rotate[0] = value;
            }
        }

        // Token: 0x17000123 RID: 291
        // (get) Token: 0x060027F6 RID: 10230 RVA: 0x0015238D File Offset: 0x0015058D
        public AppMain.Vector4D_Buf rotate_axis
        {
            get
            {
                return this.rotate_axis_;
            }
        }

        // Token: 0x060027F7 RID: 10231 RVA: 0x00152395 File Offset: 0x00150595
        public void set_rotate_axis( float x, float y, float z, float w )
        {
            this.rotate_axis_.x = x;
            this.rotate_axis_.y = y;
            this.rotate_axis_.z = z;
            this.rotate_axis_.w = w;
        }

        // Token: 0x17000124 RID: 292
        // (get) Token: 0x060027F8 RID: 10232 RVA: 0x001523C8 File Offset: 0x001505C8
        public AppMain.Vector4D_Buf st
        {
            get
            {
                return this.st_;
            }
        }

        // Token: 0x060027F9 RID: 10233 RVA: 0x001523D0 File Offset: 0x001505D0
        public void set_st( float x, float y, float z, float w )
        {
            this.st_.x = x;
            this.st_.y = y;
            this.st_.z = z;
            this.st_.w = w;
        }

        // Token: 0x17000125 RID: 293
        // (get) Token: 0x060027FA RID: 10234 RVA: 0x00152403 File Offset: 0x00150603
        public AppMain.Vector4D_Buf size
        {
            get
            {
                return this.size_;
            }
        }

        // Token: 0x060027FB RID: 10235 RVA: 0x0015240B File Offset: 0x0015060B
        public void set_size( float x, float y, float z, float w )
        {
            this.size_.x = x;
            this.size_.y = y;
            this.size_.z = z;
            this.size_.w = w;
        }

        // Token: 0x060027FC RID: 10236 RVA: 0x0015243E File Offset: 0x0015063E
        public void set_size( AppMain.NNS_VECTOR4D v )
        {
            this.size_.Assign( v );
        }

        // Token: 0x17000126 RID: 294
        // (get) Token: 0x060027FD RID: 10237 RVA: 0x0015244C File Offset: 0x0015064C
        public AppMain.AMS_RGBA8888_Buf color
        {
            get
            {
                return this.color_;
            }
        }

        // Token: 0x060027FE RID: 10238 RVA: 0x00152454 File Offset: 0x00150654
        public void set_color( byte r, byte g, byte b, byte a )
        {
            this.color_.r = r;
            this.color_.g = g;
            this.color_.b = b;
            this.color_.a = a;
        }

        // Token: 0x060027FF RID: 10239 RVA: 0x00152487 File Offset: 0x00150687
        public void set_color( uint c )
        {
            this.color_.color = c;
        }

        // Token: 0x17000127 RID: 295
        // (get) Token: 0x06002800 RID: 10240 RVA: 0x00152498 File Offset: 0x00150698
        // (set) Token: 0x06002801 RID: 10241 RVA: 0x001524C4 File Offset: 0x001506C4
        public float tex_time
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes * 3 + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes * 3 + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x17000128 RID: 296
        // (get) Token: 0x06002802 RID: 10242 RVA: 0x001524F4 File Offset: 0x001506F4
        // (set) Token: 0x06002803 RID: 10243 RVA: 0x00152524 File Offset: 0x00150724
        public int tex_no
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes * 3 + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                return BitConverter.ToInt32( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes * 3 + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x06002804 RID: 10244 RVA: 0x00152553 File Offset: 0x00150753
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_PLANE work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061D9 RID: 25049
        private AppMain.Vector4D_Buf rotate_axis_;

        // Token: 0x040061DA RID: 25050
        private AppMain.Vector4D_Buf st_;

        // Token: 0x040061DB RID: 25051
        private AppMain.Vector4D_Buf size_;

        // Token: 0x040061DC RID: 25052
        private AppMain.AMS_RGBA8888_Buf color_;

        // Token: 0x040061DD RID: 25053
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003C0 RID: 960
    public struct AMS_AME_RUNTIME_WORK_MODEL
    {
        // Token: 0x06002805 RID: 10245 RVA: 0x0015255C File Offset: 0x0015075C
        public AMS_AME_RUNTIME_WORK_MODEL( AppMain.AMS_AME_RUNTIME_WORK rtm_work )
        {
            this.rtm_work_ = rtm_work;
            this.rotate_axis_ = new AppMain.Vector4D_Buf( rtm_work.dummy, 0 );
            this.scale_ = new AppMain.Vector4D_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes );
            this.color_ = new AppMain.AMS_RGBA8888_Buf( rtm_work.dummy, AppMain.Vector4D_Buf.SizeBytes + AppMain.Vector4D_Buf.SizeBytes );
        }

        // Token: 0x17000129 RID: 297
        // (get) Token: 0x06002806 RID: 10246 RVA: 0x001525B4 File Offset: 0x001507B4
        // (set) Token: 0x06002807 RID: 10247 RVA: 0x001525C1 File Offset: 0x001507C1
        public AppMain.AMS_AME_LIST next
        {
            get
            {
                return this.rtm_work_.next;
            }
            set
            {
                this.rtm_work_.next = value;
            }
        }

        // Token: 0x1700012A RID: 298
        // (get) Token: 0x06002808 RID: 10248 RVA: 0x001525CF File Offset: 0x001507CF
        // (set) Token: 0x06002809 RID: 10249 RVA: 0x001525DC File Offset: 0x001507DC
        public AppMain.AMS_AME_LIST prev
        {
            get
            {
                return this.rtm_work_.prev;
            }
            set
            {
                this.rtm_work_.prev = value;
            }
        }

        // Token: 0x1700012B RID: 299
        // (get) Token: 0x0600280A RID: 10250 RVA: 0x001525EA File Offset: 0x001507EA
        // (set) Token: 0x0600280B RID: 10251 RVA: 0x001525F7 File Offset: 0x001507F7
        public float time
        {
            get
            {
                return this.rtm_work_.time;
            }
            set
            {
                this.rtm_work_.time = value;
            }
        }

        // Token: 0x1700012C RID: 300
        // (get) Token: 0x0600280C RID: 10252 RVA: 0x00152605 File Offset: 0x00150805
        // (set) Token: 0x0600280D RID: 10253 RVA: 0x00152612 File Offset: 0x00150812
        public uint flag
        {
            get
            {
                return this.rtm_work_.flag;
            }
            set
            {
                this.rtm_work_.flag = value;
            }
        }

        // Token: 0x1700012D RID: 301
        // (get) Token: 0x0600280E RID: 10254 RVA: 0x00152620 File Offset: 0x00150820
        // (set) Token: 0x0600280F RID: 10255 RVA: 0x0015262D File Offset: 0x0015082D
        public AppMain.NNS_VECTOR4D position
        {
            get
            {
                return this.rtm_work_.position;
            }
            set
            {
                this.rtm_work_.position.Assign( value );
            }
        }

        // Token: 0x1700012E RID: 302
        // (get) Token: 0x06002810 RID: 10256 RVA: 0x00152640 File Offset: 0x00150840
        // (set) Token: 0x06002811 RID: 10257 RVA: 0x0015264D File Offset: 0x0015084D
        public AppMain.NNS_VECTOR4D velocity
        {
            get
            {
                return this.rtm_work_.velocity;
            }
            set
            {
                this.rtm_work_.velocity.Assign( value );
            }
        }

        // Token: 0x1700012F RID: 303
        // (get) Token: 0x06002812 RID: 10258 RVA: 0x00152660 File Offset: 0x00150860
        // (set) Token: 0x06002813 RID: 10259 RVA: 0x00152678 File Offset: 0x00150878
        public AppMain.NNS_QUATERNION rotate
        {
            get
            {
                return this.rtm_work_.rotate[0];
            }
            set
            {
                this.rtm_work_.rotate[0] = value;
            }
        }

        // Token: 0x17000130 RID: 304
        // (get) Token: 0x06002814 RID: 10260 RVA: 0x00152691 File Offset: 0x00150891
        public AppMain.Vector4D_Buf rotate_axis
        {
            get
            {
                return this.rotate_axis_;
            }
        }

        // Token: 0x06002815 RID: 10261 RVA: 0x00152699 File Offset: 0x00150899
        public void set_rotate_axis( float x, float y, float z, float w )
        {
            this.rotate_axis_.x = x;
            this.rotate_axis_.y = y;
            this.rotate_axis_.z = z;
            this.rotate_axis_.w = w;
        }

        // Token: 0x17000131 RID: 305
        // (get) Token: 0x06002816 RID: 10262 RVA: 0x001526CC File Offset: 0x001508CC
        public AppMain.Vector4D_Buf scale
        {
            get
            {
                return this.scale_;
            }
        }

        // Token: 0x06002817 RID: 10263 RVA: 0x001526D4 File Offset: 0x001508D4
        public void set_scale( float x, float y, float z, float w )
        {
            this.scale_.x = x;
            this.scale_.y = y;
            this.scale_.z = z;
            this.scale_.w = w;
        }

        // Token: 0x06002818 RID: 10264 RVA: 0x00152707 File Offset: 0x00150907
        public void set_scale( AppMain.NNS_VECTOR4D v )
        {
            this.scale_.Assign( v );
        }

        // Token: 0x06002819 RID: 10265 RVA: 0x00152715 File Offset: 0x00150915
        public void set_scale( AppMain.NNS_VECTOR v )
        {
            this.scale_.Assign( v );
        }

        // Token: 0x17000132 RID: 306
        // (get) Token: 0x0600281A RID: 10266 RVA: 0x00152723 File Offset: 0x00150923
        public AppMain.AMS_RGBA8888_Buf color
        {
            get
            {
                return this.color_;
            }
        }

        // Token: 0x0600281B RID: 10267 RVA: 0x0015272B File Offset: 0x0015092B
        public void set_color( byte r, byte g, byte b, byte a )
        {
            this.color_.r = r;
            this.color_.g = g;
            this.color_.b = b;
            this.color_.a = a;
        }

        // Token: 0x0600281C RID: 10268 RVA: 0x0015275E File Offset: 0x0015095E
        public void set_color( uint c )
        {
            this.color_.color = c;
        }

        // Token: 0x17000133 RID: 307
        // (get) Token: 0x0600281D RID: 10269 RVA: 0x0015276C File Offset: 0x0015096C
        // (set) Token: 0x0600281E RID: 10270 RVA: 0x0015279C File Offset: 0x0015099C
        public float scroll_u
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x17000134 RID: 308
        // (get) Token: 0x0600281F RID: 10271 RVA: 0x001527D0 File Offset: 0x001509D0
        // (set) Token: 0x06002820 RID: 10272 RVA: 0x00152804 File Offset: 0x00150A04
        public float scroll_v
        {
            get
            {
                int num = AppMain.Vector4D_Buf.SizeBytes + AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                return BitConverter.ToSingle( this.rtm_work_.dummy, num );
            }
            set
            {
                int offset = AppMain.Vector4D_Buf.SizeBytes + AppMain.Vector4D_Buf.SizeBytes + AppMain.AMS_RGBA8888_Buf.SizeBytes + 4;
                MppBitConverter.GetBytes( value, this.rtm_work_.dummy, offset );
            }
        }

        // Token: 0x06002821 RID: 10273 RVA: 0x00152837 File Offset: 0x00150A37
        public static explicit operator AppMain.AMS_AME_LIST( AppMain.AMS_AME_RUNTIME_WORK_MODEL work )
        {
            return work.rtm_work_;
        }

        // Token: 0x06002822 RID: 10274 RVA: 0x00152840 File Offset: 0x00150A40
        public static implicit operator AppMain.AMS_AME_RUNTIME_WORK( AppMain.AMS_AME_RUNTIME_WORK_MODEL work )
        {
            return work.rtm_work_;
        }

        // Token: 0x040061DE RID: 25054
        private AppMain.Vector4D_Buf rotate_axis_;

        // Token: 0x040061DF RID: 25055
        private AppMain.Vector4D_Buf scale_;

        // Token: 0x040061E0 RID: 25056
        private AppMain.AMS_RGBA8888_Buf color_;

        // Token: 0x040061E1 RID: 25057
        private AppMain.AMS_AME_RUNTIME_WORK rtm_work_;
    }

    // Token: 0x020003C1 RID: 961
    public class AMS_AME_ENTRY : AppMain.AMS_AME_LIST
    {
        // Token: 0x040061E2 RID: 25058
        public AppMain.AMS_AME_RUNTIME runtime;

        // Token: 0x040061E3 RID: 25059
        public uint reserved;
    }

    // Token: 0x020003C2 RID: 962
    public class AMS_AME_ECB : AppMain.AMS_AME_LIST
    {
        // Token: 0x06002824 RID: 10276 RVA: 0x00152854 File Offset: 0x00150A54
        public override void Clear()
        {
            this.next = null;
            this.prev = null;
            this.attribute = 0;
            this.priority = 0;
            this.translate.Clear();
            this.rotate.Clear();
            this.bounding.Clear();
            this.transparency = 0;
            this.size_rate = 0f;
            this.pObj = null;
            this.entry_head = null;
            this.entry_tail = null;
            this.entry_num = 0;
            this.drawState = 0U;
            this.drawObjState = 0U;
            this.skip_update = 0;
        }

        // Token: 0x040061E4 RID: 25060
        public int attribute;

        // Token: 0x040061E5 RID: 25061
        public int priority;

        // Token: 0x040061E6 RID: 25062
        public readonly AppMain.NNS_VECTOR4D translate = new AppMain.NNS_VECTOR4D();

        // Token: 0x040061E7 RID: 25063
        public AppMain.NNS_QUATERNION rotate;

        // Token: 0x040061E8 RID: 25064
        public readonly AppMain.AMS_AME_BOUNDING bounding = new AppMain.AMS_AME_BOUNDING();

        // Token: 0x040061E9 RID: 25065
        public int transparency;

        // Token: 0x040061EA RID: 25066
        public float size_rate;

        // Token: 0x040061EB RID: 25067
        public AppMain.NNS_OBJECT pObj;

        // Token: 0x040061EC RID: 25068
        public AppMain.AMS_AME_ENTRY entry_head;

        // Token: 0x040061ED RID: 25069
        public AppMain.AMS_AME_ENTRY entry_tail;

        // Token: 0x040061EE RID: 25070
        public int entry_num;

        // Token: 0x040061EF RID: 25071
        public uint drawState;

        // Token: 0x040061F0 RID: 25072
        public uint drawObjState;

        // Token: 0x040061F1 RID: 25073
        public int skip_update;
    }

    // Token: 0x020003C3 RID: 963
    public class AMS_AME_CREATE_PARAM : AppMain.IClearable
    {
        // Token: 0x06002826 RID: 10278 RVA: 0x001528FF File Offset: 0x00150AFF
        public void Clear()
        {
            this.ecb = null;
            this.runtime = null;
            this.node = null;
            this.work = null;
            this.position = null;
            this.velocity = null;
            this.parent_position = null;
            this.parent_velocity = null;
        }

        // Token: 0x040061F2 RID: 25074
        public AppMain.AMS_AME_ECB ecb;

        // Token: 0x040061F3 RID: 25075
        public AppMain.AMS_AME_RUNTIME runtime;

        // Token: 0x040061F4 RID: 25076
        public AppMain.AMS_AME_NODE node;

        // Token: 0x040061F5 RID: 25077
        public AppMain.AMS_AME_RUNTIME_WORK work;

        // Token: 0x040061F6 RID: 25078
        public AppMain.NNS_VECTOR4D position;

        // Token: 0x040061F7 RID: 25079
        public AppMain.NNS_VECTOR4D velocity;

        // Token: 0x040061F8 RID: 25080
        public AppMain.NNS_VECTOR4D parent_position;

        // Token: 0x040061F9 RID: 25081
        public AppMain.NNS_VECTOR4D parent_velocity;
    }

    // Token: 0x020003C4 RID: 964
    // (Invoke) Token: 0x06002829 RID: 10281
    public delegate int AmeDelegateFunc( object o );

    // Token: 0x020003C5 RID: 965
    // (Invoke) Token: 0x0600282D RID: 10285
    public delegate void AmeFieldFunc( AppMain.AMS_AME_ECB ecb, AppMain.AMS_AME_NODE node, AppMain.AMS_AME_RUNTIME_WORK work );

    // Token: 0x020003C6 RID: 966
    public class AMS_AME_CUSTOM_PARAM
    {
        // Token: 0x17000135 RID: 309
        // (get) Token: 0x06002830 RID: 10288 RVA: 0x00152941 File Offset: 0x00150B41
        // (set) Token: 0x06002831 RID: 10289 RVA: 0x0015294E File Offset: 0x00150B4E
        public AppMain.AmeDelegateFunc pInitFunc
        {
            get
            {
                return ( AppMain.AmeDelegateFunc )this._pInitFieldFunc;
            }
            set
            {
                this._pInitFieldFunc = value;
            }
        }

        // Token: 0x17000136 RID: 310
        // (get) Token: 0x06002832 RID: 10290 RVA: 0x00152957 File Offset: 0x00150B57
        // (set) Token: 0x06002833 RID: 10291 RVA: 0x00152964 File Offset: 0x00150B64
        public AppMain.AmeFieldFunc pFieldFunc
        {
            get
            {
                return ( AppMain.AmeFieldFunc )this._pInitFieldFunc;
            }
            set
            {
                this._pInitFieldFunc = value;
            }
        }

        // Token: 0x040061FA RID: 25082
        private object _pInitFieldFunc;

        // Token: 0x040061FB RID: 25083
        public AppMain.AmeDelegateFunc pUpdateFunc;

        // Token: 0x040061FC RID: 25084
        public AppMain.AmeDelegateFunc pDrawFunc;
    }


    // Token: 0x0600114D RID: 4429 RVA: 0x0009755C File Offset: 0x0009575C
    public static AppMain.AMS_AME_HEADER readAMEfile( string filename )
    {
        filename = string.Format( "Content/{0}", filename );
        BinaryReader binaryReader = new BinaryReader(TitleContainer.OpenStream(filename));
        AppMain.AMS_AME_HEADER result = AppMain.readAMEfile(binaryReader);
        binaryReader.Dispose();
        return result;
    }

    // Token: 0x0600114E RID: 4430 RVA: 0x00097590 File Offset: 0x00095790
    public static AppMain.AMS_AME_HEADER readAMEfile( AppMain.AmbChunk data )
    {
        AppMain.AMS_AME_HEADER result = null;
        using ( MemoryStream memoryStream = new MemoryStream( data.array, data.offset, data.array.Length - data.offset ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
            {
                result = AppMain.readAMEfile( binaryReader );
            }
        }
        return result;
    }

    // Token: 0x0600114F RID: 4431 RVA: 0x00097604 File Offset: 0x00095804
    private static AppMain.AMS_AME_TEX_ANIM readTexAnim( BinaryReader br )
    {
        AppMain.AMS_AME_TEX_ANIM ams_AME_TEX_ANIM = new AppMain.AMS_AME_TEX_ANIM();
        ams_AME_TEX_ANIM.time = br.ReadSingle();
        ams_AME_TEX_ANIM.key_num = br.ReadInt32();
        ams_AME_TEX_ANIM.key_buf = new AppMain.AMS_AME_TEX_ANIM_KEY[ams_AME_TEX_ANIM.key_num];
        for ( int i = 0; i < ams_AME_TEX_ANIM.key_num; i++ )
        {
            ams_AME_TEX_ANIM.key_buf[i].time = br.ReadSingle();
            ams_AME_TEX_ANIM.key_buf[i].l = br.ReadSingle();
            ams_AME_TEX_ANIM.key_buf[i].t = br.ReadSingle();
            ams_AME_TEX_ANIM.key_buf[i].r = br.ReadSingle();
            ams_AME_TEX_ANIM.key_buf[i].b = br.ReadSingle();
        }
        return ams_AME_TEX_ANIM;
    }

    // Token: 0x06001150 RID: 4432 RVA: 0x000976C5 File Offset: 0x000958C5
    private static void fillAMENodeBegin( AppMain.AMS_AME_NODE node, short id, short type, uint flag, char[] name, int child_offset, int sibling_offset, int parent_offset )
    {
        node.id = id;
        node.type = type;
        node.flag = flag;
        Array.Copy( name, 0, node.name, 0, 12 );
        node.child_offset = child_offset;
        node.sibling_offset = sibling_offset;
        node.parent_offset = parent_offset;
    }

    // Token: 0x06001151 RID: 4433 RVA: 0x00097705 File Offset: 0x00095905
    private static void readVector4( BinaryReader br, AppMain.NNS_VECTOR4D v )
    {
        v.x = br.ReadSingle();
        v.y = br.ReadSingle();
        v.z = br.ReadSingle();
        v.w = br.ReadSingle();
    }

    // Token: 0x06001152 RID: 4434 RVA: 0x00097737 File Offset: 0x00095937
    private static void readQuaternion( BinaryReader br, ref AppMain.NNS_QUATERNION q )
    {
        q.x = br.ReadSingle();
        q.y = br.ReadSingle();
        q.z = br.ReadSingle();
        q.w = br.ReadSingle();
    }

    // Token: 0x06001153 RID: 4435 RVA: 0x0009776C File Offset: 0x0009596C
    public static AppMain.AMS_AME_HEADER readAMEfile( BinaryReader br )
    {
        AppMain.AMS_AME_HEADER ams_AME_HEADER = new AppMain.AMS_AME_HEADER();
        ams_AME_HEADER.file_id = br.ReadBytes( 4 );
        ams_AME_HEADER.file_version = br.ReadInt32();
        ams_AME_HEADER.node_num = br.ReadInt32();
        ams_AME_HEADER.node_ofst = br.ReadUInt32();
        ams_AME_HEADER.bounding.center.x = br.ReadSingle();
        ams_AME_HEADER.bounding.center.y = br.ReadSingle();
        ams_AME_HEADER.bounding.center.z = br.ReadSingle();
        ams_AME_HEADER.bounding.center.w = br.ReadSingle();
        ams_AME_HEADER.bounding.radius = br.ReadSingle();
        ams_AME_HEADER.bounding.radius2 = br.ReadSingle();
        br.BaseStream.Seek( 8L, SeekOrigin.Current );
        br.BaseStream.Seek( 16L, SeekOrigin.Current );
        ams_AME_HEADER.node = new AppMain.AMS_AME_NODE[ams_AME_HEADER.node_num];
        br.BaseStream.Seek( ( long )( ( ulong )ams_AME_HEADER.node_ofst ), 0 );
        Dictionary<uint, AppMain.AMS_AME_NODE> dictionary = new Dictionary<uint, AppMain.AMS_AME_NODE>(ams_AME_HEADER.node_num);
        for ( int i = 0; i < ams_AME_HEADER.node_num; i++ )
        {
            uint num = (uint)br.BaseStream.Position;
            num += 15U;
            num &= 4294967280U;
            if ( ( ulong )num >= ( ulong )br.BaseStream.Length )
            {
                break;
            }
            br.BaseStream.Seek( ( long )( ( ulong )num ), 0 );
            short id = br.ReadInt16();
            AppMain.AME_AME_NODE_TYPE ame_AME_NODE_TYPE = (AppMain.AME_AME_NODE_TYPE)br.ReadInt16();
            uint flag = br.ReadUInt32();
            char[] name = br.ReadChars(12);
            int child_offset = br.ReadInt32();
            int sibling_offset = br.ReadInt32();
            int parent_offset = br.ReadInt32();
            AppMain.AME_AME_NODE_TYPE ame_AME_NODE_TYPE2 = ame_AME_NODE_TYPE;
            switch ( ame_AME_NODE_TYPE2 )
            {
                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_OMNI:
                    {
                        AppMain.AMS_AME_NODE_OMNI ams_AME_NODE_OMNI = new AppMain.AMS_AME_NODE_OMNI();
                        AppMain.fillAMENodeBegin( ams_AME_NODE_OMNI, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                        AppMain.readVector4( br, ams_AME_NODE_OMNI.translate );
                        AppMain.readQuaternion( br, ref ams_AME_NODE_OMNI.rotate );
                        ams_AME_NODE_OMNI.inheritance_rate = br.ReadSingle();
                        ams_AME_NODE_OMNI.life = br.ReadSingle();
                        ams_AME_NODE_OMNI.start_time = br.ReadSingle();
                        ams_AME_NODE_OMNI.offset = br.ReadSingle();
                        ams_AME_NODE_OMNI.offset_chaos = br.ReadSingle();
                        ams_AME_NODE_OMNI.speed = br.ReadSingle();
                        ams_AME_NODE_OMNI.speed_chaos = br.ReadSingle();
                        ams_AME_NODE_OMNI.max_count = br.ReadSingle();
                        ams_AME_NODE_OMNI.frequency = br.ReadSingle();
                        dictionary[num] = ams_AME_NODE_OMNI;
                        ams_AME_HEADER.node[i] = ams_AME_NODE_OMNI;
                        break;
                    }
                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_DIRECTIONAL:
                    {
                        AppMain.AMS_AME_NODE_DIRECTIONAL ams_AME_NODE_DIRECTIONAL = new AppMain.AMS_AME_NODE_DIRECTIONAL();
                        AppMain.fillAMENodeBegin( ams_AME_NODE_DIRECTIONAL, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                        AppMain.readVector4( br, ams_AME_NODE_DIRECTIONAL.translate );
                        AppMain.readQuaternion( br, ref ams_AME_NODE_DIRECTIONAL.rotate );
                        ams_AME_NODE_DIRECTIONAL.inheritance_rate = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.life = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.start_time = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.offset = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.offset_chaos = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.speed = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.speed_chaos = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.max_count = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.frequency = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.spread = br.ReadSingle();
                        ams_AME_NODE_DIRECTIONAL.spread_variation = br.ReadSingle();
                        dictionary[num] = ams_AME_NODE_DIRECTIONAL;
                        ams_AME_HEADER.node[i] = ams_AME_NODE_DIRECTIONAL;
                        break;
                    }
                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_SURFACE:
                    {
                        AppMain.AMS_AME_NODE_SURFACE ams_AME_NODE_SURFACE = new AppMain.AMS_AME_NODE_SURFACE();
                        AppMain.fillAMENodeBegin( ams_AME_NODE_SURFACE, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                        AppMain.readVector4( br, ams_AME_NODE_SURFACE.translate );
                        AppMain.readQuaternion( br, ref ams_AME_NODE_SURFACE.rotate );
                        ams_AME_NODE_SURFACE.inheritance_rate = br.ReadSingle();
                        ams_AME_NODE_SURFACE.life = br.ReadSingle();
                        ams_AME_NODE_SURFACE.start_time = br.ReadSingle();
                        ams_AME_NODE_SURFACE.offset = br.ReadSingle();
                        ams_AME_NODE_SURFACE.offset_chaos = br.ReadSingle();
                        ams_AME_NODE_SURFACE.speed = br.ReadSingle();
                        ams_AME_NODE_SURFACE.speed_chaos = br.ReadSingle();
                        ams_AME_NODE_SURFACE.max_count = br.ReadSingle();
                        ams_AME_NODE_SURFACE.frequency = br.ReadSingle();
                        ams_AME_NODE_SURFACE.width = br.ReadSingle();
                        ams_AME_NODE_SURFACE.width_variation = br.ReadSingle();
                        ams_AME_NODE_SURFACE.height = br.ReadSingle();
                        ams_AME_NODE_SURFACE.height_variation = br.ReadSingle();
                        dictionary[num] = ams_AME_NODE_SURFACE;
                        ams_AME_HEADER.node[i] = ams_AME_NODE_SURFACE;
                        break;
                    }
                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_CIRCLE:
                    {
                        AppMain.AMS_AME_NODE_CIRCLE ams_AME_NODE_CIRCLE = new AppMain.AMS_AME_NODE_CIRCLE();
                        AppMain.fillAMENodeBegin( ams_AME_NODE_CIRCLE, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                        AppMain.readVector4( br, ams_AME_NODE_CIRCLE.translate );
                        AppMain.readQuaternion( br, ref ams_AME_NODE_CIRCLE.rotate );
                        ams_AME_NODE_CIRCLE.inheritance_rate = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.life = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.start_time = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.offset = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.offset_chaos = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.speed = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.speed_chaos = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.max_count = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.frequency = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.spread = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.spread_variation = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.radius = br.ReadSingle();
                        ams_AME_NODE_CIRCLE.radius_variation = br.ReadSingle();
                        dictionary[num] = ams_AME_NODE_CIRCLE;
                        ams_AME_HEADER.node[i] = ams_AME_NODE_CIRCLE;
                        break;
                    }
                default:
                    switch ( ame_AME_NODE_TYPE2 )
                    {
                        case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_SIMPLE_SPRITE:
                        case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_SPRITE:
                            {
                                AppMain.AMS_AME_NODE_SPRITE ams_AME_NODE_SPRITE = new AppMain.AMS_AME_NODE_SPRITE();
                                AppMain.fillAMENodeBegin( ams_AME_NODE_SPRITE, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                AppMain.readVector4( br, ams_AME_NODE_SPRITE.translate );
                                AppMain.readQuaternion( br, ref ams_AME_NODE_SPRITE.rotate );
                                ams_AME_NODE_SPRITE.z_bias = br.ReadSingle();
                                ams_AME_NODE_SPRITE.inheritance_rate = br.ReadSingle();
                                ams_AME_NODE_SPRITE.life = br.ReadSingle();
                                ams_AME_NODE_SPRITE.start_time = br.ReadSingle();
                                ams_AME_NODE_SPRITE.size = br.ReadSingle();
                                ams_AME_NODE_SPRITE.size_chaos = br.ReadSingle();
                                ams_AME_NODE_SPRITE.scale_x_start = br.ReadSingle();
                                ams_AME_NODE_SPRITE.scale_x_end = br.ReadSingle();
                                ams_AME_NODE_SPRITE.scale_y_start = br.ReadSingle();
                                ams_AME_NODE_SPRITE.scale_y_end = br.ReadSingle();
                                ams_AME_NODE_SPRITE.twist_angle = br.ReadSingle();
                                ams_AME_NODE_SPRITE.twist_angle_chaos = br.ReadSingle();
                                ams_AME_NODE_SPRITE.twist_angle_speed = br.ReadSingle();
                                ams_AME_NODE_SPRITE.color_start.color = br.ReadUInt32();
                                ams_AME_NODE_SPRITE.color_end.color = br.ReadUInt32();
                                ams_AME_NODE_SPRITE.blend = br.ReadInt32();
                                ams_AME_NODE_SPRITE.texture_slot = br.ReadInt16();
                                ams_AME_NODE_SPRITE.texture_id = br.ReadInt16();
                                ams_AME_NODE_SPRITE.cropping_l = br.ReadSingle();
                                ams_AME_NODE_SPRITE.cropping_t = br.ReadSingle();
                                ams_AME_NODE_SPRITE.cropping_r = br.ReadSingle();
                                ams_AME_NODE_SPRITE.cropping_b = br.ReadSingle();
                                ams_AME_NODE_SPRITE.scroll_u = br.ReadSingle();
                                ams_AME_NODE_SPRITE.scroll_v = br.ReadSingle();
                                ams_AME_NODE_SPRITE.tex_anim = AppMain.readTexAnim( br );
                                dictionary[num] = ams_AME_NODE_SPRITE;
                                ams_AME_HEADER.node[i] = ams_AME_NODE_SPRITE;
                                break;
                            }
                        case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_LINE:
                            {
                                AppMain.AMS_AME_NODE_LINE ams_AME_NODE_LINE = new AppMain.AMS_AME_NODE_LINE();
                                AppMain.fillAMENodeBegin( ams_AME_NODE_LINE, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                AppMain.readVector4( br, ams_AME_NODE_LINE.translate );
                                AppMain.readQuaternion( br, ref ams_AME_NODE_LINE.rotate );
                                ams_AME_NODE_LINE.z_bias = br.ReadSingle();
                                ams_AME_NODE_LINE.inheritance_rate = br.ReadSingle();
                                ams_AME_NODE_LINE.life = br.ReadSingle();
                                ams_AME_NODE_LINE.start_time = br.ReadSingle();
                                ams_AME_NODE_LINE.length_start = br.ReadSingle();
                                ams_AME_NODE_LINE.length_end = br.ReadSingle();
                                ams_AME_NODE_LINE.inside_width_start = br.ReadSingle();
                                ams_AME_NODE_LINE.inside_width_end = br.ReadSingle();
                                ams_AME_NODE_LINE.outside_width_start = br.ReadSingle();
                                ams_AME_NODE_LINE.outside_width_end = br.ReadSingle();
                                ams_AME_NODE_LINE.inside_color_start.color = br.ReadUInt32();
                                ams_AME_NODE_LINE.inside_color_end.color = br.ReadUInt32();
                                ams_AME_NODE_LINE.outside_color_start.color = br.ReadUInt32();
                                ams_AME_NODE_LINE.outside_color_end.color = br.ReadUInt32();
                                ams_AME_NODE_LINE.blend = br.ReadInt32();
                                ams_AME_NODE_LINE.texture_slot = br.ReadInt16();
                                ams_AME_NODE_LINE.texture_id = br.ReadInt16();
                                ams_AME_NODE_LINE.cropping_l = br.ReadSingle();
                                ams_AME_NODE_LINE.cropping_t = br.ReadSingle();
                                ams_AME_NODE_LINE.cropping_r = br.ReadSingle();
                                ams_AME_NODE_LINE.cropping_b = br.ReadSingle();
                                ams_AME_NODE_LINE.scroll_u = br.ReadSingle();
                                ams_AME_NODE_LINE.scroll_v = br.ReadSingle();
                                ams_AME_NODE_LINE.tex_anim = AppMain.readTexAnim( br );
                                dictionary[num] = ams_AME_NODE_LINE;
                                ams_AME_HEADER.node[i] = ams_AME_NODE_LINE;
                                break;
                            }
                        case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_PLANE:
                            {
                                AppMain.AMS_AME_NODE_PLANE ams_AME_NODE_PLANE = new AppMain.AMS_AME_NODE_PLANE();
                                AppMain.fillAMENodeBegin( ams_AME_NODE_PLANE, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                AppMain.readVector4( br, ams_AME_NODE_PLANE.translate );
                                AppMain.readQuaternion( br, ref ams_AME_NODE_PLANE.rotate );
                                AppMain.readVector4( br, ams_AME_NODE_PLANE.rotate_axis );
                                ams_AME_NODE_PLANE.z_bias = br.ReadSingle();
                                ams_AME_NODE_PLANE.inheritance_rate = br.ReadSingle();
                                ams_AME_NODE_PLANE.life = br.ReadSingle();
                                ams_AME_NODE_PLANE.start_time = br.ReadSingle();
                                ams_AME_NODE_PLANE.size = br.ReadSingle();
                                ams_AME_NODE_PLANE.size_chaos = br.ReadSingle();
                                ams_AME_NODE_PLANE.scale_x_start = br.ReadSingle();
                                ams_AME_NODE_PLANE.scale_x_end = br.ReadSingle();
                                ams_AME_NODE_PLANE.scale_y_start = br.ReadSingle();
                                ams_AME_NODE_PLANE.scale_y_end = br.ReadSingle();
                                ams_AME_NODE_PLANE.color_start.color = br.ReadUInt32();
                                ams_AME_NODE_PLANE.color_end.color = br.ReadUInt32();
                                ams_AME_NODE_PLANE.blend = br.ReadInt32();
                                ams_AME_NODE_PLANE.texture_slot = br.ReadInt16();
                                ams_AME_NODE_PLANE.texture_id = br.ReadInt16();
                                ams_AME_NODE_PLANE.cropping_l = br.ReadSingle();
                                ams_AME_NODE_PLANE.cropping_t = br.ReadSingle();
                                ams_AME_NODE_PLANE.cropping_r = br.ReadSingle();
                                ams_AME_NODE_PLANE.cropping_b = br.ReadSingle();
                                ams_AME_NODE_PLANE.scroll_u = br.ReadSingle();
                                ams_AME_NODE_PLANE.scroll_v = br.ReadSingle();
                                ams_AME_NODE_PLANE.tex_anim = AppMain.readTexAnim( br );
                                dictionary[num] = ams_AME_NODE_PLANE;
                                ams_AME_HEADER.node[i] = ams_AME_NODE_PLANE;
                                break;
                            }
                        case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_MODEL:
                            {
                                AppMain.AMS_AME_NODE_MODEL ams_AME_NODE_MODEL = new AppMain.AMS_AME_NODE_MODEL();
                                AppMain.fillAMENodeBegin( ams_AME_NODE_MODEL, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                AppMain.readVector4( br, ams_AME_NODE_MODEL.translate );
                                AppMain.readQuaternion( br, ref ams_AME_NODE_MODEL.rotate );
                                AppMain.readVector4( br, ams_AME_NODE_MODEL.rotate_axis );
                                AppMain.readVector4( br, ams_AME_NODE_MODEL.scale_start );
                                AppMain.readVector4( br, ams_AME_NODE_MODEL.scale_end );
                                ams_AME_NODE_MODEL.z_bias = br.ReadSingle();
                                ams_AME_NODE_MODEL.inheritance_rate = br.ReadSingle();
                                ams_AME_NODE_MODEL.life = br.ReadSingle();
                                ams_AME_NODE_MODEL.start_time = br.ReadSingle();
                                ams_AME_NODE_MODEL.model_name = br.ReadChars( 8 );
                                ams_AME_NODE_MODEL.lod = br.ReadInt32();
                                ams_AME_NODE_MODEL.color_start.color = br.ReadUInt32();
                                ams_AME_NODE_MODEL.color_end.color = br.ReadUInt32();
                                ams_AME_NODE_MODEL.blend = br.ReadInt32();
                                ams_AME_NODE_MODEL.scroll_u = br.ReadSingle();
                                ams_AME_NODE_MODEL.scroll_v = br.ReadSingle();
                                dictionary[num] = ams_AME_NODE_MODEL;
                                ams_AME_HEADER.node[i] = ams_AME_NODE_MODEL;
                                break;
                            }
                        default:
                            switch ( ame_AME_NODE_TYPE2 )
                            {
                                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_GRAVITY:
                                    {
                                        AppMain.AMS_AME_NODE_GRAVITY ams_AME_NODE_GRAVITY = new AppMain.AMS_AME_NODE_GRAVITY();
                                        AppMain.fillAMENodeBegin( ams_AME_NODE_GRAVITY, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                        AppMain.readVector4( br, ams_AME_NODE_GRAVITY.direction );
                                        ams_AME_NODE_GRAVITY.magnitude = br.ReadSingle();
                                        dictionary[num] = ams_AME_NODE_GRAVITY;
                                        ams_AME_HEADER.node[i] = ams_AME_NODE_GRAVITY;
                                        break;
                                    }
                                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_UNIFORM:
                                    {
                                        AppMain.AMS_AME_NODE_UNIFORM ams_AME_NODE_UNIFORM = new AppMain.AMS_AME_NODE_UNIFORM();
                                        AppMain.fillAMENodeBegin( ams_AME_NODE_UNIFORM, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                        AppMain.readVector4( br, ams_AME_NODE_UNIFORM.direction );
                                        ams_AME_NODE_UNIFORM.magnitude = br.ReadSingle();
                                        dictionary[num] = ams_AME_NODE_UNIFORM;
                                        ams_AME_HEADER.node[i] = ams_AME_NODE_UNIFORM;
                                        break;
                                    }
                                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_RADIAL:
                                    {
                                        AppMain.AMS_AME_NODE_RADIAL ams_AME_NODE_RADIAL = new AppMain.AMS_AME_NODE_RADIAL();
                                        AppMain.fillAMENodeBegin( ams_AME_NODE_RADIAL, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                        AppMain.readVector4( br, ams_AME_NODE_RADIAL.position );
                                        ams_AME_NODE_RADIAL.magnitude = br.ReadSingle();
                                        ams_AME_NODE_RADIAL.attenuation = br.ReadSingle();
                                        dictionary[num] = ams_AME_NODE_RADIAL;
                                        ams_AME_HEADER.node[i] = ams_AME_NODE_RADIAL;
                                        break;
                                    }
                                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_VORTEX:
                                    {
                                        AppMain.AMS_AME_NODE_VORTEX ams_AME_NODE_VORTEX = new AppMain.AMS_AME_NODE_VORTEX();
                                        AppMain.fillAMENodeBegin( ams_AME_NODE_VORTEX, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                        AppMain.readVector4( br, ams_AME_NODE_VORTEX.position );
                                        AppMain.readVector4( br, ams_AME_NODE_VORTEX.axis );
                                        dictionary[num] = ams_AME_NODE_VORTEX;
                                        ams_AME_HEADER.node[i] = ams_AME_NODE_VORTEX;
                                        break;
                                    }
                                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_DRAG:
                                    {
                                        AppMain.AMS_AME_NODE_DRAG ams_AME_NODE_DRAG = new AppMain.AMS_AME_NODE_DRAG();
                                        AppMain.fillAMENodeBegin( ams_AME_NODE_DRAG, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                        AppMain.readVector4( br, ams_AME_NODE_DRAG.position );
                                        ams_AME_NODE_DRAG.magnitude = br.ReadSingle();
                                        dictionary[num] = ams_AME_NODE_DRAG;
                                        ams_AME_HEADER.node[i] = ams_AME_NODE_DRAG;
                                        break;
                                    }
                                case AppMain.AME_AME_NODE_TYPE.AME_AME_NODE_TYPE_NOISE:
                                    {
                                        AppMain.AMS_AME_NODE_NOISE ams_AME_NODE_NOISE = new AppMain.AMS_AME_NODE_NOISE();
                                        AppMain.fillAMENodeBegin( ams_AME_NODE_NOISE, id, ( short )ame_AME_NODE_TYPE, flag, name, child_offset, sibling_offset, parent_offset );
                                        AppMain.readVector4( br, ams_AME_NODE_NOISE.axis );
                                        ams_AME_NODE_NOISE.magnitude = br.ReadSingle();
                                        dictionary[num] = ams_AME_NODE_NOISE;
                                        ams_AME_HEADER.node[i] = ams_AME_NODE_NOISE;
                                        break;
                                    }
                            }
                            break;
                    }
                    break;
            }
        }
        foreach ( KeyValuePair<uint, AppMain.AMS_AME_NODE> keyValuePair in dictionary )
        {
            AppMain.AMS_AME_NODE value = keyValuePair.Value;
            if ( value.child_offset != 0 )
            {
                value.child = dictionary[( uint )value.child_offset];
            }
            if ( value.parent_offset != 0 )
            {
                value.parent = dictionary[( uint )value.parent_offset];
            }
            if ( value.sibling_offset != 0 )
            {
                value.sibling = dictionary[( uint )value.sibling_offset];
            }
        }
        return ams_AME_HEADER;
    }


    // Token: 0x06001154 RID: 4436 RVA: 0x0009854C File Offset: 0x0009674C
    private static int amAMEConv( byte[] pFile )
    {
        AppMain.mppAssertNotImpl();
        return 1;
    }

    // Token: 0x06001A4B RID: 6731 RVA: 0x000EB31B File Offset: 0x000E951B
    public static int AMD_AME_NODE_TYPE( AppMain.AMS_AME_NODE node )
    {
        return ( int )node.type;
    }

    // Token: 0x06001A4C RID: 6732 RVA: 0x000EB323 File Offset: 0x000E9523
    public static int AMD_AME_SUPER_CLASS_ID( AppMain.AMS_AME_NODE node )
    {
        return ( int )( ( ushort )node.type & 65280 );
    }

    // Token: 0x06001A4D RID: 6733 RVA: 0x000EB332 File Offset: 0x000E9532
    public static int AMD_AME_CLASS_ID( AppMain.AMS_AME_NODE node )
    {
        return ( int )( ( ushort )node.type & 255 );
    }

    // Token: 0x06001A4E RID: 6734 RVA: 0x000EB341 File Offset: 0x000E9541
    public static bool AMD_AME_IS_EMITTER( AppMain.AMS_AME_NODE node )
    {
        return AppMain.AMD_AME_SUPER_CLASS_ID( node ) == 256;
    }

    // Token: 0x06001A4F RID: 6735 RVA: 0x000EB350 File Offset: 0x000E9550
    public static bool AMD_AME_IS_PARTICLE( AppMain.AMS_AME_NODE node )
    {
        return AppMain.AMD_AME_SUPER_CLASS_ID( node ) == 512;
    }

    // Token: 0x06001A50 RID: 6736 RVA: 0x000EB35F File Offset: 0x000E955F
    public static bool AMD_AME_IS_FIELD( AppMain.AMS_AME_NODE node )
    {
        return AppMain.AMD_AME_SUPER_CLASS_ID( node ) == 768;
    }
}
