using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Runtime.InteropServices;

public partial class AppMain
{
    // Token: 0x02000006 RID: 6
    private static class nnnodestatuslist
    {
        // Token: 0x04004742 RID: 18242
        public static AppMain.NNS_MATRIX[] nnsMtxPal;

        // Token: 0x04004743 RID: 18243
        public static uint[] nnsNodeStatList;

        // Token: 0x04004744 RID: 18244
        public static uint nnsNSFlag = 0U;

        // Token: 0x04004745 RID: 18245
        public static AppMain.NNS_NODE[] nnsNodeList;
    }

    // Token: 0x02000007 RID: 7
    public class NNS_NODE
    {
        // Token: 0x1700006A RID: 106
        // (get) Token: 0x06001CDC RID: 7388 RVA: 0x0013596E File Offset: 0x00133B6E
        // (set) Token: 0x06001CDD RID: 7389 RVA: 0x00135976 File Offset: 0x00133B76
        public float BoundingBoxX
        {
            get
            {
                return this.SIIKBoneLength;
            }
            set
            {
                this.SIIKBoneLength = value;
            }
        }

        // Token: 0x06001CDE RID: 7390 RVA: 0x0013597F File Offset: 0x00133B7F
        public NNS_NODE()
        {
        }

        // Token: 0x06001CDF RID: 7391 RVA: 0x001359B4 File Offset: 0x00133BB4
        public NNS_NODE( AppMain.NNS_NODE node )
        {
            this.fType = node.fType;
            this.iMatrix = node.iMatrix;
            this.iParent = node.iParent;
            this.iChild = node.iChild;
            this.iSibling = node.iSibling;
            this.Translation.Assign( node.Translation );
            this.Rotation = node.Rotation;
            this.Scaling.Assign( node.Scaling );
            this.InvInitMtx.Assign( node.InvInitMtx );
            this.Center.Assign( node.Center );
            this.Radius = node.Radius;
            this.User = node.User;
            this.SIIKBoneLength = node.SIIKBoneLength;
            this.BoundingBoxY = node.BoundingBoxY;
            this.BoundingBoxZ = node.BoundingBoxZ;
        }

        // Token: 0x06001CE0 RID: 7392 RVA: 0x00135AC0 File Offset: 0x00133CC0
        public AppMain.NNS_NODE Assign( AppMain.NNS_NODE node )
        {
            if ( this != node )
            {
                this.fType = node.fType;
                this.iMatrix = node.iMatrix;
                this.iParent = node.iParent;
                this.iChild = node.iChild;
                this.iSibling = node.iSibling;
                this.Translation.Assign( node.Translation );
                this.Rotation = node.Rotation;
                this.Scaling.Assign( node.Scaling );
                this.InvInitMtx.Assign( node.InvInitMtx );
                this.Center.Assign( node.Center );
                this.Radius = node.Radius;
                this.User = node.User;
                this.SIIKBoneLength = node.SIIKBoneLength;
                this.BoundingBoxY = node.BoundingBoxY;
                this.BoundingBoxZ = node.BoundingBoxZ;
            }
            return this;
        }

        // Token: 0x06001CE1 RID: 7393 RVA: 0x00135BA4 File Offset: 0x00133DA4
        public static AppMain.NNS_NODE Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_NODE nns_NODE = new AppMain.NNS_NODE();
            nns_NODE.fType = reader.ReadUInt32();
            nns_NODE.iMatrix = reader.ReadInt16();
            nns_NODE.iParent = reader.ReadInt16();
            nns_NODE.iChild = reader.ReadInt16();
            nns_NODE.iSibling = reader.ReadInt16();
            nns_NODE.Translation.x = reader.ReadSingle();
            nns_NODE.Translation.y = reader.ReadSingle();
            nns_NODE.Translation.z = reader.ReadSingle();
            nns_NODE.Rotation.x = reader.ReadInt32();
            nns_NODE.Rotation.y = reader.ReadInt32();
            nns_NODE.Rotation.z = reader.ReadInt32();
            nns_NODE.Scaling.x = reader.ReadSingle();
            nns_NODE.Scaling.y = reader.ReadSingle();
            nns_NODE.Scaling.z = reader.ReadSingle();
            nns_NODE.InvInitMtx.M00 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M10 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M20 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M30 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M01 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M11 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M21 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M31 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M02 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M12 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M22 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M32 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M03 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M13 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M23 = reader.ReadSingle();
            nns_NODE.InvInitMtx.M33 = reader.ReadSingle();
            nns_NODE.Center.x = reader.ReadSingle();
            nns_NODE.Center.y = reader.ReadSingle();
            nns_NODE.Center.z = reader.ReadSingle();
            nns_NODE.Radius = reader.ReadSingle();
            nns_NODE.User = reader.ReadUInt32();
            nns_NODE.BoundingBoxX = reader.ReadSingle();
            nns_NODE.BoundingBoxY = reader.ReadSingle();
            nns_NODE.BoundingBoxZ = reader.ReadSingle();
            return nns_NODE;
        }

        // Token: 0x04004746 RID: 18246
        public uint fType;

        // Token: 0x04004747 RID: 18247
        public short iMatrix;

        // Token: 0x04004748 RID: 18248
        public short iParent;

        // Token: 0x04004749 RID: 18249
        public short iChild;

        // Token: 0x0400474A RID: 18250
        public short iSibling;

        // Token: 0x0400474B RID: 18251
        public readonly AppMain.NNS_VECTOR Translation = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400474C RID: 18252
        public AppMain.NNS_ROTATE_A32 Rotation;

        // Token: 0x0400474D RID: 18253
        public readonly AppMain.NNS_VECTOR Scaling = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400474E RID: 18254
        public readonly AppMain.NNS_MATRIX InvInitMtx = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();

        // Token: 0x0400474F RID: 18255
        public readonly AppMain.NNS_VECTOR Center = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004750 RID: 18256
        public float Radius;

        // Token: 0x04004751 RID: 18257
        public uint User;

        // Token: 0x04004752 RID: 18258
        public float SIIKBoneLength;

        // Token: 0x04004753 RID: 18259
        public float BoundingBoxY;

        // Token: 0x04004754 RID: 18260
        public float BoundingBoxZ;
    }

    // Token: 0x02000008 RID: 8
    public class NNS_NODENAME
    {
        // Token: 0x06001CE2 RID: 7394 RVA: 0x00135E0C File Offset: 0x0013400C
        public NNS_NODENAME()
        {
        }

        // Token: 0x06001CE3 RID: 7395 RVA: 0x00135E14 File Offset: 0x00134014
        public NNS_NODENAME( AppMain.NNS_NODENAME nodeName )
        {
            this.iNode = nodeName.iNode;
            this.Name = nodeName.Name;
        }

        // Token: 0x06001CE4 RID: 7396 RVA: 0x00135E34 File Offset: 0x00134034
        public AppMain.NNS_NODENAME Assign( AppMain.NNS_NODENAME nodeName )
        {
            this.iNode = nodeName.iNode;
            this.Name = nodeName.Name;
            return this;
        }

        // Token: 0x04004755 RID: 18261
        public int iNode;

        // Token: 0x04004756 RID: 18262
        public string Name;
    }

    // Token: 0x02000009 RID: 9
    public enum NNE_NODENAME_SORTTYPE
    {
        // Token: 0x04004758 RID: 18264
        NNE_NODENAME_SORTTYPE_INDEX,
        // Token: 0x04004759 RID: 18265
        NNE_NODENAME_SORTTYPE_NAME
    }

    // Token: 0x0200000A RID: 10
    public class NNS_NODENAMELIST
    {
        // Token: 0x06001CE5 RID: 7397 RVA: 0x00135E4F File Offset: 0x0013404F
        public NNS_NODENAMELIST()
        {
        }

        // Token: 0x06001CE6 RID: 7398 RVA: 0x00135E57 File Offset: 0x00134057
        public NNS_NODENAMELIST( AppMain.NNS_NODENAMELIST nodeNameList )
        {
            this.SortType = nodeNameList.SortType;
            this.nNode = nodeNameList.nNode;
            this.pNodeNameList = nodeNameList.pNodeNameList;
        }

        // Token: 0x06001CE7 RID: 7399 RVA: 0x00135E83 File Offset: 0x00134083
        public AppMain.NNS_NODENAMELIST Assign( AppMain.NNS_NODENAMELIST nodeNameList )
        {
            if ( this != nodeNameList )
            {
                this.SortType = nodeNameList.SortType;
                this.nNode = nodeNameList.nNode;
                this.pNodeNameList = nodeNameList.pNodeNameList;
            }
            return this;
        }

        // Token: 0x0400475A RID: 18266
        public AppMain.NNE_NODENAME_SORTTYPE SortType;

        // Token: 0x0400475B RID: 18267
        public int nNode;

        // Token: 0x0400475C RID: 18268
        public AppMain.NNS_NODENAME[] pNodeNameList;
    }

    // Token: 0x0200000B RID: 11
    public class NNS_MATERIALNAME
    {
        // Token: 0x06001CE8 RID: 7400 RVA: 0x00135EAE File Offset: 0x001340AE
        public NNS_MATERIALNAME()
        {
        }

        // Token: 0x06001CE9 RID: 7401 RVA: 0x00135EB6 File Offset: 0x001340B6
        public NNS_MATERIALNAME( AppMain.NNS_MATERIALNAME materialName )
        {
            this.iMaterial = materialName.iMaterial;
            this.Name = materialName.Name;
        }

        // Token: 0x06001CEA RID: 7402 RVA: 0x00135ED6 File Offset: 0x001340D6
        public AppMain.NNS_MATERIALNAME Assign( AppMain.NNS_MATERIALNAME materialName )
        {
            this.iMaterial = materialName.iMaterial;
            this.Name = materialName.Name;
            return this;
        }

        // Token: 0x0400475D RID: 18269
        public int iMaterial;

        // Token: 0x0400475E RID: 18270
        public string Name;
    }

    // Token: 0x0200000C RID: 12
    public enum NNE_MATERIALNAME_SORTTYPE
    {
        // Token: 0x04004760 RID: 18272
        NNE_MATERIALNAME_SORTTYPE_INDEX,
        // Token: 0x04004761 RID: 18273
        NNE_MATERIALNAME_SORTTYPE_NAME
    }

    // Token: 0x0200000D RID: 13
    public class NNS_MATERIALNAMELIST
    {
        // Token: 0x06001CEB RID: 7403 RVA: 0x00135EF1 File Offset: 0x001340F1
        public NNS_MATERIALNAMELIST()
        {
        }

        // Token: 0x06001CEC RID: 7404 RVA: 0x00135EF9 File Offset: 0x001340F9
        public NNS_MATERIALNAMELIST( AppMain.NNS_MATERIALNAMELIST materialNameList )
        {
            this.SortType = materialNameList.SortType;
            this.nMaterial = materialNameList.nMaterial;
            this.pMaterialNameList = materialNameList.pMaterialNameList;
        }

        // Token: 0x06001CED RID: 7405 RVA: 0x00135F25 File Offset: 0x00134125
        public AppMain.NNS_MATERIALNAMELIST Assign( AppMain.NNS_MATERIALNAMELIST materialNameList )
        {
            if ( this != materialNameList )
            {
                this.SortType = materialNameList.SortType;
                this.nMaterial = materialNameList.nMaterial;
                this.pMaterialNameList = materialNameList.pMaterialNameList;
            }
            return this;
        }

        // Token: 0x04004762 RID: 18274
        public AppMain.NNE_MATERIALNAME_SORTTYPE SortType;

        // Token: 0x04004763 RID: 18275
        public int nMaterial;

        // Token: 0x04004764 RID: 18276
        public AppMain.NNS_MATERIALNAME[] pMaterialNameList;
    }

    // Token: 0x0200000E RID: 14
    public class NNS_VTXLISTPTR
    {
        // Token: 0x06001CEE RID: 7406 RVA: 0x00135F50 File Offset: 0x00134150
        public NNS_VTXLISTPTR()
        {
        }

        // Token: 0x06001CEF RID: 7407 RVA: 0x00135F58 File Offset: 0x00134158
        public NNS_VTXLISTPTR( AppMain.NNS_VTXLISTPTR vtxListPtr )
        {
            this.fType = vtxListPtr.fType;
            this.pVtxList = vtxListPtr.pVtxList;
        }

        // Token: 0x06001CF0 RID: 7408 RVA: 0x00135F78 File Offset: 0x00134178
        public AppMain.NNS_VTXLISTPTR Assign( AppMain.NNS_VTXLISTPTR vtxListPtr )
        {
            this.fType = vtxListPtr.fType;
            this.pVtxList = vtxListPtr.pVtxList;
            return this;
        }

        // Token: 0x06001CF1 RID: 7409 RVA: 0x00135F94 File Offset: 0x00134194
        public static AppMain.NNS_VTXLISTPTR Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_VTXLISTPTR nns_VTXLISTPTR = new AppMain.NNS_VTXLISTPTR();
            nns_VTXLISTPTR.fType = reader.ReadUInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                nns_VTXLISTPTR.pVtxList = AppMain.NNS_VTXLIST_GL_DESC.Read( reader, data0Pos );
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_VTXLISTPTR;
        }

        // Token: 0x04004765 RID: 18277
        public uint fType;

        // Token: 0x04004766 RID: 18278
        public object pVtxList;
    }

    // Token: 0x0200000F RID: 15
    public class NNS_MORPHTARGETPTR
    {
        // Token: 0x06001CF2 RID: 7410 RVA: 0x00135FF6 File Offset: 0x001341F6
        public NNS_MORPHTARGETPTR()
        {
        }

        // Token: 0x06001CF3 RID: 7411 RVA: 0x00135FFE File Offset: 0x001341FE
        public NNS_MORPHTARGETPTR( AppMain.NNS_MORPHTARGETPTR morthTargetPtr )
        {
            this.nVtxList = morthTargetPtr.nVtxList;
            this.pMorphTarget = morthTargetPtr.pMorphTarget;
        }

        // Token: 0x06001CF4 RID: 7412 RVA: 0x0013601E File Offset: 0x0013421E
        public AppMain.NNS_MORPHTARGETPTR Assign( AppMain.NNS_MORPHTARGETPTR morthTargetPtr )
        {
            this.nVtxList = morthTargetPtr.nVtxList;
            this.pMorphTarget = morthTargetPtr.pMorphTarget;
            return this;
        }

        // Token: 0x04004767 RID: 18279
        public int nVtxList;

        // Token: 0x04004768 RID: 18280
        public AppMain.NNS_VTXLISTPTR[] pMorphTarget;
    }

    // Token: 0x02000010 RID: 16
    public class NNS_MORPHTARGETLIST
    {
        // Token: 0x06001CF5 RID: 7413 RVA: 0x00136039 File Offset: 0x00134239
        public NNS_MORPHTARGETLIST()
        {
        }

        // Token: 0x06001CF6 RID: 7414 RVA: 0x00136041 File Offset: 0x00134241
        public NNS_MORPHTARGETLIST( AppMain.NNS_MORPHTARGETLIST morthTargetList )
        {
            this.nMorphTarget = morthTargetList.nMorphTarget;
            this.pMorphTargetPtrList = morthTargetList.pMorphTargetPtrList;
        }

        // Token: 0x06001CF7 RID: 7415 RVA: 0x00136061 File Offset: 0x00134261
        public AppMain.NNS_MORPHTARGETLIST Assign( AppMain.NNS_MORPHTARGETLIST morthTargetList )
        {
            this.nMorphTarget = morthTargetList.nMorphTarget;
            this.pMorphTargetPtrList = morthTargetList.pMorphTargetPtrList;
            return this;
        }

        // Token: 0x04004769 RID: 18281
        public int nMorphTarget;

        // Token: 0x0400476A RID: 18282
        public AppMain.NNS_MORPHTARGETPTR[] pMorphTargetPtrList;
    }

    // Token: 0x02000011 RID: 17
    public class NNS_MORPHTARGETNAME
    {
        // Token: 0x06001CF8 RID: 7416 RVA: 0x0013607C File Offset: 0x0013427C
        public NNS_MORPHTARGETNAME()
        {
        }

        // Token: 0x06001CF9 RID: 7417 RVA: 0x00136084 File Offset: 0x00134284
        public NNS_MORPHTARGETNAME( AppMain.NNS_MORPHTARGETNAME morthTargetName )
        {
            this.iMorphTarget = morthTargetName.iMorphTarget;
            this.Name = morthTargetName.Name;
        }

        // Token: 0x06001CFA RID: 7418 RVA: 0x001360A4 File Offset: 0x001342A4
        public AppMain.NNS_MORPHTARGETNAME Assign( AppMain.NNS_MORPHTARGETNAME morthTargetName )
        {
            this.iMorphTarget = morthTargetName.iMorphTarget;
            this.Name = morthTargetName.Name;
            return this;
        }

        // Token: 0x0400476B RID: 18283
        public int iMorphTarget;

        // Token: 0x0400476C RID: 18284
        public string Name;
    }

    // Token: 0x02000012 RID: 18
    public enum NNE_MORPHTARGETNAME_SORTTYPE
    {
        // Token: 0x0400476E RID: 18286
        NNE_MORPHTARGETNAME_SORTTYPE_INDEX,
        // Token: 0x0400476F RID: 18287
        NNE_MORPHTARGETNAME_SORTTYPE_NAME
    }

    // Token: 0x02000013 RID: 19
    public class NNS_MORPHTARGETNAMELIST
    {
        // Token: 0x06001CFB RID: 7419 RVA: 0x001360BF File Offset: 0x001342BF
        public NNS_MORPHTARGETNAMELIST()
        {
        }

        // Token: 0x06001CFC RID: 7420 RVA: 0x001360C7 File Offset: 0x001342C7
        public NNS_MORPHTARGETNAMELIST( AppMain.NNS_MORPHTARGETNAMELIST morthTargetNameList )
        {
            this.SortType = morthTargetNameList.SortType;
            this.nMorphTarget = morthTargetNameList.nMorphTarget;
            this.pMorphTargetNameList = morthTargetNameList.pMorphTargetNameList;
        }

        // Token: 0x06001CFD RID: 7421 RVA: 0x001360F3 File Offset: 0x001342F3
        public AppMain.NNS_MORPHTARGETNAMELIST Assign( AppMain.NNS_MORPHTARGETNAMELIST morthTargetNameList )
        {
            this.SortType = morthTargetNameList.SortType;
            this.nMorphTarget = morthTargetNameList.nMorphTarget;
            this.pMorphTargetNameList = morthTargetNameList.pMorphTargetNameList;
            return this;
        }

        // Token: 0x04004770 RID: 18288
        public AppMain.NNE_MORPHTARGETNAME_SORTTYPE SortType;

        // Token: 0x04004771 RID: 18289
        public int nMorphTarget;

        // Token: 0x04004772 RID: 18290
        public AppMain.NNS_MORPHTARGETNAME[] pMorphTargetNameList;
    }

    // Token: 0x02000014 RID: 20
    public class NNS_PRIMLISTPTR
    {
        // Token: 0x06001CFE RID: 7422 RVA: 0x0013611A File Offset: 0x0013431A
        public NNS_PRIMLISTPTR()
        {
        }

        // Token: 0x06001CFF RID: 7423 RVA: 0x00136122 File Offset: 0x00134322
        public NNS_PRIMLISTPTR( AppMain.NNS_PRIMLISTPTR primListPtr )
        {
            this.fType = primListPtr.fType;
            this.pPrimList = primListPtr.pPrimList;
        }

        // Token: 0x06001D00 RID: 7424 RVA: 0x00136142 File Offset: 0x00134342
        public AppMain.NNS_PRIMLISTPTR Assign( AppMain.NNS_PRIMLISTPTR primListPtr )
        {
            this.fType = primListPtr.fType;
            this.pPrimList = primListPtr.pPrimList;
            return this;
        }

        // Token: 0x06001D01 RID: 7425 RVA: 0x00136160 File Offset: 0x00134360
        public static AppMain.NNS_PRIMLISTPTR Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_PRIMLISTPTR nns_PRIMLISTPTR = new AppMain.NNS_PRIMLISTPTR();
            nns_PRIMLISTPTR.fType = reader.ReadUInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                nns_PRIMLISTPTR.pPrimList = AppMain.NNS_PRIMLIST_GL_DESC.Read( reader, data0Pos );
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_PRIMLISTPTR;
        }

        // Token: 0x04004773 RID: 18291
        public uint fType;

        // Token: 0x04004774 RID: 18292
        public object pPrimList;
    }

    // Token: 0x02000015 RID: 21
    public class NNS_MESHSET
    {
        // Token: 0x06001D02 RID: 7426 RVA: 0x001361C2 File Offset: 0x001343C2
        public NNS_MESHSET()
        {
        }

        // Token: 0x06001D03 RID: 7427 RVA: 0x001361D8 File Offset: 0x001343D8
        public NNS_MESHSET( AppMain.NNS_MESHSET meshSet )
        {
            this.Center.Assign( meshSet.Center );
            this.Radius = meshSet.Radius;
            this.iNode = meshSet.iNode;
            this.iMatrix = meshSet.iMatrix;
            this.iMaterial = meshSet.iMaterial;
            this.iVtxList = meshSet.iVtxList;
            this.iPrimList = meshSet.iPrimList;
            this.Reserved2 = meshSet.Reserved2;
            this.Reserved1 = meshSet.Reserved1;
            this.Reserved0 = meshSet.Reserved0;
        }

        // Token: 0x06001D04 RID: 7428 RVA: 0x00136274 File Offset: 0x00134474
        public AppMain.NNS_MESHSET Assign( AppMain.NNS_MESHSET meshSet )
        {
            if ( this != meshSet )
            {
                this.Center.Assign( meshSet.Center );
                this.Radius = meshSet.Radius;
                this.iNode = meshSet.iNode;
                this.iMatrix = meshSet.iMatrix;
                this.iMaterial = meshSet.iMaterial;
                this.iVtxList = meshSet.iVtxList;
                this.iPrimList = meshSet.iPrimList;
                this.Reserved2 = meshSet.Reserved2;
                this.Reserved1 = meshSet.Reserved1;
                this.Reserved0 = meshSet.Reserved0;
            }
            return this;
        }

        // Token: 0x06001D05 RID: 7429 RVA: 0x00136304 File Offset: 0x00134504
        public static AppMain.NNS_MESHSET Read( BinaryReader reader )
        {
            return new AppMain.NNS_MESHSET
            {
                Center =
                {
                    x = reader.ReadSingle(),
                    y = reader.ReadSingle(),
                    z = reader.ReadSingle()
                },
                Radius = reader.ReadSingle(),
                iNode = reader.ReadInt32(),
                iMatrix = reader.ReadInt32(),
                iMaterial = reader.ReadInt32(),
                iVtxList = reader.ReadInt32(),
                iPrimList = reader.ReadInt32(),
                Reserved2 = reader.ReadUInt32(),
                Reserved1 = reader.ReadUInt32(),
                Reserved0 = reader.ReadUInt32()
            };
        }

        // Token: 0x04004775 RID: 18293
        public readonly AppMain.NNS_VECTOR Center = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04004776 RID: 18294
        public float Radius;

        // Token: 0x04004777 RID: 18295
        public int iNode;

        // Token: 0x04004778 RID: 18296
        public int iMatrix;

        // Token: 0x04004779 RID: 18297
        public int iMaterial;

        // Token: 0x0400477A RID: 18298
        public int iVtxList;

        // Token: 0x0400477B RID: 18299
        public int iPrimList;

        // Token: 0x0400477C RID: 18300
        public uint Reserved2;

        // Token: 0x0400477D RID: 18301
        public uint Reserved1;

        // Token: 0x0400477E RID: 18302
        public uint Reserved0;
    }

    // Token: 0x02000016 RID: 22
    public class NNS_SUBOBJ
    {
        // Token: 0x06001D06 RID: 7430 RVA: 0x001363B7 File Offset: 0x001345B7
        public NNS_SUBOBJ()
        {
        }

        // Token: 0x06001D07 RID: 7431 RVA: 0x001363C0 File Offset: 0x001345C0
        public NNS_SUBOBJ( AppMain.NNS_SUBOBJ subObj )
        {
            this.fType = subObj.fType;
            this.nMeshset = subObj.nMeshset;
            this.pMeshsetList = subObj.pMeshsetList;
            this.nTex = subObj.nTex;
            this.pTexNumList = subObj.pTexNumList;
        }

        // Token: 0x06001D08 RID: 7432 RVA: 0x00136410 File Offset: 0x00134610
        public AppMain.NNS_SUBOBJ Assign( AppMain.NNS_SUBOBJ subObj )
        {
            if ( this != subObj )
            {
                this.fType = subObj.fType;
                this.nMeshset = subObj.nMeshset;
                this.pMeshsetList = subObj.pMeshsetList;
                this.nTex = subObj.nTex;
                this.pTexNumList = subObj.pTexNumList;
            }
            return this;
        }

        // Token: 0x06001D09 RID: 7433 RVA: 0x00136460 File Offset: 0x00134660
        public static AppMain.NNS_SUBOBJ Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_SUBOBJ nns_SUBOBJ = new AppMain.NNS_SUBOBJ();
            nns_SUBOBJ.fType = reader.ReadUInt32();
            nns_SUBOBJ.nMeshset = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                nns_SUBOBJ.pMeshsetList = new AppMain.NNS_MESHSET[nns_SUBOBJ.nMeshset];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                for ( int i = 0; i < nns_SUBOBJ.nMeshset; i++ )
                {
                    nns_SUBOBJ.pMeshsetList[i] = AppMain.NNS_MESHSET.Read( reader );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_SUBOBJ.nTex = reader.ReadInt32();
            uint num2 = reader.ReadUInt32();
            if ( num2 != 0U )
            {
                nns_SUBOBJ.pTexNumList = new int[nns_SUBOBJ.nTex];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num2 ), 0 );
                for ( int j = 0; j < nns_SUBOBJ.nTex; j++ )
                {
                    nns_SUBOBJ.pTexNumList[j] = reader.ReadInt32();
                }
                reader.BaseStream.Seek( position, 0 );
            }
            return nns_SUBOBJ;
        }

        // Token: 0x0400477F RID: 18303
        public uint fType;

        // Token: 0x04004780 RID: 18304
        public int nMeshset;

        // Token: 0x04004781 RID: 18305
        public AppMain.NNS_MESHSET[] pMeshsetList;

        // Token: 0x04004782 RID: 18306
        public int nTex;

        // Token: 0x04004783 RID: 18307
        public int[] pTexNumList;
    }

    // Token: 0x02000017 RID: 23
    public class NNS_OBJECT
    {
        // Token: 0x06001D0A RID: 7434 RVA: 0x0013656A File Offset: 0x0013476A
        public NNS_OBJECT()
        {
        }

        // Token: 0x06001D0B RID: 7435 RVA: 0x00136580 File Offset: 0x00134780
        public NNS_OBJECT( AppMain.NNS_OBJECT nnsObject )
        {
            this.Center.Assign( nnsObject.Center );
            this.Radius = nnsObject.Radius;
            this.nMaterial = nnsObject.nMaterial;
            this.pMatPtrList = nnsObject.pMatPtrList;
            this.nVtxList = nnsObject.nVtxList;
            this.pVtxListPtrList = nnsObject.pVtxListPtrList;
            this.nPrimList = nnsObject.nPrimList;
            this.pPrimListPtrList = nnsObject.pPrimListPtrList;
            this.nNode = nnsObject.nNode;
            this.MaxNodeDepth = nnsObject.MaxNodeDepth;
            this.pNodeList = nnsObject.pNodeList;
            this.nMtxPal = nnsObject.nMtxPal;
            this.nSubobj = nnsObject.nSubobj;
            this.pSubobjList = nnsObject.pSubobjList;
            this.nTex = nnsObject.nTex;
            this.fType = nnsObject.fType;
            this.Version = nnsObject.Version;
            this.BoundingBoxX = nnsObject.BoundingBoxX;
            this.BoundingBoxY = nnsObject.BoundingBoxY;
            this.BoundingBoxZ = nnsObject.BoundingBoxZ;
        }

        // Token: 0x06001D0C RID: 7436 RVA: 0x00136694 File Offset: 0x00134894
        public AppMain.NNS_OBJECT Assign( AppMain.NNS_OBJECT nnsObject )
        {
            if ( this != nnsObject )
            {
                this.Center.Assign( nnsObject.Center );
                this.Radius = nnsObject.Radius;
                this.nMaterial = nnsObject.nMaterial;
                this.pMatPtrList = nnsObject.pMatPtrList;
                this.nVtxList = nnsObject.nVtxList;
                this.pVtxListPtrList = nnsObject.pVtxListPtrList;
                this.nPrimList = nnsObject.nPrimList;
                this.pPrimListPtrList = nnsObject.pPrimListPtrList;
                this.nNode = nnsObject.nNode;
                this.MaxNodeDepth = nnsObject.MaxNodeDepth;
                this.pNodeList = nnsObject.pNodeList;
                this.nMtxPal = nnsObject.nMtxPal;
                this.nSubobj = nnsObject.nSubobj;
                this.pSubobjList = nnsObject.pSubobjList;
                this.nTex = nnsObject.nTex;
                this.fType = nnsObject.fType;
                this.Version = nnsObject.Version;
                this.BoundingBoxX = nnsObject.BoundingBoxX;
                this.BoundingBoxY = nnsObject.BoundingBoxY;
                this.BoundingBoxZ = nnsObject.BoundingBoxZ;
            }
            return this;
        }

        // Token: 0x06001D0D RID: 7437 RVA: 0x001367A0 File Offset: 0x001349A0
        public static AppMain.NNS_OBJECT Read( BinaryReader reader, long data0Pos )
        {
            AppMain.NNS_OBJECT nns_OBJECT = new AppMain.NNS_OBJECT();
            nns_OBJECT.Center.x = reader.ReadSingle();
            nns_OBJECT.Center.y = reader.ReadSingle();
            nns_OBJECT.Center.z = reader.ReadSingle();
            nns_OBJECT.Radius = reader.ReadSingle();
            nns_OBJECT.nMaterial = reader.ReadInt32();
            uint num = reader.ReadUInt32();
            if ( num != 0U )
            {
                bool flag = false;
                nns_OBJECT.pMatPtrList = new AppMain.NNS_MATERIALPTR[nns_OBJECT.nMaterial];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num ), 0 );
                for ( int i = 0; i < nns_OBJECT.nMaterial; i++ )
                {
                    bool flag2;
                    nns_OBJECT.pMatPtrList[i] = AppMain.NNS_MATERIALPTR.Read( reader, data0Pos, out flag2 );
                    flag = ( flag || flag2 );
                }
                if ( flag )
                {
                    for ( int j = 0; j < nns_OBJECT.nMaterial; j++ )
                    {
                        ( ( AppMain.NNS_MATERIAL_GLES11_DESC )nns_OBJECT.pMatPtrList[j].pMaterial ).fFlag |= 1U;
                    }
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_OBJECT.nVtxList = reader.ReadInt32();
            uint num2 = reader.ReadUInt32();
            if ( num2 != 0U )
            {
                nns_OBJECT.pVtxListPtrList = new AppMain.NNS_VTXLISTPTR[nns_OBJECT.nVtxList];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num2 ), 0 );
                for ( int k = 0; k < nns_OBJECT.nVtxList; k++ )
                {
                    nns_OBJECT.pVtxListPtrList[k] = AppMain.NNS_VTXLISTPTR.Read( reader, data0Pos );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_OBJECT.nPrimList = reader.ReadInt32();
            uint num3 = reader.ReadUInt32();
            if ( num3 != 0U )
            {
                nns_OBJECT.pPrimListPtrList = new AppMain.NNS_PRIMLISTPTR[nns_OBJECT.nPrimList];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num3 ), 0 );
                for ( int l = 0; l < nns_OBJECT.nPrimList; l++ )
                {
                    nns_OBJECT.pPrimListPtrList[l] = AppMain.NNS_PRIMLISTPTR.Read( reader, data0Pos );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_OBJECT.nNode = reader.ReadInt32();
            nns_OBJECT.MaxNodeDepth = reader.ReadInt32();
            uint num4 = reader.ReadUInt32();
            if ( num4 != 0U )
            {
                nns_OBJECT.pNodeList = new AppMain.NNS_NODE[nns_OBJECT.nNode];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num4 ), 0 );
                for ( int m = 0; m < nns_OBJECT.nNode; m++ )
                {
                    nns_OBJECT.pNodeList[m] = AppMain.NNS_NODE.Read( reader, data0Pos );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_OBJECT.nMtxPal = reader.ReadInt32();
            nns_OBJECT.nSubobj = reader.ReadInt32();
            uint num5 = reader.ReadUInt32();
            if ( num5 != 0U )
            {
                nns_OBJECT.pSubobjList = new AppMain.NNS_SUBOBJ[nns_OBJECT.nSubobj];
                long position = reader.BaseStream.Position;
                reader.BaseStream.Seek( data0Pos + ( long )( ( ulong )num5 ), 0 );
                for ( int n = 0; n < nns_OBJECT.nSubobj; n++ )
                {
                    nns_OBJECT.pSubobjList[n] = AppMain.NNS_SUBOBJ.Read( reader, data0Pos );
                }
                reader.BaseStream.Seek( position, 0 );
            }
            nns_OBJECT.nTex = reader.ReadInt32();
            nns_OBJECT.fType = reader.ReadUInt32();
            nns_OBJECT.Version = reader.ReadInt32();
            nns_OBJECT.BoundingBoxX = reader.ReadSingle();
            nns_OBJECT.BoundingBoxY = reader.ReadSingle();
            nns_OBJECT.BoundingBoxZ = reader.ReadSingle();
            return nns_OBJECT;
        }

        // Token: 0x04004784 RID: 18308
        public readonly AppMain.NNS_VECTOR Center = new AppMain.NNS_VECTOR();

        // Token: 0x04004785 RID: 18309
        public float Radius;

        // Token: 0x04004786 RID: 18310
        public int nMaterial;

        // Token: 0x04004787 RID: 18311
        public AppMain.NNS_MATERIALPTR[] pMatPtrList;

        // Token: 0x04004788 RID: 18312
        public int nVtxList;

        // Token: 0x04004789 RID: 18313
        public AppMain.NNS_VTXLISTPTR[] pVtxListPtrList;

        // Token: 0x0400478A RID: 18314
        public int nPrimList;

        // Token: 0x0400478B RID: 18315
        public AppMain.NNS_PRIMLISTPTR[] pPrimListPtrList;

        // Token: 0x0400478C RID: 18316
        public int nNode;

        // Token: 0x0400478D RID: 18317
        public int MaxNodeDepth;

        // Token: 0x0400478E RID: 18318
        public AppMain.NNS_NODE[] pNodeList;

        // Token: 0x0400478F RID: 18319
        public int nMtxPal;

        // Token: 0x04004790 RID: 18320
        public int nSubobj;

        // Token: 0x04004791 RID: 18321
        public AppMain.NNS_SUBOBJ[] pSubobjList;

        // Token: 0x04004792 RID: 18322
        public int nTex;

        // Token: 0x04004793 RID: 18323
        public uint fType;

        // Token: 0x04004794 RID: 18324
        public int Version;

        // Token: 0x04004795 RID: 18325
        public float BoundingBoxX;

        // Token: 0x04004796 RID: 18326
        public float BoundingBoxY;

        // Token: 0x04004797 RID: 18327
        public float BoundingBoxZ;
    }

    // Token: 0x02000018 RID: 24
    public class NNS_COMMON_WEIGHT2
    {
        // Token: 0x04004798 RID: 18328
        public int Index0;

        // Token: 0x04004799 RID: 18329
        public int Index1;

        // Token: 0x0400479A RID: 18330
        public float Ratio;
    }

    // Token: 0x02000019 RID: 25
    public class NNS_COMMON_WEIGHT
    {
        // Token: 0x0400479B RID: 18331
        public int Index;

        // Token: 0x0400479C RID: 18332
        public float Ratio;
    }

    // Token: 0x0200001A RID: 26
    public class NNS_COMMON_PW2
    {
        // Token: 0x0400479D RID: 18333
        public readonly AppMain.NNS_VECTOR Pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x0400479E RID: 18334
        public readonly AppMain.NNS_COMMON_WEIGHT2 Wgt = new AppMain.NNS_COMMON_WEIGHT2();
    }

    // Token: 0x0200001B RID: 27
    public class NNS_COMMON_PW4
    {
        // Token: 0x0400479F RID: 18335
        public readonly AppMain.NNS_VECTOR Pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047A0 RID: 18336
        public readonly AppMain.NNS_COMMON_WEIGHT[] Wgt = AppMain.New<AppMain.NNS_COMMON_WEIGHT>(4);
    }

    // Token: 0x0200001C RID: 28
    public class NNS_COMMON_PN
    {
        // Token: 0x040047A1 RID: 18337
        public readonly AppMain.NNS_VECTOR Pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047A2 RID: 18338
        public readonly AppMain.NNS_VECTOR Nrm = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
    }

    // Token: 0x0200001D RID: 29
    public class NNS_COMMON_PNW2
    {
        // Token: 0x040047A3 RID: 18339
        public readonly AppMain.NNS_VECTOR Pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047A4 RID: 18340
        public readonly AppMain.NNS_VECTOR Nrm = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047A5 RID: 18341
        public readonly AppMain.NNS_COMMON_WEIGHT2 Wgt = new AppMain.NNS_COMMON_WEIGHT2();
    }

    // Token: 0x0200001E RID: 30
    public class NNS_COMMON_PNW4
    {
        // Token: 0x040047A6 RID: 18342
        public readonly AppMain.NNS_VECTOR Pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047A7 RID: 18343
        public readonly AppMain.NNS_VECTOR Nrm = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x040047A8 RID: 18344
        public readonly AppMain.NNS_COMMON_WEIGHT[] Wgt = AppMain.New<AppMain.NNS_COMMON_WEIGHT>(4);
    }

    // Token: 0x0200001F RID: 31
    public class NNS_COMMON_TEXCOORD2
    {
        // Token: 0x040047A9 RID: 18345
        public readonly AppMain.NNS_TEXCOORD[] Tex = AppMain.New<AppMain.NNS_TEXCOORD>(2);
    }

    // Token: 0x02000020 RID: 32
    public class NNS_VTXLIST_COMMON_ARRAY
    {
        // Token: 0x06001D16 RID: 7446 RVA: 0x00136BC8 File Offset: 0x00134DC8
        public AppMain.NNS_VTXLIST_COMMON_ARRAY Assign( AppMain.NNS_VTXLIST_COMMON_ARRAY array )
        {
            this.fType = array.fType;
            this.Number = array.Number;
            this.Size = array.Size;
            this.pList = array.pList;
            return this;
        }

        // Token: 0x040047AA RID: 18346
        public uint fType;

        // Token: 0x040047AB RID: 18347
        public int Number;

        // Token: 0x040047AC RID: 18348
        public uint Size;

        // Token: 0x040047AD RID: 18349
        public object pList;
    }

    // Token: 0x02000021 RID: 33
    public class NNS_VTXLIST_COMMON_DESC
    {
        // Token: 0x06001D18 RID: 7448 RVA: 0x00136C04 File Offset: 0x00134E04
        public AppMain.NNS_VTXLIST_COMMON_DESC Assign( AppMain.NNS_VTXLIST_COMMON_DESC desc )
        {
            if ( this != desc )
            {
                this.List0.Assign( desc.List0 );
                this.List1.Assign( desc.List1 );
                this.List2.Assign( desc.List2 );
                this.List3.Assign( desc.List3 );
            }
            return this;
        }

        // Token: 0x040047AE RID: 18350
        public readonly AppMain.NNS_VTXLIST_COMMON_ARRAY List0 = new AppMain.NNS_VTXLIST_COMMON_ARRAY();

        // Token: 0x040047AF RID: 18351
        public readonly AppMain.NNS_VTXLIST_COMMON_ARRAY List1 = new AppMain.NNS_VTXLIST_COMMON_ARRAY();

        // Token: 0x040047B0 RID: 18352
        public readonly AppMain.NNS_VTXLIST_COMMON_ARRAY List2 = new AppMain.NNS_VTXLIST_COMMON_ARRAY();

        // Token: 0x040047B1 RID: 18353
        public readonly AppMain.NNS_VTXLIST_COMMON_ARRAY List3 = new AppMain.NNS_VTXLIST_COMMON_ARRAY();
    }

    // Token: 0x02000022 RID: 34
    public class NNS_PRIMLIST_COMMON_TRIANGLE_STRIP
    {
        // Token: 0x06001D1A RID: 7450 RVA: 0x00136C92 File Offset: 0x00134E92
        public AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_STRIP Assign( AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_STRIP desc )
        {
            this.fType = desc.fType;
            this.nIndexSetSize = desc.nIndexSetSize;
            this.nStrip = desc.nStrip;
            this.pLengthList = desc.pLengthList;
            this.pStripList = desc.pStripList;
            return this;
        }

        // Token: 0x040047B2 RID: 18354
        public uint fType;

        // Token: 0x040047B3 RID: 18355
        public int nIndexSetSize;

        // Token: 0x040047B4 RID: 18356
        public int nStrip;

        // Token: 0x040047B5 RID: 18357
        public ushort[] pLengthList;

        // Token: 0x040047B6 RID: 18358
        public ushort[] pStripList;
    }

    // Token: 0x02000023 RID: 35
    public class NNS_PRIMLIST_COMMON_TRIANGLE_LIST
    {
        // Token: 0x06001D1D RID: 7453 RVA: 0x00136CE1 File Offset: 0x00134EE1
        public AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_LIST Assign( AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_LIST desc )
        {
            this.fType = desc.fType;
            this.nIndexSetSize = desc.nIndexSetSize;
            this.nTriangle = desc.nTriangle;
            this.pTriangleList = desc.pTriangleList;
            return this;
        }

        // Token: 0x040047B7 RID: 18359
        public uint fType;

        // Token: 0x040047B8 RID: 18360
        public int nIndexSetSize;

        // Token: 0x040047B9 RID: 18361
        public int nTriangle;

        // Token: 0x040047BA RID: 18362
        public ushort[] pTriangleList;
    }

    // Token: 0x02000024 RID: 36
    public class NNS_PRIMLIST_COMMON_QUAD_LIST
    {
        // Token: 0x06001D1E RID: 7454 RVA: 0x00136D14 File Offset: 0x00134F14
        public AppMain.NNS_PRIMLIST_COMMON_QUAD_LIST Assign( AppMain.NNS_PRIMLIST_COMMON_QUAD_LIST list )
        {
            this.fType = list.fType;
            this.nIndexSetSize = list.nIndexSetSize;
            this.nQuad = list.nQuad;
            this.pQuadList = list.pQuadList;
            return this;
        }

        // Token: 0x040047BB RID: 18363
        public uint fType;

        // Token: 0x040047BC RID: 18364
        public int nIndexSetSize;

        // Token: 0x040047BD RID: 18365
        public int nQuad;

        // Token: 0x040047BE RID: 18366
        public ushort[] pQuadList;
    }

    // Token: 0x02000025 RID: 37
    public class NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST
    {
        // Token: 0x06001D20 RID: 7456 RVA: 0x00136D50 File Offset: 0x00134F50
        public AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST Assign( AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST list )
        {
            this.fType = list.fType;
            this.nIndexSetSize = list.nIndexSetSize;
            this.nTriangle = list.nTriangle;
            this.pTriangleList = list.pTriangleList;
            this.nQuad = list.nQuad;
            this.pQuadList = list.pQuadList;
            return this;
        }

        // Token: 0x040047BF RID: 18367
        public uint fType;

        // Token: 0x040047C0 RID: 18368
        public int nIndexSetSize;

        // Token: 0x040047C1 RID: 18369
        public int nTriangle;

        // Token: 0x040047C2 RID: 18370
        public ushort[] pTriangleList;

        // Token: 0x040047C3 RID: 18371
        public int nQuad;

        // Token: 0x040047C4 RID: 18372
        public ushort[] pQuadList;
    }

    // Token: 0x02000276 RID: 630
    private static class nncalcmatrixpalettemotion
    {
        // Token: 0x04005994 RID: 22932
        public static int nnsSubMotIdx;

        // Token: 0x04005995 RID: 22933
        public static AppMain.NNS_MATRIX nnsBaseMtx;

        // Token: 0x04005996 RID: 22934
        public static AppMain.NNS_MATRIX[] nnsMtxPal;

        // Token: 0x04005997 RID: 22935
        public static uint[] nnsNodeStatList;

        // Token: 0x04005998 RID: 22936
        public static uint nnsNSFlag;

        // Token: 0x04005999 RID: 22937
        public static AppMain.NNS_OBJECT nnsObj;

        // Token: 0x0400599A RID: 22938
        public static AppMain.NNS_NODE[] nnsNodeList;

        // Token: 0x0400599B RID: 22939
        public static AppMain.NNS_MATRIXSTACK nnsMstk;

        // Token: 0x0400599C RID: 22940
        public static AppMain.NNS_MOTION nnsMot;

        // Token: 0x0400599D RID: 22941
        public static float nnsFrame;

        // Token: 0x0400599E RID: 22942
        public static float nnsRootScale = 1f;
    }

    // Token: 0x02000277 RID: 631
    private class _nnCalcMotionRotate
    {
        // Token: 0x0400599F RID: 22943
        public static int[] arv = new int[3];

        // Token: 0x040059A0 RID: 22944
        public static short[] arsv = new short[3];
    }

    // Token: 0x02000302 RID: 770
    public class NNS_PRIM2D_P
    {
        // Token: 0x0600252F RID: 9519 RVA: 0x0014C1D0 File Offset: 0x0014A3D0
        public virtual void Clear()
        {
            this.Pos.Clear();
        }

        // Token: 0x04005D2E RID: 23854
        public readonly AppMain.NNS_VECTOR2D Pos = new AppMain.NNS_VECTOR2D();
    }

    // Token: 0x02000303 RID: 771
    public class NNS_PRIM2D_PC : AppMain.NNS_PRIM2D_P
    {
        // Token: 0x06002531 RID: 9521 RVA: 0x0014C1F0 File Offset: 0x0014A3F0
        public override void Clear()
        {
            this.Col = 0U;
            base.Clear();
        }

        // Token: 0x04005D2F RID: 23855
        public uint Col;
    }

    // Token: 0x02000304 RID: 772
    public class NNS_PRIM2D_PCT : AppMain.NNS_PRIM2D_PC
    {
        // Token: 0x06002533 RID: 9523 RVA: 0x0014C207 File Offset: 0x0014A407
        public static int SizeOf()
        {
            return 20;
        }

        // Token: 0x04005D30 RID: 23856
        public AppMain.NNS_TEXCOORD Tex;
    }

    // Token: 0x02000305 RID: 773
    public class NNS_PRIM3D_PN
    {
        // Token: 0x04005D31 RID: 23857
        public readonly AppMain.NNS_VECTOR Pos = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();

        // Token: 0x04005D32 RID: 23858
        public readonly AppMain.NNS_VECTOR Nrm = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
    }

    // Token: 0x02000306 RID: 774
    public struct NNS_PRIM3D_PC
    {
        // Token: 0x04005D33 RID: 23859
        public AppMain.Vector3f Pos;

        // Token: 0x04005D34 RID: 23860
        public uint Col;
    }

    // Token: 0x02000307 RID: 775
    public class NNS_PRIM3D_PNT : AppMain.NNS_PRIM3D_PN
    {
        // Token: 0x04005D35 RID: 23861
        public AppMain.NNS_TEXCOORD Tex;
    }

    // Token: 0x02000308 RID: 776
    public struct NNS_PRIM3D_PCT
    {
        // Token: 0x04005D36 RID: 23862
        public AppMain.Vector3f Pos;

        // Token: 0x04005D37 RID: 23863
        public uint Col;

        // Token: 0x04005D38 RID: 23864
        public AppMain.NNS_TEXCOORD Tex;
    }

    // Token: 0x02000309 RID: 777
    public class NNS_PRIM3D_PCT_ARRAY
    {
        // Token: 0x04005D39 RID: 23865
        public AppMain.NNS_PRIM3D_PCT[] buffer;

        // Token: 0x04005D3A RID: 23866
        public int offset;
    }

    // Token: 0x0200030A RID: 778
    public enum NNE_PRIM_LINE
    {
        // Token: 0x04005D3C RID: 23868
        NNE_PRIM_LINE_LIST,
        // Token: 0x04005D3D RID: 23869
        NNE_PRIM_LINE_STRIP
    }

    // Token: 0x0200030B RID: 779
    private struct NNS_CONFIG_GL
    {
        // Token: 0x04005D3E RID: 23870
        public int WindowWidth;

        // Token: 0x04005D3F RID: 23871
        public int WindowHeight;
    }

    // Token: 0x0200033C RID: 828
    private struct NNS_SCREEN
    {
        // Token: 0x04005E6F RID: 24175
        public float xad;

        // Token: 0x04005E70 RID: 24176
        public float yad;

        // Token: 0x04005E71 RID: 24177
        public float cx;

        // Token: 0x04005E72 RID: 24178
        public float cy;

        // Token: 0x04005E73 RID: 24179
        public float ooxad;

        // Token: 0x04005E74 RID: 24180
        public float ooyad;

        // Token: 0x04005E75 RID: 24181
        public float dist;

        // Token: 0x04005E76 RID: 24182
        public float ax;

        // Token: 0x04005E77 RID: 24183
        public float ay;

        // Token: 0x04005E78 RID: 24184
        public float aspect;

        // Token: 0x04005E79 RID: 24185
        public float w;

        // Token: 0x04005E7A RID: 24186
        public float h;
    }

    // Token: 0x0200033D RID: 829
    private struct NNS_CLIP
    {
        // Token: 0x04005E7B RID: 24187
        public float f_clip;

        // Token: 0x04005E7C RID: 24188
        public float n_clip;

        // Token: 0x04005E7D RID: 24189
        public float x1;

        // Token: 0x04005E7E RID: 24190
        public float x0;

        // Token: 0x04005E7F RID: 24191
        public float y1;

        // Token: 0x04005E80 RID: 24192
        public float y0;
    }

    // Token: 0x0200036D RID: 877
    private static class nncalcnodematrix
    {
        // Token: 0x04005FE5 RID: 24549
        public static int nnsSubMotIdx;

        // Token: 0x04005FE6 RID: 24550
        public static AppMain.NNS_MATRIX nnsBaseMtx;

        // Token: 0x04005FE7 RID: 24551
        public static AppMain.NNS_NODE[] nnsNodeList;

        // Token: 0x04005FE8 RID: 24552
        public static AppMain.NNS_OBJECT nnsObj;

        // Token: 0x04005FE9 RID: 24553
        public static AppMain.NNS_MOTION nnsMot;

        // Token: 0x04005FEA RID: 24554
        public static float nnsFrame;
    }

    // Token: 0x0200036E RID: 878
    private static class nncalcmatrixpalette
    {
        // Token: 0x04005FEB RID: 24555
        public static AppMain.NNS_MATRIX nnsBaseMtx;

        // Token: 0x04005FEC RID: 24556
        public static AppMain.NNS_MATRIX[] nnsMtxPal;

        // Token: 0x04005FED RID: 24557
        public static uint[] nnsNodeStatList;

        // Token: 0x04005FEE RID: 24558
        public static uint nnsNSFlag;

        // Token: 0x04005FEF RID: 24559
        public static AppMain.NNS_NODE[] nnsNodeList;

        // Token: 0x04005FF0 RID: 24560
        public static AppMain.NNS_MATRIXSTACK nnsMstk;

        // Token: 0x04005FF1 RID: 24561
        public static float nnsRootScale = 1f;
    }

    // Token: 0x0200036F RID: 879
    public enum NNE_CIRCUM_COL
    {
        // Token: 0x04005FF3 RID: 24563
        NNE_CIRCUM_COL_NONE,
        // Token: 0x04005FF4 RID: 24564
        NNE_CIRCUM_COL_HIDE,
        // Token: 0x04005FF5 RID: 24565
        NNE_CIRCUM_COL_CLIPHIDE,
        // Token: 0x04005FF6 RID: 24566
        NNE_CIRCUM_COL_INSIDE,
        // Token: 0x04005FF7 RID: 24567
        NNE_CIRCUM_COL_GSINSIDE,
        // Token: 0x04005FF8 RID: 24568
        NNE_CIRCUM_COL_CROSSNEAR,
        // Token: 0x04005FF9 RID: 24569
        NNE_CIRCUM_COL_ERR
    }

    // Token: 0x02000370 RID: 880
    public class NNS_TRS
    {
        // Token: 0x060026B4 RID: 9908 RVA: 0x0015026E File Offset: 0x0014E46E
        public NNS_TRS()
        {
        }

        // Token: 0x060026B5 RID: 9909 RVA: 0x00150276 File Offset: 0x0014E476
        public NNS_TRS( AppMain.NNS_TRS trs )
        {
            this.Translation = trs.Translation;
            this.Rotation = trs.Rotation;
            this.Scaling = trs.Scaling;
        }

        // Token: 0x060026B6 RID: 9910 RVA: 0x001502A2 File Offset: 0x0014E4A2
        public AppMain.NNS_TRS Assign( AppMain.NNS_TRS trs )
        {
            if ( this != trs )
            {
                this.Translation = trs.Translation;
                this.Rotation = trs.Rotation;
                this.Scaling = trs.Scaling;
            }
            return this;
        }

        // Token: 0x04005FFA RID: 24570
        public AppMain.NNS_VECTORFAST Translation;

        // Token: 0x04005FFB RID: 24571
        public AppMain.NNS_QUATERNION Rotation;

        // Token: 0x04005FFC RID: 24572
        public AppMain.NNS_VECTORFAST Scaling;
    }

    // Token: 0x02000371 RID: 881
    public enum NNE_MOTIONBLEND
    {
        // Token: 0x04005FFE RID: 24574
        NNE_MOTIONBLEND_REPLACE_ALL,
        // Token: 0x04005FFF RID: 24575
        NNE_MOTIONBLEND_ADD_TRANSLATION,
        // Token: 0x04006000 RID: 24576
        NNE_MOTIONBLEND_ADD_ALL
    }

    // Token: 0x02000372 RID: 882
    public class NNS_NODEUSRMOT_CALLBACK_VAL
    {
        // Token: 0x170000BF RID: 191
        // (get) Token: 0x060026B7 RID: 9911 RVA: 0x001502CD File Offset: 0x0014E4CD
        // (set) Token: 0x060026B8 RID: 9912 RVA: 0x001502E0 File Offset: 0x0014E4E0
        public float FValue
        {
            get
            {
                return BitConverter.ToSingle( BitConverter.GetBytes( this.IValue ), 0 );
            }
            set
            {
                this.IValue = BitConverter.ToUInt32( BitConverter.GetBytes( value ), 0 );
            }
        }

        // Token: 0x04006001 RID: 24577
        public int iNode;

        // Token: 0x04006002 RID: 24578
        public float Frame;

        // Token: 0x04006003 RID: 24579
        public uint IValue;

        // Token: 0x04006004 RID: 24580
        public AppMain.NNS_MOTION pMotion;

        // Token: 0x04006005 RID: 24581
        public int iSubmot;

        // Token: 0x04006006 RID: 24582
        public uint fSubmotType;

        // Token: 0x04006007 RID: 24583
        public uint fSubmotIPType;

        // Token: 0x04006008 RID: 24584
        public AppMain.NNS_OBJECT pObject;
    }

    // Token: 0x02000373 RID: 883
    // (Invoke) Token: 0x060026BB RID: 9915
    public delegate void NNS_NODEUSRMOT_CALLBACK_FUNC( AppMain.NNS_NODEUSRMOT_CALLBACK_VAL val );

    // Token: 0x02000374 RID: 884
    private class nngGLExtensions
    {
        // Token: 0x04006009 RID: 24585
        public static int max_texture_units = 2;

        // Token: 0x0400600A RID: 24586
        public static int light_max_exponent = 0;

        // Token: 0x0400600B RID: 24587
        public static float max_shininess = 128f;
    }

    // Token: 0x02000375 RID: 885
    private class NNS_SHADER_MANAGER
    {
        // Token: 0x0400600C RID: 24588
        public AppMain.NNS_SHADER_NAME Name;

        // Token: 0x0400600D RID: 24589
        public AppMain.NNE_SHADERTYPE ShaderType;

        // Token: 0x0400600E RID: 24590
        public uint ProgramObject;

        // Token: 0x0400600F RID: 24591
        public uint VertexProgram;

        // Token: 0x04006010 RID: 24592
        public uint FragmentProgram;

        // Token: 0x04006011 RID: 24593
        public int NumParallelLightLocation;

        // Token: 0x04006012 RID: 24594
        public int NumPointLightLocation;

        // Token: 0x04006013 RID: 24595
        public int NumSpotLightLocation;

        // Token: 0x04006014 RID: 24596
        public int PointLightFallOffEndLocation;

        // Token: 0x04006015 RID: 24597
        public int PointLightFallOffScaleLocation;

        // Token: 0x04006016 RID: 24598
        public int SpotLightFallOffEndLocation;

        // Token: 0x04006017 RID: 24599
        public int SpotLightFallOffScaleLocation;

        // Token: 0x04006018 RID: 24600
        public int SpotLightAngleScaleLocation;

        // Token: 0x04006019 RID: 24601
        public int TexBaseAlphaLocation;

        // Token: 0x0400601A RID: 24602
        public int TexDecalAlphaLocation;

        // Token: 0x0400601B RID: 24603
        public int TexDecal2AlphaLocation;

        // Token: 0x0400601C RID: 24604
        public int TexDecal3AlphaLocation;

        // Token: 0x0400601D RID: 24605
        public int TexShininessLevelLocation;

        // Token: 0x0400601E RID: 24606
        public int TexDualParaboloidLevelLocation;

        // Token: 0x0400601F RID: 24607
        public int TexAddLevelLocation;

        // Token: 0x04006020 RID: 24608
        public int TexShadowColorLocation;

        // Token: 0x04006021 RID: 24609
        public int TexShadow2ColorLocation;

        // Token: 0x04006022 RID: 24610
        public int TexUser1ParamLocation;

        // Token: 0x04006023 RID: 24611
        public int TexUser2ParamLocation;

        // Token: 0x04006024 RID: 24612
        public int TexUser3ParamLocation;

        // Token: 0x04006025 RID: 24613
        public int TexUser4ParamLocation;

        // Token: 0x04006026 RID: 24614
        public int TexUser5ParamLocation;

        // Token: 0x04006027 RID: 24615
        public int TexUser6ParamLocation;

        // Token: 0x04006028 RID: 24616
        public int TexUser7ParamLocation;

        // Token: 0x04006029 RID: 24617
        public int TexUser8ParamLocation;

        // Token: 0x0400602A RID: 24618
        public int TexNormalSamplerLocation;

        // Token: 0x0400602B RID: 24619
        public int TexBaseSamplerLocation;

        // Token: 0x0400602C RID: 24620
        public int TexDecalSamplerLocation;

        // Token: 0x0400602D RID: 24621
        public int TexDecal2SamplerLocation;

        // Token: 0x0400602E RID: 24622
        public int TexDecal3SamplerLocation;

        // Token: 0x0400602F RID: 24623
        public int TexSpecularSamplerLocation;

        // Token: 0x04006030 RID: 24624
        public int TexShininessSamplerLocation;

        // Token: 0x04006031 RID: 24625
        public int TexDualParaboloidSamplerLocation;

        // Token: 0x04006032 RID: 24626
        public int TexEnvMaskSamplerLocation;

        // Token: 0x04006033 RID: 24627
        public int TexModulateSamplerLocation;

        // Token: 0x04006034 RID: 24628
        public int TexAddSamplerLocation;

        // Token: 0x04006035 RID: 24629
        public int TexOpacitySamplerLocation;

        // Token: 0x04006036 RID: 24630
        public int TexUser1SamplerLocation;

        // Token: 0x04006037 RID: 24631
        public int TexUser2SamplerLocation;

        // Token: 0x04006038 RID: 24632
        public int TexUser3SamplerLocation;

        // Token: 0x04006039 RID: 24633
        public int TexUser4SamplerLocation;

        // Token: 0x0400603A RID: 24634
        public int TexUser5SamplerLocation;

        // Token: 0x0400603B RID: 24635
        public int TexUser6SamplerLocation;

        // Token: 0x0400603C RID: 24636
        public int TexUser7SamplerLocation;

        // Token: 0x0400603D RID: 24637
        public int TexUser8SamplerLocation;

        // Token: 0x0400603E RID: 24638
        public int TexShadowSamplerLocation;

        // Token: 0x0400603F RID: 24639
        public int TexShadow2SamplerLocation;

        // Token: 0x04006040 RID: 24640
        public int TexUserSampler2D1Location;

        // Token: 0x04006041 RID: 24641
        public int TexUserSampler2D2Location;

        // Token: 0x04006042 RID: 24642
        public int TexUserSampler3D1Location;

        // Token: 0x04006043 RID: 24643
        public int TexUserSampler3D2Location;

        // Token: 0x04006044 RID: 24644
        public int TexUserSamplerCube1Location;

        // Token: 0x04006045 RID: 24645
        public int TexUserSamplerCube2Location;

        // Token: 0x04006046 RID: 24646
        public int DualParaboloidMatrixLocation;

        // Token: 0x04006047 RID: 24647
        public int UserUniformLocation;

        // Token: 0x04006048 RID: 24648
        public int PositionMatrixLocation;

        // Token: 0x04006049 RID: 24649
        public int NormalMatrixLocation;
    }

    // Token: 0x02000376 RID: 886
    private struct NNS_SPHERE
    {
        // Token: 0x0400604A RID: 24650
        private AppMain.NNS_VECTOR c;

        // Token: 0x0400604B RID: 24651
        private float r;
    }

    // Token: 0x02000377 RID: 887
    private struct NNS_CAPSULE
    {
        // Token: 0x0400604C RID: 24652
        private AppMain.NNS_VECTOR c1;

        // Token: 0x0400604D RID: 24653
        private AppMain.NNS_VECTOR c2;

        // Token: 0x0400604E RID: 24654
        private float r;
    }

    // Token: 0x02000378 RID: 888
    private class NNS_BOX
    {
        // Token: 0x0400604F RID: 24655
        private AppMain.NNS_VECTOR p;

        // Token: 0x04006050 RID: 24656
        private AppMain.NNS_VECTOR[] v = AppMain.New<AppMain.NNS_VECTOR>(3);
    }

    // Token: 0x02000379 RID: 889
    private enum NNE_PRINT_ORIENTATION_MODE
    {
        // Token: 0x04006052 RID: 24658
        NNE_POM_VERTICAL,
        // Token: 0x04006053 RID: 24659
        NNE_POM_HORIZON_LEFT,
        // Token: 0x04006054 RID: 24660
        NNE_POM_HORIZON_RIGHT
    }

    // Token: 0x020003A4 RID: 932
    private static class nnclip
    {
        // Token: 0x04006150 RID: 24912
        public static uint[] nnsNodeStatList;

        // Token: 0x04006151 RID: 24913
        public static AppMain.NNS_NODE[] nnsNodeList;
    }

    // Token: 0x020003A5 RID: 933
    [StructLayout( LayoutKind.Explicit )]
    public class NNS_CLIP_PLANE_XZ
    {
        // Token: 0x04006152 RID: 24914
        [FieldOffset(0)]
        public float nx;

        // Token: 0x04006153 RID: 24915
        [FieldOffset(0)]
        public float mul;

        // Token: 0x04006154 RID: 24916
        [FieldOffset(4)]
        public float nz;

        // Token: 0x04006155 RID: 24917
        [FieldOffset(4)]
        public float ofs;
    }

    // Token: 0x020003A6 RID: 934
    [StructLayout( LayoutKind.Explicit )]
    public class NNS_CLIP_PLANE_YZ
    {
        // Token: 0x04006156 RID: 24918
        [FieldOffset(0)]
        public float ny;

        // Token: 0x04006157 RID: 24919
        [FieldOffset(0)]
        public float mul;

        // Token: 0x04006158 RID: 24920
        [FieldOffset(4)]
        public float nz;

        // Token: 0x04006159 RID: 24921
        [FieldOffset(4)]
        public float ofs;
    }

    // Token: 0x020003A7 RID: 935
    public class NNS_CLIP_PLANE
    {
        // Token: 0x0400615A RID: 24922
        public AppMain.NNS_CLIP_PLANE_YZ Top = new AppMain.NNS_CLIP_PLANE_YZ();

        // Token: 0x0400615B RID: 24923
        public AppMain.NNS_CLIP_PLANE_YZ Bottom = new AppMain.NNS_CLIP_PLANE_YZ();

        // Token: 0x0400615C RID: 24924
        public AppMain.NNS_CLIP_PLANE_XZ Right = new AppMain.NNS_CLIP_PLANE_XZ();

        // Token: 0x0400615D RID: 24925
        public AppMain.NNS_CLIP_PLANE_XZ Left = new AppMain.NNS_CLIP_PLANE_XZ();
    }

    // Token: 0x020003A8 RID: 936
    private struct NNS_OBJECT_MEASURE
    {
        // Token: 0x0400615E RID: 24926
        private int nObj;

        // Token: 0x0400615F RID: 24927
        private int nSubobj;

        // Token: 0x04006160 RID: 24928
        private int nNode;

        // Token: 0x04006161 RID: 24929
        private int nMtx;

        // Token: 0x04006162 RID: 24930
        private int nVtx;

        // Token: 0x04006163 RID: 24931
        private int nPrim;

        // Token: 0x04006164 RID: 24932
        private int nMeshset;

        // Token: 0x04006165 RID: 24933
        private int nMaterial;

        // Token: 0x04006166 RID: 24934
        private int nTex;
    }

    // Token: 0x020003A9 RID: 937
    private struct NNS_PLIABLEOBJ
    {
        // Token: 0x04006167 RID: 24935
        private uint flag;

        // Token: 0x04006168 RID: 24936
        private AppMain.NNS_OBJECT pObject;

        // Token: 0x04006169 RID: 24937
        private uint Size;

        // Token: 0x0400616A RID: 24938
        private object pBuffer;

        // Token: 0x0400616B RID: 24939
        private uint pIdx;
    }

    // Token: 0x06001125 RID: 4389 RVA: 0x00095960 File Offset: 0x00093B60
    private static void nnCalcMatrixPaletteMotion( AppMain.NNS_MATRIX[] mtxpal, uint[] nodestatlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        if ( ( mot.fType & 1U ) != 0U )
        {
            AppMain.nncalcmatrixpalettemotion.nnsSubMotIdx = 0;
            float nnsFrame;
            int num = AppMain.nnCalcMotionFrame(out nnsFrame, mot.fType, mot.StartFrame, mot.EndFrame, frame);
            AppMain.nncalcmatrixpalettemotion.nnsMtxPal = mtxpal;
            AppMain.nncalcmatrixpalettemotion.nnsNodeStatList = nodestatlist;
            AppMain.nncalcmatrixpalettemotion.nnsNSFlag = flag;
            AppMain.nncalcmatrixpalettemotion.nnsObj = obj;
            AppMain.nncalcmatrixpalettemotion.nnsNodeList = obj.pNodeList;
            AppMain.nncalcmatrixpalettemotion.nnsMstk = mstk;
            AppMain.nncalcmatrixpalettemotion.nnsMot = mot;
            AppMain.nncalcmatrixpalettemotion.nnsFrame = nnsFrame;
            if ( num != 0 )
            {
                if ( basemtx != null )
                {
                    AppMain.nncalcmatrixpalettemotion.nnsBaseMtx = basemtx;
                }
                else
                {
                    AppMain.nncalcmatrixpalettemotion.nnsBaseMtx = AppMain.nngUnitMatrix;
                }
                AppMain.nnSetCurrentMatrix( mstk, AppMain.nncalcmatrixpalettemotion.nnsBaseMtx );
                AppMain.nnCalcMatrixPaletteMotionNode( 0 );
                return;
            }
            AppMain.nnCalcMatrixPalette( mtxpal, nodestatlist, obj, basemtx, mstk, AppMain.nncalcmatrixpalettemotion.nnsNSFlag );
        }
    }

    // Token: 0x06001126 RID: 4390 RVA: 0x00095A14 File Offset: 0x00093C14
    private static int nnCalcMotionFrame( out float dstframe, uint fType, float startframe, float endframe, float frame )
    {
        if ( ( fType & 64U ) != 0U )
        {
            dstframe = frame;
            return 1;
        }
        uint num = fType & 2031680U & 4294967231U;
        if ( num <= 131072U )
        {
            if ( num != 65536U )
            {
                if ( num == 131072U )
                {
                    if ( startframe > frame )
                    {
                        dstframe = startframe;
                    }
                    else if ( endframe <= frame )
                    {
                        dstframe = endframe;
                    }
                    else
                    {
                        dstframe = frame;
                    }
                    return 1;
                }
            }
            else
            {
                if ( startframe <= frame && frame < endframe )
                {
                    dstframe = frame;
                    return 1;
                }
                dstframe = frame;
                return 0;
            }
        }
        else
        {
            if ( num == 262144U )
            {
                if ( startframe <= frame && frame < endframe )
                {
                    dstframe = frame;
                }
                else
                {
                    float num2 = frame - startframe;
                    float num3 = endframe - startframe;
                    float num4 = num2 / num3;
                    int num5 = (int)num4;
                    if ( num4 < 0f )
                    {
                        num5--;
                    }
                    num4 = ( float )num5;
                    dstframe = frame - num3 * num4;
                }
                return 1;
            }
            if ( num == 524288U )
            {
                float num2 = frame - startframe;
                float num3 = endframe - startframe;
                float num4 = num2 / num3;
                int num5 = (int)num4;
                if ( num4 < 0f )
                {
                    num5--;
                }
                num4 = ( float )num5;
                if ( ( num5 & 1 ) != 0 )
                {
                    dstframe = startframe - num2 + num3 * ( num4 + 1f );
                }
                else
                {
                    dstframe = frame - num3 * num4;
                }
                return 1;
            }
            if ( num != 1048576U )
            {
            }
        }
        dstframe = frame;
        return 0;
    }

    // Token: 0x06001127 RID: 4391 RVA: 0x00095B2C File Offset: 0x00093D2C
    private static void nnCalcMatrixPaletteMotionNode( int nodeIdx )
    {
        int? num = new int?(0);
        for (; ; )
        {
            AppMain.NNS_NODE nns_NODE = AppMain.nncalcmatrixpalettemotion.nnsNodeList[nodeIdx];
            if ( ( nns_NODE.fType & 134217728U ) != 0U )
            {
                if ( ( nns_NODE.fType & 100663296U ) == 0U )
                {
                    goto IL_D4;
                }
                AppMain.nnPushMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk, null );
                if ( ( nns_NODE.fType & 33554432U ) != 0U )
                {
                    AppMain.nnCalcMatrixPaletteMotionNode1BoneXSIIK( nodeIdx );
                }
                else if ( ( nns_NODE.fType & 67108864U ) != 0U )
                {
                    AppMain.nnCalcMatrixPaletteMotionNode2BoneXSIIK( nodeIdx );
                }
                AppMain.nnPopMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk );
                nodeIdx = ( int )nns_NODE.iSibling;
            }
            else
            {
                if ( ( nns_NODE.fType & 16384U ) != 0U )
                {
                    break;
                }
                if ( ( nns_NODE.fType & 32768U ) != 0U )
                {
                    goto Block_6;
                }
                goto IL_D4;
            }
            IL_1E0:
            if ( nns_NODE.iSibling == -1 )
            {
                return;
            }
            continue;
            IL_D4:
            AppMain.nnPushMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk, null );
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.nnGetCurrentMatrix(AppMain.nncalcmatrixpalettemotion.nnsMstk);
            AppMain.nncalcmatrixpalettemotion.nnsSubMotIdx = AppMain.nnCalcNodeMotionCore( nns_MATRIX, ref num, AppMain.nncalcmatrixpalettemotion.nnsBaseMtx, nns_NODE, nodeIdx, AppMain.nncalcmatrixpalettemotion.nnsObj, AppMain.nncalcmatrixpalettemotion.nnsMot, AppMain.nncalcmatrixpalettemotion.nnsSubMotIdx, AppMain.nncalcmatrixpalettemotion.nnsFrame );
            if ( nns_NODE.iMatrix != -1 )
            {
                if ( ( nns_NODE.fType & 8U ) != 0U )
                {
                    AppMain.nnCopyMatrix( AppMain.nncalcmatrixpalettemotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX );
                }
                else
                {
                    AppMain.nnMultiplyMatrix( AppMain.nncalcmatrixpalettemotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX, nns_NODE.InvInitMtx );
                }
            }
            if ( AppMain.nncalcmatrixpalettemotion.nnsNodeStatList != null )
            {
                if ( nodeIdx == 0 && AppMain.nncalcmatrixpalettemotion.nnsNSFlag != 0U )
                {
                    AppMain.nncalcmatrixpalettemotion.nnsRootScale = AppMain.nnEstimateMatrixScaling( nns_MATRIX );
                }
                if ( num != 0 )
                {
                    AppMain.nncalcmatrixpalettemotion.nnsNodeStatList[nodeIdx] |= 1U;
                }
                AppMain.nnCalcClipSetNodeStatus( AppMain.nncalcmatrixpalettemotion.nnsNodeStatList, AppMain.nncalcmatrixpalettemotion.nnsNodeList, nodeIdx, nns_MATRIX, AppMain.nncalcmatrixpalettemotion.nnsRootScale, AppMain.nncalcmatrixpalettemotion.nnsNSFlag );
            }
            if ( nns_NODE.iChild != -1 )
            {
                AppMain.nnCalcMatrixPaletteMotionNode( ( int )nns_NODE.iChild );
            }
            AppMain.nnPopMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk );
            nodeIdx = ( int )nns_NODE.iSibling;
            goto IL_1E0;
        }
        AppMain.nnPushMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk, null );
        AppMain.nnCalcMatrixPaletteMotionNode1BoneSIIK( nodeIdx );
        AppMain.nnPopMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk );
        return;
        Block_6:
        AppMain.nnPushMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk, null );
        AppMain.nnCalcMatrixPaletteMotionNode2BoneSIIK( nodeIdx );
        AppMain.nnPopMatrix( AppMain.nncalcmatrixpalettemotion.nnsMstk );
    }

    // Token: 0x06001128 RID: 4392 RVA: 0x00095D28 File Offset: 0x00093F28
    private static int nnCalcNodeMotionCore( AppMain.NNS_MATRIX pNodeMtx, ref int? pHideFlag, AppMain.NNS_MATRIX pBaseMtx, AppMain.NNS_NODE pNode, int NodeIdx, AppMain.NNS_OBJECT pObj, AppMain.NNS_MOTION pMot, int SubMotIdx, float frame )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_ROTATE_A32 nns_ROTATE_A = default(AppMain.NNS_ROTATE_A32);
        AppMain.NNS_QUATERNION rq = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        uint fType = pNode.fType;
        uint num = pNode.fType & 3840U;
        nns_VECTOR.Assign( pNode.Translation );
        nns_VECTOR2.Assign( pNode.Scaling );
        if ( ( fType & 114688U ) != 0U )
        {
            nns_ROTATE_A.x = ( nns_ROTATE_A.y = ( nns_ROTATE_A.z = 0 ) );
        }
        else
        {
            nns_ROTATE_A.x = pNode.Rotation.x;
            nns_ROTATE_A.y = pNode.Rotation.y;
            nns_ROTATE_A.z = pNode.Rotation.z;
        }
        int num2 = ((fType & 1U) != 0U) ? 0 : 1;
        int num3 = ((fType & 2U) != 0U) ? 0 : 1;
        int num4 = ((fType & 4U) != 0U) ? 0 : 1;
        if ( pHideFlag != null )
        {
            pHideFlag = new int?( 0 );
        }
        for ( int i = SubMotIdx; i < pMot.nSubmotion; i++ )
        {
            AppMain.NNS_SUBMOTION nns_SUBMOTION = pMot.pSubmotion[i];
            if ( NodeIdx < nns_SUBMOTION.Id )
            {
                SubMotIdx = i;
                break;
            }
            if ( NodeIdx == nns_SUBMOTION.Id && nns_SUBMOTION.fType != 0U && nns_SUBMOTION.StartFrame <= frame && frame <= nns_SUBMOTION.EndFrame )
            {
                uint fType2 = nns_SUBMOTION.fIPType;
                if ( ( pMot.fType & 131072U ) != 0U && frame == nns_SUBMOTION.EndFrame )
                {
                    fType2 = 131072U;
                }
                float num5;
                if ( AppMain.nnCalcMotionFrame( out num5, fType2, nns_SUBMOTION.StartKeyFrame, nns_SUBMOTION.EndKeyFrame, frame ) != 0 )
                {
                    if ( ( nns_SUBMOTION.fType & 30720U ) != 0U )
                    {
                        num3 |= AppMain.nnCalcMotionRotate( nns_SUBMOTION, num5, ref nns_ROTATE_A, rq, num );
                    }
                    else if ( ( nns_SUBMOTION.fType & 1792U ) != 0U )
                    {
                        num2 |= AppMain.nnCalcMotionTranslate( nns_SUBMOTION, num5, nns_VECTOR );
                    }
                    else if ( ( nns_SUBMOTION.fType & 229376U ) != 0U )
                    {
                        num4 |= AppMain.nnCalcMotionScale( nns_SUBMOTION, num5, nns_VECTOR2 );
                    }
                    else if ( ( nns_SUBMOTION.fType & 786432U ) != 0U )
                    {
                        AppMain.nnCallbackMotionUserData( pObj, pMot, i, NodeIdx, num5, frame );
                    }
                    else if ( ( nns_SUBMOTION.fType & 1048576U ) != 0U && pHideFlag != null )
                    {
                        pHideFlag = new int?( AppMain.nnCalcMotionNodeHide( nns_SUBMOTION, num5 ) );
                    }
                }
            }
        }
        if ( num2 == 1 )
        {
            if ( ( pNode.fType & 8192U ) != 0U )
            {
                AppMain.NNS_VECTORFAST src = default(AppMain.NNS_VECTORFAST);
                AppMain.nnmSetUpVectorFast( out src, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z );
                AppMain.nnTransformVectorFast( out src, pBaseMtx, src );
                AppMain.nnCopyVectorFastMatrixTranslation( pNodeMtx, ref src );
            }
            else
            {
                AppMain.nnTranslateMatrixFast( pNodeMtx, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z );
            }
        }
        if ( ( pNode.fType & 1839104U ) != 0U )
        {
            if ( ( pNode.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( pNodeMtx, pBaseMtx );
            }
            if ( ( pNode.fType & 262144U ) != 0U )
            {
                AppMain.nnNormalizeColumn0( pNodeMtx );
            }
            if ( ( pNode.fType & 524288U ) != 0U )
            {
                AppMain.nnNormalizeColumn1( pNodeMtx );
            }
            if ( ( pNode.fType & 1048576U ) != 0U )
            {
                AppMain.nnNormalizeColumn2( pNodeMtx );
            }
        }
        if ( num3 == 1 )
        {
            uint num6 = num;
            if ( num6 != 0U )
            {
                if ( num6 != 256U )
                {
                    if ( num6 != 1024U )
                    {
                        AppMain.nnRotateXYZMatrix( pNodeMtx, pNodeMtx, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                    }
                    else
                    {
                        AppMain.nnRotateZXYMatrixFast( pNodeMtx, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                    }
                }
                else
                {
                    AppMain.nnRotateXZYMatrixFast( pNodeMtx, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                }
            }
            else
            {
                AppMain.nnRotateXYZMatrix( pNodeMtx, pNodeMtx, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
            }
        }
        else if ( ( num3 & 2 ) != 0 )
        {
            AppMain.nnQuaternionMatrix( pNodeMtx, pNodeMtx, ref rq );
        }
        if ( num4 == 1 )
        {
            AppMain.nnScaleMatrixFast( pNodeMtx, nns_VECTOR2.x, nns_VECTOR2.y, nns_VECTOR2.z );
        }
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        return SubMotIdx;
    }

    // Token: 0x06001129 RID: 4393 RVA: 0x0009611C File Offset: 0x0009431C
    private static int nnCalcMotionRotate( AppMain.NNS_SUBMOTION submot, float frame, ref AppMain.NNS_ROTATE_A32 rv, AppMain.NNS_QUATERNION rq, uint rtype )
    {
        int result = 0;
        AppMain.NNS_ROTATE_A16 nns_ROTATE_A = default(AppMain.NNS_ROTATE_A16);
        int[] arv = AppMain._nnCalcMotionRotate.arv;
        arv[0] = rv.x;
        arv[1] = rv.y;
        arv[2] = rv.z;
        short[] arsv = AppMain._nnCalcMotionRotate.arsv;
        arsv[0] = nns_ROTATE_A.x;
        arsv[1] = nns_ROTATE_A.y;
        arsv[2] = nns_ROTATE_A.z;
        object pKeyList = submot.pKeyList;
        int nKeyFrame = submot.nKeyFrame;
        uint num = submot.fType & 30720U;
        uint num2 = submot.fType & 28U;
        int num3 = 0;
        uint num4 = num;
        if ( num4 != 14336U )
        {
            if ( num4 != 16384U )
            {
                if ( num == 8192U )
                {
                    num3 += 2;
                    num = 2048U;
                }
                else if ( num == 4096U )
                {
                    num3++;
                    num = 2048U;
                }
                if ( 2048U == num )
                {
                    if ( num2 == 16U )
                    {
                        result = 1;
                        uint num5 = submot.fIPType & 3703U;
                        switch ( num5 )
                        {
                            case 2U:
                                AppMain.nnInterpolateLinearA16_1( ( AppMain.NNS_MOTION_KEY_Class14[] )pKeyList, nKeyFrame, frame, out arsv[num3] );
                                arv[num3] = ( int )arsv[num3];
                                break;
                            case 3U:
                                break;
                            case 4U:
                                AppMain.nnInterpolateConstantA16_1( ( AppMain.NNS_MOTION_KEY_Class14[] )pKeyList, nKeyFrame, frame, out arsv[num3] );
                                arv[num3] = ( int )arsv[num3];
                                break;
                            default:
                                if ( num5 == 32U )
                                {
                                    AppMain.nnInterpolateSISplineA16_1( ( AppMain.NNS_MOTION_KEY_Class15[] )pKeyList, nKeyFrame, frame, out arsv[num3] );
                                    arv[num3] = ( int )arsv[num3];
                                }
                                break;
                        }
                    }
                    else
                    {
                        uint num6 = submot.fIPType & 3703U;
                        if ( num6 <= 32U )
                        {
                            switch ( num6 )
                            {
                                case 1U:
                                case 3U:
                                    break;
                                case 2U:
                                    AppMain.nnInterpolateLinearA32_1( ( AppMain.NNS_MOTION_KEY_Class8[] )pKeyList, nKeyFrame, frame, out arv[num3] );
                                    result = 1;
                                    break;
                                case 4U:
                                    AppMain.nnInterpolateConstantA32_1( ( AppMain.NNS_MOTION_KEY_Class8[] )pKeyList, nKeyFrame, frame, out arv[num3] );
                                    result = 1;
                                    break;
                                default:
                                    if ( num6 != 16U )
                                    {
                                        if ( num6 == 32U )
                                        {
                                            AppMain.nnInterpolateSISplineA32_1( ( AppMain.NNS_MOTION_KEY_Class10[] )pKeyList, nKeyFrame, frame, out arv[num3] );
                                            result = 1;
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateBezierA32_1( ( AppMain.NNS_MOTION_KEY_Class9[] )pKeyList, nKeyFrame, frame, out arv[num3] );
                                        result = 1;
                                    }
                                    break;
                            }
                        }
                        else if ( num6 != 512U && num6 != 1024U && num6 != 2048U )
                        {
                        }
                    }
                }
                rv.x = arv[0];
                rv.y = arv[1];
                rv.z = arv[2];
            }
            else
            {
                uint num7 = submot.fIPType & 3703U;
                if ( num7 <= 16U )
                {
                    switch ( num7 )
                    {
                        case 1U:
                        case 2U:
                        case 3U:
                            break;
                        case 4U:
                            AppMain.nnInterpolateConstantQuat_4( ( AppMain.NNS_MOTION_KEY_Class7[] )pKeyList, nKeyFrame, frame, ref rq );
                            result = 2;
                            break;
                        default:
                            if ( num7 != 16U )
                            {
                            }
                            break;
                    }
                }
                else if ( num7 != 512U )
                {
                    if ( num7 != 1024U )
                    {
                        if ( num7 == 2048U )
                        {
                            AppMain.nnInterpolateSquadQuat_4( ( AppMain.NNS_MOTION_KEY_Class7[] )pKeyList, nKeyFrame, frame, ref rq );
                            result = 2;
                        }
                    }
                    else
                    {
                        AppMain.nnInterpolateSlerpQuat_4( ( AppMain.NNS_MOTION_KEY_Class7[] )pKeyList, nKeyFrame, frame, ref rq );
                        result = 2;
                    }
                }
                else
                {
                    AppMain.nnInterpolateLerpQuat_4( ( AppMain.NNS_MOTION_KEY_Class7[] )pKeyList, nKeyFrame, frame, ref rq );
                    result = 2;
                }
            }
        }
        else if ( num2 == 16U )
        {
            uint num8 = submot.fIPType & 3703U;
            if ( num8 <= 16U )
            {
                switch ( num8 )
                {
                    case 1U:
                    case 3U:
                        break;
                    case 2U:
                        AppMain.nnInterpolateLinearA16_3( ( AppMain.NNS_MOTION_KEY_Class16[] )pKeyList, nKeyFrame, frame, ref nns_ROTATE_A );
                        rv.x = ( int )nns_ROTATE_A.x;
                        rv.y = ( int )nns_ROTATE_A.y;
                        rv.z = ( int )nns_ROTATE_A.z;
                        result = 1;
                        break;
                    case 4U:
                        AppMain.nnInterpolateConstantA16_3( ( AppMain.NNS_MOTION_KEY_Class16[] )pKeyList, nKeyFrame, frame, ref nns_ROTATE_A );
                        rv.x = ( int )nns_ROTATE_A.x;
                        rv.y = ( int )nns_ROTATE_A.y;
                        rv.z = ( int )nns_ROTATE_A.z;
                        result = 1;
                        break;
                    default:
                        if ( num8 != 16U )
                        {
                        }
                        break;
                }
            }
            else if ( num8 != 512U )
            {
                if ( num8 != 1024U )
                {
                    if ( num8 == 2048U )
                    {
                        AppMain.nnInterpolateSquadA16_3( ( AppMain.NNS_MOTION_KEY_Class16[] )pKeyList, nKeyFrame, frame, ref rq, rtype );
                        result = 2;
                    }
                }
                else
                {
                    AppMain.nnInterpolateSlerpA16_3( ( AppMain.NNS_MOTION_KEY_Class16[] )pKeyList, nKeyFrame, frame, ref rq, rtype );
                    result = 2;
                }
            }
            else
            {
                AppMain.nnInterpolateLerpA16_3( ( AppMain.NNS_MOTION_KEY_Class16[] )pKeyList, nKeyFrame, frame, ref rq, rtype );
                result = 2;
            }
        }
        else
        {
            uint num9 = submot.fIPType & 3703U;
            if ( num9 <= 16U )
            {
                switch ( num9 )
                {
                    case 1U:
                    case 3U:
                        break;
                    case 2U:
                        AppMain.nnInterpolateLinearA32_3( ( AppMain.NNS_MOTION_KEY_Class13[] )pKeyList, nKeyFrame, frame, ref rv );
                        result = 1;
                        break;
                    case 4U:
                        AppMain.nnInterpolateConstantA32_3( ( AppMain.NNS_MOTION_KEY_Class13[] )pKeyList, nKeyFrame, frame, ref rv );
                        result = 1;
                        break;
                    default:
                        if ( num9 != 16U )
                        {
                        }
                        break;
                }
            }
            else if ( num9 != 512U )
            {
                if ( num9 != 1024U )
                {
                    if ( num9 == 2048U )
                    {
                        AppMain.nnInterpolateSquadA32_3( ( AppMain.NNS_MOTION_KEY_Class13[] )pKeyList, nKeyFrame, frame, ref rq, rtype );
                        result = 2;
                    }
                }
                else
                {
                    AppMain.nnInterpolateSlerpA32_3( ( AppMain.NNS_MOTION_KEY_Class13[] )pKeyList, nKeyFrame, frame, ref rq, rtype );
                    result = 2;
                }
            }
            else
            {
                AppMain.nnInterpolateLerpA32_3( ( AppMain.NNS_MOTION_KEY_Class13[] )pKeyList, nKeyFrame, frame, ref rq, rtype );
                result = 2;
            }
        }
        return result;
    }

    // Token: 0x0600112A RID: 4394 RVA: 0x00096639 File Offset: 0x00094839
    private static void nnRotateXYZMatrixFast( AppMain.NNS_MATRIX mtx, int ax, int ay, int az )
    {
        AppMain.nnmRotateMatrixFast( mtx, az, 0, 1 );
        AppMain.nnmRotateMatrixFast( mtx, ay, 2, 0 );
        AppMain.nnmRotateMatrixFast( mtx, ax, 1, 2 );
    }

    // Token: 0x0600112B RID: 4395 RVA: 0x00096656 File Offset: 0x00094856
    private static void nnRotateXZYMatrixFast( AppMain.NNS_MATRIX mtx, int ax, int ay, int az )
    {
        AppMain.nnmRotateMatrixFast( mtx, ay, 2, 0 );
        AppMain.nnmRotateMatrixFast( mtx, az, 0, 1 );
        AppMain.nnmRotateMatrixFast( mtx, ax, 1, 2 );
    }

    // Token: 0x0600112C RID: 4396 RVA: 0x00096673 File Offset: 0x00094873
    private static void nnRotateZXYMatrixFast( AppMain.NNS_MATRIX mtx, int ax, int ay, int az )
    {
        AppMain.nnmRotateMatrixFast( mtx, ay, 2, 0 );
        AppMain.nnmRotateMatrixFast( mtx, ax, 1, 2 );
        AppMain.nnmRotateMatrixFast( mtx, az, 0, 1 );
    }

    // Token: 0x0600112D RID: 4397 RVA: 0x00096690 File Offset: 0x00094890
    private static int nnCalcMotionTranslate( AppMain.NNS_SUBMOTION submot, float frame, AppMain.NNS_VECTOR tv )
    {
        int result = 0;
        float num = 0f;
        bool flag = false;
        uint num2 = submot.fType & 1792U;
        object pKeyList = submot.pKeyList;
        int nKeyFrame = submot.nKeyFrame;
        if ( num2 == 1792U )
        {
            uint num3 = submot.fIPType & 3703U;
            switch ( num3 )
            {
                case 1U:
                case 3U:
                    break;
                case 2U:
                    AppMain.nnInterpolateLinearF3( ( AppMain.NNS_MOTION_KEY_Class5[] )pKeyList, nKeyFrame, frame, tv );
                    result = 1;
                    break;
                case 4U:
                    AppMain.nnInterpolateConstantF3( ( AppMain.NNS_MOTION_KEY_Class5[] )pKeyList, nKeyFrame, frame, tv );
                    result = 1;
                    break;
                default:
                    if ( num3 != 16U )
                    {
                    }
                    break;
            }
        }
        else
        {
            uint num4 = num2;
            if ( num4 != 256U )
            {
                if ( num4 != 512U )
                {
                    if ( num4 == 1024U )
                    {
                        flag = true;
                        num = tv.z;
                    }
                }
                else
                {
                    flag = true;
                    num = tv.y;
                }
            }
            else
            {
                flag = true;
                num = tv.x;
            }
            if ( flag )
            {
                uint num5 = submot.fIPType & 3703U;
                switch ( num5 )
                {
                    case 1U:
                    case 3U:
                        break;
                    case 2U:
                        AppMain.nnInterpolateLinearF1( ( AppMain.NNS_MOTION_KEY_Class1[] )pKeyList, nKeyFrame, frame, out num );
                        result = 1;
                        break;
                    case 4U:
                        AppMain.nnInterpolateConstantF1( ( AppMain.NNS_MOTION_KEY_Class1[] )pKeyList, nKeyFrame, frame, out num );
                        result = 1;
                        break;
                    default:
                        if ( num5 != 16U )
                        {
                            if ( num5 == 32U )
                            {
                                AppMain.nnInterpolateSISplineF1( ( AppMain.NNS_MOTION_KEY_Class3[] )pKeyList, nKeyFrame, frame, out num );
                                result = 1;
                            }
                        }
                        else
                        {
                            AppMain.nnInterpolateBezierF1( ( AppMain.NNS_MOTION_KEY_Class2[] )pKeyList, nKeyFrame, frame, out num );
                            result = 1;
                        }
                        break;
                }
                uint num6 = num2;
                if ( num6 != 256U )
                {
                    if ( num6 != 512U )
                    {
                        if ( num6 == 1024U )
                        {
                            tv.z = num;
                        }
                    }
                    else
                    {
                        tv.y = num;
                    }
                }
                else
                {
                    tv.x = num;
                }
            }
        }
        return result;
    }

    // Token: 0x0600112E RID: 4398 RVA: 0x00096834 File Offset: 0x00094A34
    private static void nnTranslateMatrixFast( AppMain.NNS_MATRIX mtx, float x, float y, float z )
    {
        mtx.M03 = mtx.M00 * x + mtx.M01 * y + mtx.M02 * z + mtx.M03;
        mtx.M13 = mtx.M10 * x + mtx.M11 * y + mtx.M12 * z + mtx.M13;
        mtx.M23 = mtx.M20 * x + mtx.M21 * y + mtx.M22 * z + mtx.M23;
    }

    // Token: 0x0600112F RID: 4399 RVA: 0x000968B8 File Offset: 0x00094AB8
    private static int nnCalcMotionScale( AppMain.NNS_SUBMOTION submot, float frame, AppMain.NNS_VECTOR sv )
    {
        int result = 0;
        float num = 0f;
        bool flag = false;
        uint num2 = submot.fType & 229376U;
        object pKeyList = submot.pKeyList;
        int nKeyFrame = submot.nKeyFrame;
        if ( num2 == 229376U )
        {
            uint num3 = submot.fIPType & 3703U;
            switch ( num3 )
            {
                case 1U:
                case 3U:
                    break;
                case 2U:
                    AppMain.nnInterpolateLinearF3( ( AppMain.NNS_MOTION_KEY_Class5[] )pKeyList, nKeyFrame, frame, sv );
                    result = 1;
                    break;
                case 4U:
                    AppMain.nnInterpolateConstantF3( ( AppMain.NNS_MOTION_KEY_Class5[] )pKeyList, nKeyFrame, frame, sv );
                    result = 1;
                    break;
                default:
                    if ( num3 != 16U )
                    {
                    }
                    break;
            }
        }
        else
        {
            uint num4 = num2;
            if ( num4 != 32768U )
            {
                if ( num4 != 65536U )
                {
                    if ( num4 == 131072U )
                    {
                        flag = true;
                        num = sv.z;
                    }
                }
                else
                {
                    flag = true;
                    num = sv.y;
                }
            }
            else
            {
                flag = true;
                num = sv.x;
            }
            if ( flag )
            {
                uint num5 = submot.fIPType & 3703U;
                switch ( num5 )
                {
                    case 1U:
                    case 3U:
                        break;
                    case 2U:
                        AppMain.nnInterpolateLinearF1( ( AppMain.NNS_MOTION_KEY_Class1[] )pKeyList, nKeyFrame, frame, out num );
                        result = 1;
                        break;
                    case 4U:
                        AppMain.nnInterpolateConstantF1( ( AppMain.NNS_MOTION_KEY_Class1[] )pKeyList, nKeyFrame, frame, out num );
                        result = 1;
                        break;
                    default:
                        if ( num5 != 16U )
                        {
                            if ( num5 == 32U )
                            {
                                AppMain.nnInterpolateSISplineF1( ( AppMain.NNS_MOTION_KEY_Class3[] )pKeyList, nKeyFrame, frame, out num );
                                result = 1;
                            }
                        }
                        else
                        {
                            AppMain.nnInterpolateBezierF1( ( AppMain.NNS_MOTION_KEY_Class2[] )pKeyList, nKeyFrame, frame, out num );
                            result = 1;
                        }
                        break;
                }
                uint num6 = num2;
                if ( num6 != 32768U )
                {
                    if ( num6 != 65536U )
                    {
                        if ( num6 == 131072U )
                        {
                            sv.z = num;
                        }
                    }
                    else
                    {
                        sv.y = num;
                    }
                }
                else
                {
                    sv.x = num;
                }
            }
        }
        return result;
    }

    // Token: 0x06001130 RID: 4400 RVA: 0x00096A5C File Offset: 0x00094C5C
    private static void nnScaleMatrixFast( AppMain.NNS_MATRIX mtx, float x, float y, float z )
    {
        mtx.M00 *= x;
        mtx.M01 *= y;
        mtx.M02 *= z;
        mtx.M10 *= x;
        mtx.M11 *= y;
        mtx.M12 *= z;
        mtx.M20 *= x;
        mtx.M21 *= y;
        mtx.M22 *= z;
    }

    // Token: 0x06001131 RID: 4401 RVA: 0x00096AE7 File Offset: 0x00094CE7
    private static void nnCalcMatrixPaletteMotionNode2BoneSIIK( int jnt1nodeIdx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001132 RID: 4402 RVA: 0x00096AEE File Offset: 0x00094CEE
    private static void nnCalcMatrixPaletteMotionNode1BoneSIIK( int jnt1nodeIdx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001133 RID: 4403 RVA: 0x00096AF5 File Offset: 0x00094CF5
    private static void nnCalcMatrixPaletteMotionNode2BoneXSIIK( int rootidx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001134 RID: 4404 RVA: 0x00096AFC File Offset: 0x00094CFC
    private static void nnCalcMatrixPaletteMotionNode1BoneXSIIK( int rootidx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001135 RID: 4405 RVA: 0x00096B04 File Offset: 0x00094D04
    private static void nnCallbackMotionUserData( AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, int SubMotIdx, int NodeIdx, float nframe, float origframe )
    {
        AppMain.NNS_NODEUSRMOT_CALLBACK_VAL nns_NODEUSRMOT_CALLBACK_VAL = new AppMain.NNS_NODEUSRMOT_CALLBACK_VAL();
        nns_NODEUSRMOT_CALLBACK_VAL.iNode = NodeIdx;
        nns_NODEUSRMOT_CALLBACK_VAL.Frame = origframe;
        nns_NODEUSRMOT_CALLBACK_VAL.pMotion = mot;
        nns_NODEUSRMOT_CALLBACK_VAL.iSubmot = SubMotIdx;
        AppMain.NNS_SUBMOTION nns_SUBMOTION = mot.pSubmotion[SubMotIdx];
        nns_NODEUSRMOT_CALLBACK_VAL.fSubmotType = nns_SUBMOTION.fType;
        nns_NODEUSRMOT_CALLBACK_VAL.fSubmotIPType = nns_SUBMOTION.fIPType;
        nns_NODEUSRMOT_CALLBACK_VAL.pObject = obj;
        AppMain.nnCalcMotionUserData( nns_NODEUSRMOT_CALLBACK_VAL, nns_SUBMOTION, nframe );
    }

    // Token: 0x06001136 RID: 4406 RVA: 0x00096B68 File Offset: 0x00094D68
    private static void nnCalcMotionUserData( AppMain.NNS_NODEUSRMOT_CALLBACK_VAL val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nngNodeUserMotionCallbackFunc == null )
        {
            return;
        }
        uint num = submot.fType & 786432U;
        object pKeyList = submot.pKeyList;
        int nKeyFrame = submot.nKeyFrame;
        uint ivalue = 0U;
        float fvalue = 0f;
        if ( ( num & 262144U ) != 0U )
        {
            uint num2 = submot.fIPType & 3703U;
            switch ( num2 )
            {
                case 1U:
                case 3U:
                    break;
                case 2U:
                    AppMain.nnInterpolateLinearU1( ( AppMain.NNS_MOTION_KEY_Class12[] )pKeyList, nKeyFrame, frame, out ivalue );
                    break;
                case 4U:
                    AppMain.nnInterpolateConstantU1( ( AppMain.NNS_MOTION_KEY_Class12[] )pKeyList, nKeyFrame, frame, out ivalue );
                    break;
                default:
                    if ( num2 == 64U )
                    {
                        AppMain.nnSearchTriggerU1( ( AppMain.NNS_MOTION_KEY_Class12[] )pKeyList, nKeyFrame, frame, AppMain.nngNodeUserMotionTriggerTime, AppMain.nngNodeUserMotionCallbackFunc, val );
                        return;
                    }
                    break;
            }
            val.IValue = ivalue;
        }
        else if ( ( num & 524288U ) != 0U )
        {
            uint num3 = submot.fIPType & 3703U;
            switch ( num3 )
            {
                case 1U:
                case 3U:
                    break;
                case 2U:
                    AppMain.nnInterpolateLinearF1( ( AppMain.NNS_MOTION_KEY_Class1[] )pKeyList, nKeyFrame, frame, out fvalue );
                    break;
                case 4U:
                    AppMain.nnInterpolateConstantF1( ( AppMain.NNS_MOTION_KEY_Class1[] )pKeyList, nKeyFrame, frame, out fvalue );
                    break;
                default:
                    if ( num3 != 16U )
                    {
                        if ( num3 == 32U )
                        {
                            AppMain.nnInterpolateSISplineF1( ( AppMain.NNS_MOTION_KEY_Class3[] )pKeyList, nKeyFrame, frame, out fvalue );
                        }
                    }
                    else
                    {
                        AppMain.nnInterpolateBezierF1( ( AppMain.NNS_MOTION_KEY_Class2[] )pKeyList, nKeyFrame, frame, out fvalue );
                    }
                    break;
            }
            val.FValue = fvalue;
        }
        AppMain.nngNodeUserMotionCallbackFunc( val );
    }

    // Token: 0x06001137 RID: 4407 RVA: 0x00096CB4 File Offset: 0x00094EB4
    private static void nnNormalizeColumn0( AppMain.NNS_MATRIX mtx )
    {
        float num = mtx.M00;
        float num2 = num * num;
        num = mtx.M10;
        num2 += num * num;
        num = mtx.M20;
        num2 += num * num;
        float num3 = AppMain.nnInvertSqrt(num2);
        mtx.M00 *= num3;
        mtx.M10 *= num3;
        mtx.M20 *= num3;
    }

    // Token: 0x06001138 RID: 4408 RVA: 0x00096D18 File Offset: 0x00094F18
    private static void nnNormalizeColumn1( AppMain.NNS_MATRIX mtx )
    {
        float num = mtx.M01;
        float num2 = num * num;
        num = mtx.M11;
        num2 += num * num;
        num = mtx.M21;
        num2 += num * num;
        float num3 = AppMain.nnInvertSqrt(num2);
        mtx.M01 *= num3;
        mtx.M11 *= num3;
        mtx.M21 *= num3;
    }

    // Token: 0x06001139 RID: 4409 RVA: 0x00096D7C File Offset: 0x00094F7C
    private static void nnNormalizeColumn2( AppMain.NNS_MATRIX mtx )
    {
        float num = mtx.M02;
        float num2 = num * num;
        num = mtx.M12;
        num2 += num * num;
        num = mtx.M22;
        num2 += num * num;
        float num3 = AppMain.nnInvertSqrt(num2);
        mtx.M02 *= num3;
        mtx.M12 *= num3;
        mtx.M22 *= num3;
    }

    // Token: 0x0600113A RID: 4410 RVA: 0x00096DE0 File Offset: 0x00094FE0
    private static void nnNormalizeColumn3( AppMain.NNS_MATRIX mtx )
    {
        float num = mtx.M03;
        float num2 = num * num;
        num = mtx.M13;
        num2 += num * num;
        num = mtx.M23;
        num2 += num * num;
        float num3 = AppMain.nnInvertSqrt(num2);
        mtx.M03 *= num3;
        mtx.M13 *= num3;
        mtx.M23 *= num3;
    }

    // Token: 0x0600113B RID: 4411 RVA: 0x00096E44 File Offset: 0x00095044
    private static void nnPutFixedMaterialGL()
    {
        OpenGL.glDisable( 2884U );
        OpenGL.glLightModelf( 2898U, 0f );
        OpenGL.glDisable( 2896U );
        AppMain.nnPutFogSwitchGL( false );
        OpenGL.glDepthMask( 1 );
        OpenGL.glColorMask( 1, 1, 1, 1 );
        OpenGL.glDisable( 2903U );
        OpenGL.glEnable( 3042U );
        OpenGL.glBlendFunc( 770U, 771U );
        OpenGL.glBlendEquation( 32774U );
        OpenGL.glDisable( 3058U );
        OpenGL.glDisable( 3008U );
        OpenGL.glEnable( 2929U );
        OpenGL.glDepthFunc( 515U );
        OpenGL.glMaterialfv( 1032U, 4609U, ( OpenGL.glArray4f )AppMain.nngColorWhite );
    }

    // Token: 0x0600113C RID: 4412 RVA: 0x00096EF8 File Offset: 0x000950F8
    private static void nnPutDisableTexturesGL()
    {
        OpenGL.glActiveTexture( 33984U );
        OpenGL.glDisable( 3553U );
        OpenGL.glActiveTexture( 33985U );
        OpenGL.glDisable( 3553U );
        OpenGL.glClientActiveTexture( 33984U );
        OpenGL.glDisableClientState( 32888U );
        OpenGL.glClientActiveTexture( 33985U );
        OpenGL.glDisableClientState( 32888U );
    }

    // Token: 0x0600113D RID: 4413 RVA: 0x00096F55 File Offset: 0x00095155
    private static void nnSetDivColor( float r, float g, float b, float a )
    {
        OpenGL.glColor4f( r, g, b, a );
    }

    // Token: 0x0600113E RID: 4414 RVA: 0x00096F60 File Offset: 0x00095160
    private static void nnSetDivColorRandom( int i )
    {
        Random random = new Random(i * 15485863);
        float red = (float)random.Next() / 32767f;
        float green = (float)random.Next() / 32767f;
        float blue = (float)random.Next() / 32767f;
        OpenGL.glColor3f( red, green, blue );
    }

    // Token: 0x0600113F RID: 4415 RVA: 0x00096FAC File Offset: 0x000951AC
    private static void nnSetDivColorRandomA( int nSeed, uint[] seeds )
    {
        uint num3;
        uint num2;
        uint num = num2 = (num3 = 0U);
        int num4 = 0;
        for ( int i = 0; i < nSeed; i++ )
        {
            num4 ^= ( int )( seeds[i] * 15485863U );
            Random random = new Random(num4);
            num4 ^= random.Next();
            num4 ^= random.Next() << 10;
            num4 ^= random.Next() << 20;
            num2 ^= ( uint )random.Next();
            num ^= ( uint )random.Next();
            num3 ^= ( uint )random.Next();
        }
        OpenGL.glColor3f( num2 / 32767f, num / 32767f, num3 / 32767f );
    }

    // Token: 0x06001140 RID: 4416 RVA: 0x0009704D File Offset: 0x0009524D
    private static void nnPutColorStrip( int iStrip, int iMeshset, int iSubobj )
    {
        AppMain.nnSetDivColorRandom( iStrip * 10007 + iMeshset * 7 + iSubobj );
    }

    // Token: 0x06001141 RID: 4417 RVA: 0x00097061 File Offset: 0x00095261
    private static void nnPutColorMeshset( int iMeshset, int iSubobj )
    {
        AppMain.nnSetDivColorRandom( iMeshset * 7 + iSubobj );
    }

    // Token: 0x06001142 RID: 4418 RVA: 0x0009706D File Offset: 0x0009526D
    private static void nnPutColorMaterial( int iMaterial )
    {
        AppMain.nnSetDivColorRandom( iMaterial );
    }

    // Token: 0x06001143 RID: 4419 RVA: 0x00097078 File Offset: 0x00095278
    private static void nnPutColorNWeight( AppMain.NNS_VTXLISTPTR vlistptr )
    {
        float[][] array = new float[5][];
        array[0] = new float[]
        {
            default(float),
            default(float),
            1f
        };
        float[][] array2 = array;
        int num = 1;
        float[] array3 = new float[3];
        array3[1] = 1f;
        array2[num] = array3;
        float[][] array4 = array;
        int num2 = 2;
        float[] array5 = new float[3];
        array5[0] = 1f;
        array5[1] = 1f;
        array4[num2] = array5;
        array[3] = new float[]
        {
            1f,
            default(float),
            1f
        };
        float[][] array6 = array;
        int num3 = 4;
        float[] array7 = new float[3];
        array7[0] = 1f;
        array6[num3] = array7;
        float[][] array8 = array;
        if ( ( vlistptr.fType & 1U ) != 0U )
        {
            AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = (AppMain.NNS_VTXLIST_GL_DESC)vlistptr.pVtxList;
            int num4 = 0;
            for ( int i = 0; i < nns_VTXLIST_GL_DESC.nArray; i++ )
            {
                AppMain.NNS_VTXARRAY_GL nns_VTXARRAY_GL = nns_VTXLIST_GL_DESC.pArray[i];
                uint type = nns_VTXARRAY_GL.Type;
                if ( type == 4U )
                {
                    num4 = nns_VTXARRAY_GL.Size;
                }
            }
            OpenGL.glColor3fv( array8[num4] );
            return;
        }
        if ( ( vlistptr.fType & 16711680U ) != 0U )
        {
            AppMain.NNS_VTXLIST_COMMON_DESC nns_VTXLIST_COMMON_DESC = (AppMain.NNS_VTXLIST_COMMON_DESC)vlistptr.pVtxList;
            uint num5 = nns_VTXLIST_COMMON_DESC.List0.fType & 15872U;
            if ( num5 <= 512U )
            {
                if ( num5 == 0U )
                {
                    OpenGL.glColor3fv( array8[0] );
                    return;
                }
                if ( num5 != 512U )
                {
                    return;
                }
                OpenGL.glColor3fv( array8[1] );
                return;
            }
            else
            {
                if ( num5 == 1024U )
                {
                    OpenGL.glColor3fv( array8[2] );
                    return;
                }
                if ( num5 == 2048U )
                {
                    OpenGL.glColor3fv( array8[3] );
                    return;
                }
                if ( num5 != 4096U )
                {
                    return;
                }
                OpenGL.glColor3fv( array8[4] );
            }
        }
    }

    // Token: 0x06001144 RID: 4420 RVA: 0x0009720C File Offset: 0x0009540C
    private static void nnPutColorNTexture( int nTexture )
    {
        float[][] array = new float[8][];
        float[][] array2 = array;
        int num = 0;
        float[] array3 = new float[3];
        array2[num] = array3;
        array[1] = new float[]
        {
            default(float),
            default(float),
            1f
        };
        array[2] = new float[]
        {
            default(float),
            1f,
            1f
        };
        float[][] array4 = array;
        int num2 = 3;
        float[] array5 = new float[3];
        array5[1] = 1f;
        array4[num2] = array5;
        float[][] array6 = array;
        int num3 = 4;
        float[] array7 = new float[3];
        array7[0] = 1f;
        array7[1] = 1f;
        array6[num3] = array7;
        float[][] array8 = array;
        int num4 = 5;
        float[] array9 = new float[3];
        array9[0] = 1f;
        array8[num4] = array9;
        array[6] = new float[]
        {
            1f,
            default(float),
            1f
        };
        array[7] = new float[]
        {
            1f,
            1f,
            1f
        };
        float[][] array10 = array;
        if ( nTexture >= array10.Length )
        {
            nTexture = array10.Length - 1;
        }
        OpenGL.glColor3fv( array10[nTexture] );
    }

    // Token: 0x06001530 RID: 5424 RVA: 0x000B8A89 File Offset: 0x000B6C89
    private static void nnSetMaterialControlDiffuse( int mode, float r, float g, float b )
    {
        AppMain.nngMatCtrlDiffuse.mode = mode;
        AppMain.nngMatCtrlDiffuse.col.r = r;
        AppMain.nngMatCtrlDiffuse.col.g = g;
        AppMain.nngMatCtrlDiffuse.col.b = b;
    }

    // Token: 0x06001531 RID: 5425 RVA: 0x000B8AC6 File Offset: 0x000B6CC6
    private static void nnSetMaterialControlAmbient( int mode, float r, float g, float b )
    {
        AppMain.nngMatCtrlAmbient.mode = mode;
        AppMain.nngMatCtrlAmbient.col.r = r;
        AppMain.nngMatCtrlAmbient.col.g = g;
        AppMain.nngMatCtrlAmbient.col.b = b;
    }

    // Token: 0x06001532 RID: 5426 RVA: 0x000B8B03 File Offset: 0x000B6D03
    private void nnSetMaterialControlSpecularGL( int mode, float r, float g, float b )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001533 RID: 5427 RVA: 0x000B8B0A File Offset: 0x000B6D0A
    private static void nnSetMaterialControlAlpha( int mode, float alpha )
    {
        AppMain.nngMatCtrlAlpha.mode = mode;
        AppMain.nngMatCtrlAlpha.alpha = alpha;
    }

    // Token: 0x06001534 RID: 5428 RVA: 0x000B8B22 File Offset: 0x000B6D22
    private static void nnSetMaterialControlEnvTexMatrix( int texsrc, AppMain.NNS_MATRIX texmtx )
    {
        AppMain.nngMatCtrlEnvTexMtx.texcoordsrc = texsrc;
        AppMain.nnCopyMatrix( AppMain.nngMatCtrlEnvTexMtx.texmtx, texmtx );
    }

    // Token: 0x06001535 RID: 5429 RVA: 0x000B8B3F File Offset: 0x000B6D3F
    private static void nnSetMaterialControlBlendMode( int blendmode )
    {
        AppMain.nngMatCtrlBlendMode.blendmode = blendmode;
    }

    // Token: 0x06001536 RID: 5430 RVA: 0x000B8B4C File Offset: 0x000B6D4C
    private static void nnSetMaterialControlTextureOffset( int slot, int mode, float u, float v )
    {
        AppMain.nngMatCtrlTexOffset[slot].mode = mode;
        AppMain.nngMatCtrlTexOffset[slot].offset.u = u;
        AppMain.nngMatCtrlTexOffset[slot].offset.v = v;
    }

    // Token: 0x06001537 RID: 5431 RVA: 0x000B8B7F File Offset: 0x000B6D7F
    private static void nnSetPrimitiveBlend( int blend )
    {
        AppMain.nngDrawPrimBlend = blend;
    }

    // Token: 0x06001538 RID: 5432 RVA: 0x000B8B88 File Offset: 0x000B6D88
    private static void nnSetPrimitiveTexNum( AppMain.NNS_TEXLIST texlist, int num )
    {
        if ( texlist != null && num >= 0 && num < texlist.nTex )
        {
            AppMain.NNS_TEXINFO[] pTexInfoList = texlist.pTexInfoList;
            AppMain.nngDrawPrimTexName = pTexInfoList[num].TexName;
            AppMain.nngDrawPrimTexture = 1;
            return;
        }
        AppMain.nngDrawPrimTexture = 0;
    }

    // Token: 0x06001539 RID: 5433 RVA: 0x000B8BC8 File Offset: 0x000B6DC8
    private static void nnSetPrimitiveTexState( int blend, int coord, int uwrap, int vwrap )
    {
        switch ( blend )
        {
            default:
                AppMain.nngDrawPrimTexBlend = 8448;
                break;
            case 1:
                AppMain.nngDrawPrimTexBlend = 7681;
                break;
        }
        AppMain.nngDrawPrimTexCoord = coord;
        switch ( uwrap )
        {
            default:
                AppMain.nngDrawPrimTexSWarp = 10497;
                break;
            case 1:
                AppMain.nngDrawPrimTexSWarp = 33071;
                break;
        }
        switch ( vwrap )
        {
            default:
                AppMain.nngDrawPrimTexTWarp = 10497;
                return;
            case 1:
                AppMain.nngDrawPrimTexTWarp = 33071;
                return;
        }
    }

    // Token: 0x0600153A RID: 5434 RVA: 0x000B8C4C File Offset: 0x000B6E4C
    private static void nnPutPrimitiveTexParameter()
    {
        OpenGL.glClientActiveTexture( 33985U );
        OpenGL.glDisableClientState( 32888U );
        OpenGL.glClientActiveTexture( 33986U );
        OpenGL.glDisableClientState( 32888U );
        OpenGL.glClientActiveTexture( 33987U );
        OpenGL.glDisableClientState( 32888U );
        OpenGL.glActiveTexture( 33985U );
        OpenGL.glDisable( 3553U );
        OpenGL.glActiveTexture( 33984U );
        OpenGL.glEnable( 3553U );
        OpenGL.glBindTexture( 3553U, AppMain.nngDrawPrimTexName );
        OpenGL.glTexEnvi( 8960U, 8704U, AppMain.nngDrawPrimTexBlend );
        OpenGL.glTexParameteri( 3553U, 10242U, AppMain.nngDrawPrimTexSWarp );
        OpenGL.glTexParameteri( 3553U, 10243U, AppMain.nngDrawPrimTexTWarp );
    }

    // Token: 0x0600153B RID: 5435 RVA: 0x000B8D08 File Offset: 0x000B6F08
    private static void nnPutPrimitiveNoTexture()
    {
        OpenGL.glClientActiveTexture( 33984U );
        OpenGL.glDisableClientState( 32888U );
        OpenGL.glClientActiveTexture( 33985U );
        OpenGL.glDisableClientState( 32888U );
        OpenGL.glActiveTexture( 33984U );
        OpenGL.glDisable( 3553U );
        OpenGL.glActiveTexture( 33985U );
        OpenGL.glDisable( 3553U );
    }

    // Token: 0x0600153C RID: 5436 RVA: 0x000B8D65 File Offset: 0x000B6F65
    private static float NNM_TAYLOR_SIN( float f, float f2 )
    {
        return f * ( 1f + f2 * ( -0.16666667f - f2 * -0.008333334f ) );
    }

    // Token: 0x0600153D RID: 5437 RVA: 0x000B8D7E File Offset: 0x000B6F7E
    private static float NNM_TAYLOR_COS( float f, float f2 )
    {
        return 1f + f2 * ( -0.5f + f2 * ( 0.041666668f + f2 * -0.0013888889f ) );
    }

    // Token: 0x0600153E RID: 5438 RVA: 0x000B8DA0 File Offset: 0x000B6FA0
    private static float nnSin( int ang )
    {
        float result = 0f;
        int num = ang & 65535;
        int num2 = ang & 57344;
        float num3;
        float f;
        if ( num2 <= 24576 )
        {
            if ( num2 <= 8192 )
            {
                if ( num2 == 0 )
                {
                    num3 = AppMain.NNM_A32toRAD( num );
                    f = num3 * num3;
                    return AppMain.NNM_TAYLOR_SIN( num3, f );
                }
                if ( num2 != 8192 )
                {
                    return result;
                }
            }
            else if ( num2 != 16384 )
            {
                if ( num2 != 24576 )
                {
                    return result;
                }
                goto IL_BC;
            }
            num -= 16384;
            num3 = AppMain.NNM_A32toRAD( num );
            f = num3 * num3;
            return AppMain.NNM_TAYLOR_COS( num3, f );
        }
        if ( num2 <= 40960 )
        {
            if ( num2 == 32768 )
            {
                goto IL_BC;
            }
            if ( num2 != 40960 )
            {
                return result;
            }
        }
        else if ( num2 != 49152 )
        {
            if ( num2 != 57344 )
            {
                return result;
            }
            num -= 65536;
            num3 = AppMain.NNM_A32toRAD( num );
            f = num3 * num3;
            return AppMain.NNM_TAYLOR_SIN( num3, f );
        }
        num -= 49152;
        num3 = AppMain.NNM_A32toRAD( num );
        f = num3 * num3;
        return -AppMain.NNM_TAYLOR_COS( num3, f );
        IL_BC:
        num -= 32768;
        num3 = AppMain.NNM_A32toRAD( num );
        f = num3 * num3;
        result = -AppMain.NNM_TAYLOR_SIN( num3, f );
        return result;
    }

    // Token: 0x0600153F RID: 5439 RVA: 0x000B8EC4 File Offset: 0x000B70C4
    private static float nnCos( int ang )
    {
        return AppMain.nnSin( ang + 16384 );
    }

    // Token: 0x06001540 RID: 5440 RVA: 0x000B8EE0 File Offset: 0x000B70E0
    private static void nnCalcSinCosTable()
    {
        for ( int i = 0; i < 36000; i++ )
        {
            int ang = (int)((float)i * 1.8204443f);
            AppMain._nnSinCos( ang, out AppMain.nnSinTable[i], out AppMain.nnCosTable[i] );
        }
    }

    // Token: 0x06001541 RID: 5441 RVA: 0x000B8F24 File Offset: 0x000B7124
    private static void nnSinCos( int ang, out float s, out float c )
    {
        int i;
        for ( i = ( int )Math.Round( ( double )( ( float )ang * 0.5493164f ) ); i > 35999; i -= 36000 )
        {
        }
        while ( i < 0 )
        {
            i += 36000;
        }
        s = AppMain.nnSinTable[i];
        c = AppMain.nnCosTable[i];
    }

    // Token: 0x06001542 RID: 5442 RVA: 0x000B8F74 File Offset: 0x000B7174
    private static void _nnSinCos( int ang, out float s, out float c )
    {
        if ( ang == 0 )
        {
            s = 0f;
            c = 1f;
        }
        int num = ang & 65535;
        c = 0f;
        s = 0f;
        int num2 = ang & 57344;
        float num3;
        float f;
        if ( num2 <= 24576 )
        {
            if ( num2 <= 8192 )
            {
                if ( num2 == 0 )
                {
                    num3 = AppMain.NNM_A32toRAD( num );
                    f = num3 * num3;
                    s = AppMain.NNM_TAYLOR_SIN( num3, f );
                    c = AppMain.NNM_TAYLOR_COS( num3, f );
                    return;
                }
                if ( num2 != 8192 )
                {
                    return;
                }
            }
            else if ( num2 != 16384 )
            {
                if ( num2 != 24576 )
                {
                    return;
                }
                goto IL_D2;
            }
            num -= 16384;
            num3 = AppMain.NNM_A32toRAD( num );
            f = num3 * num3;
            s = AppMain.NNM_TAYLOR_COS( num3, f );
            c = -AppMain.NNM_TAYLOR_SIN( num3, f );
            return;
        }
        if ( num2 <= 40960 )
        {
            if ( num2 == 32768 )
            {
                goto IL_D2;
            }
            if ( num2 != 40960 )
            {
                return;
            }
        }
        else if ( num2 != 49152 )
        {
            if ( num2 != 57344 )
            {
                return;
            }
            num -= 65536;
            num3 = AppMain.NNM_A32toRAD( num );
            f = num3 * num3;
            s = AppMain.NNM_TAYLOR_SIN( num3, f );
            c = AppMain.NNM_TAYLOR_COS( num3, f );
            return;
        }
        num -= 49152;
        num3 = AppMain.NNM_A32toRAD( num );
        f = num3 * num3;
        s = -AppMain.NNM_TAYLOR_COS( num3, f );
        c = AppMain.NNM_TAYLOR_SIN( num3, f );
        return;
        IL_D2:
        num -= 32768;
        num3 = AppMain.NNM_A32toRAD( num );
        f = num3 * num3;
        s = -AppMain.NNM_TAYLOR_SIN( num3, f );
        c = -AppMain.NNM_TAYLOR_COS( num3, f );
    }

    // Token: 0x0600001B RID: 27 RVA: 0x00002606 File Offset: 0x00000806
    private void nnSetNodeUserMotionCallback( AppMain.NNS_NODEUSRMOT_CALLBACK_FUNC func )
    {
        AppMain.nngNodeUserMotionCallbackFunc = func;
    }

    // Token: 0x0600001C RID: 28 RVA: 0x0000260E File Offset: 0x0000080E
    private AppMain.NNS_NODEUSRMOT_CALLBACK_FUNC nnGetNodeUserMotionCallback()
    {
        return AppMain.nngNodeUserMotionCallbackFunc;
    }

    // Token: 0x0600001D RID: 29 RVA: 0x00002615 File Offset: 0x00000815
    private void nnSetNodeUserMotionTriggerTime( float t )
    {
        AppMain.nngNodeUserMotionTriggerTime = t;
    }

    // Token: 0x0600001E RID: 30 RVA: 0x00002620 File Offset: 0x00000820
    private static void nnSetUpNodeStatusList( uint[] nodestatlist, int num, uint flag )
    {
        for ( int i = 0; i < num; i++ )
        {
            nodestatlist[i] = flag;
        }
    }

    // Token: 0x0600001F RID: 31 RVA: 0x00002640 File Offset: 0x00000840
    private static void nnCalcNodeStatusListMatrixPaletteNode( int nodeIdx )
    {
        AppMain.mppAssertNotImpl();
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_NODE nns_NODE;
        do
        {
            nns_NODE = AppMain.nnnodestatuslist.nnsNodeList[nodeIdx];
            int iMatrix = (int)nns_NODE.iMatrix;
            if ( iMatrix != -1 )
            {
                AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.nnnodestatuslist.nnsMtxPal[iMatrix];
                if ( ( nns_NODE.fType & 8U ) != 0U )
                {
                    AppMain.nnCopyMatrix( nns_MATRIX, nns_MATRIX3 );
                }
                if ( ( nns_NODE.fType & 128U ) != 0U )
                {
                    AppMain.nnInvertOrthoMatrix( nns_MATRIX2, nns_NODE.InvInitMtx );
                    AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX3, nns_MATRIX2 );
                }
                else
                {
                    AppMain.nnInvertMatrix( nns_MATRIX2, nns_NODE.InvInitMtx );
                    AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX3, nns_MATRIX2 );
                }
                AppMain.nnCalcClipSetNodeStatus( AppMain.nnnodestatuslist.nnsNodeStatList, AppMain.nnnodestatuslist.nnsNodeList, nodeIdx, nns_MATRIX, 1f, AppMain.nnnodestatuslist.nnsNSFlag );
            }
            if ( nns_NODE.iChild != -1 )
            {
                AppMain.nnCalcNodeStatusListMatrixPaletteNode( ( int )nns_NODE.iChild );
            }
            nodeIdx = ( int )nns_NODE.iSibling;
        }
        while ( nns_NODE.iSibling != -1 );
    }

    // Token: 0x06000020 RID: 32 RVA: 0x00002709 File Offset: 0x00000909
    private static void nnCalcNodeStatusListMatrixPalette( uint[] nodestatlist, AppMain.NNS_MATRIX[] mtxpal, AppMain.NNS_OBJECT obj, uint flag )
    {
        AppMain.nnnodestatuslist.nnsMtxPal = mtxpal;
        AppMain.nnnodestatuslist.nnsNodeStatList = nodestatlist;
        AppMain.nnnodestatuslist.nnsNodeList = obj.pNodeList;
        AppMain.nnnodestatuslist.nnsNSFlag = flag;
        AppMain.nnCalcNodeStatusListMatrixPaletteNode( 0 );
    }

    // Token: 0x06000021 RID: 33 RVA: 0x0000272E File Offset: 0x0000092E
    public static bool NNM_NODE_IS_SIIK( uint _nodetype )
    {
        return ( _nodetype & 235134976U ) != 0U && ( _nodetype & 134217728U ) == 0U;
    }

    // Token: 0x06000022 RID: 34 RVA: 0x00002745 File Offset: 0x00000945
    public static bool NNM_NODE_IS_XSIIK( uint _nodetype )
    {
        return ( _nodetype & 134217728U ) != 0U;
    }

    // Token: 0x06000023 RID: 35 RVA: 0x00002754 File Offset: 0x00000954
    private void nnDrawMultiObjectInitialPoseBaseMatrixList( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtxlist, uint[] nodestatlistptrlist, uint subobjtype, uint flag, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000024 RID: 36 RVA: 0x0000275C File Offset: 0x0000095C
    public static void nnmRotateMatrixFast( AppMain.NNS_MATRIX mtx, int ang, int ma, int mb )
    {
        if ( ang != 0 )
        {
            float num;
            float num2;
            AppMain.nnSinCos( ang, out num, out num2 );
            float num3 = num;
            float num4 = num2;
            float num5 = mtx.M(0, ma);
            float num6 = mtx.M(0, mb);
            mtx.SetM( 0, ma, num5 * num4 + num6 * num3 );
            mtx.SetM( 0, mb, num5 * -num3 + num6 * num4 );
            float num7 = mtx.M(1, ma);
            float num8 = mtx.M(1, mb);
            mtx.SetM( 1, ma, num7 * num4 + num8 * num3 );
            mtx.SetM( 1, mb, num7 * -num3 + num8 * num4 );
            num5 = mtx.M( 2, ma );
            num6 = mtx.M( 2, mb );
            mtx.SetM( 2, ma, num5 * num4 + num6 * num3 );
            mtx.SetM( 2, mb, num5 * -num3 + num6 * num4 );
        }
    }

    // Token: 0x06000137 RID: 311 RVA: 0x0000E5B7 File Offset: 0x0000C7B7
    private void nnSetBoneColor( ref AppMain.NNS_RGBA pDiff, AppMain.NNS_RGB pAmb, ref AppMain.NNS_RGBA pWire )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000138 RID: 312 RVA: 0x0000E5BE File Offset: 0x0000C7BE
    private void nnDrawOneBoneData( float bonelength, AppMain.NNS_MATRIX mtx, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000139 RID: 313 RVA: 0x0000E5C5 File Offset: 0x0000C7C5
    private void nnSetEffectorColor( ref AppMain.NNS_RGBA pXcol, ref AppMain.NNS_RGBA pYcol, ref AppMain.NNS_RGBA pZcol )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600013A RID: 314 RVA: 0x0000E5CC File Offset: 0x0000C7CC
    private void nnDrawEffector( AppMain.NNS_VECTOR p, AppMain.NNS_MATRIX mtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600013B RID: 315 RVA: 0x0000E5D4 File Offset: 0x0000C7D4
    private void nnDrawSIIKBone( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIX mtxlist, uint flag )
    {
        new AppMain.NNS_RGBA( 1f, 1f, 1f, 0.5f );
        new AppMain.NNS_RGBA( 1f, 0f, 0f, 0.5f );
        new AppMain.NNS_RGBA( 0f, 1f, 0f, 0.5f );
        new AppMain.NNS_RGBA( 0f, 0f, 1f, 0.5f );
        new AppMain.NNS_RGBA( 1f, 1f, 0f, 0.5f );
        new AppMain.NNS_RGBA( 1f, 1f, 1f, 1f );
        new AppMain.NNS_RGB( 0.2f, 0.2f, 0.2f );
        new AppMain.NNS_RGBA( 1f, 1f, 1f, 1f );
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600013C RID: 316 RVA: 0x0000E6B1 File Offset: 0x0000C8B1
    private void nnMakeNodeTreeMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR vec, AppMain.NNS_VECTOR trans )
    {
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600013D RID: 317 RVA: 0x0000E6CA File Offset: 0x0000C8CA
    private void nnDrawNodeTree( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIX mtxlist, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600013E RID: 318 RVA: 0x0000E6D1 File Offset: 0x0000C8D1
    private void nnDrawAxis( AppMain.NNS_VECTOR p, float length, AppMain.NNS_MATRIX mtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600013F RID: 319 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
    private uint nnCalcGridBufferSize( int Xnum, int Znum )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000140 RID: 320 RVA: 0x0000E6E0 File Offset: 0x0000C8E0
    private void nnInitGrid( AppMain.NNS_VECTOR pBuf, int Xnum, int Znum )
    {
        this.nngGridPos = pBuf;
        this.nngGridXnum = Xnum;
        this.nngGridZnum = Znum;
    }

    // Token: 0x06000141 RID: 321 RVA: 0x0000E6F7 File Offset: 0x0000C8F7
    private void nnDrawGrid( AppMain.NNS_VECTOR p, float length, AppMain.NNS_MATRIX mtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000142 RID: 322 RVA: 0x0000E6FE File Offset: 0x0000C8FE
    private void nnDrawGridPlane( int Xnum, int Znum, float length, AppMain.NNS_MATRIX mtx, ref AppMain.NNS_RGBA pcolor )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000143 RID: 323 RVA: 0x0000E705 File Offset: 0x0000C905
    public static void nnmSetUpVectorFast( out AppMain.NNS_VECTORFAST dst, float x, float y, float z )
    {
        dst.x = x;
        dst.y = y;
        dst.z = z;
        dst.w = 1f;
    }

    // Token: 0x06000144 RID: 324 RVA: 0x0000E727 File Offset: 0x0000C927
    public static void nnSetUpVectorFast( out AppMain.NNS_VECTORFAST dst, float x, float y, float z )
    {
        dst.x = x;
        dst.y = y;
        dst.z = z;
        dst.w = 1f;
    }

    // Token: 0x06000145 RID: 325 RVA: 0x0000E749 File Offset: 0x0000C949
    public static void nnAddVector( ref AppMain.SNNS_VECTOR dst, ref AppMain.SNNS_VECTOR vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x06000146 RID: 326 RVA: 0x0000E784 File Offset: 0x0000C984
    public static void nnAddVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x06000147 RID: 327 RVA: 0x0000E7BF File Offset: 0x0000C9BF
    public static void nnAddVector( ref AppMain.Vector3f dst, ref AppMain.SNNS_VECTOR vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x06000148 RID: 328 RVA: 0x0000E7FA File Offset: 0x0000C9FA
    public static void nnAddVector( ref AppMain.Vector3f dst, ref AppMain.SNNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x06000149 RID: 329 RVA: 0x0000E835 File Offset: 0x0000CA35
    public static void nnAddVector( ref AppMain.Vector3f dst, AppMain.NNS_VECTOR vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x0600014A RID: 330 RVA: 0x0000E870 File Offset: 0x0000CA70
    public static void nnAddVector( ref AppMain.Vector3f dst, AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x0600014B RID: 331 RVA: 0x0000E8AB File Offset: 0x0000CAAB
    public static void nnAddVector( ref AppMain.Vector3f dst, ref AppMain.Vector3f vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x0600014C RID: 332 RVA: 0x0000E8E6 File Offset: 0x0000CAE6
    public static void nnAddVector( ref AppMain.Vector3f dst, ref AppMain.Vector3f vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        dst.x = vec1.x + vec2.x;
        dst.y = vec1.y + vec2.y;
        dst.z = vec1.z + vec2.z;
    }

    // Token: 0x0600014D RID: 333 RVA: 0x0000E924 File Offset: 0x0000CB24
    public static void nnCrossProductVector( ref AppMain.SNNS_VECTOR dst, ref AppMain.SNNS_VECTOR vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        float x = vec1.y * vec2.z - vec1.z * vec2.y;
        float y = vec1.z * vec2.x - vec1.x * vec2.z;
        float z = vec1.x * vec2.y - vec1.y * vec2.x;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x0600014E RID: 334 RVA: 0x0000E99C File Offset: 0x0000CB9C
    public static void nnCrossProductVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        float x = vec1.y * vec2.z - vec1.z * vec2.y;
        float y = vec1.z * vec2.x - vec1.x * vec2.z;
        float z = vec1.x * vec2.y - vec1.y * vec2.x;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x0600014F RID: 335 RVA: 0x0000EA12 File Offset: 0x0000CC12
    public static void nnCopyVector( AppMain.NNS_VECTOR dst, ref AppMain.SNNS_VECTOR src )
    {
        dst.Assign( ref src );
    }

    // Token: 0x06000150 RID: 336 RVA: 0x0000EA1C File Offset: 0x0000CC1C
    public static void nnCopyVector( AppMain.NNS_VECTOR dst, ref AppMain.SNNS_VECTOR4D src )
    {
        dst.Assign( ref src );
    }

    // Token: 0x06000151 RID: 337 RVA: 0x0000EA26 File Offset: 0x0000CC26
    public static void nnCopyVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR src )
    {
        dst.Assign( src );
    }

    // Token: 0x06000152 RID: 338 RVA: 0x0000EA30 File Offset: 0x0000CC30
    public static float nnDotProductVector( AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        return vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;
    }

    // Token: 0x06000153 RID: 339 RVA: 0x0000EA68 File Offset: 0x0000CC68
    public static float nnLengthVector( AppMain.NNS_VECTOR vec )
    {
        return AppMain.nnSqrt( vec.x * vec.x + vec.y * vec.y + vec.z * vec.z );
    }

    // Token: 0x06000154 RID: 340 RVA: 0x0000EAA8 File Offset: 0x0000CCA8
    public static float nnDistanceVector( AppMain.NNS_VECTOR vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        float num = vec2.x - vec1.x;
        float num2 = vec2.y - vec1.y;
        float num3 = vec2.z - vec1.z;
        return AppMain.nnSqrt( num * num + num2 * num2 + num3 * num3 );
    }

    // Token: 0x06000155 RID: 341 RVA: 0x0000EAF0 File Offset: 0x0000CCF0
    public static float nnDistanceVector( ref AppMain.SNNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        float num = vec2.x - vec1.x;
        float num2 = vec2.y - vec1.y;
        float num3 = vec2.z - vec1.z;
        return AppMain.nnSqrt( num * num + num2 * num2 + num3 * num3 );
    }

    // Token: 0x06000156 RID: 342 RVA: 0x0000EB38 File Offset: 0x0000CD38
    public static float nnDistanceVector( AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        float num = vec2.x - vec1.x;
        float num2 = vec2.y - vec1.y;
        float num3 = vec2.z - vec1.z;
        return AppMain.nnSqrt( num * num + num2 * num2 + num3 * num3 );
    }

    // Token: 0x06000157 RID: 343 RVA: 0x0000EB80 File Offset: 0x0000CD80
    public static float nnDistanceVector( ref AppMain.Vector3f vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        float num = vec2.x - vec1.x;
        float num2 = vec2.y - vec1.y;
        float num3 = vec2.z - vec1.z;
        return AppMain.nnSqrt( num * num + num2 * num2 + num3 * num3 );
    }

    // Token: 0x06000158 RID: 344 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
    public static float nnDistanceVector( ref AppMain.Vector3f vec1, AppMain.NNS_VECTOR vec2 )
    {
        float num = vec2.x - vec1.x;
        float num2 = vec2.y - vec1.y;
        float num3 = vec2.z - vec1.z;
        return AppMain.nnSqrt( num * num + num2 * num2 + num3 * num3 );
    }

    // Token: 0x06000159 RID: 345 RVA: 0x0000EC10 File Offset: 0x0000CE10
    public static float nnLengthSqVector( AppMain.NNS_VECTOR vec )
    {
        return vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;
    }

    // Token: 0x0600015A RID: 346 RVA: 0x0000EC48 File Offset: 0x0000CE48
    public static float nnLengthSqVector( ref AppMain.SNNS_VECTOR vec )
    {
        return vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;
    }

    // Token: 0x0600015B RID: 347 RVA: 0x0000EC80 File Offset: 0x0000CE80
    public static float nnLengthSqVector( float[] vec )
    {
        return vec[0] * vec[0] + vec[1] * vec[1] + vec[2] * vec[2];
    }

    // Token: 0x0600015C RID: 348 RVA: 0x0000ECA8 File Offset: 0x0000CEA8
    public static float nnLengthSqVector( ref OpenGL.glArray4f vec )
    {
        return vec.f0 * vec.f0 + vec.f1 * vec.f1 + vec.f2 * vec.f2;
    }

    // Token: 0x0600015D RID: 349 RVA: 0x0000ECE0 File Offset: 0x0000CEE0
    public static float nnDistanceSqVector( AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        float num = vec2.x - vec1.x;
        float num2 = vec2.y - vec1.y;
        float num3 = vec2.z - vec1.z;
        return num * num + num2 * num2 + num3 * num3;
    }

    // Token: 0x0600015E RID: 350 RVA: 0x0000ED24 File Offset: 0x0000CF24
    public static int nnNormalizeVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR src )
    {
        float num = AppMain.nnLengthSqVector(src);
        if ( num == 0f )
        {
            dst.x = 0f;
            dst.y = 0f;
            dst.z = 0f;
            return 0;
        }
        num = AppMain.nnInvertSqrt( num );
        dst.x = src.x * num;
        dst.y = src.y * num;
        dst.z = src.z * num;
        return 1;
    }

    // Token: 0x0600015F RID: 351 RVA: 0x0000ED98 File Offset: 0x0000CF98
    public static int nnNormalizeVector( ref AppMain.SNNS_VECTOR dst, ref AppMain.SNNS_VECTOR src )
    {
        float num = AppMain.nnLengthSqVector(ref src);
        if ( num == 0f )
        {
            dst.x = 0f;
            dst.y = 0f;
            dst.z = 0f;
            return 0;
        }
        num = AppMain.nnInvertSqrt( num );
        dst.x = src.x * num;
        dst.y = src.y * num;
        dst.z = src.z * num;
        return 1;
    }

    // Token: 0x06000160 RID: 352 RVA: 0x0000EE0C File Offset: 0x0000D00C
    public static int nnNormalizeVector( float[] dst, float[] src )
    {
        float num = AppMain.nnLengthSqVector(src);
        if ( num == 0f )
        {
            dst[0] = 0f;
            dst[1] = 0f;
            dst[2] = 0f;
            return 0;
        }
        num = AppMain.nnInvertSqrt( num );
        dst[0] = src[0] * num;
        dst[1] = src[1] * num;
        dst[2] = src[2] * num;
        return 1;
    }

    // Token: 0x06000161 RID: 353 RVA: 0x0000EE64 File Offset: 0x0000D064
    public static int nnNormalizeVector( ref OpenGL.glArray4f dst, ref OpenGL.glArray4f src )
    {
        float num = AppMain.nnLengthSqVector(ref src);
        if ( num == 0f )
        {
            dst.f0 = 0f;
            dst.f1 = 0f;
            dst.f2 = 0f;
            return 0;
        }
        num = AppMain.nnInvertSqrt( num );
        dst.f0 = src.f0 * num;
        dst.f1 = src.f1 * num;
        dst.f2 = src.f2 * num;
        return 1;
    }

    // Token: 0x06000162 RID: 354 RVA: 0x0000EED5 File Offset: 0x0000D0D5
    public static void nnScaleVector( ref AppMain.SNNS_VECTOR dst, ref AppMain.SNNS_VECTOR src, float scale )
    {
        dst.x = src.x * scale;
        dst.y = src.y * scale;
        dst.z = src.z * scale;
    }

    // Token: 0x06000163 RID: 355 RVA: 0x0000EF01 File Offset: 0x0000D101
    public static void nnScaleVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR src, float scale )
    {
        dst.x = src.x * scale;
        dst.y = src.y * scale;
        dst.z = src.z * scale;
    }

    // Token: 0x06000164 RID: 356 RVA: 0x0000EF30 File Offset: 0x0000D130
    public static void nnScaleAddVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2, float scale )
    {
        float num = vec2.x * scale;
        float num2 = vec2.y * scale;
        float num3 = vec2.z * scale;
        dst.x = vec1.x + num;
        dst.y = vec1.y + num2;
        dst.z = vec1.z + num3;
    }

    // Token: 0x06000165 RID: 357 RVA: 0x0000EF82 File Offset: 0x0000D182
    public static void nnSubtractVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x - vec2.x;
        dst.y = vec1.y - vec2.y;
        dst.z = vec1.z - vec2.z;
    }

    // Token: 0x06000166 RID: 358 RVA: 0x0000EFBD File Offset: 0x0000D1BD
    public static void nnSubtractVector( ref AppMain.Vector3f dst, AppMain.NNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x - vec2.x;
        dst.y = vec1.y - vec2.y;
        dst.z = vec1.z - vec2.z;
    }

    // Token: 0x06000167 RID: 359 RVA: 0x0000EFF8 File Offset: 0x0000D1F8
    public static void nnSubtractVector( ref AppMain.Vector3f dst, ref AppMain.SNNS_VECTOR vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x - vec2.x;
        dst.y = vec1.y - vec2.y;
        dst.z = vec1.z - vec2.z;
    }

    // Token: 0x06000168 RID: 360 RVA: 0x0000F033 File Offset: 0x0000D233
    public static void nnSubtractVector( ref AppMain.Vector3f dst, ref AppMain.SNNS_VECTOR vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        dst.x = vec1.x - vec2.x;
        dst.y = vec1.y - vec2.y;
        dst.z = vec1.z - vec2.z;
    }

    // Token: 0x06000169 RID: 361 RVA: 0x0000F06E File Offset: 0x0000D26E
    public static void nnSubtractVector( ref AppMain.Vector3f dst, ref AppMain.Vector3f vec1, AppMain.NNS_VECTOR vec2 )
    {
        dst.x = vec1.x - vec2.x;
        dst.y = vec1.y - vec2.y;
        dst.z = vec1.z - vec2.z;
    }

    // Token: 0x0600016A RID: 362 RVA: 0x0000F0A9 File Offset: 0x0000D2A9
    public static void nnSubtractVector( ref AppMain.Vector3f dst, ref AppMain.Vector3f vec1, ref AppMain.SNNS_VECTOR vec2 )
    {
        dst.x = vec1.x - vec2.x;
        dst.y = vec1.y - vec2.y;
        dst.z = vec1.z - vec2.z;
    }

    // Token: 0x0600016B RID: 363 RVA: 0x0000F0E4 File Offset: 0x0000D2E4
    private static void nnTransformVector( ref AppMain.SNNS_VECTOR dst, ref AppMain.SNNS_MATRIX mtx, ref AppMain.SNNS_VECTOR src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x0600016C RID: 364 RVA: 0x0000F19C File Offset: 0x0000D39C
    private static void nnTransformVector( AppMain.NNS_VECTOR dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x0600016D RID: 365 RVA: 0x0000F254 File Offset: 0x0000D454
    private static void nnTransformVector( ref AppMain.Vector3f dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x0600016E RID: 366 RVA: 0x0000F30C File Offset: 0x0000D50C
    private static void nnTransformVector( ref AppMain.Vector3f dst, ref AppMain.SNNS_MATRIX mtx, ref AppMain.SNNS_VECTOR src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x0600016F RID: 367 RVA: 0x0000F3C4 File Offset: 0x0000D5C4
    private static void nnTransformVector( ref AppMain.Vector3f dst, AppMain.NNS_MATRIX mtx, ref AppMain.SNNS_VECTOR src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000170 RID: 368 RVA: 0x0000F47C File Offset: 0x0000D67C
    private static void nnTransformVector( ref AppMain.Vector3f dst, AppMain.NNS_MATRIX mtx, ref AppMain.Vector3f src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000171 RID: 369 RVA: 0x0000F534 File Offset: 0x0000D734
    private static void nnTransformVector( AppMain.NNS_VECTOR4D dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR4D src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000172 RID: 370 RVA: 0x0000F5EC File Offset: 0x0000D7EC
    private static void nnTransformVector( ref AppMain.SNNS_VECTOR4D dst, AppMain.NNS_MATRIX mtx, ref AppMain.SNNS_VECTOR4D src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000173 RID: 371 RVA: 0x0000F6A4 File Offset: 0x0000D8A4
    private static void nnTransformNormalVector( AppMain.NNS_VECTOR dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000174 RID: 372 RVA: 0x0000F744 File Offset: 0x0000D944
    private static void nnTransformNormalVector( AppMain.NNS_VECTOR4D dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR4D src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000175 RID: 373 RVA: 0x0000F7E4 File Offset: 0x0000D9E4
    private static void nnTransformNormalVector( ref AppMain.SNNS_VECTOR4D dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR4D src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000176 RID: 374 RVA: 0x0000F884 File Offset: 0x0000DA84
    private static void nnTransformNormalVector( ref AppMain.SNNS_VECTOR4D dst, AppMain.NNS_MATRIX mtx, ref AppMain.SNNS_VECTOR4D src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000177 RID: 375 RVA: 0x0000F924 File Offset: 0x0000DB24
    private static void nnTransformNormalVector( AppMain.NNS_VECTOR4D dst, AppMain.NNS_MATRIX mtx, ref AppMain.SNNS_VECTOR4D src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z;
        dst.x = x;
        dst.y = y;
        dst.z = z;
    }

    // Token: 0x06000178 RID: 376 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
    private static void nnCopyMatrixTranslationVector( AppMain.NNS_VECTOR dst, AppMain.NNS_MATRIX mtx )
    {
        dst.x = mtx.M03;
        dst.y = mtx.M13;
        dst.z = mtx.M23;
    }

    // Token: 0x06000179 RID: 377 RVA: 0x0000F9EA File Offset: 0x0000DBEA
    private static void nnCopyMatrixTranslationVector( out AppMain.SNNS_VECTOR dst, AppMain.NNS_MATRIX mtx )
    {
        dst.x = mtx.M03;
        dst.y = mtx.M13;
        dst.z = mtx.M23;
    }

    // Token: 0x0600017A RID: 378 RVA: 0x0000FA10 File Offset: 0x0000DC10
    private static void nnCopyMatrixTranslationVector( out AppMain.SNNS_VECTOR dst, ref AppMain.SNNS_MATRIX mtx )
    {
        dst.x = mtx.M03;
        dst.y = mtx.M13;
        dst.z = mtx.M23;
    }

    // Token: 0x0600017B RID: 379 RVA: 0x0000FA36 File Offset: 0x0000DC36
    private static void nnCopyMatrixTranslationVector( AppMain.NNS_VECTOR dst, ref AppMain.SNNS_MATRIX mtx )
    {
        dst.x = mtx.M03;
        dst.y = mtx.M13;
        dst.z = mtx.M23;
    }

    // Token: 0x0600017C RID: 380 RVA: 0x0000FA5C File Offset: 0x0000DC5C
    private static void nnSubtractVectorFast( out AppMain.NNS_VECTORFAST dst, AppMain.NNS_VECTORFAST vec1, AppMain.NNS_VECTORFAST vec2 )
    {
        float x = vec1.x - vec2.x;
        float y = vec1.y - vec2.y;
        float z = vec1.z - vec2.z;
        AppMain.nnmSetUpVectorFast( out dst, x, y, z );
    }

    // Token: 0x0600017D RID: 381 RVA: 0x0000FAA4 File Offset: 0x0000DCA4
    private static void nnTransformVectorFast( out AppMain.NNS_VECTORFAST dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTORFAST src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z + mtx.M03;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z + mtx.M13;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z + mtx.M23;
        AppMain.nnmSetUpVectorFast( out dst, x, y, z );
    }

    // Token: 0x0600017E RID: 382 RVA: 0x0000FB58 File Offset: 0x0000DD58
    private static void nnTransformNormalVectorFast( out AppMain.NNS_VECTORFAST dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTORFAST src )
    {
        float x = mtx.M00 * src.x + mtx.M01 * src.y + mtx.M02 * src.z;
        float y = mtx.M10 * src.x + mtx.M11 * src.y + mtx.M12 * src.z;
        float z = mtx.M20 * src.x + mtx.M21 * src.y + mtx.M22 * src.z;
        AppMain.nnmSetUpVectorFast( out dst, x, y, z );
    }

    // Token: 0x0600017F RID: 383 RVA: 0x0000FBF5 File Offset: 0x0000DDF5
    private static void nnCopyMatrixTranslationVectorFast( out AppMain.NNS_VECTORFAST dst, AppMain.NNS_MATRIX mtx )
    {
        dst.x = mtx.M03;
        dst.y = mtx.M13;
        dst.z = mtx.M23;
        dst.w = 1f;
    }

    // Token: 0x06000180 RID: 384 RVA: 0x0000FC28 File Offset: 0x0000DE28
    private static float nnLengthSqVectorFast( ref AppMain.NNS_VECTORFAST vec )
    {
        return vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;
    }

    // Token: 0x06000181 RID: 385 RVA: 0x0000FC60 File Offset: 0x0000DE60
    private static float nnDotProductVectorFast( ref AppMain.NNS_VECTORFAST vec1, ref AppMain.NNS_VECTORFAST vec2 )
    {
        return vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;
    }

    // Token: 0x06000182 RID: 386 RVA: 0x0000FC98 File Offset: 0x0000DE98
    private static void nnSetTexCoordSrc( int slot, int src )
    {
        AppMain.nnsTexCoordSrc[slot] = src;
    }

    // Token: 0x06000183 RID: 387 RVA: 0x0000FCA2 File Offset: 0x0000DEA2
    private static int nnGetTexCoordSrc( int slot )
    {
        return AppMain.nnsTexCoordSrc[slot];
    }

    // Token: 0x06000184 RID: 388 RVA: 0x0000FCAB File Offset: 0x0000DEAB
    private static void nnSetNormalFormatType( uint ftype )
    {
        AppMain.nnsNormalFormatType = ftype;
    }

    // Token: 0x06000185 RID: 389 RVA: 0x0000FCB3 File Offset: 0x0000DEB3
    private uint nnGetNormalFormatType()
    {
        return AppMain.nnsNormalFormatType;
    }

    // Token: 0x06000186 RID: 390 RVA: 0x0000FCBC File Offset: 0x0000DEBC
    private static void nnPutEnvironmentTextureMatrix( AppMain.NNS_MATRIX pEnvMtx )
    {
        if ( AppMain.nnsTexCoordSrc[0] != 3 && AppMain.nnsTexCoordSrc[1] != 3 )
        {
            return;
        }
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.nnMakeTranslateMatrix( nns_MATRIX, 0.5f, 0.5f, 0f );
        AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, 0.5f, -0.5f, 0f );
        if ( pEnvMtx != null )
        {
            AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
            AppMain.nnCopyMatrix( nns_MATRIX2, pEnvMtx );
            nns_MATRIX2.M03 = 0f;
            nns_MATRIX2.M13 = 0f;
            AppMain.nnMultiplyMatrix( nns_MATRIX, nns_MATRIX, nns_MATRIX2 );
        }
        uint num = AppMain.nnsNormalFormatType;
        if ( num == 5122U )
        {
            AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, 3.0518044E-05f, 3.0518044E-05f, 3.0518044E-05f );
            AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, 0.5f, 0.5f, 0.5f );
        }
        OpenGL.glMatrixMode( 5890U );
        for ( int i = 0; i < 2; i++ )
        {
            if ( AppMain.nnsTexCoordSrc[i] == 3 )
            {
                OpenGL.glActiveTexture( AppMain.NNM_GL_TEXTURE( i ) );
                Matrix matrix = (Matrix)nns_MATRIX;
                OpenGL.glLoadMatrixf( ref matrix );
            }
        }
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Release( nns_MATRIX );
    }

    // Token: 0x06000187 RID: 391 RVA: 0x0000FDB8 File Offset: 0x0000DFB8
    private static void nnDrawObjectVertexList( AppMain.NNS_VTXLISTPTR vlistptr, uint flag )
    {
        AppMain.nnDrawObjectVertexList( vlistptr, flag, 0U );
    }

    // Token: 0x06000188 RID: 392 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
    private static void nnMPPVerifyAlternativeLightingSettings()
    {
        OpenGL.BufferItem bufferItem = OpenGL.m_buffers[OpenGL.m_boundArrayBuffer];
        OpenGL.VertexBufferDesc vertexBufferDesc = (OpenGL.VertexBufferDesc)bufferItem.buffer;
        VertexBuffer buffer = vertexBufferDesc.Buffer;
        uint num = AppMain.GmMainGetLightColorABGR();
        if ( vertexBufferDesc.VertexColor != num )
        {
            if ( vertexBufferDesc.vertices == null )
            {
                vertexBufferDesc.vertices = new OpenGL.Vertex[buffer.VertexCount];
            }
            OpenGL.Vertex[] array = (OpenGL.Vertex[])bufferItem.rawData;
            Array.Copy( array, vertexBufferDesc.vertices, buffer.VertexCount );
            for ( int i = 0; i < vertexBufferDesc.vertices.Length; i++ )
            {
                array[i].Color.PackedValue = num;
                Vector2.Transform( ref vertexBufferDesc.vertices[i].TextureCoordinate, ref vertexBufferDesc.TextureMatrix, out vertexBufferDesc.vertices[i].TextureCoordinate );
            }
            buffer.SetData<OpenGL.Vertex>( array );
            vertexBufferDesc.VertexColor = num;
        }
    }

    // Token: 0x06000189 RID: 393 RVA: 0x0000FEA8 File Offset: 0x0000E0A8
    private static void nnDrawObjectVertexList( AppMain.NNS_VTXLISTPTR vlistptr, uint flag, uint alternativeLighting )
    {
        AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = (AppMain.NNS_VTXLIST_GL_DESC)vlistptr.pVtxList;
        uint type = nns_VTXLIST_GL_DESC.Type;
        int nArray = nns_VTXLIST_GL_DESC.nArray;
        OpenGL.glBindBuffer( 34962U, nns_VTXLIST_GL_DESC.BufferName );
        if ( alternativeLighting != 0U )
        {
            OpenGL.glArray4f glArray4f = new OpenGL.glArray4f(0f, 0f, -1f, 0f);
            OpenGL.glArray4f glArray4f2 = ((alternativeLighting & 32768U) == 0U) ? AppMain.GmMainGetLightColorArray4f() : AppMain.BreakWall_1_3_Color;
            OpenGL.glLightfv( 16384U, 4612U, ref glArray4f );
            OpenGL.glLightfv( 16384U, 4609U, ref glArray4f2 );
            AppMain.nnMPPVerifyAlternativeLightingSettings();
        }
        if ( ( type & 1U ) != 0U )
        {
            OpenGL.glEnableClientState( 32884U );
        }
        else
        {
            OpenGL.glDisableClientState( 32884U );
        }
        if ( ( type & 8U ) != 0U )
        {
            OpenGL.glEnableClientState( 32885U );
        }
        else
        {
            OpenGL.glDisableClientState( 32885U );
        }
        if ( ( flag & 28672U ) != 0U )
        {
            OpenGL.glDisableClientState( 32886U );
        }
        else if ( ( type & 16U ) != 0U )
        {
            OpenGL.glEnableClientState( 32886U );
        }
        else
        {
            OpenGL.glDisableClientState( 32886U );
        }
        OpenGL.glClientActiveTexture( 33984U );
        if ( AppMain.nnGetTexCoordSrc( 0 ) != 0 )
        {
            OpenGL.glEnableClientState( 32888U );
        }
        else
        {
            OpenGL.glDisableClientState( 32888U );
        }
        OpenGL.glClientActiveTexture( 33985U );
        if ( AppMain.nnGetTexCoordSrc( 1 ) != 0 )
        {
            OpenGL.glEnableClientState( 32888U );
        }
        else
        {
            OpenGL.glDisableClientState( 32888U );
        }
        if ( ( type & 2U ) != 0U )
        {
            OpenGL.glEnableClientState( 34477U );
        }
        else
        {
            OpenGL.glDisableClientState( 34477U );
        }
        if ( ( type & 4U ) != 0U )
        {
            OpenGL.glEnableClientState( 34884U );
        }
        else
        {
            OpenGL.glDisableClientState( 34884U );
        }
        for ( int i = 0; i < nArray; i++ )
        {
            AppMain.NNS_VTXARRAY_GL nns_VTXARRAY_GL = nns_VTXLIST_GL_DESC.pArray[i];
            uint type2 = nns_VTXARRAY_GL.Type;
            if ( type2 <= 8U )
            {
                switch ( type2 )
                {
                    case 1U:
                        OpenGL.glVertexPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        if ( AppMain.nnGetTexCoordSrc( 0 ) == 4 )
                        {
                            OpenGL.glClientActiveTexture( 33984U );
                            OpenGL.glEnableClientState( 32888U );
                            OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        }
                        if ( AppMain.nnGetTexCoordSrc( 1 ) == 4 )
                        {
                            OpenGL.glClientActiveTexture( 33985U );
                            OpenGL.glEnableClientState( 32888U );
                            OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        }
                        break;
                    case 2U:
                        OpenGL.glWeightPointerOES( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        break;
                    case 3U:
                        break;
                    case 4U:
                        OpenGL.glMatrixIndexPointerOES( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        break;
                    default:
                        if ( type2 == 8U )
                        {
                            OpenGL.glNormalPointer( nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                            AppMain.nnSetNormalFormatType( nns_VTXARRAY_GL.DataType );
                            if ( AppMain.nnGetTexCoordSrc( 0 ) == 3 )
                            {
                                OpenGL.glClientActiveTexture( 33984U );
                                OpenGL.glEnableClientState( 32888U );
                                OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                            }
                            if ( AppMain.nnGetTexCoordSrc( 1 ) == 3 )
                            {
                                OpenGL.glClientActiveTexture( 33985U );
                                OpenGL.glEnableClientState( 32888U );
                                OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                            }
                        }
                        break;
                }
            }
            else if ( type2 != 16U )
            {
                if ( type2 != 256U )
                {
                    if ( type2 == 512U )
                    {
                        if ( AppMain.nnGetTexCoordSrc( 0 ) == 2 )
                        {
                            OpenGL.glClientActiveTexture( 33984U );
                            OpenGL.glEnableClientState( 32888U );
                            OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        }
                        if ( AppMain.nnGetTexCoordSrc( 1 ) == 2 )
                        {
                            OpenGL.glClientActiveTexture( 33985U );
                            OpenGL.glEnableClientState( 32888U );
                            OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                        }
                    }
                }
                else
                {
                    if ( AppMain.nnGetTexCoordSrc( 0 ) == 1 )
                    {
                        OpenGL.glClientActiveTexture( 33984U );
                        OpenGL.glEnableClientState( 32888U );
                        OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                    }
                    if ( AppMain.nnGetTexCoordSrc( 1 ) == 1 )
                    {
                        OpenGL.glClientActiveTexture( 33985U );
                        OpenGL.glEnableClientState( 32888U );
                        OpenGL.glTexCoordPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
                    }
                }
            }
            else if ( ( flag & 28672U ) == 0U )
            {
                OpenGL.glColorPointer( nns_VTXARRAY_GL.Size, nns_VTXARRAY_GL.DataType, nns_VTXARRAY_GL.Stride, nns_VTXARRAY_GL.Data );
            }
        }
    }

    // Token: 0x0600018A RID: 394 RVA: 0x00010370 File Offset: 0x0000E570
    private static void nnDrawObjectPrimitiveList( AppMain.NNS_PRIMLISTPTR plistptr, uint flag )
    {
        AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC = (AppMain.NNS_PRIMLIST_GL_DESC)plistptr.pPrimList;
        OpenGL.glBindBuffer( 34963U, nns_PRIMLIST_GL_DESC.BufferName );
        uint num = flag & 28672U;
        if ( num != 4096U )
        {
            if ( num != 12288U )
            {
                int nPrim = nns_PRIMLIST_GL_DESC.nPrim;
                for ( int i = 0; i < nPrim; i++ )
                {
                    OpenGL.glDrawElements( nns_PRIMLIST_GL_DESC.Mode, nns_PRIMLIST_GL_DESC.pCounts[i], nns_PRIMLIST_GL_DESC.DataType, null );
                }
                return;
            }
            int nPrim2 = nns_PRIMLIST_GL_DESC.nPrim;
            float[] array = new float[3];
            for ( int j = 0; j < nPrim2; j++ )
            {
                AppMain.nnPutColorStrip( j, AppMain.nngDrawCallBackVal.iMeshset, AppMain.nngDrawCallBackVal.iSubobject );
                array[0] = ( float )AppMain.random.Next( 0, 32767 ) / 32767f;
                array[1] = ( float )AppMain.random.Next( 0, 32767 ) / 32767f;
                array[2] = ( float )AppMain.random.Next( 0, 32767 ) / 32767f;
                OpenGL.glColor3fv( array );
                OpenGL.glDrawElements( nns_PRIMLIST_GL_DESC.Mode, nns_PRIMLIST_GL_DESC.pCounts[j], nns_PRIMLIST_GL_DESC.DataType, null );
            }
            return;
        }
        else
        {
            if ( ( plistptr.fType & 2U ) != 0U )
            {
                return;
            }
            for ( int k = 0; k < nns_PRIMLIST_GL_DESC.nPrim; k++ )
            {
                UShortBuffer ushortBuffer = nns_PRIMLIST_GL_DESC.pIndices[k];
                ushort[] array2 = new ushort[128];
                int num2 = array2.Length;
                OpenGL.glDrawElements( 3U, nns_PRIMLIST_GL_DESC.pCounts[k], nns_PRIMLIST_GL_DESC.DataType, null );
                for ( int l = 0; l <= 1; l++ )
                {
                    int num3 = 0;
                    for ( int m = l; m < nns_PRIMLIST_GL_DESC.pCounts[k]; m += 2 )
                    {
                        array2[num3++] = ushortBuffer[m];
                        if ( num3 == num2 )
                        {
                            OpenGL.glDrawElements( 3U, num3, 5123U, null );
                            num3 = 0;
                            array2[num3++] = ushortBuffer[m];
                        }
                    }
                    if ( num3 >= 2 )
                    {
                        OpenGL.glDrawElements( 3U, num3, 5123U, null );
                    }
                }
            }
            return;
        }
    }

    // Token: 0x0600018B RID: 395 RVA: 0x0001056C File Offset: 0x0000E76C
    private static void nnDrawObject( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX[] mtxpal, uint[] nodestatlist, uint subobjtype, uint flag, uint alternativeLighting )
    {
        int num = -1;
        if ( ( flag & 1U ) != 0U )
        {
            return;
        }
        if ( obj.nSubobj <= 0 )
        {
            return;
        }
        int num2 = 0;
        int num3 = 0;
        AppMain.nngDrawCallBackVal.pObject = obj;
        AppMain.nngDrawCallBackVal.pMatrixPalette = mtxpal;
        AppMain.nngDrawCallBackVal.pNodeStatusList = nodestatlist;
        AppMain.nngDrawCallBackVal.DrawSubobjType = subobjtype;
        AppMain.nngDrawCallBackVal.DrawFlag = flag;
        AppMain.nngDrawCallBackVal.iPrevMaterial = -1;
        AppMain.nngDrawCallBackVal.iPrevVtxList = -1;
        if ( subobjtype == 2147483648U )
        {
            subobjtype = 775U;
        }
        OpenGL.glShadeModel( 7425U );
        for ( int i = 0; i < obj.nSubobj; i++ )
        {
            AppMain.NNS_SUBOBJ nns_SUBOBJ = obj.pSubobjList[i];
            if ( ( nns_SUBOBJ.fType & subobjtype & 7U ) != 0U && ( nns_SUBOBJ.fType & subobjtype & 768U ) != 0U )
            {
                AppMain.nngDrawCallBackVal.iSubobject = i;
                if ( ( nns_SUBOBJ.fType & 512U ) != 0U )
                {
                    OpenGL.glMatrixMode( 5888U );
                    OpenGL.glLoadIdentity();
                }
                for ( int j = 0; j < nns_SUBOBJ.nMeshset; j++ )
                {
                    AppMain.NNS_MESHSET nns_MESHSET = nns_SUBOBJ.pMeshsetList[j];
                    AppMain.NNS_VTXLISTPTR nns_VTXLISTPTR = obj.pVtxListPtrList[nns_MESHSET.iVtxList];
                    AppMain.NNS_PRIMLISTPTR plistptr = obj.pPrimListPtrList[nns_MESHSET.iPrimList];
                    if ( nodestatlist == null || ( nodestatlist[nns_MESHSET.iNode] & 1U ) == 0U )
                    {
                        AppMain.nngDrawCallBackVal.iMeshset = j;
                        AppMain.nngDrawCallBackVal.iNode = nns_MESHSET.iNode;
                        AppMain.nngDrawCallBackVal.iMaterial = nns_MESHSET.iMaterial;
                        AppMain.nngDrawCallBackVal.pMaterial = obj.pMatPtrList[nns_MESHSET.iMaterial];
                        AppMain.nngDrawCallBackVal.iVtxList = nns_MESHSET.iVtxList;
                        AppMain.nngDrawCallBackVal.pVtxListPtr = nns_VTXLISTPTR;
                        AppMain.nngDrawCallBackVal.bModified = 0;
                        AppMain.nngDrawCallBackVal.bReDraw = 0;
                        OpenGL.glMatrixMode( 5888U );
                        if ( ( nns_SUBOBJ.fType & 256U ) != 0U )
                        {
                            Matrix matrix = (Matrix)mtxpal[nns_MESHSET.iMatrix];
                            OpenGL.glLoadMatrixf( ref matrix );
                        }
                        else
                        {
                            OpenGL.glLoadIdentity();
                        }
                        while ( AppMain.nnPutMaterial( AppMain.nngDrawCallBackVal ) != 0 )
                        {
                            AppMain.nngDrawCallBackVal.iPrevMaterial = nns_MESHSET.iMaterial;
                            AppMain.nngDrawCallBackVal.iPrevVtxList = nns_MESHSET.iVtxList;
                            if ( ( nns_VTXLISTPTR.fType & 1U ) != 0U )
                            {
                                if ( ( flag & 768U ) != 0U )
                                {
                                    AppMain.nnDrawObjectNormal( nns_VTXLISTPTR, plistptr, mtxpal, flag );
                                }
                                else
                                {
                                    if ( ( nns_SUBOBJ.fType & 512U ) != 0U )
                                    {
                                        AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = (AppMain.NNS_VTXLIST_GL_DESC)nns_VTXLISTPTR.pVtxList;
                                        int nMatrix = nns_VTXLIST_GL_DESC.nMatrix;
                                        OpenGL.glEnable( 34880U );
                                        OpenGL.glMatrixMode( 34880U );
                                        uint num4 = 0U;
                                        while ( ( ulong )num4 < ( ulong )( ( long )nMatrix ) )
                                        {
                                            OpenGL.glCurrentPaletteMatrixOES( num4 );
                                            Matrix matrix2 = (Matrix)mtxpal[(int)nns_VTXLIST_GL_DESC.pMatrixIndices[(int)((UIntPtr)num4)]];
                                            OpenGL.glLoadMatrixf( ref matrix2 );
                                            num4 += 1U;
                                        }
                                    }
                                    else
                                    {
                                        OpenGL.glDisable( 34880U );
                                    }
                                    if ( num != nns_MESHSET.iVtxList || num2 != AppMain.nnGetTexCoordSrc( 0 ) || num3 != AppMain.nnGetTexCoordSrc( 1 ) )
                                    {
                                        AppMain.nnDrawObjectVertexList( nns_VTXLISTPTR, flag, alternativeLighting );
                                        num = nns_MESHSET.iVtxList;
                                        num2 = AppMain.nnGetTexCoordSrc( 0 );
                                        num3 = AppMain.nnGetTexCoordSrc( 1 );
                                        if ( nns_MESHSET.iMatrix != -1 )
                                        {
                                            AppMain.nnPutEnvironmentTextureMatrix( mtxpal[nns_MESHSET.iMatrix] );
                                        }
                                        else
                                        {
                                            AppMain.nnPutEnvironmentTextureMatrix( mtxpal[0] );
                                        }
                                    }
                                    AppMain.nnDrawObjectPrimitiveList( plistptr, flag );
                                }
                            }
                            else
                            {
                                uint num5 = nns_VTXLISTPTR.fType & 16711680U;
                            }
                            if ( AppMain.nngDrawCallBackVal.bReDraw == 0 )
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        OpenGL.glDisable( 34880U );
    }

    // Token: 0x0600018C RID: 396 RVA: 0x000108D4 File Offset: 0x0000EAD4
    private void nnMakeCameraPointerViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_CAMERAPTR camptr )
    {
        AppMain.mppAssertNotImpl();
        uint fType = camptr.fType;
        if ( fType <= 383U )
        {
            if ( fType == 255U )
            {
                AppMain.nnMakeTargetRollCameraViewMatrix( mtx, ( AppMain.NNS_CAMERA_TARGET_ROLL )camptr.pCamera );
                return;
            }
            if ( fType != 383U )
            {
                return;
            }
            AppMain.nnMakeTargetUpVectorCameraViewMatrix( mtx, ( AppMain.NNS_CAMERA_TARGET_UPVECTOR )camptr.pCamera );
            return;
        }
        else
        {
            if ( fType == 639U )
            {
                AppMain.nnMakeTargetUpTargetCameraViewMatrix( mtx, ( AppMain.NNS_CAMERA_TARGET_UPTARGET )camptr.pCamera );
                return;
            }
            if ( fType != 3135U )
            {
                return;
            }
            this.nnMakeRotationCameraViewMatrix( mtx, ( AppMain.NNS_CAMERA_ROTATION )camptr.pCamera );
            return;
        }
    }

    // Token: 0x0600018D RID: 397 RVA: 0x0001095F File Offset: 0x0000EB5F
    private void nnMakeCameraPointerPerspectiveMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_CAMERAPTR camptr )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600018E RID: 398 RVA: 0x00010968 File Offset: 0x0000EB68
    private static void nnMakeTargetRollCameraViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_CAMERA_TARGET_ROLL cam )
    {
        AppMain.SNNS_VECTOR snns_VECTOR = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR2 = default(AppMain.SNNS_VECTOR);
        AppMain.SNNS_VECTOR snns_VECTOR3 = default(AppMain.SNNS_VECTOR);
        snns_VECTOR3.x = cam.Position.x - cam.Target.x;
        snns_VECTOR3.y = cam.Position.y - cam.Target.y;
        snns_VECTOR3.z = cam.Position.z - cam.Target.z;
        AppMain.nnNormalizeVector( ref snns_VECTOR3, ref snns_VECTOR3 );
        snns_VECTOR.x = snns_VECTOR3.z;
        snns_VECTOR.y = 0f;
        snns_VECTOR.z = -snns_VECTOR3.x;
        AppMain.nnNormalizeVector( ref snns_VECTOR, ref snns_VECTOR );
        AppMain.nnCrossProductVector( ref snns_VECTOR2, ref snns_VECTOR3, ref snns_VECTOR );
        AppMain.nnMakeVectorCameraViewMatrix( mtx, cam.Position, ref snns_VECTOR, ref snns_VECTOR2, ref snns_VECTOR3 );
        AppMain.SNNS_MATRIX snns_MATRIX;
        AppMain.nnMakeRotateZMatrix( out snns_MATRIX, -cam.Roll );
        AppMain.nnMultiplyMatrix( mtx, ref snns_MATRIX, mtx );
    }

    // Token: 0x0600018F RID: 399 RVA: 0x00010A58 File Offset: 0x0000EC58
    private static void nnMakeTargetUpVectorCameraViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_CAMERA_TARGET_UPVECTOR cam )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = cam.Position.x - cam.Target.x;
        nns_VECTOR.y = cam.Position.y - cam.Target.y;
        nns_VECTOR.z = cam.Position.z - cam.Target.z;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        AppMain.nnCrossProductVector( nns_VECTOR2, cam.UpVector, nns_VECTOR );
        AppMain.nnNormalizeVector( nns_VECTOR2, nns_VECTOR2 );
        AppMain.nnCrossProductVector( nns_VECTOR3, nns_VECTOR, nns_VECTOR2 );
        AppMain.nnMakeVectorCameraViewMatrix( mtx, cam.Position, nns_VECTOR2, nns_VECTOR3, nns_VECTOR );
    }

    // Token: 0x06000190 RID: 400 RVA: 0x00010B02 File Offset: 0x0000ED02
    private static void nnMakeTargetUpTargetCameraViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_CAMERA_TARGET_UPTARGET cam )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000191 RID: 401 RVA: 0x00010B09 File Offset: 0x0000ED09
    private void nnMakeRotationCameraViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_CAMERA_ROTATION cam )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000192 RID: 402 RVA: 0x00010B10 File Offset: 0x0000ED10
    private uint nnEstimateCameraBufferSize( uint type )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000193 RID: 403 RVA: 0x00010B18 File Offset: 0x0000ED18
    private static void nnMakeVectorCameraViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR pos, AppMain.NNS_VECTOR right, AppMain.NNS_VECTOR up, AppMain.NNS_VECTOR ilook )
    {
        mtx.M00 = right.x;
        mtx.M01 = right.y;
        mtx.M02 = right.z;
        mtx.M03 = -( right.x * pos.x + right.y * pos.y + right.z * pos.z );
        mtx.M10 = up.x;
        mtx.M11 = up.y;
        mtx.M12 = up.z;
        mtx.M13 = -( up.x * pos.x + up.y * pos.y + up.z * pos.z );
        mtx.M20 = ilook.x;
        mtx.M21 = ilook.y;
        mtx.M22 = ilook.z;
        mtx.M23 = -( ilook.x * pos.x + ilook.y * pos.y + ilook.z * pos.z );
        mtx.M30 = ( mtx.M31 = ( mtx.M32 = 0f ) );
        mtx.M33 = 1f;
    }

    // Token: 0x06000194 RID: 404 RVA: 0x00010C50 File Offset: 0x0000EE50
    private static void nnMakeVectorCameraViewMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR pos, ref AppMain.SNNS_VECTOR right, ref AppMain.SNNS_VECTOR up, ref AppMain.SNNS_VECTOR ilook )
    {
        mtx.M00 = right.x;
        mtx.M01 = right.y;
        mtx.M02 = right.z;
        mtx.M03 = -( right.x * pos.x + right.y * pos.y + right.z * pos.z );
        mtx.M10 = up.x;
        mtx.M11 = up.y;
        mtx.M12 = up.z;
        mtx.M13 = -( up.x * pos.x + up.y * pos.y + up.z * pos.z );
        mtx.M20 = ilook.x;
        mtx.M21 = ilook.y;
        mtx.M22 = ilook.z;
        mtx.M23 = -( ilook.x * pos.x + ilook.y * pos.y + ilook.z * pos.z );
        mtx.M30 = ( mtx.M31 = ( mtx.M32 = 0f ) );
        mtx.M33 = 1f;
    }

    // Token: 0x06000343 RID: 835 RVA: 0x0001A148 File Offset: 0x00018348
    public static void nnSetClipPlane()
    {
        if ( AppMain.nngProjectionType != 1 )
        {
            float num = 1f / AppMain.nngProjectionMatrix.M00;
            float num2 = 1f / AppMain.nngProjectionMatrix.M11;
            float num3 = num2 * (AppMain.nngProjectionMatrix.M12 - AppMain.nngClip3d.y0 / AppMain.nngScreen.cy);
            float num4 = AppMain.nnSqrt(num3 * num3 + 1f);
            float num5 = num3 / num4;
            float num6 = 1f / num4;
            AppMain.nngClipPlane.Top.ny = num6;
            AppMain.nngClipPlane.Top.nz = num5;
            num3 = num2 * ( AppMain.nngProjectionMatrix.M12 - AppMain.nngClip3d.y1 / AppMain.nngScreen.cy );
            num4 = AppMain.nnSqrt( num3 * num3 + 1f );
            num5 = num3 / num4;
            num6 = 1f / num4;
            AppMain.nngClipPlane.Bottom.ny = -num6;
            AppMain.nngClipPlane.Bottom.nz = -num5;
            num3 = num * ( AppMain.nngProjectionMatrix.M02 + AppMain.nngClip3d.x1 / AppMain.nngScreen.cx );
            num4 = AppMain.nnSqrt( num3 * num3 + 1f );
            num5 = num3 / num4;
            num6 = 1f / num4;
            AppMain.nngClipPlane.Right.nx = num6;
            AppMain.nngClipPlane.Right.nz = num5;
            num3 = num * ( AppMain.nngProjectionMatrix.M02 + AppMain.nngClip3d.x0 / AppMain.nngScreen.cx );
            num4 = AppMain.nnSqrt( num3 * num3 + 1f );
            num5 = num3 / num4;
            num6 = 1f / num4;
            AppMain.nngClipPlane.Left.nx = -num6;
            AppMain.nngClipPlane.Left.nz = -num5;
            return;
        }
        float num7 = 2f / AppMain.nngProjectionMatrix.M11 / 2f;
        float ofs = -(AppMain.nngProjectionMatrix.M13 / AppMain.nngProjectionMatrix.M11);
        AppMain.nngClipPlane.Top.mul = num7 * ( AppMain.nngClip3d.y0 / -AppMain.nngScreen.cy );
        AppMain.nngClipPlane.Top.ofs = ofs;
        AppMain.nngClipPlane.Bottom.mul = -num7 * ( AppMain.nngClip3d.y1 / AppMain.nngScreen.cy );
        AppMain.nngClipPlane.Bottom.ofs = ofs;
        num7 = 2f / AppMain.nngProjectionMatrix.M00 / 2f;
        ofs = -( AppMain.nngProjectionMatrix.M03 / AppMain.nngProjectionMatrix.M00 );
        AppMain.nngClipPlane.Right.mul = num7 * ( AppMain.nngClip3d.x0 / -AppMain.nngScreen.cx );
        AppMain.nngClipPlane.Right.ofs = ofs;
        AppMain.nngClipPlane.Left.mul = -num7 * ( AppMain.nngClip3d.x1 / AppMain.nngScreen.cx );
        AppMain.nngClipPlane.Left.ofs = ofs;
    }

    // Token: 0x06000344 RID: 836 RVA: 0x0001A449 File Offset: 0x00018649
    public void nnSetClipScreenCoordinates( AppMain.NNS_VECTOR2D pos )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000345 RID: 837 RVA: 0x0001A450 File Offset: 0x00018650
    public void nnSetClipZ( float znear, float zfar )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000346 RID: 838 RVA: 0x0001A457 File Offset: 0x00018657
    private int nnGetNodeIndex( AppMain.NNS_NODENAMELIST pNodeNameList, string NodeName )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000347 RID: 839 RVA: 0x0001A45F File Offset: 0x0001865F
    private string nnGetNodeName( AppMain.NNS_NODENAMELIST pNodeNameList, int NodeIndex )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06000348 RID: 840 RVA: 0x0001A467 File Offset: 0x00018667
    private void nnCalcNodeStatusListMatrixList( uint[] nodestatlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX mtxlist, AppMain.NNS_MATRIX basemtx, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000349 RID: 841 RVA: 0x0001A46E File Offset: 0x0001866E
    private static float NNM_DEGtoRAD( float n )
    {
        return n * 0.017453292f;
    }

    // Token: 0x0600034A RID: 842 RVA: 0x0001A477 File Offset: 0x00018677
    private static float NNM_DEGtoRAD( int n )
    {
        return ( float )n * 0.017453292f;
    }

    // Token: 0x0600034B RID: 843 RVA: 0x0001A481 File Offset: 0x00018681
    private static int NNM_DEGtoA32( float n )
    {
        return ( int )( n * 182.04443f );
    }

    // Token: 0x0600034C RID: 844 RVA: 0x0001A48B File Offset: 0x0001868B
    private static int NNM_RADtoA32( float n )
    {
        return ( int )( n * 10430.378f );
    }

    // Token: 0x0600034D RID: 845 RVA: 0x0001A495 File Offset: 0x00018695
    private static float NNM_RADtoDEG( float n )
    {
        return n * 57.29578f;
    }

    // Token: 0x0600034E RID: 846 RVA: 0x0001A49E File Offset: 0x0001869E
    private static float NNM_A32toDEG( float n )
    {
        return n * 0.005493164f;
    }

    // Token: 0x0600034F RID: 847 RVA: 0x0001A4A7 File Offset: 0x000186A7
    private static float NNM_A32toRAD( float n )
    {
        return n * 9.58738E-05f;
    }

    // Token: 0x06000350 RID: 848 RVA: 0x0001A4B0 File Offset: 0x000186B0
    private static int NNM_DEGtoA32( int n )
    {
        return ( int )( ( float )n * 182.04443f );
    }

    // Token: 0x06000351 RID: 849 RVA: 0x0001A4BB File Offset: 0x000186BB
    private static int NNM_RADtoA32( int n )
    {
        return ( int )( ( float )n * 10430.378f );
    }

    // Token: 0x06000352 RID: 850 RVA: 0x0001A4C6 File Offset: 0x000186C6
    private static float NNM_RADtoDEG( int n )
    {
        return ( float )n * 57.29578f;
    }

    // Token: 0x06000353 RID: 851 RVA: 0x0001A4D0 File Offset: 0x000186D0
    private static float NNM_A32toDEG( int n )
    {
        return ( float )n * 0.005493164f;
    }

    // Token: 0x06000354 RID: 852 RVA: 0x0001A4DA File Offset: 0x000186DA
    private static float NNM_A32toRAD( int n )
    {
        return ( float )n * 9.58738E-05f;
    }

    // Token: 0x06000355 RID: 853 RVA: 0x0001A4E4 File Offset: 0x000186E4
    private static int NNM_DEGtoA16( float n )
    {
        return ( int )( ( short )( ( int )( n * 182.04443f ) ) );
    }

    // Token: 0x06000356 RID: 854 RVA: 0x0001A4EF File Offset: 0x000186EF
    public static int NNM_MAX( int a, int b )
    {
        return Math.Max( a, b );
    }

    // Token: 0x06000357 RID: 855 RVA: 0x0001A4F8 File Offset: 0x000186F8
    public static float NNM_MAX( float a, float b )
    {
        return Math.Max( a, b );
    }

    // Token: 0x06000358 RID: 856 RVA: 0x0001A501 File Offset: 0x00018701
    public static int NNM_MIN( int a, int b )
    {
        return Math.Min( a, b );
    }

    // Token: 0x06000359 RID: 857 RVA: 0x0001A50A File Offset: 0x0001870A
    public static float NNM_MIN( float a, float b )
    {
        return Math.Min( a, b );
    }

    // Token: 0x0600035A RID: 858 RVA: 0x0001A513 File Offset: 0x00018713
    private static void nnSetPrimitive2DAlphaFuncGL( uint func, float _ref )
    {
        AppMain.nndrawprim2d.nnsAlphaFunc = func;
        AppMain.nndrawprim2d.nnsAlphaFuncRef = _ref;
    }

    // Token: 0x0600035B RID: 859 RVA: 0x0001A521 File Offset: 0x00018721
    private static void nnSetPrimitive2DDepthFuncGL( uint func )
    {
        AppMain.nndrawprim2d.nnsDepthFunc = func;
    }

    // Token: 0x0600035C RID: 860 RVA: 0x0001A529 File Offset: 0x00018729
    private static void nnSetPrimitive2DDepthMaskGL( bool flag )
    {
        AppMain.nndrawprim2d.nnsDepthMask = flag;
    }

    // Token: 0x0600035D RID: 861 RVA: 0x0001A534 File Offset: 0x00018734
    private static void nnConvert2DTo3D( AppMain.NNS_VECTOR p3D, float x_2D, float y_2D, float z_3D )
    {
        float num = (x_2D - AppMain.nngScreen.cx) * 2f / AppMain.nngScreen.w;
        float num2 = (AppMain.nngScreen.cy - y_2D) * 2f / AppMain.nngScreen.h;
        float num3 = AppMain.nngProjectionMatrix.M32 * z_3D + AppMain.nngProjectionMatrix.M33;
        num *= num3;
        num2 *= num3;
        num = ( num - AppMain.nngProjectionMatrix.M02 * z_3D - AppMain.nngProjectionMatrix.M03 ) / AppMain.nngProjectionMatrix.M00;
        num2 = ( num2 - AppMain.nngProjectionMatrix.M12 * z_3D - AppMain.nngProjectionMatrix.M13 ) / AppMain.nngProjectionMatrix.M11;
        p3D.x = num;
        p3D.y = num2;
        p3D.z = z_3D;
    }

    // Token: 0x0600035E RID: 862 RVA: 0x0001A5FC File Offset: 0x000187FC
    private static void nnConvert2DTo3D( ref Vector3 p3D, float x_2D, float y_2D, float z_3D )
    {
        float num = (x_2D - AppMain.nngScreen.cx) * 2f / AppMain.nngScreen.w;
        float num2 = (AppMain.nngScreen.cy - y_2D) * 2f / AppMain.nngScreen.h;
        float num3 = AppMain.nngProjectionMatrix.M32 * z_3D + AppMain.nngProjectionMatrix.M33;
        num *= num3;
        num2 *= num3;
        num = ( num - AppMain.nngProjectionMatrix.M02 * z_3D - AppMain.nngProjectionMatrix.M03 ) / AppMain.nngProjectionMatrix.M00;
        num2 = ( num2 - AppMain.nngProjectionMatrix.M12 * z_3D - AppMain.nngProjectionMatrix.M13 ) / AppMain.nngProjectionMatrix.M11;
        p3D.X = num;
        p3D.Y = num2;
        p3D.Z = z_3D;
    }

    // Token: 0x0600035F RID: 863 RVA: 0x0001A6C4 File Offset: 0x000188C4
    private static void nnBeginDrawPrimitive2DCore( int fmt, int blend )
    {
        OpenGL.glShadeModel( 7424U );
        OpenGL.glDisable( 2884U );
        OpenGL.glLightModelf( 2898U, 0f );
        OpenGL.glDisable( 2896U );
        OpenGL.glEnable( 3008U );
        OpenGL.glAlphaFunc( AppMain.nndrawprim2d.nnsAlphaFunc, AppMain.nndrawprim2d.nnsAlphaFuncRef );
        OpenGL.glEnable( 2929U );
        OpenGL.glDepthFunc( AppMain.nndrawprim2d.nnsDepthFunc );
        OpenGL.glDepthMask( AppMain.nndrawprim2d.nnsDepthMask );
        OpenGL.glColorMask( 1, 1, 1, 1 );
        OpenGL.glBindBuffer( 34962U, 0U );
        OpenGL.glBindBuffer( 34963U, 0U );
        if ( blend == 1 )
        {
            OpenGL.glEnable( 3042U );
            switch ( AppMain.nngDrawPrimBlend )
            {
                case 0:
                    OpenGL.glBlendFunc( 770U, 1U );
                    OpenGL.glBlendEquation( 32774U );
                    goto IL_E3;
            }
            OpenGL.glBlendFunc( 770U, 771U );
            OpenGL.glBlendEquation( 32774U );
        }
        else
        {
            OpenGL.glDisable( 3042U );
        }
        IL_E3:
        AppMain.nnPutFogSwitchGL( AppMain.nngFogSwitch );
        OpenGL.glMaterialfv( 1032U, 4609U, ( OpenGL.glArray4f )AppMain.nngColorWhite );
        AppMain.nndrawprim2d.nnsFormat = fmt;
        OpenGL.glDisableClientState( 32885U );
        OpenGL.glDisableClientState( 34477U );
        OpenGL.glDisableClientState( 34884U );
        switch ( fmt )
        {
            default:
                AppMain.nnPutPrimitiveNoTexture();
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glDisableClientState( 32886U );
                break;
            case 1:
                AppMain.nnPutPrimitiveNoTexture();
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glEnableClientState( 32886U );
                break;
            case 2:
                if ( AppMain.nngDrawPrimTexture != 0 )
                {
                    AppMain.nnPutPrimitiveTexParameter();
                    OpenGL.glMatrixMode( 5890U );
                    OpenGL.glLoadIdentity();
                    OpenGL.glTranslatef( 0f, 1f, 0f );
                    OpenGL.glScalef( 1f, -1f, 1f );
                    OpenGL.glClientActiveTexture( 33984U );
                    OpenGL.glEnableClientState( 32888U );
                }
                else
                {
                    AppMain.nnPutPrimitiveNoTexture();
                }
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glEnableClientState( 32886U );
                break;
        }
        OpenGL.glMatrixMode( 5888U );
        OpenGL.glLoadIdentity();
    }

    // Token: 0x06000360 RID: 864 RVA: 0x0001A8CC File Offset: 0x00018ACC
    private static void nnDrawPrimitive2DCore( uint mode, object vtx, int count, float pri )
    {
        if ( pri > -AppMain.nngClip2d.n_clip || -AppMain.nngClip2d.f_clip > pri )
        {
            return;
        }
        switch ( AppMain.nndrawprim2d.nnsFormat )
        {
            case 0:
                AppMain.mppAssertNotImpl();
                return;
            case 1:
                {
                    AppMain.NNS_PRIM2D_PC[] array = (AppMain.NNS_PRIM2D_PC[])vtx;
                    Vector3[] vbuf = AppMain._nnDrawPrimitive2DCore.vbuf;
                    AppMain.RGBA_U8[] cbuf = AppMain._nnDrawPrimitive2DCore.cbuf;
                    int num = 0;
                    OpenGL.glVertexPointer( 3, 5126U, 0, new AppMain.Vector3_VertexData( vbuf ) );
                    OpenGL.glColorPointer( 4, 5121U, 0, new AppMain.RGBA_U8_ColorData( cbuf, 0 ) );
                    for ( int i = 0; i < count; i++ )
                    {
                        AppMain.NNS_VECTOR2D pos = array[i].Pos;
                        uint col = array[i].Col;
                        AppMain.nnConvert2DTo3D( ref vbuf[num], pos.x, pos.y, pri );
                        cbuf[num].r = ( byte )( col >> 24 );
                        cbuf[num].g = ( byte )( col >> 16 );
                        cbuf[num].b = ( byte )( col >> 8 );
                        cbuf[num].a = ( byte )col;
                        num++;
                        if ( num >= 6 )
                        {
                            OpenGL.glDrawArrays( mode, 0, num );
                            switch ( mode )
                            {
                                case 3U:
                                    vbuf[0] = vbuf[5];
                                    cbuf[0] = cbuf[5];
                                    num = 1;
                                    goto IL_1C9;
                                case 5U:
                                    vbuf[0] = vbuf[4];
                                    vbuf[1] = vbuf[5];
                                    cbuf[0] = cbuf[4];
                                    cbuf[1] = cbuf[5];
                                    num = 2;
                                    goto IL_1C9;
                            }
                            num = 0;
                        }
                        IL_1C9:;
                    }
                    if ( num > 0 )
                    {
                        OpenGL.glDrawArrays( mode, 0, num );
                        return;
                    }
                    break;
                }
            case 2:
                AppMain.mppAssertNotImpl();
                break;
            default:
                return;
        }
    }

    // Token: 0x06000361 RID: 865 RVA: 0x0001AAC1 File Offset: 0x00018CC1
    private static void nnEndDrawPrimitive2DCore()
    {
    }

    // Token: 0x06000362 RID: 866 RVA: 0x0001AAC3 File Offset: 0x00018CC3
    private static void nnBeginDrawPrimitive2D( int fmt, int blend )
    {
        AppMain.nnBeginDrawPrimitive2DCore( fmt, blend );
    }

    // Token: 0x06000363 RID: 867 RVA: 0x0001AACC File Offset: 0x00018CCC
    private static void nnDrawPrimitive2D( int type, object vtx, int count, float pri )
    {
        uint mode;
        switch ( type )
        {
            case 0:
                mode = 4U;
                goto IL_18;
        }
        mode = 5U;
        IL_18:
        AppMain.nnDrawPrimitive2DCore( mode, vtx, count, pri );
    }

    // Token: 0x06000364 RID: 868 RVA: 0x0001AAFA File Offset: 0x00018CFA
    private static void nnEndDrawPrimitive2D()
    {
        AppMain.nnEndDrawPrimitive2DCore();
    }

    // Token: 0x06000365 RID: 869 RVA: 0x0001AB01 File Offset: 0x00018D01
    private static void nnBeginDrawPrimitiveLine2D( ref AppMain.NNS_RGBA col, int blend )
    {
        AppMain.nnBeginDrawPrimitive2DCore( 0, blend );
        OpenGL.glColor4fv( ( OpenGL.glArray4f )col );
    }

    // Token: 0x06000366 RID: 870 RVA: 0x0001AB1C File Offset: 0x00018D1C
    private static void nnDrawPrimitiveLine2D( AppMain.NNE_PRIM_LINE type, object vtx, int count, float pri )
    {
        uint mode;
        switch ( type )
        {
            case AppMain.NNE_PRIM_LINE.NNE_PRIM_LINE_LIST:
                mode = 1U;
                goto IL_18;
        }
        mode = 3U;
        IL_18:
        AppMain.nnDrawPrimitive2DCore( mode, vtx, count, pri );
    }

    // Token: 0x06000367 RID: 871 RVA: 0x0001AB4A File Offset: 0x00018D4A
    private static void nnEndDrawPrimitiveLine2D()
    {
        AppMain.nnEndDrawPrimitive2DCore();
    }

    // Token: 0x06000368 RID: 872 RVA: 0x0001AB51 File Offset: 0x00018D51
    private static void nnDrawPrimitivePoint2D( object vtx, int count, float pri )
    {
        AppMain.nnDrawPrimitive2DCore( 0U, vtx, count, pri );
    }

    // Token: 0x06000369 RID: 873 RVA: 0x0001AB5C File Offset: 0x00018D5C
    private static void nnEndDrawPrimitivePoint2D()
    {
        AppMain.nnEndDrawPrimitive2DCore();
    }

    // Token: 0x0600036A RID: 874 RVA: 0x0001AB64 File Offset: 0x00018D64
    private static void nnInvertTransposeMatrix33( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        float m = src.M00;
        float m2 = src.M01;
        float m3 = src.M02;
        float m4 = src.M10;
        float m5 = src.M11;
        float m6 = src.M12;
        float m7 = src.M20;
        float m8 = src.M21;
        float m9 = src.M22;
        float num = m5 * m9 - m6 * m8;
        float num2 = m6 * m7 - m4 * m9;
        float num3 = m4 * m8 - m5 * m7;
        float num4 = m * num + m2 * num2 + m3 * num3;
        if ( num4 == 0f )
        {
            dst.M00 = 0f;
            dst.M01 = 0f;
            dst.M02 = 0f;
            dst.M10 = 0f;
            dst.M11 = 0f;
            dst.M12 = 0f;
            dst.M20 = 0f;
            dst.M21 = 0f;
            dst.M22 = 0f;
            return;
        }
        float num5 = 1f / num4;
        dst.M00 = num * num5;
        dst.M10 = -( m2 * m9 - m8 * m3 ) * num5;
        dst.M20 = ( m2 * m6 - m5 * m3 ) * num5;
        dst.M01 = num2 * num5;
        dst.M11 = ( m * m9 - m7 * m3 ) * num5;
        dst.M21 = -( m * m6 - m4 * m3 ) * num5;
        dst.M02 = num3 * num5;
        dst.M12 = -( m * m8 - m7 * m2 ) * num5;
        dst.M22 = ( m * m5 - m4 * m2 ) * num5;
    }

    // Token: 0x0600036B RID: 875 RVA: 0x0001ACF0 File Offset: 0x00018EF0
    private static void nnInvertTransposeMatrix33NotNormalized( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        float m = src.M00;
        float m2 = src.M01;
        float m3 = src.M02;
        float m4 = src.M10;
        float m5 = src.M11;
        float m6 = src.M12;
        float m7 = src.M20;
        float m8 = src.M21;
        float m9 = src.M22;
        dst.M00 = m5 * m9 - m8 * m6;
        dst.M10 = -( m2 * m9 - m8 * m3 );
        dst.M20 = m2 * m6 - m5 * m3;
        dst.M01 = -( m4 * m9 - m7 * m6 );
        dst.M11 = m * m9 - m7 * m3;
        dst.M21 = -( m * m6 - m4 * m3 );
        dst.M02 = m4 * m8 - m7 * m5;
        dst.M12 = -( m * m8 - m7 * m2 );
        dst.M22 = m * m5 - m4 * m2;
    }

    // Token: 0x0600036C RID: 876 RVA: 0x0001ADCE File Offset: 0x00018FCE
    private void nnSetNormalLength( float len )
    {
        AppMain.nngNormalLength = len;
    }

    // Token: 0x0600036D RID: 877 RVA: 0x0001ADD6 File Offset: 0x00018FD6
    private void nnSetNormalColor( float r, float g, float b, float a )
    {
        AppMain.nngNormalColor.r = r;
        AppMain.nngNormalColor.g = g;
        AppMain.nngNormalColor.b = b;
        AppMain.nngNormalColor.a = a;
    }

    // Token: 0x0600036E RID: 878 RVA: 0x0001AE05 File Offset: 0x00019005
    private void nnSetWireColor( float r, float g, float b, float a )
    {
        AppMain.nngWireColor.r = r;
        AppMain.nngWireColor.g = g;
        AppMain.nngWireColor.b = b;
        AppMain.nngWireColor.a = a;
    }

    // Token: 0x0600036F RID: 879 RVA: 0x0001AE34 File Offset: 0x00019034
    private static void nnPutWireColor()
    {
        OpenGL.glColor4fv( ( OpenGL.glArray4f )AppMain.nngWireColor );
    }

    // Token: 0x06000370 RID: 880 RVA: 0x0001AE45 File Offset: 0x00019045
    private static void nnDrawObjectNormal( AppMain.NNS_VTXLISTPTR vlistptr, AppMain.NNS_PRIMLISTPTR plistptr, AppMain.NNS_MATRIX[] mtxpal, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000371 RID: 881 RVA: 0x0001AE4C File Offset: 0x0001904C
    public static uint NNM_CHUNK_ID( char a, char b, char c, char d )
    {
        return ( uint )( ( uint )( d & 'ÿ' ) << 24 | ( uint )( c & 'ÿ' ) << 16 | ( uint )( b & 'ÿ' ) << 8 | ( a & 'ÿ' ) );
    }

    // Token: 0x06000372 RID: 882 RVA: 0x0001AE75 File Offset: 0x00019075
    private static void nnInitPreviousMaterialValueGL()
    {
        AppMain.nnmaterialcore.nngPreMatFlag = uint.MaxValue;
        AppMain.nnmaterialcore.nngpPreMatColor = null;
        AppMain.nnmaterialcore.nngpPreMatLogic = null;
    }

    // Token: 0x06000373 RID: 883 RVA: 0x0001AE8C File Offset: 0x0001908C
    private static void nnPutMaterialFlagGL( AppMain.NNS_DRAWCALLBACK_VAL val, uint fMatFlag )
    {
        uint num = val.DrawFlag & 96U;
        if ( num != 32U )
        {
            if ( num != 64U )
            {
                if ( num != 96U )
                {
                    if ( ( fMatFlag & 9U ) != 0U )
                    {
                        OpenGL.glDisable( 2884U );
                    }
                    else
                    {
                        OpenGL.glEnable( 2884U );
                        OpenGL.glCullFace( 1029U );
                    }
                }
                else
                {
                    OpenGL.glEnable( 2884U );
                    OpenGL.glCullFace( 1029U );
                }
            }
            else
            {
                OpenGL.glEnable( 2884U );
                OpenGL.glCullFace( 1028U );
            }
        }
        else
        {
            OpenGL.glDisable( 2884U );
        }
        if ( ( fMatFlag & 24U ) != 0U )
        {
            OpenGL.glLightModelf( 2898U, 1f );
        }
        else
        {
            OpenGL.glLightModelf( 2898U, 0f );
        }
        if ( ( val.DrawFlag & 128U ) != 0U || ( fMatFlag & 2U ) != 0U )
        {
            OpenGL.glDisable( 2896U );
        }
        else
        {
            OpenGL.glEnable( 2896U );
        }
        AppMain.nnPutFogSwitchGL( AppMain.nngFogSwitch && 0U == ( fMatFlag & 4U ) );
        byte flag = (byte)(((fMatFlag & 256U) == 0U) ? 1 : 0);
        OpenGL.glDepthMask( flag );
        if ( ( val.DrawFlag & 2147483648U ) != 0U )
        {
            OpenGL.glColorMask( 0, 0, 0, 0 );
        }
        else
        {
            byte red = (byte)(((fMatFlag & 512U) == 0U) ? 1 : 0);
            byte green = (byte)(((fMatFlag & 1024U) == 0U) ? 1 : 0);
            byte blue = (byte)(((fMatFlag & 2048U) == 0U) ? 1 : 0);
            byte alpha = (byte)(((fMatFlag & 4096U) == 0U) ? 1 : 0);
            OpenGL.glColorMask( red, green, blue, alpha );
        }
        AppMain.nnmaterialcore.nngPreMatFlag = fMatFlag;
    }

    // Token: 0x06000374 RID: 884 RVA: 0x0001AFF0 File Offset: 0x000191F0
    private static void nnPutMaterialColorGL( uint face, AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor )
    {
        uint fFlag = pColor.fFlag;
        if ( ( fFlag & 1U ) != 0U )
        {
            OpenGL.glEnable( 2903U );
        }
        else
        {
            OpenGL.glDisable( 2903U );
        }
        if ( ( val.DrawFlag & 334498816U ) == 0U )
        {
            OpenGL.glMaterialfv( face, 4608U, ( OpenGL.glArray4f )pColor.Ambient );
            OpenGL.glMaterialfv( face, 4609U, ( OpenGL.glArray4f )pColor.Diffuse );
            OpenGL.glColor4fv( ( OpenGL.glArray4f )pColor.Diffuse );
            if ( ( pColor.fFlag & 2U ) != 0U )
            {
                OpenGL.glArray4f param;
                param.f0 = pColor.Specular.r * pColor.SpecularIntensity;
                param.f1 = pColor.Specular.g * pColor.SpecularIntensity;
                param.f2 = pColor.Specular.b * pColor.SpecularIntensity;
                param.f3 = pColor.Specular.a;
                OpenGL.glMaterialfv( face, 4610U, param );
            }
            else
            {
                OpenGL.glMaterialfv( face, 4610U, ( OpenGL.glArray4f )pColor.Specular );
            }
        }
        else
        {
            if ( ( val.DrawFlag & 2097152U ) != 0U )
            {
                switch ( AppMain.nngMatCtrlAmbient.mode )
                {
                    case 1:
                        {
                            OpenGL.glArray4f param2;
                            param2.f0 = AppMain.nngMatCtrlAmbient.col.r;
                            param2.f1 = AppMain.nngMatCtrlAmbient.col.g;
                            param2.f2 = AppMain.nngMatCtrlAmbient.col.b;
                            param2.f3 = 1f;
                            OpenGL.glMaterialfv( face, 4608U, param2 );
                            goto IL_2D7;
                        }
                    case 2:
                        {
                            OpenGL.glArray4f param2;
                            param2.f0 = pColor.Ambient.r + AppMain.nngMatCtrlAmbient.col.r;
                            param2.f1 = pColor.Ambient.g + AppMain.nngMatCtrlAmbient.col.g;
                            param2.f2 = pColor.Ambient.b + AppMain.nngMatCtrlAmbient.col.b;
                            param2.f3 = pColor.Ambient.a;
                            OpenGL.glMaterialfv( face, 4608U, param2 );
                            goto IL_2D7;
                        }
                    case 3:
                        {
                            OpenGL.glArray4f param2;
                            param2.f0 = pColor.Ambient.r * AppMain.nngMatCtrlAmbient.col.r;
                            param2.f1 = pColor.Ambient.g * AppMain.nngMatCtrlAmbient.col.g;
                            param2.f2 = pColor.Ambient.b * AppMain.nngMatCtrlAmbient.col.b;
                            param2.f3 = pColor.Ambient.a;
                            OpenGL.glMaterialfv( face, 4608U, param2 );
                            goto IL_2D7;
                        }
                }
                OpenGL.glMaterialfv( face, 4608U, ( OpenGL.glArray4f )pColor.Ambient );
            }
            else
            {
                OpenGL.glMaterialfv( face, 4608U, ( OpenGL.glArray4f )pColor.Ambient );
            }
            IL_2D7:
            if ( ( val.DrawFlag & 9437184U ) != 0U )
            {
                OpenGL.glArray4f glArray4f;
                if ( ( val.DrawFlag & 1048576U ) != 0U )
                {
                    switch ( AppMain.nngMatCtrlDiffuse.mode )
                    {
                        case 1:
                            glArray4f.f0 = AppMain.nngMatCtrlDiffuse.col.r;
                            glArray4f.f1 = AppMain.nngMatCtrlDiffuse.col.g;
                            glArray4f.f2 = AppMain.nngMatCtrlDiffuse.col.b;
                            goto IL_4A9;
                        case 2:
                            glArray4f.f0 = pColor.Diffuse.r + AppMain.nngMatCtrlDiffuse.col.r;
                            glArray4f.f1 = pColor.Diffuse.g + AppMain.nngMatCtrlDiffuse.col.g;
                            glArray4f.f2 = pColor.Diffuse.b + AppMain.nngMatCtrlDiffuse.col.b;
                            goto IL_4A9;
                        case 3:
                            glArray4f.f0 = pColor.Diffuse.r * AppMain.nngMatCtrlDiffuse.col.r;
                            glArray4f.f1 = pColor.Diffuse.g * AppMain.nngMatCtrlDiffuse.col.g;
                            glArray4f.f2 = pColor.Diffuse.b * AppMain.nngMatCtrlDiffuse.col.b;
                            goto IL_4A9;
                    }
                    glArray4f.f0 = pColor.Diffuse.r;
                    glArray4f.f1 = pColor.Diffuse.g;
                    glArray4f.f2 = pColor.Diffuse.b;
                }
                else
                {
                    glArray4f.f0 = pColor.Diffuse.r;
                    glArray4f.f1 = pColor.Diffuse.g;
                    glArray4f.f2 = pColor.Diffuse.b;
                }
                IL_4A9:
                if ( ( val.DrawFlag & 8388608U ) != 0U )
                {
                    switch ( AppMain.nngMatCtrlAlpha.mode )
                    {
                        case 1:
                            glArray4f.f3 = AppMain.nngMatCtrlAlpha.alpha;
                            goto IL_556;
                        case 2:
                            glArray4f.f3 = pColor.Diffuse.a + AppMain.nngMatCtrlAlpha.alpha;
                            goto IL_556;
                        case 3:
                            glArray4f.f3 = pColor.Diffuse.a * AppMain.nngMatCtrlAlpha.alpha;
                            goto IL_556;
                    }
                    glArray4f.f3 = pColor.Diffuse.a;
                }
                else
                {
                    glArray4f.f3 = pColor.Diffuse.a;
                }
                IL_556:
                OpenGL.glMaterialfv( face, 4609U, glArray4f );
                OpenGL.glColor4fv( glArray4f );
            }
            else
            {
                OpenGL.glMaterialfv( face, 4609U, ( OpenGL.glArray4f )pColor.Diffuse );
                OpenGL.glColor4fv( ( OpenGL.glArray4f )pColor.Diffuse );
            }
            if ( ( val.DrawFlag & 1024U ) != 0U )
            {
                OpenGL.glMaterialfv( face, 4610U, ( OpenGL.glArray4f )AppMain.nngColorBlack );
            }
            else
            {
                OpenGL.glArray4f param3;
                if ( ( pColor.fFlag & 2U ) != 0U )
                {
                    param3.f0 = pColor.Specular.r * pColor.SpecularIntensity;
                    param3.f1 = pColor.Specular.g * pColor.SpecularIntensity;
                    param3.f2 = pColor.Specular.b * pColor.SpecularIntensity;
                    param3.f3 = pColor.Specular.a;
                }
                else
                {
                    param3.f0 = pColor.Specular.r;
                    param3.f1 = pColor.Specular.g;
                    param3.f2 = pColor.Specular.b;
                    param3.f3 = pColor.Specular.a;
                }
                if ( ( val.DrawFlag & 4194304U ) != 0U )
                {
                    switch ( AppMain.nngMatCtrlSpecular.mode )
                    {
                        case 1:
                            param3.f0 = AppMain.nngMatCtrlSpecular.col.r;
                            param3.f1 = AppMain.nngMatCtrlSpecular.col.g;
                            param3.f2 = AppMain.nngMatCtrlSpecular.col.b;
                            param3.f3 = 1f;
                            break;
                        case 2:
                            param3.f0 += AppMain.nngMatCtrlSpecular.col.r;
                            param3.f1 += AppMain.nngMatCtrlSpecular.col.g;
                            param3.f2 += AppMain.nngMatCtrlSpecular.col.b;
                            break;
                        case 3:
                            param3.f0 *= AppMain.nngMatCtrlSpecular.col.r;
                            param3.f1 *= AppMain.nngMatCtrlSpecular.col.g;
                            param3.f2 *= AppMain.nngMatCtrlSpecular.col.b;
                            break;
                    }
                }
                OpenGL.glMaterialfv( face, 4610U, param3 );
            }
        }
        float param4 = (pColor.Shininess <= AppMain.nngGLExtensions.max_shininess) ? pColor.Shininess : AppMain.nngGLExtensions.max_shininess;
        OpenGL.glMaterialf( face, 5633U, param4 );
        OpenGL.glMaterialfv( face, 5632U, ( OpenGL.glArray4f )pColor.Emission );
        AppMain.nnmaterialcore.nngpPreMatColor = pColor;
    }

    // Token: 0x06000375 RID: 885 RVA: 0x0001B7F4 File Offset: 0x000199F4
    private static void nnPutMaterialLogicGL( AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_LOGIC pLogic )
    {
        uint fFlag = pLogic.fFlag;
        if ( ( val.DrawFlag & 33554432U ) != 0U )
        {
            OpenGL.glEnable( 3042U );
            switch ( AppMain.nngMatCtrlBlendMode.blendmode )
            {
                case 0:
                    OpenGL.glBlendFunc( 770U, 771U );
                    OpenGL.glBlendEquation( 32774U );
                    break;
                case 1:
                    OpenGL.glBlendFunc( 770U, 1U );
                    OpenGL.glBlendEquation( 32774U );
                    break;
                case 2:
                    OpenGL.glBlendFunc( 770U, 1U );
                    OpenGL.glBlendEquation( 32779U );
                    break;
            }
        }
        else if ( ( fFlag & 1U ) != 0U )
        {
            OpenGL.glEnable( 3042U );
            if ( ( fFlag & 2U ) != 0U )
            {
                OpenGL.glBlendFunc( ( uint )pLogic.SrcFactorRGB, ( uint )pLogic.DstFactorRGB );
            }
            else
            {
                OpenGL.glBlendFunc( ( uint )pLogic.SrcFactorRGB, ( uint )pLogic.DstFactorRGB );
            }
            OpenGL.glBlendEquation( ( uint )pLogic.BlendOp );
        }
        else
        {
            OpenGL.glDisable( 3042U );
        }
        if ( ( fFlag & 4U ) != 0U )
        {
            OpenGL.glEnable( 3058U );
            OpenGL.glLogicOp( ( uint )pLogic.LogicOp );
        }
        else
        {
            OpenGL.glDisable( 3058U );
        }
        if ( ( val.DrawFlag & 1U ) == 0U && ( fFlag & 8U ) != 0U )
        {
            OpenGL.glEnable( 3008U );
            OpenGL.glAlphaFunc( ( uint )pLogic.AlphaFunc, pLogic.AlphaRef );
        }
        else
        {
            OpenGL.glDisable( 3008U );
        }
        if ( ( fFlag & 16U ) != 0U )
        {
            OpenGL.glEnable( 2929U );
            OpenGL.glDepthFunc( ( uint )pLogic.DepthFunc );
        }
        else
        {
            OpenGL.glDisable( 2929U );
        }
        AppMain.nnmaterialcore.nngpPreMatLogic = pLogic;
    }

    // Token: 0x06000376 RID: 886 RVA: 0x0001B964 File Offset: 0x00019B64
    private static void nnPutMaterialLogicGLES11( AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_GLES11_LOGIC pLogic )
    {
        uint fFlag = pLogic.fFlag;
        if ( ( val.DrawFlag & 33554432U ) != 0U )
        {
            OpenGL.glEnable( 3042U );
            switch ( AppMain.nngMatCtrlBlendMode.blendmode )
            {
                case 0:
                    OpenGL.glBlendFunc( 770U, 771U );
                    OpenGL.glBlendEquation( 32774U );
                    break;
                case 1:
                    OpenGL.glBlendFunc( 770U, 1U );
                    OpenGL.glBlendEquation( 32774U );
                    break;
                case 2:
                    OpenGL.glBlendFunc( 770U, 1U );
                    OpenGL.glBlendEquation( 32779U );
                    break;
            }
        }
        else if ( ( fFlag & 1U ) != 0U )
        {
            OpenGL.glEnable( 3042U );
            OpenGL.glBlendFunc( ( uint )pLogic.SrcFactor, ( uint )pLogic.DstFactor );
            OpenGL.glBlendEquation( ( uint )pLogic.BlendOp );
        }
        else
        {
            OpenGL.glDisable( 3042U );
        }
        if ( ( fFlag & 4U ) != 0U )
        {
            OpenGL.glEnable( 3058U );
            OpenGL.glLogicOp( ( uint )pLogic.LogicOp );
        }
        else
        {
            OpenGL.glDisable( 3058U );
        }
        if ( ( val.DrawFlag & 1U ) == 0U && ( fFlag & 8U ) != 0U )
        {
            OpenGL.glEnable( 3008U );
            OpenGL.glAlphaFunc( ( uint )pLogic.AlphaFunc, pLogic.AlphaRef );
        }
        else
        {
            OpenGL.glDisable( 3008U );
        }
        if ( ( fFlag & 16U ) != 0U )
        {
            OpenGL.glEnable( 2929U );
            OpenGL.glDepthFunc( ( uint )pLogic.DepthFunc );
        }
        else
        {
            OpenGL.glDisable( 2929U );
        }
        AppMain.nnmaterialcore.nngpPreMatLogic = pLogic;
    }

    // Token: 0x06000377 RID: 887 RVA: 0x0001BABB File Offset: 0x00019CBB
    private void nnPutMaterialTextureShadowMap( int slot, AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNE_SHADOWMAP idx )
    {
    }

    // Token: 0x06000378 RID: 888 RVA: 0x0001BABD File Offset: 0x00019CBD
    private uint nnGetTextureMask( uint flag )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000379 RID: 889 RVA: 0x0001BAC5 File Offset: 0x00019CC5
    private void nnPutMaterialTextureOneGL( int slot, AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_TEXMAP_DESC pTex )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600037A RID: 890 RVA: 0x0001BACC File Offset: 0x00019CCC
    private static void nnPutMaterialTextureOneGLES11( int slot, AppMain.NNS_DRAWCALLBACK_VAL val, ref AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC pTex )
    {
        uint fType = pTex.fType;
        uint num = fType & 3841U;
        if ( pTex.pTexInfo != null )
        {
            AppMain.nnSetTexInfo( slot, ( AppMain.NNS_TEXINFO )pTex.pTexInfo );
        }
        else
        {
            AppMain.nnSetTextureNum( slot, pTex.iTexIdx );
        }
        uint num2 = num;
        int num3;
        if ( num2 != 1U )
        {
            if ( num2 != 256U )
            {
                if ( num2 == 512U )
                {
                    num3 = 2;
                    goto IL_8F;
                }
            }
            num3 = 1;
        }
        else if ( ( val.DrawFlag & 16777216U ) != 0U )
        {
            switch ( AppMain.nngMatCtrlEnvTexMtx.texcoordsrc )
            {
                case 0:
                    num3 = 4;
                    break;
                default:
                    num3 = 3;
                    break;
            }
        }
        else
        {
            num3 = 3;
        }
        IL_8F:
        AppMain.nnSetTexCoordSrc( slot, num3 );
        if ( num3 != 3 )
        {
            OpenGL.glMatrixMode( 5890U );
            OpenGL.glLoadIdentity();
            OpenGL.glTranslatef( 0f, 1f, 0f );
            OpenGL.glScalef( 1f, -1f, 1f );
            if ( ( val.DrawFlag & 268435456U ) != 0U )
            {
                switch ( AppMain.nngMatCtrlTexOffset[slot].mode )
                {
                    default:
                        if ( ( fType & 1073741824U ) == 0U )
                        {
                            OpenGL.glTranslatef( pTex.Offset.u, pTex.Offset.v, 0f );
                        }
                        break;
                    case 1:
                        OpenGL.glTranslatef( AppMain.nngMatCtrlTexOffset[slot].offset.u, AppMain.nngMatCtrlTexOffset[slot].offset.v, 0f );
                        break;
                    case 2:
                        OpenGL.glTranslatef( pTex.Offset.u + AppMain.nngMatCtrlTexOffset[slot].offset.u, pTex.Offset.v + AppMain.nngMatCtrlTexOffset[slot].offset.v, 0f );
                        break;
                    case 3:
                        OpenGL.glTranslatef( pTex.Offset.u * AppMain.nngMatCtrlTexOffset[slot].offset.u, pTex.Offset.v * AppMain.nngMatCtrlTexOffset[slot].offset.v, 0f );
                        break;
                }
            }
            else if ( ( fType & 1073741824U ) == 0U )
            {
                OpenGL.glTranslatef( pTex.Offset.u, pTex.Offset.v, 0f );
            }
            if ( ( fType & 65536U ) != 0U )
            {
                OpenGL.glScalef( pTex.Scale.u, pTex.Scale.v, 1f );
            }
        }
        OpenGL.glTexEnvi( 8960U, 8704U, pTex.EnvMode );
        if ( pTex.pCombine != null )
        {
            AppMain.NNS_TEXTURE_GLES11_COMBINE pCombine = pTex.pCombine;
            OpenGL.glTexEnvi( 8960U, 34161U, ( int )pCombine.CombineRGB );
            OpenGL.glTexEnvi( 8960U, 34176U, ( int )pCombine.Source0RGB );
            OpenGL.glTexEnvi( 8960U, 34192U, ( int )pCombine.Operand0RGB );
            OpenGL.glTexEnvi( 8960U, 34177U, ( int )pCombine.Source1RGB );
            OpenGL.glTexEnvi( 8960U, 34193U, ( int )pCombine.Operand1RGB );
            OpenGL.glTexEnvi( 8960U, 34178U, ( int )pCombine.Source2RGB );
            OpenGL.glTexEnvi( 8960U, 34194U, ( int )pCombine.Operand2RGB );
            OpenGL.glTexEnvi( 8960U, 34162U, ( int )pCombine.CombineAlpha );
            OpenGL.glTexEnvi( 8960U, 34184U, ( int )pCombine.Source0Alpha );
            OpenGL.glTexEnvi( 8960U, 34200U, ( int )pCombine.Operand0Alpha );
            OpenGL.glTexEnvi( 8960U, 34185U, ( int )pCombine.Source1Alpha );
            OpenGL.glTexEnvi( 8960U, 34201U, ( int )pCombine.Operand1Alpha );
            OpenGL.glTexEnvi( 8960U, 34186U, ( int )pCombine.Source2Alpha );
            OpenGL.glTexEnvi( 8960U, 34202U, ( int )pCombine.Operand2Alpha );
            OpenGL.glTexEnvfv( 8960U, 8705U, ( OpenGL.glArray4f )pCombine.EnvColor );
        }
        OpenGL.glTexParameteri( 3553U, 10242U, pTex.WrapS );
        OpenGL.glTexParameteri( 3553U, 10243U, pTex.WrapT );
        if ( pTex.pFilterMode != null )
        {
            AppMain.NNS_TEXTURE_FILTERMODE pFilterMode = pTex.pFilterMode;
            OpenGL.glTexParameteri( 3553U, 10240U, ( int )pFilterMode.MagFilter );
            OpenGL.glTexParameteri( 3553U, 10241U, ( int )pFilterMode.MinFilter );
        }
    }

    // Token: 0x0600037B RID: 891 RVA: 0x0001BEF0 File Offset: 0x0001A0F0
    private static void nnPutMaterialTexturesGL( AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_TEXMAP_DESC[] texdesc, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600037C RID: 892 RVA: 0x0001BEF8 File Offset: 0x0001A0F8
    private static void nnPutMaterialTexturesGLES11( AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] texdesc, int num )
    {
        int max_texture_units = AppMain.nngGLExtensions.max_texture_units;
        int i = 0;
        for ( int j = 0; j < num; j++ )
        {
            AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC nns_MATERIAL_GLES11_TEXMAP_DESC = texdesc[j];
            AppMain.nnPutMaterialTextureOneGLES11( i, val, ref nns_MATERIAL_GLES11_TEXMAP_DESC );
            i++;
            if ( i >= max_texture_units )
            {
                return;
            }
        }
        while ( i < max_texture_units )
        {
            AppMain.nnSetTextureNum( i, -1 );
            AppMain.nnSetTexCoordSrc( i, 0 );
            i++;
        }
    }

    // Token: 0x0600037D RID: 893 RVA: 0x0001BF51 File Offset: 0x0001A151
    private void nnPutMaterialStdShaderTextureOneGL( int slot, AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC pTex )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600037E RID: 894 RVA: 0x0001BF58 File Offset: 0x0001A158
    private void nnPutMaterialStdShaderTexturesGL( AppMain.NNS_DRAWCALLBACK_VAL val, AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC texdesc, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600037F RID: 895 RVA: 0x0001BF60 File Offset: 0x0001A160
    private static int nnPutMaterialCore( AppMain.NNS_DRAWCALLBACK_VAL val )
    {
        AppMain.NNS_MATERIALPTR pMaterial = val.pMaterial;
        if ( ( val.DrawFlag & 29440U ) != 0U )
        {
            AppMain.nnPutDisableTexturesGL();
            if ( ( val.DrawFlag & 768U ) != 0U )
            {
                AppMain.nnPutFixedMaterialGL();
                return 1;
            }
            if ( ( val.DrawFlag & 28672U ) != 0U )
            {
                AppMain.nnPutFixedMaterialGL();
                uint num = val.DrawFlag & 96U;
                if ( num != 32U )
                {
                    if ( num != 64U )
                    {
                        if ( num != 96U )
                        {
                            if ( ( ( ( AppMain.NNS_MATERIAL_DESC )pMaterial.pMaterial ).fFlag & 1U ) != 0U )
                            {
                                OpenGL.glDisable( 2884U );
                            }
                            else
                            {
                                OpenGL.glEnable( 2884U );
                                OpenGL.glCullFace( 1029U );
                            }
                        }
                        else
                        {
                            OpenGL.glEnable( 2884U );
                            OpenGL.glCullFace( 1029U );
                        }
                    }
                    else
                    {
                        OpenGL.glEnable( 2884U );
                        OpenGL.glCullFace( 1028U );
                    }
                }
                else
                {
                    OpenGL.glDisable( 2884U );
                }
                uint num2 = val.DrawFlag & 28672U;
                if ( num2 <= 12288U )
                {
                    if ( num2 != 4096U )
                    {
                        if ( num2 != 8192U )
                        {
                            if ( num2 != 12288U )
                            {
                            }
                        }
                        else if ( ( pMaterial.fType & 8U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = (AppMain.NNS_MATERIAL_GLES11_DESC)pMaterial.pMaterial;
                            AppMain.nnPutColorNTexture( nns_MATERIAL_GLES11_DESC.nTex );
                        }
                        else
                        {
                            AppMain.nnPutColorNTexture( 0 );
                        }
                    }
                    else
                    {
                        AppMain.nnPutWireColor();
                    }
                }
                else if ( num2 != 16384U )
                {
                    if ( num2 != 20480U )
                    {
                        if ( num2 == 24576U )
                        {
                            AppMain.nnPutColorNWeight( val.pVtxListPtr );
                        }
                    }
                    else
                    {
                        AppMain.nnPutColorMaterial( val.iMaterial );
                    }
                }
                else
                {
                    AppMain.nnPutColorMeshset( val.iMeshset, val.iSubobject );
                }
                return 1;
            }
        }
        if ( val.iPrevMaterial == -1 || val.bModified != 0 )
        {
            AppMain.nnInitPreviousMaterialValueGL();
        }
        else if ( val.iMaterial == val.iPrevMaterial )
        {
            return 1;
        }
        if ( ( pMaterial.fType & 8U ) != 0U )
        {
            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC2 = (AppMain.NNS_MATERIAL_GLES11_DESC)pMaterial.pMaterial;
            uint fFlag = nns_MATERIAL_GLES11_DESC2.fFlag;
            if ( fFlag != AppMain.nnmaterialcore.nngPreMatFlag )
            {
                AppMain.nnPutMaterialFlagGL( val, fFlag );
            }
            if ( nns_MATERIAL_GLES11_DESC2.pColor != AppMain.nnmaterialcore.nngpPreMatColor )
            {
                AppMain.nnPutMaterialColorGL( 1032U, val, nns_MATERIAL_GLES11_DESC2.pColor );
            }
            if ( nns_MATERIAL_GLES11_DESC2.pLogic != AppMain.nnmaterialcore.nngpPreMatLogic )
            {
                AppMain.nnPutMaterialLogicGLES11( val, nns_MATERIAL_GLES11_DESC2.pLogic );
            }
            if ( ( val.DrawFlag & 2048U ) == 0U )
            {
                AppMain.nnPutMaterialTexturesGLES11( val, nns_MATERIAL_GLES11_DESC2.pTexDesc, nns_MATERIAL_GLES11_DESC2.nTex );
            }
            else
            {
                AppMain.nnPutDisableTexturesGL();
            }
        }
        else if ( ( pMaterial.fType & 1U ) != 0U )
        {
            AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC = (AppMain.NNS_MATERIAL_DESC)pMaterial.pMaterial;
            uint fFlag2 = nns_MATERIAL_DESC.fFlag;
            if ( fFlag2 != AppMain.nnmaterialcore.nngPreMatFlag )
            {
                AppMain.nnPutMaterialFlagGL( val, fFlag2 );
            }
            if ( nns_MATERIAL_DESC.pColor != AppMain.nnmaterialcore.nngpPreMatColor )
            {
                AppMain.nnPutMaterialColorGL( 1032U, val, ( AppMain.NNS_MATERIAL_STDSHADER_COLOR )nns_MATERIAL_DESC.pColor );
            }
            if ( nns_MATERIAL_DESC.pLogic != AppMain.nnmaterialcore.nngpPreMatLogic )
            {
                AppMain.nnPutMaterialLogicGL( val, nns_MATERIAL_DESC.pLogic );
            }
            if ( ( val.DrawFlag & 2048U ) == 0U )
            {
                AppMain.nnPutMaterialTexturesGL( val, nns_MATERIAL_DESC.pTexDesc, nns_MATERIAL_DESC.nTex );
            }
            else
            {
                AppMain.nnPutDisableTexturesGL();
            }
        }
        return 1;
    }

    // Token: 0x060004B2 RID: 1202 RVA: 0x0002845F File Offset: 0x0002665F
    private int nnGetMaterialIndex( AppMain.NNS_NODENAMELIST pMaterialNameList, string MaterialName )
    {
        return this.nnGetNodeIndex( pMaterialNameList, MaterialName );
    }

    // Token: 0x060004B3 RID: 1203 RVA: 0x00028469 File Offset: 0x00026669
    private string nnGetMaterialName( AppMain.NNS_NODENAMELIST pMaterialNameList, int MaterialIndex )
    {
        return this.nnGetNodeName( pMaterialNameList, MaterialIndex );
    }

    // Token: 0x060004B4 RID: 1204 RVA: 0x00028474 File Offset: 0x00026674
    private static void nnSetPrimitive3DMaterial( ref AppMain.NNS_RGBA diffuse, ref AppMain.SNNS_RGB ambient, float specular )
    {
        AppMain.nndrawprim3d.nnsDiffuse[0] = diffuse.r;
        AppMain.nndrawprim3d.nnsDiffuse[1] = diffuse.g;
        AppMain.nndrawprim3d.nnsDiffuse[2] = diffuse.b;
        AppMain.nndrawprim3d.nnsDiffuse[3] = diffuse.a;
        AppMain.nndrawprim3d.nnsAmbient[0] = ambient.r;
        AppMain.nndrawprim3d.nnsAmbient[1] = ambient.g;
        AppMain.nndrawprim3d.nnsAmbient[2] = ambient.b;
        AppMain.nndrawprim3d.nnsAmbient[3] = 1f;
        AppMain.nndrawprim3d.nnsSpecular[0] = specular;
        AppMain.nndrawprim3d.nnsSpecular[1] = specular;
        AppMain.nndrawprim3d.nnsSpecular[2] = specular;
        AppMain.nndrawprim3d.nnsSpecular[3] = 1f;
    }

    // Token: 0x060004B5 RID: 1205 RVA: 0x0002850C File Offset: 0x0002670C
    private static void nnSetPrimitive3DMaterial( ref AppMain.NNS_RGBA diffuse, ref AppMain.NNS_RGB ambient, float specular )
    {
        AppMain.nndrawprim3d.nnsDiffuse[0] = diffuse.r;
        AppMain.nndrawprim3d.nnsDiffuse[1] = diffuse.g;
        AppMain.nndrawprim3d.nnsDiffuse[2] = diffuse.b;
        AppMain.nndrawprim3d.nnsDiffuse[3] = diffuse.a;
        AppMain.nndrawprim3d.nnsAmbient[0] = ambient.r;
        AppMain.nndrawprim3d.nnsAmbient[1] = ambient.g;
        AppMain.nndrawprim3d.nnsAmbient[2] = ambient.b;
        AppMain.nndrawprim3d.nnsAmbient[3] = 1f;
        AppMain.nndrawprim3d.nnsSpecular[0] = specular;
        AppMain.nndrawprim3d.nnsSpecular[1] = specular;
        AppMain.nndrawprim3d.nnsSpecular[2] = specular;
        AppMain.nndrawprim3d.nnsSpecular[3] = 1f;
    }

    // Token: 0x060004B6 RID: 1206 RVA: 0x000285A8 File Offset: 0x000267A8
    private static void nnSetPrimitive3DMaterialGL( ref AppMain.NNS_RGBA diffuse, ref AppMain.NNS_RGBA ambient, ref AppMain.NNS_RGBA specular, float shininess, ref AppMain.NNS_RGBA emission )
    {
        AppMain.nndrawprim3d.nnsDiffuse[0] = diffuse.r;
        AppMain.nndrawprim3d.nnsDiffuse[1] = diffuse.g;
        AppMain.nndrawprim3d.nnsDiffuse[2] = diffuse.b;
        AppMain.nndrawprim3d.nnsDiffuse[3] = diffuse.a;
        AppMain.nndrawprim3d.nnsAmbient[0] = ambient.r;
        AppMain.nndrawprim3d.nnsAmbient[1] = ambient.g;
        AppMain.nndrawprim3d.nnsAmbient[2] = ambient.b;
        AppMain.nndrawprim3d.nnsAmbient[3] = ambient.a;
        AppMain.nndrawprim3d.nnsSpecular[0] = specular.r;
        AppMain.nndrawprim3d.nnsSpecular[1] = specular.g;
        AppMain.nndrawprim3d.nnsSpecular[2] = specular.b;
        AppMain.nndrawprim3d.nnsSpecular[3] = specular.a;
        AppMain.nndrawprim3d.nnsShininess = shininess;
        AppMain.nndrawprim3d.nnsEmission[0] = emission.r;
        AppMain.nndrawprim3d.nnsEmission[1] = emission.g;
        AppMain.nndrawprim3d.nnsEmission[2] = emission.b;
        AppMain.nndrawprim3d.nnsEmission[3] = emission.a;
    }

    // Token: 0x060004B7 RID: 1207 RVA: 0x0002868F File Offset: 0x0002688F
    private static void nnSetPrimitive3DMatrix( ref AppMain.SNNS_MATRIX mtx )
    {
        AppMain.nnCopyMatrix( AppMain.nndrawprim3d.nnsPrim3DMatrix, ref mtx );
    }

    // Token: 0x060004B8 RID: 1208 RVA: 0x0002869C File Offset: 0x0002689C
    private static void nnSetPrimitive3DMatrix( AppMain.NNS_MATRIX mtx )
    {
        AppMain.nnCopyMatrix( AppMain.nndrawprim3d.nnsPrim3DMatrix, mtx );
    }

    // Token: 0x060004B9 RID: 1209 RVA: 0x000286AC File Offset: 0x000268AC
    private static void nnChangePrimitive3DMatrix( AppMain.NNS_MATRIX mtx )
    {
        OpenGL.glMatrixMode( 5888U );
        Matrix matrix = (Matrix)mtx;
        OpenGL.glLoadMatrixf( ref matrix );
        if ( AppMain.nngDrawPrimTexCoord == 1 )
        {
            AppMain.nnPutEnvironmentTextureMatrix( mtx );
        }
    }

    // Token: 0x060004BA RID: 1210 RVA: 0x000286DF File Offset: 0x000268DF
    private static void nnSetPrimitive3DAlphaFuncGL( uint func, float _ref )
    {
        AppMain.nndrawprim3d.nnsAlphaFunc = func;
        AppMain.nndrawprim3d.nnsAlphaFuncRef = _ref;
    }

    // Token: 0x060004BB RID: 1211 RVA: 0x000286ED File Offset: 0x000268ED
    private static void nnSetPrimitive3DDepthFuncGL( uint func )
    {
        AppMain.nndrawprim3d.nnsDepthFunc = func;
    }

    // Token: 0x060004BC RID: 1212 RVA: 0x000286F5 File Offset: 0x000268F5
    private static void nnSetPrimitive3DDepthMaskGL( bool flag )
    {
        AppMain.nndrawprim3d.nnsDepthMask = flag;
    }

    // Token: 0x060004BD RID: 1213 RVA: 0x00028700 File Offset: 0x00026900
    private static void nnBeginDrawPrimitive3DCore( int fmt, int blend, int light )
    {
        OpenGL.glShadeModel( 7425U );
        OpenGL.glLightModelf( 2898U, 0f );
        OpenGL.glEnable( 3008U );
        OpenGL.glAlphaFunc( AppMain.nndrawprim3d.nnsAlphaFunc, AppMain.nndrawprim3d.nnsAlphaFuncRef );
        OpenGL.glEnable( 2929U );
        OpenGL.glDepthFunc( AppMain.nndrawprim3d.nnsDepthFunc );
        OpenGL.glDepthMask( AppMain.nndrawprim3d.nnsDepthMask );
        OpenGL.glColorMask( 1, 1, 1, 1 );
        OpenGL.glBindBuffer( 34962U, 0U );
        OpenGL.glBindBuffer( 34963U, 0U );
        OpenGL.glDisableClientState( 34477U );
        OpenGL.glDisableClientState( 34884U );
        if ( blend == 1 )
        {
            OpenGL.glEnable( 3042U );
            switch ( AppMain.nngDrawPrimBlend )
            {
                case 0:
                    OpenGL.glBlendFunc( 770U, 1U );
                    OpenGL.glBlendEquation( 32774U );
                    goto IL_E3;
            }
            OpenGL.glBlendFunc( 770U, 771U );
            OpenGL.glBlendEquation( 32774U );
        }
        else
        {
            OpenGL.glDisable( 3042U );
        }
        IL_E3:
        AppMain.nnPutFogSwitchGL( AppMain.nngFogSwitch );
        switch ( light )
        {
            case 0:
                OpenGL.glDisable( 2896U );
                OpenGL.glMaterialfv( 1032U, 4609U, ( OpenGL.glArray4f )AppMain.nngColorWhite );
                OpenGL.glColor4fv( AppMain.nndrawprim3d.nnsDiffuse );
                break;
            case 1:
                OpenGL.glEnable( 2896U );
                OpenGL.glMaterialfv( 1032U, 4608U, AppMain.nndrawprim3d.nnsAmbient );
                OpenGL.glMaterialfv( 1032U, 4609U, AppMain.nndrawprim3d.nnsDiffuse );
                OpenGL.glMaterialfv( 1032U, 4610U, ( OpenGL.glArray4f )AppMain.nngColorBlack );
                OpenGL.glMaterialf( 1032U, 5633U, 0f );
                OpenGL.glMaterialfv( 1032U, 5632U, ( OpenGL.glArray4f )AppMain.nngColorBlack );
                OpenGL.glColor4fv( ( OpenGL.glArray4f )AppMain.nngColorWhite );
                break;
            case 2:
                OpenGL.glEnable( 2896U );
                OpenGL.glMaterialfv( 1032U, 4608U, AppMain.nndrawprim3d.nnsAmbient );
                OpenGL.glMaterialfv( 1032U, 4609U, AppMain.nndrawprim3d.nnsDiffuse );
                OpenGL.glMaterialfv( 1032U, 4610U, AppMain.nndrawprim3d.nnsSpecular );
                OpenGL.glMaterialf( 1032U, 5633U, AppMain.nndrawprim3d.nnsShininess );
                OpenGL.glMaterialfv( 1032U, 5632U, AppMain.nndrawprim3d.nnsEmission );
                OpenGL.glColor4fv( ( OpenGL.glArray4f )AppMain.nngColorWhite );
                break;
        }
        AppMain.nndrawprim3d.nnsFormat = fmt;
        switch ( fmt )
        {
            default:
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glDisableClientState( 32885U );
                OpenGL.glDisableClientState( 32886U );
                AppMain.nnPutPrimitiveNoTexture();
                break;
            case 1:
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glEnableClientState( 32885U );
                OpenGL.glDisableClientState( 32886U );
                if ( AppMain.nngDrawPrimTexCoord == 1 )
                {
                    OpenGL.glClientActiveTexture( 33984U );
                    OpenGL.glEnableClientState( 32888U );
                    AppMain.nnPutPrimitiveTexParameter();
                    AppMain.nnSetTexCoordSrc( 0, 3 );
                    AppMain.nnSetTexCoordSrc( 1, 0 );
                    AppMain.nnSetNormalFormatType( 5126U );
                    AppMain.nnPutEnvironmentTextureMatrix( AppMain.nndrawprim3d.nnsPrim3DMatrix );
                }
                else
                {
                    AppMain.nnPutPrimitiveNoTexture();
                }
                break;
            case 2:
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glDisableClientState( 32885U );
                OpenGL.glEnableClientState( 32886U );
                OpenGL.glClientActiveTexture( 33984U );
                OpenGL.glEnableClientState( 32888U );
                AppMain.nnPutPrimitiveNoTexture();
                break;
            case 3:
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glEnableClientState( 32885U );
                OpenGL.glDisableClientState( 32886U );
                OpenGL.glClientActiveTexture( 33984U );
                OpenGL.glEnableClientState( 32888U );
                AppMain.nnPutPrimitiveTexParameter();
                OpenGL.glMatrixMode( 5890U );
                OpenGL.glLoadIdentity();
                OpenGL.glTranslatef( 0f, 1f, 0f );
                OpenGL.glScalef( 1f, -1f, 1f );
                break;
            case 4:
                OpenGL.glEnableClientState( 32884U );
                OpenGL.glDisableClientState( 32885U );
                OpenGL.glEnableClientState( 32886U );
                OpenGL.glClientActiveTexture( 33984U );
                OpenGL.glEnableClientState( 32888U );
                AppMain.nnPutPrimitiveTexParameter();
                OpenGL.glMatrixMode( 5890U );
                OpenGL.glLoadIdentity();
                OpenGL.glTranslatef( 0f, 1f, 0f );
                OpenGL.glScalef( 1f, -1f, 1f );
                break;
        }
        OpenGL.glMatrixMode( 5888U );
        Matrix matrix = (Matrix)AppMain.nndrawprim3d.nnsPrim3DMatrix;
        OpenGL.glLoadMatrixf( ref matrix );
    }

    // Token: 0x060004BE RID: 1214 RVA: 0x00028B3C File Offset: 0x00026D3C
    private static void nnDrawPrimitive3DCore( uint mode, object vtx, int count )
    {
        switch ( AppMain.nndrawprim3d.nnsFormat )
        {
            case 0:
                AppMain.mppOpenGLFeatureNotImplAssert();
                return;
            case 1:
                AppMain.mppOpenGLFeatureNotImplAssert();
                return;
            case 2:
                {
                    AppMain.NNS_PRIM3D_PC[] array = (AppMain.NNS_PRIM3D_PC[])vtx;
                    int num = 0;
                    AppMain.RGBA_U8[] cbuf = AppMain._nnDrawPrimitive3DCore.cbuf;
                    AppMain._nnDrawPrimitive3DCore.colorData.Init( cbuf, 0 );
                    OpenGL.glColorPointer( 4, 5121U, 0, AppMain._nnDrawPrimitive3DCore.colorData );
                    int i;
                    for ( i = 0; i < count; i++ )
                    {
                        uint col = array[i].Col;
                        if ( num >= 6 )
                        {
                            OpenGL.glVertexPointer( 3, 5126U, 0, new AppMain.NNS_PRIM3D_PC_VertexData( array, i - num ) );
                            OpenGL.glDrawArrays( mode, 0, num );
                            switch ( mode )
                            {
                                case 3U:
                                    cbuf[0] = cbuf[5];
                                    num = 1;
                                    goto IL_100;
                                case 5U:
                                    cbuf[0] = cbuf[4];
                                    cbuf[1] = cbuf[5];
                                    num = 2;
                                    goto IL_100;
                            }
                            num = 0;
                        }
                        IL_100:
                        cbuf[num].r = ( byte )( col >> 24 );
                        cbuf[num].g = ( byte )( col >> 16 );
                        cbuf[num].b = ( byte )( col >> 8 );
                        cbuf[num].a = ( byte )col;
                        num++;
                    }
                    if ( num > 0 )
                    {
                        AppMain._nnDrawPrimitive3DCore.vertexDataPC.Init( array, i - num );
                        OpenGL.glVertexPointer( 3, 5126U, 0, AppMain._nnDrawPrimitive3DCore.vertexDataPC );
                        OpenGL.glDrawArrays( mode, 0, num );
                        return;
                    }
                    break;
                }
            case 3:
                AppMain.mppOpenGLFeatureNotImplAssert();
                return;
            case 4:
                {
                    AppMain.NNS_PRIM3D_PCT_ARRAY nns_PRIM3D_PCT_ARRAY = (AppMain.NNS_PRIM3D_PCT_ARRAY)vtx;
                    AppMain.NNS_PRIM3D_PCT[] buffer = nns_PRIM3D_PCT_ARRAY.buffer;
                    int offset = nns_PRIM3D_PCT_ARRAY.offset;
                    int num2 = count;
                    switch ( mode )
                    {
                        case 3U:
                            AppMain.mppAssertNotImpl();
                            break;
                        case 5U:
                            num2 = ( num2 - 2 ) * 3;
                            break;
                    }
                    if ( AppMain._nnDrawPrimitive3DCore.prim_d == null || AppMain._nnDrawPrimitive3DCore.prim_d.Length < num2 )
                    {
                        AppMain._nnDrawPrimitive3DCore.prim_d = new AppMain.NNS_PRIM3D_PCT[num2 * 2];
                        AppMain._nnDrawPrimitive3DCore.prim_c = new AppMain.RGBA_U8[num2 * 2];
                    }
                    AppMain.NNS_PRIM3D_PCT[] prim_d = AppMain._nnDrawPrimitive3DCore.prim_d;
                    AppMain.RGBA_U8[] prim_c = AppMain._nnDrawPrimitive3DCore.prim_c;
                    int num3 = 0;
                    AppMain._nnDrawPrimitive3DCore.colorData.Init( prim_c, 0 );
                    OpenGL.glColorPointer( 4, 5121U, 0, AppMain._nnDrawPrimitive3DCore.colorData );
                    OpenGL.glClientActiveTexture( 33984U );
                    for ( int j = 0; j < count; j++ )
                    {
                        uint col2 = buffer[offset + j].Col;
                        if ( num3 >= 6 )
                        {
                            switch ( mode )
                            {
                                case 3U:
                                    prim_c[num3] = prim_c[num3 - 1];
                                    prim_d[num3] = prim_d[num3 - 1];
                                    num3++;
                                    break;
                                case 5U:
                                    prim_c[num3] = prim_c[num3 - 2];
                                    prim_c[num3 + 1] = prim_c[num3 - 1];
                                    prim_d[num3] = prim_d[num3 - 2];
                                    prim_d[num3 + 1] = prim_d[num3 - 1];
                                    num3 += 2;
                                    break;
                            }
                        }
                        prim_c[num3].r = ( byte )( col2 >> 24 );
                        prim_c[num3].g = ( byte )( col2 >> 16 );
                        prim_c[num3].b = ( byte )( col2 >> 8 );
                        prim_c[num3].a = ( byte )col2;
                        prim_d[num3] = buffer[offset + j];
                        num3++;
                    }
                    AppMain._nnDrawPrimitive3DCore.vertexData.Init( prim_d, 0 );
                    AppMain._nnDrawPrimitive3DCore.texCoordData.Init( prim_d, 0 );
                    OpenGL.glVertexPointer( 3, 5126U, 0, AppMain._nnDrawPrimitive3DCore.vertexData );
                    OpenGL.glTexCoordPointer( 2, 5126U, 0, AppMain._nnDrawPrimitive3DCore.texCoordData );
                    OpenGL.glDrawArrays( mode, 0, num3 );
                    break;
                }
            default:
                return;
        }
    }

    // Token: 0x060004BF RID: 1215 RVA: 0x00028F48 File Offset: 0x00027148
    private static void nnEndDrawPrimitive3DCore()
    {
    }

    // Token: 0x060004C0 RID: 1216 RVA: 0x00028F4C File Offset: 0x0002714C
    private static void nnBeginDrawPrimitive3D( int fmt, int blend, int light, int cull )
    {
        AppMain.nnBeginDrawPrimitive3DCore( fmt, blend, light );
        switch ( cull )
        {
            case 0:
                OpenGL.glDisable( 2884U );
                return;
            case 1:
                OpenGL.glEnable( 2884U );
                OpenGL.glCullFace( 1029U );
                return;
            case 2:
                OpenGL.glEnable( 2884U );
                OpenGL.glCullFace( 1028U );
                return;
            default:
                return;
        }
    }

    // Token: 0x060004C1 RID: 1217 RVA: 0x00028FAC File Offset: 0x000271AC
    private static void nnDrawPrimitive3D( int type, object vtx, int count )
    {
        uint mode;
        switch ( type )
        {
            case 0:
                mode = 4U;
                goto IL_18;
        }
        mode = 5U;
        IL_18:
        AppMain.nnDrawPrimitive3DCore( mode, vtx, count );
    }

    // Token: 0x060004C2 RID: 1218 RVA: 0x00028FD9 File Offset: 0x000271D9
    private static void nnEndDrawPrimitive3D()
    {
        AppMain.nnEndDrawPrimitive3DCore();
    }

    // Token: 0x060004C3 RID: 1219 RVA: 0x00028FE0 File Offset: 0x000271E0
    private static void nnBeginDrawPrimitiveLine3D( ref AppMain.NNS_RGBA col, int blend )
    {
        AppMain.nnBeginDrawPrimitive3DCore( 0, blend, 0 );
        OpenGL.glDisable( 2896U );
        OpenGL.glColor4fv( ( OpenGL.glArray4f )col );
    }

    // Token: 0x060004C4 RID: 1220 RVA: 0x00029004 File Offset: 0x00027204
    private static void nnDrawPrimitiveLine3D( AppMain.NNE_PRIM_LINE type, object vtx, int count )
    {
        uint mode;
        switch ( type )
        {
            case AppMain.NNE_PRIM_LINE.NNE_PRIM_LINE_LIST:
                mode = 1U;
                goto IL_18;
        }
        mode = 3U;
        IL_18:
        AppMain.nnDrawPrimitive3DCore( mode, vtx, count );
    }

    // Token: 0x060004C5 RID: 1221 RVA: 0x00029031 File Offset: 0x00027231
    private static void nnEndDrawPrimitiveLine3D()
    {
        AppMain.nnEndDrawPrimitive3DCore();
    }

    // Token: 0x060004C6 RID: 1222 RVA: 0x00029038 File Offset: 0x00027238
    private static void nnDrawPrimitivePoint3D( object vtx, int count )
    {
        AppMain.nnDrawPrimitive3DCore( 0U, vtx, count );
    }

    // Token: 0x060004C7 RID: 1223 RVA: 0x00029042 File Offset: 0x00027242
    private static void nnEndDrawPrimitivePoint3D()
    {
        AppMain.nnEndDrawPrimitive3DCore();
    }

    // Token: 0x060004C8 RID: 1224 RVA: 0x00029049 File Offset: 0x00027249
    private int nnCalcMorphMotionWeight( ref AppMain.NNS_SUBMOTION submot, float frame, ref float weight )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x060004C9 RID: 1225 RVA: 0x00029051 File Offset: 0x00027251
    private void nnCalcMorphMotion( float[] mwpal, ref AppMain.NNS_MORPHTARGETLIST mtgt, ref AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060004CA RID: 1226 RVA: 0x00029058 File Offset: 0x00027258
    private void nnBlendMorphWeightPalette( float[] dstmwpal, float[] srcmwpal0, float ratio0, float[] srcmwpal1, float ratio1, ref AppMain.NNS_MORPHTARGETLIST mtgt )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060004CB RID: 1227 RVA: 0x0002905F File Offset: 0x0002725F
    public static void nnCopyQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION src )
    {
        dst = src;
    }

    // Token: 0x060004CC RID: 1228 RVA: 0x00029070 File Offset: 0x00027270
    public static void nnMultiplyQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION quat1, ref AppMain.NNS_QUATERNION quat2 )
    {
        float x = quat1.x;
        float y = quat1.y;
        float z = quat1.z;
        float w = quat1.w;
        float x2 = quat2.x;
        float y2 = quat2.y;
        float z2 = quat2.z;
        float w2 = quat2.w;
        dst.x = w * x2 + x * w2 + y * z2 - z * y2;
        dst.y = w * y2 - x * z2 + y * w2 + z * x2;
        dst.z = w * z2 + x * y2 - y * x2 + z * w2;
        dst.w = w * w2 - x * x2 - y * y2 - z * z2;
    }

    // Token: 0x060004CD RID: 1229 RVA: 0x00029120 File Offset: 0x00027320
    public static int nnNormalizeQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION src )
    {
        float num = src.x * src.x + src.y * src.y + src.z * src.z + src.w * src.w;
        if ( num == 0f )
        {
            dst.x = 0f;
            dst.y = 0f;
            dst.z = 0f;
            dst.w = 0f;
            return 0;
        }
        num = AppMain.nnInvertSqrt( num );
        dst.x = src.x * num;
        dst.y = src.y * num;
        dst.z = src.z * num;
        dst.w = src.w * num;
        return 1;
    }

    // Token: 0x060004CE RID: 1230 RVA: 0x000291DC File Offset: 0x000273DC
    public static int nnInvertQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION src )
    {
        float num = src.x * src.x + src.y * src.y + src.z * src.z + src.w * src.w;
        if ( num == 0f )
        {
            dst.x = 0f;
            dst.y = 0f;
            dst.z = 0f;
            dst.w = 0f;
            return 0;
        }
        float num2 = 1f / num;
        dst.x = -src.x * num2;
        dst.y = -src.y * num2;
        dst.z = -src.z * num2;
        dst.w = src.w * num2;
        return 1;
    }

    // Token: 0x060004CF RID: 1231 RVA: 0x0002929C File Offset: 0x0002749C
    private static void nnLogQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION src )
    {
        int num = AppMain.nnArcCos((double)src.w);
        float num2 = AppMain.nnSin(num);
        if ( num2 > 0f )
        {
            float num3 = 1f / num2;
            dst.x = AppMain.NNM_A32toRAD( num ) * src.x * num3;
            dst.y = AppMain.NNM_A32toRAD( num ) * src.y * num3;
            dst.z = AppMain.NNM_A32toRAD( num ) * src.z * num3;
            dst.w = 0f;
            return;
        }
        dst.x = 0f;
        dst.y = 0f;
        dst.z = 0f;
        dst.w = 0f;
    }

    // Token: 0x060004D0 RID: 1232 RVA: 0x00029344 File Offset: 0x00027544
    public static void nnExpQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION src )
    {
        float num = AppMain.nnSqrt(src.x * src.x + src.y * src.y + src.z * src.z);
        float num2;
        float w;
        AppMain.nnSinCos( AppMain.NNM_RADtoA32( num ), out num2, out w );
        if ( num > 0f )
        {
            float num3 = 1f / num;
            dst.x = num2 * src.x * num3;
            dst.y = num2 * src.y * num3;
            dst.z = num2 * src.z * num3;
            dst.w = w;
            return;
        }
        dst.x = 0f;
        dst.y = 0f;
        dst.z = 0f;
        dst.w = w;
    }

    // Token: 0x060004D1 RID: 1233 RVA: 0x00029400 File Offset: 0x00027600
    private static void nnSplineQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION quatprev, ref AppMain.NNS_QUATERNION quat, ref AppMain.NNS_QUATERNION quatnext )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.nnInvertQuaternion( ref nns_QUATERNION2, ref quat );
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION3, ref nns_QUATERNION2, ref quatprev );
        AppMain.nnMultiplyQuaternion( ref nns_QUATERNION4, ref nns_QUATERNION2, ref quatnext );
        AppMain.nnLogQuaternion( ref nns_QUATERNION3, ref nns_QUATERNION3 );
        AppMain.nnLogQuaternion( ref nns_QUATERNION4, ref nns_QUATERNION4 );
        nns_QUATERNION.x = ( nns_QUATERNION3.x + nns_QUATERNION4.x ) / -4f;
        nns_QUATERNION.y = ( nns_QUATERNION3.y + nns_QUATERNION4.y ) / -4f;
        nns_QUATERNION.z = ( nns_QUATERNION3.z + nns_QUATERNION4.z ) / -4f;
        nns_QUATERNION.w = ( nns_QUATERNION3.w + nns_QUATERNION4.w ) / -4f;
        AppMain.nnExpQuaternion( ref nns_QUATERNION, ref nns_QUATERNION );
        AppMain.nnMultiplyQuaternion( ref dst, ref quat, ref nns_QUATERNION );
    }

    // Token: 0x060004D2 RID: 1234 RVA: 0x000294E0 File Offset: 0x000276E0
    private static void nnLerpQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION quat1, ref AppMain.NNS_QUATERNION quat2, float t )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        float num = 1f - t;
        float num2 = quat1.x * quat2.x + quat1.y * quat2.y + quat1.z * quat2.z + quat1.w * quat2.w;
        if ( num2 > 0f )
        {
            nns_QUATERNION.x = quat1.x * num + quat2.x * t;
            nns_QUATERNION.y = quat1.y * num + quat2.y * t;
            nns_QUATERNION.z = quat1.z * num + quat2.z * t;
            nns_QUATERNION.w = quat1.w * num + quat2.w * t;
        }
        else
        {
            nns_QUATERNION.x = quat1.x * num - quat2.x * t;
            nns_QUATERNION.y = quat1.y * num - quat2.y * t;
            nns_QUATERNION.z = quat1.z * num - quat2.z * t;
            nns_QUATERNION.w = quat1.w * num - quat2.w * t;
        }
        AppMain.nnNormalizeQuaternion( ref dst, ref nns_QUATERNION );
    }

    // Token: 0x060004D3 RID: 1235 RVA: 0x00029608 File Offset: 0x00027808
    private static void nnSlerpQuaternion( out AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION quat1, ref AppMain.NNS_QUATERNION quat2, float t )
    {
        float num = 1f;
        float num2 = 1f - t;
        float num3 = quat1.x * quat2.x + quat1.y * quat2.y + quat1.z * quat2.z + quat1.w * quat2.w;
        if ( num3 < 0f )
        {
            num3 = -num3;
            num = -num;
        }
        float num6;
        float num7;
        if ( num3 < 0.99999f )
        {
            float num4 = 2f - 2.828427f * AppMain.nnInvertSqrt(1f + num3);
            float num5 = num4 * t;
            num6 = num2 * ( 1f - num5 );
            num7 = -num5 * num2 + t;
            float num8 = AppMain.nnInvertSqrt(num6 * num6 + num7 * num7 + 2f * num6 * num7 * num3);
            num6 *= num8;
            num7 *= num8 * num;
        }
        else
        {
            num6 = num2;
            num7 = t * num;
        }
        dst.x = quat1.x * num6 + quat2.x * num7;
        dst.y = quat1.y * num6 + quat2.y * num7;
        dst.z = quat1.z * num6 + quat2.z * num7;
        dst.w = quat1.w * num6 + quat2.w * num7;
    }

    // Token: 0x060004D4 RID: 1236 RVA: 0x00029744 File Offset: 0x00027944
    private void nnSlerpNoInvQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION q1, ref AppMain.NNS_QUATERNION q2, float t )
    {
        float num = q1.x * q2.x + q1.y * q2.y + q1.z * q2.z + q1.w * q2.w;
        float num5;
        float num6;
        if ( num >= -0.98f && num <= 0.98f )
        {
            int num2 = AppMain.nnArcCos((double)num);
            float num3 = AppMain.nnSin(num2);
            float num4 = 1f / num3;
            num5 = AppMain.nnSin( ( int )( ( float )num2 * ( 1f - t ) ) ) * num4;
            num6 = AppMain.nnSin( ( int )( ( float )num2 * t ) ) * num4;
        }
        else
        {
            num5 = 1f - t;
            num6 = t;
        }
        dst.x = q1.x * num5 + q2.x * num6;
        dst.y = q1.y * num5 + q2.y * num6;
        dst.z = q1.z * num5 + q2.z * num6;
        dst.w = q1.w * num5 + q2.w * num6;
    }

    // Token: 0x060004D5 RID: 1237 RVA: 0x00029844 File Offset: 0x00027A44
    private static void nnSquadQuaternion( ref AppMain.NNS_QUATERNION dst, ref AppMain.NNS_QUATERNION quat1, ref AppMain.NNS_QUATERNION quata, ref AppMain.NNS_QUATERNION quatb, ref AppMain.NNS_QUATERNION quat2, float t )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        float t2 = 2f * t * (1f - t);
        AppMain.nnSlerpQuaternion( out nns_QUATERNION, ref quat1, ref quat2, t );
        AppMain.nnSlerpQuaternion( out nns_QUATERNION2, ref quata, ref quatb, t );
        AppMain.nnSlerpQuaternion( out dst, ref nns_QUATERNION, ref nns_QUATERNION2, t2 );
    }

    // Token: 0x060004D6 RID: 1238 RVA: 0x00029895 File Offset: 0x00027A95
    public static void nnMakeUnitQuaternion( ref AppMain.NNS_QUATERNION dst )
    {
        dst.x = 0f;
        dst.y = 0f;
        dst.z = 0f;
        dst.w = 1f;
    }

    // Token: 0x060004D7 RID: 1239 RVA: 0x000298C4 File Offset: 0x00027AC4
    private static void nnMakeRotateAxisQuaternion( out AppMain.NNS_QUATERNION dst, float vx, float vy, float vz, int ang )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        nns_VECTOR.x = vx;
        nns_VECTOR.y = vy;
        nns_VECTOR.z = vz;
        AppMain.nnNormalizeVector( nns_VECTOR, nns_VECTOR );
        ang >>= 1;
        float num;
        float w;
        AppMain.nnSinCos( ang, out num, out w );
        dst.x = nns_VECTOR.x * num;
        dst.y = nns_VECTOR.y * num;
        dst.z = nns_VECTOR.z * num;
        dst.w = w;
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
    }

    // Token: 0x060004D8 RID: 1240 RVA: 0x0002993C File Offset: 0x00027B3C
    public static void nnMakeRotateMatrixQuaternion( out AppMain.NNS_QUATERNION dst, AppMain.NNS_MATRIX mtx )
    {
        int[] nxt = AppMain._nnMakeRotateMatrixQuaternion.nxt;
        nxt[0] = 1;
        nxt[1] = 2;
        nxt[2] = 0;
        float[] q = AppMain._nnMakeRotateMatrixQuaternion.q;
        float num = mtx.M00 + mtx.M11 + mtx.M22;
        float num2;
        if ( num > 0f )
        {
            num2 = AppMain.nnSqrt( num + 1f );
            dst.w = num2 * 0.5f;
            num2 = 0.5f / num2;
            dst.x = ( mtx.M21 - mtx.M12 ) * num2;
            dst.y = ( mtx.M02 - mtx.M20 ) * num2;
            dst.z = ( mtx.M10 - mtx.M01 ) * num2;
            return;
        }
        int num3 = 0;
        if ( mtx.M11 > mtx.M00 )
        {
            num3 = 1;
        }
        if ( mtx.M22 > mtx.M( num3, num3 ) )
        {
            num3 = 2;
        }
        int num4 = nxt[num3];
        int num5 = nxt[num4];
        num2 = AppMain.nnSqrt( mtx.M( num3, num3 ) - ( mtx.M( num4, num4 ) + mtx.M( num5, num5 ) ) + 1f );
        q[num3] = num2 * 0.5f;
        if ( num2 != 0f )
        {
            num2 = 0.5f / num2;
        }
        dst.w = ( mtx.M( num5, num4 ) - mtx.M( num4, num5 ) ) * num2;
        q[num4] = ( mtx.M( num3, num4 ) + mtx.M( num4, num3 ) ) * num2;
        q[num5] = ( mtx.M( num3, num5 ) + mtx.M( num5, num3 ) ) * num2;
        dst.x = q[0];
        dst.y = q[1];
        dst.z = q[2];
    }

    // Token: 0x060004D9 RID: 1241 RVA: 0x00029AC8 File Offset: 0x00027CC8
    private static void nnMakeRotateXYZQuaternion( out AppMain.NNS_QUATERNION dst, int rx, int ry, int rz )
    {
        float num;
        float num2;
        if ( rx == 0 )
        {
            num = 0f;
            num2 = 1f;
        }
        else
        {
            int ang = rx >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num = num3;
            num2 = num4;
        }
        float num5;
        float num6;
        if ( ry == 0 )
        {
            num5 = 0f;
            num6 = 1f;
        }
        else
        {
            int ang = ry >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num5 = num3;
            num6 = num4;
        }
        float num7;
        float num8;
        if ( rz == 0 )
        {
            num7 = 0f;
            num8 = 1f;
        }
        else
        {
            int ang = rz >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num7 = num3;
            num8 = num4;
        }
        float num9 = num8 * num6;
        float num10 = num8 * num5;
        float num11 = num7 * num5;
        float num12 = num7 * num6;
        dst.x = num9 * num - num11 * num2;
        dst.y = num10 * num2 + num12 * num;
        dst.z = -num10 * num + num12 * num2;
        dst.w = num9 * num2 + num11 * num;
    }

    // Token: 0x060004DA RID: 1242 RVA: 0x00029BA4 File Offset: 0x00027DA4
    public static void nnMakeRotateXZYQuaternion( out AppMain.NNS_QUATERNION dst, int rx, int ry, int rz )
    {
        float num;
        float num2;
        if ( rx == 0 )
        {
            num = 0f;
            num2 = 1f;
        }
        else
        {
            int ang = rx >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num = num3;
            num2 = num4;
        }
        float num5;
        float num6;
        if ( ry == 0 )
        {
            num5 = 0f;
            num6 = 1f;
        }
        else
        {
            int ang = ry >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num5 = num3;
            num6 = num4;
        }
        float num7;
        float num8;
        if ( rz == 0 )
        {
            num7 = 0f;
            num8 = 1f;
        }
        else
        {
            int ang = rz >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num7 = num3;
            num8 = num4;
        }
        float num9 = num6 * num8;
        float num10 = num5 * num8;
        float num11 = num5 * num7;
        float num12 = num6 * num7;
        dst.x = num9 * num + num11 * num2;
        dst.y = num10 * num2 + num12 * num;
        dst.z = -num10 * num + num12 * num2;
        dst.w = num9 * num2 - num11 * num;
    }

    // Token: 0x060004DB RID: 1243 RVA: 0x00029C80 File Offset: 0x00027E80
    public static void nnMakeRotateZXYQuaternion( out AppMain.NNS_QUATERNION dst, int rx, int ry, int rz )
    {
        float num;
        float num2;
        if ( rx == 0 )
        {
            num = 0f;
            num2 = 1f;
        }
        else
        {
            int ang = rx >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num = num3;
            num2 = num4;
        }
        float num5;
        float num6;
        if ( ry == 0 )
        {
            num5 = 0f;
            num6 = 1f;
        }
        else
        {
            int ang = ry >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num5 = num3;
            num6 = num4;
        }
        float num7;
        float num8;
        if ( rz == 0 )
        {
            num7 = 0f;
            num8 = 1f;
        }
        else
        {
            int ang = rz >> 1;
            float num3;
            float num4;
            AppMain.nnSinCos( ang, out num3, out num4 );
            num7 = num3;
            num8 = num4;
        }
        dst.x = num6 * num * num8 + num5 * num2 * num7;
        dst.y = -num6 * num * num7 + num5 * num2 * num8;
        dst.z = num6 * num2 * num7 - num5 * num * num8;
        dst.w = num6 * num2 * num8 + num5 * num * num7;
    }

    // Token: 0x0600050E RID: 1294 RVA: 0x0002B4F6 File Offset: 0x000296F6
    private void nnCalcMatrixList( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600050F RID: 1295 RVA: 0x0002B4FD File Offset: 0x000296FD
    private void nnCalcMatrixListMotionNode( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000510 RID: 1296 RVA: 0x0002B504 File Offset: 0x00029704
    private void nnCalcMatrixListMotion( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000511 RID: 1297 RVA: 0x0002B50B File Offset: 0x0002970B
    private void nnCalcMatrixListTRSList( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS trslist, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000512 RID: 1298 RVA: 0x0002B512 File Offset: 0x00029712
    private void nnCalcMatrixListMultiplyMatrix( AppMain.ArrayPointer<AppMain.NNS_MATRIX> dstlist, AppMain.NNS_MATRIX src, AppMain.ArrayPointer<AppMain.NNS_MATRIX> srclist, int num )
    {
        this.nnCalcMultiplyMatrices( dstlist, src, srclist, num );
    }

    // Token: 0x06000513 RID: 1299 RVA: 0x0002B51F File Offset: 0x0002971F
    private void nnCalcMatrixPaletteMatrixList( AppMain.NNS_MATRIX mtxpal, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX mtxlist, AppMain.NNS_MATRIX basemtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000514 RID: 1300 RVA: 0x0002B526 File Offset: 0x00029726
    private void nnCalcMatrixListMotionNode1BoneSIIK( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, int jnt1idx, int submotidx, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000515 RID: 1301 RVA: 0x0002B52D File Offset: 0x0002972D
    private void nnCalcMatrixListMotionNode2BoneSIIK( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, int jnt1idx, int submotidx, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000516 RID: 1302 RVA: 0x0002B534 File Offset: 0x00029734
    private void nnCalcMatrixListMotionNode1BoneXSIIK( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, int rootidx, int submotidx, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000517 RID: 1303 RVA: 0x0002B53B File Offset: 0x0002973B
    private void nnCalcMatrixListMotionNode2BoneXSIIK( AppMain.NNS_MATRIX mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, int rootidx, int submotidx, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000518 RID: 1304 RVA: 0x0002B544 File Offset: 0x00029744
    private void nnConvertPosition4sTo3f( float[] dst, short[] src, int nVertex )
    {
        int num = 0;
        int num2 = 0;
        for ( int i = 0; i < nVertex; i++ )
        {
            dst[num++] = ( float )src[num2] / ( float )src[num2 + 3];
            dst[num++] = ( float )src[num2 + 1] / ( float )src[num2 + 3];
            dst[num++] = ( float )src[num2 + 2] / ( float )src[num2 + 3];
            num2 += 4;
        }
    }

    // Token: 0x06000519 RID: 1305 RVA: 0x0002B5A0 File Offset: 0x000297A0
    private void nnConvertNormal3bTo3f( float[] dst, sbyte[] src, int nVertex )
    {
        int num = 0;
        int num2 = 0;
        for ( int i = 0; i < nVertex; i++ )
        {
            dst[num++] = ( ( float )src[num2++] + 0.5f ) * 0.007843138f;
            dst[num++] = ( ( float )src[num2++] + 0.5f ) * 0.007843138f;
            dst[num++] = ( ( float )src[num2++] + 0.5f ) * 0.007843138f;
        }
    }

    // Token: 0x0600051A RID: 1306 RVA: 0x0002B610 File Offset: 0x00029810
    private void nnConvertNormal3sTo3f( float[] dst, short[] src, int nVertex )
    {
        int num = 0;
        int num2 = 0;
        for ( int i = 0; i < nVertex; i++ )
        {
            dst[num++] = ( ( float )src[num2++] + 0.5f ) * 3.0518044E-05f;
            dst[num++] = ( ( float )src[num2++] + 0.5f ) * 3.0518044E-05f;
            dst[num++] = ( ( float )src[num2++] + 0.5f ) * 3.0518044E-05f;
        }
    }

    // Token: 0x0600051B RID: 1307 RVA: 0x0002B67E File Offset: 0x0002987E
    private static void nnCalcMorphPositon( float[] pPosBuf, AppMain.NNS_VTXARRAY_GL[] pMorphArray, AppMain.NNS_VTXARRAY_GL[] pObjArray, AppMain.NNS_VTXARRAY_GL[] pMtgtArray, int nVertex, float weight )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600051C RID: 1308 RVA: 0x0002B685 File Offset: 0x00029885
    private static void nnCalcMorphNormal( float[] pNrmBuf, AppMain.NNS_VTXARRAY_GL[] pMorphArray, AppMain.NNS_VTXARRAY_GL[] pObjArray, AppMain.NNS_VTXARRAY_GL[] pMtgtArray, int nVertex, float weight )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600051D RID: 1309 RVA: 0x0002B68C File Offset: 0x0002988C
    private static void nnCalcMorphGeneral( float[] pBuf, AppMain.NNS_VTXARRAY_GL[] pMorphArray, AppMain.NNS_VTXARRAY_GL[] pObjArray, AppMain.NNS_VTXARRAY_GL[] pMtgtArray, int nVertex, float weight )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600051E RID: 1310 RVA: 0x0002B693 File Offset: 0x00029893
    private static void nnNormalizeNormalArray( float[] pNrmBuf, AppMain.NNS_VTXARRAY_GL[] pNrmArray, int nVertex )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600051F RID: 1311 RVA: 0x0002B69A File Offset: 0x0002989A
    private void nnCalcMorphObject( ref AppMain.NNS_OBJECT mobj, ref AppMain.NNS_OBJECT obj, ref AppMain.NNS_MORPHTARGETLIST mtgt, float[] mwpal, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000520 RID: 1312 RVA: 0x0002B6A1 File Offset: 0x000298A1
    private void nnCalcMotionLightScalar( AppMain.NNS_SUBMOTION submot, float frame, ref float val )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000521 RID: 1313 RVA: 0x0002B6A8 File Offset: 0x000298A8
    private void nnCalcMotionLightAngle( AppMain.NNS_SUBMOTION submot, float frame, ref int ang )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000522 RID: 1314 RVA: 0x0002B6AF File Offset: 0x000298AF
    private void nnCalcMotionLightXYZ( AppMain.NNS_SUBMOTION submot, float frame, AppMain.NNS_VECTOR xyz )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000523 RID: 1315 RVA: 0x0002B6B6 File Offset: 0x000298B6
    private void nnCalcMotionLightRGB( AppMain.NNS_SUBMOTION submot, float frame, AppMain.NNS_RGB col )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000524 RID: 1316 RVA: 0x0002B6BD File Offset: 0x000298BD
    private void nnCalcLightMotionCore( AppMain.NNS_LIGHTPTR dstptr, AppMain.NNS_LIGHTPTR litptr, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000525 RID: 1317 RVA: 0x0002B6C4 File Offset: 0x000298C4
    private void nnCalcLightMotion( AppMain.NNS_LIGHTPTR dstptr, AppMain.NNS_LIGHTPTR litptr, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000613 RID: 1555 RVA: 0x00035D3C File Offset: 0x00033F3C
    private static int nnCalcMotionNodeHide( AppMain.NNS_SUBMOTION submot, float frame )
    {
        int result = 0;
        AppMain.NNS_MOTION_KEY_Class11[] vk = (AppMain.NNS_MOTION_KEY_Class11[])submot.pKeyList;
        int nKeyFrame = submot.nKeyFrame;
        uint num = submot.fIPType & 3703U;
        if ( num == 4U )
        {
            AppMain.nnInterpolateConstantS32_1( vk, nKeyFrame, frame, out result );
        }
        return result;
    }

    // Token: 0x06000614 RID: 1556 RVA: 0x00035D7C File Offset: 0x00033F7C
    private static void nnCalcNodeHideMotion( AppMain.ArrayPointer<uint> nodestatlist, AppMain.NNS_MOTION mot, float frame )
    {
        if ( ( mot.fType & 1U ) == 0U )
        {
            return;
        }
        float num;
        if ( AppMain.nnCalcMotionFrame( out num, mot.fType, mot.StartFrame, mot.EndFrame, frame ) == 0 )
        {
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_SUBMOTION> pointer = new AppMain.ArrayPointer<AppMain.NNS_SUBMOTION>(mot.pSubmotion);
        for ( int i = 0; i < mot.nSubmotion; i++ )
        {
            AppMain.NNS_SUBMOTION nns_SUBMOTION = pointer + i;
            if ( ( nns_SUBMOTION.fType & 1048576U ) != 0U && nns_SUBMOTION.StartFrame <= num && num <= nns_SUBMOTION.EndFrame )
            {
                uint fType = nns_SUBMOTION.fIPType;
                if ( ( mot.fType & 131072U ) != 0U && num == nns_SUBMOTION.EndFrame )
                {
                    fType = 131072U;
                }
                float frame2;
                if ( AppMain.nnCalcMotionFrame( out frame2, fType, nns_SUBMOTION.StartKeyFrame, nns_SUBMOTION.EndKeyFrame, num ) != 0 )
                {
                    int num2 = AppMain.nnCalcMotionNodeHide(nns_SUBMOTION, frame2);
                    if ( num2 != 0 )
                    {
                        ( nodestatlist + nns_SUBMOTION.Id ).SetPrimitive( ( nodestatlist + nns_SUBMOTION.Id )[0] | 1U );
                    }
                }
            }
        }
    }

    // Token: 0x06000615 RID: 1557 RVA: 0x00035E84 File Offset: 0x00034084
    private static void nnInterpolateConstantF1( AppMain.NNS_MOTION_KEY_Class1[] vk, int nKey, float frame, out float val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class1 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val = nns_MOTION_KEY_Class.Value;
    }

    // Token: 0x06000616 RID: 1558 RVA: 0x00035ED0 File Offset: 0x000340D0
    private static void nnInterpolateConstantF3( AppMain.NNS_MOTION_KEY_Class5[] vk, int nKey, float frame, AppMain.NNS_VECTOR val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val.x = nns_MOTION_KEY_Class.Value.x;
        val.y = nns_MOTION_KEY_Class.Value.y;
        val.z = nns_MOTION_KEY_Class.Value.z;
    }

    // Token: 0x06000617 RID: 1559 RVA: 0x00035F3C File Offset: 0x0003413C
    private static void nnInterpolateConstantF3( AppMain.NNS_MOTION_KEY_Class5[] vk, int nKey, float frame, out AppMain.SNNS_VECTOR val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val.x = nns_MOTION_KEY_Class.Value.x;
        val.y = nns_MOTION_KEY_Class.Value.y;
        val.z = nns_MOTION_KEY_Class.Value.z;
    }

    // Token: 0x06000618 RID: 1560 RVA: 0x00035FA8 File Offset: 0x000341A8
    private static void nnInterpolateConstantF3( AppMain.NNS_MOTION_KEY_Class5[] vk, int nKey, float frame, ref AppMain.NNS_RGBA val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val.r = nns_MOTION_KEY_Class.Value.x;
        val.g = nns_MOTION_KEY_Class.Value.y;
        val.b = nns_MOTION_KEY_Class.Value.z;
    }

    // Token: 0x06000619 RID: 1561 RVA: 0x00036014 File Offset: 0x00034214
    private static void nnInterpolateConstantA32_1( AppMain.NNS_MOTION_KEY_Class8[] vk, int nKey, float frame, out int val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class8 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val = nns_MOTION_KEY_Class.Value;
    }

    // Token: 0x0600061A RID: 1562 RVA: 0x00036054 File Offset: 0x00034254
    private static void nnInterpolateConstantA32_3( AppMain.NNS_MOTION_KEY_Class13[] vk, int nKey, float frame, ref AppMain.NNS_ROTATE_A32 val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class13 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val.x = nns_MOTION_KEY_Class.Value.x;
        val.y = nns_MOTION_KEY_Class.Value.y;
        val.z = nns_MOTION_KEY_Class.Value.z;
    }

    // Token: 0x0600061B RID: 1563 RVA: 0x000360C0 File Offset: 0x000342C0
    private static void nnInterpolateConstantA16_1( AppMain.NNS_MOTION_KEY_Class14[] vk, int nKey, float frame, out short val )
    {
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.NNS_MOTION_KEY_Class14 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num2)];
        val = nns_MOTION_KEY_Class.Value;
    }

    // Token: 0x0600061C RID: 1564 RVA: 0x00036114 File Offset: 0x00034314
    private static void nnInterpolateConstantA16_3( AppMain.NNS_MOTION_KEY_Class16[] vk, int nKey, float frame, ref AppMain.NNS_ROTATE_A16 val )
    {
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.NNS_MOTION_KEY_Class16 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num2)];
        val.x = nns_MOTION_KEY_Class.Value.x;
        val.y = nns_MOTION_KEY_Class.Value.y;
        val.z = nns_MOTION_KEY_Class.Value.z;
    }

    // Token: 0x0600061D RID: 1565 RVA: 0x00036184 File Offset: 0x00034384
    private static void nnInterpolateLinearF1( AppMain.NNS_MOTION_KEY_Class1[] vk, int nKey, float frame, out float val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        int num4 = (int)num;
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = vk[num4].Value;
            return;
        }
        int num5 = num4 + 1;
        float num6 = (frame - vk[num5].Frame) / (vk[num4].Frame - vk[num5].Frame);
        val = vk[num5].Value + ( vk[num4].Value - vk[num5].Value ) * num6;
    }

    // Token: 0x0600061E RID: 1566 RVA: 0x00036230 File Offset: 0x00034430
    private static void nnInterpolateLinearF3( AppMain.NNS_MOTION_KEY_Class5[] vk, int nKey, float frame, AppMain.NNS_VECTOR val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        if ( ( ulong )num >= ( ulong )( ( long )( nKey - 1 ) ) )
        {
            val.x = nns_MOTION_KEY_Class.Value.x;
            val.y = nns_MOTION_KEY_Class.Value.y;
            val.z = nns_MOTION_KEY_Class.Value.z;
            return;
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class2 = vk[(int)((UIntPtr)(num + 1U))];
        float num4 = (frame - nns_MOTION_KEY_Class2.Frame) / (nns_MOTION_KEY_Class.Frame - nns_MOTION_KEY_Class2.Frame);
        val.x = nns_MOTION_KEY_Class2.Value.x + ( nns_MOTION_KEY_Class.Value.x - nns_MOTION_KEY_Class2.Value.x ) * num4;
        val.y = nns_MOTION_KEY_Class2.Value.y + ( nns_MOTION_KEY_Class.Value.y - nns_MOTION_KEY_Class2.Value.y ) * num4;
        val.z = nns_MOTION_KEY_Class2.Value.z + ( nns_MOTION_KEY_Class.Value.z - nns_MOTION_KEY_Class2.Value.z ) * num4;
    }

    // Token: 0x0600061F RID: 1567 RVA: 0x0003634C File Offset: 0x0003454C
    private static void nnInterpolateLinearF3( AppMain.NNS_MOTION_KEY_Class5[] vk, int nKey, float frame, out AppMain.SNNS_VECTOR val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        if ( ( ulong )num >= ( ulong )( ( long )( nKey - 1 ) ) )
        {
            val.x = nns_MOTION_KEY_Class.Value.x;
            val.y = nns_MOTION_KEY_Class.Value.y;
            val.z = nns_MOTION_KEY_Class.Value.z;
            return;
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class2 = vk[(int)((UIntPtr)(num + 1U))];
        float num4 = (frame - nns_MOTION_KEY_Class2.Frame) / (nns_MOTION_KEY_Class.Frame - nns_MOTION_KEY_Class2.Frame);
        val.x = nns_MOTION_KEY_Class2.Value.x + ( nns_MOTION_KEY_Class.Value.x - nns_MOTION_KEY_Class2.Value.x ) * num4;
        val.y = nns_MOTION_KEY_Class2.Value.y + ( nns_MOTION_KEY_Class.Value.y - nns_MOTION_KEY_Class2.Value.y ) * num4;
        val.z = nns_MOTION_KEY_Class2.Value.z + ( nns_MOTION_KEY_Class.Value.z - nns_MOTION_KEY_Class2.Value.z ) * num4;
    }

    // Token: 0x06000620 RID: 1568 RVA: 0x00036468 File Offset: 0x00034668
    private static void nnInterpolateLinearF3( AppMain.NNS_MOTION_KEY_Class5[] vk, int nKey, float frame, ref AppMain.NNS_RGBA val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class = vk[(int)num];
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val.r = nns_MOTION_KEY_Class.Value.x;
            val.g = nns_MOTION_KEY_Class.Value.y;
            val.b = nns_MOTION_KEY_Class.Value.z;
            return;
        }
        AppMain.NNS_MOTION_KEY_Class5 nns_MOTION_KEY_Class2 = vk[(int)(num + 1U)];
        float num4 = (frame - nns_MOTION_KEY_Class2.Frame) / (nns_MOTION_KEY_Class.Frame - nns_MOTION_KEY_Class2.Frame);
        val.r = nns_MOTION_KEY_Class2.Value.x + ( nns_MOTION_KEY_Class.Value.x - nns_MOTION_KEY_Class2.Value.x ) * num4;
        val.g = nns_MOTION_KEY_Class2.Value.y + ( nns_MOTION_KEY_Class.Value.y - nns_MOTION_KEY_Class2.Value.y ) * num4;
        val.b = nns_MOTION_KEY_Class2.Value.z + ( nns_MOTION_KEY_Class.Value.z - nns_MOTION_KEY_Class2.Value.z ) * num4;
    }

    // Token: 0x06000621 RID: 1569 RVA: 0x00036580 File Offset: 0x00034780
    private static void nnInterpolateLinearA32_1( AppMain.NNS_MOTION_KEY_Class8[] vk, int nKey, float frame, out int val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class8> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class8>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class8> pointer2 = pointer + 1;
        float num4 = (frame - (~pointer2).Frame) / ((~pointer).Frame - (~pointer2).Frame);
        val = ( ~pointer2 ).Value + ( int )( ( float )( ( ~pointer ).Value - ( ~pointer2 ).Value ) * num4 );
    }

    // Token: 0x06000622 RID: 1570 RVA: 0x00036630 File Offset: 0x00034830
    private static void nnInterpolateLinearA32_3( AppMain.NNS_MOTION_KEY_Class13[] vk, int nKey, float frame, ref AppMain.NNS_ROTATE_A32 val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer2 = pointer + 1;
        float num4 = (frame - (~pointer2).Frame) / ((~pointer).Frame - (~pointer2).Frame);
        val.x = ( ~pointer2 ).Value.x + ( int )( ( float )( ( ~pointer ).Value.x - ( ~pointer2 ).Value.x ) * num4 );
        val.y = ( ~pointer2 ).Value.y + ( int )( ( float )( ( ~pointer ).Value.y - ( ~pointer2 ).Value.y ) * num4 );
        val.z = ( ~pointer2 ).Value.z + ( int )( ( float )( ( ~pointer ).Value.z - ( ~pointer2 ).Value.z ) * num4 );
    }

    // Token: 0x06000623 RID: 1571 RVA: 0x0003676C File Offset: 0x0003496C
    private static void nnInterpolateLinearA16_1( AppMain.NNS_MOTION_KEY_Class14[] vk, int nKey, float frame, out short val )
    {
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.NNS_MOTION_KEY_Class14 nns_MOTION_KEY_Class = vk[(int)num2];
        if ( num2 >= ( uint )( nKey - 1 ) )
        {
            val = nns_MOTION_KEY_Class.Value;
            return;
        }
        AppMain.NNS_MOTION_KEY_Class14 nns_MOTION_KEY_Class2 = vk[(int)(num2 + 1U)];
        int num5 = (int)(65536f * (frame - (float)nns_MOTION_KEY_Class2.Frame) / (float)(nns_MOTION_KEY_Class.Frame - nns_MOTION_KEY_Class2.Frame));
        val = ( short )( ( int )nns_MOTION_KEY_Class2.Value + ( ( int )( nns_MOTION_KEY_Class.Value - nns_MOTION_KEY_Class2.Value ) * num5 >> 16 ) );
    }

    // Token: 0x06000624 RID: 1572 RVA: 0x00036818 File Offset: 0x00034A18
    private static void nnInterpolateLinearA16_3( AppMain.NNS_MOTION_KEY_Class16[] vk, int nKey, float frame, ref AppMain.NNS_ROTATE_A16 val )
    {
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16>(vk, (int)num2);
        if ( num2 >= ( uint )( nKey - 1 ) )
        {
            val.x = ( ~pointer ).Value.x;
            val.y = ( ~pointer ).Value.y;
            val.z = ( ~pointer ).Value.z;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer2 = pointer + 1;
        int num5 = (int)(65536f * (frame - (float)(~pointer2).Frame) / (float)((~pointer).Frame - (~pointer2).Frame));
        val.x = ( short )( ( int )( ~pointer2 ).Value.x + ( ( int )( ( ~pointer ).Value.x - ( ~pointer2 ).Value.x ) * num5 >> 16 ) );
        val.y = ( short )( ( int )( ~pointer2 ).Value.y + ( ( int )( ( ~pointer ).Value.y - ( ~pointer2 ).Value.y ) * num5 >> 16 ) );
        val.z = ( short )( ( int )( ~pointer2 ).Value.z + ( ( int )( ( ~pointer ).Value.z - ( ~pointer2 ).Value.z ) * num5 >> 16 ) );
    }

    // Token: 0x06000625 RID: 1573 RVA: 0x0003699C File Offset: 0x00034B9C
    private static float nnSolveBezier( float f0, float h0, float f1, float h1, float frame )
    {
        float num = h1 - h0;
        float num2 = f1 - f0 + num;
        float num3 = -2f * num2 - num;
        float num4 = 3f * (num2 - h0);
        float num5 = 3f * h0;
        float num6 = f0 - frame;
        float num7 = 0f;
        float num8 = 0.5f;
        float num9 = 0.5f;
        for ( int i = 0; i < 16; i++ )
        {
            float num10 = ((num3 * num9 + num4) * num9 + num5) * num9 + num6;
            if ( num10 < 0f )
            {
                num7 = num9;
            }
            num8 *= 0.5f;
            num9 = num7 + num8;
        }
        return num9;
    }

    // Token: 0x06000626 RID: 1574 RVA: 0x00036A34 File Offset: 0x00034C34
    private static void nnInterpolateBezierF1( AppMain.NNS_MOTION_KEY_Class2[] vk, int nKey, float frame, out float val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class2 nns_MOTION_KEY_Class = vk[(int)num];
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = nns_MOTION_KEY_Class.Value;
            return;
        }
        AppMain.NNS_MOTION_KEY_Class2 nns_MOTION_KEY_Class2 = vk[(int)(num + 1U)];
        float num4 = AppMain.nnSolveBezier(nns_MOTION_KEY_Class.Frame, nns_MOTION_KEY_Class.Bhandle.Out.x, nns_MOTION_KEY_Class2.Frame, nns_MOTION_KEY_Class2.Bhandle.In.x, frame);
        float value = nns_MOTION_KEY_Class.Value;
        float y = nns_MOTION_KEY_Class.Bhandle.Out.y;
        float value2 = nns_MOTION_KEY_Class2.Value;
        float y2 = nns_MOTION_KEY_Class2.Bhandle.In.y;
        float num5 = y2 - y;
        float num6 = value2 - value + num5;
        float num7 = -2f * num6 - num5;
        float num8 = 3f * (num6 - y);
        float num9 = 3f * y;
        float num10 = value;
        val = ( ( num7 * num4 + num8 ) * num4 + num9 ) * num4 + num10;
    }

    // Token: 0x06000627 RID: 1575 RVA: 0x00036B3C File Offset: 0x00034D3C
    private static void nnInterpolateBezierA32_1( AppMain.NNS_MOTION_KEY_Class9[] vk, int nKey, float frame, out int val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class9> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class9>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class9> pointer2 = pointer + 1;
        float num4 = AppMain.nnSolveBezier((~pointer).Frame, (~pointer).Bhandle.Out.x, (~pointer2).Frame, (~pointer2).Bhandle.In.x, frame);
        float num5 = (float)(~pointer).Value;
        float y = (~pointer).Bhandle.Out.y;
        float num6 = (float)(~pointer2).Value;
        float y2 = (~pointer2).Bhandle.In.y;
        float num7 = y2 - y;
        float num8 = num6 - num5 + num7;
        float num9 = -2f * num8 - num7;
        float num10 = 3f * (num8 - y);
        float num11 = 3f * y;
        float num12 = num5;
        val = ( int )( ( ( num9 * num4 + num10 ) * num4 + num11 ) * num4 + num12 );
    }

    // Token: 0x06000628 RID: 1576 RVA: 0x00036C7C File Offset: 0x00034E7C
    private static void nnRotXYZtoQuat( ref AppMain.NNS_QUATERNION dst, int rx, int ry, int rz, uint rtype )
    {
        if ( rtype == 256U )
        {
            AppMain.nnMakeRotateXZYQuaternion( out dst, rx, ry, rz );
            return;
        }
        if ( rtype != 1024U )
        {
            AppMain.nnMakeRotateXYZQuaternion( out dst, rx, ry, rz );
            return;
        }
        AppMain.nnMakeRotateZXYQuaternion( out dst, rx, ry, rz );
    }

    // Token: 0x06000629 RID: 1577 RVA: 0x00036CBC File Offset: 0x00034EBC
    private static void nnInterpolateLerpA16_3( AppMain.NNS_MOTION_KEY_Class16[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val, uint rtype )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16>(vk, (int)num2);
        if ( num2 >= ( uint )( nKey - 1 ) )
        {
            AppMain.nnRotXYZtoQuat( ref val, ( int )( ~pointer ).Value.x, ( int )( ~pointer ).Value.y, ( int )( ~pointer ).Value.z, rtype );
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer2 = pointer + 1;
        float t = (frame - (float)(~pointer).Frame) / (float)((~pointer2).Frame - (~pointer).Frame);
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION, ( int )( ~pointer ).Value.x, ( int )( ~pointer ).Value.y, ( int )( ~pointer ).Value.z, rtype );
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION2, ( int )( ~pointer2 ).Value.x, ( int )( ~pointer2 ).Value.y, ( int )( ~pointer2 ).Value.z, rtype );
        AppMain.nnLerpQuaternion( ref val, ref nns_QUATERNION, ref nns_QUATERNION2, t );
    }

    // Token: 0x0600062A RID: 1578 RVA: 0x00036E10 File Offset: 0x00035010
    private static void nnInterpolateLerpA32_3( AppMain.NNS_MOTION_KEY_Class13[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val, uint rtype )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            AppMain.nnRotXYZtoQuat( ref val, ( ~pointer ).Value.x, ( ~pointer ).Value.y, ( ~pointer ).Value.z, rtype );
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer2 = pointer + 1;
        float t = (frame - (~pointer).Frame) / ((~pointer2).Frame - (~pointer).Frame);
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION, ( ~pointer ).Value.x, ( ~pointer ).Value.y, ( ~pointer ).Value.z, rtype );
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION2, ( ~pointer2 ).Value.x, ( ~pointer2 ).Value.y, ( ~pointer2 ).Value.z, rtype );
        AppMain.nnLerpQuaternion( ref val, ref nns_QUATERNION, ref nns_QUATERNION2, t );
    }

    // Token: 0x0600062B RID: 1579 RVA: 0x00036F5C File Offset: 0x0003515C
    private static void nnInterpolateLerpQuat_4( AppMain.NNS_MOTION_KEY_Class7[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer2 = pointer + 1;
        float t = (frame - (~pointer).Frame) / ((~pointer2).Frame - (~pointer).Frame);
        nns_QUATERNION = ( ~pointer ).Value;
        nns_QUATERNION2 = ( ~pointer2 ).Value;
        AppMain.nnLerpQuaternion( ref val, ref nns_QUATERNION, ref nns_QUATERNION2, t );
    }

    // Token: 0x0600062C RID: 1580 RVA: 0x00037020 File Offset: 0x00035220
    private static void nnInterpolateSlerpA16_3( AppMain.NNS_MOTION_KEY_Class16[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val, uint rtype )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16>(vk, (int)num2);
        if ( num2 >= ( uint )( nKey - 1 ) )
        {
            AppMain.nnRotXYZtoQuat( ref val, ( int )( ~pointer ).Value.x, ( int )( ~pointer ).Value.y, ( int )( ~pointer ).Value.z, rtype );
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer2 = pointer + 1;
        float t = (frame - (float)(~pointer).Frame) / (float)((~pointer2).Frame - (~pointer).Frame);
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION, ( int )( ~pointer ).Value.x, ( int )( ~pointer ).Value.y, ( int )( ~pointer ).Value.z, rtype );
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION2, ( int )( ~pointer2 ).Value.x, ( int )( ~pointer2 ).Value.y, ( int )( ~pointer2 ).Value.z, rtype );
        AppMain.nnSlerpQuaternion( out val, ref nns_QUATERNION, ref nns_QUATERNION2, t );
    }

    // Token: 0x0600062D RID: 1581 RVA: 0x00037174 File Offset: 0x00035374
    private static void nnInterpolateSlerpA32_3( AppMain.NNS_MOTION_KEY_Class13[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val, uint rtype )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            AppMain.nnRotXYZtoQuat( ref val, ( ~pointer ).Value.x, ( ~pointer ).Value.y, ( ~pointer ).Value.z, rtype );
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer2 = pointer + 1;
        float t = (frame - (~pointer).Frame) / ((~pointer2).Frame - (~pointer).Frame);
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION, ( ~pointer ).Value.x, ( ~pointer ).Value.y, ( ~pointer ).Value.z, rtype );
        AppMain.nnRotXYZtoQuat( ref nns_QUATERNION2, ( ~pointer2 ).Value.x, ( ~pointer2 ).Value.y, ( ~pointer2 ).Value.z, rtype );
        AppMain.nnSlerpQuaternion( out val, ref nns_QUATERNION, ref nns_QUATERNION2, t );
    }

    // Token: 0x0600062E RID: 1582 RVA: 0x000372C0 File Offset: 0x000354C0
    private static void nnInterpolateSlerpQuat_4( AppMain.NNS_MOTION_KEY_Class7[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer2 = pointer + 1;
        float t = (frame - (~pointer).Frame) / ((~pointer2).Frame - (~pointer).Frame);
        nns_QUATERNION = ( ~pointer ).Value;
        nns_QUATERNION2 = ( ~pointer2 ).Value;
        AppMain.nnSlerpQuaternion( out val, ref nns_QUATERNION, ref nns_QUATERNION2, t );
    }

    // Token: 0x0600062F RID: 1583 RVA: 0x00037384 File Offset: 0x00035584
    private static void nnInterpolateSquadA16_3( AppMain.NNS_MOTION_KEY_Class16[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val, uint rtype )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION5 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION6 = default(AppMain.NNS_QUATERNION);
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16>(vk, (int)num2);
        if ( num2 >= ( uint )( nKey - 1 ) )
        {
            AppMain.nnRotXYZtoQuat( ref val, ( int )( ~pointer ).Value.x, ( int )( ~pointer ).Value.y, ( int )( ~pointer ).Value.z, rtype );
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer2 = pointer + 1;
        if ( num2 > 0U && num2 < ( uint )( nKey - 2 ) )
        {
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer3 = pointer - 1;
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class16> pointer4 = pointer + 2;
            float t = (frame - (float)(~pointer).Frame) / (float)((~pointer2).Frame - (~pointer).Frame);
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION, ( int )( ~pointer3 ).Value.x, ( int )( ~pointer3 ).Value.y, ( int )( ~pointer3 ).Value.z, rtype );
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION2, ( int )( ~pointer ).Value.x, ( int )( ~pointer ).Value.y, ( int )( ~pointer ).Value.z, rtype );
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION3, ( int )( ~pointer2 ).Value.x, ( int )( ~pointer2 ).Value.y, ( int )( ~pointer2 ).Value.z, rtype );
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION4, ( int )( ~pointer4 ).Value.x, ( int )( ~pointer4 ).Value.y, ( int )( ~pointer4 ).Value.z, rtype );
            AppMain.nnSplineQuaternion( ref nns_QUATERNION5, ref nns_QUATERNION, ref nns_QUATERNION2, ref nns_QUATERNION3 );
            AppMain.nnSplineQuaternion( ref nns_QUATERNION6, ref nns_QUATERNION2, ref nns_QUATERNION3, ref nns_QUATERNION4 );
            AppMain.nnSquadQuaternion( ref val, ref nns_QUATERNION2, ref nns_QUATERNION5, ref nns_QUATERNION6, ref nns_QUATERNION3, t );
            return;
        }
        AppMain.nnInterpolateSlerpA16_3( vk, nKey, frame, ref val, rtype );
    }

    // Token: 0x06000630 RID: 1584 RVA: 0x000375B8 File Offset: 0x000357B8
    private static void nnInterpolateSquadA32_3( AppMain.NNS_MOTION_KEY_Class13[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val, uint rtype )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION5 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION6 = default(AppMain.NNS_QUATERNION);
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            AppMain.nnRotXYZtoQuat( ref val, ( ~pointer ).Value.x, ( ~pointer ).Value.y, ( ~pointer ).Value.z, rtype );
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer2 = pointer + 1;
        if ( num > 0U && num < ( uint )( nKey - 2 ) )
        {
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer3 = pointer - 1;
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class13> pointer4 = pointer + 2;
            float t = (frame - (~pointer).Frame) / ((~pointer2).Frame - (~pointer).Frame);
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION, ( ~pointer3 ).Value.x, ( ~pointer3 ).Value.y, ( ~pointer3 ).Value.z, rtype );
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION2, ( ~pointer ).Value.x, ( ~pointer ).Value.y, ( ~pointer ).Value.z, rtype );
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION3, ( ~pointer2 ).Value.x, ( ~pointer2 ).Value.y, ( ~pointer2 ).Value.z, rtype );
            AppMain.nnRotXYZtoQuat( ref nns_QUATERNION4, ( ~pointer4 ).Value.x, ( ~pointer4 ).Value.y, ( ~pointer4 ).Value.z, rtype );
            AppMain.nnSplineQuaternion( ref nns_QUATERNION5, ref nns_QUATERNION, ref nns_QUATERNION2, ref nns_QUATERNION3 );
            AppMain.nnSplineQuaternion( ref nns_QUATERNION6, ref nns_QUATERNION2, ref nns_QUATERNION3, ref nns_QUATERNION4 );
            AppMain.nnSquadQuaternion( ref val, ref nns_QUATERNION2, ref nns_QUATERNION5, ref nns_QUATERNION6, ref nns_QUATERNION3, t );
            return;
        }
        AppMain.nnInterpolateSlerpA32_3( vk, nKey, frame, ref val, rtype );
    }

    // Token: 0x06000631 RID: 1585 RVA: 0x000377E4 File Offset: 0x000359E4
    private static void nnInterpolateSquadQuat_4( AppMain.NNS_MOTION_KEY_Class7[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val )
    {
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION3 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION4 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION5 = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION6 = default(AppMain.NNS_QUATERNION);
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer2 = pointer + 1;
        if ( num > 0U && num < ( uint )( nKey - 2 ) )
        {
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer3 = pointer - 1;
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class7> pointer4 = pointer + 2;
            float t = (frame - (~pointer).Frame) / ((~pointer2).Frame - (~pointer).Frame);
            nns_QUATERNION = ( ~pointer3 ).Value;
            nns_QUATERNION2 = ( ~pointer ).Value;
            nns_QUATERNION3 = ( ~pointer2 ).Value;
            nns_QUATERNION4 = ( ~pointer4 ).Value;
            AppMain.nnSplineQuaternion( ref nns_QUATERNION5, ref nns_QUATERNION, ref nns_QUATERNION2, ref nns_QUATERNION3 );
            AppMain.nnSplineQuaternion( ref nns_QUATERNION6, ref nns_QUATERNION2, ref nns_QUATERNION3, ref nns_QUATERNION4 );
            AppMain.nnSquadQuaternion( ref val, ref nns_QUATERNION2, ref nns_QUATERNION5, ref nns_QUATERNION6, ref nns_QUATERNION3, t );
            return;
        }
        AppMain.nnInterpolateSlerpQuat_4( vk, nKey, frame, ref val );
    }

    // Token: 0x06000632 RID: 1586 RVA: 0x0003792C File Offset: 0x00035B2C
    private static void nnInterpolateConstantQuat_4( AppMain.NNS_MOTION_KEY_Class7[] vk, int nKey, float frame, ref AppMain.NNS_QUATERNION val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class7 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val.x = nns_MOTION_KEY_Class.Value.x;
        val.y = nns_MOTION_KEY_Class.Value.y;
        val.z = nns_MOTION_KEY_Class.Value.z;
        val.w = nns_MOTION_KEY_Class.Value.w;
    }

    // Token: 0x06000633 RID: 1587 RVA: 0x000379A8 File Offset: 0x00035BA8
    private static void nnInterpolateSISplineF1( AppMain.NNS_MOTION_KEY_Class3[] vk, int nKey, float frame, out float val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class3> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class3>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class3> pointer2 = pointer + 1;
        float num4 = (~pointer2).Frame - (~pointer).Frame;
        float num5 = (~pointer2).Value - (~pointer).Value;
        float num6 = (frame - (~pointer).Frame) / num4;
        float num7 = -2f * num5 + num4 * ((~pointer).Shandle.Out + (~pointer2).Shandle.In);
        float num8 = 3f * num5 - num4 * (2f * (~pointer).Shandle.Out + (~pointer2).Shandle.In);
        float num9 = num4 * (~pointer).Shandle.Out;
        val = ( ~pointer ).Value + num6 * ( num6 * ( num7 * num6 + num8 ) + num9 );
    }

    // Token: 0x06000634 RID: 1588 RVA: 0x00037AE0 File Offset: 0x00035CE0
    private static void nnInterpolateSISplineA32_1( AppMain.NNS_MOTION_KEY_Class10[] vk, int nKey, float frame, out int val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class10> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class10>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class10> pointer2 = pointer + 1;
        float num4 = (~pointer2).Frame - (~pointer).Frame;
        int num5 = (~pointer2).Value - (~pointer).Value;
        float num6 = (frame - (~pointer).Frame) / num4;
        float num7 = (float)(-2 * num5) + num4 * ((~pointer).Shandle.Out + (~pointer2).Shandle.In);
        float num8 = (float)(3 * num5) - num4 * (2f * (~pointer).Shandle.Out + (~pointer2).Shandle.In);
        float num9 = num4 * (~pointer).Shandle.Out;
        val = ( int )( ( float )( ~pointer ).Value + num6 * ( num6 * ( num7 * num6 + num8 ) + num9 ) );
    }

    // Token: 0x06000635 RID: 1589 RVA: 0x00037C14 File Offset: 0x00035E14
    private static void nnInterpolateSISplineA16_1( AppMain.NNS_MOTION_KEY_Class15[] vk, int nKey, float frame, out short val )
    {
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class15> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class15>(vk, (int)num2);
        if ( num2 >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class15> pointer2 = pointer + 1;
        float num5 = (float)((~pointer2).Frame - (~pointer).Frame);
        short num6 = (short)((~pointer2).Value - (~pointer).Value);
        float num7 = (frame - (float)(~pointer).Frame) / num5;
        float num8 = (float)(-2 * num6) + num5 * ((~pointer).Shandle.Out + (~pointer2).Shandle.In);
        float num9 = (float)(3 * num6) - num5 * (2f * (~pointer).Shandle.Out + (~pointer2).Shandle.In);
        float num10 = num5 * (~pointer).Shandle.Out;
        val = ( short )( ( float )( ~pointer ).Value + num7 * ( num7 * ( num8 * num7 + num9 ) + num10 ) );
    }

    // Token: 0x06000636 RID: 1590 RVA: 0x00037D50 File Offset: 0x00035F50
    private static void nnInterpolateConstantU1( AppMain.NNS_MOTION_KEY_Class12[] vk, int nKey, float frame, out uint val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class12 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val = nns_MOTION_KEY_Class.Value;
    }

    // Token: 0x06000637 RID: 1591 RVA: 0x00037D90 File Offset: 0x00035F90
    private static void nnInterpolateLinearU1( AppMain.NNS_MOTION_KEY_Class12[] vk, int nKey, float frame, out uint val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val = ( ~pointer ).Value;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12> pointer2 = pointer + 1;
        float num4 = (frame - (~pointer2).Frame) / ((~pointer).Frame - (~pointer2).Frame);
        val = ( uint )( ( ~pointer ).Value * num4 + ( ~pointer2 ).Value * ( 1f - num4 ) );
    }

    // Token: 0x06000638 RID: 1592 RVA: 0x00037E3C File Offset: 0x0003603C
    private static int nnInterpolateTriggerU1( AppMain.NNS_MOTION_KEY_Class12[] vk, int nKey, float frame, out uint val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class12 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        if ( frame > nns_MOTION_KEY_Class.Frame + AppMain.nngNodeUserMotionTriggerTime )
        {
            val = 0U;
            return 0;
        }
        val = nns_MOTION_KEY_Class.Value;
        return 1;
    }

    // Token: 0x06000639 RID: 1593 RVA: 0x00037E90 File Offset: 0x00036090
    private static void nnSearchTriggerU1( AppMain.NNS_MOTION_KEY_Class12[] vk, int nKey, float frame, float interval, AppMain.NNS_NODEUSRMOT_CALLBACK_FUNC func, AppMain.NNS_NODEUSRMOT_CALLBACK_VAL val )
    {
        if ( nKey == 0 )
        {
            return;
        }
        int num5;
        int num4;
        if ( vk[0].Frame < frame && frame < vk[nKey - 1].Frame )
        {
            uint num = 0U;
            uint num2 = (uint)nKey;
            while ( num2 - num > 1U )
            {
                uint num3 = num + num2 >> 1;
                if ( frame > vk[( int )( ( UIntPtr )num3 )].Frame )
                {
                    num = num3;
                }
                else
                {
                    num2 = num3;
                }
            }
            if ( vk[( int )( ( UIntPtr )num )].Frame == frame )
            {
                num4 = ( num5 = ( int )num );
            }
            else if ( vk[( int )( ( UIntPtr )num2 )].Frame == frame )
            {
                num4 = ( num5 = ( int )num2 );
            }
            else
            {
                num5 = ( int )num;
                num4 = ( int )num2;
            }
        }
        else
        {
            num4 = ( num5 = -1 );
            if ( frame < vk[0].Frame )
            {
                num4 = 0;
            }
            if ( vk[nKey - 1].Frame < frame )
            {
                num5 = nKey - 1;
            }
            if ( vk[0].Frame == frame )
            {
                num4 = ( num5 = 0 );
            }
            if ( vk[nKey - 1].Frame == frame )
            {
                num4 = ( num5 = nKey - 1 );
            }
        }
        if ( interval > 0f && num5 != -1 )
        {
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12>(vk, num5);
            while ( ( ~pointer ).Frame + interval > frame )
            {
                if ( num5 < 0 )
                {
                    return;
                }
                val.IValue = ( ~pointer ).Value;
                val.Frame = ( ~pointer ).Frame;
                func( val );
                num5--;
                pointer = --pointer;
            }
        }
        else if ( interval < 0f && num4 != -1 )
        {
            AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12> pointer2 = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class12>(vk, num4);
            while ( ( ~pointer2 ).Frame + interval < frame && num4 < nKey )
            {
                val.IValue = ( ~pointer2 ).Value;
                val.Frame = ( ~pointer2 ).Frame;
                func( val );
                num4++;
                pointer2 = ++pointer2;
            }
        }
    }

    // Token: 0x0600063A RID: 1594 RVA: 0x00038020 File Offset: 0x00036220
    private static void nnInterpolateConstantS32_1( AppMain.NNS_MOTION_KEY_Class11[] vk, int nKey, float frame, out int val )
    {
        short num = (short)frame;
        uint num2 = 0U;
        uint num3 = (uint)nKey;
        while ( num3 - num2 > 1U )
        {
            uint num4 = num2 + num3 >> 1;
            if ( ( float )num >= vk[( int )( ( UIntPtr )num4 )].Frame )
            {
                num2 = num4;
            }
            else
            {
                num3 = num4;
            }
        }
        AppMain.NNS_MOTION_KEY_Class11 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num2)];
        val = nns_MOTION_KEY_Class.Value;
    }

    // Token: 0x0600063B RID: 1595 RVA: 0x00038064 File Offset: 0x00036264
    private static void nnInterpolateConstantF2( AppMain.NNS_MOTION_KEY_Class4[] vk, int nKey, float frame, out AppMain.NNS_TEXCOORD val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.NNS_MOTION_KEY_Class4 nns_MOTION_KEY_Class = vk[(int)((UIntPtr)num)];
        val.u = nns_MOTION_KEY_Class.Value.u;
        val.v = nns_MOTION_KEY_Class.Value.v;
    }

    // Token: 0x0600063C RID: 1596 RVA: 0x000380BC File Offset: 0x000362BC
    private static void nnInterpolateLinearF2( AppMain.NNS_MOTION_KEY_Class4[] vk, int nKey, float frame, out AppMain.NNS_TEXCOORD val )
    {
        uint num = 0U;
        uint num2 = (uint)nKey;
        while ( num2 - num > 1U )
        {
            uint num3 = num + num2 >> 1;
            if ( frame >= vk[( int )( ( UIntPtr )num3 )].Frame )
            {
                num = num3;
            }
            else
            {
                num2 = num3;
            }
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class4> pointer = new AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class4>(vk, (int)num);
        if ( num >= ( uint )( nKey - 1 ) )
        {
            val.u = ( ~pointer ).Value.u;
            val.v = ( ~pointer ).Value.v;
            return;
        }
        AppMain.ArrayPointer<AppMain.NNS_MOTION_KEY_Class4> pointer2 = pointer + 1;
        float num4 = (frame - (~pointer2).Frame) / ((~pointer).Frame - (~pointer2).Frame);
        float num5 = 1f - num4;
        val.u = ( ~pointer ).Value.u * num4 + ( ~pointer2 ).Value.u * num5;
        val.v = ( ~pointer ).Value.v * num4 + ( ~pointer2 ).Value.v * num5;
    }

    // Token: 0x06000729 RID: 1833 RVA: 0x0003FB2B File Offset: 0x0003DD2B
    private static void nnCalc1BoneSIIK( AppMain.NNS_MATRIX jnt1mtx, AppMain.NNS_MATRIX jnt1motmtx, AppMain.NNS_MATRIX effmtx, float lbone1 )
    {
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600072A RID: 1834 RVA: 0x0003FB3E File Offset: 0x0003DD3E
    private static void nnCalc2BoneSIIK( AppMain.NNS_MATRIX jnt1mtx, AppMain.NNS_MATRIX jnt1motmtx, AppMain.NNS_MATRIX jnt2mtx, AppMain.NNS_MATRIX jnt2motmtx, AppMain.NNS_MATRIX effmtx, float lbone1, float lbone2, int zpref )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600072B RID: 1835 RVA: 0x0003FB45 File Offset: 0x0003DD45
    private void nnAdjustMatrixXaxis( AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTORFAST pos )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600072C RID: 1836 RVA: 0x0003FB4C File Offset: 0x0003DD4C
    private void nnCalcCosineTheorem( out float sin, out float cos, float a, float b, float c )
    {
        AppMain.mppAssertNotImpl();
        sin = ( cos = 0f );
    }

    // Token: 0x0600072D RID: 1837 RVA: 0x0003FB6C File Offset: 0x0003DD6C
    private void nnCalcCosineTheorem2( out float sin0, out float cos0, out float sin1, out float cos1, float a, float b, float c )
    {
        AppMain.mppAssertNotImpl();
        sin0 = ( cos0 = ( sin1 = ( cos1 = 0f ) ) );
    }

    // Token: 0x0600072E RID: 1838 RVA: 0x0003FB95 File Offset: 0x0003DD95
    private void nnCalcNodeStatusListInitialPose( uint[] nodestatlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600072F RID: 1839 RVA: 0x0003FB9C File Offset: 0x0003DD9C
    private static void nnmSetUpVector( AppMain.NNS_VECTOR vec, float x, float y, float z )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000730 RID: 1840 RVA: 0x0003FBA3 File Offset: 0x0003DDA3
    private static void nnmAddScaleVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR add, float scl )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000731 RID: 1841 RVA: 0x0003FBAA File Offset: 0x0003DDAA
    private static void nnmBlendVector( AppMain.NNS_VECTOR dst, AppMain.NNS_VECTOR vec1, float blend1, AppMain.NNS_VECTOR vec2, float blend2 )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000732 RID: 1842 RVA: 0x0003FBB1 File Offset: 0x0003DDB1
    private static void nnmTransformVector( AppMain.NNS_VECTOR dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR src )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000733 RID: 1843 RVA: 0x0003FBB8 File Offset: 0x0003DDB8
    private static void nnmTransformNormalVector( AppMain.NNS_VECTOR dst, AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR src )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000734 RID: 1844 RVA: 0x0003FBBF File Offset: 0x0003DDBF
    private static void nnCalcPliablePosNrm( object pPliablePositions, object pPliableNormals, int nVtx, object pObjPositions, uint PosType, object pObjNormals, uint NrmType, object pWeights, int nWeight, object pMtxIndices, int nMtxIdx, AppMain.NNS_MATRIX[] posmtx, AppMain.NNS_MATRIX[] nrmmtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000735 RID: 1845 RVA: 0x0003FBC6 File Offset: 0x0003DDC6
    private static void nnCalcPliableObjectSpaceNormal( object pPliablePositions, object pPliableNormals, object pPliableTangents, object pPliableBinormals, int nVtx, object pObjPositions, uint PosType, object pWeights, int nWeight, object pMtxIndices, int nMtxIdx, AppMain.NNS_MATRIX[] posmtx, AppMain.NNS_MATRIX[] nrmmtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000736 RID: 1846 RVA: 0x0003FBCD File Offset: 0x0003DDCD
    private static void nnCalcPliableTangentSpaceNormal( object pPliablePositions, object pPliableNormals, object pPliableTangents, object pPliableBinormals, int nVtx, object pObjPositions, uint PosType, object pObjNormals, uint NrmType, object pObjTangents, uint TanType, object pObjBinormals, uint BnrmType, object pWeights, int nWeight, object pMtxIndices, int nMtxIdx, AppMain.NNS_MATRIX[] posmtx, AppMain.NNS_MATRIX[] nrmmtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000737 RID: 1847 RVA: 0x0003FBD4 File Offset: 0x0003DDD4
    private static void nnCalcPliableVerticesGeneral( object pPliablePositions, object pPliableNormals, object pPliableTangents, object pPliableBinormals, int nVtx, object pObjPositions, uint PosType, object pObjNormals, uint NrmType, object pObjTangents, uint TanType, object pObjBinormals, uint BnrmType, object pWeights, int nWeight, object pMtxIndices, int nMtxIdx, AppMain.NNS_MATRIX[] posmtx, AppMain.NNS_MATRIX[] nrmmtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000738 RID: 1848 RVA: 0x0003FBDB File Offset: 0x0003DDDB
    private void nnCalcPliableObject( AppMain.NNS_PLIABLEOBJ pobj, AppMain.NNS_MATRIX mtxpal, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000739 RID: 1849 RVA: 0x0003FBE2 File Offset: 0x0003DDE2
    private void nnCalcPliableObjectNodeStatusList( AppMain.NNS_PLIABLEOBJ pobj, AppMain.NNS_MATRIX mtxpal, uint nodestatlist, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600073A RID: 1850 RVA: 0x0003FBE9 File Offset: 0x0003DDE9
    private void nnTransformUpVectorCameraLocal( AppMain.NNS_VECTOR vec, AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, float x, float y, float z )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600073B RID: 1851 RVA: 0x0003FBF0 File Offset: 0x0003DDF0
    private void nnPitchUpVectorCamera( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, int pitch )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600073C RID: 1852 RVA: 0x0003FBF7 File Offset: 0x0003DDF7
    private void nnRollUpVectorCamera( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, int roll )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600073D RID: 1853 RVA: 0x0003FBFE File Offset: 0x0003DDFE
    private void nnYawUpVectorCamera( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, int yaw )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600073E RID: 1854 RVA: 0x0003FC05 File Offset: 0x0003DE05
    private void nnApproachTargetUpVectorCamera( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, float d )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600073F RID: 1855 RVA: 0x0003FC0C File Offset: 0x0003DE0C
    private void nnApproachTargetUpVectorCameraLevel( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, float d )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000740 RID: 1856 RVA: 0x0003FC13 File Offset: 0x0003DE13
    private void nnMoveTargetUpVectorCamera( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, float d )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000741 RID: 1857 RVA: 0x0003FC1A File Offset: 0x0003DE1A
    private void nnRotateUpVectorCameraAroundTargetH( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, int ang )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000742 RID: 1858 RVA: 0x0003FC21 File Offset: 0x0003DE21
    private void nnRotateUpVectorCameraAroundTargetV( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, int ang )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000743 RID: 1859 RVA: 0x0003FC28 File Offset: 0x0003DE28
    private void nnRotateUpVectorCameraLevelAroundTarget( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, int ang )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000744 RID: 1860 RVA: 0x0003FC2F File Offset: 0x0003DE2F
    private void nnMoveUpVectorCameraLocal( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, float x, float y, float z )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000745 RID: 1861 RVA: 0x0003FC36 File Offset: 0x0003DE36
    private void nnConvertCameraPointerUpVectorCamera( AppMain.NNS_CAMERA_TARGET_UPVECTOR cam, AppMain.NNS_CAMERAPTR camptr )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007E9 RID: 2025 RVA: 0x000452DC File Offset: 0x000434DC
    private void nnInitCircumsphere()
    {
        AppMain.ArrayPointer<AppMain.NNS_VECTOR> pointer = new AppMain.ArrayPointer<AppMain.NNS_VECTOR>(this.nngCircumPoint);
        float num = 0f;
        float num2 = 0f;
        float num3 = 0f;
        for ( int i = 0; i < 2; i++ )
        {
            float num4;
            float num5;
            AppMain.nnSinCos( AppMain.NNM_DEGtoA32( ( int )( ( float )i * 360f / 4f ) ), out num4, out num5 );
            float num6;
            float num7;
            AppMain.nnSinCos( 0, out num6, out num7 );
            for ( int j = 0; j < 20; j++ )
            {
                ( ~pointer ).x = num7 * num5 + num;
                ( ~pointer ).y = num6 + num2;
                ( ~pointer ).z = num7 * num4 + num3;
                pointer = ++pointer;
                AppMain.nnSinCos( AppMain.NNM_DEGtoA32( ( int )( ( float )( j + 1 ) * 360f / 20f ) ), out num6, out num7 );
                ( ~pointer ).x = num7 * num5 + num;
                ( ~pointer ).y = num6 + num2;
                ( ~pointer ).z = num7 * num4 + num3;
                pointer = ++pointer;
            }
        }
        for ( int i = 0; i < 1; i++ )
        {
            float num4;
            float num5;
            AppMain.nnSinCos( AppMain.NNM_DEGtoA32( 180 ), out num4, out num5 );
            float num6;
            float num7;
            AppMain.nnSinCos( 0, out num6, out num7 );
            for ( int j = 0; j < 20; j++ )
            {
                ( ~pointer ).x = num5 * num7 + num;
                ( ~pointer ).y = num4 + num2;
                ( ~pointer ).z = num5 * num6 + num3;
                pointer = ++pointer;
                AppMain.nnSinCos( AppMain.NNM_DEGtoA32( ( int )( ( float )( j + 1 ) * 360f / 20f ) ), out num6, out num7 );
                ( ~pointer ).x = num5 * num7 + num;
                ( ~pointer ).y = num4 + num2;
                ( ~pointer ).z = num5 * num6 + num3;
                pointer = ++pointer;
            }
        }
    }

    // Token: 0x060007EA RID: 2026 RVA: 0x000454C7 File Offset: 0x000436C7
    private AppMain.NNE_CIRCUM_COL nnEstCircumColNum( uint clipstat )
    {
        AppMain.mppAssertNotImpl();
        return AppMain.NNE_CIRCUM_COL.NNE_CIRCUM_COL_NONE;
    }

    // Token: 0x060007EB RID: 2027 RVA: 0x000454CF File Offset: 0x000436CF
    private void nnSetCircumsphereColor( uint dstflag, AppMain.NNE_CIRCUM_COL colnum, ref AppMain.NNS_RGBA col )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007EC RID: 2028 RVA: 0x000454D6 File Offset: 0x000436D6
    private void nnDrawCircumsphereCore( AppMain.NNS_VECTOR center, float radius, AppMain.NNS_MATRIX mtx, ref AppMain.NNS_RGBA col, int trans )
    {
        AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007ED RID: 2029 RVA: 0x000454E9 File Offset: 0x000436E9
    private void nnDrawClipBoxCore( AppMain.NNS_VECTOR center, float sx, float sy, float sz, AppMain.NNS_MATRIX mtx, ref AppMain.NNS_RGBA col, int trans )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007EE RID: 2030 RVA: 0x000454F0 File Offset: 0x000436F0
    private void nnDrawCircumsphereNode( int nodeIdx, uint hideflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007EF RID: 2031 RVA: 0x000454F7 File Offset: 0x000436F7
    private void nnDrawCircumsphere( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F0 RID: 2032 RVA: 0x000454FE File Offset: 0x000436FE
    private void nnDrawCircumsphereMotionNode( int nodeIdx, uint hideflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F1 RID: 2033 RVA: 0x00045505 File Offset: 0x00043705
    private void nnDrawCircumsphereMotion( AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F2 RID: 2034 RVA: 0x0004550C File Offset: 0x0004370C
    private void nnDrawCircumsphereTRSListNode( int nodeIdx, uint hideflag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F3 RID: 2035 RVA: 0x00045513 File Offset: 0x00043713
    private void nnDrawCircumsphereTRSList( AppMain.NNS_OBJECT obj, AppMain.NNS_TRS trslist, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F4 RID: 2036 RVA: 0x0004551A File Offset: 0x0004371A
    private void nnDrawClipSphere( AppMain.NNS_VECTOR center, float radius, AppMain.NNS_MATRIX mtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F5 RID: 2037 RVA: 0x00045521 File Offset: 0x00043721
    private void nnDrawClipBox( AppMain.NNS_VECTOR center, float sx, float sy, float sz, AppMain.NNS_MATRIX mtx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060007F6 RID: 2038 RVA: 0x00045528 File Offset: 0x00043728
    private void nnDrawClipBound( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        this.nnDrawCircumsphere( obj, basemtx, mstk, flag );
    }

    // Token: 0x060007F7 RID: 2039 RVA: 0x00045535 File Offset: 0x00043735
    private void nnDrawClipBoundMotion( AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        this.nnDrawCircumsphereMotion( obj, mot, frame, basemtx, mstk, flag );
    }

    // Token: 0x060007F8 RID: 2040 RVA: 0x00045546 File Offset: 0x00043746
    private void nnDrawClipBoundTRSList( AppMain.NNS_OBJECT obj, AppMain.NNS_TRS trslist, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        this.nnDrawCircumsphereTRSList( obj, trslist, basemtx, mstk, flag );
    }

    // Token: 0x060007F9 RID: 2041 RVA: 0x00045555 File Offset: 0x00043755
    private void nnSetClipBoundColor( uint dstflag, AppMain.NNE_CIRCUM_COL colnum, ref AppMain.NNS_RGBA col )
    {
        this.nnSetCircumsphereColor( dstflag, colnum, ref col );
    }

    // Token: 0x060007FA RID: 2042 RVA: 0x00045560 File Offset: 0x00043760
    private void nnCalcTRS( AppMain.NNS_TRS trs, AppMain.NNS_OBJECT obj, int nodeidx )
    {
        uint fType = obj.pNodeList[nodeidx].fType;
        trs.Translation.x = obj.pNodeList[nodeidx].Translation.x;
        trs.Translation.y = obj.pNodeList[nodeidx].Translation.y;
        trs.Translation.z = obj.pNodeList[nodeidx].Translation.z;
        if ( ( fType & 2U ) != 0U )
        {
            trs.Rotation.x = 0f;
            trs.Rotation.y = 0f;
            trs.Rotation.z = 0f;
            trs.Rotation.w = 1f;
        }
        else
        {
            int x = obj.pNodeList[nodeidx].Rotation.x;
            int ry;
            int rz;
            if ( ( fType & 114688U ) != 0U )
            {
                ry = 0;
                rz = 0;
            }
            else
            {
                ry = obj.pNodeList[nodeidx].Rotation.y;
                rz = obj.pNodeList[nodeidx].Rotation.z;
            }
            uint num = fType & 3840U;
            if ( num != 256U )
            {
                if ( num != 1024U )
                {
                    AppMain.nnMakeRotateXYZQuaternion( out trs.Rotation, x, ry, rz );
                }
                else
                {
                    AppMain.nnMakeRotateZXYQuaternion( out trs.Rotation, x, ry, rz );
                }
            }
            else
            {
                AppMain.nnMakeRotateXZYQuaternion( out trs.Rotation, x, ry, rz );
            }
        }
        trs.Scaling.x = obj.pNodeList[nodeidx].Scaling.x;
        trs.Scaling.y = obj.pNodeList[nodeidx].Scaling.y;
        trs.Scaling.z = obj.pNodeList[nodeidx].Scaling.z;
    }

    // Token: 0x060007FB RID: 2043 RVA: 0x00045708 File Offset: 0x00043908
    public static void nnCalcTRSList( AppMain.NNS_TRS[] trslist, int offset, AppMain.NNS_OBJECT obj )
    {
        for ( int i = 0; i < obj.nNode; i++ )
        {
            uint fType = obj.pNodeList[i].fType;
            uint num = fType & 3840U;
            int num2 = i + offset;
            trslist[num2].Translation.x = obj.pNodeList[i].Translation.x;
            trslist[num2].Translation.y = obj.pNodeList[i].Translation.y;
            trslist[num2].Translation.z = obj.pNodeList[i].Translation.z;
            if ( ( fType & 2U ) != 0U )
            {
                trslist[num2].Rotation.x = 0f;
                trslist[num2].Rotation.y = 0f;
                trslist[num2].Rotation.z = 0f;
                trslist[num2].Rotation.w = 1f;
            }
            else
            {
                int x = obj.pNodeList[i].Rotation.x;
                int ry;
                int rz;
                if ( ( fType & 114688U ) != 0U )
                {
                    ry = 0;
                    rz = 0;
                }
                else
                {
                    ry = obj.pNodeList[i].Rotation.y;
                    rz = obj.pNodeList[i].Rotation.z;
                }
                uint num3 = num;
                if ( num3 != 256U )
                {
                    if ( num3 != 1024U )
                    {
                        AppMain.nnMakeRotateXYZQuaternion( out trslist[num2].Rotation, x, ry, rz );
                    }
                    else
                    {
                        AppMain.nnMakeRotateZXYQuaternion( out trslist[num2].Rotation, x, ry, rz );
                    }
                }
                else
                {
                    AppMain.nnMakeRotateXZYQuaternion( out trslist[num2].Rotation, x, ry, rz );
                }
            }
            trslist[num2].Scaling.x = obj.pNodeList[i].Scaling.x;
            trslist[num2].Scaling.y = obj.pNodeList[i].Scaling.y;
            trslist[num2].Scaling.z = obj.pNodeList[i].Scaling.z;
        }
    }

    // Token: 0x060007FC RID: 2044 RVA: 0x000458FC File Offset: 0x00043AFC
    private static int nnCalcNodeMotionTRSCore( out int tflag, out int rflag, out int sflag, AppMain.NNS_VECTOR tv, AppMain.NNS_VECTOR sv, ref AppMain.NNS_QUATERNION rq, ref AppMain.NNS_QUATERNION invrq, bool need_invrq, AppMain.NNS_NODE pNode, int NodeIdx, AppMain.NNS_MOTION pMot, int SubMotIdx, float frame )
    {
        AppMain.NNS_ROTATE_A32 nns_ROTATE_A = default(AppMain.NNS_ROTATE_A32);
        uint fType = pNode.fType;
        uint num = fType & 3840U;
        tv.Assign( pNode.Translation );
        sv.Assign( pNode.Scaling );
        if ( ( fType & 2U ) != 0U )
        {
            nns_ROTATE_A.x = ( nns_ROTATE_A.y = ( nns_ROTATE_A.z = 0 ) );
            rq.x = 0f;
            rq.y = 0f;
            rq.z = 0f;
            rq.w = 1f;
            if ( need_invrq )
            {
                invrq.x = 0f;
                invrq.y = 0f;
                invrq.z = 0f;
                invrq.w = 1f;
            }
        }
        else
        {
            nns_ROTATE_A.x = pNode.Rotation.x;
            if ( ( fType & 114688U ) != 0U )
            {
                nns_ROTATE_A.y = 0;
                nns_ROTATE_A.z = 0;
            }
            else
            {
                nns_ROTATE_A.y = pNode.Rotation.y;
                nns_ROTATE_A.z = pNode.Rotation.z;
            }
            uint num2 = num;
            if ( num2 != 256U )
            {
                if ( num2 != 1024U )
                {
                    AppMain.nnMakeRotateXYZQuaternion( out rq, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                }
                else
                {
                    AppMain.nnMakeRotateZXYQuaternion( out rq, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                }
            }
            else
            {
                AppMain.nnMakeRotateXZYQuaternion( out rq, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
            }
            if ( need_invrq )
            {
                AppMain.nnInvertQuaternion( ref invrq, ref rq );
            }
        }
        tflag = 0;
        rflag = 0;
        sflag = 0;
        for ( int i = SubMotIdx; i < pMot.nSubmotion; i++ )
        {
            AppMain.NNS_SUBMOTION nns_SUBMOTION = pMot.pSubmotion[i];
            if ( NodeIdx < nns_SUBMOTION.Id )
            {
                SubMotIdx = i;
                break;
            }
            float num3;
            if ( nns_SUBMOTION.Id == NodeIdx && nns_SUBMOTION.fType != 0U && nns_SUBMOTION.StartFrame <= frame && frame <= nns_SUBMOTION.EndFrame && AppMain.nnCalcMotionFrame( out num3, nns_SUBMOTION.fIPType, nns_SUBMOTION.StartKeyFrame, nns_SUBMOTION.EndKeyFrame, frame ) != 0 )
            {
                if ( ( nns_SUBMOTION.fType & 30720U ) != 0U )
                {
                    rflag |= AppMain.nnCalcMotionRotate( nns_SUBMOTION, num3, ref nns_ROTATE_A, rq, num );
                }
                else if ( ( nns_SUBMOTION.fType & 1792U ) != 0U )
                {
                    tflag |= AppMain.nnCalcMotionTranslate( nns_SUBMOTION, num3, tv );
                }
                else if ( ( nns_SUBMOTION.fType & 229376U ) != 0U )
                {
                    sflag |= AppMain.nnCalcMotionScale( nns_SUBMOTION, num3, sv );
                }
                else if ( ( nns_SUBMOTION.fType & 786432U ) != 0U )
                {
                    AppMain.nnCallbackMotionUserData( AppMain.nncalctrsmotion.nnsObj, pMot, i, NodeIdx, num3, frame );
                }
            }
        }
        if ( rflag == 1 )
        {
            uint num4 = num;
            if ( num4 != 256U )
            {
                if ( num4 != 1024U )
                {
                    AppMain.nnMakeRotateXYZQuaternion( out rq, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                }
                else
                {
                    AppMain.nnMakeRotateZXYQuaternion( out rq, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
                }
            }
            else
            {
                AppMain.nnMakeRotateXZYQuaternion( out rq, nns_ROTATE_A.x, nns_ROTATE_A.y, nns_ROTATE_A.z );
            }
        }
        return SubMotIdx;
    }

    // Token: 0x060007FD RID: 2045 RVA: 0x00045C3C File Offset: 0x00043E3C
    private void nnCalcTRSMotion( AppMain.NNS_TRS trs, AppMain.NNS_OBJECT obj, int nodeidx, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.NNS_QUATERNION rotation = default(AppMain.NNS_QUATERNION);
        if ( ( mot.fType & 1U ) == 0U )
        {
            return;
        }
        AppMain.nncalctrsmotion.nnsObj = obj;
        if ( AppMain.nnCalcMotionFrame( out frame, mot.fType, mot.StartFrame, mot.EndFrame, frame ) == 0 )
        {
            this.nnCalcTRS( trs, obj, nodeidx );
            return;
        }
        AppMain.NNS_NODE pNode = obj.pNodeList[nodeidx];
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.nnCalcTRSMotion_tv;
        nns_VECTOR.Clear();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.nnCalcTRSMotion_sv;
        nns_VECTOR2.Clear();
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        int num;
        int num2;
        int num3;
        AppMain.nnCalcNodeMotionTRSCore( out num, out num2, out num3, nns_VECTOR, nns_VECTOR2, ref rotation, ref nns_QUATERNION, false, pNode, nodeidx, mot, 0, frame );
        trs.Translation.x = nns_VECTOR.x;
        trs.Translation.y = nns_VECTOR.y;
        trs.Translation.z = nns_VECTOR.z;
        trs.Rotation = rotation;
        trs.Scaling.x = nns_VECTOR2.x;
        trs.Scaling.y = nns_VECTOR2.y;
        trs.Scaling.z = nns_VECTOR2.z;
    }

    // Token: 0x060007FE RID: 2046 RVA: 0x00045D50 File Offset: 0x00043F50
    public static void nnCalcTRSListMotion( AppMain.NNS_TRS[] trslist, int offset, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.NNS_QUATERNION rotation = default(AppMain.NNS_QUATERNION);
        if ( ( mot.fType & 1U ) == 0U )
        {
            return;
        }
        if ( AppMain.nnCalcMotionFrame( out frame, mot.fType, mot.StartFrame, mot.EndFrame, frame ) == 0 )
        {
            AppMain.nnCalcTRSList( trslist, offset, obj );
            return;
        }
        AppMain.nncalctrsmotion.nnsObj = obj;
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.nnCalcTRSMotion_tv;
        nns_VECTOR.Clear();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.nnCalcTRSMotion_sv;
        nns_VECTOR2.Clear();
        int subMotIdx = 0;
        for ( int i = 0; i < obj.nNode; i++ )
        {
            AppMain.NNS_NODE pNode = obj.pNodeList[i];
            int num;
            int num2;
            int num3;
            subMotIdx = AppMain.nnCalcNodeMotionTRSCore( out num, out num2, out num3, nns_VECTOR, nns_VECTOR2, ref rotation, ref nns_QUATERNION, false, pNode, i, mot, subMotIdx, frame );
            int num4 = i + offset;
            trslist[num4].Translation.x = nns_VECTOR.x;
            trslist[num4].Translation.y = nns_VECTOR.y;
            trslist[num4].Translation.z = nns_VECTOR.z;
            trslist[num4].Rotation = rotation;
            trslist[num4].Scaling.x = nns_VECTOR2.x;
            trslist[num4].Scaling.y = nns_VECTOR2.y;
            trslist[num4].Scaling.z = nns_VECTOR2.z;
        }
    }

    // Token: 0x060007FF RID: 2047 RVA: 0x00045E94 File Offset: 0x00044094
    private static void nnCalcMatrixPaletteTRSListNode( int nodeIdx )
    {
        for (; ; )
        {
            AppMain.NNS_NODE nns_NODE = AppMain.nncalctrsmotion.nnsNodeList[nodeIdx];
            AppMain.NNS_TRS nns_TRS = AppMain.nncalctrsmotion.nnsTrsList[nodeIdx];
            AppMain.NNS_MATRIX nns_MATRIX;
            if ( ( nns_NODE.fType & 134217728U ) != 0U )
            {
                if ( ( nns_NODE.fType & 100663296U ) == 0U )
                {
                    goto IL_19F;
                }
                AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, null );
                nns_MATRIX = AppMain.nnGetCurrentMatrix( AppMain.nncalctrsmotion.nnsMstk );
                AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, nns_TRS.Translation.x, nns_TRS.Translation.y, nns_TRS.Translation.z );
                if ( ( nns_NODE.fType & 4096U ) != 0U )
                {
                    AppMain.nnCopyMatrix33( nns_MATRIX, AppMain.nncalctrsmotion.nnsBaseMtx );
                }
                else if ( ( nns_NODE.fType & 1835008U ) != 0U )
                {
                    if ( ( nns_NODE.fType & 262144U ) != 0U )
                    {
                        AppMain.nnNormalizeColumn0( nns_MATRIX );
                    }
                    if ( ( nns_NODE.fType & 524288U ) != 0U )
                    {
                        AppMain.nnNormalizeColumn1( nns_MATRIX );
                    }
                    if ( ( nns_NODE.fType & 1048576U ) != 0U )
                    {
                        AppMain.nnNormalizeColumn2( nns_MATRIX );
                    }
                }
                AppMain.nnQuaternionMatrix( nns_MATRIX, nns_MATRIX, ref nns_TRS.Rotation );
                AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, nns_TRS.Scaling.x, nns_TRS.Scaling.y, nns_TRS.Scaling.z );
                if ( ( nns_NODE.fType & 33554432U ) != 0U )
                {
                    AppMain.nnCalcMatrixPaletteTRSListNode1BoneXSIIK( nodeIdx );
                }
                else if ( ( nns_NODE.fType & 67108864U ) != 0U )
                {
                    AppMain.nnCalcMatrixPaletteTRSListNode2BoneXSIIK( nodeIdx );
                }
                AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
                nodeIdx = ( int )nns_NODE.iSibling;
            }
            else
            {
                if ( ( nns_NODE.fType & 16384U ) != 0U )
                {
                    break;
                }
                if ( ( nns_NODE.fType & 32768U ) != 0U )
                {
                    goto Block_10;
                }
                goto IL_19F;
            }
            IL_313:
            if ( nns_NODE.iSibling == -1 )
            {
                return;
            }
            continue;
            IL_19F:
            AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, null );
            nns_MATRIX = AppMain.nnGetCurrentMatrix( AppMain.nncalctrsmotion.nnsMstk );
            AppMain.nnTranslateMatrix( nns_MATRIX, nns_MATRIX, nns_TRS.Translation.x, nns_TRS.Translation.y, nns_TRS.Translation.z );
            if ( ( nns_NODE.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX, AppMain.nncalctrsmotion.nnsBaseMtx );
            }
            else if ( ( nns_NODE.fType & 1835008U ) != 0U )
            {
                if ( ( nns_NODE.fType & 262144U ) != 0U )
                {
                    AppMain.nnNormalizeColumn0( nns_MATRIX );
                }
                if ( ( nns_NODE.fType & 524288U ) != 0U )
                {
                    AppMain.nnNormalizeColumn1( nns_MATRIX );
                }
                if ( ( nns_NODE.fType & 1048576U ) != 0U )
                {
                    AppMain.nnNormalizeColumn2( nns_MATRIX );
                }
            }
            AppMain.nnQuaternionMatrix( nns_MATRIX, nns_MATRIX, ref nns_TRS.Rotation );
            AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, nns_TRS.Scaling.x, nns_TRS.Scaling.y, nns_TRS.Scaling.z );
            if ( nns_NODE.iMatrix != -1 )
            {
                if ( ( nns_NODE.fType & 8U ) != 0U )
                {
                    AppMain.nnCopyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX );
                }
                else
                {
                    AppMain.nnMultiplyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX, nns_NODE.InvInitMtx );
                }
            }
            if ( AppMain.nncalctrsmotion.nnsNodeStatList != null )
            {
                if ( nodeIdx == 0 && AppMain.nncalctrsmotion.nnsNSFlag != 0U )
                {
                    AppMain.nncalctrsmotion.nnsRootScale = AppMain.nnEstimateMatrixScaling( nns_MATRIX );
                }
                AppMain.nnCalcClipSetNodeStatus( AppMain.nncalctrsmotion.nnsNodeStatList, AppMain.nncalctrsmotion.nnsNodeList, nodeIdx, nns_MATRIX, AppMain.nncalctrsmotion.nnsRootScale, AppMain.nncalctrsmotion.nnsNSFlag );
            }
            if ( nns_NODE.iChild != -1 )
            {
                AppMain.nnCalcMatrixPaletteTRSListNode( ( int )nns_NODE.iChild );
            }
            AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
            nodeIdx = ( int )nns_NODE.iSibling;
            goto IL_313;
        }
        AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, null );
        AppMain.nnCalcMatrixPaletteTRSListNode1BoneSIIK( nodeIdx );
        AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
        return;
        Block_10:
        AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, null );
        AppMain.nnCalcMatrixPaletteTRSListNode2BoneSIIK( nodeIdx );
        AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
    }

    // Token: 0x06000800 RID: 2048 RVA: 0x000461C0 File Offset: 0x000443C0
    private static void nnCalcMatrixPaletteTRSList( AppMain.NNS_MATRIX[] mtxpal, uint[] nodestatlist, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS[] trslist, ref AppMain.SNNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        AppMain.nncalctrsmotion.nnsBaseMtx.Assign( ref basemtx );
        AppMain.nnSetCurrentMatrix( mstk, AppMain.nncalctrsmotion.nnsBaseMtx );
        AppMain.nncalctrsmotion.nnsMtxPal = mtxpal;
        AppMain.nncalctrsmotion.nnsNodeStatList = nodestatlist;
        AppMain.nncalctrsmotion.nnsNSFlag = flag;
        AppMain.nncalctrsmotion.nnsTrsList = trslist;
        AppMain.nncalctrsmotion.nnsNodeList = obj.pNodeList;
        AppMain.nncalctrsmotion.nnsMstk = mstk;
        AppMain.nnCalcMatrixPaletteTRSListNode( 0 );
    }

    // Token: 0x06000801 RID: 2049 RVA: 0x00046218 File Offset: 0x00044418
    private static void nnCalcMatrixPaletteTRSList( AppMain.NNS_MATRIX[] mtxpal, uint[] nodestatlist, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS[] trslist, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        if ( basemtx != null )
        {
            AppMain.nncalctrsmotion.nnsBaseMtx.Assign( basemtx );
        }
        else
        {
            AppMain.nncalctrsmotion.nnsBaseMtx.Assign( AppMain.nngUnitMatrix );
        }
        AppMain.nnSetCurrentMatrix( mstk, AppMain.nncalctrsmotion.nnsBaseMtx );
        AppMain.nncalctrsmotion.nnsMtxPal = mtxpal;
        AppMain.nncalctrsmotion.nnsNodeStatList = nodestatlist;
        AppMain.nncalctrsmotion.nnsNSFlag = flag;
        AppMain.nncalctrsmotion.nnsTrsList = trslist;
        AppMain.nncalctrsmotion.nnsNodeList = obj.pNodeList;
        AppMain.nncalctrsmotion.nnsMstk = mstk;
        AppMain.nnCalcMatrixPaletteTRSListNode( 0 );
    }

    // Token: 0x06000802 RID: 2050 RVA: 0x00046288 File Offset: 0x00044488
    public static void nnLinkMotion( AppMain.ArrayPointer<AppMain.NNS_TRS> dstpose, AppMain.ArrayPointer<AppMain.NNS_TRS> pose0, AppMain.ArrayPointer<AppMain.NNS_TRS> pose1, int nnode, float ratio )
    {
        for ( int i = 0; i < nnode; i++ )
        {
            AppMain.NNS_TRS nns_TRS = dstpose.array[dstpose.offset + i];
            AppMain.NNS_TRS nns_TRS2 = pose0.array[pose0.offset + i];
            AppMain.NNS_TRS nns_TRS3 = pose1.array[pose1.offset + i];
            nns_TRS.Translation.x = nns_TRS2.Translation.x + ( nns_TRS3.Translation.x - nns_TRS2.Translation.x ) * ratio;
            nns_TRS.Translation.y = nns_TRS2.Translation.y + ( nns_TRS3.Translation.y - nns_TRS2.Translation.y ) * ratio;
            nns_TRS.Translation.z = nns_TRS2.Translation.z + ( nns_TRS3.Translation.z - nns_TRS2.Translation.z ) * ratio;
            nns_TRS.Scaling.x = nns_TRS2.Scaling.x + ( nns_TRS3.Scaling.x - nns_TRS2.Scaling.x ) * ratio;
            nns_TRS.Scaling.y = nns_TRS2.Scaling.y + ( nns_TRS3.Scaling.y - nns_TRS2.Scaling.y ) * ratio;
            nns_TRS.Scaling.z = nns_TRS2.Scaling.z + ( nns_TRS3.Scaling.z - nns_TRS2.Scaling.z ) * ratio;
            AppMain.nnSlerpQuaternion( out nns_TRS.Rotation, ref nns_TRS2.Rotation, ref nns_TRS3.Rotation, ratio );
        }
    }

    // Token: 0x06000803 RID: 2051 RVA: 0x0004641C File Offset: 0x0004461C
    private void nnBlendMotion( AppMain.ArrayPointer<AppMain.NNS_TRS> _dstpose, AppMain.ArrayPointer<AppMain.NNS_TRS> _srcpose, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mot, float frame, AppMain.NNE_MOTIONBLEND blendmode )
    {
        if ( ( mot.fType & 1U ) == 0U )
        {
            return;
        }
        AppMain.NNS_QUATERNION rotation = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.ArrayPointer<AppMain.NNS_TRS> pointer = _dstpose.Clone();
        AppMain.ArrayPointer<AppMain.NNS_TRS> pointer2 = _srcpose.Clone();
        if ( AppMain.nnCalcMotionFrame( out frame, mot.fType, mot.StartFrame, mot.EndFrame, frame ) == 0 )
        {
            if ( ~pointer != ~pointer2 )
            {
                for ( int i = 0; i < obj.nNode; i++ )
                {
                    pointer[i].Assign( pointer2 );
                }
            }
            return;
        }
        int subMotIdx = 0;
        AppMain.ArrayPointer<AppMain.NNS_NODE> pointer3 = obj.pNodeList;
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.nnCalcTRSMotion_tv;
        nns_VECTOR.Clear();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.nnCalcTRSMotion_sv;
        nns_VECTOR2.Clear();
        for ( int j = 0; j < obj.nNode; j++ )
        {
            int num;
            int num2;
            int num3;
            subMotIdx = AppMain.nnCalcNodeMotionTRSCore( out num, out num2, out num3, nns_VECTOR, nns_VECTOR2, ref rotation, ref nns_QUATERNION, true, pointer3, j, mot, subMotIdx, frame );
            switch ( blendmode )
            {
                case AppMain.NNE_MOTIONBLEND.NNE_MOTIONBLEND_REPLACE_ALL:
                    if ( num != 0 || num2 != 0 || num3 != 0 )
                    {
                        ( ~pointer ).Translation.x = nns_VECTOR.x;
                        ( ~pointer ).Translation.y = nns_VECTOR.y;
                        ( ~pointer ).Translation.z = nns_VECTOR.z;
                        ( ~pointer ).Rotation = rotation;
                        ( ~pointer ).Scaling.x = nns_VECTOR2.x;
                        ( ~pointer ).Scaling.y = nns_VECTOR2.y;
                        ( ~pointer ).Scaling.z = nns_VECTOR2.z;
                    }
                    else
                    {
                        ( ~pointer ).Assign( ~pointer2 );
                    }
                    break;
                case AppMain.NNE_MOTIONBLEND.NNE_MOTIONBLEND_ADD_TRANSLATION:
                    if ( num != 0 || num2 != 0 || num3 != 0 )
                    {
                        ( ~pointer ).Translation.x = ( ~pointer2 ).Translation.x + nns_VECTOR.x - ( ~pointer3 ).Translation.x;
                        ( ~pointer ).Translation.y = ( ~pointer2 ).Translation.y + nns_VECTOR.y - ( ~pointer3 ).Translation.y;
                        ( ~pointer ).Translation.z = ( ~pointer2 ).Translation.z + nns_VECTOR.z - ( ~pointer3 ).Translation.z;
                        ( ~pointer ).Rotation = rotation;
                        ( ~pointer ).Scaling.x = nns_VECTOR2.x;
                        ( ~pointer ).Scaling.y = nns_VECTOR2.y;
                        ( ~pointer ).Scaling.z = nns_VECTOR2.z;
                    }
                    else
                    {
                        ( ~pointer ).Assign( ~pointer2 );
                    }
                    break;
                case AppMain.NNE_MOTIONBLEND.NNE_MOTIONBLEND_ADD_ALL:
                    if ( num != 0 )
                    {
                        ( ~pointer ).Translation.x = ( ~pointer2 ).Translation.x + nns_VECTOR.x - ( ~pointer3 ).Translation.x;
                        ( ~pointer ).Translation.y = ( ~pointer2 ).Translation.y + nns_VECTOR.y - ( ~pointer3 ).Translation.y;
                        ( ~pointer ).Translation.z = ( ~pointer2 ).Translation.z + nns_VECTOR.z - ( ~pointer3 ).Translation.z;
                    }
                    else
                    {
                        ( ~pointer ).Translation.x = ( ~pointer2 ).Translation.x;
                        ( ~pointer ).Translation.y = ( ~pointer2 ).Translation.y;
                        ( ~pointer ).Translation.z = ( ~pointer2 ).Translation.z;
                    }
                    if ( num2 != 0 )
                    {
                        AppMain.nnMultiplyQuaternion( ref ( ~pointer ).Rotation, ref ( ~pointer2 ).Rotation, ref nns_QUATERNION );
                        AppMain.nnMultiplyQuaternion( ref ( ~pointer ).Rotation, ref ( ~pointer ).Rotation, ref rotation );
                    }
                    else
                    {
                        ( ~pointer ).Rotation = ( ~pointer2 ).Rotation;
                    }
                    if ( num3 != 0 )
                    {
                        ( ~pointer ).Scaling.x = ( ~pointer2 ).Scaling.x * nns_VECTOR2.x / ( ~pointer3 ).Scaling.x;
                        ( ~pointer ).Scaling.y = ( ~pointer2 ).Scaling.y * nns_VECTOR2.y / ( ~pointer3 ).Scaling.y;
                        ( ~pointer ).Scaling.z = ( ~pointer2 ).Scaling.z * nns_VECTOR2.z / ( ~pointer3 ).Scaling.z;
                    }
                    else
                    {
                        ( ~pointer ).Scaling.x = ( ~pointer2 ).Scaling.x;
                        ( ~pointer ).Scaling.y = ( ~pointer2 ).Scaling.y;
                        ( ~pointer ).Scaling.z = ( ~pointer2 ).Scaling.z;
                    }
                    break;
            }
            pointer3 = ++pointer3;
            pointer = ++pointer;
            pointer2 = ++pointer2;
        }
    }

    // Token: 0x06000804 RID: 2052 RVA: 0x000469F0 File Offset: 0x00044BF0
    private void nnBlendMotionNode( AppMain.NNS_TRS dsttrs, AppMain.NNS_TRS srctrs, AppMain.NNS_OBJECT obj, int inode, AppMain.NNS_MOTION mot, float frame, AppMain.NNE_MOTIONBLEND blendmode )
    {
        if ( ( mot.fType & 1U ) == 0U )
        {
            return;
        }
        if ( AppMain.nnCalcMotionFrame( out frame, mot.fType, mot.StartFrame, mot.EndFrame, frame ) == 0 )
        {
            if ( dsttrs != srctrs )
            {
                dsttrs.Assign( srctrs );
            }
            return;
        }
        AppMain.NNS_QUATERNION rotation = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.nnCalcTRSMotion_tv;
        nns_VECTOR.Clear();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.nnCalcTRSMotion_sv;
        nns_VECTOR2.Clear();
        AppMain.NNS_NODE nns_NODE = obj.pNodeList[inode];
        int num;
        int num2;
        int num3;
        AppMain.nnCalcNodeMotionTRSCore( out num, out num2, out num3, nns_VECTOR, nns_VECTOR2, ref rotation, ref nns_QUATERNION, true, nns_NODE, inode, mot, 0, frame );
        switch ( blendmode )
        {
            case AppMain.NNE_MOTIONBLEND.NNE_MOTIONBLEND_REPLACE_ALL:
                if ( num != 0 || num2 != 0 || num3 != 0 )
                {
                    dsttrs.Translation.x = nns_VECTOR.x;
                    dsttrs.Translation.y = nns_VECTOR.y;
                    dsttrs.Translation.z = nns_VECTOR.z;
                    dsttrs.Rotation = rotation;
                    dsttrs.Scaling.x = nns_VECTOR2.x;
                    dsttrs.Scaling.y = nns_VECTOR2.y;
                    dsttrs.Scaling.z = nns_VECTOR2.z;
                    return;
                }
                dsttrs.Assign( srctrs );
                return;
            case AppMain.NNE_MOTIONBLEND.NNE_MOTIONBLEND_ADD_TRANSLATION:
                if ( num != 0 || num2 != 0 || num3 != 0 )
                {
                    dsttrs.Translation.x = srctrs.Translation.x + nns_VECTOR.x - nns_NODE.Translation.x;
                    dsttrs.Translation.y = srctrs.Translation.y + nns_VECTOR.y - nns_NODE.Translation.y;
                    dsttrs.Translation.z = srctrs.Translation.z + nns_VECTOR.z - nns_NODE.Translation.z;
                    dsttrs.Rotation = rotation;
                    dsttrs.Scaling.x = nns_VECTOR2.x;
                    dsttrs.Scaling.y = nns_VECTOR2.y;
                    dsttrs.Scaling.z = nns_VECTOR2.z;
                    return;
                }
                dsttrs.Assign( srctrs );
                return;
            case AppMain.NNE_MOTIONBLEND.NNE_MOTIONBLEND_ADD_ALL:
                if ( num != 0 )
                {
                    dsttrs.Translation.x = srctrs.Translation.x + nns_VECTOR.x - nns_NODE.Translation.x;
                    dsttrs.Translation.y = srctrs.Translation.y + nns_VECTOR.y - nns_NODE.Translation.y;
                    dsttrs.Translation.z = srctrs.Translation.z + nns_VECTOR.z - nns_NODE.Translation.z;
                }
                else
                {
                    dsttrs.Translation.x = srctrs.Translation.x;
                    dsttrs.Translation.y = srctrs.Translation.y;
                    dsttrs.Translation.z = srctrs.Translation.z;
                }
                if ( num2 != 0 )
                {
                    AppMain.nnMultiplyQuaternion( ref dsttrs.Rotation, ref srctrs.Rotation, ref nns_QUATERNION );
                    AppMain.nnMultiplyQuaternion( ref dsttrs.Rotation, ref dsttrs.Rotation, ref rotation );
                }
                else
                {
                    dsttrs.Rotation = srctrs.Rotation;
                }
                if ( num3 != 0 )
                {
                    dsttrs.Scaling.x = srctrs.Scaling.x * nns_VECTOR2.x / nns_NODE.Scaling.x;
                    dsttrs.Scaling.y = srctrs.Scaling.y * nns_VECTOR2.y / nns_NODE.Scaling.y;
                    dsttrs.Scaling.z = srctrs.Scaling.z * nns_VECTOR2.z / nns_NODE.Scaling.z;
                    return;
                }
                dsttrs.Scaling.x = srctrs.Scaling.x;
                dsttrs.Scaling.y = srctrs.Scaling.y;
                dsttrs.Scaling.z = srctrs.Scaling.z;
                return;
            default:
                return;
        }
    }

    // Token: 0x06000805 RID: 2053 RVA: 0x00046DCD File Offset: 0x00044FCD
    private void nnCalcMatrixTRSList1BoneSIIK( AppMain.NNS_MATRIX jnt1mtx, AppMain.NNS_MATRIX effmtx, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS[] trslist, AppMain.NNS_MATRIX basemtx, int jnt1idx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000806 RID: 2054 RVA: 0x00046DD4 File Offset: 0x00044FD4
    private void nnCalcMatrixTRSList2BoneSIIK( AppMain.NNS_MATRIX jnt1mtx, AppMain.NNS_MATRIX jnt2mtx, AppMain.NNS_MATRIX effmtx, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS[] trslist, AppMain.NNS_MATRIX basemtx, int jnt1idx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000807 RID: 2055 RVA: 0x00046DDB File Offset: 0x00044FDB
    private static void nnCalcMatrixPaletteTRSListNode1BoneSIIK( int jnt1nodeIdx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000808 RID: 2056 RVA: 0x00046DE2 File Offset: 0x00044FE2
    private static void nnCalcMatrixPaletteTRSListNode2BoneSIIK( int jnt1nodeIdx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000809 RID: 2057 RVA: 0x00046DEC File Offset: 0x00044FEC
    private void nnCalcMatrixPaletteLinkMotionNode( int nodeIdx )
    {
        AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR2 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR3 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_VECTOR nns_VECTOR4 = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
        AppMain.NNS_QUATERNION rotation = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_QUATERNION nns_QUATERNION = default(AppMain.NNS_QUATERNION);
        AppMain.NNS_TRS nns_TRS = new AppMain.NNS_TRS();
        AppMain.NNS_NODE nns_NODE;
        do
        {
            nns_NODE = AppMain.nncalctrsmotion.nnsNodeList[nodeIdx];
            AppMain.NNS_QUATERNION nns_QUATERNION2 = default(AppMain.NNS_QUATERNION);
            int num;
            int num2;
            int num3;
            AppMain.nncalctrsmotion.nnsSubMotIdx0 = AppMain.nnCalcNodeMotionTRSCore( out num, out num2, out num3, nns_VECTOR, nns_VECTOR2, ref rotation, ref nns_QUATERNION2, false, nns_NODE, nodeIdx, AppMain.nncalctrsmotion.nnsMot0, AppMain.nncalctrsmotion.nnsSubMotIdx0, AppMain.nncalctrsmotion.nnsFrame0 );
            int num4;
            int num5;
            int num6;
            AppMain.nncalctrsmotion.nnsSubMotIdx1 = AppMain.nnCalcNodeMotionTRSCore( out num4, out num5, out num6, nns_VECTOR3, nns_VECTOR4, ref nns_QUATERNION, ref nns_QUATERNION2, false, nns_NODE, nodeIdx, AppMain.nncalctrsmotion.nnsMot1, AppMain.nncalctrsmotion.nnsSubMotIdx1, AppMain.nncalctrsmotion.nnsFrame1 );
            float num7 = 1f - AppMain.nncalctrsmotion.nnsRatio;
            AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, null );
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.nnGetCurrentMatrix(AppMain.nncalctrsmotion.nnsMstk);
            if ( ( num | num4 ) != 0 )
            {
                nns_TRS.Translation.x = nns_VECTOR.x * num7 + nns_VECTOR3.x * AppMain.nncalctrsmotion.nnsRatio;
                nns_TRS.Translation.y = nns_VECTOR.y * num7 + nns_VECTOR3.y * AppMain.nncalctrsmotion.nnsRatio;
                nns_TRS.Translation.z = nns_VECTOR.z * num7 + nns_VECTOR3.z * AppMain.nncalctrsmotion.nnsRatio;
                AppMain.nnTranslateMatrixFast( nns_MATRIX, nns_TRS.Translation.x, nns_TRS.Translation.y, nns_TRS.Translation.z );
            }
            else
            {
                AppMain.nnTranslateMatrixFast( nns_MATRIX, nns_VECTOR.x, nns_VECTOR.y, nns_VECTOR.z );
            }
            if ( ( nns_NODE.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX, AppMain.nncalctrsmotion.nnsBaseMtx );
            }
            else if ( ( nns_NODE.fType & 1835008U ) != 0U )
            {
                if ( ( nns_NODE.fType & 262144U ) != 0U )
                {
                    AppMain.nnNormalizeColumn0( nns_MATRIX );
                }
                if ( ( nns_NODE.fType & 524288U ) != 0U )
                {
                    AppMain.nnNormalizeColumn1( nns_MATRIX );
                }
                if ( ( nns_NODE.fType & 1048576U ) != 0U )
                {
                    AppMain.nnNormalizeColumn2( nns_MATRIX );
                }
            }
            if ( ( num2 | num5 ) != 0 )
            {
                AppMain.nnSlerpQuaternion( out nns_TRS.Rotation, ref rotation, ref nns_QUATERNION, AppMain.nncalctrsmotion.nnsRatio );
            }
            else
            {
                nns_TRS.Rotation = rotation;
            }
            AppMain.nnQuaternionMatrix( nns_MATRIX, nns_MATRIX, ref nns_TRS.Rotation );
            if ( ( num3 | num6 ) != 0 )
            {
                nns_TRS.Scaling.x = nns_VECTOR2.x * num7 + nns_VECTOR4.x * AppMain.nncalctrsmotion.nnsRatio;
                nns_TRS.Scaling.y = nns_VECTOR2.y * num7 + nns_VECTOR4.y * AppMain.nncalctrsmotion.nnsRatio;
                nns_TRS.Scaling.z = nns_VECTOR2.z * num7 + nns_VECTOR4.z * AppMain.nncalctrsmotion.nnsRatio;
                AppMain.nnScaleMatrix( nns_MATRIX, nns_MATRIX, nns_TRS.Scaling.x, nns_TRS.Scaling.y, nns_TRS.Scaling.z );
            }
            else
            {
                AppMain.nnScaleMatrixFast( nns_MATRIX, nns_VECTOR2.x, nns_VECTOR2.y, nns_VECTOR2.z );
            }
            if ( nns_NODE.iMatrix != -1 )
            {
                if ( ( nns_NODE.fType & 8U ) != 0U )
                {
                    AppMain.nnCopyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX );
                }
                else
                {
                    AppMain.nnMultiplyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX, nns_NODE.InvInitMtx );
                }
            }
            if ( AppMain.nncalctrsmotion.nnsNodeStatList != null )
            {
                if ( nodeIdx == 0 && AppMain.nncalctrsmotion.nnsNSFlag != 0U )
                {
                    AppMain.nncalctrsmotion.nnsRootScale = AppMain.nnEstimateMatrixScaling( nns_MATRIX );
                }
                AppMain.nnCalcClipSetNodeStatus( AppMain.nncalctrsmotion.nnsNodeStatList, AppMain.nncalctrsmotion.nnsNodeList, nodeIdx, nns_MATRIX, AppMain.nncalctrsmotion.nnsRootScale, AppMain.nncalctrsmotion.nnsNSFlag );
            }
            if ( nns_NODE.iChild != -1 )
            {
                this.nnCalcMatrixPaletteLinkMotionNode( ( int )nns_NODE.iChild );
            }
            AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
            nodeIdx = ( int )nns_NODE.iSibling;
        }
        while ( nns_NODE.iSibling != -1 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR2 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR3 );
        AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR4 );
    }

    // Token: 0x0600080A RID: 2058 RVA: 0x000471AC File Offset: 0x000453AC
    private void nnCalcMatrixTRSList1BoneXSIIK( AppMain.NNS_MATRIX[] mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS[] trslist, AppMain.NNS_MATRIX basemtx, int rootidx )
    {
        int num = -1;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num2 = -1;
        AppMain.NNS_VECTORFAST nns_VECTORFAST = default(AppMain.NNS_VECTORFAST);
        AppMain.NNS_NODE[] pNodeList = obj.pNodeList;
        AppMain.NNS_NODE nns_NODE = pNodeList[rootidx];
        AppMain.NNS_MATRIX src = mtxlist[rootidx];
        AppMain.NNS_NODE nns_NODE2;
        for ( int num3 = ( int )nns_NODE.iChild; num3 != -1; num3 = ( int )nns_NODE2.iSibling )
        {
            nns_NODE2 = pNodeList[num3];
            if ( ( nns_NODE2.fType & 16384U ) != 0U )
            {
                num = num3;
            }
            if ( ( nns_NODE2.fType & 8192U ) != 0U )
            {
                num2 = num3;
            }
        }
        AppMain.NNM_ASSERT( num != -1, "XSIIK 1Bone Joint1 not Found" );
        AppMain.NNM_ASSERT( num2 != -1, "XSIIK 1Bone Effector not Found" );
        AppMain.NNS_MATRIX nns_MATRIX2 = nns_MATRIX;
        AppMain.NNS_NODE nns_NODE3 = pNodeList[num];
        AppMain.NNS_TRS nns_TRS = trslist[num];
        AppMain.NNS_MATRIX nns_MATRIX3 = mtxlist[num];
        AppMain.NNS_NODE nns_NODE4 = pNodeList[num2];
        AppMain.NNS_TRS nns_TRS2 = trslist[num2];
        AppMain.NNS_MATRIX nns_MATRIX4 = mtxlist[num2];
        float siikboneLength = nns_NODE3.SIIKBoneLength;
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX2, ref nns_TRS.Rotation );
        AppMain.nnScaleMatrix( nns_MATRIX2, nns_MATRIX2, nns_TRS.Scaling.x, 1f, 1f );
        AppMain.nnMakeUnitMatrix( nns_MATRIX4 );
        AppMain.nnTransformVectorFast( out nns_VECTORFAST, basemtx, nns_TRS2.Translation );
        AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX4, ref nns_VECTORFAST );
        AppMain.nnCopyMatrix( nns_MATRIX3, src );
        AppMain.nnCalc1BoneSIIK( nns_MATRIX3, nns_MATRIX2, nns_MATRIX4, siikboneLength );
        if ( ( nns_NODE4.fType & 4096U ) == 0U )
        {
            AppMain.nnCopyMatrix33( nns_MATRIX4, src );
        }
        AppMain.nnQuaternionMatrix( nns_MATRIX4, nns_MATRIX4, ref nns_TRS2.Rotation );
    }

    // Token: 0x0600080B RID: 2059 RVA: 0x00047300 File Offset: 0x00045500
    private void nnCalcMatrixTRSList2BoneXSIIK( AppMain.NNS_MATRIX[] mtxlist, AppMain.NNS_OBJECT obj, AppMain.NNS_TRS[] trslist, AppMain.NNS_MATRIX basemtx, int rootidx )
    {
        int num = -1;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num2 = -1;
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num3 = -1;
        AppMain.NNS_VECTORFAST nns_VECTORFAST = default(AppMain.NNS_VECTORFAST);
        AppMain.NNS_NODE[] pNodeList = obj.pNodeList;
        AppMain.NNS_NODE nns_NODE = pNodeList[rootidx];
        AppMain.NNS_MATRIX src = mtxlist[rootidx];
        AppMain.NNS_NODE nns_NODE2;
        for ( int num4 = ( int )nns_NODE.iChild; num4 != -1; num4 = ( int )nns_NODE2.iSibling )
        {
            nns_NODE2 = pNodeList[num4];
            if ( ( nns_NODE2.fType & 32768U ) != 0U )
            {
                num = num4;
                num2 = ( int )nns_NODE2.iChild;
                AppMain.NNM_ASSERT( pNodeList[num2].fType & 65536U, "XSIIK 2Bone Joint2 not Found" );
            }
            if ( ( nns_NODE2.fType & 8192U ) != 0U )
            {
                num3 = num4;
            }
        }
        AppMain.NNM_ASSERT( num != -1, "XSIIK 2Bone Joint1 not Found" );
        AppMain.NNM_ASSERT( num3 != -1, "XSIIK 2Bone Effector not Found" );
        AppMain.NNS_NODE nns_NODE3 = pNodeList[num];
        AppMain.NNS_TRS nns_TRS = trslist[num];
        AppMain.NNS_MATRIX nns_MATRIX3 = mtxlist[num];
        AppMain.NNS_MATRIX nns_MATRIX4 = nns_MATRIX;
        AppMain.NNS_NODE nns_NODE4 = pNodeList[num2];
        AppMain.NNS_TRS nns_TRS2 = trslist[num2];
        AppMain.NNS_MATRIX jnt2mtx = mtxlist[num2];
        AppMain.NNS_MATRIX nns_MATRIX5 = nns_MATRIX2;
        AppMain.NNS_NODE nns_NODE5 = pNodeList[num3];
        AppMain.NNS_TRS nns_TRS3 = trslist[num3];
        AppMain.NNS_MATRIX nns_MATRIX6 = mtxlist[num3];
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX4, ref nns_TRS.Rotation );
        AppMain.nnScaleMatrix( nns_MATRIX4, nns_MATRIX4, nns_TRS.Scaling.x, 1f, 1f );
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX5, ref nns_TRS2.Rotation );
        AppMain.nnScaleMatrix( nns_MATRIX5, nns_MATRIX5, nns_TRS2.Scaling.x, 1f, 1f );
        float siikboneLength = nns_NODE3.SIIKBoneLength;
        float siikboneLength2 = nns_NODE4.SIIKBoneLength;
        AppMain.nnMakeUnitMatrix( nns_MATRIX6 );
        AppMain.nnTransformVectorFast( out nns_VECTORFAST, basemtx, nns_TRS3.Translation );
        AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX6, ref nns_VECTORFAST );
        int zpref;
        if ( ( nns_NODE4.fType & 131072U ) != 0U )
        {
            zpref = 1;
        }
        else
        {
            zpref = 0;
        }
        AppMain.nnCopyMatrix( nns_MATRIX3, src );
        AppMain.nnCalc2BoneSIIK( nns_MATRIX3, nns_MATRIX4, jnt2mtx, nns_MATRIX5, nns_MATRIX6, siikboneLength, siikboneLength2, zpref );
        if ( ( nns_NODE5.fType & 4096U ) == 0U )
        {
            AppMain.nnCopyMatrix33( nns_MATRIX6, src );
        }
        AppMain.nnQuaternionMatrix( nns_MATRIX6, nns_MATRIX6, ref nns_TRS3.Rotation );
    }

    // Token: 0x0600080C RID: 2060 RVA: 0x000474EC File Offset: 0x000456EC
    private static void nnCalcMatrixPaletteTRSListNode1BoneXSIIK( int rootidx )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num = -1;
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        int num2 = -1;
        AppMain.NNS_MATRIX nns_MATRIX4 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX5 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_VECTORFAST nns_VECTORFAST = default(AppMain.NNS_VECTORFAST);
        AppMain.NNS_NODE nns_NODE = AppMain.nncalctrsmotion.nnsNodeList[rootidx];
        AppMain.NNS_MATRIX nns_MATRIX6 = nns_MATRIX;
        AppMain.nnCopyMatrix( nns_MATRIX6, AppMain.nnGetCurrentMatrix( AppMain.nncalctrsmotion.nnsMstk ) );
        AppMain.NNS_NODE nns_NODE2;
        for ( int num3 = ( int )nns_NODE.iChild; num3 != -1; num3 = ( int )nns_NODE2.iSibling )
        {
            nns_NODE2 = AppMain.nncalctrsmotion.nnsNodeList[num3];
            if ( ( nns_NODE2.fType & 16384U ) != 0U )
            {
                num = num3;
            }
            if ( ( nns_NODE2.fType & 8192U ) != 0U )
            {
                num2 = num3;
            }
        }
        AppMain.NNM_ASSERT( num != -1, "XSIIK 1Bone Joint1 not Found" );
        AppMain.NNM_ASSERT( num2 != -1, "XSIIK 1Bone Effector not Found" );
        AppMain.NNS_NODE nns_NODE3 = AppMain.nncalctrsmotion.nnsNodeList[num];
        AppMain.NNS_TRS nns_TRS = AppMain.nncalctrsmotion.nnsTrsList[num];
        AppMain.NNS_MATRIX nns_MATRIX7 = nns_MATRIX2;
        AppMain.NNS_MATRIX nns_MATRIX8 = nns_MATRIX3;
        AppMain.NNS_NODE nns_NODE4 = AppMain.nncalctrsmotion.nnsNodeList[num2];
        AppMain.NNS_MATRIX nns_MATRIX9 = nns_MATRIX4;
        AppMain.NNS_TRS nns_TRS2 = AppMain.nncalctrsmotion.nnsTrsList[num2];
        float siikboneLength = nns_NODE3.SIIKBoneLength;
        AppMain.nnCopyMatrix( nns_MATRIX7, nns_MATRIX6 );
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX8, ref nns_TRS.Rotation );
        AppMain.nnScaleMatrix( nns_MATRIX8, nns_MATRIX8, nns_TRS.Scaling.x, 1f, 1f );
        AppMain.nnMakeQuaternionMatrix( nns_MATRIX9, ref nns_TRS2.Rotation );
        AppMain.nnScaleMatrix( nns_MATRIX9, nns_MATRIX9, nns_TRS2.Scaling.x, nns_TRS2.Scaling.y, nns_TRS2.Scaling.z );
        AppMain.nnMakeUnitMatrix( nns_MATRIX5 );
        AppMain.nnCopyMatrix33( nns_MATRIX5, nns_MATRIX9 );
        AppMain.nnTransformVectorFast( out nns_VECTORFAST, AppMain.nncalctrsmotion.nnsBaseMtx, nns_TRS2.Translation );
        AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX9, ref nns_VECTORFAST );
        AppMain.nnCalc1BoneSIIK( nns_MATRIX7, nns_MATRIX8, nns_MATRIX9, siikboneLength );
        if ( ( nns_NODE4.fType & 4096U ) == 0U )
        {
            AppMain.nnCopyMatrix33( nns_MATRIX9, nns_MATRIX6 );
        }
        AppMain.nnMultiplyMatrix( nns_MATRIX9, nns_MATRIX9, nns_MATRIX5 );
        if ( nns_NODE.iMatrix != -1 )
        {
            AppMain.nnMultiplyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX6, nns_NODE.InvInitMtx );
        }
        if ( nns_NODE3.iMatrix != -1 )
        {
            AppMain.nnMultiplyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE3.iMatrix], nns_MATRIX7, nns_NODE3.InvInitMtx );
        }
        if ( nns_NODE4.iMatrix != -1 )
        {
            AppMain.nnMultiplyMatrix( AppMain.nncalctrsmotion.nnsMtxPal[( int )nns_NODE4.iMatrix], nns_MATRIX9, nns_NODE4.InvInitMtx );
        }
        if ( AppMain.nncalctrsmotion.nnsNodeStatList != null )
        {
            AppMain.nnCalcClipSetNodeStatus( AppMain.nncalctrsmotion.nnsNodeStatList, AppMain.nncalctrsmotion.nnsNodeList, rootidx, nns_MATRIX6, AppMain.nncalctrsmotion.nnsRootScale, AppMain.nncalctrsmotion.nnsNSFlag );
            AppMain.nnCalcClipSetNodeStatus( AppMain.nncalctrsmotion.nnsNodeStatList, AppMain.nncalctrsmotion.nnsNodeList, num, nns_MATRIX7, AppMain.nncalctrsmotion.nnsRootScale, AppMain.nncalctrsmotion.nnsNSFlag );
            AppMain.nnCalcClipSetNodeStatus( AppMain.nncalctrsmotion.nnsNodeStatList, AppMain.nncalctrsmotion.nnsNodeList, num2, nns_MATRIX9, AppMain.nncalctrsmotion.nnsRootScale, AppMain.nncalctrsmotion.nnsNSFlag );
        }
        if ( nns_NODE4.iChild != -1 )
        {
            AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, nns_MATRIX9 );
            AppMain.nnCalcMatrixPaletteTRSListNode( ( int )nns_NODE4.iChild );
            AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
        }
        if ( nns_NODE4.iSibling != -1 )
        {
            AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, nns_MATRIX7 );
            AppMain.nnCalcMatrixPaletteTRSListNode( ( int )nns_NODE4.iSibling );
            AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
        }
        if ( nns_NODE3.iChild != -1 )
        {
            AppMain.nnPushMatrix( AppMain.nncalctrsmotion.nnsMstk, nns_MATRIX7 );
            AppMain.nnCalcMatrixPaletteTRSListNode( ( int )nns_NODE3.iChild );
            AppMain.nnPopMatrix( AppMain.nncalctrsmotion.nnsMstk );
        }
        if ( nns_NODE3.iSibling != -1 )
        {
            AppMain.nnCalcMatrixPaletteTRSListNode( ( int )nns_NODE3.iSibling );
        }
    }

    // Token: 0x0600080D RID: 2061 RVA: 0x0004780F File Offset: 0x00045A0F
    private static void nnCalcMatrixPaletteTRSListNode2BoneXSIIK( int rootidx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x060009FB RID: 2555 RVA: 0x00059D14 File Offset: 0x00057F14
    private static void nnBindBufferVertexDescGL( AppMain.NNS_VTXLIST_GL_DESC pVtxDesc, uint flag )
    {
        OpenGL.glGenBuffer( out pVtxDesc.BufferName );
        OpenGL.glBindBuffer( 34962U, pVtxDesc.BufferName );
        if ( ( flag & 2U ) != 0U && ( pVtxDesc.Type & 65536U ) == 0U )
        {
            AppMain.NNS_VTXARRAY_GL nns_VTXARRAY_GL = pVtxDesc.pArray[0];
            int i = nns_VTXARRAY_GL.Stride * pVtxDesc.nVertex;
            ByteBuffer pointer = nns_VTXARRAY_GL.Pointer;
            ByteBuffer buffer = nns_VTXARRAY_GL.Pointer + i;
            for ( int j = 1; j < pVtxDesc.nArray; j++ )
            {
                nns_VTXARRAY_GL = pVtxDesc.pArray[j];
                i = nns_VTXARRAY_GL.Stride * pVtxDesc.nVertex;
                if ( pointer > nns_VTXARRAY_GL.Pointer )
                {
                    pointer = nns_VTXARRAY_GL.Pointer;
                }
                if ( buffer < nns_VTXARRAY_GL.Pointer + i )
                {
                    buffer = nns_VTXARRAY_GL.Pointer + i;
                }
            }
            pVtxDesc.pVertexBuffer = pointer;
            pVtxDesc.VertexBufferSize = buffer - pointer;
            OpenGL.glBufferVertexData( new AppMain.GLVertexBuffer_( pVtxDesc ) );
            for ( int j = 0; j < pVtxDesc.nArray; j++ )
            {
                AppMain.NNS_VTXARRAY_GL nns_VTXARRAY_GL2 = pVtxDesc.pArray[j];
            }
            return;
        }
        OpenGL.glBufferVertexData( new AppMain.GLVertexBuffer_( pVtxDesc ) );
        for ( int j = 0; j < pVtxDesc.nArray; j++ )
        {
            AppMain.NNS_VTXARRAY_GL nns_VTXARRAY_GL3 = pVtxDesc.pArray[j];
            nns_VTXARRAY_GL3.Pointer.Offset = nns_VTXARRAY_GL3.Pointer - pVtxDesc.pVertexBuffer;
        }
    }

    // Token: 0x060009FC RID: 2556 RVA: 0x00059E64 File Offset: 0x00058064
    private static void nnBindBufferPrimitiveDescGL( AppMain.NNS_PRIMLIST_GL_DESC pPrimDesc, uint flag )
    {
        OpenGL.glGenBuffer( out pPrimDesc.BufferName );
        OpenGL.glBindBuffer( 34963U, pPrimDesc.BufferName );
        OpenGL.glBufferIndexData( new GLIndexBuffer_ByteBuffer( pPrimDesc.pIndexBuffer, pPrimDesc.IndexBufferSize ) );
        for ( int i = 0; i < pPrimDesc.nPrim; i++ )
        {
            pPrimDesc.pIndices[i].Offset = pPrimDesc.pIndices[i] - pPrimDesc.pIndexBuffer;
        }
    }

    // Token: 0x060009FD RID: 2557 RVA: 0x00059ED8 File Offset: 0x000580D8
    private static uint nnBindBufferVertexListGL( AppMain.NNS_VTXLISTPTR[] dstvlist, AppMain.NNS_VTXLISTPTR[] srcvlist, int nVtxList, uint flag )
    {
        for ( int i = 0; i < nVtxList; i++ )
        {
            if ( ( srcvlist[i].fType & 1U ) != 0U )
            {
                AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = (AppMain.NNS_VTXLIST_GL_DESC)srcvlist[i].pVtxList;
                AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC2 = null;
                if ( dstvlist != null )
                {
                    dstvlist[i].fType = srcvlist[0].fType;
                    nns_VTXLIST_GL_DESC2 = ( AppMain.NNS_VTXLIST_GL_DESC )( dstvlist[i].pVtxList = new AppMain.NNS_VTXLIST_GL_DESC() );
                    nns_VTXLIST_GL_DESC2.Assign( nns_VTXLIST_GL_DESC );
                }
                if ( dstvlist != null )
                {
                    nns_VTXLIST_GL_DESC2.pArray = new AppMain.NNS_VTXARRAY_GL[nns_VTXLIST_GL_DESC.nArray];
                    for ( int j = 0; j < nns_VTXLIST_GL_DESC2.nArray; j++ )
                    {
                        nns_VTXLIST_GL_DESC2.pArray[j] = new AppMain.NNS_VTXARRAY_GL( nns_VTXLIST_GL_DESC.pArray[j] );
                    }
                }
                if ( ( flag & 1U ) != 0U && ( nns_VTXLIST_GL_DESC.Type & 6U ) != 0U )
                {
                    if ( ( flag & 2U ) != 0U && ( nns_VTXLIST_GL_DESC.Type & 65536U ) == 0U )
                    {
                        if ( dstvlist != null )
                        {
                            byte[] array = new byte[nns_VTXLIST_GL_DESC.VertexBufferSize];
                            Array.Copy( nns_VTXLIST_GL_DESC.pVertexBuffer.Data, array, nns_VTXLIST_GL_DESC.VertexBufferSize );
                            nns_VTXLIST_GL_DESC2.pVertexBuffer = ByteBuffer.Wrap( array );
                            for ( int k = 0; k < nns_VTXLIST_GL_DESC.nArray; k++ )
                            {
                                nns_VTXLIST_GL_DESC2.pArray[k].Pointer = nns_VTXLIST_GL_DESC2.pVertexBuffer + nns_VTXLIST_GL_DESC.pArray[k].Pointer.Offset;
                            }
                            nns_VTXLIST_GL_DESC2.VertexBufferSize = nns_VTXLIST_GL_DESC.VertexBufferSize;
                        }
                        else
                        {
                            for ( int k = 0; k < nns_VTXLIST_GL_DESC.nArray; k++ )
                            {
                            }
                        }
                    }
                    else if ( dstvlist != null )
                    {
                        byte[] array2 = new byte[nns_VTXLIST_GL_DESC.VertexBufferSize];
                        Array.Copy( nns_VTXLIST_GL_DESC.pVertexBuffer.Data, array2, nns_VTXLIST_GL_DESC.VertexBufferSize );
                        nns_VTXLIST_GL_DESC2.pVertexBuffer = ByteBuffer.Wrap( array2 );
                        for ( int k = 0; k < nns_VTXLIST_GL_DESC.nArray; k++ )
                        {
                            nns_VTXLIST_GL_DESC2.pArray[k].Pointer = nns_VTXLIST_GL_DESC2.pVertexBuffer + nns_VTXLIST_GL_DESC.pArray[k].Pointer.Offset;
                        }
                    }
                }
                else if ( dstvlist != null )
                {
                    AppMain.nnBindBufferVertexDescGL( nns_VTXLIST_GL_DESC2, flag );
                    dstvlist[i].fType |= 16U;
                }
                if ( nns_VTXLIST_GL_DESC.nMatrix > 0 && dstvlist != null )
                {
                    nns_VTXLIST_GL_DESC2.pMatrixIndices = new ushort[nns_VTXLIST_GL_DESC.nMatrix];
                    Array.Copy( nns_VTXLIST_GL_DESC.pMatrixIndices, nns_VTXLIST_GL_DESC2.pMatrixIndices, nns_VTXLIST_GL_DESC.nMatrix );
                }
            }
            else
            {
                AppMain.NNM_ASSERT( 0, "Unknown vertex foramt.\n" );
            }
        }
        return 0U;
    }

    // Token: 0x060009FE RID: 2558 RVA: 0x0005A124 File Offset: 0x00058324
    private static uint nnBindBufferPrimitiveListGL( AppMain.NNS_PRIMLISTPTR[] dstplist, AppMain.NNS_PRIMLISTPTR[] srcplist, int nPrimList, uint flag )
    {
        for ( int i = 0; i < nPrimList; i++ )
        {
            if ( dstplist != null )
            {
                dstplist[i].fType = ( srcplist[0].fType | 2U );
            }
            if ( ( srcplist[i].fType & 1U ) != 0U )
            {
                AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC = (AppMain.NNS_PRIMLIST_GL_DESC)srcplist[i].pPrimList;
                AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC2 = null;
                if ( dstplist != null )
                {
                    nns_PRIMLIST_GL_DESC2 = ( AppMain.NNS_PRIMLIST_GL_DESC )( dstplist[i].pPrimList = new AppMain.NNS_PRIMLIST_GL_DESC() );
                    nns_PRIMLIST_GL_DESC2.Assign( nns_PRIMLIST_GL_DESC );
                }
                if ( dstplist != null )
                {
                    nns_PRIMLIST_GL_DESC2.pCounts = new int[nns_PRIMLIST_GL_DESC.nPrim];
                    Array.Copy( nns_PRIMLIST_GL_DESC.pCounts, nns_PRIMLIST_GL_DESC2.pCounts, nns_PRIMLIST_GL_DESC.nPrim );
                }
                if ( dstplist != null )
                {
                    nns_PRIMLIST_GL_DESC2.pIndices = new UShortBuffer[nns_PRIMLIST_GL_DESC.nPrim];
                    Array.Copy( nns_PRIMLIST_GL_DESC.pIndices, nns_PRIMLIST_GL_DESC2.pIndices, nns_PRIMLIST_GL_DESC.nPrim );
                    AppMain.nnBindBufferPrimitiveDescGL( nns_PRIMLIST_GL_DESC2, flag );
                }
            }
            else
            {
                AppMain.NNM_ASSERT( 0, "Unknown primitive foramt.\n" );
            }
        }
        return 0U;
    }

    // Token: 0x060009FF RID: 2559 RVA: 0x0005A1FC File Offset: 0x000583FC
    private static uint nnBindBufferObjectGL( AppMain.NNS_OBJECT dstobj, AppMain.NNS_OBJECT srcobj, uint flag )
    {
        if ( ( srcobj.fType & 65536U ) != 0U )
        {
            AppMain.NNM_ASSERT( 0, "You can not bind-buffer the common-vertex-format object.\n" );
            return AppMain.nnCopyObject( dstobj, srcobj, 0U );
        }
        if ( ( srcobj.fType & 64U ) != 0U && ( srcobj.fType & 128U ) == 0U )
        {
            flag |= 2U;
        }
        if ( dstobj != null )
        {
            dstobj.Assign( srcobj );
            dstobj.fType |= 16777344U;
        }
        if ( dstobj != null )
        {
            dstobj.pMatPtrList = AppMain.New<AppMain.NNS_MATERIALPTR>( srcobj.nMaterial );
            AppMain.nnCopyMaterialList( dstobj.pMatPtrList, srcobj.pMatPtrList, srcobj.nMaterial, 0U );
        }
        else
        {
            AppMain.nnCopyMaterialList( null, srcobj.pMatPtrList, srcobj.nMaterial, 0U );
        }
        if ( dstobj != null )
        {
            dstobj.pVtxListPtrList = AppMain.New<AppMain.NNS_VTXLISTPTR>( srcobj.nVtxList );
            AppMain.nnBindBufferVertexListGL( dstobj.pVtxListPtrList, srcobj.pVtxListPtrList, srcobj.nVtxList, flag );
        }
        else
        {
            AppMain.nnBindBufferVertexListGL( null, srcobj.pVtxListPtrList, srcobj.nVtxList, flag );
        }
        if ( dstobj != null )
        {
            dstobj.pPrimListPtrList = AppMain.New<AppMain.NNS_PRIMLISTPTR>( srcobj.nPrimList );
            AppMain.nnBindBufferPrimitiveListGL( dstobj.pPrimListPtrList, srcobj.pPrimListPtrList, srcobj.nPrimList, flag );
        }
        else
        {
            AppMain.nnBindBufferPrimitiveListGL( null, srcobj.pPrimListPtrList, srcobj.nPrimList, flag );
        }
        if ( dstobj != null )
        {
            dstobj.pNodeList = new AppMain.NNS_NODE[srcobj.nNode];
            for ( int i = 0; i < srcobj.nNode; i++ )
            {
                dstobj.pNodeList[i] = new AppMain.NNS_NODE( srcobj.pNodeList[i] );
            }
        }
        if ( dstobj != null )
        {
            dstobj.pSubobjList = AppMain.New<AppMain.NNS_SUBOBJ>( srcobj.nSubobj );
            AppMain.nnCopySubobjList( dstobj.pSubobjList, srcobj.pSubobjList, srcobj.nSubobj, flag );
        }
        else
        {
            AppMain.nnCopySubobjList( null, srcobj.pSubobjList, srcobj.nSubobj, flag );
        }
        return 0U;
    }

    // Token: 0x06000A00 RID: 2560 RVA: 0x0005A3B0 File Offset: 0x000585B0
    private void nnBindBufferObjectDirectGL( AppMain.NNS_OBJECT obj, uint flag )
    {
        if ( ( obj.fType & 65536U ) != 0U )
        {
            AppMain.NNM_ASSERT( 0, "You can not bind-buffer the common-vertex-format object.\n" );
            return;
        }
        if ( ( obj.fType & 64U ) != 0U && ( obj.fType & 128U ) == 0U )
        {
            flag |= 2U;
        }
        for ( int i = 0; i < obj.nVtxList; i++ )
        {
            AppMain.NNS_VTXLISTPTR nns_VTXLISTPTR = obj.pVtxListPtrList[i];
            if ( ( nns_VTXLISTPTR.fType & 1U ) != 0U )
            {
                AppMain.nnBindBufferVertexDescGL( ( AppMain.NNS_VTXLIST_GL_DESC )nns_VTXLISTPTR.pVtxList, flag );
                nns_VTXLISTPTR.fType |= 16U;
            }
            else
            {
                AppMain.NNM_ASSERT( 0, "Unknown vertex foramt.\n" );
            }
        }
        for ( int i = 0; i < obj.nPrimList; i++ )
        {
            AppMain.NNS_PRIMLISTPTR nns_PRIMLISTPTR = obj.pPrimListPtrList[i];
            if ( ( nns_PRIMLISTPTR.fType & 1U ) != 0U )
            {
                AppMain.nnBindBufferPrimitiveDescGL( ( AppMain.NNS_PRIMLIST_GL_DESC )nns_PRIMLISTPTR.pPrimList, flag );
                nns_PRIMLISTPTR.fType |= 2U;
            }
            else
            {
                AppMain.NNM_ASSERT( 0, "Unknown primitive foramt.\n" );
            }
        }
        obj.fType |= 16777216U;
    }

    // Token: 0x06000A01 RID: 2561 RVA: 0x0005A4A8 File Offset: 0x000586A8
    private static void nnDeleteBufferObjectGL( AppMain.NNS_OBJECT obj )
    {
        for ( int i = 0; i < obj.nVtxList; i++ )
        {
            AppMain.NNS_VTXLISTPTR nns_VTXLISTPTR = obj.pVtxListPtrList[i];
            if ( ( nns_VTXLISTPTR.fType & 16U ) != 0U )
            {
                AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = (AppMain.NNS_VTXLIST_GL_DESC)nns_VTXLISTPTR.pVtxList;
                OpenGL.glDeleteBuffers( 1, new uint[]
                {
                    nns_VTXLIST_GL_DESC.BufferName
                } );
            }
        }
        for ( int i = 0; i < obj.nPrimList; i++ )
        {
            AppMain.NNS_PRIMLISTPTR nns_PRIMLISTPTR = obj.pPrimListPtrList[i];
            if ( ( nns_PRIMLISTPTR.fType & 2U ) != 0U )
            {
                AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC = (AppMain.NNS_PRIMLIST_GL_DESC)nns_PRIMLISTPTR.pPrimList;
                OpenGL.glDeleteBuffers( 1, new uint[]
                {
                    nns_PRIMLIST_GL_DESC.BufferName
                } );
            }
        }
    }

    // Token: 0x06000A02 RID: 2562 RVA: 0x0005A54C File Offset: 0x0005874C
    public static void nnSetUpMatrixStack( ref AppMain.NNS_MATRIXSTACK mstk, uint size )
    {
        mstk = new AppMain.NNS_MATRIXSTACK( size );
        AppMain.NNS_MATRIX matrix = AppMain.NNS_MATRIX.CreateIdentity();
        mstk.push( matrix );
    }

    // Token: 0x06000A03 RID: 2563 RVA: 0x0005A570 File Offset: 0x00058770
    public static void nnClearMatrixStack( AppMain.NNS_MATRIXSTACK mstk )
    {
        mstk.clear();
        AppMain.NNS_MATRIX matrix = AppMain.NNS_MATRIX.CreateIdentity();
        mstk.push( matrix );
    }

    // Token: 0x06000A04 RID: 2564 RVA: 0x0005A590 File Offset: 0x00058790
    public static AppMain.NNS_MATRIX nnGetCurrentMatrix( AppMain.NNS_MATRIXSTACK mstk )
    {
        return mstk.get();
    }

    // Token: 0x06000A05 RID: 2565 RVA: 0x0005A598 File Offset: 0x00058798
    public static void nnSetCurrentMatrix( AppMain.NNS_MATRIXSTACK mstk, AppMain.NNS_MATRIX mtx )
    {
        mstk.set( mtx );
    }

    // Token: 0x06000A06 RID: 2566 RVA: 0x0005A5A4 File Offset: 0x000587A4
    public static void nnPushMatrix( AppMain.NNS_MATRIXSTACK mstk, ref AppMain.SNNS_MATRIX mtx )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.nnmatrixstack_mtx_pool.Alloc();
        AppMain.nnCopyMatrix( nns_MATRIX, ref mtx );
        mstk.push( nns_MATRIX );
    }

    // Token: 0x06000A07 RID: 2567 RVA: 0x0005A5CC File Offset: 0x000587CC
    public static void nnPushMatrix( AppMain.NNS_MATRIXSTACK mstk, AppMain.NNS_MATRIX mtx )
    {
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.nnmatrixstack_mtx_pool.Alloc();
        if ( mtx == null )
        {
            nns_MATRIX.Assign( mstk.get() );
        }
        else
        {
            nns_MATRIX.Assign( mtx );
        }
        mstk.push( nns_MATRIX );
    }

    // Token: 0x06000A08 RID: 2568 RVA: 0x0005A605 File Offset: 0x00058805
    public static void nnPushMatrix( AppMain.NNS_MATRIXSTACK mstk )
    {
        AppMain.nnPushMatrix( mstk, null );
    }

    // Token: 0x06000A09 RID: 2569 RVA: 0x0005A60E File Offset: 0x0005880E
    public static void nnPopMatrix( AppMain.NNS_MATRIXSTACK mstk )
    {
        AppMain.nnmatrixstack_mtx_pool.Release( mstk.pop() );
    }

    // Token: 0x06000A0A RID: 2570 RVA: 0x0005A620 File Offset: 0x00058820
    private void nnInitLight()
    {
        AppMain.nnlight.nngLight.AmbientColor.r = 0.2f;
        AppMain.nnlight.nngLight.AmbientColor.g = 0.2f;
        AppMain.nnlight.nngLight.AmbientColor.b = 0.2f;
        AppMain.nnlight.nngLight.AmbientColor.a = 1f;
        for ( int i = 0; i < AppMain.NNE_LIGHT_MAX; i++ )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[i];
            nns_GL_LIGHT_DATA.bEnable = 0;
            nns_GL_LIGHT_DATA.fType = 1U;
            nns_GL_LIGHT_DATA.Intensity = 1f;
            nns_GL_LIGHT_DATA.Ambient.r = 0f;
            nns_GL_LIGHT_DATA.Ambient.g = 0f;
            nns_GL_LIGHT_DATA.Ambient.b = 0f;
            nns_GL_LIGHT_DATA.Ambient.a = 1f;
            nns_GL_LIGHT_DATA.Diffuse.r = 1f;
            nns_GL_LIGHT_DATA.Diffuse.g = 1f;
            nns_GL_LIGHT_DATA.Diffuse.b = 1f;
            nns_GL_LIGHT_DATA.Diffuse.a = 1f;
            nns_GL_LIGHT_DATA.Specular.r = 1f;
            nns_GL_LIGHT_DATA.Specular.g = 1f;
            nns_GL_LIGHT_DATA.Specular.b = 1f;
            nns_GL_LIGHT_DATA.Specular.a = 1f;
            nns_GL_LIGHT_DATA.Direction.x = 0f;
            nns_GL_LIGHT_DATA.Direction.y = 0f;
            nns_GL_LIGHT_DATA.Direction.z = -1f;
            nns_GL_LIGHT_DATA.Position.x = 0f;
            nns_GL_LIGHT_DATA.Position.y = 0f;
            nns_GL_LIGHT_DATA.Position.z = 0f;
            nns_GL_LIGHT_DATA.Position.w = 1f;
            nns_GL_LIGHT_DATA.Target.x = 0f;
            nns_GL_LIGHT_DATA.Target.y = 0f;
            nns_GL_LIGHT_DATA.Target.z = 0f;
            nns_GL_LIGHT_DATA.RotType = 0;
            nns_GL_LIGHT_DATA.Rotation.x = 0;
            nns_GL_LIGHT_DATA.Rotation.y = 0;
            nns_GL_LIGHT_DATA.Rotation.z = 0;
            nns_GL_LIGHT_DATA.InnerAngle = 16384;
            nns_GL_LIGHT_DATA.OuterAngle = 16384;
            nns_GL_LIGHT_DATA.InnerRange = 1E+12f;
            nns_GL_LIGHT_DATA.OuterRange = 1E+12f;
            nns_GL_LIGHT_DATA.FallOffStart = 1E+12f;
            nns_GL_LIGHT_DATA.FallOffEnd = 1E+12f;
            nns_GL_LIGHT_DATA.ConstantAttenuation = 1f;
            nns_GL_LIGHT_DATA.LinearAttenuation = 0f;
            nns_GL_LIGHT_DATA.QuadraticAttenuation = 0f;
        }
    }

    // Token: 0x06000A0B RID: 2571 RVA: 0x0005A8A8 File Offset: 0x00058AA8
    private static void nnSetLightSwitch( int no, int on_off )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.bEnable = on_off;
        }
    }

    // Token: 0x06000A0C RID: 2572 RVA: 0x0005A8D4 File Offset: 0x00058AD4
    private static void nnSetLightType( int no, uint type )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.fType = type;
        }
    }

    // Token: 0x06000A0D RID: 2573 RVA: 0x0005A900 File Offset: 0x00058B00
    private static void nnSetLightAmbientGL( int no, float r, float g, float b )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Ambient.r = r;
            nns_GL_LIGHT_DATA.Ambient.g = g;
            nns_GL_LIGHT_DATA.Ambient.b = b;
        }
    }

    // Token: 0x06000A0E RID: 2574 RVA: 0x0005A948 File Offset: 0x00058B48
    private static void nnSetLightDiffuseGL( int no, float r, float g, float b )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Diffuse.r = r;
            nns_GL_LIGHT_DATA.Diffuse.g = g;
            nns_GL_LIGHT_DATA.Diffuse.b = b;
        }
    }

    // Token: 0x06000A0F RID: 2575 RVA: 0x0005A990 File Offset: 0x00058B90
    private static void nnSetLightSpecularGL( int no, float r, float g, float b )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Specular.r = r;
            nns_GL_LIGHT_DATA.Specular.g = g;
            nns_GL_LIGHT_DATA.Specular.b = b;
        }
    }

    // Token: 0x06000A10 RID: 2576 RVA: 0x0005A9D6 File Offset: 0x00058BD6
    private static void nnSetLightColor( int no, float r, float g, float b )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.nnSetLightDiffuseGL( no, r, g, b );
            AppMain.nnSetLightSpecularGL( no, r, g, b );
        }
    }

    // Token: 0x06000A11 RID: 2577 RVA: 0x0005A9F4 File Offset: 0x00058BF4
    private static void nnSetLightAlpha( int no, float a )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Diffuse.a = a;
        }
    }

    // Token: 0x06000A12 RID: 2578 RVA: 0x0005AA24 File Offset: 0x00058C24
    private static void nnSetLightDirection( int no, float x, float y, float z )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Direction.x = x;
            nns_GL_LIGHT_DATA.Direction.y = y;
            nns_GL_LIGHT_DATA.Direction.z = z;
        }
    }

    // Token: 0x06000A13 RID: 2579 RVA: 0x0005AA6C File Offset: 0x00058C6C
    private static void nnSetLightPosition( int no, float x, float y, float z )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Position.x = x;
            nns_GL_LIGHT_DATA.Position.y = y;
            nns_GL_LIGHT_DATA.Position.z = z;
            nns_GL_LIGHT_DATA.Position.w = 1f;
        }
    }

    // Token: 0x06000A14 RID: 2580 RVA: 0x0005AAC4 File Offset: 0x00058CC4
    private static void nnSetLightTarget( int no, float x, float y, float z )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Target.x = x;
            nns_GL_LIGHT_DATA.Target.y = y;
            nns_GL_LIGHT_DATA.Target.z = z;
        }
    }

    // Token: 0x06000A15 RID: 2581 RVA: 0x0005AB0C File Offset: 0x00058D0C
    private static void nnSetLightRotation( int no, int rottype, int rotx, int roty, int rotz )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.RotType = rottype;
            nns_GL_LIGHT_DATA.Rotation.x = rotx;
            nns_GL_LIGHT_DATA.Rotation.y = roty;
            nns_GL_LIGHT_DATA.Rotation.z = rotz;
            float num;
            float num2;
            AppMain.nnSinCos( rotx, out num, out num2 );
            float num3;
            float num4;
            AppMain.nnSinCos( roty, out num3, out num4 );
            float num5;
            float num6;
            AppMain.nnSinCos( rotz, out num5, out num6 );
            switch ( rottype )
            {
                case 1:
                    nns_GL_LIGHT_DATA.Direction.x = -num4 * num5 * num - num3 * num2;
                    nns_GL_LIGHT_DATA.Direction.y = num6 * num;
                    nns_GL_LIGHT_DATA.Direction.z = num3 * num5 * num - num4 * num2;
                    return;
                case 4:
                    nns_GL_LIGHT_DATA.Direction.x = -num3 * num2;
                    nns_GL_LIGHT_DATA.Direction.y = num;
                    nns_GL_LIGHT_DATA.Direction.z = -num4 * num2;
                    return;
            }
            nns_GL_LIGHT_DATA.Direction.x = -num6 * num3 * num2 - num5 * num;
            nns_GL_LIGHT_DATA.Direction.y = -num5 * num3 * num2 + num6 * num;
            nns_GL_LIGHT_DATA.Direction.z = -num4 * num2;
        }
    }

    // Token: 0x06000A16 RID: 2582 RVA: 0x0005AC46 File Offset: 0x00058E46
    public static void nnSetAmbientColor( float r, float g, float b )
    {
        AppMain.nnlight.nngLight.AmbientColor.r = r;
        AppMain.nnlight.nngLight.AmbientColor.g = g;
        AppMain.nnlight.nngLight.AmbientColor.b = b;
    }

    // Token: 0x06000A17 RID: 2583 RVA: 0x0005AC78 File Offset: 0x00058E78
    public static void nnSetLightIntensity( int no, float intensity )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.Intensity = intensity;
        }
    }

    // Token: 0x06000A18 RID: 2584 RVA: 0x0005ACA4 File Offset: 0x00058EA4
    public static void nnSetLightAngle( int no, int innerangle, int outerangle )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.InnerAngle = innerangle;
            nns_GL_LIGHT_DATA.OuterAngle = outerangle;
            nns_GL_LIGHT_DATA.SpotExponent = 0f;
            nns_GL_LIGHT_DATA.SpotCutoff = AppMain.NNM_A32toDEG( outerangle );
        }
    }

    // Token: 0x06000A19 RID: 2585 RVA: 0x0005ACEC File Offset: 0x00058EEC
    public static void nnSetLightSpotEffectGL( int no, float exp, float cutoff )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.SpotExponent = exp;
            nns_GL_LIGHT_DATA.SpotCutoff = cutoff;
        }
    }

    // Token: 0x06000A1A RID: 2586 RVA: 0x0005AD1C File Offset: 0x00058F1C
    public static void nnSetLightRange( int no, float innerrange, float outerrange )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.InnerRange = innerrange;
            nns_GL_LIGHT_DATA.OuterRange = outerrange;
        }
    }

    // Token: 0x06000A1B RID: 2587 RVA: 0x0005AD4C File Offset: 0x00058F4C
    public static void nnSetLightFallOff( int no, float falloffstart, float falloffend )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.FallOffStart = falloffstart;
            nns_GL_LIGHT_DATA.FallOffEnd = falloffend;
            nns_GL_LIGHT_DATA.ConstantAttenuation = 1f;
            nns_GL_LIGHT_DATA.LinearAttenuation = 0f;
            if ( falloffstart > 1E-12f )
            {
                nns_GL_LIGHT_DATA.QuadraticAttenuation = 1f / ( falloffstart * falloffstart );
                return;
            }
            nns_GL_LIGHT_DATA.QuadraticAttenuation = 1E+12f;
        }
    }

    // Token: 0x06000A1C RID: 2588 RVA: 0x0005ADB8 File Offset: 0x00058FB8
    public static void nnSetLightAttenuationGL( int no, float cnst, float lin, float quad )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            nns_GL_LIGHT_DATA.ConstantAttenuation = cnst;
            nns_GL_LIGHT_DATA.LinearAttenuation = lin;
            nns_GL_LIGHT_DATA.QuadraticAttenuation = quad;
        }
    }

    // Token: 0x06000A1D RID: 2589 RVA: 0x0005ADEF File Offset: 0x00058FEF
    public static void nnSetLightMatrix( AppMain.NNS_MATRIX mtx )
    {
        if ( mtx != null )
        {
            AppMain.nnCopyMatrix( AppMain.nnlight.nngLightMtx, mtx );
            return;
        }
        AppMain.nnMakeUnitMatrix( AppMain.nnlight.nngLightMtx );
    }

    // Token: 0x06000A1E RID: 2590 RVA: 0x0005AE0A File Offset: 0x0005900A
    public static void nnSetUpParallelLight( AppMain.NNS_LIGHT_PARALLEL light, ref AppMain.NNS_RGBA color, float inten, AppMain.NNS_VECTOR dir )
    {
        light.Color = color;
        light.Intensity = inten;
        light.Direction.Assign( dir );
    }

    // Token: 0x06000A1F RID: 2591 RVA: 0x0005AE2F File Offset: 0x0005902F
    public static void nnSetUpPointLight( AppMain.NNS_LIGHT_POINT light, ref AppMain.NNS_RGBA color, float inten, AppMain.NNS_VECTOR pos, float falloffstart, float falloffend )
    {
        light.Color = color;
        light.Intensity = inten;
        light.Position.Assign( pos );
        light.FallOffStart = falloffstart;
        light.FallOffEnd = falloffend;
    }

    // Token: 0x06000A20 RID: 2592 RVA: 0x0005AE68 File Offset: 0x00059068
    public static void nnSetUpTargetSpotLight( AppMain.NNS_LIGHT_TARGET_SPOT light, ref AppMain.NNS_RGBA color, float inten, AppMain.NNS_VECTOR pos, AppMain.NNS_VECTOR target, int innerangle, int outerangle, float falloffstart, float falloffend )
    {
        light.Color = color;
        light.Intensity = inten;
        light.Position.Assign( pos );
        light.Target.Assign( target );
        light.InnerAngle = innerangle;
        light.OuterAngle = outerangle;
        light.FallOffStart = falloffstart;
        light.FallOffEnd = falloffend;
    }

    // Token: 0x06000A21 RID: 2593 RVA: 0x0005AECC File Offset: 0x000590CC
    public static void nnSetUpRotationSpotLight( AppMain.NNS_LIGHT_ROTATION_SPOT light, ref AppMain.NNS_RGBA color, float inten, AppMain.NNS_VECTOR pos, int rottype, AppMain.NNS_ROTATE_A32 rotation, int innerangle, int outerangle, float falloffstart, float falloffend )
    {
        light.Color = color;
        light.Intensity = inten;
        light.Position.Assign( pos );
        light.RotType = rottype;
        light.Rotation = rotation;
        light.InnerAngle = innerangle;
        light.OuterAngle = outerangle;
        light.FallOffStart = falloffstart;
        light.FallOffEnd = falloffend;
    }

    // Token: 0x06000A22 RID: 2594 RVA: 0x0005AF34 File Offset: 0x00059134
    public static void nnSetUpTargetDirectionalLight( AppMain.NNS_LIGHT_TARGET_DIRECTIONAL light, ref AppMain.NNS_RGBA color, float inten, AppMain.NNS_VECTOR pos, AppMain.NNS_VECTOR target, float innerrange, float outerrange, float falloffstart, float falloffend )
    {
        light.Color = color;
        light.Intensity = inten;
        light.Position.Assign( pos );
        light.Target.Assign( target );
        light.InnerRange = innerrange;
        light.OuterRange = outerrange;
        light.FallOffStart = falloffstart;
        light.FallOffEnd = falloffend;
    }

    // Token: 0x06000A23 RID: 2595 RVA: 0x0005AF90 File Offset: 0x00059190
    public static void nnSetUpRotationDirectionalLight( AppMain.NNS_LIGHT_ROTATION_DIRECTIONAL light, ref AppMain.NNS_RGBA color, float inten, AppMain.NNS_VECTOR pos, int rottype, AppMain.NNS_ROTATE_A32 rotation, float innerrange, float outerrange, float falloffstart, float falloffend )
    {
        light.Color = color;
        light.Intensity = inten;
        light.Position.Assign( pos );
        light.RotType = rottype;
        light.Rotation = rotation;
        light.InnerRange = innerrange;
        light.OuterRange = outerrange;
        light.FallOffStart = falloffstart;
        light.FallOffEnd = falloffend;
    }

    // Token: 0x06000A24 RID: 2596 RVA: 0x0005AFF8 File Offset: 0x000591F8
    public static void nnSetUpStandardLightGL( AppMain.NNS_LIGHT_STANDARD_GL light, ref AppMain.NNS_RGBA ambient, ref AppMain.NNS_RGBA diffuse, ref AppMain.NNS_RGBA specular, AppMain.NNS_VECTOR4D position, AppMain.NNS_VECTOR direction, float expornent, float cutoff, float cnstattn, float linattn, float quadattn )
    {
        light.Ambient = ambient;
        light.Diffuse = diffuse;
        light.Specular = specular;
        light.Position.Assign( position );
        light.SpotDirection.Assign( direction );
        light.SpotExponent = expornent;
        light.SpotCutoff = cutoff;
        light.ConstantAttenuation = cnstattn;
        light.LinearAttenuation = linattn;
        light.QuadraticAttenuation = quadattn;
    }

    // Token: 0x06000A25 RID: 2597 RVA: 0x0005B06C File Offset: 0x0005926C
    private static void nnSetLight( int no, object light, uint type )
    {
        if ( no < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[no];
            AppMain.nnSetLightType( no, type );
            uint num = type & 65599U;
            if ( num <= 8U )
            {
                switch ( num )
                {
                    case 1U:
                        {
                            AppMain.NNS_LIGHT_PARALLEL nns_LIGHT_PARALLEL = (AppMain.NNS_LIGHT_PARALLEL)((AppMain.NNS_LIGHT_TARGET_DIRECTIONAL)light);
                            AppMain.nnSetLightColor( no, nns_LIGHT_PARALLEL.Color.r, nns_LIGHT_PARALLEL.Color.g, nns_LIGHT_PARALLEL.Color.b );
                            AppMain.nnSetLightIntensity( no, nns_LIGHT_PARALLEL.Intensity );
                            AppMain.nnSetLightDirection( no, nns_LIGHT_PARALLEL.Direction.x, nns_LIGHT_PARALLEL.Direction.y, nns_LIGHT_PARALLEL.Direction.z );
                            AppMain.nnSetLightAmbientGL( no, 0f, 0f, 0f );
                            return;
                        }
                    case 2U:
                        {
                            AppMain.NNS_LIGHT_POINT nns_LIGHT_POINT = (AppMain.NNS_LIGHT_POINT)((AppMain.NNS_LIGHT_TARGET_DIRECTIONAL)light);
                            AppMain.nnSetLightColor( no, nns_LIGHT_POINT.Color.r, nns_LIGHT_POINT.Color.g, nns_LIGHT_POINT.Color.b );
                            AppMain.nnSetLightIntensity( no, nns_LIGHT_POINT.Intensity );
                            AppMain.nnSetLightPosition( no, nns_LIGHT_POINT.Position.x, nns_LIGHT_POINT.Position.y, nns_LIGHT_POINT.Position.z );
                            AppMain.nnSetLightFallOff( no, nns_LIGHT_POINT.FallOffStart, nns_LIGHT_POINT.FallOffEnd );
                            AppMain.nnSetLightAmbientGL( no, 0f, 0f, 0f );
                            return;
                        }
                    case 3U:
                        break;
                    case 4U:
                        {
                            AppMain.NNS_LIGHT_TARGET_SPOT nns_LIGHT_TARGET_SPOT = (AppMain.NNS_LIGHT_TARGET_SPOT)((AppMain.NNS_LIGHT_TARGET_DIRECTIONAL)light);
                            AppMain.nnSetLightColor( no, nns_LIGHT_TARGET_SPOT.Color.r, nns_LIGHT_TARGET_SPOT.Color.g, nns_LIGHT_TARGET_SPOT.Color.b );
                            AppMain.nnSetLightIntensity( no, nns_LIGHT_TARGET_SPOT.Intensity );
                            AppMain.nnSetLightPosition( no, nns_LIGHT_TARGET_SPOT.Position.x, nns_LIGHT_TARGET_SPOT.Position.y, nns_LIGHT_TARGET_SPOT.Position.z );
                            AppMain.nnSetLightTarget( no, nns_LIGHT_TARGET_SPOT.Target.x, nns_LIGHT_TARGET_SPOT.Target.y, nns_LIGHT_TARGET_SPOT.Target.z );
                            AppMain.nnSetLightAngle( no, nns_LIGHT_TARGET_SPOT.InnerAngle, nns_LIGHT_TARGET_SPOT.OuterAngle );
                            AppMain.nnSetLightFallOff( no, nns_LIGHT_TARGET_SPOT.FallOffStart, nns_LIGHT_TARGET_SPOT.FallOffEnd );
                            AppMain.nnSetLightAmbientGL( no, 0f, 0f, 0f );
                            return;
                        }
                    default:
                        {
                            if ( num != 8U )
                            {
                                return;
                            }
                            AppMain.NNS_LIGHT_ROTATION_SPOT nns_LIGHT_ROTATION_SPOT = (AppMain.NNS_LIGHT_ROTATION_SPOT)((AppMain.NNS_LIGHT_TARGET_DIRECTIONAL)light);
                            AppMain.nnSetLightColor( no, nns_LIGHT_ROTATION_SPOT.Color.r, nns_LIGHT_ROTATION_SPOT.Color.g, nns_LIGHT_ROTATION_SPOT.Color.b );
                            AppMain.nnSetLightIntensity( no, nns_LIGHT_ROTATION_SPOT.Intensity );
                            AppMain.nnSetLightPosition( no, nns_LIGHT_ROTATION_SPOT.Position.x, nns_LIGHT_ROTATION_SPOT.Position.y, nns_LIGHT_ROTATION_SPOT.Position.z );
                            AppMain.nnSetLightRotation( no, nns_LIGHT_ROTATION_SPOT.RotType, nns_LIGHT_ROTATION_SPOT.Rotation.x, nns_LIGHT_ROTATION_SPOT.Rotation.y, nns_LIGHT_ROTATION_SPOT.Rotation.z );
                            AppMain.nnSetLightAngle( no, nns_LIGHT_ROTATION_SPOT.InnerAngle, nns_LIGHT_ROTATION_SPOT.OuterAngle );
                            AppMain.nnSetLightFallOff( no, nns_LIGHT_ROTATION_SPOT.FallOffStart, nns_LIGHT_ROTATION_SPOT.FallOffEnd );
                            AppMain.nnSetLightAmbientGL( no, 0f, 0f, 0f );
                            return;
                        }
                }
            }
            else
            {
                if ( num == 16U )
                {
                    AppMain.mppAssertNotImpl();
                    return;
                }
                if ( num == 32U )
                {
                    AppMain.mppAssertNotImpl();
                    return;
                }
                if ( num != 65536U )
                {
                    return;
                }
                AppMain.mppAssertNotImpl();
            }
        }
    }

    // Token: 0x06000A26 RID: 2598 RVA: 0x0005B3C4 File Offset: 0x000595C4
    private static void nnPutLightSettings()
    {
        OpenGL.glMatrixMode( 5888U );
        Matrix matrix = (Matrix)AppMain.nnlight.nngLightMtx;
        OpenGL.glLoadMatrixf( ref matrix );
        OpenGL.glArray4f param;
        param.f0 = AppMain.nnlight.nngLight.AmbientColor.r;
        param.f1 = AppMain.nnlight.nngLight.AmbientColor.g;
        param.f2 = AppMain.nnlight.nngLight.AmbientColor.b;
        param.f3 = AppMain.nnlight.nngLight.AmbientColor.a;
        OpenGL.glLightModelfv( 2899U, param );
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        int i;
        for ( i = 0; i < AppMain.NNE_LIGHT_MAX; i++ )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA = AppMain.nnlight.nngLight.LightData[i];
            if ( nns_GL_LIGHT_DATA.bEnable != 0 )
            {
                uint fType = nns_GL_LIGHT_DATA.fType;
                if ( fType <= 8U )
                {
                    switch ( fType )
                    {
                        case 1U:
                            goto IL_E4;
                        case 2U:
                            if ( num2 < 4 )
                            {
                                num2++;
                                goto IL_127;
                            }
                            nns_GL_LIGHT_DATA.bEnable = 0;
                            goto IL_127;
                        case 3U:
                            goto IL_127;
                        case 4U:
                            break;
                        default:
                            if ( fType != 8U )
                            {
                                goto IL_127;
                            }
                            break;
                    }
                    if ( num3 < 4 )
                    {
                        num3++;
                        goto IL_127;
                    }
                    nns_GL_LIGHT_DATA.bEnable = 0;
                    goto IL_127;
                }
                else if ( fType != 16U && fType != 32U )
                {
                    goto IL_127;
                }
                IL_E4:
                if ( num < 4 )
                {
                    num++;
                }
                else
                {
                    nns_GL_LIGHT_DATA.bEnable = 0;
                }
            }
            IL_127:;
        }
        AppMain.nnlight.nngNumParallelLight = num;
        AppMain.nnlight.nngNumPointLight = num2;
        AppMain.nnlight.nngNumSpotLight = num3;
        int num4 = -1;
        int num5 = -1;
        int num6 = -1;
        int num7 = -1;
        i = 0;
        int j = 0;
        while ( i < AppMain.NNE_LIGHT_MAX )
        {
            AppMain.NNS_GL_LIGHT_DATA nns_GL_LIGHT_DATA2 = AppMain.nnlight.nngLight.LightData[i];
            if ( 1 == nns_GL_LIGHT_DATA2.bEnable )
            {
                uint fType2 = nns_GL_LIGHT_DATA2.fType;
                uint num8;
                if ( fType2 <= 8U )
                {
                    switch ( fType2 )
                    {
                        case 1U:
                            goto IL_1B3;
                        case 2U:
                            num5++;
                            num8 = AppMain.NNM_GL_LIGHT( num + num5 );
                            goto IL_201;
                        case 3U:
                            goto IL_1E9;
                        case 4U:
                            break;
                        default:
                            if ( fType2 != 8U )
                            {
                                goto IL_1E9;
                            }
                            break;
                    }
                    num6++;
                    num8 = AppMain.NNM_GL_LIGHT( num + num2 + num6 );
                }
                else
                {
                    if ( fType2 == 16U || fType2 == 32U )
                    {
                        goto IL_1B3;
                    }
                    goto IL_1E9;
                }
                IL_201:
                OpenGL.glEnable( num8 );
                if ( nns_GL_LIGHT_DATA2.Intensity == 1f )
                {
                    OpenGL.glArray4f glArray4f;
                    glArray4f.f0 = nns_GL_LIGHT_DATA2.Ambient.r;
                    glArray4f.f1 = nns_GL_LIGHT_DATA2.Ambient.g;
                    glArray4f.f2 = nns_GL_LIGHT_DATA2.Ambient.b;
                    glArray4f.f3 = nns_GL_LIGHT_DATA2.Ambient.a;
                    OpenGL.glLightfv( num8, 4608U, ref glArray4f );
                    glArray4f.f0 = nns_GL_LIGHT_DATA2.Diffuse.r;
                    glArray4f.f1 = nns_GL_LIGHT_DATA2.Diffuse.g;
                    glArray4f.f2 = nns_GL_LIGHT_DATA2.Diffuse.b;
                    glArray4f.f3 = nns_GL_LIGHT_DATA2.Diffuse.a;
                    OpenGL.glLightfv( num8, 4609U, ref glArray4f );
                    glArray4f.f0 = nns_GL_LIGHT_DATA2.Specular.r;
                    glArray4f.f1 = nns_GL_LIGHT_DATA2.Specular.g;
                    glArray4f.f2 = nns_GL_LIGHT_DATA2.Specular.b;
                    glArray4f.f3 = nns_GL_LIGHT_DATA2.Specular.a;
                    OpenGL.glLightfv( num8, 4610U, ref glArray4f );
                }
                else
                {
                    float intensity = nns_GL_LIGHT_DATA2.Intensity;
                    OpenGL.glArray4f glArray4f2;
                    glArray4f2.f0 = nns_GL_LIGHT_DATA2.Ambient.r * intensity;
                    glArray4f2.f1 = nns_GL_LIGHT_DATA2.Ambient.g * intensity;
                    glArray4f2.f2 = nns_GL_LIGHT_DATA2.Ambient.b * intensity;
                    glArray4f2.f3 = nns_GL_LIGHT_DATA2.Ambient.a;
                    OpenGL.glLightfv( num8, 4608U, ref glArray4f2 );
                    glArray4f2.f0 = nns_GL_LIGHT_DATA2.Diffuse.r * intensity;
                    glArray4f2.f1 = nns_GL_LIGHT_DATA2.Diffuse.g * intensity;
                    glArray4f2.f2 = nns_GL_LIGHT_DATA2.Diffuse.b * intensity;
                    glArray4f2.f3 = nns_GL_LIGHT_DATA2.Diffuse.a;
                    OpenGL.glLightfv( num8, 4609U, ref glArray4f2 );
                    glArray4f2.f0 = nns_GL_LIGHT_DATA2.Specular.r * intensity;
                    glArray4f2.f1 = nns_GL_LIGHT_DATA2.Specular.g * intensity;
                    glArray4f2.f2 = nns_GL_LIGHT_DATA2.Specular.b * intensity;
                    glArray4f2.f3 = nns_GL_LIGHT_DATA2.Specular.a;
                    OpenGL.glLightfv( num8, 4610U, ref glArray4f2 );
                }
                uint fType3 = nns_GL_LIGHT_DATA2.fType;
                if ( fType3 == 1U )
                {
                    goto IL_47B;
                }
                if ( fType3 != 16U )
                {
                    if ( fType3 == 32U )
                    {
                        goto IL_47B;
                    }
                    OpenGL.glArray4f glArray4f3;
                    glArray4f3.f0 = nns_GL_LIGHT_DATA2.Position.x;
                    glArray4f3.f1 = nns_GL_LIGHT_DATA2.Position.y;
                    glArray4f3.f2 = nns_GL_LIGHT_DATA2.Position.z;
                    glArray4f3.f3 = nns_GL_LIGHT_DATA2.Position.w;
                    OpenGL.glLightfv( num8, 4611U, ref glArray4f3 );
                }
                else
                {
                    OpenGL.glArray4f glArray4f4;
                    glArray4f4.f0 = nns_GL_LIGHT_DATA2.Position.x - nns_GL_LIGHT_DATA2.Target.x;
                    glArray4f4.f1 = nns_GL_LIGHT_DATA2.Position.y - nns_GL_LIGHT_DATA2.Target.y;
                    glArray4f4.f2 = nns_GL_LIGHT_DATA2.Position.z - nns_GL_LIGHT_DATA2.Target.z;
                    glArray4f4.f3 = 0f;
                    AppMain.nnNormalizeVector( ref glArray4f4, ref glArray4f4 );
                    OpenGL.glLightfv( num8, 4611U, ref glArray4f4 );
                }
                IL_5B6:
                uint fType4 = nns_GL_LIGHT_DATA2.fType;
                if ( fType4 == 4U )
                {
                    OpenGL.glArray4f glArray4f5;
                    glArray4f5.f0 = nns_GL_LIGHT_DATA2.Target.x - nns_GL_LIGHT_DATA2.Position.x;
                    glArray4f5.f1 = nns_GL_LIGHT_DATA2.Target.y - nns_GL_LIGHT_DATA2.Position.y;
                    glArray4f5.f2 = nns_GL_LIGHT_DATA2.Target.z - nns_GL_LIGHT_DATA2.Position.z;
                    glArray4f5.f3 = 0f;
                    AppMain.nnNormalizeVector( ref glArray4f5, ref glArray4f5 );
                    OpenGL.glLightfv( num8, 4612U, ref glArray4f5 );
                }
                else
                {
                    OpenGL.glArray4f glArray4f6;
                    glArray4f6.f0 = nns_GL_LIGHT_DATA2.Direction.x;
                    glArray4f6.f1 = nns_GL_LIGHT_DATA2.Direction.y;
                    glArray4f6.f2 = nns_GL_LIGHT_DATA2.Direction.z;
                    glArray4f6.f3 = 0f;
                    OpenGL.glLightfv( num8, 4612U, ref glArray4f6 );
                }
                uint fType5 = nns_GL_LIGHT_DATA2.fType;
                if ( fType5 == 4U || fType5 == 8U || fType5 == 65536U )
                {
                    OpenGL.glLightf( num8, 4613U, nns_GL_LIGHT_DATA2.SpotExponent );
                    OpenGL.glLightf( num8, 4614U, nns_GL_LIGHT_DATA2.SpotCutoff );
                }
                else
                {
                    OpenGL.glLightf( num8, 4613U, 0f );
                    OpenGL.glLightf( num8, 4614U, 180f );
                }
                uint fType6 = nns_GL_LIGHT_DATA2.fType;
                switch ( fType6 )
                {
                    case 2U:
                    case 4U:
                        goto IL_734;
                    case 3U:
                        goto IL_772;
                    default:
                        if ( fType6 == 8U || fType6 == 65536U )
                        {
                            goto IL_734;
                        }
                        goto IL_772;
                }
                IL_7A5:
                uint fType7 = nns_GL_LIGHT_DATA2.fType;
                float num9;
                float num10;
                switch ( fType7 )
                {
                    case 2U:
                        AppMain.nnlight.nngPointLightFallOffEnd[num5] = nns_GL_LIGHT_DATA2.FallOffEnd;
                        num9 = nns_GL_LIGHT_DATA2.FallOffEnd - nns_GL_LIGHT_DATA2.FallOffStart;
                        num10 = ( ( num9 > 1E-12f ) ? ( 1f / num9 ) : 1E+12f );
                        AppMain.nnlight.nngPointLightFallOffScale[num5] = num10;
                        break;
                    case 3U:
                        break;
                    case 4U:
                        goto IL_814;
                    default:
                        if ( fType7 == 8U )
                        {
                            goto IL_814;
                        }
                        break;
                }
                IL_897:
                j++;
                goto IL_89B;
                IL_814:
                AppMain.nnlight.nngSpotLightFallOffEnd[num6] = nns_GL_LIGHT_DATA2.FallOffEnd;
                num9 = nns_GL_LIGHT_DATA2.FallOffEnd - nns_GL_LIGHT_DATA2.FallOffStart;
                num10 = ( ( num9 > 1E-12f ) ? ( 1f / num9 ) : 1E+12f );
                AppMain.nnlight.nngSpotLightFallOffScale[num6] = num10;
                num9 = AppMain.nnCos( nns_GL_LIGHT_DATA2.OuterAngle ) - AppMain.nnCos( nns_GL_LIGHT_DATA2.InnerAngle );
                num10 = ( ( num9 < 1E-12f ) ? ( 1f / num9 ) : -1E+12f );
                AppMain.nnlight.nngSpotLightAngleScale[num6] = num10;
                goto IL_897;
                IL_772:
                OpenGL.glLightf( num8, 4615U, 1f );
                OpenGL.glLightf( num8, 4616U, 0f );
                OpenGL.glLightf( num8, 4617U, 0f );
                goto IL_7A5;
                IL_734:
                OpenGL.glLightf( num8, 4615U, nns_GL_LIGHT_DATA2.ConstantAttenuation );
                OpenGL.glLightf( num8, 4616U, nns_GL_LIGHT_DATA2.LinearAttenuation );
                OpenGL.glLightf( num8, 4617U, nns_GL_LIGHT_DATA2.QuadraticAttenuation );
                goto IL_7A5;
                IL_47B:
                OpenGL.glArray4f glArray4f7;
                glArray4f7.f0 = -nns_GL_LIGHT_DATA2.Direction.x;
                glArray4f7.f1 = -nns_GL_LIGHT_DATA2.Direction.y;
                glArray4f7.f2 = -nns_GL_LIGHT_DATA2.Direction.z;
                glArray4f7.f3 = 0f;
                OpenGL.glLightfv( num8, 4611U, ref glArray4f7 );
                goto IL_5B6;
                IL_1B3:
                num4++;
                num8 = AppMain.NNM_GL_LIGHT( num4 );
                goto IL_201;
                IL_1E9:
                num7++;
                num8 = AppMain.NNM_GL_LIGHT( num + num2 + num3 + num7 );
                goto IL_201;
            }
            IL_89B:
            i++;
        }
        while ( j < AppMain.NNE_LIGHT_MAX )
        {
            OpenGL.glDisable( AppMain.NNM_GL_LIGHT( j ) );
            j++;
        }
    }

    // Token: 0x06000A27 RID: 2599 RVA: 0x0005BC94 File Offset: 0x00059E94
    private uint nnEstimateLightBufferSize( uint type )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000A28 RID: 2600 RVA: 0x0005BC9C File Offset: 0x00059E9C
    private void nnCalcMotionCameraScalar( AppMain.NNS_SUBMOTION submot, float frame, ref float val )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A29 RID: 2601 RVA: 0x0005BCA3 File Offset: 0x00059EA3
    private void nnCalcMotionCameraAngle( AppMain.NNS_SUBMOTION submot, float frame, ref int ang )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A2A RID: 2602 RVA: 0x0005BCAA File Offset: 0x00059EAA
    private void nnCalcMotionCameraXYZ( AppMain.NNS_SUBMOTION submot, float frame, AppMain.NNS_VECTOR xyz )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A2B RID: 2603 RVA: 0x0005BCB1 File Offset: 0x00059EB1
    private void nnCalcCameraMotionCore( AppMain.NNS_CAMERAPTR dstptr, AppMain.NNS_CAMERAPTR camptr, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A2C RID: 2604 RVA: 0x0005BCB8 File Offset: 0x00059EB8
    private void nnCalcCameraMotion( AppMain.NNS_CAMERAPTR dstptr, AppMain.NNS_CAMERAPTR camptr, AppMain.NNS_MOTION mot, float frame )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000A66 RID: 2662 RVA: 0x0005C7F6 File Offset: 0x0005A9F6
    private static void NNM_ASSERT( int iCond, string sText )
    {
    }

    // Token: 0x06000A67 RID: 2663 RVA: 0x0005C7F8 File Offset: 0x0005A9F8
    private static void NNM_ASSERT( uint iCond, string sText )
    {
    }

    // Token: 0x06000A68 RID: 2664 RVA: 0x0005C7FA File Offset: 0x0005A9FA
    private static void NNM_ASSERT( bool iCond, string sText )
    {
    }

    // Token: 0x06000D25 RID: 3365 RVA: 0x00074E98 File Offset: 0x00073098
    public static void nnSetUpTexlist( out AppMain.NNS_TEXLIST texlist, int num, ref object buf )
    {
        AppMain.NNS_TEXLIST nns_TEXLIST;
        texlist = ( nns_TEXLIST = new AppMain.NNS_TEXLIST() );
        buf = nns_TEXLIST;
        texlist.nTex = num;
        texlist.pTexInfoList = new AppMain.NNS_TEXINFO[num];
        for ( int i = 0; i < num; i++ )
        {
            texlist.pTexInfoList[i] = new AppMain.NNS_TEXINFO();
        }
    }

    // Token: 0x06000D26 RID: 3366 RVA: 0x00074EE0 File Offset: 0x000730E0
    public static uint nnEstimateTexlistSize( int num )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000D27 RID: 3367 RVA: 0x00074EE8 File Offset: 0x000730E8
    private static int nnSetTextureList( AppMain.NNS_TEXLIST pTexList )
    {
        AppMain.nngCurrentTextureList = pTexList;
        return 1;
    }

    // Token: 0x06000D28 RID: 3368 RVA: 0x00074EF1 File Offset: 0x000730F1
    public static int nnGetTextureList( out AppMain.NNS_TEXLIST pTexList )
    {
        pTexList = null;
        AppMain.mppAssertNotImpl();
        return 1;
    }

    // Token: 0x06000D29 RID: 3369 RVA: 0x00074EFC File Offset: 0x000730FC
    private static int nnSetTexInfo( int slot, AppMain.NNS_TEXINFO pTexInfo )
    {
        if ( slot >= AppMain.nngGLExtensions.max_texture_units )
        {
            return 1;
        }
        OpenGL.glActiveTexture( AppMain.NNM_GL_TEXTURE( slot ) );
        if ( pTexInfo != null )
        {
            OpenGL.glBindTexture( 3553U, pTexInfo.TexName );
        }
        if ( pTexInfo != null )
        {
            OpenGL.glEnable( 3553U );
        }
        else
        {
            OpenGL.glDisable( 3553U );
        }
        return 1;
    }

    // Token: 0x06000D2A RID: 3370 RVA: 0x00074F4B File Offset: 0x0007314B
    public static int nnSetTexture( int slot, AppMain.NNS_TEXLIST pTexList, int num )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D2B RID: 3371 RVA: 0x00074F54 File Offset: 0x00073154
    private static int nnSetTextureNum( int slot, int num )
    {
        if ( num >= 0 )
        {
            AppMain.NNS_TEXINFO[] pTexInfoList = AppMain.nngCurrentTextureList.pTexInfoList;
            return AppMain.nnSetTexInfo( slot, pTexInfoList[num] );
        }
        return AppMain.nnSetTexInfo( slot, null );
    }

    // Token: 0x06000D2C RID: 3372 RVA: 0x00074F84 File Offset: 0x00073184
    private void nnConfigureSystemGL( AppMain.NNS_CONFIG_GL config )
    {
        if ( AppMain.nnsystem_init != 1 )
        {
            AppMain.nnsystem_init = 1;
            this.nnInitCircumsphere();
        }
        AppMain.nngScreen.ax = 1f;
        AppMain.nngScreen.ay = 1f;
        AppMain.nngScreen.aspect = 1f;
        AppMain.nngScreen.dist = 500f;
        AppMain.nngScreen.xad = AppMain.nngScreen.ax * AppMain.nngScreen.dist;
        AppMain.nngScreen.yad = -( AppMain.nngScreen.ay * AppMain.nngScreen.dist );
        AppMain.nngScreen.ooxad = 1f / AppMain.nngScreen.xad;
        AppMain.nngScreen.ooyad = 1f / AppMain.nngScreen.yad;
        AppMain.nngScreen.w = ( float )config.WindowWidth;
        AppMain.nngScreen.h = ( float )config.WindowHeight;
        AppMain.nngScreen.cx = AppMain.nngScreen.w * 0.5f;
        AppMain.nngScreen.cy = AppMain.nngScreen.h * 0.5f;
        AppMain.nngClip2d.x0 = 0f;
        AppMain.nngClip2d.y0 = 0f;
        AppMain.nngClip2d.x1 = AppMain.nngScreen.w - 1f;
        AppMain.nngClip2d.y1 = AppMain.nngScreen.h - 1f;
        AppMain.nngClip2d.n_clip = 1f;
        AppMain.nngClip2d.f_clip = 10000f;
        AppMain.nngClip3d.x0 = AppMain.nngClip2d.x0 - AppMain.nngScreen.cx;
        AppMain.nngClip3d.y0 = AppMain.nngClip2d.y0 - AppMain.nngScreen.cy;
        AppMain.nngClip3d.x1 = AppMain.nngClip2d.x1 - AppMain.nngScreen.cx;
        AppMain.nngClip3d.y1 = AppMain.nngClip2d.y1 - AppMain.nngScreen.cy;
        AppMain.nngClip3d.n_clip = 1f;
        AppMain.nngClip3d.f_clip = 10000f;
    }

    // Token: 0x06000D2D RID: 3373 RVA: 0x000751B6 File Offset: 0x000733B6
    public static void nnSetProjection( AppMain.NNS_MATRIX mtx, int type )
    {
        AppMain.nngProjectionMatrix.Assign( mtx );
        AppMain.nngProjectionType = type;
        AppMain.nnSetClipPlane();
        AppMain.nnLoadProjectionMatrixGL( mtx );
    }

    // Token: 0x06000D2E RID: 3374 RVA: 0x000751D8 File Offset: 0x000733D8
    public static void nnLoadProjectionMatrixGL( AppMain.NNS_MATRIX mtx )
    {
        float m = mtx.M20;
        float m2 = mtx.M21;
        float m3 = mtx.M22;
        float m4 = mtx.M23;
        OpenGL.glMatrixMode( 5889U );
        Matrix matrix = (Matrix)mtx;
        OpenGL.glLoadMatrixf( ref matrix );
        mtx.M20 = m;
        mtx.M21 = m2;
        mtx.M22 = m3;
        mtx.M23 = m4;
    }

    // Token: 0x06000D2F RID: 3375 RVA: 0x00075236 File Offset: 0x00073436
    private void nnCalcMultiplyMatrices( AppMain.ArrayPointer<AppMain.NNS_MATRIX> dstlist, AppMain.NNS_MATRIX src, AppMain.ArrayPointer<AppMain.NNS_MATRIX> srclist, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D30 RID: 3376 RVA: 0x0007523D File Offset: 0x0007343D
    private void nnCalcMatrixPaletteMultiplyMatrix( AppMain.ArrayPointer<AppMain.NNS_MATRIX> dstpal, AppMain.NNS_MATRIX src, AppMain.ArrayPointer<AppMain.NNS_MATRIX> srcpal, int num )
    {
        this.nnCalcMultiplyMatrices( dstpal, src, srcpal, num );
    }

    // Token: 0x06000D31 RID: 3377 RVA: 0x0007524A File Offset: 0x0007344A
    private uint nnCalcShaderManageBufferSizeGL( int num )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000D32 RID: 3378 RVA: 0x00075252 File Offset: 0x00073452
    private void nnSetUpShaderConfigBasicGL( AppMain.NNS_SHADER_CONFIG config )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D33 RID: 3379 RVA: 0x00075259 File Offset: 0x00073459
    private void nnConfigureShaderGL( AppMain.NNS_SHADER_CONFIG config, object managebuffer, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D34 RID: 3380 RVA: 0x00075260 File Offset: 0x00073460
    private AppMain.NNS_SHADER_NAME nnGetShaderNameGL( AppMain.NNS_SHADER_PROFILE profile )
    {
        AppMain.NNS_SHADER_NAME result = new AppMain.NNS_SHADER_NAME();
        AppMain.mppAssertNotImpl();
        return result;
    }

    // Token: 0x06000D35 RID: 3381 RVA: 0x00075279 File Offset: 0x00073479
    private void nnGetShaderProfileGL( AppMain.NNS_SHADER_PROFILE profile, AppMain.NNS_SHADER_NAME Name )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D36 RID: 3382 RVA: 0x00075280 File Offset: 0x00073480
    private static int nnCompareShaderName( AppMain.NNS_SHADER_NAME lhs, AppMain.NNS_SHADER_NAME rhs )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D37 RID: 3383 RVA: 0x00075288 File Offset: 0x00073488
    private int nnRegistShaderNameGL( AppMain.NNS_SHADER_NAME Name )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D38 RID: 3384 RVA: 0x00075290 File Offset: 0x00073490
    private int nnRegistShaderProfileGL( AppMain.NNS_SHADER_PROFILE profile )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D39 RID: 3385 RVA: 0x00075298 File Offset: 0x00073498
    private static int nnGetTexCoord( uint fType )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D3A RID: 3386 RVA: 0x000752A0 File Offset: 0x000734A0
    private static int nnTexCoordIndex( int texcoord )
    {
        AppMain.mppAssertNotImpl();
        return texcoord;
    }

    // Token: 0x06000D3B RID: 3387 RVA: 0x000752A8 File Offset: 0x000734A8
    private void nnInitShaderProfileGL( AppMain.NNS_SHADER_PROFILE profile )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D3C RID: 3388 RVA: 0x000752AF File Offset: 0x000734AF
    private int nnSetupShaderProfile( AppMain.NNS_SHADER_PROFILE profile, AppMain.NNS_MATERIALPTR pMat, AppMain.NNS_VTXLISTPTR pVtxListPtr, uint flag )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D3D RID: 3389 RVA: 0x000752B7 File Offset: 0x000734B7
    private int nnRegistObjectShaderProfilesGL( AppMain.NNS_OBJECT obj, uint flag )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D3E RID: 3390 RVA: 0x000752BF File Offset: 0x000734BF
    private int nnGetCurrentShaderProfileNumberGL()
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D3F RID: 3391 RVA: 0x000752C7 File Offset: 0x000734C7
    private void nnGetShaderProfileOneGL( AppMain.NNS_SHADER_PROFILE profile, int idx )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D40 RID: 3392 RVA: 0x000752D0 File Offset: 0x000734D0
    private AppMain.NNS_SHADER_NAME nnGetShaderNameListGL()
    {
        AppMain.mppAssertNotImpl();
        return new AppMain.NNS_SHADER_NAME();
    }

    // Token: 0x06000D41 RID: 3393 RVA: 0x000752E9 File Offset: 0x000734E9
    private void nnClearShaderProfilesGL()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D42 RID: 3394 RVA: 0x000752F0 File Offset: 0x000734F0
    private uint nnCalcBuildShaderWorkBufferSizeGL( uint vtxshadersize, uint fragshadersize )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000D43 RID: 3395 RVA: 0x000752F8 File Offset: 0x000734F8
    private static int nnCompareShaderManager( object elem1, object elem2 )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D44 RID: 3396 RVA: 0x00075300 File Offset: 0x00073500
    private int nnGetUnbuildShaderProfileNumberGL()
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D45 RID: 3397 RVA: 0x00075308 File Offset: 0x00073508
    private int nnGetUnbuildShaderProfileOneGL( AppMain.NNS_SHADER_PROFILE profile )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06000D46 RID: 3398 RVA: 0x00075310 File Offset: 0x00073510
    private void nnRegistCompiledShaderProfileGL( AppMain.NNS_COMPILED_SHADER_PROFILE compiledShader, AppMain.NNS_SHADER_PROFILE profile )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D47 RID: 3399 RVA: 0x00075317 File Offset: 0x00073517
    private void nnBindVertexAttributeGL( uint program )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D48 RID: 3400 RVA: 0x0007531E File Offset: 0x0007351E
    private uint nnGetErrorVertexShaderObjectGL()
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000D49 RID: 3401 RVA: 0x00075326 File Offset: 0x00073526
    private uint nnGetErrorFragmentShaderObjectGL()
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000D4A RID: 3402 RVA: 0x0007532E File Offset: 0x0007352E
    private uint nnGetErrorShaderProgramObjectGL()
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000D4B RID: 3403 RVA: 0x00075336 File Offset: 0x00073536
    private void nnReleaseShaderGL()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D4C RID: 3404 RVA: 0x0007533D File Offset: 0x0007353D
    private static AppMain.NNS_SHADER_MANAGER nnSearchShaderManager( AppMain.NNS_SHADER_NAME name )
    {
        AppMain.mppAssertNotImpl();
        return null;
    }

    // Token: 0x06000D4D RID: 3405 RVA: 0x00075345 File Offset: 0x00073545
    private void nnPutColorShader( AppMain.NNS_DRAWCALLBACK_VAL val )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D4E RID: 3406 RVA: 0x0007534C File Offset: 0x0007354C
    private static void nnBindFixedShaderGL()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D4F RID: 3407 RVA: 0x00075353 File Offset: 0x00073553
    private void nnBindPrintShaderGL()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D50 RID: 3408 RVA: 0x0007535A File Offset: 0x0007355A
    private void nnRegistPrimitive2DShaderGL( int bTexture )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D51 RID: 3409 RVA: 0x00075361 File Offset: 0x00073561
    private void nnRegistPrimitive3DShaderGL( int bLighting, int bTexture, int texcoord )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D52 RID: 3410 RVA: 0x00075368 File Offset: 0x00073568
    private static void nnBindPrimitive2DShaderGL( int bTexture )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D53 RID: 3411 RVA: 0x0007536F File Offset: 0x0007356F
    private void nnBindPrimitive3DShaderGL( int bLighting, int bTexture, int texcoord )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D54 RID: 3412 RVA: 0x00075376 File Offset: 0x00073576
    private static void nnRegistDefaultShader()
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D55 RID: 3413 RVA: 0x0007537D File Offset: 0x0007357D
    private void nnSetUserUniformGL( int idx, float x, float y, float z, float w )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D56 RID: 3414 RVA: 0x00075384 File Offset: 0x00073584
    private void nnPutUserUniformGL( AppMain.NNS_DRAWCALLBACK_VAL val )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000D57 RID: 3415 RVA: 0x0007538B File Offset: 0x0007358B
    private static void nnSetFogSwitch( bool on_off )
    {
        AppMain.nngFogSwitch = on_off;
    }

    // Token: 0x06000D58 RID: 3416 RVA: 0x00075393 File Offset: 0x00073593
    private bool nnGetFogSwitch()
    {
        AppMain.mppAssertNotImpl();
        return AppMain.nngFogSwitch;
    }

    // Token: 0x06000D59 RID: 3417 RVA: 0x0007539F File Offset: 0x0007359F
    private static void nnSetFogColor( float r, float g, float b )
    {
        AppMain.nnSetFogColor_col[0] = r;
        AppMain.nnSetFogColor_col[1] = g;
        AppMain.nnSetFogColor_col[2] = b;
        AppMain.nnSetFogColor_col[3] = 1f;
        OpenGL.glFogfv( 2918U, AppMain.nnSetFogColor_col );
    }

    // Token: 0x06000D5A RID: 3418 RVA: 0x000753D4 File Offset: 0x000735D4
    private static void nnSetFogRange( float fnear, float ffar )
    {
        OpenGL.glFogf( 2917U, 9729f );
        AppMain.nngFogStart = fnear;
        AppMain.nngFogEnd = ffar;
    }

    // Token: 0x06000D5B RID: 3419 RVA: 0x000753F1 File Offset: 0x000735F1
    private void nnSetFogLinearGL( float fnear, float ffar )
    {
        AppMain.mppAssertNotImpl();
        OpenGL.glFogf( 2917U, 9729f );
        AppMain.nngFogStart = fnear;
        AppMain.nngFogEnd = ffar;
    }

    // Token: 0x06000D5C RID: 3420 RVA: 0x00075413 File Offset: 0x00073613
    private void nnSetFogExpGL( float density )
    {
        AppMain.mppAssertNotImpl();
        OpenGL.glFogf( 2917U, 2048f );
        AppMain.nngFogDensity = density;
    }

    // Token: 0x06000D5D RID: 3421 RVA: 0x0007542F File Offset: 0x0007362F
    private void nnSetFogExp2GL( float density )
    {
        AppMain.mppAssertNotImpl();
        OpenGL.glFogf( 2917U, 2049f );
        AppMain.nngFogDensity = density;
    }

    // Token: 0x06000D5E RID: 3422 RVA: 0x0007544B File Offset: 0x0007364B
    private void nnSetFogDensityGL( float density )
    {
        AppMain.mppAssertNotImpl();
        AppMain.nngFogDensity = density;
    }

    // Token: 0x06000D5F RID: 3423 RVA: 0x00075458 File Offset: 0x00073658
    private static void nnPutFogSwitchGL( bool on_off )
    {
        if ( on_off )
        {
            OpenGL.glEnable( 2912U );
            OpenGL.glFogf( 2915U, AppMain.nngFogStart );
            OpenGL.glFogf( 2916U, AppMain.nngFogEnd );
            OpenGL.glFogf( 2914U, AppMain.nngFogDensity );
            return;
        }
        OpenGL.glDisable( 2912U );
        OpenGL.glFogf( 2915U, AppMain.nngClip3d.f_clip );
        OpenGL.glFogf( 2916U, AppMain.nngClip3d.f_clip + 1f );
        OpenGL.glFogf( 2914U, 0f );
    }

    // Token: 0x06000D60 RID: 3424 RVA: 0x000754E7 File Offset: 0x000736E7
    private void nnDrawMultiObjectInitialPose( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX[] basemtxptrlist, uint[] nodestatlistptrlist, uint subobjtype, uint flag, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000F38 RID: 3896 RVA: 0x00085E9A File Offset: 0x0008409A
    private void nnDrawMultiObject( AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX[] mtxpalptrlist, uint[] nodestatlistptrlist, uint subobjtype, uint flag, int num )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000F39 RID: 3897 RVA: 0x00085EA1 File Offset: 0x000840A1
    private uint nnCalcObjectSize( AppMain.NNS_OBJECT obj )
    {
        return 0U;
    }

    // Token: 0x06000F3A RID: 3898 RVA: 0x00085EA4 File Offset: 0x000840A4
    private static uint nnCopyMaterialList( AppMain.NNS_MATERIALPTR[] dstmatptr, AppMain.NNS_MATERIALPTR[] srcmatptr, int nMaterial, uint flag )
    {
        for ( int i = 0; i < nMaterial; i++ )
        {
            if ( ( srcmatptr[i].fType & 2U ) != 0U )
            {
                AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC = null;
                AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC2 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)srcmatptr[i].pMaterial;
                if ( ( srcmatptr[i].fType & 4U ) != 0U )
                {
                    if ( dstmatptr != null )
                    {
                        dstmatptr[i].fType = 6U;
                        nns_MATERIAL_STDSHADER_DESC = ( NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )( dstmatptr[i].pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE() );
                        ( ( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )nns_MATERIAL_STDSHADER_DESC ).Assign( ( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )nns_MATERIAL_STDSHADER_DESC2 );
                    }
                }
                else if ( dstmatptr != null )
                {
                    dstmatptr[i].fType = 2U;
                    nns_MATERIAL_STDSHADER_DESC = ( NNS_MATERIAL_STDSHADER_DESC )( dstmatptr[i].pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC() );
                    nns_MATERIAL_STDSHADER_DESC.Assign( nns_MATERIAL_STDSHADER_DESC2 );
                }
                AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor = nns_MATERIAL_STDSHADER_DESC2.pColor;
                int num = 1;
                for ( int j = 0; j < i; j++ )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC3 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)srcmatptr[j].pMaterial;
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor2 = nns_MATERIAL_STDSHADER_DESC3.pColor;
                    if ( pColor == pColor2 )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_STDSHADER_DESC.pColor = ( ( AppMain.NNS_MATERIAL_STDSHADER_DESC )dstmatptr[j].pMaterial ).pColor;
                        }
                        num = 0;
                        break;
                    }
                }
                if ( num != 0 && dstmatptr != null )
                {
                    nns_MATERIAL_STDSHADER_DESC.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR();
                    nns_MATERIAL_STDSHADER_DESC.pColor.Assign( pColor );
                }
                AppMain.NNS_MATERIAL_LOGIC pLogic = nns_MATERIAL_STDSHADER_DESC2.pLogic;
                num = 1;
                for ( int j = 0; j < i; j++ )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC4 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)srcmatptr[j].pMaterial;
                    AppMain.NNS_MATERIAL_LOGIC pLogic2 = nns_MATERIAL_STDSHADER_DESC4.pLogic;
                    if ( pLogic == pLogic2 )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_STDSHADER_DESC.pLogic = ( ( AppMain.NNS_MATERIAL_STDSHADER_DESC )dstmatptr[j].pMaterial ).pLogic;
                        }
                        num = 0;
                        break;
                    }
                }
                if ( num != 0 && dstmatptr != null )
                {
                    nns_MATERIAL_STDSHADER_DESC.pLogic = new AppMain.NNS_MATERIAL_LOGIC();
                    nns_MATERIAL_STDSHADER_DESC.pLogic.Assign( pLogic );
                }
                if ( nns_MATERIAL_STDSHADER_DESC2.nTex > 0 )
                {
                    if ( dstmatptr != null )
                    {
                        nns_MATERIAL_STDSHADER_DESC.pTexDesc = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[nns_MATERIAL_STDSHADER_DESC2.nTex];
                        int num2 = 0;
                        while ( i < nns_MATERIAL_STDSHADER_DESC2.nTex )
                        {
                            nns_MATERIAL_STDSHADER_DESC.pTexDesc[num2] = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC( nns_MATERIAL_STDSHADER_DESC2.pTexDesc[num2] );
                            i++;
                        }
                    }
                    for ( int j = 0; j < nns_MATERIAL_STDSHADER_DESC2.nTex; j++ )
                    {
                        AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC nns_MATERIAL_STDSHADER_TEXMAP_DESC = nns_MATERIAL_STDSHADER_DESC2.pTexDesc[j];
                        AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC nns_MATERIAL_STDSHADER_TEXMAP_DESC2 = null;
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2 = nns_MATERIAL_STDSHADER_DESC.pTexDesc[j];
                        }
                        if ( nns_MATERIAL_STDSHADER_TEXMAP_DESC.pBorderColor != null && dstmatptr != null )
                        {
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2.pBorderColor = new AppMain.NNS_RGBA?( default( AppMain.NNS_RGBA ) );
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2.pBorderColor = nns_MATERIAL_STDSHADER_TEXMAP_DESC.pBorderColor;
                        }
                        if ( nns_MATERIAL_STDSHADER_TEXMAP_DESC.pFilterMode != null && dstmatptr != null )
                        {
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2.pFilterMode = new AppMain.NNS_TEXTURE_FILTERMODE();
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2.pFilterMode.Assign( nns_MATERIAL_STDSHADER_TEXMAP_DESC.pFilterMode );
                        }
                        if ( nns_MATERIAL_STDSHADER_TEXMAP_DESC.pLODParam != null && dstmatptr != null )
                        {
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2.pLODParam = new AppMain.NNS_TEXTURE_LOD_PARAM();
                            nns_MATERIAL_STDSHADER_TEXMAP_DESC2.pLODParam.Assign( nns_MATERIAL_STDSHADER_TEXMAP_DESC.pLODParam );
                        }
                    }
                }
            }
            else if ( ( srcmatptr[i].fType & 8U ) != 0U )
            {
                AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = null;
                AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC2 = (AppMain.NNS_MATERIAL_GLES11_DESC)srcmatptr[i].pMaterial;
                if ( dstmatptr != null )
                {
                    dstmatptr[i].fType = 8U;
                    nns_MATERIAL_GLES11_DESC = ( NNS_MATERIAL_GLES11_DESC )( dstmatptr[i].pMaterial = new AppMain.NNS_MATERIAL_GLES11_DESC() );
                    nns_MATERIAL_GLES11_DESC.Assign( nns_MATERIAL_GLES11_DESC2 );
                }
                AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor3 = nns_MATERIAL_GLES11_DESC2.pColor;
                int num3 = 1;
                for ( int j = 0; j < i; j++ )
                {
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC3 = (AppMain.NNS_MATERIAL_GLES11_DESC)srcmatptr[j].pMaterial;
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor4 = nns_MATERIAL_GLES11_DESC3.pColor;
                    if ( pColor3 == pColor4 )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_GLES11_DESC.pColor = ( ( AppMain.NNS_MATERIAL_GLES11_DESC )dstmatptr[j].pMaterial ).pColor;
                        }
                        num3 = 0;
                        break;
                    }
                }
                if ( num3 != 0 && dstmatptr != null )
                {
                    nns_MATERIAL_GLES11_DESC.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR();
                    nns_MATERIAL_GLES11_DESC.pColor.Assign( pColor3 );
                }
                AppMain.NNS_MATERIAL_GLES11_LOGIC pLogic3 = nns_MATERIAL_GLES11_DESC2.pLogic;
                num3 = 1;
                for ( int j = 0; j < i; j++ )
                {
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC4 = (AppMain.NNS_MATERIAL_GLES11_DESC)srcmatptr[j].pMaterial;
                    AppMain.NNS_MATERIAL_GLES11_LOGIC pLogic4 = nns_MATERIAL_GLES11_DESC4.pLogic;
                    if ( pLogic3 == pLogic4 )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_GLES11_DESC.pLogic = ( ( AppMain.NNS_MATERIAL_GLES11_DESC )dstmatptr[j].pMaterial ).pLogic;
                        }
                        num3 = 0;
                        break;
                    }
                }
                if ( num3 != 0 && dstmatptr != null )
                {
                    nns_MATERIAL_GLES11_DESC.pLogic = new AppMain.NNS_MATERIAL_GLES11_LOGIC();
                    nns_MATERIAL_GLES11_DESC.pLogic.Assign( pLogic3 );
                }
                if ( nns_MATERIAL_GLES11_DESC2.nTex > 0 )
                {
                    if ( dstmatptr != null )
                    {
                        nns_MATERIAL_GLES11_DESC.pTexDesc = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[nns_MATERIAL_GLES11_DESC2.nTex];
                        for ( int k = 0; k < nns_MATERIAL_GLES11_DESC2.nTex; k++ )
                        {
                            nns_MATERIAL_GLES11_DESC.pTexDesc[k] = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC( ref nns_MATERIAL_GLES11_DESC2.pTexDesc[k] );
                        }
                    }
                    for ( int j = 0; j < nns_MATERIAL_GLES11_DESC2.nTex; j++ )
                    {
                        AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC nns_MATERIAL_GLES11_TEXMAP_DESC = nns_MATERIAL_GLES11_DESC2.pTexDesc[j];
                        AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC nns_MATERIAL_GLES11_TEXMAP_DESC2;
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_GLES11_TEXMAP_DESC2 = nns_MATERIAL_GLES11_DESC.pTexDesc[j];
                        }
                        if ( nns_MATERIAL_GLES11_TEXMAP_DESC.pCombine != null && dstmatptr != null )
                        {
                            nns_MATERIAL_GLES11_TEXMAP_DESC2.pCombine = new AppMain.NNS_TEXTURE_GLES11_COMBINE();
                            nns_MATERIAL_GLES11_TEXMAP_DESC2.pCombine.Assign( nns_MATERIAL_GLES11_TEXMAP_DESC.pCombine );
                        }
                        if ( nns_MATERIAL_GLES11_TEXMAP_DESC.pFilterMode != null && dstmatptr != null )
                        {
                            nns_MATERIAL_GLES11_TEXMAP_DESC2.pFilterMode = new AppMain.NNS_TEXTURE_FILTERMODE();
                            nns_MATERIAL_GLES11_TEXMAP_DESC2.pFilterMode.Assign( nns_MATERIAL_GLES11_TEXMAP_DESC.pFilterMode );
                        }
                    }
                }
            }
            else if ( ( srcmatptr[i].fType & 1U ) != 0U )
            {
                AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC = null;
                AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC2 = (AppMain.NNS_MATERIAL_DESC)srcmatptr[i].pMaterial;
                if ( dstmatptr != null )
                {
                    dstmatptr[i].fType = 1U;
                    nns_MATERIAL_DESC = ( NNS_MATERIAL_DESC )( dstmatptr[i].pMaterial = new AppMain.NNS_MATERIAL_DESC() );
                    nns_MATERIAL_DESC.Assign( nns_MATERIAL_DESC2 );
                }
                AppMain.NNS_MATERIAL_COLOR pColor5 = nns_MATERIAL_DESC2.pColor;
                int num4 = 1;
                for ( int j = 0; j < i; j++ )
                {
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC3 = (AppMain.NNS_MATERIAL_DESC)srcmatptr[j].pMaterial;
                    AppMain.NNS_MATERIAL_COLOR pColor6 = nns_MATERIAL_DESC3.pColor;
                    AppMain.NNS_MATERIAL_COLOR pBackColor = nns_MATERIAL_DESC3.pBackColor;
                    if ( pColor5 == pColor6 )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_DESC.pColor = ( ( AppMain.NNS_MATERIAL_DESC )dstmatptr[j].pMaterial ).pColor;
                        }
                        num4 = 0;
                        break;
                    }
                    if ( pColor5 == pBackColor )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_DESC.pColor = ( ( AppMain.NNS_MATERIAL_DESC )dstmatptr[j].pMaterial ).pBackColor;
                        }
                        num4 = 0;
                        break;
                    }
                }
                if ( num4 != 0 && dstmatptr != null )
                {
                    nns_MATERIAL_DESC.pColor = new AppMain.NNS_MATERIAL_COLOR();
                    nns_MATERIAL_DESC.pColor.Assign( pColor5 );
                }
                AppMain.NNS_MATERIAL_COLOR pBackColor2 = nns_MATERIAL_DESC2.pBackColor;
                if ( pBackColor2 != null )
                {
                    num4 = 1;
                    for ( int j = 0; j < i; j++ )
                    {
                        AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC4 = (AppMain.NNS_MATERIAL_DESC)srcmatptr[j].pMaterial;
                        AppMain.NNS_MATERIAL_COLOR pColor7 = nns_MATERIAL_DESC4.pColor;
                        AppMain.NNS_MATERIAL_COLOR pBackColor3 = nns_MATERIAL_DESC4.pBackColor;
                        if ( pBackColor2 == pColor7 )
                        {
                            if ( dstmatptr != null )
                            {
                                nns_MATERIAL_DESC.pBackColor = ( ( AppMain.NNS_MATERIAL_DESC )dstmatptr[j].pMaterial ).pColor;
                            }
                            num4 = 0;
                            break;
                        }
                        if ( pBackColor2 == pBackColor3 )
                        {
                            if ( dstmatptr != null )
                            {
                                nns_MATERIAL_DESC.pBackColor = ( ( AppMain.NNS_MATERIAL_DESC )dstmatptr[j].pMaterial ).pBackColor;
                            }
                            num4 = 0;
                            break;
                        }
                    }
                    if ( num4 != 0 && dstmatptr != null )
                    {
                        nns_MATERIAL_DESC.pBackColor = new AppMain.NNS_MATERIAL_COLOR();
                        nns_MATERIAL_DESC.pBackColor.Assign( pBackColor2 );
                    }
                }
                AppMain.NNS_MATERIAL_LOGIC pLogic5 = nns_MATERIAL_DESC2.pLogic;
                num4 = 1;
                for ( int j = 0; j < i; j++ )
                {
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC5 = (AppMain.NNS_MATERIAL_DESC)srcmatptr[j].pMaterial;
                    AppMain.NNS_MATERIAL_LOGIC pLogic6 = nns_MATERIAL_DESC5.pLogic;
                    if ( pLogic5 == pLogic6 )
                    {
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_DESC.pLogic = ( ( AppMain.NNS_MATERIAL_DESC )dstmatptr[j].pMaterial ).pLogic;
                        }
                        num4 = 0;
                        break;
                    }
                }
                if ( num4 != 0 && dstmatptr != null )
                {
                    nns_MATERIAL_DESC.pLogic = new AppMain.NNS_MATERIAL_LOGIC();
                    nns_MATERIAL_DESC.pLogic.Assign( pLogic5 );
                }
                if ( nns_MATERIAL_DESC2.nTex > 0 )
                {
                    if ( dstmatptr != null )
                    {
                        nns_MATERIAL_DESC.pTexDesc = new AppMain.NNS_MATERIAL_TEXMAP_DESC[nns_MATERIAL_DESC2.nTex];
                        int num5 = 0;
                        while ( i < nns_MATERIAL_DESC2.nTex )
                        {
                            nns_MATERIAL_DESC.pTexDesc[num5] = new AppMain.NNS_MATERIAL_TEXMAP_DESC( nns_MATERIAL_DESC2.pTexDesc[num5] );
                            i++;
                        }
                    }
                    for ( int j = 0; j < nns_MATERIAL_DESC2.nTex; j++ )
                    {
                        AppMain.NNS_MATERIAL_TEXMAP_DESC nns_MATERIAL_TEXMAP_DESC = nns_MATERIAL_DESC2.pTexDesc[j];
                        AppMain.NNS_MATERIAL_TEXMAP_DESC nns_MATERIAL_TEXMAP_DESC2 = null;
                        if ( dstmatptr != null )
                        {
                            nns_MATERIAL_TEXMAP_DESC2 = nns_MATERIAL_DESC.pTexDesc[j];
                        }
                        if ( nns_MATERIAL_TEXMAP_DESC.pCombine != null && dstmatptr != null )
                        {
                            nns_MATERIAL_TEXMAP_DESC2.pCombine = new AppMain.NNS_TEXTURE_COMBINE();
                            nns_MATERIAL_TEXMAP_DESC2.pCombine.Assign( nns_MATERIAL_TEXMAP_DESC.pCombine );
                        }
                        if ( nns_MATERIAL_TEXMAP_DESC.pBorderColor != null && dstmatptr != null )
                        {
                            nns_MATERIAL_TEXMAP_DESC2.pBorderColor = new AppMain.NNS_RGBA?( default( AppMain.NNS_RGBA ) );
                            nns_MATERIAL_TEXMAP_DESC2.pBorderColor = nns_MATERIAL_TEXMAP_DESC.pBorderColor;
                        }
                        if ( nns_MATERIAL_TEXMAP_DESC.pFilterMode != null && dstmatptr != null )
                        {
                            nns_MATERIAL_TEXMAP_DESC2.pFilterMode = new AppMain.NNS_TEXTURE_FILTERMODE();
                            nns_MATERIAL_TEXMAP_DESC2.pFilterMode.Assign( nns_MATERIAL_TEXMAP_DESC.pFilterMode );
                        }
                        if ( nns_MATERIAL_TEXMAP_DESC.pLODParam != null && dstmatptr != null )
                        {
                            nns_MATERIAL_TEXMAP_DESC2.pLODParam = new AppMain.NNS_TEXTURE_LOD_PARAM();
                            nns_MATERIAL_TEXMAP_DESC2.pLODParam.Assign( nns_MATERIAL_TEXMAP_DESC.pLODParam );
                        }
                    }
                }
            }
        }
        return 0U;
    }

    // Token: 0x06000F3B RID: 3899 RVA: 0x000866D0 File Offset: 0x000848D0
    private static uint nnCopyVertexList( AppMain.NNS_VTXLISTPTR[] dstvlist, AppMain.NNS_VTXLISTPTR[] srcvlist, int nVtxList, uint flag )
    {
        for ( int i = 0; i < nVtxList; i++ )
        {
            if ( dstvlist != null )
            {
                dstvlist[i].fType = srcvlist[i].fType;
            }
            if ( ( srcvlist[i].fType & 1U ) != 0U )
            {
                AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC = (AppMain.NNS_VTXLIST_GL_DESC)srcvlist[i].pVtxList;
                AppMain.NNS_VTXLIST_GL_DESC nns_VTXLIST_GL_DESC2 = null;
                if ( dstvlist != null )
                {
                    nns_VTXLIST_GL_DESC2 = ( NNS_VTXLIST_GL_DESC )( dstvlist[i].pVtxList = new AppMain.NNS_VTXLIST_GL_DESC() );
                    nns_VTXLIST_GL_DESC2.Assign( nns_VTXLIST_GL_DESC );
                }
                if ( dstvlist != null )
                {
                    nns_VTXLIST_GL_DESC2.pArray = new AppMain.NNS_VTXARRAY_GL[nns_VTXLIST_GL_DESC.nArray];
                    for ( int j = 0; j < nns_VTXLIST_GL_DESC.nArray; j++ )
                    {
                        nns_VTXLIST_GL_DESC2.pArray[j] = new AppMain.NNS_VTXARRAY_GL( nns_VTXLIST_GL_DESC.pArray[i] );
                    }
                }
                if ( ( srcvlist[i].fType & 16U ) != 0U )
                {
                    if ( dstvlist != null )
                    {
                    }
                }
                else if ( ( nns_VTXLIST_GL_DESC.Type & 65536U ) == 0U )
                {
                    if ( dstvlist != null )
                    {
                        byte[] array = new byte[nns_VTXLIST_GL_DESC.VertexBufferSize];
                        Array.Copy( nns_VTXLIST_GL_DESC.pVertexBuffer.Data, array, nns_VTXLIST_GL_DESC.VertexBufferSize );
                        nns_VTXLIST_GL_DESC2.pVertexBuffer = ByteBuffer.Wrap( array );
                        for ( int k = 0; k < nns_VTXLIST_GL_DESC.nArray; k++ )
                        {
                            nns_VTXLIST_GL_DESC2.pArray[k].Pointer = nns_VTXLIST_GL_DESC2.pVertexBuffer + nns_VTXLIST_GL_DESC.pArray[k].Pointer.Offset;
                        }
                        nns_VTXLIST_GL_DESC2.VertexBufferSize = nns_VTXLIST_GL_DESC.VertexBufferSize;
                    }
                    else
                    {
                        for ( int k = 0; k < nns_VTXLIST_GL_DESC.nArray; k++ )
                        {
                        }
                    }
                }
                else if ( dstvlist != null )
                {
                    byte[] array2 = new byte[nns_VTXLIST_GL_DESC.VertexBufferSize];
                    Array.Copy( nns_VTXLIST_GL_DESC.pVertexBuffer.Data, array2, nns_VTXLIST_GL_DESC.VertexBufferSize );
                    nns_VTXLIST_GL_DESC2.pVertexBuffer = ByteBuffer.Wrap( array2 );
                    for ( int k = 0; k < nns_VTXLIST_GL_DESC.nArray; k++ )
                    {
                        nns_VTXLIST_GL_DESC2.pArray[k].Pointer = nns_VTXLIST_GL_DESC2.pVertexBuffer + nns_VTXLIST_GL_DESC.pArray[k].Pointer.Offset;
                    }
                }
                if ( dstvlist != null && nns_VTXLIST_GL_DESC.nMatrix != 0 )
                {
                    nns_VTXLIST_GL_DESC2.pMatrixIndices = new ushort[nns_VTXLIST_GL_DESC.nMatrix];
                    Array.Copy( nns_VTXLIST_GL_DESC.pMatrixIndices, nns_VTXLIST_GL_DESC2.pMatrixIndices, nns_VTXLIST_GL_DESC.nMatrix );
                }
            }
            else if ( ( srcvlist[i].fType & 16711680U ) != 0U )
            {
                AppMain.NNS_VTXLIST_COMMON_DESC nns_VTXLIST_COMMON_DESC = (AppMain.NNS_VTXLIST_COMMON_DESC)srcvlist[i].pVtxList;
                AppMain.NNS_VTXLIST_COMMON_DESC nns_VTXLIST_COMMON_DESC2 = null;
                if ( dstvlist != null )
                {
                    nns_VTXLIST_COMMON_DESC2 = ( NNS_VTXLIST_COMMON_DESC )( dstvlist[i].pVtxList = new AppMain.NNS_VTXLIST_COMMON_DESC() );
                    nns_VTXLIST_COMMON_DESC2.Assign( nns_VTXLIST_COMMON_DESC );
                }
                for ( int k = 0; k < 4; k++ )
                {
                    AppMain.NNS_VTXLIST_COMMON_ARRAY nns_VTXLIST_COMMON_ARRAY = null;
                    switch ( k )
                    {
                        case 0:
                            nns_VTXLIST_COMMON_ARRAY = nns_VTXLIST_COMMON_DESC.List0;
                            break;
                        case 1:
                            nns_VTXLIST_COMMON_ARRAY = nns_VTXLIST_COMMON_DESC.List1;
                            break;
                        case 2:
                            nns_VTXLIST_COMMON_ARRAY = nns_VTXLIST_COMMON_DESC.List2;
                            break;
                        case 3:
                            nns_VTXLIST_COMMON_ARRAY = nns_VTXLIST_COMMON_DESC.List3;
                            break;
                    }
                    if ( nns_VTXLIST_COMMON_ARRAY.pList != null && dstvlist != null )
                    {
                        switch ( k )
                        {
                            case 0:
                                {
                                    AppMain.NNS_VTXLIST_COMMON_ARRAY list = nns_VTXLIST_COMMON_DESC2.List0;
                                    break;
                                }
                            case 1:
                                {
                                    AppMain.NNS_VTXLIST_COMMON_ARRAY list2 = nns_VTXLIST_COMMON_DESC2.List1;
                                    break;
                                }
                            case 2:
                                {
                                    AppMain.NNS_VTXLIST_COMMON_ARRAY list3 = nns_VTXLIST_COMMON_DESC2.List2;
                                    break;
                                }
                            case 3:
                                {
                                    AppMain.NNS_VTXLIST_COMMON_ARRAY list4 = nns_VTXLIST_COMMON_DESC2.List3;
                                    break;
                                }
                        }
                        AppMain.mppAssertNotImpl();
                    }
                }
            }
            else
            {
                AppMain.NNM_ASSERT( 0, "Unknown vertex foramt.\n" );
            }
        }
        return 0U;
    }

    // Token: 0x06000F3C RID: 3900 RVA: 0x000869E4 File Offset: 0x00084BE4
    private static uint nnCopyPrimitiveList( AppMain.NNS_PRIMLISTPTR[] dstplist, AppMain.NNS_PRIMLISTPTR[] srcplist, int nPrimList, uint flag )
    {
        for ( int i = 0; i < nPrimList; i++ )
        {
            if ( dstplist != null )
            {
                dstplist[i].fType = srcplist[i].fType;
            }
            if ( ( srcplist[i].fType & 1U ) != 0U )
            {
                AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC = (AppMain.NNS_PRIMLIST_GL_DESC)srcplist[i].pPrimList;
                AppMain.NNS_PRIMLIST_GL_DESC nns_PRIMLIST_GL_DESC2 = null;
                if ( dstplist != null )
                {
                    nns_PRIMLIST_GL_DESC2 = ( NNS_PRIMLIST_GL_DESC )( dstplist[i].pPrimList = new AppMain.NNS_PRIMLIST_GL_DESC() );
                    nns_PRIMLIST_GL_DESC2.Assign( nns_PRIMLIST_GL_DESC );
                }
                if ( dstplist != null )
                {
                    nns_PRIMLIST_GL_DESC2.pCounts = new int[nns_PRIMLIST_GL_DESC.nPrim];
                    Array.Copy( nns_PRIMLIST_GL_DESC.pCounts, nns_PRIMLIST_GL_DESC2.pCounts, nns_PRIMLIST_GL_DESC.nPrim );
                }
                if ( dstplist != null )
                {
                    nns_PRIMLIST_GL_DESC2.pIndices = new UShortBuffer[nns_PRIMLIST_GL_DESC.nPrim];
                }
                if ( ( srcplist[i].fType & 2U ) != 0U )
                {
                    if ( dstplist != null )
                    {
                    }
                }
                else if ( dstplist != null )
                {
                    byte[] array = new byte[nns_PRIMLIST_GL_DESC.IndexBufferSize];
                    Array.Copy( nns_PRIMLIST_GL_DESC.pIndexBuffer.Data, array, nns_PRIMLIST_GL_DESC.IndexBufferSize );
                    nns_PRIMLIST_GL_DESC2.pIndexBuffer = ByteBuffer.Wrap( array );
                    for ( int j = 0; j < nns_PRIMLIST_GL_DESC.nPrim; j++ )
                    {
                        nns_PRIMLIST_GL_DESC2.pIndices[j] = ( nns_PRIMLIST_GL_DESC2.pIndexBuffer + nns_PRIMLIST_GL_DESC.pIndices[j].Offset ).AsUShortBuffer();
                    }
                }
            }
            else if ( ( srcplist[i].fType & 16711680U ) != 0U )
            {
                uint fType = srcplist[i].fType;
                if ( fType <= 131072U )
                {
                    if ( fType == 65536U || fType == 131072U )
                    {
                        AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_STRIP nns_PRIMLIST_COMMON_TRIANGLE_STRIP = (AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_STRIP)srcplist[i].pPrimList;
                        AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_STRIP nns_PRIMLIST_COMMON_TRIANGLE_STRIP2 = null;
                        if ( dstplist != null )
                        {
                            nns_PRIMLIST_COMMON_TRIANGLE_STRIP2 = ( NNS_PRIMLIST_COMMON_TRIANGLE_STRIP )( dstplist[i].pPrimList = new AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_STRIP() );
                            nns_PRIMLIST_COMMON_TRIANGLE_STRIP2.Assign( nns_PRIMLIST_COMMON_TRIANGLE_STRIP );
                        }
                        int nStrip = nns_PRIMLIST_COMMON_TRIANGLE_STRIP.nStrip;
                        if ( dstplist != null )
                        {
                            nns_PRIMLIST_COMMON_TRIANGLE_STRIP2.pLengthList = new ushort[nns_PRIMLIST_COMMON_TRIANGLE_STRIP.nStrip];
                            Array.Copy( nns_PRIMLIST_COMMON_TRIANGLE_STRIP.pLengthList, nns_PRIMLIST_COMMON_TRIANGLE_STRIP2.pLengthList, nns_PRIMLIST_COMMON_TRIANGLE_STRIP.nStrip );
                        }
                        int num = 0;
                        for ( int j = 0; j < nStrip; j++ )
                        {
                            num += ( int )nns_PRIMLIST_COMMON_TRIANGLE_STRIP.pLengthList[j];
                        }
                        if ( dstplist != null )
                        {
                            nns_PRIMLIST_COMMON_TRIANGLE_STRIP2.pStripList = new ushort[nns_PRIMLIST_COMMON_TRIANGLE_STRIP.nIndexSetSize * num];
                            Array.Copy( nns_PRIMLIST_COMMON_TRIANGLE_STRIP.pStripList, nns_PRIMLIST_COMMON_TRIANGLE_STRIP2.pStripList, nns_PRIMLIST_COMMON_TRIANGLE_STRIP.nIndexSetSize * num );
                        }
                    }
                }
                else if ( fType != 262144U )
                {
                    if ( fType != 524288U )
                    {
                        if ( fType == 1048576U )
                        {
                            AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST = (AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST)srcplist[i].pPrimList;
                            AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2 = null;
                            if ( dstplist != null )
                            {
                                nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2 = ( NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST )( dstplist[i].pPrimList = new AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST() );
                                nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2.Assign( nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST );
                            }
                            if ( dstplist != null )
                            {
                                nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2.pTriangleList = new ushort[nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nTriangle];
                                Array.Copy( nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.pTriangleList, nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2.pTriangleList, nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nTriangle );
                            }
                            if ( dstplist != null )
                            {
                                nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2.pQuadList = new ushort[nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nQuad];
                                Array.Copy( nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.pQuadList, nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST2.pQuadList, nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_TRIANGLE_QUAD_LIST.nQuad );
                            }
                        }
                    }
                    else
                    {
                        AppMain.NNS_PRIMLIST_COMMON_QUAD_LIST nns_PRIMLIST_COMMON_QUAD_LIST = (AppMain.NNS_PRIMLIST_COMMON_QUAD_LIST)srcplist[i].pPrimList;
                        AppMain.NNS_PRIMLIST_COMMON_QUAD_LIST nns_PRIMLIST_COMMON_QUAD_LIST2 = null;
                        if ( dstplist != null )
                        {
                            nns_PRIMLIST_COMMON_QUAD_LIST2 = ( NNS_PRIMLIST_COMMON_QUAD_LIST )( dstplist[i].pPrimList = new AppMain.NNS_PRIMLIST_COMMON_QUAD_LIST() );
                            nns_PRIMLIST_COMMON_QUAD_LIST2.Assign( nns_PRIMLIST_COMMON_QUAD_LIST );
                        }
                        if ( dstplist != null )
                        {
                            nns_PRIMLIST_COMMON_QUAD_LIST2.pQuadList = new ushort[nns_PRIMLIST_COMMON_QUAD_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_QUAD_LIST.nQuad];
                            Array.Copy( nns_PRIMLIST_COMMON_QUAD_LIST.pQuadList, nns_PRIMLIST_COMMON_QUAD_LIST2.pQuadList, nns_PRIMLIST_COMMON_QUAD_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_QUAD_LIST.nQuad );
                        }
                    }
                }
                else
                {
                    AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_LIST nns_PRIMLIST_COMMON_TRIANGLE_LIST = (AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_LIST)srcplist[i].pPrimList;
                    AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_LIST nns_PRIMLIST_COMMON_TRIANGLE_LIST2 = null;
                    if ( dstplist != null )
                    {
                        nns_PRIMLIST_COMMON_TRIANGLE_LIST2 = ( NNS_PRIMLIST_COMMON_TRIANGLE_LIST )( dstplist[i].pPrimList = new AppMain.NNS_PRIMLIST_COMMON_TRIANGLE_LIST() );
                        nns_PRIMLIST_COMMON_TRIANGLE_LIST2.Assign( nns_PRIMLIST_COMMON_TRIANGLE_LIST );
                    }
                    if ( dstplist != null )
                    {
                        nns_PRIMLIST_COMMON_TRIANGLE_LIST2.pTriangleList = new ushort[nns_PRIMLIST_COMMON_TRIANGLE_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_TRIANGLE_LIST.nTriangle];
                        Array.Copy( nns_PRIMLIST_COMMON_TRIANGLE_LIST.pTriangleList, nns_PRIMLIST_COMMON_TRIANGLE_LIST2.pTriangleList, nns_PRIMLIST_COMMON_TRIANGLE_LIST.nIndexSetSize * nns_PRIMLIST_COMMON_TRIANGLE_LIST.nTriangle );
                    }
                }
            }
            else
            {
                AppMain.NNM_ASSERT( 0, "Unknown primitive foramt.\n" );
            }
        }
        return 0U;
    }

    // Token: 0x06000F3D RID: 3901 RVA: 0x00086DF0 File Offset: 0x00084FF0
    private static uint nnCopySubobjList( AppMain.NNS_SUBOBJ[] pSubobjListDst, AppMain.NNS_SUBOBJ[] pSubobjListSrc, int nSubobj, uint flag )
    {
        if ( pSubobjListDst != null )
        {
            for ( int i = 0; i < nSubobj; i++ )
            {
                pSubobjListDst[i].Assign( pSubobjListSrc[i] );
            }
        }
        for ( int j = 0; j < nSubobj; j++ )
        {
            AppMain.NNS_SUBOBJ nns_SUBOBJ = pSubobjListSrc[j];
            AppMain.NNS_SUBOBJ nns_SUBOBJ2 = null;
            if ( pSubobjListDst != null )
            {
                nns_SUBOBJ2 = pSubobjListDst[j];
                nns_SUBOBJ2.pMeshsetList = new AppMain.NNS_MESHSET[nns_SUBOBJ.nMeshset];
                for ( int k = 0; k < nns_SUBOBJ.nMeshset; k++ )
                {
                    nns_SUBOBJ2.pMeshsetList[k] = new AppMain.NNS_MESHSET( nns_SUBOBJ.pMeshsetList[k] );
                }
            }
            if ( pSubobjListDst != null && nns_SUBOBJ.nTex != 0 )
            {
                nns_SUBOBJ2.pTexNumList = new int[nns_SUBOBJ.nTex];
                Array.Copy( nns_SUBOBJ.pTexNumList, nns_SUBOBJ2.pTexNumList, nns_SUBOBJ.nTex );
            }
        }
        return 0U;
    }

    // Token: 0x06000F3E RID: 3902 RVA: 0x00086EA8 File Offset: 0x000850A8
    private static uint nnCopyObject( AppMain.NNS_OBJECT dstobj, AppMain.NNS_OBJECT srcobj, uint flag )
    {
        if ( dstobj != null )
        {
            dstobj.Assign( srcobj );
            dstobj.fType |= 128U;
        }
        if ( dstobj != null )
        {
            dstobj.pMatPtrList = AppMain.New<AppMain.NNS_MATERIALPTR>( srcobj.pMatPtrList.Length );
            AppMain.nnCopyMaterialList( dstobj.pMatPtrList, srcobj.pMatPtrList, srcobj.nMaterial, flag );
        }
        else
        {
            AppMain.nnCopyMaterialList( null, srcobj.pMatPtrList, srcobj.nMaterial, flag );
        }
        if ( dstobj != null )
        {
            dstobj.pVtxListPtrList = AppMain.New<AppMain.NNS_VTXLISTPTR>( srcobj.pVtxListPtrList.Length );
            AppMain.nnCopyVertexList( dstobj.pVtxListPtrList, srcobj.pVtxListPtrList, srcobj.nVtxList, flag );
        }
        else
        {
            AppMain.nnCopyVertexList( null, srcobj.pVtxListPtrList, srcobj.nVtxList, flag );
        }
        if ( dstobj != null )
        {
            dstobj.pPrimListPtrList = AppMain.New<AppMain.NNS_PRIMLISTPTR>( srcobj.pPrimListPtrList.Length );
            AppMain.nnCopyPrimitiveList( dstobj.pPrimListPtrList, srcobj.pPrimListPtrList, srcobj.nPrimList, flag );
        }
        else
        {
            AppMain.nnCopyPrimitiveList( null, srcobj.pPrimListPtrList, srcobj.nPrimList, flag );
        }
        if ( dstobj != null )
        {
            dstobj.pNodeList = AppMain.New<AppMain.NNS_NODE>( srcobj.nNode );
            for ( int i = 0; i < srcobj.nNode; i++ )
            {
                dstobj.pNodeList[i].Assign( srcobj.pNodeList[i] );
            }
        }
        if ( dstobj != null )
        {
            dstobj.pSubobjList = AppMain.New<AppMain.NNS_SUBOBJ>( srcobj.pSubobjList.Length );
            AppMain.nnCopySubobjList( dstobj.pSubobjList, srcobj.pSubobjList, srcobj.nSubobj, flag );
        }
        else
        {
            AppMain.nnCopySubobjList( null, srcobj.pSubobjList, srcobj.nSubobj, flag );
        }
        return 0U;
    }

    // Token: 0x06000F3F RID: 3903 RVA: 0x00087022 File Offset: 0x00085222
    private uint nnCalcMorphObjectBufferSize( ref AppMain.NNS_OBJECT obj, ref AppMain.NNS_MORPHTARGETLIST mtgt, uint flag )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000F40 RID: 3904 RVA: 0x0008702A File Offset: 0x0008522A
    private uint nnInitMorphObject( ref AppMain.NNS_OBJECT mobj, ref AppMain.NNS_OBJECT obj, ref AppMain.NNS_MORPHTARGETLIST mtgt, uint flag )
    {
        AppMain.mppAssertNotImpl();
        return 0U;
    }

    // Token: 0x06000F41 RID: 3905 RVA: 0x00087032 File Offset: 0x00085232
    private void nnDrawMorphObject( ref AppMain.NNS_OBJECT mobj, ref AppMain.NNS_MATRIX mtxpal, ref uint nodestatlist, uint subobjtype, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06000F42 RID: 3906 RVA: 0x0008703C File Offset: 0x0008523C
    private static void nnMakeUnitMatrix( ref AppMain.SNNS_MATRIX dst )
    {
        dst.M00 = 1f;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = 1f;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = 1f;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F43 RID: 3907 RVA: 0x000870FC File Offset: 0x000852FC
    private static void nnMakeUnitMatrix( AppMain.NNS_MATRIX dst )
    {
        dst.M00 = 1f;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = 1f;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = 1f;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F44 RID: 3908 RVA: 0x000871BC File Offset: 0x000853BC
    private static void nnMakeQuaternionMatrix( out AppMain.SNNS_MATRIX dst, ref AppMain.NNS_QUATERNION quat )
    {
        float x = quat.x;
        float y = quat.y;
        float z = quat.z;
        float w = quat.w;
        float num = x * x;
        float num2 = y * y;
        float num3 = z * z;
        float num4 = w * w;
        float num5 = x * y;
        float num6 = y * z;
        float num7 = x * z;
        float num8 = x * w;
        float num9 = y * w;
        float num10 = z * w;
        float num11 = num4 - num;
        float num12 = num2 - num3;
        dst.M00 = num4 + num - num2 - num3;
        dst.M01 = 2f * ( num5 - num10 );
        dst.M02 = 2f * ( num7 + num9 );
        dst.M10 = 2f * ( num5 + num10 );
        dst.M11 = num11 + num12;
        dst.M12 = 2f * ( num6 - num8 );
        dst.M20 = 2f * ( num7 - num9 );
        dst.M21 = 2f * ( num6 + num8 );
        dst.M22 = num11 - num12;
        dst.M03 = 0f;
        dst.M13 = 0f;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F45 RID: 3909 RVA: 0x00087300 File Offset: 0x00085500
    private static void nnMakeQuaternionMatrix( AppMain.NNS_MATRIX dst, ref AppMain.NNS_QUATERNION quat )
    {
        float x = quat.x;
        float y = quat.y;
        float z = quat.z;
        float w = quat.w;
        float num = x * x;
        float num2 = y * y;
        float num3 = z * z;
        float num4 = w * w;
        float num5 = x * y;
        float num6 = y * z;
        float num7 = x * z;
        float num8 = x * w;
        float num9 = y * w;
        float num10 = z * w;
        float num11 = num4 - num;
        float num12 = num2 - num3;
        dst.M00 = num4 + num - num2 - num3;
        dst.M01 = 2f * ( num5 - num10 );
        dst.M02 = 2f * ( num7 + num9 );
        dst.M10 = 2f * ( num5 + num10 );
        dst.M11 = num11 + num12;
        dst.M12 = 2f * ( num6 - num8 );
        dst.M20 = 2f * ( num7 - num9 );
        dst.M21 = 2f * ( num6 + num8 );
        dst.M22 = num11 - num12;
        dst.M03 = 0f;
        dst.M13 = 0f;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F46 RID: 3910 RVA: 0x00087444 File Offset: 0x00085644
    public static void nnMakeRotateXMatrix( AppMain.NNS_MATRIX dst, int ax )
    {
        float num;
        float num2;
        AppMain.nnSinCos( ax, out num, out num2 );
        dst.M00 = 1f;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = num2;
        dst.M12 = -num;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = num;
        dst.M22 = num2;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F47 RID: 3911 RVA: 0x000874FC File Offset: 0x000856FC
    public static void nnMakeRotateXMatrix( out AppMain.SNNS_MATRIX dst, int ax )
    {
        float num;
        float num2;
        AppMain.nnSinCos( ax, out num, out num2 );
        dst.M00 = 1f;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = num2;
        dst.M12 = -num;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = num;
        dst.M22 = num2;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F48 RID: 3912 RVA: 0x000875B4 File Offset: 0x000857B4
    public static void nnMakeRotateYMatrix( AppMain.NNS_MATRIX dst, int ay )
    {
        float num;
        float num2;
        AppMain.nnSinCos( ay, out num, out num2 );
        dst.M00 = num2;
        dst.M01 = 0f;
        dst.M02 = num;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = 1f;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = -num;
        dst.M21 = 0f;
        dst.M22 = num2;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F49 RID: 3913 RVA: 0x0008766C File Offset: 0x0008586C
    public static void nnMakeRotateZMatrix( out AppMain.SNNS_MATRIX dst, int az )
    {
        float num;
        float num2;
        AppMain.nnSinCos( az, out num, out num2 );
        dst.M00 = num2;
        dst.M01 = -num;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = num;
        dst.M11 = num2;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = 1f;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F4A RID: 3914 RVA: 0x00087724 File Offset: 0x00085924
    public static void nnMakeRotateZMatrix( AppMain.NNS_MATRIX dst, int az )
    {
        float num;
        float num2;
        AppMain.nnSinCos( az, out num, out num2 );
        dst.M00 = num2;
        dst.M01 = -num;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = num;
        dst.M11 = num2;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = 1f;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F4B RID: 3915 RVA: 0x000877DC File Offset: 0x000859DC
    public static void nnMakeRotateXYZMatrix( AppMain.NNS_MATRIX dst, int ax, int ay, int az )
    {
        AppMain.nnMakeRotateZMatrix( dst, az );
        AppMain.nnRotateYMatrix( dst, dst, ay );
        AppMain.nnRotateXMatrix( dst, dst, ax );
    }

    // Token: 0x06000F4C RID: 3916 RVA: 0x000877F5 File Offset: 0x000859F5
    public static void nnMakeRotateXZYMatrix( AppMain.NNS_MATRIX dst, int ax, int ay, int az )
    {
        AppMain.nnMakeRotateYMatrix( dst, ay );
        AppMain.nnRotateZMatrix( dst, dst, az );
        AppMain.nnRotateXMatrix( dst, dst, ax );
    }

    // Token: 0x06000F4D RID: 3917 RVA: 0x0008780E File Offset: 0x00085A0E
    public static void nnMakeRotateZXYMatrix( AppMain.NNS_MATRIX dst, int ax, int ay, int az )
    {
        AppMain.nnMakeRotateYMatrix( dst, ay );
        AppMain.nnRotateXMatrix( dst, dst, ax );
        AppMain.nnRotateZMatrix( dst, dst, az );
    }

    // Token: 0x06000F4E RID: 3918 RVA: 0x00087828 File Offset: 0x00085A28
    public static void nnMakeScaleMatrix( out AppMain.SNNS_MATRIX dst, float x, float y, float z )
    {
        dst.M00 = x;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = y;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = z;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F4F RID: 3919 RVA: 0x000878DC File Offset: 0x00085ADC
    public static void nnMakeScaleMatrix( AppMain.NNS_MATRIX dst, float x, float y, float z )
    {
        dst.M00 = x;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = 0f;
        dst.M10 = 0f;
        dst.M11 = y;
        dst.M12 = 0f;
        dst.M13 = 0f;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = z;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F50 RID: 3920 RVA: 0x00087990 File Offset: 0x00085B90
    private static void nnMakeTranslateMatrix( out AppMain.SNNS_MATRIX dst, float x, float y, float z )
    {
        dst.M00 = 1f;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = x;
        dst.M10 = 0f;
        dst.M11 = 1f;
        dst.M12 = 0f;
        dst.M13 = y;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = 1f;
        dst.M23 = z;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F51 RID: 3921 RVA: 0x00087A44 File Offset: 0x00085C44
    private static void nnMakeTranslateMatrix( AppMain.NNS_MATRIX dst, float x, float y, float z )
    {
        dst.M00 = 1f;
        dst.M01 = 0f;
        dst.M02 = 0f;
        dst.M03 = x;
        dst.M10 = 0f;
        dst.M11 = 1f;
        dst.M12 = 0f;
        dst.M13 = y;
        dst.M20 = 0f;
        dst.M21 = 0f;
        dst.M22 = 1f;
        dst.M23 = z;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x06000F52 RID: 3922 RVA: 0x00087AF8 File Offset: 0x00085CF8
    public static void nnMakePerspectiveMatrix( AppMain.NNS_MATRIX mtx, int fovy, float aspect, float znear, float zfar )
    {
        int ang = fovy >> 1;
        double num = 1.0 / (double)AppMain.nnTan(ang);
        mtx.M00 = ( float )( num / ( double )aspect );
        mtx.M01 = 0f;
        mtx.M02 = 0f;
        mtx.M03 = 0f;
        mtx.M10 = 0f;
        mtx.M11 = ( float )num;
        mtx.M12 = 0f;
        mtx.M13 = 0f;
        mtx.M20 = 0f;
        mtx.M21 = 0f;
        mtx.M22 = ( float )( -( float )( ( double )znear ) / ( double )( zfar - znear ) );
        mtx.M23 = ( float )( -( float )( ( double )zfar * ( double )znear ) / ( double )( zfar - znear ) );
        mtx.M30 = 0f;
        mtx.M31 = 0f;
        mtx.M32 = -1f;
        mtx.M33 = 0f;
    }

    // Token: 0x06000F53 RID: 3923 RVA: 0x00087BD8 File Offset: 0x00085DD8
    public static void nnMakePerspectiveOffCenterMatrix( AppMain.NNS_MATRIX mtx, float left, float right, float bottom, float top, float znear, float zfar )
    {
        mtx.M00 = ( float )( 2.0 * ( double )znear / ( ( double )right - ( double )left ) );
        mtx.M01 = 0f;
        mtx.M02 = ( float )( ( ( double )right + ( double )left ) / ( ( double )right - ( double )left ) );
        mtx.M03 = 0f;
        mtx.M10 = 0f;
        mtx.M11 = ( float )( 2.0 * ( double )znear / ( ( double )top - ( double )bottom ) );
        mtx.M12 = ( float )( ( ( double )top + ( double )bottom ) / ( ( double )top - ( double )bottom ) );
        mtx.M13 = 0f;
        mtx.M20 = 0f;
        mtx.M21 = 0f;
        mtx.M22 = ( float )( -( float )( ( double )znear ) / ( double )( zfar - znear ) );
        mtx.M23 = ( float )( -( float )( ( double )zfar * ( double )znear ) / ( double )( zfar - znear ) );
        mtx.M30 = 0f;
        mtx.M31 = 0f;
        mtx.M32 = -1f;
        mtx.M33 = 0f;
    }

    // Token: 0x06000F54 RID: 3924 RVA: 0x00087CD8 File Offset: 0x00085ED8
    public static void nnMakeOrthoMatrix( AppMain.NNS_MATRIX mtx, float left, float right, float bottom, float top, float znear, float zfar )
    {
        mtx.M00 = ( float )( 2.0 / ( double )( right - left ) );
        mtx.M01 = 0f;
        mtx.M02 = 0f;
        mtx.M03 = ( float )( ( double )( -( double )( right + left ) ) / ( double )( right - left ) );
        mtx.M10 = 0f;
        mtx.M11 = ( float )( 2.0 / ( double )( top - bottom ) );
        mtx.M12 = 0f;
        mtx.M13 = ( float )( ( double )( -( double )( top + bottom ) ) / ( double )( top - bottom ) );
        mtx.M20 = 0f;
        mtx.M21 = 0f;
        mtx.M22 = ( float )( -1.0 / ( double )( zfar - znear ) );
        mtx.M23 = ( float )( ( double )( -( double )zfar ) / ( double )( zfar - znear ) );
        mtx.M30 = 0f;
        mtx.M31 = 0f;
        mtx.M32 = 0f;
        mtx.M33 = 1f;
    }

    // Token: 0x06001832 RID: 6194 RVA: 0x000D7DB4 File Offset: 0x000D5FB4
    private void nnCalcNodeMatrixNode( AppMain.NNS_MATRIX mtx, AppMain.NNS_OBJECT obj, int nodeidx )
    {
        AppMain.NNS_NODE nns_NODE = obj.pNodeList[nodeidx];
        if ( nns_NODE.iParent != -1 )
        {
            this.nnCalcNodeMatrixNode( mtx, obj, ( int )nns_NODE.iParent );
        }
        if ( ( nns_NODE.fType & 1U ) == 0U )
        {
            if ( ( nns_NODE.fType & 8192U ) != 0U )
            {
                AppMain.nnTranslateMatrixFast( mtx, nns_NODE.Translation.x, nns_NODE.Translation.y, nns_NODE.Translation.z );
            }
            else
            {
                AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
                AppMain.nnTransformVector( nns_VECTOR, AppMain.nncalcnodematrix.nnsBaseMtx, nns_NODE.Translation );
                AppMain.nnCopyVectorMatrixTranslation( mtx, nns_VECTOR );
            }
        }
        if ( ( nns_NODE.fType & 4096U ) != 0U )
        {
            AppMain.nnCopyMatrix33( mtx, AppMain.nncalcnodematrix.nnsBaseMtx );
        }
        else if ( ( nns_NODE.fType & 1835008U ) != 0U )
        {
            if ( ( nns_NODE.fType & 262144U ) != 0U )
            {
                AppMain.nnNormalizeColumn0( mtx );
            }
            if ( ( nns_NODE.fType & 524288U ) != 0U )
            {
                AppMain.nnNormalizeColumn1( mtx );
            }
            if ( ( nns_NODE.fType & 1048576U ) != 0U )
            {
                AppMain.nnNormalizeColumn2( mtx );
            }
        }
        if ( ( nns_NODE.fType & 2U ) == 0U )
        {
            uint num = nns_NODE.fType & 3840U;
            if ( num != 0U )
            {
                if ( num != 256U )
                {
                    if ( num != 1024U )
                    {
                        AppMain.nnRotateXYZMatrixFast( mtx, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                    }
                    else
                    {
                        AppMain.nnRotateZXYMatrixFast( mtx, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                    }
                }
                else
                {
                    AppMain.nnRotateXZYMatrixFast( mtx, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                }
            }
            else
            {
                AppMain.nnRotateXYZMatrixFast( mtx, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
            }
        }
        if ( ( nns_NODE.fType & 4U ) == 0U )
        {
            AppMain.nnScaleMatrixFast( mtx, nns_NODE.Scaling.x, nns_NODE.Scaling.y, nns_NODE.Scaling.z );
        }
    }

    // Token: 0x06001833 RID: 6195 RVA: 0x000D7FA8 File Offset: 0x000D61A8
    private void nnCalcNodeMatrix( AppMain.NNS_MATRIX mtx, AppMain.NNS_OBJECT obj, int nodeidx, AppMain.NNS_MATRIX basemtx )
    {
        if ( basemtx != null )
        {
            AppMain.nncalcnodematrix.nnsBaseMtx = basemtx;
        }
        else
        {
            AppMain.nncalcnodematrix.nnsBaseMtx = AppMain.nngUnitMatrix;
        }
        AppMain.nnCopyMatrix( mtx, AppMain.nncalcnodematrix.nnsBaseMtx );
        this.nnCalcNodeMatrixNode( mtx, obj, nodeidx );
    }

    // Token: 0x06001834 RID: 6196 RVA: 0x000D7FD8 File Offset: 0x000D61D8
    private void nnCalcNodeMatrixMotionNode( AppMain.NNS_MATRIX mtx, int nodeidx )
    {
        AppMain.NNS_MATRIX src = null;
        int num = 0;
        AppMain.NNS_NODE nns_NODE = AppMain.nncalcnodematrix.nnsNodeList[nodeidx];
        if ( ( nns_NODE.fType & 122880U ) == 0U )
        {
            if ( nns_NODE.iParent != -1 )
            {
                this.nnCalcNodeMatrixMotionNode( mtx, ( int )nns_NODE.iParent );
            }
            int? num2 = default(int?);
            AppMain.nncalcnodematrix.nnsSubMotIdx = AppMain.nnCalcNodeMotionCore( mtx, ref num2, AppMain.nncalcnodematrix.nnsBaseMtx, nns_NODE, nodeidx, AppMain.nncalcnodematrix.nnsObj, AppMain.nncalcnodematrix.nnsMot, AppMain.nncalcnodematrix.nnsSubMotIdx, AppMain.nncalcnodematrix.nnsFrame );
            return;
        }
        AppMain.NNS_NODE nns_NODE2 = null;
        AppMain.NNS_NODE nns_NODE3 = null;
        AppMain.NNS_NODE nns_NODE4 = null;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX4 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX5 = AppMain.GlobalPool<AppMain.NNS_MATRIX>.Alloc();
        AppMain.NNS_VECTORFAST src2 = default(AppMain.NNS_VECTORFAST);
        int nodeidx2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        if ( ( nns_NODE.fType & 8192U ) != 0U )
        {
            src = nns_MATRIX3;
            num5 = nodeidx;
            nns_NODE4 = nns_NODE;
            if ( ( AppMain.nncalcnodematrix.nnsNodeList[( int )nns_NODE.iParent].fType & 16384U ) != 0U )
            {
                num = 1;
                num3 = ( int )nns_NODE4.iParent;
                nns_NODE2 = AppMain.nncalcnodematrix.nnsNodeList[num3];
                nodeidx2 = ( int )nns_NODE2.iParent;
            }
            else if ( ( AppMain.nncalcnodematrix.nnsNodeList[( int )nns_NODE.iParent].fType & 65536U ) != 0U )
            {
                num = 2;
                num4 = ( int )nns_NODE4.iParent;
                nns_NODE3 = AppMain.nncalcnodematrix.nnsNodeList[num4];
                num3 = ( int )nns_NODE3.iParent;
                nns_NODE2 = AppMain.nncalcnodematrix.nnsNodeList[num3];
                nodeidx2 = ( int )nns_NODE2.iParent;
            }
        }
        else if ( ( nns_NODE.fType & 16384U ) != 0U )
        {
            src = nns_MATRIX;
            num = 1;
            num3 = nodeidx;
            nns_NODE2 = nns_NODE;
            nodeidx2 = ( int )nns_NODE2.iParent;
            num5 = ( int )nns_NODE2.iChild;
            nns_NODE4 = AppMain.nncalcnodematrix.nnsNodeList[num5];
        }
        else if ( ( nns_NODE.fType & 32768U ) != 0U )
        {
            src = nns_MATRIX;
            num = 2;
            num3 = nodeidx;
            nns_NODE2 = nns_NODE;
            nodeidx2 = ( int )nns_NODE2.iParent;
            num4 = ( int )nns_NODE2.iChild;
            nns_NODE3 = AppMain.nncalcnodematrix.nnsNodeList[num4];
            num5 = ( int )nns_NODE3.iChild;
            nns_NODE4 = AppMain.nncalcnodematrix.nnsNodeList[num5];
        }
        else if ( ( nns_NODE.fType & 65536U ) != 0U )
        {
            src = nns_MATRIX2;
            num = 2;
            num4 = nodeidx;
            nns_NODE3 = nns_NODE;
            num5 = ( int )nns_NODE3.iChild;
            nns_NODE4 = AppMain.nncalcnodematrix.nnsNodeList[num5];
            num3 = ( int )nns_NODE3.iParent;
            nns_NODE2 = AppMain.nncalcnodematrix.nnsNodeList[num3];
            nodeidx2 = ( int )nns_NODE2.iParent;
        }
        AppMain.nnCopyMatrix( nns_MATRIX, AppMain.nncalcnodematrix.nnsBaseMtx );
        this.nnCalcNodeMatrixMotionNode( nns_MATRIX, nodeidx2 );
        AppMain.nnMakeUnitMatrix( nns_MATRIX4 );
        int? num6 = default(int?);
        AppMain.nncalcnodematrix.nnsSubMotIdx = AppMain.nnCalcNodeMotionCore( nns_MATRIX4, ref num6, nns_MATRIX4, nns_NODE2, num3, AppMain.nncalcnodematrix.nnsObj, AppMain.nncalcnodematrix.nnsMot, AppMain.nncalcnodematrix.nnsSubMotIdx, AppMain.nncalcnodematrix.nnsFrame );
        float siikboneLength = nns_NODE2.SIIKBoneLength;
        if ( num == 1 )
        {
            AppMain.nnMakeUnitMatrix( nns_MATRIX3 );
            num6 = default( int? );
            AppMain.nncalcnodematrix.nnsSubMotIdx = AppMain.nnCalcNodeMotionCore( nns_MATRIX3, ref num6, nns_MATRIX3, nns_NODE4, num5, AppMain.nncalcnodematrix.nnsObj, AppMain.nncalcnodematrix.nnsMot, AppMain.nncalcnodematrix.nnsSubMotIdx, AppMain.nncalcnodematrix.nnsFrame );
            AppMain.nnCopyMatrixTranslationVectorFast( out src2, nns_MATRIX3 );
            AppMain.nnTransformVectorFast( out src2, AppMain.nncalcnodematrix.nnsBaseMtx, src2 );
            AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX3, ref src2 );
            AppMain.nnCalc1BoneSIIK( nns_MATRIX, nns_MATRIX4, nns_MATRIX3, siikboneLength );
            if ( ( nns_NODE4.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX3, AppMain.nncalcnodematrix.nnsBaseMtx );
            }
        }
        else if ( num == 2 )
        {
            AppMain.nnMakeUnitMatrix( nns_MATRIX5 );
            num6 = default( int? );
            AppMain.nncalcnodematrix.nnsSubMotIdx = AppMain.nnCalcNodeMotionCore( nns_MATRIX5, ref num6, nns_MATRIX5, nns_NODE3, num4, AppMain.nncalcnodematrix.nnsObj, AppMain.nncalcnodematrix.nnsMot, AppMain.nncalcnodematrix.nnsSubMotIdx, AppMain.nncalcnodematrix.nnsFrame );
            AppMain.nnMakeUnitMatrix( nns_MATRIX3 );
            AppMain.nncalcnodematrix.nnsSubMotIdx = AppMain.nnCalcNodeMotionCore( nns_MATRIX3, ref num6, nns_MATRIX3, nns_NODE4, num5, AppMain.nncalcnodematrix.nnsObj, AppMain.nncalcnodematrix.nnsMot, AppMain.nncalcnodematrix.nnsSubMotIdx, AppMain.nncalcnodematrix.nnsFrame );
            AppMain.nnCopyMatrixTranslationVectorFast( out src2, nns_MATRIX3 );
            AppMain.nnTransformVectorFast( out src2, AppMain.nncalcnodematrix.nnsBaseMtx, src2 );
            AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX3, ref src2 );
            int zpref;
            if ( ( nns_NODE3.fType & 131072U ) != 0U )
            {
                zpref = 1;
            }
            else
            {
                zpref = 0;
            }
            float siikboneLength2 = nns_NODE3.SIIKBoneLength;
            AppMain.nnCalc2BoneSIIK( nns_MATRIX, nns_MATRIX4, nns_MATRIX2, nns_MATRIX5, nns_MATRIX3, siikboneLength, siikboneLength2, zpref );
            if ( ( nns_NODE4.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX3, AppMain.nncalcnodematrix.nnsBaseMtx );
            }
        }
        AppMain.nnCopyMatrix( mtx, src );
    }

    // Token: 0x06001835 RID: 6197 RVA: 0x000D83C4 File Offset: 0x000D65C4
    private void nnCalcNodeMatrixMotion( AppMain.NNS_MATRIX mtx, AppMain.NNS_OBJECT obj, int nodeidx, AppMain.NNS_MOTION mot, float frame, AppMain.NNS_MATRIX basemtx )
    {
        if ( ( mot.fType & 1U ) != 0U )
        {
            float nnsFrame;
            int num = AppMain.nnCalcMotionFrame(out nnsFrame, mot.fType, mot.StartFrame, mot.EndFrame, frame);
            if ( num != 0 )
            {
                AppMain.nncalcnodematrix.nnsSubMotIdx = 0;
                if ( basemtx != null )
                {
                    AppMain.nnCopyMatrix( mtx, basemtx );
                    AppMain.nncalcnodematrix.nnsBaseMtx = basemtx;
                }
                else
                {
                    AppMain.nnCopyMatrix( mtx, AppMain.nngUnitMatrix );
                    AppMain.nncalcnodematrix.nnsBaseMtx = AppMain.nngUnitMatrix;
                }
                AppMain.nncalcnodematrix.nnsFrame = nnsFrame;
                AppMain.nncalcnodematrix.nnsObj = obj;
                AppMain.nncalcnodematrix.nnsMot = mot;
                AppMain.nncalcnodematrix.nnsNodeList = obj.pNodeList;
                this.nnCalcNodeMatrixMotionNode( mtx, nodeidx );
                return;
            }
            this.nnCalcNodeMatrix( mtx, obj, nodeidx, basemtx );
        }
    }

    // Token: 0x06001836 RID: 6198 RVA: 0x000D8464 File Offset: 0x000D6664
    private static void nnCalcNodeMatrixTRSListNode( AppMain.NNS_MATRIX mtx, AppMain.NNS_OBJECT obj, int nodeidx, AppMain.ArrayPointer<AppMain.NNS_TRS> trslist )
    {
        AppMain.NNS_NODE nns_NODE = null;
        AppMain.NNS_NODE nns_NODE2 = null;
        AppMain.NNS_MATRIX nns_MATRIX = AppMain.nnCalcNode_mtx_pool.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX2 = AppMain.nnCalcNode_mtx_pool.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX3 = AppMain.nnCalcNode_mtx_pool.Alloc();
        int nodeidx2 = 0;
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        AppMain.NNS_NODE nns_NODE3 = obj.pNodeList[nodeidx];
        AppMain.NNS_TRS nns_TRS = trslist[nodeidx];
        AppMain.NNS_MATRIX src;
        int num4;
        AppMain.NNS_NODE nns_NODE4;
        if ( ( nns_NODE3.fType & 8192U ) != 0U )
        {
            src = nns_MATRIX3;
            num4 = nodeidx;
            nns_NODE4 = nns_NODE3;
            if ( ( obj.pNodeList[( int )nns_NODE3.iParent].fType & 16384U ) != 0U )
            {
                num3 = 1;
                num = ( int )nns_NODE4.iParent;
                nns_NODE = obj.pNodeList[num];
                nodeidx2 = ( int )nns_NODE.iParent;
            }
            else if ( ( obj.pNodeList[( int )nns_NODE3.iParent].fType & 65536U ) != 0U )
            {
                num3 = 2;
                num2 = ( int )nns_NODE4.iParent;
                nns_NODE2 = obj.pNodeList[num2];
                num = ( int )nns_NODE2.iParent;
                nns_NODE = obj.pNodeList[num];
                nodeidx2 = ( int )nns_NODE.iParent;
            }
        }
        else if ( ( nns_NODE3.fType & 16384U ) != 0U )
        {
            src = nns_MATRIX;
            num3 = 1;
            num = nodeidx;
            nns_NODE = nns_NODE3;
            nodeidx2 = ( int )nns_NODE.iParent;
            num4 = ( int )nns_NODE.iChild;
            nns_NODE4 = obj.pNodeList[num4];
        }
        else if ( ( nns_NODE3.fType & 32768U ) != 0U )
        {
            src = nns_MATRIX;
            num3 = 2;
            num = nodeidx;
            nns_NODE = nns_NODE3;
            nodeidx2 = ( int )nns_NODE.iParent;
            num2 = ( int )nns_NODE.iChild;
            nns_NODE2 = obj.pNodeList[num2];
            num4 = ( int )nns_NODE2.iChild;
            nns_NODE4 = obj.pNodeList[num4];
        }
        else
        {
            if ( ( nns_NODE3.fType & 65536U ) == 0U )
            {
                AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX );
                AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX2 );
                AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX3 );
                if ( nns_NODE3.iParent != -1 )
                {
                    AppMain.nnCalcNodeMatrixTRSListNode( mtx, obj, ( int )nns_NODE3.iParent, trslist );
                }
                else
                {
                    AppMain.nnCopyMatrix( mtx, AppMain.nncalcnodematrix.nnsBaseMtx );
                }
                AppMain.nnTranslateMatrix( mtx, mtx, nns_TRS.Translation.x, nns_TRS.Translation.y, nns_TRS.Translation.z );
                if ( ( nns_NODE3.fType & 4096U ) != 0U )
                {
                    AppMain.nnCopyMatrix33( mtx, AppMain.nncalcnodematrix.nnsBaseMtx );
                }
                else if ( ( nns_NODE3.fType & 1835008U ) != 0U )
                {
                    if ( ( nns_NODE3.fType & 262144U ) != 0U )
                    {
                        AppMain.nnNormalizeColumn0( mtx );
                    }
                    if ( ( nns_NODE3.fType & 524288U ) != 0U )
                    {
                        AppMain.nnNormalizeColumn1( mtx );
                    }
                    if ( ( nns_NODE3.fType & 1048576U ) != 0U )
                    {
                        AppMain.nnNormalizeColumn2( mtx );
                    }
                }
                AppMain.nnQuaternionMatrix( mtx, mtx, ref nns_TRS.Rotation );
                AppMain.nnScaleMatrix( mtx, mtx, nns_TRS.Scaling.x, nns_TRS.Scaling.y, nns_TRS.Scaling.z );
                return;
            }
            src = nns_MATRIX2;
            num3 = 2;
            num2 = nodeidx;
            nns_NODE2 = nns_NODE3;
            num4 = ( int )nns_NODE2.iChild;
            nns_NODE4 = obj.pNodeList[num4];
            num = ( int )nns_NODE2.iParent;
            nns_NODE = obj.pNodeList[num];
            nodeidx2 = ( int )nns_NODE.iParent;
        }
        AppMain.NNS_MATRIX nns_MATRIX4 = AppMain.nnCalcNode_mtx_pool.Alloc();
        AppMain.NNS_MATRIX nns_MATRIX5 = AppMain.nnCalcNode_mtx_pool.Alloc();
        AppMain.NNS_VECTORFAST src2 = default(AppMain.NNS_VECTORFAST);
        AppMain.NNS_TRS nns_TRS2 = trslist + num;
        AppMain.NNS_TRS nns_TRS3 = trslist + num2;
        AppMain.NNS_TRS nns_TRS4 = trslist + num4;
        AppMain.nnCalcNodeMatrixTRSListNode( nns_MATRIX, obj, nodeidx2, trslist );
        AppMain.nnMakeUnitMatrix( nns_MATRIX4 );
        AppMain.nnTranslateMatrix( nns_MATRIX4, nns_MATRIX4, nns_TRS2.Translation.x, nns_TRS2.Translation.y, nns_TRS2.Translation.z );
        AppMain.nnQuaternionMatrix( nns_MATRIX4, nns_MATRIX4, ref nns_TRS2.Rotation );
        AppMain.nnScaleMatrix( nns_MATRIX4, nns_MATRIX4, nns_TRS2.Scaling.x, nns_TRS2.Scaling.y, nns_TRS2.Scaling.z );
        float siikboneLength = nns_NODE.SIIKBoneLength;
        if ( num3 == 1 )
        {
            AppMain.nnMakeUnitMatrix( nns_MATRIX3 );
            AppMain.nnTranslateMatrix( nns_MATRIX3, nns_MATRIX3, nns_TRS4.Translation.x, nns_TRS4.Translation.y, nns_TRS4.Translation.z );
            AppMain.nnQuaternionMatrix( nns_MATRIX3, nns_MATRIX3, ref nns_TRS4.Rotation );
            AppMain.nnScaleMatrix( nns_MATRIX3, nns_MATRIX3, nns_TRS4.Scaling.x, nns_TRS4.Scaling.y, nns_TRS4.Scaling.z );
            AppMain.nnCopyMatrixTranslationVectorFast( out src2, nns_MATRIX3 );
            AppMain.nnTransformVectorFast( out src2, AppMain.nncalcnodematrix.nnsBaseMtx, src2 );
            AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX3, ref src2 );
            AppMain.nnCalc1BoneSIIK( nns_MATRIX, nns_MATRIX4, nns_MATRIX3, siikboneLength );
            if ( ( nns_NODE4.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX3, AppMain.nncalcnodematrix.nnsBaseMtx );
            }
        }
        else if ( num3 == 2 )
        {
            AppMain.nnMakeUnitMatrix( nns_MATRIX5 );
            AppMain.nnTranslateMatrix( nns_MATRIX2, nns_MATRIX2, nns_TRS3.Translation.x, nns_TRS3.Translation.y, nns_TRS3.Translation.z );
            AppMain.nnQuaternionMatrix( nns_MATRIX2, nns_MATRIX2, ref nns_TRS3.Rotation );
            AppMain.nnScaleMatrix( nns_MATRIX2, nns_MATRIX2, nns_TRS3.Scaling.x, nns_TRS3.Scaling.y, nns_TRS3.Scaling.z );
            AppMain.nnMakeUnitMatrix( nns_MATRIX3 );
            AppMain.nnTranslateMatrix( nns_MATRIX3, nns_MATRIX3, nns_TRS4.Translation.x, nns_TRS4.Translation.y, nns_TRS4.Translation.z );
            AppMain.nnQuaternionMatrix( nns_MATRIX3, nns_MATRIX3, ref nns_TRS4.Rotation );
            AppMain.nnScaleMatrix( nns_MATRIX3, nns_MATRIX3, nns_TRS4.Scaling.x, nns_TRS4.Scaling.y, nns_TRS4.Scaling.z );
            AppMain.nnCopyMatrixTranslationVectorFast( out src2, nns_MATRIX3 );
            AppMain.nnTransformVectorFast( out src2, AppMain.nncalcnodematrix.nnsBaseMtx, src2 );
            AppMain.nnCopyVectorFastMatrixTranslation( nns_MATRIX3, ref src2 );
            int zpref;
            if ( ( nns_NODE2.fType & 131072U ) == 0U )
            {
                zpref = 1;
            }
            else
            {
                zpref = 0;
            }
            float siikboneLength2 = nns_NODE2.SIIKBoneLength;
            AppMain.nnCalc2BoneSIIK( nns_MATRIX, nns_MATRIX4, nns_MATRIX2, nns_MATRIX5, nns_MATRIX3, siikboneLength, siikboneLength2, zpref );
            if ( ( nns_NODE4.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX3, AppMain.nncalcnodematrix.nnsBaseMtx );
            }
        }
        AppMain.nnCopyMatrix( mtx, src );
        AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX4 );
        AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX5 );
        AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX );
        AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX2 );
        AppMain.nnCalcNode_mtx_pool.Release( nns_MATRIX3 );
    }

    // Token: 0x06001837 RID: 6199 RVA: 0x000D8A74 File Offset: 0x000D6C74
    private static void nnCalcNodeMatrixTRSList( AppMain.NNS_MATRIX mtx, AppMain.NNS_OBJECT obj, int nodeidx, AppMain.ArrayPointer<AppMain.NNS_TRS> trslist, AppMain.NNS_MATRIX basemtx )
    {
        if ( basemtx != null )
        {
            AppMain.nncalcnodematrix.nnsBaseMtx = basemtx;
        }
        else
        {
            AppMain.nncalcnodematrix.nnsBaseMtx = AppMain.nngUnitMatrix;
        }
        AppMain.nnCalcNodeMatrixTRSListNode( mtx, obj, nodeidx, trslist );
    }

    // Token: 0x06001838 RID: 6200 RVA: 0x000D8A98 File Offset: 0x000D6C98
    public static void nnCopyMatrix33( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        dst.M00 = src.M00;
        dst.M01 = src.M01;
        dst.M02 = src.M02;
        dst.M10 = src.M10;
        dst.M11 = src.M11;
        dst.M12 = src.M12;
        dst.M20 = src.M20;
        dst.M21 = src.M21;
        dst.M22 = src.M22;
    }

    // Token: 0x06001839 RID: 6201 RVA: 0x000D8B14 File Offset: 0x000D6D14
    public static void nnCopyMatrix33( ref AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX src )
    {
        dst.M00 = src.M00;
        dst.M01 = src.M01;
        dst.M02 = src.M02;
        dst.M10 = src.M10;
        dst.M11 = src.M11;
        dst.M12 = src.M12;
        dst.M20 = src.M20;
        dst.M21 = src.M21;
        dst.M22 = src.M22;
    }

    // Token: 0x0600183A RID: 6202 RVA: 0x000D8B90 File Offset: 0x000D6D90
    private static void nnCalcMatrixPaletteNode( int nodeIdx )
    {
        AppMain.NNS_NODE nns_NODE;
        do
        {
            nns_NODE = AppMain.nncalcmatrixpalette.nnsNodeList[nodeIdx];
            AppMain.nnPushMatrix( AppMain.nncalcmatrixpalette.nnsMstk, null );
            AppMain.NNS_MATRIX nns_MATRIX = AppMain.nnGetCurrentMatrix(AppMain.nncalcmatrixpalette.nnsMstk);
            if ( ( nns_NODE.fType & 1U ) == 0U )
            {
                if ( ( nns_NODE.fType & 8192U ) == 0U )
                {
                    AppMain.nnTranslateMatrixFast( nns_MATRIX, nns_NODE.Translation.x, nns_NODE.Translation.y, nns_NODE.Translation.z );
                }
                else
                {
                    AppMain.NNS_VECTOR nns_VECTOR = AppMain.GlobalPool<AppMain.NNS_VECTOR>.Alloc();
                    AppMain.nnTransformVector( nns_VECTOR, AppMain.nncalcmatrixpalette.nnsBaseMtx, nns_NODE.Translation );
                    AppMain.nnCopyVectorMatrixTranslation( nns_MATRIX, nns_VECTOR );
                    AppMain.GlobalPool<AppMain.NNS_VECTOR>.Release( nns_VECTOR );
                }
            }
            if ( ( nns_NODE.fType & 4096U ) != 0U )
            {
                AppMain.nnCopyMatrix33( nns_MATRIX, AppMain.nncalcmatrixpalette.nnsBaseMtx );
            }
            else if ( ( nns_NODE.fType & 1835008U ) != 0U )
            {
                if ( ( nns_NODE.fType & 262144U ) != 0U )
                {
                    AppMain.nnNormalizeColumn0( nns_MATRIX );
                }
                if ( ( nns_NODE.fType & 524288U ) != 0U )
                {
                    AppMain.nnNormalizeColumn1( nns_MATRIX );
                }
                if ( ( nns_NODE.fType & 1048576U ) != 0U )
                {
                    AppMain.nnNormalizeColumn2( nns_MATRIX );
                }
            }
            if ( ( nns_NODE.fType & 2U ) == 0U )
            {
                uint num = nns_NODE.fType & 3840U;
                if ( num != 0U )
                {
                    if ( num != 256U )
                    {
                        if ( num != 1024U )
                        {
                            AppMain.nnRotateXYZMatrixFast( nns_MATRIX, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                        }
                        else
                        {
                            AppMain.nnRotateZXYMatrixFast( nns_MATRIX, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                        }
                    }
                    else
                    {
                        AppMain.nnRotateXZYMatrixFast( nns_MATRIX, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                    }
                }
                else
                {
                    AppMain.nnRotateXYZMatrixFast( nns_MATRIX, nns_NODE.Rotation.x, nns_NODE.Rotation.y, nns_NODE.Rotation.z );
                }
            }
            if ( ( nns_NODE.fType & 4U ) == 0U )
            {
                AppMain.nnScaleMatrixFast( nns_MATRIX, nns_NODE.Scaling.x, nns_NODE.Scaling.y, nns_NODE.Scaling.z );
            }
            if ( nns_NODE.iMatrix != -1 )
            {
                if ( ( nns_NODE.fType & 8U ) != 0U )
                {
                    AppMain.nnCopyMatrix( AppMain.nncalcmatrixpalette.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX );
                }
                else
                {
                    AppMain.nnMultiplyMatrix( AppMain.nncalcmatrixpalette.nnsMtxPal[( int )nns_NODE.iMatrix], nns_MATRIX, nns_NODE.InvInitMtx );
                }
            }
            if ( AppMain.nncalcmatrixpalette.nnsNodeStatList != null )
            {
                if ( nodeIdx == 0 && AppMain.nncalcmatrixpalette.nnsNSFlag != 0U )
                {
                    AppMain.nncalcmatrixpalette.nnsRootScale = AppMain.nnEstimateMatrixScaling( nns_MATRIX );
                }
                AppMain.nnCalcClipSetNodeStatus( AppMain.nncalcmatrixpalette.nnsNodeStatList, AppMain.nncalcmatrixpalette.nnsNodeList, nodeIdx, nns_MATRIX, AppMain.nncalcmatrixpalette.nnsRootScale, AppMain.nncalcmatrixpalette.nnsNSFlag );
            }
            if ( nns_NODE.iChild != -1 )
            {
                AppMain.nnCalcMatrixPaletteNode( ( int )nns_NODE.iChild );
            }
            AppMain.nnPopMatrix( AppMain.nncalcmatrixpalette.nnsMstk );
            nodeIdx = ( int )nns_NODE.iSibling;
        }
        while ( nns_NODE.iSibling != -1 );
    }

    // Token: 0x0600183B RID: 6203 RVA: 0x000D8E30 File Offset: 0x000D7030
    private static void nnCalcMatrixPalette( AppMain.NNS_MATRIX[] mtxpal, uint[] nodestatlist, AppMain.NNS_OBJECT obj, AppMain.NNS_MATRIX basemtx, AppMain.NNS_MATRIXSTACK mstk, uint flag )
    {
        if ( basemtx != null )
        {
            AppMain.nncalcmatrixpalette.nnsBaseMtx = basemtx;
        }
        else
        {
            AppMain.nncalcmatrixpalette.nnsBaseMtx = AppMain.nngUnitMatrix;
        }
        AppMain.nnSetCurrentMatrix( mstk, AppMain.nncalcmatrixpalette.nnsBaseMtx );
        AppMain.nncalcmatrixpalette.nnsMtxPal = mtxpal;
        AppMain.nncalcmatrixpalette.nnsNodeStatList = nodestatlist;
        AppMain.nncalcmatrixpalette.nnsNSFlag = flag;
        AppMain.nncalcmatrixpalette.nnsNodeList = obj.pNodeList;
        AppMain.nncalcmatrixpalette.nnsMstk = mstk;
        AppMain.nnCalcMatrixPaletteNode( 0 );
    }

    // Token: 0x0600183C RID: 6204 RVA: 0x000D8E89 File Offset: 0x000D7089
    private static void nnPutCommonVertex( AppMain.NNS_VTXLIST_COMMON_DESC vdesc, int nIndexSetSize, ushort indices, AppMain.NNS_MATRIX mtxpal, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600183D RID: 6205 RVA: 0x000D8E90 File Offset: 0x000D7090
    private static void nnPutNormalVector( AppMain.NNS_VECTOR pos, AppMain.NNS_VECTOR nrm )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600183E RID: 6206 RVA: 0x000D8E97 File Offset: 0x000D7097
    private static void nnPutCommonVertexNormal( AppMain.NNS_VTXLIST_COMMON_DESC vdesc, int nIndexSetSize, ushort indices, AppMain.NNS_MATRIX mtxpal )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x0600183F RID: 6207 RVA: 0x000D8E9E File Offset: 0x000D709E
    private void nnDrawObjectCommonVertex( AppMain.NNS_VTXLISTPTR vlistptr, AppMain.NNS_PRIMLISTPTR plistptr, AppMain.NNS_MATRIX mtxpal, uint flag )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001840 RID: 6208 RVA: 0x000D8EA5 File Offset: 0x000D70A5
    private void nnDrawObjectCommonVertexNormal( AppMain.NNS_VTXLISTPTR vlistptr, AppMain.NNS_PRIMLISTPTR plistptr, AppMain.NNS_MATRIX mtxpal )
    {
        AppMain.mppAssertNotImpl();
    }

    // Token: 0x06001841 RID: 6209 RVA: 0x000D8EAC File Offset: 0x000D70AC
    public static uint NNM_GL_TEXTURE( int _slot )
    {
        return ( uint )( 33984 + _slot );
    }

    // Token: 0x06001842 RID: 6210 RVA: 0x000D8EB5 File Offset: 0x000D70B5
    public static uint NNM_GL_LIGHT( int _idx )
    {
        return ( uint )( 16384 + _idx );
    }

    // Token: 0x06001843 RID: 6211 RVA: 0x000D8EBE File Offset: 0x000D70BE
    private int nnCheckCollisionSS( ref AppMain.NNS_SPHERE sphere1, ref AppMain.NNS_SPHERE sphere2 )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06001844 RID: 6212 RVA: 0x000D8EC6 File Offset: 0x000D70C6
    private int nnCheckCollisionCC( ref AppMain.NNS_CAPSULE capsule1, ref AppMain.NNS_CAPSULE capsule2 )
    {
        AppMain.mppAssertNotImpl();
        return 1;
    }

    // Token: 0x06001845 RID: 6213 RVA: 0x000D8ECE File Offset: 0x000D70CE
    private int nnCheckCollisionBS( ref AppMain.NNS_BOX box, ref AppMain.NNS_SPHERE sphere )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06001846 RID: 6214 RVA: 0x000D8ED6 File Offset: 0x000D70D6
    private int nnCheckCollisionBB( ref AppMain.NNS_BOX box1, ref AppMain.NNS_BOX box2 )
    {
        AppMain.mppAssertNotImpl();
        return 1;
    }

    // Token: 0x06001847 RID: 6215 RVA: 0x000D8EE0 File Offset: 0x000D70E0
    public static void nnInitMaterialMotionObject( AppMain.NNS_OBJECT mmobj, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mmot )
    {
        int nMaterial = obj.nMaterial;
        mmobj.Assign( obj );
        mmobj.pMatPtrList = new AppMain.NNS_MATERIALPTR[nMaterial];
        for ( int i = 0; i < nMaterial; i++ )
        {
            mmobj.pMatPtrList[i] = new AppMain.NNS_MATERIALPTR( obj.pMatPtrList[i] );
        }
        if ( mmot != null )
        {
            if ( ( mmot.fType & 31U ) == 16U )
            {
                AppMain.ArrayPointer<AppMain.NNS_SUBMOTION> pointer = mmot.pSubmotion;
                int j = mmot.nSubmotion;
                for ( int k = 0; k < nMaterial; k++ )
                {
                    bool flag = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    bool[] array = AppMain.nnInitMaterialMotionObject_bTexOffsetMot;
                    Array.Clear( array, 0, 8 );
                    while ( j > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 >= k )
                        {
                            break;
                        }
                        pointer = ++pointer;
                        j--;
                    }
                    while ( j > 0 && ( int )( ~pointer ).Id0 == k )
                    {
                        uint num = (~pointer).fType & 4294967040U;
                        if ( num <= 65536U )
                        {
                            if ( num <= 4096U )
                            {
                                if ( num <= 1024U )
                                {
                                    if ( num == 512U || num == 1024U )
                                    {
                                        goto IL_1FF;
                                    }
                                }
                                else if ( num == 2048U || num == 3584U || num == 4096U )
                                {
                                    goto IL_1FF;
                                }
                            }
                            else if ( num <= 16384U )
                            {
                                if ( num == 8192U || num == 16384U )
                                {
                                    goto IL_1FF;
                                }
                            }
                            else if ( num == 32768U || num == 57344U || num == 65536U )
                            {
                                goto IL_1FF;
                            }
                        }
                        else if ( num <= 1835008U )
                        {
                            if ( num <= 262144U )
                            {
                                if ( num == 131072U || num == 262144U )
                                {
                                    goto IL_1FF;
                                }
                            }
                            else if ( num == 524288U || num == 1048576U || num == 1835008U )
                            {
                                goto IL_1FF;
                            }
                        }
                        else
                        {
                            if ( num <= 8388608U )
                            {
                                if ( num == 2097152U || num == 4194304U )
                                {
                                    flag = true;
                                    flag3 = true;
                                    goto IL_229;
                                }
                                if ( num != 8388608U )
                                {
                                    goto IL_229;
                                }
                            }
                            else if ( num != 16777216U && num != 25165824U )
                            {
                                if ( num != 33554432U )
                                {
                                    goto IL_229;
                                }
                                flag = true;
                                goto IL_229;
                            }
                            flag = true;
                            flag3 = true;
                            array[( int )( ~pointer ).Id1] = true;
                        }
                        IL_229:
                        pointer = ++pointer;
                        j--;
                        continue;
                        IL_1FF:
                        flag = true;
                        flag2 = true;
                        goto IL_229;
                    }
                    if ( flag )
                    {
                        uint fType = obj.pMatPtrList[k].fType;
                        if ( ( fType & 2U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC = (AppMain.NNS_MATERIAL_STDSHADER_DESC)obj.pMatPtrList[k].pMaterial;
                            AppMain.NNS_MATERIALPTR nns_MATERIALPTR = mmobj.pMatPtrList[k];
                            AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC2;
                            if ( ( fType & 4U ) != 0U )
                            {
                                nns_MATERIAL_STDSHADER_DESC2 = ( NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )( nns_MATERIALPTR.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE( ( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )nns_MATERIAL_STDSHADER_DESC ) );
                            }
                            else
                            {
                                nns_MATERIAL_STDSHADER_DESC2 = ( NNS_MATERIAL_STDSHADER_DESC )( nns_MATERIALPTR.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC( nns_MATERIAL_STDSHADER_DESC ) );
                            }
                            if ( flag2 )
                            {
                                nns_MATERIAL_STDSHADER_DESC2.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_STDSHADER_DESC.pColor );
                            }
                            if ( flag3 )
                            {
                                int nTex = nns_MATERIAL_STDSHADER_DESC.nTex;
                                nns_MATERIAL_STDSHADER_DESC2.pTexDesc = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[nTex];
                                for ( int l = 0; l < nTex; l++ )
                                {
                                    nns_MATERIAL_STDSHADER_DESC2.pTexDesc[l] = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC( nns_MATERIAL_STDSHADER_DESC.pTexDesc[l] );
                                    if ( array[l] )
                                    {
                                        nns_MATERIAL_STDSHADER_DESC2.pTexDesc[l].fType &= 3221225471U;
                                    }
                                }
                            }
                        }
                        else if ( ( fType & 8U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = (AppMain.NNS_MATERIAL_GLES11_DESC)obj.pMatPtrList[k].pMaterial;
                            AppMain.NNS_MATERIALPTR nns_MATERIALPTR2 = mmobj.pMatPtrList[k];
                            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC2 = (NNS_MATERIAL_GLES11_DESC)(nns_MATERIALPTR2.pMaterial = new AppMain.NNS_MATERIAL_GLES11_DESC(nns_MATERIAL_GLES11_DESC));
                            if ( flag2 )
                            {
                                nns_MATERIAL_GLES11_DESC2.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_GLES11_DESC.pColor );
                            }
                            if ( flag3 )
                            {
                                int nTex2 = nns_MATERIAL_GLES11_DESC.nTex;
                                nns_MATERIAL_GLES11_DESC2.pTexDesc = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[nTex2];
                                for ( int m = 0; m < nTex2; m++ )
                                {
                                    nns_MATERIAL_GLES11_DESC2.pTexDesc[m] = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC( ref nns_MATERIAL_GLES11_DESC.pTexDesc[m] );
                                    if ( array[m] )
                                    {
                                        AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] pTexDesc = nns_MATERIAL_GLES11_DESC2.pTexDesc;
                                        int num2 = m;
                                        pTexDesc[num2].fType = ( pTexDesc[num2].fType & 3221225471U );
                                    }
                                }
                            }
                        }
                        else if ( ( fType & 1U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC = (AppMain.NNS_MATERIAL_DESC)obj.pMatPtrList[k].pMaterial;
                            AppMain.NNS_MATERIALPTR nns_MATERIALPTR3 = mmobj.pMatPtrList[k];
                            AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC2 = (NNS_MATERIAL_DESC)(nns_MATERIALPTR3.pMaterial = new AppMain.NNS_MATERIAL_DESC(nns_MATERIAL_DESC));
                            if ( flag2 )
                            {
                                nns_MATERIAL_DESC2.pColor = new AppMain.NNS_MATERIAL_COLOR( nns_MATERIAL_DESC.pColor );
                            }
                            if ( flag3 )
                            {
                                int nTex3 = nns_MATERIAL_DESC.nTex;
                                nns_MATERIAL_DESC2.pTexDesc = new AppMain.NNS_MATERIAL_TEXMAP_DESC[nTex3];
                                for ( int n = 0; n < nTex3; n++ )
                                {
                                    nns_MATERIAL_DESC2.pTexDesc[n] = new AppMain.NNS_MATERIAL_TEXMAP_DESC( nns_MATERIAL_DESC.pTexDesc[n] );
                                    if ( array[n] )
                                    {
                                        nns_MATERIAL_DESC2.pTexDesc[n].fType &= 3221225471U;
                                    }
                                }
                            }
                        }
                    }
                }
                return;
            }
        }
        else
        {
            for ( int num3 = 0; num3 < nMaterial; num3++ )
            {
                uint fType2 = obj.pMatPtrList[num3].fType;
                if ( ( fType2 & 2U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC3 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)obj.pMatPtrList[num3].pMaterial;
                    AppMain.NNS_MATERIALPTR nns_MATERIALPTR4 = mmobj.pMatPtrList[num3];
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC4;
                    if ( ( fType2 & 4U ) != 0U )
                    {
                        nns_MATERIAL_STDSHADER_DESC4 = ( NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )( nns_MATERIALPTR4.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE( ( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )nns_MATERIAL_STDSHADER_DESC3 ) );
                    }
                    else
                    {
                        nns_MATERIAL_STDSHADER_DESC4 = ( NNS_MATERIAL_STDSHADER_DESC )( nns_MATERIALPTR4.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC( nns_MATERIAL_STDSHADER_DESC3 ) );
                    }
                    nns_MATERIAL_STDSHADER_DESC4.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_STDSHADER_DESC3.pColor );
                    nns_MATERIAL_STDSHADER_DESC4.pTexDesc = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[nns_MATERIAL_STDSHADER_DESC3.nTex];
                    for ( int num4 = 0; num4 < nns_MATERIAL_STDSHADER_DESC3.nTex; num4++ )
                    {
                        nns_MATERIAL_STDSHADER_DESC4.pTexDesc[num4] = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC( nns_MATERIAL_STDSHADER_DESC3.pTexDesc[num4] );
                    }
                }
                else if ( ( fType2 & 8U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC3 = (AppMain.NNS_MATERIAL_GLES11_DESC)obj.pMatPtrList[num3].pMaterial;
                    AppMain.NNS_MATERIALPTR nns_MATERIALPTR5 = mmobj.pMatPtrList[num3];
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC4 = (NNS_MATERIAL_GLES11_DESC)(nns_MATERIALPTR5.pMaterial = new AppMain.NNS_MATERIAL_GLES11_DESC(nns_MATERIAL_GLES11_DESC3));
                    nns_MATERIAL_GLES11_DESC4.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_GLES11_DESC3.pColor );
                    nns_MATERIAL_GLES11_DESC4.pTexDesc = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[nns_MATERIAL_GLES11_DESC3.nTex];
                    for ( int num5 = 0; num5 < nns_MATERIAL_GLES11_DESC3.nTex; num5++ )
                    {
                        nns_MATERIAL_GLES11_DESC4.pTexDesc[num5] = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC( ref nns_MATERIAL_GLES11_DESC3.pTexDesc[num5] );
                    }
                }
                else if ( ( fType2 & 1U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC3 = (AppMain.NNS_MATERIAL_DESC)obj.pMatPtrList[num3].pMaterial;
                    AppMain.NNS_MATERIALPTR nns_MATERIALPTR6 = mmobj.pMatPtrList[num3];
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC4 = (NNS_MATERIAL_DESC)(nns_MATERIALPTR6.pMaterial = new AppMain.NNS_MATERIAL_DESC(nns_MATERIAL_DESC3));
                    nns_MATERIAL_DESC4.pColor = new AppMain.NNS_MATERIAL_COLOR( nns_MATERIAL_DESC3.pColor );
                    nns_MATERIAL_DESC4.pTexDesc = new AppMain.NNS_MATERIAL_TEXMAP_DESC[nns_MATERIAL_DESC3.nTex];
                    for ( int num6 = 0; num6 < nns_MATERIAL_DESC3.nTex; num6++ )
                    {
                        nns_MATERIAL_DESC4.pTexDesc[num6] = new AppMain.NNS_MATERIAL_TEXMAP_DESC( nns_MATERIAL_DESC3.pTexDesc[num6] );
                    }
                }
            }
        }
    }

    // Token: 0x06001848 RID: 6216 RVA: 0x000D95C4 File Offset: 0x000D77C4
    public static void nnInitMaterialMotionObject_fast( AppMain.NNS_OBJECT mmobj, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mmot )
    {
        int nMaterial = obj.nMaterial;
        mmobj.Assign( obj );
        mmobj.pMatPtrList = AppMain.amDrawAlloc_NNS_MATERIALPTR( nMaterial );
        for ( int i = 0; i < nMaterial; i++ )
        {
            mmobj.pMatPtrList[i] = AppMain.amDrawAlloc_NNS_MATERIALPTR();
            mmobj.pMatPtrList[i].Assign( obj.pMatPtrList[i] );
        }
        if ( mmot != null )
        {
            if ( ( mmot.fType & 31U ) == 16U )
            {
                AppMain.ArrayPointer<AppMain.NNS_SUBMOTION> pointer = mmot.pSubmotion;
                int j = mmot.nSubmotion;
                for ( int k = 0; k < nMaterial; k++ )
                {
                    bool flag = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    bool[] array = AppMain.nnInitMaterialMotionObject_bTexOffsetMot;
                    Array.Clear( array, 0, 8 );
                    while ( j > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 >= k )
                        {
                            break;
                        }
                        pointer = ++pointer;
                        j--;
                    }
                    while ( j > 0 && ( int )( ~pointer ).Id0 == k )
                    {
                        uint num = (~pointer).fType & 4294967040U;
                        if ( num <= 65536U )
                        {
                            if ( num <= 4096U )
                            {
                                if ( num <= 1024U )
                                {
                                    if ( num == 512U || num == 1024U )
                                    {
                                        goto IL_20D;
                                    }
                                }
                                else if ( num == 2048U || num == 3584U || num == 4096U )
                                {
                                    goto IL_20D;
                                }
                            }
                            else if ( num <= 16384U )
                            {
                                if ( num == 8192U || num == 16384U )
                                {
                                    goto IL_20D;
                                }
                            }
                            else if ( num == 32768U || num == 57344U || num == 65536U )
                            {
                                goto IL_20D;
                            }
                        }
                        else if ( num <= 1835008U )
                        {
                            if ( num <= 262144U )
                            {
                                if ( num == 131072U || num == 262144U )
                                {
                                    goto IL_20D;
                                }
                            }
                            else if ( num == 524288U || num == 1048576U || num == 1835008U )
                            {
                                goto IL_20D;
                            }
                        }
                        else
                        {
                            if ( num <= 8388608U )
                            {
                                if ( num == 2097152U || num == 4194304U )
                                {
                                    flag = true;
                                    flag3 = true;
                                    goto IL_237;
                                }
                                if ( num != 8388608U )
                                {
                                    goto IL_237;
                                }
                            }
                            else if ( num != 16777216U && num != 25165824U )
                            {
                                if ( num != 33554432U )
                                {
                                    goto IL_237;
                                }
                                flag = true;
                                goto IL_237;
                            }
                            flag = true;
                            flag3 = true;
                            array[( int )( ~pointer ).Id1] = true;
                        }
                        IL_237:
                        pointer = ++pointer;
                        j--;
                        continue;
                        IL_20D:
                        flag = true;
                        flag2 = true;
                        goto IL_237;
                    }
                    if ( flag )
                    {
                        uint fType = obj.pMatPtrList[k].fType;
                        if ( ( fType & 2U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC = (AppMain.NNS_MATERIAL_STDSHADER_DESC)obj.pMatPtrList[k].pMaterial;
                            AppMain.NNS_MATERIALPTR nns_MATERIALPTR = mmobj.pMatPtrList[k];
                            AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC2;
                            if ( ( fType & 4U ) != 0U )
                            {
                                nns_MATERIAL_STDSHADER_DESC2 = ( NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )( nns_MATERIALPTR.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE( ( AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )nns_MATERIAL_STDSHADER_DESC ) );
                            }
                            else
                            {
                                nns_MATERIAL_STDSHADER_DESC2 = ( NNS_MATERIAL_STDSHADER_DESC )( nns_MATERIALPTR.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC( nns_MATERIAL_STDSHADER_DESC ) );
                            }
                            if ( flag2 )
                            {
                                nns_MATERIAL_STDSHADER_DESC2.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_STDSHADER_DESC.pColor );
                            }
                            if ( flag3 )
                            {
                                int nTex = nns_MATERIAL_STDSHADER_DESC.nTex;
                                nns_MATERIAL_STDSHADER_DESC2.pTexDesc = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[nTex];
                                for ( int l = 0; l < nTex; l++ )
                                {
                                    nns_MATERIAL_STDSHADER_DESC2.pTexDesc[l] = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC( nns_MATERIAL_STDSHADER_DESC.pTexDesc[l] );
                                    if ( array[l] )
                                    {
                                        nns_MATERIAL_STDSHADER_DESC2.pTexDesc[l].fType &= 3221225471U;
                                    }
                                }
                            }
                        }
                        else if ( ( fType & 8U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = (AppMain.NNS_MATERIAL_GLES11_DESC)obj.pMatPtrList[k].pMaterial;
                            AppMain.NNS_MATERIALPTR nns_MATERIALPTR2 = mmobj.pMatPtrList[k];
                            AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC2 = (NNS_MATERIAL_GLES11_DESC)(nns_MATERIALPTR2.pMaterial = AppMain.amDrawAlloc_NNS_MATERIAL_GLES11_DESC());
                            nns_MATERIAL_GLES11_DESC2.Assign( nns_MATERIAL_GLES11_DESC );
                            if ( flag2 )
                            {
                                nns_MATERIAL_GLES11_DESC2.pColor = AppMain.amDrawAlloc_NNS_MATERIAL_STDSHADER_COLOR();
                                nns_MATERIAL_GLES11_DESC2.pColor.Assign( nns_MATERIAL_GLES11_DESC.pColor );
                            }
                            if ( flag3 )
                            {
                                int nTex2 = nns_MATERIAL_GLES11_DESC.nTex;
                                nns_MATERIAL_GLES11_DESC2.pTexDesc = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[nTex2];
                                for ( int m = 0; m < nTex2; m++ )
                                {
                                    nns_MATERIAL_GLES11_DESC2.pTexDesc[m] = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC( ref nns_MATERIAL_GLES11_DESC.pTexDesc[m] );
                                    if ( array[m] )
                                    {
                                        AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] pTexDesc = nns_MATERIAL_GLES11_DESC2.pTexDesc;
                                        int num2 = m;
                                        pTexDesc[num2].fType = ( pTexDesc[num2].fType & 3221225471U );
                                    }
                                }
                            }
                        }
                        else if ( ( fType & 1U ) != 0U )
                        {
                            AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC = (AppMain.NNS_MATERIAL_DESC)obj.pMatPtrList[k].pMaterial;
                            AppMain.NNS_MATERIALPTR nns_MATERIALPTR3 = mmobj.pMatPtrList[k];
                            AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC2 = (NNS_MATERIAL_DESC)(nns_MATERIALPTR3.pMaterial = new AppMain.NNS_MATERIAL_DESC(nns_MATERIAL_DESC));
                            if ( flag2 )
                            {
                                nns_MATERIAL_DESC2.pColor = new AppMain.NNS_MATERIAL_COLOR( nns_MATERIAL_DESC.pColor );
                            }
                            if ( flag3 )
                            {
                                int nTex3 = nns_MATERIAL_DESC.nTex;
                                nns_MATERIAL_DESC2.pTexDesc = new AppMain.NNS_MATERIAL_TEXMAP_DESC[nTex3];
                                for ( int n = 0; n < nTex3; n++ )
                                {
                                    nns_MATERIAL_DESC2.pTexDesc[n] = new AppMain.NNS_MATERIAL_TEXMAP_DESC( nns_MATERIAL_DESC.pTexDesc[n] );
                                    if ( array[n] )
                                    {
                                        nns_MATERIAL_DESC2.pTexDesc[n].fType &= 3221225471U;
                                    }
                                }
                            }
                        }
                    }
                }
                return;
            }
        }
        else
        {
            for ( int num3 = 0; num3 < nMaterial; num3++ )
            {
                uint fType2 = obj.pMatPtrList[num3].fType;
                if ( ( fType2 & 2U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC3 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)obj.pMatPtrList[num3].pMaterial;
                    AppMain.NNS_MATERIALPTR nns_MATERIALPTR4 = mmobj.pMatPtrList[num3];
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC4;
                    if ( ( fType2 & 4U ) != 0U )
                    {
                        nns_MATERIAL_STDSHADER_DESC4 = ( NNS_MATERIAL_STDSHADER_DESC )( nns_MATERIALPTR4.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE( ( NNS_MATERIAL_STDSHADER_DESC_USER_PROFILE )nns_MATERIAL_STDSHADER_DESC3 ) );
                    }
                    else
                    {
                        nns_MATERIAL_STDSHADER_DESC4 = ( NNS_MATERIAL_STDSHADER_DESC )( nns_MATERIALPTR4.pMaterial = new AppMain.NNS_MATERIAL_STDSHADER_DESC( nns_MATERIAL_STDSHADER_DESC3 ) );
                    }
                    nns_MATERIAL_STDSHADER_DESC4.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_STDSHADER_DESC3.pColor );
                    nns_MATERIAL_STDSHADER_DESC4.pTexDesc = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[nns_MATERIAL_STDSHADER_DESC3.nTex];
                    for ( int num4 = 0; num4 < nns_MATERIAL_STDSHADER_DESC3.nTex; num4++ )
                    {
                        nns_MATERIAL_STDSHADER_DESC4.pTexDesc[num4] = new AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC( nns_MATERIAL_STDSHADER_DESC3.pTexDesc[num4] );
                    }
                }
                else if ( ( fType2 & 8U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC3 = (AppMain.NNS_MATERIAL_GLES11_DESC)obj.pMatPtrList[num3].pMaterial;
                    AppMain.NNS_MATERIALPTR nns_MATERIALPTR5 = mmobj.pMatPtrList[num3];
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC4 = (NNS_MATERIAL_GLES11_DESC)(nns_MATERIALPTR5.pMaterial = new AppMain.NNS_MATERIAL_GLES11_DESC(nns_MATERIAL_GLES11_DESC3));
                    nns_MATERIAL_GLES11_DESC4.pColor = new AppMain.NNS_MATERIAL_STDSHADER_COLOR( nns_MATERIAL_GLES11_DESC3.pColor );
                    nns_MATERIAL_GLES11_DESC4.pTexDesc = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[nns_MATERIAL_GLES11_DESC3.nTex];
                    for ( int num5 = 0; num5 < nns_MATERIAL_GLES11_DESC3.nTex; num5++ )
                    {
                        nns_MATERIAL_GLES11_DESC4.pTexDesc[num5] = new AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC( ref nns_MATERIAL_GLES11_DESC3.pTexDesc[num5] );
                    }
                }
                else if ( ( fType2 & 1U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC3 = (AppMain.NNS_MATERIAL_DESC)obj.pMatPtrList[num3].pMaterial;
                    AppMain.NNS_MATERIALPTR nns_MATERIALPTR6 = mmobj.pMatPtrList[num3];
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC4 = (NNS_MATERIAL_DESC)(nns_MATERIALPTR6.pMaterial = new AppMain.NNS_MATERIAL_DESC(nns_MATERIAL_DESC3));
                    nns_MATERIAL_DESC4.pColor = new AppMain.NNS_MATERIAL_COLOR( nns_MATERIAL_DESC3.pColor );
                    nns_MATERIAL_DESC4.pTexDesc = new AppMain.NNS_MATERIAL_TEXMAP_DESC[nns_MATERIAL_DESC3.nTex];
                    for ( int num6 = 0; num6 < nns_MATERIAL_DESC3.nTex; num6++ )
                    {
                        nns_MATERIAL_DESC4.pTexDesc[num6] = new AppMain.NNS_MATERIAL_TEXMAP_DESC( nns_MATERIAL_DESC3.pTexDesc[num6] );
                    }
                }
            }
        }
    }

    // Token: 0x06001849 RID: 6217 RVA: 0x000D9CCC File Offset: 0x000D7ECC
    public static int nnInterpolateFloat( ref float val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nnCalcMotionFrame( out frame, submot.fIPType, submot.StartFrame, submot.EndFrame, frame ) != 0 )
        {
            uint num = submot.fIPType & 3703U;
            switch ( num )
            {
                case 2U:
                    AppMain.nnInterpolateLinearF1( ( AppMain.NNS_MOTION_KEY_Class1[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
                case 3U:
                    break;
                case 4U:
                    AppMain.nnInterpolateConstantF1( ( AppMain.NNS_MOTION_KEY_Class1[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
                default:
                    if ( num == 16U )
                    {
                        AppMain.nnInterpolateBezierF1( ( AppMain.NNS_MOTION_KEY_Class2[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                        return 1;
                    }
                    if ( num == 32U )
                    {
                        AppMain.nnInterpolateSISplineF1( ( AppMain.NNS_MOTION_KEY_Class3[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                        return 1;
                    }
                    break;
            }
        }
        return 0;
    }

    // Token: 0x0600184A RID: 6218 RVA: 0x000D9D90 File Offset: 0x000D7F90
    public static int nnInterpolateFloat2( AppMain.NNS_TEXCOORD val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nnCalcMotionFrame( out frame, submot.fIPType, submot.StartFrame, submot.EndFrame, frame ) != 0 )
        {
            switch ( submot.fIPType & 3703U )
            {
                case 2U:
                    AppMain.nnInterpolateLinearF2( ( AppMain.NNS_MOTION_KEY_Class4[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
                case 4U:
                    AppMain.nnInterpolateConstantF2( ( AppMain.NNS_MOTION_KEY_Class4[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
            }
        }
        return 0;
    }

    // Token: 0x0600184B RID: 6219 RVA: 0x000D9E14 File Offset: 0x000D8014
    public static int nnInterpolateFloat3( AppMain.NNS_VECTOR val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nnCalcMotionFrame( out frame, submot.fIPType, submot.StartFrame, submot.EndFrame, frame ) != 0 )
        {
            switch ( submot.fIPType & 3703U )
            {
                case 2U:
                    AppMain.nnInterpolateLinearF3( ( AppMain.NNS_MOTION_KEY_Class5[] )submot.pKeyList, submot.nKeyFrame, frame, val );
                    return 1;
                case 4U:
                    AppMain.nnInterpolateConstantF3( ( AppMain.NNS_MOTION_KEY_Class5[] )submot.pKeyList, submot.nKeyFrame, frame, val );
                    return 1;
            }
        }
        return 0;
    }

    // Token: 0x0600184C RID: 6220 RVA: 0x000D9E98 File Offset: 0x000D8098
    public static int nnInterpolateFloat3( ref AppMain.SNNS_VECTOR val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nnCalcMotionFrame( out frame, submot.fIPType, submot.StartFrame, submot.EndFrame, frame ) != 0 )
        {
            switch ( submot.fIPType & 3703U )
            {
                case 2U:
                    AppMain.nnInterpolateLinearF3( ( AppMain.NNS_MOTION_KEY_Class5[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
                case 4U:
                    AppMain.nnInterpolateConstantF3( ( AppMain.NNS_MOTION_KEY_Class5[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
            }
        }
        return 0;
    }

    // Token: 0x0600184D RID: 6221 RVA: 0x000D9F1C File Offset: 0x000D811C
    public static int nnInterpolateFloat3( ref AppMain.NNS_RGBA _val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        AppMain.SNNS_VECTOR snns_VECTOR;
        snns_VECTOR.x = _val.r;
        snns_VECTOR.y = _val.g;
        snns_VECTOR.z = _val.b;
        int result = AppMain.nnInterpolateFloat3(ref snns_VECTOR, submot, frame);
        _val.r = snns_VECTOR.x;
        _val.g = snns_VECTOR.y;
        _val.b = snns_VECTOR.z;
        return result;
    }

    // Token: 0x0600184E RID: 6222 RVA: 0x000D9F84 File Offset: 0x000D8184
    public static int nnInterpolateUint32( ref uint val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nnCalcMotionFrame( out frame, submot.fIPType, submot.StartFrame, submot.EndFrame, frame ) != 0 )
        {
            uint num = submot.fIPType & 3703U;
            switch ( num )
            {
                case 2U:
                    AppMain.nnInterpolateLinearU1( ( AppMain.NNS_MOTION_KEY_Class12[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
                case 3U:
                    break;
                case 4U:
                    AppMain.nnInterpolateConstantU1( ( AppMain.NNS_MOTION_KEY_Class12[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    return 1;
                default:
                    if ( num == 64U )
                    {
                        return AppMain.nnInterpolateTriggerU1( ( AppMain.NNS_MOTION_KEY_Class12[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                    }
                    break;
            }
        }
        return 0;
    }

    // Token: 0x0600184F RID: 6223 RVA: 0x000DA024 File Offset: 0x000D8224
    public static int nnInterpolateSint32( ref int val, AppMain.NNS_SUBMOTION submot, float frame )
    {
        if ( AppMain.nnCalcMotionFrame( out frame, submot.fIPType, submot.StartFrame, submot.EndFrame, frame ) != 0 )
        {
            uint num = submot.fIPType & 3703U;
            if ( num == 4U )
            {
                AppMain.nnInterpolateConstantS32_1( ( AppMain.NNS_MOTION_KEY_Class11[] )submot.pKeyList, submot.nKeyFrame, frame, out val );
                return 1;
            }
        }
        return 0;
    }

    // Token: 0x06001850 RID: 6224 RVA: 0x000DA07C File Offset: 0x000D827C
    public static void nnCalcMaterialMotion( AppMain.NNS_OBJECT mmobj, AppMain.NNS_OBJECT obj, AppMain.NNS_MOTION mmot, float frame )
    {
        int nMaterial = obj.nMaterial;
        if ( ( mmot.fType & 31U ) != 16U )
        {
            return;
        }
        for ( int i = 0; i < nMaterial; i++ )
        {
            uint fType = obj.pMatPtrList[i].fType;
            if ( ( fType & 2U ) != 0U )
            {
                AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC = (AppMain.NNS_MATERIAL_STDSHADER_DESC)obj.pMatPtrList[i].pMaterial;
                AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC2 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)mmobj.pMatPtrList[i].pMaterial;
                if ( nns_MATERIAL_STDSHADER_DESC != nns_MATERIAL_STDSHADER_DESC2 )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor = nns_MATERIAL_STDSHADER_DESC.pColor;
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor2 = nns_MATERIAL_STDSHADER_DESC2.pColor;
                    AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[] pTexDesc = nns_MATERIAL_STDSHADER_DESC.pTexDesc;
                    AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[] pTexDesc2 = nns_MATERIAL_STDSHADER_DESC2.pTexDesc;
                    nns_MATERIAL_STDSHADER_DESC2.User = nns_MATERIAL_STDSHADER_DESC.User;
                    if ( pColor != pColor2 )
                    {
                        pColor2.Ambient = pColor.Ambient;
                        pColor2.Diffuse = pColor.Diffuse;
                        pColor2.Specular = pColor.Specular;
                        pColor2.Shininess = pColor.Shininess;
                        pColor2.SpecularIntensity = pColor.SpecularIntensity;
                    }
                    if ( pTexDesc != pTexDesc2 )
                    {
                        int nTex = nns_MATERIAL_STDSHADER_DESC.nTex;
                        for ( int j = 0; j < nTex; j++ )
                        {
                            pTexDesc2[j].iTexIdx = pTexDesc[j].iTexIdx;
                            pTexDesc2[j].Blend = pTexDesc[j].Blend;
                            pTexDesc2[j].Offset = pTexDesc[j].Offset;
                        }
                    }
                }
            }
            else if ( ( fType & 8U ) != 0U )
            {
                AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC = (AppMain.NNS_MATERIAL_GLES11_DESC)obj.pMatPtrList[i].pMaterial;
                AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC2 = (AppMain.NNS_MATERIAL_GLES11_DESC)mmobj.pMatPtrList[i].pMaterial;
                if ( nns_MATERIAL_GLES11_DESC != nns_MATERIAL_GLES11_DESC2 )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor3 = nns_MATERIAL_GLES11_DESC.pColor;
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor4 = nns_MATERIAL_GLES11_DESC2.pColor;
                    AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] pTexDesc3 = nns_MATERIAL_GLES11_DESC.pTexDesc;
                    AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] pTexDesc4 = nns_MATERIAL_GLES11_DESC2.pTexDesc;
                    nns_MATERIAL_GLES11_DESC2.User = nns_MATERIAL_GLES11_DESC.User;
                    if ( pColor3 != pColor4 )
                    {
                        pColor4.Ambient = pColor3.Ambient;
                        pColor4.Diffuse = pColor3.Diffuse;
                        pColor4.Specular = pColor3.Specular;
                        pColor4.Shininess = pColor3.Shininess;
                        pColor4.SpecularIntensity = pColor3.SpecularIntensity;
                    }
                    if ( pTexDesc3 != pTexDesc4 )
                    {
                        int nTex2 = nns_MATERIAL_GLES11_DESC.nTex;
                        for ( int k = 0; k < nTex2; k++ )
                        {
                            pTexDesc4[k].iTexIdx = pTexDesc3[k].iTexIdx;
                            pTexDesc4[k].Offset = pTexDesc3[k].Offset;
                        }
                    }
                }
            }
            else if ( ( fType & 1U ) != 0U )
            {
                AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC = (AppMain.NNS_MATERIAL_DESC)obj.pMatPtrList[i].pMaterial;
                AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC2 = (AppMain.NNS_MATERIAL_DESC)mmobj.pMatPtrList[i].pMaterial;
                if ( nns_MATERIAL_DESC != nns_MATERIAL_DESC2 )
                {
                    AppMain.NNS_MATERIAL_COLOR pColor5 = nns_MATERIAL_DESC.pColor;
                    AppMain.NNS_MATERIAL_COLOR pColor6 = nns_MATERIAL_DESC2.pColor;
                    AppMain.NNS_MATERIAL_TEXMAP_DESC[] pTexDesc5 = nns_MATERIAL_DESC.pTexDesc;
                    AppMain.NNS_MATERIAL_TEXMAP_DESC[] pTexDesc6 = nns_MATERIAL_DESC2.pTexDesc;
                    nns_MATERIAL_DESC2.User = nns_MATERIAL_DESC.User;
                    if ( pColor5 != pColor6 )
                    {
                        pColor6.Ambient = pColor5.Ambient;
                        pColor6.Diffuse = pColor5.Diffuse;
                        pColor6.Specular = pColor5.Specular;
                        pColor6.Shininess = pColor5.Shininess;
                    }
                    if ( pTexDesc5 != pTexDesc6 )
                    {
                        int nTex3 = nns_MATERIAL_DESC.nTex;
                        for ( int l = 0; l < nTex3; l++ )
                        {
                            pTexDesc6[l].iTexIdx = pTexDesc5[l].iTexIdx;
                            pTexDesc6[l].EnvColor = pTexDesc5[l].EnvColor;
                            pTexDesc6[l].Offset = pTexDesc5[l].Offset;
                        }
                    }
                }
            }
        }
        if ( AppMain.nnCalcMotionFrame( out frame, mmot.fType, mmot.StartFrame, mmot.EndFrame, frame ) != 0 )
        {
            AppMain.ArrayPointer<AppMain.NNS_SUBMOTION> pointer = mmot.pSubmotion;
            int m = mmot.nSubmotion;
            for ( int i = 0; i < nMaterial; i++ )
            {
                uint fType2 = obj.pMatPtrList[i].fType;
                if ( ( fType2 & 2U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_STDSHADER_DESC nns_MATERIAL_STDSHADER_DESC3 = (AppMain.NNS_MATERIAL_STDSHADER_DESC)mmobj.pMatPtrList[i].pMaterial;
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor7 = nns_MATERIAL_STDSHADER_DESC3.pColor;
                    AppMain.NNS_MATERIAL_STDSHADER_TEXMAP_DESC[] pTexDesc7 = nns_MATERIAL_STDSHADER_DESC3.pTexDesc;
                    while ( m > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 >= i )
                        {
                            break;
                        }
                        pointer = ++pointer;
                        m--;
                    }
                    while ( m > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 != i )
                        {
                            break;
                        }
                        uint num = (~pointer).fType & 4294967040U;
                        if ( num <= 65536U )
                        {
                            if ( num <= 4096U )
                            {
                                if ( num <= 1024U )
                                {
                                    if ( num != 512U )
                                    {
                                        if ( num == 1024U )
                                        {
                                            AppMain.nnInterpolateFloat( ref pColor7.Diffuse.g, pointer, frame );
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor7.Diffuse.r, pointer, frame );
                                    }
                                }
                                else if ( num != 2048U )
                                {
                                    if ( num != 3584U )
                                    {
                                        if ( num == 4096U )
                                        {
                                            AppMain.nnInterpolateFloat( ref pColor7.Diffuse.a, pointer, frame );
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateFloat3( ref pColor7.Diffuse, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor7.Diffuse.b, pointer, frame );
                                }
                            }
                            else if ( num <= 16384U )
                            {
                                if ( num != 8192U )
                                {
                                    if ( num == 16384U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor7.Specular.g, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor7.Specular.r, pointer, frame );
                                }
                            }
                            else if ( num != 32768U )
                            {
                                if ( num != 57344U )
                                {
                                    if ( num == 65536U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor7.SpecularIntensity, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat3( ref pColor7.Specular, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat( ref pColor7.Specular.b, pointer, frame );
                            }
                        }
                        else if ( num <= 1835008U )
                        {
                            if ( num <= 262144U )
                            {
                                if ( num != 131072U )
                                {
                                    if ( num == 262144U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor7.Ambient.r, pointer, frame );
                                    }
                                }
                                else
                                {
                                    float num2 = 0f;
                                    if ( AppMain.nnInterpolateFloat( ref num2, pointer, frame ) != 0 )
                                    {
                                        pColor7.Shininess = AppMain.nnPow( 2.0, ( double )( 10f * num2 + 2f ) );
                                    }
                                }
                            }
                            else if ( num != 524288U )
                            {
                                if ( num != 1048576U )
                                {
                                    if ( num == 1835008U )
                                    {
                                        AppMain.nnInterpolateFloat3( ref pColor7.Ambient, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor7.Ambient.b, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat( ref pColor7.Ambient.g, pointer, frame );
                            }
                        }
                        else if ( num <= 8388608U )
                        {
                            if ( num != 2097152U )
                            {
                                if ( num != 4194304U )
                                {
                                    if ( num == 8388608U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pTexDesc7[( int )( ~pointer ).Id1].Offset.u, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pTexDesc7[( int )( ~pointer ).Id1].Blend, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateSint32( ref pTexDesc7[( int )( ~pointer ).Id1].iTexIdx, pointer, frame );
                            }
                        }
                        else if ( num != 16777216U )
                        {
                            if ( num != 25165824U )
                            {
                                if ( num == 33554432U )
                                {
                                    AppMain.nnInterpolateUint32( ref nns_MATERIAL_STDSHADER_DESC3.User, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat2( pTexDesc7[( int )( ~pointer ).Id1].Offset, pointer, frame );
                            }
                        }
                        else
                        {
                            AppMain.nnInterpolateFloat( ref pTexDesc7[( int )( ~pointer ).Id1].Offset.v, pointer, frame );
                        }
                        pointer = ++pointer;
                        m--;
                    }
                }
                else if ( ( fType2 & 8U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_GLES11_DESC nns_MATERIAL_GLES11_DESC3 = (AppMain.NNS_MATERIAL_GLES11_DESC)mmobj.pMatPtrList[i].pMaterial;
                    AppMain.NNS_MATERIAL_STDSHADER_COLOR pColor8 = nns_MATERIAL_GLES11_DESC3.pColor;
                    AppMain.NNS_MATERIAL_GLES11_TEXMAP_DESC[] pTexDesc8 = nns_MATERIAL_GLES11_DESC3.pTexDesc;
                    while ( m > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 >= i )
                        {
                            break;
                        }
                        pointer = ++pointer;
                        m--;
                    }
                    while ( m > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 != i )
                        {
                            break;
                        }
                        uint num3 = (~pointer).fType & 4294967040U;
                        if ( num3 <= 65536U )
                        {
                            if ( num3 <= 4096U )
                            {
                                if ( num3 <= 1024U )
                                {
                                    if ( num3 != 512U )
                                    {
                                        if ( num3 == 1024U )
                                        {
                                            AppMain.nnInterpolateFloat( ref pColor8.Diffuse.g, pointer, frame );
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor8.Diffuse.r, pointer, frame );
                                    }
                                }
                                else if ( num3 != 2048U )
                                {
                                    if ( num3 != 3584U )
                                    {
                                        if ( num3 == 4096U )
                                        {
                                            AppMain.nnInterpolateFloat( ref pColor8.Diffuse.a, pointer, frame );
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateFloat3( ref pColor8.Diffuse, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor8.Diffuse.b, pointer, frame );
                                }
                            }
                            else if ( num3 <= 16384U )
                            {
                                if ( num3 != 8192U )
                                {
                                    if ( num3 == 16384U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor8.Specular.g, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor8.Specular.r, pointer, frame );
                                }
                            }
                            else if ( num3 != 32768U )
                            {
                                if ( num3 != 57344U )
                                {
                                    if ( num3 == 65536U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor8.SpecularIntensity, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat3( ref pColor8.Specular, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat( ref pColor8.Specular.b, pointer, frame );
                            }
                        }
                        else if ( num3 <= 1835008U )
                        {
                            if ( num3 <= 262144U )
                            {
                                if ( num3 != 131072U )
                                {
                                    if ( num3 == 262144U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor8.Ambient.r, pointer, frame );
                                    }
                                }
                                else
                                {
                                    float num4 = 0f;
                                    if ( AppMain.nnInterpolateFloat( ref num4, pointer, frame ) != 0 )
                                    {
                                        pColor8.Shininess = AppMain.nnPow( 2.0, ( double )( 10f * num4 + 2f ) );
                                    }
                                }
                            }
                            else if ( num3 != 524288U )
                            {
                                if ( num3 != 1048576U )
                                {
                                    if ( num3 == 1835008U )
                                    {
                                        AppMain.nnInterpolateFloat3( ref pColor8.Ambient, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor8.Ambient.b, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat( ref pColor8.Ambient.g, pointer, frame );
                            }
                        }
                        else if ( num3 <= 8388608U )
                        {
                            if ( num3 != 2097152U )
                            {
                                if ( num3 != 4194304U )
                                {
                                    if ( num3 == 8388608U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pTexDesc8[( int )( ~pointer ).Id1].Offset.u, pointer, frame );
                                    }
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateSint32( ref pTexDesc8[( int )( ~pointer ).Id1].iTexIdx, pointer, frame );
                            }
                        }
                        else if ( num3 != 16777216U )
                        {
                            if ( num3 != 25165824U )
                            {
                                if ( num3 == 33554432U )
                                {
                                    AppMain.nnInterpolateUint32( ref nns_MATERIAL_GLES11_DESC3.User, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat2( pTexDesc8[( int )( ~pointer ).Id1].Offset, pointer, frame );
                            }
                        }
                        else
                        {
                            AppMain.nnInterpolateFloat( ref pTexDesc8[( int )( ~pointer ).Id1].Offset.v, pointer, frame );
                        }
                        pointer = ++pointer;
                        m--;
                    }
                }
                else if ( ( fType2 & 1U ) != 0U )
                {
                    AppMain.NNS_MATERIAL_DESC nns_MATERIAL_DESC3 = (AppMain.NNS_MATERIAL_DESC)mmobj.pMatPtrList[i].pMaterial;
                    AppMain.NNS_MATERIAL_COLOR pColor9 = nns_MATERIAL_DESC3.pColor;
                    AppMain.NNS_MATERIAL_TEXMAP_DESC[] pTexDesc9 = nns_MATERIAL_DESC3.pTexDesc;
                    while ( m > 0 )
                    {
                        if ( ( int )( ~pointer ).Id0 >= i )
                        {
                            break;
                        }
                        pointer = ++pointer;
                        m--;
                    }
                    while ( m > 0 && ( int )( ~pointer ).Id0 == i )
                    {
                        uint num5 = (~pointer).fType & 4294967040U;
                        if ( num5 <= 65536U )
                        {
                            if ( num5 <= 4096U )
                            {
                                if ( num5 <= 1024U )
                                {
                                    if ( num5 != 512U )
                                    {
                                        if ( num5 == 1024U )
                                        {
                                            AppMain.nnInterpolateFloat( ref pColor9.Diffuse.g, pointer, frame );
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor9.Diffuse.r, pointer, frame );
                                    }
                                }
                                else if ( num5 != 2048U )
                                {
                                    if ( num5 != 3584U )
                                    {
                                        if ( num5 == 4096U )
                                        {
                                            AppMain.nnInterpolateFloat( ref pColor9.Diffuse.a, pointer, frame );
                                        }
                                    }
                                    else
                                    {
                                        AppMain.nnInterpolateFloat3( ref pColor9.Diffuse, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor9.Diffuse.b, pointer, frame );
                                }
                            }
                            else if ( num5 <= 16384U )
                            {
                                if ( num5 != 8192U )
                                {
                                    if ( num5 == 16384U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor9.Specular.g, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor9.Specular.r, pointer, frame );
                                }
                            }
                            else if ( num5 != 32768U )
                            {
                                if ( num5 != 57344U )
                                {
                                    if ( num5 == 65536U )
                                    {
                                        float num6 = 0f;
                                        if ( AppMain.nnInterpolateFloat( ref num6, pointer, frame ) != 0 )
                                        {
                                            AppMain.NNS_MATERIAL_COLOR nns_MATERIAL_COLOR = pColor9;
                                            nns_MATERIAL_COLOR.Specular.r = nns_MATERIAL_COLOR.Specular.r * num6;
                                            AppMain.NNS_MATERIAL_COLOR nns_MATERIAL_COLOR2 = pColor9;
                                            nns_MATERIAL_COLOR2.Specular.g = nns_MATERIAL_COLOR2.Specular.g * num6;
                                            AppMain.NNS_MATERIAL_COLOR nns_MATERIAL_COLOR3 = pColor9;
                                            nns_MATERIAL_COLOR3.Specular.b = nns_MATERIAL_COLOR3.Specular.b * num6;
                                        }
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat3( ref pColor9.Specular, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat( ref pColor9.Specular.b, pointer, frame );
                            }
                        }
                        else if ( num5 <= 1835008U )
                        {
                            if ( num5 <= 262144U )
                            {
                                if ( num5 != 131072U )
                                {
                                    if ( num5 == 262144U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pColor9.Ambient.r, pointer, frame );
                                    }
                                }
                                else
                                {
                                    float num7 = 0f;
                                    if ( AppMain.nnInterpolateFloat( ref num7, pointer, frame ) != 0 )
                                    {
                                        pColor9.Shininess = AppMain.nnPow( 2.0, ( double )( 10f * num7 + 2f ) );
                                    }
                                }
                            }
                            else if ( num5 != 524288U )
                            {
                                if ( num5 != 1048576U )
                                {
                                    if ( num5 == 1835008U )
                                    {
                                        AppMain.nnInterpolateFloat3( ref pColor9.Ambient, pointer, frame );
                                    }
                                }
                                else
                                {
                                    AppMain.nnInterpolateFloat( ref pColor9.Ambient.b, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat( ref pColor9.Ambient.g, pointer, frame );
                            }
                        }
                        else if ( num5 <= 8388608U )
                        {
                            if ( num5 != 2097152U )
                            {
                                if ( num5 != 4194304U )
                                {
                                    if ( num5 == 8388608U )
                                    {
                                        AppMain.nnInterpolateFloat( ref pTexDesc9[( int )( ~pointer ).Id1].Offset.u, pointer, frame );
                                    }
                                }
                                else
                                {
                                    float num8 = 0f;
                                    if ( AppMain.nnInterpolateFloat( ref num8, pointer, frame ) != 0 )
                                    {
                                        pTexDesc9[( int )( ~pointer ).Id1].EnvColor.r = num8;
                                        pTexDesc9[( int )( ~pointer ).Id1].EnvColor.g = num8;
                                        pTexDesc9[( int )( ~pointer ).Id1].EnvColor.b = num8;
                                    }
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateSint32( ref pTexDesc9[( int )( ~pointer ).Id1].iTexIdx, pointer, frame );
                            }
                        }
                        else if ( num5 != 16777216U )
                        {
                            if ( num5 != 25165824U )
                            {
                                if ( num5 == 33554432U )
                                {
                                    AppMain.nnInterpolateUint32( ref nns_MATERIAL_DESC3.User, pointer, frame );
                                }
                            }
                            else
                            {
                                AppMain.nnInterpolateFloat2( pTexDesc9[( int )( ~pointer ).Id1].Offset, pointer, frame );
                            }
                        }
                        else
                        {
                            AppMain.nnInterpolateFloat( ref pTexDesc9[( int )( ~pointer ).Id1].Offset.v, pointer, frame );
                        }
                        pointer = ++pointer;
                        m--;
                    }
                }
            }
        }
    }

    // Token: 0x06001851 RID: 6225 RVA: 0x000DB2F1 File Offset: 0x000D94F1
    public static void nnDrawMaterialMotionObject( AppMain.NNS_OBJECT mmobj, AppMain.NNS_MATRIX[] mtxpal, uint[] nodestatlist, uint subobjtype, uint flag )
    {
        AppMain.nnDrawObject( mmobj, mtxpal, nodestatlist, subobjtype, flag, 0U );
    }


    // Token: 0x060016E7 RID: 5863 RVA: 0x000C765E File Offset: 0x000C585E
    public static void nnCopyMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        dst.Assign( src );
    }

    // Token: 0x060016E8 RID: 5864 RVA: 0x000C7668 File Offset: 0x000C5868
    public static void nnCopyMatrix( AppMain.NNS_MATRIX dst, ref AppMain.SNNS_MATRIX src )
    {
        dst.Assign( ref src );
    }

    // Token: 0x060016E9 RID: 5865 RVA: 0x000C7672 File Offset: 0x000C5872
    public static void nnCopyMatrix( ref AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX src )
    {
        dst.Assign( ref src );
    }

    // Token: 0x060016EA RID: 5866 RVA: 0x000C767C File Offset: 0x000C587C
    public static bool nnInvertMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        float m = src.M00;
        float m2 = src.M01;
        float m3 = src.M02;
        float m4 = src.M03;
        float m5 = src.M10;
        float m6 = src.M11;
        float m7 = src.M12;
        float m8 = src.M13;
        float m9 = src.M20;
        float m10 = src.M21;
        float m11 = src.M22;
        float m12 = src.M23;
        float num = m6 * m11 - m7 * m10;
        float num2 = m7 * m9 - m5 * m11;
        float num3 = m5 * m10 - m6 * m9;
        float num4 = m * num + m2 * num2 + m3 * num3;
        if ( num4 == 0f )
        {
            dst.Clear();
            return false;
        }
        float num5 = 1f / num4;
        dst.M00 = num * num5;
        dst.M01 = -( m2 * m11 - m10 * m3 ) * num5;
        dst.M02 = ( m2 * m7 - m6 * m3 ) * num5;
        dst.M10 = num2 * num5;
        dst.M11 = ( m * m11 - m9 * m3 ) * num5;
        dst.M12 = -( m * m7 - m5 * m3 ) * num5;
        dst.M20 = num3 * num5;
        dst.M21 = -( m * m10 - m9 * m2 ) * num5;
        dst.M22 = ( m * m6 - m5 * m2 ) * num5;
        dst.M03 = -dst.M00 * m4 - dst.M01 * m8 - dst.M02 * m12;
        dst.M13 = -dst.M10 * m4 - dst.M11 * m8 - dst.M12 * m12;
        dst.M23 = -dst.M20 * m4 - dst.M21 * m8 - dst.M22 * m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
        return true;
    }

    // Token: 0x060016EB RID: 5867 RVA: 0x000C7860 File Offset: 0x000C5A60
    public static void nnInvertOrthoMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        float m = src.M00;
        float m2 = src.M01;
        float m3 = src.M02;
        float m4 = src.M03;
        float m5 = src.M10;
        float m6 = src.M11;
        float m7 = src.M12;
        float m8 = src.M13;
        float m9 = src.M20;
        float m10 = src.M21;
        float m11 = src.M22;
        float m12 = src.M23;
        dst.M01 = m5;
        dst.M02 = m9;
        dst.M10 = m2;
        dst.M12 = m10;
        dst.M20 = m3;
        dst.M21 = m7;
        dst.M03 = -( m * m4 + m5 * m8 + m9 * m12 );
        dst.M13 = -( m2 * m4 + m6 * m8 + m10 * m12 );
        dst.M23 = -( m3 * m4 + m7 * m8 + m11 * m12 );
        if ( src != dst )
        {
            dst.M00 = m;
            dst.M11 = m6;
            dst.M22 = m11;
        }
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016EC RID: 5868 RVA: 0x000C7980 File Offset: 0x000C5B80
    public static void nnMultiplyMatrix( AppMain.NNS_MATRIX dst, ref AppMain.SNNS_MATRIX mtx1, AppMain.NNS_MATRIX mtx2 )
    {
        float m = mtx1.M00;
        float m2 = mtx1.M10;
        float m3 = mtx1.M20;
        float m4 = mtx1.M01;
        float m5 = mtx1.M11;
        float m6 = mtx1.M21;
        float m7 = mtx1.M02;
        float m8 = mtx1.M12;
        float m9 = mtx1.M22;
        float m10 = mtx1.M03;
        float m11 = mtx1.M13;
        float m12 = mtx1.M23;
        float num = mtx2.M00;
        float num2 = mtx2.M10;
        float num3 = mtx2.M20;
        dst.M00 = m * num + m4 * num2 + m7 * num3;
        dst.M10 = m2 * num + m5 * num2 + m8 * num3;
        dst.M20 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M01;
        num2 = mtx2.M11;
        num3 = mtx2.M21;
        dst.M01 = m * num + m4 * num2 + m7 * num3;
        dst.M11 = m2 * num + m5 * num2 + m8 * num3;
        dst.M21 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M02;
        num2 = mtx2.M12;
        num3 = mtx2.M22;
        dst.M02 = m * num + m4 * num2 + m7 * num3;
        dst.M12 = m2 * num + m5 * num2 + m8 * num3;
        dst.M22 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M03;
        num2 = mtx2.M13;
        num3 = mtx2.M23;
        dst.M03 = m * num + m4 * num2 + m7 * num3 + m10;
        dst.M13 = m2 * num + m5 * num2 + m8 * num3 + m11;
        dst.M23 = m3 * num + m6 * num2 + m9 * num3 + m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016ED RID: 5869 RVA: 0x000C7B88 File Offset: 0x000C5D88
    public static void nnMultiplyMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX mtx1, ref AppMain.SNNS_MATRIX mtx2 )
    {
        float m = mtx1.M00;
        float m2 = mtx1.M10;
        float m3 = mtx1.M20;
        float m4 = mtx1.M01;
        float m5 = mtx1.M11;
        float m6 = mtx1.M21;
        float m7 = mtx1.M02;
        float m8 = mtx1.M12;
        float m9 = mtx1.M22;
        float m10 = mtx1.M03;
        float m11 = mtx1.M13;
        float m12 = mtx1.M23;
        float num = mtx2.M00;
        float num2 = mtx2.M10;
        float num3 = mtx2.M20;
        dst.M00 = m * num + m4 * num2 + m7 * num3;
        dst.M10 = m2 * num + m5 * num2 + m8 * num3;
        dst.M20 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M01;
        num2 = mtx2.M11;
        num3 = mtx2.M21;
        dst.M01 = m * num + m4 * num2 + m7 * num3;
        dst.M11 = m2 * num + m5 * num2 + m8 * num3;
        dst.M21 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M02;
        num2 = mtx2.M12;
        num3 = mtx2.M22;
        dst.M02 = m * num + m4 * num2 + m7 * num3;
        dst.M12 = m2 * num + m5 * num2 + m8 * num3;
        dst.M22 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M03;
        num2 = mtx2.M13;
        num3 = mtx2.M23;
        dst.M03 = m * num + m4 * num2 + m7 * num3 + m10;
        dst.M13 = m2 * num + m5 * num2 + m8 * num3 + m11;
        dst.M23 = m3 * num + m6 * num2 + m9 * num3 + m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016EE RID: 5870 RVA: 0x000C7D90 File Offset: 0x000C5F90
    public static void nnMultiplyMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX mtx1, AppMain.NNS_MATRIX mtx2 )
    {
        float m = mtx1.M00;
        float m2 = mtx1.M10;
        float m3 = mtx1.M20;
        float m4 = mtx1.M01;
        float m5 = mtx1.M11;
        float m6 = mtx1.M21;
        float m7 = mtx1.M02;
        float m8 = mtx1.M12;
        float m9 = mtx1.M22;
        float m10 = mtx1.M03;
        float m11 = mtx1.M13;
        float m12 = mtx1.M23;
        float num = mtx2.M00;
        float num2 = mtx2.M10;
        float num3 = mtx2.M20;
        dst.M00 = m * num + m4 * num2 + m7 * num3;
        dst.M10 = m2 * num + m5 * num2 + m8 * num3;
        dst.M20 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M01;
        num2 = mtx2.M11;
        num3 = mtx2.M21;
        dst.M01 = m * num + m4 * num2 + m7 * num3;
        dst.M11 = m2 * num + m5 * num2 + m8 * num3;
        dst.M21 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M02;
        num2 = mtx2.M12;
        num3 = mtx2.M22;
        dst.M02 = m * num + m4 * num2 + m7 * num3;
        dst.M12 = m2 * num + m5 * num2 + m8 * num3;
        dst.M22 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M03;
        num2 = mtx2.M13;
        num3 = mtx2.M23;
        dst.M03 = m * num + m4 * num2 + m7 * num3 + m10;
        dst.M13 = m2 * num + m5 * num2 + m8 * num3 + m11;
        dst.M23 = m3 * num + m6 * num2 + m9 * num3 + m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016EF RID: 5871 RVA: 0x000C7F98 File Offset: 0x000C6198
    public static void nnMultiplyMatrix( ref AppMain.SNNS_MATRIX dst, AppMain.NNS_MATRIX mtx1, ref AppMain.SNNS_MATRIX mtx2 )
    {
        float m = mtx1.M00;
        float m2 = mtx1.M10;
        float m3 = mtx1.M20;
        float m4 = mtx1.M01;
        float m5 = mtx1.M11;
        float m6 = mtx1.M21;
        float m7 = mtx1.M02;
        float m8 = mtx1.M12;
        float m9 = mtx1.M22;
        float m10 = mtx1.M03;
        float m11 = mtx1.M13;
        float m12 = mtx1.M23;
        float num = mtx2.M00;
        float num2 = mtx2.M10;
        float num3 = mtx2.M20;
        dst.M00 = m * num + m4 * num2 + m7 * num3;
        dst.M10 = m2 * num + m5 * num2 + m8 * num3;
        dst.M20 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M01;
        num2 = mtx2.M11;
        num3 = mtx2.M21;
        dst.M01 = m * num + m4 * num2 + m7 * num3;
        dst.M11 = m2 * num + m5 * num2 + m8 * num3;
        dst.M21 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M02;
        num2 = mtx2.M12;
        num3 = mtx2.M22;
        dst.M02 = m * num + m4 * num2 + m7 * num3;
        dst.M12 = m2 * num + m5 * num2 + m8 * num3;
        dst.M22 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M03;
        num2 = mtx2.M13;
        num3 = mtx2.M23;
        dst.M03 = m * num + m4 * num2 + m7 * num3 + m10;
        dst.M13 = m2 * num + m5 * num2 + m8 * num3 + m11;
        dst.M23 = m3 * num + m6 * num2 + m9 * num3 + m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016F0 RID: 5872 RVA: 0x000C81A0 File Offset: 0x000C63A0
    public static void nnMultiplyMatrix( out AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX mtx1, ref AppMain.SNNS_MATRIX mtx2 )
    {
        float m = mtx1.M00;
        float m2 = mtx1.M10;
        float m3 = mtx1.M20;
        float m4 = mtx1.M01;
        float m5 = mtx1.M11;
        float m6 = mtx1.M21;
        float m7 = mtx1.M02;
        float m8 = mtx1.M12;
        float m9 = mtx1.M22;
        float m10 = mtx1.M03;
        float m11 = mtx1.M13;
        float m12 = mtx1.M23;
        float num = mtx2.M00;
        float num2 = mtx2.M10;
        float num3 = mtx2.M20;
        dst.M00 = m * num + m4 * num2 + m7 * num3;
        dst.M10 = m2 * num + m5 * num2 + m8 * num3;
        dst.M20 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M01;
        num2 = mtx2.M11;
        num3 = mtx2.M21;
        dst.M01 = m * num + m4 * num2 + m7 * num3;
        dst.M11 = m2 * num + m5 * num2 + m8 * num3;
        dst.M21 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M02;
        num2 = mtx2.M12;
        num3 = mtx2.M22;
        dst.M02 = m * num + m4 * num2 + m7 * num3;
        dst.M12 = m2 * num + m5 * num2 + m8 * num3;
        dst.M22 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M03;
        num2 = mtx2.M13;
        num3 = mtx2.M23;
        dst.M03 = m * num + m4 * num2 + m7 * num3 + m10;
        dst.M13 = m2 * num + m5 * num2 + m8 * num3 + m11;
        dst.M23 = m3 * num + m6 * num2 + m9 * num3 + m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016F1 RID: 5873 RVA: 0x000C83A8 File Offset: 0x000C65A8
    public static void nnMultiplyMatrix( ref AppMain.SNNS_MATRIX dst, AppMain.NNS_MATRIX mtx1, AppMain.NNS_MATRIX mtx2 )
    {
        float m = mtx1.M00;
        float m2 = mtx1.M10;
        float m3 = mtx1.M20;
        float m4 = mtx1.M01;
        float m5 = mtx1.M11;
        float m6 = mtx1.M21;
        float m7 = mtx1.M02;
        float m8 = mtx1.M12;
        float m9 = mtx1.M22;
        float m10 = mtx1.M03;
        float m11 = mtx1.M13;
        float m12 = mtx1.M23;
        float num = mtx2.M00;
        float num2 = mtx2.M10;
        float num3 = mtx2.M20;
        dst.M00 = m * num + m4 * num2 + m7 * num3;
        dst.M10 = m2 * num + m5 * num2 + m8 * num3;
        dst.M20 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M01;
        num2 = mtx2.M11;
        num3 = mtx2.M21;
        dst.M01 = m * num + m4 * num2 + m7 * num3;
        dst.M11 = m2 * num + m5 * num2 + m8 * num3;
        dst.M21 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M02;
        num2 = mtx2.M12;
        num3 = mtx2.M22;
        dst.M02 = m * num + m4 * num2 + m7 * num3;
        dst.M12 = m2 * num + m5 * num2 + m8 * num3;
        dst.M22 = m3 * num + m6 * num2 + m9 * num3;
        num = mtx2.M03;
        num2 = mtx2.M13;
        num3 = mtx2.M23;
        dst.M03 = m * num + m4 * num2 + m7 * num3 + m10;
        dst.M13 = m2 * num + m5 * num2 + m8 * num3 + m11;
        dst.M23 = m3 * num + m6 * num2 + m9 * num3 + m12;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016F2 RID: 5874 RVA: 0x000C85B0 File Offset: 0x000C67B0
    public static void nnTransposeMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src )
    {
        dst.M00 = src.M00;
        dst.M01 = src.M10;
        dst.M02 = src.M20;
        dst.M03 = 0f;
        dst.M10 = src.M01;
        dst.M11 = src.M11;
        dst.M12 = src.M21;
        dst.M13 = 0f;
        dst.M20 = src.M02;
        dst.M21 = src.M12;
        dst.M22 = src.M22;
        dst.M23 = 0f;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016F3 RID: 5875 RVA: 0x000C8678 File Offset: 0x000C6878
    public static void nnQuaternionMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, ref AppMain.NNS_QUATERNION quat )
    {
        AppMain.SNNS_MATRIX snns_MATRIX;
        AppMain.nnMakeQuaternionMatrix( out snns_MATRIX, ref quat );
        AppMain.nnMultiplyMatrix( dst, src, ref snns_MATRIX );
    }

    // Token: 0x060016F4 RID: 5876 RVA: 0x000C8698 File Offset: 0x000C6898
    public static void nnRotateXMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, int ax )
    {
        if ( ax == 0 )
        {
            if ( dst != src )
            {
                AppMain.nnCopyMatrix( dst, src );
                return;
            }
        }
        else
        {
            float num;
            float num2;
            AppMain.nnSinCos( ax, out num, out num2 );
            float num3 = num;
            float num4 = num2;
            float num5 = src.M01;
            float num6 = src.M02;
            dst.M01 = num5 * num4 + num6 * num3;
            dst.M02 = num5 * -num3 + num6 * num4;
            float m = src.M11;
            float m2 = src.M12;
            dst.M11 = m * num4 + m2 * num3;
            dst.M12 = m * -num3 + m2 * num4;
            num5 = src.M21;
            num6 = src.M22;
            dst.M21 = num5 * num4 + num6 * num3;
            dst.M22 = num5 * -num3 + num6 * num4;
            if ( dst != src )
            {
                dst.M00 = src.M00;
                dst.M03 = src.M03;
                dst.M10 = src.M10;
                dst.M13 = src.M13;
                dst.M20 = src.M20;
                dst.M23 = src.M23;
                dst.M30 = 0f;
                dst.M31 = 0f;
                dst.M32 = 0f;
                dst.M33 = 1f;
            }
        }
    }

    // Token: 0x060016F5 RID: 5877 RVA: 0x000C87CC File Offset: 0x000C69CC
    public static void nnRotateYMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, int ay )
    {
        if ( ay == 0 )
        {
            if ( dst != src )
            {
                AppMain.nnCopyMatrix( dst, src );
                return;
            }
        }
        else
        {
            float num;
            float num2;
            AppMain.nnSinCos( ay, out num, out num2 );
            float num3 = num;
            float num4 = num2;
            float num5 = src.M00;
            float num6 = src.M02;
            dst.M00 = num5 * num4 + num6 * -num3;
            dst.M02 = num5 * num3 + num6 * num4;
            float m = src.M10;
            float m2 = src.M12;
            dst.M10 = m * num4 + m2 * -num3;
            dst.M12 = m * num3 + m2 * num4;
            num5 = src.M20;
            num6 = src.M22;
            dst.M20 = num5 * num4 + num6 * -num3;
            dst.M22 = num5 * num3 + num6 * num4;
            if ( dst != src )
            {
                dst.M01 = src.M01;
                dst.M03 = src.M03;
                dst.M11 = src.M11;
                dst.M13 = src.M13;
                dst.M21 = src.M21;
                dst.M23 = src.M23;
                dst.M30 = 0f;
                dst.M31 = 0f;
                dst.M32 = 0f;
                dst.M33 = 1f;
            }
        }
    }

    // Token: 0x060016F6 RID: 5878 RVA: 0x000C8900 File Offset: 0x000C6B00
    public static void nnRotateYMatrix( ref AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX src, int ay )
    {
        if ( ay == 0 )
        {
            return;
        }
        float num;
        float num2;
        AppMain.nnSinCos( ay, out num, out num2 );
        float num3 = num;
        float num4 = num2;
        float num5 = src.M00;
        float num6 = src.M02;
        dst.M00 = num5 * num4 + num6 * -num3;
        dst.M02 = num5 * num3 + num6 * num4;
        float m = src.M10;
        float m2 = src.M12;
        dst.M10 = m * num4 + m2 * -num3;
        dst.M12 = m * num3 + m2 * num4;
        num5 = src.M20;
        num6 = src.M22;
        dst.M20 = num5 * num4 + num6 * -num3;
        dst.M22 = num5 * num3 + num6 * num4;
        dst.M01 = src.M01;
        dst.M03 = src.M03;
        dst.M11 = src.M11;
        dst.M13 = src.M13;
        dst.M21 = src.M21;
        dst.M23 = src.M23;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016F7 RID: 5879 RVA: 0x000C8A20 File Offset: 0x000C6C20
    public static void nnRotateZMatrix( ref AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX src, int az )
    {
        if ( az == 0 )
        {
            dst = src;
            return;
        }
        float num;
        float num2;
        AppMain.nnSinCos( az, out num, out num2 );
        float num3 = num;
        float num4 = num2;
        float num5 = src.M00;
        float num6 = src.M01;
        dst.M00 = num5 * num4 + num6 * num3;
        dst.M01 = num5 * -num3 + num6 * num4;
        float m = src.M10;
        float m2 = src.M11;
        dst.M10 = m * num4 + m2 * num3;
        dst.M11 = m * -num3 + m2 * num4;
        num5 = src.M20;
        num6 = src.M21;
        dst.M20 = num5 * num4 + num6 * num3;
        dst.M21 = num5 * -num3 + num6 * num4;
        dst.M02 = src.M02;
        dst.M03 = src.M03;
        dst.M12 = src.M12;
        dst.M13 = src.M13;
        dst.M22 = src.M22;
        dst.M23 = src.M23;
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M33 = 1f;
    }

    // Token: 0x060016F8 RID: 5880 RVA: 0x000C8B4C File Offset: 0x000C6D4C
    public static void nnRotateZMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, int az )
    {
        if ( az == 0 )
        {
            if ( dst != src )
            {
                dst.Assign( src );
                return;
            }
        }
        else
        {
            float num;
            float num2;
            AppMain.nnSinCos( az, out num, out num2 );
            float num3 = num;
            float num4 = num2;
            float num5 = src.M00;
            float num6 = src.M01;
            dst.M00 = num5 * num4 + num6 * num3;
            dst.M01 = num5 * -num3 + num6 * num4;
            float m = src.M10;
            float m2 = src.M11;
            dst.M10 = m * num4 + m2 * num3;
            dst.M11 = m * -num3 + m2 * num4;
            num5 = src.M20;
            num6 = src.M21;
            dst.M20 = num5 * num4 + num6 * num3;
            dst.M21 = num5 * -num3 + num6 * num4;
            if ( dst != src )
            {
                dst.M02 = src.M02;
                dst.M03 = src.M03;
                dst.M12 = src.M12;
                dst.M13 = src.M13;
                dst.M22 = src.M22;
                dst.M23 = src.M23;
                dst.M30 = 0f;
                dst.M31 = 0f;
                dst.M32 = 0f;
                dst.M33 = 1f;
            }
        }
    }

    // Token: 0x060016F9 RID: 5881 RVA: 0x000C8C7F File Offset: 0x000C6E7F
    public static void nnRotateXYZMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, int ax, int ay, int az )
    {
        if ( az != 0 || dst != src )
        {
            AppMain.nnRotateZMatrix( dst, src, az );
        }
        if ( ay != 0 )
        {
            AppMain.nnRotateYMatrix( dst, dst, ay );
        }
        if ( ax != 0 )
        {
            AppMain.nnRotateXMatrix( dst, dst, ax );
        }
    }

    // Token: 0x060016FA RID: 5882 RVA: 0x000C8CA8 File Offset: 0x000C6EA8
    public static void nnRotateXZYMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, int ax, int ay, int az )
    {
        if ( ay != 0 || dst != src )
        {
            AppMain.nnRotateYMatrix( dst, src, ay );
        }
        if ( az != 0 )
        {
            AppMain.nnRotateZMatrix( dst, dst, az );
        }
        if ( ax != 0 )
        {
            AppMain.nnRotateXMatrix( dst, dst, ax );
        }
    }

    // Token: 0x060016FB RID: 5883 RVA: 0x000C8CD1 File Offset: 0x000C6ED1
    public static void nnRotateZXYMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, int ax, int ay, int az )
    {
        if ( ay != 0 || dst != src )
        {
            AppMain.nnRotateYMatrix( dst, src, ay );
        }
        if ( ax != 0 )
        {
            AppMain.nnRotateXMatrix( dst, dst, ax );
        }
        if ( az != 0 )
        {
            AppMain.nnRotateZMatrix( dst, dst, az );
        }
    }

    // Token: 0x060016FC RID: 5884 RVA: 0x000C8CFC File Offset: 0x000C6EFC
    public static void nnScaleMatrix( ref AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX src, float x, float y, float z )
    {
        dst.M03 = src.M03;
        dst.M13 = src.M13;
        dst.M23 = src.M23;
        dst.M33 = 1f;
        dst.M00 = src.M00 * x;
        dst.M10 = src.M10 * x;
        dst.M20 = src.M20 * x;
        dst.M30 = 0f;
        dst.M01 = src.M01 * y;
        dst.M11 = src.M11 * y;
        dst.M21 = src.M21 * y;
        dst.M31 = 0f;
        dst.M02 = src.M02 * z;
        dst.M12 = src.M12 * z;
        dst.M22 = src.M22 * z;
        dst.M32 = 0f;
    }

    // Token: 0x060016FD RID: 5885 RVA: 0x000C8DDC File Offset: 0x000C6FDC
    public static void nnScaleMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, float x, float y, float z )
    {
        if ( dst != src )
        {
            dst.M03 = src.M03;
            dst.M13 = src.M13;
            dst.M23 = src.M23;
            dst.M33 = 1f;
        }
        dst.M00 = src.M00 * x;
        dst.M10 = src.M10 * x;
        dst.M20 = src.M20 * x;
        dst.M30 = 0f;
        dst.M01 = src.M01 * y;
        dst.M11 = src.M11 * y;
        dst.M21 = src.M21 * y;
        dst.M31 = 0f;
        dst.M02 = src.M02 * z;
        dst.M12 = src.M12 * z;
        dst.M22 = src.M22 * z;
        dst.M32 = 0f;
    }

    // Token: 0x060016FE RID: 5886 RVA: 0x000C8EC0 File Offset: 0x000C70C0
    public static void nnTranslateMatrix( ref AppMain.SNNS_MATRIX dst, ref AppMain.SNNS_MATRIX src, float x, float y, float z )
    {
        AppMain.nnCopyMatrix33( ref dst, ref src );
        dst.M30 = 0f;
        dst.M31 = 0f;
        dst.M32 = 0f;
        dst.M03 = src.M00 * x + src.M01 * y + src.M02 * z + src.M03;
        dst.M13 = src.M10 * x + src.M11 * y + src.M12 * z + src.M13;
        dst.M23 = src.M20 * x + src.M21 * y + src.M22 * z + src.M23;
        dst.M33 = 1f;
    }

    // Token: 0x060016FF RID: 5887 RVA: 0x000C8F78 File Offset: 0x000C7178
    public static void nnTranslateMatrix( AppMain.NNS_MATRIX dst, AppMain.NNS_MATRIX src, float x, float y, float z )
    {
        if ( dst != src )
        {
            AppMain.nnCopyMatrix33( dst, src );
            dst.M30 = 0f;
            dst.M31 = 0f;
            dst.M32 = 0f;
        }
        dst.M03 = src.M00 * x + src.M01 * y + src.M02 * z + src.M03;
        dst.M13 = src.M10 * x + src.M11 * y + src.M12 * z + src.M13;
        dst.M23 = src.M20 * x + src.M21 * y + src.M22 * z + src.M23;
        dst.M33 = 1f;
    }

    // Token: 0x06001700 RID: 5888 RVA: 0x000C9034 File Offset: 0x000C7234
    public static void nnCopyVectorMatrixTranslation( AppMain.NNS_MATRIX mtx, ref AppMain.SNNS_VECTOR vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001701 RID: 5889 RVA: 0x000C905A File Offset: 0x000C725A
    public static void nnCopyVectorMatrixTranslation( ref AppMain.SNNS_MATRIX mtx, ref AppMain.SNNS_VECTOR vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001702 RID: 5890 RVA: 0x000C9080 File Offset: 0x000C7280
    public static void nnCopyVectorMatrixTranslation( ref AppMain.SNNS_MATRIX mtx, AppMain.NNS_VECTOR vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001703 RID: 5891 RVA: 0x000C90A6 File Offset: 0x000C72A6
    public static void nnCopyVectorMatrixTranslation( ref AppMain.SNNS_MATRIX mtx, AppMain.NNS_VECTOR4D vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001704 RID: 5892 RVA: 0x000C90CC File Offset: 0x000C72CC
    public static void nnCopyVectorMatrixTranslation( ref AppMain.SNNS_MATRIX mtx, ref AppMain.SNNS_VECTOR4D vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001705 RID: 5893 RVA: 0x000C90F2 File Offset: 0x000C72F2
    public static void nnCopyVectorMatrixTranslation( AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001706 RID: 5894 RVA: 0x000C9118 File Offset: 0x000C7318
    public static void nnCopyVectorMatrixTranslation( AppMain.NNS_MATRIX mtx, AppMain.NNS_VECTOR4D vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001707 RID: 5895 RVA: 0x000C913E File Offset: 0x000C733E
    private static void nnCopyVectorFastMatrixTranslation( AppMain.NNS_MATRIX mtx, ref AppMain.NNS_VECTORFAST vec )
    {
        mtx.M03 = vec.x;
        mtx.M13 = vec.y;
        mtx.M23 = vec.z;
    }

    // Token: 0x06001708 RID: 5896 RVA: 0x000C9164 File Offset: 0x000C7364
    private int nnCheckCollisionSC( ref AppMain.NNS_SPHERE sphere, ref AppMain.NNS_CAPSULE capsule )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }

    // Token: 0x06001709 RID: 5897 RVA: 0x000C916C File Offset: 0x000C736C
    private int nnCheckCollisionBC( ref AppMain.NNS_BOX box, ref AppMain.NNS_CAPSULE capsule )
    {
        AppMain.mppAssertNotImpl();
        return 0;
    }
}