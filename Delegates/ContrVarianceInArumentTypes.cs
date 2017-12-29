using ExampleVarianceDelegate;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
   

    public class ContrVarianceInArumentTypes
    {
        public static event DelegateA riseA;
        public static event DelegateB riseB;
        public static event DelegateC riseC;

        //Contrvariance in Arugments
        public static void Example()
        {
            DelegateA delegateA = HandleDemoEvent;  // No variavnce
            DelegateB delegateB = HandleDemoEvent;  // Contravariance
            DelegateC delegateC = HandleDemoEvent;  // Contravariance

            //ExampleVarianceDelegate.DelegateB delegateB1 = HandleDemoEventC;  // Exception
            //ExampleVarianceDelegate.DelegateC delegateC1 = HandleDemoEventB;  // Exception

            //ExampleVarianceDelegate.DelegateC delegateA1 = HandleDemoEventB;  // Covariance doesn't work Exception

            delegateA("", new EventArgs());
            //delegateB("", new EventArgs());  //Exception, you can't call it with EventArgs
            //delegateC("", new EventArgs());  //Exception, you can't call it with EventArgs
            delegateB("", new KeyPressEventArgs('b'));
            delegateC("", new MausePressEventArgs(new Object(),1, 1, 1, 1));

            // EVENTS The same rule
            riseA += HandleDemoEvent;         
            riseB += HandleDemoEvent;   //Contravariance
            riseC += HandleDemoEvent;   //Contravariance
            //riceC += HandleDemoEventB;  //Exceptoion
            //riceB += HandleDemoEvent; // Covariance Exception

            riseA.Invoke("", new EventArgs());
            riseB.Invoke("", new KeyPressEventArgs('b'));
            riseC.Invoke("", new MausePressEventArgs(new Object(), 1, 1, 1, 1));
        }

        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine("HandleDemoEvent");
        }

        static void HandleDemoEventB(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("HandleDemoEventB");
        }

        static void HandleDemoEventC(object sender, MausePressEventArgs e)
        {
            Console.WriteLine("HandleDemoEventC");
        }
    }


}

namespace ExampleVarianceDelegate
{
    public delegate void DelegateA(string input, EventArgs eventArgs);
    public delegate void DelegateB(string input, KeyPressEventArgs eventArgs);
    public delegate void DelegateC(string input, MausePressEventArgs eventArgs);

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
