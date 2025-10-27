using Microsoft.EntityFrameworkCore;

namespace GPUSpecServer.Data.Models
{
    [Index(nameof(Name))]
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Listing>? Listings { get; set; }

        public required int tensor_cores { get; set; }
        public required int rt_cores { get; set; }
    }
}