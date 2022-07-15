using System.Runtime.Serialization;

namespace Prozorro.Models;

[DataContract]
public class RequirementResponse
{
    [DataMember(Name = "requirement")]
    public string Requirement { get; set; }

    [DataMember(Name = "value")]
    public string Value { get; set; }
}