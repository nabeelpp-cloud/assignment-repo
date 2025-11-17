import { Component } from '@angular/core';
import { BookingService } from '../../../../shared/services/booking.service';
import { AuthService } from '../../../../shared/services/auth.service';

@Component({
  selector: 'app-my-booking',
  imports: [],
  templateUrl: './my-booking.component.html',
  styleUrl: './my-booking.component.scss',
})
export class MyBookingComponent {
  constructor(private bookingService: BookingService,private authService : AuthService) {}
  bookings: any[] = [];
  customerId : any ;
  

  ngOnInit() {
    this.customerId = Number(this.authService.getUserIdSnapshot());
    this.loadBookings(this.customerId);

  }
  loadBookings(customerId: number) {
    this.bookingService.getBookingsByCustomerId(this.customerId).subscribe({
      next: (data) => {
        this.bookings = data as any;
        console.log(this.bookings);
      },
      error: (err) => {
        console.log('Error', err);
      },
      complete: () => {
        console.log('Api call completed');
      },
    });
  }
}
