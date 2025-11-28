import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import {
  ReactiveFormsModule,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth-service';
import { LoginRequest } from '../../interfaces/auth/login-request';
import { LoginResult } from '../../interfaces/auth/login-result';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    RouterLink,
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss',
})
export class LoginPageComponent {
  loginResult?: LoginResult;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private snackBar: MatSnackBar
  ) {}

  loginForm = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email],
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
  });

  ngOnInit() {
    this.loginForm.valueChanges.subscribe(() => {
      this.loginResult = undefined;
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    var loginRequest = <LoginRequest>{};
    loginRequest.email = this.loginForm.controls['email'].value;
    loginRequest.password = this.loginForm.controls['password'].value;

    this.authService.login(loginRequest).subscribe({
      next: (result) => {
        this.loginResult = result;
        if (result.success) {
          this.snackBar.open('Logged in', undefined, {
            duration: 2000,
          });
          this.router.navigate(['/']);
        }
      },
      error: (error) => {
        if (error.status == 401) {
          console.log(error.error);
          this.loginResult = error.error;
        }
      },
    });
  }
}
