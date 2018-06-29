using System;

namespace Encapsulation
{

    /*
     Access modifier        Description
        public              None; restricted access
        internal            Limited to the current assembly
        protected           Limited to the containing class and derived classes
        protected internal  Limited to the current assembly or derived types
        private             Limited to the containing type
         
         */

    /*
         Internal is useful when you have a type, such as a helper class or an implementation detail,
         that shouldn't be accessible outside of the assembly you’re building.
             Only users who have access to the internal class can call the public method. 
     */

    /*
      protected internal access modifier, keep in mind that it is or, not and. In practice, this means that access is 
      limited to the current assembly or types derived from the class, even if those types are in another assembly. 
     */

    /*
     When you want to expose internal types or type members to another assembly, 
        you can use a special attribute: 
            InternalsVisibleToAttribute. (situation where this can be useful is when you write unit tests)

        [assembly:InternalsVisibleTo(“Friend1a”)] 
        [assembly:InternalsVisibleTo(“Friend1b”)]
     */


    /*
      Allowed access modifiers on nested types
        Members of   | Default member accessibility  | Allowed declared accessibility of the member
        enum           public                          None
        class          private                         public 
                                                       protected 
                                                       internal 
                                                       private 
                                                       protected 
                                                       internal
        interface      public                          None
        struct         private                         public 
                                                       internal 
                                                       private

         */

    /*
         access modifier of the enclosing type is always taken into account. 
         For example, 
         a public method inside an internal class has an accessibility of internal. 
         exceptions
          internal class implements a public interface
          a class overrides a public virtual member of a base class
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
