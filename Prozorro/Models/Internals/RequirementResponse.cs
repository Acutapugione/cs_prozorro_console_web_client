using System.Runtime.Serialization;

namespace Prozorro.Models.Internals;

[DataContract]
public class RequirementResponse
{
    [DataMember(Name = "requirement")]
    public string Requirement { get; set; }

    [DataMember(Name = "value")]
    public string Value { get; set; }
}