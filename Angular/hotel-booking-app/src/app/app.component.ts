import { Component, NgModule } from '@angular/core';
import { RouterModule } from "@angular/router";
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  imports: [RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',

})



export class AppComponent {
  title = 'hotel-booking-app';
}
