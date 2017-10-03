using System;
using System.Collections.Generic;
public sealed class Pair<T1, T2> : IEquatable<Pair<T1, T2>>
{
    private static readonly IEqualityComparer<T1> FirstComparer = EqualityComparer<T1>.Default;
    private static readonly IEqualityComparer<T2> SecondComparer = EqualityComparer<T2>.Default;
    
    private readonly T1 first;
    private readonly T2 second;
    public Pair(T1 first, T2 second)
    {
        this.first = first;
        this.second = second;
    }
    public T1 First { get { return first; } }
    public T2 Second { get { return second; } }

    public bool Equals(Pair<T1, T2> other)
    {
        return other != null && FirstComparer.Equals(this.First, other.First) &&
                                SecondComparer.Equals(this.Second, other.Second);
    }

    public override bool Equals(object o)
    {
        return Equals(o as Pair<T1, T2>);
    }

    public override int GetHashCode()
    {
        return FirstComparer.GetHashCode(first) * 37 + SecondComparer.GetHashCode(second);
    }
}