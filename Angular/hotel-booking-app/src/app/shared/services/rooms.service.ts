import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RoomsService {
  private baseUrl = `${environment.apiBaseUrl}/api/room`;

  constructor(private http : HttpClient) { }

  createRoom(room : any){
    return this.http.post(`${this.baseUrl}`,room)
  }
}
