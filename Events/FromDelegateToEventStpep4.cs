using System;

namespace Events
{
    public class MyArgsMultithreaded : EventArgs
    {
        public MyArgsMultithreaded(int value) { Value = value; }

        public int Value { get; set; }
    }

    public class PubEventMulthreading
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }

   
    public class FromDelegateToEventStpep4
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
