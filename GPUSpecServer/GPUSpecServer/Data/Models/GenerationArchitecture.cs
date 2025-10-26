namespace GPUSpecServer.Data.Models
{
    public class GenerationArchitecture
    {
        public int Id { get; set; }

        public int GenerationId { get; set; }
        public Generation? Generation { get; set; }
        public int ArchitectureId { get; set; }
        public Architecture? Architecture { get; set; }
    }
}
