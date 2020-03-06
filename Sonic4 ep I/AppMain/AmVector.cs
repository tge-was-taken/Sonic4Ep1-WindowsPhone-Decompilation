using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class AppMain
{
    // Token: 0x0600199C RID: 6556 RVA: 0x000E847D File Offset: 0x000E667D
    public static void VEC3_COPY( AppMain.NNS_QUATERNION d_vec, AppMain.NNS_VECTOR s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.z = 0f;
    }

    // Token: 0x0600199D RID: 6557 RVA: 0x000E84B2 File Offset: 0x000E66B2
    public static void VEC3_COPY( AppMain.NNS_VECTOR d_vec, AppMain.NNS_VECTOR s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
    }

    // Token: 0x0600199E RID: 6558 RVA: 0x000E84D8 File Offset: 0x000E66D8
    public static void VEC4_COPY( AppMain.NNS_VECTOR d_vec, AppMain.NNS_VECTOR s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
    }

    // Token: 0x0600199F RID: 6559 RVA: 0x000E84FE File Offset: 0x000E66FE
    public static void VEC4_COPY( ref AppMain.SNNS_VECTOR4D d_vec, ref AppMain.SNNS_VECTOR4D s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.w = s_vec.w;
    }

    // Token: 0x060019A0 RID: 6560 RVA: 0x000E8530 File Offset: 0x000E6730
    public static void VEC4_COPY( ref AppMain.SNNS_VECTOR4D d_vec, AppMain.NNS_VECTOR4D s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.w = s_vec.w;
    }

    // Token: 0x060019A1 RID: 6561 RVA: 0x000E8562 File Offset: 0x000E6762
    public static void VEC4_COPY( AppMain.NNS_VECTOR4D d_vec, ref AppMain.NNS_QUATERNION s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.w = s_vec.w;
    }

    // Token: 0x060019A2 RID: 6562 RVA: 0x000E8594 File Offset: 0x000E6794
    public static void VEC4_COPY( ref AppMain.SNNS_VECTOR4D d_vec, ref AppMain.NNS_QUATERNION s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.w = s_vec.w;
    }

    // Token: 0x060019A3 RID: 6563 RVA: 0x000E85C6 File Offset: 0x000E67C6
    public static void VEC4_COPY( ref AppMain.NNS_QUATERNION d_vec, AppMain.NNS_VECTOR s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.w = 0f;
    }

    // Token: 0x060019A4 RID: 6564 RVA: 0x000E85F7 File Offset: 0x000E67F7
    public static void VEC4_COPY( ref AppMain.NNS_QUATERNION d_vec, ref AppMain.SNNS_VECTOR4D s_vec )
    {
        d_vec.x = s_vec.x;
        d_vec.y = s_vec.y;
        d_vec.z = s_vec.z;
        d_vec.w = s_vec.w;
    }

    // Token: 0x060019A5 RID: 6565 RVA: 0x000E8629 File Offset: 0x000E6829
    public static void VEC4_NEG( AppMain.NNS_VECTOR d_vec, AppMain.NNS_VECTOR s_vec )
    {
        d_vec.x = -s_vec.x;
        d_vec.y = -s_vec.y;
        d_vec.z = -s_vec.z;
    }

    // Token: 0x060019A6 RID: 6566 RVA: 0x000E8652 File Offset: 0x000E6852
    public void amVectorInit( AppMain.NNS_VECTOR pVec )
    {
        pVec.x = 0f;
        pVec.y = 0f;
        pVec.z = 0f;
    }

    // Token: 0x060019A7 RID: 6567 RVA: 0x000E8675 File Offset: 0x000E6875
    public static void amVectorInit( ref AppMain.SNNS_VECTOR4D pVec )
    {
        pVec.x = 0f;
        pVec.y = 0f;
        pVec.z = 0f;
        pVec.w = 1f;
    }

    // Token: 0x060019A8 RID: 6568 RVA: 0x000E86A3 File Offset: 0x000E68A3
    public static void amVectorInit( AppMain.NNS_VECTOR4D pVec )
    {
        pVec.x = 0f;
        pVec.y = 0f;
        pVec.z = 0f;
        pVec.w = 1f;
    }

    // Token: 0x060019A9 RID: 6569 RVA: 0x000E86D1 File Offset: 0x000E68D1
    public static void amVectorOne( ref AppMain.SNNS_VECTOR4D pVec )
    {
        pVec.x = 1f;
        pVec.y = 1f;
        pVec.z = 1f;
        pVec.w = 1f;
    }

    // Token: 0x060019AA RID: 6570 RVA: 0x000E86FF File Offset: 0x000E68FF
    public static void amVectorOne( AppMain.NNS_VECTOR4D pVec )
    {
        pVec.x = 1f;
        pVec.y = 1f;
        pVec.z = 1f;
        pVec.w = 1f;
    }

    // Token: 0x060019AB RID: 6571 RVA: 0x000E872D File Offset: 0x000E692D
    public static void amVectorSet( AppMain.NNS_PRIM3D_PC pDst, float x, float y, float z )
    {
        pDst.Pos.x = x;
        pDst.Pos.y = y;
        pDst.Pos.z = z;
    }

    // Token: 0x060019AC RID: 6572 RVA: 0x000E8756 File Offset: 0x000E6956
    public static void amVectorSet( ref AppMain.SNNS_VECTOR pDst, float x, float y, float z )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
    }

    // Token: 0x060019AD RID: 6573 RVA: 0x000E876D File Offset: 0x000E696D
    public static void amVectorSet( AppMain.NNS_VECTOR pDst, float x, float y, float z )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
    }

    // Token: 0x060019AE RID: 6574 RVA: 0x000E8784 File Offset: 0x000E6984
    public static void amVectorSet( AppMain.NNS_VECTOR2D pDst, float x, float y )
    {
        pDst.x = x;
        pDst.y = y;
    }

    // Token: 0x060019AF RID: 6575 RVA: 0x000E8794 File Offset: 0x000E6994
    public static void amVectorSet( out AppMain.SNNS_VECTOR4D pDst, float x, float y, float z )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
        pDst.w = 1f;
    }

    // Token: 0x060019B0 RID: 6576 RVA: 0x000E87B6 File Offset: 0x000E69B6
    public static void amVectorSet( ref AppMain.NNS_VECTOR4D pDst, float x, float y, float z )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
        pDst.w = 1f;
    }

    // Token: 0x060019B1 RID: 6577 RVA: 0x000E87DC File Offset: 0x000E69DC
    public static void amVectorSet( AppMain.NNS_VECTOR4D pDst, float x, float y, float z )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
        pDst.w = 1f;
    }

    // Token: 0x060019B2 RID: 6578 RVA: 0x000E87FE File Offset: 0x000E69FE
    public static void amVectorSet( AppMain.NNS_VECTOR4D pDst, float x, float y, float z, float w )
    {
        pDst.x = x;
        pDst.y = y;
        pDst.z = z;
        pDst.w = w;
    }

    // Token: 0x060019B3 RID: 6579 RVA: 0x000E881D File Offset: 0x000E6A1D
    public static void amVectorCopy( ref AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = pSrc.x;
        pDst.y = pSrc.y;
        pDst.z = pSrc.z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019B4 RID: 6580 RVA: 0x000E884F File Offset: 0x000E6A4F
    public static void amVectorCopy( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        pDst.x = pSrc.x;
        pDst.y = pSrc.y;
        pDst.z = pSrc.z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019B5 RID: 6581 RVA: 0x000E8881 File Offset: 0x000E6A81
    public static void amVectorCopy( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        pDst.x = pSrc.x;
        pDst.y = pSrc.y;
        pDst.z = pSrc.z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019B6 RID: 6582 RVA: 0x000E88B3 File Offset: 0x000E6AB3
    public static void amVectorCopy( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = pSrc.x;
        pDst.y = pSrc.y;
        pDst.z = pSrc.z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019B7 RID: 6583 RVA: 0x000E88E8 File Offset: 0x000E6AE8
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019B8 RID: 6584 RVA: 0x000E893C File Offset: 0x000E6B3C
    public static void amVectorAdd( out AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019B9 RID: 6585 RVA: 0x000E8990 File Offset: 0x000E6B90
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019BA RID: 6586 RVA: 0x000E89E4 File Offset: 0x000E6BE4
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019BB RID: 6587 RVA: 0x000E8A36 File Offset: 0x000E6C36
    public static void amVectorAdd( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019BC RID: 6588 RVA: 0x000E8A71 File Offset: 0x000E6C71
    public static void amVectorAdd( AppMain.NNS_VECTOR pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019BD RID: 6589 RVA: 0x000E8AAC File Offset: 0x000E6CAC
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019BE RID: 6590 RVA: 0x000E8AE8 File Offset: 0x000E6CE8
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019BF RID: 6591 RVA: 0x000E8B3C File Offset: 0x000E6D3C
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019C0 RID: 6592 RVA: 0x000E8B90 File Offset: 0x000E6D90
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019C1 RID: 6593 RVA: 0x000E8BE4 File Offset: 0x000E6DE4
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019C2 RID: 6594 RVA: 0x000E8C36 File Offset: 0x000E6E36
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR pDst, AppMain.NNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019C3 RID: 6595 RVA: 0x000E8C71 File Offset: 0x000E6E71
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR pDst, AppMain.NNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019C4 RID: 6596 RVA: 0x000E8CAC File Offset: 0x000E6EAC
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019C5 RID: 6597 RVA: 0x000E8CE7 File Offset: 0x000E6EE7
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019C6 RID: 6598 RVA: 0x000E8D22 File Offset: 0x000E6F22
    public static void amVectorAdd( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR pV2 )
    {
        pDst.x = pV1.x + pV2.x;
        pDst.y = pV1.y + pV2.y;
        pDst.z = pV1.z + pV2.z;
    }

    // Token: 0x060019C7 RID: 6599 RVA: 0x000E8D5D File Offset: 0x000E6F5D
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float x, float y, float z )
    {
        pDst.x = pSrc.x + x;
        pDst.y = pSrc.y + y;
        pDst.z = pSrc.z + z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019C8 RID: 6600 RVA: 0x000E8D96 File Offset: 0x000E6F96
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        pDst.x += pSrc.x;
        pDst.y += pSrc.y;
        pDst.z += pSrc.z;
    }

    // Token: 0x060019C9 RID: 6601 RVA: 0x000E8DD1 File Offset: 0x000E6FD1
    public static void amVectorAdd( ref AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x += pSrc.x;
        pDst.y += pSrc.y;
        pDst.z += pSrc.z;
    }

    // Token: 0x060019CA RID: 6602 RVA: 0x000E8E0C File Offset: 0x000E700C
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        pDst.x += pSrc.x;
        pDst.y += pSrc.y;
        pDst.z += pSrc.z;
    }

    // Token: 0x060019CB RID: 6603 RVA: 0x000E8E47 File Offset: 0x000E7047
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x += pSrc.x;
        pDst.y += pSrc.y;
        pDst.z += pSrc.z;
    }

    // Token: 0x060019CC RID: 6604 RVA: 0x000E8E82 File Offset: 0x000E7082
    public static void amVectorAdd( AppMain.NNS_VECTOR4D pDst, float x, float y, float z )
    {
        pDst.x += x;
        pDst.y += y;
        pDst.z += z;
    }

    // Token: 0x060019CD RID: 6605 RVA: 0x000E8EB0 File Offset: 0x000E70B0
    public static void amVectorSub( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x - pV2.x;
        pDst.y = pV1.y - pV2.y;
        pDst.z = pV1.z - pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019CE RID: 6606 RVA: 0x000E8F04 File Offset: 0x000E7104
    public static void amVectorSub( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x - pV2.x;
        pDst.y = pV1.y - pV2.y;
        pDst.z = pV1.z - pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019CF RID: 6607 RVA: 0x000E8F58 File Offset: 0x000E7158
    public static void amVectorSub( AppMain.NNS_VECTOR4D pDst, ref AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x - pV2.x;
        pDst.y = pV1.y - pV2.y;
        pDst.z = pV1.z - pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019D0 RID: 6608 RVA: 0x000E8FB0 File Offset: 0x000E71B0
    public static void amVectorSub( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x - pV2.x;
        pDst.y = pV1.y - pV2.y;
        pDst.z = pV1.z - pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019D1 RID: 6609 RVA: 0x000E9002 File Offset: 0x000E7202
    public static void amVectorSub( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float x, float y, float z )
    {
        pDst.x = pSrc.x - x;
        pDst.y = pSrc.y - y;
        pDst.z = pSrc.z - z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019D2 RID: 6610 RVA: 0x000E903B File Offset: 0x000E723B
    public static void amVectorSub( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x -= pSrc.x;
        pDst.y -= pSrc.y;
        pDst.z -= pSrc.z;
    }

    // Token: 0x060019D3 RID: 6611 RVA: 0x000E9076 File Offset: 0x000E7276
    public static void amVectorSub( AppMain.NNS_VECTOR4D pDst, float x, float y, float z )
    {
        pDst.x -= x;
        pDst.y -= y;
        pDst.z -= z;
    }

    // Token: 0x060019D4 RID: 6612 RVA: 0x000E90A4 File Offset: 0x000E72A4
    public static void amVectorGetInner( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR pV1, AppMain.NNS_VECTOR pV2, float per )
    {
        float num = 1f - per;
        pDst.x = pV1.x * num + pV2.x * per;
        pDst.y = pV1.y * num + pV2.y * per;
        pDst.z = pV1.z * num + pV2.z * per;
    }

    // Token: 0x060019D5 RID: 6613 RVA: 0x000E9100 File Offset: 0x000E7300
    public static void amVectorGetInner( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2, float per )
    {
        float num = 1f - per;
        pDst.x = pV1.x * num + pV2.x * per;
        pDst.y = pV1.y * num + pV2.y * per;
        pDst.z = pV1.z * num + pV2.z * per;
        pDst.w = pV1.w;
    }

    // Token: 0x060019D6 RID: 6614 RVA: 0x000E9168 File Offset: 0x000E7368
    public static void amVectorGetAverage( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2, float p1, float p2 )
    {
        pDst.x = pV1.x * p1 + pV2.x * p2;
        pDst.y = pV1.y * p1 + pV2.y * p2;
        pDst.z = pV1.z * p1 + pV2.z * p2;
        pDst.w = pV1.w;
    }

    // Token: 0x060019D7 RID: 6615 RVA: 0x000E91CC File Offset: 0x000E73CC
    public static void amVectorGetAverage( ref AppMain.SNNS_VECTOR pDst, ref AppMain.SNNS_VECTOR pV1, ref AppMain.SNNS_VECTOR pV2, float p1, float p2 )
    {
        pDst.x = pV1.x * p1 + pV2.x * p2;
        pDst.y = pV1.y * p1 + pV2.y * p2;
        pDst.z = pV1.z * p1 + pV2.z * p2;
    }

    // Token: 0x060019D8 RID: 6616 RVA: 0x000E9224 File Offset: 0x000E7424
    public static void amVectorGetAverage( ref AppMain.SNNS_VECTOR pDst, ref AppMain.SNNS_VECTOR pV1, AppMain.NNS_VECTOR pV2, float p1, float p2 )
    {
        pDst.x = pV1.x * p1 + pV2.x * p2;
        pDst.y = pV1.y * p1 + pV2.y * p2;
        pDst.z = pV1.z * p1 + pV2.z * p2;
    }

    // Token: 0x060019D9 RID: 6617 RVA: 0x000E927C File Offset: 0x000E747C
    public static void amVectorGetAverage( ref AppMain.SNNS_VECTOR pDst, AppMain.NNS_VECTOR pV1, AppMain.NNS_VECTOR pV2, float p1, float p2 )
    {
        pDst.x = pV1.x * p1 + pV2.x * p2;
        pDst.y = pV1.y * p1 + pV2.y * p2;
        pDst.z = pV1.z * p1 + pV2.z * p2;
    }

    // Token: 0x060019DA RID: 6618 RVA: 0x000E92D4 File Offset: 0x000E74D4
    public static void amVectorGetAverage( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR pV1, AppMain.NNS_VECTOR pV2, float p1, float p2 )
    {
        pDst.x = pV1.x * p1 + pV2.x * p2;
        pDst.y = pV1.y * p1 + pV2.y * p2;
        pDst.z = pV1.z * p1 + pV2.z * p2;
    }

    // Token: 0x060019DB RID: 6619 RVA: 0x000E932C File Offset: 0x000E752C
    public static float amVectorGetLength( AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        float n_ = pV1.x - pV2.x;
        float n_2 = pV1.y - pV2.y;
        float n_3 = pV1.z - pV2.z;
        return AppMain.amSqrt( AppMain.amPow2( n_ ) + AppMain.amPow2( n_2 ) + AppMain.amPow2( n_3 ) );
    }

    // Token: 0x060019DC RID: 6620 RVA: 0x000E9380 File Offset: 0x000E7580
    public static float amVectorGetLength2( AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        float n_ = pV1.x - pV2.x;
        float n_2 = pV1.y - pV2.y;
        float n_3 = pV1.z - pV2.z;
        return AppMain.amPow2( n_ ) + AppMain.amPow2( n_2 ) + AppMain.amPow2( n_3 );
    }

    // Token: 0x060019DD RID: 6621 RVA: 0x000E93D0 File Offset: 0x000E75D0
    public static float amVectorScalor( AppMain.NNS_VECTOR4D pVec )
    {
        return AppMain.amSqrt( AppMain.amPow2( pVec.x ) + AppMain.amPow2( pVec.y ) + AppMain.amPow2( pVec.z ) );
    }

    // Token: 0x060019DE RID: 6622 RVA: 0x000E9408 File Offset: 0x000E7608
    public static float amVectorScalor( ref AppMain.SNNS_VECTOR4D pVec )
    {
        return AppMain.amSqrt( AppMain.amPow2( pVec.x ) + AppMain.amPow2( pVec.y ) + AppMain.amPow2( pVec.z ) );
    }

    // Token: 0x060019DF RID: 6623 RVA: 0x000E9440 File Offset: 0x000E7640
    public static float amVectorScalor2( AppMain.NNS_VECTOR4D pVec )
    {
        return AppMain.amPow2( pVec.x ) + AppMain.amPow2( pVec.y ) + AppMain.amPow2( pVec.z );
    }

    // Token: 0x060019E0 RID: 6624 RVA: 0x000E9474 File Offset: 0x000E7674
    public static float amVectorScaleUnit( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float len )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pSrc.x) + AppMain.amPow2(pSrc.y) + AppMain.amPow2(pSrc.z));
        AppMain.amVectorCopy( pDst, pSrc );
        if ( !AppMain.amIsZerof( num ) )
        {
            len /= num;
            pDst.x *= len;
            pDst.y *= len;
            pDst.z *= len;
        }
        return num;
    }

    // Token: 0x060019E1 RID: 6625 RVA: 0x000E94EC File Offset: 0x000E76EC
    public static float amVectorScaleUnit( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc, float len )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pSrc.x) + AppMain.amPow2(pSrc.y) + AppMain.amPow2(pSrc.z));
        AppMain.amVectorCopy( ref pDst, ref pSrc );
        if ( !AppMain.amIsZerof( num ) )
        {
            len /= num;
            pDst.x *= len;
            pDst.y *= len;
            pDst.z *= len;
        }
        return num;
    }

    // Token: 0x060019E2 RID: 6626 RVA: 0x000E9564 File Offset: 0x000E7764
    public static float amVectorScaleUnit( AppMain.NNS_VECTOR4D pDst, float len )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pDst.x) + AppMain.amPow2(pDst.y) + AppMain.amPow2(pDst.z));
        if ( !AppMain.amIsZerof( num ) )
        {
            len /= num;
            pDst.x *= len;
            pDst.y *= len;
            pDst.z *= len;
        }
        return num;
    }

    // Token: 0x060019E3 RID: 6627 RVA: 0x000E95D2 File Offset: 0x000E77D2
    public static void amVectorScale( ref AppMain.SNNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc, float sc )
    {
        pDst.x = pSrc.x * sc;
        pDst.y = pSrc.y * sc;
        pDst.z = pSrc.z * sc;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019E4 RID: 6628 RVA: 0x000E960A File Offset: 0x000E780A
    public static void amVectorScale( ref AppMain.SNNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float sc )
    {
        pDst.x = pSrc.x * sc;
        pDst.y = pSrc.y * sc;
        pDst.z = pSrc.z * sc;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019E5 RID: 6629 RVA: 0x000E9642 File Offset: 0x000E7842
    public static void amVectorScale( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pSrc, float sc )
    {
        pDst.x = pSrc.x * sc;
        pDst.y = pSrc.y * sc;
        pDst.z = pSrc.z * sc;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019E6 RID: 6630 RVA: 0x000E967A File Offset: 0x000E787A
    public static void amVectorScale( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float sc )
    {
        pDst.x = pSrc.x * sc;
        pDst.y = pSrc.y * sc;
        pDst.z = pSrc.z * sc;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019E7 RID: 6631 RVA: 0x000E96B2 File Offset: 0x000E78B2
    public void amVectorScale( AppMain.NNS_VECTOR4D pDst, float sc )
    {
        pDst.x *= sc;
        pDst.y *= sc;
        pDst.z *= sc;
    }

    // Token: 0x060019E8 RID: 6632 RVA: 0x000E96E0 File Offset: 0x000E78E0
    public static float amVectorUnit( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pSrc.x) + AppMain.amPow2(pSrc.y) + AppMain.amPow2(pSrc.z));
        AppMain.nnCopyVector( pDst, pSrc );
        if ( !AppMain.amIsZerof( num ) )
        {
            float num2 = 1f / num;
            pDst.x *= num2;
            pDst.y *= num2;
            pDst.z *= num2;
        }
        return num;
    }

    // Token: 0x060019E9 RID: 6633 RVA: 0x000E9758 File Offset: 0x000E7958
    public static float amVectorUnit( AppMain.NNS_VECTOR pDst, ref AppMain.SNNS_VECTOR4D pSrc )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pSrc.x) + AppMain.amPow2(pSrc.y) + AppMain.amPow2(pSrc.z));
        AppMain.nnCopyVector( pDst, ref pSrc );
        if ( !AppMain.amIsZerof( num ) )
        {
            float num2 = 1f / num;
            pDst.x *= num2;
            pDst.y *= num2;
            pDst.z *= num2;
        }
        return num;
    }

    // Token: 0x060019EA RID: 6634 RVA: 0x000E97D0 File Offset: 0x000E79D0
    public static float amVectorUnit( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.w = pSrc.w;
        return AppMain.amVectorUnit( pDst, pSrc );
    }

    // Token: 0x060019EB RID: 6635 RVA: 0x000E97E8 File Offset: 0x000E79E8
    public static float amVectorUnit( AppMain.NNS_VECTOR4D pDst )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pDst.x) + AppMain.amPow2(pDst.y) + AppMain.amPow2(pDst.z));
        if ( !AppMain.amIsZerof( num ) )
        {
            float num2 = 1f / num;
            pDst.x *= num2;
            pDst.y *= num2;
            pDst.z *= num2;
        }
        return num;
    }

    // Token: 0x060019EC RID: 6636 RVA: 0x000E985C File Offset: 0x000E7A5C
    public static float amVectorUnit( ref AppMain.NNS_VECTOR4D pDst )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pDst.x) + AppMain.amPow2(pDst.y) + AppMain.amPow2(pDst.z));
        if ( !AppMain.amIsZerof( num ) )
        {
            float num2 = 1f / num;
            pDst.x *= num2;
            pDst.y *= num2;
            pDst.z *= num2;
        }
        return num;
    }

    // Token: 0x060019ED RID: 6637 RVA: 0x000E98D4 File Offset: 0x000E7AD4
    public static float amVectorUnit( ref AppMain.SNNS_VECTOR4D pDst )
    {
        float num = AppMain.amSqrt(AppMain.amPow2(pDst.x) + AppMain.amPow2(pDst.y) + AppMain.amPow2(pDst.z));
        if ( !AppMain.amIsZerof( num ) )
        {
            float num2 = 1f / num;
            pDst.x *= num2;
            pDst.y *= num2;
            pDst.z *= num2;
        }
        return num;
    }

    // Token: 0x060019EE RID: 6638 RVA: 0x000E9945 File Offset: 0x000E7B45
    public void amVectorInvert( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = -pSrc.x;
        pDst.y = -pSrc.y;
        pDst.z = -pSrc.z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019EF RID: 6639 RVA: 0x000E997A File Offset: 0x000E7B7A
    public void amVectorInvert( AppMain.NNS_VECTOR pDst, AppMain.NNS_VECTOR pSrc )
    {
        pDst.x = -pSrc.x;
        pDst.y = -pSrc.y;
        pDst.z = -pSrc.z;
    }

    // Token: 0x060019F0 RID: 6640 RVA: 0x000E99A3 File Offset: 0x000E7BA3
    public void amVectorInvert( AppMain.NNS_VECTOR4D pVec )
    {
        pVec.x = -pVec.x;
        pVec.y = -pVec.y;
        pVec.z = -pVec.z;
    }

    // Token: 0x060019F1 RID: 6641 RVA: 0x000E99CC File Offset: 0x000E7BCC
    public void amVectorInvert( AppMain.NNS_VECTOR pVec )
    {
        pVec.x = -pVec.x;
        pVec.y = -pVec.y;
        pVec.z = -pVec.z;
    }

    // Token: 0x060019F2 RID: 6642 RVA: 0x000E99F5 File Offset: 0x000E7BF5
    public float amVectorInnerProduct( AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        return pV1.x * pV2.x + pV1.y * pV2.y + pV1.z * pV2.z;
    }

    // Token: 0x060019F3 RID: 6643 RVA: 0x000E9A20 File Offset: 0x000E7C20
    public static void amVectorOuterProduct( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        AppMain.amVectorSet( pDst, pV1.y * pV2.z - pV1.z * pV2.y, pV1.z * pV2.x - pV1.x * pV2.z, pV1.x * pV2.y - pV1.y * pV2.x );
    }

    // Token: 0x060019F4 RID: 6644 RVA: 0x000E9A84 File Offset: 0x000E7C84
    public static void amVectorOuterProduct( AppMain.NNS_VECTOR4D pDst, ref AppMain.SNNS_VECTOR4D pV1, ref AppMain.SNNS_VECTOR4D pV2 )
    {
        AppMain.amVectorSet( pDst, pV1.y * pV2.z - pV1.z * pV2.y, pV1.z * pV2.x - pV1.x * pV2.z, pV1.x * pV2.y - pV1.y * pV2.x );
    }

    // Token: 0x060019F5 RID: 6645 RVA: 0x000E9AE8 File Offset: 0x000E7CE8
    public void amVectorMul( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = pV1.x * pV2.x;
        pDst.y = pV1.y * pV2.y;
        pDst.z = pV1.z * pV2.z;
        pDst.w = pV1.w;
    }

    // Token: 0x060019F6 RID: 6646 RVA: 0x000E9B3A File Offset: 0x000E7D3A
    public void amVectorMul( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x *= pSrc.x;
        pDst.y *= pSrc.y;
        pDst.z *= pSrc.z;
    }

    // Token: 0x060019F7 RID: 6647 RVA: 0x000E9B75 File Offset: 0x000E7D75
    public void amVectorMul( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float x, float y, float z )
    {
        pDst.x = pSrc.x * x;
        pDst.y = pSrc.y * y;
        pDst.z = pSrc.z * z;
        pDst.w = pSrc.w;
    }

    // Token: 0x060019F8 RID: 6648 RVA: 0x000E9BAF File Offset: 0x000E7DAF
    public void amVectorMul( AppMain.NNS_VECTOR4D pDst, float x, float y, float z )
    {
        pDst.x *= x;
        pDst.y *= y;
        pDst.z *= z;
    }

    // Token: 0x060019F9 RID: 6649 RVA: 0x000E9BDC File Offset: 0x000E7DDC
    public void amVectorMax( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = AppMain.amMax<float>( pV1.x, pV2.x );
        pDst.y = AppMain.amMax<float>( pV1.y, pV2.y );
        pDst.z = AppMain.amMax<float>( pV1.z, pV2.z );
        pDst.w = pV1.w;
    }

    // Token: 0x060019FA RID: 6650 RVA: 0x000E9C3C File Offset: 0x000E7E3C
    public void amVectorMax( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float val )
    {
        pDst.x = AppMain.amMax<float>( pSrc.x, val );
        pDst.y = AppMain.amMax<float>( pSrc.y, val );
        pDst.z = AppMain.amMax<float>( pSrc.z, val );
        pDst.w = pSrc.w;
    }

    // Token: 0x060019FB RID: 6651 RVA: 0x000E9C8C File Offset: 0x000E7E8C
    public void amVectorMax( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = AppMain.amMax<float>( pDst.x, pSrc.x );
        pDst.y = AppMain.amMax<float>( pDst.y, pSrc.y );
        pDst.z = AppMain.amMax<float>( pDst.z, pSrc.z );
    }

    // Token: 0x060019FC RID: 6652 RVA: 0x000E9CDE File Offset: 0x000E7EDE
    public void amVectorMax( AppMain.NNS_VECTOR4D pDst, float val )
    {
        pDst.x = AppMain.amMax<float>( pDst.x, val );
        pDst.y = AppMain.amMax<float>( pDst.y, val );
        pDst.z = AppMain.amMax<float>( pDst.z, val );
    }

    // Token: 0x060019FD RID: 6653 RVA: 0x000E9D18 File Offset: 0x000E7F18
    public void amVectorMin( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        pDst.x = AppMain.amMin<float>( pV1.x, pV2.x );
        pDst.y = AppMain.amMin<float>( pV1.y, pV2.y );
        pDst.z = AppMain.amMin<float>( pV1.z, pV2.z );
        pDst.w = pV1.w;
    }

    // Token: 0x060019FE RID: 6654 RVA: 0x000E9D78 File Offset: 0x000E7F78
    public void amVectorMin( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float val )
    {
        pDst.x = AppMain.amMin<float>( pSrc.x, val );
        pDst.y = AppMain.amMin<float>( pSrc.y, val );
        pDst.z = AppMain.amMin<float>( pSrc.z, val );
        pDst.w = pSrc.w;
    }

    // Token: 0x060019FF RID: 6655 RVA: 0x000E9DC8 File Offset: 0x000E7FC8
    public void amVectorMin( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = AppMain.amMin<float>( pDst.x, pSrc.x );
        pDst.y = AppMain.amMin<float>( pDst.y, pSrc.y );
        pDst.z = AppMain.amMin<float>( pDst.z, pSrc.z );
    }

    // Token: 0x06001A00 RID: 6656 RVA: 0x000E9E1A File Offset: 0x000E801A
    public void amVectorMin( AppMain.NNS_VECTOR4D pDst, float val )
    {
        pDst.x = AppMain.amMin<float>( pDst.x, val );
        pDst.y = AppMain.amMin<float>( pDst.y, val );
        pDst.z = AppMain.amMin<float>( pDst.z, val );
    }

    // Token: 0x06001A01 RID: 6657 RVA: 0x000E9E54 File Offset: 0x000E8054
    public void amVectorClamp( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, AppMain.NNS_VECTOR4D pMin, AppMain.NNS_VECTOR4D pMax )
    {
        pDst.x = AppMain.amClamp( pSrc.x, pMin.x, pMax.x );
        pDst.y = AppMain.amClamp( pSrc.y, pMin.y, pMax.y );
        pDst.z = AppMain.amClamp( pSrc.z, pMin.z, pMax.z );
        pDst.w = pSrc.w;
    }

    // Token: 0x06001A02 RID: 6658 RVA: 0x000E9EC8 File Offset: 0x000E80C8
    public void amVectorClamp( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pSrc, float min, float max )
    {
        pDst.x = AppMain.amClamp( pSrc.x, min, max );
        pDst.y = AppMain.amClamp( pSrc.y, min, max );
        pDst.z = AppMain.amClamp( pSrc.z, min, max );
        pDst.w = pSrc.w;
    }

    // Token: 0x06001A03 RID: 6659 RVA: 0x000E9F20 File Offset: 0x000E8120
    public void amVectorClamp( AppMain.NNS_VECTOR4D pDst, AppMain.NNS_VECTOR4D pMin, AppMain.NNS_VECTOR4D pMax )
    {
        pDst.x = AppMain.amClamp( pDst.x, pMin.x, pMax.x );
        pDst.y = AppMain.amClamp( pDst.y, pMin.y, pMax.y );
        pDst.z = AppMain.amClamp( pDst.z, pMin.z, pMax.z );
    }

    // Token: 0x06001A04 RID: 6660 RVA: 0x000E9F84 File Offset: 0x000E8184
    public void amVectorClamp( AppMain.NNS_VECTOR4D pDst, float min, float max )
    {
        pDst.x = AppMain.amClamp( pDst.x, min, max );
        pDst.y = AppMain.amClamp( pDst.y, min, max );
        pDst.z = AppMain.amClamp( pDst.z, min, max );
    }

    // Token: 0x06001A05 RID: 6661 RVA: 0x000E9FC0 File Offset: 0x000E81C0
    public void amVectorCeil( AppMain.AMS_VECTOR4I pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = ( int )Math.Ceiling( ( double )pSrc.x );
        pDst.y = ( int )Math.Ceiling( ( double )pSrc.y );
        pDst.z = ( int )Math.Ceiling( ( double )pSrc.z );
        pDst.w = ( int )Math.Ceiling( ( double )pSrc.w );
    }

    // Token: 0x06001A06 RID: 6662 RVA: 0x000EA020 File Offset: 0x000E8220
    public void amVectorTrunc( AppMain.AMS_VECTOR4I pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = ( int )( ( pSrc.x >= 0f ) ? Math.Floor( ( double )pSrc.x ) : ( -( int )Math.Floor( ( double )( -( double )pSrc.x ) ) ) );
        pDst.y = ( int )( ( pSrc.y >= 0f ) ? Math.Floor( ( double )pSrc.y ) : ( -( int )Math.Floor( ( double )( -( double )pSrc.y ) ) ) );
        pDst.z = ( int )( ( pSrc.z >= 0f ) ? Math.Floor( ( double )pSrc.z ) : ( -( int )Math.Floor( ( double )( -( double )pSrc.z ) ) ) );
        pDst.w = ( int )( ( pSrc.w >= 0f ) ? Math.Floor( ( double )pSrc.w ) : ( -( int )Math.Floor( ( double )( -( double )pSrc.w ) ) ) );
    }

    // Token: 0x06001A07 RID: 6663 RVA: 0x000EA0F4 File Offset: 0x000E82F4
    public void amVectorFloor( AppMain.AMS_VECTOR4I pDst, AppMain.NNS_VECTOR4D pSrc )
    {
        pDst.x = ( int )Math.Floor( ( double )pSrc.x );
        pDst.y = ( int )Math.Floor( ( double )pSrc.y );
        pDst.z = ( int )Math.Floor( ( double )pSrc.z );
        pDst.w = ( int )Math.Floor( ( double )pSrc.w );
    }

    // Token: 0x06001A08 RID: 6664 RVA: 0x000EA151 File Offset: 0x000E8351
    public void amVectorIntToFloat( AppMain.NNS_VECTOR4D pDst, AppMain.AMS_VECTOR4I pSrc )
    {
        pDst.x = ( float )pSrc.x;
        pDst.y = ( float )pSrc.y;
        pDst.z = ( float )pSrc.z;
        pDst.w = ( float )pSrc.w;
    }

    // Token: 0x06001A09 RID: 6665 RVA: 0x000EA18B File Offset: 0x000E838B
    public static void amVectorRandom( ref AppMain.SNNS_VECTOR4D pDst )
    {
        AppMain.amVectorSet( out pDst, AppMain.nnRandom() - 0.5f, AppMain.nnRandom() - 0.5f, AppMain.nnRandom() - 0.5f );
        AppMain.amVectorUnit( ref pDst );
    }

    // Token: 0x06001A0A RID: 6666 RVA: 0x000EA1BB File Offset: 0x000E83BB
    public static void amVectorRandom( AppMain.NNS_VECTOR4D pDst )
    {
        AppMain.amVectorSet( pDst, AppMain.nnRandom() - 0.5f, AppMain.nnRandom() - 0.5f, AppMain.nnRandom() - 0.5f );
        AppMain.amVectorUnit( pDst );
    }

    // Token: 0x06001A0B RID: 6667 RVA: 0x000EA1EB File Offset: 0x000E83EB
    public uint amVectorCmp( AppMain.NNS_VECTOR4D pV1, AppMain.NNS_VECTOR4D pV2 )
    {
        if ( pV1.x == pV2.x && pV1.y == pV2.y && pV1.z == pV2.z && pV1.w == pV2.w )
        {
            return 1U;
        }
        return 0U;
    }
}