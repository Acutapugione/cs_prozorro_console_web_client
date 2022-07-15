using System.Runtime.Serialization;

namespace Prozorro.Models.Internals;

[DataContract]
public class Product
{
    [DataMember(Name = "name")]
    public string Name { get; set; }
}