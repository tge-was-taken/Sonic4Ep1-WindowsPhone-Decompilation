using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;

public partial class AppMain
{

    // Token: 0x02000380 RID: 896
    public class A2S_AMA_HEADER
    {
        // Token: 0x0400606E RID: 24686
        public uint version;

        // Token: 0x0400606F RID: 24687
        public uint node_num;

        // Token: 0x04006070 RID: 24688
        public uint act_num;

        // Token: 0x04006071 RID: 24689
        public int node_tbl_offset;

        // Token: 0x04006072 RID: 24690
        public AppMain.A2S_AMA_NODE[] node_tbl;

        // Token: 0x04006073 RID: 24691
        public int act_tbl_offset;

        // Token: 0x04006074 RID: 24692
        public AppMain.A2S_AMA_ACT[] act_tbl;

        // Token: 0x04006075 RID: 24693
        public int node_name_tbl_offset;

        // Token: 0x04006076 RID: 24694
        public int act_name_tbl_offset;
    }

    // Token: 0x02000381 RID: 897
    public struct A2S_SUB_RECT
    {
        // Token: 0x04006077 RID: 24695
        public float left;

        // Token: 0x04006078 RID: 24696
        public float top;

        // Token: 0x04006079 RID: 24697
        public float right;

        // Token: 0x0400607A RID: 24698
        public float bottom;
    }

    // Token: 0x02000382 RID: 898
    public struct A2S_SUB_CIRCLE
    {
        // Token: 0x0400607B RID: 24699
        public float center_x;

        // Token: 0x0400607C RID: 24700
        public float center_y;

        // Token: 0x0400607D RID: 24701
        public float radius;

        // Token: 0x0400607E RID: 24702
        public uint pad;
    }

    // Token: 0x02000383 RID: 899
    public struct A2S_SUB_COL
    {
        // Token: 0x0400607F RID: 24703
        public byte a;

        // Token: 0x04006080 RID: 24704
        public byte b;

        // Token: 0x04006081 RID: 24705
        public byte g;

        // Token: 0x04006082 RID: 24706
        public byte r;
    }

    // Token: 0x02000384 RID: 900
    public class A2S_AMA_NODE
    {
        // Token: 0x04006083 RID: 24707
        public int _off;

        // Token: 0x04006084 RID: 24708
        public uint flag;

        // Token: 0x04006085 RID: 24709
        public uint id;

        // Token: 0x04006086 RID: 24710
        public int child_offset;

        // Token: 0x04006087 RID: 24711
        public AppMain.A2S_AMA_NODE child;

        // Token: 0x04006088 RID: 24712
        public int sibling_offset;

        // Token: 0x04006089 RID: 24713
        public AppMain.A2S_AMA_NODE sibling;

        // Token: 0x0400608A RID: 24714
        public int parent_offset;

        // Token: 0x0400608B RID: 24715
        public AppMain.A2S_AMA_NODE parent;

        // Token: 0x0400608C RID: 24716
        public int act_offset;

        // Token: 0x0400608D RID: 24717
        public AppMain.A2S_AMA_ACT act;
    }

    // Token: 0x02000385 RID: 901
    public class A2S_AMA_ACT
    {
        // Token: 0x060026C8 RID: 9928 RVA: 0x001503B4 File Offset: 0x0014E5B4
        public void Assign( AppMain.A2S_AMA_ACT old )
        {
            this.flag = old.flag;
            this.id = old.flag;
            this.frm_num = old.frm_num;
            this.pad1 = old.pad1;
            this.ofst = old.ofst;
            if ( old.mtn != null )
            {
                this.mtn = new AppMain.A2S_AMA_MTN();
                this.mtn.Assign( old.mtn );
            }
            if ( old.anm != null )
            {
                this.anm = new AppMain.A2S_AMA_ANM();
                this.anm.Assign( old.anm );
            }
            if ( old.acm != null )
            {
                this.acm = new AppMain.A2S_AMA_ACM();
                this.acm.Assign( old.acm );
            }
            if ( old.usr != null )
            {
                this.usr = new AppMain.A2S_AMA_USR();
                this.usr.Assign( old.usr );
            }
            if ( old.hit != null )
            {
                this.hit = new AppMain.A2S_AMA_HIT();
                this.hit.Assign( old.hit );
            }
        }

        // Token: 0x0400608E RID: 24718
        public int _off;

        // Token: 0x0400608F RID: 24719
        public uint flag;

        // Token: 0x04006090 RID: 24720
        public uint id;

        // Token: 0x04006091 RID: 24721
        public uint frm_num;

        // Token: 0x04006092 RID: 24722
        public uint pad1;

        // Token: 0x04006093 RID: 24723
        public AppMain.A2S_SUB_RECT ofst;

        // Token: 0x04006094 RID: 24724
        public int mtn_offset;

        // Token: 0x04006095 RID: 24725
        public AppMain.A2S_AMA_MTN mtn;

        // Token: 0x04006096 RID: 24726
        public int anm_offset;

        // Token: 0x04006097 RID: 24727
        public AppMain.A2S_AMA_ANM anm;

        // Token: 0x04006098 RID: 24728
        public int acm_offset;

        // Token: 0x04006099 RID: 24729
        public AppMain.A2S_AMA_ACM acm;

        // Token: 0x0400609A RID: 24730
        public int usr_offset;

        // Token: 0x0400609B RID: 24731
        public AppMain.A2S_AMA_USR usr;

        // Token: 0x0400609C RID: 24732
        public int hit_offset;

        // Token: 0x0400609D RID: 24733
        public AppMain.A2S_AMA_HIT hit;

        // Token: 0x0400609E RID: 24734
        public int next_offset;

        // Token: 0x0400609F RID: 24735
        public AppMain.A2S_AMA_ACT next;
    }

    // Token: 0x02000386 RID: 902
    public class A2S_AMA_MTN
    {
        // Token: 0x060026CA RID: 9930 RVA: 0x001504BC File Offset: 0x0014E6BC
        internal void Assign( AppMain.A2S_AMA_MTN old )
        {
            this.flag = old.flag;
            this.mtn_key_num = old.mtn_key_num;
            this.mtn_frm_num = old.mtn_frm_num;
            if ( old.mtn_key_tbl != null )
            {
                this.mtn_key_tbl = new AppMain.A2S_SUB_KEY[old.mtn_key_tbl.Length];
                Array.Copy( old.mtn_key_tbl, old.mtn_key_tbl, old.mtn_key_tbl.Length );
            }
            if ( old.mtn_tbl != null )
            {
                this.mtn_tbl = AppMain.New<AppMain.A2S_SUB_MTN>( old.mtn_tbl.Length );
                for ( int i = 0; i < this.mtn_tbl.Length; i++ )
                {
                    this.mtn_tbl[i].Assign( old.mtn_tbl[i] );
                }
            }
            this.trs_key_num = old.trs_key_num;
            this.trs_frm_num = old.trs_frm_num;
            if ( old.trs_key_tbl != null )
            {
                this.trs_key_tbl = new AppMain.A2S_SUB_KEY[old.trs_key_tbl.Length];
                Array.Copy( old.trs_key_tbl, this.trs_key_tbl, old.trs_key_tbl.Length );
            }
            if ( old.trs_tbl != null )
            {
                this.trs_tbl = AppMain.New<AppMain.A2S_SUB_TRS>( old.trs_tbl.Length );
                for ( int j = 0; j < this.trs_tbl.Length; j++ )
                {
                    this.trs_tbl[j].Assign( old.trs_tbl[j] );
                }
            }
        }

