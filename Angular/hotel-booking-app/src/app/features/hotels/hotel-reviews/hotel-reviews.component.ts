import { Component } from '@angular/core';
import { HotelService } from '../../../shared/services/hotel.service';
import { ActivatedRoute } from '@angular/router';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-hotel-reviews',
  imports: [DecimalPipe],
  templateUrl: './hotel-reviews.component.html',
  styleUrl: './hotel-reviews.component.scss'
})
export class HotelReviewsComponent {
  hotel : any ;
  hotelId !: number;
  constructor(private hotelService : HotelService, private route : ActivatedRoute){}

  ngOnInit(){
    this.route.parent?.paramMap.subscribe(params=>{
      const hotelId=Number(params.get('id'));
      if (!isNaN(hotelId)) {
        this.loadHotelWithReviews(hotelId);
      } else {
        console.error('Invalid hotelId');
      }
    })
  }
  loadHotelWithReviews(hotelId : number){
      this.hotelService.getHotelWithReviews(hotelId).subscribe({
        next:(data)=>{
          this.hotel = data as any;
          console.log(this.hotel)
        }, 
        error:(err)=>{
          console.log(err);
        },
        complete:()=>{
          console.log('api fetching completated');
        }
      })
  }
}
