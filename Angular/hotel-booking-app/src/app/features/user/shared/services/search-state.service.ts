import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchStateService {

  constructor() { }

  checkInDate$ = new BehaviorSubject<string>('');
  checkOutDate$ = new BehaviorSubject<string>('');

  setDates(checkIn: string, checkOut: string) {
    this.checkInDate$.next(checkIn);
    this.checkOutDate$.next(checkOut);
  }
  
}
