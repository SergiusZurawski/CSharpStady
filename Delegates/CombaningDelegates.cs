using System;
using System.Threading;
using System.Threading.Tasks;

namespace CombaningDelegates
{
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

            del1 = (StringProcessor)Delegate.Remove(del1, del2); // Cast is required
            del1 -= del2;       // Cast is not required
            del1 = del1 - del2; // Cast is not required
        }
        public static void delegateCompatible1(string s){}
        public static void delegateCompatible2(string s){}

    }

    
  
}
