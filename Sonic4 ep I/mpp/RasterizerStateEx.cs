using System;
using Microsoft.Xna.Framework.Graphics;

namespace mpp
{
	// Token: 0x020003EA RID: 1002
	internal static class RasterizerStateEx
	{
		// Token: 0x060028A3 RID: 10403 RVA: 0x0015416C File Offset: 0x0015236C
		public static RasterizerState clone(this RasterizerState original)
		{
			return new RasterizerState
			{
				CullMode = original.CullMode,
				DepthBias = original.DepthBias,
				FillMode = original.FillMode,
				MultiSampleAntiAlias = original.MultiSampleAntiAlias,
				ScissorTestEnable = original.ScissorTestEnable,
				SlopeScaleDepthBias = original.SlopeScaleDepthBias
			};
		}
	}
}
