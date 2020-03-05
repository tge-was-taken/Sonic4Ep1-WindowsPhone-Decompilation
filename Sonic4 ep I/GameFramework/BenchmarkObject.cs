using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework
{
	// Token: 0x020003FC RID: 1020
	public class BenchmarkObject : TextObject
	{
		// Token: 0x06002922 RID: 10530 RVA: 0x001572AB File Offset: 0x001554AB
		public BenchmarkObject(Game game, SpriteFont font, Vector2 position, Color textColor) : base(game, font, position)
		{
			this.SpriteColor = textColor;
		}

		// Token: 0x06002923 RID: 10531 RVA: 0x001572CC File Offset: 0x001554CC
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			if (gameTime.TotalGameTime.TotalMilliseconds > this._lastUpdateMilliseconds + 1000.0)
			{
				int num = this._drawCount - this._lastDrawCount;
				int updateCount = base.UpdateCount;
				double num2 = gameTime.TotalGameTime.TotalMilliseconds - this._lastUpdateMilliseconds;
				this._strBuilder.Length = 0;
				this._strBuilder.AppendLine(((double)((float)num) / num2 * 1000.0).ToString("0.0") + " FPS");
				base.Text = this._strBuilder.ToString();
				this._lastUpdateMilliseconds = gameTime.TotalGameTime.TotalMilliseconds;
				this._lastDrawCount = this._drawCount;
				this._lastUpdateCount = base.UpdateCount;
			}
		}

		// Token: 0x06002924 RID: 10532 RVA: 0x001573AB File Offset: 0x001555AB
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			this._drawCount++;
			base.Draw(gameTime, spriteBatch);
		}

		// Token: 0x04006388 RID: 25480
		private double _lastUpdateMilliseconds;

		// Token: 0x04006389 RID: 25481
		private int _drawCount;

		// Token: 0x0400638A RID: 25482
		private int _lastDrawCount;

		// Token: 0x0400638B RID: 25483
		private int _lastUpdateCount;

		// Token: 0x0400638C RID: 25484
		private StringBuilder _strBuilder = new StringBuilder();
	}
}
