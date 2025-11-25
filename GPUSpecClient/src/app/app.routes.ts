import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListingComponent } from './listing/listing.component';
import { SearchComponent } from './search/search.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'search', component: SearchComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
];
