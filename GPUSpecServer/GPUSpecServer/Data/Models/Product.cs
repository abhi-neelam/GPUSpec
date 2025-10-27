using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GPUSpecServer.Data.Models
{
    [Index(nameof(Name))]
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public ICollection<Listing>? Listings { get; set; }

        public required int tensor_cores { get; set; }
        public required int rt_cores { get; set; }
    }
}