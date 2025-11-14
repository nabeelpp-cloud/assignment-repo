import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { SearchStateService } from '../../shared/services/search-state.service';
import { HotelService } from '../../../../shared/services/hotel.service';
import { CommonModule, TitleCasePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSliderModule } from '@angular/material/slider';
import { NgxPaginationModule } from 'ngx-pagination';
import { DaysAgoPipe } from '../../shared/pipes/days-ago.pipe';

@Component({
  selector: 'app-hotel-details',
  imports: [
    NgxPaginationModule,
    MatSliderModule,
    FormsModule,
    TitleCasePipe,
    CommonModule,
    MatProgressSpinnerModule,
    DaysAgoPipe
  ],
  templateUrl: './hotel-details.component.html',
  styleUrl: './hotel-details.component.scss',
})
export class HotelDetailsComponent {
  hotelId: any;
  hotel: any;
  checkInDate: any;
  checkOutDate: any;
  currentImageIndex: number = 0;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private searchStateService: SearchStateService,
    private hotelService: HotelService
  ) {}

  private destroy$ = new Subject<void>();

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.hotelId = params.get('id');
    });

    this.route.queryParamMap.subscribe((query) => {
      this.checkInDate = query.get('checkInDate');
      this.checkOutDate = query.get('checkOutDate');
    });

    this.loadHotelDetails();
  }

  loadHotelDetails() {
    this.hotelService
      .getHotelFullDetailsById(
        this.hotelId,
        this.checkInDate,
        this.checkOutDate
      )
      ?.pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data) => {
          this.hotel = data as any;
          console.log(this.hotel);
        },
        error: (err) => {
          console.log('Error', err);
        },
      });
  }
  bookNow(hotelId : number) {
    this.router.navigate([`/book-hotel/${hotelId}`],{
      queryParams : {
        checkInDate : this.checkInDate,
        checkOutDate  : this.checkOutDate
      }
    })
  }

  changeMainImage(index: number) {
    this.currentImageIndex = index;
  }

  ngOnDestroy(){
    this.destroy$.next();
    this.destroy$.complete();
  }
}
