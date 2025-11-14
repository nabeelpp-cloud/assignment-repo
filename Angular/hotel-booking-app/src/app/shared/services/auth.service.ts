import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core'; // Using inject
import { CookieService } from 'ngx-cookie-service';
import { Observable, tap, BehaviorSubject, finalize } from 'rxjs'; // Import BehaviorSubject
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private cookieService = inject(CookieService);
  private http = inject(HttpClient);
  private router = inject(Router);

  private baseUrl = `${environment.apiBaseUrl}/api/auth`;

  private authState$ = new BehaviorSubject<boolean>(
    this.cookieService.check('accessToken')
  );

  public isLoggedIn$ = this.authState$.asObservable();

  login(credentials: { email: string; password: string }): Observable<any> {
    return this.http
      .post(`${this.baseUrl}/login`, credentials, { withCredentials: true })
      .pipe(
        tap((response: any) => {
          this.cookieService.set('accessToken', response.accessToken, {
            path: '/',
            sameSite: 'Lax',
            secure: true,
          });
          this.authState$.next(true);
        })
      );
  }

  getAccessToken(): string {
    return this.cookieService.get('accessToken');
  }

  logout(): void {
    this.http.post(`${this.baseUrl}/logout`, {}, { withCredentials: true }) 
      .pipe(
        finalize(() => {
          this.cookieService.delete('accessToken', '/');
          this.authState$.next(false);
          this.router.navigate(['/admin/login']);
        })
      )
      .subscribe({
        next: () => console.log('Server has invalidated the refresh token.'),
        error: (err) => console.warn('Server logout failed, but client is cleaned up.', err)
      });
  }


  public isLoggedInSnapshot(): boolean {
    return this.authState$.value;
  }
}