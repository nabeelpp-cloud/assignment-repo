import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
  { 
    path: 'home', 
    component: HomeComponent 
  },
  {
    path: 'hotels',
    loadChildren: ()=>import('./features/hotels/hotels.routes').then(m=>m.hotelRoutes)
  },
  {
    path: 'customers',
    loadChildren: ()=>import('./features/customers/customers.routes').then(m=>m.customersRoutes)
  },
  { 
    path: '', 
    redirectTo: 'home', 
    pathMatch: 'full' 
  },
  { 
    path: '**', 
    redirectTo: 'home' 
  },
];
