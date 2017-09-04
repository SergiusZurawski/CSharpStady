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
    class SimpleDelegateUse
    {
        static void Example()
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
}
