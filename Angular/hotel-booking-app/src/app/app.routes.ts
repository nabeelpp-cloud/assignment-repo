import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () =>
      import('./features/admin/admin.routes').then(m => m.adminRoutes),
     
  },
  {
    path: '',
    loadChildren: () =>
      import('./features/user/user.route').then(m => m.userRoutes),
  },

  { path: '', redirectTo: '', pathMatch: 'full' },
];
