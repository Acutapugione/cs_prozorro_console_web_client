using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Enums
{
    [DataContract]
    public enum Status
    {
        [DataMember(Name = "active")]
        Active,
        [DataMember(Name = "hidden")]
        Hidden
    }
}
