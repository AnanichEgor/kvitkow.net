import { NotificationItemComponent } from './components/notification/notification-item/notification-item.component';
import { NotificationComponent } from './components/notification/notification.component';
import { SubscriptionItemComponent } from './components/notification/subscription-item/subscription-item.component';
import { RegistrationConfirmationComponent } from './components/notification/registration-confirmation/registration-confirmation.component';
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
import { ErrorLogsComponent } from './components/admin/error-logs/error-logs.component';
import { AccountLogsComponent } from './components/admin/account-logs/account-logs.component';
import { PaymentLogsComponent } from './components/admin/payment-logs/payment-logs.component';
import { AdminMainComponent } from './components/admin/admin-main/admin-main.component';
import { SearchUserResultsComponent } from './components/search-user-results/search-user-results.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { QueryLogsComponent } from './components/admin/query-logs/query-logs.component';
import { TicketLogsComponent } from './components/admin/ticket-logs/ticket-logs.component';
import { DealLogsComponent } from './components/admin/deal-logs/deal-logs.component';
import { AdminUserComponent } from './components/admin/admin-user/admin-user.component';
import { UserSettingsProfileComponent } from './components/user-settings/user-settings-profile/user-settings-profile.component';
import { UserSettingsSecurityComponent } from './components/user-settings/user-settings-security/user-settings-security.component';
import { UserSettingsAdvancedComponent } from './components/user-settings/user-settings-advanced/user-settings-advanced.component';
import { ChatComponent } from './components/chat/chat.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'admin', component: AdminComponent,
    children: [
      { path: '', component: AdminMainComponent },
      { path: 'logs/errors', component: ErrorLogsComponent },
      { path: 'logs/accounts', component: AccountLogsComponent },
      { path: 'logs/payments', component: PaymentLogsComponent },
      { path: 'logs/queries', component: QueryLogsComponent },
      { path: 'logs/tickets', component: TicketLogsComponent },
      { path: 'logs/deals', component: DealLogsComponent },
      { path: 'users', component: AdminUserComponent }
    ]},
  { path: 'tickets', component: TicketComponent,  pathMatch: 'full'  },
  { path: 'tickets/:id', component: TicketDetailComponent, pathMatch: 'full' },
  { path: 'users', component: UsersComponent, pathMatch: 'full' },
  { path: 'users/registration', component: RegistrationComponent, pathMatch: 'full' },
  { path: 'search-ticket', component: SearchTicketComponent, pathMatch: 'full' },
  { path: 'search-user', component: SearchUserComponent, pathMatch: 'full' },
  { path: 'search-ticket-results', component: SearchTicketResultsComponent, pathMatch: 'full' },
  { path: 'search-user-results', component: SearchUserResultsComponent, pathMatch: 'full' },
  { path: 'tickets/ticket/add', component: TicketFormComponent, pathMatch: 'full' },
  {path: 'security',
  loadChildren: './components/security/security.module#SecurityModule'},
  { path: 'tickets/ticket/edit', component: TicketFormComponent, canActivate: [EditGuard], pathMatch: 'full' },
  { path: 'chat', component: ChatComponent, pathMatch: 'full'},
  { path: 'notification', component: NotificationComponent, pathMatch: 'full'},
  { path: 'notification/registration-confirmation/:username', component: RegistrationConfirmationComponent, pathMatch: 'full'},
  { path: 'settings', component: UserSettingsComponent,
    children: [
      { path: 'profile', component: UserSettingsProfileComponent, pathMatch: 'full'},
      { path: 'security', component: UserSettingsSecurityComponent, pathMatch: 'full'},
      { path: 'advanced', component: UserSettingsAdvancedComponent, pathMatch: 'full'},
    ]},
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
