using Prozorro.Models.Enums;
using Prozorro.Models.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models;

[DataContract]
public class ProductDTO : BaseItemDTO
{
    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "relatedProfile")]
    public string RelatedProfile { get; set; }

    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "classification")]
    public virtual Classification Classification { get; set; }


    [DataMember(Name = "identifier")]
    public Identifier Identifier { get; set; }

    [DataMember(Name = "alternativeIdentifiers")]
    public List<Identifier> AlternativeIdentifiers { get; set; } = new();

    [DataMember(Name = "brand")]
    public Brand Brand { get; set; }

    [DataMember(Name = "product")]
    public Product Product { get; set; }

    [DataMember(Name = "images")]
    public List<Image> Images { get; set; } = new();

    [DataMember(Name = "requirementResponses")]
    public List<RequirementResponse> RequirementResponses { get; set; } = new();

    [DataMember(Name = "status")]
    public Status Status { get; set; }

    [DataMember(Name = "owner")]
    public string Owner { get; set; }
}
