import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-hotel',
  imports: [],
  templateUrl: './delete-hotel.component.html',
  styleUrl: './delete-hotel.component.scss'
})
export class DeleteHotelComponent {
  hotel:any;
  hotelId !: number;
  constructor(private hotelService : HotelService ,private router : Router,private route : ActivatedRoute) {}

  ngOnInit(){
    this.route.parent?.paramMap.subscribe(params => {
      const hotelId = Number(params.get('id'));
      if (!isNaN(hotelId)) {
        this.loadHotelDetail(hotelId);
      } else {
        console.error('Invalid hotelId');
      }
    });
  }
  loadHotelDetail(hotelId : number) {
    this.hotelService.getHotelById(hotelId).subscribe({
      next: (data) => {
        this.hotel = data as any;
      },
      error: (erros) => {
        console.log('Err ', erros);
      },
      complete: () => {
        console.log('Api calling completed');
      },
    });
  }
}
