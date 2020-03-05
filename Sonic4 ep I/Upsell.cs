using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

// Token: 0x020003FD RID: 1021
public class Upsell
{
	// Token: 0x06002925 RID: 10533 RVA: 0x001573C3 File Offset: 0x001555C3
	public static void launchUpsellScreen(AppMain.DMS_BUY_SCR_WORK buy_scr)
	{
		AppMain.DmSndBgmPlayerBgmStop();
		Upsell.ss_num = 1;
		Upsell.buy_scr_work = buy_scr;
		Upsell.loadUpsellScreen();
	}

	// Token: 0x06002926 RID: 10534 RVA: 0x001573DC File Offset: 0x001555DC
	public static void loadUpsellScreen()
	{
		try
		{
			Upsell.bg = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4us_bg.png"));
			Upsell.cursor1 = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4us_arrow.png"));
			Upsell.screenshot = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4us_ss_" + Upsell.ss_num + ".png"));
			string text = LiveFeature.lang_suffix[AppMain.GsEnvGetLanguage()];
			Upsell.button1 = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4" + text + "_back.png"));
			Upsell.button1hl = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4" + text + "_back_HL.png"));
			Upsell.button2 = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4" + text + "_buy.png"));
			Upsell.button2hl = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4" + text + "_buy_HL.png"));
			Upsell.showUpsell = true;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06002927 RID: 10535 RVA: 0x00157530 File Offset: 0x00155730
	public static bool inputUpsellScreen()
	{
		if (!Upsell.showUpsell)
		{
			return false;
		}
		Upsell.pressed_button = -1;
		bool flag = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
		if (flag)
		{
			if (Upsell.anm_progress != -1)
			{
				Upsell.anm_progress = -1;
				return true;
			}
			Upsell.disposeUpsellScreen();
			if (Upsell.buy_scr_work != null)
			{
				Upsell.buy_scr_work.result[0] = 2;
				AppMain.DmSndBgmPlayerPlayBgm(0);
			}
			else
			{
				AppMain.SyDecideEvtCase(1);
				AppMain.SyChangeNextEvt();
			}
			return true;
		}
		else
		{
			TouchCollection state = TouchPanel.GetState();
			if (state.Count == 0)
			{
				if (Upsell.px == 0 && Upsell.py == 0)
				{
					return true;
				}
				Upsell.curState = 1;
				Upsell.cx = Upsell.px;
				Upsell.cy = Upsell.py;
				Upsell.px = 0;
				Upsell.py = 0;
			}
			else
			{
				TouchLocation touchLocation = state[0];
				if (touchLocation.State == TouchLocationState.Pressed || touchLocation.State == TouchLocationState.Moved)
				{
					Upsell.curState = 0;
					Upsell.cx = (int)touchLocation.Position.X;
					Upsell.cy = (int)touchLocation.Position.Y;
				}
				if (touchLocation.State == TouchLocationState.Released || touchLocation.State == TouchLocationState.Invalid)
				{
					Upsell.curState = 1;
					Upsell.cx = Upsell.px;
					Upsell.cy = Upsell.py;
					Upsell.px = 0;
					Upsell.py = 0;
				}
			}
			Upsell.hl_buttons[0] = false;
			Upsell.hl_buttons[1] = false;
			if (Upsell.anm_progress > 100)
			{
				Upsell.anm_progress = -Upsell.anm_progress;
				Upsell.curState = 1;
				Upsell.cx = Upsell.px;
				Upsell.cy = Upsell.py;
				Upsell.px = 0;
				Upsell.py = 0;
				return true;
			}
			if (Upsell.anm_progress != -1)
			{
				return true;
			}
			for (int i = 0; i < 5; i++)
			{
				if (Upsell.rects[i].Contains(Upsell.cx, Upsell.cy))
				{
					Upsell.pressed_button = i;
					break;
				}
			}
			switch (Upsell.pressed_button)
			{
			case 0:
				if (Upsell.curState == 0)
				{
					Upsell.hl_buttons[0] = true;
				}
				else
				{
					Upsell.disposeUpsellScreen();
					if (Upsell.buy_scr_work != null)
					{
						Upsell.buy_scr_work.result[0] = 2;
						AppMain.DmSndBgmPlayerPlayBgm(0);
					}
					else
					{
						AppMain.SyDecideEvtCase(1);
						AppMain.SyChangeNextEvt();
					}
				}
				break;
			case 1:
				if (Upsell.curState == 0)
				{
					Upsell.hl_buttons[1] = true;
				}
				else
				{
					Upsell.wasUpsell = true;
					XBOXLive.showGuide();
				}
				break;
			case 2:
				if (Upsell.curState == 1)
				{
					Upsell.ss_num--;
					if (Upsell.ss_num < 1)
					{
						Upsell.ss_num = 5;
					}
					Upsell.screenshot.Dispose();
					Upsell.screenshot = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4us_ss_" + Upsell.ss_num + ".png"));
				}
				break;
			case 3:
				if (Upsell.curState == 1)
				{
					Upsell.ss_num++;
					if (Upsell.ss_num >= 5)
					{
						Upsell.ss_num = 1;
					}
					Upsell.screenshot.Dispose();
					Upsell.screenshot = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\UPSELL\\s4us_ss_" + Upsell.ss_num + ".png"));
				}
				break;
			case 4:
				if (Upsell.curState == 0)
				{
					Upsell.anm_progress = 0;
				}
				break;
			}
			if (Upsell.curState == 0)
			{
				Upsell.px = Upsell.cx;
				Upsell.py = Upsell.cy;
			}
			else
			{
				Upsell.curState = -1;
			}
			return true;
		}
	}

	// Token: 0x06002928 RID: 10536 RVA: 0x00157888 File Offset: 0x00155A88
	public static void updateUpsellScreen()
	{
		if (Upsell.anm_progress != -1)
		{
			Upsell.anm_progress += 25;
			if (Upsell.anm_progress > 255)
			{
				Upsell.anm_progress = 255;
			}
			if (Upsell.anm_progress < -1)
			{
				Upsell.anm_progress += 25;
				if (Upsell.anm_progress > -50)
				{
					Upsell.anm_progress = -1;
				}
			}
		}
		if (Upsell.wasUpsell && !Guide.IsVisible && !XBOXLive.isTrial(true))
		{
			Upsell.disposeUpsellScreen();
			if (Upsell.buy_scr_work != null)
			{
				Upsell.buy_scr_work.result[0] = 0;
				AppMain.DmSndBgmPlayerPlayBgm(0);
				return;
			}
			AppMain.event_after_buy = true;
			AppMain.SyDecideEvtCase(1);
			AppMain.SyChangeNextEvt();
		}
	}

	// Token: 0x06002929 RID: 10537 RVA: 0x0015792C File Offset: 0x00155B2C
	public static void drawUpsellScreen()
	{
		if (!Upsell.showUpsell)
		{
			return;
		}
		SpriteBatch spriteBatch = LiveFeature.GAME.spriteBatch;
		spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
		spriteBatch.Draw(Upsell.bg, Vector2.Zero, Color.White);
		spriteBatch.Draw(Upsell.hl_buttons[1] ? Upsell.button2hl : Upsell.button2, Upsell.rects[1], Color.White);
		spriteBatch.Draw(Upsell.hl_buttons[0] ? Upsell.button1hl : Upsell.button1, Upsell.rects[0], Color.White);
		spriteBatch.Draw(Upsell.cursor1, Upsell.rects[2], Color.White);
		spriteBatch.Draw(Upsell.cursor1, Upsell.rects[3], default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
		spriteBatch.Draw(Upsell.screenshot, Upsell.rects[4], Color.White);
		int num = 5;
		num += LiveFeature._drawWrapText("Download full Game!", 335, num, 300, Color.White, true, LiveFeature.GAME.fnts[1], spriteBatch, 0.8f);
		num += LiveFeature._drawWrapText("- 17 diverse stages", 195, num, 300, Color.White, false, LiveFeature.GAME.fnts[0], spriteBatch, 0.8f);
		num += LiveFeature._drawWrapText("- Two exclusive stages!", 195, num, 300, Color.White, false, LiveFeature.GAME.fnts[0], spriteBatch, 0.8f);
		num += LiveFeature._drawWrapText("- 7 special stages with tilt control!", 195, num, 300, Color.White, false, LiveFeature.GAME.fnts[0], spriteBatch, 0.8f);
		num += LiveFeature._drawWrapText("- Collect all 7 Chaos Emeralds to Unlock Super Sonic!", 195, num, 300, Color.White, false, LiveFeature.GAME.fnts[0], spriteBatch, 0.8f);
		if (Upsell.anm_progress != -1)
		{
			int num2 = Math.Abs(Upsell.anm_progress);
			spriteBatch.Draw(Upsell.screenshot, Vector2.Zero, new Color(num2, num2, num2, num2));
		}
		LiveFeature.GAME.spriteBatch.End();
		Upsell.updateUpsellScreen();
	}

	// Token: 0x0600292A RID: 10538 RVA: 0x00157B78 File Offset: 0x00155D78
	public static void disposeUpsellScreen()
	{
		try
		{
			Upsell.showUpsell = false;
			Upsell.bg.Dispose();
			Upsell.bg = null;
			Upsell.cursor1.Dispose();
			Upsell.cursor1 = null;
			Upsell.screenshot.Dispose();
			Upsell.screenshot = null;
			Upsell.button1.Dispose();
			Upsell.button1 = null;
			Upsell.button1hl.Dispose();
			Upsell.button1hl = null;
			Upsell.button2.Dispose();
			Upsell.button2 = null;
			Upsell.button2hl.Dispose();
			Upsell.button2hl = null;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600292C RID: 10540 RVA: 0x00157C10 File Offset: 0x00155E10
	// Note: this type is marked as 'beforefieldinit'.
	static Upsell()
	{
		bool[] array = new bool[2];
		Upsell.hl_buttons = array;
		Upsell.wasUpsell = false;
		Upsell.anm_progress = -1;
	}

	// Token: 0x0400638D RID: 25485
	private const int SS_MAX = 5;

	// Token: 0x0400638E RID: 25486
	private const int CUR_STATE_NONE = -1;

	// Token: 0x0400638F RID: 25487
	private const int CUR_STATE_PRESSED = 0;

	// Token: 0x04006390 RID: 25488
	private const int CUR_STATE_RELEASED = 1;

	// Token: 0x04006391 RID: 25489
	public static Texture2D bg;

	// Token: 0x04006392 RID: 25490
	public static Texture2D cursor1;

	// Token: 0x04006393 RID: 25491
	public static Texture2D cursor2;

	// Token: 0x04006394 RID: 25492
	public static Texture2D button1;

	// Token: 0x04006395 RID: 25493
	public static Texture2D button1hl;

	// Token: 0x04006396 RID: 25494
	public static Texture2D button2;

	// Token: 0x04006397 RID: 25495
	public static Texture2D button2hl;

	// Token: 0x04006398 RID: 25496
	public static Texture2D screenshot;

	// Token: 0x04006399 RID: 25497
	public static bool showUpsell = false;

	// Token: 0x0400639A RID: 25498
	public static int ss_num = 1;

	// Token: 0x0400639B RID: 25499
	public static int pressed_button = -1;

	// Token: 0x0400639C RID: 25500
	public static Rectangle[] rects = new Rectangle[]
	{
		new Rectangle(60, 245, 90, 30),
		new Rectangle(200, 230, 272, 52),
		new Rectangle(190, 145, 37, 59),
		new Rectangle(433, 145, 37, 59),
		new Rectangle(240, 115, 180, 110)
	};

	// Token: 0x0400639D RID: 25501
	public static bool[] hl_buttons;

	// Token: 0x0400639E RID: 25502
	private static AppMain.DMS_BUY_SCR_WORK buy_scr_work;

	// Token: 0x0400639F RID: 25503
	public static int px;

	// Token: 0x040063A0 RID: 25504
	public static int py;

	// Token: 0x040063A1 RID: 25505
	public static int cx;

	// Token: 0x040063A2 RID: 25506
	public static int cy;

	// Token: 0x040063A3 RID: 25507
	public static int curState;

	// Token: 0x040063A4 RID: 25508
	private static bool wasUpsell;

	// Token: 0x040063A5 RID: 25509
	public static int anm_progress;

	// Token: 0x020003FE RID: 1022
	private enum RectTypes
	{
		// Token: 0x040063A7 RID: 25511
		None = -1,
		// Token: 0x040063A8 RID: 25512
		Back,
		// Token: 0x040063A9 RID: 25513
		Purchase,
		// Token: 0x040063AA RID: 25514
		CurLeft,
		// Token: 0x040063AB RID: 25515
		CurRight,
		// Token: 0x040063AC RID: 25516
		SS,
		// Token: 0x040063AD RID: 25517
		MAX
	}

	// Token: 0x020003FF RID: 1023
	private enum HLTypes
	{
		// Token: 0x040063AF RID: 25519
		Back,
		// Token: 0x040063B0 RID: 25520
		Purchase,
		// Token: 0x040063B1 RID: 25521
		MAX
	}
}
