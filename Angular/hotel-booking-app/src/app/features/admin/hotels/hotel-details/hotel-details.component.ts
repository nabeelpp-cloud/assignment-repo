import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, RouterOutlet, RouterLinkWithHref, RouterLinkActive, RouterLink } from '@angular/router';

@Component({
  selector: 'app-hotel-details',
  imports: [RouterOutlet, RouterLink, RouterLinkWithHref, RouterLinkActive],
  templateUrl: './hotel-details.component.html',
  styleUrl: './hotel-details.component.scss'
})
export class HotelDetailsComponent {
  isSidebarOpen : boolean = false;
  constructor(){

  }
  ngOnInit(){
    this.isSidebarOpen = true;
    
  } 
}
