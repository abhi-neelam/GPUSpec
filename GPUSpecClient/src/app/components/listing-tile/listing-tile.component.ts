import { Component, Input } from '@angular/core';
import { Listing } from '../../interfaces/listing';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-listing-tile',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink],
  templateUrl: './listing-tile.component.html',
  styleUrl: './listing-tile.component.scss',
})
export class ListingTileComponent {
  constructor(private activatedRoute: ActivatedRoute, private router: Router) {}
  @Input({ required: true }) listing!: Listing;
}
