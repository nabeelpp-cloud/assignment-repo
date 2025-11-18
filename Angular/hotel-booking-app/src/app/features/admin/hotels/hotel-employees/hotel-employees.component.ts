import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-hotel-employees',
  imports: [RouterModule],
  templateUrl: './hotel-employees.component.html',
  styleUrl: './hotel-employees.component.scss'
})
export class HotelEmployeesComponent {

  private destroy$ = new Subject<void>();
  hotel : any;
  hotelId !:number;
  constructor(private hotelService : HotelService,private route : ActivatedRoute,private router :Router){}

  ngOnInit(){
    this.route.parent?.parent?.paramMap
    .pipe(takeUntil(this.destroy$))
    .subscribe(params=>{
      this.hotelId = Number(params.get('id'));
      console.log("hotelId",this.hotelId)
      if (!isNaN(this.hotelId)) {
        this.loadHotelWithEmployees(this.hotelId);
      } else {
        console.error('Invalid hotelId');
      }
    })
  }
  loadHotelWithEmployees(hotelId : number){
      this.hotelService.getHotelWithEmployees(hotelId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next : (data) =>{
          this.hotel = data as any
          console.log("hotel",this.hotel)
        },
        error : (errors) =>{
            console.log(errors);
        },
        complete : ()=>{
          console.log("Api call compleated")
        }
      })
  }
  ngOnDestroy(){
    this.destroy$.next();
    this.destroy$.complete();
  }

  editRoom(roomId: number) {
    if (!roomId) {
      console.error('Room ID undefined');
      return;
    }

    this.router.navigate([
      '/admin/hotels',
      this.hotelId,
      'employees',
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
      'employees',
      roomId,
      'delete',
    ]);
  }
}
