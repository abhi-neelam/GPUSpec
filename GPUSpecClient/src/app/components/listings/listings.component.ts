import { Component, Input } from '@angular/core';
import { Listing } from '../../interfaces/listing';
import { PagedResult } from '../../interfaces/pagedresult';

@Component({
  selector: 'app-listings',
  standalone: true,
  imports: [],
  templateUrl: './listings.component.html',
  styleUrl: './listings.component.scss',
})
export class ListingsComponent {
  @Input({ required: true }) data: PagedResult<Listing> | null = null;
}
