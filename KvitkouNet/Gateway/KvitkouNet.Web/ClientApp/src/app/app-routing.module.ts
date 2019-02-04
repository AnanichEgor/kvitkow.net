import { SecurityMenuComponent } from './components/security/security-menu/security-menu.component';
import { SecurityComponent } from './components/security/security.component';
import { NewRightComponent } from './components/security/new-right/new-right.component';
import { RightsComponent } from './components/security/rights/rights.component';
import { ChatComponent } from './components/chat/chat.component';
import { SearchTicketResultsComponent } from './components/search-ticket-results/search-ticket-results.component';
import { SearchTicketComponent } from './components/search-ticket/search-ticket.component';
import { SearchUserComponent } from './components/search-user/search-user.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AdminComponent } from './components/admin/admin.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { TicketFormComponent } from './components/ticket-form/ticket-form.component';
import { TicketDetailComponent } from './components/ticket-detail/ticket-detail.component';
import { UsersComponent } from './components/users/users.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { EditGuard } from './services/editGuard';
import { SearchUserResultsComponent } from './components/search-user-results/search-user-results.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'admin', component: AdminComponent, pathMatch: 'full' },
  { path: 'tickets/:id', component: TicketComponent, pathMatch: 'full'},
  { path: 'tickets/ticket/:id', component: TicketDetailComponent, pathMatch: 'full' },
  { path: 'users', component: UsersComponent, pathMatch: 'full' },
  { path: 'users/registration', component: RegistrationComponent, pathMatch: 'full' },
  { path: 'search-ticket', component: SearchTicketComponent, pathMatch: 'full' },
  { path: 'search-user', component: SearchUserComponent, pathMatch: 'full' },
  { path: 'search-ticket-results', component: SearchTicketResultsComponent, pathMatch: 'full' },
  { path: 'search-user-results', component: SearchUserResultsComponent, pathMatch: 'full' },
  { path: 'tickets/ticket/add', component: TicketFormComponent, pathMatch: 'full' },
  {path: 'security',
  loadChildren: 'app/security/security.module#SecurityModule'},
  { path: 'tickets/ticket/edit', component: TicketFormComponent, canActivate: [EditGuard], pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
