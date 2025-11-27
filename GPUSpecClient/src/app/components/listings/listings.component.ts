import { Component, Input } from '@angular/core';
import { Listing } from '../../interfaces/listing';
import { PagedResult } from '../../interfaces/pagedresult';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SelectOption } from '../../interfaces/selectoption';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
@Component({
  selector: 'app-listings',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatPaginatorModule],
  templateUrl: './listings.component.html',
  styleUrl: './listings.component.scss',
})
export class ListingsComponent {
  constructor(private activatedRoute: ActivatedRoute, private router: Router) {}

  @Input({ required: true }) data: PagedResult<Listing> | null = null;
  selectedSortOption: string = 'desc';

  sortOptions: SelectOption[] = [
    { value: 'desc', display: 'Newest First' },
    { value: 'asc', display: 'Oldest First' },
  ];

  onPageChange(event: PageEvent) {
    this.router.navigate(['/browse'], {
      relativeTo: this.activatedRoute,
      queryParams: {
        pageIndex: event.pageIndex + 1,
        pageSize: event.pageSize,
      },
      queryParamsHandling: 'merge',
    });
  }

  onSubmit() {
    this.router.navigate(['/browse'], {
      relativeTo: this.activatedRoute,
      queryParams: {
        orderBy: this.selectedSortOption,
        pageIndex: 1,
      },
      queryParamsHandling: 'merge',
    });
  }
}
