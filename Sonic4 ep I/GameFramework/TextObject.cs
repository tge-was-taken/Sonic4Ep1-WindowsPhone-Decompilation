using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework
{
	// Token: 0x020003FA RID: 1018
	public class TextObject : SpriteObject
	{
		// Token: 0x06002912 RID: 10514 RVA: 0x00156FD7 File Offset: 0x001551D7
		public TextObject(Game game) : base(game)
		{
			this.ScaleX = 1f;
			this.ScaleY = 1f;
			this.SpriteColor = Color.White;
		}

		// Token: 0x06002913 RID: 10515 RVA: 0x00157001 File Offset: 0x00155201
		public TextObject(Game game, SpriteFont font) : this(game)
		{
			this.Font = font;
		}

		// Token: 0x06002914 RID: 10516 RVA: 0x00157011 File Offset: 0x00155211
		public TextObject(Game game, SpriteFont font, Vector2 position) : this(game, font)
		{
			this.PositionX = position.X;
			this.PositionY = position.Y;
		}

		// Token: 0x06002915 RID: 10517 RVA: 0x00157035 File Offset: 0x00155235
		public TextObject(Game game, SpriteFont font, Vector2 position, string text) : this(game, font, position)
		{
			this.Text = text;
		}

		// Token: 0x06002916 RID: 10518 RVA: 0x00157048 File Offset: 0x00155248
		public TextObject(Game game, SpriteFont font, Vector2 position, string text, TextObject.TextAlignment horizontalAlignment, TextObject.TextAlignment verticalAlignment) : this(game, font, position, text)
		{
			this.HorizontalAlignment = horizontalAlignment;
			this.VerticalAlignment = verticalAlignment;
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06002917 RID: 10519 RVA: 0x00157065 File Offset: 0x00155265
		// (set) Token: 0x06002918 RID: 10520 RVA: 0x0015706D File Offset: 0x0015526D
		public SpriteFont Font
		{
			get
			{
				return this._font;
			}
			set
			{
				if (this._font != value)
				{
					this._font = value;
					this.CalculateAlignmentOrigin();
				}
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06002919 RID: 10521 RVA: 0x00157085 File Offset: 0x00155285
		// (set) Token: 0x0600291A RID: 10522 RVA: 0x0015708D File Offset: 0x0015528D
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if (this._text != value)
				{
					this._text = value;
					this.CalculateAlignmentOrigin();
				}
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600291B RID: 10523 RVA: 0x001570AA File Offset: 0x001552AA
		// (set) Token: 0x0600291C RID: 10524 RVA: 0x001570B2 File Offset: 0x001552B2
		public TextObject.TextAlignment HorizontalAlignment
		{
			get
			{
				return this._horizontalAlignment;
			}
			set
			{
				if (this._horizontalAlignment != value)
				{
					this._horizontalAlignment = value;
					this.CalculateAlignmentOrigin();
				}
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600291D RID: 10525 RVA: 0x001570CA File Offset: 0x001552CA
		// (set) Token: 0x0600291E RID: 10526 RVA: 0x001570D2 File Offset: 0x001552D2
		public TextObject.TextAlignment VerticalAlignment
		{
			get
			{
				return this._verticalAlignment;
			}
			set
			{
				if (this._verticalAlignment != value)
				{
					this._verticalAlignment = value;
					this.CalculateAlignmentOrigin();
				}
			}
		}

		// Token: 0x0600291F RID: 10527 RVA: 0x001570EC File Offset: 0x001552EC
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			if (this.Font != null && this.Text != null && this.Text.Length > 0)
			{
				spriteBatch.DrawString(this.Font, this.Text, base.Position, this.SpriteColor, this.Angle, base.Origin, base.Scale, SpriteEffects.None, this.LayerDepth);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06002920 RID: 10528 RVA: 0x00157150 File Offset: 0x00155350
		public override Rectangle BoundingBox
		{
			get
			{
				Vector2 vector = this.Font.MeasureString(this.Text);
				Rectangle result = new Rectangle((int)this.PositionX, (int)this.PositionY, (int)(vector.X * this.ScaleX), (int)(vector.Y * this.ScaleY));
				result.Offset((int)(-this.OriginX * this.ScaleX), (int)(-this.OriginY * this.ScaleY));
				return result;
			}
		}

		// Token: 0x06002921 RID: 10529 RVA: 0x001571C8 File Offset: 0x001553C8
		private void CalculateAlignmentOrigin()
		{
			if (this.HorizontalAlignment == TextObject.TextAlignment.Manual && this.VerticalAlignment == TextObject.TextAlignment.Manual)
			{
				return;
			}
			if (this.Font == null || this.Text == null || this.Text.Length == 0)
			{
				return;
			}
			Vector2 vector = this.Font.MeasureString(this.Text);
			switch (this.HorizontalAlignment)
			{
			case TextObject.TextAlignment.Near:
				this.OriginX = 0f;
				break;
			case TextObject.TextAlignment.Center:
				this.OriginX = vector.X / 2f;
				break;
			case TextObject.TextAlignment.Far:
				this.OriginX = vector.X;
				break;
			}
			switch (this.VerticalAlignment)
			{
			case TextObject.TextAlignment.Near:
				this.OriginY = 0f;
				return;
			case TextObject.TextAlignment.Center:
				this.OriginY = vector.Y / 2f;
				return;
			case TextObject.TextAlignment.Far:
				this.OriginY = vector.Y;
				return;
			default:
				return;
			}
		}

		// Token: 0x0400637F RID: 25471
		private SpriteFont _font;

		// Token: 0x04006380 RID: 25472
		private string _text;

		// Token: 0x04006381 RID: 25473
		private TextObject.TextAlignment _horizontalAlignment;

		// Token: 0x04006382 RID: 25474
		private TextObject.TextAlignment _verticalAlignment;

		// Token: 0x020003FB RID: 1019
		public enum TextAlignment
		{
			// Token: 0x04006384 RID: 25476
			Manual,
			// Token: 0x04006385 RID: 25477
			Near,
			// Token: 0x04006386 RID: 25478
			Center,
			// Token: 0x04006387 RID: 25479
			Far
		}
	}
}
