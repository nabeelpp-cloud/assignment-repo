import { Component } from '@angular/core';
import { BookingService } from '../../../../shared/services/booking.service';
import { AuthService } from '../../../../shared/services/auth.service';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-my-booking',
  imports: [DatePipe,CurrencyPipe,CommonModule],
  templateUrl: './my-booking.component.html',
  styleUrl: './my-booking.component.scss',
})
export class MyBookingComponent {
printInvoice() {
throw new Error('Method not implemented.');
}
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
  getStatusText(status: any): string {
    const statusMap: { [key: number]: string } = {
      0: 'Pending',
      1: 'Confirmed',
      2: 'Cancelled',
      3: 'Completed'
    };
    return statusMap[status] || 'Unknown';    
  }

  getStatusClass(status: number): string {
    const classMap: { [key: number]: string } = {
      0: 'status-pending',   
      1: 'status-confirmed', 
      2: 'status-cancelled', 
      3: 'status-completed'  
    };
    return classMap[status] || 'status-default';
  }
}
