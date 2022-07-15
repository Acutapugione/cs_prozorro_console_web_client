using System.Runtime.Serialization;

namespace Prozorro.Models.Internals
{
    [DataContract]
    public class Requirement
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "dataType")]
        public string DataType { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "unit")]
        public Unit? Unit { get; set; }

        [DataMember(Name = "minValue")]
        public decimal? MinValue { get; set; }
    }
}