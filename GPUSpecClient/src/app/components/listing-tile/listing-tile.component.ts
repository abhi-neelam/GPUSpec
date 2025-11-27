import { Component, Input } from '@angular/core';
import { Listing } from '../../interfaces/listing';

@Component({
  selector: 'app-listing-tile',
  standalone: true,
  imports: [],
  templateUrl: './listing-tile.component.html',
  styleUrl: './listing-tile.component.scss',
})
export class ListingTileComponent {
  @Input({ required: true }) listing!: Listing;
}