        // Token: 0x040060A0 RID: 24736
        public uint flag;

        // Token: 0x040060A1 RID: 24737
        public uint mtn_key_num;

        // Token: 0x040060A2 RID: 24738
        public uint mtn_frm_num;

        // Token: 0x040060A3 RID: 24739
        public int mtn_key_tbl_offset;

        // Token: 0x040060A4 RID: 24740
        public AppMain.A2S_SUB_KEY[] mtn_key_tbl;

        // Token: 0x040060A5 RID: 24741
        public int mtn_tbl_offset;

        // Token: 0x040060A6 RID: 24742
        public AppMain.A2S_SUB_MTN[] mtn_tbl;

        // Token: 0x040060A7 RID: 24743
        public uint trs_key_num;

        // Token: 0x040060A8 RID: 24744
        public uint trs_frm_num;

        // Token: 0x040060A9 RID: 24745
        public int trs_key_tbl_offset;

        // Token: 0x040060AA RID: 24746
        public AppMain.A2S_SUB_KEY[] trs_key_tbl;

        // Token: 0x040060AB RID: 24747
        public int trs_tbl_offset;

        // Token: 0x040060AC RID: 24748
        public AppMain.A2S_SUB_TRS[] trs_tbl;
    }

    // Token: 0x02000387 RID: 903
    public class A2S_AMA_ANM
    {
        // Token: 0x060026CC RID: 9932 RVA: 0x001505FC File Offset: 0x0014E7FC
        internal void Assign( AppMain.A2S_AMA_ANM old )
        {
            this.flag = old.flag;
            this.anm_key_num = old.anm_key_num;
            this.anm_frm_num = old.anm_frm_num;
            if ( old.anm_key_tbl != null )
            {
                this.anm_key_tbl = new AppMain.A2S_SUB_KEY[old.anm_key_tbl.Length];
                Array.Copy( old.anm_key_tbl, this.anm_key_tbl, old.anm_key_tbl.Length );
            }
            if ( old.anm_tbl != null )
            {
                this.anm_tbl = AppMain.New<AppMain.A2S_SUB_ANM>( old.anm_tbl.Length );
                for ( int i = 0; i < this.anm_tbl.Length; i++ )
                {
                    this.anm_tbl[i].Assign( old.anm_tbl[i] );
                }
            }
            this.mat_key_num = old.mat_key_num;
            this.mat_frm_num = old.mat_frm_num;
            if ( old.mat_key_tbl != null )
            {
                this.mat_key_tbl = new AppMain.A2S_SUB_KEY[old.mat_key_tbl.Length];
                Array.Copy( old.mat_key_tbl, this.mat_key_tbl, old.mat_key_tbl.Length );
            }
            if ( old.mat_tbl != null )
            {
                this.mat_tbl = AppMain.New<AppMain.A2S_SUB_MAT>( old.mat_tbl.Length );
                int num = 0;
                while ( ( long )num < ( long )( ( ulong )old.mat_key_num ) )
                {
                    this.mat_tbl[num].Assign( old.mat_tbl[num] );
                    num++;
                }
            }
        }

        // Token: 0x040060AD RID: 24749
        public uint flag;

        // Token: 0x040060AE RID: 24750
        public uint anm_key_num;

        // Token: 0x040060AF RID: 24751
        public uint anm_frm_num;

        // Token: 0x040060B0 RID: 24752
        public int anm_key_tbl_offset;

        // Token: 0x040060B1 RID: 24753
        public AppMain.A2S_SUB_KEY[] anm_key_tbl;

        // Token: 0x040060B2 RID: 24754
        public int anm_tbl_offset;

        // Token: 0x040060B3 RID: 24755
        public AppMain.A2S_SUB_ANM[] anm_tbl;

        // Token: 0x040060B4 RID: 24756
        public uint mat_key_num;

        // Token: 0x040060B5 RID: 24757
        public uint mat_frm_num;

        // Token: 0x040060B6 RID: 24758
        public int mat_key_tbl_offset;

        // Token: 0x040060B7 RID: 24759
        public AppMain.A2S_SUB_KEY[] mat_key_tbl;

        // Token: 0x040060B8 RID: 24760
        public int mat_tbl_offset;

        // Token: 0x040060B9 RID: 24761
        public AppMain.A2S_SUB_MAT[] mat_tbl;
    }

    // Token: 0x02000388 RID: 904
    public class A2S_AMA_ACM
    {
        // Token: 0x060026CE RID: 9934 RVA: 0x0015073C File Offset: 0x0014E93C
        internal void Assign( AppMain.A2S_AMA_ACM old )
        {
            this.flag = old.flag;
            this.acm_key_num = old.acm_key_num;
            this.acm_frm_num = old.acm_frm_num;
            if ( old.acm_key_tbl != null )
            {
                this.acm_key_tbl = new AppMain.A2S_SUB_KEY[old.acm_key_tbl.Length];
                Array.Copy( old.acm_key_tbl, this.acm_key_tbl, old.acm_key_tbl.Length );
            }
            if ( old.acm_tbl != null )
            {
                this.acm_tbl = new AppMain.A2S_SUB_ACM[old.acm_tbl.Length];
                Array.Copy( old.acm_tbl, this.acm_tbl, old.acm_tbl.Length );
            }
            this.trs_key_num = old.trs_key_num;
            this.trs_frm_num = old.trs_frm_num;
            if ( old.trs_key_tbl != null )
            {
                this.trs_key_tbl = new AppMain.A2S_SUB_KEY[old.trs_key_tbl.Length];
                Array.Copy( old.trs_key_tbl, this.trs_key_tbl, old.trs_key_tbl.Length );
            }
            if ( old.trs_tbl != null )
            {
                this.trs_tbl = AppMain.New<AppMain.A2S_SUB_TRS>( old.trs_tbl.Length );
                for ( int i = 0; i < this.trs_tbl.Length; i++ )
                {
                    this.trs_tbl[i].Assign( old.trs_tbl[i] );
                }
            }
            this.mat_key_num = old.mat_key_num;
            this.mat_frm_num = old.mat_frm_num;
            if ( old.mat_key_tbl != null )
            {
                this.mat_key_tbl = new AppMain.A2S_SUB_KEY[old.mat_key_tbl.Length];
                Array.Copy( old.mat_key_tbl, this.mat_key_tbl, old.mat_key_tbl.Length );
            }
            if ( old.mat_tbl != null )
            {
                this.mat_tbl = AppMain.New<AppMain.A2S_SUB_MAT>( old.mat_tbl.Length );
                for ( int j = 0; j < this.mat_tbl.Length; j++ )
                {
                    this.mat_tbl[j].Assign( old.mat_tbl[j] );
                }
            }
        }

        // Token: 0x040060BA RID: 24762
        public uint flag;

        // Token: 0x040060BB RID: 24763
        public uint acm_key_num;

        // Token: 0x040060BC RID: 24764
        public uint acm_frm_num;

        // Token: 0x040060BD RID: 24765
        public int acm_key_tbl_offset;

        // Token: 0x040060BE RID: 24766
        public AppMain.A2S_SUB_KEY[] acm_key_tbl;

        // Token: 0x040060BF RID: 24767
        public int acm_tbl_offset;

        // Token: 0x040060C0 RID: 24768
        public AppMain.A2S_SUB_ACM[] acm_tbl;

        // Token: 0x040060C1 RID: 24769
        public uint trs_key_num;

        // Token: 0x040060C2 RID: 24770
        public uint trs_frm_num;

