using System.Runtime.Serialization;
using WebProzorro.Models.Enums;
using WebProzorro.Models.Internals;

namespace WebProzorro.Models;

[DataContract]
public class OfferDTO : BaseItemDTO
{
    [DataMember(Name = "relatedProduct")]
    public string RelatedProduct { get; set; }

    [DataMember(Name = "deliveryAddresses")]
    public List<DeliveryAddress> DeliveryAddresses { get; set; } = new();

    [DataMember(Name = "status")]
    public Status Status { get; set; }

    [DataMember(Name = "suppliers")]
    public List<Supplier> Suppliers { get; set; } = new();

    [DataMember(Name = "value")]
    public Value Value { get; set; }

    [DataMember(Name = "minOrderValue")]
    public Value? MinOrderValue { get; set; }

    [DataMember(Name = "comment")]
    public string Comment { get; set; }

    [DataMember(Name = "owner")]
    public string Owner { get; set; }

    
}
