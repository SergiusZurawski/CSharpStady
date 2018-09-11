using System;
using System.Collections;
///  System.Collections - All collections Non Generic
///  System.Collections.Generic - All collections  Generic
///  System.Collections.Concurrent - All Concurent Collections
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;

namespace Collections
{
    public class CollectionGenericFramework
    {


        public static void ExampleCollactionTypes()
        {
            //interfaces

            IEnumerable<int> iEnumerable; //:System.Collections.IEnumerable
            IEnumerator<int> iEnumerator; //:System.Collections.iEnumerator
            ICollection<int> iCollection; //:System.Collections.IEnumerable<>
            IComparer<int>
                iComparer; // It provides a way to customize the sort order of a collection. (Used: List<T>.Sort
            //                                                                       List<T>.BinarySearch,
            //                                                                       SortedDictionary<TKey,TValue> ,
            //                                                                       SortedList<TKey,TValue>  )
            IEqualityComparer<int>
                iEqualityComparer; //Defines methods to support the comparison of objects for equality.

            IDictionary<int, int> iDictionary; //ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>, 
            //IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>
            // replaces hashtable with DictionaryEntry(KeyValuePair)  

            IList<int> iList; //Represents a collection of objects that can be individually accessed by index.
            //  Generic.ICollection<T>,
            //  Generic.IEnumerable<T>
            ISet<int> iSet;
            //  Generic.ICollection<T>,
            //  Generic.IEnumerable<T>

            IReadOnlyCollection<int> iReadOnlyCollection; // System.Collections.Generic.IEnumerable<out T>
            IReadOnlyDictionary<int, int>
                iReadOnlyDictionary; // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
            // System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>
            IReadOnlyList<int> iReadOnlyList; //System.Collections.Generic.IEnumerable<out T>,
            //System.Collections.Generic.IReadOnlyCollection<out T>

            //Classes 
            Comparer<int> comparer = new CollectionGenericFramework.IntComparer();
            iComparer = comparer;
            IComparer iComparerNonGeneric = comparer;
            Dictionary<int, int>.KeyCollection dicKeyCollection =
                new Dictionary<int, int>.KeyCollection(new Dictionary<int, int>() {{4, 5}});

            iCollection = dicKeyCollection;
            iEnumerable = dicKeyCollection;
            iCollection = dicKeyCollection;
            iReadOnlyCollection = dicKeyCollection;

            Dictionary<int, int>.ValueCollection valueCollection =
                new Dictionary<int, int>.ValueCollection(new Dictionary<int, int>() {{4, 5}});
            
            iCollection = valueCollection;
            iEnumerable = valueCollection;
            iCollection = valueCollection;
            iReadOnlyCollection = valueCollection;
            
            Dictionary<int, int> dictionary01 = new Dictionary<int, int>() {{4, 5}};

            iDictionary = dictionary01;
            IEnumerable<KeyValuePair<int, int>> enumarableForDict = dictionary01;
            ICollection<KeyValuePair<int, int>> collectionKeyValuePairs= dictionary01;
            ICollection iCollectionNonGen = dictionary01;
            iReadOnlyDictionary = dictionary01;
            IReadOnlyCollection<KeyValuePair<int, int>> iReadOnlyCollectionDict = dictionary01;
            ISerializable iSerializable = dictionary01;
            IDeserializationCallback iSerializableCallback = dictionary01;
            
        }
        
        
        public class IntComparer : Comparer<int>
        {
            public override int Compare(int x, int y)
            {
                return x > y ? 0 : 1;
            }
        }
        
        public class IntEqualityComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y ? true : false;
            }

            public int GetHashCode(int obj)
            {
                throw new NotImplementedException();
            }
        }


    }
    

}
