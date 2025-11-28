import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { environment } from '../../../environments/environment';
import { GPUListing } from '../../interfaces/gpulisting';
import { PagedResult } from '../../interfaces/pagedresult';
import { Observable } from 'rxjs';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-gpulisting-page',
  standalone: true,
  imports: [RouterLink, MatProgressSpinnerModule, MatIconModule],
  templateUrl: './gpulisting-page.component.html',
  styleUrl: './gpulisting-page.component.scss',
})
export class GPUListingPageComponent {
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  data: GPUListing | null = null;
  isLoading = true;

  ngOnInit() {
    var idParam: string = this.activatedRoute.snapshot.paramMap.get('id')!;

    this.http
      .get<GPUListing>(`${environment.baseUrl}api/Listings/${idParam}`)
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
  }
}
