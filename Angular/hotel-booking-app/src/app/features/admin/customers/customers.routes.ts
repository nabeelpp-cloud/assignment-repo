import { Routes } from '@angular/router';
import { CustomersListComponent } from './customers-list/customers-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { CustomerBookingsComponent } from './customer-bookings/customer-bookings.component';

export const customersRoutes: Routes = [
  { path: '', component: CustomersListComponent },
  {
    path: ':id',
    component: CustomerDetailComponent,
    children: [
      { path: 'bookings', component: CustomerBookingsComponent },
      { path: '', redirectTo: 'bookings', pathMatch: 'full' },
    ],
  },
];
