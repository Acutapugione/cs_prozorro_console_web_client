using System.Runtime.Serialization;

namespace Prozorro.Models.Internals;

[DataContract]
public class Image
{
    public int Id { get; set; }

    [DataMember(Name = "sizes")]
    public string Sizes { get; set; }

    [DataMember(Name = "url")]
    public string Url { get; set; }
}