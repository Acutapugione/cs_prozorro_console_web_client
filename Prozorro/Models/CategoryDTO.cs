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
public class CategoryDTO : BaseItemDTO
{
    [DataMember(Name = "classification")]
    public virtual Classification Classification { get; set; }


    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "images")]
    public List<Image> Images { get; set; } = new();

    [DataMember(Name = "procuringEntity")]
    public ProcuringEntity ProcuringEntity { get; set; }

    [DataMember(Name = "status")]
    public Status Status { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }

}
