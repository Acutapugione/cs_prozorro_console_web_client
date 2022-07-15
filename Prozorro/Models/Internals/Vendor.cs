﻿using Prozorro.Models.Structs;
using System.Runtime.Serialization;

namespace Prozorro.Models.Internals
{
    [DataContract]
    public class Vendor
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public BaseAddress Address { get; set; }

        [DataMember(Name = "contactPoint")]
        public ContactPoint ContactPoint { get; set; }

        [DataMember(Name = "identifier")]
        public Identifier Identifier { get; set; }


    }
}