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
    class CollectionFramework
    {
        //Anonimus Types
        public static void ExampleAnonimusTypes()
        {
            var a = new { Name = "a", Age="1"};
            var b = new {Name = "c", Age = "2"};
            a = b;
            var z = new {Age = "1", Name = "z"};
            //a = z; 
            
            //Not strongly type
            var x = new {Age = "1", Skils = new ArrayList()
                            {
                                new Tuple<string, string>("", ""),
                                new {SkillName = "Programming", Efficenty = "Good"},
                                new {SkillName = "Programming", Efficenty = "Good"},
                                new {Skillrate = 1, Somehting = "Good"}
                                    
                            }
                        };
            
            //Strongly typed
//            var s = new 
//            { 
//                 Name= "sergii",  SkillSet = new List<Tuple<String,String>>()
//                {
//                    new Tuple<String,String>("", ""),
//                    new Tuple<String,int("", 1),
//                    new {SkillName = "Programming", Efficenty = "Good"},
//                }
//            };
        }

        public static void ExampleCollactionTypes()
        {
            
            IEnumerable iEnumerable;
            IEnumerator iEnumerator;
            ICollection iCollection;  // Sise and iEnumerator from iEnumerable inteface
            IList iList;
            IDictionary iDictionary;
            IDictionaryEnumerator iDictionaryEnumerator;
            
            ICloneable iCloneable;
            ISerializable iSerializable;
            IDeserializationCallback iDeserializationCallback;

            IComparer iComparer;
            IEqualityComparer iHashCodeProvider;
            IStructuralComparable iStructuralComparable;
            IStructuralEquatable iStructuralEquatable;
            // CLasses
            
            //ArrayList	 Implements the IList interface using an array whose size is dynamically increased as required.
            ArrayList arrayList = new ArrayList()
            {
                "1",
                1
            };
            //Intefaces implemeted
            iList = arrayList;
            iCollection = arrayList;
            iEnumerable = arrayList;
            iCloneable = arrayList;
            
            //Bit array, for bitwise apperation
            //BitArray	 Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit is on (1) and false indicates the bit is off (0).
            bool[] array = new bool[5];
            array[0] = true;
            array[1] = false; // <-- False value is default
            BitArray bitArray = new BitArray(array);
            
            iCollection = bitArray;
            iEnumerable = bitArray;
            iCloneable = bitArray;
            
            //CaseInsensitiveComparer	         Compares two objects for equivalence, ignoring the case of strings.
            //CaseInsensitiveHashCodeProvider	 Supplies a hash code for an object, using a hashing algorithm that ignores the case of strings. (is now obsolete.)
            //CollectionBase	                 Provides the abstract base class for a strongly typed collection. (is now obsolete.)
            
            //Comparer	Compares two objects for equivalence, where string comparisons are case-sensitive.
            String str1 = "llegar";
            String str2 = "lugar";
            int resultOfComparison = Comparer.DefaultInvariant.Compare(str1, str2);
            Comparer myCompIntl = new Comparer( new CultureInfo( "es-ES", false ) );
            resultOfComparison = myCompIntl.Compare(str1, str2);
            
            //DictionaryBase	Provides the abstract base class for a strongly typed collection of key/value pairs.
            DictionaryBase dbBase;
            
            // Hashtable	Represents a collection of key/value pairs that are organized based on the hash code of the key. 
            //and Structs  
            //    DictionaryEntry	Defines a dictionary key/value pair that can be set or retrieved.
            Hashtable hashtable = new Hashtable();
            hashtable.Add("txt", "notepad.exe");
            hashtable.Add("bmp", "paint.exe");
            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            
            iCollection = hashtable;
            iEnumerable = hashtable;
            iCloneable = hashtable;
            iDictionary = hashtable;
            iSerializable = hashtable;
            iDeserializationCallback = hashtable;
            
            //Queue	Represents a first-in, first-out collection of objects.
            //This class implements a queue as a circular array. Objects stored in a Queue are inserted at one end and removed from the other.
            Queue myQ = new Queue();
            myQ.Enqueue("Hello");
            iCollection = myQ;
            iEnumerable = myQ;
            iCloneable = myQ;
            
            //SortedList	Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index.
            // Internally, SortedList maintains two object[] array, one for keys and another for values. So when you add key-value pair,
            // it runs a binary search using the key to find an appropriate index to store a key and value in respective arrays.
            // It re-arranges the elements when you remove the elements from it.
            // SortedList collection sorts the elements everytime you add the elements. 
            // sortedList2 sorts the key in alphabetical order for string key
            SortedList mySL = new SortedList();
            mySL.Add("Third", "!");
            mySL.Add("Second", "World");
            mySL.Add("First", "Hello");
            
            iCollection = mySL;
            iEnumerable = mySL;
            iCloneable = mySL;
            iDictionary = mySL;
            
            //Stack	Represents a simple last-in-first-out (LIFO) non-generic collection of objects.
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            
            iCollection = myStack;
            iEnumerable = myStack;
            iCloneable = myStack;
            // StructuralComparisons	Provides objects for performing a structural comparison of two collection objects.
        }

        /*
            13                                                      11 
            IEnumerable iEnumerable;   								IEnumerable<int> iEnumerable;
            IEnumerator iEnumerator;   							    IEnumerator<int> iEnumerator; 
            ICollection iCollection;  							    ICollection<int> iCollection
            IList iList;											IList<int> iList;
            IDictionary iDictionary;								IDictionary<int, int> iDictionary;
            IDictionaryEnumerator iDictionaryEnumerator;			
            
            ICloneable iCloneable;
            ISerializable iSerializable;
            IDeserializationCallback iDeserializationCallback;
            
            IComparer iComparer;									IComparer<int> iComparer;  
            IEqualityComparer iHashCodeProvider;					IEqualityComparer<int> iEqualityComparer;
            IStructuralComparable iStructuralComparable;			
            IStructuralEquatable iStructuralEquatable;				
                                                                    ISet<int> iSet;
                                                                    IReadOnlyCollection<int> iReadOnlyCollection;
                                                                    IReadOnlyList<int> iReadOnlyList; 
                                                                    IReadOnlyDictionary<int, int>
         
         */
        
        /*  13                                    16
            CollectionBase	
            ArrayList							List<T>
									            LinkedList<T>
									            LinkedListNode<T>
            BitArray	

            Comparer							Comparer<T>
            CaseInsensitiveComparer	
            CaseInsensitiveHashCodeProvider
            	
            DictionaryBase						KeyedByTypeCollection<TItem>
            Hashtable							Dictionary<TKey,TValue>
            Queue								Queue<T>
            ReadOnlyCollectionBase	
            SortedList							SortedList<TKey,TValue>
                                                SortedDictionary<TKey,TValue>
                                                SortedSet<T>
            Stack								Stack<T>
            StructuralComparisons	
                                                EqualityComparer<T>
                                                HashSet<T>
                                                SynchronizedCollection<T>
                                                SynchronizedKeyedCollection<K,T>
                                                SynchronizedReadOnlyCollection<T>
         
         */

    }
}
