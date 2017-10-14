using System;

using System.Collections.Generic;  
using System.Collections;

//  IEnumerable<T> extends the old IEnumerable interface,
//  you have to implement two 
//  IEnumerator<T> GetEnumerator();
//  IEnumerator GetEnumerator();
//

//foreach statement. 
// collection either implementing the
// System.Collections.IEnumerable interface or having a similar GetEnumerator()
//method that returned a type with a suitable MoveNext() method and a Current property.
//
namespace IterationsOverCustomMadeType
{
    class CountingEnumerable: IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()  //Implements IEnumerable<T> implicitly
        {
            return new CountingEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()  //Implements IEnumerable explicitly
        {
            return GetEnumerator();
        }
    }
    class CountingEnumerator : IEnumerator<int>
    {
        int current = -1;
        public bool MoveNext()
        {
            current++;
            return current < 10;
        }

        public int Current { get { return current; } }          //Implements IEnumerator<T>.Current implicitly
        object IEnumerator.Current { get { return Current; } }  //Implements IEnumerator.Current explicitly
        public void Reset()
        {
            current = -1;
        }
        public void Dispose() {}
    }

    public static class IterationsOverCustomMadeTypeExample
    {
        public static void Example()
        {
            CountingEnumerable counter = new CountingEnumerable();
            foreach (int x in counter)
            {
                Console.WriteLine(x);
            }
        }
    }

}
