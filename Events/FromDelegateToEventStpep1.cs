using System;

namespace Events
{

    public class Pub
    {

        /*
            Two weekneses:
            1. OnChange is public so everyone can:
                1.1 Erase all subscriptions by OnChange = null
                1.2 p.OnChange() every user of the class can raise the event to all subscribers. 
            2. You need a null verification.

        */
        public Action OnChange { get; set; }

        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }

   
    public class FromDelegateToEventStpep1
    {
         public void CreateAndRaise()
         {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Eventraised to method 1");
            p.OnChange += () => Console.WriteLine("Eventraised to method 2");
            p.Raise();
         }

    }
}
