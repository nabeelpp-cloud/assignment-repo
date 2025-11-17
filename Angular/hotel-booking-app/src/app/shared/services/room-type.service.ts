import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RoomTypeService {
  private baseUrl = `${environment.apiBaseUrl}/api/roomType`;

  constructor(private http : HttpClient) { }

  getRoomTypes(){
    return this.http.get(this.baseUrl)
  }
}
