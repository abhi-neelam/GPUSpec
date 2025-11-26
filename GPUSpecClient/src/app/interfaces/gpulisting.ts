import { Chip } from './chip';
import { Product } from './product';

export interface GPUListing {
  id: number;

  architecture: string;
  generation: string;
  manufacturer: string;

  base_clock: number;
  boost_clock: number;
  memory_clock: number | null;

  release_date: string | null;
  bus_interface: string | null;

  memory_size: number;
  memory_bus: number | null;
  memory_bandwidth: number | null;
  memory_type: string;

  shading_units: string;
  tmus: number;
  rops: number;
  smus: number;

  productId: number;
  product: Product;

  l1_cache: number;
  l2_cache: number;
  tdp: number | null;
  board_length: number | null;
  board_width: number | null;
  board_slot_width: string | null;
  suggested_psu: number | null;
  power_connectors: string | null;
  display_connectors: string | null;

  chipId: number;
  chip: Chip;

  pixel_rate: number;
  texture_rate: number;

  fp16: number | null;
  fp32: number | null;
  fp64: number | null;

  tpu_id: string;
  tpu_url: string;
}
