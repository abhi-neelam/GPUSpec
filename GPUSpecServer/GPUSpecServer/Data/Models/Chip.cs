using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPUSpecServer.Data.Models
{
    [Index(nameof(Name))]
    public class Chip
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Listing>? Listings { get; set; }

        public string? foundry { get; set; }
        public int? process_size { get; set; }
        public int? transistors { get; set; }
        public float? density { get; set; }
        public int? die_size { get; set; }
        public string? chip_package { get; set; }

        public int? directx_major_version { get; set; }
        public int? directx_minor_version { get; set; }
        public int? opengl_major_version { get; set; }
        public int? opengl_minor_version { get; set; }
        public int? vulkan_major_version { get; set; }
        public int? vulkan_minor_version { get; set; }
        public int? opencl_major_version { get; set; }
        public int? opencl_minor_version { get; set; }
        public int? cuda_major_version { get; set; }
        public int? cuda_minor_version { get; set; }
        public int? shader_model_major_version { get; set; }
        public int? shader_model_minor_version { get; set; }
    }
}
