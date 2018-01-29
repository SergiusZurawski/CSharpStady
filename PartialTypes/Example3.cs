using System;

namespace PartialTypes
{
    partial class Example<TFirst, TSecond> : IEquatable<string>   //Specifies interface and type constrains for Type
    {
        public bool Equals(string other)   //Implements IEquatable<>
        {
            return false; 
        }
    }

}
