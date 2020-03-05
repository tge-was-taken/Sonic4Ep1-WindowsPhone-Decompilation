using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework
{
	// Token: 0x020003F9 RID: 1017
	public class SpriteObject : GameObjectBase
	{
		// Token: 0x060028F1 RID: 10481 RVA: 0x00156CED File Offset: 0x00154EED
		public SpriteObject(Game game) : base(game)
		{
			this.ScaleX = 1f;
			this.ScaleY = 1f;
			this.SpriteColor = Color.White;
		}

		// Token: 0x060028F2 RID: 10482 RVA: 0x00156D17 File Offset: 0x00154F17
		public SpriteObject(Game game, Vector2 position) : this(game)
		{
			this.Position = position;
		}

		// Token: 0x060028F3 RID: 10483 RVA: 0x00156D27 File Offset: 0x00154F27
		public SpriteObject(Game game, Vector2 position, Texture2D texture) : this(game, position)
		{
			this.SpriteTexture = texture;
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060028F4 RID: 10484 RVA: 0x00156D38 File Offset: 0x00154F38
		// (set) Token: 0x060028F5 RID: 10485 RVA: 0x00156D40 File Offset: 0x00154F40
		public virtual Texture2D SpriteTexture { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060028F6 RID: 10486 RVA: 0x00156D49 File Offset: 0x00154F49
		// (set) Token: 0x060028F7 RID: 10487 RVA: 0x00156D51 File Offset: 0x00154F51
		public virtual float PositionX { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060028F8 RID: 10488 RVA: 0x00156D5A File Offset: 0x00154F5A
		// (set) Token: 0x060028F9 RID: 10489 RVA: 0x00156D62 File Offset: 0x00154F62
		public virtual float PositionY { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060028FA RID: 10490 RVA: 0x00156D6B File Offset: 0x00154F6B
		// (set) Token: 0x060028FB RID: 10491 RVA: 0x00156D73 File Offset: 0x00154F73
		public virtual float OriginX { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060028FC RID: 10492 RVA: 0x00156D7C File Offset: 0x00154F7C
		// (set) Token: 0x060028FD RID: 10493 RVA: 0x00156D84 File Offset: 0x00154F84
		public virtual float OriginY { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060028FE RID: 10494 RVA: 0x00156D8D File Offset: 0x00154F8D
		// (set) Token: 0x060028FF RID: 10495 RVA: 0x00156D95 File Offset: 0x00154F95
		public virtual float Angle { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06002900 RID: 10496 RVA: 0x00156D9E File Offset: 0x00154F9E
		// (set) Token: 0x06002901 RID: 10497 RVA: 0x00156DA6 File Offset: 0x00154FA6
		public virtual float ScaleX { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06002902 RID: 10498 RVA: 0x00156DAF File Offset: 0x00154FAF
		// (set) Token: 0x06002903 RID: 10499 RVA: 0x00156DB7 File Offset: 0x00154FB7
		public virtual float ScaleY { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06002904 RID: 10500 RVA: 0x00156DC0 File Offset: 0x00154FC0
		// (set) Token: 0x06002905 RID: 10501 RVA: 0x00156DC8 File Offset: 0x00154FC8
		public virtual Rectangle SourceRect { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06002906 RID: 10502 RVA: 0x00156DD1 File Offset: 0x00154FD1
		// (set) Token: 0x06002907 RID: 10503 RVA: 0x00156DD9 File Offset: 0x00154FD9
		public virtual Color SpriteColor { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06002908 RID: 10504 RVA: 0x00156DE2 File Offset: 0x00154FE2
		// (set) Token: 0x06002909 RID: 10505 RVA: 0x00156DEA File Offset: 0x00154FEA
		public virtual float LayerDepth { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600290A RID: 10506 RVA: 0x00156DF3 File Offset: 0x00154FF3
		// (set) Token: 0x0600290B RID: 10507 RVA: 0x00156E06 File Offset: 0x00155006
		public Vector2 Position
		{
			get
			{
				return new Vector2(this.PositionX, this.PositionY);
			}
			set
			{
				this.PositionX = value.X;
				this.PositionY = value.Y;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600290C RID: 10508 RVA: 0x00156E22 File Offset: 0x00155022
		// (set) Token: 0x0600290D RID: 10509 RVA: 0x00156E35 File Offset: 0x00155035
		public Vector2 Origin
		{
			get
			{
				return new Vector2(this.OriginX, this.OriginY);
			}
			set
			{
				this.OriginX = value.X;
				this.OriginY = value.Y;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600290E RID: 10510 RVA: 0x00156E51 File Offset: 0x00155051
		// (set) Token: 0x0600290F RID: 10511 RVA: 0x00156E64 File Offset: 0x00155064
		public Vector2 Scale
		{
			get
			{
				return new Vector2(this.ScaleX, this.ScaleY);
			}
			set
			{
				this.ScaleX = value.X;
				this.ScaleY = value.Y;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06002910 RID: 10512 RVA: 0x00156E80 File Offset: 0x00155080
		public virtual Rectangle BoundingBox
		{
			get
			{
				Vector2 vector;
				if (this.SourceRect.IsEmpty)
				{
					vector = new Vector2((float)this.SpriteTexture.Width, (float)this.SpriteTexture.Height);
				}
				else
				{
					vector = new Vector2((float)this.SourceRect.Width, (float)this.SourceRect.Height);
				}
				Rectangle result = new Rectangle((int)this.PositionX, (int)this.PositionY, (int)(vector.X * this.ScaleX), (int)(vector.Y * this.ScaleY));
				result.Offset((int)(-this.OriginX * this.ScaleX), (int)(-this.OriginY * this.ScaleY));
				return result;
			}
		}

		// Token: 0x06002911 RID: 10513 RVA: 0x00156F38 File Offset: 0x00155138
		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			if (this.SpriteTexture != null)
			{
				if (this.SourceRect.IsEmpty)
				{
					spriteBatch.Draw(this.SpriteTexture, this.Position, default(Rectangle?), this.SpriteColor, this.Angle, this.Origin, this.Scale, SpriteEffects.None, this.LayerDepth);
					return;
				}
				spriteBatch.Draw(this.SpriteTexture, this.Position, new Rectangle?(this.SourceRect), this.SpriteColor, this.Angle, this.Origin, this.Scale, SpriteEffects.None, this.LayerDepth);
			}
		}
	}
}
