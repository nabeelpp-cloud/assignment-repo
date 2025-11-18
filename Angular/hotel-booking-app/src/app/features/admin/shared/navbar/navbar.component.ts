import { Component, inject } from '@angular/core'; // import inject
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';
import { AsyncPipe, NgIf } from '@angular/common'; 
import { Observable } from 'rxjs'; 

@Component({
  selector: 'app-navbar',
  imports: [RouterModule, NgIf], 
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  isAdmin: boolean = false;
  
  constructor(private authService: AuthService ,private router : Router) {
    const role = this.authService.getRoleSnapshot();
    this.isAdmin = role === 'Admin';
    console.log(role);
  }

  logOutClicked() {
    this.authService.logout();
  }
  signInClicked() {
    this.router.navigate(["/login"]);
  }
}