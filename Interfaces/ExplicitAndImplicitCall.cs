using System;

namespace Interfaces
{
    class ExplicitAndImplicitCall
    {
        public static void Example()
        {
            B b = new B();
            b.CallA();

            C c = new C();
            //c.CallA();  //Exception
            ((A)c).CallA();
            A a = c;
            a.CallA();
        }
    }

    interface A {  void CallA(); }

    class B : A
    {
        public void CallA()
        { Console.WriteLine("A is called"); }
    }

    class C : A
    {
        void A.CallA()
        { Console.WriteLine("A is called"); }
    }
}
