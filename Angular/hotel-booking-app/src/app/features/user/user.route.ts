import { Routes } from '@angular/router';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { HomeComponent } from './home/home.component';
import { HotelsListComponent } from './hotel/hotels-list/hotels-list.component';
import { HotelDetailsComponent } from './hotel/hotel-details/hotel-details.component';
import { BookHotelComponent } from './hotel/book-hotel/book-hotel.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { authGuard } from './auth/guard/auth.guard';
import { MyBookingComponent } from './booking/my-booking/my-booking.component';
import { BookSuccessComponent } from './booking/book-success/book-success.component';

export const userRoutes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '',
    component: UserLayoutComponent,
    children: [
      { path: 'home', component: HomeComponent },
      {
        path: 'hotels',
        component: HotelsListComponent,
      },
      {
        path: 'hotels/:id',
        component: HotelDetailsComponent,
      },
      {
        path: 'bookings',
        component: MyBookingComponent,
        canActivate: [authGuard],
      },
      {
        path: 'book-success/:id',
        component: BookSuccessComponent,
        canActivate: [authGuard],
      },
      {
        path: 'book-hotel/:id',
        component: BookHotelComponent,
        canActivate: [authGuard],
      },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
    ],
  },
];
