using System;
using static System.Console;

namespace Inheritance
{

    /// virtual and override keywords  - to change behaviour 
    /// new keyword - explicitly hides the member from a base class
    /// 


    public class ExampleInheritences
    {
        public static void Example()
        {
            A a = new A();
            a.Execute();
            a.ExecuteVirutal();
            a.ExecuteHide();
            a.ExecuteHideVirutal();
            a = new B();
            a.Execute();
            a.ExecuteVirutal();
            a.ExecuteHide();
            a.ExecuteHideVirutal();
            /*
                A.Execute
                A.Execute Virtual
                A.Execute Hide
                A.Execute HIDE Virtual
                A.Execute
                B.Execute Virtual
                A.Execute Hide
                A.Execute HIDE Virtual
             */
        }
    }


    
    public class A
    {
        // No New no Override - means implicit hidding  (Generates Warning)
        public void Execute(){WriteLine("A.Execute"); }
        // Virtual + Override = override
        public virtual void ExecuteVirutal(){WriteLine("A.Execute Virtual");}
        //  New  - Explicit Hide (No warning)
        public void ExecuteHide() { WriteLine("A.Execute Hide"); }
        // virtual for hidding
        public virtual void ExecuteHideVirutal() { WriteLine("A.Execute HIDE Virtual "); }
        

    }

    public class B : A
    {
        public void Execute(){WriteLine("B.Execute");}
        // No Virtual Override
        //public override void Execute() { } //// cannot override becase method is not vertual
        public override void ExecuteVirutal() {WriteLine("B.Execute Virtual"); }
        public new void ExecuteHide() { WriteLine("B.Execute Hide"); }
        public new void ExecuteHideVirutal() { WriteLine("B.Execute HIDE Virtual "); }
        
    }
}
