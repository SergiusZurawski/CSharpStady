using System;
using System.Collections.Generic;

namespace FlowControlStatments
{
    class JumpStatments
    {
        /*
             A jump statement unconditionally transfers control to another location in your code.  
             break 
             continue
             goto
             goto statement moves control to a statement that is marked by a label. 
                If the label can’t be found 
                or is not within the scope of the goto statement, 
                a compiler error occurs. 
         */

        public static void Example()
        {
            int x = 3;
            if (x == 3)
                goto customLabel;
            x++;

            customLabel: Console.WriteLine(x); // Displays 3

        }


    }

    
 
}
