using System;

// Token: 0x02000425 RID: 1061
public struct TripleType<I, E1, E2>
{
	// Token: 0x06002A9F RID: 10911 RVA: 0x0015ADA4 File Offset: 0x00158FA4
	public static implicit operator TripleType<I, E1, E2>(I i)
	{
		return new TripleType<I, E1, E2>
		{
			Value = i
		};
	}

	// Token: 0x06002AA0 RID: 10912 RVA: 0x0015ADC8 File Offset: 0x00158FC8
	public static implicit operator TripleType<I, E1, E2>(E1 e1)
	{
		return new TripleType<I, E1, E2>
		{
			Value = e1
		};
	}

	// Token: 0x06002AA1 RID: 10913 RVA: 0x0015ADEC File Offset: 0x00158FEC
	public static implicit operator TripleType<I, E1, E2>(E2 e2)
	{
		return new TripleType<I, E1, E2>
		{
			Value = e2
		};
	}

	// Token: 0x06002AA2 RID: 10914 RVA: 0x0015AE10 File Offset: 0x00159010
	public static implicit operator I(TripleType<I, E1, E2> tripleType)
	{
		if (tripleType.Value is I)
		{
			return (I)((object)tripleType.Value);
		}
		return default(I);
	}

	// Token: 0x06002AA3 RID: 10915 RVA: 0x0015AE44 File Offset: 0x00159044
	public static explicit operator E1(TripleType<I, E1, E2> tripleType)
	{
		if (tripleType.Value is E1)
		{
			return (E1)((object)tripleType.Value);
		}
		return default(E1);
	}

	// Token: 0x06002AA4 RID: 10916 RVA: 0x0015AE78 File Offset: 0x00159078
	public static explicit operator E2(TripleType<I, E1, E2> tripleType)
	{
		if (tripleType.Value is E2)
		{
			return (E2)((object)tripleType.Value);
		}
		return default(E2);
	}

	// Token: 0x04006469 RID: 25705
	private object Value;
}
