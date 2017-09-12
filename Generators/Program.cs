using System;
using System.Collections;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		var a = callGen();
		Console.WriteLine(a.MoveNext()); // True
		Console.WriteLine(a.Current);    //1
		Console.WriteLine(a.Current);    //1
		a.MoveNext();
		a.MoveNext();
		Console.WriteLine(a.Current);    //3
		Console.WriteLine(a.Current);    //3
		Console.WriteLine(a.MoveNext()); //False
		Console.WriteLine(a.Current);    //3
		Console.WriteLine(a.Current);    //3
		
	}
	
	public static IEnumerator<int> callGen(){
		yield return 1; 
		yield return 2; 
		yield return 3; 
		
	}
}
