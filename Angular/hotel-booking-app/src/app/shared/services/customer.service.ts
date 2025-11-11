import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  
  private baseUrl = `${environment.apiBaseUrl}/api/customer`;
  constructor(private http : HttpClient) { }

  getCustomerList(){
    return this.http.get(this.baseUrl);
  }
  getCustomerDetails(id : number){
    return this.http.get(`${this.baseUrl}/${id}`);
  }
  getCustomerWithBookings(id : number ){
    return this.http.get(`${this.baseUrl}/${id}/bookings`);
  }
}
