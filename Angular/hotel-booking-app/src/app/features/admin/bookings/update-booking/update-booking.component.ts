import { Component } from '@angular/core';
import { BookingService } from '../../../../shared/services/booking.service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-update-booking',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './update-booking.component.html',
  styleUrl: './update-booking.component.scss',
})
export class UpdateBookingComponent {
  booking: any;
  bookingId!: number;

  updateBookingForm: FormGroup = new FormGroup({
    id: new FormControl(),
    customerId: new FormControl('', Validators.required),
    roomId: new FormControl('', Validators.required),
    checkInDate: new FormControl('', Validators.required),
    checkOutDate: new FormControl('', Validators.required),
    totalAmount: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
  });

  constructor(
    private bookingService: BookingService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.parent?.paramMap.subscribe((params) => {
      this.bookingId = Number(params.get('id'));
      console.log(params);
      if (this.bookingId) {
        this.loadBooking(this.bookingId);
      }
    });
  }

  loadBooking(id: number) {
    this.bookingService.getBookingById(id).subscribe({
      next: (data) => {
        this.booking = data as any;
        console.log(this.booking);

        const formattedBooking = {
          ...this.booking,
          checkInDate: this.formatDate(this.booking.checkInDate),
          checkOutDate: this.formatDate(this.booking.checkOutDate),
          status: Number(this.booking.status),
        };

        this.updateBookingForm.patchValue(formattedBooking);
      },
      error: (err) => console.log('Error ', err),
      complete: () => console.log('API completed'),
    });
  }

  formatDate(dateString: string): string {
    if (!dateString) return '';
    return dateString.split('T')[0];
  }

  updateBooking() {
    const formData = this.updateBookingForm.value;

    const request = {
      id: this.bookingId,
      customerId: Number(formData.customerId),
      roomId: Number(formData.roomId),
      checkInDate: formData.checkInDate + 'T00:00:00',
      checkOutDate: formData.checkOutDate + 'T00:00:00',
      totalAmount: Number(formData.totalAmount),
      status: Number(formData.status),
    };

    console.log('Final Request:', request);

    this.bookingService.updateBooking(this.bookingId, request).subscribe({
      next: (response) => {
        if (Number(response) > 0) {
          alert('Booking Updated Successfully');
          this.router.navigate(['/admin/bookings']);
          this.updateBookingForm.reset();
        }
      },
      error: (err) => console.log('Error ', err),
      complete: () => console.log('API completed'),
    });
  }

  cancelClicked() {
    this.router.navigate(['/admin/bookings']);
  }
}
