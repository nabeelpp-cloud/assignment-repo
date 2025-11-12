import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { inject } from '@angular/core';
import { environment } from '../../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HotelService {
  private baseUrl = `${environment.apiBaseUrl}/api/hotel`;
  private selectedHotelSubject = new BehaviorSubject<any>(null);
  selectedHotel$ = this.selectedHotelSubject.asObservable();

  constructor(private http: HttpClient) {}

  setSelectedHotel(hotel: any) {
    this.selectedHotelSubject.next(hotel);
  }

  getSelectedHotel() {
    return this.selectedHotelSubject.value;
  }
  getHotels() {
    return this.http.get(this.baseUrl);
  }
  getHotelsFullDetails(
    searchTerm?: string,
    checkInDate?: string,
    checkOutDate?: string,
    pageNumber: number = 1,
    pageSize: number = 10,
    selectedMaxPrice : number = 0,
    selectedMinPrice : number = 1000,
    selectedRatings? : number []
  ) {
    let params = new HttpParams();
    if (searchTerm) params = params.set('searchTerm', searchTerm);
    if (checkInDate) params = params.set('checkInDate', checkInDate);
    if (checkOutDate) params = params.set('checkOutDate', checkOutDate);
    if(selectedMaxPrice>0) params = params.set('maxPrice',selectedMaxPrice);
    if(selectedMinPrice<1000) params = params.set('minPrice',selectedMinPrice);
    if(selectedRatings!=null) params = params.set('selectedRatings',selectedRatings.toString());
    console.log(`${this.baseUrl}/full`, { params });
    params = params.set('pageNumber', pageNumber);
    params = params.set('pageSize', pageSize);
    return this.http.get(`${this.baseUrl}/full`, { params });
  }

  getHotelById(id: number) {
    return this.http.get(`${this.baseUrl}/${id}`);
  }
  getHotelWithRooms(id: number) {
    return this.http.get(`${this.baseUrl}/${id}/rooms`);
  }

  getHotelWithReviews(id: number) {
    return this.http.get(`${this.baseUrl}/${id}/reviews`);
  }

  getHotelWithEmployees(id: number) {
    return this.http.get(`${this.baseUrl}/${id}/employees`);
  }

  addHotel(hotel: any) {
    return this.http.post(this.baseUrl, hotel);
  }

  updateHotel(hotelId: number, hotel: any) {
    return this.http.patch(this.baseUrl, hotel);
  }
}
