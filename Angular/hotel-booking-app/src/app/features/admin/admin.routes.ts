import { Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { HomeComponent } from './home/home.component';

export const adminRoutes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
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
