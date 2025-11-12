import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-hotel-employees',
  imports: [],
  templateUrl: './hotel-employees.component.html',
  styleUrl: './hotel-employees.component.scss'
})
export class HotelEmployeesComponent {

  private destroy$ = new Subject<void>();
  hotel : any;
  hotelId !:number;
  constructor(private hotelService : HotelService,private route : ActivatedRoute){}

  ngOnInit(){
    this.route.parent?.paramMap
    .pipe(takeUntil(this.destroy$))
    .subscribe(params=>{
      const hotelId=Number(params.get('id'));
      console.log("hotelId",hotelId)
      if (!isNaN(hotelId)) {
        this.loadHotelWithEmployees(hotelId);
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
}
