import { Component, OnInit } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router, RouterLink } from "@angular/router";

@Component({
  selector: 'app-hotels-list',
  imports: [RouterLink],
  templateUrl: './hotels-list.component.html',
  styleUrl: './hotels-list.component.scss'
})
export class HotelsListComponent implements OnInit {

  hotels : any[]=[];
  constructor(private hotelService : HotelService , private router : Router , private route : ActivatedRoute){

  }

  ngOnInit(){
    this.loadHotels();
  }
  
  loadHotels(){
    this.hotelService.getHotels().subscribe({
      next: (data) => { 
        this.hotels = data as any [];
      },
      error: (err) => { 
        console.error('Error:', err);
      },
      complete: () => {
        console.log('API call completed');
      }
    });
  }
  goToHotelDetails(id : number){
    
    this.router.navigate([id, 'info'], { relativeTo: this.route });
  }
  editHotel(hotelId : number){
    this.router.navigate(['/admin/hotels',hotelId,'update'])
  }
  deleteHotel(hotelId : number){
    this.router.navigate(['/admin/hotels',hotelId,'delete'])
  }

}
