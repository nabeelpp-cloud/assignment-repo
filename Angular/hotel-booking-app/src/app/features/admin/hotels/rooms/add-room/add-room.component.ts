import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelService } from '../../../../../shared/services/hotel.service';
import { RoomTypeService } from '../../../../../shared/services/room-type.service';
import { RoomsService } from '../../../../../shared/services/rooms.service';

@Component({
  selector: 'app-add-room',
  imports: [ReactiveFormsModule],
  templateUrl: './add-room.component.html',
  styleUrl: './add-room.component.scss',
})
export class AddRoomComponent {
  constructor(
    private roomService: RoomsService,
    private roomTypeService: RoomTypeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  hotelId!:number;
  createRoomForm: FormGroup = new FormGroup({
    roomNumber: new FormControl(""),
    hotelId: new FormControl(),
    roomTypeId: new FormControl(),
    status: new FormControl(),
    pricePerNight: new FormControl(''),
  });

  roomTypes: any[] = [];
  ngOnInit() {
    this.loadRoomTypes();
    this.route.parent?.parent?.paramMap.subscribe((params) => {
      this.createRoomForm.patchValue({
        hotelId: Number(params.get('id')),
      });
      this.hotelId=Number(params.get('id'));
    });
  }

  loadRoomTypes() {
    this.roomTypeService.getRoomTypes().subscribe({
      next: (data) => {
        this.roomTypes = data as any;
        console.log(this.roomTypes);
      },
      error: (err) => {
        console.log('Error', err);
      },
    });
  }
  addRoom() {
    if (this.createRoomForm.invalid) return;
    const formValue = this.createRoomForm.value;
    const room = {
      roomNumber: formValue.roomNumber,
      hotelId: Number(formValue.hotelId),
      roomTypeId: Number(formValue.roomTypeId),
      status: Number(formValue.status),        
      pricePerNight: Number(formValue.pricePerNight)
    };
    this.roomService.createRoom(room).subscribe({
      next: (respose) => {
        if (Number(respose) > 0) {
          console.log('Room added successfully');
          alert('Room added successfully');
          this.router.navigate(['/admin/hotel/',this.hotelId,"/rooms"]);
        }
      },
    });
  }
  changeToInt(val : any){
    return Number(val)

  }
}
