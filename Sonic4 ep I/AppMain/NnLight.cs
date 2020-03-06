using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;

public partial class AppMain
{
    // Token: 0x02000174 RID: 372
    public class NNS_LIGHT_STANDARD_GL
    {
        // Token: 0x04004E80 RID: 20096
        public uint User;

        // Token: 0x04004E81 RID: 20097
        public AppMain.NNS_RGBA Ambient;

        // Token: 0x04004E82 RID: 20098
        public AppMain.NNS_RGBA Diffuse;

        // Token: 0x04004E83 RID: 20099
        public AppMain.NNS_RGBA Specular;

        // Token: 0x04004E84 RID: 20100
        public readonly AppMain.NNS_VECTOR4D Position = new AppMain.NNS_VECTOR4D();

        // Token: 0x04004E85 RID: 20101
        public readonly AppMain.NNS_VECTOR SpotDirection = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004E86 RID: 20102
        public float SpotExponent;

        // Token: 0x04004E87 RID: 20103
        public float SpotCutoff;

        // Token: 0x04004E88 RID: 20104
        public float ConstantAttenuation;

        // Token: 0x04004E89 RID: 20105
        public float LinearAttenuation;

        // Token: 0x04004E8A RID: 20106
        public float QuadraticAttenuation;
    }

    // Token: 0x02000175 RID: 373
    public struct NNS_LIGHT_PARALLEL
    {
        // Token: 0x06002134 RID: 8500 RVA: 0x00140E88 File Offset: 0x0013F088
        public NNS_LIGHT_PARALLEL( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data )
        {
            this.data_ = data;
        }

        // Token: 0x17000073 RID: 115
        // (get) Token: 0x06002135 RID: 8501 RVA: 0x00140E91 File Offset: 0x0013F091
        // (set) Token: 0x06002136 RID: 8502 RVA: 0x00140E9E File Offset: 0x0013F09E
        public uint User
        {
            get
            {
                return this.data_.User;
            }
            set
            {
                this.data_.User = value;
            }
        }

        // Token: 0x17000074 RID: 116
        // (get) Token: 0x06002137 RID: 8503 RVA: 0x00140EAC File Offset: 0x0013F0AC
        // (set) Token: 0x06002138 RID: 8504 RVA: 0x00140EB9 File Offset: 0x0013F0B9
        public AppMain.NNS_RGBA Color
        {
            get
            {
                return this.data_.Color;
            }
            set
            {
                this.data_.Color = value;
            }
        }

        // Token: 0x17000075 RID: 117
        // (get) Token: 0x06002139 RID: 8505 RVA: 0x00140EC7 File Offset: 0x0013F0C7
        // (set) Token: 0x0600213A RID: 8506 RVA: 0x00140ED4 File Offset: 0x0013F0D4
        public float Intensity
        {
            get
            {
                return this.data_.Intensity;
            }
            set
            {
                this.data_.Intensity = value;
            }
        }

        // Token: 0x17000076 RID: 118
        // (get) Token: 0x0600213B RID: 8507 RVA: 0x00140EE2 File Offset: 0x0013F0E2
        // (set) Token: 0x0600213C RID: 8508 RVA: 0x00140EEF File Offset: 0x0013F0EF
        public AppMain.NNS_VECTOR Direction
        {
            get
            {
                return this.data_.Position;
            }
            set
            {
                this.data_.Position.Assign( value );
            }
        }

        // Token: 0x04004E8B RID: 20107
        private AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data_;
    }

    // Token: 0x02000176 RID: 374
    public struct NNS_LIGHT_POINT
    {
        // Token: 0x0600213D RID: 8509 RVA: 0x00140F03 File Offset: 0x0013F103
        public NNS_LIGHT_POINT( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data )
        {
            this.data_ = data;
        }

        // Token: 0x17000077 RID: 119
        // (get) Token: 0x0600213E RID: 8510 RVA: 0x00140F0C File Offset: 0x0013F10C
        // (set) Token: 0x0600213F RID: 8511 RVA: 0x00140F19 File Offset: 0x0013F119
        public uint User
        {
            get
            {
                return this.data_.User;
            }
            set
            {
                this.data_.User = value;
            }
        }

