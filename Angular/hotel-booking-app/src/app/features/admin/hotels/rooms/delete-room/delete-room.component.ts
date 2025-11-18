import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { RoomTypeService } from '../../../../../shared/services/room-type.service';
import { RoomsService } from '../../../../../shared/services/rooms.service';

@Component({
  selector: 'app-delete-room',
  imports: [],
  templateUrl: './delete-room.component.html',
  styleUrl: './delete-room.component.scss',
})
export class DeleteRoomComponent {
  constructor(
    private roomService: RoomsService,
    private roomTypeService: RoomTypeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  hotelId!: number;
  roomTypes: any[] = [];
  roomId!: number;
  room: any;

  private destroy$ = new Subject<void>();

  ngOnInit() {
    this.route.parent?.parent?.paramMap
      .pipe(takeUntil(this.destroy$))
      .subscribe((params) => {
        this.hotelId = Number(params.get('id'));
      });
    this.route.params?.subscribe((params) => {
      this.roomId = params['id'];
      if (this.roomId) {
        this.loadRoomDetails(this.roomId);
      }
    });
  }

  loadRoomDetails(roomId: number) {
    this.roomService
      .getRoomDetailsByID(roomId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data) => {
          this.room = data as any;
          console.log(this.room);
        },
        error: (err) => {
          console.log('Error', err);
        },
        complete: () => {
          console.log('Api call completed');
        },
      });
  }
  confirmDelete() {
    if (confirm('Are you sure you want to delete this room?')) {
      console.log(this.roomId);
      this.roomService.deleteHotel(this.roomId).subscribe({
        next: (response) => {
          console.log(response);
          if(Number(response)>0){
            alert('Room deleted successfully');
            this.router.navigate(['/admin/hotels/', this.hotelId, 'rooms']);
          }
          else{
            alert('Error deleting room');
          }

        },
        error: (err) => {
          console.log(err);
          alert('Error deleting room');
        },
      });
    }
  }
  goBack() {
    this.router.navigate(['/admin/hotels/', this.hotelId, 'rooms']);
  }
}
