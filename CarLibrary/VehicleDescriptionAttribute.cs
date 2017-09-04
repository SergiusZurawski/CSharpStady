using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited =false)]
    public sealed class VehicleDescriptionAttribute: System.Attribute
    {
        public string Description { get; set;}
        public VehicleDescriptionAttribute(string vehicalDecription)
        {
            Description = vehicalDecription;
        }
        public VehicleDescriptionAttribute() { }
    }
}
