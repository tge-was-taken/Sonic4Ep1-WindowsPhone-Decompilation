using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

// Token: 0x020003E2 RID: 994
public abstract class XBOXLive
{
	// Token: 0x06002884 RID: 10372 RVA: 0x0015328F File Offset: 0x0015148F
	public static bool isTrial(bool update)
	{
		if (update)
		{
			XBOXLive.TrialModeCached = Guide.IsTrialMode;
		}
		return XBOXLive.TrialModeCached;
	}

	// Token: 0x06002885 RID: 10373 RVA: 0x001532A3 File Offset: 0x001514A3
	public static bool isTrial()
	{
		return XBOXLive.TrialModeCached;
	}

	// Token: 0x06002886 RID: 10374 RVA: 0x001532AA File Offset: 0x001514AA
	public static void showGuide()
	{
		if (XBOXLive.isTrial() && !Guide.IsVisible)
		{
			Guide.ShowMarketplace(PlayerIndex.One);
		}
	}

	// Token: 0x06002887 RID: 10375 RVA: 0x001532C0 File Offset: 0x001514C0
	public static void HandleGameUpdateRequired(GameUpdateRequiredException e)
	{
		try
		{
			if (XBOXLive.gameService.Enabled)
			{
				XBOXLive.displayTitleUpdateMessage = true;
			}
			XBOXLive.signinStatus = XBOXLive.SigninStatus.UpdateNeeded;
			XBOXLive.gameService.Enabled = false;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06002888 RID: 10376
	public abstract void _initTextDialog(out string dlgYes, out string dlgNo, out string dlgCaption, out string dlgText);

	// Token: 0x06002889 RID: 10377 RVA: 0x00153308 File Offset: 0x00151508
	public static void showUpdateMB()
	{
		if (XBOXLive.displayTitleUpdateMessage && XBOXLive.allowShowUpdate && !Guide.IsVisible)
		{
			XBOXLive.displayTitleUpdateMessage = false;
			AppMain.g_ao_sys_global.is_show_ui = true;
			string text = "";
			string text2 = "";
			string title = "";
			string text3 = "";
			if (XBOXLive.instanceXBOX != null)
			{
				XBOXLive.instanceXBOX._initTextDialog(out text, out text2, out title, out text3);
			}
			List<string> list = new List<string>();
			list.Add(text);
			list.Add(text2);
			Guide.BeginShowMessageBox(title, text3, list, 1, MessageBoxIcon.Alert, new AsyncCallback(XBOXLive.UpdateDialogGetMBResult), null);
		}
	}

	// Token: 0x0600288A RID: 10378 RVA: 0x001533A0 File Offset: 0x001515A0
	protected static void UpdateDialogGetMBResult(IAsyncResult userResult)
	{
		AppMain.g_ao_sys_global.is_show_ui = false;
		int? num = Guide.EndShowMessageBox(userResult);
		try
		{
			if (num != null && num.Value == 0)
			{
				if (Guide.IsTrialMode)
				{
					int num2 = 10;
					while (Guide.IsVisible && num2 > 0)
					{
						num2--;
						Thread.Sleep(100);
					}
					Guide.ShowMarketplace(PlayerIndex.One);
				}
				else
				{
					new MarketplaceDetailTask
					{
						ContentType = 1
					}.Show();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600288B RID: 10379 RVA: 0x00153424 File Offset: 0x00151624
	public static void tryUpdate()
	{
		if (XBOXLive.updateExceptCount < 0)
		{
			XBOXLive.updateExceptCount = 0;
		}
		if (XBOXLive.updateExceptCount == 0)
		{
			throw new GameUpdateRequiredException("Text Exception");
		}
	}

	// Token: 0x040062B9 RID: 25273
	protected static GamerServicesComponent gameService;

	// Token: 0x040062BA RID: 25274
	protected static bool TrialModeCached = false;

	// Token: 0x040062BB RID: 25275
	public static XBOXLive instanceXBOX;

	// Token: 0x040062BC RID: 25276
	public static XBOXLive.SigninStatus signinStatus = XBOXLive.SigninStatus.None;

	// Token: 0x040062BD RID: 25277
	public static bool displayTitleUpdateMessage = false;

	// Token: 0x040062BE RID: 25278
	public static bool allowShowUpdate = false;

	// Token: 0x040062BF RID: 25279
	public static int updateExceptCount = 1;

	// Token: 0x020003E3 RID: 995
	public enum SigninStatus
	{
		// Token: 0x040062C1 RID: 25281
		None,
		// Token: 0x040062C2 RID: 25282
		SigningIn,
		// Token: 0x040062C3 RID: 25283
		Local,
		// Token: 0x040062C4 RID: 25284
		LIVE,
		// Token: 0x040062C5 RID: 25285
		Error,
		// Token: 0x040062C6 RID: 25286
		UpdateNeeded
	}
}
