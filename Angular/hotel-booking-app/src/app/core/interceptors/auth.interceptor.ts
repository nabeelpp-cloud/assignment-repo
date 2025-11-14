import { HttpInterceptorFn, HttpRequest, HttpHandlerFn, HttpEvent } from '@angular/common/http';
import { inject } from '@angular/core';
import { CookieService } from 'ngx-cookie-service'; // Import your cookie service
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';


export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
): Observable<HttpEvent<unknown>> => {
  
  const cookieService = inject(CookieService);
  const accessToken = cookieService.get('accessToken');

  const isApiRequest = req.url.startsWith(environment.apiBaseUrl); 

  if (accessToken && isApiRequest) {
    const clonedReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`
      }
    });

    return next(clonedReq);
  }

  return next(req);
};