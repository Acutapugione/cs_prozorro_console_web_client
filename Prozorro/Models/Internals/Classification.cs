using System.Runtime.Serialization;

namespace Prozorro.Models.Internals
{
    [DataContract]
    public class Classification
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }
    }
}