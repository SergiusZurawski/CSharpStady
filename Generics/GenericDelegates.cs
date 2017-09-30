using System;

using System.Collections.Generic;  

//delegate can define its own type parameters.
//Code that references the generic delegate can specify the type argument to create a closed constructed type
namespace Generics
{
    public class DelegateExamples
    {
        public delegate void Del<T>(T item);
        public static void Notify(int i) { }

        Del<int> m1 = new Del<int>(Notify);
        // method group conversion
        Del<int> m2 = Notify;
    }

    //Delegates defined within a generic class can use the generic class type parameters in the same way that class methods do
    class Stack2<T>
    {
        T[] items;
        int index;

        public delegate void StackDelegate(T[] items);
    }

    public class DelegateExamples2
    {
        //Code that references the delegate must specify the type argument of the containing class
        private static void DoWork(float[] items) { }

        public static void TestStack()
        {
            Stack2<float> s = new Stack2<float>();
            Stack2<float>.StackDelegate d = DoWork;
        }
    }


    //Generic delegates are especially useful in defining events based on the 
    // typical design pattern because the sender argument can be strongly typed and no longer has to be cast to and from Object.

    delegate void StackEventHandler<T, U>(T sender, U eventArgs);

    class Stack1<T>
    {
        public class StackEventArgs : System.EventArgs { }
        public event StackEventHandler<Stack1<T>, StackEventArgs> stackEvent;

        protected virtual void OnStackChanged(StackEventArgs a)
        {
            stackEvent(this, a);
        }
    }
    // Without delegates
    class SampleClass
    {
        public void HandleStackChange<T>(Stack1<T> stack, Stack1<T>.StackEventArgs args) { }
    }

    class GenericDelegatesUsage{
        public static void Example()
        {
            Stack1<double> s = new Stack1<double>();
            SampleClass o = new SampleClass();
            s.stackEvent += o.HandleStackChange;
        }
    }
    
}
