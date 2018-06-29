using System;
using System.Dynamic;

namespace DynamicTypes
{
    class DynamicObjects
    {
        ///  When inheriting from DynamicObject, 
        ///  you can override members that enable you to override operations such as
        ///     getting a member,
        ///     setting a member, 
        ///     calling a method, 
        ///     performing conversions. 
        ///  By using DynamicObject, you 
        ///  can create truly dynamic objects and have full control over how they operate at runtime. 
        /// 

        static void Example()
        {
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeProperty); // Displays ‘SomeProperty’

        }
    }

    public class SampleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }

}
