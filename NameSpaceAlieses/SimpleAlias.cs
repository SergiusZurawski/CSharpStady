using System;
//Namespace Alies
using ProgramA = NameSpaceA;
using ProgramB = NameSpaceB;

namespace NameSpaceAlieses
{
    class Alieases
    {
        public static void Call()
        {
            //Using alias
            Console.WriteLine(typeof(ProgramA.Program));
            Console.WriteLine(typeof(ProgramB.Program));

            //:: namespace alias qualifier
            Console.WriteLine(typeof(ProgramA::Program));
            Console.WriteLine(typeof(ProgramB::Program));
        }

        public static void CallGlobal()
        {
            Console.WriteLine(typeof(Configuration));
            Console.WriteLine(typeof(global::System.Action));
            Console.WriteLine(typeof(global::NameSpaceAlieses.Configuration));
        }
    }
    class Configuration { }
}

namespace NameSpaceA
{
    class Program
    {
        static void Amethod()
        {
        }
    }
}

namespace NameSpaceB
{
    class Program
    {
        static void Amethod()
        {
        }
    }
}


/*  External Alias
 // Compile with
 //csc Test.cs /r:FirstAlias.dll /r:SecondAlias=Second.dll

 extern alias FirstAlias;
 extern alias SecondAlias;

using System;
using FD = FirstAlias::Demo;

class Test
{
    static void Main()
    {
        Console.WriteLine(typeof(FD.Example);
        Console.WriteLine(typeof(SecondAlias::Demo.Example);
    }

}
     */
