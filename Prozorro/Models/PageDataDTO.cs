using System.Runtime.Serialization;

namespace Prozorro.Models;

[DataContract]
public class PageDataDTO
{
    [DataMember(Name = "offset")]
    public string Offset { get; set; }

    [DataMember(Name = "path")]
    public string Path { get; set; }

    [DataMember(Name = "uri")]
    public string Uri { get; set; }
}
