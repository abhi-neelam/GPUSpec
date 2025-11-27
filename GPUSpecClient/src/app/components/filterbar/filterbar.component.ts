import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SelectOption } from '../../interfaces/selectoption';
import { ActivatedRoute, Router } from '@angular/router';
import {
  rawArchitectures,
  rawManufacturers,
  rawMemoryTypes,
} from '../../constants/rawoptions';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import {
  defaultMinMemorySize,
  defaultMaxMemorySize,
  defaultMinProcessSize,
  defaultMaxProcessSize,
  defaultMinReleaseYear,
  defaultMaxReleaseYear,
  defaultArchitecture,
  defaultManufacturer,
  defaultMemoryType,
} from '../../constants/ranges';

@Component({
  selector: 'app-filterbar',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
    MatSliderModule,
    MatButtonModule,
  ],
  templateUrl: './filterbar.component.html',
  styleUrl: './filterbar.component.scss',
})
export class FilterbarComponent {
  constructor(private activatedRoute: ActivatedRoute, private router: Router) {}

  readonly minMemoryLimit = defaultMinMemorySize;
  readonly maxMemoryLimit = defaultMaxMemorySize;
  readonly minProcessLimit = defaultMinProcessSize;
  readonly maxProcessLimit = defaultMaxProcessSize;
  readonly minYearLimit = defaultMinReleaseYear;
  readonly maxYearLimit = defaultMaxReleaseYear;

  selectedManufacturer: string = '';
  selectedArchitecture: string = '';
  selectedMemoryType: string = '';

  minMemorySize: number = defaultMinMemorySize;
  maxMemorySize: number = defaultMaxMemorySize;

  minProcessSize: number = defaultMinProcessSize;
  maxProcessSize: number = defaultMaxProcessSize;

  minReleaseYear: number = defaultMinReleaseYear;
  maxReleaseYear: number = defaultMaxReleaseYear;

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
      this.selectedManufacturer = params['manufacturer'] || '';
      this.selectedArchitecture = params['architecture'] || '';
      this.selectedMemoryType = params['memory_type'] || '';

      this.minMemorySize = params['min_memory_size']
        ? Number(params['min_memory_size'])
        : this.minMemoryLimit;

      this.maxMemorySize = params['max_memory_size']
        ? Number(params['max_memory_size'])
        : this.maxMemoryLimit;

      this.minProcessSize = params['min_process_size']
        ? Number(params['min_process_size'])
        : this.minProcessLimit;

      this.maxProcessSize = params['max_process_size']
        ? Number(params['max_process_size'])
        : this.maxProcessLimit;

      this.minReleaseYear = params['min_release_year']
        ? Number(params['min_release_year'])
        : this.minYearLimit;

      this.maxReleaseYear = params['max_release_year']
        ? Number(params['max_release_year'])
        : this.maxYearLimit;
    });
  }

  manufacturers: SelectOption[] = rawManufacturers.map((item) => ({
    value: item === defaultManufacturer ? '' : item,
    display: item,
  }));

  architectures: SelectOption[] = rawArchitectures.map((item) => ({
    value: item === defaultArchitecture ? '' : item,
    display: item,
  }));

  memoryTypes: SelectOption[] = rawMemoryTypes.map((item) => ({
    value: item === defaultMemoryType ? '' : item,
    display: item,
  }));

  onSubmit() {
    this.router.navigate(['/browse'], {
      relativeTo: this.activatedRoute,
      queryParams: {
        manufacturer: this.selectedManufacturer,
        architecture: this.selectedArchitecture,
        memory_type: this.selectedMemoryType,
        min_memory_size: this.minMemorySize,
        max_memory_size: this.maxMemorySize,
        min_process_size: this.minProcessSize,
        max_process_size: this.maxProcessSize,
        min_release_year: this.minReleaseYear,
        max_release_year: this.maxReleaseYear,
        pageIndex: 1,
      },
      queryParamsHandling: 'merge',
    });
  }
}
