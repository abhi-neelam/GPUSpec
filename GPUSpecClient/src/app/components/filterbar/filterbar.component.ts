import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SelectOption } from '../../interfaces/selectoption';
import { rawArchitectures, rawManufacturers } from '../../constants/rawoptions';

@Component({
  selector: 'app-filterbar',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule],
  templateUrl: './filterbar.component.html',
  styleUrl: './filterbar.component.scss',
})
export class FilterbarComponent {
  selectedManufacturer: string = 'All Manufacturers';

  manufacturers: SelectOption[] = rawManufacturers.map((item) => ({
    value: item === 'All Manufacturers' ? '' : item,
    display: item,
  }));

  architectures: SelectOption[] = rawArchitectures.map((item) => ({
    value: item === 'All Architectures' ? '' : item,
    display: item,
  }));
}