        // Token: 0x040060C3 RID: 24771
        public int trs_key_tbl_offset;

        // Token: 0x040060C4 RID: 24772
        public AppMain.A2S_SUB_KEY[] trs_key_tbl;

        // Token: 0x040060C5 RID: 24773
        public int trs_tbl_offset;

        // Token: 0x040060C6 RID: 24774
        public AppMain.A2S_SUB_TRS[] trs_tbl;

        // Token: 0x040060C7 RID: 24775
        public uint mat_key_num;

        // Token: 0x040060C8 RID: 24776
        public uint mat_frm_num;

        // Token: 0x040060C9 RID: 24777
        public int mat_key_tbl_offset;

        // Token: 0x040060CA RID: 24778
        public AppMain.A2S_SUB_KEY[] mat_key_tbl;

        // Token: 0x040060CB RID: 24779
        public int mat_tbl_offset;

        // Token: 0x040060CC RID: 24780
        public AppMain.A2S_SUB_MAT[] mat_tbl;
    }

    // Token: 0x02000389 RID: 905
    public class A2S_AMA_USR
    {
        // Token: 0x060026D0 RID: 9936 RVA: 0x001508FC File Offset: 0x0014EAFC
        internal void Assign( AppMain.A2S_AMA_USR old )
        {
            this.flag = old.flag;
            this.usr_key_num = old.usr_key_num;
            this.usr_frm_num = old.usr_frm_num;
            if ( old.usr_key_tbl != null )
            {
                this.usr_key_tbl = new AppMain.A2S_SUB_KEY[old.usr_key_tbl.Length];
                Array.Copy( old.usr_key_tbl, this.usr_key_tbl, old.usr_key_tbl.Length );
            }
            if ( old.usr_tbl != null )
            {
                this.usr_tbl = new AppMain.A2S_SUB_USR[old.usr_tbl.Length];
                Array.Copy( old.usr_tbl, this.usr_tbl, old.usr_tbl.Length );
            }
        }

        // Token: 0x040060CD RID: 24781
        public uint flag;

        // Token: 0x040060CE RID: 24782
        public uint usr_key_num;

        // Token: 0x040060CF RID: 24783
        public uint usr_frm_num;

        // Token: 0x040060D0 RID: 24784
        public int usr_key_tbl_offset;

        // Token: 0x040060D1 RID: 24785
        public AppMain.A2S_SUB_KEY[] usr_key_tbl;

        // Token: 0x040060D2 RID: 24786
        public int usr_tbl_offset;

        // Token: 0x040060D3 RID: 24787
        public AppMain.A2S_SUB_USR[] usr_tbl;
    }

    // Token: 0x0200038A RID: 906
    public class A2S_AMA_HIT
    {
        // Token: 0x060026D2 RID: 9938 RVA: 0x001509A0 File Offset: 0x0014EBA0
        internal void Assign( AppMain.A2S_AMA_HIT old )
        {
            this.flag = old.flag;
            this.hit_key_num = old.hit_key_num;
            this.hit_frm_num = old.hit_frm_num;
            if ( old.hit_key_tbl != null )
            {
                this.hit_key_tbl = new AppMain.A2S_SUB_KEY[old.hit_key_tbl.Length];
                Array.Copy( old.hit_key_tbl, this.hit_key_tbl, old.hit_key_tbl.Length );
            }
            if ( old.hit_tbl != null )
            {
                this.hit_tbl = AppMain.New<AppMain.A2S_SUB_HIT>( old.hit_tbl.Length );
                for ( int i = 0; i < this.hit_tbl.Length; i++ )
                {
                    this.hit_tbl[i].Assign( old.hit_tbl[i] );
                }
            }
        }

        // Token: 0x040060D4 RID: 24788
        public uint flag;

        // Token: 0x040060D5 RID: 24789
        public uint hit_key_num;

        // Token: 0x040060D6 RID: 24790
        public uint hit_frm_num;

        // Token: 0x040060D7 RID: 24791
        public int hit_key_tbl_offset;

        // Token: 0x040060D8 RID: 24792
        public AppMain.A2S_SUB_KEY[] hit_key_tbl;

        // Token: 0x040060D9 RID: 24793
        public int hit_tbl_offset;

        // Token: 0x040060DA RID: 24794
        public AppMain.A2S_SUB_HIT[] hit_tbl;
    }

    // Token: 0x0200038B RID: 907
    public class A2S_SUB_TRS
    {
        // Token: 0x060026D4 RID: 9940 RVA: 0x00150A50 File Offset: 0x0014EC50
        internal void Assign( AppMain.A2S_SUB_TRS old )
        {
            this.trs_x = old.trs_x;
            this.trs_y = old.trs_y;
            this.trs_z = old.trs_z;
            this.trs_accele = old.trs_accele;
        }

        // Token: 0x040060DB RID: 24795
        public float trs_x;

        // Token: 0x040060DC RID: 24796
        public float trs_y;

        // Token: 0x040060DD RID: 24797
        public float trs_z;

        // Token: 0x040060DE RID: 24798
        public float trs_accele;
    }

    // Token: 0x0200038C RID: 908
    public class A2S_SUB_MTN
    {
        // Token: 0x060026D6 RID: 9942 RVA: 0x00150A8A File Offset: 0x0014EC8A
        internal void Assign( AppMain.A2S_SUB_MTN old )
        {
            this.scl_x = old.scl_x;
            this.scl_y = old.scl_y;
            this.rot = old.rot;
            this.scl_accele = old.scl_accele;
            this.rot_accele = old.rot_accele;
        }

        // Token: 0x040060DF RID: 24799
        public float scl_x;

        // Token: 0x040060E0 RID: 24800
        public float scl_y;

        // Token: 0x040060E1 RID: 24801
        public float rot;

        // Token: 0x040060E2 RID: 24802
        public float scl_accele;

        // Token: 0x040060E3 RID: 24803
        public float rot_accele;
    }

    // Token: 0x0200038D RID: 909
    public class A2S_SUB_ANM
    {
        // Token: 0x060026D8 RID: 9944 RVA: 0x00150AD0 File Offset: 0x0014ECD0
        internal void Assign( AppMain.A2S_SUB_ANM old )
        {
            this.tex_id = old.tex_id;
            this.clamp = old.clamp;
            this.filter = old.filter;
            this.texel_accele = old.texel_accele;
            this.texel = old.texel;
        }

        // Token: 0x040060E4 RID: 24804
        public int tex_id;

        // Token: 0x040060E5 RID: 24805
        public uint clamp;

        // Token: 0x040060E6 RID: 24806
        public uint filter;

        // Token: 0x040060E7 RID: 24807
        public float texel_accele;

        // Token: 0x040060E8 RID: 24808
        public AppMain.A2S_SUB_RECT texel;
    }

    // Token: 0x0200038E RID: 910
    public class A2S_SUB_MAT
    {
        // Token: 0x060026DA RID: 9946 RVA: 0x00150B16 File Offset: 0x0014ED16
        internal void Assign( AppMain.A2S_SUB_MAT old )
        {
            this.base_ = old.base_;
            this.fade = old.fade;
            this.base_accele = old.base_accele;
            this.fade_accele = old.fade_accele;
            this.blend = old.blend;
        }

        // Token: 0x040060E9 RID: 24809
        public AppMain.A2S_SUB_COL base_;

        // Token: 0x040060EA RID: 24810
        public AppMain.A2S_SUB_COL fade;

        // Token: 0x040060EB RID: 24811
        public float base_accele;

        // Token: 0x040060EC RID: 24812
        public float fade_accele;

