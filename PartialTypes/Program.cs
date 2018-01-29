using System;

namespace PartialTypes
{
    /*
       Types built from multiple source files are called partial types.
         partial methods are only relevant in partial types

        You can’t write half of a member in one file and half of it in another—each individual member has to be completely contained within its own file. 
        You can’t start a method in one file and finish it in another,

        restrictions:
            - declarations have to be compatible.
            - Any file can specify interfaces to be implemented (and they don’t have to be implemented in that file),
            - any file can specify the base type, and any file can specify constraints on a type parameter. But if multiple files specify a base type, those base types have to be the same,
            - if multiple files specify type constraints, the constraints have to be identical.


        initialization of member and static variables is guaranteed to occur in the order they appear in the file, 
            but there’s no guaranteed order when multiple files are involved.

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
