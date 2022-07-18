using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals;

[DataContract]
public class RequirementResponse
{
    public int Id { get; set; }

    [DataMember(Name = "requirement")]
    public string Requirement { get; set; }

    [DataMember(Name = "value")]
    public string Value { get; set; }
}