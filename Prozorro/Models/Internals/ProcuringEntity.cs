using Prozorro.Models.Enums;
using Prozorro.Models.Structs;
using System.Runtime.Serialization;

namespace Prozorro.Models.Internals;

[DataContract]
public class ProcuringEntity
{
    [DataMember(Name = "address")]
    public DeliveryAddress Address { get; set; }

    [DataMember(Name = "contactPoint")]
    public ContactPoint ContactPoint { get; set; }

    [DataMember(Name = "identifier")]
    public Identifier Identifier { get; set; }

    [DataMember(Name = "kind")]
    public Kind Kind { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }


}