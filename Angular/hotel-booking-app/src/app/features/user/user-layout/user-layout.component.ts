import { Component } from '@angular/core';
import { NavbarComponent } from "../shared/component/navbar/navbar.component";
import { RouterModule } from "@angular/router";

@Component({
  selector: 'app-user-layout',
  imports: [NavbarComponent, RouterModule],
  templateUrl: './user-layout.component.html',
  styleUrl: './user-layout.component.scss'
})
export class UserLayoutComponent {

}
