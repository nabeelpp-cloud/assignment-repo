import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (!authService.isLoggedInSnapshot()) {
    return router.createUrlTree(['/login']);
  }

  const role = authService.getRoleSnapshot();

  if (role === 'Customer') {
    return true;
  }

  return router.createUrlTree(['/login']);
};