        // Token: 0x17000078 RID: 120
        // (get) Token: 0x06002140 RID: 8512 RVA: 0x00140F27 File Offset: 0x0013F127
        // (set) Token: 0x06002141 RID: 8513 RVA: 0x00140F34 File Offset: 0x0013F134
        public AppMain.NNS_RGBA Color
        {
            get
            {
                return this.data_.Color;
            }
            set
            {
                this.data_.Color = value;
            }
        }

        // Token: 0x17000079 RID: 121
        // (get) Token: 0x06002142 RID: 8514 RVA: 0x00140F42 File Offset: 0x0013F142
        // (set) Token: 0x06002143 RID: 8515 RVA: 0x00140F4F File Offset: 0x0013F14F
        public float Intensity
        {
            get
            {
                return this.data_.Intensity;
            }
            set
            {
                this.data_.Intensity = value;
            }
        }

        // Token: 0x1700007A RID: 122
        // (get) Token: 0x06002144 RID: 8516 RVA: 0x00140F5D File Offset: 0x0013F15D
        // (set) Token: 0x06002145 RID: 8517 RVA: 0x00140F6A File Offset: 0x0013F16A
        public AppMain.NNS_VECTOR Position
        {
            get
            {
                return this.data_.Position;
            }
            set
            {
                this.data_.Position.Assign( value );
            }
        }

        // Token: 0x1700007B RID: 123
        // (get) Token: 0x06002146 RID: 8518 RVA: 0x00140F7E File Offset: 0x0013F17E
        // (set) Token: 0x06002147 RID: 8519 RVA: 0x00140F90 File Offset: 0x0013F190
        public float FallOffStart
        {
            get
            {
                return this.data_.Target.x;
            }
            set
            {
                this.data_.Target.x = value;
            }
        }

        // Token: 0x1700007C RID: 124
        // (get) Token: 0x06002148 RID: 8520 RVA: 0x00140FA3 File Offset: 0x0013F1A3
        // (set) Token: 0x06002149 RID: 8521 RVA: 0x00140FB5 File Offset: 0x0013F1B5
        public float FallOffEnd
        {
            get
            {
                return this.data_.Target.y;
            }
            set
            {
                this.data_.Target.y = value;
            }
        }

        // Token: 0x04004E8C RID: 20108
        private AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data_;
    }

    // Token: 0x02000177 RID: 375
    public struct NNS_LIGHT_TARGET_SPOT
    {
        // Token: 0x0600214A RID: 8522 RVA: 0x00140FC8 File Offset: 0x0013F1C8
        public NNS_LIGHT_TARGET_SPOT( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data )
        {
            this.data_ = data;
        }

        // Token: 0x1700007D RID: 125
        // (get) Token: 0x0600214B RID: 8523 RVA: 0x00140FD1 File Offset: 0x0013F1D1
        // (set) Token: 0x0600214C RID: 8524 RVA: 0x00140FDE File Offset: 0x0013F1DE
        public uint User
        {
            get
            {
                return this.data_.User;
            }
            set
            {
                this.data_.User = value;
            }
        }

        // Token: 0x1700007E RID: 126
        // (get) Token: 0x0600214D RID: 8525 RVA: 0x00140FEC File Offset: 0x0013F1EC
        // (set) Token: 0x0600214E RID: 8526 RVA: 0x00140FF9 File Offset: 0x0013F1F9
        public AppMain.NNS_RGBA Color
        {
            get
            {
                return this.data_.Color;
            }
            set
            {
                this.data_.Color = value;
            }
        }

        // Token: 0x1700007F RID: 127
        // (get) Token: 0x0600214F RID: 8527 RVA: 0x00141007 File Offset: 0x0013F207
        // (set) Token: 0x06002150 RID: 8528 RVA: 0x00141014 File Offset: 0x0013F214
        public float Intensity
        {
            get
            {
                return this.data_.Intensity;
            }
            set
            {
                this.data_.Intensity = value;
            }
        }

