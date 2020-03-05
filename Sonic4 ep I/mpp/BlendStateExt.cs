using System;
using Microsoft.Xna.Framework.Graphics;

namespace mpp
{
	// Token: 0x020003E9 RID: 1001
	internal static class BlendStateExt
	{
		// Token: 0x060028A2 RID: 10402 RVA: 0x001540C8 File Offset: 0x001522C8
		public static BlendState clone(this BlendState original)
		{
			return new BlendState
			{
				AlphaBlendFunction = original.AlphaBlendFunction,
				AlphaDestinationBlend = original.AlphaDestinationBlend,
				AlphaSourceBlend = original.AlphaSourceBlend,
				BlendFactor = original.BlendFactor,
				ColorBlendFunction = original.ColorBlendFunction,
				ColorDestinationBlend = original.ColorDestinationBlend,
				ColorSourceBlend = original.ColorSourceBlend,
				ColorWriteChannels = original.ColorWriteChannels,
				ColorWriteChannels1 = original.ColorWriteChannels1,
				ColorWriteChannels2 = original.ColorWriteChannels2,
				ColorWriteChannels3 = original.ColorWriteChannels3,
				MultiSampleMask = original.MultiSampleMask
			};
		}
	}
}
