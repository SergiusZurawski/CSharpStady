using System;
using System.Threading;
using System.Threading.Tasks;

namespace CombaningDelegates
{
    // Combaning Delegates is called multicasting.
    /*
    All this is possible because delegates inherit from the System.MulticastDelegate class that in turn inherits from System.Delegate. 
    Because of this, you can use the members that are defined in those base classes on your delegates. 
    */ 
    delegate void StringProcessor(string input);
    public class DelegateManipulation{
        static StringProcessor del1, del2;

        public static void Example(){
            del1 = new StringProcessor(DelegateManipulation.delegateCompatible1);
            del2 = new StringProcessor(DelegateManipulation.delegateCompatible2);

            //New Delegate is created each time
            del1 = (StringProcessor)Delegate.Combine(del1, del2); // Cast is required
            del1 += del2;       // Cast is not required
            del1 = del1 + del2; // Cast is not required
            /*
                displays 
                    MethodOne
                    MethodTwo
                    MethodTwo
                    MethodTwo
             */
            
            // To Find out how many methods is going to be called
            int invocationCount = del1.GetInvocationList().GetLength(0);

            del1 = (StringProcessor)Delegate.Remove(del1, del2); // Cast is required
            del1 -= del2;       // Cast is not required
            del1 = del1 - del2; // Cast is not required
        }
        public static void delegateCompatible1(string s)
        {
            Console.WriteLine("MethodOne");  
        }
        public static void delegateCompatible2(string s)
        {
            Console.WriteLine("MethodTwo"); 
        } 

    }

    
  
}
