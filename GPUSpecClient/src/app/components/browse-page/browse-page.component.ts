import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ListingsComponent } from '../listings/listings.component';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { FilterbarComponent } from '../filterbar/filterbar.component';
import { Listing } from '../../interfaces/listing';
import { PagedResult } from '../../interfaces/pagedresult';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-browse-page',
  standalone: true,
  imports: [FilterbarComponent, ListingsComponent],
  templateUrl: './browse-page.component.html',
  styleUrl: './browse-page.component.scss',
})
export class BrowsePageComponent {
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  data: PagedResult<Listing> | null = null;
  isLoading = false;

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params: any) => {
      this.isLoading = true;

      this.http
        .get<PagedResult<Listing>>(`${environment.baseUrl}api/Listings`, {
          params: params,
        })
        .subscribe({
          next: (result) => {
            this.data = result;
            this.isLoading = false;
          },
          error: (error) => {
            console.error(error);
            this.isLoading = false;
          },
        });
    });
  }
}
