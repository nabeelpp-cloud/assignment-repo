import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  private baseUrl = `${environment.apiBaseUrl}/api/booking`;
  constructor(private http: HttpClient) {}

  createBooking(booking: any) {
    return this.http.post(this.baseUrl, booking);
  }
  getBookingsByCustomerId(id: number) {
    return this.http.get(`${this.baseUrl}/customer/${id}`);
  }
  getBookingById(id: number) {
    return this.http.get(`${this.baseUrl}/${id}`);
  }
  getBookings(){
    return this.http.get(`${this.baseUrl}`);
  }
}
