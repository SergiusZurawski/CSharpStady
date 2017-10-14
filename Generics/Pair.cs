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
        return other != null && 
                FirstComparer.Equals(this.First, other.First) &&
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

//non-generic class with a generic method
public static class Pair2
{
    public static Pair<T1,T2> Of<T1,T2>(T1 first, T2 second)
    {
        return new Pair<T1,T2>(first, second);
    }
}

public class ExampleOfPair
{
    public static void Example()
    {
        Pair<int, string> p0 = new Pair<int, string>(1, "1");
        Pair<int, string> p1 = new Pair<int, string>(1, "1");    
        Pair<int, string> p2 = new Pair<int, string>(2, "2");    
        Console.WriteLine(p0.Equals(p1));
        Console.WriteLine(p0.Equals(p2));
        //Type inference Doens't work
        // Pair<int, string> p3 = new Pair(2, "2");  
        // Solution non generic class with generic method
        Pair<int,string> p3 = Pair2.Of(10, "value"); 


    }
}