import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core'; // Using inject
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import {
  Observable,
  tap,
  BehaviorSubject,
  finalize,
  map,
  Subject,
  throwError,
  of,
  catchError,
  switchMap,
  filter, 
  take,
} from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private cookieService = inject(CookieService);
  private http = inject(HttpClient);
  private router = inject(Router);

  private baseUrl = `${environment.apiBaseUrl}/api/auth`;

  private authState$ = new BehaviorSubject<boolean>(false);
  private _currentUserRole$ = new BehaviorSubject<string | null>(null);
  private _currentUserId$ = new BehaviorSubject<string | null>(null);

  private isRefreshing$ = new BehaviorSubject<boolean>(false);
  private newAccessToken$ = new Subject<string | null>();

  public isLoggedIn$ = this.authState$.asObservable();
  public currentUserRole$ = this._currentUserRole$.asObservable();
  public currentUserId$ = this._currentUserId$.asObservable();
  public isAdmin$ = this.currentUserRole$.pipe(map((role) => role === 'Admin'));
  public isCustomer$ = this.currentUserRole$.pipe(
    map((role) => role === 'Customer')
  );

  constructor() {
    const token = this.getAccessToken();
    if (token) {
      const claims = this.decodeToken(token);
      if (claims && claims.role) {
        this.authState$.next(true);
        this._currentUserRole$.next(claims.role);
        this._currentUserId$.next(claims.userId);
      } else {
        this.cookieService.delete('accessToken', '/');
      }
    }
  }

  adminLogin(credentials: {
    email: string;
    password: string;
  }): Observable<any> {
    return this.http
      .post(`${this.baseUrl}/admin/login`, credentials, {
        withCredentials: true,
      })
      .pipe(
        tap((response: any) => {
          this.setTokenAndState(response.accessToken);
        })
      );
  }

  userLogin(credentials: { email: string; password: string }): Observable<any> {
    return this.http
      .post(`${this.baseUrl}/user/login`, credentials, {
        withCredentials: true,
      })
      .pipe(
        tap((response: any) => {
          this.setTokenAndState(response.accessToken);
          console.log(response);
        })
      );
  }
  userRegister(credentials: {
    fullName: string;
    email: string;
    phoneNumber: string;
    password: string;
  }): Observable<any> {
    return this.http
      .post(`${this.baseUrl}/user/register`, credentials, {
        withCredentials: true,
      })
      .pipe(
        tap((response: any) => {
          this.setTokenAndState(response.accessToken);
          console.log(response);
        })
      );
  }

  getAccessToken(): string {
    return this.cookieService.get('accessToken');
  }

  logout(currentPath?: string): void {
    const currentRole = this.getRoleSnapshot(); 
    const redirectPath = (currentRole === 'Admin') ? '/admin/login' : '/login';
    const isAlreadyOnLoginPage = this.router.url.includes(redirectPath);
    let requiresRedirect=false;
    if(currentPath){

      requiresRedirect = 
          currentPath.includes('/bookings') || 
          currentPath.includes('/book-success') || 
          currentPath.includes('/book-hotel');
    }
    this.http
      .post(`${this.baseUrl}/logout`, {}, { withCredentials: true })
      .pipe(
        finalize(() => {
          this.cookieService.delete('accessToken', '/');
          this.authState$.next(false);
          this._currentUserRole$.next(null);
          if (!isAlreadyOnLoginPage) {
            //this.router.navigate([redirectPath]);
            if(currentRole === 'Admin'){
              this.router.navigate([redirectPath])
            }
            else if(requiresRedirect){
              this.router.navigate([redirectPath])
            }
          }
        })
      )
      .subscribe({
        next: () => console.log('Server has invalidated the refresh token.'),
        error: (err) =>
          console.warn('Server logout failed, but client is cleaned up.', err),
      });
  }
  public isLoggedInSnapshot(): boolean {
    return this.authState$.value;
  }
  public getRoleSnapshot(): string | null {
    return this._currentUserRole$.value;
  }

  public getUserIdSnapshot(): string | null {
    return this._currentUserId$.value;
  }

  private setTokenAndState(token: string) {
    this.cookieService.set('accessToken', token, {
      path: '/',
      sameSite: 'Lax',
      secure: true,
    });

    const claims = this.decodeToken(token);
    console.log('Role : ', claims.role);
    console.log('User ID : ', claims.userId);

    if (claims && claims.role) {
      this.authState$.next(true);
      this._currentUserRole$.next(claims.role);
      this._currentUserId$.next(claims.userId);
      console.log('Auth state set to:', this.authState$.value);
      console.log('Current role set to:', this._currentUserRole$.value);
      console.log('Current user ID set to:', this._currentUserId$.value);
    }
  }

  private decodeToken(token: string): {
    role: string | null;
    userId: string | null;
  } {
    if (!token) {
      console.log('no token');
      return { role: null, userId: null };
    }
    try {
      const decodedToken: any = jwtDecode(token);

      const role =
        decodedToken[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
        ] || null;

      const userId = decodedToken.sub || null;

      return { role, userId };
    } catch (Error) {
      console.error('Failed to decode token', Error);
      return { role: null, userId: null };
    }
  }

  public handleRefresh(): Observable<any> {
    if (this.isRefreshing$.value) {
      return this.newAccessToken$.pipe(
        filter((token) => token !== undefined),
        take(1),
        switchMap((token) => {
          if (token) {
            return of({ accessToken: token });
          }
          return throwError(() => new Error('Refresh token failed'));
        })
      );
    }

    this.isRefreshing$.next(true);
    this.newAccessToken$.next(null);

    return this.http
      .post<any>(`${this.baseUrl}/refresh`, {}, { withCredentials: true })
      .pipe(
        tap((response) => {
          this.setTokenAndState(response.accessToken);
          this.newAccessToken$.next(response.accessToken);
        }),
        catchError((err) => {
          console.error('Refresh token failed, logging out.', err);
          this.newAccessToken$.next(null);
          this.logout();
          return throwError(() => err);
        }),
        finalize(() => {
          this.isRefreshing$.next(false);
        })
      );
  }
}
