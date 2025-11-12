import { Routes } from '@angular/router';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { HomeComponent } from './home/home.component';
import { HotelsListComponent } from './hotel/hotels-list/hotels-list.component';

export const userRoutes: Routes = [
  {
    path: '',
    component: UserLayoutComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path : 'hotels' , component : HotelsListComponent},
      { path: '', redirectTo: 'home', pathMatch: 'full' },
    ],
  },
];
