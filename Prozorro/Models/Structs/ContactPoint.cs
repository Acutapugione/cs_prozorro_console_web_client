using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Structs
{
    [DataContract]
    public struct ContactPoint
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "telephone")]
        public string Telephone { get; set; }

        [DataMember(Name = "url")]
        public string? Url { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "faxNumber")]
        public string? FaxNumber { get; set; }
    }
}
