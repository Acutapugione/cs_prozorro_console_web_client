using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals;

[DataContract]
public class PageData
{
    [DataMember(Name = "offset")]
    public string Offset { get; set; }

    [DataMember(Name = "path")]
    public string Path { get; set; }

    [DataMember(Name = "uri")]
    public string Uri { get; set; }
}
