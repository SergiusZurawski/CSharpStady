using System;
using System.Collections.Generic;
using System.Linq;

namespace Events
{

    /*
     ■■ Delegates are a type that defines a method signature and can contain a reference to a method. 
     ■■ Delegates can be instantiated, passed around, and invoked. 
     ■■ Lambda expressions, also known as anonymous methods, use the => operator and form a compact way of creating inline methods. 
     ■■ Events are a layer of syntactic sugar on top of delegates to easily implement the publish-subscribe pattern. 
     ■■ Events can be raised only from the declaring class. Users of events can only remove and add methods the invocation list. 
     ■■ You can customize events by adding a custom event accessor and by directly using the underlying delegate type.
    */
    public class PubWithExceptionHandling
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                } catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }

    public class FromDelegateToEventStpep5
    {
        public void CreateAndRaise()
        {
            PubWithExceptionHandling p = new PubWithExceptionHandling();

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e) => { throw new Exception(); };
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");

            try
            {
                p.Raise();
            } catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }

        // Displays 
        // Subscriber 1 called 
        // Subscriber 3 called 
        // 1
    }
}
