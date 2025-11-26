import { Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { BrowsePageComponent } from './components/browse-page/browse-page.component';
import { SignupPageComponent } from './components/signup-page/signup-page.component';

export const routes: Routes = [
  { path: 'browse', component: BrowsePageComponent },
  { path: 'login', component: LoginPageComponent, pathMatch: 'full' },
  { path: 'signup', component: SignupPageComponent, pathMatch: 'full' },
  { path: '', component: HomePageComponent, pathMatch: 'full' },
];
