using System;

namespace PartialTypes
{
    using System;
    partial class PartialMethodDemo
    {
        //Similarly, the actual implementations just have the partial modifier but are otherwise like normal methods.
        partial void OnConstructorEnd()
        {
            Console.WriteLine("Manual code");
        }

        /*
         Because the method may not exist, partial methods must have a return type of void , and they can’t take out parameters.
         They have to be private, but they can be static and/or generic.

         If the method isn’t implemented in one of the files, the whole statement calling it is removed, including any argument evaluations .
         */
    }

}
