using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProzorro.Models.Internals
{
    [DataContract]
    public class Identifier
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "legalName")]
        public string LegalName { get; set; }

        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }

        public virtual List<Supplier> Suppliers { get; set; }

        public override string? ToString()
        {
            return $"Id: {Id};\nLegal name: {LegalName};\nScheme: {Scheme}";
        }
    }
}