        // Token: 0x17000080 RID: 128
        // (get) Token: 0x06002151 RID: 8529 RVA: 0x00141022 File Offset: 0x0013F222
        // (set) Token: 0x06002152 RID: 8530 RVA: 0x0014102F File Offset: 0x0013F22F
        public AppMain.NNS_VECTOR Position
        {
            get
            {
                return this.data_.Position;
            }
            set
            {
                this.data_.Position.Assign( value );
            }
        }

        // Token: 0x17000081 RID: 129
        // (get) Token: 0x06002153 RID: 8531 RVA: 0x00141043 File Offset: 0x0013F243
        // (set) Token: 0x06002154 RID: 8532 RVA: 0x00141050 File Offset: 0x0013F250
        public AppMain.NNS_VECTOR Target
        {
            get
            {
                return this.data_.Target;
            }
            set
            {
                this.data_.Target.Assign( value );
            }
        }

        // Token: 0x17000082 RID: 130
        // (get) Token: 0x06002155 RID: 8533 RVA: 0x00141064 File Offset: 0x0013F264
        // (set) Token: 0x06002156 RID: 8534 RVA: 0x00141076 File Offset: 0x0013F276
        public int InnerAngle
        {
            get
            {
                return MppBitConverter.SingleToInt32( this.data_.InnerRange );
            }
            set
            {
                this.data_.InnerRange = MppBitConverter.Int32ToSingle( value );
            }
        }

        // Token: 0x17000083 RID: 131
        // (get) Token: 0x06002157 RID: 8535 RVA: 0x00141089 File Offset: 0x0013F289
        // (set) Token: 0x06002158 RID: 8536 RVA: 0x0014109B File Offset: 0x0013F29B
        public int OuterAngle
        {
            get
            {
                return MppBitConverter.SingleToInt32( this.data_.OuterRange );
            }
            set
            {
                this.data_.OuterRange = MppBitConverter.Int32ToSingle( value );
            }
        }

        // Token: 0x17000084 RID: 132
        // (get) Token: 0x06002159 RID: 8537 RVA: 0x001410AE File Offset: 0x0013F2AE
        // (set) Token: 0x0600215A RID: 8538 RVA: 0x001410BB File Offset: 0x0013F2BB
        public float FallOffStart
        {
            get
            {
                return this.data_.FallOffStart;
            }
            set
            {
                this.data_.FallOffStart = value;
            }
        }

        // Token: 0x17000085 RID: 133
        // (get) Token: 0x0600215B RID: 8539 RVA: 0x001410C9 File Offset: 0x0013F2C9
        // (set) Token: 0x0600215C RID: 8540 RVA: 0x001410D6 File Offset: 0x0013F2D6
        public float FallOffEnd
        {
            get
            {
                return this.data_.FallOffEnd;
            }
            set
            {
                this.data_.FallOffEnd = value;
            }
        }

        // Token: 0x04004E8D RID: 20109
        private AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data_;
    }

    // Token: 0x02000178 RID: 376
    public struct NNS_LIGHT_ROTATION_SPOT
    {
        // Token: 0x0600215D RID: 8541 RVA: 0x001410E4 File Offset: 0x0013F2E4
        public NNS_LIGHT_ROTATION_SPOT( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data )
        {
            this.data_ = data;
        }

        // Token: 0x17000086 RID: 134
        // (get) Token: 0x0600215E RID: 8542 RVA: 0x001410ED File Offset: 0x0013F2ED
        // (set) Token: 0x0600215F RID: 8543 RVA: 0x001410FA File Offset: 0x0013F2FA
        public uint User
        {
            get
            {
                return this.data_.User;
            }
            set
            {
                this.data_.User = value;
            }
        }

        // Token: 0x17000087 RID: 135
        // (get) Token: 0x06002160 RID: 8544 RVA: 0x00141108 File Offset: 0x0013F308
        // (set) Token: 0x06002161 RID: 8545 RVA: 0x00141115 File Offset: 0x0013F315
        public AppMain.NNS_RGBA Color
        {
            get
            {
                return this.data_.Color;
            }
            set
            {
                this.data_.Color = value;
            }
        }

        // Token: 0x17000088 RID: 136
        // (get) Token: 0x06002162 RID: 8546 RVA: 0x00141123 File Offset: 0x0013F323
        // (set) Token: 0x06002163 RID: 8547 RVA: 0x00141130 File Offset: 0x0013F330
        public float Intensity
        {
            get
            {
                return this.data_.Intensity;
            }
            set
            {
                this.data_.Intensity = value;
            }
        }

