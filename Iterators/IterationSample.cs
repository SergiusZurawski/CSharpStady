using System;
using System.Collections;

namespace Iterators
{
    // Iterator pattern , iteration without Yeald statment

    // you can only use iterator blocks to implement methods Or properties,
    //  that have a return type of IEnumerable , IEnumerator , 
    //  or one of the generic equivalents.

    // You can’t use an iterator block in an anonymous method, though.

    /*
     Restrictions on yield return:
     1. can’t use yield return inside a try block if it has any catch blocks,
     2.  can’t use yield return or yield break in a finally block.


     */
    public class IteratingOverDates : IEnumerable
    {
        private object[] values;
        private int startigPoint;

        public IteratingOverDates(object[] values, int startigPoint)
        {
            this.values = values;
            this.startigPoint = startigPoint;
        }

        public IEnumerator GetEnumerator()
        {
            return new IterationSampleIterator(this);
        }

        class IterationSampleIterator : IEnumerator
        {
            IteratingOverDates parent;
            int postion;

            internal IterationSampleIterator(IteratingOverDates parent)
            {
                this.parent = parent;
                this.postion = -1;
            }

            public bool MoveNext()
            {
                if (postion != parent.values.Length)
                {
                    postion++;
                }
                return postion < parent.values.Length;
            }

            public object Current
            {
                get
                {
                    if (postion == -1 || postion == parent.values.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    int index = postion + parent.startigPoint;
                    index = index % parent.values.Length;
                    return parent.values[index];
                }
            }

            public void Reset()
            {
                this.postion = -1;
            }



        }


    }

    
}