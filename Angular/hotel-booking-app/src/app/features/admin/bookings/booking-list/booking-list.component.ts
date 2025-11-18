import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';
import { BookingService } from '../../../../shared/services/booking.service';
import { CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-booking-list',
  imports: [RouterModule, DatePipe, CurrencyPipe],
  templateUrl: './booking-list.component.html',
  styleUrl: './booking-list.component.scss',
})
export class BookingListComponent {
  constructor(
    private bookingService: BookingService,
    private authService: AuthService,
    private router: Router
  ) {}
  bookings: any[] = [];

  ngOnInit() {
    this.loadBookings();
  }
  loadBookings() {
    this.bookingService.getBookings().subscribe({
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
  getStatusText(status: any): string {
    const statusMap: { [key: number]: string } = {
      0: 'Pending',
      1: 'Confirmed',
      2: 'Cancelled',
      3: 'Completed',
    };
    return statusMap[status] || 'Unknown';
  }
  deleteBooking(bookingId: any) {
    this.router.navigate(['/admin/bookings', bookingId, 'delete']);
  }
  editBooking(bookingId: any) {
    this.router.navigate(['/admin/bookings', bookingId, 'update']);
  }
}
