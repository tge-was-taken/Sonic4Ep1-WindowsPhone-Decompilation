using System;
using Microsoft.Xna.Framework;

namespace GameFramework
{
	// Token: 0x020003F8 RID: 1016
	public abstract class GameObjectBase
	{
		// Token: 0x060028EB RID: 10475 RVA: 0x00156CAC File Offset: 0x00154EAC
		public GameObjectBase(Game game)
		{
			this.Game = game;
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060028EC RID: 10476 RVA: 0x00156CBB File Offset: 0x00154EBB
		// (set) Token: 0x060028ED RID: 10477 RVA: 0x00156CC3 File Offset: 0x00154EC3
		protected Game Game { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060028EE RID: 10478 RVA: 0x00156CCC File Offset: 0x00154ECC
		// (set) Token: 0x060028EF RID: 10479 RVA: 0x00156CD4 File Offset: 0x00154ED4
		public int UpdateCount { get; set; }

		// Token: 0x060028F0 RID: 10480 RVA: 0x00156CDD File Offset: 0x00154EDD
		public virtual void Update(GameTime gameTime)
		{
			this.UpdateCount++;
		}
	}
}
