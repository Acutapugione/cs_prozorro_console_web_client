using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class RequirementGroup
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "requirements")]
        public List<Requirement> Requirements { get; set; }
    }
}