using System.Runtime.Serialization;

namespace Prozorro.Models;

[DataContract]
public class Product
{
    [DataMember(Name = "name")]
    public string Name { get; set; }
}