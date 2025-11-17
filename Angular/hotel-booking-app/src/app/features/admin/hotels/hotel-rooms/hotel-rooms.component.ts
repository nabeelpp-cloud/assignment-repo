import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import {
  RoomStatusMap,
  getEnumName,
} from '../../../../shared/helper/enum-mapper';

@Component({
  selector: 'app-hotel-rooms',
  imports: [RouterModule],
  templateUrl: './hotel-rooms.component.html',
  styleUrl: './hotel-rooms.component.scss',
})
export class HotelRoomsComponent {
  hotel: any;
  hotelId!: number;
  constructor(
    private hotelService: HotelService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.parent?.parent?.paramMap.subscribe((params) => {
      this.hotelId = Number(params.get('id'));
      console.log(this.hotelId);
      if (!isNaN(this.hotelId)) {
        this.loadHotelWithRooms(this.hotelId);
      } else {
        console.error('Invalid hotelId');
      }
    });
  }
  loadHotelWithRooms(hotelId: number) {
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
  getRoomStatus(roomStatus: number) {
    return getEnumName(RoomStatusMap, roomStatus);
  }
  editRoom(roomId: number) {
    if (!roomId) {
      console.error('Room ID undefined');
      return;
    }

    this.router.navigate([
      '/admin/hotels',
      this.hotelId,
      'rooms',
      roomId,
      'update',
    ]);
  }

  deleteRoom(roomId: number) {
    if (!roomId) {
      console.error('Room ID undefined');
      return;
    }

    this.router.navigate([
      '/admin/hotels',
      this.hotelId,
      'rooms',
      roomId,
      'delete',
    ]);
  }
}
