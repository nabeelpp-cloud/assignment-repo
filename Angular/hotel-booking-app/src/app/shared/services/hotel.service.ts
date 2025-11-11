import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { inject } from '@angular/core';
import { environment } from '../../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  private baseUrl = `${environment.apiBaseUrl}/api/hotel`;
  private selectedHotelSubject = new BehaviorSubject<any>(null);
  selectedHotel$=this.selectedHotelSubject.asObservable();

  constructor(private http : HttpClient) {}

  setSelectedHotel(hotel: any) {
    this.selectedHotelSubject.next(hotel);
  }

  getSelectedHotel() {
    return this.selectedHotelSubject.value;
  }
  getHotels() {
    return this.http.get(this.baseUrl);
  }

  getHotelById(id: number) {
    return this.http.get(`${this.baseUrl}/${id}`);
  }
  getHotelWithRooms(id : number){
    return this.http.get(`${this.baseUrl}/${id}/rooms`);
  }
  
  getHotelWithReviews(id : number){
    return this.http.get(`${this.baseUrl}/${id}/reviews`)
  }

  getHotelWithEmployees(id:number){
    return this.http.get(`${this.baseUrl}/${id}/employees`)
  }

  addHotel(hotel : any){
    return this.http.post(this.baseUrl,hotel);
  }

  updateHotel(hotelId:number,hotel : any){
    return this.http.patch(this.baseUrl,hotel);
  }
}