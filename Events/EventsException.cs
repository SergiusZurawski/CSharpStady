using System;

namespace Events
{
    public class PubWithExeption {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, EventArgs.Empty);
        }
    }


    public class ExpepsionHandlingInEvents
    {
        public void CreateAndRaise()
        {
            PubWithExeption p = new PubWithExeption();

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber1called");

            p.OnChange += (sender, e) => { throw new Exception(); };

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber3called");
            p.Raise();

            // Displays 
            // Subscriber 1 called

        }
    }

}
