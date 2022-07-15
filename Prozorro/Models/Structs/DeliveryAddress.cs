using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Structs;

[DataContract]
public struct DeliveryAddress
{
    [DataMember(Name = "countryName")]
    public string CountryName { get; set; }
    [DataMember(Name = "locality")]
    public string Locality { get; set; }
    [DataMember(Name = "postalCode")]
    public string? PostalCode { get; set; }
    [DataMember(Name = "region")]
    public string Region { get; set; }
    [DataMember(Name = "streetAddress")]
    public string? StreetAddress { get; set; }
}
