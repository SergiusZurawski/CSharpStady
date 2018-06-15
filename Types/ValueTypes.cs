using System;

namespace Types
{
    ///  In C#, you cannot directly inherit from System.ValueType. 
    /// Instead, you can use the struct keyword to create a new value type.

    /// Structs and classes can have methods, fields, properties, 
    /// constructors, and other functionalities. 
    /// You cannot, however, declare your own empty constructor for a struct. 
    /// Also, structs cannot be used in an inheritance hierarchy 
    public struct Point
    {
        public int x, y;

        public Point(int p1, int p2) { x = p1; y = p2; }
    }

    class ValueTypes
    {
        static void Example()
        {
            
        }
    }
}
