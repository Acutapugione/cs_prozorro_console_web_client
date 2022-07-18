using System.Runtime.Serialization;

namespace WebProzorro.Models.Enums
{
    [DataContract]
    public enum Kind
    {
        [DataMember(Name = "central")]
        Central
    }
}