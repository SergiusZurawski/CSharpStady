using System;

namespace AnonymousObjectDeclaration
{
    class Program
    {
        static void Exaple()
        {
            var jon = new { Name = "Jon", Age = 31 };
		    var tom = new { Name = "Tom", Age = 4 };
		    var tommas = new {  Age = 4 , Name = "Tom"};
		    var gabe = new { Tame = "Tom", TAge = 4, Swage = "test" };
		    Console.WriteLine ("{0} is {1}", jon.Name, jon.Age);
		    Console.WriteLine ("{0} is {1}", tom.Name, tom.Age);
		    jon = tom;
		    //jon = tommas; not compatible 
            //jon = gabe;   not compatible
        }

        static void Main(){
            Exaple();
        }
    }
}