        // Token: 0x17000089 RID: 137
        // (get) Token: 0x06002164 RID: 8548 RVA: 0x0014113E File Offset: 0x0013F33E
        // (set) Token: 0x06002165 RID: 8549 RVA: 0x0014114B File Offset: 0x0013F34B
        public AppMain.NNS_VECTOR Position
        {
            get
            {
                return this.data_.Position;
            }
            set
            {
                this.data_.Position.Assign( value );
            }
        }

        // Token: 0x1700008A RID: 138
        // (get) Token: 0x06002166 RID: 8550 RVA: 0x0014115F File Offset: 0x0013F35F
        // (set) Token: 0x06002167 RID: 8551 RVA: 0x00141176 File Offset: 0x0013F376
        public int RotType
        {
            get
            {
                return MppBitConverter.SingleToInt32( this.data_.Target.x );
            }
            set
            {
                this.data_.Target.x = MppBitConverter.Int32ToSingle( value );
            }
        }

        // Token: 0x1700008B RID: 139
        // (get) Token: 0x06002168 RID: 8552 RVA: 0x00141190 File Offset: 0x0013F390
        // (set) Token: 0x06002169 RID: 8553 RVA: 0x001411F8 File Offset: 0x0013F3F8
        public AppMain.NNS_ROTATE_A32 Rotation
        {
            get
            {
                return new AppMain.NNS_ROTATE_A32
                {
                    x = MppBitConverter.SingleToInt32( this.data_.Target.y ),
                    y = MppBitConverter.SingleToInt32( this.data_.Target.z ),
                    z = MppBitConverter.SingleToInt32( this.data_.InnerRange )
                };
            }
            set
            {
                this.data_.Target.y = MppBitConverter.Int32ToSingle( value.x );
                this.data_.Target.z = MppBitConverter.Int32ToSingle( value.y );
                this.data_.InnerRange = MppBitConverter.Int32ToSingle( value.z );
            }
        }

        // Token: 0x1700008C RID: 140
        // (get) Token: 0x0600216A RID: 8554 RVA: 0x00141254 File Offset: 0x0013F454
        // (set) Token: 0x0600216B RID: 8555 RVA: 0x00141266 File Offset: 0x0013F466
        public int InnerAngle
        {
            get
            {
                return MppBitConverter.SingleToInt32( this.data_.OuterRange );
            }
            set
            {
                this.data_.OuterRange = MppBitConverter.Int32ToSingle( value );
            }
        }

        // Token: 0x1700008D RID: 141
        // (get) Token: 0x0600216C RID: 8556 RVA: 0x00141279 File Offset: 0x0013F479
        // (set) Token: 0x0600216D RID: 8557 RVA: 0x0014128B File Offset: 0x0013F48B
        public int OuterAngle
        {
            get
            {
                return MppBitConverter.SingleToInt32( this.data_.FallOffStart );
            }
            set
            {
                this.data_.FallOffStart = MppBitConverter.Int32ToSingle( value );
            }
        }

        // Token: 0x1700008E RID: 142
        // (get) Token: 0x0600216E RID: 8558 RVA: 0x0014129E File Offset: 0x0013F49E
        // (set) Token: 0x0600216F RID: 8559 RVA: 0x001412AB File Offset: 0x0013F4AB
        public float FallOffStart
        {
            get
            {
                return this.data_.FallOffEnd;
            }
            set
            {
                this.data_.FallOffEnd = value;
            }
        }

        // Token: 0x1700008F RID: 143
        // (get) Token: 0x06002170 RID: 8560 RVA: 0x001412B9 File Offset: 0x0013F4B9
        // (set) Token: 0x06002171 RID: 8561 RVA: 0x001412C6 File Offset: 0x0013F4C6
        public float FallOffEnd
        {
            get
            {
                return this.data_.dummy;
            }
            set
            {
                this.data_.dummy = value;
            }
        }

        // Token: 0x04004E8E RID: 20110
        private AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data_;
    }

