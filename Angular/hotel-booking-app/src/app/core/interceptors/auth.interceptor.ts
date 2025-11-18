import {
  HttpInterceptorFn,
  HttpRequest,
  HttpHandlerFn,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { inject } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { AuthService } from '../../shared/services/auth.service';

const addAuthHeader = (req: HttpRequest<unknown>, token: string) => {
  return req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`,
    },
  });
};

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
): Observable<HttpEvent<unknown>> => {
  
  const cookieService = inject(CookieService);
  const authService = inject(AuthService); 
  const accessToken = cookieService.get('accessToken');
  const isApiRequest = req.url.startsWith(environment.apiBaseUrl);
  
  const authUrl = `${environment.apiBaseUrl}/api/auth`;
  const isAuthRequest = 
      req.url.startsWith(`${authUrl}/admin/login`) || 
      req.url.startsWith(`${authUrl}/user/login`) ||
      req.url.startsWith(`${authUrl}/user/register`) ||
      req.url.startsWith(`${authUrl}/refresh`);

  // 1. Add token ONLY if it's an API request AND NOT an auth request
  if (accessToken && isApiRequest && !isAuthRequest) { // 👈 --- MODIFIED THIS LINE ---
    req = addAuthHeader(req, accessToken);
  }

  // 2. Send the request
  return next(req).pipe(
    catchError((err: any) => {
      
      // 3. Check for 401 Unauthorized error
      if (err instanceof HttpErrorResponse && err.status === 401) {
        
        // 4. If it was an auth request that failed, just let it fail.
        // (This catches bad logins or bad refresh tokens)
        if (isAuthRequest) {
          // We check for /refresh specifically to log out.
          if (req.url.startsWith(`${authUrl}/refresh`)) {
            console.error('Refresh token request failed. Logging out.');
            authService.logout();
          }
          // For login/register, just let the component handle the error.
          return throwError(() => err);
        }

        // 5. It was a normal API call that failed. Try to refresh.
        return authService.handleRefresh().pipe(
          switchMap((response: any) => {
            console.log('Token refreshed. Retrying original request.');
            return next(addAuthHeader(req, response.accessToken));
          }),
          catchError((refreshErr) => {
            return throwError(() => refreshErr);
          })
        );
      }

      // 6. If it wasn't a 401, just re-throw the error
      return throwError(() => err);
    })
  );
};