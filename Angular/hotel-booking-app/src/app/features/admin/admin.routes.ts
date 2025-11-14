import { Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { authGuard } from '../../core/guards/auth.guard';

export const adminRoutes: Routes = [
  {
    path:'login',
    component:LoginComponent
  },  
  {
    path: '',
    component: AdminLayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: 'home', component: HomeComponent },
      {
        path: 'hotels',
        loadChildren: () =>
          import('./hotels/hotels.routes').then(m => m.hotelRoutes),
      },
      {
        path: 'customers',
        loadChildren: () =>
          import('./customers/customers.routes').then(m => m.customersRoutes),
      },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: '**', redirectTo: 'home' },
    ],
  },
  
];
