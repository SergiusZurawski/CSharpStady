using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImplicitTyping
{

    
    class ArrayInitalization
    {
        static void CallExample()
        {
            string[] names = { "Holly", "Jon", "Tom", "Robin", "William" };
            //works for array , but doesn’t work for parameters,
            //  void MyMethod(string[] names)
            // MyMethod({ "Holly", "Jon", "Tom", "Robin", "William" }) - Exception
            MyMethod(new string[] { "Holly", "Jon", "Tom", "Robin", "William" });
            //C#3
            MyMethod(new[] { "Holly", "Jon", "Tom", "Robin", "William" });
            // Type of the arrays is one type in that set that all the others can be implicitly converted to,
            // Otherwise (or if all the values are typeless expressions, such as constant null

            // types of the expressions are considered as candidates for the overall array type.
            // MyMethod(new[] { new MemoryStream(), new StringWriter() });  - Exception

            // If you explisitly specify it is work
            // new[] { (IDisposable)new MemoryStream(), new StringWriter() });

        }

        static void MyMethod(string[] names)
        {

        }

    }

   
}
