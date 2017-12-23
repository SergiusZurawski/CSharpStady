using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
   

    public class Variance
    {
        public static void Example()
        {
            ExampleVarianceDelegate.DelegateA delegateA = HandleDemoEvent;  // No variavnce
            ExampleVarianceDelegate.DelegateB delegateB = HandleDemoEvent;  // Contravariance
            ExampleVarianceDelegate.DelegateC delegateC = HandleDemoEvent;  // Contravariance
        }

        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine("LogKey");
        }
    }


}

namespace ExampleVarianceDelegate
{
    delegate void DelegateA(string input, EventArgs eventArgs);
    delegate void DelegateB(string input, KeyPressEventArgs eventArgs);
    delegate void DelegateC(string input, MausePressEventArgs eventArgs);

    public class DelegateConsulmer
    {
    }
    //Different Delegate Arguments
    //They are totatly different
    public class KeyPressEventArgs : EventArgs
    {
        public KeyPressEventArgs(char keyChar){}

        public char KeyChar { get; set; }
    }

    //They are totatly different
    public class MausePressEventArgs : EventArgs
    {
        public MausePressEventArgs(Object button, int clicks, int x, int y, int delta){}

        public Point Location { get; }
    }
}
