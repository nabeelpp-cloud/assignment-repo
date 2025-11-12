import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterLinkActive, RouterLinkWithHref, RouterOutlet } from '@angular/router';
import { HotelService } from '../../../../shared/services/hotel.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-hotel-info',
  imports: [],
  templateUrl: './hotel-info.component.html',
  styleUrl: './hotel-info.component.scss'
})
export class HotelInfoComponent {
  hotelId ! : number ;
  hotel : any ;
  isLoaded : boolean = false;

  private destroy$ = new Subject<void>();

  constructor(private route:ActivatedRoute,private hotelService : HotelService){

  }
  ngOnInit(){
    this.isLoaded = true;
    this.route.parent?.paramMap
    .pipe(takeUntil(this.destroy$))
    .subscribe(params => {
      const hotelId = Number(params.get('id'));
      if (!isNaN(hotelId)) {
        this.loadHotelDetail(hotelId);
      } else {
        console.error('Invalid hotelId');
      }
    });
  }
  loadHotelDetail(hotelId : number) {
    this.hotelService.getHotelById(hotelId)
    .pipe(takeUntil(this.destroy$))
    .subscribe({
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
  ngOnDestroy(){
    this.destroy$.next();
    this.destroy$.complete();
  }
}
