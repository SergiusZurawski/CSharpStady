using System;

namespace FlowControlStatments
{
    class Boolean
    {

        /*
            Operator Description              Example
                <    Less than                x < 42;
                >    Greater than             x > 42;
                <=   Less than or equal to    x <= 42;
                >=   Greater than or equal to x >= 42;
                ==   Equal to                 x == 42;
                !=   Not equal to             x != 42; 
        */

        /*
            Logical operators
             OR(||)   -- short circuit
             AND(&&)  -- short circuit
             XOR(^)   -- NOT short circuit
        */
        static void Example()
        {
            bool x = true;
            bool y = false;
            bool result = x || y;
            Console.WriteLine(result); // Displays True
            result = x || GetY();      // GetY is not going to be called, short circuit 

            //XOR example 
            bool a = true;
            bool b = false;
            Console.WriteLine(a ^ a); // False
            Console.WriteLine(a ^ b); // True
            Console.WriteLine(b ^ b); // False
        }

        private static bool GetY()
        {
            Console.WriteLine("Thismethoddoesn’tgetcalled");
            return true;
        }

        public void Process(string input)
        {
            // short circuit with AND, second part is not going to be called when fist part is null
            // !! don't switch position
            bool result = (input != null) && (input.StartsWith("v"));
            // Do something with the result
        }
    }
}
