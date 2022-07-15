﻿using Prozorro.Models.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Models.Internals;

[DataContract]
public class Supplier
{
    [DataMember(Name = "name")]
    public string Name { get; set; }
    [DataMember(Name = "scale")]
    public string? Scale { get; set; }
    [DataMember(Name = "address")]
    public DeliveryAddress Address { get; set; }
    [DataMember(Name = "contactPoint")]
    public ContactPoint ContactPoint { get; set; }
    [DataMember(Name = "identifier")] 
    public Identifier Identifier { get; set; }
}

