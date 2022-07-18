using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class Vendor
    {
        public string Id
        {
            get => Identifier.Id;
            set => Identifier.Id = value;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public BaseAddress Address { get; set; }

        [DataMember(Name = "contactPoint")]
        public ContactPoint ContactPoint { get; set; }

        
        [DataMember(Name = "identifier")]
        public Identifier Identifier { get; set; }


    }
}