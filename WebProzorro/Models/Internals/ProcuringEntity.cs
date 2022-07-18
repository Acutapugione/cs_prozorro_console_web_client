using WebProzorro.Models.Enums;
using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals;

[DataContract]
public class ProcuringEntity
{
    public int Id { get; set; }

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