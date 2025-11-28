import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AuthService } from '../../services/auth-service';
import { takeUntil, Subject } from 'rxjs';
import { UserPayload } from '../../interfaces/auth/user-payload';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    RouterLink,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule,
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  private destroySubject = new Subject();
  isLoggedIn: boolean = false;
  user?: UserPayload | null;

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.authService.authStatus
      .pipe(takeUntil(this.destroySubject))
      .subscribe((result) => {
        this.isLoggedIn = result;
      });

    this.authService.user.subscribe((user) => {
      this.user = user;
    });
  }

  onLogout(): void {
    this.authService.logout();
    this.snackBar.open('Logged out', undefined, {
      duration: 2000,
    });
    this.router.navigate(['/']);
  }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();
  }

  ngOnDestroy() {
    this.destroySubject.next(true);
    this.destroySubject.complete();
  }
}
