namespace GPUSpecServer.Data
{
    public class ListingSearchParams
    {
        public string? q { get; set; }
        public string? manufacturer {  get; set; }
        public string? architecture { get; set; }
        public string? generation { get; set; }
        public string? product { get; set; }
        public string? chip { get; set; }

        public int? min_release_year { get; set; }
        public int? max_release_year { get; set; }
        public int? min_process_size { get; set; }
        public int? max_process_size { get; set; }

        public float? min_memory_size { get; set; }
        public float? max_memory_size { get; set; }

        public float? min_memory_bus { get; set; }
        public float? max_memory_bus { get; set; }

        public string? memory_type { get; set; }
        public string? slot_width { get; set; }
    }
}
