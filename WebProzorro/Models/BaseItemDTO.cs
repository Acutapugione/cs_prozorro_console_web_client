using WebProzorro.Models.Internals;
using System.Runtime.Serialization;
using WebProzorro.Models.Internals;

namespace WebProzorro.Models
{
    [DataContract]
    public class BaseItemDTO
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "dateModified")]
        public string DateModified { get; set; }
    }

    [DataContract]
    public class BaseContainerDTO<T>
    {
        [DataMember(Name = "data")]
        public List<T> Data { get; set; }

        [DataMember(Name = "next_page")]
        public PageData? NextPage { get; set; }

        [DataMember(Name = "prev_page")]
        public PageData? PrewPage { get; set; }
    }
}