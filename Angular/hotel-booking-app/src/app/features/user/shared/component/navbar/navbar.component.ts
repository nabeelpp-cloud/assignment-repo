import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../../shared/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [], // You might need CommonModule or others here depending on your app
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit {
  isCustomer: boolean = false;
  isLoggedIn: boolean = false; 

  constructor(private authService: AuthService, private router: Router,private route : ActivatedRoute) {}

  returnUrl: string = '/hotels';
  ngOnInit() {
    this.authService.currentUserRole$.subscribe((role) => {
      this.isCustomer = role === 'Customer';
    });

    this.authService.isLoggedIn$.subscribe((status) => {
      this.isLoggedIn = status;
    });
  }

  logOutClicked() {
    if(confirm('Are you sure you want to log out?')){
      this.authService.logout();
    }
  }

  signInClicked() {
    this.returnUrl = this.router.url;
    this.router.navigate(['/login'],{
      queryParams: { returnUrl: this.returnUrl } 
    });

  }

  myBookings(){
    this.router.navigate(["/bookings"])
  }
  home(){
    this.router.navigate(["/home"])
  }
}