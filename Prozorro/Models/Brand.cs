﻿using System.Runtime.Serialization;

namespace Prozorro;

[DataContract]
public class Brand
{
    [DataMember(Name = "name")]
    public string Name { get; set; }
    
    [DataMember(Name = "uri")]
    public string? Uri { get; set; }
}