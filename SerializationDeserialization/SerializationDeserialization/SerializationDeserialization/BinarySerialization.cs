using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDeserialization
{
    public class BinarySerialization
    {
        /*
        In essence, using binary serialization looks like using the XmlSerializer. You need to mark
        an item with the SerializableAttribute and then you use instance of the binary serializer to
        serialize an object or an object graph to a Stream. 

        Different compared to XML serialization -  private fields are serialized by default. 
        Another thing is that during deserialization, no constructors are executed. 
        You have to take this into account when working with binary serialization.
            
        [NonSerialized] attribute - prevent fields from being serialized

        serializer can’t find a specific field, it won’t throw an exception (XML won't); If you have an optional field use OptionalFieldAttribute.
        */

        [Serializable]
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private bool isDirty = false;
        }

        public static void Example()
        {
            Person p = new Person
            {
                Id = 1,
                Name = "John Doe"
            };
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }
            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                Person dp = (Person)formatter.Deserialize(stream);
            }
        }

        /*
         You can influence the serialization and deserialization process in four specific phases, 
        ■ OnDeserializedAttribute
        ■ OnDeserializingAttribute
        ■ OnSerializedAttribute
        ■ OnSerializingAttribute
         */

        [Serializable]
        public class Person2
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [NonSerialized]
            private bool isDirty = false;
            [OnSerializing()]
            internal void OnSerializingMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerializing.");
            }
            [OnSerialized()]
            internal void OnSerializedMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerialized.");
            }
            [OnDeserializing()]
            internal void OnDeserializingMethod(StreamingContext context)
            {
                Console.WriteLine("OnDeserializing.");
            }
            [OnDeserialized()]
            internal void OnDeserializedMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerialized.");
            }
        }

        //Using ISerializable Interface to protect data
        [Serializable]
        public class PersonComplex : ISerializable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private bool isDirty = false;
            public PersonComplex() { }
            //This constructor is called during deserialization, and you use
            // it to retrieve the values and initialize your object. As you can see, you are free in choosing the
            // names for the values that you add to the SerializationInfo.
            protected PersonComplex(SerializationInfo info, StreamingContext context)
            {
                Id = info.GetInt32("Value1");
                Name = info.GetString("Value2");
                isDirty = info.GetBoolean("Value3");
            }

            // This method is called when your object is serialized
            // It should add the values that you want to serialize as key/value pairs to the SerializationInfo
            //you should mark this method with a SecurityPermission attribute -  so that it is allowed to execute serialization and deserialization code.
            [System.Security.Permissions.SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Value1", Id);
                info.AddValue("Value2", Name);
                info.AddValue("Value3", isDirty);
            }
        }
    }
}
