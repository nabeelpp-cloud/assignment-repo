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

  getRoomDetailsByID(roomId : number){
    return this.http.get(`${this.baseUrl}/${roomId}`)
  }

  updateRoom(id:number,room : any){
    return this.http.patch(`${this.baseUrl}/${id}`,room)

  }
  deleteHotel(roomId: number) {
    return this.http.delete(`${this.baseUrl}/${roomId}`)

  }
}
