import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatSliderModule } from '@angular/material/slider';
import { FormsModule } from '@angular/forms';
import { CommonModule, TitleCasePipe } from '@angular/common';
import { Subject, takeUntil } from 'rxjs';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SearchStateService } from '../../shared/services/search-state.service';

@Component({
  selector: 'app-hotels-list',
  imports: [
    NgxPaginationModule,
    MatSliderModule,
    FormsModule,
    TitleCasePipe,
    CommonModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './hotels-list.component.html',
  styleUrl: './hotels-list.component.scss',
})
export class HotelsListComponent {
  hotels: any[] = [];
  searchTerm: string = '';
  checkInDate: string = '';
  checkOutDate: string = '';
  isLoading: boolean = false;

  tempSearchTerm: string = '';
  tempCheckInDate: string = '';
  tempCheckOutDate: string = '';

  minPrice: number = 0;
  maxPrice: number = 1000;
  step: number = 10;

  selectedMinPrice: number = 0;
  selectedMaxPrice: number = 1000;

  selectedRatings: number[] = [];

  page: number = 1;
  itemsPerPage: number = 4;
  totalItems: number = 0;
  totalPages: number = 1;

  isChangeSearch: boolean = false;

  private destroy$ = new Subject<void>();
  constructor(
    private hotelService: HotelService,
    private route: ActivatedRoute,
    private router: Router,
    private searchState: SearchStateService
  ) {}

  ngOnInit() {
    this.route.queryParams
      .pipe(takeUntil(this.destroy$))
      .subscribe((params) => {
        this.searchTerm = params['searchTerm'] || '';
        this.checkInDate = params['checkIn'] || '';
        this.checkOutDate = params['checkOut'] || '';
        console.log(this.searchTerm, this.checkInDate, this.checkOutDate);
        this.searchState.setDates(this.checkInDate, this.checkOutDate);
        this.loadHotels();
      });
  }
  loadHotels() {
    this.isLoading = true;
    this.hotelService
      .getHotelsFullDetails(
        this.searchTerm,
        this.checkInDate,
        this.checkOutDate,
        this.page,
        this.itemsPerPage,
        this.selectedMaxPrice,
        this.selectedMinPrice,
        this.selectedRatings
      )
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (respose: any) => {
          this.hotels = respose.hotels;
          this.page = respose.pageNumber;
          this.itemsPerPage = respose.pageSize;
          this.totalItems = respose.totalCount;
          this.totalPages = respose.totalPages;
          console.log(this.hotels);
        },
        error: (err) => {
          console.error('Error:', err);
        },
        complete: () => {
          console.log('API call completed');
        },
      });
    this.isLoading = false;
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
  goToPage(pageNumber: number) {
    if (pageNumber < 1 || pageNumber > this.totalPages) return;
    this.page = pageNumber;
    this.loadHotels();
  }

  nextPage() {
    if (this.page < this.totalPages) {
      this.page++;
      this.loadHotels();
    }
  }

  prevPage() {
    if (this.page > 1) {
      this.page--;
      this.loadHotels();
    }
  }

  openChangeSearch() {
    this.tempSearchTerm = this.searchTerm;
    this.tempCheckInDate = this.checkInDate;
    this.tempCheckOutDate = this.checkOutDate;
    this.isChangeSearch = true;
  }

  searchHotel() {
    this.searchTerm = this.tempSearchTerm;
    this.checkInDate = this.tempCheckInDate;
    this.checkOutDate = this.tempCheckOutDate;
    this.page = 1;
    this.isChangeSearch = false;
    this.loadHotels();
  }

  toggleRating(rating: number, event: any) {
    if (event.target.checked) {
      if (!this.selectedRatings.includes(rating)) {
        this.selectedRatings.push(rating);
      }
    } else {
      this.selectedRatings = this.selectedRatings.filter((r) => r !== rating);
    }
    console.log(this.selectedRatings);
  }

  applyFilter() {
    this.loadHotels();
  }
  gotoHotelDetails(id: number) {
    console.log(id);
    this.router.navigate([`/hotels/${id}`],{
      queryParams : {
        checkInDate : this.checkInDate,
        checkOutDate  : this.checkOutDate
      }
    });
  }
}
