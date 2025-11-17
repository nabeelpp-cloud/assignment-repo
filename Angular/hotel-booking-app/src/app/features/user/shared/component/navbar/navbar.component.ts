import { Component } from '@angular/core';
import { AuthService } from '../../../../../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  
  isCustomer: boolean = false;
  
  constructor(private authService: AuthService ,private router : Router) {
    const role = this.authService.getRoleSnapshot();
    this.isCustomer = role === 'Customer';
  }

  logOutClicked() {
    this.authService.logout();
  }
  signInClicked() {
    this.router.navigate(["/login"]);
  }
}
