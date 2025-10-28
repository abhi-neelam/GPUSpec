using GPUSpecServer.Data.Models;
using System.Linq.Expressions;

namespace GPUSpecServer.DTOs
{
    public class ListingDTO
    {
        public required int Id { get; set; }
        public required int ChipId { get; set; }
        public required int ProductId { get; set; }

        public required string chip { get; set; }
        public required string product { get; set; }
        public required string architecture { get; set; }
        public required string generation { get; set; }
        public required string manufacturer { get; set; }
        public required float memory_size { get; set; }
        public DateOnly? release_date { get; set; }
        public string? foundry { get; set; }
        public int? process_size { get; set; }

        public static Expression<Func<Listing, ListingDTO>> Projection
        {
            get
            {
                return l => new ListingDTO { Id = l.Id, ChipId = l.ChipId, ProductId = l.ProductId, chip = l.Chip.Name, product = l.Product.Name, architecture = l.architecture, generation = l.generation, manufacturer = l.manufacturer, memory_size = l.memory_size, release_date = l.release_date, foundry = l.Chip.foundry, process_size = l.Chip.process_size };
            }
        }
    }
}