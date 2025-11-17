import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const auth = inject(AuthService);
  const router = inject(Router);

  if (!auth.isLoggedInSnapshot()) {
    return router.createUrlTree(['/admin/login']);
  }

  const role = auth.getRoleSnapshot();

  if (role === 'Admin') {
    return true;
  }

  return router.createUrlTree(['/admin/login']);
};
