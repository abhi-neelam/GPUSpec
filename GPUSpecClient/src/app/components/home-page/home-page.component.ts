import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  ReactiveFormsModule,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { inject } from '@angular/core';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss',
})
export class HomePageComponent {
  searchForm = new FormGroup({
    name: new FormControl(''),
  });

  constructor(private router: Router) {}

  onSubmit() {
    this.router.navigate(['/browse'], {
      queryParams: { q: this.searchForm.controls['name'].value },
    });
  }
}
