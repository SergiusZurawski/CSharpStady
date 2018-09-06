using System;
using System.Collections;
///  System.Collections - All collections Non Generic
///  System.Collections.Generic - All collections  Generic
///  System.Collections.Concurrent - All Concurent Collections
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Collections
{
    class CollectionGenericFramework
    {


        public static void ExampleCollactionTypes()
        {
            //interfaces

            IEnumerable<int> iEnumerable;   //:System.Collections.IEnumerable
            IEnumerator<int> iEnumerator;   //:System.Collections.iEnumerator
            ICollection<int> iCollection;   //:System.Collections.IEnumerable<>
            IComparer<int> iComparer;       // It provides a way to customize the sort order of a collection. (Used: List<T>.Sort
                                            //                                                                       List<T>.BinarySearch,
                                            //                                                                       SortedDictionary<TKey,TValue> ,
                                            //                                                                       SortedList<TKey,TValue>  )
            IEqualityComparer<int> iEqualityComparer;   //Defines methods to support the comparison of objects for equality.

            IDictionary<int, int> iDictionary;  //ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>, 
                                                //IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>
                                                // replaces hashtable with DictionaryEntry(KeyValuePair)  

            IList<int> iList;                   //Represents a collection of objects that can be individually accessed by index.
                                                //  Generic.ICollection<T>,
                                                //  Generic.IEnumerable<T>
            ISet<int> iSet;	
                                                //  Generic.ICollection<T>,
                                                //  Generic.IEnumerable<T>
            
            IReadOnlyCollection<int> iReadOnlyCollection; 	
            IReadOnlyDictionary<int,int> iReadOnlyDictionary;
            IReadOnlyList<int> iReadOnlyList;	
            

        }



    }
}