        // Token: 0x040060ED RID: 24813
        public uint blend;
    }

    // Token: 0x0200038F RID: 911
    public struct A2S_SUB_ACM
    {
        // Token: 0x040060EE RID: 24814
        public float trs_scl_x;

        // Token: 0x040060EF RID: 24815
        public float trs_scl_y;

        // Token: 0x040060F0 RID: 24816
        public float scl_x;

        // Token: 0x040060F1 RID: 24817
        public float scl_y;

        // Token: 0x040060F2 RID: 24818
        public float rot;

        // Token: 0x040060F3 RID: 24819
        public float trs_scl_accele;

        // Token: 0x040060F4 RID: 24820
        public float scl_accele;

        // Token: 0x040060F5 RID: 24821
        public float rot_accele;
    }

    // Token: 0x02000390 RID: 912
    public struct A2S_SUB_USR
    {
        // Token: 0x040060F6 RID: 24822
        public uint usr_id;

        // Token: 0x040060F7 RID: 24823
        public float usr_accele;
    }

    // Token: 0x02000391 RID: 913
    public class A2S_SUB_HIT
    {
        // Token: 0x060026DC RID: 9948 RVA: 0x00150B5C File Offset: 0x0014ED5C
        internal void Assign( AppMain.A2S_SUB_HIT old )
        {
            this.flag = old.flag;
            this.type = old.type;
            this.hit_accele = old.hit_accele;
            this.pad = old.pad;
            this.rect = old.rect;
            this.circle = old.circle;
        }

        // Token: 0x040060F8 RID: 24824
        public uint flag;

        // Token: 0x040060F9 RID: 24825
        public uint type;

        // Token: 0x040060FA RID: 24826
        public float hit_accele;

        // Token: 0x040060FB RID: 24827
        public uint pad;

        // Token: 0x040060FC RID: 24828
        public AppMain.A2S_SUB_RECT rect;

        // Token: 0x040060FD RID: 24829
        public AppMain.A2S_SUB_CIRCLE circle;
    }

    // Token: 0x02000392 RID: 914
    public struct A2S_SUB_KEY
    {
        // Token: 0x040060FE RID: 24830
        public uint frm;

        // Token: 0x040060FF RID: 24831
        public uint interpol;
    }

    // Token: 0x06001867 RID: 6247 RVA: 0x000DB95C File Offset: 0x000D9B5C
    public static AppMain.A2S_AMA_HEADER readAMAFile( string name )
    {
        AppMain.A2S_AMA_HEADER result = null;
        using ( Stream stream = TitleContainer.OpenStream( "Content\\" + name ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( stream ) )
            {
                result = AppMain.readAMAFile( binaryReader );
            }
        }
        return result;
    }

    // Token: 0x06001868 RID: 6248 RVA: 0x000DB9C0 File Offset: 0x000D9BC0
    public static AppMain.A2S_AMA_HEADER readAMAFile( object data )
    {
        if ( data is AppMain.A2S_AMA_HEADER )
        {
            return ( AppMain.A2S_AMA_HEADER )data;
        }
        AppMain.AmbChunk ambChunk = (AppMain.AmbChunk)data;
        return AppMain.readAMAFile( ambChunk.array, ambChunk.offset );
    }

    // Token: 0x06001869 RID: 6249 RVA: 0x000DB9F4 File Offset: 0x000D9BF4
    public static AppMain.A2S_AMA_HEADER readAMAFile( byte[] data, int offset )
    {
        AppMain.A2S_AMA_HEADER result = null;
        using ( MemoryStream memoryStream = new MemoryStream( data, offset, data.Length - offset ) )
        {
            using ( BinaryReader binaryReader = new BinaryReader( memoryStream ) )
            {
                result = AppMain.readAMAFile( binaryReader );
            }
        }
        return result;
    }

