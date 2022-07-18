using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class Document: BaseItemDTO
    {
        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "format")]
        public string Format { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "datePublished")]
        public string DatePublished { get; set; }
    }
}