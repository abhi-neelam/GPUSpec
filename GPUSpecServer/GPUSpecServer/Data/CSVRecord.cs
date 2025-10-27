using CsvHelper.Configuration.Attributes;

namespace GPUSpecServer.Data
{
    public class CSVRecord
    {
        public required string manufacturer { get; set; }

        [Name("name")]
        public required string product { get; set; }

        [Name("gpu_name")]
        public required string chip { get; set; }
        public required string generation { get; set; }

        public required string architecture { get; set; }

        [Name("base_clock_mhz")]
        public required float base_clock { get; set; }

        [Name("boost_clock_mhz")]
        public required float boost_clock { get; set; }

        [Name("memory_clock_mhz")]
        public float? memory_clock { get; set; }
        public string? foundry { get; set; }

        [Name("process_size_nm")]
        public float? process_size { get; set; }

        [Name("transistor_density_k_mm2")]
        public float? density { get; set; }

        [Name("die_size_mm2")]
        public float? die_size { get; set; }

        public DateOnly? release_date { get; set; }
        public string? bus_interface { get; set; }

        [Name("memory_size_gb")]
        public required float memory_size { get; set; }

        [Name("memory_bus_bits")]
        public float? memory_bus { get; set; }

        [Name("memory_bandwidth_gb_s")]
        public float? memory_bandwidth { get; set; }
        public required string memory_type { get; set; }
        public required string shading_units { get; set; }

        [Name("texture_mapping_units")]
        public required int tmus { get; set; }

        [Name("render_output_processors")]
        public required int rops { get; set; }

        [Name("streaming_multiprocessors")]
        public required int smus { get; set; }

        public required int tensor_cores { get; set; }

        [Name("ray_tracing_cores")]
        public required int rt_cores { get; set; }

        [Name("l1_cache_kb")]
        public required float l1_cache { get; set; }

        [Name("l2_cache_mb")]
        public required float l2_cache { get; set; }

        [Name("thermal_design_power_w")]
        public float? tdp { get; set; }

        [Name("board_length_mm")]
        public float? board_length { get; set; }

        [Name("board_width_mm")]
        public float? board_width { get; set; }
        public string? board_slot_width { get; set; }

        [Name("suggested_psu_w")]
        public float? suggested_psu { get; set; }
        public string? power_connectors { get; set; }
        public string? display_connectors { get; set; }

        [Name("pixel_rate_gpixel_s")]
        public float pixel_rate { get; set; }

        [Name("texture_rate_gtexel_s")]
        public float texture_rate { get; set; }

        [Name("half_float_performance_gflop_s")]
        public float? fp16 { get; set; }

        [Name("single_float_performance_gflop_s")]
        public float? fp32 { get; set; }

        [Name("double_float_performance_gflop_s")]
        public float? fp64 { get; set; }

        public required string tpu_id { get; set; }
        public required string tpu_url { get; set; }

        [Name("transistor_count_m")]
        public float? transistors { get; set; }
        public string? chip_package { get; set; }

        public float? directx_major_version { get; set; }
        public float? directx_minor_version { get; set; }
        public float? opengl_major_version { get; set; }
        public float? opengl_minor_version { get; set; }
        public float? vulkan_major_version { get; set; }
        public float? vulkan_minor_version { get; set; }
        public float? opencl_major_version { get; set; }
        public float? opencl_minor_version { get; set; }
        public float? cuda_major_version { get; set; }
        public float? cuda_minor_version { get; set; }
        public float? shader_model_major_version { get; set; }
        public float? shader_model_minor_version { get; set; }
    }
}
