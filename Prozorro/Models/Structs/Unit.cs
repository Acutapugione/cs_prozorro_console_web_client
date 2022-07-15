using System.Runtime.Serialization;

namespace Prozorro.Models.Structs
{
    [DataContract]
    public struct Unit
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}