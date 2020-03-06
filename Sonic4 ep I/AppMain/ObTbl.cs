using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x020002FC RID: 764
    public enum DRE_TBL_WORK_TYPE
    {
        // Token: 0x04005D10 RID: 23824
        OBD_TBLWORK_TYPE_ACT,
        // Token: 0x04005D11 RID: 23825
        OBD_TBLWORK_TYPE_MOVE,
        // Token: 0x04005D12 RID: 23826
        OBD_TBLWORK_TYPE_SCALE,
        // Token: 0x04005D13 RID: 23827
        OBD_TBLWORK_TYPE_DIR,
        // Token: 0x04005D14 RID: 23828
        OBD_TBLWORK_TYPE_MAX
    }

    // Token: 0x020002FD RID: 765
    public class OBS_ACT_TBL
    {
        // Token: 0x06002520 RID: 9504 RVA: 0x0014BD14 File Offset: 0x00149F14
        public OBS_ACT_TBL()
        {
        }

        // Token: 0x06002521 RID: 9505 RVA: 0x0014BD1C File Offset: 0x00149F1C
        public OBS_ACT_TBL( AppMain.OBS_ACT_TBL obsTbl )
        {
            this.act_id = obsTbl.act_id;
            this.time = obsTbl.time;
            this.flag = obsTbl.flag;
        }

        // Token: 0x06002522 RID: 9506 RVA: 0x0014BD48 File Offset: 0x00149F48
        public AppMain.OBS_ACT_TBL Assign( AppMain.OBS_ACT_TBL obsTbl )
        {
            this.act_id = obsTbl.act_id;
            this.time = obsTbl.time;
            this.flag = obsTbl.flag;
            return this;
        }

        // Token: 0x04005D15 RID: 23829
        public ushort act_id;

        // Token: 0x04005D16 RID: 23830
        public byte time;

        // Token: 0x04005D17 RID: 23831
        public byte flag;
    }

    // Token: 0x020002FE RID: 766
    public class OBS_MOVE_TBL
    {
        // Token: 0x06002523 RID: 9507 RVA: 0x0014BD6F File Offset: 0x00149F6F
        public OBS_MOVE_TBL()
        {
        }

        // Token: 0x06002524 RID: 9508 RVA: 0x0014BD90 File Offset: 0x00149F90
        public OBS_MOVE_TBL( AppMain.OBS_MOVE_TBL obsTbl )
        {
            this.spd.Assign( obsTbl.spd );
            this.spd_add.Assign( obsTbl.spd_add );
            this.time = obsTbl.time;
            this.flag = obsTbl.flag;
        }

        // Token: 0x06002525 RID: 9509 RVA: 0x0014BDF8 File Offset: 0x00149FF8
        public AppMain.OBS_MOVE_TBL Assign( AppMain.OBS_MOVE_TBL obsTbl )
        {
            if ( this != obsTbl )
            {
                this.spd.Assign( obsTbl.spd );
                this.spd_add.Assign( obsTbl.spd_add );
                this.time = obsTbl.time;
                this.flag = obsTbl.flag;
            }
            return this;
        }

        // Token: 0x04005D18 RID: 23832
        public AppMain.VecFx32 spd = default(AppMain.VecFx32);

        // Token: 0x04005D19 RID: 23833
        public AppMain.VecFx32 spd_add = default(AppMain.VecFx32);

        // Token: 0x04005D1A RID: 23834
        public byte time;

        // Token: 0x04005D1B RID: 23835
        public byte flag;
    }

    // Token: 0x020002FF RID: 767
    public class OBS_SCALE_TBL
    {
        // Token: 0x06002526 RID: 9510 RVA: 0x0014BE44 File Offset: 0x0014A044
        public OBS_SCALE_TBL()
        {
        }

        // Token: 0x06002527 RID: 9511 RVA: 0x0014BE58 File Offset: 0x0014A058
        public OBS_SCALE_TBL( AppMain.OBS_SCALE_TBL obsTbl )
        {
            this.scale.Assign( obsTbl.scale );
            this.time = obsTbl.time;
            this.flag = obsTbl.flag;
        }

        // Token: 0x06002528 RID: 9512 RVA: 0x0014BE95 File Offset: 0x0014A095
        public AppMain.OBS_SCALE_TBL Assign( AppMain.OBS_SCALE_TBL obsTbl )
        {
            if ( this != obsTbl )
            {
                this.scale.Assign( obsTbl.scale );
                this.time = obsTbl.time;
                this.flag = obsTbl.flag;
            }
            return this;
        }

        // Token: 0x04005D1C RID: 23836
        public AppMain.VecFx32 scale = default(AppMain.VecFx32);

        // Token: 0x04005D1D RID: 23837
        public byte time;

        // Token: 0x04005D1E RID: 23838
        public byte flag;
    }

    // Token: 0x02000300 RID: 768
    public class OBS_DIR_TBL
    {
        // Token: 0x06002529 RID: 9513 RVA: 0x0014BEC5 File Offset: 0x0014A0C5
        public OBS_DIR_TBL()
        {
        }

        // Token: 0x0600252A RID: 9514 RVA: 0x0014BED9 File Offset: 0x0014A0D9
        public OBS_DIR_TBL( AppMain.OBS_DIR_TBL obsTbl )
        {
            this.dir.Assign( obsTbl.dir );
            this.time = obsTbl.time;
            this.flag = obsTbl.flag;
        }

        // Token: 0x0600252B RID: 9515 RVA: 0x0014BF16 File Offset: 0x0014A116
        public AppMain.OBS_DIR_TBL Assign( AppMain.OBS_DIR_TBL obsTbl )
        {
            this.dir.Assign( obsTbl.dir );
            this.time = obsTbl.time;
            this.flag = obsTbl.flag;
            return this;
        }

        // Token: 0x04005D1F RID: 23839
        public AppMain.VecU16 dir = default(AppMain.VecU16);

        // Token: 0x04005D20 RID: 23840
        public byte time;

        // Token: 0x04005D21 RID: 23841
        public byte flag;
    }

    // Token: 0x02000301 RID: 769
    public class OBS_TBL_WORK
    {
        // Token: 0x0600252C RID: 9516 RVA: 0x0014BF44 File Offset: 0x0014A144
        public OBS_TBL_WORK()
        {
        }

        // Token: 0x0600252D RID: 9517 RVA: 0x0014BFAC File Offset: 0x0014A1AC
        public OBS_TBL_WORK( AppMain.OBS_TBL_WORK tblWork )
        {
            Array.Copy( tblWork.key_timer, this.key_timer, this.key_timer.Length );
            Array.Copy( tblWork.move_timer, this.move_timer, this.move_timer.Length );
            this.flag = tblWork.flag;
            this.spd.Assign( tblWork.spd );
            this.scale.Assign( tblWork.scale );
            this.dir.Assign( tblWork.dir );
            this.act_tbl = tblWork.act_tbl;
            this.move_tbl = tblWork.move_tbl;
            this.scale_tbl = tblWork.scale_tbl;
            this.dir_tbl = tblWork.dir_tbl;
            Array.Copy( tblWork.data_work, this.data_work, this.data_work.Length );
            Array.Copy( tblWork.repeat_point, this.repeat_point, this.repeat_point.Length );
        }

        // Token: 0x0600252E RID: 9518 RVA: 0x0014C0E8 File Offset: 0x0014A2E8
        public AppMain.OBS_TBL_WORK Assign( AppMain.OBS_TBL_WORK tblWork )
        {
            if ( this != tblWork )
            {
                Array.Copy( tblWork.key_timer, this.key_timer, this.key_timer.Length );
                Array.Copy( tblWork.move_timer, this.move_timer, this.move_timer.Length );
                this.flag = tblWork.flag;
                this.spd.Assign( tblWork.spd );
                this.scale.Assign( tblWork.scale );
                this.dir.Assign( tblWork.dir );
                this.act_tbl = tblWork.act_tbl;
                this.move_tbl = tblWork.move_tbl;
                this.scale_tbl = tblWork.scale_tbl;
                this.dir_tbl = tblWork.dir_tbl;
                Array.Copy( tblWork.data_work, this.data_work, this.data_work.Length );
                Array.Copy( tblWork.repeat_point, this.repeat_point, this.repeat_point.Length );
            }
            return this;
        }

        // Token: 0x04005D22 RID: 23842
        public readonly short[] key_timer = new short[4];

        // Token: 0x04005D23 RID: 23843
        public readonly short[] move_timer = new short[4];

        // Token: 0x04005D24 RID: 23844
        public uint flag;

        // Token: 0x04005D25 RID: 23845
        public AppMain.VecFx32 spd = default(AppMain.VecFx32);

        // Token: 0x04005D26 RID: 23846
        public AppMain.VecFx32 scale = default(AppMain.VecFx32);

        // Token: 0x04005D27 RID: 23847
        public AppMain.VecU16 dir = default(AppMain.VecU16);

        // Token: 0x04005D28 RID: 23848
        public AppMain.OBS_ACT_TBL act_tbl;

        // Token: 0x04005D29 RID: 23849
        public AppMain.OBS_MOVE_TBL move_tbl;

        // Token: 0x04005D2A RID: 23850
        public AppMain.OBS_SCALE_TBL scale_tbl;

        // Token: 0x04005D2B RID: 23851
        public AppMain.OBS_DIR_TBL dir_tbl;

        // Token: 0x04005D2C RID: 23852
        public readonly AppMain.OBS_DATA_WORK[] data_work = new AppMain.OBS_DATA_WORK[4];

        // Token: 0x04005D2D RID: 23853
        public readonly short[] repeat_point = new short[4];
    }
}
