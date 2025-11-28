import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { FavoritesService } from '../../services/favorites-service';
import { Listing } from '../../interfaces/listing';

@Component({
  selector: 'app-favorites-page',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatProgressSpinnerModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule,
  ],
  templateUrl: './favorites-page.component.html',
  styleUrls: ['./favorites-page.component.scss'],
})
export class FavoritesPageComponent implements OnInit {
  favorites: Listing[] = [];
  isLoading = true;

  constructor(
    private favoritesService: FavoritesService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.isLoading = true;
    this.favoritesService.getFavorites().subscribe({
      next: (data) => {
        this.favorites = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error(error);
        this.isLoading = false;
      },
    });
  }

  onRemoveFavorite(event: Event, listingId: number): void {
    event.stopPropagation();
    event.preventDefault();

    const index = this.favorites.findIndex((f) => f.id === listingId);
    const removedItem = this.favorites[index];
    if (index > -1) {
      this.favorites.splice(index, 1);
    }

    this.favoritesService.toggleFavorite(listingId).subscribe({
      next: () => {
        this.snackBar.open('Removed from favorites', undefined, {
          duration: 2000,
        });
      },
      error: () => {
        if (removedItem) {
          this.favorites.splice(index, 0, removedItem);
        }
      },
    });
  }
}
