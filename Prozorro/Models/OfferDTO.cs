using System.Runtime.Serialization;
using Prozorro.Models.Enums;
using Prozorro.Models.Internals;
using Prozorro.Models.Structs;

namespace Prozorro.Models;

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
    public OfferValue Value { get; set; }

    [DataMember(Name = "minOrderValue")]
    public MinOrderValue? MinOrderValue { get; set; }

    [DataMember(Name = "comment")]
    public string Comment { get; set; }

    [DataMember(Name = "owner")]
    public string Owner { get; set; }
}

public class OffersDTO : BaseContainerDTO<OfferDTO>
{

}