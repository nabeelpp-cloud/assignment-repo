import { Routes } from '@angular/router';
import { HotelsListComponent } from './hotels-list/hotels-list.component';
import { HotelDetailsComponent } from './hotel-details/hotel-details.component';
import { HotelRoomsComponent } from './hotel-rooms/hotel-rooms.component';
import { HotelEmployeesComponent } from './hotel-employees/hotel-employees.component';
import { HotelReviewsComponent } from './hotel-reviews/hotel-reviews.component';
import { HotelInfoComponent } from './hotel-info/hotel-info.component';
import { AddHotelComponent } from './add-hotel/add-hotel.component';
import { UpdateHotelComponent } from './update-hotel/update-hotel.component';
import { DeleteHotelComponent } from './delete-hotel/delete-hotel.component';

export const hotelRoutes: Routes = [
  {
    path: '',
    component: HotelsListComponent,
  },
  {
    path: 'add',
    component: AddHotelComponent,
  },
  {
    path: ':id',
    component: HotelDetailsComponent,
    children: [
      { path: 'rooms', component: HotelRoomsComponent },
      { path: 'employees', component: HotelEmployeesComponent },
      { path: 'reviews', component: HotelReviewsComponent },
      { path: 'info', component: HotelInfoComponent },
      { path: '', redirectTo: 'info', pathMatch: 'full' },
    ],
  },
  { path: ':id/update', component: UpdateHotelComponent },
  { path: ':id/delete', component: DeleteHotelComponent },
];
