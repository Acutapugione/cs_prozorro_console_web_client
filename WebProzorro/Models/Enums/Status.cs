using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProzorro.Models.Enums
{
    [DataContract]
    public enum Status
    {
        [DataMember(Name = "active")]
        Active,
        [DataMember(Name = "hidden")]
        Hidden,
        [DataMember(Name = "general")]
        General,

    }
}
