import { inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../services/auth-service';

export const LoggedInGuard: CanActivateFn = (
  next: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const authService: AuthService = inject(AuthService);
  const router: Router = inject(Router);

  if (authService.isAuthenticated()) {
    return router.createUrlTree(['/']);
  }

  return true;
};
