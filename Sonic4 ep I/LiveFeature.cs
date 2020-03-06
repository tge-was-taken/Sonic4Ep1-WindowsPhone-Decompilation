using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sonic4ep1;

// Token: 0x020003F3 RID: 1011
public class LiveFeature : XBOXLive
{
	// Token: 0x060028D0 RID: 10448 RVA: 0x00154C54 File Offset: 0x00152E54
	public LiveFeature()
	{
		try
		{
			XBOXLive.signinStatus = XBOXLive.SigninStatus.SigningIn;
			XBOXLive.isTrial(true);
			SignedInGamer.SignedIn += new EventHandler<SignedInEventArgs>(this.GamerSignedInCallback);
			XBOXLive.gameService = new GamerServicesComponent(LiveFeature.GAME);
			// HACK(fix XNA init crash): // LiveFeature.GAME.Components.Add(XBOXLive.gameService);
			for (int i = 0; i < 48; i++)
			{
				this.hiScoresTables[i] = new LiveFeature.HISCORE_ENTRY[0];
				this.l_status[i] = LiveFeature.LBStatus.NotRead;
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
			XBOXLive.signinStatus = XBOXLive.SigninStatus.Error;
		}
		LiveFeature.instance = this;
		XBOXLive.instanceXBOX = this;
	}

	// Token: 0x060028D1 RID: 10449 RVA: 0x00154D2C File Offset: 0x00152F2C
	private void GamerSignedInCallback(object sender, SignedInEventArgs args)
	{
		XBOXLive.isTrial(true);
		try
		{
			if (XBOXLive.signinStatus != XBOXLive.SigninStatus.UpdateNeeded)
			{
				SignedInGamer signedInGamer = args.Gamer;
				if (signedInGamer != null)
				{
					this.gamer = signedInGamer;
					if (!Guide.IsTrialMode)
					{
						this.gamer.BeginGetAchievements(new AsyncCallback(this.GetAchievementsCallback), this.gamer);
					}
					if (this.gamer.IsSignedInToLive)
					{
						XBOXLive.signinStatus = XBOXLive.SigninStatus.LIVE;
						GamerPrivilegeSetting allowProfileViewing = this.gamer.Privileges.AllowProfileViewing;
						if (allowProfileViewing == GamerPrivilegeSetting.Everyone || allowProfileViewing == GamerPrivilegeSetting.FriendsOnly)
						{
							this.gamer.BeginGetProfile(new AsyncCallback(this.GetProfileCallback), this.gamer);
						}
					}
					else
					{
						XBOXLive.signinStatus = XBOXLive.SigninStatus.Local;
					}
				}
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
			XBOXLive.signinStatus = XBOXLive.SigninStatus.Error;
		}
	}

	// Token: 0x060028D2 RID: 10450 RVA: 0x00154E08 File Offset: 0x00153008
	private void GetProfileCallback(IAsyncResult result)
	{
		try
		{
			if (XBOXLive.signinStatus != XBOXLive.SigninStatus.UpdateNeeded)
			{
				SignedInGamer signedInGamer = result.AsyncState as SignedInGamer;
				if (signedInGamer != null)
				{
					this.profile = signedInGamer.EndGetProfile(result);
				}
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060028D3 RID: 10451 RVA: 0x00154E68 File Offset: 0x00153068
	public LiveFeature.LBStatus getLeaderBoardStatus(int mode)
	{
		return this.l_status[mode];
	}

	// Token: 0x060028D4 RID: 10452 RVA: 0x00154E74 File Offset: 0x00153074
	public void startReadingLeaderBoard(int mode)
	{
		try
		{
			if (XBOXLive.signinStatus != XBOXLive.SigninStatus.Local)
			{
				if (XBOXLive.signinStatus == XBOXLive.SigninStatus.UpdateNeeded)
				{
					this.l_status[mode] = LiveFeature.LBStatus.ReadFail;
				}
				else
				{
					this.readErrorMSG = null;
					SignedInGamer signedInGamer = Gamer.SignedInGamers[PlayerIndex.One];
					if (signedInGamer != null)
					{
						LeaderboardIdentity leaderboardId;
						if (mode > 23)
						{
							leaderboardId = LeaderboardIdentity.Create(LeaderboardKey.BestTimeLifeTime, mode);
						}
						else
						{
							leaderboardId = LeaderboardIdentity.Create(LeaderboardKey.BestScoreLifeTime, mode);
						}
						LeaderboardReader.BeginRead(leaderboardId, signedInGamer, 100, new AsyncCallback(this.LeaderboardReadCallback), signedInGamer);
						this.l_status[mode] = LiveFeature.LBStatus.StartedRead;
					}
					else
					{
						this.l_status[mode] = LiveFeature.LBStatus.ReadFail;
					}
					this.startedRead = mode;
				}
			}
		}
		catch (GameUpdateRequiredException e)
		{
			this.l_status[mode] = LiveFeature.LBStatus.ReadFail;
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
			this.l_status[mode] = LiveFeature.LBStatus.ReadFail;
		}
	}

	// Token: 0x060028D5 RID: 10453 RVA: 0x00154F3C File Offset: 0x0015313C
	private void LeaderboardReadCallback(IAsyncResult result)
	{
		int num = -1;
		if (this.startedRead != -1)
		{
			num = this.startedRead;
		}
		try
		{
			SignedInGamer signedInGamer = result.AsyncState as SignedInGamer;
			LeaderboardReader leaderboardReader = LeaderboardReader.EndRead(result);
			num = leaderboardReader.LeaderboardIdentity.GameMode;
			this.hiScoresTables[num] = new LiveFeature.HISCORE_ENTRY[leaderboardReader.Entries.Count];
			for (int i = 0; i < leaderboardReader.Entries.Count; i++)
			{
				LeaderboardEntry leaderboardEntry = leaderboardReader.Entries[i];
				bool isMe = leaderboardEntry.Gamer.Gamertag == signedInGamer.Gamertag;
				this.hiScoresTables[num][i].index = i + 1;
				this.hiScoresTables[num][i].isMe = isMe;
				this.hiScoresTables[num][i].name = leaderboardEntry.Gamer.Gamertag;
				if (num > 23)
				{
					this.hiScoresTables[num][i].value = leaderboardEntry.Columns.GetValueInt32("BestTime");
				}
				else
				{
					this.hiScoresTables[num][i].value = leaderboardEntry.Columns.GetValueInt32("BestScore");
				}
				this.hiScoresTables[num][i].date = leaderboardEntry.Columns.GetValueDateTime("LastPlayedDateTime").ToLocalTime();
			}
			this.l_status[num] = LiveFeature.LBStatus.ReadSuccess;
		}
		catch (GameUpdateRequiredException e)
		{
			if (num == -1)
			{
				num = 0;
			}
			this.l_status[num] = LiveFeature.LBStatus.ReadFail;
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception ex)
		{
			if (num == -1)
			{
				num = 0;
			}
			this.l_status[num] = LiveFeature.LBStatus.ReadFail;
			this.readErrorMSG = ex.Message;
		}
		this.startedRead = -1;
	}

	// Token: 0x060028D6 RID: 10454 RVA: 0x00155120 File Offset: 0x00153320
	public bool saveLeaderBoardScore(int index, int value)
	{
		if (XBOXLive.isTrial())
		{
			return false;
		}
		bool result;
		try
		{
			if (XBOXLive.signinStatus == XBOXLive.SigninStatus.UpdateNeeded)
			{
				result = false;
			}
			else
			{
				SignedInGamer signedInGamer = Gamer.SignedInGamers[PlayerIndex.One];
				if (signedInGamer != null)
				{
					if (index > 23)
					{
						LeaderboardIdentity leaderboardId = LeaderboardIdentity.Create(LeaderboardKey.BestTimeLifeTime, index);
						LeaderboardEntry leaderboard = signedInGamer.LeaderboardWriter.GetLeaderboard(leaderboardId);
						leaderboard.Rating = (long)value;
						leaderboard.Columns.SetValue("Time", value);
						leaderboard.Columns.SetValue("TimeStamp", DateTime.Now);
					}
					else
					{
						LeaderboardIdentity leaderboardId2 = LeaderboardIdentity.Create(LeaderboardKey.BestScoreLifeTime, index);
						LeaderboardEntry leaderboard2 = signedInGamer.LeaderboardWriter.GetLeaderboard(leaderboardId2);
						leaderboard2.Rating = (long)value;
						leaderboard2.Columns.SetValue("Score", value);
						leaderboard2.Columns.SetValue("TimeStamp", DateTime.Now);
					}
				}
				result = true;
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
			result = false;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060028D7 RID: 10455 RVA: 0x00155220 File Offset: 0x00153420
	public static LiveFeature getInstance()
	{
		if (LiveFeature.instance == null)
		{
			LiveFeature.instance = new LiveFeature();
		}
		return LiveFeature.instance;
	}

	// Token: 0x060028D8 RID: 10456 RVA: 0x00155238 File Offset: 0x00153438
	private void GetAchievementsCallback(IAsyncResult result)
	{
		try
		{
			if (XBOXLive.signinStatus != XBOXLive.SigninStatus.UpdateNeeded)
			{
				SignedInGamer signedInGamer = result.AsyncState as SignedInGamer;
				if (signedInGamer != null)
				{
					AchievementCollection achievementCollection = signedInGamer.EndGetAchievements(result);
					foreach (Achievement achievement in achievementCollection)
					{
						string key = achievement.Key;
						for (int i = 0; i < AppMain.achievements.Length; i++)
						{
							if (AppMain.achievements[i].id == key)
							{
								if (achievement.IsEarned)
								{
									AppMain.gs_trophy_acquisition_tbl[i] = 2;
								}
								else
								{
									AppMain.gs_trophy_acquisition_tbl[i] = 0;
								}
							}
						}
					}
				}
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060028D9 RID: 10457 RVA: 0x00155318 File Offset: 0x00153518
	public bool GotAchievment(string achievementKey)
	{
		try
		{
			if (XBOXLive.signinStatus == XBOXLive.SigninStatus.UpdateNeeded)
			{
				return false;
			}
			if (this.gamer != null && !XBOXLive.isTrial())
			{
				this.gamer.BeginAwardAchievement(achievementKey, new AsyncCallback(this.AwardAchievementCallback), this.gamer);
				return true;
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
		}
		return false;
	}

	// Token: 0x060028DA RID: 10458 RVA: 0x00155390 File Offset: 0x00153590
	private void AwardAchievementCallback(IAsyncResult result)
	{
		try
		{
			if (XBOXLive.signinStatus != XBOXLive.SigninStatus.UpdateNeeded)
			{
				SignedInGamer signedInGamer = result.AsyncState as SignedInGamer;
				if (signedInGamer != null)
				{
					signedInGamer.EndAwardAchievement(result);
					this.gamer.BeginGetAchievements(new AsyncCallback(this.GetAchievementsCallback), this.gamer);
				}
			}
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060028DB RID: 10459 RVA: 0x00155408 File Offset: 0x00153608
	public void clearHiScores()
	{
		for (int i = 0; i < 48; i++)
		{
			this.l_status[i] = LiveFeature.LBStatus.NotRead;
			this.hiScoresTables[i] = null;
		}
	}

	// Token: 0x060028DC RID: 10460 RVA: 0x00155434 File Offset: 0x00153634
	public override void _initTextDialog(out string dlgYes, out string dlgNo, out string dlgCaption, out string dlgText)
	{
		dlgYes = Strings.ID_YES;
		dlgNo = Strings.ID_NO;
		dlgCaption = Strings.ID_UPDATE_CAPTION;
		dlgText = Strings.ID_UPDATE_TEXT;
	}

	// Token: 0x060028DD RID: 10461 RVA: 0x00155454 File Offset: 0x00153654
	internal void ShowAchievements()
	{
		LiveFeature.interruptMainLoop = 1;
		this.offsetY = 0;
		int num = AppMain.achievements.Length;
		LiveFeature.achievements_total = 0;
		LiveFeature.achievements_current = 0;
		if (LiveFeature.a_images == null)
		{
			LiveFeature.a_images = new Texture2D[AppMain.achievements.Length];
		}
		LiveFeature.achievementTextArray = new LiveFeature.AchievementText[num];
		for (int i = 0; i < num; i++)
		{
			LiveFeature.achievements_total += AppMain.achievements[i].cost;
			if (AppMain.gs_trophy_acquisition_tbl[i] == 2)
			{
				LiveFeature.achievements_current += AppMain.achievements[i].cost;
			}
			LiveFeature.a_images[i] = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\live_a" + (i + 1) + ".png"));
			LiveFeature.achievementTextArray[i].verticalSize = -1;
		}
		if (LiveFeature.a_bg == null)
		{
			LiveFeature.a_bg = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\tab.png"));
		}
		if (LiveFeature.arrowImg2 == null)
		{
			LiveFeature.arrowImg2 = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\arrow2.png"));
		}
		if (LiveFeature.titleImg == null)
		{
			LiveFeature.titleImg = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\ach_top_" + LiveFeature.lang_suffix[AppMain.GsEnvGetLanguage()] + ".png"));
		}
	}

	// Token: 0x060028DE RID: 10462 RVA: 0x001555B4 File Offset: 0x001537B4
	internal void ShowLeaderboards()
	{
		LiveFeature.interruptMainLoop = 2;
		this.offsetY = 0;
		this.curStage = 24;
		this.clearHiScores();
		if (LiveFeature.arrowImg == null)
		{
			LiveFeature.arrowImg = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\arrow.png"));
		}
		if (LiveFeature.a_bg == null)
		{
			LiveFeature.a_bg = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\tab.png"));
		}
		if (LiveFeature.nums == null)
		{
			LiveFeature.nums = Texture2D.FromStream(LiveFeature.GAME.GraphicsDevice, TitleContainer.OpenStream("Content\\LIVE\\nums.png"));
		}
		this.startReadingLeaderBoard(this.curStage);
	}

	// Token: 0x060028DF RID: 10463 RVA: 0x00155658 File Offset: 0x00153858
	public bool InputOverride()
	{
		if (LiveFeature.interruptMainLoop == 0)
		{
			return false;
		}
		MouseState state = Mouse.GetState();
		this.cX = state.X;
		this.cY = state.Y;
		if (((state.LeftButton == ButtonState.Pressed && this.pX != 0 && this.pY != 0) || state.LeftButton == ButtonState.Released) && this.cY > 240 && this.cX > 350)
		{
			return false;
		}
		if (LiveFeature.interruptMainLoop == 2)
		{
			if (AppMain.GsTrialIsTrial() || XBOXLive.signinStatus == XBOXLive.SigninStatus.Local)
			{
				return false;
			}
			if (state.LeftButton == ButtonState.Pressed)
			{
				this.pX = this.cX;
				this.pY = this.cY;
			}
			if (state.LeftButton == ButtonState.Released && this.pX != 0 && this.pY != 0)
			{
				bool flag = false;
				if (LiveFeature.arrow1_Left.Contains(this.cX, this.cY))
				{
					this.curStage--;
					if (this.curStage < 24)
					{
						this.curStage = 47;
					}
					flag = true;
				}
				else if (LiveFeature.arrow1_Right.Contains(this.cX, this.cY))
				{
					this.curStage++;
					if (this.curStage > 47)
					{
						this.curStage = 24;
					}
					flag = true;
				}
				this.cX = (this.pX = (this.pY = (this.cY = 0)));
				if (flag && this.l_status[this.curStage] != LiveFeature.LBStatus.ReadSuccess && this.l_status[this.curStage] != LiveFeature.LBStatus.ReadFail)
				{
					this.startReadingLeaderBoard(this.curStage);
				}
			}
		}
		else
		{
			if (state.LeftButton == ButtonState.Released)
			{
				this.pX = (this.pY = (this.cY = (this.cX = 0)));
				this.deltaX = 0;
				this.deltaY = 0;
				return true;
			}
			if (state.LeftButton == ButtonState.Pressed)
			{
				if (this.pX == 0 && this.pY == 0)
				{
					this.pX = this.cX;
					this.pY = this.cY;
					if (LiveFeature.arrow2_Up.Contains(this.cX, this.cY))
					{
						this.offsetY += 5;
						if (this.offsetY > 0)
						{
							this.offsetY = 0;
						}
						this.pX = 0;
						this.pY = 0;
					}
					if (LiveFeature.arrow2_Down.Contains(this.cX, this.cY))
					{
						this.offsetY -= 5;
						this.pX = 0;
						this.pY = 0;
					}
				}
				else
				{
					this.deltaX = this.pX - this.cX;
					this.deltaY = this.pY - this.cY;
					this.offsetY -= this.deltaY;
					if (this.offsetY > 0)
					{
						this.offsetY = 0;
					}
					this.pX = this.cX;
					this.pY = this.cY;
				}
			}
		}
		return true;
	}

	// Token: 0x060028E0 RID: 10464 RVA: 0x00155970 File Offset: 0x00153B70
	private void _drawAchievements(SpriteBatch spriteBatch, SpriteFont[] fonts)
	{
		int num = 0;
		spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
		try
		{
			if (AppMain.dm_xbox_show_progress != 100)
			{
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(10, 55, 230, (int)(170f * ((float)AppMain.dm_xbox_show_progress / 100f))), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(240, 55, 230, (int)(170f * ((float)AppMain.dm_xbox_show_progress / 100f))), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
			}
			else
			{
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(10, 55, 230, 170), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(240, 55, 230, 170), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
			}
			spriteBatch.Draw(LiveFeature.titleImg, new Rectangle(15, 22, 128, 16), Color.White);
			if (AppMain.dm_xbox_show_progress == 100)
			{
				string text = string.Concat(new object[]
				{
					LiveFeature.achievements_current,
					"/",
					LiveFeature.achievements_total,
					" G"
				});
				Vector2 vector = fonts[1].MeasureString(text);
				spriteBatch.DrawString(fonts[0], text, new Vector2((float)(240 - ((int)vector.X >> 1)), 60f), Color.White);
			}
		}
		finally
		{
			spriteBatch.End();
		}
		if (AppMain.dm_xbox_show_progress == 100)
		{
			LiveFeature.GAME.GraphicsDevice.ScissorRectangle = new Rectangle(15, 80, 450, 140);
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, LiveFeature.GAME.scissorState);
			try
			{
				num = this.offsetY + 80;
				Rectangle destinationRectangle = new Rectangle(30, num, 35, 35);
				for (int i = 0; i < AppMain.achievements.Length; i++)
				{
					bool flag = AppMain.gs_trophy_acquisition_tbl[i] == 2;
					spriteBatch.Draw(LiveFeature.a_images[i], destinationRectangle, flag ? Color.White : LiveFeature.transparent_achiev);
					if (!flag)
					{
						Color gray = Color.Gray;
					}
					else
					{
						Color white = Color.White;
					}
					string text = string.Concat(new object[]
					{
						AppMain.achievements[i].name,
						" (",
						AppMain.achievements[i].cost,
						" G)"
					});
					Vector2 vector = fonts[1].MeasureString(text);
					if (num > 0 && num < 220)
					{
						spriteBatch.DrawString(fonts[1], text, new Vector2(70f, (float)num), Color.White);
					}
					num += (int)vector.Y;
					if ((num > 0 && num < 220) || LiveFeature.achievementTextArray[i].verticalSize == -1)
					{
						if (LiveFeature.achievementTextArray[i].text == null)
						{
							LiveFeature.achievementTextArray[i].text = LiveFeature._wrapString(AppMain.achievements[i].description, 380, fonts[0]);
						}
						LiveFeature.achievementTextArray[i].verticalSize = LiveFeature._drawWrapText(LiveFeature.achievementTextArray[i].text, 70, num, 380, Color.White, false, fonts[0], spriteBatch);
					}
					num += LiveFeature.achievementTextArray[i].verticalSize;
					destinationRectangle.Y = num;
				}
				if (num < 220)
				{
					this.offsetY -= num - 220;
				}
			}
			finally
			{
				spriteBatch.End();
				LiveFeature.GAME.GraphicsDevice.ScissorRectangle = new Rectangle(0, 0, 480, 288);
			}
		}
		if (AppMain.dm_xbox_show_progress == 100)
		{
			LiveFeature.arrow_offset += 2;
			if (LiveFeature.arrow_offset > 16)
			{
				LiveFeature.arrow_offset = -16;
			}
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
			try
			{
				if (this.offsetY != 0)
				{
					Rectangle destinationRectangle2 = LiveFeature.arrow2_Up;
					destinationRectangle2.Y -= Math.Abs(LiveFeature.arrow_offset);
					spriteBatch.Draw(LiveFeature.arrowImg2, destinationRectangle2, Color.White);
				}
				if (num > 220)
				{
					Rectangle destinationRectangle2 = LiveFeature.arrow2_Down;
					destinationRectangle2.Y += Math.Abs(LiveFeature.arrow_offset);
					spriteBatch.Draw(LiveFeature.arrowImg2, destinationRectangle2, default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipVertically, 0f);
				}
			}
			finally
			{
				spriteBatch.End();
			}
		}
	}

	// Token: 0x060028E1 RID: 10465 RVA: 0x00155EA0 File Offset: 0x001540A0
	private void _drawLeaderboards(SpriteBatch spriteBatch, SpriteFont[] fonts)
	{
		spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
		try
		{
			if (AppMain.dm_xbox_show_progress != 100)
			{
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(10, 55 - (int)(40f * ((float)AppMain.dm_xbox_show_progress / 100f)), 230, (int)(220f * ((float)AppMain.dm_xbox_show_progress / 100f))), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(240, 55 - (int)(40f * ((float)AppMain.dm_xbox_show_progress / 100f)), 230, (int)(220f * ((float)AppMain.dm_xbox_show_progress / 100f))), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
			}
			else
			{
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(10, 15, 230, 220), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
				spriteBatch.Draw(LiveFeature.a_bg, new Rectangle(240, 15, 230, 220), default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
			}
			if (AppMain.dm_xbox_show_progress == 100)
			{
				int num = this.curStage;
				if (num > 23)
				{
					num -= 24;
				}
				string text;
				if (num < 16)
				{
					text = LiveFeature.zone_names[num / 4];
					if (num % 4 == 3)
					{
						text = string.Format(text, Strings.ID_BOSS);
					}
					else
					{
						text = string.Format(text, string.Format(Strings.ID_ACT, new string[]
						{
							string.Concat(num % 4 + 1)
						}));
					}
				}
				else if (num == 16)
				{
					text = Strings.ID_FINALZONE;
				}
				else
				{
					text = LiveFeature.zone_names[5];
					text = string.Format(text, new string[]
					{
						string.Concat(num - 16)
					});
				}
				Vector2 vector = fonts[2].MeasureString(text);
				spriteBatch.DrawString(fonts[2], text, new Vector2((float)(240 - ((int)vector.X >> 1)), 27f), Color.White);
				LiveFeature.arrow_offset += 2;
				if (LiveFeature.arrow_offset > 16)
				{
					LiveFeature.arrow_offset = -16;
				}
				Rectangle destinationRectangle = LiveFeature.arrow1_Left;
				destinationRectangle.X -= Math.Abs(LiveFeature.arrow_offset);
				spriteBatch.Draw(LiveFeature.arrowImg, destinationRectangle, default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
				destinationRectangle = LiveFeature.arrow1_Right;
				destinationRectangle.X += Math.Abs(LiveFeature.arrow_offset);
				spriteBatch.Draw(LiveFeature.arrowImg, destinationRectangle, default(Rectangle?), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
				text = string.Concat(num + 1);
				int i = 0;
				int num2 = text.Length;
				while (i < text.Length)
				{
					LiveFeature.num_dst_rect.X = 240 - 10 * num2;
					if (text[i] == '0')
					{
						LiveFeature.num_src_rect.X = 144;
					}
					else
					{
						LiveFeature.num_src_rect.X = (int)('\u0010' * (text[i] - '1'));
					}
					spriteBatch.Draw(LiveFeature.nums, LiveFeature.num_dst_rect, new Rectangle?(LiveFeature.num_src_rect), Color.White);
					i++;
					num2--;
				}
				LiveFeature.num_src_rect.X = 160;
				LiveFeature.num_src_rect.Width = 32;
				LiveFeature.num_dst_rect.X = 240;
				spriteBatch.Draw(LiveFeature.nums, LiveFeature.num_dst_rect, new Rectangle?(LiveFeature.num_src_rect), Color.White);
				LiveFeature.num_src_rect.Width = 16;
				LiveFeature.num_dst_rect.X = 250;
				LiveFeature.num_src_rect.X = 16;
				spriteBatch.Draw(LiveFeature.nums, LiveFeature.num_dst_rect, new Rectangle?(LiveFeature.num_src_rect), Color.White);
				LiveFeature.num_dst_rect.X = 260;
				LiveFeature.num_src_rect.X = 48;
				spriteBatch.Draw(LiveFeature.nums, LiveFeature.num_dst_rect, new Rectangle?(LiveFeature.num_src_rect), Color.White);
				int num3 = (AppMain.g_gs_env_language == 0 || AppMain.g_gs_env_language == 1 || AppMain.g_gs_env_language == 4 || AppMain.g_gs_env_language == 5) ? 0 : 1;
				text = Strings.ID_LB_RANK;
				vector = fonts[1].MeasureString(text);
				spriteBatch.DrawString(fonts[1], text, new Vector2((float)(LiveFeature.table_x[0, num3] - ((int)vector.X >> 1)), 47f), Color.White);
				text = Strings.ID_LB_GTAG;
				vector = fonts[1].MeasureString(text);
				spriteBatch.DrawString(fonts[1], text, new Vector2((float)(LiveFeature.table_x[1, num3] - ((int)vector.X >> 1)), 47f), Color.White);
				text = Strings.ID_BESTTIME;
				vector = fonts[1].MeasureString(text);
				spriteBatch.DrawString(fonts[1], text, new Vector2((float)(LiveFeature.table_x[2, num3] - ((int)vector.X >> 1)), 47f), Color.White);
				text = Strings.ID_LB_DATE;
				vector = fonts[1].MeasureString(text);
				spriteBatch.DrawString(fonts[1], text, new Vector2((float)(LiveFeature.table_x[3, num3] - ((int)vector.X >> 1)), 47f), Color.White);
				int num4 = 67;
				if (this.l_status[this.curStage] == LiveFeature.LBStatus.StartedRead)
				{
					text = Strings.ID_LOADING;
					LiveFeature._drawWrapText(text, 240, 144, 450, Color.White, true, fonts[1], spriteBatch);
				}
				else if (this.l_status[this.curStage] == LiveFeature.LBStatus.ReadFail)
				{
					text = Strings.ID_LB_UNABLE;
					LiveFeature._drawWrapText(text, 240, 144, 450, Color.White, true, fonts[1], spriteBatch);
				}
				else if (this.hiScoresTables[this.curStage] != null && this.hiScoresTables[this.curStage].Length != 0)
				{
					if (AppMain.dm_xbox_show_progress == 100)
					{
						Color color = Color.White;
						for (int j = 0; j < this.hiScoresTables[this.curStage].Length; j++)
						{
							if (j < 5 || (j >= 5 && this.hiScoresTables[this.curStage][j].isMe))
							{
								color = (this.hiScoresTables[this.curStage][j].isMe ? new Color(154 - Math.Abs(LiveFeature.arrow_offset << 3), 255, 100 - Math.Abs(LiveFeature.arrow_offset << 2)) : Color.WhiteSmoke);
								text = string.Concat(this.hiScoresTables[this.curStage][j].index);
								vector = fonts[0].MeasureString(text);
								spriteBatch.DrawString(fonts[0], text, new Vector2((float)(LiveFeature.table_x[0, num3] - ((int)vector.X >> 1)), (float)num4), color);
								text = this.hiScoresTables[this.curStage][j].name;
								vector = fonts[0].MeasureString(text);
								spriteBatch.DrawString(fonts[0], text, new Vector2((float)(LiveFeature.table_x[1, num3] - ((int)vector.X >> 1)), (float)num4), color);
								if (this.curStage > 23)
								{
									ushort num5 = 0;
									ushort num6 = 0;
									ushort num7 = 0;
									AppMain.AkUtilFrame60ToTime((uint)this.hiScoresTables[this.curStage][j].value, ref num5, ref num6, ref num7);
									StringBuilder stringBuilder = new StringBuilder();
									if (num5 < 10)
									{
										stringBuilder.Append("0");
									}
									stringBuilder.Append(num5);
									stringBuilder.Append("'");
									if (num6 < 10)
									{
										stringBuilder.Append("0");
									}
									stringBuilder.Append(num6);
									stringBuilder.Append("''");
									if (num7 < 10)
									{
										stringBuilder.Append("0");
									}
									stringBuilder.Append(num7);
									text = stringBuilder.ToString();
								}
								else
								{
									text = string.Concat(this.hiScoresTables[this.curStage][j].value);
								}
								vector = fonts[0].MeasureString(text);
								spriteBatch.DrawString(fonts[0], text, new Vector2((float)(LiveFeature.table_x[2, num3] - ((int)vector.X >> 1)), (float)num4), color);
								text = string.Concat(this.hiScoresTables[this.curStage][j].date);
								vector = fonts[0].MeasureString(text);
								spriteBatch.DrawString(fonts[0], text, new Vector2((float)(LiveFeature.table_x[3, num3] - ((int)vector.X >> 1)), (float)num4), color);
								num4 += (int)vector.Y;
							}
						}
					}
				}
				else
				{
					text = Strings.ID_LB_NORECORDS;
					LiveFeature._drawWrapText(text, 240, 144, 450, Color.White, true, fonts[1], spriteBatch);
				}
			}
		}
		finally
		{
			spriteBatch.End();
		}
	}

	// Token: 0x060028E2 RID: 10466 RVA: 0x001567F0 File Offset: 0x001549F0
	public void ShowOverride()
	{
		if (LiveFeature.interruptMainLoop == 0)
		{
			return;
		}
		if (LiveFeature.interruptMainLoop == 2)
		{
			this._drawLeaderboards(LiveFeature.GAME.spriteBatch, LiveFeature.GAME.fnts);
			return;
		}
		if (LiveFeature.interruptMainLoop == 1)
		{
			this._drawAchievements(LiveFeature.GAME.spriteBatch, LiveFeature.GAME.fnts);
		}
	}

	// Token: 0x060028E3 RID: 10467 RVA: 0x0015684A File Offset: 0x00154A4A
	public static bool isInterrupted()
	{
		return LiveFeature.interruptMainLoop != 0;
	}

	// Token: 0x060028E4 RID: 10468 RVA: 0x00156858 File Offset: 0x00154A58
	internal static void endInterrupt()
	{
		if (LiveFeature.interruptMainLoop == 1)
		{
			int num = AppMain.achievements.Length;
			for (int i = 0; i < num; i++)
			{
				LiveFeature.a_images[i].Dispose();
				LiveFeature.a_images[i] = null;
			}
			LiveFeature.a_images = null;
			LiveFeature.a_bg.Dispose();
			LiveFeature.a_bg = null;
			LiveFeature.arrowImg2.Dispose();
			LiveFeature.arrowImg2 = null;
			LiveFeature.titleImg.Dispose();
			LiveFeature.titleImg = null;
			LiveFeature.achievementTextArray = null;
		}
		if (LiveFeature.interruptMainLoop == 2)
		{
			LiveFeature.a_bg.Dispose();
			LiveFeature.a_bg = null;
			LiveFeature.arrowImg.Dispose();
			LiveFeature.arrowImg = null;
			LiveFeature.nums.Dispose();
			LiveFeature.nums = null;
			LiveFeature.getInstance().clearHiScores();
		}
		LiveFeature.interruptMainLoop = 0;
	}

	// Token: 0x060028E5 RID: 10469 RVA: 0x0015691C File Offset: 0x00154B1C
	public static string[] _wrapString(string s, int width, SpriteFont font)
	{
		List<string> list = new List<string>(5);
		s = s.Trim();
		string[] array = s.Split(new char[]
		{
			' '
		}, 1);
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string text in array)
		{
			Vector2 vector = font.MeasureString(text + " ");
			if (vector.X + (float)num > (float)width)
			{
				num = 0;
				list.Add(stringBuilder.ToString());
				stringBuilder.Remove(0, stringBuilder.Length);
				stringBuilder.Append(text);
				stringBuilder.Append(" ");
				num += (int)vector.X;
			}
			else
			{
				stringBuilder.Append(text);
				stringBuilder.Append(" ");
				num += (int)vector.X;
				if (text.Contains("\r\n"))
				{
					num = 0;
				}
			}
		}
		list.Add(stringBuilder.ToString());
		return list.ToArray();
	}

	// Token: 0x060028E6 RID: 10470 RVA: 0x00156A20 File Offset: 0x00154C20
	public static int _drawWrapText(string text, int x, int y, int width, Color color, bool isXCenter, SpriteFont font, SpriteBatch sb, float corrector)
	{
		return LiveFeature._drawWrapText(LiveFeature._wrapString(text, width, font), x, y, width, color, isXCenter, font, sb, corrector);
	}

	// Token: 0x060028E7 RID: 10471 RVA: 0x00156A48 File Offset: 0x00154C48
	public static int _drawWrapText(string text, int x, int y, int width, Color color, bool isXCenter, SpriteFont font, SpriteBatch sb)
	{
		return LiveFeature._drawWrapText(LiveFeature._wrapString(text, width, font), x, y, width, color, isXCenter, font, sb);
	}

	// Token: 0x060028E8 RID: 10472 RVA: 0x00156A64 File Offset: 0x00154C64
	public static int _drawWrapText(string[] s, int x, int y, int width, Color color, bool isXCenter, SpriteFont font, SpriteBatch sb, float corrector)
	{
		Vector2 position = new Vector2((float)x, (float)y);
		int num = 0;
		foreach (string text in s)
		{
			Vector2 vector = font.MeasureString(text);
			if (isXCenter)
			{
				position.X = (float)(x - ((int)vector.X >> 1));
			}
			sb.DrawString(font, text, position, color);
			position.Y += vector.Y * corrector;
			num += (int)(vector.Y * corrector);
		}
		return num;
	}

	// Token: 0x060028E9 RID: 10473 RVA: 0x00156AF0 File Offset: 0x00154CF0
	public static int _drawWrapText(string[] s, int x, int y, int width, Color color, bool isXCenter, SpriteFont font, SpriteBatch sb)
	{
		return LiveFeature._drawWrapText(s, x, y, width, color, isXCenter, font, sb, 1f);
	}

	// Token: 0x040062F2 RID: 25330
	private const int screenw = 480;

	// Token: 0x040062F3 RID: 25331
	private const int screenh = 288;

	// Token: 0x040062F4 RID: 25332
	private const int title_y = 22;

	// Token: 0x040062F5 RID: 25333
	private const int title_x = 15;

	// Token: 0x040062F6 RID: 25334
	private const int center_x = 240;

	// Token: 0x040062F7 RID: 25335
	private const int pad_x1 = 10;

	// Token: 0x040062F8 RID: 25336
	private const int pad_w = 230;

	// Token: 0x040062F9 RID: 25337
	private const int pad_h = 170;

	// Token: 0x040062FA RID: 25338
	private const int pad_h2 = 220;

	// Token: 0x040062FB RID: 25339
	private const int pad_x2 = 240;

	// Token: 0x040062FC RID: 25340
	private const int pad_y = 55;

	// Token: 0x040062FD RID: 25341
	private const int pad_y2 = 15;

	// Token: 0x040062FE RID: 25342
	private const int title_y1 = 27;

	// Token: 0x040062FF RID: 25343
	private const int title_y2 = 60;

	// Token: 0x04006300 RID: 25344
	private const int clip_x = 15;

	// Token: 0x04006301 RID: 25345
	private const int clip_y = 80;

	// Token: 0x04006302 RID: 25346
	private const int clip_w = 450;

	// Token: 0x04006303 RID: 25347
	private const int clip_h = 140;

	// Token: 0x04006304 RID: 25348
	private const int title_y3 = 47;

	// Token: 0x04006305 RID: 25349
	private const int title_y4 = 67;

	// Token: 0x04006306 RID: 25350
	private const int title_y5 = 87;

	// Token: 0x04006307 RID: 25351
	private const int arrow_left_x = 165;

	// Token: 0x04006308 RID: 25352
	private const int arrow_right_x = 285;

	// Token: 0x04006309 RID: 25353
	private const int arrow_y = 240;

	// Token: 0x0400630A RID: 25354
	private const int left_x = 30;

	// Token: 0x0400630B RID: 25355
	private const int list_y = 80;

	// Token: 0x0400630C RID: 25356
	private const int bottom_y = 220;

	// Token: 0x0400630D RID: 25357
	private const int draw_width = 420;

	// Token: 0x0400630E RID: 25358
	private const int icon_paddle = 40;

	// Token: 0x0400630F RID: 25359
	private static LiveFeature instance;

	// Token: 0x04006310 RID: 25360
	private SignedInGamer gamer;

	// Token: 0x04006311 RID: 25361
	private GamerProfile profile;

	// Token: 0x04006312 RID: 25362
	private static readonly string[] zone_names = new string[]
	{
		Strings.ID_STAGE1,
		Strings.ID_STAGE2,
		Strings.ID_STAGE3,
		Strings.ID_STAGE4,
		Strings.ID_FINALZONE,
		Strings.ID_SSTAGE
	};

	// Token: 0x04006313 RID: 25363
	private LiveFeature.HISCORE_ENTRY[][] hiScoresTables = new LiveFeature.HISCORE_ENTRY[48][];

	// Token: 0x04006314 RID: 25364
	public static Sonic4Ep1 GAME;

	// Token: 0x04006315 RID: 25365
	private LiveFeature.LBStatus[] l_status = new LiveFeature.LBStatus[48];

	// Token: 0x04006316 RID: 25366
	public int startedRead = -1;

	// Token: 0x04006317 RID: 25367
	public string readErrorMSG;

	// Token: 0x04006318 RID: 25368
	public static readonly string[] lang_suffix = new string[]
	{
		"ja",
		"us",
		"fr",
		"it",
		"ge",
		"es",
		"fi",
		"pt",
		"ru",
		"cn",
		"hk"
	};

	// Token: 0x04006319 RID: 25369
	public static int interruptMainLoop = 0;

	// Token: 0x0400631A RID: 25370
	public static int achievements_total;

	// Token: 0x0400631B RID: 25371
	public static int achievements_current;

	// Token: 0x0400631C RID: 25372
	public static Texture2D[] a_images;

	// Token: 0x0400631D RID: 25373
	public static Texture2D a_bg;

	// Token: 0x0400631E RID: 25374
	private int pX;

	// Token: 0x0400631F RID: 25375
	private int pY;

	// Token: 0x04006320 RID: 25376
	private int cX;

	// Token: 0x04006321 RID: 25377
	private int cY;

	// Token: 0x04006322 RID: 25378
	private int deltaX;

	// Token: 0x04006323 RID: 25379
	private int deltaY;

	// Token: 0x04006324 RID: 25380
	private int offsetY;

	// Token: 0x04006325 RID: 25381
	private int curStage;

	// Token: 0x04006326 RID: 25382
	private static Texture2D arrowImg;

	// Token: 0x04006327 RID: 25383
	private static Texture2D arrowImg2;

	// Token: 0x04006328 RID: 25384
	private static Texture2D titleImg;

	// Token: 0x04006329 RID: 25385
	private static Texture2D nums;

	// Token: 0x0400632A RID: 25386
	private static LiveFeature.AchievementText[] achievementTextArray;

	// Token: 0x0400632B RID: 25387
	public static readonly int[,] table_x = new int[,]
	{
		{
			60,
			70
		},
		{
			145,
			160
		},
		{
			260,
			275
		},
		{
			385,
			395
		}
	};

	// Token: 0x0400632C RID: 25388
	public static int arrow_offset = 0;

	// Token: 0x0400632D RID: 25389
	public static readonly Rectangle arrow1_Left = new Rectangle(165, 240, 40, 40);

	// Token: 0x0400632E RID: 25390
	public static readonly Rectangle arrow1_Right = new Rectangle(285, 240, 40, 40);

	// Token: 0x0400632F RID: 25391
	public static readonly Rectangle arrow2_Up = new Rectangle(430, 60, 35, 35);

	// Token: 0x04006330 RID: 25392
	public static readonly Rectangle arrow2_Down = new Rectangle(430, 180, 35, 35);

	// Token: 0x04006331 RID: 25393
	public static Rectangle num_src_rect = new Rectangle(0, 0, 16, 32);

	// Token: 0x04006332 RID: 25394
	public static Rectangle num_dst_rect = new Rectangle(0, 240, 16, 32);

	// Token: 0x04006333 RID: 25395
	public static readonly Color transparent_achiev = new Color(128, 128, 128, 128);

	// Token: 0x020003F4 RID: 1012
	public enum Stages
	{
		// Token: 0x04006335 RID: 25397
		Zone11_Score,
		// Token: 0x04006336 RID: 25398
		Zone12_Score,
		// Token: 0x04006337 RID: 25399
		Zone13_Score,
		// Token: 0x04006338 RID: 25400
		Zone14_Score,
		// Token: 0x04006339 RID: 25401
		Zone21_Score,
		// Token: 0x0400633A RID: 25402
		Zone22_Score,
		// Token: 0x0400633B RID: 25403
		Zone23_Score,
		// Token: 0x0400633C RID: 25404
		Zone24_Score,
		// Token: 0x0400633D RID: 25405
		Zone31_Score,
		// Token: 0x0400633E RID: 25406
		Zone32_Score,
		// Token: 0x0400633F RID: 25407
		Zone33_Score,
		// Token: 0x04006340 RID: 25408
		Zone34_Score,
		// Token: 0x04006341 RID: 25409
		Zone41_Score,
		// Token: 0x04006342 RID: 25410
		Zone42_Score,
		// Token: 0x04006343 RID: 25411
		Zone43_Score,
		// Token: 0x04006344 RID: 25412
		Zone44_Score,
		// Token: 0x04006345 RID: 25413
		ZoneF_Score,
		// Token: 0x04006346 RID: 25414
		ZoneSS1_Score,
		// Token: 0x04006347 RID: 25415
		ZoneSS2_Score,
		// Token: 0x04006348 RID: 25416
		ZoneSS3_Score,
		// Token: 0x04006349 RID: 25417
		ZoneSS4_Score,
		// Token: 0x0400634A RID: 25418
		ZoneSS5_Score,
		// Token: 0x0400634B RID: 25419
		ZoneSS6_Score,
		// Token: 0x0400634C RID: 25420
		ZoneSS7_Score,
		// Token: 0x0400634D RID: 25421
		Zone11_Time,
		// Token: 0x0400634E RID: 25422
		Zone12_Time,
		// Token: 0x0400634F RID: 25423
		Zone13_Time,
		// Token: 0x04006350 RID: 25424
		Zone14_Time,
		// Token: 0x04006351 RID: 25425
		Zone21_Time,
		// Token: 0x04006352 RID: 25426
		Zone22_Time,
		// Token: 0x04006353 RID: 25427
		Zone23_Time,
		// Token: 0x04006354 RID: 25428
		Zone24_Time,
		// Token: 0x04006355 RID: 25429
		Zone31_Time,
		// Token: 0x04006356 RID: 25430
		Zone32_Time,
		// Token: 0x04006357 RID: 25431
		Zone33_Time,
		// Token: 0x04006358 RID: 25432
		Zone34_Time,
		// Token: 0x04006359 RID: 25433
		Zone41_Time,
		// Token: 0x0400635A RID: 25434
		Zone42_Time,
		// Token: 0x0400635B RID: 25435
		Zone43_Time,
		// Token: 0x0400635C RID: 25436
		Zone44_Time,
		// Token: 0x0400635D RID: 25437
		ZoneF_Time,
		// Token: 0x0400635E RID: 25438
		ZoneSS1_Time,
		// Token: 0x0400635F RID: 25439
		ZoneSS2_Time,
		// Token: 0x04006360 RID: 25440
		ZoneSS3_Time,
		// Token: 0x04006361 RID: 25441
		ZoneSS4_Time,
		// Token: 0x04006362 RID: 25442
		ZoneSS5_Time,
		// Token: 0x04006363 RID: 25443
		ZoneSS6_Time,
		// Token: 0x04006364 RID: 25444
		ZoneSS7_Time,
		// Token: 0x04006365 RID: 25445
		LeaderboardsCount
	}

	// Token: 0x020003F5 RID: 1013
	public enum LBStatus
	{
		// Token: 0x04006367 RID: 25447
		NotRead,
		// Token: 0x04006368 RID: 25448
		StartedRead,
		// Token: 0x04006369 RID: 25449
		ReadSuccess,
		// Token: 0x0400636A RID: 25450
		ReadFail
	}

	// Token: 0x020003F6 RID: 1014
	public struct HISCORE_ENTRY
	{
		// Token: 0x0400636B RID: 25451
		public int index;

		// Token: 0x0400636C RID: 25452
		public bool isMe;

		// Token: 0x0400636D RID: 25453
		public string name;

		// Token: 0x0400636E RID: 25454
		public int value;

		// Token: 0x0400636F RID: 25455
		public DateTime date;
	}

	// Token: 0x020003F7 RID: 1015
	private struct AchievementText
	{
		// Token: 0x04006370 RID: 25456
		public string[] text;

		// Token: 0x04006371 RID: 25457
		public int verticalSize;
	}
}
