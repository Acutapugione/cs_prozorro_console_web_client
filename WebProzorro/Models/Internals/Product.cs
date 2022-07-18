using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals;

[DataContract]
public class Product
{
    public int Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }
}