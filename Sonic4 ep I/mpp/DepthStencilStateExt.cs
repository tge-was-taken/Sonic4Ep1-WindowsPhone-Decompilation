using System;
using Microsoft.Xna.Framework.Graphics;

namespace mpp
{
	// Token: 0x020003E8 RID: 1000
	internal static class DepthStencilStateExt
	{
		// Token: 0x060028A1 RID: 10401 RVA: 0x00153FF4 File Offset: 0x001521F4
		public static DepthStencilState clone(this DepthStencilState original)
		{
			return new DepthStencilState
			{
				CounterClockwiseStencilDepthBufferFail = original.CounterClockwiseStencilDepthBufferFail,
				CounterClockwiseStencilFail = original.CounterClockwiseStencilFail,
				CounterClockwiseStencilFunction = original.CounterClockwiseStencilFunction,
				CounterClockwiseStencilPass = original.CounterClockwiseStencilPass,
				DepthBufferEnable = original.DepthBufferEnable,
				DepthBufferFunction = original.DepthBufferFunction,
				DepthBufferWriteEnable = original.DepthBufferWriteEnable,
				ReferenceStencil = original.ReferenceStencil,
				StencilDepthBufferFail = original.StencilDepthBufferFail,
				StencilEnable = original.StencilEnable,
				StencilFail = original.StencilFail,
				StencilFunction = original.StencilFunction,
				StencilMask = original.StencilMask,
				StencilPass = original.StencilPass,
				StencilWriteMask = original.StencilWriteMask,
				TwoSidedStencilMode = original.TwoSidedStencilMode
			};
		}
	}
}
