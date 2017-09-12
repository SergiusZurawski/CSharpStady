using System;
using System.Threading;
using System.Threading.Tasks;
/**
delegate instance will prevent its target from being garbage collected if the
delegate instance itself can’t be collected
This can result in memory leaks
short-lived object subscribes to an event in
a long-lived object, using itself as the target. The long-lived object indirectly
holds a reference to the short-lived one, prolonging its lifetime.

When a delegate instance is invoked, all its actions are executed in order.
If the delegate’s signature has a nonvoid return type, the value returned by Invoke is the
value returned by the last action executed.
- All the other actions are never seen unless the invoking code explicitly executes the
actions one at a time, using Delegate.GetInvocationList to fetch the list of actions.

If any of the actions in the invocation list throws an exception, that prevents any of
the subsequent actions from being executed.
[a, b, c] , b - throws Exception, c is not executed.
 */
namespace Delegates
{
    /*
     The delegate type needs to be declared.
     The code to be executed must be contained in a method.
     A delegate instance must be created.
     The delegate instance must be invoked.
    */
    //StringProcessor really is a type
    //StringProcessor inherits from System.MulticastDelegate < System.Delegate
    delegate void StringProcessor(string input);

    public class Delegates
    {
        delegate void StringProcessorClassLevel(string input); // on class level
        void PrintString(string x)               //suitable for delegate 
        {
            Console.WriteLine("PrintString");
            Console.WriteLine(x);
        }
        static void PrintStringStatic(string x)  //suitable for delegate Static
        {
            Console.WriteLine("PrintStringStatic");
            Console.WriteLine(x);
        }
        void PrintInteger(int x){}                 // not suitable for delegate 
        void PrintTwoStrings(string x, string y){}  // not suitable for delegate 
        int GetStringLength(string x){ return 0;}   // not suitable for delegate 
        void PrintObject(object x)                  // suitable for delegate
        {
            Console.WriteLine("PrintObject");
            Console.WriteLine(x);
        }

        public static void Example()
        {
            // Create Delegate
            StringProcessor proc1, proc2, proc3;
            Delegates instance = new Delegates();
            proc1 = new StringProcessor(instance.PrintString);       // Instance 
            proc3 = new StringProcessor(instance.PrintObject);
            
            proc2 = new StringProcessor(Delegates.PrintStringStatic);// Static

            Console.WriteLine("!!!---11---!!!");

            //Invoke delegate
            // simple
            proc1("Hello");
            //full form
            proc3.Invoke("Hello 2");


        }
    }

    // Example of Delegate and Instance variables
    class Person
    {
        string name;
        public Person(string name) { this.name = name; }
        public void Say(string message)
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }
    }
    class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }
    public class SimpleDelegateUse
    {
        public static void Example()
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");
            StringProcessor jonsVoice, tomsVoice, background;
            jonsVoice = new StringProcessor(jon.Say);
            tomsVoice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);
            jonsVoice("Hello, son.");
            tomsVoice.Invoke("Hello, Daddy!");
            background("An airplane flies past.");
        }
    }

    public class DelegateCreation{
        
        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine ("Handled by HandleDemoEvent");
        }
        //https://msdn.microsoft.com/en-us/library/system.eventhandler(v=vs.110).aspx
        EventHandler handler;
        handler = new EventHandler(HandleDemoEvent);   //Specifies delegate type and method
        handler(null, EventArgs.Empty);
        handler = HandleDemoEvent;
        handler(null, EventArgs.Empty);                //Implicitly converts to delegate instance
        
        handler = delegate(object sender, EventArgs e) //Specifies action with anonymous method
        {
            Console.WriteLine ("Handled anonymously");
        };

        handler(null, EventArgs.Empty);
        handler = delegate                              //Uses anonymous method shortcut
        {;
            Console.WriteLine ("Handled anonymously again");
        };
        handler(null, EventArgs.Empty);

        MouseEventHandler mouseHandler = HandleDemoEvent;  //Uses delegate contravariance
        mouseHandler(null, new MouseEventArgs(MouseButtons.None,0, 0, 0, 0));
    }
}

//Summary
/* 
    Delegates encapsulate behavior with a particular return type and set of parame-
        ters, similar to a single-method interface.
     The type signature described by a delegate type declaration determines
        which methods can be used to create delegate instances, and the signature
        for invocation.
     Creating a delegate instance requires a method and (for instance methods) a
        target to call the method on.
     Delegate instances are immutable.
     Delegate instances each contain an invocation list—a list of actions.
     Delegate instances can be combined with and removed from each other.
     Events aren’t delegate instances—they’re just add/remove method pairs (think
property getters/setters).
*/
