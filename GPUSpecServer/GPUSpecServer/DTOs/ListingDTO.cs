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
    }
}