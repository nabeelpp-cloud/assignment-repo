import { Component } from '@angular/core';
import { BookingService } from '../../../../shared/services/booking.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-delete-booking',
  imports: [CommonModule],
  templateUrl: './delete-booking.component.html',
  styleUrl: './delete-booking.component.scss',
})
export class DeleteBookingComponent {
  booking: any;
  bookingId!: number;

  constructor(
    private bookingService: BookingService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.parent?.paramMap.subscribe(params => {
      this.bookingId = Number(params.get('id'));
      if (this.bookingId) {
        this.loadBooking(this.bookingId);
      }
    });
  }

  loadBooking(id: number) {
    this.bookingService.getBookingById(id).subscribe({
      next: (data) => {
        this.booking = data;
      },
      error: (err) => console.log('Error ', err),
      complete: () => console.log('API done'),
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
  
  confirmDelete() {
    if (confirm('Are you sure you want to delete this booking?')) {
      this.bookingService.deleteBooking(this.bookingId).subscribe({
        next: (response) => {
          if (Number(response) > 0) {
            alert('Booking Deleted Successfully');
            this.router.navigate(['/admin/bookings']);
          } else {
            alert('Error deleting booking');
          }
        },
        error: (err) => console.log(err),
      });
    }
  }

  goBack() {
    this.router.navigate(['/admin/bookings']);
  }
}
