using System;

namespace PartialTypes
{
    partial class Example<TFirst, TSecond> : EventArgs, IDisposable   //Specifies interface and BASE clase BUT not Constraints
    {
        public void Dispose()   //Implements IDisposable
        {
        }
    }

}
