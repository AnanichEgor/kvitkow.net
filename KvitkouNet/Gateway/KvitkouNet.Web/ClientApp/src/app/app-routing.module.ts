import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { TicketFormComponent } from './ticket-form/ticket-form.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { TicketComponent } from './ticket/ticket.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'admin', component: AdminComponent, pathMatch: 'full' },
  { path: 'ticket/add', component: TicketFormComponent, pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
  { path: 'ticket', component: TicketComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
