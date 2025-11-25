import { Component } from '@angular/core';
import { FilterbarComponent } from '../filterbar/filterbar.component';
import { ListingsComponent } from '../listings/listings.component';

@Component({
  selector: 'app-browse-page',
  standalone: true,
  imports: [FilterbarComponent, ListingsComponent],
  templateUrl: './browse-page.component.html',
  styleUrl: './browse-page.component.scss',
})
export class BrowsePageComponent {}
