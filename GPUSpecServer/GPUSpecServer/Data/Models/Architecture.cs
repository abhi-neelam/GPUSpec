using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPUSpecServer.Data.Models
{
    [Index(nameof(Name))]
    public class Architecture
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        
        public int ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public ICollection<GenerationArchitecture>? GenerationArchitectures { get; set; }
    }
}
