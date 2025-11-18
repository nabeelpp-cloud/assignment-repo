import { Routes } from '@angular/router';
import { BookingListComponent } from './booking-list/booking-list.component';
import { BookingDetailsComponent } from './booking-details/booking-details.component';
import { BookingLayoutComponent } from './booking-layout/booking-layout.component';
import { EditBookingComponent } from './edit-booking/edit-booking.component';
import { DeleteBookingComponent } from './delete-booking/delete-booking.component';

export const bookingsRoutes: Routes = [
  { path: '', component: BookingListComponent },
  {
    path: ':id',
    component: BookingLayoutComponent,
    children: [
      {
        path: 'bookings',
        component: BookingListComponent,
        children: [
          { path: ':id/update', component: EditBookingComponent },
          { path: ':id/delete', component: DeleteBookingComponent },
        ],
      },

      { path: '', redirectTo: 'bookings', pathMatch: 'full' },
    ],
  },
];
