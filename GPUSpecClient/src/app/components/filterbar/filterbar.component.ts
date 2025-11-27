import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SelectOption } from '../../interfaces/selectoption';
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
  selectedManufacturer: string = '';
  selectedArchitecture: string = '';
  selectedMemoryType: string = '';

  minMemorySize: number = defaultMinMemorySize;
  maxMemorySize: number = defaultMaxMemorySize;

  minProcessSize: number = defaultMinProcessSize;
  maxProcessSize: number = defaultMaxProcessSize;

  minReleaseYear: number = defaultMinReleaseYear;
  maxReleaseYear: number = defaultMaxReleaseYear;

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

  get isMemorySizeChanged(): boolean {
    return (
      this.minMemorySize !== defaultMinMemorySize ||
      this.maxMemorySize !== defaultMaxMemorySize
    );
  }

  get isProcessSizeChanged(): boolean {
    return (
      this.minProcessSize !== defaultMinProcessSize ||
      this.maxProcessSize !== defaultMaxProcessSize
    );
  }

  get isReleaseYearChanged(): boolean {
    return (
      this.minReleaseYear !== defaultMinReleaseYear ||
      this.maxReleaseYear !== defaultMaxReleaseYear
    );
  }
}
