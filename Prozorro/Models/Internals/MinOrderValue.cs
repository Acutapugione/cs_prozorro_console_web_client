using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Internals;

[DataContract]
public class MinOrderValue
{
    public int Id { get; set; }

    [DataMember(Name = "amount")]
    public decimal Amount { get; set; }

    [DataMember(Name = "currency")]
    public string Currency { get; set; }
}
