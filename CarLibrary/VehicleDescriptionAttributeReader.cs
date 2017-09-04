using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    class VehicleDescriptionAttributeReader
    {
        public void ReflectOnAttributesUsingEarlyBInding()
        {
            Type t = typeof(Winnebago);
            object[] customAtts = t.GetCustomAttributes(false);
            foreach (VehicleDescriptionAttribute v in customAtts)
                Console.WriteLine("-> {0}\n ", v.Description);
        }
    }

    public class MainContaner
    {
        public static void Main()
        {
            Console.WriteLine(" **** Value of VehicleDescriptionAttribute **** ");
            VehicleDescriptionAttributeReader atributeReader = new VehicleDescriptionAttributeReader();
            atributeReader.ReflectOnAttributesUsingEarlyBInding();
            Console.ReadLine();
        }

        
    }
}
