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
using System.Runtime.Serialization;

namespace SerializationDeserialization
{
    public class WCFSerialization
    {
        /*
            Data Contract Serializer is used by WCF to serialize your objects to XML or JSON.
            DataContractAttribute instead of SerializableAttribute.
            members are not serialized by default. You have to explicitly mark them with the DataMember attribute. 
            As with binary serialization, you can use OnDeserializedAttribute, 
                                                        OnDeserializingAttribute,
                                                        OnSerializedAttribute, 
                                                        OnSerializingAttribute 
            to configure the four phases of the serialization and deserialization process.
        */

        /*
          [DataContract]
          public class PersonDataContract
          {
              [DataMember]
              public int Id { get; set; }
              [DataMember]
              public string Name { get; set; }
              private bool isDirty = false;
          }

      */
        public static void Example()
        {
            
        }

       
    }
}
