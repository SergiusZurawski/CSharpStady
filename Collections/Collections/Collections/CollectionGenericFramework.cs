using System;
using System.Collections;
///  System.Collections - All collections Non Generic
///  System.Collections.Generic - All collections  Generic
///  System.Collections.Concurrent - All Concurent Collections
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Collections
{
    public class CollectionGenericFramework
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
            ISet<int> iSet;                     //  Generic.ICollection<T>,
                                                //  Generic.IEnumerable<T>

            IReadOnlyCollection<int> iReadOnlyCollection; // System.Collections.Generic.IEnumerable<out T>
            IReadOnlyDictionary<int, int>
                iReadOnlyDictionary; // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
            // System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>
            IReadOnlyList<int> iReadOnlyList; //System.Collections.Generic.IEnumerable<out T>,
            //System.Collections.Generic.IReadOnlyCollection<out T>
            
            
            //
            ISerializable iSerializable;
            IDeserializationCallback iSerializableCallback;
            //Classes 
            
            Comparer<int> comparer = new CollectionGenericFramework.IntComparer();  //Abstract
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
                iSerializable = dictionary01;
                iSerializableCallback = dictionary01;
            
            EqualityComparer<int> equalityComparer = new IntEqualityComparer(); //Abstract
                iEqualityComparer = equalityComparer;
            
            HashSet<int> hashSet = new HashSet<int>(){1, 2, 3};
                iCollection = hashSet;
                iEnumerable = hashSet;
                iCollection = hashSet;
                iReadOnlyCollection = hashSet;
                iSet = hashSet;
                
                iSerializable = hashSet;
                iSerializableCallback = hashSet;
            
            LinkedList<int> ll = new LinkedList<int>(); //System.Collections.Generic.ICollection<T>,
                                                        //System.Collections.Generic.IEnumerable<T>,
                                                        //System.Collections.Generic.IReadOnlyCollection<T>,
                                                        //System.Collections.ICollection,
                                                        //System.Runtime.Serialization.IDeserializationCallback,
                                                        //System.Runtime.Serialization.ISerializable
            //Each node in linke list is LinkedListNode<T>
            LinkedListNode<int> listNode = new LinkedListNode<int>(1);
            //The only multithreaded scenario supported by LinkedList<T> is multithreaded read operations.
                string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
                sentence.AddFirst("today");
                sentence.AddLast("mark1");
                sentence.RemoveFirst();
                sentence.RemoveLast();
            
            List<int> list = new List<int>();    //System.Collections.Generic.ICollection<T>,
                                                 //System.Collections.Generic.IEnumerable<T>,
                                                 //System.Collections.Generic.IList<T>,
                                                 //System.Collections.Generic.IReadOnlyCollection<T>,
                                                 //System.Collections.Generic.IReadOnlyList<T>,
                                                 //System.Collections.IList

            Queue<int> queue = new Queue<int>(); //System.Collections.Generic.IEnumerable<T>,
                                                 //System.Collections.Generic.IReadOnlyCollection<T>,
                                                 //System.Collections.ICollection
                queue.Enqueue(1);
                queue.Dequeue();
            SortedDictionary<int, int>.KeyCollection keyCollection; 
                                                 //System.Collections.Generic.ICollection<TKey>,
                                                 //System.Collections.Generic.IEnumerable<TKey>,
                                                 //System.Collections.Generic.IReadOnlyCollection<TKey>,
                                                 //System.Collections.ICollection

            SortedDictionary<int, int>.ValueCollection valueCollection1;
                                                 //System.Collections.Generic.ICollection<TValue>,
                                                 //System.Collections.Generic.IEnumerable<TValue>,
                                                 //System.Collections.Generic.IReadOnlyCollection<TValue>,
                                                 //System.Collections.ICollection
            SortedList<int, int> sortedList;
                                                 //System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                                 //System.Collections.Generic.IDictionary<TKey,TValue>,
                                                 //System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                                 //System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                                 //System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>, System.Collections.IDictionary
            SortedSet<int> sortedSet;            
                                                //System.Collections.Generic.ICollection<T>,
                                                //System.Collections.Generic.IEnumerable<T>,
                                                //System.Collections.Generic.IReadOnlyCollection<T>,
                                                //System.Collections.Generic.ISet<T>,
                                                //System.Collections.ICollection,
                                                //System.Runtime.Serialization.IDeserializationCallback,
                                                //System.Runtime.Serialization.ISerializable
            
            Stack<int> stack;                   //(LIFO) 
                                                //System.Collections.Generic.IEnumerable<T>,
                                                //System.Collections.Generic.IReadOnlyCollection<T>,
                                                //System.Collections.ICollection
            
            SynchronizedCollection<int> synchronizedCollection;
                                                // stores data in a List<T> container and it is thread-safe
                                                //System.Collections.Generic.ICollection<T>,
                                                //System.Collections.Generic.IEnumerable<T>
                                                //System.Collections.Generic.IList<T>,
                                                //System.Collections.IList
            SynchronizedKeyedCollection<int, int> synchronizedKeyedCollection;  //Provides a thread-safe collection, grouped by keys.
                                                //System.Collections.Generic.SynchronizedCollection<T>

            SynchronizedReadOnlyCollection<int> synchronizedReadOnlyCollection;  //	Provides a thread-safe, read-onl
                                                //System.Collections.Generic.ICollection<T>,
                                                //System.Collections.Generic.IEnumerable<T>,
                                                //System.Collections.Generic.IList<T>,
                                                //System.Collections.IList

        }
        
        
        public class IntComparer : Comparer<int>
        {
            public override int Compare(int x, int y)
            {
                return x > y ? 0 : 1;
            }
        }
        
        public class IntEqualityComparer : EqualityComparer<int>
        {
            public override bool Equals(int x, int y)
            {
                return x == y ? true : false;
            }
           

            public override int GetHashCode(int obj)
            {
                return obj;
            }
        }


        /*
          IReadOnlyCollection<int> iReadOnlyCollection; 	  //System.Collections.Generic.IEnumerable<out T>
            IReadOnlyDictionary<int, int> iReadOnlyDictionary; //System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                                               //System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>
            IReadOnlyList<int> iReadOnlyList;                  //System.Collections.Generic.IEnumerable<out T>, 
                                                               //System.Collections.Generic.IReadOnlyCollection<out T> 

            //Classes
            //Abstract
            Comparer<int> comparer = new CompareInts(); // For sorting; Coparer return int; -1; 0; 1.
                                                        // :System.Collections.Generic.IComparer<T>, 
                                                        //  System.Collections.IComparer 
            List<int> listOfInts1 = new List<int> { 3, 2, 2, 5 };
            listOfInts1.Sort(comparer);

            EqualityComparer<int> equalityComparer;     // :System.Collections.Generic.IEqualityComparer<T>; 
                                                        //  System.Collections.IEqualityComparer
        }
        */


    }

    public class Box
    {
        public Box(int lenght, int width)
        {

        }
    }

    public class CompareInts : Comparer<int>
    {
        public override int Compare(int a, int b)
        {
            return 0;
        }
    }

}
