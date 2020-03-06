using System;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using mpp;

// Token: 0x020003E1 RID: 993
public class Sonic4Ep1 : Game
{
	// Token: 0x06002879 RID: 10361 RVA: 0x00152E78 File Offset: 0x00151078
	public Sonic4Ep1()
	{
		Sonic4Ep1.pInstance = this;
		this.graphics = new GraphicsDeviceManager(this);
		this.graphics.PreferredBackBufferWidth = 480;
		this.graphics.PreferredBackBufferHeight = 288;
		this.graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
		this.graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(this.graphics_PreparingDeviceSettings);
		this.graphics.SynchronizeWithVerticalRetrace = true;
		this.graphics.IsFullScreen = false;
		base.IsMouseVisible = true;
		base.Content.RootDirectory = "Content";
		base.TargetElapsedTime = TimeSpan.FromTicks(333333L);
		base.Activated += new EventHandler<EventArgs>(this.OnActivated);
		base.Deactivated += new EventHandler<EventArgs>(this.OnDeactivated);
	}

	// Token: 0x0600287A RID: 10362 RVA: 0x00152F69 File Offset: 0x00151169
	private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
	{
		PresentationParameters presentationParameters = e.GraphicsDeviceInformation.PresentationParameters;
	}

	// Token: 0x0600287B RID: 10363 RVA: 0x00152F78 File Offset: 0x00151178
	protected override void Initialize()
	{
		this.scissorState = new RasterizerState
		{
			ScissorTestEnable = true,
			CullMode = CullMode.None
		};
		Guide.IsScreenSaverEnabled = false;
		LiveFeature.GAME = this;
		LiveFeature.getInstance();
		base.Initialize();
	}

	// Token: 0x0600287C RID: 10364 RVA: 0x00152FB8 File Offset: 0x001511B8
	protected override void LoadContent()
	{
		this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
		this.fntKootenay = base.Content.Load<SpriteFont>("Kootenay");
		this.fnts[0] = base.Content.Load<SpriteFont>("small");
		this.fnts[1] = base.Content.Load<SpriteFont>("medium");
		this.fnts[2] = base.Content.Load<SpriteFont>("large");
		try
		{
			this.appMain = new AppMain(this, this.graphics, base.GraphicsDevice);
			this.appMain.AppInit("");
			if (this.accelerometer == null)
			{
				this.accelerometer = new Accelerometer();
			}
			this.accelerometer.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(this.accelerometer_ReadingChanged);
			try
			{
				this.accelerometer.Start();
			}
			catch (AccelerometerFailedException)
			{
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600287D RID: 10365 RVA: 0x001530B8 File Offset: 0x001512B8
	protected override void OnDeactivated(object sender, EventArgs args)
	{
		AppMain.isForeground = false;
		if (SaveState.saveLater)
		{
			SaveState._saveFile(SaveState.save);
		}
		//if (!Guide.IsVisible)
		//{
		//	this.storeSystemVolume = true;
		//	try
		//	{
		//		if (!AppMain.g_ao_sys_global.is_playing_device_bgm_music)
		//		{
		//			MediaPlayer.Pause();
		//		}
		//		MediaPlayer.Volume = this.deviceMusicVolume;
		//		return;
		//	}
		//	catch (Exception)
		//	{
		//		return;
		//	}
		//}
		//this.storeSystemVolume = false;
	}

	// Token: 0x0600287E RID: 10366 RVA: 0x00153128 File Offset: 0x00151328
	protected override void OnActivated(object sender, EventArgs args)
	{
		AppMain.isForeground = true;
		if (this.storeSystemVolume)
		{
			this.deviceMusicVolume = MediaPlayer.Volume;
		}
		if ((AppMain.g_gm_main_system.game_flag & 64U) == 0U)
		{
			AppMain.g_pause_flag = true;
		}
	}

	// Token: 0x0600287F RID: 10367 RVA: 0x00153158 File Offset: 0x00151358
	private void accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
	{
		this.accel.X = (float)e.X;
		this.accel.Y = (float)e.Y;
		this.accel.Z = (float)e.Z;
	}

	// Token: 0x06002880 RID: 10368 RVA: 0x00153190 File Offset: 0x00151390
	protected override void UnloadContent()
	{
	}

	// Token: 0x06002881 RID: 10369 RVA: 0x00153194 File Offset: 0x00151394
	protected override void Update(GameTime gameTime)
	{
		AppMain.lastGameTime = gameTime;
		if (!AppMain.g_ao_sys_global.is_show_ui && Sonic4Ep1.inputDataRead)
		{
			Sonic4Ep1.inputDataRead = false;
			if (!LiveFeature.getInstance().InputOverride() && !Upsell.inputUpsellScreen())
			{
				AppMain.onTouchEvents();
			}
			AppMain.amIPhoneAccelerate(ref this.accel);
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				AppMain.back_key_is_pressed = true;
			}
		}
		try
		{
			base.Update(gameTime);
		}
		catch (GameUpdateRequiredException e)
		{
			XBOXLive.HandleGameUpdateRequired(e);
		}
	}

	// Token: 0x06002882 RID: 10370 RVA: 0x00153224 File Offset: 0x00151424
	protected override void Draw(GameTime gameTime)
	{
		Sonic4Ep1.inputDataRead = true;
		OpenGL.drawPrimitives_Count = 0;
		OpenGL.drawVertexBuffer_Count = 0;
		this.appMain.AppMainLoop();
		this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
		this.spriteBatch.End();
		LiveFeature.getInstance().ShowOverride();
		Upsell.drawUpsellScreen();
		base.Draw(gameTime);
	}

	// Token: 0x040062A9 RID: 25257
	public static Sonic4Ep1 pInstance;

	// Token: 0x040062AA RID: 25258
	private GraphicsDeviceManager graphics;

	// Token: 0x040062AB RID: 25259
	private SpriteFont fntKootenay;

	// Token: 0x040062AC RID: 25260
	public SpriteFont[] fnts = new SpriteFont[3];

	// Token: 0x040062AD RID: 25261
	private int GCCount;

	// Token: 0x040062AE RID: 25262
	private WeakReference wr = new WeakReference(new object());

	// Token: 0x040062AF RID: 25263
	private double _lastUpdateMilliseconds;

	// Token: 0x040062B0 RID: 25264
	public static bool cheat = false;

	// Token: 0x040062B1 RID: 25265
	public RasterizerState scissorState;

	// Token: 0x040062B2 RID: 25266
	private Accelerometer accelerometer;

	// Token: 0x040062B3 RID: 25267
	private AppMain appMain;

	// Token: 0x040062B4 RID: 25268
	public SpriteBatch spriteBatch;

	// Token: 0x040062B5 RID: 25269
	protected float deviceMusicVolume;

	// Token: 0x040062B6 RID: 25270
	protected bool storeSystemVolume = true;

	// Token: 0x040062B7 RID: 25271
	private Vector3 accel;

	// Token: 0x040062B8 RID: 25272
	private static bool inputDataRead = true;
}
