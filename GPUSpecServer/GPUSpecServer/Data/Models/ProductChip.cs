namespace GPUSpecServer.Data.Models
{
    public class ProductChip
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ChipId { get; set; }
        public Chip? Chip { get; set; }
        public required int base_clock { get; set; }
        public required int boost_clock { get; set; }
        public int? memory_clock { get; set; }
        public string? foundry { get; set; }
        public int? process_size { get; set; }
        public float? density { get; set; }
        public int? die_size { get; set; }
        public DateOnly? release_date { get; set; }
        public string? bus_interface { get; set; }
        public required string memory_size { get; set; }
        public string? memory_bus { get; set; }
        public string? memory_bandwidth { get; set; }
        public string? memory_type { get; set; }
        public required string shading_units { get; set; }
        public required int tmus { get; set; }
        public required int rops { get; set; }
        public required int smus { get; set; }
        public required int l1_cache { get; set; }
        public required decimal l2_cache { get; set; }
        public int? tdp { get; set; }
        public int? board_length { get; set; }
        public int? board_width { get; set; }
        public string? board_slot_width { get; set; }
        public int? suggested_psu { get; set; }
        public string? power_connectors { get; set; }
        public string? display_connectors { get; set; }

        public decimal pixel_rate { get; set; }
        public decimal texture_rate { get; set; }

        public decimal fp16{ get; set; }
        public decimal fp32 { get; set; }
        public decimal fp64 { get; set; }

        public required string tpu_id { get; set; }
        public required string tpu_url { get; set; }
    }
}
