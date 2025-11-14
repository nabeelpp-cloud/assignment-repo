import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelService } from '../../../../shared/services/hotel.service';
import { SearchStateService } from '../../shared/services/search-state.service';
import { Subject, takeUntil } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-book-hotel',
  imports: [CommonModule],
  templateUrl: './book-hotel.component.html',
  styleUrl: './book-hotel.component.scss',
})
export class BookHotelComponent {
  updateTotal() {
    throw new Error('Method not implemented.');
  }
  bookNow() {
    throw new Error('Method not implemented.');
  }
  hotelId: any;
  hotel: any;
  checkInDate: any;
  checkOutDate: any;
  rooms : any [] = [];
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
          this.rooms= this.hotel.rooms;
          console.log(this.hotel);
          console.log(this.rooms);
        },
        error: (err) => {
          console.log('Error', err);
        },
      });
  }
  isOpen : boolean = false;
  selectedRoom: any = null;
  selectedRooms : any[] = [];
  

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  selectRoom(room: any, event: MouseEvent) {
    event.stopPropagation();
    this.selectedRoom = room;
    this.isOpen = false; 
  }
  
  
  addRoom() {
    if (!this.selectedRoom) return;
  
    this.selectedRooms.push(this.selectedRoom);
    console.log(this.selectedRooms);
    console.log(this.rooms);
    this.rooms = this.rooms.filter(x => x.id !== this.selectedRoom.id);
    console.log(this.rooms);
  
    this.selectedRoom = null;
  }
  
  removeRoom(room: any) {
    if (!room) return;
  
    this.selectedRooms = this.selectedRooms.filter(x => x.id !== room.id);
  
    this.rooms.push(room);
  }
  
}
