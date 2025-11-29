import { Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { BrowsePageComponent } from './components/browse-page/browse-page.component';
import { SignupPageComponent } from './components/signup-page/signup-page.component';
import { GPUListingPageComponent } from './components/gpulisting-page/gpulisting-page.component';
import { FavoritesPageComponent } from './components/favorites-page/favorites-page.component';
import { AuthGuard } from './routeguards/auth-guard';
import { LoggedInGuard } from './routeguards/logged-in-guard';

export const routes: Routes = [
  { path: 'browse', component: BrowsePageComponent },
  {
    path: 'favorites',
    component: FavoritesPageComponent,
    canActivate: [AuthGuard],
  },
  { path: 'gpulisting/:id', component: GPUListingPageComponent },
  {
    path: 'login',
    component: LoginPageComponent,
    canActivate: [LoggedInGuard],
  },
  {
    path: 'signup',
    component: SignupPageComponent,
    canActivate: [LoggedInGuard],
  },
  { path: '', component: HomePageComponent, pathMatch: 'full' },
];