    // Token: 0x02000179 RID: 377
    public class NNS_LIGHT_TARGET_DIRECTIONAL
    {
        // Token: 0x06002172 RID: 8562 RVA: 0x001412D4 File Offset: 0x0013F4D4
        public static explicit operator AppMain.NNS_LIGHT_PARALLEL( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light )
        {
            return new AppMain.NNS_LIGHT_PARALLEL( light );
        }

        // Token: 0x06002173 RID: 8563 RVA: 0x001412DC File Offset: 0x0013F4DC
        public static explicit operator AppMain.NNS_LIGHT_POINT( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light )
        {
            return new AppMain.NNS_LIGHT_POINT( light );
        }

        // Token: 0x06002174 RID: 8564 RVA: 0x001412E4 File Offset: 0x0013F4E4
        public static explicit operator AppMain.NNS_LIGHT_TARGET_SPOT( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light )
        {
            return new AppMain.NNS_LIGHT_TARGET_SPOT( light );
        }

        // Token: 0x06002175 RID: 8565 RVA: 0x001412EC File Offset: 0x0013F4EC
        public static explicit operator AppMain.NNS_LIGHT_ROTATION_SPOT( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light )
        {
            return new AppMain.NNS_LIGHT_ROTATION_SPOT( light );
        }

        // Token: 0x04004E8F RID: 20111
        public uint User;

        // Token: 0x04004E90 RID: 20112
        public AppMain.NNS_RGBA Color;

        // Token: 0x04004E91 RID: 20113
        public float Intensity;

        // Token: 0x04004E92 RID: 20114
        public readonly AppMain.NNS_VECTOR Position = new AppMain.NNS_VECTOR();

        // Token: 0x04004E93 RID: 20115
        public readonly AppMain.NNS_VECTOR Target = new AppMain.NNS_VECTOR();

        // Token: 0x04004E94 RID: 20116
        public float InnerRange;

        // Token: 0x04004E95 RID: 20117
        public float OuterRange;

        // Token: 0x04004E96 RID: 20118
        public float FallOffStart;

        // Token: 0x04004E97 RID: 20119
        public float FallOffEnd;

        // Token: 0x04004E98 RID: 20120
        public float dummy;
    }

    // Token: 0x0200017A RID: 378
    public struct NNS_LIGHT_ROTATION_DIRECTIONAL
    {
        // Token: 0x06002177 RID: 8567 RVA: 0x00141312 File Offset: 0x0013F512
        public NNS_LIGHT_ROTATION_DIRECTIONAL( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data )
        {
            this.data_ = data;
        }

        // Token: 0x17000090 RID: 144
        // (get) Token: 0x06002178 RID: 8568 RVA: 0x0014131B File Offset: 0x0013F51B
        // (set) Token: 0x06002179 RID: 8569 RVA: 0x00141328 File Offset: 0x0013F528
        public uint User
        {
            get
            {
                return this.data_.User;
            }
            set
            {
                this.data_.User = value;
            }
        }

        // Token: 0x17000091 RID: 145
        // (get) Token: 0x0600217A RID: 8570 RVA: 0x00141336 File Offset: 0x0013F536
        // (set) Token: 0x0600217B RID: 8571 RVA: 0x00141343 File Offset: 0x0013F543
        public AppMain.NNS_RGBA Color
        {
            get
            {
                return this.data_.Color;
            }
            set
            {
                this.data_.Color = value;
            }
        }

        // Token: 0x17000092 RID: 146
        // (get) Token: 0x0600217C RID: 8572 RVA: 0x00141351 File Offset: 0x0013F551
        // (set) Token: 0x0600217D RID: 8573 RVA: 0x0014135E File Offset: 0x0013F55E
        public float Intensity
        {
            get
            {
                return this.data_.Intensity;
            }
            set
            {
                this.data_.Intensity = value;
            }
        }

        // Token: 0x17000093 RID: 147
        // (get) Token: 0x0600217E RID: 8574 RVA: 0x0014136C File Offset: 0x0013F56C
        // (set) Token: 0x0600217F RID: 8575 RVA: 0x00141379 File Offset: 0x0013F579
        public AppMain.NNS_VECTOR Position
        {
            get
            {
                return this.data_.Position;
            }
            set
            {
                this.data_.Position.Assign( value );
            }
        }

