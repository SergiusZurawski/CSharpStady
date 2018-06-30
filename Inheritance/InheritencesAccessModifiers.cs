using System;
using static System.Console;

namespace InheritencesAccessModifiers
{

   

    public class InheritencesAccessModifiers
    {
        public static void Example()
        {

        }
    }


    
    public class A
    {
        //Overrinding Hidding Private Method - No point You cannot see it anywere
        private void MethodA() { WriteLine("class A"); }
        protected void MethodB() { WriteLine("class A Method B"); }
        protected void MethodC() { WriteLine("class A Method C"); }
    }

    public class B : A
    {
        // it is two separate mehods in class A and B
        private void MethodA() { WriteLine("class B"); }
        private void MethodB() { WriteLine("class B Method B"); }


        public void CallExample()
        {
            A a = new A();
            //a.MethodB(); Cannot be valled on A type (It is protected)
            a = new B();
            //a.MethodA(); //Exception No access
            B b = new B();
            b.MethodB();  // Class B, it can be invoked due to the fact that that we are in B class
        }
    }
}
