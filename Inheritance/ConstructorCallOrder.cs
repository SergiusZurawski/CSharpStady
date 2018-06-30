using System;
using static System.Console;

namespace ConstructorCallOrder
{

    /// 1) most derived initializers first.
    /// 2) most base constructors first(or top-level in constructor-stack first.)
    /// this() references parametless constructor in the class
    /// base() call to parent  parametless constructor
    /// this(x) references constructor with argument 
    /// base() call to parent constructor with argument 


    public class ConstructorCallOrderDemoClass
    {
        public static void Example()
        {
            
            X x = new X();
            /*
             Z
             X
             */

            var d = new D();

        }
    }

    // SIMPLE EXAMPLE 1
    public class Z
    {
        public Z() { WriteLine("Z"); }
    }

    public class X : Z
    {
        public X() { WriteLine("X"); }
    }

    // SIMPLE EXAMPLE 2
    public class ZX
    {
        public ZX(string x) { WriteLine("ZX" + x); }
    }

    public class XX : ZX
    {
        //There is no default constructor, you have to call  contructor with parameter
        //public XX() { WriteLine("XX"); }  // Exception
        public XX() : base("default value") { WriteLine("XX" + "default value"); }
        public XX(string s) : base(s) { WriteLine("XX" + s); }
    }

    // Complicated Example
    public class A
    {
        public readonly C ac = new C("A");

        public A()
        {
            WriteLine("A");
        }
        public A(string x) : this()
        {
            WriteLine("A got " + x);
        }
    }

    public class B : A
    {
        public readonly C bc = new C("B");

        public B() : base()
        {
            WriteLine("B");
        }
        public B(string x) : base(x)
        {
            WriteLine("B got " + x);
        }
    }

    public class D : B
    {
        public readonly C dc = new C("D");

        public D() : this("ha")
        {
            WriteLine("D");
        }
        public D(string x) : base(x)
        {
            WriteLine("D got " + x);
        }
    }

    public class C
    {
        public C(string caller)
        {
            WriteLine(caller + "'s C.");
        }
    }
}
