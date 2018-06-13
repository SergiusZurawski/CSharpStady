using System;

namespace Events
{
    public class MyArgs : EventArgs
    {
        public MyArgs(int value) { Value = value; }

        public int Value { get; set; }
    }

    public class PubWithEventFinal
    {
        //Public property, but you can add a logic so an event is added smartly
        public event EventHandler<MyArgs> OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }

   
    public class FromDelegateToEventStpep3
    {
         public void CreateAndRaise()
         {
            PubWithEventFinal p = new PubWithEventFinal();
            p.OnChange += (sender, args) => Console.WriteLine("Eventraised to method Event {0}", args.Value);
            p.OnChange += (sender, args) => Console.WriteLine("Eventraised to method Event 2 {0}", args.Value);
            p.Raise();
         }

    }
}
