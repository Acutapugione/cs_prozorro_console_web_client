using WebProzorro.Models.Enums;
using WebProzorro.Models.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProzorro.Models;

[DataContract]
public class VendorDTO : BaseItemDTO
{
    [DataMember(Name = "vendor")]
    public Vendor Vendor { get; set; }

    [DataMember(Name = "categories")]
    public List<Category> Categories { get; set; } = new();

    [DataMember(Name = "documents")]
    public List<Document> Documents { get; set; } = new();

    [DataMember(Name = "isActivated")]
    public bool IsActivated { get; set; } = false;

    [DataMember(Name = "dateCreated")]
    public string DateCreated { get; set; }

    [DataMember(Name = "status")]
    public Status Status { get; set; }

    [DataMember(Name = "owner")]
    public string Owner { get; set; }
}
