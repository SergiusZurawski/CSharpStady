using System;

namespace Types
{
    /// <summary>
    ///  An enum is a special kind of value type
    /// </summary>


    //Default start index is 0 ,every next is indexed by 1, 
    // you can change default behaviour to =1
    enum Days : byte { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri };

    //[Flags] by itself doesn't change this at all - all it does is enable a nice representation by the .ToString() method:
    [Flags] enum DaysFlag
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40
    }
    class Enumerations
    {
        static void Main()
        {
            
        }
    }
}
