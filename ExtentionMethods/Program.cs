﻿using System;
using System.IO;
using System.Net;
//Chapter 10. Extension methods
/*
	Writing extension methods 
	Calling extension methods 
	Method chaining 
	Extension methods in .NET 3.5 
	Other uses for extension methods
*/

/*
	Candidate for Extention methods
		You want to add some members to a type. 
		You don’t need to add any more data to the instances of the type. 
		You can’t change the type itself, because it’s in someone else’s code.
		you want to work with an interface instead of a class, adding useful behavior while only calling methods on the interface.
	
	Requirements: 
		It must be in a non-nested, nongeneric static class (and therefore must be a static method).
		It must have at least one parameter.
		The first parameter must be prefixed with the this keyword.
		The first parameter can’t have any other modifiers (such as out or ref ).
		The type of the first parameter must not be a pointer type.

*/
namespace ExtentionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
			CallExample1();
        }

		static void CallExample1()
        {
			// Example without Extention method , doesn't look object oriented
            WebRequest request = WebRequest.Create("http://manning.com");
			using (WebResponse response = request.GetResponse()) 
			using (Stream responseStream = response.GetResponseStream()) 
			using (FileStream output = File.Create("response .dat")) 
			{ 
				StreamUtil.Copy(responseStream, output);
			}
        }

		static void CallExample2WithExtentionMethod()
        {
			// Example without Extention method , doesn't look object oriented
            WebRequest request = WebRequest.Create("http://manning.com");
			using (WebResponse response = request.GetResponse()) 
			using (Stream responseStream = response.GetResponseStream()) 
			using (FileStream output = File.Create("response .dat")) 
			{ 
				responseStream.CopyTo(output);
			}
        }
    }
}