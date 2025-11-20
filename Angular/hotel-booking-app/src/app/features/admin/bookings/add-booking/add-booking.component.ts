import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BookingService } from '../../../../shared/services/booking.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-booking',
  imports: [ReactiveFormsModule],
  templateUrl: './add-booking.component.html',
  styleUrl: './add-booking.component.scss'
})
export class AddBookingComponent {

  constructor(
    private bookingService: BookingService,
    private router: Router
  ) {}

  createBookingForm: FormGroup = new FormGroup({
    customerId: new FormControl('', Validators.required),
    roomId: new FormControl('', Validators.required),
    checkInDate: new FormControl('', Validators.required),
    checkOutDate: new FormControl('', Validators.required),
    totalAmount: new FormControl('', Validators.required),
    status: new FormControl(0)  
  });

  addBooking() {
    const formData = this.createBookingForm.value;

    const request = {
      customerId: Number(formData.customerId),
      roomId: Number(formData.roomId),
      checkInDate: formData.checkInDate + 'T00:00:00',
      checkOutDate: formData.checkOutDate + 'T00:00:00',
      totalAmount: Number(formData.totalAmount),
      status: Number(formData.status),
    };

    console.log('Final Request:', request);

    this.bookingService.createBooking(formData).subscribe({
      next: (response:any) => {
        if (response && response.bookingId) {
          console.log('Booking Added Successfully', response);
          alert('Booking Added Successfully');
          this.router.navigate(['/admin/bookings']);
          this.createBookingForm.reset();
        }
      },
      error: (err) => {
        console.log('Error', err);
      },
      complete: () => {
        console.log('API call completed');
      }
    });
  }
}
