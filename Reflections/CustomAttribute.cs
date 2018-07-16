using System;
using System.Diagnostics;
using System.Reflection;

namespace Reflections
{



    public class CustomAttribute
    {
        static void Example()
        {
            //();
        }

    }

    /// When creating your own custom attribute from scratch, you also have to define the targets on which an attribute can be used
    [System.AttributeUsage(
                            System.AttributeTargets.Class |
                            System.AttributeTargets.Struct |
                            System.AttributeTargets.Method,
                            AllowMultiple = true
                            )]
    public class Author : System.Attribute
    {
        private string name;
        public double version;

        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }

    /// attributes require all properties to be read-write.
    /// 
    /// 

    [Author("P. Ackerman", version = 1.1)]
    class SampleClass
    {
        // P. Ackerman's code goes here...  
    }


}
