using System.Runtime.Serialization;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class Unit
    {
        public int Id { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}