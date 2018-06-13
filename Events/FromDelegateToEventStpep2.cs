using System;

namespace Events
{

    public class PubWithEvent
    {
        /*
                Two adventeges over previous code
                1. Consumer cannot wipe out everithing.
                2. No need for null verification(delegate is initialized by default)
                3. only code within class can rise event
        */
        public event Action OnChange = delegate { };

        public void Raise()
        {
            OnChange();
        }
    }

   
    public class FromDelegateToEventStpep2
    {
         public void CreateAndRaise()
         {
            PubWithEvent p = new PubWithEvent();
            p.OnChange += () => Console.WriteLine("Eventraised to method Event 1");
            p.OnChange += () => Console.WriteLine("Eventraised to method Event 2");
            p.Raise();
         }

    }
}
