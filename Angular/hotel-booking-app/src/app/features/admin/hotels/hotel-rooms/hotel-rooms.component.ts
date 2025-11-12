import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute } from '@angular/router';
import { RoomStatusMap, getEnumName } from '../../../../shared/helper/enum-mapper';

@Component({
  selector: 'app-hotel-rooms',
  imports: [],
  templateUrl: './hotel-rooms.component.html',
  styleUrl: './hotel-rooms.component.scss',
})
export class HotelRoomsComponent {
  hotel: any;
  hotelId!: number;
  constructor(
    private hotelService: HotelService,
    private route: ActivatedRoute,
  ) {}

  ngOnInit() {
    this.route.parent?.paramMap.subscribe(params => {
      const hotelId = Number(params.get('id'));
      if (!isNaN(hotelId)) {
        this.loadHotelWithRooms(hotelId);
      } else {
        console.error('Invalid hotelId');
      }
    });
  }
  loadHotelWithRooms(hotelId : number) {
    this.hotelService.getHotelWithRooms(hotelId).subscribe({
      next: (data) => {
        this.hotel = data as any;
        console.log(this.hotel.rooms);
      },
      error: (erros) => {
        console.log('Err ', erros);
      },
      complete: () => {
        console.log('Api calling completed');
      },
    });
  }
  getRoomStatus(roomStatus : number){
    return getEnumName (RoomStatusMap,roomStatus)
  }
}
