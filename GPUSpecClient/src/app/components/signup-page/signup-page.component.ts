import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth-service';
import { SignupRequest } from '../../interfaces/auth/signup-request';
import { SignupResult } from '../../interfaces/auth/signup-result';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-signup-page',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    MatIconModule,
    RouterLink,
  ],
  templateUrl: './signup-page.component.html',
  styleUrl: './signup-page.component.scss',
})
export class SignupPageComponent {
  signupResult?: SignupResult;

  constructor(
    private activatedRoute: ActivatedRoute,
    public router: Router,
    private authService: AuthService,
    private snackBar: MatSnackBar
  ) {}

  signupForm = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email],
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, this.createPasswordStrengthValidator()],
    }),
  });

  get passwordValue(): string {
    return this.signupForm.controls.password.value;
  }

  get hasUpperCase(): boolean {
    return /[A-Z]/.test(this.passwordValue);
  }

  get hasLowerCase(): boolean {
    return /[a-z]/.test(this.passwordValue);
  }

  get hasDigit(): boolean {
    return /\d/.test(this.passwordValue);
  }

  get hasSpecialChar(): boolean {
    return /[^a-zA-Z0-9]/.test(this.passwordValue);
  }

  get hasMinLength(): boolean {
    return this.passwordValue.length >= 6;
  }

  createPasswordStrengthValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value || '';
      const hasDigit = /\d/.test(value);
      const hasSpecial = /[^a-zA-Z0-9]/.test(value);
      const hasMinLength = value.length >= 6;

      const passwordValid = hasDigit && hasSpecial && hasMinLength;

      return passwordValid ? null : { weakPassword: true };
    };
  }

  submit() {
    if (this.signupForm.invalid) {
      return;
    }

    const returnUrl =
      this.activatedRoute.snapshot.queryParams['returnUrl'] || '/';

    var signupRequest = <SignupRequest>{};
    signupRequest.email = this.signupForm.controls['email'].value;
    signupRequest.password = this.signupForm.controls['password'].value;

    this.authService.signup(signupRequest).subscribe({
      next: (result) => {
        this.signupResult = result;
        if (result.success) {
          this.snackBar.open('Successfully signed up', undefined, {
            duration: 2000,
          });
          this.router.navigate([returnUrl], { replaceUrl: true });
        }
      },
      error: (error) => {
        console.log(error.error);
        this.signupResult = error.error;
      },
    });
  }
}
