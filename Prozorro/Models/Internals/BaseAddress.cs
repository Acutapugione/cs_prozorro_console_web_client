using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Prozorro.Models.Internals;

[DataContract]
public class BaseAddress
{
    public int Id { get; set; }

    [DataMember(Name = "countryName")]
    public string CountryName { get; set; }

    [DataMember(Name = "locality")]
    public string Locality { get; set; }

    [DataMember(Name = "region")]
    public string Region { get; set; }
}