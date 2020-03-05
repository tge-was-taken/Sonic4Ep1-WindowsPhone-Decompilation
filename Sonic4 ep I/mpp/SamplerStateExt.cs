using System;
using Microsoft.Xna.Framework.Graphics;

namespace mpp
{
	// Token: 0x020003E7 RID: 999
	internal static class SamplerStateExt
	{
		// Token: 0x060028A0 RID: 10400 RVA: 0x00153F8C File Offset: 0x0015218C
		public static SamplerState clone(this SamplerState original)
		{
			return new SamplerState
			{
				AddressU = original.AddressU,
				AddressV = original.AddressV,
				AddressW = original.AddressW,
				Filter = original.Filter,
				MaxAnisotropy = original.MaxAnisotropy,
				MaxMipLevel = original.MaxMipLevel,
				MipMapLevelOfDetailBias = original.MipMapLevelOfDetailBias
			};
		}
	}
}
