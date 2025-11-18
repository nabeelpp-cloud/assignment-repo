import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RoomTypeService } from '../../../../../shared/services/room-type.service';
import { RoomsService } from '../../../../../shared/services/rooms.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-edit-room',
  imports: [ReactiveFormsModule],
  templateUrl: './edit-room.component.html',
  styleUrl: './edit-room.component.scss',
})
export class EditRoomComponent {
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

  updateRoomForm: FormGroup = new FormGroup({
    roomNumber: new FormControl(),
    hotelId: new FormControl(),
    roomTypeId: new FormControl(),
    status: new FormControl(),
    pricePerNight: new FormControl(''),
  });

  ngOnInit() {
    this.loadRoomTypes();
    this.route.parent?.parent?.paramMap
      .pipe(takeUntil(this.destroy$))
      .subscribe((params) => {
        this.updateRoomForm.patchValue({
          hotelId: Number(params.get('id')),
        });
        this.hotelId = Number(params.get('id'));
      });
    this.route.params?.subscribe((params) => {
      this.roomId = params['id'];
      if (this.roomId) {
        this.loadRoomDetails(this.roomId);
      }
    });
  }

  loadRoomTypes() {
    this.roomTypeService
      .getRoomTypes()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data) => {
          this.roomTypes = data as any;

          if (this.room) {
            this.updateRoomForm.patchValue({
              roomTypeId: this.roomTypes.find(
                (rt) => rt.typeName === this.room.roomType
              )?.id,
            });
          }
        },
        error: (err) => {
          console.log('Error', err);
        },
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
          if (this.room) {
            this.updateRoomForm.patchValue({
              roomNumber: this.room.roomNumber,
              hotelId: this.room.hotelId,
              roomTypeId: this.roomTypes.find(
                (rt) => rt.typeName === this.room.roomType
              )?.id,
              status: this.room.status,
              pricePerNight: this.room.pricePerNight,
            });
          }
        },
        error: (err) => {
          console.log('Error', err);
        },
        complete: () => {
          console.log('Api call completed');
        },
      });
  }
  updateRoom() {
    if (this.updateRoomForm.invalid) return;
    const formValue=this.updateRoomForm.value;
    const room = {
      roomNumber: formValue.roomNumber,
      hotelId: Number(formValue.hotelId),
      roomTypeId: Number(formValue.roomTypeId),
      status: Number(formValue.status),        
      pricePerNight: Number(formValue.pricePerNight)
    };
    this.roomService
      .updateRoom(this.roomId, room)
      .subscribe({
        next: (response) => {
          if (Number(response) > 0) {
            console.log('Room updated Succesfully');
            console.log(this.hotelId);
            this.router.navigate(['/admin/hotels/', this.hotelId, 'rooms']);
          }
        },
        error: (err) => {
          console.log('Error', err);
        },
      });
  }
  goBack() {
    this.router.navigate(['/admin/hotels/', this.hotelId, 'rooms']);
  }
}
