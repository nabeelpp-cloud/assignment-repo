import { Routes } from '@angular/router';
import { AddRoomComponent } from './add-room/add-room.component';
import { DeleteRoomComponent } from './delete-room/delete-room.component';
import { EditRoomComponent } from './edit-room/edit-room.component';

export const roomsRoutes: Routes = [
  { path: 'rooms/create', component: AddRoomComponent },
  { path: 'rooms/:id/update', component: EditRoomComponent },
  { path: 'rooms/:id/delete', component: DeleteRoomComponent },
];
