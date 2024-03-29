﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProzorro.Models.Internals;

[DataContract]
public class Value
{
    public int Id { get; set; }

    [DataMember(Name = "amount")]
    public decimal Amount { get; set; }

    [DataMember(Name = "currency")]
    public string Currency { get; set; }

    [DataMember(Name = "valueAddedTaxIncluded")]
    public bool ValueAddetTaxIncluded { get; set; } = false;
}
