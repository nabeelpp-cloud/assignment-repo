import { Component } from '@angular/core';
import { AuthService } from '../../../../shared/services/auth.service';
import { BookingService } from '../../../../shared/services/booking.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-book-success',
  imports: [DatePipe,CurrencyPipe],
  templateUrl: './book-success.component.html',
  styleUrl: './book-success.component.scss',
})
export class BookSuccessComponent {
  constructor(
    private bookingService: BookingService,
    private authService: AuthService,
    private route : ActivatedRoute,
    private router : Router
  ) {}
  bookingData: any;
  bookingId: any;

  showSuccessBox : boolean = true;

  ngOnInit() {
    this.route.paramMap.subscribe((params)=>{
      this.bookingId=params.get('id');
      console.log(this.bookingId);
      if(this.bookingId){
        this.loadBookings();
        setTimeout(()=>{
          this.showSuccessBox =false;
        },3000)
      }
    })
    
  }
  hideSuccessBox(){
  }
  loadBookings() {
    this.bookingService.getBookingById(this.bookingId).subscribe({
      next: (data) => {
        this.bookingData = data as any;
        console.log(this.bookingData);
      },
      error: (err) => {
        console.log('Error', err);
      },
      complete: () => {
        console.log('Api call completed');
      },
    });
  }
  printInvoice() {
    window.print();
  }
  gotoHome(){
    this.router.navigate(["/home"])
  }
  gotoBookings(){
    this.router.navigate(["/bookings"])
  }
}
