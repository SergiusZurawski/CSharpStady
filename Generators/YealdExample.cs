using System;
using System.Collections;
using System.Collections.Generic;
					
public class YealdExample
{
	public static void Example()
	{
        /// Yield is a special keyword that can be used only in the context of iterators. 
        /// It instructs the compiler to convert this regular code to a state machine. 
        /// The generated code keeps track of where you are in the collection and it implements methods such as MoveNext and Current. 
        

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
