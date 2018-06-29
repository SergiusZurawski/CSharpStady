using System;

namespace Events
{
    /**
    event allows code to react when something happens 
     An event can be used to provide notifications. 
     You can subscribe to an event if you are interested in those notifications.
     You can also create your own events and raise them to provide notifications when something interesting happens.

     !Events are not delegates; instead they are a convenient wrapper around delegates. 

     !Delegates are executed in a sequential order. 
        Generally, delegates are executed in the order in which they were added, 
        although this is not something that is specified within the Common Language Infrastructure (CLI), 
        so you shouldn’t depend on it. 
    */

    /*
        ■■ Delegates are a type that defines a method signature and can contain a reference to a method. 
        ■■ Delegates can be instantiated, passed around, and invoked. 
        ■■ Lambda expressions, also known as anonymous methods, use the => operator and form a compact way of creating inline methods. 
        ■■ Events are a layer of syntactic sugar on top of delegates to easily implement the publish-subscribe pattern. 
        ■■ Events can be raised only from the declaring class. Users of events can only remove and add methods the invocation list. 
        ■■ You can customize events by adding a custom event accessor and by directly using the underlying delegate type.
    */
    class Program
    {
        static void Main(string[] args)
        {
            FromDelegateToEventStpep5 a = new FromDelegateToEventStpep5();
            a.CreateAndRaise();
        }
    }
}
