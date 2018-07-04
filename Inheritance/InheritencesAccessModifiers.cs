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


    /// 
    ///  The default access for everything in C# is "the most restricted access you could declare for that member".
    /// 
    public class A
    {
        //Overrinding Hidding Private Method - No point You cannot see it anywere
        private void MethodA() { WriteLine("class A"); }
        protected void MethodB() { WriteLine("class A Method B"); }
        protected void MethodC() { WriteLine("class A Method C"); }
        protected void MethodD() { WriteLine("class A Method D"); }
        //virtual void MethodE() { WriteLine("class A Method E"); }  // Virtual or abstract memmbers canont be private


        // incease visibility
        internal void MethodF() { WriteLine("class A Method F"); }
        void MethodE() { WriteLine("class A Method E"); }   // Private access
    }

    public class B : A
    {
        // it is two separate mehods in class A and B
        private void MethodA() { WriteLine("class B"); }
        private new void MethodB() { WriteLine("class B Method B"); }
        public new void MethodD() { WriteLine("class B Method D"); }

        // incease visibility
        public new void MethodF() { WriteLine("class B Method F"); }
        public void MethodE() { WriteLine("class B Method E"); }  //Different method becase in A MethodE is private



        public void CallExample()
        {
            A a = new A();
            //a.MethodB(); Cannot be valled on A type (It is protected)
            a = new B();
            //a.MethodA(); //Exception No access
            //a.MethodC(); //Exception No access
            //a.MethodD(); //Exception No access
            //a.MethodE(); //Exception No access
            a.MethodF();  
            B b = new B();
            b.MethodB();  // Class B, it can be invoked due to the fact that that we are in B 
            b.MethodC();  // Class B, it can be invoked due to the fact that that we are in B class
            b.MethodD();  // Class B, it can be invoked due to the fact that that we are in B class
        }
    }
}
