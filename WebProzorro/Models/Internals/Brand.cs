using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals;

[DataContract]
public class Brand
{
    [Key]
    public int Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "uri")]
    public string? Uri { get; set; }
}