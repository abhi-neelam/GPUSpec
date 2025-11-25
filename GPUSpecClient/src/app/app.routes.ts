import { Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { BrowsePageComponent } from './browse-page/browse-page.component';
import { SignupPageComponent } from './signup-page/signup-page.component';

export const routes: Routes = [
  { path: 'browse', component: BrowsePageComponent, pathMatch: 'full' },
  { path: 'login', component: LoginPageComponent, pathMatch: 'full' },
  { path: 'signup', component: SignupPageComponent, pathMatch: 'full' },
  { path: '', component: HomePageComponent, pathMatch: 'full' },
];
