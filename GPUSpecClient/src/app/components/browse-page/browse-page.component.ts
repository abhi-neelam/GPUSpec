import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { Listing } from '../../interfaces/listing';
import { PagedResult } from '../../interfaces/pagedresult';
import { Observable } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import {
  ReactiveFormsModule,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ListingsComponent } from '../listings/listings.component';
import { FilterbarComponent } from '../filterbar/filterbar.component';

@Component({
  selector: 'app-browse-page',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    ListingsComponent,
    FilterbarComponent,
  ],
  templateUrl: './browse-page.component.html',
  styleUrl: './browse-page.component.scss',
})
export class BrowsePageComponent {
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}
  qControl = new FormControl('');
  data: PagedResult<Listing> | null = null;
  isLoading = false;

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params: any) => {
      const queryText = params['q'] || '';
      if (this.qControl.value !== queryText) {
        this.qControl.setValue(queryText);
      }

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

  onSubmit() {
    const queryText = this.qControl.value;

    this.router.navigate(['/browse'], {
      relativeTo: this.activatedRoute,
      queryParams: {
        q: queryText,
        pageIndex: 1,
      },
      queryParamsHandling: 'merge',
    });
  }
}
