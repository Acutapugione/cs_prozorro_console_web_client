using System.Runtime.Serialization;

namespace Prozorro.Models.Internals;

[DataContract]
public class Product
{
    public int Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }
}