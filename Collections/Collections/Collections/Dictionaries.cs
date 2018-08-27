using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Dictionaries
    {

        /*
            A Dictionary<TKey,TValue> can be used in scenarios in which you want to store items and retrieve them by key, 
            it doesn’t allow duplicate keys
            The Dictionary class is implemented as a hash table, which makes retrieving a value very fast, close to O(1).

            The class signature of the Dictionary<TKey,TValue> class is as follows:

                public class Dictionary<TKey, TValue> : 
                             IDictionary<TKey, TValue>,
                             ICollection<KeyValuePair<TKey, TValue>>, 
                             IDictionary, 
                             ICollection,
                             IReadOnlyDictionary<TKey, TValue>, 
                             IReadOnlyCollection<KeyValuePair<TKey, TValue>>,
                             IEnumerable<KeyValuePair<TKey, TValue>>, 
                             IEnumerable, 
                             ISerializable,
                             IDeserializationCallback
       */

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        static void Example()
        {
            Person p1 = new Person { Id = 1, Name = "Name1" };
            Person p2 = new Person { Id = 2, Name = "Name2" };
            Person p3 = new Person { Id = 3, Name = "Name3" };
            var dict = new Dictionary<int, Person>();
            dict.Add(p1.Id, p1);
            dict.Add(p2.Id, p2);
            dict.Add(p3.Id, p3);
            foreach (KeyValuePair<int, Person> v in dict)
            {
                Console.WriteLine("{0}: {1}", v.Key, v.Value.Name);
            }
            dict[0] = new Person { Id = 4, Name = "Name4" };
            Person result;
            if (!dict.TryGetValue(5, out result))
            {
                Console.WriteLine("No person with a key of 5 can be found");
            }
        }
    }
}