    // Token: 0x0600186A RID: 6250 RVA: 0x000DBA54 File Offset: 0x000D9C54
    public static AppMain.A2S_AMA_HEADER readAMAFile( BinaryReader br )
    {
        AppMain.A2S_AMA_HEADER a2S_AMA_HEADER = new AppMain.A2S_AMA_HEADER();
        br.BaseStream.Seek( 4L, SeekOrigin.Current );
        a2S_AMA_HEADER.version = br.ReadUInt32();
        a2S_AMA_HEADER.node_num = br.ReadUInt32();
        a2S_AMA_HEADER.act_num = br.ReadUInt32();
        a2S_AMA_HEADER.node_tbl_offset = br.ReadInt32();
        a2S_AMA_HEADER.act_tbl_offset = br.ReadInt32();
        a2S_AMA_HEADER.node_name_tbl_offset = br.ReadInt32();
        a2S_AMA_HEADER.act_name_tbl_offset = br.ReadInt32();
        a2S_AMA_HEADER.node_tbl = new AppMain.A2S_AMA_NODE[a2S_AMA_HEADER.node_num];
        a2S_AMA_HEADER.act_tbl = new AppMain.A2S_AMA_ACT[a2S_AMA_HEADER.act_num];
        if ( a2S_AMA_HEADER.node_tbl_offset != 0 )
        {
            br.BaseStream.Seek( ( long )a2S_AMA_HEADER.node_tbl_offset, 0 );
            int num = 0;
            while ( ( long )num < ( long )( ( ulong )a2S_AMA_HEADER.node_num ) )
            {
                int num2 = br.ReadInt32();
                if ( num2 != 0 )
                {
                    if ( !AppMain.readAMAFile_nodeHash.ContainsKey( num2 ) )
                    {
                        a2S_AMA_HEADER.node_tbl[num] = new AppMain.A2S_AMA_NODE();
                        a2S_AMA_HEADER.node_tbl[num]._off = num2;
                        AppMain.readAMAFile_nodeHash.Add( a2S_AMA_HEADER.node_tbl[num]._off, a2S_AMA_HEADER.node_tbl[num] );
                    }
                    else
                    {
                        a2S_AMA_HEADER.node_tbl[num] = AppMain.readAMAFile_nodeHash[num2];
                    }
                }
                num++;
            }
            int num3 = 0;
            while ( ( long )num3 < ( long )( ( ulong )a2S_AMA_HEADER.node_num ) )
            {
                br.BaseStream.Seek( ( long )a2S_AMA_HEADER.node_tbl[num3]._off, 0 );
                a2S_AMA_HEADER.node_tbl[num3].flag = br.ReadUInt32();
                a2S_AMA_HEADER.node_tbl[num3].id = br.ReadUInt32();
                a2S_AMA_HEADER.node_tbl[num3].child_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.node_tbl[num3].child_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_nodeHash.ContainsKey( a2S_AMA_HEADER.node_tbl[num3].child_offset ) )
                    {
                        a2S_AMA_HEADER.node_tbl[num3].child = new AppMain.A2S_AMA_NODE();
                        AppMain.readAMAFile_nodeHash.Add( a2S_AMA_HEADER.node_tbl[num3].child_offset, a2S_AMA_HEADER.node_tbl[num3].child );
                    }
                    else
                    {
                        a2S_AMA_HEADER.node_tbl[num3].child = AppMain.readAMAFile_nodeHash[a2S_AMA_HEADER.node_tbl[num3].child_offset];
                    }
                }
                a2S_AMA_HEADER.node_tbl[num3].sibling_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.node_tbl[num3].sibling_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_nodeHash.ContainsKey( a2S_AMA_HEADER.node_tbl[num3].sibling_offset ) )
                    {
                        a2S_AMA_HEADER.node_tbl[num3].sibling = new AppMain.A2S_AMA_NODE();
                        AppMain.readAMAFile_nodeHash.Add( a2S_AMA_HEADER.node_tbl[num3].sibling_offset, a2S_AMA_HEADER.node_tbl[num3].sibling );
                    }
                    else
                    {
                        a2S_AMA_HEADER.node_tbl[num3].sibling = AppMain.readAMAFile_nodeHash[a2S_AMA_HEADER.node_tbl[num3].sibling_offset];
                    }
                }
                a2S_AMA_HEADER.node_tbl[num3].parent_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.node_tbl[num3].parent_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_nodeHash.ContainsKey( a2S_AMA_HEADER.node_tbl[num3].parent_offset ) )
                    {
                        a2S_AMA_HEADER.node_tbl[num3].parent = new AppMain.A2S_AMA_NODE();
                        AppMain.readAMAFile_nodeHash.Add( a2S_AMA_HEADER.node_tbl[num3].parent_offset, a2S_AMA_HEADER.node_tbl[num3].parent );
                    }
                    else
                    {
                        a2S_AMA_HEADER.node_tbl[num3].parent = AppMain.readAMAFile_nodeHash[a2S_AMA_HEADER.node_tbl[num3].parent_offset];
                    }
                }
                a2S_AMA_HEADER.node_tbl[num3].act_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.node_tbl[num3].act_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_actHash.ContainsKey( a2S_AMA_HEADER.node_tbl[num3].act_offset ) )
                    {
                        a2S_AMA_HEADER.node_tbl[num3].act = new AppMain.A2S_AMA_ACT();
                        a2S_AMA_HEADER.node_tbl[num3].act._off = a2S_AMA_HEADER.node_tbl[num3].act_offset;
                        AppMain.readAMAFile_actHash.Add( a2S_AMA_HEADER.node_tbl[num3].act_offset, a2S_AMA_HEADER.node_tbl[num3].act );
                    }
                    else
                    {
                        a2S_AMA_HEADER.node_tbl[num3].act = AppMain.readAMAFile_actHash[a2S_AMA_HEADER.node_tbl[num3].act_offset];
                    }
                }
                br.BaseStream.Seek( 8L, SeekOrigin.Current );
                num3++;
            }
            br.BaseStream.Seek( ( long )a2S_AMA_HEADER.node_name_tbl_offset, 0 );
            int[] array = new int[a2S_AMA_HEADER.node_num];
            int num4 = 0;
            while ( ( long )num4 < ( long )( ( ulong )a2S_AMA_HEADER.node_num ) )
            {
                array[num4] = br.ReadInt32();
                num4++;
            }
            int num5 = 0;
            while ( ( long )num5 < ( long )( ( ulong )a2S_AMA_HEADER.node_num ) )
            {
                br.BaseStream.Seek( ( long )array[num5], 0 );
                AppMain.skipString( br );
                num5++;
            }
        }
        if ( a2S_AMA_HEADER.act_tbl_offset != 0 )
        {
            br.BaseStream.Seek( ( long )a2S_AMA_HEADER.act_tbl_offset, 0 );
            int num6 = 0;
            while ( ( long )num6 < ( long )( ( ulong )a2S_AMA_HEADER.act_num ) )
            {
                int num7 = br.ReadInt32();
                if ( !AppMain.readAMAFile_actHash.ContainsKey( num7 ) )
                {
                    a2S_AMA_HEADER.act_tbl[num6] = new AppMain.A2S_AMA_ACT();
                    a2S_AMA_HEADER.act_tbl[num6]._off = num7;
                    AppMain.readAMAFile_actHash.Add( a2S_AMA_HEADER.act_tbl[num6]._off, a2S_AMA_HEADER.act_tbl[num6] );
                }
                else
                {
                    a2S_AMA_HEADER.act_tbl[num6] = AppMain.readAMAFile_actHash[num7];
                }
                num6++;
            }
            int num8 = 0;
            while ( ( long )num8 < ( long )( ( ulong )a2S_AMA_HEADER.act_num ) )
            {
                br.BaseStream.Seek( ( long )a2S_AMA_HEADER.act_tbl[num8]._off, 0 );
                a2S_AMA_HEADER.act_tbl[num8].flag = br.ReadUInt32();
                a2S_AMA_HEADER.act_tbl[num8].id = br.ReadUInt32();
                a2S_AMA_HEADER.act_tbl[num8].frm_num = br.ReadUInt32();
                a2S_AMA_HEADER.act_tbl[num8].pad1 = br.ReadUInt32();
                a2S_AMA_HEADER.act_tbl[num8].ofst.left = br.ReadSingle();
                a2S_AMA_HEADER.act_tbl[num8].ofst.top = br.ReadSingle();
                a2S_AMA_HEADER.act_tbl[num8].ofst.right = br.ReadSingle();
                a2S_AMA_HEADER.act_tbl[num8].ofst.bottom = br.ReadSingle();
                a2S_AMA_HEADER.act_tbl[num8].mtn_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.act_tbl[num8].mtn_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_mtnHash.ContainsKey( a2S_AMA_HEADER.act_tbl[num8].mtn_offset ) )
                    {
                        a2S_AMA_HEADER.act_tbl[num8].mtn = new AppMain.A2S_AMA_MTN();
                        AppMain.readAMAFile_mtnHash.Add( a2S_AMA_HEADER.act_tbl[num8].mtn_offset, a2S_AMA_HEADER.act_tbl[num8].mtn );
                    }
                    else
                    {
                        a2S_AMA_HEADER.act_tbl[num8].mtn = AppMain.readAMAFile_mtnHash[a2S_AMA_HEADER.act_tbl[num8].mtn_offset];
                    }
                }
                a2S_AMA_HEADER.act_tbl[num8].anm_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.act_tbl[num8].anm_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_anmHash.ContainsKey( a2S_AMA_HEADER.act_tbl[num8].anm_offset ) )
                    {
                        a2S_AMA_HEADER.act_tbl[num8].anm = new AppMain.A2S_AMA_ANM();
                        AppMain.readAMAFile_anmHash.Add( a2S_AMA_HEADER.act_tbl[num8].anm_offset, a2S_AMA_HEADER.act_tbl[num8].anm );
                    }
                    else
                    {
                        a2S_AMA_HEADER.act_tbl[num8].anm = AppMain.readAMAFile_anmHash[a2S_AMA_HEADER.act_tbl[num8].anm_offset];
                    }
                }
                a2S_AMA_HEADER.act_tbl[num8].acm_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.act_tbl[num8].acm_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_acmHash.ContainsKey( a2S_AMA_HEADER.act_tbl[num8].acm_offset ) )
                    {
                        a2S_AMA_HEADER.act_tbl[num8].acm = new AppMain.A2S_AMA_ACM();
                        AppMain.readAMAFile_acmHash.Add( a2S_AMA_HEADER.act_tbl[num8].acm_offset, a2S_AMA_HEADER.act_tbl[num8].acm );
                    }
                    else
                    {
                        a2S_AMA_HEADER.act_tbl[num8].acm = AppMain.readAMAFile_acmHash[a2S_AMA_HEADER.act_tbl[num8].acm_offset];
                    }
                }
                a2S_AMA_HEADER.act_tbl[num8].usr_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.act_tbl[num8].usr_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_usrHash.ContainsKey( a2S_AMA_HEADER.act_tbl[num8].usr_offset ) )
                    {
                        a2S_AMA_HEADER.act_tbl[num8].usr = new AppMain.A2S_AMA_USR();
                        AppMain.readAMAFile_usrHash.Add( a2S_AMA_HEADER.act_tbl[num8].usr_offset, a2S_AMA_HEADER.act_tbl[num8].usr );
                    }
                    else
                    {
                        a2S_AMA_HEADER.act_tbl[num8].usr = AppMain.readAMAFile_usrHash[a2S_AMA_HEADER.act_tbl[num8].usr_offset];
                    }
                }
                a2S_AMA_HEADER.act_tbl[num8].hit_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.act_tbl[num8].hit_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_hitHash.ContainsKey( a2S_AMA_HEADER.act_tbl[num8].hit_offset ) )
                    {
                        a2S_AMA_HEADER.act_tbl[num8].hit = new AppMain.A2S_AMA_HIT();
                        AppMain.readAMAFile_hitHash.Add( a2S_AMA_HEADER.act_tbl[num8].hit_offset, a2S_AMA_HEADER.act_tbl[num8].hit );
                    }
                    else
                    {
                        a2S_AMA_HEADER.act_tbl[num8].hit = AppMain.readAMAFile_hitHash[a2S_AMA_HEADER.act_tbl[num8].hit_offset];
                    }
                }
                a2S_AMA_HEADER.act_tbl[num8].next_offset = br.ReadInt32();
                if ( a2S_AMA_HEADER.act_tbl[num8].next_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_actHash.ContainsKey( a2S_AMA_HEADER.act_tbl[num8].next_offset ) )
                    {
                        a2S_AMA_HEADER.act_tbl[num8].next = new AppMain.A2S_AMA_ACT();
                        AppMain.readAMAFile_actHash.Add( a2S_AMA_HEADER.act_tbl[num8].next_offset, a2S_AMA_HEADER.act_tbl[num8].next );
                    }
                    else
                    {
                        a2S_AMA_HEADER.act_tbl[num8].next = AppMain.readAMAFile_actHash[a2S_AMA_HEADER.act_tbl[num8].next_offset];
                    }
                }
                br.BaseStream.Seek( 8L, SeekOrigin.Current );
                num8++;
            }
            br.BaseStream.Seek( ( long )a2S_AMA_HEADER.act_name_tbl_offset, 0 );
            int[] array2 = new int[a2S_AMA_HEADER.act_num];
            int num9 = 0;
            while ( ( long )num9 < ( long )( ( ulong )a2S_AMA_HEADER.act_num ) )
            {
                array2[num9] = br.ReadInt32();
                num9++;
            }
            int num10 = 0;
            while ( ( long )num10 < ( long )( ( ulong )a2S_AMA_HEADER.act_num ) )
            {
                br.BaseStream.Seek( ( long )array2[num10], 0 );
                AppMain.skipString( br );
                num10++;
            }
            foreach ( KeyValuePair<int, AppMain.A2S_AMA_MTN> keyValuePair in AppMain.readAMAFile_mtnHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair.Key, 0 );
                AppMain.A2S_AMA_MTN value = keyValuePair.Value;
                value.flag = br.ReadUInt32();
                value.mtn_key_num = br.ReadUInt32();
                value.mtn_frm_num = br.ReadUInt32();
                value.mtn_key_tbl_offset = br.ReadInt32();
                if ( value.mtn_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value.mtn_key_tbl_offset ) )
                    {
                        value.mtn_key_tbl = new AppMain.A2S_SUB_KEY[value.mtn_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value.mtn_key_tbl_offset, value.mtn_key_tbl );
                    }
                    else
                    {
                        value.mtn_key_tbl = AppMain.readAMAFile_subkeyHash[value.mtn_key_tbl_offset];
                    }
                }
                value.mtn_tbl_offset = br.ReadInt32();
                if ( value.mtn_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_submtnHash.ContainsKey( value.mtn_tbl_offset ) )
                    {
                        value.mtn_tbl = new AppMain.A2S_SUB_MTN[value.mtn_key_num + 1U];
                        AppMain.readAMAFile_submtnHash.Add( value.mtn_tbl_offset, value.mtn_tbl );
                    }
                    else
                    {
                        value.mtn_tbl = AppMain.readAMAFile_submtnHash[value.mtn_tbl_offset];
                    }
                }
                value.trs_key_num = br.ReadUInt32();
                value.trs_frm_num = br.ReadUInt32();
                value.trs_key_tbl_offset = br.ReadInt32();
                if ( value.trs_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value.trs_key_tbl_offset ) )
                    {
                        value.trs_key_tbl = new AppMain.A2S_SUB_KEY[value.trs_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value.trs_key_tbl_offset, value.trs_key_tbl );
                    }
                    else
                    {
                        value.trs_key_tbl = AppMain.readAMAFile_subkeyHash[value.trs_key_tbl_offset];
                    }
                }
                value.trs_tbl_offset = br.ReadInt32();
                if ( value.trs_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subtrsHash.ContainsKey( value.trs_tbl_offset ) )
                    {
                        value.trs_tbl = new AppMain.A2S_SUB_TRS[value.trs_key_num + 1U];
                        AppMain.readAMAFile_subtrsHash.Add( value.trs_tbl_offset, value.trs_tbl );
                    }
                    else
                    {
                        value.trs_tbl = AppMain.readAMAFile_subtrsHash[value.trs_tbl_offset];
                    }
                }
            }
            foreach ( KeyValuePair<int, AppMain.A2S_AMA_ANM> keyValuePair2 in AppMain.readAMAFile_anmHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair2.Key, 0 );
                AppMain.A2S_AMA_ANM value2 = keyValuePair2.Value;
                value2.flag = br.ReadUInt32();
                value2.anm_key_num = br.ReadUInt32();
                value2.anm_frm_num = br.ReadUInt32();
                value2.anm_key_tbl_offset = br.ReadInt32();
                if ( value2.anm_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value2.anm_key_tbl_offset ) )
                    {
                        value2.anm_key_tbl = new AppMain.A2S_SUB_KEY[value2.anm_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value2.anm_key_tbl_offset, value2.anm_key_tbl );
                    }
                    else
                    {
                        value2.anm_key_tbl = AppMain.readAMAFile_subkeyHash[value2.anm_key_tbl_offset];
                    }
                }
                value2.anm_tbl_offset = br.ReadInt32();
                if ( value2.anm_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subanmHash.ContainsKey( value2.anm_tbl_offset ) )
                    {
                        value2.anm_tbl = new AppMain.A2S_SUB_ANM[value2.anm_key_num + 1U];
                        AppMain.readAMAFile_subanmHash.Add( value2.anm_tbl_offset, value2.anm_tbl );
                    }
                    else
                    {
                        value2.anm_tbl = AppMain.readAMAFile_subanmHash[value2.anm_tbl_offset];
                    }
                }
                value2.mat_key_num = br.ReadUInt32();
                value2.mat_frm_num = br.ReadUInt32();
                value2.mat_key_tbl_offset = br.ReadInt32();
                if ( value2.mat_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value2.mat_key_tbl_offset ) )
                    {
                        value2.mat_key_tbl = new AppMain.A2S_SUB_KEY[value2.mat_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value2.mat_key_tbl_offset, value2.mat_key_tbl );
                    }
                    else
                    {
                        value2.mat_key_tbl = AppMain.readAMAFile_subkeyHash[value2.mat_key_tbl_offset];
                    }
                }
                value2.mat_tbl_offset = br.ReadInt32();
                if ( value2.mat_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_submatHash.ContainsKey( value2.mat_tbl_offset ) )
                    {
                        value2.mat_tbl = new AppMain.A2S_SUB_MAT[value2.mat_key_num + 1U];
                        AppMain.readAMAFile_submatHash.Add( value2.mat_tbl_offset, value2.mat_tbl );
                    }
                    else
                    {
                        value2.mat_tbl = AppMain.readAMAFile_submatHash[value2.mat_tbl_offset];
                    }
                }
                br.BaseStream.Seek( 12L, SeekOrigin.Current );
            }
            foreach ( KeyValuePair<int, AppMain.A2S_AMA_ACM> keyValuePair3 in AppMain.readAMAFile_acmHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair3.Key, 0 );
                AppMain.A2S_AMA_ACM value3 = keyValuePair3.Value;
                value3.flag = br.ReadUInt32();
                value3.acm_key_num = br.ReadUInt32();
                value3.acm_frm_num = br.ReadUInt32();
                value3.acm_key_tbl_offset = br.ReadInt32();
                if ( value3.acm_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value3.acm_key_tbl_offset ) )
                    {
                        value3.acm_key_tbl = new AppMain.A2S_SUB_KEY[value3.acm_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value3.acm_key_tbl_offset, value3.acm_key_tbl );
                    }
                    else
                    {
                        value3.acm_key_tbl = AppMain.readAMAFile_subkeyHash[value3.acm_key_tbl_offset];
                    }
                }
                value3.acm_tbl_offset = br.ReadInt32();
                if ( value3.acm_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subacmHash.ContainsKey( value3.acm_tbl_offset ) )
                    {
                        value3.acm_tbl = new AppMain.A2S_SUB_ACM[value3.acm_key_num + 1U];
                        AppMain.readAMAFile_subacmHash.Add( value3.acm_tbl_offset, value3.acm_tbl );
                    }
                    else
                    {
                        value3.acm_tbl = AppMain.readAMAFile_subacmHash[value3.acm_tbl_offset];
                    }
                }
                value3.trs_key_num = br.ReadUInt32();
                value3.trs_frm_num = br.ReadUInt32();
                value3.trs_key_tbl_offset = br.ReadInt32();
                if ( value3.trs_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value3.trs_key_tbl_offset ) )
                    {
                        value3.trs_key_tbl = new AppMain.A2S_SUB_KEY[value3.trs_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value3.trs_key_tbl_offset, value3.trs_key_tbl );
                    }
                    else
                    {
                        value3.trs_key_tbl = AppMain.readAMAFile_subkeyHash[value3.trs_key_tbl_offset];
                    }
                }
                value3.trs_tbl_offset = br.ReadInt32();
                if ( value3.trs_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subtrsHash.ContainsKey( value3.trs_tbl_offset ) )
                    {
                        value3.trs_tbl = new AppMain.A2S_SUB_TRS[value3.trs_key_num + 1U];
                        AppMain.readAMAFile_subtrsHash.Add( value3.trs_tbl_offset, value3.trs_tbl );
                    }
                    else
                    {
                        value3.trs_tbl = AppMain.readAMAFile_subtrsHash[value3.trs_tbl_offset];
                    }
                }
                value3.mat_key_num = br.ReadUInt32();
                value3.mat_frm_num = br.ReadUInt32();
                value3.mat_key_tbl_offset = br.ReadInt32();
                if ( value3.mat_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value3.mat_key_tbl_offset ) )
                    {
                        value3.mat_key_tbl = new AppMain.A2S_SUB_KEY[value3.mat_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value3.mat_key_tbl_offset, value3.mat_key_tbl );
                    }
                    else
                    {
                        value3.mat_key_tbl = AppMain.readAMAFile_subkeyHash[value3.mat_key_tbl_offset];
                    }
                }
                value3.mat_tbl_offset = br.ReadInt32();
                if ( value3.mat_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_submatHash.ContainsKey( value3.mat_tbl_offset ) )
                    {
                        value3.mat_tbl = new AppMain.A2S_SUB_MAT[value3.mat_key_num + 1U];
                        AppMain.readAMAFile_submatHash.Add( value3.mat_tbl_offset, value3.mat_tbl );
                    }
                    else
                    {
                        value3.mat_tbl = AppMain.readAMAFile_submatHash[value3.mat_tbl_offset];
                    }
                }
                br.BaseStream.Seek( 12L, SeekOrigin.Current );
            }
            foreach ( KeyValuePair<int, AppMain.A2S_AMA_USR> keyValuePair4 in AppMain.readAMAFile_usrHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair4.Key, 0 );
                AppMain.A2S_AMA_USR value4 = keyValuePair4.Value;
                value4.flag = br.ReadUInt32();
                value4.usr_key_num = br.ReadUInt32();
                value4.usr_frm_num = br.ReadUInt32();
                value4.usr_key_tbl_offset = br.ReadInt32();
                if ( value4.usr_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value4.usr_key_tbl_offset ) )
                    {
                        value4.usr_key_tbl = new AppMain.A2S_SUB_KEY[value4.usr_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value4.usr_key_tbl_offset, value4.usr_key_tbl );
                    }
                    else
                    {
                        value4.usr_key_tbl = AppMain.readAMAFile_subkeyHash[value4.usr_key_tbl_offset];
                    }
                }
                value4.usr_tbl_offset = br.ReadInt32();
                if ( value4.usr_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subusrHash.ContainsKey( value4.usr_tbl_offset ) )
                    {
                        value4.usr_tbl = new AppMain.A2S_SUB_USR[value4.usr_key_num + 1U];
                        AppMain.readAMAFile_subusrHash.Add( value4.usr_tbl_offset, value4.usr_tbl );
                    }
                    else
                    {
                        value4.usr_tbl = AppMain.readAMAFile_subusrHash[value4.usr_tbl_offset];
                    }
                }
                br.BaseStream.Seek( 12L, SeekOrigin.Current );
            }
            foreach ( KeyValuePair<int, AppMain.A2S_AMA_HIT> keyValuePair5 in AppMain.readAMAFile_hitHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair5.Key, 0 );
                AppMain.A2S_AMA_HIT value5 = keyValuePair5.Value;
                value5.flag = br.ReadUInt32();
                value5.hit_key_num = br.ReadUInt32();
                value5.hit_frm_num = br.ReadUInt32();
                value5.hit_key_tbl_offset = br.ReadInt32();
                if ( value5.hit_key_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subkeyHash.ContainsKey( value5.hit_key_tbl_offset ) )
                    {
                        value5.hit_key_tbl = new AppMain.A2S_SUB_KEY[value5.hit_key_num + 1U];
                        AppMain.readAMAFile_subkeyHash.Add( value5.hit_key_tbl_offset, value5.hit_key_tbl );
                    }
                    else
                    {
                        value5.hit_key_tbl = AppMain.readAMAFile_subkeyHash[value5.hit_key_tbl_offset];
                    }
                }
                value5.hit_tbl_offset = br.ReadInt32();
                if ( value5.hit_tbl_offset != 0 )
                {
                    if ( !AppMain.readAMAFile_subhitHash.ContainsKey( value5.hit_tbl_offset ) )
                    {
                        value5.hit_tbl = new AppMain.A2S_SUB_HIT[value5.hit_key_num + 1U];
                        AppMain.readAMAFile_subhitHash.Add( value5.hit_tbl_offset, value5.hit_tbl );
                    }
                    else
                    {
                        value5.hit_tbl = AppMain.readAMAFile_subhitHash[value5.hit_tbl_offset];
                    }
                }
                br.BaseStream.Seek( 12L, SeekOrigin.Current );
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_TRS[]> keyValuePair6 in AppMain.readAMAFile_subtrsHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair6.Key, 0 );
                AppMain.A2S_SUB_TRS[] value6 = keyValuePair6.Value;
                int num11 = keyValuePair6.Value.Length;
                for ( int i = 0; i < num11; i++ )
                {
                    value6[i] = new AppMain.A2S_SUB_TRS();
                    value6[i].trs_x = br.ReadSingle();
                    value6[i].trs_y = br.ReadSingle();
                    value6[i].trs_z = br.ReadSingle();
                    value6[i].trs_accele = br.ReadSingle();
                }
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_MTN[]> keyValuePair7 in AppMain.readAMAFile_submtnHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair7.Key, 0 );
                AppMain.A2S_SUB_MTN[] value7 = keyValuePair7.Value;
                int num12 = keyValuePair7.Value.Length;
                for ( int j = 0; j < num12; j++ )
                {
                    value7[j] = new AppMain.A2S_SUB_MTN();
                    value7[j].scl_x = br.ReadSingle();
                    value7[j].scl_y = br.ReadSingle();
                    value7[j].rot = br.ReadSingle();
                    value7[j].scl_accele = br.ReadSingle();
                    value7[j].rot_accele = br.ReadSingle();
                    br.BaseStream.Seek( 12L, SeekOrigin.Current );
                }
            }
            try
            {
                foreach ( KeyValuePair<int, AppMain.A2S_SUB_ANM[]> keyValuePair8 in AppMain.readAMAFile_subanmHash )
                {
                    br.BaseStream.Seek( ( long )keyValuePair8.Key, 0 );
                    AppMain.A2S_SUB_ANM[] value8 = keyValuePair8.Value;
                    int num13 = keyValuePair8.Value.Length;
                    for ( int k = 0; k < num13; k++ )
                    {
                        value8[k] = new AppMain.A2S_SUB_ANM();
                        value8[k].tex_id = br.ReadInt32();
                        value8[k].clamp = br.ReadUInt32();
                        value8[k].filter = br.ReadUInt32();
                        value8[k].texel_accele = br.ReadSingle();
                        value8[k].texel.left = br.ReadSingle();
                        value8[k].texel.top = br.ReadSingle();
                        value8[k].texel.right = br.ReadSingle();
                        value8[k].texel.bottom = br.ReadSingle();
                    }
                }
            }
            catch ( EndOfStreamException )
            {
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_MAT[]> keyValuePair9 in AppMain.readAMAFile_submatHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair9.Key, 0 );
                AppMain.A2S_SUB_MAT[] value9 = keyValuePair9.Value;
                int num14 = keyValuePair9.Value.Length - 1;
                for ( int l = 0; l < num14; l++ )
                {
                    value9[l] = new AppMain.A2S_SUB_MAT();
                    value9[l].base_.a = br.ReadByte();
                    value9[l].base_.b = br.ReadByte();
                    value9[l].base_.g = br.ReadByte();
                    value9[l].base_.r = br.ReadByte();
                    value9[l].fade.a = br.ReadByte();
                    value9[l].fade.b = br.ReadByte();
                    value9[l].fade.g = br.ReadByte();
                    value9[l].fade.r = br.ReadByte();
                    value9[l].base_accele = br.ReadSingle();
                    value9[l].fade_accele = br.ReadSingle();
                    value9[l].blend = br.ReadUInt32();
                    br.BaseStream.Seek( 12L, SeekOrigin.Current );
                }
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_ACM[]> keyValuePair10 in AppMain.readAMAFile_subacmHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair10.Key, 0 );
                AppMain.A2S_SUB_ACM[] value10 = keyValuePair10.Value;
                int num15 = keyValuePair10.Value.Length;
                for ( int m = 0; m < num15; m++ )
                {
                    value10[m] = default( AppMain.A2S_SUB_ACM );
                    value10[m].trs_scl_x = br.ReadSingle();
                    value10[m].trs_scl_y = br.ReadSingle();
                    value10[m].scl_x = br.ReadSingle();
                    value10[m].scl_y = br.ReadSingle();
                    value10[m].rot = br.ReadSingle();
                    value10[m].trs_scl_accele = br.ReadSingle();
                    value10[m].scl_accele = br.ReadSingle();
                    value10[m].rot_accele = br.ReadSingle();
                }
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_USR[]> keyValuePair11 in AppMain.readAMAFile_subusrHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair11.Key, 0 );
                AppMain.A2S_SUB_USR[] value11 = keyValuePair11.Value;
                int num16 = keyValuePair11.Value.Length;
                for ( int n = 0; n < num16; n++ )
                {
                    value11[n].usr_id = br.ReadUInt32();
                    br.BaseStream.Seek( 12L, SeekOrigin.Current );
                    value11[n].usr_accele = br.ReadSingle();
                    br.BaseStream.Seek( 12L, SeekOrigin.Current );
                }
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_HIT[]> keyValuePair12 in AppMain.readAMAFile_subhitHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair12.Key, 0 );
                AppMain.A2S_SUB_HIT[] value12 = keyValuePair12.Value;
                int num17 = keyValuePair12.Value.Length;
                for ( int num18 = 0; num18 < num17; num18++ )
                {
                    value12[num18] = new AppMain.A2S_SUB_HIT();
                    value12[num18].flag = br.ReadUInt32();
                    value12[num18].type = br.ReadUInt32();
                    value12[num18].hit_accele = br.ReadSingle();
                    value12[num18].pad = br.ReadUInt32();
                    value12[num18].rect.left = br.ReadSingle();
                    value12[num18].rect.top = br.ReadSingle();
                    value12[num18].rect.right = br.ReadSingle();
                    value12[num18].rect.bottom = br.ReadSingle();
                    value12[num18].circle.center_x = value12[num18].rect.left;
                    value12[num18].circle.radius = value12[num18].rect.right;
                    value12[num18].circle.pad = ( uint )value12[num18].rect.bottom;
                }
            }
            foreach ( KeyValuePair<int, AppMain.A2S_SUB_KEY[]> keyValuePair13 in AppMain.readAMAFile_subkeyHash )
            {
                br.BaseStream.Seek( ( long )keyValuePair13.Key, 0 );
                AppMain.A2S_SUB_KEY[] value13 = keyValuePair13.Value;
                int num19 = keyValuePair13.Value.Length;
                for ( int num20 = 0; num20 < num19; num20++ )
                {
                    value13[num20] = default( AppMain.A2S_SUB_KEY );
                    value13[num20].frm = br.ReadUInt32();
                    value13[num20].interpol = br.ReadUInt32();
                }
            }
        }
        AppMain.readAMAFile_nodeHash.Clear();
        AppMain.readAMAFile_actHash.Clear();
        AppMain.readAMAFile_mtnHash.Clear();
        AppMain.readAMAFile_anmHash.Clear();
        AppMain.readAMAFile_acmHash.Clear();
        AppMain.readAMAFile_usrHash.Clear();
        AppMain.readAMAFile_hitHash.Clear();
        AppMain.readAMAFile_subtrsHash.Clear();
        AppMain.readAMAFile_submtnHash.Clear();
        AppMain.readAMAFile_subanmHash.Clear();
        AppMain.readAMAFile_submatHash.Clear();
        AppMain.readAMAFile_subacmHash.Clear();
        AppMain.readAMAFile_subusrHash.Clear();
        AppMain.readAMAFile_subhitHash.Clear();
        AppMain.readAMAFile_subkeyHash.Clear();
        return a2S_AMA_HEADER;
    }
}