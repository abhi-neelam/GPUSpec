import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, tap, Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { Listing } from '../interfaces/listing';

@Injectable({ providedIn: 'root' })
export class FavoritesService {
  constructor(private http: HttpClient) {}

  getFavorites(): Observable<Listing[]> {
    return this.http.get<Listing[]>(`${environment.baseUrl}api/Favorites`);
  }

  getFavorite(listingId: number): Observable<{ isFavorite: boolean }> {
    return this.http.get<{ isFavorite: boolean }>(
      `${environment.baseUrl}api/Favorites/${listingId}`,
      {}
    );
  }

  toggleFavorite(listingId: number): Observable<{ isFavorite: boolean }> {
    return this.http.post<{ isFavorite: boolean }>(
      `${environment.baseUrl}api/Favorites/toggle/${listingId}`,
      {}
    );
  }
}
