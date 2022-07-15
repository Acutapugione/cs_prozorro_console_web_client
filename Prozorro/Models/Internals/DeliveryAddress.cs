using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Internals;

[DataContract]
public class DeliveryAddress : BaseAddress
{
    [DataMember(Name = "postalCode")]
    public string? PostalCode { get; set; }

    [DataMember(Name = "streetAddress")]
    public string? StreetAddress { get; set; }
}
