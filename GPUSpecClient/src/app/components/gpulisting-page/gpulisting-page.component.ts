import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { environment } from '../../../environments/environment';
import { GPUListing } from '../../interfaces/gpulisting';
import { PagedResult } from '../../interfaces/pagedresult';
import { Observable } from 'rxjs';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { AuthService } from '../../services/auth-service';
import { FavoritesService } from '../../services/favorites-service';

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
    private http: HttpClient,
    private authService: AuthService,
    private favService: FavoritesService
  ) {}

  data: GPUListing | null = null;
  isLoading = true;
  isFavorite = false;

  ngOnInit() {
    var idParam: string = this.activatedRoute.snapshot.paramMap.get('id')!;

    if (this.authService.isAuthenticated()) {
      this.favService.getFavorite(parseInt(idParam)).subscribe({
        next: (result) => {
          this.isFavorite = result.isFavorite;
        },
        error: (error) => {
          console.error(error);
        },
      });
    }

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

  onToggleFavorite() {
    let snapshot = this.router.routerState.snapshot;

    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/login'], {
        relativeTo: this.activatedRoute,
        queryParams: {
          returnUrl: snapshot.url,
        },
        queryParamsHandling: 'merge',
      });
      return;
    }

    if (this.data === null) {
      return;
    }

    this.isFavorite = !this.isFavorite;

    this.favService.toggleFavorite(this.data.id).subscribe({
      error: (error) => {
        console.error(error);
        this.isFavorite = !this.isFavorite;
      },
    });
  }
}
