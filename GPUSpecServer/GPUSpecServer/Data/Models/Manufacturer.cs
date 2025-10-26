using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPUSpecServer.Data.Models
{
    [Index(nameof(Name))]
    public class Manufacturer
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Architecture>? Architectures { get; set; }
    }
}