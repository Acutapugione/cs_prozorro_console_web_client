﻿using System.Runtime.Serialization;

namespace Prozorro.Models.Internals
{
    [DataContract]
    public class Category
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}