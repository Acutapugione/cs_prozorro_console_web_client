using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Structs;

[DataContract]
public struct MinOrderValue
{
    [DataMember(Name = "amount")]
    public decimal Amount { get; set; }
    [DataMember(Name = "currency")]
    public string Currency { get; set; }
}
