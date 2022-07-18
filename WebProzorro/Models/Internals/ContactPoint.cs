using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class ContactPoint
    {

        public int Id { get; set; }

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
