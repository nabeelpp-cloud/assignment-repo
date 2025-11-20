import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelService } from '../../../../shared/services/hotel.service';
import { SearchStateService } from '../../shared/services/search-state.service';
import { Subject, takeUntil } from 'rxjs';
import { CommonModule } from '@angular/common';

import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { dateRangeValidator } from '../../shared/validator/dateRangeValidator';
import { dateCannotBeBeforeTodayValidator } from '../../shared/validator/dateCannotBeBeforeTodayValidator';
import { AuthService } from '../../../../shared/services/auth.service';
import { CustomerService } from '../../../../shared/services/customer.service';
import { BookingService } from '../../../../shared/services/booking.service';

@Component({
  selector: 'app-book-hotel',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './book-hotel.component.html',
  styleUrl: './book-hotel.component.scss',
})
export class BookHotelComponent implements OnInit, OnDestroy {
  hotelId: any;
  hotel: any;
  checkInDate: any = '';
  checkOutDate: any = '';
  totalNights: number = 0;
  totalAmount: number = 0;
  rooms: any[] = [];
  userId!: number;
  bookingId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private searchStateService: SearchStateService,
    private hotelService: HotelService,
    private authService: AuthService,
    private customerservice: CustomerService,
    private bookingService: BookingService
  ) {}

  customerDetails: any;

  bookingForm = new FormGroup(
    {
      customerId: new FormControl(),
      roomId: new FormControl(null, [Validators.required]),
      checkInDate: new FormControl('', [
        Validators.required,
        dateCannotBeBeforeTodayValidator(),
      ]),
      checkOutDate: new FormControl('', [
        Validators.required,
        dateCannotBeBeforeTodayValidator(),
      ]),
      totalAmount: new FormControl(0),
    },
    { validators: dateRangeValidator() }
  );

  private destroy$ = new Subject<void>();

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.hotelId = params.get('id');
    });

    this.route.queryParamMap.subscribe((query) => {
      this.checkInDate = query.get('checkInDate') || '';
      this.checkOutDate = query.get('checkOutDate') || '';
    });
    this.bookingForm.patchValue({
      checkInDate: this.checkInDate,
      checkOutDate: this.checkOutDate,
    });

    this.bookingForm
      .get('checkInDate')
      ?.valueChanges.pipe(takeUntil(this.destroy$))
      .subscribe(() => this.handleDateChange());

    this.bookingForm
      .get('checkOutDate')
      ?.valueChanges.pipe(takeUntil(this.destroy$))
      .subscribe(() => this.handleDateChange());

    this.bookingForm
      .get('checkInDate')
      ?.valueChanges.pipe(takeUntil(this.destroy$))
      .subscribe(() => this.handleDateChange());

    this.bookingForm
      .get('checkOutDate')
      ?.valueChanges.pipe(takeUntil(this.destroy$))
      .subscribe(() => this.handleDateChange());

    this.userId = Number(this.authService.getUserIdSnapshot());
    this.loadCustomerDetail();
    this.loadHotelDetails();
  }

  handleDateChange() {
    const checkIn = this.bookingForm.value.checkInDate;
    const checkOut = this.bookingForm.value.checkOutDate;

    if (checkIn && checkOut) {
      this.isToggle = true;
      this.loadHotelDetails();
    } else {
      this.isToggle = false;
    }

    this.calculateAmount();
  }


  loadCustomerDetail() {
    this.customerservice
      .getCustomerDetails(this.userId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data) => {
          this.customerDetails = data as any;
          this.bookingForm.patchValue({
            customerId: this.userId,
          });
        },
        error: (err) => {
          console.log(err);
        },
        complete: () => {
          console.log('api call completed');
        },
      });
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  loadHotelDetails() {
    const checkIn = this.bookingForm.get('checkInDate')?.value;
    const checkOut = this.bookingForm.get('checkOutDate')?.value;
    if (!checkIn || !checkOut) {
      this.rooms = [];
      return;
    }
    this.hotelService
      .getHotelFullDetailsById(this.hotelId, checkIn, checkOut)
      ?.pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data) => {
          this.hotel = data as any;
          this.rooms = this.hotel.rooms;
          console.log(this.hotel);
          console.log(this.rooms);
        },
        error: (err) => {
          console.log('Error', err);
        },
      });
  }

  isOpen: boolean = false;
  isToggle: boolean = false;
  selectedRoom: any = null;

  toggleDropdown() {
    const checkIn = this.bookingForm.value.checkInDate;
    const checkOut = this.bookingForm.value.checkOutDate;

    if (checkIn && checkOut) {
      this.isToggle = true;
      this.loadHotelDetails();
    }
    if (this.isToggle) this.isOpen = !this.isOpen;
  }

  selectRoom(room: any, event: MouseEvent) {
    event.stopPropagation();
    this.selectedRoom = room;
    this.isOpen = false;
    this.calculateAmount();
  }

  calculateAmount() {
    if (!this.selectedRoom) {
      this.totalNights = 0;
      this.totalAmount = 0;
      this.bookingForm.patchValue({
        roomId: null,
        totalAmount: this.totalAmount,
      });
      return;
    }

    const checkIn = new Date(this.bookingForm.value.checkInDate || '');
    const checkOut = new Date(this.bookingForm.value.checkOutDate || '');

    if (
      !checkIn ||
      !checkOut ||
      checkIn.toString() === 'Invalid Date' ||
      checkOut.toString() === 'Invalid Date' ||
      this.bookingForm.hasError('dateRangeInvalid')
    ) {
      this.totalNights = 0;
      this.totalAmount = 0;
      this.bookingForm.patchValue({ totalAmount: this.totalAmount });
      return;
    }

    const timeDiff = checkOut.getTime() - checkIn.getTime();
    this.totalNights = Math.max(0, timeDiff / (1000 * 60 * 60 * 24));

    const totalPricePerNight = this.selectedRoom.pricePerNight;

    this.totalAmount = totalPricePerNight * this.totalNights;

    this.bookingForm.patchValue({
      roomId: this.selectedRoom.id,
      totalAmount: this.totalAmount,
    });
  }

  bookNow() {
    if (this.bookingForm.invalid) {
      this.bookingForm.markAllAsTouched();
      console.log('Form is invalid', this.bookingForm.errors);
      return;
    }
    this.bookingService.createBooking(this.bookingForm.value).subscribe({
      next: (response : any) => {
        if (response && response.bookingId) {
          this.bookingId = response.bookingId;
          this.router.navigate(['/book-success', this.bookingId]);
        }
      },
      error: (err) => {
        console.log('Error ', err);
      },
      complete: () => {
        console.log('Api call completed');
      },
    });
  }
}
