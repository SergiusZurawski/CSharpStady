using System;

namespace OverloadingRules
{
    class Program
    {
		//Chapter 9.4.4
		// No Converion is always preffered over converion
		static void Write(int x, double y) {Console.WriteLine(x);Console.WriteLine(y);} 
		static void Write(double x, int y) {Console.WriteLine(x);Console.WriteLine(y);} 
		
        static void Main(string[] args)
        {
            //Write(1, 1) Exception need to specify at least one
			Write(1, (double)1);
			
        }
		
		//Example 2 Lambda
		static void Execute(Func<int> action) 
		{ 
			Console.WriteLine("action returns an int: " + action()); 
		} 
		
		static void Execute(Func<double> action) 
		{ 
			Console.WriteLine("action returns a double: " + action()); 
		}
		
		///If an anonymous function can be converted to two delegate types that have the same parameter list but different return types, 
		///the delegate conversions are judged by the conversions from the inferred return type to the delegates’ return types.
		static void Example1()
        {
            Execute(() => 1);
        }
    }
}
