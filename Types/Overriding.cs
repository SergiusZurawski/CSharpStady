using System;
using System.Collections.Generic;
using System.Linq;

namespace Types
{

    ///  When a method in a class is declared as virtual, 
    ///  you can override the method in a derived class.
    ///  

    ///  You can disable inheritance by using the sealed keyword on a class or a method. 
    ///  When used on a class, you can’t derive other classes from it.

    public class Overriding
    {

    }

    class Base
    {
        public virtual int MyMethod()
        {
            return 42;
        }
    }

    class Derived : Base
    {
        public sealed override int MyMethod()
        {
            return base.MyMethod() * 2;
        }
    }

    class Derived2 : Derived
    {
        // This line would give a compile error     
        // public override int MyMethod() { return 1;} 

    }
}