        // Token: 0x17000094 RID: 148
        // (get) Token: 0x06002180 RID: 8576 RVA: 0x0014138D File Offset: 0x0013F58D
        // (set) Token: 0x06002181 RID: 8577 RVA: 0x001413A4 File Offset: 0x0013F5A4
        public int RotType
        {
            get
            {
                return MppBitConverter.SingleToInt32( this.data_.Target.x );
            }
            set
            {
                this.data_.Target.x = MppBitConverter.Int32ToSingle( value );
            }
        }

        // Token: 0x17000095 RID: 149
        // (get) Token: 0x06002182 RID: 8578 RVA: 0x001413BC File Offset: 0x0013F5BC
        // (set) Token: 0x06002183 RID: 8579 RVA: 0x00141424 File Offset: 0x0013F624
        public AppMain.NNS_ROTATE_A32 Rotation
        {
            get
            {
                return new AppMain.NNS_ROTATE_A32
                {
                    x = MppBitConverter.SingleToInt32( this.data_.Target.y ),
                    y = MppBitConverter.SingleToInt32( this.data_.Target.z ),
                    z = MppBitConverter.SingleToInt32( this.data_.InnerRange )
                };
            }
            set
            {
                this.data_.Target.y = MppBitConverter.Int32ToSingle( value.x );
                this.data_.Target.z = MppBitConverter.Int32ToSingle( value.y );
                this.data_.InnerRange = MppBitConverter.Int32ToSingle( value.z );
            }
        }

        // Token: 0x17000096 RID: 150
        // (get) Token: 0x06002184 RID: 8580 RVA: 0x00141480 File Offset: 0x0013F680
        // (set) Token: 0x06002185 RID: 8581 RVA: 0x0014148D File Offset: 0x0013F68D
        public float InnerRange
        {
            get
            {
                return this.data_.OuterRange;
            }
            set
            {
                this.data_.OuterRange = value;
            }
        }

        // Token: 0x17000097 RID: 151
        // (get) Token: 0x06002186 RID: 8582 RVA: 0x0014149B File Offset: 0x0013F69B
        // (set) Token: 0x06002187 RID: 8583 RVA: 0x001414A8 File Offset: 0x0013F6A8
        public float OuterRange
        {
            get
            {
                return this.data_.FallOffStart;
            }
            set
            {
                this.data_.FallOffStart = value;
            }
        }

        // Token: 0x17000098 RID: 152
        // (get) Token: 0x06002188 RID: 8584 RVA: 0x001414B6 File Offset: 0x0013F6B6
        // (set) Token: 0x06002189 RID: 8585 RVA: 0x001414C3 File Offset: 0x0013F6C3
        public float FallOffStart
        {
            get
            {
                return this.data_.FallOffEnd;
            }
            set
            {
                this.data_.FallOffEnd = value;
            }
        }

        // Token: 0x17000099 RID: 153
        // (get) Token: 0x0600218A RID: 8586 RVA: 0x001414D1 File Offset: 0x0013F6D1
        // (set) Token: 0x0600218B RID: 8587 RVA: 0x001414DE File Offset: 0x0013F6DE
        public float FallOffEnd
        {
            get
            {
                return this.data_.dummy;
            }
            set
            {
                this.data_.dummy = value;
            }
        }

        // Token: 0x04004E99 RID: 20121
        private AppMain.NNS_LIGHT_TARGET_DIRECTIONAL data_;
    }

    // Token: 0x0200017B RID: 379
    public class NNS_LIGHTPTR
    {
        // Token: 0x0600218C RID: 8588 RVA: 0x001414EC File Offset: 0x0013F6EC
        public NNS_LIGHTPTR()
        {
        }

        // Token: 0x0600218D RID: 8589 RVA: 0x001414F4 File Offset: 0x0013F6F4
        public NNS_LIGHTPTR( AppMain.NNS_LIGHTPTR lightPtr )
        {
            this.fType = lightPtr.fType;
            this.pLight = lightPtr.pLight;
        }

