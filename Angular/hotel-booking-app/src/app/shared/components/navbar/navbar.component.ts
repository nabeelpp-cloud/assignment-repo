import { Component, inject } from '@angular/core'; // import inject
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { AsyncPipe, NgIf } from '@angular/common'; 
import { Observable } from 'rxjs'; 

@Component({
  selector: 'app-navbar',
  imports: [RouterModule, AsyncPipe, NgIf], 
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  private authService = inject(AuthService);

  public isLoggedIn$: Observable<boolean>;

  constructor() {
    this.isLoggedIn$ = this.authService.isLoggedIn$;
  }

  logOutClicked(){
    this.authService.logout();
  }
}