using System;

// Token: 0x02000424 RID: 1060
public struct DoubleType<I, E>
{
	// Token: 0x06002A97 RID: 10903 RVA: 0x0015AC90 File Offset: 0x00158E90
	public static implicit operator DoubleType<I, E>(I i)
	{
		return new DoubleType<I, E>
		{
			Value = i
		};
	}

	// Token: 0x06002A98 RID: 10904 RVA: 0x0015ACB4 File Offset: 0x00158EB4
	public static implicit operator DoubleType<I, E>(E e)
	{
		return new DoubleType<I, E>
		{
			Value = e
		};
	}

	// Token: 0x06002A99 RID: 10905 RVA: 0x0015ACD8 File Offset: 0x00158ED8
	public static implicit operator I(DoubleType<I, E> doubleType)
	{
		if (doubleType.Value is I)
		{
			return (I)((object)doubleType.Value);
		}
		return default(I);
	}

	// Token: 0x06002A9A RID: 10906 RVA: 0x0015AD0C File Offset: 0x00158F0C
	public static explicit operator E(DoubleType<I, E> doubleType)
	{
		if (doubleType.Value is I)
		{
			return default(E);
		}
		return (E)((object)doubleType.Value);
	}

	// Token: 0x06002A9B RID: 10907 RVA: 0x0015AD3D File Offset: 0x00158F3D
	public static bool operator ==(DoubleType<I, E> doubleType1, DoubleType<I, E> doubleType2)
	{
		return doubleType1.Equals(doubleType2);
	}

	// Token: 0x06002A9C RID: 10908 RVA: 0x0015AD52 File Offset: 0x00158F52
	public static bool operator !=(DoubleType<I, E> doubleType1, DoubleType<I, E> doubleType2)
	{
		return !doubleType1.Equals(doubleType2);
	}

	// Token: 0x06002A9D RID: 10909 RVA: 0x0015AD6A File Offset: 0x00158F6A
	public override int GetHashCode()
	{
		if (this.Value != null)
		{
			return this.Value.GetHashCode();
		}
		return 0;
	}

	// Token: 0x06002A9E RID: 10910 RVA: 0x0015AD81 File Offset: 0x00158F81
	public override bool Equals(object obj)
	{
		return obj is DoubleType<I, E> && this.Value.Equals(((DoubleType<I, E>)obj).Value);
	}

	// Token: 0x04006468 RID: 25704
	private object Value;
}
