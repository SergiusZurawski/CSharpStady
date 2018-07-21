using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parsing
{
    public class JsonSerialization
    {
        public static void Example()
        {
            /*
            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<Dictionary<string, object>>(json);
            */
            string json = "{'name':'Sergii','lastName':'Zhuravskyi'}";
            //Deserializing into JSON object
            object desirialized = JsonConvert.DeserializeObject(json);
            Newtonsoft.Json.Linq.JObject user = desirialized as Newtonsoft.Json.Linq.JObject;
            Console.WriteLine(user["name"]);

            //Deserializing into Real Object
            JsonUser user1 = JsonConvert.DeserializeObject<JsonUser>(json);
            Console.Write(user1);
        }

        public static void ExampleSerialize()
        {
            JsonUser user = new JsonUser() { name="Sergio", lastName="Belisimo" };
            string output = JsonConvert.SerializeObject(user);
            Console.WriteLine( output);

        }

        public static void ExampleSerializeAdvanced()
        {
            JsonUser user = new JsonUser() { name = "Sergio", lastName = "Belisimo" };
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"json.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, user);
            }
        }
    }

    public class JsonUser
    {
        public string name;
        public string lastName;

        public override string ToString()
        {
            return String.Format("name:{0}, lastname{1}", name, lastName);
        }
    }
}
