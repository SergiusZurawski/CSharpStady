using System;

namespace TypeInverece
{
    class Program
    {
		/// Anonymous functions (anonymous methods and lambda expressions) have inferred return types based on the types of all the return statements.
		/// Lambda expressions can only be understood by the compiler when the types of all the parameters are known.
		/// Type inference no longer requires that each argument independently come to exactly the same conclusion about type parameters, as long as the results stay compatible.
		/// Type inference is now multistage: the inferred return type of one anonymous function can be used as a parameter type for another.
		/// Finding the best overloaded method when anonymous functions are involved takes the inferred return type into account.
		
        static void Main(string[] args)
        {
            Console.WriteLine("Compiles");
        }
		
		// Example 1 
		static void PrintConvertedValue<TInput,TOutput> (TInput input, Converter<TInput,TOutput> converter) 
		{ 
			Console.WriteLine(converter(input)); 
		}
		
		static void Example1()
		{
			PrintConvertedValue("I'm a string", x => x.Length);	
		}
		
		// Example 2
		delegate T MyFunc<T>();
		
		static void WriteResult<T>(MyFunc<T> function)
		{
			Console.WriteLine(function());
		}
		
		static void Example2()
		{
			//No compile in C# 2
			WriteResult(delegate {return 5;});
			//Suitable for C#2
			WriteResult<int>(delegate { return 5; }); 
			WriteResult((MyFunc<int>)delegate { return 5; });
			
			// Dificult example of type inference code returns 
			// Does't work with net core 
			// Net 4.7 (Not confirmed )The compiler uses the same logic to determine the return type in this situation as it does for implicitly typed arrays, 
			//as described in section 8.4 . It forms a set of all the types from the return statements in the body of the anonymous function [ 8 ] 
			// (in this case, int and object ) and checks to see if exactly one of the types can be implicitly converted to from all the others.
			
			/// Returned expressions that don’t have a type, such as null or another lambda expression, aren’t included in this set. 
			/// Their validity is checked later, once a return type has been determined, but they don’t contribute to that decision.
			
			
			WriteResult(delegate 
			{ 
				if(DateTime.Now.Hour < 12)
				{
					return new object(); 
				}
				else
				{
					return 5; 
				}
			});
			
		}
		/// Fixed Types - compiler decited type, otherwise undfixed.
		/// Bounded types 
		
		
		/// C#3 
		/// - the method arguments work as a team
		/// - 
		
		// Example 3
		public static void Example3()
		{
			PrintType(1, new object());
		}
		
		static void PrintType<T>(T first, T second) 
		{ 
			Console.WriteLine(typeof(T)); 
		} 
		
		
		//EXAMPLE4
		static void ConvertTwice<TInput,TMiddle,TOutput> (TInput input, Converter<TInput,TMiddle> firstConversion, Converter<TMiddle,TOutput> secondConversion) 
		{ 
			TMiddle middle = firstConversion(input); 
			TOutput output = secondConversion(middle); 
			Console.WriteLine(output); 
		}
		
		public static void Example3()
		{
			ConvertTwice("Another string", text => text.Length, length => Math.Sqrt(length));
		}
		
		///The body of a lambda expression cannot be checked until the input parameter types are known.
		
		
    }	
	
}
