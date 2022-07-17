using System.Runtime.Serialization;

namespace Prozorro.Models.Internals
{
    [DataContract]
    public class Classification
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }

        public virtual List<ProfileDTO> ProfileDTOs { get; set; }

        public virtual List<CategoryDTO> CategoryDTOs { get; set; }

        public virtual List<ProductDTO> ProductDTOs { get; set; }

        public override string? ToString()
        {
            return $"Id: {Id};\nDescription: {Description};\nScheme: {Scheme}";
        }
    }
}