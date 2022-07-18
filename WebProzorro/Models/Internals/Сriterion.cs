using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class Сriterion
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "requirementGroups")]
        public List<RequirementGroup> RequirementGroups { get; set; }
    }
}