        // Token: 0x0600218E RID: 8590 RVA: 0x00141514 File Offset: 0x0013F714
        public AppMain.NNS_LIGHTPTR Assign( AppMain.NNS_LIGHTPTR lightPtr )
        {
            this.fType = lightPtr.fType;
            this.pLight = lightPtr.pLight;
            return this;
        }

        // Token: 0x04004E9A RID: 20122
        public uint fType;

        // Token: 0x04004E9B RID: 20123
        public object pLight;
    }

    // Token: 0x020001E4 RID: 484
    private class NNS_GL_LIGHT_DATA
    {
        // Token: 0x040054B0 RID: 21680
        public int bEnable;

        // Token: 0x040054B1 RID: 21681
        public uint fType;

        // Token: 0x040054B2 RID: 21682
        public float Intensity;

        // Token: 0x040054B3 RID: 21683
        public AppMain.NNS_RGBA Ambient = default(AppMain.NNS_RGBA);

        // Token: 0x040054B4 RID: 21684
        public AppMain.NNS_RGBA Diffuse = default(AppMain.NNS_RGBA);

        // Token: 0x040054B5 RID: 21685
        public AppMain.NNS_RGBA Specular = default(AppMain.NNS_RGBA);

        // Token: 0x040054B6 RID: 21686
        public AppMain.NNS_VECTOR Direction = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040054B7 RID: 21687
        public AppMain.NNS_VECTOR4D Position = new AppMain.NNS_VECTOR4D();

        // Token: 0x040054B8 RID: 21688
        public AppMain.NNS_VECTOR Target = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040054B9 RID: 21689
        public int RotType;

        // Token: 0x040054BA RID: 21690
        public AppMain.NNS_ROTATE_A32 Rotation;

        // Token: 0x040054BB RID: 21691
        public int InnerAngle;

        // Token: 0x040054BC RID: 21692
        public int OuterAngle;

        // Token: 0x040054BD RID: 21693
        public float InnerRange;

        // Token: 0x040054BE RID: 21694
        public float OuterRange;

        // Token: 0x040054BF RID: 21695
        public float FallOffStart;

        // Token: 0x040054C0 RID: 21696
        public float FallOffEnd;

        // Token: 0x040054C1 RID: 21697
        public float SpotExponent;

        // Token: 0x040054C2 RID: 21698
        public float SpotCutoff;

        // Token: 0x040054C3 RID: 21699
        public float ConstantAttenuation;

        // Token: 0x040054C4 RID: 21700
        public float LinearAttenuation;

        // Token: 0x040054C5 RID: 21701
        public float QuadraticAttenuation;
    }

    // Token: 0x020001E5 RID: 485
    private class NNS_GL_LIGHT
    {
        // Token: 0x040054C6 RID: 21702
        public AppMain.NNS_RGBA AmbientColor = default(AppMain.NNS_RGBA);

        // Token: 0x040054C7 RID: 21703
        public AppMain.NNS_GL_LIGHT_DATA[] LightData = AppMain.New<AppMain.NNS_GL_LIGHT_DATA>(AppMain.NNE_LIGHT_MAX);
    }

    // Token: 0x020001E6 RID: 486
    private class nnlight
    {
        // Token: 0x040054C8 RID: 21704
        public static AppMain.NNS_MATRIX nngLightMtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x040054C9 RID: 21705
        public static AppMain.NNS_GL_LIGHT nngLight = new AppMain.NNS_GL_LIGHT();

        // Token: 0x040054CA RID: 21706
        public static int nngNumParallelLight;

        // Token: 0x040054CB RID: 21707
        public static int nngNumPointLight;

        // Token: 0x040054CC RID: 21708
        public static int nngNumSpotLight;

        // Token: 0x040054CD RID: 21709
        public static float[] nngPointLightFallOffEnd = new float[4];

        // Token: 0x040054CE RID: 21710
        public static float[] nngPointLightFallOffScale = new float[4];

        // Token: 0x040054CF RID: 21711
        public static float[] nngSpotLightFallOffEnd = new float[4];

        // Token: 0x040054D0 RID: 21712
        public static float[] nngSpotLightFallOffScale = new float[4];

        // Token: 0x040054D1 RID: 21713
        public static float[] nngSpotLightAngleScale = new float[4];
    }
}
