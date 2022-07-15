using System.Runtime.Serialization;

namespace Prozorro.Models.Enums
{
    [DataContract]
    public enum Kind
    {
        [DataMember(Name = "central")]
        Central
    }
}