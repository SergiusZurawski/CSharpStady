using System;
using System.Collections;

namespace Iterators
{
    // Iterator pattern , with Yeald statment
    public class IterationSampleWithYeald : IEnumerable
    {
        private object[] values;
        private int startingPoint;

        public IterationSampleWithYeald(object[] values, int startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < values.Length; index++)
            {
                yield return values[(index + this.startingPoint) % values.Length];
            }
        }

        


    }

    
}