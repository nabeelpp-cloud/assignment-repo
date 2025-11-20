import { Routes } from '@angular/router';
import { BookingDetailsComponent } from './booking-details/booking-details.component';
import { BookingLayoutComponent } from './booking-layout/booking-layout.component';
import { BookingListComponent } from './booking-list/booking-list.component';
import { DeleteBookingComponent } from './delete-booking/delete-booking.component';
import { AddBookingComponent } from './add-booking/add-booking.component';
import { UpdateBookingComponent } from './update-booking/update-booking.component';

export const bookingsRoutes: Routes = [
  { path: '', component: BookingListComponent },          
  { path: 'add', component: AddBookingComponent },        

  {
    path: ':id',
    component: BookingLayoutComponent,                    
    children: [
      { path: '', component: BookingDetailsComponent },   
      { path: 'update', component: UpdateBookingComponent },
      { path: 'delete', component: DeleteBookingComponent }, 
    ]
  }
];
