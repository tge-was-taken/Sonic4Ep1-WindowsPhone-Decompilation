using System;

// Token: 0x02000426 RID: 1062
public struct QuadType<I, E1, E2, E3>
{
	// Token: 0x06002AA5 RID: 10917 RVA: 0x0015AEAC File Offset: 0x001590AC
	public static implicit operator QuadType<I, E1, E2, E3>(I i)
	{
		return new QuadType<I, E1, E2, E3>
		{
			Value = i
		};
	}

	// Token: 0x06002AA6 RID: 10918 RVA: 0x0015AED0 File Offset: 0x001590D0
	public static implicit operator QuadType<I, E1, E2, E3>(E1 e1)
	{
		return new QuadType<I, E1, E2, E3>
		{
			Value = e1
		};
	}

	// Token: 0x06002AA7 RID: 10919 RVA: 0x0015AEF4 File Offset: 0x001590F4
	public static implicit operator QuadType<I, E1, E2, E3>(E2 e2)
	{
		return new QuadType<I, E1, E2, E3>
		{
			Value = e2
		};
	}

	// Token: 0x06002AA8 RID: 10920 RVA: 0x0015AF18 File Offset: 0x00159118
	public static implicit operator QuadType<I, E1, E2, E3>(E3 e3)
	{
		return new QuadType<I, E1, E2, E3>
		{
			Value = e3
		};
	}

	// Token: 0x06002AA9 RID: 10921 RVA: 0x0015AF3C File Offset: 0x0015913C
	public static implicit operator I(QuadType<I, E1, E2, E3> quadType)
	{
		if (quadType.Value is I)
		{
			return (I)((object)quadType.Value);
		}
		return default(I);
	}

	// Token: 0x06002AAA RID: 10922 RVA: 0x0015AF70 File Offset: 0x00159170
	public static explicit operator E1(QuadType<I, E1, E2, E3> quadType)
	{
		if (quadType.Value is E1)
		{
			return (E1)((object)quadType.Value);
		}
		return default(E1);
	}

	// Token: 0x06002AAB RID: 10923 RVA: 0x0015AFA4 File Offset: 0x001591A4
	public static explicit operator E2(QuadType<I, E1, E2, E3> quadType)
	{
		if (quadType.Value is E2)
		{
			return (E2)((object)quadType.Value);
		}
		return default(E2);
	}

	// Token: 0x06002AAC RID: 10924 RVA: 0x0015AFD8 File Offset: 0x001591D8
	public static explicit operator E3(QuadType<I, E1, E2, E3> quadType)
	{
		if (quadType.Value is E3)
		{
			return (E3)((object)quadType.Value);
		}
		return default(E3);
	}

	// Token: 0x0400646A RID: 25706
	private object Value;
}
