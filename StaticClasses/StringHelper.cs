using System;

namespace StaticClasses
{

    /*
        Constrains:
            It can’t be declared as abstract or sealed , although it’s implicitly both.
            It can’t specify any implemented interfaces. 
            It can’t specify a base type. 
            It can’t include any nonstatic members, including constructors.
            It can’t include any operators. 
            It can’t include any protected or protected internal members.
         
    */
    public static class StringHelper  // static modifier on class level, omit constructor
    {
        /* Invalid for static classes
            StringHelper variable = null;
            StringHelper[] array = null; public void Method1(StringHelper x) { }
            public StringHelper Method1() { return null; }
            List<StringHelper> x = new List<StringHelper>();
        */

        public static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
