using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPUSpecServer.Data.Models
{
    [Index(nameof(Name))]
    public class Generation
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<Chip>? Chips { get; set; }
        public ICollection<GenerationArchitecture>? GenerationArchitectures { get; set; }
    }
}
