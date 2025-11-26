export interface Listing {
  id: number;
  chipId: number;
  productId: number;

  chip: string;
  product: string;
  architecture: string;
  generation: string;
  manufacturer: string;

  memory_size: number;

  release_date: string | null;

  foundry: string | null;
  process_size: number | null;
}
