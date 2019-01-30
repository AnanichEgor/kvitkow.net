import { RegistrationComponent } from './registration/registration.component';
import { UsersComponent } from './users/users.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AdminComponent } from './components/admin/admin.component';
import { TicketFormComponent } from './components/ticket-form/ticket-form.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { UsersComponent } from './components/users/users.component';
import { RegistrationComponent } from './components/registration/registration.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'admin', component: AdminComponent, pathMatch: 'full' },
  { path: 'tickets', component: TicketComponent,  pathMatch: 'full'  },
  { path: 'tickets/:id', component: TicketDetailComponent, pathMatch: 'full' },
  { path: 'users', component: UsersComponent, pathMatch: 'full' },
  { path: 'users/registration', component: RegistrationComponent, pathMatch: 'full' },
  { path: 'ticket/add', component: TicketFormComponent, pathMatch: 'full' },
  { path: 'ticket/edit', component: TicketFormComponent, canActivate: [EditGuard], pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
