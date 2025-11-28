import { Component, Input } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Listing } from '../../interfaces/listing';
import { AuthService } from '../../services/auth-service';
import { FavoritesService } from '../../services/favorites-service';

@Component({
  selector: 'app-listing-tile',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatIconModule, RouterLink],
  templateUrl: './listing-tile.component.html',
  styleUrl: './listing-tile.component.scss',
})
export class ListingTileComponent {
  @Input({ required: true }) listing!: Listing;
  @Input() isFavorite = false;

  constructor(
    private favService: FavoritesService,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  onToggleFavorite(e: Event) {
    e.stopPropagation();

    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/login']);
      return;
    }

    this.isFavorite = !this.isFavorite;

    this.favService.toggleFavorite(this.listing.id).subscribe({
      error: (error) => {
        console.error(error);
        this.isFavorite = !this.isFavorite;
      },
    });
  }
}
