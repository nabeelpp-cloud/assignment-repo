import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-delete-hotel',
  imports: [CommonModule],
  templateUrl: './delete-hotel.component.html',
  styleUrl: './delete-hotel.component.scss',
})
export class DeleteHotelComponent {
  

  hotel: any;
  hotelId!: number;
  constructor(
    private hotelService: HotelService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.hotelId = Number(params.get('id'));
      if (this.hotelId) {
        this.loadHotelDetail(this.hotelId);
      }
    });
  }
  loadHotelDetail(hotelId: number) {
    this.hotelService.getHotelById(hotelId).subscribe({
      next: (data) => {
        this.hotel = data as any;
        console.log(this.hotel);
      },
      error: (erros) => {
        console.log('Err ', erros);
      },
      complete: () => {
        console.log('Api calling completed');
      },
    });
  }

  confirmDelete() {
    if (confirm('Are you sure you want to delete this hotel?')) {
      console.log(this.hotelId);
      this.hotelService.deleteHotel(this.hotelId).subscribe({
        next: (response) => {
          if(Number(response)>0){
            alert('Hotel deleted successfully');
            this.router.navigate(['/admin/hotels']);
          }
          else{
            alert('Error deleting hotel');
          }

        },
        error: (err) => {
          console.log(err);
          alert('Error deleting hotel');
        },
      });
    }
  }
  goBack() {
    this.router.navigate(["/admin/hotels"]);
  }
}
