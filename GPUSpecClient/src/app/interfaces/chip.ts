export interface Chip {
  id: number;
  name: string;

  foundry: string | null;
  process_size: number | null;
  transistors: number | null;
  density: number | null;
  die_size: number | null;
  chip_package: string | null;

  directx_major_version: number | null;
  directx_minor_version: number | null;

  opengl_major_version: number | null;
  opengl_minor_version: number | null;

  vulkan_major_version: number | null;
  vulkan_minor_version: number | null;

  opencl_major_version: number | null;
  opencl_minor_version: number | null;

  cuda_major_version: number | null;
  cuda_minor_version: number | null;

  shader_model_major_version: number | null;
  shader_model_minor_version: number | null;
}
