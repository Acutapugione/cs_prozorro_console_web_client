using System.Runtime.Serialization;
using Prozorro.Models.Enums;
using Prozorro.Models.Internals;
using Prozorro.Models.Structs;

namespace Prozorro.Models;

[DataContract]
public class ProfileDTO : BaseItemDTO
{
    [DataMember(Name = "classification")]
    public Classification Classification { get; set; }

    [DataMember(Name = "criteria")]
    public List<Сriterion> Criteria { get; set; } = new();

    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "images")]
    public List<Image> Images { get; set; } = new();

    [DataMember(Name = "owner")]
    public string Owner { get; set; }

    [DataMember(Name = "relatedCategory")]
    public string RelatedCategory { get; set; }

    [DataMember(Name = "status")]
    public Status Status { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "unit")]
    public Unit Unit { get; set; }

    [DataMember(Name = "value")]
    public Value Value { get; set; }

}
